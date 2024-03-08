
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace service_anagrafica//tipoprestazione_Anagrafica//
{
	/// <summary>
	/// Summary description for frmtipoprestazione_NA.
	/// </summary>
	public class Frm_service_anagrafica : MetaDataForm
	{
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListView listRitenuteDaEffettuare;
		private System.Windows.Forms.TextBox txtCodicePrestazione;
		private System.Windows.Forms.Label label1;
		//private System.Windows.Forms.ListView listRuoliCompatibili;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.TextBox txtDescrizionePrestazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.GroupBox panel;
		private System.Windows.Forms.ComboBox cboCausale;
		private System.Windows.Forms.ComboBox cboModello;
		private System.ComponentModel.IContainer components;
		public /*Rana:tipoprestazione_Anagrafica.*/vistaForm DS;
		private System.Windows.Forms.CheckBox chkMissione;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rdbParasubordinati;
		private System.Windows.Forms.RadioButton rdbOccasionali;
		private System.Windows.Forms.RadioButton rdbProfessionali;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdbAltriCompensi;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.TabPage tabClass;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
        private CheckBox checkBox7;
        private CheckBox checkBox8;
        private CheckBox chkWebDefault;
        private CheckBox checkBox9;
        private TabPage tabPage1;
        private GroupBox grpSpeseMissione;
        private ComboBox cmbSpese;
        private Button button2;
        private GroupBox groupBox5;
        private ComboBox cmbTipoImponibileCSA;
        private Button button1;
        private ComboBox comboBox1;
        private Button button4;
        private GroupBox groupBox6;
        public CheckBox chkCsaUsability7;
        public CheckBox chkCsaUsability6;
        public CheckBox chkCsaUsability5;
        public CheckBox chkCsaUsability4;
        public CheckBox chkCsaUsability3;
        public CheckBox chkCsaUsability2;
        public CheckBox chkCsaUsability1;
        public CheckBox chkCsaUsability8;
        private CheckBox checkBox10;
        private TabPage tabPage2;
        private CheckBox checkBox11;
        private TabPage tabPage3;
        private Label label3;
        private TextBox textBox1;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkVisura;
        private CheckBox chkCCdedicato;
        private CheckBox chkNonCumula;
        private CheckBox chkDurc;
		private CheckBox chkVerificaAnac;
		private CheckBox chkRegolaritaFisc;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkCasellarioGiud;
		private MetaData Meta;

		public Frm_service_anagrafica()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_service_anagrafica));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.panel = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.listRitenuteDaEffettuare = new System.Windows.Forms.ListView();
			this.txtCodicePrestazione = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.txtDescrizionePrestazione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cboCausale = new System.Windows.Forms.ComboBox();
			this.DS = new service_anagrafica.vistaForm();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cboModello = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.chkMissione = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbProfessionali = new System.Windows.Forms.RadioButton();
			this.rdbAltriCompensi = new System.Windows.Forms.RadioButton();
			this.rdbOccasionali = new System.Windows.Forms.RadioButton();
			this.rdbParasubordinati = new System.Windows.Forms.RadioButton();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabMain = new System.Windows.Forms.TabPage();
			this.chkNonCumula = new System.Windows.Forms.CheckBox();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.chkWebDefault = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.tabClass = new System.Windows.Forms.TabPage();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.chkCsaUsability8 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability7 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability6 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability5 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability4 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability3 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability2 = new System.Windows.Forms.CheckBox();
			this.chkCsaUsability1 = new System.Windows.Forms.CheckBox();
			this.grpSpeseMissione = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button4 = new System.Windows.Forms.Button();
			this.cmbSpese = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cmbTipoImponibileCSA = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFisc = new System.Windows.Forms.CheckBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.panel.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.tabClass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.grpSpeseMissione.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// images
			// 
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			this.images.Images.SetKeyName(0, "");
			this.images.Images.SetKeyName(1, "");
			this.images.Images.SetKeyName(2, "");
			this.images.Images.SetKeyName(3, "");
			this.images.Images.SetKeyName(4, "");
			this.images.Images.SetKeyName(5, "");
			this.images.Images.SetKeyName(6, "");
			this.images.Images.SetKeyName(7, "");
			this.images.Images.SetKeyName(8, "");
			this.images.Images.SetKeyName(9, "");
			this.images.Images.SetKeyName(10, "");
			this.images.Images.SetKeyName(11, "");
			this.images.Images.SetKeyName(12, "");
			this.images.Images.SetKeyName(13, "");
			// 
			// panel
			// 
			this.panel.Controls.Add(this.label5);
			this.panel.Controls.Add(this.textBox2);
			this.panel.Location = new System.Drawing.Point(398, 230);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(353, 45);
			this.panel.TabIndex = 13;
			this.panel.TabStop = false;
			this.panel.Text = "Etichette per importi connessi alle prestazioni:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 16);
			this.label5.TabIndex = 49;
			this.label5.Text = "1 -";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(32, 16);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(128, 20);
			this.textBox2.TabIndex = 13;
			this.textBox2.Tag = "service.ivaamount";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(11, 213);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(362, 17);
			this.checkBox1.TabIndex = 12;
			this.checkBox1.Tag = "service.flagonlyfiscalabatement:S:N";
			this.checkBox1.Text = "Non dedurre le ritenute previdenziali e assistenziali dall\'imponibile fiscale";
			// 
			// listRitenuteDaEffettuare
			// 
			this.listRitenuteDaEffettuare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listRitenuteDaEffettuare.AutoArrange = false;
			this.listRitenuteDaEffettuare.CheckBoxes = true;
			this.listRitenuteDaEffettuare.HideSelection = false;
			this.listRitenuteDaEffettuare.Location = new System.Drawing.Point(6, 6);
			this.listRitenuteDaEffettuare.Name = "listRitenuteDaEffettuare";
			this.listRitenuteDaEffettuare.Size = new System.Drawing.Size(749, 450);
			this.listRitenuteDaEffettuare.TabIndex = 2;
			this.listRitenuteDaEffettuare.Tag = "tax.solodescrizione";
			this.listRitenuteDaEffettuare.UseCompatibleStateImageBehavior = false;
			this.listRitenuteDaEffettuare.View = System.Windows.Forms.View.List;
			// 
			// txtCodicePrestazione
			// 
			this.txtCodicePrestazione.Location = new System.Drawing.Point(88, 8);
			this.txtCodicePrestazione.Name = "txtCodicePrestazione";
			this.txtCodicePrestazione.Size = new System.Drawing.Size(188, 20);
			this.txtCodicePrestazione.TabIndex = 4;
			this.txtCodicePrestazione.Tag = "service.codeser";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(36, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 62;
			this.label1.Text = "Codice";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox3
			// 
			this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox3.Location = new System.Drawing.Point(11, 122);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox3.Size = new System.Drawing.Size(80, 16);
			this.checkBox3.TabIndex = 11;
			this.checkBox3.Tag = "service.active:S:N";
			this.checkBox3.Text = "Attivo";
			this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescrizionePrestazione
			// 
			this.txtDescrizionePrestazione.Location = new System.Drawing.Point(88, 34);
			this.txtDescrizionePrestazione.Name = "txtDescrizionePrestazione";
			this.txtDescrizionePrestazione.Size = new System.Drawing.Size(472, 20);
			this.txtDescrizionePrestazione.TabIndex = 5;
			this.txtDescrizionePrestazione.Tag = "service.description";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 84;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cboCausale);
			this.groupBox3.Location = new System.Drawing.Point(11, 393);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(740, 47);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Causale 770 (Si modifica da: Configurazione/Compensi/Ritenute/Causali 770 - Tipi " +
    "di Prestazione)";
			// 
			// cboCausale
			// 
			this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboCausale.DataSource = this.DS.motive770;
			this.cboCausale.DisplayMember = "description";
			this.cboCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCausale.Enabled = false;
			this.cboCausale.Location = new System.Drawing.Point(10, 20);
			this.cboCausale.Name = "cboCausale";
			this.cboCausale.Size = new System.Drawing.Size(724, 21);
			this.cboCausale.TabIndex = 60;
			this.cboCausale.Tag = "motive770service.idmot";
			this.cboCausale.ValueMember = "idmot";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.cboModello);
			this.groupBox4.Controls.Add(this.button3);
			this.groupBox4.Location = new System.Drawing.Point(398, 122);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(353, 48);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			// 
			// cboModello
			// 
			this.cboModello.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cboModello.DataSource = this.DS.certificationmodel;
			this.cboModello.DisplayMember = "description";
			this.cboModello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboModello.Location = new System.Drawing.Point(125, 16);
			this.cboModello.Name = "cboModello";
			this.cboModello.Size = new System.Drawing.Size(222, 21);
			this.cboModello.TabIndex = 59;
			this.cboModello.Tag = "service.certificatekind";
			this.cboModello.ValueMember = "idcertificationmodel";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(111, 21);
			this.button3.TabIndex = 50;
			this.button3.Tag = "manage.certificationmodel.default";
			this.button3.Text = "Modello Cert.Fiscale";
			// 
			// checkBox5
			// 
			this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox5.Location = new System.Drawing.Point(11, 100);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.checkBox5.Size = new System.Drawing.Size(197, 16);
			this.checkBox5.TabIndex = 9;
			this.checkBox5.Tag = "service.flagapplyabatements:S:N";
			this.checkBox5.Text = "Calcola detrazioni";
			this.checkBox5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkMissione
			// 
			this.chkMissione.Location = new System.Drawing.Point(11, 281);
			this.chkMissione.Name = "chkMissione";
			this.chkMissione.Size = new System.Drawing.Size(130, 16);
			this.chkMissione.TabIndex = 8;
			this.chkMissione.Tag = "service.itinerationvisible:S:N";
			this.chkMissione.Text = "Visibile in Missione";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(11, 259);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(216, 16);
			this.checkBox4.TabIndex = 10;
			this.checkBox4.Tag = "service.flagalwaysinfiscalmodels:S:N";
			this.checkBox4.Text = "Includi sempre in certificazioni  fiscali ";
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(11, 78);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(216, 16);
			this.checkBox6.TabIndex = 7;
			this.checkBox6.Tag = "service.allowedit:S:N";
			this.checkBox6.Text = "Consenti immissione manuale ritenute";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbProfessionali);
			this.groupBox1.Controls.Add(this.rdbAltriCompensi);
			this.groupBox1.Controls.Add(this.rdbOccasionali);
			this.groupBox1.Controls.Add(this.rdbParasubordinati);
			this.groupBox1.Location = new System.Drawing.Point(11, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(381, 60);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Modulo di gestione";
			// 
			// rdbProfessionali
			// 
			this.rdbProfessionali.Location = new System.Drawing.Point(218, 36);
			this.rdbProfessionali.Name = "rdbProfessionali";
			this.rdbProfessionali.Size = new System.Drawing.Size(144, 16);
			this.rdbProfessionali.TabIndex = 3;
			this.rdbProfessionali.Tag = "service.module:PROFESSIONALE";
			this.rdbProfessionali.Text = "Autonomi professionali";
			this.rdbProfessionali.CheckedChanged += new System.EventHandler(this.rdbProfessionali_CheckedChanged);
			// 
			// rdbAltriCompensi
			// 
			this.rdbAltriCompensi.Location = new System.Drawing.Point(48, 36);
			this.rdbAltriCompensi.Name = "rdbAltriCompensi";
			this.rdbAltriCompensi.Size = new System.Drawing.Size(112, 16);
			this.rdbAltriCompensi.TabIndex = 2;
			this.rdbAltriCompensi.Tag = "service.module:DIPENDENTE";
			this.rdbAltriCompensi.Text = "Altri Compensi";
			this.rdbAltriCompensi.CheckedChanged += new System.EventHandler(this.rdbAltriCompensi_CheckedChanged);
			// 
			// rdbOccasionali
			// 
			this.rdbOccasionali.Location = new System.Drawing.Point(218, 19);
			this.rdbOccasionali.Name = "rdbOccasionali";
			this.rdbOccasionali.Size = new System.Drawing.Size(136, 16);
			this.rdbOccasionali.TabIndex = 1;
			this.rdbOccasionali.Tag = "service.module:OCCASIONALE";
			this.rdbOccasionali.Text = "Autonomi occasionali";
			this.rdbOccasionali.CheckedChanged += new System.EventHandler(this.rdbOccasionali_CheckedChanged);
			// 
			// rdbParasubordinati
			// 
			this.rdbParasubordinati.Location = new System.Drawing.Point(48, 19);
			this.rdbParasubordinati.Name = "rdbParasubordinati";
			this.rdbParasubordinati.Size = new System.Drawing.Size(131, 16);
			this.rdbParasubordinati.TabIndex = 0;
			this.rdbParasubordinati.Tag = "service.module:COCOCO";
			this.rdbParasubordinati.Text = "Parasubordinati";
			this.rdbParasubordinati.CheckedChanged += new System.EventHandler(this.rdbParasubordinati_CheckedChanged);
			// 
			// textBox11
			// 
			this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox11.Location = new System.Drawing.Point(9, 19);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(338, 20);
			this.textBox11.TabIndex = 90;
			this.textBox11.Tag = "service.rec770kind";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox11);
			this.groupBox2.Location = new System.Drawing.Point(398, 176);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(353, 48);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo Record 770";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabMain);
			this.tabControl1.Controls.Add(this.tabClass);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(8, 66);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(769, 498);
			this.tabControl1.TabIndex = 85;
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.chkNonCumula);
			this.tabMain.Controls.Add(this.grpCertificatiNecessari);
			this.tabMain.Controls.Add(this.checkBox10);
			this.tabMain.Controls.Add(this.checkBox9);
			this.tabMain.Controls.Add(this.chkWebDefault);
			this.tabMain.Controls.Add(this.checkBox8);
			this.tabMain.Controls.Add(this.checkBox7);
			this.tabMain.Controls.Add(this.groupBox4);
			this.tabMain.Controls.Add(this.groupBox3);
			this.tabMain.Controls.Add(this.groupBox2);
			this.tabMain.Controls.Add(this.panel);
			this.tabMain.Controls.Add(this.checkBox5);
			this.tabMain.Controls.Add(this.chkMissione);
			this.tabMain.Controls.Add(this.checkBox1);
			this.tabMain.Controls.Add(this.checkBox6);
			this.tabMain.Controls.Add(this.checkBox3);
			this.tabMain.Controls.Add(this.checkBox4);
			this.tabMain.Controls.Add(this.groupBox1);
			this.tabMain.Location = new System.Drawing.Point(4, 23);
			this.tabMain.Name = "tabMain";
			this.tabMain.Size = new System.Drawing.Size(761, 471);
			this.tabMain.TabIndex = 0;
			this.tabMain.Text = "Principale";
			// 
			// chkNonCumula
			// 
			this.chkNonCumula.AutoSize = true;
			this.chkNonCumula.Location = new System.Drawing.Point(11, 190);
			this.chkNonCumula.Name = "chkNonCumula";
			this.chkNonCumula.Size = new System.Drawing.Size(319, 17);
			this.chkNonCumula.TabIndex = 95;
			this.chkNonCumula.Tag = "service.flagnoncumula:S:N";
			this.chkNonCumula.Text = "Non sommare redditi di altri contratti all\'imponibile previdenziale";
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(398, 12);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(353, 104);
			this.grpCertificatiNecessari.TabIndex = 94;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(18, 72);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(57, 17);
			this.chkDurc.TabIndex = 94;
			this.chkDurc.Tag = "service.requested_doc:2";
			this.chkDurc.Text = "DURC";
			this.chkDurc.UseVisualStyleBackColor = true;
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(18, 49);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(102, 17);
			this.chkVisura.TabIndex = 93;
			this.chkVisura.Tag = "service.requested_doc:1";
			this.chkVisura.Text = "Visura Camerale";
			this.chkVisura.UseVisualStyleBackColor = true;
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(18, 26);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "service.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(11, 236);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(222, 17);
			this.checkBox10.TabIndex = 90;
			this.checkBox10.Tag = "service.flagnoexemptionquote:S:N";
			this.checkBox10.Text = "Non applicare quota esente previdenziale";
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(11, 167);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(147, 17);
			this.checkBox9.TabIndex = 89;
			this.checkBox9.Tag = "service.flagdistraint:S:N";
			this.checkBox9.Text = "Pignoramento presso terzi";
			// 
			// chkWebDefault
			// 
			this.chkWebDefault.Location = new System.Drawing.Point(11, 303);
			this.chkWebDefault.Name = "chkWebDefault";
			this.chkWebDefault.Size = new System.Drawing.Size(132, 16);
			this.chkWebDefault.TabIndex = 88;
			this.chkWebDefault.Tag = "service.webdefault:S:N";
			this.chkWebDefault.Text = "Predefinita per il Web";
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(11, 324);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(128, 17);
			this.checkBox8.TabIndex = 86;
			this.checkBox8.Tag = "service.flagforeign:S:N";
			this.checkBox8.Text = "Per residenti all\'estero";
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(11, 144);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(213, 17);
			this.checkBox7.TabIndex = 85;
			this.checkBox7.Tag = "service.flagneedbalance:S:N";
			this.checkBox7.Text = "Prestazione con conguaglio a fine anno";
			// 
			// tabClass
			// 
			this.tabClass.Controls.Add(this.button7);
			this.tabClass.Controls.Add(this.button6);
			this.tabClass.Controls.Add(this.button5);
			this.tabClass.Controls.Add(this.dataGrid1);
			this.tabClass.ImageIndex = 0;
			this.tabClass.Location = new System.Drawing.Point(4, 23);
			this.tabClass.Name = "tabClass";
			this.tabClass.Size = new System.Drawing.Size(761, 471);
			this.tabClass.TabIndex = 1;
			this.tabClass.Text = "Classificazione";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(184, 8);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 5;
			this.button7.Tag = "delete";
			this.button7.Text = "Cancella";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(96, 8);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 4;
			this.button6.Tag = "edit.single";
			this.button6.Text = "Correggi";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 8);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 3;
			this.button5.Tag = "insert.single";
			this.button5.Text = "Aggiungi";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(750, 426);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "servicesorting.default.default";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox6);
			this.tabPage1.Controls.Add(this.grpSpeseMissione);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(761, 471);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Record 8000";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.chkCsaUsability8);
			this.groupBox6.Controls.Add(this.chkCsaUsability7);
			this.groupBox6.Controls.Add(this.chkCsaUsability6);
			this.groupBox6.Controls.Add(this.chkCsaUsability5);
			this.groupBox6.Controls.Add(this.chkCsaUsability4);
			this.groupBox6.Controls.Add(this.chkCsaUsability3);
			this.groupBox6.Controls.Add(this.chkCsaUsability2);
			this.groupBox6.Controls.Add(this.chkCsaUsability1);
			this.groupBox6.Location = new System.Drawing.Point(467, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(276, 229);
			this.groupBox6.TabIndex = 91;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Usabilità  per Record 8000";
			// 
			// chkCsaUsability8
			// 
			this.chkCsaUsability8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability8.AutoSize = true;
			this.chkCsaUsability8.Location = new System.Drawing.Point(20, 195);
			this.chkCsaUsability8.Name = "chkCsaUsability8";
			this.chkCsaUsability8.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability8.TabIndex = 104;
			this.chkCsaUsability8.Tag = "service.flagcsausability:7";
			this.chkCsaUsability8.Text = " ";
			this.chkCsaUsability8.Visible = false;
			// 
			// chkCsaUsability7
			// 
			this.chkCsaUsability7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability7.AutoSize = true;
			this.chkCsaUsability7.Location = new System.Drawing.Point(20, 172);
			this.chkCsaUsability7.Name = "chkCsaUsability7";
			this.chkCsaUsability7.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability7.TabIndex = 103;
			this.chkCsaUsability7.Tag = "service.flagcsausability:6";
			this.chkCsaUsability7.Text = " ";
			this.chkCsaUsability7.Visible = false;
			// 
			// chkCsaUsability6
			// 
			this.chkCsaUsability6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability6.AutoSize = true;
			this.chkCsaUsability6.Location = new System.Drawing.Point(20, 145);
			this.chkCsaUsability6.Name = "chkCsaUsability6";
			this.chkCsaUsability6.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability6.TabIndex = 102;
			this.chkCsaUsability6.Tag = "service.flagcsausability::5";
			this.chkCsaUsability6.Text = " ";
			this.chkCsaUsability6.Visible = false;
			// 
			// chkCsaUsability5
			// 
			this.chkCsaUsability5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability5.AutoSize = true;
			this.chkCsaUsability5.Location = new System.Drawing.Point(20, 116);
			this.chkCsaUsability5.Name = "chkCsaUsability5";
			this.chkCsaUsability5.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability5.TabIndex = 101;
			this.chkCsaUsability5.Tag = "service.flagcsausability:4";
			this.chkCsaUsability5.Text = " ";
			this.chkCsaUsability5.Visible = false;
			// 
			// chkCsaUsability4
			// 
			this.chkCsaUsability4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability4.AutoSize = true;
			this.chkCsaUsability4.Location = new System.Drawing.Point(20, 93);
			this.chkCsaUsability4.Name = "chkCsaUsability4";
			this.chkCsaUsability4.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability4.TabIndex = 100;
			this.chkCsaUsability4.Tag = "service.flagcsausability::3";
			this.chkCsaUsability4.Text = " ";
			this.chkCsaUsability4.Visible = false;
			// 
			// chkCsaUsability3
			// 
			this.chkCsaUsability3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability3.AutoSize = true;
			this.chkCsaUsability3.Location = new System.Drawing.Point(20, 68);
			this.chkCsaUsability3.Name = "chkCsaUsability3";
			this.chkCsaUsability3.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability3.TabIndex = 99;
			this.chkCsaUsability3.Tag = "service.flagcsausability::2";
			this.chkCsaUsability3.Text = " ";
			this.chkCsaUsability3.Visible = false;
			// 
			// chkCsaUsability2
			// 
			this.chkCsaUsability2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability2.AutoSize = true;
			this.chkCsaUsability2.Location = new System.Drawing.Point(20, 42);
			this.chkCsaUsability2.Name = "chkCsaUsability2";
			this.chkCsaUsability2.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability2.TabIndex = 98;
			this.chkCsaUsability2.Tag = "service.flagcsausability::1";
			this.chkCsaUsability2.Text = " ";
			this.chkCsaUsability2.Visible = false;
			// 
			// chkCsaUsability1
			// 
			this.chkCsaUsability1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkCsaUsability1.AutoSize = true;
			this.chkCsaUsability1.Location = new System.Drawing.Point(20, 17);
			this.chkCsaUsability1.Name = "chkCsaUsability1";
			this.chkCsaUsability1.Size = new System.Drawing.Size(29, 17);
			this.chkCsaUsability1.TabIndex = 97;
			this.chkCsaUsability1.Tag = "service.flagcsausability:0";
			this.chkCsaUsability1.Text = " ";
			this.chkCsaUsability1.Visible = false;
			// 
			// grpSpeseMissione
			// 
			this.grpSpeseMissione.Controls.Add(this.comboBox1);
			this.grpSpeseMissione.Controls.Add(this.button4);
			this.grpSpeseMissione.Controls.Add(this.cmbSpese);
			this.grpSpeseMissione.Controls.Add(this.button2);
			this.grpSpeseMissione.Location = new System.Drawing.Point(6, 62);
			this.grpSpeseMissione.Name = "grpSpeseMissione";
			this.grpSpeseMissione.Size = new System.Drawing.Size(455, 77);
			this.grpSpeseMissione.TabIndex = 89;
			this.grpSpeseMissione.TabStop = false;
			this.grpSpeseMissione.Text = "Missioni ";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.voce8000_s1;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(176, 45);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(273, 21);
			this.comboBox1.TabIndex = 61;
			this.comboBox1.Tag = "service.voce8000refund_e";
			this.comboBox1.ValueMember = "voce";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 45);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(140, 21);
			this.button4.TabIndex = 60;
			this.button4.Tag = "manage.voce8000_s1.default";
			this.button4.Text = "Voce CSA  Spese Estero";
			// 
			// cmbSpese
			// 
			this.cmbSpese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbSpese.DataSource = this.DS.voce8000_s;
			this.cmbSpese.DisplayMember = "description";
			this.cmbSpese.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpese.Location = new System.Drawing.Point(176, 16);
			this.cmbSpese.Name = "cmbSpese";
			this.cmbSpese.Size = new System.Drawing.Size(273, 21);
			this.cmbSpese.TabIndex = 59;
			this.cmbSpese.Tag = "service.voce8000refund_i";
			this.cmbSpese.ValueMember = "voce";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(140, 21);
			this.button2.TabIndex = 50;
			this.button2.Tag = "manage.voce8000_s.default";
			this.button2.Text = "Voce CSA  Spese Italia";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cmbTipoImponibileCSA);
			this.groupBox5.Controls.Add(this.button1);
			this.groupBox5.Location = new System.Drawing.Point(6, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(455, 48);
			this.groupBox5.TabIndex = 88;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Imponibile";
			// 
			// cmbTipoImponibileCSA
			// 
			this.cmbTipoImponibileCSA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoImponibileCSA.DataSource = this.DS.voce8000;
			this.cmbTipoImponibileCSA.DisplayMember = "description";
			this.cmbTipoImponibileCSA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoImponibileCSA.Location = new System.Drawing.Point(176, 16);
			this.cmbTipoImponibileCSA.Name = "cmbTipoImponibileCSA";
			this.cmbTipoImponibileCSA.Size = new System.Drawing.Size(273, 21);
			this.cmbTipoImponibileCSA.TabIndex = 59;
			this.cmbTipoImponibileCSA.Tag = "service.voce8000";
			this.cmbTipoImponibileCSA.ValueMember = "voce";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 21);
			this.button1.TabIndex = 50;
			this.button1.Tag = "manage.voce8000.default";
			this.button1.Text = "Voce CSA";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.checkBox11);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(761, 471);
			this.tabPage2.TabIndex = 3;
			this.tabPage2.Text = "Banca Dati DALIA";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(6, 15);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(168, 17);
			this.checkBox11.TabIndex = 90;
			this.checkBox11.Tag = "service.flagdalia:S:N";
			this.checkBox11.Text = "Abilita la trasmissione a DALIA";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.listRitenuteDaEffettuare);
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(761, 471);
			this.tabPage3.TabIndex = 4;
			this.tabPage3.Text = "Ritenute da effettuare";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(290, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 16);
			this.label3.TabIndex = 87;
			this.label3.Text = "Codice 770";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(371, 9);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(189, 20);
			this.textBox1.TabIndex = 86;
			this.textBox1.Tag = "service.servicecode770";
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(18, 95);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 95;
			this.chkCasellarioGiud.Tag = "service.requested_doc:3";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(18, 118);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 96;
			this.chkCasellarioAmm.Tag = "service.requested_doc:4";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(18, 142);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 97;
			this.chkOttempLegge.Tag = "service.requested_doc:5";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFisc
			// 
			this.chkRegolaritaFisc.AutoSize = true;
			this.chkRegolaritaFisc.Location = new System.Drawing.Point(18, 166);
			this.chkRegolaritaFisc.Name = "chkRegolaritaFisc";
			this.chkRegolaritaFisc.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFisc.TabIndex = 98;
			this.chkRegolaritaFisc.Tag = "service.requested_doc:6";
			this.chkRegolaritaFisc.Text = "Regolarità Fiscale";
			this.chkRegolaritaFisc.UseVisualStyleBackColor = true;
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(18, 190);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 99;
			this.chkVerificaAnac.Tag = "service.requested_doc:7";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// Frm_service_anagrafica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(785, 570);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDescrizionePrestazione);
			this.Controls.Add(this.txtCodicePrestazione);
			this.Controls.Add(this.label2);
			this.Name = "Frm_service_anagrafica";
			this.Text = "frmtipoprestazione_Anagrafica";
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabMain.ResumeLayout(false);
			this.tabMain.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.tabClass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.grpSpeseMissione.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() {
			//Carico tutte le righe delle tabelle TipoRitenuta, RapportoLavoro e CdRuolo
			GetData.CacheTable(DS.tax,null,"description",false);
			//GetData.CacheTable(DS.workcontract,null,"description",false);	
			//GetData.CacheTable(DS.role,null,"description",false);
			//GetData.CacheTable(DS.motive770service);
            GetData.CacheTable(DS.motive770);

			Meta = MetaData.GetMetaData(this);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
			bool IsAdmin=false;

			if (Meta.GetSys("manage_prestazioni")!=null) {
				IsAdmin=(Meta.GetSys("manage_prestazioni").ToString().ToUpper()=="S");
			}
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;			

			int esercizioPrec = (int) Meta.Conn.GetEsercizio()- 1;
			groupBox3.Text = "Causale 770/"+Meta.GetSys("esercizio")+" (si modifica da Configurazione/Compensi/Imposte/Causali 770 - Tipi di Prestazione)";
			string filter=QHS.CmpEq("ayear",esercizioPrec);
			GetData.SetStaticFilter(DS.motive770,filter);
			GetData.SetStaticFilter(DS.motive770service,filter);
 
			HelpForm.SetDenyNull(DS.service.Columns["itinerationvisible"],true);
			HelpForm.SetDenyNull(DS.service.Columns["flagalwaysinfiscalmodels"],true);
            HelpForm.SetDenyNull(DS.service.Columns["flagneedbalance"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagforeign"], true);
            HelpForm.SetDenyNull(DS.service.Columns["active"], true);
            HelpForm.SetDenyNull(DS.service.Columns["webdefault"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagdistraint"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagcsausability"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagnoexemptionquote"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagdalia"], true);
            HelpForm.SetDenyNull(DS.service.Columns["flagnoncumula"], true);
            string filter_voce8000 = QHS.AppAnd(QHS.CmpEq("active", "S"),QHS.CmpEq("kind","I"));
            GetData.SetStaticFilter(DS.voce8000, filter_voce8000);

            DataAccess.SetTableForReading(DS.voce8000_s, "voce8000");
            DataAccess.SetTableForReading(DS.voce8000_s1, "voce8000");
            string filter_voce8000_s = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("kind", "S"));
            GetData.SetStaticFilter(DS.voce8000_s, filter_voce8000_s);
            GetData.SetStaticFilter(DS.voce8000_s1, filter_voce8000_s);
            VisualizzaCheckBox();
            HelpForm.SetDenyNull(DS.service.Columns["requested_doc"], true);
        }


        private void VisualizzaCheckBox()
        {
            int n_chk = 8;
            for (int i = 1; i <= (n_chk - 1); i++)
            {
                CheckBox chk = GetCtrlByName("chkCsaUsability" + n_chk.ToString()) as CheckBox;
                if (chk == null) return;
                chk.Visible = false;
            }

            string num = ""; int bitposition = 0;
            DataTable tservicecsausability = Meta.Conn.RUN_SELECT("servicecsausability", "*", null, null, null, null, true);
            foreach (DataRow r in tservicecsausability.Rows)
            {
                num = r["idlabel"].ToString();
                bitposition = CfgFn.GetNoNullInt32(r["bitposition"]);
                string dicitura = r["description"].ToString();

                CheckBox CB = GetCtrlByName("chkCsaUsability" + num) as CheckBox;
                if (CB == null)
                    continue;
                CB.Text = dicitura;
                CB.Tag = "service.flagcsausability:" + bitposition.ToString();
                CB.Visible = true;
            }

        }

        public void MetaData_AfterClear() {
            chkCCdedicato.Enabled = true;
            chkVisura.Enabled = true;
			chkDurc.Enabled = true;
			chkCasellarioGiud.Enabled = true;
			chkCasellarioAmm.Enabled = true;
			chkOttempLegge.Enabled = true;
			chkRegolaritaFisc.Enabled = true;
			chkVerificaAnac.Enabled = true;
        }

        public void MetaData_AfterFill() {
            if (Meta.IsEmpty) return;
            if (DS.service.Rows.Count > 0){
                DataRow R = DS.service.Rows[0];
                if (R["module"].ToString() == "") return;
                if ((R["module"].ToString() == "DIPENDENTE") ||(R["itinerationvisible"].ToString()=="S")){
                    chkCCdedicato.Enabled = false;
                }
                else {
                    chkCCdedicato.Enabled = true;
                }
                if (R["module"].ToString() == "PROFESSIONALE"){
                    //Solo il modulo Professionale è soggetto alla verifica dell'esistenza della visura
                    chkVisura.Enabled = true;
					chkDurc.Enabled = true;
                }
                else {
                    chkVisura.Enabled = false;
					chkDurc.Enabled = false;
                }
            }
        }

        private object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        private void rdbParasubordinati_CheckedChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (rdbParasubordinati.Checked) {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = false;
				chkDurc.Enabled = false;
            }
        }

        private void rdbAltriCompensi_CheckedChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (rdbAltriCompensi.Checked) {
                chkCCdedicato.Enabled = false;
                chkVisura.Enabled = false;
				chkDurc.Enabled = false;
            }
        }

        private void rdbOccasionali_CheckedChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (rdbOccasionali.Checked) {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = false;
				chkDurc.Enabled = false;
            }
        }

        private void rdbProfessionali_CheckedChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (rdbProfessionali.Checked) {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = true;
				chkDurc.Enabled = true;
            }
        }
    }
}
