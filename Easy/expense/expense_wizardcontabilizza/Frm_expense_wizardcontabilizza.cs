/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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

namespace expense_wizardcontabilizza//SpesaWizardContabilizza//
{
	/// <summary>
	/// Summary description for FrmSpesaContabilizza.
	/// </summary>
	public class Frm_expense_wizardcontabilizza : System.Windows.Forms.Form
	{
		#region System declarations
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private Crownwood.Magic.Controls.TabPage tabConfirm;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
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
		private System.Windows.Forms.GroupBox gboxMovimento;
		private System.Windows.Forms.Button btnSelectMov;
		private System.Windows.Forms.TextBox txtNumeroMovimento;
		private System.Windows.Forms.TextBox txtEsercizioMovimento;
		private System.Windows.Forms.Label lblFaseMovimento;
		private System.Windows.Forms.ComboBox cmbFaseSpesa;
		private Crownwood.Magic.Controls.TabPage tabSelectMov;
		private Crownwood.Magic.Controls.TabPage tabSelectDoc;
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
		public vistaForm DS;
		#endregion

        bool gestisciEventoCmbFaseSpesa = true;
		MetaData Meta;
		DataAccess Conn;
		string CustomTitle;
		int fasespesacont;
		int faseivaspesa;
		private System.Windows.Forms.Label labContabAttuale;
		private System.Windows.Forms.CheckBox chkCredDeb;
		decimal currimp;
		object NuovoDocumento;
		object NuovoDataDocumento;
		object NuovoDescrizione;
		int CurrCausaleIva;
        int CurrCausaleOrdine;
        int CurrCausaleMissione;
        int CurrCausaleCedolino;
        int CurrCausaleOccasionale;
        int CurrCausaleProfessionale;
        int CurrCausaleDipendente;

		string CurrDocDescr;
		private System.Windows.Forms.Label labOperazione;
		private System.Windows.Forms.Label labNum;
		private System.Windows.Forms.Label labEserc;
        private System.Windows.Forms.ImageList imageList1;
        private GroupBox gboxUPB;
        public TextBox txtCodeUPB;
        private TextBox txtUPB;
        private Button button1;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
		private System.ComponentModel.IContainer components;

		public Frm_expense_wizardcontabilizza()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}


		int currphase()
		{
			return CfgFn.GetNoNullInt32( cmbFaseSpesa.SelectedValue);
		}
		public void MetaData_AfterActivation(){
			CustomTitle= "Wizard Aggiunta Contabilizzazioni";
			//Selects first tab
			DisplayTabs(0);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expense_wizardcontabilizza));
            this.DS = new expense_wizardcontabilizza.vistaForm();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSelectMov = new Crownwood.Magic.Controls.TabPage();
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
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.btnSelectMov = new System.Windows.Forms.Button();
            this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
            this.labNum = new System.Windows.Forms.Label();
            this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
            this.labEserc = new System.Windows.Forms.Label();
            this.lblFaseMovimento = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
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
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtCodeUPB = new System.Windows.Forms.TextBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabSelectMov.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.tabSelectDoc.SuspendLayout();
            this.gboxDocumento.SuspendLayout();
            this.tabConfirm.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
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
            this.tabController.SelectedTab = this.tabSelectMov;
            this.tabController.Size = new System.Drawing.Size(793, 476);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelectMov,
            this.tabSelectDoc,
            this.tabConfirm});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
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
            this.tabIntro.Size = new System.Drawing.Size(793, 451);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 4";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(745, 40);
            this.label4.TabIndex = 3;
            this.label4.Text = "L\'unica informazione che sarà aggiunta sarà L\'ASSOCIAZIONE tra il movimento di sp" +
                "esa ed il documento.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(745, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Non sarà creato alcun movimento di spesa, e neanche alcun documento.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(24, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(745, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "E\' da notare che uno stesso movimento di spesa NON PUO\' contabilizzare più di un " +
                "documento.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(745, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabSelectMov
            // 
            this.tabSelectMov.Controls.Add(this.gboxResponsabile);
            this.tabSelectMov.Controls.Add(this.gboxUPB);
            this.tabSelectMov.Controls.Add(this.labContabAttuale);
            this.tabSelectMov.Controls.Add(this.label6);
            this.tabSelectMov.Controls.Add(this.groupBox20);
            this.tabSelectMov.Controls.Add(this.groupBox18);
            this.tabSelectMov.Controls.Add(this.groupBox17);
            this.tabSelectMov.Controls.Add(this.gboxBilAnnuale);
            this.tabSelectMov.Controls.Add(this.groupCredDeb);
            this.tabSelectMov.Controls.Add(this.groupBox1);
            this.tabSelectMov.Controls.Add(this.gboxMovimento);
            this.tabSelectMov.Location = new System.Drawing.Point(0, 0);
            this.tabSelectMov.Name = "tabSelectMov";
            this.tabSelectMov.Size = new System.Drawing.Size(793, 451);
            this.tabSelectMov.TabIndex = 4;
            this.tabSelectMov.Title = "Pagina 2 di 4";
            // 
            // labContabAttuale
            // 
            this.labContabAttuale.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labContabAttuale.Location = new System.Drawing.Point(4, 428);
            this.labContabAttuale.Name = "labContabAttuale";
            this.labContabAttuale.Size = new System.Drawing.Size(664, 23);
            this.labContabAttuale.TabIndex = 88;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(688, 23);
            this.label6.TabIndex = 87;
            this.label6.Text = "Selezionare il movimento di spesa che si desidera ASSOCIARE al documento ";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(427, 316);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 85;
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
            this.groupBox18.Location = new System.Drawing.Point(8, 120);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(344, 40);
            this.groupBox18.TabIndex = 84;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(225, 12);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 21);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
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
            this.groupBox17.Location = new System.Drawing.Point(375, 40);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(396, 72);
            this.groupBox17.TabIndex = 82;
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
            this.txtDescrizione.Size = new System.Drawing.Size(380, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 317);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(413, 100);
            this.gboxBilAnnuale.TabIndex = 79;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(8, 49);
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
            this.txtCodiceBilancio.Location = new System.Drawing.Point(3, 73);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(221, 21);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(152, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(252, 59);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(375, 112);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(396, 40);
            this.groupCredDeb.TabIndex = 81;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(380, 21);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(427, 356);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 64);
            this.groupBox1.TabIndex = 86;
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
            this.txtImportoDisponibile.Location = new System.Drawing.Point(242, 39);
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
            this.txtImportoCorrente.Location = new System.Drawing.Point(242, 15);
            this.txtImportoCorrente.Name = "txtImportoCorrente";
            this.txtImportoCorrente.ReadOnly = true;
            this.txtImportoCorrente.Size = new System.Drawing.Size(96, 21);
            this.txtImportoCorrente.TabIndex = 0;
            this.txtImportoCorrente.TabStop = false;
            this.txtImportoCorrente.Tag = "";
            this.txtImportoCorrente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.btnSelectMov);
            this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
            this.gboxMovimento.Controls.Add(this.labNum);
            this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
            this.gboxMovimento.Controls.Add(this.labEserc);
            this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
            this.gboxMovimento.Controls.Add(this.cmbFaseSpesa);
            this.gboxMovimento.Location = new System.Drawing.Point(8, 32);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(344, 80);
            this.gboxMovimento.TabIndex = 78;
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
            this.txtNumeroMovimento.Location = new System.Drawing.Point(134, 49);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(48, 21);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(102, 49);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(32, 20);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(52, 49);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(39, 21);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(12, 49);
            this.labEserc.Name = "labEserc";
            this.labEserc.Size = new System.Drawing.Size(40, 20);
            this.labEserc.TabIndex = 0;
            this.labEserc.Text = "Eserc.";
            this.labEserc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.cmbFaseSpesa.Size = new System.Drawing.Size(198, 21);
            this.cmbFaseSpesa.TabIndex = 1;
            this.cmbFaseSpesa.Tag = "expense.nphase";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
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
            this.tabSelectDoc.Size = new System.Drawing.Size(793, 451);
            this.tabSelectDoc.TabIndex = 6;
            this.tabSelectDoc.Title = "Pagina 3 di 4";
            // 
            // chkCredDeb
            // 
            this.chkCredDeb.Checked = true;
            this.chkCredDeb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCredDeb.Location = new System.Drawing.Point(8, 160);
            this.chkCredDeb.Name = "chkCredDeb";
            this.chkCredDeb.Size = new System.Drawing.Size(680, 48);
            this.chkCredDeb.TabIndex = 102;
            this.chkCredDeb.Text = "Cerca solo documenti con lo stesso percipiente del movimento di spesa";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(688, 23);
            this.label19.TabIndex = 101;
            this.label19.Text = "Selezionare il documento da ASSOCIARE al movimento di spesa";
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
            this.cmbCausale.TabIndex = 100;
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
            this.cmbTipoContabilizzazione.TabIndex = 99;
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
            this.gboxDocumento.Size = new System.Drawing.Size(392, 72);
            this.gboxDocumento.TabIndex = 97;
            this.gboxDocumento.TabStop = false;
            this.gboxDocumento.Text = "Documento contabilizzato";
            this.gboxDocumento.Visible = false;
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumento.Location = new System.Drawing.Point(8, 48);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(144, 20);
            this.btnDocumento.TabIndex = 10;
            this.btnDocumento.Text = "Documento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.Location = new System.Drawing.Point(40, 16);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(336, 21);
            this.cmbTipoDocumento.TabIndex = 9;
            this.cmbTipoDocumento.Tag = "";
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(152, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Eserc.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(312, 48);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.ReadOnly = true;
            this.txtNumDoc.Size = new System.Drawing.Size(64, 20);
            this.txtNumDoc.TabIndex = 4;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(280, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "Num.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(200, 48);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
            this.txtEsercDoc.TabIndex = 2;
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
            this.tabConfirm.Size = new System.Drawing.Size(793, 451);
            this.tabConfirm.TabIndex = 5;
            this.tabConfirm.Title = "Pagina 4 di 4";
            // 
            // labOperazione
            // 
            this.labOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labOperazione.Location = new System.Drawing.Point(8, 8);
            this.labOperazione.Name = "labOperazione";
            this.labOperazione.Size = new System.Drawing.Size(777, 48);
            this.labOperazione.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(729, 492);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(609, 492);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(521, 492);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtCodeUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.button1);
            this.gboxUPB.Location = new System.Drawing.Point(8, 162);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(413, 104);
            this.gboxUPB.TabIndex = 91;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtCodeUPB
            // 
            this.txtCodeUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeUPB.Location = new System.Drawing.Point(8, 77);
            this.txtCodeUPB.Name = "txtCodeUPB";
            this.txtCodeUPB.ReadOnly = true;
            this.txtCodeUPB.Size = new System.Drawing.Size(396, 21);
            this.txtCodeUPB.TabIndex = 5;
            this.txtCodeUPB.Tag = "upb.codeupb?x";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(175, 9);
            this.txtUPB.Multiline = true;
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(229, 62);
            this.txtUPB.TabIndex = 4;
            this.txtUPB.TabStop = false;
            this.txtUPB.Tag = "upb.title";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(8, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 20);
            this.button1.TabIndex = 2;
            this.button1.TabStop = false;
            this.button1.Tag = "";
            this.button1.Text = "UPB:";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(8, 271);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(413, 40);
            this.gboxResponsabile.TabIndex = 92;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(402, 21);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // Frm_expense_wizardcontabilizza
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(809, 521);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_expense_wizardcontabilizza";
            this.Text = "FrmSpesaContabilizza";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabSelectMov.ResumeLayout(false);
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
            this.tabSelectDoc.ResumeLayout(false);
            this.gboxDocumento.ResumeLayout(false);
            this.gboxDocumento.PerformLayout();
            this.tabConfirm.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			GetData.CacheTable(DS.expensephase,null,null,true);
			GetData.CacheTable(DS.incomephase);
			GetData.CacheTable(DS.manager,null,null,true);
			txtEsercizioMovimento.Text= Meta.GetSys("esercizio").ToString();
			fasespesacont= CfgFn.GetNoNullInt32( Meta.GetSys("itinerationphase"));
			faseivaspesa = CfgFn.GetNoNullInt32( Meta.GetSys("invoiceexpensephase"));

			currcont = tipocont.cont_none;
            string filteresercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2)),
                null,true);
			GetData.CacheTable(DS.mandatekind,null,null,true);

		}

		public void MetaData_AfterClear(){
			DisplayTabs(tabController.SelectedIndex);
		}

		#region Gestione Tabs

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab)
		{
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
				DataRow Curr = DS.expense.Rows[0];
				labOperazione.Text="Il movimento di spesa "+
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
			DS.expenseitineration.Clear();
			DS.expensemandate.Clear();
			DS.expensepayroll.Clear();
			DS.expensecasualcontract.Clear();
			DS.expenseprofservice.Clear();
			DS.expensewageaddition.Clear();
			DS.expenseinvoice.Clear();

			DS.mandate.Clear();
			DS.itineration.Clear();
			DS.payroll.Clear();
			DS.invoice.Clear();
			DS.casualcontract.Clear();
			DS.profservice.Clear();
			DS.wageaddition.Clear();
		}

		bool GetMovimentoSelezionato()
		{
			if (txtNumeroMovimento.Text.Trim()==""){
				MessageBox.Show("Selezionare un movimento per procedere");
				return false;
			}
			if (currcont!= tipocont.cont_none){
				MessageBox.Show("Al movimento selezionato è già associata una contabilizzazione.");
				return false;
			}
			string filter= GetFasePrecFilter(true);
			MetaData MFase = MetaData.GetMetaData(this,"expense");
			MFase.FilterLocked=true;
			MFase.DS=DS.Copy();
			
			DataRow MyDR = MFase.SelectOne("default",filter,null,null);
			if (MyDR==null) return false;
			AddAllCollegate(MyDR);

            string keyspesafilter = QHS.AppAnd(QHS.CmpEq("idexp", MyDR["idexp"]),
                                                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			currimp= CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("expenseview", keyspesafilter, 
				"curramount"));

			DS.expenseitineration.Clear();
			DS.expensepayroll.Clear();
			DS.expensemandate.Clear();
			DS.expenseinvoice.Clear();
			DS.expenseprofservice.Clear();
			DS.expensecasualcontract.Clear();
			DS.expensewageaddition.Clear();
			return true;
		}

		void AddVociFiglieWhereEmpty(DataTable T, string filter){
			if (T.Select(filter).Length>0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,T,null,filter,null,true);
		}

		void AddVoceBilancio(object ID){
			if (ID==DBNull.Value) return;
			if (DS.fin.Select(QHC.CmpEq("idfin",ID)).Length>0)return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.fin, null, QHS.CmpEq("idfin", ID), null, true);			
		}
        void AddVoceUPB(object ID) {
            if (ID == DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.upb, null, QHS.CmpEq("idupb", ID) , null, true);
		}

        void AddVoceFaseSpesa(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.expensephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensephase, null, QHS.CmpEq("nphase", codice) , null, true);
		}

        void AddVoceFaseEntrata(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.incomephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomephase, null, QHS.CmpEq("nphase", codice) , null, true);
		
		}

        void AddVoceCreditore(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.registry, null, QHS.CmpEq("idreg", codice) , null, true);
			
		}
		void AddVoceResponsabile(object codice){
            if (codice == DBNull.Value) return;
            if (DS.manager.Select(QHC.CmpEq("idman", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.manager, null, QHS.CmpEq("idman", codice) , null, true);		
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
            int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			int faseivaentrata = CfgFn.GetNoNullInt32(Meta.GetSys("invoiceincomephase"));

            //DataRow []BilEnt = DS.incomephase.Select(QHC.CmpEq("flagfinance",'S'));
            int fasebilent = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));

			if (Mov.Table.TableName == "expense"){
				//int lenidspesa=Mov["idexp"].ToString().Length;
                int nfase = CfgFn.GetNoNullInt32(Mov["nphase"]);

                filter = QHC.CmpEq("idexp", Mov["idexp"]);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensemandate,filter);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expenseitineration,filter);
                if (nfase == faseivaspesa )
					AddVociFiglieWhereEmpty(DS.expenseinvoice,filter);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensepayroll,filter);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensecasualcontract,filter);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expenseprofservice,filter);
                if (nfase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensewageaddition,filter);

				AddVociFiglieWhereEmpty(DS.expensevar,filter);
				AddVociFiglieWhereEmpty(DS.expenseyear,filter);
			}
			else {
		        int nfase = CfgFn.GetNoNullInt32(Mov["nphase"]);
                filter = filter = QHC.CmpEq("idinc", Mov["idinc"]);

				AddVociFiglieWhereEmpty(DS.incomevar,filter);
				AddVociFiglieWhereEmpty(DS.incomeyear,filter);

                if (nfase == faseivaentrata )
					AddVociFiglieWhereEmpty(DS.incomeinvoice,filter);
			}
		}


		void AddAllCollegate(DataRow R){
			DS.expense.Clear();
			DS.income.Clear();

			DS.expensemandate.Clear();
			DS.expenseitineration.Clear();
			DS.expensepayroll.Clear();
			DS.expenseprofservice.Clear();
			DS.expensecasualcontract.Clear();
			DS.expensewageaddition.Clear();
			DS.expenseinvoice.Clear();
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


		string GetFasePrecFilter(bool FiltraNumMovimento){
            string ffase = "";
            if (cmbFaseSpesa.SelectedIndex > 0) {
                ffase = QHS.CmpEq("nphase", cmbFaseSpesa.SelectedValue);
            }
            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			if(txtEsercizioMovimento.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim())); 
			if((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim()!=""))
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
            txtCodeUPB.Text = MyDR["codeupb"].ToString();
            txtUPB.Text = MyDR["upb"].ToString();
            txtResponsabile.Text = MyDR["manager"].ToString();
            gestisciEventoCmbFaseSpesa = false;
            cmbFaseSpesa.SelectedValue = MyDR["nphase"];
            gestisciEventoCmbFaseSpesa = true;
			
			txtImportoCorrente.Text= CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
			txtImportoDisponibile.Text= CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");

			DS.expenseitineration.Clear();
			DS.expensemandate.Clear();
			DS.expenseinvoice.Clear();
			DS.expensepayroll.Clear();
			DS.expensecasualcontract.Clear();
			DS.expenseprofservice.Clear();
			DS.expensewageaddition.Clear();

			//int lenidspesa= MyDR["idexp"].ToString().Length;
            int fase = CfgFn.GetNoNullInt32(MyDR["nphase"]);
            string filteridexp = QHS.CmpEq("idexp", MyDR["idexp"]);
            if (fase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensemandate, null, filteridexp, null, true);
            if (fase == fasespesacont)
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseitineration, null, filteridexp, null, true);
            if (fase == faseivaspesa )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseinvoice, null, filteridexp, null, true);
            if (fase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensepayroll, null, filteridexp, null, true);
            if (fase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensecasualcontract, null, filteridexp, null, true);
            if (fase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseprofservice, null, filteridexp, null, true);
            if (fase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensewageaddition, null, filteridexp, null, true);


			currcont=DeduciTipoContabilizzazione();

			if (currcont==tipocont.cont_none) {
				labContabAttuale.Text="";
				return;
			}

			string MSG;
			MSG = "Il movimento di spesa selezionato contabilizza ";
			switch(currcont){
				case tipocont.cont_missione: 
					DataRow MisMov = DS.expenseitineration.Rows[0];
			        DataTable tMiss = Conn.RUN_SELECT("itineration", "iditineration,yitineration,nitineration", null,
			            QHS.CmpEq("iditineration", MisMov["iditineration"]), null, false);
			        if (tMiss.Rows.Count > 0) {
			            DataRow Mis = tMiss.Rows[0];
			            MSG += "la missione " + Mis["yitineration"]+ "/" + Mis["nitineration"] + ".";
			        }
			        else {
                        MSG += "la missione di ID " + MisMov["iditineration"] + "che però non è presente nel db (errore).";
                    }
					
					break;
				case tipocont.cont_cedolino: 
					DataRow Ced = DS.expensepayroll.Rows[0];
					int mese= CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll", QHS.CmpEq("idpayroll",Ced["idpayroll"]), 
                                "npayroll"));
                    int anno = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll", QHS.CmpEq("idpayroll", Ced["idpayroll"]),
                        "fiscalyear"));


					MSG+= "il cedolino  "+anno.ToString()+"/"+mese.ToString()+".";
					break;

				case tipocont.cont_iva: 
					DataRow Iva = DS.expenseinvoice.Rows[0];
					string codicetipodoc = Iva["idinvkind"].ToString();
					DataRow[] TipoDoc= DS.invoicekind.Select("idinvkind="+
						QueryCreator.quotedstrvalue(codicetipodoc,false));
					string TIPO="";
					if (TipoDoc.Length==1){
						TIPO= "("+TipoDoc[0]["description"].ToString()+")";
					}
					MSG+= "il documento iva "+TIPO+" "+ 
						Iva["yinv"].ToString()+"/"+Iva["ninv"].ToString()+".";
					break;
				case tipocont.cont_ordine: 
					DataRow Ord = DS.expensemandate.Rows[0];
					object codicetipoord = Ord["idmankind"];
					DataRow[] TipoOrd= DS.mandatekind.Select(QHC.CmpEq("idmankind",codicetipoord));
                       
					string TIPOORD="";
					if (TipoOrd.Length==1){
						TIPOORD= "("+TipoOrd[0]["description"].ToString()+")";
					}
					MSG+= "il contratto passivo "+TIPOORD+" "+ 
						Ord["yman"].ToString()+"/"+Ord["nman"].ToString()+".";
					break;
				case tipocont.cont_occasionale: 
					DataRow Occ = DS.expensecasualcontract.Rows[0];
					MSG+= "il contratto occasionale "+Occ["ycon"].ToString()+"/"+Occ["ncon"].ToString()+".";
					break;
				case tipocont.cont_professionale: 
					DataRow Prof = DS.expenseprofservice.Rows[0];
					MSG+= "il contratto professionale "+Prof["ycon"].ToString()+"/"+Prof["ncon"].ToString()+".";
					break;
				case tipocont.cont_dipendente: 
					DataRow Dip = DS.expensewageaddition.Rows[0];
                    MSG += "il compenso (Altri Compensi)" + Dip["ycon"].ToString() + "/" + Dip["ncon"].ToString() + ".";
					break;
			}
			labContabAttuale.Text= MSG;
					
		}
		public tipocont currcont;

		private void txtNumeroMovimento_Leave(object sender, System.EventArgs e) {
			if (txtNumeroMovimento.Text.Trim()==""){
				Clear(true);
				return;
			}
			btnSelectMov_Click(sender,e);
		}


		private void txtEsercizioFasePrecedente_Leave(object sender, System.EventArgs e) {			
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercizioMovimento);		
			Clear(false);
		}

		#endregion

		private void FormattaDataDelTexBox(TextBox TB) 
		{
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}


		private void cmbFaseSpesa_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (gestisciEventoCmbFaseSpesa) {
                Clear(true);
            }
		}

		void Clear(bool all){
			txtNumeroMovimento.Text="";
			if (all) txtCredDeb.Text= "";
			txtDescrizione.Text= "";
			SubEntity_txtImportoMovimento.Text= "";
			txtDataCont.Text= "";
			txtCodiceBilancio.Text="";
			txtDenominazioneBilancio.Text="";
			txtUPB.Text="";
			txtCodeUPB.Text="";
            txtResponsabile.Text = "";

			txtImportoCorrente.Text= "";
			txtImportoDisponibile.Text= "";
			currcont=tipocont.cont_none;
			gboxDocumento.Visible=false;

		}

		bool GetDocumentoSelezionato(){
			tipocont TC = DeduciTipoContabilizzazione();
			if (TC==tipocont.cont_none) {
				MessageBox.Show("Non è stato selezionato alcun documento da contabilizzare.");
				return false;
			}
			if (cmbCausale.SelectedValue==null){
				MessageBox.Show("Non è stata selezionata la causale del documento.");
				return false;
			}
			switch (TC){
				case tipocont.cont_iva:
					DataRow CurrIva= DS.invoice.Rows[0];
					CurrDocDescr="al documento iva "+CurrIva["yinv"].ToString()+
										"/"+CurrIva["ninv"].ToString();
					break;
				case tipocont.cont_missione:
					DataRow CurrMiss= DS.itineration.Rows[0];
					CurrDocDescr="alla missione "+CurrMiss["yitineration"].ToString()+
						"/"+CurrMiss["nitineration"].ToString();
					break;
				case tipocont.cont_ordine:
					DataRow CurrOrd= DS.mandate.Rows[0];
					CurrDocDescr="al contratto passivo "+CurrOrd["yman"].ToString()+
						"/"+CurrOrd["nman"].ToString();
					break;
				case tipocont.cont_cedolino:
					DataRow CurrCed= DS.payroll.Rows[0];
					CurrDocDescr="al cedolino "+CurrCed["fiscalyear"].ToString()+
						"/"+CurrCed["npayroll"].ToString();
					break;
				case tipocont.cont_occasionale:
					DataRow CurrOcc= DS.casualcontract.Rows[0];
					CurrDocDescr="al contratto occasionale "+CurrOcc["ycon"].ToString()+
						"/"+CurrOcc["ncon"].ToString();
					break;
				case tipocont.cont_professionale:
					DataRow CurrProf= DS.profservice.Rows[0];
					CurrDocDescr="al contratto professionale "+CurrProf["ycon"].ToString()+
						"/"+CurrProf["ncon"].ToString();
					break;
				case tipocont.cont_dipendente:
					DataRow CurrDip= DS.wageaddition.Rows[0];
                    CurrDocDescr = "al compenso (Altri Compensi) " + CurrDip["ycon"].ToString() +
						"/"+CurrDip["ncon"].ToString();
					break;

			}
			
			return true;
		}

		bool doAssocia(){
				
			DataRow Curr= DS.expense.Rows[0];

			
			if (MessageBox.Show(this,"Aggiorno i campi documento e data documento del movimento di spesa "+
				"in base al documento selezionato?","Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK) {
				if ((NuovoDocumento!=null)&&(NuovoDocumento!=DBNull.Value)) Curr["doc"]= NuovoDocumento;
				if (NuovoDataDocumento!=null)  Curr["docdate"]= NuovoDataDocumento;
			}
			if (MessageBox.Show(this,"Aggiorno il campo DESCRIZIONE del movimento di spesa "+
				"in base al documento selezionato?","Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK){
				if ((NuovoDescrizione!=null)&&(NuovoDescrizione!=DBNull.Value)) Curr["description"]= NuovoDescrizione;
			}
			
			
			PostData Post = Meta.Get_PostData();
			Post.InitClass(DS,Conn);
			bool res= Post.DO_POST();
			if (res)MessageBox.Show("Aggiunta della contabilizzazione eseguita con successo.");
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
				case tipocont.cont_missione:
					ReCalcImporto_Missione();
					return;
				case tipocont.cont_ordine:
					ReCalcImporto_Ordine();
					return;
				case tipocont.cont_iva:
					ReCalcImporto_Iva();
					return;
				case tipocont.cont_cedolino:
					ReCalcImporto_Cedolino();
					return;
				case tipocont.cont_occasionale:
					ReCalcImporto_Occasionale();
					return;
				case tipocont.cont_professionale:
					ReCalcImporto_Professionale();
					return;
				case tipocont.cont_dipendente:
					ReCalcImporto_Dipendente();
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
				case tipocont.cont_missione:
					cmbCausaleMissione_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_ordine:
					cmbCausaleOrdine_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_iva:
					cmbCausaleIva_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_cedolino:
					cmbCausaleCedolino_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_occasionale:
					cmbCausaleOccasionale_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_professionale:
					cmbCausaleProfessionale_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_dipendente:
					cmbCausaleDipendente_SelectedIndexChanged(sender,e);
					break;
			}
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					btnMissione_Click(sender,e);
					break;
				case tipocont.cont_ordine:
					btnOrdine_Click(sender,e);
					break;
				case tipocont.cont_iva:
					btnIva_Click(sender,e);
					break;
				case tipocont.cont_cedolino:
					btnCedolino_Click(sender,e);
					break;
				case tipocont.cont_professionale:
					btnProfessionale_Click(sender,e);
					break;
				case tipocont.cont_occasionale:
					btnOccasionale_Click(sender,e);
					break;
				case tipocont.cont_dipendente:
					btnDipendente_Click(sender,e);
					break;
			}
		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					txtEsercMissione_Leave(sender,e);
					break;
				case tipocont.cont_ordine:
					txtEsercOrdine_Leave(sender,e);
					break;
				case tipocont.cont_iva:
					txtEsercIva_Leave(sender,e);
					break;
				case tipocont.cont_cedolino:
					txtEsercCedolino_Leave(sender,e);
					break;
				case tipocont.cont_occasionale:
					txtEsercOccasionale_Leave(sender,e);
					break;
				case tipocont.cont_professionale:
					txtEsercProfessionale_Leave(sender,e);
					break;
				case tipocont.cont_dipendente:
					txtEsercDipendente_Leave(sender,e);
					break;
				
			}
		}

		private void txtNumDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_missione:
					txtNumMissione_Leave(sender,e);
					break;
				case tipocont.cont_ordine:
					txtNumOrdine_Leave(sender,e);
					break;
				case tipocont.cont_iva:
					txtNumIva_Leave(sender,e);
					break;
				case tipocont.cont_cedolino:
					txtNumCedolino_Leave(sender,e);
					break;
				case tipocont.cont_occasionale:
					txtNumOccasionale_Leave(sender,e);
					break;
				case tipocont.cont_professionale:
					txtNumProfessionale_Leave(sender,e);
					break;
				case tipocont.cont_dipendente:
					txtNumDipendente_Leave(sender,e);
					break;
			}
		}

		private void cmbTipoDocumentoGenerico_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_ordine:
					cmbTipoOrdine_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_iva:
					cmbTipoDocumento_SelectedIndexChanged(sender,e);
					break;
			}
		}

		tipocont DeduciTipoContabilizzazione(){
			if (DS.expenseitineration.Rows.Count>0) return tipocont.cont_missione;
			if (DS.expensemandate.Rows.Count>0) return tipocont.cont_ordine;
			if (DS.expenseinvoice.Rows.Count>0) return tipocont.cont_iva;
			if (DS.expensepayroll.Rows.Count>0) return tipocont.cont_cedolino;
			if (DS.expenseprofservice.Rows.Count>0) return tipocont.cont_professionale;
			if (DS.expensecasualcontract.Rows.Count>0) return tipocont.cont_occasionale;
			if (DS.expensewageaddition.Rows.Count>0) return tipocont.cont_dipendente;
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
				case tipocont.cont_missione:
					labEserc.Text="Eserc.";
					labNum.Text="Num.";
					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Missione";
					txtEsercDoc.Tag=
						"itineration.yitineration?"+
                        "expenseitinerationview.yitineration";
                    txtNumDoc.Tag = "itineration.nitineration?" +
                        "expenseitinerationview.nitineration";
					cmbTipoDocumento.Tag= null;
					AbilitaDisabilitaControlliMissione(false);
					//					txtDataInizioPrest.ReadOnly=true;
					//					txtDataFinePrest.ReadOnly=true;
					//					btnPrestazione.Enabled=false;
					//					cmbTipoprestazione.Enabled=false;
					//					btnCalcoloGuidato.Enabled=false;
					break;
				case tipocont.cont_iva:
					labEserc.Text="Eserc.";
					labNum.Text="Num.";
					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					btnDocumento.Text="Documento";
					txtEsercDoc.Tag=
						"expenseinvoice.yinv?"+
						"expenseinvoiceview.yinv";
					txtNumDoc.Tag=
						"expenseinvoice.ninv?"+
						"expenseinvoiceview.ninv";
					cmbTipoDocumento.Tag=
						"expenseinvoice.idinvkind?"+
						"expenseinvoiceview.idinvkind";
					ImpostaComboInvoiceKind();
					AbilitaDisabilitaControlliIva(false);
					break;
				case tipocont.cont_ordine:
					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					labEserc.Text="Eserc.";
					labNum.Text="Num.";
					btnDocumento.Text="Contratto Passivo";
					txtEsercDoc.Tag=
						"expensemandate.yman?"+
						"expensemandateview.yman";
					txtNumDoc.Tag="expensemandate.nman?"+
						"expensemandateview.nman";
					cmbTipoDocumento.Tag=
						"expensemandate.idmankind?"+
						"expensemandateview.idmankind";
					ImpostaComboMandateKind();
					AbilitaDisabilitaControlliOrdine(false);
					break;
				case tipocont.cont_cedolino:
					cmbCausale.Visible=false;
					labelCausale.Visible=false;
					labEserc.Text="Eserc";	//"Anno";
					labNum.Text="Num";	//"Mese";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Cedolino";
					txtEsercDoc.Tag=
						"payroll.fiscalyear?"+
						"expensepayrollview.fiscalyear";
					txtNumDoc.Tag="payroll.npayroll?"+
						"expensepayrollview.npayroll";
					cmbTipoDocumento.Tag= null;
					AbilitaDisabilitaControlliCedolino(false);
					break;
				case tipocont.cont_occasionale:
					cmbCausale.Visible=false;
					labelCausale.Visible=false;
					gboxDocumento.Visible=true;
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Contratto Occasionale";
					txtEsercDoc.Tag=
						"expensecasualcontract.ycon?"+
						"expensecasualcontractview.ycon";
					txtNumDoc.Tag="expensecasualcontract.ncon?"+
						"expensecasualcontractview.ncon";
					cmbTipoDocumento.Tag= null;
					AbilitaDisabilitaControlliCedolino(false);
					break;
				case tipocont.cont_professionale:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
					btnDocumento.Text="Contratto Professionale";
					txtEsercDoc.Tag=
						"expenseprofservice.ycon?"+
						"expenseprofserviceview.ycon";
					txtNumDoc.Tag="expenseprofservice.ncon?"+
						"expenseprofserviceview.ncon";
					cmbTipoDocumento.Tag= null;
					AbilitaDisabilitaControlliProfessionale(false);
					break;
				case tipocont.cont_dipendente:
					cmbCausale.Visible=false;
					labelCausale.Visible=false;
					gboxDocumento.Visible=true;
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					labelTipoDocumento.Visible=false;
					cmbTipoDocumento.Visible=false;
                    btnDocumento.Text = "Altri Compensi";
					txtEsercDoc.Tag=
						"expensewageaddition.ycon?"+
						"expensewageadditionview.ycon";
					txtNumDoc.Tag="expensewageaddition.ncon?"+
						"expensewageadditionview.ncon";
					cmbTipoDocumento.Tag= null;
					AbilitaDisabilitaControlliDipendente(false);
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

		void ImpostaComboMandateKind(){
			if (cmbTipoDocumento.DataSource!=null){
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idmankind"]!=null) return;
			}
			TipoDocChangePilotato=true;
			cmbTipoDocumento.DataSource= DS.mandatekind;
			cmbTipoDocumento.DisplayMember="title";
			cmbTipoDocumento.ValueMember="idmankind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento,null);
			TipoDocChangePilotato=false;
		}

		void ImpostaComboInvoiceKind(){
			if (cmbTipoDocumento.DataSource!=null){
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idinvkind"]!=null) return;
			}
			TipoDocChangePilotato=true;
			cmbTipoDocumento.DataSource= DS.invoicekind;
			cmbTipoDocumento.DisplayMember="description";
			cmbTipoDocumento.ValueMember="idinvkind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento,null);
			TipoDocChangePilotato=false;
		}

		void NascondiControlliContabilizzazione(){
			cmbCausale.Visible=false;
			labelCausale.Visible=false;
			gboxDocumento.Visible=false;
		}

		public enum tipocont {cont_none,cont_ordine,cont_missione,cont_iva,cont_cedolino,cont_occasionale,
			cont_professionale,cont_dipendente};
		string NomeContabilizzazione(tipocont TIPO){
			switch (TIPO){
				case tipocont.cont_ordine: return "Contratto Passivo";
				case tipocont.cont_missione: return "Missione";
				case tipocont.cont_iva: return "Documento Iva";
				case tipocont.cont_cedolino: return "Cedolino Parasubordinati";
				case tipocont.cont_occasionale: return "Prestazione Occasionale";
				case tipocont.cont_professionale: return "Prestazione Professionale";
                case tipocont.cont_dipendente: return "Altri Compensi";
				case tipocont.cont_none: return "";
			}
			return null;
		}
		tipocont CodiceContabilizzazione(string nomecont){
			switch(nomecont){
				case "Contratto Passivo":return tipocont.cont_ordine;
				case "Missione": return tipocont.cont_missione;
				case "Documento Iva": return tipocont.cont_iva;
				case "Cedolino Parasubordinati":return tipocont.cont_cedolino;
				case "Prestazione Occasionale": return tipocont.cont_occasionale;
				case "Prestazione Professionale": return tipocont.cont_professionale;
                case "Altri Compensi": return tipocont.cont_dipendente;
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
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			switch(codecont){
				case tipocont.cont_missione:
					if (faseMissioneInclusa()) return true;
					return false;
				case tipocont.cont_ordine:
					//if (faseOrdineInclusa()) return true;
					return false;
				case tipocont.cont_iva:
					//if (faseIvaInclusa())return true;
					return false;
				case tipocont.cont_cedolino:
					if (faseCedolinoInclusa())return true;
					return false;
				case tipocont.cont_occasionale:
					if (faseOccasionaleInclusa())return true;
					return false;
				case tipocont.cont_professionale:
					if (faseProfessionaleInclusa())return true;
					return false;
				case tipocont.cont_dipendente:
					if (faseDipendenteInclusa())return true;
					return false;

				default:
					return false;
			}
		}

		bool faseMissioneInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
			return false;
		}
		bool faseCedolinoInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
			return false;
		}
		bool faseOrdineInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
			return false;
		}
		bool faseIvaInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==faseivaspesa)return true;
			return false;
		}
		bool faseOccasionaleInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
			return false;
		}
		bool faseProfessionaleInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
			return false;
		}
		bool faseDipendenteInclusa(){
			int currphase= CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
			if (currphase==fasespesacont)return true;
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
															 tipocont.cont_ordine, 
															 tipocont.cont_missione, 
															 tipocont.cont_iva,
															 tipocont.cont_cedolino,
															tipocont.cont_occasionale,
															tipocont.cont_professionale,
															tipocont.cont_dipendente}){
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
																tipocont.cont_missione, 
																tipocont.cont_ordine, 
																tipocont.cont_iva,
																tipocont.cont_cedolino,
																tipocont.cont_occasionale,
																tipocont.cont_professionale,
																tipocont.cont_dipendente
																}){
				DisattivaContabilizzazione(disattivacont);
			}
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			VisualizzaControlliContabilizzazione(codecont);
			ClearComboCausale();
		}

		void DisattivaContabilizzazione(tipocont codecont){
			switch(codecont){
				case tipocont.cont_missione:
					if (faseMissioneInclusa()) ScollegaMissione();
					return;
				case tipocont.cont_ordine:
					if (faseOrdineInclusa()) ScollegaOrdine();
					return;
				case tipocont.cont_iva:
					if (faseIvaInclusa()) ScollegaIva();
					return;
				case tipocont.cont_cedolino:
					if (faseCedolinoInclusa()) ScollegaCedolino();
					return;
				case tipocont.cont_occasionale:
					if (faseOccasionaleInclusa()) ScollegaOccasionale();
					return;
				case tipocont.cont_professionale:
					if (faseProfessionaleInclusa()) ScollegaProfessionale();
					return;
				case tipocont.cont_dipendente:
					if (faseDipendenteInclusa()) ScollegaDipendente();
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
            FilterIva = QHS.CmpLe("yinv", esercizio);
			if(txtEsercDoc.Text != ""){
				int esercdocumento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
                    FilterIva = QHS.CmpEq("yinv", esercdocumento);
				}
				catch {
				}
			} 

			if (FiltraNum){
				int numdocumento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterIva = GetData.MergeFilters(FilterIva,QHS.CmpEq("ninv", numdocumento));
				} 
			}
			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex<=0){
                filtertipodoc = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2));
			}
			else {
				filtertipodoc = QHS.CmpEq("idinvkind", cmbTipoDocumento.SelectedValue);
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
                    QHS.CmpEq("registry",txtCredDeb.Text));
			}

			MetaData MDocumentoIva;
			DataRow MyDRIva;

			MDocumentoIva = MetaData.GetMetaData(this,"invoiceavailable");
			MDocumentoIva.FilterLocked=true;
			MDocumentoIva.DS = DS.Clone();
            string filter2 = QHS.AppAnd(QHS.CmpGe("residual", currimp), QHS.NullOrEq("active","S"));
           
            MyDRIva = MDocumentoIva.SelectOne("default",
				GetData.MergeFilters(MyFilterIvaOperativo, filter2), null,null);
			
			if(MyDRIva == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
		
            string selectord = QHS.AppAnd(QHS.CmpEq("idinvkind", MyDRIva["idinvkind"]),
                   QHS.CmpEq("yinv", MyDRIva["yinv"]), QHS.CmpEq("ninv", MyDRIva["ninv"]));
			

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
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex=0;
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

			DataRow CurrRow= DS.expense.Rows[0];
			MetaData MovIva = MetaData.GetMetaData(this,"expenseinvoice");
			MovIva.SetDefaults(DS.expenseinvoice);
			DS.expenseinvoice.Columns["idinvkind"].DefaultValue=ValoriDocumentoIva["idinvkind"];
			DS.expenseinvoice.Columns["ninv"].DefaultValue= ValoriDocumentoIva["ninv"];
			DS.expenseinvoice.Columns["yinv"].DefaultValue= ValoriDocumentoIva["yinv"];
			txtNumDoc.Text=ValoriDocumentoIva["ninv"].ToString();
			txtEsercDoc.Text=ValoriDocumentoIva["yinv"].ToString();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriDocumentoIva["idinvkind"]);
			TipoDocChangePilotato=false;

			DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.expenseinvoice);
			DS.expenseinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
			DS.expenseinvoice.Columns["ninv"].DefaultValue= DBNull.Value;
			DS.expenseinvoice.Columns["yinv"].DefaultValue= DBNull.Value;

			NuovoDocumento= "Doc."+ValoriDocumentoIva["doc"];
			NuovoDataDocumento = (DateTime)ValoriDocumentoIva["docdate"];
			NuovoDescrizione = ValoriDocumentoIva["description"];

			RintracciaIva();
			SetComboCausaleIva(NewIvaR);
			AbilitaDisabilitaControlliIva(false);
			cmbCausale.Enabled=true;
		}

		void ScollegaIva(){
			if (DS.expenseinvoice.Rows.Count==0) return;
			DS.expenseinvoice.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			ClearControlliIva(false);
			NuovoDocumento=null;
			NuovoDataDocumento=null;
			NuovoDescrizione=null;
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
			if (currphase()!=faseivaspesa) return;
			DataAccess Conn= Meta.Conn;
            string filteriva = QHS.AppAnd(
                QHS.CmpEq("idinvkind",Ordine["idinvkind"]),QHS.CmpEq("yinv",Ordine["yinv"]),
                QHS.CmpEq("ninv",Ordine["ninv"]));


			DataTable T= Conn.RUN_SELECT("invoiceresidual","*",null,filteriva,null,true);
			if ((T!=null)&&(T.Rows.Count>0)){
				DataRow R=T.Rows[0];
				totimponibile_dociva=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
				totiva_dociva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
				assigned_imponibile_dociva= CfgFn.GetNoNullDecimal( R["linkedimpon"]);
				assigned_iva_dociva= CfgFn.GetNoNullDecimal( R["linkedimpos"]);
				assigned_gen_dociva=CfgFn.GetNoNullDecimal( R["linkeddocum"]);

			}
			else {
				totimponibile_dociva= 0;
				totiva_dociva =  0;
				assigned_imponibile_dociva= 0;
				assigned_iva_dociva= 0;
				assigned_gen_dociva= 0;
			}

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
				MessageBox.Show("Il movimento selezionato ha un importo superiore al residuo del documento."+
						" La contabilizzazione è impossibile.");
			}
			DS.expenseinvoice.Rows[0]["movkind"]=
                (cmbCausale.SelectedValue == null) ? DBNull.Value : cmbCausale.SelectedValue;
			cmbCausale.Enabled=true;
			ReCalcImporto_Iva();
			
		}


		void ReCalcImporto_Iva(){
			DataRow Curr = DS.Tables["expense"].Rows[0];
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

			if (importo<0) importo=0; //dovrebbe essere superfluo
	
			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale del documento poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}


		private void cmbCausaleIva_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleIva();
			ReCalcImporto_Iva();
		}

		int GetCausaleIva(){
			CurrCausaleIva=0;
			if (DS.expenseinvoice.Rows.Count==0) return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.expenseinvoice.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.expenseinvoice.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleIva= CfgFn.GetNoNullInt32( DS.expenseinvoice.Rows[0]["movkind"]);
			return CurrCausaleIva;
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

		#region Gestione Selezione Ordine 

		string FilterOrdine;

		//		void AbilitaDisabilitaBtnOrdine(){
		//			bool SelezioneOrdineAttiva = ((Meta.IsEmpty)||(Meta.InsertMode));
		//			btnOrdine.Enabled=  SelezioneOrdineAttiva;
		//			txtNumOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			txtEsercOrdine.ReadOnly= !SelezioneOrdineAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumOrdine.Text.Trim()!="");
		//			txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//		}

		private void txtEsercOrdine_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
			//CalcolaStartFilter(null);
		}

		string GetFilterOrdine(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
            FilterOrdine = QHS.CmpLe("yman", esercizio);
			if(txtEsercDoc.Text != ""){
				int esercordine= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
						FilterOrdine=QHS.CmpEq("yman",esercordine);
				}
				catch {
				}
			} 
			string filtertipoord=null;
			if (cmbTipoDocumento.SelectedIndex<=0){
				filtertipoord= null;
			}
			else {
                filtertipoord = QHS.CmpEq("idmankind", cmbTipoDocumento.SelectedValue);
			}
			FilterOrdine = GetData.MergeFilters(FilterOrdine, filtertipoord);
			if (FiltraNum){
				int numordine= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
                    FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.CmpEq("nman", numordine));
				} 
			}

			return FilterOrdine;
		}


		private void btnOrdine_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);
			string MyOrdineFilter;
			string MyFilterOrdineGenericoOperativo;
			if (((Control)sender).Name == "txtNumDoc")
				MyOrdineFilter = GetFilterOrdine(true);
			else
				MyOrdineFilter = GetFilterOrdine(false);

			MyFilterOrdineGenericoOperativo= MyOrdineFilter;

			bool condfasecred = chkCredDeb.Checked;
			DataRow Curr = DS.expense.Rows[0];
			if (condfasecred ){
				MyFilterOrdineGenericoOperativo= GetData.MergeFilters(MyFilterOrdineGenericoOperativo,
					QHS.CmpEq("registry",txtCredDeb.Text));
			}
			
			MetaData MOrdine;
			DataRow MyDROrdine;

			MOrdine = MetaData.GetMetaData(this,"mandateavailable");
			MOrdine.FilterLocked=true;
			MOrdine.DS = DS.Clone();

            string filter2 = QHS.AppAnd(QHS.CmpGe("residual", currimp), QHS.NullOrEq("active", 'S'));

			MyDROrdine = MOrdine.SelectOne("default",
				GetData.MergeFilters( MyFilterOrdineGenericoOperativo, filter2
				),
					null,null);
			
			if(MyDROrdine == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectord = QHS.AppAnd(QHS.CmpEq("idmankind", MyDROrdine["idmankind"]),
                QHS.AppAnd(QHS.CmpEq("yman", MyDROrdine["yman"]), QHS.CmpEq("nman", MyDROrdine["nman"])));
			
			string columnlist = QueryCreator.ColumnNameList(DS.mandate)+
				",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("mandateview",columnlist,null,selectord,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetOrdine();
			CollegaOrdine(MyDR);
	
		}

		private void txtNumOrdine_Leave(object sender, System.EventArgs e) {
            if (txtNumDoc.ReadOnly) return;
			if (txtNumDoc.Text.Trim()==""){
				ScollegaOrdine();				
				ClearControlliOrdine(true);
				return;
			}


			btnOrdine_Click(sender,e);

		}

		void ClearControlliOrdine(bool skipTipoDoc){
			//txtCredDeb.Text = "";		
		}

		void AbilitaDisabilitaControlliOrdine(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}


		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaOrdine(DataRow Ordine2){
			//Meta.GetFormData(true);
			//AzzeraPadre();
			Hashtable ValoriOrdine = new Hashtable();
			foreach (DataColumn C in DS.mandate.Columns) 
				ValoriOrdine[C.ColumnName]= Ordine2[C.ColumnName];

			ScollegaOrdine();

			if (!faseOrdineInclusa()) return;

			DataRow NewOrdR = DS.mandate.NewRow();

			foreach (DataColumn C in DS.mandate.Columns){
				NewOrdR[C.ColumnName]= ValoriOrdine[C.ColumnName];
			}

			DS.mandate.Rows.Add(NewOrdR);
			NewOrdR.AcceptChanges();

			DataRow CurrRow= DS.expense.Rows[0];
			MetaData MovOrd = MetaData.GetMetaData(this,"expensemandate");
			MovOrd.SetDefaults(DS.expensemandate);
			DS.expensemandate.Columns["idmankind"].DefaultValue=ValoriOrdine["idmankind"];
			DS.expensemandate.Columns["nman"].DefaultValue= ValoriOrdine["nman"];
			DS.expensemandate.Columns["yman"].DefaultValue= ValoriOrdine["yman"];
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriOrdine["idmankind"]);
			TipoDocChangePilotato=false;
			txtNumDoc.Text=ValoriOrdine["nman"].ToString();
			txtEsercDoc.Text=ValoriOrdine["yman"].ToString();

			DataRow RMovOrd = MovOrd.Get_New_Row(CurrRow, DS.expensemandate);
			DS.expensemandate.Columns["idmankind"].DefaultValue = DBNull.Value;
			DS.expensemandate.Columns["nman"].DefaultValue= DBNull.Value;
			DS.expensemandate.Columns["yman"].DefaultValue= DBNull.Value;

			//"Ord."+ValoriOrdine["documento"];

			NuovoDocumento="Ord."+
				ValoriOrdine["idmankind"].ToString()+"/"+
				ValoriOrdine["yman"].ToString().Substring(2,2)+"/"+
				ValoriOrdine["nman"].ToString().PadLeft(6,'0');
			NuovoDataDocumento = ValoriOrdine["docdate"];
			NuovoDescrizione = ValoriOrdine["description"];


			//CurrRow["codiceresponsabile"] = ValoriOrdine["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriOrdine["codiceresponsabile"].ToString());


			//Meta.myHelpForm.FillControls(tabMovFin.Controls);
			RintracciaOrdine();
			SetComboCausaleOrdine(NewOrdR);
			AbilitaDisabilitaControlliOrdine(false);
			cmbCausale.Enabled=true;
		}

		void ScollegaOrdine(){
			if (DS.expensemandate.Rows.Count==0) return;
			DS.expensemandate.Clear();
			DS.mandate.Clear();
			ClearComboCausale();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			//CurrRow["codiceresponsabile"]=DBNull.Value;
			ClearControlliOrdine(false);
		}

		private void cmbTipoOrdine_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			ClearControlliOrdine(true);
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			TipoDocChangePilotato=false;
		}
		#endregion

		#region Gestione ComboBox Causale Ordine


		decimal totimponibile;
		decimal totiva;
		decimal assigned_imponibile;
		decimal assigned_iva;
		decimal assigned_gen;



		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleOrdine(DataRow Ordine){
			if (currphase()!=fasespesacont) return;
			DataAccess Conn= Meta.Conn;
			string filterordine =QHS.AppAnd(
                QHS.CmpEq("idmankind", Ordine["idmankind"]), QHS.CmpEq("yman", Ordine["yman"]),
                QHS.CmpEq("nman", Ordine["nman"]));
            
			DataTable T= Conn.RUN_SELECT("mandateresidual","*",null,filterordine,null,true);
			if ((T!=null)&&(T.Rows.Count>0)){
				DataRow R=T.Rows[0];
				totimponibile=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
				totiva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
				assigned_imponibile= CfgFn.GetNoNullDecimal( R["linkedimpon"]);
				assigned_iva= CfgFn.GetNoNullDecimal( R["linkedimpos"]);
				assigned_gen=CfgFn.GetNoNullDecimal( R["linkedordin"]);

			}
			else {
				totimponibile= 0;
				totiva =  0;
				assigned_imponibile= 0;
				assigned_iva= 0;
				assigned_gen= 0;
			}

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if (
				((assigned_imponibile+assigned_iva)==0) && 
				(assigned_gen< (totimponibile+totiva)) &&
				(totimponibile+totiva-assigned_gen >= currimp)
				){
				EnableTipoMovimento(1,"Contabilizzazione Totale Contratto Passivo");
			}

			if (
				( (assigned_gen==0) &&(assigned_imponibile < totimponibile)&&
					(totimponibile-assigned_imponibile >= currimp)	
				)
				){
				EnableTipoMovimento(3,"Contabilizzazione Imponibile Contratto Passivo");
			}

			if ( 
				( (assigned_gen==0) &&(assigned_iva< totiva)&&
				  (totiva-assigned_iva >= currimp)
				)
				){
				EnableTipoMovimento(2,"Contabilizzazione Iva Contratto Passivo");
			}
			DS.expensemandate.Rows[0]["movkind"]=
                (cmbCausale.SelectedValue == null) ? DBNull.Value : cmbCausale.SelectedValue;
			cmbCausale.Enabled=true;
			ReCalcImporto_Ordine();
			
		}


		void ReCalcImporto_Ordine(){
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==2){
				importo= totiva-assigned_iva;
			}
			if (tipomovimento==3){
				importo= totimponibile-assigned_imponibile;
			}
			if (tipomovimento==1){
				importo= totimponibile+totiva-assigned_gen;
			}

			if (importo<0) importo=0; //dovrebbe essere superfluo

			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale del contratto passivo poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}


		}

		private void cmbCausaleOrdine_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleOrdine();
			ReCalcImporto_Ordine();
		}

		int GetCausaleOrdine(){
			CurrCausaleOrdine=0;
			if (DS.expensemandate.Rows.Count==0) return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.expensemandate.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.expensemandate.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleOrdine= CfgFn.GetNoNullInt32( DS.expensemandate.Rows[0]["movkind"]);
			return CurrCausaleOrdine;
			//ReCalcImporto();
		}

		#endregion

		#region Gestione Selezione Missione 



		//		void AbilitaDisabilitaBtnMissione(){
		//			int fasemissione = ManageMissione.faseattivazione;
		//			bool SelezioneMissioneAttiva=false;
		//			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
		//				SelezioneMissioneAttiva=true;
		//			btnDocumento.Enabled=  SelezioneMissioneAttiva;
		//			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
		//			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//			AbilitaDisabilitaCreditoreDebitore();
		//		}

		private void txtEsercMissione_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

      

		string GetFilterMissione(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			string FilterMissione= QHS.CmpLe("yitineration",esercizio);
			if(txtEsercDoc.Text != ""){
				int esercmissione= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					FilterMissione = QHS.CmpEq("yitineration",esercmissione);
				}
				catch {
				}
			} 
			if (FiltraNum){
				int nummissione= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterMissione = GetData.MergeFilters(FilterMissione,
						QHS.CmpEq("nitineration",nummissione));
				} 
			}
			return FilterMissione;
		}


		private void btnMissione_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyMissioneFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyMissioneFilter = GetFilterMissione(true);
			else
				MyMissioneFilter = GetFilterMissione(false);


			DataRow Curr = DS.expense.Rows[0];
			bool condfasecred = chkCredDeb.Checked;
			
			if (condfasecred){
                MyMissioneFilter = QHS.AppAnd(MyMissioneFilter, QHS.CmpEq("idreg", Curr["idreg"]));
			}

			MetaData MMissione;
			DataRow MyDRMissione;

			MMissione = MetaData.GetMetaData(this,"itinerationresidual");
			MMissione.FilterLocked=true;
			MMissione.DS = DS.Clone();

            string filter2 = QHS.AppAnd(QHS.CmpGe("residual", currimp), QHS.NullOrEq("active", 'S'));
			
			MyDRMissione = MMissione.SelectOne("default",
				GetData.MergeFilters( MyMissioneFilter,filter2),
				null,null);
			
			if(MyDRMissione == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectmis = QHS.AppAnd(QHS.CmpEq("yitineration", MyDRMissione["yitineration"]),
                QHS.CmpEq("nitineration", MyDRMissione["nitineration"]));

			string columnlist = QueryCreator.ColumnNameList(DS.itineration)
				+",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("itinerationview",columnlist,null,selectmis,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetMissione();
			CollegaMissione(MyDR);
	
		}

		private void txtNumMissione_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				ScollegaMissione();				
				return;
			}
			btnMissione_Click(sender,e);
		}

		void AbilitaDisabilitaControlliMissione(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		void ClearControlliMissione(){
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaMissione(DataRow Missione2){
			
			Hashtable ValoriMissione = new Hashtable();
			foreach (DataColumn C in DS.itineration.Columns) 
				ValoriMissione[C.ColumnName]= Missione2[C.ColumnName];

			//AzzeraPadre();
			ScollegaMissione();
			DataRow CurrRow= DS.expense.Rows[0];

			if (!faseOrdineInclusa())return false;

			DataRow NewMissR = DS.itineration.NewRow();
			foreach (DataColumn C in DS.itineration.Columns){
				NewMissR[C.ColumnName]= ValoriMissione[C.ColumnName];
			}
			DS.itineration.Rows.Add(NewMissR);
			NewMissR.AcceptChanges();
			Missione2= NewMissR;

			MetaData MovMis = MetaData.GetMetaData(this,"expenseitineration");
			MovMis.SetDefaults(DS.expenseitineration);
			DS.expenseitineration.Columns["iditineration"].DefaultValue= ValoriMissione["iditineration"];
			DataRow RMovMis = MovMis.Get_New_Row(CurrRow, DS.expenseitineration);
			DS.expenseitineration.Columns["iditineration"].DefaultValue= DBNull.Value;
			txtNumDoc.Text= ValoriMissione["nitineration"].ToString();
			txtEsercDoc.Text= ValoriMissione["yitineration"].ToString();

			NuovoDocumento= "Mis."+ValoriMissione["yitineration"].ToString().Substring(2,2)+"/"+
				ValoriMissione["nitineration"].ToString().PadLeft(6,'0');
			NuovoDataDocumento = (DateTime)ValoriMissione["adate"];
			NuovoDescrizione = ValoriMissione["description"];


			RintracciaMissione();
			SetComboCausaleMissione(Missione2);
			AbilitaDisabilitaControlliMissione(false);
			cmbCausale.Enabled=true;
			return true;
		}

		
		void ScollegaMissione(){
			if (DS.expenseitineration.Rows.Count==0) {
				AbilitaDisabilitaControlliMissione(true);
				return;
			}
			DS.expenseitineration.Clear();
			DS.itineration.Clear();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			
			ClearComboCausale();
			AbilitaDisabilitaControlliMissione(true);
		}


	
		#endregion

		#region Gestione ComboBox Causale Missione
		decimal totlordo;
		decimal totanticipo;
		decimal contabilizzato_ANPAG;
		decimal contabilizzato_ANGIR;
		decimal contabilizzato_SALDO;
		decimal contabilizzato_VARIAZIONI;





		string lastMissEvalued=null;
		void CalcolaContabilizzatiMissione(DataRow Missione){
           
            //string filtermiss = "(yitineration='"+Missione["yitineration"].ToString()+"')AND"+
            //    "(nitineration='"+Missione["nitineration"].ToString()+"')";
            string filtermiss = QHS.AppAnd(
                QHS.CmpEq("yitineration", Missione["yitineration"]), QHS.CmpEq("nitineration", Missione["nitineration"])); 
           

            decimal totlordo= CfgFn.GetNoNullDecimal(Missione["totalgross"]);

			if (filtermiss==lastMissEvalued) return;
			lastMissEvalued= filtermiss;

			DataTable Residuo = Conn.RUN_SELECT("itinerationresidual","*",null,filtermiss,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzato_ANGIR= CfgFn.GetNoNullDecimal(CurrResid["linkedangir"]);
			contabilizzato_ANPAG= CfgFn.GetNoNullDecimal(CurrResid["linkedanpag"]);
			contabilizzato_SALDO= CfgFn.GetNoNullDecimal(CurrResid["linkedsaldo"]);
			decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residual"]);
			contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzato_ANPAG-contabilizzato_SALDO);

		}


		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleMissione(DataRow Missione){
			if (!faseMissioneInclusa()){
				cmbCausale.Enabled=false;
				return;
			}
			totlordo= CfgFn.GetNoNullDecimal(Missione["totalgross"]);
			totanticipo =  CfgFn.GetNoNullDecimal(Missione["totadvance"]);
			//string completed = Missione["completed"].ToString().ToUpper();

			CalcolaContabilizzatiMissione(Missione);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;
            object completed = Missione["completed"];

            if (((Meta.EditMode) ||
                ((contabilizzato_SALDO + contabilizzato_ANPAG - contabilizzato_VARIAZIONI) < totlordo) &&
                ((completed != null) && (completed.ToString().ToUpper() == "S")))
                ) {
                EnableTipoMovimento(4, "Pagamento o saldo della missione");
            }

			if ((Meta.EditMode) || 
				((contabilizzato_SALDO==0) && (contabilizzato_ANPAG==0) &&
				(contabilizzato_ANGIR< totanticipo)&&
				(totanticipo-contabilizzato_ANGIR >= currimp)
				)
				){
				EnableTipoMovimento(5,"Anticipo della missione su partita di giro");
			}

			if ((Meta.EditMode) || 
				((contabilizzato_SALDO==0) && (contabilizzato_ANGIR==0) &&
				(contabilizzato_ANPAG< totanticipo)&&
				(totanticipo-contabilizzato_ANPAG >= currimp)
				)
				){
				EnableTipoMovimento(6,"Anticipo della missione sul capitolo di spesa");
			}
            DS.expenseitineration.Rows[0]["movkind"] = 
                (cmbCausale.SelectedValue == null) ? DBNull.Value : cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Missione();
			
		}

	


		void ReCalcImporto_Missione(){
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==4){
				importo= totlordo-(contabilizzato_SALDO+contabilizzato_ANPAG)+contabilizzato_VARIAZIONI;
			}
			if (tipomovimento==5){
				importo= totanticipo-contabilizzato_ANGIR;
			}
			if (tipomovimento==6){
				importo= totanticipo-contabilizzato_ANPAG;
			}
			if (importo<0) importo=0;
			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale della missione poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}

		private void cmbCausaleMissione_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleMissione();
			ReCalcImporto_Missione();//Richiama indirettamente RicalcolaPrestazioneMissione();
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleMissione(){
			CurrCausaleMissione= 0;
			if (DS.expenseitineration.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_missione)return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.expenseitineration.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.expenseitineration.Rows[0]["movkind"]= DBNull.Value;			
			CurrCausaleMissione= CfgFn.GetNoNullInt32( DS.expenseitineration.Rows[0]["movkind"]);
			return CurrCausaleMissione; 
			//ReCalcImporto();
		}

		#endregion


		#region Gestione Selezione Cedolino 



		//		void AbilitaDisabilitaBtnMissione(){
		//			int fasemissione = ManageMissione.faseattivazione;
		//			bool SelezioneMissioneAttiva=false;
		//			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
		//				SelezioneMissioneAttiva=true;
		//			btnDocumento.Enabled=  SelezioneMissioneAttiva;
		//			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
		//			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//			AbilitaDisabilitaCreditoreDebitore();
		//		}

		private void txtEsercCedolino_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

		
		string GetFilterCedolino(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
            string FilterCedolino = QHS.CmpLe("fiscalyear", esercizio);
			if(txtEsercDoc.Text != ""){
				int annoriferimento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
                    if (annoriferimento <= esercizio)
                        FilterCedolino = QHS.CmpEq("fiscalyear", annoriferimento);
                    else
                        FilterCedolino = QHS.CmpEq("fiscalyear", annoriferimento);
					//);
				}
				catch {
				}
			} 
			if (FiltraNum){
				int meseriferimento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
                    FilterCedolino = QHS.AppAnd(FilterCedolino, QHS.CmpEq("npayroll", meseriferimento));
				} 
			}

			//if (Meta.InsertMode){
			if (true){
                FilterCedolino = QHS.AppAnd(FilterCedolino, QHS.IsNull("disbursementdate"), QHS.CmpGe("fiscalyear", esercizio));
			}

			
			return FilterCedolino;
		}


		private void btnCedolino_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyCedolinoFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyCedolinoFilter = GetFilterCedolino(true);
			else
				MyCedolinoFilter = GetFilterCedolino(false);


			DataRow Curr = DS.expense.Rows[0];
			bool condfasecred = chkCredDeb.Checked;
			
			if (condfasecred){
				MyCedolinoFilter= QHS.AppAnd(MyCedolinoFilter,QHS.CmpEq("registry",txtCredDeb.Text));
				
			}

            DataRow CurrExpenseYear = DS.expenseyear.Rows[0];

            MyCedolinoFilter = QHS.AppAnd(MyCedolinoFilter, QHS.CmpEq("idupb", CurrExpenseYear["idupb"]));

            MetaData MCedolino;
			DataRow MyDRCedolino;

			MCedolino = MetaData.GetMetaData(this,"payrollavailable");
			MCedolino.FilterLocked=true;
			MCedolino.DS = DS.Clone();
			
			MyDRCedolino = MCedolino.SelectOne("default",
                QHS.AppAnd(MyCedolinoFilter, QHS.CmpEq("feegross",currimp)),
				null,null);

			if(MyDRCedolino == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectced = QHS.CmpEq("idpayroll", MyDRCedolino["idpayroll"]);


			string columnlist = QueryCreator.ColumnNameList(DS.payroll)
				+",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("payrollview",columnlist,null,selectced,null,null,true);
			
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetCedolino();
			CollegaCedolino(MyDR);
	
		}

		private void txtNumCedolino_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				ScollegaCedolino();				
				return;
			}
			btnCedolino_Click(sender,e);
		}

		void AbilitaDisabilitaControlliCedolino(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		void ClearControlliCedolino(){
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaCedolino(DataRow Cedolino2){
			
			Hashtable ValoriCedolino = new Hashtable();
			foreach (DataColumn C in DS.payroll.Columns) 
				ValoriCedolino[C.ColumnName]= Cedolino2[C.ColumnName];

			//AzzeraPadre();
			ScollegaCedolino();
			DataRow CurrRow= DS.expense.Rows[0];

			if (!faseOrdineInclusa())return false;

			DataRow NewCedR = DS.payroll.NewRow();
			foreach (DataColumn C in DS.payroll.Columns){
				NewCedR[C.ColumnName]= ValoriCedolino[C.ColumnName];
			}
			DS.payroll.Rows.Add(NewCedR);
			NewCedR.AcceptChanges();
			Cedolino2= NewCedR;

			MetaData MovCed = MetaData.GetMetaData(this,"expensepayroll");
			MovCed.SetDefaults(DS.expensepayroll);
			DS.expensepayroll.Columns["idpayroll"].DefaultValue= ValoriCedolino["idpayroll"];
			DataRow RMovCed = MovCed.Get_New_Row(CurrRow, DS.expensepayroll);
			DS.expensepayroll.Columns["idpayroll"].DefaultValue= DBNull.Value;
			txtNumDoc.Text= CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll", 
                QHS.CmpEq("idpayroll",ValoriCedolino["idpayroll"]),         "npayroll")).ToString();
			txtEsercDoc.Text= CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll",
                QHS.CmpEq("idpayroll", ValoriCedolino["idpayroll"]), "fiscalyear")).ToString();

			//txtNumDoc.Text= ValoriMissione["nummissione"].ToString();
			//txtEsercDoc.Text= ValoriMissione["esercmissione"].ToString();

			NuovoDocumento= "Cedolino "+
				ValoriCedolino["fiscalyear"].ToString()+"/"+
				ValoriCedolino["npayroll"].ToString();	//.PadLeft(2,'0');
				
			//NuovoDataDocumento = (DateTime)ValoriMissione["datacontabile"];
			NuovoDescrizione = NuovoDocumento;


			RintracciaCedolino();
			SetComboCausaleCedolino(Cedolino2);
			AbilitaDisabilitaControlliCedolino(false);
			cmbCausale.Enabled=true;
			return true;
		}

		
		void ScollegaCedolino(){
			if (DS.expensepayroll.Rows.Count==0) {
				AbilitaDisabilitaControlliCedolino(true);
				return;
			}
			DS.expensepayroll.Clear();
			DS.payroll.Clear();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			
			ClearComboCausale();
			AbilitaDisabilitaControlliCedolino(true);
		}


	
		#endregion

		#region Gestione ComboBox Causale Cedolino
		decimal cedolinolordo;
		decimal contabilizzatocedolino;




		string lastCedEvalued=null;
		void CalcolaContabilizzatiCedolino(DataRow Cedolino){
            //string filterced = "(idpayroll='"+Cedolino["idpayroll"].ToString()+"')";
            string filterced = QHS.CmpEq("idpayroll", Cedolino["idpayroll"]); 
           

			decimal totlordo= CfgFn.GetNoNullDecimal(Cedolino["feegross"]);

			if (filterced==lastCedEvalued) return;
			lastCedEvalued= filterced;
			
			DataTable Residuo = Conn.RUN_SELECT("payrollresidual","*",null,filterced,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzatocedolino= CfgFn.GetNoNullDecimal(CurrResid["linkedamount"]);
			decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residual"]);

		}


		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleCedolino(DataRow Cedolino){
			if (!faseCedolinoInclusa()){
				cmbCausale.Enabled=false;
				return;
			}
			cedolinolordo= CfgFn.GetNoNullDecimal(Cedolino["feegross"]);
			CalcolaContabilizzatiCedolino(Cedolino);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ( 
				(contabilizzatocedolino< cedolinolordo)
				){
				EnableTipoMovimento(4,"Pagamento");
			}


			//DS.cedolinomovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Cedolino();
			
		}

	


		void ReCalcImporto_Cedolino(){
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if (cmbCausale.SelectedValue==null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=cedolinolordo-contabilizzatocedolino;

			if (importo<0) importo=0;
			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale della missione poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}

		private void cmbCausaleCedolino_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleCedolino();
			ReCalcImporto_Cedolino();//Richiama indirettamente RicalcolaPrestazioneMissione();
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleCedolino(){
			CurrCausaleCedolino= 0;
			if (DS.expensepayroll.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_cedolino)return 0;
			CurrCausaleCedolino= 4;
			return CurrCausaleCedolino; 
			//ReCalcImporto();
		}

		#endregion


		#region Gestione Selezione Occasionale 



		//		void AbilitaDisabilitaBtnMissione(){
		//			int fasemissione = ManageMissione.faseattivazione;
		//			bool SelezioneMissioneAttiva=false;
		//			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
		//				SelezioneMissioneAttiva=true;
		//			btnDocumento.Enabled=  SelezioneMissioneAttiva;
		//			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
		//			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//			AbilitaDisabilitaCreditoreDebitore();
		//		}

		private void txtEsercOccasionale_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

	    string GetFilterOccasionale(bool FiltraNum) {
	        int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
	        string FilterOccasionale = QHS.CmpLe("ycon", esercizio);
	        if (txtEsercDoc.Text != "") {
	            int eserccontratto = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
	            try {
	                if (eserccontratto <= esercizio)
	                    FilterOccasionale = QHS.CmpEq("ycon", eserccontratto);
	                else
	                    FilterOccasionale = //QHS.AppAnd(FilterOccasionale,
	                        QHS.CmpEq("ycon", eserccontratto);
	                //  );
	            }
	            catch {
	            }
	        }

	        if (FiltraNum) {
	            int numcontratto = CfgFn.GetNoNullInt32(txtNumDoc.Text);
	            if (txtNumDoc.Text != "") {
	                FilterOccasionale = QHS.AppAnd(FilterOccasionale,
	                    QHS.CmpEq("ncon", numcontratto));
	            }
	        }

	        FilterOccasionale = QHS.AppAnd(FilterOccasionale, QHS.CmpEq("completed", "S"));

	        return FilterOccasionale;
	    }

	    private void btnOccasionale_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);
			string MyOccasionaleFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyOccasionaleFilter = GetFilterOccasionale(true);
			else
				MyOccasionaleFilter = GetFilterOccasionale(false);

			DataRow Curr = DS.expense.Rows[0];
			bool condfasecred = chkCredDeb.Checked;
			
			if (condfasecred){
				MyOccasionaleFilter = GetData.MergeFilters(MyOccasionaleFilter,
                    QHS.CmpEq("idreg",Curr["idreg"]));
			}


			MetaData MOccasionale;
			DataRow MyDROccasionale;


			MOccasionale = MetaData.GetMetaData(this,"casualcontractavailable");
			MOccasionale.FilterLocked=true;
			MOccasionale.DS = DS.Clone();
			
			MyDROccasionale = MOccasionale.SelectOne("default",
                QHS.AppAnd(MyOccasionaleFilter,QHS.CmpGe("residual",currimp)),
				null,null);
			
			if(MyDROccasionale == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectocc = QHS.AppAnd(QHS.CmpEq("ycon", MyDROccasionale["ycon"]),
                QHS.CmpEq("ncon", MyDROccasionale["ncon"]));
			string columnlist = QueryCreator.ColumnNameList(DS.casualcontract)
				+",registry";

			DataTable Temp = Meta.Conn.RUN_SELECT("casualcontractview",columnlist,null,selectocc,null,null,true);
			
		
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetOccasionale();
			CollegaOccasionale(MyDR);
	
		}

		private void txtNumOccasionale_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				ScollegaOccasionale();				
				return;
			}
			btnOccasionale_Click(sender,e);
		}

		void AbilitaDisabilitaControlliOccasionale(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		void ClearControlliOccasionale(){
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaOccasionale(DataRow ContrattoOcc2){
			
			Hashtable ValoriOccasionale = new Hashtable();
			foreach (DataColumn C in DS.casualcontract.Columns) 
				ValoriOccasionale[C.ColumnName]= ContrattoOcc2[C.ColumnName];


			//AzzeraPadre();
			ScollegaOccasionale();
			DataRow CurrRow= DS.expense.Rows[0];

			if (!faseOccasionaleInclusa())return false;

			DataRow NewOccR = DS.casualcontract.NewRow();
			foreach (DataColumn C in DS.casualcontract.Columns){
				NewOccR[C.ColumnName]= ValoriOccasionale[C.ColumnName];
			}
			DS.casualcontract.Rows.Add(NewOccR);
			NewOccR.AcceptChanges();
			ContrattoOcc2= NewOccR;
			MetaData MovOcc = MetaData.GetMetaData(this,"expensecasualcontract");
			MovOcc.SetDefaults(DS.expensecasualcontract);
			DS.expensecasualcontract.Columns["ycon"].DefaultValue= ValoriOccasionale["ycon"];
			DS.expensecasualcontract.Columns["ncon"].DefaultValue= ValoriOccasionale["ncon"];
			DataRow RMovOcc = MovOcc.Get_New_Row(CurrRow, DS.expensecasualcontract);
			DS.expensecasualcontract.Columns["ycon"].DefaultValue= DBNull.Value;
			DS.expensecasualcontract.Columns["ncon"].DefaultValue= DBNull.Value;
			txtEsercDoc.Text= ValoriOccasionale["ycon"].ToString();
			txtNumDoc.Text= ValoriOccasionale["ncon"].ToString();

			NuovoDocumento=  "Contratto Occasionale "+
				ValoriOccasionale["ycon"].ToString().Substring(2,2)+"/"+
				ValoriOccasionale["ncon"].ToString().PadLeft(6,'0');
			NuovoDataDocumento = ValoriOccasionale["adate"];
			NuovoDescrizione = ValoriOccasionale["description"];


			RintracciaOccasionale();
			SetComboCausaleOccasionale(ContrattoOcc2);
			AbilitaDisabilitaControlliOccasionale(false);
			cmbCausale.Enabled=true;
			return true;
		}

		
		void ScollegaOccasionale(){
			if (DS.expensecasualcontract.Rows.Count==0) {
				AbilitaDisabilitaControlliOccasionale(true);
				return;
			}
			DS.expensecasualcontract.Clear();
			DS.casualcontract.Clear();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			
			ClearComboCausale();
			AbilitaDisabilitaControlliOccasionale(true);
		}


	
		#endregion

		#region Gestione ComboBox Causale Occasionale
		decimal occasionalelordo;
		decimal contabilizzatooccasionale;



		string lastOccEvalued=null;

		void CalcolaContabilizzatiOccasionale(DataRow ContrattoOcc){
            string filterocc = QHS.AppAnd(
                QHS.CmpEq("ycon", ContrattoOcc["ycon"]), QHS.CmpEq("ncon", ContrattoOcc["ncon"]));               
			decimal totlordo= CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);

			if (filterocc==lastOccEvalued) return;
			lastOccEvalued= filterocc;
			
			DataTable Residuo = Conn.RUN_SELECT("casualcontractresidual","*",null,filterocc,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzatooccasionale= CfgFn.GetNoNullDecimal(CurrResid["linkedtotal"]);
			//decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residuo"]);
			//contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzatooccasionale);
		}




		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleOccasionale(DataRow ContrattoOcc){
			if (!faseOccasionaleInclusa()){
				cmbCausale.Enabled=false;
				return;
			}
			occasionalelordo= CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);

			CalcolaContabilizzatiOccasionale(ContrattoOcc);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;
			if ( (Meta.EditMode) || 
				(contabilizzatooccasionale< occasionalelordo)
				){
				EnableTipoMovimento(4,"Pagamento");
			}

			//DS.contrattooccmovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Occasionale();
			
		}

	


		void ReCalcImporto_Occasionale(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if ((currphase()>1)&&(Curr["parentidexp"]==DBNull.Value)) return;
			if (cmbCausale.SelectedValue==null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=occasionalelordo-contabilizzatooccasionale;

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

			if (importo<0) importo=0;
			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale del contratto poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}

		private void cmbCausaleOccasionale_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleOccasionale();
			ReCalcImporto_Occasionale();//Richiama indirettamente RicalcolaPrestazioneMissione();
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleOccasionale(){
			CurrCausaleOccasionale= 0;
			if (DS.expensecasualcontract.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_occasionale)return 0;
			CurrCausaleOccasionale= 4;
			return CurrCausaleOccasionale; 
		}

		#endregion


		
		#region Gestione Selezione Dipendente 



		//		void AbilitaDisabilitaBtnMissione(){
		//			int fasemissione = ManageMissione.faseattivazione;
		//			bool SelezioneMissioneAttiva=false;
		//			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
		//				SelezioneMissioneAttiva=true;
		//			btnDocumento.Enabled=  SelezioneMissioneAttiva;
		//			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
		//			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//			AbilitaDisabilitaCreditoreDebitore();
		//		}

		private void txtEsercDipendente_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}
		string GetFilterDipendente(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			string FilterDipendente = QHS.CmpLe("ycon",esercizio);
			if(txtEsercDoc.Text != ""){
				int eserccontratto= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (eserccontratto <= esercizio) 
						FilterDipendente=QHS.CmpEq("ycon",eserccontratto);
					else 
						FilterDipendente = GetData.MergeFilters(FilterDipendente,
                            QHS.CmpEq("ycon", eserccontratto));
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numcontratto= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterDipendente = GetData.MergeFilters(FilterDipendente,
                        QHS.CmpEq("ncon", numcontratto));
				} 
			}						

			return FilterDipendente;
		}

		private void btnDipendente_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);
			string MyDipendenteFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyDipendenteFilter = GetFilterDipendente(true);
			else
				MyDipendenteFilter = GetFilterDipendente(false);

			DataRow Curr = DS.expense.Rows[0];
			bool condfasecred = chkCredDeb.Checked;
			
			if (condfasecred){
				MyDipendenteFilter = GetData.MergeFilters(MyDipendenteFilter,
                    QHS.CmpEq("idreg", Curr["idreg"]));
			}

			MetaData MDipendente;
			DataRow MyDRDipendente;


			MDipendente = MetaData.GetMetaData(this,"wageadditionavailable");
			MDipendente.FilterLocked=true;
			MDipendente.DS = DS.Clone();
			
			MyDRDipendente = MDipendente.SelectOne("default",
				GetData.MergeFilters( MyDipendenteFilter, QHS.CmpGe("residual",currimp)),
				null,null);
			
			if(MyDRDipendente == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectdip = QHS.AppAnd(QHS.CmpEq("ycon", MyDRDipendente["ycon"]),
                                          QHS.CmpEq("ncon", MyDRDipendente["ncon"]));

			string columnlist = QueryCreator.ColumnNameList(DS.wageaddition)
				+",registry";

			DataTable Temp = Meta.Conn.RUN_SELECT("wageadditionview",columnlist,null,selectdip,null,null,true);
			
		
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetDipendente();
			CollegaDipendente(MyDR);
	
		}

		private void txtNumDipendente_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				ScollegaDipendente();				
				return;
			}
			btnDipendente_Click(sender,e);
		}

		void AbilitaDisabilitaControlliDipendente(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		void ClearControlliDipendente(){
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaDipendente(DataRow ContrattoDip2){
			
			Hashtable ValoriDipendente = new Hashtable();
			foreach (DataColumn C in DS.wageaddition.Columns) 
				ValoriDipendente[C.ColumnName]= ContrattoDip2[C.ColumnName];


			//AzzeraPadre();
			ScollegaDipendente();
			DataRow CurrRow= DS.expense.Rows[0];

			if (!faseDipendenteInclusa())return false;

			DataRow NewDipR = DS.wageaddition.NewRow();
			foreach (DataColumn C in DS.wageaddition.Columns){
				NewDipR[C.ColumnName]= ValoriDipendente[C.ColumnName];
			}
			DS.wageaddition.Rows.Add(NewDipR);
			NewDipR.AcceptChanges();
			ContrattoDip2= NewDipR;
			MetaData MovDip = MetaData.GetMetaData(this,"expensewageaddition");
			MovDip.SetDefaults(DS.expensewageaddition);
			DS.expensewageaddition.Columns["ycon"].DefaultValue= ValoriDipendente["ycon"];
			DS.expensewageaddition.Columns["ncon"].DefaultValue= ValoriDipendente["ncon"];
			DataRow RMovDip = MovDip.Get_New_Row(CurrRow, DS.expensewageaddition);
			DS.expensewageaddition.Columns["ycon"].DefaultValue= DBNull.Value;
			DS.expensewageaddition.Columns["ncon"].DefaultValue= DBNull.Value;
			txtEsercDoc.Text= ValoriDipendente["ycon"].ToString();
			txtNumDoc.Text= ValoriDipendente["ncon"].ToString();

            NuovoDocumento = "Altri Compensi " +
				ValoriDipendente["ycon"].ToString().Substring(2,2)+"/"+
				ValoriDipendente["ncon"].ToString().PadLeft(6,'0');
			NuovoDataDocumento = ValoriDipendente["adate"];
			NuovoDescrizione = ValoriDipendente["description"];


			RintracciaDipendente();
			SetComboCausaleDipendente(ContrattoDip2);
			AbilitaDisabilitaControlliDipendente(false);
			cmbCausale.Enabled=true;
			return true;
		}

		
		void ScollegaDipendente(){
			if (DS.expensewageaddition.Rows.Count==0) {
				AbilitaDisabilitaControlliDipendente(true);
				return;
			}
			DS.expensewageaddition.Clear();
			DS.wageaddition.Clear();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			
			ClearComboCausale();
			AbilitaDisabilitaControlliDipendente(true);
		}


		#endregion

		#region Gestione ComboBox Causale Dipendente
		decimal dipendentelordo;
		decimal contabilizzatodipendente;



		string lastDipEvalued=null;

		void CalcolaContabilizzatiDipendente(DataRow ContrattoDip){
            string filterdip = QHS.AppAnd(
                QHS.CmpEq("ycon", ContrattoDip["ycon"]), QHS.CmpEq("ncon", ContrattoDip["ncon"])); 
			decimal totlordo= CfgFn.GetNoNullDecimal(ContrattoDip["feegross"]);

			if (filterdip==lastDipEvalued) return;
			lastDipEvalued= filterdip;
			
			DataTable Residuo = Conn.RUN_SELECT("wageadditionresidual","*",null,filterdip,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			contabilizzatodipendente= CfgFn.GetNoNullDecimal(CurrResid["linkedtotal"]);
			//decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residuo"]);
			//contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzatooccasionale);
		}




		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleDipendente(DataRow ContrattoDip){
			if (!faseDipendenteInclusa()){
				cmbCausale.Enabled=false;
				return;
			}
			dipendentelordo= CfgFn.GetNoNullDecimal(ContrattoDip["feegross"]);

			CalcolaContabilizzatiDipendente(ContrattoDip);

			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;
			if ( (Meta.EditMode) || 
				(contabilizzatodipendente< dipendentelordo)
				){
				EnableTipoMovimento(4,"Pagamento");
			}

			//DS.contrattooccmovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Dipendente();
			
		}

	


		void ReCalcImporto_Dipendente(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if ((currphase()>1)&&(Curr["parentidexp"]==DBNull.Value)) return;
			if (cmbCausale.SelectedValue==null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=dipendentelordo-contabilizzatodipendente;

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

			if (importo<0) importo=0;
			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale del compenso poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}

		private void cmbCausaleDipendente_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleDipendente();
			ReCalcImporto_Dipendente();//Richiama indirettamente RicalcolaPrestazioneMissione();
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleDipendente(){
			CurrCausaleDipendente= 0;
			if (DS.expensewageaddition.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_dipendente)return 0;
			CurrCausaleDipendente= 4;
			return CurrCausaleDipendente; 
		}

		#endregion


		#region Gestione Selezione Professionale 



		//		void AbilitaDisabilitaBtnMissione(){
		//			int fasemissione = ManageMissione.faseattivazione;
		//			bool SelezioneMissioneAttiva=false;
		//			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
		//				SelezioneMissioneAttiva=true;
		//			btnDocumento.Enabled=  SelezioneMissioneAttiva;
		//			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
		//			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
		//			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
		//			AbilitaDisabilitaCreditoreDebitore();
		//		}

		private void txtEsercProfessionale_Leave(object sender, System.EventArgs e) {
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
		}

		string GetFilterProfessionale(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
            string FilterProfessionale = QHS.CmpLe("ycon", esercizio);
			if(txtEsercDoc.Text != ""){
				int eserccontratto= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
                    if (eserccontratto <= esercizio)
                        FilterProfessionale = QHS.CmpEq("ycon", eserccontratto);
                    else
                        FilterProfessionale = // QHS.AppAnd(FilterProfessionale,
                            QHS.CmpEq("ycon", eserccontratto);
                            //);
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numcontratto= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
                    FilterProfessionale = QHS.AppAnd(FilterProfessionale,
                        QHS.CmpEq("ncon", numcontratto));
				} 
			}						

			return FilterProfessionale;
		}

		private void btnProfessionale_Click(object sender, System.EventArgs e) {
			
			DataAccess Conn = MetaData.GetConnection(this);

			string MyProfessionaleFilter;
			if (((Control)sender).Name == "txtNumDoc")
				MyProfessionaleFilter = GetFilterProfessionale(true);
			else
				MyProfessionaleFilter = GetFilterProfessionale(false);


			DataRow Curr = DS.expense.Rows[0];
			bool condfasecred = chkCredDeb.Checked;
			
			if (condfasecred){
                MyProfessionaleFilter = QHS.AppAnd(MyProfessionaleFilter,QHS.CmpEq("idreg", Curr["idreg"]));
			}


			MetaData MProfessionale;
			DataRow MyDRProfessionale;


			MProfessionale = MetaData.GetMetaData(this,"profserviceavailable");
			MProfessionale.FilterLocked=true;
			MProfessionale.DS = DS.Clone();
			
			MyDRProfessionale = MProfessionale.SelectOne("default",
                QHS.AppAnd(MyProfessionaleFilter,QHS.CmpGe("residual",currimp)),
				null,null);
			
			if(MyDRProfessionale == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
            string selectprof = QHS.AppAnd(QHS.CmpEq("ycon", MyDRProfessionale["ycon"]),
                QHS.CmpEq("ncon", MyDRProfessionale["ncon"]));

			string columnlist = QueryCreator.ColumnNameList(DS.profservice)
				+",registry";

			DataTable Temp = Meta.Conn.RUN_SELECT("profserviceview",columnlist,null,selectprof,null,null,true);
			
		
			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			ResetProfessionale();
			CollegaProfessionale(MyDR);
	
		}

		private void txtNumProfessionale_Leave(object sender, System.EventArgs e) {
			if (txtNumDoc.ReadOnly)return;
			//if (!Meta.InsertMode) return;

			if (txtNumDoc.Text.Trim()=="") {
				ScollegaProfessionale();				
				return;
			}
			btnProfessionale_Click(sender,e);
		}

		void AbilitaDisabilitaControlliProfessionale(bool abilita){
			//txtCredDeb.ReadOnly=!abilita;
		}

		void ClearControlliProfessionale(){
		}

		/// <summary>
		/// Collega la riga missione al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		bool CollegaProfessionale(DataRow ContrattoProf2){
			
			Hashtable ValoriProfessionale = new Hashtable();
			foreach (DataColumn C in DS.profservice.Columns) 
				ValoriProfessionale[C.ColumnName]= ContrattoProf2[C.ColumnName];


			//AzzeraPadre();
			ScollegaProfessionale();
			DataRow CurrRow= DS.expense.Rows[0];

			if (!faseProfessionaleInclusa())return false;

			DataRow NewProfR = DS.profservice.NewRow();
			foreach (DataColumn C in DS.profservice.Columns){
				NewProfR[C.ColumnName]= ValoriProfessionale[C.ColumnName];
			}
			DS.profservice.Rows.Add(NewProfR);
			NewProfR.AcceptChanges();
			ContrattoProf2= NewProfR;
			MetaData MovProf = MetaData.GetMetaData(this,"expenseprofservice");
			MovProf.SetDefaults(DS.expenseprofservice);
			DS.expenseprofservice.Columns["ycon"].DefaultValue= ValoriProfessionale["ycon"];
			DS.expenseprofservice.Columns["ncon"].DefaultValue= ValoriProfessionale["ncon"];
			DataRow RMovOcc = MovProf.Get_New_Row(CurrRow, DS.expenseprofservice);
			DS.expenseprofservice.Columns["ycon"].DefaultValue= DBNull.Value;
			DS.expenseprofservice.Columns["ncon"].DefaultValue= DBNull.Value;
			txtEsercDoc.Text= ValoriProfessionale["ycon"].ToString();
			txtNumDoc.Text= ValoriProfessionale["ncon"].ToString();


			NuovoDocumento=  ValoriProfessionale["doc"];
			NuovoDataDocumento = ValoriProfessionale["adate"];
			NuovoDescrizione = ValoriProfessionale["description"];


			RintracciaProfessionale();
			SetComboCausaleProfessionale(ContrattoProf2);
			AbilitaDisabilitaControlliProfessionale(false);
			cmbCausale.Enabled=true;
			return true;
		}

		
		void ScollegaProfessionale(){
			if (DS.expenseprofservice.Rows.Count==0) {
				AbilitaDisabilitaControlliProfessionale(true);
				return;
			}
			DS.expenseprofservice.Clear();
			DS.profservice.Clear();
			NuovoDataDocumento=null;
			NuovoDocumento=null;
			NuovoDescrizione=null;
			
			ClearComboCausale();
			AbilitaDisabilitaControlliProfessionale(true);
		}


	
		#endregion

		#region Gestione ComboBox Causale Professionale

		decimal totprofimponibile;
		decimal totprofiva;
		decimal assigned_profimponibile;
		decimal assigned_profiva;
		decimal assigned_profgen;


		string lastProfEvalued=null;
		void CalcolaContabilizzatiProfessionale(DataRow ContrattoProf){
            string filterprof = QHS.AppAnd(QHS.CmpEq("ycon", ContrattoProf["ycon"]),
                                QHS.CmpEq("ncon",ContrattoProf["ncon"]));
			if (filterprof==lastProfEvalued) return;
			lastProfEvalued= filterprof;
			decimal costototale= CfgFn.GetNoNullDecimal(ContrattoProf["totalcost"]);			
			totprofiva=CfgFn.GetNoNullDecimal( ContrattoProf["importoiva"]);
			totprofimponibile=costototale-totprofiva;

			DataTable Residuo = Conn.RUN_SELECT("profserviceresidual","*",null,filterprof,null,true);

			DataRow CurrResid = Residuo.Rows[0];
			assigned_profimponibile= CfgFn.GetNoNullDecimal(CurrResid["linkedimpon"]);
			assigned_profiva= CfgFn.GetNoNullDecimal(CurrResid["linkedimpos"]);
			assigned_profgen= CfgFn.GetNoNullDecimal(CurrResid["linkeddocum"]);
			//decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residuo"]);
			//contabilizzato_VARIAZIONI= 0; //-(totlordo-residuo-contabilizzato_ANPAG-contabilizzato_SALDO);

		}




		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleProfessionale(DataRow ContrattoProf){
			if (!faseProfessionaleInclusa()){
				cmbCausale.Enabled=false;
				return;
			}

            string filterordine = QHS.AppAnd(QHS.CmpEq("ycon", ContrattoProf["ycon"]),
                        QHS.CmpEq("ncon", ContrattoProf["ncon"]));


			DataTable T= Conn.RUN_SELECT("profserviceresidual","*",null,filterordine,null,true);
			if ((T!=null)&&(T.Rows.Count>0)){
				DataRow R=T.Rows[0];
				totprofimponibile=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
				totprofiva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
				assigned_profimponibile= CfgFn.GetNoNullDecimal( R["linkedimpon"]);
				assigned_profiva= CfgFn.GetNoNullDecimal( R["linkedimpos"]);
				assigned_profgen=CfgFn.GetNoNullDecimal( R["linkeddocum"]);

			}
			else {
				totprofimponibile= 0;
				totprofiva =  0;
				assigned_profimponibile= 0;
				assigned_profiva= 0;
				assigned_profgen= 0;
			}


			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ((Meta.EditMode) || 
				((assigned_profimponibile+assigned_profiva)==0) && 
				(assigned_profgen< (totprofimponibile+totprofiva))
				){
				EnableTipoMovimento(1,"Contabilizzazione Totale Fattura");
			}

			if ((Meta.EditMode) || 
				( (assigned_profgen==0) &&(assigned_profimponibile < totprofimponibile))
				){
				EnableTipoMovimento(3,"Contabilizzazione Imponibile Fattura");
			}

			if ( (Meta.EditMode) || 
				( (assigned_profgen==0) &&(assigned_profiva< totprofiva))
				){
				EnableTipoMovimento(2,"Contabilizzazione Iva Fattura");
			}

			DS.expenseprofservice.Rows[0]["movkind"]=
                (cmbCausale.SelectedValue == null) ? DBNull.Value : cmbCausale.SelectedValue;
			cmbCausale.Enabled=Meta.InsertMode;
			ReCalcImporto_Professionale();
			
		}

	


		void ReCalcImporto_Professionale(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.Tables["expense"].Rows[0];
			if ((currphase()>1)&&(Curr["parentidexp"]==DBNull.Value)) return;
			if (cmbCausale.SelectedValue==null) return;

			int tipomovimento = CfgFn.GetNoNullInt32( cmbCausale.SelectedValue);

			decimal importo=0;
			if (tipomovimento==2){
				importo= totprofiva-assigned_profiva;
			}
			if (tipomovimento==3){
				importo= totprofimponibile-assigned_profimponibile;
			}
			if (tipomovimento==1){
				importo= totprofimponibile+totprofiva-assigned_profgen;
			}
			if (importo<0) importo=0;

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

			if (importo> currimp) {
				MessageBox.Show("Sarà effettuata una contabilizzazione parziale del contratto poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
			}

		}

		private void cmbCausaleProfessionale_SelectedIndexChanged(object sender, System.EventArgs e) {
			GetCausaleProfessionale();
			ReCalcImporto_Professionale();//Richiama indirettamente RicalcolaPrestazioneMissione();
		}

		
		/// <summary>
		/// Legge la causale dal combobox e la mette in tipomovimento ove 
		///  possibile.
		/// </summary>
		int GetCausaleProfessionale(){
			CurrCausaleProfessionale= 0;
			if (DS.expenseprofservice.Rows.Count==0) return 0;
			if (ContabilizzazioneSelezionata()!=tipocont.cont_professionale)return 0;
			if (cmbCausale.SelectedValue!=null)
				DS.expenseprofservice.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.expenseprofservice.Rows[0]["movkind"]= DBNull.Value;			
			CurrCausaleProfessionale= CfgFn.GetNoNullInt32( DS.expenseprofservice.Rows[0]["movkind"]);
			return CurrCausaleProfessionale; 
		}

		#endregion

		void ResetMissione(){
		}

		void RintracciaMissione(){
		}

		void ResetCedolino(){
		}

		void RintracciaCedolino(){
		}

		void ResetOrdine(){
		}

		void RintracciaOrdine(){
		}

		void ResetIva(){
		}

		void RintracciaIva(){
		}

		void ResetOccasionale(){
		}

		void RintracciaOccasionale(){
		}

		void ResetProfessionale(){
		}

		void RintracciaProfessionale(){
		}

		void ResetDipendente(){
		}

		void RintracciaDipendente(){
		}

		private void tabController_SelectionChanged(object sender, System.EventArgs e) {
		
		}
	}
}
