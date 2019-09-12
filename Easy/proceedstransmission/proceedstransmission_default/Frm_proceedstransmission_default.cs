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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;

namespace proceedstransmission_default {//trasmdocincasso//
	/// <summary>
	/// Summary description for frmtrasmdocincasso.
	/// Author: Leo, 11 Dec 2002, End 12 Dec 2002
	/// Revised By Nino on 9/3/2003 (adjusted filter of combos)
	/// </summary>
	public class Frm_proceedstransmission_default : System.Windows.Forms.Form {
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label2;
		public vistaForm DS;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbResponsabile;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.ComboBox cmbCodiceIstituto;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		public MetaData Meta;
        bool flagtrasmresponsabile;
		private System.Windows.Forms.GroupBox groupBox3;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabPrincipale;
        private Crownwood.Magic.Controls.TabPage tabEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private TabControl tabDocumenti;
        private TabPage tabPageReversali;
        private GroupBox groupBox2;
        private TextBox txtTotale;
        private Label label4;
        private Button btnModifica;
        private DataGrid dataGrid1;
        private Button btnCollega;
        private Button btnScollega;
        private TabPage tabPageVariazioni;
        private GroupBox gBoxTransmissionKind;
        private CheckBox chkTransmissionKind;
        private GroupBox groupBox4;
        private Button btnModificaVar;
        private DataGrid dgrVariazioni;
        private Button btnCollegaVar;
        private Button btnScollegaVar;
        private Button btnGeneraEP;
        private Label label5;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Label labEPDisabilitato;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_proceedstransmission_default() {
			InitializeComponent();
			QueryCreator.SetTableForPosting(DS.proceedsview,"proceeds");
            QueryCreator.SetTableForPosting(DS.incomevarview, "incomevar");
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new proceedstransmission_default.vistaForm();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPrincipale = new Crownwood.Magic.Controls.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gBoxTransmissionKind = new System.Windows.Forms.GroupBox();
            this.chkTransmissionKind = new System.Windows.Forms.CheckBox();
            this.tabDocumenti = new System.Windows.Forms.TabControl();
            this.tabPageReversali = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModifica = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnCollega = new System.Windows.Forms.Button();
            this.btnScollega = new System.Windows.Forms.Button();
            this.tabPageVariazioni = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnModificaVar = new System.Windows.Forms.Button();
            this.dgrVariazioni = new System.Windows.Forms.DataGrid();
            this.btnCollegaVar = new System.Windows.Forms.Button();
            this.btnScollegaVar = new System.Windows.Forms.Button();
            this.tabEP = new Crownwood.Magic.Controls.TabPage();
            this.labEPDisabilitato = new System.Windows.Forms.Label();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEP = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.gBoxTransmissionKind.SuspendLayout();
            this.tabDocumenti.SuspendLayout();
            this.tabPageReversali.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPageVariazioni.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).BeginInit();
            this.tabEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinta di trasmissione";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(251, 17);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(88, 23);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.Tag = "proceedstransmission.nproceedstransmission?proceedstransmissionview.nproceedstran" +
    "smission";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(171, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(91, 17);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 23);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "proceedstransmission.yproceedstransmission?proceedstransmissionview.yproceedstran" +
    "smission";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "proceedstransmission.transmissiondate?proceedstransmissionview.transmissiondate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 51;
            this.label3.Text = "Data trasmissione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabile.Location = new System.Drawing.Point(160, 80);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(473, 23);
            this.cmbResponsabile.TabIndex = 3;
            this.cmbResponsabile.Tag = "proceedstransmission.idman?proceedstransmissionview.manager";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 24);
            this.label7.TabIndex = 62;
            this.label7.Text = "Responsabile della distinta:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(160, 16);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(473, 23);
            this.cmbCodiceIstituto.TabIndex = 1;
            this.cmbCodiceIstituto.Tag = "proceedstransmission.idtreasurer?proceedstransmissionview.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(64, 16);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(88, 24);
            this.btnIstitutoCassiere.TabIndex = 67;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmbResponsabile);
            this.groupBox3.Location = new System.Drawing.Point(6, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 112);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Contabili";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(296, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "Data creazione flusso:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(441, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 23);
            this.textBox1.TabIndex = 88;
            this.textBox1.Tag = "proceedstransmission.streamdate?proceedstransmissionview.streamdate";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPrincipale;
            this.tabControl1.Size = new System.Drawing.Size(650, 518);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPrincipale,
            this.tabEP});
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPrincipale.Controls.Add(this.checkBox1);
            this.tabPrincipale.Controls.Add(this.gBoxTransmissionKind);
            this.tabPrincipale.Controls.Add(this.tabDocumenti);
            this.tabPrincipale.Controls.Add(this.groupBox3);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(650, 493);
            this.tabPrincipale.TabIndex = 3;
            this.tabPrincipale.Title = "Principale";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(422, 168);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(221, 19);
            this.checkBox1.TabIndex = 88;
            this.checkBox1.Tag = "proceedstransmission.flagtransmissionenabled:S:N";
            this.checkBox1.Text = "Verificato, si autorizza la trasmissione";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // gBoxTransmissionKind
            // 
            this.gBoxTransmissionKind.Controls.Add(this.chkTransmissionKind);
            this.gBoxTransmissionKind.Location = new System.Drawing.Point(6, 157);
            this.gBoxTransmissionKind.Name = "gBoxTransmissionKind";
            this.gBoxTransmissionKind.Size = new System.Drawing.Size(374, 36);
            this.gBoxTransmissionKind.TabIndex = 85;
            this.gBoxTransmissionKind.TabStop = false;
            this.gBoxTransmissionKind.Text = "Tipo elenco";
            // 
            // chkTransmissionKind
            // 
            this.chkTransmissionKind.AutoSize = true;
            this.chkTransmissionKind.Location = new System.Drawing.Point(107, 11);
            this.chkTransmissionKind.Name = "chkTransmissionKind";
            this.chkTransmissionKind.Size = new System.Drawing.Size(212, 19);
            this.chkTransmissionKind.TabIndex = 82;
            this.chkTransmissionKind.Tag = "proceedstransmission.transmissionkind:V:I";
            this.chkTransmissionKind.Text = "Elenco di Variazioni e Annullamenti";
            this.chkTransmissionKind.UseVisualStyleBackColor = true;
            this.chkTransmissionKind.CheckedChanged += new System.EventHandler(this.chkTransmissionKind_CheckedChanged);
            // 
            // tabDocumenti
            // 
            this.tabDocumenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDocumenti.Controls.Add(this.tabPageReversali);
            this.tabDocumenti.Controls.Add(this.tabPageVariazioni);
            this.tabDocumenti.Location = new System.Drawing.Point(6, 202);
            this.tabDocumenti.Name = "tabDocumenti";
            this.tabDocumenti.SelectedIndex = 0;
            this.tabDocumenti.Size = new System.Drawing.Size(641, 285);
            this.tabDocumenti.TabIndex = 3;
            // 
            // tabPageReversali
            // 
            this.tabPageReversali.Controls.Add(this.groupBox2);
            this.tabPageReversali.Location = new System.Drawing.Point(4, 24);
            this.tabPageReversali.Name = "tabPageReversali";
            this.tabPageReversali.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReversali.Size = new System.Drawing.Size(633, 257);
            this.tabPageReversali.TabIndex = 0;
            this.tabPageReversali.Text = "Reversali incluse nella distinta di trasmissione";
            this.tabPageReversali.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotale);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.dataGrid1);
            this.groupBox2.Controls.Add(this.btnCollega);
            this.groupBox2.Controls.Add(this.btnScollega);
            this.groupBox2.Location = new System.Drawing.Point(7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 248);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // txtTotale
            // 
            this.txtTotale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotale.Location = new System.Drawing.Point(508, 221);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(104, 23);
            this.txtTotale.TabIndex = 69;
            this.txtTotale.TabStop = false;
            this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(422, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "Totale distinta";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(16, 64);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 67;
            this.btnModifica.TabStop = false;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(96, 24);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(516, 191);
            this.dataGrid1.TabIndex = 64;
            this.dataGrid1.Tag = "proceedsview.documentitrasmessi";
            // 
            // btnCollega
            // 
            this.btnCollega.Location = new System.Drawing.Point(16, 24);
            this.btnCollega.Name = "btnCollega";
            this.btnCollega.Size = new System.Drawing.Size(75, 23);
            this.btnCollega.TabIndex = 65;
            this.btnCollega.TabStop = false;
            this.btnCollega.Text = "Inserisci";
            this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(16, 104);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(75, 23);
            this.btnScollega.TabIndex = 66;
            this.btnScollega.TabStop = false;
            this.btnScollega.Tag = "unlink";
            this.btnScollega.Text = "Rimuovi";
            // 
            // tabPageVariazioni
            // 
            this.tabPageVariazioni.Controls.Add(this.groupBox4);
            this.tabPageVariazioni.Location = new System.Drawing.Point(4, 24);
            this.tabPageVariazioni.Name = "tabPageVariazioni";
            this.tabPageVariazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariazioni.Size = new System.Drawing.Size(633, 257);
            this.tabPageVariazioni.TabIndex = 1;
            this.tabPageVariazioni.Text = "Variazioni incluse nella distinta di trasmissione";
            this.tabPageVariazioni.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnModificaVar);
            this.groupBox4.Controls.Add(this.dgrVariazioni);
            this.groupBox4.Controls.Add(this.btnCollegaVar);
            this.groupBox4.Controls.Add(this.btnScollegaVar);
            this.groupBox4.Location = new System.Drawing.Point(6, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(620, 248);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // btnModificaVar
            // 
            this.btnModificaVar.Location = new System.Drawing.Point(16, 64);
            this.btnModificaVar.Name = "btnModificaVar";
            this.btnModificaVar.Size = new System.Drawing.Size(75, 23);
            this.btnModificaVar.TabIndex = 67;
            this.btnModificaVar.TabStop = false;
            this.btnModificaVar.Text = "Modifica...";
            this.btnModificaVar.Click += new System.EventHandler(this.btnModificaVar_Click);
            // 
            // dgrVariazioni
            // 
            this.dgrVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrVariazioni.CaptionVisible = false;
            this.dgrVariazioni.DataMember = "";
            this.dgrVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrVariazioni.Location = new System.Drawing.Point(96, 24);
            this.dgrVariazioni.Name = "dgrVariazioni";
            this.dgrVariazioni.Size = new System.Drawing.Size(516, 199);
            this.dgrVariazioni.TabIndex = 64;
            this.dgrVariazioni.Tag = "incomevarview.documentitrasmessi";
            // 
            // btnCollegaVar
            // 
            this.btnCollegaVar.Location = new System.Drawing.Point(16, 24);
            this.btnCollegaVar.Name = "btnCollegaVar";
            this.btnCollegaVar.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaVar.TabIndex = 65;
            this.btnCollegaVar.TabStop = false;
            this.btnCollegaVar.Text = "Inserisci";
            this.btnCollegaVar.Click += new System.EventHandler(this.btnCollegaVar_Click);
            // 
            // btnScollegaVar
            // 
            this.btnScollegaVar.Location = new System.Drawing.Point(16, 104);
            this.btnScollegaVar.Name = "btnScollegaVar";
            this.btnScollegaVar.Size = new System.Drawing.Size(75, 23);
            this.btnScollegaVar.TabIndex = 66;
            this.btnScollegaVar.TabStop = false;
            this.btnScollegaVar.Tag = "";
            this.btnScollegaVar.Text = "Rimuovi";
            this.btnScollegaVar.Click += new System.EventHandler(this.btnScollegaVar_Click);
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.labEPDisabilitato);
            this.tabEP.Controls.Add(this.btnGeneraEP);
            this.tabEP.Controls.Add(this.btnVisualizzaEP);
            this.tabEP.Controls.Add(this.labEP);
            this.tabEP.Location = new System.Drawing.Point(0, 0);
            this.tabEP.Name = "tabEP";
            this.tabEP.Selected = false;
            this.tabEP.Size = new System.Drawing.Size(650, 493);
            this.tabEP.TabIndex = 4;
            this.tabEP.Title = "E/P";
            // 
            // labEPDisabilitato
            // 
            this.labEPDisabilitato.Location = new System.Drawing.Point(12, 127);
            this.labEPDisabilitato.Name = "labEPDisabilitato";
            this.labEPDisabilitato.Size = new System.Drawing.Size(352, 16);
            this.labEPDisabilitato.TabIndex = 20;
            this.labEPDisabilitato.Text = "Le scritture in partita doppia sono disabilitate per questo elenco.";
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(12, 83);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 19;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
            this.btnGeneraEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(12, 54);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 18;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // labEP
            // 
            this.labEP.Location = new System.Drawing.Point(12, 0);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(352, 16);
            this.labEP.TabIndex = 16;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // Frm_proceedstransmission_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(650, 518);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_proceedstransmission_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtrasmdocincasso";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.gBoxTransmissionKind.ResumeLayout(false);
            this.gBoxTransmissionKind.PerformLayout();
            this.tabDocumenti.ResumeLayout(false);
            this.tabPageReversali.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPageVariazioni.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrVariazioni)).EndInit();
            this.tabEP.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
        private EP_Manager EPM;

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
			GetData.CacheTable(DS.accountkind);
            HelpForm.SetDenyNull(DS.proceedstransmission.Columns["transmissionkind"], true);
            HelpForm.SetDenyNull(DS.proceedstransmission.Columns["idtreasurer"], true);
            HelpForm.SetDenyNull(DS.proceedstransmission.Columns["flagtransmissionenabled"], true);
            EPM = new EP_Manager(Meta, null, null, null, null, btnGeneraEP, btnVisualizzaEP, labEP, labEPDisabilitato, "proceedstransmission");
        }

		public void MetaData_AfterActivation() {
            txtEsercizio.Text = esercizio.ToString();
            if (DS.config.Rows.Count > 0) {
                byte proceedsFlag = (byte)DS.config.Rows[0]["proceeds_flag"];
                flagtrasmresponsabile = (proceedsFlag & 1) == 1;
				if (flagtrasmresponsabile){
					cmbResponsabile.Enabled=true;
				}
				else{
					cmbResponsabile.Enabled=false;
				}
			}
			else {
				MessageBox.Show("Errore: Non è stata ancora effettuata la configurazione delle entrate per l'esercizio corrente.");
				Meta.CanSave=false;
				Meta.SearchEnabled=false;
			}
			btnCollega.ForeColor = formcolors.GridButtonForeColor();
			btnCollega.BackColor = formcolors.GridButtonBackColor();
			btnModifica.ForeColor = formcolors.GridButtonForeColor();
			btnModifica.BackColor = formcolors.GridButtonBackColor();
            btnCollegaVar.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaVar.BackColor = formcolors.GridButtonBackColor();
            btnModificaVar.ForeColor = formcolors.GridButtonForeColor();
            btnModificaVar.BackColor = formcolors.GridButtonBackColor();
            btnScollegaVar.ForeColor = formcolors.GridButtonForeColor();
            btnScollegaVar.BackColor = formcolors.GridButtonBackColor();
		}

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            if (T.TableName == "treasurer" && R != null)
            {
                string flagedisp = R["flagedisp"].ToString().ToUpper();

                if (flagedisp == "N")
                {
                    chkTransmissionKind.Checked = false;
                    gBoxTransmissionKind.Visible = false;
                    AddRemoveTab(tabPageVariazioni, false, false);
                }
                else
                {
                    gBoxTransmissionKind.Visible = true;
                    AddRemoveTab(tabPageVariazioni, true, false);
                }
            }
        }


		public void MetaData_AfterPost() {
		    EPM.afterPost();
		}

		/// <summary>
		/// Metodo che genera le scritture in P.D.
		/// </summary>




		string CalculateFilterForLinking(bool SQL){
            QueryHelper QH = SQL ? QHS : QHC;
			DataRow Curr = DS.proceedstransmission.Rows[0];
            string MyFilter = QH.AppAnd(QH.IsNull("kproceedstransmission"), 
                            QH.IsNotNull("printdate"), QH.CmpEq("ypro", esercizio));
            MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idtreasurer", Curr["idtreasurer"]));

            if (flagtrasmresponsabile) MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idman", Curr["idman"]));
            return MyFilter;		
		}

        string CalculateFilterForLinkingVar(bool SQL)
        {
            DataRow Curr = DS.proceedstransmission.Rows[0];
            QueryHelper QH = SQL ? QHS : QHC;
            string MyFilter = QH.AppAnd(QH.IsNull("kproceedstransmission"),QH.FieldInList("autokind","10,11,22"),
                              QH.CmpEq("yvar", esercizio), QH.IsNotNull("kpro"), QH.IsNotNull("kproceedstransmission_orig"));
            MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idtreasurer", Curr["idtreasurer"]));

            if (flagtrasmresponsabile) MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idman", Curr["idman"]));
            return MyFilter;
        }

		private void btnCollega_Click(object sender, System.EventArgs e) {
			if (MetaData.Empty(this)) return;
			MetaData.GetFormData(this,true);
			string MyFilter = CalculateFilterForLinking(true);
			string command = "choose.proceedsview.documentitrasmessi." + MyFilter;
			MetaData.Choose(this,command);
		}

        private void btnCollegaVar_Click(object sender, System.EventArgs e)
        {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            Meta.MarkTableAsNotEntityChild(DS.incomevarview);
            string MyFilter = CalculateFilterForLinkingVar(true);
            string command = "choose.incomevarview.documentitrasmessi." + MyFilter;
            MetaData.Choose(this, command);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }
		void CalcolaDefaultPerIstitutoCassiere(){
            DataRow[] cassiere = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (cassiere.Length == 1) {
                MetaData.SetDefault(DS.proceedstransmission, "idtreasurer", cassiere[0]["idtreasurer"]);
                return;
            }
            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.proceedstransmission, "idtreasurer", codiceistituto);
            }
		}

        private void LeggiRigheCollegate(Hashtable hVarCollegate, ArrayList arrVarCollegate)
        {
            // Questo metodo tiene traccia delle righe collegate 
            foreach (DataRow rVar in DS.incomevarview.Select())
            {
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object currVal = rVar["kproceedstransmission", DataRowVersion.Current];

                if (currVal != DBNull.Value)
                {
                    if (arrVarCollegate.Contains(rVar["idinc"])) continue;
                    hVarCollegate[rVar["idinc"]] = rVar["kpro"];
                    arrVarCollegate.Add(rVar["idinc"]);
                }

            }
        }

        private void ConfermaRigheCollegate(Hashtable hVarCollegate, ArrayList arrVarCollegate)
        {
            foreach (object idinc in arrVarCollegate)
            {
                string filterRow = "";
                string filter = "";
                filterRow = QHC.AppAnd(QHC.CmpEq("idinc", idinc), QHC.CmpEq("autokind", 11));
                int len = DS.incomevarview.Select(filterRow).Length;
                if (len == 0)
                {
                    filter = QHC.AppAnd(QHC.CmpEq("kpro", hVarCollegate[idinc]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.incomevarview.Select(filter))
                    {
                        VarAnn["kproceedstransmission"] = DBNull.Value;
                    }
                }
                if (len == 1)
                {
                    DataRow R = DS.incomevarview.Select(filterRow)[0];
                    object currVal = R["kproceedstransmission", DataRowVersion.Current];
                    if (currVal == DBNull.Value)
                    {
                        filter = QHC.AppAnd(QHC.CmpEq("kpro", hVarCollegate[idinc]), QHC.CmpEq("autokind", 11));
                        foreach (DataRow VarAnn in DS.incomevarview.Select(filter))
                        {
                            VarAnn["kproceedstransmission"] = DBNull.Value;
                        }
                    }
                }
            }
        }

        private void CollegaScollegaAnnullamentiTotali()
        {
            Hashtable hVarTotali = null;
            hVarTotali = new Hashtable();

            // in questo primo ciclo se vi sono righe originariamente scollegate, poi ricollegate e poi scollegate
            // le rimuove dal dataset insieme alle sorelle
            foreach (DataRow rVar in DS.incomevarview.Select())
            {
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kproceedstransmission", DataRowVersion.Original];
                object currVal = rVar["kproceedstransmission", DataRowVersion.Current];

                if ((originalVal == DBNull.Value) && (currVal == DBNull.Value))
                {
                    string filter = "";
                    filter = QHC.AppAnd(QHC.CmpEq("kpro", rVar["kpro"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.incomevarview.Select(filter))
                    {
                        VarAnn.Delete();
                        VarAnn.AcceptChanges();
                    }
                }

            }

            // in questo secondo ciclo se vi sono righe originariamente collegate, poi scollegate e poi ricollegate
            // ne ripristina il valore originale not null (anche per le sorelle) ponendole in stato unchanged

            foreach (DataRow rVar in DS.incomevarview.Select())
            {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kproceedstransmission", DataRowVersion.Original];
                object currVal = rVar["kproceedstransmission", DataRowVersion.Current];

                if ((originalVal != DBNull.Value) && (currVal != DBNull.Value))
                {
                    string filter = "";
                    filter = QHC.AppAnd(QHC.CmpEq("kpro", rVar["kpro"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.incomevarview.Select(filter))
                    {
                        VarAnn["kproceedstransmission"] = originalVal;
                        VarAnn.AcceptChanges();
                    }
                }

            }

            // in questo terzo ciclo se vi sono righe originariamente collegate, poi scollegate 
            // scollega tutte le sorelle

            foreach (DataRow rVar in DS.incomevarview.Select())
            {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kproceedstransmission", DataRowVersion.Original];
                object currVal = rVar["kproceedstransmission", DataRowVersion.Current];

                if ((originalVal != DBNull.Value) && (currVal == DBNull.Value))
                {
                    string filter = "";

                    if (hVarTotali[rVar["kpro"]] != null) continue;

                    hVarTotali[rVar["kpro"]] = 1;
                    filter = QHC.AppAnd(QHC.CmpEq("kpro", rVar["kpro"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.incomevarview.Select(filter))
                    {
                        VarAnn["kproceedstransmission"] = DBNull.Value;
                    }
                }

            }

            // in questo quarto ciclo se vi sono righe originariamente scollegate, poi collegate 
            // collega tutte le sorelle
            foreach (DataRow rVar in DS.incomevarview.Select())
            {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kproceedstransmission", DataRowVersion.Original];
                object currVal = rVar["kproceedstransmission", DataRowVersion.Current];

                if ((originalVal == DBNull.Value) && (currVal != DBNull.Value))
                {
                    string filter = "";

                    if (hVarTotali[rVar["kpro"]] != null) continue;

                    hVarTotali[rVar["kpro"]] = 1;
                    filter = QHS.AppAnd(QHS.CmpEq("kpro", rVar["kpro"]), QHS.CmpEq("autokind", 11));
                    // select da db delle var collegate
                    DataTable T = Meta.Conn.RUN_SELECT("incomevarview", "*", null, filter, null, false);
                    if (T == null) continue;

                    foreach (DataRow VarAnn in T.Rows)
                    {
                        string filterRow = QHC.AppAnd(QHC.CmpEq("idinc", VarAnn["idinc"]), QHC.CmpEq("nvar", VarAnn["nvar"]));
                        DataRow[] Found = DS.incomevarview.Select(filterRow);
                        if (Found.Length > 0)
                        {
                            Found[0]["kproceedstransmission"] = currVal;
                        }
                        else
                        {
                            DataRow NewVar = DS.incomevarview.NewRow();
                            foreach (DataColumn C in VarAnn.Table.Columns)
                            {
                                if (DS.incomevarview.Columns.Contains(C.ColumnName)) {
                                    NewVar[C.ColumnName] = VarAnn[C.ColumnName];
                                }
                            }
                            MetaData metaEntrataVarView = Meta.Dispatcher.Get("incomevarview");
                            DS.incomevarview.Rows.Add(NewVar);
                            metaEntrataVarView.CalculateFields(NewVar, "documentitrasmessi");
                            NewVar.AcceptChanges();
                            NewVar["kproceedstransmission"] = currVal;
                        }
                    }
                }
            }
        }

		public void MetaData_AfterClear() {
		    EPM.mostraEtichette();
			btnCollega.Enabled=false;
			btnScollega.Enabled=false;
			btnModifica.Enabled=false;
			txtEsercizio.Text=esercizio.ToString();
			CalcolaDefaultPerIstitutoCassiere();
			txtTotale.Text="";
            
            gBoxTransmissionKind.Visible = true;
            chkTransmissionKind.Enabled = true;
            VisualizzaTabPageVariazioni();
            Meta.UnMarkTableAsNotEntityChild(DS.incomevarview);
		    txtNumero.ReadOnly = false;
		}

		public void MetaData_AfterFill(){
			btnCollega.Enabled=true;
			btnScollega.Enabled=true;
           

			btnModifica.Enabled=true;
            if (Meta.EditMode) {
                btnVisualizzaEP.Enabled = true;  
                txtNumero.ReadOnly = true;
            }
            else {
                btnVisualizzaEP.Enabled = false;
                txtNumero.ReadOnly = false;
            }
			CalcolaTotale();
		    EPM.mostraEtichette();
            if ((Meta.InsertMode)||(Meta.EditMode))
            {
                if ((DS.proceedsview.Rows.Count  > 0 ) ||(DS.incomevarview.Rows.Count > 0 ))
                    chkTransmissionKind.Enabled = false;
                else
                    chkTransmissionKind.Enabled = true;
            }
            VisualizzaTabPageVariazioni();

		}

     

		private void btnModifica_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
            Meta.MarkTableAsNotEntityChild(DS.incomevarview);
			string MyFilter = CalculateFilterForLinking(false);
			string MyFilterSQL = CalculateFilterForLinking(true);
			Meta.MultipleLinkUnlinkRows("Composizione distinta di trasmissione",
				"Reversali incluse nella distinta di trasmissione selezionata", 
				"Reversali non incluse in alcuna distinta di trasmissione",
				DS.proceedsview, MyFilter, MyFilterSQL, "documentitrasmessi");
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
		}

        private void btnModificaVar_Click(object sender, System.EventArgs e)
        {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            Hashtable hVarCollegate = null;
            hVarCollegate = new Hashtable();
            ArrayList arrVarCollegate = null;
            arrVarCollegate = new ArrayList();
            LeggiRigheCollegate(hVarCollegate, arrVarCollegate);
       
            string MyFilter = CalculateFilterForLinkingVar(false);
            string MyFilterSQL = CalculateFilterForLinkingVar(true);
            Meta.MarkTableAsNotEntityChild(DS.incomevarview);
            Meta.MultipleLinkUnlinkRows("Composizione distinta di trasmissione",
                "Variazioni incluse nella distinta di trasmissione selezionata",
                "Variazioni non incluse in alcuna distinta di trasmissione",
                DS.incomevarview, MyFilter, MyFilterSQL, "documentitrasmessi");
            ConfermaRigheCollegate(hVarCollegate, arrVarCollegate);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }

        void AddTab(TabPage Tab, bool redraw)
        {
            if (tabDocumenti.TabPages.Contains(Tab)) return;
            tabDocumenti.TabPages.Add(Tab);
            if (Meta.IsEmpty)
            {
                Meta.myHelpForm.ClearControls(Tab.Controls);
            }
            else
            {
                if (redraw) Meta.myHelpForm.FillControls(Tab.Controls);
            }
        }
        void AddRemoveTab(TabPage Tab, bool Add, bool redraw)
        {
            if (Add)
            {
                AddTab(Tab, redraw);
            }
            else
            {
                if (tabDocumenti.TabPages.Contains(Tab))
                {
                    tabDocumenti.TabPages.Remove(Tab);
                }
            }
        }

        void VisualizzaTabPageVariazioni()
        {
            if (DS.proceedstransmission.Rows.Count == 0)
            {
                AddRemoveTab(tabPageVariazioni, true, false);
                AddRemoveTab(tabPageReversali, true, false);
                return;
            }
           
            if (!chkTransmissionKind.Checked) // I
            {
                AddRemoveTab(tabPageVariazioni, false, false);
                AddRemoveTab(tabPageReversali, true, false);
            }
            else // "V"
            {
                AddRemoveTab(tabPageVariazioni, true, false);
                AddRemoveTab(tabPageReversali, false, false);
            }
        }

		private void CalcolaTotale() {
			if (Meta.IsEmpty) return;
            if (chkTransmissionKind.Checked) return; 
			DataSet MyDS = (DataSet)dataGrid1.DataSource;
			DataTable MyTable = MyDS.Tables[dataGrid1.DataMember.ToString()];
			decimal importo=0;
			importo=MetaData.SumColumn(MyTable, "total");
			txtTotale.Text=importo.ToString("C");
		}

        
       

        private void chkTransmissionKind_CheckedChanged(object sender, EventArgs e)
        {
            VisualizzaTabPageVariazioni();
        }

        private void UnlinkGridRow(DataGrid G, int index)
        {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "incomevarview")
            {
                filter = QHC.AppAnd(QHC.CmpEq("idinc", G[index, 0]), QHC.CmpEq("nvar", G[index, 2]));
                DataRow[] selectresult = DS.incomevarview.Select(filter);
                if (selectresult.Length > 0)
                {
                    DataRow toUnlink = selectresult[0];
                    toUnlink["kproceedstransmission"] = DBNull.Value;
                }
            }
        }

        private void btnScollegaVar_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            Meta.MarkTableAsNotEntityChild(DS.incomevarview);
            int index = dgrVariazioni.CurrentRowIndex;
            if (index < 0) return;
            UnlinkGridRow(dgrVariazioni, index);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }

      
	}
}