
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
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Collections.Generic;
using System.Text;
using siopeplus_functions;
using pagamenti = bankdispositionsetup_siopeplus_pagamenti;
using System.Linq;
using q= metadatalibrary.MetaExpression;

namespace payment_generazioneautomatica { //documentopagamento_gener_auto//

    /// <summary>
    /// Summary description for frmdocumentopagamento_gener_auto.
    /// Revised By Nino on 26/1/2003
    /// Revised By Nino on 10/2/2003 (Removed 1 SqlRunner)
    /// Revised By Nino on 20/2/2003 (Rewritten filter, changed many)
    /// </summary>
    public class Frm_payment_generazioneautomatica : System.Windows.Forms.Form {
        QueryHelper QHS;
        CQueryHelper QHC;
        private System.Windows.Forms.ComboBox cmbBollo;
        private System.Windows.Forms.Button btnBollo;
        private System.Windows.Forms.ComboBox cmbCodiceIstituto;
        private System.Windows.Forms.Button btnIstitutoCassiere;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEsercizioDocumento;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.TextBox txtCreditoreDebitore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnInizia;
        private System.Windows.Forms.Button btnSuccessivo;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnSiTutti;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        public vistaForm DS;
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtResponsabile;
        private System.Windows.Forms.GroupBox groupBox6;
        DataTable TempTable;
        int limiteOPIinByte = 184320;
        private System.Windows.Forms.GroupBox grpConferma;
        private System.Windows.Forms.DataGrid DetailGrid;
        MetaData Meta;
        DataAccess Conn;
        object livbilancio = DBNull.Value;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox5;
        private CheckBox chkCSA;
        private CheckBox chkEscludiZero;
        private Label label10;
        private TextBox textBox1;
        private CheckBox chkPagamentiAzzeramentiFineAnno;
        private Label label6;
        private TextBox txtdataScadenza;
        private System.ComponentModel.IContainer components;

        public Frm_payment_generazioneautomatica() {
            InitializeComponent();
            TempTable = new DataTable("temptable");
            QueryCreator.SetTableForPosting(DS.expenselastview, "expenselast");
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_payment_generazioneautomatica));
			this.cmbBollo = new System.Windows.Forms.ComboBox();
			this.DS = new payment_generazioneautomatica.vistaForm();
			this.btnBollo = new System.Windows.Forms.Button();
			this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
			this.btnIstitutoCassiere = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizioDocumento = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTipoDocumento = new System.Windows.Forms.TextBox();
			this.txtDescrBilancio = new System.Windows.Forms.TextBox();
			this.txtBilancio = new System.Windows.Forms.TextBox();
			this.txtCreditoreDebitore = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.btnInizia = new System.Windows.Forms.Button();
			this.btnSuccessivo = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.grpConferma = new System.Windows.Forms.GroupBox();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnSiTutti = new System.Windows.Forms.Button();
			this.btnSi = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.DetailGrid = new System.Windows.Forms.DataGrid();
			this.label5 = new System.Windows.Forms.Label();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.chkCSA = new System.Windows.Forms.CheckBox();
			this.chkEscludiZero = new System.Windows.Forms.CheckBox();
			this.chkPagamentiAzzeramentiFineAnno = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtdataScadenza = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpConferma.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbBollo
			// 
			this.cmbBollo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cmbBollo.DataSource = this.DS.stamphandling;
			this.cmbBollo.DisplayMember = "description";
			this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBollo.Location = new System.Drawing.Point(368, 19);
			this.cmbBollo.Name = "cmbBollo";
			this.cmbBollo.Size = new System.Drawing.Size(260, 21);
			this.cmbBollo.TabIndex = 1;
			this.cmbBollo.Tag = "payment.idstamphandling";
			this.cmbBollo.ValueMember = "idstamphandling";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnBollo
			// 
			this.btnBollo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnBollo.Location = new System.Drawing.Point(312, 19);
			this.btnBollo.Name = "btnBollo";
			this.btnBollo.Size = new System.Drawing.Size(48, 24);
			this.btnBollo.TabIndex = 54;
			this.btnBollo.TabStop = false;
			this.btnBollo.Tag = "choose.stamphandling.lista";
			this.btnBollo.Text = "Bollo:";
			this.btnBollo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbCodiceIstituto
			// 
			this.cmbCodiceIstituto.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
			this.cmbCodiceIstituto.DisplayMember = "description";
			this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodiceIstituto.Location = new System.Drawing.Point(80, 19);
			this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
			this.cmbCodiceIstituto.Size = new System.Drawing.Size(224, 21);
			this.cmbCodiceIstituto.TabIndex = 1;
			this.cmbCodiceIstituto.Tag = "payment.idtreasurer";
			this.cmbCodiceIstituto.ValueMember = "idtreasurer";
			// 
			// btnIstitutoCassiere
			// 
			this.btnIstitutoCassiere.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 19);
			this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
			this.btnIstitutoCassiere.Size = new System.Drawing.Size(64, 24);
			this.btnIstitutoCassiere.TabIndex = 52;
			this.btnIstitutoCassiere.TabStop = false;
			this.btnIstitutoCassiere.Tag = "choose.treasurer.lista";
			this.btnIstitutoCassiere.Text = "Cassiere:";
			this.btnIstitutoCassiere.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNumeroDocumento);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtEsercizioDocumento);
			this.groupBox1.Location = new System.Drawing.Point(8, 69);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(168, 64);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Documento";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumeroDocumento
			// 
			this.txtNumeroDocumento.Location = new System.Drawing.Point(80, 40);
			this.txtNumeroDocumento.Name = "txtNumeroDocumento";
			this.txtNumeroDocumento.ReadOnly = true;
			this.txtNumeroDocumento.Size = new System.Drawing.Size(80, 20);
			this.txtNumeroDocumento.TabIndex = 2;
			this.txtNumeroDocumento.TabStop = false;
			this.txtNumeroDocumento.Tag = "payment.npay";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioDocumento
			// 
			this.txtEsercizioDocumento.Location = new System.Drawing.Point(80, 16);
			this.txtEsercizioDocumento.Name = "txtEsercizioDocumento";
			this.txtEsercizioDocumento.ReadOnly = true;
			this.txtEsercizioDocumento.Size = new System.Drawing.Size(56, 20);
			this.txtEsercizioDocumento.TabIndex = 0;
			this.txtEsercizioDocumento.TabStop = false;
			this.txtEsercizioDocumento.Tag = "payment.ypay";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTipoDocumento);
			this.groupBox2.Location = new System.Drawing.Point(184, 69);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 64);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tipo";
			// 
			// txtTipoDocumento
			// 
			this.txtTipoDocumento.Location = new System.Drawing.Point(16, 24);
			this.txtTipoDocumento.Name = "txtTipoDocumento";
			this.txtTipoDocumento.ReadOnly = true;
			this.txtTipoDocumento.Size = new System.Drawing.Size(112, 20);
			this.txtTipoDocumento.TabIndex = 3;
			this.txtTipoDocumento.Tag = "";
			// 
			// txtDescrBilancio
			// 
			this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBilancio.Location = new System.Drawing.Point(112, 16);
			this.txtDescrBilancio.Multiline = true;
			this.txtDescrBilancio.Name = "txtDescrBilancio";
			this.txtDescrBilancio.ReadOnly = true;
			this.txtDescrBilancio.Size = new System.Drawing.Size(547, 48);
			this.txtDescrBilancio.TabIndex = 57;
			this.txtDescrBilancio.TabStop = false;
			this.txtDescrBilancio.Tag = "fin.title";
			// 
			// txtBilancio
			// 
			this.txtBilancio.Location = new System.Drawing.Point(8, 40);
			this.txtBilancio.Name = "txtBilancio";
			this.txtBilancio.ReadOnly = true;
			this.txtBilancio.Size = new System.Drawing.Size(96, 20);
			this.txtBilancio.TabIndex = 56;
			this.txtBilancio.TabStop = false;
			this.txtBilancio.Tag = "fin.codefin?paymentview.codefin";
			// 
			// txtCreditoreDebitore
			// 
			this.txtCreditoreDebitore.Location = new System.Drawing.Point(8, 81);
			this.txtCreditoreDebitore.Name = "txtCreditoreDebitore";
			this.txtCreditoreDebitore.ReadOnly = true;
			this.txtCreditoreDebitore.Size = new System.Drawing.Size(280, 20);
			this.txtCreditoreDebitore.TabIndex = 58;
			this.txtCreditoreDebitore.TabStop = false;
			this.txtCreditoreDebitore.Tag = "registry.title?paymentview.registry";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 16);
			this.label3.TabIndex = 59;
			this.label3.Text = "Percipiente:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(112, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
			this.txtDataContabile.TabIndex = 3;
			this.txtDataContabile.Tag = "payment.adate";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 16);
			this.label9.TabIndex = 63;
			this.label9.Text = "Data contabile:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.ImageIndex = 0;
			this.label4.ImageList = this.imageList1;
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 64;
			this.label4.Text = "Bilancio:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(304, 65);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 16);
			this.label7.TabIndex = 65;
			this.label7.Text = "Responsabile:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(304, 81);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.ReadOnly = true;
			this.txtResponsabile.Size = new System.Drawing.Size(507, 20);
			this.txtResponsabile.TabIndex = 66;
			this.txtResponsabile.TabStop = false;
			this.txtResponsabile.Tag = "manager.title";
			// 
			// btnInizia
			// 
			this.btnInizia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInizia.Location = new System.Drawing.Point(8, 16);
			this.btnInizia.Name = "btnInizia";
			this.btnInizia.Size = new System.Drawing.Size(80, 23);
			this.btnInizia.TabIndex = 68;
			this.btnInizia.TabStop = false;
			this.btnInizia.Text = "Inizia Ricerca";
			this.btnInizia.Click += new System.EventHandler(this.btnInizia_Click);
			// 
			// btnSuccessivo
			// 
			this.btnSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSuccessivo.Enabled = false;
			this.btnSuccessivo.Location = new System.Drawing.Point(96, 16);
			this.btnSuccessivo.Name = "btnSuccessivo";
			this.btnSuccessivo.Size = new System.Drawing.Size(80, 23);
			this.btnSuccessivo.TabIndex = 69;
			this.btnSuccessivo.TabStop = false;
			this.btnSuccessivo.Text = "Prossimo >>";
			this.btnSuccessivo.Click += new System.EventHandler(this.btnSuccessivo_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(184, 16);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.Size = new System.Drawing.Size(80, 23);
			this.btnChiudi.TabIndex = 70;
			this.btnChiudi.TabStop = false;
			this.btnChiudi.Text = "Termina";
			// 
			// grpConferma
			// 
			this.grpConferma.Controls.Add(this.btnNo);
			this.grpConferma.Controls.Add(this.btnSiTutti);
			this.grpConferma.Controls.Add(this.btnSi);
			this.grpConferma.Enabled = false;
			this.grpConferma.Location = new System.Drawing.Point(585, 3);
			this.grpConferma.Name = "grpConferma";
			this.grpConferma.Size = new System.Drawing.Size(264, 48);
			this.grpConferma.TabIndex = 2;
			this.grpConferma.TabStop = false;
			this.grpConferma.Text = "Genera Mandato";
			// 
			// btnNo
			// 
			this.btnNo.Location = new System.Drawing.Point(96, 16);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(64, 23);
			this.btnNo.TabIndex = 74;
			this.btnNo.TabStop = false;
			this.btnNo.Tag = "unlink";
			this.btnNo.Text = "No";
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnSiTutti
			// 
			this.btnSiTutti.Location = new System.Drawing.Point(184, 16);
			this.btnSiTutti.Name = "btnSiTutti";
			this.btnSiTutti.Size = new System.Drawing.Size(64, 23);
			this.btnSiTutti.TabIndex = 73;
			this.btnSiTutti.TabStop = false;
			this.btnSiTutti.Text = "Sì tutti";
			this.btnSiTutti.Click += new System.EventHandler(this.btnSiTutti_Click);
			// 
			// btnSi
			// 
			this.btnSi.Location = new System.Drawing.Point(24, 16);
			this.btnSi.Name = "btnSi";
			this.btnSi.Size = new System.Drawing.Size(64, 23);
			this.btnSi.TabIndex = 72;
			this.btnSi.TabStop = false;
			this.btnSi.Text = "Sì";
			this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.DetailGrid);
			this.groupBox4.Location = new System.Drawing.Point(8, 138);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(843, 177);
			this.groupBox4.TabIndex = 6;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Elenco dei movimenti di spesa associati al mandato";
			// 
			// DetailGrid
			// 
			this.DetailGrid.AllowNavigation = false;
			this.DetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailGrid.DataMember = "";
			this.DetailGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DetailGrid.Location = new System.Drawing.Point(8, 16);
			this.DetailGrid.Name = "DetailGrid";
			this.DetailGrid.Size = new System.Drawing.Size(829, 153);
			this.DetailGrid.TabIndex = 66;
			this.DetailGrid.Tag = "expenselastview.mandatoautomatico";
			this.DetailGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.DetailGrid_Paint);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 24);
			this.label5.TabIndex = 65;
			this.label5.Text = "Importo totale del mandato:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(112, 8);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.ReadOnly = true;
			this.txtImporto.Size = new System.Drawing.Size(96, 20);
			this.txtImporto.TabIndex = 63;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "";
			this.txtImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.label10);
			this.groupBox6.Controls.Add(this.textBox1);
			this.groupBox6.Controls.Add(this.cmbCodiceIstituto);
			this.groupBox6.Controls.Add(this.btnIstitutoCassiere);
			this.groupBox6.Controls.Add(this.btnBollo);
			this.groupBox6.Controls.Add(this.cmbBollo);
			this.groupBox6.Location = new System.Drawing.Point(8, 123);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(827, 53);
			this.groupBox6.TabIndex = 2;
			this.groupBox6.TabStop = false;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.Location = new System.Drawing.Point(634, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(106, 48);
			this.label10.TabIndex = 56;
			this.label10.Text = "Numero Progr. Cassiere:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.textBox1.Location = new System.Drawing.Point(749, 20);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 55;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "payment.npay_treasurer";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btnInizia);
			this.groupBox3.Controls.Add(this.btnSuccessivo);
			this.groupBox3.Controls.Add(this.btnChiudi);
			this.groupBox3.Location = new System.Drawing.Point(306, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(272, 48);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Operazioni";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.groupBox5);
			this.groupBox7.Controls.Add(this.groupBox6);
			this.groupBox7.Location = new System.Drawing.Point(8, 315);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(843, 184);
			this.groupBox7.TabIndex = 7;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Dati Riepilogativi";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.txtCreditoreDebitore);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.txtResponsabile);
			this.groupBox5.Controls.Add(this.label4);
			this.groupBox5.Controls.Add(this.txtBilancio);
			this.groupBox5.Controls.Add(this.txtDescrBilancio);
			this.groupBox5.Location = new System.Drawing.Point(8, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(827, 106);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label5);
			this.groupBox8.Controls.Add(this.label9);
			this.groupBox8.Controls.Add(this.txtImporto);
			this.groupBox8.Controls.Add(this.txtDataContabile);
			this.groupBox8.Location = new System.Drawing.Point(336, 69);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(216, 64);
			this.groupBox8.TabIndex = 5;
			this.groupBox8.TabStop = false;
			// 
			// chkCSA
			// 
			this.chkCSA.AutoSize = true;
			this.chkCSA.Location = new System.Drawing.Point(16, 5);
			this.chkCSA.Name = "chkCSA";
			this.chkCSA.Size = new System.Drawing.Size(88, 17);
			this.chkCSA.TabIndex = 8;
			this.chkCSA.TabStop = false;
			this.chkCSA.Text = "Mandati CSA";
			this.chkCSA.UseVisualStyleBackColor = true;
			// 
			// chkEscludiZero
			// 
			this.chkEscludiZero.AutoSize = true;
			this.chkEscludiZero.Location = new System.Drawing.Point(16, 27);
			this.chkEscludiZero.Name = "chkEscludiZero";
			this.chkEscludiZero.Size = new System.Drawing.Size(188, 17);
			this.chkEscludiZero.TabIndex = 9;
			this.chkEscludiZero.TabStop = false;
			this.chkEscludiZero.Text = "Escludi i pagamenti di importo zero";
			this.chkEscludiZero.UseVisualStyleBackColor = true;
			// 
			// chkPagamentiAzzeramentiFineAnno
			// 
			this.chkPagamentiAzzeramentiFineAnno.AutoSize = true;
			this.chkPagamentiAzzeramentiFineAnno.Location = new System.Drawing.Point(16, 51);
			this.chkPagamentiAzzeramentiFineAnno.Name = "chkPagamentiAzzeramentiFineAnno";
			this.chkPagamentiAzzeramentiFineAnno.Size = new System.Drawing.Size(323, 17);
			this.chkPagamentiAzzeramentiFineAnno.TabIndex = 10;
			this.chkPagamentiAzzeramentiFineAnno.TabStop = false;
			this.chkPagamentiAzzeramentiFineAnno.Text = "Liquidazioni create con la procedura di Azzeramento Fine Anno";
			this.chkPagamentiAzzeramentiFineAnno.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(556, 113);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(193, 19);
			this.label6.TabIndex = 65;
			this.label6.Text = "Data scadenza (Data esecuzione OPI)";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtdataScadenza
			// 
			this.txtdataScadenza.Location = new System.Drawing.Point(755, 112);
			this.txtdataScadenza.Name = "txtdataScadenza";
			this.txtdataScadenza.Size = new System.Drawing.Size(96, 20);
			this.txtdataScadenza.TabIndex = 64;
			this.txtdataScadenza.Tag = "";
			this.txtdataScadenza.Leave += new System.EventHandler(this.txtdataScadenza_Leave);
			// 
			// Frm_payment_generazioneautomatica
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(859, 505);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtdataScadenza);
			this.Controls.Add(this.chkPagamentiAzzeramentiFineAnno);
			this.Controls.Add(this.chkEscludiZero);
			this.Controls.Add(this.chkCSA);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.grpConferma);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "Frm_payment_generazioneautomatica";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpConferma.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public void MetaData_AfterClear() {
//			if (Convert.ToInt16(Meta.GetSys("esercizio")) > 2001)
//				chbEuro.Visible=false;
            if (Meta.GointToInsertMode) return;
//			Text="Generazione automatica documenti di pagamento";
            try {
                if (cmbCodiceIstituto.Items.Count > 1) cmbCodiceIstituto.SelectedIndex = 1;
            }
            catch {
            }
        }

        private void CalcolaImporto() {
            DataRow[] selectedrows = GetGridSelectedRows();
            decimal somma = 0;
            for (int i = 0; i < selectedrows.Length; i++) {
                somma += CfgFn.GetNoNullDecimal(selectedrows[i]["curramount"]);
            }

            txtImporto.Text = somma.ToString("c");
        }

        void AfterLinkBody() {
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.expensephase);
            GetData.CacheTable(DS.config, filter, null, false);
            HelpForm.SetAllowMultiSelection(DS.expenselastview, true);
            GetData.SetStaticFilter(DS.expenselastview, QHS.CmpEq("ymov", Meta.GetSys("esercizio")));
        }

        bool UsoSiope = false;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            AfterLinkBody();
            GetData.SetStaticFilter(DS.payment, QHS.CmpEq("ypay", Meta.GetSys("esercizio")));
            //GetData.SetStaticFilter(DS.bilancio, filter);
            UsoSiope = Verifica_Uso_SiopePlus();
            AzzeraDataScadenza();
        }
        public void AzzeraDataScadenza() {
            txtdataScadenza.Text = "";
        }
        public void MetaData_AfterActivation() {
            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = false;
            impostaColoreBottoni();
        }

        private void impostaColoreBottoni() {
            btnInizia.BackColor = formcolors.GridButtonBackColor();
            btnInizia.ForeColor = formcolors.GridButtonForeColor();
            btnSuccessivo.BackColor = formcolors.GridButtonBackColor();
            btnSuccessivo.ForeColor = formcolors.GridButtonForeColor();
            btnChiudi.BackColor = formcolors.GridButtonBackColor();
            btnChiudi.ForeColor = formcolors.GridButtonForeColor();
            btnSi.BackColor = formcolors.GridButtonBackColor();
            btnSi.ForeColor = formcolors.GridButtonForeColor();
            btnSiTutti.BackColor = formcolors.GridButtonBackColor();
            btnSiTutti.ForeColor = formcolors.GridButtonForeColor();
        }

        string MyAppend(string source, string toappend) {
            if (source.Trim() == "") return toappend;
            return source + ", " + toappend + " ";
        }

        private void FillTempTable() {
            string ParteSelect, ParteFrom, ParteWhere, ParteGroupBy, ParteOrderBy, ParteHaving;
            string SelectClause, FromClause, WhereClause, GroupByClause, OrderByClause, HavingClause;

            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            //int giornianticipo = CfgFn.GetNoNullInt32(DS.Tables["config"].Rows[0]["expense_expiringdays"]);
            int eserccorrente = (int) Meta.GetSys("esercizio");

            byte payment_flag = (byte) DS.Tables["config"].Rows[0]["payment_flag"];
            bool flagcreddeb = (payment_flag & 4) == 4;
            bool flagbilancio = (payment_flag & 2) == 2;
            livbilancio = DS.Tables["config"].Rows[0]["payment_finlevel"];
            object maxlivbilancio = Meta.Conn.DO_READ_VALUE("finlevel",
                QHS.CmpEq("ayear", eserccorrente), "max(nlevel)");
            if ((livbilancio.Equals(maxlivbilancio)) || !flagbilancio) {
                livbilancio = DBNull.Value;
            }

            bool flagrespons = (payment_flag & 16) == 16;
            bool flagresidui = (payment_flag & 8) == 8;

            DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
            //scadenza = scadenza.AddDays( giornianticipo);

            ParteWhere = QHS.AppAnd(QHS.IsNull("kpay"),
                QHS.CmpEq("ayear", eserccorrente),
                QHS.CmpEq("nphase", codicefase) //,QHS.NullOrLe("expiration", scadenza)
            );

            if (chkCSA.Checked)
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.FieldInList("autokind", "20,21,30,31"));
            if (chkPagamentiAzzeramentiFineAnno.Checked)
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.CmpEq("autokind", "27"));
            //pagamenti creati con la procedura di Azzeramento Fine Anno, personalizzazione per Catania
            if (chkEscludiZero.Checked)
                ParteWhere = QHS.AppAnd(ParteWhere, QHS.CmpNe("curramount", 0));


            if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
                string security = Conn.SelectCondition("expenselastview", true);
                ParteWhere = QHS.AppAnd(ParteWhere, security);
            }

            string MainTable = "expenselastview";

            ParteFrom = "expenselastview";
            SelectClause = "SELECT ";
            FromClause = " FROM ";
            WhereClause = " WHERE ";
            GroupByClause = " GROUP BY ";
            OrderByClause = " ORDER BY ";
            HavingClause = " HAVING ";
            ParteSelect = ""; //"flageuro";
            ParteGroupBy = ""; //"flageuro";
            ParteOrderBy = ""; //"flageuro ASC";
            if (flagcreddeb) {
                ParteSelect = MyAppend(ParteSelect, "idreg,registry");
                ParteGroupBy = MyAppend(ParteGroupBy, "idreg,registry");
                ParteOrderBy = MyAppend(ParteOrderBy, "registry ASC");
            }

            if (flagbilancio) {
                if (livbilancio == DBNull.Value) {
                    ParteSelect = MyAppend(ParteSelect, "idfin,codefin");
                    ParteGroupBy = MyAppend(ParteGroupBy, "idfin,codefin");
                    ParteOrderBy = MyAppend(ParteOrderBy, "codefin ASC");
                }
                else {
                    ParteFrom = ParteFrom + " JOIN finlink ON finlink.idchild = " + MainTable
                                + ".idfin AND finlink.nlevel = " + QHS.quote(livbilancio);
                    //se c'è il rag.per Capitolo: idparente è il capitolo e codefin l'articolo perchè letto da expenselastview
                    // a parte che il campo non viene usato ma poi la sua presenza moltiplica le righe 
                    //ParteSelect = MyAppend(ParteSelect, "idparent,codefin");
                    ParteSelect = MyAppend(ParteSelect, "idparent");
                    //ParteGroupBy = MyAppend(ParteGroupBy, "idparent,codefin");
                    ParteGroupBy = MyAppend(ParteGroupBy, "idparent");
                    //ParteOrderBy = MyAppend(ParteOrderBy, "codefin ASC");
                    ParteOrderBy = MyAppend(ParteOrderBy, "idparent ASC");
                }
            }

            if (flagrespons) {
                ParteSelect = MyAppend(ParteSelect, "idman,manager");
                ParteGroupBy = MyAppend(ParteGroupBy, "idman,manager");
                ParteOrderBy = MyAppend(ParteOrderBy, "manager ASC");
            }

            if (flagresidui) {
                ParteSelect = MyAppend(ParteSelect, "  flagarrear AS kind ");
                ParteGroupBy = MyAppend(ParteGroupBy, "flagarrear");
                ParteOrderBy = MyAppend(ParteOrderBy, "flagarrear ASC");
            }

            ParteHaving = "SUM(curramount) > 0";

            if (ParteGroupBy == "") GroupByClause = "";
            if (ParteOrderBy == "") OrderByClause = "";

            string MyQuery = "";

            if (ParteSelect != "") {
                MyQuery = SelectClause + ParteSelect + FromClause + ParteFrom +
                          WhereClause + ParteWhere + GroupByClause + ParteGroupBy +
                          HavingClause + ParteHaving + OrderByClause + ParteOrderBy;
            }


            if (MyQuery != "") {
                TempTable = Meta.Conn.SQLRunner(MyQuery, false, 300);
                if (TempTable == null) return;
            }
            else {
                TempTable.Columns.Add("UnicoMandato");
                TempTable.Rows.Add(new object[] {""});
            }

            if (TempTable.Columns.Contains("idparent")) {
                TempTable.Columns["idparent"].ColumnName = "idfin";
            }
        }

        private DataRow[] GetGridSelectedRows() {
            string TableName = DetailGrid.DataMember.ToString();
            DataSet MyDS = (DataSet) DetailGrid.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (DetailGrid.IsSelected(i)) {
                    numrighe++;
                }
            }

            Dictionary<int, DataRow> rowsByIdInc = new Dictionary<int, DataRow>();
            foreach (DataRow r in MyTable.Rows) rowsByIdInc[(int) r["idexp"]] = r;
            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (DetailGrid.IsSelected(i)) {
                    Res[count++] = rowsByIdInc[(int) DetailGrid[i, 0]];
                }
            }

            return Res;
        }

        //private DataRow[] GetGridSelectedRows() {
        //    string TableName = DetailGrid.DataMember.ToString();
        //    DataSet MyDS = (DataSet) DetailGrid.DataSource;
        //    DataTable MyTable = MyDS.Tables[TableName];
        //    int numrighetemp = MyTable.Rows.Count;
        //    int numrighe = 0;
        //    int i;
        //    for (i = 0; i < numrighetemp; i++) {
        //        if (DetailGrid.IsSelected(i)) {
        //            numrighe++;
        //        }
        //    }

        //    DataRow[] Res = new DataRow[numrighe];
        //    int count = 0;
        //    for (i = 0; i < numrighetemp; i++) {
        //        if (DetailGrid.IsSelected(i)) {
        //            Res[count++] = GetDetailRow(i);
        //        }
        //    }
        //    return Res;
        //}

        //DataRow GetDetailRow(int index) {
        //    string TableName = DetailGrid.DataMember.ToString();
        //    DataSet MyDS = (DataSet) DetailGrid.DataSource;
        //    DataTable MyTable = MyDS.Tables[TableName];
        //    string filter = QHC.CmpEq("idexp", DetailGrid[index, 0]);
        //    DataRow[] selectresult = MyTable.Select(filter);
        //    return selectresult[0];
        //}

        /// <summary>
        /// Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
        /// </summary>
        private DataRow PredisponiNuovoDocumento( /*bool quiet*/) {
            DataRow rPersSpesa = DS.Tables["config"].Rows[0];
            byte payment_flag = (byte) rPersSpesa["payment_flag"];
            bool flagcreddeb = (payment_flag & 4) == 4;
            bool flagbilancio = (payment_flag & 2) == 2;
            bool flagrespons = (payment_flag & 16) == 16;
            bool flagresidui = (payment_flag & 8) == 8;

            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int eserccorrente = (int) Meta.GetSys("esercizio");
            string condizioniaggiuntive = QHS.CmpEq("ayear", eserccorrente);
            DataRow CurrRow = TempTable.Rows[0];

            if (flagcreddeb) {
                object codicecreddeb = CurrRow["idreg"];
                MetaData.SetDefault(DS.payment, "idreg", codicecreddeb);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idreg", codicecreddeb));
            }

            if (flagbilancio) {
                object idbilancio = CurrRow["idfin"];
                MetaData.SetDefault(DS.payment, "idfin", idbilancio);
                if (idbilancio != DBNull.Value) {
                    if (livbilancio == DBNull.Value)
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idfin", idbilancio));
                    else
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                            QHS.FieldInList("idfin", "select idchild from finlink where "
                                                     + QHS.CmpEq("idparent", idbilancio)));
                    ;
                }
                else {
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.IsNull("idfin"));
                }
            }

            if (flagrespons) {
                object codiceresponsabile = CurrRow["idman"];
                MetaData.SetDefault(DS.payment, "idman", codiceresponsabile);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("idman", codiceresponsabile));
            }

            int flag = 0;
            flag = flag & 0xF8;
            if (flagresidui) {
                object tipopagamento = CurrRow["kind"];
                if (tipopagamento.ToString().ToUpper() == "C") {
                    //def. C/Competenza
                    flag = flag + 1;
                    txtTipoDocumento.Text = "Competenza";
                }

                if (tipopagamento.ToString().ToUpper() == "R") {
                    //def. C/Residui
                    flag = flag + 2;
                    txtTipoDocumento.Text = "Residui";
                }

                MetaData.SetDefault(DS.payment, "flag", flag);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("flagarrear", tipopagamento));
            }
            else {
                //def. Misto
                flag = flag + 4;
                txtTipoDocumento.Text = "Misto";
                MetaData.SetDefault(DS.payment, "flag", flag);
            }

            //Cassiere predefinito
            DataRow[] IstCassierePredef = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (IstCassierePredef.Length == 1) {
                object codiceistituto = IstCassierePredef[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }

            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }

            //Trattamento bollo predefinito
            DataRow[] TrattBolloPredef = DS.stamphandling.Select(QHC.CmpEq("flagdefault", "S"));
            if (TrattBolloPredef.Length == 1) {
                object codicetrattamento = TrattBolloPredef[0]["idstamphandling"];
                MetaData.SetDefault(DS.payment, "idstamphandling", codicetrattamento);
            }

            //DS.expenselastview.Clear();
            //Meta.GetFormData(true);
            //string dataContabile = txtDataContabile.Text;
            //Meta.EditNew();
            DataRow NewPayment = Meta.Get_New_Row(null, DS.payment);
            return NewPayment;
            //if (chkCSA.Checked) condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.FieldInList("autokind", "20,21,30,31"));
            ////pagamenti creati con la procedura di Azzeramento Fine Anno, personalizzazione per Catania
            //if (chkPagamentiAzzeramentiFineAnno.Checked) condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("autokind", "27"));
            //if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
            //    string security = Conn.SelectCondition("expenselastview", true);
            //    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, security);
            //}

            //DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenselastview,
            //    "ymov  ASC, nmov  ASC",
            //    QHS.AppAnd(QHS.IsNull("kpay"),
            //        QHS.CmpEq("nphase", codicefase), 
            //        condizioniaggiuntive),
            //    null, false);

            //MetaData.FreshForm(this, false);
            //if (quiet) {
            //    txtDataContabile.Text = dataContabile;
            //}

        }

        /// <summary>
        /// Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
        /// </summary>
        private void CollegaRigheADocumento(bool quiet) {
            if (TempTable == null || TempTable.Rows.Count == 0) {
                if (!quiet) MetaFactory.factory.getSingleton<IMessageShower>().Show("Non ci sono movimenti di spesa da elaborare");
                btnSuccessivo.Enabled = false;
                grpConferma.Enabled = false;
                return;
            }

            //MetaData.GetFormData(this,true);
            DataRow rPersSpesa = DS.Tables["config"].Rows[0];
            byte payment_flag = (byte) rPersSpesa["payment_flag"];
            bool flagcreddeb = (payment_flag & 4) == 4;
            bool flagbilancio = (payment_flag & 2) == 2;
            bool flagrespons = (payment_flag & 16) == 16;
            bool flagresidui = (payment_flag & 8) == 8;
            //int giornianticipo = CfgFn.GetNoNullInt32(rPersSpesa["expense_expiringdays"]);
            int codicefase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            int eserccorrente = (int) Meta.GetSys("esercizio");
//			string esercsuffix=eserccorrente.Substring(2,2);
            string condizioniaggiuntive = QHS.CmpEq("ayear", eserccorrente);
            DataRow CurrRow = TempTable.Rows[0];
//			object flageuro="N";//CurrRow["flageuro"];
//			MetaData.SetDefault(DS.payment, "flageuro", flageuro);
//			if (flageuro==DBNull.Value){
//				condizioniaggiuntive+= "AND(flageuro IS null)";
//			}
//			else {
//				condizioniaggiuntive+= "AND(flageuro = '"+flageuro.ToString().ToUpper()+"')";
//			}

            if (flagcreddeb) {
                object codicecreddeb = CurrRow["idreg"];
                MetaData.SetDefault(DS.payment, "idreg", codicecreddeb);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idreg", codicecreddeb));
            }

            if (flagbilancio) {
                object idbilancio = CurrRow["idfin"];
                MetaData.SetDefault(DS.payment, "idfin", idbilancio);
                if (idbilancio != DBNull.Value) {
                    if (livbilancio == DBNull.Value)
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("idfin", idbilancio));
                    else
                        //condizioniaggiuntive+=" AND (idfin LIKE "+
                        //    QueryCreator.quotedstrvalue(idbilancio+"%",true)+")";
                        condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                            QHS.FieldInList("idfin", "select idchild from finlink where "
                                                     + QHS.CmpEq("idparent", idbilancio)));
                    ;
                }
                else {
                    condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.IsNull("idfin"));
                }
            }

            if (flagrespons) {
                object codiceresponsabile = CurrRow["idman"];
                MetaData.SetDefault(DS.payment, "idman", codiceresponsabile);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("idman", codiceresponsabile));
            }

            int flag = 0;
            flag = flag & 0xF8;
            if (flagresidui) {
                object tipopagamento = CurrRow["kind"];
                if (tipopagamento.ToString().ToUpper() == "C") {
                    //def. C/Competenza
                    flag = flag + 1;
                    txtTipoDocumento.Text = "Competenza";
                }

                if (tipopagamento.ToString().ToUpper() == "R") {
                    //def. C/Residui
                    flag = flag + 2;
                    txtTipoDocumento.Text = "Residui";
                }

                MetaData.SetDefault(DS.payment, "flag", flag);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive,
                    QHS.CmpEq("flagarrear", tipopagamento));
            }
            else {
                //def. Misto
                flag = flag + 4;
                txtTipoDocumento.Text = "Misto";
                MetaData.SetDefault(DS.payment, "flag", flag);
            }

            //Cassiere predefinito
            DataRow[] IstCassierePredef = DS.treasurer.Select(QHC.CmpEq("flagdefault", "S"));
            if (IstCassierePredef.Length == 1) {
                object codiceistituto = IstCassierePredef[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }

            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.payment, "idtreasurer", codiceistituto);
            }

            //Trattamento bollo predefinito
            DataRow[] TrattBolloPredef = DS.stamphandling.Select(QHC.CmpEq("flagdefault", "S"));
            if (TrattBolloPredef.Length == 1) {
                object codicetrattamento = TrattBolloPredef[0]["idstamphandling"];
                MetaData.SetDefault(DS.payment, "idstamphandling", codicetrattamento);
            }

            DS.expenselastview.Clear();
            DS.expense.Clear();
            AzzeraDataScadenza();
            Meta.GetFormData(true);
            string dataContabile = txtDataContabile.Text;
            Meta.EditNew();

            //DateTime scadenza = (DateTime) Meta.GetSys("datacontabile");
            //scadenza = scadenza.AddDays( giornianticipo);

            if (chkCSA.Checked)
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.FieldInList("autokind", "20,21,30,31"));
            //pagamenti creati con la procedura di Azzeramento Fine Anno, personalizzazione per Catania
            if (chkPagamentiAzzeramentiFineAnno.Checked)
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, QHS.CmpEq("autokind", "27"));
            if (Conn.GetSys("idflowchart") != null && Conn.GetSys("idflowchart").ToString() != "") {
                string security = Conn.SelectCondition("expenselastview", true);
                condizioniaggiuntive = QHS.AppAnd(condizioniaggiuntive, security);
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenselastview,
                "ymov  ASC, nmov  ASC",
                QHS.AppAnd(QHS.IsNull("kpay"),
                    QHS.CmpEq("nphase", codicefase), //QHS.NullOrLe("expiration",scadenza),				 
                    condizioniaggiuntive),
                null, false);

            MetaData.FreshForm(this, false);
            if (quiet) {
                txtDataContabile.Text = dataContabile;
            }

            int max = DS.expenselastview.Rows.Count;
            for (int i = 0; i < max; i++) {
                DetailGrid.Select(i);
            }

            CalcolaImporto();
        }


        private void btnSi_Click(object sender, System.EventArgs e) {
            bool res = AccettaDocumentoConDimensione(false);
            if (res) {
                //selezionaRighe();
                DS.expenselastview.Clear();
                DS.expense.Clear();
                AzzeraDataScadenza();
                Meta.GetFormData(true);
            }
        }

        private void selezionaRighe() {
            string dataMember = DetailGrid.DataMember;
            CurrencyManager cm = DetailGrid.BindingContext[DS, dataMember] as CurrencyManager;
            if (cm == null) return;
            DataView view = cm.List as DataView;
            if (view == null) return;

            for (int i = 0; i < view.Count; i++) {
                if (!DetailGrid.IsSelected(i)) {
                    DetailGrid.Select(i);
                }
            }
        }

        private void btnSuccessivo_Click(object sender, System.EventArgs e) {
            CollegaRigheADocumento(false);
            btnSuccessivo.Enabled = false;
            grpConferma.Enabled = TempTable.Rows.Count > 0;
            if (TempTable.Rows.Count == 0) Meta.DontWarnOnInsertCancel = true;
        }

        private void btnNo_Click(object sender, System.EventArgs e) {
            if (TempTable.Rows.Count > 0) {
                //DS.spesaview.Clear();
                //MetaData.FreshForm(this, true);
                //CalcolaImporto();
                DS.expenselastview.AcceptChanges();
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
            }

            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = true;
        }

        private void btnInizia_Click(object sender, System.EventArgs e) {
            Cursor = Cursors.WaitCursor;
            FillTempTable();
            CollegaRigheADocumento(false);
            btnInizia.Enabled = false;
            chkCSA.Enabled = false;
            chkPagamentiAzzeramentiFineAnno.Enabled = false;
            grpConferma.Enabled = TempTable.Rows.Count > 0;
            Cursor = null;
        }

       //controlla che si debba usare la trasmissione Siope+ 
        public bool Verifica_Uso_SiopePlus() {
            object usesiopeplus = Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "usesiopeplus", null);
            if (usesiopeplus == null || usesiopeplus == DBNull.Value) return false;
            if (usesiopeplus.ToString() == "S") return true;
            return false;
        }


        DataTable callSp(List<int> idincList) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @lista AS int_list;");
            int currblockLen = 0;
            foreach (int id in idincList) {
                if (currblockLen == 0) {
                    sb.Append($"insert into @lista values ({id})");
                }
                else {
                    sb.Append($",({id})");
                }

                currblockLen++;
                if (currblockLen == 20) {
                    sb.AppendLine(";");
                    currblockLen = 0;
                }
            }

            if (currblockLen > 0) sb.AppendLine(";");
            sb.AppendLine($"exec  trasmele_expense_opisiopeplus_ins {Conn.GetEsercizio()},null,'N',@lista");
            return Conn.SQLRunner(sb.ToString(),false,300);
        }

        /// </summary>
        /// <param name="all">Vale TRUE se è stato premuto il bottone "Si Tutti", altrimenti vale FALSE</param>
        private bool AccettaDocumentoConDimensione(bool all) {
            object spexport = "trasmele_expense_opisiopeplus_ins";
            object ypay = Conn.GetSys("esercizio");
            int dimensioneTotale = 0;
            int dimensioneMovCorrente = 0;

            int dimensioneMandatoVuoto = 0;
            string Dsingolo = null;
            string DocMandatoVuoto = null;
            siopeplus_export SS = new siopeplus_export(Conn);
            var infoBeneficiario = new pagamenti.mandatoInformazioni_beneficiario();

            bool success = true;
            int gridrowsnumber = DS.expenselastview.Rows.Count;
            int i;
            DataRow Curr = DS.payment.Rows[0];
            int keydocpagamento = CfgFn.GetNoNullInt32(Curr["kpay"]);
            object flagautostampa = Meta.Conn.DO_READ_VALUE("config",
                "(ayear='" + Meta.GetSys("esercizio").ToString() + "')", "payment_flagautoprintdate");
            List<DataRow> Lpagamenti = new List<DataRow>();

            

            Dictionary<int, DataRow> rowsByIdExp = new Dictionary<int, DataRow>();

            foreach (DataRow r in DS.expenselastview.Rows) { 
	            rowsByIdExp[(int)r["idexp"]] = r;
            }


            var filterExpense = q.fieldIn("idexp", (from DataRow r in DS.expenselastview.Rows select r["idexp"]).ToArray()) ;
            Conn.selectIntoTable(DS.expense,filterExpense);

            for (i = 0; i < gridrowsnumber; i++) {
                if (DetailGrid.IsSelected(i)) {
                    DataRow CurrSpesa = rowsByIdExp[(int) DetailGrid[i, 0]];
                    Lpagamenti.Add(CurrSpesa);
                }
            }

            DataTable T = callSp((from r in Lpagamenti select (int) r["idexp"]).ToList());
            if (T == null || !T.Columns.Contains("kind")) return false;

            DataRow[] MM = T.Select("(kind='MANDATO')");
            if (MM.Length == 0) {
                return false;
            }
            var mandatoVuoto = SS.creaMandato(MM[0]);

            mandatoVuoto.dati_a_disposizione_ente_mandato = new pagamenti.ctDati_a_disposizione_ente_mandato();
            mandatoVuoto.dati_a_disposizione_ente_mandato.struttura = MM[0]["dati_codice_struttura"].ToString();
            mandatoVuoto.dati_a_disposizione_ente_mandato.codice_struttura = MM[0]["dati_codice_struttura"].ToString();
            mandatoVuoto.dati_a_disposizione_ente_mandato.codice_ipa_struttura =MM[0]["dati_codice_ipa_struttura"].ToString();


            DocMandatoVuoto = mandatoVuoto.toXml();
            dimensioneMandatoVuoto = DocMandatoVuoto.Length+50;//include header xml 
            dimensioneTotale = dimensioneMandatoVuoto;

            var infoBeneficiari = SS.get_listaBeneficiari(T);
                        
            foreach (DataRow CurrSpesa in Lpagamenti) {
                object idexp = CurrSpesa["idexp"];
                infoBeneficiario = infoBeneficiari[(int) idexp];

                Dsingolo = infoBeneficiario.toXml();
                dimensioneMovCorrente = Dsingolo.Length;

                if ((dimensioneTotale + dimensioneMovCorrente <= limiteOPIinByte) || (UsoSiope == false)) {
                    dimensioneTotale = dimensioneTotale + dimensioneMovCorrente;
                    CurrSpesa["kpay"] = keydocpagamento;
                }
                else {
                    //Salva l'i-esimo mandato
                    dimensioneTotale = dimensioneMandatoVuoto + dimensioneMovCorrente;
                    if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                        Curr["printdate"] = Curr["adate"];
                    }

                    fillPaymentBank();
                    // Crea una nuova riga e legge le righe del raggruppamento corrente in spesaview
                    Curr = PredisponiNuovoDocumento();
                    keydocpagamento = CfgFn.GetNoNullInt32(Curr["kpay"]);
                    CurrSpesa["kpay"] = keydocpagamento;
                }
            }

            Meta.GetFormData(true);
            // Imposta la data sull'ultimo mandato
            if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                Curr["printdate"] = Curr["adate"];
            }
            if (txtdataScadenza.Text != "") {
                DateTime dataScadenza = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), txtdataScadenza.Text, "d");
                if (dataScadenza != null) {
                    foreach (DataRow R in DS.expense.Select()) {
                        if (R["expiration"] == DBNull.Value) {
                            R["expiration"] = dataScadenza;
                        }
                    }
                }
            }
            MetaData.DoMainCommand(this, "mainsave");
            if (all || !DS.HasChanges()) {
                success = true;
                TempTable.Rows.RemoveAt(0);
                TempTable.AcceptChanges();
                fillPaymentBank();
                ValorizzaScadenzaPagamento();
            }
            else {
                success = false;
                return success;
            }

            grpConferma.Enabled = false;
            btnSuccessivo.Enabled = true;
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="all">Vale TRUE se è stato premuto il bottone "Si Tutti", altrimenti vale FALSE</param>
        //private bool AccettaDocumento(bool all) {
        //    bool success = true; //<-
        //    int gridrowsnumber = DS.expenselastview.Rows.Count;
        //    int i;
        //    DataRow Curr = DS.payment.Rows[0];
        //    int keydocpagamento = CfgFn.GetNoNullInt32(Curr["kpay"]);
        //    for (i = 0; i < gridrowsnumber; i++) {
        //        if (DetailGrid.IsSelected(i)) {
        //            DataRow CurrSpesa = GetDetailRow(i);
        //            CurrSpesa["kpay"] = keydocpagamento;
        //        }
        //    }
        //    Meta.GetFormData(true);
        //    object flagautostampa = Meta.Conn.DO_READ_VALUE("config",
        //        "(ayear='" + Meta.GetSys("esercizio").ToString() + "')", "payment_flagautoprintdate");
        //    if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
        //        Curr["printdate"] = Curr["adate"];
        //    }
        //    MetaData.DoMainCommand(this, "mainsave");
        //    if (all || !DS.HasChanges()) {
        //        success = true;
        //        TempTable.Rows.RemoveAt(0);
        //        TempTable.AcceptChanges();
        //        fillPaymentBank();
        //    }
        //    else {
        //        success = false;
        //        return success;
        //    }

        //    grpConferma.Enabled = false;
        //    btnSuccessivo.Enabled = true;
        //    return success;
        //}

            
        private void ValorizzaScadenzaPagamento() {
        }
        private void fillPaymentBank() {
            if (DS.payment.Rows.Count == 0) return;
            foreach (DataRow Curr in DS.payment.Select()) {
	            if (Curr.RowState == DataRowState.Added) continue;
                DataSet Out = Meta.Conn.CallSP("compute_payment_bank",
                    new object[] {Curr["kpay"]}, false, 0);
            }
        }

        private void btnSiTutti_Click(object sender, System.EventArgs e) {
            while (TempTable.Rows.Count > 0) {
                bool esito = AccettaDocumentoConDimensione(true);
                if (!esito) break;
                CollegaRigheADocumento(true);
//				AccettaDocumento(true);
//				CollegaRigheADocumento(true);

                //MetaData.FreshForm(this, true);
            }

            grpConferma.Enabled = false;
            Meta.DontWarnOnInsertCancel = true;
            selezionaRighe();
        }

        private void DetailGrid_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            if (DetailGrid.DataSource == null) return;
            CalcolaImporto();
        }

        private void txtdataScadenza_Leave(object sender, EventArgs e) {
            if (txtdataScadenza.Text != "") {
                try {
                    DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), txtdataScadenza.Text, "d");
                    txtdataScadenza.Text = HelpForm.StringValue(TT, txtdataScadenza.Tag.ToString());

                }
                catch {
                    txtdataScadenza.Text = "";
                }
            }
        }
    }
}
