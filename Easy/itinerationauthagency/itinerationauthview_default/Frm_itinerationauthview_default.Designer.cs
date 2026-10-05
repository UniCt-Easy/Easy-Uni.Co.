/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using System.Windows.Forms;
using metadatalibrary;

namespace itinerationauthview_default
{
    partial class Frm_itinerationauthview_default : MetaDataForm
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
            this.DS = new itinerationauthview_default.dsmeta();
            this.lblauthagency = new System.Windows.Forms.Label();
            this.lbldescrizione = new System.Windows.Forms.Label();
            this.txtdescrizione = new System.Windows.Forms.TextBox();
            this.lbltotalespesepreviste = new System.Windows.Forms.Label();
            this.txtSpesePreviste = new System.Windows.Forms.TextBox();
            this.btnspese = new System.Windows.Forms.Button();
            this.btntappe = new System.Windows.Forms.Button();
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.lblnumero = new System.Windows.Forms.Label();
            this.txtesercizio = new System.Windows.Forms.TextBox();
            this.lblesercizio = new System.Windows.Forms.Label();
            this.txtadate = new System.Windows.Forms.TextBox();
            this.lbladate = new System.Windows.Forms.Label();
            this.txtdtafine = new System.Windows.Forms.TextBox();
            this.lbldtafine = new System.Windows.Forms.Label();
            this.txtdatainizio = new System.Windows.Forms.TextBox();
            this.lbldtainizio = new System.Windows.Forms.Label();
            this.txtntappe = new System.Windows.Forms.TextBox();
            this.lbltappe = new System.Windows.Forms.Label();
            this.txtresponsabile = new System.Windows.Forms.TextBox();
            this.lblresponsabile = new System.Windows.Forms.Label();
            this.txtpercipiente = new System.Windows.Forms.TextBox();
            this.lblPercipiente = new System.Windows.Forms.Label();
            this.btnapprova = new System.Windows.Forms.Button();
            this.btnresp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.grpAllegati = new System.Windows.Forms.GroupBox();
            this.btnInsAtt = new System.Windows.Forms.Button();
            this.btnEditAtt = new System.Windows.Forms.Button();
            this.btnDelAtt = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblAdditional = new System.Windows.Forms.Label();
            this.txtadditionalannotation = new System.Windows.Forms.TextBox();
            this.lblapplierannotation = new System.Windows.Forms.Label();
            this.txtapplierannotation = new System.Windows.Forms.TextBox();
            this.lblMotivazione = new System.Windows.Forms.Label();
            this.txtMotivazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblAnnotazioniRifiutoApprovazione = new System.Windows.Forms.Label();
            this.txtAnnotazioniRifiutoApprovazione = new System.Windows.Forms.TextBox();
            this.lblmessaggioagenteprecedente = new System.Windows.Forms.Label();
            this.txtmessaggioagenteprecedente = new System.Windows.Forms.TextBox();
            this.panelAutorizzazioni = new System.Windows.Forms.GroupBox();
            this.lblrejectreason = new System.Windows.Forms.Label();
            this.txtrejectreason = new System.Windows.Forms.TextBox();
            this.btnproceed = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnApproveAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxUPB.SuspendLayout();
            this.grpAllegati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.panelAutorizzazioni.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // lblauthagency
            // 
            this.lblauthagency.AutoSize = true;
            this.lblauthagency.Location = new System.Drawing.Point(204, 9);
            this.lblauthagency.Name = "lblauthagency";
            this.lblauthagency.Size = new System.Drawing.Size(96, 13);
            this.lblauthagency.TabIndex = 97;
            this.lblauthagency.Tag = "itinerationauthview.yitineration";
            this.lblauthagency.Text = "Ente Autorizzatore:";
            // 
            // lbldescrizione
            // 
            this.lbldescrizione.AutoSize = true;
            this.lbldescrizione.Location = new System.Drawing.Point(108, 165);
            this.lbldescrizione.Name = "lbldescrizione";
            this.lbldescrizione.Size = new System.Drawing.Size(62, 13);
            this.lbldescrizione.TabIndex = 96;
            this.lbldescrizione.Text = "Descrizione";
            // 
            // txtdescrizione
            // 
            this.txtdescrizione.Location = new System.Drawing.Point(111, 181);
            this.txtdescrizione.Multiline = true;
            this.txtdescrizione.Name = "txtdescrizione";
            this.txtdescrizione.Size = new System.Drawing.Size(89, 61);
            this.txtdescrizione.TabIndex = 50;
            this.txtdescrizione.Tag = "itinerationauthview.description";
            // 
            // lbltotalespesepreviste
            // 
            this.lbltotalespesepreviste.AutoSize = true;
            this.lbltotalespesepreviste.Location = new System.Drawing.Point(204, 126);
            this.lbltotalespesepreviste.Name = "lbltotalespesepreviste";
            this.lbltotalespesepreviste.Size = new System.Drawing.Size(111, 13);
            this.lbltotalespesepreviste.TabIndex = 94;
            this.lbltotalespesepreviste.Text = "Totale Spese Previste";
            // 
            // txtSpesePreviste
            // 
            this.txtSpesePreviste.Location = new System.Drawing.Point(207, 142);
            this.txtSpesePreviste.Name = "txtSpesePreviste";
            this.txtSpesePreviste.ReadOnly = true;
            this.txtSpesePreviste.Size = new System.Drawing.Size(140, 20);
            this.txtSpesePreviste.TabIndex = 9000;
            this.txtSpesePreviste.Tag = "itinerationauthview.totadvance.c";
            // 
            // btnspese
            // 
            this.btnspese.Location = new System.Drawing.Point(452, 12);
            this.btnspese.Name = "btnspese";
            this.btnspese.Size = new System.Drawing.Size(142, 23);
            this.btnspese.TabIndex = 92;
            this.btnspese.Tag = "spesepreviste";
            this.btnspese.Text = "Spese Previste";
            this.btnspese.UseVisualStyleBackColor = true;
            // 
            // btntappe
            // 
            this.btntappe.Location = new System.Drawing.Point(452, 41);
            this.btntappe.Name = "btntappe";
            this.btntappe.Size = new System.Drawing.Size(142, 23);
            this.btntappe.TabIndex = 91;
            this.btntappe.Tag = "tappe";
            this.btntappe.Text = "Tappe";
            this.btntappe.UseVisualStyleBackColor = true;
            // 
            // txtnumero
            // 
            this.txtnumero.Location = new System.Drawing.Point(76, 25);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(57, 20);
            this.txtnumero.TabIndex = 20;
            this.txtnumero.Tag = "itinerationauthview.";
            // 
            // lblnumero
            // 
            this.lblnumero.AutoSize = true;
            this.lblnumero.Location = new System.Drawing.Point(73, 9);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(44, 13);
            this.lblnumero.TabIndex = 16;
            this.lblnumero.Text = "Numero";
            // 
            // txtesercizio
            // 
            this.txtesercizio.Location = new System.Drawing.Point(13, 25);
            this.txtesercizio.Name = "txtesercizio";
            this.txtesercizio.Size = new System.Drawing.Size(57, 20);
            this.txtesercizio.TabIndex = 10;
            this.txtesercizio.Tag = "itinerationauthview.registry";
            // 
            // lblesercizio
            // 
            this.lblesercizio.AutoSize = true;
            this.lblesercizio.Location = new System.Drawing.Point(12, 9);
            this.lblesercizio.Name = "lblesercizio";
            this.lblesercizio.Size = new System.Drawing.Size(49, 13);
            this.lblesercizio.TabIndex = 14;
            this.lblesercizio.Tag = "itinerationauthview.yitineration";
            this.lblesercizio.Text = "Esercizio";
            // 
            // txtadate
            // 
            this.txtadate.Location = new System.Drawing.Point(280, 64);
            this.txtadate.Name = "txtadate";
            this.txtadate.Size = new System.Drawing.Size(67, 20);
            this.txtadate.TabIndex = 100;
            this.txtadate.Tag = "itinerationauthview.adate";
            // 
            // lbladate
            // 
            this.lbladate.AutoSize = true;
            this.lbladate.Location = new System.Drawing.Point(277, 48);
            this.lbladate.Name = "lbladate";
            this.lbladate.Size = new System.Drawing.Size(77, 13);
            this.lbladate.TabIndex = 12;
            this.lbladate.Text = "Data Contabile";
            // 
            // txtdtafine
            // 
            this.txtdtafine.Location = new System.Drawing.Point(207, 103);
            this.txtdtafine.Name = "txtdtafine";
            this.txtdtafine.Size = new System.Drawing.Size(67, 20);
            this.txtdtafine.TabIndex = 90;
            this.txtdtafine.Tag = "itinerationauthview.stop";
            // 
            // lbldtafine
            // 
            this.lbldtafine.AutoSize = true;
            this.lbldtafine.Location = new System.Drawing.Point(204, 87);
            this.lbldtafine.Name = "lbldtafine";
            this.lbldtafine.Size = new System.Drawing.Size(53, 13);
            this.lbldtafine.TabIndex = 8;
            this.lbldtafine.Text = "Data Fine";
            // 
            // txtdatainizio
            // 
            this.txtdatainizio.Location = new System.Drawing.Point(207, 64);
            this.txtdatainizio.Name = "txtdatainizio";
            this.txtdatainizio.Size = new System.Drawing.Size(67, 20);
            this.txtdatainizio.TabIndex = 70;
            this.txtdatainizio.Tag = "itinerationauthview.start";
            // 
            // lbldtainizio
            // 
            this.lbldtainizio.AutoSize = true;
            this.lbldtainizio.Location = new System.Drawing.Point(204, 48);
            this.lbldtainizio.Name = "lbldtainizio";
            this.lbldtainizio.Size = new System.Drawing.Size(57, 13);
            this.lbldtainizio.TabIndex = 6;
            this.lbldtainizio.Text = "Data Inizio";
            // 
            // txtntappe
            // 
            this.txtntappe.Location = new System.Drawing.Point(141, 64);
            this.txtntappe.Name = "txtntappe";
            this.txtntappe.Size = new System.Drawing.Size(49, 20);
            this.txtntappe.TabIndex = 40;
            this.txtntappe.Tag = "itinerationauthview.lapcount";
            // 
            // lbltappe
            // 
            this.lbltappe.AutoSize = true;
            this.lbltappe.Location = new System.Drawing.Point(138, 48);
            this.lbltappe.Name = "lbltappe";
            this.lbltappe.Size = new System.Drawing.Size(52, 13);
            this.lbltappe.TabIndex = 4;
            this.lbltappe.Text = "N. Tappe";
            // 
            // txtresponsabile
            // 
            this.txtresponsabile.Location = new System.Drawing.Point(15, 103);
            this.txtresponsabile.Name = "txtresponsabile";
            this.txtresponsabile.Size = new System.Drawing.Size(120, 20);
            this.txtresponsabile.TabIndex = 60;
            this.txtresponsabile.Tag = "itinerationauthview.managertitle";
            // 
            // lblresponsabile
            // 
            this.lblresponsabile.AutoSize = true;
            this.lblresponsabile.Location = new System.Drawing.Point(12, 87);
            this.lblresponsabile.Name = "lblresponsabile";
            this.lblresponsabile.Size = new System.Drawing.Size(71, 13);
            this.lblresponsabile.TabIndex = 2;
            this.lblresponsabile.Text = "Responsabile";
            // 
            // txtpercipiente
            // 
            this.txtpercipiente.Location = new System.Drawing.Point(15, 64);
            this.txtpercipiente.Name = "txtpercipiente";
            this.txtpercipiente.Size = new System.Drawing.Size(120, 20);
            this.txtpercipiente.TabIndex = 30;
            this.txtpercipiente.Tag = "itinerationauthview.registry";
            // 
            // lblPercipiente
            // 
            this.lblPercipiente.AutoSize = true;
            this.lblPercipiente.Location = new System.Drawing.Point(12, 48);
            this.lblPercipiente.Name = "lblPercipiente";
            this.lblPercipiente.Size = new System.Drawing.Size(60, 13);
            this.lblPercipiente.TabIndex = 0;
            this.lblPercipiente.Text = "Percipiente";
            // 
            // btnapprova
            // 
            this.btnapprova.Location = new System.Drawing.Point(452, 70);
            this.btnapprova.Name = "btnapprova";
            this.btnapprova.Size = new System.Drawing.Size(142, 23);
            this.btnapprova.TabIndex = 95;
            this.btnapprova.Tag = "approva";
            this.btnapprova.Text = "Approva";
            this.btnapprova.UseVisualStyleBackColor = true;
            // 
            // btnresp
            // 
            this.btnresp.Location = new System.Drawing.Point(452, 128);
            this.btnresp.Name = "btnresp";
            this.btnresp.Size = new System.Drawing.Size(142, 23);
            this.btnresp.TabIndex = 96;
            this.btnresp.Tag = "respingi";
            this.btnresp.Text = "Nega autorizzazione";
            this.btnresp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 9001;
            this.label1.Text = "Località Principale";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(15, 142);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(120, 20);
            this.txtLocation.TabIndex = 9002;
            this.txtLocation.Tag = "itinerationauthview.registry";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(266, 452);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(249, 104);
            this.gboxUPB.TabIndex = 9003;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(6, 74);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(233, 20);
            this.txtUPB.TabIndex = 38;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(96, 19);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(143, 49);
            this.txtDescrUPB.TabIndex = 36;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(6, 19);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(82, 20);
            this.btnUPBCode.TabIndex = 37;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // grpAllegati
            // 
            this.grpAllegati.Controls.Add(this.btnInsAtt);
            this.grpAllegati.Controls.Add(this.btnEditAtt);
            this.grpAllegati.Controls.Add(this.btnDelAtt);
            this.grpAllegati.Controls.Add(this.dataGrid3);
            this.grpAllegati.Location = new System.Drawing.Point(11, 448);
            this.grpAllegati.Name = "grpAllegati";
            this.grpAllegati.Size = new System.Drawing.Size(249, 160);
            this.grpAllegati.TabIndex = 9004;
            this.grpAllegati.TabStop = false;
            this.grpAllegati.Text = "Allegati";
            // 
            // btnInsAtt
            // 
            this.btnInsAtt.Location = new System.Drawing.Point(16, 19);
            this.btnInsAtt.Name = "btnInsAtt";
            this.btnInsAtt.Size = new System.Drawing.Size(68, 24);
            this.btnInsAtt.TabIndex = 41;
            this.btnInsAtt.Tag = "insert.default";
            this.btnInsAtt.Text = "Inserisci...";
            // 
            // btnEditAtt
            // 
            this.btnEditAtt.Location = new System.Drawing.Point(96, 19);
            this.btnEditAtt.Name = "btnEditAtt";
            this.btnEditAtt.Size = new System.Drawing.Size(69, 24);
            this.btnEditAtt.TabIndex = 42;
            this.btnEditAtt.Tag = "edit.default";
            this.btnEditAtt.Text = "Modifica...";
            // 
            // btnDelAtt
            // 
            this.btnDelAtt.Location = new System.Drawing.Point(176, 19);
            this.btnDelAtt.Name = "btnDelAtt";
            this.btnDelAtt.Size = new System.Drawing.Size(68, 24);
            this.btnDelAtt.TabIndex = 43;
            this.btnDelAtt.Tag = "delete";
            this.btnDelAtt.Text = "Elimina";
            // 
            // dataGrid3
            // 
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(16, 49);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.ReadOnly = true;
            this.dataGrid3.Size = new System.Drawing.Size(227, 105);
            this.dataGrid3.TabIndex = 402;
            this.dataGrid3.Tag = "itinerationattachment.default.default";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(12, 165);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(39, 13);
            this.lblMotivo.TabIndex = 9006;
            this.lblMotivo.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(11, 181);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(94, 61);
            this.txtMotivo.TabIndex = 9005;
            this.txtMotivo.Tag = "itinerationauthview.applierannotations";
            // 
            // lblAdditional
            // 
            this.lblAdditional.AutoSize = true;
            this.lblAdditional.Location = new System.Drawing.Point(204, 165);
            this.lblAdditional.Name = "lblAdditional";
            this.lblAdditional.Size = new System.Drawing.Size(170, 13);
            this.lblAdditional.TabIndex = 9008;
            this.lblAdditional.Text = "Richieste aggiuntive sulla missione";
            // 
            // txtadditionalannotation
            // 
            this.txtadditionalannotation.Location = new System.Drawing.Point(207, 181);
            this.txtadditionalannotation.Multiline = true;
            this.txtadditionalannotation.Name = "txtadditionalannotation";
            this.txtadditionalannotation.Size = new System.Drawing.Size(167, 61);
            this.txtadditionalannotation.TabIndex = 9007;
            this.txtadditionalannotation.Tag = "itinerationauthview.additionalannotations";
            // 
            // lblapplierannotation
            // 
            this.lblapplierannotation.AutoSize = true;
            this.lblapplierannotation.Location = new System.Drawing.Point(377, 165);
            this.lblapplierannotation.Name = "lblapplierannotation";
            this.lblapplierannotation.Size = new System.Drawing.Size(217, 13);
            this.lblapplierannotation.TabIndex = 9010;
            this.lblapplierannotation.Text = "Appunti per il Pagamento/Tipologia di Fondo";
            // 
            // txtapplierannotation
            // 
            this.txtapplierannotation.Location = new System.Drawing.Point(380, 181);
            this.txtapplierannotation.Multiline = true;
            this.txtapplierannotation.Name = "txtapplierannotation";
            this.txtapplierannotation.Size = new System.Drawing.Size(214, 61);
            this.txtapplierannotation.TabIndex = 9009;
            this.txtapplierannotation.Tag = "itinerationauthview.applierannotations";
            // 
            // lblMotivazione
            // 
            this.lblMotivazione.AutoSize = true;
            this.lblMotivazione.Location = new System.Drawing.Point(11, 251);
            this.lblMotivazione.Name = "lblMotivazione";
            this.lblMotivazione.Size = new System.Drawing.Size(241, 13);
            this.lblMotivazione.TabIndex = 9012;
            this.lblMotivazione.Text = "Motivazione per l\'eventuale uso del mezzo proprio";
            // 
            // txtMotivazione
            // 
            this.txtMotivazione.Location = new System.Drawing.Point(13, 267);
            this.txtMotivazione.Multiline = true;
            this.txtMotivazione.Name = "txtMotivazione";
            this.txtMotivazione.Size = new System.Drawing.Size(244, 61);
            this.txtMotivazione.TabIndex = 9011;
            this.txtMotivazione.Tag = "itinerationauthview.vehicle_motive";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 9014;
            this.label2.Text = "Dati identif. veicolo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(263, 267);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(122, 61);
            this.textBox1.TabIndex = 9013;
            this.textBox1.Tag = "itinerationauthview.vehicle_info";
            // 
            // lblAnnotazioniRifiutoApprovazione
            // 
            this.lblAnnotazioniRifiutoApprovazione.AutoSize = true;
            this.lblAnnotazioniRifiutoApprovazione.Location = new System.Drawing.Point(389, 251);
            this.lblAnnotazioniRifiutoApprovazione.Name = "lblAnnotazioniRifiutoApprovazione";
            this.lblAnnotazioniRifiutoApprovazione.Size = new System.Drawing.Size(197, 13);
            this.lblAnnotazioniRifiutoApprovazione.TabIndex = 9016;
            this.lblAnnotazioniRifiutoApprovazione.Text = "Annotazioni per il Rifiuto o Approvazione";
            // 
            // txtAnnotazioniRifiutoApprovazione
            // 
            this.txtAnnotazioniRifiutoApprovazione.Location = new System.Drawing.Point(391, 267);
            this.txtAnnotazioniRifiutoApprovazione.Multiline = true;
            this.txtAnnotazioniRifiutoApprovazione.Name = "txtAnnotazioniRifiutoApprovazione";
            this.txtAnnotazioniRifiutoApprovazione.Size = new System.Drawing.Size(195, 61);
            this.txtAnnotazioniRifiutoApprovazione.TabIndex = 9015;
            this.txtAnnotazioniRifiutoApprovazione.Tag = "itinerationauthview.annotationsrejectapproval";
            // 
            // lblmessaggioagenteprecedente
            // 
            this.lblmessaggioagenteprecedente.AutoSize = true;
            this.lblmessaggioagenteprecedente.Location = new System.Drawing.Point(10, 339);
            this.lblmessaggioagenteprecedente.Name = "lblmessaggioagenteprecedente";
            this.lblmessaggioagenteprecedente.Size = new System.Drawing.Size(153, 13);
            this.lblmessaggioagenteprecedente.TabIndex = 9018;
            this.lblmessaggioagenteprecedente.Text = "Messaggio Agente Precedente";
            // 
            // txtmessaggioagenteprecedente
            // 
            this.txtmessaggioagenteprecedente.Location = new System.Drawing.Point(12, 355);
            this.txtmessaggioagenteprecedente.Multiline = true;
            this.txtmessaggioagenteprecedente.Name = "txtmessaggioagenteprecedente";
            this.txtmessaggioagenteprecedente.Size = new System.Drawing.Size(151, 61);
            this.txtmessaggioagenteprecedente.TabIndex = 9017;
            this.txtmessaggioagenteprecedente.Tag = "itinerationauthview.annotationsrejectapproval_prec";
            // 
            // panelAutorizzazioni
            // 
            this.panelAutorizzazioni.Controls.Add(this.btncancel);
            this.panelAutorizzazioni.Controls.Add(this.btnproceed);
            this.panelAutorizzazioni.Controls.Add(this.txtrejectreason);
            this.panelAutorizzazioni.Controls.Add(this.lblrejectreason);
            this.panelAutorizzazioni.Location = new System.Drawing.Point(187, 339);
            this.panelAutorizzazioni.Name = "panelAutorizzazioni";
            this.panelAutorizzazioni.Size = new System.Drawing.Size(318, 100);
            this.panelAutorizzazioni.TabIndex = 9019;
            this.panelAutorizzazioni.TabStop = false;
            this.panelAutorizzazioni.Text = "Nega autorizzazione";
            // 
            // lblrejectreason
            // 
            this.lblrejectreason.AutoSize = true;
            this.lblrejectreason.Location = new System.Drawing.Point(17, 19);
            this.lblrejectreason.Name = "lblrejectreason";
            this.lblrejectreason.Size = new System.Drawing.Size(116, 13);
            this.lblrejectreason.TabIndex = 9019;
            this.lblrejectreason.Text = "Motivo della negazione";
            // 
            // txtrejectreason
            // 
            this.txtrejectreason.Location = new System.Drawing.Point(20, 35);
            this.txtrejectreason.Name = "txtrejectreason";
            this.txtrejectreason.Size = new System.Drawing.Size(278, 20);
            this.txtrejectreason.TabIndex = 39;
            this.txtrejectreason.Tag = "";
            // 
            // btnproceed
            // 
            this.btnproceed.Location = new System.Drawing.Point(20, 61);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(147, 23);
            this.btnproceed.TabIndex = 9020;
            this.btnproceed.Tag = "negaAutorizzazione";
            this.btnproceed.Text = "Procedi con la negazione";
            this.btnproceed.UseVisualStyleBackColor = true;
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(178, 61);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(120, 23);
            this.btncancel.TabIndex = 9021;
            this.btncancel.Tag = "nonNegare";
            this.btncancel.Text = "Non procedere";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // btnApproveAll
            // 
            this.btnApproveAll.Location = new System.Drawing.Point(452, 99);
            this.btnApproveAll.Name = "btnApproveAll";
            this.btnApproveAll.Size = new System.Drawing.Size(142, 23);
            this.btnApproveAll.TabIndex = 9020;
            this.btnApproveAll.Tag = "approvatutto";
            this.btnApproveAll.Text = "Approva tutte le missioni";
            this.btnApproveAll.UseVisualStyleBackColor = true;
            // 
            // Frm_itinerationauthview_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 612);
            this.Controls.Add(this.btnApproveAll);
            this.Controls.Add(this.panelAutorizzazioni);
            this.Controls.Add(this.lblmessaggioagenteprecedente);
            this.Controls.Add(this.txtmessaggioagenteprecedente);
            this.Controls.Add(this.lblAnnotazioniRifiutoApprovazione);
            this.Controls.Add(this.txtAnnotazioniRifiutoApprovazione);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblMotivazione);
            this.Controls.Add(this.txtMotivazione);
            this.Controls.Add(this.lblapplierannotation);
            this.Controls.Add(this.txtapplierannotation);
            this.Controls.Add(this.lblAdditional);
            this.Controls.Add(this.txtadditionalannotation);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.grpAllegati);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblauthagency);
            this.Controls.Add(this.btnresp);
            this.Controls.Add(this.lbldescrizione);
            this.Controls.Add(this.btnapprova);
            this.Controls.Add(this.txtdescrizione);
            this.Controls.Add(this.lbltotalespesepreviste);
            this.Controls.Add(this.lblesercizio);
            this.Controls.Add(this.txtSpesePreviste);
            this.Controls.Add(this.lblPercipiente);
            this.Controls.Add(this.btnspese);
            this.Controls.Add(this.txtpercipiente);
            this.Controls.Add(this.btntappe);
            this.Controls.Add(this.lblresponsabile);
            this.Controls.Add(this.txtnumero);
            this.Controls.Add(this.txtresponsabile);
            this.Controls.Add(this.lblnumero);
            this.Controls.Add(this.lbltappe);
            this.Controls.Add(this.txtesercizio);
            this.Controls.Add(this.txtntappe);
            this.Controls.Add(this.lbldtainizio);
            this.Controls.Add(this.txtadate);
            this.Controls.Add(this.txtdatainizio);
            this.Controls.Add(this.lbladate);
            this.Controls.Add(this.lbldtafine);
            this.Controls.Add(this.txtdtafine);
            this.Name = "Frm_itinerationauthview_default";
            this.Text = "Frm_itinerationauthview_default";
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpAllegati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.panelAutorizzazioni.ResumeLayout(false);
            this.panelAutorizzazioni.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public dsmeta DS;
        private Label lblPercipiente;
        private TextBox txtpercipiente;
        private TextBox txtresponsabile;
        private Label lblresponsabile;
        private TextBox txtntappe;
        private Label lbltappe;
        private TextBox txtdtafine;
        private Label lbldtafine;
        private Label lbldtainizio;
        private TextBox txtdatainizio;
        private TextBox txtadate;
        private Label lbladate;
        private Label lblnumero;
        private TextBox txtesercizio;
        private Label lblesercizio;
        private TextBox txtnumero;
        private Button btnspese;
        private Button btntappe;
        private Label lbltotalespesepreviste;
        private TextBox txtSpesePreviste;
        private Button btnapprova;
        private Button btnresp;
        private Label lbldescrizione;
        private TextBox txtdescrizione;
        private Label lblauthagency;
        private Label label1;
        private TextBox txtLocation;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox grpAllegati;
        private Button btnInsAtt;
        private Button btnEditAtt;
        private Button btnDelAtt;
        private DataGrid dataGrid3;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblAdditional;
        private TextBox txtadditionalannotation;
        private Label lblapplierannotation;
        private TextBox txtapplierannotation;
        private Label lblMotivazione;
        private TextBox txtMotivazione;
        private Label label2;
        private TextBox textBox1;
        private Label lblAnnotazioniRifiutoApprovazione;
        private TextBox txtAnnotazioniRifiutoApprovazione;
        private Label lblmessaggioagenteprecedente;
        private TextBox txtmessaggioagenteprecedente;
        private GroupBox panelAutorizzazioni;
        private Button btncancel;
        private Button btnproceed;
        public TextBox txtrejectreason;
        private Label lblrejectreason;
        private Button btnApproveAll;
    }
}