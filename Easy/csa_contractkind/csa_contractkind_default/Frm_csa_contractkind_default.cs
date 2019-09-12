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
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;

namespace csa_contractkind_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_contractkind_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        private GroupBox gboxtipo;
        private RadioButton rdbCompetenza;
        private RadioButton rdbResidui;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGrid dgrAttribuzioni;
        private Button btnPagElimina;
        private Button btnPagModifica;
        private Button btnPagInserisci;
        private TabPage tabPage2;
        private DataGrid dgrRegole;
        private Button button1;
        private Button button2;
        private Button button3;
		private System.ComponentModel.IContainer components;
        MetaData Meta;
        private TextBox textBox3;
        private Label label4;
        private CheckBox chkKeepAlive;
        private GroupBox groupBox1;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button5;
        private GroupBox grpBilancioVersamento;
        private TextBox txtDescrBilancio;
        private TextBox txtBilancio;
        private Button btnBilancio;
        private GroupBox gboxUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private CheckBox ckbAttivo;
        public GroupBox gboxclassSiope;
        public Button btnCodiceSiope;
        private TextBox txtDenomSiope;
        private TextBox txtCodiceSiope;
        private GroupBox groupBox3;
        private TextBox txtUnderwriting;
        private Button btnUnderwriting;
        private TabPage tabMain;
        public TextBox txtUPB;
        DataAccess Conn;
		public Frm_csa_contractkind_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.csa_contractkind.Columns["flagcr"], true);
            HelpForm.SetDenyNull(DS.csa_contractkind.Columns["active"], true);


            DS.csa_contractkinddata.ExtendedProperties["ViewTable"] = DS.csa_contractkinddataview;
            DS.sorting.ExtendedProperties["ViewTable"] = DS.csa_contractkinddataview;
            DS.fin.ExtendedProperties["ViewTable"] = DS.csa_contractkinddataview;
            DS.account.ExtendedProperties["ViewTable"] = DS.csa_contractkinddataview;
            DS.upb1.ExtendedProperties["ViewTable"] = DS.csa_contractkinddataview;
            DS.csa_contractkinddataview.ExtendedProperties["RealTable"] = DS.csa_contractkinddata;

            foreach (DataColumn C in DS.csa_contractkinddata.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.csa_contractkinddataview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "csa_contractkinddata." + C.ColumnName;
            }

            DS.csa_contractkinddataview.Columns["sortcode_siope"].ExtendedProperties["ViewSource"] = "sorting.sortcode";
            DS.csa_contractkinddataview.Columns["codefin"].ExtendedProperties["ViewSource"] = "fin.codefin";
            DS.csa_contractkinddataview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb1.codeupb";
            DS.csa_contractkinddataview.Columns["codeacc"].ExtendedProperties["ViewSource"] = "account.codeacc";



		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);

             GetData.SetStaticFilter(DS.csa_contractkindyear, filter);
            DataAccess.SetTableForReading(DS.fin_main, "fin");
            DataAccess.SetTableForReading(DS.account_main, "account");
            DataAccess.SetTableForReading(DS.upb1, "upb");
            GetData.SetStaticFilter(DS.csa_contractkindview, filter);
            GetData.SetStaticFilter(DS.csa_contractkinddata, filter);
            GetData.SetStaticFilter(DS.csa_contractkinddataview, filter);
            GetData.SetStaticFilter(DS.csa_contractkindrules, filter);
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            GetData.SetStaticFilter(DS.fin_main, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account_main, filter);
            GetData.SetSorting(DS.upb, "codeupb asc");
            HelpForm.SetDenyNull(DS.csa_contractkind.Columns["flagkeepalive"], true);
            DataAccess.SetTableForReading(DS.sorting_main, "sorting");

            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));  
            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)){
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
        }

        void SetGBoxClass(object sortingkind){
            if (sortingkind != DBNull.Value){
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting_main.tree." + filter;
            }
        }


        public void MetaData_AfterGetFormData () {
            // In questo modo la libreria riconosce come sub entità di casualcontract la tabella casualcontractyear
            Meta.myHelpForm.ExtraEntities["csa_contractkindyear"] = "csa_contractkindyear";
            if (Meta.InsertMode) {
                DataRow Curr = DS.csa_contractkind.Rows[0];
                foreach (DataRow R in DS.csa_contractkindyear.Select()) {
                    R["idcsa_contractkind"] = Curr["idcsa_contractkind"];
                }
            }
        }
     
        public void MetaData_BeforeFill () {
            if (Meta.InsertMode) {
                CreateImputazioneContrattoRow();
            }
        }

        public void CreateImputazioneContrattoRow () {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contractkind.Rows[0];
            string filtro = QHC.AppAnd(QHC.CmpEq("idcsa_contractkind", Curr["idcsa_contractkind"]),
                QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataRow[] r = DS.csa_contractkindyear.Select(filtro);
            if (r.Length == 0) {
                DataRow drContratto = DS.Tables["csa_contractkind"].Rows[0];
                MetaData metaIC = MetaData.GetMetaData(this, "csa_contractkindyear");
                metaIC.SetDefaults(DS.csa_contractkindyear);
                DataRow DR = metaIC.Get_New_Row(drContratto, DS.csa_contractkindyear);
            }
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_contractkind_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.gboxtipo = new System.Windows.Forms.GroupBox();
            this.rdbCompetenza = new System.Windows.Forms.RadioButton();
            this.rdbResidui = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnUnderwriting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgrAttribuzioni = new System.Windows.Forms.DataGrid();
            this.btnPagElimina = new System.Windows.Forms.Button();
            this.btnPagModifica = new System.Windows.Forms.Button();
            this.btnPagInserisci = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgrRegole = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkKeepAlive = new System.Windows.Forms.CheckBox();
            this.ckbAttivo = new System.Windows.Forms.CheckBox();
            this.DS = new csa_contractkind_default.vistaForm();
            this.gboxtipo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxclassSiope.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.grpBilancioVersamento.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrAttribuzioni)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRegole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // gboxtipo
            // 
            this.gboxtipo.Controls.Add(this.rdbCompetenza);
            this.gboxtipo.Controls.Add(this.rdbResidui);
            this.gboxtipo.Location = new System.Drawing.Point(217, 6);
            this.gboxtipo.Name = "gboxtipo";
            this.gboxtipo.Size = new System.Drawing.Size(135, 56);
            this.gboxtipo.TabIndex = 2;
            this.gboxtipo.TabStop = false;
            this.gboxtipo.Text = "Tipo";
            // 
            // rdbCompetenza
            // 
            this.rdbCompetenza.Location = new System.Drawing.Point(18, 16);
            this.rdbCompetenza.Name = "rdbCompetenza";
            this.rdbCompetenza.Size = new System.Drawing.Size(96, 16);
            this.rdbCompetenza.TabIndex = 2;
            this.rdbCompetenza.Tag = "csa_contractkind.flagcr:C";
            this.rdbCompetenza.Text = "Competenza";
            // 
            // rdbResidui
            // 
            this.rdbResidui.Location = new System.Drawing.Point(18, 35);
            this.rdbResidui.Name = "rdbResidui";
            this.rdbResidui.Size = new System.Drawing.Size(96, 16);
            this.rdbResidui.TabIndex = 3;
            this.rdbResidui.Tag = "csa_contractkind.flagcr:R";
            this.rdbResidui.Text = "Residui";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(193, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "csa_contractkind.contractkindcode";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 70);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(586, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Tag = "csa_contractkind.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 389);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.TabStop = false;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupBox3);
            this.tabMain.Controls.Add(this.groupBox1);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(953, 363);
            this.tabMain.TabIndex = 2;
            this.tabMain.Text = "Imputazione";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtUnderwriting);
            this.groupBox3.Controls.Add(this.btnUnderwriting);
            this.groupBox3.Location = new System.Drawing.Point(11, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 43);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(121, 16);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(455, 20);
            this.txtUnderwriting.TabIndex = 2;
            this.txtUnderwriting.Tag = "underwriting.title?csa_contractkindview.underwriting";
            // 
            // btnUnderwriting
            // 
            this.btnUnderwriting.Location = new System.Drawing.Point(9, 14);
            this.btnUnderwriting.Name = "btnUnderwriting";
            this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
            this.btnUnderwriting.TabIndex = 0;
            this.btnUnderwriting.TabStop = false;
            this.btnUnderwriting.Tag = "choose.underwriting.default";
            this.btnUnderwriting.Text = "Finanziamento";
            this.btnUnderwriting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gboxclassSiope);
            this.groupBox1.Controls.Add(this.gboxConto);
            this.groupBox1.Controls.Add(this.grpBilancioVersamento);
            this.groupBox1.Controls.Add(this.gboxUPB);
            this.groupBox1.Location = new System.Drawing.Point(11, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 300);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imputazione Costo Lordo";
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(469, 161);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(451, 122);
            this.gboxclassSiope.TabIndex = 4;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            this.gboxclassSiope.Text = "Classificazione SIOPE";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(8, 60);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting_main.tree";
            this.btnCodiceSiope.Text = "Codice";
            this.btnCodiceSiope.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenomSiope
            // 
            this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenomSiope.Location = new System.Drawing.Point(102, 16);
            this.txtDenomSiope.Multiline = true;
            this.txtDenomSiope.Name = "txtDenomSiope";
            this.txtDenomSiope.ReadOnly = true;
            this.txtDenomSiope.Size = new System.Drawing.Size(341, 71);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting_main.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(6, 89);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(437, 20);
            this.txtCodiceSiope.TabIndex = 3;
            this.txtCodiceSiope.Tag = "sorting_main.sortcode?x";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button5);
            this.gboxConto.Location = new System.Drawing.Point(12, 161);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(418, 122);
            this.gboxConto.TabIndex = 3;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto Ep di Costo";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(273, 67);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account_main.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 96);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(401, 20);
            this.txtCodiceConto.TabIndex = 4;
            this.txtCodiceConto.Tag = "account_main.codeacc?csa_contractkindview.codeacc_main";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 23);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.account_main.tree";
            this.button5.Text = "Conto";
            // 
            // grpBilancioVersamento
            // 
            this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancio);
            this.grpBilancioVersamento.Controls.Add(this.txtBilancio);
            this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
            this.grpBilancioVersamento.Location = new System.Drawing.Point(469, 13);
            this.grpBilancioVersamento.Name = "grpBilancioVersamento";
            this.grpBilancioVersamento.Size = new System.Drawing.Size(451, 142);
            this.grpBilancioVersamento.TabIndex = 2;
            this.grpBilancioVersamento.TabStop = false;
            this.grpBilancioVersamento.Tag = "AutoManage.txtBilancio.trees";
            this.grpBilancioVersamento.Text = "Capitolo di spesa";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrBilancio.Size = new System.Drawing.Size(300, 87);
            this.txtDescrBilancio.TabIndex = 2;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin_main.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(8, 110);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(436, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "fin_main.codefin?csa_contractkindview.codefin_main";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(8, 80);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(74, 24);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin_main.trees";
            this.btnBilancio.Text = "Bilancio";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(12, 13);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(418, 142);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(6, 116);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(403, 20);
            this.txtUPB.TabIndex = 8;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(6, 85);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(88, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(273, 95);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgrAttribuzioni);
            this.tabPage1.Controls.Add(this.btnPagElimina);
            this.tabPage1.Controls.Add(this.btnPagModifica);
            this.tabPage1.Controls.Add(this.btnPagInserisci);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(953, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Contributi";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrAttribuzioni
            // 
            this.dgrAttribuzioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrAttribuzioni.CaptionVisible = false;
            this.dgrAttribuzioni.DataMember = "";
            this.dgrAttribuzioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrAttribuzioni.Location = new System.Drawing.Point(82, 19);
            this.dgrAttribuzioni.Name = "dgrAttribuzioni";
            this.dgrAttribuzioni.ReadOnly = true;
            this.dgrAttribuzioni.Size = new System.Drawing.Size(865, 338);
            this.dgrAttribuzioni.TabIndex = 0;
            this.dgrAttribuzioni.Tag = "csa_contractkinddata.default.default";
            // 
            // btnPagElimina
            // 
            this.btnPagElimina.Location = new System.Drawing.Point(8, 75);
            this.btnPagElimina.Name = "btnPagElimina";
            this.btnPagElimina.Size = new System.Drawing.Size(68, 22);
            this.btnPagElimina.TabIndex = 3;
            this.btnPagElimina.Tag = "Delete";
            this.btnPagElimina.Text = "Elimina";
            // 
            // btnPagModifica
            // 
            this.btnPagModifica.Location = new System.Drawing.Point(8, 47);
            this.btnPagModifica.Name = "btnPagModifica";
            this.btnPagModifica.Size = new System.Drawing.Size(69, 22);
            this.btnPagModifica.TabIndex = 2;
            this.btnPagModifica.Tag = "edit.default";
            this.btnPagModifica.Text = "Modifica...";
            // 
            // btnPagInserisci
            // 
            this.btnPagInserisci.Location = new System.Drawing.Point(9, 19);
            this.btnPagInserisci.Name = "btnPagInserisci";
            this.btnPagInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnPagInserisci.TabIndex = 1;
            this.btnPagInserisci.Tag = "Insert.default";
            this.btnPagInserisci.Text = "Inserisci...";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgrRegole);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(953, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Regole di individuazione";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrRegole
            // 
            this.dgrRegole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrRegole.CaptionVisible = false;
            this.dgrRegole.DataMember = "";
            this.dgrRegole.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrRegole.Location = new System.Drawing.Point(90, 21);
            this.dgrRegole.Name = "dgrRegole";
            this.dgrRegole.ReadOnly = true;
            this.dgrRegole.Size = new System.Drawing.Size(857, 336);
            this.dgrRegole.TabIndex = 0;
            this.dgrRegole.Tag = "csa_contractkindrules.default.default";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 3;
            this.button1.Tag = "Delete";
            this.button1.Text = "Elimina";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 22);
            this.button2.TabIndex = 2;
            this.button2.Tag = "edit.default";
            this.button2.Text = "Modifica...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 22);
            this.button3.TabIndex = 1;
            this.button3.Tag = "Insert.default";
            this.button3.Text = "Inserisci...";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(375, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Tag = "csa_contractkind.idcsa_contractkind";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(375, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 0;
            this.label4.Tag = "";
            this.label4.Text = "Numero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkKeepAlive
            // 
            this.chkKeepAlive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKeepAlive.Location = new System.Drawing.Point(754, 42);
            this.chkKeepAlive.Name = "chkKeepAlive";
            this.chkKeepAlive.Size = new System.Drawing.Size(189, 27);
            this.chkKeepAlive.TabIndex = 6;
            this.chkKeepAlive.TabStop = false;
            this.chkKeepAlive.Tag = "csa_contractkind.flagkeepalive:S:N";
            this.chkKeepAlive.Text = "Conserva negli anni successivi";
            // 
            // ckbAttivo
            // 
            this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbAttivo.Location = new System.Drawing.Point(754, 20);
            this.ckbAttivo.Name = "ckbAttivo";
            this.ckbAttivo.Size = new System.Drawing.Size(80, 16);
            this.ckbAttivo.TabIndex = 5;
            this.ckbAttivo.TabStop = false;
            this.ckbAttivo.Tag = "csa_contractkind.active:S:N";
            this.ckbAttivo.Text = "Attivo";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_csa_contractkind_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(972, 494);
            this.Controls.Add(this.ckbAttivo);
            this.Controls.Add(this.chkKeepAlive);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gboxtipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_csa_contractkind_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gboxtipo.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.grpBilancioVersamento.ResumeLayout(false);
            this.grpBilancioVersamento.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrAttribuzioni)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrRegole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}
