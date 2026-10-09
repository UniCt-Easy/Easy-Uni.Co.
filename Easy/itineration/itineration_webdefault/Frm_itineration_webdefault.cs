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
using ep_functions;
using funzioni_configurazione;
using itinerationFunctions;
using metadatalibrary;
using metaeasylibrary;
using pdfa_converter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace itineration_webdefault
{

    /// <summary>
    /// Summary description for frmmissione.
    /// </summary>
    public class Frm_itineration_webdefault : MetaDataForm
    {
        #region Variabili

        IMetaData Meta;
        bool AnticipoIsReadOnly;

        DataAccess sysConn = null;

        public const string ExtraParams = "ExtraParameters";

        bool managingstatus = false;

        List<string> mandatoryControls = new List<string>();

        CfgItineration MyCfg = new CfgItineration();

        string LastFilterPosGiuridica;

        bool inside_lostfocus = false;

        /// <summary>
        /// True se in app_config esiste la riga code = 'DELEGATO_MISSIONE' con param = 'S':
        /// in tal caso il gruppo "Delegato della Missione" viene mostrato ed utilizzato.
        /// </summary>
        bool delegatoMissioneAbilitato = false;

        public Hashtable var = new Hashtable();

        #endregion

        #region Controlli

        //private TextBox txtInfos;
        private TextBox txtEsercmissione;
        private Label label2;
        private TextBox txtNummissione;
        private GroupBox grpIncaricato;
        private TextBox txtIncaricato;
        private GroupBox grpDelegatoMissione;
        private TextBox txtDelegatoMissione;
        public dsmeta DS;
        private TextBox txtDescrizione;
        private Label label4;
        private Label label5;
        private TextBox txtDataInizio;
        private Label label6;
        private TextBox txtDataFine;
        private GroupBox grpTappe;
        private GroupBox grpAllegati;
        private Label label23;
        private TextBox txtKmMezzoProprio;
        private TextBox txtEurKmMezzoProprio;
        private Label label24;
        private TextBox txtEurTotMezzoProprio;
        private Label label25;
        private GroupBox grpIndMezzoProprio;
        private DataGrid dgrTappe;
        private Button btnDelTappa;
        private Button btnEditTappa;
        private Button btnInsertTappa;
        private ToolTip myTip;
        private System.ComponentModel.IContainer components;
        private ImageList imageList1;
        private Label label1;
        private ComboBox cmbStatus;
        private GroupBox gboxAction;
        private Button btnAccetta;
        private Button btnRiconsidera;
        private Button btnintegra;
        private ComboBox cmbAuthModel;
        private DataGrid dgrAutorizzazioni;
        private Button btnAttesaAutorizzazione;
        private TextBox txtapplierannotation;
        private TextBox txtwebwarn;
        private Button btnAnnulla;
        private TextBox txtImportoMax;
        private Label label10;
        private TextBox txtLunghezzaMax;
        private Label label17;
        private TextBox txtClause;
        private CheckBox chkClauseMezzoProprio;
        private Label label38;
        private TextBox txtDatiMezzoProprio;
        private Label label34;
        private TextBox txtCausaleMezzoProprio;
        private DataGrid dataGrid3;
        private Button btnDelAtt;
        private Button btnEditAtt;
        private Button btnInsAtt;
        private Label lblLocalitaPrincipale;
        private TextBox txtLocation;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        public Button btnResponsabile;
        private TextBox txtadditionalannotation;
        private Button btnStampaMissione;
        private Button btnStatus;
        private Button btnitinerationhistory;
        private GroupBox grpSpeseRendiconto;
        private TextBox txtsaldoaccordato;
        private Button btnDeleteSpesaSaldo;
        private TextBox txtsaldorichiesto;
        private Label label33;
        private Button btnEditSpesaSaldo;
        private Label label36;
        private DataGrid dgrSpeseSaldo;
        private Button btnInsertSpesaSaldo;
        private GroupBox grpSpese;
        private Label label32;
        private TextBox txtanticipoaccordato;
        private Label label22;
        private TextBox txtanticiporichiesto;
        private Button btnDelSpesa;
        private Button btnEditSpesa;
        private DataGrid dgrSpeseTappe;
        private Button btnInsertSpesa;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox grpIndKm;
        private Label lblAppunti;
        private Label lblMissione;
        private Label lblStato;
        private Label lblDateMissione;
        private Label lblModelloAutorizzativo;
        private Label lblAutorizzazioni;
        private Label lblAvvisi;
        private Label lblAdditionalAnnotation;
        private EP_Manager EPM;

        #endregion

        object CodiceResponsabile = "";
        string Responsabile = "";

        public Frm_itineration_webdefault()
        {
            InitializeComponent();
            txtDataInizio.LostFocus += new System.EventHandler(txtDataInizio_LostFocus);
            txtDataFine.LostFocus += new EventHandler(txtDataFine_LostFocus);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itineration_webdefault));
			this.label38 = new System.Windows.Forms.Label();
			this.txtDatiMezzoProprio = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.txtCausaleMezzoProprio = new System.Windows.Forms.TextBox();
			this.txtClause = new System.Windows.Forms.TextBox();
			this.chkClauseMezzoProprio = new System.Windows.Forms.CheckBox();
			this.grpIndMezzoProprio = new System.Windows.Forms.GroupBox();
			this.txtEurTotMezzoProprio = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtKmMezzoProprio = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtEurKmMezzoProprio = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.txtadditionalannotation = new System.Windows.Forms.TextBox();
			this.txtapplierannotation = new System.Windows.Forms.TextBox();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnitinerationhistory = new System.Windows.Forms.Button();
			this.btnStampaMissione = new System.Windows.Forms.Button();
			this.btnStatus = new System.Windows.Forms.Button();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.btnResponsabile = new System.Windows.Forms.Button();
			this.lblLocalitaPrincipale = new System.Windows.Forms.Label();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.gboxAction = new System.Windows.Forms.GroupBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnAttesaAutorizzazione = new System.Windows.Forms.Button();
			this.btnAccetta = new System.Windows.Forms.Button();
			this.btnRiconsidera = new System.Windows.Forms.Button();
			this.btnintegra = new System.Windows.Forms.Button();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.DS = new itineration_webdefault.dsmeta();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
            //this.txtInfos = new System.Windows.Forms.TextBox();
            this.txtEsercmissione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNummissione = new System.Windows.Forms.TextBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grpIncaricato = new System.Windows.Forms.GroupBox();
			this.txtIncaricato = new System.Windows.Forms.TextBox();
            this.grpDelegatoMissione = new System.Windows.Forms.GroupBox();
            this.txtDelegatoMissione = new System.Windows.Forms.TextBox();
			this.txtwebwarn = new System.Windows.Forms.TextBox();
			this.dgrAutorizzazioni = new System.Windows.Forms.DataGrid();
			this.txtImportoMax = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbAuthModel = new System.Windows.Forms.ComboBox();
			this.txtLunghezzaMax = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.grpSpeseRendiconto = new System.Windows.Forms.GroupBox();
			this.txtsaldoaccordato = new System.Windows.Forms.TextBox();
			this.btnDeleteSpesaSaldo = new System.Windows.Forms.Button();
			this.txtsaldorichiesto = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.btnEditSpesaSaldo = new System.Windows.Forms.Button();
			this.label36 = new System.Windows.Forms.Label();
			this.dgrSpeseSaldo = new System.Windows.Forms.DataGrid();
			this.btnInsertSpesaSaldo = new System.Windows.Forms.Button();
			this.grpSpese = new System.Windows.Forms.GroupBox();
			this.label32 = new System.Windows.Forms.Label();
			this.txtanticipoaccordato = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtanticiporichiesto = new System.Windows.Forms.TextBox();
			this.btnDelSpesa = new System.Windows.Forms.Button();
			this.btnEditSpesa = new System.Windows.Forms.Button();
			this.dgrSpeseTappe = new System.Windows.Forms.DataGrid();
			this.btnInsertSpesa = new System.Windows.Forms.Button();
			this.grpTappe = new System.Windows.Forms.GroupBox();
			this.btnDelTappa = new System.Windows.Forms.Button();
			this.btnEditTappa = new System.Windows.Forms.Button();
			this.dgrTappe = new System.Windows.Forms.DataGrid();
			this.btnInsertTappa = new System.Windows.Forms.Button();
			this.grpAllegati = new System.Windows.Forms.GroupBox();
			this.myTip = new System.Windows.Forms.ToolTip(this.components);
			this.grpIndKm = new System.Windows.Forms.GroupBox();
			this.lblAppunti = new System.Windows.Forms.Label();
			this.lblMissione = new System.Windows.Forms.Label();
			this.lblStato = new System.Windows.Forms.Label();
			this.lblDateMissione = new System.Windows.Forms.Label();
			this.lblModelloAutorizzativo = new System.Windows.Forms.Label();
			this.lblAutorizzazioni = new System.Windows.Forms.Label();
			this.lblAvvisi = new System.Windows.Forms.Label();
			this.lblAdditionalAnnotation = new System.Windows.Forms.Label();
			this.grpIndMezzoProprio.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.gboxResponsabile.SuspendLayout();
			this.gboxAction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpIncaricato.SuspendLayout();
            this.grpDelegatoMissione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAutorizzazioni)).BeginInit();
			this.grpSpeseRendiconto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseSaldo)).BeginInit();
			this.grpSpese.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseTappe)).BeginInit();
			this.grpTappe.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrTappe)).BeginInit();
			this.grpAllegati.SuspendLayout();
			this.grpIndKm.SuspendLayout();
			this.SuspendLayout();
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(314, 87);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(138, 13);
			this.label38.TabIndex = 300;
			this.label38.Text = "Dati identificativi del veicolo";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDatiMezzoProprio
			// 
			this.txtDatiMezzoProprio.Location = new System.Drawing.Point(317, 103);
			this.txtDatiMezzoProprio.Multiline = true;
			this.txtDatiMezzoProprio.Name = "txtDatiMezzoProprio";
			this.txtDatiMezzoProprio.Size = new System.Drawing.Size(135, 45);
			this.txtDatiMezzoProprio.TabIndex = 35;
			this.txtDatiMezzoProprio.Tag = "itineration.vehicle_info";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(311, 16);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(45, 13);
			this.label34.TabIndex = 301;
			this.label34.Text = "Causale";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCausaleMezzoProprio
			// 
			this.txtCausaleMezzoProprio.Location = new System.Drawing.Point(314, 32);
			this.txtCausaleMezzoProprio.Multiline = true;
			this.txtCausaleMezzoProprio.Name = "txtCausaleMezzoProprio";
			this.txtCausaleMezzoProprio.Size = new System.Drawing.Size(138, 48);
			this.txtCausaleMezzoProprio.TabIndex = 34;
			this.txtCausaleMezzoProprio.Tag = "itineration.vehicle_motive";
			// 
			// txtClause
			// 
			this.txtClause.Location = new System.Drawing.Point(196, 19);
			this.txtClause.Multiline = true;
			this.txtClause.Name = "txtClause";
			this.txtClause.ReadOnly = true;
			this.txtClause.Size = new System.Drawing.Size(112, 80);
			this.txtClause.TabIndex = 7;
			// 
			// chkClauseMezzoProprio
			// 
			this.chkClauseMezzoProprio.AutoSize = true;
			this.chkClauseMezzoProprio.Location = new System.Drawing.Point(200, 121);
			this.chkClauseMezzoProprio.Name = "chkClauseMezzoProprio";
			this.chkClauseMezzoProprio.Size = new System.Drawing.Size(116, 17);
			this.chkClauseMezzoProprio.TabIndex = 33;
			this.chkClauseMezzoProprio.Tag = "itineration.clause_accepted:S:N";
			this.chkClauseMezzoProprio.Text = "Accetto la clausola";
			this.chkClauseMezzoProprio.UseVisualStyleBackColor = true;
			// 
			// grpIndMezzoProprio
			// 
			this.grpIndMezzoProprio.Controls.Add(this.txtEurTotMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label25);
			this.grpIndMezzoProprio.Controls.Add(this.txtKmMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label23);
			this.grpIndMezzoProprio.Controls.Add(this.txtEurKmMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label24);
			this.grpIndMezzoProprio.Location = new System.Drawing.Point(6, 19);
			this.grpIndMezzoProprio.Name = "grpIndMezzoProprio";
			this.grpIndMezzoProprio.Size = new System.Drawing.Size(184, 119);
			this.grpIndMezzoProprio.TabIndex = 400;
			this.grpIndMezzoProprio.TabStop = false;
			this.grpIndMezzoProprio.Text = "Mezzo proprio";
			// 
			// txtEurTotMezzoProprio
			// 
			this.txtEurTotMezzoProprio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEurTotMezzoProprio.Location = new System.Drawing.Point(88, 84);
			this.txtEurTotMezzoProprio.Name = "txtEurTotMezzoProprio";
			this.txtEurTotMezzoProprio.ReadOnly = true;
			this.txtEurTotMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtEurTotMezzoProprio.TabIndex = 32;
			this.txtEurTotMezzoProprio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(8, 84);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(56, 13);
			this.label25.TabIndex = 302;
			this.label25.Text = "EUR tot.";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtKmMezzoProprio
			// 
			this.txtKmMezzoProprio.Location = new System.Drawing.Point(88, 16);
			this.txtKmMezzoProprio.Name = "txtKmMezzoProprio";
			this.txtKmMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtKmMezzoProprio.TabIndex = 30;
			this.txtKmMezzoProprio.Tag = "itineration.owncarkm";
			this.txtKmMezzoProprio.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(8, 16);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(65, 13);
			this.label23.TabIndex = 303;
			this.label23.Text = "Km. percorsi";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEurKmMezzoProprio
			// 
			this.txtEurKmMezzoProprio.Location = new System.Drawing.Point(88, 48);
			this.txtEurKmMezzoProprio.Name = "txtEurKmMezzoProprio";
			this.txtEurKmMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtEurKmMezzoProprio.TabIndex = 31;
			this.txtEurKmMezzoProprio.Tag = "itineration.owncarkmcost.fixed.5...1";
			this.txtEurKmMezzoProprio.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(8, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(53, 13);
			this.label24.TabIndex = 304;
			this.label24.Text = "EUR/Km.";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(8, 506);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(413, 104);
			this.gboxUPB.TabIndex = 401;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Location = new System.Drawing.Point(8, 77);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(396, 20);
			this.txtUPB.TabIndex = 38;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(229, 62);
			this.txtDescrUPB.TabIndex = 36;
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
			this.btnUPBCode.TabIndex = 37;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// txtadditionalannotation
			// 
			this.txtadditionalannotation.Location = new System.Drawing.Point(495, 361);
			this.txtadditionalannotation.Multiline = true;
			this.txtadditionalannotation.Name = "txtadditionalannotation";
			this.txtadditionalannotation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtadditionalannotation.Size = new System.Drawing.Size(169, 50);
			this.txtadditionalannotation.TabIndex = 40;
			this.txtadditionalannotation.Tag = "itineration.additionalannotations";
			// 
			// txtapplierannotation
			// 
			this.txtapplierannotation.Location = new System.Drawing.Point(730, 29);
			this.txtapplierannotation.Multiline = true;
			this.txtapplierannotation.Name = "txtapplierannotation";
			this.txtapplierannotation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtapplierannotation.Size = new System.Drawing.Size(178, 35);
			this.txtapplierannotation.TabIndex = 39;
			this.txtapplierannotation.Tag = "itineration.applierannotations";
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
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(176, 19);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 24);
			this.btnDelAtt.TabIndex = 43;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
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
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(16, 19);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 24);
			this.btnInsAtt.TabIndex = 41;
			this.btnInsAtt.Tag = "insert.default";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// btnitinerationhistory
			// 
			this.btnitinerationhistory.Location = new System.Drawing.Point(337, 98);
			this.btnitinerationhistory.Name = "btnitinerationhistory";
			this.btnitinerationhistory.Size = new System.Drawing.Size(102, 23);
			this.btnitinerationhistory.TabIndex = 9;
			this.btnitinerationhistory.Text = "Storico Missione";
			this.btnitinerationhistory.UseVisualStyleBackColor = true;
			this.btnitinerationhistory.Click += new System.EventHandler(this.btnitinerationhistory_Click);
			// 
			// btnStampaMissione
			// 
			this.btnStampaMissione.Location = new System.Drawing.Point(342, 72);
			this.btnStampaMissione.Name = "btnStampaMissione";
			this.btnStampaMissione.Size = new System.Drawing.Size(97, 24);
			this.btnStampaMissione.TabIndex = 8;
			this.btnStampaMissione.TabStop = false;
			this.btnStampaMissione.Tag = "";
			this.btnStampaMissione.Text = "Stampa";
			this.btnStampaMissione.Click += new System.EventHandler(this.btnStampaMissione_Click);
			// 
			// btnStatus
			// 
			this.btnStatus.Location = new System.Drawing.Point(144, 77);
			this.btnStatus.Name = "btnStatus";
			this.btnStatus.Size = new System.Drawing.Size(97, 24);
			this.btnStatus.TabIndex = 3;
			this.btnStatus.TabStop = false;
			this.btnStatus.Tag = "";
			this.btnStatus.Text = "Stato";
			this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Controls.Add(this.btnResponsabile);
			this.gboxResponsabile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gboxResponsabile.Location = new System.Drawing.Point(865, 83);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(125, 40);
			this.gboxResponsabile.TabIndex = 403;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.lista.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(67, 20);
			this.txtResponsabile.TabIndex = 12;
			this.txtResponsabile.Tag = "managerwebview.title?itinerationview.manager";
			// 
			// btnResponsabile
			// 
			this.btnResponsabile.Location = new System.Drawing.Point(74, 14);
			this.btnResponsabile.Name = "btnResponsabile";
			this.btnResponsabile.Size = new System.Drawing.Size(50, 24);
			this.btnResponsabile.TabIndex = 13;
			this.btnResponsabile.TabStop = false;
			this.btnResponsabile.Tag = "choose.managerwebview.lista";
			this.btnResponsabile.Text = "...";
			// 
			// lblLocalitaPrincipale
			// 
			this.lblLocalitaPrincipale.AutoSize = true;
			this.lblLocalitaPrincipale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLocalitaPrincipale.Location = new System.Drawing.Point(709, 82);
			this.lblLocalitaPrincipale.Name = "lblLocalitaPrincipale";
			this.lblLocalitaPrincipale.Size = new System.Drawing.Size(150, 13);
			this.lblLocalitaPrincipale.TabIndex = 305;
			this.lblLocalitaPrincipale.Text = "Localita principale (facoltativo)";
			this.lblLocalitaPrincipale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(712, 101);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.Size = new System.Drawing.Size(140, 20);
			this.txtLocation.TabIndex = 6;
			this.txtLocation.Tag = "itineration.location";
			// 
			// gboxAction
			// 
			this.gboxAction.Controls.Add(this.btnAnnulla);
			this.gboxAction.Controls.Add(this.btnAttesaAutorizzazione);
			this.gboxAction.Controls.Add(this.btnAccetta);
			this.gboxAction.Controls.Add(this.btnRiconsidera);
			this.gboxAction.Controls.Add(this.btnintegra);
			this.gboxAction.Location = new System.Drawing.Point(12, 12);
			this.gboxAction.Name = "gboxAction";
			this.gboxAction.Size = new System.Drawing.Size(698, 47);
			this.gboxAction.TabIndex = 404;
			this.gboxAction.TabStop = false;
			this.gboxAction.Visible = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(500, 14);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(97, 24);
			this.btnAnnulla.TabIndex = 46;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Tag = "";
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnAttesaAutorizzazione
			// 
			this.btnAttesaAutorizzazione.Location = new System.Drawing.Point(249, 14);
			this.btnAttesaAutorizzazione.Name = "btnAttesaAutorizzazione";
			this.btnAttesaAutorizzazione.Size = new System.Drawing.Size(244, 24);
			this.btnAttesaAutorizzazione.TabIndex = 45;
			this.btnAttesaAutorizzazione.TabStop = false;
			this.btnAttesaAutorizzazione.Tag = "";
			this.btnAttesaAutorizzazione.Text = "Poni In Attesa di Autorizzazione";
			this.btnAttesaAutorizzazione.Click += new System.EventHandler(this.btnAttesaAutorizzazione_Click);
			// 
			// btnAccetta
			// 
			this.btnAccetta.Location = new System.Drawing.Point(9, 14);
			this.btnAccetta.Name = "btnAccetta";
			this.btnAccetta.Size = new System.Drawing.Size(97, 24);
			this.btnAccetta.TabIndex = 41;
			this.btnAccetta.TabStop = false;
			this.btnAccetta.Tag = "";
			this.btnAccetta.Text = "Accetta";
			this.btnAccetta.Click += new System.EventHandler(this.btnAccetta_Click);
			// 
			// btnRiconsidera
			// 
			this.btnRiconsidera.Location = new System.Drawing.Point(605, 14);
			this.btnRiconsidera.Name = "btnRiconsidera";
			this.btnRiconsidera.Size = new System.Drawing.Size(85, 24);
			this.btnRiconsidera.TabIndex = 44;
			this.btnRiconsidera.TabStop = false;
			this.btnRiconsidera.Tag = "";
			this.btnRiconsidera.Text = "Riconsidera";
			this.btnRiconsidera.Click += new System.EventHandler(this.btnRiconsidera_Click);
			// 
			// btnintegra
			// 
			this.btnintegra.Location = new System.Drawing.Point(111, 14);
			this.btnintegra.Name = "btnintegra";
			this.btnintegra.Size = new System.Drawing.Size(132, 24);
			this.btnintegra.TabIndex = 42;
			this.btnintegra.TabStop = false;
			this.btnintegra.Tag = "";
			this.btnintegra.Text = "Richiedi integrazioni";
			this.btnintegra.Click += new System.EventHandler(this.btnintegra_Click);
			// 
			// cmbStatus
			// 
			this.cmbStatus.DataSource = this.DS.itinerationstatus;
			this.cmbStatus.DisplayMember = "description";
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Location = new System.Drawing.Point(247, 100);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(77, 21);
			this.cmbStatus.TabIndex = 2;
			this.cmbStatus.Tag = "itineration.iditinerationstatus?itinerationview.iditinerationstatus";
			this.cmbStatus.ValueMember = "iditinerationstatus";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(456, 105);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 306;
			this.label6.Text = "Data fine:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(521, 102);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(80, 20);
			this.txtDataFine.TabIndex = 11;
			this.txtDataFine.Tag = "itineration.stop";
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(456, 79);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 307;
			this.label5.Text = "Data inizio:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(521, 76);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(80, 20);
			this.txtDataInizio.TabIndex = 10;
			this.txtDataInizio.Tag = "itineration.start";
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 308;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInfos
            // 
            // txtInfos
            // 
            //this.txtInfos.Location = new System.Drawing.Point(165, 35);
            //this.txtInfos.Name = "txtInfos";
            //this.txtInfos.Multiline = true;
            //this.txtInfos.Size = new System.Drawing.Size(53, 20);
            //this.txtInfos.TabIndex = 500;
            // 
            // txtEsercmissione
            // 
            this.txtEsercmissione.Location = new System.Drawing.Point(65, 75);
			this.txtEsercmissione.Name = "txtEsercmissione";
			this.txtEsercmissione.Size = new System.Drawing.Size(53, 20);
			this.txtEsercmissione.TabIndex = 0;
			this.txtEsercmissione.Tag = "itineration.yitineration.year";
			this.txtEsercmissione.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 309;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNummissione
			// 
			this.txtNummissione.Location = new System.Drawing.Point(65, 101);
			this.txtNummissione.Name = "txtNummissione";
			this.txtNummissione.Size = new System.Drawing.Size(53, 20);
			this.txtNummissione.TabIndex = 1;
			this.txtNummissione.Tag = "itineration.nitineration";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(505, 544);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(142, 32);
			this.txtDescrizione.TabIndex = 7;
			this.txtDescrizione.Tag = "itineration.description";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(509, 528);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 310;
			this.label4.Text = "Descrizione";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpIncaricato
			// 
			this.grpIncaricato.Controls.Add(this.txtIncaricato);
			this.grpIncaricato.Location = new System.Drawing.Point(337, 128);
			this.grpIncaricato.Name = "grpIncaricato";
			this.grpIncaricato.Size = new System.Drawing.Size(147, 48);
			this.grpIncaricato.TabIndex = 405;
			this.grpIncaricato.TabStop = false;
			this.grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = \'S\') AND (idreg IN(SELECT idreg FROM registrylegalstatus)) )";
			this.grpIncaricato.Text = "Percipiente";
			// 
			// txtIncaricato
			// 
			this.txtIncaricato.Location = new System.Drawing.Point(8, 16);
			this.txtIncaricato.Name = "txtIncaricato";
			this.txtIncaricato.Size = new System.Drawing.Size(131, 20);
			this.txtIncaricato.TabIndex = 5;
			this.txtIncaricato.Tag = "registry.title?itinerationview.registry";
            // 
            // grpDelegatoMissione
            // 
            this.grpDelegatoMissione.Controls.Add(this.txtDelegatoMissione);
            this.grpDelegatoMissione.Location = new System.Drawing.Point(497, 128);
            this.grpDelegatoMissione.Name = "grpDelegatoMissione";
            this.grpDelegatoMissione.Size = new System.Drawing.Size(147, 48);
            this.grpDelegatoMissione.TabIndex = 405;
            this.grpDelegatoMissione.TabStop = false;
            this.grpDelegatoMissione.Tag = "AutoChoose.txtDelegatoMissione.default.((active = \'S\') AND (idreg IN(SELECT idreg FROM registrylegalstatus)) )";
            this.grpDelegatoMissione.Text = "Delegato della Missione";
            // 
            // txtDelegatoMissione
            // 
            this.txtDelegatoMissione.Location = new System.Drawing.Point(8, 16);
            this.txtDelegatoMissione.Name = "txtDelegatoMissione";
            this.txtDelegatoMissione.Size = new System.Drawing.Size(131, 20);
            this.txtDelegatoMissione.TabIndex = 5;
            this.txtDelegatoMissione.Tag = "registry_delegato.title?itinerationview.delegato";
            // 
            // txtwebwarn
            // 
            this.txtwebwarn.Location = new System.Drawing.Point(495, 434);
			this.txtwebwarn.Multiline = true;
			this.txtwebwarn.Name = "txtwebwarn";
			this.txtwebwarn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtwebwarn.Size = new System.Drawing.Size(169, 90);
			this.txtwebwarn.TabIndex = 16;
			this.txtwebwarn.Tag = "itineration.webwarn";
			// 
			// dgrAutorizzazioni
			// 
			this.dgrAutorizzazioni.DataMember = "";
			this.dgrAutorizzazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrAutorizzazioni.Location = new System.Drawing.Point(14, 204);
			this.dgrAutorizzazioni.Name = "dgrAutorizzazioni";
			this.dgrAutorizzazioni.ReadOnly = true;
			this.dgrAutorizzazioni.Size = new System.Drawing.Size(124, 91);
			this.dgrAutorizzazioni.TabIndex = 406;
			this.dgrAutorizzazioni.Tag = "itinerationauthagency.default";
			// 
			// txtImportoMax
			// 
			this.txtImportoMax.Location = new System.Drawing.Point(204, 128);
			this.txtImportoMax.Name = "txtImportoMax";
			this.txtImportoMax.Size = new System.Drawing.Size(112, 20);
			this.txtImportoMax.TabIndex = 15;
			this.txtImportoMax.TabStop = false;
			this.txtImportoMax.Tag = "authmodel.maxlen";
			this.txtImportoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(132, 131);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 13);
			this.label10.TabIndex = 311;
			this.label10.Text = "Durata Max:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbAuthModel
			// 
			this.cmbAuthModel.DataSource = this.DS.authmodel;
			this.cmbAuthModel.DisplayMember = "title";
			this.cmbAuthModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAuthModel.Location = new System.Drawing.Point(16, 153);
			this.cmbAuthModel.Name = "cmbAuthModel";
			this.cmbAuthModel.Size = new System.Drawing.Size(104, 21);
			this.cmbAuthModel.TabIndex = 13;
			this.cmbAuthModel.Tag = "itineration.idauthmodel?itinerationview.idauthmodel";
			this.cmbAuthModel.ValueMember = "idauthmodel";
            this.cmbAuthModel.SelectedIndexChanged += new System.EventHandler(this.cmbAuthModel_SelectedIndexChanged);
            // 
            // txtLunghezzaMax
            // 
            this.txtLunghezzaMax.Location = new System.Drawing.Point(204, 154);
			this.txtLunghezzaMax.Name = "txtLunghezzaMax";
			this.txtLunghezzaMax.Size = new System.Drawing.Size(112, 20);
			this.txtLunghezzaMax.TabIndex = 14;
			this.txtLunghezzaMax.TabStop = false;
			this.txtLunghezzaMax.Tag = "authmodel.maxamount.c";
			this.txtLunghezzaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(130, 154);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(68, 13);
			this.label17.TabIndex = 312;
			this.label17.Text = "Importo Max:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpSpeseRendiconto
			// 
			this.grpSpeseRendiconto.Controls.Add(this.txtsaldoaccordato);
			this.grpSpeseRendiconto.Controls.Add(this.btnDeleteSpesaSaldo);
			this.grpSpeseRendiconto.Controls.Add(this.txtsaldorichiesto);
			this.grpSpeseRendiconto.Controls.Add(this.label33);
			this.grpSpeseRendiconto.Controls.Add(this.btnEditSpesaSaldo);
			this.grpSpeseRendiconto.Controls.Add(this.label36);
			this.grpSpeseRendiconto.Controls.Add(this.dgrSpeseSaldo);
			this.grpSpeseRendiconto.Controls.Add(this.btnInsertSpesaSaldo);
			this.grpSpeseRendiconto.Location = new System.Drawing.Point(712, 342);
			this.grpSpeseRendiconto.Name = "grpSpeseRendiconto";
			this.grpSpeseRendiconto.Size = new System.Drawing.Size(282, 216);
			this.grpSpeseRendiconto.TabIndex = 407;
			this.grpSpeseRendiconto.TabStop = false;
			this.grpSpeseRendiconto.Tag = "";
			this.grpSpeseRendiconto.Text = "Rendiconto Spese";
			// 
			// txtsaldoaccordato
			// 
			this.txtsaldoaccordato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtsaldoaccordato.Location = new System.Drawing.Point(155, 191);
			this.txtsaldoaccordato.Name = "txtsaldoaccordato";
			this.txtsaldoaccordato.ReadOnly = true;
			this.txtsaldoaccordato.Size = new System.Drawing.Size(104, 20);
			this.txtsaldoaccordato.TabIndex = 29;
			this.txtsaldoaccordato.TabStop = false;
			this.txtsaldoaccordato.Tag = "";
			this.txtsaldoaccordato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnDeleteSpesaSaldo
			// 
			this.btnDeleteSpesaSaldo.Location = new System.Drawing.Point(184, 16);
			this.btnDeleteSpesaSaldo.Name = "btnDeleteSpesaSaldo";
			this.btnDeleteSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteSpesaSaldo.TabIndex = 27;
			this.btnDeleteSpesaSaldo.Tag = "delete";
			this.btnDeleteSpesaSaldo.Text = "Elimina";
			// 
			// txtsaldorichiesto
			// 
			this.txtsaldorichiesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtsaldorichiesto.Location = new System.Drawing.Point(155, 164);
			this.txtsaldorichiesto.Name = "txtsaldorichiesto";
			this.txtsaldorichiesto.ReadOnly = true;
			this.txtsaldorichiesto.Size = new System.Drawing.Size(104, 20);
			this.txtsaldorichiesto.TabIndex = 28;
			this.txtsaldorichiesto.TabStop = false;
			this.txtsaldorichiesto.Tag = "";
			this.txtsaldorichiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(6, 194);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(119, 13);
			this.label33.TabIndex = 313;
			this.label33.Text = "Totale Saldo Accordato";
			// 
			// btnEditSpesaSaldo
			// 
			this.btnEditSpesaSaldo.Location = new System.Drawing.Point(96, 16);
			this.btnEditSpesaSaldo.Name = "btnEditSpesaSaldo";
			this.btnEditSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnEditSpesaSaldo.TabIndex = 26;
			this.btnEditSpesaSaldo.Tag = "edit.webbalance";
			this.btnEditSpesaSaldo.Text = "Modifica";
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(6, 175);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(114, 13);
			this.label36.TabIndex = 314;
			this.label36.Text = "Totale Saldo Richiesto";
			// 
			// dgrSpeseSaldo
			// 
			this.dgrSpeseSaldo.DataMember = "";
			this.dgrSpeseSaldo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSpeseSaldo.Location = new System.Drawing.Point(8, 48);
			this.dgrSpeseSaldo.Name = "dgrSpeseSaldo";
			this.dgrSpeseSaldo.ReadOnly = true;
			this.dgrSpeseSaldo.Size = new System.Drawing.Size(251, 107);
			this.dgrSpeseSaldo.TabIndex = 408;
			this.dgrSpeseSaldo.Tag = "itinerationrefund_balance.webbalance.webbalance";
			// 
			// btnInsertSpesaSaldo
			// 
			this.btnInsertSpesaSaldo.Location = new System.Drawing.Point(8, 16);
			this.btnInsertSpesaSaldo.Name = "btnInsertSpesaSaldo";
			this.btnInsertSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnInsertSpesaSaldo.TabIndex = 25;
			this.btnInsertSpesaSaldo.Tag = "insert.webbalance";
			this.btnInsertSpesaSaldo.Text = "Inserisci";
			// 
			// grpSpese
			// 
			this.grpSpese.Controls.Add(this.label32);
			this.grpSpese.Controls.Add(this.txtanticipoaccordato);
			this.grpSpese.Controls.Add(this.label22);
			this.grpSpese.Controls.Add(this.txtanticiporichiesto);
			this.grpSpese.Controls.Add(this.btnDelSpesa);
			this.grpSpese.Controls.Add(this.btnEditSpesa);
			this.grpSpese.Controls.Add(this.dgrSpeseTappe);
			this.grpSpese.Controls.Add(this.btnInsertSpesa);
			this.grpSpese.Location = new System.Drawing.Point(707, 128);
			this.grpSpese.Name = "grpSpese";
			this.grpSpese.Size = new System.Drawing.Size(287, 205);
			this.grpSpese.TabIndex = 409;
			this.grpSpese.TabStop = false;
			this.grpSpese.Tag = "";
			this.grpSpese.Text = "Spese Preventivate ed eventuale Anticipo Richiesto";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(11, 168);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(177, 13);
			this.label32.TabIndex = 315;
			this.label32.Text = "Totale spese accordate per anticipo";
			// 
			// txtanticipoaccordato
			// 
			this.txtanticipoaccordato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtanticipoaccordato.Location = new System.Drawing.Point(194, 164);
			this.txtanticipoaccordato.Name = "txtanticipoaccordato";
			this.txtanticipoaccordato.ReadOnly = true;
			this.txtanticipoaccordato.Size = new System.Drawing.Size(81, 20);
			this.txtanticipoaccordato.TabIndex = 24;
			this.txtanticipoaccordato.TabStop = false;
			this.txtanticipoaccordato.Tag = "";
			this.txtanticipoaccordato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(20, 146);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(168, 13);
			this.label22.TabIndex = 316;
			this.label22.Text = "Totale spese richieste per anticipo";
			// 
			// txtanticiporichiesto
			// 
			this.txtanticiporichiesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtanticiporichiesto.Location = new System.Drawing.Point(194, 138);
			this.txtanticiporichiesto.Name = "txtanticiporichiesto";
			this.txtanticiporichiesto.ReadOnly = true;
			this.txtanticiporichiesto.Size = new System.Drawing.Size(81, 20);
			this.txtanticiporichiesto.TabIndex = 23;
			this.txtanticiporichiesto.TabStop = false;
			this.txtanticiporichiesto.Tag = "";
			this.txtanticiporichiesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnDelSpesa
			// 
			this.btnDelSpesa.Location = new System.Drawing.Point(184, 16);
			this.btnDelSpesa.Name = "btnDelSpesa";
			this.btnDelSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnDelSpesa.TabIndex = 22;
			this.btnDelSpesa.Tag = "delete";
			this.btnDelSpesa.Text = "Elimina";
			// 
			// btnEditSpesa
			// 
			this.btnEditSpesa.Location = new System.Drawing.Point(96, 16);
			this.btnEditSpesa.Name = "btnEditSpesa";
			this.btnEditSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnEditSpesa.TabIndex = 21;
			this.btnEditSpesa.Tag = "edit.webadvance";
			this.btnEditSpesa.Text = "Modifica";
			// 
			// dgrSpeseTappe
			// 
			this.dgrSpeseTappe.DataMember = "";
			this.dgrSpeseTappe.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSpeseTappe.Location = new System.Drawing.Point(8, 48);
			this.dgrSpeseTappe.Name = "dgrSpeseTappe";
			this.dgrSpeseTappe.ReadOnly = true;
			this.dgrSpeseTappe.Size = new System.Drawing.Size(251, 84);
			this.dgrSpeseTappe.TabIndex = 410;
			this.dgrSpeseTappe.Tag = "itinerationrefund_advance.webadvance.webadvance";
			// 
			// btnInsertSpesa
			// 
			this.btnInsertSpesa.Location = new System.Drawing.Point(8, 16);
			this.btnInsertSpesa.Name = "btnInsertSpesa";
			this.btnInsertSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnInsertSpesa.TabIndex = 20;
			this.btnInsertSpesa.Tag = "insert.webadvance";
			this.btnInsertSpesa.Text = "Inserisci";
			// 
			// grpTappe
			// 
			this.grpTappe.Controls.Add(this.btnDelTappa);
			this.grpTappe.Controls.Add(this.btnEditTappa);
			this.grpTappe.Controls.Add(this.dgrTappe);
			this.grpTappe.Controls.Add(this.btnInsertTappa);
			this.grpTappe.Location = new System.Drawing.Point(430, 188);
			this.grpTappe.Name = "grpTappe";
			this.grpTappe.Size = new System.Drawing.Size(268, 145);
			this.grpTappe.TabIndex = 411;
			this.grpTappe.TabStop = false;
			this.grpTappe.Text = "Tappe";
			// 
			// btnDelTappa
			// 
			this.btnDelTappa.Location = new System.Drawing.Point(184, 16);
			this.btnDelTappa.Name = "btnDelTappa";
			this.btnDelTappa.Size = new System.Drawing.Size(75, 23);
			this.btnDelTappa.TabIndex = 19;
			this.btnDelTappa.Tag = "delete";
			this.btnDelTappa.Text = "Cancella";
			// 
			// btnEditTappa
			// 
			this.btnEditTappa.Location = new System.Drawing.Point(96, 16);
			this.btnEditTappa.Name = "btnEditTappa";
			this.btnEditTappa.Size = new System.Drawing.Size(75, 23);
			this.btnEditTappa.TabIndex = 18;
			this.btnEditTappa.Tag = "edit.webdefault";
			this.btnEditTappa.Text = "Modifica";
			// 
			// dgrTappe
			// 
			this.dgrTappe.AllowNavigation = false;
			this.dgrTappe.DataMember = "";
			this.dgrTappe.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrTappe.Location = new System.Drawing.Point(8, 48);
			this.dgrTappe.Name = "dgrTappe";
			this.dgrTappe.Size = new System.Drawing.Size(249, 87);
			this.dgrTappe.TabIndex = 412;
			this.dgrTappe.Tag = "itinerationlap.webdefault.webdefault";
			// 
			// btnInsertTappa
			// 
			this.btnInsertTappa.Location = new System.Drawing.Point(8, 16);
			this.btnInsertTappa.Name = "btnInsertTappa";
			this.btnInsertTappa.Size = new System.Drawing.Size(75, 23);
			this.btnInsertTappa.TabIndex = 17;
			this.btnInsertTappa.Tag = "insert.webdefault";
			this.btnInsertTappa.Text = "Inserisci";
			// 
			// grpAllegati
			// 
			this.grpAllegati.Controls.Add(this.btnInsAtt);
			this.grpAllegati.Controls.Add(this.btnEditAtt);
			this.grpAllegati.Controls.Add(this.btnDelAtt);
			this.grpAllegati.Controls.Add(this.dataGrid3);
			this.grpAllegati.Location = new System.Drawing.Point(163, 180);
			this.grpAllegati.Name = "grpAllegati";
			this.grpAllegati.Size = new System.Drawing.Size(249, 160);
			this.grpAllegati.TabIndex = 413;
			this.grpAllegati.TabStop = false;
			this.grpAllegati.Text = "Allegati";
			// 
			// myTip
			// 
			this.myTip.AutomaticDelay = 30;
			this.myTip.AutoPopDelay = 30000;
			this.myTip.InitialDelay = 30;
			this.myTip.ReshowDelay = 6;
			// 
			// grpIndKm
			// 
			this.grpIndKm.Controls.Add(this.grpIndMezzoProprio);
			this.grpIndKm.Controls.Add(this.txtClause);
			this.grpIndKm.Controls.Add(this.chkClauseMezzoProprio);
			this.grpIndKm.Controls.Add(this.txtCausaleMezzoProprio);
			this.grpIndKm.Controls.Add(this.label34);
			this.grpIndKm.Controls.Add(this.txtDatiMezzoProprio);
			this.grpIndKm.Controls.Add(this.label38);
			this.grpIndKm.Location = new System.Drawing.Point(8, 342);
			this.grpIndKm.Name = "grpIndKm";
			this.grpIndKm.Size = new System.Drawing.Size(468, 158);
			this.grpIndKm.TabIndex = 414;
			this.grpIndKm.TabStop = false;
			// 
			// lblAppunti
			// 
			this.lblAppunti.AutoSize = true;
			this.lblAppunti.Location = new System.Drawing.Point(728, 15);
			this.lblAppunti.Name = "lblAppunti";
			this.lblAppunti.Size = new System.Drawing.Size(125, 13);
			this.lblAppunti.TabIndex = 317;
			this.lblAppunti.Text = "Appunti per il Pagamento";
			this.lblAppunti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMissione
			// 
			this.lblMissione.AutoSize = true;
			this.lblMissione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMissione.Location = new System.Drawing.Point(63, 59);
			this.lblMissione.Name = "lblMissione";
			this.lblMissione.Size = new System.Drawing.Size(48, 13);
			this.lblMissione.TabIndex = 318;
			this.lblMissione.Text = "Missione";
			this.lblMissione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblStato
			// 
			this.lblStato.AutoSize = true;
			this.lblStato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStato.Location = new System.Drawing.Point(262, 83);
			this.lblStato.Name = "lblStato";
			this.lblStato.Size = new System.Drawing.Size(32, 13);
			this.lblStato.TabIndex = 319;
			this.lblStato.Text = "Stato";
			this.lblStato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDateMissione
			// 
			this.lblDateMissione.AutoSize = true;
			this.lblDateMissione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDateMissione.Location = new System.Drawing.Point(502, 61);
			this.lblDateMissione.Name = "lblDateMissione";
			this.lblDateMissione.Size = new System.Drawing.Size(99, 13);
			this.lblDateMissione.TabIndex = 320;
			this.lblDateMissione.Text = "Date della Missione";
			this.lblDateMissione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblModelloAutorizzativo
			// 
			this.lblModelloAutorizzativo.AutoSize = true;
			this.lblModelloAutorizzativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblModelloAutorizzativo.Location = new System.Drawing.Point(15, 138);
			this.lblModelloAutorizzativo.Name = "lblModelloAutorizzativo";
			this.lblModelloAutorizzativo.Size = new System.Drawing.Size(107, 13);
			this.lblModelloAutorizzativo.TabIndex = 321;
			this.lblModelloAutorizzativo.Text = "Modello Autorizzativo";
			this.lblModelloAutorizzativo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAutorizzazioni
			// 
			this.lblAutorizzazioni.AutoSize = true;
			this.lblAutorizzazioni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAutorizzazioni.Location = new System.Drawing.Point(15, 188);
			this.lblAutorizzazioni.Name = "lblAutorizzazioni";
			this.lblAutorizzazioni.Size = new System.Drawing.Size(71, 13);
			this.lblAutorizzazioni.TabIndex = 322;
			this.lblAutorizzazioni.Text = "Autorizzazioni";
			this.lblAutorizzazioni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAvvisi
			// 
			this.lblAvvisi.AutoSize = true;
			this.lblAvvisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAvvisi.Location = new System.Drawing.Point(492, 416);
			this.lblAvvisi.Name = "lblAvvisi";
			this.lblAvvisi.Size = new System.Drawing.Size(120, 13);
			this.lblAvvisi.TabIndex = 323;
			this.lblAvvisi.Text = "Avvisi per il Richiedente";
			this.lblAvvisi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblAdditionalAnnotation
			// 
			this.lblAdditionalAnnotation.AutoSize = true;
			this.lblAdditionalAnnotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAdditionalAnnotation.Location = new System.Drawing.Point(492, 342);
			this.lblAdditionalAnnotation.Name = "lblAdditionalAnnotation";
			this.lblAdditionalAnnotation.Size = new System.Drawing.Size(170, 13);
			this.lblAdditionalAnnotation.TabIndex = 324;
			this.lblAdditionalAnnotation.Text = "Richieste aggiuntive sulla missione";
			this.lblAdditionalAnnotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_itineration_webdefault
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1007, 620);
			this.Controls.Add(this.txtadditionalannotation);
			this.Controls.Add(this.lblAdditionalAnnotation);
			this.Controls.Add(this.txtwebwarn);
			this.Controls.Add(this.lblAvvisi);
			this.Controls.Add(this.dgrAutorizzazioni);
			this.Controls.Add(this.lblAutorizzazioni);
			this.Controls.Add(this.cmbAuthModel);
			this.Controls.Add(this.grpAllegati);
			this.Controls.Add(this.txtImportoMax);
			this.Controls.Add(this.txtLunghezzaMax);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.lblModelloAutorizzativo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.grpSpeseRendiconto);
			this.Controls.Add(this.lblDateMissione);
			this.Controls.Add(this.txtDataFine);
			this.Controls.Add(this.cmbStatus);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtDataInizio);
			this.Controls.Add(this.lblStato);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblMissione);
            //this.Controls.Add(this.txtInfos);
            this.Controls.Add(this.txtEsercmissione);
			this.Controls.Add(this.txtapplierannotation);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblAppunti);
			this.Controls.Add(this.txtNummissione);
			this.Controls.Add(this.grpIndKm);
			this.Controls.Add(this.gboxUPB);
			this.Controls.Add(this.grpSpese);
			this.Controls.Add(this.btnitinerationhistory);
			this.Controls.Add(this.grpTappe);
			this.Controls.Add(this.btnStampaMissione);
			this.Controls.Add(this.gboxAction);
			this.Controls.Add(this.btnStatus);
			this.Controls.Add(this.grpIncaricato);
            this.Controls.Add(this.grpDelegatoMissione);
            this.Controls.Add(this.gboxResponsabile);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblLocalitaPrincipale);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.txtLocation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_itineration_webdefault";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmmissione";
			this.grpIndMezzoProprio.ResumeLayout(false);
			this.grpIndMezzoProprio.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxAction.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpDelegatoMissione.ResumeLayout(false);
			this.grpDelegatoMissione.PerformLayout();
			this.grpIncaricato.ResumeLayout(false);
			this.grpIncaricato.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrAutorizzazioni)).EndInit();
			this.grpSpeseRendiconto.ResumeLayout(false);
			this.grpSpeseRendiconto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseSaldo)).EndInit();
			this.grpSpese.ResumeLayout(false);
			this.grpSpese.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseTappe)).EndInit();
			this.grpTappe.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrTappe)).EndInit();
			this.grpAllegati.ResumeLayout(false);
			this.grpIndKm.ResumeLayout(false);
			this.grpIndKm.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        QueryHelper QHS;
        CQueryHelper QHC;
        IDataAccess Conn;
        DataAccess conn;
        private IFormController controller;
        private IMetaDataDispatcher dispatcher;
        private ISecurity security;
        DateTime dataoggi;
        bool DoSendMail = false;
        bool IsManager = false;
        bool km_visibili = true;

        public void MetaData_AfterLink()
        {
            Meta = this.getInstance<IMetaData>();
            Conn = this.getInstance<IDataAccess>();
            conn = MetaData.GetConnection(this);
            controller = this.getInstance<IFormController>();
            dispatcher = this.getInstance<IMetaDataDispatcher>();

            security = this.getInstance<ISecurity>();
            GetData.CacheTable(DS.position);

            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            delegatoMissioneAbilitato = LeggiConfigDelegatoMissione();
            if (!delegatoMissioneAbilitato)
            {
                grpDelegatoMissione.Visible = false;
                txtDelegatoMissione.Visible = false;
                grpDelegatoMissione.Tag = "";
                txtDelegatoMissione.Tag = "";
            }
            else
            {
                grpDelegatoMissione.Visible = true;
                txtDelegatoMissione.Visible = true;
            }

            Meta.defaultListType = "weblista";

            if (controller.InsertMode || controller.EditMode)
                AggiornaSoloInformazioni();

            // Es: C:\Program Files (x86)\Tempo Srl\Easy\bin\config\config_missioni_unibas_easy.xml
            // dove in config_missioni_unibas_easy
            // "config" è fisso
            // "missioni" è l'app
            // "unibas_easy" è il DB
            if (sysConn == null)
                sysConn = GetVarsWeb.GetSystemDataAccess("missioni", conn.sqlConnection.Database);

            if (sysConn != null)
            {
                string filter = QHS.AppAnd(QHS.CmpEq("username", conn.externalUser), QHS.AppOr(QHS.CmpEq("userkind", 3), QHS.CmpEq("userkind", 4), QHS.CmpEq("userkind", 5)));

                //MetaFactory.factory.getSingleton<IMessageShower>().Show($"filter: {filter}");

                DataTable virtualuser = sysConn.RUN_SELECT("virtualuser", "*", "userkind desc", filter, null, false);
                if (virtualuser != null && virtualuser.Rows.Count != 0)
                {
                    string username = virtualuser.Rows[0]["username"].ToString();

                    //MetaFactory.factory.getSingleton<IMessageShower>().Show($"username: {username}");

                    string user = virtualuser.Rows[0]["sys_user"].ToString();
                    string forename = virtualuser.Rows[0]["forename"].ToString();
                    string lastname = virtualuser.Rows[0]["surname"].ToString();
                    string email = virtualuser.Rows[0]["email"].ToString();
                    string vcf = virtualuser.Rows[0]["cf"].ToString();

                    // MetaFactory.factory.getSingleton<IMessageShower>().Show($"Info: {user}, {forename} {lastname}, {email}, {vcf}");

                    Conn.SetUsr("HasVirtualUser", "S");
                    // Controllare se è anche un responsabile 
                    // Vediamo se esiste un manager il cui login="username" se si
                    // assegnamo le due variabili di responsabile come nel caso "2"
                    filter = QHS.CmpEq("userweb", username);

                    // MetaFactory.factory.getSingleton<IMessageShower>().Show($"filter: {filter}");

                    DataTable manager = Conn.RUN_SELECT("manager", "*", null, filter, null, false);
                    if (manager != null && manager.Rows.Count != 0)
                    {
                        Responsabile = manager.Rows[0]["title"].ToString();
                        CodiceResponsabile = manager.Rows[0]["idman"];

                        // MetaFactory.factory.getSingleton<IMessageShower>().Show($"Info: {Responsabile}, {CodiceResponsabile}");
                    }

                    EasySecurity sec = conn.Security as EasySecurity;

                    sec.SetSys("user", user);
                    // sec.SetSys("usergrouplist", null);  // "'ORGANIGARMMA'");//SetUsr
                    // sec.CalculateGroupList();
                    // sec.RecalcUserEnvironment();
                    // sec.ReadAllGroupOperations();
                    sec.SetUsr("forename", forename);
                    sec.SetUsr("surname", lastname);
                    sec.SetUsr("email", email);
                    sec.SetUsr("cf", vcf);
                }
            }

            GetData.CacheTable(DS.tax);

            HelpForm.SetDenyNull(DS.itineration.Columns["active"], true);
            HelpForm.SetDenyNull(DS.itineration.Columns["completed"], true);

            HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["stoptime"], "g");
            HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["starttime"], "g");
            string currsymbol = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;

            string filteresercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);

            string filterEpOperationSF = QHS.CmpEq("idepoperation", "missioni");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "missioni");

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "missioni_deb");

            DS.accmotiveapplied_debit.ExtendedProperties[ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[ExtraParams] = filterEpOperationDeb;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");


            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");



            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, filteresercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
            }

            DateTime defaultauthdate = DateTime.Now;

            DataTable webconfig = Conn.RUN_SELECT("web_config", "*", null, null, null, false);
            DataRow rwebconf = webconfig.Rows[0];
            bool showitinerationlap = (rwebconf["showitinerationlap"].ToString().ToUpper() == "S");
            bool showinerationep = (rwebconf["showinerationep"].ToString().ToUpper() == "S");
            bool askitinerationclause = (rwebconf["askitinerationclause"].ToString().ToUpper() == "S");
            km_visibili = (rwebconf["km_visibili"].ToString().ToUpper() == "S");
            string itinerationclause = (rwebconf["itinerationclause"].ToString());

            if (showitinerationlap == false)
            {
                //DisableTappe();

            }

            if (showinerationep == false)
            {
                gboxUPB.Enabled = false;
            }

            if (askitinerationclause == false)
            {
                label34.Visible = false;
                chkClauseMezzoProprio.Visible = false;
                txtClause.Visible = false;
                chkClauseMezzoProprio.Visible = false;
            }
            else
            {
                txtClause.Text = itinerationclause;
            }

            MetaData.SetDefault(DS.itineration, "iditinerationstatus", 1);
            MetaData.SetDefault(DS.itineration, "completed", "N");
            MetaData.SetDefault(DS.itineration, "flagweb", "S");
            MetaData.SetDefault(DS.itineration, "authorizationdate", defaultauthdate);
            DS.itinerationstatus.ExtendedProperties["sort_by"] = "iditinerationstatus";

            DataAccess.SetTableForReading(DS.itinerationrefund_advance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefund_balance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_advance, "itinerationrefundkind");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_balance, "itinerationrefundkind");
            DataAccess.SetTableForReading(DS.itinerationrefundkindgroup_advance, "itinerationrefundkindgroup");
            DataAccess.SetTableForReading(DS.itinerationrefundkindgroup_balance, "itinerationrefundkindgroup");
            DataAccess.SetTableForReading(DS.registry_delegato, "registry");
            QueryCreator.SetTableForPosting(DS.itinerationrefund_advance, "itinerationrefund");
            QueryCreator.SetTableForPosting(DS.itinerationrefund_balance, "itinerationrefund");
            GetData.SetStaticFilter(DS.itinerationrefund_advance, QHS.CmpEq("flagadvancebalance", "A"));
            GetData.SetStaticFilter(DS.itinerationrefund_balance, QHS.CmpEq("flagadvancebalance", "S"));

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");
            DataAccess.SetTableForReading(DS.sortingview1, "sortingview");

            setdataoggi();
            object idreg = var["idreg"];
            string cf = CF_User();
            if (cf != null && idreg == null)
            {
                DataTable T = Conn.RUN_SELECT("registry", "*", null,
                    QHS.AppAnd(new string[]{QHS.CmpEq("cf", cf), QHS.CmpEq("active","S"), //QHS.CmpEq("human","S"),
                      " (idreg IN(SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = 'S') ))  " }),
                    null, true);
                if (T.Rows.Count == 1)
                {
                    var["idreg"] = idreg = T.Rows[0]["idreg"];
                    var["title"] = T.Rows[0]["title"];
                    MetaData.SetDefault(DS.itineration, "idreg", idreg);
                }

            }

            IsManager = (CodiceResponsabile != null ? true : false);
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(CodiceResponsabile);

            if (IsManager)
            {
                if (CodiceResponsabile != null)
                {
                    DS.itineration.Columns["idman"].DefaultValue = idman;
                    //cmbresponsabile.SelectedValue = idman.ToString();
                    //EnableDisableControls(cmbresponsabile, true);
                }
            }

            SetMainVisibility();

            HelpForm.SetDenyNull(DS.itineration.Columns["clause_accepted"], true);

            //GetData.MarkSkipSecurity(DS.manager);
            btnStampaMissione.Enabled = false;
            btnStatus.Tag = "do_command.chstatus";
        }

        public void MetaData_AfterClear()
        {
            MetaData.SetDefault(DS.itineration, "iditinerationstatus", 1);
            ClearPosGiuridica();
            ImpostaTageFiltriUPB(DBNull.Value);
            cmbStatus.Enabled = true;

            txtEsercmissione.Text = Conn.GetSys("esercizio").ToString();
            txtNummissione.ReadOnly = false;
            DataColumn C = DS.itineration.Columns["nitineration"];
            RowChange.ClearAutoIncrement(C);
            RowChange.ClearCustomAutoIncrement(C);
            txtEsercmissione.ReadOnly = false;
            LockUnLockControls(false);
            btnStatus.Visible = false;
            EnableDisableControls(txtEsercmissione, false);
            EnableDisableControls(txtNummissione, false);

            EnableDisableControls(txtEurTotMezzoProprio, true);

            EnableDisableControls(txtsaldoaccordato, true);
            EnableDisableControls(txtsaldorichiesto, true);
            EnableDisableControls(txtanticipoaccordato, true);
            EnableDisableControls(txtanticiporichiesto, true);
            EnableDisableControls(txtwebwarn, true);
            EnableDisableControls(btnitinerationhistory, false);

            EnableDisableControls(txtapplierannotation, false);

            cmbAuthModel.Enabled = true;

            AggiornaTotaliErogati();

            ImpostaIncaricatoEDelegato();
            // In ricerca il delegato non deve mai fungere da filtro (verrebbe cercato itinerationview.delegato)
            if (delegatoMissioneAbilitato)
                txtDelegatoMissione.Text = "";

            if (Meta.editType == "myteamnew02")
            {
                txtResponsabile.Enabled = false;
                btnResponsabile.Enabled = false;
            }
            
            if (Meta.editType == "autolistnew02" && var["listed"] == null)
            {
                var["listed"] = "S";
                Meta.DoMainCommand("maindosearch.weblista");
            
            }
            
            if (Meta.editType == "autoinsertnew02" && var["inserted"] == null)
            {
                var["inserted"] = "S";
                Meta.DoMainCommand("maininsert");
            }
            dgrSpeseSaldo.Visible = true;
            GetData.CacheTable(DS.authmodel);
            btnStampaMissione.Enabled = false;
        }

        public void MetaData_AfterFill()
        {
            EnableDisableControls(btnitinerationhistory, true);
            IsManager = (CodiceResponsabile != null ? true : false);
            int idman = 0;
            idman = CfgFn.GetNoNullInt32(CodiceResponsabile);
            cmbAuthModel.Enabled = true;
            ImpostaTageFiltriUPB(DBNull.Value);
            if (controller.EditMode)
                if (!CanChangeAuthModel())
                    cmbAuthModel.Enabled = false;

            cmbStatus.Enabled = false;
            if ((!controller.IsEmpty) && (controller.EditMode))
            {
                btnStampaMissione.Enabled = true;
            }
            else
            {
                btnStampaMissione.Enabled = false;
            }
            if (controller.EditMode)
            {
                ManageStatus();
            }

            if (DS.itinerationrefund_advance.Rows.Count > 0 || DS.itinerationrefund_balance.Rows.Count > 0)
            {
                cmbAuthModel.Enabled = false;
            }


            DataRow Curr = DS.itineration.Rows[0];
            txtsaldoaccordato.ReadOnly = true;
            txtsaldorichiesto.ReadOnly = true;
            txtanticipoaccordato.ReadOnly = true;

            if (controller.InsertMode)
            {
                Meta.canCancel = true;
                Meta.canSave = true;
                EnableDisableControls(txtEsercmissione, true);
                EnableDisableControls(txtNummissione, true);
                EnableDisableControls(btnStatus, true);
                EnableDisableControls(txtsaldoaccordato, true);
                EnableDisableControls(txtsaldorichiesto, true);
                EnableDisableControls(txtanticipoaccordato, true);
                EnableDisableControls(txtapplierannotation, false);

                // disabilito l'inserimento delle tappe

                //if (controller.firstFillForThisRow)
                //{
                //    txtInfos.Text += "HIDE INS TAPPA\r\n";
                //    EnableDisableControls(btnInsertTappa, true);
                //    EnableDisableControls(btnEditTappa, true);
                //    EnableDisableControls(btnDelTappa, true);
                //}

                QHS = Conn.GetQueryHelper();
                string filter;
                filter = QHS.AppAnd(QHS.CmpEq("webdefault", "S"), QHS.CmpEq("itinerationvisible", "S"), QHS.CmpEq("active", "S"));

                DataTable DT = Conn.RUN_SELECT("service", "*", null, filter, null, false);
                if (DT != null && DT.Rows.Count != 0)
                    Curr["idser"] = DT.Rows[0]["idser"];
                btnStampaMissione.Visible = false;
            }

            if (controller.EditMode && controller.firstFillForThisRow)
                AggiornaSoloInformazioni();

            if (controller.EditMode)
                AggiornaTotaliErogati();

            setDateInizioFineSpesa();
            CheckAnticipiReadOnly();
            EnableDisableRefund();

            SetMainVisibility();

            calcolatotaliriepilogo();

            RicalcolaRimborsiKilometrici();
            CalcolaTotAnticipo();

            if (controller.InsertMode)
            {
                IsManager = string.IsNullOrWhiteSpace(CodiceResponsabile.ToString()) ? false : true;
                object idmanNew = CodiceResponsabile;
                if (IsManager)
                {
                    DS.itineration.Rows[0]["idman"] = idmanNew;
                    txtResponsabile.Text = Responsabile;
                    btnResponsabile.Enabled = true;
                }
            }

            if ((!controller.IsEmpty) && (controller.firstFillForThisRow))
            {
                grpIncaricato.Tag = AutoChooseIncaricatoTag;

                if (delegatoMissioneAbilitato)
                {
                    grpDelegatoMissione.Tag = AutoChooseDelegatoTag;
                }
            }

            ImpostaIncaricatoEDelegato();

            if (Meta.editType == "myteamnew02")
                gboxResponsabile.Enabled = false;
        }

        const string AutoChooseIncaricatoTag = "AutoChoose.txtIncaricato.default.((active = 'S')  AND " +
                                    " (idreg IN (SELECT idreg FROM registrylegalstatus where (active = 'S') )) AND " +
                                    " (human = 'S'))";

        const string AutoChooseDelegatoTag = "AutoChoose.txtDelegatoMissione.default.((active = 'S')  AND " +
                                    " (idreg IN (SELECT idreg FROM registrylegalstatus where (active = 'S') )) AND " +
                                    " (human = 'S'))";

        /// <summary>
        /// Imposta incaricato e delegato della missione.
        /// Delegato non abilitato: l'incaricato è l'utente collegato ed è in sola lettura (comportamento storico).
        /// Delegato abilitato: il delegato è sempre modificabile; in inserimento l'incaricato è modificabile
        /// e il delegato viene preimpostato con lo stesso valore dell'incaricato, altrimenti si legge dal db.
        /// </summary>
        void ImpostaIncaricatoEDelegato()
        {
            bool incaricatoDaUtente = var["idreg"] != null && Meta.editType != "myteamnew02";

            if (!delegatoMissioneAbilitato)
            {
                if (incaricatoDaUtente)
                {
                    txtIncaricato.ReadOnly = true;
                    grpIncaricato.Tag = "";
                    txtIncaricato.Text = var["title"].ToString();
                }
                return;
            }

            txtDelegatoMissione.ReadOnly = false;

            if (controller.InsertMode)
            {
                txtIncaricato.ReadOnly = false;
                grpIncaricato.Tag = AutoChooseIncaricatoTag;
                if (incaricatoDaUtente && DS.itineration.Rows.Count > 0)
                {
                    DataRow r = DS.itineration.Rows[0];
                    int idregUtente = CfgFn.GetNoNullInt32(var["idreg"]);
                    string titolo = var["title"].ToString();

                    // Solo al primo riempimento della riga: il delegato parte uguale all'incaricato (utente loggato)
                    if (controller.firstFillForThisRow && r["idregdelegato"] == DBNull.Value)
                        r["idregdelegato"] = var["idreg"];

                    // AfterFill viene richiamato a ogni refresh: il nome dell'utente va rimesso nelle textbox
                    // solo se la chiave nella riga è ancora la sua (l'utente non è in DS.registry, quindi il binding
                    // non lo visualizza), altrimenti resta il nominativo scelto tramite AutoChoose.
                    if (CfgFn.GetNoNullInt32(r["idreg"]) == idregUtente && txtIncaricato.Text.Trim() == "")
                        txtIncaricato.Text = titolo;
                    if (CfgFn.GetNoNullInt32(r["idregdelegato"]) == idregUtente && txtDelegatoMissione.Text.Trim() == "")
                        txtDelegatoMissione.Text = titolo;
                }
            }
            else
            {
                // In modifica incaricato e delegato vengono visualizzati dal binding con i valori letti dal db:
                // non vanno sovrascritti con l'utente loggato, che può essere il delegato e non l'incaricato.
                txtIncaricato.ReadOnly = true;
                grpIncaricato.Tag = "";
            }
        }

        public void MetaData_BeforePost()
        {
            if (DS.itineration.Rows.Count == 0)
                return;

            DataRow CurrRow = DS.itineration.Rows[0];
            if (CurrRow.RowState == DataRowState.Deleted)
            {
                foreach (var A in DS.itinerationattachment.Select())
                {
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
                }
            }

            string filterAttachment = "";
            //Se ci sono spese di anticipo cancellato, prende la chiave.
            if (DS.itinerationrefund_advance.Rows.Count > 0)
            {
                foreach (DataRow A in DS.itinerationrefund_advance.Rows)
                {
                    if (A.RowState == DataRowState.Detached || A.RowState == DataRowState.Deleted)
                    {
                        filterAttachment = QHS.DoPar(QHS.AppOr(filterAttachment, QHS.CmpKey(A)));
                    }
                }
            }
            //Se ci sono spese a rendiconto cancellate, prende la chiave.
            if (DS.itinerationrefund_balance.Rows.Count > 0)
            {
                foreach (DataRow A in DS.itinerationrefund_balance.Rows)
                {
                    if (A.RowState == DataRowState.Detached || A.RowState == DataRowState.Deleted)
                    {
                        filterAttachment = QHS.DoPar(QHS.AppOr(filterAttachment, QHS.CmpKey(A)));
                    }
                }
            }
            //Se il filtro è stato valorizzato vuol dire che alcune spese sono in cancellazione, quindi calcella gli allegati ad esse associati.
            if ((filterAttachment != "") && DS.itinerationrefundattachment.Rows.Count > 0)
            {
                foreach (var Ritinerationrefundattachment in DS.itinerationrefundattachment.Select(filterAttachment))
                {
                    if (Ritinerationrefundattachment.RowState != DataRowState.Deleted)
                        Ritinerationrefundattachment.Delete();
                }
            }
            //Se il filtro non è stato valorizzato vuol dire che alcune spese sono in cancellazione, quindi calcella gli allegati ad esse associati.
            foreach (var RAtt in DS.itinerationrefundattachment.Select())
            {
                filterAttachment = QHS.AppAnd(QHC.CmpEq("iditineration", RAtt["iditineration"]), QHC.CmpEq("nrefund", RAtt["nrefund"]));
                if ((DS.itinerationrefund_balance.Select(filterAttachment).Length == 0) && (DS.itinerationrefund_advance.Select(filterAttachment).Length == 0))
                    if (RAtt.RowState != DataRowState.Deleted)
                        RAtt.Delete();
            }

            if (CurrRow.RowState != DataRowState.Deleted)
            {
                ConvertAttachmentsToPdfA();

                int CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["iditinerationstatus"]);
                int OriginalStatus;
                if (!controller.InsertMode)
                    OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["iditinerationstatus", DataRowVersion.Original]);
                else
                    OriginalStatus = CurrentStatus;

                bool statoCambiato = CurrentStatus != OriginalStatus;

                // Con delegato abilitato, se chi salva (utente loggato) non è l'incaricato della missione
                // la mail parte anche al passaggio in stato 1 (Bozza), per avvisare l'incaricato
                bool utenteDiversoDaIncaricato = delegatoMissioneAbilitato
                    && var["idreg"] != null
                    && CfgFn.GetNoNullInt32(var["idreg"]) != CfgFn.GetNoNullInt32(CurrRow["idreg"]);

                if (statoCambiato && (CurrentStatus == 2 || (CurrentStatus == 1 && utenteDiversoDaIncaricato)))
                    DoSendMail = true;
                else
                    DoSendMail = false;

                // Nuova missione in Bozza: avvisare incaricato e delegato se diversi da chi la inserisce
                DoSendMailNuovaMissione = delegatoMissioneAbilitato && CurrRow.RowState == DataRowState.Added && CurrentStatus == 1;

                // Missione esistente (salva o ufficializza): avvisare vecchio e nuovo delegato se il delegato è cambiato
                DoSendMailCambioDelegato = false;
                VecchioDelegato = DBNull.Value;
                if (delegatoMissioneAbilitato && CurrRow.RowState == DataRowState.Modified)
                {
                    VecchioDelegato = CurrRow["idregdelegato", DataRowVersion.Original];
                    DoSendMailCambioDelegato = CfgFn.GetNoNullInt32(VecchioDelegato) != CfgFn.GetNoNullInt32(CurrRow["idregdelegato"]);
                }

                // Messaggio da mostrare a salvataggio avvenuto: creazione, ufficializzazione o salvataggio semplice.
                // Gli altri cambi di stato (Invia richiesta, Accetta, Annulla, ...) non mostrano messaggi.
                if (CurrRow.RowState == DataRowState.Added)
                    MessaggioDopoSalvataggio = "Missione creata";
                else if (ufficializzazioneInCorso)
                    MessaggioDopoSalvataggio = "Missione ufficializzata";
                else if (!statoCambiato)
                    MessaggioDopoSalvataggio = "Missione salvata";
                else
                    MessaggioDopoSalvataggio = null;
            }
            else
            {
                DoSendMailNuovaMissione = false;
                DoSendMailCambioDelegato = false;
                MessaggioDopoSalvataggio = null;
            }
        }

        bool ufficializzazioneInCorso = false;
        string MessaggioDopoSalvataggio = null;
        bool DoSendMailNuovaMissione = false;
        bool DoSendMailCambioDelegato = false;
        object VecchioDelegato = DBNull.Value;

        /// <summary>
        /// Nominativo dell'utente collegato, usato nelle mail di avviso
        /// </summary>
        string GetNomeUtenteCollegato()
        {
            if (var["title"] != null && var["title"].ToString().Trim() != "")
                return var["title"].ToString().Trim();
            string nome = ((Conn.GetUsr("forename") ?? "").ToString() + " " + (Conn.GetUsr("surname") ?? "").ToString()).Trim();
            if (nome != "")
                return nome;
            return (Conn.GetSys("user") ?? "").ToString();
        }

        public void MetaData_AfterActivation()
        {
            DirectAuth = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                   "itineration_directauth").ToString().ToUpper() == "S";
        }

        public void MetaData_AfterPost()
        {
            if (DS.itineration.Rows.Count == 0)
                return;

            DataRow CurrRow = DS.itineration.Rows[0];
            string errormsg = "";

            if (MessaggioDopoSalvataggio != null)
            {
                show(MessaggioDopoSalvataggio);
                MessaggioDopoSalvataggio = null;
            }

            if (DoSendMail)
            {
                try
                {
                    errormsg = MissFun.WebSendMails(Conn as DataAccess, CurrRow);
                    if (errormsg.Trim() != "")
                        show(errormsg, "Errore");
                }
                catch
                {
                    show("Errore di invio mail", "Errore");
                }

                DoSendMail = false;
            }

            if (DoSendMailNuovaMissione)
            {
                try
                {
                    errormsg = MissFun.WebSendMailsNuovaMissione(Conn as DataAccess, CurrRow, var["idreg"], GetNomeUtenteCollegato());
                    if (errormsg.Trim() != "")
                        show(errormsg, "Errore");
                }
                catch
                {
                    show("Errore di invio mail", "Errore");
                }

                DoSendMailNuovaMissione = false;
            }

            if (DoSendMailCambioDelegato)
            {
                try
                {
                    errormsg = MissFun.WebSendMailsCambioDelegato(Conn as DataAccess, CurrRow, VecchioDelegato, CurrRow["idregdelegato"]);
                    if (errormsg.Trim() != "")
                        show(errormsg, "Errore");
                }
                catch
                {
                    show("Errore di invio mail", "Errore");
                }

                DoSendMailCambioDelegato = false;
                VecchioDelegato = DBNull.Value;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            //txtInfos.Text += $"AfterRowSelect {T.TableName}\r\n";
            if (T.TableName == "registry")
            {
                ImpostaPosGiuridica(false, false); // ClearPosGiuridica();
            }

            if (T.TableName == "legalstatuscontract")
            {
                DataTable SelClass;
                QHS = Conn.GetQueryHelper();
                DataRow Curr = DS.itineration.Rows[0];

                object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
                object datafine = Curr["stop"];
                object codicecreddeb = Curr["idreg"];

                DataRow RcurrPosGiuridica = R;
                SelClass = Conn.RUN_SELECT("legalstatuscontract",
                            "idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                            null, QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("idregistrylegalstatus", RcurrPosGiuridica["idregistrylegalstatus"]), QHS.CmpEq("active", "S")), null, false);

                DataRow RowClass = SelClass.Rows[0];

                Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];

                object matricula = conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");

                int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
                //////txtClassStip.Text = incomeclass.ToString();
                setPosizioneGiuridica(RowClass["idposition"], RowClass["livello"]);
                //            MyCfg.idposition = RowClass["idposition"];
                MyCfg.matricula = matricula;
                MyCfg.incomeclass = incomeclass;
                MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];


                //Classe attuale
                int classe, maxclassestip;
                classe = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
                maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
                if (classe <= maxclassestip)
                {
                    MyCfg.incomeclass = classe;
                }
                else
                {
                    MyCfg.incomeclass = maxclassestip;
                }


                object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
                    QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
                    "max(idforeigngrouprule)");
                //imposta il gruppo estero
                string filterGE;
                filterGE = QHS.AppAnd(QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                                QHS.CmpEq("idposition", MyCfg.idposition),
                                QHS.NullOrEq("livello", MyCfg.livello),
                                "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");
                SetExtraParameterForDetails();

                return;
            }

            if (T.TableName == "authmodel")
            {
                if (controller.IsEmpty)
                    return;
                if (!controller.DrawStateIsDone)
                    return;
                //DataRow DR = DS.itineration.Rows[0];            
                int idauthmodel = 0;
                if (R != null)
                    idauthmodel = CfgFn.GetNoNullInt32(R["idauthmodel"]);
                if (CanChangeAuthModel())
                    ChangeItinerationAuthAgency(idauthmodel);
            }
        }

        public void setdataoggi()
        {
            object oggi = Conn.DO_SYS_CMD("select getdate()");
            if (oggi == DBNull.Value)
                dataoggi = DateTime.Now;
            else
                dataoggi = (DateTime)oggi;
        }

        private void btnitinerationhistory_Click(object sender, EventArgs e)
        {
            Meta.DoMainCommand("mainsetsearch");
            if (controller.IsEmpty)
            {
                Meta.DoMainCommand("maindosearch.weblista.(iditinerationstatus='6')");
            }
        }

        void LockUnLockControls(bool Lock)
        {
            EnableDisableControls(this, Lock);
            return;
        }

        private void ConvertAttachmentsToPdfA()
        {
            // Recupera la licenza
            string spireLicenseKey = GetSpireLicenseKey();
            PdfAConverter.SetLicense(spireLicenseKey);

            ConvertRows(DS.itinerationattachment);
            ConvertRows(DS.itinerationrefundattachment);
        }

        private void ConvertRows(DataTable table)
        {
            foreach (DataRow row in table.Select())
            {
                try
                {
                    TryConvertRow(row);
                }
                catch (Exception ex)
                {
                    show($"Conversione fallita per '{row["filename"]}': {ex.Message}");
                }
            }
        }

        private void TryConvertRow(DataRow row)
        {
            // Solo righe nuove o modificate
            if (row.RowState != DataRowState.Added && row.RowState != DataRowState.Modified)
                return;

            byte[] data = row["attachment"] as byte[];
            if (data == null || data.Length == 0)
                return;

            // Per righe modificate, salta se l'allegato non è effettivamente cambiato
            if (row.RowState == DataRowState.Modified
                && row.HasVersion(DataRowVersion.Original)
                && ByteArraysEqual(row["attachment", DataRowVersion.Original] as byte[], data))
                return;

            string filename = (row["filename"] as string) ?? string.Empty;
            string ext = Path.GetExtension(filename).ToLowerInvariant();

            if (!PdfAConverter.CanConvertToPdfA(filename))
                return;

            string tempDir = Path.GetTempPath();
            string inputPath = Path.Combine(tempDir, $"att_in_{Guid.NewGuid():N}{ext}");
            string outputPath = Path.Combine(tempDir, $"att_out_{Guid.NewGuid():N}.pdf");

            try
            {
                File.WriteAllBytes(inputPath, data);
                PdfAConverter.ConvertFileToPdfA(inputPath, outputPath);

                row["attachment"] = File.ReadAllBytes(outputPath);
                row["filename"] = Path.GetFileNameWithoutExtension(filename) + ".pdf";
            }
            catch (Exception ex)
            {
                throw new Exception($"Errore nella conversione in PDF/A del file '{filename}': {ex.Message}", ex);
            }
            finally
            {
                TryDeleteFile(inputPath);
                TryDeleteFile(outputPath);
            }
        }

        private bool LeggiConfigDelegatoMissione()
        {
            DataTable conf = conn.RUN_SELECT("app_config", "param", null,
                                     QHS.CmpEq("code", "DELEGATO_MISSIONE"), null, false);
            if (conf == null || conf.Rows.Count == 0) return false;
            return conf.Rows[0]["param"].ToString().Trim().ToUpper() == "S";
        }

        private string GetSpireLicenseKey()
        {
            DataTable conf = conn.RUN_SELECT("app_config", "param", null,
                                     "code = 'SPIRE_PDF_LICENSE_KEY'", null, false);
            return conf.Rows.Count > 0 ? conf.Rows[0]["param"].ToString() : string.Empty;
        }

        private bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a == null || b == null) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        private void TryDeleteFile(string path)
        {
            try { if (!string.IsNullOrEmpty(path) && File.Exists(path)) File.Delete(path); }
            catch { }
        }

        void ManageStatus()
        {
            // Status is:
            // 1:Bozza - 2:Richiesta - 3:Da Correggere - 4:Inserito - 5,8:In fase di autorizzazione - 6:Approvato - 7:Annullato
            DataRow CurrentRow = DS.itineration.Rows[0];

            int status = CfgFn.GetNoNullInt32(CurrentRow["iditinerationstatus"]);
            int authmodel = CfgFn.GetNoNullInt32(CurrentRow["idauthmodel"]);
            /*
            if (status >= 4)
            {
                Meta.CanSave = false;
                Meta.CanCancel = false;
            }
            else
            {
                Meta.CanSave = true;
                Meta.CanCancel = true;
            }
            */
            EnableDisableControls(btnitinerationhistory, true);
            //txtInfos.Text += $"ManageStatus: {status}\r\n";
            switch (status)
            {
                case 1: //bozza. Da bozza può diventare una richiesta (attesa di autorizzazione se direct_auth)
                    Meta.canSave = true;
                    if (!controller.InsertMode)
                    {
                        if (DirectAuth)
                        {
                            btnStatus.Text = "Ufficializza";
                        }
                        else
                        {
                            btnStatus.Text = "Invia Richiesta";
                        }
                        btnStatus.Visible = true;
                        LockUnLockControls(false);
                        EnableDisableControls(txtEsercmissione, true);
                        EnableDisableControls(txtNummissione, true);
                        EnableDisableControls(txtEurTotMezzoProprio, true);

                        EnableDisableControls(txtsaldoaccordato, true);
                        EnableDisableControls(txtsaldorichiesto, true);
                        EnableDisableControls(txtanticipoaccordato, true);
                        EnableDisableControls(txtanticiporichiesto, true);
                        EnableDisableControls(cmbStatus, true);
                        EnableDisableControls(txtwebwarn, true);
                        EnableDisableControls(btnitinerationhistory, true);
                        Meta.canCancel = true;
                        btnStampaMissione.Visible = true;
                    }

                    break;
                case 2: //richiesta, può essere riportata a bozza 
                    btnStatus.Text = "Modifica";
                    LockUnLockControls(true);
                    btnStampaMissione.Visible = true;
                    btnStatus.Enabled = true;
                    EnableDisableControls(btnEditAtt, false);
                    //EnableDisableControls(btnitinerationhistory, false);
                    btnStampaMissione.Enabled = true;
                    btnStatus.Enabled = true;
                    Meta.canSave = false;// In fase di RICHIESTA non devo poter modificare nulla da Web
                    Meta.canCancel = true;

                    break;
                case 3://da correggere, può passare a richiesta o Autorizzazione
                    btnStatus.Visible = true;
                    if (DirectAuth)
                    {
                        btnStatus.Text = "Ufficializza";
                    }
                    else
                    {
                        btnStatus.Text = "Invia Richiesta";
                    }
                    LockUnLockControls(false);
                    btnStampaMissione.Visible = true;
                    btnStampaMissione.Enabled = true;
                    EnableDisableControls(txtEsercmissione, true);
                    EnableDisableControls(txtNummissione, true);
                    EnableDisableControls(txtEurTotMezzoProprio, true);

                    EnableDisableControls(txtsaldoaccordato, true);
                    EnableDisableControls(txtsaldorichiesto, true);
                    EnableDisableControls(txtanticipoaccordato, true);
                    EnableDisableControls(txtanticiporichiesto, true);
                    EnableDisableControls(cmbStatus, true);
                    EnableDisableControls(txtwebwarn, true);
                    EnableDisableControls(btnitinerationhistory, true);

                    btnStatus.Enabled = true;
                    Meta.canSave = true;
                    Meta.canCancel = true;
                    break;
                case 5: //Da autorizzazione può passare a bozza solo se DirectAuth
                case 8:
                    LockUnLockControls(true);
                    btnStampaMissione.Visible = true;
                    btnStampaMissione.Enabled = true;
                    EnableDisableControls(btnStatus, false);
                    EnableDisableControls(btnEditAtt, false);
                    EnableDisableControls(txtadditionalannotation, true);
                    EnableDisableControls(txtClause, true);
                    EnableDisableControls(chkClauseMezzoProprio, true);
                    EnableDisableControls(txtCausaleMezzoProprio, true);
                    Meta.canSave = false;
                    Meta.canCancel = false;

                    if (DirectAuth)
                    {
                        btnStatus.Text = "Riconsidera";
                        btnStatus.Enabled = true;
                    }
                    else
                    {
                        btnStatus.Visible = false;
                    }

                    break;

                case 4: //Inserita , è tutto bloccato 
                        // Blocca tutto
                    btnStatus.Visible = false;
                    LockUnLockControls(true);
                    btnStampaMissione.Visible = true;
                    btnStampaMissione.Enabled = true;
                    EnableDisableControls(btnStatus, false);
                    //txtInfos.Text += "ManageStatus HIDE INS TAPPA/SPESA\r\n";
                    EnableDisableControls(btnInsertTappa, true);
                    EnableDisableControls(btnDelTappa, true);
                    EnableDisableControls(btnEditTappa, false);
                    EnableDisableControls(btnInsertSpesa, true);
                    EnableDisableControls(btnEditSpesa, false);
                    EnableDisableControls(btnInsertSpesaSaldo, true);
                    EnableDisableControls(btnEditSpesaSaldo, false);
                    EnableDisableControls(btnDeleteSpesaSaldo, true);
                    EnableDisableControls(btnEditAtt, false);

                    btnStatus.Visible = false;
                    Meta.canSave = false;
                    Meta.canCancel = false;

                    break;

                case 6: //approvata
                        // Attenzione! In questo caso, oltre ad essere tutto bloccato
                    btnStatus.Visible = false;
                    LockUnLockControls(true);
                    btnStampaMissione.Visible = true;
                    btnStampaMissione.Enabled = true;
                    //btnStatus.Enabled = true;
                    EnableDisableControls(btnStatus, false);
                    EnableDisableControls(btnEditAtt, false);
                    //EnableDisableControls(btnitinerationhistory, false);

                    Meta.canSave = false;
                    Meta.canCancel = false;
                    if (CheckSpeseConsuntivo())
                    {
                        btnStatus.Visible = true;
                        btnStatus.Text = "Rendiconta Spese";
                    }
                    else
                    {
                        btnStatus.Visible = false;
                    }
                    break;

                default: //annullata o in fase di autorizzazione
                         // Blocca tutto
                    btnStatus.Visible = false;
                    LockUnLockControls(true);
                    btnStampaMissione.Visible = true;
                    btnStampaMissione.Enabled = true;
                    //btnStatus.Enabled = true;
                    EnableDisableControls(btnStatus, false);
                    EnableDisableControls(btnEditAtt, false);
                    //EnableDisableControls(btnitinerationhistory, false);

                    Meta.canSave = false;
                    Meta.canCancel = false;
                    btnStatus.Visible = false;
                    break;
            }
            if (Meta.editType == "myteamnew02")
            {
                EnableDisableControls(txtapplierannotation, false);
            }

        }

        void EnableDisableControls(Control C, bool Lock)
        {
            if (typeof(Control).IsAssignableFrom(C.GetType()))
            {
                Control CC = C as Control;
                if (CC.Name == txtClause.Name)
                    return;
                // Textbox invisibili create dal framework nei gruppi AutoChoose/AutoManage: conservano la chiave
                // corrente e devono restare ReadOnly, altrimenti la chiave entra nel filtro di ricerca (es. idreg = ...)
                if (CC.Name.StartsWith("InvisibleTxt"))
                    return;
                if (
                    typeof(RadioButton).IsAssignableFrom(CC.GetType()) || typeof(ComboBox).IsAssignableFrom(CC.GetType())
                    || typeof(CheckBox).IsAssignableFrom(CC.GetType()))
                    CC.Enabled = !Lock;
                if (typeof(Button).IsAssignableFrom(CC.GetType()))
                    ((Button)CC).Visible = !Lock;


                if (typeof(TextBox).IsAssignableFrom(CC.GetType()))
                    ((TextBox)CC).ReadOnly = Lock;
            }
            if (C.HasChildren)
            {
                foreach (Control child in C.Controls)
                    EnableDisableControls(child, Lock);
            }
        }

        public bool CheckSpeseConsuntivo()
        {
            DataRow Curr = DS.itineration.Rows[0];
            if (Curr == null)
                return false;

            // cambia il criterio per serverdate
            //DateTime ServerDate = DateTime.Now;

            DateTime EndDate = (DateTime)Curr["stop"];
            int numSpeseConsuntivo = DS.itinerationrefund_balance.Rows.Count;

            if (dataoggi >= EndDate && numSpeseConsuntivo == 0)
                return true;
            else
                return false;

        }

        public void ChangeItinerationAuthAgency(int idauthmodel)
        {
            if (DS.itineration.Rows.Count == 0)
                return;
            if (idauthmodel == 0)
            {
                DS.itinerationauthagency.RejectChanges();
                foreach (DataRow Existing in DS.itinerationauthagency.Select())
                {
                    Existing.Delete();
                }
                return;
            }
            QHS = Conn.GetQueryHelper();

            string query = " select AA.idauthagency as idauthagency, ";
            query += " A.title as title, A.description as description, A.priority as priority " +
                        " from authmodelauthagency AA inner join authagency A";
            query += " on (AA.idauthagency=A.idauthagency) ";
            query += " where " + QHS.CmpEq("AA.idauthmodel", idauthmodel) + " order by A.priority asc ";


            DataTable AuthAgencies = Conn.SQLRunner(query);

            Meta.SetDefaults(DS.itineration);
            DataRow ParentRow = DS.itineration.Rows[0];
            MetaData MD = dispatcher.Get("itinerationauthagency");

            DS.itinerationauthagency.RejectChanges();

            foreach (DataRow Existing in DS.itinerationauthagency.Select())
            {
                object codiceold = Existing["idauthagency"];
                if (AuthAgencies == null || AuthAgencies.Select(QHC.CmpEq("idauthagency", codiceold)).Length == 0)
                {
                    Existing.Delete();
                }
            }
            if (AuthAgencies == null || AuthAgencies.Rows.Count == 0)
                return;

            foreach (DataRow Row in AuthAgencies.Rows)
            {
                DataRow[] Found = DS.itinerationauthagency.Select(QHC.CmpEq("idauthagency", Row["idauthagency"]));
                DataRow MissAut;
                if (Found.Length == 0)
                {
                    MD.SetDefaults(DS.itinerationauthagency);
                    DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = Row["idauthagency"];
                    MissAut = MD.Get_New_Row(ParentRow, DS.itinerationauthagency);
                    DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = DBNull.Value;
                    //MissAut = MD.Get_New_Row(ParentRow, DS.itinerationauthagency);
                    //MissAut["idauthagency"] = Row["idauthagency"];
                }
                else
                {
                    MissAut = Found[0];
                }
                MissAut["flagstatus"] = "D";
                MissAut["!status"] = "Da Definire";
                MissAut["!title"] = Row["title"];
                MissAut["!priority"] = Row["priority"];
                MissAut["!description"] = Row["description"];
                MD.DescribeColumns(DS.itinerationauthagency, "webdefault");
                MD.CalculateFields(MissAut, "webdefault");
            }
        }

        public bool CanChangeAuthModel()
        {
            bool CanChange = true;
            foreach (DataRow DR in DS.itinerationauthagency.Rows)
            {
                if (DR.RowState != DataRowState.Deleted && (DR["flagstatus"].ToString().Trim() == "S" || DR["flagstatus"].ToString().Trim() == "N"))
                {
                    CanChange = false;
                    break;
                }
            }
            return CanChange;
        }

        private void txtDataInizio_TextChanged(object sender, EventArgs e)
        {
            if (!controller.DrawStateIsDone) return;
            if (controller.destroyed) return;
            if (controller.isClosing) return;
            
            if (!DataValida(txtDataInizio.Text) && txtDataInizio.Text != "")
                return;

            if (txtDataInizio.Text != "")
            {
                //forza l'immissione di una data valida
                DateTime dataInizio;
                try
                {
                    dataInizio = Convert.ToDateTime(txtDataInizio.Text);
                }
                catch
                {
                    show("La data inserita non era valida");
                    txtDataInizio.Focus();
                    return;
                }

            }
            GeneraSelect(sender);

            setDateInizioFineSpesa();
            CheckAnticipiReadOnly();
            EnableDisableRefund();
        }

        private void cmbAuthModel_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            setDateInizioFineSpesa();
            CheckAnticipiReadOnly();
            EnableDisableRefund();
        }

        void EnableDisableRefund()
        {
            if (controller.IsEmpty)
                return;

            DataRow Curr = DS.itineration.Rows[0];
            int currentstatus = CfgFn.GetNoNullInt32(Curr["iditinerationstatus"]);
            //Gestione spese anticipo

            bool faseanticipo = getFaseAnticipoMissione();
            bool dativalidi = DataMissioneValida() && cmbAuthModel.SelectedIndex > 0;

            //show($"EnableDisableRefund - Fase anticipo: {faseanticipo}, Dati validi: {dativalidi}, Current status: {currentstatus}");

            //in bozza ed in "da rivedere" è possibile inserire le spese (rendiconto o anticipo a seconda dello stato)
            if (currentstatus == 1 || currentstatus == 3)
            {
                //txtInfos.Text += $"EnableDisableRefund {(faseanticipo && dativalidi ? "SHOW" : "HIDE")} INS SPESA\r\n";
                btnInsertSpesa.Visible = faseanticipo && dativalidi;
                btnEditSpesa.Visible = dativalidi;
                btnDelSpesa.Visible = faseanticipo && dativalidi;

                btnInsertSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
                btnEditSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
                btnDeleteSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
                dgrSpeseSaldo.Visible = (!faseanticipo) && dativalidi;
            }
            else
            {
                //txtInfos.Text += "EnableDisableRefund HIDE INS SPESA\r\n";
                btnInsertSpesa.Visible = false;
                btnEditSpesa.Visible = dativalidi;
                btnDelSpesa.Visible = false;

                btnInsertSpesaSaldo.Visible = false;
                btnEditSpesaSaldo.Visible = (!faseanticipo) && dativalidi;
                btnEditSpesaSaldo.Enabled = (!faseanticipo) && dativalidi;
                btnDeleteSpesaSaldo.Visible = false;
                dgrSpeseSaldo.Visible = (!faseanticipo) && dativalidi;
            }
        }

        private void txtDataFine_TextChanged(object sender, EventArgs e)
        {
            if (!controller.DrawStateIsDone) return;
            if (controller.destroyed) return;
            if (controller.isClosing) return;

            if (!DataValida(txtDataFine.Text) && txtDataFine.Text != "")
                return;

            if (txtDataFine.Text != "")
            {
                //forza l'immissione di una data valida
                DateTime datafine;
                try
                {
                    datafine = Convert.ToDateTime(txtDataFine.Text);
                }
                catch
                {
                    show("La data inserita non era valida");
                    txtDataFine.Focus();
                    return;
                }

            }
            GeneraSelect(sender);


            setDateInizioFineSpesa();
            CheckAnticipiReadOnly();
            EnableDisableRefund();
            return;
        }

        private void btnStampaMissione_Click(object sender, EventArgs e)
        {
            DataRow curr = DS.itineration.First();
            if (curr == null)
            {
                return;
            }
            int yitineration = CfgFn.GetNoNullInt32(curr["yitineration"]);
            int nitineration = CfgFn.GetNoNullInt32(curr["nitineration"]);
            string pdfFileName, errmess;
            //Chiama la stampa
            string tempdir = System.IO.Path.GetTempPath();
            if (!tempdir.EndsWith("\\")) tempdir += "\\";
            string tempfilename = System.Guid.NewGuid().ToString() + ".pdf";

            string reportname = "missione_prospetto_calcolo";
            bool res = MissFun.stampaMissione(conn, tempdir, reportname, yitineration, nitineration, nitineration, out pdfFileName, out errmess, tempfilename);
            if (!res)
            {
                show("Errore nella stampa " + errmess, "Errore");
            }

            string fullPath = tempdir + tempfilename;
            try
            {
                runProcess(fullPath, true);
            }
            catch (Exception E)
            {
                QueryCreator.ShowException("Errore nell'apertura del file", E);
                return;
            }
        }

        string CF_User()
        {
            object hasVirtual = Conn.GetUsr("HasVirtualUser");
            if (hasVirtual == null)
                return null;
            if (hasVirtual.ToString().ToUpper() != "S")
                return null;
            object CF = Conn.GetUsr("cf");
            if (CF == DBNull.Value)
                return null;
            if (CF == null)
                return null;
            return CF.ToString();
        }

        private void ImpostaPosGiuridica(bool changerole, bool fromButtonRuolo)
        {
            if (controller.IsEmpty)
                return;
            DataRow Curr = DS.itineration.Rows[0];

            string filter;
            //string sorting;

            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate()))
            {
                ClearPosGiuridica();
                return;
            }
            if ((datafine == DBNull.Value) || (((DateTime)datafine) == QueryCreator.EmptyDate()))
            {
                ClearPosGiuridica();
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int)codicecreddeb) <= 0))
            {
                ClearPosGiuridica();
                return;
            }


            string strdate = QueryCreator.quotedstrvalue((DateTime)datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime)datafine, true);
            //Se clicco sul button devo consentire scegliere qualsiasi cosa, e quindi mostriamo le qualifiche:
            //valide alla data inizio o valide alla data fine
            // start <= data inizio oppure start <= data fine
            if (fromButtonRuolo)
            {
                //start <= data inizio e stop >= data inizio, valida a cavallo delle data inizio, deve essere valida prima e dopo la data inizio
                //OR
                //start <=data fine e stop >= data fine, valida a cavallo della data fine, deve essere valida prima e dopo la data fine
                // OR
                //start >=data inizio e stop null o <= data fine. Con questa condizione mostriamo anche i ruoli che nascono e muoiono durante la missione(è un caso remoto ma è meglio mostrarli)
                filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("active", "S"),
                    QHS.DoPar(QHS.AppOr(
                        QHS.AppAnd(QHS.CmpLe("start", datainizio), QHS.NullOrGe("stop", datainizio)),
                        QHS.AppAnd(QHS.CmpLe("start", datafine), QHS.NullOrGe("stop", datafine)),
                        QHS.AppAnd(QHS.CmpGe("start", datainizio), QHS.NullOrLe("stop", datafine))
                        ))
                    );
            }
            else
            {
                //Qualifica valida nel periodo della missione
                filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio), QHS.CmpEq("active", "S"),
                    QHS.NullOrGe("stop", datafine));
            }
            if ((LastFilterPosGiuridica == filter) && (!changerole))
                return;

            //sorting = "start DESC";

            //DataTable SelClass = Meta.Conn.RUN_SELECT("legalstatuscontract", 
            //    "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus", // , idwor
            //    sorting, filter, "1", false);

            int NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);

            // usa un filtro meno restrittivo, prende le qualifiche valide alla data inizio o valide alla data fine:
            // data inizio missione beetwen Start and Stop
            // OR
            // data fine missione beetwen Start and Stop
            if (NposGiuridiche == 0)
            {
                filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("active", "S"),
                QHS.DoPar(QHS.AppOr(
                    QHS.AppAnd(QHS.CmpLe("start", datainizio), QHS.NullOrGe("stop", datainizio)),
                    QHS.AppAnd(QHS.CmpLe("start", datafine), QHS.NullOrGe("stop", datafine)),
                    QHS.AppAnd(QHS.CmpGe("start", datainizio), QHS.NullOrLe("stop", datafine))
                        ))
                    );
                NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);
            }
            if (NposGiuridiche == 0)
            {
                if (LastFilterPosGiuridica != filter)
                    show("I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");

                ClearPosGiuridica();
                LastFilterPosGiuridica = filter;
                ////btnCambiaRuolo.Enabled = false;
                return;
            }
            LastFilterPosGiuridica = filter;

            DataRow RcurrPosGiuridica = null;
            object CurrPosGiuridica = null;
            DataTable SelClass = null;
            if (NposGiuridiche > 1)
            {

                //btnCambiaRuolo.Enabled = true;
                Meta.DoMainCommand("choose.legalstatuscontract.anagrafica." + filter);
                return;
            }


            if (NposGiuridiche == 1)
            {
                SelClass = Conn.RUN_SELECT("legalstatuscontract", "idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class", null, filter, null, false);

                if (fromButtonRuolo)
                    show("Posizione giuridica valorizzata.", "Avviso");
            }
            DataRow RowClass = SelClass.Rows[0];

            Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];


            //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
            object currflagquotaesente = "S";



            //FiltraComboPrestazioneInBaseANiente(false);
            object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");

            int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            setPosizioneGiuridica(RowClass["idposition"], RowClass["livello"]);
            //            MyCfg.idposition = RowClass["idposition"];
            MyCfg.matricula = matricula;
            MyCfg.incomeclass = incomeclass;
            MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

            //Classe attuale
            int classe, maxclassestip;
            classe = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
            if (classe <= maxclassestip)
            {
                MyCfg.incomeclass = classe;
            }
            else
            {
                MyCfg.incomeclass = maxclassestip;
            }


            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
                QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
                "max(idforeigngrouprule)");
            //imposta il gruppo estero
            string filterGE;
            filterGE = QHS.AppAnd(QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                            QHS.CmpEq("idposition", MyCfg.idposition),
                            QHS.NullOrEq("livello", MyCfg.livello),
                            "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");

            SetExtraParameterForDetails();
        }

        void resetPosizioneGiuridica()
        {
            MyCfg.idposition = DBNull.Value;
            MyCfg.livello = DBNull.Value;
            MyCfg.foreignclass = "";
            //grpTappe.Visible = false;
            //txtInfos.Text += "resetPosizioneGiuridica HIDE INS TAPPA\r\n";
            //EnableDisableControls(btnInsertTappa, true);
            //EnableDisableControls(btnEditTappa, true);
            //EnableDisableControls(btnDelTappa, true);
            if (controller.IsEmpty)
                return;
            DataRow Curr = DS.itineration.Rows[0];
            Curr["idregistrylegalstatus"] = DBNull.Value;
        }

        void setPosizioneGiuridica(object idposition, object livello)
        {
            MyCfg.idposition = idposition;
            MyCfg.livello = livello;
            if (DS.position.Select(QHC.CmpEq("idposition", idposition)).Length > 0)
            {
                MyCfg.foreignclass = DS.position.Select(QHC.CmpEq("idposition", idposition))[0]["foreignclass"].ToString().ToUpper();
            }
            else
            {
                MyCfg.foreignclass = "";
            }
            // grpTappe.Visible = true;
            //txtInfos.Text += "setPosizioneGiuridica HIDE INS TAPPA\r\n";
            EnableDisableControls(btnInsertTappa, false);
            EnableDisableControls(btnEditTappa, false);
            EnableDisableControls(btnDelTappa, false);
        }

        void SetExtraParameterForDetails()
        {
            DS.Tables["itinerationlap"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.Tables["itinerationrefund_advance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.Tables["itinerationrefund_balance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.itineration.ExtendedProperties["MyCfgItineration"] = MyCfg;
        }

        private void GeneraSelect(object sender)
        {
            if (controller.destroyed)
                return;

            if (controller.IsEmpty)
                return;

            if (controller.isClosing)
                return;

            controller.GetFormData(true);

            if (((Control)sender) == txtIncaricato)
                ImpostaPosGiuridica(false, false);

            if ((MissFun.CampoDataPerPosGiuridica == "start") && (((Control)sender) == txtDataInizio))
                ImpostaPosGiuridica(false, false);
            
            if (((Control)sender) == txtDataFine)
                ImpostaPosGiuridica(false, false);
        }

        void ClearPosGiuridica()
        {
            LastFilterPosGiuridica = "";
            MyCfg.incomeclass = DBNull.Value;
            MyCfg.foreignclass = "";
            resetPosizioneGiuridica();
            MyCfg.idwor = DBNull.Value;
            MyCfg.incomeclassvalidity = DBNull.Value;
            MyCfg.matricula = DBNull.Value;
            SetExtraParameterForDetails();
        }

        public void MetaData_BeforeFill()
        {
            DataRow Curr = DS.itineration.Rows[0];
            if (Curr == null)
                return;

            if (controller.EditMode)
                if (!managingstatus)
                    if (Curr["iditinerationstatus", DataRowVersion.Original].ToString() != Curr["iditinerationstatus", DataRowVersion.Current].ToString())
                        Curr["iditinerationstatus"] = Curr["iditinerationstatus", DataRowVersion.Original];
        }

        public void SetMainVisibility()
        {
            QHC = new CQueryHelper();
            //if (Meta.editType == "myteamnew02")
            //{
            //    // Posso guardare solo le prenotazioni delle quali io sono responsabile
            //    // Escluse le mie
            //    IsManager = (CodiceResponsabile != null ? true : false);
            //    int idman = 0;
            //    idman = CfgFn.GetNoNullInt32(CodiceResponsabile);
            //    string filter = QHC.CmpEq("idman", idman);
            //    GetData.SetStaticFilter(DS.itinerationview, filter);
            //    gboxResponsabile.Enabled = false;
            //}
            if (Meta.editType == "webdefault" && var["idreg"] != null)
            {
                string filterReg = QHC.CmpEq("idreg", var["idreg"]);
                // Con delegato abilitato si vedono anche le missioni di cui l'utente è delegato
                if (delegatoMissioneAbilitato)
                    filterReg = QHC.DoPar(QHC.AppOr(filterReg, QHC.CmpEq("idregdelegato", var["idreg"])));
                GetData.SetStaticFilter(DS.itinerationview, filterReg);
            }
            else
            {
                GetData.SetStaticFilter(DS.itinerationview, null);
            }
            grpIndKm.Visible = km_visibili;
        }

        void CalcolaTotAnticipo()
        {
            DataRow Curr = DS.itineration.Rows[0];
            if (DS.HasChanges())
            {
                if (!AnticipoIsReadOnly)
                {
                    decimal nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                            DS.itinerationrefund_advance));
                    Curr["totadvance"] = nuovototanticipo;
                }
                //totanticipoconcesso NON USATO
            }
        }

        void setDateInizioFineSpesa()
        {
            if (controller.IsEmpty)
                return;

            object datainizio;
            object datafine;
            if (DataValida(txtDataInizio.Text.ToString()))
            {
                datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
            }
            else
                return;

            if (DataValida(txtDataFine.Text.ToString()))
            {
                datafine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            }
            else
                return;

            MetaData.SetDefault(DS.itinerationrefund_advance, "starttime", datainizio);
            MetaData.SetDefault(DS.itinerationrefund_advance, "stoptime", datafine);
            MetaData.SetDefault(DS.itinerationrefund_advance, "flagadvancebalance", "A");
            MetaData.SetDefault(DS.itinerationrefund_balance, "starttime", datainizio);
            MetaData.SetDefault(DS.itinerationrefund_balance, "stoptime", datafine);
            MetaData.SetDefault(DS.itinerationrefund_balance, "flagadvancebalance", "S");
        }

        void RicalcolaRimborsiKilometrici()
        {
            if (controller.IsEmpty)
                return;
            //controller.GetFormData(true);
            DataRow Curr = DS.itineration.Rows[0];
            double KmProprio = CfgFn.GetNoNullDouble(Curr["owncarkm"]);
            double KmAmm = CfgFn.GetNoNullDouble(Curr["admincarkm"]);
            double KmPiedi = CfgFn.GetNoNullDouble(Curr["footkm"]);
            decimal ImpProprio = CfgFn.GetNoNullDecimal(Curr["owncarkmcost"]);
            decimal ImpAmm = CfgFn.GetNoNullDecimal(Curr["admincarkmcost"]);
            decimal ImpPiedi = CfgFn.GetNoNullDecimal(Curr["footkmcost"]);

            decimal TotAmm = Convert.ToDecimal(KmAmm) * ImpAmm;
            decimal TotProprio = Convert.ToDecimal(KmProprio) * ImpProprio;
            decimal TotPiedi = Convert.ToDecimal(KmPiedi) * ImpPiedi;

            txtEurTotMezzoProprio.Text = ((decimal)CfgFn.RoundValuta(TotProprio)).ToString("C");
        }

        bool DataValida(string date)
        {
            try
            {
                DateTime TT = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), date, "x.y");
                return true;
            }
            catch
            {
                return false;
            }
        }

        bool DataMissioneValida()
        {
            if (controller.IsEmpty) return false;
            if (txtDataInizio.ToString().Trim() == "") return false;
            return DataValida(txtDataInizio.Text.ToString());

        }

        bool getFaseAnticipoMissione()
        {
            if (controller.IsEmpty)
                return false;

            bool phase = false;

            object datainizio;
            if (DataValida(txtDataInizio.Text.ToString()))
                datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
            else
                return false;

            //if (datacontabile < (DateTime)datainizio) phase = true;
            if (dataoggi < (DateTime)datainizio)
                phase = true;

            return phase;
        }

        void CheckAnticipiReadOnly()
        {
            if (controller.IsEmpty)
                return;

            AnticipoIsReadOnly = false;

            if (controller.EditMode)
            {
                DataRow Curr = DS.itineration.Rows[0];
                string filter = QHS.AppAnd(QHS.CmpMulti(Curr, "iditineration"),
                                        QHS.CmpNe("movkind", 4));
                int N = Conn.RUN_SELECT_COUNT("expenseitineration", filter, false);
                filter = QHS.CmpMulti(Curr, "iditineration");
                N += Conn.RUN_SELECT_COUNT("pettycashoperationitineration", filter, false);
                if (N > 0) AnticipoIsReadOnly = true;
            }

            if (!getFaseAnticipoMissione())
                AnticipoIsReadOnly = true;
        }

        void AggiornaTotaliErogati()
        {
            if (controller.IsEmpty)
                return;

            DataRow Curr = DS.itineration.Rows[0];
            DataTable T = Conn.RUN_SELECT("itinerationresidual", "*", null, QHS.CmpKey(Curr), null, true);
            if (T == null || T.Rows.Count == 0)
                return;

            DataRow R = T.Rows[0];
            decimal linkedangir = CfgFn.GetNoNullDecimal(R["linkedangir"]);
            decimal linkedanpag = CfgFn.GetNoNullDecimal(R["linkedanpag"]);
            decimal linkedsaldo = CfgFn.GetNoNullDecimal(R["linkedsaldo"]);

            decimal totale = CfgFn.GetNoNullDecimal(Curr["totalgross"]);
            decimal anticipo = linkedanpag + linkedangir;
            decimal pagato = linkedsaldo > 0 ? linkedsaldo + linkedanpag : linkedanpag + linkedangir;
            decimal residuo = totale - pagato;
        }

        void AggiornaSoloInformazioni()
        {
            //txtInfos.Text += $"AggiornaSoloInformazioni\r\n";
            if (controller.IsEmpty)
                return;

            DataRow Curr = DS.itineration.Rows[0];

            string filter;
            string sorting;
            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            if ((datainizio == DBNull.Value) || (((DateTime)datainizio) == QueryCreator.EmptyDate()))
            {
                ClearPosGiuridica();
                return;
            }

            if ((datafine == DBNull.Value) || (((DateTime)datafine) == QueryCreator.EmptyDate()))
            {
                ClearPosGiuridica();
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int)codicecreddeb) <= 0))
            {
                ClearPosGiuridica();
                return;
            }

            string strdate = QueryCreator.quotedstrvalue((DateTime)datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime)datafine, true);

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio));

            if (LastFilterPosGiuridica == filter)
                return;

            string filtroInquadramento = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpEq("idregistrylegalstatus", Curr["idregistrylegalstatus"]));
            DataTable SelClass = Conn.RUN_SELECT("legalstatuscontract", "idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class", null, filtroInquadramento, null, false);

            if (SelClass.Rows.Count == 0)
            {
                //if (LastFilterPosGiuridica != filter)
                    //show("I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");

                //ClearInformazioni();
                LastFilterPosGiuridica = filter;
                return;
            }
            LastFilterPosGiuridica = filter;

            DataRow RowClass = SelClass.Rows[0];

            //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
            object currflagquotaesente = "S";

            //FiltraComboPrestazioneInBaseANiente(false);
            object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");
            int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            setPosizioneGiuridica(RowClass["idposition"], RowClass["livello"]);
            MyCfg.matricula = matricula;
            MyCfg.incomeclass = incomeclass;
            MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

            object codicequalifica = RowClass["idposition"];

            //Classe attuale
            int classe, maxclassestip;
            classe = CfgFn.GetNoNullInt32(incomeclass);
            maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
            if (classe <= maxclassestip)
            {
                MyCfg.incomeclass = classe;
            }
            else
            {
                MyCfg.incomeclass = maxclassestip;
            }
            bool AzzeraImportoEsente;
            if (currflagquotaesente.ToString().ToUpper() == "S")
                AzzeraImportoEsente = false;
            else
                AzzeraImportoEsente = true;

            datainizio = Curr[MissFun.CampoDataPerGeneralita];

            filter = QHS.CmpLe("start", datainizio);

            sorting = "start DESC";
            DataTable Generalita = Conn.RUN_SELECT("itinerationparameter", "start, italianexemption,foreignexemption", sorting, filter, "1", false);
            if (Generalita.Rows.Count == 0)
            {
                // show("In Generalit  Missioni non   stata trovata alcuna informazione", "Avviso");
                MyCfg.italianexemption = 0;
                MyCfg.foreignexemption = 0;
                MyCfg.foreignhours = 0;

            }
            else
            {
                DataRow RowGen = Generalita.Rows[0];
                MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);

                MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
                
                if (AzzeraImportoEsente)
                    MyCfg.foreignexemption = 0;

                if (DS.config.Rows.Count > 0)
                {
                    DataRow CurrSetup = DS.config.Rows[0];
                    MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
                }
            }

            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule", QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]), "max(idforeigngrouprule)");

            //imposta il gruppo estero
            string filterGE;
            filterGE = QHS.AppAnd(
                QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                QHS.CmpEq("idposition", MyCfg.idposition),
                QHS.NullOrEq("livello", MyCfg.livello),
                //QHS.CmpEq("livello", MyCfg.livello),
                "(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");

            DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber", null, filterGE, "1", false);
            
            if (DettGruppoEstero.Rows.Count == 0)
                MyCfg.foreigngroupnumber = DBNull.Value;
            else
                MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
            
            SetExtraParameterForDetails();
        }

        public void calcolatotaliriepilogo()
        {
            DataRow Curr = DS.itineration.Rows[0];
            if (Curr == null)
                return;

            decimal advancerequiredamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_advance, "requiredamount"));
            decimal advanceamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_advance, "amount"));
            decimal balancerequiredamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_balance, "requiredamount"));
            decimal balanceamount = CfgFn.GetNoNullDecimal(MetaData.SumColumn(DS.itinerationrefund_balance, "amount"));

            txtanticiporichiesto.Text = advancerequiredamount.ToString("c");
            txtanticipoaccordato.Text = advanceamount.ToString("c");

            txtsaldorichiesto.Text = balancerequiredamount.ToString("c");
            txtsaldoaccordato.Text = balanceamount.ToString("c");
        }

        public void DoChangeStatus()
        {
            if (controller.EditMode)
            {
                DataRow CurrentRow = DS.itineration.Rows[0];
                int status = CfgFn.GetNoNullInt32(CurrentRow["iditinerationstatus"]);
                //txtInfos.Text += $"DoChangeStatus: {status}\r\n";
                switch (status)
                {
                    case 1://se è in bozza o da correggere passa in richiesta o stato di autorizzazione a seconda del tipo di gestione
                    case 3:
                        if (DirectAuth)
                        {
                            // pulsante "Ufficializza"
                            ufficializzazioneInCorso = true;
                            try
                            {
                                PoniInAutorizzazione();
                            }
                            finally
                            {
                                ufficializzazioneInCorso = false;
                            }
                        }
                        else
                        {
                            CurrentRow["iditinerationstatus"] = 2;
                            managingstatus = true;
                            controller.FreshForm(false, false);
                            managingstatus = false;
                            Meta.DoMainCommand("mainsave");
                        }
                        break;
                    case 2:// se è in richiesta passa in bozza
                        CurrentRow["iditinerationstatus"] = 1;
                        managingstatus = true;
                        controller.FreshForm(false, false);
                        managingstatus = false;
                        Meta.DoMainCommand("mainsave");
                        break;
                    case 6:// se è approvata passa in bozza
                        CurrentRow["iditinerationstatus"] = 1;
                        managingstatus = true;
                        controller.FreshForm(false, false);
                        managingstatus = false;
                        Meta.DoMainCommand("mainsave");
                        break;

                    case 5:
                    case 8:
                        if (DirectAuth)
                        {
                            Riconsidera();
                        }
                        break;
                }

                if (controller.EditMode)/* && PState.runningcommand == null) */
                {
                    if (CurrentRow["iditinerationstatus", DataRowVersion.Original].ToString() != CurrentRow["iditinerationstatus", DataRowVersion.Current].ToString())
                    {
                        CurrentRow["iditinerationstatus"] = CurrentRow["iditinerationstatus", DataRowVersion.Original];
                        controller.FreshForm(false, false);
                    }
                }
            }
        }

        decimal CalcolaSpeseSostenute()
        {
            decimal SUM = 0;
            if (controller.IsEmpty)
                return SUM;

            if (getFaseAnticipoMissione())
            {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows)
                {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            else
            {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows)
                {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            return SUM;
        }

        decimal CalcolaSpeseAnticipo()
        {
            decimal SUM = 0;
            if (controller.IsEmpty)
                return SUM;

            foreach (DataRow R in DS.itinerationrefund_advance.Rows)
            {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }

        decimal CalcolaSpeseSaldo()
        {
            decimal SUM = 0;
            if (controller.IsEmpty)
                return SUM;

            foreach (DataRow R in DS.itinerationrefund_balance.Rows)
            {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }

        decimal CalcolaIndennitaSupplementari()
        {
            decimal SUM = 0;
            if (getFaseAnticipoMissione())
            {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows)
                {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            else
            {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows)
                {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            return CfgFn.RoundValuta(SUM);
        }

        decimal CalcolaIndennitaChilometrica()
        {
            DataRow Curr = DS.itineration.Rows[0];
            return MissFun.IndennitaChilometrica(Curr);
        }

        decimal CalcolaIndLordaTrafertaItalia()
        {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "S")))
            {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }

        decimal CalcolaIndLordaTrafertaEstero()
        {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "N")))
            {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }

        decimal AdminTax()
        {
            return MetaData.SumColumn(DS.itinerationtax, "admintax");
        }

        void CalcolaTotali()
        {
            DataRow curr = DS.itineration.Rows[0];
            //Set accorded refund = required refund
            foreach (DataRow S in DS.itinerationrefund_advance.Select())
            {
                S["amount"] = S["requiredamount"];
                S["amount_c"] = S["requiredamount_c"];
            }
            foreach (DataRow S in DS.itinerationrefund_balance.Select())
            {
                S["amount"] = S["requiredamount"];
                S["amount_c"] = S["requiredamount_c"];
            }

            //recalc totals
            decimal totalrefund = 0;
            decimal totalrefundadv = 0;
            decimal totalrefundbal = 0;
            decimal kmrefund = 0;
            decimal extraallowance = 0;
            decimal italiangrossallowance = 0;
            decimal foreigngrossallowance = 0;

            totalrefund = CfgFn.RoundValuta(CalcolaSpeseSostenute());
            totalrefundadv = CfgFn.RoundValuta(CalcolaSpeseAnticipo());
            totalrefundbal = CfgFn.RoundValuta(CalcolaSpeseSaldo());

            extraallowance = CfgFn.RoundValuta(CalcolaIndennitaSupplementari());
            kmrefund = CfgFn.RoundValuta(CalcolaIndennitaChilometrica());
            italiangrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaItalia());
            foreigngrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaEstero());

            decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
            curr["totalgross"] = totalgross;
            decimal total = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(curr["totalgross"]) + CfgFn.GetNoNullDecimal(AdminTax()));
            curr["total"] = total;

            decimal nuovototanticipo = CfgFn.GetNoNullDecimal(curr["totadvance"]);
            if (!AnticipoIsReadOnly)
            {
                nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap, DS.itinerationrefund_advance));
                curr["totadvance"] = nuovototanticipo;
            }
        }

        decimal CalcolaImportoLordoMissione()
        {
            return CalcolaSpeseSostenute() +
                   CalcolaIndennitaSupplementari() +
                   CalcolaIndennitaChilometrica() +
                   CalcolaIndLordaTrafertaItalia() + //lordo 
                   CalcolaIndLordaTrafertaEstero(); //lordo

        }

        void RicalcolaTotaliRitenute()
        {
            if (controller.IsEmpty) return;
            decimal TotDip = 0;
            decimal TotAmm = 0;
            decimal AssicurativeDip = 0;
            decimal AssicurativeEnte = 0;
            decimal AssistenzialiDip = 0;
            decimal AssistenzialiEnte = 0;
            decimal FiscaliDip = 0;
            decimal FiscaliEnte = 0;
            decimal PrevidenzialiDip = 0;
            decimal PrevidenzialiEnte = 0;
            decimal AltreDip = 0;
            decimal AltreEnte = 0;

            DataRow Curr = DS.itineration.Rows[0];
            decimal MyImporto;
            decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
            Curr["totalgross"] = totalgross;
            MyImporto = totalgross;
            
            foreach (DataRow DR in DS.itinerationtax.Rows)
            {
                if (DR.RowState == DataRowState.Deleted)
                    continue;

                decimal DecDip = CfgFn.GetNoNullDecimal(DR["employtax"]);
                decimal DecAmm = CfgFn.GetNoNullDecimal(DR["admintax"]);
                TotDip += DecDip;
                TotAmm += DecAmm;

                string MyFilter = QHC.CmpEq("taxcode", DR["taxcode"]);
                DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);

                //In base al tipo di ritenuta:
                switch (DRTipo[0]["taxkind"].ToString())
                {
                    case "2":
                        AssistenzialiDip += DecDip;
                        AssistenzialiEnte += DecAmm;
                        break;
                    case "1":
                        FiscaliDip += DecDip;
                        FiscaliEnte += DecAmm;
                        break;
                    case "3":
                        PrevidenzialiDip += DecDip;
                        PrevidenzialiEnte += DecAmm;
                        break;
                    case "6":
                        AltreDip += DecDip;
                        AltreEnte += DecAmm;
                        break;
                    case "4":
                        AssicurativeDip += DecDip;
                        AssicurativeEnte += DecAmm;
                        break;
                }


            } //fine foreach
            TotDip = CfgFn.RoundValuta(TotDip);
            TotAmm = CfgFn.RoundValuta(TotAmm);

            CfgFn.AssignNotEquals(Curr, "netfee", MyImporto - TotDip);
            CfgFn.AssignNotEquals(Curr, "total", MyImporto + TotAmm);
        }

        public void PoniInAutorizzazione()
        {
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = getFaseAnticipoMissione() ? 5 : 8;


            if (DS.itinerationauthagency.Select().Length == 0 ||
                DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
            {
                GeneraAutorizzazioni();
            }

            if ((DS.itinerationauthagency.Select().Length == 0) ||  //non ci sono agenti autorizzativi
                (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0))
            { // missione già approvata devo inserire il saldo
                curr["iditinerationstatus"] = 6;//Approvata
                if (getFaseAnticipoMissione() == false)
                {
                    curr["completed"] = "S";
                }
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
            }
            CheckAnticipiReadOnly();
            CalcolaTotali();
            RicalcolaTotaliRitenute();

            managingstatus = true;
            controller.FreshForm(false, false);
            managingstatus = false;
            Meta.DoMainCommand("mainsave");


            if (DS.HasChanges())
            {
                DS.itinerationauthagency.RejectChanges();
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                managingstatus = true;
                controller.FreshForm(false, false);
                managingstatus = false;
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        void GeneraAutorizzazioni()
        {
            if (controller.IsEmpty)
                return;

            DataRow Curr = DS.itineration.Rows[0];
            //Aggiorna / Crea le righe nella Tabella Autorizzazioni in base al Modello Autorizzativo selezionato
            MetaData MetaAutorizzazione = MetaData.GetMetaData(this, "itinerationauthagency");
            MetaAutorizzazione.SetDefaults(DS.itinerationauthagency);
            MetaAutorizzazione.DescribeColumns(DS.itinerationauthagency, "webdefault");
            DataTable authModelAuthAgency = Conn.RUN_SELECT("authmodelauthagency", null, null, QHS.CmpEq("idauthmodel", Curr["idauthmodel"]), null, true);
            //Elimina dalla tabella Autorizzazioni le righe che non saranno utilizzate
            DS.itinerationauthagency.RejectChanges();
            foreach (DataRow Existing in DS.itinerationauthagency.Select())
            {
                if (Existing.RowState == DataRowState.Deleted)
                    continue;
                object codiceold = Existing["idauthagency"];
                if (authModelAuthAgency == null || authModelAuthAgency.Select(QHC.CmpEq("idauthagency", codiceold)).Length == 0)
                {
                    Existing.Delete();
                }
            }

            foreach (DataRow Row in authModelAuthAgency.Rows)
            {
                DataRow[] Found = DS.itinerationauthagency.Select(QHC.CmpEq("idauthagency", Row["idauthagency"]));
                DataRow MissAut;
                if (Found.Length == 0)
                {
                    MetaAutorizzazione.SetDefaults(DS.itinerationauthagency);
                    DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = Row["idauthagency"];
                    MissAut = MetaAutorizzazione.Get_New_Row(Curr, DS.itinerationauthagency);
                    DS.itinerationauthagency.Columns["idauthagency"].DefaultValue = DBNull.Value;
                }
                else
                {
                    MissAut = Found[0];
                }
                MissAut["flagstatus"] = "D";
            }
        }

        void Riconsidera()
        {
            if (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
            {
                bool asked = false;
                foreach (DataRow R in DS.itinerationauthagency.Select())
                {
                    if (R["flagstatus"].ToString().ToUpper() != "S")
                        continue;
                    R["flagstatus"] = "D";
                }
            }

            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 3;  // ritorna nello stato "Da correggere"
            managingstatus = true;
            controller.FreshForm(false, false);
            managingstatus = false;
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                DS.itinerationauthagency.RejectChanges();
                managingstatus = true;
                controller.FreshForm(false, false);
                managingstatus = false;
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private string CalcolaFiltroUPB()
        {
            if (DS.itineration.Rows.Count == 0)
                return "";

            DataRow r = DS.itineration.Rows[0];
            string filter_upb = "";
            object idman = r["idman"];
            if (idman != null && idman != DBNull.Value)
            {
                filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", idman));
            }
            return filter_upb;
        }

        private void ImpostaTageFiltriUPB(object idupbToinclude)
        {
            string upbfilter = CalcolaFiltroUPB();
            string filteradd = upbfilter;
            string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

            if (idupbToinclude != DBNull.Value && upbfilter != "")
            {
                filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
            }

            GetData.SetStaticFilter(DS.upb, filteradd);

            if (upbfilter != "")
            {
                btnUPBCode.Tag = "choose.upb.missioni." + filteractive;
            }
            else
            {
                btnUPBCode.Tag = "manage.upb.tree";
            }

            if (gboxUPB.Tag != null)
                gboxUPB.Tag = "AutoChoose.txtUPB.default." + filteractive;
            controller.SetAutoMode(gboxUPB);
        }

        string GetFieldName(object tag)
        {
            if (tag == null) return null;

            string s = tag.ToString();

            // Prendi solo la parte prima del '?'
            int q = s.IndexOf('?');
            if (q >= 0)
                s = s.Substring(0, q);

            // Ora prendi solo la parte dopo l'ultimo '.'
            int dot = s.LastIndexOf('.');
            if (dot >= 0 && dot < s.Length - 1)
                return s.Substring(dot + 1);

            return s; // Se non c'è '.', ritorna tutto
        }

        // Funzione ricorsiva per scorrere tutti i controlli di un Form (anche annidati)
        void ProcessControls(Control parent, string currfieldName)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl.Tag != null)
                {
                    string fieldName = GetFieldName(ctrl.Tag);

                    if (ctrl is TextBox textBox)
                    {

                        //Serve a gestire situazioni come i groupb dei responsabili, ove
                        // non abbiamo il nome del campo direttamente nel Tag
                        MetaData.AutoInfo a = controller.GetAutoInfo(ctrl.Name);
                        if (a != null)
                        {
                            fieldName = a.childfield;
                        }
                        // NON colorare se il textbox è readonly o disabilitato
                        if (!textBox.Enabled || textBox.ReadOnly)
                            continue;
                    }
                    else
                    {
                        //Per altri controlli: NON colorare se disabilitati. Lo facciamo graficamente su win per vederlo qui
                        if (!ctrl.Enabled)
                            continue;
                    }
                    // il secondo IF evita di fare un refresh quando un campo è diventato obbligatorio in seguito ad un evento
                    // il SetMandatoryField agisce, ma a livello grafice avrebbe fatto un refresh.
                    if (fieldName != null)
                    {
                        if ((mandatoryControls.Contains(fieldName)) || fieldName == currfieldName)
                        {
                            ctrl.AccessibleDescription = "Mandatory";
                        }
                    }
                }

                // Ricorsione: scorre anche i controlli figli
                if (ctrl.HasChildren)
                    ProcessControls(ctrl, currfieldName);
            }
        }

        #region Gestione controlli calcolati in base a creddeb/prestazione/datainizio

        void DisableSpeseSaldo()
        {
            grpSpeseRendiconto.Visible = false;
        }

        private void txtDataInizio_LostFocus(object sender, System.EventArgs e)
        {
            if (controller.isClosing) return;
            if (inside_lostfocus) return;
            inside_lostfocus = true;
            if (txtDataInizio.Text != "")
            {
                //forza l'immissione di una data valida
                DateTime datainizio;
                try
                {
                    datainizio = Convert.ToDateTime(txtDataInizio.Text);
                }
                catch
                {
                    show("La data inserita non era valida");
                    txtDataInizio.SelectAll();
                    txtDataInizio.Focus();
                    inside_lostfocus = false;
                    return;
                }
            }
            GeneraSelect(sender);
            inside_lostfocus = false;
        }

        private void txtDataFine_LostFocus(object sender, System.EventArgs e)
        {
            if (controller.isClosing) return;
            if (inside_lostfocus) return;
            inside_lostfocus = true;

            if (txtDataFine.Text != "")
            {
                //forza l'immissione di una data valida
                DateTime datafine;
                try
                {
                    datafine = Convert.ToDateTime(txtDataFine.Text);
                }
                catch
                {
                    show("La data inserita non era valida");
                    txtDataFine.SelectAll();
                    txtDataFine.Focus();
                    inside_lostfocus = false;
                    return;
                }
            }
            GeneraSelect(sender);
            inside_lostfocus = false;
        }

        #endregion

        private void txtKmMezzoProprio_TextChanged(object sender, System.EventArgs e)
        {
            if (!controller.DrawStateIsDone) return;
            if (controller.destroyed) return;
            if (controller.isClosing) return;
            RicalcolaRimborsiKilometrici();
            CalcolaTotaliMissione();
            RicalcolaTotaliRitenute();
        }

        void CalcolaTotaliMissione()
        {
            if (controller.IsEmpty) return;
            controller.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);

            DataRow curr = DS.itineration.Rows[0];
            //Set accorded refund = required refund
            foreach (DataRow S in DS.itinerationrefund_advance.Select())
            {
                S["amount"] = S["requiredamount"];
                S["amount_c"] = S["requiredamount_c"];
            }
            foreach (DataRow S in DS.itinerationrefund_balance.Select())
            {
                S["amount"] = S["requiredamount"];
                S["amount_c"] = S["requiredamount_c"];
            }

            decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
            curr["totalgross"] = totalgross;
            decimal total = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(curr["totalgross"]) +
                CfgFn.GetNoNullDecimal(AdminTax()));
            curr["total"] = total;

            decimal nuovototanticipo = CfgFn.GetNoNullDecimal(curr["totadvance"]);
            if (!AnticipoIsReadOnly)
            {
                nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                        DS.itinerationrefund_advance));
                curr["totadvance"] = nuovototanticipo;
            }
        }

        private void btnAccetta_Click(object sender, EventArgs e)
        {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 4;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        //public void MetaData_AfterGetFormData()
        //{
            //txtInfos.Text += "AfterGetFormData\r\n";
            //if (controller.EditMode)
            //{
                //DataRow R = DS.itineration.Rows[0];
                //if (CfgFn.GetNoNullDecimal(R["supposedtravel", DataRowVersion.Current]) !=
                    //CfgFn.GetNoNullDecimal(R["supposedtravel", DataRowVersion.Original])
                    //)
                //{
                    //AggiornaSpeseAnticipo("viaggio");
                //}
                //if (CfgFn.GetNoNullDecimal(R["supposedliving", DataRowVersion.Current]) !=
                    //CfgFn.GetNoNullDecimal(R["supposedliving", DataRowVersion.Original])
                    //)
                //{
                    //AggiornaSpeseAnticipo("alloggio");
                //}
                //if (CfgFn.GetNoNullDecimal(R["supposedfood", DataRowVersion.Current]) !=
                    //CfgFn.GetNoNullDecimal(R["supposedfood", DataRowVersion.Original])
                    //)
                //{
                    //AggiornaSpeseAnticipo("vitto");
                //}
                //if (CfgFn.GetNoNullDecimal(R["supposedamount", DataRowVersion.Current]) !=
                    //CfgFn.GetNoNullDecimal(R["supposedamount", DataRowVersion.Original])
                    //)
                //{
                    //AggiornaSpeseAnticipo("altro");
                //}

            //}
        //}
        
        //void AggiornaSpeseAnticipo(string kind)
        //{
            //DataRow Curr = DS.itineration.Rows[0];
            //object idfundkindgroup = Conn.DO_READ_VALUE("itinerationrefundkindgroup", QHS.CmpEq("description", kind), "iditinerationrefundkindgroup");
            //object iditinerationrefundkind = Conn.DO_READ_VALUE("itinerationrefundkind",
                //QHS.AppAnd(QHS.CmpEq("iditinerationrefundkindgroup", idfundkindgroup), QHS.CmpEq("active", "S"), QHS.CmpEq("flagadvance", "S")),
                //"iditinerationrefundkind", "codeitinerationrefundkind asc");
            //DataRow[] found = DS.itinerationrefund_advance.Select(QHC.CmpEq("iditinerationrefundkind", iditinerationrefundkind));
            //DataRow SpeseAnticipo;
            //decimal importo = 0;
            //switch (kind)
            //{
                //case "viaggio":
                    //importo = CfgFn.GetNoNullDecimal(Curr["supposedtravel"]);
                    //break;
                //case "alloggio":
                    //importo = CfgFn.GetNoNullDecimal(Curr["supposedliving"]);
                    //break;
                //case "vitto":
                    //importo = CfgFn.GetNoNullDecimal(Curr["supposedfood"]) * CfgFn.GetNoNullInt32(Curr["nfood"]);
                    //break;
                //case "altro":
                    //importo = CfgFn.GetNoNullDecimal(Curr["supposedamount"]);
                    //break;
            //}

            //if (found.Length > 0)
            //{
                //// Modifica quelle del DS
                //found[0]["amount"] = importo;
                //found[0]["requiredamount"] = importo;
                //found[0]["advancepercentage"] = Curr["advancepercentage"];
            //}
        //}

        private void btnintegra_Click(object sender, EventArgs e)
        {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 3;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }
        
        private void btnRiconsidera_Click(object sender, EventArgs e)
        {
            if (!controller.GetFormData(false)) return;
            if (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
            {
                bool asked = false;
                foreach (DataRow R in DS.itinerationauthagency.Select())
                {
                    if (R["flagstatus"].ToString().ToUpper() != "S") continue;
                    if (!asked)
                    {
                        asked = true;
                        if (
                            show("Lo stato di autorizzazione sar  resettato.", "Avviso",
                                MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                    }
                    R["flagstatus"] = "D";
                }
            }

            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 4; // ritorna nello stato "inserita"
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                DS.itinerationauthagency.RejectChanges();
                controller.FreshForm(true, false);
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private void btnAttesaAutorizzazione_Click(object sender, EventArgs e)
        {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = getFaseAnticipoMissione() ? 5 : 8;

            foreach (DataRow Ref in DS.itinerationrefund_advance.Select())
            {
                if (CfgFn.GetNoNullDecimal(Ref["requiredamount"]) > 0 &&
                    CfgFn.GetNoNullDecimal(Ref["amount"]) == 0)
                    Ref["amount"] = Ref["requiredamount"];
            }
            foreach (DataRow Ref in DS.itinerationrefund_balance.Select())
            {
                if (CfgFn.GetNoNullDecimal(Ref["requiredamount"]) > 0 &&
                    CfgFn.GetNoNullDecimal(Ref["amount"]) == 0)
                    Ref["amount"] = Ref["requiredamount"];
            }

            if (DS.itinerationauthagency.Select().Length == 0 ||
                DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
                GeneraAutorizzazioni();

            if ((DS.itinerationauthagency.Select().Length == 0) || //non ci sono agenti autorizzativi
                (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0))
            {
                // missione gi  approvata devo inserire il saldo
                curr["iditinerationstatus"] = 6;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
            }
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                DS.itinerationauthagency.RejectChanges();
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 7;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges())
            {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else
            {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        bool DirectAuth = false;

        private void btnStatus_Click(object sender, EventArgs e)
        {
            DoChangeStatus();
        }
    }
}