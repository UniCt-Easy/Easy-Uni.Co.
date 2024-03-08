
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


namespace itinerationrefundweb_default
{
    partial class frm_itinerationrefundweb_default
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label18 = new System.Windows.Forms.Label();
			this.txtComunicazioni = new System.Windows.Forms.TextBox();
			this.grpDocCollegato = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.txtImportoDocEUR = new System.Windows.Forms.TextBox();
			this.txtImportoDocValuta = new System.Windows.Forms.TextBox();
			this.grpApplicabilita = new System.Windows.Forms.GroupBox();
			this.rdbSaldo = new System.Windows.Forms.RadioButton();
			this.rdbAnticipo = new System.Windows.Forms.RadioButton();
			this.grpLimite = new System.Windows.Forms.GroupBox();
			this.txtLimiteMax = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.grpLocalita = new System.Windows.Forms.GroupBox();
			this.rdoExtraUe = new System.Windows.Forms.RadioButton();
			this.rdoUe = new System.Windows.Forms.RadioButton();
			this.rdoItaly = new System.Windows.Forms.RadioButton();
			this.grpAnticipo = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtPercAnticipoItaliaEstero = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtAnticipo = new System.Windows.Forms.TextBox();
			this.grpImporti = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtImportoEffettivoValuta = new System.Windows.Forms.TextBox();
			this.txtImportoRichiestoEUR = new System.Windows.Forms.TextBox();
			this.txtImportoEffettivoEUR = new System.Windows.Forms.TextBox();
			this.txtImportoRichiestoValuta = new System.Windows.Forms.TextBox();
			this.grpDatiGenerali = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbValuta = new System.Windows.Forms.ComboBox();
			this.btnValuta = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCambio = new System.Windows.Forms.TextBox();
			this.cmbClassificazione = new System.Windows.Forms.ComboBox();
			this.btnClassificazione = new System.Windows.Forms.Button();
			this.grpDocCollegato.SuspendLayout();
			this.grpApplicabilita.SuspendLayout();
			this.grpLimite.SuspendLayout();
			this.grpLocalita.SuspendLayout();
			this.grpAnticipo.SuspendLayout();
			this.grpImporti.SuspendLayout();
			this.grpDatiGenerali.SuspendLayout();
			this.SuspendLayout();
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(14, 433);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(262, 19);
			this.label18.TabIndex = 83;
			this.label18.Text = "Comunicazioni per il Responsabile";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtComunicazioni
			// 
			this.txtComunicazioni.Location = new System.Drawing.Point(14, 454);
			this.txtComunicazioni.Multiline = true;
			this.txtComunicazioni.Name = "txtComunicazioni";
			this.txtComunicazioni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtComunicazioni.Size = new System.Drawing.Size(457, 98);
			this.txtComunicazioni.TabIndex = 240;
			this.txtComunicazioni.Tag = "itinerationrefund.webwarn";
			// 
			// grpDocCollegato
			// 
			this.grpDocCollegato.Controls.Add(this.label17);
			this.grpDocCollegato.Controls.Add(this.label8);
			this.grpDocCollegato.Controls.Add(this.label3);
			this.grpDocCollegato.Controls.Add(this.txtDocumento);
			this.grpDocCollegato.Controls.Add(this.label6);
			this.grpDocCollegato.Controls.Add(this.label5);
			this.grpDocCollegato.Controls.Add(this.txtDataDoc);
			this.grpDocCollegato.Controls.Add(this.txtImportoDocEUR);
			this.grpDocCollegato.Controls.Add(this.txtImportoDocValuta);
			this.grpDocCollegato.Location = new System.Drawing.Point(14, 252);
			this.grpDocCollegato.Name = "grpDocCollegato";
			this.grpDocCollegato.Size = new System.Drawing.Size(638, 55);
			this.grpDocCollegato.TabIndex = 150;
			this.grpDocCollegato.TabStop = false;
			this.grpDocCollegato.Text = "Documento collegato";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(348, 25);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(43, 14);
			this.label17.TabIndex = 56;
			this.label17.Text = "Importo";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(516, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(76, 14);
			this.label8.TabIndex = 53;
			this.label8.Text = "in €";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Documento";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(73, 25);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(160, 20);
			this.txtDocumento.TabIndex = 160;
			this.txtDocumento.Tag = "itinerationrefund.doc";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(398, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(76, 14);
			this.label6.TabIndex = 52;
			this.label6.Text = "in valuta";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(237, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Data";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Location = new System.Drawing.Point(273, 25);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(69, 20);
			this.txtDataDoc.TabIndex = 170;
			this.txtDataDoc.Tag = "itinerationrefund.docdate";
			// 
			// txtImportoDocEUR
			// 
			this.txtImportoDocEUR.Location = new System.Drawing.Point(516, 25);
			this.txtImportoDocEUR.Name = "txtImportoDocEUR";
			this.txtImportoDocEUR.ReadOnly = true;
			this.txtImportoDocEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoDocEUR.TabIndex = 9000;
			this.txtImportoDocEUR.TabStop = false;
			this.txtImportoDocEUR.Tag = "itinerationrefund.docamount.c";
			this.txtImportoDocEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoDocValuta
			// 
			this.txtImportoDocValuta.Location = new System.Drawing.Point(397, 24);
			this.txtImportoDocValuta.Name = "txtImportoDocValuta";
			this.txtImportoDocValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoDocValuta.TabIndex = 180;
			this.txtImportoDocValuta.Tag = "itinerationrefund.docamount_c";
			this.txtImportoDocValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpApplicabilita
			// 
			this.grpApplicabilita.Controls.Add(this.rdbSaldo);
			this.grpApplicabilita.Controls.Add(this.rdbAnticipo);
			this.grpApplicabilita.Location = new System.Drawing.Point(514, 44);
			this.grpApplicabilita.Name = "grpApplicabilita";
			this.grpApplicabilita.Size = new System.Drawing.Size(152, 50);
			this.grpApplicabilita.TabIndex = 75;
			this.grpApplicabilita.TabStop = false;
			this.grpApplicabilita.Text = "Applicabilità";
			// 
			// rdbSaldo
			// 
			this.rdbSaldo.AutoSize = true;
			this.rdbSaldo.Location = new System.Drawing.Point(75, 19);
			this.rdbSaldo.Name = "rdbSaldo";
			this.rdbSaldo.Size = new System.Drawing.Size(52, 17);
			this.rdbSaldo.TabIndex = 90;
			this.rdbSaldo.TabStop = true;
			this.rdbSaldo.Tag = "itinerationrefund.flagadvancebalance:S";
			this.rdbSaldo.Text = "Saldo";
			this.rdbSaldo.UseVisualStyleBackColor = true;
			// 
			// rdbAnticipo
			// 
			this.rdbAnticipo.AutoSize = true;
			this.rdbAnticipo.Location = new System.Drawing.Point(6, 19);
			this.rdbAnticipo.Name = "rdbAnticipo";
			this.rdbAnticipo.Size = new System.Drawing.Size(63, 17);
			this.rdbAnticipo.TabIndex = 80;
			this.rdbAnticipo.TabStop = true;
			this.rdbAnticipo.Tag = "itinerationrefund.flagadvancebalance:A";
			this.rdbAnticipo.Text = "Anticipo";
			this.rdbAnticipo.UseVisualStyleBackColor = true;
			// 
			// grpLimite
			// 
			this.grpLimite.Controls.Add(this.txtLimiteMax);
			this.grpLimite.Controls.Add(this.label2);
			this.grpLimite.Location = new System.Drawing.Point(12, 203);
			this.grpLimite.Name = "grpLimite";
			this.grpLimite.Size = new System.Drawing.Size(264, 43);
			this.grpLimite.TabIndex = 140;
			this.grpLimite.TabStop = false;
			this.grpLimite.Text = "Limite Massimo per Classe di Spesa";
			// 
			// txtLimiteMax
			// 
			this.txtLimiteMax.Location = new System.Drawing.Point(141, 18);
			this.txtLimiteMax.Name = "txtLimiteMax";
			this.txtLimiteMax.ReadOnly = true;
			this.txtLimiteMax.Size = new System.Drawing.Size(112, 20);
			this.txtLimiteMax.TabIndex = 9000;
			this.txtLimiteMax.TabStop = false;
			this.txtLimiteMax.Tag = "";
			this.txtLimiteMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(68, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 60;
			this.label2.Text = "Importo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpLocalita
			// 
			this.grpLocalita.Controls.Add(this.rdoExtraUe);
			this.grpLocalita.Controls.Add(this.rdoUe);
			this.grpLocalita.Controls.Add(this.rdoItaly);
			this.grpLocalita.Location = new System.Drawing.Point(514, 100);
			this.grpLocalita.Name = "grpLocalita";
			this.grpLocalita.Size = new System.Drawing.Size(153, 87);
			this.grpLocalita.TabIndex = 95;
			this.grpLocalita.TabStop = false;
			this.grpLocalita.Text = "Località";
			// 
			// rdoExtraUe
			// 
			this.rdoExtraUe.AutoSize = true;
			this.rdoExtraUe.Location = new System.Drawing.Point(6, 62);
			this.rdoExtraUe.Name = "rdoExtraUe";
			this.rdoExtraUe.Size = new System.Drawing.Size(146, 17);
			this.rdoExtraUe.TabIndex = 120;
			this.rdoExtraUe.TabStop = true;
			this.rdoExtraUe.Tag = "itinerationrefund.flag_geo:E";
			this.rdoExtraUe.Text = "Fuori dall\'Unione Europea";
			this.rdoExtraUe.UseVisualStyleBackColor = true;
			// 
			// rdoUe
			// 
			this.rdoUe.AutoSize = true;
			this.rdoUe.Location = new System.Drawing.Point(6, 39);
			this.rdoUe.Name = "rdoUe";
			this.rdoUe.Size = new System.Drawing.Size(102, 17);
			this.rdoUe.TabIndex = 110;
			this.rdoUe.TabStop = true;
			this.rdoUe.Tag = "itinerationrefund.flag_geo:U";
			this.rdoUe.Text = "Unione Europea";
			this.rdoUe.UseVisualStyleBackColor = true;
			// 
			// rdoItaly
			// 
			this.rdoItaly.AutoSize = true;
			this.rdoItaly.Location = new System.Drawing.Point(6, 19);
			this.rdoItaly.Name = "rdoItaly";
			this.rdoItaly.Size = new System.Drawing.Size(47, 17);
			this.rdoItaly.TabIndex = 100;
			this.rdoItaly.TabStop = true;
			this.rdoItaly.Tag = "itinerationrefund.flag_geo:I";
			this.rdoItaly.Text = "Italia";
			this.rdoItaly.UseVisualStyleBackColor = true;
			// 
			// grpAnticipo
			// 
			this.grpAnticipo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.grpAnticipo.Controls.Add(this.label9);
			this.grpAnticipo.Controls.Add(this.txtPercAnticipoItaliaEstero);
			this.grpAnticipo.Controls.Add(this.label10);
			this.grpAnticipo.Controls.Add(this.txtAnticipo);
			this.grpAnticipo.Location = new System.Drawing.Point(356, 323);
			this.grpAnticipo.Name = "grpAnticipo";
			this.grpAnticipo.Size = new System.Drawing.Size(131, 98);
			this.grpAnticipo.TabIndex = 220;
			this.grpAnticipo.TabStop = false;
			this.grpAnticipo.Text = "Anticipo";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(9, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 16);
			this.label9.TabIndex = 64;
			this.label9.Text = "Importo";
			this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtPercAnticipoItaliaEstero
			// 
			this.txtPercAnticipoItaliaEstero.Location = new System.Drawing.Point(12, 31);
			this.txtPercAnticipoItaliaEstero.Name = "txtPercAnticipoItaliaEstero";
			this.txtPercAnticipoItaliaEstero.Size = new System.Drawing.Size(112, 20);
			this.txtPercAnticipoItaliaEstero.TabIndex = 230;
			this.txtPercAnticipoItaliaEstero.Tag = "itinerationrefund.advancepercentage.fixed.4..%.100";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 12);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 16);
			this.label10.TabIndex = 63;
			this.label10.Text = "Percentuale";
			this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtAnticipo
			// 
			this.txtAnticipo.Location = new System.Drawing.Point(13, 71);
			this.txtAnticipo.Name = "txtAnticipo";
			this.txtAnticipo.ReadOnly = true;
			this.txtAnticipo.Size = new System.Drawing.Size(112, 20);
			this.txtAnticipo.TabIndex = 9000;
			this.txtAnticipo.TabStop = false;
			this.txtAnticipo.Tag = "";
			this.txtAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpImporti
			// 
			this.grpImporti.Controls.Add(this.label16);
			this.grpImporti.Controls.Add(this.label15);
			this.grpImporti.Controls.Add(this.label14);
			this.grpImporti.Controls.Add(this.label13);
			this.grpImporti.Controls.Add(this.txtImportoEffettivoValuta);
			this.grpImporti.Controls.Add(this.txtImportoRichiestoEUR);
			this.grpImporti.Controls.Add(this.txtImportoEffettivoEUR);
			this.grpImporti.Controls.Add(this.txtImportoRichiestoValuta);
			this.grpImporti.Location = new System.Drawing.Point(14, 323);
			this.grpImporti.Name = "grpImporti";
			this.grpImporti.Size = new System.Drawing.Size(322, 98);
			this.grpImporti.TabIndex = 190;
			this.grpImporti.TabStop = false;
			this.grpImporti.Text = "Importo";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 62);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(64, 14);
			this.label16.TabIndex = 71;
			this.label16.Text = "Accordato";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(5, 38);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(53, 14);
			this.label15.TabIndex = 55;
			this.label15.Text = "Richiesto";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(196, 19);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(76, 14);
			this.label14.TabIndex = 54;
			this.label14.Text = "in €";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(71, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(104, 14);
			this.label13.TabIndex = 53;
			this.label13.Text = "in valuta";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoEffettivoValuta
			// 
			this.txtImportoEffettivoValuta.Location = new System.Drawing.Point(72, 62);
			this.txtImportoEffettivoValuta.Name = "txtImportoEffettivoValuta";
			this.txtImportoEffettivoValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoEffettivoValuta.TabIndex = 210;
			this.txtImportoEffettivoValuta.Tag = "itinerationrefund.amount_c";
			this.txtImportoEffettivoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoRichiestoEUR
			// 
			this.txtImportoRichiestoEUR.Location = new System.Drawing.Point(195, 36);
			this.txtImportoRichiestoEUR.Name = "txtImportoRichiestoEUR";
			this.txtImportoRichiestoEUR.ReadOnly = true;
			this.txtImportoRichiestoEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoRichiestoEUR.TabIndex = 9000;
			this.txtImportoRichiestoEUR.TabStop = false;
			this.txtImportoRichiestoEUR.Tag = "itinerationrefund.requiredamount.c";
			this.txtImportoRichiestoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoEffettivoEUR
			// 
			this.txtImportoEffettivoEUR.Location = new System.Drawing.Point(196, 63);
			this.txtImportoEffettivoEUR.Name = "txtImportoEffettivoEUR";
			this.txtImportoEffettivoEUR.ReadOnly = true;
			this.txtImportoEffettivoEUR.Size = new System.Drawing.Size(112, 20);
			this.txtImportoEffettivoEUR.TabIndex = 9000;
			this.txtImportoEffettivoEUR.TabStop = false;
			this.txtImportoEffettivoEUR.Tag = "itinerationrefund.amount.c";
			this.txtImportoEffettivoEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoRichiestoValuta
			// 
			this.txtImportoRichiestoValuta.Location = new System.Drawing.Point(72, 36);
			this.txtImportoRichiestoValuta.Name = "txtImportoRichiestoValuta";
			this.txtImportoRichiestoValuta.Size = new System.Drawing.Size(112, 20);
			this.txtImportoRichiestoValuta.TabIndex = 200;
			this.txtImportoRichiestoValuta.Tag = "itinerationrefund.requiredamount_c";
			this.txtImportoRichiestoValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpDatiGenerali
			// 
			this.grpDatiGenerali.Controls.Add(this.label12);
			this.grpDatiGenerali.Controls.Add(this.label11);
			this.grpDatiGenerali.Controls.Add(this.txtDataFine);
			this.grpDatiGenerali.Controls.Add(this.txtDataInizio);
			this.grpDatiGenerali.Controls.Add(this.txtDescrizione);
			this.grpDatiGenerali.Controls.Add(this.label4);
			this.grpDatiGenerali.Controls.Add(this.cmbValuta);
			this.grpDatiGenerali.Controls.Add(this.btnValuta);
			this.grpDatiGenerali.Controls.Add(this.label1);
			this.grpDatiGenerali.Controls.Add(this.txtCambio);
			this.grpDatiGenerali.Location = new System.Drawing.Point(12, 44);
			this.grpDatiGenerali.Name = "grpDatiGenerali";
			this.grpDatiGenerali.Size = new System.Drawing.Size(480, 143);
			this.grpDatiGenerali.TabIndex = 74;
			this.grpDatiGenerali.TabStop = false;
			this.grpDatiGenerali.Text = "Dati generali";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(306, 116);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 13);
			this.label12.TabIndex = 52;
			this.label12.Text = "Data Fine:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 114);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(76, 23);
			this.label11.TabIndex = 51;
			this.label11.Text = "Data Inizio:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(372, 114);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(100, 20);
			this.txtDataFine.TabIndex = 70;
			this.txtDataFine.Tag = "itinerationrefund.stoptime.g";
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(88, 116);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(100, 20);
			this.txtDataInizio.TabIndex = 60;
			this.txtDataInizio.Tag = "itinerationrefund.starttime.g";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(88, 24);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(384, 48);
			this.txtDescrizione.TabIndex = 30;
			this.txtDescrizione.Tag = "itinerationrefund.description";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 24);
			this.label4.TabIndex = 21;
			this.label4.Text = "Descrizione:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbValuta
			// 
			this.cmbValuta.DisplayMember = "description";
			this.cmbValuta.Location = new System.Drawing.Point(88, 82);
			this.cmbValuta.Name = "cmbValuta";
			this.cmbValuta.Size = new System.Drawing.Size(176, 21);
			this.cmbValuta.TabIndex = 40;
			this.cmbValuta.Tag = "itinerationrefund.idcurrency";
			this.cmbValuta.ValueMember = "idcurrency";
			// 
			// btnValuta
			// 
			this.btnValuta.Location = new System.Drawing.Point(8, 82);
			this.btnValuta.Name = "btnValuta";
			this.btnValuta.Size = new System.Drawing.Size(72, 23);
			this.btnValuta.TabIndex = 24;
			this.btnValuta.TabStop = false;
			this.btnValuta.Tag = "manage.currency.lista";
			this.btnValuta.Text = "Valuta:";
			this.btnValuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(272, 82);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 48;
			this.label1.Text = "Tasso di Cambio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCambio
			// 
			this.txtCambio.Location = new System.Drawing.Point(372, 82);
			this.txtCambio.Name = "txtCambio";
			this.txtCambio.Size = new System.Drawing.Size(100, 20);
			this.txtCambio.TabIndex = 50;
			this.txtCambio.Tag = "itinerationrefund.exchangerate.fixed.8...1";
			this.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cmbClassificazione
			// 
			this.cmbClassificazione.DisplayMember = "description";
			this.cmbClassificazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClassificazione.Location = new System.Drawing.Point(178, 12);
			this.cmbClassificazione.Name = "cmbClassificazione";
			this.cmbClassificazione.Size = new System.Drawing.Size(360, 21);
			this.cmbClassificazione.TabIndex = 20;
			this.cmbClassificazione.Tag = "itinerationrefund.iditinerationrefundkind";
			this.cmbClassificazione.ValueMember = "iditinerationrefundkind";
			// 
			// btnClassificazione
			// 
			this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClassificazione.Location = new System.Drawing.Point(12, 12);
			this.btnClassificazione.Name = "btnClassificazione";
			this.btnClassificazione.Size = new System.Drawing.Size(160, 23);
			this.btnClassificazione.TabIndex = 10;
			this.btnClassificazione.TabStop = false;
			this.btnClassificazione.Tag = "manage.itinerationrefundkind.default";
			this.btnClassificazione.Text = "Rimborso Spese";
			// 
			// frm_itinerationrefundweb_default
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(701, 575);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.txtComunicazioni);
			this.Controls.Add(this.grpDocCollegato);
			this.Controls.Add(this.grpApplicabilita);
			this.Controls.Add(this.grpLimite);
			this.Controls.Add(this.grpLocalita);
			this.Controls.Add(this.grpAnticipo);
			this.Controls.Add(this.grpImporti);
			this.Controls.Add(this.grpDatiGenerali);
			this.Controls.Add(this.cmbClassificazione);
			this.Controls.Add(this.btnClassificazione);
			this.Name = "frm_itinerationrefundweb_default";
			this.Text = "frm_itinerationrefundweb_default";
			this.grpDocCollegato.ResumeLayout(false);
			this.grpDocCollegato.PerformLayout();
			this.grpApplicabilita.ResumeLayout(false);
			this.grpApplicabilita.PerformLayout();
			this.grpLimite.ResumeLayout(false);
			this.grpLimite.PerformLayout();
			this.grpLocalita.ResumeLayout(false);
			this.grpLocalita.PerformLayout();
			this.grpAnticipo.ResumeLayout(false);
			this.grpAnticipo.PerformLayout();
			this.grpImporti.ResumeLayout(false);
			this.grpImporti.PerformLayout();
			this.grpDatiGenerali.ResumeLayout(false);
			this.grpDatiGenerali.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtComunicazioni;
        private System.Windows.Forms.GroupBox grpDocCollegato;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataDoc;
        public System.Windows.Forms.TextBox txtImportoDocEUR;
        public System.Windows.Forms.TextBox txtImportoDocValuta;
        private System.Windows.Forms.GroupBox grpApplicabilita;
        private System.Windows.Forms.RadioButton rdbSaldo;
        private System.Windows.Forms.RadioButton rdbAnticipo;
        private System.Windows.Forms.GroupBox grpLimite;
        private System.Windows.Forms.TextBox txtLimiteMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpLocalita;
        private System.Windows.Forms.RadioButton rdoExtraUe;
        private System.Windows.Forms.RadioButton rdoUe;
        private System.Windows.Forms.RadioButton rdoItaly;
        private System.Windows.Forms.GroupBox grpAnticipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPercAnticipoItaliaEstero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAnticipo;
        private System.Windows.Forms.GroupBox grpImporti;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtImportoEffettivoValuta;
        public System.Windows.Forms.TextBox txtImportoRichiestoEUR;
        public System.Windows.Forms.TextBox txtImportoEffettivoEUR;
        public System.Windows.Forms.TextBox txtImportoRichiestoValuta;
        private System.Windows.Forms.GroupBox grpDatiGenerali;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbValuta;
        private System.Windows.Forms.Button btnValuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.ComboBox cmbClassificazione;
        private System.Windows.Forms.Button btnClassificazione;
    }
}
