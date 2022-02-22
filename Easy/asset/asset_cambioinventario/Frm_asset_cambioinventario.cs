
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
using System.Runtime.InteropServices;
using funzioni_configurazione;

namespace asset_cambioinventario {
    /// <summary>
    /// Summary description for frmbeneinv_trasferimento.
    /// </summary>
    public class Frm_asset_cambioinventario : MetaDataForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public vistaForm DS;

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.ComponentModel.Container components = null;
        private string CustomTitle = "Cambio inventario cespiti";
        private MetaData Meta;
        private DataAccess Conn;
        private string Responsabile = "";
        private string CodiceResponsabile = "";
        private string Consegnatario = "";
        private string CodiceConsegnatario = "";
        private string Filtro = "";

        private object assetUnloadKind;
        private object idinventoryOrig;
        private string descUnload;
        private object cessionario = DBNull.Value;
        private object assetUnloadMotive;
        private string docUnload;
        private object docDateUnload = DBNull.Value;
        private object enactmentUnload;
        private object enactmentDateUnload = DBNull.Value;
        private object _adateUnload = DBNull.Value;
        private object printDateUnload = DBNull.Value;
        private object assetLoadKind;
        private object idinventoryDest;
        private string descLoad;
        private object cedente = DBNull.Value;
        private object newresp = DBNull.Value;
        private object newsubresp = DBNull.Value;
        private object assetLoadMotive;
        private string docLoad;
        private object docDateLoad = DBNull.Value;
        private string enactmentLoad;
        private object enactmentDateLoad = DBNull.Value;
        private object _adateLoad = DBNull.Value;
        private object printDateLoad = DBNull.Value;
        private object ratificationDateLoad = DBNull.Value;
        private object ratificationDateUnLoad = DBNull.Value;
        private Crownwood.Magic.Controls.TabPage tabPage5;
        private Label lblFase4;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private Label label8;
        private TextBox txtDataRatificaCarico;
        private GroupBox groupBox5;
        private Label label9;
        private TextBox txtDescrBuonoCarico;
        private Label label12;
        private ComboBox cmbTipoBuonoCarico;
        private TextBox txtDataContCarico;
        private Label label14;
        private Label label18;
        private TextBox txtDataStampaCarico;
        private GroupBox groupBox6;
        private ComboBox cmbCausaleCarico;
        private GroupBox groupBox7;
        private Label label19;
        private TextBox txtDataProvvCarico;
        private TextBox txtProvvCarico;
        private GroupBox grpCedente;
        private TextBox txtCedente;
        private GroupBox groupBox9;
        private TextBox txtDataDocCarico;
        private Label label20;
        private TextBox txtDocCarico;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private GroupBox groupBox8;
        private Label label26;
        private Label label24;
        private CheckBox chkpreservaInventario;
        private TextBox txtEnteCarico;
        private Label label7;
        private Label label23;
        private ComboBox cmbInventarioDest;
        private GroupBox grpResponsabile;
        private ComboBox cmbResponsabile;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Label label4;
        private Label label27;
        private TextBox txtDataRatificaScarico;
        private GroupBox groupBox4;
        private Label label1;
        private TextBox txtDescrBuonoScarico;
        private Label label11;
        private ComboBox cmbTipoBuonoScarico;
        private TextBox txtDataContScarico;
        private Label label3;
        private TextBox txtDataStampaScarico;
        private GroupBox grpCausaleScarico;
        private ComboBox cboCausaleScarico;
        private GroupBox groupBox2;
        private Label label15;
        private TextBox txtDataProvvScarico;
        private TextBox txtProvvScarico;
        private GroupBox grpCessionario;
        private TextBox txtCessionario;
        private GroupBox groupBox3;
        private TextBox txtDataDocScarico;
        private Label label2;
        private TextBox txtDocScarico;
        private Crownwood.Magic.Controls.TabPage tabPage2bis;
        private Button btnSelezionaTutto;
        private Label label17;
        private Label label10;
        private DataGrid gridCespiti;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private GroupBox grpInventoryOrigin;
        private CheckBox chkReady;
        private Label label22;
        private Label label25;
        private TextBox txtEnteScarico;
        private Label label21;
        private Label label16;
        private Label label13;
        private ComboBox cmbInventarioOrig;
        private TextBox txt_numinv_a;
        private TextBox txt_numinv_da;
        private Label label5;
        private Label label6;
        private Crownwood.Magic.Controls.TabPage tabPageInizio;
        private Label lblFase1;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Label label28;
        private ComboBox cboResp;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private Label label29;
        private ComboBox cboConsegnatario;
        private GroupBox groupBox1;
        private ComboBox cmbConsegnatario;
        private GroupBox groupBox10;
        private Panel panel1;
        private CheckBox chkSubRespInvariato;
        private CheckBox chkUpbInvariato;
        private CheckBox chkRespInvariato;
        private bool stessoNinventory = false;

        private enum eTipoModalita {
            NUMINVENTARIO
        }

        //private eTipoModalita Modalita=eTipoModalita.NONDEFINITA;

        public Frm_asset_cambioinventario() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;

            lblFase1.Text = "Il processo di trasferimento dei cespiti da un Inventario " +
                            "ad un altro può essere eseguito specificando tutti i cespiti dell'Inventario di partenza " +
                            "o parte di essi " +
                            "selezionandoli in base al " +
                            "numero Inventario\r\n\r\n";
            GetData.CacheTable(DS.manager, null, "title", true);
            GetData.CacheTable(DS.manager_orig, null, "title", true);
            GetData.CacheTable(DS.managerconsegnatario, null, "title", true);
            GetData.CacheTable(DS.managerconsegnatario_origin, null, "title", true);
            GetData.CacheTable(DS.inventory_origin, "(active='S')", "description", true);
            GetData.CacheTable(DS.inventory_dest, "(active='S')", "description", true);
            GetData.CacheTable(DS.assetloadkind, "(active='S')", "description", true);
            GetData.CacheTable(DS.assetunloadkind, "(active='S')", "description", true);
            GetData.CacheTable(DS.assetloadmotive, "(active='S')", "description", true);
            GetData.CacheTable(DS.assetunloadmotive, "(active='S')", "description", true);
            DataAccess.SetTableForReading(DS.inventory_origin, "inventory");
            DataAccess.SetTableForReading(DS.inventory_dest, "inventory");
            DataAccess.SetTableForReading(DS.registry_assetunload, "registry");
            DataAccess.SetTableForReading(DS.registry_assetload, "registry");
            DataAccess.SetTableForReading(DS.asset_detail, "asset");
            DataAccess.SetTableForReading(DS.assetview_piece, "assetview");
            DataAccess.SetTableForReading(DS.manager_orig, "manager");
            DataAccess.SetTableForReading(DS.managerconsegnatario, "manager");
            DataAccess.SetTableForReading(DS.managerconsegnatario_origin, "manager");
            QueryCreator.SetTableForPosting(DS.asset_detail, "asset");
            QueryCreator.SetTableForPosting(DS.assetview, "asset");
            QueryCreator.SetTableForPosting(DS.assetview_piece, "asset");

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_asset_cambioinventario));
			this.DS = new asset_cambioinventario.vistaForm();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
			this.lblFase4 = new System.Windows.Forms.Label();
			this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataRatificaCarico = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDescrBuonoCarico = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbTipoBuonoCarico = new System.Windows.Forms.ComboBox();
			this.txtDataContCarico = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.txtDataStampaCarico = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.cmbCausaleCarico = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtDataProvvCarico = new System.Windows.Forms.TextBox();
			this.txtProvvCarico = new System.Windows.Forms.TextBox();
			this.grpCedente = new System.Windows.Forms.GroupBox();
			this.txtCedente = new System.Windows.Forms.TextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txtDataDocCarico = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtDocCarico = new System.Windows.Forms.TextBox();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmbConsegnatario = new System.Windows.Forms.ComboBox();
			this.chkSubRespInvariato = new System.Windows.Forms.CheckBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.chkUpbInvariato = new System.Windows.Forms.CheckBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.chkpreservaInventario = new System.Windows.Forms.CheckBox();
			this.txtEnteCarico = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.cmbInventarioDest = new System.Windows.Forms.ComboBox();
			this.grpResponsabile = new System.Windows.Forms.GroupBox();
			this.cmbResponsabile = new System.Windows.Forms.ComboBox();
			this.chkRespInvariato = new System.Windows.Forms.CheckBox();
			this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.txtDataRatificaScarico = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrBuonoScarico = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbTipoBuonoScarico = new System.Windows.Forms.ComboBox();
			this.txtDataContScarico = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDataStampaScarico = new System.Windows.Forms.TextBox();
			this.grpCausaleScarico = new System.Windows.Forms.GroupBox();
			this.cboCausaleScarico = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataProvvScarico = new System.Windows.Forms.TextBox();
			this.txtProvvScarico = new System.Windows.Forms.TextBox();
			this.grpCessionario = new System.Windows.Forms.GroupBox();
			this.txtCessionario = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtDataDocScarico = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDocScarico = new System.Windows.Forms.TextBox();
			this.tabPage2bis = new Crownwood.Magic.Controls.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.gridCespiti = new System.Windows.Forms.DataGrid();
			this.btnSelezionaTutto = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.grpInventoryOrigin = new System.Windows.Forms.GroupBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cboConsegnatario = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.cboResp = new System.Windows.Forms.ComboBox();
			this.chkReady = new System.Windows.Forms.CheckBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.txtEnteScarico = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cmbInventarioOrig = new System.Windows.Forms.ComboBox();
			this.txt_numinv_a = new System.Windows.Forms.TextBox();
			this.txt_numinv_da = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPageInizio = new Crownwood.Magic.Controls.TabPage();
			this.lblFase1 = new System.Windows.Forms.Label();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabPage5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.grpCedente.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.grpResponsabile.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.grpCausaleScarico.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpCessionario.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage2bis.SuspendLayout();
			this.groupBox10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridCespiti)).BeginInit();
			this.tabPage1.SuspendLayout();
			this.grpInventoryOrigin.SuspendLayout();
			this.tabPageInizio.SuspendLayout();
			this.tabController.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(801, 540);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Annulla";
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Location = new System.Drawing.Point(697, 540);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 11;
			this.btnNext.Text = "Avanti >";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnBack
			// 
			this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBack.Location = new System.Drawing.Point(617, 540);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(75, 23);
			this.btnBack.TabIndex = 10;
			this.btnBack.Text = "< Indietro";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.lblFase4);
			this.tabPage5.Location = new System.Drawing.Point(0, 0);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Selected = false;
			this.tabPage5.Size = new System.Drawing.Size(876, 508);
			this.tabPage5.TabIndex = 10;
			// 
			// lblFase4
			// 
			this.lblFase4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFase4.Location = new System.Drawing.Point(22, 17);
			this.lblFase4.Name = "lblFase4";
			this.lblFase4.Size = new System.Drawing.Size(824, 463);
			this.lblFase4.TabIndex = 2;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label8);
			this.tabPage3.Controls.Add(this.txtDataRatificaCarico);
			this.tabPage3.Controls.Add(this.groupBox5);
			this.tabPage3.Controls.Add(this.txtDataContCarico);
			this.tabPage3.Controls.Add(this.label14);
			this.tabPage3.Controls.Add(this.label18);
			this.tabPage3.Controls.Add(this.txtDataStampaCarico);
			this.tabPage3.Controls.Add(this.groupBox6);
			this.tabPage3.Controls.Add(this.groupBox7);
			this.tabPage3.Controls.Add(this.grpCedente);
			this.tabPage3.Controls.Add(this.groupBox9);
			this.tabPage3.Location = new System.Drawing.Point(0, 0);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Selected = false;
			this.tabPage3.Size = new System.Drawing.Size(876, 508);
			this.tabPage3.TabIndex = 5;
			this.tabPage3.Title = "Page3";
			this.tabPage3.Visible = false;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 320);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 16);
			this.label8.TabIndex = 95;
			this.label8.Text = "Data ratifica:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataRatificaCarico
			// 
			this.txtDataRatificaCarico.Location = new System.Drawing.Point(117, 320);
			this.txtDataRatificaCarico.Name = "txtDataRatificaCarico";
			this.txtDataRatificaCarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataRatificaCarico.TabIndex = 94;
			this.txtDataRatificaCarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.txtDescrBuonoCarico);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.cmbTipoBuonoCarico);
			this.groupBox5.Location = new System.Drawing.Point(14, 7);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(372, 144);
			this.groupBox5.TabIndex = 93;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Buono di Carico";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(17, 15);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 16);
			this.label9.TabIndex = 84;
			this.label9.Text = "Tipo:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescrBuonoCarico
			// 
			this.txtDescrBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBuonoCarico.Location = new System.Drawing.Point(15, 82);
			this.txtDescrBuonoCarico.MaxLength = 150;
			this.txtDescrBuonoCarico.Multiline = true;
			this.txtDescrBuonoCarico.Name = "txtDescrBuonoCarico";
			this.txtDescrBuonoCarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrBuonoCarico.Size = new System.Drawing.Size(349, 56);
			this.txtDescrBuonoCarico.TabIndex = 82;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 63);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(80, 16);
			this.label12.TabIndex = 83;
			this.label12.Text = "Descrizione:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbTipoBuonoCarico
			// 
			this.cmbTipoBuonoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoBuonoCarico.DataSource = this.DS.assetloadkind;
			this.cmbTipoBuonoCarico.DisplayMember = "description";
			this.cmbTipoBuonoCarico.Location = new System.Drawing.Point(17, 34);
			this.cmbTipoBuonoCarico.MaxDropDownItems = 25;
			this.cmbTipoBuonoCarico.Name = "cmbTipoBuonoCarico";
			this.cmbTipoBuonoCarico.Size = new System.Drawing.Size(349, 23);
			this.cmbTipoBuonoCarico.TabIndex = 80;
			this.cmbTipoBuonoCarico.ValueMember = "idassetloadkind";
			this.cmbTipoBuonoCarico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbTipoBuonoCarico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// txtDataContCarico
			// 
			this.txtDataContCarico.Location = new System.Drawing.Point(117, 265);
			this.txtDataContCarico.Name = "txtDataContCarico";
			this.txtDataContCarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataContCarico.TabIndex = 89;
			this.txtDataContCarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(17, 266);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(94, 16);
			this.label14.TabIndex = 91;
			this.label14.Text = "Data contabile:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(17, 294);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(94, 16);
			this.label18.TabIndex = 92;
			this.label18.Text = "Data stampa:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataStampaCarico
			// 
			this.txtDataStampaCarico.Location = new System.Drawing.Point(117, 293);
			this.txtDataStampaCarico.Name = "txtDataStampaCarico";
			this.txtDataStampaCarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataStampaCarico.TabIndex = 90;
			this.txtDataStampaCarico.TextChanged += new System.EventHandler(this.txtData_Leave);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.cmbCausaleCarico);
			this.groupBox6.Location = new System.Drawing.Point(14, 209);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(372, 45);
			this.groupBox6.TabIndex = 86;
			this.groupBox6.TabStop = false;
			this.groupBox6.Tag = "";
			this.groupBox6.Text = "Causale di Carico";
			// 
			// cmbCausaleCarico
			// 
			this.cmbCausaleCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCausaleCarico.DataSource = this.DS.assetloadmotive;
			this.cmbCausaleCarico.DisplayMember = "description";
			this.cmbCausaleCarico.Location = new System.Drawing.Point(16, 14);
			this.cmbCausaleCarico.MaxDropDownItems = 25;
			this.cmbCausaleCarico.Name = "cmbCausaleCarico";
			this.cmbCausaleCarico.Size = new System.Drawing.Size(348, 23);
			this.cmbCausaleCarico.TabIndex = 48;
			this.cmbCausaleCarico.ValueMember = "idmot";
			this.cmbCausaleCarico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbCausaleCarico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.label19);
			this.groupBox7.Controls.Add(this.txtDataProvvCarico);
			this.groupBox7.Controls.Add(this.txtProvvCarico);
			this.groupBox7.Location = new System.Drawing.Point(392, 137);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(445, 117);
			this.groupBox7.TabIndex = 88;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Provvedimento";
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label19.Location = new System.Drawing.Point(274, 93);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(40, 16);
			this.label19.TabIndex = 75;
			this.label19.Text = "Data:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataProvvCarico
			// 
			this.txtDataProvvCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataProvvCarico.Location = new System.Drawing.Point(329, 88);
			this.txtDataProvvCarico.Name = "txtDataProvvCarico";
			this.txtDataProvvCarico.Size = new System.Drawing.Size(105, 23);
			this.txtDataProvvCarico.TabIndex = 74;
			this.txtDataProvvCarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// txtProvvCarico
			// 
			this.txtProvvCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProvvCarico.Location = new System.Drawing.Point(16, 16);
			this.txtProvvCarico.MaxLength = 150;
			this.txtProvvCarico.Multiline = true;
			this.txtProvvCarico.Name = "txtProvvCarico";
			this.txtProvvCarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtProvvCarico.Size = new System.Drawing.Size(418, 69);
			this.txtProvvCarico.TabIndex = 72;
			// 
			// grpCedente
			// 
			this.grpCedente.Controls.Add(this.txtCedente);
			this.grpCedente.Location = new System.Drawing.Point(14, 155);
			this.grpCedente.Name = "grpCedente";
			this.grpCedente.Size = new System.Drawing.Size(372, 48);
			this.grpCedente.TabIndex = 85;
			this.grpCedente.TabStop = false;
			this.grpCedente.Tag = "AutoChoose.txtCedente.lista.(active=\'S\')";
			this.grpCedente.Text = "Cedente";
			// 
			// txtCedente
			// 
			this.txtCedente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCedente.Location = new System.Drawing.Point(16, 16);
			this.txtCedente.Name = "txtCedente";
			this.txtCedente.Size = new System.Drawing.Size(348, 23);
			this.txtCedente.TabIndex = 1;
			this.txtCedente.Tag = "registry_assetload.title?x";
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.txtDataDocCarico);
			this.groupBox9.Controls.Add(this.label20);
			this.groupBox9.Controls.Add(this.txtDocCarico);
			this.groupBox9.Location = new System.Drawing.Point(392, 7);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(444, 124);
			this.groupBox9.TabIndex = 87;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Documento";
			// 
			// txtDataDocCarico
			// 
			this.txtDataDocCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDocCarico.Location = new System.Drawing.Point(329, 92);
			this.txtDataDocCarico.Name = "txtDataDocCarico";
			this.txtDataDocCarico.Size = new System.Drawing.Size(105, 23);
			this.txtDataDocCarico.TabIndex = 65;
			this.txtDataDocCarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label20.Location = new System.Drawing.Point(274, 94);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(40, 16);
			this.label20.TabIndex = 66;
			this.label20.Text = "Data:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocCarico
			// 
			this.txtDocCarico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDocCarico.Location = new System.Drawing.Point(16, 16);
			this.txtDocCarico.MaxLength = 35;
			this.txtDocCarico.Multiline = true;
			this.txtDocCarico.Name = "txtDocCarico";
			this.txtDocCarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDocCarico.Size = new System.Drawing.Size(418, 73);
			this.txtDocCarico.TabIndex = 63;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Controls.Add(this.gboxUPB);
			this.tabPage2.Controls.Add(this.groupBox8);
			this.tabPage2.Controls.Add(this.grpResponsabile);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Selected = false;
			this.tabPage2.Size = new System.Drawing.Size(876, 508);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Page2";
			this.tabPage2.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.cmbConsegnatario);
			this.groupBox1.Controls.Add(this.chkSubRespInvariato);
			this.groupBox1.Location = new System.Drawing.Point(10, 296);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(626, 53);
			this.groupBox1.TabIndex = 98;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Selezionare il nuovo subconsegnatario o selezionare \"lascia invariato\"";
			// 
			// cmbConsegnatario
			// 
			this.cmbConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbConsegnatario.DataSource = this.DS.managerconsegnatario;
			this.cmbConsegnatario.DisplayMember = "title";
			this.cmbConsegnatario.Location = new System.Drawing.Point(8, 21);
			this.cmbConsegnatario.MaxDropDownItems = 25;
			this.cmbConsegnatario.Name = "cmbConsegnatario";
			this.cmbConsegnatario.Size = new System.Drawing.Size(466, 23);
			this.cmbConsegnatario.TabIndex = 0;
			this.cmbConsegnatario.ValueMember = "idman";
			this.cmbConsegnatario.SelectedIndexChanged += new System.EventHandler(this.cmbConsegnatario_SelectedIndexChanged);
			this.cmbConsegnatario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbConsegnatario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// chkSubRespInvariato
			// 
			this.chkSubRespInvariato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSubRespInvariato.AutoSize = true;
			this.chkSubRespInvariato.Location = new System.Drawing.Point(496, 23);
			this.chkSubRespInvariato.Name = "chkSubRespInvariato";
			this.chkSubRespInvariato.Size = new System.Drawing.Size(107, 19);
			this.chkSubRespInvariato.TabIndex = 100;
			this.chkSubRespInvariato.Text = "Lascia invariato";
			this.chkSubRespInvariato.UseVisualStyleBackColor = true;
			this.chkSubRespInvariato.CheckedChanged += new System.EventHandler(this.chkSubRespInvariato_CheckedChanged);
			// 
			// gboxUPB
			// 
			this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUPB.Controls.Add(this.chkUpbInvariato);
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.gboxUPB.Location = new System.Drawing.Point(10, 367);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(626, 104);
			this.gboxUPB.TabIndex = 97;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			this.gboxUPB.Text = "Selezionare il nuovo upb di destinazione o selezionare \"lascia invariato\"";
			// 
			// chkUpbInvariato
			// 
			this.chkUpbInvariato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkUpbInvariato.AutoSize = true;
			this.chkUpbInvariato.Location = new System.Drawing.Point(496, 51);
			this.chkUpbInvariato.Name = "chkUpbInvariato";
			this.chkUpbInvariato.Size = new System.Drawing.Size(107, 19);
			this.chkUpbInvariato.TabIndex = 101;
			this.chkUpbInvariato.Text = "Lascia invariato";
			this.chkUpbInvariato.UseVisualStyleBackColor = true;
			this.chkUpbInvariato.CheckedChanged += new System.EventHandler(this.chkUpbInvariato_CheckedChanged);
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 77);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(466, 23);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(126, 22);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(348, 49);
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
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.label26);
			this.groupBox8.Controls.Add(this.label24);
			this.groupBox8.Controls.Add(this.chkpreservaInventario);
			this.groupBox8.Controls.Add(this.txtEnteCarico);
			this.groupBox8.Controls.Add(this.label7);
			this.groupBox8.Controls.Add(this.label23);
			this.groupBox8.Controls.Add(this.cmbInventarioDest);
			this.groupBox8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox8.Location = new System.Drawing.Point(10, 5);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(626, 238);
			this.groupBox8.TabIndex = 96;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Selezionare l\'Inventario di Destinazione";
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(14, 185);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(601, 42);
			this.label26.TabIndex = 88;
			this.label26.Text = "Il trasferimento lascerà invariato il Numero Inventario se si sceglie tale opzion" +
    "e, oppure, in caso contrario, assegnerà un nuovo Numero";
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label24.Location = new System.Drawing.Point(13, 151);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(601, 42);
			this.label24.TabIndex = 87;
			this.label24.Text = "I cespiti selezionati e i relativi accessori saranno associati al nuovo inventari" +
    "o";
			// 
			// chkpreservaInventario
			// 
			this.chkpreservaInventario.AutoSize = true;
			this.chkpreservaInventario.Location = new System.Drawing.Point(30, 124);
			this.chkpreservaInventario.Name = "chkpreservaInventario";
			this.chkpreservaInventario.Size = new System.Drawing.Size(196, 17);
			this.chkpreservaInventario.TabIndex = 65;
			this.chkpreservaInventario.Text = "Preserva il Numero Inventario";
			this.chkpreservaInventario.UseVisualStyleBackColor = true;
			// 
			// txtEnteCarico
			// 
			this.txtEnteCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEnteCarico.Enabled = false;
			this.txtEnteCarico.Location = new System.Drawing.Point(67, 48);
			this.txtEnteCarico.Multiline = true;
			this.txtEnteCarico.Name = "txtEnteCarico";
			this.txtEnteCarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEnteCarico.Size = new System.Drawing.Size(543, 53);
			this.txtEnteCarico.TabIndex = 64;
			this.txtEnteCarico.Tag = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(14, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(47, 16);
			this.label7.TabIndex = 36;
			this.label7.Text = "Ente:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(13, 19);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(47, 16);
			this.label23.TabIndex = 33;
			this.label23.Text = "Tipo:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbInventarioDest
			// 
			this.cmbInventarioDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbInventarioDest.DataSource = this.DS.inventory_dest;
			this.cmbInventarioDest.DisplayMember = "description";
			this.cmbInventarioDest.Location = new System.Drawing.Point(66, 19);
			this.cmbInventarioDest.MaxDropDownItems = 25;
			this.cmbInventarioDest.Name = "cmbInventarioDest";
			this.cmbInventarioDest.Size = new System.Drawing.Size(544, 21);
			this.cmbInventarioDest.TabIndex = 28;
			this.cmbInventarioDest.ValueMember = "idinventory";
			this.cmbInventarioDest.SelectedIndexChanged += new System.EventHandler(this.cmbInventarioDest_SelectedIndexChanged);
			this.cmbInventarioDest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbInventarioDest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// grpResponsabile
			// 
			this.grpResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpResponsabile.Controls.Add(this.cmbResponsabile);
			this.grpResponsabile.Controls.Add(this.chkRespInvariato);
			this.grpResponsabile.Location = new System.Drawing.Point(11, 248);
			this.grpResponsabile.Name = "grpResponsabile";
			this.grpResponsabile.Size = new System.Drawing.Size(625, 46);
			this.grpResponsabile.TabIndex = 7;
			this.grpResponsabile.TabStop = false;
			this.grpResponsabile.Text = "Selezionare il nuovo responsabile o selezionare \"lascia invariato\"";
			// 
			// cmbResponsabile
			// 
			this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbResponsabile.DataSource = this.DS.manager;
			this.cmbResponsabile.DisplayMember = "title";
			this.cmbResponsabile.Location = new System.Drawing.Point(8, 19);
			this.cmbResponsabile.MaxDropDownItems = 25;
			this.cmbResponsabile.Name = "cmbResponsabile";
			this.cmbResponsabile.Size = new System.Drawing.Size(465, 23);
			this.cmbResponsabile.TabIndex = 0;
			this.cmbResponsabile.ValueMember = "idman";
			this.cmbResponsabile.SelectedIndexChanged += new System.EventHandler(this.cboResp_SelectedIndexChanged);
			this.cmbResponsabile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbResponsabile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// chkRespInvariato
			// 
			this.chkRespInvariato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkRespInvariato.AutoSize = true;
			this.chkRespInvariato.Location = new System.Drawing.Point(495, 19);
			this.chkRespInvariato.Name = "chkRespInvariato";
			this.chkRespInvariato.Size = new System.Drawing.Size(107, 19);
			this.chkRespInvariato.TabIndex = 99;
			this.chkRespInvariato.Text = "Lascia invariato";
			this.chkRespInvariato.UseVisualStyleBackColor = true;
			this.chkRespInvariato.CheckedChanged += new System.EventHandler(this.chkRespInvariato_CheckedChanged);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Controls.Add(this.label27);
			this.tabPage4.Controls.Add(this.txtDataRatificaScarico);
			this.tabPage4.Controls.Add(this.groupBox4);
			this.tabPage4.Controls.Add(this.txtDataContScarico);
			this.tabPage4.Controls.Add(this.label3);
			this.tabPage4.Controls.Add(this.txtDataStampaScarico);
			this.tabPage4.Controls.Add(this.grpCausaleScarico);
			this.tabPage4.Controls.Add(this.groupBox2);
			this.tabPage4.Controls.Add(this.grpCessionario);
			this.tabPage4.Controls.Add(this.groupBox3);
			this.tabPage4.Location = new System.Drawing.Point(0, 0);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(876, 508);
			this.tabPage4.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(10, 321);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 16);
			this.label4.TabIndex = 98;
			this.label4.Text = "Data stampa:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(12, 350);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(94, 16);
			this.label27.TabIndex = 97;
			this.label27.Text = "Data ratifica:";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataRatificaScarico
			// 
			this.txtDataRatificaScarico.Location = new System.Drawing.Point(112, 350);
			this.txtDataRatificaScarico.Name = "txtDataRatificaScarico";
			this.txtDataRatificaScarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataRatificaScarico.TabIndex = 96;
			this.txtDataRatificaScarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.txtDescrBuonoScarico);
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.cmbTipoBuonoScarico);
			this.groupBox4.Location = new System.Drawing.Point(9, 5);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(375, 170);
			this.groupBox4.TabIndex = 84;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Buono di scarico";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 84;
			this.label1.Text = "Tipo:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDescrBuonoScarico
			// 
			this.txtDescrBuonoScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBuonoScarico.Location = new System.Drawing.Point(15, 101);
			this.txtDescrBuonoScarico.MaxLength = 150;
			this.txtDescrBuonoScarico.Multiline = true;
			this.txtDescrBuonoScarico.Name = "txtDescrBuonoScarico";
			this.txtDescrBuonoScarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrBuonoScarico.Size = new System.Drawing.Size(352, 56);
			this.txtDescrBuonoScarico.TabIndex = 82;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(17, 81);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 16);
			this.label11.TabIndex = 83;
			this.label11.Text = "Descrizione:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbTipoBuonoScarico
			// 
			this.cmbTipoBuonoScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoBuonoScarico.DataSource = this.DS.assetunloadkind;
			this.cmbTipoBuonoScarico.DisplayMember = "description";
			this.cmbTipoBuonoScarico.Location = new System.Drawing.Point(17, 34);
			this.cmbTipoBuonoScarico.MaxDropDownItems = 25;
			this.cmbTipoBuonoScarico.Name = "cmbTipoBuonoScarico";
			this.cmbTipoBuonoScarico.Size = new System.Drawing.Size(352, 23);
			this.cmbTipoBuonoScarico.TabIndex = 80;
			this.cmbTipoBuonoScarico.ValueMember = "idassetunloadkind";
			this.cmbTipoBuonoScarico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbTipoBuonoScarico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// txtDataContScarico
			// 
			this.txtDataContScarico.Location = new System.Drawing.Point(112, 282);
			this.txtDataContScarico.Name = "txtDataContScarico";
			this.txtDataContScarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataContScarico.TabIndex = 80;
			this.txtDataContScarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 283);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 16);
			this.label3.TabIndex = 82;
			this.label3.Text = "Data contabile";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataStampaScarico
			// 
			this.txtDataStampaScarico.Location = new System.Drawing.Point(112, 316);
			this.txtDataStampaScarico.Name = "txtDataStampaScarico";
			this.txtDataStampaScarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataStampaScarico.TabIndex = 81;
			this.txtDataStampaScarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// grpCausaleScarico
			// 
			this.grpCausaleScarico.Controls.Add(this.cboCausaleScarico);
			this.grpCausaleScarico.Location = new System.Drawing.Point(3, 235);
			this.grpCausaleScarico.Name = "grpCausaleScarico";
			this.grpCausaleScarico.Size = new System.Drawing.Size(370, 40);
			this.grpCausaleScarico.TabIndex = 31;
			this.grpCausaleScarico.TabStop = false;
			this.grpCausaleScarico.Tag = "";
			this.grpCausaleScarico.Text = "Causale di Scarico";
			// 
			// cboCausaleScarico
			// 
			this.cboCausaleScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboCausaleScarico.DataSource = this.DS.assetunloadmotive;
			this.cboCausaleScarico.DisplayMember = "description";
			this.cboCausaleScarico.Location = new System.Drawing.Point(16, 14);
			this.cboCausaleScarico.MaxDropDownItems = 25;
			this.cboCausaleScarico.Name = "cboCausaleScarico";
			this.cboCausaleScarico.Size = new System.Drawing.Size(348, 23);
			this.cboCausaleScarico.TabIndex = 48;
			this.cboCausaleScarico.ValueMember = "idmot";
			this.cboCausaleScarico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cboCausaleScarico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label15);
			this.groupBox2.Controls.Add(this.txtDataProvvScarico);
			this.groupBox2.Controls.Add(this.txtProvvScarico);
			this.groupBox2.Location = new System.Drawing.Point(390, 143);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(449, 132);
			this.groupBox2.TabIndex = 33;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Provvedimento";
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.Location = new System.Drawing.Point(284, 98);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(40, 16);
			this.label15.TabIndex = 75;
			this.label15.Text = "Data:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataProvvScarico
			// 
			this.txtDataProvvScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataProvvScarico.Location = new System.Drawing.Point(332, 98);
			this.txtDataProvvScarico.Name = "txtDataProvvScarico";
			this.txtDataProvvScarico.Size = new System.Drawing.Size(88, 23);
			this.txtDataProvvScarico.TabIndex = 74;
			this.txtDataProvvScarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// txtProvvScarico
			// 
			this.txtProvvScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProvvScarico.Location = new System.Drawing.Point(16, 16);
			this.txtProvvScarico.MaxLength = 150;
			this.txtProvvScarico.Multiline = true;
			this.txtProvvScarico.Name = "txtProvvScarico";
			this.txtProvvScarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtProvvScarico.Size = new System.Drawing.Size(398, 71);
			this.txtProvvScarico.TabIndex = 72;
			// 
			// grpCessionario
			// 
			this.grpCessionario.Controls.Add(this.txtCessionario);
			this.grpCessionario.Location = new System.Drawing.Point(8, 181);
			this.grpCessionario.Name = "grpCessionario";
			this.grpCessionario.Size = new System.Drawing.Size(370, 48);
			this.grpCessionario.TabIndex = 30;
			this.grpCessionario.TabStop = false;
			this.grpCessionario.Tag = "AutoChoose.txtCessionario.default.(active=\'S\')";
			this.grpCessionario.Text = "Cessionario";
			// 
			// txtCessionario
			// 
			this.txtCessionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCessionario.Location = new System.Drawing.Point(16, 16);
			this.txtCessionario.Name = "txtCessionario";
			this.txtCessionario.Size = new System.Drawing.Size(338, 23);
			this.txtCessionario.TabIndex = 1;
			this.txtCessionario.Tag = "registry_assetunload.title?x";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.txtDataDocScarico);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.txtDocScarico);
			this.groupBox3.Location = new System.Drawing.Point(388, 4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(451, 140);
			this.groupBox3.TabIndex = 32;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Documento";
			// 
			// txtDataDocScarico
			// 
			this.txtDataDocScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDocScarico.Location = new System.Drawing.Point(334, 104);
			this.txtDataDocScarico.Name = "txtDataDocScarico";
			this.txtDataDocScarico.Size = new System.Drawing.Size(80, 23);
			this.txtDataDocScarico.TabIndex = 65;
			this.txtDataDocScarico.Leave += new System.EventHandler(this.txtData_Leave);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(286, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 66;
			this.label2.Text = "Data:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocScarico
			// 
			this.txtDocScarico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDocScarico.Location = new System.Drawing.Point(16, 16);
			this.txtDocScarico.MaxLength = 35;
			this.txtDocScarico.Multiline = true;
			this.txtDocScarico.Name = "txtDocScarico";
			this.txtDocScarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDocScarico.Size = new System.Drawing.Size(400, 82);
			this.txtDocScarico.TabIndex = 63;
			// 
			// tabPage2bis
			// 
			this.tabPage2bis.Controls.Add(this.groupBox10);
			this.tabPage2bis.Controls.Add(this.btnSelezionaTutto);
			this.tabPage2bis.Controls.Add(this.label17);
			this.tabPage2bis.Controls.Add(this.label10);
			this.tabPage2bis.Location = new System.Drawing.Point(0, 0);
			this.tabPage2bis.Name = "tabPage2bis";
			this.tabPage2bis.Selected = false;
			this.tabPage2bis.Size = new System.Drawing.Size(876, 508);
			this.tabPage2bis.TabIndex = 7;
			this.tabPage2bis.Title = "Page 2bis";
			// 
			// groupBox10
			// 
			this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox10.Controls.Add(this.gridCespiti);
			this.groupBox10.Location = new System.Drawing.Point(12, 62);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(834, 426);
			this.groupBox10.TabIndex = 31;
			this.groupBox10.TabStop = false;
			// 
			// gridCespiti
			// 
			this.gridCespiti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridCespiti.DataMember = "";
			this.gridCespiti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridCespiti.Location = new System.Drawing.Point(6, 12);
			this.gridCespiti.Name = "gridCespiti";
			this.gridCespiti.Size = new System.Drawing.Size(795, 391);
			this.gridCespiti.TabIndex = 0;
			this.gridCespiti.Tag = "assetview.default";
			// 
			// btnSelezionaTutto
			// 
			this.btnSelezionaTutto.Location = new System.Drawing.Point(13, 9);
			this.btnSelezionaTutto.Name = "btnSelezionaTutto";
			this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
			this.btnSelezionaTutto.TabIndex = 30;
			this.btnSelezionaTutto.Text = "Seleziona tutto";
			this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click_1);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(117, 9);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(456, 32);
			this.label17.TabIndex = 29;
			this.label17.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
    "per selezionare più cespiti da trasferire";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(12, 43);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(440, 16);
			this.label10.TabIndex = 1;
			this.label10.Text = "Verranno elaborati i seguenti cespiti principali:";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grpInventoryOrigin);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Selected = false;
			this.tabPage1.Size = new System.Drawing.Size(876, 508);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Page1";
			this.tabPage1.Visible = false;
			// 
			// grpInventoryOrigin
			// 
			this.grpInventoryOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpInventoryOrigin.Controls.Add(this.label29);
			this.grpInventoryOrigin.Controls.Add(this.cboConsegnatario);
			this.grpInventoryOrigin.Controls.Add(this.label28);
			this.grpInventoryOrigin.Controls.Add(this.cboResp);
			this.grpInventoryOrigin.Controls.Add(this.chkReady);
			this.grpInventoryOrigin.Controls.Add(this.label22);
			this.grpInventoryOrigin.Controls.Add(this.label25);
			this.grpInventoryOrigin.Controls.Add(this.txtEnteScarico);
			this.grpInventoryOrigin.Controls.Add(this.label21);
			this.grpInventoryOrigin.Controls.Add(this.label16);
			this.grpInventoryOrigin.Controls.Add(this.label13);
			this.grpInventoryOrigin.Controls.Add(this.cmbInventarioOrig);
			this.grpInventoryOrigin.Controls.Add(this.txt_numinv_a);
			this.grpInventoryOrigin.Controls.Add(this.txt_numinv_da);
			this.grpInventoryOrigin.Controls.Add(this.label5);
			this.grpInventoryOrigin.Controls.Add(this.label6);
			this.grpInventoryOrigin.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpInventoryOrigin.Location = new System.Drawing.Point(7, 4);
			this.grpInventoryOrigin.Name = "grpInventoryOrigin";
			this.grpInventoryOrigin.Size = new System.Drawing.Size(835, 476);
			this.grpInventoryOrigin.TabIndex = 85;
			this.grpInventoryOrigin.TabStop = false;
			this.grpInventoryOrigin.Text = "Selezionare l\'Inventario di Partenza";
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(12, 131);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(146, 32);
			this.label29.TabIndex = 92;
			this.label29.Text = "Subconsegnatario attuale";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboConsegnatario
			// 
			this.cboConsegnatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboConsegnatario.DataSource = this.DS.managerconsegnatario_origin;
			this.cboConsegnatario.DisplayMember = "title";
			this.cboConsegnatario.Location = new System.Drawing.Point(164, 131);
			this.cboConsegnatario.MaxDropDownItems = 25;
			this.cboConsegnatario.Name = "cboConsegnatario";
			this.cboConsegnatario.Size = new System.Drawing.Size(628, 21);
			this.cboConsegnatario.TabIndex = 91;
			this.cboConsegnatario.ValueMember = "idman";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(14, 104);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(136, 23);
			this.label28.TabIndex = 90;
			this.label28.Text = "Responsabile attuale";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cboResp
			// 
			this.cboResp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboResp.DataSource = this.DS.manager_orig;
			this.cboResp.DisplayMember = "title";
			this.cboResp.Location = new System.Drawing.Point(166, 104);
			this.cboResp.MaxDropDownItems = 25;
			this.cboResp.Name = "cboResp";
			this.cboResp.Size = new System.Drawing.Size(628, 21);
			this.cboResp.TabIndex = 89;
			this.cboResp.ValueMember = "idman";
			// 
			// chkReady
			// 
			this.chkReady.AutoSize = true;
			this.chkReady.Location = new System.Drawing.Point(16, 298);
			this.chkReady.Name = "chkReady";
			this.chkReady.Size = new System.Drawing.Size(389, 17);
			this.chkReady.TabIndex = 88;
			this.chkReady.Text = "Seleziona solo cespiti marcati come \"Pronti per il trasferimento\"";
			this.chkReady.UseVisualStyleBackColor = true;
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label22.Location = new System.Drawing.Point(16, 205);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(778, 23);
			this.label22.TabIndex = 87;
			this.label22.Text = "Saranno trasferiti anche gli accessori associati";
			// 
			// label25
			// 
			this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label25.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(15, 163);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(778, 42);
			this.label25.TabIndex = 86;
			this.label25.Text = resources.GetString("label25.Text");
			// 
			// txtEnteScarico
			// 
			this.txtEnteScarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEnteScarico.Enabled = false;
			this.txtEnteScarico.Location = new System.Drawing.Point(67, 48);
			this.txtEnteScarico.Multiline = true;
			this.txtEnteScarico.Name = "txtEnteScarico";
			this.txtEnteScarico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEnteScarico.Size = new System.Drawing.Size(725, 50);
			this.txtEnteScarico.TabIndex = 64;
			this.txtEnteScarico.Tag = "";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(14, 48);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(47, 16);
			this.label21.TabIndex = 36;
			this.label21.Text = "Ente:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(15, 240);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(123, 20);
			this.label16.TabIndex = 34;
			this.label16.Text = "Numeri Inventario:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(13, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(47, 16);
			this.label13.TabIndex = 33;
			this.label13.Text = "Tipo:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbInventarioOrig
			// 
			this.cmbInventarioOrig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbInventarioOrig.DataSource = this.DS.inventory_origin;
			this.cmbInventarioOrig.DisplayMember = "description";
			this.cmbInventarioOrig.Location = new System.Drawing.Point(66, 19);
			this.cmbInventarioOrig.MaxDropDownItems = 25;
			this.cmbInventarioOrig.Name = "cmbInventarioOrig";
			this.cmbInventarioOrig.Size = new System.Drawing.Size(726, 21);
			this.cmbInventarioOrig.TabIndex = 28;
			this.cmbInventarioOrig.ValueMember = "idinventory";
			this.cmbInventarioOrig.SelectedIndexChanged += new System.EventHandler(this.cmbInventarioOrig_SelectedIndexChanged);
			this.cmbInventarioOrig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbInventarioOrig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			// 
			// txt_numinv_a
			// 
			this.txt_numinv_a.Location = new System.Drawing.Point(290, 239);
			this.txt_numinv_a.Name = "txt_numinv_a";
			this.txt_numinv_a.Size = new System.Drawing.Size(63, 21);
			this.txt_numinv_a.TabIndex = 31;
			// 
			// txt_numinv_da
			// 
			this.txt_numinv_da.Location = new System.Drawing.Point(175, 239);
			this.txt_numinv_da.Name = "txt_numinv_da";
			this.txt_numinv_da.Size = new System.Drawing.Size(63, 21);
			this.txt_numinv_da.TabIndex = 29;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(256, 243);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 16);
			this.label5.TabIndex = 32;
			this.label5.Text = "a:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(135, 239);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 16);
			this.label6.TabIndex = 30;
			this.label6.Text = "Da:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPageInizio
			// 
			this.tabPageInizio.Controls.Add(this.lblFase1);
			this.tabPageInizio.Location = new System.Drawing.Point(0, 0);
			this.tabPageInizio.Name = "tabPageInizio";
			this.tabPageInizio.Selected = false;
			this.tabPageInizio.Size = new System.Drawing.Size(876, 508);
			this.tabPageInizio.TabIndex = 6;
			this.tabPageInizio.Title = "Inizio";
			// 
			// lblFase1
			// 
			this.lblFase1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFase1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.lblFase1.Location = new System.Drawing.Point(8, 16);
			this.lblFase1.Name = "lblFase1";
			this.lblFase1.Size = new System.Drawing.Size(833, 404);
			this.lblFase1.TabIndex = 0;
			// 
			// tabController
			// 
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(0, 0);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 3;
			this.tabController.SelectedTab = this.tabPage4;
			this.tabController.Size = new System.Drawing.Size(876, 533);
			this.tabController.TabIndex = 1;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPageInizio,
            this.tabPage1,
            this.tabPage2bis,
            this.tabPage4,
            this.tabPage2,
            this.tabPage3,
            this.tabPage5});
			this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabController);
			this.panel1.Location = new System.Drawing.Point(1, 1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(876, 533);
			this.panel1.TabIndex = 13;
			// 
			// Frm_asset_cambioinventario
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(885, 574);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.btnBack);
			this.Name = "Frm_asset_cambioinventario";
			this.Text = "frmasset_cambioinventario";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.grpCedente.ResumeLayout(false);
			this.grpCedente.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.grpResponsabile.ResumeLayout(false);
			this.grpResponsabile.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.grpCausaleScarico.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpCessionario.ResumeLayout(false);
			this.grpCessionario.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage2bis.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridCespiti)).EndInit();
			this.tabPage1.ResumeLayout(false);
			this.grpInventoryOrigin.ResumeLayout(false);
			this.grpInventoryOrigin.PerformLayout();
			this.tabPageInizio.ResumeLayout(false);
			this.tabController.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            object dataContabile = Meta.GetSys("datacontabile");
            object esercizio = Meta.GetSys("esercizio");
            txtDataContCarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            txtDataContScarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            txtDataRatificaCarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            txtDataRatificaScarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            txtDataStampaScarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            txtDataStampaCarico.Text = HelpForm.StringValue(dataContabile, "x.y");
            string filteresercload = QHS.CmpEq("yassetload", esercizio);
            string filteresercunload = QHS.CmpEq("yassetunload", esercizio);
            string filterconfig = QHS.CmpEq("ayear", esercizio);
            GetData.CacheTable(DS.config, filterconfig, null, false);
            //GetData.SetStaticFilter(DS.assetload, filteresercload);
            //GetData.SetStaticFilter(DS.assetunload, filteresercunload);

        }
        public void MetaData_AfterRowSelect(DataTable t,DataRow r) {
            if (t.TableName == "upb" && r != null) {
                chkUpbInvariato.Checked = false;
            }
        }

        public void MetaData_AfterClear() {
            DisplayTabs(0);
        }

        public void MetaData_AfterActivation() {
            EsaminaFlag();
        }

        bool flagcreddeb;
        bool flagcausale;

        private void EsaminaFlag() {

            if (DS.config.Rows.Count == 0) {
                show("La configurazione del PATRIMONIO non è stata definita per l'esercizio corrente. " +
                                "Non sarà possibile salvare il buono di carico.\r" +
                                @"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione",
                    "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Meta.CanSave = false;
                return;
            }
            DataRow r = DS.Tables["config"].Rows[0];
            string flagnumerazione = r["asset_flagnumbering"].ToString().ToUpper();
            if (flagnumerazione == "" || flagnumerazione == "N") {
                show("Non è stato definito il tipo di numerazione per la configurazione " +
                                "del PATRIMONIO per l'esercizio corrente. " +
                                "Non sarà possibile salvare il buono di carico.\r" +
                                @"La configurazione si trova alla voce di menu Configurazione\Operazioni inventariabili\Configurazione",
                    "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Meta.CanSave = false;
                return;
            }
            byte assetload_flag = (byte) r["assetload_flag"];
            flagcreddeb = (assetload_flag & 1) != 0;
            flagcausale = (assetload_flag & 2) != 0;
            //txtCedente.ReadOnly = !flagcreddeb;
            //cmbCausaleCarico.Enabled = flagcausale;
            //txtCessionario.ReadOnly = !flagcreddeb;
            //cboCausaleScarico.Enabled = flagcausale;

        }

        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }


        bool CustomChangeTab(int oldTab, int newTab) {
            if ((oldTab == 0) && (newTab == 1)) return true;
            if (((oldTab == 1) && (newTab == 2)) || ((oldTab == 3) && (newTab == 2))) {
                if (GetFiltroScarico()) {
                    return AggiornaGrid();
                }
                return false;
            }

            if ((oldTab == 3) && (newTab == 4)) return GetInfoBuonoScarico();
            if ((oldTab == 4) && (newTab == 5)) return GetFiltroCarico();
            if ((oldTab == 5) && (newTab == 6)) return AggiornaDati();


            /*if ((oldTab==4)&&(newTab==3)) {
				DS.assetmanager.Clear();
				DS.assetview.RejectChanges();
				return true;
			}*/
            return true;
        }

        DataTable T1; //1.Accessori nuova acquisizione non ancora scaricati
        DataTable T2; //2.Accessori posseduti scaricati
        DataTable T3; //3.Accessori posseduti non scaricati
        DataTable T4; //4.Rivalutazioni Cespiti
        DataTable T5; //5.Svalutazioni  Cespiti
        DataTable T6; //6.Rivalutazioni Accessori Nuova Acquisizione Non Ancora Scaricati 
        DataTable T7; //7.Rivalutazioni Accessori Posseduti e già Scaricati
        DataTable T8; //8.Svalutazioni  Accessori Nuova Acquisizione Non Ancora Scaricati  
        DataTable T9; //9.Svalutazioni  Accessori Posseduti e già Scaricati
        DataTable T10; //10.Rivalutazioni Accessori Posseduti non ancora Scaricati 
        DataTable T11; //11.Svalutazioni  Accessori Posseduti e non ancora Scaricati


        private void GetEntitaDipendenti() {
            string filter = "";

            int N5 = 0;
            int N6 = 0;
            string numinv_da = txt_numinv_da.Text.Trim();
            string numinv_a = txt_numinv_a.Text.Trim();
            if ((numinv_da != "") && (isNumeric(numinv_da, out N5))) {
                N5 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), numinv_da, "x.y"));
                if (N5 > 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpGe("A.ninventory", N5));
                }
            }
            if ((numinv_a != "") && (isNumeric(numinv_a, out N6))) {
                N6 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), numinv_a, "x.y"));
                if (N6 > 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpLe("A.ninventory", N6));
                }
            }

            if (cmbInventarioOrig.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("A.idinventory", cmbInventarioOrig.SelectedValue));
            }
            if (cboResp.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("A.idcurrman", cboResp.SelectedValue));
            }


            // In base ai cespiti che sono stati selezionati saranno ottenuti anche
            // gli accessori e gli ammortamenti da scaricare
            // Al fine di preservare il valore attuale del bene al momento del trasferimento
            // è necessario tenere conto della storia del cespite e trasferire nel nuovo inventario:
            // 1. carichi degli accessori attualmente in carico  (sia posseduti sia di nuova acquisizione)
            // 2. ammortamenti degli accessori attualmente in carico
            // 3. ammortamenti degli accessori caricati come posseduti e poi scaricati
            // 4. ammortamenti del cespite principale
            // 5. scarichi degli accessori che erano stati caricati come posseduti

            // Filtri: Accessori
            string filtroCespite = QHS.AppAnd(filter,
                QHS.CmpEq("A.idpiece", 1),
                QHS.DoPar(QHS.AppOr(QHS.CmpEq("A.flagload", "N"), QHS.IsNotNull("A.idassetload"))));
            if (chkReady.Checked) {
                filtroCespite = QHS.AppAnd(filtroCespite, QHS.CmpEq("A.flagtransf", 'S'));
                    // pronti per il trasferimento
            }
            string filtroAccessori = QHS.AppAnd(filter,
                QHS.CmpGt("A.idpiece", 1),
                QHS.DoPar(QHS.AppOr(QHS.CmpEq("A.flagload", "N"), QHS.IsNotNull("A.idassetload"))));
            string filtroAccessoriPosseduti = QHS.AppAnd(filtroAccessori, QHS.CmpEq("A.loadkind", "R"));
            string filtroAccessoriNuovaAcq = QHS.AppAnd(filtroAccessori, QHS.CmpEq("A.loadkind", "N"));
            string filtroScaricati =
                QHS.DoPar(QHS.AppOr(QHS.CmpEq("A.flagunload", "N"), QHS.IsNotNull("A.idassetunload")));
            string filtroNonScaricati = QHS.Not(filtroScaricati);
            string filtroAmmortamentiScaricati =
                QHS.DoPar(QHS.AppOr(QHS.CmpEq("B.flagunload", "N"), QHS.IsNotNull("B.idassetunload")));

            // Filtri: Rivalutazioni/Svalutazioni ufficiali
            string filtroOfficial = QHS.CmpNe("B.official", "N");
            // Rivalutazioni positive di cespiti (quota >0)
            string filtroRivalCespiti = QHS.AppAnd(filtroOfficial, filter,
                QHS.CmpEq("A.idpiece", 1), QHS.CmpGt("B.amortizationquota", 0));
            // Svalutazioni di cespiti (quota < 0)
            string filtroSvalCespiti = QHS.AppAnd(filtroOfficial, filter,
                QHS.CmpEq("A.idpiece", 1),
                QHS.CmpLt("B.amortizationquota", 0),
                filtroAmmortamentiScaricati);
            // Rivalutazioni positive di accessori (quota >0)
            string filtroRivalAccessori = QHS.AppAnd(filtroOfficial, filter,
                QHS.CmpGt("A.idpiece", 1), QHS.CmpGt("B.amortizationquota", 0));
            // Svalutazioni di accessori di (quota < 0)
            string filtroSvalAccessori = QHS.AppAnd(filtroOfficial, filter,
                QHS.CmpGt("A.idpiece", 1),
                QHS.CmpLt("B.amortizationquota", 0),
                filtroAmmortamentiScaricati);


            //1.Accessori nuova acquisizione non ancora scaricati
            string queryT1 = " select * from assetview A where " +
                             QHS.AppAnd(filtroAccessoriNuovaAcq, filtroNonScaricati);
            T1 = Meta.Conn.SQLRunner(queryT1, true);

            //2.Accessori posseduti scaricati
            string queryT2 = " select * from assetview A where " + QHS.AppAnd(filtroAccessoriPosseduti, filtroScaricati);
            T2 = Meta.Conn.SQLRunner(queryT2, true);
            // caricare tali e quali nel nuovo inventario
            // accessori posseduti e scaricati
            // sono da  ricreare anche nel nuovo inventario e contestualmente scaricare


            //3.Accessori posseduti non scaricati
            string queryT3 = " select * from assetview A where " +
                             QHS.AppAnd(filtroAccessoriPosseduti, filtroNonScaricati);
            T3 = Meta.Conn.SQLRunner(queryT3, true);

            // SVALUTAZIONI E RIVALUTAZIONI UFFICIALI DI CESPITI


            //4. Rivalutazioni Cespiti
            string queryT4 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroCespite, filtroRivalCespiti);
            T4 = Meta.Conn.SQLRunner(queryT4, true);

            //5. Svalutazioni Cespiti
            string queryT5 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroCespite, filtroSvalCespiti);
            T5 = Meta.Conn.SQLRunner(queryT5, true);


            // AGGIUNGO SVALUTAZIONI E RIVALUTAZIONI ACCESSORI

            //6. Rivalutazioni Accessori Nuova Acquisizione Non Scaricati 
            string queryT6 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroAccessoriNuovaAcq, filtroNonScaricati, filtroRivalAccessori);
            T6 = Meta.Conn.SQLRunner(queryT6, true);

            //7. Rivalutazioni Accessori Posseduti e già Scaricati
            string queryT7 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroAccessoriPosseduti, filtroScaricati, filtroRivalAccessori);
            T7 = Meta.Conn.SQLRunner(queryT7, true);

            //8. Svalutazioni Accessori Nuova Acquisizione Non Scaricati 
            string queryT8 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroAccessoriNuovaAcq, filtroNonScaricati, filtroSvalAccessori);
            T8 = Meta.Conn.SQLRunner(queryT8, true);


            //9. Svalutazioni Accessori Posseduti e già Scaricati
            string queryT9 = " select B.* from assetamortizationview B " +
                             " join assetview A ON A.idasset = B.idasset " +
                             " and A.idpiece = B.idpiece " +
                             " where  " +
                             QHS.AppAnd(filtroAccessoriPosseduti, filtroScaricati, filtroSvalAccessori);
            T9 = Meta.Conn.SQLRunner(queryT9, true);


            // 10.Rivalutazioni Accessori Posseduti Non Scaricati
            string queryT10 = " select B.* from assetamortizationview B " +
                              " join assetview A ON A.idasset = B.idasset " +
                              " and A.idpiece = B.idpiece " +
                              " where  " +
                              QHS.AppAnd(filtroAccessoriPosseduti, filtroNonScaricati, filtroRivalAccessori);
            T10 = Meta.Conn.SQLRunner(queryT10, true);

            // 11.Svalutazioni Accessori Posseduti Non Scaricati
            string queryT11 = " select B.* from assetamortizationview B " +
                              " join assetview A ON A.idasset = B.idasset " +
                              " and A.idpiece = B.idpiece " +
                              " where  " +
                              QHS.AppAnd(filtroAccessoriPosseduti, filtroNonScaricati, filtroSvalAccessori);
            T11 = Meta.Conn.SQLRunner(queryT11, true);


        }


        private DataRow CreateNewAssetUnload(bool Origin) {
            object myidassetunloadkind = assetUnloadKind;
            if (Origin == false) {
                //Cerca un tipo buono di scarico su idinventoryDest
                if (DS.assetunloadkind.Select(QHC.CmpEq("idinventory", cmbInventarioDest.SelectedValue)).Length > 0) {
                    myidassetunloadkind = DS.assetunloadkind.Select(
                        QHC.CmpEq("idinventory", cmbInventarioDest.SelectedValue))[0]["idassetunloadkind"];
                }
            }

            // Crea Buono Scarico 
            MetaData MScar = MetaData.GetMetaData(this, "assetunload");
            MScar.SetDefaults(DS.assetunload);
            DataRow NewScar = MScar.Get_New_Row(null, DS.assetunload);
            NewScar["yassetunload"] = Meta.GetSys("esercizio");
            NewScar["idassetunloadkind"] = myidassetunloadkind;
            NewScar["idmot"] = assetUnloadMotive;
            NewScar["adate"] = _adateUnload;
            NewScar["description"] = descUnload;
            NewScar["doc"] = docUnload;
            NewScar["docdate"] = docDateUnload;
            NewScar["enactment"] = enactmentUnload;
            NewScar["enactmentdate"] = enactmentDateUnload;
            NewScar["idreg"] = cessionario;
            NewScar["printdate"] = printDateUnload;
            NewScar["ratificationdate"] = ratificationDateUnLoad;
            NewScar["ct"] = DateTime.Now;
            NewScar["cu"] = "trasf_inventario";
            NewScar["lt"] = DateTime.Now;
            NewScar["lu"] = "trasf_inventario";
            return NewScar;
        }

        /// <summary>
        /// Crea un nuovo cespite azzerando il flag "pronto per il cambio di inventario" e senza collegamento al buono di scarico.
        /// </summary>
        /// <param name="new_nassetacquire"></param>
        /// <param name="rAsset"></param>
        /// <param name="datacarico"></param>
        /// <param name="ninventory"></param>
        /// <returns></returns>
        private object CreateNewAsset(DataRow new_nassetacquire, DataRow rAsset,
            object datacarico,
            out object ninventory) {
            //Crea in asset i cespiti/accessori nuovi  
            DataRow NewAsset = MAsset.Get_New_Row(new_nassetacquire, DS.asset);
            NewAsset["idasset_prev"] = rAsset["idasset"];
            NewAsset["idpiece_prev"] = 1;
            NewAsset["ct"] = DateTime.Now;
            ;
            NewAsset["cu"] = "trasf_inventario";
            string FilterDate = QHS.AppAnd(QHS.CmpEq("nassetload", rAsset["nassetload"]),
                QHS.CmpEq("yassetload", rAsset["yassetload"]));
            object DataCaricoProvenienza = Meta.Conn.DO_READ_VALUE("assetload", FilterDate, "adate");

            if (rAsset["lifestart"] != DBNull.Value) {
                NewAsset["lifestart"] = rAsset["lifestart"];
            }
            else {
                if (DataCaricoProvenienza != DBNull.Value) {
                    NewAsset["lifestart"] = DataCaricoProvenienza;
                }
                else {
                    NewAsset["lifestart"] = datacarico;
                }
            }
            NewAsset["lt"] = DateTime.Now;
            NewAsset["lu"] = "trasf_inventario";
            NewAsset["nassetacquire"] = new_nassetacquire["nassetacquire"];
            NewAsset["idinventory"] = new_nassetacquire["idinventory"];
            // attenzione al numero inventario
            if (chkpreservaInventario.Checked) {
                // Preservare lo stesso numero inventario
                NewAsset["ninventory"] = rAsset["ninventory"];
            }
            else {
                // Preservare lo stesso numero inventario, ricalcolare il numero
                // a seconda che si tratti di bene posseduto o nuova acquisizione
                NewAsset["ninventory"] = GetNextNInventory(new_nassetacquire["idinventory"]) + 1;
            }

            NewAsset["rtf"] = rAsset["rtf"];
            NewAsset["txt"] = rAsset["txt"];
            NewAsset["multifield"] = rAsset["multifield"];
            NewAsset["transmitted"] = "N";
            NewAsset["idassetunload"] = DBNull.Value;
            NewAsset["flag"] = (CfgFn.GetNoNullInt32(rAsset["flag"]) & 0xFB);
            ninventory = NewAsset["ninventory"];
            return NewAsset["idasset"];
        }


        /// <summary>
        /// Crea un accessorio con caratteristiche analoghe a quello in ingresso (escluso buono scarico)
        /// </summary>
        /// <param name="R"></param>
        /// <param name="new_nassetacquire"></param>
        /// <param name="old_idasset"></param>
        /// <param name="new_idasset"></param>
        /// <param name="datacarico"></param>
        private DataRow CreateNewAssetPiece(DataRow R, DataRow new_nassetacquire,
            object old_idasset, object new_idasset, object datacarico) {

            DataRow NewAssetPiece = DS.asset_detail.NewRow();
            NewAssetPiece["idasset"] = new_idasset;
            NewAssetPiece["idpiece"] = R["idpiece"];
            NewAssetPiece["idasset_prev"] = old_idasset;
            NewAssetPiece["idpiece_prev"] = R["idpiece"];
            NewAssetPiece["ct"] = DateTime.Now;
            ;
            NewAssetPiece["cu"] = "trasf_inventario";
            if (R["lifestart"] != DBNull.Value) {
                NewAssetPiece["lifestart"] = R["lifestart"];
            }
            else {
                NewAssetPiece["lifestart"] = datacarico;
            }
            NewAssetPiece["lt"] = DateTime.Now;
            NewAssetPiece["lu"] = "trasf_inventario";

            NewAssetPiece["nassetacquire"] = new_nassetacquire["nassetacquire"];
            NewAssetPiece["idinventory"] = new_nassetacquire["idinventory"];
            // attenzione al numero inventario
            NewAssetPiece["ninventory"] = DBNull.Value;
            NewAssetPiece["rtf"] = R["rtf"];
            NewAssetPiece["txt"] = R["txt"];
            NewAssetPiece["multifield"] = R["multifield"];
            NewAssetPiece["transmitted"] = "N";
            NewAssetPiece["idassetunload"] = DBNull.Value;
            NewAssetPiece["flag"] = (CfgFn.GetNoNullInt32(R["flag"]) & 0xFB);
            // Attenzione se devono essere migrati come già scaricati 
            // valorizzare opportunamente il flag
            DS.asset_detail.Rows.Add(NewAssetPiece);
            return NewAssetPiece;
        }

        /// <summary>
        /// Crea un nuovo carico cespite con caratteristiche analoghe a quello in input
        /// </summary>
        /// <param name="R"></param>
        /// <param name="cessionario"></param>
        /// <param name="idinventoryDest"></param>
        /// <param name="assetLoadMotive"></param>
        /// <param name="idassetload"></param>
        /// <param name="adateLoad"></param>
        /// <returns></returns>
        private DataRow CreateNewAssetAcquire(DataRow R,
            object cessionario, object idinventoryDest,
            object assetLoadMotive, object idassetload,
            object adateLoad, object newidupb) {
            DataRow NewAssetAcq = MAssetAcquire.Get_New_Row(null, DS.assetacquire);
            //DataRow R  Riga del cespite principale (assetview)
            //foreach (DataColumn C in NewAssetAcq.Table.Columns) {
            //if (C.ColumnName == "description" || C.ColumnName == "discount" ||
            //    C.ColumnName == "idinv" || C.ColumnName == "taxable"||
            //    C.ColumnName == "taxrate") {
            //    NewAssetAcq[C.ColumnName] = R[C.ColumnName];
            //}
            //Per chiarimenti vedi task 5460
            string SQLfilter = QHS.AppAnd(QHS.CmpEq("idasset", R["idasset"]), QHS.CmpEq("idpiece", R["idpiece"]));
            decimal currentvalue =
                CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetview_current", SQLfilter, "currentvalue"));
            NewAssetAcq["taxable"] = CfgFn.GetNoNullDecimal(currentvalue);
            decimal old_historicalvalue = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", 
                                          QHS.CmpEq("nassetacquire", R["nassetacquire"]), "historicalvalue"));
     
            decimal subtractions = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetview_current", SQLfilter,
                    "isnull(subtractions,0) "));
            decimal historicalvalue = 0;
            if (old_historicalvalue > 0) historicalvalue = old_historicalvalue - subtractions;
            else 
                historicalvalue =
                CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetview_current", SQLfilter,
                    "start-isnull(subtractions,0) "));
            NewAssetAcq["historicalvalue"] = CfgFn.GetNoNullDecimal(historicalvalue);
            NewAssetAcq["tax"] = 0;
            NewAssetAcq["description"] = R["description"];
            NewAssetAcq["idinv"] = R["idinv"];
            NewAssetAcq["idlist"] = R["idlist"];
            
            //NewAssetAcq["idinvkind"] = R["idinvkind"];
            //NewAssetAcq["yinv"] = R["yinv"];
            //NewAssetAcq["ninv"] = R["ninv"];
            //NewAssetAcq["invrownum"] = R["invrownum"];


            //decimal tax = CfgFn.GetNoNullDecimal(R["tax"]);   -->
            //decimal abatable = CfgFn.GetNoNullDecimal(R["abatable"]);   -->
            //decimal taxable = CfgFn.GetNoNullDecimal(R["taxable"]);   -->
            //int number = CfgFn.GetNoNullInt32(R["number"]);   -->
            //if (number == 0) number = 1;   -->

            int flag_assetacquire = 0;
            //bit 0= includi in buono carico
            //bit 1= cespite posseduto (0=nuovo)
            //bit 2= accessorio (0=cespite principale)
            if (CfgFn.GetNoNullInt32(R["idpiece"]) > 1) {
                // accessorio del cespite principale
                flag_assetacquire += 4;
            }
            //if (R["flagload"].ToString().ToUpper() == "S") {
            flag_assetacquire += 1; //includi in buono carico sempre
            //}

            // cespite posseduto deve diventare nuovo se sta in buono carico, invece gli accessori posseduti restano posseduti
            if ((R["loadkind"].ToString().ToUpper() == "R") && (CfgFn.GetNoNullInt32(R["idpiece"]) > 1)) {
                //accessorio posseduto
                // se stava in un buono di carico ce lo metto anche ora
                if (R["idassetload"] != DBNull.Value) {
                    //se lo metto in un buono diventa non più "posseduto" ma "nuovo"
                    NewAssetAcq["idassetload"] = idassetload;
                    flag_assetacquire += 2; //2011: lo rimetto come posseduto, non vedo perché non dovrebbe esserlo
                }
                else {
                    //altrimenti rimane come posseduto senza buono di carico
                    flag_assetacquire += 2;
                }
            }
            else {
                //cespite (posseduto o meno) oppure accessorio nuovo
                //---> deve essere inserito in un buono di carico e non è più "posseduto" ma nuovo.
                NewAssetAcq["idassetload"] = idassetload;
            }

            //NewAssetAcq["abatable"] = CfgFn.RoundValuta(abatable / number); -->
            NewAssetAcq["adate"] = adateLoad;
            NewAssetAcq["ct"] = DateTime.Now;
            NewAssetAcq["cu"] = "trasf_inventario";
            NewAssetAcq["idmot"] = assetLoadMotive;
            NewAssetAcq["idreg"] = cedente;
            NewAssetAcq["lt"] = DateTime.Now;
            NewAssetAcq["lu"] = "trasf_inventario";
            NewAssetAcq["number"] = 1;
            //NewAssetAcq["startnumber"] = TCarichi;
            //NewAssetAcq["tax"] = CfgFn.RoundValuta(tax / number); -->
            NewAssetAcq["transmitted"] = "N";
            //NewAssetAcq["idupb"] = ;
            NewAssetAcq["idinventory"] = idinventoryDest;
            NewAssetAcq["idmot"] = assetLoadMotive;
            NewAssetAcq["flag"] = flag_assetacquire;
            if ((newidupb != DBNull.Value) && (newidupb != null)) {
                NewAssetAcq["idupb"] = newidupb;
            }
            else {
                NewAssetAcq["idupb"] = R["idupb"];
            }
            //NewAssetAcq["idsor1"] = ;
            //NewAssetAcq["idsor2"] = ;
            //NewAssetAcq["idsor3"] = ;

            //return NewAssetAcq["nassetacquire"];
            return NewAssetAcq;

        }


        private void CreateNewAssetAmortization(DataRow R, object newIdAsset, object datacontabile) {
            // Crea in Assetamortization le nuove rivalutazioni/svalutazioni
            // nel nuovo inventario non con la data storica ma con la data odierna 
            DataRow NewAssetAmortization = MAssetAmortization.Get_New_Row(null, DS.assetamortization);

            foreach (string cname in new string[] {
                "description", "assetvalue",
                "amortizationquota", "txt", "rtf", "idinventoryamortization"
            }) {
                NewAssetAmortization[cname] = R[cname];
            }
            NewAssetAmortization["adate"] = datacontabile;
            NewAssetAmortization["ct"] = DateTime.Now;
            NewAssetAmortization["cu"] = "trasf_inventario";
            NewAssetAmortization["idasset"] = newIdAsset;
            NewAssetAmortization["idpiece"] = R["idpiece"];
            NewAssetAmortization["lt"] = DateTime.Now;
            NewAssetAmortization["lu"] = "trasf_inventario";
            NewAssetAmortization["transmitted"] = "N";
            NewAssetAmortization["idassetunload"] = DBNull.Value;
            // attenzione se scaricati deve essere flaggato come già scaricato, dipende dalla tabella
            int flag = CfgFn.GetNoNullInt32(R["flag"]);
            flag = flag & ~(0x01); //bit 0 = includi in buono carico
            NewAssetAmortization["flag"] = flag;


        }

        private DataRow CreateNewAssetLoad() {
            // Crea un nuovo buono di carico e assegna il buono ai nuovi assetacquire 
            MetaData MCar = MetaData.GetMetaData(this, "assetload");

            DataRow NewCar = MCar.Get_New_Row(null, DS.assetload);
            NewCar["yassetload"] = Meta.GetSys("esercizio");
            NewCar["idassetloadkind"] = assetLoadKind;
            NewCar["idmot"] = assetLoadMotive;
            NewCar["adate"] = _adateLoad;
            NewCar["description"] = descLoad;
            NewCar["doc"] = docLoad;
            NewCar["docdate"] = docDateLoad;
            NewCar["enactment"] = enactmentLoad;
            NewCar["enactmentdate"] = enactmentDateLoad;
            NewCar["idreg"] = cedente;
            NewCar["printdate"] = printDateLoad;
            NewCar["ratificationdate"] = ratificationDateLoad;
            return NewCar;
        }

        object idassetunload_origin;
        object idassetunload_dest;
        object idassetload;
        MetaData MAssetAcquire;
        MetaData MAsset;
        MetaData MAssetAmortization;
        MetaData MMan;
        MetaData MSubMan;
        MetaData MAssetLocation;

        private bool UpdateData(out int righe) {
            ClearTable();
            righe = 0;
            MaxNInventory = new Hashtable();
            DataRow new_nassetacquire;
            object old_idasset;
            object new_idasset;
            DataRow RAssetLoad;
            DataRow RAssetUnload;
            DataRow RAssetUnloadDest;
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridCespiti);
            // Se ho scelto di impostare a tutti lo upb 
            // creo le righe in assetmanager
            object newidupb = DBNull.Value;
            if (txtUPB.Text != "") {
                string filterUpb = QHS.AppAnd(QHS.CmpEq("codeupb", txtUPB.Text), QHS.NullOrEq("active", "S"));

                newidupb = Meta.Conn.DO_READ_VALUE("upb", filterUpb, "idupb");
                if (newidupb == null) newidupb = DBNull.Value;
            }

            if (RigheSelezionate.Length > 0) {
                MAssetAcquire = MetaData.GetMetaData(this, "assetacquire");
                MAssetAcquire.SetDefaults(DS.assetacquire);
                MAssetLocation = MetaData.GetMetaData(this, "assetlocation");
                MAssetLocation.SetDefaults(DS.assetlocation);
                MAsset = MetaData.GetMetaData(this, "asset");
                MAsset.SetDefaults(DS.asset);
                MMan = MetaData.GetMetaData(this, "assetmanager");
                MSubMan = MetaData.GetMetaData(this, "assetsubmanager");
                MAssetAmortization = MetaData.GetMetaData(this, "assetamortization");
                MAssetAmortization.SetDefaults(DS.assetamortization);
                object new_ninventory;
                // Creazione del buono di scarico
                RAssetUnload = CreateNewAssetUnload(true);
                RAssetUnloadDest = CreateNewAssetUnload(false);
                idassetunload_origin = RAssetUnload["idassetunload"];
                idassetunload_dest = RAssetUnloadDest["idassetunload"];
                // Creazione del buono di carico
                RAssetLoad = CreateNewAssetLoad();
                idassetload = RAssetLoad["idassetload"];

                object data_carico = RAssetLoad["adate"];


                foreach (DataRow R in RigheSelezionate) {
                    object idupb_to_set = newidupb;
                    if (idupb_to_set == DBNull.Value && R["idupb"] != DBNull.Value) idupb_to_set = R["idupb"];
                    //foreach (DataRow R in DS.assetview.Select()) {
                    old_idasset = R["idasset"];
                    // Scarico del cespite, valorizzo idassetunload
                    R["idassetunload"] = idassetunload_origin;
                    R["flag"] = (CfgFn.GetNoNullInt32(R["flag"]) & 0xFB);
                        //rimuove il check "pronto per il trasf.di inventario"
                    // Creazione de singolo carico cespite nel nuovo inventario
                    new_nassetacquire = CreateNewAssetAcquire(R, cessionario, idinventoryDest,
                        assetLoadMotive, idassetload, data_carico, newidupb);
                    // Creazione del singolo Cespite
                    new_idasset = CreateNewAsset(new_nassetacquire, R, data_carico, out new_ninventory);

                    new_nassetacquire["startnumber"] = new_ninventory;
                    // Elabora le entità dipendenti di ogni cespite: accessori, svalutazioni, rivalutazioni, ecc
                    /*
                        DataTable T1;  //1.Accessori nuova acquisizione non ancora scaricati
                        DataTable T2;  //2.Accessori posseduti scaricati
                        DataTable T3;  //3.Accessori posseduti non scaricati
                        DataTable T4;  //4.Rivalutazioni Cespiti
                        DataTable T5;  //5.Svalutazioni  Cespiti
                        DataTable T6;  //6.Rivalutazioni Accessori Nuova Acquisizione Non Ancora Scaricati 
                        DataTable T7;  //7.Rivalutazioni Accessori Posseduti e già Scaricati
                        DataTable T8;  //8.Svalutazioni  Accessori Nuova Acquisizione Non Ancora Scaricati  
                        DataTable T9;  //9.Svalutazioni  Accessori Posseduti e già Scaricati
                        DataTable T10; //10.Rivalutazioni Accessori Posseduti non ancora Scaricati 
                        DataTable T11; //11.Svalutazioni  Accessori Posseduti e non ancora Scaricati
                    */
                    TransfAssetPieceNuovi(old_idasset, new_idasset, new_ninventory, idassetunload_origin,
                        cessionario, idinventoryDest, assetLoadMotive, idassetload, data_carico, idupb_to_set);
                        // T1,T6,T8

                    TransfAssetPiecePossedutiScaricati(old_idasset, new_idasset, new_ninventory,
                        cessionario, idinventoryDest, assetLoadMotive,
                        idassetload, idassetunload_dest, data_carico, idupb_to_set); //T2,T7,T9

                    TransfAssetPiecePossedutiNonScaricati(old_idasset, new_idasset, new_ninventory,
                        cessionario, idinventoryDest, assetLoadMotive,
                        idassetload, idassetunload_origin, data_carico, idupb_to_set); //T3,T8,T10

                    //TransfAssetAmortization(old_idasset, new_idasset, idassetunload_origin, data_carico); //T4, T5

                    // Se ho scelto di impostare a tutti lo stesso responsabile 
                    // creo le righe in assetmanager
                    object newresp = DBNull.Value;
                    if (cmbResponsabile.SelectedIndex > 0) {
                        newresp = cmbResponsabile.SelectedValue;
                    }
                    else {
                        newresp = R["idcurrman"];
                        if (newresp == DBNull.Value) {
                            DataTable oldResp = Conn.RUN_SELECT("assetmanager", "*", "start desc",
                                QHS.CmpEq("idasset", R["idasset"]), null, false);
                            if (oldResp != null && oldResp.Rows.Count > 0) newresp = oldResp.Rows[0]["idman"];
                        }
                    }

                    object newsubresp = DBNull.Value;
                    if (cmbConsegnatario.SelectedIndex > 0) {
                        newsubresp = cmbConsegnatario.SelectedValue;
                    }
                    else {
                        newsubresp = R["idcurrsubman"];
                        if (newsubresp == DBNull.Value) {
                            DataTable oldSubResp = Conn.RUN_SELECT("assetsubmanager", "*", "start desc",
                                QHS.CmpEq("idasset", R["idasset"]), null, false);
                            if (oldSubResp != null && oldSubResp.Rows.Count > 0) newsubresp = oldSubResp.Rows[0]["idmanager"];
                        }
                    }

                    object DT = data_carico; // non so  se va bene come valorizzazione

                    if (newresp != DBNull.Value) {
                        MetaData.SetDefault(DS.assetmanager, "idasset", new_idasset);
                        MetaData.SetDefault(DS.assetmanager, "start", DT);
                        DataRow NewMan = MMan.Get_New_Row(null, DS.assetmanager);
                        NewMan["idman"] = newresp;
                    }

                    if (newsubresp != DBNull.Value) {
                        MetaData.SetDefault(DS.assetsubmanager, "idasset", new_idasset);
                        MetaData.SetDefault(DS.assetsubmanager, "start", DT);
                        DataRow NewSubMan = MSubMan.Get_New_Row(null, DS.assetsubmanager);
                        NewSubMan["idmanager"] = newsubresp;
                    }

                    object idlocation = R["idcurrlocation"];
                    if (idlocation == DBNull.Value) {
                        DataTable oldLocation = Conn.RUN_SELECT("assetlocation", "*", "start desc",
                            QHS.CmpEq("idasset", R["idasset"]), null, false);
                        if (oldLocation != null && oldLocation.Rows.Count > 0) idlocation = oldLocation.Rows[0]["idlocation"];
                    }

                    if (idlocation != DBNull.Value) {
                        MetaData.SetDefault(DS.assetlocation, "idasset", new_idasset);
                        DataRow NewLocation = MAssetLocation.Get_New_Row(null, DS.assetlocation);
                        NewLocation["idlocation"] = idlocation;
                        NewLocation["start"] = DT;
                    }
                    righe++;
                }
                if (DS.assetview_piece.Select(QHC.CmpEq("idassetunload", idassetunload_dest)).Length == 0) {
                    RAssetUnloadDest.Delete();
                }

                PostData pd = Meta.Get_PostData();
                pd.InitClass(DS, Meta.Conn);
                return pd.DO_POST();
            }
            else {
                show("Non ci sono cespiti da elaborare", "Attenzione");
            }
            return true;
        }

        private void TransfAssetPieceNuovi(object old_idasset,
            object new_idasset, object new_ninventory,
            object idassetunload_origin, //object idassetunload_dest,
            object cessionario, object idinventoryDest, object assetLoadMotive,
            object idassetload, object datacarico, object newidupb) {
            //T1,T6,T8
            //Scarico e carico contestuale degli accessori di nuova acquisizione
            //del cespite principale elaborato
            DataRow[] AssetPiece = T1.Select(QHC.CmpEq("idasset", old_idasset));

            foreach (DataRow R in AssetPiece) {
                DataRow NewR = DS.assetview_piece.NewRow();
                foreach (DataColumn C in R.Table.Columns) {
                    if (!DS.assetview_piece.Columns.Contains(C.ColumnName)) continue;
                    NewR[C.ColumnName] = R[C.ColumnName];
                }
                DS.assetview_piece.Rows.Add(NewR);
                NewR.AcceptChanges();
                NewR["idassetunload"] = idassetunload_origin;
                //NewR["idassetunload"] = idassetunload_dest;
                DataRow assetAcquire = CreateNewAssetAcquire(NewR,
                    cessionario, idinventoryDest, assetLoadMotive, idassetload, datacarico, newidupb);
                assetAcquire["startnumber"] = new_ninventory;
                CreateNewAssetPiece(R, assetAcquire, old_idasset, new_idasset, datacarico);
                //DataRow[] AssetRival = T6.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R1 in AssetRival) {
                //    CreateNewAssetAmortization(R1, new_idasset, datacarico); //gli ammortamenti sono copiati come "già scaricati"
                //}
                //DataRow[] AssetSval  = T8.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R2 in AssetSval) {
                //    CreateNewAssetAmortization(R2, new_idasset,datacarico);
                //}
            }

        }

        private void TransfAssetPiecePossedutiScaricati(object old_idasset,
            object new_idasset, object new_ninventory,
            object cessionario, object idinventoryDest, object assetLoadMotive,
            object idassetload,
            object idassetunload_dest,
            object datacarico, object newidupb) {
            //T2,T7,T9
            DataRow[] AssetPiece = T2.Select(QHC.CmpEq("idasset", old_idasset));
            foreach (DataRow R in AssetPiece) {
                DataRow NewR = DS.assetview_piece.NewRow();
                foreach (DataColumn C in R.Table.Columns) {
                    NewR[C.ColumnName] = R[C.ColumnName];
                }
                DS.assetview_piece.Rows.Add(NewR);
                NewR.AcceptChanges();
                //NewR["idassetunload"] = idassetunload_origin; //scarica il vecchio accessorio NO è già scaricato!

                DataRow assetAcquire = CreateNewAssetAcquire(NewR,
                    cessionario, idinventoryDest, assetLoadMotive, idassetload, datacarico, newidupb);
                assetAcquire["startnumber"] = new_ninventory;
                DataRow nuovoAccessorio = CreateNewAssetPiece(R, assetAcquire, old_idasset, new_idasset, datacarico);
                nuovoAccessorio["idassetunload"] = idassetunload_dest;

                //DataRow[] AssetRival = T7.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R1 in AssetRival) {
                //    CreateNewAssetAmortization(R1, new_idasset, datacarico);
                //}
                //DataRow[] AssetSval = T9.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R2 in AssetSval) {
                //    CreateNewAssetAmortization(R2, new_idasset, datacarico);
                //}
            }
        }

        private void TransfAssetPiecePossedutiNonScaricati(object old_idasset,
            object new_idasset, object new_ninventory,
            object cessionario, object idinventoryDest, object assetLoadMotive,
            object idassetload, object idassetunload_origin, object datacarico, object newidupb) {
            //T3,T8,T10

            DataRow[] AssetPiece = T3.Select(QHC.CmpEq("idasset", old_idasset));
            foreach (DataRow R in AssetPiece) {
                DataRow NewR = DS.assetview_piece.NewRow();
                foreach (DataColumn C in R.Table.Columns) {
                    if (!DS.assetview_piece.Columns.Contains(C.ColumnName)) continue;
                    NewR[C.ColumnName] = R[C.ColumnName];
                }
                DS.assetview_piece.Rows.Add(NewR);
                NewR.AcceptChanges();
                NewR["idassetunload"] = idassetunload_origin;
                DataRow assetAcquire = CreateNewAssetAcquire(NewR,
                    cessionario, idinventoryDest, assetLoadMotive, idassetload, datacarico, newidupb);
                assetAcquire["startnumber"] = new_ninventory;
                CreateNewAssetPiece(R, assetAcquire, old_idasset, new_idasset, datacarico);
                //DataRow[] AssetRival = T8.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R1 in AssetRival) {
                //    CreateNewAssetAmortization(R1, new_idasset, datacarico);
                //}
                //DataRow[] AssetSval = T10.Select(QHC.CmpEq("idasset", old_idasset));
                //foreach (DataRow R2 in AssetSval) {
                //    CreateNewAssetAmortization(R2, new_idasset, datacarico);
                //}
            }
        }

        private void TransfAssetAmortization(object old_idasset, object new_idasset, object idassetunload,
            object datacontabile) {
            //T4, T5
            DataRow[] AssetRival = T4.Select(QHC.CmpEq("idasset", old_idasset));
            foreach (DataRow R1 in AssetRival) {
                CreateNewAssetAmortization(R1, new_idasset, datacontabile);
            }
            DataRow[] AssetSval = T5.Select(QHC.CmpEq("idasset", old_idasset));
            foreach (DataRow R2 in AssetSval) {
                CreateNewAssetAmortization(R2, new_idasset, datacontabile);
            }
        }

        // private void SaveData();

        bool AggiornaGrid() {
            DS.assetview.Clear();
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetview, " codeinventory,ninventory", Filtro, null, //TASK 10546, tolto il manager dall'order by
                false);
            HelpForm.SetDataGrid(gridCespiti, DS.assetview);
            gridCespiti.TableStyles.Clear();
            HelpForm.SetGridStyle(gridCespiti, DS.assetview);
            formatgrids format = new formatgrids(gridCespiti);
            format.AutosizeColumnWidth();
            HelpForm.SetAllowMultiSelection(DS.assetview, true);
            SelezionaTuttiICespiti();
            GetEntitaDipendenti(); // Legge in memoria accessori, rivalutazioni, svalutazioni ecc.
            return true;
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }

        private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
            ComboBox acComboBox = (ComboBox) sender;
            int selectionStart = acComboBox.SelectionStart;

            switch (e.KeyCode) {
                //Se è stato premuta la freccia "SINISTRA" faccio cominciare la selezione
                //un carattere prima rispetto alla selezione attuale
                case Keys.Left:
                    if (selectionStart > 0) {
                        acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                    }
                    else {
                        acComboBox.SelectAll();
                    }
                    break;

                //Se è stato premuto il tasto "CANC" seleziono la riga vuota del combobox
                case Keys.Delete:
                    int index = acComboBox.FindString("");
                    if (index != -1) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                        acComboBox.DroppedDown = true;
                    }
                    acComboBox.SelectAll();
                    break;

                //Se è stato premuta la freccia "DESTRA" faccio cominciare la selezione
                //un carattere dopo rispetto alla selezione attuale
                case Keys.Right:
                    if (acComboBox.Text.Length > selectionStart) {
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                    break;

                //Se è stato premuto il tasto "HOME" seleziono tutta la riga attuale.
                case Keys.Home:
                    acComboBox.SelectAll();
                    break;

                default:
                    //Altrimenti lascio la gestione di questo evento a .NET
                    return;
            }
            e.Handled = true;
        }

        private void cmb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            //Se è stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
            if ((e.KeyChar == 27) || (e.KeyChar == 13)) {
                return;
            }

            ComboBox acComboBox = (ComboBox) sender;

            int selectionStart = acComboBox.SelectionStart;
            if (selectionStart > acComboBox.Text.Length) selectionStart = acComboBox.Text.Length;

            //Se il tasto premuto è BACKSPACE, faccio cominciare la selezione un carattere prima
            //dell'inizio della selezione corrente
            if (e.KeyChar == 8) {
                if (selectionStart > 0) {
                    acComboBox.Select(selectionStart - 1, acComboBox.Text.Length - (selectionStart - 1));
                }
                else {
                    acComboBox.SelectAll();
                }
            }
            else {
                //Se è un qualunque altro carattere (quindi tale che IsInputKey()=true
                //e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

                //Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
                //della riga corrente concatenati col tasto premuto
                string ricerca = acComboBox.Text.Substring(0, selectionStart) + e.KeyChar;

                int index = acComboBox.FindString(ricerca);

                if (index != -1) {
                    //Se tale riga esiste, allora la seleziono
                    if (acComboBox.SelectedIndex != index) {
                        acComboBox.DroppedDown = false;
                        acComboBox.SelectedIndex = index;
                    }
                    acComboBox.DroppedDown = true;
                    if (selectionStart < acComboBox.Text.Length) {
                        //e faccio cominciare la selezione da selectionstart + 1
                        acComboBox.Select(selectionStart + 1, acComboBox.Text.Length - (selectionStart + 1));
                    }
                }
                else {
                    //Se invece tale riga non esiste, allora seleziono la riga attuale
                    //dal carattere in posizione selectionStart fino alla fine
                    acComboBox.DroppedDown = true;
                    acComboBox.Select(selectionStart, acComboBox.Text.Length - selectionStart);
                }
            }
            //Forzo l'apertura della tendina per facilitare l'utente nella scelta
            e.Handled = true;
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            //filter="idasset='"+G[index,0].ToString()+"' and idpiece = '" +G[index,1].ToString()+"'";
            filter = QHS.AppAnd(QHS.CmpEq("idasset", G[index, 0]), QHS.CmpEq("idpiece", G[index, 1]));
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }

        private bool AggiornaDati() {
            if (GetInfoCarico()) {
                string msg =
                    "Si desidera proseguire? Tutti i cespiti selezionati saranno scaricati con i relativi accessori e caricati nel nuovo inventario";
                if (show(msg, "Attenzione",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;

                int righe;
                if (UpdateData(out righe)) {
                    if (righe > 0)
                        lblFase4.Text = "Elaborazione terminata con successo. " +
                                        "Numero cespiti elaborati: " + righe.ToString();
                    else
                        lblFase4.Text = "Nessun cespite trovato in base al criterio di ricerca effettuato.";
                }
                else {
                    lblFase4.Text = "Sono stati riscontrati errori. " +
                                    "Non è stato possibile effettuare il trasferimento dei cespiti";
                }

                return true;
            }
            else return false;
        }

        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                DialogResult = DialogResult.OK;
                return;
            }
            DisplayTabs(newTab);
        }

        private void ClearTable() {
            DS.asset.Clear();
            DS.asset_detail.Clear();
            DS.assetacquire.Clear();
            DS.assetmanager.Clear();
            DS.assetsubmanager.Clear();
            DS.assetamortization.Clear();
            DS.assetload.Clear();
            DS.assetunload.Clear();
        }

        /// <summary>
        /// Restituisce false se non è stato applicato alcun filtro
        /// </summary>
        /// <returns></returns>
        private bool GetFiltroScarico() {
            Filtro = "";
            idinventoryOrig = DBNull.Value;
            int N5 = 0;
            int N6 = 0;
            string numinv_da = txt_numinv_da.Text.Trim();
            string numinv_a = txt_numinv_a.Text.Trim();
            if ((numinv_da != "") && (isNumeric(numinv_da, out N5))) {
                N5 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), numinv_da, "x.y"));
                if (N5 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpGe("ninventory", N5));
                }
            }
            if ((numinv_a != "") && (isNumeric(numinv_a, out N6))) {
                N6 = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), numinv_a, "x.y"));
                if (N6 > 0) {
                    Filtro = QHS.AppAnd(Filtro, QHS.CmpLe("ninventory", N6));
                }
            }

            if (cmbInventarioOrig.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idinventory", cmbInventarioOrig.SelectedValue));
                idinventoryOrig = CfgFn.GetNoNullInt32(cmbInventarioOrig.SelectedValue);
            }
            else {
                ShowMsg("Selezionare il Tipo Inventario");
                return false;
            }

            if (cboResp.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrman", cboResp.SelectedValue));
            }
            if (cboConsegnatario.SelectedIndex > 0) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idcurrsubman", cboConsegnatario.SelectedValue));
            }
            Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idpiece", 1)); // Cespite
            if (chkReady.Checked) {
                Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("flagtransf", 'S')); // pronti per il trasferimento
            }
            Filtro = QHS.AppAnd(Filtro, QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagload", "N"),
                QHS.IsNotNull("idassetload")))); // Attualmente in carico
            Filtro = QHS.AppAnd(Filtro, QHS.AppAnd(QHS.CmpNe("flagunload", "N"),
                QHS.IsNull("idassetunload")));

            return true;
        }

        private bool GetInfoBuonoScarico() {
            assetUnloadKind = DBNull.Value;
            descUnload = "";
            assetUnloadMotive = DBNull.Value;
            docUnload = "";
            docDateUnload = DBNull.Value;
            enactmentUnload = DBNull.Value;
            enactmentDateUnload = DBNull.Value;
            printDateUnload = DBNull.Value;
            _adateUnload = DBNull.Value;
            ratificationDateUnLoad = DBNull.Value;
            // lettura delle informazioni relative alla creazione del buono di scarico (tipo, descrizione, provvedimento, ecc..)
            // sarà creato un solo buono di scarico
            //if (cmbTipoBuonoScarico.SelectedIndex > 0) {
            if (cmbTipoBuonoScarico.SelectedValue != null) {
                assetUnloadKind = CfgFn.GetNoNullInt32(cmbTipoBuonoScarico.SelectedValue);
                string filtersql = QHS.CmpEq("idassetunloadkind", assetUnloadKind);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetunloadkind, null, filtersql, null, true);

            }
            else {
                show("Selezionare il Tipo Buono di Scarico");
                return false;
            }

            if (txtDescrBuonoScarico.Text != "")
                descUnload = txtDescrBuonoScarico.Text;
            else {
                ShowMsg("Selezionare la descrizione del Buono di Scarico");
                return false;
            }

            if (txtCessionario.Text != "") {
                string filteridreg = QHS.AppAnd(QHS.CmpEq("title", txtCessionario.Text), QHS.CmpEq("active", "S"));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry_assetunload, null, filteridreg, null, true);
                cessionario = DS.registry_assetunload.Rows[0]["idreg"];
            }
            else {
                ShowMsg("Selezionare il Cessionario");
                return false;
            }

            if ((cboCausaleScarico.SelectedIndex > 0)) {
                assetUnloadMotive = CfgFn.GetNoNullInt32(cboCausaleScarico.SelectedValue);
            }
            else {
                ShowMsg("Selezionare la Causale di Scarico");
                assetUnloadMotive = DBNull.Value;
                return false;
            }

            if (txtDocScarico.Text != "") {
                docUnload = txtDocScarico.Text;
            }

            if (txtDataDocScarico.Text != "") {
                docDateUnload = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataDocScarico.Text.ToString(), "x.y");
            }

            if (txtProvvScarico.Text != "") {
                enactmentUnload = txtProvvScarico.Text;
            }

            if (txtDataProvvScarico.Text != "") {
                enactmentDateUnload = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataProvvScarico.Text.ToString(), "x.y");
            }

            if (txtDataStampaScarico.Text != "") {
                printDateUnload = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataStampaScarico.Text.ToString(), "x.y");
            }

            if (txtDataContScarico.Text != "") {
                _adateUnload = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataContScarico.Text.ToString(), "x.y");
            }

            if (
                txtDataRatificaScarico.Text != "") {
                ratificationDateUnLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataRatificaScarico.Text.ToString(), "x.y");
            }


            return true;
        }

        private bool GetFiltroCarico() {
            idinventoryDest = DBNull.Value;
            newresp = DBNull.Value;
            newsubresp = DBNull.Value;
            if (cmbInventarioDest.SelectedIndex <= 0) {
                //Filtro = QHS.AppAnd(Filtro, QHS.CmpEq("idinventory", cmbInventarioDest.SelectedValue));
                ShowMsg("Selezionare il Tipo Inventario di destinazione");
                return false;
            }
            else {
                idinventoryDest = CfgFn.GetNoNullInt32(cmbInventarioDest.SelectedValue);

            }
            stessoNinventory = chkpreservaInventario.Checked;

            
            if (txtUPB.Text.Trim() == "" && chkUpbInvariato.Checked == false) {
                ShowMsg("Selezionare l'UPB o stabilire di lasciarlo invariato.");
                return false;
            }

            if (cmbResponsabile.SelectedIndex <= 0 && chkRespInvariato.Checked == false) {
                ShowMsg("Selezionare il responsabile o stabilire di lasciarlo invariato.");
                return false;
            }
            if (cmbConsegnatario.SelectedIndex <= 0 && chkSubRespInvariato.Checked == false) {
                ShowMsg("Selezionare il subconsegnatario o stabilire di lasciarlo invariato.");
                return false;
            }


            if (cmbResponsabile.SelectedIndex > 0) {
                newresp = CfgFn.GetNoNullInt32(cmbResponsabile.SelectedValue);
            }
            if (cmbConsegnatario.SelectedIndex > 0) {
                newsubresp = CfgFn.GetNoNullInt32(cmbConsegnatario.SelectedValue);
            }

            //if (txtUPB.Text == "") {
            //    ShowMsg("Selezionare UPB Destinazione");
            //    return false;
            //}

            return true; //maria
        }

        private bool GetInfoCarico() {
            assetLoadKind = DBNull.Value;
            descLoad = "";
            assetLoadMotive = DBNull.Value;
            docLoad = "";
            docDateLoad = DBNull.Value;
            enactmentLoad = "";
            enactmentDateLoad = DBNull.Value;
            printDateLoad = DBNull.Value;
            _adateLoad = DBNull.Value;
            // lettura delle informazioni relative alla creazione del buono di carico (tipo, descrizione, provvedimento, ecc..)
            // sarà creato un solo buono di ccarico
            //if (cmbTipoBuonoCarico.SelectedIndex > 0) {
            if (cmbTipoBuonoCarico.SelectedValue != null) {
                assetLoadKind = CfgFn.GetNoNullInt32(cmbTipoBuonoCarico.SelectedValue);
                string filtersql = QHS.CmpEq("idassetloadkind", assetLoadKind);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetloadkind, null, filtersql, null, true);

            }
            else {
                ShowMsg("Selezionare il Tipo Buono di Carico");
                return false;
            }


            if (txtDescrBuonoCarico.Text != "")
                descLoad = txtDescrBuonoCarico.Text;
            else {
                ShowMsg("Selezionare la descrizione del Buono di Carico");
                return false;
            }

            if (txtCedente.Text != "") {
                string filteridreg = QHS.AppAnd(QHS.CmpEq("title", txtCedente.Text), QHS.CmpEq("active", "S"));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry_assetload, null, filteridreg, null, true);
                cedente = DS.registry_assetload.Rows[0]["idreg"];
            }
            else {
                ShowMsg("Selezionare il Cedente");
                return false;
            }

            if (cmbCausaleCarico.SelectedIndex > 0) {
                assetLoadMotive = CfgFn.GetNoNullInt32(cmbCausaleCarico.SelectedValue);
            }
            else {
                ShowMsg("Selezionare la Causale di Carico");
                assetLoadMotive = DBNull.Value;
                return false;
            }

            if (txtDocCarico.Text != "") {
                docLoad = txtDocCarico.Text;
            }

            if (txtDataDocCarico.Text != "") {
                docDateLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataDocCarico.Text.ToString(), "x.y");
            }

            if (txtProvvCarico.Text != "") {
                enactmentLoad = txtProvvCarico.Text;
            }

            if (txtDataProvvCarico.Text != "") {
                enactmentDateLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataProvvCarico.Text.ToString(), "x.y");
            }

            if (txtDataStampaCarico.Text != "") {
                printDateLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataStampaCarico.Text.ToString(), "x.y");
            }

            if (txtDataContCarico.Text != "") {
                _adateLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataContCarico.Text.ToString(), "x.y");
            }

            if (txtDataRatificaCarico.Text != "") {
                ratificationDateLoad = HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataRatificaCarico.Text.ToString(), "x.y");
            }
            return true;
        }


        public void DatiValidi(object sender, System.EventArgs e) {
            TextBox T = (TextBox) sender;
            if ((T.Text == null) || (T.Text == "")) return;
            HelpForm.ExtLeaveDateTimeTextBox(T, null);
            try {
                DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
                    T.Text.ToString(), "x.y");
                return;
            }
            catch {
                ShowMsg("E' necessario inserire una data valida");
                T.Focus();
                return;
            }
        }

        private bool isNumeric(string str, out int valore) {
            valore = 0;
            try {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch {
                return false;
            }
        }

        Hashtable MaxNInventory = new Hashtable();

        private int GetNextNInventory(object codiceinventario) {
            if (MaxNInventory[codiceinventario.ToString()] != null) {
                int OldMax = CfgFn.GetNoNullInt32(MaxNInventory[codiceinventario.ToString()]);
                int NewMax = OldMax + 1;
                MaxNInventory[codiceinventario.ToString()] = NewMax;
                return NewMax;
            }
            if ((codiceinventario == DBNull.Value) || (CfgFn.GetNoNullInt32(codiceinventario) == 0)) return 0;
            string sql_numiniziale = "SELECT ISNULL(startnumber,0) FROM inventory WHERE " +
                                     QHS.CmpEq("idinventory", codiceinventario);
            DataTable t = Meta.Conn.SQLRunner(sql_numiniziale, true, 0);
            int numiniziale = 0;
            if (t != null) numiniziale = CfgFn.GetNoNullInt32(t.Rows[0][0]);

            string sqlmax = "SELECT ISNULL(MAX(ninventory)," + numiniziale.ToString() + ")  FROM assetview WHERE "
                            +
                            QHS.AppAnd(QHS.CmpEq("idinventory", codiceinventario), QHS.CmpGt("ninventory", numiniziale));

            t = Meta.Conn.SQLRunner(sqlmax, true, 0);
            int MAX = CfgFn.GetNoNullInt32(t.Rows[0][0]);
            MaxNInventory[codiceinventario.ToString()] = MAX;
            return MAX;
        }

        private void ShowMsg(string msg) {
            show(this,msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void cboResp_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (cmbResponsabile.SelectedIndex <= 0) {
                CodiceResponsabile = "";
                Responsabile = "";
                return;
            }

            try {
                DataRow R = ((DataRowView) cmbResponsabile.SelectedItem).Row;
                CodiceResponsabile = R["idman"].ToString();
                Responsabile = R["title"].ToString();
                chkRespInvariato.Checked = false;
            }
            catch {
                CodiceResponsabile = "";
                Responsabile = "";
            }
        }

        private void LeaveInt(object sender, System.EventArgs e) {
            HelpForm.LeaveIntTextBox(sender, e);
        }

        private void SelezionaTuttiICespiti() {
            object dataSource = gridCespiti.DataSource;
            if (dataSource == null) return;

            CurrencyManager cm = (CurrencyManager)
                gridCespiti.BindingContext[dataSource, gridCespiti.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    gridCespiti.Select(i);
                }
            }
        }

        private void btnSelezionaTutto_Click(object sender, System.EventArgs e) {
            //SelezionaTuttiICespiti();
        }

        private void txtData_Leave(object sender, System.EventArgs e) {
            DatiValidi(sender, e);
        }

        private void cmbInventarioOrig_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbInventarioOrig.SelectedIndex > 0) {
                object idinventory = cmbInventarioOrig.SelectedValue;
                object idinventoryagency = Meta.Conn.DO_READ_VALUE("inventory", QHS.CmpEq("idinventory", idinventory),
                    "idinventoryagency");
                string title =
                    Meta.Conn.DO_READ_VALUE("inventoryagency", QHS.CmpEq("idinventoryagency", idinventoryagency),
                        "description").ToString();

                txtEnteScarico.Text = title;
                DS.assetunloadkind.Clear();

                int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", QHS.CmpEq("idinventory", idinventory), "flag"));
                // Nei buoni di carico non filtrare l'inventario
                bool flagMixed = ((flag & 1) != 0);

                if (flagMixed) {
                    // Se il flag vale S, non devo filtrare i tipi dei buoni di scarico sull'inventario ma solo sull'ente Inventariale
                    string filterEnte = QHS.CmpEq("idinventoryagency", idinventoryagency);

                    DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);

                    if (ListInvEnte.Rows.Count > 0) {
                        if (ListInvEnte.Rows.Count != 0) {
                            string filterAllInvEnte = QHS.FieldIn("idinventory", ListInvEnte.Select());
                            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetunloadkind, null, filterAllInvEnte,
                             null, false);
                        }
                    }
                }
                else {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetunloadkind, null, QHC.CmpEq("idinventory", idinventory),
                    null, false);
                }

                if (DS.assetunloadkind.Rows.Count > 0) {
                    HelpForm.SetComboBoxValue(cmbTipoBuonoScarico, DS.assetunloadkind.Rows[0]["idassetunloadkind"]);
                }
            }
            else {
                txtEnteScarico.Text = "";
            }
        }

        private void cmbInventarioDest_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbInventarioDest.SelectedIndex > 0) {
                object idinventory = cmbInventarioDest.SelectedValue;
                object idinventoryagency = Meta.Conn.DO_READ_VALUE("inventory", QHS.CmpEq("idinventory", idinventory),
                    "idinventoryagency");
                string title =
                    Meta.Conn.DO_READ_VALUE("inventoryagency", QHS.CmpEq("idinventoryagency", idinventoryagency),
                        "description").ToString();

                txtEnteCarico.Text = title;
                DS.assetloadkind.Clear();
                int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("inventory", QHS.CmpEq("idinventory", idinventory), "flag"));
                bool flagMixed = ((flag & 2) != 0);

                if (flagMixed) {
                    // Se il flag vale S, non devo filtrare i tipi dei buoni di scarico sull'inventario ma solo sull'ente Inventariale
                    string filterEnte = QHS.CmpEq("idinventoryagency", idinventoryagency);
                    DataTable ListInvEnte = Meta.Conn.RUN_SELECT("inventory", "*", null, filterEnte, null, false);

                    if (ListInvEnte.Rows.Count > 0) {
                        if (ListInvEnte.Rows.Count != 0) {
                            string filterAllInvEnte = QHS.FieldIn("idinventory", ListInvEnte.Select());
                            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetloadkind, null, filterAllInvEnte,
                             null, false);
                        }
                    }
                }
                else {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.assetloadkind, null, QHC.CmpEq("idinventory", idinventory),
                    null, false);
                }
                if (DS.assetloadkind.Rows.Count > 0) {
                    HelpForm.SetComboBoxValue(cmbTipoBuonoCarico, DS.assetloadkind.Rows[0]["idassetloadkind"]);
                }
            }
            else {
                txtEnteCarico.Text = "";
            }

        }

        private void btnSelezionaTutto_Click_1(object sender, EventArgs e) {
            SelezionaTuttiICespiti();
        }

        private void cmbConsegnatario_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbConsegnatario.SelectedIndex <= 0) {
                CodiceConsegnatario = "";
                Consegnatario = "";
                return;
            }
            try {
                DataRow R = ((DataRowView) cmbConsegnatario.SelectedItem).Row;
                CodiceConsegnatario = R["idman"].ToString();
                Consegnatario = R["title"].ToString();
                chkSubRespInvariato.Checked = false;
            }
            catch {
                CodiceConsegnatario = "";
                Consegnatario = "";
            }
        }

        private void tabController_SelectionChanged(object sender, EventArgs e) {

        }

        private void chkRespInvariato_CheckedChanged(object sender, EventArgs e) {
            if (chkRespInvariato.Checked) {
                cmbResponsabile.SelectedIndex = 0;
            }
        }

        private void chkSubRespInvariato_CheckedChanged(object sender, EventArgs e) {
            if (chkSubRespInvariato.Checked) {
                cmbConsegnatario.SelectedIndex = 0;
            }
        }

        private void chkUpbInvariato_CheckedChanged(object sender, EventArgs e) {
            if (chkUpbInvariato.Checked) {
                txtUPB.Text = "";
                txtDescrUPB.Text = "";
            }
        }
    }
}
