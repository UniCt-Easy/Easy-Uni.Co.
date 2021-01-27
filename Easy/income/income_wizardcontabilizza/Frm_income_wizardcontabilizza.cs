
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
using funzioni_configurazione;//funzioni_configurazione

namespace income_wizardcontabilizza {//entratawizardcontabilizza//
	/// <summary>
	/// Summary description for FrmEntrataWizardContabilizza.
	/// </summary>
	public class Frm_income_wizardcontabilizza : System.Windows.Forms.Form {
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Crownwood.Magic.Controls.TabPage tabSelectMov;
		private System.Windows.Forms.Label labContabAttuale;
		private System.Windows.Forms.Label label6;
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
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblImportoDisponibile;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtImportoDisponibile;
		private System.Windows.Forms.TextBox txtImportoCorrente;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox gboxMovimento;
		private System.Windows.Forms.Button btnSelectMov;
		private System.Windows.Forms.TextBox txtNumeroMovimento;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEsercizioMovimento;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label lblFaseMovimento;
		private Crownwood.Magic.Controls.TabPage tabSelectDoc;
		private System.Windows.Forms.CheckBox chkCredDeb;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cmbCausale;
		private System.Windows.Forms.ComboBox cmbTipoContabilizzazione;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox gboxDocumento;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.ComboBox cmbTipoDocumento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.Label labelTipoDocumento;
		private System.Windows.Forms.Label labelCausale;
		private Crownwood.Magic.Controls.TabPage tabConfirm;
		private System.Windows.Forms.Label labOperazione;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		public vistaForm DS;
		private System.ComponentModel.IContainer components;


        public enum tipocont { cont_none, cont_contrattoattivo, cont_iva };
		public tipocont currcont;

        bool gestisciEventoCmbFaseEntrata = true;
		MetaData Meta;
		DataAccess Conn;
		string CustomTitle;
		//int faseentratacont;
		int faseivaentrata;
        int faseentratacontab;
		decimal currimp;
		object NuovoDocumento;
		object NuovoDataDocumento;
		object NuovoDescrizione;
		int CurrCausaleIva;
        int CurrCausaleContrattoAttivo;
		private System.Windows.Forms.ComboBox cmbFaseEntrata;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox gboxUpb;
		private System.Windows.Forms.TextBox txtDescrizioneUpb;
		private System.Windows.Forms.TextBox txtUpb;
        private System.Windows.Forms.GroupBox groupBox2;
		string CurrDocDescr;

        CQueryHelper QHC;
        private TextBox txtResponsabile;
        QueryHelper QHS;
		public Frm_income_wizardcontabilizza() {
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_income_wizardcontabilizza));
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabSelectMov = new Crownwood.Magic.Controls.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.labContabAttuale = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.gboxUpb = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.txtUpb = new System.Windows.Forms.TextBox();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lblFaseMovimento = new System.Windows.Forms.Label();
            this.cmbFaseEntrata = new System.Windows.Forms.ComboBox();
            this.DS = new income_wizardcontabilizza.vistaForm();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSelectDoc = new Crownwood.Magic.Controls.TabPage();
            this.chkCredDeb = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.cmbTipoContabilizzazione = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gboxDocumento = new System.Windows.Forms.GroupBox();
            this.btnDocumento = new System.Windows.Forms.Button();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labelTipoDocumento = new System.Windows.Forms.Label();
            this.labelCausale = new System.Windows.Forms.Label();
            this.tabConfirm = new Crownwood.Magic.Controls.TabPage();
            this.labOperazione = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabSelectMov.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxUpb.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabIntro.SuspendLayout();
            this.tabSelectDoc.SuspendLayout();
            this.gboxDocumento.SuspendLayout();
            this.tabConfirm.SuspendLayout();
            this.SuspendLayout();
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
            this.tabController.SelectedTab = this.tabSelectMov;
            this.tabController.Size = new System.Drawing.Size(712, 446);
            this.tabController.TabIndex = 1;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelectMov,
            this.tabSelectDoc,
            this.tabConfirm});
            // 
            // tabSelectMov
            // 
            this.tabSelectMov.Controls.Add(this.groupBox2);
            this.tabSelectMov.Controls.Add(this.labContabAttuale);
            this.tabSelectMov.Controls.Add(this.label6);
            this.tabSelectMov.Controls.Add(this.groupBox20);
            this.tabSelectMov.Controls.Add(this.groupBox18);
            this.tabSelectMov.Controls.Add(this.groupBox17);
            this.tabSelectMov.Controls.Add(this.gboxBilAnnuale);
            this.tabSelectMov.Controls.Add(this.groupCredDeb);
            this.tabSelectMov.Controls.Add(this.groupBox1);
            this.tabSelectMov.Controls.Add(this.gboxUpb);
            this.tabSelectMov.Controls.Add(this.gboxMovimento);
            this.tabSelectMov.Location = new System.Drawing.Point(0, 0);
            this.tabSelectMov.Name = "tabSelectMov";
            this.tabSelectMov.Size = new System.Drawing.Size(712, 421);
            this.tabSelectMov.TabIndex = 4;
            this.tabSelectMov.Title = "Pagina 2 di 4";
            this.tabSelectMov.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtResponsabile);
            this.groupBox2.Location = new System.Drawing.Point(11, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 48);
            this.groupBox2.TabIndex = 89;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Location = new System.Drawing.Point(3, 16);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(336, 23);
            this.txtResponsabile.TabIndex = 2;
            this.txtResponsabile.Tag = "";
            // 
            // labContabAttuale
            // 
            this.labContabAttuale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labContabAttuale.Location = new System.Drawing.Point(8, 410);
            this.labContabAttuale.Name = "labContabAttuale";
            this.labContabAttuale.Size = new System.Drawing.Size(664, 16);
            this.labContabAttuale.TabIndex = 88;
            this.labContabAttuale.Click += new System.EventHandler(this.labContabAttuale_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(688, 23);
            this.label6.TabIndex = 87;
            this.label6.Text = "Selezionare il movimento di entrata che si desidera ASSOCIARE al documento ";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(360, 208);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 5;
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
            this.txtDataCont.Size = new System.Drawing.Size(72, 23);
            this.txtDataCont.TabIndex = 1;
            this.txtDataCont.TabStop = false;
            this.txtDataCont.Tag = "";
            this.txtDataCont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(264, 16);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.ReadOnly = true;
            this.txtScadenza.Size = new System.Drawing.Size(72, 23);
            this.txtScadenza.TabIndex = 2;
            this.txtScadenza.TabStop = false;
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
            this.groupBox18.Location = new System.Drawing.Point(8, 112);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(344, 40);
            this.groupBox18.TabIndex = 4;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 23);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.TabStop = false;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(360, 32);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(344, 72);
            this.groupBox17.TabIndex = 3;
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
            this.txtDescrizione.Size = new System.Drawing.Size(328, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(11, 309);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(344, 98);
            this.gboxBilAnnuale.TabIndex = 6;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(9, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
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
            this.txtCodiceBilancio.Location = new System.Drawing.Point(11, 69);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(322, 23);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(79, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(257, 55);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(360, 104);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(344, 40);
            this.groupCredDeb.TabIndex = 2;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "";
            this.groupCredDeb.Text = "Versante";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(326, 23);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.TabStop = false;
            this.txtCredDeb.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(360, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 64);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(8, 40);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Location = new System.Drawing.Point(227, 40);
            this.txtImportoDisponibile.Name = "txtImportoDisponibile";
            this.txtImportoDisponibile.ReadOnly = true;
            this.txtImportoDisponibile.Size = new System.Drawing.Size(96, 23);
            this.txtImportoDisponibile.TabIndex = 0;
            this.txtImportoDisponibile.TabStop = false;
            this.txtImportoDisponibile.Tag = "";
            this.txtImportoDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImportoCorrente
            // 
            this.txtImportoCorrente.Location = new System.Drawing.Point(227, 16);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(96, 23);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxUpb
            // 
            this.gboxUpb.Controls.Add(this.label14);
            this.gboxUpb.Controls.Add(this.txtDescrizioneUpb);
            this.gboxUpb.Controls.Add(this.txtUpb);
            this.gboxUpb.Location = new System.Drawing.Point(8, 152);
            this.gboxUpb.Name = "gboxUpb";
            this.gboxUpb.Size = new System.Drawing.Size(344, 105);
            this.gboxUpb.TabIndex = 7;
            this.gboxUpb.TabStop = false;
            this.gboxUpb.Tag = "";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "U.P.B.";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(82, 8);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(254, 60);
            this.txtDescrizioneUpb.TabIndex = 0;
            this.txtDescrizioneUpb.TabStop = false;
            this.txtDescrizioneUpb.Tag = "";
            // 
            // txtUpb
            // 
            this.txtUpb.Location = new System.Drawing.Point(6, 71);
            this.txtUpb.Name = "txtUpb";
            this.txtUpb.ReadOnly = true;
            this.txtUpb.Size = new System.Drawing.Size(326, 23);
            this.txtUpb.TabIndex = 1;
            this.txtUpb.Tag = "";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.label5);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.label18);
            this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
            this.gboxMovimento.Controls.Add(this.cmbFaseEntrata);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 32);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(344, 80);
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
            this.btnSelectMov.TabStop = false;
            this.btnSelectMov.Tag = "";
            this.btnSelectMov.Text = "Seleziona";
            this.btnSelectMov.Click += new System.EventHandler(this.btnSelectMov_Click);
            // 
            // txtNumeroMovimento
            // 
            this.txtNumeroMovimento.Location = new System.Drawing.Point(134, 49);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(48, 23);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(102, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Num.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(52, 49);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.ReadOnly = true;
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 23);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.TabStop = false;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(12, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Eserc.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // cmbFaseEntrata
            // 
            this.cmbFaseEntrata.DataSource = this.DS.incomephase;
            this.cmbFaseEntrata.DisplayMember = "description";
            this.cmbFaseEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaseEntrata.Location = new System.Drawing.Point(134, 19);
            this.cmbFaseEntrata.Name = "cmbFaseEntrata";
            this.cmbFaseEntrata.Size = new System.Drawing.Size(198, 23);
            this.cmbFaseEntrata.TabIndex = 1;
            this.cmbFaseEntrata.Tag = "income.nphase";
            this.cmbFaseEntrata.ValueMember = "nphase";
            this.cmbFaseEntrata.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label4);
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(712, 421);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 4";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(664, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "L\'unica informazione che sarà aggiunta sarà L\'ASSOCIAZIONE tra il movimento di en" +
                "trata ed il documento.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(664, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Non sarà creato alcun movimento di entrata, e neanche alcun documento.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(24, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(664, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "E\' da notare che uno stesso movimento di entrata NON PUO\' contabilizzare più di u" +
                "n documento.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(664, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questo wizard serve a far si che un movimento di entrata esistente contabilizzi u" +
                "n documento esistente (doc.iva)";
            // 
            // tabSelectDoc
            // 
            this.tabSelectDoc.Controls.Add(this.chkCredDeb);
            this.tabSelectDoc.Controls.Add(this.label19);
            this.tabSelectDoc.Controls.Add(this.cmbCausale);
            this.tabSelectDoc.Controls.Add(this.cmbTipoContabilizzazione);
            this.tabSelectDoc.Controls.Add(this.label8);
            this.tabSelectDoc.Controls.Add(this.gboxDocumento);
            this.tabSelectDoc.Controls.Add(this.labelCausale);
            this.tabSelectDoc.Location = new System.Drawing.Point(0, 0);
            this.tabSelectDoc.Name = "tabSelectDoc";
            this.tabSelectDoc.Selected = false;
            this.tabSelectDoc.Size = new System.Drawing.Size(712, 421);
            this.tabSelectDoc.TabIndex = 6;
            this.tabSelectDoc.Title = "Pagina 3 di 4";
            this.tabSelectDoc.Visible = false;
            // 
            // chkCredDeb
            // 
            this.chkCredDeb.Checked = true;
            this.chkCredDeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCredDeb.Location = new System.Drawing.Point(8, 160);
            this.chkCredDeb.Name = "chkCredDeb";
            this.chkCredDeb.Size = new System.Drawing.Size(680, 48);
            this.chkCredDeb.TabIndex = 4;
            this.chkCredDeb.Text = "Cerca solo documenti con lo stesso versante del movimento di entrata";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(688, 23);
            this.label19.TabIndex = 101;
            this.label19.Text = "Selezionare il documento da ASSOCIARE al movimento di entrata";
            // 
            // cmbCausale
            // 
            this.cmbCausale.DataSource = this.DS.tipomovimento;
            this.cmbCausale.DisplayMember = "descrizione";
            this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbCausale.ItemHeight = 13;
            this.cmbCausale.Location = new System.Drawing.Point(64, 56);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(256, 21);
            this.cmbCausale.TabIndex = 2;
            this.cmbCausale.ValueMember = "idtipo";
            this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
            // 
            // cmbTipoContabilizzazione
            // 
            this.cmbTipoContabilizzazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbTipoContabilizzazione.ItemHeight = 13;
            this.cmbTipoContabilizzazione.Location = new System.Drawing.Point(128, 32);
            this.cmbTipoContabilizzazione.Name = "cmbTipoContabilizzazione";
            this.cmbTipoContabilizzazione.Size = new System.Drawing.Size(192, 21);
            this.cmbTipoContabilizzazione.TabIndex = 1;
            this.cmbTipoContabilizzazione.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContabilizzazione_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 98;
            this.label8.Text = "Tipo contabilizzazione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxDocumento
            // 
            this.gboxDocumento.Controls.Add(this.btnDocumento);
            this.gboxDocumento.Controls.Add(this.cmbTipoDocumento);
            this.gboxDocumento.Controls.Add(this.label7);
            this.gboxDocumento.Controls.Add(this.txtNumDoc);
            this.gboxDocumento.Controls.Add(this.label10);
            this.gboxDocumento.Controls.Add(this.txtEsercDoc);
            this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
            this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.gboxDocumento.Location = new System.Drawing.Point(8, 80);
            this.gboxDocumento.Name = "gboxDocumento";
            this.gboxDocumento.Size = new System.Drawing.Size(312, 72);
            this.gboxDocumento.TabIndex = 3;
            this.gboxDocumento.TabStop = false;
            this.gboxDocumento.Text = "Documento contabilizzato";
            this.gboxDocumento.Visible = false;
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumento.Location = new System.Drawing.Point(8, 48);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(72, 20);
            this.btnDocumento.TabIndex = 10;
            this.btnDocumento.TabStop = false;
            this.btnDocumento.Text = "Documento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DataSource = this.DS.invoicekind;
            this.cmbTipoDocumento.DisplayMember = "description";
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.Location = new System.Drawing.Point(40, 16);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(264, 21);
            this.cmbTipoDocumento.TabIndex = 1;
            this.cmbTipoDocumento.Tag = "invoice.idinvkind?incomeinvoiceview.idinvkind";
            this.cmbTipoDocumento.ValueMember = "idinvkind";
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Eserc.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(240, 48);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
            this.txtNumDoc.TabIndex = 4;
            this.txtNumDoc.TabStop = false;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(208, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Num.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(128, 48);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
            this.txtEsercDoc.TabIndex = 2;
            this.txtEsercDoc.TabStop = false;
            this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
            // 
            // labelTipoDocumento
            // 
            this.labelTipoDocumento.Location = new System.Drawing.Point(8, 16);
            this.labelTipoDocumento.Name = "labelTipoDocumento";
            this.labelTipoDocumento.Size = new System.Drawing.Size(32, 16);
            this.labelTipoDocumento.TabIndex = 6;
            this.labelTipoDocumento.Text = "Tipo";
            this.labelTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCausale
            // 
            this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelCausale.Location = new System.Drawing.Point(8, 56);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(48, 23);
            this.labelCausale.TabIndex = 96;
            this.labelCausale.Text = "Causale";
            this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabConfirm
            // 
            this.tabConfirm.Controls.Add(this.labOperazione);
            this.tabConfirm.Location = new System.Drawing.Point(0, 0);
            this.tabConfirm.Name = "tabConfirm";
            this.tabConfirm.Selected = false;
            this.tabConfirm.Size = new System.Drawing.Size(712, 421);
            this.tabConfirm.TabIndex = 5;
            this.tabConfirm.Title = "Pagina 4 di 4";
            this.tabConfirm.Visible = false;
            // 
            // labOperazione
            // 
            this.labOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labOperazione.Location = new System.Drawing.Point(8, 8);
            this.labOperazione.Name = "labOperazione";
            this.labOperazione.Size = new System.Drawing.Size(696, 48);
            this.labOperazione.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(645, 464);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(525, 464);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(437, 464);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Frm_income_wizardcontabilizza
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(728, 499);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_income_wizardcontabilizza";
            this.Text = "FrmEntrataWizardContabilizza";
            this.tabController.ResumeLayout(false);
            this.tabSelectMov.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
            this.gboxUpb.ResumeLayout(false);
            this.gboxUpb.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabIntro.ResumeLayout(false);
            this.tabSelectDoc.ResumeLayout(false);
            this.gboxDocumento.ResumeLayout(false);
            this.gboxDocumento.PerformLayout();
            this.tabConfirm.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		int currphase() {
			return CfgFn.GetNoNullInt32( cmbFaseEntrata.SelectedValue);
		}
		public void MetaData_AfterActivation(){
			CustomTitle= "Wizard Aggiunta Contabilizzazioni";
			//Selects first tab
			DisplayTabs(0);
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			GetData.CacheTable(DS.expensephase);
			GetData.CacheTable(DS.incomephase,null,null,true);
			GetData.CacheTable(DS.manager,null,"title",true);
			txtEsercizioMovimento.Text= Meta.GetSys("esercizio").ToString();
			faseivaentrata = CfgFn.GetNoNullInt32( Meta.GetSys("invoiceincomephase"));
            faseentratacontab = CfgFn.GetNoNullInt32(Meta.GetSys("estimatephase"));
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterinvoice = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2));
			GetData.CacheTable(DS.invoicekind,filterinvoice,null,true);
			currcont = tipocont.cont_none;
		}
		public void MetaData_AfterClear(){
			DisplayTabs(tabController.SelectedIndex);
		}

		#region Gestione Tabs

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
			tabController.SelectedIndex= newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible=(newTab>0);
			if (newTab== tabController.TabPages.Count-1)
				btnNext.Text="Associa.";
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
			if ((oldTab==1)&&(newTab==2)){
				if (! GetMovimentoSelezionato()) return false; 
				CalcolaContabilizzazioniPossibili();
				AbilitaDisabilitaControlliContabilizzazione(true);
				return true;
			}
			if ((oldTab==2)&&(newTab==1)){
				ClearContabilizzazioni();
				SetContabilizzazione(tipocont.cont_none);
				ClearComboCausale();
				return true;
			}; 
			if ((oldTab==2)&&(newTab==3)){
				if (!GetDocumentoSelezionato()) return false; 
				DataRow Curr = DS.income.Rows[0];
				labOperazione.Text="Il movimento di entrata "+
					Curr["ymov"].ToString()+"/"+Curr["nmov"].ToString()+
					" sarà associato " + CurrDocDescr;
				return true;
			}
			if ((oldTab==3)&&(newTab==4))return doAssocia(); 
			return true;
		}

		#endregion


		#region Gestione Selezione Movimento

		
		void ClearContabilizzazioni(){
			DS.incomeinvoice.Clear();
			DS.invoice.Clear();
		}

		bool GetMovimentoSelezionato() {
			if (txtNumeroMovimento.Text.Trim()==""){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Selezionare un movimento per procedere");
				return false;
			}
			if (currcont!= tipocont.cont_none){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Al movimento selezionato è già associata una contabilizzazione.");
				return false;
			}
			string filter= GetFasePrecFilter(true);
			MetaData MFase = MetaData.GetMetaData(this,"income");
			MFase.FilterLocked=true;
			MFase.DS=DS.Copy();
			
			DataRow MyDR = MFase.SelectOne("default",filter,null,null);
			if (MyDR==null) return false;
			AddAllCollegate(MyDR);

            string keyentratafilter = QHS.AppAnd(QHS.CmpEq("idinc", MyDR["idinc"]),
                                               QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            currimp = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("incomeview", keyentratafilter, "curramount"));

			DS.incomeinvoice.Clear();
			return true;
		}



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

		void AddVociCollegate(DataRow Row){
			
			if (Row.Table.TableName == "expense")
				AddVoceFaseSpesa(Row["nphase"]);
			else
				AddVoceFaseEntrata(Row["nphase"]);
			AddVoceCreditore(Row["idreg"]);
			AddVoceResponsabile(Row["idman"]);
			DataRow Imputazione=null;
			if (Row.Table.TableName == "expense"){
				DataRow [] Imputazioni = Row.GetChildRows("expenseexpenseyear");
				if (Imputazioni.Length>0) Imputazione= Imputazioni[0];
			}
			else {
				DataRow [] Imputazioni = Row.GetChildRows("incomeincomeyear");
				if (Imputazioni.Length>0) Imputazione= Imputazioni[0];
			}
			if (Imputazione!=null) {
				AddVoceBilancio(Imputazione["idfin"]);
				AddVoceUPB(Imputazione["idupb"]);
			}
		}

		void AddVociFiglie(DataRow Mov){
			string filter;
			int fasespesamax= CfgFn.GetNoNullInt32( Meta.GetSys("maxexpensephase"));
			int faseentratamax= CfgFn.GetNoNullInt32( Meta.GetSys("maxincomephase"));
			int faseivaentrata = CfgFn.GetNoNullInt32( Meta.GetSys("invoiceincomephase"));
            int faseentratacont = CfgFn.GetNoNullInt32(Meta.GetSys("estimatephase"));

			int fasebilent = CfgFn.GetNoNullInt32( Meta.GetSys("incomefinphase"));

			if (Mov.Table.TableName == "expense"){
                int nfase = CfgFn.GetNoNullInt32(Mov["nphase"]);
                filter = QHC.CmpEq("idexp", Mov["idexp"]);
				
				AddVociFiglieWhereEmpty(DS.expensevar,filter);
				AddVociFiglieWhereEmpty(DS.expenseyear,filter);
			}
			else {
                int nfase = CfgFn.GetNoNullInt32(Mov["nphase"]);
                filter = filter = QHC.CmpEq("idinc", Mov["idinc"]);


				AddVociFiglieWhereEmpty(DS.incomevar,filter);
				AddVociFiglieWhereEmpty(DS.incomeyear,filter);

				if (nfase == faseivaentrata)
					AddVociFiglieWhereEmpty(DS.incomeinvoice,filter);
                if (nfase == faseentratacont)
                    AddVociFiglieWhereEmpty(DS.incomeestimate, filter);
			}
		}


		void AddAllCollegate(DataRow R){
			DS.expense.Clear();
			DS.income.Clear();
			DS.incomeinvoice.Clear();
			DS.incomeyear.Clear();
			DS.expenseyear.Clear();
			DS.incomevar.Clear();
			DS.expensevar.Clear();


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

			foreach (DataRow R1 in DS.expense.Rows){
				AddVociFiglie(R1);
				AddVociCollegate(R1);
			}
			foreach (DataRow R2 in DS.income.Rows){
				AddVociFiglie(R2);
				AddVociCollegate(R2);
			}


		}



        string GetFasePrecFilter(bool FiltraNumMovimento) {
            string ffase = "";
            if (cmbFaseEntrata.SelectedIndex > 0) {
                ffase = QHS.CmpEq("nphase", cmbFaseEntrata.SelectedValue);
            }
            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
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

			MetaData MFase = MetaData.GetMetaData(this,"income");
			MFase.FilterLocked=true;
			MFase.DS=DS;
			
			DataRow MyDR = MFase.SelectOne("default",MyFilter,null,null);
			
			if(MyDR == null) {
				if (Meta.InsertMode){
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
					}
				}
				currcont=tipocont.cont_none;
				return;
			}

			txtEsercizioMovimento.Text=MyDR["ymov"].ToString();
			txtNumeroMovimento.Text=MyDR["nmov"].ToString();

			txtCredDeb.Text= MyDR["registry"].ToString();
			txtDescrizione.Text= MyDR["description"].ToString();
			SubEntity_txtImportoMovimento.Text= CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
			txtDataCont.Text= ((DateTime)MyDR["adate"]).ToShortDateString();
			txtCodiceBilancio.Text=MyDR["codefin"].ToString();
			txtDenominazioneBilancio.Text=MyDR["finance"].ToString();
			txtUpb.Text= MyDR["codeupb"].ToString();
			txtDescrizioneUpb.Text= MyDR["upb"].ToString();
            txtResponsabile.Text = MyDR["manager"].ToString();
            gestisciEventoCmbFaseEntrata = false;
            cmbFaseEntrata.SelectedValue = MyDR["nphase"];
            gestisciEventoCmbFaseEntrata = true;

			txtImportoCorrente.Text= CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
			txtImportoDisponibile.Text= CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");

			DS.incomeinvoice.Clear();

            int fase = CfgFn.GetNoNullInt32(MyDR["nphase"]);
			if (fase == faseivaentrata)
				DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.incomeinvoice,null,QHS.CmpEq("idinc", MyDR["idinc"]),null,true);

			currcont=DeduciTipoContabilizzazione();
			
			if (currcont==tipocont.cont_none) {
				labContabAttuale.Text="";
				return;
			}

			string MSG;
			MSG = "Il movimento di entrata selezionato contabilizza ";
			switch(currcont){
				case tipocont.cont_iva: 
					DataRow Iva = DS.incomeinvoice.Rows[0];
					string codicetipodoc = Iva["idinvkind"].ToString();
					DataRow[] TipoDoc= DS.invoicekind.Select(QHC.CmpEq("idinvkind",codicetipodoc));
					string TIPO="";
					if (TipoDoc.Length==1){
						TIPO= "("+TipoDoc[0]["description"].ToString()+")";
					}
					MSG+= "il documento iva "+TIPO+" "+ 
						Iva["yinv"].ToString()+"/"+Iva["ninv"].ToString()+".";
					break;
			}
			labContabAttuale.Text= MSG;
					
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


		#endregion

		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}

		private void cmbFaseSpesa_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (gestisciEventoCmbFaseEntrata) {
                Clear();
            }
		}
		void Clear(){
			txtNumeroMovimento.Text="";
			txtCredDeb.Text= "";
			txtDescrizione.Text= "";
			SubEntity_txtImportoMovimento.Text= "";
			txtDataCont.Text= "";
			txtCodiceBilancio.Text="";
			txtDenominazioneBilancio.Text="";
			txtUpb.Text= "";
			txtDescrizioneUpb.Text= "";
            txtResponsabile.Text = "";
			txtImportoCorrente.Text= "";
			txtImportoDisponibile.Text= "";
			currcont=tipocont.cont_none;
			gboxDocumento.Visible=false;
		}

		bool GetDocumentoSelezionato(){
			tipocont TC = DeduciTipoContabilizzazione();
			if (TC==tipocont.cont_none) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stato selezionato alcun documento da contabilizzare.");
				return false;
			}
			if (cmbCausale.SelectedValue==null){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Non è stata selezionata la causale del documento.");
				return false;
			}
			switch (TC){
				case tipocont.cont_iva:
					DataRow CurrIva= DS.invoice.Rows[0];
					CurrDocDescr="al doc iva "+CurrIva["yinv"].ToString()+
						"/"+CurrIva["ninv"].ToString();
					break;
			}
			
			return true;
		}

		bool doAssocia(){
				
			DataRow Curr= DS.income.Rows[0];

			if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Aggiorno i campi documento e data documento del movimento di entrata "+
				"in base al documento selezionato?","Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK) {
				Curr["doc"]= NuovoDocumento;
				Curr["docdate"]= NuovoDataDocumento;
			}
			if (MetaFactory.factory.getSingleton<IMessageShower>().Show(this,"Aggiorno il campo description del movimento di entrata "+
				"in base al doc selezionato?","Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK){
				Curr["description"]= NuovoDescrizione;
			}
						
			PostData Post = Meta.Get_PostData();
			Post.InitClass(DS,Conn);
			bool res= Post.DO_POST();
			if (res)MetaFactory.factory.getSingleton<IMessageShower>().Show("Aggiunta della contabilizzazione eseguita con successo.");
			if (!res) Curr.RejectChanges();
			return res;
		}

		#region Gestione ComboBox Causali (generico)

		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui è agganciato il combo causale
		/// </summary>
		void ClearComboCausale(){
			DataTable TCombo= DS.tipomovimento;
			TCombo.Clear();
			cmbCausale.Enabled=false;
		}

		void EnableTipoMovimento(int IDtipo, string descrtipo){
			DataRow R = DS.tipomovimento.NewRow();
			R["idtipo"]= IDtipo;
			R["descrizione"]= descrtipo;
			DS.tipomovimento.Rows.Add(R);
			DS.tipomovimento.AcceptChanges();
		}

		/// <summary>
		/// Restituisce la contabilizzazione selezionata nel combobox cmbTipoContabilizz.
		/// </summary>
		/// <returns></returns>
		tipocont ContabilizzazioneSelezionata(){
			if (cmbTipoContabilizzazione.Items.Count==0) return tipocont.cont_none;
			if (cmbTipoContabilizzazione.SelectedItem == null) return tipocont.cont_none;
			string currTipo = cmbTipoContabilizzazione.SelectedItem.ToString();
			tipocont codecont= CodiceContabilizzazione(currTipo);
			return codecont;
		}
		private void cmbTipoContabilizzazione_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!cmbTipoContabilizzazione.Enabled) return;
			tipocont codecont = ContabilizzazioneSelezionata();
			AttivaContabilizzazione(codecont);
		}
		

		/// <summary>
		/// Imposta il valore del combobox ed aggiorna l'importo del movimento
		/// </summary>
		/// <param name="tipomovimento"></param>
		void SetValueComboCausale(string tipomovimento){
			cmbCausale.SelectedValue= tipomovimento;
			RecalcImporto();
		}

		void RecalcImporto(){
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					ReCalcImporto_Iva();
					return;
				case tipocont.cont_none:
					return;
			}
		}


		#endregion


		#region Gestione Documenti Contabilizzazione

		private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					cmbCausaleIva_SelectedIndexChanged(sender,e);
					break;
                case tipocont.cont_contrattoattivo:
                    cmbCausaleContrattoAttivo_SelectedIndexChanged(sender, e);
                    break;
			}
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					btnIva_Click(sender,e);
					break;
                case tipocont.cont_contrattoattivo:
                    btnContrattoAttivo_Click(sender, e);
                    break;
			}
		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					txtEsercIva_Leave(sender,e);
					break;
                case tipocont.cont_contrattoattivo:
					txtEsercContrattoAttivo_Leave(sender,e);
					break;
			}
		}

		private void txtNumDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					txtNumIva_Leave(sender,e);
					break;
                case tipocont.cont_contrattoattivo:
                    txtNumContrattoAttivo_Leave(sender, e);
                    break;
			}
		}


		tipocont DeduciTipoContabilizzazione(){
			if (DS.incomeinvoice.Rows.Count>0) return tipocont.cont_iva;
            if (DS.incomeestimate.Rows.Count > 0) return tipocont.cont_contrattoattivo;
			return tipocont.cont_none;
		}

		// DEVO CONTINUARE DA QUI <<<<<<<<<<<<<<<<<<<<----------------------->>>>>>>>>>>>>>>>>>>>>>>>
		

		
		/// <summary>
		/// Imposta il combo del tipo contabilizzazione con un valore assegnato
		/// </summary>
		/// <param name="tipo"></param>
		void SetContabilizzazione(tipocont tipo){
			for (int i=0; i< cmbTipoContabilizzazione.Items.Count; i++){
				if (cmbTipoContabilizzazione.Items[i].ToString()== 
					NomeContabilizzazione(tipo)){
					cmbTipoContabilizzazione.SelectedIndex=i;
				}
			}
		}

		/// <summary>
		/// Ricalcola il combo delle contabilizzazioni in base alle fasi selezionate,
		///  ed eventualmente scollega i documenti non più collegabili
		/// </summary>
		//		void GestioneFasePerDocumentoCollegato(){
		//			tipocont oldcont = ContabilizzazioneSelezionata();
		//			//disabilita gli eventi collegati al cmbTipoContabilizzazione
		//			cmbTipoContabilizzazione.Enabled=false;
		//			cmbTipoContabilizzazione.Items.Clear();
		//			CalcolaContabilizzazioniPossibili();
		//			if (ContabilizzazioneAttivabile(oldcont)){
		//				SetContabilizzazione(oldcont);
		//				if (!Meta.EditMode) cmbTipoContabilizzazione.Enabled=true;
		//				VisualizzaControlliContabilizzazione(oldcont);
		//				return;
		//			}
		//			if (!Meta.EditMode)cmbTipoContabilizzazione.Enabled=true;
		//			SetContabilizzazione(tipocont.cont_none);
		//			AttivaContabilizzazione(tipocont.cont_none);
		//		}
		//
		void AbilitaDisabilitaControlliContabilizzazione(bool abilita){
			cmbCausale.Enabled= abilita ;
			cmbTipoDocumento.Enabled= abilita ;
			btnDocumento.Enabled=abilita ;
			txtEsercDoc.ReadOnly=(!abilita) ;
			txtNumDoc.ReadOnly=(!abilita);
			cmbTipoContabilizzazione.Enabled=abilita ;
		}

		/// <summary>
		/// Visualizza/Nasconde i controlli relativi alla contabilizzazione scelta, 
		///  (inclusi btn, txtCredDeb, etc. ) impostandone anche i tag. 
		/// </summary>
		/// <param name="codecont"></param>
		void VisualizzaControlliContabilizzazione(tipocont codecont){
			cmbCausale.Visible=true;
			labelCausale.Visible=true;
			gboxDocumento.Visible=true;
			txtEsercDoc.ReadOnly= false;
			txtNumDoc.ReadOnly= false;
			btnDocumento.Enabled= true;
			cmbTipoDocumento.Enabled = true;

			switch(codecont){
				case tipocont.cont_iva:
					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					btnDocumento.Text="Documento";
					txtEsercDoc.Tag=
						"incomeinvoice.yinv?"+
						"incomeinvoiceview.yinv";
					txtNumDoc.Tag=
						"incomeinvoice.ninv?"+
						"incomeinvoiceview.ninv";
					cmbTipoDocumento.Tag=
						"incomeinvoice.idinvkind?"+
						"incomeinvoiceview.idinvkind";
					AbilitaDisabilitaControlliIva(false);
					break;
                case tipocont.cont_contrattoattivo:
                    labelTipoDocumento.Visible = true;
                    cmbTipoDocumento.Visible = true;
                    btnDocumento.Text = "Contratto Attivo";
                    txtEsercDoc.Tag =
                        "incomeestimate.yestim?" +
                        "incomeestimateview.yestim";
                    txtNumDoc.Tag =
                        "incomeestimate.nestim?" +
                        "incomeestimateview.nestim";
                    cmbTipoDocumento.Tag =
                        "incomeestimate.idestimkind?" +
                        "incomeestimateview.idestimkind";
                    AbilitaDisabilitaControlliContrattoAttivo(false);
                    break;
				case tipocont.cont_none:
					cmbTipoDocumento.Tag= null;
					txtEsercDoc.Tag=null;
					txtNumDoc.Tag=null;
					NascondiControlliContabilizzazione();
					break;
			}
			//ClearComboCausale();
		}

		void NascondiControlliContabilizzazione(){
			cmbCausale.Visible=false;
			labelCausale.Visible=false;
			gboxDocumento.Visible=false;
		}


		string NomeContabilizzazione(tipocont TIPO){
			switch (TIPO){
				case tipocont.cont_iva: return "Documento Iva";
                case tipocont.cont_contrattoattivo: return "Contratto Attivo";
				case tipocont.cont_none: return "";
			}
			return null;
		}
		tipocont CodiceContabilizzazione(string nomecont){
			switch(nomecont){
				case "Documento Iva": return tipocont.cont_iva;
                case "Contratto Attivo": return tipocont.cont_contrattoattivo;
				case "":return tipocont.cont_none;
			}
			return tipocont.cont_none;
		}

		/// <summary>
		/// Stabilisce se è possibile con la fase corrente contabilizzare un
		///  certo tipo di documento
		/// </summary>
		/// <returns></returns>
		bool ContabilizzazioneAttivabile(tipocont codecont){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseEntrata.SelectedValue);
			switch(codecont){
				case tipocont.cont_iva:
					//if (faseIvaInclusa())return true;
					return false;
                case tipocont.cont_contrattoattivo:
                    //if (faseContrattoAttivoInclusa()) return true;
                    return false;
				default:
					return false;
			}
		}

		bool faseIvaInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseEntrata.SelectedValue);
			if (currphase==faseivaentrata)return true;
			return false;
		}

        bool faseContrattoAttivoInclusa() {
            int currphase = CfgFn.GetNoNullInt32(cmbFaseEntrata.SelectedValue);
            if (currphase == faseentratacontab) return true;
            return false;
        }

		/// <summary>
		/// Riempie il Combo del tipo di Contabilizzazione con
		///  le scelte possibili in base alla fase corrente
		/// </summary>
		void CalcolaContabilizzazioniPossibili(){
			cmbTipoContabilizzazione.Items.Clear();
			cmbTipoContabilizzazione.Items.Add("");
			foreach (tipocont codecont in new tipocont[] {
															 tipocont.cont_iva}){
				if (ContabilizzazioneAttivabile(codecont))
					cmbTipoContabilizzazione.Items.Add(
						NomeContabilizzazione(codecont));
			}																								   
		}
		
		/// <summary>
		/// Funzione chiamata quando cambia il combo delle contabilizzazioni
		/// Disattiva tutte le contabilizzazioni e poi attiva quella indicata.
		/// Scollega qualsiasi documento collegato
		/// </summary>
		/// <param name="codecont"></param>
		void AttivaContabilizzazione(tipocont codecont){
			foreach(tipocont disattivacont in new tipocont[]{
																tipocont.cont_iva, tipocont.cont_contrattoattivo}){
				DisattivaContabilizzazione(disattivacont);
			}
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			VisualizzaControlliContabilizzazione(codecont);
			ClearComboCausale();
		}

		void DisattivaContabilizzazione(tipocont codecont){
			switch(codecont){
				case tipocont.cont_iva:
					if (faseIvaInclusa()) ScollegaIva();
					return;
                case tipocont.cont_contrattoattivo:
                    if (faseIvaInclusa()) ScollegaContrattoAttivo();
                    return;
			}

		}



	
		#endregion


		#region Gestione Selezione Documento Iva 

		string FilterIva;

		//		void AbilitaDisabilitaBtnOrdine(){
		//			bool SelezioneOrdineAttiva = ((Meta.IsEmpty)||(Meta.InsertMode));
		//			btnOrdine.Enabled=  SelezioneOrdineAttiva;
		//			txtNumOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			txtEsercOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumOrdine.Text.Trim()!="");
		//			txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//		}

		private void txtEsercIva_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
			//CalcolaStartFilter(null);
		}

		string GetFilterIva(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			FilterIva="(yinv<='"+esercizio.ToString()+"')";
			if(txtEsercDoc.Text != ""){
				int esercdocumento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercdocumento <= esercizio) 
						FilterIva="(yinv='"+esercdocumento.ToString()+"')";
					else 
						FilterIva = GetData.MergeFilters(FilterIva,
							"(yinv='"+esercdocumento.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numdocumento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterIva = GetData.MergeFilters(FilterIva,
						"(ninv='"+numdocumento.ToString()+"')");
				} 
			}
			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex<=0){
                filtertipodoc = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2));
			}
			else {
				filtertipodoc = "(idinvkind="+
					QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue,true)+")";
			}
			FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

			//eventualmente appende al filtro sull'ordine un filtro sul creditore.
			//Questo accade se la fase creditore è precedente a quella della missione e la
			// fase creditore è precedente alla prima fase selezionata ed il 
			// movimento relativo alla fase precedente è stato selezionato
			//			int fasecreditore = ManageCreditore.faseattivazione;
			//			bool fasecredcond = (fasecreditore<currphase) && (fasecreditore<faseiva);
			//			if (Meta.IsEmpty) return FilterIva;
			//			DataRow Curr = DS.spesa.Rows[0];
			//			bool faseprecselected = (Curr["livsupidspesa"]!=DBNull.Value);
			//			if (fasecredcond && faseprecselected){
			//				FilterIva = GetData.MergeFilters(FilterIva,
			//					"(codicecreddeb="+QueryCreator.quotedstrvalue(
			//					Curr["codicecreddeb"],true)+")");
			//			}
			//
			return FilterIva;
		}


		private void btnIva_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);
			string MyIvaFilter;
			string MyFilterIvaOperativo;
			if (((Control)sender).Name == "txtNumDoc")
				MyIvaFilter = GetFilterIva(true);
			else
				MyIvaFilter = GetFilterIva(false);

			MyFilterIvaOperativo= MyIvaFilter;

			bool condfasecred = chkCredDeb.Checked;
			if (condfasecred){
				MyFilterIvaOperativo= GetData.MergeFilters(MyFilterIvaOperativo,
					"(registry="+
					QueryCreator.quotedstrvalue(txtCredDeb.Text,true)+")");
			}

			MetaData MDocumentoIva;
			DataRow MyDRIva;

			MDocumentoIva = MetaData.GetMetaData(this,"invoiceavailable");
			MDocumentoIva.FilterLocked=true;
			MDocumentoIva.DS = DS.Clone();
			
			string filter2 = "(residual >= " + QueryCreator.quotedstrvalue(currimp,true)
				+ ") and ((active is null) or (active = 'S'))";

			MyDRIva = MDocumentoIva.SelectOne("default",
				GetData.MergeFilters(MyFilterIvaOperativo, filter2
				//"(residual>="+QueryCreator.quotedstrvalue(currimp,true)+")"
				),

				null,null);
			
			if(MyDRIva == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectord= 
				"(idinvkind="+QueryCreator.quotedstrvalue(MyDRIva["idinvkind"],true)+")AND"+
				"(yinv='"+MyDRIva["yinv"].ToString()+"')AND"+
				"(ninv='"+MyDRIva["ninv"].ToString()+"')";

			string columnlist = QueryCreator.ColumnNameList(DS.invoice)+
				",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("invoiceview",columnlist,null,selectord,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			ResetIva();
			CollegaIva(MyDR);
	
		}

		private void txtNumIva_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;
			//CalcolaStartFilter(null);


			if (txtNumDoc.Text.Trim()==""){
				ScollegaIva();				
				ClearControlliIva(true);
				return;
			}
			btnIva_Click(sender,e);
		}

		void ClearControlliIva(bool skipTipoDoc){
			//txtCredDeb.Text = "";		
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex=-1;
		}

		void AbilitaDisabilitaControlliIva(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaIva(DataRow Iva2){

			Hashtable ValoriDocumentoIva = new Hashtable();
			foreach (DataColumn C in DS.invoice.Columns) 
				ValoriDocumentoIva[C.ColumnName]= Iva2[C.ColumnName];

			ScollegaIva();

			if (!faseIvaInclusa()) return;

			DataRow NewIvaR = DS.invoice.NewRow();

			foreach (DataColumn C in DS.invoice.Columns){
				NewIvaR[C.ColumnName]= ValoriDocumentoIva[C.ColumnName];
			}

			DS.invoice.Rows.Add(NewIvaR);
			NewIvaR.AcceptChanges();

			DataRow CurrRow= DS.income.Rows[0];
			MetaData MovIva = MetaData.GetMetaData(this,"incomeinvoice");
			MovIva.SetDefaults(DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue=ValoriDocumentoIva["idinvkind"];
			DS.incomeinvoice.Columns["ninv"].DefaultValue= ValoriDocumentoIva["ninv"];
			DS.incomeinvoice.Columns["yinv"].DefaultValue= ValoriDocumentoIva["yinv"];
			txtNumDoc.Text=ValoriDocumentoIva["ninv"].ToString();
			txtEsercDoc.Text=ValoriDocumentoIva["yinv"].ToString();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriDocumentoIva["idinvkind"]);
			TipoDocChangePilotato=false;

			DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
			DS.incomeinvoice.Columns["ninv"].DefaultValue= DBNull.Value;
			DS.incomeinvoice.Columns["yinv"].DefaultValue= DBNull.Value;

			NuovoDocumento= "Doc."+ValoriDocumentoIva["doc"];
			NuovoDataDocumento = (DateTime)ValoriDocumentoIva["docdate"];
			NuovoDescrizione = ValoriDocumentoIva["description"];

			RintracciaIva();
			SetComboCausaleIva(NewIvaR);
			AbilitaDisabilitaControlliIva(false);
			cmbCausale.Enabled=true;
		}

		void ScollegaIva(){
			if (DS.incomeinvoice.Rows.Count==0) return;
			DS.incomeinvoice.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			ClearControlliIva(false);
			NuovoDocumento=null;
			NuovoDataDocumento=null;
			NuovoDescrizione=null;
		}

		#endregion

        #region Gestione Selezione Contratto Attivo
        string FilterContrattoAttivo;

        private void txtEsercContrattoAttivo_Leave(object sender, System.EventArgs e) {
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
            //CalcolaStartFilter(null);
        }

        string GetFilterContrattoAttivo(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            FilterContrattoAttivo = QHS.CmpLe("yestim", esercizio);
            if (txtEsercDoc.Text != "") {
                int esercdocumento = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (esercdocumento <= esercizio)
                        FilterContrattoAttivo = QHS.CmpEq("yestim", esercdocumento);
                    else
                        FilterContrattoAttivo = GetData.MergeFilters(FilterIva,
                            QHS.CmpEq("yestim", esercdocumento));
                }
                catch {
                }
            }
            if (FiltraNum) {
                int numdocumento = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterContrattoAttivo = GetData.MergeFilters(FilterIva,
                        QHS.CmpEq("(nestim", numdocumento));
                }
            }
            string filtertipodoc;
            if (cmbTipoDocumento.SelectedIndex <= 0) {
                filtertipodoc = null;
            }
            else {
                filtertipodoc = QHS.CmpEq("idestimkind", cmbTipoDocumento.SelectedValue);
            }
            FilterContrattoAttivo = GetData.MergeFilters(FilterContrattoAttivo, filtertipodoc);

            return FilterContrattoAttivo;
        }


        private void btnContrattoAttivo_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);
            string MyContrattoAttivoFilter;
            string MyFilterContrattoAttivoOperativo;
            if (((Control)sender).Name == "txtNumDoc")
                MyContrattoAttivoFilter = GetFilterContrattoAttivo(true);
            else
                MyContrattoAttivoFilter = GetFilterContrattoAttivo(false);

            MyFilterContrattoAttivoOperativo = MyContrattoAttivoFilter;

            bool condfasecred = chkCredDeb.Checked;
            if (condfasecred) {
                MyFilterContrattoAttivoOperativo = GetData.MergeFilters(MyFilterContrattoAttivoOperativo,
                    QHS.CmpEq("registry", txtCredDeb.Text));
            }

            MetaData MContrattoAttivo;
            DataRow MyDRContrattoAttivo;

            MContrattoAttivo = MetaData.GetMetaData(this, "estimateavailable");
            MContrattoAttivo.FilterLocked = true;
            MContrattoAttivo.DS = DS.Clone();

            string filter2 = QHS.AppAnd(QHS.CmpGe("residual", currimp), QHS.NullOrEq("active", "S"));

            MyDRContrattoAttivo = MContrattoAttivo.SelectOne("default",
                GetData.MergeFilters(MyFilterContrattoAttivoOperativo, filter2
                ),
                null, null);

            if (MyDRContrattoAttivo == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox)sender).Text.Trim() != "") ((TextBox)sender).Focus();
                }
                return;
            }
            string selectord = QHS.AppAnd(QHS.CmpEq("idestimkind", MyDRContrattoAttivo["idestimkind"]),
                QHS.AppAnd(QHS.CmpEq("yestim", MyDRContrattoAttivo["yestim"]), QHS.CmpEq("nestim", MyDRContrattoAttivo["nestim"])));

            string columnlist = QueryCreator.ColumnNameList(DS.estimate) +
                ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("estimateview", columnlist, null, selectord, null, null, true);

            //if (Temp.Rows.Count==0) return;

            DataRow MyDR = Temp.Rows[0];


            ResetContrattoAttivo();
            CollegaContrattoAttivo(MyDR);

        }

        private void txtNumContrattoAttivo_Leave(object sender, System.EventArgs e) {
            if (txtNumDoc.ReadOnly) return;

            if (txtNumDoc.Text.Trim() == "") {
                ScollegaContrattoAttivo();
                ClearControlliContrattoAttivo(true);
                return;
            }
            btnContrattoAttivo_Click(sender, e);
        }

        void ClearControlliContrattoAttivo(bool skipTipoDoc) {
            //txtCredDeb.Text = "";		
            if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex = 0;
        }
       
        void AbilitaDisabilitaControlliContrattoAttivo(bool abilita) {
            //txtCredDeb.ReadOnly=!abilita;
        }

        /// <summary>
        /// Collega la riga al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        void CollegaContrattoAttivo(DataRow ContrAttivo2) {

            Hashtable ValoriContrattoAttivo = new Hashtable();
            foreach (DataColumn C in DS.estimate.Columns)
                ValoriContrattoAttivo[C.ColumnName] = ContrAttivo2[C.ColumnName];

            ScollegaContrattoAttivo();

            if (!faseContrattoAttivoInclusa()) return;

            DataRow NewCAR = DS.estimate.NewRow();

            foreach (DataColumn C in DS.estimate.Columns) {
                NewCAR[C.ColumnName] = ValoriContrattoAttivo[C.ColumnName];
            }

            DS.estimate.Rows.Add(NewCAR);
            NewCAR.AcceptChanges();

            DataRow CurrRow = DS.income.Rows[0];
            MetaData MovCA = MetaData.GetMetaData(this, "incomeestimate");
            MovCA.SetDefaults(DS.incomeestimate);
            DS.incomeestimate.Columns["idestimkind"].DefaultValue = ValoriContrattoAttivo["idestimkind"];
            DS.incomeestimate.Columns["nestim"].DefaultValue = ValoriContrattoAttivo["nestim"];
            DS.incomeestimate.Columns["yestim"].DefaultValue = ValoriContrattoAttivo["yestim"];
            txtNumDoc.Text = ValoriContrattoAttivo["nestim"].ToString();
            txtEsercDoc.Text = ValoriContrattoAttivo["yestim"].ToString();
            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, ValoriContrattoAttivo["idestimkind"]);
            TipoDocChangePilotato = false;

            DataRow RMovCA = MovCA.Get_New_Row(CurrRow, DS.incomeestimate);
            DS.incomeestimate.Columns["idestimkind"].DefaultValue = DBNull.Value;
            DS.incomeestimate.Columns["nestim"].DefaultValue = DBNull.Value;
            DS.incomeestimate.Columns["yestim"].DefaultValue = DBNull.Value;

            NuovoDocumento = "Doc." + ValoriContrattoAttivo["doc"];
            NuovoDataDocumento = (DateTime)ValoriContrattoAttivo["docdate"];
            NuovoDescrizione = ValoriContrattoAttivo["description"];

            RintracciaContrattoAttivo();
            SetComboCausaleContrattoAttivo(NewCAR);
            AbilitaDisabilitaControlliContrattoAttivo(false);
            cmbCausale.Enabled = true;
        }

        void ScollegaContrattoAttivo() {
            if (DS.incomeestimate.Rows.Count == 0) return;
            DS.incomeestimate.Clear();
            DS.estimate.Clear();
            ClearComboCausale();
            ClearControlliContrattoAttivo(false);
            NuovoDocumento = null;
            NuovoDataDocumento = null;
            NuovoDescrizione = null;
        }
        #endregion

        #region Gestione ComboBox Causale Iva


        decimal totimponibile_dociva;
		decimal totiva_dociva;
		decimal assigned_imponibile_dociva;
		decimal assigned_iva_dociva;
		decimal assigned_gen_dociva;

		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleIva(DataRow Ordine){
			if (currphase()!=faseivaentrata) return;
			DataAccess Conn= Meta.Conn;
			string filteriva = 
				"(idinvkind="+QueryCreator.quotedstrvalue(Ordine["idinvkind"],true)+")AND"+
				"(yinv='"+Ordine["yinv"].ToString()+"')AND"+
				"(ninv='"+Ordine["ninv"].ToString()+"')";
			totimponibile_dociva= CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("totinvoiceview", filteriva, "taxabletotal"));
			totiva_dociva =  CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("totinvoiceview", filteriva, "ivatotal"));
			string filterivamoventrataview = filteriva;
			//				GetData.MergeFilters(filterordine, 
			//				"(esercizio='"+Conn.sys["esercizio"].ToString()+"')");
			assigned_imponibile_dociva = CfgFn.GetNoNullDecimal( 
				Conn.DO_READ_VALUE("incomeinvoiceview", filterivamoventrataview+"AND(movkind=3)", "SUM(curramount)"));
			assigned_iva_dociva=	  CfgFn.GetNoNullDecimal( Conn.DO_READ_VALUE("incomeinvoiceview", filterivamoventrataview+"AND(movkind=2)", "SUM(curramount)"));
			assigned_gen_dociva=	  CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("incomeinvoiceview", filterivamoventrataview+"AND(movkind=1)", "SUM(curramount)"));
			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;


			bool found=false;
			if ((Meta.EditMode) || 
				((assigned_imponibile_dociva+assigned_iva_dociva)==0) && 
				(assigned_gen_dociva< (totimponibile_dociva+totiva_dociva)&&
				(totimponibile_dociva+totiva_dociva-assigned_gen_dociva>=currimp)
				)
				){
				EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
				found=true;
			}

			if ((Meta.EditMode) || 
				( (assigned_gen_dociva==0) &&(assigned_imponibile_dociva < totimponibile_dociva)&&
				(  (totimponibile_dociva-assigned_imponibile_dociva) >= currimp)
				)
				){
				EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
				found=true;
			}

			if ( (Meta.EditMode) || 
				( (assigned_gen_dociva==0) &&(assigned_iva_dociva< totiva_dociva)&&
				( (totiva_dociva-assigned_iva_dociva) >= currimp)
				)
				){
				EnableTipoMovimento(2,"Contabilizzazione iva documento");
				found=true;
			}
			if (!found){
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Il movimento selezionato ha un importo superiore al residuo del documento."+
					" La contabilizzazione è impossibile.");
			}
			DS.incomeinvoice.Rows[0]["movkind"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=true;
			ReCalcImporto_Iva();
			
		}


		void ReCalcImporto_Iva(){
			DataRow Curr = DS.Tables["income"].Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==2){
				importo= totiva_dociva-assigned_iva_dociva;
			}
			if (tipomovimento==3){
				importo= totimponibile_dociva-assigned_imponibile_dociva;
			}
			if (tipomovimento==1){
				importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
			}

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;
			if (importo<0) importo=0; //dovrebbe essere superfluo
	
			if (importo> currimp) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Sarà effettuata una contabilizzazione parziale del documento poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}


		private void cmbCausaleIva_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleIva();
			ReCalcImporto_Iva();
		}

		int GetCausaleIva(){
			CurrCausaleIva=0;
			if (DS.incomeinvoice.Rows.Count==0) return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.incomeinvoice.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.incomeinvoice.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleIva= CfgFn.GetNoNullInt32( DS.incomeinvoice.Rows[0]["movkind"]);
			return CurrCausaleIva;
			//ReCalcImporto();
		}


		bool TipoDocChangePilotato=false;
		private void cmbTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			ScollegaIva();
			ClearControlliIva(true);
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			ClearComboCausale();
			cmbCausale.Enabled=false;
			TipoDocChangePilotato=false;
		}

		#endregion

        #region Gestione ComboBox Causale Contratto Attivo


        decimal totimponibile_contrattivo;
        decimal totiva_contrattivo;
        decimal assigned_imponibile_contrattivo;
        decimal assigned_iva_contrattivo;
        decimal assigned_gen_contrattivo;

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleContrattoAttivo(DataRow Ordine) {
            if (currphase() != faseivaentrata) return;
            DataAccess Conn = Meta.Conn;
            string filtercontrattoattivo = QHS.AppAnd(QHS.AppAnd(
                QHS.CmpEq("idestimkind", Ordine["idestimkind"]), QHS.CmpEq("yestim", Ordine["yestim"])),
                QHS.CmpEq("nestim", Ordine["nestim"]));

            totimponibile_contrattivo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("totestimateview", filtercontrattoattivo, "taxabletotal"));
            totiva_contrattivo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("totestimateview", filtercontrattoattivo, "ivatotal"));
            string filterivamoventrataview = filtercontrattoattivo;
            //				GetData.MergeFilters(filterordine, 
            //				"(esercizio='"+Conn.sys["esercizio"].ToString()+"')");
            assigned_imponibile_contrattivo = CfgFn.GetNoNullDecimal(
                Conn.DO_READ_VALUE("incomeestimateview", QHS.AppAnd(filterivamoventrataview, QHS.CmpEq("movkind", 3)), "SUM(curramount)"));
            assigned_iva_contrattivo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("incomeestimateview", QHS.AppAnd(filterivamoventrataview, QHS.CmpEq("movkind", 2)), "SUM(curramount)"));
            assigned_gen_contrattivo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("incomeestimateview", QHS.AppAnd(filterivamoventrataview, QHS.CmpEq("movkind", 1)), "SUM(curramount)"));
            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;


            bool found = false;
            if ((Meta.EditMode) ||
                ((assigned_imponibile_contrattivo + assigned_iva_contrattivo) == 0) &&
                (assigned_gen_contrattivo < (totimponibile_contrattivo + totiva_contrattivo) &&
                (totimponibile_contrattivo + totiva_contrattivo - assigned_gen_contrattivo >= currimp)
                )
                ) {
                EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
                found = true;
            }

            if ((Meta.EditMode) ||
                ((assigned_gen_contrattivo == 0) && (assigned_imponibile_contrattivo < totimponibile_contrattivo) &&
                ((totimponibile_contrattivo - assigned_imponibile_contrattivo) >= currimp)
                )
                ) {
                EnableTipoMovimento(3, "Contabilizzazione imponibile documento");
                found = true;
            }

            if ((Meta.EditMode) ||
                ((assigned_gen_contrattivo == 0) && (assigned_iva_contrattivo < totiva_contrattivo) &&
                ((totiva_contrattivo - assigned_iva_contrattivo) >= currimp)
                )
                ) {
                EnableTipoMovimento(2, "Contabilizzazione iva documento");
                found = true;
            }
            if (!found) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il movimento selezionato ha un importo superiore al residuo del documento." +
                    " La contabilizzazione è impossibile.");
            }
            DS.incomeestimate.Rows[0]["movkind"] = cmbCausale.SelectedValue;
            cmbCausale.Enabled = true;
            ReCalcImporto_ContrattoAttivo();

        }


        void ReCalcImporto_ContrattoAttivo() {
            DataRow Curr = DS.Tables["income"].Rows[0];
            if (cmbCausale.SelectedValue == null) return;

            int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

            decimal importo = 0;
            if (tipomovimento == 2) {
                importo = totiva_contrattivo - assigned_iva_contrattivo;
            }
            if (tipomovimento == 3) {
                importo = totimponibile_contrattivo - assigned_imponibile_contrattivo;
            }
            if (tipomovimento == 1) {
                importo = totimponibile_contrattivo + totiva_contrattivo - assigned_gen_contrattivo;
            }

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;
            if (importo < 0) importo = 0; //dovrebbe essere superfluo

            if (importo > currimp) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Sarà effettuata una contabilizzazione parziale del documento poiché la " +
                    "disponibilità del movimento selezionato è inferiore a " + importo.ToString());
            }

        }


        private void cmbCausaleContrattoAttivo_SelectedIndexChanged(object sender, System.EventArgs e) {
            GetCausaleContrattoAttivo();
            ReCalcImporto_ContrattoAttivo();
        }

        int GetCausaleContrattoAttivo() {
            CurrCausaleContrattoAttivo = 0;
            if (DS.incomeestimate.Rows.Count == 0) return 0;
            if (cmbCausale.SelectedValue != null)
                DS.incomeestimate.Rows[0]["movkind"] = cmbCausale.SelectedValue;
            else
                DS.incomeestimate.Rows[0]["movkind"] = DBNull.Value;
            CurrCausaleContrattoAttivo = CfgFn.GetNoNullInt32( DS.incomeestimate.Rows[0]["movkind"]);
            return CurrCausaleContrattoAttivo;
            //ReCalcImporto();
        }

        #endregion

		void ResetIva(){
		}

        void ResetContrattoAttivo() {
        }

		void RintracciaIva(){
		}

        void RintracciaContrattoAttivo() {
        }

        private void labContabAttuale_Click(object sender, EventArgs e) {

        }
	}
}
