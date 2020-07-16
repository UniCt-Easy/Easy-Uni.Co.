/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace sdi_vendita_default {
    partial class Frm_sdi_vendita_default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new sdi_vendita_default.VistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.btnInvioMail = new System.Windows.Forms.Button();
            this.btnVisualizzaSempl = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnScollega = new System.Windows.Forms.Button();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.chkIsSigned = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSignedFileName = new System.Windows.Forms.TextBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.chkExported = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEsercDocumento = new System.Windows.Forms.TextBox();
            this.txtProtocollo = new System.Windows.Forms.TextBox();
            this.btnGeneraFile = new System.Windows.Forms.Button();
            this.btnVisualizza = new System.Windows.Forms.Button();
            this.btnToProtocol = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.grpMittenteVendita = new System.Windows.Forms.GroupBox();
            this.grpRifAmmMittenteVendita = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txtRifamm_ven_emittente = new System.Windows.Forms.TextBox();
            this.grpIPAMittenteVendita = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtIpa_ven_emittente = new System.Windows.Forms.TextBox();
            this.grpStatoTrasmissione = new System.Windows.Forms.GroupBox();
            this.cmbStatoTrasmissioneSdiVen = new System.Windows.Forms.ComboBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeFile = new System.Windows.Forms.TextBox();
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tabVisualizza = new System.Windows.Forms.TabPage();
            this.btnXMLAT = new System.Windows.Forms.Button();
            this.grpMessaggi = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.chkAT_attestazione = new System.Windows.Forms.CheckBox();
            this.chkRC_ricevutaconsegna = new System.Windows.Forms.CheckBox();
            this.chkNE_esitocedente = new System.Windows.Forms.CheckBox();
            this.chkNS_notificascarto = new System.Windows.Forms.CheckBox();
            this.chkDT_decorrenzatermini = new System.Windows.Forms.CheckBox();
            this.chkMC_mancataconsegna = new System.Windows.Forms.CheckBox();
            this.btnXMLDT = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeFilecompresso = new System.Windows.Forms.TextBox();
            this.btnXMLNE = new System.Windows.Forms.Button();
            this.txtIdentificativoSdI = new System.Windows.Forms.TextBox();
            this.btnXMLRC = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXMLMC = new System.Windows.Forms.Button();
            this.btnXMLNS = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpMittenteVendita.SuspendLayout();
            this.grpRifAmmMittenteVendita.SuspendLayout();
            this.grpIPAMittenteVendita.SuspendLayout();
            this.grpStatoTrasmissione.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxStato.SuspendLayout();
            this.tabVisualizza.SuspendLayout();
            this.grpMessaggi.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "VistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabVisualizza);
            this.tabControl1.Location = new System.Drawing.Point(7, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(921, 421);
            this.tabControl1.TabIndex = 35;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.btnInvioMail);
            this.tabPrincipale.Controls.Add(this.btnVisualizzaSempl);
            this.tabPrincipale.Controls.Add(this.label10);
            this.tabPrincipale.Controls.Add(this.btnScollega);
            this.tabPrincipale.Controls.Add(this.txtNumDocumento);
            this.tabPrincipale.Controls.Add(this.chkIsSigned);
            this.tabPrincipale.Controls.Add(this.label12);
            this.tabPrincipale.Controls.Add(this.txtSignedFileName);
            this.tabPrincipale.Controls.Add(this.cboTipo);
            this.tabPrincipale.Controls.Add(this.btnUpload);
            this.tabPrincipale.Controls.Add(this.chkExported);
            this.tabPrincipale.Controls.Add(this.label9);
            this.tabPrincipale.Controls.Add(this.label14);
            this.tabPrincipale.Controls.Add(this.txtEsercDocumento);
            this.tabPrincipale.Controls.Add(this.txtProtocollo);
            this.tabPrincipale.Controls.Add(this.btnGeneraFile);
            this.tabPrincipale.Controls.Add(this.btnVisualizza);
            this.tabPrincipale.Controls.Add(this.btnToProtocol);
            this.tabPrincipale.Controls.Add(this.label8);
            this.tabPrincipale.Controls.Add(this.grpMittenteVendita);
            this.tabPrincipale.Controls.Add(this.grpStatoTrasmissione);
            this.tabPrincipale.Controls.Add(this.txtDataContabile);
            this.tabPrincipale.Controls.Add(this.label5);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.label2);
            this.tabPrincipale.Controls.Add(this.txtNomeFile);
            this.tabPrincipale.Controls.Add(this.gboxStato);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrincipale.Size = new System.Drawing.Size(913, 395);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // btnInvioMail
            // 
            this.btnInvioMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvioMail.Location = new System.Drawing.Point(685, 313);
            this.btnInvioMail.Name = "btnInvioMail";
            this.btnInvioMail.Size = new System.Drawing.Size(203, 26);
            this.btnInvioMail.TabIndex = 77;
            this.btnInvioMail.Text = "Forza invio mail";
            this.btnInvioMail.UseVisualStyleBackColor = true;
            this.btnInvioMail.Click += new System.EventHandler(this.btnInvioMail_Click);
            // 
            // btnVisualizzaSempl
            // 
            this.btnVisualizzaSempl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizzaSempl.AutoSize = true;
            this.btnVisualizzaSempl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizzaSempl.Location = new System.Drawing.Point(685, 281);
            this.btnVisualizzaSempl.Name = "btnVisualizzaSempl";
            this.btnVisualizzaSempl.Size = new System.Drawing.Size(203, 26);
            this.btnVisualizzaSempl.TabIndex = 76;
            this.btnVisualizzaSempl.Text = "Visualizzazione F.E. Semplificata";
            this.btnVisualizzaSempl.UseVisualStyleBackColor = true;
            this.btnVisualizzaSempl.Click += new System.EventHandler(this.btnVisualizza_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 252);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Tipo documento";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnScollega
            // 
            this.btnScollega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScollega.Location = new System.Drawing.Point(733, 184);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(160, 44);
            this.btnScollega.TabIndex = 75;
            this.btnScollega.TabStop = false;
            this.btnScollega.Text = "Scollega la fattura e consenti una ritrasmissione";
            this.btnScollega.UseVisualStyleBackColor = true;
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDocumento.Location = new System.Drawing.Point(663, 253);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(64, 20);
            this.txtNumDocumento.TabIndex = 33;
            this.txtNumDocumento.Tag = "invoice.ninv?sdi_venditaview.ninv";
            // 
            // chkIsSigned
            // 
            this.chkIsSigned.AutoSize = true;
            this.chkIsSigned.Location = new System.Drawing.Point(664, 16);
            this.chkIsSigned.Name = "chkIsSigned";
            this.chkIsSigned.Size = new System.Drawing.Size(60, 17);
            this.chkIsSigned.TabIndex = 57;
            this.chkIsSigned.Tag = "sdi_vendita.issigned:S:N";
            this.chkIsSigned.Text = "Firmata";
            this.chkIsSigned.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(367, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 17);
            this.label12.TabIndex = 56;
            this.label12.Text = "Nome file firmato:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSignedFileName
            // 
            this.txtSignedFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignedFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSignedFileName.Location = new System.Drawing.Point(370, 208);
            this.txtSignedFileName.Name = "txtSignedFileName";
            this.txtSignedFileName.Size = new System.Drawing.Size(357, 20);
            this.txtSignedFileName.TabIndex = 55;
            this.txtSignedFileName.Tag = "sdi_vendita.signedxmlfilename";
            // 
            // cboTipo
            // 
            this.cboTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTipo.DisplayMember = "description";
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.Location = new System.Drawing.Point(124, 250);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(333, 21);
            this.cboTipo.TabIndex = 31;
            this.cboTipo.Tag = "invoice.idinvkind?sdi_venditaview.idinvkind";
            this.cboTipo.ValueMember = "idinvkind";
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(480, 13);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(160, 26);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.TabStop = false;
            this.btnUpload.Text = "Acquisisci il file firmato";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // chkExported
            // 
            this.chkExported.AutoSize = true;
            this.chkExported.Location = new System.Drawing.Point(808, 16);
            this.chkExported.Name = "chkExported";
            this.chkExported.Size = new System.Drawing.Size(91, 17);
            this.chkExported.TabIndex = 5;
            this.chkExported.Tag = "sdi_vendita.exported:S:N";
            this.chkExported.Text = "Inviata all\'SDI";
            this.chkExported.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(477, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 29;
            this.label9.Text = "Esercizio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(367, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(150, 20);
            this.label14.TabIndex = 54;
            this.label14.Text = "Numero protocollo";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercDocumento
            // 
            this.txtEsercDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercDocumento.Location = new System.Drawing.Point(539, 253);
            this.txtEsercDocumento.Name = "txtEsercDocumento";
            this.txtEsercDocumento.Size = new System.Drawing.Size(64, 20);
            this.txtEsercDocumento.TabIndex = 32;
            this.txtEsercDocumento.Tag = "invoice.yinv.year?sdi_venditaview.yinv";
            // 
            // txtProtocollo
            // 
            this.txtProtocollo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProtocollo.Location = new System.Drawing.Point(370, 157);
            this.txtProtocollo.Name = "txtProtocollo";
            this.txtProtocollo.Size = new System.Drawing.Size(515, 20);
            this.txtProtocollo.TabIndex = 9;
            this.txtProtocollo.Tag = " sdi_vendita.arrivalprotocolnum";
            // 
            // btnGeneraFile
            // 
            this.btnGeneraFile.Location = new System.Drawing.Point(307, 13);
            this.btnGeneraFile.Name = "btnGeneraFile";
            this.btnGeneraFile.Size = new System.Drawing.Size(154, 26);
            this.btnGeneraFile.TabIndex = 3;
            this.btnGeneraFile.TabStop = false;
            this.btnGeneraFile.Text = "Genera file da firmare";
            this.btnGeneraFile.UseVisualStyleBackColor = true;
            this.btnGeneraFile.Click += new System.EventHandler(this.btnGeneraFile_Click);
            // 
            // btnVisualizza
            // 
            this.btnVisualizza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizza.AutoSize = true;
            this.btnVisualizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizza.Location = new System.Drawing.Point(752, 249);
            this.btnVisualizza.Name = "btnVisualizza";
            this.btnVisualizza.Size = new System.Drawing.Size(136, 26);
            this.btnVisualizza.TabIndex = 28;
            this.btnVisualizza.Text = "Visualizza File";
            this.btnVisualizza.UseVisualStyleBackColor = true;
            this.btnVisualizza.Click += new System.EventHandler(this.btnVisualizza_Click);
            // 
            // btnToProtocol
            // 
            this.btnToProtocol.Location = new System.Drawing.Point(166, 13);
            this.btnToProtocol.Name = "btnToProtocol";
            this.btnToProtocol.Size = new System.Drawing.Size(129, 26);
            this.btnToProtocol.TabIndex = 2;
            this.btnToProtocol.TabStop = false;
            this.btnToProtocol.Text = "Inserisci protocollo";
            this.btnToProtocol.UseVisualStyleBackColor = true;
            this.btnToProtocol.Click += new System.EventHandler(this.btnToProtocol_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(609, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Numero";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpMittenteVendita
            // 
            this.grpMittenteVendita.Controls.Add(this.grpRifAmmMittenteVendita);
            this.grpMittenteVendita.Controls.Add(this.grpIPAMittenteVendita);
            this.grpMittenteVendita.Location = new System.Drawing.Point(12, 48);
            this.grpMittenteVendita.Name = "grpMittenteVendita";
            this.grpMittenteVendita.Size = new System.Drawing.Size(339, 123);
            this.grpMittenteVendita.TabIndex = 6;
            this.grpMittenteVendita.TabStop = false;
            this.grpMittenteVendita.Text = "Mittente della Fattura Vendita";
            // 
            // grpRifAmmMittenteVendita
            // 
            this.grpRifAmmMittenteVendita.Controls.Add(this.button3);
            this.grpRifAmmMittenteVendita.Controls.Add(this.txtRifamm_ven_emittente);
            this.grpRifAmmMittenteVendita.Location = new System.Drawing.Point(4, 73);
            this.grpRifAmmMittenteVendita.Name = "grpRifAmmMittenteVendita";
            this.grpRifAmmMittenteVendita.Size = new System.Drawing.Size(329, 45);
            this.grpRifAmmMittenteVendita.TabIndex = 36;
            this.grpRifAmmMittenteVendita.TabStop = false;
            this.grpRifAmmMittenteVendita.Tag = "AutoChoose.txtRifamm_ven_emittente.default";
            this.grpRifAmmMittenteVendita.Text = "Riferimento Amministrazione";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(29, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 38;
            this.button3.Tag = "choose.sdi_rifamm.default";
            this.button3.Text = "Rif.Amm.";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtRifamm_ven_emittente
            // 
            this.txtRifamm_ven_emittente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRifamm_ven_emittente.Location = new System.Drawing.Point(123, 20);
            this.txtRifamm_ven_emittente.Name = "txtRifamm_ven_emittente";
            this.txtRifamm_ven_emittente.Size = new System.Drawing.Size(143, 20);
            this.txtRifamm_ven_emittente.TabIndex = 34;
            this.txtRifamm_ven_emittente.Tag = "sdi_vendita.idsdi_rifamm";
            // 
            // grpIPAMittenteVendita
            // 
            this.grpIPAMittenteVendita.Controls.Add(this.button5);
            this.grpIPAMittenteVendita.Controls.Add(this.txtIpa_ven_emittente);
            this.grpIPAMittenteVendita.Location = new System.Drawing.Point(4, 19);
            this.grpIPAMittenteVendita.Name = "grpIPAMittenteVendita";
            this.grpIPAMittenteVendita.Size = new System.Drawing.Size(329, 45);
            this.grpIPAMittenteVendita.TabIndex = 35;
            this.grpIPAMittenteVendita.TabStop = false;
            this.grpIPAMittenteVendita.Tag = "AutoChoose.txtIpa_ven_emittente.default";
            this.grpIPAMittenteVendita.Text = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 37;
            this.button5.Tag = "choose.ipa.default";
            this.button5.Text = "IPA";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // txtIpa_ven_emittente
            // 
            this.txtIpa_ven_emittente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpa_ven_emittente.Location = new System.Drawing.Point(146, 20);
            this.txtIpa_ven_emittente.Name = "txtIpa_ven_emittente";
            this.txtIpa_ven_emittente.Size = new System.Drawing.Size(120, 20);
            this.txtIpa_ven_emittente.TabIndex = 32;
            this.txtIpa_ven_emittente.Tag = "sdi_vendita.ipa_fe";
            // 
            // grpStatoTrasmissione
            // 
            this.grpStatoTrasmissione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStatoTrasmissione.Controls.Add(this.cmbStatoTrasmissioneSdiVen);
            this.grpStatoTrasmissione.Location = new System.Drawing.Point(370, 97);
            this.grpStatoTrasmissione.Name = "grpStatoTrasmissione";
            this.grpStatoTrasmissione.Size = new System.Drawing.Size(523, 40);
            this.grpStatoTrasmissione.TabIndex = 8;
            this.grpStatoTrasmissione.TabStop = false;
            this.grpStatoTrasmissione.Text = "Stato trasmissione";
            // 
            // cmbStatoTrasmissioneSdiVen
            // 
            this.cmbStatoTrasmissioneSdiVen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatoTrasmissioneSdiVen.DataSource = this.DS.sdi_deliverystatus;
            this.cmbStatoTrasmissioneSdiVen.DisplayMember = "description";
            this.cmbStatoTrasmissioneSdiVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatoTrasmissioneSdiVen.Location = new System.Drawing.Point(6, 15);
            this.cmbStatoTrasmissioneSdiVen.Name = "cmbStatoTrasmissioneSdiVen";
            this.cmbStatoTrasmissioneSdiVen.Size = new System.Drawing.Size(511, 21);
            this.cmbStatoTrasmissioneSdiVen.TabIndex = 43;
            this.cmbStatoTrasmissioneSdiVen.Tag = "sdi_vendita.idsdi_deliverystatus?invoiceview.idsdi_deliverystatus";
            this.cmbStatoTrasmissioneSdiVen.ValueMember = "idsdi_deliverystatus";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(453, 64);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(101, 20);
            this.txtDataContabile.TabIndex = 7;
            this.txtDataContabile.Tag = "sdi_vendita.adate";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(346, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumFile);
            this.groupBox1.Location = new System.Drawing.Point(13, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Num.File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumFile
            // 
            this.txtNumFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumFile.Location = new System.Drawing.Point(65, 10);
            this.txtNumFile.Name = "txtNumFile";
            this.txtNumFile.Size = new System.Drawing.Size(71, 20);
            this.txtNumFile.TabIndex = 8;
            this.txtNumFile.Tag = "sdi_vendita.idsdi_vendita";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Nome File:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeFile
            // 
            this.txtNomeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFile.Location = new System.Drawing.Point(7, 208);
            this.txtNomeFile.Name = "txtNomeFile";
            this.txtNomeFile.Size = new System.Drawing.Size(340, 20);
            this.txtNomeFile.TabIndex = 10;
            this.txtNomeFile.Tag = "sdi_vendita.filename";
            // 
            // gboxStato
            // 
            this.gboxStato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxStato.Controls.Add(this.cmbStatus);
            this.gboxStato.Location = new System.Drawing.Point(643, 48);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(256, 40);
            this.gboxStato.TabIndex = 8;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DataSource = this.DS.sdi_status;
            this.cmbStatus.DisplayMember = "description";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(6, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(244, 21);
            this.cmbStatus.TabIndex = 43;
            this.cmbStatus.Tag = "sdi_vendita.idsdi_status?sdi_venditaview.idsdi_status";
            this.cmbStatus.ValueMember = "idsdi_status";
            // 
            // tabVisualizza
            // 
            this.tabVisualizza.Controls.Add(this.btnXMLAT);
            this.tabVisualizza.Controls.Add(this.grpMessaggi);
            this.tabVisualizza.Controls.Add(this.btnXMLDT);
            this.tabVisualizza.Controls.Add(this.label3);
            this.tabVisualizza.Controls.Add(this.txtNomeFilecompresso);
            this.tabVisualizza.Controls.Add(this.btnXMLNE);
            this.tabVisualizza.Controls.Add(this.txtIdentificativoSdI);
            this.tabVisualizza.Controls.Add(this.btnXMLRC);
            this.tabVisualizza.Controls.Add(this.label4);
            this.tabVisualizza.Controls.Add(this.btnXMLMC);
            this.tabVisualizza.Controls.Add(this.btnXMLNS);
            this.tabVisualizza.Location = new System.Drawing.Point(4, 22);
            this.tabVisualizza.Name = "tabVisualizza";
            this.tabVisualizza.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisualizza.Size = new System.Drawing.Size(913, 395);
            this.tabVisualizza.TabIndex = 1;
            this.tabVisualizza.Text = "Dati SDI";
            this.tabVisualizza.UseVisualStyleBackColor = true;
            // 
            // btnXMLAT
            // 
            this.btnXMLAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLAT.AutoSize = true;
            this.btnXMLAT.Location = new System.Drawing.Point(789, 297);
            this.btnXMLAT.Name = "btnXMLAT";
            this.btnXMLAT.Size = new System.Drawing.Size(94, 23);
            this.btnXMLAT.TabIndex = 74;
            this.btnXMLAT.Text = "Visualizza File";
            this.btnXMLAT.UseVisualStyleBackColor = true;
            this.btnXMLAT.Click += new System.EventHandler(this.btnXMLIR_Click);
            // 
            // grpMessaggi
            // 
            this.grpMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMessaggi.Controls.Add(this.textBox2);
            this.grpMessaggi.Controls.Add(this.label7);
            this.grpMessaggi.Controls.Add(this.textBox1);
            this.grpMessaggi.Controls.Add(this.label6);
            this.grpMessaggi.Controls.Add(this.textBox11);
            this.grpMessaggi.Controls.Add(this.textBox10);
            this.grpMessaggi.Controls.Add(this.label18);
            this.grpMessaggi.Controls.Add(this.label17);
            this.grpMessaggi.Controls.Add(this.label16);
            this.grpMessaggi.Controls.Add(this.label11);
            this.grpMessaggi.Controls.Add(this.textBox9);
            this.grpMessaggi.Controls.Add(this.textBox3);
            this.grpMessaggi.Controls.Add(this.chkAT_attestazione);
            this.grpMessaggi.Controls.Add(this.chkRC_ricevutaconsegna);
            this.grpMessaggi.Controls.Add(this.chkNE_esitocedente);
            this.grpMessaggi.Controls.Add(this.chkNS_notificascarto);
            this.grpMessaggi.Controls.Add(this.chkDT_decorrenzatermini);
            this.grpMessaggi.Controls.Add(this.chkMC_mancataconsegna);
            this.grpMessaggi.Location = new System.Drawing.Point(3, 152);
            this.grpMessaggi.Name = "grpMessaggi";
            this.grpMessaggi.Size = new System.Drawing.Size(780, 188);
            this.grpMessaggi.TabIndex = 13;
            this.grpMessaggi.TabStop = false;
            this.grpMessaggi.Text = "Messaggi ricevuti";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(315, 149);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(459, 20);
            this.textBox2.TabIndex = 68;
            this.textBox2.Tag = "sdi_vendita.at_prot";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(266, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 67;
            this.label7.Text = "N.Prot. ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(315, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(459, 20);
            this.textBox1.TabIndex = 66;
            this.textBox1.Tag = "sdi_vendita.dt_prot";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(266, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 65;
            this.label6.Text = "N.Prot. ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(315, 92);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(459, 20);
            this.textBox11.TabIndex = 64;
            this.textBox11.Tag = "sdi_vendita.ne_prot";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(315, 66);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(459, 20);
            this.textBox10.TabIndex = 63;
            this.textBox10.Tag = "sdi_vendita.rc_prot";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(266, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 17);
            this.label18.TabIndex = 62;
            this.label18.Text = "N.Prot. ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(266, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 61;
            this.label17.Text = "N.Prot. ";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(266, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 17);
            this.label16.TabIndex = 60;
            this.label16.Text = "N.Prot. ";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(266, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 58;
            this.label11.Text = "N.Prot.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(315, 41);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(459, 20);
            this.textBox9.TabIndex = 59;
            this.textBox9.Tag = "sdi_vendita.mc_prot";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(315, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(459, 20);
            this.textBox3.TabIndex = 57;
            this.textBox3.Tag = "sdi_vendita.ns_prot";
            // 
            // chkAT_attestazione
            // 
            this.chkAT_attestazione.AutoSize = true;
            this.chkAT_attestazione.Location = new System.Drawing.Point(6, 144);
            this.chkAT_attestazione.Name = "chkAT_attestazione";
            this.chkAT_attestazione.Size = new System.Drawing.Size(228, 30);
            this.chkAT_attestazione.TabIndex = 28;
            this.chkAT_attestazione.Tag = "sdi_vendita.flag_unseen:5";
            this.chkAT_attestazione.Text = "Attestazione di avvenuta trasmissione della\r\nfattura al SdI con impossibilità di " +
    "recapito";
            this.chkAT_attestazione.UseVisualStyleBackColor = true;
            // 
            // chkRC_ricevutaconsegna
            // 
            this.chkRC_ricevutaconsegna.AutoSize = true;
            this.chkRC_ricevutaconsegna.Location = new System.Drawing.Point(6, 69);
            this.chkRC_ricevutaconsegna.Name = "chkRC_ricevutaconsegna";
            this.chkRC_ricevutaconsegna.Size = new System.Drawing.Size(119, 17);
            this.chkRC_ricevutaconsegna.TabIndex = 27;
            this.chkRC_ricevutaconsegna.Tag = "sdi_vendita.flag_unseen:2";
            this.chkRC_ricevutaconsegna.Text = "Ricevuta consegna";
            this.chkRC_ricevutaconsegna.UseVisualStyleBackColor = true;
            // 
            // chkNE_esitocedente
            // 
            this.chkNE_esitocedente.AutoSize = true;
            this.chkNE_esitocedente.Location = new System.Drawing.Point(6, 95);
            this.chkNE_esitocedente.Name = "chkNE_esitocedente";
            this.chkNE_esitocedente.Size = new System.Drawing.Size(129, 17);
            this.chkNE_esitocedente.TabIndex = 26;
            this.chkNE_esitocedente.Tag = "sdi_vendita.flag_unseen:3";
            this.chkNE_esitocedente.Text = "Notifica esito cedente";
            this.chkNE_esitocedente.UseVisualStyleBackColor = true;
            // 
            // chkNS_notificascarto
            // 
            this.chkNS_notificascarto.AutoSize = true;
            this.chkNS_notificascarto.Location = new System.Drawing.Point(6, 20);
            this.chkNS_notificascarto.Name = "chkNS_notificascarto";
            this.chkNS_notificascarto.Size = new System.Drawing.Size(105, 17);
            this.chkNS_notificascarto.TabIndex = 22;
            this.chkNS_notificascarto.Tag = "sdi_vendita.flag_unseen:0";
            this.chkNS_notificascarto.Text = "Notifica di scarto";
            this.chkNS_notificascarto.UseVisualStyleBackColor = true;
            // 
            // chkDT_decorrenzatermini
            // 
            this.chkDT_decorrenzatermini.AutoSize = true;
            this.chkDT_decorrenzatermini.Location = new System.Drawing.Point(6, 120);
            this.chkDT_decorrenzatermini.Name = "chkDT_decorrenzatermini";
            this.chkDT_decorrenzatermini.Size = new System.Drawing.Size(151, 17);
            this.chkDT_decorrenzatermini.TabIndex = 25;
            this.chkDT_decorrenzatermini.Tag = "sdi_vendita.flag_unseen:4";
            this.chkDT_decorrenzatermini.Text = "Notifica decorrenza termini";
            this.chkDT_decorrenzatermini.UseVisualStyleBackColor = true;
            // 
            // chkMC_mancataconsegna
            // 
            this.chkMC_mancataconsegna.AutoSize = true;
            this.chkMC_mancataconsegna.Location = new System.Drawing.Point(6, 46);
            this.chkMC_mancataconsegna.Name = "chkMC_mancataconsegna";
            this.chkMC_mancataconsegna.Size = new System.Drawing.Size(167, 17);
            this.chkMC_mancataconsegna.TabIndex = 24;
            this.chkMC_mancataconsegna.Tag = "sdi_vendita.flag_unseen:1";
            this.chkMC_mancataconsegna.Text = "Notifica di mancata consegna";
            this.chkMC_mancataconsegna.UseVisualStyleBackColor = true;
            // 
            // btnXMLDT
            // 
            this.btnXMLDT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLDT.AutoSize = true;
            this.btnXMLDT.Location = new System.Drawing.Point(789, 269);
            this.btnXMLDT.Name = "btnXMLDT";
            this.btnXMLDT.Size = new System.Drawing.Size(94, 23);
            this.btnXMLDT.TabIndex = 73;
            this.btnXMLDT.Text = "Visualizza File";
            this.btnXMLDT.UseVisualStyleBackColor = true;
            this.btnXMLDT.Click += new System.EventHandler(this.btnXMLNDC_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "Nome File Compresso:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNomeFilecompresso
            // 
            this.txtNomeFilecompresso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFilecompresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFilecompresso.Location = new System.Drawing.Point(6, 53);
            this.txtNomeFilecompresso.Name = "txtNomeFilecompresso";
            this.txtNomeFilecompresso.Size = new System.Drawing.Size(890, 20);
            this.txtNomeFilecompresso.TabIndex = 11;
            this.txtNomeFilecompresso.Tag = "sdi_vendita.zipfilename";
            // 
            // btnXMLNE
            // 
            this.btnXMLNE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLNE.AutoSize = true;
            this.btnXMLNE.Location = new System.Drawing.Point(789, 240);
            this.btnXMLNE.Name = "btnXMLNE";
            this.btnXMLNE.Size = new System.Drawing.Size(94, 23);
            this.btnXMLNE.TabIndex = 72;
            this.btnXMLNE.Text = "Visualizza File";
            this.btnXMLNE.UseVisualStyleBackColor = true;
            this.btnXMLNE.Click += new System.EventHandler(this.btnXMLNEC_Click);
            // 
            // txtIdentificativoSdI
            // 
            this.txtIdentificativoSdI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentificativoSdI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificativoSdI.Location = new System.Drawing.Point(6, 99);
            this.txtIdentificativoSdI.Name = "txtIdentificativoSdI";
            this.txtIdentificativoSdI.Size = new System.Drawing.Size(890, 20);
            this.txtIdentificativoSdI.TabIndex = 12;
            this.txtIdentificativoSdI.Tag = "sdi_vendita.identificativo_sdi";
            // 
            // btnXMLRC
            // 
            this.btnXMLRC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLRC.AutoSize = true;
            this.btnXMLRC.Location = new System.Drawing.Point(789, 215);
            this.btnXMLRC.Name = "btnXMLRC";
            this.btnXMLRC.Size = new System.Drawing.Size(94, 23);
            this.btnXMLRC.TabIndex = 71;
            this.btnXMLRC.Text = "Visualizza File";
            this.btnXMLRC.UseVisualStyleBackColor = true;
            this.btnXMLRC.Click += new System.EventHandler(this.btnXMLRC_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "Identificativo SdI:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnXMLMC
            // 
            this.btnXMLMC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLMC.AutoSize = true;
            this.btnXMLMC.Location = new System.Drawing.Point(789, 190);
            this.btnXMLMC.Name = "btnXMLMC";
            this.btnXMLMC.Size = new System.Drawing.Size(94, 23);
            this.btnXMLMC.TabIndex = 70;
            this.btnXMLMC.Text = "Visualizza File";
            this.btnXMLMC.UseVisualStyleBackColor = true;
            this.btnXMLMC.Click += new System.EventHandler(this.btnXMLNMC_Click);
            // 
            // btnXMLNS
            // 
            this.btnXMLNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXMLNS.AutoSize = true;
            this.btnXMLNS.Location = new System.Drawing.Point(789, 162);
            this.btnXMLNS.Name = "btnXMLNS";
            this.btnXMLNS.Size = new System.Drawing.Size(94, 23);
            this.btnXMLNS.TabIndex = 69;
            this.btnXMLNS.Text = "Visualizza File";
            this.btnXMLNS.UseVisualStyleBackColor = true;
            this.btnXMLNS.Click += new System.EventHandler(this.btnXMLNS_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_sdi_vendita_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 437);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_sdi_vendita_default";
            this.Text = "Frm_sdi_vendita_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.grpMittenteVendita.ResumeLayout(false);
            this.grpRifAmmMittenteVendita.ResumeLayout(false);
            this.grpRifAmmMittenteVendita.PerformLayout();
            this.grpIPAMittenteVendita.ResumeLayout(false);
            this.grpIPAMittenteVendita.PerformLayout();
            this.grpStatoTrasmissione.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxStato.ResumeLayout(false);
            this.tabVisualizza.ResumeLayout(false);
            this.tabVisualizza.PerformLayout();
            this.grpMessaggi.ResumeLayout(false);
            this.grpMessaggi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrincipale;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpMessaggi;
        private System.Windows.Forms.CheckBox chkNS_notificascarto;
        private System.Windows.Forms.CheckBox chkDT_decorrenzatermini;
        private System.Windows.Forms.CheckBox chkMC_mancataconsegna;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdentificativoSdI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeFilecompresso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeFile;
        private System.Windows.Forms.GroupBox gboxStato;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TabPage tabVisualizza;
        private System.Windows.Forms.Button btnVisualizza;
        private System.Windows.Forms.CheckBox chkAT_attestazione;
        private System.Windows.Forms.CheckBox chkRC_ricevutaconsegna;
        private System.Windows.Forms.CheckBox chkNE_esitocedente;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox grpStatoTrasmissione;
        private System.Windows.Forms.ComboBox cmbStatoTrasmissioneSdiVen;
        private System.Windows.Forms.GroupBox grpMittenteVendita;
        private System.Windows.Forms.GroupBox grpRifAmmMittenteVendita;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtRifamm_ven_emittente;
        private System.Windows.Forms.GroupBox grpIPAMittenteVendita;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtIpa_ven_emittente;
        private System.Windows.Forms.Button btnToProtocol;
        private System.Windows.Forms.Button btnGeneraFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtProtocollo;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.TextBox txtEsercDocumento;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkExported;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSignedFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkIsSigned;
        private System.Windows.Forms.Button btnXMLAT;
        private System.Windows.Forms.Button btnXMLDT;
        private System.Windows.Forms.Button btnXMLNE;
        private System.Windows.Forms.Button btnXMLRC;
        private System.Windows.Forms.Button btnXMLMC;
        private System.Windows.Forms.Button btnXMLNS;
        private System.Windows.Forms.Button btnScollega;
        public VistaForm DS;
		private System.Windows.Forms.Button btnVisualizzaSempl;
        private System.Windows.Forms.Button btnInvioMail;
    }
}