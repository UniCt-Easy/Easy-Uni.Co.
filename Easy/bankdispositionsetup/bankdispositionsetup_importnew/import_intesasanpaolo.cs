
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


    class import_intesasanpaolo {

        public static DatiImportati ImportaFile(DataAccess Conn, string fname) {
            XmlDocument X = new XmlDocument();
            try {
                X.Load(fname);
            }
            catch (Exception e2) {
                QueryCreator.ShowException(null, "Errore durante l'apertura del file selezionato!", e2);
                return null;
            }

            try {
                return ElaboraXml(X, Conn);
            }
            catch {

            }
            return null;

        }


        public static DatiImportati ElaboraXml(XmlDocument Xdoc, DataAccess Conn) {
            DatiImportati M = new DatiImportati(Conn.GetEsercizio());
            QueryHelper QHS = Conn.GetQueryHelper();
            DataTable Treasurer = Conn.RUN_SELECT("treasurer", "idtreasurer,trasmcode", null,
                        QHS.AppAnd(QHS.IsNotNull("trasmcode"), QHS.NullOrEq("active", "S")), null, false);
            List<string> CodiciCassiere = new List<string>();
            foreach (DataRow R in Treasurer.Select()) {
                CodiciCassiere.Add(R["trasmcode"].ToString().ToUpper() + " ");
            }

            int NOp = Xdoc.SelectNodes("/flusso_giornale_di_cassa/informazioni_conto_evidenza/movimento_conto_evidenza").Count;
            //Scorre l'elenco dei flussi (forse superfluo)
            XmlNodeList ElencoFlussi = Xdoc.SelectNodes("/flusso_giornale_di_cassa");
            foreach (XmlNode XFlusso in ElencoFlussi) {
                int esercizio = CfgFn.GetNoNullInt32(XFlusso["esercizio"].InnerText);
				M.esercizioflusso = esercizio;
				string codice_ente_BT = XFlusso["codice_ente_BT"].InnerText;
                string codice_ABI_BT = XFlusso["codice_ABI_BT"].InnerText;  //  05424  Banca Popolare di Bari
                string data_inizio_periodo_riferimento = XFlusso["data_inizio_periodo_riferimento"].InnerText;
                string data_fine_periodo_riferimento = XFlusso["data_inizio_periodo_riferimento"].InnerText;


                foreach (XmlNode Xinfo_conto_evidenza in XFlusso.SelectNodes("informazioni_conto_evidenza")) {
                    string conto_evidenza = Xinfo_conto_evidenza["conto_evidenza"].InnerText;
                    foreach (XmlNode Xmovimento_conto_evidenza in Xinfo_conto_evidenza.SelectNodes("movimento_conto_evidenza")) {

                        // "REVERSALE"   "MANDATO"   "SOSPESO ENTRATA"   "SOSPESO USCITA"
                        string tipo_documento = Xmovimento_conto_evidenza["tipo_documento"].InnerText;
                        string tipo_operazione = Xmovimento_conto_evidenza["tipo_operazione"].InnerText;
                        
                        if (tipo_documento == "MANDATO") {
                            M.Mandati.Add(CreaRigaMandato(Xmovimento_conto_evidenza, esercizio));
                        }
						if (tipo_documento == "REVERSALE") {
							M.Reversali.Add(CreaRigaReversale(Xmovimento_conto_evidenza, esercizio));
						}

						if (tipo_documento == "SOSPESO ENTRATA" && (tipo_operazione == "ESEGUITO" || tipo_operazione == "STORNATO")) {
							M.BolletteEntrata.Add(CreaSospesoEntrata(Xmovimento_conto_evidenza, conto_evidenza, esercizio, CodiciCassiere));
						}
						/* Parte nuova solo ARPAL / Banca Popolare di Bari: dal momento che non c'� <numero_sospeso> 
                         * nella sezione di regolarizzazione del mandato o della reversale
                         * crea qua l'esito del sospeso leggendo <numero_documento>
                         * se <numero_sospeso> � valorizzato l'esito del sospeso verr� creato contestualmente col tipo_documento == "REVERSALE"
                         * Idem per la parte spesa.
                         */
						/* Parte nuova solo per 05424  Banca Popolare di Bari, che non mette il numero sospeso 
                        * nella sezione di regolarizzazione della reversale*/
						if (tipo_documento == "SOSPESO ENTRATA" && tipo_operazione == "REGOLARIZZATO"
							&& (codice_ABI_BT.ToString() == "05424") /* 05424  Banca Popolare di Bari*/) {
							EsitoProvvisorio e = CreaEsitoSospesoEntrata(Xmovimento_conto_evidenza, esercizio, CodiciCassiere);
							if (e != null) M.EsitiBolletteEntrata.Add(e);
						}

						if (tipo_documento == "SOSPESO USCITA" && (tipo_operazione == "ESEGUITO" || tipo_operazione == "STORNATO"  )) {
                            M.BolletteSpesa.Add(CreaSospesoUscita(Xmovimento_conto_evidenza, conto_evidenza, esercizio, CodiciCassiere));
                        }
                        /* Parte nuova solo per 05424  Banca Popolare di Bari, che non mette il numero sospeso 
                         * nella sezione di regolarizzazione del mandato*/
                        if (tipo_documento == "SOSPESO USCITA" && tipo_operazione == "REGOLARIZZATO" 
                            && (codice_ABI_BT.ToString() == "05424") /* 05424  Banca Popolare di Bari*/) {
                            EsitoProvvisorio e = CreaEsitoSospesoUscita(Xmovimento_conto_evidenza, esercizio, CodiciCassiere);
                            if (e != null) M.EsitiBolletteSpesa.Add(e);
                        }
                        object numero_sospeso = XmlHelper.AsOptionalInt(Xmovimento_conto_evidenza, "numero_sospeso");
						if ((tipo_documento == "REVERSALE") && (numero_sospeso.ToString() != "")) {
							EsitoProvvisorio e = CreaEsitoSospesoEntrata(Xmovimento_conto_evidenza, esercizio, CodiciCassiere);
							if (e != null) M.EsitiBolletteEntrata.Add(e);
						}
						if ((tipo_documento == "MANDATO" ) && (numero_sospeso.ToString() != "") ) {
                            EsitoProvvisorio e = CreaEsitoSospesoUscita(Xmovimento_conto_evidenza, esercizio, CodiciCassiere);
                            if (e != null) M.EsitiBolletteSpesa.Add(e);
                        }

                    }
                }
            }



            return M;
        }

        static RigaMandato CreaRigaMandato(XmlNode X, int esercizio) {
            XmlNode Xreg = X.SelectSingleNode("cliente");
            string tipo_operazione = X["tipo_operazione"].InnerText;

            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");
            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;

            if (numero_sospeso == DBNull.Value && (tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO")) {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
            }
            
            decimal importo = XmlHelper.AsDecimal(X, "importo");
            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
                importo = -importo;
            }


            RigaMandato R = new RigaMandato(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        importo,
                                        XmlHelper.AsDate(X, "data_movimento"),
                                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        XmlHelper.AsString(X, "causale"),
                                        numero_sospeso,
                                        XmlHelper.AsInt(X, "progressivo_documento")
                                        );
            foreach (string field in new string[] { "coordinate", "causale" }) {
                if (X[field] == null) continue;
                R.Set(field, X[field].InnerText);
            }

            if (numero_sospeso != DBNull.Value) R.Set("numero_sospeso", numero_sospeso.ToString());

            foreach (string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                if (Xreg[field] == null) continue;
                R.Set(field, Xreg[field].InnerText);
            }
            return R;

        }

        static RigaReversale CreaRigaReversale(XmlNode X, int esercizio) {
            XmlNode Xreg = X.SelectSingleNode("cliente");
            string tipo_operazione = X["tipo_operazione"].InnerText;

            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");
            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;

            if (numero_sospeso == DBNull.Value && (tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO")) {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
            }

            decimal importo = XmlHelper.AsDecimal(X, "importo");
            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
                importo = -importo;
            }


            RigaReversale R = new RigaReversale(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        importo,
                                        XmlHelper.AsDate(X, "data_movimento"),
                                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        XmlHelper.AsString(X, "causale"),
                                        numero_sospeso,
                                        XmlHelper.AsInt(X, "progressivo_documento"));
            foreach (string field in new string[] { "causale" }) {
                if (X[field] == null) continue;
                R.Set(field, X[field].InnerText);
            }
            if (numero_sospeso != DBNull.Value) R.Set("numero_sospeso", numero_sospeso.ToString());

            foreach (string field in new string[] { "anagrafica_cliente", "codice_fiscale_cliente", "partita_iva_cliente" }) {
                if (Xreg[field] == null) continue;
                R.Set(field, Xreg[field].InnerText);
            }
            return R;
        }

        private static void ExtractCode(string causale_in, List<string> codici, out object codice, out string causale_out) {
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

        static ProvvisorioEntrata CreaSospesoEntrata(XmlNode X,  string conto_evidenza, int esercizio, List<string> CodiciCassiere) {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            string causale = XmlHelper.AsString(X, "causale");
 
            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value)

                data_da_considerare = data_movimento;
            else data_da_considerare = (DateTime)data_valuta_ente;

            decimal importo = XmlHelper.AsDecimal(X, "importo");

            string tipo_operazione = X["tipo_operazione"].InnerText;

            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
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


        static ProvvisorioSpesa CreaSospesoUscita(XmlNode X,  string conto_evidenza, int esercizio, List<string> CodiciCassiere) {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            string causale = XmlHelper.AsString(X, "causale");
            
            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value)

                data_da_considerare = data_movimento;
            else data_da_considerare = (DateTime)data_valuta_ente;

            decimal importo = XmlHelper.AsDecimal(X, "importo");
    
            string tipo_operazione = X["tipo_operazione"].InnerText;

            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
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

        static EsitoProvvisorio CreaEsitoSospesoEntrata(XmlNode X, int esercizio, List<string> CodiciCassiere) {
            decimal importo = XmlHelper.AsDecimal(X, "importo");
            string tipo_documento = X["tipo_documento"].InnerText;
            string tipo_operazione = X["tipo_operazione"].InnerText;

            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");
            //if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;
            
            if ((numero_sospeso.ToString() == "0") || (numero_sospeso.ToString() == "")){
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_documento");
            }
            if ((numero_sospeso.ToString() == "0") || (numero_sospeso.ToString() == "")) {
                numero_sospeso = DBNull.Value;
            }
            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
                importo = -importo;
            }
            if (numero_sospeso == DBNull.Value && (tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO")) {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
            }
            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;
            if (numero_sospeso == DBNull.Value) return null;

            EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                                         CfgFn.GetNoNullInt32(numero_sospeso),
                                        importo,
                                        XmlHelper.AsDate(X, "data_valuta_ente")
                                        );
            return R;
        }




        static EsitoProvvisorio CreaEsitoSospesoUscita(XmlNode X, int esercizio, List<string> CodiciCassiere) {
            decimal importo = XmlHelper.AsDecimal(X, "importo");

         
            string tipo_documento = X["tipo_documento"].InnerText;
            string tipo_operazione = X["tipo_operazione"].InnerText;
            if ((tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO") && importo > 0) {
                importo = -importo;
            }
            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");
            //if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;

            if ((numero_sospeso.ToString() == "0") || (numero_sospeso.ToString() == "")) {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_documento");
            }
            if ((numero_sospeso.ToString() == "0") || (numero_sospeso.ToString() == "")) {
                numero_sospeso = DBNull.Value;
            }
            if (numero_sospeso == DBNull.Value && (tipo_operazione == "STORNATO" || tipo_operazione == "RIPRISTINATO")) {
                numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_bolletta_quietanza_storno");
            }

            if (numero_sospeso.ToString() == "0") numero_sospeso = DBNull.Value;
            if (numero_sospeso == DBNull.Value) return null;


            EsitoProvvisorio R = new EsitoProvvisorio(esercizio,
                                         CfgFn.GetNoNullInt32(numero_sospeso),
                                        importo,
                                        XmlHelper.AsDate(X, "data_valuta_ente")
                                        );
            return R;
        }

    }
}
