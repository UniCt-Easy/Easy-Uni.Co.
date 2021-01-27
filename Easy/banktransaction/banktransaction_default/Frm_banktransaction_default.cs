
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace banktransaction_default
{
	/// <summary>
	/// Summary description for Frm_banktransaction_default.
	/// </summary>
	public class Frm_banktransaction_default : System.Windows.Forms.Form
	{
		MetaData Meta;
		string standardTagBtnReversale = "";
		string standardTagBtnMandato = "";
		string standardTagBtnEntrata = "";
		string standardTagBtnSpesa = "";
		int esercizio;
		public banktransaction_default.vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox gboxMandato;
		private System.Windows.Forms.GroupBox gboxReversale;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.RadioButton rdoCredito;
		private System.Windows.Forms.RadioButton rdoDebito;
		private System.Windows.Forms.TextBox txtNumeroMandato;
		private System.Windows.Forms.TextBox txtNumeroReversale;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnEntrata;
		private System.Windows.Forms.Button btnSpesa;
		private System.Windows.Forms.TextBox txtNumMovSpesa;
		private System.Windows.Forms.TextBox txtNumMovEntrata;
		private System.Windows.Forms.GroupBox grpEntrata;
		private System.Windows.Forms.GroupBox grpSpesa;
		private System.Windows.Forms.Button btnMandato;
		private System.Windows.Forms.Button btnReversale;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox txtImportoEsito;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGrid dGridClassSup;
        private Button btnElimina;
        private Button btnModifica;
        private Button btnInserisci;
        CQueryHelper QHC;
        QueryHelper QHS;
        private Button btnCollegaBankImport;
        private GroupBox groupBox6;
        private Label label15;
        private TextBox textBox4;
        private Label label16;
        private TextBox textBox5;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_banktransaction_default()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
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

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			esercizio = (int)Meta.GetSys("esercizio");
			string filterEsercizio = QHS.CmpEq("ayear", esercizio);
			string filterPay = QHS.CmpEq("ypay", esercizio);
			string filterPro = QHS.CmpEq("ypro", esercizio);
			string filtroSpesa = QHS.AppAnd(QHS.CmpEq("ymov",esercizio), QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), QHS.IsNotNull("idpay"));
			filtroSpesa = GetData.MergeFilters(filterEsercizio,filtroSpesa);
            GetData.SetStaticFilter(DS.expenseview, filtroSpesa);
            GetData.SetStaticFilter(DS.payment, filterPay);
            GetData.SetStaticFilter(DS.proceeds, filterPro);
            GetData.SetStaticFilter(DS.sortingview, filterEsercizio);

			object nomeFaseS = Meta.Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), "description");
			string faseS = (nomeFaseS != null) ? nomeFaseS.ToString() : "";
			grpSpesa.Text = faseS;
			btnSpesa.Text = faseS;

		

            string filtroEntrata = QHS.AppAnd(QHS.CmpEq("ymov",esercizio),QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")), QHS.IsNotNull("idpro"));
			filtroEntrata = GetData.MergeFilters(filterEsercizio,filtroEntrata);
			GetData.SetStaticFilter(DS.incomeview, filtroEntrata);

            object nomeFaseE = Meta.Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Meta.GetSys("maxincomephase")), "description");
			string faseE = (nomeFaseE != null) ? nomeFaseE.ToString() : "";
			grpEntrata.Text = faseE;
			btnEntrata.Text = faseE;
	
			standardTagBtnReversale = HelpForm.GetStandardTag(btnReversale.Tag);
			standardTagBtnEntrata = HelpForm.GetStandardTag(btnEntrata.Tag);
            btnCollegaBankImport.Tag = btnCollegaBankImport.Tag + "." + QHS.DoPar(QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            gboxReversale.Tag = gboxReversale.Tag.ToString()+"."+filterPro;
            gboxMandato.Tag = gboxMandato.Tag.ToString() + "." + filterPay;

            standardTagBtnMandato = HelpForm.GetStandardTag(btnMandato.Tag);
            standardTagBtnSpesa = HelpForm.GetStandardTag(btnSpesa.Tag);
		}

        MetaData.AutoInfo AI_Mandato;
		MetaData.AutoInfo AI_Reversale;
		public void MetaData_AfterActivation() {
			txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
			AI_Mandato = Meta.GetAutoInfo(txtNumeroMandato.Name);
			AI_Reversale = Meta.GetAutoInfo(txtNumeroReversale.Name);
		}

		public void MetaData_AfterClear() {
			gboxReversale.Enabled = true;
			gboxMandato.Enabled = true;
			grpEntrata.Enabled = true;
			grpSpesa.Enabled = true;
			string filterPay = QHS.CmpEq("ypay", esercizio);
			string filterPro = QHS.CmpEq("ypro", esercizio);
			AI_Mandato.startfilter = filterPay;
			AI_Reversale.startfilter = filterPro;
			SetGBoxIncome();
			SetGBoxExpense();
		}

		public void MetaData_AfterFill(){
			SetGBoxExpense();
			SetGBoxIncome();
			string filterPay = QHS.CmpEq("ypay", esercizio);
			string filterPro = QHS.CmpEq("ypro", esercizio);
			//AggiornaGBox();
			if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
				string filter = "(total>performed)";
				AI_Mandato.startfilter = QHS.AppAnd( filter,filterPay);
				AI_Reversale.startfilter = QHS.AppAnd( filter,filterPro);

				btnMandato.Tag = standardTagBtnMandato + " AND " + filter;
				btnReversale.Tag = standardTagBtnReversale + " AND " + filter;
			}
			if (Meta.EditMode) {
				btnMandato.Tag = standardTagBtnMandato;
				btnReversale.Tag = standardTagBtnReversale;
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "payment") {
				SetGBoxExpense();
				//AggiornaGBox();
			}
			if (T.TableName == "proceeds") {
				SetGBoxIncome();
				//AggiornaGBox();
			}
			if (T.TableName == "expenseview") {
				if (R == null) return;
				if (Meta.IsEmpty) return;
				decimal importo = calcolaImportoDaEsitare(R, "S");
				DS.banktransaction.Rows[0]["amount"] = importo;
				txtImportoEsito.Text = importo.ToString("c");
			}

			if (T.TableName == "incomeview") {
				if (R == null) return;
				if (Meta.IsEmpty) return;
				decimal importo = calcolaImportoDaEsitare(R, "E");
				DS.banktransaction.Rows[0]["amount"] = importo;
				txtImportoEsito.Text = importo.ToString("c");
			}
		}

		private decimal calcolaImportoDaEsitare(DataRow rMov, string e_s) {
			decimal importoCorrente = CfgFn.GetNoNullDecimal(rMov["curramount"]);
			decimal importoGiaEsitato = 0;
			string field = (e_s == "S") ? "idexp" : "idinc";
			string filtroEsiti = QHS.CmpEq(field, rMov[field]);
			if (Meta.EditMode) {
				DataRow Curr = DS.banktransaction.Rows[0];
                filtroEsiti = QHS.AppAnd(filtroEsiti, QHS.CmpNe("yban", Curr["yban"]), QHS.CmpNe("nban", Curr["nban"]));
			}
			importoGiaEsitato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("banktransaction", filtroEsiti, "SUM(amount)"));

			importoCorrente -= importoGiaEsitato;
			return importoCorrente;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoCredito = new System.Windows.Forms.RadioButton();
			this.rdoDebito = new System.Windows.Forms.RadioButton();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.gboxMandato = new System.Windows.Forms.GroupBox();
			this.btnMandato = new System.Windows.Forms.Button();
			this.txtNumeroMandato = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gboxReversale = new System.Windows.Forms.GroupBox();
			this.btnReversale = new System.Windows.Forms.Button();
			this.txtNumeroReversale = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.txtImportoEsito = new System.Windows.Forms.TextBox();
			this.grpEntrata = new System.Windows.Forms.GroupBox();
			this.txtNumMovEntrata = new System.Windows.Forms.TextBox();
			this.btnEntrata = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.grpSpesa = new System.Windows.Forms.GroupBox();
			this.txtNumMovSpesa = new System.Windows.Forms.TextBox();
			this.btnSpesa = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnCollegaBankImport = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dGridClassSup = new System.Windows.Forms.DataGrid();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.DS = new banktransaction_default.vistaForm();
			this.groupBox1.SuspendLayout();
			this.gboxMandato.SuspendLayout();
			this.gboxReversale.SuspendLayout();
			this.grpEntrata.SuspendLayout();
			this.grpSpesa.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdoCredito);
			this.groupBox1.Controls.Add(this.rdoDebito);
			this.groupBox1.Location = new System.Drawing.Point(280, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 56);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tipo Mov. Bancario";
			// 
			// rdoCredito
			// 
			this.rdoCredito.Location = new System.Drawing.Point(8, 16);
			this.rdoCredito.Name = "rdoCredito";
			this.rdoCredito.Size = new System.Drawing.Size(96, 16);
			this.rdoCredito.TabIndex = 1;
			this.rdoCredito.Tag = "banktransaction.kind:C";
			this.rdoCredito.Text = "a Credito";
			this.rdoCredito.CheckedChanged += new System.EventHandler(this.rdoCredito_CheckedChanged);
			// 
			// rdoDebito
			// 
			this.rdoDebito.Location = new System.Drawing.Point(8, 32);
			this.rdoDebito.Name = "rdoDebito";
			this.rdoDebito.Size = new System.Drawing.Size(96, 16);
			this.rdoDebito.TabIndex = 2;
			this.rdoDebito.Tag = "banktransaction.kind:D";
			this.rdoDebito.Text = "a Debito";
			this.rdoDebito.CheckedChanged += new System.EventHandler(this.rdoDebito_CheckedChanged);
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(120, 12);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
			this.txtEsercizio.TabIndex = 1;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "";
			this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Esercizio";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 36);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "banktransaction.nban";
			// 
			// gboxMandato
			// 
			this.gboxMandato.Controls.Add(this.btnMandato);
			this.gboxMandato.Controls.Add(this.txtNumeroMandato);
			this.gboxMandato.Controls.Add(this.label3);
			this.gboxMandato.Location = new System.Drawing.Point(208, 68);
			this.gboxMandato.Name = "gboxMandato";
			this.gboxMandato.Size = new System.Drawing.Size(192, 75);
			this.gboxMandato.TabIndex = 4;
			this.gboxMandato.TabStop = false;
			this.gboxMandato.Tag = "AutoChoose.txtNumeroMandato.listapermovbancario";
			this.gboxMandato.Text = "Mandato";
			// 
			// btnMandato
			// 
			this.btnMandato.Location = new System.Drawing.Point(8, 16);
			this.btnMandato.Name = "btnMandato";
			this.btnMandato.Size = new System.Drawing.Size(96, 23);
			this.btnMandato.TabIndex = 9;
			this.btnMandato.TabStop = false;
			this.btnMandato.Tag = "choose.payment.lista";
			this.btnMandato.Text = "Documento";
			// 
			// txtNumeroMandato
			// 
			this.txtNumeroMandato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNumeroMandato.Location = new System.Drawing.Point(80, 51);
			this.txtNumeroMandato.Name = "txtNumeroMandato";
			this.txtNumeroMandato.Size = new System.Drawing.Size(100, 20);
			this.txtNumeroMandato.TabIndex = 2;
			this.txtNumeroMandato.Tag = "payment.npay?banktransactionview.npay";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.Location = new System.Drawing.Point(24, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxReversale
			// 
			this.gboxReversale.Controls.Add(this.btnReversale);
			this.gboxReversale.Controls.Add(this.txtNumeroReversale);
			this.gboxReversale.Controls.Add(this.label5);
			this.gboxReversale.Location = new System.Drawing.Point(8, 68);
			this.gboxReversale.Name = "gboxReversale";
			this.gboxReversale.Size = new System.Drawing.Size(192, 75);
			this.gboxReversale.TabIndex = 3;
			this.gboxReversale.TabStop = false;
			this.gboxReversale.Tag = "AutoChoose.txtNumeroReversale.listapermovbancario";
			this.gboxReversale.Text = "Reversale";
			// 
			// btnReversale
			// 
			this.btnReversale.Location = new System.Drawing.Point(8, 16);
			this.btnReversale.Name = "btnReversale";
			this.btnReversale.Size = new System.Drawing.Size(96, 23);
			this.btnReversale.TabIndex = 10;
			this.btnReversale.TabStop = false;
			this.btnReversale.Tag = "choose.proceeds.lista";
			this.btnReversale.Text = "Documento";
			// 
			// txtNumeroReversale
			// 
			this.txtNumeroReversale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNumeroReversale.Location = new System.Drawing.Point(80, 51);
			this.txtNumeroReversale.Name = "txtNumeroReversale";
			this.txtNumeroReversale.Size = new System.Drawing.Size(100, 20);
			this.txtNumeroReversale.TabIndex = 2;
			this.txtNumeroReversale.Tag = "proceeds.npro?banktransactionview.npro";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.Location = new System.Drawing.Point(24, 51);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Numero:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 373);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 7;
			this.label7.Tag = "";
			this.label7.Text = "Riferimento Banca:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(16, 405);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "Data Operazione:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(224, 405);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 23);
			this.label9.TabIndex = 9;
			this.label9.Text = "Data Valuta:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 437);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 10;
			this.label10.Text = "Importo:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(120, 373);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(280, 20);
			this.textBox7.TabIndex = 5;
			this.textBox7.Tag = "banktransaction.bankreference";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(120, 405);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(100, 20);
			this.textBox8.TabIndex = 6;
			this.textBox8.Tag = "banktransaction.transactiondate";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(296, 405);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(104, 20);
			this.textBox9.TabIndex = 7;
			this.textBox9.Tag = "banktransaction.valuedate";
			// 
			// txtImportoEsito
			// 
			this.txtImportoEsito.Location = new System.Drawing.Point(120, 437);
			this.txtImportoEsito.Name = "txtImportoEsito";
			this.txtImportoEsito.Size = new System.Drawing.Size(100, 20);
			this.txtImportoEsito.TabIndex = 8;
			this.txtImportoEsito.Tag = "banktransaction.amount";
			// 
			// grpEntrata
			// 
			this.grpEntrata.Controls.Add(this.txtNumMovEntrata);
			this.grpEntrata.Controls.Add(this.btnEntrata);
			this.grpEntrata.Controls.Add(this.label12);
			this.grpEntrata.Location = new System.Drawing.Point(8, 149);
			this.grpEntrata.Name = "grpEntrata";
			this.grpEntrata.Size = new System.Drawing.Size(192, 76);
			this.grpEntrata.TabIndex = 11;
			this.grpEntrata.TabStop = false;
			this.grpEntrata.Tag = "AutoChoose.txtNumMovEntrata.default";
			this.grpEntrata.Text = "Entrata";
			// 
			// txtNumMovEntrata
			// 
			this.txtNumMovEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNumMovEntrata.Location = new System.Drawing.Point(80, 48);
			this.txtNumMovEntrata.Name = "txtNumMovEntrata";
			this.txtNumMovEntrata.Size = new System.Drawing.Size(100, 20);
			this.txtNumMovEntrata.TabIndex = 6;
			this.txtNumMovEntrata.Tag = "incomeview.nmov?banktransactionview.ninc";
			// 
			// btnEntrata
			// 
			this.btnEntrata.Location = new System.Drawing.Point(8, 16);
			this.btnEntrata.Name = "btnEntrata";
			this.btnEntrata.Size = new System.Drawing.Size(96, 23);
			this.btnEntrata.TabIndex = 2;
			this.btnEntrata.Tag = "choose.incomeview.default";
			this.btnEntrata.Text = "entrata";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.Location = new System.Drawing.Point(24, 48);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 23);
			this.label12.TabIndex = 1;
			this.label12.Text = "Numero:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpSpesa
			// 
			this.grpSpesa.Controls.Add(this.txtNumMovSpesa);
			this.grpSpesa.Controls.Add(this.btnSpesa);
			this.grpSpesa.Controls.Add(this.label14);
			this.grpSpesa.Location = new System.Drawing.Point(208, 149);
			this.grpSpesa.Name = "grpSpesa";
			this.grpSpesa.Size = new System.Drawing.Size(192, 76);
			this.grpSpesa.TabIndex = 12;
			this.grpSpesa.TabStop = false;
			this.grpSpesa.Tag = "AutoChoose.txtNumMovSpesa.default";
			this.grpSpesa.Text = "Spesa";
			// 
			// txtNumMovSpesa
			// 
			this.txtNumMovSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtNumMovSpesa.Location = new System.Drawing.Point(80, 48);
			this.txtNumMovSpesa.Name = "txtNumMovSpesa";
			this.txtNumMovSpesa.Size = new System.Drawing.Size(100, 20);
			this.txtNumMovSpesa.TabIndex = 5;
			this.txtNumMovSpesa.Tag = "expenseview.nmov?banktransactionview.nexp";
			// 
			// btnSpesa
			// 
			this.btnSpesa.Location = new System.Drawing.Point(8, 16);
			this.btnSpesa.Name = "btnSpesa";
			this.btnSpesa.Size = new System.Drawing.Size(96, 23);
			this.btnSpesa.TabIndex = 3;
			this.btnSpesa.Tag = "choose.expenseview.default";
			this.btnSpesa.Text = "spesa";
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.Location = new System.Drawing.Point(24, 48);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 23);
			this.label14.TabIndex = 2;
			this.label14.Text = "Numero:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Location = new System.Drawing.Point(8, 241);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 48);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Progressivo Entrata";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 18);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Tag = "banktransaction.idpro";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox3);
			this.groupBox3.Location = new System.Drawing.Point(208, 241);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(192, 48);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Progressivo Spesa";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(8, 18);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "banktransaction.idpay";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(424, 530);
			this.tabControl1.TabIndex = 15;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnCollegaBankImport);
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.txtEsercizio);
			this.tabPage1.Controls.Add(this.grpSpesa);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.grpEntrata);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.txtImportoEsito);
			this.tabPage1.Controls.Add(this.gboxMandato);
			this.tabPage1.Controls.Add(this.textBox9);
			this.tabPage1.Controls.Add(this.gboxReversale);
			this.tabPage1.Controls.Add(this.textBox8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.textBox7);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(416, 504);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Transazione";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// btnCollegaBankImport
			// 
			this.btnCollegaBankImport.Location = new System.Drawing.Point(3, 311);
			this.btnCollegaBankImport.Name = "btnCollegaBankImport";
			this.btnCollegaBankImport.Size = new System.Drawing.Size(166, 40);
			this.btnCollegaBankImport.TabIndex = 16;
			this.btnCollegaBankImport.Tag = "choose.bankimport.default";
			this.btnCollegaBankImport.Text = "Collega a Importazione esiti e sospesi";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label15);
			this.groupBox6.Controls.Add(this.textBox4);
			this.groupBox6.Controls.Add(this.label16);
			this.groupBox6.Controls.Add(this.textBox5);
			this.groupBox6.Location = new System.Drawing.Point(175, 295);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(235, 65);
			this.groupBox6.TabIndex = 15;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Importazione esiti Bancari";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(128, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 16);
			this.label15.TabIndex = 3;
			this.label15.Text = "Numero";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(176, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(56, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.Tag = "bankimport.idbankimport";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 16);
			this.label16.TabIndex = 1;
			this.label16.Text = "Esercizio";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(64, 16);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(56, 20);
			this.textBox5.TabIndex = 0;
			this.textBox5.Tag = "bankimport.ayear";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dGridClassSup);
			this.tabPage2.Controls.Add(this.btnElimina);
			this.tabPage2.Controls.Add(this.btnModifica);
			this.tabPage2.Controls.Add(this.btnInserisci);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(416, 504);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Classificazione";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dGridClassSup
			// 
			this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassSup.DataMember = "";
			this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassSup.Location = new System.Drawing.Point(6, 36);
			this.dGridClassSup.Name = "dGridClassSup";
			this.dGridClassSup.Size = new System.Drawing.Size(404, 462);
			this.dGridClassSup.TabIndex = 18;
			this.dGridClassSup.Tag = "banktransactionsorting.default.default";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(249, 6);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(72, 24);
			this.btnElimina.TabIndex = 17;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(171, 6);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(72, 24);
			this.btnModifica.TabIndex = 16;
			this.btnModifica.Tag = "edit.default";
			this.btnModifica.Text = "Modifica";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(93, 6);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(72, 24);
			this.btnInserisci.TabIndex = 15;
			this.btnInserisci.Tag = "insert.default";
			this.btnInserisci.Text = "Inserisci";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_banktransaction_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(429, 535);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_banktransaction_default";
			this.Text = "Frm_banktransaction_default";
			this.groupBox1.ResumeLayout(false);
			this.gboxMandato.ResumeLayout(false);
			this.gboxMandato.PerformLayout();
			this.gboxReversale.ResumeLayout(false);
			this.gboxReversale.PerformLayout();
			this.grpEntrata.ResumeLayout(false);
			this.grpEntrata.PerformLayout();
			this.grpSpesa.ResumeLayout(false);
			this.grpSpesa.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		void SetGBoxExpense(){
			if (rdoCredito.Checked) {
				gboxMandato.Enabled = false;
				grpSpesa.Enabled = false;
				return;
			}

			string filterspesa="";
			filterspesa = QHS.AppAnd(filterspesa, QHS.CmpEq("ypay", Meta.GetSys("esercizio")));

			if (txtNumeroMandato.Text!=""){
				filterspesa = QHS.AppAnd(filterspesa, QHS.CmpEq("npay", txtNumeroMandato.Text));
			}


			MetaData.AutoInfo AI_Spesa;
			AI_Spesa = Meta.GetAutoInfo(txtNumMovSpesa.Name);
			if (AI_Spesa!=null) AI_Spesa.startfilter = filterspesa;
			btnSpesa.Tag = standardTagBtnSpesa + "." + filterspesa;
		
			gboxMandato.Enabled = true;
			grpSpesa.Enabled = true;



		}

		void SetGBoxIncome(){
			if (rdoDebito.Checked){
				gboxReversale.Enabled = false;
				grpEntrata.Enabled = false;
				return;
			}

			string filterentrata="";
			filterentrata = QHS.AppAnd(filterentrata, QHS.CmpEq("ypro", Meta.GetSys("esercizio")));
			if (txtNumeroReversale.Text!=""){
                filterentrata = QHS.AppAnd(filterentrata, QHS.CmpEq("npro", txtNumeroReversale.Text));
			}

			MetaData.AutoInfo AI_Entrata;
			AI_Entrata = Meta.GetAutoInfo(txtNumMovEntrata.Name);
			if (AI_Entrata!=null) AI_Entrata.startfilter = filterentrata;
			btnEntrata.Tag = standardTagBtnEntrata+ "." + filterentrata;				

			gboxReversale.Enabled = true;
			grpEntrata.Enabled = true;


		}



		void AggiornaGBox(){
			if (!Meta.DrawStateIsDone) return;
			if (rdoCredito.Checked) {
				if (DS.banktransaction.Rows.Count == 0) return;
				DataRow Curr = DS.banktransaction.Rows[0];
				DS.payment.Clear();
				Curr["kpay"] = DBNull.Value;
				Curr["idpay"] = DBNull.Value;
				Curr["idexp"] = DBNull.Value;
				txtNumeroMandato.Text = "";
				txtNumMovSpesa.Text = "";


			}
			if (rdoDebito.Checked) {
				if (DS.banktransaction.Rows.Count == 0) return;
				DataRow Curr = DS.banktransaction.Rows[0];
				DS.proceeds.Clear();
				Curr["kpro"] = DBNull.Value;
				Curr["idpro"] = DBNull.Value;
				Curr["idinc"] = DBNull.Value;
				txtNumeroReversale.Text = "";
				txtNumMovEntrata.Text = "";


			}		

		}


		private void rdoCredito_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			AggiornaGBox();
			SetGBoxExpense();
			SetGBoxIncome();
		}

		private void rdoDebito_CheckedChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone)return;
			AggiornaGBox();
			SetGBoxExpense();
			SetGBoxIncome();
		}
    }
}
