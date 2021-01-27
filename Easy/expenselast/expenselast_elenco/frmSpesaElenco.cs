
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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione

namespace expenselast_elenco//spesamodcreddebi//
{
    /// <summary>
    /// Summary description for frmSpesaModCredDebi.
    /// </summary>
    public class Frm_expenselast_elenco : System.Windows.Forms.Form {
        const string CIN_NON_CORRETTO = "CIN non corretto!";
        MetaData Meta;
        string lastCIN = "";
        string lastABI = "";
        string lastCAB = "";
        string lastCC = "";
        bool inChiusura = false;
        public vistaForm DS;
        private GroupBox grpDescrizione;
        private TextBox txtDescrizione;
        private GroupBox grpImporti;
        private TextBox textBox4;
        private Label label9;
        private Label lblImportoEsitato;
        private Label label12;
        private TextBox txtImportoDisponibile;
        private TextBox txtImportoCorrente;
        private GroupBox gboxBolletta;
        private TextBox SubEntity_txtBolletta;
        private GroupBox grpMandato;
        private TextBox SubEntity_txtNumMandato;
        private Label label28;
        private CheckBox SubEntity_chbCoperturaIniziativa;
        private Label label11;
        private TextBox txtNum;
        private Label label14;
        private TextBox txtEserc;
        private Label label15;
        private ComboBox cmbFaseSpesa;
		private Label lblBolletta;
		private GroupBox grpDocCollegato;
		private TextBox txtDocumento;
		private Label label10;
		private TextBox txtDataDocumento;
		private Label label2;
		private GroupBox grpResponsabile;
		public TextBox SubEntity_txtResponsabile;
		private GroupBox grpBilancio;
		private TextBox txtCodiceBilancio;
		private TextBox txtDenominazioneBilancio;
		private GroupBox grpUpb;
		private TextBox txtUpb;
		private TextBox textBox3;
		private GroupBox grpDate;
		private Label label5;
		private TextBox txtDataCont;
		private TextBox txtScadenza;
		private Label label13;
		private Label label6;
		private DataGrid dataGrid2;
		private Label label7;
		private DataGrid dataGrid1;
		private Button btnBilancio;
		private Button btnUpb;
		private GroupBox groupCredDeb;
		private TextBox txtCredDeb;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frm_expenselast_elenco() {
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
			this.grpDescrizione = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.grpImporti = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.lblImportoEsitato = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
			this.txtImportoCorrente = new System.Windows.Forms.TextBox();
			this.gboxBolletta = new System.Windows.Forms.GroupBox();
			this.lblBolletta = new System.Windows.Forms.Label();
			this.SubEntity_txtBolletta = new System.Windows.Forms.TextBox();
			this.grpMandato = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtNumMandato = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.SubEntity_chbCoperturaIniziativa = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.DS = new expenselast_elenco.vistaForm();
			this.grpDocCollegato = new System.Windows.Forms.GroupBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpResponsabile = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtResponsabile = new System.Windows.Forms.TextBox();
			this.grpBilancio = new System.Windows.Forms.GroupBox();
			this.btnBilancio = new System.Windows.Forms.Button();
			this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
			this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
			this.grpUpb = new System.Windows.Forms.GroupBox();
			this.btnUpb = new System.Windows.Forms.Button();
			this.txtUpb = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.grpDate = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataCont = new System.Windows.Forms.TextBox();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.label7 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.grpDescrizione.SuspendLayout();
			this.grpImporti.SuspendLayout();
			this.gboxBolletta.SuspendLayout();
			this.grpMandato.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpDocCollegato.SuspendLayout();
			this.grpResponsabile.SuspendLayout();
			this.grpBilancio.SuspendLayout();
			this.grpUpb.SuspendLayout();
			this.grpDate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupCredDeb.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpDescrizione
			// 
			this.grpDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDescrizione.Controls.Add(this.txtDescrizione);
			this.grpDescrizione.Location = new System.Drawing.Point(25, 97);
			this.grpDescrizione.Name = "grpDescrizione";
			this.grpDescrizione.Size = new System.Drawing.Size(301, 56);
			this.grpDescrizione.TabIndex = 63;
			this.grpDescrizione.TabStop = false;
			this.grpDescrizione.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(285, 34);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "expense.description?expenselastview.description";
			// 
			// grpImporti
			// 
			this.grpImporti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpImporti.Controls.Add(this.textBox4);
			this.grpImporti.Controls.Add(this.label9);
			this.grpImporti.Controls.Add(this.lblImportoEsitato);
			this.grpImporti.Controls.Add(this.label12);
			this.grpImporti.Controls.Add(this.txtImportoDisponibile);
			this.grpImporti.Controls.Add(this.txtImportoCorrente);
			this.grpImporti.Location = new System.Drawing.Point(24, 352);
			this.grpImporti.Name = "grpImporti";
			this.grpImporti.Size = new System.Drawing.Size(609, 64);
			this.grpImporti.TabIndex = 62;
			this.grpImporti.TabStop = false;
			this.grpImporti.Text = "Situazione riassuntiva importo del movimento";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(404, 38);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(113, 20);
			this.textBox4.TabIndex = 2;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "expenselastview.notperformed?x";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(327, 39);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 20);
			this.label9.TabIndex = 1;
			this.label9.Text = "Non Esitato:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblImportoEsitato
			// 
			this.lblImportoEsitato.Location = new System.Drawing.Point(8, 40);
			this.lblImportoEsitato.Name = "lblImportoEsitato";
			this.lblImportoEsitato.Size = new System.Drawing.Size(192, 20);
			this.lblImportoEsitato.TabIndex = 0;
			this.lblImportoEsitato.Text = "Esitato:";
			this.lblImportoEsitato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 12);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(200, 24);
			this.label12.TabIndex = 0;
			this.label12.Text = "Attuale (comprensivo delle variazioni):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoDisponibile
			// 
			this.txtImportoDisponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoDisponibile.Location = new System.Drawing.Point(208, 40);
			this.txtImportoDisponibile.Name = "txtImportoDisponibile";
			this.txtImportoDisponibile.Size = new System.Drawing.Size(113, 20);
			this.txtImportoDisponibile.TabIndex = 0;
			this.txtImportoDisponibile.TabStop = false;
			this.txtImportoDisponibile.Tag = "expenselastview.performed?x";
			// 
			// txtImportoCorrente
			// 
			this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoCorrente.Location = new System.Drawing.Point(208, 16);
			this.txtImportoCorrente.Name = "txtImportoCorrente";
			this.txtImportoCorrente.Size = new System.Drawing.Size(113, 20);
			this.txtImportoCorrente.TabIndex = 0;
			this.txtImportoCorrente.TabStop = false;
			this.txtImportoCorrente.Tag = "expensetotal.curramount?expenselastview.curramount";
			// 
			// gboxBolletta
			// 
			this.gboxBolletta.Controls.Add(this.lblBolletta);
			this.gboxBolletta.Controls.Add(this.SubEntity_txtBolletta);
			this.gboxBolletta.Location = new System.Drawing.Point(184, 288);
			this.gboxBolletta.Name = "gboxBolletta";
			this.gboxBolletta.Size = new System.Drawing.Size(188, 36);
			this.gboxBolletta.TabIndex = 58;
			this.gboxBolletta.TabStop = false;
			this.gboxBolletta.Tag = "AutoChoose.SubEntity_txtBolletta.spesa.(active=\'S\')";
			// 
			// lblBolletta
			// 
			this.lblBolletta.Location = new System.Drawing.Point(6, 12);
			this.lblBolletta.Name = "lblBolletta";
			this.lblBolletta.Size = new System.Drawing.Size(50, 20);
			this.lblBolletta.TabIndex = 2;
			this.lblBolletta.Text = "Bolletta:";
			this.lblBolletta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtBolletta
			// 
			this.SubEntity_txtBolletta.Location = new System.Drawing.Point(62, 12);
			this.SubEntity_txtBolletta.Name = "SubEntity_txtBolletta";
			this.SubEntity_txtBolletta.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtBolletta.TabIndex = 1;
			this.SubEntity_txtBolletta.Tag = "bill.nbill?x";
			// 
			// grpMandato
			// 
			this.grpMandato.Controls.Add(this.SubEntity_txtNumMandato);
			this.grpMandato.Controls.Add(this.label28);
			this.grpMandato.Location = new System.Drawing.Point(25, 288);
			this.grpMandato.Name = "grpMandato";
			this.grpMandato.Size = new System.Drawing.Size(153, 50);
			this.grpMandato.TabIndex = 57;
			this.grpMandato.TabStop = false;
			this.grpMandato.Tag = "AutoChoose.SubEntity_txtNumMandato.default ";
			this.grpMandato.Text = "Mandato di pagamento";
			// 
			// SubEntity_txtNumMandato
			// 
			this.SubEntity_txtNumMandato.Location = new System.Drawing.Point(59, 20);
			this.SubEntity_txtNumMandato.Name = "SubEntity_txtNumMandato";
			this.SubEntity_txtNumMandato.Size = new System.Drawing.Size(64, 20);
			this.SubEntity_txtNumMandato.TabIndex = 2;
			this.SubEntity_txtNumMandato.Tag = "payment.npay?expenselastview.npay";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(6, 20);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 13;
			this.label28.Text = "Numero:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_chbCoperturaIniziativa
			// 
			this.SubEntity_chbCoperturaIniziativa.Enabled = false;
			this.SubEntity_chbCoperturaIniziativa.Location = new System.Drawing.Point(184, 323);
			this.SubEntity_chbCoperturaIniziativa.Name = "SubEntity_chbCoperturaIniziativa";
			this.SubEntity_chbCoperturaIniziativa.Size = new System.Drawing.Size(179, 29);
			this.SubEntity_chbCoperturaIniziativa.TabIndex = 59;
			this.SubEntity_chbCoperturaIniziativa.Tag = "expenselast.flag:0?expenselastview.flag:0";
			this.SubEntity_chbCoperturaIniziativa.Text = "Pagamento a regolarizzazione";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(19, 19);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(40, 16);
			this.label11.TabIndex = 51;
			this.label11.Text = "Fase";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNum
			// 
			this.txtNum.Location = new System.Drawing.Point(526, 21);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(99, 20);
			this.txtNum.TabIndex = 56;
			this.txtNum.Tag = "expense.nmov?expenselastview.nmov";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(459, 21);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(54, 16);
			this.label14.TabIndex = 55;
			this.label14.Text = "Numero:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(385, 21);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 54;
			this.txtEserc.Tag = "expense.ymov.year?expenselastview.ymov.year";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(304, 22);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(75, 16);
			this.label15.TabIndex = 52;
			this.label15.Text = "Esercizio:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbFaseSpesa
			// 
			this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFaseSpesa.DataSource = this.DS.expensephase;
			this.cmbFaseSpesa.DisplayMember = "description";
			this.cmbFaseSpesa.Location = new System.Drawing.Point(66, 20);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(232, 21);
			this.cmbFaseSpesa.TabIndex = 53;
			this.cmbFaseSpesa.Tag = "expensephase.nphase?expenselastview.nphase";
			this.cmbFaseSpesa.ValueMember = "nphase";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			// 
			// grpDocCollegato
			// 
			this.grpDocCollegato.Controls.Add(this.txtDocumento);
			this.grpDocCollegato.Controls.Add(this.label10);
			this.grpDocCollegato.Controls.Add(this.txtDataDocumento);
			this.grpDocCollegato.Controls.Add(this.label2);
			this.grpDocCollegato.Location = new System.Drawing.Point(337, 97);
			this.grpDocCollegato.Name = "grpDocCollegato";
			this.grpDocCollegato.Size = new System.Drawing.Size(302, 56);
			this.grpDocCollegato.TabIndex = 64;
			this.grpDocCollegato.TabStop = false;
			this.grpDocCollegato.Text = "Documento collegato";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(8, 32);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(200, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "expense.doc?expenselastview.doc";
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
			this.txtDataDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDocumento.Location = new System.Drawing.Point(222, 32);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(66, 20);
			this.txtDataDocumento.TabIndex = 2;
			this.txtDataDocumento.Tag = "expense.docdate?expenselastview.docdate";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(232, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Data";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpResponsabile
			// 
			this.grpResponsabile.Controls.Add(this.SubEntity_txtResponsabile);
			this.grpResponsabile.Location = new System.Drawing.Point(339, 155);
			this.grpResponsabile.Name = "grpResponsabile";
			this.grpResponsabile.Size = new System.Drawing.Size(300, 40);
			this.grpResponsabile.TabIndex = 95;
			this.grpResponsabile.TabStop = false;
			this.grpResponsabile.Tag = "AutoChoose.SubEntity_txtResponsabile.default.(active=\'S\')";
			this.grpResponsabile.Text = "Responsabile";
			// 
			// SubEntity_txtResponsabile
			// 
			this.SubEntity_txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtResponsabile.Location = new System.Drawing.Point(7, 14);
			this.SubEntity_txtResponsabile.Name = "SubEntity_txtResponsabile";
			this.SubEntity_txtResponsabile.Size = new System.Drawing.Size(286, 20);
			this.SubEntity_txtResponsabile.TabIndex = 1;
			this.SubEntity_txtResponsabile.Tag = "manager.title?expenselastview.manager";
			// 
			// grpBilancio
			// 
			this.grpBilancio.Controls.Add(this.btnBilancio);
			this.grpBilancio.Controls.Add(this.txtCodiceBilancio);
			this.grpBilancio.Controls.Add(this.txtDenominazioneBilancio);
			this.grpBilancio.Location = new System.Drawing.Point(339, 200);
			this.grpBilancio.Name = "grpBilancio";
			this.grpBilancio.Size = new System.Drawing.Size(301, 86);
			this.grpBilancio.TabIndex = 93;
			this.grpBilancio.TabStop = false;
			this.grpBilancio.Tag = "AutoManage.txtCodiceBilancio.treealls";
			this.grpBilancio.Text = " Bilancio";
			// 
			// btnBilancio
			// 
			this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
			this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancio.ImageIndex = 0;
			this.btnBilancio.Location = new System.Drawing.Point(11, 33);
			this.btnBilancio.Name = "btnBilancio";
			this.btnBilancio.Size = new System.Drawing.Size(112, 20);
			this.btnBilancio.TabIndex = 3;
			this.btnBilancio.TabStop = false;
			this.btnBilancio.Tag = "manage.fin.treealls";
			this.btnBilancio.Text = "Bilancio:";
			this.btnBilancio.UseVisualStyleBackColor = false;
			// 
			// txtCodiceBilancio
			// 
			this.txtCodiceBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceBilancio.Location = new System.Drawing.Point(11, 56);
			this.txtCodiceBilancio.Name = "txtCodiceBilancio";
			this.txtCodiceBilancio.Size = new System.Drawing.Size(285, 20);
			this.txtCodiceBilancio.TabIndex = 1;
			this.txtCodiceBilancio.Tag = "fin.codefin?expenselastview.codefin";
			// 
			// txtDenominazioneBilancio
			// 
			this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneBilancio.Location = new System.Drawing.Point(123, 8);
			this.txtDenominazioneBilancio.Multiline = true;
			this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
			this.txtDenominazioneBilancio.ReadOnly = true;
			this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneBilancio.Size = new System.Drawing.Size(173, 45);
			this.txtDenominazioneBilancio.TabIndex = 2;
			this.txtDenominazioneBilancio.TabStop = false;
			this.txtDenominazioneBilancio.Tag = "fin.title";
			// 
			// grpUpb
			// 
			this.grpUpb.Controls.Add(this.btnUpb);
			this.grpUpb.Controls.Add(this.txtUpb);
			this.grpUpb.Controls.Add(this.textBox3);
			this.grpUpb.Location = new System.Drawing.Point(25, 200);
			this.grpUpb.Name = "grpUpb";
			this.grpUpb.Size = new System.Drawing.Size(301, 86);
			this.grpUpb.TabIndex = 96;
			this.grpUpb.TabStop = false;
			this.grpUpb.Tag = "AutoManage.txtUpb.tree";
			this.grpUpb.Text = " UPB";
			// 
			// btnUpb
			// 
			this.btnUpb.Location = new System.Drawing.Point(11, 33);
			this.btnUpb.Name = "btnUpb";
			this.btnUpb.Size = new System.Drawing.Size(104, 20);
			this.btnUpb.TabIndex = 3;
			this.btnUpb.Tag = "manage.upb.tree";
			this.btnUpb.Text = "U.P.B.:";
			// 
			// txtUpb
			// 
			this.txtUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUpb.Location = new System.Drawing.Point(11, 56);
			this.txtUpb.Name = "txtUpb";
			this.txtUpb.Size = new System.Drawing.Size(285, 20);
			this.txtUpb.TabIndex = 1;
			this.txtUpb.Tag = "upb.codeupb?expenselastview.codeupb";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(121, 8);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(175, 45);
			this.textBox3.TabIndex = 2;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "upb.title";
			// 
			// grpDate
			// 
			this.grpDate.Controls.Add(this.label5);
			this.grpDate.Controls.Add(this.txtDataCont);
			this.grpDate.Controls.Add(this.txtScadenza);
			this.grpDate.Controls.Add(this.label13);
			this.grpDate.Location = new System.Drawing.Point(25, 155);
			this.grpDate.Name = "grpDate";
			this.grpDate.Size = new System.Drawing.Size(301, 40);
			this.grpDate.TabIndex = 97;
			this.grpDate.TabStop = false;
			this.grpDate.Text = "Data";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(2, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 20);
			this.label5.TabIndex = 0;
			this.label5.Text = "Contabile";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataCont
			// 
			this.txtDataCont.Location = new System.Drawing.Point(58, 16);
			this.txtDataCont.Name = "txtDataCont";
			this.txtDataCont.Size = new System.Drawing.Size(72, 20);
			this.txtDataCont.TabIndex = 1;
			this.txtDataCont.Tag = "expense.adate";
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(217, 16);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(72, 20);
			this.txtScadenza.TabIndex = 2;
			this.txtScadenza.Tag = "expense.expiration";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(145, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 20);
			this.label13.TabIndex = 0;
			this.label13.Text = "Scadenza:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(21, 420);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(606, 16);
			this.label6.TabIndex = 99;
			this.label6.Text = "Dettaglio dei movimenti bancari associati";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(22, 434);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(610, 73);
			this.dataGrid2.TabIndex = 98;
			this.dataGrid2.Tag = "payment_bankview.default";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(20, 518);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(606, 16);
			this.label7.TabIndex = 100;
			this.label7.Text = "Dettaglio delle esitazioni bancarie";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(23, 534);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(610, 65);
			this.dataGrid1.TabIndex = 101;
			this.dataGrid1.Tag = "banktransactionview.default";
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(25, 51);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(397, 40);
			this.groupCredDeb.TabIndex = 102;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.groupCredDeb.Text = "Percipiente";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(9, 14);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(382, 20);
			this.txtCredDeb.TabIndex = 1;
			this.txtCredDeb.Tag = "registry.title?expenselastview.registry";
			// 
			// Frm_expenselast_elenco
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(646, 605);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dataGrid2);
			this.Controls.Add(this.grpDate);
			this.Controls.Add(this.grpUpb);
			this.Controls.Add(this.grpResponsabile);
			this.Controls.Add(this.grpBilancio);
			this.Controls.Add(this.grpDocCollegato);
			this.Controls.Add(this.grpDescrizione);
			this.Controls.Add(this.grpImporti);
			this.Controls.Add(this.gboxBolletta);
			this.Controls.Add(this.grpMandato);
			this.Controls.Add(this.SubEntity_chbCoperturaIniziativa);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.txtNum);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.txtEserc);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.cmbFaseSpesa);
			this.Name = "Frm_expenselast_elenco";
			this.Text = "frmExpenseLastElenco";
			this.grpDescrizione.ResumeLayout(false);
			this.grpDescrizione.PerformLayout();
			this.grpImporti.ResumeLayout(false);
			this.grpImporti.PerformLayout();
			this.gboxBolletta.ResumeLayout(false);
			this.gboxBolletta.PerformLayout();
			this.grpMandato.ResumeLayout(false);
			this.grpMandato.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpDocCollegato.ResumeLayout(false);
			this.grpDocCollegato.PerformLayout();
			this.grpResponsabile.ResumeLayout(false);
			this.grpResponsabile.PerformLayout();
			this.grpBilancio.ResumeLayout(false);
			this.grpBilancio.PerformLayout();
			this.grpUpb.ResumeLayout(false);
			this.grpUpb.PerformLayout();
			this.grpDate.ResumeLayout(false);
			this.grpDate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		 int esercizio;
	    string filteresercizio;
		int maxexpensephase ;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
 			maxexpensephase  = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            filteresercizio = QHS.CmpEq("ymov", esercizio);
			GetData.CacheTable(DS.expensephase, QHS.CmpEq("nphase", maxexpensephase), "nphase", true);
		    GetData.SetStaticFilter(DS.expenselastview, filteresercizio);
			string billfilter = QHS.AppAnd(QHS.CmpEq("billkind", "D"),QHS.CmpEq("ybill", esercizio));
			GetData.SetStaticFilter(DS.bill, billfilter);
		    GetData.SetStaticFilter(DS.billview, billfilter);
			GetData.SetStaticFilter(DS.banktransactionview, QHS.CmpEq("yban", esercizio)); 
			GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", esercizio));
			GetData.SetStaticFilter(DS.fin, QHS.CmpEq("ayear", esercizio)); 
			txtEserc.Text= esercizio.ToString();
        }
 
		 public void MetaData_AfterFill() {
            enableControls(false);
        }
	 public void MetaData_AfterClear() {
            enableControls(true);
			txtEserc.Text= esercizio.ToString();
        }

		  private void enableControls(bool abilita) {
            bool readOnly = !abilita;
			this.cmbFaseSpesa.Enabled = abilita;
			this.txtEserc.ReadOnly = readOnly;
			this.txtNum.ReadOnly = readOnly;
			this.grpDescrizione.Enabled = abilita;
		 	this.grpImporti.Enabled = abilita;
			 
			this.gboxBolletta.Enabled = abilita;
			this.grpMandato.Enabled = abilita;
			this.SubEntity_chbCoperturaIniziativa.Enabled = abilita;
			 
		 	this.grpDocCollegato.Enabled = abilita;
			this.grpResponsabile.Enabled = abilita;
			this.grpBilancio.Enabled = abilita;
			this.grpUpb.Enabled = abilita;
			this.grpDate.Enabled = abilita;
			this.grpImporti.Enabled = abilita;
	 
		}

 
    }
}

