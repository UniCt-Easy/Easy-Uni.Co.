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
using funzioni_configurazione;
using itinerationFunctions;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace itinerationauthview_default
{
    public partial class Frm_itinerationauthview_default : MetaDataForm
    {
        #region Variabili
        QueryHelper QHS;
        CQueryHelper QHC;
        int idauthagency;
        IMetaData Meta;
        IDataAccess Conn;
        private IFormController controller;
        private ISecurity security;
        string mainfilter = "";
        #endregion

        #region Dichiarazione controlli
        public dsmeta DS;
        private System.ComponentModel.IContainer components = null;
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
        private TextBox txtInfoVeicolo;
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
        #endregion

        public Frm_itinerationauthview_default()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itinerationauthview_default));
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
            this.txtInfoVeicolo = new System.Windows.Forms.TextBox();
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
            this.btnspese.Text = "Spese Previste";
            this.btnspese.UseVisualStyleBackColor = true;
            this.btnspese.Click += new System.EventHandler(this.btnSpese_Click);
            this.btnspese.Visible = false;
            // 
            // btntappe
            // 
            this.btntappe.Location = new System.Drawing.Point(452, 41);
            this.btntappe.Name = "btntappe";
            this.btntappe.Size = new System.Drawing.Size(142, 23);
            this.btntappe.TabIndex = 91;
            this.btntappe.Text = "Tappe";
            this.btntappe.UseVisualStyleBackColor = true;
            this.btntappe.Click += new System.EventHandler(this.btnTappe_Click);
            this.btntappe.Visible = false;
            // 
            // txtnumero
            // 
            this.txtnumero.Location = new System.Drawing.Point(76, 25);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(57, 20);
            this.txtnumero.TabIndex = 20;
            this.txtnumero.Tag = "itinerationauthview.nitineration";
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
            this.txtesercizio.Tag = "itinerationauthview.yitineration.year";
            // 
            // lblesercizio
            // 
            this.lblesercizio.AutoSize = true;
            this.lblesercizio.Location = new System.Drawing.Point(12, 9);
            this.lblesercizio.Name = "lblesercizio";
            this.lblesercizio.Size = new System.Drawing.Size(49, 13);
            this.lblesercizio.TabIndex = 14;
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
            this.btnapprova.Text = "Approva";
            this.btnapprova.UseVisualStyleBackColor = true;
            this.btnapprova.Click += new System.EventHandler(this.btnApprova_Click);
            // 
            // btnresp
            // 
            this.btnresp.Location = new System.Drawing.Point(452, 128);
            this.btnresp.Name = "btnresp";
            this.btnresp.Size = new System.Drawing.Size(142, 23);
            this.btnresp.TabIndex = 96;
            this.btnresp.Text = "Nega autorizzazione";
            this.btnresp.UseVisualStyleBackColor = true;
            this.btnresp.Click += new System.EventHandler(this.btnRespingi_Click);
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
            this.txtLocation.Tag = "itinerationauthview.location";
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
            this.txtInfoVeicolo.Location = new System.Drawing.Point(263, 267);
            this.txtInfoVeicolo.Multiline = true;
            this.txtInfoVeicolo.Name = "textBox1";
            this.txtInfoVeicolo.Size = new System.Drawing.Size(122, 61);
            this.txtInfoVeicolo.TabIndex = 9013;
            this.txtInfoVeicolo.Tag = "itinerationauthview.vehicle_info";
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
            this.txtrejectreason.Tag = ""; // "itinerationauthview.cancelreason";
            // 
            // btnproceed
            // 
            this.btnproceed.Location = new System.Drawing.Point(20, 61);
            this.btnproceed.Name = "btnproceed";
            this.btnproceed.Size = new System.Drawing.Size(147, 23);
            this.btnproceed.TabIndex = 9020;
            this.btnproceed.Text = "Procedi con la negazione";
            this.btnproceed.UseVisualStyleBackColor = true;
            this.btnproceed.Click += new System.EventHandler(this.btnNega_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(178, 61);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(120, 23);
            this.btncancel.TabIndex = 9021;
            this.btncancel.Text = "Non procedere";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btnNonNegare_Click);
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
            this.btnApproveAll.Click += new System.EventHandler(this.btnApprovaTutti_Click);
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
            this.Controls.Add(this.txtInfoVeicolo);
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

        private void ShowClientMessage(string msg, string title)
        {
            MetaFactory.factory.getSingleton<IMessageShower>().Show(msg, title);
        }

        public void MetaData_AfterLink()
        {
            Meta = this.getInstance<IMetaData>();
            Conn = this.getInstance<IDataAccess>();
            controller = this.getInstance<IFormController>();

            security = this.getInstance<ISecurity>();
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            GetImpersonatedAuthAgency();
            controller.CanInsert = false;
            //Meta.CanSave = false;
            controller.CanCancel = false;

            int codiceResponsabile = 0;

            string filter = QHS.CmpEq("userweb", Conn.GetSys("user"));
            DataTable manager = Conn.RUN_SELECT("manager", "*", null, filter, null, false);
            if (manager != null && manager.Rows.Count != 0)
            {
                //responsabile = manager.Rows[0]["title"].ToString();
                codiceResponsabile = int.Parse(manager.Rows[0]["idman"].ToString());
            }


            bool IsManager = codiceResponsabile != null ? true : false;
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(codiceResponsabile);
            string filteresercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.upbitinerationavailable, QHS.AppAnd(filteresercizio, QHS.CmpEq("active", "S")));
            
            string subfilter = "";
            
            subfilter = "(select count(*) from itinerationauthagency IA join authagency A on (IA.idauthagency=A.idauthagency) ";
            subfilter += " where IA.iditineration=itinerationauthview.iditineration ";
            subfilter += " and IA.idauthagency<> itinerationauthview.idauthagency ";
            subfilter += " and (flagstatus='N' or flagstatus='D') ";
            subfilter += " and A.priority<= itinerationauthview.priority ";
            subfilter += " )=0";
            filter = QHS.AppAnd(subfilter, QHS.CmpEq("idauthagency", idauthagency), QHS.CmpEq("flagstatus", "D"),
                            QHS.FieldInList("iditinerationstatus", QHS.List(5, 8)));

            //filter = QHS.AppAnd(filter, QHC.CmpEq("ayear", Meta.GetSys("esercizio") ));
            if (IsManager)
            {
                filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.CmpEq("ismanager", "N"), QHS.CmpEq("idman", idman))));
            }
            else
            {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ismanager", "N"));
            }

            mainfilter = filter;

            GetData.SetStaticFilter(DS.itinerationauthview, filter);

            object viewtappe = Conn.DO_READ_VALUE("web_config", null, "showitinerationlap");
            if (viewtappe == null)
                viewtappe = DBNull.Value;
            if (viewtappe.ToString().ToUpper() == "N")
            {
                lbltappe.Visible = false;
                txtntappe.Visible = false;
            }
            txtMotivo.ReadOnly = true;
        }

        public void MetaData_AfterFill()
        {
            txtdatainizio.ReadOnly = true;
            txtdtafine.ReadOnly = true;
            txtpercipiente.ReadOnly = true;
            txtresponsabile.ReadOnly = true;
            txtadate.ReadOnly = true;
            btnapprova.Enabled = true;
            btnresp.Enabled = true;
            btnApproveAll.Enabled = true;
            btnspese.Enabled = true;
            btntappe.Enabled = true;
            txtesercizio.ReadOnly = true;
            txtnumero.ReadOnly = true;
            txtdescrizione.ReadOnly = true;
            txtntappe.ReadOnly = true;
            txtLocation.ReadOnly = true;
            txtapplierannotation.ReadOnly = true;
            txtMotivazione.ReadOnly = true;
            txtInfoVeicolo.ReadOnly = true;
            txtadditionalannotation.ReadOnly = true;
            //lblauthagency.Visible = true;
            ImpostaTageFiltriUPB(DBNull.Value);
            AbilitaUPB();
        }

        public void MetaData_AfterClear()
        {
            txtdatainizio.ReadOnly = false;
            txtdtafine.ReadOnly = false;
            txtpercipiente.ReadOnly = false;
            txtresponsabile.ReadOnly = false;
            txtadate.ReadOnly = false;

            btnapprova.Enabled = false;
            btnresp.Enabled = false;
            btnApproveAll.Enabled = false;

            btnspese.Enabled = false;
            btntappe.Enabled = false;
            txtdescrizione.ReadOnly = false;
            txtntappe.ReadOnly = false;
            txtLocation.ReadOnly = false;
            txtapplierannotation.ReadOnly = false;
            txtMotivazione.ReadOnly = false;
            txtInfoVeicolo.ReadOnly = false;
            panelAutorizzazioni.Visible = false;
            //lblauthagency.Visible = false;
            ImpostaTageFiltriUPB(DBNull.Value);
            //PanelUpb.Enabled = false;//ex true
            object catCfg = security.GetSys("system_config_catania_missioni");
            //Solo per Catania viene disabilitata la scelta dell'ubp in fase di ricerca.
            if (catCfg != null && catCfg.ToString().ToUpper() == "S")
            {
                gboxUPB.Enabled = false;
            }
            else
            {
                gboxUPB.Enabled = true;
            }
        }

        public void DoCancel()
        {
            // Imposta lo stato globale su "Annullata" (iditinerationstatus=7),
            // lo stato dell'approvazione su "N"
            // Aggiornare anche il campo "cancelreason" su itineration con il motivo della cancellazione
            ////rejectreason.Style.Remove("display");
            ////rejectreason.Style.Add("display", "none");
            ////rejectreason.Style.Remove("z-index");
            ////rejectreason.Style.Add("z-index", "11000");
            //GetImpersonatedAuthAgency();
            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
            DS.AcceptChanges();

            QHS = Conn.GetQueryHelper();

            string filter = "";
            filter = QHS.AppAnd(QHS.CmpEq("idauthagency", idauthagency), QHS.CmpEq("iditineration", iditineration));
            DataTable DTItinerationAuthAgency = Conn.RUN_SELECT("itinerationauthagency", "*", null, filter, null, false);
            if (DTItinerationAuthAgency == null || DTItinerationAuthAgency.Rows.Count == 0)
                return;
            DTItinerationAuthAgency.Rows[0]["flagstatus"] = "N";
            DTItinerationAuthAgency.setSkipSecurity();


            filter = QHS.CmpEq("iditineration", iditineration);
            DataTable DTItineration = Conn.CreateTableByName("itineration", "*");
            DTItineration.setSkipSecurity();
            Conn.RUN_SELECT_INTO_TABLE(DTItineration, null, filter, null, false);

            if (DTItineration == null || DTItineration.Rows.Count == 0)
                return;
            DTItineration.Rows[0]["iditinerationstatus"] = 7;
            if (txtrejectreason.Text != "")
                DTItineration.Rows[0]["webwarn"] = txtrejectreason.Text;
            if (txtAnnotazioniRifiutoApprovazione.Text != "")
                DTItineration.Rows[0]["cancelreason"] = txtAnnotazioniRifiutoApprovazione.Text;
            DataSet DSNew = new DataSet();

            DSNew.Tables.Add(DTItinerationAuthAgency);
            DSNew.Tables.Add(DTItineration);

            Easy_PostData PD = new Easy_PostData();
            PD.initClass(DSNew, Conn);
            ProcedureMessageCollection PMC = PD.DO_POST_SERVICE();
            if (!PMC.CanIgnore)
            {
                string longMessage = "";
                foreach (ProcedureMessage pm in PMC)
                {
                    longMessage += pm.GetKey() + " " + pm.LongMess + (pm.CanIgnore ? " warning " : " error") + "\n\r";
                }
                ShowClientMessage("Regole di sicurezza hanno impedito l'aggiornamento del DataBase", "Errore");
            }
            else
            {
                PD.DO_POST_SERVICE();
            }
            string errormsg = "";
            if (PMC.Count == 0)
            {
                try
                {
                    errormsg = MissFun.WebSendMails(Conn as DataAccess, DTItineration.Rows[0]);
                    if (errormsg != "")
                        ShowClientMessage(errormsg, "Errore");
                }
                catch
                {
                    ShowClientMessage("Errore di invio mail", "Errore");
                }

            }

            Meta.DoMainCommand("mainsetsearch");
            Meta.DoMainCommand("maindosearch");


        }

        bool DoApprove(DataRow rItinerationauthview)
        {

            PostData.RemoveFalseUpdates(DS);

            if (DS.HasChanges())
            {
                ShowClientMessage("Ci sono modifiche da salvare prima di procedere con l'approvazione", "Errore");
                return false;
            }
            string errormsg = "";
            bool ChangeGlobalItinerationStatus = false; //se true è necessario cambiare lo stato della missione (itineration)
            int iditineration = CfgFn.GetNoNullInt32(rItinerationauthview["iditineration"]);
            string filter = "";
            filter = QHS.AppAnd(QHS.CmpEq("iditineration", iditineration), QHS.CmpNe("idauthagency", idauthagency),
                   QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagstatus", "D"), QHS.CmpEq("flagstatus", "N"))));

            int pendingauthcount = Conn.RUN_SELECT_COUNT("itinerationauthagency", filter, false);
            if (pendingauthcount == 0)
            {//Non ci sono altre autorizzazioni pendenti
                ChangeGlobalItinerationStatus = true;//Bisogna cambiare lo stato complessivo della missione
            }

            filter = "";

            filter = QHS.AppAnd(QHS.CmpEq("iditineration", iditineration), QHS.CmpEq("idauthagency", idauthagency));

            DataSet DSNew = new DataSet();

            //Imposta i campi di itinerationauthagency e aggiunge la tabella 
            DataTable DTItinerationAuthAgency = Conn.RUN_SELECT("itinerationauthagency", "*", null, filter, null, false);
            DTItinerationAuthAgency.setSkipSecurity();

            if (DTItinerationAuthAgency == null || DTItinerationAuthAgency.Rows.Count == 0) return true;
            DTItinerationAuthAgency.Rows[0]["flagstatus"] = "S";

            if (txtAnnotazioniRifiutoApprovazione.Text != "")
            {
                DTItinerationAuthAgency.Rows[0]["annotationsrejectapproval"] = txtAnnotazioniRifiutoApprovazione.Text;
            }

            DSNew.Tables.Add(DTItinerationAuthAgency);


            DataTable DTItineration = Conn.CreateTableByName("itineration", "*");
            DTItineration.setSkipSecurity();
            filter = QHS.CmpEq("iditineration", iditineration);
            Conn.RUN_SELECT_INTO_TABLE(DTItineration, null, filter, null, false);
            if (DTItineration.Rows.Count == 0)
            {
                ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti (filtro applicato:{filter})", "Errore");
                return false;
            }
            if (ChangeGlobalItinerationStatus)
            {
                DTItineration.Rows[0]["iditinerationstatus"] = 6;
                DTItineration.Rows[0]["authorizationdate"] = DateTime.Now;
            }
            //DataRow rItinerationauthview = DS.itinerationauthview.Rows[0];
            //ShowClientMessage(rItinerationauthview["idupb"].ToString(), "Errore");
            bool upbaggiornato = false;
            if (rItinerationauthview["idupb"] != DBNull.Value)
            {
                DTItineration.Rows[0]["idupb"] = rItinerationauthview["idupb"];//Valorizza l'UPB
                upbaggiornato = true;
            }

            if (ChangeGlobalItinerationStatus || upbaggiornato)
            {
                DSNew.Tables.Add(DTItineration);
            }

            Easy_PostData PD = new Easy_PostData();
            PD.initClass(DSNew, Conn);
            ProcedureMessageCollection PMC = PD.DO_POST_SERVICE();

            if (!PMC.CanIgnore)
            {
                string longMessage = "";
                foreach (ProcedureMessage pm in PMC)
                {
                    longMessage += pm.GetKey() + " " + /*pm.LongMess +*/ (pm.CanIgnore ? ". Warning. " : ". Error. ");// + "\n\r";
                }

                ShowClientMessage("Regole non ignorabili hanno impedito il salvataggio. Espandere il messaggio per leggere il dettaglio.", "Errore");
                return false;
            }

            if (PMC.Count > 0)
            {
                PD.DO_POST_SERVICE();
            }
            try
            {
                errormsg = MissFun.WebSendMails(Conn as DataAccess, DTItineration.Rows[0]);
                if (errormsg != "")
                {
                    ShowClientMessage(errormsg, "Errore");
                    return false;
                }
            }
            catch
            {
                ShowClientMessage("Errore di invio mail", "Errore");
                return false;
            }


            return true;
        }


        private void btnSpese_Click(object sender, EventArgs e)
        {
            //ShowSpese();
        }

        private void btnTappe_Click(object sender, EventArgs e)
        {
            //ShowTappe();
        }

        private void btnApprova_Click(object sender, EventArgs e)
        {
            DoApprove();
        }

        private void btnApprovaTutti_Click(object sender, EventArgs e)
        {
            doApproveAll();
        }

        private void btnNega_Click(object sender, EventArgs e)
        {
            DoCancel();
        }

        private void btnNonNegare_Click(object sender, EventArgs e)
        {
            panelAutorizzazioni.Visible = false;
            btnapprova.Visible = true;
        }
        private void btnRespingi_Click(object sender, EventArgs e)
        {
            panelAutorizzazioni.Visible = true;
            btnapprova.Visible = false;
        }

        public void DoApprove()
        {
            string errormsg = "";
            // Determinare anche se sono l'ultimo ad approvare. Se si, 
            // Tutta la missione passa nello stato di approvato
            // Cioè se questa select count dà come risultato 0
            //select count(*) from itinerationauthagency where iditineration=159 
            // and idauthagency<>9 and (flagstatus='D' or flagstatus='N')
            // Modificare inoltre la data di autorizzazione oltre a quello globale
            bool ChangeGlobalItinerationStatus = false;
            DS.AcceptChanges();
            //GetImpersonatedAuthAgency();
            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
            bool res = DoApprove(Curr);
            if (!res)
                return;

            Meta.DoMainCommand("mainsetsearch");
            Meta.DoMainCommand("maindosearch");

        }

        public void doApproveAll()
        {
            DataTable T = Conn.RUN_SELECT("itinerationauthview", "*", null, mainfilter, null, false);
            foreach (DataRow R in T.Rows)
            {
                bool res = DoApprove(R);
                if (!res)
                    return;
            }

            Meta.DoMainCommand("mainsetsearch");
            Meta.DoMainCommand("maindosearch");

        }


        public void AbilitaUPB()
        {
            if (controller.IsEmpty)
            {
                gboxUPB.Enabled = false;
                return;
            }
            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);
            string flagownfunds = Conn.DO_READ_VALUE("itineration", QHS.CmpEq("iditineration", iditineration), "flagownfunds").ToString();
            if ((Curr["idupb", DataRowVersion.Original]) != DBNull.Value)
            {
                gboxUPB.Enabled = false;
                return;
            }

            if (flagownfunds == "N")
            {
                //Fondi di altri è l'agente che deve indicare l'UPB
                gboxUPB.Enabled = true;
            }
            else
            {
                //Se non valorizzato o Fondi propri
                gboxUPB.Enabled = false;
            }

        }
        private string CalcolaFiltroUPB()
        {
            if (controller.IsEmpty) return "";
            DataRow r = DS.itinerationauthview.Rows[0];
            string filter_upb = "";
            object idman = r["idman"];
            if (idman != DBNull.Value)
            {
                filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", idman));
            }
            return filter_upb;
        }

        private void ImpostaTageFiltriUPB(object idupbToinclude)
        {
            if (controller.IsEmpty) return;

            string upbfilter = CalcolaFiltroUPB();
            string filteradd = upbfilter;
            object importoPresuntoObj = null;
            decimal importoPresunto = 0;


            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);

            DataTable tItineration = Conn.CreateTableByName("itineration", "*");
            tItineration.setSkipSecurity();
            Conn.RUN_SELECT_INTO_TABLE(tItineration, null, QHS.CmpEq("iditineration", iditineration), null, true);
            if (tItineration.Rows.Count == 0)
            {
                ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti", "Errore");
                return;
            }
            DataRow R = tItineration.Rows[0];
            string advanceapplied = R["advanceapplied"].ToString();
            //Importo presunto (Anticipo No)
            if (advanceapplied == "N")
            {
                importoPresunto = CfgFn.GetNoNullDecimal(R["supposedamount"]);
            }
            //Importo presunto (Anticipo Si)
            if (advanceapplied == "S")
            {
                importoPresunto = CfgFn.GetNoNullDecimal(R["supposedfood"])
                    + CfgFn.GetNoNullDecimal(R["supposedliving"])
                    + CfgFn.GetNoNullDecimal(R["supposedtravel"]);
            }
            string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"),
                QHS.CmpGt("differenzadisponibilita", 0),
                QHS.CmpGe("differenzadisponibilita", importoPresunto), QHS.CmpEq("ayear", Conn.GetSys("esercizio")));
            if (idupbToinclude != DBNull.Value && upbfilter != "")
            {
                filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
            }

            GetData.SetStaticFilter(DS.upb, filteradd);

            //if (upbfilter != "") {
            btnUPBCode.Tag = "choose.upbitinerationavailable.default." + filteractive;
            //}
            //else {
            //    btnUPBCode.Tag = "manage.upb.tree";
            //}

            if (gboxUPB.Tag != null)
                gboxUPB.Tag = "AutoChoose.txtUPB.missioni." + filteractive;//"AutoChoose.txtCodiceUPB.default." + filteractive;
            controller.SetAutoMode(gboxUPB);

        }
        public void GetImpersonatedAuthAgency()
        {
            string idflowchart;
            if (Meta.GetSys("idflowchart") == null && Meta.GetSys("idflowchart").ToString() == "")
                return;

            // lookup idauthagency from idflowchart
            idflowchart = Meta.GetSys("idflowchart").ToString();
            QHS = Conn.GetQueryHelper();
            string filter;
            filter = QHS.CmpEq("idflowchart", idflowchart);
            DataTable DT = Conn.RUN_SELECT("flowchartauthagency", "*", null, filter, null, false);

            if (DT == null || DT.Rows.Count == 0)
                return;

            idauthagency = CfgFn.GetNoNullInt32(DT.Rows[0]["idauthagency"]);
            if (idauthagency == 0)
                return;

            filter = "";
            filter = QHS.CmpEq("idauthagency", idauthagency);

            DT = Conn.RUN_SELECT("authagency", "*", null, filter, null, false);
            if (DT == null || DT.Rows.Count == 0)
                return;

            string authagencytitle;
            authagencytitle = DT.Rows[0]["title"].ToString();
            lblauthagency.Text = "";
            lblauthagency.Text = "Ente Autorizzatore: <b>" + authagencytitle + "</b>";

            return;
        }
        /*
        public void ShowTappe()
        {
            QHS = Conn.GetQueryHelper();

            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);

            string Query = "";

            Query += "select (case when itinerationlap.flagitalian='S' then 'Italia' when itinerationlap.flagitalian='N' then 'Estero' End) as italiaestero, ";
            Query += " itinerationlap.starttime as inizio,itinerationlap.stoptime as fine, itinerationlap.days as giorni, itinerationlap.hours as ore, itinerationlap.description as description, ";
            Query += " foreigncountry.description as foreigncountrydes from ";
            Query += " itinerationlap left outer join foreigncountry on (itinerationlap.idforeigncountry=foreigncountry.idforeigncountry) ";
            Query += " where iditineration='" + iditineration.ToString() + "'";


            DataTable DT = Conn.SQLRunner(Query);

            DT.Columns["italiaestero"].Caption = "Italia/Estero";
            DT.Columns["inizio"].Caption = "Data/Ora Inizio";
            DT.Columns["fine"].Caption = "Data/Ora Fine";
            DT.Columns["giorni"].Caption = "Giorni";
            DT.Columns["ore"].Caption = "Ore";
            DT.Columns["description"].Caption = "Descrizione";
            DT.Columns["foreigncountrydes"].Caption = "Località Estera";
            ShowFormattedResults(DT, "Tappe Missione");
            return;

        }

        public void ShowSpese()
        {
            QHS = Conn.GetQueryHelper();

            DataRow Curr = DS.itinerationauthview.Rows[0];
            int iditineration = CfgFn.GetNoNullInt32(Curr["iditineration"]);

            string Query = " select itinerationrefundkind.description as refunddes, itinerationrefund.amount as amount";
            Query += " from itinerationrefund join itinerationrefundkind on itinerationrefund.iditinerationrefundkind=itinerationrefundkind.iditinerationrefundkind ";
            Query += " where iditineration='" + iditineration.ToString() + "' and flagadvancebalance='A'";

            DataTable DT = Conn.SQLRunner(Query);


            DataTable Titineration = Conn.CreateTableByName("itineration", "*");
            Titineration.setSkipSecurity();
            Conn.RUN_SELECT_INTO_TABLE(Titineration, null, QHS.CmpEq("iditineration", iditineration), null, false);
            if (Titineration.Rows.Count == 0)
            {
                ShowClientMessage($"Non si dispone delle autorizzazioni sufficienti", "Errore");
                return;
            }

            DataRow Ritineration = Titineration.Rows[0];
            if ((DT.Rows.Count == 1) && CfgFn.GetNoNullDecimal(Ritineration["supposedamount"]) > 0)
            {
                Query = " select 'Importo presunto della missione' as refunddes, supposedamount as amount";
                Query += " from itineration ";
                Query += " where iditineration='" + iditineration.ToString() + "'";
                DT = Conn.SQLRunner(Query);
            }
            DT.Columns["amount"].Caption = "Importo (EURO)";
            DT.Columns["refunddes"].Caption = "Classificazione";
            ShowFormattedResults(DT, "Spese Previste");
            return;
        }

        public void ShowEmptyMessage(string TableName)
        {
            string OutHTML = "";
            OutHTML += "<div class=\"row\">";
            OutHTML += "<div class=\"col-md-12\">";
            OutHTML += "<fieldset style=\"background-color: #eeeeee; font-size: 14px; \">";
            OutHTML += "<legend style=\"text-align :center\">" + TableName + "</legend>";


            OutHTML += "<div class=\"row\">";
            OutHTML += "<div class=\"col-md-1\"></div>";
            OutHTML += "<div class=\"col-md-10\">";
            OutHTML += "<label>Nessuna Riga Presente.</label>";
            OutHTML += "</div>";
            OutHTML += "<div class=\"col-md-1\"></div>";
            OutHTML += "</div>";//chiude la rows

            OutHTML += "<div class=\"row\">";//apre la rows del btnOK
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "<div class=\"col-md-2\">";
            OutHTML += "<input type=\"button\" id=\"btnok\" value=\"Ok\" onclick=\"javascript:closelist();\"></center><br/>";
            OutHTML += "</div>";
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "</div>";//chiude rows del btnOK

            OutHTML += "</fieldset>";
            OutHTML += "</div>";
            OutHTML += "</div>";
            plcitems.InnerHtml = OutHTML;
            plcitems.Style.Remove("display");
            plcitems.Style.Add("display", "block");
            plcitems.Style.Remove("z-index");
            plcitems.Style.Add("z-index", "11000");
            plcitems.Style.Remove("overflow");
            plcitems.Style.Remove("max-height");
            plcitems.Style.Add("max-height", "auto");
            plcitems.Style.Remove("width");
            plcitems.Style.Add("width", "auto");


            return;
        }


        public void ShowFormattedResults(DataTable T, String TableName)
        {

            string OutHTML;

            if (T.Rows.Count == 0 || T == null)
            {
                ShowEmptyMessage(TableName);
                return;
            }


            OutHTML = "";
            OutHTML += "<div class=\"row\">";// row
            OutHTML += "<div class=\"col-md-12\">"; // col

            OutHTML += "<fieldset style=\"background-color: #eeeeee; font-size: 14px; \">";
            OutHTML += "<legend style=\"text-align :center\">" + TableName + "</legend>";

            OutHTML += "<div class=\"row\">";
            OutHTML += "<div class=\"col-md-12\">";
            OutHTML += "<table class=\"table table-striped\";>";
            OutHTML += "<thead><tr style=\"background-color:#ffffff;color:#000000;\">";

            for (int indexcolumn = 0; indexcolumn < T.Columns.Count; indexcolumn++)
            {
                DataColumn C = T.Columns[indexcolumn];
                OutHTML += "<th><center>" + C.Caption + "</center></th>";
            }

            OutHTML += "</thead>";//chiude la composizione delle intestazioni di colonna
            OutHTML += "<tbody>";

            int rowcount = T.Rows.Count;

            for (int rowindex = 0; rowindex < rowcount; rowindex++)
            {
                DataRow DR = T.Rows[rowindex];

                string bgcolor;
                if (rowindex % 2 == 0)
                    bgcolor = "#d9edf7;";
                else
                    bgcolor = "#c4e3f3;";

                OutHTML += "<tr style='background-color:" + bgcolor + "'>";
                for (int columnindex = 0; columnindex < T.Columns.Count; columnindex++)
                {
                    DataColumn C = T.Columns[columnindex];

                    System.Windows.Forms.HorizontalAlignment HA = HelpForm.GetAlignForColumn(C);
                    string OutputValue = GetValoreFormattato(DR, C.ColumnName);

                    if (HA == System.Windows.Forms.HorizontalAlignment.Right)
                        OutHTML += "<td align=\"right\">" + OutputValue + "</td>";
                    else
                        OutHTML += "<td align=\"left\">" + OutputValue + "</td>";

                }
            }
            OutHTML += "</tbody></table>";

            OutHTML += "</div>";// chiude class col-md-12
            OutHTML += "</div>";//chiude la rows

            OutHTML += "<div class=\"row\">";//apre la rows del btnOK
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "<div class=\"col-md-2\">";
            OutHTML += "<input type=\"button\" id=\"btnok\" value=\"Ok\" onclick=\"javascript:closelist();\"></center><br/>";
            OutHTML += "</div>";
            OutHTML += "<div class=\"col-md-5\"></div>";
            OutHTML += "</div>";//chiude rows del btnOK
            OutHTML += "</fieldset>";
            OutHTML += "</div>";//chiude la colonna - new
            OutHTML += "</div>";//chiude la riga - new
            plcitems.InnerHtml = OutHTML;
            plcitems.Style.Remove("display");
            plcitems.Style.Add("display", "block");
            plcitems.Style.Remove("z-index");
            plcitems.Style.Add("z-index", "11000");
            plcitems.Style.Remove("overflow");
            plcitems.Style.Remove("max-height");
            plcitems.Style.Add("max-height", "auto");
            plcitems.Style.Remove("width");
            plcitems.Style.Add("width", "auto");

        }

        public string GetValoreFormattato(DataRow R, string field)
        {
            string tag = HelpForm.CompleteTag(null, R.Table.Columns[field]);
            return HelpForm.StringValue(R[field], tag);
        }
        */
    }
}