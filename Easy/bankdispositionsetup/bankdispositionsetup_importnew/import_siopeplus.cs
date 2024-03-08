
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Text;
using System.Windows;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;
using funzioni_configurazione;
using System.Drawing;
using System.ComponentModel;

namespace bankdispositionsetup_importnew {


    class import_siopeplus {

        public static DatiImportati ImportaFile(DataAccess Conn, Stream file, out string idbank) {
            XmlDocument X = new XmlDocument();
            idbank = null;
            file.Seek(0, SeekOrigin.Begin);
            try {
                X.Load(file);
            }
            catch (Exception e2) {
                QueryCreator.ShowException(null, "Errore durante l'apertura del file selezionato!", e2);
                return null;
            }

            try {
                return ElaboraXml(X, Conn, out idbank);
            }
            catch (Exception e){
                string errore = e.Message + " " + e.ToString();
                QueryCreator.ShowException(null, "Errore!", e);
            }
            return null;

        }
        public static DatiImportati ImportaFileManuale(DataAccess Conn, string fname, out string idbank) {
            XmlDocument X = new XmlDocument();
            idbank = null;
            try {
                X.Load(fname);
            }
            catch (Exception e2) {
                QueryCreator.ShowException(null, "Errore durante l'apertura del file selezionato!", e2);
                return null;
            }

            try {
                return ElaboraXml(X, Conn, out idbank);
            }
            catch (Exception e) {
                string errore = e.Message + " " + e.ToString();
                QueryCreator.ShowException(null, "Errore durante l'elaborazione del file selezionato!", e);
            }
            return null;

        }

        static string getXmlText(XmlNode x, string xpath) {
            try {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch (Exception e) {
                string errore = e.Message + " " + e.ToString();
            }
            return null;
        }

        public static DatiImportati ElaboraXml(XmlDocument Xdoc, DataAccess Conn, out string idbank) {
            DatiImportati M = new DatiImportati(Conn.GetEsercizio());
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Treasurer = Conn.RUN_SELECT("treasurer", "idtreasurer,trasmcode", null,
            QHS.AppAnd(QHS.IsNotNull("trasmcode"), QHS.NullOrEq("active", "S")), null, false);
            List<string> CodiciCassiere = new List<string>();
            foreach (DataRow R in Treasurer.Select()) {
                CodiciCassiere.Add(R["trasmcode"].ToString().ToUpper() + " ");
            }

            int NOp =
                Xdoc.SelectNodes("/flusso_giornale_di_cassa/informazioni_conto_evidenza/movimento_conto_evidenza").Count;
            //Xdoc.SelectNodes("/flusso_giornale_di_cassa/testata_messaggio/codice_ABI_BT").Inn;
            idbank = getXmlText(Xdoc, "//flusso_giornale_di_cassa/testata_messaggio/codice_ABI_BT");
            M.idbank = idbank;
            M.identificativo_flusso_BT = getXmlText(Xdoc, "//flusso_giornale_di_cassa/identificativo_flusso_BT");
            //Scorre l'elenco dei flussi (forse superfluo)
            XmlNodeList ElencoFlussi = Xdoc.SelectNodes("/flusso_giornale_di_cassa");
            foreach (XmlNode XFlusso in ElencoFlussi) {
                int esercizio = CfgFn.GetNoNullInt32(XFlusso["esercizio"].InnerText);
                M.esercizioflusso = CfgFn.GetNoNullInt32(XFlusso["esercizio"].InnerText);
                string data_riferimento_GdC = XFlusso["data_riferimento_GdC"].InnerText;
                

                foreach (XmlNode Xinfo_conto_evidenza in XFlusso.SelectNodes("informazioni_conto_evidenza")) {
                    string conto_evidenza = Xinfo_conto_evidenza["conto_evidenza"].InnerText;
                    foreach (
                        XmlNode Xmovimento_conto_evidenza in
                            Xinfo_conto_evidenza.SelectNodes("movimento_conto_evidenza")) {

                        // "REVERSALE"   "MANDATO"   "SOSPESO ENTRATA"   "SOSPESO USCITA"
                        string tipo_documento = Xmovimento_conto_evidenza["tipo_documento"].InnerText;
                        string tipo_operazione = Xmovimento_conto_evidenza["tipo_operazione"].InnerText;
                        string numero_movimento = Xmovimento_conto_evidenza["numero_movimento"].InnerText;

                        if (tipo_documento == "MANDATO") {
                             List<RigaMandato>righeMandati = CreaRigaMandato(Xmovimento_conto_evidenza, esercizio);
                             foreach ( RigaMandato R in  righeMandati){
                                       M.Mandati.Add(R);
                             }
                        }
                        if (tipo_documento == "REVERSALE") {
                             List<RigaReversale>righeReversali = CreaRigaReversale(Xmovimento_conto_evidenza, esercizio);
                             foreach ( RigaReversale R in  righeReversali){
                                       M.Reversali.Add(R);
                             }
                        }

                        if (tipo_documento == "SOSPESO ENTRATA" &&
                            (tipo_operazione == "ESEGUITO" ||tipo_operazione == "STORNATO")) {
                            //M.BolletteEntrata.Add(CreaSospesoEntrata(Xmovimento_conto_evidenza, esercizio,
                            //    CodiciCassiere));
                            M.BolletteEntrata.Add(CreaSospesoEntrata(Xmovimento_conto_evidenza, conto_evidenza, esercizio, CodiciCassiere));
                        }

                        if (tipo_documento == "SOSPESO USCITA" &&
                            (tipo_operazione == "ESEGUITO" || tipo_operazione == "STORNATO")) {
                            M.BolletteSpesa.Add(CreaSospesoUscita(Xmovimento_conto_evidenza, conto_evidenza, esercizio, CodiciCassiere));
                        }

                        if (tipo_documento == "REVERSALE") {
                            List<EsitoProvvisorio> esitiProvvisorio = CreaEsitoSospesoEntrata(Xmovimento_conto_evidenza, esercizio,CodiciCassiere);

                             foreach ( EsitoProvvisorio esito in  esitiProvvisorio){
                                       M.EsitiBolletteEntrata.Add(esito);
                             }
 
                        }
                        if (tipo_documento == "MANDATO") {
                            List<EsitoProvvisorio> esitiProvvisorio = CreaEsitoSospesoUscita(Xmovimento_conto_evidenza, esercizio,CodiciCassiere);
                            foreach ( EsitoProvvisorio esito in  esitiProvvisorio){
                                       M.EsitiBolletteSpesa.Add(esito);
                             }
                        }

                    }
                }
            }
            return M;
        }

        static List<RigaMandato> CreaRigaMandato(XmlNode X, int esercizio) {
            List<RigaMandato> RigheMandato = new List<RigaMandato>(); 
            XmlNode Xreg = X.SelectSingleNode("cliente");
            string tipo_operazione = X["tipo_operazione"].InnerText;
            XmlNodeList sospesi = X.SelectNodes("sospeso");
            decimal importo = XmlHelper.AsDecimal(X, "importo");
            if ((tipo_operazione == "STORNATO") && (importo > 0)) {
                importo = -importo;
            }

            if ((sospesi==null) || (sospesi.Count==0))
                {
                    RigaMandato R = new RigaMandato(esercizio,
                        XmlHelper.AsInt(X, "numero_documento"),
                        importo,
                        XmlHelper.AsDate(X, "data_movimento"),
                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                        XmlHelper.AsString(X, "causale"),
                        DBNull.Value,
                        XmlHelper.AsInt(X, "progressivo_documento")
                        );
                    foreach (string field in new string[] { "coordinate", "causale" }) {
                        if (X[field] == null) continue;
                        R.Set(field, X[field].InnerText);
                    }

                    foreach (
                            string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                            if (Xreg[field] == null) continue;
                            R.Set(field, Xreg[field].InnerText);
                    }
                    RigheMandato.Add(R);
             }
            else
                 {
                        foreach (XmlNode sospeso in sospesi) {
                                object numero_provvisorio = XmlHelper.AsOptionalInt(sospeso, "numero_provvisorio");
                                Decimal importo_provvisorio = XmlHelper.AsDecimal(sospeso, "importo_provvisorio");
                                if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;


                                if (numero_provvisorio == DBNull.Value  && tipo_operazione == "STORNATO" ) {
                                    numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
                                }
                                if (numero_provvisorio == DBNull.Value && tipo_operazione == "RIPRISTINATO") {
                                    numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza");
                                }
                                if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;
                                if (numero_provvisorio == DBNull.Value) return null;
            
                                if ((tipo_operazione == "STORNATO" ||tipo_operazione == "RIPRISTINATO") && importo_provvisorio > 0) {
                                    importo_provvisorio = -importo_provvisorio;
                                }

                                RigaMandato R = new RigaMandato(esercizio,
                                    XmlHelper.AsInt(X, "numero_documento"),
                                    importo_provvisorio,
                                    XmlHelper.AsDate(X, "data_movimento"),
                                    XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                    XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                    XmlHelper.AsString(X, "causale"),
                                    numero_provvisorio,
                                    XmlHelper.AsInt(X, "progressivo_documento")
                                    );
                                foreach (string field in new string[] { "coordinate", "causale" }) {
                                    if (X[field] == null) continue;
                                    R.Set(field, X[field].InnerText);
                                }

                        if (numero_provvisorio != DBNull.Value) R.Set("numero_sospeso", numero_provvisorio.ToString());

                        foreach (
                            string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                            if (Xreg[field] == null) continue;
                            R.Set(field, Xreg[field].InnerText);
                        }
            	        RigheMandato.Add(R);
                        }
            }
            return RigheMandato;
        }

        static List<RigaReversale> CreaRigaReversale(XmlNode X, int esercizio) {

			List<RigaReversale> RigheReversale = new List<RigaReversale>(); 
            XmlNode Xreg = X.SelectSingleNode("cliente");
            string tipo_operazione = X["tipo_operazione"].InnerText;
            decimal importo = XmlHelper.AsDecimal(X, "importo");
            XmlNodeList sospesi = X.SelectNodes("sospeso");
            if ((tipo_operazione == "STORNATO") && (importo > 0)) {
                importo = -importo;
            }

            if ((sospesi==null) || (sospesi.Count==0))
                {
                    RigaReversale R = new RigaReversale(esercizio,
                        XmlHelper.AsInt(X, "numero_documento"),
                        importo,
                        XmlHelper.AsDate(X, "data_movimento"),
                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                        XmlHelper.AsString(X, "causale"),
                        DBNull.Value,
                        XmlHelper.AsInt(X, "progressivo_documento")
                        );
                    foreach (string field in new string[] { "coordinate", "causale" }) {
                        if (X[field] == null) continue;
                        R.Set(field, X[field].InnerText);
                    }

                    foreach (
                            string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                            if (Xreg[field] == null) continue;
                            R.Set(field, Xreg[field].InnerText);
                    }
                    RigheReversale.Add(R);
            }
            else
                 {
                    foreach (XmlNode sospeso in sospesi) {
                            object numero_provvisorio = XmlHelper.AsOptionalInt(sospeso, "numero_provvisorio");
                            Decimal importo_provvisorio = XmlHelper.AsDecimal(sospeso, "importo_provvisorio");
                            if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;

                            if (numero_provvisorio == DBNull.Value  && tipo_operazione == "STORNATO" ) {
                                numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
                            }
                            if (numero_provvisorio == DBNull.Value && tipo_operazione == "RIPRISTINATO") {
                                numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza");
                            }
                            if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;
                            if (numero_provvisorio == DBNull.Value) return null;
            
                            if ((tipo_operazione == "STORNATO" ||tipo_operazione == "RIPRISTINATO") && importo_provvisorio > 0) {
                                importo_provvisorio = -importo_provvisorio;
                            }
 
                             RigaReversale R = new RigaReversale(esercizio,
                                XmlHelper.AsInt(X, "numero_documento"),
                                importo_provvisorio,
                                XmlHelper.AsDate(X, "data_movimento"),
                                XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                XmlHelper.AsString(X, "causale"),
                                numero_provvisorio,
                                XmlHelper.AsInt(X, "progressivo_documento"));
                                foreach (string field in new string[] { "causale" }) {
                                    if (X[field] == null) continue;
                                    R.Set(field, X[field].InnerText);
                                }
                        if (numero_provvisorio != DBNull.Value) R.Set("numero_sospeso", numero_provvisorio.ToString());

                        foreach (
                            string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                            if (Xreg[field] == null) continue;
                            R.Set(field, Xreg[field].InnerText);
                        }
			            RigheReversale.Add(R);
            }
            }
	 
            return RigheReversale;
        }


        private static void ExtractCode(string causale_in, List<string> codici, out object codice,
            out string causale_out) {
            string c = causale_in.ToUpper();
            foreach (string s in codici) {
                if (c.StartsWith(s)) {
                    codice = s.TrimEnd();
                    causale_out = causale_in.Substring(s.Length);
                    return;
                }
            }
            codice = DBNull.Value;
            causale_out = causale_in;
        }

       

        static ProvvisorioEntrata CreaSospesoEntrata(XmlNode X, string conto_evidenza, int esercizio, List<string> CodiciCassiere) {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            string causale = XmlHelper.AsString(X, "causale");

            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value) {
                data_da_considerare = data_movimento;
            }
            else {
                data_da_considerare = (DateTime)data_valuta_ente;
            }

            string tipo_operazione = X["tipo_operazione"].InnerText;
            Decimal importo = XmlHelper.AsDecimal(X, "importo");
            if ((tipo_operazione == "STORNATO") && (importo > 0)) {
                importo = -importo;
            }
            ProvvisorioEntrata R = new ProvvisorioEntrata(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        importo,
                                        causale,
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        data_da_considerare,
                                        conto_evidenza
                                        );
            return R;

        }


       
        static ProvvisorioSpesa CreaSospesoUscita(XmlNode X, string conto_evidenza, int esercizio, List<string> CodiciCassiere) {
            XmlNode Xreg = X.SelectSingleNode("cliente");
            string causale = XmlHelper.AsString(X, "causale");

            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value) {
                data_da_considerare = data_movimento;
            }
            else {
                data_da_considerare = (DateTime)data_valuta_ente;
            }
            
            string tipo_operazione = X["tipo_operazione"].InnerText;
            Decimal importo = XmlHelper.AsDecimal(X, "importo");
            if ((tipo_operazione == "STORNATO") && (importo > 0)) {
                importo = -importo;
            }
            ProvvisorioSpesa R = new ProvvisorioSpesa(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        importo,
                                        causale,
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        data_da_considerare,
                                        conto_evidenza
                                        );
            return R;

        }
        /// <summary>
        /// Gestisce il tag SOSPESO ENTRATA, SOSPESO USCITA, tipo_operazione REGOLARIZZATO
        /// --- NON USATO 
        /*
        /// </summary>
        /// <param name="X"></param>
        /// <param name="esercizio"></param>
        /// <param name="CodiciCassiere"></param>
        /// <returns></returns>
        static EsitoProvvisorio CreaRegolarizzazioneSospeso(XmlNode X, int esercizio, List<string> CodiciCassiere) {
            decimal importo = -XmlHelper.AsDecimal(X, "importo");
            string tipo_documento = X["tipo_documento"].InnerText;
            string tipo_operazione = X["tipo_operazione"].InnerText;

            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_documento");
            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;

            if (numero_sospeso == DBNull.Value && tipo_operazione == "REGOLARIZZATO") {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza");
            }

            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;
            if (numero_sospeso == DBNull.Value) return null;

            EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                CfgFn.GetNoNullInt32(numero_sospeso),
                importo,
                XmlHelper.isNull(XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                    XmlHelper.AsOptionalDate(X, "data_movimento"))
            );
            return R;
        }
        */

        static   List<EsitoProvvisorio> CreaEsitoSospesoEntrata(XmlNode X, int esercizio, List<string> CodiciCassiere) {
            List<EsitoProvvisorio> EsitiBolletteEntrata = new List<EsitoProvvisorio>(); 
            string tipo_documento = X["tipo_documento"].InnerText;
            string tipo_operazione = X["tipo_operazione"].InnerText;

            foreach (XmlNode sospeso in X.SelectNodes("sospeso")) {
                object numero_provvisorio = XmlHelper.AsOptionalInt(sospeso, "numero_provvisorio");
                Decimal importo_provvisorio = XmlHelper.AsDecimal(sospeso, "importo_provvisorio");
                if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;

                if (numero_provvisorio == DBNull.Value && tipo_operazione == "STORNATO") {
                    numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
                }
                if (numero_provvisorio == DBNull.Value && tipo_operazione == "RIPRISTINATO") {
                    numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza");
                }
                if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;
                if (numero_provvisorio == DBNull.Value) return null;

                if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo_provvisorio > 0) {
                    importo_provvisorio = -importo_provvisorio;
                }

                if (tipo_operazione == "STORNATO") {
                    EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                    CfgFn.GetNoNullInt32(numero_provvisorio),
                    importo_provvisorio,
                        XmlHelper.isNull(XmlHelper.AsOptionalDate(X, "data_movimento"),
                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"))
                    );
                    EsitiBolletteEntrata.Add(R);
                }
                else {   //  "RIPRISTINATO" /  "REGOLARIZZATO"
                  EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                  CfgFn.GetNoNullInt32(numero_provvisorio),
                  importo_provvisorio,
                      XmlHelper.isNull(XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                      XmlHelper.AsOptionalDate(X, "data_movimento"))
                  );
                  EsitiBolletteEntrata.Add(R);
                }
                            
                
           }
 
          return EsitiBolletteEntrata;
        }

        static List<EsitoProvvisorio> CreaEsitoSospesoUscita(XmlNode X, int esercizio, List<string> CodiciCassiere) {
            List<EsitoProvvisorio> EsitiBolletteSpesa = new List<EsitoProvvisorio>(); 
            string tipo_documento = X["tipo_documento"].InnerText;
            string tipo_operazione = X["tipo_operazione"].InnerText;
            foreach (XmlNode sospeso in X.SelectNodes("sospeso")) {
                            object numero_provvisorio = XmlHelper.AsOptionalInt(sospeso, "numero_provvisorio");
                            Decimal importo_provvisorio = XmlHelper.AsDecimal(sospeso, "importo_provvisorio");
                            if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;

                            if (numero_provvisorio == DBNull.Value  && tipo_operazione == "STORNATO" ) {
                                numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
                            }
                            if (numero_provvisorio == DBNull.Value && tipo_operazione == "RIPRISTINATO") {
                                numero_provvisorio = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza");
                            }
                            if (numero_provvisorio.ToString() == "0") numero_provvisorio = DBNull.Value;
                            if (numero_provvisorio == DBNull.Value) return null;
            
                            if ((tipo_operazione == "STORNATO" ||tipo_operazione == "RIPRISTINATO") && importo_provvisorio > 0) {
                                importo_provvisorio = -importo_provvisorio;
                            }

                            if (tipo_operazione == "STORNATO") {
                                EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                                CfgFn.GetNoNullInt32(numero_provvisorio),
                                importo_provvisorio,
                                    XmlHelper.isNull(XmlHelper.AsOptionalDate(X, "data_movimento"),
                                    XmlHelper.AsOptionalDate(X, "data_valuta_ente"))
                                );
                                EsitiBolletteSpesa.Add(R);
                            }
                            else {   //  "RIPRISTINATO" /  "REGOLARIZZATO"
                                EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                                CfgFn.GetNoNullInt32(numero_provvisorio),
                                importo_provvisorio,
                                    XmlHelper.isNull(XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                    XmlHelper.AsOptionalDate(X, "data_movimento"))
                                );
                                EsitiBolletteSpesa.Add(R);
                            }
           }
 
          return EsitiBolletteSpesa;
        }

    }
}
