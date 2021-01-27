
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
using System.Data;
using AskInfo;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;

namespace csa_importriep_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_importriep_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
		private System.ComponentModel.IContainer components;
        MetaData Meta;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private TextBox txtMatricola;
        private GroupBox grpMatricola;
        private GroupBox gboxtipo;
        private RadioButton rdbCompetenza;
        private RadioButton rdbResidui;
        private GroupBox groupBox3;
        private TextBox txtNumImport;
        private Label label8;
        private TextBox txtEsercImport;
        private Label label9;
        private GroupBox groupBox4;
        private TextBox txtNumRiep;
        private Label label6;
        private GroupBox groupBox5;
        private TextBox txtCompetenza;
        private GroupBox groupBox7;
        private Label label2;
        private TextBox txtRuoloCsa;
        private TextBox txtCapitoloCsa;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPageMovFin;
        private GroupBox groupBox11;
        private DataGrid dataGrid4;
        private GroupBox groupBox12;
        private DataGrid dataGrid5;
        private Button button9;
        private Button button8;
        private TabPage tabPagRipUnica;
        private TabPage tabVecchiaConfig;
        private GroupBox groupBox10;
        private Button button4;
        private Button button6;
        private Button button7;
        private DataGrid dataGrid3;
        private TabControl tabControl2;
        private TabPage tabFinanziario;
        private GroupBox groupBox2;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        public GroupBox gboxclassSiope;
        public Button btnCodiceSiope;
        private TextBox txtDenomSiope;
        private TextBox txtCodiceSiope;
        private GroupBox groupBox13;
        private TextBox txtUnderwriting;
        private Button btnUnderwriting;
        private GroupBox grpBilancioVersamento;
        private TextBox txtDescrBilancio;
        private TextBox txtBilancio;
        private Button btnBilancio;
        private CheckBox chkSpesa;
        private GroupBox gboxSpesa;
        private Label label7;
        private TextBox txtNum;
        private Label label13;
        private TextBox txtEserc;
        private Label label12;
        private ComboBox cmbFaseSpesa;
        private Button btnSpesa;
        private TabPage tabRipartizioni;
        private GroupBox groupBox8;
        private Button btnInserisci;
        private Button btnModifica;
        private Button btnElimina;
        private DataGrid dataGrid1;
        private GroupBox groupBox9;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGrid dataGrid2;
        private TabPage tabEP;
        private GroupBox gboxImponibile;
        private Label label10;
        private ComboBox cmbFaseImpBudget;
        private Label label34;
        private Label label33;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button5;
        private GroupBox groupBox6;
        private Label label11;
        private TextBox txtImporto;
        private GroupBox groupBox14;
        private TextBox txtNumRegolaspecifica;
        private Label label14;
        private TextBox txtEserRegolaspecifica;
        private Label label15;
        private GroupBox groupBox15;
        private TextBox txtNumeroregGenerale;
        private Label label5;
        private Label label16;
        private TextBox txtCodiceRegGenerale;
        private TextBox txtRegolaGenerale;
        private Button button11;
        DataAccess Conn;
		public Frm_csa_importriep_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.csa_importriep.Columns["flagcr"], true);
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
        private EP_Manager epm;

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
            GetData.SetStaticFilter(DS.csa_contract, filter);
            //GetData.SetStaticFilter(DS.csa_importriep, filter);
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            GetData.SetStaticFilter(DS.expenseview, filter);
            GetData.SetStaticFilter(DS.expenseview1, filter);
            GetData.SetStaticFilter(DS.expenseview3, filter);
            GetData.SetStaticFilter(DS.csa_import, QHS.CmpEq("yimport", Conn.GetEsercizio()));
            GetData.SetStaticFilter(DS.csa_contractkindview, filter);
            //GetData.CacheTable(DS.csa_contractkind,null, null, false);
            //GetData.CacheTable(DS.upb, QHS.CmpEq("active", 'S'), null, false);
            //GetData.CacheTable(DS.upb_kind, QHS.CmpEq("active", 'S'), null, false);
            GetData.SetSorting(DS.upb, "codeupb asc");
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_importriep.Columns["flagcr"], true);

            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)){
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
            DataAccess.SetTableForReading(DS.epexpview1, "epexpview");
            DataAccess.SetTableForReading(DS.expenseview1, "expenseview");
            DataAccess.SetTableForReading(DS.epexpview3, "epexpview");
            DataAccess.SetTableForReading(DS.expenseview3, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview4, "expenseview");
            DataAccess.SetTableForReading(DS.fin2, "fin");
            DataAccess.SetTableForReading(DS.upb2, "upb");
            DataAccess.SetTableForReading(DS.account2, "account");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
            epm = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni, null, null,
                        null, null, "csa_importriep");

 

        }

        bool vecchiaGestione() {
            if (Meta.IsEmpty) return false;
            if (DS.csa_importriep.Rows.Count > 0) {
                DataRow Curr = DS.csa_importriep.Rows[0];
                string filterCsa = QHS.CmpEq("idcsa_import", Curr["idcsa_import"]);
                DataTable tRiepiloghi = Meta.Conn.RUN_SELECT("csa_importriep_partition", "*", null, filterCsa, null, null, true);
                if ((tRiepiloghi != null) && (tRiepiloghi.Rows.Count > 0)) {
                    return true;
                }
                else {
                    DataTable tVersamenti = Meta.Conn.RUN_SELECT("csa_importver_partition", "*", null, filterCsa, null, null, true);
                    if ((tVersamenti != null) && (tVersamenti.Rows.Count > 0)) {
                        return true;
                    }
                }
            }
            return false;
             
        }

        void SetGBoxClass(object sortingkind){
            if (sortingkind != DBNull.Value){
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
                btnCodiceSiope.Text = title;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_importriep_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new csa_importriep_default.vistaForm();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.txtMatricola = new System.Windows.Forms.TextBox();
            this.grpMatricola = new System.Windows.Forms.GroupBox();
            this.gboxtipo = new System.Windows.Forms.GroupBox();
            this.rdbCompetenza = new System.Windows.Forms.RadioButton();
            this.rdbResidui = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNumImport = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEsercImport = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNumRiep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCompetenza = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRuoloCsa = new System.Windows.Forms.TextBox();
            this.txtCapitoloCsa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagRipUnica = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabPageMovFin = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.dataGrid4 = new System.Windows.Forms.DataGrid();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dataGrid5 = new System.Windows.Forms.DataGrid();
            this.tabVecchiaConfig = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabFinanziario = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtUnderwriting = new System.Windows.Forms.TextBox();
            this.btnUnderwriting = new System.Windows.Forms.Button();
            this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.chkSpesa = new System.Windows.Forms.CheckBox();
            this.gboxSpesa = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
            this.btnSpesa = new System.Windows.Forms.Button();
            this.tabRipartizioni = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.gboxImponibile = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.btnLinkEpExp = new System.Windows.Forms.Button();
            this.btnRemoveEpExp = new System.Windows.Forms.Button();
            this.txtNumImpegno = new System.Windows.Forms.TextBox();
            this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
            this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
            this.btnViewPreimpegni = new System.Windows.Forms.Button();
            this.btnGeneraEpExp = new System.Windows.Forms.Button();
            this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtNumRegolaspecifica = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEserRegolaspecifica = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.txtNumeroregGenerale = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCodiceRegGenerale = new System.Windows.Forms.TextBox();
            this.txtRegolaGenerale = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupCredDeb.SuspendLayout();
            this.grpMatricola.SuspendLayout();
            this.gboxtipo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagRipUnica.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabPageMovFin.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
            this.tabVecchiaConfig.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabFinanziario.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxclassSiope.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.grpBilancioVersamento.SuspendLayout();
            this.gboxSpesa.SuspendLayout();
            this.tabRipartizioni.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabEP.SuspendLayout();
            this.gboxImponibile.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
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
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(6, 59);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(366, 50);
            this.groupCredDeb.TabIndex = 4;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredDeb.Location = new System.Drawing.Point(8, 21);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(350, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?csa_importriepview.registry";
            // 
            // txtMatricola
            // 
            this.txtMatricola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMatricola.Location = new System.Drawing.Point(10, 21);
            this.txtMatricola.Multiline = true;
            this.txtMatricola.Name = "txtMatricola";
            this.txtMatricola.ReadOnly = true;
            this.txtMatricola.Size = new System.Drawing.Size(463, 20);
            this.txtMatricola.TabIndex = 14;
            this.txtMatricola.TabStop = false;
            this.txtMatricola.Tag = "csa_importriep.matricola";
            // 
            // grpMatricola
            // 
            this.grpMatricola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMatricola.Controls.Add(this.txtMatricola);
            this.grpMatricola.Location = new System.Drawing.Point(491, 59);
            this.grpMatricola.Name = "grpMatricola";
            this.grpMatricola.Size = new System.Drawing.Size(479, 50);
            this.grpMatricola.TabIndex = 6;
            this.grpMatricola.TabStop = false;
            this.grpMatricola.Text = "Matricola";
            // 
            // gboxtipo
            // 
            this.gboxtipo.Controls.Add(this.rdbCompetenza);
            this.gboxtipo.Controls.Add(this.rdbResidui);
            this.gboxtipo.Location = new System.Drawing.Point(156, 7);
            this.gboxtipo.Name = "gboxtipo";
            this.gboxtipo.Size = new System.Drawing.Size(217, 46);
            this.gboxtipo.TabIndex = 2;
            this.gboxtipo.TabStop = false;
            this.gboxtipo.Text = "Tipo";
            // 
            // rdbCompetenza
            // 
            this.rdbCompetenza.Location = new System.Drawing.Point(11, 18);
            this.rdbCompetenza.Name = "rdbCompetenza";
            this.rdbCompetenza.Size = new System.Drawing.Size(90, 24);
            this.rdbCompetenza.TabIndex = 2;
            this.rdbCompetenza.Tag = "csa_importriep.flagcr:C";
            this.rdbCompetenza.Text = "Competenza";
            // 
            // rdbResidui
            // 
            this.rdbResidui.Location = new System.Drawing.Point(118, 22);
            this.rdbResidui.Name = "rdbResidui";
            this.rdbResidui.Size = new System.Drawing.Size(90, 16);
            this.rdbResidui.TabIndex = 3;
            this.rdbResidui.Tag = "csa_importriep.flagcr:R";
            this.rdbResidui.Text = "Residui";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNumImport);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtEsercImport);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(379, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 46);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtNumImport.default";
            this.groupBox3.Text = "Importazione";
            // 
            // txtNumImport
            // 
            this.txtNumImport.Location = new System.Drawing.Point(234, 15);
            this.txtNumImport.Name = "txtNumImport";
            this.txtNumImport.Size = new System.Drawing.Size(70, 20);
            this.txtNumImport.TabIndex = 3;
            this.txtNumImport.Tag = "csa_import.nimport?csa_importriepview.nimport";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(167, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Numero:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercImport
            // 
            this.txtEsercImport.Location = new System.Drawing.Point(76, 15);
            this.txtEsercImport.Name = "txtEsercImport";
            this.txtEsercImport.ReadOnly = true;
            this.txtEsercImport.Size = new System.Drawing.Size(70, 20);
            this.txtEsercImport.TabIndex = 2;
            this.txtEsercImport.Tag = "csa_import.yimport.year?csa_importriepview.yimport.year";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Esercizio:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNumRiep);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 46);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "";
            this.groupBox4.Text = "Riepilogo";
            // 
            // txtNumRiep
            // 
            this.txtNumRiep.Location = new System.Drawing.Point(82, 18);
            this.txtNumRiep.Name = "txtNumRiep";
            this.txtNumRiep.Size = new System.Drawing.Size(56, 20);
            this.txtNumRiep.TabIndex = 3;
            this.txtNumRiep.Tag = "csa_importriep.idriep";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Numero:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCompetenza);
            this.groupBox5.Location = new System.Drawing.Point(377, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(110, 50);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Competenza";
            // 
            // txtCompetenza
            // 
            this.txtCompetenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompetenza.Location = new System.Drawing.Point(12, 20);
            this.txtCompetenza.Multiline = true;
            this.txtCompetenza.Name = "txtCompetenza";
            this.txtCompetenza.ReadOnly = true;
            this.txtCompetenza.Size = new System.Drawing.Size(92, 20);
            this.txtCompetenza.TabIndex = 14;
            this.txtCompetenza.TabStop = false;
            this.txtCompetenza.Tag = "csa_importriep.competenza.year";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtRuoloCsa);
            this.groupBox7.Controls.Add(this.txtCapitoloCsa);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Location = new System.Drawing.Point(645, 112);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(325, 62);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ruolo CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRuoloCsa
            // 
            this.txtRuoloCsa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuoloCsa.Location = new System.Drawing.Point(91, 40);
            this.txtRuoloCsa.Name = "txtRuoloCsa";
            this.txtRuoloCsa.ReadOnly = true;
            this.txtRuoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRuoloCsa.Size = new System.Drawing.Size(220, 20);
            this.txtRuoloCsa.TabIndex = 14;
            this.txtRuoloCsa.TabStop = false;
            this.txtRuoloCsa.Tag = "csa_importriep.ruolocsa";
            // 
            // txtCapitoloCsa
            // 
            this.txtCapitoloCsa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCapitoloCsa.Location = new System.Drawing.Point(91, 11);
            this.txtCapitoloCsa.Name = "txtCapitoloCsa";
            this.txtCapitoloCsa.ReadOnly = true;
            this.txtCapitoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCapitoloCsa.Size = new System.Drawing.Size(220, 20);
            this.txtCapitoloCsa.TabIndex = 13;
            this.txtCapitoloCsa.TabStop = false;
            this.txtCapitoloCsa.Tag = "csa_importriep.capitolocsa";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Capitolo CSA:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPagRipUnica);
            this.tabControl1.Controls.Add(this.tabPageMovFin);
            this.tabControl1.Controls.Add(this.tabVecchiaConfig);
            this.tabControl1.Location = new System.Drawing.Point(6, 224);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(968, 463);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPagRipUnica
            // 
            this.tabPagRipUnica.Controls.Add(this.groupBox10);
            this.tabPagRipUnica.Location = new System.Drawing.Point(4, 22);
            this.tabPagRipUnica.Name = "tabPagRipUnica";
            this.tabPagRipUnica.Size = new System.Drawing.Size(960, 437);
            this.tabPagRipUnica.TabIndex = 4;
            this.tabPagRipUnica.Text = "Ripartizione Unica";
            this.tabPagRipUnica.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.button4);
            this.groupBox10.Controls.Add(this.button6);
            this.groupBox10.Controls.Add(this.button7);
            this.groupBox10.Controls.Add(this.dataGrid3);
            this.groupBox10.Location = new System.Drawing.Point(4, 16);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(943, 310);
            this.groupBox10.TabIndex = 53;
            this.groupBox10.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(10, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(68, 22);
            this.button4.TabIndex = 23;
            this.button4.Tag = "insert.detail";
            this.button4.Text = "Inserisci";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 51);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(68, 22);
            this.button6.TabIndex = 24;
            this.button6.Tag = "edit.detail";
            this.button6.Text = "Modifica";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(10, 83);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(68, 22);
            this.button7.TabIndex = 25;
            this.button7.Tag = "delete";
            this.button7.Text = "Elimina";
            // 
            // dataGrid3
            // 
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(84, 19);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(850, 285);
            this.dataGrid3.TabIndex = 20;
            this.dataGrid3.Tag = "csa_importriep_partition.default.detail";
            // 
            // tabPageMovFin
            // 
            this.tabPageMovFin.Controls.Add(this.groupBox11);
            this.tabPageMovFin.Controls.Add(this.groupBox12);
            this.tabPageMovFin.Location = new System.Drawing.Point(4, 22);
            this.tabPageMovFin.Name = "tabPageMovFin";
            this.tabPageMovFin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMovFin.Size = new System.Drawing.Size(960, 437);
            this.tabPageMovFin.TabIndex = 3;
            this.tabPageMovFin.Text = "Movimenti finanziari";
            this.tabPageMovFin.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.button9);
            this.groupBox11.Controls.Add(this.dataGrid4);
            this.groupBox11.Location = new System.Drawing.Point(10, 3);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(937, 197);
            this.groupBox11.TabIndex = 53;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Entrata";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(68, 22);
            this.button9.TabIndex = 29;
            this.button9.Tag = "edit.detail";
            this.button9.Text = "Visualizza";
            // 
            // dataGrid4
            // 
            this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid4.DataMember = "";
            this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid4.Location = new System.Drawing.Point(87, 19);
            this.dataGrid4.Name = "dataGrid4";
            this.dataGrid4.Size = new System.Drawing.Size(838, 166);
            this.dataGrid4.TabIndex = 20;
            this.dataGrid4.Tag = "csa_importriep_partition_income.default.detail";
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox12.Controls.Add(this.button8);
            this.groupBox12.Controls.Add(this.dataGrid5);
            this.groupBox12.Location = new System.Drawing.Point(14, 245);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(937, 161);
            this.groupBox12.TabIndex = 52;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Spesa";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(9, 89);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(68, 22);
            this.button8.TabIndex = 29;
            this.button8.Tag = "edit.detail";
            this.button8.Text = "Visualizza";
            // 
            // dataGrid5
            // 
            this.dataGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid5.DataMember = "";
            this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid5.Location = new System.Drawing.Point(89, 19);
            this.dataGrid5.Name = "dataGrid5";
            this.dataGrid5.Size = new System.Drawing.Size(836, 136);
            this.dataGrid5.TabIndex = 20;
            this.dataGrid5.Tag = "csa_importriep_partition_expense.default.detail";
            // 
            // tabVecchiaConfig
            // 
            this.tabVecchiaConfig.Controls.Add(this.tabControl2);
            this.tabVecchiaConfig.Location = new System.Drawing.Point(4, 22);
            this.tabVecchiaConfig.Name = "tabVecchiaConfig";
            this.tabVecchiaConfig.Size = new System.Drawing.Size(960, 437);
            this.tabVecchiaConfig.TabIndex = 5;
            this.tabVecchiaConfig.Text = "Vecchia Configurazione";
            this.tabVecchiaConfig.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabFinanziario);
            this.tabControl2.Controls.Add(this.tabRipartizioni);
            this.tabControl2.Controls.Add(this.tabEP);
            this.tabControl2.Location = new System.Drawing.Point(4, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(930, 414);
            this.tabControl2.TabIndex = 17;
            // 
            // tabFinanziario
            // 
            this.tabFinanziario.Controls.Add(this.groupBox2);
            this.tabFinanziario.Controls.Add(this.groupBox13);
            this.tabFinanziario.Controls.Add(this.grpBilancioVersamento);
            this.tabFinanziario.Controls.Add(this.chkSpesa);
            this.tabFinanziario.Controls.Add(this.gboxSpesa);
            this.tabFinanziario.Location = new System.Drawing.Point(4, 22);
            this.tabFinanziario.Name = "tabFinanziario";
            this.tabFinanziario.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinanziario.Size = new System.Drawing.Size(922, 388);
            this.tabFinanziario.TabIndex = 0;
            this.tabFinanziario.Text = "Finanziario";
            this.tabFinanziario.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gboxUPB);
            this.groupBox2.Controls.Add(this.gboxclassSiope);
            this.groupBox2.Location = new System.Drawing.Point(9, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 199);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(6, 8);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(350, 114);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(7, 66);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(338, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(101, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(241, 52);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(7, 40);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(77, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(5, 122);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(350, 72);
            this.gboxclassSiope.TabIndex = 2;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(8, 16);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting.tree";
            this.btnCodiceSiope.Text = "SIOPE";
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
            this.txtDenomSiope.Size = new System.Drawing.Size(240, 52);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(88, 20);
            this.txtCodiceSiope.TabIndex = 3;
            this.txtCodiceSiope.Tag = "sorting.sortcode?csa_importriepview.sortcode";
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.txtUnderwriting);
            this.groupBox13.Controls.Add(this.btnUnderwriting);
            this.groupBox13.Location = new System.Drawing.Point(456, 134);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(463, 68);
            this.groupBox13.TabIndex = 11;
            this.groupBox13.TabStop = false;
            this.groupBox13.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
            // 
            // txtUnderwriting
            // 
            this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnderwriting.Location = new System.Drawing.Point(9, 37);
            this.txtUnderwriting.Name = "txtUnderwriting";
            this.txtUnderwriting.Size = new System.Drawing.Size(446, 20);
            this.txtUnderwriting.TabIndex = 2;
            this.txtUnderwriting.Tag = "underwriting.title?csa_importriepview.underwriting";
            // 
            // btnUnderwriting
            // 
            this.btnUnderwriting.Location = new System.Drawing.Point(9, 8);
            this.btnUnderwriting.Name = "btnUnderwriting";
            this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
            this.btnUnderwriting.TabIndex = 0;
            this.btnUnderwriting.TabStop = false;
            this.btnUnderwriting.Tag = "choose.underwriting.default";
            this.btnUnderwriting.Text = "Finanziamento";
            this.btnUnderwriting.UseVisualStyleBackColor = true;
            // 
            // grpBilancioVersamento
            // 
            this.grpBilancioVersamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancio);
            this.grpBilancioVersamento.Controls.Add(this.txtBilancio);
            this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
            this.grpBilancioVersamento.Location = new System.Drawing.Point(461, 6);
            this.grpBilancioVersamento.Name = "grpBilancioVersamento";
            this.grpBilancioVersamento.Size = new System.Drawing.Size(455, 114);
            this.grpBilancioVersamento.TabIndex = 10;
            this.grpBilancioVersamento.TabStop = false;
            this.grpBilancioVersamento.Tag = "AutoManage.txtBilancio.trees";
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
            this.txtDescrBilancio.Size = new System.Drawing.Size(304, 60);
            this.txtDescrBilancio.TabIndex = 0;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(6, 82);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(525, 20);
            this.txtBilancio.TabIndex = 2;
            this.txtBilancio.Tag = "fin.codefin?csa_importriepview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(6, 52);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(90, 24);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin.trees";
            this.btnBilancio.Text = "Bilancio";
            // 
            // chkSpesa
            // 
            this.chkSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSpesa.Location = new System.Drawing.Point(360, 275);
            this.chkSpesa.Name = "chkSpesa";
            this.chkSpesa.Size = new System.Drawing.Size(193, 23);
            this.chkSpesa.TabIndex = 12;
            this.chkSpesa.Text = "Seleziona  movimento di spesa ";
            this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
            // 
            // gboxSpesa
            // 
            this.gboxSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxSpesa.Controls.Add(this.label7);
            this.gboxSpesa.Controls.Add(this.txtNum);
            this.gboxSpesa.Controls.Add(this.label13);
            this.gboxSpesa.Controls.Add(this.txtEserc);
            this.gboxSpesa.Controls.Add(this.label12);
            this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
            this.gboxSpesa.Controls.Add(this.btnSpesa);
            this.gboxSpesa.Location = new System.Drawing.Point(560, 271);
            this.gboxSpesa.Name = "gboxSpesa";
            this.gboxSpesa.Size = new System.Drawing.Size(356, 108);
            this.gboxSpesa.TabIndex = 13;
            this.gboxSpesa.TabStop = false;
            this.gboxSpesa.Text = "Movimento di Spesa";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fase";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(214, 70);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(79, 20);
            this.txtNum.TabIndex = 4;
            this.txtNum.Tag = "";
            this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(155, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Numero:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(66, 69);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(56, 20);
            this.txtEserc.TabIndex = 3;
            this.txtEserc.Tag = "";
            this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(5, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Esercizio:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseSpesa
            // 
            this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFaseSpesa.DataSource = this.DS.expensephase;
            this.cmbFaseSpesa.DisplayMember = "description";
            this.cmbFaseSpesa.Location = new System.Drawing.Point(66, 45);
            this.cmbFaseSpesa.Name = "cmbFaseSpesa";
            this.cmbFaseSpesa.Size = new System.Drawing.Size(279, 21);
            this.cmbFaseSpesa.TabIndex = 2;
            this.cmbFaseSpesa.Tag = "";
            this.cmbFaseSpesa.ValueMember = "nphase";
            this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
            // 
            // btnSpesa
            // 
            this.btnSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpesa.Location = new System.Drawing.Point(163, 21);
            this.btnSpesa.Name = "btnSpesa";
            this.btnSpesa.Size = new System.Drawing.Size(181, 23);
            this.btnSpesa.TabIndex = 1;
            this.btnSpesa.TabStop = false;
            this.btnSpesa.Text = "Scegli Movimento";
            this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
            // 
            // tabRipartizioni
            // 
            this.tabRipartizioni.Controls.Add(this.groupBox8);
            this.tabRipartizioni.Controls.Add(this.groupBox9);
            this.tabRipartizioni.Location = new System.Drawing.Point(4, 22);
            this.tabRipartizioni.Name = "tabRipartizioni";
            this.tabRipartizioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabRipartizioni.Size = new System.Drawing.Size(922, 388);
            this.tabRipartizioni.TabIndex = 2;
            this.tabRipartizioni.Text = "Ripartizioni";
            this.tabRipartizioni.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.btnInserisci);
            this.groupBox8.Controls.Add(this.btnModifica);
            this.groupBox8.Controls.Add(this.btnElimina);
            this.groupBox8.Controls.Add(this.dataGrid1);
            this.groupBox8.Location = new System.Drawing.Point(16, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(899, 134);
            this.groupBox8.TabIndex = 51;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Finanziaria";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(8, 19);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(68, 22);
            this.btnInserisci.TabIndex = 23;
            this.btnInserisci.Tag = "insert.detail";
            this.btnInserisci.Text = "Inserisci";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(8, 51);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(68, 22);
            this.btnModifica.TabIndex = 24;
            this.btnModifica.Tag = "edit.detail";
            this.btnModifica.Text = "Modifica";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(8, 83);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(68, 22);
            this.btnElimina.TabIndex = 25;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(82, 19);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(808, 103);
            this.dataGrid1.TabIndex = 20;
            this.dataGrid1.Tag = "csa_importriep_expense.default.detail";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.button1);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Controls.Add(this.button3);
            this.groupBox9.Controls.Add(this.dataGrid2);
            this.groupBox9.Location = new System.Drawing.Point(16, 185);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(899, 133);
            this.groupBox9.TabIndex = 50;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Movimenti di Budget";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 22);
            this.button1.TabIndex = 23;
            this.button1.Tag = "insert.detail";
            this.button1.Text = "Inserisci";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 22);
            this.button2.TabIndex = 24;
            this.button2.Tag = "edit.detail";
            this.button2.Text = "Modifica";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 22);
            this.button3.TabIndex = 25;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(84, 19);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(806, 108);
            this.dataGrid2.TabIndex = 20;
            this.dataGrid2.Tag = "csa_importriep_epexp.default.detail";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.gboxImponibile);
            this.tabEP.Controls.Add(this.btnGeneraPreImpegni);
            this.tabEP.Controls.Add(this.btnViewPreimpegni);
            this.tabEP.Controls.Add(this.btnGeneraEpExp);
            this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
            this.tabEP.Controls.Add(this.gboxConto);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Padding = new System.Windows.Forms.Padding(3);
            this.tabEP.Size = new System.Drawing.Size(922, 388);
            this.tabEP.TabIndex = 1;
            this.tabEP.Text = "EP";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // gboxImponibile
            // 
            this.gboxImponibile.Controls.Add(this.label10);
            this.gboxImponibile.Controls.Add(this.cmbFaseImpBudget);
            this.gboxImponibile.Controls.Add(this.label34);
            this.gboxImponibile.Controls.Add(this.label33);
            this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
            this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
            this.gboxImponibile.Controls.Add(this.txtNumImpegno);
            this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
            this.gboxImponibile.Location = new System.Drawing.Point(399, 72);
            this.gboxImponibile.Name = "gboxImponibile";
            this.gboxImponibile.Size = new System.Drawing.Size(498, 92);
            this.gboxImponibile.TabIndex = 48;
            this.gboxImponibile.TabStop = false;
            this.gboxImponibile.Text = "Impegno di Budget";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(11, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 10;
            this.label10.Text = "Fase";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFaseImpBudget
            // 
            this.cmbFaseImpBudget.DataSource = this.DS.fase_epexp;
            this.cmbFaseImpBudget.DisplayMember = "descrizione";
            this.cmbFaseImpBudget.Location = new System.Drawing.Point(58, 19);
            this.cmbFaseImpBudget.Name = "cmbFaseImpBudget";
            this.cmbFaseImpBudget.Size = new System.Drawing.Size(189, 21);
            this.cmbFaseImpBudget.TabIndex = 11;
            this.cmbFaseImpBudget.Tag = "";
            this.cmbFaseImpBudget.ValueMember = "nphase";
            this.cmbFaseImpBudget.SelectedIndexChanged += new System.EventHandler(this.cmbFaseImpBudget_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(133, 57);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(7, 59);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLinkEpExp
            // 
            this.btnLinkEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEpExp.Location = new System.Drawing.Point(356, 19);
            this.btnLinkEpExp.Name = "btnLinkEpExp";
            this.btnLinkEpExp.Size = new System.Drawing.Size(136, 23);
            this.btnLinkEpExp.TabIndex = 5;
            this.btnLinkEpExp.TabStop = false;
            this.btnLinkEpExp.Text = "Collega";
            this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
            // 
            // btnRemoveEpExp
            // 
            this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEpExp.Location = new System.Drawing.Point(356, 49);
            this.btnRemoveEpExp.Name = "btnRemoveEpExp";
            this.btnRemoveEpExp.Size = new System.Drawing.Size(137, 23);
            this.btnRemoveEpExp.TabIndex = 4;
            this.btnRemoveEpExp.TabStop = false;
            this.btnRemoveEpExp.Text = "Scollega";
            this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
            // 
            // txtNumImpegno
            // 
            this.txtNumImpegno.Location = new System.Drawing.Point(183, 53);
            this.txtNumImpegno.Name = "txtNumImpegno";
            this.txtNumImpegno.ReadOnly = true;
            this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
            this.txtNumImpegno.TabIndex = 3;
            this.txtNumImpegno.TabStop = false;
            this.txtNumImpegno.Tag = "epexp.nepexp";
            // 
            // txtEsercizioImpegno
            // 
            this.txtEsercizioImpegno.Location = new System.Drawing.Point(61, 55);
            this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
            this.txtEsercizioImpegno.ReadOnly = true;
            this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioImpegno.TabIndex = 2;
            this.txtEsercizioImpegno.TabStop = false;
            this.txtEsercizioImpegno.Tag = "epexp.yepexp";
            // 
            // btnGeneraPreImpegni
            // 
            this.btnGeneraPreImpegni.Location = new System.Drawing.Point(90, 11);
            this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
            this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
            this.btnGeneraPreImpegni.TabIndex = 28;
            this.btnGeneraPreImpegni.Text = "Genera movimenti di Budget";
            // 
            // btnViewPreimpegni
            // 
            this.btnViewPreimpegni.Location = new System.Drawing.Point(90, 43);
            this.btnViewPreimpegni.Name = "btnViewPreimpegni";
            this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
            this.btnViewPreimpegni.TabIndex = 27;
            this.btnViewPreimpegni.Text = "Visualizza preimpegni/preaccertamenti di Budget";
            // 
            // btnGeneraEpExp
            // 
            this.btnGeneraEpExp.Location = new System.Drawing.Point(399, 11);
            this.btnGeneraEpExp.Name = "btnGeneraEpExp";
            this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEpExp.TabIndex = 26;
            this.btnGeneraEpExp.Text = "Genera movimenti di Budget ultima fase";
            // 
            // btnVisualizzaEpExp
            // 
            this.btnVisualizzaEpExp.Location = new System.Drawing.Point(399, 43);
            this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
            this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEpExp.TabIndex = 25;
            this.btnVisualizzaEpExp.Text = "Visualizza Impegni/Accertamenti di Budget";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button5);
            this.gboxConto.Location = new System.Drawing.Point(14, 72);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(358, 92);
            this.gboxConto.TabIndex = 14;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(213, 59);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 54);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceConto.TabIndex = 2;
            this.txtCodiceConto.Tag = "account.codeacc?csa_importriepview.codeacc_main";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "manage.account.tree";
            this.button5.Text = "Conto";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtImporto);
            this.groupBox6.Location = new System.Drawing.Point(783, 186);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(188, 38);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Importo:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImporto.Location = new System.Drawing.Point(67, 12);
            this.txtImporto.Multiline = true;
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(115, 20);
            this.txtImporto.TabIndex = 14;
            this.txtImporto.TabStop = false;
            this.txtImporto.Tag = "csa_importriep.importo";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtNumRegolaspecifica);
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Controls.Add(this.txtEserRegolaspecifica);
            this.groupBox14.Controls.Add(this.label15);
            this.groupBox14.Location = new System.Drawing.Point(5, 177);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(367, 41);
            this.groupBox14.TabIndex = 17;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Regola specifica CSA";
            // 
            // txtNumRegolaspecifica
            // 
            this.txtNumRegolaspecifica.Location = new System.Drawing.Point(284, 18);
            this.txtNumRegolaspecifica.Name = "txtNumRegolaspecifica";
            this.txtNumRegolaspecifica.Size = new System.Drawing.Size(56, 20);
            this.txtNumRegolaspecifica.TabIndex = 7;
            this.txtNumRegolaspecifica.Tag = "csa_contract.ncontract?csa_importriepview.ncontract";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(220, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Numero:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEserRegolaspecifica
            // 
            this.txtEserRegolaspecifica.Location = new System.Drawing.Point(138, 18);
            this.txtEserRegolaspecifica.Name = "txtEserRegolaspecifica";
            this.txtEserRegolaspecifica.Size = new System.Drawing.Size(56, 20);
            this.txtEserRegolaspecifica.TabIndex = 6;
            this.txtEserRegolaspecifica.Tag = "csa_contract.ycontract.year?csa_importriepview.ycontract.year";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(73, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 5;
            this.label15.Text = "Esercizio:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.txtNumeroregGenerale);
            this.groupBox15.Controls.Add(this.label5);
            this.groupBox15.Controls.Add(this.label16);
            this.groupBox15.Controls.Add(this.txtCodiceRegGenerale);
            this.groupBox15.Controls.Add(this.txtRegolaGenerale);
            this.groupBox15.Controls.Add(this.button11);
            this.groupBox15.Location = new System.Drawing.Point(6, 113);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(633, 61);
            this.groupBox15.TabIndex = 49;
            this.groupBox15.TabStop = false;
            this.groupBox15.Tag = "AutoChoose.txtRegolaGenerale.default.(active = \'S\')";
            this.groupBox15.Text = "Regola generale CSA";
            // 
            // txtNumeroregGenerale
            // 
            this.txtNumeroregGenerale.Location = new System.Drawing.Point(543, 34);
            this.txtNumeroregGenerale.Name = "txtNumeroregGenerale";
            this.txtNumeroregGenerale.Size = new System.Drawing.Size(84, 20);
            this.txtNumeroregGenerale.TabIndex = 7;
            this.txtNumeroregGenerale.Tag = "csa_contractkind.idcsa_contractkind?csa_importriepview.idcsa_contractkind";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(482, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Numero";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(99, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 21);
            this.label16.TabIndex = 3;
            this.label16.Text = "Codice";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodiceRegGenerale
            // 
            this.txtCodiceRegGenerale.Location = new System.Drawing.Point(162, 38);
            this.txtCodiceRegGenerale.Name = "txtCodiceRegGenerale";
            this.txtCodiceRegGenerale.Size = new System.Drawing.Size(319, 20);
            this.txtCodiceRegGenerale.TabIndex = 2;
            this.txtCodiceRegGenerale.Tag = "csa_contractkind.contractkindcode?csa_importriepview.csa_contractkindcode";
            // 
            // txtRegolaGenerale
            // 
            this.txtRegolaGenerale.Location = new System.Drawing.Point(162, 13);
            this.txtRegolaGenerale.Name = "txtRegolaGenerale";
            this.txtRegolaGenerale.Size = new System.Drawing.Size(465, 20);
            this.txtRegolaGenerale.TabIndex = 1;
            this.txtRegolaGenerale.Tag = "csa_contractkind.description?csa_importriepview.csa_contractkind";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 13);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 20);
            this.button11.TabIndex = 0;
            this.button11.Tag = "choose.csa_contractkind.default";
            this.button11.Text = "Regola generale associata";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // Frm_csa_importriep_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(979, 695);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gboxtipo);
            this.Controls.Add(this.grpMatricola);
            this.Controls.Add(this.groupCredDeb);
            this.Name = "Frm_csa_importriep_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmImportRiep";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpMatricola.ResumeLayout(false);
            this.grpMatricola.PerformLayout();
            this.gboxtipo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPagRipUnica.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabPageMovFin.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).EndInit();
            this.tabVecchiaConfig.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabFinanziario.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.grpBilancioVersamento.ResumeLayout(false);
            this.grpBilancioVersamento.PerformLayout();
            this.gboxSpesa.ResumeLayout(false);
            this.gboxSpesa.PerformLayout();
            this.tabRipartizioni.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabEP.ResumeLayout(false);
            this.gboxImponibile.ResumeLayout(false);
            this.gboxImponibile.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e) {
            chkSpesa_CheckedChanged(sender, e, true);
        }

        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e, bool DispMessage) {
            if (chkSpesa.Checked) {
                EnableDisable(false);
                if (Meta.IsEmpty) return;
                DataRow R = DS.csa_importriep.Rows[0];
                if ((R["idfin"] != DBNull.Value) ||
                    (R["idupb"] != DBNull.Value)) {

                    if (DispMessage) {
                        if (MessageBox.Show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre " +
                            "attribuzioni su questo contratto. Proseguo?", "Conferma",
                            MessageBoxButtons.OKCancel) != DialogResult.OK) {
                            chkSpesa.Checked = false;
                            return;
                        }
                    }
                    R["idfin"] = DBNull.Value;
                    R["idupb"] = DBNull.Value;
                    DS.fin.Clear();
                    txtBilancio.Text = "";
                    txtDescrBilancio.Text = "";
                    Meta.SetAutoField(DBNull.Value, txtUPB);
                    txtDescrUPB.Text = "";
                    return;
                }
                return;
            }
            if (Meta.IsEmpty) return;
            EnableDisable(true);

            DataRow RR = DS.csa_importriep.Rows[0];

            if (RR["idexp"] != DBNull.Value) {
                  if (DispMessage) {
                      if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questo contratto è necessario annullare il collegamento al movimento di spesa " +
                          ". Proseguo?", "Conferma",
                          MessageBoxButtons.OKCancel) != DialogResult.OK) {
                          chkSpesa.Checked = true;
                          return;
                      }
                }
                RR["idexp"] = DBNull.Value;
                DS.expenseview.Clear();
                cmbFaseSpesa.SelectedIndex = 0;
                txtEserc.Text = "";
                txtNum.Text = "";
            }
        }


       

        void EnableDisableParteSpesa(bool enable){
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseSpesa.Enabled = enable;
            btnSpesa.Enabled = enable;
		}
		void EnableDisableParteNormale(bool enable){
			btnBilancio.Enabled = enable;
			btnUPBCode.Enabled = enable;
            txtUPB.ReadOnly= !enable;
			txtBilancio.ReadOnly = !enable;			
		}

		void EnableDisable(bool parteNormale){
			EnableDisableParteNormale(parteNormale);
			EnableDisableParteSpesa(!parteNormale);
		}

        private void btnSpesa_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.csa_importriep.Rows[0];
             string filter = "";
            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                        QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))));
            }
            int ymov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
            int nmov = CfgFn.GetNoNullInt32(txtNum.Text.Trim());
            if ((ymov != 0) && (nmov != 0)) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov), QHS.CmpEq("nmov", nmov));
            }
            else {
                var f = new FrmAskInfo(Meta, "S", true).EnableManagerSelection(false);                
                if (f.ShowDialog() != DialogResult.OK) return;

                if (ymov != 0) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
                }
                if ((nmov != 0)) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
                }
                var filterUpb = QHS.CmpEq("idupb", "0001");
                var filterFin = "";
                // Aggiunta filtro dell'UPB e del Bilancio
                if (f.GetUPB()!=DBNull.Value) {
                    
                    filterUpb = QHS.CmpEq("idupb", f.GetUPB());
                    
                    if (f.GetFin()!= DBNull.Value) {
                        filterFin = QHS.CmpEq("idfin", f.GetFin());
                    }
                }
               
                filter = QHS.AppAnd(filter, filterUpb);
                if (filterFin != "") {
                    filter = QHS.AppAnd(filter, filterFin);
                }
            }

            MetaData E = Meta.Dispatcher.Get("expense");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            DataRow Choosen = E.SelectOne("default", filter, "expense", null);
            if (Choosen == null) return;
            int oldIdExp = CfgFn.GetNoNullInt32(Curr["idexp"]);
            int newIdExp = CfgFn.GetNoNullInt32(Choosen["idexp"]);
            Curr["idexp"] = Choosen["idexp"];

            DS.expenseview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]), QHS.CmpEq("ayear", Conn.GetEsercizio())),
                null, true);
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
            

            Meta.FreshForm(false);
        }



	    public void MetaData_AfterFill() {
	        epm.mostraEtichette();
	        if (Meta.FirstFillForThisRow)  ImpostaCheckSpesa();
            bool usaVecchiaGestione = vecchiaGestione();
            if (!usaVecchiaGestione) {
                if (tabControl1.TabPages.Contains(tabPageMovFin)) {
                    tabControl1.TabPages.Remove(tabPageMovFin);
                }
            }
            else {
                if (!tabControl1.TabPages.Contains(tabPageMovFin)) {
                    tabControl1.TabPages.Add(tabPageMovFin);
                }
            }

            if (!Meta.InsertMode)       VisualizzaMovimentoSpesa();
            EnableDisableControlliInput(Meta.IsEmpty);
	        if (DS.epexp.Rows.Count > 0) {
	            object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
	            HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
	        }

            txtEserRegolaspecifica.ReadOnly = true;
            txtNumRegolaspecifica.ReadOnly = true;
            txtNumeroregGenerale.ReadOnly = true;
            txtRegolaGenerale.ReadOnly = true;
            txtCodiceRegGenerale.ReadOnly = true;
        }


        void EnableDisableControlliInput (bool enable) {
            //txtImporto.ReadOnly = !enable;
            txtCompetenza.ReadOnly = !enable;
            txtMatricola.ReadOnly = !enable;
            txtCapitoloCsa.ReadOnly = !enable;
            txtRuoloCsa.ReadOnly = !enable;
         }

        public void MetaData_AfterClear () {
            epm.mostraEtichette();
            ImpostaCheckSpesa();
            txtEserc.Text = "";
            txtNum.Text = "";
            txtEsercImport.Text = Conn.GetEsercizio().ToString();
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseImpBudget.SelectedIndex = -1;
            EnableDisableControlliInput(true);
            gboxImponibile.Enabled = true;
            
            txtNumeroregGenerale.ReadOnly = false;
            txtEserRegolaspecifica.ReadOnly = false;
            txtNumRegolaspecifica.ReadOnly = false;
            txtRegolaGenerale.ReadOnly = false;
            txtCodiceRegGenerale.ReadOnly = false;
        }

        void ImpostaCheckSpesa () {
            if (Meta.IsEmpty) {
                EnableDisable(true);
                return;
            }
            DataRow R = DS.csa_importriep.Rows[0];
            if (R["idexp"] != DBNull.Value)
                chkSpesa.Checked = true;
            else
                chkSpesa.Checked = false;
            chkSpesa_CheckedChanged(null, null,false);         
           
        }


        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_importriep"].Rows[0]["idexp"];
            string filter = QHS.CmpEq("idexp", idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
        }


        private void txtNum_Leave (object sender, EventArgs e) {

            if (Meta.IsEmpty) return;
            if (txtNum.ReadOnly) return;
            DataRow Curr = DS.csa_importriep.Rows[0];
            if ((Curr["idexp"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp"] = DBNull.Value;
            }
            btnSpesa_Click(sender, e);
        }

        private void txtEserc_Leave (object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importriep.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNum.Text = "";
                            DS.expenseview.Clear();
                            Curr["idexp"] = DBNull.Value;
                        }
                    }
                    else {
                        txtNum.Text = "";
                        DS.expenseview.Clear();
                        Curr["idexp"] = DBNull.Value;
                    }
                }

            }

        }

        private void cmbFaseSpesa_SelectedIndexChanged (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.csa_importriep.Rows[0];
            if (Curr["idexp"] != DBNull.Value) {
                if (DS.expenseview.Rows.Count > 0) {
                    int oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                    int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                    if (oldNphase != newNPhase) {
                        txtNum.Text = "";
                        txtEserc.Text = "";
                        DS.expenseview.Clear();
                        Curr["idexp"] = DBNull.Value;
                    }
                }
                else {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    Curr["idexp"] = DBNull.Value;
                }
            }
        }
        public void MetaData_BeforePost() {
            epm.beforePost();
        }

        public void MetaData_AfterPost() {
            epm.afterPost();
        }

        void EnableFaseImpegnoBudget(int nphase, string descrizione)
        {
            DataRow R = DS.fase_epexp.NewRow();
            R["nphase"] = nphase;
            R["descrizione"] = descrizione;
            DS.fase_epexp.Rows.Add(R);
            DS.fase_epexp.AcceptChanges();
        }
        private void btnLinkEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.csa_importriep.Rows[0];
            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);
            if ((Meta.EditMode) && (!vecchiaGestione())) {
                txtEsercImport.Text = Conn.GetEsercizio().ToString();
                var idrel = BudgetFunction.GetIdForDocument(curr);
                DataTable mov_budg = Conn.RUN_SELECT("epexp", "idepexp", null, QHS.CmpEq("idrelated", idrel), null, true);
                if (mov_budg.Rows.Count > 0) {
                    MessageBox.Show("Non è possibile collegare un preimpegno di budget perchè vi sono già impegni di budget collegati");
                    return;
                }
            }
            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filter_fase = "";
            if (CfgFn.GetNoNullInt32(nphase) == 0)
            {
                filter_fase = QHS.AppOr(QHS.DoPar(QHS.CmpEq("nphase", 1)),
                                        QHS.DoPar(QHS.CmpEq("nphase", 2)));
            }
            if ((CfgFn.GetNoNullInt32(nphase) == 1) || (CfgFn.GetNoNullInt32(nphase) == 2))
            {
                filter_fase = QHS.CmpEq("nphase", nphase);
            }

            filter = QHS.AppAnd(filter, filter_fase);

            String fAmount = QHS.CmpGt("(totcurramount - isnull(totalcost,0))", 0); // condizione sul disponibile
            filter = QHS.AppAnd(filter, fAmount);

            string VistaScelta = "epexpview";

            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow myDr = mepexp.SelectOne("default", filter, null, null);

            if (myDr != null)
            {
                curr["idepexp"] = myDr["idepexp"];
                Meta.FreshForm();
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importriep.Rows[0];
            if ((Meta.EditMode) && (!vecchiaGestione())) {
                txtEsercImport.Text = Conn.GetEsercizio().ToString();
                var idrel = BudgetFunction.GetIdForDocument(Curr);
                DataTable mov_budg = Conn.RUN_SELECT("epexp", "idepexp", null, QHS.CmpEq("idrelated", idrel), null, true);
                if ((mov_budg.Rows.Count > 0)&&(Curr["idepexp"]!=DBNull.Value)){
                    MessageBox.Show("Non è possibile scollegare un preimpegno di budget perchè vi sono già impegni di budget collegati");
                    return;
                }
              
            }
            Curr["idepexp"] = DBNull.Value;
            DS.epexp.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
            Meta.FreshForm();
        }

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (cmbFaseImpBudget.SelectedIndex <= 0)
            {
                btnRemoveEpExp_Click(sender, e);
            }
        }
    }
}
