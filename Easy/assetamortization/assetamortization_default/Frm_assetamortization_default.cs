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
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione



namespace assetamortization_default//rivalutazionebene//
{
	/// <summary>
	/// Summary description for frmrivalutazionebene.
	/// </summary>
	public class Frm_assetamortization_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox5;
		public vistaForm DS;
		private System.Windows.Forms.TextBox txtNumInv;
		public MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtQuota;
		private System.Windows.Forms.ComboBox cmbInventario;
		private System.Windows.Forms.ComboBox cmbTipoRival;
		private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grpBene;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>

        private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtValoreIniziale;
		private string m_LastCodiceInventario="";
		private System.Windows.Forms.Button btnTipo;
		private System.Windows.Forms.TextBox txtDescrizioneCespite;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label labDescrizione;
		private System.Windows.Forms.TextBox txtidpiece;
		private System.Windows.Forms.Button btnSelezBene;
		private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.TextBox textBox2;
        private GroupBox grpBuonoInv;
        private ComboBox cmbCodiceTipoBuono;
        private Label label4;
        private Label label15;
        private TextBox txtNumBuono;
        private TextBox txtEserBuono;
        private Label label;
        private CheckBox chkFlagUnload;
        private CheckBox chkTransmitted;
        private GroupBox grpClassif;
        private TextBox txtDescClassif;
        private TextBox txtIdClassif;
        private Button btnClassif;
        private GroupBox grpBuonoCarico;
        private ComboBox cmbtipobuonocarico;
        private Label label12;
        private Label label13;
        private TextBox txtNumBuonoCarico;
        private TextBox txtEsercBuonoCarico;
        private Label label14;
        private GroupBox groupBox1;
        private TextBox txtCat;
        private GroupBox groupBox3;
        private TextBox txtAnnoCes;
        private GroupBox groupBox2;
        private TextBox txtAnnoSval;
        private CheckBox checkBox1;
	
		MetaData.AutoInfo MyAutoInfo;

		public Frm_assetamortization_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			GetData.CacheTable(DS.inventory,null,null,true);
            GetData.CacheTable(DS.assetunloadkind, null, null, true);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetamortization_default));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbTipoRival = new System.Windows.Forms.ComboBox();
            this.DS = new assetamortization_default.vistaForm();
            this.grpBene = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAnnoCes = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCat = new System.Windows.Forms.TextBox();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtidpiece = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.labDescrizione = new System.Windows.Forms.Label();
            this.btnSelezBene = new System.Windows.Forms.Button();
            this.txtValoreIniziale = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescrizioneCespite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.txtNumInv = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtQuota = new System.Windows.Forms.TextBox();
            this.btnTipo = new System.Windows.Forms.Button();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.grpBuonoInv = new System.Windows.Forms.GroupBox();
            this.cmbCodiceTipoBuono = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumBuono = new System.Windows.Forms.TextBox();
            this.txtEserBuono = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.chkFlagUnload = new System.Windows.Forms.CheckBox();
            this.chkTransmitted = new System.Windows.Forms.CheckBox();
            this.grpBuonoCarico = new System.Windows.Forms.GroupBox();
            this.cmbtipobuonocarico = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumBuonoCarico = new System.Windows.Forms.TextBox();
            this.txtEsercBuonoCarico = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAnnoSval = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpBene.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpClassif.SuspendLayout();
            this.grpBuonoInv.SuspendLayout();
            this.grpBuonoCarico.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "N.Rivalutazione";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "assetamortization.namortization";
            // 
            // cmbTipoRival
            // 
            this.cmbTipoRival.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoRival.DataSource = this.DS.inventoryamortization;
            this.cmbTipoRival.DisplayMember = "description";
            this.cmbTipoRival.Location = new System.Drawing.Point(299, 27);
            this.cmbTipoRival.Name = "cmbTipoRival";
            this.cmbTipoRival.Size = new System.Drawing.Size(273, 21);
            this.cmbTipoRival.TabIndex = 2;
            this.cmbTipoRival.Tag = "assetamortization.idinventoryamortization.(active=\'S\')";
            this.cmbTipoRival.ValueMember = "idinventoryamortization";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpBene
            // 
            this.grpBene.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBene.Controls.Add(this.groupBox3);
            this.grpBene.Controls.Add(this.groupBox1);
            this.grpBene.Controls.Add(this.grpClassif);
            this.grpBene.Controls.Add(this.textBox2);
            this.grpBene.Controls.Add(this.txtidpiece);
            this.grpBene.Controls.Add(this.txtDescrizione);
            this.grpBene.Controls.Add(this.labDescrizione);
            this.grpBene.Controls.Add(this.btnSelezBene);
            this.grpBene.Controls.Add(this.txtValoreIniziale);
            this.grpBene.Controls.Add(this.label11);
            this.grpBene.Controls.Add(this.txtDescrizioneCespite);
            this.grpBene.Controls.Add(this.label5);
            this.grpBene.Controls.Add(this.label3);
            this.grpBene.Controls.Add(this.cmbInventario);
            this.grpBene.Controls.Add(this.txtNumInv);
            this.grpBene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBene.Location = new System.Drawing.Point(0, 53);
            this.grpBene.Name = "grpBene";
            this.grpBene.Size = new System.Drawing.Size(948, 232);
            this.grpBene.TabIndex = 3;
            this.grpBene.TabStop = false;
            this.grpBene.Tag = "AutoChoose.txtNumInv.default.(nassetunload IS NULL)";
            this.grpBene.Text = "Cespite";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtAnnoCes);
            this.groupBox3.Location = new System.Drawing.Point(578, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 40);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Anno esistenza cespite";
            // 
            // txtAnnoCes
            // 
            this.txtAnnoCes.Location = new System.Drawing.Point(6, 14);
            this.txtAnnoCes.Name = "txtAnnoCes";
            this.txtAnnoCes.Size = new System.Drawing.Size(100, 20);
            this.txtAnnoCes.TabIndex = 0;
            this.txtAnnoCes.Tag = "assetamortizationview.ass_year.year?assetamortizationview.ass_year.year";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCat);
            this.groupBox1.Location = new System.Drawing.Point(459, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 40);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Categoria";
            // 
            // txtCat
            // 
            this.txtCat.Location = new System.Drawing.Point(6, 14);
            this.txtCat.Name = "txtCat";
            this.txtCat.Size = new System.Drawing.Size(100, 20);
            this.txtCat.TabIndex = 0;
            this.txtCat.Tag = "inventorytreeview.codeinv_lev1?assetamortizationview.codeinv_lev1";
            // 
            // grpClassif
            // 
            this.grpClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(7, 147);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(446, 79);
            this.grpClassif.TabIndex = 3;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(170, 11);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(270, 62);
            this.txtDescClassif.TabIndex = 19;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtIdClassif
            // 
            this.txtIdClassif.Location = new System.Drawing.Point(8, 53);
            this.txtIdClassif.Name = "txtIdClassif";
            this.txtIdClassif.Size = new System.Drawing.Size(153, 20);
            this.txtIdClassif.TabIndex = 1;
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetpieceview.codeinv";
            // 
            // btnClassif
            // 
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(8, 17);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(120, 23);
            this.btnClassif.TabIndex = 17;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(239, 100);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(681, 41);
            this.textBox2.TabIndex = 38;
            this.textBox2.Text = "Imponibile *(1-sconto)*(1-IVA). L\'IVA è calcolata a seconda della configurazione " +
    "del tipo di Rivalutazione/Svalutazione. Lo sconto non è calcolato per i libri ca" +
    "ricati in esercizi >=2005.";
            // 
            // txtidpiece
            // 
            this.txtidpiece.Location = new System.Drawing.Point(24, 73);
            this.txtidpiece.Name = "txtidpiece";
            this.txtidpiece.ReadOnly = true;
            this.txtidpiece.Size = new System.Drawing.Size(80, 20);
            this.txtidpiece.TabIndex = 37;
            this.txtidpiece.Tag = "assetpieceview.idpiece?assetamortizationview.idpiece";
            this.txtidpiece.Text = "idpiece Value";
            this.txtidpiece.Visible = false;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(494, 47);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(426, 47);
            this.txtDescrizione.TabIndex = 36;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "assetpieceview.descriptionmain";
            // 
            // labDescrizione
            // 
            this.labDescrizione.Location = new System.Drawing.Point(491, 28);
            this.labDescrizione.Name = "labDescrizione";
            this.labDescrizione.Size = new System.Drawing.Size(184, 16);
            this.labDescrizione.TabIndex = 35;
            this.labDescrizione.Text = "Descrizione Cespite principale";
            this.labDescrizione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelezBene
            // 
            this.btnSelezBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelezBene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelezBene.Location = new System.Drawing.Point(308, 16);
            this.btnSelezBene.Name = "btnSelezBene";
            this.btnSelezBene.Size = new System.Drawing.Size(108, 21);
            this.btnSelezBene.TabIndex = 1;
            this.btnSelezBene.TabStop = false;
            this.btnSelezBene.Tag = "choose.assetpieceview.default";
            this.btnSelezBene.Text = "N. Inventario";
            // 
            // txtValoreIniziale
            // 
            this.txtValoreIniziale.Location = new System.Drawing.Point(15, 118);
            this.txtValoreIniziale.Name = "txtValoreIniziale";
            this.txtValoreIniziale.ReadOnly = true;
            this.txtValoreIniziale.Size = new System.Drawing.Size(96, 20);
            this.txtValoreIniziale.TabIndex = 3;
            this.txtValoreIniziale.TabStop = false;
            this.txtValoreIniziale.Tag = "assetamortization.assetvalue";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "Valore iniziale ai fini dell\'ammortamento";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescrizioneCespite
            // 
            this.txtDescrizioneCespite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneCespite.Location = new System.Drawing.Point(112, 47);
            this.txtDescrizioneCespite.Multiline = true;
            this.txtDescrizioneCespite.Name = "txtDescrizioneCespite";
            this.txtDescrizioneCespite.ReadOnly = true;
            this.txtDescrizioneCespite.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneCespite.Size = new System.Drawing.Size(376, 47);
            this.txtDescrizioneCespite.TabIndex = 3;
            this.txtDescrizioneCespite.TabStop = false;
            this.txtDescrizioneCespite.Tag = "assetpieceview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(24, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Inventario:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DataSource = this.DS.inventory;
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventario.Location = new System.Drawing.Point(72, 17);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(221, 21);
            this.cmbInventario.TabIndex = 0;
            this.cmbInventario.Tag = "assetpieceview.idinventory.(active=\'S\')?assetamortizationview.idinventory";
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // txtNumInv
            // 
            this.txtNumInv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumInv.Location = new System.Drawing.Point(418, 17);
            this.txtNumInv.Name = "txtNumInv";
            this.txtNumInv.Size = new System.Drawing.Size(70, 20);
            this.txtNumInv.TabIndex = 2;
            this.txtNumInv.Tag = "assetpieceview.ninventory?assetamortizationview.ninventory";
            this.txtNumInv.TextChanged += new System.EventHandler(this.txtNumInv_TextChanged);
            this.txtNumInv.Leave += new System.EventHandler(this.txtNumInv_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Descrizione:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(112, 392);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 21);
            this.label8.TabIndex = 26;
            this.label8.Text = "Importo della rivalutazione/svalutazione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(321, 392);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Data Contabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(4, 394);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Quota:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(3, 313);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(403, 72);
            this.textBox5.TabIndex = 4;
            this.textBox5.Tag = "assetamortization.description";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(321, 416);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(96, 20);
            this.txtData.TabIndex = 8;
            this.txtData.Tag = "assetamortization.adate";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(112, 416);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.ReadOnly = true;
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 6;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "";
            this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtQuota
            // 
            this.txtQuota.Location = new System.Drawing.Point(4, 416);
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Size = new System.Drawing.Size(96, 20);
            this.txtQuota.TabIndex = 7;
            this.txtQuota.Tag = "assetamortization.amortizationquota.fixed.6..%.100";
            this.txtQuota.TextChanged += new System.EventHandler(this.txtQuota_TextChanged);
            // 
            // btnTipo
            // 
            this.btnTipo.Location = new System.Drawing.Point(109, 27);
            this.btnTipo.Name = "btnTipo";
            this.btnTipo.Size = new System.Drawing.Size(184, 20);
            this.btnTipo.TabIndex = 1;
            this.btnTipo.TabStop = false;
            this.btnTipo.Tag = "choose.inventoryamortization.default";
            this.btnTipo.Text = "Tipo Rivalutazione/Svalutazione";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(862, 411);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 29;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // grpBuonoInv
            // 
            this.grpBuonoInv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuonoInv.Controls.Add(this.cmbCodiceTipoBuono);
            this.grpBuonoInv.Controls.Add(this.label4);
            this.grpBuonoInv.Controls.Add(this.label15);
            this.grpBuonoInv.Controls.Add(this.txtNumBuono);
            this.grpBuonoInv.Controls.Add(this.txtEserBuono);
            this.grpBuonoInv.Controls.Add(this.label);
            this.grpBuonoInv.Location = new System.Drawing.Point(412, 291);
            this.grpBuonoInv.Name = "grpBuonoInv";
            this.grpBuonoInv.Size = new System.Drawing.Size(527, 43);
            this.grpBuonoInv.TabIndex = 5;
            this.grpBuonoInv.TabStop = false;
            this.grpBuonoInv.Text = "Buono di Scarico (solo per gli ammortamenti) ";
            // 
            // cmbCodiceTipoBuono
            // 
            this.cmbCodiceTipoBuono.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodiceTipoBuono.DataSource = this.DS.assetunloadkind;
            this.cmbCodiceTipoBuono.DisplayMember = "description";
            this.cmbCodiceTipoBuono.Location = new System.Drawing.Point(39, 14);
            this.cmbCodiceTipoBuono.Name = "cmbCodiceTipoBuono";
            this.cmbCodiceTipoBuono.Size = new System.Drawing.Size(231, 21);
            this.cmbCodiceTipoBuono.TabIndex = 1;
            this.cmbCodiceTipoBuono.Tag = "assetunload.idassetunloadkind.(active=\'S\')?assetamortizationview.idassetunloadkin" +
    "d";
            this.cmbCodiceTipoBuono.ValueMember = "idassetunloadkind";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(393, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "Numero";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumBuono
            // 
            this.txtNumBuono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumBuono.Location = new System.Drawing.Point(441, 14);
            this.txtNumBuono.Name = "txtNumBuono";
            this.txtNumBuono.Size = new System.Drawing.Size(67, 20);
            this.txtNumBuono.TabIndex = 3;
            this.txtNumBuono.Tag = "assetunload.nassetunload?assetamortizationview.nassetunload";
            // 
            // txtEserBuono
            // 
            this.txtEserBuono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEserBuono.Location = new System.Drawing.Point(329, 14);
            this.txtEserBuono.Name = "txtEserBuono";
            this.txtEserBuono.Size = new System.Drawing.Size(54, 20);
            this.txtEserBuono.TabIndex = 2;
            this.txtEserBuono.Tag = "assetunload.yassetunload.year?assetamortizationview.yassetunload.year";
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Location = new System.Drawing.Point(276, 16);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(51, 16);
            this.label.TabIndex = 0;
            this.label.Text = "Esercizio";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkFlagUnload
            // 
            this.chkFlagUnload.Location = new System.Drawing.Point(707, 412);
            this.chkFlagUnload.Name = "chkFlagUnload";
            this.chkFlagUnload.Size = new System.Drawing.Size(115, 24);
            this.chkFlagUnload.TabIndex = 10;
            this.chkFlagUnload.Tag = "assetamortization.flag:0";
            this.chkFlagUnload.Text = "Includi in buono";
            this.chkFlagUnload.UseVisualStyleBackColor = true;
            // 
            // chkTransmitted
            // 
            this.chkTransmitted.AutoSize = true;
            this.chkTransmitted.Location = new System.Drawing.Point(707, 396);
            this.chkTransmitted.Name = "chkTransmitted";
            this.chkTransmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTransmitted.TabIndex = 9;
            this.chkTransmitted.Tag = "assetamortization.transmitted:S:N";
            this.chkTransmitted.Text = "Trasmesso";
            this.chkTransmitted.UseVisualStyleBackColor = true;
            // 
            // grpBuonoCarico
            // 
            this.grpBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuonoCarico.Controls.Add(this.cmbtipobuonocarico);
            this.grpBuonoCarico.Controls.Add(this.label12);
            this.grpBuonoCarico.Controls.Add(this.label13);
            this.grpBuonoCarico.Controls.Add(this.txtNumBuonoCarico);
            this.grpBuonoCarico.Controls.Add(this.txtEsercBuonoCarico);
            this.grpBuonoCarico.Controls.Add(this.label14);
            this.grpBuonoCarico.Location = new System.Drawing.Point(412, 340);
            this.grpBuonoCarico.Name = "grpBuonoCarico";
            this.grpBuonoCarico.Size = new System.Drawing.Size(531, 45);
            this.grpBuonoCarico.TabIndex = 6;
            this.grpBuonoCarico.TabStop = false;
            this.grpBuonoCarico.Text = "Buono di Carico (solo per le rivalutazioni) ";
            // 
            // cmbtipobuonocarico
            // 
            this.cmbtipobuonocarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbtipobuonocarico.DataSource = this.DS.assetloadkind;
            this.cmbtipobuonocarico.DisplayMember = "description";
            this.cmbtipobuonocarico.Location = new System.Drawing.Point(39, 14);
            this.cmbtipobuonocarico.Name = "cmbtipobuonocarico";
            this.cmbtipobuonocarico.Size = new System.Drawing.Size(235, 21);
            this.cmbtipobuonocarico.TabIndex = 1;
            this.cmbtipobuonocarico.Tag = "assetload.idassetloadkind.(active=\'S\')?assetamortizationview.idassetloadkind";
            this.cmbtipobuonocarico.ValueMember = "idassetloadkind";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Tipo ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(397, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Numero";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumBuonoCarico
            // 
            this.txtNumBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumBuonoCarico.Location = new System.Drawing.Point(445, 14);
            this.txtNumBuonoCarico.Name = "txtNumBuonoCarico";
            this.txtNumBuonoCarico.Size = new System.Drawing.Size(67, 20);
            this.txtNumBuonoCarico.TabIndex = 3;
            this.txtNumBuonoCarico.Tag = "assetload.nassetload?assetamortizationview.nassetload";
            // 
            // txtEsercBuonoCarico
            // 
            this.txtEsercBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercBuonoCarico.Location = new System.Drawing.Point(333, 14);
            this.txtEsercBuonoCarico.Name = "txtEsercBuonoCarico";
            this.txtEsercBuonoCarico.Size = new System.Drawing.Size(54, 20);
            this.txtEsercBuonoCarico.TabIndex = 2;
            this.txtEsercBuonoCarico.Tag = "assetload.yassetload.year?assetamortizationview.yassetload.year";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(280, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Esercizio";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAnnoSval);
            this.groupBox2.Location = new System.Drawing.Point(589, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 40);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Anno svalutazione/rivalutazione";
            // 
            // txtAnnoSval
            // 
            this.txtAnnoSval.Location = new System.Drawing.Point(6, 14);
            this.txtAnnoSval.Name = "txtAnnoSval";
            this.txtAnnoSval.Size = new System.Drawing.Size(100, 20);
            this.txtAnnoSval.TabIndex = 0;
            this.txtAnnoSval.Tag = "assetamortizationview.am_year.year?assetamortizationview.am_year.year";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(487, 410);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(208, 24);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Tag = "assetamortization.flag:1";
            this.checkBox1.Text = "Ammortamento correttivo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Frm_assetamortization_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(972, 456);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpBuonoCarico);
            this.Controls.Add(this.chkTransmitted);
            this.Controls.Add(this.chkFlagUnload);
            this.Controls.Add(this.grpBuonoInv);
            this.Controls.Add(this.btnSituazione);
            this.Controls.Add(this.btnTipo);
            this.Controls.Add(this.txtQuota);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grpBene);
            this.Controls.Add(this.cmbTipoRival);
            this.Controls.Add(this.label1);
            this.Name = "Frm_assetamortization_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmrivalutazionebene";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpBene.ResumeLayout(false);
            this.grpBene.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.grpBuonoInv.ResumeLayout(false);
            this.grpBuonoInv.PerformLayout();
            this.grpBuonoCarico.ResumeLayout(false);
            this.grpBuonoCarico.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

		private void abilitaSceltaBene(bool enabled) 
		{
			cmbInventario.Enabled = enabled;
			btnTipo.Enabled = enabled;
			cmbTipoRival.Enabled = enabled;
			txtNumInv.ReadOnly = ! enabled;
			btnSelezBene.Enabled = enabled;
		}

        private void abilitaCampiPerRicerca(bool enabled) {
            grpClassif.Enabled = enabled;
            grpBuonoInv.Enabled = enabled;
            grpBuonoCarico.Enabled = enabled;
            txtCat.ReadOnly = !enabled;
            txtAnnoCes.ReadOnly = !enabled;
            txtAnnoSval.ReadOnly = !enabled;
        }

		public void MetaData_AfterClear() {
			btnSituazione.Enabled=false;
			btnSelezBene.Tag = "choose.assetpieceview.default";
			
			m_LastCodiceInventario="";
			txtImporto.Text="";
			txtValoreIniziale.Text="";  //	<-- sa
			txtDescrizione.Visible=false;
			labDescrizione.Visible=false;
			abilitaSceltaBene(true);
            abilitaCampiPerRicerca(true);
		}

		public void MetaData_AfterFill() {
//			btnSituazione.Enabled=!Meta.IsEmpty;
			if (MyAutoInfo == null) MyAutoInfo= Meta.GetAutoInfo(txtNumInv.Name);

			abilitaSceltaBene(Meta.InsertMode);
			if (Meta.IsEmpty) return;
            if (Meta.FirstFillForThisRow) {
                abilitaCampiPerRicerca(false);
            }
			bool ModoInsert=Meta.InsertMode;
			btnSituazione.Enabled=!ModoInsert;
			if (!Meta.IsEmpty) {
				if (DS.assetpieceview.Rows.Count==0)
					ImpostaFiltrobtnSelezBene(null,false);
				else 
					ImpostaFiltrobtnSelezBene(DS.assetpieceview.Rows[0],true);
			}
			if (!Meta.InsertMode) {				
//				txtValoreAttuale.Text=GetValoreAttuale(); // <-- sa
				if (cmbInventario.SelectedIndex > 0) 
					m_LastCodiceInventario=cmbInventario.SelectedValue.ToString();
				else 
					m_LastCodiceInventario="";
				if (Meta.FirstFillForThisRow) {
					object quota=DS.assetamortization.Rows[0]["amortizationquota"];
//					object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreAttuale.Text,null);// <-- sa
					object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreIniziale.Text,null);
					CalcolaImporto(quota,valorebene);
				}
			}
			int nidpiece= CfgFn.GetNoNullInt32(DS.assetamortization.Rows[0]["idpiece"]);
			if (nidpiece==1)
			{	txtDescrizione.Visible = false;
				labDescrizione.Visible = false;
			}
			else 
			{	txtDescrizione.Visible=true;
				labDescrizione.Visible=true;
			}
		}
		
		void ImpostaFiltrobtnSelezBene(DataRow AssetPiece, bool filtraIdPiece)
		{
			string filtro = (AssetPiece== null) ? "" : ".(idinventory=" + QueryCreator.quotedstrvalue(AssetPiece["idinventory"], false) + ")";
			btnSelezBene.Tag = "choose.assetpieceview.default" + filtro;
            string filtrobase = null;
            if (Meta.InsertMode) {
                filtrobase = QHS.IsNull("nassetunload");
            }
			if (AssetPiece!=null && filtraIdPiece) 	
			{
                string starttag = btnSelezBene.Tag.ToString();
                string tag = QHC.AppAnd(starttag, QHC.CmpEq("idpiece", AssetPiece["idpiece"]));
				btnSelezBene.Tag = tag;
				if (MyAutoInfo!=null)
					MyAutoInfo.startfilter=QHS.AppAnd(filtrobase, QHS.CmpEq("idpiece", AssetPiece["idpiece"]));
			}
			else 
			{
				if (MyAutoInfo!=null)
					MyAutoInfo.startfilter=filtrobase;
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {

			bool ModoInsert=Meta.InsertMode;
			btnSituazione.Enabled=!ModoInsert;

			if (T.TableName == "inventoryamortization" && R!=null && Meta.DrawStateIsDone) {
				Rivaluta();
			}
			if (T.TableName == "assetpieceview" && R!=null && !Meta.IsEmpty && Meta.DrawStateIsDone) {
				//DS.assetamortization.Rows[0]["assetvalue"]=R["taxable"];  //    <-- sa
				Rivaluta();
				object quota=DS.assetamortization.Rows[0]["amortizationquota"];
//				object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreAttuale.Text,null);// <-- sa
				object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreIniziale.Text,null);
				CalcolaImporto(quota,valorebene);
			}
			if (T.TableName == "inventory") 
			{
//				string filtro = (R == null) ? "" : ".(idinventory=" + QueryCreator.quotedstrvalue(R["idinventory"], false) + ")";
//				btnSelezBene.Tag = "choose.assetpieceview.default" + filtro;
				if (!Meta.DrawStateIsDone) return;
				ImpostaFiltrobtnSelezBene(R,false);
				ScollegaBene(R);
			}

            //if (Meta.InsertMode)// <-- sa
            //    if ((cmbTipoRival.SelectedIndex<=0)||(txtNumInv.Text.Trim()==""))
            //        txtValoreIniziale.Text="";
				
		}

		private void ScollegaBene(DataRow R) {
			string codice=(R==null?"":R["idinventory"].ToString());
			if (m_LastCodiceInventario==codice) return;
			m_LastCodiceInventario=codice;
			txtNumInv.Text="";
			txtDescrizioneCespite.Text="";
			if (!Meta.IsEmpty) {
				DS.assetpieceview.Clear();
				DS.assetamortization.Rows[0]["idasset"]=-1;
			}
		}

		private string GetValoreAttuale() {
			if (Meta.IsEmpty) return string.Empty;
			decimal imp=CfgFn.GetNoNullDecimal(DS.assetamortization.Rows[0]["assetvalue"]);
			return imp.ToString("c");
		}

		private void CalcolaImporto(object quota, object valorebene) {
			if (Meta.IsEmpty) return;
			double quotareale=CfgFn.GetNoNullDouble(quota);
			decimal valbene=CfgFn.GetNoNullDecimal(valorebene); 
			double valbenereale=Convert.ToDouble(valbene);
			double imp=(valbenereale*quotareale);
			txtImporto.Text=imp.ToString("c");
		}

		private void txtQuota_TextChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			object quota=DS.assetamortization.Rows[0]["amortizationquota"];
//			object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreAttuale.Text,null);//<--sa
			object valorebene=HelpForm.GetObjectFromString(typeof(decimal),txtValoreIniziale.Text,null);
			CalcolaImporto(quota,valorebene);
		}

		private void txtNumInv_Leave(object sender, System.EventArgs e) {
//old
//			if (Meta.IsEmpty) return;
//			if (txtNumInv.Text.Trim()=="") {
//				Meta.DoMainCommand(choose+".clear");
//				return;
//			}
//			string filter="(idinventory="+QueryCreator.quotedstrvalue(m_LastCodiceInventario,true)+") "+
//				"AND (ninventory="+QueryCreator.quotedstrvalue(txtNumInv.Text,true)+") "+
//				"AND (nassetunload IS NULL)";
//			Meta.DoMainCommand(choose+"."+filter);

		}

		private void Rivaluta() {
			//La rivalutazione viene eseguita anche in fase di ricerca, pertanto
			//non viene usato GetForm
			
			if (DS.assetpieceview.Rows.Count<1) return;
            object idbene = DS.assetpieceview.Rows[0]["idasset"];
            object idpiece = DS.assetpieceview.Rows[0]["idpiece"]; // <-- sa
            object esercizio = Meta.GetSys("esercizio");

            string[] param1 = new string[5] { "@idasset", "@idpiece", "@date", "@originalvalue", "@totale" };
            SqlDbType[] tipi1 = new SqlDbType[5]{SqlDbType.Int,SqlDbType.Int,SqlDbType.DateTime,
                                                    SqlDbType.Decimal,SqlDbType.Decimal};
            int[] len1 = new int[5] { 0, 0, 1, 0, 0 };
            ParameterDirection[] dir1 = new ParameterDirection[5]{ParameterDirection.Input,
                                    ParameterDirection.Input, ParameterDirection.Input,
                                    ParameterDirection.Output,ParameterDirection.Output};


            //object flagIva = Meta.Conn.DO_READ_VALUE("inventoryamortization",
            //                                         QHS.CmpEq("idinventoryamortization", codicetipo), "flag");
            DateTime Dec31 = new DateTime(CfgFn.GetNoNullInt32(esercizio), 12, 31);
            object[] valori1 = new object[5] { idbene, idpiece, Dec31, null, null };

            if (Meta.Conn.CallSPParameter("get_assetvalueatdate", param1, tipi1, len1, dir1, ref valori1, true, -1)) {

                DS.assetamortization.Rows[0]["assetvalue"] = CfgFn.GetNoNullDecimal(valori1[3]);  // <-- sa
                txtValoreIniziale.Text = CfgFn.GetNoNullDecimal(valori1[3]).ToString("c");	// <-- sa
            }
       

			if (cmbTipoRival.SelectedIndex<=0) return;
			if (cmbTipoRival.SelectedValue.ToString()=="") return;
			
			string[] param= new string[5]{"@idasset","@idpiece","@idinventoryamortization",
                "@ayear","@amortizationquota"};
			SqlDbType[] tipi=new SqlDbType[6]{SqlDbType.Int,SqlDbType.Int,SqlDbType.VarChar,SqlDbType.Int,
			SqlDbType.Float,SqlDbType.Decimal};
			int[] len=new int[5]{0,0,10,0,0};
			ParameterDirection[] dir=new ParameterDirection[5]{ParameterDirection.Input,
                                    ParameterDirection.Input,ParameterDirection.Input,
									 ParameterDirection.Input, 
                                    ParameterDirection.Output};

			object codicetipo=cmbTipoRival.SelectedValue;
			object[] valori=new object[5]{idbene,idpiece,codicetipo,esercizio,null};
			
			if (Meta.Conn.CallSPParameter("compute_amortization",param,tipi,len,dir,ref valori,true,-1)) {
				if (!Meta.EditMode) 
				{	
					object quotaRivalutazione;
					if (valori[4]== DBNull.Value)
						quotaRivalutazione = DS.assetamortization.Rows[0]["amortizationquota"];
					else
					{	
						quotaRivalutazione = CfgFn.GetNoNullDecimal(valori[4]);
						DS.assetamortization.Rows[0]["amortizationquota"] = quotaRivalutazione;
					}
					txtQuota.Text = HelpForm.StringValue(quotaRivalutazione, txtQuota.Tag.ToString());
				}
              
			}

            //execute get_assetvalueatdate @idasset,@idpiece, @dec_31,@flagivaapplying, @assetvalue OUTPUT, @actualvalue OUTPUT 
       
		}

		private void txtNumInv_TextChanged(object sender, System.EventArgs e)
		{
			if (Meta==null) return;
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if (DS.assetpieceview.Rows.Count==0) 
			{
				ImpostaFiltrobtnSelezBene(null,false);
				return;
			}
			DataRow R=DS.assetpieceview.Rows[0];
			ImpostaFiltrobtnSelezBene(R,false); 
		}

		private void btnSituazione_Click(object sender, System.EventArgs e)
		{
			DataRow MyRow=HelpForm.GetLastSelected(DS.assetamortization);
			object idasset=(MyRow!=null?MyRow["idasset"]:null);

			DataSet Out = Meta.Conn.CallSP("show_asset",
				new Object[2] {Meta.GetSys("datacontabile"),idasset});
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione cespiti inventariati";
			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}
	}
}
