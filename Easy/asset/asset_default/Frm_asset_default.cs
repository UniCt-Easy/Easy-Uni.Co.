/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione


namespace asset_default //beneinventariabile//
{
    /// <summary>
    /// Summary description for frmbeneinventariabile.
    /// </summary>
    public class Frm_asset_default : System.Windows.Forms.Form {
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPrincipale;
        public vistaForm DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpClassif;
        private System.Windows.Forms.TextBox txtDescClassif;
        private System.Windows.Forms.TextBox txtIdClassif;
        private System.Windows.Forms.Button btnClassif;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.GroupBox grpValore;
        private System.Windows.Forms.TextBox txtImposta;
        private System.Windows.Forms.TextBox txtSconto;
        private System.Windows.Forms.TextBox txtImpostaTotale;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboInventario;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.TextBox txtIdBene;
        private MetaData Meta;
        private System.Windows.Forms.TabPage tabAltriDati;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DataAccess Conn;
        private System.Windows.Forms.TextBox txtImpConIVA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataCreazione;
        private System.Windows.Forms.Button btnInserisciQuota;
        private System.Windows.Forms.Button btnModificaQuota;
        private System.Windows.Forms.Button btnEliminaQuota;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gboxUbicazione;
        private System.Windows.Forms.GroupBox gboxResponsabile;
        private System.Windows.Forms.ComboBox cmbTipoBuonoScarico;
        private System.Windows.Forms.TextBox txtNumBuonoScarico;
        private System.Windows.Forms.TextBox txtEsercBuonoScarico;
        private System.Windows.Forms.ComboBox cmbTipoBuonoCarico;
        private System.Windows.Forms.TextBox txtNumBuonoCarico;
        private System.Windows.Forms.TextBox txtEsercBuonoCarico;
        private System.Windows.Forms.TextBox txtNumInv;
        private System.Windows.Forms.GroupBox gboxScarico;
        private System.Windows.Forms.GroupBox gboxCarico;
        private System.Windows.Forms.GroupBox gboxPrincipale;
        private System.Windows.Forms.Label lab5b;
        private CheckBox chkIncludes;
        private CheckBox chkTrasmitted;
        private CheckBox chkUnload;
        private TabPage tabStorico;
        private GroupBox gboxInventarioDestinazione;
        private Label label21;
        private TextBox txtNumInvNextAsset;
        private Label label22;
        private GroupBox gboxInventarioProvenienza;
        private Label label20;
        private TextBox txtNumInvPreviousAsset;
        private Label label4;
        private Label label23;
        private ComboBox cmbCausaleCarico;
        private Label label24;
        private ComboBox cmbCausaleScarico;
        private CheckBox chkTransf;
        private TabPage tabAggiuntive;
        private TabPage tabAmmortamenti;
        private GroupBox grpUbicazioneAttuale;
        private Button btnUbicazioneAttuale;
        private TextBox txtDescUbicazAttuale;
        private TextBox txtUbicazioneAttuale;
        private GroupBox grpRespAttuale;
        private TextBox txtValoreCarico;
        private Label label5;
        private GroupBox gboxaccessoriposseduti;
        private DataGrid gridpartiscaricate;
        private GroupBox gboxammortamenti;
        private DataGrid gridAmmortamenti;
        private CheckBox chkScaricato;
        private CheckBox chkCaricato;
        private TextBox txtValoreAttuale;
        private Label labelAttuale;
        private TextBox txtAmmortamenti;
        private Label label26;
        private TextBox txtpartipossedute;
        private Label labpartipossedute;
        private CheckBox chkAccessorio;
        private CheckBox chkPosseduto;
        private GroupBox gboxOperazioni;
        private ComboBox cboNextAsset;
        private ComboBox cboPreviousAsset;
        private Label label25;
        private TextBox textBox1;
        private Label label27;
        private TextBox txtRevalPending;
        private TextBox textBox2;
        private Label label11;
        private TextBox textBox4;
        private Label label19;
        private Label label3;
        private Label label15;
        public TextBox txtResponsabile;
        private GroupBox gboxCategoria;
        private GroupBox groupBox1;
        private TextBox textBox6;
        private TextBox textBox5;
        private TabPage tabConsegnatario;
        private GroupBox grpConsegnatarioAttuale;
        public TextBox txtConsegnatario;
        private GroupBox gboxConsegnatario;
        private Button button4;
        private Button button5;
        private Button button6;
        private DataGrid dataGrid3;
        private GroupBox gboxListino;
        private CheckBox chkListDescription;
        private Button btnListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private GroupBox grpAmmortamento;
        private ComboBox cmbAmmortamento;
        private Button button10;
        private TextBox textBox7;
        private TextBox textBox8;
        private Label label2;
        private TextBox txtRatificaScarico;
        private Label label28;
        private TextBox txtRatificaCarico;
        private Label label29;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private CheckBox chkInventarioVisibile;
        private TabPage tabRisconti;
        private GroupBox gboxRisconti;
        private Button btnInsAssetGrant;
        private Button btnDelAssetGrant;
        private Button btnUpdAssetGrant;
        private DataGrid datagridassetgrant;
        private GroupBox groupBox2;
        private Button button7;
        private Button button8;
        private Button button9;
        private DataGrid dataGrid4;
		private Label label30;
		private TextBox txtRfid;
		private Button btnUPBCode;
        //private bool m_bControlliAggiunti = false;

        public Frm_asset_default() {
            InitializeComponent();
            GetData.SetSorting(DS.assetview, "nassetacquire DESC");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_asset_default));
            this.DS = new asset_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxListino = new System.Windows.Forms.GroupBox();
            this.chkListDescription = new System.Windows.Forms.CheckBox();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.gboxCategoria = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.gboxPrincipale = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lab5b = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkTrasmitted = new System.Windows.Forms.CheckBox();
            this.cboInventario = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNumInv = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.gboxScarico = new System.Windows.Forms.GroupBox();
            this.txtRatificaScarico = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.chkTransf = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cmbCausaleScarico = new System.Windows.Forms.ComboBox();
            this.chkUnload = new System.Windows.Forms.CheckBox();
            this.chkIncludes = new System.Windows.Forms.CheckBox();
            this.cmbTipoBuonoScarico = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumBuonoScarico = new System.Windows.Forms.TextBox();
            this.txtEsercBuonoScarico = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.gboxCarico = new System.Windows.Forms.GroupBox();
            this.txtRatificaCarico = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbCausaleCarico = new System.Windows.Forms.ComboBox();
            this.cmbTipoBuonoCarico = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNumBuonoCarico = new System.Windows.Forms.TextBox();
            this.txtEsercBuonoCarico = new System.Windows.Forms.TextBox();
            this.grpValore = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImpConIVA = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImposta = new System.Windows.Forms.TextBox();
            this.txtSconto = new System.Windows.Forms.TextBox();
            this.txtImpostaTotale = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataCreazione = new System.Windows.Forms.TextBox();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.txtIdBene = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabAltriDati = new System.Windows.Forms.TabPage();
            this.grpUbicazioneAttuale = new System.Windows.Forms.GroupBox();
            this.btnUbicazioneAttuale = new System.Windows.Forms.Button();
            this.txtDescUbicazAttuale = new System.Windows.Forms.TextBox();
            this.txtUbicazioneAttuale = new System.Windows.Forms.TextBox();
            this.grpRespAttuale = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxUbicazione = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnEliminaQuota = new System.Windows.Forms.Button();
            this.btnModificaQuota = new System.Windows.Forms.Button();
            this.btnInserisciQuota = new System.Windows.Forms.Button();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tabAmmortamenti = new System.Windows.Forms.TabPage();
            this.gboxOperazioni = new System.Windows.Forms.GroupBox();
            this.chkInventarioVisibile = new System.Windows.Forms.CheckBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRevalPending = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCaricato = new System.Windows.Forms.CheckBox();
            this.chkPosseduto = new System.Windows.Forms.CheckBox();
            this.chkScaricato = new System.Windows.Forms.CheckBox();
            this.txtValoreCarico = new System.Windows.Forms.TextBox();
            this.chkAccessorio = new System.Windows.Forms.CheckBox();
            this.labpartipossedute = new System.Windows.Forms.Label();
            this.txtpartipossedute = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtValoreAttuale = new System.Windows.Forms.TextBox();
            this.txtAmmortamenti = new System.Windows.Forms.TextBox();
            this.labelAttuale = new System.Windows.Forms.Label();
            this.grpAmmortamento = new System.Windows.Forms.GroupBox();
            this.cmbAmmortamento = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxaccessoriposseduti = new System.Windows.Forms.GroupBox();
            this.gridpartiscaricate = new System.Windows.Forms.DataGrid();
            this.gboxammortamenti = new System.Windows.Forms.GroupBox();
            this.gridAmmortamenti = new System.Windows.Forms.DataGrid();
            this.tabStorico = new System.Windows.Forms.TabPage();
            this.gboxInventarioDestinazione = new System.Windows.Forms.GroupBox();
            this.cboNextAsset = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNumInvNextAsset = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.gboxInventarioProvenienza = new System.Windows.Forms.GroupBox();
            this.cboPreviousAsset = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNumInvPreviousAsset = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabAggiuntive = new System.Windows.Forms.TabPage();
            this.tabConsegnatario = new System.Windows.Forms.TabPage();
            this.grpConsegnatarioAttuale = new System.Windows.Forms.GroupBox();
            this.txtConsegnatario = new System.Windows.Forms.TextBox();
            this.gboxConsegnatario = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabRisconti = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.gboxRisconti = new System.Windows.Forms.GroupBox();
            this.btnInsAssetGrant = new System.Windows.Forms.Button();
            this.btnDelAssetGrant = new System.Windows.Forms.Button();
            this.btnUpdAssetGrant = new System.Windows.Forms.Button();
            this.datagridassetgrant = new System.Windows.Forms.DataGrid();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxListino.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxCategoria.SuspendLayout();
            this.gboxPrincipale.SuspendLayout();
            this.gboxScarico.SuspendLayout();
            this.gboxCarico.SuspendLayout();
            this.grpValore.SuspendLayout();
            this.grpClassif.SuspendLayout();
            this.tabAltriDati.SuspendLayout();
            this.grpUbicazioneAttuale.SuspendLayout();
            this.grpRespAttuale.SuspendLayout();
            this.gboxUbicazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.gboxResponsabile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabAmmortamenti.SuspendLayout();
            this.gboxOperazioni.SuspendLayout();
            this.grpAmmortamento.SuspendLayout();
            this.gboxaccessoriposseduti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridpartiscaricate)).BeginInit();
            this.gboxammortamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAmmortamenti)).BeginInit();
            this.tabStorico.SuspendLayout();
            this.gboxInventarioDestinazione.SuspendLayout();
            this.gboxInventarioProvenienza.SuspendLayout();
            this.tabConsegnatario.SuspendLayout();
            this.grpConsegnatarioAttuale.SuspendLayout();
            this.gboxConsegnatario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabRisconti.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.gboxRisconti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridassetgrant)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPrincipale);
            this.tabControl1.Controls.Add(this.tabAltriDati);
            this.tabControl1.Controls.Add(this.tabAmmortamenti);
            this.tabControl1.Controls.Add(this.tabStorico);
            this.tabControl1.Controls.Add(this.tabAggiuntive);
            this.tabControl1.Controls.Add(this.tabConsegnatario);
            this.tabControl1.Controls.Add(this.tabRisconti);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 559);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.gboxUPB);
            this.tabPrincipale.Controls.Add(this.gboxListino);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.gboxCategoria);
            this.tabPrincipale.Controls.Add(this.gboxPrincipale);
            this.tabPrincipale.Controls.Add(this.gboxScarico);
            this.tabPrincipale.Controls.Add(this.gboxCarico);
            this.tabPrincipale.Controls.Add(this.txtDataCreazione);
            this.tabPrincipale.Controls.Add(this.grpClassif);
            this.tabPrincipale.Controls.Add(this.label10);
            this.tabPrincipale.Controls.Add(this.btnSituazione);
            this.tabPrincipale.Controls.Add(this.txtIdBene);
            this.tabPrincipale.Controls.Add(this.label1);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(974, 533);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 174);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(482, 101);
            this.gboxUPB.TabIndex = 33;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(465, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?assetview.codeupb";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(141, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(332, 62);
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
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxListino
            // 
            this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxListino.Controls.Add(this.chkListDescription);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtListino);
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Location = new System.Drawing.Point(504, 48);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(467, 130);
            this.gboxListino.TabIndex = 5;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            // 
            // chkListDescription
            // 
            this.chkListDescription.Location = new System.Drawing.Point(10, 14);
            this.chkListDescription.Name = "chkListDescription";
            this.chkListDescription.Size = new System.Drawing.Size(428, 17);
            this.chkListDescription.TabIndex = 4;
            this.chkListDescription.TabStop = false;
            this.chkListDescription.Text = "Fitra per Descrizione/Class.Merceologica";
            // 
            // btnListino
            // 
            this.btnListino.BackColor = System.Drawing.SystemColors.Control;
            this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListino.ImageIndex = 0;
            this.btnListino.Location = new System.Drawing.Point(6, 71);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(104, 23);
            this.btnListino.TabIndex = 1;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtListino
            // 
            this.txtListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListino.Location = new System.Drawing.Point(6, 100);
            this.txtListino.Name = "txtListino";
            this.txtListino.Size = new System.Drawing.Size(453, 20);
            this.txtListino.TabIndex = 6;
            this.txtListino.Tag = "listview.intcode?assetview.intcode";
            this.txtListino.TextChanged += new System.EventHandler(this.txtListino_TextChanged);
            this.txtListino.Enter += new System.EventHandler(this.txtListino_Enter);
            this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(139, 37);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(320, 57);
            this.txtDescrizioneListino.TabIndex = 9;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "listview.description";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Location = new System.Drawing.Point(674, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 38);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anno inizio esistenza";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(5, 13);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(88, 20);
            this.textBox6.TabIndex = 0;
            this.textBox6.Tag = "assetview.yearstart?assetview.yearstart";
            // 
            // gboxCategoria
            // 
            this.gboxCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCategoria.Controls.Add(this.textBox5);
            this.gboxCategoria.Location = new System.Drawing.Point(800, 9);
            this.gboxCategoria.Name = "gboxCategoria";
            this.gboxCategoria.Size = new System.Drawing.Size(76, 38);
            this.gboxCategoria.TabIndex = 4;
            this.gboxCategoria.TabStop = false;
            this.gboxCategoria.Text = "Categoria";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(4, 13);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(70, 20);
            this.textBox5.TabIndex = 0;
            this.textBox5.Tag = "assetview.codeinv_lev1?assetview.codeinv_lev1";
            // 
            // gboxPrincipale
            // 
            this.gboxPrincipale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxPrincipale.Controls.Add(this.label30);
            this.gboxPrincipale.Controls.Add(this.txtRfid);
            this.gboxPrincipale.Controls.Add(this.label25);
            this.gboxPrincipale.Controls.Add(this.textBox1);
            this.gboxPrincipale.Controls.Add(this.lab5b);
            this.gboxPrincipale.Controls.Add(this.label13);
            this.gboxPrincipale.Controls.Add(this.chkTrasmitted);
            this.gboxPrincipale.Controls.Add(this.cboInventario);
            this.gboxPrincipale.Controls.Add(this.label14);
            this.gboxPrincipale.Controls.Add(this.txtNumInv);
            this.gboxPrincipale.Controls.Add(this.txtDescrizione);
            this.gboxPrincipale.Location = new System.Drawing.Point(8, 5);
            this.gboxPrincipale.Name = "gboxPrincipale";
            this.gboxPrincipale.Size = new System.Drawing.Size(482, 169);
            this.gboxPrincipale.TabIndex = 0;
            this.gboxPrincipale.TabStop = false;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(297, 48);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 16);
            this.label30.TabIndex = 10;
            this.label30.Tag = "";
            this.label30.Text = "Rfid";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRfid
            // 
            this.txtRfid.Location = new System.Drawing.Point(339, 47);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(134, 20);
            this.txtRfid.TabIndex = 4;
            this.txtRfid.Tag = "asset.rfid";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(179, 48);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 8;
            this.label25.Tag = "";
            this.label25.Text = "N.parte";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(238, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "asset.idpiece";
            // 
            // lab5b
            // 
            this.lab5b.Location = new System.Drawing.Point(8, 73);
            this.lab5b.Name = "lab5b";
            this.lab5b.Size = new System.Drawing.Size(71, 16);
            this.lab5b.TabIndex = 4;
            this.lab5b.Text = "Descrizione";
            this.lab5b.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Inventario";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTrasmitted
            // 
            this.chkTrasmitted.AutoSize = true;
            this.chkTrasmitted.Location = new System.Drawing.Point(299, 72);
            this.chkTrasmitted.Name = "chkTrasmitted";
            this.chkTrasmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTrasmitted.TabIndex = 6;
            this.chkTrasmitted.TabStop = false;
            this.chkTrasmitted.Tag = "asset.transmitted:S:N";
            this.chkTrasmitted.Text = "Trasmesso";
            this.chkTrasmitted.UseVisualStyleBackColor = true;
            // 
            // cboInventario
            // 
            this.cboInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInventario.DataSource = this.DS.inventory;
            this.cboInventario.DisplayMember = "description";
            this.cboInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInventario.Location = new System.Drawing.Point(81, 16);
            this.cboInventario.Name = "cboInventario";
            this.cboInventario.Size = new System.Drawing.Size(393, 21);
            this.cboInventario.TabIndex = 1;
            this.cboInventario.Tag = "assetview.idinventory.(active=\'S\')?assetview.idinventory";
            this.cboInventario.ValueMember = "idinventory";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Numero";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumInv
            // 
            this.txtNumInv.Location = new System.Drawing.Point(81, 46);
            this.txtNumInv.Name = "txtNumInv";
            this.txtNumInv.Size = new System.Drawing.Size(96, 20);
            this.txtNumInv.TabIndex = 2;
            this.txtNumInv.Tag = "asset.ninventory";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 91);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(462, 68);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.Tag = "assetacquireview.description?assetview.description";
            // 
            // gboxScarico
            // 
            this.gboxScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxScarico.Controls.Add(this.txtRatificaScarico);
            this.gboxScarico.Controls.Add(this.label28);
            this.gboxScarico.Controls.Add(this.chkTransf);
            this.gboxScarico.Controls.Add(this.label24);
            this.gboxScarico.Controls.Add(this.cmbCausaleScarico);
            this.gboxScarico.Controls.Add(this.chkUnload);
            this.gboxScarico.Controls.Add(this.chkIncludes);
            this.gboxScarico.Controls.Add(this.cmbTipoBuonoScarico);
            this.gboxScarico.Controls.Add(this.label18);
            this.gboxScarico.Controls.Add(this.txtNumBuonoScarico);
            this.gboxScarico.Controls.Add(this.txtEsercBuonoScarico);
            this.gboxScarico.Controls.Add(this.label17);
            this.gboxScarico.Location = new System.Drawing.Point(8, 426);
            this.gboxScarico.Name = "gboxScarico";
            this.gboxScarico.Size = new System.Drawing.Size(958, 102);
            this.gboxScarico.TabIndex = 9;
            this.gboxScarico.TabStop = false;
            this.gboxScarico.Text = "Informazioni sullo scarico";
            this.gboxScarico.Enter += new System.EventHandler(this.gboxScarico_Enter);
            // 
            // txtRatificaScarico
            // 
            this.txtRatificaScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRatificaScarico.Location = new System.Drawing.Point(250, 76);
            this.txtRatificaScarico.Name = "txtRatificaScarico";
            this.txtRatificaScarico.Size = new System.Drawing.Size(100, 20);
            this.txtRatificaScarico.TabIndex = 39;
            this.txtRatificaScarico.Tag = " assetunload.ratificationdate?assetview.unloadratificationdate";
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.Location = new System.Drawing.Point(151, 76);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(83, 16);
            this.label28.TabIndex = 40;
            this.label28.Text = "Ratifica scarico";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkTransf
            // 
            this.chkTransf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTransf.Location = new System.Drawing.Point(502, 46);
            this.chkTransf.Name = "chkTransf";
            this.chkTransf.Size = new System.Drawing.Size(240, 26);
            this.chkTransf.TabIndex = 38;
            this.chkTransf.Tag = "asset.flag:2";
            this.chkTransf.Text = "Pronto per il trasferimento di Inventario";
            this.chkTransf.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(11, 45);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(107, 24);
            this.label24.TabIndex = 37;
            this.label24.Text = "Causale di scarico";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCausaleScarico
            // 
            this.cmbCausaleScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausaleScarico.DataSource = this.DS.assetunloadmotive;
            this.cmbCausaleScarico.DisplayMember = "description";
            this.cmbCausaleScarico.Location = new System.Drawing.Point(130, 45);
            this.cmbCausaleScarico.Name = "cmbCausaleScarico";
            this.cmbCausaleScarico.Size = new System.Drawing.Size(352, 21);
            this.cmbCausaleScarico.TabIndex = 36;
            this.cmbCausaleScarico.Tag = "assetunload.idmot?assetview.idunloadmot";
            this.cmbCausaleScarico.ValueMember = "idmot";
            // 
            // chkUnload
            // 
            this.chkUnload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkUnload.Location = new System.Drawing.Point(780, 49);
            this.chkUnload.Name = "chkUnload";
            this.chkUnload.Size = new System.Drawing.Size(165, 20);
            this.chkUnload.TabIndex = 35;
            this.chkUnload.Tag = "asset.flag:1";
            this.chkUnload.Text = "Pronto per lo scarico";
            this.chkUnload.UseVisualStyleBackColor = true;
            // 
            // chkIncludes
            // 
            this.chkIncludes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludes.Location = new System.Drawing.Point(681, 18);
            this.chkIncludes.Name = "chkIncludes";
            this.chkIncludes.Size = new System.Drawing.Size(165, 20);
            this.chkIncludes.TabIndex = 34;
            this.chkIncludes.Tag = "asset.flag:0";
            this.chkIncludes.Text = "Includi in buono di scarico";
            this.chkIncludes.UseVisualStyleBackColor = true;
            // 
            // cmbTipoBuonoScarico
            // 
            this.cmbTipoBuonoScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoBuonoScarico.DataSource = this.DS.assetunloadkind;
            this.cmbTipoBuonoScarico.DisplayMember = "description";
            this.cmbTipoBuonoScarico.Location = new System.Drawing.Point(130, 16);
            this.cmbTipoBuonoScarico.Name = "cmbTipoBuonoScarico";
            this.cmbTipoBuonoScarico.Size = new System.Drawing.Size(352, 21);
            this.cmbTipoBuonoScarico.TabIndex = 1;
            this.cmbTipoBuonoScarico.Tag = "assetunload.idassetunloadkind.(active=\'S\')?assetview.idassetunloadkind";
            this.cmbTipoBuonoScarico.ValueMember = "idassetunloadkind";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(550, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(8, 23);
            this.label18.TabIndex = 29;
            this.label18.Text = "/";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumBuonoScarico
            // 
            this.txtNumBuonoScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumBuonoScarico.Location = new System.Drawing.Point(566, 19);
            this.txtNumBuonoScarico.Name = "txtNumBuonoScarico";
            this.txtNumBuonoScarico.Size = new System.Drawing.Size(80, 20);
            this.txtNumBuonoScarico.TabIndex = 3;
            this.txtNumBuonoScarico.Tag = "assetunload.nassetunload?assetview.nassetunload";
            // 
            // txtEsercBuonoScarico
            // 
            this.txtEsercBuonoScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercBuonoScarico.Location = new System.Drawing.Point(502, 19);
            this.txtEsercBuonoScarico.Name = "txtEsercBuonoScarico";
            this.txtEsercBuonoScarico.Size = new System.Drawing.Size(40, 20);
            this.txtEsercBuonoScarico.TabIndex = 2;
            this.txtEsercBuonoScarico.Tag = "assetunload.yassetunload?assetview.yassetunload";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(31, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 23);
            this.label17.TabIndex = 25;
            this.label17.Text = "Buono di scarico";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxCarico
            // 
            this.gboxCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCarico.Controls.Add(this.txtRatificaCarico);
            this.gboxCarico.Controls.Add(this.label29);
            this.gboxCarico.Controls.Add(this.label15);
            this.gboxCarico.Controls.Add(this.label3);
            this.gboxCarico.Controls.Add(this.label23);
            this.gboxCarico.Controls.Add(this.cmbCausaleCarico);
            this.gboxCarico.Controls.Add(this.cmbTipoBuonoCarico);
            this.gboxCarico.Controls.Add(this.label16);
            this.gboxCarico.Controls.Add(this.txtNumBuonoCarico);
            this.gboxCarico.Controls.Add(this.txtEsercBuonoCarico);
            this.gboxCarico.Controls.Add(this.grpValore);
            this.gboxCarico.Location = new System.Drawing.Point(8, 276);
            this.gboxCarico.Name = "gboxCarico";
            this.gboxCarico.Size = new System.Drawing.Size(958, 148);
            this.gboxCarico.TabIndex = 8;
            this.gboxCarico.TabStop = false;
            this.gboxCarico.Text = "Buono di carico";
            // 
            // txtRatificaCarico
            // 
            this.txtRatificaCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRatificaCarico.Location = new System.Drawing.Point(341, 84);
            this.txtRatificaCarico.Name = "txtRatificaCarico";
            this.txtRatificaCarico.Size = new System.Drawing.Size(100, 20);
            this.txtRatificaCarico.TabIndex = 41;
            this.txtRatificaCarico.Tag = " assetacquireview.ratificationdate?assetview.ratificationdate";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.Location = new System.Drawing.Point(249, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(83, 16);
            this.label29.TabIndex = 42;
            this.label29.Text = "Ratifica carico";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(39, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Anno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tipo";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(12, 83);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(107, 22);
            this.label23.TabIndex = 25;
            this.label23.Text = "Causale di carico";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCausaleCarico
            // 
            this.cmbCausaleCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCausaleCarico.DataSource = this.DS.assetloadmotive;
            this.cmbCausaleCarico.DisplayMember = "description";
            this.cmbCausaleCarico.Location = new System.Drawing.Point(11, 108);
            this.cmbCausaleCarico.Name = "cmbCausaleCarico";
            this.cmbCausaleCarico.Size = new System.Drawing.Size(430, 21);
            this.cmbCausaleCarico.TabIndex = 24;
            this.cmbCausaleCarico.Tag = "assetacquireview.idmot?assetview.idloadmot";
            this.cmbCausaleCarico.ValueMember = "idmot";
            // 
            // cmbTipoBuonoCarico
            // 
            this.cmbTipoBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoBuonoCarico.DataSource = this.DS.assetloadkind;
            this.cmbTipoBuonoCarico.DisplayMember = "description";
            this.cmbTipoBuonoCarico.Location = new System.Drawing.Point(89, 26);
            this.cmbTipoBuonoCarico.Name = "cmbTipoBuonoCarico";
            this.cmbTipoBuonoCarico.Size = new System.Drawing.Size(366, 21);
            this.cmbTipoBuonoCarico.TabIndex = 1;
            this.cmbTipoBuonoCarico.Tag = "assetacquireview.idassetloadkind.(active=\'S\')?assetview.idassetloadkind";
            this.cmbTipoBuonoCarico.ValueMember = "idassetloadkind";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(148, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 23);
            this.label16.TabIndex = 23;
            this.label16.Text = "N.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumBuonoCarico
            // 
            this.txtNumBuonoCarico.Location = new System.Drawing.Point(190, 58);
            this.txtNumBuonoCarico.Name = "txtNumBuonoCarico";
            this.txtNumBuonoCarico.Size = new System.Drawing.Size(80, 20);
            this.txtNumBuonoCarico.TabIndex = 3;
            this.txtNumBuonoCarico.Tag = "assetacquireview.nassetload?assetview.nassetload";
            // 
            // txtEsercBuonoCarico
            // 
            this.txtEsercBuonoCarico.Location = new System.Drawing.Point(90, 58);
            this.txtEsercBuonoCarico.Name = "txtEsercBuonoCarico";
            this.txtEsercBuonoCarico.Size = new System.Drawing.Size(40, 20);
            this.txtEsercBuonoCarico.TabIndex = 2;
            this.txtEsercBuonoCarico.Tag = "assetacquireview.yassetload?assetview.yassetload";
            // 
            // grpValore
            // 
            this.grpValore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpValore.Controls.Add(this.textBox4);
            this.grpValore.Controls.Add(this.label19);
            this.grpValore.Controls.Add(this.textBox2);
            this.grpValore.Controls.Add(this.label11);
            this.grpValore.Controls.Add(this.txtImpConIVA);
            this.grpValore.Controls.Add(this.label6);
            this.grpValore.Controls.Add(this.txtImposta);
            this.grpValore.Controls.Add(this.txtSconto);
            this.grpValore.Controls.Add(this.txtImpostaTotale);
            this.grpValore.Controls.Add(this.label12);
            this.grpValore.Controls.Add(this.label9);
            this.grpValore.Controls.Add(this.label8);
            this.grpValore.Controls.Add(this.txtImponibile);
            this.grpValore.Controls.Add(this.label7);
            this.grpValore.Location = new System.Drawing.Point(486, 15);
            this.grpValore.Name = "grpValore";
            this.grpValore.Size = new System.Drawing.Size(464, 125);
            this.grpValore.TabIndex = 6;
            this.grpValore.TabStop = false;
            this.grpValore.Text = "Valore iniziale";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(368, 44);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(80, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "assetview.tax.C?assetview.tax.C";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(248, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 16);
            this.label19.TabIndex = 10;
            this.label19.Text = "IVA totale";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(80, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Tag = "assetview.total?assetview.total";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(17, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Importo totale";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpConIVA
            // 
            this.txtImpConIVA.Location = new System.Drawing.Point(368, 93);
            this.txtImpConIVA.Name = "txtImpConIVA";
            this.txtImpConIVA.Size = new System.Drawing.Size(80, 20);
            this.txtImpConIVA.TabIndex = 7;
            this.txtImpConIVA.TabStop = false;
            this.txtImpConIVA.Tag = "assetview.cost.C?assetview.cost.C";
            this.txtImpConIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(248, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Costo effettivo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImposta
            // 
            this.txtImposta.Location = new System.Drawing.Point(368, 20);
            this.txtImposta.Name = "txtImposta";
            this.txtImposta.Size = new System.Drawing.Size(80, 20);
            this.txtImposta.TabIndex = 2;
            this.txtImposta.Tag = "assetview.taxrate.fixed.4..%.100?assetview.taxrate.fixed.4..%.100";
            // 
            // txtSconto
            // 
            this.txtSconto.Location = new System.Drawing.Point(144, 40);
            this.txtSconto.Name = "txtSconto";
            this.txtSconto.Size = new System.Drawing.Size(80, 20);
            this.txtSconto.TabIndex = 3;
            this.txtSconto.Tag = "assetview.discount.fixed.4..%.100?assetview.discount.fixed.4..%.100";
            // 
            // txtImpostaTotale
            // 
            this.txtImpostaTotale.Location = new System.Drawing.Point(368, 68);
            this.txtImpostaTotale.Name = "txtImpostaTotale";
            this.txtImpostaTotale.Size = new System.Drawing.Size(80, 20);
            this.txtImpostaTotale.TabIndex = 4;
            this.txtImpostaTotale.TabStop = false;
            this.txtImpostaTotale.Tag = "assetview.unabatable.c?assetview.unabatable.c";
            this.txtImpostaTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(58, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Sconto";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(248, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "IVA indetraibile";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(248, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Aliquota IVA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(144, 16);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.Size = new System.Drawing.Size(80, 20);
            this.txtImponibile.TabIndex = 1;
            this.txtImponibile.Tag = "assetview.taxable?assetview.taxable";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(58, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Imponibile";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataCreazione
            // 
            this.txtDataCreazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataCreazione.Location = new System.Drawing.Point(570, 25);
            this.txtDataCreazione.Name = "txtDataCreazione";
            this.txtDataCreazione.Size = new System.Drawing.Size(100, 20);
            this.txtDataCreazione.TabIndex = 2;
            this.txtDataCreazione.Tag = "asset.lifestart";
            // 
            // grpClassif
            // 
            this.grpClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(504, 184);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(467, 93);
            this.grpClassif.TabIndex = 7;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione ";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Location = new System.Drawing.Point(199, 13);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(260, 72);
            this.txtDescClassif.TabIndex = 3;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtIdClassif
            // 
            this.txtIdClassif.Location = new System.Drawing.Point(6, 65);
            this.txtIdClassif.Name = "txtIdClassif";
            this.txtIdClassif.Size = new System.Drawing.Size(187, 20);
            this.txtIdClassif.TabIndex = 1;
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetview.codeinv";
            // 
            // btnClassif
            // 
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(6, 36);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(112, 23);
            this.btnClassif.TabIndex = 1;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            this.btnClassif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(570, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Inizio Esistenza:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSituazione
            // 
            this.btnSituazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSituazione.Location = new System.Drawing.Point(881, 19);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(83, 23);
            this.btnSituazione.TabIndex = 9;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // txtIdBene
            // 
            this.txtIdBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdBene.Location = new System.Drawing.Point(497, 26);
            this.txtIdBene.Name = "txtIdBene";
            this.txtIdBene.Size = new System.Drawing.Size(64, 20);
            this.txtIdBene.TabIndex = 1;
            this.txtIdBene.Tag = "asset.idasset";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(496, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "N.cespite";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabAltriDati
            // 
            this.tabAltriDati.Controls.Add(this.grpUbicazioneAttuale);
            this.tabAltriDati.Controls.Add(this.grpRespAttuale);
            this.tabAltriDati.Controls.Add(this.gboxUbicazione);
            this.tabAltriDati.Controls.Add(this.gboxResponsabile);
            this.tabAltriDati.Location = new System.Drawing.Point(4, 22);
            this.tabAltriDati.Name = "tabAltriDati";
            this.tabAltriDati.Size = new System.Drawing.Size(974, 533);
            this.tabAltriDati.TabIndex = 3;
            this.tabAltriDati.Text = "Responsabile e Ubicazione";
            this.tabAltriDati.UseVisualStyleBackColor = true;
            // 
            // grpUbicazioneAttuale
            // 
            this.grpUbicazioneAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazioneAttuale.Controls.Add(this.btnUbicazioneAttuale);
            this.grpUbicazioneAttuale.Controls.Add(this.txtDescUbicazAttuale);
            this.grpUbicazioneAttuale.Controls.Add(this.txtUbicazioneAttuale);
            this.grpUbicazioneAttuale.Location = new System.Drawing.Point(3, 458);
            this.grpUbicazioneAttuale.Name = "grpUbicazioneAttuale";
            this.grpUbicazioneAttuale.Size = new System.Drawing.Size(958, 72);
            this.grpUbicazioneAttuale.TabIndex = 24;
            this.grpUbicazioneAttuale.TabStop = false;
            this.grpUbicazioneAttuale.Tag = "AutoManage.txtUbicazioneAttuale.tree";
            this.grpUbicazioneAttuale.Text = "Ubicazione attuale";
            // 
            // btnUbicazioneAttuale
            // 
            this.btnUbicazioneAttuale.Location = new System.Drawing.Point(8, 16);
            this.btnUbicazioneAttuale.Name = "btnUbicazioneAttuale";
            this.btnUbicazioneAttuale.Size = new System.Drawing.Size(128, 23);
            this.btnUbicazioneAttuale.TabIndex = 6;
            this.btnUbicazioneAttuale.TabStop = false;
            this.btnUbicazioneAttuale.Tag = "manage.locationview.tree";
            this.btnUbicazioneAttuale.Text = "Ubicazione attuale";
            // 
            // txtDescUbicazAttuale
            // 
            this.txtDescUbicazAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazAttuale.Location = new System.Drawing.Point(210, 16);
            this.txtDescUbicazAttuale.Multiline = true;
            this.txtDescUbicazAttuale.Name = "txtDescUbicazAttuale";
            this.txtDescUbicazAttuale.ReadOnly = true;
            this.txtDescUbicazAttuale.Size = new System.Drawing.Size(740, 48);
            this.txtDescUbicazAttuale.TabIndex = 8;
            this.txtDescUbicazAttuale.TabStop = false;
            this.txtDescUbicazAttuale.Tag = "locationview.description";
            // 
            // txtUbicazioneAttuale
            // 
            this.txtUbicazioneAttuale.Location = new System.Drawing.Point(8, 40);
            this.txtUbicazioneAttuale.Name = "txtUbicazioneAttuale";
            this.txtUbicazioneAttuale.Size = new System.Drawing.Size(196, 20);
            this.txtUbicazioneAttuale.TabIndex = 1;
            this.txtUbicazioneAttuale.Tag = "locationview.locationcode?assetview.currlocationcode";
            // 
            // grpRespAttuale
            // 
            this.grpRespAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRespAttuale.Controls.Add(this.txtResponsabile);
            this.grpRespAttuale.Location = new System.Drawing.Point(8, 203);
            this.grpRespAttuale.Name = "grpRespAttuale";
            this.grpRespAttuale.Size = new System.Drawing.Size(958, 56);
            this.grpRespAttuale.TabIndex = 23;
            this.grpRespAttuale.TabStop = false;
            this.grpRespAttuale.Tag = "AutoChoose.txtResponsabile.default.(active=\'S\')";
            this.grpRespAttuale.Text = "Responsabile attuale";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(8, 22);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(942, 20);
            this.txtResponsabile.TabIndex = 1;
            this.txtResponsabile.Tag = "manager1.title?assetview.currmanager";
            // 
            // gboxUbicazione
            // 
            this.gboxUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUbicazione.Controls.Add(this.dataGrid1);
            this.gboxUbicazione.Controls.Add(this.btnEliminaQuota);
            this.gboxUbicazione.Controls.Add(this.btnModificaQuota);
            this.gboxUbicazione.Controls.Add(this.btnInserisciQuota);
            this.gboxUbicazione.Location = new System.Drawing.Point(8, 265);
            this.gboxUbicazione.Name = "gboxUbicazione";
            this.gboxUbicazione.Size = new System.Drawing.Size(958, 187);
            this.gboxUbicazione.TabIndex = 2;
            this.gboxUbicazione.TabStop = false;
            this.gboxUbicazione.Text = "Ubicazione";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.CaptionVisible = false;
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(96, 19);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(854, 162);
            this.dataGrid1.TabIndex = 19;
            this.dataGrid1.Tag = "assetlocation.detail.single";
            // 
            // btnEliminaQuota
            // 
            this.btnEliminaQuota.Location = new System.Drawing.Point(8, 83);
            this.btnEliminaQuota.Name = "btnEliminaQuota";
            this.btnEliminaQuota.Size = new System.Drawing.Size(75, 24);
            this.btnEliminaQuota.TabIndex = 18;
            this.btnEliminaQuota.TabStop = false;
            this.btnEliminaQuota.Tag = "delete";
            this.btnEliminaQuota.Text = "Elimina";
            // 
            // btnModificaQuota
            // 
            this.btnModificaQuota.Location = new System.Drawing.Point(8, 51);
            this.btnModificaQuota.Name = "btnModificaQuota";
            this.btnModificaQuota.Size = new System.Drawing.Size(75, 24);
            this.btnModificaQuota.TabIndex = 17;
            this.btnModificaQuota.TabStop = false;
            this.btnModificaQuota.Tag = "edit.single";
            this.btnModificaQuota.Text = "Modifica";
            // 
            // btnInserisciQuota
            // 
            this.btnInserisciQuota.Location = new System.Drawing.Point(8, 19);
            this.btnInserisciQuota.Name = "btnInserisciQuota";
            this.btnInserisciQuota.Size = new System.Drawing.Size(75, 24);
            this.btnInserisciQuota.TabIndex = 16;
            this.btnInserisciQuota.TabStop = false;
            this.btnInserisciQuota.Tag = "insert.single";
            this.btnInserisciQuota.Text = "Inserisci";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxResponsabile.Controls.Add(this.button1);
            this.gboxResponsabile.Controls.Add(this.button2);
            this.gboxResponsabile.Controls.Add(this.button3);
            this.gboxResponsabile.Controls.Add(this.dataGrid2);
            this.gboxResponsabile.Location = new System.Drawing.Point(8, 8);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(958, 189);
            this.gboxResponsabile.TabIndex = 1;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.Tag = "insert.single";
            this.button1.Text = "Inserisci";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.Tag = "delete";
            this.button2.Text = "Elimina";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 51);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 8;
            this.button3.TabStop = false;
            this.button3.Tag = "edit.single";
            this.button3.Text = "Modifica";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.CaptionVisible = false;
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(96, 19);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(846, 164);
            this.dataGrid2.TabIndex = 10;
            this.dataGrid2.Tag = "assetmanager.detail.single";
            // 
            // tabAmmortamenti
            // 
            this.tabAmmortamenti.Controls.Add(this.gboxOperazioni);
            this.tabAmmortamenti.Controls.Add(this.grpAmmortamento);
            this.tabAmmortamenti.Controls.Add(this.gboxaccessoriposseduti);
            this.tabAmmortamenti.Controls.Add(this.gboxammortamenti);
            this.tabAmmortamenti.Location = new System.Drawing.Point(4, 22);
            this.tabAmmortamenti.Name = "tabAmmortamenti";
            this.tabAmmortamenti.Padding = new System.Windows.Forms.Padding(3);
            this.tabAmmortamenti.Size = new System.Drawing.Size(974, 533);
            this.tabAmmortamenti.TabIndex = 7;
            this.tabAmmortamenti.Text = "Operazioni";
            this.tabAmmortamenti.UseVisualStyleBackColor = true;
            // 
            // gboxOperazioni
            // 
            this.gboxOperazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxOperazioni.Controls.Add(this.chkInventarioVisibile);
            this.gboxOperazioni.Controls.Add(this.label27);
            this.gboxOperazioni.Controls.Add(this.txtRevalPending);
            this.gboxOperazioni.Controls.Add(this.label5);
            this.gboxOperazioni.Controls.Add(this.chkCaricato);
            this.gboxOperazioni.Controls.Add(this.chkPosseduto);
            this.gboxOperazioni.Controls.Add(this.chkScaricato);
            this.gboxOperazioni.Controls.Add(this.txtValoreCarico);
            this.gboxOperazioni.Controls.Add(this.chkAccessorio);
            this.gboxOperazioni.Controls.Add(this.labpartipossedute);
            this.gboxOperazioni.Controls.Add(this.txtpartipossedute);
            this.gboxOperazioni.Controls.Add(this.label26);
            this.gboxOperazioni.Controls.Add(this.txtValoreAttuale);
            this.gboxOperazioni.Controls.Add(this.txtAmmortamenti);
            this.gboxOperazioni.Controls.Add(this.labelAttuale);
            this.gboxOperazioni.Location = new System.Drawing.Point(8, 382);
            this.gboxOperazioni.Name = "gboxOperazioni";
            this.gboxOperazioni.Size = new System.Drawing.Size(956, 145);
            this.gboxOperazioni.TabIndex = 14;
            this.gboxOperazioni.TabStop = false;
            this.gboxOperazioni.Text = "Riepilogo";
            // 
            // chkInventarioVisibile
            // 
            this.chkInventarioVisibile.AutoSize = true;
            this.chkInventarioVisibile.Location = new System.Drawing.Point(430, 110);
            this.chkInventarioVisibile.Name = "chkInventarioVisibile";
            this.chkInventarioVisibile.Size = new System.Drawing.Size(193, 17);
            this.chkInventarioVisibile.TabIndex = 16;
            this.chkInventarioVisibile.Tag = "assetview.inventorykindvisible:S:N?assetview.inventorykindvisible:S:N";
            this.chkInventarioVisibile.Text = "Inventario visibile in sit. patrimoniale";
            this.chkInventarioVisibile.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(307, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(117, 13);
            this.label27.TabIndex = 14;
            this.label27.Text = "Ammortamenti pendenti";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRevalPending
            // 
            this.txtRevalPending.Location = new System.Drawing.Point(430, 77);
            this.txtRevalPending.Name = "txtRevalPending";
            this.txtRevalPending.ReadOnly = true;
            this.txtRevalPending.Size = new System.Drawing.Size(120, 20);
            this.txtRevalPending.TabIndex = 15;
            this.txtRevalPending.Tag = "assetview.revals_pending";
            this.txtRevalPending.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Valore di carico";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCaricato
            // 
            this.chkCaricato.AutoSize = true;
            this.chkCaricato.Location = new System.Drawing.Point(599, 12);
            this.chkCaricato.Name = "chkCaricato";
            this.chkCaricato.Size = new System.Drawing.Size(65, 17);
            this.chkCaricato.TabIndex = 10;
            this.chkCaricato.Tag = "assetview.is_loaded:S:N?assetview.is_loaded:S:N";
            this.chkCaricato.Text = "Caricato";
            this.chkCaricato.UseVisualStyleBackColor = true;
            // 
            // chkPosseduto
            // 
            this.chkPosseduto.AutoSize = true;
            this.chkPosseduto.Enabled = false;
            this.chkPosseduto.Location = new System.Drawing.Point(430, 35);
            this.chkPosseduto.Name = "chkPosseduto";
            this.chkPosseduto.Size = new System.Drawing.Size(146, 17);
            this.chkPosseduto.TabIndex = 13;
            this.chkPosseduto.Tag = "assetview.loadkind:R:N?assetview.loadkind:R:N";
            this.chkPosseduto.Text = "Caricato come posseduto";
            this.chkPosseduto.UseVisualStyleBackColor = true;
            // 
            // chkScaricato
            // 
            this.chkScaricato.AutoSize = true;
            this.chkScaricato.Location = new System.Drawing.Point(599, 35);
            this.chkScaricato.Name = "chkScaricato";
            this.chkScaricato.Size = new System.Drawing.Size(71, 17);
            this.chkScaricato.TabIndex = 11;
            this.chkScaricato.Tag = "assetview.is_unloaded:S:N?assetview.is_unloaded:S:N";
            this.chkScaricato.Text = "Scaricato";
            this.chkScaricato.UseVisualStyleBackColor = true;
            // 
            // txtValoreCarico
            // 
            this.txtValoreCarico.Location = new System.Drawing.Point(166, 13);
            this.txtValoreCarico.Name = "txtValoreCarico";
            this.txtValoreCarico.ReadOnly = true;
            this.txtValoreCarico.Size = new System.Drawing.Size(120, 20);
            this.txtValoreCarico.TabIndex = 3;
            this.txtValoreCarico.Tag = "assetview.cost";
            this.txtValoreCarico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkAccessorio
            // 
            this.chkAccessorio.AutoSize = true;
            this.chkAccessorio.Enabled = false;
            this.chkAccessorio.Location = new System.Drawing.Point(430, 12);
            this.chkAccessorio.Name = "chkAccessorio";
            this.chkAccessorio.Size = new System.Drawing.Size(78, 17);
            this.chkAccessorio.TabIndex = 12;
            this.chkAccessorio.Tag = "assetview.ispiece:S:N?assetview.ispiece:S:N";
            this.chkAccessorio.Text = "Accessorio";
            this.chkAccessorio.UseVisualStyleBackColor = true;
            // 
            // labpartipossedute
            // 
            this.labpartipossedute.AutoSize = true;
            this.labpartipossedute.Location = new System.Drawing.Point(21, 50);
            this.labpartipossedute.Name = "labpartipossedute";
            this.labpartipossedute.Size = new System.Drawing.Size(139, 13);
            this.labpartipossedute.TabIndex = 4;
            this.labpartipossedute.Text = "Scarico accessori posseduti";
            this.labpartipossedute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtpartipossedute
            // 
            this.txtpartipossedute.Location = new System.Drawing.Point(166, 43);
            this.txtpartipossedute.Name = "txtpartipossedute";
            this.txtpartipossedute.ReadOnly = true;
            this.txtpartipossedute.Size = new System.Drawing.Size(120, 20);
            this.txtpartipossedute.TabIndex = 5;
            this.txtpartipossedute.Tag = "assetview.subtractions";
            this.txtpartipossedute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(87, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "Ammortamenti";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValoreAttuale
            // 
            this.txtValoreAttuale.Location = new System.Drawing.Point(166, 106);
            this.txtValoreAttuale.Name = "txtValoreAttuale";
            this.txtValoreAttuale.ReadOnly = true;
            this.txtValoreAttuale.Size = new System.Drawing.Size(120, 20);
            this.txtValoreAttuale.TabIndex = 9;
            this.txtValoreAttuale.Tag = "assetview.currentvalue";
            this.txtValoreAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmmortamenti
            // 
            this.txtAmmortamenti.Location = new System.Drawing.Point(166, 74);
            this.txtAmmortamenti.Name = "txtAmmortamenti";
            this.txtAmmortamenti.ReadOnly = true;
            this.txtAmmortamenti.Size = new System.Drawing.Size(120, 20);
            this.txtAmmortamenti.TabIndex = 7;
            this.txtAmmortamenti.Tag = "assetview.revals";
            this.txtAmmortamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelAttuale
            // 
            this.labelAttuale.Location = new System.Drawing.Point(14, 109);
            this.labelAttuale.Name = "labelAttuale";
            this.labelAttuale.Size = new System.Drawing.Size(146, 17);
            this.labelAttuale.TabIndex = 8;
            this.labelAttuale.Text = "Valore attuale";
            this.labelAttuale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAmmortamento
            // 
            this.grpAmmortamento.Controls.Add(this.cmbAmmortamento);
            this.grpAmmortamento.Controls.Add(this.button10);
            this.grpAmmortamento.Controls.Add(this.textBox7);
            this.grpAmmortamento.Controls.Add(this.textBox8);
            this.grpAmmortamento.Controls.Add(this.label2);
            this.grpAmmortamento.Location = new System.Drawing.Point(10, 190);
            this.grpAmmortamento.Name = "grpAmmortamento";
            this.grpAmmortamento.Size = new System.Drawing.Size(875, 63);
            this.grpAmmortamento.TabIndex = 32;
            this.grpAmmortamento.TabStop = false;
            this.grpAmmortamento.Text = "Ammortamento";
            // 
            // cmbAmmortamento
            // 
            this.cmbAmmortamento.DataSource = this.DS.inventoryamortization;
            this.cmbAmmortamento.DisplayMember = "description";
            this.cmbAmmortamento.Location = new System.Drawing.Point(132, 15);
            this.cmbAmmortamento.Name = "cmbAmmortamento";
            this.cmbAmmortamento.Size = new System.Drawing.Size(286, 21);
            this.cmbAmmortamento.TabIndex = 29;
            this.cmbAmmortamento.Tag = "asset.idinventoryamortization";
            this.cmbAmmortamento.ValueMember = "idinventoryamortization";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 14);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(120, 23);
            this.button10.TabIndex = 28;
            this.button10.Tag = "choose.inventoryamortization.default";
            this.button10.Text = "Tipo Ammortamento";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(328, 37);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(90, 20);
            this.textBox7.TabIndex = 27;
            this.textBox7.Tag = "asset.amortizationquota.fixed.6..%.100";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(423, 10);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(446, 47);
            this.textBox8.TabIndex = 26;
            this.textBox8.TabStop = false;
            this.textBox8.Text = resources.GetString("textBox8.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Percentuale ammortamento";
            // 
            // gboxaccessoriposseduti
            // 
            this.gboxaccessoriposseduti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxaccessoriposseduti.Controls.Add(this.gridpartiscaricate);
            this.gboxaccessoriposseduti.Location = new System.Drawing.Point(10, 262);
            this.gboxaccessoriposseduti.Name = "gboxaccessoriposseduti";
            this.gboxaccessoriposseduti.Size = new System.Drawing.Size(954, 114);
            this.gboxaccessoriposseduti.TabIndex = 1;
            this.gboxaccessoriposseduti.TabStop = false;
            this.gboxaccessoriposseduti.Text = "Scarico accessori posseduti (sono accessori inizialmente inglobati al cespite pri" +
    "ncipale)";
            // 
            // gridpartiscaricate
            // 
            this.gridpartiscaricate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridpartiscaricate.CaptionVisible = false;
            this.gridpartiscaricate.DataMember = "";
            this.gridpartiscaricate.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridpartiscaricate.Location = new System.Drawing.Point(6, 19);
            this.gridpartiscaricate.Name = "gridpartiscaricate";
            this.gridpartiscaricate.Size = new System.Drawing.Size(942, 89);
            this.gridpartiscaricate.TabIndex = 11;
            this.gridpartiscaricate.Tag = "assetview4.cespite";
            // 
            // gboxammortamenti
            // 
            this.gboxammortamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxammortamenti.Controls.Add(this.gridAmmortamenti);
            this.gboxammortamenti.Location = new System.Drawing.Point(8, 6);
            this.gboxammortamenti.Name = "gboxammortamenti";
            this.gboxammortamenti.Size = new System.Drawing.Size(956, 181);
            this.gboxammortamenti.TabIndex = 0;
            this.gboxammortamenti.TabStop = false;
            this.gboxammortamenti.Text = "Ammortamenti";
            // 
            // gridAmmortamenti
            // 
            this.gridAmmortamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAmmortamenti.CaptionVisible = false;
            this.gridAmmortamenti.DataMember = "";
            this.gridAmmortamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAmmortamenti.Location = new System.Drawing.Point(6, 19);
            this.gridAmmortamenti.Name = "gridAmmortamenti";
            this.gridAmmortamenti.Size = new System.Drawing.Size(944, 156);
            this.gridAmmortamenti.TabIndex = 11;
            this.gridAmmortamenti.Tag = "assetamortizationview.cespite";
            // 
            // tabStorico
            // 
            this.tabStorico.Controls.Add(this.gboxInventarioDestinazione);
            this.tabStorico.Controls.Add(this.gboxInventarioProvenienza);
            this.tabStorico.Location = new System.Drawing.Point(4, 22);
            this.tabStorico.Name = "tabStorico";
            this.tabStorico.Size = new System.Drawing.Size(974, 533);
            this.tabStorico.TabIndex = 5;
            this.tabStorico.Text = "Storico";
            this.tabStorico.UseVisualStyleBackColor = true;
            this.tabStorico.Click += new System.EventHandler(this.tabStorico_Click);
            // 
            // gboxInventarioDestinazione
            // 
            this.gboxInventarioDestinazione.Controls.Add(this.cboNextAsset);
            this.gboxInventarioDestinazione.Controls.Add(this.label21);
            this.gboxInventarioDestinazione.Controls.Add(this.txtNumInvNextAsset);
            this.gboxInventarioDestinazione.Controls.Add(this.label22);
            this.gboxInventarioDestinazione.Location = new System.Drawing.Point(8, 145);
            this.gboxInventarioDestinazione.Name = "gboxInventarioDestinazione";
            this.gboxInventarioDestinazione.Size = new System.Drawing.Size(688, 37);
            this.gboxInventarioDestinazione.TabIndex = 23;
            this.gboxInventarioDestinazione.TabStop = false;
            this.gboxInventarioDestinazione.Text = "Inventario di Destinazione";
            // 
            // cboNextAsset
            // 
            this.cboNextAsset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboNextAsset.DataSource = this.DS.inventory2;
            this.cboNextAsset.DisplayMember = "description";
            this.cboNextAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNextAsset.Location = new System.Drawing.Point(205, 10);
            this.cboNextAsset.Name = "cboNextAsset";
            this.cboNextAsset.Size = new System.Drawing.Size(285, 21);
            this.cboNextAsset.TabIndex = 6;
            this.cboNextAsset.Tag = "assetview.idinventory_next?assetview.idinventory_next";
            this.cboNextAsset.ValueMember = "idinventory";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(513, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 16);
            this.label21.TabIndex = 5;
            this.label21.Text = "Numero";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumInvNextAsset
            // 
            this.txtNumInvNextAsset.Location = new System.Drawing.Point(586, 11);
            this.txtNumInvNextAsset.Name = "txtNumInvNextAsset";
            this.txtNumInvNextAsset.Size = new System.Drawing.Size(96, 20);
            this.txtNumInvNextAsset.TabIndex = 4;
            this.txtNumInvNextAsset.Tag = "assetview.ninventory_next?assetview.ninventory_next";
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(132, 12);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 3;
            this.label22.Text = "Inventario";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxInventarioProvenienza
            // 
            this.gboxInventarioProvenienza.Controls.Add(this.cboPreviousAsset);
            this.gboxInventarioProvenienza.Controls.Add(this.label20);
            this.gboxInventarioProvenienza.Controls.Add(this.txtNumInvPreviousAsset);
            this.gboxInventarioProvenienza.Controls.Add(this.label4);
            this.gboxInventarioProvenienza.Location = new System.Drawing.Point(8, 48);
            this.gboxInventarioProvenienza.Name = "gboxInventarioProvenienza";
            this.gboxInventarioProvenienza.Size = new System.Drawing.Size(688, 37);
            this.gboxInventarioProvenienza.TabIndex = 22;
            this.gboxInventarioProvenienza.TabStop = false;
            this.gboxInventarioProvenienza.Text = "Inventario di Provenienza";
            // 
            // cboPreviousAsset
            // 
            this.cboPreviousAsset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPreviousAsset.DataSource = this.DS.inventory1;
            this.cboPreviousAsset.DisplayMember = "description";
            this.cboPreviousAsset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreviousAsset.Location = new System.Drawing.Point(205, 10);
            this.cboPreviousAsset.Name = "cboPreviousAsset";
            this.cboPreviousAsset.Size = new System.Drawing.Size(285, 21);
            this.cboPreviousAsset.TabIndex = 6;
            this.cboPreviousAsset.Tag = "assetview.idinventory_prev?assetview.idinventory_prev";
            this.cboPreviousAsset.ValueMember = "idinventory";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(513, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 16);
            this.label20.TabIndex = 5;
            this.label20.Text = "Numero";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumInvPreviousAsset
            // 
            this.txtNumInvPreviousAsset.Location = new System.Drawing.Point(586, 11);
            this.txtNumInvPreviousAsset.Name = "txtNumInvPreviousAsset";
            this.txtNumInvPreviousAsset.Size = new System.Drawing.Size(96, 20);
            this.txtNumInvPreviousAsset.TabIndex = 4;
            this.txtNumInvPreviousAsset.Tag = "assetview.ninventory_prev?assetview.ninventory_prev";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Inventario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabAggiuntive
            // 
            this.tabAggiuntive.AutoScroll = true;
            this.tabAggiuntive.Location = new System.Drawing.Point(4, 22);
            this.tabAggiuntive.Name = "tabAggiuntive";
            this.tabAggiuntive.Padding = new System.Windows.Forms.Padding(3);
            this.tabAggiuntive.Size = new System.Drawing.Size(974, 533);
            this.tabAggiuntive.TabIndex = 6;
            this.tabAggiuntive.Text = "Informazioni Aggiuntive";
            this.tabAggiuntive.UseVisualStyleBackColor = true;
            // 
            // tabConsegnatario
            // 
            this.tabConsegnatario.Controls.Add(this.grpConsegnatarioAttuale);
            this.tabConsegnatario.Controls.Add(this.gboxConsegnatario);
            this.tabConsegnatario.Location = new System.Drawing.Point(4, 22);
            this.tabConsegnatario.Name = "tabConsegnatario";
            this.tabConsegnatario.Size = new System.Drawing.Size(974, 533);
            this.tabConsegnatario.TabIndex = 8;
            this.tabConsegnatario.Text = "Subconsegnatario cespite";
            this.tabConsegnatario.UseVisualStyleBackColor = true;
            // 
            // grpConsegnatarioAttuale
            // 
            this.grpConsegnatarioAttuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConsegnatarioAttuale.Controls.Add(this.txtConsegnatario);
            this.grpConsegnatarioAttuale.Location = new System.Drawing.Point(8, 175);
            this.grpConsegnatarioAttuale.Name = "grpConsegnatarioAttuale";
            this.grpConsegnatarioAttuale.Size = new System.Drawing.Size(958, 56);
            this.grpConsegnatarioAttuale.TabIndex = 25;
            this.grpConsegnatarioAttuale.TabStop = false;
            this.grpConsegnatarioAttuale.Tag = "AutoChoose.txtConsegnatario.default.(active=\'S\')";
            this.grpConsegnatarioAttuale.Text = "Consegnatario attuale";
            // 
            // txtConsegnatario
            // 
            this.txtConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsegnatario.Location = new System.Drawing.Point(8, 22);
            this.txtConsegnatario.Name = "txtConsegnatario";
            this.txtConsegnatario.Size = new System.Drawing.Size(942, 20);
            this.txtConsegnatario.TabIndex = 1;
            this.txtConsegnatario.Tag = "currsubmanager.title?assetview.currsubmanager";
            // 
            // gboxConsegnatario
            // 
            this.gboxConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxConsegnatario.Controls.Add(this.button4);
            this.gboxConsegnatario.Controls.Add(this.button5);
            this.gboxConsegnatario.Controls.Add(this.button6);
            this.gboxConsegnatario.Controls.Add(this.dataGrid3);
            this.gboxConsegnatario.Location = new System.Drawing.Point(8, 16);
            this.gboxConsegnatario.Name = "gboxConsegnatario";
            this.gboxConsegnatario.Size = new System.Drawing.Size(958, 153);
            this.gboxConsegnatario.TabIndex = 24;
            this.gboxConsegnatario.TabStop = false;
            this.gboxConsegnatario.Text = "Subconsegnatario cespite";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 24);
            this.button4.TabIndex = 7;
            this.button4.TabStop = false;
            this.button4.Tag = "insert.single";
            this.button4.Text = "Inserisci";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 24);
            this.button5.TabIndex = 9;
            this.button5.TabStop = false;
            this.button5.Tag = "delete";
            this.button5.Text = "Elimina";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 24);
            this.button6.TabIndex = 8;
            this.button6.TabStop = false;
            this.button6.Tag = "edit.single";
            this.button6.Text = "Modifica";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.CaptionVisible = false;
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(96, 19);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(846, 128);
            this.dataGrid3.TabIndex = 10;
            this.dataGrid3.Tag = "assetsubmanager.detail.single";
            // 
            // tabRisconti
            // 
            this.tabRisconti.Controls.Add(this.groupBox2);
            this.tabRisconti.Controls.Add(this.gboxRisconti);
            this.tabRisconti.Location = new System.Drawing.Point(4, 22);
            this.tabRisconti.Name = "tabRisconti";
            this.tabRisconti.Padding = new System.Windows.Forms.Padding(3);
            this.tabRisconti.Size = new System.Drawing.Size(974, 533);
            this.tabRisconti.TabIndex = 9;
            this.tabRisconti.Text = "Contributi e Risconti";
            this.tabRisconti.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.dataGrid4);
            this.groupBox2.Location = new System.Drawing.Point(8, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 153);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Risconti";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 24);
            this.button7.TabIndex = 7;
            this.button7.TabStop = false;
            this.button7.Tag = "insert.detail";
            this.button7.Text = "Inserisci";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(8, 83);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 24);
            this.button8.TabIndex = 9;
            this.button8.TabStop = false;
            this.button8.Tag = "delete";
            this.button8.Text = "Elimina";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 51);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 24);
            this.button9.TabIndex = 8;
            this.button9.TabStop = false;
            this.button9.Tag = "edit.detail";
            this.button9.Text = "Modifica";
            // 
            // dataGrid4
            // 
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.CaptionVisible = false;
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(96, 19);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(846, 128);
            this.dataGrid4.TabIndex = 10;
            this.dataGrid4.Tag = "assetgrantdetail.detail";
            // 
            // gboxRisconti
            // 
            this.gboxRisconti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxRisconti.Controls.Add(this.btnInsAssetGrant);
            this.gboxRisconti.Controls.Add(this.btnDelAssetGrant);
            this.gboxRisconti.Controls.Add(this.btnUpdAssetGrant);
            this.gboxRisconti.Controls.Add(this.datagridassetgrant);
            this.gboxRisconti.Location = new System.Drawing.Point(8, 16);
            this.gboxRisconti.Name = "gboxRisconti";
            this.gboxRisconti.Size = new System.Drawing.Size(958, 153);
            this.gboxRisconti.TabIndex = 25;
            this.gboxRisconti.TabStop = false;
            this.gboxRisconti.Text = "Contributi";
            // 
            // btnInsAssetGrant
            // 
            this.btnInsAssetGrant.Location = new System.Drawing.Point(8, 19);
            this.btnInsAssetGrant.Name = "btnInsAssetGrant";
            this.btnInsAssetGrant.Size = new System.Drawing.Size(75, 24);
            this.btnInsAssetGrant.TabIndex = 7;
            this.btnInsAssetGrant.TabStop = false;
            this.btnInsAssetGrant.Tag = "insert.single";
            this.btnInsAssetGrant.Text = "Inserisci";
            // 
            // btnDelAssetGrant
            // 
            this.btnDelAssetGrant.Location = new System.Drawing.Point(8, 83);
            this.btnDelAssetGrant.Name = "btnDelAssetGrant";
            this.btnDelAssetGrant.Size = new System.Drawing.Size(75, 24);
            this.btnDelAssetGrant.TabIndex = 9;
            this.btnDelAssetGrant.TabStop = false;
            this.btnDelAssetGrant.Tag = "delete";
            this.btnDelAssetGrant.Text = "Elimina";
            // 
            // btnUpdAssetGrant
            // 
            this.btnUpdAssetGrant.Location = new System.Drawing.Point(8, 51);
            this.btnUpdAssetGrant.Name = "btnUpdAssetGrant";
            this.btnUpdAssetGrant.Size = new System.Drawing.Size(75, 24);
            this.btnUpdAssetGrant.TabIndex = 8;
            this.btnUpdAssetGrant.TabStop = false;
            this.btnUpdAssetGrant.Tag = "edit.single";
            this.btnUpdAssetGrant.Text = "Modifica";
            // 
            // datagridassetgrant
            // 
            this.datagridassetgrant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridassetgrant.CaptionVisible = false;
            this.datagridassetgrant.DataMember = "";
            this.datagridassetgrant.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.datagridassetgrant.Location = new System.Drawing.Point(96, 19);
            this.datagridassetgrant.Name = "datagridassetgrant";
            this.datagridassetgrant.Size = new System.Drawing.Size(846, 128);
            this.datagridassetgrant.TabIndex = 10;
            this.datagridassetgrant.Tag = "assetgrant.single";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 0;
            // 
            // Frm_asset_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(982, 559);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_asset_default";
            this.Text = "frmbeneinventariabile";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxCategoria.ResumeLayout(false);
            this.gboxCategoria.PerformLayout();
            this.gboxPrincipale.ResumeLayout(false);
            this.gboxPrincipale.PerformLayout();
            this.gboxScarico.ResumeLayout(false);
            this.gboxScarico.PerformLayout();
            this.gboxCarico.ResumeLayout(false);
            this.gboxCarico.PerformLayout();
            this.grpValore.ResumeLayout(false);
            this.grpValore.PerformLayout();
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.tabAltriDati.ResumeLayout(false);
            this.grpUbicazioneAttuale.ResumeLayout(false);
            this.grpUbicazioneAttuale.PerformLayout();
            this.grpRespAttuale.ResumeLayout(false);
            this.grpRespAttuale.PerformLayout();
            this.gboxUbicazione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.gboxResponsabile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabAmmortamenti.ResumeLayout(false);
            this.gboxOperazioni.ResumeLayout(false);
            this.gboxOperazioni.PerformLayout();
            this.grpAmmortamento.ResumeLayout(false);
            this.grpAmmortamento.PerformLayout();
            this.gboxaccessoriposseduti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridpartiscaricate)).EndInit();
            this.gboxammortamenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAmmortamenti)).EndInit();
            this.tabStorico.ResumeLayout(false);
            this.gboxInventarioDestinazione.ResumeLayout(false);
            this.gboxInventarioDestinazione.PerformLayout();
            this.gboxInventarioProvenienza.ResumeLayout(false);
            this.gboxInventarioProvenienza.PerformLayout();
            this.tabConsegnatario.ResumeLayout(false);
            this.grpConsegnatarioAttuale.ResumeLayout(false);
            this.grpConsegnatarioAttuale.PerformLayout();
            this.gboxConsegnatario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabRisconti.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.gboxRisconti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridassetgrant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        QueryHelper QHS;
        CQueryHelper QHC;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
//			QueryCreator.SetRelationActivationFilter(DS.Relations["assetmanagermanager"],"(idpiece=1)");
//			QueryCreator.SetRelationActivationFilter(DS.Relations["assetassetlocation"],"(idpiece=1)");
            DataAccess.SetTableForReading(DS.asset1, "asset");
            DataAccess.SetTableForReading(DS.inventory1, "inventory");
            DataAccess.SetTableForReading(DS.assetview4, "assetview");
            DataAccess.SetTableForReading(DS.manager1, "manager");
            DataAccess.SetTableForReading(DS.currsubmanager, "manager");
            DataAccess.SetTableForReading(DS.submanager, "manager");
            DataAccess.SetTableForReading(DS.inventory2, "inventory");
            //GetData.SetStaticFilter(DS.assetview,"(idpiece=1)");
            GetData.SetStaticFilter(DS.asset1, QHS.CmpEq("idpiece", 1));
            GetData.SetStaticFilter(DS.assetview4, QHS.AppAnd(QHS.CmpNe("idpiece", 1), QHS.CmpEq("loadkind", "R"),
                QHS.IsNotNull("yassetunload")));

            HelpForm.SetDenyNull(DS.asset.Columns["nassetacquire"],true);
            GetData.CacheTable(DS.manager, null, null, false);
            GetData.CacheTable(DS.multifieldkind, null, null, false);
        }

        public void MetaData_AfterClear() {
            MetaData.SetDefault(DS.assetgrantdetail, "idgrant", DBNull.Value);
            gboxListino.Enabled = true;
            gboxammortamenti.Visible = false;
            gboxaccessoriposseduti.Visible = false;
            gboxOperazioni.Visible = true;

            grpRespAttuale.Visible = true;
            grpConsegnatarioAttuale.Visible = true;
            grpUbicazioneAttuale.Visible = true;
            txtNumInv.Tag = "asset.ninventory";
            Meta.additional_search_condition = "";
            ClearMultifieldTab();
            lastrejected = DBNull.Value;
            txtUbicazioneAttuale.Text = null;
            Meta.SetAutoField(DBNull.Value, txtResponsabile);
            Meta.SetAutoField(DBNull.Value, txtConsegnatario);
            btnSituazione.Enabled = false;
            txtDescUbicazAttuale.Text = null;
            DisabilitaCampiNonModificabili(false);
            txtNumInv.ReadOnly = false;
            //txtDescrizioneCespitePrincipale.Visible=false;
            //labDescrizioneCespitePrincipale.Visible=false;
            Meta.UnMarkTableAsNotEntityChild(DS.assetmanager);
            Meta.UnMarkTableAsNotEntityChild(DS.assetsubmanager);
            Meta.UnMarkTableAsNotEntityChild(DS.assetlocation);

            Meta.UnMarkTableAsNotEntityChild(DS.assetgrant);

            chkTransf.Enabled = true;
            gboxPrincipale.Text = "";

            gboxaccessoriposseduti.Visible = false;
            labpartipossedute.Visible = false;
            txtpartipossedute.Visible = false;
            chkAccessorio.Visible = true;
            chkPosseduto.Visible = true;
            chkAccessorio.Enabled = true;
            chkPosseduto.Enabled = true;
            chkInventarioVisibile.Enabled = true;
            chkInventarioVisibile.Visible = true;

            txtValoreCarico.Text = "";
            txtpartipossedute.Text = "";
            txtAmmortamenti.Text = "";
            txtValoreAttuale.Text = "";
            chkAccessorio.CheckState = CheckState.Indeterminate;
            chkCaricato.CheckState = CheckState.Indeterminate;
            chkScaricato.CheckState = CheckState.Indeterminate;
            chkPosseduto.CheckState = CheckState.Indeterminate;
            chkInventarioVisibile.CheckState= CheckState.Indeterminate;
            ShowHideProvenienzaDestinazione();
        }

        object lastrejected = DBNull.Value;

        void CheckResponsabileChange() {

            DataRow[] Location = DS.assetlocation.Select(null, null, DataViewRowState.Added);
            foreach (DataRow RL in Location) {
                string filterloc = QHC.CmpEq("idlocation", RL["idlocation"]);
                DataRow[] LL = DS.location.Select(filterloc);
                if (LL.Length == 0) continue;
                if (LL[0]["idman"] == DBNull.Value) continue;
                if (LL[0]["idman"].ToString() == lastrejected.ToString()) continue;
                string filter = QHC.CmpEq("start", RL["start"]);
                if (DS.assetmanager.Select(filter).Length == 0) {
                    if (MessageBox.Show(this, "Si vuole reimpostare il responsabile in base alla nuova ubicazione?",
                        "Conferma",
                        MessageBoxButtons.YesNo) == DialogResult.No) {
                        lastrejected = LL[0]["idman"];
                        return;
                    }
                    MetaData AM = Meta.Dispatcher.Get("assetmanager");
                    AM.SetDefaults(DS.assetmanager);
                    DataRow NA = AM.Get_New_Row(DS.asset.Rows[0], DS.assetmanager);
                    MetaData.SetDefault(DS.assetmanager, "start", RL["start"]);
                    NA["start"] = RL["start"];
                    NA["idman"] = LL[0]["idman"];
                }
                else {
                    DataRow CurrAssMan = DS.assetmanager.Select(filter)[0];
                    if (CurrAssMan["idman"].ToString() != LL[0]["idman"].ToString()) {
                        if (MessageBox.Show(this, "Si vuole reimpostare il responsabile in base alla nuova ubicazione?",
                            "Conferma",
                            MessageBoxButtons.YesNo) == DialogResult.No) {
                            lastrejected = LL[0]["idman"];
                            return;
                        }
                        CurrAssMan["idman"] = LL[0]["idman"];
                    }
                }

            }
            Meta.myGetData.GetTemporaryValues(DS.assetmanager);
            lastrejected = DBNull.Value;

        }

        public void MetaData_BeforeFill() {
            if (!tabControl1.TabPages.Contains(tabAmmortamenti))
                tabControl1.TabPages.Add(tabAmmortamenti);
            modifica_attiva = false;
            CheckResponsabileChange();
            int Nidpiece = CfgFn.GetNoNullInt32(DS.asset.Rows[0]["idpiece"]);
            if (Nidpiece != 1) {
//carico parte
                txtNumInv.Tag = "asset1.ninventory";
                //txtDescrizioneCespitePrincipale.Tag="asset1.description"; 
            }
            else {
//carico bene
                txtNumInv.Tag = "asset.ninventory";
                //txtDescrizioneCespitePrincipale.Tag=""; 
            }
            Meta.MarkTableAsNotEntityChild(DS.assetmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetsubmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetlocation);
            Meta.MarkTableAsNotEntityChild(DS.assetgrantdetail);

            Meta.MarkTableAsNotEntityChild(DS.assetgrant);
        }

        void CalcolaTotOperazioni() {
            if (DS.assetview.Rows.Count == 0) return;
            DataRow R = DS.assetview.Rows[0];
            txtAmmortamenti.Text = CfgFn.GetNoNullDecimal(R["revals"]).ToString("c");
            txtRevalPending.Text = CfgFn.GetNoNullDecimal(R["revals_pending"]).ToString("c");
            txtValoreCarico.Text = CfgFn.GetNoNullDecimal(R["cost"]).ToString("c");
            txtValoreAttuale.Text = CfgFn.GetNoNullDecimal(R["currentvalue"]).ToString("c");
            txtpartipossedute.Text = CfgFn.GetNoNullDecimal(R["subtractions"]).ToString("c");
            //chkCaricato.Checked = R["is_loaded"].ToString() == "S";
            //chkScaricato.Checked = R["is_unloaded"].ToString() == "S";

            if (DS.assetacquireview.Rows.Count == 0) return;
            DataRow C = DS.assetacquireview.Rows[0];
            //chkAccessorio.Checked = C["ispieceacquire"].ToString() == "S";
            //chkPosseduto.Checked = C["loadkind"].ToString() == "R";

            if (chkScaricato.Checked) {
                labelAttuale.Text = "Valore allo scarico";
            }
            else {
                labelAttuale.Text = "Valore attuale";
            }

        }

        void CalcolaProvenienza() {
            txtNumInvPreviousAsset.ReadOnly = true;
            cboPreviousAsset.Enabled = false;
        }

        void CalcolaDestinazione() {
            txtNumInvNextAsset.ReadOnly = true;
            cboNextAsset.Enabled = false;
        }


        void ShowHideProvenienzaDestinazione() {
            if (Meta.IsEmpty) {
                gboxInventarioProvenienza.Visible = true;
                gboxInventarioDestinazione.Visible = true;

                txtNumInvPreviousAsset.ReadOnly = false;
                cboPreviousAsset.Enabled = true;
                txtNumInvNextAsset.ReadOnly = false;
                cboNextAsset.Enabled = true;

                cboPreviousAsset.SelectedIndex = -1;
                txtNumInvPreviousAsset.ReadOnly = false;
                cboPreviousAsset.Enabled = true;
                cboNextAsset.SelectedIndex = -1;
                txtNumInvNextAsset.ReadOnly = false;
                cboNextAsset.Enabled = true;
                return;
            }

            if (Meta.InsertMode) {
                gboxInventarioProvenienza.Visible = false;
                gboxInventarioDestinazione.Visible = false;
                return;
            }


            DataRow Curr = DS.asset.Rows[0];
            if (Curr["idasset_prev"] == DBNull.Value) {
                gboxInventarioProvenienza.Visible = false;
            }
            else {
                gboxInventarioProvenienza.Visible = true;
            }

            gboxInventarioDestinazione.Visible = true;
            txtNumInvPreviousAsset.ReadOnly = true;
            cboPreviousAsset.Enabled = false;
            txtNumInvNextAsset.ReadOnly = true;
            cboNextAsset.Enabled = false;
        }

        public void MetaData_AfterFill() {
            gboxListino.Enabled = false;
            if (Meta.FirstFillForThisRow) {
                grpRespAttuale.Visible = false;
                grpConsegnatarioAttuale.Visible = false;
                grpUbicazioneAttuale.Visible = false;
                gboxOperazioni.Visible = true;
                gboxammortamenti.Visible = true;
                ShowHideProvenienzaDestinazione();
            }
            if (Meta.FirstFillForThisRow) CalcolaTotOperazioni();
            DisabilitaCampiNonModificabili(true);
            btnSituazione.Enabled = !Meta.IsEmpty;
            int N = CfgFn.GetNoNullInt32(DS.asset.Rows[0]["idpiece"]);
            if (N == 1) {
//carico bene
                gboxPrincipale.Text = "CESPITE";
                gboxResponsabile.Enabled = true;
                gboxUbicazione.Enabled = true;
                gboxConsegnatario.Enabled = true;
                txtNumInv.ReadOnly = true;
                //txtDescrizioneCespitePrincipale.Visible = false;
                //labDescrizioneCespitePrincipale.Visible = false;
                chkTransf.Enabled = true;
                gboxaccessoriposseduti.Visible = true;
                labpartipossedute.Visible = true;
                txtpartipossedute.Visible = true;
            }
            else {
//carico parte
                gboxPrincipale.Text = "ACCESSORIO";
                gboxResponsabile.Enabled = false;
                gboxUbicazione.Enabled = false;
                gboxConsegnatario.Enabled = false;
                txtNumInv.ReadOnly = true;
                //txtDescrizioneCespitePrincipale.Visible=true;
                //labDescrizioneCespitePrincipale.Visible = true;
                chkTransf.Enabled = false;
                gboxaccessoriposseduti.Visible = false;
                labpartipossedute.Visible = false;
                txtpartipossedute.Visible = false;
            }
            chkAccessorio.Visible = true;
            chkPosseduto.Visible = true;
            chkInventarioVisibile.Visible = true;
            chkAccessorio.Enabled = false;
            chkPosseduto.Enabled = false;
            chkInventarioVisibile.Enabled = false;
            


            DataRow Curr = DS.asset.Rows[0];
            object idinv = DBNull.Value;

            if (DS.assetacquireview.Rows.Count > 0) {
                DataRow CurrAssAcquire = DS.assetacquireview.Rows[0];
                idinv = CurrAssAcquire["idinv"];
            }
            if (Meta.FirstFillForThisRow) {
                ClearMultifieldTab();
                FillMultifieldTab(Curr["multifield"].ToString(), DS.multifieldkind,
                    DS.inventorytreemultifieldkind.Select(QHC.CmpEq("idinv", idinv), "idmultifieldkind"));
            }

        }

        public void MetaData_AfterGetFormData() {
            DataRow Curr = DS.asset.Rows[0];
            if (DS.assetacquireview.Rows.Count > 0) {
                DataRow CurrAssAcquire = DS.assetacquireview.Rows[0];
                object idinv = CurrAssAcquire["idinv"];
                string S = GetMultifieldTab();
                if (S == "" || S == null)
                    Curr["multifield"] = DBNull.Value;
                else
                    Curr["multifield"] = S;
            }
        }

        public void MetaData_BeforePost() {

            AggiornaUbicazioneCorrente();
            AggiornaResponsabileCorrente();
            AggiornaSubconsegnatarioCorrente();
            // Invio Mail al cambio di responsabile o subconsegnatario
            PredisponiInvioMailAResponsabili();
            PredisponiInvioMailsASubconsegnatari();
        }

        public void ScriviEInviaMail() {
            //Invia la mail al nuovo responsabile
            foreach (int idasset_temp in hNew.Keys) {
                int idasset = CfgFn.GetNoNullInt32(hRow[idasset_temp]["idasset"]);
                int newidman = hNew[idasset_temp];                
                DataTable T = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (T == null || T.Rows.Count == 0) return;
                string mailto = T.Rows[0]["email"].ToString();
                if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") continue;
                string MsgBody = "";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    MsgBody = "Si comunica che il cespite N. " + Rassetview["ninventory"] + ", \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "Ë stato assegnato al Responsabile: " + T.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";
                if (mailto != "") {
                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    SM.Subject = "Notifica assegnazione Cespite";
                    SM.MessageBody = MsgBody;
                    SM.Conn = Conn;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                }
            }

            //Invia la mail al nuovo Subconsegnatario
            foreach (int idasset_temp in hNewSub.Keys) {
                int idasset = CfgFn.GetNoNullInt32(hRowSub[idasset_temp]["idasset"]);
                int newidman = hNewSub[idasset_temp];
                DataTable T = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (T == null || T.Rows.Count == 0) return;
                string mailto = T.Rows[0]["email"].ToString();
                if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") continue;
                string MsgBody = "";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    MsgBody = "Si comunica che il cespite N. " + Rassetview["ninventory"] + ", \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "Ë stato assegnato al Subconsegnatario: " + T.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";
                if (mailto != "") {
                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    SM.Subject = "Notifica assegnazione Cespite";
                    SM.MessageBody = MsgBody;
                    SM.Conn = Conn;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                }
            }

            //Invia la mail al vecchio  responsabile
            foreach (int idasset_temp in hOld.Keys) {
                int idasset = CfgFn.GetNoNullInt32(hRow[idasset_temp]["idasset"]);
                int oldidman = hOld[idasset_temp];                
                // Trovare l'indirizzo e-mail del responsabile mediante idman
                DataTable Told = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", oldidman), null, false);
                if (Told == null || Told.Rows.Count == 0) return;
                string mailto = Told.Rows[0]["email"].ToString();
                if (Told.Rows[0]["wantswarn"].ToString().ToUpper() != "S") continue;
                
                int newidman = hNew[idasset];
                DataTable Tnew = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (Tnew == null || Tnew.Rows.Count == 0) return;
                string MsgBody = "";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    MsgBody = "Si comunica che il cespite N. " + Rassetview["ninventory"] + ", \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "Ë stato assegnato al Responsabile: " + Tnew.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";
                if (mailto != "") {
                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    SM.Subject = "Notifica assegnazione Cespite ad altro responsabile";
                    SM.MessageBody = MsgBody;
                    SM.Conn = Conn;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                }
            }


            //Invia la mail al vecchio Subconsegnatario
            foreach (int idasset_temp in hOldSub.Keys) {
                int idasset = CfgFn.GetNoNullInt32(hRowSub[idasset_temp]["idasset"]);
                int oldidman = hOldSub[idasset_temp];
                // Trovare l'indirizzo e-mail del Subconsegnatario mediante idman
                DataTable Told = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", oldidman), null, false);
                if (Told == null || Told.Rows.Count == 0) return;
                string mailto = Told.Rows[0]["email"].ToString();
                if (Told.Rows[0]["wantswarn"].ToString().ToUpper() != "S") continue;
                int newidman = hNewSub[idasset];
                DataTable Tnew = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (Tnew == null || Tnew.Rows.Count == 0) return;
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                string MsgBody = null;
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    MsgBody = "Si comunica che il cespite N. " + Rassetview["ninventory"] + ", \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "Ë stato assegnato al Subconsegnatario: " + Tnew.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";
                if (mailto != "") {
                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    SM.Subject = "Notifica assegnazione Cespite ad altro sub Consegnatario";
                    SM.MessageBody = MsgBody;
                    SM.Conn = Conn;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            MessageBox.Show(SM.ErrorMessage, "Errore");
                    }
                }
            }

            hNew.Clear();
            hOld.Clear();
            hNewSub.Clear();
            hOldSub.Clear();
            hRow.Clear();
            hRowSub.Clear();
        }

        public void MetaData_AfterPost() {
            ScriviEInviaMail();
        }

        Dictionary<int,int> hNew = new Dictionary<int, int>();
        Dictionary<int, int> hOld = new Dictionary<int, int>();
        private Dictionary<int, DataRow> hRow = new Dictionary<int, DataRow>();

        public void PredisponiInvioMailAResponsabili() {
            hNew.Clear();
            hOld.Clear();
            hRow.Clear();
            
            //Responsabili con data inizio null
            foreach (DataRow R in DS.assetmanager.Select(QHC.IsNull("start"))) {
                int idasset = CfgFn.GetNoNullInt32(R["idasset"]);
                int Current_idman;
                if (R.RowState == DataRowState.Added || R.RowState == DataRowState.Modified) {
                    Current_idman = CfgFn.GetNoNullInt32(R["idman"]);
                    int Original_idman;
                    //if (!Meta.InsertMode)
                    Original_idman = R.RowState == DataRowState.Added
                        ? 0
                        : CfgFn.GetNoNullInt32(R["idman", DataRowVersion.Original]);
                    //else
                    //    Original_idman = Current_idman;
                    if (Current_idman != Original_idman) {
                        hNew[idasset] = Current_idman;

                        if (Original_idman != 0) {
                            hOld[idasset] = Original_idman;
                        }
                    }
                   
                    hRow[idasset] = R;
                }
            }

            //Quando aggiungo il resp. con start valorizzato, invio la mail a quello con start valorizzato, ed al precedente calcolato sulla base di idassetmanager

            //Responsabile (new) con data inizio valorizzato
            foreach (DataRow R in DS.assetmanager.Select(QHC.IsNotNull("start"), "start desc")) {
                int idasset = CfgFn.GetNoNullInt32(R["idasset"]);
                int Current_idman;
                if (R.RowState == DataRowState.Added || R.RowState == DataRowState.Modified) {
                    Current_idman = CfgFn.GetNoNullInt32(R["idman"]);
                    int Original_idman;
                    //if (!Meta.InsertMode) {
                    Original_idman = R.RowState == DataRowState.Added
                        ? 0
                        : CfgFn.GetNoNullInt32(R["idman", DataRowVersion.Original]);
                    //}
                    //else {
                    //    Original_idman = Current_idman;
                    //    }
                    if (Current_idman != Original_idman) {
                        //Invia la mail al nuovo responsabile
                        int newidman = Current_idman;
                        hNew[idasset] = newidman;
 
                        //Invia la mail anche al resp. precedente
                        if (Original_idman == 0) {
                            int idassetmanager = CfgFn.GetNoNullInt32(R["idassetmanager"]);
                            DataRow[] RowsAssetmanagerPrec =
                                DS.assetmanager.Select(
                                    QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),
                                        QHC.CmpNe("idassetmanager", idassetmanager)), "idassetmanager desc");
                            if (RowsAssetmanagerPrec.Length > 0) {
                                DataRow rAssetmanagerPrec = RowsAssetmanagerPrec[0];
                                int oldidman = CfgFn.GetNoNullInt32(rAssetmanagerPrec["idman"]);
                                ;
                                hOld[idasset] = oldidman;
                            }
                        }
                        else {
                            hOld[idasset] = Original_idman;
                        }
                        hRow[idasset] = R;
                    }
                }
                break;
            }
            
        }

        public void AggiornaUbicazioneCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            DataRow Curr = DS.asset.Rows[0];
            DataRow[] RAssetLoc = DS.assetlocation.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
            if (RAssetLoc.Length > 0) {
                DataRow R = RAssetLoc[0];
                Curr["idcurrlocation"] = R["idlocation"];
            }
            else
                Curr["idcurrlocation"] = DBNull.Value;
        }

            public void AggiornaResponsabileCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            DataRow Curr = DS.asset.Rows[0];
            DataRow[] RAssetMan = DS.assetmanager.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
            if (RAssetMan.Length > 0) {
                DataRow R = RAssetMan[0];
                Curr["idcurrman"] = R["idman"];
            }
            else
                Curr["idcurrman"] = DBNull.Value;
        }

        public void AggiornaSubconsegnatarioCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            DataRow Curr = DS.asset.Rows[0];
            DataRow[] RAssetSubMan = DS.assetsubmanager.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
            if (RAssetSubMan.Length > 0) {
                DataRow R = RAssetSubMan[0];
                Curr["idcurrsubman"] = R["idmanager"];
            }
            else
                Curr["idcurrsubman"] = DBNull.Value;
        }

        Dictionary<int, int> hNewSub = new Dictionary<int, int>();
        Dictionary<int, int> hOldSub = new Dictionary<int, int>();
        private Dictionary<int, DataRow> hRowSub = new Dictionary<int, DataRow>();

        public void PredisponiInvioMailsASubconsegnatari() {
            // Subconsegnatario con data inizio null
            hNewSub.Clear();
            hOldSub.Clear();
            hRowSub.Clear();
            //Subconsegnatario con data inizio null
            foreach (DataRow R in DS.assetsubmanager.Select(QHC.IsNull("start"))) {
                int Current_idman;
                int idasset = CfgFn.GetNoNullInt32(R["idasset"]);
                if (R.RowState == DataRowState.Added || R.RowState == DataRowState.Modified) {
                    Current_idman = CfgFn.GetNoNullInt32(R["idmanager"]);
                    int Original_idman;
                    //if (!Meta.InsertMode)
                    Original_idman = R.RowState == DataRowState.Added
                        ? 0
                        : CfgFn.GetNoNullInt32(R["idmanager", DataRowVersion.Original]);
                    //else
                    //    Original_idman = Current_idman;
                    if (Current_idman != Original_idman) {
                        int newidman = Current_idman;
                        hNewSub[idasset] = newidman;
                    }
                    if (Original_idman != 0) {
                        hOldSub[idasset] = Original_idman;
                    }
                    hRowSub[idasset] = R;
                }
            }

            //Quando aggiungo il Subconsegnatario con start valorizzato, invio la mail a quello con start valorizzato, ed al precedente calcolato sulla base di idassetmanager

            //Subconsegnatario (new) con data inizio valorizzato
            foreach (DataRow R in DS.assetsubmanager.Select(QHC.IsNotNull("start"), "start desc")) {
                int Current_idman;
                int idasset = CfgFn.GetNoNullInt32(R["idasset"]);
                if (R.RowState == DataRowState.Added || R.RowState == DataRowState.Modified) {
                    Current_idman = CfgFn.GetNoNullInt32(R["idmanager"]);
                    int Original_idman;
                    //if (!Meta.InsertMode) {
                    Original_idman = R.RowState == DataRowState.Added
                        ? 0
                        : CfgFn.GetNoNullInt32(R["idmanager", DataRowVersion.Original]);
                    //}
                    //else {
                    //    Original_idman = Current_idman;
                    //    }
                    if (Current_idman != Original_idman) {
                        //Invia la mail al nuovo Subconsegnatario
                        int newidman = Current_idman;
                        hNewSub[idasset] = newidman;
                        //Invia la mail anche al Subconsegnatario precedente
                        if (Original_idman == 0) {
                            int idassetsubmanager = CfgFn.GetNoNullInt32(R["idassetsubmanager"]);
                            DataRow[] RowsAssetSubmanagerPrec =
                                DS.assetsubmanager.Select(
                                    QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),
                                        QHC.CmpNe("idassetsubmanager", idassetsubmanager)), "idassetsubmanager desc");
                            if (RowsAssetSubmanagerPrec.Length > 0) {
                                DataRow rAssetSubmanagerPrec = RowsAssetSubmanagerPrec[0];
                                int oldidman = CfgFn.GetNoNullInt32(rAssetSubmanagerPrec["idmanager"]);
                                ;
                                hOldSub[idasset] = oldidman;
                            }
                        }
                        else {
                            hOldSub[idasset] = Original_idman;
                        }
                        hRowSub[idasset] = R;
                    }
                }
                break;
            }

        }

  

        private void DisabilitaCampiNonModificabili(bool disable) {
            //txtNumCarico.ReadOnly=disable;
            txtDescrizione.ReadOnly = disable;
            btnClassif.Enabled = !disable;
            txtIdClassif.ReadOnly = disable;
            cboInventario.Enabled = !disable;
            txtImponibile.ReadOnly = disable;
            txtImposta.ReadOnly = disable;
            txtSconto.ReadOnly = disable;

            cmbTipoBuonoCarico.Enabled = !disable;
            txtEsercBuonoCarico.ReadOnly = disable;
            txtNumBuonoCarico.ReadOnly = disable;
            cmbTipoBuonoScarico.Enabled = !disable;
            txtEsercBuonoScarico.ReadOnly = disable;
            txtNumBuonoScarico.ReadOnly = disable;
            cmbCausaleCarico.Enabled = !disable;
            cmbCausaleScarico.Enabled = !disable;
            btnUPBCode.Enabled = !disable;
            txtUPB.Enabled = !disable;
            txtRatificaCarico.Enabled = !disable;
            txtRatificaScarico.Enabled = !disable;
            //grpAmmortamento.Enabled = !disable;
        }

        private void btnSituazione_Click(object sender, System.EventArgs e) {
            DataRow MyRow = HelpForm.GetLastSelected(DS.asset);
            object idbene = (MyRow != null ? MyRow["idasset"] : null);

            DataSet Out = Conn.CallSP("show_asset",
                new Object[2] {Meta.GetSys("datacontabile"), idbene});
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione beni inventariati";
            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();
        }

        private void btnUbicazioneAttuale_Click(object sender, EventArgs e) {

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "inventorytreeview") {
                ClearMultifieldTab();
                if (R == null) {
                    Meta.additional_search_condition = "";
                    return;
                }
                DataTable MF = Conn.RUN_SELECT("inventorytreemultifieldkind", "*", null, QHS.CmpEq("idinv", R["idinv"]), null, true);
                FillMultifieldTab("", DS.multifieldkind, MF.Select(null, "idmultifieldkind"));

            }

            if (T.TableName == "assetgrant") {
                if (R != null) {
                    MetaData.SetDefault(DS.assetgrantdetail, "idgrant", R["idgrant"]);
                }
            }

        }

        #region gestione multifieldkind

        int TextHeight = 30;
        int TextWidth = 300;

        class mfield {
            public string fieldname;
            public string systype;
            public bool allownull;
            public string tag;
            public string fieldcode;
            public TextBox T;
        }

        int AddMultiFieldToForm(TabPage TP, mfield MF, int x, int y, int maxlen) {
	        int nLine = maxlen / 45;
	        TextBox T = new TextBox();
	        T.Width = TextWidth;
	        T.Height = TextHeight;
	        if (maxlen != 0) {
		        T.MaxLength = maxlen;
	        }
	        if (nLine > 1) {
		        T.Multiline = true;
		        T.Height = TextHeight*nLine;
		        T.ScrollBars = ScrollBars.Vertical;
	        }

            GroupBox G = new GroupBox();
            G.Size = new Size(320, T.Height +30);
            G.Location = new Point(10 + x, 15 + y);


            G.Anchor = ((AnchorStyles) (((AnchorStyles.Top | AnchorStyles.Left))));
            //if (intab_count < 10) {
            //    G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left))));
            //}
            //else {
            //    G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            //                    | AnchorStyles.Right)));
            //}
            G.Text = MF.fieldname;
            if (!MF.allownull) {
                G.Text = G.Text + " (*)";
            }
            TP.Controls.Add(G);

         
            G.Controls.Add(T);
        
            //T.Multiline = true;
            //T.ScrollBars = ScrollBars.Vertical;
            T.Location = new Point(5, 18);
            T.Anchor = ((AnchorStyles) ((AnchorStyles.Top | AnchorStyles.Left)));

            MF.T = T;
            return G.Height;
        }


        mfield[] allfields = new mfield[1];
        bool modifica_attiva = false;

        /// <summary>
        /// Aggiunge i textbox al tab e li riempie con i valori trovati in value
        /// </summary>
        /// <param name="value">stinga codificata</param>
        /// <param name="MFKind">tabella multifieldkind</param>
        /// <param name="Fields">inventorytreemultifieldkind filtrata per idinv</param>
        void FillMultifieldTab(string value, DataTable MFKind, DataRow[] Fields) {
            TabControl FT = new TabControl();
            FT.Dock = DockStyle.Fill;
			///HL = dizionario che associa ai nomi dei tab  i datarow che descrivono i campi in essi contenuti
            var HL = new Dictionary<string, List<DataRow>>();

            var availableCodes = new Dictionary<string, bool>();
			//Elenco dei nomi dei tab
            var TabNameList = new ArrayList();
            foreach (DataRow Fk0 in MFKind.Select(null, "ordernumber")) {
                DataRow F = null;
                foreach (var FF in Fields) {
                    if (FF["idmultifieldkind"].ToString() == Fk0["idmultifieldkind"].ToString()) {
                        F = FF;
                        break;
                    }
                }
                if (F == null) continue;//considera solo i campi di questo codice inventario
                availableCodes[Fk0["fieldcode"].ToString().ToLower()] = true;
                string tabname = Fk0["tabname"].ToString();
                List<DataRow> AL;
                if (HL.ContainsKey(tabname)) {
                    AL = HL[tabname] as List<DataRow>;
                }
                else {
                    AL = new List<DataRow>();
                    HL[tabname] = AL;
                    TabNameList.Add(tabname);
                }
                AL.Add(F);
            }


            tabAggiuntive.Controls.Clear();
            tabAggiuntive.Controls.Add(FT);

            var H = new Hashtable(); //associazione codice campi -> valori campi
            string[] allmf = value.Split(new char[] {'ß'}); //coppie codice valore memorizzate nella riga
            foreach (string coppia in allmf) {
                if (coppia == "") continue;
                string[] cc = coppia.Split(new char[] {'|'});
                string code = cc[0].ToLower();
                if (!availableCodes.ContainsKey(code)) continue;
                string val = cc[1];
                H[code] = val;
            }
            modifica_attiva = false;
            //allfields= array di stringhe del tipo chiaveßvalore
			
            allfields = new mfield[Fields.Length];

            //if (value == "") allfields = new mfield[0];
            TabNameList.Sort();
            int maincount = 1;

            foreach (string tabname in TabNameList) { //cicla tra i tab
				var TP = new TabPage(tabname == "null" ? "" : tabname) {
					AutoScroll = true
				};

				int x = 0;
                int y = 0;

                int tabcount = 1;
                foreach (var Field in HL[tabname]) { //elenco dei datarow per ogni tab
                    var Fks = MFKind.Select(QHC.CmpEq("idmultifieldkind", Field["idmultifieldkind"]));
                    if (Fks.Length == 0) continue;
                    var R = Fks[0];

                    string fieldcode = R["fieldcode"].ToString();
                    object XX = H[fieldcode.ToLower()];
                    if (XX == null) XX = "";
					var MF = new mfield {
						fieldname = R["fieldname"].ToString(),
						allownull = (R["allownull"].ToString().ToUpper() == "S"),
						systype = R["systype"].ToString(),
						tag = R["tag"].ToString(),
						fieldcode = fieldcode
					};
					int height = AddMultiFieldToForm(TP, MF, x, y, CfgFn.GetNoNullInt32(R["len"])); //inizio

                    MF.T.LostFocus += new EventHandler(T_LostFocus);

                    MF.T.Text = XX.ToString();

                    MF.T.TextAlign = MF.systype.ToLower() == "string" ? HorizontalAlignment.Left : HorizontalAlignment.Right;

					allfields[maincount - 1] = MF;

                    tabcount++;
                    maincount++;
                    y += height+10;
                    if (tabcount == 10) {
                        x += 350;
                        y = 0;
                    }
                }

                FT.TabPages.Add(TP);
                FT.Refresh();
            }

            ////Legenda campi obbligatori
            //if (Fields.Length > 0) {
            //    Label L = new Label();
            //    tabAggiuntive.Controls.Add(L);
            //    L.Text = "I campi contrassegnati da (*) sono obbligatori";
            //    L.AutoSize = true;
            //    L.Location = new Point(10 + x, 15 + y);
            //}

            modifica_attiva = true;
        }


        void T_LostFocus(object sender, EventArgs e) {
            if (!modifica_attiva) return;
            Meta.additional_search_condition = GetSearchMultifieldTab();
        }

        string GetSearchMultifieldTab() {
            string filtro = "";
            foreach (mfield mf in allfields) {
                if (mf == null) continue;
                string value = mf.T.Text.Trim().Replace("ß", "").Replace("|", "");
                if (value == "") continue;
                string fieldcode = mf.fieldcode;
                string coppia = "ß" + fieldcode + "|" + value;
                string search = QHS.Like("'ß'+multifield", "%" + coppia + "%");
                filtro = QHS.AppAnd(filtro, search);
            }
            if (filtro == "") return null;
            return filtro;
        }

        bool are_same(string mfield1, string mfield2) {
            string[] coppie1 = mfield1.Split('ß');
            string[] coppie2 = mfield2.Split('ß');

            Hashtable h1 = new Hashtable();
            foreach (string c1 in coppie1) {
                string[] cval1 = c1.Split('|');
                if (cval1.Length < 2) continue;
                if (cval1[1].ToString() == "") continue;
                h1[cval1[0]] = cval1[1].TrimEnd();
            }

            Hashtable h2 = new Hashtable();
            foreach (string c2 in coppie2) {
                string[] cval2 = c2.Split('|');
                if (cval2.Length < 2) continue;
                if (cval2[1].ToString() == "") continue;
                h2[cval2[0]] = cval2[1].TrimEnd();
            }


            foreach (object k1 in h1.Keys) {
                if (!h2.Contains(k1.ToString())) return false;
                if (h1[k1.ToString()].ToString() != h2[k1.ToString()].ToString()) return false;
            }

            foreach (object k2 in h2.Keys) {
                if (!h1.Contains(k2.ToString())) return false;
                if (h1[k2.ToString()].ToString() != h2[k2.ToString()].ToString()) return false;
            }

            return true;
        }

        string GetMultifieldTab() {
            string res = "";
            foreach (mfield mf in allfields) {
                if (mf == null) continue;
                string value = mf.T.Text.Trim().Replace("ß", "").Replace("|", "");
                if (value == "") continue;
                string fieldcode = mf.fieldcode;
                string coppia = fieldcode + "|" + value;
                if (res != "") res += "ß";
                res += coppia;
            }
            if (Meta.EditMode) {
                DataRow Curr = DS.asset.Rows[0];
                string old = Curr["multifield", DataRowVersion.Original].ToString();
                if (are_same(res, old)) res = old;
            }

            return res;
        }

        void ClearMultifieldTab() {
            tabAggiuntive.Controls.Clear();
            allfields = new mfield[1];
        }

        #endregion

        private void tabStorico_Click(object sender, EventArgs e) {

        }

        private void btnProvenienza_Click(object sender, EventArgs e) {
            CalcolaProvenienza();
        }

        private void btnDestinazione_Click(object sender, EventArgs e) {
            CalcolaDestinazione();
        }

        private void gboxScarico_Enter(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }

        private void btnListino_Click(object sender, EventArgs e) {

            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1));
                //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            if (chkListDescription.Checked) {
                FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null) {
                    object idlistclass = FR.Selected["idlistclass"];
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass", idlistclass));
                }
                if (FR.txtDescrizione.Text != "") {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%")) Description += "%";
                    if (!Description.StartsWith("%")) Description = "%" + Description;
                    filter = QHS.AppAnd(filter, QHS.Like("description", Description));
                }
            }



            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            AggiornaListino(Choosen);
        }


        void AggiornaListino(DataRow Choosen) {
            if (Meta.IsEmpty) {
                riempiOggetti(Choosen);
                return;
            }


        }


        private void riempiOggetti(DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";

        }

        private void svuotaOggetti() {
            txtDescrizioneListino.Text = "";
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {
            //NON USARE QUESTO SCHIFO DI METODO GRAZIE
        }

        private void txtListino_Leave(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtListino.Text == "") {
                svuotaOggetti();
                return;
            }
            if (txtListino.Text == lastCodice) return;
            if (!Meta.DrawStateIsDone) return;

            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = QHC.AppAnd(filter, QHS.Like("intcode", IntCode));

            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) {
                txtListino.Focus();
                lastCodice = null;
                return;
            }

            AggiornaListino(Choosen);
        }

        private string lastCodice;

        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

    }
}

