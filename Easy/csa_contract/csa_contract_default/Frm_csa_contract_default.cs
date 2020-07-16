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
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using AskInfo;
using metadatalibrary;
using funzioni_configurazione;
using ep_functions;

namespace csa_contract_default
{
	/// <summary>
	/// </summary>
    public class Frm_csa_contract_default : System.Windows.Forms.Form {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGrid dgrContributi;
        private Button btnPagElimina;
        private Button btnPagModifica;
        private Button btnPagInserisci;
        private TabPage tabPage2;
        private DataGrid dgrAnagrafiche;
        private Button button1;
        private Button button2;
        private Button button3;
        private TabPage tabPageRipUnica;
		private System.ComponentModel.IContainer components;
        MetaData Meta;
        private CheckBox chkKeepAlive;
        private Label label2;
        private TextBox textBox2;
        private TextBox txtNumContratto;
        private Label label3;
        private TextBox txtEsercContratto;
        private Label label5;
        private TextBox textBox1;
        private Label label1;
        private CheckBox chkFlagRecreate;
        private CheckBox ckbAttivo;
        private TabPage tabPage4;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button5;
        private GroupBox gboxImponibile;
        private Label label34;
        private Label label33;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumImpegno;
        private TextBox txtEsercizioImpegno;
        private Label label6;
        private ComboBox cmbFaseImpBudget;
        private TabControl tabControlVecchiaCfg;
        private TabPage tabPagePrincipale;
        private TabPage tabPageRipartizioni;
        private TabPage tabPageEP;
        private GroupBox groupBox5;
        private Button button4;
        private Button button6;
        private Button button7;
        private DataGrid dataGrid2;
        private GroupBox groupBox4;
        private Button btnInserisci;
        private Button btnModifica;
        private Button btnElimina;
        private DataGrid dataGrid1;
        private GroupBox groupBox2;
        public GroupBox gboxclassSiope;
        public Button btnCodiceSiope;
        private TextBox txtDenomSiope;
        private TextBox txtCodiceSiope;
        private GroupBox gboxSpesa;
        private Label label7;
        private TextBox txtNum;
        private Label label13;
        private TextBox txtEserc;
        private Label label12;
        private ComboBox cmbFaseSpesa;
        private Button btnSpesa;
        private GroupBox grpBilancioVersamento;
        private TextBox txtDescrBilancio;
        private TextBox txtBilancio;
        private Button btnBilancio;
        private CheckBox chkSpesa;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private GroupBox groupBox3;
        private TextBox txtUnderwriting;
        private Button btnUnderwriting;
        private GroupBox groupBox6;
        private Button button8;
        private Button button9;
        private Button button10;
        private DataGrid dataGrid3;
        private GroupBox groupBox1;
        private TextBox txtNumeroregGenerale;
        private Label label4;
        private Label label8;
        private TextBox txtCodiceRegGenerale;
        private TextBox txtRegolaGenerale;
        private Button button11;
        private RadioButton rdbCompetenza;
        private RadioButton rdbResidui;
        DataAccess Conn;
		public Frm_csa_contract_default()
		{
			InitializeComponent();
			HelpForm.SetDenyNull(DS.csa_contractkind.Columns["flagcr"], true);
            HelpForm.SetDenyNull(DS.csa_contract.Columns["active"], true);

            DS.csa_contracttax.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.sorting1.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.fin1.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.account1.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.upb1.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.expenseview3.ExtendedProperties["ViewTable"] = DS.csa_contracttaxview;
            DS.csa_contracttaxview.ExtendedProperties["RealTable"] = DS.csa_contracttax;

            foreach (DataColumn C in DS.csa_contracttax.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.csa_contracttaxview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "csa_contracttax." + C.ColumnName;
            }

            DS.csa_contracttaxview.Columns["sortcode_siope"].ExtendedProperties["ViewSource"] = "sorting1.sortcode";
            DS.csa_contracttaxview.Columns["codefin"].ExtendedProperties["ViewSource"] = "fin1.codefin";
            DS.csa_contracttaxview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb1.codeupb";
            DS.csa_contracttaxview.Columns["codeacc"].ExtendedProperties["ViewSource"] = "account1.codeacc";
            DS.csa_contracttaxview.Columns["ymov"].ExtendedProperties["ViewSource"] = "expenseview3.ymov";
            DS.csa_contracttaxview.Columns["nmov"].ExtendedProperties["ViewSource"] = "expenseview3.nmov";
            DS.csa_contracttaxview.Columns["nphase"].ExtendedProperties["ViewSource"] = "expenseview3.nphase";



            DS.csa_contracttaxexpense.ExtendedProperties["ViewTable"] = DS.csa_contracttaxexpenseview;
            DS.expenseview2.ExtendedProperties["ViewTable"] = DS.csa_contracttaxexpenseview;
            DS.csa_contracttaxexpenseview.ExtendedProperties["RealTable"] = DS.csa_contracttaxexpense;

            foreach (DataColumn C in DS.csa_contracttaxexpense.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.csa_contracttaxexpenseview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "csa_contracttaxexpense." + C.ColumnName;
            }
            DS.csa_contracttaxexpenseview.Columns["ymov"].ExtendedProperties["ViewSource"] = "expenseview2.ymov";
            DS.csa_contracttaxexpenseview.Columns["nmov"].ExtendedProperties["ViewSource"] = "expenseview2.nmov";
            DS.csa_contracttaxexpenseview.Columns["phase"].ExtendedProperties["ViewSource"] = "expenseview2.phase";


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
            GetData.SetStaticFilter(DS.csa_contract, filter);
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            GetData.SetStaticFilter(DS.expenseview, filter);
            GetData.SetStaticFilter(DS.expenseview1, filter);
            GetData.SetStaticFilter(DS.expenseview2, filter);
            GetData.SetStaticFilter(DS.expenseview3, filter);
            GetData.SetStaticFilter(DS.expenseview4, filter);
            GetData.SetStaticFilter(DS.csa_contractview, filter);
            GetData.SetStaticFilter(DS.csa_contractkindview, filter);
            DataAccess.SetTableForReading(DS.upb1, "upb");
            DataAccess.SetTableForReading(DS.fin1, "fin");
            DataAccess.SetTableForReading(DS.upb2, "upb");
            DataAccess.SetTableForReading(DS.fin2, "fin");
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.account1, "account");
            DataAccess.SetTableForReading(DS.account2, "account");
            DataAccess.SetTableForReading(DS.expenseview1, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview2, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview3, "expenseview");
            DataAccess.SetTableForReading(DS.expenseview4, "expenseview");
            DataAccess.SetTableForReading(DS.epexpview1, "epexpview");
            DataAccess.SetTableForReading(DS.epexpview2, "epexpview");
            DataAccess.SetTableForReading(DS.epexpview3, "epexpview");
            GetData.SetSorting(DS.upb, "codeupb asc"); 
            GetData.CacheTable(DS.expensephase, QHS.AppAnd(QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                   QHS.CmpGe("nphase", Meta.GetSys("expensefinphase"))), "nphase", true);
            HelpForm.SetDenyNull(DS.csa_contract.Columns["flagkeepalive"], true);
            HelpForm.SetDenyNull(DS.csa_contract.Columns["flagrecreate"], true);

            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));  

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0)){
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
            PostData.MarkAsTemporaryTable(DS.fase_epexp, false);
            GetData.MarkToAddBlankRow(DS.fase_epexp);
            GetData.Add_Blank_Row(DS.fase_epexp);
            EnableFaseImpegnoBudget(1, "Preimpegno di Budget");
            EnableFaseImpegnoBudget(2, "Impegno di Budget");
       
        }

        void SetGBoxClass(object sortingkind){
            if (sortingkind != DBNull.Value){
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_csa_contract_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new csa_contract_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageRipUnica = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dgrContributi = new System.Windows.Forms.DataGrid();
			this.btnPagElimina = new System.Windows.Forms.Button();
			this.btnPagModifica = new System.Windows.Forms.Button();
			this.btnPagInserisci = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dgrAnagrafiche = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabControlVecchiaCfg = new System.Windows.Forms.TabControl();
			this.tabPagePrincipale = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtUnderwriting = new System.Windows.Forms.TextBox();
			this.btnUnderwriting = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gboxclassSiope = new System.Windows.Forms.GroupBox();
			this.btnCodiceSiope = new System.Windows.Forms.Button();
			this.txtDenomSiope = new System.Windows.Forms.TextBox();
			this.txtCodiceSiope = new System.Windows.Forms.TextBox();
			this.gboxSpesa = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtNum = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtEserc = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.btnSpesa = new System.Windows.Forms.Button();
			this.grpBilancioVersamento = new System.Windows.Forms.GroupBox();
			this.txtDescrBilancio = new System.Windows.Forms.TextBox();
			this.txtBilancio = new System.Windows.Forms.TextBox();
			this.btnBilancio = new System.Windows.Forms.Button();
			this.chkSpesa = new System.Windows.Forms.CheckBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.btnUPB = new System.Windows.Forms.Button();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.tabPageRipartizioni = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnElimina = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPageEP = new System.Windows.Forms.TabPage();
			this.gboxConto = new System.Windows.Forms.GroupBox();
			this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
			this.txtCodiceConto = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.gboxImponibile = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbFaseImpBudget = new System.Windows.Forms.ComboBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.btnLinkEpExp = new System.Windows.Forms.Button();
			this.btnRemoveEpExp = new System.Windows.Forms.Button();
			this.txtNumImpegno = new System.Windows.Forms.TextBox();
			this.txtEsercizioImpegno = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.chkKeepAlive = new System.Windows.Forms.CheckBox();
			this.txtNumContratto = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercContratto = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkFlagRecreate = new System.Windows.Forms.CheckBox();
			this.ckbAttivo = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbCompetenza = new System.Windows.Forms.RadioButton();
			this.rdbResidui = new System.Windows.Forms.RadioButton();
			this.txtNumeroregGenerale = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtCodiceRegGenerale = new System.Windows.Forms.TextBox();
			this.txtRegolaGenerale = new System.Windows.Forms.TextBox();
			this.button11 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPageRipUnica.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrContributi)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrAnagrafiche)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.tabControlVecchiaCfg.SuspendLayout();
			this.tabPagePrincipale.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gboxclassSiope.SuspendLayout();
			this.gboxSpesa.SuspendLayout();
			this.grpBilancioVersamento.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabPageRipartizioni.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPageEP.SuspendLayout();
			this.gboxConto.SuspendLayout();
			this.gboxImponibile.SuspendLayout();
			this.groupBox1.SuspendLayout();
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
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPageRipUnica);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(6, 184);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(887, 430);
			this.tabControl1.TabIndex = 5;
			// 
			// tabPageRipUnica
			// 
			this.tabPageRipUnica.Controls.Add(this.groupBox6);
			this.tabPageRipUnica.Location = new System.Drawing.Point(4, 22);
			this.tabPageRipUnica.Name = "tabPageRipUnica";
			this.tabPageRipUnica.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRipUnica.Size = new System.Drawing.Size(879, 404);
			this.tabPageRipUnica.TabIndex = 2;
			this.tabPageRipUnica.Text = "Ripartizione Unica";
			this.tabPageRipUnica.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.button8);
			this.groupBox6.Controls.Add(this.button9);
			this.groupBox6.Controls.Add(this.button10);
			this.groupBox6.Controls.Add(this.dataGrid3);
			this.groupBox6.Location = new System.Drawing.Point(6, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(864, 236);
			this.groupBox6.TabIndex = 22;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Ripartizione unica";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(17, 16);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(68, 22);
			this.button8.TabIndex = 19;
			this.button8.Tag = "insert.detail";
			this.button8.Text = "Inserisci";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(17, 48);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(68, 22);
			this.button9.TabIndex = 21;
			this.button9.Tag = "edit.detail";
			this.button9.Text = "Modifica";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(17, 80);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(68, 22);
			this.button10.TabIndex = 22;
			this.button10.Tag = "delete";
			this.button10.Text = "Elimina";
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(91, 19);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(764, 211);
			this.dataGrid3.TabIndex = 20;
			this.dataGrid3.Tag = "csa_contract_partition.default.detail";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.dgrContributi);
			this.tabPage1.Controls.Add(this.btnPagElimina);
			this.tabPage1.Controls.Add(this.btnPagModifica);
			this.tabPage1.Controls.Add(this.btnPagInserisci);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(879, 404);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Contributi";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dgrContributi
			// 
			this.dgrContributi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrContributi.CaptionVisible = false;
			this.dgrContributi.DataMember = "";
			this.dgrContributi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrContributi.Location = new System.Drawing.Point(108, 19);
			this.dgrContributi.Name = "dgrContributi";
			this.dgrContributi.ReadOnly = true;
			this.dgrContributi.Size = new System.Drawing.Size(747, 367);
			this.dgrContributi.TabIndex = 1;
			this.dgrContributi.TabStop = false;
			this.dgrContributi.Tag = "csa_contracttax.lista.default";
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
			this.tabPage2.Controls.Add(this.dgrAnagrafiche);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(879, 404);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Anagrafiche";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dgrAnagrafiche
			// 
			this.dgrAnagrafiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrAnagrafiche.CaptionVisible = false;
			this.dgrAnagrafiche.DataMember = "";
			this.dgrAnagrafiche.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrAnagrafiche.Location = new System.Drawing.Point(109, 19);
			this.dgrAnagrafiche.Name = "dgrAnagrafiche";
			this.dgrAnagrafiche.ReadOnly = true;
			this.dgrAnagrafiche.Size = new System.Drawing.Size(749, 367);
			this.dgrAnagrafiche.TabIndex = 1;
			this.dgrAnagrafiche.Tag = "csa_contractregistry.lista.default";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 75);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 22);
			this.button1.TabIndex = 3;
			this.button1.Tag = "Delete";
			this.button1.Text = "Elimina";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 47);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 22);
			this.button2.TabIndex = 2;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica...";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(9, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(68, 22);
			this.button3.TabIndex = 1;
			this.button3.Tag = "Insert.default";
			this.button3.Text = "Inserisci...";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.tabControlVecchiaCfg);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(879, 404);
			this.tabPage4.TabIndex = 4;
			this.tabPage4.Text = "Vecchia configurazione";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// tabControlVecchiaCfg
			// 
			this.tabControlVecchiaCfg.Controls.Add(this.tabPagePrincipale);
			this.tabControlVecchiaCfg.Controls.Add(this.tabPageRipartizioni);
			this.tabControlVecchiaCfg.Controls.Add(this.tabPageEP);
			this.tabControlVecchiaCfg.Location = new System.Drawing.Point(6, 6);
			this.tabControlVecchiaCfg.Name = "tabControlVecchiaCfg";
			this.tabControlVecchiaCfg.SelectedIndex = 0;
			this.tabControlVecchiaCfg.Size = new System.Drawing.Size(870, 384);
			this.tabControlVecchiaCfg.TabIndex = 46;
			// 
			// tabPagePrincipale
			// 
			this.tabPagePrincipale.Controls.Add(this.groupBox3);
			this.tabPagePrincipale.Controls.Add(this.groupBox2);
			this.tabPagePrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPagePrincipale.Name = "tabPagePrincipale";
			this.tabPagePrincipale.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagePrincipale.Size = new System.Drawing.Size(862, 358);
			this.tabPagePrincipale.TabIndex = 0;
			this.tabPagePrincipale.Text = "Principale";
			this.tabPagePrincipale.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtUnderwriting);
			this.groupBox3.Controls.Add(this.btnUnderwriting);
			this.groupBox3.Location = new System.Drawing.Point(410, 15);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(446, 43);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Tag = "AutoChoose.txtUnderwriting.default.(active = \'S\')";
			// 
			// txtUnderwriting
			// 
			this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnderwriting.Location = new System.Drawing.Point(121, 16);
			this.txtUnderwriting.Name = "txtUnderwriting";
			this.txtUnderwriting.Size = new System.Drawing.Size(317, 20);
			this.txtUnderwriting.TabIndex = 2;
			this.txtUnderwriting.TabStop = false;
			this.txtUnderwriting.Tag = "underwriting.title?csa_contractview.underwriting";
			// 
			// btnUnderwriting
			// 
			this.btnUnderwriting.Location = new System.Drawing.Point(9, 14);
			this.btnUnderwriting.Name = "btnUnderwriting";
			this.btnUnderwriting.Size = new System.Drawing.Size(104, 23);
			this.btnUnderwriting.TabIndex = 0;
			this.btnUnderwriting.Tag = "choose.underwriting.default";
			this.btnUnderwriting.Text = "Finanziamento";
			this.btnUnderwriting.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.gboxclassSiope);
			this.groupBox2.Controls.Add(this.gboxSpesa);
			this.groupBox2.Controls.Add(this.grpBilancioVersamento);
			this.groupBox2.Controls.Add(this.chkSpesa);
			this.groupBox2.Controls.Add(this.gboxUPB);
			this.groupBox2.Location = new System.Drawing.Point(3, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(857, 337);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Imputazione Costo Lordo";
			// 
			// gboxclassSiope
			// 
			this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
			this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
			this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
			this.gboxclassSiope.Location = new System.Drawing.Point(8, 127);
			this.gboxclassSiope.Name = "gboxclassSiope";
			this.gboxclassSiope.Size = new System.Drawing.Size(389, 100);
			this.gboxclassSiope.TabIndex = 3;
			this.gboxclassSiope.TabStop = false;
			this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
			this.gboxclassSiope.Text = "Classificazione SIOPE";
			// 
			// btnCodiceSiope
			// 
			this.btnCodiceSiope.Location = new System.Drawing.Point(10, 37);
			this.btnCodiceSiope.Name = "btnCodiceSiope";
			this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
			this.btnCodiceSiope.TabIndex = 4;
			this.btnCodiceSiope.TabStop = false;
			this.btnCodiceSiope.Tag = "manage.sorting.tree";
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
			this.txtDenomSiope.Size = new System.Drawing.Size(279, 44);
			this.txtDenomSiope.TabIndex = 3;
			this.txtDenomSiope.TabStop = false;
			this.txtDenomSiope.Tag = "sorting.description";
			// 
			// txtCodiceSiope
			// 
			this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodiceSiope.Location = new System.Drawing.Point(8, 66);
			this.txtCodiceSiope.Name = "txtCodiceSiope";
			this.txtCodiceSiope.Size = new System.Drawing.Size(373, 20);
			this.txtCodiceSiope.TabIndex = 3;
			this.txtCodiceSiope.Tag = "sorting.sortcode?x";
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
			this.gboxSpesa.Location = new System.Drawing.Point(413, 182);
			this.gboxSpesa.Name = "gboxSpesa";
			this.gboxSpesa.Size = new System.Drawing.Size(389, 108);
			this.gboxSpesa.TabIndex = 6;
			this.gboxSpesa.TabStop = false;
			this.gboxSpesa.Text = "Movimento di Spesa a cui collegare il Lordo";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(46, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "Fase";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNum
			// 
			this.txtNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNum.Location = new System.Drawing.Point(224, 69);
			this.txtNum.Name = "txtNum";
			this.txtNum.Size = new System.Drawing.Size(152, 20);
			this.txtNum.TabIndex = 5;
			this.txtNum.Tag = "";
			this.txtNum.Leave += new System.EventHandler(this.txtNum_Leave);
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(165, 69);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(54, 16);
			this.label13.TabIndex = 4;
			this.label13.Text = "Numero:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEserc
			// 
			this.txtEserc.Location = new System.Drawing.Point(93, 69);
			this.txtEserc.Name = "txtEserc";
			this.txtEserc.Size = new System.Drawing.Size(56, 20);
			this.txtEserc.TabIndex = 3;
			this.txtEserc.Tag = "";
			this.txtEserc.Leave += new System.EventHandler(this.txtEserc_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(12, 70);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 16);
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
			this.cmbFaseSpesa.Location = new System.Drawing.Point(93, 45);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(285, 21);
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
			this.btnSpesa.Size = new System.Drawing.Size(214, 23);
			this.btnSpesa.TabIndex = 1;
			this.btnSpesa.TabStop = false;
			this.btnSpesa.Text = "Scegli Movimento";
			this.btnSpesa.Click += new System.EventHandler(this.btnSpesa_Click);
			// 
			// grpBilancioVersamento
			// 
			this.grpBilancioVersamento.Controls.Add(this.txtDescrBilancio);
			this.grpBilancioVersamento.Controls.Add(this.txtBilancio);
			this.grpBilancioVersamento.Controls.Add(this.btnBilancio);
			this.grpBilancioVersamento.Location = new System.Drawing.Point(407, 15);
			this.grpBilancioVersamento.Name = "grpBilancioVersamento";
			this.grpBilancioVersamento.Size = new System.Drawing.Size(440, 114);
			this.grpBilancioVersamento.TabIndex = 2;
			this.grpBilancioVersamento.TabStop = false;
			this.grpBilancioVersamento.Tag = "AutoManage.txtBilancio.trees";
			this.grpBilancioVersamento.Text = "Capitolo Spesa";
			// 
			// txtDescrBilancio
			// 
			this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrBilancio.Location = new System.Drawing.Point(116, 14);
			this.txtDescrBilancio.Multiline = true;
			this.txtDescrBilancio.Name = "txtDescrBilancio";
			this.txtDescrBilancio.ReadOnly = true;
			this.txtDescrBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrBilancio.Size = new System.Drawing.Size(317, 58);
			this.txtDescrBilancio.TabIndex = 0;
			this.txtDescrBilancio.TabStop = false;
			this.txtDescrBilancio.Tag = "fin.title";
			// 
			// txtBilancio
			// 
			this.txtBilancio.Location = new System.Drawing.Point(6, 78);
			this.txtBilancio.Name = "txtBilancio";
			this.txtBilancio.Size = new System.Drawing.Size(427, 20);
			this.txtBilancio.TabIndex = 2;
			this.txtBilancio.Tag = "fin.codefin?csa_contractview.codefin_main";
			// 
			// btnBilancio
			// 
			this.btnBilancio.ImageIndex = 0;
			this.btnBilancio.Location = new System.Drawing.Point(6, 46);
			this.btnBilancio.Name = "btnBilancio";
			this.btnBilancio.Size = new System.Drawing.Size(90, 24);
			this.btnBilancio.TabIndex = 1;
			this.btnBilancio.TabStop = false;
			this.btnBilancio.Tag = "manage.fin.trees";
			this.btnBilancio.Text = "Bilancio";
			// 
			// chkSpesa
			// 
			this.chkSpesa.Location = new System.Drawing.Point(413, 155);
			this.chkSpesa.Name = "chkSpesa";
			this.chkSpesa.Size = new System.Drawing.Size(308, 26);
			this.chkSpesa.TabIndex = 5;
			this.chkSpesa.TabStop = false;
			this.chkSpesa.Text = "Seleziona  movimento di spesa per il Lordo";
			this.chkSpesa.CheckedChanged += new System.EventHandler(this.chkSpesa_CheckedChanged);
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.btnUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Location = new System.Drawing.Point(8, 13);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(389, 114);
			this.gboxUPB.TabIndex = 1;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 86);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(375, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// btnUPB
			// 
			this.btnUPB.Location = new System.Drawing.Point(6, 56);
			this.btnUPB.Name = "btnUPB";
			this.btnUPB.Size = new System.Drawing.Size(66, 24);
			this.btnUPB.TabIndex = 1;
			this.btnUPB.TabStop = false;
			this.btnUPB.Tag = "manage.upb.tree";
			this.btnUPB.Text = "UPB";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Location = new System.Drawing.Point(92, 14);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrUPB.Size = new System.Drawing.Size(289, 66);
			this.txtDescrUPB.TabIndex = 2;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// tabPageRipartizioni
			// 
			this.tabPageRipartizioni.Controls.Add(this.groupBox5);
			this.tabPageRipartizioni.Controls.Add(this.groupBox4);
			this.tabPageRipartizioni.Location = new System.Drawing.Point(4, 22);
			this.tabPageRipartizioni.Name = "tabPageRipartizioni";
			this.tabPageRipartizioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageRipartizioni.Size = new System.Drawing.Size(862, 358);
			this.tabPageRipartizioni.TabIndex = 1;
			this.tabPageRipartizioni.Text = "Ripartizioni";
			this.tabPageRipartizioni.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.button4);
			this.groupBox5.Controls.Add(this.button6);
			this.groupBox5.Controls.Add(this.button7);
			this.groupBox5.Controls.Add(this.dataGrid2);
			this.groupBox5.Location = new System.Drawing.Point(-4, 154);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(869, 151);
			this.groupBox5.TabIndex = 22;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Impegni di Budget";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(17, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(68, 22);
			this.button4.TabIndex = 19;
			this.button4.Tag = "insert.detail";
			this.button4.Text = "Inserisci";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(17, 48);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(68, 22);
			this.button6.TabIndex = 21;
			this.button6.Tag = "edit.detail";
			this.button6.Text = "Modifica";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(17, 80);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(68, 22);
			this.button7.TabIndex = 22;
			this.button7.Tag = "delete";
			this.button7.Text = "Elimina";
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(91, 19);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(769, 126);
			this.dataGrid2.TabIndex = 20;
			this.dataGrid2.Tag = "csa_contractepexp.default.detail";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btnInserisci);
			this.groupBox4.Controls.Add(this.btnModifica);
			this.groupBox4.Controls.Add(this.btnElimina);
			this.groupBox4.Controls.Add(this.dataGrid1);
			this.groupBox4.Location = new System.Drawing.Point(-4, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(869, 151);
			this.groupBox4.TabIndex = 21;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Finanziaria";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(17, 16);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnInserisci.TabIndex = 19;
			this.btnInserisci.Tag = "insert.detail";
			this.btnInserisci.Text = "Inserisci";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(17, 48);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(68, 22);
			this.btnModifica.TabIndex = 21;
			this.btnModifica.Tag = "edit.detail";
			this.btnModifica.Text = "Modifica";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(17, 80);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(68, 22);
			this.btnElimina.TabIndex = 22;
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
			this.dataGrid1.Location = new System.Drawing.Point(91, 19);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(769, 126);
			this.dataGrid1.TabIndex = 20;
			this.dataGrid1.Tag = "csa_contractexpense.default.detail";
			// 
			// tabPageEP
			// 
			this.tabPageEP.Controls.Add(this.gboxConto);
			this.tabPageEP.Controls.Add(this.gboxImponibile);
			this.tabPageEP.Location = new System.Drawing.Point(4, 22);
			this.tabPageEP.Name = "tabPageEP";
			this.tabPageEP.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageEP.Size = new System.Drawing.Size(862, 358);
			this.tabPageEP.TabIndex = 2;
			this.tabPageEP.Text = "EP";
			this.tabPageEP.UseVisualStyleBackColor = true;
			// 
			// gboxConto
			// 
			this.gboxConto.Controls.Add(this.txtDenominazioneConto);
			this.gboxConto.Controls.Add(this.txtCodiceConto);
			this.gboxConto.Controls.Add(this.button5);
			this.gboxConto.Location = new System.Drawing.Point(13, 6);
			this.gboxConto.Name = "gboxConto";
			this.gboxConto.Size = new System.Drawing.Size(389, 98);
			this.gboxConto.TabIndex = 5;
			this.gboxConto.TabStop = false;
			this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
			this.gboxConto.Text = "Conto EP di Costo";
			// 
			// txtDenominazioneConto
			// 
			this.txtDenominazioneConto.Location = new System.Drawing.Point(136, 16);
			this.txtDenominazioneConto.Multiline = true;
			this.txtDenominazioneConto.Name = "txtDenominazioneConto";
			this.txtDenominazioneConto.ReadOnly = true;
			this.txtDenominazioneConto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDenominazioneConto.Size = new System.Drawing.Size(245, 52);
			this.txtDenominazioneConto.TabIndex = 2;
			this.txtDenominazioneConto.TabStop = false;
			this.txtDenominazioneConto.Tag = "account.title";
			// 
			// txtCodiceConto
			// 
			this.txtCodiceConto.Location = new System.Drawing.Point(8, 72);
			this.txtCodiceConto.Name = "txtCodiceConto";
			this.txtCodiceConto.Size = new System.Drawing.Size(373, 20);
			this.txtCodiceConto.TabIndex = 4;
			this.txtCodiceConto.Tag = "account.codeacc?csa_contractview.codeacc_main";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(10, 45);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 23);
			this.button5.TabIndex = 1;
			this.button5.TabStop = false;
			this.button5.Tag = "manage.account.tree";
			this.button5.Text = "Conto";
			// 
			// gboxImponibile
			// 
			this.gboxImponibile.Controls.Add(this.label6);
			this.gboxImponibile.Controls.Add(this.cmbFaseImpBudget);
			this.gboxImponibile.Controls.Add(this.label34);
			this.gboxImponibile.Controls.Add(this.label33);
			this.gboxImponibile.Controls.Add(this.btnLinkEpExp);
			this.gboxImponibile.Controls.Add(this.btnRemoveEpExp);
			this.gboxImponibile.Controls.Add(this.txtNumImpegno);
			this.gboxImponibile.Controls.Add(this.txtEsercizioImpegno);
			this.gboxImponibile.Location = new System.Drawing.Point(13, 110);
			this.gboxImponibile.Name = "gboxImponibile";
			this.gboxImponibile.Size = new System.Drawing.Size(498, 92);
			this.gboxImponibile.TabIndex = 45;
			this.gboxImponibile.TabStop = false;
			this.gboxImponibile.Text = "Impegno di Budget";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Fase";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
			this.label34.Location = new System.Drawing.Point(114, 58);
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
			this.btnLinkEpExp.Location = new System.Drawing.Point(240, 49);
			this.btnLinkEpExp.Name = "btnLinkEpExp";
			this.btnLinkEpExp.Size = new System.Drawing.Size(110, 23);
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
			this.txtNumImpegno.Location = new System.Drawing.Point(164, 54);
			this.txtNumImpegno.Name = "txtNumImpegno";
			this.txtNumImpegno.Size = new System.Drawing.Size(64, 20);
			this.txtNumImpegno.TabIndex = 3;
			this.txtNumImpegno.Tag = "";
			this.txtNumImpegno.Leave += new System.EventHandler(this.txtNumImpegno_Leave);
			// 
			// txtEsercizioImpegno
			// 
			this.txtEsercizioImpegno.Location = new System.Drawing.Point(61, 55);
			this.txtEsercizioImpegno.Name = "txtEsercizioImpegno";
			this.txtEsercizioImpegno.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizioImpegno.TabIndex = 2;
			this.txtEsercizioImpegno.Tag = "";
			this.txtEsercizioImpegno.Leave += new System.EventHandler(this.txtEsercizioImpegno_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(10, 44);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(398, 43);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "csa_contract.description";
			// 
			// chkKeepAlive
			// 
			this.chkKeepAlive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkKeepAlive.Location = new System.Drawing.Point(708, 18);
			this.chkKeepAlive.Name = "chkKeepAlive";
			this.chkKeepAlive.Size = new System.Drawing.Size(181, 27);
			this.chkKeepAlive.TabIndex = 3;
			this.chkKeepAlive.TabStop = false;
			this.chkKeepAlive.Tag = "csa_contract.flagkeepalive:S:N";
			this.chkKeepAlive.Text = "Conserva negli anni successivi";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(226, 7);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(56, 20);
			this.txtNumContratto.TabIndex = 3;
			this.txtNumContratto.Tag = "csa_contract.ncontract";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(162, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Numero:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercContratto
			// 
			this.txtEsercContratto.Location = new System.Drawing.Point(88, 7);
			this.txtEsercContratto.Name = "txtEsercContratto";
			this.txtEsercContratto.Size = new System.Drawing.Size(56, 20);
			this.txtEsercContratto.TabIndex = 2;
			this.txtEsercContratto.Tag = "csa_contract.ycontract.year";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Competenza";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(439, 44);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(254, 43);
			this.textBox1.TabIndex = 2;
			this.textBox1.Tag = "csa_contract.title";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(436, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Descrizione sintetica:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkFlagRecreate
			// 
			this.chkFlagRecreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkFlagRecreate.Location = new System.Drawing.Point(708, 41);
			this.chkFlagRecreate.Name = "chkFlagRecreate";
			this.chkFlagRecreate.Size = new System.Drawing.Size(181, 27);
			this.chkFlagRecreate.TabIndex = 4;
			this.chkFlagRecreate.TabStop = false;
			this.chkFlagRecreate.Tag = "csa_contract.flagrecreate:S:N";
			this.chkFlagRecreate.Text = "Ricrea negli anni successivi";
			// 
			// ckbAttivo
			// 
			this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ckbAttivo.Location = new System.Drawing.Point(708, 71);
			this.ckbAttivo.Name = "ckbAttivo";
			this.ckbAttivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ckbAttivo.Size = new System.Drawing.Size(80, 16);
			this.ckbAttivo.TabIndex = 5;
			this.ckbAttivo.TabStop = false;
			this.ckbAttivo.Tag = "csa_contract.active:S:N";
			this.ckbAttivo.Text = "Attivo";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbCompetenza);
			this.groupBox1.Controls.Add(this.rdbResidui);
			this.groupBox1.Controls.Add(this.txtNumeroregGenerale);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtCodiceRegGenerale);
			this.groupBox1.Controls.Add(this.txtRegolaGenerale);
			this.groupBox1.Controls.Add(this.button11);
			this.groupBox1.Location = new System.Drawing.Point(10, 93);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(683, 72);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "AutoChoose.txtRegolaGenerale.default.(active = \'S\')";
			this.groupBox1.Text = "Regola generale CSA";
			// 
			// rdbCompetenza
			// 
			this.rdbCompetenza.Location = new System.Drawing.Point(561, 15);
			this.rdbCompetenza.Name = "rdbCompetenza";
			this.rdbCompetenza.Size = new System.Drawing.Size(96, 16);
			this.rdbCompetenza.TabIndex = 8;
			this.rdbCompetenza.Tag = "csa_contractkind.flagcr:C?csa_contractview.csa_contractkindflagcr:C";
			this.rdbCompetenza.Text = "Competenza";
			// 
			// rdbResidui
			// 
			this.rdbResidui.Location = new System.Drawing.Point(561, 34);
			this.rdbResidui.Name = "rdbResidui";
			this.rdbResidui.Size = new System.Drawing.Size(96, 16);
			this.rdbResidui.TabIndex = 9;
			this.rdbResidui.Tag = "csa_contractkind.flagcr:R?csa_contractview.csa_contractkindflagcr:R";
			this.rdbResidui.Text = "Residui";
			// 
			// txtNumeroregGenerale
			// 
			this.txtNumeroregGenerale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumeroregGenerale.Location = new System.Drawing.Point(458, 42);
			this.txtNumeroregGenerale.Name = "txtNumeroregGenerale";
			this.txtNumeroregGenerale.Size = new System.Drawing.Size(75, 20);
			this.txtNumeroregGenerale.TabIndex = 7;
			this.txtNumeroregGenerale.Tag = "csa_contractkind.idcsa_contractkind?csa_contractview.idcsa_contractkind";
			this.txtNumeroregGenerale.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(398, 43);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Numero";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(99, 43);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 21);
			this.label8.TabIndex = 3;
			this.label8.Text = "Codice";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodiceRegGenerale
			// 
			this.txtCodiceRegGenerale.Location = new System.Drawing.Point(162, 43);
			this.txtCodiceRegGenerale.Name = "txtCodiceRegGenerale";
			this.txtCodiceRegGenerale.Size = new System.Drawing.Size(236, 20);
			this.txtCodiceRegGenerale.TabIndex = 2;
			this.txtCodiceRegGenerale.Tag = "csa_contractkind.contractkindcode?csa_contractview.csa_contractkindcode";
			// 
			// txtRegolaGenerale
			// 
			this.txtRegolaGenerale.Location = new System.Drawing.Point(162, 16);
			this.txtRegolaGenerale.Name = "txtRegolaGenerale";
			this.txtRegolaGenerale.Size = new System.Drawing.Size(371, 20);
			this.txtRegolaGenerale.TabIndex = 1;
			this.txtRegolaGenerale.Tag = "csa_contractkind.description?csa_contractview.csa_contractkind";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(6, 15);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(150, 25);
			this.button11.TabIndex = 0;
			this.button11.Tag = "choose.csa_contractkind.default";
			this.button11.Text = "Regola generale associata";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// Frm_csa_contract_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(896, 626);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ckbAttivo);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.txtNumContratto);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.chkFlagRecreate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.chkKeepAlive);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtEsercContratto);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_csa_contract_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmContratto";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPageRipUnica.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrContributi)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrAnagrafiche)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabControlVecchiaCfg.ResumeLayout(false);
			this.tabPagePrincipale.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.gboxclassSiope.ResumeLayout(false);
			this.gboxclassSiope.PerformLayout();
			this.gboxSpesa.ResumeLayout(false);
			this.gboxSpesa.PerformLayout();
			this.grpBilancioVersamento.ResumeLayout(false);
			this.grpBilancioVersamento.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.tabPageRipartizioni.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPageEP.ResumeLayout(false);
			this.gboxConto.ResumeLayout(false);
			this.gboxConto.PerformLayout();
			this.gboxImponibile.ResumeLayout(false);
			this.gboxImponibile.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e) {
            chkSpesa_CheckedChanged(sender, e, true);
        }

        private void chkSpesa_CheckedChanged (object sender, System.EventArgs e, bool DispMessage) {
            if (chkSpesa.Checked) {
                EnableDisable(false);
                if (Meta.IsEmpty) return;
                DataRow R = DS.csa_contract.Rows[0];
                if ((R["idfin_main"] != DBNull.Value) ||
                    (R["idupb"] != DBNull.Value)) {

                    if (DispMessage) {
                        if (MessageBox.Show("Per abilitare la selezione del movimento di spesa Ë necessario annullare le altre " +
                            "attribuzioni su questo contratto. Proseguo?", "Conferma",
                            MessageBoxButtons.OKCancel) != DialogResult.OK) {
                            chkSpesa.Checked = false;
                            return;
                        }
                    }
                    R["idfin_main"] = DBNull.Value;
                    R["idupb"] = DBNull.Value;
                    DS.fin.Clear();
                    txtBilancio.Text = "";
                    txtDescrBilancio.Text = "";
                    Meta.SetAutoField(DBNull.Value,txtUPB);
                    txtDescrUPB.Text = "";
                    return;
                }
                return;
            }
            if (Meta.IsEmpty) return;
            EnableDisable(true);

            DataRow RR = DS.csa_contract.Rows[0];

            if (RR["idexp_main"] != DBNull.Value) {
                  if (DispMessage) {
                      if (MessageBox.Show("Per abilitare la selezione delle attribuzioni normali su questo contratto Ë necessario annullare il collegamento al movimento di spesa " +
                          ". Proseguo?", "Conferma",
                          MessageBoxButtons.OKCancel) != DialogResult.OK) {
                          chkSpesa.Checked = true;
                          return;
                      }
                }
                RR["idexp_main"] = DBNull.Value;
                DS.expenseview.Clear();
                cmbFaseSpesa.SelectedIndex = 0;
                txtEserc.Text = "";
                txtNum.Text = "";
            }
        }

        object Get_Registry_Auto () {
            if (Meta.IsEmpty) return DBNull.Value;
            object esercizio = Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return DBNull.Value;
            if (t.Rows.Count == 0) return DBNull.Value;
            DataRow rConfig = t.Rows[0];
            return rConfig["idregauto"];
        }

        object Get_Registry_Csa () {
            if (Meta.IsEmpty) return DBNull.Value;
            object esercizio = Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
            if (t == null) return DBNull.Value;
            if (t.Rows.Count == 0) return DBNull.Value;
            DataRow rConfig = t.Rows[0];
            return rConfig["idreg_csa"];
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
			btnUPB.Enabled = enable;
            txtUPB.ReadOnly = !enable;
			txtBilancio.ReadOnly = !enable;			
		}

		void EnableDisable(bool parteNormale){
			EnableDisableParteNormale(parteNormale);
			EnableDisableParteSpesa(!parteNormale);
		}

        private void btnSpesa_Click (object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Curr = DS.csa_contract.Rows[0];
            string filter = "";
            int selectedfase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
            object idregcsa = Get_Registry_Csa();
            if (selectedfase > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nphase", selectedfase), 
                         QHS.DoPar(QHS.NullOrEq("idreg", idregcsa)));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpNe("nphase", Meta.GetSys("maxexpensephase")),
                         QHS.CmpGe("nphase", Meta.GetSys("expensefinphase")), 
                         QHS.DoPar(QHS.NullOrEq("idreg", idregcsa)));
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
                if (f.GetUPB() != DBNull.Value) {
                    
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
            if (Choosen == null) {
                MessageBox.Show("Nessuna riga trovata con il filtro " + filter, "Avviso");
                Meta.FreshForm(true);
                return;
            }
            int oldIdExp = CfgFn.GetNoNullInt32(Curr["idexp_main"]);
            int newIdExp = CfgFn.GetNoNullInt32(Choosen["idexp"]);
            Curr["idexp_main"] = Choosen["idexp"];

            DS.expenseview.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.expenseview, null,
                QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp_main"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))),
                null, true);
            txtEserc.Text = Choosen["ymov"].ToString();
            txtNum.Text = Choosen["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = Choosen["nphase"];
            

            Meta.FreshForm(false);
        }



        public void MetaData_AfterFill() {
            if (Meta.FirstFillForThisRow)
                ImpostaCheckSpesa();
            if (!Meta.InsertMode) {
                VisualizzaMovimentoSpesa();
                VisualizzaMovimentoBudget();
            }
            //txtEsercContratto.ReadOnly = true;
            txtNumContratto.ReadOnly = true;
            txtCodiceRegGenerale.ReadOnly = true;
            txtNumeroregGenerale.ReadOnly = true;
            rdbCompetenza.Enabled = false;
            rdbResidui.Enabled = false;
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttax);
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttaxexpense);
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttaxepexp);
            Meta.MarkTableAsNotEntityChild(DS.csa_contracttax_partition);
            if (DS.HasChanges())
            {
                DataRow[] righeDeleted = DS.csa_contracttax.Select(null, null, DataViewRowState.Deleted);
                foreach (DataRow D in righeDeleted)
                {
                    foreach (DataRow RipartR in DS.csa_contracttaxexpense.Select(
                        QHC.AppAnd(QHC.CmpEq("ayear", D["ayear",DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contract", D["idcsa_contract", DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contracttax", D["idcsa_contracttax", DataRowVersion.Original]))))
                    {
                        RipartR.Delete();
                    }
                    //D.Delete();

                }

                foreach (DataRow D in righeDeleted)
                {
                    foreach (DataRow RipartR1 in DS.csa_contracttaxepexp.Select(
                        QHC.AppAnd(QHC.CmpEq("ayear", D["ayear", DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contract", D["idcsa_contract", DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contracttax", D["idcsa_contracttax", DataRowVersion.Original]))))
                    {
                        RipartR1.Delete();
                    }
                    //D.Delete();

                }

                foreach (DataRow D in righeDeleted) {
                    foreach (DataRow RipartR1 in DS.csa_contracttax_partition.Select(
                        QHC.AppAnd(QHC.CmpEq("ayear", D["ayear", DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contract", D["idcsa_contract", DataRowVersion.Original]),
                                   QHC.CmpEq("idcsa_contracttax", D["idcsa_contracttax", DataRowVersion.Original])))) {
                        RipartR1.Delete();
                    }
                    //D.Delete();

                }


            }

            if (DS.epexp.Rows.Count > 0)
            {
                object currtipo = DS.Tables["epexp"].Rows[0]["nphase"];
                HelpForm.SetComboBoxValue(cmbFaseImpBudget, currtipo);
            }
        }

        public void MetaData_AfterClear () {
            ImpostaCheckSpesa();
            txtEserc.Text = "";
            txtNum.Text = "";
            cmbFaseSpesa.SelectedIndex = 0;
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = 0;
            //txtEsercContratto.ReadOnly = false;
            txtNumContratto.ReadOnly = false;
            txtCodiceRegGenerale.ReadOnly = false;
            txtNumeroregGenerale.ReadOnly = false;
            rdbCompetenza.Enabled = true;
            rdbResidui.Enabled = true;
        }

        void ImpostaCheckSpesa () {
            if (Meta.IsEmpty) {
                EnableDisable(true);
                return;
            }
            DataRow R = DS.csa_contract.Rows[0];
            if (R["idexp_main"] != DBNull.Value)
                chkSpesa.Checked = true;
            else
                chkSpesa.Checked = false;
            chkSpesa_CheckedChanged(null, null,false);         
           
        }

        public void MetaData_BeforePost()
        {
            if (DS.csa_contract.Rows.Count == 0)
            {
                DS.csa_contracttax.Clear();
                return; //Insert/Cancel sequence
            }
            DataRow R = DS.csa_contract.Rows[0];
            if (R.RowState == DataRowState.Deleted)
            {
                foreach (DataRow A in DS.csa_contracttaxexpense.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();

                foreach (DataRow A in DS.csa_contracttaxepexp.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();

                foreach (DataRow A in DS.csa_contracttax_partition.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();

                foreach (DataRow A in DS.csa_contracttax.Select())
                    if (A.RowState != DataRowState.Deleted)
                        A.Delete();
            }
        }

        private void VisualizzaMovimentoSpesa() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idexp = DS.Tables["csa_contract"].Rows[0]["idexp_main"];
            string filter = QHS.CmpEq("idexp", idexp);
            DataTable DT = Conn.RUN_SELECT("expense", "idexp,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseSpesa.SelectedValue = DT.Rows[0]["nphase"];
        }
        private void VisualizzaMovimentoBudget() {
            if (MetaData.Empty(this)) return;
            object idepexp = DS.Tables["csa_contract"].Rows[0]["idepexp_main"];
            string filter = QHS.CmpEq("idepexp", idepexp);
            DataTable DT = Conn.RUN_SELECT("epexp", "idepexp, yepexp, nepexp, nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEsercizioImpegno.Text = DT.Rows[0]["yepexp"].ToString();
            txtNumImpegno.Text = DT.Rows[0]["nepexp"].ToString();
            cmbFaseImpBudget.SelectedValue = DT.Rows[0]["nphase"];
        }

        private void txtNum_Leave (object sender, EventArgs e) {
            if (Meta.destroyed || Meta.formController.isClosing) return;
            if (Meta.IsEmpty) return;
            if (txtNum.ReadOnly) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            if ((Curr["idexp_main"] != DBNull.Value) && (txtNum.Text.Trim() == "")) {
                DS.expenseview.Clear();
                Curr["idexp_main"] = DBNull.Value;
            }
            btnSpesa_Click(sender, e);
        }

        private void txtEserc_Leave (object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEserc);
            if (Meta.destroyed || Meta.formController.isClosing) return;
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            if (Curr["idexp_main"] != DBNull.Value) {
                if (txtEserc.Text.Trim() == "") {
                    txtNum.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp_main"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["ymov"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEserc.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNum.Text = "";
                            DS.expenseview.Clear();
                            Curr["idexp_main"] = DBNull.Value;
                        }
                    }
                    else {
                        Curr["idexp_main"] = DBNull.Value;
                    }
                }

            }

        }

        private void cmbFaseSpesa_SelectedIndexChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            if (Curr["idexp_main"] != DBNull.Value) {
                int oldNphase = -1;
                if (DS.expenseview.Rows.Count > 0) {
                    oldNphase = CfgFn.GetNoNullInt32(DS.expenseview.Rows[0]["nphase"]);
                }
                int newNPhase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                if (oldNphase != newNPhase) {
                    txtNum.Text = "";
                    txtEserc.Text = "";
                    DS.expenseview.Clear();
                    Curr["idexp_main"] = DBNull.Value;
                }
            }

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
            DataRow curr = DS.csa_contract.Rows[0];
            MetaData.GetFormData(this, true);
            EP_functions ep = new EP_functions(Meta.Dispatcher);

            object nphase = cmbFaseImpBudget.SelectedValue; // Impegno
            string filter = "";
            int yepexp = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
            if (yepexp != 0) {
                filter = QHS.CmpEq("yepexp", yepexp);
            }
            else {
                filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            }
            int nepexp = CfgFn.GetNoNullInt32(txtNumImpegno.Text.Trim());
            if (nepexp != 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("nepexp", nepexp));
            }

            string filter_fase = "";
            if (CfgFn.GetNoNullInt32(nphase) == 0) {
                filter_fase = QHS.DoPar(
                        QHS.AppOr(QHS.CmpEq("nphase", 1),
                        QHS.AppAnd(QHS.CmpEq("nphase", 2), QHS.CmpEq("idreg", Get_Registry_Csa()))
                        ));
            }
            if (CfgFn.GetNoNullInt32( nphase) == 1) {
                filter_fase = QHS.CmpEq("nphase", nphase);
            }
            if (CfgFn.GetNoNullInt32(nphase) == 2) 
            {
                filter_fase = QHS.AppAnd(QHS.CmpEq("nphase", nphase), QHS.CmpEq("idreg", Get_Registry_Csa()));
            }
            filter = QHS.AppAnd(filter, filter_fase);
            //  Filter = QHS.AppAnd(Filter, EP.GetFilterForEpexp(Meta, Curr["idrelated"].ToString()));
            String fAmount = QHS.CmpGt("isnull(totcurramount,0) - isnull(totalcost,0)", 0); // condizione sul disponibile
            filter = QHS.AppAnd(filter, fAmount);

            // Introduco un filtro su UPB E CONTO 
            object selectedUPB = curr["idupb"];
            object selectedAccount = curr["idacc_main"];

            var filterUpb = "";
            if (selectedUPB != DBNull.Value)

                filterUpb = QHC.CmpEq("idupb", selectedUPB);
            var filterAccount = "";
            if (selectedAccount != DBNull.Value)
                filterAccount = QHC.CmpEq("idacc", selectedAccount);

            filter = QHS.AppAnd(filter, filterUpb);
            if (filterAccount != "") {
                filter = QHS.AppAnd(filter, filterAccount);
            }

            string VistaScelta = "epexpview";

            MetaData mepexp = Meta.Dispatcher.Get(VistaScelta);
            mepexp.FilterLocked = true;
            mepexp.DS = DS;
            DataRow Choosen = mepexp.SelectOne("default", filter, null, null);

            if (Choosen != null){
                curr["idepexp_main"] = Choosen["idepexp"];
                curr["idacc_main"] = Choosen["idacc"];
                curr["idupb"] = Choosen["idupb"];
                Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", curr["idacc_main"]),
                 null, true);
                Conn.RUN_SELECT_INTO_TABLE(DS.upb, null,
                 QHS.CmpEq("idupb", curr["idupb"]),
                 null, true);
                txtEsercizioImpegno.Text = Choosen["yepexp"].ToString();
                txtNumImpegno.Text = Choosen["nepexp"].ToString();
                cmbFaseImpBudget.SelectedValue = Choosen["nphase"];

                Meta.FreshForm();
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            Curr["idepexp_main"] = DBNull.Value;
            DS.epexp.Clear();
            txtEsercizioImpegno.Text = "";
            txtNumImpegno.Text = "";
            cmbFaseImpBudget.SelectedIndex = -1;
            Meta.FreshForm();
        }

        private void cmbFaseImpBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            if (cmbFaseImpBudget.SelectedIndex <= 0)
            {
                btnRemoveEpExp_Click(sender, e);
            }
        }

        private void txtEsercizioImpegno_Leave(object sender, EventArgs e) {
            HelpForm.FormatLikeYear(txtEsercizioImpegno);
            if (Meta.destroyed || Meta.formController.isClosing) return;            
            if (Meta.IsEmpty || DS.csa_contract.Rows.Count==0) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            if (Curr["idepexp_main"] != DBNull.Value) {
                if (txtEsercizioImpegno.Text.Trim() == "") {
                    txtNumImpegno.Text = "";
                    DS.epexpview.Clear();
                    Curr["idepexp_main"] = DBNull.Value;
                }
                else {
                    if (DS.expenseview.Rows.Count > 0) {
                        int oldYmov = CfgFn.GetNoNullInt32(DS.epexpview.Rows[0]["yepexp"]);
                        int newYmov = CfgFn.GetNoNullInt32(txtEsercizioImpegno.Text.Trim());
                        if (oldYmov != newYmov) {
                            txtNumImpegno.Text = "";
                            DS.epexpview.Clear();
                            Curr["idepexp_main"] = DBNull.Value;
                        }
                    }
                    else {
                        txtNumImpegno.Text = "";
                        Curr["idepexp_main"] = DBNull.Value;
                    }
                }

            }
        }

        private void txtNumImpegno_Leave(object sender, EventArgs e) {
            if (Meta.destroyed || Meta.formController.isClosing) return;
            if (Meta.IsEmpty || DS.csa_contract.Rows.Count == 0) return;
            if (txtNumImpegno.ReadOnly) return;
            DataRow Curr = DS.csa_contract.Rows[0];
            if ((Curr["idepexp_main"] != DBNull.Value) && (txtNumImpegno.Text.Trim() == "")) {
                DS.epexpview.Clear();
                Curr["idepexp_main"] = DBNull.Value;
            }
            btnLinkEpExp_Click(sender, e);
        }

        private void textBox5_TextChanged(object sender, EventArgs e) {

        }
    }
}
