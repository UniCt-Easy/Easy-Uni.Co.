
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
using funzioni_configurazione;
using System.Data;
using System.Collections.Generic;
using q = metadatalibrary.MetaExpression;



namespace manage_automatismi {
    /// <summary>
    /// Summary description for FrmManage_Automatismi.
    /// </summary>
    public class FrmManage_Automatismi : System.Windows.Forms.Form {
        DataSet DS;
        DataAccess Conn;
        MetaDataDispatcher Disp;
        bool viewMainMov;
        CQueryHelper QHC;
        QueryHelper QHS;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSpesa;
        private System.Windows.Forms.TabPage tabEntrata;
        private System.Windows.Forms.TabPage tabVarSpesa;
        private System.Windows.Forms.TabPage tabVarEntrata;
        private System.Windows.Forms.DataGrid dgSpesa;
        private System.Windows.Forms.DataGrid dgEntrata;
        private System.Windows.Forms.DataGrid dgVarSpesa;
        private System.Windows.Forms.DataGrid dgVarEntrata;
        private System.Windows.Forms.DataGrid dgClassSpesa;
        private System.Windows.Forms.DataGrid dgClassEntrata;
        private System.Windows.Forms.GroupBox groupBox2;
        public manage_automatismi.dsMov dsMov;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnDeleteClassE;
        private System.Windows.Forms.Button btnUpdateClassE;
        private System.Windows.Forms.Button btnInsertClassE;
        private System.Windows.Forms.Button btnDeleteClassI;
        private System.Windows.Forms.Button btnUpdateClassI;
        private System.Windows.Forms.Button btnInsertClassI;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private TabControl tabCrediti;
        private TabPage tabClassificazioni;
        private TabPage tabFinanziamenti;
        private Button btnDelFinanziamentoCrediti;
        private Button btnAddFinanziamentoCrediti;
        private Button btnEditFinanziamentoCrediti;
        private DataGrid dgCrediti;
        private TabPage tabCassa;
        private Button btnDelFinanziamentoCassa;
        private Button btnAddFinanziamentoCassa;
        private Button btnEditFinanziamentoCassa;
        private DataGrid dgCassa;
        int expensefinphase = 0;
        int expensepaymentphase = 0;
        private Label label1;
        ContextMenu ExcelMenu;


        private int getIntSys(string nome) {
            object O = Conn.GetSys(nome);
            if (O == null) return 99;
            return Convert.ToInt32(O);
        }

        AutoTablesCache Cache;
        object maxincomephase;
        object maxexpensephase = 0;
        public FrmManage_Automatismi(DataSet DS, DataAccess Conn, MetaDataDispatcher Disp, bool viewMainMov, AutoTablesCache Cache) {

            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));

            this.DS = DS;
            this.Conn = Conn;
            this.Disp = Disp;
            this.viewMainMov = viewMainMov;
            this.Cache = Cache;

            InitializeComponent();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            expensefinphase = getIntSys("expensefinphase");
            expensepaymentphase = getIntSys("maxexpensephase");
            maxincomephase = getIntSys("maxincomephase");
            maxexpensephase = getIntSys("maxexpensephase");
            FillTables();
        }


        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabSpesa = new System.Windows.Forms.TabPage();
			this.tabCrediti = new System.Windows.Forms.TabControl();
			this.tabClassificazioni = new System.Windows.Forms.TabPage();
			this.btnDeleteClassE = new System.Windows.Forms.Button();
			this.btnInsertClassE = new System.Windows.Forms.Button();
			this.btnUpdateClassE = new System.Windows.Forms.Button();
			this.dgClassSpesa = new System.Windows.Forms.DataGrid();
			this.tabFinanziamenti = new System.Windows.Forms.TabPage();
			this.btnDelFinanziamentoCrediti = new System.Windows.Forms.Button();
			this.btnAddFinanziamentoCrediti = new System.Windows.Forms.Button();
			this.btnEditFinanziamentoCrediti = new System.Windows.Forms.Button();
			this.dgCrediti = new System.Windows.Forms.DataGrid();
			this.tabCassa = new System.Windows.Forms.TabPage();
			this.btnDelFinanziamentoCassa = new System.Windows.Forms.Button();
			this.btnAddFinanziamentoCassa = new System.Windows.Forms.Button();
			this.btnEditFinanziamentoCassa = new System.Windows.Forms.Button();
			this.dgCassa = new System.Windows.Forms.DataGrid();
			this.dgSpesa = new System.Windows.Forms.DataGrid();
			this.tabEntrata = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnDeleteClassI = new System.Windows.Forms.Button();
			this.btnUpdateClassI = new System.Windows.Forms.Button();
			this.btnInsertClassI = new System.Windows.Forms.Button();
			this.dgClassEntrata = new System.Windows.Forms.DataGrid();
			this.dgEntrata = new System.Windows.Forms.DataGrid();
			this.tabVarEntrata = new System.Windows.Forms.TabPage();
			this.dgVarEntrata = new System.Windows.Forms.DataGrid();
			this.tabVarSpesa = new System.Windows.Forms.TabPage();
			this.dgVarSpesa = new System.Windows.Forms.DataGrid();
			this.dsMov = new manage_automatismi.dsMov();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabSpesa.SuspendLayout();
			this.tabCrediti.SuspendLayout();
			this.tabClassificazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgClassSpesa)).BeginInit();
			this.tabFinanziamenti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCrediti)).BeginInit();
			this.tabCassa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCassa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSpesa)).BeginInit();
			this.tabEntrata.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgClassEntrata)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgEntrata)).BeginInit();
			this.tabVarEntrata.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVarEntrata)).BeginInit();
			this.tabVarSpesa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVarSpesa)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsMov)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tabControl1.Controls.Add(this.tabSpesa);
			this.tabControl1.Controls.Add(this.tabEntrata);
			this.tabControl1.Controls.Add(this.tabVarEntrata);
			this.tabControl1.Controls.Add(this.tabVarSpesa);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(623, 422);
			this.tabControl1.TabIndex = 0;
			// 
			// tabSpesa
			// 
			this.tabSpesa.Controls.Add(this.tabCrediti);
			this.tabSpesa.Controls.Add(this.dgSpesa);
			this.tabSpesa.Location = new System.Drawing.Point(4, 25);
			this.tabSpesa.Name = "tabSpesa";
			this.tabSpesa.Size = new System.Drawing.Size(615, 393);
			this.tabSpesa.TabIndex = 0;
			this.tabSpesa.Text = "Spesa";
			// 
			// tabCrediti
			// 
			this.tabCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabCrediti.Controls.Add(this.tabClassificazioni);
			this.tabCrediti.Controls.Add(this.tabFinanziamenti);
			this.tabCrediti.Controls.Add(this.tabCassa);
			this.tabCrediti.Location = new System.Drawing.Point(8, 195);
			this.tabCrediti.Name = "tabCrediti";
			this.tabCrediti.SelectedIndex = 0;
			this.tabCrediti.Size = new System.Drawing.Size(599, 195);
			this.tabCrediti.TabIndex = 4;
			// 
			// tabClassificazioni
			// 
			this.tabClassificazioni.Controls.Add(this.btnDeleteClassE);
			this.tabClassificazioni.Controls.Add(this.btnInsertClassE);
			this.tabClassificazioni.Controls.Add(this.btnUpdateClassE);
			this.tabClassificazioni.Controls.Add(this.dgClassSpesa);
			this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
			this.tabClassificazioni.Name = "tabClassificazioni";
			this.tabClassificazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabClassificazioni.Size = new System.Drawing.Size(591, 169);
			this.tabClassificazioni.TabIndex = 0;
			this.tabClassificazioni.Text = "Classificazioni";
			this.tabClassificazioni.UseVisualStyleBackColor = true;
			// 
			// btnDeleteClassE
			// 
			this.btnDeleteClassE.Location = new System.Drawing.Point(198, 6);
			this.btnDeleteClassE.Name = "btnDeleteClassE";
			this.btnDeleteClassE.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteClassE.TabIndex = 5;
			this.btnDeleteClassE.Text = "Cancella";
			this.btnDeleteClassE.Click += new System.EventHandler(this.btnDeleteClassE_Click);
			// 
			// btnInsertClassE
			// 
			this.btnInsertClassE.Location = new System.Drawing.Point(6, 6);
			this.btnInsertClassE.Name = "btnInsertClassE";
			this.btnInsertClassE.Size = new System.Drawing.Size(75, 23);
			this.btnInsertClassE.TabIndex = 3;
			this.btnInsertClassE.Text = "Inserisci";
			this.btnInsertClassE.Click += new System.EventHandler(this.btnInsertClassE_Click);
			// 
			// btnUpdateClassE
			// 
			this.btnUpdateClassE.Location = new System.Drawing.Point(102, 6);
			this.btnUpdateClassE.Name = "btnUpdateClassE";
			this.btnUpdateClassE.Size = new System.Drawing.Size(75, 23);
			this.btnUpdateClassE.TabIndex = 4;
			this.btnUpdateClassE.Text = "Correggi";
			this.btnUpdateClassE.Click += new System.EventHandler(this.btnUpdateClassE_Click);
			// 
			// dgClassSpesa
			// 
			this.dgClassSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgClassSpesa.DataMember = "";
			this.dgClassSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgClassSpesa.Location = new System.Drawing.Point(6, 38);
			this.dgClassSpesa.Name = "dgClassSpesa";
			this.dgClassSpesa.Size = new System.Drawing.Size(579, 125);
			this.dgClassSpesa.TabIndex = 2;
			// 
			// tabFinanziamenti
			// 
			this.tabFinanziamenti.Controls.Add(this.btnDelFinanziamentoCrediti);
			this.tabFinanziamenti.Controls.Add(this.btnAddFinanziamentoCrediti);
			this.tabFinanziamenti.Controls.Add(this.btnEditFinanziamentoCrediti);
			this.tabFinanziamenti.Controls.Add(this.dgCrediti);
			this.tabFinanziamenti.Location = new System.Drawing.Point(4, 22);
			this.tabFinanziamenti.Name = "tabFinanziamenti";
			this.tabFinanziamenti.Padding = new System.Windows.Forms.Padding(3);
			this.tabFinanziamenti.Size = new System.Drawing.Size(591, 169);
			this.tabFinanziamenti.TabIndex = 1;
			this.tabFinanziamenti.Text = "Finanziamento Crediti";
			this.tabFinanziamenti.UseVisualStyleBackColor = true;
			// 
			// btnDelFinanziamentoCrediti
			// 
			this.btnDelFinanziamentoCrediti.Location = new System.Drawing.Point(198, 6);
			this.btnDelFinanziamentoCrediti.Name = "btnDelFinanziamentoCrediti";
			this.btnDelFinanziamentoCrediti.Size = new System.Drawing.Size(75, 23);
			this.btnDelFinanziamentoCrediti.TabIndex = 9;
			this.btnDelFinanziamentoCrediti.Text = "Cancella";
			this.btnDelFinanziamentoCrediti.Click += new System.EventHandler(this.btnDelFinanziamentoCrediti_Click);
			// 
			// btnAddFinanziamentoCrediti
			// 
			this.btnAddFinanziamentoCrediti.Location = new System.Drawing.Point(6, 6);
			this.btnAddFinanziamentoCrediti.Name = "btnAddFinanziamentoCrediti";
			this.btnAddFinanziamentoCrediti.Size = new System.Drawing.Size(75, 23);
			this.btnAddFinanziamentoCrediti.TabIndex = 7;
			this.btnAddFinanziamentoCrediti.Text = "Inserisci";
			this.btnAddFinanziamentoCrediti.Click += new System.EventHandler(this.btnAddFinanziamentoCrediti_Click);
			// 
			// btnEditFinanziamentoCrediti
			// 
			this.btnEditFinanziamentoCrediti.Location = new System.Drawing.Point(102, 6);
			this.btnEditFinanziamentoCrediti.Name = "btnEditFinanziamentoCrediti";
			this.btnEditFinanziamentoCrediti.Size = new System.Drawing.Size(75, 23);
			this.btnEditFinanziamentoCrediti.TabIndex = 8;
			this.btnEditFinanziamentoCrediti.Text = "Correggi";
			this.btnEditFinanziamentoCrediti.Click += new System.EventHandler(this.btnEditFinanziamentoCrediti_Click);
			// 
			// dgCrediti
			// 
			this.dgCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCrediti.DataMember = "";
			this.dgCrediti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCrediti.Location = new System.Drawing.Point(6, 38);
			this.dgCrediti.Name = "dgCrediti";
			this.dgCrediti.Size = new System.Drawing.Size(579, 125);
			this.dgCrediti.TabIndex = 6;
			// 
			// tabCassa
			// 
			this.tabCassa.Controls.Add(this.btnDelFinanziamentoCassa);
			this.tabCassa.Controls.Add(this.btnAddFinanziamentoCassa);
			this.tabCassa.Controls.Add(this.btnEditFinanziamentoCassa);
			this.tabCassa.Controls.Add(this.dgCassa);
			this.tabCassa.Location = new System.Drawing.Point(4, 22);
			this.tabCassa.Name = "tabCassa";
			this.tabCassa.Size = new System.Drawing.Size(591, 169);
			this.tabCassa.TabIndex = 2;
			this.tabCassa.Text = "Finanziamento Cassa";
			this.tabCassa.UseVisualStyleBackColor = true;
			// 
			// btnDelFinanziamentoCassa
			// 
			this.btnDelFinanziamentoCassa.Location = new System.Drawing.Point(198, 6);
			this.btnDelFinanziamentoCassa.Name = "btnDelFinanziamentoCassa";
			this.btnDelFinanziamentoCassa.Size = new System.Drawing.Size(75, 23);
			this.btnDelFinanziamentoCassa.TabIndex = 13;
			this.btnDelFinanziamentoCassa.Text = "Cancella";
			this.btnDelFinanziamentoCassa.Click += new System.EventHandler(this.btnDelFinanziamentoCassa_Click);
			// 
			// btnAddFinanziamentoCassa
			// 
			this.btnAddFinanziamentoCassa.Location = new System.Drawing.Point(6, 6);
			this.btnAddFinanziamentoCassa.Name = "btnAddFinanziamentoCassa";
			this.btnAddFinanziamentoCassa.Size = new System.Drawing.Size(75, 23);
			this.btnAddFinanziamentoCassa.TabIndex = 11;
			this.btnAddFinanziamentoCassa.Text = "Inserisci";
			this.btnAddFinanziamentoCassa.Click += new System.EventHandler(this.btnAddFinanziamentoCassa_Click);
			// 
			// btnEditFinanziamentoCassa
			// 
			this.btnEditFinanziamentoCassa.Location = new System.Drawing.Point(102, 6);
			this.btnEditFinanziamentoCassa.Name = "btnEditFinanziamentoCassa";
			this.btnEditFinanziamentoCassa.Size = new System.Drawing.Size(75, 23);
			this.btnEditFinanziamentoCassa.TabIndex = 12;
			this.btnEditFinanziamentoCassa.Text = "Correggi";
			this.btnEditFinanziamentoCassa.Click += new System.EventHandler(this.btnEditFinanziamentoCassa_Click);
			// 
			// dgCassa
			// 
			this.dgCassa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCassa.DataMember = "";
			this.dgCassa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCassa.Location = new System.Drawing.Point(6, 38);
			this.dgCassa.Name = "dgCassa";
			this.dgCassa.Size = new System.Drawing.Size(579, 125);
			this.dgCassa.TabIndex = 10;
			// 
			// dgSpesa
			// 
			this.dgSpesa.AllowNavigation = false;
			this.dgSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgSpesa.DataMember = "";
			this.dgSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgSpesa.Location = new System.Drawing.Point(8, 8);
			this.dgSpesa.Name = "dgSpesa";
			this.dgSpesa.Size = new System.Drawing.Size(599, 181);
			this.dgSpesa.TabIndex = 0;
			this.dgSpesa.CurrentCellChanged += new System.EventHandler(this.dgSpesa_CurrentCellChanged);
			this.dgSpesa.DoubleClick += new System.EventHandler(this.dgSpesa_DoubleClick);
			// 
			// tabEntrata
			// 
			this.tabEntrata.Controls.Add(this.label1);
			this.tabEntrata.Controls.Add(this.groupBox2);
			this.tabEntrata.Controls.Add(this.dgEntrata);
			this.tabEntrata.Location = new System.Drawing.Point(4, 25);
			this.tabEntrata.Name = "tabEntrata";
			this.tabEntrata.Size = new System.Drawing.Size(615, 393);
			this.tabEntrata.TabIndex = 1;
			this.tabEntrata.Text = "Entrata";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label1.Location = new System.Drawing.Point(5, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(395, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Doppio click su una riga  per cambiare la descrizione o associare un finanziament" +
    "o";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.btnDeleteClassI);
			this.groupBox2.Controls.Add(this.btnUpdateClassI);
			this.groupBox2.Controls.Add(this.btnInsertClassI);
			this.groupBox2.Controls.Add(this.dgClassEntrata);
			this.groupBox2.Location = new System.Drawing.Point(8, 189);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(599, 201);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Classificazioni";
			// 
			// btnDeleteClassI
			// 
			this.btnDeleteClassI.Location = new System.Drawing.Point(200, 16);
			this.btnDeleteClassI.Name = "btnDeleteClassI";
			this.btnDeleteClassI.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteClassI.TabIndex = 8;
			this.btnDeleteClassI.Text = "Cancella";
			this.btnDeleteClassI.Click += new System.EventHandler(this.btnDeleteClassI_Click);
			// 
			// btnUpdateClassI
			// 
			this.btnUpdateClassI.Location = new System.Drawing.Point(104, 16);
			this.btnUpdateClassI.Name = "btnUpdateClassI";
			this.btnUpdateClassI.Size = new System.Drawing.Size(75, 23);
			this.btnUpdateClassI.TabIndex = 7;
			this.btnUpdateClassI.Text = "Correggi";
			this.btnUpdateClassI.Click += new System.EventHandler(this.btnUpdateClassI_Click);
			// 
			// btnInsertClassI
			// 
			this.btnInsertClassI.Location = new System.Drawing.Point(8, 16);
			this.btnInsertClassI.Name = "btnInsertClassI";
			this.btnInsertClassI.Size = new System.Drawing.Size(75, 23);
			this.btnInsertClassI.TabIndex = 6;
			this.btnInsertClassI.Text = "Inserisci";
			this.btnInsertClassI.Click += new System.EventHandler(this.btnInsertClassI_Click);
			// 
			// dgClassEntrata
			// 
			this.dgClassEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgClassEntrata.DataMember = "";
			this.dgClassEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgClassEntrata.Location = new System.Drawing.Point(8, 48);
			this.dgClassEntrata.Name = "dgClassEntrata";
			this.dgClassEntrata.Size = new System.Drawing.Size(583, 145);
			this.dgClassEntrata.TabIndex = 4;
			// 
			// dgEntrata
			// 
			this.dgEntrata.AllowNavigation = false;
			this.dgEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgEntrata.DataMember = "";
			this.dgEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgEntrata.Location = new System.Drawing.Point(8, 27);
			this.dgEntrata.Name = "dgEntrata";
			this.dgEntrata.Size = new System.Drawing.Size(599, 156);
			this.dgEntrata.TabIndex = 1;
			this.dgEntrata.CurrentCellChanged += new System.EventHandler(this.dgEntrata_CurrentCellChanged);
			this.dgEntrata.DoubleClick += new System.EventHandler(this.dgEntrata_DoubleClick);
			// 
			// tabVarEntrata
			// 
			this.tabVarEntrata.Controls.Add(this.dgVarEntrata);
			this.tabVarEntrata.Location = new System.Drawing.Point(4, 25);
			this.tabVarEntrata.Name = "tabVarEntrata";
			this.tabVarEntrata.Size = new System.Drawing.Size(615, 393);
			this.tabVarEntrata.TabIndex = 3;
			this.tabVarEntrata.Text = "Var. Entrata";
			// 
			// dgVarEntrata
			// 
			this.dgVarEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgVarEntrata.DataMember = "";
			this.dgVarEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVarEntrata.Location = new System.Drawing.Point(8, 8);
			this.dgVarEntrata.Name = "dgVarEntrata";
			this.dgVarEntrata.Size = new System.Drawing.Size(599, 382);
			this.dgVarEntrata.TabIndex = 1;
			this.dgVarEntrata.DoubleClick += new System.EventHandler(this.dgVarEntrata_DoubleClick);
			// 
			// tabVarSpesa
			// 
			this.tabVarSpesa.Controls.Add(this.dgVarSpesa);
			this.tabVarSpesa.Location = new System.Drawing.Point(4, 25);
			this.tabVarSpesa.Name = "tabVarSpesa";
			this.tabVarSpesa.Size = new System.Drawing.Size(615, 393);
			this.tabVarSpesa.TabIndex = 2;
			this.tabVarSpesa.Text = "Var. Spesa";
			// 
			// dgVarSpesa
			// 
			this.dgVarSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgVarSpesa.DataMember = "";
			this.dgVarSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVarSpesa.Location = new System.Drawing.Point(8, 8);
			this.dgVarSpesa.Name = "dgVarSpesa";
			this.dgVarSpesa.Size = new System.Drawing.Size(599, 382);
			this.dgVarSpesa.TabIndex = 1;
			this.dgVarSpesa.DoubleClick += new System.EventHandler(this.dgVarSpesa_DoubleClick);
			// 
			// dsMov
			// 
			this.dsMov.DataSetName = "dsMov";
			this.dsMov.EnforceConstraints = false;
			this.dsMov.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(440, 438);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(536, 438);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 2;
			this.btnAnnulla.Text = "Annulla";
			// 
			// FrmManage_Automatismi
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(639, 468);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabControl1);
			this.Name = "FrmManage_Automatismi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Gestione Automatismi";
			this.tabControl1.ResumeLayout(false);
			this.tabSpesa.ResumeLayout(false);
			this.tabCrediti.ResumeLayout(false);
			this.tabClassificazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgClassSpesa)).EndInit();
			this.tabFinanziamenti.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCrediti)).EndInit();
			this.tabCassa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCassa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgSpesa)).EndInit();
			this.tabEntrata.ResumeLayout(false);
			this.tabEntrata.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgClassEntrata)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgEntrata)).EndInit();
			this.tabVarEntrata.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVarEntrata)).EndInit();
			this.tabVarSpesa.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVarSpesa)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsMov)).EndInit();
			this.ResumeLayout(false);

        }
        #endregion

        private void FillTables() {
            impostaCaptionClass("I");
            impostaCaptionClass("E");

            impostaCaptionCrediti();
            impostaCaptionCassa();

            popolaMovimento("I");
            impostaCaption("I", "M");
            HelpForm.SetDataGrid(dgEntrata, dsMov.Tables["incomeview"]);
            showingTab(tabControl1.TabPages["tabEntrata"], dsMov.Tables["incomeview"]);
            if (dsMov.Tables["incomeview"].Rows.Count > 0) {
                aggiornaClassificazioni("I", ottieniRiga(dgEntrata), dgClassEntrata);
            }
            dgEntrata.ContextMenu = ExcelMenu;
            popolaMovimento("E");
            impostaCaption("E", "M");

            HelpForm.SetDataGrid(dgSpesa, dsMov.Tables["expenseview"]);
            showingTab(tabControl1.TabPages["tabSpesa"], dsMov.Tables["expenseview"]);
            if (dsMov.Tables["expenseview"].Rows.Count > 0) {
                aggiornaClassificazioni("E", ottieniRiga(dgSpesa), dgClassSpesa);
                aggiornaCrediti(ottieniRiga(dgSpesa), dgCrediti);
                aggiornaCassa(ottieniRiga(dgSpesa), dgCassa);

            }
            dgSpesa.ContextMenu = ExcelMenu;

            popolaVariazione("I");
            impostaCaption("I", "V");
            HelpForm.SetDataGrid(dgVarEntrata, dsMov.Tables["incomevarview"]);
            showingTab(tabControl1.TabPages["tabVarEntrata"], dsMov.Tables["incomevarview"]);
            dgVarEntrata.ContextMenu = ExcelMenu;

            aggiornaImportoCorrente("I");

            popolaVariazione("E");
            impostaCaption("E", "V");
            HelpForm.SetDataGrid(dgVarSpesa, dsMov.Tables["expensevarview"]);
            showingTab(tabControl1.TabPages["tabVarSpesa"], dsMov.Tables["expensevarview"]);
            dgVarSpesa.ContextMenu = ExcelMenu;

            aggiornaImportoCorrente("E");
        }

        private void showingTab(TabPage tp, DataTable t) {
            if (t.Rows.Count == 0) {
                tabControl1.TabPages.Remove(tp);
            }
        }


        private void aggiornaImportoCorrente(string IoE) {
            string tName = (IoE == "I") ? "income" : "expense";
            string vName = tName + "view";
            string tVar = tName + "varview";
            string idfield = (IoE == "I") ? "idinc" : "idexp";

            foreach (DataRow rMov in dsMov.Tables[vName].Rows) {
                string fVar = QHC.CmpEq(idfield, rMov[idfield]);
                decimal sumVariation = CfgFn.GetNoNullDecimal(dsMov.Tables[tVar].Compute("SUM(amount)", fVar));
                rMov["curramount"] = CfgFn.GetNoNullDecimal(rMov["curramount"]) + sumVariation;
            }
        }

        private void popolaMovimento(string IoE) {
            string tName = (IoE == "I") ? "income" : "expense";
            string vName = tName + "view";
            string tImp = tName + "year";
            string tLast = tName + "last";
            string idfield = (IoE == "I") ? "idinc" : "idexp";
            string parentidfield = "parent" + idfield;
            object esercizio = Conn.GetSys("esercizio");
            object fasemax = IoE == "I" ? maxincomephase : maxexpensephase;

           
            Cache.registry.ReadValuesRelatedTo(DS.Tables[tName], "idreg");
            if (IoE == "I")
                Cache.underwriting.ReadValuesRelatedTo(DS.Tables[tName], "idunderwriting");
            Cache.fin.ReadValuesRelatedTo(DS.Tables[tImp], "idfin");
            Cache.upb.ReadValuesRelatedTo(DS.Tables[tImp], "idupb");

            Dictionary<int,DataRow> impById = new Dictionary<int, DataRow>();
            Dictionary<int,DataRow> lastById = new Dictionary<int, DataRow>();
            foreach (DataRow r in  DS.Tables[tImp].Select()) {
                impById[(int) r[idfield]] = r;
            }
            foreach (DataRow r in DS.Tables[tLast].Select()) {
                lastById[(int) r[idfield]] = r;
            }

            foreach (DataRow rMov in DS.Tables[tName].Select()) {
                if (!viewMainMov) {
                    if (rMov["autokind"] == DBNull.Value) continue;
                    if (rMov.RowState != DataRowState.Added) continue;
                }

                DataRow rMovLocal = dsMov.Tables[vName].NewRow();

                string[] listaCampi = new string[] {idfield,parentidfield,  "idreg", "ymov", "nmov", "adate",
                    "description", "nphase"};
                foreach (string campo in listaCampi) {
                    rMovLocal[campo] = rMov[campo];
                }

                string phase = ottieniNomeFase(IoE, rMov["nphase"]);
                rMovLocal["phase"] = phase;
                rMovLocal["ayear"] = esercizio;

                if (rMov["idreg"] != DBNull.Value) {
                    object registry = Cache.registry.ReadValuesFor(rMov["idreg"])["title"];
                    //Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", rMov["idreg"]), "title");
                    if (registry != DBNull.Value) rMovLocal["registry"] = registry;

                }

                if (IoE == "I") {
                    //string f_underwriting = QHS.CmpEq("idunderwriting", rMov["idunderwriting"]);
                    rMovLocal["idunderwriting"] = rMov["idunderwriting"];

                    object code_underwriting = Cache.underwriting.ReadValuesFor(rMov["idunderwriting"])["codeunderwriting"];
                    //Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                    rMovLocal["!codeunderwriting"] = code_underwriting;

                    object title_underwriting = Cache.underwriting.ReadValuesFor(rMov["idunderwriting"])["title"];
                    //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                    rMovLocal["!underwriting"] = title_underwriting;
                }


                DataRow rMovYear;
                if (impById.TryGetValue((int) rMov[idfield], out rMovYear)) {
                    DataRow r = rMovYear;
                    if (r["idfin"] != DBNull.Value) {
                        object codeFin = Cache.fin.ReadValuesFor(r["idfin"])["codefin"];
                        //Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", r["idfin"]), "codefin");
                        object Finance = Cache.fin.ReadValuesFor(r["idfin"])["title"];
                        //Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", r["idfin"]), "title");
                        if (codeFin != DBNull.Value) rMovLocal["codefin"] = codeFin;
                        if (Finance != DBNull.Value) rMovLocal["finance"] = Finance;
                    }

                    if (r["idupb"] != DBNull.Value) {
                        rMovLocal["idupb"] = r["idupb"] ;
                        object codeUpb = Cache.upb.ReadValuesFor(r["idupb"])["codeupb"];
                        //Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", r["idupb"]), "codeupb");
                        if (codeUpb != DBNull.Value) rMovLocal["codeupb"] = codeUpb;
                    }
                    rMovLocal["amount"] = r["amount"];
                    rMovLocal["curramount"] = r["amount"];
                }

             

                DataRow  rMovLast ;
                if (lastById.TryGetValue((int) rMov[idfield], out rMovLast)) {
                    if (rMov["nphase"].ToString() == fasemax.ToString()) {
                        DataRow r = rMovLast;
                        rMovLocal["nbill"] = r["nbill"];
                    }
                }

              
                rMovLocal["ct"] = DateTime.Now;
                rMovLocal["cu"] = "-";
                rMovLocal["lt"] = DateTime.Now;
                rMovLocal["lu"] = "-";

                dsMov.Tables[vName].Rows.Add(rMovLocal);
                rMovLocal.AcceptChanges();
            }
        }

        private void popolaVariazione(string IoE) {
            string tName = (IoE == "I") ? "incomevar" : "expensevar";
            string vName = tName + "view";
            string tPhaseName = tName + "phase";
            string tMov = (IoE == "I") ? "incomeview" : "expenseview";
            string idfield = (IoE == "I") ? "idinc" : "idexp";

            if (IoE=="E") Cache.underwriting.ReadValuesRelatedTo(DS.Tables[tName], "idunderwriting");

            foreach (DataRow rVar in DS.Tables[tName].Select()) {
                //				if (rVar["autokind"] == DBNull.Value) continue;

                DataRow rVarLocal = dsMov.Tables[vName].NewRow();

                string[] listaCampi;
                if (IoE == "I")
                    listaCampi = new string[] {idfield, "nvar", "yvar",
                    "amount", "adate", "description"};
                else
                    listaCampi = new string[] {idfield, "nvar", "yvar",
                    "amount", "adate", "description","idunderwriting"};

                foreach (string campo in listaCampi) {
                    rVarLocal[campo] = rVar[campo];
                }

                object nPhase = IoE == "E"
                    ? Cache.GetCachedExpensePhase(Conn, dsMov.Tables[tMov], CfgFn.GetNoNullInt32(rVar["idexp"]))
                    : Cache.GetCachedIncomePhase(Conn, dsMov.Tables[tMov], CfgFn.GetNoNullInt32(rVar["idinc"]));

                //DataRow [] MOV = dsMov.Tables[tMov].Select(QHC.CmpEq("idexp", rVar["idexp"]));
                //if (MOV.Length > 0) {
                //    nPhase = MOV[0]["nphase"];
                //}
                //else {
                //    string fSQL = QHS.CmpEq("idexp", rVar["idexp"]);
                //    nPhase =  Conn.DO_READ_VALUE(tMov, fSQL, "nphase"); 
                //}

                string phase = ottieniNomeFase(IoE, nPhase);

                if (IoE == "E") {
                    object idunderwriting = rVar["idunderwriting"];
                    //string f_underwriting = QHS.CmpEq("idunderwriting", rVar["idunderwriting"]);
                    object code_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["codeunderwriting"];
                    //Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                    rVarLocal["!codeunderwriting"] = code_underwriting;

                    object title_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["title"];
                    //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                    rVarLocal["!underwriting"] = title_underwriting;
                }


                rVarLocal["ymov"] = Conn.GetSys("esercizio");
                rVarLocal["nmov"] = 1;
                rVarLocal["nphase"] = nPhase;
                rVarLocal["phase"] = phase;
                rVarLocal["ct"] = DateTime.Now;
                rVarLocal["cu"] = "-";
                rVarLocal["lt"] = DateTime.Now;
                rVarLocal["lu"] = "-";

                dsMov.Tables[vName].Rows.Add(rVarLocal);
                rVarLocal.AcceptChanges();
            }

        }

        private string ottieniNomeFase(string IoE, object nphase) {
            if (IoE == "I") {
                return Cache.incomephase.ReadValuesFor(nphase)["description"].ToString();
            }
            else {
                return Cache.expensephase.ReadValuesFor(nphase)["description"].ToString();
            }

            //string tName = (IoE == "I") ? "incomephase" : "expensephase";
            //object descrPhase = Conn.DO_READ_VALUE(tName, QHS.CmpEq("nphase", nphase), "description");
            //string phase = (descrPhase == null) ? "" : descrPhase.ToString();
            //return phase;
        }

        /// <summary>
        /// Metodo che imposta le caption dei grid
        /// </summary>
        /// <param name="IoE">I = Income; E = Expense</param>
        /// <param name="MoV">M = Movimento; V = Variazione</param>
        private void impostaCaption(string IoE, string MoV) {
            string tName = (IoE == "I") ? "incomeview" : "expenseview";
            if (MoV == "V") {
                tName = (IoE == "I") ? "incomevarview" : "expensevarview";
            }

            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["phase"].Caption = "Fase";
            string anagrafica = (IoE == "I") ? "Versante" : "Percipiente";
            if (MoV == "M") {
                dsMov.Tables[tName].Columns["registry"].Caption = anagrafica;
                dsMov.Tables[tName].Columns["codefin"].Caption = "Cod. Bilancio";
                dsMov.Tables[tName].Columns["finance"].Caption = "Bilancio";
                dsMov.Tables[tName].Columns["codeupb"].Caption = "UPB";
                dsMov.Tables[tName].Columns["idupb"].Caption = ".#UPB";
            }

            if (MoV == "M" && IoE == "I") {
                dsMov.Tables[tName].Columns["!codeunderwriting"].Caption = "Cod. Finanziamento";
                dsMov.Tables[tName].Columns["!underwriting"].Caption = "Finanziamento";
                dsMov.Tables[tName].Columns["nbill"].Caption = "bolletta";

            }
            if (MoV == "V" && IoE == "E") {
                dsMov.Tables[tName].Columns["!codeunderwriting"].Caption = "Cod. Finanziamento";
                dsMov.Tables[tName].Columns["!underwriting"].Caption = "Finanziamento";
            }


            dsMov.Tables[tName].Columns["description"].Caption = "Descrizione";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";


        }

        private void impostaCaptionClass(string IoE) {
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["!sorting"].Caption = "Cod. Class.";
            dsMov.Tables[tName].Columns["!sortcode"].Caption = "Classificazione";
            dsMov.Tables[tName].Columns["idsubclass"].Caption = "Sub Movim.";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";
            dsMov.Tables[tName].Columns["values1"].Caption = "Cod.UE";
            if (IoE == "E") {
                dsMov.Tables[tName].Columns["values2"].Caption = "Cod.COFOG";
            }
        }

        private DataRow cambiaDescrizione(DataGrid dg, bool askFinanziamento, bool askBolletta) {
            DataRow row = ottieniRiga(dg);
            if (row == null) return null;
            if (row.Table.ToString() == "incomeview") {
                if (row["nphase"].ToString() != Conn.GetSys("assessmentphase").ToString())
                    askFinanziamento = false;
            }
            if (row.Table.TableName == "expenseview" && row["nphase"].ToString() != maxexpensephase.ToString()) {
                askBolletta = false;
            }
            if (row.Table.TableName == "incomeview" && row["nphase"].ToString() != maxincomephase.ToString()) {
                askBolletta = false;
            }

            AskDescription fAsk = new AskDescription(row, 0, askFinanziamento, askBolletta, Disp, Conn);
            DialogResult dr = fAsk.ShowDialog();
            if (dr != DialogResult.OK) return null;
            string descrMov = fAsk.txtDescrizione.Text;
            string oldDescription = row["description"].ToString();
            object idunderwriting = DBNull.Value;
            object oldIdunderwriting = DBNull.Value;
            if (askFinanziamento) {
                idunderwriting = fAsk.UnderWritingSelected;
                if (idunderwriting == null) idunderwriting = DBNull.Value;
                oldIdunderwriting = row["idunderwriting"];
            }
            object idbolletta = DBNull.Value;
            object oldIdbolletta = DBNull.Value;
            if (askBolletta) {
                idbolletta = fAsk.BillSelected;
                if (idbolletta == null) {
                    idbolletta = DBNull.Value;
                }
                oldIdbolletta = row["nbill"];
            }

            if (oldDescription == descrMov && oldIdunderwriting.ToString() == idunderwriting.ToString()
                        && oldIdbolletta.ToString() == idbolletta.ToString()
                    )
                return null;
            if (descrMov.Length > 150) {
                row["description"] = descrMov.Substring(0, 150);
            }
            else {
                row["description"] = descrMov;
            }
            if (askFinanziamento) {
                row["idunderwriting"] = idunderwriting;
                if (row.Table.ToString() == "incomeview")
                    CambiaIncassoFiglioDi(row);
            }

            if (askBolletta) {
                row["nbill"] = idbolletta;
            }
            return row;
        }

        private void CambiaIncassoFiglioDi(DataRow row) {
            DataRow[] rChilds = ottieniFigli(row);
            foreach (DataRow rChild in rChilds) {
                rChild["idunderwriting"] = row["idunderwriting"];
                CambiaIncassoFiglioDi(rChild);
            }
        }




        private DataRow[] ottieniFigli(DataRow row) {
            string filter = (row.Table.TableName.StartsWith("expense")) ?
                QHC.CmpEq("parentidexp", row["idexp"]) :
                QHC.CmpEq("parentidinc", row["idinc"]);
            DataRow[] rChilds = row.Table.Select(filter);
            return rChilds;
        }


       private DataRow[] ImpClassChilds(DataRow row) {
          
            string filterChilds =QHC.AppAnd( QHC.CmpEq("paridsor", row["idsor"]),QHC.CmpEq("paridsubclass", row["idsubclass"]),
                (row.Table.TableName.StartsWith("expense")) ?
                QHC.CmpEq("idexp", row["idexp"]) :
                QHC.CmpEq("idinc", row["idinc"]));

             DataRow[] rChilds = row.Table.Select(filterChilds);
             return rChilds;
        }


        private DataRow ottieniRiga(DataGrid dg) {
            DataSet DSV = (DataSet)dg.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[dg.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView)dg.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null) return null;
            DataRow R = DV.Row;
            return R;
        }

        private void dgSpesa_DoubleClick(object sender, System.EventArgs e) {
            DataRow row = cambiaDescrizione(dgSpesa, false, true);
            allineaDescrizioneInDS("E", "M", row);
        }

        private void dgEntrata_DoubleClick(object sender, System.EventArgs e) {
            DataRow row = cambiaDescrizione(dgEntrata, true, true);
            allineaDescrizioneInDS("I", "M", row);
        }

        private void dgVarEntrata_DoubleClick(object sender, System.EventArgs e) {
            DataRow row = cambiaDescrizione(dgVarEntrata, false, false);
            allineaDescrizioneInDS("I", "V", row);
        }

        private void dgVarSpesa_DoubleClick(object sender, System.EventArgs e) {
            DataRow row = cambiaDescrizione(dgVarSpesa, true, false);
            allineaDescrizioneInDS("E", "V", row);
        }


        private void aggiornaClassificazioni(string IoE, DataRow rMov, DataGrid dgClass) {
            string tNameSource = (IoE == "I") ? "incomesorted" : "expensesorted";
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";
            string idfield = (IoE == "I") ? "idinc" : "idexp";
            
            object codesorkind_siope = (IoE == "I")
			? Conn.Security.GetSys("codesorkind_siopeentrate")
			: Conn.Security.GetSys("codesorkind_siopespese");
			object idsorkind_siope = Conn.readValue("sortingkind", q.eq("codesorkind", codesorkind_siope), "idsorkind");

            string filter = QHC.CmpEq(idfield, rMov[idfield]);
            DataRow[] Classificazioni = DS.Tables[tNameSource].Select(filter);

            dsMov.Tables[tName].Clear();

            Cache.sorting.ReadValuesRelatedTo(Classificazioni, "idsor");

            foreach (DataRow rClass in Classificazioni) {
                DataRow rClassDest = dsMov.Tables[tName].NewRow();
                foreach (DataColumn C in DS.Tables[tNameSource].Columns) {
                    if (!dsMov.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rClassDest[C.ColumnName] = rClass[C];
                }
                rClassDest["!ymov"] = rMov["ymov"];
                rClassDest["!nmov"] = rMov["nmov"];
                rClassDest["!nphase"] = rMov["nphase"];
                rClassDest["!phase"] = ottieniNomeFase(IoE, rMov["nphase"]);
                rClassDest["!idfin"] = rMov["idfin"];
                rClassDest["!codefin"] = rMov["codefin"];
                rClassDest["!idupb"] = rMov["idupb"];
                rClassDest["!codeupb"] = rMov["codeupb"];
                rClassDest["!adate"] = rMov["adate"];
                object idsor = rClass["idsor"];
                //string f_sorting = QHS.CmpEq("idsor", rClass["idsor"]);
                object descr_sor = Cache.sorting.ReadValuesFor(idsor)["sortcode"];
                //Conn.DO_READ_VALUE("sorting", f_sorting, "sortcode");
                rClassDest["!sortcode"] = descr_sor;

                object idsorkind = Cache.sorting.ReadValuesFor(idsor)["idsorkind"];

                //Conn.DO_READ_VALUE("sorting", f_sorting, "idsorkind");
                //string f_sortingkind = QHS.CmpEq("idsorkind", idsorkind);
                object descr_sorkind = Cache.sortingkind.ReadValuesFor(idsorkind)["description"];
                //Conn.DO_READ_VALUE("sortingkind",f_sortingkind, "description");
                rClassDest["!sorting"] = descr_sorkind;

                dsMov.Tables[tName].Rows.Add(rClassDest);
                // Solo per Siope
                if ((idsorkind.ToString() == idsorkind_siope.ToString())&&(IoE == "E"))
                {
            //         MetaFactory.factory.getSingleton<IMessageShower>().Show(
				        // "UPB" + rMov["idupb"].ToString() +  "Cod" + rMov["codeupb"] +  "idsorkind"+ idsorkind.ToString()  +"idsorkind_siope"+ idsorkind_siope.ToString()
				        //,
				        //"Avviso", 
				        //MessageBoxButtons.OK);
                    object uesiopecode = Cache.upb.ReadValuesFor(rMov["idupb"])["uesiopecode"];
                    object cofogmpcode = Cache.upb.ReadValuesFor(rMov["idupb"])["cofogmpcode"];
                    rClassDest["values1"] = uesiopecode;
                    rClassDest["values2"] = cofogmpcode;
                }
                rClassDest.AcceptChanges();
            }

            HelpForm.SetDataGrid(dgClass, dsMov.Tables[tName]);
        }

        private void btnInsertClassE_Click(object sender, System.EventArgs e) {
            DataRow Parent = ottieniRiga(dgSpesa);
            if (Parent == null) return;
            DataRow rClass = InsertDataRow("E", "all", dsMov.Tables["expensesorted"], Parent, dgClassSpesa);

            MetaData metaExp = Disp.Get("expense");
            if (rClass!=null){ 
                List <DataRow> autoR = CalcAutoClasses(metaExp, "expense", rClass, Parent);

                allineaDatiInDS("E", rClass);
                foreach(DataRow auto in autoR) {
                    allineaDatiInDS("E", auto);
                }
            }
            aggiornaClassificazioni("E", Parent, dgClassSpesa);
        }

        private void btnUpdateClassE_Click(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgClassSpesa);
            DataRow rMov = ottieniRiga(dgSpesa);
            if ((row == null) || (rMov == null)) return;
            DataRow newRow;
            bool res = EditDataRow("E", row, "all", out newRow);
            if (res) {

                  if (ImpClassChilds(newRow).Length>0) {
			            MetaFactory.factory.getSingleton<IMessageShower>().Show(
				        "La classificazione selezionata non può essere modificata poiché ci sono classificazioni "
				        +" subordinate ad essa. Per cambiarne i dati sarà necessario rimuoverla."
				        ,
				        "Avviso", 
				        MessageBoxButtons.OK);
			        return;
			    }

                allineaDatiInDS("E", newRow);
                aggiornaClassificazioni("E", rMov, dgClassSpesa);
            }
        }

        private void btnDeleteClassE_Click(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgClassSpesa);
            if (row == null) return;
             if (ImpClassChilds(row).Length>0) {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata e le relative subordinate?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}
			else {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}

            DeleteImpClassMov(row,"E");
            

            allineaDatiInDS("E", row);
            HelpForm.SetDataGrid(dgClassSpesa, dsMov.Tables["expensesorted"]);
        }

        private void btnInsertClassI_Click(object sender, System.EventArgs e) {
            DataRow Parent = ottieniRiga(dgEntrata);
            if (Parent == null) return;
            DataRow rClass = InsertDataRow("I", "all", dsMov.Tables["incomesorted"], Parent, dgClassEntrata);

            MetaData metaInc = Disp.Get("income");
            if (rClass != null) {
                List<DataRow> autoR = CalcAutoClasses(metaInc, "income", rClass, Parent);

                allineaDatiInDS("I", rClass);
                foreach (DataRow auto in autoR) {
                    allineaDatiInDS("I", auto);
                }
            }
            aggiornaClassificazioni("I", Parent, dgClassEntrata);
        }
 

        private void btnUpdateClassI_Click(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgClassEntrata);
            DataRow rMov = ottieniRiga(dgEntrata);
            if ((row == null) || (rMov == null)) return;
            DataRow newRow;
            bool res = EditDataRow("I", row, "all", out newRow);
            if (res) {
                  if (ImpClassChilds(newRow).Length>0) {
			            MetaFactory.factory.getSingleton<IMessageShower>().Show(
				        "La classificazione selezionata non può essere modificata poiché ci sono classificazioni "
				        +" subordinate ad essa. Per cambiarne i dati sarà necessario rimuoverla."
				        ,
				        "Avviso", 
				        MessageBoxButtons.OK);
			        return;
			    }
                allineaDatiInDS("I", newRow);
                aggiornaClassificazioni("I", rMov, dgClassEntrata);
            }
        }


        /// <summary>
		/// Deletes impclassspesa with all sub-autoclasses
		/// </summary>
		/// <param name="R"></param>
		void DeleteImpClassMov(DataRow R, string kind ) {
			DataRow [] Childs =  ImpClassChilds(R);
			foreach (DataRow Child in Childs) {
				DeleteImpClassMov(Child,kind);
                allineaDatiInDS(kind, Child);
			}
             
			R.Delete();
		}

        private void btnDeleteClassI_Click(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgClassEntrata);
            if (row == null) return;
            if (ImpClassChilds(row).Length>0) {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata e le relative subordinate?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}
			else {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}

			DeleteImpClassMov(row,"I");
    
            allineaDatiInDS("I", row);
            HelpForm.SetDataGrid(dgClassEntrata, dsMov.Tables["incomesorted"]);
        }

        /// <summary>
        /// Edits a datarow using a specified listig type. Also Extra parameter
        ///  of R.Table is considered.
        /// </summary>
        /// <param name="R"></param>
        /// <param name="edit_type"></param>
        /// <returns>true if row has been modified</returns>
        public bool EditDataRow(string IoEoCoS, DataRow R, string edit_type, out DataRow newRow) {
            newRow = R;
            string tName;
            switch (IoEoCoS) {
                case "I":
                    tName = "incomesorted";
                    break;
                case "E":
                    tName = "expensesorted";
                    break;
                case "C":
                    tName = "underwritingappropriation";
                    break;
                case "S":
                    tName = "underwritingpayment";
                    break;
                default: throw new Exception("Errore in EditDataRow");
            }
            DataTable SourceTable = R.Table;
            MetaData M = Disp.Get(DS.Tables[tName].TableName);
            if (M == null) return false;
            M.SetDefaults(SourceTable);
            M.SetSource(R);

            M.Edit(this, edit_type, true);
            if (M.entityChanged) {
                newRow = M.NewSourceRow;
            }
            return M.entityChanged;
        }

        public DataRow InsertDataRow(string IoE, string edit_type, DataTable SourceTable, DataRow Parent, DataGrid dg) {
            MetaData M = Disp.Get(SourceTable.TableName);

            M.SetDefaults(SourceTable);
            MetaData.SetDefault(SourceTable, "amount", Parent["amount"]);
            DataRow R = M.Get_New_Row(Parent, SourceTable);
            if (R == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "La tabella " + SourceTable.TableName +
                    " contiene dati non validi. Contattare il servizio di assistenza.");
                return null;
            }

            M.SetSource(R);

            M.Edit(this, edit_type, true);

            if (!M.entityChanged) {
                R.Delete();
                R = null;
            }
            else {
                R = M.NewSourceRow;
            }

            return R;
        }

        private void allineaDatiInDS(string IoEoCoS, DataRow rData) {
            if (rData == null) return;

            string tName;
            switch (IoEoCoS) {
                case "I":
                    tName = "incomesorted";
                    break;
                case "E":
                    tName = "expensesorted";
                    break;
                case "C":
                    tName = "underwritingappropriation";
                    break;
                case "S":
                    tName = "underwritingpayment";
                    break;
                default: throw new Exception("Errore in allineaDatiInDS");
            }

            DataRowVersion toConsider = DataRowVersion.Default;
            switch (rData.RowState) {
                case DataRowState.Added:
                    {
                        toConsider = DataRowVersion.Current;
                        break;
                    }
                case DataRowState.Modified:
                    {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
                case DataRowState.Deleted:
                    {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
            }

            string filter = QueryCreator.WHERE_KEY_CLAUSE(rData, toConsider, false);

            DataRow[] Data = DS.Tables[tName].Select(filter);
            if (Data.Length == 0) {
                DataRow rDataDS = DS.Tables[tName].NewRow();
                foreach (DataColumn C in rData.Table.Columns) {
                    if (!DS.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rDataDS[C.ColumnName] = rData[C];
                }
                DS.Tables[tName].Rows.Add(rDataDS);
            }
            else {
                if (rData.RowState == DataRowState.Deleted) {
                    Data[0].Delete();
                }
                else {
                    foreach (DataColumn C in rData.Table.Columns) {
                        if (!DS.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                        Data[0][C.ColumnName] = rData[C];
                    }
                }
            }
            rData.AcceptChanges();
        }

        private void allineaDescrizioneInDS(string IoE, string MoV, DataRow rMov) {
            if (rMov == null) return;
            string tName = (IoE == "I") ? "income" : "expense";
            if (MoV == "V") {
                tName = (IoE == "I") ? "incomevar" : "expensevar";
            }
            DataRowVersion toConsider = DataRowVersion.Default;
            switch (rMov.RowState) {
                case DataRowState.Added:
                    {
                        toConsider = DataRowVersion.Current;
                        break;
                    }
                case DataRowState.Modified:
                    {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
                case DataRowState.Deleted:
                    {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
            }
            string filter = QueryCreator.WHERE_KEY_CLAUSE(rMov, toConsider, false);
            DataRow[] MOV = DS.Tables[tName].Select(filter);
            if (MOV.Length == 0) return;
            MOV[0]["description"] = rMov["description"];
            if (IoE == "I" && MoV == "M") {
                object idunderwriting = rMov["idunderwriting"];
                //string f_underwriting = QHS.CmpEq("idunderwriting", rMov["idunderwriting"]);
                object code_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["codeunderwriting"];
                // Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                object title_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["title"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");

                AggiornaIdUnderwritingIncomeInDS(rMov["idinc"], rMov["idunderwriting"], code_underwriting, title_underwriting, rMov.Table);

                AggiornaNbillIncomeInDS(rMov["idinc"], rMov["nbill"], rMov.Table);
            }

            if (IoE == "E" && MoV == "M") {
                AggiornaNbillExpenseInDS(rMov["idexp"], rMov["nbill"], rMov.Table);
            }

            if (IoE == "E" && MoV == "V") {
                object idunderwriting = rMov["idunderwriting"];
                MOV[0]["idunderwriting"] = idunderwriting;

                //string f_underwriting = QHS.CmpEq("idunderwriting", MOV[0]["idunderwriting"]);
                object code_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["codeunderwriting"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                rMov["!codeunderwriting"] = code_underwriting;

                object title_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["title"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                rMov["!underwriting"] = title_underwriting;

            }
            rMov.AcceptChanges();
        }

        void AggiornaIdUnderwritingIncomeInDS(object idinc, object idunderwriting, object code_underwriting, object title_underwriting,
                                DataTable Temp) {
            DataRow[] MOV = DS.Tables["income"].Select(QHC.CmpEq("idinc", idinc));
            DataRow[] tempMOV = Temp.Select(QHC.CmpEq("idinc", idinc));
            if (MOV.Length == 0) return;
            DataRow r = MOV[0];
            r["idunderwriting"] = idunderwriting;


            DataRow rTemp = tempMOV[0];
            rTemp["!codeunderwriting"] = code_underwriting;
            rTemp["!underwriting"] = title_underwriting;
            foreach (DataRow rchild in DS.Tables["income"].Select(QHC.CmpEq("parentidinc", idinc))) {
                AggiornaIdUnderwritingIncomeInDS(rchild["idinc"], idunderwriting, code_underwriting, title_underwriting, Temp);
            }

        }

        void AggiornaNbillIncomeInDS(object idinc, object nbill, DataTable Temp) {
            DataRow[] MOV = DS.Tables["incomelast"].Select(QHC.CmpEq("idinc", idinc));
            DataRow[] tempMOV = Temp.Select(QHC.CmpEq("idinc", idinc));
            if (MOV.Length == 0) return;
            DataRow r = MOV[0];
            r["nbill"] = nbill;
            int flag = CfgFn.GetNoNullInt32(r["flag"]);
            if (nbill == DBNull.Value) {
                r["flag"] = flag & 0xFFFE;
            }
            else {
                r["flag"] = flag | 1;
            }


        }


        void AggiornaNbillExpenseInDS(object idexp, object nbill, DataTable Temp) {
            DataRow[] MOV = DS.Tables["expenselast"].Select(QHC.CmpEq("idexp", idexp));
            DataRow[] tempMOV = Temp.Select(QHC.CmpEq("idexp", idexp));
            if (MOV.Length == 0) return;
            DataRow r = MOV[0];
            r["nbill"] = nbill;
            int flag = CfgFn.GetNoNullInt32(r["flag"]);
            if (nbill == DBNull.Value) {
                r["flag"] = flag & 0xFFFE;
            }
            else {
                r["flag"] = flag | 1;
            }

        }


        private void dgSpesa_CurrentCellChanged(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgSpesa);
            if (row == null) return;
            aggiornaClassificazioni("E", row, dgClassSpesa);
            aggiornaCrediti(row, dgCrediti);
            aggiornaCassa(row, dgCassa);
        }

        private void dgEntrata_CurrentCellChanged(object sender, System.EventArgs e) {
            DataRow row = ottieniRiga(dgEntrata);
            if (row == null) return;
            aggiornaClassificazioni("I", row, dgClassEntrata);
        }
        private void impostaCaptionCrediti() {
            string tName = "underwritingappropriation";
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["!codeunderwriting"].Caption = "Cod. Finanziamento";
            dsMov.Tables[tName].Columns["!underwriting"].Caption = "Finanziamento";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";
        }
        private void impostaCaptionCassa() {
            string tName = "underwritingpayment";
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["!codeunderwriting"].Caption = "Cod. Finanziamento";
            dsMov.Tables[tName].Columns["!underwriting"].Caption = "Finanziamento";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";
        }



        private void aggiornaCrediti(DataRow rMov, DataGrid dgCrediti) {
            string tNameSource = "underwritingappropriation";
            string tName = "underwritingappropriation";
            string idfield = "idexp";

            string filter = QHC.CmpEq(idfield, rMov[idfield]);
            DataRow[] Crediti = DS.Tables[tNameSource].Select(filter);

            dsMov.Tables[tName].Clear();
            Cache.underwriting.ReadValuesRelatedTo(Crediti, "idunderwriting");

            foreach (DataRow rCred in Crediti) {
                DataRow rCredDest = dsMov.Tables[tName].NewRow();
                foreach (DataColumn C in DS.Tables[tNameSource].Columns) {
                    if (!dsMov.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rCredDest[C.ColumnName] = rCred[C];
                }
                object idunderwriting = rCred["idunderwriting"];

                //string f_underwriting = QHS.CmpEq("idunderwriting", rCred["idunderwriting"]);
                object code_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["codeunderwriting"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                rCredDest["!codeunderwriting"] = code_underwriting;

                object title_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["title"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                rCredDest["!underwriting"] = title_underwriting;

                dsMov.Tables[tName].Rows.Add(rCredDest);
                rCredDest.AcceptChanges();
            }

            HelpForm.SetDataGrid(dgCrediti, dsMov.Tables[tName]);
        }

        private void aggiornaCassa(DataRow rMov, DataGrid dgCassa) {
            string tNameSource = "underwritingpayment";
            string tName = "underwritingpayment";
            string idfield = "idexp";

            string filter = QHC.CmpEq(idfield, rMov[idfield]);
            DataRow[] Cassa = DS.Tables[tNameSource].Select(filter);

            dsMov.Tables[tName].Clear();
            Cache.underwriting.ReadValuesRelatedTo(Cassa, "idunderwriting");
            foreach (DataRow rCassa in Cassa) {
                DataRow rCassaDest = dsMov.Tables[tName].NewRow();
                foreach (DataColumn C in DS.Tables[tNameSource].Columns) {
                    if (!dsMov.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rCassaDest[C.ColumnName] = rCassa[C];
                }

                object idunderwriting = rCassa["idunderwriting"];

                //string f_underwriting = QHS.CmpEq("idunderwriting", rCassa["idunderwriting"]);
                object code_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["codeunderwriting"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                rCassaDest["!codeunderwriting"] = code_underwriting;

                object title_underwriting = Cache.underwriting.ReadValuesFor(idunderwriting)["title"];
                //Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                rCassaDest["!underwriting"] = title_underwriting;

                dsMov.Tables[tName].Rows.Add(rCassaDest);
                rCassaDest.AcceptChanges();
            }

            HelpForm.SetDataGrid(dgCassa, dsMov.Tables[tName]);
        }

        private void btnAddFinanziamentoCrediti_Click(object sender, EventArgs e) {
            DataRow Parent = ottieniRiga(dgSpesa);
            if (Parent == null) return;

            int nphase = CfgFn.GetNoNullInt32(Parent["nphase"]);
            if (nphase != expensefinphase) return;

            DataRow rCred = InsertDataRow("C", "detail", dsMov.Tables["underwritingappropriation"], Parent, dgCrediti);
            allineaDatiInDS("C", rCred);
            aggiornaCrediti(Parent, dgCrediti);
        }

        private void btnAddFinanziamentoCassa_Click(object sender, EventArgs e) {
            DataRow Parent = ottieniRiga(dgSpesa);
            if (Parent == null) return;

            int nphase = CfgFn.GetNoNullInt32(Parent["nphase"]);
            if (nphase != expensepaymentphase) return;

            DataRow rCred = InsertDataRow("S", "detail", dsMov.Tables["underwritingpayment"], Parent, dgCassa);
            allineaDatiInDS("S", rCred);
            aggiornaCassa(Parent, dgCassa);
        }

        private void btnEditFinanziamentoCrediti_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgCrediti);
            DataRow rMov = ottieniRiga(dgSpesa);
            if ((row == null) || (rMov == null)) return;
            DataRow newRow;
            bool res = EditDataRow("C", row, "detail", out newRow);

            if (res) {
                allineaDatiInDS("C", newRow);
                aggiornaCrediti(rMov, dgCrediti);
            }
        }

        private void btnEditFinanziamentoCassa_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgCassa);
            DataRow rMov = ottieniRiga(dgSpesa);
            if ((row == null) || (rMov == null)) return;
            DataRow newRow;
            bool res = EditDataRow("S", row, "detail", out newRow);

            if (res) {
                allineaDatiInDS("S", newRow);
                aggiornaCassa(rMov, dgCassa);
            }
        }

        private void btnDelFinanziamentoCrediti_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgCrediti);
            if (row == null) return;
            row.Delete();
            allineaDatiInDS("C", row);
            HelpForm.SetDataGrid(dgCrediti, dsMov.Tables["underwritingappropriation"]);
        }

        private void btnDelFinanziamentoCassa_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgCassa);
            if (row == null) return;
            row.Delete();
            allineaDatiInDS("S", row);
            HelpForm.SetDataGrid(dgCassa, dsMov.Tables["underwritingpayment"]);
        }



        List<DataRow> CalcAutoClasses(MetaData Meta, string tableName, DataRow CurrImpClass, DataRow MovView) {
            List<DataRow> result = new List<DataRow>();
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            DataTable ImpClass = CurrImpClass.Table;
            string idmovimento;
            string codicefase;
            if (tableName == "expense") {
                //VarMovimento = Meta.DS.Tables["expensevar"];
                idmovimento = "idexp";
                codicefase = "nphaseexpense";
            }
            else {
                //VarMovimento = Meta.DS.Tables["incomevar"];
                idmovimento = "idinc";
                codicefase = "nphaseincome";
            }


            string filteridexp = QHC.CmpEq(idmovimento, CurrImpClass[idmovimento]);
            decimal curramount = CfgFn.GetNoNullDecimal(MovView["amount"]);
            int currfase = CfgFn.GetNoNullInt32(MovView["nphase"]);
            object IDForSP = DBNull.Value;
            DataSet OutDS;
            try {
                OutDS = Meta.Conn.CallSP("create_autoclasses_" + tableName,
                    new object[]{
                                    Meta.GetSys("esercizio"),
                                    DBNull.Value,
                                    MovView["idreg"],
                                    MovView["idupb"],
                                    currfase,
                                    MovView["idfin"],
                                    MovView["idman"],
                                    curramount,
                                    //CurrImpClass["idsorkind"],
									CurrImpClass["idsor"],
                                    CurrImpClass["idsubclass"],
                                    CurrImpClass["amount"],
                                    CurrImpClass["description"],
                                    CurrImpClass["flagnodate"],
                                    CurrImpClass["tobecontinued"],
                                    CurrImpClass["start"],
                                    CurrImpClass["stop"],
                                    CurrImpClass["valuen1"],
                                    CurrImpClass["valuen2"],
                                    CurrImpClass["valuen3"],
                                    CurrImpClass["valuen4"],
                                    CurrImpClass["valuen5"],
                                    CurrImpClass["values1"],
                                    CurrImpClass["values2"],
                                    CurrImpClass["values3"],
                                    CurrImpClass["values4"],
                                    CurrImpClass["values5"],
                                    CurrImpClass["valuev1"],
                                    CurrImpClass["valuev2"],
                                    CurrImpClass["valuev3"],
                                    CurrImpClass["valuev4"],
                                    CurrImpClass["valuev5"]
                                });
            }
            catch (Exception E) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
                return result;
            }
            if ((OutDS == null) || (OutDS.Tables.Count == 0)) return result; //no autoclass

            //AbilitaSubMovimenti();
            RowChange.MarkAsAutoincrement(ImpClass.Columns["idsubclass"], null, null, 7, false);
            RowChange.SetSelector(ImpClass, idmovimento);
            RowChange.SetSelector(ImpClass, "idsor");


            string filtercl = "";

            filtercl = QHS.CmpEq(codicefase, currfase);
            filtercl = QHS.AppAnd(filtercl, QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
            DataTable TipoClassMovimenti = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filtercl, null, true);
            if (TipoClassMovimenti == null) return result;

            DataTable TipoClassAllowed = CalcTipoClassAllowed(Meta.Conn, tableName, MovView, CurrImpClass, TipoClassMovimenti);
            if (TipoClassAllowed == null) return result;

            DataTable AutoClasses = OutDS.Tables[0];
            //for every row in OutDS.Tables[0]:
            // - add row to impclassspesa
            // - evaluates temporary AutoIncrement fields
            foreach (DataRow AutoClass in AutoClasses.Rows) {
                object idSorKind = AutoClass["idsorkind"];

                if (TipoClassAllowed.Select(QHC.CmpEq("idsorkind", idSorKind)).Length == 0) continue;
                DataRow MyDR = ImpClass.NewRow();
                foreach (DataColumn DC in ImpClass.Columns) {
                    if (DC.ColumnName.StartsWith("!")) continue;
                    if (!ImpClass.Columns.Contains(DC.ColumnName)) continue;
                    MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
                }
                ///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
                if (MyDR[idmovimento] == DBNull.Value)
                    MyDR[idmovimento] = MovView[idmovimento];
                RowChange.CalcTemporaryID(MyDR);
                ImpClass.Rows.Add(MyDR);
                result.Add(MyDR);
                CalcFlag(MyDR, AutoClass["idsorkind"]);
            }
            return result;

        }

        void CalcFlag(DataRow R, object idsorkind) {
            CQueryHelper QH = new CQueryHelper();
            DataSet DS = R.Table.DataSet;
            if (DS.Tables["sortingkind"] == null) return;
            string filtercodice = QH.CmpEq("idsorkind", idsorkind);
            DataRow[] tipoclass = DS.Tables["sortingkind"].Select(filtercodice);
            if (tipoclass.Length == 0) return; //??

            string filteridcodice = QH.CmpMulti(R, "idsor");
            DataRow[] classmov = DS.Tables["sorting"].Select(filteridcodice);
            if (classmov.Length == 0) return; //??

            DataRow CurrTipo = tipoclass[0];
            DataRow CurrClass = classmov[0];

            //Evaluates flagincompleto and checks forced columns to be not null
            bool flagincompleto = false;
            foreach (char C in new char[3] { 'n', 's', 'v' }) {
                for (int i = 1; i <= 5; i++) {
                    string suffix = C.ToString() + i.ToString();
                    if ((CurrTipo["forced" + suffix].ToString().ToLower() == "s") &&
                        (R["value" + C.ToString() + i.ToString()] == DBNull.Value)) {
                        flagincompleto = true;
                    }
                }
            }
            if ((CurrClass["flagnodate"].ToString().ToLower() == "n") &&
                (R["flagnodate"].ToString().ToLower() == "n")) {
                if (R["start"].ToString().Equals("")) flagincompleto = true;
                if (R["stop"].ToString().Equals("")) flagincompleto = true;

            }

            if ((flagincompleto) && (R["tobecontinued"].ToString().ToLower() == "")) {
                R["tobecontinued"] = "S";
            }


        }

        public static DataTable CalcTipoClassAllowed(DataAccess Conn, string table, DataRow MovView,
                       DataRow CurrImpClass, DataTable TipoClassMovimenti) {

            if (CurrImpClass.RowState == DataRowState.Deleted) return null;

            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            object idsorkind = Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", CurrImpClass["idsor"]), "idsorkind");
            string filter = QHS.CmpEq("idsorkind", idsorkind);
            DataRow[] CurrTipoClassS = TipoClassMovimenti.Select(filter);
            DataRow CurrTipoClass = null;
            if (CurrTipoClassS.Length > 0) CurrTipoClass = CurrTipoClassS[0];

            if (CurrTipoClass == null) return null;


            DataTable ImpClass = CurrImpClass.Table;
            string idmovimento;
            if (table == "expense") {
                //VarMovimento = Meta.DS.Tables["expensevar"];
                idmovimento = "idexp";
            }
            else {
                //VarMovimento = Meta.DS.Tables["incomevar"];
                idmovimento = "idinc";
            }


            string filteridexp = QHC.CmpEq(idmovimento, CurrImpClass[idmovimento]);
            decimal curramount = CfgFn.GetNoNullDecimal(MovView["amount"]);
            int currfase = CfgFn.GetNoNullInt32(MovView["nphase"]); ;
            object IDForSP = DBNull.Value;

            DataTable TipoClassAllowed = null;
            DataSet OutDS = null;


            string sp_root_tipo = "compute_root_sortingkind_" + table;

            //Calls sp_root_tipoclasses_spesa to get roots classes available
            OutDS = Conn.CallSP(sp_root_tipo,
                new object[8] {Conn.GetSys("esercizio"),
                                       IDForSP,
                                       MovView["idreg"],
                                       MovView["idupb"],
                                       MovView["nphase"],
                                       MovView["idfin"],
                                       MovView["idman"],
                                       curramount
                                   });

            if (OutDS != null && OutDS.Tables.Count > 0) {
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    TipoClassAllowed.Clear();
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }

            }

            //			DS.classmovimenti.Clear();
            //			DS.tipoclassmovimenti.Clear();
            //			QueryCreator.MergeDataTable(DS.tipoclassmovimenti, OutDS.Tables[0]);
            //			DS.tipoclassmovimenti.AcceptChanges();

            //foreach (DataRow CurrImpClass in ImpClass.Select(filteridexp)) {
            //    if (CurrImpClass.RowState == DataRowState.Deleted) continue;
            try {
                OutDS = Conn.CallSP(
                    "compute_filtered_sortingkind_" + table,
                    new object[32]{Conn.GetSys("esercizio"),
                                          IDForSP,
                                          MovView["idreg"],
                                          MovView["idupb"],
                                          currfase,
                                          MovView["idfin"],
                                          MovView["idman"],
                                          MovView["amount"],
                                          CurrTipoClass["idsorkind"],
                                          CurrImpClass["idsor"],
                                          CurrImpClass["idsubclass"],
                                          CurrImpClass["amount"],
                                          CurrImpClass["description"],
                                          CurrImpClass["flagnodate"],
                                          CurrImpClass["tobecontinued"],
                                          CurrImpClass["start"],
                                          CurrImpClass["stop"],
                                          CurrImpClass["valuen1"],
                                          CurrImpClass["valuen2"],
                                          CurrImpClass["valuen3"],
                                          CurrImpClass["valuen4"],
                                          CurrImpClass["valuen5"],
                                          CurrImpClass["values1"],
                                          CurrImpClass["values2"],
                                          CurrImpClass["values3"],
                                          CurrImpClass["values4"],
                                          CurrImpClass["values5"],
                                          CurrImpClass["valuev1"],
                                          CurrImpClass["valuev2"],
                                          CurrImpClass["valuev3"],
                                          CurrImpClass["valuev4"],
                                          CurrImpClass["valuev5"]
                                      });
            }
            catch (Exception E) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
            }
            if ((OutDS != null) && (OutDS.Tables.Count > 0)) {
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }
            }

            QueryCreator.MergeDataTable(TipoClassAllowed, TipoClassMovimenti);
            //foreach (DataRow CurrKind in TipoClassAllowed.Select(
            //    QHC.AppOr(QHC.CmpLt(codicefase, faseinizio), QHC.CmpGt(codicefase, fasemovfine))
            //    )) {
            //    CurrKind.Delete();
            //}
            TipoClassAllowed.AcceptChanges();
            return TipoClassAllowed;

        }
    }

}
