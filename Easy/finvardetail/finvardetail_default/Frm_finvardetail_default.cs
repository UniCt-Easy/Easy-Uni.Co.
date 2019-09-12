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
using metaeasylibrary;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione


namespace finvardetail_default//DettaglioVariazionePrevisioneAnnuale//
{
    /// <summary>
    /// Summary description for frmDettaglioVariazionePrevisioneAnnuale.
    /// Revised by Nino on 22/12/2002
    /// Revised by Nino on 9/1/2003
    /// </summary>
    public class Frm_finvardetail_default : System.Windows.Forms.Form {
        private System.Windows.Forms.TextBox txtNumProvv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataProvv;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProvvedimento;
        private System.Windows.Forms.RadioButton rdbVarAssestamento;
        private System.Windows.Forms.RadioButton rdbVarNormale;
        private System.Windows.Forms.RadioButton rdbVarRipartizione;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.RadioButton rdbEntrata;
        private System.Windows.Forms.RadioButton rdbSpesa;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        public vistaForm DS;
        private System.Windows.Forms.Button btnVariazione;
        private System.Windows.Forms.GroupBox groupBox5;
        MetaData Meta;
        string filteresercizio;
        private System.Windows.Forms.GroupBox gboxTipoVariazione;
        private System.Windows.Forms.GroupBox gboxTipoPrevisione;
        private System.Windows.Forms.GroupBox gboxBilancio;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.GroupBox gboxprovvedimento;
        private System.Windows.Forms.RadioButton rdbVarStorno;
        private System.Windows.Forms.CheckBox ckbGenVarDotCassa;
        private System.Windows.Forms.CheckBox ckbGenVarDotCrediti;
        private System.Windows.Forms.CheckBox ckbPrevSecondaria;
        private System.Windows.Forms.CheckBox ckbPrevPrincipale;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label10;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private GroupBox gboxAtto;
        private Button btnScegliAtto;
        private TextBox txtNact;
        private GroupBox gBoxCard;
        private TextBox txtCard;
        private Label label9;
        private TextBox textBox4;
        private GroupBox gBoxUnderWriting;
        private Button btnUnderwriting;
        private TextBox txtUnderwriting;
        private RadioButton rdbVarIniziale;
        private TextBox txtImporto;
        private RadioButton rdbDiminuzione;
        private RadioButton rdbAumento;
        private GroupBox gboxPluriennale;
        private GroupBox gboxanno1;
        private TextBox txtAnno1;
        private GroupBox gboxanno3;
        private TextBox txtAnno3;
        private GroupBox gboxanno2;
        private TextBox txtAnno2;
        private GroupBox grpImporto;
        private GroupBox gboxMovimento;
        private Label labelMovimentoGenerato;
        private CheckBox chkCreateMov;
        private Label label11;
        private TextBox textBox5;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox gBoxResidui;
        private TextBox txtResidui;
        private CheckBox chkDispPresunto;
        private GroupBox gBoxPrecPrev;
        private TextBox txtPreviousPrevision;
        bool inChiusura = false;

        public Frm_finvardetail_default() {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finvardetail_default));
            this.DS = new finvardetail_default.vistaForm();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxAtto = new System.Windows.Forms.GroupBox();
            this.btnScegliAtto = new System.Windows.Forms.Button();
            this.txtNact = new System.Windows.Forms.TextBox();
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxprovvedimento = new System.Windows.Forms.GroupBox();
            this.txtProvvedimento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumProvv = new System.Windows.Forms.TextBox();
            this.txtDataProvv = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.btnVariazione = new System.Windows.Forms.Button();
            this.gboxTipoVariazione = new System.Windows.Forms.GroupBox();
            this.rdbVarIniziale = new System.Windows.Forms.RadioButton();
            this.rdbVarStorno = new System.Windows.Forms.RadioButton();
            this.rdbVarAssestamento = new System.Windows.Forms.RadioButton();
            this.rdbVarNormale = new System.Windows.Forms.RadioButton();
            this.rdbVarRipartizione = new System.Windows.Forms.RadioButton();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxTipoPrevisione = new System.Windows.Forms.GroupBox();
            this.ckbGenVarDotCassa = new System.Windows.Forms.CheckBox();
            this.ckbGenVarDotCrediti = new System.Windows.Forms.CheckBox();
            this.ckbPrevSecondaria = new System.Windows.Forms.CheckBox();
            this.ckbPrevPrincipale = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gBoxCard = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.gBoxUnderWriting = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnUnderwriting = new System.Windows.Forms.Button();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
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
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.gboxMovimento = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelMovimentoGenerato = new System.Windows.Forms.Label();
            this.chkCreateMov = new System.Windows.Forms.CheckBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.chkDispPresunto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.gboxAtto.SuspendLayout();
            this.gboxStato.SuspendLayout();
            this.gboxprovvedimento.SuspendLayout();
            this.gboxTipoVariazione.SuspendLayout();
            this.gboxTipoPrevisione.SuspendLayout();
            this.gboxBilancio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gBoxCard.SuspendLayout();
            this.gBoxUnderWriting.SuspendLayout();
            this.gboxPluriennale.SuspendLayout();
            this.gBoxPrecPrev.SuspendLayout();
            this.gBoxResidui.SuspendLayout();
            this.gboxanno1.SuspendLayout();
            this.gboxanno3.SuspendLayout();
            this.gboxanno2.SuspendLayout();
            this.grpImporto.SuspendLayout();
            this.gboxMovimento.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.gboxResponsabile);
            this.groupBox5.Controls.Add(this.gboxAtto);
            this.groupBox5.Controls.Add(this.gboxStato);
            this.groupBox5.Controls.Add(this.txtDataContabile);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.gboxprovvedimento);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtEsercizio);
            this.groupBox5.Controls.Add(this.btnVariazione);
            this.groupBox5.Controls.Add(this.gboxTipoVariazione);
            this.groupBox5.Controls.Add(this.txtDescrizione);
            this.groupBox5.Controls.Add(this.gboxTipoPrevisione);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(4, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(967, 182);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtNumero.default";
            this.groupBox5.Text = "Dati variazione";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(663, 127);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(298, 40);
            this.gboxResponsabile.TabIndex = 6;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(11, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(277, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // gboxAtto
            // 
            this.gboxAtto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxAtto.Controls.Add(this.btnScegliAtto);
            this.gboxAtto.Controls.Add(this.txtNact);
            this.gboxAtto.Location = new System.Drawing.Point(663, 79);
            this.gboxAtto.Name = "gboxAtto";
            this.gboxAtto.Size = new System.Drawing.Size(295, 44);
            this.gboxAtto.TabIndex = 4;
            this.gboxAtto.TabStop = false;
            this.gboxAtto.Tag = "AutoChoose.txtNact.default";
            // 
            // btnScegliAtto
            // 
            this.btnScegliAtto.Location = new System.Drawing.Point(6, 15);
            this.btnScegliAtto.Name = "btnScegliAtto";
            this.btnScegliAtto.Size = new System.Drawing.Size(133, 23);
            this.btnScegliAtto.TabIndex = 13;
            this.btnScegliAtto.TabStop = false;
            this.btnScegliAtto.Tag = "choose.enactment.default";
            this.btnScegliAtto.Text = "Atto Amministrativo";
            this.btnScegliAtto.UseVisualStyleBackColor = true;
            // 
            // txtNact
            // 
            this.txtNact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNact.Location = new System.Drawing.Point(145, 15);
            this.txtNact.Name = "txtNact";
            this.txtNact.Size = new System.Drawing.Size(143, 20);
            this.txtNact.TabIndex = 10;
            this.txtNact.Tag = "enactment.nenactment?finvardetailview.enactmentnumber";
            // 
            // gboxStato
            // 
            this.gboxStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxStato.Controls.Add(this.cmbStatus);
            this.gboxStato.Location = new System.Drawing.Point(663, 8);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(295, 44);
            this.gboxStato.TabIndex = 1;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DataSource = this.DS.finvarstatus;
            this.cmbStatus.DisplayMember = "description";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(6, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(282, 21);
            this.cmbStatus.TabIndex = 43;
            this.cmbStatus.Tag = "finvar.idfinvarstatus?finvardetailview.idfinvarstatus";
            this.cmbStatus.ValueMember = "idfinvarstatus";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(871, 58);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 19;
            this.txtDataContabile.TabStop = false;
            this.txtDataContabile.Tag = "finvar.adate";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(217, 78);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "finvar.nvar?finvardetailview.nvar";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(161, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxprovvedimento
            // 
            this.gboxprovvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxprovvedimento.Controls.Add(this.txtProvvedimento);
            this.gboxprovvedimento.Controls.Add(this.label7);
            this.gboxprovvedimento.Controls.Add(this.txtNumProvv);
            this.gboxprovvedimento.Controls.Add(this.txtDataProvv);
            this.gboxprovvedimento.Controls.Add(this.label6);
            this.gboxprovvedimento.Location = new System.Drawing.Point(295, 79);
            this.gboxprovvedimento.Name = "gboxprovvedimento";
            this.gboxprovvedimento.Size = new System.Drawing.Size(362, 94);
            this.gboxprovvedimento.TabIndex = 3;
            this.gboxprovvedimento.TabStop = false;
            this.gboxprovvedimento.Text = "Provvedimento";
            // 
            // txtProvvedimento
            // 
            this.txtProvvedimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvvedimento.Location = new System.Drawing.Point(8, 16);
            this.txtProvvedimento.Multiline = true;
            this.txtProvvedimento.Name = "txtProvvedimento";
            this.txtProvvedimento.ReadOnly = true;
            this.txtProvvedimento.Size = new System.Drawing.Size(348, 40);
            this.txtProvvedimento.TabIndex = 1;
            this.txtProvvedimento.TabStop = false;
            this.txtProvvedimento.Tag = "finvar.enactment";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(144, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Num. provv";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumProvv
            // 
            this.txtNumProvv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumProvv.Location = new System.Drawing.Point(208, 64);
            this.txtNumProvv.Name = "txtNumProvv";
            this.txtNumProvv.ReadOnly = true;
            this.txtNumProvv.Size = new System.Drawing.Size(148, 20);
            this.txtNumProvv.TabIndex = 3;
            this.txtNumProvv.TabStop = false;
            this.txtNumProvv.Tag = "finvar.nenactment";
            // 
            // txtDataProvv
            // 
            this.txtDataProvv.Location = new System.Drawing.Point(72, 64);
            this.txtDataProvv.Name = "txtDataProvv";
            this.txtDataProvv.ReadOnly = true;
            this.txtDataProvv.Size = new System.Drawing.Size(70, 20);
            this.txtDataProvv.TabIndex = 2;
            this.txtDataProvv.TabStop = false;
            this.txtDataProvv.Tag = "finvar.enactmentdate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(5, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Data provv";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(779, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(68, 76);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 5;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVariazione
            // 
            this.btnVariazione.Location = new System.Drawing.Point(16, 16);
            this.btnVariazione.Name = "btnVariazione";
            this.btnVariazione.Size = new System.Drawing.Size(72, 23);
            this.btnVariazione.TabIndex = 1;
            this.btnVariazione.TabStop = false;
            this.btnVariazione.Tag = "choose.finvar.default";
            this.btnVariazione.Text = "Variazione";
            // 
            // gboxTipoVariazione
            // 
            this.gboxTipoVariazione.Controls.Add(this.rdbVarIniziale);
            this.gboxTipoVariazione.Controls.Add(this.rdbVarStorno);
            this.gboxTipoVariazione.Controls.Add(this.rdbVarAssestamento);
            this.gboxTipoVariazione.Controls.Add(this.rdbVarNormale);
            this.gboxTipoVariazione.Controls.Add(this.rdbVarRipartizione);
            this.gboxTipoVariazione.Location = new System.Drawing.Point(100, 8);
            this.gboxTipoVariazione.Name = "gboxTipoVariazione";
            this.gboxTipoVariazione.Size = new System.Drawing.Size(241, 65);
            this.gboxTipoVariazione.TabIndex = 3;
            this.gboxTipoVariazione.TabStop = false;
            this.gboxTipoVariazione.Text = "Tipo variazione";
            // 
            // rdbVarIniziale
            // 
            this.rdbVarIniziale.AutoSize = true;
            this.rdbVarIniziale.Location = new System.Drawing.Point(101, 44);
            this.rdbVarIniziale.Name = "rdbVarIniziale";
            this.rdbVarIniziale.Size = new System.Drawing.Size(57, 17);
            this.rdbVarIniziale.TabIndex = 5;
            this.rdbVarIniziale.Tag = "finvar.variationkind:5?finvardetailview.variationkind:5";
            this.rdbVarIniziale.Text = "Iniziale";
            this.rdbVarIniziale.UseVisualStyleBackColor = true;
            // 
            // rdbVarStorno
            // 
            this.rdbVarStorno.Location = new System.Drawing.Point(101, 11);
            this.rdbVarStorno.Name = "rdbVarStorno";
            this.rdbVarStorno.Size = new System.Drawing.Size(96, 16);
            this.rdbVarStorno.TabIndex = 4;
            this.rdbVarStorno.Tag = "finvar.variationkind:4?finvardetailview.variationkind:4";
            this.rdbVarStorno.Text = "Storno";
            // 
            // rdbVarAssestamento
            // 
            this.rdbVarAssestamento.Location = new System.Drawing.Point(101, 28);
            this.rdbVarAssestamento.Name = "rdbVarAssestamento";
            this.rdbVarAssestamento.Size = new System.Drawing.Size(96, 16);
            this.rdbVarAssestamento.TabIndex = 2;
            this.rdbVarAssestamento.Tag = "finvar.variationkind:3?finvardetailview.variationkind:3";
            this.rdbVarAssestamento.Text = "Assestamento";
            // 
            // rdbVarNormale
            // 
            this.rdbVarNormale.Location = new System.Drawing.Point(8, 16);
            this.rdbVarNormale.Name = "rdbVarNormale";
            this.rdbVarNormale.Size = new System.Drawing.Size(85, 16);
            this.rdbVarNormale.TabIndex = 0;
            this.rdbVarNormale.Tag = "finvar.variationkind:1?finvardetailview.variationkind:1";
            this.rdbVarNormale.Text = "Normale";
            // 
            // rdbVarRipartizione
            // 
            this.rdbVarRipartizione.Location = new System.Drawing.Point(8, 32);
            this.rdbVarRipartizione.Name = "rdbVarRipartizione";
            this.rdbVarRipartizione.Size = new System.Drawing.Size(85, 16);
            this.rdbVarRipartizione.TabIndex = 1;
            this.rdbVarRipartizione.Tag = "finvar.variationkind:2?finvardetailview.variationkind:2";
            this.rdbVarRipartizione.Text = "Ripartizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(7, 118);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(282, 55);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "finvar.description";
            // 
            // gboxTipoPrevisione
            // 
            this.gboxTipoPrevisione.Controls.Add(this.ckbGenVarDotCassa);
            this.gboxTipoPrevisione.Controls.Add(this.ckbGenVarDotCrediti);
            this.gboxTipoPrevisione.Controls.Add(this.ckbPrevSecondaria);
            this.gboxTipoPrevisione.Controls.Add(this.ckbPrevPrincipale);
            this.gboxTipoPrevisione.Location = new System.Drawing.Point(352, 8);
            this.gboxTipoPrevisione.Name = "gboxTipoPrevisione";
            this.gboxTipoPrevisione.Size = new System.Drawing.Size(288, 65);
            this.gboxTipoPrevisione.TabIndex = 4;
            this.gboxTipoPrevisione.TabStop = false;
            this.gboxTipoPrevisione.Text = "Tipo previsione";
            // 
            // ckbGenVarDotCassa
            // 
            this.ckbGenVarDotCassa.Location = new System.Drawing.Point(139, 33);
            this.ckbGenVarDotCassa.Name = "ckbGenVarDotCassa";
            this.ckbGenVarDotCassa.Size = new System.Drawing.Size(143, 22);
            this.ckbGenVarDotCassa.TabIndex = 19;
            this.ckbGenVarDotCassa.TabStop = false;
            this.ckbGenVarDotCassa.Tag = "finvar.flagproceeds:S:N?finvardetailview.flagproceeds:S:N";
            this.ckbGenVarDotCassa.Text = "Variazione dotaz. cassa";
            // 
            // ckbGenVarDotCrediti
            // 
            this.ckbGenVarDotCrediti.Location = new System.Drawing.Point(139, 9);
            this.ckbGenVarDotCrediti.Name = "ckbGenVarDotCrediti";
            this.ckbGenVarDotCrediti.Size = new System.Drawing.Size(143, 24);
            this.ckbGenVarDotCrediti.TabIndex = 18;
            this.ckbGenVarDotCrediti.TabStop = false;
            this.ckbGenVarDotCrediti.Tag = "finvar.flagcredit:S:N?finvardetailview.flagcredit:S:N";
            this.ckbGenVarDotCrediti.Text = "Variazione dotaz. crediti";
            // 
            // ckbPrevSecondaria
            // 
            this.ckbPrevSecondaria.Location = new System.Drawing.Point(6, 34);
            this.ckbPrevSecondaria.Name = "ckbPrevSecondaria";
            this.ckbPrevSecondaria.Size = new System.Drawing.Size(112, 16);
            this.ckbPrevSecondaria.TabIndex = 17;
            this.ckbPrevSecondaria.TabStop = false;
            this.ckbPrevSecondaria.Tag = "finvar.flagsecondaryprev:S:N?finvardetailview.flagsecondaryprev:S:N";
            // 
            // ckbPrevPrincipale
            // 
            this.ckbPrevPrincipale.Location = new System.Drawing.Point(6, 12);
            this.ckbPrevPrincipale.Name = "ckbPrevPrincipale";
            this.ckbPrevPrincipale.Size = new System.Drawing.Size(112, 16);
            this.ckbPrevPrincipale.TabIndex = 16;
            this.ckbPrevPrincipale.TabStop = false;
            this.ckbPrevPrincipale.Tag = "finvar.flagprevision:S:N?finvardetailview.flagprevision:S:N";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrizione Variazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Controls.Add(this.chkListTitle);
            this.gboxBilancio.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancio.Controls.Add(this.txtBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Controls.Add(this.rdbEntrata);
            this.gboxBilancio.Controls.Add(this.rdbSpesa);
            this.gboxBilancio.Location = new System.Drawing.Point(424, 185);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(422, 103);
            this.gboxBilancio.TabIndex = 2;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "";
            this.gboxBilancio.Text = "Bilancio";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 33);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(151, 16);
            this.chkListTitle.TabIndex = 33;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(165, 14);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(251, 56);
            this.txtDescrBilancio.TabIndex = 32;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(2, 76);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(409, 20);
            this.txtBilancio.TabIndex = 6;
            this.txtBilancio.Tag = "finview.codefin?finvardetailview.codefin";
            this.txtBilancio.Leave += new System.EventHandler(this.txtBilancio_Leave);
            // 
            // btnBilancio
            // 
            this.btnBilancio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(2, 50);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 20);
            this.btnBilancio.TabIndex = 5;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(5, 15);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 0;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?finvardetailview.finpart:E";
            this.rdbEntrata.Text = "Entrata";
            this.rdbEntrata.CheckedChanged += new System.EventHandler(this.rdbEntrata_CheckedChanged);
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(85, 15);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 1;
            this.rdbSpesa.Tag = "finview.finpart:S?finvardetailview.finpart:S";
            this.rdbSpesa.Text = "Spesa";
            this.rdbSpesa.CheckedChanged += new System.EventHandler(this.rdbSpesa_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(328, 298);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 52);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "finvardetail.description";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(261, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Descrizione:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(3, 469);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 72);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestione interfaccia web";
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
            this.textBox2.Size = new System.Drawing.Size(621, 50);
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
            // gBoxCard
            // 
            this.gBoxCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxCard.Controls.Add(this.textBox4);
            this.gBoxCard.Controls.Add(this.label9);
            this.gBoxCard.Controls.Add(this.txtCard);
            this.gBoxCard.Location = new System.Drawing.Point(661, 291);
            this.gBoxCard.Name = "gBoxCard";
            this.gBoxCard.Size = new System.Drawing.Size(304, 64);
            this.gBoxCard.TabIndex = 5;
            this.gBoxCard.TabStop = false;
            this.gBoxCard.Tag = "";
            this.gBoxCard.Text = "Card";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(112, 12);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(187, 41);
            this.textBox4.TabIndex = 22;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "lcard.title";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(5, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Num. card";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCard
            // 
            this.txtCard.Location = new System.Drawing.Point(10, 35);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(96, 20);
            this.txtCard.TabIndex = 3;
            this.txtCard.Tag = "finvardetail.idlcard";
            // 
            // gBoxUnderWriting
            // 
            this.gBoxUnderWriting.Controls.Add(this.txtUnderwriting);
            this.gBoxUnderWriting.Controls.Add(this.btnUnderwriting);
            this.gBoxUnderWriting.Location = new System.Drawing.Point(4, 355);
            this.gBoxUnderWriting.Name = "gBoxUnderWriting";
            this.gBoxUnderWriting.Size = new System.Drawing.Size(445, 43);
            this.gBoxUnderWriting.TabIndex = 6;
            this.gBoxUnderWriting.TabStop = false;
            this.gBoxUnderWriting.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(121, 16);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(316, 20);
            this.txtUnderwriting.TabIndex = 2;
            this.txtUnderwriting.Tag = "underwriting.title?finvardetailview.underwriting";
            // 
            // btnUnderwriting
            // 
            this.btnUnderwriting.Location = new System.Drawing.Point(11, 14);
            this.btnUnderwriting.Name = "btnUnderwriting";
            this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
            this.btnUnderwriting.TabIndex = 0;
            this.btnUnderwriting.TabStop = false;
            this.btnUnderwriting.Tag = "choose.underwriting.default";
            this.btnUnderwriting.Text = "Finanziamento";
            this.btnUnderwriting.UseVisualStyleBackColor = true;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(7, 19);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(120, 20);
            this.txtImporto.TabIndex = 3;
            this.txtImporto.Tag = "finvardetail.amount";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbDiminuzione.Location = new System.Drawing.Point(154, 32);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(91, 16);
            this.rdbDiminuzione.TabIndex = 2;
            this.rdbDiminuzione.TabStop = true;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(154, 14);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(80, 16);
            this.rdbAumento.TabIndex = 1;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // gboxPluriennale
            // 
            this.gboxPluriennale.Controls.Add(this.gBoxPrecPrev);
            this.gboxPluriennale.Controls.Add(this.gBoxResidui);
            this.gboxPluriennale.Controls.Add(this.gboxanno1);
            this.gboxPluriennale.Controls.Add(this.gboxanno3);
            this.gboxPluriennale.Controls.Add(this.gboxanno2);
            this.gboxPluriennale.Location = new System.Drawing.Point(4, 405);
            this.gboxPluriennale.Name = "gboxPluriennale";
            this.gboxPluriennale.Size = new System.Drawing.Size(958, 58);
            this.gboxPluriennale.TabIndex = 8;
            this.gboxPluriennale.TabStop = false;
            this.gboxPluriennale.Text = "Informazioni utili ai fini della redazione del bilancio di previsione";
            // 
            // gBoxPrecPrev
            // 
            this.gBoxPrecPrev.Controls.Add(this.txtPreviousPrevision);
            this.gBoxPrecPrev.Location = new System.Drawing.Point(750, 13);
            this.gBoxPrecPrev.Name = "gBoxPrecPrev";
            this.gBoxPrecPrev.Size = new System.Drawing.Size(199, 39);
            this.gBoxPrecPrev.TabIndex = 11;
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
            this.gBoxResidui.Location = new System.Drawing.Point(379, 15);
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
            // grpImporto
            // 
            this.grpImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(4, 298);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(251, 52);
            this.grpImporto.TabIndex = 3;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "finvardetail.amount.valuesigned";
            this.grpImporto.Text = "Importo";
            // 
            // gboxMovimento
            // 
            this.gboxMovimento.Controls.Add(this.label11);
            this.gboxMovimento.Controls.Add(this.textBox5);
            this.gboxMovimento.Controls.Add(this.labelMovimentoGenerato);
            this.gboxMovimento.Controls.Add(this.chkCreateMov);
            this.gboxMovimento.Location = new System.Drawing.Point(464, 356);
            this.gboxMovimento.Name = "gboxMovimento";
            this.gboxMovimento.Size = new System.Drawing.Size(501, 46);
            this.gboxMovimento.TabIndex = 7;
            this.gboxMovimento.TabStop = false;
            this.gboxMovimento.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(387, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "N.";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(411, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 20);
            this.textBox5.TabIndex = 2;
            this.textBox5.Tag = "expenseview.nmov?finvardetailview.nmov";
            // 
            // labelMovimentoGenerato
            // 
            this.labelMovimentoGenerato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMovimentoGenerato.Location = new System.Drawing.Point(287, 16);
            this.labelMovimentoGenerato.Name = "labelMovimentoGenerato";
            this.labelMovimentoGenerato.Size = new System.Drawing.Size(95, 23);
            this.labelMovimentoGenerato.TabIndex = 1;
            this.labelMovimentoGenerato.Tag = "expenseview.phase";
            this.labelMovimentoGenerato.Text = "Movimento";
            this.labelMovimentoGenerato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCreateMov
            // 
            this.chkCreateMov.Location = new System.Drawing.Point(12, 15);
            this.chkCreateMov.Name = "chkCreateMov";
            this.chkCreateMov.Size = new System.Drawing.Size(199, 27);
            this.chkCreateMov.TabIndex = 0;
            this.chkCreateMov.Tag = "finvardetail.createexpense:S:N";
            this.chkCreateMov.Text = "Richiedi generazione movimento";
            this.chkCreateMov.UseVisualStyleBackColor = true;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(3, 184);
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
            // chkDispPresunto
            // 
            this.chkDispPresunto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDispPresunto.AutoSize = true;
            this.chkDispPresunto.Location = new System.Drawing.Point(856, 268);
            this.chkDispPresunto.Name = "chkDispPresunto";
            this.chkDispPresunto.Size = new System.Drawing.Size(106, 17);
            this.chkDispPresunto.TabIndex = 31;
            this.chkDispPresunto.Tag = "finvar.varflag:0?finvardetailview.varflag:0";
            this.chkDispPresunto.Text = "Avanzo presunto";
            this.chkDispPresunto.UseVisualStyleBackColor = true;
            // 
            // Frm_finvardetail_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(972, 542);
            this.Controls.Add(this.chkDispPresunto);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxMovimento);
            this.Controls.Add(this.gboxPluriennale);
            this.Controls.Add(this.gBoxUnderWriting);
            this.Controls.Add(this.gBoxCard);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpImporto);
            this.Controls.Add(this.gboxBilancio);
            this.Controls.Add(this.label8);
            this.Name = "Frm_finvardetail_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDettaglioVariazionePrevisioneAnnuale";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.gboxAtto.ResumeLayout(false);
            this.gboxAtto.PerformLayout();
            this.gboxStato.ResumeLayout(false);
            this.gboxprovvedimento.ResumeLayout(false);
            this.gboxprovvedimento.PerformLayout();
            this.gboxTipoVariazione.ResumeLayout(false);
            this.gboxTipoVariazione.PerformLayout();
            this.gboxTipoPrevisione.ResumeLayout(false);
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gBoxCard.ResumeLayout(false);
            this.gBoxCard.PerformLayout();
            this.gBoxUnderWriting.ResumeLayout(false);
            this.gBoxUnderWriting.PerformLayout();
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
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.gboxMovimento.ResumeLayout(false);
            this.gboxMovimento.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filteresercvar = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.finview, filteresercizio);
            GetData.SetStaticFilter(DS.finvar, filteresercvar);
            GetData.SetStaticFilter(DS.finvardetail, filteresercvar);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.SetStaticFilter(DS.enactment, QHS.CmpEq("yenactment", Meta.Conn.GetSys("esercizio")));
            //Come defualt visualizziamo i grp dell'importo
            grpImporto.Visible = true;
            gboxPluriennale.Visible = false;
            gboxMovimento.Visible = false;
            HelpForm.SetDenyNull(DS.Tables["finvardetail"].Columns["createexpense"], true);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
        }

        int varkind = 0;
        bool isprev_iniziale() {
            return (varkind == 5);
        }

        public void MetaData_AfterClear() {
            gboxTipoVariazione.Enabled = true;
            gboxTipoPrevisione.Enabled = true;
            gboxResponsabile.Enabled = true;
            gboxAtto.Enabled = true;
            gboxStato.Enabled = true;
            gBoxCard.Enabled = true;
            rdbSpesa.Enabled = true;
            rdbEntrata.Enabled = true;
            btnBilancio.Enabled = true;

            txtBilancio.ReadOnly = false;
            btnUPBCode.Enabled = true;
            txtUPB.ReadOnly = false;
            gBoxUnderWriting.Enabled = true;
            SetFilterFinView();

            //Visualizza il default e reimposta i Tag.
            grpImporto.Visible = true;
            gboxPluriennale.Visible = false;
            txtImporto.Text = "";
            rdbAumento.Checked = false;
            rdbDiminuzione.Checked = false;
            rdbAumento.Tag = "+";
            rdbDiminuzione.Tag = "-";
            grpImporto.Tag = "finvardetail.amount.valuesigned";
            txtImporto.Tag = "finvardetail.amount";

            gboxMovimento.Visible = true;
            gboxMovimento.Enabled = true;
            chkCreateMov.Enabled = true;

        }

        public void MetaData_AfterActivation() {
            if (DS.Tables["config"].Rows.Count == 0) return;
            DataRow R = DS.config.Rows[0];

            string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
            if (nomeprevsecondaria == null) {
                ckbPrevSecondaria.Tag = "";
                ckbPrevPrincipale.Checked = true;
                ckbPrevSecondaria.Visible = false;
                //				gboxTipoPrevisione.Visible=false;
            }
            else {
                ckbPrevSecondaria.Text = nomeprevsecondaria;
            }

            ckbPrevPrincipale.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) {
                if (T.TableName == "finvar") {
                    gboxTipoVariazione.Enabled = R == null;
                    gboxTipoPrevisione.Enabled = R == null;
                    gboxStato.Enabled = R == null;
                    gboxprovvedimento.Enabled = R == null;
                    gboxResponsabile.Enabled = R == null;
                    gboxAtto.Enabled = R == null;
                    gBoxCard.Enabled = R == null;
                }
            }

            if (T.TableName == "upb") {
                string idupb = "0001";// "0001"; 
                if (R != null)
                    idupb = R["idupb"].ToString();
                MetaData.AutoInfo AI;
                AI = Meta.GetAutoInfo(txtBilancio.Name);
                string filter = QHS.CmpEq("idupb", idupb);
                if (AI != null)
                    AI.startfilter = filter;
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                SetFilterFinView();

            }
        }
        public void MetaData_BeforeFill() {
            if (!Meta.IsEmpty) {
                DataRow rFinvar = DS.finvar.Rows[0];
                varkind = CfgFn.GetNoNullInt32(rFinvar["variationkind"]);
            }
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
            }
            else {
                grpImporto.Visible = true;
                gboxPluriennale.Visible = false;
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
                rdbAumento.Tag = "+";
                rdbDiminuzione.Tag = "-";
                grpImporto.Tag = "finvardetail.amount.valuesigned";
                txtImporto.Tag = "finvardetail.amount";

                txtDescrizione.Focus();
            }
        }

        public void MetaData_AfterFill() {
            if (!Meta.IsEmpty) {
                gboxTipoVariazione.Enabled = false;
                gboxTipoPrevisione.Enabled = false;
                gboxResponsabile.Enabled = false;
                gboxAtto.Enabled = false;
                gboxStato.Enabled = false;
                gBoxCard.Enabled = false;
                gboxMovimento.Enabled = true;
                rdbSpesa.Enabled = false;
                rdbEntrata.Enabled = false;

                if (isprev_iniziale() && rdbSpesa.Checked) {
                    gboxMovimento.Visible = true;
                    if (DS.finvardetail.Rows[0]["idexp"].ToString() != "") {
                        chkCreateMov.Enabled = false;
                    }
                    else {
                        chkCreateMov.Enabled = true;
                    }
                }
                else {
                    gboxMovimento.Visible = false;
                }
            }

            if (Meta.EditMode) {
                chkListTitle.Enabled = false;
                gBoxUnderWriting.Enabled = false;
                btnBilancio.Enabled = false;
                txtBilancio.ReadOnly = true;
                btnUPBCode.Enabled = false;
                txtUPB.ReadOnly = true;


            }
            else {
                chkListTitle.Enabled = true;
                gBoxUnderWriting.Enabled = true;
                btnBilancio.Enabled = true;
                txtBilancio.ReadOnly = false;
                btnUPBCode.Enabled = true;
                txtUPB.ReadOnly = false;
            }
            SetFilterFinView();

        }


        private void rdbEntrata_CheckedChanged(object sender, System.EventArgs e) {
            //			if (rdbEntrata.Checked){
            //				btnBilancio.Tag="manage.finview.treeE";//+".(esercizio="+MetaData.GetConnection(this).sys["esercizio"].ToString()+")";
            //				gboxBilancio.Tag="AutoManage.txtBilancio.treeE";//+".(esercizio="+MetaData.GetConnection(this).sys["esercizio"].ToString()+")";
            //			}
            //			if (Meta.DrawState!= MetaData.form_drawstates.done)return;
            //			txtBilancio.Text="";
            //			txtDescrBilancio.Text="";
            //			DS.finview.Clear();
            //			if (Meta.IsEmpty) return;
            //			if (DS.finvardetail.Rows[0]["idfin"].ToString()!="")
            //			{
            //				DS.finvardetail.Rows[0]["idfin"]="";
            //			}
        }

        private void rdbSpesa_CheckedChanged(object sender, System.EventArgs e) {
            //			if (rdbSpesa.Checked){
            //				btnBilancio.Tag="manage.finview.treeS";//+".(esercizio="+MetaData.GetConnection(this).sys["esercizio"].ToString()+")";
            //				gboxBilancio.Tag="AutoManage.txtBilancio.treeS";//+".(esercizio="+MetaData.GetConnection(this).sys["esercizio"].ToString()+")";
            //			}
            //			if (Meta.DrawState!= MetaData.form_drawstates.done)return;
            //			txtBilancio.Text="";
            //			txtDescrBilancio.Text="";
            //			DS.finview.Clear();
            //			if (Meta.IsEmpty) return;
            //			if (DS.finvardetail.Rows[0]["idfin"].ToString()!="")
            //			{
            //				DS.finvardetail.Rows[0]["idfin"]="";
            //			}
        }



        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "";
            if (rdbSpesa.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'));
            if (rdbEntrata.Checked)
                filteridfin = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'E'));

            //Il filtro sull'UPB c'è sempre
            object idupb = Meta.GetAutoField(txtUPB);
            if (idupb != DBNull.Value) {
                filter = QHS.CmpEq("idupb", idupb);
            }
            else {
                filter = QHS.CmpEq("idupb", "0001");
            }
            filter = QHS.AppAnd(filteridfin, filter);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            if (rdbSpesa.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treesupb");
            if (rdbEntrata.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treeeupb");
        }

        private void txtBilancio_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if ((Meta.EditMode) && txtBilancio.ReadOnly) return;
                DataRow Curr = null;
            if (DS.finvardetail.Rows.Count > 0) Curr = DS.finvardetail.Rows[0];
            if (txtBilancio.Text.Trim() == "") {
                SvuotaFinView();
                if (Curr != null) Curr["idfin"] = 0;
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
            if (idupb != DBNull.Value) {
                filterUpb = QHS.CmpEq("idupb", idupb);
            }
            else {
                filterUpb = QHS.CmpEq("idupb", "0001");
            }

            string filtro = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", finpart), filterUpb);
            MetaData MetaBilancio = MetaData.GetMetaData(this, "finview");
            MetaBilancio.FilterLocked = true;
            MetaBilancio.SearchEnabled = false;
            MetaBilancio.MainSelectionEnabled = true;
            MetaBilancio.StartFilter = filtro;
            MetaBilancio.ExtraParameter = filtro;
            MetaBilancio.startFieldWanted = "codefin";
            MetaBilancio.startValueWanted = null;

            MetaBilancio.startValueWanted = txtBilancio.Text.Trim();
            string startfield = MetaBilancio.startFieldWanted;
            string startvalue = MetaBilancio.startValueWanted;
            DataRow rFin = null;
            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                rFin = MetaBilancio.SelectByCondition(filter2, "finview");
            }

            if (rFin == null) {
                string edittype = "tree" + finpart.ToLower() + "upb";
                bool res = MetaBilancio.Edit(this, edittype, true);
                if (!res) {
                    SvuotaFinView();
                    if (Curr != null) Curr["idfin"] = DBNull.Value;
                    return;
                }
                rFin = MetaBilancio.LastSelectedRow;
            }
            if (Curr != null) Curr["idfin"] = rFin["idfin"];

            if (rFin != null) {
                SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("idupb", rFin["idupb"]), QHS.CmpEq("ayear", rFin["ayear"]));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.finview, null, filter, null, false);
            }
            Meta.FreshForm(gboxBilancio.Controls, true, "finview");
            if (!(Meta.InsertMode || Meta.EditMode)) {
                txtBilancio.Text = rFin["codefin"].ToString();
                txtDescrBilancio.Text = rFin["title"].ToString();
                if (rFin["finpart"].ToString() == "S") {
                    rdbSpesa.Checked = true;
                }
                else {
                    rdbEntrata.Checked = true;
                }
            }
        }
        private void SvuotaFinView() {
            txtBilancio.Text = "";
            txtDescrBilancio.Text = "";
            DS.finview.Clear();
        }

        private void SetFilterFinView() {
            string filter;
            object idupb = Meta.GetAutoField(txtUPB);
            if (idupb != DBNull.Value) {
                filter = QHS.CmpEq("idupb", idupb);
            }
            else {
                filter = QHS.CmpEq("idupb", "0001");
            }
            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, filter));
        }

    }
}
