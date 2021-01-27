
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
namespace csa_importver_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_importver_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
		private System.ComponentModel.IContainer components;
        MetaData Meta;
        private GroupBox groupBox4;
        private TextBox txtNumVer;
        private Label label6;
        private GroupBox gboxtipo;
        private RadioButton rdbCompetenza;
        private RadioButton rdbResidui;
        private GroupBox groupBox3;
        private TextBox txtNumImport;
        private Label label8;
        private TextBox txtEsercImport;
        private Label label9;
        private GroupBox groupBox6;
        private TextBox txtImporto;
        private GroupBox grpMatricola;
        private TextBox txtMatricola;
        private GroupBox groupBox1;
        private TextBox txtCompetenza;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Button btnModalita;
        private TextBox txtDescModalita;
        private GroupBox groupBox7;
        private ComboBox cmbEnte;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private GroupBox groupBox5;
        private TextBox txtNumContratto;
        private Label label14;
        private TextBox textBox3;
        private Label label15;
        private GroupBox groupBox8;
        private Label label5;
        private TextBox txtEnteCsa;
        private TextBox txtVoceCsa;
        private Label label1;
        private Label label2;
        private TextBox txtRuoloCsa;
        private TextBox txtCapitoloCsa;
        private Label label3;
        private TabControl tabControl1;
        private GroupBox gBoxContoRicavo;
        private TextBox txtDenominazioneContoRicavo;
        private TextBox txtCodiceContoRicavo;
        private Button button4;
        private GroupBox grpBilancioEntrata;
        private TextBox textBox12;
        private TextBox txtBilancioEntrata;
        private Button btnBilancioEntrata;
        private GroupBox grpContoDebito;
        private TextBox textBox14;
        public TextBox txtContoDebito;
        private Button btnContoDebito;
        private GroupBox gboxContoCosto;
        private TextBox txtDenominazioneConto;
        public TextBox txtCodiceContoCosto;
        private Button btnContoCosto;
        private GroupBox grpBilancioCosto;
        private TextBox txtDescrBilancio;
        public TextBox txtBilancioCosto;
        private Button btnBilancioCosto;
        private CheckBox chkSpesa;
        private GroupBox gboxSpesa;
        private Label label7;
        private TextBox txtNum;
        private Label label13;
        private TextBox txtEserc;
        private Label label12;
        private ComboBox cmbFaseSpesa;
        private Button btnSpesa;
        private GroupBox grpEntrataInterno;
        private TextBox textBox16;
        public TextBox txtBilancioEntrataInterno;
        private Button btnEntrataInterno;
        private GroupBox grpContoEntrataInterno;
        private TextBox textBox18;
        public TextBox txtCodiceContoInterno;
        private Button btnContoEntrataInterno;
        private CheckBox chkRecupero;
        private GroupBox grpBilancioSpesa;
        private TextBox textBox6;
        private TextBox txtBilancioSpesa;
        private Button btnBilancioSpesa;
        private GroupBox grpContoSpesa;
        private TextBox textBox10;
        private TextBox txtCodiceContoSpesa;
        private Button btnContoSpesa;
        private GroupBox groupBox11;
        private TextBox txtCredDebEnte;
        private GroupBox groupBox12;
        private TextBox textBox1;
        public TextBox txtAgencyCredit;
        private Button button1;
        private GroupBox grpModalitaRecuperi;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        public GroupBox grpSiopeCosto;
        public Button btnCodiceSiopeCosto;
        private TextBox txtDenomSiope;
        public TextBox txtCodiceSiopeCosto;
        public GroupBox grpSiopeEntrata;
        public Button btnSiopeEntrata;
        private TextBox textBox2;
        private TextBox txtCodiceSiopeEntrata;
        public GroupBox grpSiopeSpesa;
        public Button btnSiopeSpesa;
        private TextBox txtDescrSiopeVersamentoRit;
        private TextBox txtSiopeSpesa;
        public GroupBox grpSiopeEntrataInterno;
        public Button btnSiopeEntrataInt;
        private TextBox txtDescrSiopeEntrata;
        public TextBox txtSiopeEntrataInt;
        private GroupBox groupBox13;
        private TextBox txtUnderwriting;
        private Button btnUnderwriting;
        private TabPage tabRitenute;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private TextBox textBox4;
        private Label label4;
        private TabPage tabPageEP;
        private GroupBox gboxImponibile;
        private Label label10;
        private ComboBox cmbFaseImpBudget;
        private Label label34;
        private Label label33;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private GroupBox groupBox9;
        private DataGrid dataGrid2;
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private GroupBox groupBox14;
        private DataGrid dataGrid1;
        private GroupBox groupBox15;
        private DataGrid dataGrid3;
        private Button button2;
        private Button button3;
        private Button button5;
        private Button btnInserisci;
        private Button btnModifica;
        private Button btnElimina;
        private TabPage tabPageMovFin;
        private GroupBox groupBox17;
        private DataGrid dataGrid5;
        private GroupBox groupBox18;
        private DataGrid dataGrid6;
        private Button button9;
        private Button button10;
        private TabPage tabPartizioneUnica;
        private Button button6;
        private Button button7;
        private Button button8;
        private DataGrid dataGrid4;
        private TabPage tabVecchiaCfg;
        private TabControl tabControl2;
        private TabPage tabPage8;
        private TabPage tabPage9;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private TabPage tabPage3;
        DataAccess Conn;
		public Frm_csa_importver_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.csa_contractkind.Columns["flagcr"], true);
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
            DataAccess.SetTableForReading(DS.fin_cost, "fin");
            DataAccess.SetTableForReading(DS.fin_income, "fin");
            DataAccess.SetTableForReading(DS.registry_agency, "registry");
            DataAccess.SetTableForReading(DS.account_cost, "account");
            DataAccess.SetTableForReading(DS.account_agency_credit, "account");
            DataAccess.SetTableForReading(DS.account_debit, "account");
            DataAccess.SetTableForReading(DS.fin_expense, "fin");
            DataAccess.SetTableForReading(DS.account_expense, "account");
            DataAccess.SetTableForReading(DS.fin_incomeclawback, "fin");
            DataAccess.SetTableForReading(DS.account_internalcredit, "account");
            DataAccess.SetTableForReading(DS.account_revenue, "account");
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);
            GetData.SetStaticFilter(DS.csa_import, QHS.CmpEq("yimport", Conn.GetEsercizio()));
            //GetData.SetStaticFilter(DS.csa_import, filter);
            GetData.SetStaticFilter(DS.account_revenue, filter);
            GetData.SetStaticFilter(DS.account_agency_credit, filter);
            GetData.SetStaticFilter(DS.csa_contractkindyear, filter);
            GetData.SetStaticFilter(DS.csa_contracttax, filter);
            GetData.SetStaticFilter(DS.csa_contractkinddata, filter);
            GetData.SetStaticFilter(DS.csa_incomesetup, filter);
            GetData.SetStaticFilter(DS.fin_cost, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.fin_expense, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.fin_incomeclawback, QHS.AppAnd(filter, QHS.BitClear("flag", 0)));
            GetData.SetStaticFilter(DS.fin_income, QHS.AppAnd(filter, QHS.BitClear("flag", 0)));
            GetData.SetStaticFilter(DS.account_debit, filter);
            GetData.SetStaticFilter(DS.account_cost, filter);
            GetData.SetStaticFilter(DS.account_expense, filter);
            GetData.SetStaticFilter(DS.account_internalcredit, filter);
            GetData.SetStaticFilter(DS.expenseview, filter);
            GetData.SetStaticFilter(DS.expenseview1, filter);
            GetData.SetStaticFilter(DS.expenseview2, filter);
            GetData.SetStaticFilter(DS.expenseview3, filter);
            GetData.SetStaticFilter(DS.epexpview2, filter);
            GetData.SetStaticFilter(DS.epexp_ver, filter);

            GetData.CacheTable(DS.csa_agency);
            GetData.MarkToAddBlankRow(DS.csa_agency);
            GetData.Add_Blank_Row(DS.csa_agency);
            GetData.SetSorting(DS.upb, "codeupb asc");
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_importver.Columns["flagclawback"], true);
            HelpForm.SetDenyNull(DS.csa_importver.Columns["flagcr"], true);

            DataAccess.SetTableForReading(DS.sorting_cost, "sorting");
            DataAccess.SetTableForReading(DS.sorting_income, "sorting");
            DataAccess.SetTableForReading(DS.sorting_expense, "sorting");
            DataAccess.SetTableForReading(DS.sorting_incomeclawback, "sorting");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.epexpview2, "epexpview");
            DataAccess.SetTableForReading(DS.epexpview3, "epexpview");
            DataAccess.SetTableForReading(DS.epexp_ver, "epexpview");
            DataAccess.SetTableForReading(DS.expenseview1, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview2, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview3, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview4, "expenseview");
            
            DataAccess.SetTableForReading(DS.fin2, "fin");
            DataAccess.SetTableForReading(DS.upb2, "upb");
            DataAccess.SetTableForReading(DS.account2, "account");
            string filterSiopeS = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));


            DataTable tSortingkindS = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiopeS, null, null, true);
            if ((tSortingkindS != null) && (tSortingkindS.Rows.Count > 0)){
                DataRow RS = tSortingkindS.Rows[0];
                object idsorkindS = RS["idsorkind"];
                SetGBoxClass(null, idsorkindS);
            }
            string filterSiopeE = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate"));
            DataTable tSortingkindE = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiopeE, null, null, true);
            if ((tSortingkindE != null) && (tSortingkindE.Rows.Count > 0)){
                DataRow RE = tSortingkindE.Rows[0];
                object idsorkindE = RE["idsorkind"];
                SetGBoxClass(idsorkindE, null);
            }
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
            epm = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni, null, null,
                            null, null, "csa_importver");

       
        }

      
        void SetGBoxClass(object sortingkindE, object sortingkindS){
            if ((sortingkindE != null) && (sortingkindE != DBNull.Value)){
                string filterE = QHS.CmpEq("idsorkind", sortingkindE);
                GetData.SetStaticFilter(DS.sorting_income, filterE);
                GetData.SetStaticFilter(DS.sorting_incomeclawback, filterE);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filterE, "description").ToString();

                grpSiopeEntrata.Tag = "AutoManage.txtCodiceSiopeEntrata.tree." + filterE;
                btnSiopeEntrata.Tag = "manage.sorting_income.tree." + filterE;
                btnSiopeEntrata.Text = title;

                grpSiopeEntrataInterno.Tag = "AutoManage.txtSiopeEntrataInt.tree." + filterE;
                btnSiopeEntrataInt.Tag = "manage.sorting_incomeclawback.tree." + filterE;
                grpSiopeEntrataInterno.Text = title;
            }
            if ((sortingkindS != null) && (sortingkindE != DBNull.Value))
            {
                string filterS = QHS.CmpEq("idsorkind", sortingkindS);
                GetData.SetStaticFilter(DS.sorting_expense, filterS);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filterS, "description").ToString();

                grpSiopeSpesa.Text = title;
                grpSiopeSpesa.Tag = "AutoManage.txtSiopeSpesa.tree." + filterS;
                btnSiopeSpesa.Tag = "manage.sorting_expense.tree." + filterS;

                grpSiopeCosto.Tag = "AutoManage.txtCodiceSiopeCosto.tree." + filterS;
                btnCodiceSiopeCosto.Tag = "manage.sorting_cost.tree." + filterS;
                btnCodiceSiopeCosto.Text = title;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_importver_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new csa_importver_default.vistaForm();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtNumVer = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.gboxtipo = new System.Windows.Forms.GroupBox();
			this.rdbCompetenza = new System.Windows.Forms.RadioButton();
			this.rdbResidui = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtNumImport = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtEsercImport = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.grpMatricola = new System.Windows.Forms.GroupBox();
			this.txtMatricola = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtCompetenza = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnModalita = new System.Windows.Forms.Button();
			this.txtDescModalita = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cmbEnte = new System.Windows.Forms.ComboBox();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtNumContratto = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEnteCsa = new System.Windows.Forms.TextBox();
			this.txtVoceCsa = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRuoloCsa = new System.Windows.Forms.TextBox();
			this.txtCapitoloCsa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPartizioneUnica = new System.Windows.Forms.TabPage();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.grpSiopeSpesa = new System.Windows.Forms.GroupBox();
			this.btnSiopeSpesa = new System.Windows.Forms.Button();
			this.txtDescrSiopeVersamentoRit = new System.Windows.Forms.TextBox();
			this.txtSiopeSpesa = new System.Windows.Forms.TextBox();
			this.grpSiopeEntrata = new System.Windows.Forms.GroupBox();
			this.btnSiopeEntrata = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.txtCodiceSiopeEntrata = new System.Windows.Forms.TextBox();
			this.grpBilancioSpesa = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.txtBilancioSpesa = new System.Windows.Forms.TextBox();
			this.btnBilancioSpesa = new System.Windows.Forms.Button();
			this.grpBilancioEntrata = new System.Windows.Forms.GroupBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.txtBilancioEntrata = new System.Windows.Forms.TextBox();
			this.btnBilancioEntrata = new System.Windows.Forms.Button();
			this.tabPageEP = new System.Windows.Forms.TabPage();
			this.grpContoSpesa = new System.Windows.Forms.GroupBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoSpesa = new System.Windows.Forms.TextBox();
			this.btnContoSpesa = new System.Windows.Forms.Button();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtAgencyCredit = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.tabPageMovFin = new System.Windows.Forms.TabPage();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.button9 = new System.Windows.Forms.Button();
			this.dataGrid5 = new System.Windows.Forms.DataGrid();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.button10 = new System.Windows.Forms.Button();
			this.dataGrid6 = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.grpSiopeCosto = new System.Windows.Forms.GroupBox();
			this.btnCodiceSiopeCosto = new System.Windows.Forms.Button();
			this.txtDenomSiope = new System.Windows.Forms.TextBox();
			this.txtCodiceSiopeCosto = new System.Windows.Forms.TextBox();
			this.gboxContoCosto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceContoCosto = new System.Windows.Forms.TextBox();
			this.btnContoCosto = new System.Windows.Forms.Button();
			this.grpBilancioCosto = new System.Windows.Forms.GroupBox();
			this.txtDescrBilancio = new System.Windows.Forms.TextBox();
			this.txtBilancioCosto = new System.Windows.Forms.TextBox();
			this.btnBilancioCosto = new System.Windows.Forms.Button();
			this.grpSiopeEntrataInterno = new System.Windows.Forms.GroupBox();
			this.btnSiopeEntrataInt = new System.Windows.Forms.Button();
			this.txtDescrSiopeEntrata = new System.Windows.Forms.TextBox();
			this.txtSiopeEntrataInt = new System.Windows.Forms.TextBox();
			this.gBoxContoRicavo = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneContoRicavo = new System.Windows.Forms.TextBox();
			this.txtCodiceContoRicavo = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.grpEntrataInterno = new System.Windows.Forms.GroupBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.txtBilancioEntrataInterno = new System.Windows.Forms.TextBox();
			this.btnEntrataInterno = new System.Windows.Forms.Button();
			this.tabVecchiaCfg = new System.Windows.Forms.TabPage();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txtUnderwriting = new System.Windows.Forms.TextBox();
			this.btnUnderwriting = new System.Windows.Forms.Button();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.gboxImponibile = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.btnLinkEpExp = new System.Windows.Forms.Button();
			this.btnRemoveEpExp = new System.Windows.Forms.Button();
			this.txtNumImpegno = new System.Windows.Forms.TextBox();
			this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnElimina = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.grpContoDebito = new System.Windows.Forms.GroupBox();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.txtContoDebito = new System.Windows.Forms.TextBox();
			this.btnContoDebito = new System.Windows.Forms.Button();
			this.gboxSpesa = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.btnSpesa = new System.Windows.Forms.Button();
			this.chkSpesa = new System.Windows.Forms.CheckBox();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.grpModalitaRecuperi = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.grpContoEntrataInterno = new System.Windows.Forms.GroupBox();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.txtCodiceContoInterno = new System.Windows.Forms.TextBox();
			this.btnContoEntrataInterno = new System.Windows.Forms.Button();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtCredDebEnte = new System.Windows.Forms.TextBox();
			this.chkRecupero = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.gboxtipo.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.grpMatricola.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPartizioneUnica.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.tabRitenute.SuspendLayout();
			this.grpSiopeSpesa.SuspendLayout();
			this.grpSiopeEntrata.SuspendLayout();
			this.grpBilancioSpesa.SuspendLayout();
			this.grpBilancioEntrata.SuspendLayout();
			this.tabPageEP.SuspendLayout();
			this.grpContoSpesa.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.tabPageMovFin.SuspendLayout();
			this.groupBox17.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).BeginInit();
			this.groupBox18.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.grpSiopeCosto.SuspendLayout();
			this.gboxContoCosto.SuspendLayout();
			this.grpBilancioCosto.SuspendLayout();
			this.grpSiopeEntrataInterno.SuspendLayout();
			this.gBoxContoRicavo.SuspendLayout();
			this.grpEntrataInterno.SuspendLayout();
			this.tabVecchiaCfg.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.gboxImponibile.SuspendLayout();
			this.groupBox9.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabPage9.SuspendLayout();
			this.groupBox15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.groupBox14.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage10.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.grpContoDebito.SuspendLayout();
			this.gboxSpesa.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.grpModalitaRecuperi.SuspendLayout();
			this.grpContoEntrataInterno.SuspendLayout();
			this.groupBox11.SuspendLayout();
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
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtNumVer);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Location = new System.Drawing.Point(6, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(105, 59);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Tag = "";
			this.groupBox4.Text = "Versamento";
			// 
			// txtNumVer
			// 
			this.txtNumVer.Location = new System.Drawing.Point(22, 35);
			this.txtNumVer.Name = "txtNumVer";
			this.txtNumVer.Size = new System.Drawing.Size(56, 20);
			this.txtNumVer.TabIndex = 2;
			this.txtNumVer.Tag = "csa_importver.idver";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 17);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Numero:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxtipo
			// 
			this.gboxtipo.Controls.Add(this.rdbCompetenza);
			this.gboxtipo.Controls.Add(this.rdbResidui);
			this.gboxtipo.Location = new System.Drawing.Point(117, 5);
			this.gboxtipo.Name = "gboxtipo";
			this.gboxtipo.Size = new System.Drawing.Size(114, 59);
			this.gboxtipo.TabIndex = 2;
			this.gboxtipo.TabStop = false;
			this.gboxtipo.Text = "Tipo";
			// 
			// rdbCompetenza
			// 
			this.rdbCompetenza.Location = new System.Drawing.Point(11, 16);
			this.rdbCompetenza.Name = "rdbCompetenza";
			this.rdbCompetenza.Size = new System.Drawing.Size(90, 16);
			this.rdbCompetenza.TabIndex = 1;
			this.rdbCompetenza.Tag = "csa_importver.flagcr:C";
			this.rdbCompetenza.Text = "Competenza";
			// 
			// rdbResidui
			// 
			this.rdbResidui.Location = new System.Drawing.Point(11, 36);
			this.rdbResidui.Name = "rdbResidui";
			this.rdbResidui.Size = new System.Drawing.Size(90, 16);
			this.rdbResidui.TabIndex = 1;
			this.rdbResidui.Tag = "csa_importver.flagcr:R";
			this.rdbResidui.Text = "Residui";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtNumImport);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.txtEsercImport);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Location = new System.Drawing.Point(366, 14);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(271, 50);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Tag = "AutoChoose.txtNumImport.default";
			this.groupBox3.Text = "Importazione";
			// 
			// txtNumImport
			// 
			this.txtNumImport.Location = new System.Drawing.Point(195, 15);
			this.txtNumImport.Name = "txtNumImport";
			this.txtNumImport.Size = new System.Drawing.Size(56, 20);
			this.txtNumImport.TabIndex = 2;
			this.txtNumImport.Tag = "csa_import.nimport?csa_importverview.nimport";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(137, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 0;
			this.label8.Text = "Numero:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercImport
			// 
			this.txtEsercImport.Location = new System.Drawing.Point(68, 15);
			this.txtEsercImport.Name = "txtEsercImport";
			this.txtEsercImport.ReadOnly = true;
			this.txtEsercImport.Size = new System.Drawing.Size(56, 20);
			this.txtEsercImport.TabIndex = 1;
			this.txtEsercImport.Tag = "csa_import.yimport.year?csa_importverview.yimport.year";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 0;
			this.label9.Text = "Esercizio:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.txtImporto);
			this.groupBox6.Location = new System.Drawing.Point(643, 20);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(200, 43);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Importo";
			// 
			// txtImporto
			// 
			this.txtImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImporto.Location = new System.Drawing.Point(55, 16);
			this.txtImporto.Multiline = true;
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.Size = new System.Drawing.Size(138, 20);
			this.txtImporto.TabIndex = 1;
			this.txtImporto.TabStop = false;
			this.txtImporto.Tag = "csa_importver.importo";
			// 
			// grpMatricola
			// 
			this.grpMatricola.Controls.Add(this.txtMatricola);
			this.grpMatricola.Location = new System.Drawing.Point(493, 209);
			this.grpMatricola.Name = "grpMatricola";
			this.grpMatricola.Size = new System.Drawing.Size(142, 43);
			this.grpMatricola.TabIndex = 5;
			this.grpMatricola.TabStop = false;
			this.grpMatricola.Text = "Matricola";
			// 
			// txtMatricola
			// 
			this.txtMatricola.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMatricola.Location = new System.Drawing.Point(10, 17);
			this.txtMatricola.Name = "txtMatricola";
			this.txtMatricola.ReadOnly = true;
			this.txtMatricola.Size = new System.Drawing.Size(126, 20);
			this.txtMatricola.TabIndex = 1;
			this.txtMatricola.TabStop = false;
			this.txtMatricola.Tag = "csa_importver.matricola";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtCompetenza);
			this.groupBox1.Location = new System.Drawing.Point(237, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(123, 50);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Competenza";
			// 
			// txtCompetenza
			// 
			this.txtCompetenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCompetenza.Location = new System.Drawing.Point(6, 18);
			this.txtCompetenza.Multiline = true;
			this.txtCompetenza.Name = "txtCompetenza";
			this.txtCompetenza.ReadOnly = true;
			this.txtCompetenza.Size = new System.Drawing.Size(105, 20);
			this.txtCompetenza.TabIndex = 1;
			this.txtCompetenza.TabStop = false;
			this.txtCompetenza.Tag = "csa_importver.competenza";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Location = new System.Drawing.Point(6, 160);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(301, 43);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Regola generale CSA";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DataSource = this.DS.csa_contractkind;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(7, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(280, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "csa_importver.idcsa_contractkind";
			this.comboBox1.ValueMember = "idcsa_contractkind";
			// 
			// btnModalita
			// 
			this.btnModalita.Location = new System.Drawing.Point(6, 310);
			this.btnModalita.Name = "btnModalita";
			this.btnModalita.Size = new System.Drawing.Size(212, 28);
			this.btnModalita.TabIndex = 10;
			this.btnModalita.TabStop = false;
			this.btnModalita.Tag = "";
			this.btnModalita.Text = "Scegli Modalità di Pagamento Ente";
			this.btnModalita.Click += new System.EventHandler(this.btnModalita_Click);
			// 
			// txtDescModalita
			// 
			this.txtDescModalita.Location = new System.Drawing.Point(237, 307);
			this.txtDescModalita.Multiline = true;
			this.txtDescModalita.Name = "txtDescModalita";
			this.txtDescModalita.ReadOnly = true;
			this.txtDescModalita.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescModalita.Size = new System.Drawing.Size(463, 31);
			this.txtDescModalita.TabIndex = 11;
			this.txtDescModalita.TabStop = false;
			this.txtDescModalita.Tag = "csa_agencypaymethod.description";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cmbEnte);
			this.groupBox7.Location = new System.Drawing.Point(6, 256);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(301, 48);
			this.groupBox7.TabIndex = 6;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Ente";
			// 
			// cmbEnte
			// 
			this.cmbEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbEnte.DataSource = this.DS.csa_agency;
			this.cmbEnte.DisplayMember = "description";
			this.cmbEnte.Location = new System.Drawing.Point(9, 19);
			this.cmbEnte.Name = "cmbEnte";
			this.cmbEnte.Size = new System.Drawing.Size(286, 21);
			this.cmbEnte.TabIndex = 1;
			this.cmbEnte.Tag = "csa_importver.idcsa_agency";
			this.cmbEnte.ValueMember = "idcsa_agency";
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(6, 209);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(470, 41);
			this.groupCredDeb.TabIndex = 4;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.groupCredDeb.Text = "Anagrafica Regola specifica CSA";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(8, 17);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(456, 20);
			this.txtCredDeb.TabIndex = 1;
			this.txtCredDeb.Tag = "registry.title?csa_importverview?registry";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtNumContratto);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.textBox3);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Location = new System.Drawing.Point(313, 161);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(322, 42);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Tag = "AutoChoose.txtNumContratto.default";
			this.groupBox5.Text = "Regola specifica CSA";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(220, 13);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(68, 20);
			this.txtNumContratto.TabIndex = 2;
			this.txtNumContratto.Tag = "csa_contract.ncontract?csa_importverview.ncontract";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(156, 15);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(56, 16);
			this.label14.TabIndex = 0;
			this.label14.Text = "Numero:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(67, 14);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(56, 20);
			this.textBox3.TabIndex = 1;
			this.textBox3.Tag = "csa_contract.ycontract.year?csa_importverview.ycontract.year";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(3, 14);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 16);
			this.label15.TabIndex = 0;
			this.label15.Text = "Esercizio:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.textBox4);
			this.groupBox8.Controls.Add(this.label4);
			this.groupBox8.Controls.Add(this.label5);
			this.groupBox8.Controls.Add(this.txtEnteCsa);
			this.groupBox8.Controls.Add(this.txtVoceCsa);
			this.groupBox8.Controls.Add(this.label1);
			this.groupBox8.Controls.Add(this.label2);
			this.groupBox8.Controls.Add(this.txtRuoloCsa);
			this.groupBox8.Controls.Add(this.txtCapitoloCsa);
			this.groupBox8.Controls.Add(this.label3);
			this.groupBox8.Location = new System.Drawing.Point(6, 64);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(893, 90);
			this.groupBox8.TabIndex = 6;
			this.groupBox8.TabStop = false;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(189, 64);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(345, 20);
			this.textBox4.TabIndex = 6;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "csa_importver.vocecsaunified";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(190, 16);
			this.label4.TabIndex = 5;
			this.label4.Text = "Voce CSA per Raggruppamento:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(234, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Ente CSA:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEnteCsa
			// 
			this.txtEnteCsa.Location = new System.Drawing.Point(237, 33);
			this.txtEnteCsa.Name = "txtEnteCsa";
			this.txtEnteCsa.ReadOnly = true;
			this.txtEnteCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEnteCsa.Size = new System.Drawing.Size(227, 20);
			this.txtEnteCsa.TabIndex = 2;
			this.txtEnteCsa.TabStop = false;
			this.txtEnteCsa.Tag = "csa_importver.ente";
			// 
			// txtVoceCsa
			// 
			this.txtVoceCsa.Location = new System.Drawing.Point(656, 33);
			this.txtVoceCsa.Name = "txtVoceCsa";
			this.txtVoceCsa.ReadOnly = true;
			this.txtVoceCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtVoceCsa.Size = new System.Drawing.Size(227, 20);
			this.txtVoceCsa.TabIndex = 4;
			this.txtVoceCsa.TabStop = false;
			this.txtVoceCsa.Tag = "csa_importver.vocecsa";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(653, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Voce CSA:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(468, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Ruolo CSA:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRuoloCsa
			// 
			this.txtRuoloCsa.Location = new System.Drawing.Point(472, 33);
			this.txtRuoloCsa.Name = "txtRuoloCsa";
			this.txtRuoloCsa.ReadOnly = true;
			this.txtRuoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtRuoloCsa.Size = new System.Drawing.Size(170, 20);
			this.txtRuoloCsa.TabIndex = 3;
			this.txtRuoloCsa.TabStop = false;
			this.txtRuoloCsa.Tag = "csa_importver.ruolocsa";
			// 
			// txtCapitoloCsa
			// 
			this.txtCapitoloCsa.Location = new System.Drawing.Point(8, 33);
			this.txtCapitoloCsa.Name = "txtCapitoloCsa";
			this.txtCapitoloCsa.ReadOnly = true;
			this.txtCapitoloCsa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCapitoloCsa.Size = new System.Drawing.Size(223, 20);
			this.txtCapitoloCsa.TabIndex = 1;
			this.txtCapitoloCsa.TabStop = false;
			this.txtCapitoloCsa.Tag = "csa_importver.capitolocsa";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Capitolo CSA:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPartizioneUnica);
			this.tabControl1.Controls.Add(this.tabRitenute);
			this.tabControl1.Controls.Add(this.tabPageEP);
			this.tabControl1.Controls.Add(this.tabPageMovFin);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabVecchiaCfg);
			this.tabControl1.Location = new System.Drawing.Point(12, 347);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(891, 408);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabStop = false;
			// 
			// tabPartizioneUnica
			// 
			this.tabPartizioneUnica.Controls.Add(this.button6);
			this.tabPartizioneUnica.Controls.Add(this.button7);
			this.tabPartizioneUnica.Controls.Add(this.button8);
			this.tabPartizioneUnica.Controls.Add(this.dataGrid4);
			this.tabPartizioneUnica.Location = new System.Drawing.Point(4, 22);
			this.tabPartizioneUnica.Name = "tabPartizioneUnica";
			this.tabPartizioneUnica.Padding = new System.Windows.Forms.Padding(3);
			this.tabPartizioneUnica.Size = new System.Drawing.Size(883, 382);
			this.tabPartizioneUnica.TabIndex = 8;
			this.tabPartizioneUnica.Text = "Ripartizione unica";
			this.tabPartizioneUnica.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(7, 6);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(68, 22);
			this.button6.TabIndex = 26;
			this.button6.Tag = "insert.detail";
			this.button6.Text = "Inserisci";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(7, 38);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(68, 22);
			this.button7.TabIndex = 27;
			this.button7.Tag = "edit.detail";
			this.button7.Text = "Modifica";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(7, 70);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(68, 22);
			this.button8.TabIndex = 28;
			this.button8.Tag = "delete";
			this.button8.Text = "Elimina";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(81, 6);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(785, 358);
			this.dataGrid4.TabIndex = 20;
			this.dataGrid4.Tag = "csa_importver_partition.default.detail";
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.grpSiopeSpesa);
			this.tabRitenute.Controls.Add(this.grpSiopeEntrata);
			this.tabRitenute.Controls.Add(this.grpBilancioSpesa);
			this.tabRitenute.Controls.Add(this.grpBilancioEntrata);
			this.tabRitenute.Location = new System.Drawing.Point(4, 22);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(883, 382);
			this.tabRitenute.TabIndex = 2;
			this.tabRitenute.Text = "Ritenute";
			this.tabRitenute.UseVisualStyleBackColor = true;
			// 
			// grpSiopeSpesa
			// 
			this.grpSiopeSpesa.Controls.Add(this.btnSiopeSpesa);
			this.grpSiopeSpesa.Controls.Add(this.txtDescrSiopeVersamentoRit);
			this.grpSiopeSpesa.Controls.Add(this.txtSiopeSpesa);
			this.grpSiopeSpesa.Location = new System.Drawing.Point(438, 128);
			this.grpSiopeSpesa.Name = "grpSiopeSpesa";
			this.grpSiopeSpesa.Size = new System.Drawing.Size(380, 110);
			this.grpSiopeSpesa.TabIndex = 2;
			this.grpSiopeSpesa.TabStop = false;
			this.grpSiopeSpesa.Tag = "AutoManage.txtSiopeSpesa.treeclassmovimenti";
			this.grpSiopeSpesa.Text = "SIOPE Spesa";
			// 
			// btnSiopeSpesa
			// 
			this.btnSiopeSpesa.Location = new System.Drawing.Point(6, 55);
			this.btnSiopeSpesa.Name = "btnSiopeSpesa";
			this.btnSiopeSpesa.Size = new System.Drawing.Size(88, 23);
			this.btnSiopeSpesa.TabIndex = 4;
			this.btnSiopeSpesa.TabStop = false;
			this.btnSiopeSpesa.Tag = "manage.sorting_expense.tree";
			this.btnSiopeSpesa.Text = "Codice";
			this.btnSiopeSpesa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDescrSiopeVersamentoRit
			// 
			this.txtDescrSiopeVersamentoRit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrSiopeVersamentoRit.Location = new System.Drawing.Point(113, 14);
			this.txtDescrSiopeVersamentoRit.Multiline = true;
			this.txtDescrSiopeVersamentoRit.Name = "txtDescrSiopeVersamentoRit";
			this.txtDescrSiopeVersamentoRit.ReadOnly = true;
			this.txtDescrSiopeVersamentoRit.Size = new System.Drawing.Size(259, 64);
			this.txtDescrSiopeVersamentoRit.TabIndex = 3;
			this.txtDescrSiopeVersamentoRit.TabStop = false;
			this.txtDescrSiopeVersamentoRit.Tag = "sorting_expense.description";
			// 
			// txtSiopeSpesa
			// 
			this.txtSiopeSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtSiopeSpesa.Location = new System.Drawing.Point(6, 84);
			this.txtSiopeSpesa.Name = "txtSiopeSpesa";
			this.txtSiopeSpesa.Size = new System.Drawing.Size(366, 20);
			this.txtSiopeSpesa.TabIndex = 4;
			this.txtSiopeSpesa.Tag = "sorting_expense.sortcode?importverview.sortcode_expense";
			// 
			// grpSiopeEntrata
			// 
			this.grpSiopeEntrata.Controls.Add(this.btnSiopeEntrata);
			this.grpSiopeEntrata.Controls.Add(this.textBox2);
			this.grpSiopeEntrata.Controls.Add(this.txtCodiceSiopeEntrata);
			this.grpSiopeEntrata.Location = new System.Drawing.Point(438, 8);
			this.grpSiopeEntrata.Name = "grpSiopeEntrata";
			this.grpSiopeEntrata.Size = new System.Drawing.Size(380, 114);
			this.grpSiopeEntrata.TabIndex = 2;
			this.grpSiopeEntrata.TabStop = false;
			this.grpSiopeEntrata.Tag = "AutoManage.txtCodiceSiopeEntrata.treeclassmovimenti";
			this.grpSiopeEntrata.Text = "SIOPE Entrata";
			// 
			// btnSiopeEntrata
			// 
			this.btnSiopeEntrata.Location = new System.Drawing.Point(6, 59);
			this.btnSiopeEntrata.Name = "btnSiopeEntrata";
			this.btnSiopeEntrata.Size = new System.Drawing.Size(88, 23);
			this.btnSiopeEntrata.TabIndex = 4;
			this.btnSiopeEntrata.TabStop = false;
			this.btnSiopeEntrata.Tag = "manage.sorting_income.tree";
			this.btnSiopeEntrata.Text = "Codice";
			this.btnSiopeEntrata.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(113, 14);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(260, 68);
			this.textBox2.TabIndex = 3;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "sorting_income.description";
			// 
			// txtCodiceSiopeEntrata
			// 
			this.txtCodiceSiopeEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodiceSiopeEntrata.Location = new System.Drawing.Point(6, 88);
			this.txtCodiceSiopeEntrata.Name = "txtCodiceSiopeEntrata";
			this.txtCodiceSiopeEntrata.Size = new System.Drawing.Size(366, 20);
			this.txtCodiceSiopeEntrata.TabIndex = 3;
			this.txtCodiceSiopeEntrata.Tag = "sorting_income.sortcode?csa_importverview.sortcode_income";
			// 
			// grpBilancioSpesa
			// 
			this.grpBilancioSpesa.Controls.Add(this.textBox6);
			this.grpBilancioSpesa.Controls.Add(this.txtBilancioSpesa);
			this.grpBilancioSpesa.Controls.Add(this.btnBilancioSpesa);
			this.grpBilancioSpesa.Location = new System.Drawing.Point(6, 123);
			this.grpBilancioSpesa.Name = "grpBilancioSpesa";
			this.grpBilancioSpesa.Size = new System.Drawing.Size(416, 115);
			this.grpBilancioSpesa.TabIndex = 1;
			this.grpBilancioSpesa.TabStop = false;
			this.grpBilancioSpesa.Tag = "AutoManage.txtBilancioSpesa.trees";
			this.grpBilancioSpesa.Text = "Capitolo di Spesa per versamento (Ritenuta partita di giro)";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(144, 16);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(265, 67);
			this.textBox6.TabIndex = 0;
			this.textBox6.TabStop = false;
			this.textBox6.Tag = "fin_expense.title";
			// 
			// txtBilancioSpesa
			// 
			this.txtBilancioSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBilancioSpesa.Location = new System.Drawing.Point(7, 89);
			this.txtBilancioSpesa.Name = "txtBilancioSpesa";
			this.txtBilancioSpesa.Size = new System.Drawing.Size(403, 20);
			this.txtBilancioSpesa.TabIndex = 2;
			this.txtBilancioSpesa.Tag = "fin_expense.codefin?csa_importverview.codefin_expense";
			// 
			// btnBilancioSpesa
			// 
			this.btnBilancioSpesa.ImageIndex = 0;
			this.btnBilancioSpesa.Location = new System.Drawing.Point(8, 41);
			this.btnBilancioSpesa.Name = "btnBilancioSpesa";
			this.btnBilancioSpesa.Size = new System.Drawing.Size(90, 24);
			this.btnBilancioSpesa.TabIndex = 1;
			this.btnBilancioSpesa.TabStop = false;
			this.btnBilancioSpesa.Tag = "manage.fin_expense.trees";
			this.btnBilancioSpesa.Text = "Bilancio";
			this.btnBilancioSpesa.Click += new System.EventHandler(this.btnBilancioSpesa_Click);
			// 
			// grpBilancioEntrata
			// 
			this.grpBilancioEntrata.Controls.Add(this.textBox12);
			this.grpBilancioEntrata.Controls.Add(this.txtBilancioEntrata);
			this.grpBilancioEntrata.Controls.Add(this.btnBilancioEntrata);
			this.grpBilancioEntrata.Location = new System.Drawing.Point(6, 3);
			this.grpBilancioEntrata.Name = "grpBilancioEntrata";
			this.grpBilancioEntrata.Size = new System.Drawing.Size(416, 114);
			this.grpBilancioEntrata.TabIndex = 1;
			this.grpBilancioEntrata.TabStop = false;
			this.grpBilancioEntrata.Tag = "AutoManage.txtBilancioEntrata.treee";
			this.grpBilancioEntrata.Text = "Capitolo di Entrata (Ritenuta partita di giro)";
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(144, 16);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(265, 64);
			this.textBox12.TabIndex = 0;
			this.textBox12.TabStop = false;
			this.textBox12.Tag = "fin_income.title";
			// 
			// txtBilancioEntrata
			// 
			this.txtBilancioEntrata.Location = new System.Drawing.Point(6, 86);
			this.txtBilancioEntrata.Name = "txtBilancioEntrata";
			this.txtBilancioEntrata.Size = new System.Drawing.Size(403, 20);
			this.txtBilancioEntrata.TabIndex = 2;
			this.txtBilancioEntrata.Tag = "fin_income.codefin?csa_importverview.codefin_income";
			// 
			// btnBilancioEntrata
			// 
			this.btnBilancioEntrata.ImageIndex = 0;
			this.btnBilancioEntrata.Location = new System.Drawing.Point(6, 56);
			this.btnBilancioEntrata.Name = "btnBilancioEntrata";
			this.btnBilancioEntrata.Size = new System.Drawing.Size(90, 24);
			this.btnBilancioEntrata.TabIndex = 1;
			this.btnBilancioEntrata.TabStop = false;
			this.btnBilancioEntrata.Tag = "manage.fin_income.treee";
			this.btnBilancioEntrata.Text = "Bilancio";
			// 
			// tabPageEP
			// 
			this.tabPageEP.Controls.Add(this.grpContoSpesa);
			this.tabPageEP.Controls.Add(this.groupBox12);
			this.tabPageEP.Controls.Add(this.btnGeneraPreImpegni);
			this.tabPageEP.Controls.Add(this.btnViewPreimpegni);
			this.tabPageEP.Controls.Add(this.btnGeneraEpExp);
			this.tabPageEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPageEP.Location = new System.Drawing.Point(4, 22);
			this.tabPageEP.Name = "tabPageEP";
			this.tabPageEP.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageEP.Size = new System.Drawing.Size(883, 382);
			this.tabPageEP.TabIndex = 5;
			this.tabPageEP.Text = "EP";
			this.tabPageEP.UseVisualStyleBackColor = true;
			// 
			// grpContoSpesa
			// 
			this.grpContoSpesa.Controls.Add(this.textBox10);
			this.grpContoSpesa.Controls.Add(this.txtCodiceContoSpesa);
			this.grpContoSpesa.Controls.Add(this.btnContoSpesa);
			this.grpContoSpesa.Location = new System.Drawing.Point(18, 101);
			this.grpContoSpesa.Name = "grpContoSpesa";
			this.grpContoSpesa.Size = new System.Drawing.Size(416, 126);
			this.grpContoSpesa.TabIndex = 3;
			this.grpContoSpesa.TabStop = false;
			this.grpContoSpesa.Tag = "AutoManage.txtCodiceContoSpesa.tree";
			this.grpContoSpesa.Text = "Conto di debito verso Ente";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(114, 18);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox10.Size = new System.Drawing.Size(296, 76);
			this.textBox10.TabIndex = 0;
			this.textBox10.TabStop = false;
			this.textBox10.Tag = "account_expense.title";
			// 
			// txtCodiceContoSpesa
			// 
			this.txtCodiceContoSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceContoSpesa.Location = new System.Drawing.Point(5, 100);
			this.txtCodiceContoSpesa.Name = "txtCodiceContoSpesa";
			this.txtCodiceContoSpesa.Size = new System.Drawing.Size(405, 20);
			this.txtCodiceContoSpesa.TabIndex = 2;
			this.txtCodiceContoSpesa.Tag = "account_expense.codeacc?csa_importverview.codeacc_expense";
			// 
			// btnContoSpesa
			// 
			this.btnContoSpesa.Location = new System.Drawing.Point(8, 71);
			this.btnContoSpesa.Name = "btnContoSpesa";
			this.btnContoSpesa.Size = new System.Drawing.Size(98, 23);
			this.btnContoSpesa.TabIndex = 1;
			this.btnContoSpesa.TabStop = false;
			this.btnContoSpesa.Tag = "manage.account_expense.tree";
			this.btnContoSpesa.Text = "Conto";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.textBox1);
			this.groupBox12.Controls.Add(this.txtAgencyCredit);
			this.groupBox12.Controls.Add(this.button1);
			this.groupBox12.Location = new System.Drawing.Point(18, 233);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(416, 105);
			this.groupBox12.TabIndex = 6;
			this.groupBox12.TabStop = false;
			this.groupBox12.Tag = "AutoManage.txtAgencyCredit.tree";
			this.groupBox12.Text = "Conto EP di Credito verso Ente per contributi e ritenute negativi";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(116, 21);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(294, 52);
			this.textBox1.TabIndex = 0;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "account_agency_credit.title";
			// 
			// txtAgencyCredit
			// 
			this.txtAgencyCredit.Location = new System.Drawing.Point(5, 79);
			this.txtAgencyCredit.Name = "txtAgencyCredit";
			this.txtAgencyCredit.Size = new System.Drawing.Size(403, 20);
			this.txtAgencyCredit.TabIndex = 2;
			this.txtAgencyCredit.Tag = "account_agency_credit.codeacc?csa_importverview.codeacc_agency_credit";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(7, 45);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 23);
			this.button1.TabIndex = 1;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.account_agency_credit.tree";
			this.button1.Text = "Conto";
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(16, 18);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
			this.btnGeneraPreImpegni.TabIndex = 51;
			this.btnGeneraPreImpegni.Text = "Genera movimenti di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(16, 50);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
			this.btnViewPreimpegni.TabIndex = 50;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni/preaccertamenti di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(325, 18);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 49;
			this.btnGeneraEpExp.Text = "Genera movimenti di Budget ultima fase";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(325, 50);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 48;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni/Accertamenti di Budget";
			// 
			// tabPageMovFin
			// 
			this.tabPageMovFin.Controls.Add(this.groupBox17);
			this.tabPageMovFin.Controls.Add(this.groupBox18);
			this.tabPageMovFin.Location = new System.Drawing.Point(4, 22);
			this.tabPageMovFin.Name = "tabPageMovFin";
			this.tabPageMovFin.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMovFin.Size = new System.Drawing.Size(883, 382);
			this.tabPageMovFin.TabIndex = 7;
			this.tabPageMovFin.Text = "Movimenti Finanziari";
			this.tabPageMovFin.UseVisualStyleBackColor = true;
			// 
			// groupBox17
			// 
			this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox17.Controls.Add(this.button9);
			this.groupBox17.Controls.Add(this.dataGrid5);
			this.groupBox17.Location = new System.Drawing.Point(11, 6);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(866, 189);
			this.groupBox17.TabIndex = 55;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Entrata";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(14, 78);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(68, 22);
			this.button9.TabIndex = 28;
			this.button9.Tag = "edit.detail";
			this.button9.Text = "Visualizza";
			// 
			// dataGrid5
			// 
			this.dataGrid5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid5.DataMember = "";
			this.dataGrid5.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid5.Location = new System.Drawing.Point(96, 19);
			this.dataGrid5.Name = "dataGrid5";
			this.dataGrid5.Size = new System.Drawing.Size(756, 154);
			this.dataGrid5.TabIndex = 20;
			this.dataGrid5.Tag = "csa_importver_partition_income.default.detail";
			// 
			// groupBox18
			// 
			this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox18.Controls.Add(this.button10);
			this.groupBox18.Controls.Add(this.dataGrid6);
			this.groupBox18.Location = new System.Drawing.Point(11, 201);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(866, 168);
			this.groupBox18.TabIndex = 54;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Spesa";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(14, 67);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(68, 22);
			this.button10.TabIndex = 28;
			this.button10.Tag = "edit.detail";
			this.button10.Text = "Visualizza";
			// 
			// dataGrid6
			// 
			this.dataGrid6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid6.DataMember = "";
			this.dataGrid6.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid6.Location = new System.Drawing.Point(96, 19);
			this.dataGrid6.Name = "dataGrid6";
			this.dataGrid6.Size = new System.Drawing.Size(758, 143);
			this.dataGrid6.TabIndex = 20;
			this.dataGrid6.Tag = "csa_importver_partition_expense.default.detail";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.grpSiopeCosto);
			this.tabPage3.Controls.Add(this.gboxContoCosto);
			this.tabPage3.Controls.Add(this.grpBilancioCosto);
			this.tabPage3.Controls.Add(this.grpSiopeEntrataInterno);
			this.tabPage3.Controls.Add(this.gBoxContoRicavo);
			this.tabPage3.Controls.Add(this.grpEntrataInterno);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(883, 382);
			this.tabPage3.TabIndex = 10;
			this.tabPage3.Text = "Contributi negativi e Recuperi positivi e negativi";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// grpSiopeCosto
			// 
			this.grpSiopeCosto.Controls.Add(this.btnCodiceSiopeCosto);
			this.grpSiopeCosto.Controls.Add(this.txtDenomSiope);
			this.grpSiopeCosto.Controls.Add(this.txtCodiceSiopeCosto);
			this.grpSiopeCosto.Location = new System.Drawing.Point(456, 255);
			this.grpSiopeCosto.Name = "grpSiopeCosto";
			this.grpSiopeCosto.Size = new System.Drawing.Size(405, 121);
			this.grpSiopeCosto.TabIndex = 5;
			this.grpSiopeCosto.TabStop = false;
			this.grpSiopeCosto.Tag = "AutoManage.txtCodiceSiopeCosto.treeclassmovimenti";
			this.grpSiopeCosto.Text = "SIOPE Spesa";
			this.grpSiopeCosto.Enter += new System.EventHandler(this.grpSiopeCosto_Enter);
			// 
			// btnCodiceSiopeCosto
			// 
			this.btnCodiceSiopeCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodiceSiopeCosto.Location = new System.Drawing.Point(6, 64);
			this.btnCodiceSiopeCosto.Name = "btnCodiceSiopeCosto";
			this.btnCodiceSiopeCosto.Size = new System.Drawing.Size(98, 23);
			this.btnCodiceSiopeCosto.TabIndex = 4;
			this.btnCodiceSiopeCosto.TabStop = false;
			this.btnCodiceSiopeCosto.Tag = "manage.sorting_cost.tree";
			this.btnCodiceSiopeCosto.Text = "Codice";
			this.btnCodiceSiopeCosto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenomSiope
			// 
			this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenomSiope.Location = new System.Drawing.Point(123, 19);
			this.txtDenomSiope.Multiline = true;
			this.txtDenomSiope.Name = "txtDenomSiope";
			this.txtDenomSiope.ReadOnly = true;
			this.txtDenomSiope.Size = new System.Drawing.Size(274, 68);
			this.txtDenomSiope.TabIndex = 3;
			this.txtDenomSiope.TabStop = false;
			this.txtDenomSiope.Tag = "sorting_cost.description";
			// 
			// txtCodiceSiopeCosto
			// 
			this.txtCodiceSiopeCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceSiopeCosto.Location = new System.Drawing.Point(6, 93);
			this.txtCodiceSiopeCosto.Name = "txtCodiceSiopeCosto";
			this.txtCodiceSiopeCosto.Size = new System.Drawing.Size(391, 20);
			this.txtCodiceSiopeCosto.TabIndex = 3;
			this.txtCodiceSiopeCosto.Tag = "sorting_cost.sortcode?csa_importverview.sortcode_cost";
			// 
			// gboxContoCosto
			// 
			this.gboxContoCosto.Controls.Add(this.txtDenominazioneConto);
			this.gboxContoCosto.Controls.Add(this.txtCodiceContoCosto);
			this.gboxContoCosto.Controls.Add(this.btnContoCosto);
			this.gboxContoCosto.Location = new System.Drawing.Point(456, 15);
			this.gboxContoCosto.Name = "gboxContoCosto";
			this.gboxContoCosto.Size = new System.Drawing.Size(405, 112);
			this.gboxContoCosto.TabIndex = 6;
			this.gboxContoCosto.TabStop = false;
			this.gboxContoCosto.Tag = "AutoManage.txtCodiceContoCosto.tree";
			this.gboxContoCosto.Text = "Conto EP di Costo (Recupero negativo)";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneConto.Location = new System.Drawing.Point(123, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(275, 64);
			this.txtDenominazioneConto.TabIndex = 0;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account_cost.title";
			// 
			// txtCodiceContoCosto
			// 
			this.txtCodiceContoCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceContoCosto.Location = new System.Drawing.Point(3, 86);
			this.txtCodiceContoCosto.Name = "txtCodiceContoCosto";
			this.txtCodiceContoCosto.Size = new System.Drawing.Size(394, 20);
			this.txtCodiceContoCosto.TabIndex = 2;
			this.txtCodiceContoCosto.Tag = "account_cost.codeacc?csa_importverview.codeacc_cost";
			// 
			// btnContoCosto
			// 
			this.btnContoCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnContoCosto.Location = new System.Drawing.Point(3, 57);
			this.btnContoCosto.Name = "btnContoCosto";
			this.btnContoCosto.Size = new System.Drawing.Size(101, 23);
			this.btnContoCosto.TabIndex = 1;
			this.btnContoCosto.TabStop = false;
			this.btnContoCosto.Tag = "manage.account_cost.tree";
			this.btnContoCosto.Text = "Conto";
			// 
			// grpBilancioCosto
			// 
			this.grpBilancioCosto.Controls.Add(this.txtDescrBilancio);
			this.grpBilancioCosto.Controls.Add(this.txtBilancioCosto);
			this.grpBilancioCosto.Controls.Add(this.btnBilancioCosto);
			this.grpBilancioCosto.Location = new System.Drawing.Point(456, 133);
			this.grpBilancioCosto.Name = "grpBilancioCosto";
			this.grpBilancioCosto.Size = new System.Drawing.Size(405, 116);
			this.grpBilancioCosto.TabIndex = 4;
			this.grpBilancioCosto.TabStop = false;
			this.grpBilancioCosto.Tag = "AutoManage.txtBilancioCosto.trees";
			this.grpBilancioCosto.Text = "Capitolo di Spesa per Costo (Recupero Negativo)";
			// 
			// txtDescrBilancio
			// 
			this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBilancio.Location = new System.Drawing.Point(123, 19);
			this.txtDescrBilancio.Multiline = true;
			this.txtDescrBilancio.Name = "txtDescrBilancio";
			this.txtDescrBilancio.ReadOnly = true;
			this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrBilancio.Size = new System.Drawing.Size(275, 69);
			this.txtDescrBilancio.TabIndex = 0;
			this.txtDescrBilancio.TabStop = false;
			this.txtDescrBilancio.Tag = "fin_cost.title";
			// 
			// txtBilancioCosto
			// 
			this.txtBilancioCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBilancioCosto.Location = new System.Drawing.Point(6, 89);
			this.txtBilancioCosto.Name = "txtBilancioCosto";
			this.txtBilancioCosto.Size = new System.Drawing.Size(391, 20);
			this.txtBilancioCosto.TabIndex = 2;
			this.txtBilancioCosto.Tag = "fin_cost.codefin?csa_importverview.codefin_cost";
			// 
			// btnBilancioCosto
			// 
			this.btnBilancioCosto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBilancioCosto.ImageIndex = 0;
			this.btnBilancioCosto.Location = new System.Drawing.Point(6, 64);
			this.btnBilancioCosto.Name = "btnBilancioCosto";
			this.btnBilancioCosto.Size = new System.Drawing.Size(98, 24);
			this.btnBilancioCosto.TabIndex = 1;
			this.btnBilancioCosto.TabStop = false;
			this.btnBilancioCosto.Tag = "manage.fin_cost.trees";
			this.btnBilancioCosto.Text = "Bilancio";
			this.btnBilancioCosto.Click += new System.EventHandler(this.btnBilancioCosto_Click);
			// 
			// grpSiopeEntrataInterno
			// 
			this.grpSiopeEntrataInterno.Controls.Add(this.btnSiopeEntrataInt);
			this.grpSiopeEntrataInterno.Controls.Add(this.txtDescrSiopeEntrata);
			this.grpSiopeEntrataInterno.Controls.Add(this.txtSiopeEntrataInt);
			this.grpSiopeEntrataInterno.Location = new System.Drawing.Point(6, 255);
			this.grpSiopeEntrataInterno.Name = "grpSiopeEntrataInterno";
			this.grpSiopeEntrataInterno.Size = new System.Drawing.Size(431, 121);
			this.grpSiopeEntrataInterno.TabIndex = 4;
			this.grpSiopeEntrataInterno.TabStop = false;
			this.grpSiopeEntrataInterno.Tag = "AutoManage.txtSiopeEntrataInt.treeclassmovimenti";
			this.grpSiopeEntrataInterno.Text = "SIOPE Entrata interno";
			// 
			// btnSiopeEntrataInt
			// 
			this.btnSiopeEntrataInt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSiopeEntrataInt.Location = new System.Drawing.Point(5, 64);
			this.btnSiopeEntrataInt.Name = "btnSiopeEntrataInt";
			this.btnSiopeEntrataInt.Size = new System.Drawing.Size(88, 23);
			this.btnSiopeEntrataInt.TabIndex = 4;
			this.btnSiopeEntrataInt.TabStop = false;
			this.btnSiopeEntrataInt.Tag = "manage.sorting_incomeclawback.tree";
			this.btnSiopeEntrataInt.Text = "Codice";
			this.btnSiopeEntrataInt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDescrSiopeEntrata
			// 
			this.txtDescrSiopeEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrSiopeEntrata.Location = new System.Drawing.Point(109, 19);
			this.txtDescrSiopeEntrata.Multiline = true;
			this.txtDescrSiopeEntrata.Name = "txtDescrSiopeEntrata";
			this.txtDescrSiopeEntrata.ReadOnly = true;
			this.txtDescrSiopeEntrata.Size = new System.Drawing.Size(313, 68);
			this.txtDescrSiopeEntrata.TabIndex = 3;
			this.txtDescrSiopeEntrata.TabStop = false;
			this.txtDescrSiopeEntrata.Tag = "sorting_incomeclawback.description";
			// 
			// txtSiopeEntrataInt
			// 
			this.txtSiopeEntrataInt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSiopeEntrataInt.Location = new System.Drawing.Point(5, 93);
			this.txtSiopeEntrataInt.Name = "txtSiopeEntrataInt";
			this.txtSiopeEntrataInt.Size = new System.Drawing.Size(419, 20);
			this.txtSiopeEntrataInt.TabIndex = 5;
			this.txtSiopeEntrataInt.Tag = "sorting_incomeclawback.sortcode?csa_importverview.sortcode_incomeclawback";
			// 
			// gBoxContoRicavo
			// 
			this.gBoxContoRicavo.Controls.Add(this.txtDenominazioneContoRicavo);
			this.gBoxContoRicavo.Controls.Add(this.txtCodiceContoRicavo);
			this.gBoxContoRicavo.Controls.Add(this.button4);
			this.gBoxContoRicavo.Location = new System.Drawing.Point(6, 15);
			this.gBoxContoRicavo.Name = "gBoxContoRicavo";
			this.gBoxContoRicavo.Size = new System.Drawing.Size(431, 112);
			this.gBoxContoRicavo.TabIndex = 3;
			this.gBoxContoRicavo.TabStop = false;
			this.gBoxContoRicavo.Tag = "AutoManage.txtCodiceContoRicavo.tree";
			this.gBoxContoRicavo.Text = "Conto EP di  Ricavo (Recupero positivo o Contributo negativo)";
			// 
			// txtDenominazioneContoRicavo
			// 
			this.txtDenominazioneContoRicavo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneContoRicavo.Location = new System.Drawing.Point(109, 16);
			this.txtDenominazioneContoRicavo.Multiline = true;
			this.txtDenominazioneContoRicavo.Name = "txtDenominazioneContoRicavo";
			this.txtDenominazioneContoRicavo.ReadOnly = true;
			this.txtDenominazioneContoRicavo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneContoRicavo.Size = new System.Drawing.Size(309, 66);
			this.txtDenominazioneContoRicavo.TabIndex = 0;
			this.txtDenominazioneContoRicavo.TabStop = false;
			this.txtDenominazioneContoRicavo.Tag = "account_revenue.title";
			// 
			// txtCodiceContoRicavo
			// 
			this.txtCodiceContoRicavo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceContoRicavo.Location = new System.Drawing.Point(6, 88);
			this.txtCodiceContoRicavo.Name = "txtCodiceContoRicavo";
			this.txtCodiceContoRicavo.Size = new System.Drawing.Size(412, 20);
			this.txtCodiceContoRicavo.TabIndex = 2;
			this.txtCodiceContoRicavo.Tag = "account_revenue.codeacc?x";
			// 
			// button4
			// 
			this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button4.Location = new System.Drawing.Point(6, 59);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(89, 23);
			this.button4.TabIndex = 1;
			this.button4.TabStop = false;
			this.button4.Tag = "manage.account_revenue.tree";
			this.button4.Text = "Conto";
			// 
			// grpEntrataInterno
			// 
			this.grpEntrataInterno.Controls.Add(this.textBox16);
			this.grpEntrataInterno.Controls.Add(this.txtBilancioEntrataInterno);
			this.grpEntrataInterno.Controls.Add(this.btnEntrataInterno);
			this.grpEntrataInterno.Location = new System.Drawing.Point(6, 133);
			this.grpEntrataInterno.Name = "grpEntrataInterno";
			this.grpEntrataInterno.Size = new System.Drawing.Size(431, 116);
			this.grpEntrataInterno.TabIndex = 3;
			this.grpEntrataInterno.TabStop = false;
			this.grpEntrataInterno.Tag = "AutoManage.txtBilancioEntrataInterno.treee";
			this.grpEntrataInterno.Text = "Capitolo di Entrata per i recuperi e contributi negativi";
			// 
			// textBox16
			// 
			this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox16.Location = new System.Drawing.Point(109, 19);
			this.textBox16.Multiline = true;
			this.textBox16.Name = "textBox16";
			this.textBox16.ReadOnly = true;
			this.textBox16.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox16.Size = new System.Drawing.Size(315, 69);
			this.textBox16.TabIndex = 0;
			this.textBox16.TabStop = false;
			this.textBox16.Tag = "fin_incomeclawback.title";
			// 
			// txtBilancioEntrataInterno
			// 
			this.txtBilancioEntrataInterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBilancioEntrataInterno.Location = new System.Drawing.Point(6, 90);
			this.txtBilancioEntrataInterno.Name = "txtBilancioEntrataInterno";
			this.txtBilancioEntrataInterno.Size = new System.Drawing.Size(419, 20);
			this.txtBilancioEntrataInterno.TabIndex = 2;
			this.txtBilancioEntrataInterno.Tag = "fin_incomeclawback.codefin?csa_importverview.codefin_incomeclawback";
			// 
			// btnEntrataInterno
			// 
			this.btnEntrataInterno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEntrataInterno.ImageIndex = 0;
			this.btnEntrataInterno.Location = new System.Drawing.Point(5, 64);
			this.btnEntrataInterno.Name = "btnEntrataInterno";
			this.btnEntrataInterno.Size = new System.Drawing.Size(90, 24);
			this.btnEntrataInterno.TabIndex = 1;
			this.btnEntrataInterno.TabStop = false;
			this.btnEntrataInterno.Tag = "manage.fin_incomeclawback.treee";
			this.btnEntrataInterno.Text = "Bilancio";
			// 
			// tabVecchiaCfg
			// 
			this.tabVecchiaCfg.Controls.Add(this.groupBox13);
			this.tabVecchiaCfg.Controls.Add(this.tabControl2);
			this.tabVecchiaCfg.Location = new System.Drawing.Point(4, 22);
			this.tabVecchiaCfg.Name = "tabVecchiaCfg";
			this.tabVecchiaCfg.Padding = new System.Windows.Forms.Padding(3);
			this.tabVecchiaCfg.Size = new System.Drawing.Size(883, 382);
			this.tabVecchiaCfg.TabIndex = 9;
			this.tabVecchiaCfg.Text = "Vecchia Configurazione";
			this.tabVecchiaCfg.UseVisualStyleBackColor = true;
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.txtUnderwriting);
			this.groupBox13.Controls.Add(this.btnUnderwriting);
			this.groupBox13.Location = new System.Drawing.Point(7, 6);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(301, 61);
			this.groupBox13.TabIndex = 8;
			this.groupBox13.TabStop = false;
			this.groupBox13.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
			// 
			// txtUnderwriting
			// 
			this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnderwriting.Location = new System.Drawing.Point(9, 31);
			this.txtUnderwriting.Name = "txtUnderwriting";
			this.txtUnderwriting.Size = new System.Drawing.Size(284, 20);
			this.txtUnderwriting.TabIndex = 2;
			this.txtUnderwriting.Tag = "underwriting.title?csa_importverview.underwriting";
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
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage8);
			this.tabControl2.Controls.Add(this.tabPage9);
			this.tabControl2.Controls.Add(this.tabPage10);
			this.tabControl2.Controls.Add(this.tabPage11);
			this.tabControl2.Location = new System.Drawing.Point(5, 73);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(872, 303);
			this.tabControl2.TabIndex = 0;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.gboxImponibile);
			this.tabPage8.Controls.Add(this.groupBox9);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new System.Drawing.Size(864, 277);
			this.tabPage8.TabIndex = 0;
			this.tabPage8.Text = "EP";
			this.tabPage8.UseVisualStyleBackColor = true;
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
			this.gboxImponibile.Location = new System.Drawing.Point(9, 22);
			this.gboxImponibile.Name = "gboxImponibile";
			this.gboxImponibile.Size = new System.Drawing.Size(498, 92);
			this.gboxImponibile.TabIndex = 46;
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
			this.label34.Location = new System.Drawing.Point(133, 58);
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
			this.btnLinkEpExp.Location = new System.Drawing.Point(357, 16);
			this.btnLinkEpExp.Name = "btnLinkEpExp";
			this.btnLinkEpExp.Size = new System.Drawing.Size(135, 23);
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
			this.txtNumImpegno.Location = new System.Drawing.Point(183, 52);
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
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.dataGrid2);
			this.groupBox9.Location = new System.Drawing.Point(9, 120);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(849, 151);
			this.groupBox9.TabIndex = 47;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Ripartizione";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(10, 19);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(830, 126);
			this.dataGrid2.TabIndex = 20;
			this.dataGrid2.Tag = "csa_contracttaxepexp.default";
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.groupBox15);
			this.tabPage9.Controls.Add(this.groupBox14);
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(864, 277);
			this.tabPage9.TabIndex = 1;
			this.tabPage9.Text = "Ripartizioni";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// groupBox15
			// 
			this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox15.Controls.Add(this.button2);
			this.groupBox15.Controls.Add(this.button3);
			this.groupBox15.Controls.Add(this.button5);
			this.groupBox15.Controls.Add(this.dataGrid3);
			this.groupBox15.Location = new System.Drawing.Point(6, 132);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(852, 126);
			this.groupBox15.TabIndex = 53;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Impegni di Budget";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(5, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(68, 22);
			this.button2.TabIndex = 26;
			this.button2.Tag = "insert.detail";
			this.button2.Text = "Inserisci";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(5, 51);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(68, 22);
			this.button3.TabIndex = 27;
			this.button3.Tag = "edit.detail";
			this.button3.Text = "Modifica";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(5, 83);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(68, 22);
			this.button5.TabIndex = 28;
			this.button5.Tag = "delete";
			this.button5.Text = "Elimina";
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(79, 19);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(764, 101);
			this.dataGrid3.TabIndex = 20;
			this.dataGrid3.Tag = "csa_importver_epexp.detail.detail";
			// 
			// groupBox14
			// 
			this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox14.Controls.Add(this.btnInserisci);
			this.groupBox14.Controls.Add(this.btnModifica);
			this.groupBox14.Controls.Add(this.btnElimina);
			this.groupBox14.Controls.Add(this.dataGrid1);
			this.groupBox14.Location = new System.Drawing.Point(7, 6);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(851, 122);
			this.groupBox14.TabIndex = 52;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Finanziaria";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(5, 19);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnInserisci.TabIndex = 26;
			this.btnInserisci.Tag = "insert.detail";
			this.btnInserisci.Text = "Inserisci";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(5, 51);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(68, 22);
			this.btnModifica.TabIndex = 27;
			this.btnModifica.Tag = "edit.detail";
			this.btnModifica.Text = "Modifica";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(5, 83);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(68, 22);
			this.btnElimina.TabIndex = 28;
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
			this.dataGrid1.Location = new System.Drawing.Point(79, 19);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(763, 97);
			this.dataGrid1.TabIndex = 20;
			this.dataGrid1.Tag = "csa_importver_expense.default.detail";
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.gboxUPB);
			this.tabPage10.Controls.Add(this.grpContoDebito);
			this.tabPage10.Controls.Add(this.gboxSpesa);
			this.tabPage10.Controls.Add(this.chkSpesa);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(864, 277);
			this.tabPage10.TabIndex = 2;
			this.tabPage10.Text = "Contributi";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(6, 6);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(329, 110);
			this.gboxUPB.TabIndex = 1;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(3, 83);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(317, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(141, 8);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(180, 69);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(6, 57);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// grpContoDebito
			// 
			this.grpContoDebito.Controls.Add(this.textBox14);
			this.grpContoDebito.Controls.Add(this.txtContoDebito);
			this.grpContoDebito.Controls.Add(this.btnContoDebito);
			this.grpContoDebito.Location = new System.Drawing.Point(12, 140);
			this.grpContoDebito.Name = "grpContoDebito";
			this.grpContoDebito.Size = new System.Drawing.Size(345, 101);
			this.grpContoDebito.TabIndex = 7;
			this.grpContoDebito.TabStop = false;
			this.grpContoDebito.Tag = "AutoManage.txtContoDebito.tree";
			this.grpContoDebito.Text = "Conto EP di Debito conto Ente (contr. su p. di giro, opzionale)";
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.Location = new System.Drawing.Point(141, 16);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.ReadOnly = true;
			this.textBox14.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox14.Size = new System.Drawing.Size(197, 52);
			this.textBox14.TabIndex = 0;
			this.textBox14.TabStop = false;
			this.textBox14.Tag = "account_debit.title";
			// 
			// txtContoDebito
			// 
			this.txtContoDebito.Location = new System.Drawing.Point(6, 75);
			this.txtContoDebito.Name = "txtContoDebito";
			this.txtContoDebito.Size = new System.Drawing.Size(331, 20);
			this.txtContoDebito.TabIndex = 2;
			this.txtContoDebito.Tag = "account_debit.codeacc?csa_importverview.codeacc_debit";
			// 
			// btnContoDebito
			// 
			this.btnContoDebito.Location = new System.Drawing.Point(6, 46);
			this.btnContoDebito.Name = "btnContoDebito";
			this.btnContoDebito.Size = new System.Drawing.Size(127, 23);
			this.btnContoDebito.TabIndex = 1;
			this.btnContoDebito.TabStop = false;
			this.btnContoDebito.Tag = "manage.account_debit.tree";
			this.btnContoDebito.Text = "Conto";
			// 
			// gboxSpesa
			// 
			this.gboxSpesa.Controls.Add(this.label7);
			this.gboxSpesa.Controls.Add(this.txtNum);
			this.gboxSpesa.Controls.Add(this.label13);
			this.gboxSpesa.Controls.Add(this.txtEserc);
			this.gboxSpesa.Controls.Add(this.label12);
			this.gboxSpesa.Controls.Add(this.cmbFaseSpesa);
			this.gboxSpesa.Controls.Add(this.btnSpesa);
			this.gboxSpesa.Location = new System.Drawing.Point(480, 20);
			this.gboxSpesa.Name = "gboxSpesa";
			this.gboxSpesa.Size = new System.Drawing.Size(346, 80);
			this.gboxSpesa.TabIndex = 3;
			this.gboxSpesa.TabStop = false;
			this.gboxSpesa.Text = "Movimento di Spesa a cui collegare i Contributi";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(69, 19);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Fase:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNum
			// 
			this.txtNum.Location = new System.Drawing.Point(273, 44);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(66, 20);
			this.txtNum.TabIndex = 3;
			this.txtNum.Tag = "";
			this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(231, 47);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(42, 16);
			this.label13.TabIndex = 0;
			this.label13.Text = "Num.:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(173, 46);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 2;
			this.txtEserc.Tag = "";
			this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(129, 47);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 16);
			this.label12.TabIndex = 0;
			this.label12.Text = "Eserc.:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbFaseSpesa
			// 
			this.cmbFaseSpesa.DataSource = this.DS.expensephase;
			this.cmbFaseSpesa.DisplayMember = "description";
			this.cmbFaseSpesa.Location = new System.Drawing.Point(114, 17);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(226, 21);
			this.cmbFaseSpesa.TabIndex = 1;
			this.cmbFaseSpesa.Tag = "";
			this.cmbFaseSpesa.ValueMember = "nphase";
			this.cmbFaseSpesa.SelectedIndexChanged += new System.EventHandler(this.cmbFaseSpesa_SelectedIndexChanged);
			// 
			// btnSpesa
			// 
			this.btnSpesa.Location = new System.Drawing.Point(9, 47);
			this.btnSpesa.Name = "btnSpesa";
			this.btnSpesa.Size = new System.Drawing.Size(116, 23);
			this.btnSpesa.TabIndex = 1;
			this.btnSpesa.TabStop = false;
			this.btnSpesa.Text = "Scegli Movimento";
			this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click_1);
			// 
			// chkSpesa
			// 
			this.chkSpesa.Location = new System.Drawing.Point(341, 30);
			this.chkSpesa.Name = "chkSpesa";
			this.chkSpesa.Size = new System.Drawing.Size(133, 70);
			this.chkSpesa.TabIndex = 2;
			this.chkSpesa.Text = "Seleziona  movimento di spesa per i Contributi";
			this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
			// 
			// tabPage11
			// 
			this.tabPage11.Controls.Add(this.grpModalitaRecuperi);
			this.tabPage11.Controls.Add(this.grpContoEntrataInterno);
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new System.Drawing.Size(864, 277);
			this.tabPage11.TabIndex = 3;
			this.tabPage11.Text = "Versamenti in entrata";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// grpModalitaRecuperi
			// 
			this.grpModalitaRecuperi.Controls.Add(this.radioButton2);
			this.grpModalitaRecuperi.Controls.Add(this.radioButton1);
			this.grpModalitaRecuperi.Location = new System.Drawing.Point(9, 16);
			this.grpModalitaRecuperi.Name = "grpModalitaRecuperi";
			this.grpModalitaRecuperi.Size = new System.Drawing.Size(501, 43);
			this.grpModalitaRecuperi.TabIndex = 2;
			this.grpModalitaRecuperi.TabStop = false;
			this.grpModalitaRecuperi.Text = "Modalità di applicazione (Per Recuperi)";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(365, 21);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(129, 16);
			this.radioButton2.TabIndex = 13;
			this.radioButton2.Tag = "csa_importver.flagdirectcsaclawback:N";
			this.radioButton2.Text = "Su Partite di giro";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(230, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 16);
			this.radioButton1.TabIndex = 12;
			this.radioButton1.Tag = "csa_importver.flagdirectcsaclawback:S";
			this.radioButton1.Text = "Diretta";
			// 
			// grpContoEntrataInterno
			// 
			this.grpContoEntrataInterno.Controls.Add(this.textBox18);
			this.grpContoEntrataInterno.Controls.Add(this.txtCodiceContoInterno);
			this.grpContoEntrataInterno.Controls.Add(this.btnContoEntrataInterno);
			this.grpContoEntrataInterno.Location = new System.Drawing.Point(9, 81);
			this.grpContoEntrataInterno.Name = "grpContoEntrataInterno";
			this.grpContoEntrataInterno.Size = new System.Drawing.Size(424, 105);
			this.grpContoEntrataInterno.TabIndex = 5;
			this.grpContoEntrataInterno.TabStop = false;
			this.grpContoEntrataInterno.Tag = "AutoManage.txtCodiceContoInterno.tree";
			this.grpContoEntrataInterno.Text = "Conto EP di Credito interno per recuperi su p.di giro";
			// 
			// textBox18
			// 
			this.textBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox18.Location = new System.Drawing.Point(129, 16);
			this.textBox18.Multiline = true;
			this.textBox18.Name = "textBox18";
			this.textBox18.ReadOnly = true;
			this.textBox18.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox18.Size = new System.Drawing.Size(289, 52);
			this.textBox18.TabIndex = 0;
			this.textBox18.TabStop = false;
			this.textBox18.Tag = "account_internalcredit.title";
			// 
			// txtCodiceContoInterno
			// 
			this.txtCodiceContoInterno.Location = new System.Drawing.Point(8, 79);
			this.txtCodiceContoInterno.Name = "txtCodiceContoInterno";
			this.txtCodiceContoInterno.Size = new System.Drawing.Size(410, 20);
			this.txtCodiceContoInterno.TabIndex = 2;
			this.txtCodiceContoInterno.Tag = "account_internalcredit.codeacc?csa_importverview.codeacc_internalcredit";
			// 
			// btnContoEntrataInterno
			// 
			this.btnContoEntrataInterno.Location = new System.Drawing.Point(8, 50);
			this.btnContoEntrataInterno.Name = "btnContoEntrataInterno";
			this.btnContoEntrataInterno.Size = new System.Drawing.Size(98, 23);
			this.btnContoEntrataInterno.TabIndex = 1;
			this.btnContoEntrataInterno.TabStop = false;
			this.btnContoEntrataInterno.Tag = "manage.account_internalcredit.tree";
			this.btnContoEntrataInterno.Text = "Conto";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.txtCredDebEnte);
			this.groupBox11.Location = new System.Drawing.Point(313, 263);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(387, 41);
			this.groupBox11.TabIndex = 7;
			this.groupBox11.TabStop = false;
			this.groupBox11.Tag = "AutoChoose.txtCredDebEnte.lista.(active=\'S\')";
			this.groupBox11.Text = "Anagrafica associata all\'Ente ";
			// 
			// txtCredDebEnte
			// 
			this.txtCredDebEnte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDebEnte.Location = new System.Drawing.Point(8, 17);
			this.txtCredDebEnte.Name = "txtCredDebEnte";
			this.txtCredDebEnte.Size = new System.Drawing.Size(373, 20);
			this.txtCredDebEnte.TabIndex = 1;
			this.txtCredDebEnte.Tag = "registry_agency.title?csa_importverview?registry_agency";
			// 
			// chkRecupero
			// 
			this.chkRecupero.Location = new System.Drawing.Point(714, 281);
			this.chkRecupero.Name = "chkRecupero";
			this.chkRecupero.Size = new System.Drawing.Size(156, 18);
			this.chkRecupero.TabIndex = 1;
			this.chkRecupero.Tag = "csa_importver.flagclawback:S:N";
			this.chkRecupero.Text = "Recupero (Ente interno)";
			// 
			// Frm_csa_importver_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(915, 760);
			this.Controls.Add(this.txtDescModalita);
			this.Controls.Add(this.chkRecupero);
			this.Controls.Add(this.groupBox11);
			this.Controls.Add(this.btnModalita);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox7);
			this.Controls.Add(this.grpMatricola);
			this.Controls.Add(this.groupCredDeb);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox8);
			this.Controls.Add(this.gboxtipo);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox4);
			this.Name = "Frm_csa_importver_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.gboxtipo.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.grpMatricola.ResumeLayout(false);
			this.grpMatricola.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPartizioneUnica.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.tabRitenute.ResumeLayout(false);
			this.grpSiopeSpesa.ResumeLayout(false);
			this.grpSiopeSpesa.PerformLayout();
			this.grpSiopeEntrata.ResumeLayout(false);
			this.grpSiopeEntrata.PerformLayout();
			this.grpBilancioSpesa.ResumeLayout(false);
			this.grpBilancioSpesa.PerformLayout();
			this.grpBilancioEntrata.ResumeLayout(false);
			this.grpBilancioEntrata.PerformLayout();
			this.tabPageEP.ResumeLayout(false);
			this.grpContoSpesa.ResumeLayout(false);
			this.grpContoSpesa.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.tabPageMovFin.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid5)).EndInit();
			this.groupBox18.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid6)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.grpSiopeCosto.ResumeLayout(false);
			this.grpSiopeCosto.PerformLayout();
			this.gboxContoCosto.ResumeLayout(false);
			this.gboxContoCosto.PerformLayout();
			this.grpBilancioCosto.ResumeLayout(false);
			this.grpBilancioCosto.PerformLayout();
			this.grpSiopeEntrataInterno.ResumeLayout(false);
			this.grpSiopeEntrataInterno.PerformLayout();
			this.gBoxContoRicavo.ResumeLayout(false);
			this.gBoxContoRicavo.PerformLayout();
			this.grpEntrataInterno.ResumeLayout(false);
			this.grpEntrataInterno.PerformLayout();
			this.tabVecchiaCfg.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.gboxImponibile.ResumeLayout(false);
			this.gboxImponibile.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabPage9.ResumeLayout(false);
			this.groupBox15.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.groupBox14.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage10.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.grpContoDebito.ResumeLayout(false);
			this.grpContoDebito.PerformLayout();
			this.gboxSpesa.ResumeLayout(false);
			this.gboxSpesa.PerformLayout();
			this.tabPage11.ResumeLayout(false);
			this.grpModalitaRecuperi.ResumeLayout(false);
			this.grpContoEntrataInterno.ResumeLayout(false);
			this.grpContoEntrataInterno.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            chkSpesa_CheckedChanged(sender, e, true);
        }

	    private bool inside = false;

        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e, bool DispMessage) {
            if (!Meta.DrawStateIsDone) return;
            if (inside) return;
            inside = true;
            if (chkSpesa.Checked) {
                EnableDisable(false);
                if (Meta.IsEmpty) {
                    inside = false;
                    return;
                }
                DataRow R = DS.csa_importver.Rows[0];
                if ((R["idfin_cost"] != DBNull.Value) ||
                    (R["idupb"] != DBNull.Value)) {

                    if (DispMessage) {
                        if (MessageBox.Show("Per abilitare la selezione del movimento di spesa è necessario annullare le altre " +
                            "attribuzioni dei contributi su questo contratto. Proseguo?", "Conferma",
                            MessageBoxButtons.OKCancel) != DialogResult.OK) {
                            chkSpesa.Checked = false;
                            inside = false;
                            return;
                        }
                    }
                    R["idfin_cost"] = DBNull.Value;
                    R["idupb"] = DBNull.Value;
                    DS.fin_cost.Clear();
                    txtBilancioCosto.Text = "";
                    txtDescrBilancio.Text = "";
                    Meta.SetAutoField(DBNull.Value, txtUPB);
                    txtDescrUPB.Text = "";
                    inside = false;
                    return;
                }
                inside = false;
                return;
            }
            if (Meta.IsEmpty) {
                inside = false;
                return;
            }
            EnableDisable(true);

            DataRow RR = DS.csa_importver.Rows[0];

            if (RR["idexp_cost"] != DBNull.Value) {
                  if (DispMessage) {
                      if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questo contratto è necessario annullare il collegamento al movimento di spesa " +
                          ". Proseguo?", "Conferma",
                          MessageBoxButtons.OKCancel) != DialogResult.OK) {
                          chkSpesa.Checked = true;
                        inside = false;
                        return;
                      }
                }
                RR["idexp_cost"] = DBNull.Value;
                DS.expenseview.Clear();
                cmbFaseSpesa.SelectedIndex = 0;
                txtEserc.Text = "";
                txtNum.Text = "";
            }
            inside = false;
        }

        void EnableDisableParteSpesa(bool enable){
            txtEserc.ReadOnly = !enable;
            txtNum.ReadOnly = !enable;
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseSpesa.Enabled = enable;
            btnSpesa.Enabled = enable;
		}
		void EnableDisableParteNormale(bool enable){
			btnBilancioCosto.Enabled = enable;
			btnUPBCode.Enabled = enable;
            txtUPB.ReadOnly = !enable;
			txtBilancioCosto.ReadOnly = !enable;			
		}

		void EnableDisable(bool parteNormale){
			EnableDisableParteNormale(parteNormale);
			EnableDisableParteSpesa(!parteNormale);
		}

        void EnableDisableControlliInput (bool enable) {
           // txtImporto.ReadOnly = !enable;
            txtCompetenza.ReadOnly = !enable;
            txtMatricola.ReadOnly = !enable;
            txtCapitoloCsa.ReadOnly = !enable;
            txtEnteCsa.ReadOnly = !enable;
            txtRuoloCsa.ReadOnly = !enable;
            txtVoceCsa.ReadOnly = !enable;
		}

        private void btnSpesa_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.csa_importver.Rows[0];
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
                string filterUpb = QHC.CmpEq("idupb", "0001");
                string filterFin = "";
                // Aggiunta filtro dell'UPB e del Bilancio
                if (f.GetUPB()!=DBNull.Value) {
                    
                    filterUpb = QHS.CmpEq("idupb", f.GetUPB());
                    
                    if (f.GetFin() != DBNull.Value) {
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
            int oldIdExp = CfgFn.GetNoNullInt32(Curr["idexp_cost"]);
            int newIdExp = CfgFn.GetNoNullInt32(Choosen["idexp"]);
            Curr["idexp_cost"] = Choosen["idexp"];

            DS.expenseview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp_cost"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
            

            Meta.FreshForm(false);
        }
        bool vecchiaGestione() {
            if (Meta.IsEmpty) return false;
            if (DS.csa_importver.Rows.Count > 0) {
                DataRow Curr = DS.csa_importver.Rows[0];
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
        public void MetaData_AfterFill () {
            epm.mostraEtichette();
            if (Meta.FirstFillForThisRow) ImpostaCheckSpesa();

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
            
            if (!Meta.InsertMode)    VisualizzaMovimentoSpesa();
            txtEsercImport.Text = Conn.GetEsercizio().ToString();
            EnableDisableControlliInput(Meta.IsEmpty);             
            if (DS.epexp.Rows.Count > 0)
            {
                object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
                HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
            }
		}

        public void MetaData_AfterClear () {
            epm.mostraEtichette();
            ImpostaCheckSpesa();
            txtEserc.Text = "";
            txtNum.Text = "";
            cmbFaseSpesa.SelectedIndex = 0;
            cmbFaseImpBudget.SelectedIndex = -1;
            EnableDisableControlliInput(true);
            txtEsercImport.Text = Conn.GetEsercizio().ToString();
		}

        void ImpostaCheckSpesa () {
            if (Meta.IsEmpty) {
                EnableDisable(true);
                return;
            }
            DataRow R = DS.csa_importver.Rows[0];
            if (R["idexp_cost"] != DBNull.Value)
                chkSpesa.Checked = true;
            else
                chkSpesa.Checked = false;
            chkSpesa_CheckedChanged(null, null,false);         
        }


        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_importver"].Rows[0]["idexp_cost"];
            string filter = QHS.CmpEq("idexp", idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
        }


        private void txtNum_Leave (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importver.Rows[0];
            if ((Curr["idexp_cost"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp_cost"] = DBNull.Value;
            }
            btnSpesa_Click(sender, e);
        }

        private void txtEserc_Leave (object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importver.Rows[0];
            if (Curr["idexp_cost"] != DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp_cost"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNum.Text = "";
                            DS.expenseview.Clear();
                            Curr["idexp_cost"] = DBNull.Value;
                        }
                    }
                    else {
                        txtNum.Text = "";
                        Curr["idexp_cost"] = DBNull.Value;
                    }
                }
            }
        }

        private void cmbFaseSpesa_SelectedIndexChanged (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.csa_importver.Rows[0];
            if (Curr["idexp_cost"] != DBNull.Value) {
                if (DS.expenseview.Rows.Count > 0) {
                    int oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                    int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                    if (oldNphase != newNPhase) {
                        txtNum.Text = "";
                        txtEserc.Text = "";
                        DS.expenseview.Clear();
                        Curr["idexp_cost"] = DBNull.Value;
                    }
                }
                else {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp_cost"] = DBNull.Value;
                }
            }
        }

        public void MetaData_AfterRowSelect (DataTable T, DataRow R) {
            if (T.TableName=="csa_import")
            if (T.TableName == "csa_agency") {
                if (!Meta.DrawStateIsDone) return;
                DS.csa_agencypaymethod.Clear();
                txtDescModalita.Text = "";
                if (!Meta.IsEmpty) {
                    DataRow Curr = DS.csa_importver.Rows[0];
                    if (R != null) {
                        Curr["flagclawback"] = R["isinternal"]; //ente interno: recupero
                        chkRecupero.Checked = (R["isinternal"].ToString() == "S");
                    }
                    else {
                        Curr["flagclawback"] = "N"; //ritenuta
                        chkRecupero.Checked = false;
                    }
                }
                return;
            } 
        }
       
        private void btnModalita_Click (object sender, EventArgs e) {
            object idcsa_agency = cmbEnte.SelectedValue;
            if (idcsa_agency == DBNull.Value) return;
            MetaData E = Meta.Dispatcher.Get("csa_agencypaymethod");
            E.FilterLocked = true;
            E.DS = DS.Clone();
            string filterSQL = QHS.CmpEq("idcsa_agency", idcsa_agency);
            DataRow Choosen = E.SelectOne("default", filterSQL, "csa_agencypaymethod", null);
            if (Choosen == null) return;
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.csa_agencypaymethod, null,
               QHS.AppAnd(QHS.CmpEq("idcsa_agencypaymethod", Choosen["idcsa_agencypaymethod"]), 
               QHS.CmpEq("idcsa_agency", Choosen["idcsa_agency"])),
               null, true);
            txtDescModalita.Text = Choosen["vocecsa"].ToString();
        }

        private void btnBilancioCosto_Click(object sender, EventArgs e)
        {

        }

        private void btnBilancioSpesa_Click(object sender, EventArgs e) {

        }

        private void grpSiopeCosto_Enter(object sender, EventArgs e) {

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
            DataRow curr = DS.csa_importver.Rows[0];
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

        private void btnSpesa_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_importver.Rows[0];
            if ((Meta.EditMode) && (!vecchiaGestione())) {
                txtEsercImport.Text = Conn.GetEsercizio().ToString();
                var idrel = BudgetFunction.GetIdForDocument(Curr);
                DataTable mov_budg = Conn.RUN_SELECT("epexp", "idepexp", null, QHS.CmpEq("idrelated", idrel), null, true);
                if ((mov_budg.Rows.Count > 0) && (Curr["idepexp"]!=DBNull.Value)) {
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

        public void MetaData_BeforePost()
        {
            epm.beforePost();
        }

        public void MetaData_AfterPost()
        {
            epm.afterPost();
        }

	}
}
