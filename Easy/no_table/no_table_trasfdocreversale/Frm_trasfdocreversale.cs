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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.IO;
using System.IO.Compression;


namespace no_table_trasfdocreversale {
    public partial class Frm_trasfdocreversale : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;

        IFolderBrowserDialog folderDlg;
        ISaveFileDialog saveZipDlg;

        // Sorgente di cancellazione per l'operazione di download su archivio in corso. null quando inattiva.
        CancellationTokenSource _cts;

        struct ProgressInfo {
            public string Phase;
            public int Done;
            public int Total;   // 0 => barra indeterminata (marquee)
            public int Files;
        }

        public Frm_trasfdocreversale() {
            InitializeComponent();
            folderDlg = createFolderBrowserDialog(_folderDlg);
            saveZipDlg = createSaveFileDialog(_saveZipDlg);

            if (isBlazor())
			{
                txtFolder.Visible = false;
                btnSelezionaFolder.Visible = false;
                txtZipFile.Visible = false;
                btnSelezionaZip.Visible = false;
			}
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            txtEsercizioReversale.Text = Meta.GetSys("esercizio").ToString();
        }

        private void SelezionaCartella()
		{
            if (folderDlg.ShowDialog(this) == DialogResult.OK)
            {
                txtFolder.Text = folderDlg.SelectedPath;
            }
        }

        private void btnSelezionaFolder_Click(object sender, EventArgs e) {
            SelezionaCartella();
        }

        private void btnEseguidownload_Click(object sender, EventArgs e) {
            if (isBlazor())
            {
                SelezionaCartella();
            }
            object nstart = HelpForm.GetObjectFromString(typeof(int), txtNumInizio.Text, null);
            object nstop = HelpForm.GetObjectFromString(typeof(int), txtNumFine.Text, null);
            string pathdir = txtFolder.Text;
            object esercReversale = HelpForm.GetObjectFromString(typeof(int), txtEsercizioReversale.Text.ToString(), "x.y.year");
            string errors = "";

            if (pathdir.Equals("")) {
                show(this, "Selezionare una directory per il salvataggio degli allegati");
                return;
            }

            QueryHelper QHS = Conn.GetQueryHelper();
            string filterReversale = QHS.AppAnd(QHS.Between("npro", nstart, nstop), QHS.CmpEq("ypro", esercReversale));
            DataTable tProceeds = Conn.RUN_SELECT("proceeds", "*", null, filterReversale, null, false);
            string filterView = QHS.FieldIn("kpro", tProceeds.Select());

            int filesCount = 0;
            AttachmentsManager attachmentsManager;
            AttachmentsManager.DocType[] types = { AttachmentsManager.DocType.estimate,
                                                   AttachmentsManager.DocType.invoicesell
                                                 };

            AttachmentsManager attachmentsManagerS = new AttachmentsManager(Conn, pathdir);
            foreach (DataRow R in tProceeds.Select()) {
                //dstPath: rappresenta la cartella indicata + /mandato_ypay_npay/
                string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());
                if (!Directory.Exists(dstPath)) {
                    Directory.CreateDirectory(dstPath);
                }
                foreach (AttachmentsManager.DocType doctype in types) {
                    attachmentsManager = new AttachmentsManager(Conn, doctype, dstPath, null, QHS.CmpEq("kpro", R["kpro"]));
                    filesCount += attachmentsManager.saveAttachments();
                }
                string errmess = "";
                bool res = attachmentsManagerS.stampaReversale(Conn, dstPath, R, out errmess);
                if (!res) {
                    show(errmess);
                }
                else {
                    filesCount++;
                }
            }
            // Stampa FE associate agli incassi
            string queryFE = "SELECT distinct sdi_vendita.*, I.ipa_ven_cliente , EL.ypro, EL.npro "
                + " FROM income E "
                + " join incomelastview EL on E.idinc = EL.idinc "
                + " join incomeinvoice EI on EI.idinc = EL.idinc "
                + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                + " join sdi_vendita  on I.idsdi_vendita = sdi_vendita.idsdi_vendita "
                + " where sdi_vendita.xml is not null and " + filterView;
            DataTable tFattElettr = Meta.Conn.SQLRunner(queryFE);
            if ((tFattElettr!=null) && (tFattElettr.Rows.Count > 0)) {
                foreach (DataRow R in tFattElettr.Select()) {
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());
                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }
                    string errmess = "";
                    bool res = attachmentsManagerS.stampaFatturaFEvendita(Conn, dstPath, R, out errmess);
                    if (!res) {
                        show(errmess);
                    }
                    else {
                        filesCount++;
                    }
                    res = attachmentsManagerS.stampaXML_FEvendita(Conn, dstPath, R, out errmess);
                    if (!res) {
                        show(errmess);
                    }
                    else {
                        filesCount++;
                    }
                }
            }


            // Stampa Contratti Attivi associati alla reversale
            // La join sorgente emette una riga per ogni incasso collegato all'impegno: lo stesso
            // contratto attivo (idestimkind/yestim/nestim) si ripeterebbe e verrebbe ristampato una
            // volta per incasso. Riduciamo a una sola riga per contratto mantenendo invariate le
            // colonne attese a valle (un solo rappresentante per chiave, scelto in modo deterministico).
            string queryCalcCA =
                " select ayear, printkind, idestimkind, estimkind, nestim_start, nestim_stop, " +
                "        idman, idreg, ypro, npro, registry, idsor01, idsor02, idsor03, idsor04, idsor05 " +
                " from ( " +
                "   select E.yestim as ayear, 'I' as printkind, E.idestimkind, E.estimkind,  " +
                "   E.nestim as nestim_start,  E.nestim as nestim_stop, " +
                "   null as idman, IL.idreg,   IL.ypro, IL.npro, IL.registry,  " +
                "   null as idsor01,null as idsor02, null as idsor03,null as idsor04 ,null as idsor05, " +
                "   row_number() over (partition by E.idestimkind, E.yestim, E.nestim order by IL.idreg) as rn "
                    + " from income I "
                    + " join incomelastview IL on I.idinc = IL.idinc "
                    + " join incomelink ILK on ILK.idchild = IL.idinc "
                    + " join incomeestimate IM on IM.idinc = ILK.idparent "
                    + " join estimateview E on E.idestimkind = IM.idestimkind AND E.yestim = IM.yestim AND E.nestim = IM.nestim "
                    + " where " + filterView
                + " ) q where q.rn = 1";
            DataTable tContrattiA = Conn.SQLRunner(queryCalcCA);
            if ((tContrattiA != null) && (tContrattiA.Rows.Count > 0)) {

                //var errors = new List<Exception>();

                foreach (DataRow R in tContrattiA.Select()) {
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());

                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }

                    string errmess = "";
                    bool res = attachmentsManagerS.stampaContrattoAttivo(Conn, dstPath, R, out errmess);
                    if (!res) {
                        show(errmess);
                    }
                    else {
                        filesCount++;
                    }
                }
            }
            // Scarica i file allegati nella reversale
            string queryProceeds = "WITH proceeds_file AS ( "
                    + " select p.ypro, p.npro, pa.* "
                    + " from proceedsattachment pa "
                    + " join proceeds p on pa.kpro = p.kpro) "
                + " select * from proceeds_file "
                + " where " + filterView;

            DataTable tProceedsAttachment = Meta.Conn.SQLRunner(queryProceeds);
            if ((tProceedsAttachment != null) && (tProceedsAttachment.Rows.Count > 0)) {
                foreach (DataRow R in tProceedsAttachment.Select()) {
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());

                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }

                    byte[] ByteArray = null;

                    if (R["attachment"] == DBNull.Value) {
                        if (R["idfilestorage"] != DBNull.Value) {
                            // Leggo da MongoDb
                            ByteArray = HttpFileStorage.DownloadFile(Conn, "proceedsattachment", R["idfilestorage"].ToString()).GetAwaiter().GetResult();
                            if (ByteArray == null) {
                                show("Servizio Download degli Allegati non disponibile");
                                return;
                            }
                        }
                    }
                    else
                        ByteArray = (byte[])R["attachment"];

                    int offset = 0;
                    string fname = AttachmentsManager.SafeFileNameObj(R["filename"]);
                    fname = "Reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString() + "_all_" + R["idattachment"].ToString() + "_" + fname;
                    string sw = Path.Combine(dstPath, fname);
                    try {
                        ScriviFile(sw, ByteArray, offset);
                    }
                    catch (Exception E) {
                        QueryCreator.ShowException(E);
                    }
                }
            }

            show("Downlaod eseguito");
        }

        public static void ScriviFile(string sw, byte[] documento, int offset) {
            // Legge il documento memorizzato nel DB e lo scrive nel file temp.
            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) return;
            try {
                FS.Write(documento, offset, n);//<<<<<<<<<
                FS.Flush();
                FS.Close();

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(sw, false);
            }
            catch { }
        }

        // =====================================================================================
        //  COPIA DEL DOWNLOAD CON CREAZIONE DI UN UNICO ARCHIVIO ZIP + BARRA DI AVANZAMENTO
        //  Replica btnEseguidownload_Click ma scrive i documenti in una cartella temporanea,
        //  li comprime in un singolo archivio e ripulisce la cartella temporanea.
        // =====================================================================================
        private void SelezionaArchivio() {
            if (saveZipDlg.ShowDialog(this) == DialogResult.OK) {
                txtZipFile.Text = saveZipDlg.FileName;
            }
        }

        private void btnSelezionaZip_Click(object sender, EventArgs e) {
            SelezionaArchivio();
        }

        private async void btnEseguidownloadZip_Click(object sender, EventArgs e) {
            if (isBlazor() && string.IsNullOrEmpty(txtZipFile.Text)) {
                SelezionaArchivio();
            }
            object nstart = HelpForm.GetObjectFromString(typeof(int), txtNumInizio.Text, null);
            object nstop = HelpForm.GetObjectFromString(typeof(int), txtNumFine.Text, null);
            object esercReversale = HelpForm.GetObjectFromString(typeof(int), txtEsercizioReversale.Text.ToString(), "x.y.year");

            string zipPath = txtZipFile.Text;
            if (string.IsNullOrEmpty(zipPath)) {
                show(this, "Selezionare l'archivio ZIP di destinazione");
                return;
            }
            string zipDir = Path.GetDirectoryName(zipPath);
            if (string.IsNullOrEmpty(zipDir) || !Directory.Exists(zipDir)) {
                show(this, "La cartella che dovrebbe contenere l'archivio ZIP non esiste.");
                return;
            }

            // Costruzione del filtro sul thread UI.
            QueryHelper QHS = Conn.GetQueryHelper();
            string filterReversale = QHS.AppAnd(QHS.Between("npro", nstart, nstop), QHS.CmpEq("ypro", esercReversale));
            DataTable tProceeds = Conn.RUN_SELECT("proceeds", "*", null, filterReversale, null, false);
            string filterView = QHS.FieldIn("kpro", tProceeds.Select());

            var errors = new StringBuilder();
            _cts = new CancellationTokenSource();
            CancellationToken ct = _cts.Token;
            SetUiBusy(true);

            IProgress<ProgressInfo> progress = new Progress<ProgressInfo>(UpdateProgress);

            int filesCount = 0;
            bool wasCancelled = false;

            try {
                filesCount = await Task.Run(() => GenerateZip(zipPath, tProceeds, filterView, progress, errors, ct));
                wasCancelled = ct.IsCancellationRequested;
            }
            catch (OperationCanceledException) {
                wasCancelled = true;
            }
            catch (Exception ex) {
                errors.AppendLine("Errore: " + ex.Message);
            }
            finally {
                SetUiBusy(false);
                if (_cts != null) { _cts.Dispose(); _cts = null; }
            }

            string msg;
            if (wasCancelled) {
                msg = $"Operazione interrotta.\nFile aggiunti all'archivio: {filesCount}\nArchivio: {zipPath}";
            }
            else {
                msg = $"Download completato.\nFile aggiunti all'archivio: {filesCount}\nArchivio: {zipPath}";
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

        // Abilita/disabilita i controlli dipendenti dallo stato di elaborazione (download su archivio)
        // e mostra/nasconde la barra di avanzamento.
        private void SetUiBusy(bool busy) {
            btnSelezionaFolder.Enabled = !busy;
            btnSelezionaZip.Enabled = !busy;
            btnEseguidownload.Enabled = !busy;
            btnEseguidownloadZip.Enabled = !busy;
            btnOK.Enabled = !busy;
            btnAnnulla.Enabled = !busy;
            btnInterrompi.Visible = busy;
            btnInterrompi.Enabled = busy;
            progressBar1.Visible = busy;
            lblStatus.Visible = busy;
            if (busy) {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.Value = 0;
                lblStatus.Text = "Avvio elaborazione...";
                Cursor = Cursors.AppStarting;
            }
            else {
                progressBar1.Style = ProgressBarStyle.Continuous;
                lblStatus.Text = "";
                Cursor = Cursors.Default;
            }
        }

        // Aggiorna barra e label di stato sul thread UI (invocata via IProgress).
        private void UpdateProgress(ProgressInfo info) {
            if (info.Total > 0) {
                if (progressBar1.Style != ProgressBarStyle.Continuous) progressBar1.Style = ProgressBarStyle.Continuous;
                if (progressBar1.Maximum != info.Total) progressBar1.Maximum = Math.Max(1, info.Total);
                progressBar1.Value = Math.Min(info.Done, progressBar1.Maximum);
            }
            else {
                if (progressBar1.Style != ProgressBarStyle.Marquee) progressBar1.Style = ProgressBarStyle.Marquee;
            }
            string head = info.Phase ?? "";
            if (info.Total > 0) head += $" {info.Done}/{info.Total}";
            lblStatus.Text = $"{head} - file: {info.Files}";
        }

        // Genera tutti i documenti in una cartella temporanea, la comprime in un unico archivio ZIP
        // e ripulisce la cartella temporanea. Eseguita su thread di background.
        private int GenerateZip(string zipPath, DataTable tProceeds, string filterView, IProgress<ProgressInfo> progress, StringBuilder errors, CancellationToken ct) {
            string tempRoot = Path.Combine(Path.GetTempPath(), "easy_reversale_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempRoot);
            int files = 0;
            try {
                files = GenerateInto(tempRoot, tProceeds, filterView, progress, errors, ct);
                // Anche se l'operazione è stata interrotta, comprimiamo ciò che è stato prodotto finora.
                CompressFolder(tempRoot, zipPath, progress, files);
            }
            finally {
                try { if (Directory.Exists(tempRoot)) Directory.Delete(tempRoot, true); }
                catch { /* best effort: eventuali file ancora aperti restano nella cartella temporanea */ }
            }
            return files;
        }

        // Comprime il contenuto di root in un singolo archivio ZIP, riportando l'avanzamento per file.
        private void CompressFolder(string root, string zipPath, IProgress<ProgressInfo> progress, int filesProduced) {
            string[] allFiles = Directory.GetFiles(root, "*", SearchOption.AllDirectories);
            using (var fs = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
            using (var zip = new ZipArchive(fs, ZipArchiveMode.Create)) {
                for (int i = 0; i < allFiles.Length; i++) {
                    string rel = allFiles[i].Substring(root.Length + 1).Replace('\\', '/');
                    var entry = zip.CreateEntry(rel, CompressionLevel.Optimal);
                    using (var es = entry.Open())
                    using (var ins = File.OpenRead(allFiles[i])) {
                        ins.CopyTo(es);
                    }
                    progress.Report(new ProgressInfo { Phase = "Compressione archivio", Done = i + 1, Total = allFiles.Length, Files = filesProduced });
                }
            }
        }

        // Copia di btnEseguidownload_Click adattata: genera i documenti della reversale dentro pathdir
        // (cartella temporanea) riusando gli stessi helper. Restituisce il numero di file prodotti.
        // Eseguita su thread di background: gli avvisi sono accumulati in errors invece di usare show().
        private int GenerateInto(string pathdir, DataTable tProceeds, string filterView, IProgress<ProgressInfo> progress, StringBuilder errors, CancellationToken ct) {
            int filesCount = 0;
            QueryHelper QHS = Conn.GetQueryHelper();

            AttachmentsManager attachmentsManager;
            AttachmentsManager.DocType[] types = { AttachmentsManager.DocType.estimate,
                                                   AttachmentsManager.DocType.invoicesell
                                                 };

            AttachmentsManager attachmentsManagerS = new AttachmentsManager(Conn, pathdir);
            DataRow[] proceeds = tProceeds.Select();
            for (int i = 0; i < proceeds.Length; i++) {
                ct.ThrowIfCancellationRequested();
                DataRow R = proceeds[i];

                string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());
                if (!Directory.Exists(dstPath)) {
                    Directory.CreateDirectory(dstPath);
                }
                foreach (AttachmentsManager.DocType doctype in types) {
                    ct.ThrowIfCancellationRequested();
                    attachmentsManager = new AttachmentsManager(Conn, doctype, dstPath, null, QHS.CmpEq("kpro", R["kpro"]));
                    filesCount += attachmentsManager.saveAttachments();
                }
                string errmess = "";
                bool res = attachmentsManagerS.stampaReversale(Conn, dstPath, R, out errmess);
                if (!res) {
                    errors.AppendLine(errmess);
                }
                else {
                    filesCount++;
                }

                progress.Report(new ProgressInfo { Phase = "Reversale " + R["ypro"] + "_" + R["npro"], Done = i + 1, Total = proceeds.Length, Files = filesCount });
            }

            // Stampa FE associate agli incassi
            progress.Report(new ProgressInfo { Phase = "Fatture elettroniche", Total = 0, Files = filesCount });
            string queryFE = "SELECT distinct sdi_vendita.*, I.ipa_ven_cliente , EL.ypro, EL.npro "
                + " FROM income E "
                + " join incomelastview EL on E.idinc = EL.idinc "
                + " join incomeinvoice EI on EI.idinc = EL.idinc "
                + " join invoice I on I.idinvkind = EI.idinvkind AND I.yinv = EI.yinv AND I.ninv = EI.ninv "
                + " join sdi_vendita  on I.idsdi_vendita = sdi_vendita.idsdi_vendita "
                + " where sdi_vendita.xml is not null and " + filterView;
            DataTable tFattElettr = Meta.Conn.SQLRunner(queryFE);
            if ((tFattElettr != null) && (tFattElettr.Rows.Count > 0)) {
                foreach (DataRow R in tFattElettr.Select()) {
                    ct.ThrowIfCancellationRequested();
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());
                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }
                    string errmess = "";
                    bool res = attachmentsManagerS.stampaFatturaFEvendita(Conn, dstPath, R, out errmess);
                    if (!res) {
                        errors.AppendLine(errmess);
                    }
                    else {
                        filesCount++;
                    }
                    res = attachmentsManagerS.stampaXML_FEvendita(Conn, dstPath, R, out errmess);
                    if (!res) {
                        errors.AppendLine(errmess);
                    }
                    else {
                        filesCount++;
                    }
                }
            }

            // Stampa Contratti Attivi associati alla reversale
            // La join sorgente emette una riga per ogni incasso collegato all'impegno: lo stesso
            // contratto attivo (idestimkind/yestim/nestim) si ripeterebbe e verrebbe ristampato una
            // volta per incasso. Riduciamo a una sola riga per contratto mantenendo invariate le
            // colonne attese a valle (un solo rappresentante per chiave, scelto in modo deterministico).
            progress.Report(new ProgressInfo { Phase = "Contratti attivi", Total = 0, Files = filesCount });
            string queryCalcCA =
                " select ayear, printkind, idestimkind, estimkind, nestim_start, nestim_stop, " +
                "        idman, idreg, ypro, npro, registry, idsor01, idsor02, idsor03, idsor04, idsor05 " +
                " from ( " +
                "   select E.yestim as ayear, 'I' as printkind, E.idestimkind, E.estimkind,  " +
                "   E.nestim as nestim_start,  E.nestim as nestim_stop, " +
                "   null as idman, IL.idreg,   IL.ypro, IL.npro, IL.registry,  " +
                "   null as idsor01,null as idsor02, null as idsor03,null as idsor04 ,null as idsor05, " +
                "   row_number() over (partition by E.idestimkind, E.yestim, E.nestim order by IL.idreg) as rn "
                    + " from income I "
                    + " join incomelastview IL on I.idinc = IL.idinc "
                    + " join incomelink ILK on ILK.idchild = IL.idinc "
                    + " join incomeestimate IM on IM.idinc = ILK.idparent "
                    + " join estimateview E on E.idestimkind = IM.idestimkind AND E.yestim = IM.yestim AND E.nestim = IM.nestim "
                    + " where " + filterView
                + " ) q where q.rn = 1";
            DataTable tContrattiA = Conn.SQLRunner(queryCalcCA);
            if ((tContrattiA != null) && (tContrattiA.Rows.Count > 0)) {
                foreach (DataRow R in tContrattiA.Select()) {
                    ct.ThrowIfCancellationRequested();
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());

                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }

                    string errmess = "";
                    bool res = attachmentsManagerS.stampaContrattoAttivo(Conn, dstPath, R, out errmess);
                    if (!res) {
                        errors.AppendLine(errmess);
                    }
                    else {
                        filesCount++;
                    }
                }
            }
            // Scarica i file allegati nella reversale
            progress.Report(new ProgressInfo { Phase = "Allegati reversale", Total = 0, Files = filesCount });
            string queryProceeds = "WITH proceeds_file AS ( "
                    + " select p.ypro, p.npro, pa.* "
                    + " from proceedsattachment pa "
                    + " join proceeds p on pa.kpro = p.kpro) "
                + " select * from proceeds_file "
                + " where " + filterView;

            DataTable tProceedsAttachment = Meta.Conn.SQLRunner(queryProceeds);
            if ((tProceedsAttachment != null) && (tProceedsAttachment.Rows.Count > 0)) {
                foreach (DataRow R in tProceedsAttachment.Select()) {
                    ct.ThrowIfCancellationRequested();
                    string dstPath = Path.Combine(pathdir, "reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString());

                    if (!Directory.Exists(dstPath)) {
                        Directory.CreateDirectory(dstPath);
                    }

                    byte[] ByteArray = null;

                    if (R["attachment"] == DBNull.Value) {
                        if (R["idfilestorage"] != DBNull.Value) {
                            // Leggo da MongoDb
                            ByteArray = HttpFileStorage.DownloadFile(Conn, "proceedsattachment", R["idfilestorage"].ToString()).GetAwaiter().GetResult();
                            if (ByteArray == null) {
                                errors.AppendLine("Servizio Download degli Allegati non disponibile (proceedsattachment idattachment " + R["idattachment"] + ")");
                                continue;
                            }
                        }
                    }
                    else
                        ByteArray = (byte[])R["attachment"];

                    int offset = 0;
                    string fname = AttachmentsManager.SafeFileNameObj(R["filename"]) ;
                    fname = "Reversale_" + R["ypro"].ToString() + "_" + R["npro"].ToString() + "_all_" + R["idattachment"].ToString() + "_" + fname;
                    string sw = Path.Combine(dstPath, fname);
                    try {
                        ScriviFileArchivio(sw, ByteArray, offset);
                    }
                    catch (Exception E) {
                        errors.AppendLine(E.Message);
                    }
                }
            }

            return filesCount;
        }

        // Variante di ScriviFile per la modalità archivio: scrive il blob nella cartella temporanea
        // senza aprire il file con il process runner.
        private static void ScriviFileArchivio(string sw, byte[] documento, int offset) {
            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);

            int n = documento.Length - offset;
            if (n == 0) { FS.Close(); return; }
            try {
                FS.Write(documento, offset, n);
                FS.Flush();
                FS.Close();
            }
            catch { }
        }
    }
}
