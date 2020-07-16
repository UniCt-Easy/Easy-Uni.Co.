/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace assetunload_storico
{
	/// <summary>
	/// Summary description for FrmWizardScarico.
	/// </summary>
	public class FrmWizardScarico : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkIncludiAsset;
		private System.Windows.Forms.CheckBox chkIncludiAumenti;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboResponsabile;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.GroupBox grpUbicazione;
		private System.Windows.Forms.Button btnUbicazione;
		private System.Windows.Forms.TextBox txtDescUbicazione;
		private System.Windows.Forms.TextBox txtUbicazione;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cmbInventario;
		private System.Windows.Forms.TextBox txt_numinv_a;
		private System.Windows.Forms.TextBox txt_numinv_da;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_numcarico_a;
		private System.Windows.Forms.TextBox txt_numcarico_da;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_idbene_a;
		private System.Windows.Forms.TextBox txt_idbene_da;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtDescrizione;
		private Crownwood.Magic.Controls.TabControl tabController;
		MetaData Meta;
		DataAccess Conn;
		ContextMenu ExcelMenu;
		private System.Windows.Forms.TextBox txtIDUbicazione;
		private Crownwood.Magic.Controls.TabPage tabGrid;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.DataGrid gridBeni;
		public DataTable AssetPiece;
		public object CodInv;
        CQueryHelper QHC;
        QueryHelper QHS;
		private System.Windows.Forms.Button btnSelezionaTutto;
		private System.Windows.Forms.Label label16;
        private CheckBox chkReady;
		//bool SaveData;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmWizardScarico(MetaData Meta, object CodiceInventario)
		{
			InitializeComponent();

			this.Meta=Meta;
            QHC = new CQueryHelper();
            QHS = this.Meta.Conn.GetQueryHelper();
			CodInv = CodiceInventario;
			Conn= Meta.Conn;
			ExcelMenu = new ContextMenu();
			ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
			gridBeni.ContextMenu= ExcelMenu;
			FormInit();

		}

		private void Excel_Click(object menusender, EventArgs e) {
			if (menusender==null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))return;
			object sender  = ((MenuItem) menusender).Parent.GetContextMenu().SourceControl;
			if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))return;
			DataGrid G = (DataGrid) sender;
			object DDS = G.DataSource;
			if (DDS==null) return;
			if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))return;
			string DDT = G.DataMember;
			if (DDT==null) return;
			DataTable T = ((DataSet)DDS).Tables[DDT];
			if (T==null) return;
			exportclass.DataTableToExcel(T,true);
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkIncludiAsset = new System.Windows.Forms.CheckBox();
            this.chkIncludiAumenti = new System.Windows.Forms.CheckBox();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.chkReady = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.txt_numinv_a = new System.Windows.Forms.TextBox();
            this.txt_numinv_da = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_numcarico_a = new System.Windows.Forms.TextBox();
            this.txt_numcarico_da = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idbene_a = new System.Windows.Forms.TextBox();
            this.txt_idbene_da = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.txtIDUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtUbicazione = new System.Windows.Forms.TextBox();
            this.cboResponsabile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabGrid = new Crownwood.Magic.Controls.TabPage();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridBeni = new System.Windows.Forms.DataGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.grpUbicazione.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBeni)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(720, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selezionare le condizioni per identificare i beni e/o gli aumenti valore da scari" +
    "care (non Ë necessario selezionarle tutte)";
            // 
            // chkIncludiAsset
            // 
            this.chkIncludiAsset.Checked = true;
            this.chkIncludiAsset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludiAsset.Location = new System.Drawing.Point(16, 32);
            this.chkIncludiAsset.Name = "chkIncludiAsset";
            this.chkIncludiAsset.Size = new System.Drawing.Size(104, 16);
            this.chkIncludiAsset.TabIndex = 1;
            this.chkIncludiAsset.Text = "Includi cespiti";
            // 
            // chkIncludiAumenti
            // 
            this.chkIncludiAumenti.Checked = true;
            this.chkIncludiAumenti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludiAumenti.Location = new System.Drawing.Point(128, 32);
            this.chkIncludiAumenti.Name = "chkIncludiAumenti";
            this.chkIncludiAumenti.Size = new System.Drawing.Size(104, 16);
            this.chkIncludiAumenti.TabIndex = 2;
            this.chkIncludiAumenti.Text = "Includi aumenti di valore";
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabIntro;
            this.tabController.Size = new System.Drawing.Size(600, 432);
            this.tabController.TabIndex = 3;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabGrid});
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.chkReady);
            this.tabIntro.Controls.Add(this.label15);
            this.tabIntro.Controls.Add(this.txtDescrizione);
            this.tabIntro.Controls.Add(this.label12);
            this.tabIntro.Controls.Add(this.label11);
            this.tabIntro.Controls.Add(this.label10);
            this.tabIntro.Controls.Add(this.label9);
            this.tabIntro.Controls.Add(this.label13);
            this.tabIntro.Controls.Add(this.cmbInventario);
            this.tabIntro.Controls.Add(this.txt_numinv_a);
            this.tabIntro.Controls.Add(this.txt_numinv_da);
            this.tabIntro.Controls.Add(this.label5);
            this.tabIntro.Controls.Add(this.label6);
            this.tabIntro.Controls.Add(this.txt_numcarico_a);
            this.tabIntro.Controls.Add(this.txt_numcarico_da);
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label4);
            this.tabIntro.Controls.Add(this.txt_idbene_a);
            this.tabIntro.Controls.Add(this.txt_idbene_da);
            this.tabIntro.Controls.Add(this.label7);
            this.tabIntro.Controls.Add(this.label8);
            this.tabIntro.Controls.Add(this.grpUbicazione);
            this.tabIntro.Controls.Add(this.cboResponsabile);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.chkIncludiAumenti);
            this.tabIntro.Controls.Add(this.chkIncludiAsset);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Size = new System.Drawing.Size(600, 407);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.PropertyChanged += new Crownwood.Magic.Controls.TabPage.PropChangeHandler(this.tabIntro_PropertyChanged);
            // 
            // chkReady
            // 
            this.chkReady.AutoSize = true;
            this.chkReady.Location = new System.Drawing.Point(11, 329);
            this.chkReady.Name = "chkReady";
            this.chkReady.Size = new System.Drawing.Size(435, 19);
            this.chkReady.TabIndex = 47;
            this.chkReady.Text = "Seleziona solo cespiti e aumenti di valore marcati come \"Pronti per lo scarico\"";
            this.chkReady.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 366);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(576, 16);
            this.label15.TabIndex = 45;
            this.label15.Text = "Nota: per ogni cespite saranno automaticamente scaricati tutti gli eventuali aume" +
    "nti di valore associati.";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(96, 288);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(488, 23);
            this.txtDescrizione.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(24, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 23);
            this.label12.TabIndex = 43;
            this.label12.Text = "Inventario";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "Per numero carico cespite";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "Identificativo cespite principale";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Descrizione";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(208, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "Tipo";
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.Location = new System.Drawing.Point(256, 232);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(328, 23);
            this.cmbInventario.TabIndex = 34;
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // txt_numinv_a
            // 
            this.txt_numinv_a.Location = new System.Drawing.Point(368, 264);
            this.txt_numinv_a.Name = "txt_numinv_a";
            this.txt_numinv_a.Size = new System.Drawing.Size(56, 23);
            this.txt_numinv_a.TabIndex = 37;
            this.txt_numinv_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_numinv_da
            // 
            this.txt_numinv_da.Location = new System.Drawing.Point(256, 264);
            this.txt_numinv_da.Name = "txt_numinv_da";
            this.txt_numinv_da.Size = new System.Drawing.Size(56, 23);
            this.txt_numinv_da.TabIndex = 35;
            this.txt_numinv_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(344, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "a";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Da";
            // 
            // txt_numcarico_a
            // 
            this.txt_numcarico_a.Location = new System.Drawing.Point(368, 200);
            this.txt_numcarico_a.Name = "txt_numcarico_a";
            this.txt_numcarico_a.Size = new System.Drawing.Size(56, 23);
            this.txt_numcarico_a.TabIndex = 31;
            this.txt_numcarico_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_numcarico_da
            // 
            this.txt_numcarico_da.Location = new System.Drawing.Point(256, 200);
            this.txt_numcarico_da.Name = "txt_numcarico_da";
            this.txt_numcarico_da.Size = new System.Drawing.Size(56, 23);
            this.txt_numcarico_da.TabIndex = 29;
            this.txt_numcarico_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(344, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "a";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Da";
            // 
            // txt_idbene_a
            // 
            this.txt_idbene_a.Location = new System.Drawing.Point(368, 166);
            this.txt_idbene_a.Name = "txt_idbene_a";
            this.txt_idbene_a.Size = new System.Drawing.Size(56, 23);
            this.txt_idbene_a.TabIndex = 26;
            this.txt_idbene_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_idbene_da
            // 
            this.txt_idbene_da.Location = new System.Drawing.Point(256, 166);
            this.txt_idbene_da.Name = "txt_idbene_da";
            this.txt_idbene_da.Size = new System.Drawing.Size(56, 23);
            this.txt_idbene_da.TabIndex = 24;
            this.txt_idbene_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(344, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "a";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(216, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Da";
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazione.Controls.Add(this.txtIDUbicazione);
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(8, 88);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(576, 72);
            this.grpUbicazione.TabIndex = 12;
            this.grpUbicazione.TabStop = false;
            this.grpUbicazione.Tag = "AutoManage.txtUbicazione.tree";
            this.grpUbicazione.Text = "Ubicazione";
            // 
            // txtIDUbicazione
            // 
            this.txtIDUbicazione.Location = new System.Drawing.Point(296, 24);
            this.txtIDUbicazione.Name = "txtIDUbicazione";
            this.txtIDUbicazione.Size = new System.Drawing.Size(100, 23);
            this.txtIDUbicazione.TabIndex = 9;
            this.txtIDUbicazione.Visible = false;
            // 
            // btnUbicazione
            // 
            this.btnUbicazione.Location = new System.Drawing.Point(8, 16);
            this.btnUbicazione.Name = "btnUbicazione";
            this.btnUbicazione.Size = new System.Drawing.Size(128, 23);
            this.btnUbicazione.TabIndex = 6;
            this.btnUbicazione.TabStop = false;
            this.btnUbicazione.Tag = "manage.locationview.tree";
            this.btnUbicazione.Text = "Ubicazione";
            this.btnUbicazione.Click += new System.EventHandler(this.btnUbicazione_Click);
            // 
            // txtDescUbicazione
            // 
            this.txtDescUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazione.Location = new System.Drawing.Point(144, 21);
            this.txtDescUbicazione.Multiline = true;
            this.txtDescUbicazione.Name = "txtDescUbicazione";
            this.txtDescUbicazione.ReadOnly = true;
            this.txtDescUbicazione.Size = new System.Drawing.Size(424, 48);
            this.txtDescUbicazione.TabIndex = 8;
            this.txtDescUbicazione.TabStop = false;
            this.txtDescUbicazione.Tag = "locationview.description";
            // 
            // txtUbicazione
            // 
            this.txtUbicazione.Location = new System.Drawing.Point(8, 40);
            this.txtUbicazione.Name = "txtUbicazione";
            this.txtUbicazione.Size = new System.Drawing.Size(128, 23);
            this.txtUbicazione.TabIndex = 1;
            this.txtUbicazione.Tag = "locationview.locationcode?assetview.locationcode";
            this.txtUbicazione.Leave += new System.EventHandler(this.txtUbicazione_Leave);
            // 
            // cboResponsabile
            // 
            this.cboResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResponsabile.Location = new System.Drawing.Point(128, 56);
            this.cboResponsabile.Name = "cboResponsabile";
            this.cboResponsabile.Size = new System.Drawing.Size(456, 23);
            this.cboResponsabile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Responsabile";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.btnSelezionaTutto);
            this.tabGrid.Controls.Add(this.label16);
            this.tabGrid.Controls.Add(this.label14);
            this.tabGrid.Controls.Add(this.gridBeni);
            this.tabGrid.Location = new System.Drawing.Point(0, 0);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Selected = false;
            this.tabGrid.Size = new System.Drawing.Size(600, 407);
            this.tabGrid.TabIndex = 4;
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 16);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 26;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(112, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(456, 32);
            this.label16.TabIndex = 25;
            this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare pi˘ cespiti da scaricare";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(192, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "Cespiti e aumenti da da scaricare:";
            // 
            // gridBeni
            // 
            this.gridBeni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBeni.DataMember = "";
            this.gridBeni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridBeni.Location = new System.Drawing.Point(8, 64);
            this.gridBeni.Name = "gridBeni";
            this.gridBeni.Size = new System.Drawing.Size(584, 336);
            this.gridBeni.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(528, 456);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(424, 456);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(344, 456);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FrmWizardScarico
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 485);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmWizardScarico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWizardScarico";
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBeni)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		string CustomTitle;
		void FormInit() {
			CustomTitle = "Scarico";
			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

			DataTable Manager = Conn.CreateTableByName("manager","*");
			GetData.MarkToAddBlankRow(Manager);
			GetData.Add_Blank_Row(Manager);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,Manager,"title asc",null,null,true);
			cboResponsabile.DataSource=Manager;
			cboResponsabile.DisplayMember="title";
			cboResponsabile.ValueMember= "idman";


			DataTable Inventory = Conn.CreateTableByName("inventory","*");
			GetData.MarkToAddBlankRow(Inventory);
			GetData.Add_Blank_Row(Inventory);
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,Inventory,"description asc","(active='S')",null,true);
			cmbInventario.DataSource=Inventory;
			cmbInventario.DisplayMember="description";
			cmbInventario.ValueMember= "idinventory";
			if (CodInv!=null){
				cmbInventario.SelectedValue = CodInv;
				cmbInventario.Enabled=false;
			}
			//Selects first tab
			DisplayTabs(0);
		}

		void SetGridColumnCaptions(DataTable T) {
//			T.Columns[0].Caption="";
//			T.Columns[1].Caption="";
//			T.Columns[2].Caption="Fase";
//			T.Columns[3].Caption="";
//			T.Columns[4].Caption="Cred./deb.";
//			T.Columns[5].Caption="";
//			T.Columns[6].Caption="Bilancio";
//			T.Columns[7].Caption="Fondo";
//			T.Columns[8].Caption="Ripartizione";
//			T.Columns[9].Caption="Descrizione";
//			T.Columns[10].Caption="Importo";
		}

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Fine.";
			else
				btnNext.Text="Avanti >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}

		/// <summary>
		/// Changes tab backward/forward
		/// </summary>
		/// <param name="step"></param>
		void StandardChangeTab(int step) {
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count) {
				DialogResult= DialogResult.OK;
				return;
			}
			DisplayTabs(newTab);
		}


		/// <summary>
		/// Must return true if operation is possible, and do any
		///  operation related to change from tab oldTab to newTab
		/// </summary>
		/// <param name="oldTab"></param>
		/// <param name="newTab"></param>
		/// <returns></returns>
		bool CustomChangeTab(int oldTab, int newTab) {
			if ((oldTab==0)&&(newTab==1)) return GetFiltro();

//			//if (oldTab==0) 	return true ; // 0->1: nothing to do
//			if ((oldTab==1)&&(newTab==0)) {
//				DS.incomeview.Clear();
//				btnNext.Enabled=true;
//				return true; //1->0:nothing to do!
//			}
//			if ((oldTab==0)&&(newTab==1)) {
//				if (CheckInputData())
//					return CallStoredProcedure(); 
//				else
//					btnNext.Enabled=false;
//			}
			return true;
		}
		


		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}

		private void btnNext_Click(object sender, System.EventArgs e) {
			if (tabController.SelectedIndex==tabController.TabPages.Count-1)

				SaveData();
			
			StandardChangeTab(+1);
		}

		bool GetFiltro(){
			string Filtro="";
			//string field="";
			if (txtIDUbicazione.Text!=""){
                Filtro = QHS.CmpEq("idcurrlocation", txtIDUbicazione.Text);
			}
			if (cboResponsabile.SelectedIndex>0){
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrman", cboResponsabile.SelectedValue));
			}

			if (txt_idbene_da.Text.Trim()!=""){
				int N1= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_idbene_da.Text,"x.y"));
				if (N1>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("idasset", N1));
				}
			}
			if (txt_idbene_a.Text.Trim()!=""){
				int N2= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_idbene_a.Text,"x.y"));
				if (N2>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("idasset", N2));
				}
			}
			if (txt_numcarico_da.Text.Trim()!=""){
				int N3= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numcarico_da.Text,"x.y"));
				if (N3>0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("nassetacquire", N3));
				}
			}
			if (txt_numcarico_a.Text.Trim()!=""){
				int N4= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numcarico_a.Text,"x.y"));
				if (N4>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("nassetacquire", N4));
				}
			}

			if (txt_numinv_da.Text.Trim()!=""){
				int N5= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numinv_da.Text,"x.y"));
				if (N5>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("ninventory", N5));
				}
			}
			if (txt_numinv_a.Text.Trim()!=""){
				int N6= CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),txt_numinv_a.Text,"x.y"));
				if (N6>0){
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("ninventory", N6));
				}
			}
			if (cmbInventario.SelectedIndex>0){
				Filtro = QHS.AppAnd(Filtro,
					"(nassetacquire in (SELECT nassetacquire from assetacquire " +
                    " WHERE " + GetInventoryFilter(QHS, cmbInventario.SelectedValue) +
                    "))");

			}
			if (txtDescrizione.Text.Trim()!=""){
				string descr= txtDescrizione.Text.Trim();
				if (!descr.StartsWith("%"))descr="%"+descr;
				if (!descr.EndsWith("%"))descr=descr+"%";
				Filtro = QHS.AppAnd(Filtro, QHS.Like("description", descr + "%"));
			}
            if (chkReady.Checked) {
                Filtro = QHS.AppAnd(Filtro, QHS.BitSet("flag", 1));
            }
            if (Filtro == "") {
				if (MessageBox.Show("Non Ë stato selezionato alcun filtro. Conferma?",
					"Conferma",MessageBoxButtons.OKCancel)!=DialogResult.OK) return false;
			}
			if (!chkIncludiAsset.Checked && chkIncludiAumenti.Checked){
                Filtro = QHS.AppAnd(Filtro, QHS.CmpGt("idpiece", 1));
			}
			if (chkIncludiAsset.Checked && !chkIncludiAumenti.Checked){
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idpiece", 1));
			}
            Filtro = QHS.AppAnd(Filtro, QHS.IsNull("idassetunload"));
            Filtro = QHS.AppAnd(Filtro, QHS.BitSet("flag", 0));

			AssetPiece = Conn.RUN_SELECT("assetpieceview","*","idinventory asc,ninventory asc",
				Filtro,null,false);
			AssetPiece.PrimaryKey= new DataColumn[]{AssetPiece.Columns["idasset"],
													   AssetPiece.Columns["idpiece"]};


			string elencoidasset= QueryCreator.ColumnValues(AssetPiece, QHS.CmpEq("idpiece", 1),"idasset",true);
			if (elencoidasset!="" && elencoidasset!=null){
                
				string filtroasset= QHS.AppAnd(QHS.FieldInList("idasset", elencoidasset),
                    QHS.IsNull("idassetunload"), QHS.CmpGt("idpiece", 1));

				Conn.RUN_SELECT_INTO_TABLE(AssetPiece,null,filtroasset,null,false);
			}


			MetaData MAP= Meta.Dispatcher.Get("assetpieceview");
			MAP.DescribeColumns(AssetPiece,"default");
			DataSet D= new DataSet();
			D.Tables.Add(AssetPiece);
			gridBeni.DataSource = null;
			HelpForm.SetDataGrid(gridBeni,AssetPiece);
			HelpForm.SetAllowMultiSelection(AssetPiece,true);
			SelezionaTuttiICespiti();
			return true;
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
		private DataRow[] GetGridSelectedRows(DataGrid G){
			if (G.DataMember==null) return null;
			if (G.DataSource==null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp=MyTable.Rows.Count;
			int numrighe=0;
			int i;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					numrighe++;
				}
			}

			DataRow[] Res=new DataRow[numrighe]; 			
			int count=0;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					Res[count++]= GetGridRow(G,i);
				}
			}
			return Res;	
		}

		DataRow GetGridRow(DataGrid G, int index){
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter;
			filter=QHC.AppAnd(QHC.CmpEq("idasset", G[index,0]), QHC.CmpEq("idpiece", G[index,1]));
			DataRow[] selectresult = MyTable.Select(filter);
			return selectresult[0];
		}


		void SaveData(){
			if (gridBeni.DataSource==null) return;
			string T = gridBeni.DataMember.ToString();
			DataSet DS =(DataSet)gridBeni.DataSource;
			DataTable DgrTable = DS.Tables[T];
			DataTable MyTable = DgrTable.Copy();
			DataColumn idColumn = new  DataColumn();
			idColumn.DataType = System.Type.GetType("System.String");
			idColumn.ColumnName = "flagsel";
			MyTable.Columns.Add("flagsel");
			int numrighe=MyTable.Rows.Count;
			int i;

			for (i=0; i<numrighe; i++){
				  MyTable.Rows[i]["flagsel"]= "N";	
			}

			DataRow []RigheSelezionate= GetGridSelectedRows(gridBeni);
			if (RigheSelezionate.Length >0){

				foreach (DataRow R in RigheSelezionate) {
					for (i=0; i<numrighe; i++){
						if(MyTable.Rows[i]["idasset"].ToString() == R["idasset"].ToString() && 
							MyTable.Rows[i]["idpiece"].ToString() == R["idpiece"].ToString()){
							MyTable.Rows[i]["flagsel"]= "S";	
						}
					}
				}

				for (i=0; i<numrighe; i++){
			
					if(MyTable.Rows[i]["flagsel"].ToString()=="S" && MyTable.Rows[i]["idpiece"].ToString()=="1" ){
						int j;
						for (j=0; j<numrighe; j++){
							if (MyTable.Rows[j]["idasset"].ToString() == MyTable.Rows[i]["idasset"].ToString() && (MyTable.Rows[j]["idpiece"].ToString() != "1") && MyTable.Rows[j]["flagsel"].ToString() =="N"){
								MyTable.Rows[j]["flagsel"] ="S";
							}
						}	 	
				
					}
				}
			}

			for  (i=0; i<numrighe; i++) {
				if (MyTable.Rows[i]["flagsel"].ToString()=="N")
				DgrTable.Rows[i].Delete();
			}

			DgrTable.AcceptChanges();
		}
		

		private void tabIntro_PropertyChanged(Crownwood.Magic.Controls.TabPage page, Crownwood.Magic.Controls.TabPage.Property prop, object oldValue) {
		
		}

		private void txtUbicazione_Leave(object sender, System.EventArgs e) {
			if (txtUbicazione.Text.Trim()==""){
				txtIDUbicazione.Text="";
				txtUbicazione.Text="";
				txtDescUbicazione.Text="";
				return;
			}
            //string codubic= txtUbicazione.Text.Trim();
            //if (!codubic.EndsWith("%"))codubic+="%";
            //string filter="(locationcode like "+QueryCreator.quotedstrvalue(codubic,true)+")";
			DoManage(true);
		
		}
		
		private void btnUbicazione_Click(object sender, System.EventArgs e) {
			DoManage(false);
		}

		void DoManage(bool StartFieldWanted){
			MetaData M= Meta.Dispatcher.Get("locationview");
			M.FilterLocked=true;
			M.SearchEnabled=false;
			M.MainSelectionEnabled=true;
			M.StartFilter= null;
			if (StartFieldWanted){
				M.startFieldWanted= "locationcode";
				M.startValueWanted= txtUbicazione.Text.Trim();
			}
			M.ExtraParameter= null;
			M.edit_type="tree";
			M.DS = Meta.DS.Clone();

			bool res = M.Edit(null, "tree", true);
			if (!res) { //user canceled the operation
				return ;
			}
			DataRow Selected = M.LastSelectedRow;
			if (Selected==null) return;
			txtIDUbicazione.Text=Selected["idlocation"].ToString();
			txtUbicazione.Text=Selected["locationcode"].ToString();
			txtDescUbicazione.Text=Selected["description"].ToString();

		}

		private void SelezionaTuttiICespiti() {
			object dataSource = gridBeni.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridBeni.BindingContext[dataSource, gridBeni.DataMember];

			DataView view = cm.List as DataView;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					gridBeni.Select(i);
				}
			}
		}

		private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
			SelezionaTuttiICespiti();
		}

	}
}
