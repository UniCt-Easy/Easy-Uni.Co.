
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Globalization;
using ep_functions;
using funzioni_configurazione;

namespace assetload_generazioneautomatica//buonocaricoinv_gen_auto//
{
	/// <summary>
	/// Summary description for frmbuonocaricoinv_gen_auto.
	/// </summary>
	public class Frm_assetload_generazioneautomatica : System.Windows.Forms.Form
	{
        DataTable tInventoryTree;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.GroupBox grpCausale;
		private System.Windows.Forms.GroupBox grpCred;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox grpCaricoBene;
		private System.Windows.Forms.DataGrid dgrCaricoBene;
		private System.Windows.Forms.TextBox txtCausale;
		private System.Windows.Forms.TextBox textBox1;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		DataAccess Conn;
		DataTable TempTable;
		private bool flagcreddeb;
		private bool flagcausale;
		private System.Windows.Forms.Button btnAddBene;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnInizia;
		private System.Windows.Forms.ComboBox cboTipo;
		private System.Windows.Forms.GroupBox grpIncludi;
		private object CodiceTipoBuono=null;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Button btnSuccessivo;
		private System.Windows.Forms.Button btnGeneraTutto;
		private System.Windows.Forms.ToolTip Tip;
		private System.Windows.Forms.Button button4;
		private bool flag_bene=true;
		private bool flag_aumento=true;
		private System.Windows.Forms.GroupBox grpRatifica;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDataRatifica;
		private System.Windows.Forms.Button btnCollegaMov;
		private System.Windows.Forms.Button btnScollegaMov;
		bool Warning=false;
		private MetaData Mspesaview;
		private System.Windows.Forms.DataGrid gridRatifica;
		private object codicefase;
		private System.Windows.Forms.TextBox textBoxDescrizione;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBoxDataDocumento;
		private System.Windows.Forms.TextBox textBoxDocumento;
		private System.Windows.Forms.TextBox textBoxProvvedimento;
		private System.Windows.Forms.GroupBox grpElabora;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnSi;
		private System.Windows.Forms.Button btnDeselBene;
		private object m_DataRatifica=DBNull.Value;
        private EP_Manager EPM;

        public Frm_assetload_generazioneautomatica()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			QueryCreator.SetTableForPosting(DS.assetacquireview,"assetacquire");
//			QueryCreator.SetTableForPosting(DS.assetaccretionview,"assetaccretion");
			TempTable = new DataTable("temptable");
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
            this.DS = new assetload_generazioneautomatica.vistaForm();
            this.button4 = new System.Windows.Forms.Button();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.grpCred = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.grpCaricoBene = new System.Windows.Forms.GroupBox();
            this.btnDeselBene = new System.Windows.Forms.Button();
            this.btnAddBene = new System.Windows.Forms.Button();
            this.dgrCaricoBene = new System.Windows.Forms.DataGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnInizia = new System.Windows.Forms.Button();
            this.grpIncludi = new System.Windows.Forms.GroupBox();
            this.btnGeneraTutto = new System.Windows.Forms.Button();
            this.btnSi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.btnSuccessivo = new System.Windows.Forms.Button();
            this.Tip = new System.Windows.Forms.ToolTip(this.components);
            this.grpRatifica = new System.Windows.Forms.GroupBox();
            this.btnScollegaMov = new System.Windows.Forms.Button();
            this.gridRatifica = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataRatifica = new System.Windows.Forms.TextBox();
            this.btnCollegaMov = new System.Windows.Forms.Button();
            this.textBoxDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDocumento = new System.Windows.Forms.TextBox();
            this.textBoxDataDocumento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxProvvedimento = new System.Windows.Forms.TextBox();
            this.grpElabora = new System.Windows.Forms.GroupBox();
            this.btnNo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.grpCausale.SuspendLayout();
            this.grpCred.SuspendLayout();
            this.grpCaricoBene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).BeginInit();
            this.grpIncludi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpRatifica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatifica)).BeginInit();
            this.grpElabora.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(72, 24);
            this.button4.TabIndex = 177;
            this.button4.Tag = "choose.assetloadkind.default";
            this.button4.Text = "Tipo buono";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DataSource = this.DS.assetloadkind;
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.Location = new System.Drawing.Point(88, 16);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(536, 21);
            this.cboTipo.TabIndex = 3;
            this.cboTipo.Tag = "assetload.idassetloadkind.(active=\'S\')";
            this.cboTipo.ValueMember = "idassetloadkind";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Location = new System.Drawing.Point(184, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(144, 48);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(8, 16);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(128, 20);
            this.txtNumero.TabIndex = 61;
            this.txtNumero.Tag = "assetload.nassetload";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(8, 16);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 59;
            this.txtEsercizio.Tag = "assetload.yassetload.year";
            // 
            // grpCausale
            // 
            this.grpCausale.Controls.Add(this.txtCausale);
            this.grpCausale.Location = new System.Drawing.Point(8, 144);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(320, 48);
            this.grpCausale.TabIndex = 5;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "";
            this.grpCausale.Text = "Causale di carico";
            // 
            // txtCausale
            // 
            this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCausale.Location = new System.Drawing.Point(8, 16);
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(304, 20);
            this.txtCausale.TabIndex = 2;
            this.txtCausale.Tag = "assetloadmotive.description";
            // 
            // grpCred
            // 
            this.grpCred.Controls.Add(this.txtCredDeb);
            this.grpCred.Location = new System.Drawing.Point(8, 96);
            this.grpCred.Name = "grpCred";
            this.grpCred.Size = new System.Drawing.Size(320, 48);
            this.grpCred.TabIndex = 4;
            this.grpCred.TabStop = false;
            this.grpCred.Tag = "AutoChoose.txtCredDeb.default";
            this.grpCred.Text = "Cedente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(304, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?assetloadview.registry";
            // 
            // grpCaricoBene
            // 
            this.grpCaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCaricoBene.Controls.Add(this.btnDeselBene);
            this.grpCaricoBene.Controls.Add(this.btnAddBene);
            this.grpCaricoBene.Controls.Add(this.dgrCaricoBene);
            this.grpCaricoBene.Location = new System.Drawing.Point(8, 264);
            this.grpCaricoBene.Name = "grpCaricoBene";
            this.grpCaricoBene.Size = new System.Drawing.Size(728, 175);
            this.grpCaricoBene.TabIndex = 6;
            this.grpCaricoBene.TabStop = false;
            this.grpCaricoBene.Text = "Carico cespiti e aumenti valore";
            // 
            // btnDeselBene
            // 
            this.btnDeselBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselBene.Location = new System.Drawing.Point(632, 80);
            this.btnDeselBene.Name = "btnDeselBene";
            this.btnDeselBene.Size = new System.Drawing.Size(88, 32);
            this.btnDeselBene.TabIndex = 74;
            this.btnDeselBene.Text = "Annulla selezione";
            this.btnDeselBene.Click += new System.EventHandler(this.btnDeselBene_Click);
            // 
            // btnAddBene
            // 
            this.btnAddBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBene.Enabled = false;
            this.btnAddBene.Location = new System.Drawing.Point(632, 40);
            this.btnAddBene.Name = "btnAddBene";
            this.btnAddBene.Size = new System.Drawing.Size(88, 32);
            this.btnAddBene.TabIndex = 73;
            this.btnAddBene.Text = "Seleziona tutto";
            this.btnAddBene.Click += new System.EventHandler(this.btnAddBene_Click);
            // 
            // dgrCaricoBene
            // 
            this.dgrCaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrCaricoBene.CaptionVisible = false;
            this.dgrCaricoBene.DataMember = "";
            this.dgrCaricoBene.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrCaricoBene.Location = new System.Drawing.Point(8, 16);
            this.dgrCaricoBene.Name = "dgrCaricoBene";
            this.dgrCaricoBene.Size = new System.Drawing.Size(616, 151);
            this.dgrCaricoBene.TabIndex = 3;
            this.dgrCaricoBene.TabStop = false;
            this.dgrCaricoBene.Tag = "assetacquireview.buonoautomatico";
            this.dgrCaricoBene.Paint += new System.Windows.Forms.PaintEventHandler(this.dgrCaricoBene_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(640, 96);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(88, 24);
            this.btnChiudi.TabIndex = 2;
            this.btnChiudi.Text = "Termina";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnInizia
            // 
            this.btnInizia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInizia.Location = new System.Drawing.Point(632, 16);
            this.btnInizia.Name = "btnInizia";
            this.btnInizia.Size = new System.Drawing.Size(88, 24);
            this.btnInizia.TabIndex = 0;
            this.btnInizia.Text = "Inizia Ricerca";
            this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
            // 
            // grpIncludi
            // 
            this.grpIncludi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpIncludi.Controls.Add(this.button4);
            this.grpIncludi.Controls.Add(this.cboTipo);
            this.grpIncludi.Controls.Add(this.btnInizia);
            this.grpIncludi.Location = new System.Drawing.Point(8, 0);
            this.grpIncludi.Name = "grpIncludi";
            this.grpIncludi.Size = new System.Drawing.Size(728, 48);
            this.grpIncludi.TabIndex = 83;
            this.grpIncludi.TabStop = false;
            // 
            // btnGeneraTutto
            // 
            this.btnGeneraTutto.Enabled = false;
            this.btnGeneraTutto.Location = new System.Drawing.Point(8, 56);
            this.btnGeneraTutto.Name = "btnGeneraTutto";
            this.btnGeneraTutto.Size = new System.Drawing.Size(88, 24);
            this.btnGeneraTutto.TabIndex = 3;
            this.btnGeneraTutto.Text = "Si tutti";
            this.btnGeneraTutto.Click += new System.EventHandler(this.btnGeneraTutto_Click);
            // 
            // btnSi
            // 
            this.btnSi.Enabled = false;
            this.btnSi.Location = new System.Drawing.Point(8, 16);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(88, 24);
            this.btnSi.TabIndex = 85;
            this.btnSi.Text = "Si";
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDataContabile);
            this.groupBox2.Location = new System.Drawing.Point(8, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(104, 48);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "";
            this.groupBox2.Text = "Data contabile";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(8, 16);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(88, 20);
            this.txtDataContabile.TabIndex = 87;
            this.txtDataContabile.Tag = "assetload.adate";
            // 
            // btnSuccessivo
            // 
            this.btnSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSuccessivo.Enabled = false;
            this.btnSuccessivo.Location = new System.Drawing.Point(640, 56);
            this.btnSuccessivo.Name = "btnSuccessivo";
            this.btnSuccessivo.Size = new System.Drawing.Size(88, 24);
            this.btnSuccessivo.TabIndex = 88;
            this.btnSuccessivo.Text = "Prossimo";
            this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
            // 
            // Tip
            // 
            this.Tip.ShowAlways = true;
            // 
            // grpRatifica
            // 
            this.grpRatifica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRatifica.Controls.Add(this.btnScollegaMov);
            this.grpRatifica.Controls.Add(this.gridRatifica);
            this.grpRatifica.Controls.Add(this.label1);
            this.grpRatifica.Controls.Add(this.txtDataRatifica);
            this.grpRatifica.Controls.Add(this.btnCollegaMov);
            this.grpRatifica.Location = new System.Drawing.Point(336, 56);
            this.grpRatifica.Name = "grpRatifica";
            this.grpRatifica.Size = new System.Drawing.Size(296, 136);
            this.grpRatifica.TabIndex = 90;
            this.grpRatifica.TabStop = false;
            this.grpRatifica.Text = "Ratifica";
            // 
            // btnScollegaMov
            // 
            this.btnScollegaMov.Location = new System.Drawing.Point(216, 14);
            this.btnScollegaMov.Name = "btnScollegaMov";
            this.btnScollegaMov.Size = new System.Drawing.Size(64, 24);
            this.btnScollegaMov.TabIndex = 181;
            this.btnScollegaMov.Tag = "";
            this.btnScollegaMov.Text = "Scollega";
            this.btnScollegaMov.Click += new System.EventHandler(this.btnScollegaMov_Click);
            // 
            // gridRatifica
            // 
            this.gridRatifica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRatifica.CaptionVisible = false;
            this.gridRatifica.DataMember = "";
            this.gridRatifica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridRatifica.Location = new System.Drawing.Point(8, 48);
            this.gridRatifica.Name = "gridRatifica";
            this.gridRatifica.Size = new System.Drawing.Size(280, 80);
            this.gridRatifica.TabIndex = 180;
            this.gridRatifica.Tag = "assetloadexpense.buonodicarico";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 179;
            this.label1.Text = "Data";
            // 
            // txtDataRatifica
            // 
            this.txtDataRatifica.Location = new System.Drawing.Point(40, 16);
            this.txtDataRatifica.Name = "txtDataRatifica";
            this.txtDataRatifica.ReadOnly = true;
            this.txtDataRatifica.Size = new System.Drawing.Size(80, 20);
            this.txtDataRatifica.TabIndex = 178;
            this.txtDataRatifica.Tag = "assetload.ratificationdate";
            this.txtDataRatifica.Leave += new System.EventHandler(this.txtDataRatifica_Leave);
            // 
            // btnCollegaMov
            // 
            this.btnCollegaMov.Location = new System.Drawing.Point(128, 14);
            this.btnCollegaMov.Name = "btnCollegaMov";
            this.btnCollegaMov.Size = new System.Drawing.Size(80, 24);
            this.btnCollegaMov.TabIndex = 177;
            this.btnCollegaMov.Tag = "";
            this.btnCollegaMov.Text = "Collega mov.";
            this.btnCollegaMov.Click += new System.EventHandler(this.btnCollegaMov_Click);
            // 
            // textBoxDescrizione
            // 
            this.textBoxDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescrizione.Location = new System.Drawing.Point(336, 208);
            this.textBoxDescrizione.Multiline = true;
            this.textBoxDescrizione.Name = "textBoxDescrizione";
            this.textBoxDescrizione.Size = new System.Drawing.Size(288, 56);
            this.textBoxDescrizione.TabIndex = 92;
            this.textBoxDescrizione.Tag = "assetload.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(336, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 91;
            this.label4.Text = "Descrizione";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDocumento
            // 
            this.textBoxDocumento.Location = new System.Drawing.Point(56, 40);
            this.textBoxDocumento.Name = "textBoxDocumento";
            this.textBoxDocumento.Size = new System.Drawing.Size(88, 20);
            this.textBoxDocumento.TabIndex = 96;
            this.textBoxDocumento.Tag = "assetload.doc";
            // 
            // textBoxDataDocumento
            // 
            this.textBoxDataDocumento.Location = new System.Drawing.Point(56, 16);
            this.textBoxDataDocumento.Name = "textBoxDataDocumento";
            this.textBoxDataDocumento.Size = new System.Drawing.Size(88, 20);
            this.textBoxDataDocumento.TabIndex = 94;
            this.textBoxDataDocumento.Tag = "assetload.docdate";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 97;
            this.label7.Text = "Data";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(64, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(88, 20);
            this.textBox4.TabIndex = 98;
            this.textBox4.Tag = "assetload.enactmentdate";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 99;
            this.label8.Text = "Numero";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProvvedimento
            // 
            this.textBoxProvvedimento.Location = new System.Drawing.Point(64, 40);
            this.textBoxProvvedimento.Name = "textBoxProvvedimento";
            this.textBoxProvvedimento.Size = new System.Drawing.Size(88, 20);
            this.textBoxProvvedimento.TabIndex = 100;
            this.textBoxProvvedimento.Tag = "assetload.enactment";
            // 
            // grpElabora
            // 
            this.grpElabora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpElabora.Controls.Add(this.btnNo);
            this.grpElabora.Controls.Add(this.btnGeneraTutto);
            this.grpElabora.Controls.Add(this.btnSi);
            this.grpElabora.Location = new System.Drawing.Point(632, 136);
            this.grpElabora.Name = "grpElabora";
            this.grpElabora.Size = new System.Drawing.Size(104, 128);
            this.grpElabora.TabIndex = 0;
            this.grpElabora.TabStop = false;
            this.grpElabora.Text = "Conferma";
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(8, 96);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(88, 24);
            this.btnNo.TabIndex = 86;
            this.btnNo.Text = "No";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtEsercizio);
            this.groupBox3.Location = new System.Drawing.Point(112, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 48);
            this.groupBox3.TabIndex = 101;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Esercizio";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxDataDocumento);
            this.groupBox4.Controls.Add(this.textBoxDocumento);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(8, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(152, 72);
            this.groupBox4.TabIndex = 102;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Documento";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 95;
            this.label3.Text = "Numero";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxProvvedimento);
            this.groupBox6.Controls.Add(this.textBox4);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Location = new System.Drawing.Point(168, 192);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(160, 72);
            this.groupBox6.TabIndex = 103;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Provvedimento";
            // 
            // Frm_assetload_generazioneautomatica
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 445);
            this.Controls.Add(this.grpRatifica);
            this.Controls.Add(this.textBoxDescrizione);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpIncludi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSuccessivo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpElabora);
            this.Controls.Add(this.grpCaricoBene);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpCausale);
            this.Controls.Add(this.grpCred);
            this.Controls.Add(this.btnChiudi);
            this.Name = "Frm_assetload_generazioneautomatica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            this.grpCred.ResumeLayout(false);
            this.grpCred.PerformLayout();
            this.grpCaricoBene.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrCaricoBene)).EndInit();
            this.grpIncludi.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpRatifica.ResumeLayout(false);
            this.grpRatifica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRatifica)).EndInit();
            this.grpElabora.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;

		public void MetaData_AfterLink() {
			HelpForm.SetAllowMultiSelection(DS.assetacquireview, true);
			//HelpForm.SetAllowMultiSelection(DS.assetaccretionview, true);
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.config,filter,null,false);
			GetData.CacheTable(DS.expensephase,null,"nphase",true);
            //GetData.CacheTable(DS.assetloadmotive, null, "description", true);
			Mspesaview=MetaData.GetMetaData(this,"historypaymentview");
            tInventoryTree = DataAccess.CreateTableByName(Meta.Conn, "inventorytree", "*");

			//Tooltip
			Tip.SetToolTip(btnInizia,"Cliccare qui per far partire la generazione automatica");
			Tip.SetToolTip(grpIncludi,"Selezionare una delle voci per filtrare la generazione completa");
//			Tip.SetToolTip(rdoAll,"Selezionare questa voce se si vogliono tutti i tipi di carico");
//			Tip.SetToolTip(rdoBene,"Selezionare questa voce se si vogliono solo i carichi cespiti");
//			Tip.SetToolTip(rdoParte,"Selezionare questa voce se si vogliono solo gli aumenti di valore");
			Tip.SetToolTip(btnGeneraTutto,"Cliccare qui per avviare in qualsiasi momento la generazione automatica");
			Tip.SetToolTip(btnSi,"Cliccare qui per collegare sia i carichi cespiti che gli aumenti di valore al buono");
			Tip.SetToolTip(btnAddBene,"Cliccare qui per collegare solo i carichi cespiti al buono");
			//Tip.SetToolTip(btnAddParte,"Cliccare qui per collegare solo gli aumenti di valore");
			Tip.SetToolTip(btnSuccessivo,"Cliccare qui per passare al buono successivo");
            EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "assetload");
        }

		public void MetaData_AfterClear()
		{
			if (Meta.GointToInsertMode) return;
			Text="Generazione automatica";
		}

		public void MetaData_AfterActivation() {
            codicefase = Meta.GetSys("maxexpensephase");
            if (DS.config.Rows.Count == 0) {
				MessageBox.Show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente!", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Warning=true;
				return;
			}
			DataRow r=DS.Tables["config"].Rows[0];
            string flagnumerazione = r["asset_flagnumbering"].ToString().ToUpper();
			if (flagnumerazione=="" || flagnumerazione=="N") {
				MessageBox.Show("Non è stato definito il tipo di numerazione per la configurazione "+
					"del PATRIMONIO per l'esercizio corrente", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Warning=true;
				return;
			}
            byte assetload_flag = (byte)r["assetload_flag"];
            flagcreddeb = (assetload_flag & 1) == 1;
            flagcausale = (assetload_flag & 2) == 2;
			if (!flagcausale && !flagcreddeb) {
				MessageBox.Show("Non è stata definita la configurazione dei buoni "+
					"di carico / scarico per l'esercizio corrente.\rI buoni eventualmente "+
					"generati verranno creati senza creditore e causale.\r\r"+
					@"Voce di menu: Configurazione\Operazioni inventariabili\Configurazione",
					"Attenzione",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			AbilitaBottoni(false);
			AbilitaBottoniOperazioni(false);
			Meta.MarkTableAsNotEntityChild(DS.assetacquireview);
			//Meta.MarkTableAsNotEntityChild(DS.assetaccretionview);
		}
		
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "assetloadkind") {
				CodiceTipoBuono=(R==null?null:R["idassetloadkind"]);
				//flag_bene=(R==null || R["flagassetacquire"].ToString()=="S");
				//flag_aumento=(R==null || R["flagassetaccretion"].ToString()=="S");
//				rdoBene.Enabled=true; //flag_bene;
//				rdoParte.Enabled=true; //flag_aumento;
//				//abilitato se è abilitata almeno una voce
//				rdoAll.Enabled=true; //(flag_bene || flag_aumento);
			}
		}
        //string idrelated = "";
        //bool fromDelete = false;
        public void MetaData_BeforePost(){
            EPM.beforePost();
        }

        public void MetaData_AfterPost(){
            EPM.afterPost();
        }

		void visualizzaMessaggio()
		{
			string messaggio = "Non ci sono carichi ";
			messaggio += "cespiti e/o aumenti valore da elaborare";
//			if (rdoAll.Checked)
//			{
//				messaggio += "cespiti e/o aumenti valore da elaborare";
//			}
//			else 
//			{
//				if (rdoBene.Checked)
//				{
//					messaggio += "cespiti da elaborare";
//				}
//				if (rdoParte.Checked)
//				{
//					messaggio += "aumenti valore da elaborare";
//				}
//			}
			MessageBox.Show(messaggio);
		}

		/// <summary>
		/// Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
		/// </summary>
		private void CollegaRigheADocumento(bool quiet){
			if ((TempTable==null) || (TempTable.Rows.Count==0)) {
				if (!quiet) visualizzaMessaggio();
					//MessageBox.Show("Non ci sono carichi cespiti e/o parti da elaborare");
				AbilitaBottoniOperazioni(false);
				AbilitaBottoni(false);
				//cboTipo.Enabled=true;
				grpIncludi.Enabled = true;
				//btnInizia.Enabled=true;
				return;
			}

            string fCodTipoBuono = QHC.CmpEq("idassetloadkind", cboTipo.SelectedValue);
			DataRow [] codiceinventarioRow = DS.assetloadkind.Select(fCodTipoBuono);
			object codInventario = DBNull.Value;
			if ((codiceinventarioRow != null) && (codiceinventarioRow.Length > 0)) {
				codInventario = codiceinventarioRow[0]["idinventory"] ;
			}



			string condizioniaggiuntive="";

			if (TempTable.Columns["xxx"]!=null){
                // Considera o meno il filtro su Inventario in base a flagmixed di inventory
                condizioniaggiuntive += GetInventoryFilter(QHS,codInventario);
			}

			if (TempTable.TableName != "dummy"){
				DataRow CurrRow = TempTable.Rows[0];				
				if (flagcreddeb){
					object codicecreddeb = CurrRow["idreg"];
					MetaData.SetDefault(DS.assetload,"idreg",codicecreddeb);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive , QHS.CmpEq("idreg",codicecreddeb));
				}
				if (flagcausale){
					object codicecausale = CurrRow["idmot"];
					MetaData.SetDefault(DS.assetload,"idmot",codicecausale);
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idmot", codicecausale));
				}
			}
			else {
				MetaData.SetDefault(DS.assetload,"idreg",DBNull.Value);
				MetaData.SetDefault(DS.assetload,"idmot",DBNull.Value);
			}

			DS.assetacquireview.Clear();
			//DS.assetaccretionview.Clear();
			MetaData.SetDefault(DS.assetload,"idassetloadkind",CodiceTipoBuono);
			MetaData.SetDefault(DS.assetload,"ratificationdate",m_DataRatifica);
			Meta.EditNew();
			string sort="idassetloadkind ASC, yassetload ASC, nassetload ASC";
            string filter = QHS.AppAnd(QHS.CmpEq("flagload", "S"), QHS.IsNull("idassetload"),
                    condizioniaggiuntive);

			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.assetacquireview, sort,filter,null,false);

//			if (rdoAll.Checked || rdoBene.Checked) 
//			{
//				DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.assetacquireview, sort,filter,null,false);
//			}
//			if (rdoAll.Checked || rdoParte.Checked) 
//			{
//				DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.assetaccretionview, sort,filter,null,false);
//			}

			MetaData.FreshForm(this, false);
			int max=DS.assetacquireview.Rows.Count;
			for (int i=0; i<max; i++){
				dgrCaricoBene.Select(i);
			}
//			max=DS.assetaccretionview.Rows.Count;
//			for (int i=0; i<max; i++){
//				dgrCaricoParte.Select(i);
//			}
			AbilitaBottoniOperazioni(false); //true
			CheckBottoniBene();
			//CheckBottoniParte();
			CheckBottoneTutto();
			//ControlloRatifica();
//			if (TempTable.TableName=="dummy") TempTable=null;
		}

		private string GetTempQuery(string tipo) {
			string ParteSelect, ParteFrom, ParteWhere;
			string SelectClause, FromClause, WhereClause;

            string fCodTipoBuono = QHC.CmpEq("idassetloadkind", cboTipo.SelectedValue);
			DataRow [] codiceinventarioRow = DS.assetloadkind.Select(fCodTipoBuono);
			object codInventario = DBNull.Value;
			if ((codiceinventarioRow != null) && (codiceinventarioRow.Length > 0))
			{
				codInventario = codiceinventarioRow[0]["idinventory"];
			}
			
			ParteSelect="'tipobuono' as xxx";
            ParteWhere = QHS.AppAnd(QHS.CmpEq("flagload", "S"), QHS.IsNull("idassetload"));

            if (codInventario != DBNull.Value)
            {
                // considero se devo filtrare per inventario 
                ParteWhere = QHS.AppAnd(ParteWhere,GetInventoryFilter(QHS,codInventario));
                string filterInv = QHS.CmpEq("idinventory", codInventario);
                int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", filterInv, "flag"));
                bool flagMixed = ((flag & 1) != 0);
                if (!flagMixed) {
                    ParteSelect += ", inventory";
                }
            }
            //ParteWhere += ")";
			SelectClause="SELECT ";
			FromClause=" FROM ";
			WhereClause=" WHERE ";
			ParteFrom="";

			ParteFrom="assetacquireview";
//			switch(tipo) {
//				case "B":ParteFrom="assetacquireview";break;
//				case "P":ParteFrom="assetaccretionview";break;
//			}

			if (flagcreddeb) {
				ParteSelect  = MyAppend(ParteSelect, "idreg");
			}
			if (flagcausale){
				ParteSelect  = MyAppend(ParteSelect, "idmot");
			}
			/*if ((flagcreddeb!="S")&&(flagcausale!="S")) {
				ParteSelect  = MyAppend(ParteSelect, "idreg");
				ParteSelect  = MyAppend(ParteSelect, "idmot");
			}*/

            string lista = SelectClause + ParteSelect + FromClause + ParteFrom +
                    WhereClause + ParteWhere;
            return lista;
		}

        private string GetInventoryFilter(QueryHelper QH, object codInventario)
        {
            string filter = "";
            string filterInv = QH.CmpEq("idinventory", codInventario);
            string SQLfilterInv = QHS.CmpEq("idinventory", codInventario);

            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "flag"));
            bool flagMixed = ((flag & 1) != 0);
            if (flagMixed)
             {
                 
                 // Se il flag vale S, non devo filtrare i carichi sull'inventario ma solo sull'ente Inventariale
                object inventoryAgency = Meta.Conn.DO_READ_VALUE("inventory", SQLfilterInv, "idinventoryagency");
                 string filterEnte = QHS.CmpEq("idinventoryagency", inventoryAgency);
                 DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);
                 if (ListInvEnte.Rows.Count > 0)
                 {
                     if (ListInvEnte.Rows.Count != 0) {
                         filter = QH.FieldIn("idinventory", ListInvEnte.Select());
                     }
                     else
                     {
                         filter =filterInv;
                     }
                 }
                 else
                 {
                    filter = filterInv;
                 }
             }
             else
             {
                
                filter =  filterInv;
             }
             return filter;
		    }

		private void FillTempTable(){
			string query = "";
			query=GetTempQuery("B"); //+" UNION "+GetTempQuery("P");

//			if (rdoAll.Checked)
//			{
//				query=GetTempQuery("B")+" UNION "+GetTempQuery("P");
//			}
//			else
//			{
//				if (rdoBene.Checked)
//				{
//					query = GetTempQuery("B");
//				}
//				if (rdoParte.Checked)
//				{
//					query = GetTempQuery("P");
//				}
//			}

			string GroupByClause=" GROUP BY ";
			string OrderByClause=" ORDER BY ";
            string GroupBy = "";
            string OrderBy = "";
            string ParteGroupBy = " ";
            if (query.Contains(", inventory"))
            {
                ParteGroupBy += "inventory";
            }
			string ParteOrderBy="";
			bool config=false;
			if (flagcreddeb) {
				ParteGroupBy = MyAppend(ParteGroupBy, "idreg");
				ParteOrderBy = MyAppend(ParteOrderBy, "idreg ASC");
				config=true;
			}
			if (flagcausale) {
				ParteGroupBy = MyAppend(ParteGroupBy, "idmot");
				ParteOrderBy = MyAppend(ParteOrderBy, "idmot ASC");
				config=true;
			}

            if (ParteGroupBy.Trim() != "")
            {
                GroupBy = GroupByClause + ParteGroupBy;
            }

            if (ParteOrderBy.Trim() != "")
            {
                OrderBy = OrderByClause + ParteOrderBy;
            }
            
     
			if (config){
                string list = query + GroupBy + OrderBy;
				TempTable = Conn.SQLRunner(list,true);
			}
			else {			
				DataTable Temp  = Conn.SQLRunner(query+GroupBy,true);
				//DataTable Temp = Conn.SQLRunner(query);
				if ((Temp!=null)&&(Temp.Rows.Count>0)){
					TempTable = new DataTable("dummy");	
					DataRow R=TempTable.NewRow();
					TempTable.Rows.Add(R);
				}
				else {
					TempTable=null;
				}
			}
		}

		private string MyAppend(string source, string toappend){
			if (source.Trim()=="") return toappend;
			return source + ", " +toappend+" ";
		}
		
		private DataRow GetDetailRow(DataGrid G, int index, string key){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter=key+"='"+G[index,0].ToString()+"'";
			DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];
		}

		private bool CollegaTipoDoc(DataGrid G, int count, string key) {
            bool something = false;
			DataRow R=DS.assetload.Rows[0];
			object chiaveBuono=R["idassetload"];
			for (int i=0; i<count; i++) {
				if (G.IsSelected(i)) {
					DataRow CurrRow=GetDetailRow(G,i,key);
                    CurrRow["idassetload"] = chiaveBuono;
                    something = true;
				}
			}
            return something;
		}

		/// <summary>
		/// Collega documenti
		/// </summary>
		/// <param name="link">"1"=caricobene,"2"=caricoparte,"3"=entrambi</param>
		private bool AccettaDocumento(/*string link*/){
			bool success=true;
			int rowsBene=DS.assetacquireview.Rows.Count;
			//int rowsParte=DS.assetaccretionview.Rows.Count;
			//if (flag_bene) 
			if (!CollegaTipoDoc(dgrCaricoBene, rowsBene, "nassetacquire")) {
                return false;
            }
			//if (flag_aumento) CollegaTipoDoc(dgrCaricoParte, rowsParte, "nassetaccretion");
			//					break;
//			}

			MetaData.DoMainCommand(this, "mainsave");
			if (!DS.HasChanges() && (TempTable!=null))
			{
				if (TempTable.Rows.Count>0) TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
				success=true;
			}
			else
			{
				success=false;
				return success;
			}
			AbilitaBottoni(false);
			return success;
			//btnGeneraTutto.Enabled=(TempTable!=null && TempTable.Rows.Count>0);
		}

		private void btnInizia_Click(object sender, System.EventArgs e) {
			if (CodiceTipoBuono==null || CodiceTipoBuono.ToString()=="") {
				MessageBox.Show("Selezionare il tipo buono di carico","Attenzione",
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			Cursor = Cursors.WaitCursor;
			txtDataContabile.ReadOnly=false;
			txtDataRatifica.ReadOnly=false;
			grpIncludi.Enabled = false;
			//btnInizia.Enabled=false;
			if (Warning) 
			{
				Cursor = null;
				return;
			}
			FillTempTable();
			CollegaRigheADocumento(false);
			Cursor = null;
		}

		private void btnSuccessivo_Click(object sender, System.EventArgs e) {
			abilitaDisabilitaGenerazione(true);
			VaiAvanti();

			CollegaRigheADocumento(false);
			if ((TempTable==null) || ((TempTable!=null) && (TempTable.Rows.Count==0))) Meta.DontWarnOnInsertCancel=true;
		}

		private void btnAddBene_Click(object sender, System.EventArgs e) {
            //			AccettaDocumento("1");
            if (selezionaTutteLeRigheDiUnGrid(dgrCaricoBene)) {
                AbilitaBottoniCreaBuono(true);
            }
		}

//		private void btnAddParte_Click(object sender, System.EventArgs e) {
////			AccettaDocumento("2");
//			selezionaTutteLeRigheDiUnGrid(dgrCaricoParte);
//			AbilitaBottoniCreaBuono(true);
//		}

		private void btnSi_Click(object sender, System.EventArgs e) {
			bool res=AccettaDocumento();	//<-
			if (res) AbilitaBottoniOperazioni(true);
		}

		private void VaiAvanti() {
			if ((TempTable!=null) && (TempTable.Rows.Count > 0) && (DS.HasChanges())) {
				if (DS.assetacquireview.Rows.Count>0) DS.assetacquireview.AcceptChanges();
				//if (DS.assetaccretionview.Rows.Count>0) DS.assetaccretionview.AcceptChanges();
				TempTable.Rows.RemoveAt(0);
				TempTable.AcceptChanges();
			}
		}

		private void AbilitaBottoniOperazioni(bool enable) {
			btnSuccessivo.Enabled=enable;
			//btnGeneraTutto.Enabled=enable && (flag_bene || flag_aumento);
		}

		private void CheckBottoniBene() {
			DataSet DSbene = (DataSet)dgrCaricoBene.DataSource;
			DataTable T=(DataTable)DSbene.Tables[dgrCaricoBene.DataMember.ToString()];
			DataRow[] rows=T.Select(null,null,DataViewRowState.CurrentRows);
			AbilitaBottoniBene(rows.Length>0);
		}

		private void AbilitaBottoniBene(bool enable) {
			btnAddBene.Enabled=(enable && flag_bene);
			btnDeselBene.Enabled=(enable && flag_bene);
		}

//		private void CheckBottoniParte() {
//			DataSet DSparte = (DataSet)dgrCaricoParte.DataSource;
//			DataTable T=(DataTable)DSparte.Tables[dgrCaricoParte.DataMember.ToString()];
//			DataRow[] rows=T.Select(null,null,DataViewRowState.CurrentRows);
//			AbilitaBottoniParte(rows.Length>0);
//		}
//
//		private void AbilitaBottoniParte(bool enable) {
//			btnAddParte.Enabled=(enable && flag_aumento);
//			btnDeselParte.Enabled=(enable && flag_aumento);
//		}

		private void AbilitaBottoni(bool enable) {
			AbilitaBottoniBene(enable);
//			AbilitaBottoniParte(enable);
			btnSi.Enabled=enable && (flag_bene || flag_aumento);
			btnNo.Enabled=enable && (flag_bene || flag_aumento);
			btnGeneraTutto.Enabled = enable && (flag_bene || flag_aumento);
		}

		private void CheckBottoneTutto() {
			//il controllo dei flag si trova già nell'enabled dei singoli button
			btnSi.Enabled=(btnAddBene.Enabled );
			btnNo.Enabled=(btnAddBene.Enabled );
			btnGeneraTutto.Enabled=(btnAddBene.Enabled );
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.DialogResult=DialogResult.Cancel;
			this.Close();
		}

		private void btnGeneraTutto_Click(object sender, System.EventArgs e) {
/*			string link="";
			if (rdoAll.Checked) 
				link="3";
			else {
				if (rdoBene.Checked) 
					link="1";
				else
					link="2";
			}
*/			
			Meta.GetFormData(true);
			foreach (string c in new string[] {"description","docdate","enactmentdate","doc","enactment"}) {
				if (DS.assetload.Rows[0][c] != DBNull.Value) 
				{
					MetaData.SetDefault(DS.assetload, c, DS.assetload.Rows[0][c]);
				}
			}
			
			while ((TempTable!=null) && (TempTable.Rows.Count>0))
			{
				bool esito = AccettaDocumento();
				if (!esito) 	break;
				CollegaRigheADocumento(true);
			}
			AbilitaBottoni(false);
			AbilitaBottoniOperazioni(false);
			Meta.DontWarnOnInsertCancel=true;
		}

		/*private void AbilitaRatificaCampo(bool enable) {
			txtDataRatifica.ReadOnly=!enable;
		}
		private void AbilitaRatificaGrid(bool enable) {
			btnCollegaMov.Enabled=enable;
			btnScollegaMov.Enabled=enable;
			gridRatifica.Enabled=enable;
		}
		private void AbilitaRatifica(bool enable) {
			AbilitaRatificaCampo(enable);
			AbilitaRatificaGrid(enable);
		}*/
		private void ParseDate(TextBox T) {
			if (!T.Enabled) return;
			if (T.ReadOnly) return;
			if (T.Text=="") {
				m_DataRatifica=DBNull.Value;
				return;
			}
			string tag=HelpForm.GetStandardTag(T.Tag);
			tag = tag+".d";
			string hhsep = CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator;
			string ppsep = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
			string S = T.Text+hhsep+"0"+ppsep+"0";
			int len = S.Length;
			object valore = DBNull.Value;
			while (len>0){
				try {
					valore =HelpForm.GetObjectFromString(typeof(DateTime), S, tag);
					if ((valore!=null)&&(valore!=DBNull.Value)) break;
				}
				catch {
				}
				len=len-1;
				S= S.Substring(0, len);
			}
			T.Text=HelpForm.StringValue(valore, tag);
			m_DataRatifica=valore;
		}

		/*private void ControlloRatifica() {
			if (Meta.IsEmpty) return;
			DataRow[] rows=DS.assetloadexpense.Select(null,null,DataViewRowState.CurrentRows);
			ParseDate(txtDataRatifica);			
			string dataratifica=txtDataRatifica.Text;
			if (dataratifica=="" && rows.Length==0) {
				AbilitaRatifica(true);
			}
			else {
				if (dataratifica!="") {
					AbilitaRatificaCampo(true);
					AbilitaRatificaGrid(false);
				}
				if (rows.Length>0) {
					AbilitaRatificaCampo(false);
					AbilitaRatificaGrid(true);
				}
			}
		}*/

		private void txtDataRatifica_Leave(object sender, System.EventArgs e) {
			//ControlloRatifica();
            ParseDate(txtDataRatifica);		
		}

		private string GetMovimentoFilter() {
			string codicecreddeb = DS.assetload.Rows[0]["idreg"].ToString();
			string eserccorrente=Meta.GetSys("esercizio").ToString();

			string MyFilter="";
            if (txtEsercizio.Text.Trim() != "")
                MyFilter += " (DATEPART(year,competencydate) =" + QHS.quote(CfgFn.GetNoNullInt32(txtEsercizio.Text)) + ")";

			if (flagcreddeb){
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
            }

			if (DS.assetloadexpense.Rows.Count>0) {
				foreach (DataRow R in DS.assetloadexpense.Rows) {
					if (R.RowState==DataRowState.Deleted) continue;
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpNe("idexp",QHS.quote(R["idexp"])));
				}
			}
			return MyFilter;
		}

		private void ImpostaValoriDaSpesa(DataTable T, DataRow R) {
			MetaData.SetDefault(T,"idexp",R["idexp"]);
			MetaData.SetDefault(T,"!ymov",R["ymov"]);
			MetaData.SetDefault(T,"!nmov",R["nmov"]);
			MetaData.SetDefault(T,"!expensedescription",R["description"]);
			MetaData.SetDefault(T,"!expensedoc",R["doc"]);
			MetaData.SetDefault(T,"!amount",R["amount"]);
		}

        private void ImpostaDataRatifica(DataRow R)
        {
            Meta.GetFormData(true);
            // Calcola la data di competenza per il pagamento selezionato
            object compDate = R["competencydate"];
            if (compDate == DBNull.Value) return;
            string tag = HelpForm.GetStandardTag(txtDataRatifica.Tag);
            if (DS.assetload.Rows[0]["ratificationdate"] == DBNull.Value)
            {
                DS.assetload.Rows[0]["ratificationdate"] = compDate;
                txtDataRatifica.Text = HelpForm.StringValue(compDate, tag);
            }
            else
            {
                if (!(DS.assetload.Rows[0]["ratificationdate"].Equals(compDate)))
                {
                    if (MessageBox.Show("Sostituire la data ratifica con la data di competenza " + HelpForm.StringValue(compDate, tag) +
                                        " del movimento selezionato?",
                    "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DS.assetload.Rows[0]["ratificationdate"] = compDate;
                        txtDataRatifica.Text = HelpForm.StringValue(compDate, tag);
                    }
                }
            }
            MetaData.FreshForm(this,false);
        }
		private void btnCollegaMov_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Mspesaview.FilterLocked=true;
            Mspesaview.DS = DS.Clone() ;
			DataRow R=Mspesaview.SelectOne("default",GetMovimentoFilter(),null,null);
			if (R==null) return;
			MetaData M=MetaData.GetMetaData(this,"assetloadexpense");
			ImpostaValoriDaSpesa(DS.assetloadexpense, R);
            ImpostaDataRatifica(R);
			M.SetDefaults(DS.assetloadexpense);
			M.Get_New_Row(DS.assetload.Rows[0],DS.assetloadexpense);
			//ControlloRatifica();
		}

		private void btnScollegaMov_Click(object sender, System.EventArgs e) {
			DataRow R;
			DataTable T;
			if (!Meta.myHelpForm.GetCurrentRow(gridRatifica, out T, out R)) return;
			if (R==null) return;
			R.Delete();
			//ControlloRatifica();
		}

		private bool selezionaTutteLeRigheDiUnGrid(DataGrid grid) 
		{
            bool something = false;
			string dataMember = grid.DataMember;
			CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
			if ((cm == null)||!(cm.List is DataView)) return false;
			for (int i=0; i<cm.Count; i++) 
			{
				grid.Select(i);
                something = true;
			}
            return something;
		}

		private void deselezionaTutteLeRigheDiUnGrid(DataGrid grid) 
		{
			string dataMember = grid.DataMember;
			CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
			if ((cm == null)||!(cm.List is DataView)) return;
			for (int i=0; i<cm.Count; i++) 
			{
				grid.UnSelect(i);
			}
		}

		private void abilitaDisabilitaGenerazione(bool enabled) 
		{
			grpCaricoBene.Enabled = enabled;
			//grpCaricoParte.Enabled = enabled;
			btnSi.Enabled = enabled;
			btnGeneraTutto.Enabled = enabled;
			btnNo.Enabled = enabled;
		}

		private void btnNo_Click(object sender, System.EventArgs e)
		{
			abilitaDisabilitaGenerazione(false);
			deselezionaTutteLeRigheDiUnGrid(dgrCaricoBene);
			//deselezionaTutteLeRigheDiUnGrid(dgrCaricoParte);
			AbilitaBottoniOperazioni(true);
		}

		private void btnDeselBene_Click(object sender, System.EventArgs e)
		{
			deselezionaTutteLeRigheDiUnGrid(dgrCaricoBene);
			AbilitaBottoniCreaBuono(false);
//			int i = contaRigheSelezionate(dgrCaricoParte);
//			if (i == 0)
//			{
//				AbilitaBottoniCreaBuono(false);
//			}
		}

//		private void btnDeselParte_Click(object sender, System.EventArgs e)
//		{
//			deselezionaTutteLeRigheDiUnGrid(dgrCaricoParte);
//			int i = contaRigheSelezionate(dgrCaricoBene);
//			if (i == 0)
//			{
//				AbilitaBottoniCreaBuono(false);
//			}
//		}

		private void AbilitaBottoniCreaBuono(bool enable)
		{
			btnSi.Enabled = enable;
			btnGeneraTutto.Enabled = enable;
		}

		private int contaRigheSelezionate(DataGrid grid)
		{
			string dataMember = grid.DataMember;
			int contarighe = 0;
			CurrencyManager cm = grid.BindingContext[DS, dataMember] as CurrencyManager;
			if ((cm == null)||!(cm.List is DataView)) return contarighe;
			for (int i=0; i<cm.Count; i++) 
			{
				if (grid.IsSelected(i))
				{
					contarighe ++;
				}
			}
			return contarighe;
		}

		private void dgrCaricoBene_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			int i = contaRigheSelezionate(dgrCaricoBene);
			if (i > 0) AbilitaBottoniCreaBuono(true);
		}

//		private void dgrCaricoParte_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
//		{
//			int i = contaRigheSelezionate(dgrCaricoParte);
//			if (i > 0) AbilitaBottoniCreaBuono(true);		
//		}
        #region E/P


       /* private void btnVisualizzaEP_Click(object sender, EventArgs e)
        {
            EditEntry();
        }

        void EditEntry()
        {
            if (DS.assetload.Rows.Count == 0) return;
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            EP.EditRelatedEntry(Meta, DS.assetload.Rows[0]);
        }*/


        private object calcolaIdAccMotiveCaricoCespite(object idinv)
        {
            if (idinv == DBNull.Value)
            {
                return null;
            }
            string filter = QHC.CmpEq("idinv", idinv);
            if (tInventoryTree.Select(filter).Length > 0)
            {
                DataRow r = tInventoryTree.Select(filter)[0];
                return r["idaccmotiveload"];
            }
            string filtersql = QHS.CmpEq("idinv", idinv);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tInventoryTree, null, filtersql, null, true);
            if (tInventoryTree.Select(filter).Length > 0)
            {
                DataRow r = tInventoryTree.Select(filter)[0];
                return r["idaccmotiveload"];
            }
            return null;
        }

        private object calcolaIdAccMotiveCausaleCarico(object idmot)
        {
            if (idmot == DBNull.Value)
            {
                return null;
            }
            string filter = QHC.CmpEq("idmot", idmot);
            if (DS.assetloadmotive.Select(filter).Length > 0)
            {
                DataRow r = DS.assetloadmotive.Select(filter)[0];
                return r["idaccmotive"];
            }
            string filtersql = QHS.CmpEq("idmot", idmot);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetloadmotive, null, filtersql, null, true);
            if (DS.assetloadmotive.Select(filter).Length > 0)
            {
                DataRow r = DS.assetloadmotive.Select(filter)[0];
                return r["idaccmotive"];
            }
            return null;
        }

        void GeneraScritture()
        {
            if (DS.assetload.Rows.Count == 0) return; //It was an insert-cancel

            DataRow Curr = DS.assetload.Rows[0];
            if (Curr.RowState == DataRowState.Deleted)
            {
                //Should delete the related entries 
                return;
            }

            

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;
            EP.GetEntryForDocument(Curr);

            object doc = "Buono Carico " +
                Curr["idassetloadkind"].ToString() + "/" +
                Curr["yassetload"].ToString().Substring(2, 2) + "/" +
                Curr["nassetload"].ToString().PadLeft(6, '0');

            if (EP.MainEntryExists())
            {
                if (MessageBox.Show("Attenzione, le scritture in E/P risultano già generate." +
                    " Si desidera sovrascriverle per aggiornarle?", "Avviso",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            }
            object descr = (Curr["description"] != DBNull.Value) ? Curr["description"] : ".";
            DataRow r=EP.SetEntry(descr, Curr["adate"],
                doc, Curr["adate"], EP_functions.GetIdForDocument(Curr));

            EP.ClearDetails(r);
            //bool isAmmortamento = false;
            string idepcontext = "CARICO";
            bool somethingdone = false;
            foreach (DataRow rAssetAcquire in DS.assetacquireview.Rows)
            {
                // Devo applicare la causale di carico, devo solo calcolare l'importo del bene da caricare
                // Verifico che la causale di carico abbia una causale EP impostata.
                // In caso contrario salto questo carico nella generazione scritture
                object assetloadMotive = rAssetAcquire["idmot"];
                object idaccAssetLoadMotive = calcolaIdAccMotiveCausaleCarico(assetloadMotive);
                object idreg = rAssetAcquire["idreg"];
                object idupb = rAssetAcquire["idupb"];
                if ((idaccAssetLoadMotive == null) || (idaccAssetLoadMotive == DBNull.Value)) continue;

                decimal importoOriginale = CfgFn.GetNoNullDecimal(rAssetAcquire["cost"]);

                object idaccmotive = calcolaIdAccMotiveCaricoCespite(rAssetAcquire["idinv"]);
                if ((idaccmotive == null) || (idaccmotive == DBNull.Value))
                {
                    MessageBox.Show(this, "Non è stata specificata la causale per la class. inventariale del carico n." +
                        rAssetAcquire["nassetacquire"], "Errore");
                    return;
                }
                DataRow[] ContiImmobilizzazione = EP.GetAccMotiveDetails(idaccmotive);
                foreach (DataRow r3 in ContiImmobilizzazione)
                {
                    object idacc = r3["idacc"];
                    EP.EffettuaScrittura(idepcontext, importoOriginale, idacc, idreg, idupb, null, null, rAssetAcquire, idaccmotive);
                    somethingdone = true;
                }

                DataRow[] ContiReddito = EP.GetAccMotiveDetails(idaccAssetLoadMotive);
                foreach (DataRow r2 in ContiReddito)
                {
                    object idacc = r2["idacc"];
                    EP.EffettuaScrittura(idepcontext, importoOriginale, idacc, idreg, idupb, null, null, rAssetAcquire, idaccAssetLoadMotive);
                    somethingdone = true;
                }

            }
            if (somethingdone == false) {
                MessageBox.Show("Nessuna scrittura da generare", "Avviso");
                return;
            }
            EP.RemoveEmptyDetails();

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            /*if (Post.DO_POST())
            {
                VisualizzaEtichetteEP();
                EditEntry();
            }*/

        }
        

        #endregion
	}
}
