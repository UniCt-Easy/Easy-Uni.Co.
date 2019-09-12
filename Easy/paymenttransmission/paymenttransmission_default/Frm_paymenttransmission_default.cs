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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;

namespace paymenttransmission_default { //trasmdocpagamento//
    /// <summary>
    /// Summary description for frmtrasmdocpagamento.
    /// Revised By Nino on 9/3/2003 (adjusted filter of combos)
    /// </summary>
    public class Frm_paymenttransmission_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ComboBox cmbCodiceIstituto;
        private System.Windows.Forms.Button btnIstitutoCassiere;
        private System.Windows.Forms.ComboBox cmbResponsabile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataTrasmissione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        public vistaForm DS;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MetaData Meta;
        private System.Windows.Forms.GroupBox groupBox3;
        private Crownwood.Magic.Controls.TabControl tabControl1;
        private Crownwood.Magic.Controls.TabPage tabPrincipale;
        private Crownwood.Magic.Controls.TabPage tabEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private GroupBox gBoxNotifiche;
        private CheckBox chkFlagMailSent;
        private Button btnSendNotification;
        private TabControl tabDocumenti;
        private TabPage tabPageMandati;
        private GroupBox groupBox2;
        private TextBox txtTotale;
        private Label label4;
        private Button btnModifica;
        private Button btnScollega;
        private DataGrid dataGrid1;
        private Button btnCollega;
        private TabPage tabPageVariazioni;
        private GroupBox groupBox4;
        private Button btnModificaVar;
        private Button btnScollegaVar;
        private DataGrid dgrVariazioni;
        private Button btnCollegaVar;
        private GroupBox gBoxTransmissionKind;
        private CheckBox chkTransmissionKind;
        private ProgressBar progressBarImport;
        private Label lblNotifiche;
        private Button btnGeneraEP;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox8;
        private Label label6;
        private CheckBox checkBox1;
        private Label labEPDisabilitato;
        bool flagtrasmresponsabile;

        public Frm_paymenttransmission_default() {
            InitializeComponent();
            QueryCreator.SetTableForPosting(DS.paymentview, "payment");
            QueryCreator.SetTableForPosting(DS.expensevarview, "expensevar");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
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
            this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
            this.DS = new paymenttransmission_default.vistaForm();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataTrasmissione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPrincipale = new Crownwood.Magic.Controls.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblNotifiche = new System.Windows.Forms.Label();
            this.progressBarImport = new System.Windows.Forms.ProgressBar();
            this.gBoxTransmissionKind = new System.Windows.Forms.GroupBox();
            this.chkTransmissionKind = new System.Windows.Forms.CheckBox();
            this.tabDocumenti = new System.Windows.Forms.TabControl();
            this.tabPageMandati = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnScollega = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnCollega = new System.Windows.Forms.Button();
            this.tabPageVariazioni = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnModificaVar = new System.Windows.Forms.Button();
            this.btnScollegaVar = new System.Windows.Forms.Button();
            this.dgrVariazioni = new System.Windows.Forms.DataGrid();
            this.btnCollegaVar = new System.Windows.Forms.Button();
            this.gBoxNotifiche = new System.Windows.Forms.GroupBox();
            this.chkFlagMailSent = new System.Windows.Forms.CheckBox();
            this.btnSendNotification = new System.Windows.Forms.Button();
            this.tabEP = new Crownwood.Magic.Controls.TabPage();
            this.labEPDisabilitato = new System.Windows.Forms.Label();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.gBoxTransmissionKind.SuspendLayout();
            this.tabDocumenti.SuspendLayout();
            this.tabPageMandati.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGrid1)).BeginInit();
            this.tabPageVariazioni.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dgrVariazioni)).BeginInit();
            this.gBoxNotifiche.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCodiceIstituto
            // 
            this.cmbCodiceIstituto.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
            this.cmbCodiceIstituto.DisplayMember = "description";
            this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodiceIstituto.Location = new System.Drawing.Point(160, 19);
            this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
            this.cmbCodiceIstituto.Size = new System.Drawing.Size(533, 23);
            this.cmbCodiceIstituto.TabIndex = 1;
            this.cmbCodiceIstituto.Tag = "paymenttransmission.idtreasurer?paymenttransmissionview.idtreasurer";
            this.cmbCodiceIstituto.ValueMember = "idtreasurer";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(68, 16);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(88, 24);
            this.btnIstitutoCassiere.TabIndex = 78;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsabile.Location = new System.Drawing.Point(160, 80);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(533, 23);
            this.cmbResponsabile.TabIndex = 3;
            this.cmbResponsabile.Tag = "paymenttransmission.idman?paymenttransmissionview.manager";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 24);
            this.label7.TabIndex = 73;
            this.label7.Text = "Responsabile della distinta:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataTrasmissione
            // 
            this.txtDataTrasmissione.Location = new System.Drawing.Point(112, 52);
            this.txtDataTrasmissione.Name = "txtDataTrasmissione";
            this.txtDataTrasmissione.Size = new System.Drawing.Size(94, 23);
            this.txtDataTrasmissione.TabIndex = 2;
            this.txtDataTrasmissione.Tag =
                "paymenttransmission.transmissiondate?paymenttransmissionview.transmissiondate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 71;
            this.label3.Text = "Data trasmissione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Distinta di trasmissione";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(245, 17);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(88, 23);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "paymenttransmission.npaymenttransmission?paymenttransmissionview.npaymenttransmis" +
                                 "sion";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(165, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(85, 17);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 23);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag =
                "paymenttransmission.ypaymenttransmission?paymenttransmissionview.ypaymenttransmis" +
                "sion";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmbResponsabile);
            this.groupBox3.Controls.Add(this.cmbCodiceIstituto);
            this.groupBox3.Controls.Add(this.btnIstitutoCassiere);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtDataTrasmissione);
            this.groupBox3.Location = new System.Drawing.Point(11, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(699, 107);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Contabili";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(447, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Data acquisizione banca:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(599, 48);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(97, 23);
            this.textBox8.TabIndex = 82;
            this.textBox8.Tag = "paymenttransmission.bankdate?paymenttransmissionview.bankdate";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(211, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Data creazione flusso:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 23);
            this.textBox1.TabIndex = 79;
            this.textBox1.Tag = "paymenttransmission.streamdate?paymenttransmissionview.streamdate";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPrincipale;
            this.tabControl1.Size = new System.Drawing.Size(715, 543);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
                this.tabPrincipale,
                this.tabEP
            });
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPrincipale.Controls.Add(this.checkBox1);
            this.tabPrincipale.Controls.Add(this.lblNotifiche);
            this.tabPrincipale.Controls.Add(this.progressBarImport);
            this.tabPrincipale.Controls.Add(this.gBoxTransmissionKind);
            this.tabPrincipale.Controls.Add(this.tabDocumenti);
            this.tabPrincipale.Controls.Add(this.gBoxNotifiche);
            this.tabPrincipale.Controls.Add(this.btnSendNotification);
            this.tabPrincipale.Controls.Add(this.groupBox3);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(715, 518);
            this.tabPrincipale.TabIndex = 3;
            this.tabPrincipale.Title = "Principale";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(351, 210);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(221, 19);
            this.checkBox1.TabIndex = 87;
            this.checkBox1.Tag = "paymenttransmission.flagtransmissionenabled:S:N";
            this.checkBox1.Text = "Verificato, si autorizza la trasmissione";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblNotifiche
            // 
            this.lblNotifiche.Location = new System.Drawing.Point(12, 52);
            this.lblNotifiche.Name = "lblNotifiche";
            this.lblNotifiche.Size = new System.Drawing.Size(352, 16);
            this.lblNotifiche.TabIndex = 86;
            this.lblNotifiche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBarImport
            // 
            this.progressBarImport.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarImport.Location = new System.Drawing.Point(11, 68);
            this.progressBarImport.Name = "progressBarImport";
            this.progressBarImport.Size = new System.Drawing.Size(693, 19);
            this.progressBarImport.TabIndex = 85;
            this.progressBarImport.Visible = false;
            // 
            // gBoxTransmissionKind
            // 
            this.gBoxTransmissionKind.Controls.Add(this.chkTransmissionKind);
            this.gBoxTransmissionKind.Location = new System.Drawing.Point(12, 197);
            this.gBoxTransmissionKind.Name = "gBoxTransmissionKind";
            this.gBoxTransmissionKind.Size = new System.Drawing.Size(333, 36);
            this.gBoxTransmissionKind.TabIndex = 84;
            this.gBoxTransmissionKind.TabStop = false;
            this.gBoxTransmissionKind.Text = "Tipo elenco";
            // 
            // chkTransmissionKind
            // 
            this.chkTransmissionKind.AutoSize = true;
            this.chkTransmissionKind.Location = new System.Drawing.Point(76, 13);
            this.chkTransmissionKind.Name = "chkTransmissionKind";
            this.chkTransmissionKind.Size = new System.Drawing.Size(212, 19);
            this.chkTransmissionKind.TabIndex = 82;
            this.chkTransmissionKind.Tag = "paymenttransmission.transmissionkind:V:I";
            this.chkTransmissionKind.Text = "Elenco di Variazioni e Annullamenti";
            this.chkTransmissionKind.UseVisualStyleBackColor = true;
            this.chkTransmissionKind.CheckedChanged += new System.EventHandler(this.chkTransmissionKind_CheckedChanged);
            // 
            // tabDocumenti
            // 
            this.tabDocumenti.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDocumenti.Controls.Add(this.tabPageMandati);
            this.tabDocumenti.Controls.Add(this.tabPageVariazioni);
            this.tabDocumenti.Location = new System.Drawing.Point(11, 239);
            this.tabDocumenti.Name = "tabDocumenti";
            this.tabDocumenti.SelectedIndex = 0;
            this.tabDocumenti.Size = new System.Drawing.Size(690, 270);
            this.tabDocumenti.TabIndex = 82;
            // 
            // tabPageMandati
            // 
            this.tabPageMandati.Controls.Add(this.groupBox2);
            this.tabPageMandati.Location = new System.Drawing.Point(4, 24);
            this.tabPageMandati.Name = "tabPageMandati";
            this.tabPageMandati.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMandati.Size = new System.Drawing.Size(682, 242);
            this.tabPageMandati.TabIndex = 0;
            this.tabPageMandati.Text = "Mandati inclusi nella distinta di trasmissione";
            this.tabPageMandati.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTotale);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnModifica);
            this.groupBox2.Controls.Add(this.btnScollega);
            this.groupBox2.Controls.Add(this.dataGrid1);
            this.groupBox2.Controls.Add(this.btnCollega);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(670, 230);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // txtTotale
            // 
            this.txtTotale.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotale.Location = new System.Drawing.Point(557, 195);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(104, 23);
            this.txtTotale.TabIndex = 80;
            this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(471, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 79;
            this.label4.Text = "Totale distinta";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(16, 64);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(75, 23);
            this.btnModifica.TabIndex = 78;
            this.btnModifica.TabStop = false;
            this.btnModifica.Text = "Modifica...";
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(16, 104);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(75, 23);
            this.btnScollega.TabIndex = 77;
            this.btnScollega.TabStop = false;
            this.btnScollega.Tag = "unlink";
            this.btnScollega.Text = "Rimuovi";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(96, 24);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(566, 161);
            this.dataGrid1.TabIndex = 75;
            this.dataGrid1.Tag = "paymentview.documentitrasmessi";
            // 
            // btnCollega
            // 
            this.btnCollega.Location = new System.Drawing.Point(16, 24);
            this.btnCollega.Name = "btnCollega";
            this.btnCollega.Size = new System.Drawing.Size(75, 23);
            this.btnCollega.TabIndex = 76;
            this.btnCollega.TabStop = false;
            this.btnCollega.Text = "Inserisci";
            this.btnCollega.Click += new System.EventHandler(this.btnCollega_Click);
            // 
            // tabPageVariazioni
            // 
            this.tabPageVariazioni.Controls.Add(this.groupBox4);
            this.tabPageVariazioni.Location = new System.Drawing.Point(4, 24);
            this.tabPageVariazioni.Name = "tabPageVariazioni";
            this.tabPageVariazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariazioni.Size = new System.Drawing.Size(682, 242);
            this.tabPageVariazioni.TabIndex = 1;
            this.tabPageVariazioni.Text = "Variazioni incluse nella distinta di trasmissione";
            this.tabPageVariazioni.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnModificaVar);
            this.groupBox4.Controls.Add(this.btnScollegaVar);
            this.groupBox4.Controls.Add(this.dgrVariazioni);
            this.groupBox4.Controls.Add(this.btnCollegaVar);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(670, 230);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btnModificaVar
            // 
            this.btnModificaVar.Location = new System.Drawing.Point(16, 64);
            this.btnModificaVar.Name = "btnModificaVar";
            this.btnModificaVar.Size = new System.Drawing.Size(75, 23);
            this.btnModificaVar.TabIndex = 78;
            this.btnModificaVar.TabStop = false;
            this.btnModificaVar.Text = "Modifica...";
            this.btnModificaVar.Click += new System.EventHandler(this.btnModificaVar_Click);
            // 
            // btnScollegaVar
            // 
            this.btnScollegaVar.Location = new System.Drawing.Point(16, 104);
            this.btnScollegaVar.Name = "btnScollegaVar";
            this.btnScollegaVar.Size = new System.Drawing.Size(75, 23);
            this.btnScollegaVar.TabIndex = 77;
            this.btnScollegaVar.TabStop = false;
            this.btnScollegaVar.Tag = "";
            this.btnScollegaVar.Text = "Rimuovi";
            this.btnScollegaVar.Click += new System.EventHandler(this.btnScollegaVar_Click);
            // 
            // dgrVariazioni
            // 
            this.dgrVariazioni.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top |
                                                         System.Windows.Forms.AnchorStyles.Bottom)
                                                        | System.Windows.Forms.AnchorStyles.Left)
                                                       | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrVariazioni.CaptionVisible = false;
            this.dgrVariazioni.DataMember = "";
            this.dgrVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrVariazioni.Location = new System.Drawing.Point(96, 24);
            this.dgrVariazioni.Name = "dgrVariazioni";
            this.dgrVariazioni.Size = new System.Drawing.Size(566, 188);
            this.dgrVariazioni.TabIndex = 75;
            this.dgrVariazioni.Tag = "expensevarview.documentitrasmessi";
            // 
            // btnCollegaVar
            // 
            this.btnCollegaVar.Location = new System.Drawing.Point(16, 24);
            this.btnCollegaVar.Name = "btnCollegaVar";
            this.btnCollegaVar.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaVar.TabIndex = 76;
            this.btnCollegaVar.TabStop = false;
            this.btnCollegaVar.Text = "Inserisci";
            this.btnCollegaVar.Click += new System.EventHandler(this.btnCollegaVar_Click);
            // 
            // gBoxNotifiche
            // 
            this.gBoxNotifiche.Controls.Add(this.chkFlagMailSent);
            this.gBoxNotifiche.Location = new System.Drawing.Point(538, 3);
            this.gBoxNotifiche.Name = "gBoxNotifiche";
            this.gBoxNotifiche.Size = new System.Drawing.Size(144, 46);
            this.gBoxNotifiche.TabIndex = 81;
            this.gBoxNotifiche.TabStop = false;
            this.gBoxNotifiche.Text = "Notifiche";
            // 
            // chkFlagMailSent
            // 
            this.chkFlagMailSent.AutoSize = true;
            this.chkFlagMailSent.Location = new System.Drawing.Point(6, 17);
            this.chkFlagMailSent.Name = "chkFlagMailSent";
            this.chkFlagMailSent.Size = new System.Drawing.Size(113, 19);
            this.chkFlagMailSent.TabIndex = 81;
            this.chkFlagMailSent.Tag = "paymenttransmission.flagmailsent:S:N";
            this.chkFlagMailSent.Text = "Notifiche Inviate";
            this.chkFlagMailSent.UseVisualStyleBackColor = true;
            // 
            // btnSendNotification
            // 
            this.btnSendNotification.Location = new System.Drawing.Point(393, 12);
            this.btnSendNotification.Name = "btnSendNotification";
            this.btnSendNotification.Size = new System.Drawing.Size(118, 24);
            this.btnSendNotification.TabIndex = 80;
            this.btnSendNotification.TabStop = false;
            this.btnSendNotification.Tag = "";
            this.btnSendNotification.Text = "Invia Email";
            this.btnSendNotification.Click += new System.EventHandler(this.btnSendNotification_Click);
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
            this.tabEP.Size = new System.Drawing.Size(715, 518);
            this.tabEP.TabIndex = 4;
            this.tabEP.Title = "E/P";
            // 
            // labEPDisabilitato
            // 
            this.labEPDisabilitato.Location = new System.Drawing.Point(12, 132);
            this.labEPDisabilitato.Name = "labEPDisabilitato";
            this.labEPDisabilitato.Size = new System.Drawing.Size(352, 16);
            this.labEPDisabilitato.TabIndex = 17;
            this.labEPDisabilitato.Text = "Le scritture in partita doppia sono disabilitate per questo elenco.";
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(6, 93);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 16;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
            this.btnGeneraEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(6, 64);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 15;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            // 
            // labEP
            // 
            this.labEP.Location = new System.Drawing.Point(3, 9);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(352, 16);
            this.labEP.TabIndex = 13;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // Frm_paymenttransmission_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(715, 543);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_paymenttransmission_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmtrasmdocpagamento";
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.gBoxTransmissionKind.ResumeLayout(false);
            this.gBoxTransmissionKind.PerformLayout();
            this.tabDocumenti.ResumeLayout(false);
            this.tabPageMandati.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGrid1)).EndInit();
            this.tabPageVariazioni.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.dgrVariazioni)).EndInit();
            this.gBoxNotifiche.ResumeLayout(false);
            this.gBoxNotifiche.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
        private EP_Manager EPM;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
            GetData.CacheTable(DS.accountkind);
            GetData.CacheTable(DS.tax, null, null, false);
            HelpForm.SetDenyNull(DS.paymenttransmission.Columns["flagmailsent"], true);
            HelpForm.SetDenyNull(DS.paymenttransmission.Columns["transmissionkind"], true);
            HelpForm.SetDenyNull(DS.paymenttransmission.Columns["idtreasurer"], true);
            HelpForm.SetDenyNull(DS.paymenttransmission.Columns["flagtransmissionenabled"], true);

            EPM = new EP_Manager(Meta, null, null, null, null, btnGeneraEP, btnVisualizzaEP, labEP, labEPDisabilitato,
                "paymenttransmission");
        }

        public void MetaData_AfterPost() {
            if (_paymentChanges) EPM.afterPost();
        }

        bool _paymentChanges = false;

        public void MetaData_BeforePost() {
            _paymentChanges = false;
            PostData.RemoveFalseUpdates(DS);
            foreach (DataRow R in DS.paymentview.Rows) {
                if (R.RowState == DataRowState.Unchanged) continue;
                _paymentChanges = true;
                break;
            }

            foreach (DataRow R in DS.expensevarview.Rows) {
                if (R.RowState == DataRowState.Unchanged) continue;
                _paymentChanges = true;
                break;
            }


            if (_paymentChanges) {
                EPM.beforePost();
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "treasurer" && R != null) {
                string flagedisp = R["flagedisp"].ToString().ToUpper();
                if (flagedisp == "N") {
                    chkTransmissionKind.Checked = false;
                    gBoxTransmissionKind.Visible = false;
                    AddRemoveTab(tabPageVariazioni, false, false);
                }
                else {
                    gBoxTransmissionKind.Visible = true;
                    AddRemoveTab(tabPageVariazioni, true, false);
                }
            }
        }

        private void SendNotificationDisp() {
            if (DS.paymenttransmission.Rows.Count == 0) return;
            if (DS.paymentview.Rows.Count == 0) return;
            string MsgBody = "";
            string MsgNotes = " ";
            string MsgHeader = "";
            string filtroMandati = QHC.IsNotNull("kpaymenttransmission");
            DataRow[] rMandati = DS.paymentview.Select(filtroMandati);

            DataTable TTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.CmpEq("idtreasurer", DS.paymenttransmission.Rows[0]["idtreasurer"]), null, false);
            DataRow RTreasurer = TTreasurer.Rows[0];

            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            DataRow rLicenza = tLicenza.Rows[0];

            string filter = "";
            string filtermandato = "";
            foreach (DataRow Mandato in rMandati) {
				// Ci sono ora due modalità di generazione mandati per le disposizioni di pagamento
				//1) Mandato singolo associato alla disposizione, unico pagamento cumulativo su Anagrafica "Studenti Diversi"
				//2) Più mandati corrispondenti alle liquidazioni generate singolarmente sui dettagli mediante wizard
                filtermandato = QHS.CmpEq("kpay", Mandato["kpay"]);
                filter = QHS.AppAnd(QHS.CmpGt("amount", 0), filtermandato);

				DataTable T = Meta.Conn.RUN_SELECT("paydispositionview", "*", null, filtermandato, null, false);
				DataTable TDetails = Meta.Conn.RUN_SELECT("paydispositiondetailview", "*", null, filter, null, false);
			
				if (T == null || T.Rows.Count == 0) {
					// Mandati su liquidazion
					filtermandato = QHS.CmpEq("kpaydett", Mandato["kpay"]);
					filter = QHS.AppAnd(QHS.CmpGt("amount", 0), filtermandato);
					TDetails = Meta.Conn.RUN_SELECT("paydispositiondetailview", "*", null, filter, null, false);
				}

				if ((TDetails == null) || (TDetails.Rows.Count == 0)) continue;
 
				progressBarImport.Visible = true;
                progressBarImport.Value = 0;
                progressBarImport.Maximum = TDetails.Rows.Count;
                lblNotifiche.Text = "Invio notifiche in corso per Mandato n° " + Mandato["npay"];

                // Ciclo sui beneficiari della disposizione di pagamento
                foreach (DataRow rDispDetailsRow in TDetails.Rows) {
                    if (progressBarImport.Value < progressBarImport.Maximum) progressBarImport.Value++;
                    Application.DoEvents();
                    object description = rDispDetailsRow["maindescription"];
                    object surname = rDispDetailsRow["surname"];
                    object forename = rDispDetailsRow["forename"];
                    object title = rDispDetailsRow["title"];
                    object paymentadate = Mandato["adate"];
                    object npay = Mandato["npay"];
                    object ypay = Mandato["ypay"];
                    object amount = rDispDetailsRow["amount"];
                    object iban = rDispDetailsRow["iban"];

                    string ModPagamento = "";
                    if (iban != DBNull.Value) {
                        ModPagamento = "Bonifico";
                    }
                    else {
                        ModPagamento = "Per Cassa";
                    }

                    string registry = "";
                    if (title != DBNull.Value)
                        registry = title.ToString();
                    else {
                        if (surname != DBNull.Value) {
                            registry = surname.ToString();
                        }

                        if (forename != DBNull.Value) {
                            registry = registry + " " + forename.ToString();
                        }
                    }

                    string mailto = rDispDetailsRow["email"].ToString();
                    bool avviso_errore = false;
                    if (mailto == "") avviso_errore = true;
                    if (avviso_errore && emaildep == "") continue;

                    MsgHeader = "";
                    if (avviso_errore) MsgHeader = "EMAIL NON INVIATA per assenza di indirizzo email\r\n";

                    if (RTreasurer["idbank"].ToString() == "03067") {
                        MsgHeader += " Si informa che presso l'Istituto cassiere di questa Università, " + "\r\n" +
                                     " in tutte le agenzie e filiali di Banca CARIME S.P.A., " + "\r\n";
                    }
                    else {
                        MsgHeader += " Si informa che presso il servizio di Cassa di questa Università: " + "\r\n" +
                                     rLicenza["agencyname"] + " - " + rLicenza["departmentname"] + "\r\n";
                    }

                    string causale = rDispDetailsRow["motive"].ToString();
                    if (causale == "") causale = rDispDetailsRow["mainmotive"].ToString();
                    causale += "\r\n";
                    MsgBody = MsgHeader +
                              " è in pagamento per il Beneficiario " + registry + " \r\n" +
                              " il Mandato numero " + npay.ToString() + " relativo all'esercizio " + ypay.ToString() +
                              "\r\n" +
                              " del " + ((DateTime) paymentadate).ToShortDateString() + ".\r\n" +
                              " Modalità di pagamento: " + ModPagamento + "\r\n" +
                              " Causale del pagamento: " + description.ToString() + ".\r\n" +causale+
                              " Importo del pagamento: " + CfgFn.GetNoNullDecimal(amount).ToString("c") +
                              ".\r\n" +
                              "\r\n" +
                              "\r\n" +
                              "\r\n";

                    MsgNotes = RTreasurer["annotations"].ToString();

                    foreach (DataColumn C in RTreasurer.Table.Columns) {
                        MsgNotes = MsgNotes.Replace("<%" + C.ColumnName + "%>", RTreasurer[C.ColumnName].ToString());
                    }


                    MsgBody += MsgNotes;

                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    if (avviso_errore) {
                        SM.Subject = "MAIL NON INVIATA: Emissione Mandato di Pagamento n° " + npay.ToString() + "/" +
                                     ypay.ToString();
                        SM.To = emaildep;
                    }
                    else {
                        SM.Subject = "Emissione Mandato di Pagamento n° " + npay.ToString() + "/" + ypay.ToString();
                        SM.To = mailto;
                        if (emaildep != "") SM.Cc = emaildep;
                    }

                    SM.MessageBody = MsgBody;
                    SM.Conn = Meta.Conn;
                    //if (SM.NoConfig == false) continue;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                    else sent = true;
                }

                progressBarImport.Value = 0;
                progressBarImport.Visible = false;
                lblNotifiche.Text = "";
            }
        }

        private void SendNotification() {
            if (DS.paymenttransmission.Rows.Count == 0) return;
            if (DS.paymentview.Rows.Count == 0) return;
            string MsgBody = "";
            string MsgHeader = " ";
            string MsgNotes = " ";
            string filtroMandati = QHC.IsNotNull("kpaymenttransmission");

            object idtreasurer;
            idtreasurer = DS.paymenttransmission.Rows[0]["idtreasurer"];
            DataTable TTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.CmpEq("idtreasurer", idtreasurer),
                null, false);
            if (TTreasurer == null || TTreasurer.Rows.Count == 0) return;
            DataRow RTreasurer = TTreasurer.Rows[0];

            DataTable tLicenza = Meta.Conn.RUN_SELECT("license", null, null, null, null, true);
            if (tLicenza == null || tLicenza.Rows.Count == 0) return;
            DataRow rLicenza = tLicenza.Rows[0];

            DataRow[] rMandati = DS.paymentview.Select(filtroMandati);

            string filtermand = "";
            foreach (DataRow Mandato in rMandati) {
                filtermand = QHS.CmpEq("kpay", Mandato["kpay"]);
                DataTable TDisp = Meta.Conn.RUN_SELECT("paydispositionview", "*", null, filtermand, null, false);
                if (TDisp.Rows.Count > 0) continue; // mandato associato a disposizioni di pagamento

                DataTable T = Meta.Conn.RUN_SELECT("expenselastview", "*", null, filtermand, null, false);

                if (T == null || T.Rows.Count == 0) return;

                progressBarImport.Visible = true;
                progressBarImport.Value = 0;
                progressBarImport.Maximum = T.Rows.Count;
                lblNotifiche.Text = "Invio notifiche in corso per Mandato n° " + Mandato["npay"];
                // Ciclo sui beneficiari delle righe di mandato
                foreach (DataRow rExp in T.Rows) {
                    if (progressBarImport.Value < progressBarImport.Maximum) progressBarImport.Value++;
                    Application.DoEvents();
                    object idreg = rExp["idreg"];
                    object description = rExp["description"];
                    object registry = rExp["registry"];
                    object paymentadate = rExp["paymentadate"];
                    object npay = rExp["npay"];
                    object ypay = rExp["ypay"];
                    decimal amount = CfgFn.GetNoNullDecimal(rExp["amount"]);
                    object doc = rExp["doc"];
                    object docdate = rExp["docdate"];

                    decimal linkedIncome = CfgFn.GetNoNullDecimal(Meta.Conn.DO_SYS_CMD(
                        "SELECT sum(IIT.curramount) from 		income II with (nolock) " +
                        " join incometotal IIT  with (nolock)  on II.idinc=IIT.idinc and IIT.ayear=" +
                        QHS.quote(Meta.Conn.GetEsercizio()) +
                        " join incomelast IL with (nolock) on IL.idinc=II.idinc " +
                        "WHERE II.idpayment = " + QHS.quote(rExp["idexp"]) + " AND " +
                        "((II.autokind=4 and II.idreg = " + QHS.quote(idreg) + ") or II.autokind in (6,14,20,21)) ",
                        true));

                    amount -= linkedIncome;

                    string doc_docdate = "";
                    if ((doc != DBNull.Value) && (doc != null)) {
                        doc_docdate = " Documento collegato: " + doc.ToString();

                        if ((docdate != DBNull.Value) && (docdate != null))
                            doc_docdate += " del " + ((DateTime) docdate).ToShortDateString();


                        doc_docdate += ".\r\n";
                    }

                    string filterReference = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("flagdefault", "S"));
                    DataTable TReference =
                        Meta.Conn.RUN_SELECT("registryreference", "*", null, filterReference, null, false);

                    if (TReference == null || TReference.Rows.Count == 0) continue;

                    //if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;
                    string mailto = TReference.Rows[0]["email"].ToString();
                    string AVVISO_ERRORE = "";
                    if (mailto == "") {
                        mailto = GetErrorMailAddress(Meta.Conn);
                        AVVISO_ERRORE = "MAIL NON INVIATA\r\n";
                        continue;
                    }

                    DataTable Tpaymethod = Meta.Conn.RUN_SELECT("paymethod", "*", null,
                        QHS.CmpEq("idpaymethod", rExp["idpaymethod"]), null, false);
                    if (Tpaymethod == null || Tpaymethod.Rows.Count == 0) continue;
                    DataRow Rpaymethod = Tpaymethod.Rows[0];
                    MsgHeader = AVVISO_ERRORE;
                    if (RTreasurer["idbank"].ToString() == "03067") {
                        MsgHeader += " Si informa che presso l'Istituto cassiere di questa Università, " + "\r\n" +
                                     " in tutte le agenzie e filiali di Banca CARIME S.P.A., " + "\r\n";
                    }
                    else {
                        MsgHeader += " Si informa che presso il servizio di Cassa di questa Università: " + "\r\n" +
                                     rLicenza["agencyname"] + " - " + rLicenza["departmentname"] + "\r\n";
                    }


                    MsgBody = MsgHeader +
                              " è in pagamento per il Beneficiario " + registry + " \r\n" +
                              " il Mandato numero " + npay.ToString() + " relativo all'esercizio " + ypay.ToString() +
                              "\r\n" +
                              " del " + ((DateTime) paymentadate).ToShortDateString() + ".\r\n" +
                              " Modalità di pagamento: " + Rpaymethod["description"] + "\r\n" +
                              " Causale del pagamento: " + description.ToString() + ".\r\n" +
                              doc_docdate +
                              " Importo del pagamento: " + CfgFn.GetNoNullDecimal(amount).ToString("c") +
                              ".\r\n" +
                              "\r\n" +
                              "\r\n" +
                              "\r\n";

                    MsgNotes = RTreasurer["annotations"].ToString();

                    foreach (DataColumn C in RTreasurer.Table.Columns) {
                        MsgNotes = MsgNotes.Replace("<%" + C.ColumnName + "%>", RTreasurer[C.ColumnName].ToString());
                    }


                    MsgBody += MsgNotes;

                    SendMail SM = new SendMail();
                    SM.Conn = Meta.Conn;
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    if (emaildep != "") SM.Cc = emaildep;
                    SM.Subject = "Emissione Mandato di Pagamento n° " + npay.ToString() + "/" + ypay.ToString();
                    SM.MessageBody = MsgBody;
                    SM.Conn = Meta.Conn;
                    //if (SM.NoConfig == false) continue;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                    else sent = true;
                }

                progressBarImport.Value = 0;
                progressBarImport.Visible = false;
                lblNotifiche.Text = "";
            }
        }

        public static string GetErrorMailAddress(DataAccess Conn) {
            QueryHelper QHS = Conn.GetQueryHelper();
            object email = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "email");
            if (email == null) email = DBNull.Value;
            return email.ToString();
        }





        void VisualizzaTabPageVariazioni() {
            if (DS.paymenttransmission.Rows.Count == 0) {
                AddRemoveTab(tabPageVariazioni, true, false);
                AddRemoveTab(tabPageMandati, true, false);
                return;
            }

            if (!chkTransmissionKind.Checked) // I
            {
                AddRemoveTab(tabPageVariazioni, false, false);
                AddRemoveTab(tabPageMandati, true, false);
            }
            else // "V"
            {
                AddRemoveTab(tabPageVariazioni, true, false);
                AddRemoveTab(tabPageMandati, false, false);
            }
        }

        void AddTab(TabPage Tab, bool redraw) {
            if (tabDocumenti.TabPages.Contains(Tab)) return;
            tabDocumenti.TabPages.Add(Tab);
            if (Meta.IsEmpty) {
                Meta.myHelpForm.ClearControls(Tab.Controls);
            }
            else {
                if (redraw) Meta.myHelpForm.FillControls(Tab.Controls);
            }
        }

        void AddRemoveTab(TabPage Tab, bool Add, bool redraw) {
            if (Add) {
                AddTab(Tab, redraw);
            }
            else {
                if (tabDocumenti.TabPages.Contains(Tab)) {
                    tabDocumenti.TabPages.Remove(Tab);
                }
            }
        }




        string CalculateFilterForLinking(bool SQL) {
            DataRow Curr = DS.paymenttransmission.Rows[0];
            QueryHelper QH = SQL ? QHS : QHC;
            string MyFilter = QH.AppAnd(QH.IsNull("kpaymenttransmission"),
                QH.IsNotNull("printdate"), QH.CmpEq("ypay", esercizio));
            MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idtreasurer", Curr["idtreasurer"]));

            if (flagtrasmresponsabile) MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idman", Curr["idman"]));
            return MyFilter;
        }

        string CalculateFilterForLinkingVar(bool SQL) {
            DataRow Curr = DS.paymenttransmission.Rows[0];
            QueryHelper QH = SQL ? QHS : QHC;
            string MyFilter = QH.AppAnd(QH.IsNull("kpaymenttransmission"), QH.FieldInList("autokind", "10,11,22"),
                QH.CmpEq("yvar", esercizio), QH.IsNotNull("kpay"), QH.IsNotNull("kpaymenttransmission_orig"));
            MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idtreasurer", Curr["idtreasurer"]));

            if (flagtrasmresponsabile) MyFilter = QH.AppAnd(MyFilter, QH.CmpEq("idman", Curr["idman"]));
            return MyFilter;
        }

        private void btnCollega_Click(object sender, System.EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            string MyFilter = CalculateFilterForLinking(true);

            string command = "choose.paymentview.documentitrasmessi." + MyFilter;

            MetaData.Choose(this, command);

        }

        private void btnCollegaVar_Click(object sender, System.EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            Meta.MarkTableAsNotEntityChild(DS.expensevarview);
            string MyFilter = CalculateFilterForLinkingVar(true);
            string command = "choose.expensevarview.documentitrasmessi." + MyFilter;
            MetaData.Choose(this, command);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }

        void CalcolaDefaultPerIstitutoCassiere() {
            DataRow[] cassiere = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (cassiere.Length == 1) {
                MetaData.SetDefault(DS.paymenttransmission, "idtreasurer", cassiere[0]["idtreasurer"]);
                return;
            }

            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.paymenttransmission, "idtreasurer", codiceistituto);
            }
        }

        public void MetaData_AfterClear() {
            btnCollega.Enabled = false;
            btnScollega.Enabled = false;
            btnModifica.Enabled = false;
            chkFlagMailSent.ThreeState = true;
            txtEsercizio.Text = esercizio.ToString();
            CalcolaDefaultPerIstitutoCassiere();
            txtTotale.Text = "";
            VisualizzaTabPageVariazioni();
            chkTransmissionKind.Enabled = true;
            Meta.UnMarkTableAsNotEntityChild(DS.expensevarview);
            EPM.mostraEtichette();
            txtNumero.ReadOnly = false;
        }

        string emaildep = "";

        public void MetaData_AfterActivation() {
            txtEsercizio.Text = esercizio.ToString();
            if (DS.config.Rows.Count > 0) {
                emaildep = DS.config.Rows[0]["email"].ToString();
                byte payment_flag = (byte) DS.config.Rows[0]["payment_flag"];
                flagtrasmresponsabile = (payment_flag & 1) == 1;
                if (flagtrasmresponsabile) {
                    cmbResponsabile.Enabled = true;
                }
                else {
                    cmbResponsabile.Enabled = false;
                }
            }
            else {
                MessageBox.Show(
                    "Errore: Non è stata ancora effettuata la configurazione delle spese per l'esercizio corrente.");
                Meta.CanSave = false;
                Meta.SearchEnabled = false;
            }

            btnCollega.ForeColor = formcolors.GridButtonForeColor();
            btnCollega.BackColor = formcolors.GridButtonBackColor();
            btnModifica.ForeColor = formcolors.GridButtonForeColor();
            btnModifica.BackColor = formcolors.GridButtonBackColor();
            btnModificaVar.ForeColor = formcolors.GridButtonForeColor();
            btnModificaVar.BackColor = formcolors.GridButtonBackColor();
            btnCollegaVar.ForeColor = formcolors.GridButtonForeColor();
            btnCollegaVar.BackColor = formcolors.GridButtonBackColor();
            btnScollegaVar.ForeColor = formcolors.GridButtonForeColor();
            btnScollegaVar.BackColor = formcolors.GridButtonBackColor();
        }


        public void MetaData_AfterFill() {
            btnCollega.Enabled = true;
            btnScollega.Enabled = true;
            btnModifica.Enabled = true;
            if (Meta.EditMode) {
                btnVisualizzaEP.Enabled = true;
                btnSendNotification.Enabled = true;
                txtNumero.ReadOnly = true;
            }
            else {
                btnVisualizzaEP.Enabled = false;
                btnSendNotification.Enabled = false;
                txtNumero.ReadOnly = false;
            }

            EPM.mostraEtichette();

            CalcolaTotale();
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                if ((DS.paymentview.Rows.Count > 0) || (DS.expensevarview.Rows.Count > 0))
                    chkTransmissionKind.Enabled = false;
                else
                    chkTransmissionKind.Enabled = true;
            }

            VisualizzaTabPageVariazioni();
        }


        private void LeggiRigheCollegate(Hashtable hVarCollegate, ArrayList arrVarCollegate) {
            // Questo metodo tiene traccia delle righe collegate 
            foreach (DataRow rVar in DS.expensevarview.Select()) {
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object currVal = rVar["kpaymenttransmission", DataRowVersion.Current];

                if (currVal != DBNull.Value) {
                    if (arrVarCollegate.Contains(rVar["idexp"])) continue;
                    hVarCollegate[rVar["idexp"]] = rVar["kpay"];
                    arrVarCollegate.Add(rVar["idexp"]);
                }

            }
        }

        private void ConfermaRigheCollegate(Hashtable hVarCollegate, ArrayList arrVarCollegate) {
            foreach (object idexp in arrVarCollegate) {
                string filterRow = "";
                string filter = "";
                filterRow = QHC.AppAnd(QHC.CmpEq("idexp", idexp), QHC.CmpEq("autokind", 11));
                int len = DS.expensevarview.Select(filterRow).Length;
                if (len == 0) {
                    filter = QHC.AppAnd(QHC.CmpEq("kpay", hVarCollegate[idexp]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.expensevarview.Select(filter)) {
                        VarAnn["kpaymenttransmission"] = DBNull.Value;
                    }
                }

                if (len == 1) {
                    DataRow R = DS.expensevarview.Select(filterRow)[0];
                    object currVal = R["kpaymenttransmission", DataRowVersion.Current];
                    if (currVal == DBNull.Value) {
                        filter = QHC.AppAnd(QHC.CmpEq("kpay", hVarCollegate[idexp]), QHC.CmpEq("autokind", 11));
                        foreach (DataRow VarAnn in DS.expensevarview.Select(filter)) {
                            VarAnn["kpaymenttransmission"] = DBNull.Value;
                        }
                    }
                }
            }
        }



        private void CollegaScollegaAnnullamentiTotali() {
            Hashtable hVarTotali = null;
            hVarTotali = new Hashtable();

            // in questo primo ciclo se vi sono righe originariamente scollegate, poi ricollegate e poi scollegate
            // le rimuove dal dataset insieme alle sorelle
            foreach (DataRow rVar in DS.expensevarview.Select()) {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kpaymenttransmission", DataRowVersion.Original];
                object currVal = rVar["kpaymenttransmission", DataRowVersion.Current];

                if ((originalVal == DBNull.Value) && (currVal == DBNull.Value)) {
                    string filter = "";
                    filter = QHC.AppAnd(QHC.CmpEq("kpay", rVar["kpay"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.expensevarview.Select(filter)) {
                        VarAnn.Delete();
                        VarAnn.AcceptChanges();
                    }
                }

            }

            // in questo secondo ciclo se vi sono righe originariamente collegate, poi scollegate e poi ricollegate
            // ne ripristina il valore originale not null (anche per le sorelle) ponendole in stato unchanged

            foreach (DataRow rVar in DS.expensevarview.Select()) {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kpaymenttransmission", DataRowVersion.Original];
                object currVal = rVar["kpaymenttransmission", DataRowVersion.Current];

                if ((originalVal != DBNull.Value) && (currVal != DBNull.Value)) {
                    string filter = "";
                    filter = QHC.AppAnd(QHC.CmpEq("kpay", rVar["kpay"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.expensevarview.Select(filter)) {
                        VarAnn["kpaymenttransmission"] = originalVal;
                        VarAnn.AcceptChanges();
                    }
                }

            }

            // in questo terzo ciclo se vi sono righe originariamente collegate, poi scollegate 
            // scollega tutte le sorelle

            foreach (DataRow rVar in DS.expensevarview.Select()) {
                if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kpaymenttransmission", DataRowVersion.Original];
                object currVal = rVar["kpaymenttransmission", DataRowVersion.Current];

                if ((originalVal != DBNull.Value) && (currVal == DBNull.Value)) {
                    string filter = "";

                    if (hVarTotali[rVar["kpay"]] != null) continue;

                    hVarTotali[rVar["kpay"]] = 1;
                    filter = QHC.AppAnd(QHC.CmpEq("kpay", rVar["kpay"]), QHC.CmpEq("autokind", 11));
                    foreach (DataRow VarAnn in DS.expensevarview.Select(filter)) {
                        VarAnn["kpaymenttransmission"] = DBNull.Value;
                    }
                }

            }

            // in questo quarto ciclo se vi sono righe originariamente scollegate, poi collegate 
            // collega tutte le sorelle
            foreach (DataRow rVar in DS.expensevarview.Select()) {
                //if (rVar.RowState != DataRowState.Modified) continue;
                if (CfgFn.GetNoNullInt32(rVar["autokind"]) != 11) continue;

                object originalVal = rVar["kpaymenttransmission", DataRowVersion.Original];
                object currVal = rVar["kpaymenttransmission", DataRowVersion.Current];

                if ((originalVal == DBNull.Value) && (currVal != DBNull.Value)) {
                    string filter = "";

                    if (hVarTotali[rVar["kpay"]] != null) continue;

                    hVarTotali[rVar["kpay"]] = 1;
                    filter = QHS.AppAnd(QHS.CmpEq("kpay", rVar["kpay"]), QHS.CmpEq("autokind", 11));
                    // select da db delle var collegate
                    DataTable T = Meta.Conn.RUN_SELECT("expensevarview", "*", null, filter, null, false);
                    if (T == null) continue;

                    foreach (DataRow VarAnn in T.Rows) {
                        string filterRow = QHC.AppAnd(QHC.CmpEq("idexp", VarAnn["idexp"]),
                            QHC.CmpEq("nvar", VarAnn["nvar"]));
                        DataRow[] Found = DS.expensevarview.Select(filterRow);
                        if (Found.Length > 0) {
                            Found[0]["kpaymenttransmission"] = currVal;
                        }
                        else {
                            DataRow NewVar = DS.expensevarview.NewRow();
                            foreach (DataColumn C in VarAnn.Table.Columns) {
                                if (DS.expensevarview.Columns.Contains(C.ColumnName)) {
                                    NewVar[C.ColumnName] = VarAnn[C.ColumnName];
                                }
                            }

                            MetaData metaSpesaVarView = Meta.Dispatcher.Get("expensevarview");
                            DS.expensevarview.Rows.Add(NewVar);
                            metaSpesaVarView.CalculateFields(NewVar, "documentitrasmessi");
                            NewVar.AcceptChanges();
                            NewVar["kpaymenttransmission"] = currVal;
                        }
                    }
                }
            }
        }




        private void btnModifica_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = CalculateFilterForLinking(false);
            string MyFilterSQL = CalculateFilterForLinking(true);
            Meta.MultipleLinkUnlinkRows("Composizione distinta di trasmissione",
                "Mandati inclusi nella distinta di trasmissione selezionata",
                "Mandati non inclusi in alcuna distinta di trasmissione",
                DS.paymentview, MyFilter, MyFilterSQL, "documentitrasmessi");
        }

        private void btnModificaVar_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            Hashtable hVarCollegate = null;
            hVarCollegate = new Hashtable();
            ArrayList arrVarCollegate = null;
            arrVarCollegate = new ArrayList();
            LeggiRigheCollegate(hVarCollegate, arrVarCollegate);
            Meta.MarkTableAsNotEntityChild(DS.expensevarview);
            string MyFilter = CalculateFilterForLinkingVar(false);
            string MyFilterSQL = CalculateFilterForLinkingVar(true);
            Meta.MultipleLinkUnlinkRows("Composizione distinta di trasmissione",
                "Variazioni incluse nella distinta di trasmissione selezionata",
                "Variazioni non incluse in alcuna distinta di trasmissione",
                DS.expensevarview, MyFilter, MyFilterSQL, "documentitrasmessi");
            ConfermaRigheCollegate(hVarCollegate, arrVarCollegate);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }

        private void CalcolaTotale() {
            if (Meta.IsEmpty) return;
            if (chkTransmissionKind.Checked) return; // il totale va calcolato solo se è una distinta normale
            DataSet MyDS = (DataSet) dataGrid1.DataSource;
            DataTable MyTable = MyDS.Tables[dataGrid1.DataMember.ToString()];
            decimal importo = 0;
            importo = MetaData.SumColumn(MyTable, "total");
            txtTotale.Text = importo.ToString("C");
        }




        bool sent = false;

        private void btnSendNotification_Click(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (MetaData.Empty(this)) return;
            DataRow Curr = DS.paymenttransmission.Rows[0];
            if (chkFlagMailSent.Checked) return;
            sent = false;
            SendNotification();
            SendNotificationDisp();
            if (Meta.destroyed) return;

            if (sent) {
                MessageBox.Show("Notifiche inviate");
                sent = false;
                Curr["flagmailsent"] = "S";
                Meta.FreshForm();
                Meta.DoMainCommand("mainsave");
            }
        }

        private void chkTransmissionKind_CheckedChanged(object sender, EventArgs e) {
            VisualizzaTabPageVariazioni();
        }

        private void UnlinkGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "expensevarview") {
                filter = QHC.AppAnd(QHC.CmpEq("idexp", G[index, 0]), QHC.CmpEq("nvar", G[index, 2]));
                DataRow[] selectresult = DS.expensevarview.Select(filter);
                if (selectresult.Length > 0) {
                    DataRow toUnlink = selectresult[0];
                    toUnlink["kpaymenttransmission"] = DBNull.Value;
                }
            }
        }

        private void btnScollegaVar_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            Meta.MarkTableAsNotEntityChild(DS.expensevarview);
            int index = dgrVariazioni.CurrentRowIndex;
            if (index < 0) return;
            UnlinkGridRow(dgrVariazioni, index);
            CollegaScollegaAnnullamentiTotali();
            Meta.FreshForm();
        }



    }
}