/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using bankdispositionsetup_importnew;
using System.Data;
using metadatalibrary;
using System.Windows.Forms;
using System.Xml;
using funzioni_configurazione;

namespace bankdispositionsetup_bccirpina {

    public class RigaMandatoSondrio : RigaMandato {
        public RigaMandatoSondrio(int esercmandato, int nummandato, decimal amount, DateTime data_operazione, object data_valuta,
                        string beneficiario, string causale, object nbolletta, int nprog)
            : base(esercmandato, nummandato, amount, data_operazione, data_valuta, beneficiario, causale, nbolletta,nprog) {
        }

        

        /// <summary>
        /// Aggiunge le info di questo documento alla tabella in ingresso
        /// </summary>
        /// <param name="T"></param>
        public override void AddToTable(DataTable T) {
            DataRow R = T.NewRow();
            R["ydoc"] = y;
            R["ndoc"] = ndoc;
            R["amount"] = amount;
            R["causale"] = causale.ToString();
            R["registry"] = registry.ToString();
            R["transactiondate"] = transactiondate;
            R["nbill"] = nbill.ToString();
            T.Rows.Add(R);
        }

       

    }

    public class RigaReversaleSondrio : RigaReversale {
        public RigaReversaleSondrio(int esercreve, int numreve, decimal amount, DateTime data_operazione, object data_valuta,
                        string versante, string causale, object nbolletta,int prog)
            : base(esercreve, numreve, amount, data_operazione, data_valuta, versante, causale, nbolletta, prog) {
        }

      

        /// <summary>
        /// Aggiunge le info di questo documento alla tabella in ingresso
        /// </summary>
        /// <param name="T"></param>
        public override void AddToTable(DataTable T) {
            DataRow R = T.NewRow();
            R["ydoc"] = y;
            R["ndoc"] = ndoc;
            R["amount"] = amount;
            R["causale"] = causale.ToString();
            R["registry"] = registry.ToString();
            R["transactiondate"] = transactiondate;
            R["nbill"] = nbill.ToString();

            T.Rows.Add(R);
        }

    }

  

    /// <summary>
    /// Elenco delle informazioni rilevanti per l'esitazione delle reversali, che vanno impostati in fase di importazione:
    ///  vedi campi_reversale_sondrio
    /// </summary>
 

    public static class ImportBccIrpina {

        public static bool ElaboraXml(DatiImportati M, XmlDocument Xdoc,
            Label labelOperazione, ProgressBar pBar, TextBox DataInizioElab, TextBox DataFineElab, DataAccess Conn)
        {

            QueryHelper QHS= Conn.GetQueryHelper();
            DataTable Treasurer = Conn.RUN_SELECT("treasurer", "idtreasurer,trasmcode", null,
                            QHS.IsNotNull("trasmcode"), null, false);
            List<string> CodiciCassiere = new List<string>();
            foreach (DataRow R in Treasurer.Select()) {
                CodiciCassiere.Add(R["trasmcode"].ToString().ToUpper()+" ");
            }

            int NOp= Xdoc.SelectNodes("/flusso_giornale_di_cassa/informazioni_conto_evidenza/movimento_conto_evidenza").Count;
            pBar.Maximum= NOp;
            pBar.Value=0;
            labelOperazione.Text= "Lettura flusso XML";
            //Scorre l'elenco dei flussi (forse superfluo)
            XmlNodeList ElencoFlussi= Xdoc.SelectNodes("/flusso_giornale_di_cassa");
            foreach(XmlNode XFlusso in ElencoFlussi){
                int esercizio = CfgFn.GetNoNullInt32(XFlusso["esercizio"].InnerText);
                string codice_ente_BT = XFlusso["codice_ente_BT"].InnerText;

                string data_inizio_periodo_riferimento = XFlusso["data_inizio_periodo_riferimento"].InnerText;
                string data_fine_periodo_riferimento = XFlusso["data_inizio_periodo_riferimento"].InnerText;

                if (data_inizio_periodo_riferimento != "")
                {
                    //DataInizioElab.Text = ((DateTime)data_inizio_periodo_riferimento).ToString("dd/mm/yyyy");
                    DataInizioElab.Text = data_inizio_periodo_riferimento;
                }

                if (data_fine_periodo_riferimento != "")
                {
                  //DataFineElab.Text = ((DateTime)data_fine_periodo_riferimento).ToString("dd/mm/yyyy");
                  DataFineElab.Text = data_fine_periodo_riferimento;
                }

                foreach(XmlNode Xinfo_conto_evidenza in XFlusso.SelectNodes("informazioni_conto_evidenza")){
                    string conto_evidenza = Xinfo_conto_evidenza["conto_evidenza"].InnerText;
                    foreach (XmlNode Xmovimento_conto_evidenza in Xinfo_conto_evidenza.SelectNodes("movimento_conto_evidenza")) {

                        // "REVERSALE"   "MANDATO"   "SOSPESO ENTRATA"   "SOSPESO USCITA"
                        string tipo_documento = Xmovimento_conto_evidenza["tipo_documento"].InnerText;
                        if (tipo_documento == "MANDATO") {
                            M.Mandati.Add(CreaRigaMandato(Xmovimento_conto_evidenza, esercizio));
                        }
                        if (tipo_documento == "REVERSALE") {
                            M.Reversali.Add(CreaRigaReversale(Xmovimento_conto_evidenza, esercizio));
                        }
                        if (tipo_documento == "SOSPESO ENTRATA") {
                            M.BolletteEntrata.Add(CreaSospesoEntrata(Xmovimento_conto_evidenza, esercizio, CodiciCassiere));
                        }
                        if (tipo_documento == "SOSPESO USCITA") {
                            M.BolletteSpesa.Add(CreaSospesoUscita(Xmovimento_conto_evidenza, esercizio, CodiciCassiere));
                        }
                        pBar.Increment(1);
                        Application.DoEvents();
                    }
                }
            }
            


            return true;
        }

        static RigaMandatoSondrio CreaRigaMandato(XmlNode X,int esercizio){
            XmlNode Xreg = X.SelectSingleNode("cliente");
            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");

            RigaMandatoSondrio R = new RigaMandatoSondrio(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        XmlHelper.AsDecimal(X, "importo"),
                                        XmlHelper.AsDate(X, "data_movimento"),
                                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        XmlHelper.AsString(X, "causale"),
                                        numero_sospeso,
                                        XmlHelper.AsInt(X, "progressivo_documento")
                                        );
            foreach (string field in new string[] {  "coordinate", "causale" }) {
                if (X[field] == null) continue;
                R.Set(field, X[field].InnerText);
            }

            if (numero_sospeso != DBNull.Value) R.Set("numero_sospeso", numero_sospeso.ToString());

            foreach (string field in new string[] {"anagrafica_cliente","codice_fiscale_cliente", "partita_iva_cliente" }) {
                if (Xreg[field] == null) continue;
                R.Set(field, Xreg[field].InnerText);
            }
            return R;                   

        }

        static RigaReversaleSondrio CreaRigaReversale(XmlNode X, int esercizio) {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            object numero_sospeso = XmlHelper.AsOptionalInt(X, "numero_sospeso");
            
            RigaReversaleSondrio R = new RigaReversaleSondrio(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        XmlHelper.AsDecimal(X, "importo"),
                                        XmlHelper.AsDate(X,"data_movimento"),
                                        XmlHelper.AsOptionalDate(X, "data_valuta_ente"),
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        XmlHelper.AsString(X, "causale"),
                                        numero_sospeso,
                                        XmlHelper.AsInt(X, "progressivo_documento"));
            foreach (string field in new string[] {  "causale" }) {
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
            string c=causale_in.ToUpper();
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

        static ProvvisorioEntrata CreaSospesoEntrata(XmlNode X, int esercizio, List<string> CodiciCassiere)
        {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            string causale = XmlHelper.AsString(X, "causale");
            string causale_da_usare;
            object conto;
            ExtractCode(causale, CodiciCassiere, out conto, out causale_da_usare);

            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value)

                data_da_considerare = data_movimento;
            else data_da_considerare = (DateTime)data_valuta_ente;


            ProvvisorioEntrata R = new ProvvisorioEntrata(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        XmlHelper.AsDecimal(X, "importo"),
                                        causale_da_usare,
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        data_da_considerare,
                                        conto       // codice del cassiere ove presente il prefisso nella causale
                                        );
            return R;

        }


        static ProvvisorioSpesa CreaSospesoUscita(XmlNode X, int esercizio, List<string> CodiciCassiere)
        {
            XmlNode Xreg = X.SelectSingleNode("cliente");

            string causale = XmlHelper.AsString(X, "causale");
            string causale_da_usare;
            object conto;
            ExtractCode(causale, CodiciCassiere, out conto, out causale_da_usare);

            object data_valuta_ente = XmlHelper.AsOptionalDate(X, "data_valuta_ente");
            DateTime data_movimento = XmlHelper.AsDate(X, "data_movimento");

            DateTime data_da_considerare = QueryCreator.EmptyDate();

            if (data_valuta_ente == DBNull.Value)

                data_da_considerare = data_movimento;
            else data_da_considerare = (DateTime)data_valuta_ente;

            ProvvisorioSpesa R = new ProvvisorioSpesa(esercizio,
                                        XmlHelper.AsInt(X, "numero_documento"),
                                        XmlHelper.AsDecimal(X, "importo"),
                                        causale_da_usare,
                                        XmlHelper.AsString(Xreg, "anagrafica_cliente"),
                                        data_da_considerare,
                                        conto       // codice del cassiere ove presente il prefisso nella causale
                                        );
            return R;

        }
        

    }
}
