
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace expenselast_modpaga//spesamodcreddebi//
{
    /// <summary>
    /// Summary description for frmSpesaModCredDebi.
    /// </summary>
    public class Frm_expenselast_modpaga : MetaDataForm {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbModalita;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        const string CIN_NON_CORRETTO = "CIN non corretto!";
        MetaData Meta;
        string lastCIN = "";
        string lastABI = "";
        string lastCAB = "";
        string lastCC = "";
        bool inChiusura = false;
        private System.Windows.Forms.TextBox descrizione;
        private System.Windows.Forms.Label label3;
        public vistaForm DS;
        private TabControl tabInformazioniModPagamento;
        private TabPage tabGenerale;
        private TextBox txtRifDocumentoEsterno;
        private Label label6;
        private GroupBox gboxDelegato;
        private TextBox txtDelegato;
        private GroupBox gboxCoordinate;
        private Label label13;
        private TextBox textBox3;
        private GroupBox gboxSportello;
        private Button btnCab;
        private TextBox txtCab;
        private TextBox txtCabDescr;
        private GroupBox gboxBanca;
        private TextBox txtBanca;
        private Button BancaButton;
        private TextBox txtDescrBanca;
        private Button btnIBAN;
        private Label label10;
        private TextBox txtIBAN;
        private Label label8;
        private Button btnBBAN;
        private Label label7;
        private TextBox txtBBAN;
        private Label label5;
        private TextBox txtCin;
        private Label label4;
        private TextBox contocorrente;
        private TabPage tabOpzioni;
        private GroupBox groupBox1;
        private GroupBox groupBox5;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox4;
        private CheckBox chkObbligoCoordBanc;
        private CheckBox chkDivietoCoordBanc;
        private CheckBox chkContoCorrPostale;
        private CheckBox chkDelegato;
        private CheckBox chkStampaAvviso;
        private GroupBox groupBox3;
        private TextBox textBox2;
        private GroupBox groupBox2;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox chk_bank_charges_exempt;
        private Button btnChargeHandling;
        private ComboBox cmbChargeHandling;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_expenselast_modpaga() {
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbModalita = new System.Windows.Forms.ComboBox();
			this.DS = new expenselast_modpaga.vistaForm();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.descrizione = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabInformazioniModPagamento = new System.Windows.Forms.TabControl();
			this.tabGenerale = new System.Windows.Forms.TabPage();
			this.txtRifDocumentoEsterno = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.gboxDelegato = new System.Windows.Forms.GroupBox();
			this.txtDelegato = new System.Windows.Forms.TextBox();
			this.gboxCoordinate = new System.Windows.Forms.GroupBox();
			this.cmbChargeHandling = new System.Windows.Forms.ComboBox();
			this.btnChargeHandling = new System.Windows.Forms.Button();
			this.chk_bank_charges_exempt = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.gboxSportello = new System.Windows.Forms.GroupBox();
			this.btnCab = new System.Windows.Forms.Button();
			this.txtCab = new System.Windows.Forms.TextBox();
			this.txtCabDescr = new System.Windows.Forms.TextBox();
			this.gboxBanca = new System.Windows.Forms.GroupBox();
			this.txtBanca = new System.Windows.Forms.TextBox();
			this.BancaButton = new System.Windows.Forms.Button();
			this.txtDescrBanca = new System.Windows.Forms.TextBox();
			this.btnIBAN = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.txtIBAN = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnBBAN = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtBBAN = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCin = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.contocorrente = new System.Windows.Forms.TextBox();
			this.tabOpzioni = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chkObbligoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkDivietoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkContoCorrPostale = new System.Windows.Forms.CheckBox();
			this.chkDelegato = new System.Windows.Forms.CheckBox();
			this.chkStampaAvviso = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabInformazioniModPagamento.SuspendLayout();
			this.tabGenerale.SuspendLayout();
			this.gboxDelegato.SuspendLayout();
			this.gboxCoordinate.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gboxSportello.SuspendLayout();
			this.gboxBanca.SuspendLayout();
			this.tabOpzioni.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Percipiente";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(121, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(501, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "registry.title";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tipo Modalità";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbModalita
			// 
			this.cmbModalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbModalita.DataSource = this.DS.paymethod;
			this.cmbModalita.DisplayMember = "description";
			this.cmbModalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModalita.Location = new System.Drawing.Point(121, 56);
			this.cmbModalita.Name = "cmbModalita";
			this.cmbModalita.Size = new System.Drawing.Size(501, 21);
			this.cmbModalita.TabIndex = 1;
			this.cmbModalita.Tag = "expenselast.idpaymethod";
			this.cmbModalita.ValueMember = "idpaymethod";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(556, 563);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 5;
			this.BtnCancel.Text = "Annulla";
			// 
			// BtnOk
			// 
			this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.BtnOk.Location = new System.Drawing.Point(468, 563);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(75, 23);
			this.BtnOk.TabIndex = 4;
			this.BtnOk.Tag = "mainsave";
			this.BtnOk.Text = "Ok";
			// 
			// descrizione
			// 
			this.descrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.descrizione.Location = new System.Drawing.Point(121, 88);
			this.descrizione.Multiline = true;
			this.descrizione.Name = "descrizione";
			this.descrizione.Size = new System.Drawing.Size(510, 48);
			this.descrizione.TabIndex = 3;
			this.descrizione.Tag = "expenselast.paymentdescr";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 39);
			this.label3.TabIndex = 18;
			this.label3.Text = "Note per il Tesoriere  -  Rif.doc.esterno ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabInformazioniModPagamento
			// 
			this.tabInformazioniModPagamento.Controls.Add(this.tabGenerale);
			this.tabInformazioniModPagamento.Controls.Add(this.tabOpzioni);
			this.tabInformazioniModPagamento.Location = new System.Drawing.Point(12, 142);
			this.tabInformazioniModPagamento.Name = "tabInformazioniModPagamento";
			this.tabInformazioniModPagamento.SelectedIndex = 0;
			this.tabInformazioniModPagamento.Size = new System.Drawing.Size(623, 415);
			this.tabInformazioniModPagamento.TabIndex = 34;
			// 
			// tabGenerale
			// 
			this.tabGenerale.Controls.Add(this.txtRifDocumentoEsterno);
			this.tabGenerale.Controls.Add(this.label6);
			this.tabGenerale.Controls.Add(this.gboxDelegato);
			this.tabGenerale.Controls.Add(this.gboxCoordinate);
			this.tabGenerale.Location = new System.Drawing.Point(4, 22);
			this.tabGenerale.Name = "tabGenerale";
			this.tabGenerale.Padding = new System.Windows.Forms.Padding(3);
			this.tabGenerale.Size = new System.Drawing.Size(615, 389);
			this.tabGenerale.TabIndex = 0;
			this.tabGenerale.Text = "Generale";
			this.tabGenerale.UseVisualStyleBackColor = true;
			// 
			// txtRifDocumentoEsterno
			// 
			this.txtRifDocumentoEsterno.Location = new System.Drawing.Point(179, 361);
			this.txtRifDocumentoEsterno.Name = "txtRifDocumentoEsterno";
			this.txtRifDocumentoEsterno.ReadOnly = true;
			this.txtRifDocumentoEsterno.Size = new System.Drawing.Size(327, 20);
			this.txtRifDocumentoEsterno.TabIndex = 63;
			this.txtRifDocumentoEsterno.TabStop = false;
			this.txtRifDocumentoEsterno.Tag = "expenselast.refexternaldoc";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 364);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(160, 13);
			this.label6.TabIndex = 62;
			this.label6.Text = "Riferimento Documento Esterno:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxDelegato
			// 
			this.gboxDelegato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDelegato.Controls.Add(this.txtDelegato);
			this.gboxDelegato.Location = new System.Drawing.Point(12, 315);
			this.gboxDelegato.Name = "gboxDelegato";
			this.gboxDelegato.Size = new System.Drawing.Size(589, 40);
			this.gboxDelegato.TabIndex = 61;
			this.gboxDelegato.TabStop = false;
			this.gboxDelegato.Tag = "AutoChoose.txtDelegato.anagrafica.((active!=\'N\')AND(human=\'S\')AND(cf!=\'\')AND(cf i" +
    "s not null))";
			this.gboxDelegato.Text = "Delegato";
			// 
			// txtDelegato
			// 
			this.txtDelegato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDelegato.Location = new System.Drawing.Point(4, 16);
			this.txtDelegato.Name = "txtDelegato";
			this.txtDelegato.Size = new System.Drawing.Size(581, 20);
			this.txtDelegato.TabIndex = 1;
			this.txtDelegato.Tag = "deputy.title?expenseview.deputy";
			// 
			// gboxCoordinate
			// 
			this.gboxCoordinate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxCoordinate.Controls.Add(this.cmbChargeHandling);
			this.gboxCoordinate.Controls.Add(this.btnChargeHandling);
			this.gboxCoordinate.Controls.Add(this.chk_bank_charges_exempt);
			this.gboxCoordinate.Controls.Add(this.groupBox3);
			this.gboxCoordinate.Controls.Add(this.label13);
			this.gboxCoordinate.Controls.Add(this.textBox3);
			this.gboxCoordinate.Controls.Add(this.gboxSportello);
			this.gboxCoordinate.Controls.Add(this.gboxBanca);
			this.gboxCoordinate.Controls.Add(this.btnIBAN);
			this.gboxCoordinate.Controls.Add(this.label10);
			this.gboxCoordinate.Controls.Add(this.txtIBAN);
			this.gboxCoordinate.Controls.Add(this.label8);
			this.gboxCoordinate.Controls.Add(this.btnBBAN);
			this.gboxCoordinate.Controls.Add(this.label7);
			this.gboxCoordinate.Controls.Add(this.txtBBAN);
			this.gboxCoordinate.Controls.Add(this.label5);
			this.gboxCoordinate.Controls.Add(this.txtCin);
			this.gboxCoordinate.Controls.Add(this.label4);
			this.gboxCoordinate.Controls.Add(this.contocorrente);
			this.gboxCoordinate.Location = new System.Drawing.Point(12, 17);
			this.gboxCoordinate.Name = "gboxCoordinate";
			this.gboxCoordinate.Size = new System.Drawing.Size(595, 292);
			this.gboxCoordinate.TabIndex = 60;
			this.gboxCoordinate.TabStop = false;
			this.gboxCoordinate.Text = "Coordinate bancarie";
			// 
			// cmbChargeHandling
			// 
			this.cmbChargeHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbChargeHandling.DataSource = this.DS.chargehandling;
			this.cmbChargeHandling.DisplayMember = "description";
			this.cmbChargeHandling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChargeHandling.Location = new System.Drawing.Point(100, 185);
			this.cmbChargeHandling.Name = "cmbChargeHandling";
			this.cmbChargeHandling.Size = new System.Drawing.Size(290, 21);
			this.cmbChargeHandling.TabIndex = 64;
			this.cmbChargeHandling.Tag = "expenselast.idchargehandling";
			this.cmbChargeHandling.ValueMember = "idchargehandling";
			// 
			// btnChargeHandling
			// 
			this.btnChargeHandling.Location = new System.Drawing.Point(14, 183);
			this.btnChargeHandling.Name = "btnChargeHandling";
			this.btnChargeHandling.Size = new System.Drawing.Size(80, 23);
			this.btnChargeHandling.TabIndex = 63;
			this.btnChargeHandling.TabStop = false;
			this.btnChargeHandling.Tag = "choose.chargehandling.default.(active<>\'N\')";
			this.btnChargeHandling.Text = "Tratt. Spese";
			// 
			// chk_bank_charges_exempt
			// 
			this.chk_bank_charges_exempt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chk_bank_charges_exempt.Location = new System.Drawing.Point(406, 183);
			this.chk_bank_charges_exempt.Name = "chk_bank_charges_exempt";
			this.chk_bank_charges_exempt.Size = new System.Drawing.Size(170, 24);
			this.chk_bank_charges_exempt.TabIndex = 58;
			this.chk_bank_charges_exempt.Tag = "expenselast.flag:3";
			this.chk_bank_charges_exempt.Text = "Esente da Spese Bancarie";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.textBox2);
			this.groupBox3.Location = new System.Drawing.Point(423, 128);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(171, 49);
			this.groupBox3.TabIndex = 57;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Conto Banca d\'Italia";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(36, 19);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(126, 20);
			this.textBox2.TabIndex = 0;
			this.textBox2.Tag = "expenselast.extracode";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(13, 154);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(99, 13);
			this.label13.TabIndex = 33;
			this.label13.Text = "Codice BIC/SWIFT";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(114, 151);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(199, 20);
			this.textBox3.TabIndex = 32;
			this.textBox3.Tag = "expenselast.biccode";
			// 
			// gboxSportello
			// 
			this.gboxSportello.Controls.Add(this.btnCab);
			this.gboxSportello.Controls.Add(this.txtCab);
			this.gboxSportello.Controls.Add(this.txtCabDescr);
			this.gboxSportello.Location = new System.Drawing.Point(312, 48);
			this.gboxSportello.Name = "gboxSportello";
			this.gboxSportello.Size = new System.Drawing.Size(300, 73);
			this.gboxSportello.TabIndex = 3;
			this.gboxSportello.TabStop = false;
			this.gboxSportello.Tag = "AutoChoose.txtCab.default.(flagusable<>\'N\')";
			// 
			// btnCab
			// 
			this.btnCab.Location = new System.Drawing.Point(6, 14);
			this.btnCab.Name = "btnCab";
			this.btnCab.Size = new System.Drawing.Size(100, 23);
			this.btnCab.TabIndex = 4;
			this.btnCab.Tag = "choose.cab.default";
			this.btnCab.Text = "CAB";
			// 
			// txtCab
			// 
			this.txtCab.Location = new System.Drawing.Point(6, 43);
			this.txtCab.Name = "txtCab";
			this.txtCab.Size = new System.Drawing.Size(100, 20);
			this.txtCab.TabIndex = 29;
			this.txtCab.Tag = "cab.idcab?registrypaymethodview.idcab";
			// 
			// txtCabDescr
			// 
			this.txtCabDescr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCabDescr.Location = new System.Drawing.Point(112, 10);
			this.txtCabDescr.Multiline = true;
			this.txtCabDescr.Name = "txtCabDescr";
			this.txtCabDescr.ReadOnly = true;
			this.txtCabDescr.Size = new System.Drawing.Size(164, 58);
			this.txtCabDescr.TabIndex = 1;
			this.txtCabDescr.TabStop = false;
			this.txtCabDescr.Tag = "cab.description";
			// 
			// gboxBanca
			// 
			this.gboxBanca.Controls.Add(this.txtBanca);
			this.gboxBanca.Controls.Add(this.BancaButton);
			this.gboxBanca.Controls.Add(this.txtDescrBanca);
			this.gboxBanca.Location = new System.Drawing.Point(7, 48);
			this.gboxBanca.Name = "gboxBanca";
			this.gboxBanca.Size = new System.Drawing.Size(299, 73);
			this.gboxBanca.TabIndex = 2;
			this.gboxBanca.TabStop = false;
			this.gboxBanca.Tag = "AutoChoose.txtBanca.default.(flagusable<>\'N\')";
			// 
			// txtBanca
			// 
			this.txtBanca.Location = new System.Drawing.Point(9, 43);
			this.txtBanca.Name = "txtBanca";
			this.txtBanca.Size = new System.Drawing.Size(100, 20);
			this.txtBanca.TabIndex = 3;
			this.txtBanca.Tag = "bank.idbank?registrypaymethodview.idbank";
			// 
			// BancaButton
			// 
			this.BancaButton.Location = new System.Drawing.Point(8, 14);
			this.BancaButton.Name = "BancaButton";
			this.BancaButton.Size = new System.Drawing.Size(101, 23);
			this.BancaButton.TabIndex = 2;
			this.BancaButton.Tag = "choose.bank.default.(flagusable<>\'N\')";
			this.BancaButton.Text = "ABI";
			// 
			// txtDescrBanca
			// 
			this.txtDescrBanca.Location = new System.Drawing.Point(129, 10);
			this.txtDescrBanca.Multiline = true;
			this.txtDescrBanca.Name = "txtDescrBanca";
			this.txtDescrBanca.ReadOnly = true;
			this.txtDescrBanca.Size = new System.Drawing.Size(164, 58);
			this.txtDescrBanca.TabIndex = 2;
			this.txtDescrBanca.TabStop = false;
			this.txtDescrBanca.Tag = "bank.description";
			// 
			// btnIBAN
			// 
			this.btnIBAN.Location = new System.Drawing.Point(338, 262);
			this.btnIBAN.Name = "btnIBAN";
			this.btnIBAN.Size = new System.Drawing.Size(176, 23);
			this.btnIBAN.TabIndex = 31;
			this.btnIBAN.TabStop = false;
			this.btnIBAN.Text = "Inserisci direttamente l\'IBAN";
			this.btnIBAN.Click += new System.EventHandler(this.btnIBAN_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(11, 267);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(32, 13);
			this.label10.TabIndex = 30;
			this.label10.Text = "IBAN";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIBAN
			// 
			this.txtIBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIBAN.Location = new System.Drawing.Point(44, 264);
			this.txtIBAN.Name = "txtIBAN";
			this.txtIBAN.ReadOnly = true;
			this.txtIBAN.Size = new System.Drawing.Size(279, 20);
			this.txtIBAN.TabIndex = 29;
			this.txtIBAN.TabStop = false;
			this.txtIBAN.Tag = "expenselast.iban";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(136, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(344, 32);
			this.label8.TabIndex = 27;
			this.label8.Text = "Nota: solo inserendo correttamente tutti i dati sarà visualizzato, nelle stampe, " +
    "il BBAN come da regolamento bancario";
			// 
			// btnBBAN
			// 
			this.btnBBAN.Location = new System.Drawing.Point(338, 230);
			this.btnBBAN.Name = "btnBBAN";
			this.btnBBAN.Size = new System.Drawing.Size(176, 23);
			this.btnBBAN.TabIndex = 24;
			this.btnBBAN.TabStop = false;
			this.btnBBAN.Text = "Inserisci direttamente il BBAN";
			this.btnBBAN.Click += new System.EventHandler(this.btnBBAN_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 235);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "BBAN";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBBAN
			// 
			this.txtBBAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBBAN.Location = new System.Drawing.Point(44, 232);
			this.txtBBAN.Name = "txtBBAN";
			this.txtBBAN.ReadOnly = true;
			this.txtBBAN.Size = new System.Drawing.Size(279, 20);
			this.txtBBAN.TabIndex = 25;
			this.txtBBAN.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 127);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "C/C Italia o Estero:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCin
			// 
			this.txtCin.Location = new System.Drawing.Point(88, 25);
			this.txtCin.Name = "txtCin";
			this.txtCin.Size = new System.Drawing.Size(40, 20);
			this.txtCin.TabIndex = 1;
			this.txtCin.Tag = "expenselast.cin";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "CIN:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contocorrente
			// 
			this.contocorrente.Location = new System.Drawing.Point(114, 127);
			this.contocorrente.Name = "contocorrente";
			this.contocorrente.Size = new System.Drawing.Size(199, 20);
			this.contocorrente.TabIndex = 4;
			this.contocorrente.Tag = "expenselast.cc";
			// 
			// tabOpzioni
			// 
			this.tabOpzioni.Controls.Add(this.groupBox1);
			this.tabOpzioni.Location = new System.Drawing.Point(4, 22);
			this.tabOpzioni.Name = "tabOpzioni";
			this.tabOpzioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabOpzioni.Size = new System.Drawing.Size(615, 389);
			this.tabOpzioni.TabIndex = 1;
			this.tabOpzioni.Text = "Opzioni";
			this.tabOpzioni.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.chkContoCorrPostale);
			this.groupBox1.Controls.Add(this.chkDelegato);
			this.groupBox1.Controls.Add(this.chkStampaAvviso);
			this.groupBox1.Location = new System.Drawing.Point(6, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(308, 364);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Opzioni Tipo Modalità Pagamento";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox8);
			this.groupBox2.Controls.Add(this.checkBox9);
			this.groupBox2.Location = new System.Drawing.Point(5, 78);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(195, 52);
			this.groupBox2.TabIndex = 18;
			this.groupBox2.TabStop = false;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(7, 28);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(97, 17);
			this.checkBox8.TabIndex = 18;
			this.checkBox8.Tag = "expenselast.paymethod_flag:14";
			this.checkBox8.Text = "Bonifico Estero";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(7, 11);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(95, 17);
			this.checkBox9.TabIndex = 17;
			this.checkBox9.Tag = "expenselast.paymethod_flag:13";
			this.checkBox9.Text = "Bonifico SEPA";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(6, 341);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(247, 17);
			this.checkBox7.TabIndex = 14;
			this.checkBox7.Tag = "expenselast.paymethod_flag:12";
			this.checkBox7.Text = "Fruttifera (Tipo Cont. Ente Ricevente Girofondi)";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.checkBox6);
			this.groupBox5.Controls.Add(this.checkBox5);
			this.groupBox5.Controls.Add(this.checkBox2);
			this.groupBox5.Controls.Add(this.checkBox4);
			this.groupBox5.Controls.Add(this.checkBox3);
			this.groupBox5.Controls.Add(this.checkBox1);
			this.groupBox5.Location = new System.Drawing.Point(0, 193);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(278, 142);
			this.groupBox5.TabIndex = 10;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Istituto cassiere";
			this.groupBox5.Visible = false;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(8, 95);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(144, 17);
			this.checkBox6.TabIndex = 13;
			this.checkBox6.Tag = "expenselast.paymethod_flag:11";
			this.checkBox6.Text = "Girofondi vincolati TAB B";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(8, 74);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(139, 17);
			this.checkBox5.TabIndex = 12;
			this.checkBox5.Tag = "expenselast.paymethod_flag:10";
			this.checkBox5.Text = "Girofondi ordinari TAB B";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(8, 118);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(67, 17);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Tag = "expenselast.paymethod_flag:7";
			this.checkBox2.Text = "Sportello";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(8, 55);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(144, 17);
			this.checkBox4.TabIndex = 11;
			this.checkBox4.Tag = "expenselast.paymethod_flag:9";
			this.checkBox4.Text = "Girofondi vincolati TAB A";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(8, 37);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(139, 17);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Tag = "expenselast.paymethod_flag:8";
			this.checkBox3.Text = "Girofondi ordinari TAB A";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(8, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(68, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Tag = "expenselast.paymethod_flag:6";
			this.checkBox1.Text = "Girofondi";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chkObbligoCoordBanc);
			this.groupBox4.Controls.Add(this.chkDivietoCoordBanc);
			this.groupBox4.Location = new System.Drawing.Point(5, 136);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(195, 51);
			this.groupBox4.TabIndex = 9;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Coordinate bancarie";
			// 
			// chkObbligoCoordBanc
			// 
			this.chkObbligoCoordBanc.AutoSize = true;
			this.chkObbligoCoordBanc.Location = new System.Drawing.Point(6, 14);
			this.chkObbligoCoordBanc.Name = "chkObbligoCoordBanc";
			this.chkObbligoCoordBanc.Size = new System.Drawing.Size(82, 17);
			this.chkObbligoCoordBanc.TabIndex = 4;
			this.chkObbligoCoordBanc.Tag = "expenselast.paymethod_flag:2";
			this.chkObbligoCoordBanc.Text = "Obbligatorie";
			this.chkObbligoCoordBanc.UseVisualStyleBackColor = true;
			this.chkObbligoCoordBanc.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// chkDivietoCoordBanc
			// 
			this.chkDivietoCoordBanc.AutoSize = true;
			this.chkDivietoCoordBanc.Location = new System.Drawing.Point(6, 31);
			this.chkDivietoCoordBanc.Name = "chkDivietoCoordBanc";
			this.chkDivietoCoordBanc.Size = new System.Drawing.Size(115, 17);
			this.chkDivietoCoordBanc.TabIndex = 5;
			this.chkDivietoCoordBanc.Tag = "expenselast.paymethod_flag:3";
			this.chkDivietoCoordBanc.Text = "Da non specificare";
			this.chkDivietoCoordBanc.UseVisualStyleBackColor = true;
			this.chkDivietoCoordBanc.CheckedChanged += new System.EventHandler(this.chkDivietoCoordBanc_CheckedChanged);
			this.chkDivietoCoordBanc.CheckStateChanged += new System.EventHandler(this.CheckBoxVincolatoChange);
			// 
			// chkContoCorrPostale
			// 
			this.chkContoCorrPostale.AutoSize = true;
			this.chkContoCorrPostale.Location = new System.Drawing.Point(13, 55);
			this.chkContoCorrPostale.Name = "chkContoCorrPostale";
			this.chkContoCorrPostale.Size = new System.Drawing.Size(133, 17);
			this.chkContoCorrPostale.TabIndex = 8;
			this.chkContoCorrPostale.Tag = "expenselast.paymethod_flag:1";
			this.chkContoCorrPostale.Text = "Conto corrente postale";
			this.chkContoCorrPostale.UseVisualStyleBackColor = true;
			// 
			// chkDelegato
			// 
			this.chkDelegato.AutoSize = true;
			this.chkDelegato.Location = new System.Drawing.Point(13, 19);
			this.chkDelegato.Name = "chkDelegato";
			this.chkDelegato.Size = new System.Drawing.Size(109, 17);
			this.chkDelegato.TabIndex = 3;
			this.chkDelegato.Tag = "expenselast.paymethod_allowdeputy:S:N";
			this.chkDelegato.Text = "Ammetti Delegato";
			this.chkDelegato.CheckedChanged += new System.EventHandler(this.chkDelegato_CheckedChanged);
			// 
			// chkStampaAvviso
			// 
			this.chkStampaAvviso.AutoSize = true;
			this.chkStampaAvviso.Location = new System.Drawing.Point(13, 37);
			this.chkStampaAvviso.Name = "chkStampaAvviso";
			this.chkStampaAvviso.Size = new System.Drawing.Size(163, 17);
			this.chkStampaAvviso.TabIndex = 2;
			this.chkStampaAvviso.Tag = "expenselast.paymethod_flag:0";
			this.chkStampaAvviso.Text = "Stampa avviso di pagamento";
			// 
			// Frm_expenselast_modpaga
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(646, 596);
			this.Controls.Add(this.tabInformazioniModPagamento);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.descrizione);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbModalita);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Frm_expenselast_modpaga";
			this.Text = "frmExpenseRegistryPayMethod";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabInformazioniModPagamento.ResumeLayout(false);
			this.tabGenerale.ResumeLayout(false);
			this.tabGenerale.PerformLayout();
			this.gboxDelegato.ResumeLayout(false);
			this.gboxDelegato.PerformLayout();
			this.gboxCoordinate.ResumeLayout(false);
			this.gboxCoordinate.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.gboxSportello.ResumeLayout(false);
			this.gboxSportello.PerformLayout();
			this.gboxBanca.ResumeLayout(false);
			this.gboxBanca.PerformLayout();
			this.tabOpzioni.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            DataAccess.SetTableForReading(DS.deputy, "registry");
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            chk_bank_charges_exempt.Visible = LeggiFlagEsenteBancaPredefinita();
        }

        private void btnBBAN_Click(object sender, System.EventArgs e) {
            inserisciBBAN();
        }

        private bool controllaBanca(string insertedBBAN) {
            string ABI = insertedBBAN.Substring(1, 5);
            string filtroBanca = QHS.CmpEq("idbank", ABI);
            object codiceABI = Meta.Conn.DO_READ_VALUE("bank", filtroBanca, "idbank");
            if (codiceABI == null) {
                show(this, "La banca inserita nel BBAN non esiste!");
                return false;
            }
            string CAB = insertedBBAN.Substring(6, 5);
            filtroBanca = QHS.AppAnd(filtroBanca, QHS.CmpEq("idcab", CAB));
            object codiceCAB = Meta.Conn.DO_READ_VALUE("cab", filtroBanca, "idcab");
            if (codiceCAB == null) {
                show(this, "Lo sportello inserito nel BBAN non esiste!");
                return false;
            }
            return true;
        }


        private bool LeggiFlagEsenteBancaPredefinita()
        {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        private void inserisciBBAN() {
            string bbanIniziale = txtBBAN.Text == CIN_NON_CORRETTO ? "" : txtBBAN.Text;
            frmaskbban BBAN = new frmaskbban(bbanIniziale);
            if (BBAN.ShowDialog(this) != DialogResult.OK) return;
            if (BBAN.insertedBBAN == "") return;

            if (BBAN.insertedBBAN.Length < 23) {
                show("Testo BBAN italiano inserito troppo corto per calcolare abi cab etc.");
                return;
            }

            bool inserisciDati = controllaBanca(BBAN.insertedBBAN);
            if (!inserisciDati) return;
            string CIN = BBAN.insertedBBAN.Substring(0, 1).ToUpper();
            string ABI = BBAN.insertedBBAN.Substring(1, 5);
            string CAB = BBAN.insertedBBAN.Substring(6, 5);
            string CC = BBAN.insertedBBAN.Substring(11, 12);
            string iban = CfgFn.calcolaIBAN("IT", BBAN.insertedBBAN);
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                DataRow curr = DS.expenselast.Rows[0];
                curr["cin"] = CIN;
                curr["idbank"] = ABI;
                curr["idcab"] = CAB;
                curr["cc"] = CC;
                curr["iban"] = iban;
                Meta.FreshForm();
            }
            else {
                txtBanca.Text = ABI;
                txtCab.Text = CAB;
                txtCin.Text = CIN;
                contocorrente.Text = CC;
            }
            txtBBAN.Text = BBAN.insertedBBAN;
            txtIBAN.Text = iban;
        }

        private void txtCin_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            if (txtCin.Text == "") {
                txtBBAN.Text = "";
                lastCIN = "";
                return;
            }
            if (lastCIN == txtCin.Text.ToUpper()) return;
            lastCIN = txtCin.Text.ToUpper();
            calcolaBBAN();
        }

        private void contocorrente_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            if (contocorrente.Text == "") {
                txtBBAN.Text = "";
                lastCC = "";
                return;
            }
            if (lastCC == contocorrente.Text) return;
            lastCC = contocorrente.Text;
            calcolaBBAN();
        }
        void SetAutoCab(object idbank) {
            string Autochoose = "AutoChoose.txtCab.default.";
            string Choose = "Choose.cab.default.";
            string filter;
            if (idbank != DBNull.Value) {
                //Imposta il filtro sulla banca nello sportello
                filter = QHS.AppAnd(QHS.CmpEq("idbank", idbank), QHS.CmpNe("flagusable", "N"));
            }
            else {
                //Rimuove il filtro sulla banca nello sportello
                filter = QHS.CmpNe("flagusable", "N");
            }
            gboxSportello.Tag = Autochoose + filter;
            btnCab.Tag = Choose + filter;
            Meta.SetAutoMode(gboxSportello);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            switch (T.TableName) {
                case "bank": {
                        if (Meta.DrawStateIsDone) {
                            string Autochoose = "AutoChoose.txtCab.default.";
                            string Choose = "Choose.cab.default.";
                            DS.cab.Clear();
                            txtCab.Text = "";
                            txtCabDescr.Text = "";
                            if (!Meta.IsEmpty) {
                                DataRow Curr = DS.expenselast.Rows[0];
                                Curr["idcab"] = DBNull.Value;
                            }
                            string filter;
                            if (R != null) {
                                //Imposta il filtro sulla banca nello sportello
                                filter = QHS.AppAnd(QHS.CmpEq("idbank", R["idbank"]), QHS.CmpNe("flagusable", "N"));
                            }
                            else {
                                //Rimuove il filtro sulla banca nello sportello
                                filter = QHS.CmpNe("flagusable", "N");
                            }
                            gboxSportello.Tag = Autochoose + filter;
                            btnCab.Tag = Choose + filter;
                            Meta.SetAutoMode(gboxSportello);
                        }

                        if (R == null) {
                            lastABI = "";
                            txtBBAN.Text = "";
                            return;
                        }
                        if (lastABI == R["idbank"].ToString()) return;
                        lastABI = R["idbank"].ToString();
                        //calcolaBBAN();
                        break;
                    }
                case "cab": {
                        if (R != null && Meta.DrawStateIsDone && txtBanca.Text == "") {
                            DS.bank.Clear();
                            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bank, null, QHS.CmpEq("idbank", R["idbank"]), null, false);
                            if (DS.bank.Rows.Count > 0) {
                                DataRow B = DS.bank.Rows[0];
                                txtBanca.Text = B["idbank"].ToString();
                                txtDescrBanca.Text = B["description"].ToString();
                            }
                            SetAutoCab(R["idbank"]);
                        }
                        if (R == null) {
                            lastCAB = "";
                            txtBBAN.Text = "";
                            return;
                        }
                        if (lastCAB == R["idcab"].ToString()) return;
                        lastCAB = R["idcab"].ToString();
                        calcolaBBAN();
                        break;
                    }
                case "paymethod": {
                        if (R != null) {
                            DataRow Curr = DS.expenselast.Rows[0];
                            copiaOpzionidaTipoPag(R);
                            bool ammettiDelegato = (R["allowdeputy"].ToString().ToUpper() == "S");
                            AbilitaDisabilitaDelegato(ammettiDelegato);
                            if (!ammettiDelegato) {
                                azzeraDelegato();
                            }
                        }
                        else {
                            gboxCoordinate.Visible = true;
                            gboxDelegato.Visible = true;
                        }
                        break;
                    }
                case "chargehandling":
                    {
                        if (R != null)
                        {
                            int flag_exemption = (CfgFn.GetNoNullInt32(R["flag"]) & 1);
                            chk_bank_charges_exempt.Checked = !((flag_exemption & 1) == 0);
                        }

                        break;
                    }
            }
        }

        private void AbilitaDisabilitaDelegato(bool ammettiDelegato) {
            if (Meta.IsEmpty) return;
            if (DS.paymethod.Rows.Count == 0) return;
            if (ammettiDelegato) {
                gboxDelegato.Visible = true;
            }
            else {

                gboxDelegato.Visible = false;
            }
        }

        private void azzeraCoordinate() {
            if (Meta.IsEmpty) return;
            if (DS.expense.Rows.Count == 0) return;
            DataRow curr = DS.expenselast.Rows[0];
            txtCin.Text = "";
            curr["iban"] = DBNull.Value;
            curr["cin"] = DBNull.Value;
            curr["idbank"] = DBNull.Value;
            curr["idcab"] = DBNull.Value;
            contocorrente.Text = "";
            curr["cc"] = DBNull.Value;

            txtBanca.Text = "";
            txtCab.Text = "";
            txtDescrBanca.Text = "";
            txtCabDescr.Text = "";
            txtBBAN.Text = "";
            txtIBAN.Text = "";
            DS.bank.Clear();
            DS.cab.Clear();
        }

        private void copiaOpzionidaTipoPag(DataRow R) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.expenselast.Rows.Count == 0) return;
            DataRow curr = DS.expenselast.Rows[0];
            curr["idpaymethod"] = R["idpaymethod"];
            curr["paymethod_allowdeputy"] = R["allowdeputy"];
            curr["paymethod_flag"] = R["flag"];
            Meta.FreshForm();

        }

        private void azzeraDelegato() {
            if (Meta.IsEmpty) return;
            if (DS.expense.Rows.Count == 0) return;
            DataRow curr = DS.expenselast.Rows[0];
            txtDelegato.Text = "";
            curr["iddeputy"] = DBNull.Value;
        }




        private void calcolaBBAN() {
            if (DS.expense.Rows.Count == 0) return;
            if (Meta.DrawStateIsDone) Meta.GetFormData(true);
            DataRow curr = DS.expenselast.Rows[0];
            bool puoiCalcolare =
                ((curr["cin"] != DBNull.Value) &&
                (curr["idbank"] != DBNull.Value) &&
                (curr["idcab"] != DBNull.Value) &&
                (curr["cc"] != DBNull.Value) &&
                (curr["cin"].ToString() != "") &&
                (curr["idbank"].ToString() != "") &&
                (curr["idcab"].ToString() != "") &&
                (curr["cc"].ToString() != ""));
            if (!puoiCalcolare) {
                txtBBAN.Text = "";
                return;
            }
            curr["cin"] = curr["cin"].ToString().ToUpper();
            bool cinCorretto = CfgFn.CheckCIN(curr["cin"].ToString(), curr["idcab"].ToString(), curr["idbank"].ToString(), curr["cc"].ToString());
            if (cinCorretto) {
                txtBBAN.Text = curr["cin"].ToString() + curr["idbank"].ToString() + curr["idcab"].ToString() + curr["cc"].ToString();
                txtIBAN.Text = CfgFn.calcolaIBAN("IT", txtBBAN.Text);
                curr["iban"] = txtIBAN.Text;
            }
            else {
                txtBBAN.Text = CIN_NON_CORRETTO;
                txtIBAN.Text = null;
            }
        }


        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow) {
                DataRow Curr = DS.expenselast.Rows[0];
                SetAutoCab(Curr["idbank"]);
                calcolaBBAN();
            }


            if ((Meta.FirstFillForThisRow) && (Meta.EditMode)) {
                assegnaVarDiConfronto();
                DataRow curr = DS.expenselast.Rows[0];
                string filtroModalita = QHC.CmpEq("idpaymethod", curr["idpaymethod"]);
                DataRow[] rr = DS.paymethod.Select(filtroModalita);
                if (rr.Length > 0) {
                    DataRow rMod = rr[0];
                    bool ammettiDelegato = ((rMod["allowdeputy"].ToString().ToUpper() == "S"));
                    AbilitaDisabilitaDelegato(ammettiDelegato);
                }
                else
                    AbilitaDisabilitaDelegato(false);
            }
        }

        public void assegnaVarDiConfronto() {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.expenselast.Rows[0];

            lastCIN = (curr["cin"] == DBNull.Value) ? "" : curr["cin"].ToString().ToUpper();
            lastABI = (curr["idbank"] == DBNull.Value) ? "" : curr["idbank"].ToString();
            lastCAB = (curr["idcab"] == DBNull.Value) ? "" : curr["idcab"].ToString();
            lastCC = (curr["cc"] == DBNull.Value) ? "" : curr["cc"].ToString();
        }

        private void btnIBAN_Click(object sender, EventArgs e) {
            FrmAskIban frm = new FrmAskIban(txtIBAN.Text);
			DataRow curr = DS.expenselast.Rows[0];
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if ((frm.insertedIBAN == "")||(!frm.insertedIBAN.StartsWith("IT"))) {
			    curr["idbank"] = DBNull.Value;
                curr["idcab"] = DBNull.Value;
				txtBBAN.Text = "";
                txtIBAN.Text = frm.insertedIBAN;
				txtBanca.Text = "";
                txtCab.Text = "";
                txtCin.Text = "";
                contocorrente.Text = "";
                return;
            }

            if (frm.insertedIBAN.StartsWith("IT")) {
                bool inserisciDati = controllaBanca(frm.insertedIBAN.Substring(4));
                if (!inserisciDati) return;
				if (frm.insertedIBAN.Length<27) {
					show("Testo inserito troppo corto per calcolare abi cab etc.");
					return;
				}
            }
           
            string bban = frm.insertedIBAN.Substring(4);
            string CIN = bban.Substring(0, 1).ToUpper();
            string ABI = bban.Substring(1, 5);
            string CAB = bban.Substring(6, 5);
            string CC = bban.Substring(11, 12);
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                if (frm.insertedIBAN.StartsWith("IT")) {
                    curr["cin"] = CIN;
                    curr["idbank"] = ABI;
                    curr["idcab"] = CAB;
                    curr["cc"] = CC;
                    curr["iban"] = frm.insertedIBAN;
                }
                Meta.FreshForm();
            }
            else {
                txtBanca.Text = ABI;
                txtCab.Text = CAB;
                txtCin.Text = CIN;
                contocorrente.Text = CC;
            }
            txtBBAN.Text = frm.insertedIBAN.Substring(4);
            txtIBAN.Text = frm.insertedIBAN;
        }

        private void chkDelegato_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            bool ammettiDelegato = chkDelegato.Checked;

            if (!ammettiDelegato) {
                azzeraDelegato();
            }
            AbilitaDisabilitaDelegato(ammettiDelegato);
        }

        private void chkDivietoCoordBanc_CheckedChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            bool VietaCoordinateBancarie = chkDivietoCoordBanc.Checked;
            if (VietaCoordinateBancarie) {
                azzeraCoordinate();
            }
        }

        void DeselezionaAltriCheckBox(GroupBox G, CheckBox C) {
            if (C.CheckState != CheckState.Checked) return;
            foreach (Control c in G.Controls) {
                if (c == C) continue;
                CheckBox chk = c as CheckBox;
                if (chk == null) continue;
                if (chk.CheckState == CheckState.Checked) chk.Checked = false;
            }
        }

        private void CheckBoxVincolatoChange(object sender, EventArgs e) {
            CheckBox C = sender as CheckBox;
            if (C == null) {
                show("Metodo CheckBoxVincolatoChange con parametro non checkbox", "Errore");
                return;
            }
            GroupBox CParent = C.Parent as GroupBox;
            if (CParent == null) {
                show("Metodo CheckBoxVincolatoChange con parametro checkbox non contenuto in g.box", "Errore");
                return;
            }
            DeselezionaAltriCheckBox(CParent, C);
        }
    }
}

