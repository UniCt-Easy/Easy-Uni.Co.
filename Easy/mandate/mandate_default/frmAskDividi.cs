
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using System.Globalization;
using funzioni_configurazione;

namespace mandate_default
{
	/// <summary>
	/// Summary description for frmaskbban.
	/// </summary>
	public class frmAskDividi : MetaDataForm
	{
	
		MetaData  Meta;
		MetaDataDispatcher Disp;
		//DataTable upb;
		DataAccess Conn;
		public DataTable Info;
		decimal importo;
		decimal importoIva;
		decimal importoIndetraibile;
		decimal totaleRiga;
		DataRow Dettaglio;
		decimal exchangerate;
        private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox txtAmount5;
		public System.Windows.Forms.TextBox txtAmount3;
		public System.Windows.Forms.TextBox txtAmount1;
		public System.Windows.Forms.TextBox txtAmount2;
		public System.Windows.Forms.TextBox txtAmount4;
		public System.Windows.Forms.TextBox txtAmount9;
		public System.Windows.Forms.TextBox txtAmount6;
		public System.Windows.Forms.TextBox txtAmount8;
		public System.Windows.Forms.TextBox txtAmount10;
		public System.Windows.Forms.TextBox txtPerc5;
		public System.Windows.Forms.TextBox txtPerc3;
		public System.Windows.Forms.TextBox txtPerc1;
		public System.Windows.Forms.TextBox txtPerc2;
		public System.Windows.Forms.TextBox txtPerc4;
		public System.Windows.Forms.TextBox txtPerc9;
		public System.Windows.Forms.TextBox txtPerc6;
		public System.Windows.Forms.TextBox txtPerc8;
		public System.Windows.Forms.TextBox txtPerc10;
		public System.Windows.Forms.Button btnUpb1;
		public System.Windows.Forms.Button btnUpb5;
		public System.Windows.Forms.Button btnUpb3;
		public System.Windows.Forms.Button btnUpb2;
		public System.Windows.Forms.Button btnUpb4;
		public System.Windows.Forms.Button btnUpb6;
		public System.Windows.Forms.Button btnUpb8;
		public System.Windows.Forms.Button btnUpb9;
		public System.Windows.Forms.Button btnUpb10;
		public System.Windows.Forms.TextBox txtAmount7;
		public System.Windows.Forms.TextBox txtPerc7;
		public System.Windows.Forms.Button btnUpb7;
		private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
		public System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtTotale;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.TextBox txtIvaTotale;
		public System.Windows.Forms.TextBox txtIva7;
		public System.Windows.Forms.TextBox txtIva1;
		public System.Windows.Forms.TextBox txtIva2;
		public System.Windows.Forms.TextBox txtIva3;
		public System.Windows.Forms.TextBox txtIva4;
		public System.Windows.Forms.TextBox txtIva5;
		public System.Windows.Forms.TextBox txtIva6;
		public System.Windows.Forms.TextBox txtIva8;
		public System.Windows.Forms.TextBox txtIva9;
		public System.Windows.Forms.TextBox txtIva10;
		public System.Windows.Forms.TextBox txtIvaMax;
		public System.Windows.Forms.TextBox txtPercMax;
		public System.Windows.Forms.TextBox txtImponibileMax;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label16;
		public System.Windows.Forms.TextBox txtIvaResidua;
		public System.Windows.Forms.TextBox txtImponResiduo;
		public System.Windows.Forms.TextBox txtEsercizio;
		public System.Windows.Forms.TextBox txtNumero;
		public System.Windows.Forms.TextBox txtRiga;
		private System.Windows.Forms.TextBox txtDescrizione;
		public System.Windows.Forms.TextBox txtTipo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		public System.Windows.Forms.TextBox txtIndetrMax;
		public System.Windows.Forms.TextBox txtIndetrTotale;
		public System.Windows.Forms.TextBox txtIndetr7;
		public System.Windows.Forms.TextBox txtIndetr1;
		public System.Windows.Forms.TextBox txtIndetr2;
		public System.Windows.Forms.TextBox txtIndetr3;
		public System.Windows.Forms.TextBox txtIndetr4;
		public System.Windows.Forms.TextBox txtIndetr5;
		public System.Windows.Forms.TextBox txtIndetr6;
		public System.Windows.Forms.TextBox txtIndetr8;
		public System.Windows.Forms.TextBox txtIndetr9;
		public System.Windows.Forms.TextBox txtIndetr10;
		public System.Windows.Forms.TextBox txtIndetrResidua;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		public System.Windows.Forms.TextBox txtTotaleRigaMax;
		public System.Windows.Forms.TextBox txtTotaleRiga1;
		public System.Windows.Forms.TextBox txtTotaleRiga2;
		public System.Windows.Forms.TextBox txtTotaleRiga3;
		public System.Windows.Forms.TextBox txtTotaleRiga4;
		public System.Windows.Forms.TextBox txtTotaleRiga5;
		public System.Windows.Forms.TextBox txtTotaleRiga6;
		public System.Windows.Forms.TextBox txtTotaleRiga7;
		public System.Windows.Forms.TextBox txtTotaleRiga8;
		public System.Windows.Forms.TextBox txtTotaleRiga9;
		public System.Windows.Forms.TextBox txtTotaleRiga10;
		public System.Windows.Forms.TextBox txtTotaleRigaSuddiv;
		public System.Windows.Forms.TextBox txtTotaleRigaResiduo;
		/// <date>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label labelImponibile;

		decimal TotaleImponibile;
        CQueryHelper QHC;
        public TextBox txtQuantitaConfezioni;
        private Label label4;
        public TextBox txtUpb1;
        QueryHelper QHS;
        public TextBox txtUpb2;
        public TextBox txtUpb3;
        public TextBox txtUpb4;
        public TextBox txtUpb5;
        public TextBox txtUpb6;
        public TextBox txtUpb7;
        public TextBox txtUpb8;
        public TextBox txtUpb9;
        public TextBox txtUpb10;
        public DataRow SelectedUpb;
        bool destroyed = false;
        public void Destroy() {
            if (destroyed) return;
            destroyed = true;
            MetaData.UnregisterAllEvents(this);
           

            this.Conn = null;
            this.QHS = null;
            this.QHC = null;
            this.SelectedUpb = null;
            this.Meta = null;
           
        }

        public frmAskDividi(DataRow Ordine, DataRow RigaSelezionata,MetaData Meta,MetaDataDispatcher Disp)
		{
			InitializeComponent();
			this.Meta = Meta; 
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			//upb = Conn.CreateTableByName("upb","*",false);
			//GetData.MarkToAddBlankRow(upb);
			//GetData.Add_Blank_Row(upb);
			//Conn.RUN_SELECT_INTO_TABLE(upb,null,null,null,true);
			this.importo = CfgFn.GetNoNullDecimal(RigaSelezionata["taxable"]);
			this.importoIva = CfgFn.GetNoNullDecimal(RigaSelezionata["tax"]);
			this.importoIndetraibile = CfgFn.GetNoNullDecimal(RigaSelezionata["unabatable"]);
			this.Disp = Disp;
			this.Dettaglio = RigaSelezionata;
			//DataRow Ordine = RigaSelezionata.GetParentRow("mandatemandatedetail");
			// Calcola il totale Riga
			decimal discount     =  CfgFn.GetNoNullDecimal(RigaSelezionata["discount"]);
            decimal npackage = CfgFn.GetNoNullDecimal(RigaSelezionata["npackage"]);
			exchangerate		 =  CfgFn.GetNoNullDecimal(Ordine["exchangerate"]);
            string codecurrency = Meta.Conn.DO_READ_VALUE("currency", QHS.CmpEq("idcurrency", Ordine["idcurrency"]), "codecurrency").ToString();
			if (codecurrency!="EUR") labelImponibile.Text =  labelImponibile.Text + " " + codecurrency;

            TotaleImponibile = CfgFn.RoundValuta(importo * npackage * (1 - discount) * exchangerate);
			totaleRiga       = TotaleImponibile + importoIva ;

		  
            //SetDataSourceCmb();
            txtAmount1.Text = ImpoStr(this.importo);
            txtIva1.Text = IvaStr(this.importoIva);

            txtIndetr1.Text = IvaStr(importoIndetraibile);
            txtTotaleRiga1.Text = TotaleRigaStr(totaleRiga);
			decimal percentuale = 100;
			percentuale = Math.Round(percentuale, 4);
            txtPerc1.Text = HelpForm.StringValue(percentuale, "x.y.fixed.4...1");

            txtTotale.Text = ImpoStr(this.importo);
            txtIvaTotale.Text = IvaStr(this.importoIva);
            txtIndetrTotale.Text = IvaStr(importoIndetraibile);
            txtTotaleRigaSuddiv.Text = TotaleRigaStr(totaleRiga);

            txtPercMax.Text = HelpForm.StringValue(percentuale, "x.y.fixed.4...1");
            txtImponibileMax.Text = ImpoStr(this.importo);
            txtIvaMax.Text = IvaStr(this.importoIva);
            txtIndetrMax.Text = IvaStr(importoIndetraibile);
            txtTotaleRigaMax.Text = TotaleRigaStr(totaleRiga);
			
			object mandatekind=Conn.DO_READ_VALUE("mandatekind",
				"(idmankind="+QueryCreator.quotedstrvalue(RigaSelezionata["idmankind"],true)+")","description");
			txtTipo.Text = mandatekind.ToString();
			txtEsercizio.Text = RigaSelezionata["yman"].ToString();
			txtNumero.Text = RigaSelezionata["nman"].ToString();
			txtRiga.Text = RigaSelezionata["rownum"].ToString();
			txtDescrizione.Text = RigaSelezionata["detaildescription"].ToString();
            txtQuantitaConfezioni.Text = RigaSelezionata["npackage"].ToString();
		}

        public frmAskDividi(DataRow Ordine, DataRow [] listaSplit, MetaData Meta, MetaDataDispatcher Disp) {
            InitializeComponent();
            this.Meta = Meta;
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            //upb = Conn.CreateTableByName("upb", "*", false);
            //GetData.MarkToAddBlankRow(upb);
            //GetData.Add_Blank_Row(upb);
            //Conn.RUN_SELECT_INTO_TABLE(upb, null, null, null, true);
            
            foreach (DataRow rDetail in listaSplit) {
                importo += CfgFn.GetNoNullDecimal(rDetail["taxable"]);
                importoIva += CfgFn.GetNoNullDecimal(rDetail["tax"]);
                importoIndetraibile += CfgFn.GetNoNullDecimal(rDetail["unabatable"]);
            }
            
            this.Disp = Disp;

            DataRow RigaSelezionata = listaSplit[0];

            this.Dettaglio = RigaSelezionata;
            //DataRow Ordine = RigaSelezionata.GetParentRow("mandatemandatedetail");
            // Calcola il totale Riga
            decimal discount = CfgFn.GetNoNullDecimal(RigaSelezionata["discount"]);
            decimal npackage = CfgFn.GetNoNullDecimal(RigaSelezionata["npackage"]);
            exchangerate = 1;
            if (Ordine != null) {
                exchangerate= CfgFn.GetNoNullDecimal(Ordine["exchangerate"]);
                object codecurrency = Meta.Conn.DO_READ_VALUE("currency",
                                          QHS.CmpEq("idcurrency", Ordine["idcurrency"]), "codecurrency") ?? "EUR";
                if (codecurrency.ToString() != "EUR") labelImponibile.Text = labelImponibile.Text + " " + codecurrency;
            }
       

            TotaleImponibile = CfgFn.RoundValuta(importo * npackage * (1 - discount) * exchangerate);
            totaleRiga = TotaleImponibile + importoIva;

            
            //SetDataSourceCmb();

            decimal percentuale = 100;
            percentuale = Math.Round(percentuale, 4);

            txtTotale.Text = ImpoStr(importo);
            txtIvaTotale.Text = IvaStr(importoIva);
            txtIndetrTotale.Text = IvaStr(importoIndetraibile);
            txtTotaleRigaSuddiv.Text = TotaleRigaStr(totaleRiga);

            txtPercMax.Text = HelpForm.StringValue(percentuale, "x.y.fixed.4...1");
            txtImponibileMax.Text = ImpoStr(importo);
            txtIvaMax.Text = IvaStr(importoIva);
            txtIndetrMax.Text = IvaStr(importoIndetraibile);
            txtTotaleRigaMax.Text = TotaleRigaStr(totaleRiga);

            fillOggetti(listaSplit);

            object mandatekind = Conn.DO_READ_VALUE("mandatekind",
                QHS.CmpEq("idmankind", RigaSelezionata["idmankind"]), "description");
            if (mandatekind != null) {
                txtTipo.Text = mandatekind.ToString();
            }
            txtEsercizio.Text = RigaSelezionata["yman"].ToString();
            txtNumero.Text = RigaSelezionata["nman"].ToString();
            txtRiga.Text = RigaSelezionata["rownum"].ToString();
            txtDescrizione.Text = RigaSelezionata["detaildescription"].ToString();
            txtQuantitaConfezioni.Text = RigaSelezionata["npackage"].ToString();
        }

        private bool isNumeric (string str, out int valore){
            valore = 0;
            try {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch {
                return false;
            }
        }

        private void fillOggetti(DataRow[] Detail) {
            const int Max1 = 10;
            const int Max2 = 5;
            
            TextBox[,] T_Array = new TextBox[Max1,Max2];
            TextBox[] T_Upb = new TextBox[Max1];
            Button[] B_Upb = new Button[Max1];

            const int posPerc = 0;
            const int posAmount = 1;
            const int posIva = 2;
            const int posIndetr = 3;
            const int posTotale = 4;

            int valore = 0;
            string nome = "";
            foreach (Control controllo in this.Controls) {
                string tipoOggetto = controllo.GetType().Name;
                nome = controllo.Name;
                switch (tipoOggetto) {
                    case "TextBox": {
                        if (nome.StartsWith("txtUpb")) {
                            int len = "txtUpb".Length;
                            if ((nome.Length > len) &&
                                (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Upb[valore - 1] = (TextBox)controllo;
                                continue;
                            }
                        }

                            if (nome.StartsWith("txtPerc")) {
                                int len = "txtPerc".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Array[valore - 1, posPerc] = (TextBox)controllo;
                                    continue;
                                }
                            }

                            if (nome.StartsWith("txtAmount")) {
                                int len = "txtAmount".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Array[valore - 1,posAmount] = (TextBox)controllo;
                                    continue;
                                }
                            }

                            if (nome.StartsWith("txtIva")) {
                                int len = "txtIva".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Array[valore - 1,posIva] = (TextBox)controllo;
                                    continue;
                                }
                            }

                            if (nome.StartsWith("txtIndetr")) {
                                int len = "txtIndetr".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Array[valore - 1, posIndetr] = (TextBox)controllo;
                                    continue;
                                }
                            }

                            if (nome.StartsWith("txtTotaleRiga")) {
                                int len = "txtTotaleRiga".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    T_Array[valore - 1, posTotale] = (TextBox)controllo;
                                    continue;
                                }
                            }
                            
                            break;


                        }
                   
                    case "Button": {
                            if (nome.StartsWith("btnUpb")) {
                                int len = "btnUpb".Length;
                                if ((nome.Length > len) &&
                                    (isNumeric(nome.Substring(len, nome.Length - len), out valore))) {
                                    B_Upb[valore - 1] = (Button)controllo;
                                    continue;
                                }
                            }
                            break;
                        }
                }
            }

            int nCiclo = 0;
            decimal importoAllDetail = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal),
                txtTotale.Text, "x.y.fixed.5...1"));
            foreach (DataRow rDetail in Detail) {
                decimal importo = CfgFn.GetNoNullDecimal(rDetail["taxable"]);
                decimal npackage = CfgFn.GetNoNullDecimal(rDetail["npackage"]);
                decimal discount = CfgFn.GetNoNullDecimal(rDetail["discount"]);

                decimal totImponibile = CfgFn.RoundValuta(importo * npackage * (1 - discount) * exchangerate);
                decimal importoIva = CfgFn.GetNoNullDecimal(rDetail["tax"]);
                decimal totaleRiga = totImponibile + importoIva;

                decimal percentuale = 100;
                decimal rounded = Math.Round(percentuale, 4);
                // calcola la percentuale in base all'importo
                if (importoAllDetail != 0) {
                    percentuale = importo / importoAllDetail;
                    rounded = Math.Round(percentuale, 4);
                }

                T_Array[nCiclo, posPerc].Text = PercentualeStr(rounded);
                T_Array[nCiclo, posAmount].Text = ImpoStr(CfgFn.GetNoNullDecimal(rDetail["taxable"]));
                T_Array[nCiclo, posIva].Text = IvaStr(CfgFn.GetNoNullDecimal(rDetail["tax"]));
                T_Array[nCiclo, posIndetr].Text = IvaStr(CfgFn.GetNoNullDecimal(rDetail["unabatable"]));
                T_Array[nCiclo, posTotale].Text = TotaleRigaStr(totaleRiga);

                T_Upb[nCiclo].Text = (rDetail["idupb"] != DBNull.Value) ? Conn.DO_READ_VALUE("upb",QHS.CmpEq("idupb",rDetail["idupb"]),"title").ToString() : "";
                T_Upb[nCiclo].Enabled = false;
                B_Upb[nCiclo].Enabled = false;
                nCiclo++;
            }

            // Tutti gli oggetti che sono superflui rispetto al numero di dettagli vengono disabilitati
            for (int i = Detail.Length; i < Max1; i++) {
                T_Array[i, posPerc].ReadOnly = true;
                T_Array[i, posAmount].ReadOnly = true;
                T_Array[i, posIva].ReadOnly = true;
                T_Array[i, posIndetr].ReadOnly = true;
                T_Array[i, posTotale].ReadOnly = true;
                T_Upb[i].Enabled = false;
                B_Upb[i].Enabled = false;
            }
        }

     

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.txtPerc5 = new System.Windows.Forms.TextBox();
            this.txtAmount5 = new System.Windows.Forms.TextBox();
            this.btnUpb5 = new System.Windows.Forms.Button();
            this.txtPerc3 = new System.Windows.Forms.TextBox();
            this.txtAmount3 = new System.Windows.Forms.TextBox();
            this.btnUpb3 = new System.Windows.Forms.Button();
            this.txtPerc1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.labelImponibile = new System.Windows.Forms.Label();
            this.btnUpb1 = new System.Windows.Forms.Button();
            this.txtPerc2 = new System.Windows.Forms.TextBox();
            this.txtAmount2 = new System.Windows.Forms.TextBox();
            this.btnUpb2 = new System.Windows.Forms.Button();
            this.txtPerc4 = new System.Windows.Forms.TextBox();
            this.txtAmount4 = new System.Windows.Forms.TextBox();
            this.btnUpb4 = new System.Windows.Forms.Button();
            this.txtPerc9 = new System.Windows.Forms.TextBox();
            this.txtAmount9 = new System.Windows.Forms.TextBox();
            this.btnUpb9 = new System.Windows.Forms.Button();
            this.txtPerc6 = new System.Windows.Forms.TextBox();
            this.txtAmount6 = new System.Windows.Forms.TextBox();
            this.btnUpb6 = new System.Windows.Forms.Button();
            this.txtPerc8 = new System.Windows.Forms.TextBox();
            this.txtAmount8 = new System.Windows.Forms.TextBox();
            this.btnUpb8 = new System.Windows.Forms.Button();
            this.txtPerc10 = new System.Windows.Forms.TextBox();
            this.txtAmount10 = new System.Windows.Forms.TextBox();
            this.btnUpb10 = new System.Windows.Forms.Button();
            this.btnUpb7 = new System.Windows.Forms.Button();
            this.txtAmount7 = new System.Windows.Forms.TextBox();
            this.txtPerc7 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtIvaTotale = new System.Windows.Forms.TextBox();
            this.txtIva7 = new System.Windows.Forms.TextBox();
            this.txtIva1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIva2 = new System.Windows.Forms.TextBox();
            this.txtIva3 = new System.Windows.Forms.TextBox();
            this.txtIva4 = new System.Windows.Forms.TextBox();
            this.txtIva5 = new System.Windows.Forms.TextBox();
            this.txtIva6 = new System.Windows.Forms.TextBox();
            this.txtIva8 = new System.Windows.Forms.TextBox();
            this.txtIva9 = new System.Windows.Forms.TextBox();
            this.txtIva10 = new System.Windows.Forms.TextBox();
            this.txtIvaMax = new System.Windows.Forms.TextBox();
            this.txtPercMax = new System.Windows.Forms.TextBox();
            this.txtImponibileMax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIvaResidua = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtImponResiduo = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtRiga = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIndetrResidua = new System.Windows.Forms.TextBox();
            this.txtIndetrMax = new System.Windows.Forms.TextBox();
            this.txtIndetrTotale = new System.Windows.Forms.TextBox();
            this.txtIndetr7 = new System.Windows.Forms.TextBox();
            this.txtIndetr1 = new System.Windows.Forms.TextBox();
            this.txtIndetr2 = new System.Windows.Forms.TextBox();
            this.txtIndetr3 = new System.Windows.Forms.TextBox();
            this.txtIndetr4 = new System.Windows.Forms.TextBox();
            this.txtIndetr5 = new System.Windows.Forms.TextBox();
            this.txtIndetr6 = new System.Windows.Forms.TextBox();
            this.txtIndetr8 = new System.Windows.Forms.TextBox();
            this.txtIndetr9 = new System.Windows.Forms.TextBox();
            this.txtIndetr10 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTotaleRigaMax = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga1 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga2 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga4 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga3 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga6 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga5 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga8 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga7 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga10 = new System.Windows.Forms.TextBox();
            this.txtTotaleRiga9 = new System.Windows.Forms.TextBox();
            this.txtTotaleRigaResiduo = new System.Windows.Forms.TextBox();
            this.txtTotaleRigaSuddiv = new System.Windows.Forms.TextBox();
            this.txtUpb1 = new System.Windows.Forms.TextBox();
            this.txtUpb2 = new System.Windows.Forms.TextBox();
            this.txtUpb3 = new System.Windows.Forms.TextBox();
            this.txtUpb4 = new System.Windows.Forms.TextBox();
            this.txtUpb5 = new System.Windows.Forms.TextBox();
            this.txtUpb6 = new System.Windows.Forms.TextBox();
            this.txtUpb7 = new System.Windows.Forms.TextBox();
            this.txtUpb8 = new System.Windows.Forms.TextBox();
            this.txtUpb9 = new System.Windows.Forms.TextBox();
            this.txtUpb10 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPerc5
            // 
            this.txtPerc5.Location = new System.Drawing.Point(296, 280);
            this.txtPerc5.Name = "txtPerc5";
            this.txtPerc5.Size = new System.Drawing.Size(64, 20);
            this.txtPerc5.TabIndex = 28;
            this.txtPerc5.Tag = "";
            this.txtPerc5.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount5
            // 
            this.txtAmount5.Location = new System.Drawing.Point(368, 280);
            this.txtAmount5.Name = "txtAmount5";
            this.txtAmount5.Size = new System.Drawing.Size(72, 20);
            this.txtAmount5.TabIndex = 29;
            this.txtAmount5.Tag = "";
            this.txtAmount5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount5.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb5
            // 
            this.btnUpb5.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb5.Location = new System.Drawing.Point(40, 280);
            this.btnUpb5.Name = "btnUpb5";
            this.btnUpb5.Size = new System.Drawing.Size(72, 23);
            this.btnUpb5.TabIndex = 26;
            this.btnUpb5.TabStop = false;
            this.btnUpb5.Tag = "";
            this.btnUpb5.Text = "UPB:";
            this.btnUpb5.UseVisualStyleBackColor = false;
            this.btnUpb5.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc3
            // 
            this.txtPerc3.Location = new System.Drawing.Point(296, 216);
            this.txtPerc3.Name = "txtPerc3";
            this.txtPerc3.Size = new System.Drawing.Size(64, 20);
            this.txtPerc3.TabIndex = 15;
            this.txtPerc3.Tag = "";
            this.txtPerc3.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount3
            // 
            this.txtAmount3.Location = new System.Drawing.Point(368, 216);
            this.txtAmount3.Name = "txtAmount3";
            this.txtAmount3.Size = new System.Drawing.Size(72, 20);
            this.txtAmount3.TabIndex = 16;
            this.txtAmount3.Tag = "";
            this.txtAmount3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount3.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb3
            // 
            this.btnUpb3.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb3.Location = new System.Drawing.Point(40, 216);
            this.btnUpb3.Name = "btnUpb3";
            this.btnUpb3.Size = new System.Drawing.Size(72, 23);
            this.btnUpb3.TabIndex = 13;
            this.btnUpb3.TabStop = false;
            this.btnUpb3.Tag = "";
            this.btnUpb3.Text = "UPB:";
            this.btnUpb3.UseVisualStyleBackColor = false;
            this.btnUpb3.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc1
            // 
            this.txtPerc1.Location = new System.Drawing.Point(296, 152);
            this.txtPerc1.Name = "txtPerc1";
            this.txtPerc1.Size = new System.Drawing.Size(64, 20);
            this.txtPerc1.TabIndex = 3;
            this.txtPerc1.Tag = "";
            this.txtPerc1.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 85;
            this.label3.Text = "%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAmount1
            // 
            this.txtAmount1.Location = new System.Drawing.Point(368, 152);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(72, 20);
            this.txtAmount1.TabIndex = 4;
            this.txtAmount1.Tag = "";
            this.txtAmount1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount1.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // labelImponibile
            // 
            this.labelImponibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImponibile.Location = new System.Drawing.Point(368, 80);
            this.labelImponibile.Name = "labelImponibile";
            this.labelImponibile.Size = new System.Drawing.Size(72, 23);
            this.labelImponibile.TabIndex = 83;
            this.labelImponibile.Text = "Imponibile:";
            this.labelImponibile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpb1
            // 
            this.btnUpb1.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb1.Location = new System.Drawing.Point(40, 152);
            this.btnUpb1.Name = "btnUpb1";
            this.btnUpb1.Size = new System.Drawing.Size(72, 23);
            this.btnUpb1.TabIndex = 1;
            this.btnUpb1.TabStop = false;
            this.btnUpb1.Tag = "";
            this.btnUpb1.Text = "UPB:";
            this.btnUpb1.UseVisualStyleBackColor = false;
            this.btnUpb1.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc2
            // 
            this.txtPerc2.Location = new System.Drawing.Point(296, 184);
            this.txtPerc2.Name = "txtPerc2";
            this.txtPerc2.Size = new System.Drawing.Size(64, 20);
            this.txtPerc2.TabIndex = 9;
            this.txtPerc2.Tag = "";
            this.txtPerc2.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount2
            // 
            this.txtAmount2.Location = new System.Drawing.Point(368, 184);
            this.txtAmount2.Name = "txtAmount2";
            this.txtAmount2.Size = new System.Drawing.Size(72, 20);
            this.txtAmount2.TabIndex = 10;
            this.txtAmount2.Tag = "";
            this.txtAmount2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount2.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb2
            // 
            this.btnUpb2.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb2.Location = new System.Drawing.Point(40, 184);
            this.btnUpb2.Name = "btnUpb2";
            this.btnUpb2.Size = new System.Drawing.Size(72, 23);
            this.btnUpb2.TabIndex = 7;
            this.btnUpb2.TabStop = false;
            this.btnUpb2.Tag = "";
            this.btnUpb2.Text = "UPB:";
            this.btnUpb2.UseVisualStyleBackColor = false;
            this.btnUpb2.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc4
            // 
            this.txtPerc4.Location = new System.Drawing.Point(296, 248);
            this.txtPerc4.Name = "txtPerc4";
            this.txtPerc4.Size = new System.Drawing.Size(64, 20);
            this.txtPerc4.TabIndex = 21;
            this.txtPerc4.Tag = "";
            this.txtPerc4.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount4
            // 
            this.txtAmount4.Location = new System.Drawing.Point(368, 248);
            this.txtAmount4.Name = "txtAmount4";
            this.txtAmount4.Size = new System.Drawing.Size(72, 20);
            this.txtAmount4.TabIndex = 22;
            this.txtAmount4.Tag = "";
            this.txtAmount4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount4.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb4
            // 
            this.btnUpb4.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb4.Location = new System.Drawing.Point(40, 248);
            this.btnUpb4.Name = "btnUpb4";
            this.btnUpb4.Size = new System.Drawing.Size(72, 23);
            this.btnUpb4.TabIndex = 19;
            this.btnUpb4.TabStop = false;
            this.btnUpb4.Tag = "";
            this.btnUpb4.Text = "UPB:";
            this.btnUpb4.UseVisualStyleBackColor = false;
            this.btnUpb4.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc9
            // 
            this.txtPerc9.Location = new System.Drawing.Point(296, 408);
            this.txtPerc9.Name = "txtPerc9";
            this.txtPerc9.Size = new System.Drawing.Size(64, 20);
            this.txtPerc9.TabIndex = 52;
            this.txtPerc9.Tag = "";
            this.txtPerc9.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount9
            // 
            this.txtAmount9.Location = new System.Drawing.Point(368, 408);
            this.txtAmount9.Name = "txtAmount9";
            this.txtAmount9.Size = new System.Drawing.Size(72, 20);
            this.txtAmount9.TabIndex = 53;
            this.txtAmount9.Tag = "";
            this.txtAmount9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount9.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb9
            // 
            this.btnUpb9.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb9.Location = new System.Drawing.Point(40, 408);
            this.btnUpb9.Name = "btnUpb9";
            this.btnUpb9.Size = new System.Drawing.Size(72, 23);
            this.btnUpb9.TabIndex = 50;
            this.btnUpb9.TabStop = false;
            this.btnUpb9.Tag = "";
            this.btnUpb9.Text = "UPB:";
            this.btnUpb9.UseVisualStyleBackColor = false;
            this.btnUpb9.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc6
            // 
            this.txtPerc6.Location = new System.Drawing.Point(296, 312);
            this.txtPerc6.Name = "txtPerc6";
            this.txtPerc6.Size = new System.Drawing.Size(64, 20);
            this.txtPerc6.TabIndex = 34;
            this.txtPerc6.Tag = "";
            this.txtPerc6.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount6
            // 
            this.txtAmount6.Location = new System.Drawing.Point(368, 312);
            this.txtAmount6.Name = "txtAmount6";
            this.txtAmount6.Size = new System.Drawing.Size(72, 20);
            this.txtAmount6.TabIndex = 35;
            this.txtAmount6.Tag = "";
            this.txtAmount6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount6.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb6
            // 
            this.btnUpb6.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb6.Location = new System.Drawing.Point(40, 312);
            this.btnUpb6.Name = "btnUpb6";
            this.btnUpb6.Size = new System.Drawing.Size(72, 23);
            this.btnUpb6.TabIndex = 32;
            this.btnUpb6.TabStop = false;
            this.btnUpb6.Tag = "";
            this.btnUpb6.Text = "UPB:";
            this.btnUpb6.UseVisualStyleBackColor = false;
            this.btnUpb6.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc8
            // 
            this.txtPerc8.Location = new System.Drawing.Point(296, 376);
            this.txtPerc8.Name = "txtPerc8";
            this.txtPerc8.Size = new System.Drawing.Size(64, 20);
            this.txtPerc8.TabIndex = 46;
            this.txtPerc8.Tag = "";
            this.txtPerc8.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount8
            // 
            this.txtAmount8.Location = new System.Drawing.Point(368, 376);
            this.txtAmount8.Name = "txtAmount8";
            this.txtAmount8.Size = new System.Drawing.Size(72, 20);
            this.txtAmount8.TabIndex = 47;
            this.txtAmount8.Tag = "";
            this.txtAmount8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount8.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb8
            // 
            this.btnUpb8.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb8.Location = new System.Drawing.Point(40, 376);
            this.btnUpb8.Name = "btnUpb8";
            this.btnUpb8.Size = new System.Drawing.Size(72, 23);
            this.btnUpb8.TabIndex = 44;
            this.btnUpb8.TabStop = false;
            this.btnUpb8.Tag = "";
            this.btnUpb8.Text = "UPB:";
            this.btnUpb8.UseVisualStyleBackColor = false;
            this.btnUpb8.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtPerc10
            // 
            this.txtPerc10.Location = new System.Drawing.Point(296, 440);
            this.txtPerc10.Name = "txtPerc10";
            this.txtPerc10.Size = new System.Drawing.Size(64, 20);
            this.txtPerc10.TabIndex = 58;
            this.txtPerc10.Tag = "";
            this.txtPerc10.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // txtAmount10
            // 
            this.txtAmount10.Location = new System.Drawing.Point(368, 440);
            this.txtAmount10.Name = "txtAmount10";
            this.txtAmount10.Size = new System.Drawing.Size(72, 20);
            this.txtAmount10.TabIndex = 59;
            this.txtAmount10.Tag = "";
            this.txtAmount10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount10.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // btnUpb10
            // 
            this.btnUpb10.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb10.Location = new System.Drawing.Point(40, 440);
            this.btnUpb10.Name = "btnUpb10";
            this.btnUpb10.Size = new System.Drawing.Size(72, 23);
            this.btnUpb10.TabIndex = 56;
            this.btnUpb10.TabStop = false;
            this.btnUpb10.Tag = "";
            this.btnUpb10.Text = "UPB:";
            this.btnUpb10.UseVisualStyleBackColor = false;
            this.btnUpb10.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // btnUpb7
            // 
            this.btnUpb7.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb7.Location = new System.Drawing.Point(40, 344);
            this.btnUpb7.Name = "btnUpb7";
            this.btnUpb7.Size = new System.Drawing.Size(72, 23);
            this.btnUpb7.TabIndex = 38;
            this.btnUpb7.TabStop = false;
            this.btnUpb7.Tag = "";
            this.btnUpb7.Text = "UPB:";
            this.btnUpb7.UseVisualStyleBackColor = false;
            this.btnUpb7.Click += new System.EventHandler(this.SelezionaUpb);
            // 
            // txtAmount7
            // 
            this.txtAmount7.Location = new System.Drawing.Point(368, 344);
            this.txtAmount7.Name = "txtAmount7";
            this.txtAmount7.Size = new System.Drawing.Size(72, 20);
            this.txtAmount7.TabIndex = 41;
            this.txtAmount7.Tag = "";
            this.txtAmount7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount7.Leave += new System.EventHandler(this.ImportoLeave);
            // 
            // txtPerc7
            // 
            this.txtPerc7.Location = new System.Drawing.Point(296, 344);
            this.txtPerc7.Name = "txtPerc7";
            this.txtPerc7.Size = new System.Drawing.Size(64, 20);
            this.txtPerc7.TabIndex = 40;
            this.txtPerc7.Tag = "";
            this.txtPerc7.Leave += new System.EventHandler(this.PercentualeLeave);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(408, 224);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 0;
            // 
            // txtTotale
            // 
            this.txtTotale.Enabled = false;
            this.txtTotale.Location = new System.Drawing.Point(368, 488);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.Size = new System.Drawing.Size(72, 20);
            this.txtTotale.TabIndex = 92;
            this.txtTotale.Tag = "";
            this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 23);
            this.label1.TabIndex = 94;
            this.label1.Text = "Totale Suddiviso:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(616, 568);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 63;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(520, 568);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 62;
            this.btnOK.Tag = "";
            this.btnOK.Text = "OK";
            // 
            // txtIvaTotale
            // 
            this.txtIvaTotale.Enabled = false;
            this.txtIvaTotale.Location = new System.Drawing.Point(448, 488);
            this.txtIvaTotale.Name = "txtIvaTotale";
            this.txtIvaTotale.Size = new System.Drawing.Size(72, 20);
            this.txtIvaTotale.TabIndex = 108;
            this.txtIvaTotale.Tag = "";
            this.txtIvaTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIva7
            // 
            this.txtIva7.Location = new System.Drawing.Point(448, 344);
            this.txtIva7.Name = "txtIva7";
            this.txtIva7.Size = new System.Drawing.Size(72, 20);
            this.txtIva7.TabIndex = 42;
            this.txtIva7.Tag = "";
            this.txtIva7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva7.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva1
            // 
            this.txtIva1.Location = new System.Drawing.Point(448, 152);
            this.txtIva1.Name = "txtIva1";
            this.txtIva1.Size = new System.Drawing.Size(72, 20);
            this.txtIva1.TabIndex = 5;
            this.txtIva1.Tag = "";
            this.txtIva1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva1.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 97;
            this.label2.Text = "IVA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIva2
            // 
            this.txtIva2.Location = new System.Drawing.Point(448, 184);
            this.txtIva2.Name = "txtIva2";
            this.txtIva2.Size = new System.Drawing.Size(72, 20);
            this.txtIva2.TabIndex = 11;
            this.txtIva2.Tag = "";
            this.txtIva2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva2.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva3
            // 
            this.txtIva3.Location = new System.Drawing.Point(448, 216);
            this.txtIva3.Name = "txtIva3";
            this.txtIva3.Size = new System.Drawing.Size(72, 20);
            this.txtIva3.TabIndex = 17;
            this.txtIva3.Tag = "";
            this.txtIva3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva3.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva4
            // 
            this.txtIva4.Location = new System.Drawing.Point(448, 248);
            this.txtIva4.Name = "txtIva4";
            this.txtIva4.Size = new System.Drawing.Size(72, 20);
            this.txtIva4.TabIndex = 23;
            this.txtIva4.Tag = "";
            this.txtIva4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva4.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva5
            // 
            this.txtIva5.Location = new System.Drawing.Point(448, 280);
            this.txtIva5.Name = "txtIva5";
            this.txtIva5.Size = new System.Drawing.Size(72, 20);
            this.txtIva5.TabIndex = 30;
            this.txtIva5.Tag = "";
            this.txtIva5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva5.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva6
            // 
            this.txtIva6.Location = new System.Drawing.Point(448, 312);
            this.txtIva6.Name = "txtIva6";
            this.txtIva6.Size = new System.Drawing.Size(72, 20);
            this.txtIva6.TabIndex = 36;
            this.txtIva6.Tag = "";
            this.txtIva6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva6.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva8
            // 
            this.txtIva8.Location = new System.Drawing.Point(448, 376);
            this.txtIva8.Name = "txtIva8";
            this.txtIva8.Size = new System.Drawing.Size(72, 20);
            this.txtIva8.TabIndex = 48;
            this.txtIva8.Tag = "";
            this.txtIva8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva8.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva9
            // 
            this.txtIva9.Location = new System.Drawing.Point(448, 408);
            this.txtIva9.Name = "txtIva9";
            this.txtIva9.Size = new System.Drawing.Size(72, 20);
            this.txtIva9.TabIndex = 54;
            this.txtIva9.Tag = "";
            this.txtIva9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva9.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIva10
            // 
            this.txtIva10.Location = new System.Drawing.Point(448, 440);
            this.txtIva10.Name = "txtIva10";
            this.txtIva10.Size = new System.Drawing.Size(72, 20);
            this.txtIva10.TabIndex = 60;
            this.txtIva10.Tag = "";
            this.txtIva10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIva10.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIvaMax
            // 
            this.txtIvaMax.Enabled = false;
            this.txtIvaMax.Location = new System.Drawing.Point(448, 112);
            this.txtIvaMax.Name = "txtIvaMax";
            this.txtIvaMax.Size = new System.Drawing.Size(72, 20);
            this.txtIvaMax.TabIndex = 112;
            this.txtIvaMax.Tag = "";
            this.txtIvaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPercMax
            // 
            this.txtPercMax.Enabled = false;
            this.txtPercMax.Location = new System.Drawing.Point(296, 112);
            this.txtPercMax.Name = "txtPercMax";
            this.txtPercMax.Size = new System.Drawing.Size(64, 20);
            this.txtPercMax.TabIndex = 110;
            this.txtPercMax.Tag = "";
            // 
            // txtImponibileMax
            // 
            this.txtImponibileMax.Enabled = false;
            this.txtImponibileMax.Location = new System.Drawing.Point(368, 112);
            this.txtImponibileMax.Name = "txtImponibileMax";
            this.txtImponibileMax.Size = new System.Drawing.Size(72, 20);
            this.txtImponibileMax.TabIndex = 109;
            this.txtImponibileMax.Tag = "";
            this.txtImponibileMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 16);
            this.label6.TabIndex = 113;
            this.label6.Text = "1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 16);
            this.label7.TabIndex = 114;
            this.label7.Text = "2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 16);
            this.label8.TabIndex = 115;
            this.label8.Text = "3";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 16);
            this.label9.TabIndex = 116;
            this.label9.Text = "4";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 16);
            this.label10.TabIndex = 117;
            this.label10.Text = "5";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 16);
            this.label11.TabIndex = 118;
            this.label11.Text = "6";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 16);
            this.label12.TabIndex = 119;
            this.label12.Text = "7";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 384);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 16);
            this.label13.TabIndex = 120;
            this.label13.Text = "8";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 416);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 16);
            this.label14.TabIndex = 121;
            this.label14.Text = "9";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 448);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 16);
            this.label15.TabIndex = 122;
            this.label15.Text = "10";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(152, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 23);
            this.label5.TabIndex = 123;
            this.label5.Text = "Totale Dettaglio:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIvaResidua
            // 
            this.txtIvaResidua.Enabled = false;
            this.txtIvaResidua.Location = new System.Drawing.Point(448, 520);
            this.txtIvaResidua.Name = "txtIvaResidua";
            this.txtIvaResidua.Size = new System.Drawing.Size(72, 20);
            this.txtIvaResidua.TabIndex = 126;
            this.txtIvaResidua.Tag = "";
            this.txtIvaResidua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(232, 520);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 23);
            this.label16.TabIndex = 125;
            this.label16.Text = "Residuo:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImponResiduo
            // 
            this.txtImponResiduo.Enabled = false;
            this.txtImponResiduo.Location = new System.Drawing.Point(368, 520);
            this.txtImponResiduo.Name = "txtImponResiduo";
            this.txtImponResiduo.Size = new System.Drawing.Size(72, 20);
            this.txtImponResiduo.TabIndex = 124;
            this.txtImponResiduo.Tag = "";
            this.txtImponResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(208, 43);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(45, 20);
            this.txtEsercizio.TabIndex = 127;
            this.txtEsercizio.Tag = "";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(259, 43);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(48, 20);
            this.txtNumero.TabIndex = 128;
            this.txtNumero.Tag = "";
            this.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRiga
            // 
            this.txtRiga.Location = new System.Drawing.Point(312, 43);
            this.txtRiga.Name = "txtRiga";
            this.txtRiga.ReadOnly = true;
            this.txtRiga.Size = new System.Drawing.Size(48, 20);
            this.txtRiga.TabIndex = 129;
            this.txtRiga.Tag = "";
            this.txtRiga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(436, 32);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(260, 33);
            this.txtDescrizione.TabIndex = 131;
            this.txtDescrizione.Tag = "";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(32, 43);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(168, 20);
            this.txtTipo.TabIndex = 132;
            this.txtTipo.Tag = "";
            this.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtQuantitaConfezioni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Location = new System.Drawing.Point(16, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 71);
            this.groupBox1.TabIndex = 133;
            this.groupBox1.TabStop = false;
            // 
            // txtQuantitaConfezioni
            // 
            this.txtQuantitaConfezioni.Location = new System.Drawing.Point(350, 44);
            this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
            this.txtQuantitaConfezioni.ReadOnly = true;
            this.txtQuantitaConfezioni.Size = new System.Drawing.Size(64, 20);
            this.txtQuantitaConfezioni.TabIndex = 131;
            this.txtQuantitaConfezioni.Tag = "";
            this.txtQuantitaConfezioni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(350, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 26);
            this.label4.TabIndex = 130;
            this.label4.Text = "Totale Q.tà ordinata";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(422, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(104, 16);
            this.label21.TabIndex = 4;
            this.label21.Text = "Descrizione";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(296, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 3;
            this.label20.Text = "Riga";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(241, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 16);
            this.label19.TabIndex = 2;
            this.label19.Text = "Numero";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(190, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 16);
            this.label18.TabIndex = 1;
            this.label18.Text = "Esercizio";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(144, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tipo";
            // 
            // txtIndetrResidua
            // 
            this.txtIndetrResidua.Enabled = false;
            this.txtIndetrResidua.Location = new System.Drawing.Point(528, 520);
            this.txtIndetrResidua.Name = "txtIndetrResidua";
            this.txtIndetrResidua.Size = new System.Drawing.Size(72, 20);
            this.txtIndetrResidua.TabIndex = 146;
            this.txtIndetrResidua.Tag = "";
            this.txtIndetrResidua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIndetrMax
            // 
            this.txtIndetrMax.Enabled = false;
            this.txtIndetrMax.Location = new System.Drawing.Point(528, 112);
            this.txtIndetrMax.Name = "txtIndetrMax";
            this.txtIndetrMax.Size = new System.Drawing.Size(72, 20);
            this.txtIndetrMax.TabIndex = 145;
            this.txtIndetrMax.Tag = "";
            this.txtIndetrMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIndetrTotale
            // 
            this.txtIndetrTotale.Enabled = false;
            this.txtIndetrTotale.Location = new System.Drawing.Point(528, 488);
            this.txtIndetrTotale.Name = "txtIndetrTotale";
            this.txtIndetrTotale.Size = new System.Drawing.Size(72, 20);
            this.txtIndetrTotale.TabIndex = 144;
            this.txtIndetrTotale.Tag = "";
            this.txtIndetrTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIndetr7
            // 
            this.txtIndetr7.Location = new System.Drawing.Point(528, 344);
            this.txtIndetr7.Name = "txtIndetr7";
            this.txtIndetr7.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr7.TabIndex = 43;
            this.txtIndetr7.Tag = "";
            this.txtIndetr7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr7.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr1
            // 
            this.txtIndetr1.Location = new System.Drawing.Point(528, 152);
            this.txtIndetr1.Name = "txtIndetr1";
            this.txtIndetr1.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr1.TabIndex = 6;
            this.txtIndetr1.Tag = "";
            this.txtIndetr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr1.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr2
            // 
            this.txtIndetr2.Location = new System.Drawing.Point(528, 184);
            this.txtIndetr2.Name = "txtIndetr2";
            this.txtIndetr2.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr2.TabIndex = 12;
            this.txtIndetr2.Tag = "";
            this.txtIndetr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr2.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr3
            // 
            this.txtIndetr3.Location = new System.Drawing.Point(528, 216);
            this.txtIndetr3.Name = "txtIndetr3";
            this.txtIndetr3.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr3.TabIndex = 18;
            this.txtIndetr3.Tag = "";
            this.txtIndetr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr3.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr4
            // 
            this.txtIndetr4.Location = new System.Drawing.Point(528, 248);
            this.txtIndetr4.Name = "txtIndetr4";
            this.txtIndetr4.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr4.TabIndex = 24;
            this.txtIndetr4.Tag = "";
            this.txtIndetr4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr4.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr5
            // 
            this.txtIndetr5.Location = new System.Drawing.Point(528, 280);
            this.txtIndetr5.Name = "txtIndetr5";
            this.txtIndetr5.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr5.TabIndex = 31;
            this.txtIndetr5.Tag = "";
            this.txtIndetr5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr5.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr6
            // 
            this.txtIndetr6.Location = new System.Drawing.Point(528, 312);
            this.txtIndetr6.Name = "txtIndetr6";
            this.txtIndetr6.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr6.TabIndex = 37;
            this.txtIndetr6.Tag = "";
            this.txtIndetr6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr6.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr8
            // 
            this.txtIndetr8.Location = new System.Drawing.Point(528, 376);
            this.txtIndetr8.Name = "txtIndetr8";
            this.txtIndetr8.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr8.TabIndex = 49;
            this.txtIndetr8.Tag = "";
            this.txtIndetr8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr8.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr9
            // 
            this.txtIndetr9.Location = new System.Drawing.Point(528, 408);
            this.txtIndetr9.Name = "txtIndetr9";
            this.txtIndetr9.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr9.TabIndex = 55;
            this.txtIndetr9.Tag = "";
            this.txtIndetr9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr9.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // txtIndetr10
            // 
            this.txtIndetr10.Location = new System.Drawing.Point(528, 440);
            this.txtIndetr10.Name = "txtIndetr10";
            this.txtIndetr10.Size = new System.Drawing.Size(72, 20);
            this.txtIndetr10.TabIndex = 61;
            this.txtIndetr10.Tag = "";
            this.txtIndetr10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIndetr10.Leave += new System.EventHandler(this.IvaLeave);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(520, 80);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 29);
            this.label22.TabIndex = 147;
            this.label22.Text = "IVA Indetraibile:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(616, 80);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 23);
            this.label23.TabIndex = 161;
            this.label23.Text = "Totale Riga:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotaleRigaMax
            // 
            this.txtTotaleRigaMax.Enabled = false;
            this.txtTotaleRigaMax.Location = new System.Drawing.Point(608, 112);
            this.txtTotaleRigaMax.Name = "txtTotaleRigaMax";
            this.txtTotaleRigaMax.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRigaMax.TabIndex = 159;
            this.txtTotaleRigaMax.Tag = "";
            this.txtTotaleRigaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleRiga1
            // 
            this.txtTotaleRiga1.Location = new System.Drawing.Point(608, 152);
            this.txtTotaleRiga1.Name = "txtTotaleRiga1";
            this.txtTotaleRiga1.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga1.TabIndex = 7;
            this.txtTotaleRiga1.Tag = "";
            this.txtTotaleRiga1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga1.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga2
            // 
            this.txtTotaleRiga2.Location = new System.Drawing.Point(608, 184);
            this.txtTotaleRiga2.Name = "txtTotaleRiga2";
            this.txtTotaleRiga2.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga2.TabIndex = 163;
            this.txtTotaleRiga2.Tag = "";
            this.txtTotaleRiga2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga2.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga4
            // 
            this.txtTotaleRiga4.Location = new System.Drawing.Point(608, 248);
            this.txtTotaleRiga4.Name = "txtTotaleRiga4";
            this.txtTotaleRiga4.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga4.TabIndex = 165;
            this.txtTotaleRiga4.Tag = "";
            this.txtTotaleRiga4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga4.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga3
            // 
            this.txtTotaleRiga3.Location = new System.Drawing.Point(608, 216);
            this.txtTotaleRiga3.Name = "txtTotaleRiga3";
            this.txtTotaleRiga3.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga3.TabIndex = 164;
            this.txtTotaleRiga3.Tag = "";
            this.txtTotaleRiga3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga3.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga6
            // 
            this.txtTotaleRiga6.Location = new System.Drawing.Point(608, 312);
            this.txtTotaleRiga6.Name = "txtTotaleRiga6";
            this.txtTotaleRiga6.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga6.TabIndex = 167;
            this.txtTotaleRiga6.Tag = "";
            this.txtTotaleRiga6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga6.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga5
            // 
            this.txtTotaleRiga5.Location = new System.Drawing.Point(608, 280);
            this.txtTotaleRiga5.Name = "txtTotaleRiga5";
            this.txtTotaleRiga5.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga5.TabIndex = 166;
            this.txtTotaleRiga5.Tag = "";
            this.txtTotaleRiga5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga5.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga8
            // 
            this.txtTotaleRiga8.Location = new System.Drawing.Point(608, 376);
            this.txtTotaleRiga8.Name = "txtTotaleRiga8";
            this.txtTotaleRiga8.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga8.TabIndex = 169;
            this.txtTotaleRiga8.Tag = "";
            this.txtTotaleRiga8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga8.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga7
            // 
            this.txtTotaleRiga7.Location = new System.Drawing.Point(608, 344);
            this.txtTotaleRiga7.Name = "txtTotaleRiga7";
            this.txtTotaleRiga7.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga7.TabIndex = 168;
            this.txtTotaleRiga7.Tag = "";
            this.txtTotaleRiga7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga7.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga10
            // 
            this.txtTotaleRiga10.Location = new System.Drawing.Point(608, 440);
            this.txtTotaleRiga10.Name = "txtTotaleRiga10";
            this.txtTotaleRiga10.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga10.TabIndex = 171;
            this.txtTotaleRiga10.Tag = "";
            this.txtTotaleRiga10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga10.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRiga9
            // 
            this.txtTotaleRiga9.Location = new System.Drawing.Point(608, 408);
            this.txtTotaleRiga9.Name = "txtTotaleRiga9";
            this.txtTotaleRiga9.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRiga9.TabIndex = 170;
            this.txtTotaleRiga9.Tag = "";
            this.txtTotaleRiga9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotaleRiga9.Leave += new System.EventHandler(this.rigaTotaleLeave);
            // 
            // txtTotaleRigaResiduo
            // 
            this.txtTotaleRigaResiduo.Enabled = false;
            this.txtTotaleRigaResiduo.Location = new System.Drawing.Point(608, 520);
            this.txtTotaleRigaResiduo.Name = "txtTotaleRigaResiduo";
            this.txtTotaleRigaResiduo.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRigaResiduo.TabIndex = 173;
            this.txtTotaleRigaResiduo.Tag = "";
            this.txtTotaleRigaResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleRigaSuddiv
            // 
            this.txtTotaleRigaSuddiv.Enabled = false;
            this.txtTotaleRigaSuddiv.Location = new System.Drawing.Point(608, 488);
            this.txtTotaleRigaSuddiv.Name = "txtTotaleRigaSuddiv";
            this.txtTotaleRigaSuddiv.Size = new System.Drawing.Size(88, 20);
            this.txtTotaleRigaSuddiv.TabIndex = 172;
            this.txtTotaleRigaSuddiv.Tag = "";
            this.txtTotaleRigaSuddiv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtUpb1
            // 
            this.txtUpb1.Location = new System.Drawing.Point(118, 152);
            this.txtUpb1.Name = "txtUpb1";
            this.txtUpb1.Size = new System.Drawing.Size(170, 20);
            this.txtUpb1.TabIndex = 1;
            this.txtUpb1.Tag = "";
            this.txtUpb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb1.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb2
            // 
            this.txtUpb2.Location = new System.Drawing.Point(118, 183);
            this.txtUpb2.Name = "txtUpb2";
            this.txtUpb2.Size = new System.Drawing.Size(170, 20);
            this.txtUpb2.TabIndex = 8;
            this.txtUpb2.Tag = "";
            this.txtUpb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb2.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb3
            // 
            this.txtUpb3.Location = new System.Drawing.Point(118, 216);
            this.txtUpb3.Name = "txtUpb3";
            this.txtUpb3.Size = new System.Drawing.Size(170, 20);
            this.txtUpb3.TabIndex = 14;
            this.txtUpb3.Tag = "";
            this.txtUpb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb3.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb4
            // 
            this.txtUpb4.Location = new System.Drawing.Point(120, 248);
            this.txtUpb4.Name = "txtUpb4";
            this.txtUpb4.Size = new System.Drawing.Size(170, 20);
            this.txtUpb4.TabIndex = 19;
            this.txtUpb4.Tag = "";
            this.txtUpb4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb4.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb5
            // 
            this.txtUpb5.Location = new System.Drawing.Point(120, 280);
            this.txtUpb5.Name = "txtUpb5";
            this.txtUpb5.Size = new System.Drawing.Size(170, 20);
            this.txtUpb5.TabIndex = 25;
            this.txtUpb5.Tag = "";
            this.txtUpb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb5.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb6
            // 
            this.txtUpb6.Location = new System.Drawing.Point(118, 312);
            this.txtUpb6.Name = "txtUpb6";
            this.txtUpb6.Size = new System.Drawing.Size(170, 20);
            this.txtUpb6.TabIndex = 32;
            this.txtUpb6.Tag = "";
            this.txtUpb6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb6.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb7
            // 
            this.txtUpb7.Location = new System.Drawing.Point(118, 345);
            this.txtUpb7.Name = "txtUpb7";
            this.txtUpb7.Size = new System.Drawing.Size(170, 20);
            this.txtUpb7.TabIndex = 38;
            this.txtUpb7.Tag = "";
            this.txtUpb7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb7.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb8
            // 
            this.txtUpb8.Location = new System.Drawing.Point(118, 376);
            this.txtUpb8.Name = "txtUpb8";
            this.txtUpb8.Size = new System.Drawing.Size(170, 20);
            this.txtUpb8.TabIndex = 44;
            this.txtUpb8.Tag = "";
            this.txtUpb8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb8.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb9
            // 
            this.txtUpb9.Location = new System.Drawing.Point(118, 408);
            this.txtUpb9.Name = "txtUpb9";
            this.txtUpb9.Size = new System.Drawing.Size(170, 20);
            this.txtUpb9.TabIndex = 50;
            this.txtUpb9.Tag = "";
            this.txtUpb9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb9.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // txtUpb10
            // 
            this.txtUpb10.Location = new System.Drawing.Point(118, 440);
            this.txtUpb10.Name = "txtUpb10";
            this.txtUpb10.Size = new System.Drawing.Size(170, 20);
            this.txtUpb10.TabIndex = 56;
            this.txtUpb10.Tag = "";
            this.txtUpb10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpb10.Leave += new System.EventHandler(this.txtUPB1_TextChanged);
            // 
            // frmAskDividi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(712, 605);
            this.Controls.Add(this.txtUpb10);
            this.Controls.Add(this.txtUpb9);
            this.Controls.Add(this.txtUpb8);
            this.Controls.Add(this.txtUpb7);
            this.Controls.Add(this.txtUpb6);
            this.Controls.Add(this.txtUpb5);
            this.Controls.Add(this.txtUpb4);
            this.Controls.Add(this.txtUpb3);
            this.Controls.Add(this.txtUpb2);
            this.Controls.Add(this.txtUpb1);
            this.Controls.Add(this.txtTotaleRigaResiduo);
            this.Controls.Add(this.txtTotaleRigaSuddiv);
            this.Controls.Add(this.txtTotaleRiga10);
            this.Controls.Add(this.txtTotaleRiga9);
            this.Controls.Add(this.txtTotaleRiga8);
            this.Controls.Add(this.txtTotaleRiga7);
            this.Controls.Add(this.txtTotaleRiga6);
            this.Controls.Add(this.txtTotaleRiga5);
            this.Controls.Add(this.txtTotaleRiga4);
            this.Controls.Add(this.txtTotaleRiga3);
            this.Controls.Add(this.txtTotaleRiga2);
            this.Controls.Add(this.txtTotaleRiga1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtIndetrResidua);
            this.Controls.Add(this.txtIndetrMax);
            this.Controls.Add(this.txtIndetrTotale);
            this.Controls.Add(this.txtIndetr7);
            this.Controls.Add(this.txtIndetr1);
            this.Controls.Add(this.txtIndetr2);
            this.Controls.Add(this.txtIndetr3);
            this.Controls.Add(this.txtIndetr4);
            this.Controls.Add(this.txtIndetr5);
            this.Controls.Add(this.txtIndetr6);
            this.Controls.Add(this.txtIndetr8);
            this.Controls.Add(this.txtIndetr9);
            this.Controls.Add(this.txtIndetr10);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.txtRiga);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.txtIvaResidua);
            this.Controls.Add(this.txtImponResiduo);
            this.Controls.Add(this.txtIvaMax);
            this.Controls.Add(this.txtPercMax);
            this.Controls.Add(this.txtImponibileMax);
            this.Controls.Add(this.txtIvaTotale);
            this.Controls.Add(this.txtIva7);
            this.Controls.Add(this.txtIva1);
            this.Controls.Add(this.txtIva2);
            this.Controls.Add(this.txtIva3);
            this.Controls.Add(this.txtIva4);
            this.Controls.Add(this.txtIva5);
            this.Controls.Add(this.txtIva6);
            this.Controls.Add(this.txtIva8);
            this.Controls.Add(this.txtIva9);
            this.Controls.Add(this.txtIva10);
            this.Controls.Add(this.txtTotale);
            this.Controls.Add(this.txtAmount7);
            this.Controls.Add(this.txtPerc7);
            this.Controls.Add(this.txtPerc1);
            this.Controls.Add(this.txtAmount1);
            this.Controls.Add(this.txtAmount2);
            this.Controls.Add(this.txtPerc2);
            this.Controls.Add(this.txtAmount3);
            this.Controls.Add(this.txtPerc3);
            this.Controls.Add(this.txtAmount4);
            this.Controls.Add(this.txtPerc4);
            this.Controls.Add(this.txtAmount5);
            this.Controls.Add(this.txtPerc5);
            this.Controls.Add(this.txtAmount6);
            this.Controls.Add(this.txtPerc6);
            this.Controls.Add(this.txtAmount8);
            this.Controls.Add(this.txtPerc8);
            this.Controls.Add(this.txtAmount9);
            this.Controls.Add(this.txtPerc9);
            this.Controls.Add(this.txtAmount10);
            this.Controls.Add(this.txtPerc10);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpb7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelImponibile);
            this.Controls.Add(this.btnUpb1);
            this.Controls.Add(this.btnUpb2);
            this.Controls.Add(this.btnUpb3);
            this.Controls.Add(this.btnUpb4);
            this.Controls.Add(this.btnUpb5);
            this.Controls.Add(this.btnUpb6);
            this.Controls.Add(this.btnUpb8);
            this.Controls.Add(this.btnUpb9);
            this.Controls.Add(this.btnUpb10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtTotaleRigaMax);
            this.Name = "frmAskDividi";
            this.Text = "Suddividi Dettaglio";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmAskInfo_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAskDividi_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAskDividi_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		public void SelezionaUpb(object sender, System.EventArgs e) {
			Button B = (Button)sender;
			if (B.IsDisposed) return;
			if (!B.Enabled) return;

            MetaData MetaUpb = Disp.Get("upb");
            MetaUpb.FilterLocked = true;
			MetaUpb.SearchEnabled = true;
			MetaUpb.StartFilter = null;

			string edittype = "tree";
			bool res = MetaUpb.Edit(this, edittype, true);
			if (!res) return;
			DataRow SelectedUpb = MetaUpb.LastSelectedRow;
			riempiInfoUpb(SelectedUpb,sender, e);

		}
		decimal GetImponibileNear(decimal imponibiletest,bool silent){
            decimal npackage = CfgFn.GetNoNullDecimal(Dettaglio["npackage"]);
			decimal discount = CfgFn.GetNoNullDecimal(Dettaglio["discount"]);
			//decimal taxable  = CfgFn.GetNoNullDecimal(Dettaglio["taxable"]);
            decimal taxable = CfgFn.GetNoNullDecimal(this.importo);
			decimal imponibilecomplementare= taxable-imponibiletest;
            decimal totale1 = CfgFn.RoundValuta(imponibiletest * npackage * (1 - discount) * exchangerate);
            decimal totale2 = CfgFn.RoundValuta(imponibilecomplementare * npackage * (1 - discount) * exchangerate);
			if (totale1+totale2 == TotaleImponibile) return imponibiletest;

            decimal x = (npackage * (1 - discount) * exchangerate);	
			decimal passo = 0 ;
			if (x<=10) {
				passo = 0.001M; 
			}
			if (10<x && x<=100){
				passo = 0.0001M;
			}					 
			if (100<x && x<=1000) {
				passo = 0.00001M;
			}
			if (x>1000 ) {
				passo = 0.000001M;
			}
            //if (passo == 0.01M) {
            //    imponibiletest = CfgFn.Round(imponibiletest, 2);
            //}
            //if (passo == 0.001M) {
            //    imponibiletest = CfgFn.Round(imponibiletest, 3);
            //}
            //if (passo == 0.0001M) {
            //    imponibiletest = CfgFn.Round(imponibiletest, 4);
            //}
            //if (passo == 0.00001M) {
            //    imponibiletest = CfgFn.Round(imponibiletest, 5);
            //}

			decimal cent= passo;//0.01M;

			while(cent < 0.3M){
				decimal imponibile_try= imponibiletest+cent;
				decimal imponibilecomplementare_try= taxable-imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try * npackage * (1 - discount) * exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try * npackage * (1 - discount) * exchangerate);
				if (totale1+totale2 == TotaleImponibile) {
					if (!silent) show("L'imponibile è stato portato da "+
                        ImpoStr(imponibiletest)+
                        " a " + ImpoStr(imponibile_try) +
						" per evitare problemi di incoerenza dei totali.");
					return imponibile_try;
				}
				imponibile_try= imponibiletest-cent;
				imponibilecomplementare_try= taxable-imponibile_try;
                totale1 = CfgFn.RoundValuta(imponibile_try * npackage * (1 - discount) * exchangerate);
                totale2 = CfgFn.RoundValuta(imponibilecomplementare_try * npackage * (1 - discount) * exchangerate);
				if (totale1+totale2 == TotaleImponibile) {
					if (!silent) show("L'imponibile è stato portato da "+
                    ImpoStr(imponibiletest) +
                    " a " + ImpoStr(imponibile_try) +
                  " per evitare problemi di incoerenza dei totali.");
					return imponibile_try;
				}
				cent+= passo;
			}
			show("Non è stato trovato un imponibile adeguato alle esigenze di divisione");
			return imponibiletest;
		}

		public void PercentualeLeave (object sender, System.EventArgs e){
			TextBox T = (TextBox)sender;
			if (!T.Modified) return;
			string suffix = T.Name.Substring(7);
			TextBox T1 = GetTxtByName("txtAmount"+suffix);
			// ripristina l'importo originale
			if(checkPercentuale(sender)) {
				// calcola l'importo in base alla percentuale
				decimal perc = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				// Calcola importoresiduo
				decimal importoresiduo = CalcolaImportoResiduo(sender);
				decimal percentualeresidua = 0;
				percentualeresidua = CalcolaPercentualeResidua(sender); 
				decimal importoassegnato = 0;

				if (percentualeresidua!=0)  importoassegnato = CfgFn.Round((perc/percentualeresidua)*importoresiduo,5) ;
				importoassegnato= GetImponibileNear(importoassegnato,true);
				RicalcolaIva(importoassegnato,importoresiduo,suffix);
				RicalcolaIvaIndetraibile(importoassegnato, importoresiduo,suffix);
                T1.Text = ImpoStr(importoassegnato);
                T.Text =  HelpForm.StringValue(perc, "x.y.fixed.4...1");    
				AggiornaTotali();
				AggiornaTotaleIva();
				AggiornaTotaleIvaIndetraibile();
				AggiornaTotaleRiga();
			}
				calcolaTotaleRiga(sender,e,7);
		}

		public void AggiornaTotali() {
			// Ciclo su tutti i gruppi per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				TextBox T = GetTxtByName("txtAmount"+suffix);
				importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));	
			}
            txtTotale.Text = ImpoStr(importoassegnato);
            txtImponResiduo.Text = ImpoStr(importo - importoassegnato);
		}

        string ImpoStr(decimal d) {
            return HelpForm.StringValue(d, "x.y.fixed.5...1");  
        }
        string IvaStr(decimal d) {
            return HelpForm.StringValue(d, "x.y.fixed.2...1");
        }
        string TotaleRigaStr (decimal d) {
            return HelpForm.StringValue(d, "x.y.fixed.2...1");
        }
        string PercentualeStr (decimal d) {
            return HelpForm.StringValue(d, "x.y.fixed.4...100");
        }
		public void AggiornaTotaleIva() {
			// Ciclo su tutti i gruppi per determinare l'iva assegnata 
			decimal ivaassegnata = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				TextBox T = GetTxtByName("txtIva"+suffix);
				ivaassegnata += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));			
			}
            txtIvaTotale.Text = IvaStr(ivaassegnata) ;
			txtIvaResidua.Text = IvaStr(importoIva - ivaassegnata);  
		}
		
		public void AggiornaTotaleIvaIndetraibile() {
			// Ciclo su tutti i gruppi per determinare l'iva assegnata 
			decimal ivaassegnata = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				TextBox T = GetTxtByName("txtIndetr"+suffix);
				ivaassegnata += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));			
			}
			txtIndetrTotale.Text = IvaStr(ivaassegnata);
			txtIndetrResidua.Text = IvaStr(importoIndetraibile - ivaassegnata);  
		}
		
		public void AggiornaTotaleRiga() {
			// Ciclo su tutti i gruppi per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				TextBox T = GetTxtByName("txtTotaleRiga"+suffix);
				importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));	
			}
			txtTotaleRigaSuddiv.Text = TotaleRigaStr(importoassegnato);
            txtTotaleRigaResiduo.Text = TotaleRigaStr(totaleRiga - importoassegnato);  
		}

		public void ImportoLeave (object sender, System.EventArgs e) {
			TextBox T = (TextBox)sender;
			if (!T.Modified) return;
			string suffix = T.Name.Substring(9);
			TextBox T1 = GetTxtByName("txtPerc"+suffix);   
			decimal importomovimento= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
                T.Text, "x.y.fixed.5...1"));
			importomovimento = GetImponibileNear(importomovimento,false);
            T.Text = ImpoStr(importomovimento);
			if(!checkImporto(sender)) {
				// Valore digitato errato
				T.Focus();
			}
			else {
				decimal percentuale = 100;
				decimal rounded = Math.Round(percentuale, 4);
                T.Text = ImpoStr(importomovimento);
				// calcola la percentuale in base all'importo
				decimal imponibileresiduo = CalcolaImportoResiduo(sender);
				if (imponibileresiduo!=0) {
					percentuale= importomovimento/imponibileresiduo*CalcolaPercentualeResidua(sender);
					rounded    = Math.Round(percentuale, 4);  
				}
                T1.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
				RicalcolaIva(importomovimento,imponibileresiduo,suffix);
				RicalcolaIvaIndetraibile(importomovimento, imponibileresiduo,suffix);
				AggiornaTotali();
				AggiornaTotaleIva();
				AggiornaTotaleIvaIndetraibile();
				AggiornaTotaleRiga();
			}
			calcolaTotaleRiga(sender,e,9);
		}
		
		public void IvaLeave (object sender, System.EventArgs e) {
			TextBox T = (TextBox)sender;
			if (!T.Modified) return;
			decimal importoiva= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
                T.Text, "x.y.fixed.2...1"));
			if(!checkIva(sender)) {
				// Valore digitato errato
				T.Focus();
			}
			else {
                T.Text = IvaStr(importoiva);
				if (T.Name.Substring(0,6)=="txtIva"){
					AggiornaTotaleIva();
					calcolaTotaleRiga(sender,e,6);
				}
				else {
					AggiornaTotaleIvaIndetraibile();
				}
			}
		}

		public void rigaTotaleLeave (object sender, System.EventArgs e) {
			TextBox T = (TextBox)sender;
			if (!T.Modified) return;
			decimal importo= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
				T.Text,"x.y.c"));
			if(!checkRigaTotale(sender)) {
				// Valore digitato errato
				T.Focus();
			}
			else {
                T.Text = TotaleRigaStr(importo);
				DividiCostoTotale(sender);
				AggiornaTotaleRiga();
				AggiornaTotaleIva();
				AggiornaTotaleIvaIndetraibile();
				AggiornaTotali();
			}
		}

		public void calcolaTotaleRiga(object sender, System.EventArgs e, int l)	
		{
			TextBox T = (TextBox)sender;
			string suffix = T.Name.Substring(l);
			TextBox T1 = GetTxtByName("txtTotaleRiga"+suffix);

			// calcola l'importo totale riga e valorizza il textbox
            decimal npackage = CfgFn.GetNoNullDecimal(Dettaglio["npackage"]);
			decimal discount = CfgFn.GetNoNullDecimal(Dettaglio["discount"]);

			TextBox TAmount = GetTxtByName("txtAmount"+suffix);
			decimal imponibile = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),TAmount.Text,"x.y.c"));	

			TextBox TIva = GetTxtByName("txtIva"+suffix);
			decimal iva = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),TIva.Text,"x.y.c"));

            decimal importoTotaleRiga = CfgFn.RoundValuta(imponibile * npackage * (1 - discount) * exchangerate) + iva;
            T1.Text = TotaleRigaStr(importoTotaleRiga);                
			AggiornaTotaleRiga();
		}

		public void RicalcolaIva(decimal importoDigitato, decimal imponibileResiduo, string suffix) {
			// Calcola l'Iva Residua
			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo dell'Iva
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string tSuffix=i.ToString();
				if (tSuffix != suffix) {
					TextBox T = GetTxtByName("txtIva"+tSuffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			decimal ivaResidua = importoIva - importoassegnato;
			TextBox TIva = GetTxtByName("txtIva"+suffix);
			decimal ivaRicalcolata = 0;
			if (imponibileResiduo!=0) ivaRicalcolata = (importoDigitato/imponibileResiduo)*ivaResidua;
			TIva.Text    = IvaStr(ivaRicalcolata);
		}
		
		public void RicalcolaIvaIndetraibile(decimal importoDigitato, decimal imponibileResiduo, string suffix) {
			//Calcola l'Iva Indetraibile Residua
			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo dell'Iva Indetraibile
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string tSuffix=i.ToString();
				if (tSuffix != suffix) {
					TextBox T = GetTxtByName("txtIndetr"+tSuffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			decimal ivaResidua = importoIndetraibile - importoassegnato;
			TextBox TIva = GetTxtByName("txtIndetr"+suffix);
			decimal ivaRicalcolata = 0;
			if (imponibileResiduo!=0) ivaRicalcolata = (importoDigitato/imponibileResiduo)*ivaResidua;
			TIva.Text    = IvaStr( ivaRicalcolata);
		}

		private void riempiInfoUpb(DataRow upbRow, object sender, System.EventArgs e) 
		{
			Button B = (Button)sender; 
			if (B.IsDisposed) return;
			if (!B.Enabled) return; 
			string buttonName = B.Name;
			string suffix = buttonName.Substring(6);
            
            //ComboBox C = GetCmbByName("cmbUpb"+suffix);
            //C.SelectedValue = (upbRow != null) ? upbRow["idupb"] : DBNull.Value;
            TextBox Tupb = GetTxtByName("txtUpb" + suffix);  
            Tupb.Text = (upbRow != null) ? upbRow["codeupb"].ToString() : null;
		}
		
		TextBox GetTxtByName(string Name) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			return T;
		}

        //ComboBox GetCmbByName(string Name) {
        //    System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
        //    if (Ctrl==null) return null;
        //    if (!typeof(ComboBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
        //    ComboBox C =  (ComboBox) Ctrl.GetValue(this);                        
        //    return C;
        //}

        //private void SetDataSourceCmb () {
            //ComboBox C = null;
            //for (int i=1; i<=10; i++) {
            //    string suffix = i.ToString();
            //    C = GetCmbByName("cmbUpb"+suffix);
            //    C.DataSource = upb.Copy();
            //    C.ValueMember = "idupb";
            //    C.DisplayMember = "codeupb";
            //}
	
        //}
        private object RicavaIdupb(string codeupb){
            object idupb = Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("codeupb", codeupb), "idupb");
            return idupb;
        }
		private void frmAskInfo_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			if (e.Cancel==true) return;
			if (DialogResult == DialogResult.Cancel) return;
			// Lettura dei dati digitati
			
			Info = new DataTable();
			Info.Columns.Add("idupb", typeof(string));
            Info.Columns.Add("taxable", typeof(decimal));
			Info.Columns.Add("tax", typeof(decimal));
			Info.Columns.Add("unabatable", typeof(decimal));
			
			decimal taxableassegnato = 0;
			decimal taxassegnato = 0; 
			decimal unabatassegnato = 0; 
			decimal totrigaassegnato = 0;
			for (int i=1; i<=10; i++) {
				string suffix = i.ToString();
				//ComboBox C  =  GetCmbByName("cmbUpb"+suffix);
                TextBox Tupb = GetTxtByName("txtUpb" + suffix);    
				TextBox  T  =  GetTxtByName("txtAmount"+suffix);
				TextBox  T1 =  GetTxtByName("txtIva"+suffix);
				TextBox  T2 =  GetTxtByName("txtIndetr"+suffix);
				TextBox  T3 =  GetTxtByName("txtTotaleRiga"+suffix);

				decimal taxable = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), T.Text, "x.y.c"));
				decimal tax		= CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), T1.Text,"x.y.c"));
				decimal unabatable = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), T2.Text,"x.y.c"));
				decimal totaleriga = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), T3.Text,"x.y.c"));
			
				taxableassegnato +=taxable;
				taxassegnato += tax;
				unabatassegnato += unabatable;
				totrigaassegnato += totaleriga;

                if ((Tupb.Text.ToString().Trim() == "") && (taxable != 0 || tax != 0)) {
                    show("Riga " + suffix + ": selezionare l'UPB");
                    Tupb.Focus();
                    e.Cancel = true;
                    return;
                }

                if (Tupb.Text.ToString().Trim() != "") {
					DataRow rInfo    = Info.NewRow();
                    rInfo["idupb"] = RicavaIdupb(Tupb.Text.ToString());
					rInfo["taxable"] = taxable;
					rInfo["tax"]     = tax;
					rInfo["unabatable"] = unabatable;
					Info.Rows.Add(rInfo);
				}
			}

			// calcola l'importo totale riga e valorizza il textbox
            decimal npackage = CfgFn.GetNoNullDecimal(Dettaglio["npackage"]);
			decimal discount = CfgFn.GetNoNullDecimal(Dettaglio["discount"]);
            decimal importoTotaleRiga = CfgFn.RoundValuta(importo * npackage * (1 - discount) * exchangerate) + importoIva;

			
			if (taxableassegnato<importo){
				show("L'imponibile del dettaglio originale non è stato interamente suddiviso");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if(taxassegnato<importoIva){
				show("L'Iva del dettaglio originale non è stata interamente suddivisa");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if (taxableassegnato<importo){
				show("L'imponibile del dettaglio originale è inferiore alla somma dei valori ripartiti");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if(totrigaassegnato<(importoTotaleRiga)){
				show("Il totale riga del dettaglio originale non è stato interamente suddiviso");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if(taxassegnato>importoIva){
				show("L'Iva del dettaglio originale è inferiore alla somma dei valori ripartiti");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if(unabatassegnato<importoIndetraibile){
				show("L'Iva Indetraibile del dettaglio originale è inferiore alla somma dei valori ripartiti");
				Info.Clear();
				e.Cancel = true;
				return;
			}
			if(totrigaassegnato>(importoTotaleRiga)){
				show("Il totale riga del dettaglio originale è inferiore alla somma dei valori ripartiti");
				Info.Clear();
				e.Cancel = true;
				return;
			}
		}
	
		private bool checkPercentuale(object sender) {      
			TextBox T = (TextBox)sender;
			bool OK = false;
			if (T.Text == "") return false;           
			decimal percentmax=100;
			// Calcola importoresiduo
			decimal importoresiduo = CalcolaImportoResiduo(sender);
			if (importo!=0) percentmax = importoresiduo/importo*100; 
			
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
                    "tra 0 e " + HelpForm.StringValue(percentmax, "x.y.fixed.4...1");
			try {
				decimal percent = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				if ((percent < 0) || (percent > percentmax)){
					show(errmsg,"Avviso");
					T.Focus();
					OK = false;
				}
				else
				 {
					OK=true;
				}
  
			}
			catch {                
				show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private bool checkImporto(object sender) {
			TextBox T = (TextBox)sender;
			bool OK = false;
			if (T.Text == "") return false;
			// Calcola importoresiduo
			decimal importoresiduo = CalcolaImportoResiduo(sender);
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + ImpoStr( importoresiduo);
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					T.Text,HelpForm.GetStandardTag(T.Tag)));
					
				if ((importo >= 0) && (importo <= (importoresiduo))) {
					OK = true;
				}
				else{
					show(errmsg,"Avviso");
					OK = false;
				}
  
			}
			catch {                
				show("E' necessario inserire un numero","Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}
		
		private bool checkRigaTotale(object sender) {
			TextBox T = (TextBox)sender;
			bool OK = false;
			if (T.Text == "") return false;
			// Calcola importoresiduo
			decimal importoresiduo = CalcolaCostoTotaleResiduo(sender);
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + ImpoStr( importoresiduo);
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					T.Text,HelpForm.GetStandardTag(T.Tag)));
					
				if ((importo >= 0) && (importo <= (importoresiduo))) {
					OK = true;
				}
				else{
					show(errmsg,"Avviso");
					OK = false;
				}
  
			}
			catch {                
				show("E' necessario inserire un numero","Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}


		private bool checkIva(object sender) {
			TextBox T = (TextBox)sender;
			bool OK = false;
			if (T.Text == "") return false;
			decimal importoresiduo = 0; 
			string name = T.Name.Substring(0,6);
			// Calcola importoresiduo
			if (name == "txtIva"){
				importoresiduo = CalcolaIvaResidua(sender);
			}
			else {
				importoresiduo = CalcolaIndetraibileResidua(sender);
			}
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + IvaStr( importoresiduo);
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					T.Text,HelpForm.GetStandardTag(T.Tag)));
					
				if ((importo >= 0) && (importo <= (importoresiduo))) {
					OK = true;
				}
				else{
					show(errmsg,"Avviso");
					OK = false;
				}
  
			}
			catch {                
				show("E' necessario inserire un numero","Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}
		
		
		private decimal CalcolaImportoResiduo (object sender) {
			TextBox TSender = (TextBox)sender;
			string sendSuffix = null;
			string sendName=TSender.Name.Substring(0,5) ;
			if (sendName == "txtAm") {
				sendSuffix = TSender.Name.Substring(9);
			}
			else {
				sendSuffix = TSender.Name.Substring(7);
			}

			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				if (suffix != sendSuffix) {
					TextBox T = GetTxtByName("txtAmount"+suffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			return importo - importoassegnato;
		}

		private decimal CalcolaPercentualeResidua (object sender) {
			TextBox TSender = (TextBox)sender;
			string sendSuffix = null;
			string sendName=TSender.Name.Substring(0,5) ;
			if (sendName == "txtAm") {
				sendSuffix = TSender.Name.Substring(9);
			}
			else {
				sendSuffix = TSender.Name.Substring(7);
			}

			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				if (suffix != sendSuffix) {
					TextBox T = GetTxtByName("txtPerc"+suffix);
                    importoassegnato += CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal), T.Text, "x.y.c"));		
				}
			}
			return 100 - importoassegnato;
		}
		
		private decimal CalcolaIvaResidua (object sender) {
			TextBox TSender = (TextBox)sender;
			string sendSuffix = TSender.Name.Substring(6);
			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				if (suffix != sendSuffix) {
					TextBox T = GetTxtByName("txtIva"+suffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			return importoIva - importoassegnato;
		}
		
		private decimal CalcolaIndetraibileResidua (object sender) {
			TextBox TSender = (TextBox)sender;
			string sendSuffix = TSender.Name.Substring(9);
			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				if (suffix != sendSuffix) {
					TextBox T = GetTxtByName("txtIndetr"+suffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			return importoIndetraibile - importoassegnato;
		}
		
		private decimal CalcolaCostoTotaleResiduo (object sender) {
			TextBox TSender = (TextBox)sender;
			string sendSuffix = null;
			string sendName=TSender.Name.Substring(0,5) ;
			sendSuffix = TSender.Name.Substring(13);
			// Ciclo su tutti i gruppi escluso uno per determinare l'importo residuo 
			decimal importoassegnato = 0;
			for (int i=1;i<=10;i++){
				string suffix=i.ToString();
				if (suffix != sendSuffix) {
					TextBox T = GetTxtByName("txtTotaleRiga"+suffix);
					importoassegnato += CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),T.Text,"x.y.c"));		
				}
			}
			return totaleRiga - importoassegnato;
		}
		
		private void DividiCostoTotale (object sender) {
			
			TextBox TSender = (TextBox)sender;
			decimal costoTotale = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),TSender.Text,"x.y.c"));		
			string sendSuffix = TSender.Name.Substring(13);

			//this.importo = CfgFn.GetNoNullDecimal(Dettaglio["taxable"]);
			//this.importoIva = CfgFn.GetNoNullDecimal(Dettaglio["tax"]);

            decimal npackage = CfgFn.GetNoNullDecimal(Dettaglio["npackage"]);
			decimal discount = CfgFn.GetNoNullDecimal(Dettaglio["discount"]);
			decimal taxrate  = CfgFn.GetNoNullDecimal(Dettaglio["taxrate"]);
			decimal unabatabilitypercentage = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("ivakind", 
				QHS.CmpEq("idivakind", Dettaglio["idivakind"]), "unabatabilitypercentage"));

			// CostoTotale = imponibile*quantita *(1-sconto)*(tassocambio) + (perciva)(imponibile*quantita *(1-sconto)(tassocambio)) 

			decimal imponibiletotalescontato =  costoTotale / (1 + taxrate);
            decimal new_taxable = CfgFn.Round((imponibiletotalescontato / (npackage * (1 - discount) * exchangerate)), 5);
			new_taxable= GetImponibileNear(new_taxable,true); //imponibile unitario che quadra con l'imponibile residuo 
			// Devo ora fare  in modo che anche il costo totale ricalcolato sia il più possibile vicino
			// al costoTotale iniziale. Ciclo fino a minimizzare l'errore
			
			/*double imponibiletot 	= CfgFn.RoundValuta((imponibile*quantita*(1-sconto)));
			double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);			
			double iva        		= CfgFn.RoundValuta(imponibiletot*aliquota);
			double ivaEUR     		= CfgFn.RoundValuta(iva*tassocambio);
			double impindeduc		= CfgFn.RoundValuta(iva*percindeduc);
			double impindeducEUR	= CfgFn.RoundValuta(impindeduc*tassocambio);*/
			
			
			decimal totale1= costoTotale;
            decimal imponibiletotalescontato2 = CfgFn.RoundValuta(new_taxable * npackage * (1 - discount) * exchangerate); 
			decimal totale2= imponibiletotalescontato2  + CfgFn.RoundValuta(imponibiletotalescontato2 * taxrate) ;
			decimal delta = 0;
			if (totale1!=totale2) 
			{
				  delta  = totale1 - totale2;
				  if (delta<0) delta = - delta;
				  decimal cent= - 0.09M;
				  while (cent < 0.1M){
					    decimal delta1 = 0;
						decimal imponibile_try= GetImponibileNear(new_taxable+cent,true);
                        imponibiletotalescontato2 = CfgFn.RoundValuta(imponibile_try * npackage * (1 - discount) * exchangerate);
						totale2= imponibiletotalescontato2  + CfgFn.RoundValuta(imponibiletotalescontato2 * taxrate) ;
						delta1 =  totale1 - totale2;
					    if (delta1< 0) delta1 = - delta1;
					    if (delta1<delta) {
							delta = delta1;
							new_taxable = imponibile_try;
					    }
					cent+= 0.01M;
				}
			}

			// Deve calcolare new_tax come la quota del residuo di tax in rapporto a new_taxable/ residuo taxable
			// idem per new_unabatable
			
			decimal new_tax			=  0;
            if (importoIva != 0) new_tax = costoTotale - CfgFn.RoundValuta(new_taxable * npackage * (1 - discount) * exchangerate);
	
			decimal new_unabatable  =  new_tax * unabatabilitypercentage;

			TextBox T1 = GetTxtByName("txtAmount"+sendSuffix);
			TextBox T2 = GetTxtByName("txtIva"+sendSuffix);
			TextBox T3 = GetTxtByName("txtPerc"+sendSuffix);
			TextBox T4 = GetTxtByName("txtIndetr"+sendSuffix);

            T1.Text = ImpoStr(new_taxable);
            T2.Text = IvaStr(new_tax);
                //new_tax.ToString("c");
			decimal percentuale  = 100;
			if (importo!=0) percentuale= new_taxable/importo*100;
			decimal rounded = Math.Round(percentuale, 4);                
			// calcola la percentuale in base all'importo
            T3.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");

			return;
		}

		private void cmb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
		//Se è stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
		if ( (e.KeyChar == 27) || (e.KeyChar == 13) ) {
			return;
			}

		ComboBox acComboBox = (ComboBox) sender;

		int selectionStart = acComboBox.SelectionStart;
		if (selectionStart>acComboBox.Text.Length) selectionStart=acComboBox.Text.Length;

		//Se il tasto premuto è BACKSPACE, faccio cominciare la selezione un carattere prima
		//dell'inizio della selezione corrente
		if ( e.KeyChar == 8 ) {
		if (selectionStart > 0) {
			acComboBox.Select( selectionStart-1, acComboBox.Text.Length-(selectionStart-1) );
		} 
		else {
			acComboBox.SelectAll();
			}
		} 
	else {
		//Se è un qualunque altro carattere (quindi tale che IsInputKey()=true
		//e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

		//Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
		//della riga corrente concatenati col tasto premuto
		string ricerca = acComboBox.Text.Substring( 0, selectionStart ) + e.KeyChar;

		int index = acComboBox.FindString(ricerca);

		if ( index != -1 ) {
			//Se tale riga esiste, allora la seleziono
			if (acComboBox.SelectedIndex != index) {
			acComboBox.DroppedDown = false;
			acComboBox.SelectedIndex = index;
		}
		acComboBox.DroppedDown = true;
		if (selectionStart < acComboBox.Text.Length) {
			//e faccio cominciare la selezione da selectionstart + 1
			acComboBox.Select( selectionStart+1, acComboBox.Text.Length-(selectionStart+1) );
		}
	} 
	else {
		//Se invece tale riga non esiste, allora seleziono la riga attuale
		//dal carattere in posizione selectionStart fino alla fine
		acComboBox.DroppedDown = true;
		acComboBox.Select( selectionStart, acComboBox.Text.Length - selectionStart );
		}
		}
		//Forzo l'apertura della tendina per facilitare l'utente nella scelta
		e.Handled = true;
		}

		/// <summary>
		/// Evento generato prima di KeyPress. Lo uso per gestire la pressione dei tasti 
		/// "SINISTRA", "DESTRA", "HOME" e "CANC"
		/// che altrimenti non riuscirei ad intercettare con KeyPress.
		/// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
		/// </summary>
		/// <param name="sender">il ComboBox da gestire</param>
		/// <param name="e">l'evento</param>
		private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
		ComboBox acComboBox = (ComboBox) sender;
		int selectionStart = acComboBox.SelectionStart;

		switch (e.KeyCode) {
		//Se è stato premuta la freccia "SINISTRA" faccio cominciare la selezione
		//un carattere prima rispetto alla selezione attuale
		case Keys.Left:
			if (selectionStart > 0) {
			acComboBox.Select( selectionStart-1, acComboBox.Text.Length-(selectionStart-1) );
			} 
			else {
			acComboBox.SelectAll();
			}
			break;

		//Se è stato premuto il tasto "CANC" seleziono la riga vuota del combobox
		case Keys.Delete:
			int index = acComboBox.FindString("");
			if ( index != -1 ) {
			acComboBox.DroppedDown = false;
			acComboBox.SelectedIndex = index;
			acComboBox.DroppedDown = true;
			} 
			acComboBox.SelectAll();
			break;

		//Se è stato premuta la freccia "DESTRA" faccio cominciare la selezione
		//un carattere dopo rispetto alla selezione attuale
		case Keys.Right:
			if (acComboBox.Text.Length > selectionStart) {
			acComboBox.Select( selectionStart+1, acComboBox.Text.Length-(selectionStart+1) );
			}
			break;

		//Se è stato premuto il tasto "HOME" seleziono tutta la riga attuale.
		case Keys.Home:
			acComboBox.SelectAll();
			break;

		default:
		//Altrimenti lascio la gestione di questo evento a .NET
			return;
		}
		e.Handled = true;
		}

        private void riempiTextBox(DataRow UpbRow, TextBox txtUpb) {
            txtUpb.Text = (UpbRow != null) ? UpbRow["codeupb"].ToString() : "";
        }

        private void GestisceTextUpb(TextBox txtUpb) {
            if (txtUpb.Text.Trim() == "") {
                SelectedUpb = null;
                riempiTextBox(SelectedUpb, txtUpb);
                return;
            }
            MetaData MetaUpb = Disp.Get("upb");

            MetaUpb.FilterLocked = true;
            MetaUpb.SearchEnabled = false;
            MetaUpb.MainSelectionEnabled = true;
            MetaUpb.StartFilter = null;
            MetaUpb.startFieldWanted = "codeupb";
            MetaUpb.startValueWanted = null;

            MetaUpb.startValueWanted = txtUpb.Text.Trim();
            string startfield = MetaUpb.startFieldWanted;
            string startvalue = MetaUpb.startValueWanted;

            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter = "(" + startfield + "='" + stripped + "')";
                SelectedUpb = MetaUpb.SelectByCondition(filter, "upb");
            }

            if (SelectedUpb == null) {
                string filter = "(codeupb like " + QueryCreator.quotedstrvalue(txtUpb.Text + "%", true) + ")";
                MetaUpb.FilterLocked = true;
                SelectedUpb = MetaUpb.SelectOne("default", filter, "upbview", null);
                riempiTextBox(SelectedUpb, txtUpb);
                return;
            }
            riempiTextBox(SelectedUpb, txtUpb);
        }

        private void txtUPB1_TextChanged(object sender, EventArgs e) {
            TextBox T = (TextBox)sender;
            if (!T.Modified) return;
            string suffix = T.Name.Substring(6);
            TextBox T1 = GetTxtByName("txtUpb" + suffix);
            GestisceTextUpb(T1);
        }

        private void frmAskDividi_FormClosed(object sender, FormClosedEventArgs e) {
            MetaData.UnregisterAllEvents(this);
        }

        private void frmAskDividi_FormClosing(object sender, FormClosingEventArgs e) {
            this.ActiveControl = null;
        }
    }
}
