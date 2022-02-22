
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using System.Data;
using ep_functions;
using funzioni_configurazione;

namespace assetunload_default
{
	/// <summary>
	/// Summary description for frmbuonoscaricoinventario.
	/// </summary>
	public class Frm_assetunload_default : MetaDataForm
	{
        DataTable tInventoryAmortization;
        DataTable tInventorySortingAmortizationYear;
        DataTable tInventoryTree;

		public vistaForm DS;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabBuono;
		private System.Windows.Forms.TabPage tabOperazioni;
		private System.Windows.Forms.TabPage tabRatifica;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.GroupBox grpCausale;
		private System.Windows.Forms.ComboBox cboCausale;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.GroupBox grpCred;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.GroupBox grpMovimenti;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNumeroFin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizioFin;
		private System.Windows.Forms.DataGrid dgrRatifica;
		private System.Windows.Forms.Button btnScollegaMov;
		private System.Windows.Forms.Button btnCollegaMov;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtRatifica;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private MetaData Meta;
        DataAccess Conn;
        private MetaData Mentrataview;
		private object codicefase;
		private System.Windows.Forms.DataGrid dgrScaricoBene;
		private string descrizionefase;
		private bool flagcreddeb;
		private System.Windows.Forms.Button btnModificaScaricoBene;
		private System.Windows.Forms.Button btnScollegaScaricoBene;
		private System.Windows.Forms.Button btnCollegaScaricoBene;
		private bool flagcausale;
        private bool Warning = false;
		private System.Windows.Forms.Button btnWizard;
		private System.Windows.Forms.Label label7;
        private TabPage tabAmmortamenti;
        private Button btnScollegaAmmortamento;
        private Button btnCollegaAmmortamento;
        private Button btnModificaAmmortamento;
        private DataGrid dgrAmmortamenti;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private CheckBox chkTransmitted;
        private TabPage tabEP;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEPnongenerato;
        private Label labEPgenerato;
        private Button btnWizardAmortization;
        private GroupBox gboxtotali;
        private TextBox txttotali;
        private Label label8;
        private TextBox txtrival;
        private Label label5;
        private TextBox txtcarichi;
        private Label label9;
        private Button btnVisualizzaPreaccertamenti;
        private Button btnGeneraPreaccertamenti;
        private Button btnGeneraEpAcc;
        private Button btnVisualizzaEpAcc;
        bool inChiusura = false;

		public Frm_assetunload_default()
		{
			InitializeComponent();
			GetData.SetSorting(DS.incomeview,"ymov DESC,nmov DESC");
			QueryCreator.SetTableForPosting(DS.assetpieceview,"asset");
            QueryCreator.SetTableForPosting(DS.assetamortizationunloadview, "assetamortization");
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			inChiusura = true;
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
            this.DS = new assetunload_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBuono = new System.Windows.Forms.TabPage();
            this.gboxtotali = new System.Windows.Forms.GroupBox();
            this.txttotali = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtrival = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcarichi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkTransmitted = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.grpCred = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabOperazioni = new System.Windows.Forms.TabPage();
            this.btnWizard = new System.Windows.Forms.Button();
            this.btnScollegaScaricoBene = new System.Windows.Forms.Button();
            this.btnCollegaScaricoBene = new System.Windows.Forms.Button();
            this.btnModificaScaricoBene = new System.Windows.Forms.Button();
            this.dgrScaricoBene = new System.Windows.Forms.DataGrid();
            this.tabAmmortamenti = new System.Windows.Forms.TabPage();
            this.btnWizardAmortization = new System.Windows.Forms.Button();
            this.btnScollegaAmmortamento = new System.Windows.Forms.Button();
            this.btnCollegaAmmortamento = new System.Windows.Forms.Button();
            this.btnModificaAmmortamento = new System.Windows.Forms.Button();
            this.dgrAmmortamenti = new System.Windows.Forms.DataGrid();
            this.tabRatifica = new System.Windows.Forms.TabPage();
            this.grpMovimenti = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroFin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizioFin = new System.Windows.Forms.TextBox();
            this.dgrRatifica = new System.Windows.Forms.DataGrid();
            this.btnScollegaMov = new System.Windows.Forms.Button();
            this.btnCollegaMov = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRatifica = new System.Windows.Forms.TextBox();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.btnVisualizzaPreaccertamenti = new System.Windows.Forms.Button();
            this.btnGeneraPreaccertamenti = new System.Windows.Forms.Button();
            this.btnGeneraEpAcc = new System.Windows.Forms.Button();
            this.btnVisualizzaEpAcc = new System.Windows.Forms.Button();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEPnongenerato = new System.Windows.Forms.Label();
            this.labEPgenerato = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabBuono.SuspendLayout();
            this.gboxtotali.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpCausale.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCred.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabOperazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrScaricoBene)).BeginInit();
            this.tabAmmortamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAmmortamenti)).BeginInit();
            this.tabRatifica.SuspendLayout();
            this.grpMovimenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRatifica)).BeginInit();
            this.tabEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBuono);
            this.tabControl1.Controls.Add(this.tabOperazioni);
            this.tabControl1.Controls.Add(this.tabAmmortamenti);
            this.tabControl1.Controls.Add(this.tabRatifica);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 419);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBuono
            // 
            this.tabBuono.Controls.Add(this.gboxtotali);
            this.tabBuono.Controls.Add(this.chkTransmitted);
            this.tabBuono.Controls.Add(this.groupBox1);
            this.tabBuono.Controls.Add(this.groupBox5);
            this.tabBuono.Controls.Add(this.grpCausale);
            this.tabBuono.Controls.Add(this.groupBox2);
            this.tabBuono.Controls.Add(this.grpCred);
            this.tabBuono.Controls.Add(this.textBox13);
            this.tabBuono.Controls.Add(this.label11);
            this.tabBuono.Controls.Add(this.textBox14);
            this.tabBuono.Controls.Add(this.label16);
            this.tabBuono.Controls.Add(this.label17);
            this.tabBuono.Controls.Add(this.textBox15);
            this.tabBuono.Controls.Add(this.groupBox3);
            this.tabBuono.Location = new System.Drawing.Point(4, 22);
            this.tabBuono.Name = "tabBuono";
            this.tabBuono.Size = new System.Drawing.Size(660, 393);
            this.tabBuono.TabIndex = 0;
            this.tabBuono.Text = "Principale";
            this.tabBuono.UseVisualStyleBackColor = true;
            // 
            // gboxtotali
            // 
            this.gboxtotali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxtotali.Controls.Add(this.txttotali);
            this.gboxtotali.Controls.Add(this.label8);
            this.gboxtotali.Controls.Add(this.txtrival);
            this.gboxtotali.Controls.Add(this.label5);
            this.gboxtotali.Controls.Add(this.txtcarichi);
            this.gboxtotali.Controls.Add(this.label9);
            this.gboxtotali.Location = new System.Drawing.Point(514, 6);
            this.gboxtotali.Name = "gboxtotali";
            this.gboxtotali.Size = new System.Drawing.Size(136, 170);
            this.gboxtotali.TabIndex = 82;
            this.gboxtotali.TabStop = false;
            this.gboxtotali.Text = "Totali";
            // 
            // txttotali
            // 
            this.txttotali.Location = new System.Drawing.Point(10, 138);
            this.txttotali.Name = "txttotali";
            this.txttotali.ReadOnly = true;
            this.txttotali.Size = new System.Drawing.Size(100, 20);
            this.txttotali.TabIndex = 5;
            this.txttotali.TabStop = false;
            this.txttotali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Totale buono";
            // 
            // txtrival
            // 
            this.txtrival.Location = new System.Drawing.Point(9, 81);
            this.txtrival.Name = "txtrival";
            this.txtrival.ReadOnly = true;
            this.txtrival.Size = new System.Drawing.Size(100, 20);
            this.txtrival.TabIndex = 3;
            this.txtrival.TabStop = false;
            this.txtrival.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ammortamenti";
            // 
            // txtcarichi
            // 
            this.txtcarichi.Location = new System.Drawing.Point(10, 33);
            this.txtcarichi.Name = "txtcarichi";
            this.txtcarichi.ReadOnly = true;
            this.txtcarichi.Size = new System.Drawing.Size(100, 20);
            this.txtcarichi.TabIndex = 1;
            this.txtcarichi.TabStop = false;
            this.txtcarichi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Scarichi";
            // 
            // chkTransmitted
            // 
            this.chkTransmitted.AutoSize = true;
            this.chkTransmitted.Location = new System.Drawing.Point(242, 339);
            this.chkTransmitted.Name = "chkTransmitted";
            this.chkTransmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTransmitted.TabIndex = 80;
            this.chkTransmitted.Tag = "assetunload.transmitted:S:N";
            this.chkTransmitted.Text = "Trasmesso";
            this.chkTransmitted.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboTipo);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 47);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 180;
            this.label7.Text = "Tipo Buono";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.assetunloadkindview;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(96, 16);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(396, 21);
            this.cboTipo.TabIndex = 2;
            this.cboTipo.Tag = "assetunload.idassetunloadkind.(active=\'S\')";
            this.cboTipo.ValueMember = "idassetunloadkind";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtEsercizio);
            this.groupBox5.Location = new System.Drawing.Point(8, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(160, 72);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 62;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(72, 40);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 61;
            this.txtNumero.Tag = "assetunload.nassetunload";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Esercizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 59;
            this.txtEsercizio.Tag = "assetunload.yassetunload.year";
            // 
            // grpCausale
            // 
            this.grpCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCausale.Controls.Add(this.cboCausale);
            this.grpCausale.Location = new System.Drawing.Point(8, 176);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(642, 40);
            this.grpCausale.TabIndex = 5;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "";
            this.grpCausale.Text = "Causale di Scarico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DataSource = this.DS.assetunloadmotive;
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.Location = new System.Drawing.Point(16, 14);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(618, 21);
            this.cboCausale.TabIndex = 48;
            this.cboCausale.Tag = "assetunload.idmot.(active=\'S\')";
            this.cboCausale.ValueMember = "idmot";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox11);
            this.groupBox2.Controls.Add(this.textBox12);
            this.groupBox2.Location = new System.Drawing.Point(240, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 112);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Provvedimento";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(88, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 75;
            this.label15.Text = "Data:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Location = new System.Drawing.Point(136, 88);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(88, 20);
            this.textBox11.TabIndex = 74;
            this.textBox11.Tag = "assetunload.enactmentdate";
            // 
            // textBox12
            // 
            this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox12.Location = new System.Drawing.Point(16, 16);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox12.Size = new System.Drawing.Size(208, 64);
            this.textBox12.TabIndex = 72;
            this.textBox12.Tag = "assetunload.enactment";
            // 
            // grpCred
            // 
            this.grpCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCred.Controls.Add(this.txtCredDeb);
            this.grpCred.Location = new System.Drawing.Point(8, 128);
            this.grpCred.Name = "grpCred";
            this.grpCred.Size = new System.Drawing.Size(500, 48);
            this.grpCred.TabIndex = 4;
            this.grpCred.TabStop = false;
            this.grpCred.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.grpCred.Text = "Cessionario";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(16, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(468, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?assetunloadview.registry";
            // 
            // textBox13
            // 
            this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox13.Location = new System.Drawing.Point(184, 72);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox13.Size = new System.Drawing.Size(324, 56);
            this.textBox13.TabIndex = 3;
            this.textBox13.Tag = "assetunload.description";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(184, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 77;
            this.label11.Text = "Descrizione:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(128, 336);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(80, 20);
            this.textBox14.TabIndex = 8;
            this.textBox14.Tag = "assetunload.adate";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(16, 336);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 16);
            this.label16.TabIndex = 78;
            this.label16.Text = "Data contabile";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 360);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 79;
            this.label17.Text = "Data stampa";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(128, 360);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(80, 20);
            this.textBox15.TabIndex = 9;
            this.textBox15.Tag = "assetunload.printdate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Location = new System.Drawing.Point(8, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 112);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Documento";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(144, 88);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 20);
            this.textBox4.TabIndex = 65;
            this.textBox4.Tag = "assetunload.docdate";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(96, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 66;
            this.label6.Text = "Data:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(16, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox5.Size = new System.Drawing.Size(208, 64);
            this.textBox5.TabIndex = 63;
            this.textBox5.Tag = "assetunload.doc";
            // 
            // tabOperazioni
            // 
            this.tabOperazioni.Controls.Add(this.btnWizard);
            this.tabOperazioni.Controls.Add(this.btnScollegaScaricoBene);
            this.tabOperazioni.Controls.Add(this.btnCollegaScaricoBene);
            this.tabOperazioni.Controls.Add(this.btnModificaScaricoBene);
            this.tabOperazioni.Controls.Add(this.dgrScaricoBene);
            this.tabOperazioni.Location = new System.Drawing.Point(4, 22);
            this.tabOperazioni.Name = "tabOperazioni";
            this.tabOperazioni.Size = new System.Drawing.Size(660, 393);
            this.tabOperazioni.TabIndex = 1;
            this.tabOperazioni.Text = "Cespiti ed accessori";
            this.tabOperazioni.UseVisualStyleBackColor = true;
            // 
            // btnWizard
            // 
            this.btnWizard.Location = new System.Drawing.Point(384, 8);
            this.btnWizard.Name = "btnWizard";
            this.btnWizard.Size = new System.Drawing.Size(112, 23);
            this.btnWizard.TabIndex = 5;
            this.btnWizard.Text = "Aggiunta guidata";
            this.btnWizard.Click += new System.EventHandler(this.btnWizard_Click);
            // 
            // btnScollegaScaricoBene
            // 
            this.btnScollegaScaricoBene.Location = new System.Drawing.Point(88, 8);
            this.btnScollegaScaricoBene.Name = "btnScollegaScaricoBene";
            this.btnScollegaScaricoBene.Size = new System.Drawing.Size(75, 24);
            this.btnScollegaScaricoBene.TabIndex = 2;
            this.btnScollegaScaricoBene.Tag = "";
            this.btnScollegaScaricoBene.Text = "Rimuovi";
            this.btnScollegaScaricoBene.Click += new System.EventHandler(this.btnScollegaScaricoBene_Click);
            // 
            // btnCollegaScaricoBene
            // 
            this.btnCollegaScaricoBene.Location = new System.Drawing.Point(8, 8);
            this.btnCollegaScaricoBene.Name = "btnCollegaScaricoBene";
            this.btnCollegaScaricoBene.Size = new System.Drawing.Size(75, 24);
            this.btnCollegaScaricoBene.TabIndex = 1;
            this.btnCollegaScaricoBene.Tag = "";
            this.btnCollegaScaricoBene.Text = "Aggiungi";
            this.btnCollegaScaricoBene.Click += new System.EventHandler(this.btnCollegaScaricoBene_Click);
            // 
            // btnModificaScaricoBene
            // 
            this.btnModificaScaricoBene.Location = new System.Drawing.Point(168, 8);
            this.btnModificaScaricoBene.Name = "btnModificaScaricoBene";
            this.btnModificaScaricoBene.Size = new System.Drawing.Size(75, 23);
            this.btnModificaScaricoBene.TabIndex = 4;
            this.btnModificaScaricoBene.Text = "Correggi";
            this.btnModificaScaricoBene.Click += new System.EventHandler(this.btnModificaScaricoBene_Click);
            // 
            // dgrScaricoBene
            // 
            this.dgrScaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrScaricoBene.CaptionVisible = false;
            this.dgrScaricoBene.DataMember = "";
            this.dgrScaricoBene.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrScaricoBene.Location = new System.Drawing.Point(8, 37);
            this.dgrScaricoBene.Name = "dgrScaricoBene";
            this.dgrScaricoBene.Size = new System.Drawing.Size(644, 350);
            this.dgrScaricoBene.TabIndex = 3;
            this.dgrScaricoBene.TabStop = false;
            this.dgrScaricoBene.Tag = "assetpieceview.buonoscarico";
            // 
            // tabAmmortamenti
            // 
            this.tabAmmortamenti.Controls.Add(this.btnWizardAmortization);
            this.tabAmmortamenti.Controls.Add(this.btnScollegaAmmortamento);
            this.tabAmmortamenti.Controls.Add(this.btnCollegaAmmortamento);
            this.tabAmmortamenti.Controls.Add(this.btnModificaAmmortamento);
            this.tabAmmortamenti.Controls.Add(this.dgrAmmortamenti);
            this.tabAmmortamenti.Location = new System.Drawing.Point(4, 22);
            this.tabAmmortamenti.Name = "tabAmmortamenti";
            this.tabAmmortamenti.Size = new System.Drawing.Size(660, 393);
            this.tabAmmortamenti.TabIndex = 3;
            this.tabAmmortamenti.Text = "Ammortamenti";
            this.tabAmmortamenti.UseVisualStyleBackColor = true;
            // 
            // btnWizardAmortization
            // 
            this.btnWizardAmortization.Location = new System.Drawing.Point(379, 5);
            this.btnWizardAmortization.Name = "btnWizardAmortization";
            this.btnWizardAmortization.Size = new System.Drawing.Size(105, 22);
            this.btnWizardAmortization.TabIndex = 9;
            this.btnWizardAmortization.Text = "Aggiunta guidata";
            this.btnWizardAmortization.UseVisualStyleBackColor = true;
            this.btnWizardAmortization.Click += new System.EventHandler(this.btnWizardAmortization_Click);
            // 
            // btnScollegaAmmortamento
            // 
            this.btnScollegaAmmortamento.Location = new System.Drawing.Point(88, 5);
            this.btnScollegaAmmortamento.Name = "btnScollegaAmmortamento";
            this.btnScollegaAmmortamento.Size = new System.Drawing.Size(75, 24);
            this.btnScollegaAmmortamento.TabIndex = 6;
            this.btnScollegaAmmortamento.Tag = "";
            this.btnScollegaAmmortamento.Text = "Rimuovi";
            this.btnScollegaAmmortamento.Click += new System.EventHandler(this.btnScollegaAmmortamento_Click);
            // 
            // btnCollegaAmmortamento
            // 
            this.btnCollegaAmmortamento.Location = new System.Drawing.Point(8, 5);
            this.btnCollegaAmmortamento.Name = "btnCollegaAmmortamento";
            this.btnCollegaAmmortamento.Size = new System.Drawing.Size(75, 24);
            this.btnCollegaAmmortamento.TabIndex = 5;
            this.btnCollegaAmmortamento.Tag = "";
            this.btnCollegaAmmortamento.Text = "Aggiungi";
            this.btnCollegaAmmortamento.Click += new System.EventHandler(this.btnCollegaAmmortamento_Click);
            // 
            // btnModificaAmmortamento
            // 
            this.btnModificaAmmortamento.Location = new System.Drawing.Point(168, 5);
            this.btnModificaAmmortamento.Name = "btnModificaAmmortamento";
            this.btnModificaAmmortamento.Size = new System.Drawing.Size(75, 23);
            this.btnModificaAmmortamento.TabIndex = 8;
            this.btnModificaAmmortamento.Text = "Correggi";
            this.btnModificaAmmortamento.Click += new System.EventHandler(this.btnModificaAmmortamento_Click);
            // 
            // dgrAmmortamenti
            // 
            this.dgrAmmortamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrAmmortamenti.CaptionVisible = false;
            this.dgrAmmortamenti.DataMember = "";
            this.dgrAmmortamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrAmmortamenti.Location = new System.Drawing.Point(8, 34);
            this.dgrAmmortamenti.Name = "dgrAmmortamenti";
            this.dgrAmmortamenti.Size = new System.Drawing.Size(644, 350);
            this.dgrAmmortamenti.TabIndex = 7;
            this.dgrAmmortamenti.TabStop = false;
            this.dgrAmmortamenti.Tag = "assetamortizationunloadview.buonoscarico";
            // 
            // tabRatifica
            // 
            this.tabRatifica.Controls.Add(this.grpMovimenti);
            this.tabRatifica.Controls.Add(this.label13);
            this.tabRatifica.Controls.Add(this.txtRatifica);
            this.tabRatifica.Location = new System.Drawing.Point(4, 22);
            this.tabRatifica.Name = "tabRatifica";
            this.tabRatifica.Size = new System.Drawing.Size(660, 393);
            this.tabRatifica.TabIndex = 2;
            this.tabRatifica.Text = "Ratifica";
            this.tabRatifica.UseVisualStyleBackColor = true;
            // 
            // grpMovimenti
            // 
            this.grpMovimenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMovimenti.Controls.Add(this.label4);
            this.grpMovimenti.Controls.Add(this.txtNumeroFin);
            this.grpMovimenti.Controls.Add(this.label1);
            this.grpMovimenti.Controls.Add(this.txtEsercizioFin);
            this.grpMovimenti.Controls.Add(this.dgrRatifica);
            this.grpMovimenti.Controls.Add(this.btnScollegaMov);
            this.grpMovimenti.Controls.Add(this.btnCollegaMov);
            this.grpMovimenti.Location = new System.Drawing.Point(4, 47);
            this.grpMovimenti.Name = "grpMovimenti";
            this.grpMovimenti.Size = new System.Drawing.Size(652, 333);
            this.grpMovimenti.TabIndex = 72;
            this.grpMovimenti.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(128, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Numero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumeroFin
            // 
            this.txtNumeroFin.Location = new System.Drawing.Point(184, 25);
            this.txtNumeroFin.Name = "txtNumeroFin";
            this.txtNumeroFin.Size = new System.Drawing.Size(48, 20);
            this.txtNumeroFin.TabIndex = 2;
            this.txtNumeroFin.Tag = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizioFin
            // 
            this.txtEsercizioFin.Location = new System.Drawing.Point(72, 25);
            this.txtEsercizioFin.Name = "txtEsercizioFin";
            this.txtEsercizioFin.Size = new System.Drawing.Size(48, 20);
            this.txtEsercizioFin.TabIndex = 1;
            this.txtEsercizioFin.Tag = "";
            this.txtEsercizioFin.Leave += new System.EventHandler(this.txtEsercizioFin_Leave);
            // 
            // dgrRatifica
            // 
            this.dgrRatifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRatifica.CaptionVisible = false;
            this.dgrRatifica.DataMember = "";
            this.dgrRatifica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRatifica.Location = new System.Drawing.Point(8, 56);
            this.dgrRatifica.Name = "dgrRatifica";
            this.dgrRatifica.Size = new System.Drawing.Size(636, 269);
            this.dgrRatifica.TabIndex = 5;
            this.dgrRatifica.Tag = "assetunloadincome.buonodiscarico";
            // 
            // btnScollegaMov
            // 
            this.btnScollegaMov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScollegaMov.Location = new System.Drawing.Point(564, 24);
            this.btnScollegaMov.Name = "btnScollegaMov";
            this.btnScollegaMov.Size = new System.Drawing.Size(75, 23);
            this.btnScollegaMov.TabIndex = 4;
            this.btnScollegaMov.Tag = "delete";
            this.btnScollegaMov.Text = "Rimuovi";
            // 
            // btnCollegaMov
            // 
            this.btnCollegaMov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollegaMov.Location = new System.Drawing.Point(484, 24);
            this.btnCollegaMov.Name = "btnCollegaMov";
            this.btnCollegaMov.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaMov.TabIndex = 3;
            this.btnCollegaMov.Text = "Aggiungi";
            this.btnCollegaMov.Click += new System.EventHandler(this.btnCollegaMov_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(12, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 71;
            this.label13.Text = "Data ratifica";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRatifica
            // 
            this.txtRatifica.Location = new System.Drawing.Point(92, 13);
            this.txtRatifica.Name = "txtRatifica";
            this.txtRatifica.Size = new System.Drawing.Size(80, 20);
            this.txtRatifica.TabIndex = 70;
            this.txtRatifica.Tag = "assetunload.ratificationdate.d";
            this.txtRatifica.Leave += new System.EventHandler(this.txtRatifica_Leave);
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.btnVisualizzaPreaccertamenti);
            this.tabEP.Controls.Add(this.btnGeneraPreaccertamenti);
            this.tabEP.Controls.Add(this.btnGeneraEpAcc);
            this.tabEP.Controls.Add(this.btnVisualizzaEpAcc);
            this.tabEP.Controls.Add(this.btnGeneraEP);
            this.tabEP.Controls.Add(this.btnVisualizzaEP);
            this.tabEP.Controls.Add(this.labEPnongenerato);
            this.tabEP.Controls.Add(this.labEPgenerato);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(660, 393);
            this.tabEP.TabIndex = 4;
            this.tabEP.Text = "E/P";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaPreaccertamenti
            // 
            this.btnVisualizzaPreaccertamenti.Location = new System.Drawing.Point(342, 154);
            this.btnVisualizzaPreaccertamenti.Name = "btnVisualizzaPreaccertamenti";
            this.btnVisualizzaPreaccertamenti.Size = new System.Drawing.Size(298, 23);
            this.btnVisualizzaPreaccertamenti.TabIndex = 67;
            this.btnVisualizzaPreaccertamenti.TabStop = false;
            this.btnVisualizzaPreaccertamenti.Text = "Visualizza Preaccertamenti di Budget";
            // 
            // btnGeneraPreaccertamenti
            // 
            this.btnGeneraPreaccertamenti.Location = new System.Drawing.Point(342, 115);
            this.btnGeneraPreaccertamenti.Name = "btnGeneraPreaccertamenti";
            this.btnGeneraPreaccertamenti.Size = new System.Drawing.Size(298, 23);
            this.btnGeneraPreaccertamenti.TabIndex = 66;
            this.btnGeneraPreaccertamenti.TabStop = false;
            this.btnGeneraPreaccertamenti.Text = "Genera Preaccertamenti di Budget";
            // 
            // btnGeneraEpAcc
            // 
            this.btnGeneraEpAcc.Location = new System.Drawing.Point(342, 34);
            this.btnGeneraEpAcc.Name = "btnGeneraEpAcc";
            this.btnGeneraEpAcc.Size = new System.Drawing.Size(298, 23);
            this.btnGeneraEpAcc.TabIndex = 64;
            this.btnGeneraEpAcc.TabStop = false;
            this.btnGeneraEpAcc.Text = "Genera Accertamenti di Budget";
            // 
            // btnVisualizzaEpAcc
            // 
            this.btnVisualizzaEpAcc.Location = new System.Drawing.Point(342, 74);
            this.btnVisualizzaEpAcc.Name = "btnVisualizzaEpAcc";
            this.btnVisualizzaEpAcc.Size = new System.Drawing.Size(298, 23);
            this.btnVisualizzaEpAcc.TabIndex = 65;
            this.btnVisualizzaEpAcc.TabStop = false;
            this.btnVisualizzaEpAcc.Text = "Visualizza Accertamenti di Budget";
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(3, 94);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 17;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(3, 62);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 16;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // labEPnongenerato
            // 
            this.labEPnongenerato.Location = new System.Drawing.Point(3, 34);
            this.labEPnongenerato.Name = "labEPnongenerato";
            this.labEPnongenerato.Size = new System.Drawing.Size(352, 16);
            this.labEPnongenerato.TabIndex = 15;
            this.labEPnongenerato.Text = "Le scritture in partita doppia NON sono state ancora generate.";
            // 
            // labEPgenerato
            // 
            this.labEPgenerato.Location = new System.Drawing.Point(3, 10);
            this.labEPgenerato.Name = "labEPgenerato";
            this.labEPgenerato.Size = new System.Drawing.Size(352, 16);
            this.labEPgenerato.TabIndex = 14;
            this.labEPgenerato.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aggiunta guidata";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 2;
            this.button2.Tag = "";
            this.button2.Text = "Rimuovi";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 1;
            this.button3.Tag = "";
            this.button3.Text = "Aggiungi";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(168, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Correggi";
            // 
            // Frm_assetunload_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(668, 419);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_assetunload_default";
            this.Text = "frmbuonoscaricoinventario";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabBuono.ResumeLayout(false);
            this.tabBuono.PerformLayout();
            this.gboxtotali.ResumeLayout(false);
            this.gboxtotali.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCred.ResumeLayout(false);
            this.grpCred.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabOperazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrScaricoBene)).EndInit();
            this.tabAmmortamenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAmmortamenti)).EndInit();
            this.tabRatifica.ResumeLayout(false);
            this.tabRatifica.PerformLayout();
            this.grpMovimenti.ResumeLayout(false);
            this.grpMovimenti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRatifica)).EndInit();
            this.tabEP.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterClear() {
            gboxtotali.Visible = false;
			EsaminaFlag();
            txtEsercizio.ReadOnly = false;
            txtNumero.ReadOnly = false;
			txtEsercizio.Text=Meta.GetSys("esercizio").ToString();
			txtEsercizioFin.Text=Meta.GetSys("esercizio").ToString();
			txtNumeroFin.Text = "";
			cboTipo.Enabled = true;
			Meta.UnMarkTableAsNotEntityChild(DS.assetpieceview);
            Meta.UnMarkTableAsNotEntityChild(DS.assetamortizationunloadview);
            EPM.mostraEtichette();
            btnCollegaScaricoBene.Enabled = false;
            btnWizard.Enabled = false;
        }
        private EP_Manager EPM;
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.config,filteresercizio,null,false);
			GetData.CacheTable(DS.incomephase,null,"nphase",true);
            Mentrataview = MetaData.GetMetaData(this, "historyproceedsview");
            tInventoryAmortization = DataAccess.CreateTableByName(Meta.Conn, "inventoryamortization", "*");
            tInventorySortingAmortizationYear = DataAccess.CreateTableByName(Meta.Conn, "inventorysortingamortizationyear", "*");
            tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "*");
            EPM = new EP_Manager(Meta, btnGeneraEpAcc, btnVisualizzaEpAcc, btnGeneraPreaccertamenti, btnVisualizzaPreaccertamenti,
                       btnGeneraEP, btnVisualizzaEP, labEPgenerato, labEPnongenerato, "assetunload");
        }

		public void MetaData_AfterActivation(){
			EsaminaFlag();
            codicefase = Meta.GetSys("maxincomephase");
            DataRow[] rows = DS.incomephase.Select(QHC.CmpEq("nphase", codicefase));
            descrizionefase = "-";
            if (rows.Length > 0) {
                descrizionefase = rows[0]["description"].ToString();
            }
			grpMovimenti.Text=descrizionefase;
			assegnaColoriAiButton();
		}

		private void assegnaColoriAiButton()
		{
			btnCollegaScaricoBene.ForeColor = formcolors.GridButtonForeColor();
			btnCollegaScaricoBene.BackColor = formcolors.GridHeaderBackColor();
			btnScollegaScaricoBene.ForeColor = formcolors.GridButtonForeColor();
			btnScollegaScaricoBene.BackColor = formcolors.GridHeaderBackColor();
			btnModificaScaricoBene.ForeColor = formcolors.GridButtonForeColor();
			btnModificaScaricoBene.BackColor = formcolors.GridHeaderBackColor();
            btnCollegaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
            btnScollegaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnScollegaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
            btnModificaAmmortamento.ForeColor = formcolors.GridButtonForeColor();
            btnModificaAmmortamento.BackColor = formcolors.GridHeaderBackColor();
			btnCollegaMov.ForeColor = formcolors.GridButtonForeColor();
			btnCollegaMov.BackColor = formcolors.GridHeaderBackColor();
		}

        void CalcolaTotali() {
            gboxtotali.Visible = true;
            decimal totcarichi = MetaData.SumColumn(DS.assetpieceview, "currentvalue");
            decimal totrival = -MetaData.SumColumn(DS.assetamortizationunloadview, "amount");
            decimal tot = totcarichi + totrival;
            txtcarichi.Text = totcarichi.ToString("n");
            txtrival.Text = totrival.ToString("n");
            txttotali.Text = tot.ToString("n");
        }

		public void MetaData_AfterFill() {
			if (Meta.IsEmpty) return;
            CalcolaTotali();
            if (Meta.EditMode || Meta.InsertMode) {
                txtEsercizio.ReadOnly = true;
                txtNumero.ReadOnly = true;
            }
            else {
                txtEsercizio.ReadOnly = false;
                txtNumero.ReadOnly = false;
            }
			DataRow Rprimary = DS.assetunload.Rows[0];
			ControlloRatifica();
			EsaminaFlag();
			AbilitaTipoBuono();
			ValorizzaVariabiliUtente();
            EPM.mostraEtichette();
            if (Meta.InsertMode || Meta.EditMode) {
                btnCollegaScaricoBene.Enabled = true;
                btnWizard.Enabled = true;
            }
            else {
                btnCollegaScaricoBene.Enabled = false;
                btnWizard.Enabled = false;
            }
        }

	    bool scrittureAbilitate() {
            if (Meta.IsEmpty || DS.assetunload.Rows.Count==0) return false;
	        object idmot = DS.assetunload.Rows[0]["idmot"];
            if (idmot == DBNull.Value) return false;
	        DataRow[] s = DS.assetunloadmotive.Select(QHC.CmpEq("idmot", idmot));
            if (s.Length == 0) return false;
	        int flag = CfgFn.GetNoNullInt32(s[0]["flag"]);
	        return ((flag & 1) == 0);
	    }
        void VisualizzaEtichetteEP() {
            if (Meta.InsertMode || DS.assetunload.Rows.Count == 0 || DS.config.Rows.Count == 0) {
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = false;
                btnVisualizzaEP.Visible = false;
                btnGeneraEP.Visible = false;
                return;
            }

            string idrelated = EP_functions.GetIdForDocument(DS.assetunload.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("entry",QHS.CmpEq("idrelated",idrelated),true) == 0) {

                labEPnongenerato.Visible = true;
                labEPgenerato.Visible = false;
                btnVisualizzaEP.Visible = false;
                btnGeneraEP.Visible = true;
            }
            else {
                labEPnongenerato.Visible = false;
                labEPgenerato.Visible = true;
                btnVisualizzaEP.Visible = true;
                btnGeneraEP.Visible = false;
            }
        }

		void CollegaAsset(DataRow R){
            string filterpiece_sql = QHS.AppAnd(QHS.CmpEq("idasset", R["idasset"]),
                QHS.CmpGt("idpiece", 1), QHS.IsNull("idassetunload"),QHS.BitSet("flag",0));
			DataTable DaCollegare=Meta.Conn.RUN_SELECT("assetpieceview",
                "*", null, filterpiece_sql, null, true);
            string filterpiece_C = QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),
                QHC.CmpGt("idpiece", 1), QHC.IsNull("idassetunload"), QHC.BitSet("flag", 0));
			
			bool messaggiovisualizzato=false;
			
			DataRow Curr =DS.assetunload.Rows[0];
			foreach (DataRow Rw in DaCollegare.Rows) { // per ogni accessorio da collegare			
				string keyfilter= QueryCreator.WHERE_COLNAME_CLAUSE(Rw,
					new string[]{"idasset","idpiece"},DataRowVersion.Default,false);
				//verifico se presente nel dataSet del form 
				DataRow []Found= DS.assetpieceview.Select(keyfilter);
				if (Found.Length>0){
					//Se presente viene ricollegato
					if (Found[0]["idassetunload"]==DBNull.Value){
                        Found[0]["idassetunload"] = Curr["idassetunload"];
						messaggiovisualizzato=true;
					}
				}
				else { //se non presente, viene aggiunto
					DataRow NewR=DS.assetpieceview.NewRow();
					foreach(DataColumn C in Rw.Table.Columns){
                        if (DS.assetpieceview.Columns.Contains(C.ColumnName)) {
                            NewR[C.ColumnName] = Rw[C.ColumnName];
                        }
					}
					DS.assetpieceview.Rows.Add(NewR);
					NewR.AcceptChanges();
					NewR["idassetunload"]=Curr["idassetunload"];
					messaggiovisualizzato=true;
				}			
			}
            foreach (DataRow Riga in DS.assetpieceview.Select(filterpiece_C)) {
				Riga.BeginEdit();
				Riga["idassetunload"]=Curr["idassetunload"];
				Riga.EndEdit();
				messaggiovisualizzato=true;
			}
			
			Meta.MarkTableAsNotEntityChild(DS.assetpieceview);

			if (messaggiovisualizzato){
				show("Insieme al cespite selezionato saranno scaricati anche i relativi ACCESSORI",
				"Avviso");
			}
			Meta.FreshForm();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			//if (T.TableName=="assetpieceview" && R!=null){
			//	if (!Meta.DrawStateIsDone)return;
			//	if (R["idpiece"].ToString()=="1"){
			//			Meta.GetFormData(true);
			//			CollegaAsset(R);						
			//	}
   //         }
            
		}

        string idrelated = "";
        bool fromDelete = false;
        public void MetaData_BeforePost() {
            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }

		private void AbilitaRatificaCampo(bool enable) {
			txtRatifica.ReadOnly=!enable;
		}
		private void AbilitaRatificaGrid(bool enable) {
			btnCollegaMov.Enabled=enable;
			btnScollegaMov.Enabled=enable;
		}
		private void AbilitaRatifica(bool enable) {
			AbilitaRatificaCampo(enable);
			AbilitaRatificaGrid(enable);
		}

		private void ParseDate(TextBox T) {
			if (!T.Enabled) return;
			if (T.ReadOnly) return;
			if (T.Text=="") return;
			string tag=HelpForm.GetStandardTag(T.Tag);
			//tag = tag+".d";
			string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			string S = T.Text; //+hhsep+"0"+ppsep+"0";
			int len = S.Length;
			object O = DBNull.Value;
			while (len>0){
				try {
					O =HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
					if ((O!=null)&&(O!=DBNull.Value)) break;
				}
				catch {
				}
				len=len-1;
				S= S.Substring(0, len);
			}
			T.Text=HelpForm.StringValue(O, tag);
		}

		private void ControlloRatifica() {
			if (Meta.IsEmpty) return;
			DataRow[] rows=DS.assetunloadincome.Select(null,null,DataViewRowState.CurrentRows);
			ParseDate(txtRatifica);			
			string dataratifica=txtRatifica.Text;
			if (dataratifica=="" && rows.Length==0) {
				AbilitaRatifica(true);
			}
			else {
				if (dataratifica!="") {
					AbilitaRatificaCampo(true);
					AbilitaRatificaGrid(false);
					txtEsercizioFin.Text="";
					txtNumeroFin.Text="";
				}
				if (rows.Length>0) {
					AbilitaRatificaCampo(false);
					AbilitaRatificaGrid(true);
				}
			}
		}

		private void ValorizzaVariabiliUtente() {
			if (Meta.IsEmpty) return;
			DataRow R=DS.assetunload.Rows[0];
			Meta.Conn.SetUsr("frmbuonodiscarico_causale",R["idmot"]);
			Meta.Conn.SetUsr("frmbuonodiscarico_codicecreddeb",R["idreg"]);
		}

		private void AbilitaTipoBuono() {
			if (Meta.IsEmpty) return;
            if (DS.assetpieceview.Rows.Count > 0 || DS.assetamortizationunloadview.Rows.Count > 0)
            {
				cboTipo.Enabled=false;
			}
			else {
				cboTipo.Enabled=Meta.InsertMode;
			}

		}

		private void EsaminaFlag() {	
			if (Warning) return;
			if (DS.config.Rows.Count==0) {
				show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente. "+
					"Non sarà possibile salvare il buono di scarico.\r"+
					@"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione","Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Warning=true;
				Meta.CanSave=false;
				return;
			}
			DataRow r=DS.Tables["config"].Rows[0];
            string flagnumerazione = r["asset_flagnumbering"].ToString().ToUpper();
			if (flagnumerazione=="" || flagnumerazione=="N") {
				show("Non è stato definito il tipo di numerazione per la configurazione "+
					"del PATRIMONIO per l'esercizio corrente. "+
					"Non sarà possibile salvare il buono di scarico.\r"+
					@"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione","Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Warning=true;
				Meta.CanSave=false;
				return;
			}
            byte assetload_flag = (byte)r["assetload_flag"];
            flagcreddeb = (assetload_flag & 1) == 1;
            flagcausale = (assetload_flag & 2) == 2;
			txtCredDeb.ReadOnly = !flagcreddeb;			
			cboCausale.Enabled = flagcausale;
		}

        private string GetInventoryFilter(QueryHelper QH, object codInventario) {
            string filter = "";
            string filterInv = QH.CmpEq("idinventory", codInventario);
            string SQLfilterInv = QHS.CmpEq("idinventory", codInventario);

            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "flag"));
            bool flagMixed = ((flag & 2) != 0);

            if (flagMixed) {

                // Se il flag vale S, non devo filtrare i carichi sull'inventario ma solo sull'ente Inventariale
                object inventoryAgency = Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "idinventoryagency");
                string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                if (ListInvEnte.Rows.Count > 0) {
                    if (ListInvEnte.Rows.Count != 0) {
                        filter = QH.FieldIn("idinventory", ListInvEnte.Select());
                    }
                    else {
                        filter = filterInv;
                    }
                }
                else {
                    filter = filterInv;
                }
            }
            else {

                filter = filterInv;
            }
            return filter;
        }

		private string CalcolaFiltroDocCollegato(string tipo, bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
			Meta.GetFormData(true);
            string filter = qh.AppAnd(qh.IsNull("idassetunload"), 
                            qh.BitSet("flag", 0));

			//ricavo informazioni sul codiceinventario
			if (!Meta.IsEmpty && cboTipo.SelectedIndex>0) {
				DataRow R=DS.assetunload.Rows[0];
				DataRow Rinv=R.GetParentRow("assetunloadkindviewassetunload");
             	if (Rinv!=null) {
                    filter = qh.AppAnd(filter, GetInventoryFilter(qh, Rinv["idinventory"]));
				}
			}
            if (tipo.ToUpper() == "A")
            {
                filter = qh.AppAnd(filter, QHS.CmpLt("amortizationquota", 0));
            }
			return filter;
		}

		private void Collega(string tipo) {
			if (MetaData.Empty(this)) return;
            if (cboTipo.SelectedIndex <= 0)
            {
                show("Selezionare prima il tipo del buono di scarico",
                "Avviso");
                return;
            }
			Meta.GetFormData(true);
			string filter=CalcolaFiltroDocCollegato(tipo, true);
			string command="";
			switch(tipo.ToUpper()) {
				case "B":
					//scarico bene
					command="choose.assetpieceview.buonoscarico";
					break;
                case "A":
                    //scarico bene
                    command = "choose.assetamortizationunloadview.buonoscarico";
                    break;
				default:
					return;
			}
			Meta.DoMainCommand(command+"."+filter);
		}

		private void Scollega(string tipo) {
			if (Meta.IsEmpty) return;
			DataGrid grid;
			switch(tipo.ToUpper()) {
				case "B": 
					grid=dgrScaricoBene;
					break;
                case "A":
                    grid = dgrAmmortamenti;
                    break;
				default: 
					return;
			}
			MetaData.Unlink_Grid(grid);
		}

		private void Modifica(string tipo) {
			if (Meta.IsEmpty) return;
			string lblAdded;
			string lblToAdd;
			DataTable T;
			switch(tipo.ToUpper()) {
				case "B":
					lblAdded="Cespiti e accessori inclusi nel buono di scarico";
					lblToAdd="Cespiti e accessori non inclusi nel buono di scarico";
					T=DS.assetpieceview;
					break;
                case "A":
                    lblAdded = "Ammortamenti inclusi nel buono di scarico";
                    lblToAdd = "Ammortamenti non inclusi nel buono di scarico";
                    T = DS.assetamortizationunloadview;
                    break;
				default:
					return;
			}
			string MyFilter = CalcolaFiltroDocCollegato(tipo, false);
            string MyFilterSQL = CalcolaFiltroDocCollegato(tipo, true);
			Meta.MultipleLinkUnlinkRows("Composizione buono di scarico",
				lblAdded, lblToAdd, T, MyFilter, MyFilterSQL, "default"); 
		}



		private void btnCollegaScaricoBene_Click(object sender, System.EventArgs e) {
			Collega("B");
		}

		private void btnScollegaScaricoBene_Click(object sender, System.EventArgs e) {
			Scollega("B");
		}

		private void btnModificaScaricoBene_Click(object sender, System.EventArgs e) {
			Modifica("B");
		}

//		private void btnCollegaScaricoParte_Click(object sender, System.EventArgs e) {
//			Collega("P");
//		}
//
//		private void btnScollegaScaricoParte_Click(object sender, System.EventArgs e) {
//			Scollega("P");
//		}
//
//		private void btnModificaScaricoParte_Click(object sender, System.EventArgs e) {
//			Modifica("P");
//		}

		private string GetMovimentoFilter() {
			object codicecreddeb = DS.assetunload.Rows[0]["idreg"];

			//string MyFilter="(nphase='"+codicefase+"')";
            string MyFilter="";
			//if(txtEsercizio.Text.Trim() != "")
				//MyFilter+="AND (ayear="+QueryCreator.quotedstrvalue(txtEsercizio.Text.Trim(),true)+")";
              //  MyFilter = QHS.AppAnd(MyFilter,QHS.CmpEq("ayear",txtEsercizio.Text.Trim()));
			if(txtEsercizioFin.Text.Trim() != "")
				//MyFilter+="AND (ymov="+QueryCreator.quotedstrvalue(txtEsercizioFin.Text.Trim(),true)+")";
                MyFilter = QHS.AppAnd(MyFilter,QHS.CmpGe("ymov", txtEsercizioFin.Text.Trim()));
			if(txtNumeroFin.Text.Trim() != "")
				//MyFilter+="AND (nmov="+QueryCreator.quotedstrvalue(txtNumeroFin.Text.Trim(),true)+")";
                MyFilter = QHS.AppAnd(MyFilter,QHS.CmpEq("nmov",txtNumeroFin.Text.Trim()));

            if (flagcreddeb) {
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
            }

			if (DS.assetunloadincome.Rows.Count>0) {
				foreach (DataRow R in DS.assetunloadincome.Rows) {
					if (R.RowState==DataRowState.Deleted) continue;
                    MyFilter = QHS.AppAnd(MyFilter,QHS.CmpNe("idinc",R["idinc"]));
				}
			}
			return MyFilter;
		}


		private void btnCollegaMov_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Mentrataview.FilterLocked=true;
			Mentrataview.DS=DS.Clone();
			DataRow R=Mentrataview.SelectOne("scarico",GetMovimentoFilter(),"historyproceedsview",null);
			if (R==null) return;
			MetaData M=MetaData.GetMetaData(this,"assetunloadincome");
			ImpostaValoriDaEntrata(DS.assetunloadincome, R);
			M.SetDefaults(DS.assetunloadincome);
			M.Get_New_Row(DS.assetunload.Rows[0],DS.assetunloadincome);
			txtNumeroFin.Text="";
		}

		private void ImpostaValoriDaEntrata(DataTable T, DataRow R) {
			MetaData.SetDefault(T,"idinc",R["idinc"]);
			MetaData.SetDefault(T,"!ymov",R["ymov"]);
			MetaData.SetDefault(T,"!nmov",R["nmov"]);
			MetaData.SetDefault(T,"!incomedescription",R["description"]);
			MetaData.SetDefault(T,"!incomedoc",R["doc"]);
			MetaData.SetDefault(T,"!amount",R["amount"]);
			//MetaData.SetDefault(T,"!available",R["available"]);
		}

		private void txtRatifica_Leave(object sender, System.EventArgs e)
		{
			if (inChiusura) return;
			ControlloRatifica();
		}

		private void txtEsercizioFin_Leave(object sender, System.EventArgs e)
		{
			if (inChiusura) return;
			HelpForm.ExtLeaveIntTextBox(txtEsercizioFin,"x.x.year");
		}

		private void btnWizard_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
            if (cboTipo.SelectedIndex <= 0) {
                show("Selezionare prima il tipo del buono di scarico",
                "Avviso");
                return;
            }
            DataRow[] RTipoBuono = DS.assetunloadkindview.Select(QHC.CmpEq("idassetunloadkind" ,cboTipo.SelectedValue ));
			object OldIdinventory;
			if (RTipoBuono.Length>0) {
				OldIdinventory = RTipoBuono[0]["idinventory"];
			}
			else {
				 OldIdinventory = null;
			}
			FrmWizardScarico F = new FrmWizardScarico(Meta,OldIdinventory);
			DialogResult RES =  F.ShowDialog(this);
			if (RES!=DialogResult.OK) return;
			Meta.GetFormData(true);
			DataTable T=F.AssetPiece;  //(assetpieceview)
			if (T.Rows.Count>0) {
				
                object PrimoIdInv = T.Rows[0]["idinventory"];
                //object NewIdInv;
                //int i;
                //for (i = 1; i < T.Rows.Count; i++) {
                //     NewIdInv = T.Rows[i]["idinventory"];
                //     if (!PrimoIdInv.Equals(NewIdInv)) {
                //         show("Attenzione! I cespiti selezionati appartengono a diversi tipi di inventario");
                //         return;
                //     }
                //} 
				DataRow Curr =DS.assetunload.Rows[0];

                if ((Meta.InsertMode) && (CfgFn.GetNoNullDecimal(Curr["idassetunloadkind"]) == 0))
                {
                    DataRow []NewRTipoBuono = DS.assetunloadkindview.Select(QHC.CmpEq("idinventory",PrimoIdInv));
					object NewIdAssetunloadkind;
					if (NewRTipoBuono.Length>0) {
						NewIdAssetunloadkind = NewRTipoBuono[0]["idassetunloadkind"];
						Curr["idassetunloadkind"]= NewIdAssetunloadkind;
						cboTipo.SelectedValue = NewIdAssetunloadkind;
					}
					
				}

				foreach (DataRow R in T.Rows) {	//Righe selezionate attraverso il wizard		
					string keyfilter= QueryCreator.WHERE_COLNAME_CLAUSE(R,
						new string[]{"idasset","idpiece"},DataRowVersion.Default,false);
					// Verifica se già presente nel DataSet del form chiamante
					DataRow []Found= DS.assetpieceview.Select(keyfilter);
					if (Found.Length>0){
						Found[0]["idassetunload"]=Curr["idassetunload"];
					}
					else { //non presente, la aggiunge
						DataRow NewR=DS.assetpieceview.NewRow();
						foreach(DataColumn C in R.Table.Columns){
                            if (DS.assetpieceview.Columns.Contains(C.ColumnName))
							    NewR[C.ColumnName]= R[C.ColumnName];
						}
						DS.assetpieceview.Rows.Add(NewR);
						NewR.AcceptChanges();
						NewR["idassetunload"]=Curr["idassetunload"];
					}
				}
				Meta.MarkTableAsNotEntityChild(DS.assetpieceview);
				Meta.FreshForm();
			}

		}

        private void btnCollegaAmmortamento_Click(object sender, EventArgs e)
        {
            Collega("A");
        }

        private void btnScollegaAmmortamento_Click(object sender, EventArgs e)
        {
            Scollega("A");
        }

        private void btnModificaAmmortamento_Click(object sender, EventArgs e)
        {
            Modifica("A");
        }

       

        #region E/P

       

        


       

        private void btnVisualizzaEP_Click(object sender, EventArgs e) {
            EditEntry();
        }

        void EditEntry() {
            if (DS.assetunload.Rows.Count == 0) return;
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, DS.assetunload.Rows[0]);
        }

        
       

      

        private void cancellaScritture() {
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;
            EP.GetEntryForDocument(idrelated);

            foreach (DataRow rEntry in EP.D.Tables["entry"].Rows) {
                rEntry.Delete();
            }

            foreach (DataRow rEntryDetail in EP.D.Tables["entrydetail"].Rows) {
                rEntryDetail.Delete();
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            if (!Post.DO_POST()) {
                show(this, "Errore durante la cancellazione delle scritture in PD");
            }
        }

        #endregion

        

        private void btnWizardAmortization_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow[] RTipoBuono = DS.assetunloadkindview.Select(QHC.CmpEq("idassetunloadkind", cboTipo.SelectedValue));
            object OldIdinventory;
            if (RTipoBuono.Length > 0)
            {
                OldIdinventory = RTipoBuono[0]["idinventory"];
            }
            else
            {
                OldIdinventory = null;
            }
            FrmWizardAmortization F = new FrmWizardAmortization(Meta, OldIdinventory);
            DialogResult RES = F.ShowDialog(this);
            if (RES != DialogResult.OK) return;
            Meta.GetFormData(true);
            DataTable T = F.AssetAmortization;  //(assetpieceview)
            if (T.Rows.Count > 0)
            {

                object PrimoIdInv = T.Rows[0]["idinventory"];
                //object NewIdInv;
                //int i;
                //for (i = 1; i < T.Rows.Count; i++)
                //{
                //    NewIdInv = T.Rows[i]["idinventory"];
                //    if (!PrimoIdInv.Equals(NewIdInv))
                //    {
                //        show("Attenzione! I cespiti selezionati appartengono a diversi tipi di inventario");
                //        return;
                //    }
                //}
                DataRow Curr = DS.assetunload.Rows[0];
                
                if ((Meta.InsertMode) && (CfgFn.GetNoNullDecimal(Curr["idassetunloadkind"]) == 0))
                {
                    DataRow[] NewRTipoBuono = DS.assetunloadkindview.Select(QHC.CmpEq("idinventory", PrimoIdInv));
                    object NewIdAssetunloadkind;
                    if (NewRTipoBuono.Length > 0)
                    {
                        NewIdAssetunloadkind = NewRTipoBuono[0]["idassetunloadkind"];
                        Curr["idassetunloadkind"] = NewIdAssetunloadkind;
                        cboTipo.SelectedValue = NewIdAssetunloadkind;
                    }

                }

                foreach (DataRow R in T.Rows)
                {	//Righe selezionate attraverso il wizard		
                    string keyfilter = QueryCreator.WHERE_COLNAME_CLAUSE(R,
                        new string[] { "namortization"}, DataRowVersion.Default, false);
                    // Verifica se già presente nel DataSet del form chiamante
                    DataRow[] Found = DS.assetamortizationunloadview.Select(keyfilter);
                    if (Found.Length > 0)
                    {
                        Found[0]["idassetunload"] = Curr["idassetunload"];
                    }
                    else
                    { //non presente, la aggiunge
                        DataRow NewR = DS.assetamortizationunloadview.NewRow();
                        foreach (DataColumn C in R.Table.Columns)
                        {
                            NewR[C.ColumnName] = R[C.ColumnName];
                        }
                        DS.assetamortizationunloadview.Rows.Add(NewR);
                        NewR.AcceptChanges();
                        NewR["idassetunload"] = Curr["idassetunload"];
                    }
                }
                Meta.MarkTableAsNotEntityChild(DS.assetamortizationunloadview);
                Meta.FreshForm();
            }


        }
    }
}
