
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;


namespace finvardetail_single {//UnDettVarBilancio//
	/// <summary>
	/// Summary description for frmUnDettVarBilancio.
	/// </summary>
	public class Frm_finvardetail_single : MetaDataForm {
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		public System.Windows.Forms.RadioButton rdbEntrata;
		public System.Windows.Forms.RadioButton rdbSpesa;
		public dsmeta DS;
		string filteresercizio;
		private System.Windows.Forms.GroupBox grpImporto;
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.Button btnBilancio;
		MetaData Meta;
		private System.Windows.Forms.ImageList imageList1;
		bool inChiusura = false;
        CQueryHelper QHC;
        private GroupBox gBoxCard;
        private TextBox textBox4;
        private Label label9;
        private TextBox txtCard;
        private GroupBox groupBox2;
        private TextBox txtUnderwriting;
        private Button btnUnderwriting;
        private GroupBox gboxMovimento;
        private CheckBox chkCreateMov;
        private Label labelMovimentoGenerato;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox gboxPluriennale;
        private GroupBox gBoxResidui;
        private TextBox txtResidui;
        private GroupBox gboxanno1;
        private TextBox txtAnno1;
        private GroupBox gboxanno3;
        private TextBox txtAnno3;
        private GroupBox gboxanno2;
        private TextBox txtAnno2;
        private GroupBox groupBox3;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label10;
        private GroupBox gBoxPrecPrev;
        private TextBox txtPreviousPrevision;
        QueryHelper QHS;
		public Frm_finvardetail_single() {
			InitializeComponent();
		}
        bool mustshowmovimento = false;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finvardetail_single));
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gBoxCard = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnUnderwriting = new System.Windows.Forms.Button();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.labelMovimentoGenerato = new System.Windows.Forms.Label();
            this.chkCreateMov = new System.Windows.Forms.CheckBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxPluriennale = new System.Windows.Forms.GroupBox();
            this.gBoxPrecPrev = new System.Windows.Forms.GroupBox();
            this.txtPreviousPrevision = new System.Windows.Forms.TextBox();
            this.gBoxResidui = new System.Windows.Forms.GroupBox();
            this.txtResidui = new System.Windows.Forms.TextBox();
            this.gboxanno1 = new System.Windows.Forms.GroupBox();
            this.txtAnno1 = new System.Windows.Forms.TextBox();
            this.gboxanno3 = new System.Windows.Forms.GroupBox();
            this.txtAnno3 = new System.Windows.Forms.TextBox();
            this.gboxanno2 = new System.Windows.Forms.GroupBox();
            this.txtAnno2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DS = new finvardetail_single.dsmeta();
            this.grpImporto.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gBoxCard.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxPluriennale.SuspendLayout();
            this.gBoxPrecPrev.SuspendLayout();
            this.gBoxResidui.SuspendLayout();
            this.gboxanno1.SuspendLayout();
            this.gboxanno3.SuspendLayout();
            this.gboxanno2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(800, 435);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 24);
            this.btnAnnulla.TabIndex = 11;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(696, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 24);
            this.btnOK.TabIndex = 10;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 18);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "finvardetail.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(260, 134);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(301, 51);
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.Tag = "finvardetail.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(259, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rdbAumento
            // 
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(140, 12);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(94, 16);
            this.rdbAumento.TabIndex = 1;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(140, 29);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(94, 16);
            this.rdbDiminuzione.TabIndex = 2;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(5, 9);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 2;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?x";
            this.rdbEntrata.Text = "Entrata";
            this.rdbEntrata.CheckedChanged += new System.EventHandler(this.rdbEntrata_CheckedChanged);
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(77, 9);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 3;
            this.rdbSpesa.Tag = "finview.finpart:S?x";
            this.rdbSpesa.Text = "Spesa";
            this.rdbSpesa.CheckedChanged += new System.EventHandler(this.rdbSpesa_CheckedChanged);
            // 
            // grpImporto
            // 
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(8, 115);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(240, 56);
            this.grpImporto.TabIndex = 3;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "finvardetail.amount.valuesigned";
            this.grpImporto.Text = "Importo";
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Controls.Add(this.rdbEntrata);
            this.gboxBilAnnuale.Controls.Add(this.rdbSpesa);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(427, 12);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(447, 102);
            this.gboxBilAnnuale.TabIndex = 2;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(4, 24);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(155, 16);
            this.chkListTitle.TabIndex = 4;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(4, 46);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(4, 72);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(437, 20);
            this.txtCodiceBilancio.TabIndex = 5;
            this.txtCodiceBilancio.Tag = "finview.codefin?x";
            this.txtCodiceBilancio.Leave += new System.EventHandler(this.txtCodiceBilancio_Leave);
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(165, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(276, 58);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gBoxCard
            // 
            this.gBoxCard.Controls.Add(this.textBox4);
            this.gBoxCard.Controls.Add(this.label9);
            this.gBoxCard.Controls.Add(this.txtCard);
            this.gBoxCard.Location = new System.Drawing.Point(567, 115);
            this.gBoxCard.Name = "gBoxCard";
            this.gBoxCard.Size = new System.Drawing.Size(310, 72);
            this.gBoxCard.TabIndex = 9;
            this.gBoxCard.TabStop = false;
            this.gBoxCard.Tag = "";
            this.gBoxCard.Text = "Card";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(149, 14);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(155, 45);
            this.textBox4.TabIndex = 22;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "lcard.title";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(2, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Num. card";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(11, 36);
            this.txtCard.Name = "txtCard";
            this.txtCard.ReadOnly = true;
            this.txtCard.Size = new System.Drawing.Size(120, 20);
            this.txtCard.TabIndex = 3;
            this.txtCard.Tag = "lcard.idlcard";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUnderwriting);
            this.groupBox2.Controls.Add(this.btnUnderwriting);
            this.groupBox2.Location = new System.Drawing.Point(8, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(553, 43);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(121, 16);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(424, 20);
            this.txtUnderwriting.TabIndex = 2;
            this.txtUnderwriting.Tag = "underwriting.title?finvardetailview.underwriting";
            // 
            // btnUnderwriting
            // 
            this.btnUnderwriting.Location = new System.Drawing.Point(9, 14);
            this.btnUnderwriting.Name = "btnUnderwriting";
            this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
            this.btnUnderwriting.TabIndex = 0;
            this.btnUnderwriting.TabStop = false;
            this.btnUnderwriting.Tag = "choose.underwriting.default";
            this.btnUnderwriting.Text = "Finanziamento";
            this.btnUnderwriting.UseVisualStyleBackColor = true;
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.labelMovimentoGenerato);
            this.gboxMovimento.Controls.Add(this.chkCreateMov);
            this.gboxMovimento.Location = new System.Drawing.Point(567, 193);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(310, 69);
            this.gboxMovimento.TabIndex = 7;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            this.gboxMovimento.Text = "Richiesta generazione movimento";
            // 
            // labelMovimentoGenerato
            // 
            this.labelMovimentoGenerato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMovimentoGenerato.Location = new System.Drawing.Point(8, 41);
            this.labelMovimentoGenerato.Name = "labelMovimentoGenerato";
            this.labelMovimentoGenerato.Size = new System.Drawing.Size(294, 20);
            this.labelMovimentoGenerato.TabIndex = 1;
            this.labelMovimentoGenerato.Text = "Generato movimento";
            // 
            // chkCreateMov
            // 
            this.chkCreateMov.Location = new System.Drawing.Point(6, 13);
            this.chkCreateMov.Name = "chkCreateMov";
            this.chkCreateMov.Size = new System.Drawing.Size(176, 27);
            this.chkCreateMov.TabIndex = 0;
            this.chkCreateMov.Tag = "finvardetail.createexpense:S:N";
            this.chkCreateMov.Text = "Richiedi movimento";
            this.chkCreateMov.UseVisualStyleBackColor = true;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 10);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(413, 104);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(396, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(229, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxPluriennale
            // 
            this.gboxPluriennale.Controls.Add(this.gBoxPrecPrev);
            this.gboxPluriennale.Controls.Add(this.gBoxResidui);
            this.gboxPluriennale.Controls.Add(this.gboxanno1);
            this.gboxPluriennale.Controls.Add(this.gboxanno3);
            this.gboxPluriennale.Controls.Add(this.gboxanno2);
            this.gboxPluriennale.Location = new System.Drawing.Point(3, 267);
            this.gboxPluriennale.Name = "gboxPluriennale";
            this.gboxPluriennale.Size = new System.Drawing.Size(874, 58);
            this.gboxPluriennale.TabIndex = 8;
            this.gboxPluriennale.TabStop = false;
            this.gboxPluriennale.Text = "Informazioni utili ai fini della redazione del bilancio di previsione";
            // 
            // gBoxPrecPrev
            // 
            this.gBoxPrecPrev.Controls.Add(this.txtPreviousPrevision);
            this.gBoxPrecPrev.Location = new System.Drawing.Point(669, 13);
            this.gBoxPrecPrev.Name = "gBoxPrecPrev";
            this.gBoxPrecPrev.Size = new System.Drawing.Size(199, 39);
            this.gBoxPrecPrev.TabIndex = 10;
            this.gBoxPrecPrev.TabStop = false;
            this.gBoxPrecPrev.Text = "Previsione anno precedente";
            // 
            // txtPreviousPrevision
            // 
            this.txtPreviousPrevision.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPreviousPrevision.Location = new System.Drawing.Point(6, 13);
            this.txtPreviousPrevision.Name = "txtPreviousPrevision";
            this.txtPreviousPrevision.Size = new System.Drawing.Size(187, 20);
            this.txtPreviousPrevision.TabIndex = 2;
            this.txtPreviousPrevision.Tag = "finvardetail.previousprevision";
            // 
            // gBoxResidui
            // 
            this.gBoxResidui.Controls.Add(this.txtResidui);
            this.gBoxResidui.Location = new System.Drawing.Point(403, 15);
            this.gBoxResidui.Name = "gBoxResidui";
            this.gBoxResidui.Size = new System.Drawing.Size(147, 39);
            this.gBoxResidui.TabIndex = 9;
            this.gBoxResidui.TabStop = false;
            this.gBoxResidui.Text = "Residui presunti";
            // 
            // txtResidui
            // 
            this.txtResidui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResidui.Location = new System.Drawing.Point(6, 13);
            this.txtResidui.Name = "txtResidui";
            this.txtResidui.Size = new System.Drawing.Size(135, 20);
            this.txtResidui.TabIndex = 2;
            this.txtResidui.Tag = "finvardetail.residual";
            // 
            // gboxanno1
            // 
            this.gboxanno1.Controls.Add(this.txtAnno1);
            this.gboxanno1.Location = new System.Drawing.Point(9, 15);
            this.gboxanno1.Name = "gboxanno1";
            this.gboxanno1.Size = new System.Drawing.Size(114, 39);
            this.gboxanno1.TabIndex = 6;
            this.gboxanno1.TabStop = false;
            this.gboxanno1.Tag = "finvardetail.amount";
            this.gboxanno1.Text = "Previsione";
            // 
            // txtAnno1
            // 
            this.txtAnno1.Location = new System.Drawing.Point(5, 13);
            this.txtAnno1.Name = "txtAnno1";
            this.txtAnno1.Size = new System.Drawing.Size(100, 20);
            this.txtAnno1.TabIndex = 1;
            this.txtAnno1.Tag = "finvardetail.amount";
            // 
            // gboxanno3
            // 
            this.gboxanno3.Controls.Add(this.txtAnno3);
            this.gboxanno3.Location = new System.Drawing.Point(249, 15);
            this.gboxanno3.Name = "gboxanno3";
            this.gboxanno3.Size = new System.Drawing.Size(114, 39);
            this.gboxanno3.TabIndex = 8;
            this.gboxanno3.TabStop = false;
            this.gboxanno3.Tag = "finvardetail.prevision3";
            this.gboxanno3.Text = "Previsione";
            // 
            // txtAnno3
            // 
            this.txtAnno3.Location = new System.Drawing.Point(8, 13);
            this.txtAnno3.Name = "txtAnno3";
            this.txtAnno3.Size = new System.Drawing.Size(100, 20);
            this.txtAnno3.TabIndex = 1;
            this.txtAnno3.Tag = "finvardetail.prevision3";
            // 
            // gboxanno2
            // 
            this.gboxanno2.Controls.Add(this.txtAnno2);
            this.gboxanno2.Location = new System.Drawing.Point(129, 15);
            this.gboxanno2.Name = "gboxanno2";
            this.gboxanno2.Size = new System.Drawing.Size(114, 39);
            this.gboxanno2.TabIndex = 7;
            this.gboxanno2.TabStop = false;
            this.gboxanno2.Tag = "finvardetail.prevision2";
            this.gboxanno2.Text = "Previsione";
            // 
            // txtAnno2
            // 
            this.txtAnno2.Location = new System.Drawing.Point(8, 13);
            this.txtAnno2.Name = "txtAnno2";
            this.txtAnno2.Size = new System.Drawing.Size(100, 20);
            this.txtAnno2.TabIndex = 1;
            this.txtAnno2.Tag = "finvardetail.prevision2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(3, 331);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(874, 96);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gestione interfaccia web";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(258, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Annotazioni";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 37);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.TabStop = false;
            this.textBox3.Tag = "finvardetail.limit";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(331, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(533, 74);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "finvardetail.annotation";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(243, 18);
            this.label10.TabIndex = 50;
            this.label10.Text = "Limite da imporre per il valore di questo dettaglio";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_finvardetail_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(886, 469);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gboxPluriennale);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.grpImporto);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gboxMovimento);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gBoxCard);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_finvardetail_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gBoxCard.ResumeLayout(false);
            this.gBoxCard.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxPluriennale.ResumeLayout(false);
            this.gBoxPrecPrev.ResumeLayout(false);
            this.gBoxPrecPrev.PerformLayout();
            this.gBoxResidui.ResumeLayout(false);
            this.gBoxResidui.PerformLayout();
            this.gboxanno1.ResumeLayout(false);
            this.gboxanno1.PerformLayout();
            this.gboxanno3.ResumeLayout(false);
            this.gboxanno3.PerformLayout();
            this.gboxanno2.ResumeLayout(false);
            this.gboxanno2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "upb") {
                object idupb = "0001";
				if (R!=null)
						idupb= R["idupb"];
				MetaData.AutoInfo AI;
				AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
				string filter=QHS.CmpEq("idupb", idupb);
				if (AI!=null) AI.startfilter=filter;
				DS.finview.ExtendedProperties[MetaData.ExtraParams]= filter;
				SetFilterFinView();
							
			}
            // di qui non passa comunque mai
            //if (T.TableName == "fin") {
            //    object idupb = "";// "0001";
            //    if (R != null)
            //        idupb = R["idupb"];
            //    MetaData.AutoInfo AI;
            //    AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
            //    string filter = QHS.CmpEq("idupb", idupb);
            //    if (AI != null) AI.startfilter = filter;
            //    DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            //    SetFilterFinView();

            //}
			
		}

        int varkind = 0;
        bool isprev_iniziale() {
            return (varkind == 5);
        }

        void MakeSpaceFrom(GroupBox G) {
            Form F = G.FindForm();
            int disp = G.Height;
            int y0 = G.Location.Y;
            F.SuspendLayout();
            foreach (Control C in F.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            F.Size = new Size(F.Size.Width, F.Size.Height - disp);
            F.ResumeLayout();

        }


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            //GetData.SetStaticFilter(DS.finview,filteresercizio);
            SetFilterFinView();

            DataRow rFinvardetail = Meta.SourceRow;
            DataRow rFinvar = rFinvardetail.GetParentRow("finvarfinvardetail");
            varkind = CfgFn.GetNoNullInt32(rFinvar["variationkind"]);

            if (isprev_iniziale()) {
                grpImporto.Visible = false;
                gboxPluriennale.Visible = true;
                rdbAumento.Tag = "";
                rdbDiminuzione.Tag = "";
                txtImporto.Tag = "";
                grpImporto.Tag = "";
                gBoxCard.Visible = false;

                txtAnno1.Tag = "finvardetail.amount";
                txtAnno2.Tag = "finvardetail.prevision2";
                txtAnno3.Tag = "finvardetail.prevision3";
                txtResidui.Tag = "finvardetail.residual";
                txtPreviousPrevision.Tag = "finvardetail.previousprevision";

                int anno = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
                int annosucc1 = anno + 1;
                int annosucc2 = anno + 2;

                gboxanno1.Text = anno.ToString();
                gboxanno2.Text = annosucc1.ToString();
                gboxanno3.Text = annosucc2.ToString();
                mustshowmovimento = true;

                if (rFinvardetail["idexp"].ToString() == "") {
                    labelMovimentoGenerato.Visible = false;
                    chkCreateMov.Visible = true;
                    
                    HelpForm.SetDenyNull(DS.Tables["finvardetail"].Columns["createexpense"], true);
                }
                else {
                    chkCreateMov.Visible = false;
                    labelMovimentoGenerato.Visible = true;
                }
            }
            else {
                grpImporto.Visible = true;
                gboxPluriennale.Visible = false;
                gboxMovimento.Visible = false;
                txtAnno1.Tag = "";
                txtAnno2.Tag = "";
                txtAnno3.Tag = "";
                txtResidui.Tag = "";
                txtPreviousPrevision.Tag = "";
                gboxanno1.Text = "";
                gboxanno2.Text = "";
                gboxanno3.Text = "";
                gBoxResidui.Text = "";
                gBoxPrecPrev.Text = "";
                //MakeSpaceFrom(gboxPluriennale);
                //MakeSpaceFrom(gboxMovimento);
                txtDescrizione.Focus();
            }

            if (rFinvar.RowState == DataRowState.Modified){
                int CurrentStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus"]);
                int OriginalStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus", DataRowVersion.Original]);
                if ((OriginalStatus == 5) || ((CurrentStatus == 5) && (rFinvar.RowState == DataRowState.Modified))){
                    txtDescrizione.Focus();
                }
            }

            


        }

		public void MetaData_AfterClear(){
			SetFilterFinView();
		}

		public void MetaData_AfterFill(){
            DataRow rFinvardetail = Meta.SourceRow;
            DataRow rFinvar = rFinvardetail.GetParentRow("finvarfinvardetail");

            if (mustshowmovimento && rdbSpesa.Checked) {
                gboxMovimento.Visible = true;
            }
            else {
                gboxMovimento.Visible = false;
                chkCreateMov.Checked = false;
            }

            // 5 = Approvata
            if (Meta.InsertMode){
                rdbEntrata.Enabled = true;
                rdbSpesa.Enabled = true;
                chkListTitle.Enabled = true;
                btnUnderwriting.Enabled = true;
                txtUnderwriting.ReadOnly = false;
                btnBilancio.Enabled = true;
                btnBilancio.TabStop = true;
                txtCodiceBilancio.ReadOnly = false;
                btnUPBCode.Enabled = true;
                txtUPB.ReadOnly= false;
            }
            else{
                int CurrentStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus"]);
                int OriginalStatus = CfgFn.GetNoNullInt32(rFinvar["idfinvarstatus", DataRowVersion.Original]);
                if ((OriginalStatus == 5)  ||  ((CurrentStatus == 5) && (rFinvar.RowState == DataRowState.Modified))){
                    rdbEntrata.Enabled = false;
                    rdbSpesa.Enabled = false;
                    chkListTitle.Enabled = false;
                    btnUnderwriting.Enabled = false;
                    btnBilancio.Enabled = false;
                    btnBilancio.TabStop = false;
                    txtCodiceBilancio.ReadOnly = true;
                    txtCodiceBilancio.TabStop = false;
                    txtUnderwriting.ReadOnly = true;
                    btnUPBCode.Enabled = false;
                    txtUPB.TabStop = false;
                    txtUPB.ReadOnly= true;
                }
                else{
                    rdbEntrata.Enabled = true;
                    rdbSpesa.Enabled = true;
                    chkListTitle.Enabled = true;
                    btnUnderwriting.Enabled = true;
                    btnBilancio.Enabled = true;
                    btnBilancio.TabStop = true;
                    txtCodiceBilancio.ReadOnly = false;
                    txtUnderwriting.ReadOnly = false;
                    btnUPBCode.Enabled = true;
                    txtUPB.ReadOnly = false;
                    txtUPB.TabStop = true;
                    
                }
            }


            labelMovimentoGenerato.Text = "";
            if (DS.expenseview.Rows.Count == 1 ) {
                DataRow E = DS.expenseview.Rows[0];
                string lab = E["phase"].ToString() + " n." + E["nmov"].ToString();
                labelMovimentoGenerato.Text = "Generato movimento: " + lab;
            }

           
			SetFilterFinView();
            EnableDisableAmount();
		}

        private void EnableDisableAmount(){
            DataRow Curr = DS.finvardetail.Rows[0];
            if (Curr["idlcard"] != DBNull.Value){
                grpImporto.Enabled = false;
            }
            else{
                grpImporto.Enabled = true;
            }


        }
		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string filteridfin="";
            //if (rdbSpesa.Checked)
            //    filteridfin= "(idfin like '"+esercizio.ToString().Substring(2)+"S%')";
            //if (rdbEntrata.Checked)
            //    filteridfin= "(idfin like '"+esercizio.ToString().Substring(2)+"E%')";

            if (rdbSpesa.Checked)
                filteridfin =QHS.AppAnd(QHS.CmpEq("ayear",esercizio),QHS.BitSet("flag",0));
            if (rdbEntrata.Checked)
                filteridfin =QHS.AppAnd(QHS.CmpEq("ayear",esercizio),QHS.BitClear("flag",0));

            //Il filtro sull'UPB c'è sempre
            object idupb = Meta.GetAutoField(txtUPB);
			if (idupb!=DBNull.Value) {
				filter=QHS.CmpEq("idupb", idupb);
			}
			else {
				filter=QHS.CmpEq("idupb", "0001");
			}
            filter = QHS.AppAnd(filteridfin, filter);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                esercizio + "'))";

			if (chkListTitle.Checked) {
				FrmAskDescr FR= new FrmAskDescr(0);
				createForm(FR, this);
				DialogResult D = FR.ShowDialog(this);
				if (D!= DialogResult.OK) return;
				filter = GetData.MergeFilters(filter,
					"(title like "+QueryCreator.quotedstrvalue(
					"%"+FR.txtDescrizione.Text+"%",true))+")";
				filter= GetData.MergeFilters(filter,filteroperativo);
				MetaData.DoMainCommand(this,"choose.finview.default."+filter);
				return;
			}

			DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			if (rdbSpesa.Checked)
				MetaData.DoMainCommand(this,"manage.finview.treesupb");
			if (rdbEntrata.Checked)
				MetaData.DoMainCommand(this,"manage.finview.treeeupb");

		}

		private void txtCodiceBilancio_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
            if ((Meta.EditMode)&& txtCodiceBilancio.ReadOnly) return;
            if (!Meta.formController.formInited) {
                Meta.LogError("txtCodiceBilancio_Leave di finvardetail_single chiamata su form not inited");
                return;
            }
            if (Meta.IsEmpty) return;
			DataRow Curr = DS.finvardetail.Rows[0];
			if (txtCodiceBilancio.Text.Trim()=="") {
				SvuotaFinView();
				Curr["idfin"] = 0;
				return;
			}

			string finpart = "";
			if (rdbSpesa.Checked) {
				finpart = "S";
			}
			if (rdbEntrata.Checked) {
				finpart = "E";
			}
			if (finpart == "") return;

            string filterUpb = "";
            object idupb = Meta.GetAutoField(txtUPB);
			if (idupb!=DBNull.Value) {
				filterUpb = QHS.CmpEq("idupb", idupb);
			}
			else {
				filterUpb = QHS.CmpEq("idupb","0001");
			}

			string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                QHS.CmpEq("finpart", finpart), filterUpb);
			MetaData MetaBilancio = MetaData.GetMetaData(this,"finview");
			MetaBilancio.FilterLocked = true;
			MetaBilancio.SearchEnabled = false;
			MetaBilancio.MainSelectionEnabled = true;
			MetaBilancio.StartFilter = filtro;
			MetaBilancio.ExtraParameter = filtro;
			MetaBilancio.startFieldWanted = "codefin";
			MetaBilancio.startValueWanted = null;

			MetaBilancio.startValueWanted = txtCodiceBilancio.Text.Trim();
			string startfield = MetaBilancio.startFieldWanted;
			string startvalue = MetaBilancio.startValueWanted;
			DataRow rFin = null;
			if (startvalue != null) {
				//try to load a row directly, without opening a new form		
				string stripped=startvalue;
				if (stripped.EndsWith("%")) stripped=stripped.TrimEnd(new Char[] {'%'});

                string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                    esercizio + "'))";

                string filter2 = GetData.MergeFilters(filtro,"("+startfield+"='"+stripped+"')");
                filter2 = GetData.MergeFilters(filter2, filteroperativo);
                 
                rFin = MetaBilancio.SelectByCondition(filter2, "finview");
			}

			if (rFin == null) {
				string edittype = "tree" + finpart.ToLower() + "upb";
				bool res = MetaBilancio.Edit(this, edittype, true);
				if (!res) {
					SvuotaFinView();
					Curr["idfin"] = 0;
					return;
				}
				rFin = MetaBilancio.LastSelectedRow;
			}
			Curr["idfin"] = rFin["idfin"];
			if (rFin!=null) {
				SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("idupb", rFin["idupb"]), QHS.CmpEq("ayear", rFin["ayear"]));
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.finview,null,filter,null,false);
			}
			Meta.FreshForm(gboxBilAnnuale.Controls,true,"finview");
		}

		private void SvuotaFinView() {
			txtDenominazioneBilancio.Text =  "";
			txtCodiceBilancio.Text = "";
			DS.finview.Clear();
		}

		private void SetFilterFinView() {
			string filter;
            object idupb = Meta.GetAutoField(txtUPB);
            if (idupb == null) idupb = DBNull.Value;

			if (idupb!=DBNull.Value) {
                filter = QHS.CmpEq("idupb", idupb);
			}
			else {
                filter = QHS.CmpEq("idupb", "0001");
			}
			GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, filter));
		}

        private void rdbSpesa_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CheckFin();
            if (mustshowmovimento && rdbSpesa.Checked) {
                gboxMovimento.Visible = true;
            }
            else {
                gboxMovimento.Visible = false;
                chkCreateMov.Checked = false;
            }
        }

        private void rdbEntrata_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CheckFin();
            if (mustshowmovimento && rdbSpesa.Checked) {
                gboxMovimento.Visible = true;
            }
            else {
                gboxMovimento.Visible = false;
                chkCreateMov.Checked = false;
            }
        }

        void CheckFin() {
            if (DS.finview.Rows.Count == 0) return;
            if (txtCodiceBilancio.Text == "") return;
            DataRow F = DS.finview.Rows[0];
            string E_S = F["finpart"].ToString().ToUpper();

            if (rdbSpesa.Checked && E_S == "S") return;
            if (rdbEntrata.Checked && E_S == "E") return;

            DS.finview.Clear();
            txtCodiceBilancio.Text = "";
            txtDenominazioneBilancio.Text = "";

            DataRow Curr = DS.finvardetail.Rows[0];
            Curr["idfin"] = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }
	}
}
