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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using funzioni_configurazione;
using ep_functions;
using movimentofunctions;

namespace ivapay_wizard_calcolo {
    /// <summary>
    /// Summary description for frmliquidazioneiva_calcolo.
    /// </summary>
    public class Frm_ivapay_wizard_calcolo : System.Windows.Forms.Form {
        public vistaForm DS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private string CustomTitle;
        private MetaData Meta;
        private DataAccess Conn;
        private object esercizio;
        private Hashtable errmsg = null;
        private string tag_perc = "tabella.campo.fixed.2..%.100";
        private object maxfasespesa;
        private object maxfaseentrata;
        private Hashtable RighePadriEntrata;
        private Hashtable RighePadriSpesa;
        MetaDataDispatcher Disp;
        private DataTable TAutomatismi;
        private DateTime m_ToDate;
        private int m_PeriodicitaMese = 1;
        private int periodo = 0;

        //DataTable fattureLiquidate;

        CQueryHelper QHC;
        QueryHelper QHS;
        bool ModoCalcolo_RigaPerRiga = true;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private Label label67;
        private TextBox txtLiquidMese__split;
        private Label labCredito4__split;
        private Label labCredito3__split;
        private TextBox txtNuovoSaldo__split;
        private Panel panel5;
        private Label label70;
        private Label label71;
        private Label lblcredito5__split;
        private Label lblcredito2__split;
        private Label lblcredito1__split;
        private TextBox txtIvaPeriodo__split;
        private TextBox txtTotaleIva__split;
        private TextBox txtSaldoPrec__split;
        private Panel panel6;
        private Label label77;
        private Label label78;
        private Label label46;
        private Panel panel4;
        private Label lblcredito5__12;
        private Label lblcredito2__12;
        private Label lblcredito1__12;
        private TextBox txtLiquidMese12;
        private Label lab_credito4_12;
        private Label lab_credito3_12;
        private TextBox txtNuovoSaldo12;
        private Panel panel3;
        private Label label50;
        private Label label51;
        private Label lab_credito5_12;
        private Label lab_credito2_12;
        private Label lab_credito1_12;
        private TextBox txtIvaPeriodo12;
        private TextBox txtTotaleIva12;
        private TextBox txtSaldoPrec12;
        private Label label45;
        private TextBox txtLiquidMese;
        private Label label37;
        private Label labCredito4;
        private Label labCredito3;
        private TextBox txtNuovoSaldo;
        private Label label36;
        private Panel panel2;
        private Label label25;
        private Label label26;
        private Label lblcredito5;
        private Label lblcredito2;
        private Label lblcredito1;
        private TextBox txtIvaPeriodo;
        private Label label14;
        private TextBox txtTotaleIva;
        private Label lblSaldoCorr;
        private TextBox txtSaldoPrec;
        private Label label12;
        private Crownwood.Magic.Controls.TabPage tabpage1;
        private GroupBox groupBox15;
        private CheckBox chkIstituzionaleSplit;
        private CheckBox chkIstituzionale;
        private CheckBox chkCommerciale;
        private GroupBox groupBox14;
        private TextBox txtDataRegolamento;
        private Label label10;
        private Label lblEndOfYear;
        private Label label23;
        private GroupBox groupBox3;
        private Label label13;
        private TextBox txtPromiscuo;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtProrata;
        private GroupBox groupBox1;
        private CheckBox chkEndOfYear;
        private TextBox txtPeriodicita;
        private Label label4;
        private Label label3;
        private TextBox txtAl;
        private TextBox txtDal;
        private Label label6;
        private Label label1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private TextBox txtTotIvaIstituzionaleSplit;
        private Label label61;
        private TextBox txtTotIvaIstituzIntrastat;
        private Label label43;
        private Label label9;
        private TextBox txtIvaCredito;
        private Label labTotDopoProrata;
        private TextBox txtIvaCreditoProrata;
        private TabControl tabControl2;
        private TabPage tabPage6;
        private Label lblMessaggi;
        private DataGrid gridDebito;
        private GroupBox groupBox5;
        private Label label8;
        private Label label15;
        private TextBox txtIvaDebitoImmediata;
        private TextBox txtIvaDebitoDifferita;
        private TabPage tabPage7;
        private GroupBox groupBox7;
        private Label label22;
        private TextBox txtIndetraibileDifferita;
        private TextBox txtIvaCreditoTotaleDifferita;
        private Label label20;
        private Label label18;
        private TextBox txtIvaCreditoDifferita;
        private Label label7;
        private GroupBox groupBox6;
        private Label label17;
        private TextBox txtIndetraibileImmediata;
        private TextBox txtIvaCreditoTotaleImmediata;
        private Label label19;
        private TextBox txtIvaCreditoImmediata;
        private Label label21;
        private DataGrid gridAcquisti;
        private GroupBox groupBox4;
        private TextBox txtIvaCreditoTotaleCommerciale;
        private Label label2;
        private TabPage tabPage8;
        private Label label30;
        private GroupBox groupBox9;
        private Label label31;
        private TextBox txtIndetraibileImmediataPromiscui;
        private TextBox txtIvaCreditoTotaleImmediataPromiscui;
        private Label label32;
        private TextBox txtIvaCreditoImmediataPromiscui;
        private Label label33;
        private DataGrid gridacquistipromiscui;
        private GroupBox groupBox10;
        private TextBox txtIvaCreditoTotalePromiscuiPOST;
        private Label labTotIvaPromPOST;
        private TextBox txtIvaCreditoTotalePromiscui;
        private Label label34;
        private GroupBox groupBox8;
        private Label label27;
        private TextBox txtIndetraibileDifferitaPromiscui;
        private TextBox txtIvaCreditoTotaleDifferitaPromiscui;
        private Label label28;
        private Label label29;
        private TextBox txtIvaCreditoDifferitaPromiscui;
        private TabPage tabIntra12;
        private GroupBox groupBox11;
        private Label label35;
        private TextBox txtIvaIstituzDeferr;
        private TextBox txtImpIstituzDeferr;
        private Label label38;
        private Label label40;
        private GroupBox groupBox12;
        private Label label41;
        private TextBox txtIvaIstituzImmed;
        private TextBox txtImpIstituzImmed;
        private Label label42;
        private DataGrid gridacquistiistituzionaliINTRA;
        private GroupBox groupBox13;
        private TextBox txtTotIvaIstituz;
        private Label label39;
        private TextBox txtTotImpIstituz;
        private Label label44;
        private TabPage tabPage9;
        private GroupBox groupBox16;
        private Label label47;
        private TextBox txtIvaIstituzDeferrSplit;
        private TextBox txtImpIstituzDeferrSplit;
        private Label label48;
        private Label label52;
        private GroupBox groupBox17;
        private Label label53;
        private TextBox txtIvaIstituzImmedSplit;
        private TextBox txtImpIstituzImmedSplit;
        private Label label54;
        private DataGrid gridacquistiistituzionaliSplit;
        private GroupBox groupBox18;
        private TextBox txtTotIvaIstituzSplit;
        private Label label59;
        private TextBox txtTotImpIstituzSplit;
        private Label label60;
        private Label label16;
        private TextBox txtIvaDebito;
        private Panel panel1;
        private TabControl tabControl;
        private TabPage tabPage4;
        private Button btnCambiaUPBEntrata;
        private DataGrid gridEntrata;
        private Button btnScollegaE;
        private Button btnCollegaE;
        private Label label11;
        private TabPage tabPage5;
        private Button btnCambiaUPBSpesa;
        private Label label24;
        private DataGrid gridSpesa;
        private Button btnScollegaS;
        private Button btnCollegaS;
        bool GeneraTuttelafasi = true;
        private DataTable AltriPagamenti;
        private DataTable AltriPagamentiIntraExtraUe;
        private Crownwood.Magic.Controls.TabPage tabPage13;
        private Label label49;
        private TextBox txtLiquidMese__split1;
        private Label labCredito4__split1;
        private Label labCredito3__split1;
        private TextBox txtNuovoSaldo__split1;
        private Panel panel7;
        private Label label57;
        private Label label58;
        private Label lblcredito5__split1;
        private Label lblcredito2__split1;
        private Label lblcredito1__split1;
        private TextBox txtIvaPeriodo__split1;
        private TextBox txtTotaleIva__split1;
        private TextBox txtSaldoPrec__split1;
        private Panel panel8;
        private Label label65;
        private Label label66;
        private Label label68;
        private Panel panel9;
        private Label lblcredito5__121;
        private Label lblcredito2__121;
        private Label lblcredito1__121;
        private TextBox txtLiquidMese121;
        private Label lab_credito4_121;
        private Label lab_credito3_121;
        private TextBox txtNuovoSaldo121;
        private Panel panel10;
        private Label label76;
        private Label label79;
        private Label label80;
        private Label label81;
        private Label label82;
        private TextBox txtIvaPeriodo121;
        private TextBox txtTotaleIva121;
        private TextBox txtSaldoPrec121;
        private Label label83;
        private TextBox txtLiquidMese1;
        private Label label84;
        private Label labCredito41;
        private Label labCredito31;
        private TextBox txtNuovoSaldo1;
        private Label label87;
        private Panel panel11;
        private Label label88;
        private Label label89;
        private TabControl tabControlCollegaAltriPagamenti;
        private TabPage tabPageAltri;
        private Label label91;
        private Button btnCollegaAltri;
        private DataGrid gridAltri;
        private TabPage tabPageAltriIntra;
        private Button btnCollegaAltriIntra;
        private DataGrid gridAltriIstituzionaleIntra;
        private TabPage tabPageAltriSplit;
        private Button btnCollegaAltriSplit;
        private DataGrid gridAltriIstituzionaleSplit;
        private Label lblcredito51;
        private Label lblcredito21;
        private Label lblcredito11;
        private TextBox txtIvaPeriodo1;
        private Label label95;
        private TextBox txtTotaleIva1;
        private Label lblSaldoCorr1;
        private TextBox txtSaldoPrec1;
        private Label label97;
        private Label label90;
        private Label label98;
        private Button btnSCollegaAltri;
        private Button btnSCollegaAltriIntra;
        private Button btnSCollegaAltriSplit;
        private DataTable AltriPagamentiIstituzionaleSplitPayment;

        public Frm_ivapay_wizard_calcolo() {
            InitializeComponent();
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            GetData.CacheTable(DS.ivapayperiodicity);
            GetData.CacheTable(DS.config);
            GetData.CacheTable(DS.incomephase);
            GetData.CacheTable(DS.expensephase);
            GetData.SetSorting(DS.incomeview, "ymov DESC,nmov DESC");
            GetData.SetSorting(DS.expenseview, "ymov DESC,nmov DESC");
            AltriPagamenti = new DataTable();
            AltriPagamentiIntraExtraUe = new DataTable();
            AltriPagamentiIstituzionaleSplitPayment = new DataTable();

            ImpostaColonneTabellaAltriPagamenti(AltriPagamenti);
            ImpostaColonneTabellaAltriPagamenti(AltriPagamentiIntraExtraUe);
            ImpostaColonneTabellaAltriPagamenti(AltriPagamentiIstituzionaleSplitPayment);
            AltriPagamenti.TableName = "AltriPagamenti";
            AltriPagamentiIntraExtraUe.TableName = "AltriPagamentiIntraExtraUe";
            AltriPagamentiIstituzionaleSplitPayment.TableName = "AltriPagamentiIstituzionaleSplitPayment";

            DataSet D = new DataSet();
            D.Tables.Add(AltriPagamenti);
            D.Tables.Add(AltriPagamentiIntraExtraUe);
            D.Tables.Add(AltriPagamentiIstituzionaleSplitPayment);

            HelpForm.SetDataGrid(gridAltri, AltriPagamenti);
            HelpForm.SetDataGrid(gridAltriIstituzionaleIntra, AltriPagamentiIntraExtraUe);
            HelpForm.SetDataGrid(gridAltriIstituzionaleSplit, AltriPagamentiIstituzionaleSplitPayment);
        }

        private void ImpostaColonneTabellaAltriPagamenti(DataTable T) {
            T.Columns.Clear();
            T.Columns.Add("idexp", typeof(int));
            T.Columns.Add("phase", typeof(string));
            T.Columns.Add("ymov", typeof(int));
            T.Columns.Add("nmov", typeof(int));
            T.Columns.Add("amount", typeof(decimal));
            T.Columns.Add("registry", typeof(string));
            T.Columns.Add("description", typeof(string));
            T.Columns.Add("upb", typeof(string));

            T.Columns["idexp"].Caption = ".#";
            T.Columns["phase"].Caption = "Fase";
            T.Columns["ymov"].Caption = "Eserc.";
            T.Columns["nmov"].Caption = "Numero";
            T.Columns["amount"].Caption = "Importo";
            T.Columns["registry"].Caption = "Creditore";
            T.Columns["description"].Caption = "Descrizione";
            T.Columns["upb"].Caption = "upb";

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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.DS = new ivapay_wizard_calcolo.vistaForm();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.label67 = new System.Windows.Forms.Label();
            this.txtLiquidMese__split = new System.Windows.Forms.TextBox();
            this.labCredito4__split = new System.Windows.Forms.Label();
            this.labCredito3__split = new System.Windows.Forms.Label();
            this.txtNuovoSaldo__split = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lblcredito5__split = new System.Windows.Forms.Label();
            this.lblcredito2__split = new System.Windows.Forms.Label();
            this.lblcredito1__split = new System.Windows.Forms.Label();
            this.txtIvaPeriodo__split = new System.Windows.Forms.TextBox();
            this.txtTotaleIva__split = new System.Windows.Forms.TextBox();
            this.txtSaldoPrec__split = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label77 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblcredito5__12 = new System.Windows.Forms.Label();
            this.lblcredito2__12 = new System.Windows.Forms.Label();
            this.lblcredito1__12 = new System.Windows.Forms.Label();
            this.txtLiquidMese12 = new System.Windows.Forms.TextBox();
            this.lab_credito4_12 = new System.Windows.Forms.Label();
            this.lab_credito3_12 = new System.Windows.Forms.Label();
            this.txtNuovoSaldo12 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lab_credito5_12 = new System.Windows.Forms.Label();
            this.lab_credito2_12 = new System.Windows.Forms.Label();
            this.lab_credito1_12 = new System.Windows.Forms.Label();
            this.txtIvaPeriodo12 = new System.Windows.Forms.TextBox();
            this.txtTotaleIva12 = new System.Windows.Forms.TextBox();
            this.txtSaldoPrec12 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtLiquidMese = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.labCredito4 = new System.Windows.Forms.Label();
            this.labCredito3 = new System.Windows.Forms.Label();
            this.txtNuovoSaldo = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnCambiaUPBEntrata = new System.Windows.Forms.Button();
            this.gridEntrata = new System.Windows.Forms.DataGrid();
            this.btnScollegaE = new System.Windows.Forms.Button();
            this.btnCollegaE = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnCambiaUPBSpesa = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.gridSpesa = new System.Windows.Forms.DataGrid();
            this.btnScollegaS = new System.Windows.Forms.Button();
            this.btnCollegaS = new System.Windows.Forms.Button();
            this.lblcredito5 = new System.Windows.Forms.Label();
            this.lblcredito2 = new System.Windows.Forms.Label();
            this.lblcredito1 = new System.Windows.Forms.Label();
            this.txtIvaPeriodo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotaleIva = new System.Windows.Forms.TextBox();
            this.lblSaldoCorr = new System.Windows.Forms.Label();
            this.txtSaldoPrec = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabpage1 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.chkIstituzionaleSplit = new System.Windows.Forms.CheckBox();
            this.chkIstituzionale = new System.Windows.Forms.CheckBox();
            this.chkCommerciale = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.txtDataRegolamento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblEndOfYear = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPromiscuo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProrata = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEndOfYear = new System.Windows.Forms.CheckBox();
            this.txtPeriodicita = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAl = new System.Windows.Forms.TextBox();
            this.txtDal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.txtTotIvaIstituzionaleSplit = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.txtTotIvaIstituzIntrastat = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIvaCredito = new System.Windows.Forms.TextBox();
            this.labTotDopoProrata = new System.Windows.Forms.Label();
            this.txtIvaCreditoProrata = new System.Windows.Forms.TextBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.lblMessaggi = new System.Windows.Forms.Label();
            this.gridDebito = new System.Windows.Forms.DataGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIvaDebitoImmediata = new System.Windows.Forms.TextBox();
            this.txtIvaDebitoDifferita = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtIndetraibileDifferita = new System.Windows.Forms.TextBox();
            this.txtIvaCreditoTotaleDifferita = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtIvaCreditoDifferita = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIndetraibileImmediata = new System.Windows.Forms.TextBox();
            this.txtIvaCreditoTotaleImmediata = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtIvaCreditoImmediata = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.gridAcquisti = new System.Windows.Forms.DataGrid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIvaCreditoTotaleCommerciale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtIndetraibileImmediataPromiscui = new System.Windows.Forms.TextBox();
            this.txtIvaCreditoTotaleImmediataPromiscui = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtIvaCreditoImmediataPromiscui = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.gridacquistipromiscui = new System.Windows.Forms.DataGrid();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtIvaCreditoTotalePromiscuiPOST = new System.Windows.Forms.TextBox();
            this.labTotIvaPromPOST = new System.Windows.Forms.Label();
            this.txtIvaCreditoTotalePromiscui = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtIndetraibileDifferitaPromiscui = new System.Windows.Forms.TextBox();
            this.txtIvaCreditoTotaleDifferitaPromiscui = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtIvaCreditoDifferitaPromiscui = new System.Windows.Forms.TextBox();
            this.tabIntra12 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtIvaIstituzDeferr = new System.Windows.Forms.TextBox();
            this.txtImpIstituzDeferr = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtIvaIstituzImmed = new System.Windows.Forms.TextBox();
            this.txtImpIstituzImmed = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.gridacquistiistituzionaliINTRA = new System.Windows.Forms.DataGrid();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.txtTotIvaIstituz = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtTotImpIstituz = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtIvaIstituzDeferrSplit = new System.Windows.Forms.TextBox();
            this.txtImpIstituzDeferrSplit = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtIvaIstituzImmedSplit = new System.Windows.Forms.TextBox();
            this.txtImpIstituzImmedSplit = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.gridacquistiistituzionaliSplit = new System.Windows.Forms.DataGrid();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.txtTotIvaIstituzSplit = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtTotImpIstituzSplit = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtIvaDebito = new System.Windows.Forms.TextBox();
            this.tabPage13 = new Crownwood.Magic.Controls.TabPage();
            this.label49 = new System.Windows.Forms.Label();
            this.txtLiquidMese__split1 = new System.Windows.Forms.TextBox();
            this.labCredito4__split1 = new System.Windows.Forms.Label();
            this.labCredito3__split1 = new System.Windows.Forms.Label();
            this.txtNuovoSaldo__split1 = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lblcredito5__split1 = new System.Windows.Forms.Label();
            this.lblcredito2__split1 = new System.Windows.Forms.Label();
            this.lblcredito1__split1 = new System.Windows.Forms.Label();
            this.txtIvaPeriodo__split1 = new System.Windows.Forms.TextBox();
            this.txtTotaleIva__split1 = new System.Windows.Forms.TextBox();
            this.txtSaldoPrec__split1 = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblcredito5__121 = new System.Windows.Forms.Label();
            this.lblcredito2__121 = new System.Windows.Forms.Label();
            this.lblcredito1__121 = new System.Windows.Forms.Label();
            this.txtLiquidMese121 = new System.Windows.Forms.TextBox();
            this.lab_credito4_121 = new System.Windows.Forms.Label();
            this.lab_credito3_121 = new System.Windows.Forms.Label();
            this.txtNuovoSaldo121 = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label76 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.txtIvaPeriodo121 = new System.Windows.Forms.TextBox();
            this.txtTotaleIva121 = new System.Windows.Forms.TextBox();
            this.txtSaldoPrec121 = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.txtLiquidMese1 = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.labCredito41 = new System.Windows.Forms.Label();
            this.labCredito31 = new System.Windows.Forms.Label();
            this.txtNuovoSaldo1 = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label88 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.tabControlCollegaAltriPagamenti = new System.Windows.Forms.TabControl();
            this.tabPageAltri = new System.Windows.Forms.TabPage();
            this.btnSCollegaAltri = new System.Windows.Forms.Button();
            this.label91 = new System.Windows.Forms.Label();
            this.btnCollegaAltri = new System.Windows.Forms.Button();
            this.gridAltri = new System.Windows.Forms.DataGrid();
            this.tabPageAltriIntra = new System.Windows.Forms.TabPage();
            this.btnSCollegaAltriIntra = new System.Windows.Forms.Button();
            this.label90 = new System.Windows.Forms.Label();
            this.btnCollegaAltriIntra = new System.Windows.Forms.Button();
            this.gridAltriIstituzionaleIntra = new System.Windows.Forms.DataGrid();
            this.tabPageAltriSplit = new System.Windows.Forms.TabPage();
            this.btnSCollegaAltriSplit = new System.Windows.Forms.Button();
            this.label98 = new System.Windows.Forms.Label();
            this.btnCollegaAltriSplit = new System.Windows.Forms.Button();
            this.gridAltriIstituzionaleSplit = new System.Windows.Forms.DataGrid();
            this.lblcredito51 = new System.Windows.Forms.Label();
            this.lblcredito21 = new System.Windows.Forms.Label();
            this.lblcredito11 = new System.Windows.Forms.Label();
            this.txtIvaPeriodo1 = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.txtTotaleIva1 = new System.Windows.Forms.TextBox();
            this.lblSaldoCorr1 = new System.Windows.Forms.Label();
            this.txtSaldoPrec1 = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabController.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
            this.tabpage1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDebito)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAcquisti)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistipromiscui)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabIntra12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliINTRA)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliSplit)).BeginInit();
            this.groupBox18.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabControlCollegaAltriPagamenti.SuspendLayout();
            this.tabPageAltri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAltri)).BeginInit();
            this.tabPageAltriIntra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAltriIstituzionaleIntra)).BeginInit();
            this.tabPageAltriSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAltriIstituzionaleSplit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(873, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Annulla";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(769, 544);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(689, 544);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabpage1;
            this.tabController.Size = new System.Drawing.Size(938, 509);
            this.tabController.TabIndex = 14;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabpage1,
            this.tabPage2,
            this.tabPage13,
            this.tabPage3});
            this.tabController.SelectionChanged += new System.EventHandler(this.tabController_SelectionChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label67);
            this.tabPage3.Controls.Add(this.txtLiquidMese__split);
            this.tabPage3.Controls.Add(this.labCredito4__split);
            this.tabPage3.Controls.Add(this.labCredito3__split);
            this.tabPage3.Controls.Add(this.txtNuovoSaldo__split);
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.label70);
            this.tabPage3.Controls.Add(this.label71);
            this.tabPage3.Controls.Add(this.lblcredito5__split);
            this.tabPage3.Controls.Add(this.lblcredito2__split);
            this.tabPage3.Controls.Add(this.lblcredito1__split);
            this.tabPage3.Controls.Add(this.txtIvaPeriodo__split);
            this.tabPage3.Controls.Add(this.txtTotaleIva__split);
            this.tabPage3.Controls.Add(this.txtSaldoPrec__split);
            this.tabPage3.Controls.Add(this.panel6);
            this.tabPage3.Controls.Add(this.label77);
            this.tabPage3.Controls.Add(this.label78);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.lblcredito5__12);
            this.tabPage3.Controls.Add(this.lblcredito2__12);
            this.tabPage3.Controls.Add(this.lblcredito1__12);
            this.tabPage3.Controls.Add(this.txtLiquidMese12);
            this.tabPage3.Controls.Add(this.lab_credito4_12);
            this.tabPage3.Controls.Add(this.lab_credito3_12);
            this.tabPage3.Controls.Add(this.txtNuovoSaldo12);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.label50);
            this.tabPage3.Controls.Add(this.label51);
            this.tabPage3.Controls.Add(this.lab_credito5_12);
            this.tabPage3.Controls.Add(this.lab_credito2_12);
            this.tabPage3.Controls.Add(this.lab_credito1_12);
            this.tabPage3.Controls.Add(this.txtIvaPeriodo12);
            this.tabPage3.Controls.Add(this.txtTotaleIva12);
            this.tabPage3.Controls.Add(this.txtSaldoPrec12);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.txtLiquidMese);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.labCredito4);
            this.tabPage3.Controls.Add(this.labCredito3);
            this.tabPage3.Controls.Add(this.txtNuovoSaldo);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.label25);
            this.tabPage3.Controls.Add(this.label26);
            this.tabPage3.Controls.Add(this.tabControl);
            this.tabPage3.Controls.Add(this.lblcredito5);
            this.tabPage3.Controls.Add(this.lblcredito2);
            this.tabPage3.Controls.Add(this.lblcredito1);
            this.tabPage3.Controls.Add(this.txtIvaPeriodo);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.txtTotaleIva);
            this.tabPage3.Controls.Add(this.lblSaldoCorr);
            this.tabPage3.Controls.Add(this.txtSaldoPrec);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(938, 484);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Pagina 4 di 4";
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label67.AutoSize = true;
            this.label67.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.Location = new System.Drawing.Point(669, 309);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(160, 13);
            this.label67.TabIndex = 91;
            this.label67.Text = "Istituzionale Split Payment";
            // 
            // txtLiquidMese__split
            // 
            this.txtLiquidMese__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese__split.Location = new System.Drawing.Point(681, 426);
            this.txtLiquidMese__split.Name = "txtLiquidMese__split";
            this.txtLiquidMese__split.ReadOnly = true;
            this.txtLiquidMese__split.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese__split.TabIndex = 90;
            this.txtLiquidMese__split.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labCredito4__split
            // 
            this.labCredito4__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito4__split.Location = new System.Drawing.Point(784, 431);
            this.labCredito4__split.Name = "labCredito4__split";
            this.labCredito4__split.Size = new System.Drawing.Size(72, 16);
            this.labCredito4__split.TabIndex = 89;
            this.labCredito4__split.Text = "a debito";
            // 
            // labCredito3__split
            // 
            this.labCredito3__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito3__split.Location = new System.Drawing.Point(784, 392);
            this.labCredito3__split.Name = "labCredito3__split";
            this.labCredito3__split.Size = new System.Drawing.Size(72, 16);
            this.labCredito3__split.TabIndex = 88;
            this.labCredito3__split.Text = "a debito";
            // 
            // txtNuovoSaldo__split
            // 
            this.txtNuovoSaldo__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo__split.Location = new System.Drawing.Point(681, 453);
            this.txtNuovoSaldo__split.Name = "txtNuovoSaldo__split";
            this.txtNuovoSaldo__split.ReadOnly = true;
            this.txtNuovoSaldo__split.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo__split.TabIndex = 87;
            this.txtNuovoSaldo__split.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(672, 381);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 2);
            this.panel5.TabIndex = 86;
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label70.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(861, 358);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(16, 16);
            this.label70.TabIndex = 85;
            this.label70.Text = "=";
            // 
            // label71
            // 
            this.label71.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(861, 337);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(16, 16);
            this.label71.TabIndex = 84;
            this.label71.Text = "+";
            // 
            // lblcredito5__split
            // 
            this.lblcredito5__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito5__split.Location = new System.Drawing.Point(784, 457);
            this.lblcredito5__split.Name = "lblcredito5__split";
            this.lblcredito5__split.Size = new System.Drawing.Size(72, 16);
            this.lblcredito5__split.TabIndex = 83;
            // 
            // lblcredito2__split
            // 
            this.lblcredito2__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito2__split.Location = new System.Drawing.Point(784, 358);
            this.lblcredito2__split.Name = "lblcredito2__split";
            this.lblcredito2__split.Size = new System.Drawing.Size(72, 16);
            this.lblcredito2__split.TabIndex = 82;
            // 
            // lblcredito1__split
            // 
            this.lblcredito1__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito1__split.Location = new System.Drawing.Point(784, 335);
            this.lblcredito1__split.Name = "lblcredito1__split";
            this.lblcredito1__split.Size = new System.Drawing.Size(72, 16);
            this.lblcredito1__split.TabIndex = 81;
            // 
            // txtIvaPeriodo__split
            // 
            this.txtIvaPeriodo__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo__split.Location = new System.Drawing.Point(681, 355);
            this.txtIvaPeriodo__split.Name = "txtIvaPeriodo__split";
            this.txtIvaPeriodo__split.ReadOnly = true;
            this.txtIvaPeriodo__split.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo__split.TabIndex = 80;
            this.txtIvaPeriodo__split.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleIva__split
            // 
            this.txtTotaleIva__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva__split.Location = new System.Drawing.Point(681, 386);
            this.txtTotaleIva__split.Name = "txtTotaleIva__split";
            this.txtTotaleIva__split.ReadOnly = true;
            this.txtTotaleIva__split.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva__split.TabIndex = 79;
            this.txtTotaleIva__split.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoPrec__split
            // 
            this.txtSaldoPrec__split.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec__split.Location = new System.Drawing.Point(681, 330);
            this.txtSaldoPrec__split.Name = "txtSaldoPrec__split";
            this.txtSaldoPrec__split.ReadOnly = true;
            this.txtSaldoPrec__split.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec__split.TabIndex = 78;
            this.txtSaldoPrec__split.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(672, 380);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 2);
            this.panel6.TabIndex = 73;
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.Location = new System.Drawing.Point(861, 357);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(16, 16);
            this.label77.TabIndex = 72;
            this.label77.Text = "=";
            // 
            // label78
            // 
            this.label78.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.Location = new System.Drawing.Point(861, 336);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(16, 16);
            this.label78.TabIndex = 71;
            this.label78.Text = "+";
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(398, 309);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(178, 13);
            this.label46.TabIndex = 64;
            this.label46.Text = "Istituzionale INTRA e Extra-UE";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(401, 381);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 2);
            this.panel4.TabIndex = 59;
            // 
            // lblcredito5__12
            // 
            this.lblcredito5__12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito5__12.Location = new System.Drawing.Point(511, 458);
            this.lblcredito5__12.Name = "lblcredito5__12";
            this.lblcredito5__12.Size = new System.Drawing.Size(72, 16);
            this.lblcredito5__12.TabIndex = 56;
            // 
            // lblcredito2__12
            // 
            this.lblcredito2__12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito2__12.Location = new System.Drawing.Point(512, 357);
            this.lblcredito2__12.Name = "lblcredito2__12";
            this.lblcredito2__12.Size = new System.Drawing.Size(72, 16);
            this.lblcredito2__12.TabIndex = 55;
            // 
            // lblcredito1__12
            // 
            this.lblcredito1__12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito1__12.Location = new System.Drawing.Point(512, 334);
            this.lblcredito1__12.Name = "lblcredito1__12";
            this.lblcredito1__12.Size = new System.Drawing.Size(72, 16);
            this.lblcredito1__12.TabIndex = 54;
            // 
            // txtLiquidMese12
            // 
            this.txtLiquidMese12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese12.Location = new System.Drawing.Point(410, 426);
            this.txtLiquidMese12.Name = "txtLiquidMese12";
            this.txtLiquidMese12.ReadOnly = true;
            this.txtLiquidMese12.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese12.TabIndex = 48;
            this.txtLiquidMese12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lab_credito4_12
            // 
            this.lab_credito4_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito4_12.Location = new System.Drawing.Point(511, 431);
            this.lab_credito4_12.Name = "lab_credito4_12";
            this.lab_credito4_12.Size = new System.Drawing.Size(72, 16);
            this.lab_credito4_12.TabIndex = 46;
            this.lab_credito4_12.Text = "a debito";
            // 
            // lab_credito3_12
            // 
            this.lab_credito3_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito3_12.Location = new System.Drawing.Point(511, 392);
            this.lab_credito3_12.Name = "lab_credito3_12";
            this.lab_credito3_12.Size = new System.Drawing.Size(72, 16);
            this.lab_credito3_12.TabIndex = 45;
            this.lab_credito3_12.Text = "a debito";
            // 
            // txtNuovoSaldo12
            // 
            this.txtNuovoSaldo12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo12.Location = new System.Drawing.Point(409, 454);
            this.txtNuovoSaldo12.Name = "txtNuovoSaldo12";
            this.txtNuovoSaldo12.ReadOnly = true;
            this.txtNuovoSaldo12.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo12.TabIndex = 44;
            this.txtNuovoSaldo12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(401, 380);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 2);
            this.panel3.TabIndex = 42;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(590, 357);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(16, 16);
            this.label50.TabIndex = 41;
            this.label50.Text = "=";
            // 
            // label51
            // 
            this.label51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(590, 336);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(16, 16);
            this.label51.TabIndex = 40;
            this.label51.Text = "+";
            // 
            // lab_credito5_12
            // 
            this.lab_credito5_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito5_12.Location = new System.Drawing.Point(511, 457);
            this.lab_credito5_12.Name = "lab_credito5_12";
            this.lab_credito5_12.Size = new System.Drawing.Size(72, 16);
            this.lab_credito5_12.TabIndex = 39;
            // 
            // lab_credito2_12
            // 
            this.lab_credito2_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito2_12.Location = new System.Drawing.Point(513, 355);
            this.lab_credito2_12.Name = "lab_credito2_12";
            this.lab_credito2_12.Size = new System.Drawing.Size(72, 16);
            this.lab_credito2_12.TabIndex = 38;
            // 
            // lab_credito1_12
            // 
            this.lab_credito1_12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito1_12.Location = new System.Drawing.Point(513, 332);
            this.lab_credito1_12.Name = "lab_credito1_12";
            this.lab_credito1_12.Size = new System.Drawing.Size(72, 16);
            this.lab_credito1_12.TabIndex = 37;
            // 
            // txtIvaPeriodo12
            // 
            this.txtIvaPeriodo12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo12.Location = new System.Drawing.Point(411, 353);
            this.txtIvaPeriodo12.Name = "txtIvaPeriodo12";
            this.txtIvaPeriodo12.ReadOnly = true;
            this.txtIvaPeriodo12.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo12.TabIndex = 36;
            this.txtIvaPeriodo12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleIva12
            // 
            this.txtTotaleIva12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva12.Location = new System.Drawing.Point(409, 385);
            this.txtTotaleIva12.Name = "txtTotaleIva12";
            this.txtTotaleIva12.ReadOnly = true;
            this.txtTotaleIva12.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva12.TabIndex = 34;
            this.txtTotaleIva12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoPrec12
            // 
            this.txtSaldoPrec12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec12.Location = new System.Drawing.Point(411, 326);
            this.txtSaldoPrec12.Name = "txtSaldoPrec12";
            this.txtSaldoPrec12.ReadOnly = true;
            this.txtSaldoPrec12.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec12.TabIndex = 32;
            this.txtSaldoPrec12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(154, 309);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(97, 13);
            this.label45.TabIndex = 20;
            this.label45.Text = "Liquidazione iva";
            // 
            // txtLiquidMese
            // 
            this.txtLiquidMese.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese.Location = new System.Drawing.Point(155, 424);
            this.txtLiquidMese.Name = "txtLiquidMese";
            this.txtLiquidMese.ReadOnly = true;
            this.txtLiquidMese.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese.TabIndex = 30;
            this.txtLiquidMese.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(24, 428);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(124, 15);
            this.label37.TabIndex = 29;
            this.label37.Text = "Liquidazione del mese";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCredito4
            // 
            this.labCredito4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito4.Location = new System.Drawing.Point(263, 431);
            this.labCredito4.Name = "labCredito4";
            this.labCredito4.Size = new System.Drawing.Size(72, 16);
            this.labCredito4.TabIndex = 28;
            this.labCredito4.Text = "a debito";
            // 
            // labCredito3
            // 
            this.labCredito3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito3.Location = new System.Drawing.Point(263, 388);
            this.labCredito3.Name = "labCredito3";
            this.labCredito3.Size = new System.Drawing.Size(62, 16);
            this.labCredito3.TabIndex = 27;
            this.labCredito3.Text = "a debito";
            // 
            // txtNuovoSaldo
            // 
            this.txtNuovoSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo.Location = new System.Drawing.Point(155, 450);
            this.txtNuovoSaldo.Name = "txtNuovoSaldo";
            this.txtNuovoSaldo.ReadOnly = true;
            this.txtNuovoSaldo.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo.TabIndex = 26;
            this.txtNuovoSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label36.Location = new System.Drawing.Point(36, 455);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(112, 16);
            this.label36.TabIndex = 25;
            this.label36.Text = "Nuovo saldo";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(39, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 2);
            this.panel2.TabIndex = 24;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(337, 354);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 16);
            this.label25.TabIndex = 23;
            this.label25.Text = "=";
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(337, 333);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 16);
            this.label26.TabIndex = 22;
            this.label26.Text = "+";
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Location = new System.Drawing.Point(4, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(906, 299);
            this.tabControl.TabIndex = 17;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnCambiaUPBEntrata);
            this.tabPage4.Controls.Add(this.gridEntrata);
            this.tabPage4.Controls.Add(this.btnScollegaE);
            this.tabPage4.Controls.Add(this.btnCollegaE);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(898, 271);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Movimenti di entrata";
            // 
            // btnCambiaUPBEntrata
            // 
            this.btnCambiaUPBEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambiaUPBEntrata.Location = new System.Drawing.Point(546, 239);
            this.btnCambiaUPBEntrata.Name = "btnCambiaUPBEntrata";
            this.btnCambiaUPBEntrata.Size = new System.Drawing.Size(176, 23);
            this.btnCambiaUPBEntrata.TabIndex = 20;
            this.btnCambiaUPBEntrata.Text = "Cambia UPB";
            this.btnCambiaUPBEntrata.Click += new System.EventHandler(this.btnCambiaUPB_Click);
            // 
            // gridEntrata
            // 
            this.gridEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridEntrata.CaptionVisible = false;
            this.gridEntrata.DataMember = "";
            this.gridEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridEntrata.Location = new System.Drawing.Point(8, 24);
            this.gridEntrata.Name = "gridEntrata";
            this.gridEntrata.Size = new System.Drawing.Size(882, 204);
            this.gridEntrata.TabIndex = 19;
            // 
            // btnScollegaE
            // 
            this.btnScollegaE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaE.Location = new System.Drawing.Point(202, 239);
            this.btnScollegaE.Name = "btnScollegaE";
            this.btnScollegaE.Size = new System.Drawing.Size(176, 23);
            this.btnScollegaE.TabIndex = 18;
            this.btnScollegaE.Text = "Annulla il collegamento";
            this.btnScollegaE.Click += new System.EventHandler(this.btnScollegaE_Click);
            // 
            // btnCollegaE
            // 
            this.btnCollegaE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaE.Location = new System.Drawing.Point(18, 239);
            this.btnCollegaE.Name = "btnCollegaE";
            this.btnCollegaE.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaE.TabIndex = 17;
            this.btnCollegaE.Text = "Collega a movimento esistente";
            this.btnCollegaE.Click += new System.EventHandler(this.btnCollegaE_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(882, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Premendo il pulsante Fine saranno associati o creati i seguenti movimenti di entr" +
    "ata";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnCambiaUPBSpesa);
            this.tabPage5.Controls.Add(this.label24);
            this.tabPage5.Controls.Add(this.gridSpesa);
            this.tabPage5.Controls.Add(this.btnScollegaS);
            this.tabPage5.Controls.Add(this.btnCollegaS);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(898, 271);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Movimenti di spesa";
            // 
            // btnCambiaUPBSpesa
            // 
            this.btnCambiaUPBSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCambiaUPBSpesa.Location = new System.Drawing.Point(546, 239);
            this.btnCambiaUPBSpesa.Name = "btnCambiaUPBSpesa";
            this.btnCambiaUPBSpesa.Size = new System.Drawing.Size(176, 23);
            this.btnCambiaUPBSpesa.TabIndex = 23;
            this.btnCambiaUPBSpesa.Text = "Cambia UPB";
            this.btnCambiaUPBSpesa.Click += new System.EventHandler(this.btnCambiaUPBSpesa_Click);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Location = new System.Drawing.Point(8, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(882, 16);
            this.label24.TabIndex = 22;
            this.label24.Text = "Premendo il pulsante Fine saranno associati o creati i seguenti movimenti di spes" +
    "a";
            // 
            // gridSpesa
            // 
            this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpesa.CaptionVisible = false;
            this.gridSpesa.DataMember = "";
            this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSpesa.Location = new System.Drawing.Point(8, 24);
            this.gridSpesa.Name = "gridSpesa";
            this.gridSpesa.Size = new System.Drawing.Size(882, 204);
            this.gridSpesa.TabIndex = 21;
            // 
            // btnScollegaS
            // 
            this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaS.Location = new System.Drawing.Point(202, 239);
            this.btnScollegaS.Name = "btnScollegaS";
            this.btnScollegaS.Size = new System.Drawing.Size(176, 23);
            this.btnScollegaS.TabIndex = 20;
            this.btnScollegaS.Text = "Annulla il collegamento";
            this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
            // 
            // btnCollegaS
            // 
            this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaS.Location = new System.Drawing.Point(18, 239);
            this.btnCollegaS.Name = "btnCollegaS";
            this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaS.TabIndex = 19;
            this.btnCollegaS.Text = "Collega a movimento esistente";
            this.btnCollegaS.Click += new System.EventHandler(this.btnCollegaS_Click);
            // 
            // lblcredito5
            // 
            this.lblcredito5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito5.Location = new System.Drawing.Point(263, 459);
            this.lblcredito5.Name = "lblcredito5";
            this.lblcredito5.Size = new System.Drawing.Size(72, 16);
            this.lblcredito5.TabIndex = 14;
            // 
            // lblcredito2
            // 
            this.lblcredito2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito2.Location = new System.Drawing.Point(263, 355);
            this.lblcredito2.Name = "lblcredito2";
            this.lblcredito2.Size = new System.Drawing.Size(72, 16);
            this.lblcredito2.TabIndex = 13;
            // 
            // lblcredito1
            // 
            this.lblcredito1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito1.Location = new System.Drawing.Point(263, 332);
            this.lblcredito1.Name = "lblcredito1";
            this.lblcredito1.Size = new System.Drawing.Size(72, 16);
            this.lblcredito1.TabIndex = 12;
            // 
            // txtIvaPeriodo
            // 
            this.txtIvaPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo.Location = new System.Drawing.Point(154, 351);
            this.txtIvaPeriodo.Name = "txtIvaPeriodo";
            this.txtIvaPeriodo.ReadOnly = true;
            this.txtIvaPeriodo.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo.TabIndex = 11;
            this.txtIvaPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.Location = new System.Drawing.Point(36, 355);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 16);
            this.label14.TabIndex = 10;
            this.label14.Text = "Iva del periodo";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotaleIva
            // 
            this.txtTotaleIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva.Location = new System.Drawing.Point(154, 385);
            this.txtTotaleIva.Name = "txtTotaleIva";
            this.txtTotaleIva.ReadOnly = true;
            this.txtTotaleIva.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva.TabIndex = 9;
            this.txtTotaleIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoCorr
            // 
            this.lblSaldoCorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldoCorr.Location = new System.Drawing.Point(36, 392);
            this.lblSaldoCorr.Name = "lblSaldoCorr";
            this.lblSaldoCorr.Size = new System.Drawing.Size(112, 16);
            this.lblSaldoCorr.TabIndex = 8;
            this.lblSaldoCorr.Text = "Totale iva";
            this.lblSaldoCorr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaldoPrec
            // 
            this.txtSaldoPrec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec.Location = new System.Drawing.Point(154, 327);
            this.txtSaldoPrec.Name = "txtSaldoPrec";
            this.txtSaldoPrec.ReadOnly = true;
            this.txtSaldoPrec.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec.TabIndex = 7;
            this.txtSaldoPrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(36, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Saldo precedente";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabpage1
            // 
            this.tabpage1.Controls.Add(this.groupBox15);
            this.tabpage1.Controls.Add(this.groupBox14);
            this.tabpage1.Controls.Add(this.label10);
            this.tabpage1.Controls.Add(this.lblEndOfYear);
            this.tabpage1.Controls.Add(this.label23);
            this.tabpage1.Controls.Add(this.groupBox3);
            this.tabpage1.Controls.Add(this.groupBox2);
            this.tabpage1.Controls.Add(this.groupBox1);
            this.tabpage1.Controls.Add(this.label6);
            this.tabpage1.Controls.Add(this.label1);
            this.tabpage1.Location = new System.Drawing.Point(0, 0);
            this.tabpage1.Name = "tabpage1";
            this.tabpage1.Size = new System.Drawing.Size(938, 484);
            this.tabpage1.TabIndex = 0;
            this.tabpage1.Tag = "tabella.campo.fixed.2..%.100";
            this.tabpage1.Title = "Pagina 1 di 4";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.chkIstituzionaleSplit);
            this.groupBox15.Controls.Add(this.chkIstituzionale);
            this.groupBox15.Controls.Add(this.chkCommerciale);
            this.groupBox15.Location = new System.Drawing.Point(8, 118);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(922, 56);
            this.groupBox15.TabIndex = 22;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Tipo Liquidazione";
            // 
            // chkIstituzionaleSplit
            // 
            this.chkIstituzionaleSplit.Location = new System.Drawing.Point(440, 18);
            this.chkIstituzionaleSplit.Name = "chkIstituzionaleSplit";
            this.chkIstituzionaleSplit.Size = new System.Drawing.Size(186, 19);
            this.chkIstituzionaleSplit.TabIndex = 24;
            this.chkIstituzionaleSplit.Text = "Iva Istituzionale Split Payment";
            this.chkIstituzionaleSplit.UseVisualStyleBackColor = true;
            // 
            // chkIstituzionale
            // 
            this.chkIstituzionale.Location = new System.Drawing.Point(239, 18);
            this.chkIstituzionale.Name = "chkIstituzionale";
            this.chkIstituzionale.Size = new System.Drawing.Size(186, 19);
            this.chkIstituzionale.TabIndex = 23;
            this.chkIstituzionale.Text = "Iva Istituzionale INTRA12";
            this.chkIstituzionale.UseVisualStyleBackColor = true;
            // 
            // chkCommerciale
            // 
            this.chkCommerciale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCommerciale.Location = new System.Drawing.Point(9, 17);
            this.chkCommerciale.Name = "chkCommerciale";
            this.chkCommerciale.Size = new System.Drawing.Size(386, 19);
            this.chkCommerciale.TabIndex = 22;
            this.chkCommerciale.Tag = "";
            this.chkCommerciale.Text = "Iva Commerciale e Promiscua";
            this.chkCommerciale.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.txtDataRegolamento);
            this.groupBox14.Location = new System.Drawing.Point(8, 405);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(754, 62);
            this.groupBox14.TabIndex = 19;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Data di Regolamento";
            // 
            // txtDataRegolamento
            // 
            this.txtDataRegolamento.Location = new System.Drawing.Point(13, 24);
            this.txtDataRegolamento.Name = "txtDataRegolamento";
            this.txtDataRegolamento.Size = new System.Drawing.Size(72, 23);
            this.txtDataRegolamento.TabIndex = 6;
            this.txtDataRegolamento.Leave += new System.EventHandler(this.txtDataRegolamento_Leave);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(914, 22);
            this.label10.TabIndex = 18;
            this.label10.Text = "Tuttavia nel mese di dicembre, per chi lo desidera, sarà possibile anche liquidar" +
    "e il periodo corrente fino alla fine dell\'anno.";
            // 
            // lblEndOfYear
            // 
            this.lblEndOfYear.Location = new System.Drawing.Point(16, 70);
            this.lblEndOfYear.Name = "lblEndOfYear";
            this.lblEndOfYear.Size = new System.Drawing.Size(914, 22);
            this.lblEndOfYear.TabIndex = 17;
            this.lblEndOfYear.Text = "In base alla periodicità configurata il periodo da liquidare è quello precedente " +
    "al mese corrente.";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(661, 23);
            this.label23.TabIndex = 16;
            this.label23.Text = "PROCEDURA GUIDATA PER IL CALCOLO DELLA LIQUIDAZIONE IVA PERIODICA";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtPromiscuo);
            this.groupBox3.Location = new System.Drawing.Point(8, 330);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(922, 64);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gestione Promiscuo";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(397, 18);
            this.label13.TabIndex = 10;
            this.label13.Text = "Percentuale di promiscuo ";
            // 
            // txtPromiscuo
            // 
            this.txtPromiscuo.Location = new System.Drawing.Point(6, 38);
            this.txtPromiscuo.Name = "txtPromiscuo";
            this.txtPromiscuo.ReadOnly = true;
            this.txtPromiscuo.Size = new System.Drawing.Size(90, 23);
            this.txtPromiscuo.TabIndex = 11;
            this.txtPromiscuo.Tag = "";
            this.txtPromiscuo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtProrata);
            this.groupBox2.Location = new System.Drawing.Point(8, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(922, 67);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestione Pro Rata";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(485, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Percentuale di pro rata ";
            // 
            // txtProrata
            // 
            this.txtProrata.Location = new System.Drawing.Point(8, 38);
            this.txtProrata.Name = "txtProrata";
            this.txtProrata.ReadOnly = true;
            this.txtProrata.Size = new System.Drawing.Size(88, 23);
            this.txtProrata.TabIndex = 8;
            this.txtProrata.Tag = "";
            this.txtProrata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEndOfYear);
            this.groupBox1.Controls.Add(this.txtPeriodicita);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAl);
            this.groupBox1.Controls.Add(this.txtDal);
            this.groupBox1.Location = new System.Drawing.Point(8, 176);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 48);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Periodicità";
            // 
            // chkEndOfYear
            // 
            this.chkEndOfYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEndOfYear.Location = new System.Drawing.Point(440, 16);
            this.chkEndOfYear.Name = "chkEndOfYear";
            this.chkEndOfYear.Size = new System.Drawing.Size(476, 28);
            this.chkEndOfYear.TabIndex = 7;
            this.chkEndOfYear.Text = "Periodo corrente fino al 31 dicembre dell\'anno ";
            this.chkEndOfYear.UseVisualStyleBackColor = true;
            this.chkEndOfYear.CheckedChanged += new System.EventHandler(this.chkEndOfYear_CheckedChanged);
            // 
            // txtPeriodicita
            // 
            this.txtPeriodicita.Location = new System.Drawing.Point(8, 16);
            this.txtPeriodicita.Name = "txtPeriodicita";
            this.txtPeriodicita.ReadOnly = true;
            this.txtPeriodicita.Size = new System.Drawing.Size(181, 23);
            this.txtPeriodicita.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(322, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "al";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(198, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "dal";
            // 
            // txtAl
            // 
            this.txtAl.Location = new System.Drawing.Point(353, 16);
            this.txtAl.Name = "txtAl";
            this.txtAl.ReadOnly = true;
            this.txtAl.Size = new System.Drawing.Size(72, 23);
            this.txtAl.TabIndex = 6;
            // 
            // txtDal
            // 
            this.txtDal.Location = new System.Drawing.Point(237, 16);
            this.txtDal.Name = "txtDal";
            this.txtDal.ReadOnly = true;
            this.txtDal.Size = new System.Drawing.Size(72, 23);
            this.txtDal.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(914, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Per proseguire, inserire le percentuali di prorata e promiscuo e cliccare su Avan" +
    "ti";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(914, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Questa procedura vi aiuterà a calcolare rapidamente l\'ammontare dell\'Iva a credit" +
    "o e dell\'Iva a debito e a generare i movimenti finanziari collegati alla liquida" +
    "zione";
            // 
            // tabPage2
            // 
            this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage2.Controls.Add(this.txtTotIvaIstituzionaleSplit);
            this.tabPage2.Controls.Add(this.label61);
            this.tabPage2.Controls.Add(this.txtTotIvaIstituzIntrastat);
            this.tabPage2.Controls.Add(this.label43);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtIvaCredito);
            this.tabPage2.Controls.Add(this.labTotDopoProrata);
            this.tabPage2.Controls.Add(this.txtIvaCreditoProrata);
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.txtIvaDebito);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(938, 484);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Title = "Pagina 2 di 4";
            this.tabPage2.Visible = false;
            // 
            // txtTotIvaIstituzionaleSplit
            // 
            this.txtTotIvaIstituzionaleSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotIvaIstituzionaleSplit.Location = new System.Drawing.Point(498, 454);
            this.txtTotIvaIstituzionaleSplit.Name = "txtTotIvaIstituzionaleSplit";
            this.txtTotIvaIstituzionaleSplit.ReadOnly = true;
            this.txtTotIvaIstituzionaleSplit.Size = new System.Drawing.Size(96, 23);
            this.txtTotIvaIstituzionaleSplit.TabIndex = 21;
            this.txtTotIvaIstituzionaleSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label61
            // 
            this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label61.Location = new System.Drawing.Point(498, 438);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(251, 16);
            this.label61.TabIndex = 20;
            this.label61.Text = "Totale iva istituzionale Split Payment";
            // 
            // txtTotIvaIstituzIntrastat
            // 
            this.txtTotIvaIstituzIntrastat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotIvaIstituzIntrastat.Location = new System.Drawing.Point(498, 412);
            this.txtTotIvaIstituzIntrastat.Name = "txtTotIvaIstituzIntrastat";
            this.txtTotIvaIstituzIntrastat.ReadOnly = true;
            this.txtTotIvaIstituzIntrastat.Size = new System.Drawing.Size(96, 23);
            this.txtTotIvaIstituzIntrastat.TabIndex = 19;
            this.txtTotIvaIstituzIntrastat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label43.Location = new System.Drawing.Point(498, 396);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(251, 16);
            this.label43.TabIndex = 18;
            this.label43.Text = "Totale iva istituzionale INTRA e Extra-UE";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.Location = new System.Drawing.Point(154, 396);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(316, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Totale iva detraibile (somma di commerciale e promiscuo)";
            // 
            // txtIvaCredito
            // 
            this.txtIvaCredito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaCredito.Location = new System.Drawing.Point(156, 412);
            this.txtIvaCredito.Name = "txtIvaCredito";
            this.txtIvaCredito.ReadOnly = true;
            this.txtIvaCredito.Size = new System.Drawing.Size(122, 23);
            this.txtIvaCredito.TabIndex = 16;
            this.txtIvaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labTotDopoProrata
            // 
            this.labTotDopoProrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labTotDopoProrata.Location = new System.Drawing.Point(154, 438);
            this.labTotDopoProrata.Name = "labTotDopoProrata";
            this.labTotDopoProrata.Size = new System.Drawing.Size(283, 16);
            this.labTotDopoProrata.TabIndex = 8;
            this.labTotDopoProrata.Text = "Totale Iva detraibile dopo applicazione prorata";
            // 
            // txtIvaCreditoProrata
            // 
            this.txtIvaCreditoProrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaCreditoProrata.Location = new System.Drawing.Point(157, 454);
            this.txtIvaCreditoProrata.Name = "txtIvaCreditoProrata";
            this.txtIvaCreditoProrata.ReadOnly = true;
            this.txtIvaCreditoProrata.Size = new System.Drawing.Size(167, 23);
            this.txtIvaCreditoProrata.TabIndex = 9;
            this.txtIvaCreditoProrata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Controls.Add(this.tabIntra12);
            this.tabControl2.Controls.Add(this.tabPage9);
            this.tabControl2.Location = new System.Drawing.Point(4, 8);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(931, 379);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.lblMessaggi);
            this.tabPage6.Controls.Add(this.gridDebito);
            this.tabPage6.Controls.Add(this.groupBox5);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(923, 351);
            this.tabPage6.TabIndex = 0;
            this.tabPage6.Text = "Vendite";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // lblMessaggi
            // 
            this.lblMessaggi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessaggi.Location = new System.Drawing.Point(6, 15);
            this.lblMessaggi.Name = "lblMessaggi";
            this.lblMessaggi.Size = new System.Drawing.Size(729, 16);
            this.lblMessaggi.TabIndex = 0;
            this.lblMessaggi.Text = "Registri IVA vendite";
            // 
            // gridDebito
            // 
            this.gridDebito.AllowNavigation = false;
            this.gridDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDebito.CaptionVisible = false;
            this.gridDebito.DataMember = "";
            this.gridDebito.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridDebito.Location = new System.Drawing.Point(6, 31);
            this.gridDebito.Name = "gridDebito";
            this.gridDebito.Size = new System.Drawing.Size(911, 239);
            this.gridDebito.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.txtIvaDebitoImmediata);
            this.groupBox5.Controls.Add(this.txtIvaDebitoDifferita);
            this.groupBox5.Location = new System.Drawing.Point(9, 276);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(330, 67);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "IVA a Debito";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Immediata";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(158, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 11;
            this.label15.Text = "Differita";
            // 
            // txtIvaDebitoImmediata
            // 
            this.txtIvaDebitoImmediata.Location = new System.Drawing.Point(6, 33);
            this.txtIvaDebitoImmediata.Name = "txtIvaDebitoImmediata";
            this.txtIvaDebitoImmediata.ReadOnly = true;
            this.txtIvaDebitoImmediata.Size = new System.Drawing.Size(122, 23);
            this.txtIvaDebitoImmediata.TabIndex = 13;
            this.txtIvaDebitoImmediata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaDebitoDifferita
            // 
            this.txtIvaDebitoDifferita.Location = new System.Drawing.Point(158, 33);
            this.txtIvaDebitoDifferita.Name = "txtIvaDebitoDifferita";
            this.txtIvaDebitoDifferita.ReadOnly = true;
            this.txtIvaDebitoDifferita.Size = new System.Drawing.Size(122, 23);
            this.txtIvaDebitoDifferita.TabIndex = 14;
            this.txtIvaDebitoDifferita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox7);
            this.tabPage7.Controls.Add(this.label7);
            this.tabPage7.Controls.Add(this.groupBox6);
            this.tabPage7.Controls.Add(this.gridAcquisti);
            this.tabPage7.Controls.Add(this.groupBox4);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(923, 351);
            this.tabPage7.TabIndex = 1;
            this.tabPage7.Text = "Acquisti commerciali";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.txtIndetraibileDifferita);
            this.groupBox7.Controls.Add(this.txtIvaCreditoTotaleDifferita);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.txtIvaCreditoDifferita);
            this.groupBox7.Location = new System.Drawing.Point(156, 194);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(144, 149);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Differita";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(96, 16);
            this.label22.TabIndex = 21;
            this.label22.Text = "di cui Indetraibile";
            // 
            // txtIndetraibileDifferita
            // 
            this.txtIndetraibileDifferita.Location = new System.Drawing.Point(8, 72);
            this.txtIndetraibileDifferita.Name = "txtIndetraibileDifferita";
            this.txtIndetraibileDifferita.ReadOnly = true;
            this.txtIndetraibileDifferita.Size = new System.Drawing.Size(96, 23);
            this.txtIndetraibileDifferita.TabIndex = 22;
            this.txtIndetraibileDifferita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaCreditoTotaleDifferita
            // 
            this.txtIvaCreditoTotaleDifferita.Location = new System.Drawing.Point(8, 32);
            this.txtIvaCreditoTotaleDifferita.Name = "txtIvaCreditoTotaleDifferita";
            this.txtIvaCreditoTotaleDifferita.ReadOnly = true;
            this.txtIvaCreditoTotaleDifferita.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoTotaleDifferita.TabIndex = 20;
            this.txtIvaCreditoTotaleDifferita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(8, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 16);
            this.label20.TabIndex = 19;
            this.label20.Text = "Totale";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 16);
            this.label18.TabIndex = 17;
            this.label18.Text = "Detraibile";
            // 
            // txtIvaCreditoDifferita
            // 
            this.txtIvaCreditoDifferita.Location = new System.Drawing.Point(8, 112);
            this.txtIvaCreditoDifferita.Name = "txtIvaCreditoDifferita";
            this.txtIvaCreditoDifferita.ReadOnly = true;
            this.txtIvaCreditoDifferita.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoDifferita.TabIndex = 18;
            this.txtIvaCreditoDifferita.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(431, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Registri IVA acquisti commerciali";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txtIndetraibileImmediata);
            this.groupBox6.Controls.Add(this.txtIvaCreditoTotaleImmediata);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txtIvaCreditoImmediata);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Location = new System.Drawing.Point(9, 194);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(144, 149);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Immediata";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 16);
            this.label17.TabIndex = 19;
            this.label17.Text = "di cui Indetraibile";
            // 
            // txtIndetraibileImmediata
            // 
            this.txtIndetraibileImmediata.Location = new System.Drawing.Point(8, 72);
            this.txtIndetraibileImmediata.Name = "txtIndetraibileImmediata";
            this.txtIndetraibileImmediata.ReadOnly = true;
            this.txtIndetraibileImmediata.Size = new System.Drawing.Size(96, 23);
            this.txtIndetraibileImmediata.TabIndex = 20;
            this.txtIndetraibileImmediata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaCreditoTotaleImmediata
            // 
            this.txtIvaCreditoTotaleImmediata.Location = new System.Drawing.Point(8, 32);
            this.txtIvaCreditoTotaleImmediata.Name = "txtIvaCreditoTotaleImmediata";
            this.txtIvaCreditoTotaleImmediata.ReadOnly = true;
            this.txtIvaCreditoTotaleImmediata.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoTotaleImmediata.TabIndex = 18;
            this.txtIvaCreditoTotaleImmediata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(8, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 16);
            this.label19.TabIndex = 17;
            this.label19.Text = "Totale";
            // 
            // txtIvaCreditoImmediata
            // 
            this.txtIvaCreditoImmediata.Location = new System.Drawing.Point(8, 112);
            this.txtIvaCreditoImmediata.Name = "txtIvaCreditoImmediata";
            this.txtIvaCreditoImmediata.ReadOnly = true;
            this.txtIvaCreditoImmediata.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoImmediata.TabIndex = 16;
            this.txtIvaCreditoImmediata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 96);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 16);
            this.label21.TabIndex = 15;
            this.label21.Text = "Detraibile";
            // 
            // gridAcquisti
            // 
            this.gridAcquisti.AllowNavigation = false;
            this.gridAcquisti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAcquisti.CaptionVisible = false;
            this.gridAcquisti.DataMember = "";
            this.gridAcquisti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAcquisti.Location = new System.Drawing.Point(6, 19);
            this.gridAcquisti.Name = "gridAcquisti";
            this.gridAcquisti.Size = new System.Drawing.Size(906, 169);
            this.gridAcquisti.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.txtIvaCreditoTotaleCommerciale);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(306, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(239, 149);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "IVA a Credito";
            // 
            // txtIvaCreditoTotaleCommerciale
            // 
            this.txtIvaCreditoTotaleCommerciale.Location = new System.Drawing.Point(6, 33);
            this.txtIvaCreditoTotaleCommerciale.Name = "txtIvaCreditoTotaleCommerciale";
            this.txtIvaCreditoTotaleCommerciale.ReadOnly = true;
            this.txtIvaCreditoTotaleCommerciale.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoTotaleCommerciale.TabIndex = 11;
            this.txtIvaCreditoTotaleCommerciale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Totale iva detraibile";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.label30);
            this.tabPage8.Controls.Add(this.groupBox9);
            this.tabPage8.Controls.Add(this.gridacquistipromiscui);
            this.tabPage8.Controls.Add(this.groupBox10);
            this.tabPage8.Controls.Add(this.groupBox8);
            this.tabPage8.Location = new System.Drawing.Point(4, 24);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(923, 351);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Acquisti promiscui";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label30.Location = new System.Drawing.Point(9, 5);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(431, 16);
            this.label30.TabIndex = 18;
            this.label30.Text = "Registri IVA acquisti promiscui";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox9.Controls.Add(this.label31);
            this.groupBox9.Controls.Add(this.txtIndetraibileImmediataPromiscui);
            this.groupBox9.Controls.Add(this.txtIvaCreditoTotaleImmediataPromiscui);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.txtIvaCreditoImmediataPromiscui);
            this.groupBox9.Controls.Add(this.label33);
            this.groupBox9.Location = new System.Drawing.Point(9, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(144, 149);
            this.groupBox9.TabIndex = 21;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Immediata";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(8, 56);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(96, 16);
            this.label31.TabIndex = 19;
            this.label31.Text = "di cui Indetraibile";
            // 
            // txtIndetraibileImmediataPromiscui
            // 
            this.txtIndetraibileImmediataPromiscui.Location = new System.Drawing.Point(8, 72);
            this.txtIndetraibileImmediataPromiscui.Name = "txtIndetraibileImmediataPromiscui";
            this.txtIndetraibileImmediataPromiscui.ReadOnly = true;
            this.txtIndetraibileImmediataPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIndetraibileImmediataPromiscui.TabIndex = 20;
            this.txtIndetraibileImmediataPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaCreditoTotaleImmediataPromiscui
            // 
            this.txtIvaCreditoTotaleImmediataPromiscui.Location = new System.Drawing.Point(8, 32);
            this.txtIvaCreditoTotaleImmediataPromiscui.Name = "txtIvaCreditoTotaleImmediataPromiscui";
            this.txtIvaCreditoTotaleImmediataPromiscui.ReadOnly = true;
            this.txtIvaCreditoTotaleImmediataPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoTotaleImmediataPromiscui.TabIndex = 18;
            this.txtIvaCreditoTotaleImmediataPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(8, 16);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(96, 16);
            this.label32.TabIndex = 17;
            this.label32.Text = "Totale";
            // 
            // txtIvaCreditoImmediataPromiscui
            // 
            this.txtIvaCreditoImmediataPromiscui.Location = new System.Drawing.Point(8, 112);
            this.txtIvaCreditoImmediataPromiscui.Name = "txtIvaCreditoImmediataPromiscui";
            this.txtIvaCreditoImmediataPromiscui.ReadOnly = true;
            this.txtIvaCreditoImmediataPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoImmediataPromiscui.TabIndex = 16;
            this.txtIvaCreditoImmediataPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(8, 96);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(112, 16);
            this.label33.TabIndex = 15;
            this.label33.Text = "Detraibile";
            // 
            // gridacquistipromiscui
            // 
            this.gridacquistipromiscui.AllowNavigation = false;
            this.gridacquistipromiscui.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridacquistipromiscui.CaptionVisible = false;
            this.gridacquistipromiscui.DataMember = "";
            this.gridacquistipromiscui.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridacquistipromiscui.Location = new System.Drawing.Point(9, 21);
            this.gridacquistipromiscui.Name = "gridacquistipromiscui";
            this.gridacquistipromiscui.Size = new System.Drawing.Size(906, 166);
            this.gridacquistipromiscui.TabIndex = 19;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox10.Controls.Add(this.txtIvaCreditoTotalePromiscuiPOST);
            this.groupBox10.Controls.Add(this.labTotIvaPromPOST);
            this.groupBox10.Controls.Add(this.txtIvaCreditoTotalePromiscui);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Location = new System.Drawing.Point(312, 193);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(288, 149);
            this.groupBox10.TabIndex = 20;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "IVA a Credito";
            // 
            // txtIvaCreditoTotalePromiscuiPOST
            // 
            this.txtIvaCreditoTotalePromiscuiPOST.Location = new System.Drawing.Point(8, 80);
            this.txtIvaCreditoTotalePromiscuiPOST.Name = "txtIvaCreditoTotalePromiscuiPOST";
            this.txtIvaCreditoTotalePromiscuiPOST.ReadOnly = true;
            this.txtIvaCreditoTotalePromiscuiPOST.Size = new System.Drawing.Size(145, 23);
            this.txtIvaCreditoTotalePromiscuiPOST.TabIndex = 13;
            this.txtIvaCreditoTotalePromiscuiPOST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labTotIvaPromPOST
            // 
            this.labTotIvaPromPOST.Location = new System.Drawing.Point(8, 64);
            this.labTotIvaPromPOST.Name = "labTotIvaPromPOST";
            this.labTotIvaPromPOST.Size = new System.Drawing.Size(256, 16);
            this.labTotIvaPromPOST.TabIndex = 12;
            this.labTotIvaPromPOST.Text = "Totale iva detraibile dopo applicazione promiscuo";
            // 
            // txtIvaCreditoTotalePromiscui
            // 
            this.txtIvaCreditoTotalePromiscui.Location = new System.Drawing.Point(8, 40);
            this.txtIvaCreditoTotalePromiscui.Name = "txtIvaCreditoTotalePromiscui";
            this.txtIvaCreditoTotalePromiscui.ReadOnly = true;
            this.txtIvaCreditoTotalePromiscui.Size = new System.Drawing.Size(145, 23);
            this.txtIvaCreditoTotalePromiscui.TabIndex = 11;
            this.txtIvaCreditoTotalePromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(256, 16);
            this.label34.TabIndex = 10;
            this.label34.Text = "Totale iva detraibile";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.txtIndetraibileDifferitaPromiscui);
            this.groupBox8.Controls.Add(this.txtIvaCreditoTotaleDifferitaPromiscui);
            this.groupBox8.Controls.Add(this.label28);
            this.groupBox8.Controls.Add(this.label29);
            this.groupBox8.Controls.Add(this.txtIvaCreditoDifferitaPromiscui);
            this.groupBox8.Location = new System.Drawing.Point(162, 193);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(144, 149);
            this.groupBox8.TabIndex = 22;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Differita";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 56);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 16);
            this.label27.TabIndex = 21;
            this.label27.Text = "di cui Indetraibile";
            // 
            // txtIndetraibileDifferitaPromiscui
            // 
            this.txtIndetraibileDifferitaPromiscui.Location = new System.Drawing.Point(8, 72);
            this.txtIndetraibileDifferitaPromiscui.Name = "txtIndetraibileDifferitaPromiscui";
            this.txtIndetraibileDifferitaPromiscui.ReadOnly = true;
            this.txtIndetraibileDifferitaPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIndetraibileDifferitaPromiscui.TabIndex = 22;
            this.txtIndetraibileDifferitaPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaCreditoTotaleDifferitaPromiscui
            // 
            this.txtIvaCreditoTotaleDifferitaPromiscui.Location = new System.Drawing.Point(8, 32);
            this.txtIvaCreditoTotaleDifferitaPromiscui.Name = "txtIvaCreditoTotaleDifferitaPromiscui";
            this.txtIvaCreditoTotaleDifferitaPromiscui.ReadOnly = true;
            this.txtIvaCreditoTotaleDifferitaPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoTotaleDifferitaPromiscui.TabIndex = 20;
            this.txtIvaCreditoTotaleDifferitaPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(96, 16);
            this.label28.TabIndex = 19;
            this.label28.Text = "Totale";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 96);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(112, 16);
            this.label29.TabIndex = 17;
            this.label29.Text = "Detraibile";
            // 
            // txtIvaCreditoDifferitaPromiscui
            // 
            this.txtIvaCreditoDifferitaPromiscui.Location = new System.Drawing.Point(8, 112);
            this.txtIvaCreditoDifferitaPromiscui.Name = "txtIvaCreditoDifferitaPromiscui";
            this.txtIvaCreditoDifferitaPromiscui.ReadOnly = true;
            this.txtIvaCreditoDifferitaPromiscui.Size = new System.Drawing.Size(96, 23);
            this.txtIvaCreditoDifferitaPromiscui.TabIndex = 18;
            this.txtIvaCreditoDifferitaPromiscui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabIntra12
            // 
            this.tabIntra12.Controls.Add(this.groupBox11);
            this.tabIntra12.Controls.Add(this.label40);
            this.tabIntra12.Controls.Add(this.groupBox12);
            this.tabIntra12.Controls.Add(this.gridacquistiistituzionaliINTRA);
            this.tabIntra12.Controls.Add(this.groupBox13);
            this.tabIntra12.Location = new System.Drawing.Point(4, 24);
            this.tabIntra12.Name = "tabIntra12";
            this.tabIntra12.Padding = new System.Windows.Forms.Padding(3);
            this.tabIntra12.Size = new System.Drawing.Size(923, 351);
            this.tabIntra12.TabIndex = 3;
            this.tabIntra12.Text = "Acquisti Istituzionali INTRA e Extra-UE";
            this.tabIntra12.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox11.Controls.Add(this.label35);
            this.groupBox11.Controls.Add(this.txtIvaIstituzDeferr);
            this.groupBox11.Controls.Add(this.txtImpIstituzDeferr);
            this.groupBox11.Controls.Add(this.label38);
            this.groupBox11.Location = new System.Drawing.Point(159, 243);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(144, 101);
            this.groupBox11.TabIndex = 22;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Differita";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(8, 56);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(96, 16);
            this.label35.TabIndex = 21;
            this.label35.Text = "Iva";
            // 
            // txtIvaIstituzDeferr
            // 
            this.txtIvaIstituzDeferr.Location = new System.Drawing.Point(8, 72);
            this.txtIvaIstituzDeferr.Name = "txtIvaIstituzDeferr";
            this.txtIvaIstituzDeferr.ReadOnly = true;
            this.txtIvaIstituzDeferr.Size = new System.Drawing.Size(96, 23);
            this.txtIvaIstituzDeferr.TabIndex = 22;
            this.txtIvaIstituzDeferr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpIstituzDeferr
            // 
            this.txtImpIstituzDeferr.Location = new System.Drawing.Point(8, 32);
            this.txtImpIstituzDeferr.Name = "txtImpIstituzDeferr";
            this.txtImpIstituzDeferr.ReadOnly = true;
            this.txtImpIstituzDeferr.Size = new System.Drawing.Size(96, 23);
            this.txtImpIstituzDeferr.TabIndex = 20;
            this.txtImpIstituzDeferr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 16);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(96, 16);
            this.label38.TabIndex = 19;
            this.label38.Text = "Imponibile";
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label40.Location = new System.Drawing.Point(9, 4);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(389, 16);
            this.label40.TabIndex = 18;
            this.label40.Text = "Registri IVA acquisti istituzionali";
            // 
            // groupBox12
            // 
            this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox12.Controls.Add(this.label41);
            this.groupBox12.Controls.Add(this.txtIvaIstituzImmed);
            this.groupBox12.Controls.Add(this.txtImpIstituzImmed);
            this.groupBox12.Controls.Add(this.label42);
            this.groupBox12.Location = new System.Drawing.Point(12, 244);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(144, 101);
            this.groupBox12.TabIndex = 21;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Immediata";
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(8, 56);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(96, 16);
            this.label41.TabIndex = 19;
            this.label41.Text = "Iva";
            // 
            // txtIvaIstituzImmed
            // 
            this.txtIvaIstituzImmed.Location = new System.Drawing.Point(8, 72);
            this.txtIvaIstituzImmed.Name = "txtIvaIstituzImmed";
            this.txtIvaIstituzImmed.ReadOnly = true;
            this.txtIvaIstituzImmed.Size = new System.Drawing.Size(96, 23);
            this.txtIvaIstituzImmed.TabIndex = 20;
            this.txtIvaIstituzImmed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpIstituzImmed
            // 
            this.txtImpIstituzImmed.Location = new System.Drawing.Point(8, 32);
            this.txtImpIstituzImmed.Name = "txtImpIstituzImmed";
            this.txtImpIstituzImmed.ReadOnly = true;
            this.txtImpIstituzImmed.Size = new System.Drawing.Size(96, 23);
            this.txtImpIstituzImmed.TabIndex = 18;
            this.txtImpIstituzImmed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(8, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(96, 16);
            this.label42.TabIndex = 17;
            this.label42.Text = "Imponibile";
            // 
            // gridacquistiistituzionaliINTRA
            // 
            this.gridacquistiistituzionaliINTRA.AllowNavigation = false;
            this.gridacquistiistituzionaliINTRA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridacquistiistituzionaliINTRA.CaptionVisible = false;
            this.gridacquistiistituzionaliINTRA.DataMember = "";
            this.gridacquistiistituzionaliINTRA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridacquistiistituzionaliINTRA.Location = new System.Drawing.Point(9, 20);
            this.gridacquistiistituzionaliINTRA.Name = "gridacquistiistituzionaliINTRA";
            this.gridacquistiistituzionaliINTRA.Size = new System.Drawing.Size(906, 217);
            this.gridacquistiistituzionaliINTRA.TabIndex = 19;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox13.Controls.Add(this.txtTotIvaIstituz);
            this.groupBox13.Controls.Add(this.label39);
            this.groupBox13.Controls.Add(this.txtTotImpIstituz);
            this.groupBox13.Controls.Add(this.label44);
            this.groupBox13.Location = new System.Drawing.Point(309, 243);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(239, 101);
            this.groupBox13.TabIndex = 20;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "IVA a Debito";
            // 
            // txtTotIvaIstituz
            // 
            this.txtTotIvaIstituz.Location = new System.Drawing.Point(6, 73);
            this.txtTotIvaIstituz.Name = "txtTotIvaIstituz";
            this.txtTotIvaIstituz.ReadOnly = true;
            this.txtTotIvaIstituz.Size = new System.Drawing.Size(96, 23);
            this.txtTotIvaIstituz.TabIndex = 13;
            this.txtTotIvaIstituz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(6, 57);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(200, 16);
            this.label39.TabIndex = 12;
            this.label39.Text = "Totale iva";
            // 
            // txtTotImpIstituz
            // 
            this.txtTotImpIstituz.Location = new System.Drawing.Point(6, 33);
            this.txtTotImpIstituz.Name = "txtTotImpIstituz";
            this.txtTotImpIstituz.ReadOnly = true;
            this.txtTotImpIstituz.Size = new System.Drawing.Size(96, 23);
            this.txtTotImpIstituz.TabIndex = 11;
            this.txtTotImpIstituz.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(6, 17);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(200, 16);
            this.label44.TabIndex = 10;
            this.label44.Text = "Totale imponibile";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.groupBox16);
            this.tabPage9.Controls.Add(this.label52);
            this.tabPage9.Controls.Add(this.groupBox17);
            this.tabPage9.Controls.Add(this.gridacquistiistituzionaliSplit);
            this.tabPage9.Controls.Add(this.groupBox18);
            this.tabPage9.Location = new System.Drawing.Point(4, 24);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(923, 351);
            this.tabPage9.TabIndex = 4;
            this.tabPage9.Text = "Acquisti istituzionali Split Payment";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox16.Controls.Add(this.label47);
            this.groupBox16.Controls.Add(this.txtIvaIstituzDeferrSplit);
            this.groupBox16.Controls.Add(this.txtImpIstituzDeferrSplit);
            this.groupBox16.Controls.Add(this.label48);
            this.groupBox16.Location = new System.Drawing.Point(159, 243);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(144, 101);
            this.groupBox16.TabIndex = 27;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Differita";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(8, 56);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(96, 16);
            this.label47.TabIndex = 21;
            this.label47.Text = "Iva";
            // 
            // txtIvaIstituzDeferrSplit
            // 
            this.txtIvaIstituzDeferrSplit.Location = new System.Drawing.Point(8, 72);
            this.txtIvaIstituzDeferrSplit.Name = "txtIvaIstituzDeferrSplit";
            this.txtIvaIstituzDeferrSplit.ReadOnly = true;
            this.txtIvaIstituzDeferrSplit.Size = new System.Drawing.Size(96, 23);
            this.txtIvaIstituzDeferrSplit.TabIndex = 22;
            this.txtIvaIstituzDeferrSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpIstituzDeferrSplit
            // 
            this.txtImpIstituzDeferrSplit.Location = new System.Drawing.Point(8, 32);
            this.txtImpIstituzDeferrSplit.Name = "txtImpIstituzDeferrSplit";
            this.txtImpIstituzDeferrSplit.ReadOnly = true;
            this.txtImpIstituzDeferrSplit.Size = new System.Drawing.Size(96, 23);
            this.txtImpIstituzDeferrSplit.TabIndex = 20;
            this.txtImpIstituzDeferrSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(96, 16);
            this.label48.TabIndex = 19;
            this.label48.Text = "Imponibile";
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.Location = new System.Drawing.Point(9, 4);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(389, 16);
            this.label52.TabIndex = 23;
            this.label52.Text = "Registri IVA acquisti istituzionali";
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox17.Controls.Add(this.label53);
            this.groupBox17.Controls.Add(this.txtIvaIstituzImmedSplit);
            this.groupBox17.Controls.Add(this.txtImpIstituzImmedSplit);
            this.groupBox17.Controls.Add(this.label54);
            this.groupBox17.Location = new System.Drawing.Point(12, 243);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(144, 101);
            this.groupBox17.TabIndex = 26;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Immediata";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 56);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(96, 16);
            this.label53.TabIndex = 19;
            this.label53.Text = "Iva";
            // 
            // txtIvaIstituzImmedSplit
            // 
            this.txtIvaIstituzImmedSplit.Location = new System.Drawing.Point(8, 72);
            this.txtIvaIstituzImmedSplit.Name = "txtIvaIstituzImmedSplit";
            this.txtIvaIstituzImmedSplit.ReadOnly = true;
            this.txtIvaIstituzImmedSplit.Size = new System.Drawing.Size(96, 23);
            this.txtIvaIstituzImmedSplit.TabIndex = 20;
            this.txtIvaIstituzImmedSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpIstituzImmedSplit
            // 
            this.txtImpIstituzImmedSplit.Location = new System.Drawing.Point(8, 32);
            this.txtImpIstituzImmedSplit.Name = "txtImpIstituzImmedSplit";
            this.txtImpIstituzImmedSplit.ReadOnly = true;
            this.txtImpIstituzImmedSplit.Size = new System.Drawing.Size(96, 23);
            this.txtImpIstituzImmedSplit.TabIndex = 18;
            this.txtImpIstituzImmedSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(8, 16);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(96, 16);
            this.label54.TabIndex = 17;
            this.label54.Text = "Imponibile";
            // 
            // gridacquistiistituzionaliSplit
            // 
            this.gridacquistiistituzionaliSplit.AllowNavigation = false;
            this.gridacquistiistituzionaliSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridacquistiistituzionaliSplit.CaptionVisible = false;
            this.gridacquistiistituzionaliSplit.DataMember = "";
            this.gridacquistiistituzionaliSplit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridacquistiistituzionaliSplit.Location = new System.Drawing.Point(9, 20);
            this.gridacquistiistituzionaliSplit.Name = "gridacquistiistituzionaliSplit";
            this.gridacquistiistituzionaliSplit.Size = new System.Drawing.Size(906, 217);
            this.gridacquistiistituzionaliSplit.TabIndex = 24;
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox18.Controls.Add(this.txtTotIvaIstituzSplit);
            this.groupBox18.Controls.Add(this.label59);
            this.groupBox18.Controls.Add(this.txtTotImpIstituzSplit);
            this.groupBox18.Controls.Add(this.label60);
            this.groupBox18.Location = new System.Drawing.Point(309, 243);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(239, 101);
            this.groupBox18.TabIndex = 25;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "IVA a Debito";
            // 
            // txtTotIvaIstituzSplit
            // 
            this.txtTotIvaIstituzSplit.Location = new System.Drawing.Point(6, 73);
            this.txtTotIvaIstituzSplit.Name = "txtTotIvaIstituzSplit";
            this.txtTotIvaIstituzSplit.ReadOnly = true;
            this.txtTotIvaIstituzSplit.Size = new System.Drawing.Size(96, 23);
            this.txtTotIvaIstituzSplit.TabIndex = 13;
            this.txtTotIvaIstituzSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(6, 57);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(200, 16);
            this.label59.TabIndex = 12;
            this.label59.Text = "Totale iva";
            // 
            // txtTotImpIstituzSplit
            // 
            this.txtTotImpIstituzSplit.Location = new System.Drawing.Point(6, 33);
            this.txtTotImpIstituzSplit.Name = "txtTotImpIstituzSplit";
            this.txtTotImpIstituzSplit.ReadOnly = true;
            this.txtTotImpIstituzSplit.Size = new System.Drawing.Size(96, 23);
            this.txtTotImpIstituzSplit.TabIndex = 11;
            this.txtTotImpIstituzSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(6, 17);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(200, 16);
            this.label60.TabIndex = 10;
            this.label60.Text = "Totale imponibile";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(8, 396);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 16);
            this.label16.TabIndex = 12;
            this.label16.Text = "Totale iva a debito";
            // 
            // txtIvaDebito
            // 
            this.txtIvaDebito.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaDebito.Location = new System.Drawing.Point(10, 412);
            this.txtIvaDebito.Name = "txtIvaDebito";
            this.txtIvaDebito.ReadOnly = true;
            this.txtIvaDebito.Size = new System.Drawing.Size(122, 23);
            this.txtIvaDebito.TabIndex = 5;
            this.txtIvaDebito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.label49);
            this.tabPage13.Controls.Add(this.txtLiquidMese__split1);
            this.tabPage13.Controls.Add(this.labCredito4__split1);
            this.tabPage13.Controls.Add(this.labCredito3__split1);
            this.tabPage13.Controls.Add(this.txtNuovoSaldo__split1);
            this.tabPage13.Controls.Add(this.panel7);
            this.tabPage13.Controls.Add(this.label57);
            this.tabPage13.Controls.Add(this.label58);
            this.tabPage13.Controls.Add(this.lblcredito5__split1);
            this.tabPage13.Controls.Add(this.lblcredito2__split1);
            this.tabPage13.Controls.Add(this.lblcredito1__split1);
            this.tabPage13.Controls.Add(this.txtIvaPeriodo__split1);
            this.tabPage13.Controls.Add(this.txtTotaleIva__split1);
            this.tabPage13.Controls.Add(this.txtSaldoPrec__split1);
            this.tabPage13.Controls.Add(this.panel8);
            this.tabPage13.Controls.Add(this.label65);
            this.tabPage13.Controls.Add(this.label66);
            this.tabPage13.Controls.Add(this.label68);
            this.tabPage13.Controls.Add(this.panel9);
            this.tabPage13.Controls.Add(this.lblcredito5__121);
            this.tabPage13.Controls.Add(this.lblcredito2__121);
            this.tabPage13.Controls.Add(this.lblcredito1__121);
            this.tabPage13.Controls.Add(this.txtLiquidMese121);
            this.tabPage13.Controls.Add(this.lab_credito4_121);
            this.tabPage13.Controls.Add(this.lab_credito3_121);
            this.tabPage13.Controls.Add(this.txtNuovoSaldo121);
            this.tabPage13.Controls.Add(this.panel10);
            this.tabPage13.Controls.Add(this.label76);
            this.tabPage13.Controls.Add(this.label79);
            this.tabPage13.Controls.Add(this.label80);
            this.tabPage13.Controls.Add(this.label81);
            this.tabPage13.Controls.Add(this.label82);
            this.tabPage13.Controls.Add(this.txtIvaPeriodo121);
            this.tabPage13.Controls.Add(this.txtTotaleIva121);
            this.tabPage13.Controls.Add(this.txtSaldoPrec121);
            this.tabPage13.Controls.Add(this.label83);
            this.tabPage13.Controls.Add(this.txtLiquidMese1);
            this.tabPage13.Controls.Add(this.label84);
            this.tabPage13.Controls.Add(this.labCredito41);
            this.tabPage13.Controls.Add(this.labCredito31);
            this.tabPage13.Controls.Add(this.txtNuovoSaldo1);
            this.tabPage13.Controls.Add(this.label87);
            this.tabPage13.Controls.Add(this.panel11);
            this.tabPage13.Controls.Add(this.label88);
            this.tabPage13.Controls.Add(this.label89);
            this.tabPage13.Controls.Add(this.tabControlCollegaAltriPagamenti);
            this.tabPage13.Controls.Add(this.lblcredito51);
            this.tabPage13.Controls.Add(this.lblcredito21);
            this.tabPage13.Controls.Add(this.lblcredito11);
            this.tabPage13.Controls.Add(this.txtIvaPeriodo1);
            this.tabPage13.Controls.Add(this.label95);
            this.tabPage13.Controls.Add(this.txtTotaleIva1);
            this.tabPage13.Controls.Add(this.lblSaldoCorr1);
            this.tabPage13.Controls.Add(this.txtSaldoPrec1);
            this.tabPage13.Controls.Add(this.label97);
            this.tabPage13.Location = new System.Drawing.Point(0, 0);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Selected = false;
            this.tabPage13.Size = new System.Drawing.Size(938, 484);
            this.tabPage13.TabIndex = 4;
            this.tabPage13.Title = "Pagina 3 di 4";
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(681, 313);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(160, 13);
            this.label49.TabIndex = 146;
            this.label49.Text = "Istituzionale Split Payment";
            // 
            // txtLiquidMese__split1
            // 
            this.txtLiquidMese__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese__split1.Location = new System.Drawing.Point(693, 430);
            this.txtLiquidMese__split1.Name = "txtLiquidMese__split1";
            this.txtLiquidMese__split1.ReadOnly = true;
            this.txtLiquidMese__split1.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese__split1.TabIndex = 145;
            this.txtLiquidMese__split1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labCredito4__split1
            // 
            this.labCredito4__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito4__split1.Location = new System.Drawing.Point(796, 435);
            this.labCredito4__split1.Name = "labCredito4__split1";
            this.labCredito4__split1.Size = new System.Drawing.Size(72, 16);
            this.labCredito4__split1.TabIndex = 144;
            this.labCredito4__split1.Text = "a debito";
            // 
            // labCredito3__split1
            // 
            this.labCredito3__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito3__split1.Location = new System.Drawing.Point(796, 396);
            this.labCredito3__split1.Name = "labCredito3__split1";
            this.labCredito3__split1.Size = new System.Drawing.Size(72, 16);
            this.labCredito3__split1.TabIndex = 143;
            this.labCredito3__split1.Text = "a debito";
            // 
            // txtNuovoSaldo__split1
            // 
            this.txtNuovoSaldo__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo__split1.Location = new System.Drawing.Point(693, 457);
            this.txtNuovoSaldo__split1.Name = "txtNuovoSaldo__split1";
            this.txtNuovoSaldo__split1.ReadOnly = true;
            this.txtNuovoSaldo__split1.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo__split1.TabIndex = 142;
            this.txtNuovoSaldo__split1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(684, 385);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(180, 2);
            this.panel7.TabIndex = 141;
            // 
            // label57
            // 
            this.label57.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.Location = new System.Drawing.Point(873, 362);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(16, 16);
            this.label57.TabIndex = 140;
            this.label57.Text = "=";
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.Location = new System.Drawing.Point(873, 341);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(16, 16);
            this.label58.TabIndex = 139;
            this.label58.Text = "+";
            // 
            // lblcredito5__split1
            // 
            this.lblcredito5__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito5__split1.Location = new System.Drawing.Point(796, 461);
            this.lblcredito5__split1.Name = "lblcredito5__split1";
            this.lblcredito5__split1.Size = new System.Drawing.Size(72, 16);
            this.lblcredito5__split1.TabIndex = 138;
            // 
            // lblcredito2__split1
            // 
            this.lblcredito2__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito2__split1.Location = new System.Drawing.Point(796, 362);
            this.lblcredito2__split1.Name = "lblcredito2__split1";
            this.lblcredito2__split1.Size = new System.Drawing.Size(72, 16);
            this.lblcredito2__split1.TabIndex = 137;
            // 
            // lblcredito1__split1
            // 
            this.lblcredito1__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito1__split1.Location = new System.Drawing.Point(796, 339);
            this.lblcredito1__split1.Name = "lblcredito1__split1";
            this.lblcredito1__split1.Size = new System.Drawing.Size(72, 16);
            this.lblcredito1__split1.TabIndex = 136;
            // 
            // txtIvaPeriodo__split1
            // 
            this.txtIvaPeriodo__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo__split1.Location = new System.Drawing.Point(693, 359);
            this.txtIvaPeriodo__split1.Name = "txtIvaPeriodo__split1";
            this.txtIvaPeriodo__split1.ReadOnly = true;
            this.txtIvaPeriodo__split1.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo__split1.TabIndex = 135;
            this.txtIvaPeriodo__split1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleIva__split1
            // 
            this.txtTotaleIva__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva__split1.Location = new System.Drawing.Point(693, 390);
            this.txtTotaleIva__split1.Name = "txtTotaleIva__split1";
            this.txtTotaleIva__split1.ReadOnly = true;
            this.txtTotaleIva__split1.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva__split1.TabIndex = 134;
            this.txtTotaleIva__split1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoPrec__split1
            // 
            this.txtSaldoPrec__split1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec__split1.Location = new System.Drawing.Point(693, 334);
            this.txtSaldoPrec__split1.Name = "txtSaldoPrec__split1";
            this.txtSaldoPrec__split1.ReadOnly = true;
            this.txtSaldoPrec__split1.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec__split1.TabIndex = 133;
            this.txtSaldoPrec__split1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Location = new System.Drawing.Point(684, 384);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(180, 2);
            this.panel8.TabIndex = 132;
            // 
            // label65
            // 
            this.label65.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.Location = new System.Drawing.Point(873, 361);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(16, 16);
            this.label65.TabIndex = 131;
            this.label65.Text = "=";
            // 
            // label66
            // 
            this.label66.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.Location = new System.Drawing.Point(873, 340);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(16, 16);
            this.label66.TabIndex = 130;
            this.label66.Text = "+";
            // 
            // label68
            // 
            this.label68.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(410, 313);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(178, 13);
            this.label68.TabIndex = 129;
            this.label68.Text = "Istituzionale INTRA e Extra-UE";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Location = new System.Drawing.Point(413, 385);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(180, 2);
            this.panel9.TabIndex = 128;
            // 
            // lblcredito5__121
            // 
            this.lblcredito5__121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito5__121.Location = new System.Drawing.Point(523, 462);
            this.lblcredito5__121.Name = "lblcredito5__121";
            this.lblcredito5__121.Size = new System.Drawing.Size(72, 16);
            this.lblcredito5__121.TabIndex = 127;
            // 
            // lblcredito2__121
            // 
            this.lblcredito2__121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito2__121.Location = new System.Drawing.Point(524, 361);
            this.lblcredito2__121.Name = "lblcredito2__121";
            this.lblcredito2__121.Size = new System.Drawing.Size(72, 16);
            this.lblcredito2__121.TabIndex = 126;
            // 
            // lblcredito1__121
            // 
            this.lblcredito1__121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito1__121.Location = new System.Drawing.Point(524, 338);
            this.lblcredito1__121.Name = "lblcredito1__121";
            this.lblcredito1__121.Size = new System.Drawing.Size(72, 16);
            this.lblcredito1__121.TabIndex = 125;
            // 
            // txtLiquidMese121
            // 
            this.txtLiquidMese121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese121.Location = new System.Drawing.Point(422, 430);
            this.txtLiquidMese121.Name = "txtLiquidMese121";
            this.txtLiquidMese121.ReadOnly = true;
            this.txtLiquidMese121.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese121.TabIndex = 124;
            this.txtLiquidMese121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lab_credito4_121
            // 
            this.lab_credito4_121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito4_121.Location = new System.Drawing.Point(523, 435);
            this.lab_credito4_121.Name = "lab_credito4_121";
            this.lab_credito4_121.Size = new System.Drawing.Size(72, 16);
            this.lab_credito4_121.TabIndex = 123;
            this.lab_credito4_121.Text = "a debito";
            // 
            // lab_credito3_121
            // 
            this.lab_credito3_121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_credito3_121.Location = new System.Drawing.Point(523, 396);
            this.lab_credito3_121.Name = "lab_credito3_121";
            this.lab_credito3_121.Size = new System.Drawing.Size(72, 16);
            this.lab_credito3_121.TabIndex = 122;
            this.lab_credito3_121.Text = "a debito";
            // 
            // txtNuovoSaldo121
            // 
            this.txtNuovoSaldo121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo121.Location = new System.Drawing.Point(421, 458);
            this.txtNuovoSaldo121.Name = "txtNuovoSaldo121";
            this.txtNuovoSaldo121.ReadOnly = true;
            this.txtNuovoSaldo121.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo121.TabIndex = 121;
            this.txtNuovoSaldo121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Location = new System.Drawing.Point(413, 384);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(180, 2);
            this.panel10.TabIndex = 120;
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(602, 361);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(16, 16);
            this.label76.TabIndex = 119;
            this.label76.Text = "=";
            // 
            // label79
            // 
            this.label79.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.Location = new System.Drawing.Point(602, 340);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(16, 16);
            this.label79.TabIndex = 118;
            this.label79.Text = "+";
            // 
            // label80
            // 
            this.label80.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label80.Location = new System.Drawing.Point(523, 461);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(72, 16);
            this.label80.TabIndex = 117;
            // 
            // label81
            // 
            this.label81.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label81.Location = new System.Drawing.Point(525, 359);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(72, 16);
            this.label81.TabIndex = 116;
            // 
            // label82
            // 
            this.label82.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label82.Location = new System.Drawing.Point(525, 336);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(72, 16);
            this.label82.TabIndex = 115;
            // 
            // txtIvaPeriodo121
            // 
            this.txtIvaPeriodo121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo121.Location = new System.Drawing.Point(423, 357);
            this.txtIvaPeriodo121.Name = "txtIvaPeriodo121";
            this.txtIvaPeriodo121.ReadOnly = true;
            this.txtIvaPeriodo121.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo121.TabIndex = 114;
            this.txtIvaPeriodo121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleIva121
            // 
            this.txtTotaleIva121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva121.Location = new System.Drawing.Point(421, 389);
            this.txtTotaleIva121.Name = "txtTotaleIva121";
            this.txtTotaleIva121.ReadOnly = true;
            this.txtTotaleIva121.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva121.TabIndex = 113;
            this.txtTotaleIva121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaldoPrec121
            // 
            this.txtSaldoPrec121.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec121.Location = new System.Drawing.Point(423, 330);
            this.txtSaldoPrec121.Name = "txtSaldoPrec121";
            this.txtSaldoPrec121.ReadOnly = true;
            this.txtSaldoPrec121.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec121.TabIndex = 112;
            this.txtSaldoPrec121.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label83
            // 
            this.label83.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label83.AutoSize = true;
            this.label83.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.Location = new System.Drawing.Point(166, 313);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(97, 13);
            this.label83.TabIndex = 102;
            this.label83.Text = "Liquidazione iva";
            // 
            // txtLiquidMese1
            // 
            this.txtLiquidMese1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLiquidMese1.Location = new System.Drawing.Point(167, 428);
            this.txtLiquidMese1.Name = "txtLiquidMese1";
            this.txtLiquidMese1.ReadOnly = true;
            this.txtLiquidMese1.Size = new System.Drawing.Size(96, 23);
            this.txtLiquidMese1.TabIndex = 111;
            this.txtLiquidMese1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label84
            // 
            this.label84.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(36, 432);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(124, 15);
            this.label84.TabIndex = 110;
            this.label84.Text = "Liquidazione del mese";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labCredito41
            // 
            this.labCredito41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito41.Location = new System.Drawing.Point(275, 435);
            this.labCredito41.Name = "labCredito41";
            this.labCredito41.Size = new System.Drawing.Size(72, 16);
            this.labCredito41.TabIndex = 109;
            this.labCredito41.Text = "a debito";
            // 
            // labCredito31
            // 
            this.labCredito31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labCredito31.Location = new System.Drawing.Point(275, 392);
            this.labCredito31.Name = "labCredito31";
            this.labCredito31.Size = new System.Drawing.Size(62, 16);
            this.labCredito31.TabIndex = 108;
            this.labCredito31.Text = "a debito";
            // 
            // txtNuovoSaldo1
            // 
            this.txtNuovoSaldo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNuovoSaldo1.Location = new System.Drawing.Point(167, 454);
            this.txtNuovoSaldo1.Name = "txtNuovoSaldo1";
            this.txtNuovoSaldo1.ReadOnly = true;
            this.txtNuovoSaldo1.Size = new System.Drawing.Size(96, 23);
            this.txtNuovoSaldo1.TabIndex = 107;
            this.txtNuovoSaldo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label87
            // 
            this.label87.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label87.Location = new System.Drawing.Point(48, 459);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(112, 16);
            this.label87.TabIndex = 106;
            this.label87.Text = "Nuovo saldo";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel11
            // 
            this.panel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Location = new System.Drawing.Point(51, 381);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(236, 2);
            this.panel11.TabIndex = 105;
            // 
            // label88
            // 
            this.label88.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(349, 358);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(16, 16);
            this.label88.TabIndex = 104;
            this.label88.Text = "=";
            // 
            // label89
            // 
            this.label89.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label89.Location = new System.Drawing.Point(349, 337);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(16, 16);
            this.label89.TabIndex = 103;
            this.label89.Text = "+";
            // 
            // tabControlCollegaAltriPagamenti
            // 
            this.tabControlCollegaAltriPagamenti.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControlCollegaAltriPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlCollegaAltriPagamenti.Controls.Add(this.tabPageAltri);
            this.tabControlCollegaAltriPagamenti.Controls.Add(this.tabPageAltriIntra);
            this.tabControlCollegaAltriPagamenti.Controls.Add(this.tabPageAltriSplit);
            this.tabControlCollegaAltriPagamenti.Location = new System.Drawing.Point(16, 4);
            this.tabControlCollegaAltriPagamenti.Name = "tabControlCollegaAltriPagamenti";
            this.tabControlCollegaAltriPagamenti.SelectedIndex = 0;
            this.tabControlCollegaAltriPagamenti.Size = new System.Drawing.Size(906, 299);
            this.tabControlCollegaAltriPagamenti.TabIndex = 101;
            // 
            // tabPageAltri
            // 
            this.tabPageAltri.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAltri.Controls.Add(this.btnSCollegaAltri);
            this.tabPageAltri.Controls.Add(this.label91);
            this.tabPageAltri.Controls.Add(this.btnCollegaAltri);
            this.tabPageAltri.Controls.Add(this.gridAltri);
            this.tabPageAltri.Location = new System.Drawing.Point(4, 4);
            this.tabPageAltri.Name = "tabPageAltri";
            this.tabPageAltri.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAltri.Size = new System.Drawing.Size(898, 271);
            this.tabPageAltri.TabIndex = 2;
            this.tabPageAltri.Text = "Altri Pagamenti da collegare";
            // 
            // btnSCollegaAltri
            // 
            this.btnSCollegaAltri.Location = new System.Drawing.Point(523, 9);
            this.btnSCollegaAltri.Name = "btnSCollegaAltri";
            this.btnSCollegaAltri.Size = new System.Drawing.Size(75, 23);
            this.btnSCollegaAltri.TabIndex = 25;
            this.btnSCollegaAltri.Text = "Scollega";
            this.btnSCollegaAltri.UseVisualStyleBackColor = true;
            this.btnSCollegaAltri.Click += new System.EventHandler(this.btnSCollegaAltri_Click);
            // 
            // label91
            // 
            this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label91.Location = new System.Drawing.Point(89, 11);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(509, 16);
            this.label91.TabIndex = 24;
            this.label91.Text = "Premere il pulsante per collegare pagamenti già esistenti alla Liquidazione IVA";
            // 
            // btnCollegaAltri
            // 
            this.btnCollegaAltri.Location = new System.Drawing.Point(8, 8);
            this.btnCollegaAltri.Name = "btnCollegaAltri";
            this.btnCollegaAltri.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaAltri.TabIndex = 23;
            this.btnCollegaAltri.Text = "Collega";
            this.btnCollegaAltri.UseVisualStyleBackColor = true;
            this.btnCollegaAltri.Click += new System.EventHandler(this.btnCollegaAltri_Click);
            // 
            // gridAltri
            // 
            this.gridAltri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAltri.CaptionVisible = false;
            this.gridAltri.DataMember = "";
            this.gridAltri.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAltri.Location = new System.Drawing.Point(8, 53);
            this.gridAltri.Name = "gridAltri";
            this.gridAltri.Size = new System.Drawing.Size(882, 197);
            this.gridAltri.TabIndex = 22;
            // 
            // tabPageAltriIntra
            // 
            this.tabPageAltriIntra.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAltriIntra.Controls.Add(this.btnSCollegaAltriIntra);
            this.tabPageAltriIntra.Controls.Add(this.label90);
            this.tabPageAltriIntra.Controls.Add(this.btnCollegaAltriIntra);
            this.tabPageAltriIntra.Controls.Add(this.gridAltriIstituzionaleIntra);
            this.tabPageAltriIntra.Location = new System.Drawing.Point(4, 4);
            this.tabPageAltriIntra.Name = "tabPageAltriIntra";
            this.tabPageAltriIntra.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAltriIntra.Size = new System.Drawing.Size(898, 271);
            this.tabPageAltriIntra.TabIndex = 3;
            this.tabPageAltriIntra.Text = "Altri Pagamenti Istituzionale INTRA e Extra-UE";
            // 
            // btnSCollegaAltriIntra
            // 
            this.btnSCollegaAltriIntra.Location = new System.Drawing.Point(673, 11);
            this.btnSCollegaAltriIntra.Name = "btnSCollegaAltriIntra";
            this.btnSCollegaAltriIntra.Size = new System.Drawing.Size(75, 23);
            this.btnSCollegaAltriIntra.TabIndex = 26;
            this.btnSCollegaAltriIntra.Text = "Scollega";
            this.btnSCollegaAltriIntra.UseVisualStyleBackColor = true;
            this.btnSCollegaAltriIntra.Click += new System.EventHandler(this.btnSCollegaAltriIntra_Click);
            // 
            // label90
            // 
            this.label90.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label90.Location = new System.Drawing.Point(89, 11);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(712, 16);
            this.label90.TabIndex = 25;
            this.label90.Text = "Premere il pulsante per collegare pagamenti già esistenti alla Liquidazione IVA I" +
    "stituzionale Intra ed Extra-UE";
            // 
            // btnCollegaAltriIntra
            // 
            this.btnCollegaAltriIntra.Location = new System.Drawing.Point(8, 8);
            this.btnCollegaAltriIntra.Name = "btnCollegaAltriIntra";
            this.btnCollegaAltriIntra.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaAltriIntra.TabIndex = 24;
            this.btnCollegaAltriIntra.Text = "Collega";
            this.btnCollegaAltriIntra.UseVisualStyleBackColor = true;
            this.btnCollegaAltriIntra.Click += new System.EventHandler(this.btnCollegaaltriIntraExtraUe_Click);
            // 
            // gridAltriIstituzionaleIntra
            // 
            this.gridAltriIstituzionaleIntra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAltriIstituzionaleIntra.CaptionVisible = false;
            this.gridAltriIstituzionaleIntra.DataMember = "";
            this.gridAltriIstituzionaleIntra.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAltriIstituzionaleIntra.Location = new System.Drawing.Point(8, 53);
            this.gridAltriIstituzionaleIntra.Name = "gridAltriIstituzionaleIntra";
            this.gridAltriIstituzionaleIntra.Size = new System.Drawing.Size(882, 197);
            this.gridAltriIstituzionaleIntra.TabIndex = 23;
            // 
            // tabPageAltriSplit
            // 
            this.tabPageAltriSplit.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAltriSplit.Controls.Add(this.btnSCollegaAltriSplit);
            this.tabPageAltriSplit.Controls.Add(this.label98);
            this.tabPageAltriSplit.Controls.Add(this.btnCollegaAltriSplit);
            this.tabPageAltriSplit.Controls.Add(this.gridAltriIstituzionaleSplit);
            this.tabPageAltriSplit.Location = new System.Drawing.Point(4, 4);
            this.tabPageAltriSplit.Name = "tabPageAltriSplit";
            this.tabPageAltriSplit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAltriSplit.Size = new System.Drawing.Size(898, 271);
            this.tabPageAltriSplit.TabIndex = 4;
            this.tabPageAltriSplit.Text = "Altri Pagamenti Istituzionale Split Payment";
            // 
            // btnSCollegaAltriSplit
            // 
            this.btnSCollegaAltriSplit.Location = new System.Drawing.Point(673, 10);
            this.btnSCollegaAltriSplit.Name = "btnSCollegaAltriSplit";
            this.btnSCollegaAltriSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSCollegaAltriSplit.TabIndex = 27;
            this.btnSCollegaAltriSplit.Text = "Scollega";
            this.btnSCollegaAltriSplit.UseVisualStyleBackColor = true;
            this.btnSCollegaAltriSplit.Click += new System.EventHandler(this.btnSCollegaAltriSplit_Click);
            // 
            // label98
            // 
            this.label98.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label98.Location = new System.Drawing.Point(89, 11);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(712, 16);
            this.label98.TabIndex = 26;
            this.label98.Text = "Premere il pulsante per collegare pagamenti già esistenti alla Liquidazione IVA I" +
    "stituzionale Split Payment";
            // 
            // btnCollegaAltriSplit
            // 
            this.btnCollegaAltriSplit.Location = new System.Drawing.Point(8, 8);
            this.btnCollegaAltriSplit.Name = "btnCollegaAltriSplit";
            this.btnCollegaAltriSplit.Size = new System.Drawing.Size(75, 23);
            this.btnCollegaAltriSplit.TabIndex = 25;
            this.btnCollegaAltriSplit.Text = "Collega";
            this.btnCollegaAltriSplit.UseVisualStyleBackColor = true;
            this.btnCollegaAltriSplit.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridAltriIstituzionaleSplit
            // 
            this.gridAltriIstituzionaleSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAltriIstituzionaleSplit.CaptionVisible = false;
            this.gridAltriIstituzionaleSplit.DataMember = "";
            this.gridAltriIstituzionaleSplit.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAltriIstituzionaleSplit.Location = new System.Drawing.Point(8, 53);
            this.gridAltriIstituzionaleSplit.Name = "gridAltriIstituzionaleSplit";
            this.gridAltriIstituzionaleSplit.Size = new System.Drawing.Size(882, 197);
            this.gridAltriIstituzionaleSplit.TabIndex = 23;
            // 
            // lblcredito51
            // 
            this.lblcredito51.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito51.Location = new System.Drawing.Point(275, 463);
            this.lblcredito51.Name = "lblcredito51";
            this.lblcredito51.Size = new System.Drawing.Size(72, 16);
            this.lblcredito51.TabIndex = 100;
            // 
            // lblcredito21
            // 
            this.lblcredito21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito21.Location = new System.Drawing.Point(275, 359);
            this.lblcredito21.Name = "lblcredito21";
            this.lblcredito21.Size = new System.Drawing.Size(72, 16);
            this.lblcredito21.TabIndex = 99;
            // 
            // lblcredito11
            // 
            this.lblcredito11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblcredito11.Location = new System.Drawing.Point(275, 336);
            this.lblcredito11.Name = "lblcredito11";
            this.lblcredito11.Size = new System.Drawing.Size(72, 16);
            this.lblcredito11.TabIndex = 98;
            // 
            // txtIvaPeriodo1
            // 
            this.txtIvaPeriodo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIvaPeriodo1.Location = new System.Drawing.Point(166, 355);
            this.txtIvaPeriodo1.Name = "txtIvaPeriodo1";
            this.txtIvaPeriodo1.ReadOnly = true;
            this.txtIvaPeriodo1.Size = new System.Drawing.Size(96, 23);
            this.txtIvaPeriodo1.TabIndex = 97;
            this.txtIvaPeriodo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label95
            // 
            this.label95.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label95.Location = new System.Drawing.Point(48, 359);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(112, 16);
            this.label95.TabIndex = 96;
            this.label95.Text = "Iva del periodo";
            this.label95.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotaleIva1
            // 
            this.txtTotaleIva1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotaleIva1.Location = new System.Drawing.Point(166, 389);
            this.txtTotaleIva1.Name = "txtTotaleIva1";
            this.txtTotaleIva1.ReadOnly = true;
            this.txtTotaleIva1.Size = new System.Drawing.Size(96, 23);
            this.txtTotaleIva1.TabIndex = 95;
            this.txtTotaleIva1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSaldoCorr1
            // 
            this.lblSaldoCorr1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaldoCorr1.Location = new System.Drawing.Point(48, 396);
            this.lblSaldoCorr1.Name = "lblSaldoCorr1";
            this.lblSaldoCorr1.Size = new System.Drawing.Size(112, 16);
            this.lblSaldoCorr1.TabIndex = 94;
            this.lblSaldoCorr1.Text = "Totale iva";
            this.lblSaldoCorr1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSaldoPrec1
            // 
            this.txtSaldoPrec1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldoPrec1.Location = new System.Drawing.Point(166, 331);
            this.txtSaldoPrec1.Name = "txtSaldoPrec1";
            this.txtSaldoPrec1.ReadOnly = true;
            this.txtSaldoPrec1.Size = new System.Drawing.Size(96, 23);
            this.txtSaldoPrec1.TabIndex = 93;
            this.txtSaldoPrec1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label97
            // 
            this.label97.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label97.Location = new System.Drawing.Point(48, 338);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(112, 16);
            this.label97.TabIndex = 92;
            this.label97.Text = "Saldo precedente";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 509);
            this.panel1.TabIndex = 20;
            // 
            // Frm_ivapay_wizard_calcolo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_ivapay_wizard_calcolo";
            this.Text = "frmliquidazioneiva_calcolo";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabController.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEntrata)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
            this.tabpage1.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDebito)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAcquisti)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistipromiscui)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabIntra12.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliINTRA)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage9.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridacquistiistituzionaliSplit)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.tabPage13.ResumeLayout(false);
            this.tabPage13.PerformLayout();
            this.tabControlCollegaAltriPagamenti.ResumeLayout(false);
            this.tabPageAltri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAltri)).EndInit();
            this.tabPageAltriIntra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAltriIstituzionaleIntra)).EndInit();
            this.tabPageAltriSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAltriIstituzionaleSplit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public void MetaData_AfterLink() {
            errmsg = new Hashtable();
            errmsg.Add("err_persiva", "Impossibile proseguire. Non è stata definita la configurazione " +
                                      "del modulo IVA relativa all'esercizio corrente");
            errmsg.Add("err_codicetipoper", "Impossibile proseguire. Non è stato associato nessun tipo di " +
                                            "liquidazione periodica nella configurazione IVA relativo all'esercizio corrente");
            errmsg.Add("err_periodo",
                "Impossibile proseguire. Non è stato configurato correttamente il tipo di periodicità " +
                "della liquidazione IVA");
            errmsg.Add("err_paymentagency",
                "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA");
            errmsg.Add("err_refundagency",
                "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di entrata " +
                "della liquidazione IVA");
            errmsg.Add("err_paymentfin",
                "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
                "della liquidazione IVA");
            errmsg.Add("err_refundfin",
                "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di entrata " +
                "della liquidazione IVA");


            errmsg.Add("err_persiva12", "Impossibile proseguire. Non è stata definita la configurazione " +
                                        "del modulo IVA intrastat istituzionale relativa all'esercizio corrente");
            errmsg.Add("err_paymentagency12",
                "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA intrastat istituzionale ");
            errmsg.Add("err_refundagency12",
                "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di entrata " +
                "della liquidazione IVA intrastat istituzionale ");
            errmsg.Add("err_paymentfin12",
                "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
                "della liquidazione IVA intrastat istituzionale ");
            errmsg.Add("err_refundfin12",
                "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di entrata " +
                "della liquidazione IVA intrastat istituzionale ");


            errmsg.Add("err_paymentagencysplit",
                "Impossibile proseguire. Non è stata configurata l'anagrafica per i movimenti finanziari di spesa " +
                "della liquidazione IVA istituzionale Split Payment");
            errmsg.Add("err_paymentfinsplit",
                "Impossibile proseguire. Non è stata configurata la voce di bilancio per i movimenti finanziari di spesa " +
                "della liquidazione IVA istituzionale Split Payment");

            Meta = MetaData.GetMetaData(this);
            this.Conn = Meta.Conn;
            this.Disp = Meta.Dispatcher;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            esercizio = Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            GetData.SetStaticFilter(DS.config, filterEsercizio);
            //GetData.CacheTable(DS.iva_prorata,filterEsercizio,null,false);
            //GetData.CacheTable(DS.iva_mixed,filterEsercizio,null,false);
            //GetData.CacheTable(DS.entrysetup, filterEsercizio, null, false);
            GetData.CacheTable(DS.invoicekind);
            GetData.CacheTable(DS.ivaregisterkind);
            GetData.CacheTable(DS.invoicekindyear, filterEsercizio, null, false);
        }

        public void MetaData_AfterActivation() {
            FormInit();
            //DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.invoicedeferred,"yivapay,nivapay,idinvkind,yinv,ninv",null,null,true);
            maxfaseentrata = Meta.GetSys("maxincomephase");
            maxfasespesa = Meta.GetSys("maxexpensephase");
            DataRow CfgRow = DS.config.Rows[0];
            ModoCalcolo_RigaPerRiga = CfgRow["flagivapaybyrow"].ToString().ToUpper() == "S";
            if (CfgRow["flagivaregphase"].ToString().ToUpper() == "S")
                GeneraTuttelafasi = false;
            else
                GeneraTuttelafasi = true;
            startivabalance = CfgFn.GetNoNullDecimal(CfgRow["startivabalance"]);
            startivabalance12 = CfgFn.GetNoNullDecimal(CfgRow["startivabalance12"]);
            startivabalancesplit = CfgFn.GetNoNullDecimal(CfgRow["startivabalancesplit"]);
        }


        private void FormInit() {
            CustomTitle = "Calcola liquidazione periodica";
            txtProrata.Enter += new EventHandler(txtProrata_Enter);
            txtProrata.Leave += new EventHandler(txtProrata_Leave);
            txtPromiscuo.Enter += new EventHandler(txtPromiscuo_Enter);
            txtPromiscuo.Leave += new EventHandler(txtPromiscuo_Leave);
            CheckInit();
            //Selects first tab
            DisplayTabs(0);
            // Se il mese della data corrente è dicembre,
            // visualizza il checkbox che consente di
            // cambiare il periodo di riferimento
            // forzando la liquidazione relativa a tale mese 
            // invece del periodo precedente come avviene di norma
            //calcolo periodo
            DateTime data = ((DateTime) Meta.GetSys("datacontabile"));
            int month = data.Month;
            if (month == 12) chkEndOfYear.Visible = true;
            else chkEndOfYear.Visible = false;
            chkEndOfYear.Text = chkEndOfYear.Text + "" + HelpForm.StringValue(data.Year, null);
        }

        private void txtProrata_Enter(object sender, EventArgs e) {
            HelpForm.ExtEnterNumTextBox(txtProrata, tag_perc);
        }

        private void txtProrata_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveNumTextBox(txtProrata, tag_perc);
        }

        private void txtPromiscuo_Enter(object sender, EventArgs e) {
            HelpForm.ExtEnterNumTextBox(txtPromiscuo, tag_perc);
        }

        private void txtPromiscuo_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveNumTextBox(txtPromiscuo, tag_perc);
        }

        /// <summary>
        /// Messaggi di warning
        /// </summary>
        private void ShowMsg(string msg) {
            ShowMsg(msg, null);
        }

        /// <summary>
        /// Errori
        /// </summary>
        private void ShowMsg(string msg, string error) {
            if (error == null || error == "")
                MessageBox.Show(msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
                QueryCreator.ShowError(this, msg, error);
        }

        /// <summary>
        /// Controlla la presenza di righe di configurazione, persiva e tipoliquidperiodiva
        /// </summary>
        private void CheckInit() {
            if (DS.config.Rows.Count == 0) {
                ShowMsg(errmsg["err_persiva"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if (DS.config.Rows[0]["idivapayperiodicity"].ToString() == "") {
                ShowMsg(errmsg["err_codicetipoper"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagpayment"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["paymentagency"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentagency"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpayment12"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["paymentagency12"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentagency12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagrefund"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["refundagency"] == DBNull.Value)) {
                ShowMsg(errmsg["err_refundagency"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagrefund12"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["refundagency12"] == DBNull.Value)) {
                ShowMsg(errmsg["err_refundagency12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagpayment"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["idfinivapayment"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentfin"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpayment12"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["idfinivapayment12"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentfin12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagrefund"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["idfinivarefund"] == DBNull.Value)) {
                ShowMsg(errmsg["err_refundfin"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagrefund12"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["idfinivarefund12"] == DBNull.Value)) {
                ShowMsg(errmsg["err_refundfin12"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            if ((DS.config.Rows[0]["flagpaymentsplit"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["paymentagencysplit"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentagencysplit"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }
            if ((DS.config.Rows[0]["flagpaymentsplit"].ToString().ToUpper() == "S") &&
                (DS.config.Rows[0]["idfinivapaymentsplit"] == DBNull.Value)) {
                ShowMsg(errmsg["err_paymentfinsplit"].ToString());
                btnNext.Enabled = false;
                AllDisabled = true;
                return;
            }

            DataRow Rperiodo = DS.config.Rows[0].GetParentRow("ivapayperiodicity_config");
            if (Rperiodo == null ||
                Rperiodo["periodicity"].ToString() == "" ||
                Rperiodo["periodicmonth"].ToString() == "") {
                ShowMsg(errmsg["err_periodo"].ToString());
                btnNext.Enabled = false;
                return;
            }
            m_PeriodicitaMese = CfgFn.GetNoNullInt32(Rperiodo["periodicmonth"]);
            if (m_PeriodicitaMese < 0) m_PeriodicitaMese = 1;

            txtPeriodicita.Text = Rperiodo["description"].ToString();
            periodo = CfgFn.GetNoNullInt32(Rperiodo["periodicity"]);
            if (periodo <= 0) {
                ShowMsg(errmsg["err_periodo"].ToString());
                btnNext.Enabled = false;
                return;
            }
            //calcolo periodo
            ComputePeriod(periodo);


            int anno_rif = m_ToDate.Year;
            string f_anno = QHS.CmpEq("ayear", anno_rif);

            //default
            txtProrata.Text = "100,00 %";
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.iva_prorata, null, f_anno, null, true);
            if (DS.iva_prorata.Rows.Count > 0) {
                txtProrata.Text = HelpForm.StringValue(DS.iva_prorata.Rows[0]["prorata"], tag_perc);
            }
            //default
            txtPromiscuo.Text = "100,00 %";
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.iva_mixed, null, f_anno, null, true);
            if (DS.iva_mixed.Rows.Count > 0) {
                txtPromiscuo.Text = HelpForm.StringValue(DS.iva_mixed.Rows[0]["mixed"], tag_perc);
            }
            chkCommerciale.Checked = true;
            chkIstituzionale.Checked = true;
            chkIstituzionaleSplit.Checked = true;
        }


        private void ComputePeriod(int periodo) {
            //calcolo periodo default (periodo precedente)
            if (periodo <= 0) return;
            DateTime data = ((DateTime) Meta.GetSys("datacontabile"));
            int year = data.Year;
            int month = (data.Month - periodo > 0 ? data.Month - periodo : 12 + data.Month - periodo);
            //se sono a cavallo dell'anno nuovo la liquidazione cade nell'anno prima
            if ((month + periodo) > 12) {
                month = month - periodo + 1;
                year--;
            }
            DateTime FromDate = new DateTime(year, month, 1);
            m_ToDate = FromDate.AddMonths(periodo - 1);
            m_ToDate = m_ToDate.AddDays(DateTime.DaysInMonth(year, m_ToDate.Month) - 1);
            //forza la liquidazione del periodo corrente per il solo mese di dicembre
            //se è stata scelta tale opzione
            if ((chkEndOfYear.Checked) && (data.Month == 12)) {
                FromDate = m_ToDate.AddDays(1);
                m_ToDate = new DateTime(data.Year, 12, 31);
            }

            txtDal.Text = HelpForm.StringValue(FromDate, null);
            txtAl.Text = HelpForm.StringValue(m_ToDate, null);
			//rimuovo la valorizzazione in automatico della data regolamento (data esecuzione pagamento)
			//perchè in OPI Siope + causa lo scarto dei pagamenti a regolarizzazione (task 13949)
			//txtDataRegolamento.Text = HelpForm.StringValue(data, null);
		}

		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		private void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0) && (AllDisabled == false);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Fine.";
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            btnNext.Enabled = (AllDisabled == false);
        }

        bool AllDisabled = false;

        /// <summary>
        /// Changes tab backward/forward
        /// </summary>
        /// <param name="step"></param>
        private void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnCancel.Text = "Chiudi";
                AllDisabled = true;
                return;
            }
            DisplayTabs(newTab);
        }

        bool ErroriPresenti() {
            object esercizio = Meta.GetSys("esercizio");
            object date_from = HelpForm.GetObjectFromString(typeof(DateTime), txtDal.Text, null);
            object date_to = HelpForm.GetObjectFromString(typeof(DateTime), txtAl.Text, null);
            object kind = DBNull.Value;
            object[] param = new object[] {esercizio, date_from, date_to, kind };
            DataSet DScheck1 = Conn.CallSP("exp_invdetail_notequal_expense", param, true);
            if (DScheck1 != null && DScheck1.Tables.Count > 0) {
                DataTable Table1 = DScheck1.Tables[0];
                if (Table1.Rows.Count > 0) {
                    MessageBox.Show(this, "Ci sono fatture con pagamenti incoerenti. Correggere i dati prima di procedere.");
                    exportclass.DataTableToExcel(Table1, true);
                    return true;
                }
            }

            DataSet DScheck2 = Conn.CallSP("exp_invdetail_variation_notequal_expense", param, true);
            if (DScheck2 != null && DScheck2.Tables.Count > 0) {
                DataTable Table2 = DScheck2.Tables[0];
                if (Table2.Rows.Count > 0) {
                    MessageBox.Show(this, "Ci sono Note di variazione con pagamenti incoerenti. Correggere i dati prima di procedere.");
                    exportclass.DataTableToExcel(Table2, true);
                    return true;
                }
            }

            DataSet DScheck3 = Conn.CallSP("exp_invdetail_expensewithvar", param, true);
            if (DScheck3 != null && DScheck3.Tables.Count > 0) {
                DataTable Table3 = DScheck3.Tables[0];
                if (Table3.Rows.Count > 0) {
                    MessageBox.Show(this, "Ci sono pagamenti di fatture con variazioni che non contabilizzano documenti. Correggere i dati prima di procedere.");
                    exportclass.DataTableToExcel(Table3, true);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Must return true if operation is possible, and do any
        ///  operation related to change from tab oldTab to newTab
        /// </summary>
        /// <param name="oldTab"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        bool CustomChangeTab(int oldTab, int newTab) {
            if (AllDisabled) return false;
            if ((oldTab == 0) && (newTab == 1)) {
                if (!(chkCommerciale.Checked || chkIstituzionale.Checked || chkIstituzionaleSplit.Checked)) {
                    MessageBox.Show(this, "Selezionare il Tipo Liquidazione");
                    return false;
                }
                CheckDefault();
                if (ErroriPresenti()) return false;
                if (!CalcolaLiquidazione()) return false;
                CalcolaTotali();
                CalcolaIVA();
                return true;
            }
            if ((oldTab == 1) && (newTab == 2)) {

                if (!chkCommerciale.Checked) {
                    tabControlCollegaAltriPagamenti.TabPages.Remove(tabPageAltri);
                }

                if (!chkIstituzionale.Checked) {
                    tabControlCollegaAltriPagamenti.TabPages.Remove(tabPageAltriIntra);
                }


                if (!chkIstituzionaleSplit.Checked) {
                    tabControlCollegaAltriPagamenti.TabPages.Remove(tabPageAltriSplit);

                }

            }
            if ((oldTab == 2) && (newTab == 3)) {
                AbilitaCollegaMovEsistente();
                return GeneraMovimenti();
            }
            if ((oldTab == 3) && (newTab == 4)) {
                SaveData();
            }
            return true;
        }

        private void AbilitaCollegaMovEsistente() {
            int faselastI = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
            if (faselastI == 1)
                btnCollegaE.Enabled = false;
            else
                btnCollegaE.Enabled = true;

            int faselastE = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
            if (faselastE == 1)
                btnCollegaS.Enabled = false;
            else
                btnCollegaS.Enabled = true;

        }

        private void ImpostaLabel(decimal importo, Label lbl) {
            if (importo > 0)
                lbl.Text = "a debito";
            else {
                if (importo < 0)
                    lbl.Text = "a credito";
                else
                    lbl.Text = "";
            }
        }

        decimal totale_iva_debito = 0;
        decimal totale_iva_credito = 0;
        decimal totale_iva_debito12 = 0;
        decimal totale_iva_credito12 = 0;
        decimal totale_iva_debitosplit = 0;

        decimal vendite_immediata = 0;
        decimal vendite_deferred = 0;


        decimal acqcomm_immediata = 0;
        decimal acqcomm_immediata_indetr = 0;
        decimal acqcomm_deferred = 0;
        decimal acqcomm_deferred_indetr = 0;

        decimal acqprom_immediata = 0;
        decimal acqprom_immediata_indetr = 0;
        decimal acqprom_deferred = 0;
        decimal acqprom_deferred_indetr = 0;

        //decimal acqist_immediata = 0;
        //decimal acqist_deferred = 0;


        //decimal acqist_immediata_split = 0;
        //decimal acqist_deferred_split = 0;


        decimal saldo_precedente = 0; //si intende come IVA A DEBITO
        decimal saldo_precedente12 = 0; //si intende come IVA A DEBITO
        decimal saldo_precedentesplit = 0; //si intende come IVA A DEBITO

        decimal startivabalance;
        decimal startivabalance12;
        decimal startivabalancesplit;

        decimal ivadelperiodo = 0;
        decimal ivadelperiodo12 = 0;
        decimal ivadelperiodosplit = 0;

        decimal totaleiva = 0;
        decimal totaleiva12 = 0;
        decimal totaleivasplit = 0;

        decimal liquidazionecorrente = 0;
        decimal liquidazionecorrente12 = 0;
        decimal liquidazionecorrentesplit = 0;
        decimal nuovosaldo = 0;
        decimal nuovosaldo12 = 0;
        decimal nuovosaldosplit = 0;


        decimal credito_immediato = 0;
        decimal credito_differito = 0;
        decimal debito_immediato12 = 0;
        decimal debito_immediatosplit = 0;
        decimal debito_differito12 = 0;
        decimal debito_differitosplit = 0;
        decimal credito_immediato12 = 0;
        decimal credito_differito12 = 0;


        decimal impdebito_immediato12 = 0;
        decimal impdebito_immediatosplit = 0;
        decimal impdebito_differito12 = 0;
        decimal impdebito_differitosplit = 0;
        decimal impcredito_immediato12 = 0;
        decimal impcredito_differito12 = 0;



        decimal taxableintrastat12 = 0;
        decimal ivaintrastat12 = 0;

        decimal taxablesplit = 0;
        decimal ivasplit = 0;


        void CalcolaTabPageIva() {
            decimal perc_promiscuo = getPromiscuo();
            decimal perc_prorata = getProrata();
            credito_immediato = 0; //calcolati riga per riga
            credito_differito = 0; //calcolati riga per riga

            totale_iva_credito = 0; //somma definitiva del  prorata riga per riga oppure sul totale
            //in base alla configuraazione            
            vendite_immediata = 0;
            vendite_deferred = 0;


            debito_immediato12 = 0;
            debito_differito12 = 0;

            debito_immediatosplit = 0;
            debito_differitosplit = 0;

            credito_immediato12 = 0;
            credito_differito12 = 0;

            impdebito_immediato12 = 0;
            impdebito_differito12 = 0;
            impdebito_immediatosplit = 0;
            impdebito_differitosplit = 0;
            impcredito_immediato12 = 0;
            impcredito_differito12 = 0;




            acqcomm_immediata = 0;
            acqcomm_immediata_indetr = 0;
            acqcomm_deferred = 0;
            acqcomm_deferred_indetr = 0;

            acqprom_immediata = 0;
            acqprom_immediata_indetr = 0;
            acqprom_deferred = 0;
            acqprom_deferred_indetr = 0;

            //acqist_immediata = 0;
            //acqist_deferred = 0;

            //acqist_immediata_split = 0;
            //acqist_deferred_split = 0;

            TableIva.Columns.Add("singola", typeof(Decimal));
            //TableIva.Columns.Add("mixed", typeof(Decimal));
            foreach (DataRow R in TableIva.Rows) {
                bool istituzionale = false;
                bool commerciale = false;
                bool promiscuo = false;


                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;
                bool flagintracom = R["flagintracom"].ToString().ToUpper() != "N";
                bool flagExtraUe = R["flagintracom"].ToString().ToUpper() == "X";


                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 2) commerciale = true;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 3) promiscuo = true;


                bool immediata = R["flagdeferred"].ToString().ToUpper() == "N";
                //è il registro che determina la natura dell'operazione 
                bool acquisto = R["registerclass"].ToString().ToUpper() == "A";
                bool vendita = !acquisto;

                bool fatturaDiAcquisto = R["kind"].ToString().ToUpper() == "A";
                bool fatturaDiVendita = !fatturaDiAcquisto;

                bool flagsplit = R["flagsplit"].ToString().ToUpper() == "S";

                if (istituzionale && !flagintracom && !flagsplit) {
                    continue;
                }

                if (!istituzionale && flagsplit && fatturaDiVendita) {
                    continue;
                }

                decimal taxable = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal imposta = CfgFn.GetNoNullDecimal(R["currivagrosspayed"]);
                decimal indetraibile = CfgFn.GetNoNullDecimal(R["currivaunabatable"]);
                if (istituzionale) indetraibile = imposta;



                if (acquisto) {
                    decimal prorata_evalued = 0;
                    decimal promiscuo_evalued = 0;
                    decimal indetraibile_singolo = 0;

                    //calcola R["singola"],indetraibile_singolo
                    if (promiscuo) {
                        promiscuo_evalued = CfgFn.Round((imposta - indetraibile)*perc_promiscuo, 2);
                        prorata_evalued = CfgFn.Round((imposta - indetraibile)*perc_promiscuo*perc_prorata, 2);
                        if (ModoCalcolo_RigaPerRiga) {
                            //if (ModoCalcolo_RigaPerRiga)
                            R["singola"] = prorata_evalued;
                            indetraibile_singolo = imposta - prorata_evalued;
                        }
                        else {
                            R["singola"] = prorata_evalued;
                            indetraibile_singolo = indetraibile; // imposta - promiscuo_evalued;
                        }
                    }
                    if (commerciale) {
                        prorata_evalued = CfgFn.Round((imposta - indetraibile)*perc_prorata, 2);
                        if (ModoCalcolo_RigaPerRiga) {
                            R["singola"] = prorata_evalued;
                            indetraibile_singolo = imposta - prorata_evalued;
                        }
                        else {
                            R["singola"] = prorata_evalued; // imposta - indetraibile;
                            indetraibile_singolo = indetraibile;
                        }
                    }
                    if (istituzionale) {
                        R["singola"] = imposta; // imposta - indetraibile;
                        indetraibile_singolo = imposta;
                    }



                    if (immediata) {
                        if (promiscuo) {
                            acqprom_immediata += imposta;
                            acqprom_immediata_indetr += indetraibile_singolo;
                        }
                        if (commerciale) {
                            acqcomm_immediata += imposta;
                            acqcomm_immediata_indetr += indetraibile_singolo;
                        }
                        if (istituzionale) {
                            if (flagintracom) {
                                debito_immediato12 += imposta;
                                impdebito_immediato12 += taxable;
                            }
                            if (flagsplit) {
                                debito_immediatosplit += imposta;
                                impdebito_immediatosplit += taxable;
                            }
                        }
                    }
                    else {
                        if (promiscuo) {
                            acqprom_deferred += imposta;
                            acqprom_deferred_indetr += indetraibile_singolo;
                        }
                        if (commerciale) {
                            acqcomm_deferred += imposta;
                            acqcomm_deferred_indetr += indetraibile_singolo;
                        }
                        if (istituzionale) {
                            if (flagintracom) {
                                debito_differito12 += imposta;
                                impdebito_differito12 += taxable;
                            }
                            if (flagsplit) {
                                debito_differitosplit += imposta;
                                impdebito_differitosplit += taxable;
                            }
                        }
                    }
                    if (!istituzionale) {
                        totale_iva_credito += prorata_evalued;
                        if (immediata)
                            credito_immediato += prorata_evalued; //E' comunque calcolato sulla base riga per riga
                        else
                            credito_differito += prorata_evalued; // ma non è visualizzato 
                    }
                }
                else {
                    //vendita
                    if (istituzionale) {
                        //le vendite istituzionali incrementano il credito (anche se non dovrebbero esisterne
                        if (immediata) {
                            if (flagintracom) {
                                credito_immediato12 += imposta;
                                impcredito_immediato12 += taxable;
                            }
                        }
                        else {
                            if (flagintracom) {
                                credito_differito12 += imposta;
                                impcredito_differito12 += taxable;
                            }
                        }
                    }
                    if (!istituzionale) {

                        if (immediata) {
                            vendite_immediata += imposta;
                        }
                        else {
                            vendite_deferred += imposta;
                        }


                    }

                    R["singola"] = imposta;
                }

            } //foreach

            txtIvaDebitoImmediata.Text = vendite_immediata.ToString("c");
            txtIvaDebitoDifferita.Text = vendite_deferred.ToString("c");

            txtIvaCreditoTotaleImmediata.Text = acqcomm_immediata.ToString("c");
            txtIndetraibileImmediata.Text = acqcomm_immediata_indetr.ToString("c");
            decimal detraibile_immediata_comm = acqcomm_immediata - acqcomm_immediata_indetr;
            txtIvaCreditoImmediata.Text = detraibile_immediata_comm.ToString("c");

            txtIvaCreditoTotaleDifferita.Text = acqcomm_deferred.ToString("c");
            txtIndetraibileDifferita.Text = acqcomm_deferred_indetr.ToString("c");
            decimal detraibile_differita_comm = acqcomm_deferred - acqcomm_deferred_indetr;
            txtIvaCreditoDifferita.Text = detraibile_differita_comm.ToString("c");


            decimal detraibile_commerciale = detraibile_immediata_comm + detraibile_differita_comm;
            txtIvaCreditoTotaleCommerciale.Text = detraibile_commerciale.ToString("c");


            txtIvaCreditoTotaleImmediataPromiscui.Text = acqprom_immediata.ToString("c");
            txtIndetraibileImmediataPromiscui.Text = acqprom_immediata_indetr.ToString("c");
            decimal detraibile_immediata_prom = acqprom_immediata - acqprom_immediata_indetr;
            txtIvaCreditoImmediataPromiscui.Text = detraibile_immediata_prom.ToString("c");

            txtIvaCreditoTotaleDifferitaPromiscui.Text = acqprom_deferred.ToString("c");
            txtIndetraibileDifferitaPromiscui.Text = acqprom_deferred_indetr.ToString("c");
            decimal detraibile_differita_prom = acqprom_deferred - acqprom_deferred_indetr;
            txtIvaCreditoDifferitaPromiscui.Text = detraibile_differita_prom.ToString("c");


            decimal detraibile_promiscui = detraibile_immediata_prom + detraibile_differita_prom;
            txtIvaCreditoTotalePromiscui.Text = detraibile_promiscui.ToString("c");

            decimal detraibile_promiscuiPOST = detraibile_promiscui;
            if (!ModoCalcolo_RigaPerRiga) {
                labTotIvaPromPOST.Visible = true;
                txtIvaCreditoTotalePromiscuiPOST.Visible = true;
                //promiscuo_evalued = CfgFn.Round((imposta - indetraibile) * perc_promiscuo, 2);
                detraibile_promiscuiPOST = CfgFn.Round(
                    detraibile_promiscui*perc_promiscuo, 2);
                txtIvaCreditoTotalePromiscuiPOST.Text = detraibile_promiscuiPOST.ToString("c");
            }
            else {
                labTotIvaPromPOST.Visible = false;
                txtIvaCreditoTotalePromiscuiPOST.Visible = false;
            }



            totale_iva_debito = vendite_immediata + vendite_deferred;
            txtIvaDebito.Text = totale_iva_debito.ToString("c");

            decimal ivacredito = detraibile_commerciale + detraibile_promiscuiPOST;
            txtIvaCredito.Text = ivacredito.ToString("c");

            if (!ModoCalcolo_RigaPerRiga) {
                labTotDopoProrata.Visible = true;
                txtIvaCreditoProrata.Visible = true;
                //decimal ivacredito = detraibile_commerciale + detraibile_promiscui;
                totale_iva_credito = CfgFn.Round(ivacredito*perc_prorata, 2);
                txtIvaCreditoProrata.Text = totale_iva_credito.ToString("c");
            }
            else {
                labTotDopoProrata.Visible = false;
                txtIvaCreditoProrata.Visible = false;
            }

            ivadelperiodo = totale_iva_debito - totale_iva_credito;

            decimal netto_ivadeb_imm = debito_immediato12 - credito_immediato12;
            decimal netto_impdeb_imm = impdebito_immediato12 - impcredito_immediato12;
            txtImpIstituzImmed.Text = netto_impdeb_imm.ToString("c");
            txtIvaIstituzImmed.Text = netto_ivadeb_imm.ToString("c");

            decimal netto_ivadeb_def = debito_differito12 - credito_differito12;
            decimal netto_impdeb_def = impdebito_differito12 - impcredito_differito12;
            txtImpIstituzDeferr.Text = netto_impdeb_def.ToString("c");
            txtIvaIstituzDeferr.Text = netto_ivadeb_def.ToString("c");


            decimal netto_iva12 = netto_ivadeb_imm + netto_ivadeb_def;
            decimal netto_impo12 = netto_impdeb_imm + netto_impdeb_def;
            taxableintrastat12 = netto_impo12;
            ivaintrastat12 = netto_iva12;

            totale_iva_debito12 = debito_immediato12 + debito_differito12;
            totale_iva_credito12 = credito_immediato12 + credito_differito12;

            txtTotImpIstituz.Text = netto_impo12.ToString("c");
            txtTotIvaIstituz.Text = netto_iva12.ToString("c");

            txtTotIvaIstituzIntrastat.Text = netto_iva12.ToString("c");
            ivadelperiodo12 = netto_iva12;

            decimal netto_ivadeb_imm_split = debito_immediatosplit;
            decimal netto_impdeb_imm_split = impdebito_immediatosplit;
            txtImpIstituzImmedSplit.Text = netto_impdeb_imm_split.ToString("c");
            txtIvaIstituzImmedSplit.Text = netto_ivadeb_imm_split.ToString("c");

            decimal netto_ivadeb_def_split = debito_differitosplit;
            decimal netto_impdeb_def_split = impdebito_differitosplit;
            txtImpIstituzDeferrSplit.Text = netto_impdeb_def_split.ToString("c");
            txtIvaIstituzDeferrSplit.Text = netto_ivadeb_def_split.ToString("c");


            decimal netto_ivasplit = netto_ivadeb_imm_split + netto_ivadeb_def_split;
            decimal netto_imposplit = netto_impdeb_imm_split + netto_impdeb_def_split;
            taxablesplit = netto_imposplit;
            ivasplit = netto_ivasplit;

            totale_iva_debitosplit = debito_immediatosplit + debito_differitosplit;

            txtTotImpIstituzSplit.Text = netto_imposplit.ToString("c");
            txtTotIvaIstituzionaleSplit.Text = netto_ivasplit.ToString("c");

            txtTotIvaIstituzSplit.Text = netto_ivasplit.ToString("c");
            ivadelperiodosplit = netto_ivasplit;


        }

        private void CalcolaTotali() {

            CalcolaTabPageIva();

            txtIvaPeriodo.Text = Math.Abs(ivadelperiodo).ToString("c");
            ImpostaLabel(ivadelperiodo, lblcredito2);
            txtIvaPeriodo1.Text = Math.Abs(ivadelperiodo).ToString("c");
            //ImpostaLabel(ivadelperiodo, lblcredito2);

            txtIvaPeriodo12.Text = Math.Abs(ivadelperiodo12).ToString("c");
            ImpostaLabel(ivadelperiodo12, lblcredito2__12);
            txtIvaPeriodo121.Text = Math.Abs(ivadelperiodo12).ToString("c");
            //ImpostaLabel(ivadelperiodo12, lblcredito2__12);

            txtIvaPeriodo__split.Text = Math.Abs(ivadelperiodosplit).ToString("c");
            ImpostaLabel(ivadelperiodosplit, lblcredito2__split);

            txtIvaPeriodo__split1.Text = Math.Abs(ivadelperiodosplit).ToString("c");
            //ImpostaLabel(ivadelperiodosplit, lblcredito2__split);

            bool movfinanziariConfig = false;
            if (!MovimentiFinanziariConfigurati()) {
                liquidazionecorrente = ivadelperiodo;
                movfinanziariConfig = false;
                //return;
            }
            else {
                movfinanziariConfig = true;
            }

            bool movfinanziariConfig12 = false;
            if (!MovimentiFinanziariConfigurati12()) {
                liquidazionecorrente12 = ivadelperiodo12;
                movfinanziariConfig12 = false;
                //return;
            }
            else {
                movfinanziariConfig12 = true;
            }

            bool movfinanziariConfigSplit = false;
            if (!MovimentiFinanziariConfiguratiSplit()) {
                liquidazionecorrentesplit = ivadelperiodosplit;
                movfinanziariConfigSplit = false;
                //return;
            }
            else {
                movfinanziariConfigSplit = true;
            }


            string filter = QHS.AppAnd(QHS.CmpEq("yivapay", esercizio), QHS.BitSet("flag", 0));
            string filter12 = QHS.AppAnd(QHS.CmpEq("yivapay", esercizio), QHS.BitSet("flag", 1));
            string filterSplit = QHS.AppAnd(QHS.CmpEq("yivapay", esercizio), QHS.BitSet("flag", 2));
            if (chkEndOfYear.Checked == false) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("paymentkind", "C"));
                filter12 = QHS.AppAnd(filter12, QHS.CmpEq("paymentkind", "C"));
                filterSplit = QHS.AppAnd(filterSplit, QHS.CmpEq("paymentkind", "C"));
            }

            string sql = "SELECT SUM(paymentamount) AS paymentamount, "
                         + "SUM(refundamount) AS refundamount, "
                         + "SUM(totaldebit) AS totaldebit, "
                         + "SUM(totalcredit) AS totalcredit "
                         + "FROM ivapay WHERE ";

            DataTable T = Conn.SQLRunner(sql + filter, false);

            string sql12 = "SELECT SUM(paymentamount12) as paymentamount12,"
                           + " SUM(refundamount12) as refundamount12, "
                           + " SUM(totaldebit12) as totaldebit12,"
                           + " SUM(totalcredit12) as totalcredit12 "
                           + "FROM ivapay  WHERE ";
            DataTable T12 = Conn.SQLRunner(sql12 + filter12, false);


            string sqlSplit = "SELECT SUM(paymentamountsplit) as paymentamountsplit,"
                              + " SUM(totaldebitsplit) as totaldebitsplit "
                              + "FROM ivapay WHERE ";

            DataTable TSplit = Conn.SQLRunner(sqlSplit + filterSplit, false);


            saldo_precedente = 0;
            saldo_precedente12 = 0;
            saldo_precedentesplit = 0;
            //saldoiniziale= saldo iniziale dell'anno: (si intende: positivo= a debito)

            decimal saldoiniziale = 0;
            if (chkCommerciale.Checked) {
                saldoiniziale = -startivabalance;
            }

            decimal saldoiniziale12 = 0;
            if (chkIstituzionale.Checked) {
                saldoiniziale12 = -startivabalance12;
            }

            decimal saldoinizialeslpit = 0;
            if (chkIstituzionaleSplit.Checked) {
                saldoinizialeslpit = -startivabalancesplit;
            }


            saldo_precedente = saldoiniziale;
            saldo_precedente12 = saldoiniziale12;
            saldo_precedentesplit = saldoinizialeslpit;

            if (T != null && T.Rows.Count > 0) {
                DataRow R = T.Rows[0];


                if (chkCommerciale.Checked) {

                    saldo_precedente = saldo_precedente
                                       + CfgFn.GetNoNullDecimal(R["totaldebit"])
                                       - CfgFn.GetNoNullDecimal(R["paymentamount"])

                                       - CfgFn.GetNoNullDecimal(R["totalcredit"])
                                       + CfgFn.GetNoNullDecimal(R["refundamount"]);
                }




            }
            if (T12 != null && T12.Rows.Count > 0) {
                DataRow R12 = T12.Rows[0];
                if (chkIstituzionale.Checked) {
                    saldo_precedente12 = saldo_precedente12
                                         + CfgFn.GetNoNullDecimal(R12["totaldebit12"])
                                         - CfgFn.GetNoNullDecimal(R12["paymentamount12"])

                                         - CfgFn.GetNoNullDecimal(R12["totalcredit12"])
                                         + CfgFn.GetNoNullDecimal(R12["refundamount12"]);
                }

            }
            if (TSplit != null && TSplit.Rows.Count > 0) {
                DataRow RSplit = TSplit.Rows[0];
                if (chkIstituzionaleSplit.Checked) {
                    saldo_precedentesplit = saldo_precedentesplit
                                            + CfgFn.GetNoNullDecimal(RSplit["totaldebitsplit"])
                                            - CfgFn.GetNoNullDecimal(RSplit["paymentamountsplit"]);
                }
            }




            if ((movfinanziariConfig) && (chkCommerciale.Checked)) {
                txtSaldoPrec.Text = Math.Abs(saldo_precedente).ToString("c");
                txtSaldoPrec1.Text = Math.Abs(saldo_precedente).ToString("c");
                ImpostaLabel(saldo_precedente, lblcredito1);
                ImpostaLabel(saldo_precedente, lblcredito11);
                totaleiva = ivadelperiodo + saldo_precedente;
                txtTotaleIva.Text = Math.Abs(totaleiva).ToString("c");
                txtTotaleIva1.Text = Math.Abs(totaleiva).ToString("c");
                ImpostaLabel(totaleiva, labCredito3);
                ImpostaLabel(totaleiva, labCredito31);
                liquidazionecorrente = 0;
                if (controllaSeCreareAutomatismi(totaleiva)) {
                    liquidazionecorrente = totaleiva;
                }

                txtLiquidMese.Text = Math.Abs(liquidazionecorrente).ToString("c");
                txtLiquidMese1.Text = Math.Abs(liquidazionecorrente).ToString("c");
                ImpostaLabel(liquidazionecorrente, labCredito4);
                ImpostaLabel(liquidazionecorrente, labCredito41);
                nuovosaldo = totaleiva - liquidazionecorrente;
                txtNuovoSaldo.Text = Math.Abs(nuovosaldo).ToString("c");
                txtNuovoSaldo1.Text = Math.Abs(nuovosaldo).ToString("c");
                ImpostaLabel(nuovosaldo, lblcredito5);
                ImpostaLabel(nuovosaldo, lblcredito51);
            }
            else {
                liquidazionecorrente = 0;
                txtSaldoPrec.Text = "";
                txtSaldoPrec1.Text = "";
                txtTotaleIva.Text = "";
                txtTotaleIva1.Text = "";
                txtLiquidMese.Text = "";
                txtLiquidMese1.Text = "";
                txtNuovoSaldo.Text = "";
                txtNuovoSaldo1.Text = "";
                lblcredito1.Text = "";
                lblcredito11.Text = "";
                labCredito3.Text = "";
                labCredito31.Text = "";
                labCredito4.Text = "";
                labCredito41.Text = "";
                lblcredito5.Text = "";
                lblcredito51.Text = "";
            }

            if ((movfinanziariConfig12) && (chkIstituzionale.Checked)) {
                txtSaldoPrec12.Text = Math.Abs(saldo_precedente12).ToString("c");
                txtSaldoPrec121.Text = Math.Abs(saldo_precedente12).ToString("c");
                ImpostaLabel(saldo_precedente12, lab_credito1_12);
                ImpostaLabel(saldo_precedente12, lblcredito1__12);
                totaleiva12 = ivadelperiodo12 + saldo_precedente12;
                txtTotaleIva12.Text = Math.Abs(totaleiva12).ToString("c");
                txtTotaleIva121.Text = Math.Abs(totaleiva12).ToString("c");
                ImpostaLabel(totaleiva12, lab_credito3_12);
                ImpostaLabel(totaleiva12, lab_credito3_121);
                liquidazionecorrente12 = 0;
                if (controllaSeCreareAutomatismi12(totaleiva12)) {
                    liquidazionecorrente12 = totaleiva12;
                }

                txtLiquidMese12.Text = Math.Abs(liquidazionecorrente12).ToString("c");
                txtLiquidMese121.Text = Math.Abs(liquidazionecorrente12).ToString("c");
                ImpostaLabel(liquidazionecorrente12, lab_credito4_12);
                ImpostaLabel(liquidazionecorrente12, lab_credito4_121);
                nuovosaldo12 = totaleiva12 - liquidazionecorrente12;
                txtNuovoSaldo12.Text = Math.Abs(nuovosaldo12).ToString("c");
                txtNuovoSaldo121.Text = Math.Abs(nuovosaldo12).ToString("c");
                ImpostaLabel(nuovosaldo12, lab_credito5_12);
                ImpostaLabel(nuovosaldo12, lblcredito5__121);
            }
            else {
                liquidazionecorrente12 = 0;
                txtSaldoPrec12.Text = "";
                txtSaldoPrec121.Text = "";
                txtTotaleIva12.Text = "";
                txtTotaleIva121.Text = "";
                txtLiquidMese12.Text = "";
                txtLiquidMese121.Text = "";
                txtNuovoSaldo12.Text = "";
                txtNuovoSaldo121.Text = "";
                lab_credito1_12.Text = "";

                lab_credito3_12.Text = "";
                lab_credito4_12.Text = "";
                lab_credito5_12.Text = "";
            }

            if ((movfinanziariConfigSplit) && (chkIstituzionaleSplit.Checked)) {
                txtSaldoPrec__split.Text = Math.Abs(saldo_precedentesplit).ToString("c");
                txtSaldoPrec__split1.Text = Math.Abs(saldo_precedentesplit).ToString("c");
                ImpostaLabel(saldo_precedentesplit, lblcredito1__split);
                ImpostaLabel(saldo_precedentesplit, lblcredito1__split1);
                totaleivasplit = ivadelperiodosplit + saldo_precedentesplit;
                txtTotaleIva__split.Text = Math.Abs(totaleivasplit).ToString("c");
                txtTotaleIva__split1.Text = Math.Abs(totaleivasplit).ToString("c");
                ImpostaLabel(totaleivasplit, labCredito3__split);
                ImpostaLabel(totaleivasplit, labCredito3__split1);

                liquidazionecorrentesplit = 0;
                if (controllaSeCreareAutomatismiSplit(totaleivasplit)) {
                    liquidazionecorrentesplit = totaleivasplit;
                }

                txtLiquidMese__split.Text = Math.Abs(liquidazionecorrentesplit).ToString("c");
                txtLiquidMese__split1.Text = Math.Abs(liquidazionecorrentesplit).ToString("c");
                ImpostaLabel(liquidazionecorrentesplit, labCredito4__split);
                ImpostaLabel(liquidazionecorrentesplit, labCredito4__split1);
                nuovosaldosplit = totaleivasplit - liquidazionecorrentesplit;
                txtNuovoSaldo__split.Text = Math.Abs(nuovosaldosplit).ToString("c");
                txtNuovoSaldo__split1.Text = Math.Abs(nuovosaldosplit).ToString("c");
                ImpostaLabel(nuovosaldosplit, lblcredito5__split);
                ImpostaLabel(nuovosaldosplit, lblcredito5__split1);

            }
            else {
                liquidazionecorrentesplit = 0;
                txtSaldoPrec__split.Text = "";
                txtSaldoPrec__split1.Text = "";
                txtTotaleIva__split.Text = "";
                txtTotaleIva__split1.Text = "";
                txtLiquidMese__split.Text = "";
                txtLiquidMese__split1.Text = "";
                txtNuovoSaldo__split.Text = "";
                txtNuovoSaldo__split1.Text = "";
                lblcredito1__split.Text = "";
                lblcredito1__split1.Text = "";
                labCredito3__split.Text = "";
                labCredito3__split1.Text = "";
                labCredito4__split.Text = "";
                labCredito4__split1.Text = "";
                lblcredito5__split.Text = "";
                lblcredito5__split1.Text = "";
            }
        }

        private void AddRowToTable(DataRow R, DataTable T, int i) {
            Meta.SetDefaults(T);
            DataRow NewR = T.NewRow();
            if (T.TableName == "incomeview") {
                NewR["idinc"] = i;
            }
            if (T.TableName == "expenseview") {
                NewR["idexp"] = i;
            }
            string descr = "Liquidazione periodica IVA";
            bool intra12 = false;
            if (R["autokind"].ToString() == "17") intra12 = true;
            if (intra12) descr = "Liquidazione periodica IVA Intrastat Istituzionale";

            bool split = false;
            if (R["autokind"].ToString() == "23")
                split = true;
            if (split)
                descr = "Liquidazione periodica IVA Istituzionale Split Payment";


            NewR["description"] = descr + "- dal " + txtDal.Text + " al " + txtAl.Text;

            foreach (DataColumn C in R.Table.Columns) {
                if (C.ColumnName == "movkind") continue;
                if (T.Columns[C.ColumnName] == null) continue;
                NewR[C.ColumnName] = R[C.ColumnName];
            }
            T.Rows.Add(NewR);
        }

        private void FillTables(DataRow[] Automatismi) {
            DS.expenseview.Clear();
            DS.incomeview.Clear();
            for (int i = 0; i < Automatismi.Length; i++) {
                DataRow R = Automatismi[i];
                switch (R["movkind"].ToString().ToLower()) {
                    case "spesa": {
                        AddRowToTable(R, DS.expenseview, i);
                        break;
                    }
                    case "entrata": {
                        AddRowToTable(R, DS.incomeview, i);
                        break;
                    }
                }
            }
            MetaData MSpesaView = Disp.Get("expenseview");
            MSpesaView.DescribeColumns(DS.expenseview, "autogeneratips");

            MetaData MEntrataView = Disp.Get("incomeview");
            MEntrataView.DescribeColumns(DS.incomeview, "autogeneratips");

            //gridEntrata.DataSource = null;
            //gridSpesa.DataSource = null;

            HelpForm.SetDataGrid(gridEntrata, DS.incomeview);
            HelpForm.SetDataGrid(gridSpesa, DS.expenseview);

            RicalcolaCampiCalcolati();

            if (liquidazionecorrente > 0) {
                foreach (DataRow R in AltriPagamenti.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, null, QHS.CmpEq("idexp", R["idexp"]),
                        null, true);

                    DataRow[] RowsExpense = DS.expenseview.Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 12;
                    }

                }
            }

            if (liquidazionecorrente12 > 0) {
                foreach (DataRow R in AltriPagamentiIntraExtraUe.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, null, QHS.CmpEq("idexp", R["idexp"]),
                        null, true);

                    DataRow[] RowsExpense = DS.expenseview.Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 17;
                    }

                }
            }

            if (liquidazionecorrentesplit > 0) {
                foreach (DataRow R in AltriPagamentiIstituzionaleSplitPayment.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expenseview, null, QHS.CmpEq("idexp", R["idexp"]),
                        null, true);

                    DataRow[] RowsExpense = DS.expenseview.Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 23;
                    }
                }
            }
        }

        /// <summary>
        /// Calcola la sp compute_ivapay e scarta le righe che non sono comprese nella selezione dei flag effettuata dall'utente
        /// </summary>
        /// <returns></returns>
        bool CalcolaLiquidazione() {
            object date_from = HelpForm.GetObjectFromString(typeof(DateTime), txtDal.Text, null);
            object date_to = HelpForm.GetObjectFromString(typeof(DateTime), txtAl.Text, null);
            object[] param = new object[] {date_from, date_to};
            DataSet DSiva = Conn.CallSP("compute_ivapay", param, true);
            if (DSiva == null || DSiva.Tables.Count == 0) return false;
            TableIva = DSiva.Tables[0];
            bool comm_promiscua = chkCommerciale.Checked;
            bool istituzionale = chkIstituzionale.Checked;
            bool split = chkIstituzionaleSplit.Checked;
            foreach (DataRow R in TableIva.Select()) {
                //se istituzionale e non split e NON HO selezionato istituzionale, saltiamo la fattura
                if ((CfgFn.GetNoNullInt32(R["flagactivity"]) == 1 && R["flagsplit"].ToString().ToUpper() == "N") &&
                    (!istituzionale)) {
                    R.Delete();
                    continue;
                }
                //se istituzionale e anche split e NON HO selezionato split, saltiamo la fattura
                if ((CfgFn.GetNoNullInt32(R["flagactivity"]) == 1 && R["flagsplit"].ToString().ToUpper() == "S") &&
                    (!split)) {
                    R.Delete();
                    continue;
                }
                //Se non è istituzionale e NON ho selezionato commerciale promiscuo saltiamo la fattura
                if ((CfgFn.GetNoNullInt32(R["flagactivity"]) != 1) && (!comm_promiscua)) {
                    R.Delete();
                    continue;
                }
            }
            TableIva.AcceptChanges();
            return true;
        }


        DataTable TableIva = null;

        private bool GeneraMovimenti() {
            DS.incomeview.Clear();
            DS.expenseview.Clear();
            DataTable movimentiIVA = CalcolaMovFinanziari(TableIva);
            if (movimentiIVA == null) return false;
            if (movimentiIVA.Rows.Count == 0) return true;
            TAutomatismi = movimentiIVA;
            RighePadriEntrata = new Hashtable();
            RighePadriSpesa = new Hashtable();
            FillTables(TAutomatismi.Select());
            return true;
        }

        /// <summary>
        /// Metodo che scrive i dati in INVOICEDEFERRED.
        /// Attenzione! INVOICEDEFERRED ha cambiato concetto. Vengono memorizzate in tale tabella tutti i documenti IVA
        /// sia che essi abbiano IVA immediata sia che abbiano IVA differita
        /// </summary>
        /// <param name="rIvaPay">DataRow della liquidazione IVA corrente</param>
        /// <returns></returns>
        private void creaRigheInvoiceDeferred(DataRow rIvaPay) {
            DataTable fatture = TableIva;
            string filtro = QHC.FieldIn("registerclass", new object[] {"A", "V"});
            DataRow[] fattureDaInserire = fatture.Select(filtro);
            if (fattureDaInserire.Length == 0) return;
            MetaData MetaInvoiceDeferred = MetaData.GetMetaData(this, "invoicedeferred");
            MetaInvoiceDeferred.SetDefaults(DS.invoicedeferred);
            foreach (DataRow rFattura in fattureDaInserire) {
                int sign = +1;
                if (rFattura["flagvariation"].ToString().ToUpper() == "S") sign = -sign;
                if (rFattura["registerclass"].ToString().ToUpper() != rFattura["kind"].ToString().ToUpper())
                    sign = -sign;
                if (CfgFn.GetNoNullDecimal(rFattura["currivagrosspayed"]) == 0) continue;
                DataRow rInvDef;
                string filter = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]),
                    QHC.CmpEq("yinv", rFattura["yinv"]),
                    QHC.CmpEq("ninv", rFattura["ninv"]));
                DataRow[] Inv = DS.invoicedeferred.Select(filter);
                if (Inv.Length != 0) {
                    rInvDef = Inv[0];
                    rInvDef["ivatotalpayed"] = CfgFn.GetNoNullDecimal(rInvDef["ivatotalpayed"]) +
                                               sign*CfgFn.GetNoNullDecimal(rFattura["currivagrosspayed"]);
                }
                else {
                    rInvDef = MetaInvoiceDeferred.Get_New_Row(rIvaPay, DS.invoicedeferred);
                    rInvDef["idinvkind"] = rFattura["idinvkind"];
                    rInvDef["yinv"] = rFattura["yinv"];
                    rInvDef["ninv"] = rFattura["ninv"];
                    rInvDef["ivatotalpayed"] = sign*CfgFn.GetNoNullDecimal(rFattura["currivagrosspayed"]);
                }
            }
        }

        private void creaRigheInvoiceDetailDeferred(DataRow rIvaPay) {
            DataTable fatture = TableIva;
            string filtro = QHC.FieldIn("registerclass", new object[] {"A", "V"});
            DataRow[] fattureDaInserire = fatture.Select(filtro);
            if (fattureDaInserire.Length == 0)
                return;
            MetaData MetaInvoiceDetailDeferred = MetaData.GetMetaData(this, "invoicedetaildeferred");
            MetaInvoiceDetailDeferred.SetDefaults(DS.invoicedetaildeferred);
            foreach (DataRow rFattura in fattureDaInserire) {
                int sign = +1;
                if (rFattura["flagvariation"].ToString().ToUpper() == "S")
                    sign = -sign;
                if (rFattura["registerclass"].ToString().ToUpper() != rFattura["kind"].ToString().ToUpper())
                    sign = -sign;
                if (CfgFn.GetNoNullDecimal(rFattura["currivagrosspayed"]) == 0)
                    continue;
                DataRow rInvDef;
                rInvDef = MetaInvoiceDetailDeferred.Get_New_Row(rIvaPay, DS.invoicedetaildeferred);
                rInvDef["idivaregisterkind"] = rFattura["idivaregisterkind"];
                rInvDef["idinvkind"] = rFattura["idinvkind"];
                rInvDef["yinv"] = rFattura["yinv"];
                rInvDef["ninv"] = rFattura["ninv"];
                rInvDef["rownum"] = rFattura["rownum"];
                rInvDef["taxable"] = rFattura["taxable"];
                rInvDef["ivatotalpayed"] = sign*CfgFn.GetNoNullDecimal(rFattura["currivagrosspayed"]);
            }
        }

        /// <summary>
        /// Metodo che calcola i movimenti finanziari inerenti la liquidazione IVA
        /// </summary>
        /// <param name="dettagliLiquidazione">Tabella con tutti i documenti IVA che vengono liquidati</param>
        /// <returns>DataTable dei movimenti finanziari</returns>
        private DataTable CalcolaMovFinanziari(DataTable dettagliLiquidazione) {
            DataTable movimentiIVA = new DataTable();
            movimentiIVA.TableName = "movimentiiva";
            movimentiIVA.Columns.Add("movkind", typeof(string));
            movimentiIVA.Columns.Add("idreg", typeof(decimal));
            movimentiIVA.Columns.Add("idfin", typeof(int));
            movimentiIVA.Columns.Add("idupb", typeof(string));
            movimentiIVA.Columns.Add("amount", typeof(decimal));
            movimentiIVA.Columns.Add("registry", typeof(string));
            movimentiIVA.Columns.Add("codefin", typeof(string));
            movimentiIVA.Columns.Add("codeupb", typeof(string));
            movimentiIVA.Columns.Add("idmovimento", typeof(int));
            movimentiIVA.Columns.Add("parentidmov", typeof(int));
            movimentiIVA.Columns.Add("autokind", typeof(int));

            DataRow rConfIVA = DS.config.Rows[0];
            //string elencoCampi = "refundagencytitle, paymentagencytitle, codefinivarefund, codefinivapayment";


            //liquidazionecorrente è l'importo da liquidare, positivo se a debito
            if ((MovimentiFinanziariConfigurati()) && (chkCommerciale.Checked)) {
                object idregpayment = rConfIVA["paymentagency"];
                object paymentagencytitle = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregpayment),
                    "title");

                object idfinpayment = rConfIVA["idfinivapayment"];
                object codefinivapayment = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinpayment), "codefin");

                object idregrefund = rConfIVA["refundagency"];
                object refundagencytitle = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregrefund), "title");

                object idfinrefund = rConfIVA["idfinivarefund"];
                object codefinivarefund = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinrefund), "codefin");

                string idUpb = "0001";
                object codeUpb = Meta.Conn.DO_READ_VALUE("upb",
                    QHS.CmpEq("idupb", "0001"),
                    "codeupb");
                if (liquidazionecorrente > 0) {
                    decimal importoAltriPagamenti = 0;
                    importoAltriPagamenti = MetaData.SumColumn(AltriPagamenti, "amount");
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Spesa";
                    rMov["idreg"] = rConfIVA["paymentagency"];
                    rMov["registry"] = paymentagencytitle;
                    rMov["idfin"] = rConfIVA["idfinivapayment"];
                    rMov["codefin"] = codefinivapayment;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = liquidazionecorrente - importoAltriPagamenti;
                    rMov["autokind"] = 12;
                    movimentiIVA.Rows.Add(rMov);
                }

                if (liquidazionecorrente < 0) {

                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Entrata";
                    rMov["idreg"] = rConfIVA["refundagency"];
                    rMov["registry"] = refundagencytitle;
                    rMov["idfin"] = rConfIVA["idfinivarefund"];
                    rMov["codefin"] = codefinivarefund;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = -liquidazionecorrente;
                    rMov["autokind"] = 12;
                    movimentiIVA.Rows.Add(rMov);
                }
            }

            if ((MovimentiFinanziariConfigurati12()) && (chkIstituzionale.Checked)) {

                object idregpayment12 = rConfIVA["paymentagency12"];
                object paymentagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregpayment12),
                    "title");

                object idfinpayment12 = rConfIVA["idfinivapayment12"];
                object codefinivapayment12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinpayment12),
                    "codefin");

                object idregrefund12 = rConfIVA["refundagency12"];
                object refundagencytitle12 = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idregrefund12),
                    "title");

                object idfinrefund12 = rConfIVA["idfinivarefund12"];
                object codefinivarefund12 = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinrefund12), "codefin");


                string idUpb = "0001";
                object codeUpb = Meta.Conn.DO_READ_VALUE("upb",
                    QHS.CmpEq("idupb", "0001"),
                    "codeupb");
                if (liquidazionecorrente12 > 0) {
                    decimal importoAltriPagamentiIntra12 = 0;
                    importoAltriPagamentiIntra12 = MetaData.SumColumn(AltriPagamentiIntraExtraUe, "amount");
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Spesa";
                    rMov["idreg"] = rConfIVA["paymentagency12"];
                    rMov["registry"] = paymentagencytitle12;
                    rMov["idfin"] = rConfIVA["idfinivapayment12"];
                    rMov["codefin"] = codefinivapayment12;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = liquidazionecorrente12 - importoAltriPagamentiIntra12;
                    rMov["autokind"] = 17;
                    movimentiIVA.Rows.Add(rMov);

                }

                if (liquidazionecorrente12 < 0) {
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Entrata";
                    rMov["idreg"] = rConfIVA["refundagency12"];
                    rMov["registry"] = refundagencytitle12;
                    rMov["idfin"] = rConfIVA["idfinivarefund12"];
                    rMov["codefin"] = codefinivarefund12;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = -liquidazionecorrente12;
                    rMov["autokind"] = 17;
                    movimentiIVA.Rows.Add(rMov);
                }
            }


            if ((MovimentiFinanziariConfiguratiSplit()) && (chkIstituzionaleSplit.Checked)) {

                object idregpaymentsplit = rConfIVA["paymentagencysplit"];
                object paymentagencytitlesplit = Meta.Conn.DO_READ_VALUE("registry",
                    QHS.CmpEq("idreg", idregpaymentsplit), "title");

                object idfinpaymentsplit = rConfIVA["idfinivapaymentsplit"];
                object codefinivapaymentsplit = Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idfinpaymentsplit),
                    "codefin");



                string idUpb = "0001";
                object codeUpb = Meta.Conn.DO_READ_VALUE("upb",
                    QHS.CmpEq("idupb", "0001"),
                    "codeupb");
                if (liquidazionecorrentesplit > 0) {
                    decimal importoAltriPagamentiSplit = 0;
                    importoAltriPagamentiSplit = MetaData.SumColumn(AltriPagamentiIstituzionaleSplitPayment, "amount");
                    DataRow rMov = movimentiIVA.NewRow();
                    rMov["movkind"] = "Spesa";
                    rMov["idreg"] = rConfIVA["paymentagencysplit"];
                    rMov["registry"] = paymentagencytitlesplit;
                    rMov["idfin"] = rConfIVA["idfinivapaymentsplit"];
                    rMov["codefin"] = codefinivapaymentsplit;
                    rMov["idupb"] = idUpb;
                    rMov["codeupb"] = codeUpb;
                    rMov["amount"] = liquidazionecorrentesplit - importoAltriPagamentiSplit;
                    rMov["autokind"] = 23;
                    movimentiIVA.Rows.Add(rMov);
                }

            }


            return movimentiIVA;
        }

        /// <summary>
        /// se importo negativo --> iva a credito
        /// </summary>
        /// <param name="importo"></param>
        /// <param name="E_S"></param>
        /// <returns></returns>
        private bool controllaSeCreareAutomatismi(decimal importo) {
            if (importo == 0) return false;
            DataRow rConfIVA = DS.config.Rows[0];
            decimal minImporto = 0;
            string generaMov = "";
            if (importo < 0) {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["minrefund"]);
                generaMov = rConfIVA["flagrefund"].ToString().ToUpper();
                importo = -importo;

            }
            else {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["minpayment"]);
                generaMov = rConfIVA["flagpayment"].ToString().ToUpper();
            }
            return ((importo > minImporto) && (generaMov == "S"));
        }

        private bool controllaSeCreareAutomatismi12(decimal importo) {
            if (importo == 0) return false;
            DataRow rConfIVA = DS.config.Rows[0];
            decimal minImporto = 0;
            string generaMov = "";
            if (importo < 0) {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["minrefund12"]);
                generaMov = rConfIVA["flagrefund12"].ToString().ToUpper();
                importo = -importo;

            }
            else {
                minImporto = CfgFn.GetNoNullDecimal(rConfIVA["minpayment12"]);
                generaMov = rConfIVA["flagpayment12"].ToString().ToUpper();
            }
            return ((importo > minImporto) && (generaMov == "S"));
        }

        private bool controllaSeCreareAutomatismiSplit(decimal importo) {
            if (importo == 0)
                return false;
            DataRow rConfIVA = DS.config.Rows[0];
            decimal minImporto = 0;
            string generaMov = "";
            if (importo > 0) {
                minImporto = 0; //CfgFn.GetNoNullDecimal(rConfIVA["minpaymentsplit"]);
                generaMov = rConfIVA["flagpaymentsplit"].ToString().ToUpper();
            }
            return ((importo > minImporto) && (generaMov == "S"));
        }



        bool MovimentiFinanziariConfigurati() {
            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["flagpayment"].ToString().ToUpper() == "S") &&
                (rConfIVA["paymentagency"] != DBNull.Value))
                return true;
            if ((rConfIVA["flagrefund"].ToString().ToUpper() == "S") &&
                (rConfIVA["refundagency"] != DBNull.Value)) return true;
            return false;
        }


        bool MovimentiFinanziariConfigurati12() {

            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["flagpayment12"].ToString().ToUpper() == "S") &&
                (rConfIVA["paymentagency12"] != DBNull.Value))
                return true;
            if ((rConfIVA["flagrefund12"].ToString().ToUpper() == "S") &&
                (rConfIVA["refundagency12"] != DBNull.Value)) return true;
            return false;
        }

        bool MovimentiFinanziariConfiguratiSplit() {

            DataRow rConfIVA = DS.config.Rows[0];
            if ((rConfIVA["flagpaymentsplit"].ToString().ToUpper() == "S") &&
                (rConfIVA["paymentagencysplit"] != DBNull.Value))
                return true;
            return false;
        }


        private void CheckDefault() {
            object obj = HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
            if (obj == DBNull.Value) txtProrata.Text = "100,00 %";
            obj = HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);
            if (obj == DBNull.Value) txtPromiscuo.Text = "100,00 %";
        }

        private string CalcolaTotaleColonna(DataTable T, string fieldname) {
            return MetaData.SumColumn(T, fieldname).ToString("c");
        }

        private void ImpostaIVADebito(DataTable T) {
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva"].Caption = "Iva totale";
            //T.Columns["unabatable"].Caption = "Iva Indetraibile";
            T.Columns["flagdeferred"].Caption = "IVA Differita";
            HelpForm.SetFormatForColumn(T.Columns["iva"], "c");
            gridDebito.DataSource = null;
            HelpForm.SetDataGrid(gridDebito, T);
        }

        private void ImpostaIVADebitoIstituzionale(DataTable T) {
            if (T == null) return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["taxable"].Caption = "Imponibile netto";
            T.Columns["iva"].Caption = "Iva totale";
            //T.Columns["unabatable"].Caption = "Iva Indetraibile";
            T.Columns["flagdeferred"].Caption = "IVA Differita";
            HelpForm.SetFormatForColumn(T.Columns["iva"], "c");
            gridacquistiistituzionaliINTRA.DataSource = null;
            HelpForm.SetDataGrid(gridacquistiistituzionaliINTRA, T);
        }

        private void ImpostaIVADebitoSplit(DataTable T) {
            if (T == null)
                return;
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["taxable"].Caption = "Imponibile netto";
            T.Columns["iva"].Caption = "Iva totale";
            //T.Columns["unabatable"].Caption = "Iva Indetraibile";
            T.Columns["flagdeferred"].Caption = "IVA Differita";
            HelpForm.SetFormatForColumn(T.Columns["iva"], "c");
            gridacquistiistituzionaliSplit.DataSource = null;
            HelpForm.SetDataGrid(gridacquistiistituzionaliSplit, T);
        }


        decimal getProrata() {
            return (decimal) HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
        }


        decimal getPromiscuo() {
            return (decimal) HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);
        }


        private void ImpostaIVACreditoCommerciale(DataTable T) {
            if (T == null) return;
            //T.Columns["idivaregisterkind"].Caption = "";
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva"].Caption = "Iva totale";
            T.Columns["unabatable"].Caption = "Iva Indetraibile";
            T.Columns["flagdeferred"].Caption = "IVA Differita";

            HelpForm.SetFormatForColumn(T.Columns["iva"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable"], "c");
            gridAcquisti.DataSource = null;
            HelpForm.SetDataGrid(gridAcquisti, T);
        }

        private void ImpostaIVACreditoPromiscui(DataTable T) {
            if (T == null) return;
            //T.Columns["idivaregisterkind"].Caption = "";
            T.Columns["codeivaregisterkind"].Caption = "Codice";
            T.Columns["description"].Caption = "Registro";
            T.Columns["iva"].Caption = "Iva totale";
            T.Columns["unabatable"].Caption = "Iva Indetraibile";
            T.Columns["flagdeferred"].Caption = "IVA Differita";
            HelpForm.SetFormatForColumn(T.Columns["iva"], "c");
            HelpForm.SetFormatForColumn(T.Columns["unabatable"], "c");
            gridacquistipromiscui.DataSource = null;
            HelpForm.SetDataGrid(gridacquistipromiscui, T);
        }


        private void CalcolaIVA() {
            DataSet DSRegistry = new DataSet();
            DataTable AcquistiComm = new DataTable();
            DataTable AcquistiProm = new DataTable();
            DataTable Vendite = new DataTable();
            DataTable AcquistiIst = new DataTable();
            DataTable AcquistiSplit = new DataTable();

            AcquistiComm.Columns.Add("codeivaregisterkind", typeof(string));
            AcquistiProm.Columns.Add("codeivaregisterkind", typeof(string));
            Vendite.Columns.Add("codeivaregisterkind", typeof(string));
            AcquistiIst.Columns.Add("codeivaregisterkind", typeof(string));
            AcquistiSplit.Columns.Add("codeivaregisterkind", typeof(string));


            AcquistiComm.Columns.Add("description", typeof(string));
            AcquistiProm.Columns.Add("description", typeof(string));
            Vendite.Columns.Add("description", typeof(string));
            AcquistiIst.Columns.Add("description", typeof(string));
            AcquistiSplit.Columns.Add("description", typeof(string));

            AcquistiIst.Columns.Add("taxable", typeof(decimal));
            AcquistiSplit.Columns.Add("taxable", typeof(decimal));


            AcquistiComm.Columns.Add("iva", typeof(decimal));
            AcquistiProm.Columns.Add("iva", typeof(decimal));
            Vendite.Columns.Add("iva", typeof(decimal));
            AcquistiIst.Columns.Add("iva", typeof(decimal));
            AcquistiSplit.Columns.Add("iva", typeof(decimal));

            AcquistiComm.Columns.Add("unabatable", typeof(decimal));
            AcquistiProm.Columns.Add("unabatable", typeof(decimal));

            AcquistiComm.Columns.Add("flagdeferred", typeof(string));
            AcquistiProm.Columns.Add("flagdeferred", typeof(string));
            Vendite.Columns.Add("flagdeferred", typeof(string));
            AcquistiIst.Columns.Add("flagdeferred", typeof(string));
            AcquistiSplit.Columns.Add("flagdeferred", typeof(string));


            DSRegistry.Tables.Add(AcquistiComm);
            DSRegistry.Tables.Add(AcquistiProm);
            DSRegistry.Tables.Add(Vendite);
            DSRegistry.Tables.Add(AcquistiIst);
            DSRegistry.Tables.Add(AcquistiSplit);



            foreach (DataRow R in TableIva.Rows) {
                bool istituzionale = (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1);
                bool flagintracom = R["flagintracom"].ToString().ToUpper() != "N";
                    // ossia se vale S:intracom oppure X:extra-UE
                bool flagsplit = R["flagsplit"].ToString().ToUpper() != "N";
                    // ossia se vale S:intracom oppure X:extra-UE
                bool commerciale = false;
                bool promiscuo = false;

                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 2)
                    commerciale = true;
                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 3)
                    promiscuo = true;
                bool acquisto = R["registerclass"].ToString().ToUpper() == "A";
                bool vendita = !acquisto;

                bool tipoFatturaacquisto = R["kind"].ToString().ToUpper() == "A";
                bool tipoFatturavendita = !tipoFatturaacquisto;

                if (istituzionale && !flagintracom && !flagsplit) continue;


                if (!istituzionale && flagsplit && tipoFatturavendita) {
                    continue;
                }



                string searchreg = QHC.AppAnd(QHC.CmpEq("codeivaregisterkind", R["codeivaregisterkind"]),
                    QHC.CmpEq("flagdeferred", R["flagdeferred"]));
                bool immediata = R["flagdeferred"].ToString().ToUpper() == "N";
                DataRow RRegistro = null;
                DataTable TRegistro = null;
                if (acquisto) {
                    if (promiscuo) TRegistro = AcquistiProm;
                    if (commerciale) TRegistro = AcquistiComm;
                    if (istituzionale && flagintracom) TRegistro = AcquistiIst;
                    if (istituzionale && flagsplit) TRegistro = AcquistiSplit;

                }
                else {
                    TRegistro = Vendite;
                }
                if (TRegistro == null) {
                    MessageBox.Show(
                        $"La fattura {R["codeivaregisterkind"]} n. {R["ninv"]} del {R["yinv"]} non è associata ad alcun registro valido e non sarà considerata.", 
                        "Errore");
                    continue;
                }
                
                DataRow[] Regs = TRegistro.Select(searchreg);
                if (Regs.Length > 0) {
                    RRegistro = Regs[0];
                }
                else {
                    RRegistro = TRegistro.NewRow();

                    RRegistro["iva"] = 0;
                    if (acquisto && !istituzionale) RRegistro["unabatable"] = 0;

                }
                RRegistro["codeivaregisterkind"] = R["codeivaregisterkind"];
                RRegistro["flagdeferred"] = R["flagdeferred"];
                RRegistro["description"] = R["description"];
                decimal ivatotale = CfgFn.GetNoNullDecimal(R["currivagrosspayed"]);
                decimal ivadetraibile = CfgFn.GetNoNullDecimal(R["singola"]);
                decimal ivaindetraibile = CfgFn.GetNoNullDecimal(R["currivaunabatable"]);
                decimal taxable = CfgFn.GetNoNullDecimal(R["taxable"]);
                RRegistro["iva"] = CfgFn.GetNoNullDecimal(RRegistro["iva"]) + ivatotale;
                if (acquisto && !istituzionale) {
                    RRegistro["unabatable"] = CfgFn.GetNoNullDecimal(RRegistro["unabatable"]) +
                                              ivaindetraibile;
                }
                if (acquisto && istituzionale) {
                    RRegistro["taxable"] = CfgFn.GetNoNullDecimal(RRegistro["taxable"]) +
                                           taxable;
                }

                if (Regs.Length == 0) {
                    TRegistro.Rows.Add(RRegistro);
                }

            }

            AcquistiComm.AcceptChanges();
            AcquistiProm.AcceptChanges();
            Vendite.AcceptChanges();
            AcquistiIst.AcceptChanges();
            AcquistiSplit.AcceptChanges();

            ImpostaIVADebito(Vendite);
            ImpostaIVACreditoCommerciale(AcquistiComm);
            ImpostaIVACreditoPromiscui(AcquistiProm);
            ImpostaIVADebitoIstituzionale(AcquistiIst);
            ImpostaIVADebitoSplit(AcquistiSplit);
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }

        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        private void RicalcolaCampiCalcolati() {
            string denominazioneFasi = "";
            string faseDA = "", faseA = "";

            if (GeneraTuttelafasi) {
                denominazioneFasi = "Tutte";
            }
            else {
                faseDA = DS.expensephase.Select(QHC.CmpEq("nphase", 1))[0]["description"].ToString();
                faseA =
                    DS.expensephase.Select(QHC.CmpEq("nphase", getIntSys("expenseregphase")))[0]["description"].ToString
                        ();
                denominazioneFasi = (faseDA != faseA) ? ("Da " + faseDA + " a " + faseA) : (faseDA);
            }

            foreach (DataRow RS in DS.expenseview.Rows) {
                object livsup = RS["parentidexp"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                if (livsup != DBNull.Value) {
                    DataRow Sup = (DataRow) RighePadriSpesa[livsup];
                    string nomefasesup =
                        DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 =
                        DS.expensephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
                                           Sup["ymov"].ToString() + "/" +
                                           Sup["nmov"].ToString();
                    string nomefasemax =
                        DS.expensephase.Select(QHC.CmpEq("nphase", maxfasespesa))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = nomefasesup2 + " - " + nomefasemax;
                    else
                        RS["phase"] = nomefasemax;
                }
                else {
                    RS["!livprecedente"] = "";
                    RS["phase"] = denominazioneFasi;
                }
            }

            if (GeneraTuttelafasi) {
                denominazioneFasi = "Tutte";
            }
            else {
                faseDA = DS.incomephase.Select(QHC.CmpEq("nphase", 1))[0]["description"].ToString();
                faseA =
                    DS.incomephase.Select(QHC.CmpEq("nphase", getIntSys("incomeregphase")))[0]["description"].ToString();
                denominazioneFasi = (faseDA != faseA) ? ("Da " + faseDA + " a " + faseA) : (faseDA);
            }

            foreach (DataRow RS in DS.incomeview.Rows) {
                object livsup = RS["parentidinc"];
                int nfasesup = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("income", QHS.CmpEq("idinc", livsup), "nphase"));
                if (livsup != DBNull.Value) {
                    DataRow Sup = (DataRow) RighePadriEntrata[livsup];
                    string nomefasesup =
                        DS.incomephase.Select(QHC.CmpEq("nphase", nfasesup))[0]["description"].ToString();
                    string nomefasesup2 =
                        DS.incomephase.Select(QHC.CmpEq("nphase", nfasesup + 1))[0]["description"].ToString();
                    RS["!livprecedente"] = nomefasesup + " " +
                                           Sup["ymov"].ToString() + "/" +
                                           Sup["nmov"].ToString();
                    string nomefasemax =
                        DS.incomephase.Select(QHC.CmpEq("nphase", maxfaseentrata))[0]["description"].ToString();
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = "Da " + nomefasesup2 + " a " + nomefasemax;
                    else
                        RS["phase"] = nomefasesup2;
                }
                else {
                    RS["!livprecedente"] = "";
                    RS["phase"] = denominazioneFasi;
                }
            }
            formatgrids FGSpesa = new formatgrids(gridSpesa);
            FGSpesa.AutosizeColumnWidth();
            formatgrids FGEntrata = new formatgrids(gridEntrata);
            FGEntrata.AutosizeColumnWidth();
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = G.DataSource as DataSet;
            if (MyDS == null) return null;
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

        int GetMaxFaseForSelection(DataRow[] Selected, string table) {
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense") {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            int fasecurr = 99;
            if (table == "income") {
                fasecurr = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
                fasecurr = fasecurr - 1;
            }
            else {
                fasecurr = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
                fasecurr = fasecurr - 1;
            }
            if (nvaloridiversi("idfin", Selected) > 1) {
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }
            if (nvaloridiversi("idreg", Selected) > 1) {
                if (fasecurr >= minfasecred) fasecurr = minfasecred - 1;
            }
            if (nvaloridiversi("idupb", Selected) > 1) {
                if (fasecurr >= minfasebil) fasecurr = minfasebil - 1;
            }
            return fasecurr;
        }

        int nvaloridiversi(string column, DataRow[] ROWS) {
            string outstring = "";
            int diversi = 0;
            foreach (DataRow R in ROWS) {
                //if (R[column]==DBNull.Value) continue;
                string quoted = QueryCreator.quotedstrvalue(R[column], false);
                if (outstring.IndexOf(quoted) >= 0) continue;
                if (outstring != "") outstring += ",";
                outstring += quoted;
                diversi++;
            }
            return diversi;
        }

        //int GetFaseInfo(string flag, string table) {
        //    string fasitable = table + "phase";
        //    DataTable Fase = DS.Tables[fasitable];
        //    int faseattivazione;

        //    DataRow[] MyDRfase;
        //    MyDRfase = Fase.Select(QHC.CmpEq(flag, 'S'), "nphase");
        //    if (MyDRfase.Length > 0)
        //        faseattivazione = (Convert.ToInt32(MyDRfase[0]["nphase"]));
        //    else
        //        faseattivazione = 99;
        //    return faseattivazione;
        //}

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            if (MyTable.TableName == "expenseview" ||
                MyTable.TableName == "AltriPagamenti" ||
                MyTable.TableName == "AltriPagamentiIntraExtraUe" ||
                MyTable.TableName == "AltriPagamentiIstituzionaleSplitPayment")
                filter = QHC.CmpEq("idexp", G[index, 0]);
            else
                filter = QHC.CmpEq("idinc", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }


        string GetFilterForSelection(DataRow[] Selected, string table, int livello) {
            string filter = "";
            int minfasecred = 99;
            int minfasebil = 99;
            if (table == "expense") {
                minfasecred = Convert.ToInt32(Conn.GetSys("expenseregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("expensefinphase"));
            }
            if (table == "income") {
                minfasecred = Convert.ToInt32(Conn.GetSys("incomeregphase"));
                minfasebil = Convert.ToInt32(Conn.GetSys("incomefinphase"));
            }

            if (livello >= minfasebil) {
                object O = Selected[0]["idfin"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idfin", O));
                }
            }

            if (livello >= minfasecred) {
                object O = Selected[0]["idreg"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
                }
            }

            if (livello >= minfasebil) {
                object O = Selected[0]["idupb"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", O));
                }
            }
            return filter;
        }

        private void btnCollegaE_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridEntrata);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            string rowfilter;

            int maxfase = GetMaxFaseForSelection(RigheSelezionate, "income");
            if (maxfase < 1) {
                MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                                "Le informazioni di U.P.B., bilancio e versante sono troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;
            if (maxfase > 1) {
                DataTable Fasi2 = DS.incomephase.Copy();
                foreach (DataRow ToDel in Fasi2.Select(
                    QHC.CmpGt("nphase", maxfase))) {
                    ToDel.Delete();
                }
                Fasi2.AcceptChanges();
                FrmAskFase F = new FrmAskFase(Fasi2);
                if (F.ShowDialog() != DialogResult.OK) return;
                selectedfase = Convert.ToInt32(F.cmbFasi.SelectedValue);
            }
            rowfilter = GetFilterForSelection(RigheSelezionate, "income", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate) {
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData E = Disp.Get("income");
            E.DS = DS.Clone();
            E.FilterLocked = true;
            DataRow Choosen = E.SelectOne("default", rowfilter, "income", null);
            if (Choosen == null) return;
            RighePadriEntrata[Choosen["idinc"]] = Choosen;
            foreach (DataRow R in RigheSelezionate) {
                R["parentidinc"] = Choosen["idinc"];
                int I = Convert.ToInt32(R["idinc"]);
                TAutomatismi.Rows[I]["parentidmov"] = Choosen["idinc"];
            }
            RicalcolaCampiCalcolati();
        }

        private void btnScollegaE_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridEntrata);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            foreach (DataRow R in RigheSelezionate) {
                R["parentidinc"] = DBNull.Value;
                int I = Convert.ToInt32(R["idinc"]);
                TAutomatismi.Rows[I]["parentidmov"] = DBNull.Value;
            }
            RicalcolaCampiCalcolati();
        }



        private void btnCollegaS_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            string rowfilter;
            int maxfase = GetMaxFaseForSelection(RigheSelezionate, "expense");
            if (maxfase < 1) {
                MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                                "Le informazioni di U.P.B., bilancio e versante sono troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;
            if (maxfase > 1) {
                DataTable Fasi2 = DS.expensephase.Copy();
                foreach (DataRow ToDel in Fasi2.Select(
                    QHC.CmpGt("nphase", maxfase))) {
                    ToDel.Delete();
                }
                Fasi2.AcceptChanges();
                FrmAskFase F = new FrmAskFase(Fasi2);
                if (F.ShowDialog() != DialogResult.OK) return;
                selectedfase = Convert.ToInt32(F.cmbFasi.SelectedValue);
            }
            rowfilter = GetFilterForSelection(RigheSelezionate, "expense", selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate) {
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData S = Disp.Get("expense");
            S.DS = DS.Clone();
            S.FilterLocked = true;
            DataRow Choosen = S.SelectOne("default", rowfilter, "expense", null);
            if (Choosen == null) return;
            RighePadriSpesa[Choosen["idexp"]] = Choosen; //<<<<<<<<<<sara tostring
            foreach (DataRow R in RigheSelezionate) {
                R["parentidexp"] = Choosen["idexp"];
                int I = Convert.ToInt32(R["idexp"]);
                TAutomatismi.Rows[I]["parentidmov"] = Choosen["idexp"];
            }
            RicalcolaCampiCalcolati();
        }

        private void btnScollegaS_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            foreach (DataRow R in RigheSelezionate) {
                R["parentidexp"] = DBNull.Value;
                int I = Convert.ToInt32(R["idexp"]);
                TAutomatismi.Rows[I]["parentidmov"] = DBNull.Value;
            }
            RicalcolaCampiCalcolati();
        }

        void AddVoceBilancio(object ID, string codbil) {
            if (ID == DBNull.Value) return;
            if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
            DataRow NewBil = DS.fin.NewRow();
            NewBil["idfin"] = ID;
            NewBil["codefin"] = codbil;
            DS.fin.Rows.Add(NewBil);
            NewBil.AcceptChanges();
        }

        void AddVoceUpb(object ID, string codupb) {
            if (ID == DBNull.Value) return;
            if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;

            DataRow NewUpb = DS.upb.NewRow();
            NewUpb["idupb"] = ID;
            NewUpb["codeupb"] = codupb;
            DS.upb.Rows.Add(NewUpb);
            NewUpb.AcceptChanges();
        }

        void AddVoceCreditore(object codice, string denominazione) {
            if (codice == DBNull.Value) return;
            if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;

            DataRow NewCred = DS.registry.NewRow();
            NewCred["idreg"] = codice;
            NewCred["title"] = denominazione;
            DS.registry.Rows.Add(NewCred);
            NewCred.AcceptChanges();
        }

        void AddVociCollegate(DataRow SP_Row) {
            AddVoceBilancio(SP_Row["idfin"], SP_Row["codefin"].ToString());
            AddVoceUpb(SP_Row["idupb"], SP_Row["codeupb"].ToString());
            AddVoceCreditore(SP_Row["idreg"], SP_Row["registry"].ToString());
        }

        private void FillMovimento(DataRow E_S, DataRow Auto) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
            E_S.BeginEdit();
            E_S["ymov"] = esercizio;
            //E_S["ycreation"]= esercizio;
            E_S["adate"] = DataCont;
            //E_S["fulfilled"]="N";
            ////if (E_S.Table.Columns.Contains("autotaxflag"))E_S["autotaxflag"]="N";
            ////if (E_S.Table.Columns.Contains("autoclawbackflag"))E_S["autoclawbackflag"]="N";

            string[] fields_to_copy = new string[] {
                "idman", "idreg", "description", "autokind"
            };
            foreach (string field in fields_to_copy) {
                if (Auto.Table.Columns[field] == null) continue;
                if (E_S.Table.Columns[field] == null) continue;
                E_S[field] = Auto[field];
            }
            //E_S["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
            E_S.EndEdit();
        }



        void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
            string[] fields_to_copy = new string[] {"idfin", "idupb", "codefin", "codeupb"};
            foreach (string field in fields_to_copy) {
                if (Auto.Table.Columns[field] == null) continue;
                if (ImpMov.Table.Columns[field] == null) continue;
                ImpMov[field] = Auto[field];
            }
            ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
        }

        private int getIntSys(string nome) {
            int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
            if (s == 0) return 99;
            return s;
        }

        private void insertMov(DataRow rIvaPay, object scadenza, bool intrastat) {
            if ((!MovimentiFinanziariConfigurati()) && (!MovimentiFinanziariConfigurati12()) &&
                (!MovimentiFinanziariConfiguratiSplit())) return;

            int fasemax = 0;
            int faseCreditoreDebitore = 0;
            int faseBilancio = 0;
            int faselast = 0;



            DS.Tables["expenseview"].AcceptChanges();
            DS.Tables["incomeview"].AcceptChanges();

            DS.Tables["expense"].Clear();
            DS.Tables["income"].Clear();
            DS.Tables["expenseview"].Clear();
            DS.Tables["incomeview"].Clear();
            DS.Tables["incomelast"].Clear();
            DS.Tables["expenselast"].Clear();


            string parentIdField;
            string movIdField;

            DataRow[] Auto = TAutomatismi.Select(); // (filterMovKind);
            foreach (DataRow R in Auto) {
                string mov = "";
                if (R["movkind"].ToString().ToLower() == "spesa")
                    mov = "expense";
                else
                    mov = "income";
                string view = mov + "view";
                string impMov = mov + "year";
                string lastMov = mov + "last";

                DataTable Mov = DS.Tables[mov];
                DataTable ImpMov = DS.Tables[impMov];
                DataTable LastMov = DS.Tables[lastMov];

                if (mov == "expense") {
                    //filterMovKind = "(movkind = 'Spesa')";
                    movIdField = "idexp";
                    parentIdField = "parentidexp";
                }
                else {
                    //filterMovKind = "(movkind = 'Entrata')";
                    movIdField = "idinc";
                    parentIdField = "parentidinc";
                }

                MetaData MetaM = Meta.Dispatcher.Get(mov);
                MetaM.SetDefaults(DS.Tables[mov]);
                MetaData MetaImputazioneM = Meta.Dispatcher.Get(impMov);
                MetaImputazioneM.SetDefaults(DS.Tables[impMov]);
                MetaData MetaMovLast = Meta.Dispatcher.Get(lastMov);
                MetaMovLast.SetDefaults(DS.Tables[lastMov]);

                if (mov == "expense") {
                    fasemax = getIntSys("maxexpensephase");
                    faseCreditoreDebitore = getIntSys("expenseregphase");
                    faseBilancio = getIntSys("expensefinphase");
                    faselast = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
                }
                else {
                    fasemax = getIntSys("maxincomephase");
                    faseCreditoreDebitore = getIntSys("incomeregphase");
                    faseBilancio = getIntSys("incomefinphase");
                    faselast = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
                }


                AddVociCollegate(R);
                DataRow ParentR = null;

                for (int faseCorrente = 1; faseCorrente <= faselast; faseCorrente++) {
                    Mov.Columns["nphase"].DefaultValue = faseCorrente;

                    DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
                    ParentR = NewMovRow;

                    FillMovimento(NewMovRow, R);
                    R["idmovimento"] = NewMovRow[movIdField];
                    NewMovRow["nphase"] = faseCorrente;

                    if (faseCorrente < faseCreditoreDebitore) {
                        NewMovRow["idreg"] = DBNull.Value;
                    }

                    if ((faseCorrente == fasemax) && (mov == "expense")) {
                        object codicecreddeb = R["idreg"];
                        DataRow ModPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, codicecreddeb);
                        if (ModPagam == null) {
                            MessageBox.Show(this,
                                "E' necessario che sia definita almeno una modalità di pagamento per il percipiente " +
                                "\"" + R["registry"].ToString() + "\"\n\n" +
                                "Dati non salvati", "Errore", MessageBoxButtons.OK);
                            return;
                        }
                        DataRow NewLastMov = MetaMovLast.Get_New_Row(NewMovRow, LastMov);
                        NewLastMov["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
                        NewLastMov["idpaymethod"] = ModPagam["idpaymethod"];
                        NewLastMov["iban"] = ModPagam["iban"];
                        NewLastMov["cin"] = ModPagam["cin"];
                        NewLastMov["idbank"] = ModPagam["idbank"];
                        NewLastMov["idcab"] = ModPagam["idcab"];
                        NewLastMov["cc"] = ModPagam["cc"];
                        NewLastMov["paymentdescr"] = ModPagam["paymentdescr"];
                        NewLastMov["iddeputy"] = ModPagam["iddeputy"];
                        NewLastMov["refexternaldoc"] = ModPagam["refexternaldoc"];

                        NewLastMov["biccode"] = ModPagam["biccode"];
                        NewLastMov["extracode"] = ModPagam["extracode"];
                        NewLastMov["idchargehandling"] = ModPagam["idchargehandling"];
                        if (LeggiFlagEsenteBancaPredefinita()) {
                            int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
                            int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) |
                                                 ((CfgFn.GetNoNullInt32(ModPagam["flag"]) & 1) << 3);
                            NewLastMov["flag"] = flag_exemption;
                        }
                        object idpaymethod = ModPagam["idpaymethod"];
                        string filterpaymethod = QHS.CmpEq("idpaymethod", idpaymethod);

                        DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);

                        if ((TPaymethod != null) && (TPaymethod.Rows.Count > 0)) {
                            object paymethod_allowdeputy = TPaymethod.Rows[0]["allowdeputy"];
                            object paymethod_flag = TPaymethod.Rows[0]["flag"];
                            NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
                            NewLastMov["paymethod_flag"] = paymethod_flag;
                        }

                    }
                    if ((faseCorrente == fasemax) && (mov == "income")) {
                        DataRow NewLastMov = MetaMovLast.Get_New_Row(NewMovRow, LastMov);
                    }
                    DataRow NewImpMov = ImpMov.NewRow();

                    FillImputazioneMovimento(NewImpMov, R);
                    NewImpMov[movIdField] = NewMovRow[movIdField];
                    NewImpMov["ayear"] = esercizio;

                    if (faseCorrente < faseBilancio) {
                        NewImpMov["idfin"] = DBNull.Value;
                        NewImpMov["idupb"] = DBNull.Value;
                    }
                    ImpMov.Rows.Add(NewImpMov);
                }
            }

            //Imposta il livsupid di tutte le righe per cui è necessario
            foreach (DataRow R in Auto) {
                string mov = "";
                if (R["movkind"].ToString().ToLower() == "spesa")
                    mov = "expense";
                else
                    mov = "income";

                DataTable Mov = DS.Tables[mov];

                if (mov == "expense") {
                    //filterMovKind = "(movkind = 'Spesa')";
                    movIdField = "idexp";
                    parentIdField = "parentidexp";
                }
                else {
                    //filterMovKind = "(movkind = 'Entrata')";
                    movIdField = "idinc";
                    parentIdField = "parentidinc";
                }


                if (R["parentidmov"] == DBNull.Value) continue;
                object idtolink = R["parentidmov"];

                object idmov = R["idmovimento"];

                //int nfasetolink = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("expense", QHS.CmpEq(movIdField, idtolink), "nphase"));
                int nfasetolink = 0;
                if (R["movkind"].ToString().ToLower() == "spesa") {
                    nfasetolink =
                        CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("expense", QHS.CmpEq(movIdField, idtolink),
                            "nphase"));
                }
                else {
                    nfasetolink =
                        CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("income", QHS.CmpEq(movIdField, idtolink), "nphase"));
                }

                DataRow MovSel = Mov.Select(QHC.CmpEq(movIdField, idmov))[0];
                int currfase = CfgFn.GetNoNullInt32(MovSel["nphase"]);

                while (currfase > (nfasetolink + 1)) {
                    idmov = MovSel[parentIdField];
                    MovSel = Mov.Select(QHC.CmpEq(movIdField, idmov))[0];
                    currfase--;
                }
                MovSel[parentIdField] = idtolink;

            }



            //Cancella tutto ciò che non ha figli e non è di ultima fase* sino a che non trova + nulla,
            // (*)non è necessariamente la maxphase, ma è l'ultima fase che si è generata, che può essere la maxphase o quella del creditore
            faselast = (GeneraTuttelafasi) ? getIntSys("maxexpensephase") : getIntSys("expenseregphase");
            bool keep = true;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", faselast);
                foreach (DataRow Parent in DS.Tables["expense"].Select(filternolastphase)) {
                    object idpar = Parent["idexp"];
                    string filterchild = QHC.CmpEq("parentidexp", idpar);
                    if (DS.Tables["expense"].Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq("idexp", Parent["idexp"]);
                        DataRow Imp = DS.Tables["expenseyear"].Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }
            faselast = (GeneraTuttelafasi) ? getIntSys("maxincomephase") : getIntSys("incomeregphase");
            keep = true;
            while (keep) {
                keep = false;
                string filternolastphase = QHC.CmpNe("nphase", faselast);
                foreach (DataRow Parent in DS.Tables["income"].Select(filternolastphase)) {
                    object idpar = Parent["idinc"];
                    string filterchild = QHC.CmpEq("parentidinc", idpar);
                    if (DS.Tables["income"].Select(filterchild).Length == 0) {
                        string filterimp = QHC.CmpEq("idinc", Parent["idinc"]);
                        DataRow Imp = DS.Tables["incomeyear"].Select(filterimp)[0];
                        Imp.Delete();
                        Parent.Delete();
                        keep = true;
                    }
                }
            }

            string ivapaymov = "ivapay" + "expense";
            string idfield = "idexp";
            foreach (DataRow R in DS.Tables["expense"].Rows) {

                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
                NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

         
            ivapaymov = "ivapay" + "income";
            idfield = "idinc";
            foreach (DataRow R in DS.Tables["income"].Rows) {

                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
                NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

            foreach (DataRow R in DS.Tables["expense"].Rows) {
                //R["autokind"]=12;
                R["expiration"] = scadenza;
                //R["description"]="Liquidazione periodica IVA - dal "+txtDal.Text+" al "+txtAl.Text;
                string descr = "Liquidazione periodica IVA";
                if (R["autokind"].ToString() == "17") {
                    descr = "Liquidazione periodica IVA Intrastat Istituzionale";
                }
                R["description"] = descr + "- dal " + txtDal.Text + " al " + txtAl.Text;
            }
            foreach (DataRow R in DS.Tables["income"].Rows) {
                //R["autokind"]=12;
                R["expiration"] = scadenza;
                //R["description"]="Liquidazione periodica IVA - dal "+txtDal.Text+" al "+txtAl.Text;
                string descr = "Liquidazione periodica IVA";
                if (R["autokind"].ToString() == "17") {
                    descr = "Liquidazione periodica IVA Intrastat Istituzionale";
                }
                if (R["autokind"].ToString() == "23") {
                    descr = "Liquidazione periodica IVA Split payment Istituzionale";
                }
                R["description"] = descr + " - dal " + txtDal.Text + " al " + txtAl.Text;

            }

            //generaMandatiReversali(DS,mov);
        }

        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }

        byte calcolaFlag() {
            bool comm_promiscua_kind = chkCommerciale.Checked;
            bool istituzionale_kind = chkIstituzionale.Checked;
            bool split_kind = chkIstituzionaleSplit.Checked;
            byte flag = 0;
            flag = 0;
            if (comm_promiscua_kind) flag += 1;
            if (istituzionale_kind) flag += 2;
            if (split_kind) flag += 4;
            return flag;
        }

        private void ViewAutomatismi(DataSet DS) {
            bool automatismi = false;
            string spesa = null;
            if (DS.Tables["expense"] != null) {
                DataTable Var = DS.Tables["expense"];
                spesa = QHC.FieldIn("idexp", Var.Select(), "idexp");
                if (Var.Select().Length > 0) automatismi = true;
            }
            string entrata = null;
            if (DS.Tables["income"] != null) {
                DataTable Var = DS.Tables["income"];
                entrata = QHC.FieldIn("idinc", Var.Select(), "idinc");
                if (Var.Select().Length > 0) automatismi = true;
            }
            if (!automatismi) return;

            Form F = ShowAutomatismi.Show(Meta, spesa, entrata, null, null);
            F.ShowDialog(this);
        }

        private void SaveData() {
            object prorata = HelpForm.GetObjectFromString(typeof(decimal), txtProrata.Text, tag_perc);
            object promiscuo = HelpForm.GetObjectFromString(typeof(decimal), txtPromiscuo.Text, tag_perc);

            int month = m_ToDate.Month;
            int year = m_ToDate.Year;
            if (month + m_PeriodicitaMese > 12) {
                year++;
                month = month + m_PeriodicitaMese - 12;
            }

            //riga di liquidazioneiva
            Meta.SetDefaults(DS.ivapay);
            DataRow Rliquidazione = Meta.Get_New_Row(null, DS.ivapay);
            Rliquidazione["paymentkind"] = "C";
            Rliquidazione["start"] = HelpForm.GetObjectFromString(typeof(DateTime), txtDal.Text, null);
            Rliquidazione["stop"] = HelpForm.GetObjectFromString(typeof(DateTime), txtAl.Text, null);
            Rliquidazione["prorata"] = prorata;
            Rliquidazione["mixed"] = promiscuo;

            if (chkCommerciale.Checked) {
                Rliquidazione["creditamount"] = credito_immediato;
                Rliquidazione["creditamountdeferred"] = credito_differito;
                Rliquidazione["debitamount"] = vendite_immediata;
                Rliquidazione["debitamountdeferred"] = vendite_deferred;
                Rliquidazione["totalcredit"] = totale_iva_credito;
                Rliquidazione["totaldebit"] = totale_iva_debito;
                Rliquidazione["prev_debit"] = saldo_precedente;
            }

            if (chkIstituzionale.Checked) {
                Rliquidazione["creditamount12"] = credito_immediato12;
                Rliquidazione["creditamountdeferred12"] = credito_differito12;
                Rliquidazione["debitamount12"] = debito_immediato12;
                Rliquidazione["debitamountdeferred12"] = debito_differito12;
                Rliquidazione["totalcredit12"] = totale_iva_credito12;
                Rliquidazione["totaldebit12"] = totale_iva_debito12;
                Rliquidazione["taxableintrastat12"] = taxableintrastat12;
                Rliquidazione["ivaintrastat12"] = ivaintrastat12;
                Rliquidazione["prev_debit12"] = saldo_precedente12;
            }


            if (chkIstituzionaleSplit.Checked) {
                Rliquidazione["debitamountsplit"] = debito_immediatosplit;
                Rliquidazione["debitamountdeferredsplit"] = debito_differitosplit;
                Rliquidazione["totaldebitsplit"] = totale_iva_debitosplit;
                Rliquidazione["taxablesplit"] = taxablesplit;
                Rliquidazione["ivasplit"] = ivasplit;
                Rliquidazione["prev_debitsplit"] = saldo_precedentesplit;
            }



            Rliquidazione["flag"] = calcolaFlag();



            //crea righe di ivapaydetail (debito) (REGISTRI DI VENDITA)
            foreach (DataRow R in TableIva.Select(QHC.CmpEq("registerclass", "V"))) {
                bool istituzionale = false;
                //bool iscommerciale = false;
                //bool ispromiscuo = false;

                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;
                bool flagintracom = R["flagintracom"].ToString().ToUpper() != "N";
                bool flagsplit = R["flagsplit"].ToString().ToUpper() != "N";
                bool fatturaDiAcquisto = R["kind"].ToString().ToUpper() == "A";
                bool fatturaDiVendita = !fatturaDiAcquisto;

                if (istituzionale && !flagintracom && !flagsplit) continue;
                if (!istituzionale && flagsplit && fatturaDiVendita) continue;

                //if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 2) iscommerciale = true;
                //if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 3) ispromiscuo = true;  
                string filtroDett = QHC.AppAnd(QHC.CmpMulti(Rliquidazione, "yivapay", "nivapay"),
                    QHC.CmpMulti(R, "idivaregisterkind"));

                DataRow[] rDett = DS.ivapaydetail.Select(filtroDett);
                decimal imponibile12 = 0; // Valorizziamo il campo della tabella solo se il registro è istituzionale.
                decimal imponibilesplit = 0; // Valorizziamo il campo della tabella solo se il registro è split.

                decimal currivagrosspayed = CfgFn.GetNoNullDecimal(R["currivagrosspayed"]);


                if (istituzionale && flagintracom) {
                    imponibile12 = CfgFn.GetNoNullDecimal(R["taxable"]);
                }
                if (istituzionale && flagsplit) {
                    imponibilesplit = CfgFn.GetNoNullDecimal(R["taxable"]);
                }

                if (rDett.Length == 0) {
                    DataRow Rdettaglio = DS.ivapaydetail.NewRow();
                    Rdettaglio["yivapay"] = Rliquidazione["yivapay"];
                    Rdettaglio["nivapay"] = Rliquidazione["nivapay"];
                    Rdettaglio["idivaregisterkind"] = R["idivaregisterkind"];
                    if (R["flagdeferred"].ToString().ToUpper() == "S") {
                        Rdettaglio["ivadeferred"] = currivagrosspayed;
                        Rdettaglio["ivanetdeferred"] = currivagrosspayed;
                        Rdettaglio["taxabledeferred12"] = imponibile12;
                        Rdettaglio["taxabledeferredsplit"] = imponibilesplit;
                    }
                    else {
                        Rdettaglio["iva"] = currivagrosspayed;
                        Rdettaglio["ivanet"] = currivagrosspayed;
                        Rdettaglio["taxable12"] = imponibile12;
                        Rdettaglio["taxablesplit"] = imponibilesplit;
                    }
                    Rdettaglio["cu"] = "AUTO";
                    Rdettaglio["ct"] = DateTime.Now;
                    Rdettaglio["lu"] = "AUTO";
                    Rdettaglio["lt"] = DateTime.Now;
                    DS.ivapaydetail.Rows.Add(Rdettaglio);
                }
                else {
                    if (R["flagdeferred"].ToString().ToUpper() == "S") {
                        rDett[0]["ivadeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivadeferred"])
                                                  + CfgFn.GetNoNullDecimal(currivagrosspayed);
                        rDett[0]["ivanetdeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanetdeferred"])
                                                     + CfgFn.GetNoNullDecimal(currivagrosspayed);
                        rDett[0]["taxabledeferred12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferred12"])
                                                        + imponibile12;
                        rDett[0]["taxabledeferredsplit"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferredsplit"])
                                                           + imponibilesplit;
                    }
                    else {
                        rDett[0]["iva"] = CfgFn.GetNoNullDecimal(rDett[0]["iva"])
                                          + CfgFn.GetNoNullDecimal(currivagrosspayed);
                        rDett[0]["ivanet"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanet"])
                                             + CfgFn.GetNoNullDecimal(currivagrosspayed);
                        rDett[0]["taxable12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxable12"])
                                                + imponibile12;
                        rDett[0]["taxablesplit"] = CfgFn.GetNoNullDecimal(rDett[0]["taxablesplit"])
                                                   + imponibilesplit;
                    }
                }

            }


            //crea righe di ivapaydetail (credito)        (REGISTRI DI ACQUISTO)
            foreach (DataRow R in TableIva.Select(QHC.CmpEq("registerclass", "A"))) {
                bool istituzionale = false;
                //bool commerciale = false;
                //bool promiscuo = false;

                if (CfgFn.GetNoNullInt32(R["flagactivity"]) == 1) istituzionale = true;
                bool flagintracom = R["flagintracom"].ToString().ToUpper() != "N";
                bool flagsplit = R["flagsplit"].ToString().ToUpper() != "N";
                bool fatturaDiAcquisto = R["kind"].ToString().ToUpper() == "A";
                bool fatturaDiVendita = !fatturaDiAcquisto;

                if (istituzionale && !flagintracom && !flagsplit) continue;
                if (!istituzionale && flagsplit && fatturaDiVendita) continue;

                string filtroDett = QHC.AppAnd(QHC.CmpMulti(Rliquidazione, "yivapay", "nivapay"),
                    QHC.CmpMulti(R, "idivaregisterkind"));
                DataRow[] rDett = DS.ivapaydetail.Select(filtroDett);
                decimal ivatotal = CfgFn.GetNoNullDecimal(R["currivagrosspayed"]);
                decimal abatable = CfgFn.GetNoNullDecimal(R["singola"]);
                decimal unabatable = CfgFn.GetNoNullDecimal(R["currivaunabatable"]);
                decimal imponibile12 = 0; // Valorizziamo il campo della tabella solo se il registro è istituzionale.
                decimal imponibilesplit = 0; // Valorizziamo il campo della tabella solo se il registro è split.
                if (istituzionale && flagintracom) {
                    imponibile12 = CfgFn.GetNoNullDecimal(R["taxable"]);
                }
                if (istituzionale && flagsplit) {
                    imponibilesplit = CfgFn.GetNoNullDecimal(R["taxable"]);
                }

                if (rDett.Length == 0) {
                    DataRow Rdettaglio = DS.ivapaydetail.NewRow();
                    Rdettaglio["yivapay"] = Rliquidazione["yivapay"];
                    Rdettaglio["nivapay"] = Rliquidazione["nivapay"];
                    Rdettaglio["idivaregisterkind"] = R["idivaregisterkind"];
                    if (R["flagdeferred"].ToString().ToUpper() == "S") {
                        Rdettaglio["ivadeferred"] = ivatotal;
                        Rdettaglio["unabatabledeferred"] = unabatable;
                        Rdettaglio["ivanetdeferred"] = abatable;
                        Rdettaglio["taxabledeferred12"] = imponibile12;
                        Rdettaglio["taxabledeferredsplit"] = imponibilesplit;
                    }
                    else {
                        Rdettaglio["iva"] = ivatotal;
                        Rdettaglio["unabatable"] = unabatable;
                        Rdettaglio["ivanet"] = abatable;
                        Rdettaglio["taxable12"] = imponibile12;
                        Rdettaglio["taxablesplit"] = imponibilesplit;
                    }
                    Rdettaglio["prorata"] = Rliquidazione["prorata"];
                    Rdettaglio["mixed"] = (R["flagmixed"].ToString().ToUpper() == "S")
                        ? Rliquidazione["mixed"]
                        : DBNull.Value;
                    Rdettaglio["cu"] = "AUTO";
                    Rdettaglio["ct"] = DateTime.Now;
                    Rdettaglio["lu"] = "AUTO";
                    Rdettaglio["lt"] = DateTime.Now;
                    DS.ivapaydetail.Rows.Add(Rdettaglio);
                }
                else {
                    if (R["flagdeferred"].ToString().ToUpper() == "S") {
                        rDett[0]["ivadeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivadeferred"]) + ivatotal;
                        rDett[0]["unabatabledeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["unabatabledeferred"])
                                                         + unabatable;
                        rDett[0]["ivanetdeferred"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanetdeferred"])
                                                     + abatable;
                        rDett[0]["taxabledeferred12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferred12"])
                                                        + imponibile12;
                        rDett[0]["taxabledeferredsplit"] = CfgFn.GetNoNullDecimal(rDett[0]["taxabledeferredsplit"])
                                                           + imponibilesplit;
                    }
                    else {
                        rDett[0]["iva"] = CfgFn.GetNoNullDecimal(rDett[0]["iva"]) + ivatotal;
                        rDett[0]["unabatable"] = CfgFn.GetNoNullDecimal(rDett[0]["unabatable"])
                                                 + unabatable;
                        rDett[0]["ivanet"] = CfgFn.GetNoNullDecimal(rDett[0]["ivanet"])
                                             + abatable;
                        rDett[0]["taxable12"] = CfgFn.GetNoNullDecimal(rDett[0]["taxable12"])
                                                + imponibile12;
                        rDett[0]["taxablesplit"] = CfgFn.GetNoNullDecimal(rDett[0]["taxablesplit"])
                                                   + imponibilesplit;
                    }
                }
            }

            creaRigheInvoiceDeferred(Rliquidazione);
            creaRigheInvoiceDetailDeferred(Rliquidazione);
			object scadenza = DBNull.Value;
			 

			scadenza  = HelpForm.GetObjectFromString(typeof(DateTime), txtDataRegolamento.Text, "x.y");

			if ((TAutomatismi != null) && (TAutomatismi.Rows.Count > 0))
                insertMov(Rliquidazione, scadenza, false);

            // I campi refundamount e paymentamount vengono riempiti solo dopo aver creato i movimenti di entrata e spesa
            bool assegnaData = false;
            if (chkCommerciale.Checked) {
                if (liquidazionecorrente < 0) {
                    Rliquidazione["refundamount"] = -liquidazionecorrente;
                    assegnaData = true;
                }
                if (liquidazionecorrente > 0) {
                    Rliquidazione["paymentamount"] = liquidazionecorrente;
                    assegnaData = true;
                }
            }

            if (chkIstituzionale.Checked) {
                if (liquidazionecorrente12 < 0) {
                    Rliquidazione["refundamount12"] = -liquidazionecorrente12;
                    assegnaData = true;
                }
                if (liquidazionecorrente12 > 0) {
                    Rliquidazione["paymentamount12"] = liquidazionecorrente12;
                    assegnaData = true;
                }
            }


            if (chkIstituzionaleSplit.Checked) {
                if (liquidazionecorrentesplit > 0) {
                    Rliquidazione["paymentamountsplit"] = liquidazionecorrentesplit;
                    assegnaData = true;
                }
            }


            if (assegnaData) {
				object assesmentdate = DBNull.Value;
				assesmentdate = HelpForm.GetObjectFromString(typeof(DateTime),
					txtDataRegolamento.Text.ToString(), "x.y");

				Rliquidazione["assesmentdate"] = assesmentdate;

			}
            if (VerificaGestioneGirofondi()) {
                if (MessageBox.Show(
                    "Genero i girofondi da o verso i dipartimenti a compensazione dell'iva a debito/credito ?",
                    "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    GeneraGirofondi();
                }
            }
            if (((liquidazionecorrente != 0) && MovimentiFinanziariConfigurati())
                || ((liquidazionecorrente12 != 0) && MovimentiFinanziariConfigurati12())
                || ((liquidazionecorrentesplit != 0) && MovimentiFinanziariConfiguratiSplit())
                ) {
                int fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
                DataSet dsCopy = DS.Copy();
                GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, dsCopy,
                    fasespesamax, fasespesamax, "ivapay", true);
                ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
                string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind", QHC.CmpEq("codesorkind_siopespese", Meta.GetSys("codesorkind_siopespese")), "newcomputesorting").ToString();
                if (newcomputesorting == "S") {
                    ga.GeneraClassificazioniSiope2018(ga.DSP, "expense");
                    ga.GeneraClassificazioniSiope2018(ga.DSP, "income");
                }
                bool res = ga.GeneraAutomatismiAfterPost(true);
                if (!res) {
                    MessageBox.Show(this,
                        "Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
                    return;
                }
                //ga.GeneraClassificazioniIndirette(ga.DSP, true); lo fa già GeneraClassificazioniAutomatiche
                insertAltriPagamenti(ga.DSP, Rliquidazione);
                res = ga.doPost(Meta.Dispatcher);
                if (res) {
                    ViewAutomatismi(ga.DSP);
                    DataRow rLiq = ga.DSP.Tables["ivapay"].Rows[0];
                    var epm = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "ivapay");
                    epm.generaScritture(rLiq);
                }
            }
            else {
                Easy_PostData EP = new Easy_PostData();
                EP.InitClass(DS, Conn);
                bool res = EP.DO_POST();
                if (res) {
                    DataRow rLiq = DS.Tables["ivapay"].Rows[0];
                    var epm = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "ivapay");
                    epm.generaScritture(rLiq);
                }
            }


            DS.AcceptChanges();
        }

        private void insertAltriPagamenti(DataSet DS, DataRow rIvaPay) {
            if ((!MovimentiFinanziariConfigurati()) && (!MovimentiFinanziariConfigurati12()) &&
                (!MovimentiFinanziariConfiguratiSplit())) return;

            if (liquidazionecorrente > 0) {
                foreach (DataRow R in AltriPagamenti.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expense"], null,
                        QHS.CmpEq("idexp", R["idexp"]), null, true);
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expenseyear"], null,
                 QHS.AppAnd(QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), null, true);
                    DataRow[] RowsExpense = DS.Tables["expense"].Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 12;
                    }

                }
            }

            if (liquidazionecorrente12 > 0) {
                foreach (DataRow R in AltriPagamentiIntraExtraUe.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expense"], null,
                        QHS.CmpEq("idexp", R["idexp"]), null, true);
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expenseyear"], null,
                 QHS.AppAnd(QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), null, true);
                    DataRow[] RowsExpense = DS.Tables["expense"].Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 17;
                    }

                }
            }

            if (liquidazionecorrentesplit > 0) {
                foreach (DataRow R in AltriPagamentiIstituzionaleSplitPayment.Rows) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expense"], null,
                        QHS.CmpEq("idexp", R["idexp"]), null, true);
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.Tables["expenseyear"], null,
                      QHS.AppAnd(QHS.CmpEq("idexp", R["idexp"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), null, true);

                    DataRow[] RowsExpense = DS.Tables["expense"].Select(QHC.CmpEq("idexp", R["idexp"]));
                    if (RowsExpense.Length > 0) {
                        DataRow RowExp = RowsExpense[0];
                        RowExp["autokind"] = 23;
                    }
                }
            }


            string ivapaymov = "ivapay" + "expense";
            string idfield = "idexp";


            foreach (DataRow R in AltriPagamenti.Rows) {
                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
                NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

            foreach (DataRow R in AltriPagamentiIntraExtraUe.Rows) {
                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
                NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }

            foreach (DataRow R in AltriPagamentiIstituzionaleSplitPayment.Rows) {
                DataRow NewIvaPay_MovRow = DS.Tables[ivapaymov].NewRow();
                NewIvaPay_MovRow["yivapay"] = rIvaPay["yivapay"];
                NewIvaPay_MovRow["nivapay"] = rIvaPay["nivapay"];
                NewIvaPay_MovRow[idfield] = R[idfield];
                NewIvaPay_MovRow["cu"] = "AAAA";
                NewIvaPay_MovRow["ct"] = DateTime.Now;
                NewIvaPay_MovRow["lu"] = "AAAAA";
                NewIvaPay_MovRow["lt"] = DateTime.Now;
                DS.Tables[ivapaymov].Rows.Add(NewIvaPay_MovRow);
            }
        }

        bool VerificaGestioneGirofondi() {
            if (DS.ivaregisterkind.Select(QHC.IsNotNull("idtreasurer")).Length == 0) return false;
            object idtres_default = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("flagdefault", "S"), "idtreasurer");
            if (idtres_default == null) idtres_default = DBNull.Value;
            foreach (DataRow r in DS.ivapaydetail.Select()) {
                if (CfgFn.GetNoNullDecimal(r["ivanetdeferred"]) == 0
                    && CfgFn.GetNoNullDecimal(r["ivanet"]) == 0) continue;
                string ftr = QHC.CmpEq("idivaregisterkind", r["idivaregisterkind"]);
                DataRow rivareg = DS.ivaregisterkind.Select(ftr)[0];
                if (rivareg["idtreasurer"] != DBNull.Value && rivareg["idtreasurer"] != idtres_default) return true;
            }
            return false;
        }

        void GeneraGirofondi() {
            DS.moneytransfer.Clear();
            MetaData metaMonTr = MetaData.GetDispatcher(this).Get("moneytransfer");
            metaMonTr.SetDefaults(DS.moneytransfer);
            object idtres_default = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("flagdefault", "S"), "idtreasurer");
            if (idtres_default == null) {
                MessageBox.Show("E' necessario configurare un cassiere predefinito, i girofondi non saranno generati.",
                    "Errore");
                return;
            }
            foreach (DataRow r in DS.ivapaydetail.Select()) {
                if (CfgFn.GetNoNullDecimal(r["ivanet"]) == 0
                    && CfgFn.GetNoNullDecimal(r["ivanetdeferred"]) == 0) continue;
                string ftr = QHC.CmpEq("idivaregisterkind", r["idivaregisterkind"]);

                DataRow rivareg = DS.ivaregisterkind.Select(ftr)[0];
                if (rivareg["idtreasurer"] == DBNull.Value || rivareg["idtreasurer"] == idtres_default) continue;
                DataRow mt = metaMonTr.Get_New_Row(null, DS.moneytransfer);
                decimal total = CfgFn.GetNoNullDecimal(r["ivanet"]) + CfgFn.GetNoNullDecimal(r["ivanetdeferred"]);
                if (total == 0) continue;
                string rClass = rivareg["registerclass"].ToString().ToUpper();
                string rActivity = rivareg["flagactivity"].ToString().ToUpper();

                //DEBITO
                if (rClass == "V" || (rClass == "A" && rActivity == "1")) {
                    mt["idtreasurersource"] = rivareg["idtreasurer"];
                    mt["idtreasurerdest"] = idtres_default;
                    mt["amount"] = total;
                }

                //CREDITO
                if (rClass == "A" && rActivity != "1") {
                    mt["idtreasurerdest"] = rivareg["idtreasurer"];
                    mt["idtreasurersource"] = idtres_default;
                    mt["amount"] = total;
                }


                mt["transferkind"] = "I";
                mt["description"] = "Girofondo a compensazione di liq.iva dal " + txtDal.Text + " al " + txtAl.Text +
                                    " registro " + rivareg["description"].ToString();
            }
        }



        private void chkEndOfYear_CheckedChanged(object sender, EventArgs e) {
            ComputePeriod(periodo);
        }

        private void txtDataRegolamento_Leave(object sender, EventArgs e) {
            HelpForm.ExtLeaveDateTimeTextBox(txtDataRegolamento, null);
        }

        public bool DatiValidi() {
            try {
                DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
                    txtDataRegolamento.Text.ToString(), "x.y");
                return true;
            }
            catch {
                MessageBox.Show("E' necessario inserire una data valida");
                txtDataRegolamento.Focus();
                return false;
            }

        }

        private void btnCambiaUPB_Click(object sender, EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridEntrata);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            cambiaUPB(RigheSelezionate);
        }

        void cambiaUPB(DataRow[] RigheSelezionate) {
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;

            object idupb = RigheSelezionate[0]["idupb"];
            object idfin = RigheSelezionate[0]["idfin"];

            FrmAskInfo AskUpb = new FrmAskInfo(idupb, idfin, Disp, Conn);

            if (AskUpb.ShowDialog() != DialogResult.OK) return;
            if (AskUpb.SelectedUpb == null) return;
            if (AskUpb.SelectedUpb["idupb"] == DBNull.Value) return;

            for (int i = 0; i < RigheSelezionate.Length; i++) {
                RigheSelezionate[i]["idupb"] = AskUpb.SelectedUpb["idupb"];
                RigheSelezionate[i]["codeupb"] = AskUpb.SelectedUpb["codeupb"];
                TAutomatismi.Rows[i]["idupb"] = AskUpb.SelectedUpb["idupb"];
                TAutomatismi.Rows[i]["codeupb"] = AskUpb.SelectedUpb["codeupb"];
                TAutomatismi.Rows[i].AcceptChanges();
            }
        }

        private void btnCambiaUPBSpesa_Click(object sender, EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            cambiaUPB(RigheSelezionate);
        }

        private void tabController_SelectionChanged(object sender, EventArgs e) {

        }



        string GetFilterExpense() {
            string MyFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            MyFilter = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            //  non deve essere stato trasmesso
            //MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("npaymenttransmission"));  task 10427 rimuovo il filtro
            //  non deve essere un automatismo
            MyFilter = QHS.AppAnd(MyFilter, "(autokind is null)");
            return MyFilter;
        }

        private void CollegaPagamentiallaLiquidazione(string kind) {
            // private DataTable AltriPagamenti;
            // private DataTable AltriPagamentiIntraExtraUe;
            // private DataTable AltriPagamentiIstituzionaleSplitPayment;
            MetaData MetaExpense = Disp.Get("expenseview");
            string MyFilter = GetFilterExpense();
            MetaExpense.FilterLocked = true;
            MetaExpense.DS = DS;
            DataRow SelectedExpense = MetaExpense.SelectOne("default", MyFilter, null, null);


            if (SelectedExpense == null) return;
            if (SelectedExpense["idexp"] == DBNull.Value) return;
            DataTable Table = new DataTable();

            switch (kind.ToString().ToLower()) {
                case "altriliquidazione": {
                    Table = AltriPagamenti;
                    break;
                }
                case "alltriintraextraue": {
                    Table = AltriPagamentiIntraExtraUe;
                    break;
                }
                case "altriistituzionalesplitpayment": {
                    Table = AltriPagamentiIstituzionaleSplitPayment;
                    break;
                }
            }

            DataRow NewR = Table.NewRow();
            NewR["idexp"] = SelectedExpense["idexp"];
            NewR["amount"] = SelectedExpense["curramount"];
            NewR["phase"] = SelectedExpense["phase"];
            NewR["ymov"] = SelectedExpense["ymov"];
            NewR["nmov"] = SelectedExpense["nmov"];
            NewR["registry"] = SelectedExpense["registry"];
            NewR["description"] = SelectedExpense["description"];
            NewR["upb"] = SelectedExpense["upb"];
            Table.Rows.Add(NewR);
        }

        private void btnCollegaAltri_Click(object sender, EventArgs e) {
            CollegaPagamentiallaLiquidazione("AltriLiquidazione");
        }

        private void btnCollegaaltriIntraExtraUe_Click(object sender, EventArgs e) {
            CollegaPagamentiallaLiquidazione("alltriintraextraue");
        }

        private void button1_Click(object sender, EventArgs e) {
            CollegaPagamentiallaLiquidazione("altriistituzionalesplitpayment");
        }

        private void ScollegaPagamentidaLiquidazione(string kind) {
            DataTable Table = new DataTable();
            DataGrid Grid = new DataGrid();
            switch (kind.ToString().ToLower()) {
                case "altriliquidazione": {
                    Table = AltriPagamenti;
                    Grid = gridAltri;
                    break;
                }
                case "alltriintraextraue": {
                    Table = AltriPagamentiIntraExtraUe;
                    Grid = gridAltriIstituzionaleIntra;
                    break;
                }
                case "altriistituzionalesplitpayment": {
                    Table = AltriPagamentiIstituzionaleSplitPayment;
                    Grid = gridAltriIstituzionaleSplit;
                    break;
                }
            }


            DataRow[] RigheSelezionate = GetGridSelectedRows(Grid);
            if (RigheSelezionate == null) return;
            if (RigheSelezionate.Length == 0) return;
            // cancellazione righe selezionate
            for (int i = 0; i < RigheSelezionate.Length; i++) {
                RigheSelezionate[i].Delete();
            }
            Table.AcceptChanges();
        }

        private void btnSCollegaAltri_Click(object sender, EventArgs e) {
            ScollegaPagamentidaLiquidazione("altriliquidazione");
        }

        private void btnSCollegaAltriIntra_Click(object sender, EventArgs e) {
            ScollegaPagamentidaLiquidazione("alltriintraextraue");
        }

        private void btnSCollegaAltriSplit_Click(object sender, EventArgs e) {
            ScollegaPagamentidaLiquidazione("altriistituzionalesplitpayment");
        }
    }
}