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
using funzioni_configurazione;//funzioni_configurazione

namespace expense_wizarddecontabilizza {//spesawizarddecontabilizza//
	/// <summary>
	/// Summary description for FrmSpesaWizardDecontabilizza.
	/// </summary>
	public class Frm_expense_wizarddecontabilizza : System.Windows.Forms.Form {
		private Crownwood.Magic.Controls.TabPage tabIntro;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnBack;
		private Crownwood.Magic.Controls.TabPage tabSelect;
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
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox gboxDocumento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.Label labelTipoDocumento;
		private System.Windows.Forms.Label labelCausale;
		private System.Windows.Forms.TextBox txtTipoCont;
		private System.Windows.Forms.TextBox txtCausale;
		MetaData Meta;
		DataAccess Conn;
		private System.Windows.Forms.TextBox txtTipoDoc;
		string CustomTitle;
		private Crownwood.Magic.Controls.TabControl tabController;
		private Crownwood.Magic.Controls.TabPage tabElimina;
		private System.Windows.Forms.Label labMSG;
		private System.Windows.Forms.Label label18;
		public vistaForm DS;
		private System.Windows.Forms.Label labDocumento;
		int fasespesacont;
		int faseivaspesa;
		private System.Windows.Forms.Label labNum;
		private System.Windows.Forms.Label labEserc;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.ComponentModel.IContainer components;
        CQueryHelper QHC;
        private GroupBox gboxBilAnnuale;
        private Label label9;
        private TextBox txtCodiceBilancio;
        private TextBox txtDenominazioneBilancio;
        public TextBox txtResponsabile;
        public TextBox txtUPB;
        QueryHelper QHS;

		public Frm_expense_wizarddecontabilizza() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			tabController.HideTabsMode = 
				Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}

		public void MetaData_AfterActivation(){
			CustomTitle= "Wizard Rimozione Contabilizzazioni";
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expense_wizarddecontabilizza));
            this.DS = new expense_wizarddecontabilizza.vistaForm();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabSelect = new Crownwood.Magic.Controls.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.txtTipoCont = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gboxDocumento = new System.Windows.Forms.GroupBox();
            this.labDocumento = new System.Windows.Forms.Label();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labelTipoDocumento = new System.Windows.Forms.Label();
            this.labelCausale = new System.Windows.Forms.Label();
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
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabElimina = new Crownwood.Magic.Controls.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.labMSG = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabSelect.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.gboxDocumento.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.tabElimina.SuspendLayout();
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
            this.tabController.Size = new System.Drawing.Size(865, 454);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabSelect,
            this.tabElimina});
            // 
            // tabSelect
            // 
            this.tabSelect.Controls.Add(this.gboxUPB);
            this.tabSelect.Controls.Add(this.groupBox16);
            this.tabSelect.Controls.Add(this.txtCausale);
            this.tabSelect.Controls.Add(this.txtTipoCont);
            this.tabSelect.Controls.Add(this.label8);
            this.tabSelect.Controls.Add(this.gboxDocumento);
            this.tabSelect.Controls.Add(this.labelCausale);
            this.tabSelect.Controls.Add(this.label6);
            this.tabSelect.Controls.Add(this.groupBox20);
            this.tabSelect.Controls.Add(this.groupBox18);
            this.tabSelect.Controls.Add(this.groupBox17);
            this.tabSelect.Controls.Add(this.gboxBilAnnuale);
            this.tabSelect.Controls.Add(this.groupCredDeb);
            this.tabSelect.Controls.Add(this.groupBox1);
            this.tabSelect.Controls.Add(this.gboxMovimento);
            this.tabSelect.Location = new System.Drawing.Point(0, 0);
            this.tabSelect.Name = "tabSelect";
            this.tabSelect.Size = new System.Drawing.Size(865, 429);
            this.tabSelect.TabIndex = 4;
            this.tabSelect.Title = "Pagina 2 di 3";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(16, 155);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(466, 97);
            this.gboxUPB.TabIndex = 92;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 65);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.ReadOnly = true;
            this.txtUPB.Size = new System.Drawing.Size(452, 21);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(324, 51);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Enabled = false;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(11, 39);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.txtResponsabile);
            this.groupBox16.Location = new System.Drawing.Point(16, 253);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(466, 40);
            this.groupBox16.TabIndex = 91;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(8, 13);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.ReadOnly = true;
            this.txtResponsabile.Size = new System.Drawing.Size(452, 21);
            this.txtResponsabile.TabIndex = 1;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // txtCausale
            // 
            this.txtCausale.Location = new System.Drawing.Point(574, 183);
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(280, 21);
            this.txtCausale.TabIndex = 77;
            // 
            // txtTipoCont
            // 
            this.txtTipoCont.Location = new System.Drawing.Point(646, 159);
            this.txtTipoCont.Name = "txtTipoCont";
            this.txtTipoCont.ReadOnly = true;
            this.txtTipoCont.Size = new System.Drawing.Size(208, 21);
            this.txtTipoCont.TabIndex = 76;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(518, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 75;
            this.label8.Text = "Tipo contabilizzazione";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxDocumento
            // 
            this.gboxDocumento.Controls.Add(this.labDocumento);
            this.gboxDocumento.Controls.Add(this.txtTipoDoc);
            this.gboxDocumento.Controls.Add(this.label7);
            this.gboxDocumento.Controls.Add(this.txtNumDoc);
            this.gboxDocumento.Controls.Add(this.label10);
            this.gboxDocumento.Controls.Add(this.txtEsercDoc);
            this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
            this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.gboxDocumento.Location = new System.Drawing.Point(495, 207);
            this.gboxDocumento.Name = "gboxDocumento";
            this.gboxDocumento.Size = new System.Drawing.Size(359, 72);
            this.gboxDocumento.TabIndex = 73;
            this.gboxDocumento.TabStop = false;
            this.gboxDocumento.Text = "Documento contabilizzato";
            this.gboxDocumento.Visible = false;
            // 
            // labDocumento
            // 
            this.labDocumento.Location = new System.Drawing.Point(8, 48);
            this.labDocumento.Name = "labDocumento";
            this.labDocumento.Size = new System.Drawing.Size(104, 16);
            this.labDocumento.TabIndex = 8;
            this.labDocumento.Text = "Documento";
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.txtTipoDoc.Location = new System.Drawing.Point(40, 16);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.ReadOnly = true;
            this.txtTipoDoc.Size = new System.Drawing.Size(298, 20);
            this.txtTipoDoc.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 48);
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
            this.txtEsercDoc.Location = new System.Drawing.Point(152, 48);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
            this.txtEsercDoc.TabIndex = 2;
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
            this.labelCausale.Location = new System.Drawing.Point(518, 200);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(48, 23);
            this.labelCausale.TabIndex = 71;
            this.labelCausale.Text = "Causale";
            this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(504, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "Selezionare il movimento di spesa che si desidera scollegare dal documento associ" +
                "ato";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(17, 378);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(344, 40);
            this.groupBox20.TabIndex = 27;
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
            this.groupBox18.Location = new System.Drawing.Point(16, 113);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(466, 40);
            this.groupBox18.TabIndex = 26;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Importo";
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(136, 11);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.ReadOnly = true;
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(121, 21);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "";
            this.SubEntity_txtImportoMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(67, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(495, 35);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(367, 72);
            this.groupBox17.TabIndex = 24;
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
            this.txtDescrizione.Size = new System.Drawing.Size(353, 48);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.label9);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(17, 292);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(465, 80);
            this.gboxBilAnnuale.TabIndex = 21;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImageIndex = 0;
            this.label9.ImageList = this.imageList1;
            this.label9.Location = new System.Drawing.Point(7, 32);
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
            this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 55);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(453, 21);
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
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(307, 44);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(495, 107);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(367, 40);
            this.groupCredDeb.TabIndex = 23;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "";
            this.groupCredDeb.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.ReadOnly = true;
            this.txtCredDeb.Size = new System.Drawing.Size(351, 21);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblImportoDisponibile);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtImportoDisponibile);
            this.groupBox1.Controls.Add(this.txtImportoCorrente);
            this.groupBox1.Location = new System.Drawing.Point(495, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 70);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
            // 
            // lblImportoDisponibile
            // 
            this.lblImportoDisponibile.Location = new System.Drawing.Point(37, 44);
            this.lblImportoDisponibile.Name = "lblImportoDisponibile";
            this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
            this.lblImportoDisponibile.TabIndex = 0;
            this.lblImportoDisponibile.Text = "Disponibile:";
            this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(37, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(200, 24);
            this.label12.TabIndex = 0;
            this.label12.Text = "Attuale (comprensivo delle variazioni):";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoDisponibile
            // 
            this.txtImportoDisponibile.Location = new System.Drawing.Point(256, 44);
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
            this.txtImportoCorrente.Location = new System.Drawing.Point(256, 20);
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
            this.gboxMovimento.Location = new System.Drawing.Point(13, 27);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(469, 80);
            this.gboxMovimento.TabIndex = 20;
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
            this.txtNumeroMovimento.Location = new System.Drawing.Point(251, 43);
            this.txtNumeroMovimento.Name = "txtNumeroMovimento";
            this.txtNumeroMovimento.Size = new System.Drawing.Size(68, 21);
            this.txtNumeroMovimento.TabIndex = 3;
            this.txtNumeroMovimento.Tag = "";
            this.txtNumeroMovimento.Leave += new System.EventHandler(this.txtNumeroMovimento_Leave);
            // 
            // labNum
            // 
            this.labNum.Location = new System.Drawing.Point(219, 43);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(32, 20);
            this.labNum.TabIndex = 0;
            this.labNum.Text = "Num.";
            this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioMovimento
            // 
            this.txtEsercizioMovimento.Location = new System.Drawing.Point(134, 45);
            this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
            this.txtEsercizioMovimento.Size = new System.Drawing.Size(55, 21);
            this.txtEsercizioMovimento.TabIndex = 2;
            this.txtEsercizioMovimento.Tag = "";
            this.txtEsercizioMovimento.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
            // 
            // labEserc
            // 
            this.labEserc.Location = new System.Drawing.Point(94, 45);
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
            this.cmbFaseSpesa.Size = new System.Drawing.Size(329, 21);
            this.cmbFaseSpesa.TabIndex = 1;
            this.cmbFaseSpesa.Tag = "expense.nphase";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(865, 429);
            this.tabIntro.TabIndex = 3;
            this.tabIntro.Title = "Pagina 1 di 3";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(16, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(809, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "L\'unica informazione che sar‡ eliminata sar‡ il COLLEGAMENTO tra il movimento di " +
                "spesa e il documento associato.";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(809, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Il documento in se stesso non sar‡ rimosso, e neanche sar‡ rimosso il movimento d" +
                "i spesa che lo contabilizza.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(817, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // tabElimina
            // 
            this.tabElimina.Controls.Add(this.label18);
            this.tabElimina.Controls.Add(this.labMSG);
            this.tabElimina.Location = new System.Drawing.Point(0, 0);
            this.tabElimina.Name = "tabElimina";
            this.tabElimina.Selected = false;
            this.tabElimina.Size = new System.Drawing.Size(865, 429);
            this.tabElimina.TabIndex = 5;
            this.tabElimina.Title = "Pagina 3 di 3";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(664, 23);
            this.label18.TabIndex = 1;
            this.label18.Text = "Premere Rimuovi per eseguire l\'operazione.";
            // 
            // labMSG
            // 
            this.labMSG.Location = new System.Drawing.Point(8, 16);
            this.labMSG.Name = "labMSG";
            this.labMSG.Size = new System.Drawing.Size(672, 40);
            this.labMSG.TabIndex = 0;
            this.labMSG.Text = "Messaggio";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(777, 468);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Tag = "maincancel";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(657, 468);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(88, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(569, 468);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Frm_expense_wizarddecontabilizza
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(881, 497);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabController);
            this.Name = "Frm_expense_wizarddecontabilizza";
            this.Text = "FrmSpesaWizardDecontabilizza";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabSelect.ResumeLayout(false);
            this.tabSelect.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.gboxDocumento.ResumeLayout(false);
            this.gboxDocumento.PerformLayout();
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
            this.tabElimina.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion



		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			GetData.CacheTable(DS.expensephase);
			GetData.CacheTable(DS.incomephase);
			GetData.CacheTable(DS.manager,null,null,true);
			GetData.CacheTable(DS.invoicekind);
			GetData.CacheTable(DS.mandatekind);
			txtEsercizioMovimento.Text= Meta.GetSys("esercizio").ToString();
			fasespesacont= CfgFn.GetNoNullInt32(Meta.GetSys("mandatephase"));//Conn.DO_READ_VALUE("expensesetup","(ayear='"+Meta.GetSys("esercizio").ToString()+"')","expensephase"));
			faseivaspesa = CfgFn.GetNoNullInt32(Meta.GetSys("invoiceexpensephase"));//Conn.DO_READ_VALUE("invoicesetup","(ayear='"+Meta.GetSys("esercizio").ToString()+"')","expensephase"));

			currcont = tipocont.cont_none;
		}

		public void MetaData_AfterClear(){
			DisplayTabs(tabController.SelectedIndex);
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
				btnNext.Text="Rimuovi.";
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
			if (currcont== tipocont.cont_none){
				MessageBox.Show("Al movimento selezionato non Ë associata alcuna contabilizzazione.");
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


		void AddVociFiglieWhereEmpty(DataTable T, string filter){
			if (T.Select(filter).Length>0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,T,null,filter,null,true);
		}

		void AddVoceBilancio(object ID){
			if (ID==DBNull.Value) return;
			if (DS.fin.Select(QHC.CmpEq("idfin",ID)).Length>0)return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.fin,null,QHS.CmpEq("idfin",ID),null,true);			
		}

		void AddVoceUPB(object ID){
			if (ID==DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.upb, null, QHS.CmpEq("idupb", ID), null, true);			
		}

		void AddVoceFaseSpesa(object codice){
			if (codice==DBNull.Value) return;
			if (DS.expensephase.Select(QHC.CmpEq("nphase",codice)).Length>0)return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.expensephase,null,QHS.CmpEq("nphase",codice),null,true);			

		}

        void AddVoceFaseEntrata(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.incomephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.incomephase, null, QHS.CmpEq("nphase", codice), null, true);			
		}

		void AddVoceCreditore(object codice){
			if (codice==DBNull.Value) return;
			if (DS.registry.Select(QHC.CmpEq("idreg",codice)).Length>0)return;
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.registry, null, QHS.CmpEq("idreg", codice), null, true);			
		}

        void AddVoceResponsabile(object codice) {
            if (codice == DBNull.Value) return;
            if (DS.manager.Select(QHC.CmpEq("idman", codice)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.manager,null,QHS.CmpEq("idman", codice),null,true);			
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
			//			int fasespesacont= CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("persspesa",
			//				"(esercizio='"+Conn.sys["esercizio"].ToString()+"')",
			//				"fasespesa"));
			//			int faseivaspesa = CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("persiva",
			//				"(esercizio='"+Conn.sys["esercizio"].ToString()+"')",
			//				"fasespesa"));
			int faseivaentrata = CfgFn.GetNoNullInt32(Meta.GetSys("invoiceincomephase"));
			//CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("invoicesetup", 
			//			"(ayear='"+Meta.GetSys("esercizio").ToString()+"')", "faseentrata"));

			//DataRow []BilEnt = DS.incomephase.Select("(flagfinance='S')");
			//int fasebilent = Convert.ToInt32(BilEnt[0]["codicefase"]);
			int fasebilent = Convert.ToInt32(Meta.GetSys("incomefinphase"));


			if (Mov.Table.TableName == "expense"){
				int fase= CfgFn.GetNoNullInt32( Mov["nphase"]);

                filter = QHS.CmpEq("idexp", Mov["idexp"]);

                if (fase == fasespesacont)
					AddVociFiglieWhereEmpty(DS.expensemandate,filter);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensepayroll,filter);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensecasualcontract,filter);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expenseprofservice,filter);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expensewageaddition,filter);
                if (fase == fasespesacont )
					AddVociFiglieWhereEmpty(DS.expenseitineration,filter);
                if (fase == faseivaspesa )
					AddVociFiglieWhereEmpty(DS.expenseinvoice,filter);
				
				AddVociFiglieWhereEmpty(DS.expensevar,filter);
				AddVociFiglieWhereEmpty(DS.expenseyear,filter);
			}
			else {
                int fase = CfgFn.GetNoNullInt32(Mov["nphase"]);
                filter = QHS.CmpEq("idinc", Mov["idinc"]);

				AddVociFiglieWhereEmpty(DS.incomevar,filter);
				AddVociFiglieWhereEmpty(DS.incomeyear,filter);

                if (fase == faseivaentrata )
					AddVociFiglieWhereEmpty(DS.incomeinvoice,filter);
			}
		}

		void AddAllCollegate(DataRow R){
			DS.expense.Clear();
			DS.income.Clear();
			DS.expensemandate.Clear();
			DS.expenseitineration.Clear();
			DS.expensepayroll.Clear();
			DS.expensecasualcontract.Clear();
			DS.expenseprofservice.Clear();
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
				filter= QHS.CmpEq("idexp",R["idexp"]);
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
            string MyFilter ="";
            if(cmbFaseSpesa.SelectedValue !=null && cmbFaseSpesa.SelectedIndex>=0) {
                object codicefase = cmbFaseSpesa.SelectedValue;
                MyFilter = QHS.CmpEq("nphase", codicefase);
            }
            MyFilter= QHS.AppAnd(MyFilter, QHS.CmpEq("ayear",Meta.GetSys("esercizio")));

			if(txtEsercizioMovimento.Text.Trim() != "")
                MyFilter  = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim()));

			if((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim()!=""))
                MyFilter  = QHS.AppAnd(MyFilter,  QHS.CmpEq("nmov", txtNumeroMovimento.Text.Trim()));

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

					
			//txtCredDeb.Text = MyDR["denominazione"].ToString();		
            HelpForm.SetComboBoxValue(cmbFaseSpesa, MyDR["nphase"]);
            txtEsercizioMovimento.Text = MyDR["ymov"].ToString();
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
			DS.expenseitineration.Clear();
			DS.expensemandate.Clear();
			DS.expenseinvoice.Clear();
			DS.expensepayroll.Clear();
			DS.expenseprofservice.Clear();
			DS.expensecasualcontract.Clear();
			DS.expensewageaddition.Clear();
            string filterexp = QHS.CmpEq("idexp", MyDR["idexp"]);
            int nfase = CfgFn.GetNoNullInt32(MyDR["nphase"]);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensemandate, null, filterexp, null, true);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseitineration, null, filterexp, null, true);
            if (nfase == faseivaspesa)
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseinvoice, null, filterexp, null, true);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensepayroll, null, filterexp, null, true);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensecasualcontract, null, filterexp, null, true);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseprofservice, null, filterexp, null, true);
            if (nfase == fasespesacont )
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensewageaddition, null, filterexp, null, true);


			currcont=DeduciTipoContabilizzazione();
			if (currcont==tipocont.cont_none) {
				txtTipoCont.Text="";
				txtCausale.Text="";
				gboxDocumento.Visible=false;
				return;
			}

			string MSG;
			MSG = "Il movimento di spesa "+txtEsercizioMovimento.Text+"/"+txtNumeroMovimento.Text+
				" sar‡ scollegato ";
			gboxDocumento.Visible=true;
			string decodedtipomov="";
			int tipomov=0;
			switch(currcont){
				case tipocont.cont_missione: 
					txtTipoCont.Text="Missione";
					labDocumento.Text="Missione";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					DataRow Mis = DS.expenseitineration.Rows[0];
                    txtNumDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                        QHS.CmpEq("iditineration", Mis["iditineration"]), "nitineration")).ToString();
                    txtEsercDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                        QHS.CmpEq("iditineration", Mis["iditineration"]), "yitineration")).ToString();

					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=false;
					tipomov = CfgFn.GetNoNullInt32( Mis["movkind"]);
					if (tipomov==5)decodedtipomov="Anticipo della missione su partita di giro";
					if (tipomov==6)decodedtipomov="Anticipo della missione sul capitolo di spesa";
					if (tipomov==4)decodedtipomov="Pagamento o saldo della missione";
					txtCausale.Text=decodedtipomov;
					MSG+= "della missione "+txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;
				case tipocont.cont_dipendente: 
					txtTipoCont.Text="Contratto";
					labDocumento.Text="Contratto";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					DataRow Dip = DS.expensewageaddition.Rows[0];
					txtNumDoc.Text = Dip["ncon"].ToString();
					txtEsercDoc.Text= Dip["ycon"].ToString();
					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=false;
					//tipomov=Mis["tipomovimento"].ToString().ToUpper();
					//if (tipomov=="ANGIR")decodedtipomov="Anticipo della missione su partita di giro";
					//if (tipomov=="ANPAG")decodedtipomov="Anticipo della missione sul capitolo di spesa";
					//if (tipomov=="SALDO")decodedtipomov="Pagamento o saldo della missione";
                    decodedtipomov = "Pagamento di Altri Compensi";
					txtCausale.Text=decodedtipomov;
					MSG+= "del contratto "+txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;
				case tipocont.cont_occasionale: 
					txtTipoCont.Text="Prestazione";
					labDocumento.Text="Prestazione";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					DataRow Occ = DS.expensecasualcontract.Rows[0];
					txtNumDoc.Text = Occ["ncon"].ToString();
					txtEsercDoc.Text= Occ["ycon"].ToString();
					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=false;
					//tipomov=Mis["tipomovimento"].ToString().ToUpper();
					//if (tipomov=="ANGIR")decodedtipomov="Anticipo della missione su partita di giro";
					//if (tipomov=="ANPAG")decodedtipomov="Anticipo della missione sul capitolo di spesa";
					//if (tipomov=="SALDO")decodedtipomov="Pagamento o saldo della missione";
					decodedtipomov="Pagamento della prestazione occasionale";
					txtCausale.Text=decodedtipomov;
					MSG+= "della prestazione occasionale "+txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;
				case tipocont.cont_professionale: 
					txtTipoCont.Text="Contratto";
					labDocumento.Text="Contratto";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";

					DataRow Prof = DS.expenseprofservice.Rows[0];
					txtNumDoc.Text = Prof["ncon"].ToString();
					txtEsercDoc.Text= Prof["ycon"].ToString();
					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=false;
					tipomov= CfgFn.GetNoNullInt32( Prof["movkind"]);
					if (tipomov==1)decodedtipomov="Contabilizzazione importo totale contratto professionale";
					if (tipomov==3)decodedtipomov="Contabilizzazione Imponibile contratto professionale";
					if (tipomov==2)decodedtipomov="Contabilizzazione Iva contratto professionale";
					//decodedtipomov="Pagamento del contratto professionale";
					txtCausale.Text=decodedtipomov;
					MSG+= "della prestazione professionale "+txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;

				case tipocont.cont_cedolino: 
					txtTipoCont.Text="Cedolino";
					labDocumento.Text="Cedolino";
					DataRow Ced = DS.expensepayroll.Rows[0];
					labEserc.Text="Eserc";	
					labNum.Text="Num";	
					txtNumDoc.Text= CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll", 
                        QHS.CmpEq("idpayroll",Ced["idpayroll"]), "npayroll")).ToString();
					txtEsercDoc.Text= CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll",
                        QHS.CmpEq("idpayroll", Ced["idpayroll"]), "fiscalyear")).ToString();

					//txtNumDoc.Text = Mis["nummissione"].ToString();
					//txtEsercDoc.Text= Mis["esercmissione"].ToString();
					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=false;
					//tipomov=Mis["tipomovimento"].ToString().ToUpper();
					//if (tipomov=="ANGIR")decodedtipomov="Anticipo della missione su partita di giro";
					//if (tipomov=="ANPAG")decodedtipomov="Anticipo della missione sul capitolo di spesa";
					//if (tipomov=="SALDO")decodedtipomov="Pagamento o saldo della missione";
					txtCausale.Text="Saldo";
					MSG+= "dal Cedolino "+txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;

				case tipocont.cont_iva: 
					txtTipoCont.Text="Iva";
					labDocumento.Text="Iva";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";
					DataRow Iva = DS.expenseinvoice.Rows[0];
					txtNumDoc.Text = Iva["ninv"].ToString();
					txtEsercDoc.Text= Iva["yinv"].ToString();
					labelTipoDocumento.Visible=true;
					txtTipoDoc.Visible=true;
					string codicetipodoc = Iva["idinvkind"].ToString();
					DataRow[] TipoDoc= DS.invoicekind.Select(QHC.CmpEq("idinvkind",codicetipodoc));
					if (TipoDoc.Length==1){
						txtTipoDoc.Text= TipoDoc[0]["description"].ToString();
					}
							
					tipomov= CfgFn.GetNoNullInt32( Iva["movkind"]);
					if (tipomov==1)decodedtipomov="Contabilizzazione importo totale documento";
					if (tipomov==3)decodedtipomov="Contabilizzazione Imponibile documento";
					if (tipomov==2)decodedtipomov="Contabilizzazione Iva documento";
					txtCausale.Text=decodedtipomov;
					MSG+= "dalla fattura ("+txtTipoDoc.Text+") " + txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;
				case tipocont.cont_ordine: 
					txtTipoCont.Text="Contratto Passivo";
					labDocumento.Text="Contratto Passivo";
					labEserc.Text="Eserc.";
					labNum.Text="Num.";
					DataRow Ord = DS.expensemandate.Rows[0];
					txtNumDoc.Text = Ord["nman"].ToString();
					txtEsercDoc.Text= Ord["yman"].ToString();
					labelTipoDocumento.Visible=false;
					txtTipoDoc.Visible=true;
					object codiceTipoOrdine = Ord["idmankind"];
					DataRow[] TipoOrd = DS.mandatekind.Select(QHC.CmpEq("idmankind",codiceTipoOrdine));
					if (TipoOrd.Length==1){
						txtTipoDoc.Text= TipoOrd[0]["description"].ToString();
					}
					tipomov= CfgFn.GetNoNullInt32(  Ord["movkind"]);
					if (tipomov==1)decodedtipomov="Contabilizzazione Totale Contratto Passivo";
					if (tipomov==3)decodedtipomov="Contabilizzazione Imponibile Contratto Passivo";
					if (tipomov==2)decodedtipomov="Contabilizzazione Iva Contratto Passivo";
					txtCausale.Text=decodedtipomov;
					MSG+= "dal contratto passivo (" + txtTipoDoc.Text + ") " + txtEsercDoc.Text+"/"+txtNumDoc.Text+".";
					break;
			}
			labMSG.Text= MSG;

		}
		public enum tipocont {cont_none,cont_ordine,cont_missione,cont_iva,cont_cedolino,
			cont_occasionale,cont_professionale,cont_dipendente};
		public tipocont currcont;

		tipocont DeduciTipoContabilizzazione(){
			if (DS.expenseitineration.Rows.Count>0) return tipocont.cont_missione;
			if (DS.expensemandate.Rows.Count>0) return tipocont.cont_ordine;
			if (DS.expenseinvoice.Rows.Count>0) return tipocont.cont_iva;
			if (DS.expensepayroll.Rows.Count>0) return tipocont.cont_cedolino;
			if (DS.expensecasualcontract.Rows.Count>0) return tipocont.cont_occasionale;
			if (DS.expenseprofservice.Rows.Count>0) return tipocont.cont_professionale;
			if (DS.expensewageaddition.Rows.Count>0) return tipocont.cont_dipendente;
			return tipocont.cont_none;
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
			txtNumeroMovimento.Text="";
			Clear();

		}

		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}
		bool doDelete(){
			DataTable []ToDelete = new DataTable[]{
													  DS.expensemandate, 
													  DS.expenseitineration,  
													  DS.expenseinvoice,
													  DS.incomeinvoice,
													  DS.expensepayroll,
													  DS.expenseprofservice,
													  DS.expensecasualcontract,
													  DS.expensewageaddition
												  };
			foreach (DataTable T in ToDelete){
				foreach(DataRow R in T.Rows) R.Delete();
			}
			PostData Post = Meta.Get_PostData();
			Post.InitClass(DS,Conn);
			bool res= Post.DO_POST();
			if (res)MessageBox.Show("Rimozione della contabilizzazione eseguita con successo.");
			return res;
		}

		private void cmbFaseSpesa_SelectedIndexChanged(object sender, System.EventArgs e) {
			Clear();
		}
		void Clear(){
			txtNumeroMovimento.Text="";
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
			currcont=tipocont.cont_none;
			txtTipoCont.Text="";
			txtCausale.Text="";
			gboxDocumento.Visible=false;
		}

        private void label6_Click(object sender, EventArgs e) {

        }
	}
}