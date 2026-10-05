using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using metadatalibrary;
using sdiDbConnection;
using sdiConfig;
using System.Data;
using sdiLog;
using Xceed.FileSystem;
using Xceed.Zip;
using System.IO;
using System.Net.Mail;
using eventLog;
using sdipassword;
using AegisImplicitMail;
using ftpfun;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.IO.Compression;

namespace preserveParer {
    public class ParerSOAP {
        private string endPoint { get; }

        private string user { get; }

        private string password { get; }

        private string ambiente { get; }

        private string ente { get; }

        private string struttura { get; }

        //Default Constructor
        public class PreIngestConfig {
            public string Code;
            public string[] Config;
        }

        public class InviaOggettoPreIngest {
            // Chiamata al servizio “InvioOggettoPreIngest”
            public string NmAmbiente; // Nome che identifica l’Ambiente cui appartiene il Versatore asincrono.X  SI

            public string
                NmVersatore; //Nome che identifica il Versatore asincrono nell'ambito dell'Ambiente di appartenenza X SI

            public string
                CdKeyObject; // Chiave che identifica l'Oggetto versato nell'ambito del Versatore asincrono. Per esempio: PUC-2013-1 X SI

            public string DsObject; //Descrizione dell’oggetto SI/NO

            public string
                NmTipoObject; // Nome identificante il tipo dell'Oggetto versato nell'ambito del Versatore asincrono X SI

            public string
                FlFileCifrato; //Indica se i file dell''Oggetto saranno trasmessi cifrati, oppure no (default = false) X SI

            public string flForzaWarning; // Indica se forza a WARNING l’esito del versamento; default = false X SI

            public string
                FlForzaAccettazione; //  Assume valori True o False. Valore di default: False True: indica la volontà del versante di voler eseguire l’invio in conservazione anche se la precedente sessione di ingest dell’Oggetto versato è in stato WARNING X SI

            public string
                DlMotivazione; // Motivo della forzatura(da indicare nel caso in cui FlForzaAccettazione sia settato a True) NO

            public string
                CdVersioneXML; //Versione del file XML contenente i Dati specifici versato con l'Oggetto. È definito se nel versamento è inviato anche il file XML con i dati specifici Specifiche tecniche dei servizi di versamento [ 134 ] NO

            public string
                XML; //È l’Indice del SIP da normalizzare, un documento in formato XML.Può contenere i metadati specifici dell’Oggetto se per la Tipologia di Unità documentaria relative all’Oggetto o per le tipologie di file versati sono previsti Dati specifici. NO

            public string
                NmAmbienteObjectPadre; // Nome che identifica l'ambiente a cui appartiene il versatore dell’eventuale oggetto padre NO

            public string
                NmVersatoreObjectPadre; // Nome che identifica il versatore nell'ambito dell'ambiente di appartenenza, dell’eventuale oggetto padre NO

            public string cdKeyObjectPadre; //Codice dell’eventuale oggetto padre NO

            public string
                niTotObjectFigli; // Numero totale degli oggetti figli; definibile solo se è definito l’oggetto padre NO

            public string pgObjectFiglio; //Progressivo dell’oggetto figlio di cui si effettua l’invio NO
            public string niUnitaDocAttese; // Numero di unità doc attese contenute nell’oggetto inviato NO

            public string
                cdVersGen; //Codice del versatore per cui si generano oggetti; è definibile solo se l’invio oggetto è relativo ad un oggetti di tipo DA_TRASFORMARE NO

            public string tiGestOggettiFigli; //Tipo gestione degli oggetti NO

        }

        public class EsitoInviaOggettoPreIngest {
            // Esito chiamata al servizio “InvioOggettoPreIngest”
            public string CdEsito; /* Codice che identifica l’esito del servizio:
									 OK se non si determinano errori;
									 KO se si determina un errore;
									 WARN se si determina un warning.*/

            public string
                cdErr; //  Codice identificante l’errore o il warning rilevato. Non è definito se CdEsito = OK.

            public string dlErr; // Descrizione dell’errore o del warning
            public string NmAmbiente; // Nome che identifica l’Ambiente cui appartiene il Versatore asincrono.X  SI

            public string
                NmVersatore; //Nome che identifica il Versatore asincrono nell'ambito dell'Ambiente di appartenenza X SI

            public string
                CdKeyObject; // Chiave che identifica l'Oggetto versato nell'ambito del Versatore asincrono. Per esempio: PUC-2013-1 X SI

            public string
                NmTipoObject; // Nome identificante il tipo dell'Oggetto versato nell'ambito del Versatore asincrono X SI

            public string
                FlFileCifrato; //Indica se i file dell''Oggetto saranno trasmessi cifrati, oppure no (default = false) X SI

            public string flForzaWarning; // Indica se forza a WARNING l’esito del versamento; default = false X SI

            public string
                FlForzaAccettazione; //  Assume valori True o False. Valore di default: False True: indica la volontà del versante di voler eseguire l’invio in conservazione anche se la precedente sessione di ingest dell’Oggetto versato è in stato WARNING X SI

            public string
                DlMotivazione; // Motivo della forzatura(da indicare nel caso in cui FlForzaAccettazione sia settato a True) NO

            public string
                CdVersioneXML; //Versione del file XML contenente i Dati specifici versato con l'Oggetto. È definito se nel versamento è inviato anche il file XML con i dati specifici Specifiche tecniche dei servizi di versamento [ 134 ] NO

            public string
                XML; //È l’Indice del SIP da normalizzare, un documento in formato XML.Può contenere i metadati specifici dell’Oggetto se per la Tipologia di Unità documentaria relative all’Oggetto o per le tipologie di file versati sono previsti Dati specifici. NO

            public string
                NmAmbienteObjectPadre; // Nome che identifica l'ambiente a cui appartiene il versatore dell’eventuale oggetto padre NO

            public string
                NmVersatoreObjectPadre; // Nome che identifica il versatore nell'ambito dell'ambiente di appartenenza, dell’eventuale oggetto padre NO

            public string cdKeyObjectPadre; //Codice dell’eventuale oggetto padre NO

            public string
                niTotObjectFigli; // Numero totale degli oggetti figli; definibile solo se è definito l’oggetto padre NO

            public string pgObjectFiglio; //Progressivo dell’oggetto figlio di cui si effettua l’invio NO
            public string niUnitaDocAttese; // Numero di unità doc attese contenute nell’oggetto inviato NO
        }

        public class NotificaTrasferimentoFile {
            // Chiamata del servizio “NotificaTrasferimentoFile”
            public string NmAmbiente; // Nome che identifica l’Ambiente cui appartiene il Versatore asincrono.X  SI

            public string
                NmVersatore; //Nome che identifica il Versatore asincrono nell'ambito dell'Ambiente di appartenenza X SI

            public string CdPassword; // Contiene la password di autenticazione del Versatore asincrono.

            public string
                CdKeyObject; // Chiave che identifica l'Oggetto versato nell'ambito del Versatore asincrono. Per esempio: PUC-2013-1 X SI

            public string[] ListaFileDepositati;
            public string NmTipoFile; // Nome identificante il tipo di file versato nell'ambito del tipo Oggetto.
            public string NmNomeFile; // Nome del file depositato.
            public string CdEncoding; // Encoding hash.
            public string TiAlgoritmoHash; // Algoritmo di hash utilizzato. Al momento sono gestiti SHA256, SHA1, MD5.

            public string
                DsHashFile; // Hash dei file trasmessi. Viene utilizzato in fase di controllo asincrono per verificare l’integrità dei file inviati.
        }



        public static PreIngestConfig getPreIngestConfig(DataAccess conn, string code) {
            QueryHelper q = conn.GetQueryHelper();
            //code può assumere i seguenti valori ;  parer_async, parer_sinc
            var tPreIngestConfig = conn.RUN_SELECT("conservation_config", "*", null, q.CmpEq("code", code), "1", false);
            if (tPreIngestConfig == null || tPreIngestConfig.Rows.Count == 0) {
                return null;
            }

            var r = tPreIngestConfig.Rows[0];
            return new PreIngestConfig {Code = r["code"] as string, Config = r["config"].ToString().Split('|')};
        }

        public ParerSOAP(string url, string user = null, string password = null, string ambiente = null,
            string ente = null, string struttura = null) {
            endPoint = url;
            this.user = user;
            this.password = password;
            this.ambiente = ambiente;
            this.ente = ente;
            this.struttura = struttura;
        }

        //public ParerSOAPFTP(string urlftp, string user = null, string password = null, string ambiente = null, string ente = null, string struttura = null) {
        //	this.endPoint = urlftp;
        //	this.userftp = userftp;
        //	this.passwordftp = passwordftp;
        //	this.ambienteftp = ambienteftp;
        //	this.enteftp = enteftp;
        //	this.strutturaftp = strutturaftp;
        //}


        public string inviaAPreIngest(string filename, string tipoObject, string dsObject) {
            /*PING(PRE INGEST): è il modulo del Sistema preposto alla ricezione dei SIP non normalizzati, alla loro trasformazione in SIP normalizzati  e al conseguente versamento nel Sistema. 
             * Tra le sue funzionalità, rientrano quelle di gestione dei servizi di versamento in modalità asincrona.*/
            var wc = new WebClient();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            InviaOggettoPreIngest request = new InviaOggettoPreIngest();
            request.NmAmbiente =
                this.ambiente; // Nome che identifica l’Ambiente cui appartiene il Versatore asincrono.  OBBL
            request.NmVersatore =
                this.user; //Nome che identifica il Versatore asincrono nell'ambito dell'Ambiente di appartenenza  OBBL
            request.CdKeyObject =
                filename; // Chiave che identifica l'Oggetto versato nell'ambito del Versatore asincrono. Per esempio: PUC-2013-1   OBBL
            request.DsObject = dsObject; //Descrizione dell’oggetto non OBBL
            request.NmTipoObject =
                tipoObject; // Nome identificante il tipo dell'Oggetto versato nell'ambito del Versatore asincrono   OBBL
            request.FlFileCifrato =
                "FALSE"; //Indica se i file dell''Oggetto saranno trasmessi cifrati, oppure no (default = false) OBBL
            request.flForzaWarning = "FALSE"; // Indica se forza a WARNING l’esito del versamento; default = false  OBBL
            request.FlForzaAccettazione =
                "FALSE"; //  Assume valori True o False. Valore di default: False True: indica la volontà del versante di voler eseguire l’invio in conservazione anche se la precedente sessione di ingest dell’Oggetto versato è in stato WARNING  OBBL
            // non valorizziamo il file indice ma solo un file CSV
            // request.XML = ;//È l’Indice del SIP da normalizzare, un documento in formato XML.Può contenere i metadati specifici dell’Oggetto se per la Tipologia di Unità documentaria relative all’Oggetto o per le tipologie di file versati sono previsti Dati specifici. NO OBBL

            // non compiliamo   i dati facoltativi nella request
            /*
            request.DlMotivazione  =; // Motivo della forzatura(da indicare nel caso in cui FlForzaAccettazione sia settato a True) NO OBBL
            request.CdVersioneXML  =;//Versione del file XML contenente i Dati specifici versato con l'Oggetto. È definito se nel versamento è inviato anche il file XML con i dati specifici Specifiche tecniche dei servizi di versamento [ 134 ] NO OBBL
            request.XML  =;//È l’Indice del SIP da normalizzare, un documento in formato XML.Può contenere i metadati specifici dell’Oggetto se per la Tipologia di Unità documentaria relative all’Oggetto o per le tipologie di file versati sono previsti Dati specifici. NO OBBL
            request.NmAmbienteObjectPadre  =;// Nome che identifica l'ambiente a cui appartiene il versatore dell’eventuale oggetto padre NO OBBL
            request.NmVersatoreObjectPadre  =;// Nome che identifica il versatore nell'ambito dell'ambiente di appartenenza, dell’eventuale oggetto padre NO OBBL
            request.cdKeyObjectPadre  =;//Codice dell’eventuale oggetto padre NO OBBL
            request.niTotObjectFigli  =;// Numero totale degli oggetti figli; definibile solo se è definito l’oggetto padre NO OBBL
            request.pgObjectFiglio  =;//Progressivo dell’oggetto figlio di cui si effettua l’invio NO OBBL
            request.niUnitaDocAttese  =;// Numero di unità doc attese contenute nell’oggetto inviato NO OBBL
            request.cdVersGen =;//Codice del versatore per cui si generano oggetti; è definibile solo se l’invio oggetto è relativo ad un oggetti di tipo DA_TRASFORMARE NO OBBL
            request.tiGestOggettiFigli  =;//Tipo gestione degli oggetti NO OBBL
            */
            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
            wc.Headers.Remove("Expect");
            wc.Headers.Remove("Content-Type");
            wc.Headers["Content-Type"] = "text/xml";
            wc.Headers["Host"] = "siopeplus-tst.vaservices.eu:444";

            wc.Headers[HttpRequestHeader.Accept] = "*/*";
            wc.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate, br";
            wc.Headers[HttpRequestHeader.AcceptLanguage] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7";
            string onlyfilename = Path.GetFileNameWithoutExtension(filename);
            wc.Headers.Remove("Content-Disposition");
            wc.Headers["Content-Disposition"] = onlyfilename + ".zip";


            //var servicePoint = ServicePointManager.FindServicePoint(new Uri(endPoint));
            //servicePoint.Expect100Continue = false;

            //string addr = endPoint;

            //try {
            //	var getPagamentoReq = new EsitoInviaOggettoPreIngest();
            //	var result = Service.Pagamento(getPagamentoReq);
            //	var resBody = result.response;
            //	if (resBody != null)
            //		return GenericSerializer.fromXml<PAGAMENTO_RESPONSE>(resBody.PagamentoResult);
            //} catch (FaultException exception) {
            //	error = exception.ToString();
            //	return null;
            //}
            return null;

            //try {
            //	var response = wc.DownloadData(new Uri(addr));
            //	var memStream = new MemoryStream(response);
            //	// Controllare se XML oppure generica stringa errore

            //	try {
            //		var xmlDoc = new XmlDocument();
            //		xmlDoc.Load(memStream);
            //		//XmlElement xmlDoc = xmlDoc.GetElementById("identificativoFlusso");
            //		if (xmlDoc.InnerXml.ToString().Contains("identificativoFlusso")) {
            //			memStream.Position = 0;

            //			var serializer = new XmlSerializer(typeof(FlussoRiversamento));
            //			var reader = XmlReader.Create(memStream);
            //			try {
            //				var rendiconto = (FlussoRiversamento) serializer.Deserialize(reader);
            //				return rendiconto;
            //			} catch (Exception ex) {
            //				//var ricevuta = new FlussoRiversamento();
            //				//errore = ex.ToString();
            //				//rendiconto.codiceBicBancaDiRiversamento = "123";
            //				//rendiconto.dataOraFlusso = DateTime.Now;
            //				//rendiconto.identificativoFlusso = "12345";
            //				//rendiconto = GenericSerializer.toXml<FlussoRiversamento>(ricevuta);
            //				errore = ex.ToString();
            //			}
            //		} else {
            //			errore = xmlDoc.ToString();
            //		}
            //	} catch (Exception ex) {
            //		// Lettura della stringa di errore
            //		StreamReader sr = new StreamReader(memStream);
            //		long pos = memStream.Position;
            //		memStream.Position = 0;

            //		string data = sr.ReadToEnd();
            //		errore = data;

            //	}
            //} catch (Exception ex) {
            //	//We catch non Http 200 responses here.
            //	errore = ex.ToString();

            //}

            return null;


        }





        public class Versatore {
            string ambiente;
            string ente;
            string struttura;
            string userid;

            public Versatore(string ambiente, string ente, string struttura, string userid) {
                this.ambiente = ambiente;
                this.ente = ente;
                this.struttura = struttura;
                this.userid = userid;
            }

            public XElement getXml() {
                if (this.ambiente == null) return null;
                XElement versatore = new XElement("versatore");
                versatore.Add(new XElement("Ambiente", this.ambiente));
                versatore.Add(new XElement("Ente", this.ente));
                versatore.Add(new XElement("Struttura", this.struttura));
                versatore.Add(new XElement("UserID", this.userid));
                return versatore;
            }

            public static Versatore getFromCfg() {
                serviceconfig s = SdiConfigManager.getServiceConfig();
                DataRow r = s.Tables["cfg"].Rows[0];
                return new Versatore(r["cons_ambiente"].ToString(), r["cons_ente"].ToString(),
                    r["cons_struttura"].ToString(), r["cons_userid"].ToString());
            }

        }


        public class Riferimento {
            string tiporegistro;
            string anno;
            string numero;

            public XElement getXml() {
                if (this.tiporegistro == null) return null;
                XElement chiave = new XElement("tiporegistro");
                chiave.Add(new XElement("TipoRegistro", this.tiporegistro));
                chiave.Add(new XElement("Anno", this.anno));
                chiave.Add(new XElement("Numero", this.numero));
                return chiave;
            }

            public Riferimento(string tiporegistro, string anno, string numero) {
                this.tiporegistro = tiporegistro;
                this.anno = anno;
                this.numero = numero;
            }
        }

        public class Chiave {
            string tiporegistro;
            string anno;
            string numero;

            public XElement getXml() {
                if (this.tiporegistro == null) return null;
                XElement chiave = new XElement("Chiave");
                chiave.Add(new XElement("TipoRegistro", this.tiporegistro));
                chiave.Add(new XElement("Anno", this.anno));
                chiave.Add(new XElement("Numero", this.numero));
                return chiave;
            }

            public Chiave(string tiporegistro, string anno, string numero) {
                this.tiporegistro = tiporegistro;
                this.anno = anno;
                this.numero = numero;
            }
        }

        public class ChiaveCollegamento {
            string tiporegistro;
            string anno;
            string numero;

            public XElement getXml() {
                if (this.tiporegistro == null) return null;
                XElement chiave = new XElement("ChiaveCollegamento");
                chiave.Add(new XElement("Numero", this.numero));
                chiave.Add(new XElement("Anno", this.anno));
                chiave.Add(new XElement("TipoRegistro", this.tiporegistro));
                return chiave;
            }

            public ChiaveCollegamento(string tiporegistro, string anno, string numero) {
                this.tiporegistro = tiporegistro;
                this.anno = anno;
                this.numero = numero;
            }
        }

        public class DocumentoCollegato {
            ChiaveCollegamento chiave;
            string DescrizioneCollegamento;

            public XElement getXml() {
                if (this.DescrizioneCollegamento == null) return null;
                XElement docCollegato = new XElement("DocumentoCollegato");
                docCollegato.Add(this.chiave);
                docCollegato.Add(new XElement("DescrizioneCollegamento", this.DescrizioneCollegamento));
                return docCollegato;
            }

            public DocumentoCollegato(ChiaveCollegamento chiave, string DescrizioneCollegamento) {
                this.chiave = chiave;
                this.DescrizioneCollegamento = DescrizioneCollegamento;
            }
        }

        public class Configurazione {
            string tipoconservazione;
            string forzaaccettazione;
            string forzaconservazione;
            string forzacollegamento;
            string SimulaSalvataggioDatiInDB;

            public XElement getXml() {
                if (this.tipoconservazione == null) return null;
                XElement config = new XElement("Configurazione");
                config.Add(new XElement("TipoConservazione", this.tipoconservazione));
                config.Add(new XElement("ForzaAccettazione", this.forzaaccettazione));
                config.Add(new XElement("ForzaConservazione", this.forzaconservazione));
                config.Add(new XElement("ForzaCollegamento", this.forzacollegamento));
                config.Add(new XElement("SimulaSalvataggioDatiInDB", this.SimulaSalvataggioDatiInDB));

                return config;
            }

            public Configurazione(string tipoconservazione, string forzaaccettazione, string forzaconservazione,
                string forzacollegamento, string SimulaSalvataggioDatiInDB) {
                this.tipoconservazione = tipoconservazione;
                this.forzaaccettazione = forzaaccettazione;
                this.forzaconservazione = forzaconservazione;
                this.forzacollegamento = forzacollegamento;
                this.SimulaSalvataggioDatiInDB = SimulaSalvataggioDatiInDB;
            }
        }

        public class ProfiloUnitaDocumentaria {
            string oggetto;
            string data;

            public XElement getXml() {
                if (this.oggetto == null) return null;
                XElement profilo = new XElement("ProfiloUnitaDocumentaria");
                profilo.Add(new XElement("Oggetto", this.oggetto));
                profilo.Add(new XElement("Data", this.data));
                return profilo;
            }

            public ProfiloUnitaDocumentaria(string oggetto, string data) {
                this.oggetto = oggetto;
                this.data = oggetto;
            }
        }



        public class DatiSpecificiFatturaAttiva {
            string versionedatispecifici;
            string denomdestinatario;
            string tipodenomdestinatario;
            string iddestinatario;
            string tipoiddestinatario;
            string importototale;
            string scadenzafattura;
            string aliquotaivareversecharge;
            string ivatotalereversecharge;

            public XElement getXml() {
                if (this.versionedatispecifici == null) return null;
                XElement datispec = new XElement("DatiSpecifici");
                datispec.Add(new XElement("VersioneDatiSpecifici", this.versionedatispecifici));
                datispec.Add(new XElement("DenominazioneDestinatario", this.denomdestinatario));
                datispec.Add(new XElement("TipoDenominazioneDestinatario", this.tipodenomdestinatario));
                datispec.Add(new XElement("IdentificativoDestinatario", this.iddestinatario));
                datispec.Add(new XElement("TipoIdentificativoDestinatario", this.tipoiddestinatario));
                datispec.Add(new XElement("ImportoTotale", this.importototale));
                datispec.Add(new XElement("ScadenzaFattura", this.scadenzafattura));
                datispec.Add(new XElement("AliquotaIvaReverseCharge", this.aliquotaivareversecharge));
                datispec.Add(new XElement("IvaTotaleReverseCharge", this.ivatotalereversecharge));
                return datispec;
            }

            public DatiSpecificiFatturaAttiva(string versionedatispecifici, string denomdestinatario,
                string tipodenomdestinatario,
                string iddestinatario, string tipoiddestinatario, string importototale,
                string scadenzafattura, string aliquotaivareversecharge, string ivatotalereversecharge) {
                this.versionedatispecifici = versionedatispecifici;
                this.denomdestinatario = denomdestinatario;
                this.tipodenomdestinatario = tipodenomdestinatario;
                this.iddestinatario = iddestinatario;
                this.tipoiddestinatario = tipoiddestinatario;
                this.importototale = importototale;
                this.scadenzafattura = scadenzafattura;
                this.aliquotaivareversecharge = aliquotaivareversecharge;
                this.ivatotalereversecharge = ivatotalereversecharge;
            }
        }



        public class DatiSpecificiFatturaPassiva {
            string versionedatispecifici;
            string numeroprotocollo;
            string dataprotocollo;
            string numeroruf;
            string denommittente;
            string dataregistrazioneruf;
            string numeroemissione;
            string dataemissione;
            string tipodenommittente;
            string idmittente;
            string tipoidmittente;
            string importototale;
            string oggettofornitura;
            string scadenza;
            string riferimentocontabile;
            string tiporifcontabile;
            string rilevanzaiva;
            string aliquotaivareversecharge;
            string ivatotalereversecharge;
            string cig;
            string cup;

            public XElement getXml() {
                if (this.numeroemissione == null) return null;
                XElement datispec = new XElement("DatiSpecifici");
                datispec.Add(new XElement("NumeroProtocollo", this.numeroprotocollo));
                datispec.Add(new XElement("VersioneDatiSpecifici", this.versionedatispecifici));
                datispec.Add(new XElement("DataProtocollo", this.dataprotocollo));
                datispec.Add(new XElement("NumeroRUF", this.numeroruf));
                datispec.Add(new XElement("DataRegistrazioneRUF", this.dataregistrazioneruf));
                datispec.Add(new XElement("NumeroEmissione", this.numeroemissione));
                datispec.Add(new XElement("DataEmissione", this.dataemissione));
                datispec.Add(new XElement("DenominazioneMittente", this.denommittente));
                datispec.Add(new XElement("TipoDenominazioneMittente", this.tipodenommittente));
                datispec.Add(new XElement("IdentificativoMittente", this.idmittente));
                datispec.Add(new XElement("TipoIdentificativoMittente", this.tipoidmittente));
                datispec.Add(new XElement("OggettoFornitura", this.oggettofornitura));
                datispec.Add(new XElement("ImportoTotale", this.importototale));
                datispec.Add(new XElement("Scadenza", this.scadenza));
                datispec.Add(new XElement("RiferimentoContabile", this.riferimentocontabile));
                datispec.Add(new XElement("TipoRifContabile", this.tiporifcontabile));
                datispec.Add(new XElement("RilevanzaIVA", this.rilevanzaiva));
                datispec.Add(new XElement("AliquotaIvaReverseCharge", this.aliquotaivareversecharge));
                datispec.Add(new XElement("IvaTotaleReverseCharge", this.ivatotalereversecharge));
                datispec.Add(new XElement("CIG", this.cig));
                datispec.Add(new XElement("CUP", this.cup));
                return datispec;
            }

            public DatiSpecificiFatturaPassiva(string versionedatispecifici, string numeroprotocollo,
                string dataprotocollo, string numeroruf, string dataregistrazioneruf,
                string numeroemissione, string dataemissione, string denommittente, string tipodenommittente,
                string idmittente,
                string tipoidmittente, string oggettofornitura, string importototale, string scadenza,
                string riferimentocontabile,
                string tiporifcontabile, string rilevanzaiva, string aliquotaivareversecharge,
                string ivatotalereversecharge, string cig, string cup) {
                this.versionedatispecifici = versionedatispecifici;
                this.numeroprotocollo = numeroprotocollo;
                this.dataprotocollo = dataprotocollo;
                this.numeroruf = numeroruf;
                this.dataregistrazioneruf = dataregistrazioneruf;
                this.numeroemissione = numeroemissione;
                this.dataemissione = dataemissione;
                this.denommittente = denommittente;
                this.tipodenommittente = tipodenommittente;
                this.idmittente = idmittente;
                this.tipoidmittente = tipoidmittente;
                this.oggettofornitura = oggettofornitura;
                this.importototale = importototale;
                this.importototale = importototale;
                this.scadenza = scadenza;
                this.riferimentocontabile = riferimentocontabile;
                this.tiporifcontabile = tiporifcontabile;
                this.rilevanzaiva = rilevanzaiva;
                this.aliquotaivareversecharge = aliquotaivareversecharge;
                this.ivatotalereversecharge = ivatotalereversecharge;
                this.cig = cig;
                this.cup = cup;
            }

        }


        public class DatiSpecificiLottoFattureAttive {
            string versionedatispecifici;
            string denomdestinatario;
            string tipodenomdestinatario;
            string iddestinatario;
            string tipoiddestinatario;


            public XElement getXml() {
                if (this.versionedatispecifici == null) return null;
                XElement datispec = new XElement("DatiSpecifici");
                datispec.Add(new XElement("VersioneDatiSpecifici", this.versionedatispecifici));
                datispec.Add(new XElement("DenominazioneDestinatario", this.denomdestinatario));
                datispec.Add(new XElement("TipoDenominazioneDestinatario", this.tipodenomdestinatario));
                datispec.Add(new XElement("IdentificativoDestinatario", this.iddestinatario));
                datispec.Add(new XElement("TipoIdentificativoDestinatario", this.tipoiddestinatario));
                return datispec;
            }

            public DatiSpecificiLottoFattureAttive(string versionedatispecifici, string denomdestinatario,
                string tipodenomdestinatario,
                string iddestinatario, string tipoiddestinatario) {
                this.versionedatispecifici = versionedatispecifici;
                this.denomdestinatario = denomdestinatario;
                this.tipodenomdestinatario = tipodenomdestinatario;
                this.iddestinatario = iddestinatario;
                this.tipoiddestinatario = tipoiddestinatario;
            }
        }

        public class DatiSpecificiLottoFatturePassive {
            string versionedatispecifici;
            string denommittente;
            string tipodenommittente;
            string idmittente;
            string tipoidmittente;


            public XElement getXml() {
                if (this.versionedatispecifici == null) return null;
                XElement datispec = new XElement("DatiSpecifici");
                datispec.Add(new XElement("VersioneDatiSpecifici", this.versionedatispecifici));
                datispec.Add(new XElement("DenominazioneMittente", this.denommittente));
                datispec.Add(new XElement("TipoDenominazioneMittente", this.tipodenommittente));
                datispec.Add(new XElement("IdentificativoMittente", this.idmittente));
                datispec.Add(new XElement("TipoIdentificativoMittente", this.tipoidmittente));
                return datispec;
            }

            public DatiSpecificiLottoFatturePassive(string versionedatispecifici, string denommittente,
                string tipodenommittente,
                string idmittente, string tipoidmittente) {
                this.versionedatispecifici = versionedatispecifici;
                this.denommittente = denommittente;
                this.tipodenommittente = tipodenommittente;
                this.idmittente = idmittente;
                this.tipoidmittente = tipoidmittente;
            }
        }

        public class Intestazione {
            Versatore versatore;
            Chiave chiave;
            string tipologiaunitadocumentaria;

            public XElement getXml() {
                if (this.chiave == null) return null;
                XElement intesta = new XElement("Intestazione");
                intesta.Add(this.versatore);
                intesta.Add(this.chiave);
                intesta.Add(new XElement("TipologiaUnitaDocumentaria", this.tipologiaunitadocumentaria));
                return intesta;
            }

            public Intestazione(Versatore versatore, Chiave chiave, string tipologiaunitadocumentaria) {
                this.versatore = versatore;
                this.chiave = chiave;
                this.tipologiaunitadocumentaria = tipologiaunitadocumentaria;
            }
        }

        public class SottoComponente {
            string id;
            string ordinepresentazione;
            string tipocomponente;
            string tiposupportocomponente;
            string nomecomponente;
            string formatofileversato;
            Riferimento riferimento;

            public XElement getXml() {
                if (this.nomecomponente == null) return null;
                XElement sottoComp = new XElement("sottocomponente");
                sottoComp.Add(new XElement("ID", this.id));
                sottoComp.Add(new XElement("OrdinePresentazione", this.ordinepresentazione));
                sottoComp.Add(new XElement("TipoComponente", this.tipocomponente));
                sottoComp.Add(new XElement("TipoSupportoComponente", this.tiposupportocomponente));
                sottoComp.Add(new XElement("NomeComponente", this.nomecomponente));
                sottoComp.Add(this.riferimento);
                sottoComp.Add(new XElement("FormatoFileVersato", this.formatofileversato));
                return sottoComp;
            }

            public SottoComponente(string id, string ordinepresentazione, string tipocomponente,
                string tiposupportocomponente, string nomecomponente, Riferimento riferimento,
                string formatofileversato) {
                this.id = id;
                this.ordinepresentazione = ordinepresentazione;
                this.tipocomponente = tipocomponente;
                this.tiposupportocomponente = tiposupportocomponente;
                this.nomecomponente = nomecomponente;
                this.riferimento = riferimento;
                this.formatofileversato = formatofileversato;
            }
        }

        public class Componente {
            string id;
            string ordinepresentazione;
            string tipocomponente;
            string tiposupportocomponente;
            string tiporappresentazionecomponente;
            string nomecomponente;
            string formatofileversato;
            List<SottoComponente> listastc;

            public XElement getXml() {
                if (this.nomecomponente == null) return null;
                XElement comp = new XElement("componente");
                comp.Add(new XElement("ID", id));
                comp.Add(new XElement("OrdinePresentazione", this.ordinepresentazione));
                comp.Add(new XElement("TipoComponente", this.tipocomponente));
                comp.Add(new XElement("TipoSupportoComponente", this.tiposupportocomponente));
                comp.Add(new XElement("TipoRappresentazioneComponente", this.tiporappresentazionecomponente));
                comp.Add(new XElement("NomeComponente", this.nomecomponente));
                comp.Add(new XElement("FormatoFileVersato", this.formatofileversato));
                comp.Add(new XElement("UtilizzoDataFirmaPerRifTemp", true));
                comp.Add(new XElement("SottoComponenti", this.listastc));
                return comp;
            }

            public Componente(string id, string ordinepresentazione, string tipocomponente,
                string tiposupportocomponente, string tiporappresentazionecomponente, string nomecomponente,
                string formatofileversato, List<SottoComponente> listastc) {
                this.id = id;
                this.ordinepresentazione = ordinepresentazione;
                this.tipocomponente = tipocomponente;
                this.tiposupportocomponente = tiposupportocomponente;
                this.tiporappresentazionecomponente = tiporappresentazionecomponente;
                this.nomecomponente = nomecomponente;
                this.formatofileversato = formatofileversato;
                this.listastc = listastc;
            }

        }

        public class Annesso {
            string iddocumento;
            string tipodocumento;
            List<Componente> strutturaoriginale;

            public XElement getXml() {
                if (this.iddocumento == null) return null;
                XElement annesso = new XElement("annesso");
                annesso.Add(new XElement("IDDocumento", this.iddocumento));
                annesso.Add(new XElement("TipoDocumento", this.tipodocumento));
                annesso.Add(new XElement("StrutturaOriginale", this.strutturaoriginale));
                return annesso;
            }

            public Annesso(string iddocumento, string tipodocumento, List<Componente> strutturaoriginale) {
                this.iddocumento = iddocumento;
                this.tipodocumento = tipodocumento;
                this.strutturaoriginale = strutturaoriginale;
            }
        }


        public class PreserveFile {
            public byte[] content;
            public int id_sdi;
            public string identificativo_sdi;
            public string codIpa;
            public string protocollo;
            Versatore Vers;
            Chiave Chiave;
            string TipologiaUnitaDocumentaria;
            Configurazione Configurazione;
            ProfiloUnitaDocumentaria ProfiloUD;
            DatiSpecificiFatturaAttiva DatiSpecificiAttiva;
            DatiSpecificiFatturaPassiva DatiSpecificiPassiva;
            DatiSpecificiLottoFattureAttive DatiSpecificiLottoAttive;
            DatiSpecificiLottoFatturePassive DatiSpecificiLottoPassive;
            List<Componente> Componenti = new List<Componente>();
            List<Annesso> Annessi = new List<Annesso>();
            List<DocumentoCollegato> DocumentiCollegati = new List<DocumentoCollegato>();
            int NumeroAllegati;
            int NumeroAnnessi;
            int NumeroAnnotazioni;

            string idDocumento;
            string TipoDocumento;

            public string formatDate(DateTime d) {
                return d.Year.ToString() + "-" + d.Month.ToString().PadLeft(2, '0') + "-" +
                       d.Day.ToString().PadLeft(2, '0');
            }

            public PreserveFile() {

            }

            public XElement getXml() {
                // Costruisce il file indice SIP  XML su singola Unita' Documentaria
                //<? xml version = "1.0" encoding = "utf-8" ?>
                //< UnitaDocumentaria xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance" >
                string primorigo = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
                XElement indiceUD = new XElement("UnitaDocumentaria");
                indiceUD.Add(new XAttribute("xmlns:xsi", "Shttp://www.w3.org/2001/XMLSchema-instance"));
                // Leggo i parametri della sezione Versatore da file di configurazione
                Vers = Versatore.getFromCfg();
                XElement XML_Vers = Vers.getXml();
                // Leggo il tipo unità documentaria
                string tipoUD = this.TipologiaUnitaDocumentaria;

                XElement e = new XElement("Intestazione");
                e.Add(new XElement("versione", "1.4"));
                e.Add(XML_Vers);
                // Chiave
                e.Add(this.Chiave.getXml());

                // fine intestazione
                //configurazione
                XElement config = this.Configurazione.getXml();
                XElement profiloUD = this.ProfiloUD.getXml();
                if (config != null) {
                    indiceUD.Add(config);
                }

                if (profiloUD != null) {
                    indiceUD.Add(profiloUD);
                }

                /*
                    <NumeroAllegati>2</NumeroAllegati>
                    <NumeroAnnessi>4</NumeroAnnessi>
                    <NumeroAnnotazioni> 0 </NumeroAnnotazioni>
                */
                e.Add(new XElement("NumeroAllegati", 0));
                e.Add(new XElement("NumeroAnnessi", this.Annessi.Count()));
                e.Add(new XElement("NumeroAnnotazioni", 0));
                XElement datispeLottoAttive = this.DatiSpecificiLottoAttive.getXml();
                if (datispeLottoAttive != null) {
                    indiceUD.Add(profiloUD);
                }

                XElement datispeLottoPassive = this.DatiSpecificiPassiva.getXml();
                if (datispeLottoPassive != null) {
                    indiceUD.Add(profiloUD);
                }

                XElement datispecattiva = this.DatiSpecificiAttiva.getXml();
                if (datispecattiva != null) {
                    indiceUD.Add(profiloUD);
                }

                XElement datispecpassiva = this.DatiSpecificiPassiva.getXml();
                if (datispecpassiva != null) {
                    indiceUD.Add(profiloUD);
                }

                //<IDDocumento> token </IDDocumento>
                //<TipoDocumento> concordato con ParER</TipoDocumento>
                XElement DocPrincipale = new XElement("DocumentoPrincipale");
                DocPrincipale.Add(new XElement("IDDocumento", this.idDocumento));
                DocPrincipale.Add(new XElement("TipoDocumento", this.TipoDocumento));

                if (this.Componenti.Count > 0) {
                    DocPrincipale.Add(new XElement("StrutturaOriginale"));

                    foreach (Componente comp in this.Componenti) {
                        XElement componente = comp.getXml();
                        if (componente != null) {
                            DocPrincipale.Add(componente);
                        }
                    }
                }

                indiceUD.Add(DocPrincipale);

                foreach (DocumentoCollegato doc in this.DocumentiCollegati) {
                    XElement doccoll = doc.getXml();
                    if (doccoll != null) {
                        indiceUD.Add(doccoll);
                    }
                }

                foreach (Annesso ann in this.Annessi) {
                    XElement annesso = ann.getXml();
                    if (annesso != null) {
                        indiceUD.Add(annesso);
                    }
                }


                return indiceUD;

            }

            static string getXmlText(XmlNode x, string xpath, XmlNamespaceManager ns) {
                if (ns == null) {
                    try {
                        XmlNode n = x.SelectSingleNode(xpath);
                        if (n != null) {
                            return n.InnerText;
                        }
                    }
                    catch {
                    }

                    return null;
                }

                try {
                    XmlNode n = x.SelectSingleNode(xpath, ns);
                    if (n != null) {
                        return n.InnerText;
                    }
                }
                catch {
                }

                return null;
            }



            public static string getCig(XmlDocument x) {
                string cig = null;
                foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiOrdineAcquisto")) {
                    if (d["CodiceCIG"] != null) {
                        cig = d["CodiceCIG"].InnerText;
                        if (cig != null && cig != "")
                            return cig;
                    }
                }

                foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiContratto")) {
                    if (d["CodiceCIG"] != null) {
                        cig = d["CodiceCIG"].InnerText;
                        if (cig != null && cig != "")
                            return cig;
                    }
                }

                foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiConvenzione")) {
                    if (d["CodiceCIG"] != null) {
                        cig = d["CodiceCIG"].InnerText;
                        if (cig != null && cig != "")
                            return cig;
                    }
                }

                foreach (XmlNode d in x.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiRicezione")) {
                    if (d["CodiceCIG"] != null) {
                        cig = d["CodiceCIG"].InnerText;
                        if (cig != null && cig != "")
                            return cig;
                    }
                }

                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="Conn">Connessione all'ente</param>
            /// <returns></returns>
            public static string getRiferimentoAmministrazione(XmlDocument x, DataAccess Conn) {
                QueryHelper q = Conn.GetQueryHelper();

                string riferimentoAmministrazione = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/RiferimentoAmministrazione", null);
                if (riferimentoAmministrazione != null && riferimentoAmministrazione.ToString().Trim() != "") {

                    if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", riferimentoAmministrazione),
                            false) == 1) {
                        return riferimentoAmministrazione;
                    }
                }

                string cig = getCig(x);
                if (cig == null)
                    return null;
                object rifamm = Conn.DO_SYS_CMD("select top 1 MK.riferimento_amministrazione from " +
                                                " mandatekind MK join mandatedetail MD on MD.idmankind=MK.idmankind " +
                                                " where " + q.CmpEq("MD.cigcode", cig), true);
                if (rifamm != null && rifamm.ToString().Trim() != "") {
                    if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                        return rifamm.ToString();
                    }
                }

                string p_iva = getP_IVACedentePrestatore(x);
                if (p_iva != null) {
                    if (p_iva.StartsWith("IT"))
                        p_iva = p_iva.Substring(2);
                    rifamm = Conn.DO_SYS_CMD(
                        "select top 1 R.sdi_defrifamm from registry R where p_iva  = " + q.quote(p_iva) +
                        " and sdi_defrifamm is not null", true);
                    if (rifamm != null && rifamm.ToString().Trim() != "") {
                        if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                            return rifamm.ToString();
                        }
                    }
                }

                string cf = getCodiceFiscaleCedentePrestatore(x);
                if (cf != null) {
                    rifamm = Conn.DO_SYS_CMD(
                        "select top 1 R.sdi_defrifamm from registry R where cf  = " + q.quote(cf) +
                        " and sdi_defrifamm is not null", true);
                    if (rifamm != null && rifamm.ToString().Trim() != "") {
                        if (Conn.RUN_SELECT_COUNT("sdi_rifamm", q.CmpEq("idsdi_rifamm", rifamm), false) == 1) {
                            return rifamm.ToString();
                        }
                    }
                }

                return null;
            }

            public static string getCodiceFiscaleCedentePrestatore(XmlDocument x) {
                string cf = getXmlText(x, "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/CodiceFiscale",
                    null);
                if (cf == "")
                    return null;
                return cf;
            }

            public static string getP_IVACedentePrestatore(XmlDocument x) {
                XmlNode IdFiscaleIVA =
                    x.SelectSingleNode("//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/IdFiscaleIVA");
                return IdFiscaleIVA["IdPaese"].InnerText + IdFiscaleIVA["IdCodice"].InnerText;
            }

            public bool getDataFromFoglioDiStile(XmlDocument x, string filenameOriginale) {
                if (x == null) return false;

                Chiave key = new Chiave("FOGLI_TRASFORMAZIONE", "2018", filenameOriginale);
                this.Chiave = key;
                this.TipologiaUnitaDocumentaria = "FOGLIO DI TRASFORMAZIONE";
                Configurazione config = new Configurazione("SOSTITUTIVA", "FALSE", "TRUE", "FALSE", "FALSE");
                this.Configurazione = config;
                this.idDocumento = filenameOriginale;
                ProfiloUnitaDocumentaria profiloUD = new ProfiloUnitaDocumentaria(
                    "Foglio di trasformazione relativo al documento Fattura, " +
                    "Acconto/ anticipo su fattura, Acconto/ anticipo su parcella e Parcella", "31/12/2018");

                this.ProfiloUD = profiloUD;
                Componente componente = new Componente("FDS_1", "1", "Contenuto", "File", null, filenameOriginale,
                    "xslt", null);
                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(componente);
                this.Componenti = strutturaoriginale;
                return true;
            }

            /// <summary>
            /// Per le fatture di acquisto:
            /// docid = 
            /// </summary>
            /// <param name="f"></param>
            public void getDataFromFatturaAcquisto(XmlDocument x, string filenameOriginale, DataAccess conn,
                string codipa, XmlDocument xLotto, string filenameOriginaleLotto) {
                getDataFromFatturaAcquisto(x, filenameOriginale, conn);
                // aggiunta di un annesso FATTURA ESTRATTA DAL LOTTO
                // (FATTURA ESTRATTA DAL LOTTO) che contiene la singola fattura estratta dal lotto 
                // (costituita dalla sezione FatturaElettronicaHeader del lotto e dalla sezione FatturaElettronicaBody della singola fattura).
                DataRow RFattura_Sdi = getFatturaAcquistoSDI(this.id_sdi, conn);
                string numeroLotto =
                    RFattura_Sdi["ninvoice"] == DBNull.Value ? "" : RFattura_Sdi["ninvoice"].ToString();
                object dataLotto = RFattura_Sdi["adate"] == DBNull.Value ? "" : RFattura_Sdi["adate"].ToString();
                DateTime dataLottodt = Convert.ToDateTime(dataLotto);
                int esercLotto = dataLottodt.Year;
                // Valorizzo documento collegato (la struttura originale è quella del lotto con riferimento al foglio di stile
                ChiaveCollegamento chiavecoll =
                    new ChiaveCollegamento("Sdi_Acquisto", esercLotto.ToString(), numeroLotto);
                DocumentoCollegato documentocoll = new DocumentoCollegato(chiavecoll, "Appartenenza a lotto");
                this.DocumentiCollegati.Add(documentocoll);
            }

            public void getDataFromFatturaAcquisto(XmlDocument x, string filenameOriginale, DataAccess conn) {
                /*
                  <xs:element type="xs:float" name="VersioneDatiSpecifici"/> 1.0
                  <xs:element type="xs:string" name="NumeroProtocollo"/>
                  <xs:element type="xs:date" name="DataProtocollo"/>
                  <xs:element type="xs:string" name="NumeroRUF"/>
                  <xs:element type="xs:date" name="DataRegistrazioneRUF"/>
                  <xs:element type="xs:string" name="NumeroEmissione"/>
                  <xs:element type="xs:date" name="DataEmissione"/>
                  <xs:element type="xs:string" name="DenominazioneMittente"/>
                  <xs:element type="xs:string" name="TipoDenominazioneMittente"/>
                  <xs:element type="xs:string" name="IdentificativoMittente"/>
                  <xs:element type="xs:string" name="TipoIdentificativoMittente"/>
                  <xs:element type="xs:string" name="OggettoFornitura"/>
                  <xs:element type="xs:string" name="ImportoTotale"/>
                  <xs:element type="xs:date" name="Scadenza"/>
                  <xs:element type="xs:string" name="RiferimentoContabile"/>
                  <xs:element type="xs:string" name="TipoRifContabile"/>
                  <xs:element type="xs:string" name="RilevanzaIVA"/>
                  <xs:element type="xs:string" name="CIG"/>
                 * */
                if (x == null) return;
                DataRow RFattura_Sdi = getFatturaAcquistoSDI(this.id_sdi, conn);
                if (RFattura_Sdi == null) return;
                XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
                XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
                string Denominazione = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
                string Nome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
                string Cognome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
                string numeroDocumento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
                string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale",
                    null);
                //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
                string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
                DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
                string Aliquota = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/AliquotaIVA",
                    null);
                string Natura = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/Natura",
                    null);
                string Imposta = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/Imposta",
                    null);
                string datascadenzapagamento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiPagamento/DataScadenzaPagamento",
                    null);
                /*
                 value="N1"  Escluse ex.art. 15		
                 value="N2"  Non soggette  
                 value="N3"  Non Imponibili 
                 value="N4"  Esenti  
                 value="N5"  Regime del margine 
                 value="N6"> Inversione contabile(reverse charge) 
                 value="N7" IVA assolta in altro stato UE(vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett.b, DL 331 / 93; 
                 prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7 - sexies lett.f, g, DPR 633 / 72 e art. 74 - sexies, DPR 633 / 72)
                 */
                string aliquotaivareversecharge = "";
                string ivatotalereversecharge = "";
                string rilevanzaiva = "";
                if ((Natura == "N1") || (Natura == "N2") || (Natura == "N3")) rilevanzaiva = "NO";
                else rilevanzaiva = "SI";
                if (Natura == "N6") {
                    aliquotaivareversecharge = Aliquota;
                    ivatotalereversecharge = Imposta;
                }

                string p_iva = getP_IVACedentePrestatore(x);
                string cf = getCodiceFiscaleCedentePrestatore(x);
                string versione = "1.0";

                string numeroprotocollo = RFattura_Sdi["arrivalprotocolnum"] == DBNull.Value
                    ? ""
                    : RFattura_Sdi["arrivalprotocolnum"].ToString();
                string dataprotocollo = RFattura_Sdi["protocoldate"] == DBNull.Value
                    ? ""
                    : RFattura_Sdi["protocoldate"].ToString();

                string numeroemissione = numeroDocumento;
                string dataemissione = sData;

                string scadenza = datascadenzapagamento;
                // Al momento non li compiliamo perchè non sono dati ricavabili dal file SDI
                string numeroruf = "";
                string dataregistrazioneruf = "";
                // Al momento non li compiliamo perchè non sono dati ricavabili dal file SDI
                string riferimentocontabile = "";
                string tiporifcontabile = "";

                string cig = getCig(x);
                string cup = getCig(x);
                string importototale = RFattura_Sdi["total"] == DBNull.Value ? "" : RFattura_Sdi["total"].ToString();
                ;
                string denommittente = "";
                string tipodenommittente = "";
                if (Denominazione != null) {
                    denommittente = Denominazione;
                    tipodenommittente = "RagioneSociale";
                }
                else {
                    denommittente = Nome + " " + Cognome;
                    tipodenommittente = "Nominativo";
                }

                string idmittente = "";
                string tipoidmittente = "";
                if (p_iva != null) {
                    idmittente = p_iva;
                    tipoidmittente = "PIVA";
                }
                else {
                    idmittente = cf;
                    tipoidmittente = "CF";
                }

                DatiSpecificiFatturaPassiva datiProfilo = new DatiSpecificiFatturaPassiva(versione, numeroprotocollo,
                    dataprotocollo, numeroruf, dataregistrazioneruf,
                    numeroemissione, dataemissione, denommittente, tipodenommittente, idmittente, tipoidmittente,
                    Causale, importototale, scadenza,
                    riferimentocontabile, tiporifcontabile, rilevanzaiva, aliquotaivareversecharge,
                    ivatotalereversecharge, cig, cup);
                this.DatiSpecificiPassiva = datiProfilo;
                this.TipologiaUnitaDocumentaria = "Fattura";

                string oggetto = Causale;
                ProfiloUnitaDocumentaria profiloUD = new ProfiloUnitaDocumentaria(Causale, sData);
                this.ProfiloUD = profiloUD;
                Configurazione config = new Configurazione("FISCALE", "true", "false", "true", "false");
                this.Configurazione = config;

                Chiave key = new Chiave("sdi_acquisto", dData.Year.ToString(), numeroemissione);
                this.Chiave = key;

                // Componenti, inserisco  solo la fattura con collegamento a foglio di stile,quest'ultimo  già trasmesso in precedenza (ne indico il riferimento come sottocomponente dell'annesso)
                string nomeFDiStile = "fatturapa_v1.1.xslt";

                Riferimento rif = new Riferimento("FOGLI_TRASFORMAZIONE", "2018", nomeFDiStile);
                SottoComponente fdstile = new SottoComponente(nomeFDiStile, "1", "Foglio di trasformazione",
                    "Riferimento", null, rif, "xslt");
                List<SottoComponente> listasottocomp = new List<SottoComponente>();
                listasottocomp.Add(fdstile);

                Componente comp = new Componente("FDS_1", "1", "Foglio di Trasformazione", "Riferimento",
                    "Trasformazione XML con XSLT", filenameOriginale, "xml", listasottocomp);

                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(comp);
                // Valorizzo annesso (la struttura originale è quella della fattura con riferimento al foglio di stile
                Annesso annesso = new Annesso(numeroDocumento + "_", this.TipologiaUnitaDocumentaria,
                    strutturaoriginale);
                this.Annessi.Add(annesso);
            }

            public void getDataFromLottoFattureVendita(XmlDocument x, string filenameOriginale, DataAccess conn) {
                DataRow RFattura_Sdi = getFatturaVenditaSDI(this.id_sdi, conn);
                string p_iva = getP_IVACedentePrestatore(x);
                string cf = getCodiceFiscaleCedentePrestatore(x);
                string aDateLotto = RFattura_Sdi["adate"] == DBNull.Value ? "" : RFattura_Sdi["adate"].ToString();
                ;
                DateTime sDateLotto = XmlConvert.ToDateTime(aDateLotto, XmlDateTimeSerializationMode.Unspecified);
                string importototale = RFattura_Sdi["total"] == DBNull.Value ? "" : RFattura_Sdi["total"].ToString();
                string numeroLotto =
                    RFattura_Sdi["ninvoice"] == DBNull.Value ? "" : RFattura_Sdi["ninvoice"].ToString();

                /*
                  < xs:element type="xs:float" name = "VersioneDatiSpecifici" />
                  < xs:element type="xs:string" name = "DenominazioneDestinatario" />
                  < xs:element type="xs:string" name = "TipoDenominazioneDestinatario" />
                  < xs:element type="xs:string" name = "IdentificativoDestinatario" 
                  < xs:element type="xs:string" name = "TipoIdentificativoDestinatario" />
                  < xs:element type="xs:string" name = "ImportoTotale" />
                  < xs:element type="xs:date" name = "ScadenzaFattura" />
                */
                XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
                XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");

                string Denominazione = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
                string Nome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
                string Cognome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);

                string denomdestinatario = "";
                string tipodenomdestinatario = "";
                if (Denominazione != null) {
                    denomdestinatario = Denominazione;
                    tipodenomdestinatario = "RagioneSociale";
                }
                else {
                    denomdestinatario = Nome + " " + Cognome;
                    tipodenomdestinatario = "Nominativo";
                }

                string iddestinatario = "";
                string tipoiddestinatario = "";
                if (p_iva != null) {
                    iddestinatario = p_iva;
                    tipoiddestinatario = "PIVA";
                }
                else {
                    iddestinatario = cf;
                    tipoiddestinatario = "CF";
                }

                Configurazione config = new Configurazione("FISCALE", "true", "false", "true", "false");
                this.Configurazione = config;

                Chiave key = new Chiave("LOTTI_FATTURE", sDateLotto.Year.ToString(), idDocumento);
                this.Chiave = key;

                string oggetto = "Lotto contenente " + xBody.Count.ToString() + " fatture - Destinatario " +
                                 denomdestinatario;
                ProfiloUnitaDocumentaria profiloUD = new ProfiloUnitaDocumentaria(oggetto, aDateLotto);

                // Ciclo sulle singole fatture del lotto
                int i;
                for (i = 1; i < xBody.Count; i++) {
                    string numeroDocumento = getXmlText(xBody[i],
                        "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
                    string sData = getXmlText(xBody[i],
                        "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
                    DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
                    string numeroemissione = numeroDocumento;
                    string dataemissione = sData;
                    ChiaveCollegamento chiave =
                        new ChiaveCollegamento("sdi_vendita", dData.Year.ToString(), numeroemissione);
                    DocumentoCollegato docCollegato = new DocumentoCollegato(chiave, "Appartenenza a Lotto");
                    this.DocumentiCollegati.Add(docCollegato);
                }

                string versionedatispecifici = "1.0";
                DatiSpecificiLottoFattureAttive datiSpecificiLotto =
                    new DatiSpecificiLottoFattureAttive(versionedatispecifici, denomdestinatario, tipodenomdestinatario,
                        iddestinatario, tipoiddestinatario);
                this.TipologiaUnitaDocumentaria = "LOTTO DI FATTURE";

                // Componenti, inserisco  solo il lotto con collegamento a foglio di stile,quest'ultimo  già trasmesso in precedenza (ne indico il riferimento come sottocomponente dell'annesso)
                string nomeFDiStile = "fatturapa_v1.1.xslt";

                Riferimento rif = new Riferimento("FOGLI_TRASFORMAZIONE", "2018", nomeFDiStile);
                SottoComponente fdstile = new SottoComponente(nomeFDiStile, "1", "Foglio di trasformazione",
                    "Riferimento", null, rif, "xslt");
                List<SottoComponente> listasottocomp = new List<SottoComponente>();
                listasottocomp.Add(fdstile);

                Componente comp = new Componente("FDS_1", "1", "Foglio di Trasformazione", "Riferimento",
                    "Trasformazione XML con XSLT", filenameOriginale, "xml", listasottocomp);

                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(comp);
                // Valorizzo annesso (la struttura originale è quella del lotto con riferimento al foglio di stile
                Annesso annesso = new Annesso(numeroLotto + "_", this.TipologiaUnitaDocumentaria, strutturaoriginale);
                this.Annessi.Add(annesso);


            }




            /// <summary>
            /// 
            /// </summary>
            /// <param name="xMess"></param>
            /// <param name="filenameOriginale"></param>
            /// <param name="conn">Connessione all'ENTE</param>
            /// <param name="codIpa"></param>
            /// <returns></returns>
            /// 
            public string getTipologiaDocumentariaMessaggio(XmlDocument xMess, string filenameOriginale,
                out string tipoMessaggio) {
                string tipologia = "";
                string[] nameParts = filenameOriginale.Split('_');

                if (!(nameParts.Length == 2)) {
                    tipoMessaggio = "";
                    return tipologia;
                }

                tipoMessaggio = nameParts[2].ToLower();

                //Si tratta di un messaggio. In genere dal tipoMessaggio si può evincere  di cosa si tratta

                switch (tipoMessaggio) {
                    case "ns": {
                        tipologia = "Notifica di scarto";
                        break;
                    }
                    case "mc": {
                        tipologia = "Notifica di mancata consegna";
                        break;
                    }
                    case "rc": {
                        tipologia = "Ricevuta di consegna";
                        break;
                    }
                    case "ne": {
                        tipologia = "Notifica di esito";
                        break;
                    }
                    case "at": {
                        tipologia = "Attestazione impossibilità di recapito";
                        break;
                    }
                    case "dt": {
                        tipologia = "Notifica di decorrenza dei termini";
                        break;
                    }
                    case "mt": {
                        tipologia = "Notifica di mancata  trasmissione";
                        break;
                    }
                    case "ec": {
                        tipologia = "Notifica di esito cedente";
                        break;
                    }
                    case "se": {
                        tipologia = "Notifica di scarto esito committente";
                        break;
                    }
                }

                return tipologia;
            }

            public string getFoglioDiStileMessaggio(string tipoMessaggio) {
                string foglioName = "";
                //Si tratta di un messaggio. In genere dal tipoMessaggio si può evincere  il nome foglio di stile

                switch (tipoMessaggio) {
                    case "ns": {
                        foglioName = "NS_v1.0.xslt"; // "Notifica di scarto";
                        break;
                    }
                    case "mc": {
                        foglioName = "MC_v1.0.xslt"; //  "Notifica di mancata consegna";
                        break;
                    }
                    case "rc": {
                        foglioName = "RC_v1.0.xslt"; // "Ricevuta di consegna";
                        break;
                    }
                    case "ne": {
                        foglioName = "NE_v1.0.xslt"; //  "Notifica di esito";
                        break;
                    }
                    case "at": {
                        foglioName = "AT_v1.1.xslt"; // "Attestazione impossibilità di recapito";
                        break;
                    }
                    case "dt": {
                        foglioName = "DT_v1.0.xslt"; // "Notifica di decorrenza dei termini";
                        break;
                    }
                    case "mt": {
                        foglioName = "MT_v1.0.xslt"; //  "Notifica di mancata  trasmissione";
                        break;
                    }
                    case "ec": {
                        foglioName = "EC_v1.0.xslt"; // "Notifica di esito cedente";
                        break;
                    }
                    case "se": {
                        foglioName = "SE_v1.0.xslt"; //  "Notifica di di scarto esito committente";
                        break;
                    }
                }

                return foglioName;
            }

            public bool getDataFromMessaggioFatturaAcquisto(XmlDocument xMess, string filenameOriginale,
                DataAccess conn, string codIpa = null) {
                XmlDocument x = getFatturaAcquisto(this.id_sdi, conn);
                DataRow RFattura_Sdi = getFatturaAcquistoSDI(this.id_sdi, conn);
                if (x == null)
                    return false;
                string numeroDocumento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
                string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
                DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
                this.identificativo_sdi = getXmlText(xMess, "//IdentificativoSdI", null);

                Chiave key = new Chiave("sdi_acquisto", dData.Year.ToString(), numeroDocumento);
                this.Chiave = key;
                string tipoMess;
                this.TipologiaUnitaDocumentaria =
                    getTipologiaDocumentariaMessaggio(xMess, filenameOriginale, out tipoMess);
                // Componenti, inserisco  solo il messaggio con collegamento a foglio di stile, già trasmesso in precedenza (sottocomponente dell'annesso)
                string nomeFDiStile = getFoglioDiStileMessaggio(tipoMess);

                Riferimento rif = new Riferimento("FOGLI_TRASFORMAZIONE", "2018", nomeFDiStile);
                SottoComponente fdstile = new SottoComponente(nomeFDiStile, "1", "Foglio di trasformazione",
                    "Riferimento", null, rif, "xslt");
                List<SottoComponente> listasottocomp = new List<SottoComponente>();
                listasottocomp.Add(fdstile);

                Componente messaggio = new Componente("FDS_1", "1", "Foglio di Trasformazione", "Riferimento",
                    "Trasformazione XML con XSLT", filenameOriginale, "xml", listasottocomp);

                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(messaggio);
                // Valorizzo annesso (la struttura originale è quella del messaggio con riferimento al foglio di stile
                Annesso annesso = new Annesso(numeroDocumento + "_" + tipoMess, this.TipologiaUnitaDocumentaria,
                    strutturaoriginale);
                this.Annessi.Add(annesso);
                return true;
            }

            public void getDataFromFatturaVendita(XmlDocument x, string filenameOriginale, DataAccess conn) {
                DataRow RFattura_Sdi = getFatturaVenditaSDI(this.id_sdi, conn);
                /*
                  < xs:element type="xs:float" name = "VersioneDatiSpecifici" />
                  < xs:element type="xs:string" name = "DenominazioneDestinatario" />
                  < xs:element type="xs:string" name = "TipoDenominazioneDestinatario" />
                  < xs:element type="xs:string" name = "IdentificativoDestinatario" 
                  < xs:element type="xs:string" name = "TipoIdentificativoDestinatario" />
                  < xs:element type="xs:string" name = "ImportoTotale" />
                  < xs:element type="xs:date" name = "ScadenzaFattura" />
                */
                XmlNode xHead = x.GetElementsByTagName("FatturaElettronicaHeader")[0];
                XmlNodeList xBody = x.GetElementsByTagName("FatturaElettronicaBody");
                string Denominazione = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Denominazione", null);
                string Nome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Nome", null);
                string Cognome = getXmlText(x,
                    "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/Anagrafica/Cognome", null);
                string numeroDocumento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
                string Causale = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale",
                    null);
                //string ddt = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiDDT/NumeroDDT", null);
                string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
                DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
                string Aliquota = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/AliquotaIVA",
                    null);
                string Natura = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/Natura",
                    null);
                string Imposta = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiBeniServizi/DatiRiepilogo/Imposta",
                    null);

                string p_iva = getP_IVACedentePrestatore(x);
                string cf = getCodiceFiscaleCedentePrestatore(x);
                string importototale = RFattura_Sdi["total"] == DBNull.Value ? "" : RFattura_Sdi["total"].ToString();
                ;
                string datascadenzapagamento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/DatiPagamento/DataScadenzaPagamento",
                    null);
                /*
                 value="N1"  Escluse ex.art. 15		
                 value="N2"  Non soggette  
                 value="N3"  Non Imponibili 
                 value="N4"  Esenti  
                 value="N5"  Regime del margine 
                 value="N6"> Inversione contabile(reverse charge) 
                 value="N7" IVA assolta in altro stato UE(vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett.b, DL 331 / 93; 
                 prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7 - sexies lett.f, g, DPR 633 / 72 e art. 74 - sexies, DPR 633 / 72)
                 */
                string aliquotaivareversecharge = "";
                string ivatotalereversecharge = "";

                if (Natura == "N6") {
                    aliquotaivareversecharge = Aliquota;
                    ivatotalereversecharge = Imposta;
                }

                string versione = "1.0";

                string numeroemissione = numeroDocumento;
                string dataemissione = sData;

                string scadenza = datascadenzapagamento;


                string cig = getCig(x);
                string denomdestinatario = "";
                string tipodenomdestinatario = "";
                if (Denominazione != null) {
                    denomdestinatario = Denominazione;
                    tipodenomdestinatario = "RagioneSociale";
                }
                else {
                    denomdestinatario = Nome + " " + Cognome;
                    tipodenomdestinatario = "Nominativo";
                }

                string iddestinatario = "";
                string tipoiddestinatario = "";
                if (p_iva != null) {
                    iddestinatario = p_iva;
                    tipoiddestinatario = "PIVA";
                }
                else {
                    iddestinatario = cf;
                    tipoiddestinatario = "CF";
                }

                DatiSpecificiFatturaAttiva datiProfilo = new DatiSpecificiFatturaAttiva(versione, denomdestinatario,
                    tipodenomdestinatario, iddestinatario, tipoiddestinatario,
                    importototale, scadenza, aliquotaivareversecharge, ivatotalereversecharge);
                this.DatiSpecificiAttiva = datiProfilo;
                this.TipologiaUnitaDocumentaria = "Fattura";

                string oggetto = Causale;
                ProfiloUnitaDocumentaria profiloUD = new ProfiloUnitaDocumentaria(Causale, sData);
                this.ProfiloUD = profiloUD;

                Chiave key = new Chiave("sdi_vendita", dData.Year.ToString(), numeroemissione);
                this.Chiave = key;
                // Componenti, inserisco  solo la fattura con collegamento a foglio di stile,quest'ultimo  già trasmesso in precedenza (ne indico il riferimento come sottocomponente dell'annesso)
                string nomeFDiStile = "fatturapa_v1.1.xslt";

                Riferimento rif = new Riferimento("FOGLI_TRASFORMAZIONE", "2018", nomeFDiStile);
                SottoComponente fdstile = new SottoComponente(nomeFDiStile, "1", "Foglio di trasformazione",
                    "Riferimento", null, rif, "xslt");
                List<SottoComponente> listasottocomp = new List<SottoComponente>();
                listasottocomp.Add(fdstile);
                Componente comp = new Componente("FDS_1", "1", "Foglio di Trasformazione", "Riferimento",
                    "Trasformazione XML con XSLT", filenameOriginale, "xml", listasottocomp);
                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(comp);
                // Valorizzo documento collegato
                Annesso annesso = new Annesso(numeroDocumento + "_", this.TipologiaUnitaDocumentaria,
                    strutturaoriginale);
                this.Annessi.Add(annesso);

            }

            public void getDataFromFatturaVendita(XmlDocument x, string filenameOriginale, DataAccess conn,
                string codipa, XmlDocument xLotto, string filenameOriginaleLotto) {
                getDataFromFatturaVendita(x, filenameOriginale, conn);
                // aggiunta di un annesso FATTURA ESTRATTA DAL LOTTO
                // (FATTURA ESTRATTA DAL LOTTO) che contiene la singola fattura estratta dal lotto 
                // (costituita dalla sezione FatturaElettronicaHeader del lotto e dalla sezione FatturaElettronicaBody della singola fattura).
                DataRow RFattura_Sdi = getFatturaVenditaSDI(this.id_sdi, conn);
                string numeroLotto =
                    RFattura_Sdi["ninvoice"] == DBNull.Value ? "" : RFattura_Sdi["ninvoice"].ToString();
                object dataLotto = RFattura_Sdi["adate"] == DBNull.Value ? "" : RFattura_Sdi["adate"].ToString();
                DateTime dataLottodt = Convert.ToDateTime(dataLotto);
                int esercLotto = dataLottodt.Year;
                // Valorizzo documento collegato 
                ChiaveCollegamento chiavecoll =
                    new ChiaveCollegamento("Sdi_Vendita", esercLotto.ToString(), numeroLotto);
                DocumentoCollegato documentocoll = new DocumentoCollegato(chiavecoll, "Appartenenza a lotto");
                this.DocumentiCollegati.Add(documentocoll);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="xMess"></param>
            /// <param name="filenameOriginale"></param>
            /// <param name="conn">Connessione all'ente</param>
            /// <param name="codIpa"></param>
            /// <returns></returns>
            public bool getDataFromMessaggioFatturaVendita(XmlDocument xMess, string filenameOriginale, DataAccess conn,
                string codIpa = null) {
                XmlDocument x = getFatturaVendita(this.id_sdi, conn);
                if (x == null) return false;
                DataRow RFattura_Sdi = getFatturaVenditaSDI(this.id_sdi, conn);
                string numeroDocumento = getXmlText(x,
                    "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero", null);
                string sData = getXmlText(x, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data", null);
                DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);

                Chiave key = new Chiave("sdi_vendita", dData.Year.ToString(), numeroDocumento);
                this.Chiave = key;
                string tipoMess;
                this.TipologiaUnitaDocumentaria =
                    getTipologiaDocumentariaMessaggio(xMess, filenameOriginale, out tipoMess);

                // Componenti, inserisco  solo il messaggio con collegamento a foglio di stile, già trasmesso in precedenza (ne indico il riferimento come sottocomponente dell'annesso)
                string nomeFDiStile = getFoglioDiStileMessaggio(tipoMess);

                Riferimento rif = new Riferimento("FOGLI_TRASFORMAZIONE", "2018", nomeFDiStile);
                SottoComponente fdstile = new SottoComponente(nomeFDiStile, "1", "Foglio di trasformazione",
                    "Riferimento", null, rif, "xslt");
                List<SottoComponente> listasottocomp = new List<SottoComponente>();
                listasottocomp.Add(fdstile);

                Componente messaggio = new Componente("FDS_1", "1", "Foglio di Trasformazione", "Riferimento",
                    "Trasformazione XML con XSLT", filenameOriginale, "xml", listasottocomp);

                List<Componente> strutturaoriginale = new List<Componente>();
                strutturaoriginale.Add(messaggio);
                // Valorizzo annesso (la struttura originale è quella del messaggio con riferimento al foglio di stile
                Annesso annesso = new Annesso(numeroDocumento + "_" + tipoMess, this.TipologiaUnitaDocumentaria,
                    strutturaoriginale);
                this.Annessi.Add(annesso);
                return true;
            }

            public static XmlDocument getFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "xml");
                if (o == null || o == DBNull.Value)
                    return null;
                XmlDocument x = new XmlDocument();
                x.LoadXml(o.ToString());
                return x;
            }


            public static object getDataEmissioneFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "adate");
                return o;
            }

            public static object getDataEmissioneFatturaVendita(int idsdi_vendita, DataAccess Conn) {

                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "adate");
                return o;
            }

            public static object getTotaleFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {

                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "total");
                return o;
            }

            public static object getTotaleFatturaVendita(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "total");
                return o;
            }


            public static DataRow getFatturaVenditaSDI(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                DataTable T = Conn.RUN_SELECT("sdi_vendita", "*", null, cond, null, false);
                if (T.Rows.Count > 0)
                    return T.Rows[0];
                else return null;
            }

            public static DataRow getFatturaAcquistoSDI(int idsdi_acquisto, DataAccess Conn) {

                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                DataTable T = Conn.RUN_SELECT("sdi_acquisto", "*", null, cond, null, false);
                if (T.Rows.Count > 0)
                    return T.Rows[0];
                else return null;
            }

            public static object getProtocolDateFatturaVendita(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "protocoldate");
                return o;
            }

            public static object getProtocolNumberFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {

                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "arrivalprotocolnum");
                return o;
            }

            public static object getProtocolNumberFatturaVendita(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "arrivalprotocolnum");
                return o;
            }

            public static object getProtocolTipoDocFatturaAcquisto(int idsdi_acquisto, DataAccess Conn) {

                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_acquisto", idsdi_acquisto);
                object o = Conn.DO_READ_VALUE("sdi_acquisto", cond, "tipodocumento");
                return o;
            }

            public static object getProtocolTipoDocFatturaVendita(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "tipodocumento");
                return o;
            }


            public static XmlDocument getFatturaVendita(int idsdi_vendita, DataAccess Conn) {
                QueryHelper Q = Conn.GetQueryHelper();
                string cond = Q.CmpEq("idsdi_vendita", idsdi_vendita);
                object o = Conn.DO_READ_VALUE("sdi_vendita", cond, "xml");
                if (o == null || o == DBNull.Value)
                    return null;
                XmlDocument x = new XmlDocument();
                x.LoadXml(o.ToString());
                return x;
            }
        }

        public class ArchiveData {
            public byte[] document;
            public string kind;
            public XmlDocument x;
            public string fNameOrig;
            public string identificativo_sdi;
            public int id_sdi;
        }



        public class PreserveArchive {
            // Unità documentaria UD
            List<PreserveFile> files = new List<PreserveFile>();

            public SdiLog logger = new sdiLog.SdiLog("PreserveUD");
            static PreserveArchive currArchive;

            public static void sendArchive(string nomeSupporto) {
                if (currArchive == null)
                    return;
                if (nomeSupporto.ToLowerInvariant().EndsWith(".zip")) {
                    //rimuove il .zip dal nome supporto
                    nomeSupporto = nomeSupporto.Substring(0, nomeSupporto.Length - 4);
                }

                currArchive.preparaConservazione(nomeSupporto);
            }



            public static PreserveArchive getArchive(bool clear, SdiLog logger) {
                if (clear) {
                    currArchive = null;
                }

                if (currArchive != null) {
                    currArchive.logger = logger;
                    return currArchive;
                }

                var sc = SdiConfigManager.getServiceConfig(sdiPassword.getPassword());
                if (sc == null)
                    return null;

                var c = sc.cfg.Rows[0];

                if (c.Table.Columns.Contains("cons_archivio") && c["cons_archivio"].ToString() != "") {
                    currArchive = new PreserveArchive {logger = logger};
                }

                return currArchive;
            }



            public static void conservaFatturaAcquisto(XmlDocument x, string filenameOriginale,
                string identificativo_sdi, int id_sdiacquisto, DataAccess ConnEnte, string codIpa = null) {
                if (currArchive == null) return;
                PreserveFile pf = new PreserveFile();
                pf.identificativo_sdi = identificativo_sdi;
                pf.id_sdi = id_sdiacquisto;
                pf.getDataFromFatturaAcquisto(x, filenameOriginale, ConnEnte);
                currArchive.files.Add(pf);

            }

            public static void conservaFatturaVendita(XmlDocument x, string filenameOriginale,
                string identificativo_sdi, int id_sdivendita, DataAccess conn, string codIpa = null) {
                if (currArchive == null) return;
                PreserveFile pf = new PreserveFile();
                pf.getDataFromFatturaVendita(x, filenameOriginale, conn);
                currArchive.files.Add(pf);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="x"></param>
            /// <param name="filenameOriginale"></param>
            /// <param name="idsdi_acquisto"></param>
            /// <param name="conn">CONNESSIONE ALL'ENTE</param>
            /// <param name="codIpa"></param>
            public static void conservaMessaggioFatturaAcquisto(XmlDocument x, string filenameOriginale,
                int idsdi_acquisto, DataAccess conn, string codIpa = null) {
                // Aggiunta posticipata annesso all'unità documentaria principale
                if (currArchive == null)
                    return;
                PreserveFile pf = new PreserveFile();
                if (!pf.getDataFromMessaggioFatturaAcquisto(x, filenameOriginale, conn, codIpa)) return;
                currArchive.files.Add(pf);
            }

            public static void conservaMessaggioFatturaVendita(XmlDocument x, string filenameOriginale,
                int idsdi_vendita, DataAccess conn, string codIpa = null) {
                // Aggiunta posticipata annesso all'unità documentaria principale
                if (currArchive == null)
                    return;
                PreserveFile pf = new PreserveFile();
                if (!pf.getDataFromMessaggioFatturaVendita(x, filenameOriginale, conn, codIpa)) return;
                currArchive.files.Add(pf);
            }

            public static void conservaLottoFatturaAcquisto(XmlDocument x, string filenameOriginale,
                int idsdi_acquisto, DataAccess conn, string codIpa = null) {
                // Aggiunta posticipata annesso all'unità documentaria principale
                if (currArchive == null)
                    return;
                PreserveFile pf = new PreserveFile();
                if (!pf.getDataFromMessaggioFatturaAcquisto(x, filenameOriginale, conn, codIpa)) return;
                currArchive.files.Add(pf);
            }

            public static void conservaLottoFatturaVendita(XmlDocument x, string filenameOriginale,
                int idsdi_vendita, DataAccess conn, string codIpa = null) {
                // Aggiunta posticipata annesso all'unità documentaria principale
                if (currArchive == null)
                    return;
                PreserveFile pf = new PreserveFile();
                if (!pf.getDataFromMessaggioFatturaVendita(x, filenameOriginale, conn, codIpa)) return;
                currArchive.files.Add(pf);
            }

            public byte[] getXml(string nomeSupporto, string docClass) {
                var settings = new XmlWriterSettings() {
                    Encoding = Encoding.UTF8,
                    CloseOutput = true,
                    Indent = true
                };

                byte[] result = null;
                using (var stream = new MemoryStream()) {
                    var writer = XmlWriter.Create(stream, settings);
                    writer.WriteStartDocument();

                    var root = new XElement("PDV");

                    var Xpdvid = new XElement("pdvid", nomeSupporto);
                    root.Add(Xpdvid);

                    // <docClass namespace="conservazione.docExt">803__Fattura_PA</docClass>
                    var XdocClass = new XElement("docClass", docClass);
                    // XdocClass.SetAttributeValue("namespace", namespaceEsterno());
                    root.Add(XdocClass);

                    var Xfiles = new XElement("files");
                    foreach (PreserveFile file in files) {
                        Xfiles.Add(file.getXml());
                    }

                    root.Add(Xfiles);

                    root.WriteTo(writer);
                    writer.Flush();

                    result = stream.ToArray();
                }

                return result;
            }

            static string localAppDataPath {
                get {
                    return Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Tempo Srl", "sdiftp");
                }
            }

            static string localAppDataPath_multi {
                get {
                    return Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "Tempo Srl", "sdiftp_multi");
                }
            }

            public bool preparaConservazione(string nomeSupporto) {
                if (files.Count == 0)
                    return false;

                serviceconfig s = SdiConfigManager.getServiceConfig();
                DataRow r = s.Tables["cfg"].Rows[0];

                if (r["cons_classedocumentale"].ToString() == "") {
                    logger.addWarn("Classe documentale non presente");
                    return false;
                }

                var docClass = r["cons_classedocumentale"].ToString();

                //Il nome cartella inizia con l'identificativo dell'archivio di destinazione del file. 
                if (r["cons_archivio"].ToString() == "") {
                    logger.addWarn("Nome archivio per conservazione non presente");
                    return false;
                }

                //   utti i documenti devono essere contenuti all'interno di un unico file compresso

                //  il nome del file compresso mandato in allegato indica al sistema il nome che il versante intende dare al PdA risultante
                // il file compresso lo assumo pari a nomeSupporto

                string cartella = string.Format("{0}#IPDV-{1}", r["cons_archivio"].ToString(), nomeSupporto);
                string localPath = localAppDataPath;
                if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
                if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
                string basePath = Path.Combine(localPath, cartella);
                if (File.Exists(basePath)) File.Delete(basePath);
                if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

                var FileExists = new Dictionary<string, bool>();
                //foreach (PreserveFile file in files) {
                //    if (FileExists.ContainsKey(file.fileName)) continue;
                //    FileExists[file.fileName] = true;

                //    string nomeFile = Path.Combine(basePath, file.fileName);
                //    FileStream S = new FileStream(nomeFile, FileMode.Create);
                //    S.Write(file.content, 0, file.content.Length);
                //    S.Close();
                //}

                string nomeFilePDV = string.Format("IPDV-{0}.xml", nomeSupporto);
                string pdvLocale = Path.Combine(basePath, nomeFilePDV);
                FileStream SPdv = new FileStream(pdvLocale, FileMode.Create);
                byte[] byteIPDV = getXml(nomeSupporto, docClass);
                SPdv.Write(byteIPDV, 0, byteIPDV.Length);
                SPdv.Close();

                return true;
            }

            /// <summary>
            /// ARCHIVIA dal supporto solo le fatture / messaggi relativi al codIpa
            ///  (è anche da capire come gestire i doppi invii messaggio DT su emissione fatture tra enti gestiti)
            /// </summary>
            /// <param name="nomeSupporto"></param>
            /// <param name="codIpa"></param>
            /// <returns></returns>
            //public bool preparaConservazione_multi(string nomeSupporto, string codIpa) {
            //	if (files.Count == 0)
            //		return false;

            //	serviceconfig s = SdiConfigManager.getMultiServiceConfig(codIpa);
            //	DataRow r = s.Tables["cfg"].Rows[0];

            //	if (r["cons_classedocumentale"].ToString() == "") {
            //		logger.addWarn("Classe documentale non presente");
            //		return false;
            //	}

            //	var docClass = r["cons_classedocumentale"].ToString();

            //	//Il nome cartella inizia con l'identificativo dell'archivio di destinazione del file. 
            //	if (r["cons_archivio"].ToString() == "") {
            //		logger.addWarn("Nome archivio per conservazione non presente");
            //		return false;
            //	}

            //	//I documenti da inviare in conservazione devono essere allegati alla PEC con le seguenti convenzioni:
            //	//   tutti i documenti devono essere contenuti all'interno di un unico file compresso

            //	//  il nome del file compresso mandato in allegato indica al sistema il nome che il versante intende dare al PdA risultante
            //	// il file compresso lo assumo pari a nomeSupporto

            //	string cartella = string.Format("{0}#{1}#IPDV-{2}", codIpa, r["cons_archivio"].ToString(), nomeSupporto);
            //	string localPath = localAppDataPath_multi;
            //	if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
            //	if (!Directory.Exists(localPath)) Directory.CreateDirectory(localPath);
            //	string basePath = Path.Combine(localPath, cartella);
            //	if (File.Exists(basePath)) File.Delete(basePath);
            //	if (!Directory.Exists(basePath)) Directory.CreateDirectory(basePath);

            //	var FileExists = new Dictionary<string, bool>();
            //	foreach (PreserveFile file in files) {
            //              if (file.codIpa != codIpa) continue;

            //              if (FileExists.ContainsKey(file.fileName)) continue;
            //		FileExists[file.fileName] = true;

            //		string nomeFile = Path.Combine(basePath, file.fileName);
            //		FileStream S = new FileStream(nomeFile, FileMode.Create);
            //		S.Write(file.content, 0, file.content.Length);
            //		S.Close();
            //	}

            //	string nomeFilePDV = string.Format("IPDV-{0}.xml", nomeSupporto);
            //	string pdvLocale = Path.Combine(basePath, nomeFilePDV);
            //	FileStream SPdv = new FileStream(pdvLocale, FileMode.Create);
            //	byte[] byteIPDV = getXml(nomeSupporto, docClass);
            //	SPdv.Write(byteIPDV, 0, byteIPDV.Length);
            //	SPdv.Close();

            //	return true;
            //}

            public static bool inviaConservazione(SdiLog logger) {
                string localPath = localAppDataPath;

                serviceconfig s = SdiConfigManager.getServiceConfig();
                DataRow r = s.Tables["cfg"].Rows[0];
                if (s.cfg.Columns.Contains("cons_localpath")) localPath = r["cons_localpath"].ToString();
                if (localPath == "") return true;

                IEnumerable<string> cartelle = Directory.EnumerateDirectories(localPath);
                if (!cartelle.Any())
                    return true; //non fa nulla se non ci sono cartelle (inutile connettersi all'ftp etc.)

                FtpCfgBase cfg = FtpFun.getCfgConservazione();
                ftpHelper fh = new ftpHelper(cfg, logger);
                bool res = fh.login();
                if (!res) {
                    logger.addErrorList(fh.errors);
                    return false;
                }

                // Carica tutto quello che trova nella cartella dati

                foreach (string cartella in cartelle) {
                    if (fh.UploadFolder(cartella, cfg.remote_dir)) {
                        Directory.Delete(cartella, true);
                    }
                }

                fh.logout();

                return true;
            }
        }



    }
}