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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;
namespace inventorytree_default//classinventario//
{
	/// <summary>
	/// Summary description for frmclassinventario.
	/// </summary>
	public class Frm_inventorytree_default : System.Windows.Forms.Form {
        public TreeView treeView1;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabGeneralita;
		private System.Windows.Forms.Button btnDoSituazione;
		private System.Windows.Forms.TabPage tabClassSupp;
		private System.Windows.Forms.DataGrid dGridClassSup;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		public dsmeta DS;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
		private MetaData Meta;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.Label lblLivello;
        private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ImageList imageList1;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleScarico;
        private Button button4;
        private GroupBox groupBox2;
        private TextBox textBox3;
        private TextBox txtCodiceCausaleCarico;
        private Button button5;
        private TabPage tabPage2;
        private ListView listCodiciCampiAggiuntivi;
        private GroupBox grpCampiAggiuntivi;
        private TabPage tabConsolidamento;
        private TextBox textBox2;
        private Label label1;
        private Splitter splitter1;
        private GroupBox groupBox3;
        private TextBox textBox4;
        public TextBox txtCodiceCausaleSconto;
        private Button button6;
        private GroupBox groupBox4;
        private TextBox textBox5;
        private TextBox txtCodiceCausaleTrasferimento;
        private Button button7;
        private DataAccess Conn;

		public Frm_inventorytree_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            DataAccess.SetTableForReading(DS.accmotiveapplied_load, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_unload, "accmotiveapplied");
		    DataAccess.SetTableForReading(DS.accmotiveapplied_discount, "accmotiveapplied");
	        
		
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
        QueryHelper QHS;
        CQueryHelper QHC;
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_inventorytree_default));
            this.DS = new inventorytree_default.dsmeta();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabGeneralita = new System.Windows.Forms.TabPage();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.lblLivello = new System.Windows.Forms.Label();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.btnDoSituazione = new System.Windows.Forms.Button();
            this.tabClassSupp = new System.Windows.Forms.TabPage();
            this.dGridClassSup = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleSconto = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleCarico = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleScarico = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpCampiAggiuntivi = new System.Windows.Forms.GroupBox();
            this.listCodiciCampiAggiuntivi = new System.Windows.Forms.ListView();
            this.tabConsolidamento = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleTrasferimento = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabGeneralita.SuspendLayout();
            this.tabClassSupp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpCampiAggiuntivi.SuspendLayout();
            this.tabConsolidamento.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 1;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(214, 594);
            this.treeView1.TabIndex = 3;
            this.treeView1.Tag = "inventorytree.default";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabGeneralita);
            this.MetaDataDetail.Controls.Add(this.tabClassSupp);
            this.MetaDataDetail.Controls.Add(this.tabPage5);
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Controls.Add(this.tabPage2);
            this.MetaDataDetail.Controls.Add(this.tabConsolidamento);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(214, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(606, 594);
            this.MetaDataDetail.TabIndex = 4;
            // 
            // tabGeneralita
            // 
            this.tabGeneralita.Controls.Add(this.txtDenominazione);
            this.tabGeneralita.Controls.Add(this.lblDenominazione);
            this.tabGeneralita.Controls.Add(this.txtCodice);
            this.tabGeneralita.Controls.Add(this.lblCodice);
            this.tabGeneralita.Controls.Add(this.lblLivello);
            this.tabGeneralita.Controls.Add(this.cmbLivello);
            this.tabGeneralita.Controls.Add(this.btnDoSituazione);
            this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
            this.tabGeneralita.Name = "tabGeneralita";
            this.tabGeneralita.Size = new System.Drawing.Size(598, 567);
            this.tabGeneralita.TabIndex = 0;
            this.tabGeneralita.Text = "Principale";
            this.tabGeneralita.UseVisualStyleBackColor = true;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(16, 89);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(566, 175);
            this.txtDenominazione.TabIndex = 3;
            this.txtDenominazione.Tag = "inventorytree.description";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(16, 70);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(88, 16);
            this.lblDenominazione.TabIndex = 35;
            this.lblDenominazione.Text = "Denominazione:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(208, 24);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(168, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "inventorytree.codeinv";
            // 
            // lblCodice
            // 
            this.lblCodice.Location = new System.Drawing.Point(192, 8);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(56, 16);
            this.lblCodice.TabIndex = 33;
            this.lblCodice.Text = "Codice:";
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLivello
            // 
            this.lblLivello.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLivello.Location = new System.Drawing.Point(16, 8);
            this.lblLivello.Name = "lblLivello";
            this.lblLivello.Size = new System.Drawing.Size(96, 14);
            this.lblLivello.TabIndex = 31;
            this.lblLivello.Text = "Livello:";
            this.lblLivello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.inventorysortinglevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(16, 24);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(168, 21);
            this.cmbLivello.TabIndex = 1;
            this.cmbLivello.Tag = "inventorytree.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // btnDoSituazione
            // 
            this.btnDoSituazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoSituazione.Location = new System.Drawing.Point(502, 24);
            this.btnDoSituazione.Name = "btnDoSituazione";
            this.btnDoSituazione.Size = new System.Drawing.Size(72, 23);
            this.btnDoSituazione.TabIndex = 4;
            this.btnDoSituazione.Text = "Situazione";
            this.btnDoSituazione.Click += new System.EventHandler(this.btnDoSituazione_Click);
            // 
            // tabClassSupp
            // 
            this.tabClassSupp.Controls.Add(this.dGridClassSup);
            this.tabClassSupp.Controls.Add(this.btnElimina);
            this.tabClassSupp.Controls.Add(this.btnModifica);
            this.tabClassSupp.Controls.Add(this.btnInserisci);
            this.tabClassSupp.ImageIndex = 0;
            this.tabClassSupp.Location = new System.Drawing.Point(4, 23);
            this.tabClassSupp.Name = "tabClassSupp";
            this.tabClassSupp.Size = new System.Drawing.Size(598, 567);
            this.tabClassSupp.TabIndex = 1;
            this.tabClassSupp.Text = "Classificazione";
            this.tabClassSupp.UseVisualStyleBackColor = true;
            this.tabClassSupp.Visible = false;
            // 
            // dGridClassSup
            // 
            this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridClassSup.CaptionVisible = false;
            this.dGridClassSup.DataMember = "";
            this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridClassSup.Location = new System.Drawing.Point(88, 8);
            this.dGridClassSup.Name = "dGridClassSup";
            this.dGridClassSup.Size = new System.Drawing.Size(501, 548);
            this.dGridClassSup.TabIndex = 14;
            this.dGridClassSup.Tag = "inventorytreesorting.default";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(8, 72);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 13;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(8, 40);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 12;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(8, 8);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 11;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dataGrid1);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.button2);
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(598, 567);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Ammortamento";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(88, 9);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(501, 548);
            this.dataGrid1.TabIndex = 18;
            this.dataGrid1.Tag = "inventorysortingamortizationyear.default.default";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 17;
            this.button1.Tag = "delete";
            this.button1.Text = "Elimina";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 24);
            this.button2.TabIndex = 16;
            this.button2.Tag = "edit.default";
            this.button2.Text = "Modifica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(72, 24);
            this.button3.TabIndex = 15;
            this.button3.Tag = "insert.default";
            this.button3.Text = "Inserisci";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 567);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "EP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.txtCodiceCausaleSconto);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Location = new System.Drawing.Point(19, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(449, 118);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoManage.txtCodiceCausaleSconto.tree.(in_use=\'S\')";
            this.groupBox3.Text = "Causale di Ricavo in applicazione sconto";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 19);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(303, 68);
            this.textBox4.TabIndex = 2;
            this.textBox4.Tag = "accmotiveapplied_discount.motive?x";
            // 
            // txtCodiceCausaleSconto
            // 
            this.txtCodiceCausaleSconto.Location = new System.Drawing.Point(6, 93);
            this.txtCodiceCausaleSconto.Name = "txtCodiceCausaleSconto";
            this.txtCodiceCausaleSconto.Size = new System.Drawing.Size(435, 20);
            this.txtCodiceCausaleSconto.TabIndex = 1;
            this.txtCodiceCausaleSconto.Tag = "accmotiveapplied_discount.codemotive?x";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 24);
            this.button6.TabIndex = 0;
            this.button6.Tag = "manage.accmotiveapplied_discount.tree";
            this.button6.Text = "Causale";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.txtCodiceCausaleCarico);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Location = new System.Drawing.Point(19, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(449, 107);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtCodiceCausaleCarico.tree.(in_use=\'S\')";
            this.groupBox2.Text = "Causale di Carico";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(140, 18);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(303, 56);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "accmotiveapplied_load.motive?x";
            // 
            // txtCodiceCausaleCarico
            // 
            this.txtCodiceCausaleCarico.Location = new System.Drawing.Point(8, 81);
            this.txtCodiceCausaleCarico.Name = "txtCodiceCausaleCarico";
            this.txtCodiceCausaleCarico.Size = new System.Drawing.Size(435, 20);
            this.txtCodiceCausaleCarico.TabIndex = 1;
            this.txtCodiceCausaleCarico.Tag = "accmotiveapplied_load.codemotive?x";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 24);
            this.button5.TabIndex = 0;
            this.button5.Tag = "manage.accmotiveapplied_load.tree";
            this.button5.Text = "Causale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtCodiceCausaleScarico);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Location = new System.Drawing.Point(19, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 108);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceCausaleScarico.tree.(in_use=\'S\')";
            this.groupBox1.Text = "Causale di Scarico";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(140, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(303, 62);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "accmotiveapplied_unload.motive?x";
            // 
            // txtCodiceCausaleScarico
            // 
            this.txtCodiceCausaleScarico.Location = new System.Drawing.Point(8, 82);
            this.txtCodiceCausaleScarico.Name = "txtCodiceCausaleScarico";
            this.txtCodiceCausaleScarico.Size = new System.Drawing.Size(435, 20);
            this.txtCodiceCausaleScarico.TabIndex = 1;
            this.txtCodiceCausaleScarico.Tag = "accmotiveapplied_unload.codemotive?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 24);
            this.button4.TabIndex = 0;
            this.button4.Tag = "manage.accmotiveapplied_unload.tree";
            this.button4.Text = "Causale";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpCampiAggiuntivi);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 567);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Altri Dati";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpCampiAggiuntivi
            // 
            this.grpCampiAggiuntivi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCampiAggiuntivi.Controls.Add(this.listCodiciCampiAggiuntivi);
            this.grpCampiAggiuntivi.Location = new System.Drawing.Point(6, 6);
            this.grpCampiAggiuntivi.Name = "grpCampiAggiuntivi";
            this.grpCampiAggiuntivi.Size = new System.Drawing.Size(582, 268);
            this.grpCampiAggiuntivi.TabIndex = 0;
            this.grpCampiAggiuntivi.TabStop = false;
            this.grpCampiAggiuntivi.Text = "Campi aggiuntivi per cespiti";
            this.grpCampiAggiuntivi.Visible = false;
            // 
            // listCodiciCampiAggiuntivi
            // 
            this.listCodiciCampiAggiuntivi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listCodiciCampiAggiuntivi.AutoArrange = false;
            this.listCodiciCampiAggiuntivi.CheckBoxes = true;
            this.listCodiciCampiAggiuntivi.Location = new System.Drawing.Point(6, 19);
            this.listCodiciCampiAggiuntivi.Name = "listCodiciCampiAggiuntivi";
            this.listCodiciCampiAggiuntivi.Size = new System.Drawing.Size(570, 239);
            this.listCodiciCampiAggiuntivi.TabIndex = 3;
            this.listCodiciCampiAggiuntivi.Tag = "multifieldkind.solodescrizione";
            this.listCodiciCampiAggiuntivi.UseCompatibleStateImageBehavior = false;
            this.listCodiciCampiAggiuntivi.View = System.Windows.Forms.View.List;
            // 
            // tabConsolidamento
            // 
            this.tabConsolidamento.Controls.Add(this.textBox2);
            this.tabConsolidamento.Controls.Add(this.label1);
            this.tabConsolidamento.Location = new System.Drawing.Point(4, 23);
            this.tabConsolidamento.Name = "tabConsolidamento";
            this.tabConsolidamento.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsolidamento.Size = new System.Drawing.Size(598, 567);
            this.tabConsolidamento.TabIndex = 5;
            this.tabConsolidamento.Text = "Consolidamento";
            this.tabConsolidamento.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(216, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Tag = "inventorytree.lookupcode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice lookup per destinazione";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(214, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 594);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.txtCodiceCausaleTrasferimento);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Location = new System.Drawing.Point(19, 405);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(449, 118);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "AutoManage.txtCodiceCausaleTrasferimento.tree.(in_use=\'S\')";
            this.groupBox4.Text = "Causale di Carico/Scarico per trasferimento";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(140, 19);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(303, 67);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "accmotiveapplied_transfer.motive?x";
            // 
            // txtCodiceCausaleTrasferimento
            // 
            this.txtCodiceCausaleTrasferimento.Location = new System.Drawing.Point(8, 92);
            this.txtCodiceCausaleTrasferimento.Name = "txtCodiceCausaleTrasferimento";
            this.txtCodiceCausaleTrasferimento.Size = new System.Drawing.Size(435, 20);
            this.txtCodiceCausaleTrasferimento.TabIndex = 1;
            this.txtCodiceCausaleTrasferimento.Tag = "accmotiveapplied_transfer.codemotive?x";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 62);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(104, 24);
            this.button7.TabIndex = 0;
            this.button7.Tag = "manage.accmotiveapplied_transfer.tree";
            this.button7.Text = "Causale";
            // 
            // Frm_inventorytree_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(820, 594);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_inventorytree_default";
            this.Text = "frmclassinventario";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabGeneralita.ResumeLayout(false);
            this.tabGeneralita.PerformLayout();
            this.tabClassSupp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.grpCampiAggiuntivi.ResumeLayout(false);
            this.tabConsolidamento.ResumeLayout(false);
            this.tabConsolidamento.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.inventorysortinglevel, null, null, true);
			GetData.CacheTable(DS.inventoryamortization);
			GetData.SetStaticFilter(DS.inventorysortingamortizationyear,filteresercizio);

            DataAccess.SetTableForReading(DS.accmotiveapplied_load, "accmotiveapplied");
		    DataAccess.SetTableForReading(DS.accmotiveapplied_discount, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_unload, "accmotiveapplied");
		    DataAccess.SetTableForReading(DS.accmotiveapplied_transfer, "accmotiveapplied");

            DataAccess.SetTableForReading(DS.accmotive_amortization, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_amortization_unload, "accmotive");		    

            string filterEpOperationCarSF = QHS.CmpEq("idepoperation", "car_ces");
            string filterEpOperationCarEP = QHS.CmpEq("idepoperation", "car_ces");

            DS.accmotiveapplied_load.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCarEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_load, filterEpOperationCarSF);

		    DS.accmotiveapplied_discount.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCarEP;
		    GetData.SetStaticFilter(DS.accmotiveapplied_discount, filterEpOperationCarSF);



            string filterEpOperationScarSF = QHS.CmpEq("idepoperation", "scar_ces");
            string filterEpOperationScarEP = QHS.CmpEq("idepoperation", "scar_ces");
   
            DS.accmotiveapplied_unload.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationScarEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_unload, filterEpOperationScarSF);

		    DS.accmotiveapplied_transfer.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationScarEP;
		    GetData.SetStaticFilter(DS.accmotiveapplied_transfer, filterEpOperationScarSF);
		   

            GetData.CacheTable(DS.multifieldkind, null, "fieldname", false);
            
        }

		public void MetaData_AfterClear(){
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
			txtDenominazione.ReadOnly=false;
            Meta.CanInsert = false;
            grpCampiAggiuntivi.Visible = true;
		}

		public void MetaData_AfterFill(){
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			//abilita/disabilita i controlli
			bool ModoInsert= Meta.InsertMode;
			btnDoSituazione.Enabled =!ModoInsert;
			cmbLivello.Enabled=false;
            DataRow R = HelpForm.GetLastSelected(DS.inventorytree);
            if (Meta.EditMode) {
                if (R == null) grpCampiAggiuntivi.Visible = false;
                else grpCampiAggiuntivi.Visible = ((Operativo(R)) && (Foglia(R)));
            }
            if (ModoInsert){
                grpCampiAggiuntivi.Visible = false;
              	if (R==null) return;
				object livello = R["nlevel"];
				txtCodice.ReadOnly=TipoNumerico(livello);
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName != "inventorytree") return;
			cmbLivello.Enabled=false;
			bool ModoInsert=Meta.InsertMode;
			btnDoSituazione.Enabled=!ModoInsert;
			if (Operativo(R)){
				object livello = R["nlevel"];
				txtCodice.ReadOnly=!(ModoInsert && !TipoNumerico(livello));
			}
			else{
				txtCodice.ReadOnly=true;
			}
		}

		private bool Operativo(DataRow R){
			if (R==null) return false;
			object livellorow=R["nlevel"];
            string filter = QHC.CmpEq("nlevel", livellorow);
			DataRow[] Res = DS.inventorysortinglevel.Select(filter);
			if (Res.Length!=1) return false;
            byte flag = CfgFn.GetNoNullByte(Res[0]["flag"]);
			if ((flag&2)==0) return false;
			return true;
		}
        private bool Foglia (DataRow R) {
            if (R == null) return false;
            object idinv = R["idinv"];
            string filter = QHC.CmpEq("idinv", idinv);
            DataTable T = Meta.Conn.RUN_SELECT("inventorytreeusable","*",null,filter,null,false);
            if (T.Rows.Count== 0) return false;
            return true;
        }

		private bool TipoNumerico(object codicelivello){
            string filter = QHC.CmpEq("nlevel", codicelivello);
			DataRow[] Res = DS.inventorysortinglevel.Select(filter);
			if (Res.Length!=1) return false;
            byte flag = CfgFn.GetNoNullByte(Res[0]["flag"]);
            if ((flag & 1) == 0) return true;
			return false;
		}

		private void btnDoSituazione_Click(object sender, System.EventArgs e) {
			DataRow MyRow=HelpForm.GetLastSelected(DS.inventorytree);
			object idclass=(MyRow!=null?MyRow["idinv"]:null);

			DataSet Out = Conn.CallSP("show_inventorytree",
				new Object[3] {Meta.GetSys("datacontabile"),
								idclass,
								Meta.GetSys("esercizio")
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione classific.inventario";
			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }
	}
}
