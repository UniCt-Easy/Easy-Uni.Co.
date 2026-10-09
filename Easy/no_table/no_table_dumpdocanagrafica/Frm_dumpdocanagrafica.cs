/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_dumpdocanagrafica {
    public partial class Frm_dumpdocanagrafica : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        ISaveFileDialog saveZipDlg;
        IOpenFileDialog openExcelDlg;

        // DataTable usato come buffer per i dati letti dal foglio Excel.
        // Le colonne devono avere lo stesso nome delle intestazioni del foglio.
        DataTable mData = new DataTable();

        // Sorgente di cancellazione per l'operazione di download in corso. null quando inattiva.
        CancellationTokenSource _cts;

        // true quando l'utente chiede di chiudere mentre un'elaborazione è in corso: la chiusura viene
        // rimandata al termine del task di background.
        bool _closeAfterCancel;

        struct ProgressInfo {
            public int Done;
            public int Total;
            public int CurrentIdreg;
            public int FilesSoFar;
        }

        // Un BLOB di allegato all'interno di una riga: colonna BLOB, colonna idfilestorage per il backend
        // MongoDB, colonna con il nome originale del file (null quando la tabella non ce l'ha) e prefisso
        // da usare per il nome sintetico di fallback.
        class BlobSpec {
            public string BlobColumn;
            public string StorageColumn;
            public string FileNameColumn;
            public string FallbackPrefix;
            public BlobSpec(string blob, string storage, string fileNameColumn, string fallbackPrefix) {
                BlobColumn = blob; StorageColumn = storage; FileNameColumn = fileNameColumn; FallbackPrefix = fallbackPrefix;
            }
        }

        // Tabella figlia di registry contenente allegati. SubPath restituisce i segmenti di cartella da
        // creare sotto la cartella dell'anagrafica: costante per la maggior parte delle tabelle, dipendente
        // dalla riga per le modalità di pagamento (una sottocartella per ogni idregistrypaymethod).
        class RegistrySource {
            public string TableName;
            public string IdColumn;
            public BlobSpec[] Blobs;
            public Func<DataRow, string[]> SubPath;
            public RegistrySource(string table, string idcol, Func<DataRow, string[]> subPath, params BlobSpec[] blobs) {
                TableName = table; IdColumn = idcol; SubPath = subPath; Blobs = blobs;
            }
        }

        // L'ordine determina l'ordine delle entry nello ZIP. Le caselle di spunta del gruppo "Tabelle da
        // includere" sono associate a queste voci da _tableOfCheckBox, popolato nel costruttore.
        static readonly RegistrySource[] AllSources = new[] {
            new RegistrySource("registrycvattachment", "idregistrycvattachment", row => new[] { "CV" },
                new BlobSpec("attachment", "idfilestorage", "filename", "registrycvattachment")),
            new RegistrySource("registryattachment", "idattachment", row => new[] { "Allegati" },
                new BlobSpec("attachment", "idfilestorage", "filename", "registryattachment")),
            new RegistrySource("registryvisura", "idregistryvisura", row => new[] { "Visure" },
                new BlobSpec("visuracertification", "idfilestorage", "filename", "registryvisura")),
            new RegistrySource("registrycasellariogiudiziale", "idregistrycasellariogiudiziale", row => new[] { "Casellario_Giudiziale" },
                new BlobSpec("casellariocertification", "idfilestorage", "filename", "registrycasellariogiudiziale")),
            new RegistrySource("registrycasellarioamministrativo", "idregistrycasellarioamministrativo", row => new[] { "Casellario_Amministrativo" },
                new BlobSpec("casellariocertification", "idfilestorage", "filename", "registrycasellarioamministrativo")),
            new RegistrySource("registryottemperanzalegge68_99", "idregistryottemperanzalegge", row => new[] { "Ottemperanza_L68_99" },
                new BlobSpec("ottemperanzacertification", "idfilestorage", "filename", "registryottemperanzalegge68_99")),
            new RegistrySource("registryregolaritafiscale", "idregistryregolaritafiscale", row => new[] { "Regolarita_Fiscale" },
                new BlobSpec("regolaritacertification", "idfilestorage", "filename", "registryregolaritafiscale")),
            new RegistrySource("registryverificaanac", "idregistryverificaanac", row => new[] { "Verifica_ANAC" },
                new BlobSpec("verificaanaccertification", "idfilestorage", "filename", "registryverificaanac")),
            new RegistrySource("registrypattointegrita", "idregistrypattointegrita", row => new[] { "Patto_Integrita" },
                new BlobSpec("pattointegritacertification", "idfilestorage", "filename", "registrypattointegrita")),

            // Due BLOB nella stessa riga, stessa sottocartella.
            new RegistrySource("registrydurc", "idregistrydurc", row => new[] { "DURC" },
                new BlobSpec("durccertification", "idfilestorage", "durccertificationfilename", "DURC"),
                new BlobSpec("selfcertification", "idfilestorage2", "selfcertificationfilename", "Autocert_DURC")),

            // ccdedicato_doc/_cf non hanno una colonna filename: il nome è incapsulato come header
            // null-terminated nel BLOB.
            new RegistrySource("registrypaymethod", "idregistrypaymethod",
                row => new[] { "Modalita_Pagamento", row["idregistrypaymethod"].ToString() },
                new BlobSpec("ccdedicato_doc", "idfilestorage2", null, "CCdedicato_doc"),
                new BlobSpec("ccdedicato_cf", "idfilestorage", null, "CCdedicato_cf")),

            // Figlio di registrypaymethod: si annida sotto la cartella della modalità di pagamento.
            new RegistrySource("registrypaymethodattachment", "idattachment",
                row => new[] { "Modalita_Pagamento", row["idregistrypaymethod"].ToString(), "Allegati" },
                new BlobSpec("attachment", "idfilestorage", "filename", "paymethod_attachment")),
        };

        // Casella di spunta -> nome della tabella che include. La proprietà Tag non è utilizzabile allo
        // scopo: è il canale di binding dichiarativo del framework, e HelpForm.clearControl salta solo i
        // controlli con Tag vuoto. Su una CheckBox con Tag valorizzato imposta ThreeState=true e
        // CheckState=Indeterminate: da lì un clic dell'utente porta allo stato indeterminato invece che a
        // quello deselezionato, e Checked resta true (Checked == CheckState != Unchecked), per cui la
        // tabella finiva nello ZIP anche quando appariva deselezionata.
        readonly Dictionary<CheckBox, string> _tableOfCheckBox = new Dictionary<CheckBox, string>();

        // Chiamata dal framework (FormController.Clear) al termine di ogni azzeramento del form: le caselle
        // devono restare a due stati e tornare deselezionate, così che l'utente scelga esplicitamente cosa
        // includere.
        public void AfterClear() {
            SetAllTables(false);
        }

        public Frm_dumpdocanagrafica() {
            InitializeComponent();

            _tableOfCheckBox[chkCv] = "registrycvattachment";
            _tableOfCheckBox[chkAllegati] = "registryattachment";
            _tableOfCheckBox[chkVisure] = "registryvisura";
            _tableOfCheckBox[chkCasellarioGiud] = "registrycasellariogiudiziale";
            _tableOfCheckBox[chkCasellarioAmm] = "registrycasellarioamministrativo";
            _tableOfCheckBox[chkOttemperanza] = "registryottemperanzalegge68_99";
            _tableOfCheckBox[chkRegolaritaFiscale] = "registryregolaritafiscale";
            _tableOfCheckBox[chkVerificaAnac] = "registryverificaanac";
            _tableOfCheckBox[chkPattoIntegrita] = "registrypattointegrita";
            _tableOfCheckBox[chkDurc] = "registrydurc";
            _tableOfCheckBox[chkPayMethod] = "registrypaymethod";
            _tableOfCheckBox[chkPayMethodAttach] = "registrypaymethodattachment";
            SetAllTables(false);

            saveZipDlg = createSaveFileDialog(_saveZipDlg);
            openExcelDlg = createOpenFileDialog(_openExcelDlg);
            openExcelDlg.FileName = "openFileDialog";
            openExcelDlg.Title = "Selezionare il file Excel da importare";

            if (isBlazor()) {
                txtZipFile.Visible = false;
                btnSelezionaZip.Visible = false;
            }
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
        }

        private void SelezionaArchivio() {
            if (saveZipDlg.ShowDialog(this) == DialogResult.OK) {
                txtZipFile.Text = saveZipDlg.FileName;
            }
        }

        private void btnSelezionaZip_Click(object sender, EventArgs e) {
            SelezionaArchivio();
        }

        // Le tabelle selezionate, nell'ordine di AllSources (indipendente dall'ordine dei controlli).
        // Da invocare sul thread della UI.
        private List<RegistrySource> GetSelectedSources() {
            var checkedNames = new List<string>();
            foreach (var kv in _tableOfCheckBox) {
                // CheckState invece di Checked: se il framework dovesse comunque rendere tri-stato la
                // casella, lo stato indeterminato non deve valere come selezione.
                if (kv.Key.CheckState == CheckState.Checked) checkedNames.Add(kv.Value);
            }
            var selected = new List<RegistrySource>();
            foreach (var src in AllSources) {
                if (checkedNames.Contains(src.TableName)) selected.Add(src);
            }
            return selected;
        }

        private void SetAllTables(bool value) {
            foreach (var chk in _tableOfCheckBox.Keys) {
                chk.ThreeState = false;
                chk.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void btnSelezionaTutto_Click(object sender, EventArgs e) {
            SetAllTables(true);
        }

        private void btnDeselezionaTutto_Click(object sender, EventArgs e) {
            SetAllTables(false);
        }

        private void btnSelezionaExcel_Click(object sender, EventArgs e) {
            // Riempie il datatable mData leggendo dal foglio Excel.
            mData.Clear();
            addColumnExcel(mData);

            if (!LeggiFile()) {
                txtExcelFile.Text = "";
                mData.Clear();
                return;
            }
        }

        // Stesso pattern usato in cu_details_default: pre-popola le colonne
        // con i nomi delle intestazioni attese dal foglio Excel.
        private void addColumnExcel(DataTable tExcel) {
            if (!tExcel.Columns.Contains("Denominazione"))
                tExcel.Columns.Add("Denominazione", typeof(string));
            if (!tExcel.Columns.Contains("Codice"))
                tExcel.Columns.Add("Codice", typeof(string));
        }

        // Legge un foglio Excel in mData, mappando le intestazioni alle colonne con lo stesso nome.
        private bool LeggiFile() {
            DialogResult dr = openExcelDlg.ShowDialog(this);
            if (dr != DialogResult.OK) return false;

            try {
                string fileName = openExcelDlg.FileName;
                var Xcel = new ExcelImport();
                Xcel.ImportTable(fileName, mData, true, 2);
                txtExcelFile.Text = fileName;
            }
            catch (Exception ex) {
                show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }

            if (!verificaValiditaFileExcel()) {
                show(this, "Il file selezionato non è valido. Verificare la presenza delle colonne 'Denominazione' e 'Codice'.", "Errore");
                return false;
            }

            return true;
        }

        // Verifica che il foglio Excel contenga almeno una riga valida con il "Codice" popolato.
        private bool verificaValiditaFileExcel() {
            if (mData.Select().Length == 0) return false;
            foreach (DataRow r in mData.Select()) {
                if (r["Codice"] != DBNull.Value && r["Codice"].ToString().Trim().Length > 0) return true;
            }
            return false;
        }

        private async void btnEseguiDownload_Click(object sender, EventArgs e) {
            if (isBlazor() && string.IsNullOrEmpty(txtZipFile.Text)) {
                SelezionaArchivio();
            }

            string zipPath = txtZipFile.Text;

            if (mData == null || mData.Select().Length == 0) {
                show("Selezionare prima un file Excel valido.", "Avviso");
                return;
            }
            if (string.IsNullOrEmpty(zipPath)) {
                show("Selezionare l'archivio ZIP di destinazione.", "Avviso");
                return;
            }
            string zipDir = Path.GetDirectoryName(zipPath);
            if (string.IsNullOrEmpty(zipDir) || !Directory.Exists(zipDir)) {
                show("La cartella che dovrebbe contenere l'archivio ZIP non esiste.", "Avviso");
                return;
            }

            // Letta qui, sul thread della UI: il thread di background non può accedere ai controlli.
            var sources = GetSelectedSources();
            if (sources.Count == 0) {
                show("Selezionare almeno una tabella da includere.", "Avviso");
                return;
            }

            // Struttura delle cartelle scelta dall'utente. Letta sul thread della UI e catturata
            // nella closure del task di background.
            //   false -> anagrafica-first: {idreg}_{title} / {tipo allegato} / file  (predefinito)
            //   true  -> tipo-first:       {tipo allegato} / {idreg}_{title} / file
            bool typeFirst = rbStructType.Checked;

            var errors = new StringBuilder();
            var idregs = new List<int>();
            int rowNum = 1; // l'intestazione conta come riga 1
            foreach (DataRow r in mData.Select()) {
                rowNum++;
                if (r["Codice"] == DBNull.Value) continue;
                string sval = r["Codice"].ToString().Trim();
                if (sval.Length == 0) continue;

                int idreg;
                if (!int.TryParse(sval, out idreg)) {
                    double d;
                    if (double.TryParse(sval, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out d)
                        || double.TryParse(sval, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out d)) {
                        idreg = (int)d;
                    }
                    else {
                        errors.AppendLine($"Riga {rowNum}: valore 'Codice' non numerico: {sval}");
                        continue;
                    }
                }
                if (!idregs.Contains(idreg)) idregs.Add(idreg);
            }

            if (idregs.Count == 0) {
                show("Nessun valore valido trovato nella colonna 'Codice'.\n" + errors, "Avviso");
                return;
            }

            // Mette la UI in modalità "occupata" e avvia il dump in background.
            _cts = new CancellationTokenSource();
            SetUiBusy(true, idregs.Count);

            IProgress<ProgressInfo> progress = new Progress<ProgressInfo>(info => {
                if (progressBar1.Maximum != info.Total) progressBar1.Maximum = Math.Max(1, info.Total);
                progressBar1.Value = Math.Min(info.Done, progressBar1.Maximum);
                lblStatus.Text = $"Elaborazione {info.Done}/{info.Total} - idreg {info.CurrentIdreg} - file scaricati: {info.FilesSoFar}";
            });

            int filesCount = 0;
            int regsProcessed = 0;
            bool wasCancelled = false;
            CancellationToken ct = _cts.Token;

            try {
                var result = await Task.Run(() => {
                    int localFiles = 0;
                    int localReg = 0;
                    // Un unico archivio ZIP aperto in modalità Create per tutta l'elaborazione.
                    // Viene usato solo da questo thread di background, quindi non servono lock.
                    using (var zipStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
                    using (var zip = new ZipArchive(zipStream, ZipArchiveMode.Create)) {
                        foreach (int idreg in idregs) {
                            if (ct.IsCancellationRequested) break;
                            try {
                                localFiles += ProcessIdreg(idreg, zip, sources, typeFirst, errors, ct);
                            }
                            catch (OperationCanceledException) {
                                break;
                            }
                            catch (Exception ex) {
                                errors.AppendLine($"idreg {idreg}: {ex.Message}");
                            }
                            localReg++;
                            progress.Report(new ProgressInfo {
                                Done = localReg,
                                Total = idregs.Count,
                                CurrentIdreg = idreg,
                                FilesSoFar = localFiles,
                            });
                        }
                    }
                    return new { Reg = localReg, Files = localFiles };
                });
                regsProcessed = result.Reg;
                filesCount = result.Files;
                wasCancelled = ct.IsCancellationRequested;
            }
            catch (OperationCanceledException) {
                wasCancelled = true;
            }
            catch (Exception ex) {
                errors.AppendLine("Errore: " + ex.Message);
            }
            finally {
                SetUiBusy(false, 0);
                if (_cts != null) { _cts.Dispose(); _cts = null; }
            }

            // L'utente ha chiuso il form durante l'elaborazione: niente riepilogo, si chiude e basta.
            // _cts è ormai null, quindi OnFormClosing lascia passare la chiusura.
            if (_closeAfterCancel) {
                Close();
                return;
            }

            string msg;
            if (wasCancelled) {
                msg = $"Operazione interrotta.\nAnagrafiche elaborate: {regsProcessed}/{idregs.Count}\nFile aggiunti all'archivio: {filesCount}\nArchivio: {zipPath}";
            }
            else {
                msg = $"Download completato.\nAnagrafiche elaborate: {regsProcessed}\nFile aggiunti all'archivio: {filesCount}\nArchivio: {zipPath}";
            }
            if (errors.Length > 0) msg += "\n\nAvvisi/errori:\n" + errors;
            show(msg, wasCancelled ? "Interrotto" : "Esito");
        }

        private void btnInterrompi_Click(object sender, EventArgs e) {
            if (_cts != null && !_cts.IsCancellationRequested) {
                _cts.Cancel();
                btnInterrompi.Enabled = false;
                lblStatus.Text = "Annullamento in corso...";
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            Close();
        }

        // Chiude il form. Se c'è un'elaborazione in corso la annulla e rimanda la chiusura al termine del
        // task: chiudere subito lascerebbe il task di background a riferire l'avanzamento su controlli
        // già distrutti, e l'archivio ZIP resterebbe aperto a metà.
        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (_cts != null) {
                if (!_cts.IsCancellationRequested) _cts.Cancel();
                _closeAfterCancel = true;
                e.Cancel = true;
                btnInterrompi.Enabled = false;
                btnAnnulla.Enabled = false;
                lblStatus.Text = "Annullamento in corso...";
                return;
            }
            base.OnFormClosing(e);
        }

        // Abilita/disabilita i controlli dipendenti dallo stato di elaborazione
        // e mostra/nasconde la barra di avanzamento.
        private void SetUiBusy(bool busy, int total) {
            btnSelezionaExcel.Enabled = !busy;
            btnSelezionaZip.Enabled = !busy;
            gboxTabelle.Enabled = !busy;
            gboxStruttura.Enabled = !busy;
            btnEseguiDownload.Enabled = !busy;
            // btnAnnulla resta abilitato durante l'elaborazione: annulla il processo e chiude il form.
            btnAnnulla.Enabled = true;
            btnInterrompi.Visible = busy;
            btnInterrompi.Enabled = busy;
            progressBar1.Visible = busy;
            lblStatus.Visible = busy;
            if (busy) {
                progressBar1.Value = 0;
                progressBar1.Maximum = Math.Max(1, total);
                lblStatus.Text = "Avvio elaborazione...";
                Cursor = Cursors.AppStarting;
            }
            else {
                lblStatus.Text = "";
                Cursor = Cursors.Default;
            }
        }

        // Restituisce il numero di file aggiunti all'archivio per l'idreg, limitatamente alle tabelle in
        // sources. Eseguita su thread di background.
        // typeFirst determina la struttura delle cartelle:
        //   false -> anagrafica-first: {idreg}_{title} / {tipo allegato} / file  (predefinito)
        //   true  -> tipo-first:       {tipo allegato} / {idreg}_{title} / file
        // Solleva OperationCanceledException se il token viene cancellato durante un'iterazione.
        private int ProcessIdreg(int idreg, ZipArchive zip, List<RegistrySource> sources, bool typeFirst, StringBuilder errors, CancellationToken ct) {
            int count = 0;
            DataTable tReg = Conn.RUN_SELECT("registry", "idreg,title", null, QHS.CmpEq("idreg", idreg), null, false);
            if (tReg == null || tReg.Rows.Count == 0) {
                errors.AppendLine($"idreg {idreg} non trovato in tabella registry.");
                return 0;
            }
            string title = tReg.Rows[0]["title"]?.ToString() ?? "";
            string regEntry = AttachmentsManager.CleanFolderName($"{idreg}_{title}");
            // Solo in modalità anagrafica-first la cartella dell'anagrafica è di primo livello e la si
            // conserva anche senza allegati. In modalità tipo-first l'anagrafica è una sottocartella del
            // tipo di allegato (dipendente dalla riga), perciò compare solo dove ci sono file.
            if (!typeFirst) EnsureZipFolder(zip, regEntry);

            foreach (var src in sources) {
                if (ct.IsCancellationRequested) return count;
                DataTable t;
                try {
                    t = Conn.RUN_SELECT(src.TableName, "*", null, QHS.CmpEq("idreg", idreg), null, false);
                }
                catch (Exception ex) {
                    errors.AppendLine($"{src.TableName} idreg {idreg}: {ex.Message}");
                    continue;
                }
                if (t == null || t.Rows.Count == 0) continue;

                foreach (DataRow row in t.Rows) {
                    if (ct.IsCancellationRequested) return count;

                    string subEntry;
                    try {
                        string typePath = EntryPath(src.SubPath(row));
                        // anagrafica-first: {anagrafica}/{tipo}   tipo-first: {tipo}/{anagrafica}
                        subEntry = typeFirst
                            ? EntryPath(typePath, regEntry)
                            : EntryPath(regEntry, typePath);
                    }
                    catch (Exception ex) {
                        errors.AppendLine($"{src.TableName} idreg {idreg}: percorso non determinabile: {ex.Message}");
                        continue;
                    }

                    foreach (var blob in src.Blobs) {
                        byte[] bytes = ReadAttachmentBytes(row, blob.BlobColumn, blob.StorageColumn, src.TableName);
                        if (bytes == null) continue;
                        int offset;
                        string fname = ResolveFileName(row, src.IdColumn, blob.FileNameColumn, bytes, blob.FallbackPrefix, out offset);
                        try {
                            AddZipEntry(zip, EntryPath(subEntry, fname), bytes, offset);
                            count++;
                        }
                        catch (Exception ex) {
                            errors.AppendLine($"{src.TableName} #{row[src.IdColumn]} ({blob.BlobColumn}): {ex.Message}");
                        }
                    }
                }
            }
            return count;
        }

        private byte[] ReadAttachmentBytes(DataRow row, string blobColumn, string idFileStorageColumn, string tableName) {
            if (row.Table.Columns.Contains(blobColumn) && row[blobColumn] != DBNull.Value) {
                return (byte[])row[blobColumn];
            }
            if (row.Table.Columns.Contains(idFileStorageColumn) && row[idFileStorageColumn] != DBNull.Value) {
                try {
                    return HttpFileStorage.DownloadFile(Conn, tableName, row[idFileStorageColumn].ToString()).GetAwaiter().GetResult();
                }
                catch {
                    return null;
                }
            }
            return null;
        }

        // Determina il nome finale del file e l'offset dal quale iniziare a scrivere il BLOB sul disco.
        // Ordine di priorità:
        //   1) colonna filename esplicita (es. "filename", "durccertificationfilename") - convenzione moderna, payload = blob intero
        //   2) header null-terminated all'inizio del BLOB (convenzione legacy, usata da ccdedicato_* e dai record vecchi)
        //   3) fallback sintetico con estensione dedotta dai magic bytes
        // Restituisce il filename già sanitizzato (con prefisso id per evitare collisioni); payloadOffset == 0 nei casi 1) e 3),
        // == lunghezza-header+1 nel caso 2).
        private static string ResolveFileName(DataRow row, string idColumn, string fileNameColumn, byte[] bytes, string fallbackPrefix, out int payloadOffset) {
            payloadOffset = 0;
            string idVal = (row[idColumn] == DBNull.Value) ? "0" : row[idColumn].ToString();

            // 1) colonna filename
            if (!string.IsNullOrEmpty(fileNameColumn) && row.Table.Columns.Contains(fileNameColumn) && row[fileNameColumn] != DBNull.Value) {
                string s = row[fileNameColumn].ToString().Trim();
                if (s.Length > 0) return AttachmentsManager.SanitizeFilename($"{idVal}_{s}");
            }

            // 2) header legacy
            string legacy;
            int legacyOffset;
            if (TryGetLegacyHeader(bytes, out legacy, out legacyOffset)) {
                payloadOffset = legacyOffset;
                return AttachmentsManager.SanitizeFilename($"{idVal}_{legacy}");
            }

            // 3) fallback sintetico
            string ext = DetectExtensionFromMagic(bytes) ?? "bin";
            return AttachmentsManager.SanitizeFilename($"{fallbackPrefix}_{idVal}.{ext}");
        }

        // Tenta di leggere un filename null-terminated all'inizio del BLOB (convenzione legacy di Easy).
        // Accetta solo header con caratteri stampabili (>= 0x20 oppure '\t'), null entro 512 byte, e che assomiglino
        // a un nome file (estensione di 1-5 caratteri alfanumerici).
        private static bool TryGetLegacyHeader(byte[] bytes, out string filename, out int payloadOffset) {
            filename = null;
            payloadOffset = 0;
            if (bytes == null || bytes.Length < 4) return false;
            int maxScan = Math.Min(bytes.Length, 512);
            int nullPos = -1;
            for (int i = 0; i < maxScan; i++) {
                byte b = bytes[i];
                if (b == 0) { nullPos = i; break; }
                if (b < 0x20 && b != (byte)'\t') return false;
            }
            if (nullPos < 1) return false;
            string candidate;
            try {
                candidate = Encoding.Default.GetString(bytes, 0, nullPos).Trim();
            }
            catch { return false; }
            if (candidate.Length == 0 || candidate.Length > 255) return false;

            int lastDot = candidate.LastIndexOf('.');
            if (lastDot <= 0 || lastDot >= candidate.Length - 1) return false;
            string ext = candidate.Substring(lastDot + 1);
            if (ext.Length < 1 || ext.Length > 5) return false;
            foreach (char c in ext) {
                if (!char.IsLetterOrDigit(c)) return false;
            }

            filename = candidate;
            payloadOffset = nullPos + 1;
            return true;
        }

        // Riconosce alcuni formati comuni a partire dai magic bytes per dare un'estensione plausibile
        // ai file senza filename né header legacy.
        private static string DetectExtensionFromMagic(byte[] b) {
            if (b == null || b.Length < 4) return null;
            if (b[0] == 0x25 && b[1] == 0x50 && b[2] == 0x44 && b[3] == 0x46) return "pdf";        // %PDF
            if (b[0] == 0x50 && b[1] == 0x4B && (b[2] == 0x03 || b[2] == 0x05 || b[2] == 0x07)) return "zip"; // PK..  (anche docx/xlsx)
            if (b[0] == 0x89 && b[1] == 0x50 && b[2] == 0x4E && b[3] == 0x47) return "png";
            if (b[0] == 0xFF && b[1] == 0xD8 && b[2] == 0xFF) return "jpg";
            if (b[0] == 0xD0 && b[1] == 0xCF && b[2] == 0x11 && b[3] == 0xE0) return "doc";        // OLE (doc/xls vecchi)
            if (b.Length >= 6 && b[0] == 0x47 && b[1] == 0x49 && b[2] == 0x46) return "gif";
            if (b.Length >= 5 && b[0] == 0x7B && b[1] == 0x5C && b[2] == 0x72 && b[3] == 0x74 && b[4] == 0x66) return "rtf"; // {\rtf
            if (b.Length >= 5 && b[0] == 0x3C && b[1] == 0x3F && b[2] == 0x78 && b[3] == 0x6D && b[4] == 0x6C) return "xml"; // <?xml
            return null;
        }

        // Compone un percorso di entry per lo ZIP usando sempre '/' come separatore (richiesto dal formato ZIP),
        // scartando i segmenti vuoti. I singoli segmenti sono già sanitizzati da AttachmentsManager.CleanFolderName/SanitizeFilename.
        private static string EntryPath(params string[] parts) {
            var sb = new StringBuilder();
            foreach (var p in parts) {
                if (string.IsNullOrEmpty(p)) continue;
                if (sb.Length > 0) sb.Append('/');
                sb.Append(p);
            }
            return sb.ToString();
        }

        // Crea una entry "cartella" (nome che termina con '/') per conservare le cartelle vuote nello ZIP.
        private static void EnsureZipFolder(ZipArchive zip, string folderEntry) {
            if (string.IsNullOrEmpty(folderEntry)) return;
            zip.CreateEntry(folderEntry + "/");
        }

        // Aggiunge all'archivio una entry con il contenuto bytes[offset..].
        // Per file moderni offset=0, per file con header legacy offset salta l'header.
        private static void AddZipEntry(ZipArchive zip, string entryName, byte[] bytes, int offset) {
            if (bytes == null || offset >= bytes.Length) return;
            var entry = zip.CreateEntry(entryName, CompressionLevel.Optimal);
            using (var s = entry.Open()) {
                int n = bytes.Length - offset;
                if (n > 0) s.Write(bytes, offset, n);
            }
        }
    }
}
