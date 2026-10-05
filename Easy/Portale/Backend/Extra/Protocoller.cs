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
using System.Linq;
using System.Security.Cryptography;

using metadatalibrary;
using metaeasylibrary;

using Document.Protocol;

using Backend.CommonBackend;
using Backend.Data;

namespace Backend.Extra {

    /// <summary>
    /// File gestito da SDI da protocollare.
    /// </summary>
    public class SDIProtocolFile : IProtocolFile {
        
        /// <summary>
        /// Descrittore del file.
        /// </summary>
        public FileInfo FileDescriptor { get; }
        /// <summary>
        /// Contenuto del file.
        /// </summary>
        public byte[] Contents { get; }
        /// <summary>
        /// Algoritmo di hashing da utilizzare sul contenuto del file.
        /// </summary>
        public HashAlgorithm HashAlgorithm { get; }
        /// <summary>
        /// Hash del file calcolato secondo l'algoritmo impostato.
        /// </summary>
        public byte[] Hash => HashAlgorithm.ComputeHash(Contents);

        /// <summary>
        /// Crea un file gestito da SDI da protocollare.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="contents"></param>
        /// <param name="ha"></param>
        public SDIProtocolFile(string fileName, byte[] contents, HashAlgorithm ha = null) {

            FileDescriptor = !string.IsNullOrWhiteSpace(fileName) ? new FileInfo(fileName) : throw new Exception("Name of file must be provided.");

            Contents = contents;

            HashAlgorithm = ha ?? SHA256.Create(); // default SHA256
        }
    }

    /// <summary>
    /// Istanzia dataset per il protocollo e ne imposta le proprietà di estensione.
    /// </summary>
    public class ProtocolDSCreator {

        /// <summary>
        /// Nome della tabella principale per il protocollo.
        /// </summary>
        public string Tablename { get; } = "protocollo";
        /// <summary>
        /// Edittype da utilizzare per il protocollo.
        /// </summary>
        public string Edittype { get; } = "default";
        /// <summary>
        /// Nome del campo che referenzia la data dei documenti sul protocollo.
        /// </summary>
        public string DateFieldname { get; } = "protdata";

        // non posso usare DataUtils.createDataSet e metodi che lo richiamano perchè dipendono tutti dal contesto Http (per il riferimento al dispatcher) ...
        // => duplichiamo codice in una Factory che idealmente dovrebbe usare i metodi di DataUtils...
        // I metodi di DataUtils dovrebbero prendere il riferimento al dispatcher come argomento per poter essere riutilizzati...

        #region DUPLICATECODE
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <param name="dtToDescribe"></param>
        public static void manageColDescr(Dispatcher dispatcher, DataTable dtToDescribe) {

            //var conn = dispatcher.conn;
            //var qh = dispatcher.QueryHelper;

            string tableName = dtToDescribe.tableForReading();

            //var filter = qh.CmpEq("tablename", localtableName);
            var colDescr = dispatcher.Connection.RUN_SELECT("coldescr", "*", null, $"tablename = '{tableName}'", null, false);

            // 3. eseguo loop per popolare la caption della tabella del dataset
            foreach (DataColumn c in dtToDescribe.Columns) {
                // seleziono la riga di coldescr per questo column e seleziono il valore della caption
                string expr = "colname ='" + c.ColumnName + "'";
                DataRow[] rows = colDescr.Select(expr);
                if (rows.Length > 0) {
                    var caption = rows[0]["caption"];
                    if (caption != DBNull.Value) {
                        c.Caption = caption.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <param name="t"></param>
        /// <param name="editType"></param>
        public void setDefaults(Dispatcher dispatcher, DataTable t, string editType) {
            string tName = DataAccess.GetTableForReading(t);
            var meta = dispatcher.GetMeta(tName);
            meta.edit_type = editType;
            meta.SetDefaults(t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rel"></param>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool isSubEntityOrNotEntityChild(DataRelation rel, DataTable child, DataTable parent) {
            var model = MetaFactory.factory.getSingleton<IMetaModel>();
            bool isSubentity;
            if (rel == null) {
                isSubentity = QueryCreator.IsSubEntity(child, parent);
            }
            else {
                isSubentity = QueryCreator.IsSubEntity(rel, child, parent);
            }
            return isSubentity || model.isNotEntityChild(child);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <param name="parent"></param>
        /// <param name="editType"></param>
        /// <param name="scannedTable"></param>
        public void addSubEntityExtProperties(Dispatcher dispatcher, DataTable parent, string editType, Dictionary<string, bool> scannedTable = null) {

            if (scannedTable == null) {
                scannedTable = new Dictionary<string, bool> { [parent.tableForReading()] = true };//creates a congruent start condition
            }
            setDefaults(dispatcher, parent, editType);
            // propaga sulle tabelle child. Quindi conseidero le ChilRelation, cioè quelle in cui parent è tabella parent
            foreach (DataRelation r in parent.ChildRelations) {
                DataTable child = r.ChildTable;
                setDefaults(dispatcher, child, editType);
                if (scannedTable.ContainsKey(child.tableForReading())) continue; //skip this if it has already been scanned
                scannedTable[child.tableForReading()] = true; //avoids loops by design
                if (!isSubEntityOrNotEntityChild(r, child, parent)) continue;
                MetaData meta = dispatcher.GetMeta(child.tableForReading());
                meta.DescribeColumns(child);
                manageColDescr(dispatcher, child);
                dispatcher.conn.AddExtendedProperty(child);
                // vado in ricorsione
                addSubEntityExtProperties(dispatcher, child, editType, scannedTable);
            }
        }
        #endregion

        /// <summary>
        /// Istanzia un dataset in maniera dinamica creando un'istanza del tipo specifico letto dal namespace e imposta le proprietà di estensione tramite il dispatcher fornito.
        /// </summary>
        public Func<Dispatcher, string, string, DataSet> DataSetFactory { get; }

        /// <summary>
        /// Helper per l'accesso a DataSetFactory che utilizza le proprietà Tablename ed Edittype.
        /// </summary>
        /// <param name="dispatcher">Dispatcher da utilizzare per la creazione del dataset.</param>
        /// <returns>Istanza del dataset.</returns>
        public DataSet CreateDataSet(Dispatcher dispatcher) {

            // helper
            return DataSetFactory(dispatcher, Tablename, Edittype);
        }

        /// <summary>
        /// Inizializza la funzione di creazione del dataset.
        /// </summary>
        public ProtocolDSCreator() {

            DataSetFactory = (dispatcher, tableName, editType) => {

                //DataUtils.createDataSet()

                var dsName = $"Backend.Data.dsmeta_{tableName}_{editType}";
                var type = Type.GetType(dsName, true, true);

                if (!(Activator.CreateInstance(type) is DataSet ds))
                    throw new Exception($"Could not create dataset for table '{tableName}' and edittype '{editType}'.");

                ds.DataSetName = $"{tableName}_{editType}";
                if (ds is IDataSetInit ids) ids.initCustom(dispatcher);

                DataTable primaryTable = ds.Tables[tableName];
                dispatcher.conn.AddExtendedProperty(primaryTable);
                MetaData meta = dispatcher.GetMeta(tableName);
                meta.DescribeColumns(primaryTable);

                manageColDescr(dispatcher, primaryTable);
                addSubEntityExtProperties(dispatcher, primaryTable, editType);

                dispatcher.conn.AddExtendedProperty(ds.Tables[tableName]);

                return ds;
            };
        }
    }

    /// <summary>
    /// Identificativo di una protocollazione.
    /// </summary>
    public class ProtocolID {

        /// <summary>
        /// Nome del campo contenente l'anno di protocollazione su una riga di tabella.
        /// </summary>
        public static readonly string AnnoFieldname = "protanno";
        /// <summary>
        /// Nome del campo contenente il numero di protocollazione su una riga di tabella.
        /// </summary>
        public static readonly string NumeroFieldname = "protnumero";

        /// <summary>
        /// Data di protocollazione.
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Numero di protocollazione.
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Anno di protocollazione
        /// </summary>
        public int Year => Date.Year;

        /// <summary>
        /// Crea un identificativo a partire da una data e un numero di protocollazione.
        /// </summary>
        /// <param name="date">Data di protocollazione.</param>
        /// <param name="number">Numero di protocollazione.</param>
        public ProtocolID(DateTime date, int number) {

            Date = date;
            Number = number;
        }

        /// <summary>
        /// Crea un identificativo a partire da una riga di tabella.
        /// </summary>
        /// <param name="dr">Riga da cui estrarre i dati per creare l'identificativo.</param>
        public ProtocolID(DataRow dr) {

            if (dr == null) throw new ArgumentNullException(nameof(dr));

            try {

                var dateValue = dr["protdata"];
                var numberValue = dr[NumeroFieldname];

                Date = Convert.ToDateTime(dateValue);
                Number = Convert.ToInt32(numberValue);
            }
            catch (Exception e) {

                //sistemare
                throw new FormatException($"Invalid DataRow for ProtocolID. Expected fields '{AnnoFieldname}' and '{NumeroFieldname}'.", e);
            }
        }
    }

    /// <summary>
    /// Risultato della protocollazione di un documento.
    /// </summary>
    public class ProtocolResult : IProtocolResponse {

        /// <summary>
        /// Identificativo della protocollazione.
        /// </summary>
        public ProtocolID ID { get; }

        /// <summary>
        /// Percorso dell'allegato del file protocollato.
        /// </summary>
        public string AttachmentPath { get; }
        /// <summary>
        /// Codice di protocollo assegnato.
        /// </summary>
        public string ProtocolCode { get; }
        /// <summary>
        /// Oggetto.
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Numero di protocollo.
        /// </summary>
        public string ProtocolNum => ID.Number.ToString();

        /// <summary>
        /// Errore di protocollazione.
        /// </summary>
        public string Error => null;

        /// <summary>
        /// Estrae i dati di protocollazione dal dataset fornito.
        /// </summary>
        /// <param name="ds">Dati dell'operazione di protocollazione.</param>
        public ProtocolResult(DataSet ds) {

            try {

                var date = Convert.ToDateTime(ds.Tables["protocollo"].Rows[0]["protdata"]);
                var number = Convert.ToInt32(ds.Tables["protocollo"].Rows[0]["protnumero"]);

                ID = new ProtocolID(date, number);

            }
            catch (Exception e) {

                throw new Exception("Could not extract ID from provided data.", e);
            }

            try {

                AttachmentPath = ds.Tables["attach"].Rows[0]["filename"].ToString();
            }
            catch (Exception e) {

                throw new Exception("Could not extract file name.", e);
            }
        }
    }

    /// <summary>
    /// Protocolla i dati forniti nel dataset.
    /// </summary>
    public class Protocoller {

        /// <summary>
        /// Directory per l'archiviazione degli allegati.
        /// </summary>
        public DirectoryInfo AttachmentDir { get; }

        /// <summary>
        /// Istanzia un nuovo protocoller con la directory di scrittura fornita.
        /// </summary>
        /// <param name="writeDirPath">Percorso della directory per l'archiviazione dei file protocollati.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Protocoller(string writeDirPath) {

            AttachmentDir = Directory.Exists(writeDirPath) ? new DirectoryInfo(writeDirPath) :
                throw new ArgumentNullException(nameof(writeDirPath), "Attachment directory path is not valid.");
        }

        /// <summary>
        /// Protocolla i dati forniti nel dataset utilizzando il dispatcher fornito e l'allegato opzionale
        /// e ne forma la segnatura.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
        /// <param name="requestDS">Dati riguardanti il file da protocollare.</param>
        /// <param name="protocolFile">File da protocollare.</param>
        /// <returns>Dati di protocollazione.</returns>
        /// <exception cref="Exception"></exception>
        public DataSet Protocol(Dispatcher dispatcher, DataSet requestDS, IProtocolFile protocolFile) {

            var protocolDSCreator = new ProtocolDSCreator();

            // codice preso pari pari da SegreterieController.protocolla(), da sfoltire
            string tProtocollodestinatario = "protocollodestinatario";
            string tProtocollodoc = "protocollodoc";
            string tProtocollo = "protocollo";
            string tProtocollodocelement = "protocollodocelement";
            //string editType = "seg";
            string protnumeroField = "protnumero";
            string protannoField = "protanno";
            string dataannullamentoField = "dataannullamento";

            //var ds = prms.dsProtocolloSeg;
            //var tableName = prms.tableName;

            int protanno = getProtAnno();
            int protnumero = getProtNumber(dispatcher, protanno);
            //DataSet myds = DataSetSerializer.deserialize(ds, true, dispatcher);
            // protocollo potrebbe avere 2 righe, prendo quella in stato added, l'altra potrebbe essere quella da annullare
            foreach (DataRow r in requestDS.Tables[tProtocollo].Rows) {
                if (r.RowState == DataRowState.Added && r[dataannullamentoField] == DBNull.Value) {
                    r[protnumeroField] = protnumero;
                    r[protannoField] = protanno;
                }
            }

            foreach (DataRow r in requestDS.Tables[tProtocollodestinatario].Rows) {
                if (r.RowState == DataRowState.Added /*&& (int)r[protnumeroField] == 99990002*/) {
                    r[protnumeroField] = protnumero;
                    r[protannoField] = protanno;
                }
            }

            foreach (DataRow r in requestDS.Tables[tProtocollodoc].Rows) {
                if (r.RowState == DataRowState.Added /*&& (int)r[protnumeroField] == 99990002*/) {
                    r[protnumeroField] = protnumero;
                    r[protannoField] = protanno;
                }
            }

            foreach (DataRow r in requestDS.Tables[tProtocollodocelement].Rows) {
                if (r.RowState == DataRowState.Added /*&& (int)r[protnumeroField] == 99990002*/) {
                    r[protnumeroField] = protnumero;
                    r[protannoField] = protanno;
                }
            }

            // salvo su tabella referenziata
            requestDS.Tables[protocolDSCreator.Tablename].Rows[0][protnumeroField] = protnumero;
            requestDS.Tables[protocolDSCreator.Tablename].Rows[0][protannoField] = protanno;

            // sul meta della tab principale invocherò la post
            var saveDS = protocolDSCreator.CreateDataSet(dispatcher);

            //var outDs = DataUtils.createDataSet(protocolDSCreator.Tablename, protocolDSCreator.Edittype);

            // 4. Travasa i dati del ds proveninte dal client, su quello appena generato del server
            foreach (DataTable table in saveDS.Tables) {
                // solo se ovviamente la tabella esiste
                DataTable requestTable = requestDS.Tables[table.TableName];
                if (requestTable != null) {
                    // merge preservando lo stato delle righe
                    table.Merge(requestTable, true);
                    // copio le prop di autoincremento
                    //RowChange.CopyAutoIncrementProperties(requestTable, table);
                }
            }

            DataTable attachmentTable = saveDS.Tables["attach"];
            string opID = Guid.NewGuid().ToString();

            if (protocolFile != null && requestDS.Tables[tProtocollodoc].Rows.Count > 0) {

                string uniqueProtocolFilename = $"{opID}-{protocolFile.FileDescriptor.Name}";

                string attachFilepath = Path.Combine(AttachmentDir.FullName, uniqueProtocolFilename);

                try {

                    File.WriteAllBytes(attachFilepath, protocolFile.Contents);
                }
                catch (Exception e) {

                    throw new Exception($"Could not write '{protocolFile.FileDescriptor.FullName}' protocolFile file contents to '{attachFilepath}'.", e);
                }

                DataRow protocollodocRow = saveDS.Tables[tProtocollodoc].Rows[0];

                var idAttach = getIDattach(dispatcher);
                var metaAttach = dispatcher.GetMeta("attach");
                metaAttach.SetDefaults(attachmentTable);
                DataRow attachmentRow = metaAttach.Get_New_Row(null, attachmentTable);
                attachmentRow["idattach"] = idAttach;
                protocollodocRow["idattach"] = idAttach; //attachmentRow["idattach"]; 

                attachmentRow["filename"] = uniqueProtocolFilename;
                attachmentRow["size"] = protocolFile.Contents.Length;
                attachmentRow["hash"] = string.Empty; //protocolFile.Hash;
                //attachmentRow["testosegnatura"] = signatureFile?.ToString();
            }

            var meta = dispatcher.GetMeta(protocolDSCreator.Tablename);
            //var postData = meta.Get_PostData();

            var postData = new Easy_PostData_NoBL();
            postData.initClass(saveDS, dispatcher.Connection);

            //salva i dati ed ottiene un eventuale elenco di messaggi
            ProcedureMessageCollection myMessages = postData.DO_POST_SERVICE();
            var success = myMessages.Count == 0;
            //var canIgnore = success;

            var errorMsgs = myMessages.ToArray().Cast<ProcedureMessage>().Select(m => m.LongMess);

            if (!success)
                throw new Exception($"Errors while storing protocol data: { string.Join(" -> ", errorMsgs) }");

            //return saveDS.Tables[protocolDSCreator.Tablename].Rows[0];
            return saveDS;
        }

        /// <summary>
        /// Ottiene il numero di allegato successivo. Usa il dispatcher fornito.
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <returns>Identificativo prossimo numero di allegato disponibile.</returns>
        public static int getIDattach(Dispatcher dispatcher) {
            //var dispatcher = HttpContext.Current.getDataDispatcher();
            var conn = dispatcher.conn;
            string query = "select max(idattach) from attach";
            DataTable dtPaged = conn.SQLRunner(query);
            DataRow dtrow = dtPaged.Rows[0];
            return dtrow[0] == DBNull.Value ? 1 : (int)dtrow[0] + 1;
        }

        /// <summary>
        /// Ottiene il numero di protocollo successivo. Usa il dispatcher fornito. Copiato da SegreterieController.
        /// </summary>
        /// <param name="dispatcher"></param>
        /// <returns>Identificativo prossimo numero di protocollo disponibile.</returns>
        public static int getProtNumber(Dispatcher dispatcher, int protanno) {
            //var dispatcher = HttpContext.Current.getDataDispatcher();
            var conn = dispatcher.conn;
            string query = $"select max(protnumero) from protocollo where protanno = {protanno}";
            DataTable dtPaged = conn.SQLRunner(query);
            DataRow dtrow = dtPaged.Rows[0];
            return dtrow[0] == DBNull.Value ? 1 : (int)dtrow[0] + 1;
        }

        /// <summary>
        /// Ottiene l'anno di protocollo corrente. Copiato da SegreterieController.
        /// </summary>
        /// <returns>Anno corrente.</returns>
        public static int getProtAnno() {
            return DateTime.Now.Year;
        }
    }
}