
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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;
using SituazioneViewer;//SituazioneViewer

namespace ivapay_default {//liquidazioneiva//
	/// <summary>
	/// Summary description for frmliquidazioneiva.
	/// </summary>
	public class Frm_ivapay_default : MetaDataForm {
		public vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdoAcconto;
		private System.Windows.Forms.RadioButton rdoPeriodica;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid3;
		private System.Windows.Forms.GroupBox gboxmovimenti;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtTotaleMovSpe;
        private System.Windows.Forms.TextBox txtTotaleMovEnt;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.DataGrid dataGrid4;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TabPage tabEP;
		private System.Windows.Forms.Button btnVisualizzaEP;
		private System.Windows.Forms.Label labEP;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private TextBox txtLiquidMese;
        private Label label37;
        private Label labCredito4;
        private Label labCredito3;
        private TextBox txtNuovoSaldo;
        private Label label36;
        private Panel panel2;
        private Label label25;
        private Label label26;
        private Label lblcredito5;
        private Label lblcredito2;
        private Label lblcredito1;
        private TextBox txtIvaPeriodo;
        private Label label6;
        private TextBox txtTotaleIva;
        private Label lblSaldoCorr;
        private TextBox txtSaldoPrec;
        private Label label12;
        private Button btnRiepilogo;
        private TabPage tabPgINTRA;
        private GroupBox gboxmovimenti12;
        private TextBox txtTotaleMovSpe12;
        private Label label8;
        private TextBox txtTotaleMovEnt12;
        private Label label9;
        private GroupBox groupBox9;
        private TextBox txtLiquidMese12;
        private Label label10;
        private Label lblcredito4_12;
        private Label lblcredito3_12;
        private TextBox txtNuovoSaldo12;
        private Label label27;
        private Panel panel1;
        private Label label28;
        private Label label29;
        private Label lblcredito5_12;
        private Label lblcredito2_12;
        private Label lblcredito1_12;
        private TextBox txtIvaPeriodo12;
        private Label label33;
        private TextBox txtTotaleIva12;
        private Label label34;
        private TextBox txtSaldoPrec12;
        private Label label35;
        private GroupBox groupBox10;
        private TextBox textBox17;
        private Label label38;
        private TextBox textBox19;
        private Label label40;
        private Label label58;
        private CheckBox chkIstituzionale;
        private CheckBox chkCommerciale;
        private GroupBox gboxmanuale;
        private TextBox textBox5;
        private Label label13;
        private TextBox textBox8;
        private Label label22;
        private GroupBox gboxmanuale12;
        private TextBox textBox9;
        private Label label30;
        private TextBox textBox11;
        private Label label31;
        private CheckBox chkSplit;
        private TabPage tabSplitPayment;
        private GroupBox gboxmanualeSplit;
        private TextBox textBox12;
        private Label label32;
        private Label label41;
        private GroupBox gboxmovimentiSplit;
        private TextBox txtTotaleMovSpeSplit;
        private Label label42;
        private GroupBox groupBox11;
        private TextBox txtLiquidMeseSplit;
        private Label label44;
        private Label lblcredito4_split;
        private Label lblcredito3_split;
        private TextBox txtNuovoSaldoSplit;
        private Label label47;
        private Panel panel3;
        private Label label48;
        private Label label49;
        private Label lblcredito5_split;
        private Label lblcredito2_split;
        private Label lblcredito1_split;
        private TextBox txtIvaPeriodoSplit;
        private Label label53;
        private TextBox txtTotaleIvaSplit;
        private Label label54;
        private TextBox txtSaldoPrecSplit;
        private Label label55;
        private GroupBox groupBox12;
        private TextBox textBox25;
        private Label label56;
        private TabPage tabFatture;
        private TabControl tabControl2;
        private TabPage tabPage6;
        private Label label39;
        private TextBox txtIvaVendita;
        private DataGrid gridDebito;
        private TabPage tabPage7;
        private Label label51;
        private DataGrid gridAcquisti;
        private TextBox txtIvaAcquistiComm;
        private Label label60;
        private TabPage tabPage8;
        private Label label61;
        private DataGrid gridacquistipromiscui;
        private TextBox txtIvaAcquistiProm;
        private Label labTotIvaPromPOST;
        private TabPage tabIntra12;
        private Label label71;
        private DataGrid gridacquistiistituzionaliINTRA;
        private TextBox txtIvaIstituz;
        private Label label74;
        private TabPage tabPage9;
        private Label label78;
        private DataGrid gridacquistiistituzionaliSplit;
        private TextBox txtIvaIstituzSplit;
        private Label label81;
        private Label lblMessaggi;
        private Button btnGeneraEP;
        private MetaData Meta;
        private TextBox textBox14;
        private Label label43;
        private TabPage tabPage3;
        private GroupBox grpMetodoAcconto;
        private RadioButton rdbMetodoAcconto4;
        private RadioButton rdbMetodoAcconto1;
        private RadioButton rdbMetodoAcconto3;
        private RadioButton rdbMetodoAcconto2;
        private Label label45;
        private TextBox txtF24ep;
        private EP_Manager epm;
		public Frm_ivapay_default() {
			InitializeComponent();
			GetData.SetSorting(DS.ivapay,"yivapay DESC");
			DataAccess.SetTableForReading(DS.dettliquidazioneivaview_debito,"ivapaydetailview");
			QueryCreator.SetTableForPosting(DS.dettliquidazioneivaview_debito,"ivapaydetailview");
			QueryCreator.SetTableForPosting(DS.ivapaydetailview,"ivapaydetail");
			QueryCreator.SetTableForPosting(DS.ivapayincomeview,"ivapayincome");
			QueryCreator.SetTableForPosting(DS.ivapayexpenseview,"ivapayexpense");
            DataAccess.SetTableForReading(DS.deferredview_fatture_vendita, "invoicedeferredview");
            DataAccess.SetTableForReading(DS.deferredview_fatture_acquisti_comm, "invoicedeferredview");
            DataAccess.SetTableForReading(DS.deferredview_fatture_acquisti_prom, "invoicedeferredview");
            DataAccess.SetTableForReading(DS.deferredview_fatture_acquisti_ist_intraextra, "invoicedeferredview");
            DataAccess.SetTableForReading(DS.deferredview_fatture_acquisti_ist_split, "invoicedeferredview");
			GetData.CacheTable(DS.incomephase);
			GetData.CacheTable(DS.expensephase);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label45 = new System.Windows.Forms.Label();
			this.txtF24ep = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.gboxmanuale = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.btnRiepilogo = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.gboxmovimenti = new System.Windows.Forms.GroupBox();
			this.txtTotaleMovSpe = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtTotaleMovEnt = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtLiquidMese = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.labCredito4 = new System.Windows.Forms.Label();
			this.labCredito3 = new System.Windows.Forms.Label();
			this.txtNuovoSaldo = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.lblcredito5 = new System.Windows.Forms.Label();
			this.lblcredito2 = new System.Windows.Forms.Label();
			this.lblcredito1 = new System.Windows.Forms.Label();
			this.txtIvaPeriodo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTotaleIva = new System.Windows.Forms.TextBox();
			this.lblSaldoCorr = new System.Windows.Forms.Label();
			this.txtSaldoPrec = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkSplit = new System.Windows.Forms.CheckBox();
			this.chkIstituzionale = new System.Windows.Forms.CheckBox();
			this.chkCommerciale = new System.Windows.Forms.CheckBox();
			this.rdoAcconto = new System.Windows.Forms.RadioButton();
			this.rdoPeriodica = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabSplitPayment = new System.Windows.Forms.TabPage();
			this.gboxmanualeSplit = new System.Windows.Forms.GroupBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.gboxmovimentiSplit = new System.Windows.Forms.GroupBox();
			this.txtTotaleMovSpeSplit = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtLiquidMeseSplit = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.lblcredito4_split = new System.Windows.Forms.Label();
			this.lblcredito3_split = new System.Windows.Forms.Label();
			this.txtNuovoSaldoSplit = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.lblcredito5_split = new System.Windows.Forms.Label();
			this.lblcredito2_split = new System.Windows.Forms.Label();
			this.lblcredito1_split = new System.Windows.Forms.Label();
			this.txtIvaPeriodoSplit = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.txtTotaleIvaSplit = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.txtSaldoPrecSplit = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.textBox25 = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.tabPgINTRA = new System.Windows.Forms.TabPage();
			this.gboxmanuale12 = new System.Windows.Forms.GroupBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.gboxmovimenti12 = new System.Windows.Forms.GroupBox();
			this.txtTotaleMovSpe12 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtTotaleMovEnt12 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txtLiquidMese12 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.lblcredito4_12 = new System.Windows.Forms.Label();
			this.lblcredito3_12 = new System.Windows.Forms.Label();
			this.txtNuovoSaldo12 = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label28 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.lblcredito5_12 = new System.Windows.Forms.Label();
			this.lblcredito2_12 = new System.Windows.Forms.Label();
			this.lblcredito1_12 = new System.Windows.Forms.Label();
			this.txtIvaPeriodo12 = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.txtTotaleIva12 = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.txtSaldoPrec12 = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.tabFatture = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.label39 = new System.Windows.Forms.Label();
			this.lblMessaggi = new System.Windows.Forms.Label();
			this.txtIvaVendita = new System.Windows.Forms.TextBox();
			this.gridDebito = new System.Windows.Forms.DataGrid();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.txtIvaAcquistiComm = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.gridAcquisti = new System.Windows.Forms.DataGrid();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.txtIvaAcquistiProm = new System.Windows.Forms.TextBox();
			this.labTotIvaPromPOST = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.gridacquistipromiscui = new System.Windows.Forms.DataGrid();
			this.tabIntra12 = new System.Windows.Forms.TabPage();
			this.txtIvaIstituz = new System.Windows.Forms.TextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.gridacquistiistituzionaliINTRA = new System.Windows.Forms.DataGrid();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.txtIvaIstituzSplit = new System.Windows.Forms.TextBox();
			this.label81 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.gridacquistiistituzionaliSplit = new System.Windows.Forms.DataGrid();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.grpMetodoAcconto = new System.Windows.Forms.GroupBox();
			this.rdbMetodoAcconto4 = new System.Windows.Forms.RadioButton();
			this.rdbMetodoAcconto1 = new System.Windows.Forms.RadioButton();
			this.rdbMetodoAcconto3 = new System.Windows.Forms.RadioButton();
			this.rdbMetodoAcconto2 = new System.Windows.Forms.RadioButton();
			this.DS = new ivapay_default.vistaForm();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxmanuale.SuspendLayout();
			this.gboxmovimenti.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabSplitPayment.SuspendLayout();
			this.gboxmanualeSplit.SuspendLayout();
			this.gboxmovimentiSplit.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.tabPgINTRA.SuspendLayout();
			this.gboxmanuale12.SuspendLayout();
			this.gboxmovimenti12.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabFatture.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDebito)).BeginInit();
			this.tabPage7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAcquisti)).BeginInit();
			this.tabPage8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistipromiscui)).BeginInit();
			this.tabIntra12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliINTRA)).BeginInit();
			this.tabPage9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliSplit)).BeginInit();
			this.tabEP.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.grpMetodoAcconto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabSplitPayment);
			this.tabControl1.Controls.Add(this.tabPgINTRA);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabFatture);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(654, 549);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.Tag = "";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label45);
			this.tabPage1.Controls.Add(this.txtF24ep);
			this.tabPage1.Controls.Add(this.label43);
			this.tabPage1.Controls.Add(this.textBox14);
			this.tabPage1.Controls.Add(this.gboxmanuale);
			this.tabPage1.Controls.Add(this.btnRiepilogo);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label20);
			this.tabPage1.Controls.Add(this.gboxmovimenti);
			this.tabPage1.Controls.Add(this.textBox16);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.groupBox8);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(646, 523);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Commerciale";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(531, 405);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(47, 17);
			this.label45.TabIndex = 25;
			this.label45.Text = "F24 EP";
			// 
			// txtF24ep
			// 
			this.txtF24ep.Location = new System.Drawing.Point(587, 401);
			this.txtF24ep.Name = "txtF24ep";
			this.txtF24ep.Size = new System.Drawing.Size(42, 20);
			this.txtF24ep.TabIndex = 24;
			this.txtF24ep.TabStop = false;
			this.txtF24ep.Tag = "ivapay.idf24ep";
			this.txtF24ep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(498, 438);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(131, 45);
			this.label43.TabIndex = 23;
			this.label43.Text = "Credito anno precedente utilizzato (comunicazione periodica)";
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(498, 486);
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(128, 20);
			this.textBox14.TabIndex = 22;
			this.textBox14.TabStop = false;
			this.textBox14.Tag = "ivapay.startcredit_applied";
			this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gboxmanuale
			// 
			this.gboxmanuale.Controls.Add(this.textBox5);
			this.gboxmanuale.Controls.Add(this.label13);
			this.gboxmanuale.Controls.Add(this.textBox8);
			this.gboxmanuale.Controls.Add(this.label22);
			this.gboxmanuale.Location = new System.Drawing.Point(9, 446);
			this.gboxmanuale.Name = "gboxmanuale";
			this.gboxmanuale.Size = new System.Drawing.Size(450, 64);
			this.gboxmanuale.TabIndex = 21;
			this.gboxmanuale.TabStop = false;
			this.gboxmanuale.Text = "Importi liquidati da considerare ai fini dei calcoli successivi (INSERIMENTO MANU" +
    "ALE)";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(160, 40);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(128, 20);
			this.textBox5.TabIndex = 12;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "ivapay.paymentamount";
			this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(160, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(112, 16);
			this.label13.TabIndex = 11;
			this.label13.Text = "Versamenti";
			this.label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(8, 40);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(128, 20);
			this.textBox8.TabIndex = 10;
			this.textBox8.TabStop = false;
			this.textBox8.Tag = "ivapay.refundamount";
			this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(8, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(48, 16);
			this.label22.TabIndex = 9;
			this.label22.Text = "Incassi";
			this.label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnRiepilogo
			// 
			this.btnRiepilogo.Location = new System.Drawing.Point(559, 80);
			this.btnRiepilogo.Name = "btnRiepilogo";
			this.btnRiepilogo.Size = new System.Drawing.Size(78, 26);
			this.btnRiepilogo.TabIndex = 20;
			this.btnRiepilogo.Text = "Riepilogo";
			this.btnRiepilogo.UseVisualStyleBackColor = true;
			this.btnRiepilogo.Click += new System.EventHandler(this.btnRiepilogo_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(416, 402);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(64, 20);
			this.textBox1.TabIndex = 18;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "ivapay.mixed.fixed.2..%.100";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(272, 402);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(136, 16);
			this.label20.TabIndex = 19;
			this.label20.Text = "% di Promiscuo applicato:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// gboxmovimenti
			// 
			this.gboxmovimenti.Controls.Add(this.txtTotaleMovSpe);
			this.gboxmovimenti.Controls.Add(this.label16);
			this.gboxmovimenti.Controls.Add(this.txtTotaleMovEnt);
			this.gboxmovimenti.Controls.Add(this.label15);
			this.gboxmovimenti.Location = new System.Drawing.Point(251, 325);
			this.gboxmovimenti.Name = "gboxmovimenti";
			this.gboxmovimenti.Size = new System.Drawing.Size(378, 64);
			this.gboxmovimenti.TabIndex = 6;
			this.gboxmovimenti.TabStop = false;
			this.gboxmovimenti.Text = "Totale movimenti finanziari collegati";
			// 
			// txtTotaleMovSpe
			// 
			this.txtTotaleMovSpe.Location = new System.Drawing.Point(160, 40);
			this.txtTotaleMovSpe.Name = "txtTotaleMovSpe";
			this.txtTotaleMovSpe.ReadOnly = true;
			this.txtTotaleMovSpe.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleMovSpe.TabIndex = 12;
			this.txtTotaleMovSpe.TabStop = false;
			this.txtTotaleMovSpe.Tag = "ivapay.importocorrente";
			this.txtTotaleMovSpe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(160, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(48, 16);
			this.label16.TabIndex = 11;
			this.label16.Text = "Spese";
			this.label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtTotaleMovEnt
			// 
			this.txtTotaleMovEnt.Location = new System.Drawing.Point(8, 40);
			this.txtTotaleMovEnt.Name = "txtTotaleMovEnt";
			this.txtTotaleMovEnt.ReadOnly = true;
			this.txtTotaleMovEnt.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleMovEnt.TabIndex = 10;
			this.txtTotaleMovEnt.TabStop = false;
			this.txtTotaleMovEnt.Tag = "ivapay.importocorrente";
			this.txtTotaleMovEnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(48, 16);
			this.label15.TabIndex = 9;
			this.label15.Text = "Entrate";
			this.label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(192, 402);
			this.textBox16.Name = "textBox16";
			this.textBox16.ReadOnly = true;
			this.textBox16.Size = new System.Drawing.Size(64, 20);
			this.textBox16.TabIndex = 7;
			this.textBox16.TabStop = false;
			this.textBox16.Tag = "ivapay.prorata.fixed.2..%.100";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(48, 402);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(128, 16);
			this.label17.TabIndex = 17;
			this.label17.Text = "% di Pro rata applicato:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.textBox2);
			this.groupBox8.Controls.Add(this.label3);
			this.groupBox8.Controls.Add(this.textBox3);
			this.groupBox8.Controls.Add(this.label4);
			this.groupBox8.Location = new System.Drawing.Point(8, 77);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(312, 48);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Periodo della liquidazione";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(224, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(74, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "ivapay.stop";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(184, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "Al";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(72, 22);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(74, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "ivapay.start";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Dal";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.textBox13);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.textBox10);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Location = new System.Drawing.Point(8, 235);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(234, 154);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Regolamento";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(16, 55);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.Size = new System.Drawing.Size(208, 72);
			this.textBox13.TabIndex = 18;
			this.textBox13.Tag = "ivapay.paymentdetails";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(16, 39);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(128, 16);
			this.label14.TabIndex = 17;
			this.label14.Text = "Estremi del versamento";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(144, 15);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(80, 20);
			this.textBox10.TabIndex = 16;
			this.textBox10.Tag = "ivapay.assesmentdate";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(40, 15);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 16);
			this.label11.TabIndex = 15;
			this.label11.Text = "Data";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtLiquidMese);
			this.groupBox4.Controls.Add(this.label37);
			this.groupBox4.Controls.Add(this.labCredito4);
			this.groupBox4.Controls.Add(this.labCredito3);
			this.groupBox4.Controls.Add(this.txtNuovoSaldo);
			this.groupBox4.Controls.Add(this.label36);
			this.groupBox4.Controls.Add(this.panel2);
			this.groupBox4.Controls.Add(this.label25);
			this.groupBox4.Controls.Add(this.label26);
			this.groupBox4.Controls.Add(this.lblcredito5);
			this.groupBox4.Controls.Add(this.lblcredito2);
			this.groupBox4.Controls.Add(this.lblcredito1);
			this.groupBox4.Controls.Add(this.txtIvaPeriodo);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.txtTotaleIva);
			this.groupBox4.Controls.Add(this.lblSaldoCorr);
			this.groupBox4.Controls.Add(this.txtSaldoPrec);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Location = new System.Drawing.Point(251, 131);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(378, 188);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Saldo";
			// 
			// txtLiquidMese
			// 
			this.txtLiquidMese.Location = new System.Drawing.Point(133, 128);
			this.txtLiquidMese.Name = "txtLiquidMese";
			this.txtLiquidMese.ReadOnly = true;
			this.txtLiquidMese.Size = new System.Drawing.Size(96, 20);
			this.txtLiquidMese.TabIndex = 48;
			this.txtLiquidMese.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(8, 131);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(111, 13);
			this.label37.TabIndex = 47;
			this.label37.Text = "Liquidazione del mese";
			// 
			// labCredito4
			// 
			this.labCredito4.Location = new System.Drawing.Point(244, 131);
			this.labCredito4.Name = "labCredito4";
			this.labCredito4.Size = new System.Drawing.Size(72, 16);
			this.labCredito4.TabIndex = 46;
			// 
			// labCredito3
			// 
			this.labCredito3.Location = new System.Drawing.Point(244, 92);
			this.labCredito3.Name = "labCredito3";
			this.labCredito3.Size = new System.Drawing.Size(72, 16);
			this.labCredito3.TabIndex = 45;
			// 
			// txtNuovoSaldo
			// 
			this.txtNuovoSaldo.Location = new System.Drawing.Point(132, 156);
			this.txtNuovoSaldo.Name = "txtNuovoSaldo";
			this.txtNuovoSaldo.ReadOnly = true;
			this.txtNuovoSaldo.Size = new System.Drawing.Size(96, 20);
			this.txtNuovoSaldo.TabIndex = 44;
			this.txtNuovoSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(17, 159);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(112, 16);
			this.label36.TabIndex = 43;
			this.label36.Text = "Nuovo saldo";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(20, 77);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(316, 2);
			this.panel2.TabIndex = 42;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(324, 48);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(16, 16);
			this.label25.TabIndex = 41;
			this.label25.Text = "=";
			// 
			// label26
			// 
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(324, 27);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(16, 16);
			this.label26.TabIndex = 40;
			this.label26.Text = "+";
			// 
			// lblcredito5
			// 
			this.lblcredito5.Location = new System.Drawing.Point(244, 159);
			this.lblcredito5.Name = "lblcredito5";
			this.lblcredito5.Size = new System.Drawing.Size(72, 16);
			this.lblcredito5.TabIndex = 39;
			// 
			// lblcredito2
			// 
			this.lblcredito2.Location = new System.Drawing.Point(244, 50);
			this.lblcredito2.Name = "lblcredito2";
			this.lblcredito2.Size = new System.Drawing.Size(72, 16);
			this.lblcredito2.TabIndex = 38;
			// 
			// lblcredito1
			// 
			this.lblcredito1.Location = new System.Drawing.Point(244, 27);
			this.lblcredito1.Name = "lblcredito1";
			this.lblcredito1.Size = new System.Drawing.Size(72, 16);
			this.lblcredito1.TabIndex = 37;
			// 
			// txtIvaPeriodo
			// 
			this.txtIvaPeriodo.Location = new System.Drawing.Point(132, 50);
			this.txtIvaPeriodo.Name = "txtIvaPeriodo";
			this.txtIvaPeriodo.ReadOnly = true;
			this.txtIvaPeriodo.Size = new System.Drawing.Size(96, 20);
			this.txtIvaPeriodo.TabIndex = 36;
			this.txtIvaPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 16);
			this.label6.TabIndex = 35;
			this.label6.Text = "Iva del periodo";
			// 
			// txtTotaleIva
			// 
			this.txtTotaleIva.Location = new System.Drawing.Point(132, 87);
			this.txtTotaleIva.Name = "txtTotaleIva";
			this.txtTotaleIva.ReadOnly = true;
			this.txtTotaleIva.Size = new System.Drawing.Size(96, 20);
			this.txtTotaleIva.TabIndex = 34;
			this.txtTotaleIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblSaldoCorr
			// 
			this.lblSaldoCorr.Location = new System.Drawing.Point(17, 92);
			this.lblSaldoCorr.Name = "lblSaldoCorr";
			this.lblSaldoCorr.Size = new System.Drawing.Size(112, 16);
			this.lblSaldoCorr.TabIndex = 33;
			this.lblSaldoCorr.Text = "Totale iva";
			// 
			// txtSaldoPrec
			// 
			this.txtSaldoPrec.Location = new System.Drawing.Point(132, 26);
			this.txtSaldoPrec.Name = "txtSaldoPrec";
			this.txtSaldoPrec.ReadOnly = true;
			this.txtSaldoPrec.Size = new System.Drawing.Size(96, 20);
			this.txtSaldoPrec.TabIndex = 32;
			this.txtSaldoPrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(21, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(112, 16);
			this.label12.TabIndex = 31;
			this.label12.Text = "Saldo precedente";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox7);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.textBox6);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBox4);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(8, 131);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(234, 104);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Liquidazione corrente";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(144, 48);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(80, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.Tag = "ivapay.totaldebit";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 48);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(128, 16);
			this.label21.TabIndex = 11;
			this.label21.Text = "Totale iva a debito";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(144, 72);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(80, 20);
			this.textBox6.TabIndex = 5;
			this.textBox6.Tag = "ivapay.dateivapay";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(56, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 16);
			this.label7.TabIndex = 9;
			this.label7.Text = "Data Contabile";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(144, 22);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(80, 20);
			this.textBox4.TabIndex = 1;
			this.textBox4.Tag = "ivapay.totalcredit";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Totale iva a credito";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkSplit);
			this.groupBox2.Controls.Add(this.chkIstituzionale);
			this.groupBox2.Controls.Add(this.chkCommerciale);
			this.groupBox2.Controls.Add(this.rdoAcconto);
			this.groupBox2.Controls.Add(this.rdoPeriodica);
			this.groupBox2.Location = new System.Drawing.Point(327, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(226, 117);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo di liquidazione";
			// 
			// chkSplit
			// 
			this.chkSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSplit.Location = new System.Drawing.Point(9, 90);
			this.chkSplit.Name = "chkSplit";
			this.chkSplit.Size = new System.Drawing.Size(197, 19);
			this.chkSplit.TabIndex = 28;
			this.chkSplit.Tag = "ivapay.flag:2";
			this.chkSplit.Text = "Iva Istituzionale  Split Payment";
			this.chkSplit.UseVisualStyleBackColor = true;
			// 
			// chkIstituzionale
			// 
			this.chkIstituzionale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkIstituzionale.Location = new System.Drawing.Point(9, 69);
			this.chkIstituzionale.Name = "chkIstituzionale";
			this.chkIstituzionale.Size = new System.Drawing.Size(197, 19);
			this.chkIstituzionale.TabIndex = 27;
			this.chkIstituzionale.Tag = "ivapay.flag:1";
			this.chkIstituzionale.Text = "Iva Istituzionale  Intra 12";
			this.chkIstituzionale.UseVisualStyleBackColor = true;
			// 
			// chkCommerciale
			// 
			this.chkCommerciale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkCommerciale.Location = new System.Drawing.Point(9, 47);
			this.chkCommerciale.Name = "chkCommerciale";
			this.chkCommerciale.Size = new System.Drawing.Size(211, 19);
			this.chkCommerciale.TabIndex = 26;
			this.chkCommerciale.Tag = "ivapay.flag:0";
			this.chkCommerciale.Text = "Iva Commerciale e Promiscua";
			this.chkCommerciale.UseVisualStyleBackColor = true;
			// 
			// rdoAcconto
			// 
			this.rdoAcconto.Location = new System.Drawing.Point(151, 17);
			this.rdoAcconto.Name = "rdoAcconto";
			this.rdoAcconto.Size = new System.Drawing.Size(74, 24);
			this.rdoAcconto.TabIndex = 1;
			this.rdoAcconto.Tag = "ivapay.paymentkind:A";
			this.rdoAcconto.Text = "Acconto";
			// 
			// rdoPeriodica
			// 
			this.rdoPeriodica.Location = new System.Drawing.Point(9, 17);
			this.rdoPeriodica.Name = "rdoPeriodica";
			this.rdoPeriodica.Size = new System.Drawing.Size(136, 24);
			this.rdoPeriodica.TabIndex = 0;
			this.rdoPeriodica.Tag = "ivapay.paymentkind:C";
			this.rdoPeriodica.Text = "Liquidazione periodica";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtNumero);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtEsercizio);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(8, 7);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(312, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Liquidazione";
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(224, 24);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(74, 20);
			this.txtNumero.TabIndex = 4;
			this.txtNumero.Tag = "ivapay.nivapay";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(72, 22);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(74, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.TabStop = false;
			this.txtEsercizio.Tag = "ivapay.yivapay.year";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabSplitPayment
			// 
			this.tabSplitPayment.Controls.Add(this.gboxmanualeSplit);
			this.tabSplitPayment.Controls.Add(this.label41);
			this.tabSplitPayment.Controls.Add(this.gboxmovimentiSplit);
			this.tabSplitPayment.Controls.Add(this.groupBox11);
			this.tabSplitPayment.Controls.Add(this.groupBox12);
			this.tabSplitPayment.Location = new System.Drawing.Point(4, 22);
			this.tabSplitPayment.Name = "tabSplitPayment";
			this.tabSplitPayment.Padding = new System.Windows.Forms.Padding(3);
			this.tabSplitPayment.Size = new System.Drawing.Size(646, 523);
			this.tabSplitPayment.TabIndex = 6;
			this.tabSplitPayment.Text = "Iva Istituzionale Split Payment";
			this.tabSplitPayment.UseVisualStyleBackColor = true;
			// 
			// gboxmanualeSplit
			// 
			this.gboxmanualeSplit.Controls.Add(this.textBox12);
			this.gboxmanualeSplit.Controls.Add(this.label32);
			this.gboxmanualeSplit.Location = new System.Drawing.Point(18, 307);
			this.gboxmanualeSplit.Name = "gboxmanualeSplit";
			this.gboxmanualeSplit.Size = new System.Drawing.Size(620, 64);
			this.gboxmanualeSplit.TabIndex = 56;
			this.gboxmanualeSplit.TabStop = false;
			this.gboxmanualeSplit.Text = "Importi liquidati da considerare ai fini dei calcoli successivi (INSERIMENTO MANU" +
    "ALE)";
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(161, 40);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(128, 20);
			this.textBox12.TabIndex = 12;
			this.textBox12.TabStop = false;
			this.textBox12.Tag = "ivapay.paymentamountsplit";
			this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label32.Location = new System.Drawing.Point(161, 16);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(112, 16);
			this.label32.TabIndex = 11;
			this.label32.Text = "Versamenti";
			this.label32.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label41.Location = new System.Drawing.Point(22, 22);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(251, 13);
			this.label41.TabIndex = 55;
			this.label41.Text = "Liquidazione iva istituzionale Split Payment";
			// 
			// gboxmovimentiSplit
			// 
			this.gboxmovimentiSplit.Controls.Add(this.txtTotaleMovSpeSplit);
			this.gboxmovimentiSplit.Controls.Add(this.label42);
			this.gboxmovimentiSplit.Location = new System.Drawing.Point(260, 237);
			this.gboxmovimentiSplit.Name = "gboxmovimentiSplit";
			this.gboxmovimentiSplit.Size = new System.Drawing.Size(378, 64);
			this.gboxmovimentiSplit.TabIndex = 54;
			this.gboxmovimentiSplit.TabStop = false;
			this.gboxmovimentiSplit.Text = "Totale movimenti finanziari collegati";
			// 
			// txtTotaleMovSpeSplit
			// 
			this.txtTotaleMovSpeSplit.Location = new System.Drawing.Point(160, 40);
			this.txtTotaleMovSpeSplit.Name = "txtTotaleMovSpeSplit";
			this.txtTotaleMovSpeSplit.ReadOnly = true;
			this.txtTotaleMovSpeSplit.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleMovSpeSplit.TabIndex = 12;
			this.txtTotaleMovSpeSplit.TabStop = false;
			this.txtTotaleMovSpeSplit.Tag = "ivapay.importocorrente";
			this.txtTotaleMovSpeSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(160, 16);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(48, 16);
			this.label42.TabIndex = 11;
			this.label42.Text = "Spese";
			this.label42.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.txtLiquidMeseSplit);
			this.groupBox11.Controls.Add(this.label44);
			this.groupBox11.Controls.Add(this.lblcredito4_split);
			this.groupBox11.Controls.Add(this.lblcredito3_split);
			this.groupBox11.Controls.Add(this.txtNuovoSaldoSplit);
			this.groupBox11.Controls.Add(this.label47);
			this.groupBox11.Controls.Add(this.panel3);
			this.groupBox11.Controls.Add(this.label48);
			this.groupBox11.Controls.Add(this.label49);
			this.groupBox11.Controls.Add(this.lblcredito5_split);
			this.groupBox11.Controls.Add(this.lblcredito2_split);
			this.groupBox11.Controls.Add(this.lblcredito1_split);
			this.groupBox11.Controls.Add(this.txtIvaPeriodoSplit);
			this.groupBox11.Controls.Add(this.label53);
			this.groupBox11.Controls.Add(this.txtTotaleIvaSplit);
			this.groupBox11.Controls.Add(this.label54);
			this.groupBox11.Controls.Add(this.txtSaldoPrecSplit);
			this.groupBox11.Controls.Add(this.label55);
			this.groupBox11.Location = new System.Drawing.Point(260, 43);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(378, 188);
			this.groupBox11.TabIndex = 53;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Saldo";
			// 
			// txtLiquidMeseSplit
			// 
			this.txtLiquidMeseSplit.Location = new System.Drawing.Point(133, 128);
			this.txtLiquidMeseSplit.Name = "txtLiquidMeseSplit";
			this.txtLiquidMeseSplit.ReadOnly = true;
			this.txtLiquidMeseSplit.Size = new System.Drawing.Size(96, 20);
			this.txtLiquidMeseSplit.TabIndex = 48;
			this.txtLiquidMeseSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(8, 131);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(111, 13);
			this.label44.TabIndex = 47;
			this.label44.Text = "Liquidazione del mese";
			// 
			// lblcredito4_split
			// 
			this.lblcredito4_split.Location = new System.Drawing.Point(244, 131);
			this.lblcredito4_split.Name = "lblcredito4_split";
			this.lblcredito4_split.Size = new System.Drawing.Size(72, 16);
			this.lblcredito4_split.TabIndex = 46;
			// 
			// lblcredito3_split
			// 
			this.lblcredito3_split.Location = new System.Drawing.Point(244, 92);
			this.lblcredito3_split.Name = "lblcredito3_split";
			this.lblcredito3_split.Size = new System.Drawing.Size(72, 16);
			this.lblcredito3_split.TabIndex = 45;
			// 
			// txtNuovoSaldoSplit
			// 
			this.txtNuovoSaldoSplit.Location = new System.Drawing.Point(132, 156);
			this.txtNuovoSaldoSplit.Name = "txtNuovoSaldoSplit";
			this.txtNuovoSaldoSplit.ReadOnly = true;
			this.txtNuovoSaldoSplit.Size = new System.Drawing.Size(96, 20);
			this.txtNuovoSaldoSplit.TabIndex = 44;
			this.txtNuovoSaldoSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(17, 159);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(112, 16);
			this.label47.TabIndex = 43;
			this.label47.Text = "Nuovo saldo";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(20, 77);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(316, 2);
			this.panel3.TabIndex = 42;
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label48.Location = new System.Drawing.Point(324, 48);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(16, 16);
			this.label48.TabIndex = 41;
			this.label48.Text = "=";
			// 
			// label49
			// 
			this.label49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label49.Location = new System.Drawing.Point(324, 27);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(16, 16);
			this.label49.TabIndex = 40;
			this.label49.Text = "+";
			// 
			// lblcredito5_split
			// 
			this.lblcredito5_split.Location = new System.Drawing.Point(244, 159);
			this.lblcredito5_split.Name = "lblcredito5_split";
			this.lblcredito5_split.Size = new System.Drawing.Size(72, 16);
			this.lblcredito5_split.TabIndex = 39;
			// 
			// lblcredito2_split
			// 
			this.lblcredito2_split.Location = new System.Drawing.Point(244, 50);
			this.lblcredito2_split.Name = "lblcredito2_split";
			this.lblcredito2_split.Size = new System.Drawing.Size(72, 16);
			this.lblcredito2_split.TabIndex = 38;
			// 
			// lblcredito1_split
			// 
			this.lblcredito1_split.Location = new System.Drawing.Point(244, 27);
			this.lblcredito1_split.Name = "lblcredito1_split";
			this.lblcredito1_split.Size = new System.Drawing.Size(72, 16);
			this.lblcredito1_split.TabIndex = 37;
			// 
			// txtIvaPeriodoSplit
			// 
			this.txtIvaPeriodoSplit.Location = new System.Drawing.Point(132, 50);
			this.txtIvaPeriodoSplit.Name = "txtIvaPeriodoSplit";
			this.txtIvaPeriodoSplit.ReadOnly = true;
			this.txtIvaPeriodoSplit.Size = new System.Drawing.Size(96, 20);
			this.txtIvaPeriodoSplit.TabIndex = 36;
			this.txtIvaPeriodoSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(20, 50);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(112, 16);
			this.label53.TabIndex = 35;
			this.label53.Text = "Iva del periodo";
			// 
			// txtTotaleIvaSplit
			// 
			this.txtTotaleIvaSplit.Location = new System.Drawing.Point(132, 87);
			this.txtTotaleIvaSplit.Name = "txtTotaleIvaSplit";
			this.txtTotaleIvaSplit.ReadOnly = true;
			this.txtTotaleIvaSplit.Size = new System.Drawing.Size(96, 20);
			this.txtTotaleIvaSplit.TabIndex = 34;
			this.txtTotaleIvaSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(17, 92);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(112, 16);
			this.label54.TabIndex = 33;
			this.label54.Text = "Totale iva";
			// 
			// txtSaldoPrecSplit
			// 
			this.txtSaldoPrecSplit.Location = new System.Drawing.Point(132, 26);
			this.txtSaldoPrecSplit.Name = "txtSaldoPrecSplit";
			this.txtSaldoPrecSplit.ReadOnly = true;
			this.txtSaldoPrecSplit.Size = new System.Drawing.Size(96, 20);
			this.txtSaldoPrecSplit.TabIndex = 32;
			this.txtSaldoPrecSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(21, 29);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(112, 16);
			this.label55.TabIndex = 31;
			this.label55.Text = "Saldo precedente";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.textBox25);
			this.groupBox12.Controls.Add(this.label56);
			this.groupBox12.Location = new System.Drawing.Point(20, 43);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(234, 80);
			this.groupBox12.TabIndex = 52;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Liquidazione corrente";
			// 
			// textBox25
			// 
			this.textBox25.Location = new System.Drawing.Point(144, 48);
			this.textBox25.Name = "textBox25";
			this.textBox25.ReadOnly = true;
			this.textBox25.Size = new System.Drawing.Size(80, 20);
			this.textBox25.TabIndex = 2;
			this.textBox25.Tag = "ivapay.totaldebitsplit";
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(8, 48);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(128, 16);
			this.label56.TabIndex = 11;
			this.label56.Text = "Totale iva a debito";
			this.label56.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabPgINTRA
			// 
			this.tabPgINTRA.Controls.Add(this.gboxmanuale12);
			this.tabPgINTRA.Controls.Add(this.label58);
			this.tabPgINTRA.Controls.Add(this.gboxmovimenti12);
			this.tabPgINTRA.Controls.Add(this.groupBox9);
			this.tabPgINTRA.Controls.Add(this.groupBox10);
			this.tabPgINTRA.Location = new System.Drawing.Point(4, 22);
			this.tabPgINTRA.Name = "tabPgINTRA";
			this.tabPgINTRA.Padding = new System.Windows.Forms.Padding(3);
			this.tabPgINTRA.Size = new System.Drawing.Size(646, 523);
			this.tabPgINTRA.TabIndex = 5;
			this.tabPgINTRA.Text = "INTRA e Extra-UE";
			this.tabPgINTRA.UseVisualStyleBackColor = true;
			// 
			// gboxmanuale12
			// 
			this.gboxmanuale12.Controls.Add(this.textBox9);
			this.gboxmanuale12.Controls.Add(this.label30);
			this.gboxmanuale12.Controls.Add(this.textBox11);
			this.gboxmanuale12.Controls.Add(this.label31);
			this.gboxmanuale12.Location = new System.Drawing.Point(18, 307);
			this.gboxmanuale12.Name = "gboxmanuale12";
			this.gboxmanuale12.Size = new System.Drawing.Size(620, 64);
			this.gboxmanuale12.TabIndex = 51;
			this.gboxmanuale12.TabStop = false;
			this.gboxmanuale12.Text = "Importi liquidati da considerare ai fini dei calcoli successivi (INSERIMENTO MANU" +
    "ALE)";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(160, 40);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(128, 20);
			this.textBox9.TabIndex = 12;
			this.textBox9.TabStop = false;
			this.textBox9.Tag = "ivapay.paymentamount12";
			this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label30
			// 
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label30.Location = new System.Drawing.Point(160, 16);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(112, 16);
			this.label30.TabIndex = 11;
			this.label30.Text = "Versamenti";
			this.label30.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(8, 40);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(128, 20);
			this.textBox11.TabIndex = 10;
			this.textBox11.TabStop = false;
			this.textBox11.Tag = "ivapay.refundamount12";
			this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label31
			// 
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label31.Location = new System.Drawing.Point(8, 16);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(48, 16);
			this.label31.TabIndex = 9;
			this.label31.Text = "Incassi";
			this.label31.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label58.Location = new System.Drawing.Point(22, 22);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(269, 13);
			this.label58.TabIndex = 50;
			this.label58.Text = "Liquidazione iva istituzionale INTRA e Extra-UE";
			// 
			// gboxmovimenti12
			// 
			this.gboxmovimenti12.Controls.Add(this.txtTotaleMovSpe12);
			this.gboxmovimenti12.Controls.Add(this.label8);
			this.gboxmovimenti12.Controls.Add(this.txtTotaleMovEnt12);
			this.gboxmovimenti12.Controls.Add(this.label9);
			this.gboxmovimenti12.Location = new System.Drawing.Point(260, 237);
			this.gboxmovimenti12.Name = "gboxmovimenti12";
			this.gboxmovimenti12.Size = new System.Drawing.Size(378, 64);
			this.gboxmovimenti12.TabIndex = 9;
			this.gboxmovimenti12.TabStop = false;
			this.gboxmovimenti12.Text = "Totale movimenti finanziari collegati";
			// 
			// txtTotaleMovSpe12
			// 
			this.txtTotaleMovSpe12.Location = new System.Drawing.Point(160, 40);
			this.txtTotaleMovSpe12.Name = "txtTotaleMovSpe12";
			this.txtTotaleMovSpe12.ReadOnly = true;
			this.txtTotaleMovSpe12.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleMovSpe12.TabIndex = 12;
			this.txtTotaleMovSpe12.TabStop = false;
			this.txtTotaleMovSpe12.Tag = "ivapay.importocorrente";
			this.txtTotaleMovSpe12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(160, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 16);
			this.label8.TabIndex = 11;
			this.label8.Text = "Spese";
			this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtTotaleMovEnt12
			// 
			this.txtTotaleMovEnt12.Location = new System.Drawing.Point(8, 40);
			this.txtTotaleMovEnt12.Name = "txtTotaleMovEnt12";
			this.txtTotaleMovEnt12.ReadOnly = true;
			this.txtTotaleMovEnt12.Size = new System.Drawing.Size(128, 20);
			this.txtTotaleMovEnt12.TabIndex = 10;
			this.txtTotaleMovEnt12.TabStop = false;
			this.txtTotaleMovEnt12.Tag = "ivapay.importocorrente";
			this.txtTotaleMovEnt12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "Entrate";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txtLiquidMese12);
			this.groupBox9.Controls.Add(this.label10);
			this.groupBox9.Controls.Add(this.lblcredito4_12);
			this.groupBox9.Controls.Add(this.lblcredito3_12);
			this.groupBox9.Controls.Add(this.txtNuovoSaldo12);
			this.groupBox9.Controls.Add(this.label27);
			this.groupBox9.Controls.Add(this.panel1);
			this.groupBox9.Controls.Add(this.label28);
			this.groupBox9.Controls.Add(this.label29);
			this.groupBox9.Controls.Add(this.lblcredito5_12);
			this.groupBox9.Controls.Add(this.lblcredito2_12);
			this.groupBox9.Controls.Add(this.lblcredito1_12);
			this.groupBox9.Controls.Add(this.txtIvaPeriodo12);
			this.groupBox9.Controls.Add(this.label33);
			this.groupBox9.Controls.Add(this.txtTotaleIva12);
			this.groupBox9.Controls.Add(this.label34);
			this.groupBox9.Controls.Add(this.txtSaldoPrec12);
			this.groupBox9.Controls.Add(this.label35);
			this.groupBox9.Location = new System.Drawing.Point(260, 43);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(378, 188);
			this.groupBox9.TabIndex = 8;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Saldo";
			// 
			// txtLiquidMese12
			// 
			this.txtLiquidMese12.Location = new System.Drawing.Point(133, 128);
			this.txtLiquidMese12.Name = "txtLiquidMese12";
			this.txtLiquidMese12.ReadOnly = true;
			this.txtLiquidMese12.Size = new System.Drawing.Size(96, 20);
			this.txtLiquidMese12.TabIndex = 48;
			this.txtLiquidMese12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(8, 131);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 13);
			this.label10.TabIndex = 47;
			this.label10.Text = "Liquidazione del mese";
			// 
			// lblcredito4_12
			// 
			this.lblcredito4_12.Location = new System.Drawing.Point(244, 131);
			this.lblcredito4_12.Name = "lblcredito4_12";
			this.lblcredito4_12.Size = new System.Drawing.Size(72, 16);
			this.lblcredito4_12.TabIndex = 46;
			// 
			// lblcredito3_12
			// 
			this.lblcredito3_12.Location = new System.Drawing.Point(244, 92);
			this.lblcredito3_12.Name = "lblcredito3_12";
			this.lblcredito3_12.Size = new System.Drawing.Size(72, 16);
			this.lblcredito3_12.TabIndex = 45;
			// 
			// txtNuovoSaldo12
			// 
			this.txtNuovoSaldo12.Location = new System.Drawing.Point(132, 156);
			this.txtNuovoSaldo12.Name = "txtNuovoSaldo12";
			this.txtNuovoSaldo12.ReadOnly = true;
			this.txtNuovoSaldo12.Size = new System.Drawing.Size(96, 20);
			this.txtNuovoSaldo12.TabIndex = 44;
			this.txtNuovoSaldo12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(17, 159);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(112, 16);
			this.label27.TabIndex = 43;
			this.label27.Text = "Nuovo saldo";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(20, 77);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 2);
			this.panel1.TabIndex = 42;
			// 
			// label28
			// 
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label28.Location = new System.Drawing.Point(324, 48);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(16, 16);
			this.label28.TabIndex = 41;
			this.label28.Text = "=";
			// 
			// label29
			// 
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label29.Location = new System.Drawing.Point(324, 27);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(16, 16);
			this.label29.TabIndex = 40;
			this.label29.Text = "+";
			// 
			// lblcredito5_12
			// 
			this.lblcredito5_12.Location = new System.Drawing.Point(244, 159);
			this.lblcredito5_12.Name = "lblcredito5_12";
			this.lblcredito5_12.Size = new System.Drawing.Size(72, 16);
			this.lblcredito5_12.TabIndex = 39;
			// 
			// lblcredito2_12
			// 
			this.lblcredito2_12.Location = new System.Drawing.Point(244, 50);
			this.lblcredito2_12.Name = "lblcredito2_12";
			this.lblcredito2_12.Size = new System.Drawing.Size(72, 16);
			this.lblcredito2_12.TabIndex = 38;
			// 
			// lblcredito1_12
			// 
			this.lblcredito1_12.Location = new System.Drawing.Point(244, 27);
			this.lblcredito1_12.Name = "lblcredito1_12";
			this.lblcredito1_12.Size = new System.Drawing.Size(72, 16);
			this.lblcredito1_12.TabIndex = 37;
			// 
			// txtIvaPeriodo12
			// 
			this.txtIvaPeriodo12.Location = new System.Drawing.Point(132, 50);
			this.txtIvaPeriodo12.Name = "txtIvaPeriodo12";
			this.txtIvaPeriodo12.ReadOnly = true;
			this.txtIvaPeriodo12.Size = new System.Drawing.Size(96, 20);
			this.txtIvaPeriodo12.TabIndex = 36;
			this.txtIvaPeriodo12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(20, 50);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(112, 16);
			this.label33.TabIndex = 35;
			this.label33.Text = "Iva del periodo";
			// 
			// txtTotaleIva12
			// 
			this.txtTotaleIva12.Location = new System.Drawing.Point(132, 87);
			this.txtTotaleIva12.Name = "txtTotaleIva12";
			this.txtTotaleIva12.ReadOnly = true;
			this.txtTotaleIva12.Size = new System.Drawing.Size(96, 20);
			this.txtTotaleIva12.TabIndex = 34;
			this.txtTotaleIva12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(17, 92);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(112, 16);
			this.label34.TabIndex = 33;
			this.label34.Text = "Totale iva";
			// 
			// txtSaldoPrec12
			// 
			this.txtSaldoPrec12.Location = new System.Drawing.Point(132, 26);
			this.txtSaldoPrec12.Name = "txtSaldoPrec12";
			this.txtSaldoPrec12.ReadOnly = true;
			this.txtSaldoPrec12.Size = new System.Drawing.Size(96, 20);
			this.txtSaldoPrec12.TabIndex = 32;
			this.txtSaldoPrec12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(21, 29);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(112, 16);
			this.label35.TabIndex = 31;
			this.label35.Text = "Saldo precedente";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.textBox17);
			this.groupBox10.Controls.Add(this.label38);
			this.groupBox10.Controls.Add(this.textBox19);
			this.groupBox10.Controls.Add(this.label40);
			this.groupBox10.Location = new System.Drawing.Point(20, 43);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(234, 80);
			this.groupBox10.TabIndex = 7;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Liquidazione corrente";
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(144, 48);
			this.textBox17.Name = "textBox17";
			this.textBox17.ReadOnly = true;
			this.textBox17.Size = new System.Drawing.Size(80, 20);
			this.textBox17.TabIndex = 2;
			this.textBox17.Tag = "ivapay.totaldebit12";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(8, 48);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(128, 16);
			this.label38.TabIndex = 11;
			this.label38.Text = "Totale iva a debito";
			this.label38.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBox19
			// 
			this.textBox19.Location = new System.Drawing.Point(144, 22);
			this.textBox19.Name = "textBox19";
			this.textBox19.ReadOnly = true;
			this.textBox19.Size = new System.Drawing.Size(80, 20);
			this.textBox19.TabIndex = 1;
			this.textBox19.Tag = "ivapay.totalcredit12";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(8, 24);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(128, 16);
			this.label40.TabIndex = 5;
			this.label40.Text = "Totale iva a credito";
			this.label40.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label24);
			this.tabPage2.Controls.Add(this.label23);
			this.tabPage2.Controls.Add(this.dataGrid2);
			this.tabPage2.Controls.Add(this.dataGrid1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(646, 523);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Iva per registro";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(8, 232);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(100, 16);
			this.label24.TabIndex = 3;
			this.label24.Text = "IVA a Credito:";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 8);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(100, 16);
			this.label23.TabIndex = 2;
			this.label23.Text = "IVA a Debito:";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 248);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(630, 271);
			this.dataGrid2.TabIndex = 1;
			this.dataGrid2.Tag = "ivapaydetailview.liquidazione_credito";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(630, 200);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "dettliquidazioneivaview_debito.liquidazione_debito";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label19);
			this.tabPage4.Controls.Add(this.label18);
			this.tabPage4.Controls.Add(this.dataGrid4);
			this.tabPage4.Controls.Add(this.dataGrid3);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(646, 523);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Movimenti";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 200);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(160, 16);
			this.label19.TabIndex = 3;
			this.label19.Text = "Movimenti di spesa collegati:";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(8, 8);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(232, 16);
			this.label18.TabIndex = 2;
			this.label18.Text = "Movimenti di entrata collegati:";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.CaptionVisible = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(8, 216);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(630, 295);
			this.dataGrid4.TabIndex = 1;
			this.dataGrid4.Tag = "ivapayexpenseview.liquidazioneiva";
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.CaptionVisible = false;
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(8, 24);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(630, 168);
			this.dataGrid3.TabIndex = 0;
			this.dataGrid3.Tag = "ivapayincomeview.liquidazioneiva";
			// 
			// tabFatture
			// 
			this.tabFatture.Controls.Add(this.tabControl2);
			this.tabFatture.Location = new System.Drawing.Point(4, 22);
			this.tabFatture.Name = "tabFatture";
			this.tabFatture.Size = new System.Drawing.Size(646, 523);
			this.tabFatture.TabIndex = 7;
			this.tabFatture.Text = "Fatture";
			this.tabFatture.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage6);
			this.tabControl2.Controls.Add(this.tabPage7);
			this.tabControl2.Controls.Add(this.tabPage8);
			this.tabControl2.Controls.Add(this.tabIntra12);
			this.tabControl2.Controls.Add(this.tabPage9);
			this.tabControl2.Location = new System.Drawing.Point(8, 21);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(620, 481);
			this.tabControl2.TabIndex = 16;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.label39);
			this.tabPage6.Controls.Add(this.lblMessaggi);
			this.tabPage6.Controls.Add(this.txtIvaVendita);
			this.tabPage6.Controls.Add(this.gridDebito);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(612, 455);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "Vendite";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// label39
			// 
			this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label39.Location = new System.Drawing.Point(9, 423);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(469, 16);
			this.label39.TabIndex = 4;
			this.label39.Text = "Totale IVA da fatture di vendita (esclusa IVA a debito per Inversione Contabile)";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblMessaggi
			// 
			this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessaggi.Location = new System.Drawing.Point(6, 15);
			this.lblMessaggi.Name = "lblMessaggi";
			this.lblMessaggi.Size = new System.Drawing.Size(418, 16);
			this.lblMessaggi.TabIndex = 0;
			this.lblMessaggi.Text = "Registri IVA vendite";
			// 
			// txtIvaVendita
			// 
			this.txtIvaVendita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIvaVendita.Location = new System.Drawing.Point(484, 419);
			this.txtIvaVendita.Name = "txtIvaVendita";
			this.txtIvaVendita.ReadOnly = true;
			this.txtIvaVendita.Size = new System.Drawing.Size(122, 20);
			this.txtIvaVendita.TabIndex = 13;
			this.txtIvaVendita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// gridDebito
			// 
			this.gridDebito.AllowNavigation = false;
			this.gridDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDebito.CaptionVisible = false;
			this.gridDebito.DataMember = "";
			this.gridDebito.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDebito.Location = new System.Drawing.Point(6, 31);
			this.gridDebito.Name = "gridDebito";
			this.gridDebito.Size = new System.Drawing.Size(600, 371);
			this.gridDebito.TabIndex = 1;
			this.gridDebito.Tag = "deferredview_fatture_vendita.fatture_vendita";
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.txtIvaAcquistiComm);
			this.tabPage7.Controls.Add(this.label60);
			this.tabPage7.Controls.Add(this.label51);
			this.tabPage7.Controls.Add(this.gridAcquisti);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(612, 455);
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "Acquisti commerciali";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// txtIvaAcquistiComm
			// 
			this.txtIvaAcquistiComm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIvaAcquistiComm.Location = new System.Drawing.Point(484, 419);
			this.txtIvaAcquistiComm.Name = "txtIvaAcquistiComm";
			this.txtIvaAcquistiComm.ReadOnly = true;
			this.txtIvaAcquistiComm.Size = new System.Drawing.Size(122, 20);
			this.txtIvaAcquistiComm.TabIndex = 11;
			this.txtIvaAcquistiComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label60
			// 
			this.label60.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label60.Location = new System.Drawing.Point(296, 422);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(182, 17);
			this.label60.TabIndex = 10;
			this.label60.Text = "Totale IVA";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label51
			// 
			this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label51.Location = new System.Drawing.Point(6, 15);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(225, 13);
			this.label51.TabIndex = 2;
			this.label51.Text = "Registri IVA acquisti commerciali";
			// 
			// gridAcquisti
			// 
			this.gridAcquisti.AllowNavigation = false;
			this.gridAcquisti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridAcquisti.CaptionVisible = false;
			this.gridAcquisti.DataMember = "";
			this.gridAcquisti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridAcquisti.Location = new System.Drawing.Point(6, 31);
			this.gridAcquisti.Name = "gridAcquisti";
			this.gridAcquisti.Size = new System.Drawing.Size(600, 371);
			this.gridAcquisti.TabIndex = 3;
			this.gridAcquisti.Tag = "deferredview_fatture_acquisti_comm.fatture_acquisti_comm";
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.txtIvaAcquistiProm);
			this.tabPage8.Controls.Add(this.labTotIvaPromPOST);
			this.tabPage8.Controls.Add(this.label61);
			this.tabPage8.Controls.Add(this.gridacquistipromiscui);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(612, 455);
			this.tabPage8.TabIndex = 2;
			this.tabPage8.Text = "Acquisti promiscui";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// txtIvaAcquistiProm
			// 
			this.txtIvaAcquistiProm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIvaAcquistiProm.Location = new System.Drawing.Point(484, 419);
			this.txtIvaAcquistiProm.Name = "txtIvaAcquistiProm";
			this.txtIvaAcquistiProm.ReadOnly = true;
			this.txtIvaAcquistiProm.Size = new System.Drawing.Size(122, 20);
			this.txtIvaAcquistiProm.TabIndex = 13;
			this.txtIvaAcquistiProm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labTotIvaPromPOST
			// 
			this.labTotIvaPromPOST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.labTotIvaPromPOST.Location = new System.Drawing.Point(364, 426);
			this.labTotIvaPromPOST.Name = "labTotIvaPromPOST";
			this.labTotIvaPromPOST.Size = new System.Drawing.Size(111, 13);
			this.labTotIvaPromPOST.TabIndex = 12;
			this.labTotIvaPromPOST.Text = "Totale IVA";
			this.labTotIvaPromPOST.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label61
			// 
			this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label61.Location = new System.Drawing.Point(6, 15);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(229, 13);
			this.label61.TabIndex = 18;
			this.label61.Text = "Registri IVA acquisti promiscui";
			// 
			// gridacquistipromiscui
			// 
			this.gridacquistipromiscui.AllowNavigation = false;
			this.gridacquistipromiscui.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridacquistipromiscui.CaptionVisible = false;
			this.gridacquistipromiscui.DataMember = "";
			this.gridacquistipromiscui.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridacquistipromiscui.Location = new System.Drawing.Point(9, 31);
			this.gridacquistipromiscui.Name = "gridacquistipromiscui";
			this.gridacquistipromiscui.Size = new System.Drawing.Size(600, 371);
			this.gridacquistipromiscui.TabIndex = 19;
			this.gridacquistipromiscui.Tag = "deferredview_fatture_acquisti_prom.fatture_acquisti_prom";
			// 
			// tabIntra12
			// 
			this.tabIntra12.Controls.Add(this.txtIvaIstituz);
			this.tabIntra12.Controls.Add(this.label74);
			this.tabIntra12.Controls.Add(this.label71);
			this.tabIntra12.Controls.Add(this.gridacquistiistituzionaliINTRA);
			this.tabIntra12.Location = new System.Drawing.Point(4, 22);
			this.tabIntra12.Name = "tabIntra12";
			this.tabIntra12.Padding = new System.Windows.Forms.Padding(3);
			this.tabIntra12.Size = new System.Drawing.Size(612, 455);
			this.tabIntra12.TabIndex = 3;
			this.tabIntra12.Text = "Acquisti Istituzionali INTRA e Extra-UE";
			this.tabIntra12.UseVisualStyleBackColor = true;
			// 
			// txtIvaIstituz
			// 
			this.txtIvaIstituz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIvaIstituz.Location = new System.Drawing.Point(484, 419);
			this.txtIvaIstituz.Name = "txtIvaIstituz";
			this.txtIvaIstituz.ReadOnly = true;
			this.txtIvaIstituz.Size = new System.Drawing.Size(122, 20);
			this.txtIvaIstituz.TabIndex = 13;
			this.txtIvaIstituz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label74
			// 
			this.label74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label74.Location = new System.Drawing.Point(304, 422);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(174, 17);
			this.label74.TabIndex = 12;
			this.label74.Text = "Totale IVA";
			this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label71
			// 
			this.label71.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label71.Location = new System.Drawing.Point(6, 15);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(307, 13);
			this.label71.TabIndex = 18;
			this.label71.Text = "Registri IVA acquisti istituzionali";
			// 
			// gridacquistiistituzionaliINTRA
			// 
			this.gridacquistiistituzionaliINTRA.AllowNavigation = false;
			this.gridacquistiistituzionaliINTRA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridacquistiistituzionaliINTRA.CaptionVisible = false;
			this.gridacquistiistituzionaliINTRA.DataMember = "";
			this.gridacquistiistituzionaliINTRA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridacquistiistituzionaliINTRA.Location = new System.Drawing.Point(6, 31);
			this.gridacquistiistituzionaliINTRA.Name = "gridacquistiistituzionaliINTRA";
			this.gridacquistiistituzionaliINTRA.Size = new System.Drawing.Size(600, 371);
			this.gridacquistiistituzionaliINTRA.TabIndex = 19;
			this.gridacquistiistituzionaliINTRA.Tag = "deferredview_fatture_acquisti_ist_intraextra.fatture_acquisti_ist_intraextra";
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.txtIvaIstituzSplit);
			this.tabPage9.Controls.Add(this.label81);
			this.tabPage9.Controls.Add(this.label78);
			this.tabPage9.Controls.Add(this.gridacquistiistituzionaliSplit);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(612, 455);
			this.tabPage9.TabIndex = 4;
			this.tabPage9.Text = "Acquisti istituzionali Split Payment";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// txtIvaIstituzSplit
			// 
			this.txtIvaIstituzSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIvaIstituzSplit.Location = new System.Drawing.Point(484, 419);
			this.txtIvaIstituzSplit.Name = "txtIvaIstituzSplit";
			this.txtIvaIstituzSplit.ReadOnly = true;
			this.txtIvaIstituzSplit.Size = new System.Drawing.Size(122, 20);
			this.txtIvaIstituzSplit.TabIndex = 13;
			this.txtIvaIstituzSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label81
			// 
			this.label81.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label81.Location = new System.Drawing.Point(304, 423);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(174, 16);
			this.label81.TabIndex = 12;
			this.label81.Text = "Totale IVA";
			this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label78
			// 
			this.label78.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label78.Location = new System.Drawing.Point(6, 15);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(277, 13);
			this.label78.TabIndex = 23;
			this.label78.Text = "Registri IVA acquisti istituzionali";
			// 
			// gridacquistiistituzionaliSplit
			// 
			this.gridacquistiistituzionaliSplit.AllowNavigation = false;
			this.gridacquistiistituzionaliSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridacquistiistituzionaliSplit.CaptionVisible = false;
			this.gridacquistiistituzionaliSplit.DataMember = "";
			this.gridacquistiistituzionaliSplit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridacquistiistituzionaliSplit.Location = new System.Drawing.Point(6, 31);
			this.gridacquistiistituzionaliSplit.Name = "gridacquistiistituzionaliSplit";
			this.gridacquistiistituzionaliSplit.Size = new System.Drawing.Size(600, 371);
			this.gridacquistiistituzionaliSplit.TabIndex = 24;
			this.gridacquistiistituzionaliSplit.Tag = "deferredview_fatture_acquisti_ist_split.fatture_acquisti_ist_split";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(646, 523);
			this.tabEP.TabIndex = 4;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(395, 18);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(216, 24);
			this.btnGeneraEP.TabIndex = 3;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(16, 24);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(272, 24);
			this.labEP.TabIndex = 1;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(395, 58);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(216, 24);
			this.btnVisualizzaEP.TabIndex = 0;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.grpMetodoAcconto);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(646, 523);
			this.tabPage3.TabIndex = 8;
			this.tabPage3.Text = "Acconto";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// grpMetodoAcconto
			// 
			this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto4);
			this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto1);
			this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto3);
			this.grpMetodoAcconto.Controls.Add(this.rdbMetodoAcconto2);
			this.grpMetodoAcconto.Location = new System.Drawing.Point(8, 22);
			this.grpMetodoAcconto.Name = "grpMetodoAcconto";
			this.grpMetodoAcconto.Size = new System.Drawing.Size(620, 111);
			this.grpMetodoAcconto.TabIndex = 13;
			this.grpMetodoAcconto.TabStop = false;
			this.grpMetodoAcconto.Text = "Metodo usato per calcolare l\'Acconto";
			// 
			// rdbMetodoAcconto4
			// 
			this.rdbMetodoAcconto4.AutoSize = true;
			this.rdbMetodoAcconto4.Location = new System.Drawing.Point(15, 83);
			this.rdbMetodoAcconto4.Name = "rdbMetodoAcconto4";
			this.rdbMetodoAcconto4.Size = new System.Drawing.Size(412, 17);
			this.rdbMetodoAcconto4.TabIndex = 35;
			this.rdbMetodoAcconto4.TabStop = true;
			this.rdbMetodoAcconto4.Tag = "ivapay.advancecomputemethod:4";
			this.rdbMetodoAcconto4.Text = "4 - Soggetti operanti nei settori delle telecomunicazioni,  energia elettrica, ec" +
    "cetera";
			this.rdbMetodoAcconto4.UseVisualStyleBackColor = true;
			// 
			// rdbMetodoAcconto1
			// 
			this.rdbMetodoAcconto1.AutoSize = true;
			this.rdbMetodoAcconto1.Location = new System.Drawing.Point(15, 19);
			this.rdbMetodoAcconto1.Name = "rdbMetodoAcconto1";
			this.rdbMetodoAcconto1.Size = new System.Drawing.Size(110, 17);
			this.rdbMetodoAcconto1.TabIndex = 34;
			this.rdbMetodoAcconto1.TabStop = true;
			this.rdbMetodoAcconto1.Tag = "ivapay.advancecomputemethod:1";
			this.rdbMetodoAcconto1.Text = "1 - Metodo storico";
			this.rdbMetodoAcconto1.UseVisualStyleBackColor = true;
			// 
			// rdbMetodoAcconto3
			// 
			this.rdbMetodoAcconto3.AutoSize = true;
			this.rdbMetodoAcconto3.Location = new System.Drawing.Point(15, 60);
			this.rdbMetodoAcconto3.Name = "rdbMetodoAcconto3";
			this.rdbMetodoAcconto3.Size = new System.Drawing.Size(159, 17);
			this.rdbMetodoAcconto3.TabIndex = 33;
			this.rdbMetodoAcconto3.TabStop = true;
			this.rdbMetodoAcconto3.Tag = "ivapay.advancecomputemethod:3";
			this.rdbMetodoAcconto3.Text = "3 - Metodo analitico effettivo";
			this.rdbMetodoAcconto3.UseVisualStyleBackColor = true;
			// 
			// rdbMetodoAcconto2
			// 
			this.rdbMetodoAcconto2.AutoSize = true;
			this.rdbMetodoAcconto2.Location = new System.Drawing.Point(15, 39);
			this.rdbMetodoAcconto2.Name = "rdbMetodoAcconto2";
			this.rdbMetodoAcconto2.Size = new System.Drawing.Size(135, 17);
			this.rdbMetodoAcconto2.TabIndex = 32;
			this.rdbMetodoAcconto2.TabStop = true;
			this.rdbMetodoAcconto2.Tag = "ivapay.advancecomputemethod:2";
			this.rdbMetodoAcconto2.Text = "2 - Metodo previsionale";
			this.rdbMetodoAcconto2.UseVisualStyleBackColor = true;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_ivapay_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(654, 549);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_ivapay_default";
			this.Text = "frmliquidazioneiva";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gboxmanuale.ResumeLayout(false);
			this.gboxmanuale.PerformLayout();
			this.gboxmovimenti.ResumeLayout(false);
			this.gboxmovimenti.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabSplitPayment.ResumeLayout(false);
			this.tabSplitPayment.PerformLayout();
			this.gboxmanualeSplit.ResumeLayout(false);
			this.gboxmanualeSplit.PerformLayout();
			this.gboxmovimentiSplit.ResumeLayout(false);
			this.gboxmovimentiSplit.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.tabPgINTRA.ResumeLayout(false);
			this.tabPgINTRA.PerformLayout();
			this.gboxmanuale12.ResumeLayout(false);
			this.gboxmanuale12.PerformLayout();
			this.gboxmovimenti12.ResumeLayout(false);
			this.gboxmovimenti12.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabFatture.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDebito)).EndInit();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAcquisti)).EndInit();
			this.tabPage8.ResumeLayout(false);
			this.tabPage8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistipromiscui)).EndInit();
			this.tabIntra12.ResumeLayout(false);
			this.tabIntra12.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliINTRA)).EndInit();
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliSplit)).EndInit();
			this.tabEP.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.grpMetodoAcconto.ResumeLayout(false);
			this.grpMetodoAcconto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			GetData.CacheTable(DS.config, 
                QHS.CmpEq("ayear",Meta.GetSys("esercizio")),
                null, false);
            GetData.SetStaticFilter(DS.ivapayexpenseview, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            GetData.SetStaticFilter(DS.ivapayincomeview, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
		    epm = new EP_Manager(Meta, null, null, null, null, btnGeneraEP, btnVisualizzaEP, labEP, null, "ivapay");
		}

        decimal startivabalance;
        decimal startivabalance12;
        decimal startivabalancesplit;
        public void MetaData_AfterActivation() {
            DataRow CfgRow = DS.config.Rows[0];

            startivabalance = CfgFn.GetNoNullDecimal(CfgRow["startivabalance"]);
            startivabalance12 = CfgFn.GetNoNullDecimal(CfgRow["startivabalance12"]);
            startivabalancesplit = CfgFn.GetNoNullDecimal(CfgRow["startivabalancesplit"]);

            if (MovimentiFinanziariConfigurati()) {
                gboxmanuale.Visible = false;
            }
            else {
                gboxmovimenti.Visible = false;
            }

            if (MovimentiFinanziariConfigurati12()) {
                gboxmanuale12.Visible = false;
            }
            else {
                gboxmovimenti12.Visible = false;
            }
            if (MovimentiFinanziariConfiguratiSplit()) {
                gboxmanualeSplit.Visible = false;
            }
            else {
                gboxmovimentiSplit.Visible = false;
            }
        }

		public void MetaData_AfterClear() {
		    epm.mostraEtichette();
			DisabilitaCampi(false);
			SvuotaCampi();
			txtEsercizio.Text=Meta.GetSys("esercizio").ToString();
            VisualizzaRiepilogo();
            PostData.MarkAsRealTable(DS.deferredview_fatture_vendita);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_comm);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_prom);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_intraextra);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_split);
		}


		public void MetaData_BeforeFill() {
			if (Meta.FirstFillForThisRow) {
                calcolaIVACredito();
                calcolaIVACreditoIstituzionale();
                }		
		}

		public void MetaData_AfterFill() {
            epm.mostraEtichette();
            DisabilitaCampi(true);
			CalcolaTotali();
            VisualizzaRiepilogo();
            ValorizzaTotaleIVAGridFatture();
            PostData.MarkAsRealTable(DS.deferredview_fatture_vendita);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_comm);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_prom);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_intraextra);
            PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_split);
		}

        void ValorizzaTotaleIVAGridFatture() {
            if (Meta.IsEmpty)
                return;
            /* registerclass = V 
             * AND
             * ( flagactivity =1 and flag_enable_split_payment=S 
             * OR flagactivity=1 and flagintracom<>N 
             * OR flagactivity=2 and flag_enable_split_payment= N
             * OR flagactivity = 3 and flag_enable_split_payment=N
             * )
            */
            string filterIvaVendita = QHC.AppAnd(QHC.CmpEq("registerclass", "V"),
                QHC.DoPar(QHC.AppOr(
                                            QHC.AppAnd(QHC.CmpEq("flagactivity", "1"), QHC.CmpEq("flag_enable_split_payment", "S")),
                                            QHC.AppAnd(QHC.CmpEq("flagactivity", "1"), QHC.CmpNe("flagintracom", "N")),
                                            QHC.AppAnd(QHC.CmpEq("flagactivity", "2"), QHC.CmpEq("flag_enable_split_payment", "N")),
                                            QHC.AppAnd(QHC.CmpEq("flagactivity", "3"), QHC.CmpEq("flag_enable_split_payment", "N"))
                                    )));
            decimal IvaLiquidata = 0;
            foreach (DataRow rDettaglio in DS.deferredview_fatture_vendita.Select(filterIvaVendita)) {
                IvaLiquidata = IvaLiquidata + CfgFn.GetNoNullDecimal(rDettaglio["ivatotalpayed"]);
            }
            txtIvaVendita.Text = IvaLiquidata.ToString("c");

            // Acquisto e Commerciale
            string filterIvaAcquistiComm = QHC.AppAnd(QHC.CmpEq("registerclass", "A"), QHC.CmpEq("flagactivity", "2"));
            IvaLiquidata = 0;
            foreach (DataRow rDettaglio in DS.deferredview_fatture_acquisti_comm.Select(filterIvaAcquistiComm)) {
                IvaLiquidata = IvaLiquidata + CfgFn.GetNoNullDecimal(rDettaglio["ivatotalpayed"]);
            }
            txtIvaAcquistiComm.Text = IvaLiquidata.ToString("c");

            // Acquisto e Promiscuo
            string filterIvaAcquistiProm = QHC.AppAnd(QHC.CmpEq("registerclass", "A"), QHC.CmpEq("flagactivity", "3"));
            IvaLiquidata = 0;
            foreach (DataRow rDettaglio in DS.deferredview_fatture_acquisti_prom.Select(filterIvaAcquistiProm)) {
                IvaLiquidata = IvaLiquidata + CfgFn.GetNoNullDecimal(rDettaglio["ivatotalpayed"]);
            }
            txtIvaAcquistiProm.Text = IvaLiquidata.ToString("c");

            // Acquisto e Istituzionale e Intracom, e non Spli perchè li prendo dopo
            string filterIvaIntra = QHC.AppAnd(QHC.CmpEq("registerclass", "A"), QHC.CmpEq("flagactivity", "1"), QHC.CmpNe("flagintracom", "N"), QHC.CmpEq("flag_enable_split_payment", "N"));
            IvaLiquidata = 0;
            foreach (DataRow rDettaglio in DS.deferredview_fatture_acquisti_ist_intraextra.Select(filterIvaIntra)) {
                IvaLiquidata = IvaLiquidata + CfgFn.GetNoNullDecimal(rDettaglio["ivatotalpayed"]);
            }
            txtIvaIstituz.Text = IvaLiquidata.ToString("c");

            // Acquisto Istituzionale e soggetta a Split , e non intracom perchè li ho presi prima
            string filterIvaIstplit = QHC.AppAnd(QHC.CmpEq("registerclass", "A"), QHC.CmpEq("flagactivity", "1"), QHC.CmpEq("flagintracom", "N"), QHC.CmpEq("flag_enable_split_payment", "S"));
            IvaLiquidata = 0;
            foreach (DataRow rDettaglio in DS.deferredview_fatture_acquisti_ist_split.Select(filterIvaIstplit)) {
                IvaLiquidata = IvaLiquidata + CfgFn.GetNoNullDecimal(rDettaglio["ivatotalpayed"]);
            }
            txtIvaIstituzSplit.Text = IvaLiquidata.ToString("c");
 

        }


        void VisualizzaRiepilogo(){
  			if (DS.ivapay.Rows.Count==0 || DS.config.Rows.Count==0) {
                btnRiepilogo.Enabled = false;
                return;
            }

            DataRow CfgRow = DS.config.Rows[0];
            if (CfgRow["flagivapaybyrow"].ToString().ToUpper() == "S"){
                btnRiepilogo.Visible = true;
            }
            else {
                btnRiepilogo.Visible = false;
            }
            
            btnRiepilogo.Enabled = (!Meta.IsEmpty);
            return;

        }

		private void calcolaIVACredito() {
            object idivaregisterkind;
            object flagactivity;
            // Elabora i registri NON Istituzionali
			foreach(DataRow rDettaglio in DS.ivapaydetailview.Select(QHC.CmpEq("registerclass","A"))) {
                idivaregisterkind = rDettaglio["idivaregisterkind"];
                flagactivity = Meta.Conn.DO_READ_VALUE("ivaregisterkind", QHS.CmpEq("idivaregisterkind", idivaregisterkind), "flagactivity");
                if (flagactivity.ToString() == "1") continue;

				decimal ivaNetta = CfgFn.GetNoNullDecimal(rDettaglio["ivanet"]);
				decimal ivaNettaDiff = CfgFn.GetNoNullDecimal(rDettaglio["ivanetdeferred"]);
				rDettaglio["!ivacredit"] = ivaNetta + ivaNettaDiff;
			}
		}

        private void calcolaIVACreditoIstituzionale(){
            object idivaregisterkind;
            object flagactivity;
            // Elabora i registri Istituzionali
            foreach (DataRow rDettaglio in DS.ivapaydetailview.Select(QHC.CmpEq("registerclass", "A"))){
                idivaregisterkind = rDettaglio["idivaregisterkind"];
                flagactivity = Meta.Conn.DO_READ_VALUE("ivaregisterkind", QHS.CmpEq("idivaregisterkind", idivaregisterkind), "flagactivity");
                if (flagactivity.ToString() != "1") continue;
                decimal ivaNetta = CfgFn.GetNoNullDecimal(rDettaglio["iva"]);
                decimal ivaNettaDiff = CfgFn.GetNoNullDecimal(rDettaglio["ivadeferred"]);
                rDettaglio["!ivacredit"] = ivaNetta + ivaNettaDiff;
            }
        }


		string idrelated = "";
		bool fromDelete = false;
		public void MetaData_BeforePost() {
		    epm.beforePost();
			fromDelete = false;
			DS.dettliquidazioneivaview_debito.AcceptChanges();
			if (DS.ivapay.Rows[0].RowState == DataRowState.Deleted){
				idrelated = EP_functions.GetIdForDocument(DS.ivapay.Rows[0]);
                PostData.MarkAsTemporaryTable(DS.deferredview_fatture_vendita,false);
                PostData.MarkAsTemporaryTable(DS.deferredview_fatture_acquisti_comm,false);
                PostData.MarkAsTemporaryTable(DS.deferredview_fatture_acquisti_prom, false);
                PostData.MarkAsTemporaryTable(DS.deferredview_fatture_acquisti_ist_intraextra, false);
                PostData.MarkAsTemporaryTable(DS.deferredview_fatture_acquisti_ist_split, false);
				fromDelete = true;
			}
		}

        bool MovimentiFinanziariConfigurati() {
            DataRow rConfIVA = DS.config.Rows[0];
            if (rConfIVA["flagpayment"].ToString().ToUpper() == "S") return true;
            if (rConfIVA["flagrefund"].ToString().ToUpper() == "S") return true;
            return false;
        }

        bool MovimentiFinanziariConfigurati12()
        {
            DataRow rConfIVA = DS.config.Rows[0];
            if (rConfIVA["flagpayment12"].ToString().ToUpper() == "S") return true;
            if (rConfIVA["flagrefund12"].ToString().ToUpper() == "S") return true;
            return false;
        }
        bool MovimentiFinanziariConfiguratiSplit() {

            DataRow rConfIVA = DS.config.Rows[0];
            if (rConfIVA["flagpaymentsplit"].ToString().ToUpper() == "S") return true;
            return false;
        }


		public void MetaData_AfterPost() {
		   
			if (fromDelete)
			{
                PostData.MarkAsRealTable(DS.deferredview_fatture_vendita);
                PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_comm);
                PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_prom);
                PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_intraextra);
                PostData.MarkAsRealTable(DS.deferredview_fatture_acquisti_ist_split);
                DS.deferredview_fatture_vendita.Clear();
                DS.deferredview_fatture_acquisti_comm.Clear();
                DS.deferredview_fatture_acquisti_prom.Clear();
                DS.deferredview_fatture_acquisti_ist_intraextra.Clear();
                DS.deferredview_fatture_acquisti_ist_split.Clear();
                epm.afterPost();
				fromDelete = false;
			}
		}
	

		private void DisabilitaCampi(bool disable) {
			rdoPeriodica.Enabled=!disable;
			rdoAcconto.Enabled=!disable;
            chkCommerciale.Enabled = !disable;
            chkIstituzionale.Enabled = !disable;
            chkSplit.Enabled = !disable;
            txtF24ep.ReadOnly = disable;

        }

		private void SvuotaCampi() {
            txtSaldoPrec.Text = "";
            txtSaldoPrec12 .Text = "";
            txtSaldoPrecSplit.Text = "";

            lblcredito1.Text = "";
            lblcredito1_12.Text = "";

            txtIvaPeriodo.Text = "";
            txtIvaPeriodo12.Text = "";
            txtIvaPeriodoSplit.Text = "";

            lblcredito2.Text = "";
            lblcredito2_split.Text = "";

            txtTotaleIva.Text  = "";
            txtTotaleIva12.Text = "";
            txtTotaleIvaSplit.Text = "";

            labCredito3.Text = "";
            lblcredito3_12.Text = "";
            lblcredito3_split.Text = "";

            txtLiquidMese.Text = "";
            txtLiquidMese12.Text = "";
            txtLiquidMeseSplit.Text = "";

            labCredito3.Text = "";
            labCredito3.Text = "";

            lblcredito4_12.Text = "";
            lblcredito4_split.Text = "";

            txtNuovoSaldo.Text = "";
            txtNuovoSaldo12.Text = "";
            txtNuovoSaldoSplit.Text = "";

            lblcredito5_12.Text = "";
            lblcredito5_split.Text = "";
            // Text Grid Fatture
            txtIvaVendita.Text = "";
            txtIvaAcquistiComm.Text = "";
            txtIvaAcquistiProm.Text = "";
            txtIvaIstituz.Text = "";
            txtIvaIstituzSplit.Text = "";
		}
        private bool CiSonoInserimentiManuali() {
            object esercizio = Meta.GetSys("esercizio");
            int n_man = Conn.RUN_SELECT_COUNT("ivapay",
                    QHS.AppAnd(QHS.CmpEq("yivapay", esercizio),
                                    QHS.DoPar(QHS.AppOr(
                                            QHS.Not(QHS.NullOrEq("paymentamount", 0)),
                                            QHS.Not(QHS.NullOrEq("refundamount", 0))
                                    ))
                            ), false);
            return (n_man == 0);
        }
        private bool CiSonoInserimentiManuali12() {
            object esercizio = Meta.GetSys("esercizio");
            int n_man = Conn.RUN_SELECT_COUNT("ivapay",
                    QHS.AppAnd(QHS.CmpEq("yivapay", esercizio),
                                    QHS.DoPar(QHS.AppOr(
                                            QHS.Not(QHS.NullOrEq("paymentamount12", 0)),
                                            QHS.Not(QHS.NullOrEq("refundamount12", 0))
                                    ))
                            ), false);
            return (n_man == 0);
        }
        private bool CiSonoInserimentiManualiSplit() {
            object esercizio = Meta.GetSys("esercizio");
            int n_man = Conn.RUN_SELECT_COUNT("ivapay",
                    QHS.AppAnd(QHS.CmpEq("yivapay", esercizio),
                                    QHS.Not(QHS.NullOrEq("paymentamountsplit", 0))                                    
                            ), false);
            return (n_man == 0);
        }

		private decimal GetSaldoPrecedente() {
			DataRow R = DS.ivapay.Rows[0];
            if (R["prev_debit"] != DBNull.Value) return CfgFn.GetNoNullDecimal(R["prev_debit"]);

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamount) AS paymentamount, "
                + "SUM(refundamount) AS refundamount, "
                + "SUM(totaldebit) AS totaldebit, "
                + "SUM(totalcredit) AS totalcredit "
                + "FROM ivapay ";
            string filter = " WHERE " + QHS.AppAnd(
                QHS.CmpEq("yivapay", R["yivapay"]), QHS.CmpLt("nivapay", R["nivapay"]));
            DataTable T = Conn.SQLRunner(sql + filter, false);

            decimal saldo_precedente = -startivabalance;
            if (T != null && T.Rows.Count > 0) {
                DataRow RR = T.Rows[0];
                saldo_precedente = saldo_precedente
                                   + CfgFn.GetNoNullDecimal(RR["totaldebit"])
                                   - CfgFn.GetNoNullDecimal(RR["paymentamount"])

                                   - CfgFn.GetNoNullDecimal(RR["totalcredit"])
                                   + CfgFn.GetNoNullDecimal(RR["refundamount"]);
            }
            return saldo_precedente;
		}

        private decimal GetSaldoPrecedente12(){
            DataRow R = DS.ivapay.Rows[0];
            if (R["prev_debit12"] != DBNull.Value) return CfgFn.GetNoNullDecimal(R["prev_debit12"]);

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamount12) as paymentamount12,"
                + " SUM(refundamount12) as refundamount12, "
                + " SUM(totaldebit12) as totaldebit12,"
                + " SUM(totalcredit12) as totalcredit12 "
                + "FROM ivapay ";
            string filter = " WHERE " + QHS.AppAnd(
                QHS.CmpEq("yivapay", R["yivapay"]), QHS.CmpLt("nivapay", R["nivapay"]));
            DataTable T = Conn.SQLRunner(sql + filter, false);

            decimal saldo_precedente12 = -startivabalance12;
            if (T != null && T.Rows.Count > 0){
                DataRow RR = T.Rows[0];
                saldo_precedente12 = saldo_precedente12
                                   + CfgFn.GetNoNullDecimal(RR["totaldebit12"])
                                   - CfgFn.GetNoNullDecimal(RR["paymentamount12"])

                                   - CfgFn.GetNoNullDecimal(RR["totalcredit12"])
                                   + CfgFn.GetNoNullDecimal(RR["refundamount12"]);
            }
            return saldo_precedente12;
        }
        
        private decimal GetSaldoPrecedenteSplit() {
            DataRow R = DS.ivapay.Rows[0];
            if (R["prev_debitsplit"] != DBNull.Value)
                return CfgFn.GetNoNullDecimal(R["prev_debitsplit"]);

            object esercizio = Meta.GetSys("esercizio");

            string sql = "SELECT SUM(paymentamountsplit) as paymentamountsplit,"
                + " SUM(totaldebitsplit) as totaldebitsplit "
                + "FROM ivapay ";
            string filter = " WHERE " + QHS.AppAnd(
                QHS.CmpEq("yivapay", R["yivapay"]), QHS.CmpLt("nivapay", R["nivapay"]));
            DataTable T = Conn.SQLRunner(sql + filter, false);

            decimal saldo_precedentesplit = -startivabalancesplit;
            if (T != null && T.Rows.Count > 0) {
                DataRow RR = T.Rows[0];
                saldo_precedentesplit = saldo_precedentesplit
                                   + CfgFn.GetNoNullDecimal(RR["totaldebitsplit"])
                                   - CfgFn.GetNoNullDecimal(RR["paymentamountsplit"]);
            }
            return saldo_precedentesplit;
        }
        private void ImpostaLabel(decimal importo, Label lbl) {
            if (importo > 0)
                lbl.Text = "a debito";
            else {
                if (importo < 0)
                    lbl.Text = "a credito";
                else
                    lbl.Text = "";
            }
        }


        private void CalcolaTotali() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.ivapay.Rows[0];

            decimal ivadelperiodo = CfgFn.GetNoNullDecimal(Curr["totaldebit"])
                                    - CfgFn.GetNoNullDecimal(Curr["totalcredit"]);
            txtIvaPeriodo.Text = Math.Abs(ivadelperiodo).ToString("c");
            ImpostaLabel(ivadelperiodo, lblcredito2);

            decimal ivadelperiodo12 = CfgFn.GetNoNullDecimal(Curr["totaldebit12"])
                                    - CfgFn.GetNoNullDecimal(Curr["totalcredit12"]);
            txtIvaPeriodo12.Text = Math.Abs(ivadelperiodo12).ToString("c");
            ImpostaLabel(ivadelperiodo12, lblcredito2_12);

            decimal ivadelperiodosplit = CfgFn.GetNoNullDecimal(Curr["totaldebitsplit"]);
            txtIvaPeriodoSplit.Text = Math.Abs(ivadelperiodosplit).ToString("c");
            ImpostaLabel(ivadelperiodosplit, lblcredito2_split);


            bool movfinanziariConfig = false;
            if (!MovimentiFinanziariConfigurati()){
                movfinanziariConfig = false;
            }
            else{
                movfinanziariConfig = true;
            }

            bool movfinanziariConfig12 = false;
            if (!MovimentiFinanziariConfigurati12()){
                movfinanziariConfig12 = false;
            }
            else{
                movfinanziariConfig12 = true;
            }

            bool movfinanziariConfigSplit = false;
            if (!MovimentiFinanziariConfiguratiSplit()) {
                movfinanziariConfigSplit = false;
            }
            else {
                movfinanziariConfigSplit = true;
            }

            
            decimal liquidazionecorrente = CfgFn.GetNoNullDecimal(Curr["paymentamount"]) - CfgFn.GetNoNullDecimal(Curr["refundamount"]);
            txtLiquidMese.Text = Math.Abs(liquidazionecorrente).ToString("c");
            if (movfinanziariConfig)
                ImpostaLabel(liquidazionecorrente, labCredito4);

            decimal liquidazionecorrente12 = CfgFn.GetNoNullDecimal(Curr["paymentamount12"]) - CfgFn.GetNoNullDecimal(Curr["refundamount12"]);
            txtLiquidMese12.Text = Math.Abs(liquidazionecorrente12).ToString("c");
            if (movfinanziariConfig12)
                ImpostaLabel(liquidazionecorrente12, lblcredito4_12);

            decimal liquidazionecorrenteSplit = CfgFn.GetNoNullDecimal(Curr["paymentamountsplit"]);
            txtLiquidMeseSplit.Text = Math.Abs(liquidazionecorrenteSplit).ToString("c");
            if (movfinanziariConfigSplit)
                ImpostaLabel(liquidazionecorrenteSplit, lblcredito4_split);


            decimal saldo_precedente = GetSaldoPrecedente();
            decimal saldo_precedente12 = GetSaldoPrecedente12();
            decimal saldo_precedentesplit = GetSaldoPrecedenteSplit();

            decimal totaleiva = saldo_precedente + ivadelperiodo;
            decimal totaleiva12 = saldo_precedente12 + ivadelperiodo12;
            decimal totaleivasplit = saldo_precedentesplit + ivadelperiodosplit;

            decimal nuovosaldo = totaleiva - liquidazionecorrente;
            decimal nuovosaldo12 = totaleiva12 - liquidazionecorrente12;
            decimal nuovosaldosplit = totaleivasplit - liquidazionecorrenteSplit;

            if (movfinanziariConfig || CiSonoInserimentiManuali()){
                txtSaldoPrec.Text = Math.Abs(saldo_precedente).ToString("c");
                ImpostaLabel(saldo_precedente, lblcredito1);
                txtTotaleIva.Text = Math.Abs(totaleiva).ToString("c");
                ImpostaLabel(totaleiva, labCredito3);
                txtNuovoSaldo.Text = Math.Abs(nuovosaldo).ToString("c");
                ImpostaLabel(nuovosaldo, lblcredito5);
            }
            if (movfinanziariConfig12 || CiSonoInserimentiManuali12()){
                txtSaldoPrec12.Text = Math.Abs(saldo_precedente12).ToString("c");
                ImpostaLabel(saldo_precedente12, lblcredito1_12);
                txtTotaleIva12.Text = Math.Abs(totaleiva12).ToString("c");
                ImpostaLabel(totaleiva12, lblcredito3_12);
                txtNuovoSaldo12.Text = Math.Abs(nuovosaldo12).ToString("c");
                ImpostaLabel(nuovosaldo12, lblcredito5_12);
            }
            if (movfinanziariConfigSplit || CiSonoInserimentiManualiSplit()) {
                txtSaldoPrecSplit.Text = Math.Abs(saldo_precedentesplit).ToString("c");
                ImpostaLabel(saldo_precedente12, lblcredito1_split);
                txtTotaleIvaSplit.Text = Math.Abs(totaleivasplit).ToString("c");
                ImpostaLabel(totaleivasplit, lblcredito3_split);
                txtNuovoSaldoSplit.Text = Math.Abs(nuovosaldosplit).ToString("c");
                ImpostaLabel(nuovosaldosplit, lblcredito5_split);
            }


            decimal totalemovent = 0, totalemovent12 = 0;
            decimal totalemovspe = 0, totalemovspe12 = 0, totalemovspeSplit=0;
            object fasespesamax = Meta.GetSys("maxexpensephase");
            string filterspesamax = QHS.CmpEq("nphase", fasespesamax);

            object faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            string filterentratamax = QHS.CmpEq("nphase", faseentratamax);

            string filter =  QHS.AppAnd(
                        QHS.CmpEq("yivapay", DS.ivapay.Rows[0]["yivapay"]),
                        QHS.CmpEq("nivapay", DS.ivapay.Rows[0]["nivapay"])) + " ";
            //  12	-	Liquidazione IVA
            //  17	-	Liquidazione IVA intrastat istituzionale
            string filterAutokind = QHS.CmpEq("autokind", "12");
            string filterAutokind12 = QHS.CmpEq("autokind", "17");
            string filterAutokindSplit = QHS.CmpEq("autokind", "23");

            string filterMov = GetData.MergeFilters(filter, filterAutokind);
            string cmd = "select sum(amount) from ivapayincomeview WHERE " + filterMov +
                " group by yivapay,nivapay,nphase " +
                "having " + filterentratamax;
            DataTable T = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T != null && T.Rows.Count > 0) totalemovent = CfgFn.GetNoNullDecimal(T.Rows[0][0]);

            cmd = "select sum(amount) from ivapayexpenseview WHERE " + filterMov +
                "group by yivapay,nivapay,nphase " +
                "having " + filterspesamax;
            T = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T != null && T.Rows.Count > 0) totalemovspe = CfgFn.GetNoNullDecimal(T.Rows[0][0]);


            // INTRA 
            string filterMov12 = GetData.MergeFilters(filter, filterAutokind12);
            cmd = "select sum(amount) from ivapayincomeview WHERE " + filterMov12 +
                " group by yivapay,nivapay,nphase " +
                "having " + filterentratamax;
            DataTable T12 = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T12 != null && T12.Rows.Count > 0) totalemovent12 = CfgFn.GetNoNullDecimal(T12.Rows[0][0]);

            cmd = "select sum(amount) from ivapayexpenseview WHERE " + filterMov12 +
                "group by yivapay,nivapay,nphase " +
                "having " + filterspesamax;
            T12 = Meta.Conn.SQLRunner(cmd, true, -1);
            if (T12!= null && T12.Rows.Count > 0) totalemovspe12 = CfgFn.GetNoNullDecimal(T12.Rows[0][0]);



            // SPLIT 
            string filterMovSplit = GetData.MergeFilters(filter, filterAutokindSplit);            
            cmd = "select sum(amount) from ivapayexpenseview WHERE " + filterMovSplit+
                "group by yivapay,nivapay,nphase " +
                "having " + filterspesamax;
            DataTable TSplit = Meta.Conn.SQLRunner(cmd, true, -1);
            if (TSplit != null && TSplit.Rows.Count > 0)
                totalemovspeSplit = CfgFn.GetNoNullDecimal(TSplit.Rows[0][0]);


            if (movfinanziariConfig){
                txtTotaleMovEnt.Text = totalemovent.ToString("c");
                txtTotaleMovSpe.Text = totalemovspe.ToString("c");
            }

            if (movfinanziariConfig12){
                txtTotaleMovEnt12.Text = totalemovent12.ToString("c");
                txtTotaleMovSpe12.Text = totalemovspe12.ToString("c");
            }

            if (movfinanziariConfigSplit) {
                txtTotaleMovSpeSplit.Text = totalemovspeSplit.ToString("c");
            }

        }
		

        private void btnRiepilogo_Click(object sender, EventArgs e) {
            object yivapay = DBNull.Value;
            object nivapay = DBNull.Value;
            DataRow MyRow = HelpForm.GetLastSelected(DS.ivapay);

            if (MyRow != null)
            {
                yivapay = MyRow["yivapay"];
                nivapay = MyRow["nivapay"];
                DataSet Out = Conn.CallSP("show_ivapay",
                    new Object[2] { yivapay, nivapay });
                if (Out == null) return;
                Out.Tables[0].TableName = "Situazione liquidazione";
                frmSituazioneViewer view = new frmSituazioneViewer(Out);
                createForm(view, null);
                view.Show();


            }

        }

       
		
    }
}
