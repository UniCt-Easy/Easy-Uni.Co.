
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using ep_functions;
using q= metadatalibrary.MetaExpression;

namespace epexp_default {
	/// <summary>
	/// Summary description for Frm_epexp_default.
	/// </summary>
	public class Frm_epexp_default : MetaDataForm {

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox gBoxImporti;
		public TextBox SubEntity_txtAnno1;
		private System.Windows.Forms.GroupBox gboxClienteFornitore;
		private System.Windows.Forms.TextBox txtClienteFornitore;
		private System.Windows.Forms.GroupBox gboxConto;
		private System.Windows.Forms.TextBox txtDenominazioneConto;
		private System.Windows.Forms.TextBox txtCodiceConto;
		private System.Windows.Forms.Button btnAccount;
		public epexp_default.dsmeta DS;
		public MetaData Meta;
		
		private System.Windows.Forms.TabPage tabVariazioni;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnInsertVar;
		private System.Windows.Forms.Button btnEditVar;
		private System.Windows.Forms.Button btnDeleteVar;
		private System.Windows.Forms.DataGrid GridVariazioni;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TabPage tabPrincipale;
		private GroupBox gboxUPB;
		public TextBox txtUPB;
		private TextBox txtDescrUPB;
		private Button btnUPBCode;
		public Label labAnno1;
		public Label labAnno5;
		public TextBox SubEntity_txtAnno5;
		public Label labAnno4;
		public TextBox SubEntity_txtAnno4;
		public Label labAnno3;
		public TextBox SubEntity_txtAnno3;
		public Label labAnno2;
		public TextBox SubEntity_txtAnno2;
		public TextBox txtImpCorr5;
		public TextBox txtImpCorr4;
		public TextBox txtImpCorr3;
		public TextBox txtImpCorr2;
		public TextBox txtImpCorr;
		public TextBox txtTotaleCorr;
		public TextBox txtTotale;
		private Label label8;
		private GroupBox gboxFasePrec;
		private Label label9;
		private TextBox txtNprec;
		private TextBox txtYprec;
		private Label label11;
		private Button btnFasePrec;
		private GroupBox grpFasi;
		private RadioButton radImpegno;
		private RadioButton radPreimpegno;
		private GroupBox gboxResponsabile;
		public TextBox txtResponsabile;
		private TabPage tabClassificazioni;
		private DataGrid dgrClassificazioni;
		private Button btnIndElimina;
		private Button btnIndModifica;
		private Button btnIndInserisci;
		private Button btnGeneraImpegnoBudget;
		private CheckBox chkFlagVariazione;
		private Label labdisponibile;
		public TextBox txtTotaleDisp;
		public TextBox txtCurrDisp5;
		public TextBox txtCurrDisp4;
		public TextBox txtCurrDisp3;
		public TextBox txtCurrDisp2;
		public TextBox txtCurrDisp;
		private Label label13;
		private Label label12;
		private Button btnEditDocument;
		private GroupBox gBoxCausale;
		private TextBox txtDescrCausale;
		private TextBox txtCodiceCausale;
		private Button btnSpalmaPrevisioni;
		public TextBox textBox3;
		private Label label7;
		private Button btnCausale;

		public Frm_epexp_default() {
			InitializeComponent();

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			InChiusura = true;
			if (disposing) {

			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnSpalmaPrevisioni = new System.Windows.Forms.Button();
			this.gBoxCausale = new System.Windows.Forms.GroupBox();
			this.txtDescrCausale = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.btnCausale = new System.Windows.Forms.Button();
			this.btnEditDocument = new System.Windows.Forms.Button();
			this.chkFlagVariazione = new System.Windows.Forms.CheckBox();
			this.btnGeneraImpegnoBudget = new System.Windows.Forms.Button();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.gboxFasePrec = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNprec = new System.Windows.Forms.TextBox();
			this.txtYprec = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnFasePrec = new System.Windows.Forms.Button();
			this.grpFasi = new System.Windows.Forms.GroupBox();
			this.radImpegno = new System.Windows.Forms.RadioButton();
			this.radPreimpegno = new System.Windows.Forms.RadioButton();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.TextBox();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.gBoxImporti = new System.Windows.Forms.GroupBox();
			this.labdisponibile = new System.Windows.Forms.Label();
			this.txtTotaleDisp = new System.Windows.Forms.TextBox();
			this.txtCurrDisp5 = new System.Windows.Forms.TextBox();
			this.txtCurrDisp4 = new System.Windows.Forms.TextBox();
			this.txtCurrDisp3 = new System.Windows.Forms.TextBox();
			this.txtCurrDisp2 = new System.Windows.Forms.TextBox();
			this.txtCurrDisp = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtTotaleCorr = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.labAnno5 = new System.Windows.Forms.Label();
			this.txtImpCorr5 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtImpCorr4 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAnno5 = new System.Windows.Forms.TextBox();
			this.labAnno4 = new System.Windows.Forms.Label();
			this.txtImpCorr3 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAnno4 = new System.Windows.Forms.TextBox();
			this.labAnno3 = new System.Windows.Forms.Label();
			this.txtImpCorr2 = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAnno3 = new System.Windows.Forms.TextBox();
			this.labAnno2 = new System.Windows.Forms.Label();
			this.txtImpCorr = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAnno2 = new System.Windows.Forms.TextBox();
			this.labAnno1 = new System.Windows.Forms.Label();
			this.SubEntity_txtAnno1 = new System.Windows.Forms.TextBox();
			this.gboxClienteFornitore = new System.Windows.Forms.GroupBox();
			this.txtClienteFornitore = new System.Windows.Forms.TextBox();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.btnAccount = new System.Windows.Forms.Button();
			this.tabClassificazioni = new System.Windows.Forms.TabPage();
			this.dgrClassificazioni = new System.Windows.Forms.DataGrid();
			this.btnIndElimina = new System.Windows.Forms.Button();
			this.btnIndModifica = new System.Windows.Forms.Button();
			this.btnIndInserisci = new System.Windows.Forms.Button();
			this.tabVariazioni = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnDeleteVar = new System.Windows.Forms.Button();
			this.btnEditVar = new System.Windows.Forms.Button();
			this.btnInsertVar = new System.Windows.Forms.Button();
			this.GridVariazioni = new System.Windows.Forms.DataGrid();
			this.DS = new epexp_default.dsmeta();
			this.tabControl1.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.gBoxCausale.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.gboxFasePrec.SuspendLayout();
			this.grpFasi.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gBoxImporti.SuspendLayout();
			this.gboxClienteFornitore.SuspendLayout();
			this.gboxConto.SuspendLayout();
			this.tabClassificazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).BeginInit();
			this.tabVariazioni.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GridVariazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabClassificazioni);
			this.tabControl1.Controls.Add(this.tabVariazioni);
			this.tabControl1.Location = new System.Drawing.Point(8, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(896, 528);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.textBox3);
			this.tabPrincipale.Controls.Add(this.label7);
			this.tabPrincipale.Controls.Add(this.btnSpalmaPrevisioni);
			this.tabPrincipale.Controls.Add(this.gBoxCausale);
			this.tabPrincipale.Controls.Add(this.btnEditDocument);
			this.tabPrincipale.Controls.Add(this.chkFlagVariazione);
			this.tabPrincipale.Controls.Add(this.btnGeneraImpegnoBudget);
			this.tabPrincipale.Controls.Add(this.gboxResponsabile);
			this.tabPrincipale.Controls.Add(this.gboxFasePrec);
			this.tabPrincipale.Controls.Add(this.grpFasi);
			this.tabPrincipale.Controls.Add(this.gboxUPB);
			this.tabPrincipale.Controls.Add(this.groupBox19);
			this.tabPrincipale.Controls.Add(this.groupBox1);
			this.tabPrincipale.Controls.Add(this.label6);
			this.tabPrincipale.Controls.Add(this.txtNumero);
			this.tabPrincipale.Controls.Add(this.txtEsercizio);
			this.tabPrincipale.Controls.Add(this.txtDescrizione);
			this.tabPrincipale.Controls.Add(this.txtDataContabile);
			this.tabPrincipale.Controls.Add(this.label1);
			this.tabPrincipale.Controls.Add(this.label2);
			this.tabPrincipale.Controls.Add(this.label5);
			this.tabPrincipale.Controls.Add(this.gBoxImporti);
			this.tabPrincipale.Controls.Add(this.gboxClienteFornitore);
			this.tabPrincipale.Controls.Add(this.gboxConto);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(888, 502);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(769, 221);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(104, 20);
			this.textBox3.TabIndex = 78;
			this.textBox3.Tag = "epexpview.totaldebit";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(692, 223);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(59, 13);
			this.label7.TabIndex = 77;
			this.label7.Text = "Debiti totali";
			// 
			// btnSpalmaPrevisioni
			// 
			this.btnSpalmaPrevisioni.Location = new System.Drawing.Point(501, 219);
			this.btnSpalmaPrevisioni.Name = "btnSpalmaPrevisioni";
			this.btnSpalmaPrevisioni.Size = new System.Drawing.Size(173, 23);
			this.btnSpalmaPrevisioni.TabIndex = 76;
			this.btnSpalmaPrevisioni.Text = "Ripartisci importo pluriennale";
			this.btnSpalmaPrevisioni.UseVisualStyleBackColor = true;
			this.btnSpalmaPrevisioni.Click += new System.EventHandler(this.btnSpalmaPrevisioni_Click);
			// 
			// gBoxCausale
			// 
			this.gBoxCausale.Controls.Add(this.txtDescrCausale);
			this.gBoxCausale.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausale.Controls.Add(this.btnCausale);
			this.gBoxCausale.Location = new System.Drawing.Point(580, 378);
			this.gBoxCausale.Name = "gBoxCausale";
			this.gBoxCausale.Size = new System.Drawing.Size(297, 118);
			this.gBoxCausale.TabIndex = 34;
			this.gBoxCausale.TabStop = false;
			this.gBoxCausale.Tag = "AutoManage.txtCodiceCausale.tree";
			// 
			// txtDescrCausale
			// 
			this.txtDescrCausale.Location = new System.Drawing.Point(120, 12);
			this.txtDescrCausale.Multiline = true;
			this.txtDescrCausale.Name = "txtDescrCausale";
			this.txtDescrCausale.ReadOnly = true;
			this.txtDescrCausale.Size = new System.Drawing.Size(171, 72);
			this.txtDescrCausale.TabIndex = 2;
			this.txtDescrCausale.TabStop = false;
			this.txtDescrCausale.Tag = "accmotive.title";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(7, 90);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(284, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotive.codemotive?epexpview.codemotive";
			// 
			// btnCausale
			// 
			this.btnCausale.Location = new System.Drawing.Point(8, 60);
			this.btnCausale.Name = "btnCausale";
			this.btnCausale.Size = new System.Drawing.Size(104, 23);
			this.btnCausale.TabIndex = 0;
			this.btnCausale.Tag = "manage.accmotive.tree";
			this.btnCausale.Text = "Causale";
			// 
			// btnEditDocument
			// 
			this.btnEditDocument.Location = new System.Drawing.Point(501, 182);
			this.btnEditDocument.Name = "btnEditDocument";
			this.btnEditDocument.Size = new System.Drawing.Size(173, 23);
			this.btnEditDocument.TabIndex = 33;
			this.btnEditDocument.Text = "Vedi documento principale";
			this.btnEditDocument.UseVisualStyleBackColor = true;
			this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
			// 
			// chkFlagVariazione
			// 
			this.chkFlagVariazione.Location = new System.Drawing.Point(166, 10);
			this.chkFlagVariazione.Name = "chkFlagVariazione";
			this.chkFlagVariazione.Size = new System.Drawing.Size(142, 24);
			this.chkFlagVariazione.TabIndex = 32;
			this.chkFlagVariazione.Tag = "epexp.flagvariation:S:N";
			this.chkFlagVariazione.Text = "Nota di variazione";
			// 
			// btnGeneraImpegnoBudget
			// 
			this.btnGeneraImpegnoBudget.Location = new System.Drawing.Point(314, 12);
			this.btnGeneraImpegnoBudget.Name = "btnGeneraImpegnoBudget";
			this.btnGeneraImpegnoBudget.Size = new System.Drawing.Size(173, 23);
			this.btnGeneraImpegnoBudget.TabIndex = 31;
			this.btnGeneraImpegnoBudget.Text = "Genera Impegno di Budget";
			this.btnGeneraImpegnoBudget.UseVisualStyleBackColor = true;
			this.btnGeneraImpegnoBudget.Click += new System.EventHandler(this.btnGeneraImpegnoBudget_Click);
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(24, 202);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(463, 40);
			this.gboxResponsabile.TabIndex = 30;
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
			this.txtResponsabile.Size = new System.Drawing.Size(452, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// gboxFasePrec
			// 
			this.gboxFasePrec.Controls.Add(this.label9);
			this.gboxFasePrec.Controls.Add(this.txtNprec);
			this.gboxFasePrec.Controls.Add(this.txtYprec);
			this.gboxFasePrec.Controls.Add(this.label11);
			this.gboxFasePrec.Controls.Add(this.btnFasePrec);
			this.gboxFasePrec.Location = new System.Drawing.Point(491, 10);
			this.gboxFasePrec.Name = "gboxFasePrec";
			this.gboxFasePrec.Size = new System.Drawing.Size(382, 49);
			this.gboxFasePrec.TabIndex = 29;
			this.gboxFasePrec.TabStop = false;
			this.gboxFasePrec.Text = "Fase precedente";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(230, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 30;
			this.label9.Text = "Numero:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNprec
			// 
			this.txtNprec.Location = new System.Drawing.Point(292, 21);
			this.txtNprec.Name = "txtNprec";
			this.txtNprec.Size = new System.Drawing.Size(56, 20);
			this.txtNprec.TabIndex = 32;
			this.txtNprec.Tag = "";
			this.txtNprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNprec.Leave += new System.EventHandler(this.txtNumeroFasePrecedente_Leave);
			// 
			// txtYprec
			// 
			this.txtYprec.Location = new System.Drawing.Point(156, 19);
			this.txtYprec.Name = "txtYprec";
			this.txtYprec.Size = new System.Drawing.Size(55, 20);
			this.txtYprec.TabIndex = 31;
			this.txtYprec.Tag = "";
			this.txtYprec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtYprec.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(94, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 16);
			this.label11.TabIndex = 29;
			this.label11.Text = "Esercizio:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnFasePrec
			// 
			this.btnFasePrec.BackColor = System.Drawing.SystemColors.Control;
			this.btnFasePrec.Location = new System.Drawing.Point(10, 19);
			this.btnFasePrec.Name = "btnFasePrec";
			this.btnFasePrec.Size = new System.Drawing.Size(83, 23);
			this.btnFasePrec.TabIndex = 27;
			this.btnFasePrec.Tag = "";
			this.btnFasePrec.Text = "Preimpegno";
			this.btnFasePrec.UseVisualStyleBackColor = false;
			this.btnFasePrec.Click += new System.EventHandler(this.btnFasePrecedente_Click);
			// 
			// grpFasi
			// 
			this.grpFasi.Controls.Add(this.radImpegno);
			this.grpFasi.Controls.Add(this.radPreimpegno);
			this.grpFasi.Location = new System.Drawing.Point(24, 3);
			this.grpFasi.Name = "grpFasi";
			this.grpFasi.Size = new System.Drawing.Size(130, 56);
			this.grpFasi.TabIndex = 28;
			this.grpFasi.TabStop = false;
			this.grpFasi.Text = "Tipo";
			// 
			// radImpegno
			// 
			this.radImpegno.AutoSize = true;
			this.radImpegno.Location = new System.Drawing.Point(6, 35);
			this.radImpegno.Name = "radImpegno";
			this.radImpegno.Size = new System.Drawing.Size(66, 17);
			this.radImpegno.TabIndex = 1;
			this.radImpegno.TabStop = true;
			this.radImpegno.Tag = "epexp.nphase:2";
			this.radImpegno.Text = "Impegno";
			this.radImpegno.UseVisualStyleBackColor = true;
			this.radImpegno.CheckedChanged += new System.EventHandler(this.radPreimpegno_CheckedChanged);
			// 
			// radPreimpegno
			// 
			this.radPreimpegno.AutoSize = true;
			this.radPreimpegno.Location = new System.Drawing.Point(6, 17);
			this.radPreimpegno.Name = "radPreimpegno";
			this.radPreimpegno.Size = new System.Drawing.Size(81, 17);
			this.radPreimpegno.TabIndex = 0;
			this.radPreimpegno.TabStop = true;
			this.radPreimpegno.Tag = "epexp.nphase:1";
			this.radPreimpegno.Text = "Preimpegno";
			this.radPreimpegno.UseVisualStyleBackColor = true;
			this.radPreimpegno.CheckedChanged += new System.EventHandler(this.radPreimpegno_CheckedChanged);
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(300, 379);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(274, 117);
			this.gboxUPB.TabIndex = 8;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 89);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(257, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(112, 11);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(153, 72);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(8, 62);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(98, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			this.btnUPBCode.Click += new System.EventHandler(this.btnUPBCode_Click);
			// 
			// groupBox19
			// 
			this.groupBox19.Controls.Add(this.txtDocumento);
			this.groupBox19.Controls.Add(this.label10);
			this.groupBox19.Controls.Add(this.txtDataDocumento);
			this.groupBox19.Controls.Add(this.label14);
			this.groupBox19.Location = new System.Drawing.Point(493, 64);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(380, 56);
			this.groupBox19.TabIndex = 2;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Documento collegato";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(8, 32);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(249, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "epexp.doc";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 14);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "Descrizione";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Location = new System.Drawing.Point(279, 32);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(72, 20);
			this.txtDataDocumento.TabIndex = 2;
			this.txtDataDocumento.Tag = "epexp.docdate";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(279, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 18);
			this.label14.TabIndex = 0;
			this.label14.Text = "Data";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(695, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(178, 77);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Competenza";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(82, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 20);
			this.textBox1.TabIndex = 16;
			this.textBox1.Tag = "epexp.start";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Data fine";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(84, 48);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(80, 20);
			this.textBox2.TabIndex = 18;
			this.textBox2.Tag = "epexp.stop";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Data inizio";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(266, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Numero:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumero
			// 
			this.txtNumero.Location = new System.Drawing.Point(327, 41);
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.Size = new System.Drawing.Size(56, 20);
			this.txtNumero.TabIndex = 1;
			this.txtNumero.Tag = "epexp.nepexp";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(210, 40);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(48, 20);
			this.txtEsercizio.TabIndex = 16;
			this.txtEsercizio.Tag = "epexp.yepexp.year";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(24, 134);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(457, 62);
			this.txtDescrizione.TabIndex = 5;
			this.txtDescrizione.Tag = "epexp.description";
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(504, 153);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
			this.txtDataContabile.TabIndex = 3;
			this.txtDataContabile.Tag = "epexp.adate";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(159, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 12;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 13;
			this.label2.Text = "Descrizione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(501, 134);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "Data contabile:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gBoxImporti
			// 
			this.gBoxImporti.Controls.Add(this.labdisponibile);
			this.gBoxImporti.Controls.Add(this.txtTotaleDisp);
			this.gBoxImporti.Controls.Add(this.txtCurrDisp5);
			this.gBoxImporti.Controls.Add(this.txtCurrDisp4);
			this.gBoxImporti.Controls.Add(this.txtCurrDisp3);
			this.gBoxImporti.Controls.Add(this.txtCurrDisp2);
			this.gBoxImporti.Controls.Add(this.txtCurrDisp);
			this.gBoxImporti.Controls.Add(this.label13);
			this.gBoxImporti.Controls.Add(this.txtTotaleCorr);
			this.gBoxImporti.Controls.Add(this.label12);
			this.gBoxImporti.Controls.Add(this.txtTotale);
			this.gBoxImporti.Controls.Add(this.labAnno5);
			this.gBoxImporti.Controls.Add(this.txtImpCorr5);
			this.gBoxImporti.Controls.Add(this.label8);
			this.gBoxImporti.Controls.Add(this.txtImpCorr4);
			this.gBoxImporti.Controls.Add(this.SubEntity_txtAnno5);
			this.gBoxImporti.Controls.Add(this.labAnno4);
			this.gBoxImporti.Controls.Add(this.txtImpCorr3);
			this.gBoxImporti.Controls.Add(this.SubEntity_txtAnno4);
			this.gBoxImporti.Controls.Add(this.labAnno3);
			this.gBoxImporti.Controls.Add(this.txtImpCorr2);
			this.gBoxImporti.Controls.Add(this.SubEntity_txtAnno3);
			this.gBoxImporti.Controls.Add(this.labAnno2);
			this.gBoxImporti.Controls.Add(this.txtImpCorr);
			this.gBoxImporti.Controls.Add(this.SubEntity_txtAnno2);
			this.gBoxImporti.Controls.Add(this.labAnno1);
			this.gBoxImporti.Controls.Add(this.SubEntity_txtAnno1);
			this.gBoxImporti.Location = new System.Drawing.Point(24, 248);
			this.gBoxImporti.Name = "gBoxImporti";
			this.gBoxImporti.Size = new System.Drawing.Size(847, 125);
			this.gBoxImporti.TabIndex = 7;
			this.gBoxImporti.TabStop = false;
			this.gBoxImporti.Tag = "";
			this.gBoxImporti.Text = "Importi";
			// 
			// labdisponibile
			// 
			this.labdisponibile.Location = new System.Drawing.Point(8, 91);
			this.labdisponibile.Name = "labdisponibile";
			this.labdisponibile.Size = new System.Drawing.Size(122, 13);
			this.labdisponibile.TabIndex = 65;
			this.labdisponibile.Text = "Disponibile";
			this.labdisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleDisp
			// 
			this.txtTotaleDisp.Location = new System.Drawing.Point(710, 88);
			this.txtTotaleDisp.Name = "txtTotaleDisp";
			this.txtTotaleDisp.ReadOnly = true;
			this.txtTotaleDisp.Size = new System.Drawing.Size(104, 20);
			this.txtTotaleDisp.TabIndex = 64;
			this.txtTotaleDisp.TabStop = false;
			this.txtTotaleDisp.Tag = "";
			this.txtTotaleDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCurrDisp5
			// 
			this.txtCurrDisp5.Location = new System.Drawing.Point(595, 88);
			this.txtCurrDisp5.Name = "txtCurrDisp5";
			this.txtCurrDisp5.ReadOnly = true;
			this.txtCurrDisp5.Size = new System.Drawing.Size(96, 20);
			this.txtCurrDisp5.TabIndex = 63;
			this.txtCurrDisp5.TabStop = false;
			this.txtCurrDisp5.Tag = "";
			this.txtCurrDisp5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCurrDisp4
			// 
			this.txtCurrDisp4.Location = new System.Drawing.Point(480, 88);
			this.txtCurrDisp4.Name = "txtCurrDisp4";
			this.txtCurrDisp4.ReadOnly = true;
			this.txtCurrDisp4.Size = new System.Drawing.Size(96, 20);
			this.txtCurrDisp4.TabIndex = 62;
			this.txtCurrDisp4.TabStop = false;
			this.txtCurrDisp4.Tag = "";
			this.txtCurrDisp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCurrDisp3
			// 
			this.txtCurrDisp3.Location = new System.Drawing.Point(361, 88);
			this.txtCurrDisp3.Name = "txtCurrDisp3";
			this.txtCurrDisp3.ReadOnly = true;
			this.txtCurrDisp3.Size = new System.Drawing.Size(96, 20);
			this.txtCurrDisp3.TabIndex = 61;
			this.txtCurrDisp3.TabStop = false;
			this.txtCurrDisp3.Tag = "";
			this.txtCurrDisp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCurrDisp2
			// 
			this.txtCurrDisp2.Location = new System.Drawing.Point(245, 88);
			this.txtCurrDisp2.Name = "txtCurrDisp2";
			this.txtCurrDisp2.ReadOnly = true;
			this.txtCurrDisp2.Size = new System.Drawing.Size(96, 20);
			this.txtCurrDisp2.TabIndex = 60;
			this.txtCurrDisp2.TabStop = false;
			this.txtCurrDisp2.Tag = "";
			this.txtCurrDisp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCurrDisp
			// 
			this.txtCurrDisp.Location = new System.Drawing.Point(134, 88);
			this.txtCurrDisp.Name = "txtCurrDisp";
			this.txtCurrDisp.ReadOnly = true;
			this.txtCurrDisp.Size = new System.Drawing.Size(96, 20);
			this.txtCurrDisp.TabIndex = 59;
			this.txtCurrDisp.TabStop = false;
			this.txtCurrDisp.Tag = "";
			this.txtCurrDisp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(82, 65);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(47, 13);
			this.label13.TabIndex = 58;
			this.label13.Text = "Corrente";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleCorr
			// 
			this.txtTotaleCorr.Location = new System.Drawing.Point(710, 62);
			this.txtTotaleCorr.Name = "txtTotaleCorr";
			this.txtTotaleCorr.ReadOnly = true;
			this.txtTotaleCorr.Size = new System.Drawing.Size(104, 20);
			this.txtTotaleCorr.TabIndex = 56;
			this.txtTotaleCorr.TabStop = false;
			this.txtTotaleCorr.Tag = "";
			this.txtTotaleCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(58, 39);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(72, 13);
			this.label12.TabIndex = 57;
			this.label12.Text = "Iniziale annuo";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotale
			// 
			this.txtTotale.Location = new System.Drawing.Point(711, 36);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.Size = new System.Drawing.Size(104, 20);
			this.txtTotale.TabIndex = 56;
			this.txtTotale.Tag = "";
			this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labAnno5
			// 
			this.labAnno5.AutoSize = true;
			this.labAnno5.Location = new System.Drawing.Point(592, 16);
			this.labAnno5.Name = "labAnno5";
			this.labAnno5.Size = new System.Drawing.Size(38, 13);
			this.labAnno5.TabIndex = 9;
			this.labAnno5.Text = "Anno1";
			this.labAnno5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImpCorr5
			// 
			this.txtImpCorr5.Location = new System.Drawing.Point(595, 62);
			this.txtImpCorr5.Name = "txtImpCorr5";
			this.txtImpCorr5.ReadOnly = true;
			this.txtImpCorr5.Size = new System.Drawing.Size(96, 20);
			this.txtImpCorr5.TabIndex = 8;
			this.txtImpCorr5.TabStop = false;
			this.txtImpCorr5.Tag = "";
			this.txtImpCorr5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(708, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(91, 13);
			this.label8.TabIndex = 55;
			this.label8.Text = "Totale pluriennale";
			// 
			// txtImpCorr4
			// 
			this.txtImpCorr4.Location = new System.Drawing.Point(480, 62);
			this.txtImpCorr4.Name = "txtImpCorr4";
			this.txtImpCorr4.ReadOnly = true;
			this.txtImpCorr4.Size = new System.Drawing.Size(96, 20);
			this.txtImpCorr4.TabIndex = 6;
			this.txtImpCorr4.TabStop = false;
			this.txtImpCorr4.Tag = "";
			this.txtImpCorr4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtAnno5
			// 
			this.SubEntity_txtAnno5.Location = new System.Drawing.Point(595, 36);
			this.SubEntity_txtAnno5.Name = "SubEntity_txtAnno5";
			this.SubEntity_txtAnno5.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtAnno5.TabIndex = 8;
			this.SubEntity_txtAnno5.Tag = "epexpyear.amount5?epexpview.amount5";
			this.SubEntity_txtAnno5.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// labAnno4
			// 
			this.labAnno4.AutoSize = true;
			this.labAnno4.Location = new System.Drawing.Point(477, 15);
			this.labAnno4.Name = "labAnno4";
			this.labAnno4.Size = new System.Drawing.Size(38, 13);
			this.labAnno4.TabIndex = 7;
			this.labAnno4.Text = "Anno1";
			this.labAnno4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImpCorr3
			// 
			this.txtImpCorr3.Location = new System.Drawing.Point(361, 62);
			this.txtImpCorr3.Name = "txtImpCorr3";
			this.txtImpCorr3.ReadOnly = true;
			this.txtImpCorr3.Size = new System.Drawing.Size(96, 20);
			this.txtImpCorr3.TabIndex = 4;
			this.txtImpCorr3.TabStop = false;
			this.txtImpCorr3.Tag = "";
			this.txtImpCorr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtAnno4
			// 
			this.SubEntity_txtAnno4.Location = new System.Drawing.Point(480, 36);
			this.SubEntity_txtAnno4.Name = "SubEntity_txtAnno4";
			this.SubEntity_txtAnno4.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtAnno4.TabIndex = 6;
			this.SubEntity_txtAnno4.Tag = "epexpyear.amount4?epexpview.amount4";
			this.SubEntity_txtAnno4.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// labAnno3
			// 
			this.labAnno3.AutoSize = true;
			this.labAnno3.Location = new System.Drawing.Point(358, 16);
			this.labAnno3.Name = "labAnno3";
			this.labAnno3.Size = new System.Drawing.Size(38, 13);
			this.labAnno3.TabIndex = 5;
			this.labAnno3.Text = "Anno1";
			this.labAnno3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImpCorr2
			// 
			this.txtImpCorr2.Location = new System.Drawing.Point(245, 62);
			this.txtImpCorr2.Name = "txtImpCorr2";
			this.txtImpCorr2.ReadOnly = true;
			this.txtImpCorr2.Size = new System.Drawing.Size(96, 20);
			this.txtImpCorr2.TabIndex = 2;
			this.txtImpCorr2.TabStop = false;
			this.txtImpCorr2.Tag = "";
			this.txtImpCorr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtAnno3
			// 
			this.SubEntity_txtAnno3.Location = new System.Drawing.Point(361, 36);
			this.SubEntity_txtAnno3.Name = "SubEntity_txtAnno3";
			this.SubEntity_txtAnno3.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtAnno3.TabIndex = 4;
			this.SubEntity_txtAnno3.Tag = "epexpyear.amount3?epexpview.amount3";
			this.SubEntity_txtAnno3.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// labAnno2
			// 
			this.labAnno2.AutoSize = true;
			this.labAnno2.Location = new System.Drawing.Point(246, 16);
			this.labAnno2.Name = "labAnno2";
			this.labAnno2.Size = new System.Drawing.Size(38, 13);
			this.labAnno2.TabIndex = 3;
			this.labAnno2.Text = "Anno1";
			this.labAnno2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImpCorr
			// 
			this.txtImpCorr.Location = new System.Drawing.Point(134, 62);
			this.txtImpCorr.Name = "txtImpCorr";
			this.txtImpCorr.ReadOnly = true;
			this.txtImpCorr.Size = new System.Drawing.Size(96, 20);
			this.txtImpCorr.TabIndex = 0;
			this.txtImpCorr.TabStop = false;
			this.txtImpCorr.Tag = "";
			this.txtImpCorr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// SubEntity_txtAnno2
			// 
			this.SubEntity_txtAnno2.Location = new System.Drawing.Point(245, 36);
			this.SubEntity_txtAnno2.Name = "SubEntity_txtAnno2";
			this.SubEntity_txtAnno2.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtAnno2.TabIndex = 2;
			this.SubEntity_txtAnno2.Tag = "epexpyear.amount2?epexpview.amount2";
			this.SubEntity_txtAnno2.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// labAnno1
			// 
			this.labAnno1.AutoSize = true;
			this.labAnno1.Location = new System.Drawing.Point(131, 16);
			this.labAnno1.Name = "labAnno1";
			this.labAnno1.Size = new System.Drawing.Size(38, 13);
			this.labAnno1.TabIndex = 1;
			this.labAnno1.Text = "Anno1";
			this.labAnno1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtAnno1
			// 
			this.SubEntity_txtAnno1.Location = new System.Drawing.Point(134, 36);
			this.SubEntity_txtAnno1.Name = "SubEntity_txtAnno1";
			this.SubEntity_txtAnno1.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtAnno1.TabIndex = 0;
			this.SubEntity_txtAnno1.Tag = "epexpyear.amount?epexpview.amount";
			this.SubEntity_txtAnno1.Leave += new System.EventHandler(this.txtImportoLeave);
			// 
			// gboxClienteFornitore
			// 
			this.gboxClienteFornitore.Controls.Add(this.txtClienteFornitore);
			this.gboxClienteFornitore.Location = new System.Drawing.Point(24, 64);
			this.gboxClienteFornitore.Name = "gboxClienteFornitore";
			this.gboxClienteFornitore.Size = new System.Drawing.Size(463, 48);
			this.gboxClienteFornitore.TabIndex = 4;
			this.gboxClienteFornitore.TabStop = false;
			this.gboxClienteFornitore.Tag = "AutoChoose.txtClienteFornitore.default.(active=\'S\')";
			this.gboxClienteFornitore.Text = "Cliente/Fornitore";
			// 
			// txtClienteFornitore
			// 
			this.txtClienteFornitore.Location = new System.Drawing.Point(8, 16);
			this.txtClienteFornitore.Name = "txtClienteFornitore";
			this.txtClienteFornitore.Size = new System.Drawing.Size(449, 20);
			this.txtClienteFornitore.TabIndex = 0;
			this.txtClienteFornitore.Tag = "registry.title?epexpview.registry";
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.btnAccount);
			this.gboxConto.Location = new System.Drawing.Point(24, 374);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(270, 121);
			this.gboxConto.TabIndex = 7;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(103, 14);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(161, 74);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(6, 94);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(258, 20);
			this.txtCodiceConto.TabIndex = 1;
			this.txtCodiceConto.Tag = "account.codeacc?x";
			// 
			// btnAccount
			// 
			this.btnAccount.BackColor = System.Drawing.SystemColors.Control;
			this.btnAccount.Location = new System.Drawing.Point(8, 65);
			this.btnAccount.Name = "btnAccount";
			this.btnAccount.Size = new System.Drawing.Size(89, 23);
			this.btnAccount.TabIndex = 0;
			this.btnAccount.Tag = "manage.account.tree";
			this.btnAccount.Text = "Conto";
			this.btnAccount.UseVisualStyleBackColor = false;
			// 
			// tabClassificazioni
			// 
			this.tabClassificazioni.Controls.Add(this.dgrClassificazioni);
			this.tabClassificazioni.Controls.Add(this.btnIndElimina);
			this.tabClassificazioni.Controls.Add(this.btnIndModifica);
			this.tabClassificazioni.Controls.Add(this.btnIndInserisci);
			this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
			this.tabClassificazioni.Name = "tabClassificazioni";
			this.tabClassificazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabClassificazioni.Size = new System.Drawing.Size(888, 502);
			this.tabClassificazioni.TabIndex = 3;
			this.tabClassificazioni.Text = "Classificazioni";
			this.tabClassificazioni.UseVisualStyleBackColor = true;
			// 
			// dgrClassificazioni
			// 
			this.dgrClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassificazioni.DataMember = "";
			this.dgrClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassificazioni.Location = new System.Drawing.Point(6, 36);
			this.dgrClassificazioni.Name = "dgrClassificazioni";
			this.dgrClassificazioni.ReadOnly = true;
			this.dgrClassificazioni.Size = new System.Drawing.Size(876, 460);
			this.dgrClassificazioni.TabIndex = 19;
			this.dgrClassificazioni.Tag = "epexpsorting.default.default";
			// 
			// btnIndElimina
			// 
			this.btnIndElimina.BackColor = System.Drawing.SystemColors.Control;
			this.btnIndElimina.Location = new System.Drawing.Point(166, 6);
			this.btnIndElimina.Name = "btnIndElimina";
			this.btnIndElimina.Size = new System.Drawing.Size(68, 24);
			this.btnIndElimina.TabIndex = 18;
			this.btnIndElimina.Tag = "delete";
			this.btnIndElimina.Text = "Elimina";
			this.btnIndElimina.UseVisualStyleBackColor = false;
			// 
			// btnIndModifica
			// 
			this.btnIndModifica.BackColor = System.Drawing.SystemColors.Control;
			this.btnIndModifica.Location = new System.Drawing.Point(86, 6);
			this.btnIndModifica.Name = "btnIndModifica";
			this.btnIndModifica.Size = new System.Drawing.Size(69, 24);
			this.btnIndModifica.TabIndex = 17;
			this.btnIndModifica.Tag = "edit.default";
			this.btnIndModifica.Text = "Modifica...";
			this.btnIndModifica.UseVisualStyleBackColor = false;
			// 
			// btnIndInserisci
			// 
			this.btnIndInserisci.BackColor = System.Drawing.SystemColors.Control;
			this.btnIndInserisci.Location = new System.Drawing.Point(6, 6);
			this.btnIndInserisci.Name = "btnIndInserisci";
			this.btnIndInserisci.Size = new System.Drawing.Size(68, 24);
			this.btnIndInserisci.TabIndex = 16;
			this.btnIndInserisci.Tag = "insert.default";
			this.btnIndInserisci.Text = "Inserisci...";
			this.btnIndInserisci.UseVisualStyleBackColor = false;
			// 
			// tabVariazioni
			// 
			this.tabVariazioni.Controls.Add(this.groupBox4);
			this.tabVariazioni.Location = new System.Drawing.Point(4, 22);
			this.tabVariazioni.Name = "tabVariazioni";
			this.tabVariazioni.Size = new System.Drawing.Size(888, 502);
			this.tabVariazioni.TabIndex = 2;
			this.tabVariazioni.Text = "Variazioni";
			this.tabVariazioni.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btnDeleteVar);
			this.groupBox4.Controls.Add(this.btnEditVar);
			this.groupBox4.Controls.Add(this.btnInsertVar);
			this.groupBox4.Controls.Add(this.GridVariazioni);
			this.groupBox4.Location = new System.Drawing.Point(16, 16);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(852, 471);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Variazione impegno di budget";
			// 
			// btnDeleteVar
			// 
			this.btnDeleteVar.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteVar.Location = new System.Drawing.Point(200, 24);
			this.btnDeleteVar.Name = "btnDeleteVar";
			this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteVar.TabIndex = 3;
			this.btnDeleteVar.Tag = "delete";
			this.btnDeleteVar.Text = "Elimina";
			this.btnDeleteVar.UseVisualStyleBackColor = false;
			// 
			// btnEditVar
			// 
			this.btnEditVar.BackColor = System.Drawing.SystemColors.Control;
			this.btnEditVar.Location = new System.Drawing.Point(112, 24);
			this.btnEditVar.Name = "btnEditVar";
			this.btnEditVar.Size = new System.Drawing.Size(75, 23);
			this.btnEditVar.TabIndex = 2;
			this.btnEditVar.Tag = "edit.detail";
			this.btnEditVar.Text = "Modifica...";
			this.btnEditVar.UseVisualStyleBackColor = false;
			// 
			// btnInsertVar
			// 
			this.btnInsertVar.BackColor = System.Drawing.SystemColors.Control;
			this.btnInsertVar.Location = new System.Drawing.Point(16, 24);
			this.btnInsertVar.Name = "btnInsertVar";
			this.btnInsertVar.Size = new System.Drawing.Size(75, 23);
			this.btnInsertVar.TabIndex = 1;
			this.btnInsertVar.Tag = "insert.detail";
			this.btnInsertVar.Text = "Inserisci...";
			this.btnInsertVar.UseVisualStyleBackColor = false;
			// 
			// GridVariazioni
			// 
			this.GridVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GridVariazioni.DataMember = "";
			this.GridVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.GridVariazioni.Location = new System.Drawing.Point(8, 56);
			this.GridVariazioni.Name = "GridVariazioni";
			this.GridVariazioni.Size = new System.Drawing.Size(836, 407);
			this.GridVariazioni.TabIndex = 0;
			this.GridVariazioni.Tag = "epexpvar.default.detail";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_epexp_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(916, 533);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_epexp_default";
			this.Text = "Impegno di Budget";
			this.tabControl1.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.gBoxCausale.ResumeLayout(false);
			this.gBoxCausale.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxFasePrec.ResumeLayout(false);
			this.gboxFasePrec.PerformLayout();
			this.grpFasi.ResumeLayout(false);
			this.grpFasi.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gBoxImporti.ResumeLayout(false);
			this.gBoxImporti.PerformLayout();
			this.gboxClienteFornitore.ResumeLayout(false);
			this.gboxClienteFornitore.PerformLayout();
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			this.tabClassificazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).EndInit();
			this.tabVariazioni.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.GridVariazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private BudgetFunction bf;
		public void metaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			bf = new BudgetFunction(this.getInstance<IMetaDataDispatcher>() as MetaDataDispatcher);
			controller.CanInsertCopy = false;
			HelpForm.SetDenyNull(DS.epexp.Columns["flagvariation"], true);
			var filteresercvariazione = toString(eq("yvar", esercizio));
			setStaticFilter(DS.epexpvar, filteresercvariazione);
			string filteresercizio = toString(eq("ayear", esercizio));
			setStaticFilter(DS.epexpyear, filteresercizio);
			setStaticFilter(DS.epexptotal, filteresercizio);
			setStaticFilter(DS.epexpview, filteresercizio);
			var tExpSetup = getTable("config", eq("ayear", esercizio));
			if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
				var r = tExpSetup.Rows[0];
			}

			DS.epexpsorting.ExtendedProperties["ViewTable"] = DS.epexpsortingview;
			DS.sortingview.ExtendedProperties["ViewTable"] = DS.epexpsortingview;
			DS.epexpsortingview.ExtendedProperties["RealTable"] = DS.epexpsorting;

			foreach (DataColumn C in DS.epexpsorting.Columns) {
				if (C.ColumnName.StartsWith("!"))
					continue;
				DS.epexpsortingview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] =
					"epexpsorting." + C.ColumnName;
			}

			DS.epexpsortingview.Columns["sortingkind"].ExtendedProperties["ViewSource"] = "sortingview.sortingkind";
			DS.epexpsortingview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sortingview.sortcode";
			DS.epexpsortingview.Columns["sorting"].ExtendedProperties["ViewSource"] = "sortingview.description";
			setStaticFilter(DS.Tables["account"], toString(eq("ayear", esercizio)));
			setImportoName();
		}

		object getCtrlByName(string Name) {
			var Ctrl = this.GetType().GetField(Name);
			if (Ctrl == null)
				return null;
			return Ctrl.GetValue(this);
		}

		void setImportoName() {
			for (int i = 1; i <= 5; i++) {
				var L = (Label) getCtrlByName("labAnno" + i.ToString());
				int N = esercizio + i - 1;
				L.Text = N.ToString();
			}
		}



		void checkCoerenzaCausale(DataRow accmotive) {
			if (isEmpty) return;
			if (accmotive == null) return;
			getFormData(true);
			btnAccount.Tag = "manage.account.tree";
			var  availableDetails=getTable("accmotivedetail",eq("ayear",esercizio)& eq("idaccmotive",accmotive["idaccmotive"]));
			var filterMask = q.bitSet("flagaccountusage", 6) | q.bitSet("flagaccountusage", 8) | q.bitSet("flagaccountusage", 12);
			btnAccount.Tag = "choose.account.default." + toString(q.fieldIn("idacc",(string) "idacc", availableDetails.Select()) & filterMask);

			var idacc = DS.epexpyear.Rows[0]["idacc"];
			if (idacc == DBNull.Value || idacc.ToString()=="") return;
			var details = getTable("accmotivedetail",eq("ayear",esercizio)& eq("idaccmotive",accmotive["idaccmotive"])& eq("idacc",idacc));
			if (details.Rows.Count==0) {
				DS.account.Clear();
				DS.epexpyear.Rows[0]["idacc"] = DBNull.Value;
				controller.ReFillControls(gboxConto.Controls);
				show("Il conto � stata azzerato poich� incorente con la causale selezionata");
			};
		}

		void checkCoerenzaConto(DataRow account) {
			if (isEmpty) return;
			if (account == null) return;
			getFormData(true);
			var idaccmotive = currentRow["idaccmotive"];
			if (idaccmotive == DBNull.Value) return;
			var details = getTable("accmotivedetail",eq("ayear",esercizio)& eq("idacc",account["idacc"])& eq("idaccmotive",idaccmotive));
			if (details.Rows.Count==0) {
				DS.accmotive.Clear();
				currentRow["idaccmotive"] = DBNull.Value;
				controller.ReFillControls(gBoxCausale.Controls);
				show("La causale � stata reimpostata poich� incorente col conto selezionato");
			}
		}

		public void metaData_AfterRowSelect(DataTable t, DataRow r) {
			if (t.TableName == "account" && drawStateIsDone) {
				checkCoerenzaConto(r);
			}
			if (t.TableName=="accmotive" && drawStateIsDone) {
				checkCoerenzaCausale(r);
			}
		}

		public void metaData_AfterGetFormData() {
			calcolaImportoTotaleExtProp();


		}

		void calcolaImportoTotaleExtProp() {
			if (DS.epexpyear.Rows.Count == 0)
				return;
			var R = DS.epexpyear.Rows[0];
			if (R.RowState == DataRowState.Deleted)
				return;

			decimal totalecorr = CfgFn.GetNoNullDecimal(R["amount"]);

			//somma le variazioni
			foreach (var rVar in DS.epexpvar.Select()) {
				totalecorr += CfgFn.GetNoNullDecimal(rVar["amount"]);
			}

			DS.epexpsorting.ExtendedProperties["importototale"] = totalecorr;
		}

		

		void addTab(TabPage Tab, bool redraw) {
			if (tabControl1.TabPages.Contains(Tab)) return;
			tabControl1.TabPages.Add(Tab);
			if (isEmpty) {
				helpForm.ClearControls(Tab.Controls);
			}
			else {
				if (redraw) helpForm.FillControls(Tab.Controls);
			}
		}

		void addRemoveTab(TabPage Tab, bool Add, bool redraw) {
			if (Add) {
				addTab(Tab, redraw);
			}
			else {
				if (tabControl1.TabPages.Contains(Tab)) {
					tabControl1.TabPages.Remove(Tab);
				}
			}
		}

		void addRemoveTabs(bool redraw) {
			if (!controller.IsRealClear) return;
			tabControl1.SuspendLayout();
			int currsel = tabControl1.SelectedIndex;
			addRemoveTab(tabVariazioni, editMode, redraw);

			if (tabControl1.SelectedIndex != currsel) tabControl1.SelectedIndex = currsel;
			tabControl1.ResumeLayout();
		}

		public void metaData_AfterClear() {
			btnAccount.Tag = "manage.account.tree";
			btnSpalmaPrevisioni.Visible = false;
			btnEditDocument.Visible = false;
			txtEsercizio.Text = esercizio.ToString();
			txtNprec.Text = "";
			txtYprec.Text = "";
			txtTotale.Text = "";
			txtTotaleCorr.Text = "";
			txtTotaleDisp.Text = "";
			txtImpCorr.Text = "";
			txtCurrDisp.Text = "";
			txtDescrizione.Text = "";
			txtDataDocumento.Text = "";
			txtDocumento.Text = "";
			labdisponibile.Text = "";
			for (int i = 2; i <= 5; i++) {
				var T = (TextBox) getCtrlByName("txtImpCorr" + i);
				T.Text = "";
				T.Visible = false;
				T = (TextBox) getCtrlByName("txtCurrDisp" + i);
				T.Text = "";
				T.Visible = false;
			}

			txtTotaleCorr.Visible = false;
			txtImpCorr.Visible = false;
			txtCurrDisp.Visible = false;
			txtTotaleDisp.Visible = false;
			DS.epexptotal.Clear();
			gestioneFasi();
			btnGeneraImpegnoBudget.Enabled = false;
			addRemoveTabs(true);
			txtEsercizio.ReadOnly = !isEmpty;
			txtNumero.ReadOnly = !isEmpty;
			abilitaDisabilitaSalvataggio();
			chkFlagVariazione.Enabled = true;
			EnableDisableImporti();
		}

		public void metaData_BeforeFill() {
			addRemoveTabs(false);
			if (insertMode) {
				createEpExpYearRow();
			}
			else {
				if (DS.epexptotal.Rows.Count == 0) {
					selectIntoTable(DS.epexptotal, eq("idepexp", DS.epexp.Rows[0]["idepexp"]) & eq("ayear", esercizio));
				}
			}

			if (CfgFn.GetNoNullInt32(DS.epexp.Rows[0]["nphase"]) == 1) DS.epexp.Rows[0]["paridepexp"] = DBNull.Value;
			calcolaImportoTotaleExtProp();
			gestioneFasi();
			GetData.CalculateTable(DS.epexpsorting);

		}

		void createEpExpYearRow() {
			if (DS.Tables["epexpyear"].Rows.Count == 0) {
				try {
					var DREpExp = DS.Tables["epexp"].Rows[0];
					var MetaImp = MetaData.GetMetaData(this, "epexpyear");
					MetaImp.SetDefaults(DS.epexpyear);
					var DR = MetaImp.Get_New_Row(DREpExp, DS.epexpyear);
					DR["ayear"] = esercizio;
				}
				catch {
				}
			}
		}





		public void metaData_AfterPost() {
			MetaData.sendBroadcast(this, "EpExpSaved");
			if (Meta.PrimaryDataTable.Rows.Count > 0) {
				abilitaDisabilitaGeneraImpegno();
			}
		}



		private void setFasePrecedente() {
			if (radPreimpegno.Checked) return; //se esiste una fase precedente
			if (isEmpty) return;
			//Calcola e riempie i campi relativi alla fase precedente:
			object Livsupid = DS.Tables["epexp"].Rows[0]["paridepexp"];
			var filter = q.eq("idepexp", Livsupid);
			var DT = getTable("epexp", filter, "idepexp,yepexp,nepexp");
			if (DT.Rows.Count == 0) return;
			txtYprec.Text = DT.Rows[0]["yepexp"].ToString();
			txtNprec.Text = DT.Rows[0]["nepexp"].ToString();
		}


		public void metaData_AfterFill() {
			if (firstFillForThisRow)btnAccount.Tag = "manage.account.tree";
			btnSpalmaPrevisioni.Visible = true;
			DataRow curr = DS.epexp.Rows[0];
			btnEditDocument.Visible = (curr["idrelated"] != DBNull.Value);
			calcolaTotale(false);
			calcolaTotaleCorrente(false);
			txtEsercizio.ReadOnly = !isEmpty;
			txtNumero.ReadOnly = !isEmpty;
			setFasePrecedente();
			abilitaDisabilitaGeneraImpegno();
			//AbilitaDisabilitaSalvataggio();
			abilitaDisabilitaNotaVariazione();
			txtTotaleCorr.Visible = true;
			txtImpCorr.Visible = true;
			txtCurrDisp.Visible = radPreimpegno.Checked;
			labdisponibile.Text = (radPreimpegno.Checked) ? "Disponibile" : "Disponibile per costi";
			txtTotaleDisp.Visible = true;
			for (int i = 2; i <= 5; i++) {
				var T = (TextBox) getCtrlByName("txtImpCorr" + i);
				T.Visible = true;
				T = (TextBox) getCtrlByName("txtCurrDisp" + i);
				T.Visible = radPreimpegno.Checked;
			}

			abilitaDisabilitaSalvataggio();
			EnableDisableImporti();
		}

		private void abilitaDisabilitaNotaVariazione() {
			if (isEmpty || editMode) {
				chkFlagVariazione.Enabled = false;
				return;
			}

			if (insertMode) {
				if (radPreimpegno.Checked) {
					chkFlagVariazione.Enabled = true;
				}
				else {
					if (radImpegno.Checked) {
						chkFlagVariazione.Enabled = false;
					}
					else {
						chkFlagVariazione.Enabled = true;
					}
				}

				return;
			}
		}

		private void abilitaDisabilitaSalvataggio() {
			if (isEmpty) {
				return;
			}

			if (insertMode) {
				Meta.CanSave = true;
				return;
			}

			if (DS.epexp.Rows.Count == 0) {
				return;
			}

			DataRow Curr = DS.epexp.Rows[0];
			if (Curr["idrelated"].ToString() != "") {
				// Solo l'utente abilitato a edit_epexpresidui, � autorizzato a salvare, e se trattasi di residuo
				if (utenteAbilitatoAModificareResidui() && impegnoBudgetResiduo(Curr)) {
					Meta.CanSave = true;
				}
				else {
					Meta.CanSave = false;
				}
			}
			else {
				Meta.CanSave = true;
			}

			controller.FreshToolBar();
		}

		public bool utenteAbilitatoAModificareResidui() {
			object idflowchart = getSys("idflowchart");
			// Nessuna restrizione
			if (idflowchart == null || idflowchart == DBNull.Value)
				return true;
			object edit_epexpresidui = getUsr("edit_epexpresidui");
			//Utente abilitato alla funzione di sicurezza: Modifica Impegni di Budget(Residui)
			if (edit_epexpresidui != null && edit_epexpresidui.ToString().ToUpper() == "'S'") {
				return true;
			}

			return false;
		}

		public bool impegnoBudgetResiduo(DataRow R) {
			if (CfgFn.GetNoNullInt32(R["yepexp"]) != esercizio) {
				return true;
			}

			return false;
		}

		private void txtImportoLeave(object sender, EventArgs e) {
			calcolaTotale(drawStateIsDone);
			calcolaTotaleCorrente(drawStateIsDone);
		}

		void abilitaDisabilitaGeneraImpegno() {
			if (isEmpty || insertMode) {
				btnGeneraImpegnoBudget.Enabled = false;
				return;
			}

			if (radImpegno.Checked) {
				btnGeneraImpegnoBudget.Enabled = false;
				return;
			}

			if (editMode) {
				//controlla disponibile
				btnGeneraImpegnoBudget.Enabled = true;
			}

		}

		void gestioneFasi() {
			gboxFasePrec.Visible = radPreimpegno.Checked == false;
			gboxClienteFornitore.Visible = radPreimpegno.Checked == false;

			if (isEmpty) {
				txtYprec.ReadOnly = false;
				txtNprec.ReadOnly = false;
				btnUPBCode.Enabled = true;
				btnAccount.Enabled = true;
				btnCausale.Enabled = true;
				txtCodiceConto.ReadOnly = false;
				txtUPB.ReadOnly = false;
				txtCodiceCausale.ReadOnly = false;
				grpFasi.Enabled = true;
				if (radPreimpegno.Checked) {
					txtNprec.Text = "";
					txtYprec.Text = "";
				}

				return;
			}

			if (insertMode) {
				btnFasePrec.Enabled = true;
				txtYprec.ReadOnly = false;
				txtNprec.ReadOnly = false;
				grpFasi.Enabled = true;
				if (radPreimpegno.Checked) {
					DS.epexp.Rows[0]["paridepexp"] = DBNull.Value;
					txtNprec.Text = "";
					txtYprec.Text = "";
				}
			}
			else {
				btnFasePrec.Enabled = false;
				txtYprec.ReadOnly = true;
				txtNprec.ReadOnly = true;
				grpFasi.Enabled = false;
			}

			btnUPBCode.Enabled = radPreimpegno.Checked;
			btnAccount.Enabled = radPreimpegno.Checked;
			btnCausale.Enabled = radPreimpegno.Checked;
			txtCodiceConto.ReadOnly = !radPreimpegno.Checked;
			txtUPB.ReadOnly = !radPreimpegno.Checked;
			txtCodiceCausale.ReadOnly = !radPreimpegno.Checked;
		}
		void EnableDisableImporti() {
			if (!isEmpty) {
				DataRow r = DS.epexpyear.Rows[0];
				DataRow rMov = DS.epexp.Rows[0];
				//Se siamo nell'esercizio successivo a quello di creazione, disabilita TUTTO ed esce
				if ( (CfgFn.GetNoNullInt32(r["ayear"]) > CfgFn.GetNoNullInt32(rMov["yepexp"]))) {
					gBoxImporti.Enabled = false;
					return;
				}
				//Se siamo nell'esercizio di creazione, disabilita tutti gli importi se esiste la riga di imputazione nell'esercizio successivo.
				string filterEpExpYearSucc = qhs.AppAnd(qhs.CmpEq("idepexp", r["idepexp"]), qhs.CmpEq("ayear", esercizio+1));
				int rowsfound = conn.RUN_SELECT_COUNT("epexpyear", filterEpExpYearSucc, true);
				if ((CfgFn.GetNoNullInt32(r["ayear"]) == CfgFn.GetNoNullInt32(rMov["yepexp"]))
					&& rowsfound>0) {
					gBoxImporti.Enabled = false;
					return;
				}
			}
			else {
				// In ricerca, abilita tutto.
				gBoxImporti.Enabled = true; 
			}



			
		}

		void calcolaTotale(bool read) {
			if (Meta == null) return;
			if (isEmpty) return;
			if (DS.epexpyear.Rows.Count == 0) return;
			if (read) getFormData(true);
			DataRow R = DS.epexpyear.Rows[0];
			decimal totale = CfgFn.GetNoNullDecimal(R["amount"]);
			for (int i = 2; i <= 5; i++) {
				totale += CfgFn.GetNoNullDecimal(R["amount" + i]);
			}

			txtTotale.Text = totale.ToString("c");
		}

		void calcolaTotaleCorrente(bool read) {
			if (Meta == null) return;
			if (isEmpty) return;
			if (DS.epexpyear.Rows.Count == 0)
				return;
			if (read) getFormData(true);
			DataRow R = DS.epexpyear.Rows[0];
			decimal[] allprev = new decimal[6];
			allprev[1] = CfgFn.GetNoNullDecimal(R["amount"]);
			for (int i = 2; i <= 5; i++) {
				allprev[i] = CfgFn.GetNoNullDecimal(R["amount" + i]);
			}

			//somma le variazioni
			foreach (DataRow rVar in DS.epexpvar.Select()) {
				allprev[1] += CfgFn.GetNoNullDecimal(rVar["amount"]);
				for (int i = 2; i <= 5; i++) {
					allprev[i] += CfgFn.GetNoNullDecimal(rVar["amount" + i]);
				}
			}

			decimal totalecorr = allprev[1];
			txtImpCorr.Text = allprev[1].ToString("c");
			for (int i = 2; i <= 5; i++) {
				TextBox T = (TextBox) getCtrlByName("txtImpCorr" + i);
				T.Text = allprev[i].ToString("c");
				totalecorr += allprev[i];
			}

			txtTotaleCorr.Text = totalecorr.ToString("c");

			decimal[] alldisp = new decimal[6];
			for (int i = 2; i <= 5; i++) {
				alldisp[i] = allprev[i];
			}

			decimal diff = 0;
			if (DS.epexptotal.Rows.Count > 0) {
				DataRow oldTotal = DS.epexptotal.Rows[0];
				diff += (allprev[1] - CfgFn.GetNoNullDecimal(oldTotal["curramount"]));
				alldisp[1] = CfgFn.GetNoNullDecimal(oldTotal["available"])
				             - CfgFn.GetNoNullDecimal(oldTotal["curramount"])
				             + allprev[1];
				for (int i = 2; i <= 5; i++) {
					alldisp[i] = CfgFn.GetNoNullDecimal(oldTotal["available" + i])
					             - CfgFn.GetNoNullDecimal(oldTotal["curramount" + i])
					             + allprev[i];
					diff += (allprev[i] - CfgFn.GetNoNullDecimal(oldTotal["curramount" + i]));
				}
			}

			decimal totaledisp = alldisp[1];
			if (CfgFn.GetNoNullInt32(DS.epexp.Rows[0]["nphase"]) == 1) {
				txtCurrDisp.Text = alldisp[1].ToString("c");
				for (int i = 2; i <= 5; i++) {
					TextBox T = (TextBox) getCtrlByName("txtCurrDisp" + i);
					T.Text = alldisp[i].ToString("c");
					totaledisp += alldisp[i];
				}

				txtTotaleDisp.Text = totaledisp.ToString("c");
			}
			else {
				if (DS.epexptotal.Rows.Count > 0) {
					object costavailable = readValue("epexpview",
						eq("ayear", esercizio) & q.eq("idepexp", R["idepexp"]), "costavailable");
					decimal costAvail = CfgFn.GetNoNullDecimal(costavailable);
					costAvail += diff;
					txtTotaleDisp.Text = costAvail.ToString("c");
				}
				else {
					txtTotaleDisp.Text = txtTotaleCorr.Text;
				}
			}
		}



		bool InChiusura = false;

		private void txtNumeroFasePrecedente_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (!drawStateIsDone) return;
			if (txtNprec.ReadOnly) return;
			calcolaStartFilter(null);

			if (!insertMode) return;
			if (txtNprec.Text.Trim() == "") {
				DataRow Curr = DS.Tables["epexp"].Rows[0];
				Curr["paridepexp"] = DBNull.Value;

				DataRow CurrImp = DS.Tables["epexpyear"].Rows[0];
				CurrImp["amount"] = 0;
				return;
			}

			btnFasePrecedente_Click(sender, e);
		}

		void clearStartFilter() {
			Meta.StartFilter = null;
		}

		void calcolaStartFilter(string livsupid) {
			clearStartFilter();
			if (livsupid != null)
				Meta.StartFilter = GetData.MergeFilters(Meta.StartFilter,
					"(paridepexp='" + livsupid + "')");
			else {
				string flt = "";
				if (txtYprec.Text.Length == 4) {
					flt = qhs.CmpEq("parentyepexp", txtYprec.Text);
				}

				if (txtNprec.Text != "") {
					flt = qhs.AppAnd(flt, qhs.CmpEq("parentnepexp", txtNprec.Text));
				}

				Meta.StartFilter = flt;
			}
		}

		private void formattaDataDelTexBox(TextBox TB) {
			if (!TB.Modified)
				return;
			HelpForm.FormatLikeYear(TB);
		}

		private void txtEsercizioFasePrecedente_Leave(object sender, EventArgs e) {
			if (InChiusura)
				return;
			if (txtYprec.ReadOnly)
				return;
			if (!drawStateIsDone)
				return;
			formattaDataDelTexBox(txtYprec);
			calcolaStartFilter(null);
		}

		string getFasePrecFilter(bool FiltraNumMovimento) {
			var ffase = radPreimpegno.Checked ? "" : "(nphase=1)";

			string MyFilter = qhs.AppAnd(ffase, qhs.CmpEq("ayear", esercizio));

			if (insertMode) {
				MyFilter = qhs.AppAnd(MyFilter, qhs.CmpGt("totavailable", 0));
			}

			if (txtYprec.Text.Trim() != "")
				MyFilter = qhs.AppAnd(MyFilter, qhs.CmpEq("yepexp", txtYprec.Text.Trim()));
			//if (!FiltraNumMovimento) return MyFilter; //
			if (FiltraNumMovimento && (txtNprec.Text.Trim() != ""))
				MyFilter = qhs.AppAnd(MyFilter, qhs.CmpEq("nepexp", txtNprec.Text.Trim()));


			if (!isEmpty) {
				DataRow CurrImp = DS.epexpyear.Rows[0];
				object idupb = CurrImp["idupb"];
				if (idupb.ToString() != "")
					MyFilter = qhs.AppAnd(MyFilter, qhs.CmpEq("idupb", idupb));
			}

			return MyFilter;
		}

		private void btnFasePrecedente_Click(object sender, EventArgs e) {


			string MyFilter;

			if (((Control) sender).Name == "txtNprec")
				MyFilter = getFasePrecFilter(true);
			else
				MyFilter = getFasePrecFilter(false);

			if (chkFlagVariazione.Checked) {
				MyFilter = qhs.AppAnd(MyFilter, qhs.CmpEq("flagvariation", "S"));
			}
			else {
				MyFilter = qhs.AppAnd(MyFilter, qhs.CmpEq("flagvariation", "N"));
			}

			var MFase = MetaData.GetMetaData(this, "epexpview");
			MFase.FilterLocked = true;
			MFase.ds = DS;

			DataRow MyDR = MFase.SelectOne("elencofaseprec", MyFilter, null, null);

			if (MyDR == null) {
				if (insertMode) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox) sender).Text.Trim() != "")
							((TextBox) sender).Focus();
					}
				}

				return;
			}

			calcolaStartFilter(MyDR["idepexp"].ToString());

			if (isEmpty) {
				//Se mi trovo in imposta ricerca
				txtClienteFornitore.Text = MyDR["registry"].ToString();
				txtYprec.Text = MyDR["yepexp"].ToString();
				txtNprec.Text = MyDR["nepexp"].ToString();
			}

			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if (insertMode) {

				//Legge i dati dal Form
				MetaData.GetFormData(this, true);
				DS.epexp.Rows[0]["paridepexp"] = MyDR["idepexp"];
				DataRow DRImputazione = DS.Tables["epexpyear"].Rows[0];
				DataRow DRSpesa = DS.Tables["epexp"].Rows[0];


				//DRImputazione["idepexp"] = DRSpesa["idepexp"];
				//DRImputazione["ayear"] = Meta.GetSys("esercizio").ToString();


				DRImputazione["idacc"] = MyDR["idacc"];
				DRImputazione["idupb"] = MyDR["idupb"];
				setUPB(MyDR["idupb"]);
				setResponsabile(MyDR["idman"]);
				DRSpesa["description"] = MyDR["description"];
				txtDescrizione.Text = MyDR["description"].ToString();
				DRSpesa["docdate"] = MyDR["docdate"];
				txtDataDocumento.Text = HelpForm.StringValue(MyDR["docdate"], txtDataDocumento.Tag.ToString());
				DRSpesa["doc"] = MyDR["doc"];
				txtDocumento.Text = MyDR["doc"].ToString();

				DRImputazione["amount"] = MyDR["available"];
				for (int i = 2; i <= 5; i++) {
					DRImputazione["amount" + i.ToString()] = MyDR["available" + i.ToString()];
				}

				//Valori del padre del movimento
				txtYprec.Text = MyDR["yepexp"].ToString();
				txtNprec.Text = MyDR["nepexp"].ToString();


				Meta.FreshForm(true); //richiama in automatico il Ricalcolo Missione,

			}
		}

		void setResponsabile(object idman) {
			Meta.SetAutoField(idman, txtResponsabile);
		}

		void setUPB(object idupb) {
			Meta.SetAutoField(idupb, txtUPB);
		}

		object getResponsabile() {
			return Meta.GetAutoField(txtResponsabile);
		}

		object getUpb() {
			return Meta.GetAutoField(txtUPB);
		}

		private void radPreimpegno_CheckedChanged(object sender, EventArgs e) {
			gestioneFasi();
			abilitaDisabilitaGeneraImpegno();
			abilitaDisabilitaNotaVariazione();
		}


		private void btnUPBCode_Click(object sender, EventArgs e) {
			object getresp = getResponsabile();
			if (isEmpty || (editMode && getresp == DBNull.Value)) {
				Meta.DoMainCommand("manage.upb.tree");
				return;
			}

			string filterMan = "";
			if (getresp != DBNull.Value) {
				filterMan = qhs.CmpEq("idman", getresp);
			}

			string filter = qhs.AppAnd(filterMan, qhs.CmpEq("active", 'S'),
				qhs.CmpEq("ayear", esercizio));
			decimal currval = 0;
			if (isEmpty || insertMode) {
				if (SubEntity_txtAnno1.Text.Trim() != "") {
					currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
						typeof(decimal), SubEntity_txtAnno1.Text, "x.y.c"));
				}
			}
			else {
				if (txtImpCorr.Text.Trim() != "") {
					currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
						typeof(decimal), txtImpCorr.Text, "x.y.c"));
				}
			}

			if (insertMode && (currval > 0)) {
				filter = qhs.AppAnd(filter, qhs.CmpGe("available", currval));
			}

			var MetaUpb = MetaData.GetMetaData(this, "upbepexpyearview");
			MetaUpb.ds = new DataSet();
			MetaUpb.linkedForm = this;
			MetaUpb.FilterLocked = true;
			var Upb = MetaUpb.SelectOne("epexp", filter, "upbepexpyearview", null);
			if (Upb == null) return;
			object idupb = Upb["idupb"];
			setUPB(idupb);
		}

		private void btnGeneraImpegnoBudget_Click(object sender, EventArgs e) {
			var Curr = DS.epexp.Rows[0];
			var CurrEpexpyear = DS.epexpyear.Rows[0];
			string FilterFase1 = qhs.AppAnd(qhs.CmpEq("idepexp", CurrEpexpyear["idepexp"]),
				qhs.CmpEq("ayear", esercizio), qhs.CmpGt("available", 0));
			var tEpexpview = getTable("epexpview", FilterFase1);
			DataRow rEpexpview;
			if ((tEpexpview != null) && (tEpexpview.Rows.Count > 0)) {
				rEpexpview = tEpexpview.Rows[0];
			}
			else {
				show("Il Preimpegno non ha disponibile.");
				return;
			}

			MetaData MetaImpegno = MetaData.GetMetaData(this, "epexp");
			MetaData MetaImputazioneImpegno = MetaData.GetMetaData(this, "epexpyear");

			MetaImpegno.Edit(ParentForm, "default", false);

			Hashtable saveddefaultsEpexp = new Hashtable();
			Hashtable saveddefaultsEpexpYear = new Hashtable();
			var D = MetaImpegno.ds;

			DataTable EpExp = D.Tables["epexp"];
			DataTable EpExpyear = D.Tables["epexpyear"];
			foreach (DataColumn C in EpExp.Columns) {
				saveddefaultsEpexp[C.ColumnName] = C.DefaultValue;
			}

			foreach (DataColumn C in EpExpyear.Columns) {
				saveddefaultsEpexpYear[C.ColumnName] = C.DefaultValue;
			}

			MetaData.SetDefault(EpExp, "nphase", 2);
			MetaData.SetDefault(EpExp, "flagvariation", Curr["flagvariation"]);
			MetaData.SetDefault(EpExp, "description", Curr["description"]);
			MetaData.SetDefault(EpExp, "doc", Curr["doc"]);
			MetaData.SetDefault(EpExp, "docdate", Curr["docdate"]);
			MetaData.SetDefault(EpExp, "idman", Curr["idman"]);
			MetaData.SetDefault(EpExp, "paridepexp", Curr["idepexp"]);
			MetaData.SetDefault(EpExp, "idaccmotive", Curr["idaccmotive"]);

			MetaData.SetDefault(EpExpyear, "ayear", esercizio);
			MetaData.SetDefault(EpExpyear, "idacc", CurrEpexpyear["idacc"]);
			MetaData.SetDefault(EpExpyear, "idupb", CurrEpexpyear["idupb"]);

			MetaData.SetDefault(EpExpyear, "amount", rEpexpview["available"]);
			for (int i = 2; i <= 5; i++) {
				MetaData.SetDefault(EpExpyear, "amount" + i, rEpexpview["available" + i]);
			}

			MetaImpegno.DoMainCommand("maininsert");

			foreach (DataColumn CC in EpExp.Columns) {
				CC.DefaultValue = saveddefaultsEpexp[CC.ColumnName];
			}

			foreach (DataColumn CC in EpExpyear.Columns) {
				CC.DefaultValue = saveddefaultsEpexpYear[CC.ColumnName];
			}

			MetaImpegno.FreshForm(true);
		}

		private void btnEditDocument_Click(object sender, EventArgs e) {
			if (DS.epexp.Rows.Count == 0) return;
			DataRow Curr = DS.epexp.Rows[0];
			BudgetFunction.EditRelatedDocument(Meta, Curr);
		}

		private void btnSpalmaPrevisioni_Click(object sender, EventArgs e) {
			Meta.GetFormData(true);
			var r = DS.epexpyear.Rows[0];
			decimal total = 0;
			foreach (string field in new[] {"amount", "amount2", "amount3", "amount4", "amount5"}) {
				total += CfgFn.GetNoNullDecimal(r[field]);
			}
            FrmAskDataInizioFine f = new FrmAskDataInizioFine(false);
            createForm(f, this);
            var res = f.ShowDialog(this);
			if (res != DialogResult.OK) return;
			DateTime inizio = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
				f.txtDataInizio.Text.ToString(), "x.y");
			DateTime fine = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
				f.txtDataFine.Text.ToString(), "x.y");

			var split = bf.GetAmounts(total, inizio, fine);
			for (int i = 1; i <= 5; i++) {
				string field = (i == 1) ? "amount" : $"amount{i}";
				var d = split[i-1];
				r[field] = d;
			}
			Meta.FreshForm(false);
		}
	}

}
