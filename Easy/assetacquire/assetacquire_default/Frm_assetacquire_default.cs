/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using funzioni_configurazione;//funzioni_configurazione
using System.Data;
using q = metadatalibrary.MetaExpression;

namespace assetacquire_default { //caricobeneinventario//

    /// <summary>
    /// Summary description for frmcaricobeneinventario.
    /// </summary>
    public class Frm_assetacquire_default : System.Windows.Forms.Form {
        private System.Windows.Forms.TabControl tabCaricoBeni;
        private System.Windows.Forms.TabPage tabPageOperazioni;
        private System.Windows.Forms.TabPage tabPageInventario;
        private System.Windows.Forms.TabPage tabPageUtilizzo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpTipoCarico;
        private System.Windows.Forms.RadioButton radioNuovo;
        private System.Windows.Forms.RadioButton radioPosseduto;
        private System.Windows.Forms.TextBox txtNumCaricoBene;
        private System.Windows.Forms.GroupBox grpRiga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox txtEserBuono;
        private System.Windows.Forms.TextBox txtNumBuono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.CheckBox chkIncludi;
        private System.Windows.Forms.GroupBox grpValore;
        private System.Windows.Forms.GroupBox grpInventario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.ComboBox cboInventario;
        private System.Windows.Forms.TextBox txtNumIniz;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnEliminaQuota;
        private System.Windows.Forms.Button btnModificaQuota;
        private System.Windows.Forms.Button btnInserisciQuota;
        private System.Windows.Forms.DataGrid gridQuota;
        private System.Windows.Forms.GroupBox grpCredDeb;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox txtDescClassif;
        private System.Windows.Forms.TextBox txtIdClassif;
        private System.Windows.Forms.Button btnClassif;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboCausale;
        private System.Windows.Forms.GroupBox grpClassif;
        private System.Windows.Forms.TextBox txtImposta;
        private System.Windows.Forms.TextBox txtSconto;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.TextBox txtImpostaTotale;
        private System.Windows.Forms.TextBox txtImpTotale;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.Button btnModificaBene;
        private System.Windows.Forms.Button btnCopiaBene;
        private System.Windows.Forms.DataGrid gridBene;
        private System.Windows.Forms.GroupBox grpBuonoInv;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.Button btnCollegaRiga;
        public dsmeta DS;
        private object m_LastCodiceInventario = DBNull.Value;
        private string m_LastNumIniz = "";
        private object m_LastTipoCP = DBNull.Value;
        private MetaData Meta;
        private System.Windows.Forms.TextBox txtNumriga;
        private System.Windows.Forms.TextBox txtNumordine;
        private System.Windows.Forms.TextBox txtEsercordine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImpConIVA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCodiceBuono;
        private System.Windows.Forms.GroupBox gboxCespiti;
        private System.Windows.Forms.CheckBox chkIspieceAcquire;
        private bool InChiusura;
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAbatable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSuggerimento;
        private CheckBox chkTransmitted;
        private System.Windows.Forms.TabPage tabPageEP;
        private GroupBox grpAnalitico;
        private Button btnbuonocarico;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        public GroupBox gboxclass3;
        public Button btnCodice3;
        public TextBox txtDenom3;
        public TextBox txtCodice3;
        public GroupBox gboxclass2;
        public Button btnCodice2;
        public TextBox txtDenom2;
        public TextBox txtCodice2;
        public GroupBox gboxclass1;
        public Button btnCodice1;
        public TextBox txtDenom1;
        public TextBox txtCodice1;
        private Label label16;
        private TextBox textBox3;
        private GroupBox groupBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private GroupBox gboxListino;
        private CheckBox chkListDescription;
        private Button btnListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private GroupBox grpRigaFattura;
        private ComboBox cmbTipoFattura;
        private Button btnCollegaRigaFattura;
        private TextBox txtNumRigaFattura;
        private TextBox txtNumFattura;
        private TextBox txtEsercFattura;
        private Label label17;
		private Label label18;
		private TextBox txtRatificationDate;
		private System.Windows.Forms.Button btnNumInventario;
        //private string TagDetail="assetpiece.dettaglio";
        public Frm_assetacquire_default() {
            InitializeComponent();
            
            InChiusura = false;

            //vista per grid BeneInventariabile
            DataTable BeneInv = DS.asset;
            DataTable BeneInvView = DS.assetview;
            DataTable Respons = DS.manager;
            DataTable Ubicaz = DS.location;
            DataTable Inventario = DS.inventory;
            DataTable ClassInvView = DS.inventorytreeview;
            DataTable CaricoBeneInv = DS.assetacquire;

            BeneInv.ExtendedProperties["ViewTable"] = BeneInvView;
            Inventario.ExtendedProperties["ViewTable"] = BeneInvView;
            ClassInvView.ExtendedProperties["ViewTable"] = BeneInvView;
            CaricoBeneInv.ExtendedProperties["ViewTable"] = BeneInvView;
            BeneInvView.ExtendedProperties["RealTable"] = BeneInv;

            //			BeneInvView.Columns[""].ExtendedProperties["ViewSource"]="beneinventariabile";

            BeneInvView.Columns["idasset"].ExtendedProperties["ViewSource"] = "asset.idasset";
            BeneInvView.Columns["idpiece"].ExtendedProperties["ViewSource"] = "asset.idpiece";
            BeneInvView.Columns["nassetacquire"].ExtendedProperties["ViewSource"] = "asset.nassetacquire";
            BeneInvView.Columns["ninventory"].ExtendedProperties["ViewSource"] = "asset.ninventory";
            BeneInvView.Columns["idinventory"].ExtendedProperties["ViewSource"] = "asset.idinventory";
			BeneInvView.Columns["rfid"].ExtendedProperties["ViewSource"] = "asset.rfid";
			BeneInvView.Columns["lifestart"].ExtendedProperties["ViewSource"] = "asset.lifestart";
            BeneInvView.Columns["idassetunload"].ExtendedProperties["ViewSource"] = "asset.idassetunload";
            BeneInvView.Columns["multifield"].ExtendedProperties["ViewSource"] = "asset.multifield";
            BeneInvView.Columns["flag"].ExtendedProperties["ViewSource"] = "asset.flag";
            //BeneInvView.Columns["txt"].ExtendedProperties["ViewSource"] = "asset.txt";
            //BeneInvView.Columns["rtf"].ExtendedProperties["ViewSource"] = "asset.rtf";
            BeneInvView.Columns["transmitted"].ExtendedProperties["ViewSource"] = "asset.transmitted";
            BeneInvView.Columns["idasset_prev"].ExtendedProperties["ViewSource"] = "asset.idasset_prev";
            BeneInvView.Columns["idpiece_prev"].ExtendedProperties["ViewSource"] = "asset.idpiece_prev";
            BeneInvView.Columns["cu"].ExtendedProperties["ViewSource"] = "asset.cu";
            BeneInvView.Columns["ct"].ExtendedProperties["ViewSource"] = "asset.ct";
            BeneInvView.Columns["lu"].ExtendedProperties["ViewSource"] = "asset.lu";
            BeneInvView.Columns["lt"].ExtendedProperties["ViewSource"] = "asset.lt";
            BeneInvView.Columns["idinventoryamortization"].ExtendedProperties["ViewSource"] =
                "asset.idinventoryamortization";
            BeneInvView.Columns["amortizationquota"].ExtendedProperties["ViewSource"] = "asset.amortizationquota";
            BeneInvView.Columns["inventory"].ExtendedProperties["ViewSource"] = "inventory.description";

            BeneInvView.Columns["codeinv"].ExtendedProperties["ViewSource"] = "inventorytreeview.codeinv";
            BeneInvView.Columns["inventorytree"].ExtendedProperties["ViewSource"] = "inventorytreeview.description";
            BeneInvView.Columns["idcurrman"].ExtendedProperties["ViewSource"] = "asset.idcurrman";
            BeneInvView.Columns["idcurrsubman"].ExtendedProperties["ViewSource"] = "asset.idcurrsubman";
            BeneInvView.Columns["idcurrlocation"].ExtendedProperties["ViewSource"] = "asset.idcurrlocation";


            //vista per grid quota utilizzo
            DataTable UtilizzoCarico = DS.assetusage;
            DataTable UtilizzoCaricoView = DS.assetusageview;
            DataTable TipoUtilizzo = DS.assetusagekind;

            UtilizzoCarico.ExtendedProperties["ViewTable"] = UtilizzoCaricoView;
            TipoUtilizzo.ExtendedProperties["ViewTable"] = UtilizzoCaricoView;
            UtilizzoCaricoView.ExtendedProperties["RealTable"] = UtilizzoCarico;

            UtilizzoCaricoView.Columns["nassetacquire"].ExtendedProperties["ViewSource"] = "assetusage.nassetacquire";
            UtilizzoCaricoView.Columns["idassetusagekind"].ExtendedProperties["ViewSource"] =
                "assetusage.idassetusagekind";
            UtilizzoCaricoView.Columns["usagequota"].ExtendedProperties["ViewSource"] = "assetusage.usagequota";
            UtilizzoCaricoView.Columns["cu"].ExtendedProperties["ViewSource"] = "assetusage.cu";
            UtilizzoCaricoView.Columns["ct"].ExtendedProperties["ViewSource"] = "assetusage.ct";
            UtilizzoCaricoView.Columns["lu"].ExtendedProperties["ViewSource"] = "assetusage.lu";
            UtilizzoCaricoView.Columns["lt"].ExtendedProperties["ViewSource"] = "assetusage.lt";

            UtilizzoCaricoView.Columns["assetusagekind"].ExtendedProperties["ViewSource"] = "assetusagekind.description";
            //GetData.MarkToAddBlankRow(DS.upb);
            //GetData.Add_Blank_Row(DS.upb);
            GetData.SetSorting(DS.upb, "codeupb ASC");
            GetData.SetSorting(DS.assetacquireview, "nassetacquire DESC");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetacquire_default));
            this.tabCaricoBeni = new System.Windows.Forms.TabControl();
            this.tabPageOperazioni = new System.Windows.Forms.TabPage();
            this.gboxListino = new System.Windows.Forms.GroupBox();
            this.chkListDescription = new System.Windows.Forms.CheckBox();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtListino = new System.Windows.Forms.TextBox();
            this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkTransmitted = new System.Windows.Forms.CheckBox();
            this.chkIspieceAcquire = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCausale = new System.Windows.Forms.ComboBox();
            this.DS = new assetacquire_default.dsmeta();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.grpCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.chkIncludi = new System.Windows.Forms.CheckBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumCaricoBene = new System.Windows.Forms.TextBox();
            this.grpTipoCarico = new System.Windows.Forms.GroupBox();
            this.grpRigaFattura = new System.Windows.Forms.GroupBox();
            this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
            this.btnCollegaRigaFattura = new System.Windows.Forms.Button();
            this.txtNumRigaFattura = new System.Windows.Forms.TextBox();
            this.txtNumFattura = new System.Windows.Forms.TextBox();
            this.txtEsercFattura = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.grpBuonoInv = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRatificationDate = new System.Windows.Forms.TextBox();
            this.btnbuonocarico = new System.Windows.Forms.Button();
            this.cmbCodiceBuono = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNumBuono = new System.Windows.Forms.TextBox();
            this.txtEserBuono = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.grpRiga = new System.Windows.Forms.GroupBox();
            this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
            this.btnCollegaRiga = new System.Windows.Forms.Button();
            this.txtNumriga = new System.Windows.Forms.TextBox();
            this.txtNumordine = new System.Windows.Forms.TextBox();
            this.txtEsercordine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioPosseduto = new System.Windows.Forms.RadioButton();
            this.radioNuovo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageInventario = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImpTotale = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtImpostaTotale = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImpConIVA = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAbatable = new System.Windows.Forms.TextBox();
            this.btnSuggerimento = new System.Windows.Forms.Button();
            this.gboxCespiti = new System.Windows.Forms.GroupBox();
            this.btnModificaBene = new System.Windows.Forms.Button();
            this.btnCopiaBene = new System.Windows.Forms.Button();
            this.gridBene = new System.Windows.Forms.DataGrid();
            this.grpValore = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtImposta = new System.Windows.Forms.TextBox();
            this.txtSconto = new System.Windows.Forms.TextBox();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.btnNumInventario = new System.Windows.Forms.Button();
            this.txtNumIniz = new System.Windows.Forms.TextBox();
            this.cboInventario = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.tabPageUtilizzo = new System.Windows.Forms.TabPage();
            this.btnInserisciQuota = new System.Windows.Forms.Button();
            this.btnEliminaQuota = new System.Windows.Forms.Button();
            this.btnModificaQuota = new System.Windows.Forms.Button();
            this.gridQuota = new System.Windows.Forms.DataGrid();
            this.tabPageEP = new System.Windows.Forms.TabPage();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.grpAnalitico = new System.Windows.Forms.GroupBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.tabCaricoBeni.SuspendLayout();
            this.tabPageOperazioni.SuspendLayout();
            this.gboxListino.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpClassif.SuspendLayout();
            this.grpCredDeb.SuspendLayout();
            this.grpTipoCarico.SuspendLayout();
            this.grpRigaFattura.SuspendLayout();
            this.grpBuonoInv.SuspendLayout();
            this.grpRiga.SuspendLayout();
            this.tabPageInventario.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxCespiti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBene)).BeginInit();
            this.grpValore.SuspendLayout();
            this.grpInventario.SuspendLayout();
            this.tabPageUtilizzo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuota)).BeginInit();
            this.tabPageEP.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.grpAnalitico.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCaricoBeni
            // 
            this.tabCaricoBeni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCaricoBeni.Controls.Add(this.tabPageOperazioni);
            this.tabCaricoBeni.Controls.Add(this.tabPageInventario);
            this.tabCaricoBeni.Controls.Add(this.tabPageUtilizzo);
            this.tabCaricoBeni.Controls.Add(this.tabPageEP);
            this.tabCaricoBeni.HotTrack = true;
            this.tabCaricoBeni.Location = new System.Drawing.Point(0, 0);
            this.tabCaricoBeni.Name = "tabCaricoBeni";
            this.tabCaricoBeni.SelectedIndex = 0;
            this.tabCaricoBeni.Size = new System.Drawing.Size(899, 554);
            this.tabCaricoBeni.TabIndex = 0;
            this.tabCaricoBeni.SelectedIndexChanged += new System.EventHandler(this.tabCaricoBeni_SelectionChanged);
            // 
            // tabPageOperazioni
            // 
            this.tabPageOperazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageOperazioni.Controls.Add(this.gboxListino);
            this.tabPageOperazioni.Controls.Add(this.label16);
            this.tabPageOperazioni.Controls.Add(this.chkTransmitted);
            this.tabPageOperazioni.Controls.Add(this.chkIspieceAcquire);
            this.tabPageOperazioni.Controls.Add(this.groupBox2);
            this.tabPageOperazioni.Controls.Add(this.grpClassif);
            this.tabPageOperazioni.Controls.Add(this.grpCredDeb);
            this.tabPageOperazioni.Controls.Add(this.chkIncludi);
            this.tabPageOperazioni.Controls.Add(this.txtDataContabile);
            this.tabPageOperazioni.Controls.Add(this.txtDescrizione);
            this.tabPageOperazioni.Controls.Add(this.label6);
            this.tabPageOperazioni.Controls.Add(this.label5);
            this.tabPageOperazioni.Controls.Add(this.txtNumCaricoBene);
            this.tabPageOperazioni.Controls.Add(this.grpTipoCarico);
            this.tabPageOperazioni.Controls.Add(this.label1);
            this.tabPageOperazioni.Location = new System.Drawing.Point(4, 22);
            this.tabPageOperazioni.Name = "tabPageOperazioni";
            this.tabPageOperazioni.Size = new System.Drawing.Size(891, 528);
            this.tabPageOperazioni.TabIndex = 3;
            this.tabPageOperazioni.Text = "Principale";
            // 
            // gboxListino
            // 
            this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxListino.Controls.Add(this.chkListDescription);
            this.gboxListino.Controls.Add(this.btnListino);
            this.gboxListino.Controls.Add(this.txtListino);
            this.gboxListino.Controls.Add(this.txtDescrizioneListino);
            this.gboxListino.Location = new System.Drawing.Point(450, 239);
            this.gboxListino.Name = "gboxListino";
            this.gboxListino.Size = new System.Drawing.Size(431, 123);
            this.gboxListino.TabIndex = 6;
            this.gboxListino.TabStop = false;
            this.gboxListino.Tag = "";
            // 
            // chkListDescription
            // 
            this.chkListDescription.Location = new System.Drawing.Point(11, 13);
            this.chkListDescription.Name = "chkListDescription";
            this.chkListDescription.Size = new System.Drawing.Size(277, 20);
            this.chkListDescription.TabIndex = 1;
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
            this.txtListino.Size = new System.Drawing.Size(409, 20);
            this.txtListino.TabIndex = 6;
            this.txtListino.Tag = "listview.intcode?assetacquireview.intcode";
            this.txtListino.TextChanged += new System.EventHandler(this.txtListino_TextChanged);
            this.txtListino.Enter += new System.EventHandler(this.txtListino_Enter);
            // 
            // txtDescrizioneListino
            // 
            this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneListino.Location = new System.Drawing.Point(134, 37);
            this.txtDescrizioneListino.Multiline = true;
            this.txtDescrizioneListino.Name = "txtDescrizioneListino";
            this.txtDescrizioneListino.ReadOnly = true;
            this.txtDescrizioneListino.Size = new System.Drawing.Size(281, 57);
            this.txtDescrizioneListino.TabIndex = 9;
            this.txtDescrizioneListino.TabStop = false;
            this.txtDescrizioneListino.Tag = "";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(274, 500);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(606, 23);
            this.label16.TabIndex = 11;
            this.label16.Text = "Nota: l\'inclusione di un bene in un buono di carico è condizione necessaria per p" +
    "oterlo poi ammortizzare.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // chkTransmitted
            // 
            this.chkTransmitted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTransmitted.AutoSize = true;
            this.chkTransmitted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransmitted.Location = new System.Drawing.Point(351, 475);
            this.chkTransmitted.Name = "chkTransmitted";
            this.chkTransmitted.Size = new System.Drawing.Size(77, 17);
            this.chkTransmitted.TabIndex = 9;
            this.chkTransmitted.Tag = "assetacquire.transmitted:S:N";
            this.chkTransmitted.Text = "Trasmesso";
            this.chkTransmitted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTransmitted.UseVisualStyleBackColor = true;
            // 
            // chkIspieceAcquire
            // 
            this.chkIspieceAcquire.Location = new System.Drawing.Point(16, 5);
            this.chkIspieceAcquire.Name = "chkIspieceAcquire";
            this.chkIspieceAcquire.Size = new System.Drawing.Size(168, 16);
            this.chkIspieceAcquire.TabIndex = 1;
            this.chkIspieceAcquire.Tag = "assetacquire.flag:2";
            this.chkIspieceAcquire.Text = "Carico di un ACCESSORIO ";
            this.chkIspieceAcquire.CheckStateChanged += new System.EventHandler(this.chkIspieceAcquire_CheckStateChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboCausale);
            this.groupBox2.Location = new System.Drawing.Point(8, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 47);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Causale di Carico";
            // 
            // cboCausale
            // 
            this.cboCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCausale.DataSource = this.DS.assetloadmotive;
            this.cboCausale.DisplayMember = "description";
            this.cboCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCausale.Location = new System.Drawing.Point(8, 15);
            this.cboCausale.Name = "cboCausale";
            this.cboCausale.Size = new System.Drawing.Size(409, 21);
            this.cboCausale.TabIndex = 14;
            this.cboCausale.Tag = "assetacquire.idmot.(active=\'S\')";
            this.cboCausale.ValueMember = "idmot";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // grpClassif
            // 
            this.grpClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(450, 365);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(433, 103);
            this.grpClassif.TabIndex = 7;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(134, 12);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(296, 54);
            this.txtDescClassif.TabIndex = 19;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtIdClassif
            // 
            this.txtIdClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdClassif.Location = new System.Drawing.Point(8, 73);
            this.txtIdClassif.Name = "txtIdClassif";
            this.txtIdClassif.Size = new System.Drawing.Size(423, 20);
            this.txtIdClassif.TabIndex = 1;
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetacquireview.codeinv";
            // 
            // btnClassif
            // 
            this.btnClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(11, 44);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(120, 23);
            this.btnClassif.TabIndex = 17;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            // 
            // grpCredDeb
            // 
            this.grpCredDeb.Controls.Add(this.txtCredDeb);
            this.grpCredDeb.Location = new System.Drawing.Point(8, 252);
            this.grpCredDeb.Name = "grpCredDeb";
            this.grpCredDeb.Size = new System.Drawing.Size(425, 46);
            this.grpCredDeb.TabIndex = 4;
            this.grpCredDeb.TabStop = false;
            this.grpCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.grpCredDeb.Text = "Cedente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(409, 20);
            this.txtCredDeb.TabIndex = 12;
            this.txtCredDeb.Tag = "registry.title?assetacquireview.registry";
            // 
            // chkIncludi
            // 
            this.chkIncludi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkIncludi.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIncludi.Location = new System.Drawing.Point(696, 476);
            this.chkIncludi.Name = "chkIncludi";
            this.chkIncludi.Size = new System.Drawing.Size(184, 19);
            this.chkIncludi.TabIndex = 10;
            this.chkIncludi.Tag = "assetacquire.flag:0";
            this.chkIncludi.Text = "Includere in Buono di Carico";
            this.chkIncludi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataContabile.Location = new System.Drawing.Point(103, 471);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 8;
            this.txtDataContabile.Tag = "assetacquire.adate";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 374);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(425, 91);
            this.txtDescrizione.TabIndex = 6;
            this.txtDescrizione.Tag = "assetacquire.description";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(9, 473);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Data contabile:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Descrizione:";
            // 
            // txtNumCaricoBene
            // 
            this.txtNumCaricoBene.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumCaricoBene.Location = new System.Drawing.Point(811, 3);
            this.txtNumCaricoBene.Name = "txtNumCaricoBene";
            this.txtNumCaricoBene.Size = new System.Drawing.Size(72, 20);
            this.txtNumCaricoBene.TabIndex = 2;
            this.txtNumCaricoBene.Tag = "assetacquire.nassetacquire";
            // 
            // grpTipoCarico
            // 
            this.grpTipoCarico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoCarico.Controls.Add(this.grpRigaFattura);
            this.grpTipoCarico.Controls.Add(this.grpBuonoInv);
            this.grpTipoCarico.Controls.Add(this.grpRiga);
            this.grpTipoCarico.Controls.Add(this.radioPosseduto);
            this.grpTipoCarico.Controls.Add(this.radioNuovo);
            this.grpTipoCarico.Location = new System.Drawing.Point(8, 27);
            this.grpTipoCarico.Name = "grpTipoCarico";
            this.grpTipoCarico.Size = new System.Drawing.Size(875, 212);
            this.grpTipoCarico.TabIndex = 3;
            this.grpTipoCarico.TabStop = false;
            this.grpTipoCarico.Text = "Tipo carico";
            // 
            // grpRigaFattura
            // 
            this.grpRigaFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRigaFattura.Controls.Add(this.cmbTipoFattura);
            this.grpRigaFattura.Controls.Add(this.btnCollegaRigaFattura);
            this.grpRigaFattura.Controls.Add(this.txtNumRigaFattura);
            this.grpRigaFattura.Controls.Add(this.txtNumFattura);
            this.grpRigaFattura.Controls.Add(this.txtEsercFattura);
            this.grpRigaFattura.Controls.Add(this.label17);
            this.grpRigaFattura.Location = new System.Drawing.Point(8, 90);
            this.grpRigaFattura.Name = "grpRigaFattura";
            this.grpRigaFattura.Size = new System.Drawing.Size(749, 48);
            this.grpRigaFattura.TabIndex = 5;
            this.grpRigaFattura.TabStop = false;
            this.grpRigaFattura.Text = "Riga della fattura (Tipo  / Eserc. /  Num.  / Gruppo)";
            // 
            // cmbTipoFattura
            // 
            this.cmbTipoFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoFattura.DataSource = this.DS.invoicekind;
            this.cmbTipoFattura.DisplayMember = "description";
            this.cmbTipoFattura.Location = new System.Drawing.Point(162, 19);
            this.cmbTipoFattura.Name = "cmbTipoFattura";
            this.cmbTipoFattura.Size = new System.Drawing.Size(390, 21);
            this.cmbTipoFattura.TabIndex = 2;
            this.cmbTipoFattura.Tag = "assetacquire.idinvkind";
            this.cmbTipoFattura.ValueMember = "idinvkind";
            // 
            // btnCollegaRigaFattura
            // 
            this.btnCollegaRigaFattura.Location = new System.Drawing.Point(8, 19);
            this.btnCollegaRigaFattura.Name = "btnCollegaRigaFattura";
            this.btnCollegaRigaFattura.Size = new System.Drawing.Size(128, 23);
            this.btnCollegaRigaFattura.TabIndex = 1;
            this.btnCollegaRigaFattura.TabStop = false;
            this.btnCollegaRigaFattura.Tag = "";
            this.btnCollegaRigaFattura.Text = "Riga fattura";
            this.btnCollegaRigaFattura.Click += new System.EventHandler(this.btnCollegaRigaFattura_Click);
            // 
            // txtNumRigaFattura
            // 
            this.txtNumRigaFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumRigaFattura.Location = new System.Drawing.Point(674, 19);
            this.txtNumRigaFattura.Name = "txtNumRigaFattura";
            this.txtNumRigaFattura.Size = new System.Drawing.Size(48, 20);
            this.txtNumRigaFattura.TabIndex = 5;
            this.txtNumRigaFattura.Tag = "assetacquire.invrownum";
            // 
            // txtNumFattura
            // 
            this.txtNumFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumFattura.Location = new System.Drawing.Point(612, 20);
            this.txtNumFattura.Name = "txtNumFattura";
            this.txtNumFattura.Size = new System.Drawing.Size(56, 20);
            this.txtNumFattura.TabIndex = 4;
            this.txtNumFattura.Tag = "assetacquire.ninv";
            // 
            // txtEsercFattura
            // 
            this.txtEsercFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercFattura.Location = new System.Drawing.Point(558, 19);
            this.txtEsercFattura.Name = "txtEsercFattura";
            this.txtEsercFattura.Size = new System.Drawing.Size(48, 20);
            this.txtEsercFattura.TabIndex = 3;
            this.txtEsercFattura.Tag = "assetacquire.yinv.year";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(120, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 16);
            this.label17.TabIndex = 0;
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpBuonoInv
            // 
            this.grpBuonoInv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBuonoInv.Controls.Add(this.label18);
            this.grpBuonoInv.Controls.Add(this.txtRatificationDate);
            this.grpBuonoInv.Controls.Add(this.btnbuonocarico);
            this.grpBuonoInv.Controls.Add(this.cmbCodiceBuono);
            this.grpBuonoInv.Controls.Add(this.label4);
            this.grpBuonoInv.Controls.Add(this.label15);
            this.grpBuonoInv.Controls.Add(this.txtNumBuono);
            this.grpBuonoInv.Controls.Add(this.txtEserBuono);
            this.grpBuonoInv.Controls.Add(this.label);
            this.grpBuonoInv.Location = new System.Drawing.Point(4, 142);
            this.grpBuonoInv.Name = "grpBuonoInv";
            this.grpBuonoInv.Size = new System.Drawing.Size(859, 64);
            this.grpBuonoInv.TabIndex = 4;
            this.grpBuonoInv.TabStop = false;
            this.grpBuonoInv.Text = "Buono di Carico (se l\'accessorio è stato già incluso in un buono come parte di un" +
    " cespite è normale che questi campi siano vuoti)";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(769, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 13;
            this.label18.Text = "Data ratifica";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRatificationDate
            // 
            this.txtRatificationDate.Location = new System.Drawing.Point(771, 37);
            this.txtRatificationDate.Name = "txtRatificationDate";
            this.txtRatificationDate.Size = new System.Drawing.Size(72, 20);
            this.txtRatificationDate.TabIndex = 12;
            this.txtRatificationDate.Tag = "assetload.ratificationdate?assetacquireview.ratificationdate";
            // 
            // btnbuonocarico
            // 
            this.btnbuonocarico.Location = new System.Drawing.Point(8, 34);
            this.btnbuonocarico.Name = "btnbuonocarico";
            this.btnbuonocarico.Size = new System.Drawing.Size(91, 23);
            this.btnbuonocarico.TabIndex = 4;
            this.btnbuonocarico.TabStop = false;
            this.btnbuonocarico.Text = "Buono di carico";
            this.btnbuonocarico.UseVisualStyleBackColor = true;
            this.btnbuonocarico.Click += new System.EventHandler(this.btnbuonocarico_Click);
            // 
            // cmbCodiceBuono
            // 
            this.cmbCodiceBuono.DataSource = this.DS.assetloadkind;
            this.cmbCodiceBuono.DisplayMember = "description";
            this.cmbCodiceBuono.Location = new System.Drawing.Point(107, 36);
            this.cmbCodiceBuono.Name = "cmbCodiceBuono";
            this.cmbCodiceBuono.Size = new System.Drawing.Size(525, 21);
            this.cmbCodiceBuono.TabIndex = 1;
            this.cmbCodiceBuono.Tag = "assetload.idassetloadkind.(active=\'S\')?assetacquireview.idassetloadkind";
            this.cmbCodiceBuono.ValueMember = "idassetloadkind";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(104, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo Buono";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(691, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 16);
            this.label15.TabIndex = 4;
            this.label15.Text = "Numero";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumBuono
            // 
            this.txtNumBuono.Location = new System.Drawing.Point(693, 37);
            this.txtNumBuono.Name = "txtNumBuono";
            this.txtNumBuono.Size = new System.Drawing.Size(72, 20);
            this.txtNumBuono.TabIndex = 3;
            this.txtNumBuono.Tag = "assetload.nassetload?assetacquireview.nassetload";
            // 
            // txtEserBuono
            // 
            this.txtEserBuono.Location = new System.Drawing.Point(639, 37);
            this.txtEserBuono.Name = "txtEserBuono";
            this.txtEserBuono.Size = new System.Drawing.Size(48, 20);
            this.txtEserBuono.TabIndex = 2;
            this.txtEserBuono.Tag = "assetload.yassetload.year?assetacquireview.yassetload";
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(636, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(56, 16);
            this.label.TabIndex = 0;
            this.label.Text = "Esercizio";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpRiga
            // 
            this.grpRiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiga.Controls.Add(this.cmbTipoOrdine);
            this.grpRiga.Controls.Add(this.btnCollegaRiga);
            this.grpRiga.Controls.Add(this.txtNumriga);
            this.grpRiga.Controls.Add(this.txtNumordine);
            this.grpRiga.Controls.Add(this.txtEsercordine);
            this.grpRiga.Controls.Add(this.label2);
            this.grpRiga.Location = new System.Drawing.Point(8, 43);
            this.grpRiga.Name = "grpRiga";
            this.grpRiga.Size = new System.Drawing.Size(749, 48);
            this.grpRiga.TabIndex = 2;
            this.grpRiga.TabStop = false;
            this.grpRiga.Text = "Riga del contratto passivo (Tipo  / Eserc. /  Num.  / Gruppo)";
            // 
            // cmbTipoOrdine
            // 
            this.cmbTipoOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoOrdine.DataSource = this.DS.mandatekind;
            this.cmbTipoOrdine.DisplayMember = "description";
            this.cmbTipoOrdine.Location = new System.Drawing.Point(162, 19);
            this.cmbTipoOrdine.Name = "cmbTipoOrdine";
            this.cmbTipoOrdine.Size = new System.Drawing.Size(390, 21);
            this.cmbTipoOrdine.TabIndex = 2;
            this.cmbTipoOrdine.Tag = "assetacquire.idmankind";
            this.cmbTipoOrdine.ValueMember = "idmankind";
            // 
            // btnCollegaRiga
            // 
            this.btnCollegaRiga.Location = new System.Drawing.Point(8, 19);
            this.btnCollegaRiga.Name = "btnCollegaRiga";
            this.btnCollegaRiga.Size = new System.Drawing.Size(128, 23);
            this.btnCollegaRiga.TabIndex = 1;
            this.btnCollegaRiga.TabStop = false;
            this.btnCollegaRiga.Tag = "";
            this.btnCollegaRiga.Text = "Riga contratto passivo";
            this.btnCollegaRiga.Click += new System.EventHandler(this.btnCollegaRiga_Click);
            // 
            // txtNumriga
            // 
            this.txtNumriga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumriga.Location = new System.Drawing.Point(674, 19);
            this.txtNumriga.Name = "txtNumriga";
            this.txtNumriga.Size = new System.Drawing.Size(48, 20);
            this.txtNumriga.TabIndex = 5;
            this.txtNumriga.Tag = "assetacquire.rownum";
            this.txtNumriga.Leave += new System.EventHandler(this.txtNumriga_Leave);
            // 
            // txtNumordine
            // 
            this.txtNumordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumordine.Location = new System.Drawing.Point(612, 19);
            this.txtNumordine.Name = "txtNumordine";
            this.txtNumordine.Size = new System.Drawing.Size(56, 20);
            this.txtNumordine.TabIndex = 4;
            this.txtNumordine.Tag = "assetacquire.nman";
            this.txtNumordine.Leave += new System.EventHandler(this.txtNumordine_Leave);
            // 
            // txtEsercordine
            // 
            this.txtEsercordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercordine.Location = new System.Drawing.Point(558, 19);
            this.txtEsercordine.Name = "txtEsercordine";
            this.txtEsercordine.Size = new System.Drawing.Size(48, 20);
            this.txtEsercordine.TabIndex = 3;
            this.txtEsercordine.Tag = "assetacquire.yman.year";
            this.txtEsercordine.Leave += new System.EventHandler(this.txtEsercordine_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // radioPosseduto
            // 
            this.radioPosseduto.Location = new System.Drawing.Point(223, 18);
            this.radioPosseduto.Name = "radioPosseduto";
            this.radioPosseduto.Size = new System.Drawing.Size(643, 24);
            this.radioPosseduto.TabIndex = 3;
            this.radioPosseduto.Tag = "assetacquire.flag::1";
            this.radioPosseduto.Text = "Cespite posseduto (da usare se si stanno inserendo buoni di carico di anni preced" +
    "enti l\'adozione del software)";
            this.radioPosseduto.CheckedChanged += new System.EventHandler(this.radioPosseduto_CheckedChanged);
            // 
            // radioNuovo
            // 
            this.radioNuovo.Location = new System.Drawing.Point(8, 18);
            this.radioNuovo.Name = "radioNuovo";
            this.radioNuovo.Size = new System.Drawing.Size(213, 17);
            this.radioNuovo.TabIndex = 1;
            this.radioNuovo.Tag = "assetacquire.flag::#1";
            this.radioNuovo.Text = "Nuova acquisizione";
            this.radioNuovo.CheckedChanged += new System.EventHandler(this.radioNuovo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(683, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero carico cespite";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPageInventario
            // 
            this.tabPageInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageInventario.Controls.Add(this.textBox2);
            this.tabPageInventario.Controls.Add(this.groupBox3);
            this.tabPageInventario.Controls.Add(this.groupBox1);
            this.tabPageInventario.Controls.Add(this.gboxCespiti);
            this.tabPageInventario.Controls.Add(this.grpValore);
            this.tabPageInventario.Controls.Add(this.grpInventario);
            this.tabPageInventario.Location = new System.Drawing.Point(4, 22);
            this.tabPageInventario.Name = "tabPageInventario";
            this.tabPageInventario.Size = new System.Drawing.Size(891, 528);
            this.tabPageInventario.TabIndex = 4;
            this.tabPageInventario.Text = "Inventario";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(224, 159);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(649, 39);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(871, 55);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Valore storico, ai fini degli ammortamenti";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(85, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "assetacquire.historicalvalue";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtImpTotale);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtImpostaTotale);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtImpConIVA);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtAbatable);
            this.groupBox1.Controls.Add(this.btnSuggerimento);
            this.groupBox1.Location = new System.Drawing.Point(8, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 64);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Totali";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Imponibile";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpTotale
            // 
            this.txtImpTotale.Location = new System.Drawing.Point(8, 32);
            this.txtImpTotale.Name = "txtImpTotale";
            this.txtImpTotale.ReadOnly = true;
            this.txtImpTotale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpTotale.Size = new System.Drawing.Size(96, 20);
            this.txtImpTotale.TabIndex = 5;
            this.txtImpTotale.TabStop = false;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(128, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "IVA ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpostaTotale
            // 
            this.txtImpostaTotale.Location = new System.Drawing.Point(128, 32);
            this.txtImpostaTotale.Name = "txtImpostaTotale";
            this.txtImpostaTotale.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtImpostaTotale.Size = new System.Drawing.Size(96, 20);
            this.txtImpostaTotale.TabIndex = 6;
            this.txtImpostaTotale.Tag = "assetacquire.tax";
            this.txtImpostaTotale.TextChanged += new System.EventHandler(this.txtImpostaTotale_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(248, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Totale";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtImpConIVA
            // 
            this.txtImpConIVA.Location = new System.Drawing.Point(248, 32);
            this.txtImpConIVA.Name = "txtImpConIVA";
            this.txtImpConIVA.ReadOnly = true;
            this.txtImpConIVA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpConIVA.Size = new System.Drawing.Size(96, 20);
            this.txtImpConIVA.TabIndex = 8;
            this.txtImpConIVA.TabStop = false;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(376, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 9;
            this.label14.Text = "IVA detraibile";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAbatable
            // 
            this.txtAbatable.Location = new System.Drawing.Point(376, 32);
            this.txtAbatable.Name = "txtAbatable";
            this.txtAbatable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAbatable.Size = new System.Drawing.Size(80, 20);
            this.txtAbatable.TabIndex = 10;
            this.txtAbatable.Tag = "assetacquire.abatable";
            // 
            // btnSuggerimento
            // 
            this.btnSuggerimento.Location = new System.Drawing.Point(488, 16);
            this.btnSuggerimento.Name = "btnSuggerimento";
            this.btnSuggerimento.Size = new System.Drawing.Size(161, 40);
            this.btnSuggerimento.TabIndex = 7;
            this.btnSuggerimento.Text = "Suggerimento su come effettuare il carico";
            this.btnSuggerimento.Click += new System.EventHandler(this.btnSuggerimento_Click);
            // 
            // gboxCespiti
            // 
            this.gboxCespiti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCespiti.Controls.Add(this.btnModificaBene);
            this.gboxCespiti.Controls.Add(this.btnCopiaBene);
            this.gboxCespiti.Controls.Add(this.gridBene);
            this.gboxCespiti.Location = new System.Drawing.Point(8, 280);
            this.gboxCespiti.Name = "gboxCespiti";
            this.gboxCespiti.Size = new System.Drawing.Size(879, 242);
            this.gboxCespiti.TabIndex = 5;
            this.gboxCespiti.TabStop = false;
            this.gboxCespiti.Text = "Cespiti inventariabili";
            // 
            // btnModificaBene
            // 
            this.btnModificaBene.Location = new System.Drawing.Point(104, 20);
            this.btnModificaBene.Name = "btnModificaBene";
            this.btnModificaBene.Size = new System.Drawing.Size(75, 23);
            this.btnModificaBene.TabIndex = 15;
            this.btnModificaBene.Tag = "edit.dettaglio";
            this.btnModificaBene.Text = "Modifica";
            this.btnModificaBene.Click += new System.EventHandler(this.btnModificaBene_Click);
            // 
            // btnCopiaBene
            // 
            this.btnCopiaBene.Location = new System.Drawing.Point(16, 20);
            this.btnCopiaBene.Name = "btnCopiaBene";
            this.btnCopiaBene.Size = new System.Drawing.Size(75, 23);
            this.btnCopiaBene.TabIndex = 14;
            this.btnCopiaBene.Tag = "";
            this.btnCopiaBene.Text = "Copia";
            this.btnCopiaBene.Click += new System.EventHandler(this.btnCopiaBene_Click);
            // 
            // gridBene
            // 
            this.gridBene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBene.CaptionVisible = false;
            this.gridBene.DataMember = "";
            this.gridBene.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridBene.Location = new System.Drawing.Point(11, 49);
            this.gridBene.Name = "gridBene";
            this.gridBene.Size = new System.Drawing.Size(860, 187);
            this.gridBene.TabIndex = 16;
            this.gridBene.Tag = "asset.dettaglio.dettaglio";
            // 
            // grpValore
            // 
            this.grpValore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpValore.Controls.Add(this.textBox3);
            this.grpValore.Controls.Add(this.txtImposta);
            this.grpValore.Controls.Add(this.txtSconto);
            this.grpValore.Controls.Add(this.txtQuantita);
            this.grpValore.Controls.Add(this.label12);
            this.grpValore.Controls.Add(this.label10);
            this.grpValore.Controls.Add(this.label8);
            this.grpValore.Controls.Add(this.txtImponibile);
            this.grpValore.Controls.Add(this.label7);
            this.grpValore.Location = new System.Drawing.Point(8, 80);
            this.grpValore.Name = "grpValore";
            this.grpValore.Size = new System.Drawing.Size(871, 63);
            this.grpValore.TabIndex = 2;
            this.grpValore.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(409, 13);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(456, 40);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "In caso di cespiti provenienti da altri inventari, inserire il valore residuo al " +
    "momento del trasferimento, comprensivo di iva, tutto nella casella imponibile.";
            // 
            // txtImposta
            // 
            this.txtImposta.Location = new System.Drawing.Point(312, 32);
            this.txtImposta.Name = "txtImposta";
            this.txtImposta.Size = new System.Drawing.Size(80, 20);
            this.txtImposta.TabIndex = 4;
            this.txtImposta.Tag = "assetacquire.taxrate.fixed.4..%.100";
            this.txtImposta.TextChanged += new System.EventHandler(this.txtImposta_TextChanged);
            this.txtImposta.Leave += new System.EventHandler(this.txtImposta_Leave);
            // 
            // txtSconto
            // 
            this.txtSconto.Location = new System.Drawing.Point(112, 32);
            this.txtSconto.Name = "txtSconto";
            this.txtSconto.Size = new System.Drawing.Size(80, 20);
            this.txtSconto.TabIndex = 2;
            this.txtSconto.Tag = "assetacquire.discount.fixed.4..%.100";
            this.txtSconto.TextChanged += new System.EventHandler(this.txtSconto_TextChanged);
            this.txtSconto.Leave += new System.EventHandler(this.txtSconto_Leave);
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(216, 32);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.Size = new System.Drawing.Size(80, 20);
            this.txtQuantita.TabIndex = 3;
            this.txtQuantita.Tag = "assetacquire.number";
            this.txtQuantita.TextChanged += new System.EventHandler(this.txtQuantita_TextChanged);
            this.txtQuantita.Leave += new System.EventHandler(this.txtQuantita_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(112, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Sconto";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(216, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Quantità";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(312, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Aliquota IVA";
            // 
            // txtImponibile
            // 
            this.txtImponibile.Location = new System.Drawing.Point(16, 32);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.Size = new System.Drawing.Size(80, 20);
            this.txtImponibile.TabIndex = 1;
            this.txtImponibile.Tag = "assetacquire.taxable";
            this.txtImponibile.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
            this.txtImponibile.Leave += new System.EventHandler(this.txtImponibile_Leave);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Imponibile";
            // 
            // grpInventario
            // 
            this.grpInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInventario.Controls.Add(this.btnNumInventario);
            this.grpInventario.Controls.Add(this.txtNumIniz);
            this.grpInventario.Controls.Add(this.cboInventario);
            this.grpInventario.Controls.Add(this.label13);
            this.grpInventario.Controls.Add(this.chkAuto);
            this.grpInventario.Location = new System.Drawing.Point(8, 0);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(871, 75);
            this.grpInventario.TabIndex = 1;
            this.grpInventario.TabStop = false;
            this.grpInventario.Text = "Inventario";
            // 
            // btnNumInventario
            // 
            this.btnNumInventario.Location = new System.Drawing.Point(19, 45);
            this.btnNumInventario.Name = "btnNumInventario";
            this.btnNumInventario.Size = new System.Drawing.Size(85, 24);
            this.btnNumInventario.TabIndex = 4;
            this.btnNumInventario.TabStop = false;
            this.btnNumInventario.Text = "N. iniziale";
            this.btnNumInventario.Click += new System.EventHandler(this.btnNumInventario_Click);
            // 
            // txtNumIniz
            // 
            this.txtNumIniz.Location = new System.Drawing.Point(110, 45);
            this.txtNumIniz.Name = "txtNumIniz";
            this.txtNumIniz.Size = new System.Drawing.Size(88, 20);
            this.txtNumIniz.TabIndex = 2;
            this.txtNumIniz.Tag = "assetacquire.startnumber";
            // 
            // cboInventario
            // 
            this.cboInventario.DataSource = this.DS.inventory;
            this.cboInventario.DisplayMember = "description";
            this.cboInventario.Location = new System.Drawing.Point(112, 16);
            this.cboInventario.Name = "cboInventario";
            this.cboInventario.Size = new System.Drawing.Size(328, 21);
            this.cboInventario.TabIndex = 1;
            this.cboInventario.Tag = "assetacquire.idinventory.(active=\'S\')?assetacquireview.idinventory";
            this.cboInventario.ValueMember = "idinventory";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Inventario";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAuto
            // 
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(251, 45);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(347, 24);
            this.chkAuto.TabIndex = 3;
            this.chkAuto.Text = "Assegnazione in automatico del numero di inventario";
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // tabPageUtilizzo
            // 
            this.tabPageUtilizzo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPageUtilizzo.Controls.Add(this.btnInserisciQuota);
            this.tabPageUtilizzo.Controls.Add(this.btnEliminaQuota);
            this.tabPageUtilizzo.Controls.Add(this.btnModificaQuota);
            this.tabPageUtilizzo.Controls.Add(this.gridQuota);
            this.tabPageUtilizzo.Location = new System.Drawing.Point(4, 22);
            this.tabPageUtilizzo.Name = "tabPageUtilizzo";
            this.tabPageUtilizzo.Size = new System.Drawing.Size(891, 528);
            this.tabPageUtilizzo.TabIndex = 5;
            this.tabPageUtilizzo.Text = "Utilizzo";
            // 
            // btnInserisciQuota
            // 
            this.btnInserisciQuota.Location = new System.Drawing.Point(8, 16);
            this.btnInserisciQuota.Name = "btnInserisciQuota";
            this.btnInserisciQuota.Size = new System.Drawing.Size(75, 24);
            this.btnInserisciQuota.TabIndex = 0;
            this.btnInserisciQuota.Tag = "insert.dettaglioquota";
            this.btnInserisciQuota.Text = "Inserisci";
            // 
            // btnEliminaQuota
            // 
            this.btnEliminaQuota.Location = new System.Drawing.Point(8, 80);
            this.btnEliminaQuota.Name = "btnEliminaQuota";
            this.btnEliminaQuota.Size = new System.Drawing.Size(75, 24);
            this.btnEliminaQuota.TabIndex = 2;
            this.btnEliminaQuota.Tag = "delete";
            this.btnEliminaQuota.Text = "Elimina";
            // 
            // btnModificaQuota
            // 
            this.btnModificaQuota.Location = new System.Drawing.Point(8, 48);
            this.btnModificaQuota.Name = "btnModificaQuota";
            this.btnModificaQuota.Size = new System.Drawing.Size(75, 24);
            this.btnModificaQuota.TabIndex = 1;
            this.btnModificaQuota.Tag = "edit.dettaglioquota";
            this.btnModificaQuota.Text = "Modifica";
            // 
            // gridQuota
            // 
            this.gridQuota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridQuota.CaptionVisible = false;
            this.gridQuota.DataMember = "";
            this.gridQuota.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridQuota.Location = new System.Drawing.Point(88, 16);
            this.gridQuota.Name = "gridQuota";
            this.gridQuota.Size = new System.Drawing.Size(788, 500);
            this.gridQuota.TabIndex = 3;
            this.gridQuota.Tag = "assetusage.dettaglioquota.dettaglioquota";
            // 
            // tabPageEP
            // 
            this.tabPageEP.Controls.Add(this.gboxUPB);
            this.tabPageEP.Controls.Add(this.grpAnalitico);
            this.tabPageEP.Location = new System.Drawing.Point(4, 22);
            this.tabPageEP.Name = "tabPageEP";
            this.tabPageEP.Size = new System.Drawing.Size(891, 528);
            this.tabPageEP.TabIndex = 6;
            this.tabPageEP.Text = "   E/P   ";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(18, 3);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(459, 104);
            this.gboxUPB.TabIndex = 9;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(445, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(141, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(312, 62);
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
            // grpAnalitico
            // 
            this.grpAnalitico.Controls.Add(this.gboxclass3);
            this.grpAnalitico.Controls.Add(this.gboxclass2);
            this.grpAnalitico.Controls.Add(this.gboxclass1);
            this.grpAnalitico.Location = new System.Drawing.Point(18, 113);
            this.grpAnalitico.Name = "grpAnalitico";
            this.grpAnalitico.Size = new System.Drawing.Size(459, 313);
            this.grpAnalitico.TabIndex = 7;
            this.grpAnalitico.TabStop = false;
            this.grpAnalitico.Text = "Analitico";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(8, 219);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(433, 85);
            this.gboxclass3.TabIndex = 9;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 30);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(133, 14);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(292, 39);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 59);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(419, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(8, 115);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(433, 89);
            this.gboxclass2.TabIndex = 8;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 34);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(133, 14);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(292, 46);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(8, 63);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(417, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(8, 20);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(433, 89);
            this.gboxclass1.TabIndex = 7;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 37);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(133, 12);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(292, 48);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 63);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(417, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // Frm_assetacquire_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(911, 563);
            this.Controls.Add(this.tabCaricoBeni);
            this.Name = "Frm_assetacquire_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_assetacquire_default";
            this.Load += new System.EventHandler(this.Frm_assetacquire_default_Load);
            this.tabCaricoBeni.ResumeLayout(false);
            this.tabPageOperazioni.ResumeLayout(false);
            this.tabPageOperazioni.PerformLayout();
            this.gboxListino.ResumeLayout(false);
            this.gboxListino.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.grpCredDeb.ResumeLayout(false);
            this.grpCredDeb.PerformLayout();
            this.grpTipoCarico.ResumeLayout(false);
            this.grpRigaFattura.ResumeLayout(false);
            this.grpRigaFattura.PerformLayout();
            this.grpBuonoInv.ResumeLayout(false);
            this.grpBuonoInv.PerformLayout();
            this.grpRiga.ResumeLayout(false);
            this.grpRiga.PerformLayout();
            this.tabPageInventario.ResumeLayout(false);
            this.tabPageInventario.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxCespiti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBene)).EndInit();
            this.grpValore.ResumeLayout(false);
            this.grpValore.PerformLayout();
            this.grpInventario.ResumeLayout(false);
            this.grpInventario.PerformLayout();
            this.tabPageUtilizzo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQuota)).EndInit();
            this.tabPageEP.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.grpAnalitico.ResumeLayout(false);
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void AbilitaCredDeb(bool enable) {
            txtCredDeb.ReadOnly = !enable;
        }

        private void AbilitaTipoCarico(bool enable) {
            radioNuovo.Enabled = enable;
            radioPosseduto.Enabled = enable;
        }

        private void AbilitaRigaOrdine(bool enable) {
            grpRiga.Enabled = enable;
        }


        private void AbilitaAutoNumerazione(bool enable) {
            //se il check va disabilitato imposto il valore a true per la config. iniziale
            if (!enable && chkAuto.Checked) chkAuto.Checked = false;

            chkAuto.Enabled = enable;

            //se il check non è abilitato non abilito num. iniziale
            //if (enable && !chkAuto.Checked) return;

            AbilitaNumIniziale(!chkAuto.Checked);
        }

        private void AbilitaBenePosseduto(bool enable) {
            grpBuonoInv.Enabled = enable;
        }

        private void AbilitaNumIniziale(bool enable) {
            //btnNumInventario.Enabled=enable && chkIspieceAcquire.Checked;
            txtNumIniz.ReadOnly = !enable;
            if (enable)
                txtNumIniz.PasswordChar = Convert.ToChar(0);
            else
                txtNumIniz.PasswordChar = ' ';
        }

        /// <summary>
        /// sarebbe CalcolaTotali(true), cioè esegue GetFormData
        /// </summary>
        /*private void CalcolaTotali() {
			CalcolaTotali(true);
		}*/

        /// <summary>
        /// Calcola i totali. Se chiamato dopo l'aggiornamento righe di asset
        /// il parametro EseguiGetFormData è sempre a false
        /// </summary>
        /// <param name="EseguiGetFormData">True, esegue GetFormData</param>
        private void CalcolaTotali(bool EseguiGetFormData, bool RicalcolaTotIva) {
            if (Meta == null) return;
            if (Meta.IsEmpty) return;

            //Se non sono in salvataggio eseguo la lettura
            if (EseguiGetFormData) MetaData.GetFormData(this, true);

            if (DS.Tables["assetacquire"].Rows.Count == 0) return;
            DataRow R = DS.Tables["assetacquire"].Rows[0];
            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
            decimal quantita = CfgFn.GetNoNullDecimal(R["number"]);
            decimal sconto = CfgFn.GetNoNullDecimal(R["discount"]);
            decimal imposta = CfgFn.GetNoNullDecimal(R["taxrate"]);
            decimal ivadetraibile = CfgFn.GetNoNullDecimal(R["abatable"]);

            decimal imponibiletot = CfgFn.RoundValuta(imponibile * (1 - sconto)) * quantita;
            decimal impostatot;
            if (RicalcolaTotIva) {
                if (MandateLinked) {
                    if (quantita == residuo || residuo == 0) {
                        impostatot = IvaGenResiduo;
                        ivadetraibile = IvaDetResiduo;
                    }
                    else {
                        impostatot =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                                Decimal.Truncate(IvaGenResiduo * 100 / residuo) / 100) * quantita);
                        ivadetraibile =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                                Decimal.Truncate(IvaDetResiduo * 100 / residuo) / 100) * quantita);

                    }
                }
                else {
                    impostatot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)) * imposta);
                }
            }
            else {
                impostatot = CfgFn.GetNoNullDecimal(R["tax"]);
            }

            decimal imponibileconiva = imponibiletot + impostatot;
            txtImpTotale.Text = imponibiletot.ToString("c");
            txtImpostaTotale.Text = impostatot.ToString("c");
            txtImpConIVA.Text = imponibileconiva.ToString("c");
            txtAbatable.Text = ivadetraibile.ToString("c");
        }


        private object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            return GetMAXNumInventario();
        }

        public void ImpostaAutoIncrementoNumInventario(bool enable) {
            DataColumn C = DS.asset.Columns["ninventory"];
            if (enable) {
                RowChange.MarkAsAutoincrement(C, null, null, 7);
                RowChange.MarkAsCustomAutoincrement(C, new RowChange.CustomCalcAutoID(CalcID));
            }
            else {
                RowChange.ClearAutoIncrement(C);
                RowChange.ClearCustomAutoIncrement(C);
            }
        }


        private int GetMAXNumInventario() {
            if (DS.assetacquire.Rows.Count == 0) return 1;
            object codiceinventario = DS.assetacquire.Rows[0]["idinventory"];
            if ((codiceinventario == DBNull.Value) || (CfgFn.GetNoNullInt32(codiceinventario) == 0)) return 1;
            //string sql_numiniziale="SELECT ISNULL(startnumber,0) FROM inventory "+
            //	"WHERE idinventory = "+QueryCreator.quotedstrvalue(codiceinventario,true);
            string sql_numiniziale = "SELECT ISNULL(startnumber,0) FROM inventory WHERE " +
                                     QHS.CmpEq("idinventory", codiceinventario);
            DataTable t = Meta.Conn.SQLRunner(sql_numiniziale, true, 0);
            int numiniziale = 0;
            if (t != null) numiniziale = CfgFn.GetNoNullInt32(t.Rows[0][0]);
            //string sqlmax = "SELECT ISNULL(MAX(ninventory),"+numiniziale.ToString()+") + 1 "+
            //	"FROM assetview "+
            //	"WHERE idinventory = "+QueryCreator.quotedstrvalue(codiceinventario,true)+
            //	" AND ninventory >= "+numiniziale.ToString();

            string sqlmax = "SELECT ISNULL(MAX(ninventory)," + numiniziale.ToString() + ") + 1 FROM assetview WHERE "
                            +
                            QHS.AppAnd(QHS.CmpEq("idinventory", codiceinventario), QHS.CmpGt("ninventory", numiniziale));

            t = Meta.Conn.SQLRunner(sqlmax, true, 0);
            return CfgFn.GetNoNullInt32(t.Rows[0][0]);
        }



        public void MetaData_AfterClear() {
            MetaData.SetDefault(DS.asset, "lifestart", Meta.GetSys("datacontabile"));
            MandateLinked = false;
            AbilitaTipoCarico(true);
            AbilitaBenePosseduto(true);
            AbilitaRigaOrdine(true);
            AbilitaBuonoInventario(true);
            AbilitaAutoNumerazione(false);
            //tabPageUtilizzo.Visible=true;
            ImpostaAutoIncrementoNumInventario(false);
            WarningDaVisualizzare = false;
            m_LastCodiceInventario = DBNull.Value;
            m_LastNumIniz = "";
            txtImpTotale.Text = "";
            txtImpostaTotale.Text = "";
            txtImpConIVA.Text = "";
            grpInventario.Enabled = true;
            chkIspieceAcquire.Enabled = true;
            btnNumInventario.Enabled = false;
            txtCredDeb.ReadOnly = false;
            HelpForm.SetDenyNull(DS.assetacquire.Columns["startnumber"], false);
            riempiOggetti(null);
            DisabilitaFattura(true);
            radioPosseduto.Enabled = true;
        }


        public void MetaData_BeforeFill() {
            if (Meta.IsEmpty) return;
            if (DS.assetacquire.Rows.Count == 0) return;
            DataRow R = DS.assetacquire.Rows[0];
            DataTable IDAvailable=null;
            DataRow rInvdetAvailable=null;
            if (R["idmankind"] != DBNull.Value &&
                R["yman"] != DBNull.Value &&
                R["nman"] != DBNull.Value &&
                R["rownum"] != DBNull.Value && !MandateLinked) {

                string filtro_cp = QHS.AppAnd(QHS.CmpEq("idmankind", R["idmankind"]), QHS.CmpEq("yman", R["yman"]),
                    QHS.CmpEq("nman", R["nman"]), QHS.CmpEq("idgroup", R["rownum"]));
                if (R["idreg"] != DBNull.Value) filtro_cp = QHS.AppAnd(filtro_cp, QHS.CmpEq("idreg", R["idreg"]));
                string filtro_CPperCespite = QHS.MCmp(R, "idmankind", "yman", "nman", "rownum");
                string filtro_Fattura = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]),
                QHS.CmpEq("ninv", R["ninv"]), QHS.CmpEq("invidgroup", R["invrownum"]));
                string filtro_FatturaPerCespite = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]),
                QHS.CmpEq("ninv", R["ninv"]), QHS.CmpEq("invrownum", R["invrownum"]));
                DataTable MDAvailable = new DataTable();
                if (R["idmankind"]!=DBNull.Value) MDAvailable=   Meta.Conn.RUN_SELECT("mandatedetailavailable", "*", null, filtro_cp, null, false);
                residuo = 0;
                if (MDAvailable.Rows.Count == 0) {
                    MessageBox.Show(@"Non ci sono dettagli dell'ordine specificato attivi. " +
                                    @"Presumibilmente i dettagli associati sono stati cancellati o annullati. " +
                                    @"E' necessario correggere i dati del contratto passivo correlato.");
                    //Meta.LogError("AssetAcquireDefault - MetaData_BeforeFill -  condizione di errore 1322- filtro:" + filtro_cp + " carico chiave:" +
                       // QHS.CmpKey(R));
                    if (Meta.InsertMode) {
                        DS.asset.Clear();
                        R["idmankind"] = DBNull.Value;
                        R["yman"] = DBNull.Value;
                        R["nman"] = DBNull.Value;
                        R["rownum"] = DBNull.Value;
                        txtNumriga.Text = "";
                        txtNumordine.Text = "";
                        txtEsercordine.Text = "";
                        TotIvaGenerale = 0;
                        TotIvaDetraibile = 0;
                        IvaDetResiduo = 0;
                        IvaGenResiduo = 0;
                        totquantita = 0;
                        cmbTipoOrdine.SelectedIndex = -1;
                        return;
                    }
                }
                else {
                    IDAvailable = new DataTable();
                    if (R["idinvkind"] != DBNull.Value) {
                        IDAvailable=Meta.Conn.RUN_SELECT("invoicedetailavailable", "*", null, filtro_Fattura, null, false);
                    }
                    if (IDAvailable.Rows.Count > 0) {
                        rInvdetAvailable = IDAvailable.Rows[0];
                        residuo = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);
                    }
                    else {
                        DataRow MDRAvailable = MDAvailable.Rows[0];
                        residuo = CfgFn.GetNoNullInt32(MDRAvailable["residual"]);
                    }
                }

                DataTable MDView = Meta.Conn.RUN_SELECT("mandatedetailgroupview", "*", null, filtro_cp, null, true);
               
                decimal impostacaricata = 0;
                decimal detraibilecaricato = 0;
                if (MDView.Rows.Count == 0) {
                    TotIvaGenerale = 0;
                    TotIvaDetraibile = 0;
                    IvaDetResiduo = 0;
                    IvaGenResiduo = 0;
                    totquantita = 0;
                }
                else {
                    DataRow MDRView = MDView.Rows[0];

                    DataTable FatturaGroup = new DataTable();
                    if (R["idinvkind"]!=DBNull.Value)FatturaGroup= Conn.RUN_SELECT("invoicedetailgroupview", "*", null, filtro_Fattura, null, false);
                    if (FatturaGroup.Rows.Count > 0) {
                        impostacaricata = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire",filtro_FatturaPerCespite, "SUM(tax)"));
                        detraibilecaricato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_FatturaPerCespite, "SUM(abatable)"));
                        DataRow rFatturaGroup = FatturaGroup.Rows[0];
                        decimal ivafattura = CfgFn.GetNoNullDecimal(FatturaGroup.Rows[0]["tax"]);
                        int quantitafattura = CfgFn.GetNoNullInt32(rInvdetAvailable["invoiced"]); //q.tà della fattura
                        int quantitacarico = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);// disponibile della fattura da caricare
                        residuo = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);
                        TotIvaGenerale = ivafattura;
                                //CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                                //    Decimal.Truncate(ivafattura * 100 / quantitafattura) / 100) * quantitacarico);
                        TotIvaDetraibile = calcolaIvaDetraibile(MDRView, rFatturaGroup,residuo);
                        IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                        IvaGenResiduo = TotIvaGenerale - impostacaricata;
                        totquantita = CfgFn.GetNoNullInt32(rFatturaGroup["number"]);


                    }
                    else {
                        impostacaricata = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_CPperCespite, "SUM(tax)"));
                        detraibilecaricato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_CPperCespite, "SUM(abatable)"));
                        TotIvaGenerale = CfgFn.GetNoNullDecimal(MDRView["tax"]);
                        TotIvaDetraibile = calcolaIvaDetraibile(MDRView,null,residuo);
                        IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                        IvaGenResiduo = TotIvaGenerale - impostacaricata;
                        totquantita = CfgFn.GetNoNullInt32(MDRView["number"]);
                    }
                    if (Meta.EditMode &&
                        R["idmankind", DataRowVersion.Original].ToString() ==
                        R["idmankind", DataRowVersion.Current].ToString() &&
                        R["yman", DataRowVersion.Original].ToString() == R["yman", DataRowVersion.Current].ToString() &&
                        R["nman", DataRowVersion.Original].ToString() == R["nman", DataRowVersion.Current].ToString() &&
                        R["rownum", DataRowVersion.Original].ToString() ==
                        R["rownum", DataRowVersion.Current].ToString()) {
                        residuo += CfgFn.GetNoNullInt32(R["number", DataRowVersion.Original]);
                        IvaDetResiduo += CfgFn.GetNoNullDecimal(R["abatable", DataRowVersion.Original]);
                        IvaGenResiduo += CfgFn.GetNoNullDecimal(R["tax", DataRowVersion.Original]);

                    }
                }
                MandateLinked = true;
            }




            int flag = CfgFn.GetNoNullInt32(R["flag"]);
            bool ispieceacquire = ((flag & 4) != 0);
            if (ispieceacquire) {
                if (gridBene.Tag.ToString() != "asset.accessorio.accessorio") {
                    gridBene.Tag = "asset.accessorio.accessorio";
                    btnModificaBene.Tag = "edit.accessorio";
                    gridBene.TableStyles.Clear();
                    MetaData Asset = MetaData.GetMetaData(this, "asset");
                    Asset.ComputeRowsAs(DS.Tables["asset"], "accessorio");
                    Meta.myGetData.GetTemporaryValues(DS.asset);
                    HelpForm.SetDataGrid(gridBene, DS.asset);

                }
            }
            else {
                if (gridBene.Tag.ToString() != "asset.dettaglio.dettaglio") {
                    gridBene.Tag = "asset.dettaglio.dettaglio";
                    btnModificaBene.Tag = "edit.dettaglio";
                    gridBene.TableStyles.Clear();
                    MetaData Asset = MetaData.GetMetaData(this, "asset");
                    Asset.ComputeRowsAs(DS.Tables["asset"], "dettaglio");
                    Meta.myGetData.GetTemporaryValues(DS.asset);
                    HelpForm.SetDataGrid(gridBene, DS.asset);
                }
            }
            int nassetacquire = CfgFn.GetNoNullInt32(R["nassetacquire"]);
            int newquantita = DS.asset.Select("nassetacquire=" + nassetacquire).Length;
            int oldquantita = CfgFn.GetNoNullInt32(R["number"]);
            if (newquantita != oldquantita) R["number"] = newquantita;

        }


        public void MetaData_AfterFill() {
            if (Meta.EditMode) WarningDaVisualizzare = true;
            ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            try {
                DataView dv = ((CurrencyManager)this.BindingContext[gridBene.DataSource,
                    gridBene.DataMember]).List as DataView;
                string sort = dv.Sort;
                if (sort == null || sort == "") sort = "!ninventory asc";
                if (Meta.FirstFillForThisRow) dv.Sort = sort;
            }
            catch {
            }

            DataRow Curr = DS.assetacquire.Rows[0];
            object idlist = Curr["idlist"];
            if (idlist != DBNull.Value) {
                var rList= DS.listview.get(Meta.Conn, q.eq("idlist", idlist));
                if (rList.Length>0) {
                    riempiOggetti(rList[0]);
                }
            }


            if (chkIspieceAcquire.Checked)
                btnNumInventario.Enabled = true;
            else
                btnNumInventario.Enabled = false;

            chkIspieceAcquire.Enabled = Meta.InsertMode;

            Meta.MarkTableAsNotEntityChild(DS.asset);
            Meta.MarkTableAsNotEntityChild(DS.assetlocation);
            Meta.MarkTableAsNotEntityChild(DS.assetmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetsubmanager);

            if (Meta.EditMode && chkIspieceAcquire.Checked) {
                grpInventario.Enabled = false;
            }
            else {
                grpInventario.Enabled = true;
            }

            if (Meta.InsertMode && Meta.FirstFillForThisRow && chkIspieceAcquire.Checked)
                txtNumIniz.Text = "";

            if (chkIspieceAcquire.Checked) {
                //Meta.MarkTableAsNotEntityChild(DS.asset);
                chkAuto.Visible = false;
            }
            else {
                //Meta.UnMarkTableAsNotEntityChild(DS.asset);
                chkAuto.Visible = true;
            }

            AbilitaBenePosseduto(false);
            AbilitaBuonoInventario(false);

            if (Meta.InsertMode) {
                AbilitaRigaOrdine(radioNuovo.Checked);
                AbilitaTipoCarico(true);
            }
            else {
                int flag = CfgFn.GetNoNullInt32(Curr["flag"]);
                bool loadkind_N = ((flag & 2) == 0);
                bool loadkind_R = ((flag & 2) != 0);
                if (loadkind_R) {
                    AbilitaRigaOrdine(false);
                    AbilitaTipoCarico(true);
                }
                if (loadkind_N && (Curr["idassetload"] == DBNull.Value)) {
                    AbilitaRigaOrdine(true);
                    AbilitaTipoCarico(true);
                }
                if (loadkind_N && (Curr["idassetload"] != DBNull.Value)) {
                    AbilitaRigaOrdine(true);
                    AbilitaTipoCarico(false);
                }

                //AbilitaRigaOrdine(false);
                //AbilitaBenePosseduto(false);
                //AbilitaBuonoInventario(false);

                if (Meta.EditMode && DS.mandate.Rows.Count > 0)
                    AbilitaCredDeb(false);
                else
                    AbilitaCredDeb(true);

                if (chkIspieceAcquire.Checked) {
                    m_LastCodiceInventario = DS.assetacquire.Rows[0]["idinventory"];
                    m_LastNumIniz = "";
                    if (DS.asset.Rows.Count > 0) {
                        int Nxx = CfgFn.GetNoNullInt32(DS.asset.Compute("min(!ninventory)", null));
                        m_LastNumIniz = Nxx.ToString();
                        //DS.asset.Rows[0]["!ninventory"].ToString();
                    }
                    txtNumIniz.Text = m_LastNumIniz;
                }
                else {
                    if (DS.asset.Rows.Count > 0) {
                        int Nxx = CfgFn.GetNoNullInt32(DS.asset.Compute("min(ninventory)", null));
                        m_LastNumIniz = Nxx.ToString();
                        txtNumIniz.Text = m_LastNumIniz;
                        //DS.asset.Rows[0]["!ninventory"].ToString();
                    }
                }

            }

            //AbilitaTipoCarico(Meta.InsertMode);
            //in fase di inserimento il check autonumerazione è abilitato se il radiobutton
            //nuova acquisizione è true e se il check stesso è true oppure se non è a true
            //ma è abilitato il textbox num. iniziale
            if (!chkIspieceAcquire.Checked) {
                bool valore = Meta.InsertMode && radioNuovo.Checked;
                AbilitaAutoNumerazione(valore);
                ImpostaAutoIncrementoNumInventario(Meta.InsertMode && chkAuto.Checked && chkAuto.Enabled);
            }
            else {

                if (txtQuantita.Text != "") {
                    int quantita = CfgFn.GetNoNullInt32(txtQuantita.Text);
                    if (Meta.InsertMode && Meta.FirstFillForThisRow && quantita != 0)
                        AggiornaRigheParteNonInv(quantita, 0, false);
                }
            }

            CalcolaTotali(false, false); //Nino:: cambiato, prima era TRUE!!!

            //Rusciano G. 09.03.2005 - Inserita qui e non nel metadato perché questa valorizzazione deve
            //avvenire in una fase di NON inserimento
            int start = CfgFn.GetNoNullInt32(txtNumIniz.Text);
            if (!Meta.InsertMode && !chkIspieceAcquire.Checked && start > 0) {
                foreach (DataRow r in DS.asset.Rows) {
                    // Se la riga è stata rimossa non ha senso assegnare il numero inventario
                    if (r.RowState != DataRowState.Deleted) {
                        r["!ninventory"] = r["ninventory"];
                    }
                }
            }

            if (Meta.InsertMode && Meta.FirstFillForThisRow && chkAuto.Checked == false) {
                DataRow R = DS.assetacquire.Rows[0];
                int flag = CfgFn.GetNoNullInt32(R["flag"]);
                bool piece_acquire = ((flag & 4) != 0);
                if (!piece_acquire) {
                    chkAuto.Checked = true;
                    DoAutoCheck();
                }
            }
            DisabilitaFattura(false);
            if (Curr["idmankind"] != DBNull.Value) {
                radioPosseduto.Enabled = false;
            }
            else {
                radioPosseduto.Enabled = true;
            }
        }


        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (T.TableName == "inventory" &&
                (Meta.IsEmpty == false) &&
                (Meta.FirstFillForThisRow == false)
                && chkIspieceAcquire.Checked) {
                AbilitaDettaglio(R != null);
                AbilitaNumIniziale(R != null);
                if (R == null) {
                    txtNumIniz.Text = "";
                    m_LastNumIniz = "";
                    m_LastCodiceInventario = DBNull.Value;
                    //aggiorno le righe figlie annullando il valore 
                    //di codiceinventario e numinventario
                    ScollegaBeniInv();
                }
                else {
                    //se ho selezionato la stessa riga non faccio nulla
                    if (m_LastCodiceInventario != R["idinventory"]) {
                        //annullo il numero iniziale
                        txtNumIniz.Text = "";
                        m_LastNumIniz = "";
                        m_LastCodiceInventario = R["idinventory"];
                        //aggiorno le righe figlie con il nuovo codiceinventario 
                        //e annullando il numeroinventario
                        ScollegaBeniInv(m_LastCodiceInventario);
                    }
                }
            }

            if (T.TableName == "mandatekind" && (!Meta.IsEmpty) &&  (!Meta.FirstFillForThisRow)) {
                if (!Meta.DrawStateIsDone)
                    return;
                DataRow Curr = DS.assetacquire.Rows[0];
                if (R == null) {
                    txtEsercordine.Text = "";
                    txtNumordine.Text = "";
                    txtNumriga.Text = "";
                    txtEsercFattura.Text = "";
                    txtNumFattura.Text = "";
                    txtNumRigaFattura.Text = "";
                    cmbTipoFattura.SelectedIndex = -1;
                    Curr["yman"] = DBNull.Value;
                    Curr["nman"] = DBNull.Value;
                    Curr["rownum"] = DBNull.Value;
                    Curr["idinvkind"] = DBNull.Value;
                    Curr["yinv"] = DBNull.Value;
                    Curr["ninv"] = DBNull.Value;
                    Curr["invrownum"] = DBNull.Value;
                }
                else {
                    if (m_LastTipoCP != R["idmankind"]) {
                        txtEsercordine.Text = "";
                        txtNumordine.Text = "";
                        txtNumriga.Text = "";
                        txtEsercFattura.Text = "";
                        txtNumFattura.Text = "";
                        txtNumRigaFattura.Text = "";
                        cmbTipoFattura.SelectedIndex = -1;
                        Curr["yman"] = DBNull.Value;
                        Curr["nman"] = DBNull.Value;
                        Curr["rownum"] = DBNull.Value;
                        Curr["idinvkind"] = DBNull.Value;
                        Curr["yinv"] = DBNull.Value;
                        Curr["ninv"] = DBNull.Value;
                        Curr["invrownum"] = DBNull.Value;
                        m_LastTipoCP = R["idmankind"];
                    }
                }
            }
        }


        private void AbilitaDettaglio(bool enable) {
            btnModificaBene.Enabled = enable;
            if (chkIspieceAcquire.Checked) {
                string TagDetail = "asset.accessorio";
                gridBene.Tag = TagDetail;
                if (enable) gridBene.Tag = TagDetail + ".accessorio";
            }
            else {
                string TagDetail = "asset.dettaglio";
                gridBene.Tag = TagDetail;
                if (enable) gridBene.Tag = TagDetail + ".dettaglio";
            }
        }

        CQueryHelper QHC;
        QueryHelper QHS;
        private DataAccess Conn;

        public void DisabilitaFattura(bool enable) {
            grpRigaFattura.Enabled = enable;
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            //GetData.CacheTable(DS.manager);
            //GetData.CacheTable(DS.location);
            //HelpForm.SetDenyNull(DS.assetacquire.Columns["ispieceacquire"],true);
            
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["assetacquireassetusage"], QHC.BitClear("flag", 2));
            //QHC.CmpEq("ispieceacquire","N"));
            this.txtNumriga.Leave += txtNumriga_Leave;
            this.txtListino.Leave += txtListino_Leave;
            this.txtQuantita.LostFocus += txtQuantita_LostFocus;
            this.txtNumIniz.LostFocus += txtNumIniz_LostFocus;

            QueryCreator.SetRelationActivationFilter(DS.Relations["asset_assetmanager"], QHC.CmpEq("idpiece", 1));
            QueryCreator.SetRelationActivationFilter(DS.Relations["asset_assetlocation"], QHC.CmpEq("idpiece", 1));
            QueryCreator.SetRelationActivationFilter(DS.Relations["asset_assetsubmanager"], QHC.CmpEq("idpiece", 1));
            GetData.SetStaticFilter(DS.assetview1, QHS.CmpEq("idpiece", 1));
            GetData.SetSorting(DS.asset, "idasset asc,idpiece asc");
            GetData.SetSorting(DS.assetview1, "ninventory asc");
            DataAccess.SetTableForReading(DS.assetview1, "assetview");
            DataAccess.SetTableForReading(DS.submanager, "manager");
            string filter = "(ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")";
            GetData.CacheTable(DS.config, filter, null, false);
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");

            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
                filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);


                if (idsorkind1.ToString() + idsorkind2.ToString() + idsorkind3.ToString() == "") {
                    grpAnalitico.Visible = false;
                }
            }

        }

        
    
        private List<infoMailOld> oldRespInfo= new List<infoMailOld>();
        private List<infoMailNew> newRespInfo= new List<infoMailNew>();

        private List<infoMailOld> oldSubRespInfo = new List<infoMailOld>();
        private List<infoMailNew> newSubRespInfo = new List<infoMailNew>();

        
        public struct infoMailOld {
            public DataRow RAssetManager;
            public int OldManager;
            public int NewManager;
        }
        public struct infoMailNew {
            public DataRow RAssetManager;
            public int NewManager;
        }

        public void PredisponiInvioMailResponsabili() {
            newRespInfo.Clear();
            oldRespInfo.Clear();
            
            //Responsabili con data inizio null
            foreach (DataRow R in DS.assetmanager.Select(QHC.IsNull("start"))) {
                int currentIdman = CfgFn.GetNoNullInt32(R["idman"]);
                if (R.RowState == DataRowState.Added) {
                    //Solo mail a nuovo responsabile, non c'è un precedente
                    newRespInfo.Add(new infoMailNew() {NewManager= currentIdman, RAssetManager = R});
                }

                if (R.RowState == DataRowState.Modified) {
                    int originalIdman = CfgFn.GetNoNullInt32(R["idman", DataRowVersion.Original]);
                 
                    if (currentIdman != originalIdman) {
                        if (originalIdman != 0) {
                            //mail a vecchio e a nuovo
                            oldRespInfo.Add(new infoMailOld() { NewManager = currentIdman, RAssetManager = R, OldManager = originalIdman });                            
                        }
                        else { //solo nuovo
                            newRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R });
                        }
                    }
                }
            }

            //Quando aggiungo il resp. con start valorizzato, invio la mail a quello con start valorizzato, ed al precedente calcolato sulla base di idassetmanager

            //Responsabile (new) con data inizio valorizzato
            foreach (DataRow R in DS.assetmanager.Select(QHC.IsNotNull("start"), "start desc")) {
                int currentIdman = CfgFn.GetNoNullInt32(R["idman"]);
                if (R.RowState == DataRowState.Added) { //nuova riga 
                    DataRow[] rowsAssetmanagerPrec =
                        DS.assetmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),QHC.CmpNe("idassetmanager", R["idassetmanager"])), "idassetmanager desc");
                    if (rowsAssetmanagerPrec.Length > 0) { 
                        //c'è un resp. precedente, invia la mail al resp. prec e anche al nuovo
                        int oldidman = CfgFn.GetNoNullInt32(rowsAssetmanagerPrec[0]["idman"]);
                        oldRespInfo.Add(new infoMailOld() { NewManager = currentIdman, RAssetManager = R, OldManager = oldidman });
                    }
                    else {
                        //invia la mail solo al nuovo resp
                        newRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R });

                    }
                }

                if (R.RowState == DataRowState.Modified) {
                    //in questo caso il resp. precedente lo consideriamo il valore precedente della riga
                    int oldidman = CfgFn.GetNoNullInt32(R["idman", DataRowVersion.Original]);
                    if (currentIdman != oldidman) {
                        if (oldidman != 0) { //vecchio e nuovo
                            oldRespInfo.Add(new infoMailOld() {
                                NewManager = currentIdman,
                                RAssetManager = R,
                                OldManager = oldidman
                            });
                        }
                        else {//solo nuovo
                            newRespInfo.Add(new infoMailNew() {
                                NewManager = currentIdman,
                                RAssetManager = R
                            });
                        }
                    }
                }
            }
        }


        public void PredisponiInvioMailSubconsegnatari() {
            // Subconsegnatario con data inizio null
            newSubRespInfo.Clear();
            oldSubRespInfo.Clear();
            //Subconsegnatario con data inizio null
            foreach (DataRow R in DS.assetsubmanager.Select(QHC.IsNull("start"))) {
                int currentIdman = CfgFn.GetNoNullInt32(R["idmanager"]);
                if (R.RowState == DataRowState.Added) {
                    //Solo mail a nuovo responsabile, non c'è un precedente
                    newSubRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R });
                }

                if (R.RowState == DataRowState.Modified) {
                    int originalIdman = CfgFn.GetNoNullInt32(R["idmanager", DataRowVersion.Original]);

                    if (currentIdman != originalIdman) {
                        //mail a vecchio e a nuovo
                        if (originalIdman != 0) {
                            oldSubRespInfo.Add(new infoMailOld() { NewManager = currentIdman, RAssetManager = R, OldManager = originalIdman });
                        }
                        else {
                            newSubRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R});
                        }
                    }
                }
                
            }

            //Quando aggiungo il Subconsegnatario con start valorizzato, invio la mail a quello con start valorizzato, ed al precedente calcolato sulla base di idassetmanager

            //Subconsegnatario (new) con data inizio valorizzato
            foreach (DataRow R in DS.assetsubmanager.Select(QHC.IsNotNull("start"), "start desc")) {
                int currentIdman = CfgFn.GetNoNullInt32(R["idmanager"]);
                if (R.RowState == DataRowState.Added) { //nuova riga 
                    DataRow[] rowsAssetSubmanagerPrec =
                        DS.assetsubmanager.Select(                        
                            QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]), QHC.CmpNe("idassetsubmanager", R["idassetsubmanager"])), "idassetsubmanager desc");
                    if (rowsAssetSubmanagerPrec.Length > 0) {
                        //c'è un resp. precedente, invia la mail al resp. prec
                        int oldidman = CfgFn.GetNoNullInt32(rowsAssetSubmanagerPrec[0]["idmanager"]);
                        oldSubRespInfo.Add(new infoMailOld() { NewManager = currentIdman, RAssetManager = R, OldManager = oldidman });
                    }
                    else {
                        //invia la mail al nuovo resp
                        newSubRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R });
                    }
                    
                }

                if (R.RowState == DataRowState.Modified) {
                    //in questo caso il resp. precedente lo consideriamo il valore precedente della riga
                    int oldidman = CfgFn.GetNoNullInt32(R["idmanager", DataRowVersion.Original]);
                    if (currentIdman != oldidman) {
                        if (oldidman != 0) {
                            //vecchio e nuovo
                            oldSubRespInfo.Add(new infoMailOld() {
                                NewManager = currentIdman,
                                RAssetManager = R,
                                OldManager = oldidman
                            });
                        }
                        else {
                            newSubRespInfo.Add(new infoMailNew() { NewManager = currentIdman, RAssetManager = R });
                        }

                        
                    }
                }
                
                
            }

        }

        public void MetaData_AfterActivation() {
            btnCopiaBene.BackColor = formcolors.GridButtonBackColor();
            btnCopiaBene.ForeColor = formcolors.GridButtonForeColor();
        }

        public void AggiornaInventarioAsset() {
            if (DS.asset.Rows.Count == 0) return;
            if (DS.assetacquire.Rows.Count == 0) return;
            DataRow Curr = DS.assetacquire.Rows[0];
            foreach (DataRow rAsset in DS.asset.Select()) {
                rAsset["idinventory"] = Curr["idinventory"];
            }
        }

        public void AggiornaUbicazioneCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            foreach (DataRow Curr in DS.asset.Select()) {
                DataRow[] RAssetLoc = DS.assetlocation.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
                if (RAssetLoc.Length > 0) {
                    DataRow R = RAssetLoc[0];
                    Curr["idcurrlocation"] = R["idlocation"];
                }
                else
                    Curr["idcurrlocation"] = DBNull.Value;
        }
        }

        public void AggiornaResponsabileCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            foreach (DataRow Curr in DS.asset.Select()) {
                DataRow[] RAssetMan = DS.assetmanager.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
                if (RAssetMan.Length > 0) {
                    DataRow R = RAssetMan[0];
                    Curr["idcurrman"] = R["idman"];
                }
                else
                    Curr["idcurrman"] = DBNull.Value;
            }
        }

        public void AggiornaSubconsegnatarioCorrente() {
            if (DS.asset.Rows.Count == 0) return;
            foreach (DataRow Curr in DS.asset.Select()) {
                DataRow[] RAssetSubMan = DS.assetsubmanager.Select(QHC.CmpEq("idasset", Curr["idasset"]), "start desc");
                if (RAssetSubMan.Length > 0) {
                    DataRow R = RAssetSubMan[0];
                    Curr["idcurrsubman"] = R["idmanager"];
                }
                else
                    Curr["idcurrsubman"] = DBNull.Value;
            }
        }


        public void MetaData_BeforePost() {
            if (DS.assetacquire.Rows.Count == 0) {
                DS.asset.Clear();
                return; //Insert/Cancel sequence
            }
            DataRow R = DS.assetacquire.Rows[0];
            if (R.RowState == DataRowState.Deleted) {
                foreach (DataRow A in DS.assetlocation.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
                foreach (DataRow A in DS.assetmanager.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
                foreach (DataRow A in DS.assetsubmanager.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
                foreach (DataRow A in DS.asset.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
            }

            // Gestisce cambi di responsabile o subconsegnatario 
            AggiornaUbicazioneCorrente();
            AggiornaResponsabileCorrente();
            AggiornaSubconsegnatarioCorrente();
            AggiornaInventarioAsset();
           //  e predispone l' Invio delle mail ai soggetti interessati
            PredisponiInvioMailResponsabili();
            PredisponiInvioMailSubconsegnatari();
        }

        public void ScriviEInviaMail() {
            if (DS.assetacquire.Rows.Count == 0) return;
            //Invia la mail al nuovo responsabile
            foreach (infoMailNew info in newRespInfo) {
                int idasset = CfgFn.GetNoNullInt32(info.RAssetManager["idasset"]);
                object newidman = info.NewManager;
                DataTable T = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (T == null || T.Rows.Count == 0) continue;
                string mailto = T.Rows[0]["email"].ToString();
                if (mailto == "") continue;
                string MsgBody = "Si comunica che il cespite N. " + idasset + ", \r\n";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    string nInventory = Rassetview["ninventory"].ToString();
                    MsgBody = "Si comunica che il cespite di inventario N. " + nInventory + " (n. cespite " + idasset + "), \r\n";
                    MsgBody = MsgBody + "Inventario " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Class. inventariale " + Rassetview["inventorytree"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "è stato assegnato al Responsabile " + T.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";

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

            //Invia la mail al nuovo Subconsegnatario
            foreach (infoMailNew info in newSubRespInfo) {
                int idasset = CfgFn.GetNoNullInt32(info.RAssetManager["idasset"]);
                object newidman = info.NewManager;
                DataTable T = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                if (T == null || T.Rows.Count == 0) continue;
                string mailto = T.Rows[0]["email"].ToString();
                if (mailto == "") continue;
                string MsgBody = "Si comunica che il cespite N. " + idasset + ", \r\n";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    string nInventory = Rassetview["ninventory"].ToString();
                    MsgBody = "Si comunica che il cespite di inventario N. " + nInventory + " (n. cespite " + idasset +
                              "), \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Class. inventariale " + Rassetview["inventorytree"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + "è stato assegnato al Subconsegnatario :" + T.Rows[0]["title"] + ".\r\n\r\n";
                MsgBody = MsgBody + "Cordiali saluti.\r\n";
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

            //Invia la mail al vecchio e nuovo responsabile
            foreach (infoMailOld info in oldRespInfo) {
                int idasset = CfgFn.GetNoNullInt32(info.RAssetManager["idasset"]);
                int oldidman = info.OldManager;
                int newidman = info.NewManager;
                // Trovare l'indirizzo e-mail del responsabile mediante idman
                DataTable Told = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", oldidman), null, false);
                if (Told == null || Told.Rows.Count == 0) continue;
                string mailto = Told.Rows[0]["email"].ToString();
                if (mailto == "") continue;

                string newResponsabile;
                DataTable Tnew = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);                
                if (Tnew == null || Tnew.Rows.Count == 0) {
                    newResponsabile = "non ha più un responsabile collegato.\r\n\r\n";
                }
                else {
                    newResponsabile = "è stato assegnato al Responsabile: " + Tnew.Rows[0]["title"] + ".\r\n\r\n";
                }
                string MsgBody = "Si comunica che il cespite N. " + idasset + ", \r\n";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    string nInventory = Rassetview["ninventory"].ToString();
                    MsgBody = "Si comunica che il cespite di inventario N. " + nInventory + " (n. cespite " + idasset +
                              "), \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + newResponsabile;
                MsgBody = MsgBody + "Cordiali saluti.\r\n";

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


            //Invia la mail al vecchio e nuovo Subconsegnatario
            foreach (infoMailOld info in oldSubRespInfo) {
                int idasset = CfgFn.GetNoNullInt32(info.RAssetManager["idasset"]);
                int oldidman = info.OldManager;
                int newidman = info.NewManager;
                // Trovare l'indirizzo e-mail del Subconsegnatario mediante idman
                DataTable Told = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", oldidman), null, false);
                if (Told == null || Told.Rows.Count == 0) continue;
                string mailto = Told.Rows[0]["email"].ToString();
                if (mailto == "") continue;
                DataTable Tnew = null;

                Tnew = Conn.RUN_SELECT("manager", "*", null, QHS.CmpEq("idman", newidman), null, false);
                
                string newResponsabile;
                if (Tnew == null || Tnew.Rows.Count == 0) {
                    newResponsabile = "non ha più un Subconsegnatario collegato.\r\n\r\n";
                }
                else {
                    newResponsabile = "è stato assegnato al Subconsegnatario: " + Tnew.Rows[0]["title"] + ".\r\n\r\n";
                }

                string MsgBody = "Si comunica che il cespite N. " + idasset + ", \r\n";
                DataTable Tassetview = Meta.Conn.RUN_SELECT("assetview", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idasset", idasset), QHS.CmpEq("idpiece", 1)), null, true);
                if (Tassetview.Rows.Count > 0) {
                    DataRow Rassetview = Tassetview.Rows[0];
                    string nInventory = Rassetview["ninventory"].ToString();
                    MsgBody = "Si comunica che il cespite di inventario N. " + nInventory + " (n. cespite " + idasset +
                              "), \r\n";
                    MsgBody = MsgBody + "Inventario: " + Rassetview["inventory"] + ", \r\n"
                              + "Ente inventariale: " + Rassetview["inventoryagency"] + ", \r\n"
                              + "Descrizione: " + Rassetview["description"] + ", \r\n";
                }
                MsgBody = MsgBody + newResponsabile;
                MsgBody = MsgBody + "Cordiali saluti.\r\n";

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
            newSubRespInfo.Clear();
            oldSubRespInfo.Clear();
            newRespInfo.Clear();
            oldRespInfo.Clear();
        }

        public void MetaData_AfterPost() {
            ScriviEInviaMail();
            //se non sono in inserimento non faccio nulla
            if (!Meta.InsertMode) return;
            //se non ci sono righe (ad es. clicco annulla in fase di inserimento)
            if (DS.assetacquire.Rows.Count < 1) return;
            //aggiorno il num. iniziale di assetacquire, solo per un cespite NON posseduto
            // questo non deve accadere per gli accessori.
            if (chkAuto.Checked && chkAuto.Enabled) {
                int quantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);
                if (quantita > 0) {
                    if (chkIspieceAcquire.Checked) {
                        DataRow[] rows = DS.asset.Select(null, "!ninventory ASC");
                        DS.assetacquire.Rows[0]["startnumber"] = CfgFn.GetNoNullInt32(rows[0]["!ninventory"]);
                    }
                    else {
                        DataRow[] rows = DS.asset.Select(null, "ninventory ASC");
                        DS.assetacquire.Rows[0]["startnumber"] = CfgFn.GetNoNullInt32(rows[0]["ninventory"]);
                    }
                }
                else {
                    DS.assetacquire.Rows[0]["startnumber"] = GetMAXNumInventario();
                }
                //PostData pd = Meta.Get_PostData();
                //pd.InitClass(DS, Meta.Conn);
                //if (pd.DO_POST()) {
                //    DS.AcceptChanges();
                //    Meta.FreshForm();
                //} task 5684
                string script = "update assetacquire set startnumber = " +
                                QHS.quote(DS.assetacquire.Rows[0]["startnumber"]) + " where "
                                + QHS.CmpEq("nassetacquire", DS.assetacquire.Rows[0]["nassetacquire"]);
                Meta.Conn.SQLRunner(script);
                DS.AcceptChanges();
                Meta.FreshForm();
            }
        }


        private void txtImponibile_TextChanged(object sender, System.EventArgs e) {
        }


        private void txtImposta_TextChanged(object sender, System.EventArgs e) {
        }


        private void txtSconto_TextChanged(object sender, System.EventArgs e) {
        }



        /// <summary>
        /// fa un controllo sul valore della quantità, e se ok aggiorna righe e totali
        /// </summary>
        private void ControlloQuantita() {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;

            //leggo il valore quantita
            int quantita = 0;
            quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(quantita.GetType(), txtQuantita.Text, null));
            if (quantita <= 0) {
                MessageBox.Show("Inserire una quantità maggiore o uguale a zero", "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HelpForm.FocusControl(txtQuantita);
                //txtQuantita.Focus();
                return;
            }

            int oldquantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);

            MetaData.GetFormData(this, true);

            //Calcolo i totali solo ad aggiornamento avvenuto
            if (chkIspieceAcquire.Checked) {
                if (AggiornaRigheParteNonInv(quantita, oldquantita, true))
                    CalcolaTotali(false, true);

            }
            else {
                if (AggiornaRigheBeneInv(quantita, oldquantita))
                    CalcolaTotali(false, true);
            }
        }


        bool InsideControlloQuantita = false;

        private void txtQuantita_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (InsideControlloQuantita) return;
            InsideControlloQuantita = true;
            try {
                ControlloQuantita();
            }
            catch {
            }
            InsideControlloQuantita = false;
        }



        private void txtQuantita_TextChanged(object sender, System.EventArgs e) {
        }

        /// <summary>
        /// Imposta i default di una riga di asset quando essa viene
        /// riportata nello stato CURRENT
        /// </summary>
        /// <param name="r"></param>
        private void ImpostaDefaultBeneInv(DataRow r) {
            foreach (DataColumn C in DS.asset.Columns) {
                if (C.ColumnName == "idasset" ||
                    C.ColumnName == "nassetacquire" ||
                    C.ColumnName == "ninventory" ||
                    C.ColumnName == "!numeroriga" ||
                    C.ColumnName == "!ninventory" ||
                    //C.ColumnName == "idinventory" ||
                    C.ColumnName == "cu" ||
                    C.ColumnName == "ct" ||
                    C.ColumnName == "lu" ||
                    C.ColumnName == "lt") continue;
                r[C.ColumnName] = C.DefaultValue;
            }
        }


        private bool AggiornaRigheParteNonInv(int quantita, int oldquantita, bool CollegaRighe) {
            //può capitare ad esempio quando si seleziona una riga ordine che ha
            //una quantità ordinata < caricata
            if (oldquantita < 0 || quantita < 0) return false;
            if (quantita == oldquantita) return false;

            if (oldquantita < quantita) {
                //aggiungo righe
                bool Aggiorna = CollegaRighe;
                if (CollegaRighe) {
                    if (!EseguiCheckInv(m_LastCodiceInventario, m_LastNumIniz, quantita)) {
                        Aggiorna = false;
                    }
                }

                DataTable BeneInvView = null;
                BeneInvView = GetBeneInvRows(m_LastCodiceInventario,
                    CfgFn.GetNoNullInt32(m_LastNumIniz), CfgFn.GetNoNullInt32(quantita));


                MetaData M = MetaData.GetMetaData(this, "asset");

                DataRow[] righeCurrent = DS.asset.Select(null, "!ninventory asc", DataViewRowState.CurrentRows);
                DataRow[] righeDeleted = DS.asset.Select(null, "idasset ASC,idpiece ASC", DataViewRowState.Deleted);
                int nrCurrent = righeCurrent.Length;
                int nrDeleted = righeDeleted.Length;

                for (int i = 0; i < quantita; i++) {
                    DataRow CurrAsset = null;
                    if (BeneInvView.Rows.Count > i) CurrAsset = BeneInvView.Rows[i];

                    //riga esistente, la aggiorno 
                    if (i < nrCurrent) {
                        DataRow r = righeCurrent[i];
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                        r["!numeroriga"] = i + 1;
                        if (CollegaRighe && CurrAsset != null) {
                            if (r["idasset"].ToString() != CurrAsset["idasset"].ToString()) {
                                ImpostaRigaParteNonInv(r, CfgFn.GetNoNullInt32(CurrAsset["idasset"]), r["!numeroriga"],
                                    CurrAsset["ninventory"].ToString(), m_LastCodiceInventario,
                                    CurrAsset["description"].ToString());
                            }
                        }
                        continue;
                    }
                    //riga cancellata da riproporre aggiornata
                    if (i >= nrCurrent && i < nrCurrent + nrDeleted) {
                        DataRow r = righeDeleted[i - nrCurrent];
                        r.RejectChanges();
                        ImpostaDefaultParteNonInv(r);
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                        r["!numeroriga"] = i + 1;
                        if (CollegaRighe && CurrAsset != null) {
                            if (r["idasset"].ToString() != CurrAsset["idasset"].ToString()) {
                                ImpostaRigaParteNonInv(r, CfgFn.GetNoNullInt32(CurrAsset["idasset"]), r["!numeroriga"],
                                    CurrAsset["ninventory"].ToString(), m_LastCodiceInventario,
                                    CurrAsset["description"].ToString());
                            }
                        }
                        continue;
                    }
                    //riga nuova
                    HelpForm.SetDenyNull(DS.asset.Columns["idasset"], false);
                    if (CollegaRighe && CurrAsset != null) {
                        MetaData.SetDefault(DS.asset, "idasset", CurrAsset["idasset"]);
                    }
                    else {
                        MetaData.SetDefault(DS.asset, "idasset", -666);
                    }
                    M.SetDefaults(DS.asset);
                    DataRow row = M.Get_New_Row(DS.assetacquire.Rows[0], DS.asset);
                    row["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                    row["!numeroriga"] = i + 1;
                    if (CollegaRighe && CurrAsset != null) {
                        ImpostaRigaParteNonInv(row, CfgFn.GetNoNullInt32(CurrAsset["idasset"]), row["!numeroriga"],
                            CurrAsset["ninventory"].ToString(), m_LastCodiceInventario,
                            CurrAsset["description"].ToString());
                    }

                }

                if (CollegaRighe) {
                    //if (!Aggiorna)	ScollegaBeniInv(m_LastCodiceInventario);
                }
            }
            else {
                //Se sono in modalità inserimento non faccio visualizzare nessun msg
                if (Meta.EditMode) {
                    string msg = "La diminuizione della quantità di aumenti di valore " +
                                 "produrrà la cancellazione di aumenti di valore dall'inventario. Continuare?";
                    DialogResult res = MessageBox.Show(msg, "Conferma",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes) {
                        //rimetto a quantità il vecchio valore
                        DS.assetacquire.Rows[0]["number"] = oldquantita;
                        Meta.FreshForm();
                        HelpForm.FocusControl(txtQuantita);
                        //txtQuantita.Focus();
                        return false;
                    }
                }
                int ntodel = oldquantita - quantita;
                //elimino righe in differenza tra oldquantita e quantita
                foreach (DataRow RD in DS.asset.Select("!ninventory is null")) {
                    if (ntodel == 0) break;
                    ntodel--;
                    RD.Delete();
                }

                foreach (DataRow RD in DS.asset.Select(null, "!ninventory DESC")) {
                    if (ntodel == 0) break;
                    ntodel--;
                    RD.Delete();
                }
                //				for(int i = oldquantita; i > quantita; i--) {
                //					DataRow[] r = DS.asset.Select("!numeroriga="+i+);
                //					if (r.Length > 0) r[0].Delete();
                //				}
            }
            return true;
        }


        /// <summary>
        /// Imposta i default di una riga di partenoninventariabile quando essa viene
        /// riportata nello stato CURRENT
        /// </summary>
        /// <param name="r"></param>
        private void ImpostaDefaultParteNonInv(DataRow r) {
            foreach (DataColumn C in DS.asset.Columns) {
                if (C.ColumnName == "idpiece" ||
                    C.ColumnName == "idasset" ||
                    C.ColumnName == "!numeroriga" ||
                    C.ColumnName == "!ninventory" ||
                    //C.ColumnName == "!idinventory"||
                    C.ColumnName == "!description" ||
                    C.ColumnName == "cu" ||
                    C.ColumnName == "ct" ||
                    C.ColumnName == "lu" ||
                    C.ColumnName == "lt") continue;
                r[C.ColumnName] = C.DefaultValue;
            }
        }

        /// <summary>
        /// Aggiorna le righe di asset in base al numero della quantita
        /// Se sono in modalità inserimento non viene effettuato il controllo
        /// sulla diminuizione della quantità
        /// </summary>
        /// <param name="quantita">nuovo valore</param>
        /// <param name="oldquantita">vecchio valore</param>
        private bool AggiornaRigheBeneInv(int quantita, int oldquantita) {
            //può capitare ad esempio quando si seleziona una riga ordine che ha
            //una quantità ordinata < caricata
            if (oldquantita < 0 || quantita < 0) return false;

            //			if (quantita==oldquantita) return false;
            Meta.GetFormData(true);

            if (oldquantita <= quantita) {
                //aggiungo righe

                MetaData M = MetaData.GetMetaData(this, "asset");

                DataRow[] righeCurrent = DS.asset.Select(null, "!ninventory ASC", DataViewRowState.CurrentRows);
                DataRow[] righeDeleted = DS.asset.Select(null, "!ninventory ASC", DataViewRowState.Deleted);

                int nrCurrent = righeCurrent.Length;
                int nrDeleted = righeDeleted.Length;

                bool NumAutomatica = chkAuto.Enabled && chkAuto.Checked;

                //calcolo num. iniziale
                int numiniziale = 0;
                if (!NumAutomatica) {
                    numiniziale = CfgFn.GetNoNullInt32(txtNumIniz.Text);
                }
                else {
                    numiniziale = GetMAXNumInventario();
                }

                for (int i = 0; i < quantita; i++) {
                    //riga esistente da aggiornare
                    if (i < nrCurrent) {
                        DataRow r = righeCurrent[i];
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                        r["ninventory"] = numiniziale + i;
                        if (NumAutomatica || numiniziale == 0)
                            r["!ninventory"] = DBNull.Value; //""
                        else
                            r["!ninventory"] = r["ninventory"];
                        r["!numeroriga"] = i + 1;
                        continue;
                    }
                    //riga cancellata da riproporre aggiornata
                    if (i >= nrCurrent && i < nrCurrent + nrDeleted) {
                        DataRow r = righeDeleted[i - nrCurrent];
                        r.RejectChanges();
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                        r["ninventory"] = numiniziale + i;
                        if (NumAutomatica || numiniziale == 0)
                            r["!ninventory"] = DBNull.Value; // "";
                        else
                            r["!ninventory"] = r["ninventory"];
                        r["!numeroriga"] = i + 1;
                        ImpostaDefaultBeneInv(r);
                        continue;
                    }
                    //riga nuova
                    M.SetDefaults(DS.asset);
                    MetaData.SetDefault(DS.asset, "lifestart", DS.assetacquire.Rows[0]["adate"]);

                    DataRow row = M.Get_New_Row(DS.assetacquire.Rows[0], DS.asset);
                    row["ninventory"] = numiniziale + i;
                    row["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                    if (NumAutomatica || numiniziale == 0)
                        row["!ninventory"] = DBNull.Value; // "";
                    else
                        row["!ninventory"] = row["ninventory"];
                    row["!numeroriga"] = i + 1;
                }
            }
            else {
                //Se sono in modalità inserimento non faccio visualizzare nessun msg
                if (!Meta.InsertMode) {
                    string msg = "La diminuizione della quantità di beni caricati " +
                                 "produrrà la cancellazione di cespiti dall'inventario. Continuare?";
                    DialogResult res = MessageBox.Show(msg, "Conferma",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes) {
                        //rimetto a quantità il vecchio valore
                        DS.assetacquire.Rows[0]["number"] = oldquantita;
                        Meta.FreshForm();
                        HelpForm.FocusControl(txtQuantita); //.Focus();
                        return false;
                    }
                }
                int todel = oldquantita - quantita;

                DataRow[] lista = DS.asset.Select("!ninventory is null");
                foreach (DataRow D in lista) {
                    if (todel == 0) break;
                    foreach (DataRow ManR in DS.assetmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManR.Delete();
                    }
                    foreach (DataRow SubManR in DS.assetsubmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        SubManR.Delete();
                    }
                    foreach (DataRow ManL in DS.assetlocation.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManL.Delete();
                    }
                    D.Delete();
                    todel--;
                }


                //elimino righe in differenza tra oldquantita e quantita
                lista = DS.asset.Select("!ninventory is not null", "!ninventory desc");
                foreach (DataRow D in lista) {
                    if (todel == 0) break;
                    foreach (DataRow ManR in DS.assetmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManR.Delete();
                    }
                    foreach (DataRow SubManR in DS.assetsubmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        SubManR.Delete();
                    }
                    foreach (DataRow ManL in DS.assetlocation.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManL.Delete();
                    }
                    D.Delete();
                    todel--;
                }
                //				for(int i = oldquantita; i > quantita; i--) {
                //					DataRow[] r = DS.asset.Select("!numeroriga="+i);
                //					if (r.Length > 0) r[0].Delete();
                //				}
            }
            return true;
        }

        /// <summary>
        /// Restituisce un datatable (assetview) con le righe filtrate per 
        /// codiceinventario e numinventario
        /// </summary>
        /// <param name="numinziale"></param>
        /// <param name="quantita"></param>
        /// <returns></returns>
        private DataTable GetBeneInvRows(object codiceinventario, int numiniziale, int quantita) {
            int min = numiniziale;
            int max = numiniziale + quantita - 1;
            string filter = QHS.AppAnd(QHS.CmpEq("idinventory", codiceinventario),
                QHS.CmpGe("ninventory", min), QHS.CmpLe("ninventory", max),
                QHS.CmpEq("idpiece", 1));
            DataTable T = Meta.Conn.RUN_SELECT("assetview", "*", "ninventory ASC", filter, null, true);
            //la vista serve a poter usare idinventory
            //QueryCreator.MergeDataTable(DS.assetview1,T);
            return T;
        }

        /// <summary>
        /// Legge i dati da assetview e valorizza le relative righe di assetview (degli accessori)
        /// </summary>
        private void ValorizzaParteConBene(int primapartedaaggiornare,
            object codiceinventario, string numinventario, string quantita) {
            DataTable BeneInvView = GetBeneInvRows(codiceinventario,
                CfgFn.GetNoNullInt32(numinventario), CfgFn.GetNoNullInt32(quantita));
            int n = 0;
            foreach (DataRow R in DS.asset.Select("idpiece>=" + primapartedaaggiornare, "idpiece asc")) {
                if (n < BeneInvView.Rows.Count) {
                    DataRow Rbene = BeneInvView.Rows[n];
                    ImpostaRigaParteNonInv(R, CfgFn.GetNoNullInt32(Rbene["idasset"]), R["!numeroriga"],
                        Rbene["ninventory"].ToString(), codiceinventario, Rbene["description"].ToString());
                    n++;
                }
            }
        }

        /// <summary>
        /// Valorizza il campo temporaneo codiceinventario di partenoninventariabile 
        /// e scollega eventuali righe collegate.
        /// Non aggiunge/elimina righe
        /// </summary>
        private void ScollegaBeniInv(object codiceinventario) {
            if (Meta.IsEmpty) return;
            foreach (DataRow r in DS.asset.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                ImpostaRigaParteNonInv(r, -666, r["!numeroriga"], "", codiceinventario, "");
            }
        }


        /// <summary>
        /// Si verifica quando cambia il codiceinventario o quando la combinazione codiceinventario
        /// numinventario dà esito negativo. Non aggiunge/elimina righe
        /// </summary>
        private void ScollegaBeniInv() {
            if (Meta.IsEmpty) return;
            foreach (DataRow r in DS.asset.Rows) {
                if (r.RowState == DataRowState.Deleted) continue;
                ImpostaRigaParteNonInv(r, -666, r["!numeroriga"], "", DBNull.Value, "");
            }
        }


        private void ImpostaRigaParteNonInv(DataRow rowParteInv, int idbene, object numeroriga,
            string numinventario, object codiceinventario, string descrizione) {
            int Piece = CfgFn.GetNoNullInt32(DS.asset.Compute("MAX(idpiece)", "idasset=" + idbene.ToString())) + 1;
            if (Piece <= 1) Piece = 2;

            rowParteInv.BeginEdit();
            rowParteInv["idasset"] = idbene;
            rowParteInv["idpiece"] = Piece;
            rowParteInv["!numeroriga"] = numeroriga;
            rowParteInv["idinventory"] = codiceinventario;
            if (numinventario == "") {
                rowParteInv["!ninventory"] = DBNull.Value;
            }
            else {
                rowParteInv["!ninventory"] = CfgFn.GetNoNullInt32(numinventario);
            }
            rowParteInv["ninventory"] = DBNull.Value;
            //rowParteInv["!idinventory"]=codiceinventario;
            rowParteInv["!assetdescription"] = descrizione;
            rowParteInv.EndEdit();


        }


        private void PulisciRigaOrdine() {
            Meta.GetFormData(true);
            DataRow row = DS.assetacquire.Rows[0];
            row["idmankind"] = DBNull.Value;
            row["yman"] = DBNull.Value;
            row["nman"] = DBNull.Value;
            row["rownum"] = DBNull.Value;
            txtCredDeb.ReadOnly = false;
            Meta.FreshForm();
        }

        //private void PulisciBenePosseduto() {
        //    Meta.GetFormData(true);
        //    DataRow row = DS.assetacquire.Rows[0];
        //    row["yassetload"]=DBNull.Value;
        //    row["nassetload"]=DBNull.Value;
        //    row["idassetloadkind"] = DBNull.Value;
        //    Meta.FreshForm();
        //}


        private void radioPosseduto_CheckedChanged(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (!radioPosseduto.Checked) return;
            AbilitaBenePosseduto(false);
            AbilitaRigaOrdine(false);
            PulisciRigaOrdine();
            if (Meta.InsertMode) {
                AbilitaAutoNumerazione(false);
                if (!chkIspieceAcquire.Checked) ImpostaAutoIncrementoNumInventario(false);
            }
        }


        private void radioNuovo_CheckedChanged(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (!radioNuovo.Checked) return;
            AbilitaBenePosseduto(false);
            AbilitaRigaOrdine(true);
            //PulisciBenePosseduto();
            if (Meta.InsertMode) {
                AbilitaAutoNumerazione(true);
                if (!chkIspieceAcquire.Checked) ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            }
        }


        void VisualizzaONascondiNumInventario(bool visualizza) {
            Meta.GetFormData(true);
            if (visualizza) {
                //svuoto il campo numinventario delle righe di asset (tab. figlio)
                foreach (DataRow r in DS.asset.Rows) {
                    if (r.RowState == DataRowState.Deleted) continue;
                    r["!ninventory"] = r["ninventory"]; //.ToString();
                }
            }
            else {
                foreach (DataRow r in DS.asset.Rows) {
                    if (r.RowState == DataRowState.Deleted) continue;
                    r["!ninventory"] = DBNull.Value; // "";
                }
            }
            //Meta.FreshForm();

        }

        /// <summary>
        /// Elimina il num. dell'inventario dalle righe di asset
        /// e imposta temporaneamente il max + 1 (per eludere le regole)
        /// </summary>
        /// <param name="flag">True = num. auto abilitata</param>
        //		private void CancellaNumInventario(bool flag) {
        //			Meta.GetFormData(true);
        //			//svuoto campo num. iniziale tabella principale
        //			DS.assetacquire.Rows[0]["startnumber"]=0;
        //
        //			int numinventario = 0;
        //			if (flag) numinventario = GetMAXNumInventario();
        //
        //			//svuoto il campo numinventario delle righe di asset (tab. figlio)
        //			foreach (DataRow r in DS.asset.Rows) {
        //				if (r.RowState==DataRowState.Deleted) continue;
        //				r["!ninventory"]="";
        //				if (flag) 
        //					r["ninventory"]=numinventario++;
        //				else 
        //					r["ninventory"]=DBNull.Value;
        //			}
        //			Meta.FreshForm();
        //		}
        void DoAutoCheck() {
            AbilitaNumIniziale(!chkAuto.Checked);
            int numiniz = CfgFn.GetNoNullInt32(txtNumIniz.Text);
            VisualizzaONascondiNumInventario((numiniz != 0) && (!chkAuto.Checked));
            //CancellaNumInventario(chkAuto.Checked);
            ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            HelpForm.SetDenyNull(DS.assetacquire.Columns["startnumber"], !chkAuto.Checked);
            if (Meta.IsEmpty) return;
            int quantita = CfgFn.GetNoNullInt32(txtQuantita.Text);
            if (quantita == 0) return;
            int oldquantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);
            AggiornaRigheBeneInv(quantita, oldquantita);
        }

        private void chkAuto_CheckedChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            DoAutoCheck();
        }


        private void btnCopiaBene_Click(object sender, System.EventArgs e) {

            if (MetaData.Empty(this)) return;
            btnCopiaBene.Focus();
            MetaData.GetFormData(this, true);
            if (DS.asset.Rows.Count < 1) return;
            string msg = "Questa operazione copia le informazioni specifiche del cespite " +
                         "evidenziato su tutti gli altri cespiti del carico sovrapponendo le " +
                         "informazioni eventualmente inserite precedentemente. Confermi?";
            DialogResult res = MessageBox.Show(msg, "Conferma",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {

                DataRow selRow = HelpForm.GetLastSelected(DS.asset);
                if (selRow == null) return;
                foreach (DataRow row in DS.asset.Rows) {
                    if (row.RowState == DataRowState.Deleted)
                        continue;
                    foreach (DataColumn C in DS.asset.Columns) {
                        if (C.ColumnName == "idasset" ||
                            C.ColumnName == "idpiece" ||
                            C.ColumnName == "ninventory" ||
                            C.ColumnName == "!ninventory" ||
                            C.ColumnName == "!numeroriga"
                            )
                            continue;
                        row[C.ColumnName] = selRow[C.ColumnName];
                    }

                }
                DataRow[] CurrMan = DS.assetmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", selRow["idasset"]),
                    QHC.IsNull("start")));
                MetaData Meta_AssetManager = Meta.Dispatcher.Get("assetmanager");
                Meta_AssetManager.SetDefaults(DS.assetmanager);

                DataRow[] CurrSubMan = DS.assetsubmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", selRow["idasset"]),
                    QHC.IsNull("start")));
                MetaData Meta_AssetSubManager = Meta.Dispatcher.Get("assetsubmanager");
                Meta_AssetSubManager.SetDefaults(DS.assetsubmanager);

                MetaData Meta_AssetLocation = Meta.Dispatcher.Get("assetlocation");
                Meta_AssetLocation.SetDefaults(DS.assetlocation);
                if (CurrMan.Length > 0) {
                    DataRow CM = CurrMan[0];
                    foreach (DataRow arow in DS.asset.Select()) {
                        if (arow["idasset"].Equals(selRow["idasset"]))
                            continue;
                        //Crea o modifica la riga iniziale sul resp.
                        DataRow[] MyMan = DS.assetmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                            QHC.IsNull("start")));
                        if (MyMan.Length == 0) {
                            MyMan = DS.assetmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                                QHC.IsNull("start")), null, DataViewRowState.Deleted);
                            if (MyMan.Length > 0) {
                                MyMan[0].RejectChanges();
                            }
                        }
                        DataRow SelMan;
                        if (MyMan.Length == 0) {
                            SelMan = Meta_AssetManager.Get_New_Row(arow, DS.assetmanager);
                        }
                        else {
                            SelMan = MyMan[0];
                        }
                        foreach (DataColumn ColM in DS.assetmanager.Columns) {
                            if (ColM.ColumnName != "idasset") {
                                SelMan[ColM.ColumnName] = CM[ColM.ColumnName];
                            }
                        }
                    }
                }
                else {
                    foreach (DataRow arow in DS.assetmanager.Select(QHC.IsNull("start"))) {
                        arow.Delete();
                    }

                }

                DataRow[] CurrLoc = DS.assetlocation.Select(QHC.AppAnd(QHC.CmpEq("idasset", selRow["idasset"]),
                    QHC.IsNull("start")));
                if (CurrLoc.Length > 0) {
                    DataRow CL = CurrLoc[0];
                    foreach (DataRow arow in DS.asset.Select()) {
                        if (arow["idasset"].Equals(selRow["idasset"]))
                            continue;
                        DataRow[] MyLoc = DS.assetlocation.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                            QHC.IsNull("start")));
                        if (MyLoc.Length == 0) {
                            MyLoc = DS.assetlocation.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                                QHC.IsNull("start")), null, DataViewRowState.Deleted);
                            if (MyLoc.Length > 0) {
                                MyLoc[0].RejectChanges();
                            }
                        }
                        DataRow SelLoc;
                        if (MyLoc.Length == 0) {
                            SelLoc = Meta_AssetLocation.Get_New_Row(arow, DS.assetlocation);
                        }
                        else {
                            SelLoc = MyLoc[0];
                        }
                        foreach (DataColumn ColL in DS.assetlocation.Columns) {
                            if (ColL.ColumnName != "idasset") {
                                SelLoc[ColL.ColumnName] = CL[ColL.ColumnName];
                            }
                        }
                    }
                }
                else {
                    foreach (DataRow arow in DS.assetlocation.Select(QHC.IsNull("start"))) {
                        arow.Delete();
                    }
                }


                if (CurrSubMan.Length > 0) {
                    DataRow CMsub = CurrSubMan[0];
                    foreach (DataRow arow in DS.asset.Select()) {
                        if (arow["idasset"].Equals(selRow["idasset"]))
                            continue;
                        //Crea o modifica la riga iniziale sul consegnatario
                        DataRow[] MySubMan = DS.assetsubmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                            QHC.IsNull("start")));
                        if (MySubMan.Length == 0) {
                            MySubMan = DS.assetsubmanager.Select(QHC.AppAnd(QHC.CmpEq("idasset", arow["idasset"]),
                                QHC.IsNull("start")), null, DataViewRowState.Deleted);
                            if (MySubMan.Length > 0) {
                                MySubMan[0].RejectChanges();
                            }
                        }
                        DataRow SelSubMan;
                        if (MySubMan.Length == 0) {
                            SelSubMan = Meta_AssetSubManager.Get_New_Row(arow, DS.assetsubmanager);
                        }
                        else {
                            SelSubMan = MySubMan[0];
                        }
                        foreach (DataColumn ColM in DS.assetsubmanager.Columns) {
                            if (ColM.ColumnName != "idasset") {
                                SelSubMan[ColM.ColumnName] = CMsub[ColM.ColumnName];
                            }
                        }
                    }
                }
                else {
                    foreach (DataRow arow in DS.assetsubmanager.Select(QHC.IsNull("start"))) {
                        arow.Delete();
                    }
                }
            }
        }



        void AggiornaUbicazioneDaContrattoPassivo (Object idlocation){

            if (chkIspieceAcquire.Checked) { return; }
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            if (DS.assetlocation.Rows.Count == 0) {

                foreach (DataRow Curr in DS.asset.Select()){
                        MetaData Meta_AssetLocation = Meta.Dispatcher.Get("assetlocation");
                        Meta_AssetLocation.SetDefaults(DS.assetlocation);
                        DataRow RAssetLoc;
                        RAssetLoc = Meta_AssetLocation.Get_New_Row(Curr, DS.assetlocation);
                        RAssetLoc["idlocation"] = idlocation;

                }
            }
            else { 
            string msg = "Si desidera aggiornare le ubicazioni specifiche del cespite in base a quelle del dettaglio del contratto passivo." +                         
                         "Confermi?";
            DialogResult res = MessageBox.Show(msg, "Conferma",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes){                
                foreach (DataRow Curr in DS.assetlocation.Select()){
                        Curr["idlocation"] = idlocation;           
                }
            }
            }
            Meta.FreshForm();
        }


            bool WarningDaVisualizzare = false;

        private void txtNumIniz_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (MetaData.Empty(this)) return;

            
            int numiniziale = 0;
            numiniziale =
                CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(numiniziale.GetType(), txtNumIniz.Text, null));
            string sNumIniziale = txtNumIniz.Text.Trim();
            bool NumInizIsLetter = false;
            for (int i = 0; i < sNumIniziale.Length; i++) {
                if (!(Char.IsNumber(sNumIniziale, i))) {
                    NumInizIsLetter = true;
                    break;
                }
            }

            if (numiniziale < 0 || sNumIniziale == "" || NumInizIsLetter) {
                //				MessageBox.Show("Inserire un numero iniziale maggiore o uguale a zero.","Attenzione",
                //					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numiniziale = 0;
            }

            if (chkIspieceAcquire.Checked) {
                Meta.GetFormData(true);
                object codiceinventario = DS.assetacquire.Rows[0]["idinventory"];
                if (sNumIniziale == "") {
                    ScollegaBeniInv(codiceinventario);
                    m_LastNumIniz = "";
                    txtNumIniz.Text = m_LastNumIniz;
                    WarningDaVisualizzare = false;                    
                    return;
                }

                if (m_LastNumIniz == sNumIniziale) {
                    return;
                }

                if (DS.asset.Rows.Count < 1) {
                    bool check = EseguiCheckInv(codiceinventario, sNumIniziale, 1);
                    if (!check) {
                        txtNumIniz.Text = m_LastNumIniz;
                        return;
                    }
                    m_LastNumIniz = sNumIniziale;
                    return;
                }

                object quantita = DS.assetacquire.Rows[0]["number"];
                bool check2 = EseguiCheckInv(codiceinventario, sNumIniziale, quantita);
                if (!check2) {
                    txtNumIniz.Text = m_LastNumIniz;
                    return;
                }
                string msg = "Questa operazione associa gli aumenti valore " +
                             "a beni numerati progressivamente sostituendo l'associazione " +
                             "eventualmente assegnata precedentemente. Confermi?";
                DialogResult res = DialogResult.Yes;
                if (WarningDaVisualizzare)
                    res = MessageBox.Show(msg, "Conferma",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) {
                    ScollegaBeniInv();
                    ValorizzaParteConBene(2, codiceinventario, sNumIniziale, quantita.ToString());
                    m_LastNumIniz = sNumIniziale;
                }
                else {
                    //rimetto il valore precedente al num. iniziale e non faccio nulla
                    txtNumIniz.Text = m_LastNumIniz;
                }

            }
            else {

                int oldnuminiziale = CfgFn.GetNoNullInt32(DS.Tables["assetacquire"].Rows[0]["startnumber"]);
                if ((numiniziale == 0) && (oldnuminiziale > 0)) {
                    MessageBox.Show("Il n. iniziale non può essere 0.");
                    txtNumIniz.Text = oldnuminiziale.ToString();
                    HelpForm.FocusControl(txtNumIniz);//.Focus();
                    return;
                }

                if (oldnuminiziale == numiniziale) {
                    return;
                }

                MetaData.GetFormData(this, true);

                if (DS.asset.Rows.Count < 1) {
                    return;
                }
                string msg = "Questa operazione assegna un numero di inventario " +
                             "progressivo a tutti i cespiti del carico. Confermi?";
                DialogResult res = DialogResult.Yes;
                if (WarningDaVisualizzare && (oldnuminiziale > 0))
                    res = MessageBox.Show(msg, "Conferma",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) {
                    //aggiorno num. inventario
                    int N = numiniziale;
                    foreach (DataRow row in DS.asset.Rows) {
                        if (row.RowState == DataRowState.Deleted) continue;
                        if (numiniziale == 0) {
                            row["!ninventory"] = DBNull.Value; //ex ""
                        }
                        else {
                            row["!ninventory"] = N;
                        }

                        row["ninventory"] = N++;
                    }
                }
                else {
                    //rimetto il valore precedente al num. iniziale e non faccio nulla
                    DS.assetacquire.Rows[0]["startnumber"] = oldnuminiziale;
                    Meta.FreshForm();
                }
            }
            WarningDaVisualizzare = true;
        }


        private bool EseguiCheckInv(object codiceinventario, object numiniziale, object quantita) {
            if ((numiniziale.ToString() == "") || (codiceinventario.ToString() == "")) return false;
            if (!CheckInventario(codiceinventario, numiniziale, quantita)) {
                string msg = "L'insieme di numeri di inventario indicato è in tutto o in parte " +
                             "inesistente oppure uno o più cespiti appartenenti all'insieme sono stati scaricati";
                MessageBox.Show(msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }


        /// <summary>
        /// Restituisce true se ci i beni sono disponibili per quantita e num. iniz e codiceinventario.
        /// </summary>
        private bool CheckInventario(object codiceinventario, object numiniziale, object quantita) {
            if (codiceinventario == null || codiceinventario.ToString() == "") return false;
            if (numiniziale == null || numiniziale.ToString() == "") return false;
            if (quantita == null || quantita.ToString() == "" || quantita.ToString() == "0") return false;
            string[] ParamName = new string[4] { "@idinventory", "@startnumber", "@number", "@is_ok" };
            SqlDbType[] tipi = new SqlDbType[4] { SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Char };
            int[] len = new int[4] { 10, 0, 0, 1 };
            ParameterDirection[] dir = new ParameterDirection[4] {
                ParameterDirection.Input, ParameterDirection.Input,
                ParameterDirection.Input, ParameterDirection.Output
            };
            object[] valori = new object[4] { codiceinventario, numiniziale, quantita, null };
            bool res = Meta.Conn.CallSPParameter("compute_checkasset", ParamName, tipi, len, dir, ref valori, true, -1);
            if (res) return (valori[3].ToString() == "S");
            QueryCreator.ShowError(this, "Errore chiamando compute_checkasset.", Meta.Conn.LastError);
            return false;
        }


        /// <summary>
        /// Filtro sui 3 textbox
        /// </summary>
        /// <returns></returns>
        private string CalcolaFiltro() {
            string filter = "";
            if (cmbTipoOrdine.SelectedValue != null && cmbTipoOrdine.SelectedValue.ToString() != "") {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idmankind", cmbTipoOrdine.SelectedValue));
            }

            string esercordine = txtEsercordine.Text.Trim();
            if (esercordine != "") filter = QHS.AppAnd(filter, QHS.CmpEq("yman", CfgFn.GetNoNullInt32(esercordine)));
            string numordine = txtNumordine.Text.Trim();
            if (numordine != "") filter = QHS.AppAnd(filter, QHS.CmpEq("nman", CfgFn.GetNoNullInt32(numordine)));
            string numriga = txtNumriga.Text.Trim();
            if (numriga != "") filter= QHS.AppAnd(filter, QHS.CmpEq("idgroup", CfgFn.GetNoNullInt32(numriga)));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idmandatestatus", 5)); // stato approvato

            object idreg = Meta.GetAutoField(txtCredDeb);
            if (idreg!=DBNull.Value) filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", idreg));

            //object idlist = Meta.GetAutoField(txtListino);
            //if (idlist != DBNull.Value) {
            //    filter = QHS.AppAnd(filter, QHS.CmpEq("idlist", idlist));
            //}
            //else {
            //    filter = QHS.AppAnd(filter, QHS.IsNotNull("idlist"));
            //}
            object idinv = Meta.GetAutoField(txtIdClassif);
            if (idinv != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idinv", idinv));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.IsNotNull("idinv"));
            }
            return filter;
        }

        private string CalcolaFiltroBuonoCarico() {
            string filter = "";
            if (cmbCodiceBuono.SelectedValue != null && CfgFn.GetNoNullInt32(cmbCodiceBuono.SelectedValue) != 0) {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idassetloadkind", cmbCodiceBuono.SelectedValue));
            }
            string esercbuono = txtEserBuono.Text.Trim();
            if (esercbuono != "")
                filter = QHS.AppAnd(filter, QHS.CmpEq("yassetload", CfgFn.GetNoNullInt32(esercbuono)));
            string numbuono = txtNumBuono.Text.Trim();
            if (numbuono != "") filter = QHS.AppAnd(filter, QHS.CmpEq("nassetload", CfgFn.GetNoNullInt32(numbuono)));
            return filter;
        }

        public void AbilitaBuonoInventario(bool abilita) {
            txtEserBuono.ReadOnly = !abilita;
            txtNumBuono.ReadOnly = !abilita;
			txtRatificationDate.ReadOnly = !abilita;
			cmbCodiceBuono.Enabled = abilita;
        }

        bool MandateLinked = false;
        decimal TotIvaDetraibile = 0;
        decimal TotIvaGenerale = 0;
        decimal IvaGenResiduo = 0;
        decimal IvaDetResiduo = 0;
        int totquantita = 0;
        int residuo = 0;

        void CalcolaTotaliIva() {

        }


        //Chiamato solo quando cambia la quantita
        void DoSuggest() {

        }


        private void btnCollegaRiga_Click(object sender, System.EventArgs e) {
            if (!Meta.IsEmpty) Meta.GetFormData(true);
            DataRow Curr = null;

            DataAccess Conn = MetaData.GetConnection(this);
            MetaData MRiga;
            if ((Meta.InsertMode) || (Meta.EditMode))
                MRiga = MetaData.GetMetaData(this, "mandatedetailavailable");
            else {
                //MRiga= MetaData.GetMetaData(this,"mandatedetailview");
                //ho creato il nuovo MRiga xkè quando andrà a selezionare la riga di mandatedetailview tramite idgroup 
                //non avrà 1 riga ma n, xkè ci sono nrighe per ogni gruppo in mandatedetailview
                MRiga = MetaData.GetMetaData(this, "mandatedetailgroupview");
            }
            MRiga.FilterLocked = true;
            MRiga.DS = DS;

            string filter = CalcolaFiltro();
            filter = QHS.AppAnd(filter, QHS.CmpEq("linktoasset", "S"), QHS.IsNull("stop"));

            bool inseritoInBuonoCarico = false;

            //filtro per quegli ordini che hanno caricato beni inventariabili e il cui ordine
            //ha un residuo diverso da zero
            string staticfilter;
            // Rusciano G. 09.03.2005 - La ricerca sulla disponibilità dei dettagli dell'ordine 
            // deve essere fatta sia in Insert che in Edit Mode
            // il dettaglio dell'ordine deve avere residuo > 0 e non <> 0
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                Curr = DS.assetacquire.Rows[0];
                inseritoInBuonoCarico = (Curr["idassetload"] != DBNull.Value);
                //sara, il residuo è calcolato su idgroup di mandatedetail non più su rownum

                if (inseritoInBuonoCarico) {
                    staticfilter = QHS.CmpGe("residual", Curr["number"]);
                }
                else {
                    staticfilter = QHS.CmpGt("residual", 0);
                }

                // QHS.AppAnd(QHS.CmpGt("residual", 0), QHS.IsNotNull("codeinv"));          
                if (chkIspieceAcquire.Checked) {
                    staticfilter = QHS.AppAnd(staticfilter, QHS.CmpEq("assetkind", "P"));
                }
                else {
                    staticfilter = QHS.AppAnd(staticfilter, QHS.CmpEq("assetkind", "A"));
                }
            }
            else {
                // siamo in ricerca
                staticfilter = QHS.IsNotNull("codeinv");
            }
            string qold = "";
            if (Meta.EditMode) {
                if (Curr["idmankind", DataRowVersion.Original] != DBNull.Value) {
                    qold = QHS.AppAnd(QHS.CmpEq("idmankind", Curr["idmankind", DataRowVersion.Original]),
                        QHS.CmpEq("yman", Curr["yman", DataRowVersion.Original]),
                        QHS.CmpEq("nman", Curr["nman", DataRowVersion.Original]),
                        QHS.CmpEq("idgroup", Curr["rownum", DataRowVersion.Original]));
                    staticfilter = QHS.DoPar(QHS.AppOr(staticfilter, qold));
                }
            }


            string filterToUse = QHS.AppAnd(staticfilter, filter);
            if (inseritoInBuonoCarico) {
                filterToUse = QHS.AppAnd(filterToUse,
                    QHS.CmpEq("taxable", Curr["taxable"]),
                    QHS.CmpEq("idreg", Curr["idreg"]),
                    QHS.CmpEq("idinv", Curr["idinv"]),
                    QHS.CmpEq("taxrate", Curr["taxrate"]),
                    QHS.CmpEq("discount", Curr["discount"]),
                    QHS.CmpEq("idlist", Curr["idlist"])
                    );
            }

            DataRow selRow = MRiga.SelectOne("dettaglio", filterToUse, null, null);

            if (selRow == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") {
                            HelpForm.FocusControl((TextBox)sender);//.Focus();
                        }
                    }
                }
                return;
            }

            if (Meta.EditMode) {
                string qnew = QHS.AppAnd(QHS.CmpEq("idmankind", selRow["idmankind"]),
                    QHS.CmpEq("yman", selRow["yman"]),
                    QHS.CmpEq("nman", selRow["nman"]),
                    QHS.CmpEq("idgroup", selRow["idgroup"]));
                if (qnew == qold) {
                    PostData.RemoveFalseUpdates(DS);
                    if (DS.HasChanges()) {
                        MessageBox.Show("Poiché è stata riselezionata la riga dell'ordine originariamente collegata " +
                                        "a questo carico, le altre modifiche effettute sono state annullate.", "Avviso");
                        DS.RejectChanges();
                    }
                    Meta.FreshForm(true);
                    return;
                }
            }

            if ((Meta.InsertMode) || (Meta.EditMode)) {
                int oldquantita = CfgFn.GetNoNullInt32(Curr["number"]);
                var rAssetacquireCurr = DS.assetacquire.First();
                Curr["idmankind"] = selRow["idmankind"];    //rAssetacquireCurr.idmankind = selRow["idmankind"];
                Curr["yman"] = selRow["yman"];
                Curr["nman"] = selRow["nman"];
                Curr["rownum"] = selRow["idgroup"];

                AbilitaCredDeb(false);
                string filtroGroup = QHS.MCmp(selRow, "idmankind", "yman", "nman", "idgroup");
                string filtroRow = QHS.AppAnd(QHS.MCmp(selRow, "idmankind", "yman", "nman"),
                    QHS.CmpEq("rownum", selRow["idgroup"]));

                DataTable ordineGroup = Conn.RUN_SELECT("mandatedetailgroupview", "*", null, filtroGroup, null, false);
                var rOrdineGroup = ordineGroup.First();
                if (rOrdineGroup == null) {
                    MessageBox.Show(@"Il dettaglio ordine non è stato trovato", @"Errore");
                    return;
                }
                DataTable ordUpb = Conn.SQLRunner("select * from mandatedetail where " + filtroGroup, true);
                object iddupb = DBNull.Value;

                if (ordUpb != null && ordUpb.Rows.Count == 1) {
                    if (inseritoInBuonoCarico && Curr["idupb"].ToString() != ordUpb.Rows[0]["idupb"].ToString()) {
                        MessageBox.Show(@"La riga selezionata ha un upb diverso da quello precedente", @"Errore");
                        DS.RejectChanges();
                        Meta.FreshForm(true);
                        return;
                    }
                    Curr["idupb"] = ordUpb.Rows[0]["idupb"];
                    Curr["idsor1"] = ordUpb.Rows[0]["idsor1"];
                    Curr["idsor2"] = ordUpb.Rows[0]["idsor2"];
                    Curr["idsor3"] = ordUpb.Rows[0]["idsor3"];
                }

                if (inseritoInBuonoCarico) {
                    //non opera nessun altro tipo di modifica
                    Meta.FreshForm(true);
                    return;
                }

                if (selRow["detaildescription"] == DBNull.Value) {
                    rAssetacquireCurr.description = ""; // Curr["description"] = "";
                }
                else {
                    Curr["description"] = selRow["detaildescription"];
                }

                string filtroOrdine = QHS.MCmp(selRow, "idmankind", "yman", "nman");

                object tassoCambio = Meta.Conn.DO_READ_VALUE("mandate", filtroOrdine, "exchangerate");
                Curr["idreg"] = rOrdineGroup["idreg"];
                if (rOrdineGroup["idinv"] != DBNull.Value) {
                    Curr["idinv"] = rOrdineGroup["idinv"];
                }
                if (rOrdineGroup["idlist"] != DBNull.Value) {
                    Curr["idlist"] = rOrdineGroup["idlist"];
                }

               
                decimal impostacaricata = 0;
                decimal detraibilecaricato = 0;
                //Cerca di associare la Riga Fattura
                DataRow Rinv = SelezionaRigaFattura(selRow);
                if (Rinv == null) {
                    Curr["idinvkind"] = DBNull.Value;
                    Curr["yinv"] = DBNull.Value;
                    Curr["ninv"] = DBNull.Value;
                    Curr["invrownum"] = DBNull.Value;
                    Curr["taxable"] = CfgFn.Round(CfgFn.GetNoNullDecimal(rOrdineGroup["taxable"])
                                                                     * CfgFn.GetNoNullDecimal(tassoCambio), 2);

                    Curr["taxrate"] = rOrdineGroup["taxrate"];
                    Curr["discount"] = rOrdineGroup["discount"];

                    TotIvaGenerale = CfgFn.Round(CfgFn.GetNoNullDecimal(rOrdineGroup["tax"]), 2);
                    residuo = CfgFn.GetNoNullInt32(selRow["residual"]);
                    impostacaricata = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtroRow, "SUM(tax)"));
                    detraibilecaricato = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtroRow, "SUM(abatable)"));
                }
                else {
                    Curr["idinvkind"] = Rinv["idinvkind"];
                    Curr["yinv"] = Rinv["yinv"];
                    Curr["ninv"] = Rinv["ninv"];
                    Curr["invrownum"] = Rinv["invidgroup"];
                    Curr["taxable"] = CfgFn.Round(CfgFn.GetNoNullDecimal(Rinv["taxable"])
                                                                     * CfgFn.GetNoNullDecimal(tassoCambio), 2);

                    Curr["taxrate"] = Rinv["taxrate"];
                    Curr["discount"] = Rinv["discount"];
                    string filtro_groupinv = QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv", "invidgroup");
                    object otax = Conn.DO_READ_VALUE("invoicedetailgroupview", filtro_groupinv, "tax", null);
                    decimal ivafattura = CfgFn.GetNoNullDecimal(otax);
                    int quantitafattura = CfgFn.GetNoNullInt32(Rinv["invoiced"]); //q.tà della fattura
                    int quantitacarico = CfgFn.GetNoNullInt32(Rinv["residual"]);// disponibile della fattura da caricare
                    residuo = CfgFn.GetNoNullInt32(Rinv["residual"]);
                    TotIvaGenerale = ivafattura;
                            //CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                            //    Decimal.Truncate(ivafattura * 100 / quantitafattura) / 100) * quantitacarico);
                    string filtro_inv = QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv");
                    filtro_inv = QHS.AppAnd(filtro_inv, QHS.CmpEq("invrownum", Rinv["invidgroup"]));
                    impostacaricata = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtro_inv, "SUM(tax)"));
                    detraibilecaricato = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtro_inv, "SUM(abatable)"));
                }
                
                totquantita = CfgFn.GetNoNullInt32(rOrdineGroup["number"]);
                if (inseritoInBuonoCarico) {
                    totquantita = oldquantita;
                }


                IvaGenResiduo = TotIvaGenerale - impostacaricata;

                DS.assetacquire.Rows[0]["tax"] = IvaGenResiduo;

                Meta.FreshForm();
                DS.assetacquire.Rows[0]["number"] = residuo;
                txtQuantita.Text = residuo.ToString();
                                

                if (Rinv != null) {
                    DataTable FatturaGroup = Conn.CreateTableByName("invoicedetailgroupview", "*");
                    GetData.MarkSkipSecurity(FatturaGroup);
                    Conn.RUN_SELECT_INTO_TABLE(FatturaGroup, null, QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv", "invidgroup"), null, false);
                    TotIvaDetraibile = calcolaIvaDetraibile(rOrdineGroup, FatturaGroup.Rows[0],residuo);
 
                }
                else {
                    TotIvaDetraibile = calcolaIvaDetraibile(rOrdineGroup, null,residuo);
                }

                IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                DS.assetacquire.Rows[0]["abatable"] = IvaDetResiduo;
                txtAbatable.Text = IvaDetResiduo.ToString("c");
                MandateLinked = true;

                if (CheckShowHint(IvaGenResiduo, IvaDetResiduo, residuo))
                    ShowHint(IvaGenResiduo, IvaDetResiduo, residuo);

                if (chkIspieceAcquire.Checked) {
                    if (AggiornaRigheParteNonInv(residuo, oldquantita, true))
                        CalcolaTotali(false, false);
                }
                else {
                    if (AggiornaRigheBeneInv(residuo, oldquantita))
                        CalcolaTotali(false, false);
                }

                Object idlocation = rOrdineGroup["idlocation"];
                if (idlocation != DBNull.Value) {

                    MetaData.SetDefault(DS.assetlocation, "idlocation", idlocation);
                    AggiornaUbicazioneDaContrattoPassivo(idlocation);
                }

            }
            else {
                HelpForm.SetComboBoxValue(cmbTipoOrdine, selRow["idmankind"]);
                txtEsercordine.Text = selRow["yman"].ToString();
                txtNumordine.Text = selRow["nman"].ToString();
                txtNumriga.Text = selRow["idgroup"].ToString();
                MandateLinked = false;
            }
        }
        /*dobbiamo controllare quanti sono i dett. fattura collegati a quell'ordine non ancora collegati a carichi: se ce ne sono 0, non facciamo niente, 
        se è 1 lo collego automaticamente, 
        se più di uno lo faccio scegliere dall'utente. 
        Dopo aver selezionato i dett.CP i dati verranno copiati dalla fattura nel carico cespite
        */
        DataRow SelezionaRigaFattura(DataRow SelRowMan) {
            string filter = QHS.AppAnd(QHS.MCmp(SelRowMan, "idmankind", "yman", "nman"),
                    QHS.CmpEq("manidgroup", SelRowMan["idgroup"]));
            filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0));
            //filter = QHS.AppAnd(filter, QHS.CmpGe("invoiced", SelRowMan["residual"]));// q.tà fattura >= q.tà carico Non va bene qui questa condizione [*]

            DataAccess Conn = MetaData.GetConnection(this);
            DataTable FatureView = Conn.RUN_SELECT("invoicedetailavailable", "*", null, filter, null, false);
            if (FatureView.Rows.Count == 0) return null;
            if (FatureView.Rows.Count == 1) return FatureView.Rows[0];
            if (FatureView.Rows.Count > 1) {
                MetaData MRigaInv = MetaData.GetMetaData(this, "invoicedetailavailable");
                MRigaInv.FilterLocked = true;
                MRigaInv.DS = DS;
                DataRow selRowInv = MRigaInv.SelectOne("dettaglio", filter, null, null);
                return selRowInv;
            }
            return null;
        }
        /* [*] Ho un CP di 10 collegato ad una fattura di 3.
                Creo il carico ed associo il C.P. e lui imposta automatica q.tà 10. 
                Non riesce ad associare la fattura perchè viene scartata , inquanto : 
                q.tà fattura non è >= q.tà carico
                Io vorrei modificare il carico scrivendo q.tà 3, ma oramai l'associazione con la fattura è andata perchè la gestione è sotto il btn_click di associa all'ordine.
                Allo scopo, fu rimosso il filtro sulla q.tà fattura >= q.tà carico
         * */
        bool verificaDivisibilita(decimal X, int N) {
            if (N == 0) return false;
            decimal Xone = CfgFn.RoundValuta(X / N);
            decimal Xrebuilded = Xone * N;
            if (Xrebuilded == X) return true;
            return false;
        }

        /// <summary>
        /// Restituisce true se è necessario visualizzare un aiuto sul carico
        /// </summary>
        /// <param name="totiva"></param>
        /// <param name="totivadetraibile"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        bool CheckShowHint(decimal totiva, decimal totivadetraibile, int number) {
            if (number == 0) return false;
            //Verifica iva unitaria
            if (!verificaDivisibilita(totiva, number)) return true;
            if (!verificaDivisibilita(totivadetraibile, number)) return true;
            return false;

        }

        void ShowHint(decimal totiva, decimal totivadetraibile, int number) {
            FormHint F = new FormHint(totiva, totivadetraibile, number);
            F.Show();

        }

        decimal calcolaIvaDetraibileDaOrdine(DataRow rDettOrdine) {
            decimal quantitaDettOrdine = CfgFn.GetNoNullDecimal(rDettOrdine["number"]);
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string flagmixedDettOrdine = "N";
            if (CfgFn.GetNoNullInt32(rDettOrdine["flagactivity"]) == 3) flagmixedDettOrdine = "S";
            string filtro = QHS.AppAnd(QHS.CmpEq("flagmixed", flagmixedDettOrdine),
                QHC.CmpEq("ayear", esercizio));


            object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtro, "TOP 1 abatablerate");
            double abatableRate = 1;
            if ((OabatableRate != null) && (OabatableRate != DBNull.Value)) {
                abatableRate = CfgFn.GetNoNullDouble(OabatableRate);
            }

            decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((CfgFn.GetNoNullDecimal(rDettOrdine["tax"])
                                                                         -
                                                                         CfgFn.GetNoNullDecimal(
                                                                             rDettOrdine["unabatable"]))) *
                                                      (decimal)abatableRate);

            //perequa l'iva detraibile sull quantità esegnata dall'iva detraibile totale
            //ivaDetraibile= CfgFn.RoundValuta(ivaDetraibile/quantitaDettOrdine)*quantitaAssegnata;
            return CfgFn.RoundValuta(ivaDetraibile);

        }

        decimal calcolaIvaDetraibileDaFattura(DataRow rDettOrdine, DataRow rDettIva,int residuo) {
            decimal quantitaDettOrdine = CfgFn.GetNoNullDecimal(rDettOrdine["number"]);
            // Se la quantità assegnata al carico è differente dalla quantità del dettaglio ordine
            // assegna come IVA detraibile ZERO
            //if (quantitaAssegnata != quantitaDettOrdine) return 0;

            // Se il dettaglio dell'ordine non è collegato a dettagli fattura 
            // assegna come IVA detraibile ZERO
            string filtro = QHS.AppAnd(QHS.MCmp(rDettOrdine, "idmankind", "yman", "nman"),
                QHS.CmpEq("manidgroup", rDettOrdine["idgroup"]));
            string elencoCampiDettFattura = "idinvkind, yinv, ninv, number, tax, unabatable, adate, exchangerate";

            if (rDettIva == null) return calcolaIvaDetraibileDaOrdine(rDettOrdine);//  10673
            //decimal quantitaDettFattura = CfgFn.GetNoNullDecimal(rDettIva["number"]);
            // Se le quantità sono differenti prende i campi dall'ORDINE
            decimal unabatable = 0;
            decimal tax = 0;
            //if (quantitaDettOrdine != quantitaDettFattura) {
            //    unabatable = CfgFn.GetNoNullDecimal(rDettOrdine["unabatable"]);
            //    tax = CfgFn.GetNoNullDecimal(rDettOrdine["tax"]);
            //}
            //else {
            //    unabatable = CfgFn.GetNoNullDecimal(rDettIva["unabatable"]);
            //    tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDettIva["tax"]));
            //}
            unabatable = CfgFn.GetNoNullDecimal(rDettIva["unabatable"]);
            tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDettIva["tax"]));
            //Vanno entrambe proporzionate alla q.tà del carico, ossia alla q.tà della fattura disponibile per il carico

            string filter = (QHS.MCmp(rDettIva, "idinvkind", "yinv", "ninv", "invidgroup"));
            //object residuo = Meta.Conn.DO_READ_VALUE("invoicedetailavailable", filter, "residual");
            decimal quantitaDettFattura = CfgFn.GetNoNullDecimal(rDettIva["number"]);
            if (quantitaDettFattura == 0) return 0;

            unabatable = (unabatable/ CfgFn.GetNoNullDecimal(rDettIva["number"])) * CfgFn.GetNoNullDecimal(residuo);
            tax = (tax / CfgFn.GetNoNullDecimal(rDettIva["number"])) * CfgFn.GetNoNullDecimal(residuo);


            string filtroTipoFattura = QHS.AppAnd(QHS.MCmp(rDettIva, "idinvkind"), QHS.CmpEq("ayear", rDettIva["yinv"]));
            object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtroTipoFattura, "abatablerate");
            double abatableRate = 1;
            if ((OabatableRate != null) && (OabatableRate != DBNull.Value)) {
                abatableRate = CfgFn.GetNoNullDouble(OabatableRate);
            }

            decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((tax - unabatable)) * (decimal)abatableRate);
            //ivaDetraibile= CfgFn.RoundValuta(ivaDetraibile/quantitaDettOrdine)*quantitaAssegnata;
            return ivaDetraibile;
        }



        /// <summary>
        /// Metodo che calcola l'IVA detraibile
        /// </summary>
        /// <param name="rDettOrdine">Riga del dettaglio ordine</param>
        /// <param name="quantitaAssegnata">Quantità assegnata al carico cespite</param>
        /// <returns>IVA detraibile</returns>
        decimal calcolaIvaDetraibile(DataRow rDettOrdine, DataRow rDettFattura,int residuo) {
            if (DS.Tables["config"].Rows.Count == 0) return 0;
            DataRow tCurrSetup = DS.Tables["config"].Rows[0];
            if (tCurrSetup["linktoinvoice"].ToString().ToUpper() == "S")
                return calcolaIvaDetraibileDaFattura(rDettOrdine, rDettFattura,residuo);
            else
                return calcolaIvaDetraibileDaOrdine(rDettOrdine);
        }

        private void txtNumriga_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumriga.ReadOnly) return;
            if (Meta.IsEmpty) return;
            if (txtNumriga.Text == "") return;
            btnCollegaRiga_Click(sender, e);
        }


        private void chkIspieceAcquire_CheckStateChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            //if (!Meta.DrawStateIsDone) return;
            MetaData Asset = MetaData.GetMetaData(this, "asset");
            if (chkIspieceAcquire.Checked) {
                chkAuto.Visible = false;
                chkAuto.Checked = false;
                btnNumInventario.Enabled = true;
                gridBene.Tag = "asset.accessorio.accessorio";
                btnModificaBene.Tag = "edit.accessorio";
                Asset.DescribeColumns(DS.Tables["asset"], "accessorio");
                Meta.myGetData.GetTemporaryValues(DS.asset);
                Asset.ComputeRowsAs(DS.Tables["asset"], "accessorio");
                if (!Meta.IsEmpty) {
                    gboxCespiti.Text = "Accessori";
                    //tabPageUtilizzo.Visible=false;
                    btnInserisciQuota.Enabled = false;
                    btnModificaQuota.Enabled = false;
                    btnEliminaQuota.Enabled = false;
                }

            }
            else {
                chkAuto.Visible = true;
                btnNumInventario.Enabled = false;
                gridBene.Tag = "asset.dettaglio.dettaglio";
                btnModificaBene.Tag = "edit.dettaglio";
                Asset.DescribeColumns(DS.Tables["asset"], "dettaglio");
                Meta.myGetData.GetTemporaryValues(DS.asset);
                Asset.ComputeRowsAs(DS.Tables["asset"], "dettaglio");
                if (!Meta.IsEmpty) {
                    gboxCespiti.Text = "Cespiti";
                    //tabPageUtilizzo.Visible=true;
                    btnInserisciQuota.Enabled = true;
                    btnModificaQuota.Enabled = true;
                    btnEliminaQuota.Enabled = true;
                }
            }
            gridBene.TableStyles.Clear();
            HelpForm.SetDataGrid(gridBene, DS.asset);
            if (Meta.IsEmpty) return;
            if (Meta.DrawStateIsDone) {
                DS.asset.Clear();
                txtNumIniz.Text = "";
                txtQuantita.Text = "";
                cmbTipoOrdine.SelectedIndex = 0;
                txtEsercordine.Text = "";
                PulisciRigaOrdine();
                txtNumordine.Text = "";
                txtNumriga.Text = "";
                txtImponibile.Text = "";
                txtImposta.Text = "";
                txtSconto.Text = "";
                txtQuantita.Text = "";
                txtImpostaTotale.Text = "";
                CalcolaTotali(true, true);
            }
        }


        private void btnNumInventario_Click(object sender, System.EventArgs e) {
            if (!chkIspieceAcquire.Checked) return;
            if (Meta.IsEmpty) return;
            string filter = QHS.AppAnd(QHS.IsNull("nassetunload"), QHS.CmpEq("idpiece", 1));
            if (txtIdClassif.Text != "") {

                DataRow Class = DS.inventorytreeview.Select(QHC.CmpEq("codeinv", txtIdClassif.Text.Trim()))[0];

                filter = QHS.AppAnd(filter, QHS.CmpEq("idinv_lev1", Class["idinv_lev1"]));
            }

            if (cboInventario.SelectedIndex > 0) {
                object O = cboInventario.SelectedValue;
                if (O != null) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idinventory", O));
                }
            }
            MetaData Asset = MetaData.GetMetaData(this, "asset");
            Asset.DS = DS.Clone();
            GetData.SetSorting(Asset.DS.Tables["assetview"], "ninventory asc");
            Asset.FilterLocked = true;
            DataRow AssetRow = Asset.SelectOne("default", filter, null, null);
            if (AssetRow == null) return;
            HelpForm.SetComboBoxValue(cboInventario, AssetRow["idinventory"].ToString());
            txtNumIniz.Text = AssetRow["ninventory"].ToString();
            txtNumIniz_LostFocus(null, null);
        }

        private void btnSuggerimento_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            decimal totiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtImpostaTotale.Text, txtImpostaTotale.Tag.ToString()));
            decimal totdetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtAbatable.Text, txtAbatable.Tag.ToString()));
            int quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(
                typeof(int), txtQuantita.Text, txtQuantita.Tag.ToString()));
            if (quantita == 0) return;
            ShowHint(totiva, totdetraibile, quantita);
        }

        private void btnbuonocarico_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            MetaData MRiga;
            MRiga = MetaData.GetMetaData(this, "assetloadview");

            MRiga.FilterLocked = true;
            MRiga.DS = DS;
            string filter = CalcolaFiltroBuonoCarico();
            DataRow selRow = MRiga.SelectOne("default", filter, null, null);
            if (selRow == null) {
                return;
            }

            HelpForm.SetComboBoxValue(cmbCodiceBuono, selRow["idassetloadkind"]);
            txtEserBuono.Text = selRow["yassetload"].ToString();
            txtNumBuono.Text = selRow["nassetload"].ToString();
			txtRatificationDate.Text = selRow["ratificationdate"].ToString().Substring(0,10);
		}

        private void txtImpostaTotale_TextChanged(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            decimal imponibile =
                CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImpTotale.Text, "x.y.c"));
            decimal iva =
                CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImpostaTotale.Text, "x.y.c"));
            decimal tot = imponibile + iva;
            txtImpConIVA.Text = tot.ToString("c");
        }

        private void tabCaricoBeni_SelectionChanged(object sender, EventArgs e) {

        }

        private void btnModificaBene_Click(object sender, EventArgs e) {

        }

        private void label16_Click(object sender, EventArgs e) {

        }

        private void label17_Click(object sender, EventArgs e) {

        }

        private void btnListino_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1));
            if (!Meta.IsEmpty) filter = QHS.AppAnd(filter, QHS.FieldIn("assetkind", new object[] { "A", "P" })); //task 9912
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
            //rimuovo per via di task 9912, che ha imposto filtro a prescindere (vedi sopra)
            //if (!Meta.IsEmpty) {
            //    DataRow Curr = DS.assetacquire.Rows[0];
            //    if (Curr["idmankind"] != DBNull.Value) {
            //        string filterManKind = QHS.CmpEq("idmankind", Curr["idmankind"]);
            //        object AssetKind = Conn.DO_READ_VALUE("mandatekind", filterManKind, "assetkind");
            //        int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);

            //        string filterAssetKind = "";
            //        ArrayList Alist = new ArrayList();

            //        if ((IAssetKind & 1) != 0) Alist.Add("A");
            //        if ((IAssetKind & 2) != 0) Alist.Add("P");
            //        if ((IAssetKind & 4) != 0) Alist.Add("S");
            //        if ((IAssetKind & 8) != 0) Alist.Add("M");
            //        if ((IAssetKind & 16) != 0) Alist.Add("O");

            //        foreach (string value in Alist) {
            //            filterAssetKind = QHS.AppOr(filterAssetKind, QHS.CmpEq("assetkind", value));
            //        }
            //        filterAssetKind = QHS.AppOr(filterAssetKind, QHS.IsNull("assetkind"));
            //        filter = QHS.AppAnd(filter, QHS.DoPar(filterAssetKind));
            //    }
            //}


            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            AggiornaListino(Choosen);
        }

        void AggiornaListino(DataRow Choosen) {
            if (Meta.IsEmpty) {
                riempiOggetti(Choosen);
                return;
            }
            DataRow Curr = DS.assetacquire.Rows[0];
            if (txtDescrizione.Text != "") {
                if (CfgFn.GetNoNullInt32(Curr["idlist"]) != CfgFn.GetNoNullInt32(Choosen["idlist"])) {
                    if (MessageBox.Show("Aggiorno il campo descrizione in base al listino selezionato?",
                        "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        txtDescrizione.Text = Choosen["description"].ToString();
                        Curr["description"] = Choosen["description"].ToString();
                    }

                }
            }
            else {
                Curr["description"] = Choosen["description"].ToString();
                txtDescrizione.Text = Choosen["description"].ToString();
            }
            object idlistclasssel = Choosen["idlistclass"];
            string filterListClass = QHS.AppAnd(QHS.CmpEq("idlistclass", idlistclasssel),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataTable ListClass =
                Conn.RUN_SELECT("listclassyearview", "*", null, filterListClass, null, true);
            if ((ListClass != null) && (ListClass.Rows.Count > 0) &&
                (ListClass.Rows[0]["idinv"] != DBNull.Value)) {
                Curr["idinv"] = ListClass.Rows[0]["idinv"];
                txtIdClassif.Text = ListClass.Rows[0]["codeinv"].ToString();
                txtDescClassif.Text = ListClass.Rows[0]["inventorytree"].ToString();
                Meta.FreshForm();
            }

            Curr["idlist"] = Choosen["idlist"];
            riempiOggetti(Choosen);

        }

        private void riempiOggetti(DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";

        }

        private void svuotaOggetti() {
            txtDescrizioneListino.Text = "";

            if ((!MetaData.Empty(this))) {
                DS.assetacquire.Rows[0]["idlist"] = DBNull.Value;
            }
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

            //if (DS.assetacquire.Rows.Count == 0) return;

            if (!Meta.DrawStateIsDone) return;
            if (!Meta.IsEmpty) {
                Meta.GetFormData(true);
            }
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
                //txtListino.Focus();
                HelpForm.FocusControl(txtListino);
                lastCodice = null;
                return;
            }

            AggiornaListino(Choosen);
        }

        private string lastCodice;

        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
        }

        private void btnCollegaRigaFattura_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            MetaData MRiga;
            MRiga = MetaData.GetMetaData(this, "invoicedetailgroupview");

            MRiga.FilterLocked = true;
            MRiga.DS = DS;
            string filter = CalcolaFiltroRigaFattura();
            DataRow selRow = MRiga.SelectOne("dettaglio", filter, null, null);
            if (selRow == null) {
                return;
            }

            HelpForm.SetComboBoxValue(cmbTipoFattura, selRow["idinvkind"]);
            txtEsercFattura.Text = selRow["yinv"].ToString();
            txtNumFattura.Text = selRow["ninv"].ToString();
        }
        private string CalcolaFiltroRigaFattura() {
            string filter = "";
            if (cmbTipoFattura.SelectedValue != null && CfgFn.GetNoNullInt32(cmbTipoFattura.SelectedValue) != 0) {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idinvkind", cmbTipoFattura.SelectedValue));
            }
            string esercFattura = txtEsercFattura.Text.Trim();
            if (esercFattura != "")
                filter = QHS.AppAnd(filter, QHS.CmpEq("yinv", CfgFn.GetNoNullInt32(esercFattura)));
            string numFattura = txtNumFattura.Text.Trim();
            if (numFattura != "") filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", CfgFn.GetNoNullInt32(numFattura)));
            return filter;
        }

        private void txtNumordine_Leave(object sender, EventArgs e) {
            if (InChiusura) return;
            if (txtNumordine.ReadOnly) return;
            if (Meta.IsEmpty) return;
            if (txtNumordine.Text == "") return;
            HelpForm.FocusControl(txtNumriga);//.Focus();
        }

        private void txtEsercordine_Leave(object sender, EventArgs e) {
            if (InChiusura) return;
            if (txtEsercordine.ReadOnly) return;
            if (Meta.IsEmpty) return;
            if (txtEsercordine.Text == "") return;
            HelpForm.FocusControl(txtNumordine);//.Focus();
        }

        private void txtImposta_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);

        }

        private void txtQuantita_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (txtQuantita.Text.Trim() == "") txtQuantita.Text = "0";

        }

        private void txtImponibile_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);

        }

        private void txtSconto_Leave(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);

        }

        private void Frm_assetacquire_default_Load(object sender, EventArgs e) {

        }
    }
}
