/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿using System;
using System.Text;
using System.IO;            //Needs to be added
using System.Net;           //Needs to be added
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Collections.Generic;
using genericSerializer;
using funzioni_configurazione;
using metadatalibrary;

namespace pagoPaService {
    
    public class ValtellineseREST {
        private string endPoint { get; }
        
        private string user { get; }

        private string password { get; }

        //Default Constructor
        public ValtellineseREST(string urlRest, string user = null, string password = null) {

            endPoint = urlRest;            
            this.user = user;
            this.password = password;
        }

        public string GetEsitoAllineamentoPendenze(string idTrasmissione, out string error) {
            error = null;
            var wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));

            
            string addr = endPoint + "/allineamentopendenze/getEsito?idTrasmissione="+idTrasmissione;

            try {
                var responseData = wc.DownloadData(addr);
                return    UTF8Encoding.UTF8.GetString(responseData);
            }
            catch (Exception e) {
                error = e.ToString();
                return null;
            }

            ///allineamentopendenze/getEsito?idTrasmissione=<id_trasmissione>|FileRisposta
            return null;
        }


        public string inviaCrediti(string file, out string idTrasmissione) {

            var wc = new WebClient();
            idTrasmissione = null;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //NetworkCredential myCreds = new NetworkCredential(user, password);
            //wc.Credentials = myCreds;
            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));


            string addr = endPoint + "/allineamentopendenze/send";
            //wc.BaseAddress = "https://service.pmpay.it/";

            //var cred = new NetworkCredential(user, password);
            //cred.Domain = "https://service.pmpay.it/";
            //wc.Credentials = cred; 
            try {
                // Crea un file temporaneo
                string FilePath = AppDomain.CurrentDomain.BaseDirectory;

                string tempfilename = FilePath + "crediti.txt";

                using (StreamWriter sw = File.AppendText(tempfilename)) {
                    sw.Write(file);

                }
                var response = wc.UploadFile(addr, "POST", tempfilename);


                try {
                    System.IO.File.Delete(tempfilename);
                }
                catch { return "Errore nella cancellazione del file temporaneo " + tempfilename; }

                var ss = UTF8Encoding.UTF8.GetString(response);
                QueryCreator.MarkEvent("Ricevuto risposta:"+ss);
             
                var memStream = new MemoryStream(response);


                var xtr = new XmlTextReader(memStream) {
                    XmlResolver = null,
                    WhitespaceHandling = WhitespaceHandling.None
                };


                // get the root node
                xtr.Read();
                var esito = "";
                var errore = "";
                if ((xtr.NodeType == XmlNodeType.Element) && (xtr.Name == "PMPAY_AllineamentoPendenze")) {
                    while (xtr.Read()) {
                        if ((xtr.NodeType == XmlNodeType.Element) && (!xtr.IsEmptyElement)) {
                            var currentField = xtr.Name;
                            xtr.Read();
                            if (xtr.NodeType == XmlNodeType.Text) {
                                switch (currentField) {
                                    case "Id_Trasmissione":
                                        QueryCreator.MarkEvent("Ricevuto id trasmissione:"+xtr.Value);
                                        idTrasmissione = xtr.Value;
                                        break;
                                    case "Esito":
                                        esito = xtr.Value; 
                                        break;
                                    case "Errore":
                                        errore = xtr.Value;
                                        break;
                                }
                            }
                        }
                    }
                    return esito.ToUpper() == "OK" ? null : (errore??"Errore generico");
                }


                return "Risposta malformata";

            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                return ex.ToString();
            }


        }


        public RT GetRicevutaTelematica(string codiceAzienda, string iuv, out string errore) {
            errore = null;
            //9.GetRicevutaTelematica
            //Consente di  recuperare una singola ricevuta telematica a fronte di uno IUV e CREDITORE

            //La chiamata REST(con basic authentication) è:
            //< url_end_point_PMPAY >/ ricevutatelematica / get ? creditore =< creditore > &IUV =< IUV >| FileRisposta

            //L’operazione restituisce il file XML di ricevuta telematica come ricevuto da nodo SPC o messaggio di errore nel caso di operazione non andata a buon fine

            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
 
            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));


            string addr = endPoint + "/ricevutatelematica/get?creditore=" + codiceAzienda + "&IUV =" + iuv;

            try {
                var response = wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Controllare se XML oppure generica stringa errore

                try {
                    XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                XmlElement elem = xmlDoc.GetElementById("RT");
                if (elem != null) {
                    RT ricevuta = new RT();
                    ricevuta = GenericSerializer.fromXml<RT>(xmlDoc.ToString());
                    return ricevuta;
                }
                else errore = xmlDoc.ToString();
            }
                catch (Exception ex) {
                    // Lettura della stringa di errore
                    StreamReader sr = new StreamReader(memStream);
                    long pos = memStream.Position;
                    memStream.Position = 0;

                    string data = sr.ReadToEnd(); 
                        errore = data;

                }
            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore= ex.ToString();
                
            }
            return null;

        }

        public FlussoRiversamento
            GetRendicontazione(string codiceAzienda, string id_Rendicontazione, out string errore) {
            errore = null;
            //La chiamata REST(con basic authentication) è:
            //< url_end_point_PMPAY >/ rendicontazioni / get ? idTrasmissione =< ID_RESTITUITO_DA_OPERAZIONE 12 >| FileRisposta
            //L’operazione restituisce il file XML di rendicontazione come ricevuto da nodo SPC o messaggio di errore nel caso di operazione non andata a buon fine.

            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
            string addr = endPoint + "/rendicontazioni/get?idTrasmissione=" + id_Rendicontazione;

            try {
                var response = wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Controllare se XML oppure generica stringa errore

                try {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(memStream);
                    //XmlElement xmlDoc = xmlDoc.GetElementById("identificativoFlusso");
                    if (xmlDoc.InnerXml.ToString().Contains("identificativoFlusso")) {
                        memStream.Position = 0;

                        var serializer = new XmlSerializer(typeof(FlussoRiversamento));
                        var reader = XmlReader.Create(memStream);
                        try {
                            var rendiconto = (FlussoRiversamento) serializer.Deserialize(reader);
                            return rendiconto;
                        }
                        catch (Exception ex) {
                            //var ricevuta = new FlussoRiversamento();
                            //errore = ex.ToString();
                            //rendiconto.codiceBicBancaDiRiversamento = "123";
                            //rendiconto.dataOraFlusso = DateTime.Now;
                            //rendiconto.identificativoFlusso = "12345";
                            //rendiconto = GenericSerializer.toXml<FlussoRiversamento>(ricevuta);
                            errore = ex.ToString();
                        }
                    }
                    else {
                        errore = xmlDoc.ToString();
                    }
                }
                catch (Exception ex) {
                    // Lettura della stringa di errore
                    StreamReader sr = new StreamReader(memStream);
                    long pos = memStream.Position;
                    memStream.Position = 0;

                    string data = sr.ReadToEnd();
                    errore = data;

                }
            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore = ex.ToString();

            }

            return null;

        }


        public allineamentopendenze GetInformativaPagamentoRendicontati(string idTrasmissione, out string errore) {
            errore = null;
            // Consente di  recuperare i pagamenti effettuati sulla piattaforma PMPAY , per i quali vi è
            //una rendicontazione, che devono essere aggiornate su app Client a copertura delle partite aperte.
            //La chiamata REST(con basic authentication) è:
            //< url_end_point_PMPAY >/ informativapagamentirendicontati / get ? idTrasmissione =< id_trasmissione >| FileRisposta
            //Il parametro idTrasmissione è l'id della trasmissione che identifica il flusso di pagamenti da scaricare 
            //sul sistema Client (è il campo IdTrasmissione del file xml ritornato dal metodo  informativapagamentirendicontati /list del punto precedente.
            //Il FileRisposta è un file in formato CSV  con codifica UTF - 8.
            //Ogni linea è costituita da 21 campi delimitati dal carattere '|'(pipe) e il formato è lo stesso formato CSV di SendAllineamentoPendenze utilizzato per inviare le pendenze.
            CultureInfo MyCultureInfo = new CultureInfo("en-US");

             var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));


            string addr = endPoint + "/informativapagamentirendicontati/get?idTrasmissione=" + idTrasmissione;

            try {
                var response = wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Controllare se CSV oppure generica stringa errore

     
                    string[] read;
                    char[] seperators = { '|' };


                    StreamReader sr = new StreamReader(memStream);

                    string data = "";

                    while ((data = sr.ReadLine()) != null) {
                        if (!data.Contains("|")) {
                            errore = data;
                            return null;
                        }
                        if (data.Contains("CREDITORE")) continue; // si tratta della riga di intestazione del file CSV
                                    /*
                      * <xs:element name="CREDITORE" type="xs:string"/>
                        <xs:element name="CODICE_PARTITARIO " type="xs:string"/>
                        <xs:element name="DEBITORE" type="xs:string"/>
                        <xs:element name="ID_DEBITO" type="xs:string"/>
                        <xs:element name="ID_PAGAMENTO" type="xs:string"/>
                        <xs:element name="DATA_SCADENZA " type="xs:date" minOccurs="0"/>
                        <xs:element name="DATA_INIZIO_VALIDITA" type="xs:date" minOccurs="0"/>
                        <xs:element name="DATA_FINE_VALIDITA" type="xs:date" minOccurs="0"/>
                        <xs:element name="CAUSALE_PAGAMENTO" type="xs:string" minOccurs="0"/>
                        <xs:element name="STATO_PAGAMENTO" type="xs:string"/>
                        <xs:element name="IMPORTO_PAGAMENTO" type="xs:decimal"/>
                        <xs:element name="VOCI_PAGAMENTO" type="xs:string" minOccurs="0"/>
                        <xs:element name="ANNO_RIFERIMENTO" type="xs:string" minOccurs="0"/>
                        <xs:element name="NOTE_DEBITO" type="xs:string" minOccurs="0"/>
                        <xs:element name="CAUSALE_DEBITO" type="xs:string" minOccurs="0"/>
                        <xs:element name="IMPORTO_PAGATO" type="xs:decimal" minOccurs="0"/>
                        <xs:element name="DATA_VALUTA_ACCREDITO" type="xs:date" minOccurs="0"/>
                        <xs:element name="CANALE_PAGAMENTO" type="xs:string" minOccurs="0"/>
                        <xs:element name="DATA_PAGAMENTO" type="xs:dateTime" minOccurs="0"/>
                        <xs:element name="NOTE_PAGAMENTO" type="xs:string" minOccurs="0"/>
                        <xs:element name="PAGATO_PIATTAFORMA" type="xs:string" minOccurs="0"/>

                       * */
                        read = data.Split(seperators, StringSplitOptions.None);
                        string creditore = read[0];
                        string codice_partitario = read[1];
                        string debitore = read[2];
                        string id_debito = read[3];
                        string id_pagamento = read[4];
                        string data_scadenza = read[5];
                        string data_inizio_validita = read[6];
                        string datafine_validita = read[7];
                        string causale_pagamento = read[8];
                        string stato_pagamento = read[9];
                        string importo_pagamento = read[10];
                        string voci_pagamento = read[11];
                        string anno_riferimento = read[12];
                        string note_debito = read[13];
                        string causale_debito = read[14];
                        string importo_pagato = read[15];
                        string data_valuta_accredito = read[16];
                        string canale_pagamento = read[17];
                        string data_pagamento = read[18];
                        string note_pagamento = read[19];
                        string pagato_piattaforma = read[20];

                        // conversione CSV letto nel tipo  allineamentopendenze 
                        allineamentopendenze informativaResponse = new allineamentopendenze();
                        informativaResponse.ANNO_RIFERIMENTO =  CfgFn.GetNoNullInt32(anno_riferimento);
                        informativaResponse.CREDITORE = creditore;
                        informativaResponse.CODICE_PARTITARIO = codice_partitario;
                        informativaResponse.DEBITORE =debitore;
                        informativaResponse.ID_DEBITO = id_debito;
                        informativaResponse.DATA_SCADENZA = DateTime.Parse(data_scadenza,MyCultureInfo);
                        informativaResponse.DATA_INIZIO_VALIDITA = DateTime.Parse(data_inizio_validita, MyCultureInfo);
                        informativaResponse.DATA_FINE_VALIDITA = DateTime.Parse(datafine_validita, MyCultureInfo);
                        informativaResponse.CAUSALE_PAGAMENTO = causale_pagamento;
                        informativaResponse.STATO_PAGAMENTO = stato_pagamento;
                        informativaResponse.IMPORTO_PAGAMENTO = CfgFn.GetNoNullDecimal(importo_pagamento);
                        informativaResponse.VOCI_PAGAMENTO = voci_pagamento;
                        informativaResponse.NOTE_DEBITO = note_debito;
                        informativaResponse.CAUSALE_DEBITO = causale_debito;
                        informativaResponse.IMPORTO_PAGATO = CfgFn.GetNoNullDecimal(importo_pagato);
                        informativaResponse.DATA_VALUTA_ACCREDITO = DateTime.Parse(data_valuta_accredito, MyCultureInfo); ;
                        informativaResponse.CANALE_PAGAMENTO = canale_pagamento;
                        informativaResponse.NOTE_PAGAMENTO = note_pagamento;
                        informativaResponse.PAGATO_PIATTAFORMA = pagato_piattaforma;
                        return informativaResponse;
                }

                }
                catch (Exception ex) {
                    //We catch non Http 200 responses here.
                    errore = ex.ToString();
                }

            return null;

        }

        public List<string> GetRicevuteTelematiche(string codiceAzienda, out string errore) {
            // questo metodo restituisce una lista di IUV, di cui richiedere le ricevute telematiche singole
            List<string> listIUV = new List<string>();
            errore = "";
            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
 
            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
           
            // < url_end_point_PMPAY >/ ricevutetelematiche / get ? creditore =< CODICE_ENTE_CREDITORE >| FileRisposta
            string addr = endPoint + "/ricevutetelematiche/get?creditore=" + codiceAzienda;
            
            try {

                var response =
                    wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Il metodo potrebbe restituire o un file CSV oppure una stringa di errore
                // CREDITORE | IDENTIFICATIVO_PAGAMENTO(IUV),

                string[] read;
                char[] seperators = { '|' };

              
                StreamReader sr = new StreamReader(memStream);

                string data = "";

                while ((data = sr.ReadLine()) != null) {
                    if (!data.Contains("|")) { 
                        errore = data;
                        return listIUV;
                    }
                    if (data.Contains("CREDITORE")) continue; // si tratta della riga di intestazione del file CSV

                    read = data.Split(seperators, StringSplitOptions.None);
                    string creditore =  read[0];
                    string iuv = read[1];
                    listIUV.Add(iuv);
                }
 
            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore= ex.ToString();
            }
            return listIUV;

        }


        public List<string> GetElencoInformativePagamentiRendicontati(string codiceAzienda, out string errore) {
            //Consente di  recuperare la lista delle trasmissioni di informative pagamenti presenti su PMPAY , per i quali è stata ricevuta rendicontazione.
            //La chiamata REST(con basic authentication) è:
            //< url_end_point_PMPAY >/ informativapagamentirendicontati / list ? CFDebitore =< cf del debitore > &creditore =< CODICE_ENTE_CREDITORE >| FileRisposta

            //Il FileRisposta è un file in formato XML.
            //< InformativaPagamentiList >

            //    < InformativaPagamenti >

            //        < IdTrasmissione > Id_Trasmissione </ IdTrasmissione >

            //        < Creditore > COMUNE DI FRITTOLE</ Creditore >
   
            //           < Esito > true </ Esito >
   
            //       </ InformativaPagamenti >
            //   </ InformativaPagamentiList >

            //La funzione prende in esame i pagamenti ESEGUITI con successo, per i quali vi è una rendicontazione, che non sono ancora stati presi in considerazione da una richiesta GetElencoInformativePagamentiRendicontati(dello stesso tipo dove la discriminante del tipo è la presenza o meno di cfdebitore), raggruppati per ente.
            //Verranno presi in considerazione solamente gli enti per i quali effettivamente sono presenti pagamenti che corrispondano al criterio di estrazione.
            //Se viene fornito in ingresso il parametro opzionale CFDebitore la ricerca riguarda solamente le pratiche associate al debitore indicato.
            //Il parametro in ingresso creditore che limita la ricerca ad un determinato ente è facoltativo.

            List<string> listId_Trasmissione = new List<string>();
            errore = "";
            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));

            // < url_end_point_PMPAY >/ informativapagamentirendicontati / list ? creditore =< CODICE_ENTE_CREDITORE >| FileRisposta
            string addr = endPoint + "/informativapagamentirendicontati/list?creditore=" + codiceAzienda;

            try {

                var response =
                    wc.DownloadData(new Uri(addr));
                var memStream = new MemoryStream(response);
                // Il metodo potrebbe restituire o un file XML oppure una stringa di errore
                //  


                var xtr = new XmlTextReader(memStream) {
                    XmlResolver = null,
                    WhitespaceHandling = WhitespaceHandling.None
                };


                // get the root node
                xtr.Read();
                var esito = "";
      
                if ((xtr.NodeType == XmlNodeType.Element) && (xtr.Name == "InformativaPagamentiList")) {
                    while (xtr.Read()) {
                        if ((xtr.NodeType == XmlNodeType.Element) && (!xtr.IsEmptyElement)) {
                            var currentField = xtr.Name;
                            xtr.Read();
                            if (xtr.NodeType == XmlNodeType.Text) {
                                switch (currentField) {
                                    case "IdTrasmissione":
                                        listId_Trasmissione.Add(xtr.Value);
                                        break;
                                    case "Errore":
                                        errore = xtr.Value;
                                        break;
                                }
                            }
                        }
                    }
                    return listId_Trasmissione;
                }


            }
            catch (Exception ex) {
                //We catch non Http 200 responses here.
                errore = ex.ToString();
            }
            return listId_Trasmissione;

        }
        public List<string> GetElencoRendicontazioni(DateTime start, DateTime stop, string codiceAzienda, out string errore) {
            //La chiamata REST(con basic authentication) è:
            //< url_end_point_PMPAY >/ rendicontazioni / list ? parametri descritti nella sezione Input | FileRisposta

            //La funzione consente di recuperare una lista di identificativi rappresentanti le rendicontazioni presenti in archivio che rispettano i criteri di filtro.
            // http://www.agid.gov.it/sites/default/files/linee_guida/specifiche_attuative_pagamenti_1_3_1.pdf a pagina 26 parla del flusso rendicontazione
            List<string> listId_Rendicontazione = new List<string>();
            errore = "";
            var wc = new WebClient();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            wc.Headers.Add(HttpRequestHeader.Authorization,
                "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));

            DateTime inizioperiodo = new DateTime();
            DateTime fineperiodoprecedente = new DateTime();

            List<DateTime> dateinizio  = new List<DateTime>();
            List<DateTime> datefine = new List<DateTime>();
         
            for (DateTime d = start;
                    d <= stop; // 
                    d = d.AddMonths(1)) {
                    inizioperiodo = d;
                    fineperiodoprecedente = d.AddDays(-1);
                    dateinizio.Add(inizioperiodo);
                    if ((fineperiodoprecedente< stop) && (fineperiodoprecedente>start))
                        datefine.Add(fineperiodoprecedente);
                  
            }
            datefine.Add(stop);
            //POST /Rest/rendicontazioni/list HTTP/1.1
            //idTrasmissione = &CFDebitore = &creditore = &IUV = &dataDa = 01052018 & dataA = 22052018
            // GET / Rest / rendicontazioni / list ? dataDa % 20 =% 2001012018 % 20 & dataA % 20 =% 2031012018 & creditore = CRE14 HTTP / 1.1
            for (int i = 0 ; i<= dateinizio.Count-1; i++) {
                string dataDa = dateinizio[i].Day.ToString("00") + dateinizio[i].Month.ToString("00") + dateinizio[i].Year.ToString("0000");
                string dataA = datefine[i].Day.ToString("00") + datefine[i].Month.ToString("00") + datefine[i].Year.ToString("0000");
                string addr = endPoint + "/rendicontazioni/list?dataDa=" + dataDa +  "&dataA=" + dataA + "&creditore=" + codiceAzienda;
                try {

                    var response =
                        wc.DownloadData(new Uri(addr));
                    var memStream = new MemoryStream(response);
                    // Il metodo potrebbe restituire o un file CSV oppure una stringa di errore
                    // CREDITORE | ID_RENDICONTAZIONE,

                    string[] read;
                    char[] seperators = { '|' };
                    StreamReader sr = new StreamReader(memStream);

                    string data = "";

                    while ((data = sr.ReadLine()) != null) {
                        if (!data.Contains("|")) {
                            errore = data;
                            continue;
                        }
                        if (data.Contains("ID_DEBITO")) continue; // si tratta della riga di intestazione del file CSV

                        read = data.Split(seperators, StringSplitOptions.None);
                        string creditore = read[0];
                        string id_rendicontazione = read[1];
                        listId_Rendicontazione.Add(id_rendicontazione);
                    }

                }
                catch (Exception ex) {
                    //We catch non Http 200 responses here.
                    errore = ex.ToString();
                }
            }

            return listId_Rendicontazione;

        }


    }

}

