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
using System.IO;
using System.Data;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using Document;
using Document.IPA;
using Document.Protocol;
using Document.SDI;

using Backend.CommonBackend;
using Backend.Controllers;

namespace Backend.Extra {

    /// <summary>
    /// Classe utilizzata per i valori della cache estratta da protocollodockind.
    /// </summary>
    public class DocKind {

        // con C# 9 potremmo usare la keyword "record" per minimo boilerplate

        /// <summary>
        /// Direzione del documento relativamente all'Amministrazione.
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Nome del tipo di documento.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Assegna i valori indicati alle proprietà.
        /// </summary>
        /// <param name="kind">Direzione del documento relativamente all'Amministrazione.</param>
        /// <param name="title">Nome del tipo di documento.</param>
        public DocKind(string kind, string title) {
            Kind = kind;
            Title = title;
        }
    }

    /// <summary>
    /// Gestisce il protocoller a livello di applicazione per il backend. 
    /// </summary>
    public class ProtocollerService {

        /// <summary>
        /// Dispatcher.
        /// </summary>
        private static Dispatcher _dispatcher;
        /// <summary>
        /// Logger.
        /// </summary>
        private static BackendLogger _logger;
        /// <summary>
        /// Istanziatore del dataset di protocollo.
        /// </summary>
        private static ProtocolDSCreator _protocolDSCreator;
        /// <summary>
        /// Logger.
        /// </summary>
        private static Protocoller _protocoller;
        /// <summary>
        /// Amministrazione che effettua la conservazione.
        /// </summary>
        private static Administration _owner;

        /// <summary>
        /// Recupera l'ID sulla tabella "registry" per il soggetto.
        /// </summary>
        public static Func<ISoggetto, int?> RegistryIDRetriever = (ISoggetto s) =>
        {
            var q = _dispatcher.QueryHelper;

            string activeFilter = q.CmpEq("active", "S");
            string cfFilter = !string.IsNullOrWhiteSpace(s.CodiceFiscale) ? q.CmpEq("cf", s.CodiceFiscale) : string.Empty;
            string pivaFilter = !string.IsNullOrWhiteSpace(s.PartitaIVA) ? q.CmpEq("p_iva", s.PartitaIVA) : string.Empty;
            //string ipaFilter = q.CmpEq("ipa_fe", s.IPAAmm);

            string condition = q.AppAnd(activeFilter, q.AppOr(cfFilter, pivaFilter/*, ipaFilter*/));

            var idreg = _dispatcher.Connection.DO_READ_VALUE(
                "registry",
                condition,
                "idreg"
            );

            if (idreg == null)
                return null;

            if (int.TryParse(idreg.ToString(), out var parsed))
                return parsed;

            return null;
        };


        /// <summary>
        /// Cache dei MimeType per la protocollazione.
        /// </summary>
        public static Dictionary<int, string> MimeTypes = new Dictionary<int, string>();
        /// <summary>
        /// Cache dei ProtocolloKind per la protocollazione.
        /// </summary>
        public static Dictionary<int, string> ProtocolloKinds = new Dictionary<int, string>();
        /// <summary>
        /// Cache dei ProtocolloDocKind per la protocollazione.
        /// </summary>
        public static Dictionary<int, DocKind> ProtocolloDocKinds = new Dictionary<int, DocKind>();
        /// <summary>
        /// Cache dei ClassificazioneProtocollo per la protocollazione.
        /// </summary>
        public static Dictionary<int, string> ProtocolloClassificazioneKinds = new Dictionary<int, string>();  //classificazioneprotocollo

        /// <summary>
        /// Istanza condivisa.
        /// </summary>
        private static ProtocollerService _instance;
        /// <summary>
        /// Valore dell'istanza.
        /// </summary>
        public static ProtocollerService Instance {
            get {
                if (_instance == null) {
                    _logger?.Log($"{nameof(ProtocollerService)}.Instance is not available.",
                                 BackendLogger.LogLevel.Warning);

                    return null;
                }

                return _instance;
            }
        }

        /// <summary>
        /// Istanzia il singleton.
        /// </summary>
        /// <param name="dispatcher">Dispatcher.</param>
        /// <param name="logger">Logger.</param>
        private ProtocollerService(Dispatcher dispatcher, BackendLogger logger) {

            _dispatcher = dispatcher ?? throw new ArgumentException("Dispatcher non valido.");
            _logger = logger ?? throw new ArgumentException("Logger non valido.");

            _protocoller = new Protocoller(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileController.UploadPath));

            _protocolDSCreator = new ProtocolDSCreator();

            try {

                _owner = Administration.Get(dispatcher);
            }
            catch (Exception e) {

                throw new Exception("Could not set Administration.", e);
            }

            try {
                var mimetypeTable = _dispatcher.Connection.RUN_SELECT("mimetype", "idmimetype, title", null, null, null, false);
                MimeTypes = mimetypeTable.AsEnumerable()
                    .ToDictionary(row => Convert.ToInt32(row["idmimetype"]), row => row["title"].ToString());
            }
            catch (Exception e) {

                MimeTypes = new Dictionary<int, string>() { { 57, "application/xml" } }; // riempiamo per default con XML

                throw new Exception("Could not create MimeTypes cache.", e);
            }

            try {
                var protocollokindTable = _dispatcher.Connection.RUN_SELECT("protocollokind", "idprotocollokind, title", null, null, null, false);
                ProtocolloKinds = protocollokindTable.AsEnumerable()
                    .ToDictionary(row => Convert.ToInt32(row["idprotocollokind"]), row => row["title"].ToString());
            }
            catch (Exception e) {

                ProtocolloKinds = new Dictionary<int, string>() { { 1, "Entrata" }, { 2, "Uscita" }, { 3, "Interno" } }; // riempiamo default

                throw new Exception("Could not create ProtocolloKinds cache.", e);
            }

            try {
                var protocollodockindTable = _dispatcher.Connection.RUN_SELECT("protocollodockind", "idprotocollodockind, kind, title", null, null, null, false);
                ProtocolloDocKinds = protocollodockindTable.AsEnumerable()
                    .ToDictionary(row => Convert.ToInt32(row["idprotocollodockind"]), row => new DocKind(row["kind"].ToString(), row["title"].ToString()));
            }
            catch (Exception e) {

                ProtocolloDocKinds = new Dictionary<int, DocKind>() { { 5, new DocKind("Interno", "Documento") } }; // riempiamo per default con "Documento" generico e "Interno"

                throw new Exception("Could not create ProtocolloDocKinds cache.", e);
            }

            try {
                var classificazioneprotocolloTable = _dispatcher.Connection.RUN_SELECT("classificazioneprotocollo", "idclassificazioneprotocollo, title", null, null, null, false);
                ProtocolloClassificazioneKinds = classificazioneprotocolloTable.AsEnumerable()
                    .ToDictionary(row => Convert.ToInt32(row["idclassificazioneprotocollo"]), row => row["title"].ToString());
            }
            catch (Exception e) {

                // qui dovremmo mettere default generici e non specifici
                ProtocolloClassificazioneKinds = new Dictionary<int, string>() { { 1489, "CONTABILITA' GENERALE" } }; // riempiamo per default con una classificazione ispirata a quella di Trapani

                throw new Exception("Could not create ProtocolloClassificazioneKinds cache.", e);
            }

            _logger.Log("Inizializzazione completata.", BackendLogger.LogLevel.Information);
        }

        /// <summary>
        /// Imposta il dispatcher e il protocoller sul servizio.
        /// </summary>
        /// <param name="dispatcher">Dispatcher utilizzato per la configurazione del servizio.</param>
        public static void Initialize(Dispatcher dispatcher) {

            if (_dispatcher != null ||  _logger != null)
                throw new InvalidOperationException($"'{nameof(ProtocollerService)}' già inizializzato.");

            _dispatcher = dispatcher;

            var cfg = EasyConfigReader.Read(_dispatcher, "PROTOCOLLERSERVICE");

            // logger
            BackendLogger.LogLevel logLevel;
            if (cfg.TryGetValue("loglevel", out string logLevelStr) &&
                Enum.TryParse(logLevelStr, ignoreCase: true, out BackendLogger.LogLevel parsedLevel)) {
                logLevel = parsedLevel;
            }
            else {
                logLevel = BackendLogger.LogLevel.Error;
            }

            _logger = new BackendLogger(dispatcher, logLevel, nameof(ProtocollerService));

            // TODO: gestire creazione istanza se servizio abilitato e loggare istanziazione, per ora istanziamo in ogni caso
            try {

                _instance = new ProtocollerService(_dispatcher, _logger);
            }
            catch (Exception e) {

                BackendLoggerService.Logger.Log($"Impossibile inizializzare l'istanza: '{e.Message}'", BackendLogger.LogLevel.Critical);
            }
        }

        // il metodo per la protocollazione del registro giornaliero dovrebbe essere spostato come metodo su questo servizio così come fatto per
        // i documenti gestiti da SDI. In questo modo generalizzeremmo il tutto, e ProtocolLogPreserver si decomporrebbe nei 3 servizi che esplica:
        // Protocollazione (Protocol), Creazione del registro (Log), Conservazione (Preserve).
        // Volendo spingersi ancora oltre il metodo potrebbe essere uno solo e generico, prendendo come parametro generico <> un handler o una
        // interfaccia da cui SDIProtocolRequest : ISDIDocument derivi.

        /// <summary>
        /// Protocolla un documento gestito da SDI.
        /// </summary>
        /// <param name="d">Dispatcher da utilizzare.</param>
        /// <param name="spr">Richiesta di protocollazione.</param>
        /// <returns>Risultato dell'operazione di protocollazione.</returns>
        public ProtocolResult ProtocolSdi(Dispatcher d, SDIProtocolRequest spr) {

            byte[] xmlBytes = Convert.FromBase64String(spr.Xml);
            byte[] signedXmlBytes = Convert.FromBase64String(spr.SignedXml);

            var doc = new XmlDocument();

            using (var ms = new MemoryStream(xmlBytes)) {
                doc.Load(ms);
            }

            // estraiamo i ruoli dal documento e creiamo 
            var roleInfos = XMLUtils.ExtractRoleInfos(spr.DocumentType, doc, _owner.AdministrativeSubject);
            var sdifile = new SDIProtocolFile(spr.NomeDocumento, signedXmlBytes, SHA256.Create());

            var requestDS = _protocolDSCreator.CreateDataSet(d);

            DataTable protocollo = requestDS.Tables["protocollo"];
            DataTable protocollodestinatario = requestDS.Tables["protocollodestinatario"];
            DataTable protocollodoc = requestDS.Tables["protocollodoc"];
            DataTable protocollodocelement = requestDS.Tables["protocollodocelement"];

            // caricamento metadati
            var metaProtocollo = d.GetMeta("protocollo");
            var metaProtocolloDestinatario = d.GetMeta("protocollodestinatario");
            var metaProtocolloDoc = d.GetMeta("protocollodoc");
            var metaProtocollodocElement = d.GetMeta("protocollodocelement");

            // creazione nuove righe con default
            DataRow rowProtocollo = metaProtocollo.Get_New_Row(null, protocollo);
            DataRow rowProtocolloDestinatario = metaProtocolloDestinatario.Get_New_Row(rowProtocollo, protocollodestinatario);
            DataRow rowProtocolloDoc = metaProtocolloDoc.Get_New_Row(rowProtocollo, protocollodoc);
            DataRow rowProtocolloDocElement = metaProtocollodocElement.Get_New_Row(rowProtocolloDoc, protocollodocelement);

            var sender = roleInfos.FirstOrDefault(ri => ri.Tipo == TSoggetto.Mittente);
            var receiver = roleInfos.FirstOrDefault(ri => ri.Tipo == TSoggetto.Destinatario);

            // riga protocollo
            rowProtocollo["originemail"] = sender.Soggetto.IndirizziDigitali.FirstOrDefault(); //_owner.EmailAddress;
            rowProtocollo["originecodiceaoo"] = sender.Soggetto.IPAAOO;
            rowProtocollo["origineidamm"] = sender.Soggetto.IPAUOR;
            rowProtocollo["idreg_origine"] = RegistryIDRetriever(sender.Soggetto) ?? (object)DBNull.Value;

            // valorizzazione stringhe per oggetto protocollazione
            string documentType = HumanReadable.TDocuments.TryGetValue(spr.DocumentType, out var desc) ? desc : "Documento";
            string directionType = Enum.GetName(typeof(TDirection), spr.DirectionType);
            string additionalSubjectData = string.Empty;

            switch (spr.DirectionType) {
                case TDirection.Entrata:
                    additionalSubjectData = sender.Name;
                    break;

                case TDirection.Uscita:
                    additionalSubjectData = receiver.Name;
                    break;

                case TDirection.Interno:
                default:
                    additionalSubjectData = "Interno";
                    break;
            }
            rowProtocollo["oggetto"] = string.Join(" - ", documentType, additionalSubjectData); ;

            rowProtocollo["idprotocollokind"] = spr.DirectionType;

            // classificazione documenti SDI
            var classificazioneKey = ProtocolloClassificazioneKinds
                .Where(kvp => kvp.Value.Contains("CONTABILITA' GENERALE"))
                .Select(kvp => (int?)kvp.Key)
                .FirstOrDefault();
            rowProtocollo["idclassificazioneprotocollo"] = classificazioneKey ?? (object)DBNull.Value;

            rowProtocollo["protdata"] = DateTime.Now;
            rowProtocollo["testo"] = ""; //testo;
            rowProtocollo["codiceammipa"] = receiver.Soggetto.IPAAmm; //dsRegIstitutiPrinc.Tables["istitutoprinc"].Rows[0]["codiceammipa"];
            rowProtocollo["idaoo"] = 1; //(prima riga mi dicono)  //dsRegIstitutiPrinc.Tables["aoo"].Rows[0]["idaoo"];
            rowProtocollo["codiceregistro"] = "Registro Unico";
            rowProtocollo["annullato"] = "N";

            // riga destinatario
            rowProtocolloDestinatario["destmail"] = receiver.Soggetto.IndirizziDigitali.FirstOrDefault();
            rowProtocolloDestinatario["destcodiceaoo"] = receiver.Soggetto.IPAAOO;
            rowProtocolloDestinatario["destidamm"] = receiver.Soggetto.IPAUOR;
            rowProtocolloDestinatario["idreg_dest"] = RegistryIDRetriever(receiver.Soggetto) ?? (object)DBNull.Value;

            // riga documento
            rowProtocolloDoc["idprotocollorifkind"] = 3;    //Riferimento a un documento informatico contenuto nella struttura MIME che costituisce il messaggio
            rowProtocolloDoc["idmimetype"] = MimeTypes
                .Where(kvp => kvp.Value == "application/xml").Select(kvp => kvp.Key).DefaultIfEmpty(3).First();   // 3 => Interno

            rowProtocolloDoc["fileName"] = sdifile.FileDescriptor.Name;
            rowProtocolloDoc["datadoc"] = spr.DataDocumento;

            // riga elemento documento
            rowProtocolloDocElement["idprotocollodockind"] = ProtocolloDocKinds
                .Where(kvp => kvp.Value.Kind == "" && kvp.Value.Title == "").Select(kvp => kvp.Key).DefaultIfEmpty(5).First();   // 5 => "Interno", "Documento"

            // per ora lo impostiamo uguale all'oggetto della protocollazione, ma dovremmo metterci la causale
            // estraendo la logica da preserve.UniStorage.Logic.Mappings.Oggetto e riportandola sul progetto Document
            rowProtocolloDocElement["oggetto"] = rowProtocollo["oggetto"];
            
            rowProtocolloDocElement["telematicohash"] = sdifile.Hash;

            DataSet resData;

            try {

                resData = _protocoller.Protocol(d, requestDS, sdifile);
            }
            catch (Exception e) {

                throw new Exception($"Errore durante la protocollazione SDI per '{spr}'.", e);
            }

            return new ProtocolResult(resData);
        }
    }
}