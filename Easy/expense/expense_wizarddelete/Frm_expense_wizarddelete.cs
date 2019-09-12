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
using funzioni_configurazione;//funzioni_configurazione

namespace expense_wizarddelete {//spesawizardelimina//
	/// <summary>
	/// Summary description for FrmSpesaWizardElimina.
	/// </summary>
	public class Frm_expense_wizarddelete : System.Windows.Forms.Form {
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private Crownwood.Magic.Controls.TabPage tabSelect;
		private Crownwood.Magic.Controls.TabPage tabShow;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gboxMovimento;
		private System.Windows.Forms.TextBox txtNumeroMovimento;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercizioMovimento;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblFaseMovimento;
		private System.Windows.Forms.ComboBox cmbFaseSpesa;
		private System.Windows.Forms.Label label6;
		public vistaForm DS;
		DataAccess Conn;
		string CustomTitle;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private Crownwood.Magic.Controls.TabControl tabController;
		private System.Windows.Forms.Button btnSelectMov;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtDataCont;
		private System.Windows.Forms.TextBox txtScadenza;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblImportoDisponibile;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtImportoDisponibile;
		private System.Windows.Forms.TextBox txtImportoCorrente;
		private System.Windows.Forms.Label label9;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.DataGrid grdEntrata;
		private System.Windows.Forms.DataGrid grdSpesa;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
        public TextBox txtResponsabile;
        public TextBox txtUPB;
		public MetaData Meta;

		public Frm_expense_wizarddelete() {
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}

		public void MetaData_AfterActivation(){
			CustomTitle= "Wizard Cancellazione Movimenti di Spesa";
			//Selects first tab
			DisplayTabs(0);
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

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			GetData.CacheTable(DS.incomephase);
			GetData.CacheTable(DS.expensephase);
			GetData.CacheTable(DS.manager,null,"title",true);
			GetData.CacheTable(DS.sortingkind);
			GetData.CacheTable(DS.clawback);
			GetData.CacheTable(DS.tax);
			txtEsercizioMovimento.Text= Meta.GetSys("esercizio").ToString();
		}

		public void MetaData_AfterClear(){
			DisplayTabs(tabController.SelectedIndex);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expense_wizarddelete));
            this.DS = new expense_wizarddelete.vistaForm();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabSelect = new Crownwood.Magic.Controls.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataCont = new System.Windows.Forms.TextBox();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblImportoDisponibile = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
            this.txtImportoCorrente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFaseMovimento = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabShow = new Crownwood.Magic.Controls.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grdEntrata = new System.Windows.Forms.DataGrid();
            this.grdSpesa = new System.Windows.Forms.DataGrid();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpesa)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(8, 8);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabSelect;
            this.tabController.Size = new System.Drawing.Size(898, 461);
            this.tabController.TabIndex = 4;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelect,
            this.tabShow});
            // 
            // tabSelect
            // 
            this.tabSelect.Controls.Add(this.groupBox16);
            this.tabSelect.Controls.Add(this.gboxUPB);
            this.tabSelect.Controls.Add(this.groupBox20);
            this.tabSelect.Controls.Add(this.groupBox18);
            this.tabSelect.Controls.Add(this.groupBox17);
            this.tabSelect.Controls.Add(this.gboxBilAnnuale);
            this.tabSelect.Controls.Add(this.groupCredDeb);
            this.tabSelect.Controls.Add(this.groupBox1);
            this.tabSelect.Controls.Add(this.label6);
            this.tabSelect.Controls.Add(this.gboxMovimento);
            this.tabSelect.Location = new System.Drawing.Point(0, 0);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Size = new System.Drawing.Size(898, 436);
            this.tabSelect.TabIndex = 4;
            this.tabSelect.Title = "Pagina 2 di 3";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtResponsabile);
            this.groupBox16.Location = new System.Drawing.Point(13, 249);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(443, 40);
            this.groupBox16.TabIndex = 92;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Responsabile";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 147);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(447, 96);
            this.gboxUPB.TabIndex = 91;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 19);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(305, 44);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 43);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(8, 379);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 18;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Data";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(2, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contabile";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(67, 15);
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.ReadOnly = true;
            this.txtDataCont.Size = new System.Drawing.Size(72, 21);
            this.txtDataCont.TabIndex = 1;
            this.txtDataCont.Tag = "";
            this.txtDataCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(264, 16);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.ReadOnly = true;
            this.txtScadenza.Size = new System.Drawing.Size(72, 21);
            this.txtScadenza.TabIndex = 2;
            this.txtScadenza.Tag = "";
            this.txtScadenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(192, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Scadenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(13, 108);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(443, 40);
            this.groupBox18.TabIndex = 17;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(131, 13);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 21);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(75, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(475, 32);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(402, 72);
            this.groupBox17.TabIndex = 15;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(386, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 287);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(448, 86);
            this.gboxBilAnnuale.TabIndex = 12;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(12, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 18);
            this.label9.TabIndex = 3;
            this.label9.Text = "Bilancio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceBilancio.Location = new System.Drawing.Point(11, 56);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(432, 21);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(152, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(291, 45);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(475, 104);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(402, 40);
            this.groupCredDeb.TabIndex = 14;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(386, 21);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(483, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 77);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(72, 45);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(72, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Location = new System.Drawing.Point(291, 45);
            this.txtImportoDisponibile.Name = "txtImportoDisponibile";
            this.txtImportoDisponibile.ReadOnly = true;
            this.txtImportoDisponibile.Size = new System.Drawing.Size(96, 21);
            this.txtImportoDisponibile.TabIndex = 0;
            this.txtImportoDisponibile.TabStop = false;
            this.txtImportoDisponibile.Tag = "";
            this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Location = new System.Drawing.Point(291, 21);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(96, 21);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(416, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Selezionare il movimento di spesa che si desidera ELIMINARE";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.label4);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.label5);
            this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
            this.gboxMovimento.Controls.Add(this.cmbFaseSpesa);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 32);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(447, 70);
            this.gboxMovimento.TabIndex = 1;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Movimento";
            // 
            // btnSelectMov
            // 
            this.btnSelectMov.Location = new System.Drawing.Point(15, 17);
            this.btnSelectMov.Name = "btnSelectMov";
            this.btnSelectMov.Size = new System.Drawing.Size(75, 23);
            this.btnSelectMov.TabIndex = 4;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNumeroMovimento
            // 
            this.txtNumeroMovimento.Location = new System.Drawing.Point(218, 43);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(48, 21);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(186, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Num.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(136, 43);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.ReadOnly = true;
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 21);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(96, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Eserc.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFaseMovimento
            // 
            this.lblFaseMovimento.Location = new System.Drawing.Point(102, 19);
            this.lblFaseMovimento.Name = "lblFaseMovimento";
            this.lblFaseMovimento.Size = new System.Drawing.Size(32, 20);
            this.lblFaseMovimento.TabIndex = 0;
            this.lblFaseMovimento.Text = "Fase";
            this.lblFaseMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaseSpesa.Location = new System.Drawing.Point(134, 19);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(293, 21);
            this.cmbFaseSpesa.TabIndex = 1;
            this.cmbFaseSpesa.Tag = "expense.nphase";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label25);
            this.tabIntro.Controls.Add(this.label24);
            this.tabIntro.Controls.Add(this.label23);
            this.tabIntro.Controls.Add(this.label22);
            this.tabIntro.Controls.Add(this.label21);
            this.tabIntro.Controls.Add(this.label20);
            this.tabIntro.Controls.Add(this.label19);
            this.tabIntro.Controls.Add(this.label18);
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(898, 436);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 3";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 312);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(680, 32);
            this.label25.TabIndex = 14;
            this.label25.Text = resources.GetString("label25.Text");
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 288);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(440, 23);
            this.label24.TabIndex = 13;
            this.label24.Text = "- Variazioni";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 264);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(440, 23);
            this.label23.TabIndex = 12;
            this.label23.Text = "- Classificazioni imputate";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(432, 23);
            this.label22.TabIndex = 11;
            this.label22.Text = "- Assegnazione Incassi e Crediti";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 216);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(432, 23);
            this.label21.TabIndex = 10;
            this.label21.Text = "- Dettaglio Ritenute ed automatismi correlati";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(432, 23);
            this.label20.TabIndex = 9;
            this.label20.Text = "- Dettaglio Recuperi ed automatismi correlati";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(432, 23);
            this.label19.TabIndex = 8;
            this.label19.Text = "- Movimenti collegati di entrata/spesa ed automatismi correlati";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(480, 23);
            this.label18.TabIndex = 7;
            this.label18.Text = "Oltre ai movimenti di entrata o spesa trovati saranno cancellati anche i dati cor" +
                "relati, tra cui:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(882, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nel secondo passo vi verranno mostrati tutti i movimenti che sono stati trovati e" +
                " vi sarà chiesta conferma di voler procedere nell\'operazione.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(882, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = " Nel primo passo vi verrà richiesto di selezionare un movimento di spesa, ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(882, 48);
            this.label1.TabIndex = 4;
            this.label1.Text = "Questo Wizard serve ad eliminare in modo guidato un movimento di spesa con tutti " +
                "i movimenti dipendenti direttamente o indirettamente.";
            // 
            // tabShow
            // 
            this.tabShow.Controls.Add(this.label10);
            this.tabShow.Controls.Add(this.label8);
            this.tabShow.Controls.Add(this.label7);
            this.tabShow.Controls.Add(this.grdEntrata);
            this.tabShow.Controls.Add(this.grdSpesa);
            this.tabShow.Location = new System.Drawing.Point(0, 0);
            this.tabShow.Name = "tabShow";
            this.tabShow.Selected = false;
            this.tabShow.Size = new System.Drawing.Size(898, 436);
            this.tabShow.TabIndex = 5;
            this.tabShow.Title = "Pagina 3 di 3";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(8, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Movimenti di entrata";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(352, 23);
            this.label8.TabIndex = 3;
            this.label8.Text = "I movimenti correlati a quello selezionato sono i seguenti:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Movimenti di spesa";
            // 
            // grdEntrata
            // 
            this.grdEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEntrata.DataMember = "";
            this.grdEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEntrata.Location = new System.Drawing.Point(8, 237);
            this.grdEntrata.Name = "grdEntrata";
            this.grdEntrata.Size = new System.Drawing.Size(882, 192);
            this.grdEntrata.TabIndex = 1;
            this.grdEntrata.Tag = "";
            // 
            // grdSpesa
            // 
            this.grdSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSpesa.DataMember = "";
            this.grdSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.grdSpesa.Location = new System.Drawing.Point(8, 48);
            this.grdSpesa.Name = "grdSpesa";
            this.grdSpesa.Size = new System.Drawing.Size(882, 157);
            this.grdSpesa.TabIndex = 0;
            this.grdSpesa.Tag = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(818, 485);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(698, 485);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 6;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(610, 485);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(8, 13);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(429, 21);
            this.txtResponsabile.TabIndex = 1;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 69);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(433, 21);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // Frm_expense_wizarddelete
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(914, 522);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_expense_wizarddelete";
            this.Text = "Eliminazione movimenti di spesa";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabSelect.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.tabIntro.ResumeLayout(false);
            this.tabShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntrata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSpesa)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		void AddVociFiglieWhereEmpty(DataTable T, string filter){
			if (T.Select(filter).Length>0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,T,null,filter,null,true);
		}

        void AddVoceBilancio(object ID) {
            if (ID == DBNull.Value) return;
            if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.fin, null, QHS.CmpEq("idfin", ID), null, true);
        }

        void AddVoceUPB(object ID) {
            if (ID == DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.upb, null, QHS.CmpEq("idupb", ID), null, true);
        }

        void AddVoceFaseSpesa(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.expensephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensephase, null, QHS.CmpEq("nphase", codice), null, true);

        }

        void AddVoceFaseEntrata(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.incomephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomephase, null, QHS.CmpEq("nphase", codice), null, true);
        }

        void AddVoceCreditore(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.registry, null, QHS.CmpEq("idreg", codice), null, true);
        }

        void AddVoceResponsabile(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.manager.Select(QHC.CmpEq("idman", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.manager, null, QHS.CmpEq("idman", codice), null, true);
        }


        void AddVociCollegate(DataRow Row) {

            if (Row.Table.TableName == "expense")
                AddVoceFaseSpesa(Row["nphase"]);
            else
                AddVoceFaseEntrata(Row["nphase"]);
            AddVoceCreditore(Row["idreg"]);
            AddVoceResponsabile(Row["idman"]);
            DataRow Imputazione = null;
            if (Row.Table.TableName == "expense") {
                DataRow[] Imputazioni = Row.GetChildRows("expenseexpenseyear");
                if (Imputazioni.Length > 0) Imputazione = Imputazioni[0];
            }
            else {
                DataRow[] Imputazioni = Row.GetChildRows("incomeincomeyear");
                if (Imputazioni.Length > 0) Imputazione = Imputazioni[0];
            }
            if (Imputazione != null) {
                AddVoceBilancio(Imputazione["idfin"]);
                AddVoceUPB(Imputazione["idupb"]);
            }
        }

		void AddVociFiglie(DataRow Mov){
			string filter;
            int faseimpegnogiuridico = CfgFn.GetNoNullInt32(Meta.GetSys("appropriationphase"));
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			int fasespesacont= CfgFn.GetNoNullInt32(Meta.GetSys("itinerationphase"));
			//CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("expensesetup", 
			//"(ayear='"+Meta.GetSys("esercizio").ToString()+"')", "expensephase"));
			int faseivaspesa =  CfgFn.GetNoNullInt32(Meta.GetSys("invoiceexpensephase"));
			//CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("invoicesetup", 
			//"(ayear='"+Meta.GetSys("esercizio").ToString()+"')", "fasespesa"));
			int faseivaentrata = CfgFn.GetNoNullInt32(Meta.GetSys("invoiceincomephase"));
			//CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("invoicesetup", 
			//"(ayear='"+Meta.GetSys("esercizio").ToString()+"')", "faseentrata"));

            //DataRow []BilEnt = DS.incomephase.Select("(flagfinance='S')");
            int fasebilent =CfgFn.GetNoNullInt32( Meta.GetSys("incomefinphase"));

			if (Mov.Table.TableName == "expense"){
                int fase = CfgFn.GetNoNullInt32(Mov["nphase"]);

                filter = QHS.CmpEq("idexp", Mov["idexp"]);
                if (fase == fasespesamax )
					AddVociFiglieWhereEmpty(DS.expenseclawback,filter);

                if (fase == fasespesamax)
                    AddVociFiglieWhereEmpty(DS.expenselast, filter);

                if (fase == fasespesamax)
					AddVociFiglieWhereEmpty(DS.expensetax,filter);

                if (fase == fasespesamax)
                    AddVociFiglieWhereEmpty(DS.expensetaxofficial, filter);

                if (fase == fasespesamax)
                    AddVociFiglieWhereEmpty(DS.expensetaxcorrige, filter);

                if (fase == fasespesamax)
                    AddVociFiglieWhereEmpty(DS.underwritingpayment, filter);

                if (fase == fasespesamax)
                    AddVociFiglieWhereEmpty(DS.expensebill, filter);

                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expensemandate, filter);
                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expensepayroll, filter);
                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expensecasualcontract, filter);
                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expenseprofservice, filter);
                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expensewageaddition, filter);
                if (fase == fasespesacont)
                    AddVociFiglieWhereEmpty(DS.expenseitineration, filter);
                if (fase == faseimpegnogiuridico)
                    AddVociFiglieWhereEmpty(DS.underwritingappropriation, filter);
                if (fase == faseivaspesa)
                    AddVociFiglieWhereEmpty(DS.expenseinvoice, filter);
				
				string filterpag= QHS.CmpEq("idpayment",Mov["idexp"]);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensevar,filterpag);

				AddVociFiglieWhereEmpty(DS.expensesorted,filter);
				AddVociFiglieWhereEmpty(DS.expensevar,filter);
				AddVociFiglieWhereEmpty(DS.expenseyear,QHS.AppAnd(filter,
                    QHS.CmpEq("ayear",Meta.GetSys("esercizio"))));
			}
			else {
                int fase = CfgFn.GetNoNullInt32(Mov["nphase"]);
                filter = QHS.CmpEq("idinc", Mov["idinc"]);

				AddVociFiglieWhereEmpty(DS.incomesorted,filter);
				AddVociFiglieWhereEmpty(DS.incomevar,filter);
				AddVociFiglieWhereEmpty(DS.incomeyear,QHS.AppAnd(filter,
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio"))));

                if (fase == fasebilent )
					AddVociFiglieWhereEmpty(DS.creditpart,filter);

                if (fase == faseentratamax )
					AddVociFiglieWhereEmpty(DS.proceedspart,filter);

                if (fase == faseentratamax)
                    AddVociFiglieWhereEmpty(DS.incomelast, filter);


                if (fase == faseivaentrata )
					AddVociFiglieWhereEmpty(DS.incomeinvoice,filter);
			}
		}

		void AddAllCollegate(DataRow R){
			DS.expense.Clear();
			DS.income.Clear();
			DS.expenseclawback.Clear();
			DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
			DS.expensemandate.Clear();
			DS.expenseitineration.Clear();
            DS.expensebill.Clear();
            DS.expensepayroll.Clear();
			DS.expensecasualcontract.Clear();
			DS.expenseprofservice.Clear();
			DS.expensewageaddition.Clear();
			DS.expenseinvoice.Clear();
			DS.incomeinvoice.Clear();
			DS.expensesorted.Clear();
			DS.incomesorted.Clear();
			DS.incomeyear.Clear();
			DS.expenseyear.Clear();
			DS.incomevar.Clear();
			DS.expensevar.Clear();
			DS.creditpart.Clear();
			DS.proceedspart.Clear();
            DS.expenselast.Clear();
            DS.incomelast.Clear();
            DS.incomeestimate.Clear();
            DS.underwritingappropriation.Clear();
            DS.underwritingpayment.Clear();	 
			int NSpesa = DS.expense.Rows.Count;
			int NEntrata = DS.income.Rows.Count;
			string filter;
			DataRow Curr;
			if (R.Table.TableName.StartsWith("expense")){
                filter = QHS.CmpEq("idexp", R["idexp"]);
				DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.expense,null,filter,null,true);
				Curr= DS.expense.Rows[0];
				
			}
			else {
                filter = QHS.CmpEq("idinc", R["idinc"]);
 				DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.income,null,filter,null,true);
				Curr=DS.income.Rows[0];
			}
			while ((NSpesa!=DS.expense.Rows.Count)||(NEntrata!=DS.income.Rows.Count)){
				NSpesa = DS.expense.Rows.Count;
				NEntrata = DS.income.Rows.Count;
				//Prende le righe con i riferimenti livsupid/idpagamento/idincasso a quelle in DS
				foreach(DataRow R1 in DS.expense.Select()){
                    filter = QHS.CmpEq("idpayment", R1["idexp"]);
					AddVociFiglieWhereEmpty(DS.expense,filter);
					AddVociFiglieWhereEmpty(DS.income,filter);
                    filter = QHS.CmpEq("parentidexp", R1["idexp"]);
					AddVociFiglieWhereEmpty(DS.expense,filter);
				}
                foreach (DataRow R2 in DS.income.Select()) {
                    //filter = "(idproceeds=" +
                    //    QueryCreator.quotedstrvalue(R2["idproceeds"], true) + ")";
                    //AddVociFiglieWhereEmpty(DS.expense, filter);
                    //AddVociFiglieWhereEmpty(DS.income, filter);
                    filter = QHS.CmpEq("parentidinc", R2["idinc"]);
                    AddVociFiglieWhereEmpty(DS.income, filter);
                }


			}
			foreach (DataRow R1 in DS.expense.Rows){
				AddVociFiglie(R1);
				AddVociCollegate(R1);
			}
			foreach (DataRow R2 in DS.income.Rows){
				AddVociFiglie(R2);
				AddVociCollegate(R2);
			}


			DS.expenseview.Clear();
            string filterid = QHS.FieldIn("idexp", DS.expense.Select(), "idexp");
			if (DS.expense.Select().Length>0) DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.expenseview,null,filterid,null,true);

			DS.incomeview.Clear();
            filterid = QHS.FieldIn("idinc", DS.income.Select(), "idinc");
            if (DS.income.Select().Length>0) 
                DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.incomeview,null,filterid,null,true);

			MetaData MetaS = Meta.Dispatcher.Get("expenseview");
			MetaS.DescribeColumns(DS.expenseview,"default");
			MetaData MetaE = Meta.Dispatcher.Get("incomeview");
			MetaE.DescribeColumns(DS.incomeview,"default");
			HelpForm.SetDataGrid(grdEntrata, DS.incomeview);
			HelpForm.SetDataGrid(grdSpesa, DS.expenseview);
		}

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab){
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Elimina tutto.";
			else
				btnNext.Text="Next >";
			Text = CustomTitle+ " (Pagina "+(newTab+1)+" di "+tabController.TabPages.Count+")";
		}
		void StandardChangeTab(int step){
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab<0)||(newTab>tabController.TabPages.Count))return;
			if (!CustomChangeTab(oldTab,newTab))return;
			if (newTab==tabController.TabPages.Count){
				DialogResult= DialogResult.OK;
				Close();
				return;
			}
			DisplayTabs(newTab);
		}
		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}


		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		bool CustomChangeTab(int oldTab, int newTab){
			if (oldTab==0) 	{
				return true ; // 0->1: nothing to do
			}
			if ((oldTab==1)&&(newTab==0))return true; //1->0:nothing to do!
			if ((oldTab==1)&&(newTab==2))return GetMovimentoSelezionato(); 
			if ((oldTab==2)&&(newTab==3))return doDelete(); 
			return true;
		}

		bool GetMovimentoSelezionato(){
			if (txtNumeroMovimento.Text.Trim()==""){
				MessageBox.Show("Selezionare un movimento per procedere");
				return false;
			}
			string filter= GetFasePrecFilter(true);
			MetaData MFase = MetaData.GetMetaData(this,"expense");
			MFase.FilterLocked=true;
			MFase.DS=DS.Copy();
			
			DataRow MyDR = MFase.SelectOne("default",filter,null,null);
			if (MyDR==null) return false;
			AddAllCollegate(MyDR);

			return true;
		}

		bool doDelete(){
			DataTable []ToDelete = new DataTable[]{
													  DS.expenseclawback, DS.expensetax, DS.expensetaxcorrige, DS.expensetaxofficial,
                                                      DS.incomesorted, DS.expensesorted,
													  DS.expensemandate, DS.expenseitineration, DS.expensepayroll, DS.expenseinvoice,
													  DS.expenseprofservice,DS.expensecasualcontract,DS.expensewageaddition,
													  DS.incomeinvoice, DS.incomeestimate,
													  DS.incomeyear, DS.expenseyear, DS.incomelast, DS.expenselast,
													  DS.incomevar,DS.expensevar, DS.creditpart,DS.proceedspart,
													  DS.income,DS.expense,DS.underwritingappropriation,DS.underwritingpayment,
                                                      DS.expensebill
												  };
			foreach (DataTable T in ToDelete){
				foreach(DataRow R in T.Rows) R.Delete();
			}
			PostData Post = Meta.Get_PostData();
			Post.InitClass(DS,Conn);
			bool res= Post.DO_POST();
			if (res)MessageBox.Show("Cancellazione eseguita con successo.");
			return res;
		}

		string GetFasePrecFilter(bool FiltraNumMovimento){
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if(cmbFaseSpesa.SelectedIndex >= 0) {
                object codicefase = cmbFaseSpesa.SelectedValue;
                MyFilter = QHS.CmpEq("nphase", codicefase);
            }
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            if (txtEsercizioMovimento.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim()));

            if ((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroMovimento.Text.Trim()));

			return MyFilter;
		}

		private void btnSelectMov_Click(object sender, System.EventArgs e) {
			string MyFilter; 
			
			if (((Control)sender).Name == "txtNumeroMovimento")
				MyFilter = GetFasePrecFilter(true);
			else
				MyFilter = GetFasePrecFilter(false);

			MetaData MFase = MetaData.GetMetaData(this,"expense");
			MFase.FilterLocked=true;
			MFase.DS=DS;
			
			DataRow MyDR = MFase.SelectOne("default",MyFilter,null,null);
			
			if(MyDR == null) {
				if (Meta.InsertMode){
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
					}
				}
				return;
			}


            HelpForm.SetComboBoxValue(cmbFaseSpesa, MyDR["nphase"]);
					
			//txtCredDeb.Text = MyDR["denominazione"].ToString();		
			txtNumeroMovimento.Text=MyDR["nmov"].ToString();

			txtCredDeb.Text= MyDR["registry"].ToString();
			txtDescrizione.Text= MyDR["description"].ToString();
			SubEntity_txtImportoMovimento.Text= CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
			txtDataCont.Text= ((DateTime)MyDR["adate"]).ToShortDateString();
			txtCodiceBilancio.Text=MyDR["codefin"].ToString();
			txtDenominazioneBilancio.Text=MyDR["finance"].ToString();
            txtUPB.Text = MyDR["codeupb"].ToString();
			txtDescrUPB.Text=MyDR["upb"].ToString();
            txtResponsabile.Text = MyDR["manager"].ToString();

			txtImportoCorrente.Text= CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
			txtImportoDisponibile.Text= CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
		}

		private void txtNumeroMovimento_Leave(object sender, System.EventArgs e) {
			if (txtNumeroMovimento.Text.Trim()==""){
				Clear();
				return;
			}
			btnSelectMov_Click(sender,e);
		}

		private void txtEsercizioFasePrecedente_Leave(object sender, System.EventArgs e) {			
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercizioMovimento);		

		}

		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}

		private void cmbFaseSpesa_SelectedIndexChanged(object sender, System.EventArgs e) {
			Clear();
		}

		void Clear(){
			txtNumeroMovimento.Text="";
			//txtEsercizioMovimento.Text="";
			txtCredDeb.Text= "";
			txtDescrizione.Text= "";
			SubEntity_txtImportoMovimento.Text= "";
			txtDataCont.Text= "";
			txtCodiceBilancio.Text="";
			txtDenominazioneBilancio.Text="";
            txtUPB.Text = "";
			txtDescrUPB.Text="";
            txtResponsabile.Text = "";
			txtImportoCorrente.Text= "";
			txtImportoDisponibile.Text= "";
		}
	}
}