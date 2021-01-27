
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace sortingkind_lista//tipoclassmovimentibase//
{
	/// <summary>
	/// Descrizione di riepilogo per frmTipoClassMovimentiBase.
	/// </summary>
	public class Frm_sortingkind_lista : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList images;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCodice;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox etN5;
		private System.Windows.Forms.CheckBox lockN5;
		private System.Windows.Forms.CheckBox forceN5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox etN4;
		private System.Windows.Forms.CheckBox lockN4;
		private System.Windows.Forms.CheckBox forceN4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox etN3;
		private System.Windows.Forms.CheckBox lockN3;
		private System.Windows.Forms.CheckBox forceN3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox etN2;
		private System.Windows.Forms.CheckBox lockN2;
		private System.Windows.Forms.CheckBox forceN2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox etN1;
		private System.Windows.Forms.CheckBox lockN1;
		private System.Windows.Forms.CheckBox forceN1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox etDate;
		private System.Windows.Forms.TextBox etichettaignoradate;
		public System.Windows.Forms.TextBox txtDenom;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox etV4;
		private System.Windows.Forms.TextBox etV3;
		private System.Windows.Forms.TextBox etV2;
		private System.Windows.Forms.TextBox etV1;
		private System.Windows.Forms.TextBox etV5;
		private System.Windows.Forms.CheckBox forceV5;
		private System.Windows.Forms.CheckBox lockV4;
		private System.Windows.Forms.CheckBox forceV4;
		private System.Windows.Forms.CheckBox lockV3;
		private System.Windows.Forms.CheckBox forceV3;
		private System.Windows.Forms.CheckBox lockV2;
		private System.Windows.Forms.CheckBox forceV2;
		private System.Windows.Forms.CheckBox lockV1;
		private System.Windows.Forms.CheckBox forceV1;
		private System.Windows.Forms.CheckBox lockV5;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.CheckBox checkBox5;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox usaDate;
        private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBox2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label35;
        private ComboBox cmbClassPrecedente;
        private Label label36;
		MetaData Meta;
        private TabPage tabPage4;
        private Label label37;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private Label label16;
        private Label label17;
        private Label label18;
        private CheckBox lockS5;
        private CheckBox forceS5;
        private TextBox etS4;
        private TextBox etS5;
        private CheckBox forceS4;
        private TextBox etS3;
        private CheckBox lockS3;
        private CheckBox forceS3;
        private CheckBox lockS4;
        private CheckBox lockS2;
        private CheckBox forceS2;
        private TextBox etS1;
        private CheckBox lockS1;
        private TextBox etS2;
        private CheckBox forceS1;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox textBox5;
        private TextBox textBox4;
        private CheckBox checkBox1;
        //DataAccess Conn;

		public Frm_sortingkind_lista()
		{
			//
			// Necessario per il supporto di Progettazione Windows Form
			//
			InitializeComponent();
            DataAccess.SetTableForReading(DS.Tables["sortingkind1"], "sortingkind");

			//
			// TODO: aggiungere il codice del costruttore dopo la chiamata a InitializeComponent.
			//
		}

		/// <summary>
		/// Pulire le risorse in uso.
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

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["flagdate"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["active"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedn1"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedn2"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedn3"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedn4"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedn5"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forceds1"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forceds2"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forceds3"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forceds4"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forceds5"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedv1"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedv2"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedv3"],true);
			HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedv4"],true);
            HelpForm.SetDenyNull(DS.sortingkind.Columns["forcedv5"], true);
			GetData.CacheTable(DS.sortabletable,null,"description",false);
			GetData.SetSorting(DS.incomephase,"nphase ASC");
			GetData.SetSorting(DS.expensephase,"nphase ASC");

		}
		public void MetaData_AfterFill(){
			CheckAll();
			usaDate_CheckedChanged(null,null);
            if (Meta.EditMode)
            {
                txtCodice.ReadOnly = true;
            }
            else
            {
                txtCodice.ReadOnly = false;
            }
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sortingkind_lista));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.seleziona = new System.Windows.Forms.ToolBarButton();
            this.modifica = new System.Windows.Forms.ToolBarButton();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDenom = new System.Windows.Forms.TextBox();
            this.etN5 = new System.Windows.Forms.TextBox();
            this.lockN5 = new System.Windows.Forms.CheckBox();
            this.forceN5 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.etN4 = new System.Windows.Forms.TextBox();
            this.lockN4 = new System.Windows.Forms.CheckBox();
            this.forceN4 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.etN3 = new System.Windows.Forms.TextBox();
            this.lockN3 = new System.Windows.Forms.CheckBox();
            this.forceN3 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.etN2 = new System.Windows.Forms.TextBox();
            this.lockN2 = new System.Windows.Forms.CheckBox();
            this.forceN2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.etN1 = new System.Windows.Forms.TextBox();
            this.lockN1 = new System.Windows.Forms.CheckBox();
            this.forceN1 = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.etV4 = new System.Windows.Forms.TextBox();
            this.etV3 = new System.Windows.Forms.TextBox();
            this.etV2 = new System.Windows.Forms.TextBox();
            this.etV1 = new System.Windows.Forms.TextBox();
            this.etV5 = new System.Windows.Forms.TextBox();
            this.forceV5 = new System.Windows.Forms.CheckBox();
            this.lockV4 = new System.Windows.Forms.CheckBox();
            this.forceV4 = new System.Windows.Forms.CheckBox();
            this.lockV3 = new System.Windows.Forms.CheckBox();
            this.forceV3 = new System.Windows.Forms.CheckBox();
            this.lockV2 = new System.Windows.Forms.CheckBox();
            this.forceV2 = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lockV1 = new System.Windows.Forms.CheckBox();
            this.forceV1 = new System.Windows.Forms.CheckBox();
            this.lockV5 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.etDate = new System.Windows.Forms.TextBox();
            this.etichettaignoradate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.DS = new sortingkind_lista.vistaForm();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usaDate = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cmbClassPrecedente = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lockS5 = new System.Windows.Forms.CheckBox();
            this.forceS5 = new System.Windows.Forms.CheckBox();
            this.etS4 = new System.Windows.Forms.TextBox();
            this.etS5 = new System.Windows.Forms.TextBox();
            this.forceS4 = new System.Windows.Forms.CheckBox();
            this.etS3 = new System.Windows.Forms.TextBox();
            this.lockS3 = new System.Windows.Forms.CheckBox();
            this.forceS3 = new System.Windows.Forms.CheckBox();
            this.lockS4 = new System.Windows.Forms.CheckBox();
            this.lockS2 = new System.Windows.Forms.CheckBox();
            this.forceS2 = new System.Windows.Forms.CheckBox();
            this.etS1 = new System.Windows.Forms.TextBox();
            this.lockS1 = new System.Windows.Forms.CheckBox();
            this.etS2 = new System.Windows.Forms.TextBox();
            this.forceS1 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.seleziona,
            this.modifica,
            this.inserisci,
            this.inseriscicopia,
            this.elimina,
            this.Salva,
            this.aggiorna});
            this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(864, 56);
            this.MetaDataToolBar.TabIndex = 2;
            this.MetaDataToolBar.Tag = "";
            // 
            // seleziona
            // 
            this.seleziona.ImageIndex = 1;
            this.seleziona.Name = "seleziona";
            this.seleziona.Tag = "mainselect";
            this.seleziona.Text = "Seleziona";
            this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
            // 
            // modifica
            // 
            this.modifica.ImageIndex = 6;
            this.modifica.Name = "modifica";
            this.modifica.Tag = "mainedit";
            this.modifica.Text = "Modifica";
            this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.ImageIndex = 9;
            this.inseriscicopia.Name = "inseriscicopia";
            this.inseriscicopia.Tag = "maininsertcopy";
            this.inseriscicopia.Text = "Inserisci copia";
            this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 13;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 64);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(840, 316);
            this.dataGrid1.TabIndex = 1;
            this.dataGrid1.TabStop = false;
            this.dataGrid1.Tag = "sortingkind.default";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(96, 16);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(88, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "sortingkind.codesorkind";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Denominazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenom
            // 
            this.txtDenom.Location = new System.Drawing.Point(96, 40);
            this.txtDenom.Name = "txtDenom";
            this.txtDenom.Size = new System.Drawing.Size(232, 20);
            this.txtDenom.TabIndex = 2;
            this.txtDenom.Tag = "sortingkind.description";
            // 
            // etN5
            // 
            this.etN5.Location = new System.Drawing.Point(112, 151);
            this.etN5.Name = "etN5";
            this.etN5.Size = new System.Drawing.Size(104, 20);
            this.etN5.TabIndex = 40;
            this.etN5.Tag = "sortingkind.labeln5";
            this.etN5.Text = "etN5";
            this.etN5.TextChanged += new System.EventHandler(this.etS5_TextChanged);
            // 
            // lockN5
            // 
            this.lockN5.Location = new System.Drawing.Point(234, 152);
            this.lockN5.Name = "lockN5";
            this.lockN5.Size = new System.Drawing.Size(16, 24);
            this.lockN5.TabIndex = 41;
            this.lockN5.Tag = "sortingkind.lockedn5:S:N";
            // 
            // forceN5
            // 
            this.forceN5.Location = new System.Drawing.Point(272, 152);
            this.forceN5.Name = "forceN5";
            this.forceN5.Size = new System.Drawing.Size(16, 24);
            this.forceN5.TabIndex = 42;
            this.forceN5.Tag = "sortingkind.forcedn5:S:N";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(40, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 93;
            this.label15.Text = "Valuta 5";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(104, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 72;
            this.label9.Text = "Etichetta";
            // 
            // etN4
            // 
            this.etN4.Location = new System.Drawing.Point(112, 126);
            this.etN4.Name = "etN4";
            this.etN4.Size = new System.Drawing.Size(104, 20);
            this.etN4.TabIndex = 37;
            this.etN4.Tag = "sortingkind.labeln4";
            this.etN4.Text = "etN4";
            this.etN4.TextChanged += new System.EventHandler(this.etS5_TextChanged);
            // 
            // lockN4
            // 
            this.lockN4.Location = new System.Drawing.Point(234, 120);
            this.lockN4.Name = "lockN4";
            this.lockN4.Size = new System.Drawing.Size(16, 24);
            this.lockN4.TabIndex = 38;
            this.lockN4.Tag = "sortingkind.lockedn4:S:N";
            // 
            // forceN4
            // 
            this.forceN4.Location = new System.Drawing.Point(272, 120);
            this.forceN4.Name = "forceN4";
            this.forceN4.Size = new System.Drawing.Size(16, 24);
            this.forceN4.TabIndex = 39;
            this.forceN4.Tag = "sortingkind.forcedn4:S:N";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(40, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 68;
            this.label8.Text = "Valuta 4";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // etN3
            // 
            this.etN3.Location = new System.Drawing.Point(112, 100);
            this.etN3.Name = "etN3";
            this.etN3.Size = new System.Drawing.Size(104, 20);
            this.etN3.TabIndex = 34;
            this.etN3.Tag = "sortingkind.labeln3";
            this.etN3.Text = "etN3";
            this.etN3.TextChanged += new System.EventHandler(this.etS5_TextChanged);
            // 
            // lockN3
            // 
            this.lockN3.Location = new System.Drawing.Point(234, 96);
            this.lockN3.Name = "lockN3";
            this.lockN3.Size = new System.Drawing.Size(16, 24);
            this.lockN3.TabIndex = 35;
            this.lockN3.Tag = "sortingkind.lockedn3:S:N";
            // 
            // forceN3
            // 
            this.forceN3.Location = new System.Drawing.Point(272, 96);
            this.forceN3.Name = "forceN3";
            this.forceN3.Size = new System.Drawing.Size(16, 24);
            this.forceN3.TabIndex = 36;
            this.forceN3.Tag = "sortingkind.forcedn3:S:N";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(40, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 64;
            this.label7.Text = "Valuta 3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // etN2
            // 
            this.etN2.Location = new System.Drawing.Point(112, 72);
            this.etN2.Name = "etN2";
            this.etN2.Size = new System.Drawing.Size(104, 20);
            this.etN2.TabIndex = 31;
            this.etN2.Tag = "sortingkind.labeln2";
            this.etN2.Text = "etN2";
            this.etN2.TextChanged += new System.EventHandler(this.etS5_TextChanged);
            // 
            // lockN2
            // 
            this.lockN2.Location = new System.Drawing.Point(234, 64);
            this.lockN2.Name = "lockN2";
            this.lockN2.Size = new System.Drawing.Size(16, 24);
            this.lockN2.TabIndex = 32;
            this.lockN2.Tag = "sortingkind.lockedn2:S:N";
            // 
            // forceN2
            // 
            this.forceN2.Location = new System.Drawing.Point(272, 64);
            this.forceN2.Name = "forceN2";
            this.forceN2.Size = new System.Drawing.Size(16, 24);
            this.forceN2.TabIndex = 33;
            this.forceN2.Tag = "sortingkind.forcedn2:S:N";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 60;
            this.label4.Text = "Valuta 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(264, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 59;
            this.label5.Text = "obbligatorio";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Invisibile";
            // 
            // etN1
            // 
            this.etN1.Location = new System.Drawing.Point(112, 40);
            this.etN1.Name = "etN1";
            this.etN1.Size = new System.Drawing.Size(104, 20);
            this.etN1.TabIndex = 28;
            this.etN1.Tag = "sortingkind.labeln1";
            this.etN1.Text = "etN1";
            this.etN1.TextChanged += new System.EventHandler(this.etS5_TextChanged);
            // 
            // lockN1
            // 
            this.lockN1.Location = new System.Drawing.Point(234, 32);
            this.lockN1.Name = "lockN1";
            this.lockN1.Size = new System.Drawing.Size(16, 24);
            this.lockN1.TabIndex = 29;
            this.lockN1.Tag = "sortingkind.lockedn1:S:N";
            // 
            // forceN1
            // 
            this.forceN1.Location = new System.Drawing.Point(272, 32);
            this.forceN1.Name = "forceN1";
            this.forceN1.Size = new System.Drawing.Size(16, 24);
            this.forceN1.TabIndex = 30;
            this.forceN1.Tag = "sortingkind.forcedn1:S:N";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(40, 41);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 16);
            this.label20.TabIndex = 54;
            this.label20.Text = "Valuta 1";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(190, 196);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(432, 16);
            this.label34.TabIndex = 127;
            this.label34.Text = "Nota: scegliendo Invisibile=\'grigiato\' il campo sarà visibile ma non modificabile" +
    ".";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(425, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(72, 16);
            this.label24.TabIndex = 125;
            this.label24.Text = "Etichetta";
            // 
            // etV4
            // 
            this.etV4.Location = new System.Drawing.Point(433, 125);
            this.etV4.Name = "etV4";
            this.etV4.Size = new System.Drawing.Size(104, 20);
            this.etV4.TabIndex = 52;
            this.etV4.Tag = "sortingkind.labelv4";
            this.etV4.Text = "etV4";
            // 
            // etV3
            // 
            this.etV3.Location = new System.Drawing.Point(433, 101);
            this.etV3.Name = "etV3";
            this.etV3.Size = new System.Drawing.Size(104, 20);
            this.etV3.TabIndex = 49;
            this.etV3.Tag = "sortingkind.labelv3";
            this.etV3.Text = "etV3";
            // 
            // etV2
            // 
            this.etV2.Location = new System.Drawing.Point(433, 69);
            this.etV2.Name = "etV2";
            this.etV2.Size = new System.Drawing.Size(104, 20);
            this.etV2.TabIndex = 46;
            this.etV2.Tag = "sortingkind.labelv2";
            this.etV2.Text = "etV2";
            // 
            // etV1
            // 
            this.etV1.Location = new System.Drawing.Point(433, 37);
            this.etV1.Name = "etV1";
            this.etV1.Size = new System.Drawing.Size(104, 20);
            this.etV1.TabIndex = 43;
            this.etV1.Tag = "sortingkind.labelv1";
            this.etV1.Text = "etV1";
            // 
            // etV5
            // 
            this.etV5.Location = new System.Drawing.Point(433, 152);
            this.etV5.Name = "etV5";
            this.etV5.Size = new System.Drawing.Size(104, 20);
            this.etV5.TabIndex = 55;
            this.etV5.Tag = "sortingkind.labelv5";
            this.etV5.Text = "etV5";
            // 
            // forceV5
            // 
            this.forceV5.Location = new System.Drawing.Point(577, 149);
            this.forceV5.Name = "forceV5";
            this.forceV5.Size = new System.Drawing.Size(16, 24);
            this.forceV5.TabIndex = 57;
            this.forceV5.Tag = "sortingkind.forcedv5:S:N";
            // 
            // lockV4
            // 
            this.lockV4.Location = new System.Drawing.Point(545, 117);
            this.lockV4.Name = "lockV4";
            this.lockV4.Size = new System.Drawing.Size(16, 24);
            this.lockV4.TabIndex = 53;
            this.lockV4.Tag = "sortingkind.lockedv4:S:N";
            // 
            // forceV4
            // 
            this.forceV4.Location = new System.Drawing.Point(577, 117);
            this.forceV4.Name = "forceV4";
            this.forceV4.Size = new System.Drawing.Size(16, 24);
            this.forceV4.TabIndex = 54;
            this.forceV4.Tag = "sortingkind.forcedv4:S:N";
            // 
            // lockV3
            // 
            this.lockV3.Location = new System.Drawing.Point(545, 93);
            this.lockV3.Name = "lockV3";
            this.lockV3.Size = new System.Drawing.Size(16, 24);
            this.lockV3.TabIndex = 50;
            this.lockV3.Tag = "sortingkind.lockedv3:S:N";
            // 
            // forceV3
            // 
            this.forceV3.Location = new System.Drawing.Point(577, 93);
            this.forceV3.Name = "forceV3";
            this.forceV3.Size = new System.Drawing.Size(16, 24);
            this.forceV3.TabIndex = 51;
            this.forceV3.Tag = "sortingkind.forcedv3:S:N";
            // 
            // lockV2
            // 
            this.lockV2.Location = new System.Drawing.Point(545, 61);
            this.lockV2.Name = "lockV2";
            this.lockV2.Size = new System.Drawing.Size(16, 24);
            this.lockV2.TabIndex = 47;
            this.lockV2.Tag = "sortingkind.lockedv2:S:N";
            // 
            // forceV2
            // 
            this.forceV2.Location = new System.Drawing.Point(577, 61);
            this.forceV2.Name = "forceV2";
            this.forceV2.Size = new System.Drawing.Size(16, 24);
            this.forceV2.TabIndex = 48;
            this.forceV2.Tag = "sortingkind.forcedv2:S:N";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(569, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 16);
            this.label27.TabIndex = 121;
            this.label27.Text = "obbligatorio";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(521, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 16);
            this.label28.TabIndex = 120;
            this.label28.Text = "Invisibile";
            // 
            // lockV1
            // 
            this.lockV1.Location = new System.Drawing.Point(545, 29);
            this.lockV1.Name = "lockV1";
            this.lockV1.Size = new System.Drawing.Size(16, 24);
            this.lockV1.TabIndex = 44;
            this.lockV1.Tag = "sortingkind.lockedv1:S:N";
            // 
            // forceV1
            // 
            this.forceV1.Location = new System.Drawing.Point(577, 29);
            this.forceV1.Name = "forceV1";
            this.forceV1.Size = new System.Drawing.Size(16, 24);
            this.forceV1.TabIndex = 45;
            this.forceV1.Tag = "sortingkind.forcedv1:S:N";
            // 
            // lockV5
            // 
            this.lockV5.Location = new System.Drawing.Point(545, 149);
            this.lockV5.Name = "lockV5";
            this.lockV5.Size = new System.Drawing.Size(16, 24);
            this.lockV5.TabIndex = 56;
            this.lockV5.Tag = "sortingkind.lockedv5:S:N";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(353, 149);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(64, 16);
            this.label29.TabIndex = 126;
            this.label29.Text = "Valore 5";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(353, 117);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 16);
            this.label30.TabIndex = 124;
            this.label30.Text = "Valore 4";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(353, 93);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(64, 16);
            this.label31.TabIndex = 123;
            this.label31.Text = "Valore 3";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(353, 69);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 16);
            this.label32.TabIndex = 122;
            this.label32.Text = "Valore 2";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(353, 37);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 16);
            this.label33.TabIndex = 119;
            this.label33.Text = "Valore 1";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // etDate
            // 
            this.etDate.Location = new System.Drawing.Point(142, 253);
            this.etDate.Name = "etDate";
            this.etDate.Size = new System.Drawing.Size(232, 20);
            this.etDate.TabIndex = 58;
            this.etDate.Tag = "sortingkind.labelfordate";
            // 
            // etichettaignoradate
            // 
            this.etichettaignoradate.Location = new System.Drawing.Point(380, 253);
            this.etichettaignoradate.Name = "etichettaignoradate";
            this.etichettaignoradate.Size = new System.Drawing.Size(232, 20);
            this.etichettaignoradate.TabIndex = 59;
            this.etichettaignoradate.Tag = "sortingkind.nodatelabel";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(380, 229);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(256, 16);
            this.label25.TabIndex = 103;
            this.label25.Text = "Etichetta da usare quando le date vanno ignorate";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(142, 229);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(160, 16);
            this.label26.TabIndex = 101;
            this.label26.Text = "Etichetta per intervallo date";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(16, 152);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(256, 16);
            this.label23.TabIndex = 109;
            this.label23.Text = "Espressione da usare per il totale classificato";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 168);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(392, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Tag = "sortingkind.totalexpression";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(336, 136);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 24);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Tag = "sortingkind.active:S:N";
            this.checkBox5.Text = "Attivo";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Controls.Add(this.tabPage2);
            this.MetaDataDetail.Controls.Add(this.tabPage3);
            this.MetaDataDetail.Controls.Add(this.tabPage4);
            this.MetaDataDetail.Location = new System.Drawing.Point(16, 386);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(840, 313);
            this.MetaDataDetail.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtCodice);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtDenom);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(832, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mov.Finanziari";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(405, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 17);
            this.checkBox1.TabIndex = 112;
            this.checkBox1.Tag = "sortingkind.flag:2";
            this.checkBox1.Text = "Piano dei Conti";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usaDate);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Location = new System.Drawing.Point(336, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impostazioni SOLO per il finanziario";
            // 
            // usaDate
            // 
            this.usaDate.AutoSize = true;
            this.usaDate.Location = new System.Drawing.Point(16, 80);
            this.usaDate.Name = "usaDate";
            this.usaDate.Size = new System.Drawing.Size(162, 17);
            this.usaDate.TabIndex = 13;
            this.usaDate.Tag = "sortingkind.flagdate:S:N";
            this.usaDate.Text = "Usa Campi Data Inizio e Fine";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(16, 56);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Tag = "sortingkind.flag:0";
            this.checkBox3.Text = "Classificazione obbligatoria";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 32);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(348, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Tag = "sortingkind.flag:1";
            this.checkBox2.Text = "Effettua controllo di disponibilità della previsione di entrata e di spesa";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(96, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 111;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lockN1);
            this.tabPage2.Controls.Add(this.etDate);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.etN5);
            this.tabPage2.Controls.Add(this.lockN5);
            this.tabPage2.Controls.Add(this.forceN5);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.forceN1);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.etN4);
            this.tabPage2.Controls.Add(this.lockN4);
            this.tabPage2.Controls.Add(this.forceN4);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.etN3);
            this.tabPage2.Controls.Add(this.lockN3);
            this.tabPage2.Controls.Add(this.forceN3);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.etN2);
            this.tabPage2.Controls.Add(this.lockN2);
            this.tabPage2.Controls.Add(this.forceN2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.etV4);
            this.tabPage2.Controls.Add(this.etV3);
            this.tabPage2.Controls.Add(this.etV2);
            this.tabPage2.Controls.Add(this.etV1);
            this.tabPage2.Controls.Add(this.etV5);
            this.tabPage2.Controls.Add(this.forceV5);
            this.tabPage2.Controls.Add(this.lockV4);
            this.tabPage2.Controls.Add(this.forceV4);
            this.tabPage2.Controls.Add(this.lockV3);
            this.tabPage2.Controls.Add(this.forceV3);
            this.tabPage2.Controls.Add(this.lockV2);
            this.tabPage2.Controls.Add(this.forceV2);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.label28);
            this.tabPage2.Controls.Add(this.lockV1);
            this.tabPage2.Controls.Add(this.forceV1);
            this.tabPage2.Controls.Add(this.lockV5);
            this.tabPage2.Controls.Add(this.label29);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.label31);
            this.tabPage2.Controls.Add(this.label32);
            this.tabPage2.Controls.Add(this.label33);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.etN1);
            this.tabPage2.Controls.Add(this.etichettaignoradate);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(832, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Campi Aggiuntivi";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cmbClassPrecedente);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.comboBox1);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(832, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Applicabilità";
            // 
            // cmbClassPrecedente
            // 
            this.cmbClassPrecedente.DataSource = this.DS.sortingkind1;
            this.cmbClassPrecedente.DisplayMember = "description";
            this.cmbClassPrecedente.FormattingEnabled = true;
            this.cmbClassPrecedente.Location = new System.Drawing.Point(432, 198);
            this.cmbClassPrecedente.Name = "cmbClassPrecedente";
            this.cmbClassPrecedente.Size = new System.Drawing.Size(269, 21);
            this.cmbClassPrecedente.TabIndex = 233;
            this.cmbClassPrecedente.Tag = "sortingkind.idparentkind";
            this.cmbClassPrecedente.ValueMember = "idsorkind";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(521, 182);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(172, 13);
            this.label36.TabIndex = 232;
            this.label36.Text = "Classificazione della fase principale";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(636, 127);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 231;
            this.textBox1.Tag = "sortingkind.stop.year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Anno fine";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(492, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(66, 20);
            this.textBox3.TabIndex = 230;
            this.textBox3.Tag = "sortingkind.start.year";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(429, 130);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(58, 13);
            this.label35.TabIndex = 0;
            this.label35.Text = "Anno inizio";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.incomephase;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(425, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 21);
            this.comboBox1.TabIndex = 108;
            this.comboBox1.Tag = "sortingkind.nphaseincome";
            this.comboBox1.ValueMember = "nphase";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(417, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(285, 23);
            this.label21.TabIndex = 110;
            this.label21.Text = "Fase per classificazione mov. di Entrata";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(411, 76);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(291, 16);
            this.label22.TabIndex = 111;
            this.label22.Text = "Fase per classificazione mov. di Spesa";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.DS.expensephase;
            this.comboBox2.DisplayMember = "description";
            this.comboBox2.Location = new System.Drawing.Point(425, 94);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(277, 21);
            this.comboBox2.TabIndex = 109;
            this.comboBox2.Tag = "sortingkind.nphaseexpense";
            this.comboBox2.ValueMember = "nphase";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(400, 23);
            this.label19.TabIndex = 1;
            this.label19.Text = "Tabelle a cui si può applicare la classificazione";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(8, 32);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(400, 224);
            this.listView1.TabIndex = 0;
            this.listView1.Tag = "sortabletable.solodescrizione";
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.textBox8);
            this.tabPage4.Controls.Add(this.textBox7);
            this.tabPage4.Controls.Add(this.textBox6);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.lockS5);
            this.tabPage4.Controls.Add(this.forceS5);
            this.tabPage4.Controls.Add(this.etS4);
            this.tabPage4.Controls.Add(this.etS5);
            this.tabPage4.Controls.Add(this.forceS4);
            this.tabPage4.Controls.Add(this.etS3);
            this.tabPage4.Controls.Add(this.lockS3);
            this.tabPage4.Controls.Add(this.forceS3);
            this.tabPage4.Controls.Add(this.lockS4);
            this.tabPage4.Controls.Add(this.lockS2);
            this.tabPage4.Controls.Add(this.forceS2);
            this.tabPage4.Controls.Add(this.etS1);
            this.tabPage4.Controls.Add(this.lockS1);
            this.tabPage4.Controls.Add(this.etS2);
            this.tabPage4.Controls.Add(this.forceS1);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.textBox5);
            this.tabPage4.Controls.Add(this.textBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(832, 287);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Valori ammessi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(202, 18);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(259, 16);
            this.label37.TabIndex = 158;
            this.label37.Text = "Valori ammessi(value1|value2|...valueN)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(195, 46);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(266, 36);
            this.textBox8.TabIndex = 157;
            this.textBox8.Tag = "sortingkind.allowedS1";
            this.textBox8.Text = "valS1";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(195, 88);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(266, 36);
            this.textBox7.TabIndex = 156;
            this.textBox7.Tag = "sortingkind.allowedS2";
            this.textBox7.Text = "valS2";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(195, 133);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(266, 36);
            this.textBox6.TabIndex = 155;
            this.textBox6.Tag = "sortingkind.allowedS3";
            this.textBox6.Text = "valS3";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(78, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 16);
            this.label16.TabIndex = 152;
            this.label16.Text = "Etichetta";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(535, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 149;
            this.label17.Text = "obbligatorio";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(484, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 16);
            this.label18.TabIndex = 148;
            this.label18.Text = "Invisibile";
            // 
            // lockS5
            // 
            this.lockS5.Location = new System.Drawing.Point(500, 223);
            this.lockS5.Name = "lockS5";
            this.lockS5.Size = new System.Drawing.Size(16, 24);
            this.lockS5.TabIndex = 145;
            this.lockS5.Tag = "sortingkind.lockeds5:S:N";
            // 
            // forceS5
            // 
            this.forceS5.Location = new System.Drawing.Point(543, 223);
            this.forceS5.Name = "forceS5";
            this.forceS5.Size = new System.Drawing.Size(16, 24);
            this.forceS5.TabIndex = 146;
            this.forceS5.Tag = "sortingkind.forceds5:S:N";
            // 
            // etS4
            // 
            this.etS4.Location = new System.Drawing.Point(76, 176);
            this.etS4.Name = "etS4";
            this.etS4.Size = new System.Drawing.Size(109, 20);
            this.etS4.TabIndex = 141;
            this.etS4.Tag = "sortingkind.labels4";
            this.etS4.Text = "etS4";
            // 
            // etS5
            // 
            this.etS5.Location = new System.Drawing.Point(76, 223);
            this.etS5.Name = "etS5";
            this.etS5.Size = new System.Drawing.Size(109, 20);
            this.etS5.TabIndex = 144;
            this.etS5.Tag = "sortingkind.labels5";
            this.etS5.Text = "etS5";
            // 
            // forceS4
            // 
            this.forceS4.Location = new System.Drawing.Point(543, 176);
            this.forceS4.Name = "forceS4";
            this.forceS4.Size = new System.Drawing.Size(16, 24);
            this.forceS4.TabIndex = 143;
            this.forceS4.Tag = "sortingkind.forceds4:S:N";
            // 
            // etS3
            // 
            this.etS3.Location = new System.Drawing.Point(81, 133);
            this.etS3.Name = "etS3";
            this.etS3.Size = new System.Drawing.Size(104, 20);
            this.etS3.TabIndex = 138;
            this.etS3.Tag = "sortingkind.labels3";
            this.etS3.Text = "etS3";
            this.etS3.TextChanged += new System.EventHandler(this.etS3_TextChanged);
            // 
            // lockS3
            // 
            this.lockS3.Location = new System.Drawing.Point(500, 136);
            this.lockS3.Name = "lockS3";
            this.lockS3.Size = new System.Drawing.Size(16, 24);
            this.lockS3.TabIndex = 139;
            this.lockS3.Tag = "sortingkind.lockeds3:S:N";
            // 
            // forceS3
            // 
            this.forceS3.Location = new System.Drawing.Point(543, 133);
            this.forceS3.Name = "forceS3";
            this.forceS3.Size = new System.Drawing.Size(16, 24);
            this.forceS3.TabIndex = 140;
            this.forceS3.Tag = "sortingkind.forceds3:S:N";
            // 
            // lockS4
            // 
            this.lockS4.Location = new System.Drawing.Point(500, 176);
            this.lockS4.Name = "lockS4";
            this.lockS4.Size = new System.Drawing.Size(16, 24);
            this.lockS4.TabIndex = 142;
            this.lockS4.Tag = "sortingkind.lockeds4:S:N";
            // 
            // lockS2
            // 
            this.lockS2.Location = new System.Drawing.Point(500, 92);
            this.lockS2.Name = "lockS2";
            this.lockS2.Size = new System.Drawing.Size(16, 24);
            this.lockS2.TabIndex = 136;
            this.lockS2.Tag = "sortingkind.lockeds2:S:N";
            // 
            // forceS2
            // 
            this.forceS2.Location = new System.Drawing.Point(543, 87);
            this.forceS2.Name = "forceS2";
            this.forceS2.Size = new System.Drawing.Size(16, 24);
            this.forceS2.TabIndex = 137;
            this.forceS2.Tag = "sortingkind.forceds2:S:N";
            // 
            // etS1
            // 
            this.etS1.Location = new System.Drawing.Point(81, 46);
            this.etS1.Name = "etS1";
            this.etS1.Size = new System.Drawing.Size(104, 20);
            this.etS1.TabIndex = 132;
            this.etS1.Tag = "sortingkind.labels1";
            this.etS1.Text = "etS1";
            // 
            // lockS1
            // 
            this.lockS1.Location = new System.Drawing.Point(500, 46);
            this.lockS1.Name = "lockS1";
            this.lockS1.Size = new System.Drawing.Size(16, 24);
            this.lockS1.TabIndex = 133;
            this.lockS1.Tag = "sortingkind.lockeds1:S:N";
            // 
            // etS2
            // 
            this.etS2.Location = new System.Drawing.Point(81, 88);
            this.etS2.Name = "etS2";
            this.etS2.Size = new System.Drawing.Size(104, 20);
            this.etS2.TabIndex = 135;
            this.etS2.Tag = "sortingkind.labels2";
            this.etS2.Text = "etS2";
            // 
            // forceS1
            // 
            this.forceS1.Location = new System.Drawing.Point(543, 46);
            this.forceS1.Name = "forceS1";
            this.forceS1.Size = new System.Drawing.Size(16, 24);
            this.forceS1.TabIndex = 134;
            this.forceS1.Tag = "sortingkind.forceds1:S:N";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 225);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 154;
            this.label14.Text = "Testo 5";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(15, 175);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 153;
            this.label13.Text = "Testo 4";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(20, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 151;
            this.label12.Text = "Testo 3";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(22, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 24);
            this.label11.TabIndex = 150;
            this.label11.Text = "Testo 2";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(25, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 24);
            this.label10.TabIndex = 147;
            this.label10.Text = "Testo 1";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(195, 178);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(266, 36);
            this.textBox5.TabIndex = 131;
            this.textBox5.Tag = "sortingkind.allowedS4";
            this.textBox5.Text = "valS4";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(195, 223);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(266, 36);
            this.textBox4.TabIndex = 130;
            this.textBox4.Tag = "sortingkind.allowedS5";
            this.textBox4.Text = "valS5";
            // 
            // Frm_sortingkind_lista
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(864, 704);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "Frm_sortingkind_lista";
            this.Text = "frmTipoClassMovimentiBase";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		void Check(TextBox T, CheckBox Rlocked, CheckBox Rforced) {
			if (T.Text.ToString().Equals("")){
				Rlocked.Checked=true;
				Rlocked.Enabled=false;
				Rforced.Checked=false;
				Rforced.Enabled=false;
			}
			else {
				Rlocked.Enabled=true;
				Rforced.Enabled=true;
			}
		}
		void CheckAll() {
			Check(etN1,lockN1,forceN1);
			Check(etN2,lockN2,forceN2);
			Check(etN3,lockN3,forceN3);
			Check(etN4,lockN4,forceN4);
			Check(etN5,lockN5,forceN5);
			Check(etS1,lockS1,forceS1);
			Check(etS2,lockS2,forceS2);
			Check(etS3,lockS3,forceS3);
			Check(etS4,lockS4,forceS4);
			Check(etS5,lockS5,forceS5);
			Check(etV1,lockV1,forceV1);
			Check(etV2,lockV2,forceV2);
			Check(etV3,lockV3,forceV3);
			Check(etV4,lockV4,forceV4);
			Check(etV5,lockV5,forceV5);
		}

		private void etS5_TextChanged(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (Meta.DrawState!= MetaData.form_drawstates.done) return;
			CheckAll();
		}


		private void usaDate_CheckedChanged(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (Meta.DrawState!= MetaData.form_drawstates.done) return;
			
			etDate.Enabled=usaDate.Checked;
			etDate.Enabled=usaDate.Checked;
			etDate.ReadOnly=!usaDate.Checked;
			etDate.ReadOnly=!usaDate.Checked;
			etichettaignoradate.Enabled = usaDate.Checked;
			etichettaignoradate.Enabled=usaDate.Checked;
			etichettaignoradate.ReadOnly=!usaDate.Checked;
			etichettaignoradate.ReadOnly=!usaDate.Checked;

		}

        private void etS3_TextChanged(object sender, EventArgs e) {

        }
    }
}
