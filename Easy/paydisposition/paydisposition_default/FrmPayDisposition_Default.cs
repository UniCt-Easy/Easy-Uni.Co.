/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using funzioni_configurazione;
using movimentofunctions;
using System.Security;
using System.Xml;
using System.Web;
using Microsoft.CSharp;
 

namespace paydisposition_default {
    public partial class FrmPayDisposition_Default : Form {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        string ConnectionString;
        public FrmPayDisposition_Default() {
            InitializeComponent();
        }
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            GetData.SetStaticFilter(DS.paydisposition, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", Meta.GetSys("esercizio")));
            
            btnInputFile.ContextMenu =  CMenu;
			HelpForm.SetAllowMultiSelection(DS.paydispositiondetail, true);
		}

        public void MetaData_AfterActivation() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
        }

        public void MetaData_AfterClear() {
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtImporto.Text = "";
            txtInputFile.Text = "";
            btnExcel.Enabled = false;
            btnCBI.Enabled = false;
        }

        private void CalcolaImporto() {
            DataSet MyDS = (DataSet)dgDetail.DataSource;
            DataTable MyTable = MyDS.Tables[dgDetail.DataMember.ToString()];
            decimal importo = 0;
            importo = MetaData.SumColumn(MyTable, "amount");
            txtImporto.Text = importo.ToString("C");
        }

        public void MetaData_AfterFill() {
            CalcolaImporto();
			if ((Meta.InsertMode)|| (Meta.IsEmpty)) {
                    btnExcel.Enabled = false;
                    btnCBI.Enabled = false;
                }
                else {
                    btnExcel.Enabled = true;
                    btnCBI.Enabled = true;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            DataTable tExcel = new DataTable();
            addColumn(tExcel);
            popolaTabella(tExcel);
            if (tExcel != null) {
                exportclass.DataTableToExcel(tExcel, true);
            }
            else {
                MessageBox.Show(this, "Esportazione non riuscita!");
            }
        }

        private void addColumn(DataTable tExcel) {
            tExcel.Columns.Add("progressivo", typeof(int));
            tExcel.Columns["progressivo"].Caption = "Progr.";

            tExcel.Columns.Add("nominativo", typeof(string));
            tExcel.Columns["nominativo"].Caption = "NOMINATIVO";

            tExcel.Columns.Add("ddn", typeof(DateTime));
            tExcel.Columns["ddn"].Caption = "DDN";
            
            tExcel.Columns.Add("codice_fiscale", typeof(string));
            tExcel.Columns["codice_fiscale"].Caption = "CODICE_FISCALE";

            tExcel.Columns.Add("p_iva", typeof(string));
            tExcel.Columns["p_iva"].Caption = "P_IVA";
            
            tExcel.Columns.Add("cap", typeof(string));
            tExcel.Columns["cap"].Caption = "CAP";

            tExcel.Columns.Add("localita", typeof(string));
            tExcel.Columns["localita"].Caption = "LOCALITA'";

            tExcel.Columns.Add("indirizzo", typeof(string));
            tExcel.Columns["indirizzo"].Caption = "INDIRIZZO";
            
            tExcel.Columns.Add("importo", typeof(decimal));
            tExcel.Columns["importo"].Caption = "IMPORTO";

            tExcel.Columns.Add("modalitapagamento", typeof(string));
            tExcel.Columns["modalitapagamento"].Caption = "MOD. PAGAMENTO";

            tExcel.Columns.Add("iban", typeof(string));
            tExcel.Columns["iban"].Caption = "IBAN";

            tExcel.Columns.Add("codicemodalitacbi", typeof(string));
            tExcel.Columns["codicemodalitacbi"].Caption = "COD. MOD. PAGAMENTO CBI";

            tExcel.Columns.Add("note", typeof(string));
            tExcel.Columns["note"].Caption = "NOTE";
            
            tExcel.Columns.Add("descrizione", typeof(string));
            tExcel.Columns["descrizione"].Caption = "DESCRIZIONE";
            
            tExcel.Columns.Add("causale", typeof(string));
            tExcel.Columns["causale"].Caption = "CAUSALE DEL PAGAMENTO";
            
            tExcel.Columns.Add("mandato", typeof(string));
            tExcel.Columns["mandato"].Caption = "MANDATO N.";

            tExcel.Columns.Add("email", typeof(string));
            tExcel.Columns["email"].Caption = "E-Mail";

            tExcel.Columns.Add("rimborsotasse", typeof(string));
            tExcel.Columns["rimborsotasse"].Caption = "RIMBORSO TASSE";

            tExcel.Columns.Add("annoaccademico", typeof(string));
            tExcel.Columns["annoaccademico"].Caption = "ANNO ACCADEMICO";

            tExcel.Columns.Add("annosolare", typeof(string));
            tExcel.Columns["annosolare"].Caption = "ANNO SOLARE";

            tExcel.Columns.Add("tipologiacorso", typeof(string));
            tExcel.Columns["tipologiacorso"].Caption = "TIPOLOGIA CORSO";

            tExcel.Columns.Add("codicecorsouniversitario", typeof(string));
            tExcel.Columns["codicecorsouniversitario"].Caption = "COD.CORSO UNIV.";

			tExcel.Columns.Add("esentespesebancarie", typeof(string));
			tExcel.Columns["esentespesebancarie"].Caption = "ESENTE SPESE BANCARIE";
			tExcel.Columns.Add("tipotrattamentospese", typeof(string));
			tExcel.Columns["tipotrattamentospese"].Caption = "TIPO TRATT. SPESE";
		}

        private void addColumnExcel (DataTable tExcel) {
            tExcel.Columns.Add("nome", typeof(string));
            tExcel.Columns.Add("cognome", typeof(string));
            tExcel.Columns.Add("denominazione", typeof(string));
            tExcel.Columns.Add("personafisica", typeof(string));
            tExcel.Columns.Add("cf", typeof(string));
            tExcel.Columns.Add("p_iva", typeof(string));
            tExcel.Columns.Add("datanasc", typeof(string));
            tExcel.Columns.Add("indirizzo", typeof(string));
            tExcel.Columns.Add("cap", typeof(string));
            tExcel.Columns.Add("localita", typeof(string));
            tExcel.Columns.Add("provincia", typeof(string));
            tExcel.Columns.Add("email", typeof(string));
            tExcel.Columns.Add("iban", typeof(string));
            tExcel.Columns.Add("causaledett", typeof(string));
            tExcel.Columns.Add("causaleCBIdett", typeof(string));
            tExcel.Columns.Add("importo", typeof(decimal));
            tExcel.Columns.Add("codicepagamento", typeof(string));

            tExcel.Columns.Add("rimborsotasse", typeof(string));
            tExcel.Columns.Add("annoaccademico", typeof(string));
            tExcel.Columns.Add("annosolare", typeof(string));
            tExcel.Columns.Add("tipologiacorso", typeof(string));
            tExcel.Columns.Add("codicecorsouniversitario", typeof(string));
			tExcel.Columns.Add("esentespesebancarie", typeof(string));
			tExcel.Columns.Add("tipotrattamentospese", typeof(string));
		}

        private void popolaTabella(DataTable t) {
            DataRow rMain = DS.paydisposition.Rows[0];
			Conn.RUN_SELECT_INTO_TABLE(DS.chargehandling, null, null, null, false);
			 
			// POPOLA LA TABELLA DELL'ESPORTAZIONE EXCEL
			//DataRow rPay = DS.payment.Rows[0];
			foreach (DataRow rDetail in DS.paydispositiondetail.Rows) {
                DataRow r = t.NewRow();
                r["progressivo"] = rDetail["iddetail"];
                if (rDetail["flaghuman"].ToString().ToUpper() == "S")
                {
                    r["nominativo"] = rDetail["surname"].ToString() + " " + rDetail["forename"].ToString();
                }
                else {
                    r["nominativo"] = rDetail["title"].ToString();
                }
                r["ddn"] = rDetail["birthdate"];
                r["codice_fiscale"] = rDetail["cf"];
                r["p_iva"] = rDetail["p_iva"];
                r["cap"] = rDetail["cap"];
                r["localita"] = rDetail["location"].ToString() + " (" + rDetail["province"].ToString() + ")";
                r["indirizzo"] = rDetail["address"];
                r["importo"] = rDetail["amount"];

                int valore_paymethodcode = CfgFn.GetNoNullInt32(rDetail["paymethodcode"]);
                r["codicemodalitacbi"] = valore_paymethodcode;

                switch (valore_paymethodcode)
                {
                    case 1:
                        r["modalitapagamento"]  = "Bonifico";  r["codicemodalitacbi"] = "1"; break;
                    case 2:
                        r["modalitapagamento"]  =   "Cassa"; r["codicemodalitacbi"] = "1"; break;
                    case 3:
                         r["modalitapagamento"] =   "Assegno Circolare" ; r["codicemodalitacbi"] = "2"; break;
                    case 4:
                         r["modalitapagamento"] =   "Assegno Circolare Non Trasf" ;r["codicemodalitacbi"] = "3";  break;
                    case 5:
                         r["modalitapagamento"] =   "Assegno Quietanza"; r["codicemodalitacbi"] = "4"; break;
                }

                if (r["modalitapagamento"] == DBNull.Value)
                    if (r["iban"] == DBNull.Value)
                    {
                        r["modalitapagamento"] = "Cassa";
                        r["codicemodalitacbi"] = "1";
                    }
                    else
                    {
                        r["modalitapagamento"] = "Bonifico";
                        r["codicemodalitacbi"] = "1";
                    }

                r["iban"] = rDetail["iban"];
                r["note"] = "Q.";
                r["descrizione"] = rMain["description"];
                r["causale"] = isNull(rDetail["motive"], rMain["motive"]);
                r["mandato"] = componiMandato();
                r["email"] = rDetail["email"];

                r["rimborsotasse"] = rDetail["flagtaxrefund"];
                r["annosolare"] = rDetail["calendaryear"];
                int AAAA2 = CfgFn.GetNoNullInt32(rDetail["academicyear"])+1;
                string AnnoAccademico = rDetail["academicyear"].ToString() + "/" + AAAA2.ToString();
                r["annoaccademico"] = AnnoAccademico;
                r["tipologiacorso"] = rDetail["degreekind"];

				if ((CfgFn.GetNoNullInt32(rDetail["flag"])& 1)!= 0) 
					r["esentespesebancarie"] = "S";
				else
					r["esentespesebancarie"] = "N";

				r["tipotrattamentospese"] = leggi_trattamentospese(DS.chargehandling, rDetail["idchargehandling"]);
				t.Rows.Add(r);
            }
        }

        private object isNull(object a, object b) {
            if ((a != null) && (a != DBNull.Value)) {
                return a;
            }
            return b;
        }

        private string componiMandato() {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay",kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            DateTime data = (rPay["adate"] != DBNull.Value)
                ? (DateTime)rPay["adate"] : QueryCreator.EmptyDate();
            string outstr = rPay["npay"].ToString() + " del " + data.ToString("dd/MM/yyyy");

            return outstr;
        }

        private string leggi_NumMandato() {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            string outstr = rPay["npay"].ToString();

            return outstr;
        }

        // Con CARIME non serve leggere questo
        private string leggi_reccbikind()
        {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object idtreasurer = rPay["idtreasurer"];
            if (idtreasurer == DBNull.Value) return "";

            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer), null, false);
            DataRow[] rtreasurer = tTreasurer.Select(QHS.CmpEq("idtreasurer", idtreasurer));
            if (rtreasurer.Length == 0) return "";
            DataRow rTreasurer = rtreasurer[0];
            object reccbikind = rTreasurer["reccbikind"];
            if (reccbikind == DBNull.Value) return "";
            string outstr = rTreasurer["reccbikind"].ToString();

            return outstr;
        }

        private string leggi_causale(object idcbimotive)
        {
            DataRow[] rCBImotive = DS.cbimotive.Select(QHS.CmpEq("idcbimotive", idcbimotive));
            if (rCBImotive.Length == 0) return "";
            DataRow rcbimotive = rCBImotive[0];
            object cbimotive = rcbimotive["codemotive"];
            if (cbimotive == DBNull.Value) return "";
            string outstr = rcbimotive["codemotive"].ToString();
            return outstr;
        }

		Hashtable hashTrattamentoSpese = null;



		object leggi_trattamentospese(DataTable ChargeHandling, object idchargehandling) {
			if (hashTrattamentoSpese == null) {
				hashTrattamentoSpese = new Hashtable();
				foreach (DataRow RH in ChargeHandling.Rows) {
					hashTrattamentoSpese[RH["idchargehandling"]] = RH;
				}
			}
			DataRow RID = hashTrattamentoSpese[idchargehandling] as DataRow;
			if (RID != null) {
				return RID["handlingbankcode"];
			} 
			else return DBNull.Value;
		}
		 
		private string leggi_datiMandato(string datoDaLeggere) {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object datoPayment = DBNull.Value;
            switch (datoDaLeggere)
            {
              case "datavaluta":
                    datoPayment = rPay["adate"]; break; // Data di emissione del mandato collegato
            }
            return datoPayment.ToString();
        }


        private string leggi_coordinateCassiere(string coordinata)
        {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object idtreasurer = rPay["idtreasurer"];
            if (idtreasurer == DBNull.Value) return "";

            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer), null, false);
            DataRow[] rtreasurer = tTreasurer.Select(QHS.CmpEq("idtreasurer", idtreasurer));
            if (rtreasurer.Length == 0) return "";
            DataRow rTreasurer = rtreasurer[0];
            object coordinataMain = DBNull.Value;
            switch (coordinata)
            {
                case "abi":
                    coordinataMain = rTreasurer["idbank"]; break;
                case "cab":
                    coordinataMain = rTreasurer["idcab"]; break;
                case "cin":
                    coordinataMain = rTreasurer["cincbi"]; break;
                case "cc":
                    coordinataMain = rTreasurer["cc"]; break;
                case "iban":
                    coordinataMain = rTreasurer["iban"]; break;
            }

            if (coordinataMain == DBNull.Value) return "";
            string outstr = coordinataMain.ToString();

            return outstr;
        }

        private string leggi_coordinateCBI(string coordinata){
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object idtreasurer = rPay["idtreasurer"];
            if (idtreasurer == DBNull.Value) return "";

            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer), null, false);
            DataRow[] rtreasurer = tTreasurer.Select(QHS.CmpEq("idtreasurer", idtreasurer));
            if (rtreasurer.Length == 0) return "";
            DataRow rTreasurer = rtreasurer[0];
            object coordinataCBI = DBNull.Value;
            switch (coordinata)
            {
                case "abi":
                    coordinataCBI = rTreasurer["idbankcbi"]; break;
                case "cab":
                    coordinataCBI = rTreasurer["idcabcbi"]; break;
                case "cin":
                    coordinataCBI = rTreasurer["cincbi"]; break;
                case "cc":
                    coordinataCBI = rTreasurer["cccbi"]; break;
                case "iban":
                    coordinataCBI = rTreasurer["ibancbi"]; break;
            }
        
            if (coordinataCBI == DBNull.Value) return "";
            string outstr = coordinataCBI.ToString();

            return outstr;
        }

        private string leggi_CodiceSIA()
        {
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object idtreasurer = rPay["idtreasurer"];
            if (idtreasurer == DBNull.Value) return "";

            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer), null, false);
            DataRow[] rtreasurer = tTreasurer.Select(QHS.CmpEq("idtreasurer", idtreasurer));
            if (rtreasurer.Length == 0) return "";
            DataRow rTreasurer = rtreasurer[0];
            object siacodecbi = rTreasurer["siacodecbi"];
            if (siacodecbi == DBNull.Value) return "";
            string outstr = rTreasurer["siacodecbi"].ToString();

            return outstr;
        }
        private void btnCBI_Click(object sender, EventArgs e){
            // definizione file da creare
            SaveFileDialog dlg = new SaveFileDialog();
            string filename="";
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            if (filename == "") return;
            LeggiDati(filename);
        }

        private string LeggiBanca(){
            DataRow Curr = DS.paydisposition.Rows[0];
            object kpay = Curr["kpay"];
            if (kpay == DBNull.Value) return "";

            DataRow[] rpay = DS.payment.Select(QHS.CmpEq("kpay", kpay));
            if (rpay.Length == 0) return "";
            DataRow rPay = rpay[0];
            object idtreasurer = rPay["idtreasurer"];
            if (idtreasurer == DBNull.Value) return "";

            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer), null, false);
            DataRow[] rtreasurer = tTreasurer.Select(QHS.CmpEq("idtreasurer", idtreasurer));
            if (rtreasurer.Length == 0) return "";
            DataRow rTreasurer = rtreasurer[0];
            object ABI = rTreasurer["idbank"];
            if (ABI == DBNull.Value) return "";
            string outstr = rTreasurer["idbank"].ToString();

            return outstr;
        }
 
        private void LeggiDati(string filename){
            DataRow rpaydisposition = DS.paydisposition.Rows[0]; 

            dsDati.TestataDisposizioni.Clear();
            dsDati.RigheDisposizioni.Clear();
            DataRow drTestata = dsDati.TestataDisposizioni.NewRow();

            bool BancaCarime = (LeggiBanca()=="03067");
            bool BancaPopPugliese = (LeggiBanca() == "05262");
            bool Unicredit = (LeggiBanca() == "02008"); // Caserta
            // Leggi dati da License
            IDictionary campiPresiDallaLicenza = new Hashtable();
            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            DataRow rLicenza = tLicenza.Rows[0];
            campiPresiDallaLicenza["cf"] = rLicenza["cf"] is DBNull ? rLicenza["p_iva"] : rLicenza["cf"];
            campiPresiDallaLicenza["agencyname"] = rLicenza["agencyname"];
            campiPresiDallaLicenza["address1"] = rLicenza["address1"];
            campiPresiDallaLicenza["location"] = rLicenza["location"];

            drTestata["AbiAzienda"] = leggi_coordinateCassiere("abi");
            drTestata["CabAzienda"] = leggi_coordinateCassiere("cab");
            drTestata["CodiceSia"] = leggi_CodiceSIA();
            // Per CARIME non è obbligatorio.
            if ((drTestata["CodiceSia"].ToString() == "") && BancaCarime){
                drTestata["CodiceSia"] = "     ";// blank lunghezza 5
            }
            if ((drTestata["CodiceSia"].ToString() == "") && !BancaCarime){
                MessageBox.Show("Non è stato inserito il CodiceSIA. Inserirlo in Configurazione/Tesoriere.\n "+
                                "L'operazione sarà annullata.", "Attenzione",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            drTestata["CodificaFiscale"] = campiPresiDallaLicenza["cf"];
            drTestata["ContoAzienda"] = leggi_coordinateCassiere("cc");
            drTestata["DataAutorizzazione"] = (DateTime)Meta.GetSys("datacontabile");
            drTestata["DataDisposizioni"] = (DateTime)Meta.GetSys("datacontabile");
            drTestata["Descrizione"] = string.Format("{0} {1}-{2}", (DateTime)Meta.GetSys("datacontabile"), drTestata["AbiAzienda"], drTestata["CabAzienda"]);
            drTestata["DescrizioneAzienda"] = campiPresiDallaLicenza["agencyname"];
            drTestata["IndirizzoAzienda"] = campiPresiDallaLicenza["address1"];
            drTestata["LocalitaAzienda"] = campiPresiDallaLicenza["location"];
            drTestata["NomeSupporto"] = string.Format("INVIO DEL {0}", (DateTime) Meta.GetSys("datacontabile"));
            drTestata["ProvinciaFinanza"] = campiPresiDallaLicenza["country"];
            drTestata["RagioneSociale"] = drTestata["DescrizioneAzienda"];

            dsDati.TestataDisposizioni.Rows.Add(drTestata);
            
            int k = 0;
            foreach (DataRow rDetail in DS.paydispositiondetail.Rows) {
                DataRow drRighe = dsDati.RigheDisposizioni.NewRow();
                drRighe["PagamentoPerBonifico"] = "N";
                drRighe["PagamentoPerCassa"] = "N";
                drRighe["PagamentoPerAssegnoCircolare"] = "N";
                drRighe["PagamentoPerAssegnoCircolareNonTrasf"] = "N";
                drRighe["PagamentoPerAssegnoQuietanza"] = "N";
                if (((rDetail["abi"] != DBNull.Value) && 
                    (rDetail["cab"] != DBNull.Value) && 
                    (rDetail["cc"] != DBNull.Value))&& 
                    (rDetail["iban"] == DBNull.Value)){

                    string Beneficiario = "";
                    if (rDetail["flaghuman"].ToString().ToUpper() == "S"){
                        Beneficiario = rDetail["surname"].ToString() + " " + rDetail["forename"].ToString();
                    }
                    else{
                        Beneficiario = rDetail["title"].ToString();
                    }

                    MessageBox.Show("Nella disposizione per " + Beneficiario.ToString() + 
                                    " sono state indicate le coordinate bancarie " 
                                    , "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                // E' un Bonifico se c'è l'IBAN, in quanto per il bonifico dobbiamo compilare il record 17 in cui l'IBAN è obbligatorio.
                if ((rDetail["iban"] != DBNull.Value)){ 
                    //legge i dati dal dettagli
                        drRighe["AbiCliente"] = rDetail["abi"];
                        drRighe["CabCliente"] = rDetail["cab"];
                        drRighe["CCCliente"] = rDetail["cc"];
                        drRighe["CinCliente"] = rDetail["cin"];
                        drRighe["IBANCliente"] = rDetail["iban"];
                        drRighe["PagamentoPerBonifico"] = "S";
                }
                else { 
                    int valore_paymethodcode = CfgFn.GetNoNullInt32(rDetail["paymethodcode"]);
                    switch (valore_paymethodcode)
                    {
                        case 2:
                            drRighe["PagamentoPerCassa"] = "S"; break;
                        case 3:
                            drRighe["PagamentoPerAssegnoCircolare"] = "S"; break;
                        case 4:
                            drRighe["PagamentoPerAssegnoCircolareNonTrasf"] = "S"; break;
                        case 5:
                            drRighe["PagamentoPerAssegnoQuietanza"] = "S"; break;
                        default:  
                            drRighe["PagamentoPerCassa"] = "S";break;

                    }
                    //I campi coordinate bancarie cliente vengono messi a null (CARIME) perchè per il pagamento per cassa/assegno non serve comunicarli. 
                    if (BancaCarime){
                        drRighe["AbiCliente"] = string.Empty;
                        drRighe["CabCliente"] = string.Empty;
                        drRighe["CCCliente"] = string.Empty;
                        drRighe["CinCliente"] = string.Empty;
                        drRighe["IBANCliente"] = string.Empty;
                    }
                    else{
                        // alcune banche invece richiedono la trasmissione di coordinate bancarie convenzionali
                        // anche se non si tratta di bonifico, come ad  esempio Unicredit, si configurano nel tesoriere
                        drRighe["AbiCliente"] = leggi_coordinateCBI("abi");
                        drRighe["CabCliente"] = leggi_coordinateCBI("cab");
                        drRighe["CCCliente"] = leggi_coordinateCBI("cc");
                        drRighe["CinCliente"] = leggi_coordinateCBI("cin");
                        drRighe["IBANCliente"] = leggi_coordinateCBI("iban");
                    }
                }
                drRighe["CapBeneficiario"] = rDetail["cap"].ToString();
                drRighe["DataDocumento"] = (DateTime)Meta.GetSys("datacontabile");
                if (rDetail["flaghuman"].ToString().ToUpper() == "S") {
                    drRighe["DescrizioneBeneficiario"] = rDetail["surname"].ToString() + " " + rDetail["forename"].ToString();
                    drRighe["CodiceBeneficiario"] = rDetail["cf"].ToString();//rec 10
                    drRighe["CodiceFiscaleBeneficiario"] = rDetail["cf"]; // rec 30
                }
                else {
                    drRighe["DescrizioneBeneficiario"] = rDetail["title"].ToString();
                    drRighe["CodiceBeneficiario"] = rDetail["cf"] is DBNull ? rDetail["p_iva"] : rDetail["cf"];//rec  10
                    drRighe["CodiceFiscaleBeneficiario"] = rDetail["cf"] is DBNull ? rDetail["p_iva"] : rDetail["cf"];// rec 30
                }
                drRighe["IdRiga"] = k + 1;
                drRighe["Importo"] = (decimal) rDetail["amount"];
                drRighe["IndirizzoBeneficiario"] = rDetail["address"];
                drRighe["LocalitaBeneficiario"] = rDetail["location"].ToString();
                drRighe["NumeroDocumento"] = leggi_NumMandato();
                drRighe["RichiestaEsito"] = 0;
                drRighe["SiglaProvincia"] = rDetail["province"].ToString(); ;
                drRighe["TipoCodice"] = 3;// il 3 significa che come codice creditore andremo a specificare il CF
                drRighe["TipoDocBeneficiario"] = 0;
                if ((BancaPopPugliese) || (Unicredit)) {
                    drRighe["DataValuta"] = leggi_datiMandato("datavaluta");
                }
                if (rDetail["idcbimotive"] != DBNull.Value){
                    drRighe["Causale"] = leggi_causale(rDetail["idcbimotive"]);
                }
                else{
                    drRighe["Causale"] = leggi_causale(rpaydisposition["idcbimotive"]);
                   }
                   if (drRighe["Causale"].ToString() == "") {
                   MessageBox.Show("Non è stato inserita la Causale.\n " +
                                   "L'operazione sarà annullata.", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   return;
               }

                drRighe["CausaleDescrittiva"] = isNull(rDetail["motive"], rpaydisposition["motive"]);
                dsDati.RigheDisposizioni.Rows.Add(drRighe);
            }

            GeneraFile(filename);
        }

        private int CheckValore(TextBox t){
            int retValue = 0;
            if (!int.TryParse(t.Text,out retValue) || retValue <= 0)
            {
                MessageBox.Show("Valore errato");
                t.Focus();
            }
            return retValue;
        }
        
        private void GeneraFile(string filename)
        {
            

            string reccbikind = leggi_reccbikind();
            StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding(1252));
                DataRow[] dr = dsDati.TestataDisposizioni.Select(); 

                DatiCbiRiba riba = new DatiCbiRiba();
                riba.AbiAzienda = dr[0]["AbiAzienda"].ToString();
                riba.CabAzienda = dr[0]["CabAzienda"].ToString();
                riba.CodiceSia = dr[0]["CodiceSia"].ToString();
                riba.CodificaFiscale = dr[0]["CodificaFiscale"].ToString();
                riba.ContoAzienda = dr[0]["ContoAzienda"].ToString();
                riba.DataAutorizzazione = (DateTime)dr[0]["DataAutorizzazione"];
                riba.DataCreazione = (DateTime)dr[0]["DataDisposizioni"];
                riba.DescrizioneAzienda = riba.sanitize(dr[0]["DescrizioneAzienda"].ToString());
                riba.IndirizzoAzienda = riba.sanitize(dr[0]["IndirizzoAzienda"].ToString());
                riba.LocalitaAzienda = riba.sanitize(dr[0]["LocalitaAzienda"].ToString());
                riba.NomeSupporto = riba.sanitize(dr[0]["NomeSupporto"].ToString());
                riba.ProvinciaFinanza = riba.sanitize(dr[0]["ProvinciaFinanza"].ToString());
                riba.RagioneSociale = riba.sanitize(dr[0]["RagioneSociale"].ToString());
                // scrittura testata file riba
                sw.WriteLine(riba.RecordPC());
  
       
                // ciclo su datarows dettaglio
                foreach (DataRow righe in dsDati.RigheDisposizioni.Select())
            	{
                    riba.AbiCliente = righe["AbiCliente"].ToString();
                    riba.CabCliente = righe["CabCliente"].ToString();
                    riba.CCCliente = righe["CCCliente"].ToString();
                    riba.CinCliente = righe["CinCliente"].ToString();
                    riba.IBANCliente = righe["IBANCliente"].ToString();

                    riba.CapBeneficiario = righe["CapBeneficiario"].ToString();
                    riba.CodiceBeneficiario = righe["CodiceBeneficiario"].ToString();
                    riba.CodiceFiscaleBeneficiario = riba.sanitize(righe["CodiceFiscaleBeneficiario"].ToString());
                    riba.DescrizioneBeneficiario = riba.sanitize(righe["DescrizioneBeneficiario"].ToString());
                    riba.Importo = (decimal)righe["Importo"];
                    riba.IndirizzoBeneficiario = riba.sanitize(righe["IndirizzoBeneficiario"].ToString());
                    riba.LocalitaBeneficiario = riba.sanitize(righe["LocalitaBeneficiario"].ToString());
                    riba.RichiestaEsito = (int)righe["RichiestaEsito"];
                    riba.RiferimentoCredito = riba.sanitize(righe["CausaleDescrittiva"].ToString());
                    riba.SportelloBeneficiario = string.Empty;
                    riba.TipoCodice = (int)righe["TipoCodice"];
                    riba.TipoDocBeneficiario = (int)righe["TipoDocBeneficiario"];
                    if (righe["DataValuta"] != DBNull.Value)
                        riba.DataValuta = (DateTime)righe["DataValuta"];
                    else
                        riba.DataValuta = QueryCreator.EmptyDate();
                    riba.Causale = riba.sanitize(righe["Causale"].ToString());
                    riba.CausaleDescrittiva = riba.sanitize(righe["CausaleDescrittiva"].ToString());
                    riba.PagamentoPerBonifico = riba.sanitize(righe["PagamentoPerBonifico"].ToString());
                    riba.PagamentoPerCassa = righe["PagamentoPerBonifico"].ToString();
                    riba.PagamentoPerAssegnoCircolare = righe["PagamentoPerAssegnoCircolare"].ToString();
                    riba.PagamentoPerAssegnoCircolareNonTrasf = righe["PagamentoPerAssegnoCircolareNonTrasf"].ToString();
                    riba.PagamentoPerAssegnoQuietanza = righe["PagamentoPerAssegnoQuietanza"].ToString();
                    sw.WriteLine(riba.Record10());

                    string valore_iban = righe["IBANCliente"].ToString();
                    // Convenzione per UNICREDIT
                    // Se sono valorizzate le coordinate nel dettaglio allora è un bonifico altrimenti è un pagamento per cassa.
                    // PRIMO IF - Se è un "Bonifico" e sono valorizzati SOLO abi cab e cc si prendo quelli e si scrive SOLO il rec 10
                    // Se c'è l'IBAN si compila ANCHE il rec 17. 
                    // SECONDO IF - Se pagamento "per cassa", se nel Cassiere si è scelto recCBIkind = 17 si compila ANCHE il 17 altrimenti SOLO il rec 10.
                    // NB:il Record 17 è un record facoltativo. Qualora esista, prevale sul 10.

                    // Convenzione pr CARIME
                    // Se sono valorizzate le coordinate nel dettaglio allora è un bonifico altrimenti è un pagamento per cassa 
                    // o per assegno circolare o non trasferibile.
                    // PRIMO IF - Se è un "Bonifico" non si compilano i campi abi/cab/cc del record 10, ma si compilarà solo record 17.
                    // SECONDO IF - Se pagamento "per cassa", non si compilano i campi abi/cab/cc del record 10, non si compila neanche il record 17.
                    // NB:il Record 17 è un record facoltativo. Qualora esista, prevale sul 10.

                    if ((valore_iban != "") && (righe["PagamentoPerCassa"].ToString() == "N")) {
                        sw.WriteLine(riba.Record17());
                    }

                    sw.WriteLine( riba.Record20());
                    sw.WriteLine( riba.Record30());
                    sw.WriteLine( riba.Record40());
                    sw.WriteLine( riba.Record50());
                    sw.WriteLine( riba.Record70());                 
            	}
                // scrittura footer file riba
                sw.WriteLine( riba.RecordEF());
            	sw.Close();
                MessageBox.Show("File salvato in " + filename, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        private void btnInputFile_Click (object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            //Riempie il datatable MData leggendo dal foglio Excel
            if (!LeggiFile()) {
                return;
            }
        }

        private bool LeggiFile () {
            DialogResult dr = MyOpenFile.ShowDialog(this);
            if (dr != DialogResult.OK) return false;
            DataTable t;
            try {
                string fileName = MyOpenFile.FileName;
                //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                //    ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                ConnectionString = ExcelImport.ExcelConnString(fileName);
                t=ReadCurrentSheet(fileName);
                txtInputFile.Text = fileName;
            }
            catch (Exception ex) {
                MessageBox.Show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }
            if (t == null) return false;
           
            if (!verificaValiditaCampiExcel(t)) {
                return false;
            }
            fillPayDisposition(t);
            Meta.FreshForm();
            return true;
        }

        // /// <summary>
        // /// legge i dati dal foglio di Excel a mData
        // /// </summary>
        //private void ReadCurrentSheet() {
        //     try {
        //         // open the connection to the file
        //         using (OleDbConnection connection =
        //                    new OleDbConnection(ConnectionString)) {
        //             connection.Open();
        //             DataTable sheetData = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //             string foglioLavoro = sheetData.Rows[0]["TABLE_NAME"].ToString();
        //             string sql =
        //                 string.Format("select * from [{0}]", foglioLavoro);
        //             // create an adapter
        //             using (OleDbDataAdapter adapter =
        //                        new OleDbDataAdapter(sql, connection)) {
        //                 // clear the datatable to avoid old data persistance
        //                 mData.Clear();
        //                 //mData.Columns.Clear();

        //                 // fille the datatable
        //                 adapter.Fill(mData);
        //             }
        //             connection.Close();
        //         }
        //     }
        //     catch (Exception ex) {
        //         MessageBox.Show(this, ex.Message);
        //     }
        //    // pulizia nomi colonne da eventuali spazi
        //    foreach (DataColumn C in mData.Columns) {
        //        C.ColumnName = C.ColumnName.Trim();
        //    }

        // }

        private DataTable ReadCurrentSheet(string filename) {
            LeggiFile Reader = new LeggiFile();
            if (!Reader.Init(tracciato_disppagamento, filename)) return null;

            DataTable t = new DataTable();
            addColumnExcel(t);

            Reader.Skip();
            Reader.GetNext();
            while (Reader.DataPresent()) {
                DataRow r = t.NewRow();
                foreach(DataColumn c in t.Columns) {
                    object o = Reader.getCurrField(c.ColumnName);
                    r[c.ColumnName] = o;
                }
                t.Rows.Add(r);
                Reader.GetNext();
            }
            t.AcceptChanges();
            Reader.Close();
            return t;
        }
      

        private object TrimString(object value,bool toglichiocciola)
        {
            if (value!= null)
            {
                 string strValue = value.ToString();
                 if (strValue == "") return DBNull.Value;
                 //  else return aggiustaStringa(strValue,toglichiocciola).Trim();  
                else return strValue.Trim();
             }
             else
                return DBNull.Value; 
        }

        private string aggiustaStringa(string stringa, bool toglichiocciola)
        {

            string s= stringa.Replace('’', ' ').Replace('´', ' ').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
            if (toglichiocciola) s = s.Replace('@', ' ');
            return s;
        }

        string[] tracciato_disppagamento =
              new string[]{
                        "nome;Nome;Stringa;30",
                        "cognome;Cognome;Stringa;30",
                        "denominazione; Denominazione;Stringa;100",
                        "personafisica; Persona Fisica;Codificato;1;S|N",
                        "cf;C.F.;Stringa;16",
                        "p_iva;Partita IVA (se non si tratta di persona fisica);Stringa;15",
                        "datanasc;Data Nascita;Data;10",
                        //indirizzo
                        "indirizzo;Indirizzo;Stringa;30",
                        "cap;CAP;Stringa;5",
                        "localita;Località;Stringa;25",
                        "provincia;SIGLA Provincia;Stringa;2",
                        "email; indirizzo e-mail(facoltativo);Stringa;200",
			            // informazioni sul tipo pagamento
                        "iban;IBAN (valorizzare se bonifico);Stringa;50",
                        "causaledett;Causale del dettaglio della disposizione (facoltativa, se diversa dalla causale principale della disposizione);Stringa;80",
                        "causaleCBIdett; Causale Esportazione CBI (facoltativa,se diversa dalla causale " +
                            " CBI principale della disposizione)" +
                            "1-emolumenti generici	     "       +
                            "2-emolumenti - pensione	 "     +
                            "3-emolumenti - stipendi	 "     +
                            "4-giroconto			     "       +
                            "5-bonifici generici	 	 "       +
                            "6-bonifici per previdenza complementare "  +
                            "7-girofondi			 "           +
                            "8-rimborsi ad utenti RID	 "        +
                            "9-bonifici da parte di società emittenti carte di credito a favore di esercenti;" +
                            "Codificato;1;1|2|3|4|5|6|7|8|9",
                        "importo;Importo del dettaglio della disposizione;Numero;22",
                        "codicepagamento;Cod. Pagamento;Stringa;10",
                        "codicemodpagamento;Cod. Modalità pagamento " +
                            " 1 - Bonifico " +
                            " 2 - Cassa" +
                            " 3 - Assegno Circolare" +
                            " 4 - Assegno Circolare Non Trasferibile" +
                            " 5 - Assegno di Quietanza;" +
                            "Codificato;1;1|2|3|4|5",
                            "rimborsotasse;Rimborso Tasse;Codificato;1;S|N"+
                            "annoaccademico;Anno accademico cui si riferiscono le spese(es.2015/2016);Stringa;9",
                            "annosolare;Anno solare in cui è stata sostenuta la spesa rimborsata);Stringa;4",
                            "tipologiacorso;Tipologia del corso cui si riferiscono le spese" +
                            "1 - Laurea "+
                            "2 - Laurea Magistrale"+
                            "3 - Laurea vecchio ordinamento"+
                            "4 - Master I livello"+
                            "5 - Master II livello "+
                            "6 - Dottorato "+
                            "7 - Scuola di specializzazione" +
                            "8 - Corsi di perfezionamento;" +
                            "Codificato;1;1|2|3|4|5|6|7|8",
                            "codicecorsouniversitario;Codice del corso universitario cui si riferiscono le spese(dato estratto dal codice ANS);Stringa;16",
							"esentespesebancarie;Esente da Spese Bancarie(S/N);Codificato;1;S|N",
							"tipotrattamentospese;Tipologia trattamento Spese / idchargehandling;Intero;8"// leggere da configurazione e mettere idchargehandling    

				  };

        private bool verificaValiditaCampiExcel (DataTable mData) {
          

            bool ok = true;
            DataSet Out = new DataSet();
            DataTable T = new DataTable();
            T.Columns.Add("errors", typeof(System.String), "");
            for (int i = 0; i < tracciato_disppagamento.Length; i++) {
                 string fmt = tracciato_disppagamento[i];
                 bool datiValidi = verificaCampo(mData, fmt,T);
                 if (!datiValidi) ok = false;   
            }

            Out.Tables.Add(T);

            if (!ok) {
                FrmViewError View = new FrmViewError(Out);
                View.Show();
            }

            return ok;
        }

        bool verificaCampo (DataTable mData, string tracciato_field, DataTable T) {
       
            bool ok = true; 
            string[] ff = tracciato_field.Split(';');
            string fieldname = ff[0];
            if (((fieldname == "codicepagamento")||
                (fieldname == "codicemodpagamento")||
                (fieldname == "rimborsotasse") ||
                (fieldname == "annoaccademico") ||
                (fieldname ==  "annosolare")||
                (fieldname == "tipologiacorso") ||
                (fieldname == "codicecorsouniversitario")    
                ) &&
                (!mData.Columns.Contains(fieldname)))
                {
                    return ok;
                }
            int len = Convert.ToInt32(ff[3]);
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            int rownum = 0;
            foreach (DataRow riga in mData.Select()) {
            string val = riga[fieldname].ToString().Trim();
            rownum++;
            if ((val.Length > len) && (ftype== "stringa")) {
                string err = "Lunghezza non prevista nella decodifica del campo " + fieldname + " di tipo " + ftype + " e di valore " +
                 val.Trim().TrimStart('0') + " alla riga " + rownum;
                 DataRow row = T.NewRow();
                 row["errors"] = err;
                 T.Rows.Add(row);
                 ok = false;
            }

            switch (fieldname) {
                case "personafisica":
                if ((val.ToUpper() != "S") && (val.ToUpper() != "N")) {
                    string err = "Valore non previsto nella decodifica del campo " + fieldname +
                                    " di tipo " + ftype + " e di valore " +
                    val.Trim() + " alla riga " + rownum;
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }
                else {
                    string cognome = riga["cognome"].ToString();
                    string nome = riga["nome"].ToString();
                    string denominazione = riga["denominazione"].ToString();
                    string cf = riga["cf"].ToString();
                    string p_iva = riga["p_iva"].ToString();
                    string datanascita = riga["datanasc"].ToString();

                    if ((val.ToUpper() == "S")&&((cognome=="")||(nome==""))) {
                        string err = "Cognome/Nome non valorizzati" + 
                                     " alla riga " + rownum + " e obbligatori per una persona fisica";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }

                    if ((val.ToUpper() == "S") && (cf == "")) {
                        string err = "Codice fiscale non valorizzato" +
                                     " alla riga " + rownum +  " e obbligatorio per una persona fisica";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }

                    if ((val.ToUpper() == "S") && (datanascita == "")) {
                        string err = "Data di nascita non valorizzata" +
                                     " alla riga " + rownum + " e obbligatoria per una persona fisica";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                    if ((val.ToUpper() == "N") && (denominazione == "")) {
                        string err = "Denominazione non valorizzata ma obbligatoria non trattandosi di persona fisica" +
                                     " alla riga " + rownum;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }

                    if ((val.ToUpper() == "N") && (p_iva == "")) {
                        string err = "Partita IVA non valorizzata  ma obbligatoria non trattandosi di persona fisica" +
                                     " alla riga " + rownum;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }

                }
                break;
                case "cf":
                     // controllo del codice fiscale
                if (val != "") {
                    string errori = null;
                    CalcolaCodiceFiscale.CheckCF(val.Trim(),out errori);
                    if (errori != "") 
                    {
                        string err = " Nel codice fiscale " + " alla riga " + rownum + ": " + val + " compaiono i seguenti errori: " + errori;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                }
                break;
                case "p_iva":
                     // controllo della partita iva
                if (val != "") {

                    string errori = CalcolaPartitaIva.controllaPartitaIva(val);
                    if ((errori != null)&&(errori!="OK")) {
                        string err =  " Nella PARTITA IVA " + " alla riga " +  rownum + ": " + val + " compaiono i seguenti errori: " + errori;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                }
                break;
                case "indirizzo":
                    // controlli su tutti i campi indirizzo che devono essere obbliagatori
                if (val == "") {
                    string err = " Indirizzo non valorizzato ma obbligatorio" + " alla riga " +  rownum;
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }
                else {
                    string cap       = riga["cap"].ToString();
                    string localita  = riga["localita"].ToString();
                    string provincia = riga["provincia"].ToString();
                    if ((cap == "") || (localita == "") || (provincia == "")) {
                        string err = "CAP/località/provincia non valorizzati ma obbligatori" +
                                     " alla riga " + rownum;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                }
                break;
                case "provincia":
                if ((val != "")&&(val.Length != 2)) {
                    string err = "La sigla della " + fieldname + " di tipo " + ftype + " e di valore " +
                           val.Trim() + " alla riga " +  rownum + " deve essere di 2 caratteri";
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }
                break;
                case "datanasc": 
                      // controllo della data 
                    if (!controllaData(val) && (val!="")) {
                         string err = "Valore non previsto nella decodifica della data " + fieldname + " di tipo " + ftype + " e di valore " +
                            val.Trim() + " alla riga " +  rownum;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                 break;   
                            
                case "iban":
                     // controllo validita IBAN
                if ((val != "")&&(val.ToUpper().Trim().StartsWith("IT"))) {
                    string IBAN = CfgFn.normalizzaIBAN(val.ToString());
                    if (!CfgFn.verificaIban(IBAN)|| IBAN.Length!=27) {
                        string err = "Valore non previsto nella decodifica del campo " + fieldname + " di tipo " + ftype + " e di valore " +
                        val.Trim()+ " alla riga " +  rownum;
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                }
                break;
                case "importo": 
                     // importo >=0
                    if (CfgFn.GetNoNullDecimal(val) <= 0) {
                        string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype + " e di valore " +
                        val.Trim() + " alla riga " +  rownum + ": inserire un importo maggiore di zero";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                    break;
                case "codicemodpagamento":
                    if ((CfgFn.GetNoNullDecimal(val)<0)||(CfgFn.GetNoNullDecimal(val)>5))
                    {
                        string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype + " e di valore " +
                        val.Trim() + " alla riga " + rownum + ": inserire un valore non superiore a 5";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                    break;
                case "tipologiacorso":
                    if ((CfgFn.GetNoNullInt32(val) < 0) || (CfgFn.GetNoNullInt32(val) > 8)) {
                        string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype + " e di valore " +
                        val.Trim() + " alla riga " + rownum + ": inserire un valore non superiore a 8";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                    break;
                case "annoaccademico":
                    //controlla che sia AAAA/AAAA
                    if (val != "") {
                        string[] AA = val.Split('/');
                        int eserc1 = CfgFn.GetNoNullInt32(AA[0]);
                        int eserc2 = CfgFn.GetNoNullInt32(AA[1]);
                        if (eserc2 != eserc1 + 1) {
                            string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype + " e di valore " +
                                val.Trim() + " alla riga " + rownum + ": inserire un valore nel formato AAAA/AAAA";
                            DataRow row = T.NewRow();
                            row["errors"] = err;
                            T.Rows.Add(row);
                            ok = false;
                        }
                    }
                    break;
                case "codicecorsouniversitario":
                    if ((val != "") && (val.Length > 16)) {
                        string err = "Il codice  " + fieldname + " di tipo " + ftype + " e di valore " +
                               val.Trim() + " alla riga " + rownum + " deve essere massimo di 16 caratteri";
                        DataRow row = T.NewRow();
                        row["errors"] = err;
                        T.Rows.Add(row);
                        ok = false;
                    }
                    break;
                case "causaleCBIdett": {
                    if (val != "") {
                        int codval = CfgFn.GetNoNullInt32(val);
                        bool ok_cbi = false;
                        // verifica se è uno dei valori codificati consentiti
                        string [] codici =  ff[4].Split('|');
                        for (int i = 0; i < codici.Length; i++) {
                            if (codval.ToString() == codici[i].ToString()) {
                                ok_cbi = true;
                                break;
                            }
                        }
                        
                        if (!ok_cbi) 
                        {
                                string err = "Valore non previsto nella decodifica del campo " + fieldname + " di tipo " + ftype + " e di valore " +
                                val.Trim() + " alla riga " +  rownum;
                                DataRow row = T.NewRow();
                                row["errors"] = err;
                                T.Rows.Add(row);
                                ok = false;
                         
                        }
                    }
                    break;
                   
                }
                         
                }
             }
             
             return ok;
        }

        private void fillPayDisposition (DataTable mData) {
            progressBarImport.Value = 0;
            progressBarImport.Maximum = mData.Rows.Count;
            progressBarImport.Visible = true;
            // riempie il Dataset con le righe dei dettagli delle disposizioni di pagamento
            // a partire dalla tabella temporanea mData
            if (DS.paydisposition.Rows.Count == 0) return;
            DataRow RCurr = DS.paydisposition.Rows[0];
            MetaData MetaDetail = MetaData.GetMetaData(this, "paydispositiondetail");
            foreach (DataRow rFile in mData.Select()) {
                DataRow rNew = MetaDetail.Get_New_Row(RCurr, DS.paydispositiondetail);
                rNew["surname"]  = TrimString(rFile["cognome"],true);
                rNew["forename"] = TrimString(rFile["nome"], true);
                string codicefiscale = "";
                if ((rFile["datanasc"] != DBNull.Value) && (controllaData(rFile["datanasc"].ToString()))) {
                    rNew["birthdate"] = rFile["datanasc"];
                }
                if (TrimString(rFile["cf"], true) != DBNull.Value)
                {
                    codicefiscale = TrimString(rFile["cf"], true).ToString().ToUpper();
                    rNew["cf"] = codicefiscale;
                    rNew["gender"] = InfoDaCodiceFiscale.Sesso(codicefiscale);
                    if (rNew["birthdate"] == DBNull.Value)
                    {
                        rNew["birthdate"] = InfoDaCodiceFiscale.DataNascita(Meta.Conn, codicefiscale);
                    }
                    string idcomune = InfoDaCodiceFiscale.Comune(Meta.Conn, codicefiscale);
                    if ((idcomune != null) && (idcomune != "")) {
                        rNew["idcity"] = idcomune;
                    }

                    string idnazione = InfoDaCodiceFiscale.Nazione(Meta.Conn, codicefiscale);
                    if ((idnazione != null) && (idnazione != "")) {
                        rNew["idnation"] = idnazione;
                    }
                }

                rNew["address"] = TrimString(rFile["indirizzo"], true);
                rNew["location"] = TrimString(rFile["localita"], true);
                rNew["province"] = TrimString(rFile["provincia"], true);
                rNew["cap"] = TrimString(rFile["cap"], true);
                rNew["motive"] = TrimString(rFile["causaledett"], true);
                rNew["amount"] = CfgFn.GetNoNullDecimal(rFile["importo"]);
                rNew["ct"] = DateTime.Now;
                rNew["cu"] = "Import";
                rNew["lt"] = DateTime.Now;
                rNew["lu"] = "Import";
                rNew["email"] = TrimString(rFile["email"],false);
                rNew["idcbimotive"] = TrimString(rFile["causaleCBIdett"], true);
                //Info relative al rimborso spese
                if (rFile.Table.Columns.Contains("rimborsotasse")) {
					rNew["flagtaxrefund"] = TrimString(rFile["rimborsotasse"], false);				
				}
				if (rNew["flagtaxrefund"] == DBNull.Value) rNew["flagtaxrefund"] = "N";
				if (rFile.Table.Columns.Contains("annoaccademico")) {
                    rNew["academicyear"] = EstraiAnnoAccademico(rFile["annoaccademico"]);
                }
                if (rFile.Table.Columns.Contains("annosolare")) {
                    rNew["calendaryear"] = TrimString(rFile["annosolare"], false);
                }
                if (rFile.Table.Columns.Contains("tipologiacorso")) {
                    rNew["degreekind"] = TrimString(rFile["tipologiacorso"], false);
                }
                if (rFile.Table.Columns.Contains("codicecorsouniversitario")) {
                    rNew["degreecode"] = TrimString(rFile["codicecorsouniversitario"], false);
                }
               
                string IBAN = CfgFn.normalizzaIBAN(TrimString(rFile["iban"], true).ToString().ToUpper());
                if (IBAN.Trim() == "") rNew["iban"] = DBNull.Value;
                else {
                    if (!IBAN.Trim().StartsWith("IT"))
                        rNew["iban"] = IBAN;
                    else {
                        if (CfgFn.verificaIban(IBAN)&& IBAN.Length==27) {
                            string BBAN = IBAN.Substring(4);
                            string CIN = BBAN.Substring(0, 1).ToUpper();
                            string ABI = BBAN.Substring(1, 5);
                            string CAB = BBAN.Substring(6, 5);
                            string CC = BBAN.Substring(11, 12);
                            rNew["abi"] = ABI;
                            rNew["cab"] = CAB;
                            rNew["cc"] = CC;
                            rNew["cin"] = CIN;
                            rNew["iban"] = IBAN;
                        }
                    }
                }
				int flag = 0;
				if (rFile.Table.Columns.Contains("esentespesebancarie")) {
					object esentespesebancarie =   rFile["esentespesebancarie"];
					if (esentespesebancarie.ToString() == "S") flag += 1;
				}
				if (rFile.Table.Columns.Contains("tipotrattamentospese")) {
					rNew["idchargehandling"] =  rFile["tipotrattamentospese"];
				}
				rNew["flag"] = flag;
				rNew["flaghuman"] = TrimString(rFile["personafisica"], true).ToString().ToUpper();
                rNew["title"] = TrimString(rFile["denominazione"], true);
                rNew["p_iva"] = TrimString(rFile["p_iva"], true);
                if (TrimString(rFile["personafisica"], true).ToString().ToUpper() == "S")
                {
                    rNew["title"] = DBNull.Value;
                }
                else {
                    rNew["surname"]  = DBNull.Value;
                    rNew["forename"] = DBNull.Value;
                }
                if (rFile.Table.Columns.Contains("codicepagamento"))
                {
                    rNew["paymentcode"] = TrimString(rFile["codicepagamento"], true);
                }

                int codicemodpagamento = 0;
                if (rFile.Table.Columns.Contains("codicemodpagamento"))
                {
                    codicemodpagamento = CfgFn.GetNoNullInt32(rFile["codicemodpagamento"]);
                }
                if (codicemodpagamento != 0)
                {
                    if ((IBAN.Trim() == "") && (codicemodpagamento == 1))  // 1 Bonifico, 2 Cassa
                        codicemodpagamento = 2;
                    if ((IBAN.Trim() != "") && (codicemodpagamento != 1))  // 1 Bonifico
                        codicemodpagamento = 1;
                    rNew["paymethodcode"] = codicemodpagamento;
                }
                else
                {
                    if (IBAN.Trim() == "")
                    {
                        rNew["paymethodcode"] = 2;  // cassa
                    }
                    else
                    {
                        rNew["paymethodcode"] = 1; // bonifico
                    }
                }
                progressBarImport.Value++;
            }
            progressBarImport.Visible = false;

        }
        private object  EstraiAnnoAccademico(object annoaccademico){
        if (annoaccademico == DBNull.Value) return annoaccademico;
            string[] AA = annoaccademico.ToString().Split('/');
                string eserc1 = AA[0];
                string eserc2 = AA[1];
                return eserc1;
    }
        private bool controllaData (string txtData) {
            try {
                DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime),
                    txtData, "x.y");
                return true;
            }
            catch {
                return false;
            }
        }

        private void GeneraFileSpeseUniversitarie(DataTable DT, string filename) {
            StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.GetEncoding(1252));
            foreach (DataRow rFile in DT.Select()) {
                string riga = rFile["riga"].ToString();
                sw.WriteLine(riga);
            }
            sw.Close();
            MessageBox.Show("File salvato in " + filename, "Informazioni", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool DatiCorretti() {
            object publicagency = Meta.Conn.DO_READ_VALUE("uniconfig", null, "publicagency");
            if (publicagency.ToString() == "") {
                MessageBox.Show(this, "Indicare il Tipo Univesità nella Configurazione Pluriennale.");
                return false;
            }
            return true;

        }
        private void btnRimborsoSpeseUniversitarie_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            if (!Meta.GetFormData(false))
                return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MessageBox.Show(this, "Per generare il file occorre prima SALVARE");
                return;
            }
            if (DS.paydispositiondetail.Select(QHC.CmpEq("flagtaxrefund", 'S')).Length == 0) {
                MessageBox.Show(this, "Non ci sono disposizioni marcate come Rimborso Spese.");
                return;
            }
            if(!DatiCorretti())
                return;
            DataRow Curr = DS.paydisposition.Rows[0];
            object idpaydisposition = Curr["idpaydisposition"];
            
            // definizione file da creare
            SaveFileDialog dlg = new SaveFileDialog();
            string filename = "";
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            if (filename == "")
                return;

            object[] param = new object[] { idpaydisposition };

            DataSet DSspeserimborsate = Meta.Conn.CallSP("compute_paydispositionrefund", param, true);
            if (DSspeserimborsate == null || DSspeserimborsate.Tables.Count == 0)
                return;
            DataTable Tsr = DSspeserimborsate.Tables[0];
            GeneraFileSpeseUniversitarie(Tsr, filename);
               
        }

      
        private void MenuVisualizza_Click(object sender, EventArgs e) {
            if (sender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
            object mysender = ((MenuItem)sender).Parent.GetContextMenu().SourceControl;
            string tracciato = "";
            DataTable TableTracciato = null;

            tracciato = GetTracciato(tracciato_disppagamento);
            TableTracciato = GetTableTracciato(tracciato_disppagamento);
            FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
            FT.ShowDialog();

        }

        public string GetTracciato(string[] tracciato) {
            string res = "";
            int pos = 0;
            foreach (string t in tracciato)
            {
                string[] ss = t.Split(';');
                string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
                               ss[3].PadLeft(4) +
                               " Tipo: " + ss[2].PadLeft(15);
                if (ss[2].ToLower() == "codificato")
                {
                    field += " Codifica:" + ss[4];
                }
                field += " Descrizione: " + ss[1];
                field += "\r\n";
                pos += CfgFn.GetNoNullInt32(ss[3]);
                res += field;
            }
            return res;
        }

        public DataTable GetTableTracciato(string[] tracciato) {
            int pos = 0;
            DataTable T = new DataTable("t");
            T.Columns.Add("nome", typeof(string));
            T.Columns.Add("posizione", typeof(int));
            T.Columns.Add("lunghezza", typeof(string));
            T.Columns.Add("tipo", typeof(string));
            T.Columns.Add("codifica", typeof(string));
            T.Columns.Add("Descrizione", typeof(string));

            foreach (string t in tracciato)
            {
                DataRow r = T.NewRow();
                string[] ss = t.Split(';');
                r["nome"] = ss[0];
                r["posizione"] = pos;
                r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
                r["tipo"] = ss[2];
                if (ss.Length == 5) r["codifica"] = ss[4];
                r["Descrizione"] = ss[1];
                pos += CfgFn.GetNoNullInt32(ss[3]);
                T.Rows.Add(r);
            }
            return T;
        }

		DataRow GetGridRow(DataGrid G, int index) {

			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter = "";
			//string nomecampo= "idcsa_import";
			string nomecampo= "iddetail";
			//if (G.Name == "dgrEntiVersamento") nomecampo = "idreg_agency";
			filter = QHC.CmpEq(nomecampo, G[index, 0]);
			DataRow[] selectresult = MyTable.Select(filter);
			return (selectresult.Length > 0) ? selectresult[0] : null;
		}

		private DataRow[] GetGridSelectedRows(DataGrid G) {
			if (G.DataMember == null) return null;
			if (G.DataSource == null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp = MyTable.Select().Length;
			int numrighe = 0;
			int i;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					if (R["idexp"] != DBNull.Value) continue;
					numrighe++;
				}
			}

			DataRow[] Res = new DataRow[numrighe];
			int count = 0;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					if (R["idexp"] != DBNull.Value) {
						G.UnSelect(i);
						continue;
					}
					Res[count++] = R;
				}
			}

			return Res;
		}

		private void btnSelezionaTutto_Click(object sender, EventArgs e) {
		    int numrighetemp = DS.paydispositiondetail.Select().Length;
				for (int i = 0; i < numrighetemp; i++) {
				    DataRow R = GetGridRow(dgDetail, i);
                    if (R.RowState==DataRowState.Deleted)continue;
					if (R["idexp"]==DBNull.Value)
						dgDetail.Select(i); // seleziona righe da elaborare
					else
						dgDetail.UnSelect(i); // deseleziona righe da non elaborare 
				}
			Meta.FreshForm();
		}

	


		private void btnCreaMovimentiFinanziari_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			DataRow Curr = DS.paydisposition.Rows[0];
			DataRow[] RowSelected  = GetGridSelectedRows(dgDetail);
			DSFinancial.Clear();
			if (RowSelected.Length == 0) {
				MessageBox.Show("Selezionare almeno un dettaglio  non associato a movimenti finanziari");
				return;
			}
			WizCreaPagamenti F = new WizCreaPagamenti(RowSelected, Meta, Conn, DSFinancial);
			if (F.ShowDialog(this) != DialogResult.OK) return;
			if (F.SavedData) { 
				Conn.RUN_SELECT_INTO_TABLE(DS.paydispositiondetail, null, QHS.CmpEq("idpaydisposition",  Curr["idpaydisposition"]), null,false);
				Meta.FreshForm();
			}
		}
	}

}