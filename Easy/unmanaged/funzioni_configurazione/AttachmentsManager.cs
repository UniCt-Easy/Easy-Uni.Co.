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
using metadatalibrary;
using metaeasylibrary;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Xml;
using System.Xml.Xsl;
using System.Threading;
using ReportGenClient;
using HubConnector;
using System.Linq;
using System.Text.RegularExpressions;

namespace funzioni_configurazione {
    public class AttachmentsManager {

        //enum dei tipi di documento
        public enum DocType { 
            estimate, 
            mandate, 
            invoicebuy, 
            invoicesell, 
            itineration,
            itinerationrefund,
        }

        //dizionario che associa al tipo di documento la chiave della tabella degli attachments
        public static readonly Dictionary<DocType, string[]> ViewKeysLookupDict = new Dictionary<DocType, string[]> {
            {DocType.estimate, new [] { "idestimkind", "yestim", "nestim", "idattachment" } },
            {DocType.mandate, new [] { "idmankind", "yman", "nman", "idattachment" } },
            {DocType.invoicebuy, new [] { "idinvkind", "yinv", "ninv", "idattachment" } },
            {DocType.invoicesell, new [] { "idinvkind", "yinv", "ninv", "idattachment" } },
            {DocType.itineration, new [] { "iditineration", "idattachment" } },
            {DocType.itinerationrefund, new [] { "iditineration", "nrefund", "idattachment" } } 
        };

        //dizionario che associa al tipo di documento il prefisso da usare nei nomi dei file
        private static readonly Dictionary<DocType, string> FilePrefixLookupDict = new Dictionary<DocType, string> {
            {DocType.estimate, "ca_all"},
            {DocType.mandate, "cp_all"},
            {DocType.invoicebuy, "fatt_all"},
            {DocType.invoicesell, "fatt_all"},
            {DocType.itineration, "miss_all"},
            {DocType.itinerationrefund, "miss_spesa_all"}
        };

        //tipo di documento gestito dal manager
        private DocType docType;

        //tabella dei contenuti dei file allegati
        private DataTable attachmentsTable;

        public DataAccess Conn { get; }
        private DataTable filteredView;

        private string viewName;
        private string viewFilter;

        private string dstDir;
        /// <summary>
        /// Directory da cui leggere i fogli di stile.
        /// </summary>
        private readonly DirectoryInfo xslDir;
        /// <summary>
        /// Indica se il contesto di esecuzione dell'oggetto ha a disposizione l'interfaccia utente.
        /// </summary>
        private readonly bool _useUI = true;

        /// <summary>
        /// Caratteri non utilizzabili sui nomi dei file.
        /// </summary>
        private static readonly HashSet<char> InvalidCharSet = new HashSet<char>(Path.GetInvalidFileNameChars()) {

            // Aggiungiamo caratteri extra potenzialmente problematici e i separatori di path:
            '%', '#', '@', '$', '`', '=', Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar
        };

        /// <summary>
        /// Nomi di device DOS riservati: CreateFile apre il device, non un file, qualunque sia l'estensione.
        /// Confronto case-insensitive sullo stem (parte prima del primo '.'), spazi finali ignorati.
        /// </summary>
        private static readonly HashSet<string> ReservedDeviceNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "CON", "PRN", "AUX", "NUL",
            "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
            "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9",
            "CONIN$", "CONOUT$"
        };

        /// <summary>Lunghezza massima di un componente di percorso su NTFS / la gran parte dei file system.</summary>
        private const int MaxFileNameComponentLength = 255;

        /// <summary>
        /// Sostituisce caratteri illegali per l'OS con underscore in un nome file, rimuove i whitespace in testa
        /// e coda, applica le ulteriori regole di validità che Windows impone (punti/spazi finali eliminati, nomi
        /// di device riservati come CON -> _CON, limite di 255 caratteri con estensione preservata) e assegna un
        /// nome casuale nel caso non sia specificato o non resti nulla di utilizzabile.
        /// Deterministica per input non vuoto e idempotente (ri-sanitizzare un nome già pulito lo lascia invariato).
        /// </summary>
        /// <param name="name">Nome originario del file.</param>
        /// <returns>Nuovo nome.</returns>
        public static string SanitizeFilename(string name) {

            // nome casuale con estensione .dat
            if (string.IsNullOrWhiteSpace(name))
                return $"{Guid.NewGuid()}.dat";

            // trim dei whitespace
            name = name.Trim();

            // sostituzione caratteri illegali
            var result = new char[name.Length];

            for (int i = 0; i < name.Length; i++)
                result[i] = InvalidCharSet.Contains(name[i]) ? '_' : name[i];

            // regole di validità OS: punti/spazi finali, nomi riservati, limite 255 caratteri
            string cleaned = ApplyOsNameRules(new string(result));

            // se non resta nulla (input tipo ".", "..", "   ...") ripieghiamo su un nome casuale
            if (cleaned.Length == 0)
                return $"{Guid.NewGuid()}.dat";

            return cleaned;
        }

        /// <summary>
        /// Applica le regole di validità che Windows impone oltre alla sola sostituzione dei caratteri illegali:
        /// rimuove punti/spazi finali (Windows li elimina silenziosamente), antepone '_' ai nomi di device
        /// riservati (CON -> _CON) e tronca a 255 caratteri preservando l'estensione. Idempotente.
        /// Restituisce "" se non resta nulla di utilizzabile (il chiamante decide il ripiego).
        /// </summary>
        private static string ApplyOsNameRules(string cleaned) {

            // Punti/spazi finali: Windows li elimina, quindi "a." e "a " verrebbero rifiutati/rinominati.
            cleaned = cleaned.TrimEnd('.', ' ');
            if (cleaned.Length == 0)
                return "";

            // Nome di device riservato (CON, COM1, ... anche con estensione): anteponiamo '_' cosicché
            // lo stem non coincida più. "_CON" è un nome file del tutto ordinario.
            if (IsReservedDeviceName(cleaned))
                cleaned = "_" + cleaned;

            // Limite di lunghezza del componente: troncamento preservando l'estensione dove c'è spazio.
            if (cleaned.Length > MaxFileNameComponentLength)
                cleaned = TruncatePreservingExtension(cleaned, MaxFileNameComponentLength);

            // Il troncamento può esporre un nuovo punto/spazio finale.
            return cleaned.TrimEnd('.', ' ');
        }

        /// <summary>
        /// True se lo stem (parte prima del PRIMO '.', spazi finali ignorati) è un nome di device riservato DOS.
        /// "CON" e "CON.txt" sono entrambi riservati; uno stem vuoto (es. ".pdf") non lo è.
        /// </summary>
        private static bool IsReservedDeviceName(string value) {
            int dot = value.IndexOf('.');
            string stem = dot >= 0 ? value.Substring(0, dot) : value;
            stem = stem.TrimEnd(' ');
            if (stem.Length == 0)
                return false;
            return ReservedDeviceNames.Contains(stem);
        }

        /// <summary>
        /// Accorcia un nome a <paramref name="max"/> caratteri preservando l'estensione (ULTIMO '.') se c'è spazio;
        /// altrimenti taglia netto ai primi <paramref name="max"/> caratteri.
        /// </summary>
        private static string TruncatePreservingExtension(string s, int max) {
            int dot = s.LastIndexOf('.');
            // Un'estensione vera (punto né primo né ultimo carattere) viene mantenuta finché lo stem ha spazio.
            if (dot > 0 && dot < s.Length - 1) {
                string ext = s.Substring(dot);
                if (ext.Length < max) {
                    string stem = s.Substring(0, dot);
                    int stemLen = max - ext.Length;
                    if (stem.Length > stemLen)
                        stem = stem.Substring(0, stemLen);
                    return stem + ext;
                }
            }
            return s.Substring(0, max);
        }


        /// <summary>
        /// Sanitizza un nome da usare come cartella: rimuove i caratteri illegali (come <see cref="SanitizeFilename"/>)
        /// e in più elimina punti e spazi finali (non ammessi a fine nome su Windows),
        /// restituendo "_" se il risultato è vuoto.
        /// </summary>
        /// <param name="name">Nome della cartella.</param>
        /// <returns>Nuovo nome, mai vuoto.</returns>
        public static string CleanFolderName(string name) {
            string sanitized = SanitizeFilename(name).TrimEnd('.', ' ');
            return sanitized.Length == 0 ? "_" : sanitized;
        }

        //tablename lo recuperiamo da viewname(dal nome che assegnamo alla vista)
        public AttachmentsManager(DataAccess _conn, DocType _docType, string _dstDir, string _viewName = null, string _viewFilter = null, string _xslDir = null, bool useUI = true) {

            Conn = _conn;
            docType = _docType;

            dstDir = _dstDir;
            xslDir = Directory.Exists(_xslDir) ? new DirectoryInfo(_xslDir) : new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            viewName = _viewName ?? _docType.ToString() + "attachmentview";
            viewFilter = _viewFilter;

            attachmentsTable = new DataTable();

            _useUI = useUI;

            fillFilteredView();
            fillAttachmentsTable();
        }
        public AttachmentsManager(DataAccess _conn, string _dstDir, string _xslDir = null) {

            Conn = _conn;

            dstDir = _dstDir;
            xslDir = Directory.Exists(_xslDir) ? new DirectoryInfo(_xslDir) : new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            attachmentsTable = new DataTable();
        }

        private void fillFilteredView() {
            filteredView = Conn.RUN_SELECT(viewName, "*", null, viewFilter, null, false);
        }

        private void fillAttachmentsTable() {
            string attachmentsTablename;

            switch (docType) {
                case DocType.invoicebuy:
                case DocType.invoicesell:
                    attachmentsTablename = "invoiceattachment";
                    break;
                default:
                    attachmentsTablename = docType.ToString() + "attachment";
                    break;
            }

            QueryHelper qHelper = Conn.GetQueryHelper();

            string[] keyFields = ViewKeysLookupDict[docType];
            string[] andParameters = new string[keyFields.Length];


            foreach (DataRow filteredViewRow in filteredView.Select()) {

                //creazione parametri da mettere in AND
                keyFields._forEach((fieldName, paramsIndex) => { andParameters[paramsIndex] = qHelper.CmpEq(fieldName, filteredViewRow[fieldName]); });

                //creazione filtro per interrogare la tabella degli attachment su db
                string attachmentsFilter = qHelper.AppAnd(andParameters);

                DataTable temp = Conn.RUN_SELECT(attachmentsTablename, "*", null, attachmentsFilter, null, false);

                // Per ogni riga del datatabel leggo da MongoDB l'attachment della tabella attachmentsTablename
                foreach (DataRow row in temp.Rows)
                {
                    if (row["attachment"] == DBNull.Value)
                    {
                        if (row["idfilestorage"] != null)
                        {
                            // Leggo da MongoDb
                            byte[] byteArray = HttpFileStorage.DownloadFile(Conn, attachmentsTablename, row["idfilestorage"].ToString()).GetAwaiter().GetResult();
                            if (byteArray == null)
                            {
                                if (!_useUI) {

                                    throw new Exception($"Errore non gestito su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(byteArray)}' nullo per idfilestorage '{row["idfilestorage"]}' e bucket '{attachmentsTablename}'.");
                                }

                                MetaFactory.factory.getSingleton<IMessageShower>()?.Show("Servizio Download degli Allegati non disponibile");
                                return;
                            }
                            row["attachment"] = byteArray;
                        }
                    }
                }

                attachmentsTable.Merge(temp);
            }
        }

        public static string SafeFileNameObj(object value) {
            string fileName = null;

            if (value != null && value != DBNull.Value)
                // trim dei whitespace
                fileName = value.ToString().Trim();

            if (string.IsNullOrWhiteSpace(fileName)) {
                fileName = "allegato_" + Guid.NewGuid().ToString("N").Substring(0, 8) + ".dat";
            }
            foreach (char c in Path.GetInvalidFileNameChars())
                fileName = fileName.Replace(c, '_');
            // i nomi file potrebbero contenere caratteri separatori di cartella
            fileName = fileName.Replace('/', '_').Replace('\\', '_');
            return fileName;
        }

        private void saveFile(string fileName, byte[] fileContents) {
          
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            if (fileContents.Length == 0) return;
            try {
                fileStream.Write(fileContents, 0, fileContents.Length);
                fileStream.Flush();
                fileStream.Close();

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(fileName, false);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static DataTable createStampaReversaleTable() {
            var myPrimaryTable = new DataTable("export_payment");
            //Create a dummy primary key
            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;
            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("startnpro", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("stopnpro", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printdate", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("oneprint", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idtreasurer", typeof(int)));

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);
            return myPrimaryTable;
        }
        public static DataTable createStampaMandatoTable() {
            var myPrimaryTable = new DataTable("export_payment");
            //Create a dummy primary key
            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;
            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("startnpay", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("stopnpay", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printdate", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("oneprint", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idtreasurer", typeof(int)));
            column = new DataColumn("nota", typeof(string));
            column.AllowDBNull = true;
            myPrimaryTable.Columns.Add(column);

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);
            return myPrimaryTable;
        }
        public static DataTable createStampaCedoliniTable() {
            var myPrimaryTable = new DataTable("export_cedolino");
            //Create a dummy primary key
            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;
            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idreg", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("start", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("stop", typeof(DateTime)));
            myPrimaryTable.Columns.Add(new DataColumn("mode", typeof(string)));

            column = new DataColumn("nota", typeof(string));
            column.AllowDBNull = true;
            myPrimaryTable.Columns.Add(column);

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);
            return myPrimaryTable;
        }

        //Table parametri ContrattoAttivo
        public static DataTable createStampaContrattiAttiviTable() {
            var myPrimaryTable = new DataTable("export_contratto_attivo");

            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;

            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("idestimkind", typeof(string)));

            myPrimaryTable.Columns.Add(new DataColumn("nestim_start", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("nestim_stop", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("idman", typeof(int)));

            column = new DataColumn("competencydate", typeof(DateTime));
            column.AllowDBNull = true;
            myPrimaryTable.Columns.Add(column);

            myPrimaryTable.Columns.Add(new DataColumn("filtercompetency", typeof(string)));

            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));

            myPrimaryTable.Columns.Add(new DataColumn("idsor01", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor02", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor03", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor04", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor05", typeof(int)));

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);

            return myPrimaryTable;
        }
        //Table parametri ContrattoPassivo
        public static DataTable createStampaContrattiPassiviTable() {
            var myPrimaryTable = new DataTable("export_contratto_passivo");

            var dcpk = new DataColumn("DummyPrimaryKeyField", typeof(int)) { DefaultValue = 1 };
            myPrimaryTable.Columns.Add(dcpk);
            myPrimaryTable.PrimaryKey = new[] { dcpk };

            DataColumn column;

            myPrimaryTable.Columns.Add(new DataColumn("reportname", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("ayear", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("printkind", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("mandatekind", typeof(string)));

            myPrimaryTable.Columns.Add(new DataColumn("startnman", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("stopnman", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idman", typeof(int)));

            myPrimaryTable.Columns.Add(new DataColumn("official", typeof(string)));
            myPrimaryTable.Columns.Add(new DataColumn("includevariation", typeof(string)));

            column = new DataColumn("variationdate", typeof(DateTime));
            column.AllowDBNull = true;
            myPrimaryTable.Columns.Add(column);

            myPrimaryTable.Columns.Add(new DataColumn("labelinenglish", typeof(string)));

            myPrimaryTable.Columns.Add(new DataColumn("idsor01", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor02", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor03", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor04", typeof(int)));
            myPrimaryTable.Columns.Add(new DataColumn("idsor05", typeof(int)));

            var r = myPrimaryTable.NewRow();
            myPrimaryTable.Rows.Add(r);

            return myPrimaryTable;
        }
        public static bool exportToPdf(ReportDocument rd, string fileName, string relativePath, out string error) {
            error = "";

            // Costruisce i percorsi da provare, in ordine di preferenza. Il percorso richiesto puo' non
            // essere scrivibile (percorso troppo lungo, cartella mancante, permessi assenti...), quindi non
            // lo verifichiamo in anticipo: proviamo a esportare e, in caso di errore, passiamo al candidato successivo.
            //   1) il percorso richiesto
            //   2) stessa cartella, ma con un nome accorciato (comunque riconoscibile)
            //   3) un file temporaneo di sistema
            var candidates = new System.Collections.Generic.List<string>();
            candidates.Add(relativePath + fileName);

            try {
                string directory = Path.GetDirectoryName(Path.GetFullPath(relativePath + fileName));
                if (!string.IsNullOrEmpty(directory)) {
                    string ext = Path.GetExtension(fileName);
                    if (string.IsNullOrEmpty(ext)) ext = ".pdf";
                    string baseName = Path.GetFileNameWithoutExtension(fileName) ?? "";
                    if (baseName.Length > 20) baseName = baseName.Substring(0, 20);
                    string shortName = baseName + "_" + Guid.NewGuid().ToString("N").Substring(0, 8) + ext;
                    candidates.Add(Path.Combine(directory, shortName));
                }
            }
            catch { /* impossibile ricavare un percorso accorciato; resta valido il ripiego sul file temporaneo */ }

            try { candidates.Add(Path.GetTempFileName()); }
            catch { /* nessun file temporaneo di sistema disponibile; proviamo con quel che abbiamo */ }

            rd.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            rd.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

            // Esporta il report, ripiegando sui percorsi candidati in caso di errore.
            Exception lastException = null;
            try {
                for (int i = 0; i < candidates.Count; i++) {
                    string target = candidates[i];
                    try {
                        rd.ExportOptions.DestinationOptions = new DiskFileDestinationOptions { DiskFileName = target };
                        rd.Export();
                        if (File.Exists(target)) {
                            // Se non abbiamo usato il percorso originariamente richiesto, lo segnaliamo in 'error'.
                            if (i > 0) error = "percorso file modificato: " + target;
                            return true;
                        }
                        // L'export non ha dato errore ma non ha prodotto il file: lo trattiamo come errore e proviamo il percorso successivo.
                        lastException = null;
                    }
                    catch (Exception e) {
                        lastException = e;
                    }
                }

                // Tutti i tentativi falliti: riportiamo l'errore piu' recente, mantenendo la vecchia logica del messaggio KB3102429.
                if (lastException != null) {
                    if (!lastException.ToString().Contains("0x8000030E")) {
                        error =
                            "E' necessario disinstallare l'aggiornamento di windows KB3102429 per poter effettuare la stampa. - " +
                            lastException.Message;
                    }
                    else {
                        error = lastException.Message;
                    }
                }
                else {
                    error = "export fallito";
                }
                return false;
            }
			finally {
                rd.Dispose();

			}
        }

        public bool stampaFatturaFEvendita(DataAccess Conn, string FilePath, DataRow Rsdi_venditaext, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "fevendita_" + Rsdi_venditaext["idsdi_vendita"].ToString() + ".htm";
            //Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            string fullTempFileName = Path.GetTempFileName();

            //XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlWriter xw = XmlWriter.Create(fullTempFileName);
            XmlDocument doc = new XmlDocument();

            if (Rsdi_venditaext["xml"] == null)
            {
                if (Rsdi_venditaext["idfilestorage"] != null)
                {
                    // Leggo da MongoDb
                    byte[] byteArray = HttpFileStorage.DownloadFile(Conn, "sdi_vendita", Rsdi_venditaext["idfilestorage"].ToString()).GetAwaiter().GetResult();
                    if (byteArray == null)
                    {
                        if (!_useUI) {

                            throw new Exception($"Errore non gestito su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(byteArray)}' nullo per idfilestorage '{Rsdi_venditaext["idfilestorage"]}' e bucket 'sdi_vendita'.");
                        }

                        MetaFactory.factory.getSingleton<IMessageShower>()?.Show("Servizio Download degli Allegati non disponibile");
                        return false;
                    }
                    Rsdi_venditaext["xml"] = byteArray;
                }
            }

            doc.LoadXml(Rsdi_venditaext["xml"].ToString());
            string versione = doc.DocumentElement.Attributes["versione"].Value;
            DateTime dataCont = (DateTime)Conn.GetSys("datacontabile");
            DateTime dataOttobre2020 = new DateTime(2020, 10, 1);
            string xsl = "";
            bool isPA = Rsdi_venditaext["ipa_ven_cliente"].ToString().Length == 6;

            try
            {
                if (dataCont != null && dataCont > dataOttobre2020)
                {
                    //PRENDO I NUOVI FILE XSLT CHE VANNO IN VIGORE DAL 1/10/2020
                    string xslNew = isPA ? "fatturapa_v1.2.1.xslt" : "fatturaordinaria_v1.2.1.xslt";
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;
                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(Path.Combine(xslDir.FullName, xsl));
                    xsltransform.Transform(doc, null, xw);
                    xw.Flush();
                    xw.Close();
                    if (File.Exists(FilePath + tempFileName))
                    {
                        File.Delete(FilePath + tempFileName);
                    }
                    //File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                    File.Move(fullTempFileName, FilePath + tempFileName);
                }
                else
                {
                    string xslNew = isPA ? "fatturapa_v1.2.xslt" : "fatturaordinaria_v1.2.xslt";
                    xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;

                    XslCompiledTransform xsltransform = new XslCompiledTransform();
                    xsltransform.Load(Path.Combine(xslDir.FullName,xsl));

                    xsltransform.Transform(doc, null, xw);
                    xw.Flush();
                    xw.Close();
                    if (File.Exists(FilePath + tempFileName))
                    {
                        File.Delete(FilePath + tempFileName);
                    }

                    //File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                    File.Move(fullTempFileName, FilePath + tempFileName);
                }

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(FilePath + tempFileName, false);
            }
            catch (Exception ee)
            {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }

        public void writeToFile(string fileName, XmlDocument doc) {
            if (doc != null) {
                doc.Save(fileName);

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(fileName, false);
            }
        }
        public bool stampaXML_FEacquisto(DataAccess Conn, string FilePath, DataRow Rsdi_acquisto, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "feacquisto_xml_" + Rsdi_acquisto["idsdi_acquisto"].ToString() + ".xml";

            string fullTempFileName = Path.GetTempFileName();

            //XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlWriter xw = XmlWriter.Create(fullTempFileName);
            XmlDocument doc = new XmlDocument();

            if (Rsdi_acquisto["xml"] == null)
            {
                if (Rsdi_acquisto["idfilestorage"] != null)
                {
                    // Leggo da MongoDb
                    byte[] byteArray = HttpFileStorage.DownloadFile(Conn, "sdi_acquisto", Rsdi_acquisto["idfilestorage"].ToString()).GetAwaiter().GetResult();
                    if (byteArray == null)
                    {
                        if (!_useUI) {

                            throw new Exception($"Errore non gestito su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(byteArray)}' nullo per idfilestorage '{Rsdi_acquisto["idfilestorage"]}' e bucket 'sdi_acquisto'.");
                        }

                        MetaFactory.factory.getSingleton<IMessageShower>()?.Show("Servizio Download degli Allegati non disponibile");
                        return false;
                    }
                    Rsdi_acquisto["xml"] = byteArray;
                }
            }

            doc.LoadXml(Rsdi_acquisto["xml"].ToString());
            try
            {
                if (doc != null)
                {
                    string nomeFileXml = Path.Combine(FilePath, tempFileName);
                    if (File.Exists(nomeFileXml))
                    {
                        File.Delete(nomeFileXml);
                    }
                    writeToFile(nomeFileXml, doc);

                }
            }
            catch (Exception ee)
            {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }

        public bool stampaXML_FEvendita(DataAccess Conn, string FilePath, DataRow Rsdi_vendita, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "fevendita_xml_" + Rsdi_vendita["idsdi_vendita"].ToString() + ".xml";

            string fullTempFileName = Path.GetTempFileName();

            //XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlWriter xw = XmlWriter.Create(fullTempFileName);
            XmlDocument doc = new XmlDocument();

            if (Rsdi_vendita["xml"] == null)
            {
                if (Rsdi_vendita["idfilestorage"] != null)
                {
                    // Leggo da MongoDb
                    byte[] byteArray = HttpFileStorage.DownloadFile(Conn, "sdi_vendita", Rsdi_vendita["idfilestorage"].ToString()).GetAwaiter().GetResult();
                    if (byteArray == null)
                    {
                        if (!_useUI) {

                            throw new Exception($"Errore non gestito su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(byteArray)}' nullo per idfilestorage '{Rsdi_vendita["idfilestorage"]}' e bucket 'sdi_vendita'.");
                        }

                        MetaFactory.factory.getSingleton<IMessageShower>()?.Show("Servizio Download degli Allegati non disponibile");
                        return false;
                    }
                    Rsdi_vendita["xml"] = byteArray;
                }
            }

            doc.LoadXml(Rsdi_vendita["xml"].ToString());
            try
            {
                if (doc != null)
                {
                    string nomeFileXml = Path.Combine(FilePath, tempFileName);
                    if (File.Exists(nomeFileXml))
                    {
                        File.Delete(nomeFileXml);
                    }
                    writeToFile(nomeFileXml, doc);

                }
            }
            catch (Exception ee)
            {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }
        public bool stampaFatturaFEacquisto(DataAccess Conn, string FilePath, DataRow Rsdi_acquisto, out string errmess) {
            errmess = "";
            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            string tempFileName = "feacquisto_" + Rsdi_acquisto["idsdi_acquisto"].ToString() + ".htm";
            //Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            string fullTempFileName = Path.GetTempFileName();

            //XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlWriter xw = XmlWriter.Create(fullTempFileName);
            XmlDocument doc = new XmlDocument();

            if (Rsdi_acquisto["xml"] == null)
            {
                if (Rsdi_acquisto["idfilestorage"] != null)
                {
                    // Leggo da MongoDb
                    byte[] byteArray = HttpFileStorage.DownloadFile(Conn, "sdi_acquisto", Rsdi_acquisto["idfilestorage"].ToString()).GetAwaiter().GetResult();
                    if (byteArray == null)
                    {
                        if (!_useUI) {

                            throw new Exception($"Errore non gestito su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(byteArray)}' nullo per idfilestorage '{Rsdi_acquisto["idfilestorage"]}' e bucket 'sdi_acquisto'.");
                        }

                        MetaFactory.factory.getSingleton<IMessageShower>()?.Show("Servizio Download degli Allegati non disponibile");
                        return false;
                    }
                    Rsdi_acquisto["xml"] = byteArray;
                }
            }

            doc.LoadXml(Rsdi_acquisto["xml"].ToString());
            string versione = doc.DocumentElement.Attributes["versione"].Value;
            string xsl;
            DateTime dataCont = (DateTime)Conn.GetSys("datacontabile");
            DateTime dataOttobre2020 = new DateTime(2020, 10, 1);

            if (dataCont != null && dataCont > dataOttobre2020)
            {
                xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : "fatturapa_v1.2.1.xslt";
            }
            else
            {
                xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : "fatturapa_v1.2.xslt";
            }

            try
            {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(Path.Combine(xslDir.FullName, xsl));

                xsltransform.Transform(doc, null, xw);
                xw.Flush();
                xw.Close();
                if (File.Exists(FilePath + tempFileName))
                {
                    File.Delete(FilePath + tempFileName);
                }
                //File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                //File.Move(AppDomain.CurrentDomain.BaseDirectory + tempFileName, FilePath + tempFileName);
                File.Move(fullTempFileName, FilePath + tempFileName);

                MetaFactory.factory.getSingleton<IProcessRunner>()?.start(FilePath + tempFileName, false);
            }
            catch (Exception ee)
            {
                errmess = "Errore nella creazione del file FE " + ee;
                return false;
            }
            return true;
        }
        public bool stampaMandato(DataAccess Conn, string FilePath, DataRow curr,  out string errmess) {
            errmess = "";
            string ReportName = "mandato_pagamento";
            DataTable myPrymaryTable = createStampaMandatoTable();
            myPrymaryTable.Rows[0]["reportname"] = ReportName;

            myPrymaryTable.Rows[0]["ayear"] = curr["ypay"]; //Conn.GetSys("esercizio");
            myPrymaryTable.Rows[0]["printkind"] = "I";
            
            myPrymaryTable.Rows[0]["startnpay"] = CfgFn.GetNoNullInt32(curr["npay"]); 
            myPrymaryTable.Rows[0]["stopnpay"] = CfgFn.GetNoNullInt32(curr["npay"]);
            myPrymaryTable.Rows[0]["printdate"] = Conn.GetSys("datacontabile");
            myPrymaryTable.Rows[0]["official"] = "N";
            myPrymaryTable.Rows[0]["oneprint"] = "N";
            myPrymaryTable.Rows[0]["idtreasurer"] = CfgFn.GetNoNullInt32(curr["idtreasurer"]); ;
            myPrymaryTable.Rows[0]["nota"] = DBNull.Value ;

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();
            var par = myPrymaryTable.Rows[0];

            string tempfilename = "stampamandato_" + curr["ypay"].ToString() + "_" + curr["npay"].ToString() + ".pdf";

            bool retExp = false;

            if (MetaDataForm.isBlazorApp())
			{
                bool done = false;

                // Leggo la configurazione del servizio da chiamare da DB reportgenclient

                // se web client
                DataTable dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");

                string tempFilePath = Path.Combine(FilePath, tempfilename);

                if (dt != null)
				{
                    if (dt.Rows.Count > 0)
					{
                        string ServiceUrl = dt.Rows[0][0].ToString();
                        string ServiceParam = dt.Rows[0][1].ToString();

                        retExp = CallReportGenClient(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);

                        done = true;
					}
				}

                if (!done)
				{
                    // altrimenti cerco SignalR
                    dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'signalr'");
                    if (dt != null)
					{
                        if (dt.Rows.Count > 0)
						{
                            string ServiceUrl = dt.Rows[0][0].ToString();
                            string ServiceParam = dt.Rows[0][1].ToString();

                            retExp = CallReportGenSignal(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
						}
					}
				}

                return retExp;
			}

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            
            //pdfFileName = @"ReportPDF/" + sanitizedFilename;
            string error;
            retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
            if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
            return retExp;
        }
        public bool stampaReversale(DataAccess Conn, string FilePath, DataRow curr, out string errmess) {
            errmess = "";
            string ReportName = "reversale_incasso";
            DataTable myPrymaryTable = createStampaReversaleTable();
            myPrymaryTable.Rows[0]["reportname"] = ReportName;

            myPrymaryTable.Rows[0]["ayear"] = curr["ypro"]; // Conn.GetSys("esercizio");
            myPrymaryTable.Rows[0]["printkind"] = "I";

            myPrymaryTable.Rows[0]["startnpro"] = CfgFn.GetNoNullInt32(curr["npro"]);
            myPrymaryTable.Rows[0]["stopnpro"] = CfgFn.GetNoNullInt32(curr["npro"]);
            myPrymaryTable.Rows[0]["printdate"] = Conn.GetSys("datacontabile");
            myPrymaryTable.Rows[0]["official"] = "N";
            myPrymaryTable.Rows[0]["oneprint"] = "N";
            myPrymaryTable.Rows[0]["idtreasurer"] = CfgFn.GetNoNullInt32(curr["idtreasurer"]); ;

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();
            var par = myPrymaryTable.Rows[0];

            string tempfilename = "stampareversale_" + curr["ypro"].ToString() + "_" + curr["npro"].ToString() + ".pdf";

            bool retExp = false;

            if (MetaDataForm.isBlazorApp())
			{
                bool done = false;

                // Leggo la configurazione del servizio da chiamare da DB reportgenclient

                // se web client
                DataTable dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");

                string tempFilePath = Path.Combine(FilePath, tempfilename);

                if (dt != null)
				{
                    if (dt.Rows.Count > 0)
					{
                        string ServiceUrl = dt.Rows[0][0].ToString();
                        string ServiceParam = dt.Rows[0][1].ToString();

                        retExp = CallReportGenClient(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);

                        done = true;
					}
				}

                if (!done)
				{
                    // altrimenti cerco SignalR
                    dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'signalr'");
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            string ServiceUrl = dt.Rows[0][0].ToString();
                            string ServiceParam = dt.Rows[0][1].ToString();

                            retExp = CallReportGenSignal(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
                        }
                    }
                }

                return retExp;
            }

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\")) FilePath += "\\";
            
            //pdfFileName = @"ReportPDF/" + sanitizedFilename;
            string error;
            retExp = exportToPdf(myRptDoc, tempfilename, FilePath, out error);
            if (!retExp) errmess = "Impossibile esportare in pdf: " + tempfilename + " in " + FilePath + " (" + error + ")";
            return retExp;
        }
        public bool stampaCedolino(DataAccess Conn, string FilePath, DataRow curr, out string errmess) {

            errmess = "";
            string ReportName = "cedolino";
            DataTable myPrymaryTable = createStampaCedoliniTable();
            myPrymaryTable.Rows[0]["reportname"] = ReportName;

            myPrymaryTable.Rows[0]["idreg"] = curr["idreg"];
            myPrymaryTable.Rows[0]["ayear"] = CfgFn.GetNoNullInt32(curr["fiscalyear"]); //payroll.fiscalyear;
            myPrymaryTable.Rows[0]["start"] = curr["start"];
            myPrymaryTable.Rows[0]["stop"] = curr["stop"];
            myPrymaryTable.Rows[0]["mode"] = "E"; // anche contributi carico ente
            myPrymaryTable.Rows[0]["nota"] = DBNull.Value;

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();
            var par = myPrymaryTable.Rows[0];

            object[] parts = {
                "stampa",
                ReportName,
                curr["idpayroll"],
                curr["registry"],
                "mandato",
                curr["ypay"],
                curr["npay"]
            };

            string tempfilename = string.Join("_", parts.Select(part => (part ?? "").ToString().Replace(" ", "_")));
            string sanitizedFilename = !string.IsNullOrWhiteSpace(tempfilename) ? SanitizeFilename(tempfilename) : $"{Guid.NewGuid()}";
            var finalFilename = Path.ChangeExtension(sanitizedFilename, "pdf");

            bool retExp = false;

            if (MetaDataForm.isBlazorApp()) {
                bool done = false;

                // Leggo la configurazione del servizio da chiamare da DB reportgenclient

                // se web client
                DataTable dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");

                string tempFilePath = Path.Combine(FilePath, finalFilename);

                if (dt != null) {
                    if (dt.Rows.Count > 0) {
                        string ServiceUrl = dt.Rows[0][0].ToString();
                        string ServiceParam = dt.Rows[0][1].ToString();

                        retExp = CallReportGenClient(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);

                        done = true;
                    }
                }

                if (!done) {
                    // altrimenti cerco SignalR
                    dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'signalr'");
                    if (dt != null) {
                        if (dt.Rows.Count > 0) {
                            string ServiceUrl = dt.Rows[0][0].ToString();
                            string ServiceParam = dt.Rows[0][1].ToString();

                            retExp = CallReportGenSignal(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
                        }
                    }
                }

                return retExp;
            }

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "") errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\")) FilePath += "\\";

            //pdfFileName = @"ReportPDF/" + sanitizedFilename;
            string error;
            retExp = exportToPdf(myRptDoc, finalFilename, FilePath, out error);
            if (!retExp) errmess = "Impossibile esportare in pdf: " + finalFilename + " in " + FilePath + " (" + error + ")";
            return retExp;
        }


        public bool stampaContrattoPassivo(DataAccess Conn, string FilePath, DataRow curr, out string errmess) {

            errmess = "";
            string ReportName = "buono_ordine";

            DataTable myPrymaryTable = createStampaContrattiPassiviTable();
            DataRow par = myPrymaryTable.Rows[0];

            par["reportname"] = ReportName;

            par["ayear"] = CfgFn.GetNoNullInt32(curr["ayear"]);
            par["printkind"] = "I";  //curr["printkind"];
            par["mandatekind"] = curr["mandatekind"];
            par["startnman"] = CfgFn.GetNoNullInt32(curr["startnman"]);
            par["stopnman"] = CfgFn.GetNoNullInt32(curr["stopnman"]);
            par["idman"] = DBNull.Value;//CfgFn.GetNoNullInt32(curr["idman"]);
            par["official"] = "N"; // curr["official"];
            par["includevariation"] = "S"; // curr["includevariation"];
            par["variationdate"] = Conn.GetSys("datacontabile");// curr["variationdate"] == DBNull.Value ? DBNull.Value : curr["variationdate"];
            par["labelinenglish"] = curr["labelinenglish"];

            par["idsor01"] =curr["idsor01"];
            par["idsor02"] =curr["idsor02"];
            par["idsor03"] =curr["idsor03"];
            par["idsor04"] =curr["idsor04"];
            par["idsor05"] =curr["idsor05"];

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();

            object[] parts = {
                "stampa",
                ReportName,
                curr["descrmandatekind"],
                curr["ayear"],
                curr["startnman"],
                //curr["registry"]
            };

            string tempfilename = string.Join("_", parts.Select(part => (part ?? "").ToString().Replace(" ", "_")));
            string sanitizedFilename = !string.IsNullOrWhiteSpace(tempfilename) ? SanitizeFilename(tempfilename) : $"{Guid.NewGuid()}";
            var finalFilename = Path.ChangeExtension(sanitizedFilename, "pdf");

            bool retExp = false;

            if (MetaDataForm.isBlazorApp()) {
                bool done = false;

                DataTable dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");

                string tempFilePath = Path.Combine(FilePath, finalFilename);

                if (dt != null) {
                    if (dt.Rows.Count > 0) {
                        string ServiceUrl = dt.Rows[0][0].ToString();
                        string ServiceParam = dt.Rows[0][1].ToString();

                        retExp = CallReportGenClient(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);

                        done = true;
                    }
                }

                if (!done) {
                    dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'signalr'");
                    if (dt != null) {
                        if (dt.Rows.Count > 0) {
                            string ServiceUrl = dt.Rows[0][0].ToString();
                            string ServiceParam = dt.Rows[0][1].ToString();

                            retExp = CallReportGenSignal(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
                        }
                    }
                }

                return retExp;
            }

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (errmess == null || errmess == "")
                    errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\"))
                FilePath += "\\";

            string error;
            retExp = exportToPdf(myRptDoc, finalFilename, FilePath, out error);
            if (!retExp)
                errmess = "Impossibile esportare in pdf: " + finalFilename + " in " + FilePath + " (" + error + ")";

            return retExp;
        }


        public bool stampaContrattoAttivo(DataAccess Conn, string FilePath, DataRow curr, out string errmess) {

            errmess = "";
            string ReportName = "contrattoattivo";

            DataTable myPrymaryTable = createStampaContrattiAttiviTable();
            DataRow par = myPrymaryTable.Rows[0];

            par["reportname"] = ReportName;
            par["ayear"] = CfgFn.GetNoNullInt32(curr["ayear"]);
            par["printkind"] = curr["printkind"];
            par["idestimkind"] = curr["idestimkind"];
            par["nestim_start"] = CfgFn.GetNoNullInt32(curr["nestim_start"]);
            par["nestim_stop"] = CfgFn.GetNoNullInt32(curr["nestim_stop"]);
            par["idman"] =  curr["idman"];

            par["competencydate"] = Conn.GetSys("datacontabile");
            par["filtercompetency"] = "N";//curr["filtercompetency"]; //N

            par["official"] = "N";//curr["official"];

            par["idsor01"] = curr["idsor01"];
            par["idsor02"] = curr["idsor02"];
            par["idsor03"] = curr["idsor03"];
            par["idsor04"] = curr["idsor04"];
            par["idsor05"] = curr["idsor05"];

            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("reportname", ReportName);

            DataTable Report = Conn.RUN_SELECT("report", "*", null, filter, null, false);

            if (Report == null) {
                errmess = "Report: '" + ReportName + "' non trovato.";
                return false;
            }

            var rep = Report._First();

            object[] parts = {
                "stampa",
                ReportName,
                curr["estimkind"],
                curr["ayear"],
                curr["nestim_start"],
                //curr["registry"]
            };

            string tempfilename = string.Join("_", parts.Select(part => (part ?? "").ToString().Replace(" ", "_")));
            string sanitizedFilename = !string.IsNullOrWhiteSpace(tempfilename) ? SanitizeFilename(tempfilename) : $"{Guid.NewGuid()}";
            var finalFilename = Path.ChangeExtension(sanitizedFilename, "pdf");

            bool retExp = false;

            if (MetaDataForm.isBlazorApp()) {
                bool done = false;

                DataTable dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'webclient'");
                string tempFilePath = Path.Combine(FilePath, finalFilename);

                if (dt != null && dt.Rows.Count > 0) {
                    string ServiceUrl = dt.Rows[0][0].ToString();
                    string ServiceParam = dt.Rows[0][1].ToString();

                    retExp = CallReportGenClient(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
                    done = true;
                }

                if (!done) {
                    dt = Conn.SQLRunner("SELECT TOP 1 url, params FROM reportgenclient where name = 'signalr'");
                    if (dt != null && dt.Rows.Count > 0) {
                        string ServiceUrl = dt.Rows[0][0].ToString();
                        string ServiceParam = dt.Rows[0][1].ToString();

                        retExp = CallReportGenSignal(par, rep, ServiceUrl, ServiceParam, tempFilePath, out errmess);
                    }
                }

                return retExp;
            }

            ReportDocument myRptDoc = Easy_DataAccess.GetReport(Conn as Easy_DataAccess, rep, par, out errmess);
            if (myRptDoc == null) {
                if (string.IsNullOrEmpty(errmess))
                    errmess = "Impossibile trovare il report";
                return false;
            }

            if (!FilePath.EndsWith("\\"))
                FilePath += "\\";

            string error;
            retExp = exportToPdf(myRptDoc, finalFilename, FilePath, out error);

            if (!retExp) {
                errmess = "Impossibile esportare in pdf: " + finalFilename + " in " + FilePath + " (" + error + ")";
            }

            return retExp;
        }

        // =====================================================================================
        //									 WEB CLIENT
        // =====================================================================================
        private bool CallReportGenClient(DataRow Params, DataRow moduleReport, string ServiceUrl, string ServiceParam, string filePath, out string errmess)
		{
            errmess = "";

            byte[] reportContents;

            // Timeout di default 120
            int timeout = 120;

            // Provo a leggerlo dalla configurazione
            int.TryParse(ServiceParam, out timeout);

            string db = Conn.Security.GetSys("database").ToString();// Meta.Dispatcher.security.GetSys("database").ToString();

            try
            {
                WebClient client = new WebClient(ServiceUrl, timeout); // mettere in configurazione
                reportContents = client.Generate(db, moduleReport, Params);
            }
            catch (Exception ex)
            {
                errmess = string.Join(": ", "errore durante la chiamata al server dei report", ex.Message);
                return false;
            }

            try
            {
                File.WriteAllBytes(filePath, reportContents);

                MetaFactory.factory.getSingleton<IProcessRunner>().start(filePath, false);

                return true;
            }
            catch (Exception ex)
            {
                errmess = string.Join(": ", "impossibile ottenere il contenuto del file del report", ex.Message);
                return false;
            }
        }

        // =====================================================================================
        //										SIGNALR
        // =====================================================================================
        private bool CallReportGenSignal(DataRow Params, DataRow moduleReport, string ServiceUrl, string ServiceParam, string filePath, out string errmess)
        {
            errmess = "";

            byte[] reportContentsSignalR = { };

            string[] HubParams = ServiceParam.Split(',');

            string HubServiceUrl = ServiceUrl;          // https://localhost:44396/
            string HubName = HubParams[0];              // HubReport
            string HubMethod = HubParams[1];            // Send
            string FunctionCaller = HubParams[2];       // ReceivePdf
            string FunctionError = HubParams[3];        // ReceiveError

            // Controllo Url del servizio
            if (string.IsNullOrEmpty(HubServiceUrl) || string.IsNullOrEmpty(HubName) || string.IsNullOrEmpty(HubMethod) || string.IsNullOrEmpty(FunctionCaller) || string.IsNullOrEmpty(FunctionError))
            {
                errmess = "Servizio non configurato";
                return false;
            }

            try
            {
                // =====================================================================================
                // Delegate, Metodo chiamato da HubConnection ricevuto il pdf
                // =====================================================================================
                ActionCaller actionCaller = (byte[] pdfByte) => {
                    
                    File.WriteAllBytes(filePath, pdfByte);

                    MetaFactory.factory.getSingleton<IProcessRunner>().start(filePath, false);
                };

                // =====================================================================================
                // Delegate, Metodo chiamato da HubConnection in caso di errore
                // =====================================================================================
                ActionError actionError = (string msg) => {
                    ShowMsg(string.Join(": ", "impossibile ottenere il contenuto del file del report", msg));
                };

                // Istanza di HubConnection
                HubConn hubConn = HubConn.GetInstance(actionCaller, actionError, HubServiceUrl, HubName, FunctionCaller, FunctionError);

                // Se connesso Genero
                if (hubConn.isConnected())
                {
                    hubConn.Generate(HubMethod, moduleReport, Params);
                    return true;
                }
                else
                {
                    errmess = "Non è possibile stabilire la connessione con " + HubServiceUrl;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errmess = string.Join(": ", "impossibile ottenere il contenuto del file del report", ex.Message);
                return false;
            }
        }

        private void ShowMsg(string shortmsg)
        {
            ShowMsg(shortmsg, null);
        }

        private void ShowMsg(string shortmsg, string longmsg)
        {
            QueryCreator.ShowError(null, shortmsg, longmsg);
        }

        public int saveAttachments() {
            int filesCount = 0;

            if (attachmentsTable.Rows.Count == 0) return filesCount;

            if (!Directory.Exists(dstDir)) {
                Directory.CreateDirectory(dstDir);
            }

		    foreach (DataRow attachmentRow in attachmentsTable.Rows) {
                if (attachmentRow["attachment"] == DBNull.Value && attachmentRow["idfilestorage"] == DBNull.Value) continue;
                
                // File preso dall'attachment o dal MongoDb
                byte[] fileContents = { };

                if (attachmentRow["attachment"] != DBNull.Value)
                {
                    // Attachment
                    fileContents = (byte[])attachmentRow["attachment"];
                }
                else
                {
                    // MongoDb
                    fileContents = metaeasylibrary.HttpFileStorage.DownloadFile(Conn, attachmentsTable.TableName, attachmentRow["idfilestorage"].ToString()).GetAwaiter().GetResult();
                    if (fileContents == null)
                    {
                        if (!_useUI) {

                            throw new Exception($"Errore sconosciuto su '{nameof(HttpFileStorage.DownloadFile)}', restituito un '{nameof(fileContents)}' nullo per idfilestorage '{attachmentRow["idfilestorage"]}' e bucket '{attachmentsTable.TableName}'.");
                        }

                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Servizio Download degli Allegati non disponibile");
                        continue;
                    }
                }


                string fileName = SafeFileNameObj(attachmentRow["filename"]);
				string dstPath = Path.Combine (dstDir, FilePrefixLookupDict[docType] + "_" + attachmentRow["idattachment"].ToString() + "_" + fileName);

				try {
					saveFile(dstPath, fileContents);
				} catch (Exception e) {

                    if (!_useUI) {

                        throw new Exception($"Errore al salvataggio del file '{dstPath}'.", e);
                    }

					QueryCreator.ShowException(e);
				}

				filesCount++;
			}

			return filesCount;
        }
    }
}

