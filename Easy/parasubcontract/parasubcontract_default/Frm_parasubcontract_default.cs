/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Globalization;
using funzioni_configurazione;//funzioni_configurazione
using System.Data.SqlClient;
using calcolocedolino;//calcolocedolino
using parasubcontract_generazionecedolini;//contratto_generazionecedolini
using SituazioneViewer;//SituazioneViewer
using ep_functions;
using ap_functions;
using metaeasylibrary;
using q = metadatalibrary.MetaExpression;
using System.Collections.Generic;
using System.Linq;

namespace parasubcontract_default { //contratto//

    /// <summary>
    /// Summary description for frmcontratto.
    /// </summary>
    public class Frm_parasubcontract_default : System.Windows.Forms.Form {
        InputPerCalcoloCostoTotale inputPerCalcoloCostoTotale;
        InputPerCalcoloCostoTotale inputDatiSalvati;
        InputPerGestioneCud inputPerGestioneCud;
        DataTable tAddress;
        bool inChiusura = false;
        string filteresercizio;
        private MetaData Meta;
        decimal lastTotImponibileCud = 0;
        object lastPrestazione = DBNull.Value;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        private EP_Manager EPM;
        private EP_Manager EPM_payroll;

        #region Controlli del form

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDurataMesi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.TextBox txtPercipiente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.GroupBox grpPercipiente;
        private System.Windows.Forms.GroupBox grpContratto;
        public dsmeta DS;
        private System.Windows.Forms.GroupBox grpComune;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SubEntity_txtAddReg;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SubEntity_txtAddProv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SubEntity_txtAddCom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox SubEntity_txtNumRate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox SubEntity_cmbMeseInizio;
        private System.Windows.Forms.TabPage tabCUD;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.DataGrid dataGrid3;
        private System.Windows.Forms.Button inserisci_CUD;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGrid dgrid_CUD;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGrid dgrid_DedCud;
        private System.Windows.Forms.DataGrid dgrid_DetCud;
        private System.Windows.Forms.Button btnDeleteDet;
        private System.Windows.Forms.Button btnEditDet;
        private System.Windows.Forms.Button btnInsertDet;
        private System.Windows.Forms.Button btnDeleteDed;
        private System.Windows.Forms.Button btnEditDed;
        private System.Windows.Forms.Button btnInsertDed;
        private System.Windows.Forms.TabPage tabAddizionali;
        private System.Windows.Forms.TabPage tabErogazioni;
        private System.Windows.Forms.TabPage tabFamiliare;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.DataGrid dataGrid8;
        private System.Windows.Forms.ToolTip myTip;
        private System.Windows.Forms.DataGrid dgCedolini;
        private System.Windows.Forms.TabPage tabCedolini;
        private System.Windows.Forms.TabPage tabImponibili;
        private System.Windows.Forms.TabPage tabAltreCollINAIL;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.DataGrid dataGrid10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox grpAliquoteIrpef;
        private System.Windows.Forms.TextBox SubEntity_txtImponibilePrevidenziale;
        private System.Windows.Forms.ComboBox SubEntity_cmbAliquotaIRPEF;
        private System.Windows.Forms.RadioButton SubEntity_rbScaglioniIRPEF;
        private System.Windows.Forms.RadioButton SubEntity_rbAliquotaMarginale;
        private System.Windows.Forms.TextBox SubEntity_txtGiornicontratto;
        private System.Windows.Forms.TextBox SubEntity_txtImponibilecontratto;
        private System.Windows.Forms.TextBox SubEntity_txtPrevidenzialeCUD;
        private System.Windows.Forms.TextBox SubEntity_txtGiorniCUD;
        private System.Windows.Forms.Button btnCalcolaCedolino;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox SubEntity_txtDataFineCompetenza;
        private System.Windows.Forms.TextBox SubEntity_txtDataInizioCompetenza;
        private System.Windows.Forms.Button btnVisualizzaCedolino;
        private System.Windows.Forms.GroupBox grpAddizionaliPassate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox grpDettagliPrevidenzialiAssistenziali;
        private System.Windows.Forms.Button btnAttivitaPrevINPS;
        private System.Windows.Forms.Button btnAltreFormeAssicurative;
        //		private System.Windows.Forms.ComboBox cmbTipoLibro;
        //		private System.Windows.Forms.Button btnTipoLibro;
        private System.Windows.Forms.ComboBox cmbPAT;
        private System.Windows.Forms.Button btnPAT;
        //		private System.Windows.Forms.Button button1;
        //		private System.Windows.Forms.ComboBox cmbDescrCedolino;
        private System.Windows.Forms.GroupBox grpDettagliFiscali;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnGeneraCedolini;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtLordoAlBeneficiario;
        private System.Windows.Forms.TabPage tabGenerale;
        private System.Windows.Forms.TabPage tabDatiRiepilogativi;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtFiscDip;
        private System.Windows.Forms.TextBox txtPrevDip;
        private System.Windows.Forms.TextBox txtAssisDip;
        private System.Windows.Forms.TextBox txtAssicDip;
        private System.Windows.Forms.TextBox txtAssicAmm;
        private System.Windows.Forms.TextBox txtAssisAmm;
        private System.Windows.Forms.TextBox txtPrevAmm;
        private System.Windows.Forms.TextBox txtFiscAmm;
        private System.Windows.Forms.TextBox txtTotaleRitAmmin;
        private System.Windows.Forms.TextBox txtTotaleRitDip;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txtLordoAlBeneficiarioRiep;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtCompensoNetto;
        private System.Windows.Forms.TabPage TabClassSuppl;
        private System.Windows.Forms.DataGrid dgrClassSuppl;
        private System.Windows.Forms.Button btnClassInserisci;
        private System.Windows.Forms.Button btnClassModifica;
        private System.Windows.Forms.Button btnClassElimina;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.DataGrid dataGrid4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabPage tabOneri;
        private System.Windows.Forms.DataGrid gridRitenute;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox txtStimaCostoTotale;
        private System.Windows.Forms.TextBox txtCostoTotale;
        private System.Windows.Forms.Button btnTipoRapporto;
        private System.Windows.Forms.ComboBox cmbTipoRapporto;
        private System.Windows.Forms.ComboBox cmbAttPrevidenzialeINPS;
        private System.Windows.Forms.ComboBox cmbAltreFormeAssicurative;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGrid dataGrid11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabFinanziario;
        private System.Windows.Forms.TabPage tabAnalitico;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.GroupBox gBoxCausaleCosto;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.TabPage tabEconoPatr;
        private System.Windows.Forms.TabPage tabAP;
        private System.Windows.Forms.Button btnGeneraAP;
        private System.Windows.Forms.Button btnVisualizzaAP;
        private System.Windows.Forms.Label labAPnongenerato;
        private System.Windows.Forms.Label labAPgenerato;
        private System.Windows.Forms.Button btnVerificaProblemi;
        private GroupBox grpAccontoAddCom;
        private Button btnCalcAcconto;
        private ComboBox SubEntity_cmbMeseInizioAcconto;
        private TextBox SubEntity_txtNumRateAcconto;
        private TextBox SubEntity_txtImportoAcconto;
        private Label label16;
        private Label label15;
        private Label label14;
        private Button btnTroncaContratto;
        private GroupBox groupBox19;
        private TextBox txtComuneAddRegionali;
        private TextBox txtComuneAddComunali;
        private Label label18;
        private TextBox textBox6;
        private Label label21;
        private TextBox textBox7;
        private GroupBox groupBox20;
        private TextBox txtComuneAddRegRata;
        private GroupBox groupBox21;
        private TextBox txtComuneAddComRata;
        private Label label19;
        private TextBox textBox8;
        private GroupBox gBoxCausaleDebitoCrg;
        private TextBox textBox9;
        private TextBox txtCodiceCausaleCrg;
        private Button button8;
        private GroupBox gBoxCausaleDebito;
        private TextBox textBox10;
        private TextBox txtCodiceCausaleDeb;
        private Button button21;
        private GroupBox groupBox24;
        private Button btnCambiaRuolo;
        private TextBox txtCompartoCSA;
        private TextBox txtInquadrcsa;
        private Label label20;
        private Label label22;
        private Label lblRuoloCSA;
        private TextBox txtRuoloCSA;
        private TabPage tabAttributi;
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
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private Button btnCollegaAP;
        private GroupBox grpNoTaxArea;
        private RadioButton SubEntity_rbtnNonApplicare;
        private RadioButton SubEntity_rbtnDedBaseGiorno;
        private RadioButton SubEntity_rbtnDedBaseIntero;
        private CheckBox SubEntity_chkApplicaBonus;
        private CheckBox SubEntity_chkExcludeFromCertificate;
        private TabPage tabDALIA;
        private GroupBox groupBox18;
        private Label label91;
        private TextBox textBox11;
        private ComboBox cmb_dalia_position;
        private Button btnVoceSpesaDalia;
        private TextBox txtVoceSpesaDalia;
        private Button btnQualificaDalia;
        private DataGrid dgCedoliniAltriEsercizi;
        private Label label23;
        private Label label24;
        private GroupBox grpBoxSiopeEP;
        private Button btnSiope;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkCCdedicato;
        private GroupBox grpCausaliAssunzioneDalia;
        private TextBox txtCausaleAssunzione;
        private Button btnEsclusioneCIG;
        private GroupBox groupBox22;
        private ComboBox cmbDaliaFunzionale;
        private GroupBox gboxDipartimento;
        private Button btnDipartimento;
        private TextBox txtCodiceDipartimento;
        public TextBox txtDaliaDipartimento;
        private System.ComponentModel.IContainer components;

        #endregion

        public Frm_parasubcontract_default() {
            InitializeComponent();
            DS.exhibitedcuddeduction.ExtendedProperties["gridmaster"] = "exhibitedcud";
            DS.exhibitedcudabatement.ExtendedProperties["gridmaster"] = "exhibitedcud";
            cmbDaliaFunzionale.DataSource = DS.dalia_funzionale;
            cmbDaliaFunzionale.DisplayMember = "title";
            cmbDaliaFunzionale.ValueMember = "iddalia_funzionale";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        int esercizio;
        DateTime primoDellAnno;
        DateTime ultimoDellAnno;
        DateTime primoDellAnnoPrec;
        DateTime ultimoDellAnnoPrec;
        object idsorkindDalia;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            idsorkindDalia = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");
            AccMotiveManager AM = new AccMotiveManager(gBoxCausaleCosto);
            AccMotiveManager AM01 = new AccMotiveManager(gBoxCausaleDebito);
            AccMotiveManager AM02 = new AccMotiveManager(gBoxCausaleDebitoCrg);
            esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filtroMaxFase = QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase"));
            filteresercizio = QHS.CmpEq("ayear", esercizio);
    
            primoDellAnno = new DateTime(esercizio, 01, 01);
            primoDellAnnoPrec = new DateTime(esercizio - 1, 01, 01);
            ultimoDellAnno = new DateTime(esercizio, 12, 31);
            ultimoDellAnnoPrec = new DateTime(esercizio - 1, 12, 31);
            string filterTipoPrestazione = QHS.CmpEq("module", "COCOCO");
            DS.service.setStaticFilter(filterTipoPrestazione);
            DS.parasubcontractyear.setStaticFilter(filteresercizio);
            DS.abatementcode.setStaticFilter(filteresercizio);
            DS.deductioncode.setStaticFilter(filteresercizio);
            DS.otherinsurance.setStaticFilter(filteresercizio);
            DS.parasubcontractview.setStaticFilter(filteresercizio);
            DS.payroll.setSorting("flagbalance, fiscalyear, npayroll");
            DS.payroll_altriesercizi.setSorting("flagbalance, fiscalyear, npayroll");
            string filtroAnnoFiscale = QHS.CmpEq("fiscalyear", esercizio);
            DS.payroll.setStaticFilter(filtroAnnoFiscale);
            string filtroAltroAnnoFiscale = QHS.CmpNe("fiscalyear", esercizio);
            DS.payroll_altriesercizi.setStaticFilter(filtroAltroAnnoFiscale);

            DS.exhibitedcud.setStaticFilter(filtroAnnoFiscale);  // era filtroAltroAnnoFiscale
            DS.parasubcontractfamily.setStaticFilter(filteresercizio);
            DS.sortingview1.setStaticFilter(filteresercizio);

            DS.sortingview1.setTableForReading("sortingview");
			DS.upb_payroll.setTableForReading("upb");
			DS.upb_payrollother.setTableForReading("upb");
			DS.payroll_altriesercizi.setTableForReading("payroll");
            
            DS.deductibleexpense.setStaticFilter(filteresercizio);
            DS.abatableexpense.setStaticFilter(filteresercizio);
            DS.expensepayrollview.setStaticFilter(QHS.AppAnd(filteresercizio, filtroAnnoFiscale));

            DS.exhibitedcud.setSorting("idexhibitedcud DESC");
            DS.config.CacheTable(filteresercizio, null, false);
            DS.monthname.setSorting("code");

            DS.abatement.CacheTable();
            DS.deduction.CacheTable();
            DS.tax.CacheTable();
            
            HelpForm.SetDenyNull(DS.parasubcontract.Columns["requested_doc"], true);
            int esercizioprec = esercizio - 1;
            grpAddizionaliPassate.Text = "Addizionali derivanti da contratti della stessa università al 31/12/" +
                                         esercizioprec;
            grpAccontoAddCom.Text = "Acconto dell'addizionale comunale per l'esercizio " +
                                    Meta.GetSys("esercizio").ToString();

            this.txtDataFine.LostFocus += new System.EventHandler(this.txtDataFine_LostFocus);
            this.txtDataInizio.LostFocus += new System.EventHandler(this.txtDataInizio_LostFocus);
            //this.txtStimaCostoTotale.LostFocus += new System.EventHandler(this.txtStimaCostoTotale_LostFocus);
            this.txtLordoAlBeneficiario.LostFocus += new System.EventHandler(this.txtLordoAlBeneficiario_LostFocus);
            fillTipoComunicazione();

            string filterEpOperationSF = QHS.CmpEq("idepoperation", "cococo");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "cococo");
            filterEpOperationEP = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationEP, Meta.Conn);
            filterEpOperationSF = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationSF, Meta.Conn);
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperationSF);
            DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "cococo_deb");
            filterEpOperationDeb = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDeb, Meta.Conn);
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");


            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filteresercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow rConfig = tExpSetup.Rows[0];
                object idsorkind1 = rConfig["idsortingkind1"];
                object idsorkind2 = rConfig["idsortingkind2"];
                object idsorkind3 = rConfig["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl2.TabPages.Remove(tabAnalitico);
                }
            }


            gestisciGrpNoTaxArea();
            tAddress = DataAccess.CreateTableByName(Meta.Conn, "address", "idaddress, codeaddress");
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tAddress, null,
                QHS.FieldIn("codeaddress", new object[] {"07_SW_DOM", "07_SW_DEF"}), null, true);

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
                null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }
            bool IsAdmin = (Meta.GetSys("manage_prestazioni") != null)
                ? Meta.GetSys("manage_prestazioni").ToString() == "S"
                : false;
            object flag_escludidacu = Conn.GetUsr("flag_escludidacu");
            bool function_enabled = ((flag_escludidacu != null && flag_escludidacu.ToString().ToUpper() == "'S'"));

            SubEntity_chkExcludeFromCertificate.Enabled = IsAdmin||function_enabled;
            HelpForm.SetDenyNull(DS.parasubcontractyear.Columns["flagexcludefromcertificate"], true);
            HelpForm.SetDenyNull(DS.parasubcontractyear.Columns["flagbonusappliance"], true);
            EPM = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "parasubcontract");
            EPM_payroll = new EP_Manager(Meta, null, null, null, null, null, null, null, null, "payroll");
            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);
        }

        siope_helper SiopeObj;

        public void MetaData_AfterActivation() {
            DS.taxratebracket.Clear();
            Meta.myHelpForm.FillComboBoxTable(SubEntity_cmbAliquotaIRPEF, true);

        }

        /// <summary>
        /// Metodo che gestisce il group box delle applicazioni delle detrazioni (quando è nato gestiva le deduzioni)
        /// </summary>
        private void gestisciGrpNoTaxArea() {
            string captionGrp = (esercizio < 2007)
                ? "No Tax Area per questo contratto"
                : "Detrazioni per reddito del contratto";
            grpNoTaxArea.Text = captionGrp;

            string captionFirstRB = (esercizio < 2007) ? "Deduzione Base per Intero" : "Applica detrazioni per reddito";
            SubEntity_rbtnDedBaseIntero.Text = captionFirstRB;

            SubEntity_rbtnDedBaseGiorno.Visible = (esercizio < 2007);

            string tagSecondRB = (esercizio < 2007)
                ? "parasubcontractyear.notaxappliance:G?parasubcontractview.notaxappliance"
                : "";
            SubEntity_rbtnDedBaseGiorno.Tag = tagSecondRB;

            string captionThirdRB = (esercizio < 2007) ? "Non applicare la No Tax Area" : "Non applicare le detrazioni";
            SubEntity_rbtnNonApplicare.Text = captionThirdRB;
            ImpostaTestoToolTip();
        }





        /// <summary>
        /// Metodo che riempie la tabella tipocomunicazione, presente nel Dataset ma non nel DB
        /// Questa tabella serve solamente per far visualizzare il tipo di comunicazione da CAF nel grid delle comunicazioni
        /// </summary>
        private void fillTipoComunicazione() {
            PostData.MarkAsTemporaryTable(DS.tipocomunicazione, false);
            DS.tipocomunicazione.Rows.Add(new object[] {"O", "Ordinaria"});
            DS.tipocomunicazione.Rows.Add(new object[] {"I", "Integrativa"});
            DS.tipocomunicazione.Rows.Add(new object[] {"R", "Rettificativa"});
            DS.tipocomunicazione.AcceptChanges();
        }

        // Funzione che assegna il testo ai tool tip che verranno visualizzati nel form
        void ImpostaTestoToolTip() {
            string hlpMaggioreRitenuta = "Aliquota Marginale";
            SetToolTip(SubEntity_cmbAliquotaIRPEF, hlpMaggioreRitenuta);
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string hlpNoTaxArea = (esercizio < 2007) ? "Gestione No Tax Area" : "Gestione Detrazioni per Reddito";
            SetToolTip(grpNoTaxArea, hlpNoTaxArea);
            string hlpDedBaseIntero = (esercizio < 2007)
                ? "Deduzione Base applicata per intero"
                : "Applicazione delle detrazioni per reddito";
            SetToolTip(SubEntity_rbtnDedBaseIntero, hlpDedBaseIntero);
            string hlpDedBaseGiorno = (esercizio < 2007) ? "Deduzione Base applicata per i giorni lavorati" : "";
            SetToolTip(SubEntity_rbtnDedBaseGiorno, hlpDedBaseGiorno);
            string hlpNonApplicare = (esercizio < 2007)
                ? "Non applicare la no-tax area"
                : "Non applicare le detrazioni per reddito";
            SetToolTip(SubEntity_rbtnNonApplicare, hlpNonApplicare);
        }

        /// <summary>
        /// Metodo che imposta la tabella cedolino e i suoi figli come sub entità e viceversa
        /// </summary>
        /// <param name="isSubEntita">TRUE: Imposta come Sub Entità; FALSE: Non impostare come Sub Entità </param>
        private void impostaTabelleCedolinoEFigliSubEntita(bool isSubEntita) {
            foreach (string tabella in new string[] {
                "payroll", "payrolltax", "payrolltaxbracket",
                "payrolldeduction", "payrollabatement"
            }) {
                if (isSubEntita) {
                    Meta.MarkTableAsNotEntityChild(DS.Tables[tabella]);
                }
                else {
                    Meta.UnMarkTableAsNotEntityChild(DS.Tables[tabella]);
                }
            }
        }

        // Funzione che gestisce la visualizzazione dei tooltip
        void SetToolTip(Control C, string tip) {
            myTip.SetToolTip(C, tip);
        }

        public void MetaData_BeforeFill() {
            PostData.MarkAsTemporaryTable((DataTable) cmbTipoRapporto.DataSource, false);

            //Controlla che vi sia o Crea una nuova riga nelle in "imputazionecontratto" con valori di default.
            if (Meta.InsertMode) {
                CreateImputazioneContrattoRow();
            }
            if (Meta.InsertMode) {
                txtDataInizio.Enabled = true;
            }
            if (Meta.EditMode && Meta.FirstFillForThisRow) {
                int count = Meta.Conn.RUN_SELECT_COUNT("payroll",
                    QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                        QHS.IsNotNull("disbursementdate")),
                    true);
                txtDataInizio.Enabled = count == 0;
            }

            foreach (DataRow r in DS.exhibitedcuddeduction.Select()) {
                DataRow rPadre = r.GetParentRow("exhibitedcudexhibitedcuddeduction");
                if (rPadre == null) {
                    r.Delete();
                }
            }

            foreach (DataRow r in DS.exhibitedcudabatement.Select()) {
                DataRow rPadre = r.GetParentRow("exhibitedcudexhibitedcudabatement");
                if (rPadre == null) {
                    r.Delete();
                }
            }

        }

        #region Gestione Combo Tipo Rapporto

        void ClearComboTipoRapporto() {
            ((DataTable) cmbTipoRapporto.DataSource).Clear();
        }

        private void impostaComboTipoRapporto() {
            bool enableold = true;
            string filterTipoRapporto;
            object oldcode = DBNull.Value;
            if (cmbTipoRapporto.SelectedIndex > 0) oldcode = cmbTipoRapporto.SelectedValue;
            if (oldcode == DBNull.Value) enableold = false;

            //prende i tipi rapporto compatibili con il modulo PARASUBORDINATI in base alla tabella
            string filtro = QHS.AppAnd(
                QHS.Like("module", "%C%"),
                QHS.CmpEq("ayear", esercizio),
                QHS.CmpEq("ayear", esercizio),
                QHS.DoPar(QHS.AppOr(QHS.IsNull("active"), QHS.CmpEq("active", "S")))
                );
            DataTable emensTipoRapporto = Meta.Conn.RUN_SELECT("emenscontractkind", "*", null, filtro, null, null, true);

            if (emensTipoRapporto.Rows.Count == 0) {
                // Caso 1: non ci sono rapporti compatibili con il modulo PARASUBORDINATI
                // Si controlla se è stato scelto un rapporto in precedenza.
                // Se si appare il messaggio che il rapporto non è più compatibile con il modulo
                // Altrimenti viene svuotato il combo box
                if (enableold) {
                    filterTipoRapporto = QHS.AppAnd(QHS.CmpEq("idemenscontractkind", oldcode),
                        QHS.CmpEq("ayear", esercizio));
                    MessageBox.Show(this,
                        "Attenzione: il tipo rapporto selezionato non è coerente con il modulo PARASUBORDINATI");
                }
                else {
                    ClearComboTipoRapporto();
                    return;
                }
            }
            else {
                // Caso 2: ci sono rapporti compatibili con il modulo PARASUBORDINATI
                // Si costruisce il filtro su tipoRapporto tenendo conto della prestazione precedentemente scelta
                //filterTipoRapporto="(modulo LIKE "+QueryCreator.quotedstrvalue("%C%",true)+")";
                filterTipoRapporto = filtro;
                bool rapportoSceltoIsOld = (emensTipoRapporto.Select(
                    QHC.AppAnd(QHC.CmpEq("idemenscontractkind", oldcode), QHC.CmpEq("ayear", esercizio))).Length == 0);
                if (enableold && rapportoSceltoIsOld) {
                    MessageBox.Show(this,
                        "Attenzione: il tipo rapporto EMENS selezionato non è coerente con il modulo PARASUBORDINATI");
                }
                if (enableold)
                    filterTipoRapporto = QHS.AppOr(QHS.DoPar(filterTipoRapporto),
                        QHS.DoPar(QHS.AppAnd(QHS.CmpEq("idemenscontractkind", oldcode), QHS.CmpEq("ayear", esercizio))));
            }

            //Imposta combo prestazione filtrata
            Meta.myHelpForm.DisableAutoEvents();
            cmbTipoRapporto.BeginUpdate();
            QueryCreator.MyClear(((DataTable) cmbTipoRapporto.DataSource));
            GetData.Add_Blank_Row(((DataTable) cmbTipoRapporto.DataSource));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, ((DataTable) cmbTipoRapporto.DataSource), "description",
                filterTipoRapporto, null, true);
            HelpForm.SetComboBoxValue(cmbTipoRapporto, oldcode);
            cmbTipoRapporto.EndUpdate();
            Meta.myHelpForm.EnableAutoEvents();
        }

        #endregion

        #region Gestione Combo Attività Previdenziale INPS

        void ClearComboAttPrevINPS() {
            ((DataTable) cmbAttPrevidenzialeINPS.DataSource).Clear();
        }

        private void impostaComboAttPrevINPS() {
            bool enableold = true;
            string filterAttPrevINPS = "";
            object oldcode = DBNull.Value;
            if (cmbAttPrevidenzialeINPS.SelectedIndex > 0) oldcode = cmbAttPrevidenzialeINPS.SelectedValue;
            if (oldcode == DBNull.Value) enableold = false;

            //Filtro i rapporti che hanno il codice attività obbligatorio
            string filtro = QHC.AppAnd(QHC.CmpEq("flagactivityrequested", "S"), QHS.Like("module", "%C%"));
            DataRow[] emensRow = DS.emenscontractkind.Select(filtro);

            if (emensRow.Length == 0) {
                // Caso 1: I rapporti selezionati non hanno l'obbligatorietà del codice attività
                // Si controlla se è stata scelta un'attività in precedenza.
                // Se si appare il messaggio che l'attività non è più compatibile con i rapporti
                // Altrimenti viene svuotato il combo box
                if (enableold) {
                    filterAttPrevINPS = QHS.AppAnd(QHS.CmpEq("activitycode", oldcode), QHS.CmpEq("ayear", esercizio));
                    MessageBox.Show(this,
                        "Attenzione: l'attività previdenziale INPS scelta non è coerente con il rapporto scelto");
                }
                else {
                    ClearComboAttPrevINPS();
                    return;
                }
            }
            else {
                object tipoRapporto = (cmbTipoRapporto.SelectedIndex <= 0)
                    ? DBNull.Value
                    : cmbTipoRapporto.SelectedValue;
                string filtroTR = QHC.CmpEq("idemenscontractkind", tipoRapporto);
                string filtroCompleto = QHC.AppAnd(filtro, filtroTR);
                DataRow[] emensRowSelected = DS.emenscontractkind.Select(filtroCompleto);
                if (emensRowSelected.Length == 0) {
                    cmbAttPrevidenzialeINPS.Enabled = false;
                    btnAttivitaPrevINPS.Enabled = false;
                    return;
                }
                // Caso 2: I rapporti selezionati hanno l'obbligatorietà del codice attività
                // Si costruisce il filtro su tipoRapporto tenendo conto della prestazione precedentemente scelta
                filterAttPrevINPS = QHS.CmpEq("ayear", esercizio);
            }

            //Imposta combo prestazione filtrata
            Meta.myHelpForm.DisableAutoEvents();
            cmbAttPrevidenzialeINPS.BeginUpdate();
            QueryCreator.MyClear(((DataTable) cmbAttPrevidenzialeINPS.DataSource));
            GetData.Add_Blank_Row(((DataTable) cmbAttPrevidenzialeINPS.DataSource));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, ((DataTable) cmbAttPrevidenzialeINPS.DataSource), "description",
                filterAttPrevINPS, null, true);
            HelpForm.SetComboBoxValue(cmbAttPrevidenzialeINPS, oldcode);
            cmbAttPrevidenzialeINPS.EndUpdate();
            Meta.myHelpForm.EnableAutoEvents();
            // Se DS.attivitaprevidenzialeinps ha una sola riga essa è quella vuota (GetData.Add_Blank_Row)
            // e quindi può essere disabilitato
            if (((DataTable) cmbAttPrevidenzialeINPS.DataSource).Rows.Count == 1) {
                cmbAttPrevidenzialeINPS.Enabled = false;
                btnAttivitaPrevINPS.Enabled = false;
            }
        }

        #endregion

        private void impostaVarDiConfronto() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontract.Rows[0];
            lastPrestazione = Curr["idser"];
            lastTotImponibileCud = calcolaSommaImponibileCud();
            DataRow CurrImp = DS.parasubcontractyear.Rows[0];
            lastTotImponibileCud += calcolaImponibileFiscalePresuntoAnnuo();
            //CfgFn.GetNoNullDecimal( CurrImp["taxablegross"]);
        }

        /// <summary>
        /// Metodo che rende il contratto in sola lettura
        /// </summary>
        /// <param name="solaLettura">TRUE: Rendi il contratto in sola lettura; FALSE: Altrimenti</param>
        private void rendiContrattoInSolaLettura(bool solaLettura) {
            /// Questo metodo viene chiamato solo se: esisteContrattoNellAnnoSuccessivo() || controllaCedolinoDiConguaglioErogato
            /// Tuttavia, nell'AfterRowSelect viene gestista bene l'abilitazione del button, poi però la chiamata a rendiContrattoInSolaLettura() sovrascrive l'impostazione effettuata.
            /// Per cui lasciamo che questo metodo disabiliti al verificarsi delle due condizioni scritte sopra, qualora il button fosse stato abilitato.
            bool abilita = !solaLettura;
            btnGeneraCedolini.Enabled = abilita;
            if (btnCalcolaCedolino.Enabled) {
                btnCalcolaCedolino.Enabled = abilita; // && fromBtnVisualizza;
            }
            //fromBtnVisualizza = false;
            abilitaDisabilitaControlliSensibili(abilita);
        }

        /// <summary>
        /// Metodo che abilita/disaabilita i controlli che incidono sul ricalcolo del cedolino
        /// </summary>
        /// <param name="abilita"></param>
        private void abilitaDisabilitaControlliSensibili(bool abilita) {
            bool solaLettura = !abilita;
            txtDataInizio.ReadOnly = solaLettura;
            txtDataFine.ReadOnly = solaLettura;
            bool abilitaPAT = true;
            if (DS.parasubcontract.Rows.Count > 0) {
                DataRow Curr = DS.parasubcontract.Rows[0];
                object idSer = Curr["idser"];
                abilitaPAT = abilitaCmbPat(idSer);
            }
            btnPAT.Enabled = abilita && abilitaPAT;
            cmbPAT.Enabled = abilita && abilitaPAT;

            cmbTipoPrestazione.Enabled = abilita;
            txtLordoAlBeneficiario.ReadOnly = solaLettura;
            txtStimaCostoTotale.ReadOnly = solaLettura;
            txtPercipiente.ReadOnly = solaLettura;
            //SubEntity_txtGeoComune.ReadOnly = solaLettura;
        }

        /// <summary>
        /// Metodo che controlla l'esistenza del contratto nell'anno successivo
        /// </summary>
        /// <returns></returns>
        private bool esisteContrattoNellAnnoSuccessivo() {
            if (Meta.InsertMode) return false;
            object idContratto = DS.parasubcontract.Rows[0]["idcon"];
            int eserciziosucc = 1 + esercizio;
            string filtro = QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("ayear", eserciziosucc));
            object o = Meta.Conn.DO_READ_VALUE("parasubcontractyear", filtro, "COUNT(*)");
            return (o != DBNull.Value && (int) o != 0) ? true : false;
        }

        private decimal calcolaSommaImponibileCud() {
            decimal imponibile = 0;
            foreach (DataRow rCud in DS.exhibitedcud.Select(null, "idexhibitedcud")) {
                if (rCud["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    imponibile = CfgFn.GetNoNullDecimal(rCud["taxablegross"]);
                }
                else {
                    imponibile += CfgFn.GetNoNullDecimal(rCud["taxablegross"]);
                }
            }
            return imponibile;
        }

        public void MetaData_AfterFill() {
            //btnImportaOneri.Enabled = true;
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = false;
            AggiornaVoceSpesa();

            btnVerificaProblemi.Enabled = true;
            btnSituazione.Enabled = !Meta.InsertMode;
            calcolaCudPresentati();
            txtEsercizio.ReadOnly = true;
            btnCalcAcconto.Enabled = true;
            if (Meta.EditMode) {
                txtNumContratto.ReadOnly = true;
                txtDataFine.Enabled = controllaSeConguaglioDiQuestoContrattoNonErogato();
            }
            EnableDisableBtnCUDdeduzionidetrazioni();
            if (Meta.FirstFillForThisRow) {
                string filtroCCP = Meta.GetStaticFilter("contratti con problemi");
                if (filtroCCP != null) {
                    DataRow[] rContrattiConProblemi = DS.parasubcontract.Select(filtroCCP);
                }
                impostaTabelleCedolinoEFigliSubEntita(true);
                inputDatiSalvati = getInputPerCalcoloCostoTotale(false);
                impostaComboTipoRapporto();
                impostaComboAttPrevINPS();
                impostaVarDiConfronto();
                gestisciSubEntity_cmbAliquotaIRPEF(false);
                if (Meta.InsertMode || Meta.EditMode) {
                    object codicePrestazione = DS.parasubcontract.Rows[0]["idser"];
                    int idreg = CfgFn.GetNoNullInt32(DS.parasubcontract.Rows[0]["idreg"]);
                    if (codicePrestazione != DBNull.Value) {
                        abilitaCmbAltreFormeAssicurative(codicePrestazione);

                        if (Meta.EditMode) {
                            abilitaCmbTipoRapporto(codicePrestazione);
                            abilitaCmbPat(codicePrestazione);
                            abilitaChiudiContratto(codicePrestazione);
                        }

                        object idComuneAddizionale = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg,
                            primoDellAnno);
                        string denomComuneAddizionale = ricavaDenominazioneComune(idComuneAddizionale);
                        txtComuneAddComunali.Text = denomComuneAddizionale;

                        object idComuneAddizionaleRata = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg,
                            primoDellAnnoPrec);
                        string denomComuneAddizionaleRata = ricavaDenominazioneComune(idComuneAddizionaleRata);
                        txtComuneAddComRata.Text = denomComuneAddizionaleRata;

                        DataTable T = CalcoliCococo.verificaAddizionaliPrestazione(Conn, codicePrestazione, "C");
                        if ((T != null) && (T.Rows.Count > 0) && (idreg != 0)) {
                            if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
                                MessageBox.Show(this,
                                    "In riferimento all'applicazione delle addizionali comunali non esiste per il percipiente "
                                    + "\nun domicilio fiscale o un indirizzo di residenza valido al " +
                                    primoDellAnno.ToShortDateString());
                            }
                        }
                        txtComuneAddRegionali.Text = denomComuneAddizionale;
                        aggiornaComuneResidenza(idComuneAddizionale);

                        txtComuneAddRegRata.Text = denomComuneAddizionaleRata;

                        DataTable TGeo = CalcoliCococo.verificaAddizionaliPrestazione(Conn, codicePrestazione, "R");
                        if ((TGeo != null) && (TGeo.Rows.Count > 0) && (idreg != 0)) {
                            //Messaggi per avvisare l'utente
                            if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
                                MessageBox.Show(this,
                                    "In riferimento all'applicazione delle addizionali regionali non esiste per il percipiente "
                                    + "\nun domicilio fiscale o un indirizzo di residenza valido al " +
                                    primoDellAnno.ToShortDateString()
                                    + "\no alla data di fine contratto. ");
                            }
                        }
                    }
                }
                if (Meta.EditMode) {
                    bool contrattoInSolaLettura = esisteContrattoNellAnnoSuccessivo()
                                                  ||
                                                  controllaCedolinoDiConguaglioErogato(
                                                      DS.parasubcontract.Rows[0]["idcon"]);
                    rendiContrattoInSolaLettura(contrattoInSolaLettura);
                    ricalcoloEventualeDelCostoTotale();
                    riempiDatiRiepilogativi();
                }
                if (Meta.InsertMode) {
                    // Se ci sono solo 2 righe vuol dire che è stata caricata solo una riga da emenstiporapporto
                    // mentre l'altra rappresenta la riga vuota aggiunta dal CacheTable.
                    txtDataFine.Enabled = true;
                    if (DS.emenscontractkind.Rows.Count == 2) {
                        cmbTipoRapporto.SelectedIndex = 1;
                        cmbTipoRapporto.Enabled = false;
                        btnTipoRapporto.Enabled = false;
                    }
                }
            }
            if (true) {
//!Meta.FirstFillForThisRow) {
                decimal totImponibileCud = calcolaSommaImponibileCud();
                DataRow CurrImp = DS.parasubcontractyear.Rows[0];
                totImponibileCud += calcolaImponibileFiscalePresuntoAnnuo();
                if (lastTotImponibileCud != totImponibileCud) {
                    bool aliquotaImpostata = impostaAliquotaFiscaleMarginale();
                    if (aliquotaImpostata) {
                        lastTotImponibileCud = totImponibileCud;
                    }
                }
            }
            //impostaComuneRegioneCAF();

            if (Meta.FirstFillForThisRow && Meta.EditMode) {
                VisualizzaEtichetteAP();
            }

            if (Meta.FirstFillForThisRow) {
                ricalcoloEventualeDelCostoTotale();
            }
            if ((!Meta.IsEmpty) && (Meta.FirstFillForThisRow)) {
                grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') and (human = 'S'))";
                Meta.SetAutoMode(grpPercipiente);
                grpPercipiente.Enabled = Meta.InsertMode;
            }

            if (Meta.EditMode && Meta.FirstFillForThisRow) AggiornaSoloInformazioni();
            if (Meta.FirstFillForThisRow) VisualizzaBtnCambiaRuolo();
            DataRow curr = DS.parasubcontract.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive"]);
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
                abilitaDisabilitaCCdedicato(null);
            }
        }

        public void VisualizzaBtnCambiaRuolo() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontract.Rows[0];

            string filter;

            object datainizio = Curr["start"];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                return;
            }
            if ((datafine == DBNull.Value) || (((DateTime) datafine) == QueryCreator.EmptyDate())) {
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                return;
            }

            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime) datafine, true);

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio),
                QHS.NullOrGe("stop", datafine),
                QHS.IsNotNull("csa_compartment"), QHS.IsNotNull("csa_role"));

            int NposGiuridiche = Meta.Conn.RUN_SELECT_COUNT("registrylegalstatus", filter, false);
            if (NposGiuridiche > 1)
                btnCambiaRuolo.Visible = true;
            else
                btnCambiaRuolo.Visible = false;

        }

        // J.T.R. 03.06.2008 - Metodo commentato non serve più, viene impostato direttamente dal form del CAF idcity
        // e idfiscaltaxregion
        private void impostaComuneRegioneCAF() {
            //if (DS.cafdocument.Rows.Count == 0) return;
            //if (DS.parasubcontractyear.Rows.Count == 0) return;
            //DataRow rImputazioneContratto = DS.parasubcontractyear.Rows[0];
            //int idComune = 0;
            //int idRegione = 0;
            //if (rImputazioneContratto["idresidence"] != DBNull.Value) {
            //    idComune = (int)rImputazioneContratto["idresidence"];
            //    string filter = QHS.CmpEq("idcity", idComune);
            //    object o = Meta.Conn.DO_READ_VALUE("geo_cityview", filter, "idregion");
            //    if (o != null) {
            //        idRegione = (int)o;
            //    }
            //}
            //foreach (DataRow R in DS.cafdocument.Select()) {
            //    if (CfgFn.GetNoNullInt32(R["idcity"]) != idComune) R["idcity"] = idComune;
            //    if (CfgFn.GetNoNullInt32(R["idregion"]) != idRegione) R["idregion"] = idRegione;
            //}
        }

        /* private object calcolaComuneIndirizzoValido (int idReg, DateTime date) {

             // La data di riferimento deve essere 
             // 1) il 1 gennaio dell'esercizio corrente per l' applicazione delle addizionali comunali
             // 2) in caso di applicazione delle addizionali regionali, il 31 dicembre dell'esercizio contabile 
             // o la data di fine contratto se precedente

             // Verifico esistenza di un domicilio fiscale alla data di riferimento
             object idDomFiscale = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
             object idResidenza = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

             string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idDomFiscale),
                             "(" + QHS.quote(adate) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
             object idComuneAddizionale = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
             if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
             // in assenza di un domicilio fiscale verifico l'esistenza di un indirizzo di residenza ala data di riferimento
                 filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idResidenza),
                            "(" + QHS.quote(adate) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
                 idComuneAddizionale = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
             }
             if ((idComuneAddizionale != DBNull.Value) && (idComuneAddizionale != null)) {
                 return idComuneAddizionale;
             }
             else {
                 return null;
             }
         }*/

        /// <summary>
        /// Metodo che controlla che il cedolino di conguaglio per l'anno in corso non sia stato erogato
        /// </summary>
        /// <returns>TRUE: Cedolino di conguaglio non erogato FALSE: altrimenti</returns>
        private bool controllaSeConguaglioDiQuestoContrattoNonErogato() {
            DataRow Curr = DS.parasubcontract.Rows[0];
            string filtroCedolino = QHC.AppAnd(QHC.CmpEq("idcon", Curr["idcon"]),
                QHC.CmpEq("flagbalance", "S"), QHC.CmpEq("fiscalyear", esercizio), QHC.IsNotNull("disbursementdate"));
            return (DS.payroll.Select(filtroCedolino).Length == 0) ? true : false;
        }

        /// <summary>
        /// Metodo che controlla che il cedolino di conguaglio di un contratto sia stato erogato nell'anno fiscale corrente
        /// </summary>
        /// <param name="idContratto"></param>
        /// <returns></returns>
        private bool controllaCedolinoDiConguaglioErogato(object idContratto) {
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(idContratto, true);
            if (rCedolini.Length == 0) {
                return false;
            }
            return true;
        }

        private DataRow[] ottieniFamiliariContratto(object idContratto) {
            string filter = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            DataTable tFamiliari = DataAccess.RUN_SELECT(Meta.Conn, "parasubcontractfamily", "*",
                null, filter, null, null, true);

            DataRow[] rFamiliari = tFamiliari.Select();
            return rFamiliari;
        }


        public void MetaData_AfterClear() {
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = true;
            grpPercipiente.Enabled = true;
            AggiornaVoceSpesa();

            //btnImportaOneri.Enabled = false;
            impostaTabelleCedolinoEFigliSubEntita(false);
            abilitaDisabilitaCCdedicato(null);
            rendiContrattoInSolaLettura(false);
            btnSituazione.Enabled = false;
            txtEsercizio.ReadOnly = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            txtNumContratto.ReadOnly = false;
            txtDataFine.Enabled = true;
            EnableDisableBtnCUDdeduzionidetrazioni();
            cancellaCampiCalcolati();
            inputPerCalcoloCostoTotale = null;
            inputDatiSalvati = null;
            inputPerGestioneCud = null;
            lastTotImponibileCud = 0;
            lastPrestazione = DBNull.Value;
            SubEntity_cmbAliquotaIRPEF.Enabled = false;
            btnVerificaProblemi.Enabled = false;
            txtDataInizio.Enabled = true;
            btnTroncaContratto.Enabled = false;

            //Fill con filtro del solo esercizio della combo - EMENSTIPORAPPORTO
            PostData.MarkAsRealTable((DataTable) cmbTipoRapporto.DataSource);
            GetData.CacheTable(DS.emenscontractkind, filteresercizio, null, true);
            Meta.myHelpForm.PreFillControlsTable(cmbTipoRapporto, null);
            PostData.MarkAsTemporaryTable((DataTable) cmbTipoRapporto.DataSource, false);

            //Fill con filtro del solo esercizio della combo - ATTIVITAPREVIDENZIALEINPS
            PostData.MarkAsRealTable((DataTable) cmbAttPrevidenzialeINPS.DataSource);
            GetData.CacheTable(DS.inpsactivity, filteresercizio, null, true);
            Meta.myHelpForm.PreFillControlsTable(cmbAttPrevidenzialeINPS, null);
            PostData.MarkAsTemporaryTable((DataTable) cmbAttPrevidenzialeINPS.DataSource, false);
            btnTipoRapporto.Enabled = true;
            cmbTipoRapporto.Enabled = true;
            btnAltreFormeAssicurative.Enabled = true;
            cmbAltreFormeAssicurative.Enabled = true;
            if (DS.inpsactivity.Rows.Count > 0) {
                btnAttivitaPrevINPS.Enabled = true;
                cmbAttPrevidenzialeINPS.Enabled = true;
            }
            abilitaDisabilitaControlliSensibili(true);
            VisualizzaEtichetteAP();
            btnCalcAcconto.Enabled = false;
            txtComuneAddComunali.Text = null;
            txtComuneAddRegionali.Text = null;
            grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.(active='S')";
            Meta.SetAutoMode(grpPercipiente);
            btnCambiaRuolo.Visible = false;
            ClearPosGiuridica();
            SiopeObj.setCausaleEPCorrente(null);
        }


        private void cancellaCampiCalcolati() {
            gridRitenute.DataSource = null;
            txtFiscAmm.Text = null;
            txtFiscDip.Text = null;
            txtPrevAmm.Text = null;
            txtPrevDip.Text = null;
            txtAssicAmm.Text = null;
            txtAssicDip.Text = null;
            txtAssisAmm.Text = null;
            txtAssisDip.Text = null;
            txtTotaleRitAmmin.Text = null;
            txtTotaleRitDip.Text = null;
            txtCostoTotale.Text = null;
            txtLordoAlBeneficiarioRiep.Text = null;
            txtCompensoNetto.Text = null;
            txtStimaCostoTotale.Text = null;
        }

        public void CreateImputazioneContrattoRow() {
            if (Meta.IsEmpty) return;
            object idcontratto = DS.parasubcontract.Rows[0]["idcon"];
            DataRow[] r = DS.parasubcontractyear.Select(
                QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("ayear", esercizio)));
            if (r.Length == 0) {
                DataRow drContratto = DS.Tables["parasubcontract"].Rows[0];
                MetaData metaIC = MetaData.GetMetaData(this, "parasubcontractyear");
                metaIC.SetDefaults(DS.parasubcontractyear);
                MetaData.SetDefault(DS.parasubcontractyear, "notaxappliance", "I");
                MetaData.SetDefault(DS.parasubcontractyear, "applybrackets", "S");
                DataRow DR = metaIC.Get_New_Row(drContratto, DS.parasubcontractyear);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_parasubcontract_default));
			this.tabGenerale = new System.Windows.Forms.TabPage();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkExcludeFromCertificate = new System.Windows.Forms.CheckBox();
			this.groupBox24 = new System.Windows.Forms.GroupBox();
			this.btnCambiaRuolo = new System.Windows.Forms.Button();
			this.txtCompartoCSA = new System.Windows.Forms.TextBox();
			this.txtInquadrcsa = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.lblRuoloCSA = new System.Windows.Forms.Label();
			this.txtRuoloCSA = new System.Windows.Forms.TextBox();
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.txtComuneAddRegionali = new System.Windows.Forms.TextBox();
			this.btnTroncaContratto = new System.Windows.Forms.Button();
			this.txtStimaCostoTotale = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.grpDettagliPrevidenzialiAssistenziali = new System.Windows.Forms.GroupBox();
			this.cmbTipoRapporto = new System.Windows.Forms.ComboBox();
			this.DS = new parasubcontract_default.dsmeta();
			this.btnTipoRapporto = new System.Windows.Forms.Button();
			this.cmbAttPrevidenzialeINPS = new System.Windows.Forms.ComboBox();
			this.btnAttivitaPrevINPS = new System.Windows.Forms.Button();
			this.cmbAltreFormeAssicurative = new System.Windows.Forms.ComboBox();
			this.btnAltreFormeAssicurative = new System.Windows.Forms.Button();
			this.cmbPAT = new System.Windows.Forms.ComboBox();
			this.btnPAT = new System.Windows.Forms.Button();
			this.grpDettagliFiscali = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.grpPrestazione = new System.Windows.Forms.GroupBox();
			this.btnTipoPrestazione = new System.Windows.Forms.Button();
			this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
			this.grpPercipiente = new System.Windows.Forms.GroupBox();
			this.txtPercipiente = new System.Windows.Forms.TextBox();
			this.grpContratto = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.txtNumContratto = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtLordoAlBeneficiario = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDurataMesi = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.grpComune = new System.Windows.Forms.GroupBox();
			this.txtComuneAddComunali = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabImponibili = new System.Windows.Forms.TabPage();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btnSituazione = new System.Windows.Forms.Button();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtImponibilePrevidenziale = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtPrevidenzialeCUD = new System.Windows.Forms.TextBox();
			this.SubEntity_txtGiorniCUD = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SubEntity_chkApplicaBonus = new System.Windows.Forms.CheckBox();
			this.grpNoTaxArea = new System.Windows.Forms.GroupBox();
			this.SubEntity_rbtnNonApplicare = new System.Windows.Forms.RadioButton();
			this.SubEntity_rbtnDedBaseGiorno = new System.Windows.Forms.RadioButton();
			this.SubEntity_rbtnDedBaseIntero = new System.Windows.Forms.RadioButton();
			this.grpAliquoteIrpef = new System.Windows.Forms.GroupBox();
			this.SubEntity_cmbAliquotaIRPEF = new System.Windows.Forms.ComboBox();
			this.SubEntity_rbScaglioniIRPEF = new System.Windows.Forms.RadioButton();
			this.SubEntity_rbAliquotaMarginale = new System.Windows.Forms.RadioButton();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtDataFineCompetenza = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.SubEntity_txtDataInizioCompetenza = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.SubEntity_txtGiornicontratto = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.SubEntity_txtImponibilecontratto = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.tabFamiliare = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.dataGrid8 = new System.Windows.Forms.DataGrid();
			this.button13 = new System.Windows.Forms.Button();
			this.button12 = new System.Windows.Forms.Button();
			this.button11 = new System.Windows.Forms.Button();
			this.tabAltreCollINAIL = new System.Windows.Forms.TabPage();
			this.dataGrid10 = new System.Windows.Forms.DataGrid();
			this.button16 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.tabOneri = new System.Windows.Forms.TabPage();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button4 = new System.Windows.Forms.Button();
			this.tabCUD = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.btnVerificaProblemi = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.dgrid_DetCud = new System.Windows.Forms.DataGrid();
			this.btnDeleteDet = new System.Windows.Forms.Button();
			this.btnEditDet = new System.Windows.Forms.Button();
			this.btnInsertDet = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dgrid_DedCud = new System.Windows.Forms.DataGrid();
			this.btnDeleteDed = new System.Windows.Forms.Button();
			this.btnEditDed = new System.Windows.Forms.Button();
			this.btnInsertDed = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.inserisci_CUD = new System.Windows.Forms.Button();
			this.dgrid_CUD = new System.Windows.Forms.DataGrid();
			this.tabAddizionali = new System.Windows.Forms.TabPage();
			this.grpAccontoAddCom = new System.Windows.Forms.GroupBox();
			this.btnCalcAcconto = new System.Windows.Forms.Button();
			this.SubEntity_cmbMeseInizioAcconto = new System.Windows.Forms.ComboBox();
			this.SubEntity_txtNumRateAcconto = new System.Windows.Forms.TextBox();
			this.SubEntity_txtImportoAcconto = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button20 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.dataGrid11 = new System.Windows.Forms.DataGrid();
			this.grpAddizionaliPassate = new System.Windows.Forms.GroupBox();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.txtComuneAddRegRata = new System.Windows.Forms.TextBox();
			this.groupBox21 = new System.Windows.Forms.GroupBox();
			this.txtComuneAddComRata = new System.Windows.Forms.TextBox();
			this.SubEntity_cmbMeseInizio = new System.Windows.Forms.ComboBox();
			this.SubEntity_txtNumRate = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAddReg = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.SubEntity_txtAddProv = new System.Windows.Forms.TextBox();
			this.SubEntity_txtAddCom = new System.Windows.Forms.TextBox();
			this.tabCedolini = new System.Windows.Forms.TabPage();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.dgCedoliniAltriEsercizi = new System.Windows.Forms.DataGrid();
			this.btnGeneraCedolini = new System.Windows.Forms.Button();
			this.btnVisualizzaCedolino = new System.Windows.Forms.Button();
			this.btnCalcolaCedolino = new System.Windows.Forms.Button();
			this.dgCedolini = new System.Windows.Forms.DataGrid();
			this.tabErogazioni = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabDatiRiepilogativi = new System.Windows.Forms.TabPage();
			this.label68 = new System.Windows.Forms.Label();
			this.gridRitenute = new System.Windows.Forms.DataGrid();
			this.txtCompensoNetto = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.txtLordoAlBeneficiarioRiep = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.txtCostoTotale = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.txtAssicAmm = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.txtAssisAmm = new System.Windows.Forms.TextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.txtPrevAmm = new System.Windows.Forms.TextBox();
			this.label63 = new System.Windows.Forms.Label();
			this.txtFiscAmm = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.txtTotaleRitAmmin = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txtAssicDip = new System.Windows.Forms.TextBox();
			this.label58 = new System.Windows.Forms.Label();
			this.txtAssisDip = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.txtPrevDip = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.txtFiscDip = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txtTotaleRitDip = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.TabClassSuppl = new System.Windows.Forms.TabPage();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
			this.dgrClassSuppl = new System.Windows.Forms.DataGrid();
			this.tabEconoPatr = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabFinanziario = new System.Windows.Forms.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
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
			this.tabEP = new System.Windows.Forms.TabPage();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.gBoxCausaleDebitoCrg = new System.Windows.Forms.GroupBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.gBoxCausaleDebito = new System.Windows.Forms.GroupBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button21 = new System.Windows.Forms.Button();
			this.gBoxCausaleCosto = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button17 = new System.Windows.Forms.Button();
			this.tabAttributi = new System.Windows.Forms.TabPage();
			this.gboxclass05 = new System.Windows.Forms.GroupBox();
			this.txtCodice05 = new System.Windows.Forms.TextBox();
			this.btnCodice05 = new System.Windows.Forms.Button();
			this.txtDenom05 = new System.Windows.Forms.TextBox();
			this.gboxclass04 = new System.Windows.Forms.GroupBox();
			this.txtCodice04 = new System.Windows.Forms.TextBox();
			this.btnCodice04 = new System.Windows.Forms.Button();
			this.txtDenom04 = new System.Windows.Forms.TextBox();
			this.gboxclass03 = new System.Windows.Forms.GroupBox();
			this.txtCodice03 = new System.Windows.Forms.TextBox();
			this.btnCodice03 = new System.Windows.Forms.Button();
			this.txtDenom03 = new System.Windows.Forms.TextBox();
			this.gboxclass02 = new System.Windows.Forms.GroupBox();
			this.txtCodice02 = new System.Windows.Forms.TextBox();
			this.btnCodice02 = new System.Windows.Forms.Button();
			this.txtDenom02 = new System.Windows.Forms.TextBox();
			this.gboxclass01 = new System.Windows.Forms.GroupBox();
			this.txtCodice01 = new System.Windows.Forms.TextBox();
			this.btnCodice01 = new System.Windows.Forms.Button();
			this.txtDenom01 = new System.Windows.Forms.TextBox();
			this.tabAP = new System.Windows.Forms.TabPage();
			this.btnCollegaAP = new System.Windows.Forms.Button();
			this.btnGeneraAP = new System.Windows.Forms.Button();
			this.btnVisualizzaAP = new System.Windows.Forms.Button();
			this.labAPnongenerato = new System.Windows.Forms.Label();
			this.labAPgenerato = new System.Windows.Forms.Label();
			this.tabDALIA = new System.Windows.Forms.TabPage();
			this.groupBox22 = new System.Windows.Forms.GroupBox();
			this.cmbDaliaFunzionale = new System.Windows.Forms.ComboBox();
			this.gboxDipartimento = new System.Windows.Forms.GroupBox();
			this.btnDipartimento = new System.Windows.Forms.Button();
			this.txtCodiceDipartimento = new System.Windows.Forms.TextBox();
			this.txtDaliaDipartimento = new System.Windows.Forms.TextBox();
			this.grpCausaliAssunzioneDalia = new System.Windows.Forms.GroupBox();
			this.txtCausaleAssunzione = new System.Windows.Forms.TextBox();
			this.btnEsclusioneCIG = new System.Windows.Forms.Button();
			this.txtVoceSpesaDalia = new System.Windows.Forms.TextBox();
			this.btnVoceSpesaDalia = new System.Windows.Forms.Button();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.label91 = new System.Windows.Forms.Label();
			this.btnQualificaDalia = new System.Windows.Forms.Button();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.myTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabGenerale.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.groupBox24.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.grpDettagliPrevidenzialiAssistenziali.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpDettagliFiscali.SuspendLayout();
			this.grpPrestazione.SuspendLayout();
			this.grpPercipiente.SuspendLayout();
			this.grpContratto.SuspendLayout();
			this.grpComune.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabImponibili.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpNoTaxArea.SuspendLayout();
			this.grpAliquoteIrpef.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.tabFamiliare.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid8)).BeginInit();
			this.tabAltreCollINAIL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid10)).BeginInit();
			this.tabOneri.SuspendLayout();
			this.groupBox15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.groupBox16.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabCUD.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrid_DetCud)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrid_DedCud)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrid_CUD)).BeginInit();
			this.tabAddizionali.SuspendLayout();
			this.grpAccontoAddCom.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid11)).BeginInit();
			this.grpAddizionaliPassate.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox21.SuspendLayout();
			this.tabCedolini.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniAltriEsercizi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCedolini)).BeginInit();
			this.tabErogazioni.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabDatiRiepilogativi.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRitenute)).BeginInit();
			this.groupBox14.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.TabClassSuppl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).BeginInit();
			this.tabEconoPatr.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabFinanziario.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabEP.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.gBoxCausaleDebitoCrg.SuspendLayout();
			this.gBoxCausaleDebito.SuspendLayout();
			this.gBoxCausaleCosto.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAP.SuspendLayout();
			this.tabDALIA.SuspendLayout();
			this.groupBox22.SuspendLayout();
			this.gboxDipartimento.SuspendLayout();
			this.grpCausaliAssunzioneDalia.SuspendLayout();
			this.groupBox18.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.SuspendLayout();
			// 
			// tabGenerale
			// 
			this.tabGenerale.Controls.Add(this.grpCertificatiNecessari);
			this.tabGenerale.Controls.Add(this.SubEntity_chkExcludeFromCertificate);
			this.tabGenerale.Controls.Add(this.groupBox24);
			this.tabGenerale.Controls.Add(this.groupBox19);
			this.tabGenerale.Controls.Add(this.btnTroncaContratto);
			this.tabGenerale.Controls.Add(this.txtStimaCostoTotale);
			this.tabGenerale.Controls.Add(this.label54);
			this.tabGenerale.Controls.Add(this.textBox2);
			this.tabGenerale.Controls.Add(this.grpDettagliPrevidenzialiAssistenziali);
			this.tabGenerale.Controls.Add(this.grpDettagliFiscali);
			this.tabGenerale.Controls.Add(this.label8);
			this.tabGenerale.Controls.Add(this.grpPrestazione);
			this.tabGenerale.Controls.Add(this.grpPercipiente);
			this.tabGenerale.Controls.Add(this.grpContratto);
			this.tabGenerale.Controls.Add(this.txtLordoAlBeneficiario);
			this.tabGenerale.Controls.Add(this.label6);
			this.tabGenerale.Controls.Add(this.txtDataFine);
			this.tabGenerale.Controls.Add(this.label4);
			this.tabGenerale.Controls.Add(this.txtDurataMesi);
			this.tabGenerale.Controls.Add(this.label5);
			this.tabGenerale.Controls.Add(this.txtDataInizio);
			this.tabGenerale.Controls.Add(this.label3);
			this.tabGenerale.Controls.Add(this.grpComune);
			this.tabGenerale.Location = new System.Drawing.Point(4, 22);
			this.tabGenerale.Name = "tabGenerale";
			this.tabGenerale.Size = new System.Drawing.Size(862, 520);
			this.tabGenerale.TabIndex = 0;
			this.tabGenerale.Text = "Generale";
			this.tabGenerale.UseVisualStyleBackColor = true;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(717, 196);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(139, 48);
			this.grpCertificatiNecessari.TabIndex = 116;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(13, 20);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "parasubcontract.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// SubEntity_chkExcludeFromCertificate
			// 
			this.SubEntity_chkExcludeFromCertificate.Location = new System.Drawing.Point(7, 123);
			this.SubEntity_chkExcludeFromCertificate.Name = "SubEntity_chkExcludeFromCertificate";
			this.SubEntity_chkExcludeFromCertificate.Size = new System.Drawing.Size(314, 16);
			this.SubEntity_chkExcludeFromCertificate.TabIndex = 5;
			this.SubEntity_chkExcludeFromCertificate.Tag = "parasubcontractyear.flagexcludefromcertificate:S:N?parasubcontractyearview.flagex" +
    "cludefromcertificate:S:N";
			this.SubEntity_chkExcludeFromCertificate.Text = "Escludi  da Certificazione Unica dei Redditi";
			// 
			// groupBox24
			// 
			this.groupBox24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox24.Controls.Add(this.btnCambiaRuolo);
			this.groupBox24.Controls.Add(this.txtCompartoCSA);
			this.groupBox24.Controls.Add(this.txtInquadrcsa);
			this.groupBox24.Controls.Add(this.label20);
			this.groupBox24.Controls.Add(this.label22);
			this.groupBox24.Controls.Add(this.lblRuoloCSA);
			this.groupBox24.Controls.Add(this.txtRuoloCSA);
			this.groupBox24.Location = new System.Drawing.Point(728, 8);
			this.groupBox24.Name = "groupBox24";
			this.groupBox24.Size = new System.Drawing.Size(126, 138);
			this.groupBox24.TabIndex = 104;
			this.groupBox24.TabStop = false;
			this.groupBox24.Text = "Dati CSA";
			// 
			// btnCambiaRuolo
			// 
			this.btnCambiaRuolo.Location = new System.Drawing.Point(30, 111);
			this.btnCambiaRuolo.Name = "btnCambiaRuolo";
			this.btnCambiaRuolo.Size = new System.Drawing.Size(90, 22);
			this.btnCambiaRuolo.TabIndex = 109;
			this.btnCambiaRuolo.Text = "Cambia Ruolo";
			this.btnCambiaRuolo.UseVisualStyleBackColor = true;
			this.btnCambiaRuolo.Click += new System.EventHandler(this.btnCambiaRuolo_Click);
			// 
			// txtCompartoCSA
			// 
			this.txtCompartoCSA.Location = new System.Drawing.Point(68, 19);
			this.txtCompartoCSA.Name = "txtCompartoCSA";
			this.txtCompartoCSA.ReadOnly = true;
			this.txtCompartoCSA.Size = new System.Drawing.Size(52, 20);
			this.txtCompartoCSA.TabIndex = 108;
			// 
			// txtInquadrcsa
			// 
			this.txtInquadrcsa.Location = new System.Drawing.Point(47, 83);
			this.txtInquadrcsa.Name = "txtInquadrcsa";
			this.txtInquadrcsa.ReadOnly = true;
			this.txtInquadrcsa.Size = new System.Drawing.Size(73, 20);
			this.txtInquadrcsa.TabIndex = 107;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(11, 20);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(52, 13);
			this.label20.TabIndex = 106;
			this.label20.Text = "Comparto";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(6, 68);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(78, 13);
			this.label22.TabIndex = 105;
			this.label22.Text = "Inquadramento";
			// 
			// lblRuoloCSA
			// 
			this.lblRuoloCSA.AutoSize = true;
			this.lblRuoloCSA.Location = new System.Drawing.Point(8, 46);
			this.lblRuoloCSA.Name = "lblRuoloCSA";
			this.lblRuoloCSA.Size = new System.Drawing.Size(35, 13);
			this.lblRuoloCSA.TabIndex = 104;
			this.lblRuoloCSA.Text = "Ruolo";
			// 
			// txtRuoloCSA
			// 
			this.txtRuoloCSA.Location = new System.Drawing.Point(47, 44);
			this.txtRuoloCSA.Name = "txtRuoloCSA";
			this.txtRuoloCSA.ReadOnly = true;
			this.txtRuoloCSA.Size = new System.Drawing.Size(73, 20);
			this.txtRuoloCSA.TabIndex = 103;
			// 
			// groupBox19
			// 
			this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox19.Controls.Add(this.txtComuneAddRegionali);
			this.groupBox19.Location = new System.Drawing.Point(329, 98);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(393, 48);
			this.groupBox19.TabIndex = 21;
			this.groupBox19.TabStop = false;
			this.groupBox19.Tag = "";
			this.groupBox19.Text = "Comune di riferimento per le addizionali regionali";
			// 
			// txtComuneAddRegionali
			// 
			this.txtComuneAddRegionali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtComuneAddRegionali.Location = new System.Drawing.Point(9, 19);
			this.txtComuneAddRegionali.Name = "txtComuneAddRegionali";
			this.txtComuneAddRegionali.ReadOnly = true;
			this.txtComuneAddRegionali.Size = new System.Drawing.Size(378, 20);
			this.txtComuneAddRegionali.TabIndex = 8;
			this.txtComuneAddRegionali.Tag = "";
			// 
			// btnTroncaContratto
			// 
			this.btnTroncaContratto.AutoSize = true;
			this.btnTroncaContratto.Location = new System.Drawing.Point(206, 97);
			this.btnTroncaContratto.Name = "btnTroncaContratto";
			this.btnTroncaContratto.Size = new System.Drawing.Size(115, 23);
			this.btnTroncaContratto.TabIndex = 20;
			this.btnTroncaContratto.Text = "Chiudi il contratto";
			this.btnTroncaContratto.UseVisualStyleBackColor = true;
			this.btnTroncaContratto.Click += new System.EventHandler(this.btnTroncaContratto_Click);
			// 
			// txtStimaCostoTotale
			// 
			this.txtStimaCostoTotale.Location = new System.Drawing.Point(336, 209);
			this.txtStimaCostoTotale.Name = "txtStimaCostoTotale";
			this.txtStimaCostoTotale.Size = new System.Drawing.Size(104, 20);
			this.txtStimaCostoTotale.TabIndex = 8;
			this.txtStimaCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.myTip.SetToolTip(this.txtStimaCostoTotale, "La stima si basa sulle aliquote delle varie ritenute valide alla data attuale e n" +
        "on tiene conto degli arrotondamenti parziali, pertanto può non coincidere con il" +
        " costo totale reale della prestazione.");
			this.txtStimaCostoTotale.Leave += new System.EventHandler(this.txtStimaCostoTotale_LostFocus);
			// 
			// label54
			// 
			this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label54.Location = new System.Drawing.Point(256, 211);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(77, 20);
			this.label54.TabIndex = 19;
			this.label54.Text = "Stima costo totale";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(72, 403);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(782, 111);
			this.textBox2.TabIndex = 12;
			this.textBox2.Tag = "parasubcontract.duty";
			// 
			// grpDettagliPrevidenzialiAssistenziali
			// 
			this.grpDettagliPrevidenzialiAssistenziali.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.cmbTipoRapporto);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.btnTipoRapporto);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.cmbAttPrevidenzialeINPS);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.btnAttivitaPrevINPS);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.cmbAltreFormeAssicurative);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.btnAltreFormeAssicurative);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.cmbPAT);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.btnPAT);
			this.grpDettagliPrevidenzialiAssistenziali.Location = new System.Drawing.Point(8, 243);
			this.grpDettagliPrevidenzialiAssistenziali.Name = "grpDettagliPrevidenzialiAssistenziali";
			this.grpDettagliPrevidenzialiAssistenziali.Size = new System.Drawing.Size(846, 152);
			this.grpDettagliPrevidenzialiAssistenziali.TabIndex = 10;
			this.grpDettagliPrevidenzialiAssistenziali.TabStop = false;
			this.grpDettagliPrevidenzialiAssistenziali.Text = "Dettagli Previdenziali/Assistenziali";
			// 
			// cmbTipoRapporto
			// 
			this.cmbTipoRapporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoRapporto.DataSource = this.DS.emenscontractkind;
			this.cmbTipoRapporto.DisplayMember = "description";
			this.cmbTipoRapporto.Location = new System.Drawing.Point(112, 24);
			this.cmbTipoRapporto.Name = "cmbTipoRapporto";
			this.cmbTipoRapporto.Size = new System.Drawing.Size(726, 21);
			this.cmbTipoRapporto.TabIndex = 2;
			this.cmbTipoRapporto.Tag = "parasubcontractyear.idemenscontractkind?parasubcontractview.idemenscontractkind";
			this.cmbTipoRapporto.ValueMember = "idemenscontractkind";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnTipoRapporto
			// 
			this.btnTipoRapporto.Location = new System.Drawing.Point(8, 24);
			this.btnTipoRapporto.Name = "btnTipoRapporto";
			this.btnTipoRapporto.Size = new System.Drawing.Size(96, 23);
			this.btnTipoRapporto.TabIndex = 1;
			this.btnTipoRapporto.Tag = "manage.emenscontractkind.default";
			this.btnTipoRapporto.Text = "Tipo rapporto";
			// 
			// cmbAttPrevidenzialeINPS
			// 
			this.cmbAttPrevidenzialeINPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAttPrevidenzialeINPS.DataSource = this.DS.inpsactivity;
			this.cmbAttPrevidenzialeINPS.DisplayMember = "description";
			this.cmbAttPrevidenzialeINPS.ItemHeight = 13;
			this.cmbAttPrevidenzialeINPS.Location = new System.Drawing.Point(112, 56);
			this.cmbAttPrevidenzialeINPS.Name = "cmbAttPrevidenzialeINPS";
			this.cmbAttPrevidenzialeINPS.Size = new System.Drawing.Size(726, 21);
			this.cmbAttPrevidenzialeINPS.TabIndex = 4;
			this.cmbAttPrevidenzialeINPS.Tag = "parasubcontractyear.activitycode?parasubcontractview.activitycode";
			this.cmbAttPrevidenzialeINPS.ValueMember = "activitycode";
			// 
			// btnAttivitaPrevINPS
			// 
			this.btnAttivitaPrevINPS.Location = new System.Drawing.Point(8, 56);
			this.btnAttivitaPrevINPS.Name = "btnAttivitaPrevINPS";
			this.btnAttivitaPrevINPS.Size = new System.Drawing.Size(96, 23);
			this.btnAttivitaPrevINPS.TabIndex = 3;
			this.btnAttivitaPrevINPS.Tag = "manage.inpsactivity.default";
			this.btnAttivitaPrevINPS.Text = "Att. Prev. INPS";
			// 
			// cmbAltreFormeAssicurative
			// 
			this.cmbAltreFormeAssicurative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAltreFormeAssicurative.DataSource = this.DS.otherinsurance;
			this.cmbAltreFormeAssicurative.DisplayMember = "description";
			this.cmbAltreFormeAssicurative.ItemHeight = 13;
			this.cmbAltreFormeAssicurative.Location = new System.Drawing.Point(112, 88);
			this.cmbAltreFormeAssicurative.Name = "cmbAltreFormeAssicurative";
			this.cmbAltreFormeAssicurative.Size = new System.Drawing.Size(726, 21);
			this.cmbAltreFormeAssicurative.TabIndex = 6;
			this.cmbAltreFormeAssicurative.Tag = "parasubcontractyear.idotherinsurance?parasubcontractview.idotherinsurance";
			this.cmbAltreFormeAssicurative.ValueMember = "idotherinsurance";
			// 
			// btnAltreFormeAssicurative
			// 
			this.btnAltreFormeAssicurative.Location = new System.Drawing.Point(8, 88);
			this.btnAltreFormeAssicurative.Name = "btnAltreFormeAssicurative";
			this.btnAltreFormeAssicurative.Size = new System.Drawing.Size(96, 23);
			this.btnAltreFormeAssicurative.TabIndex = 5;
			this.btnAltreFormeAssicurative.Tag = "manage.otherinsurance.default";
			this.btnAltreFormeAssicurative.Text = "Altra Forma Ass.";
			// 
			// cmbPAT
			// 
			this.cmbPAT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPAT.DataSource = this.DS.pat;
			this.cmbPAT.DisplayMember = "description";
			this.cmbPAT.ItemHeight = 13;
			this.cmbPAT.Location = new System.Drawing.Point(112, 120);
			this.cmbPAT.Name = "cmbPAT";
			this.cmbPAT.Size = new System.Drawing.Size(726, 21);
			this.cmbPAT.TabIndex = 8;
			this.cmbPAT.Tag = "parasubcontract.idpat?parasubcontractview.idpat";
			this.cmbPAT.ValueMember = "idpat";
			// 
			// btnPAT
			// 
			this.btnPAT.Location = new System.Drawing.Point(8, 120);
			this.btnPAT.Name = "btnPAT";
			this.btnPAT.Size = new System.Drawing.Size(96, 23);
			this.btnPAT.TabIndex = 7;
			this.btnPAT.Tag = "manage.pat.default";
			this.btnPAT.Text = "Pos. Assic.Terr.";
			// 
			// grpDettagliFiscali
			// 
			this.grpDettagliFiscali.Controls.Add(this.checkBox1);
			this.grpDettagliFiscali.Controls.Add(this.checkBox3);
			this.grpDettagliFiscali.Location = new System.Drawing.Point(446, 196);
			this.grpDettagliFiscali.Name = "grpDettagliFiscali";
			this.grpDettagliFiscali.Size = new System.Drawing.Size(265, 48);
			this.grpDettagliFiscali.TabIndex = 9;
			this.grpDettagliFiscali.TabStop = false;
			this.grpDettagliFiscali.Text = "Dettagli Fiscali";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(185, 17);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(65, 16);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Tag = "parasubcontract.employed:S:N";
			this.checkBox1.Text = "In Forza";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(6, 19);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(174, 16);
			this.checkBox3.TabIndex = 4;
			this.checkBox3.Tag = "parasubcontract.payrollccinfo:S:N";
			this.checkBox3.Text = "Informazioni CC su Cedolino";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 402);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 23);
			this.label8.TabIndex = 7;
			this.label8.Text = "Mansione";
			// 
			// grpPrestazione
			// 
			this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
			this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
			this.grpPrestazione.Location = new System.Drawing.Point(8, 148);
			this.grpPrestazione.Name = "grpPrestazione";
			this.grpPrestazione.Size = new System.Drawing.Size(846, 48);
			this.grpPrestazione.TabIndex = 6;
			this.grpPrestazione.TabStop = false;
			this.grpPrestazione.Text = "Prestazione";
			// 
			// btnTipoPrestazione
			// 
			this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
			this.btnTipoPrestazione.Name = "btnTipoPrestazione";
			this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 23);
			this.btnTipoPrestazione.TabIndex = 6;
			this.btnTipoPrestazione.Tag = "choose.service.default";
			this.btnTipoPrestazione.Text = "Tipo";
			// 
			// cmbTipoPrestazione
			// 
			this.cmbTipoPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoPrestazione.DataSource = this.DS.service;
			this.cmbTipoPrestazione.DisplayMember = "description";
			this.cmbTipoPrestazione.ItemHeight = 13;
			this.cmbTipoPrestazione.Location = new System.Drawing.Point(96, 16);
			this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
			this.cmbTipoPrestazione.Size = new System.Drawing.Size(742, 21);
			this.cmbTipoPrestazione.TabIndex = 7;
			this.cmbTipoPrestazione.Tag = "parasubcontract.idser";
			this.cmbTipoPrestazione.ValueMember = "idser";
			// 
			// grpPercipiente
			// 
			this.grpPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPercipiente.Controls.Add(this.txtPercipiente);
			this.grpPercipiente.Location = new System.Drawing.Point(330, 8);
			this.grpPercipiente.Name = "grpPercipiente";
			this.grpPercipiente.Size = new System.Drawing.Size(392, 40);
			this.grpPercipiente.TabIndex = 4;
			this.grpPercipiente.TabStop = false;
			this.grpPercipiente.Tag = "AutoChoose.txtPercipiente.lista.((active=\'S\'))";
			this.grpPercipiente.Text = "Percipiente";
			// 
			// txtPercipiente
			// 
			this.txtPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercipiente.Location = new System.Drawing.Point(8, 16);
			this.txtPercipiente.Name = "txtPercipiente";
			this.txtPercipiente.Size = new System.Drawing.Size(376, 20);
			this.txtPercipiente.TabIndex = 0;
			this.txtPercipiente.Tag = "registry.title?parasubcontractview.registry";
			// 
			// grpContratto
			// 
			this.grpContratto.Controls.Add(this.label2);
			this.grpContratto.Controls.Add(this.txtEsercizio);
			this.grpContratto.Controls.Add(this.txtNumContratto);
			this.grpContratto.Controls.Add(this.label1);
			this.grpContratto.Controls.Add(this.textBox1);
			this.grpContratto.Controls.Add(this.label17);
			this.grpContratto.Location = new System.Drawing.Point(8, 8);
			this.grpContratto.Name = "grpContratto";
			this.grpContratto.Size = new System.Drawing.Size(146, 112);
			this.grpContratto.TabIndex = 1;
			this.grpContratto.TabStop = false;
			this.grpContratto.Text = "Contratto";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(62, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.Tag = "parasubcontract.ycon.year";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(62, 48);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(72, 20);
			this.txtNumContratto.TabIndex = 3;
			this.txtNumContratto.Tag = "parasubcontract.ncon";
			this.txtNumContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(62, 80);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Tag = "parasubcontract.matricula";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(8, 80);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(56, 20);
			this.label17.TabIndex = 9;
			this.label17.Text = "Matricola";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLordoAlBeneficiario
			// 
			this.txtLordoAlBeneficiario.Location = new System.Drawing.Point(146, 209);
			this.txtLordoAlBeneficiario.Name = "txtLordoAlBeneficiario";
			this.txtLordoAlBeneficiario.Size = new System.Drawing.Size(104, 20);
			this.txtLordoAlBeneficiario.TabIndex = 7;
			this.txtLordoAlBeneficiario.Tag = "parasubcontract.grossamount";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 205);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 28);
			this.label6.TabIndex = 6;
			this.label6.Text = "Lordo al beneficiario";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(233, 41);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(88, 20);
			this.txtDataFine.TabIndex = 3;
			this.txtDataFine.Tag = "parasubcontract.stop";
			this.txtDataFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataFine.Leave += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(169, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 23);
			this.label4.TabIndex = 1;
			this.label4.Text = "Data Fine";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDurataMesi
			// 
			this.txtDurataMesi.Location = new System.Drawing.Point(233, 67);
			this.txtDurataMesi.Name = "txtDurataMesi";
			this.txtDurataMesi.ReadOnly = true;
			this.txtDurataMesi.Size = new System.Drawing.Size(88, 20);
			this.txtDurataMesi.TabIndex = 5;
			this.txtDurataMesi.TabStop = false;
			this.txtDurataMesi.Tag = "parasubcontract.monthlen";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(153, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "Durata (Mesi)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(233, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(88, 20);
			this.txtDataInizio.TabIndex = 2;
			this.txtDataInizio.Tag = "parasubcontract.start";
			this.txtDataInizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataInizio.Leave += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(161, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Data Inizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpComune
			// 
			this.grpComune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpComune.Controls.Add(this.txtComuneAddComunali);
			this.grpComune.Location = new System.Drawing.Point(330, 49);
			this.grpComune.Name = "grpComune";
			this.grpComune.Size = new System.Drawing.Size(392, 48);
			this.grpComune.TabIndex = 5;
			this.grpComune.TabStop = false;
			this.grpComune.Tag = "";
			this.grpComune.Text = "Comune di riferimento per le addizionali comunali";
			// 
			// txtComuneAddComunali
			// 
			this.txtComuneAddComunali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtComuneAddComunali.Location = new System.Drawing.Point(8, 19);
			this.txtComuneAddComunali.Name = "txtComuneAddComunali";
			this.txtComuneAddComunali.ReadOnly = true;
			this.txtComuneAddComunali.Size = new System.Drawing.Size(378, 20);
			this.txtComuneAddComunali.TabIndex = 8;
			this.txtComuneAddComunali.Tag = "";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabGenerale);
			this.tabControl1.Controls.Add(this.tabImponibili);
			this.tabControl1.Controls.Add(this.tabFamiliare);
			this.tabControl1.Controls.Add(this.tabAltreCollINAIL);
			this.tabControl1.Controls.Add(this.tabOneri);
			this.tabControl1.Controls.Add(this.tabCUD);
			this.tabControl1.Controls.Add(this.tabAddizionali);
			this.tabControl1.Controls.Add(this.tabCedolini);
			this.tabControl1.Controls.Add(this.tabErogazioni);
			this.tabControl1.Controls.Add(this.tabDatiRiepilogativi);
			this.tabControl1.Controls.Add(this.TabClassSuppl);
			this.tabControl1.Controls.Add(this.tabEconoPatr);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAP);
			this.tabControl1.Controls.Add(this.tabDALIA);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.ItemSize = new System.Drawing.Size(55, 18);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(870, 546);
			this.tabControl1.TabIndex = 14;
			// 
			// tabImponibili
			// 
			this.tabImponibili.Controls.Add(this.groupBox17);
			this.tabImponibili.Controls.Add(this.groupBox12);
			this.tabImponibili.Controls.Add(this.groupBox9);
			this.tabImponibili.Controls.Add(this.groupBox7);
			this.tabImponibili.Location = new System.Drawing.Point(4, 22);
			this.tabImponibili.Name = "tabImponibili";
			this.tabImponibili.Size = new System.Drawing.Size(862, 520);
			this.tabImponibili.TabIndex = 9;
			this.tabImponibili.Text = "Imponibili";
			this.tabImponibili.UseVisualStyleBackColor = true;
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.textBox3);
			this.groupBox17.Controls.Add(this.btnSituazione);
			this.groupBox17.Location = new System.Drawing.Point(264, 200);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(312, 72);
			this.groupBox17.TabIndex = 106;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Situazione del contratto";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(88, 16);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(216, 48);
			this.textBox3.TabIndex = 102;
			this.textBox3.TabStop = false;
			this.textBox3.Text = "Cliccando sul bottone Situazione si conosceranno tutte le informazioni inerenti i" +
    "l contratto e i cedolini associati ad esso";
			// 
			// btnSituazione
			// 
			this.btnSituazione.Location = new System.Drawing.Point(8, 16);
			this.btnSituazione.Name = "btnSituazione";
			this.btnSituazione.Size = new System.Drawing.Size(75, 23);
			this.btnSituazione.TabIndex = 101;
			this.btnSituazione.Text = "Situazione";
			this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.Add(this.groupBox10);
			this.groupBox12.Location = new System.Drawing.Point(264, 120);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(312, 72);
			this.groupBox12.TabIndex = 105;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Totali Generali";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.SubEntity_txtImponibilePrevidenziale);
			this.groupBox10.Controls.Add(this.label35);
			this.groupBox10.Enabled = false;
			this.groupBox10.Location = new System.Drawing.Point(8, 24);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(296, 40);
			this.groupBox10.TabIndex = 97;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Totali Presunti Annui";
			// 
			// SubEntity_txtImponibilePrevidenziale
			// 
			this.SubEntity_txtImponibilePrevidenziale.Location = new System.Drawing.Point(192, 16);
			this.SubEntity_txtImponibilePrevidenziale.Name = "SubEntity_txtImponibilePrevidenziale";
			this.SubEntity_txtImponibilePrevidenziale.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtImponibilePrevidenziale.TabIndex = 90;
			this.SubEntity_txtImponibilePrevidenziale.Tag = "parasubcontractyear.taxablepension?parasubcontractview.taxablepension";
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(8, 16);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(128, 16);
			this.label35.TabIndex = 89;
			this.label35.Text = "Imponibile previdenziale";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.groupBox8);
			this.groupBox9.Controls.Add(this.textBox4);
			this.groupBox9.Location = new System.Drawing.Point(264, 8);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(480, 104);
			this.groupBox9.TabIndex = 104;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Informazioni inerenti altri contratti";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.SubEntity_txtPrevidenzialeCUD);
			this.groupBox8.Controls.Add(this.SubEntity_txtGiorniCUD);
			this.groupBox8.Controls.Add(this.label33);
			this.groupBox8.Controls.Add(this.label7);
			this.groupBox8.Enabled = false;
			this.groupBox8.Location = new System.Drawing.Point(8, 24);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(240, 72);
			this.groupBox8.TabIndex = 88;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Totali dei CUD presentati";
			// 
			// SubEntity_txtPrevidenzialeCUD
			// 
			this.SubEntity_txtPrevidenzialeCUD.Location = new System.Drawing.Point(128, 16);
			this.SubEntity_txtPrevidenzialeCUD.Name = "SubEntity_txtPrevidenzialeCUD";
			this.SubEntity_txtPrevidenzialeCUD.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtPrevidenzialeCUD.TabIndex = 86;
			this.SubEntity_txtPrevidenzialeCUD.Tag = "parasubcontractyear.taxablecud?parasubcontractview.taxablecud";
			// 
			// SubEntity_txtGiorniCUD
			// 
			this.SubEntity_txtGiorniCUD.Location = new System.Drawing.Point(128, 40);
			this.SubEntity_txtGiorniCUD.Name = "SubEntity_txtGiorniCUD";
			this.SubEntity_txtGiorniCUD.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtGiorniCUD.TabIndex = 90;
			this.SubEntity_txtGiorniCUD.Tag = "parasubcontractyear.cuddays?parasubcontractview.cuddays";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(16, 40);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(104, 23);
			this.label33.TabIndex = 89;
			this.label33.Text = "Giorni lavorati";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 23);
			this.label7.TabIndex = 85;
			this.label7.Text = "Imponibile previdenziale";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(256, 24);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(216, 72);
			this.textBox4.TabIndex = 107;
			this.textBox4.TabStop = false;
			this.textBox4.Text = "Totale dei CUD associati al contratto";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.groupBox2);
			this.groupBox7.Controls.Add(this.groupBox11);
			this.groupBox7.Location = new System.Drawing.Point(8, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(248, 450);
			this.groupBox7.TabIndex = 103;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Informazioni inerenti questo contratto";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SubEntity_chkApplicaBonus);
			this.groupBox2.Controls.Add(this.grpNoTaxArea);
			this.groupBox2.Controls.Add(this.grpAliquoteIrpef);
			this.groupBox2.Location = new System.Drawing.Point(8, 24);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(232, 266);
			this.groupBox2.TabIndex = 102;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Gestione Ritenute Fiscali";
			// 
			// SubEntity_chkApplicaBonus
			// 
			this.SubEntity_chkApplicaBonus.Location = new System.Drawing.Point(18, 124);
			this.SubEntity_chkApplicaBonus.Name = "SubEntity_chkApplicaBonus";
			this.SubEntity_chkApplicaBonus.Size = new System.Drawing.Size(197, 18);
			this.SubEntity_chkApplicaBonus.TabIndex = 110;
			this.SubEntity_chkApplicaBonus.Tag = "parasubcontractyear.flagbonusappliance:S:N?parasubcontractyearview.flagbonusappli" +
    "ance:S:N";
			this.SubEntity_chkApplicaBonus.Text = "Applica Bonus Fiscale";
			// 
			// grpNoTaxArea
			// 
			this.grpNoTaxArea.Controls.Add(this.SubEntity_rbtnNonApplicare);
			this.grpNoTaxArea.Controls.Add(this.SubEntity_rbtnDedBaseGiorno);
			this.grpNoTaxArea.Controls.Add(this.SubEntity_rbtnDedBaseIntero);
			this.grpNoTaxArea.Location = new System.Drawing.Point(8, 24);
			this.grpNoTaxArea.Name = "grpNoTaxArea";
			this.grpNoTaxArea.Size = new System.Drawing.Size(216, 90);
			this.grpNoTaxArea.TabIndex = 84;
			this.grpNoTaxArea.TabStop = false;
			this.grpNoTaxArea.Text = "No Tax Area per questo contratto";
			// 
			// SubEntity_rbtnNonApplicare
			// 
			this.SubEntity_rbtnNonApplicare.Location = new System.Drawing.Point(8, 64);
			this.SubEntity_rbtnNonApplicare.Name = "SubEntity_rbtnNonApplicare";
			this.SubEntity_rbtnNonApplicare.Size = new System.Drawing.Size(200, 16);
			this.SubEntity_rbtnNonApplicare.TabIndex = 2;
			this.SubEntity_rbtnNonApplicare.Tag = "parasubcontractyear.notaxappliance:N?parasubcontractview.notaxappliance";
			this.SubEntity_rbtnNonApplicare.Text = "Non applicare la No Tax Area";
			// 
			// SubEntity_rbtnDedBaseGiorno
			// 
			this.SubEntity_rbtnDedBaseGiorno.Location = new System.Drawing.Point(8, 40);
			this.SubEntity_rbtnDedBaseGiorno.Name = "SubEntity_rbtnDedBaseGiorno";
			this.SubEntity_rbtnDedBaseGiorno.Size = new System.Drawing.Size(202, 16);
			this.SubEntity_rbtnDedBaseGiorno.TabIndex = 1;
			this.SubEntity_rbtnDedBaseGiorno.Tag = "parasubcontractyear.notaxappliance:G?parasubcontractview.notaxappliance";
			this.SubEntity_rbtnDedBaseGiorno.Text = "Deduzione Base Giorni Fiscali";
			// 
			// SubEntity_rbtnDedBaseIntero
			// 
			this.SubEntity_rbtnDedBaseIntero.Checked = true;
			this.SubEntity_rbtnDedBaseIntero.Location = new System.Drawing.Point(8, 16);
			this.SubEntity_rbtnDedBaseIntero.Name = "SubEntity_rbtnDedBaseIntero";
			this.SubEntity_rbtnDedBaseIntero.Size = new System.Drawing.Size(202, 16);
			this.SubEntity_rbtnDedBaseIntero.TabIndex = 0;
			this.SubEntity_rbtnDedBaseIntero.TabStop = true;
			this.SubEntity_rbtnDedBaseIntero.Tag = "parasubcontractyear.notaxappliance:I?parasubcontractview.notaxappliance";
			this.SubEntity_rbtnDedBaseIntero.Text = "Deduzione Base per Intero";
			// 
			// grpAliquoteIrpef
			// 
			this.grpAliquoteIrpef.Controls.Add(this.SubEntity_cmbAliquotaIRPEF);
			this.grpAliquoteIrpef.Controls.Add(this.SubEntity_rbScaglioniIRPEF);
			this.grpAliquoteIrpef.Controls.Add(this.SubEntity_rbAliquotaMarginale);
			this.grpAliquoteIrpef.Location = new System.Drawing.Point(8, 164);
			this.grpAliquoteIrpef.Name = "grpAliquoteIrpef";
			this.grpAliquoteIrpef.Size = new System.Drawing.Size(216, 96);
			this.grpAliquoteIrpef.TabIndex = 7;
			this.grpAliquoteIrpef.TabStop = false;
			this.grpAliquoteIrpef.Text = "Aliquote IRPEF per questo contratto";
			// 
			// SubEntity_cmbAliquotaIRPEF
			// 
			this.SubEntity_cmbAliquotaIRPEF.DataSource = this.DS.taxratebracket;
			this.SubEntity_cmbAliquotaIRPEF.DisplayMember = "employrate";
			this.SubEntity_cmbAliquotaIRPEF.Enabled = false;
			this.SubEntity_cmbAliquotaIRPEF.Location = new System.Drawing.Point(24, 64);
			this.SubEntity_cmbAliquotaIRPEF.Name = "SubEntity_cmbAliquotaIRPEF";
			this.SubEntity_cmbAliquotaIRPEF.Size = new System.Drawing.Size(120, 21);
			this.SubEntity_cmbAliquotaIRPEF.TabIndex = 6;
			this.SubEntity_cmbAliquotaIRPEF.Tag = "parasubcontractyear.highertax.fixed.4..%.100?parasubcontractview.highertax";
			this.SubEntity_cmbAliquotaIRPEF.ValueMember = "employrate";
			// 
			// SubEntity_rbScaglioniIRPEF
			// 
			this.SubEntity_rbScaglioniIRPEF.Checked = true;
			this.SubEntity_rbScaglioniIRPEF.Location = new System.Drawing.Point(8, 16);
			this.SubEntity_rbScaglioniIRPEF.Name = "SubEntity_rbScaglioniIRPEF";
			this.SubEntity_rbScaglioniIRPEF.Size = new System.Drawing.Size(128, 24);
			this.SubEntity_rbScaglioniIRPEF.TabIndex = 4;
			this.SubEntity_rbScaglioniIRPEF.TabStop = true;
			this.SubEntity_rbScaglioniIRPEF.Tag = "parasubcontractyear.applybrackets:S?parasubcontractview.applybrackets:S";
			this.SubEntity_rbScaglioniIRPEF.Text = "Applica gli scaglioni";
			this.SubEntity_rbScaglioniIRPEF.CheckedChanged += new System.EventHandler(this.SubEntity_rbScaglioniIRPEF_CheckedChanged);
			// 
			// SubEntity_rbAliquotaMarginale
			// 
			this.SubEntity_rbAliquotaMarginale.Location = new System.Drawing.Point(8, 40);
			this.SubEntity_rbAliquotaMarginale.Name = "SubEntity_rbAliquotaMarginale";
			this.SubEntity_rbAliquotaMarginale.Size = new System.Drawing.Size(160, 24);
			this.SubEntity_rbAliquotaMarginale.TabIndex = 5;
			this.SubEntity_rbAliquotaMarginale.Tag = "parasubcontractyear.applybrackets:N?parasubcontractview.applybrackets:N";
			this.SubEntity_rbAliquotaMarginale.Text = "Applica l\'aliquota marginale";
			this.SubEntity_rbAliquotaMarginale.CheckedChanged += new System.EventHandler(this.rbAliquotaMarginale_CheckedChanged);
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.SubEntity_txtDataFineCompetenza);
			this.groupBox11.Controls.Add(this.label44);
			this.groupBox11.Controls.Add(this.SubEntity_txtDataInizioCompetenza);
			this.groupBox11.Controls.Add(this.label43);
			this.groupBox11.Controls.Add(this.SubEntity_txtGiornicontratto);
			this.groupBox11.Controls.Add(this.label40);
			this.groupBox11.Controls.Add(this.SubEntity_txtImponibilecontratto);
			this.groupBox11.Controls.Add(this.label39);
			this.groupBox11.Enabled = false;
			this.groupBox11.Location = new System.Drawing.Point(6, 306);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(232, 144);
			this.groupBox11.TabIndex = 98;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Totali del contratto";
			// 
			// SubEntity_txtDataFineCompetenza
			// 
			this.SubEntity_txtDataFineCompetenza.Location = new System.Drawing.Point(127, 78);
			this.SubEntity_txtDataFineCompetenza.Name = "SubEntity_txtDataFineCompetenza";
			this.SubEntity_txtDataFineCompetenza.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtDataFineCompetenza.TabIndex = 7;
			this.SubEntity_txtDataFineCompetenza.Tag = "parasubcontractyear.stopcompetency?parasubcontractview.stopcompetency";
			this.SubEntity_txtDataFineCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(23, 78);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(100, 23);
			this.label44.TabIndex = 6;
			this.label44.Text = "Data fine";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtDataInizioCompetenza
			// 
			this.SubEntity_txtDataInizioCompetenza.Location = new System.Drawing.Point(127, 46);
			this.SubEntity_txtDataInizioCompetenza.Name = "SubEntity_txtDataInizioCompetenza";
			this.SubEntity_txtDataInizioCompetenza.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtDataInizioCompetenza.TabIndex = 5;
			this.SubEntity_txtDataInizioCompetenza.Tag = "parasubcontractyear.startcompetency?parasubcontractview.startcompetency";
			this.SubEntity_txtDataInizioCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(23, 46);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(100, 23);
			this.label43.TabIndex = 4;
			this.label43.Text = "Data inizio";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtGiornicontratto
			// 
			this.SubEntity_txtGiornicontratto.Location = new System.Drawing.Point(127, 110);
			this.SubEntity_txtGiornicontratto.Name = "SubEntity_txtGiornicontratto";
			this.SubEntity_txtGiornicontratto.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtGiornicontratto.TabIndex = 3;
			this.SubEntity_txtGiornicontratto.Tag = "parasubcontractyear.ndays?parasubcontractview.ndays";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(23, 110);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(100, 23);
			this.label40.TabIndex = 2;
			this.label40.Text = "Durata (giorni)";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtImponibilecontratto
			// 
			this.SubEntity_txtImponibilecontratto.Location = new System.Drawing.Point(128, 16);
			this.SubEntity_txtImponibilecontratto.Name = "SubEntity_txtImponibilecontratto";
			this.SubEntity_txtImponibilecontratto.Size = new System.Drawing.Size(96, 20);
			this.SubEntity_txtImponibilecontratto.TabIndex = 1;
			this.SubEntity_txtImponibilecontratto.Tag = "parasubcontractyear.taxablecontract?parasubcontractview.taxablecontract";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(1, 16);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(126, 23);
			this.label39.TabIndex = 0;
			this.label39.Text = "Imponibile previdenziale";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabFamiliare
			// 
			this.tabFamiliare.Controls.Add(this.label18);
			this.tabFamiliare.Controls.Add(this.dataGrid8);
			this.tabFamiliare.Controls.Add(this.button13);
			this.tabFamiliare.Controls.Add(this.button12);
			this.tabFamiliare.Controls.Add(this.button11);
			this.tabFamiliare.Location = new System.Drawing.Point(4, 22);
			this.tabFamiliare.Name = "tabFamiliare";
			this.tabFamiliare.Size = new System.Drawing.Size(862, 520);
			this.tabFamiliare.TabIndex = 7;
			this.tabFamiliare.Text = "Familiari";
			this.tabFamiliare.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label18.Location = new System.Drawing.Point(13, 45);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(731, 26);
			this.label18.TabIndex = 4;
			this.label18.Text = "N.B. Nel caso si vogliano applicare le detrazioni per carichi di famiglia, si dev" +
    "e procede all\'inserimento di tutti i componenti del nucleo familiare (sia quelli" +
    " a carico sia quelli non a carico)";
			// 
			// dataGrid8
			// 
			this.dataGrid8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid8.CaptionVisible = false;
			this.dataGrid8.DataMember = "";
			this.dataGrid8.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid8.Location = new System.Drawing.Point(8, 74);
			this.dataGrid8.Name = "dataGrid8";
			this.dataGrid8.Size = new System.Drawing.Size(846, 440);
			this.dataGrid8.TabIndex = 3;
			this.dataGrid8.Tag = "parasubcontractfamily.contrattodetail.contrattodetail";
			// 
			// button13
			// 
			this.button13.Location = new System.Drawing.Point(208, 16);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(75, 23);
			this.button13.TabIndex = 2;
			this.button13.Tag = "delete";
			this.button13.Text = "Elimina";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(112, 16);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(75, 23);
			this.button12.TabIndex = 1;
			this.button12.Tag = "edit.contrattodetail";
			this.button12.Text = "Modifica";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(16, 16);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(75, 23);
			this.button11.TabIndex = 0;
			this.button11.Tag = "insert.contrattodetail";
			this.button11.Text = "Inserisci";
			// 
			// tabAltreCollINAIL
			// 
			this.tabAltreCollINAIL.Controls.Add(this.dataGrid10);
			this.tabAltreCollINAIL.Controls.Add(this.button16);
			this.tabAltreCollINAIL.Controls.Add(this.button15);
			this.tabAltreCollINAIL.Controls.Add(this.button14);
			this.tabAltreCollINAIL.Location = new System.Drawing.Point(4, 22);
			this.tabAltreCollINAIL.Name = "tabAltreCollINAIL";
			this.tabAltreCollINAIL.Size = new System.Drawing.Size(862, 520);
			this.tabAltreCollINAIL.TabIndex = 11;
			this.tabAltreCollINAIL.Text = "Altre Coll. INAIL";
			this.tabAltreCollINAIL.UseVisualStyleBackColor = true;
			// 
			// dataGrid10
			// 
			this.dataGrid10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid10.CaptionVisible = false;
			this.dataGrid10.DataMember = "";
			this.dataGrid10.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid10.Location = new System.Drawing.Point(8, 48);
			this.dataGrid10.Name = "dataGrid10";
			this.dataGrid10.Size = new System.Drawing.Size(846, 466);
			this.dataGrid10.TabIndex = 3;
			this.dataGrid10.Tag = "otherinail.default.default";
			// 
			// button16
			// 
			this.button16.Location = new System.Drawing.Point(208, 16);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(75, 23);
			this.button16.TabIndex = 2;
			this.button16.Tag = "delete";
			this.button16.Text = "Elimina";
			// 
			// button15
			// 
			this.button15.Location = new System.Drawing.Point(112, 16);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(75, 23);
			this.button15.TabIndex = 1;
			this.button15.Tag = "edit.default";
			this.button15.Text = "Modifica";
			// 
			// button14
			// 
			this.button14.Location = new System.Drawing.Point(16, 16);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(75, 23);
			this.button14.TabIndex = 0;
			this.button14.Tag = "insert.default";
			this.button14.Text = "Inserisci";
			// 
			// tabOneri
			// 
			this.tabOneri.Controls.Add(this.textBox6);
			this.tabOneri.Controls.Add(this.label21);
			this.tabOneri.Controls.Add(this.groupBox15);
			this.tabOneri.Controls.Add(this.groupBox16);
			this.tabOneri.Location = new System.Drawing.Point(4, 22);
			this.tabOneri.Name = "tabOneri";
			this.tabOneri.Size = new System.Drawing.Size(862, 520);
			this.tabOneri.TabIndex = 4;
			this.tabOneri.Text = "Oneri";
			this.tabOneri.UseVisualStyleBackColor = true;
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(8, 5);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(846, 37);
			this.textBox6.TabIndex = 7;
			this.textBox6.Text = resources.GetString("textBox6.Text");
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(13, 12);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(0, 13);
			this.label21.TabIndex = 6;
			// 
			// groupBox15
			// 
			this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox15.Controls.Add(this.dataGrid4);
			this.groupBox15.Controls.Add(this.button7);
			this.groupBox15.Controls.Add(this.button6);
			this.groupBox15.Controls.Add(this.button5);
			this.groupBox15.Location = new System.Drawing.Point(8, 323);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(854, 191);
			this.groupBox15.TabIndex = 5;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Oneri detraibili";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.CaptionVisible = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(8, 40);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(838, 143);
			this.dataGrid4.TabIndex = 3;
			this.dataGrid4.Tag = "abatableexpense.contrattodetail.contrattodetail";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(208, 16);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 2;
			this.button7.Tag = "delete";
			this.button7.Text = "Elimina";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(112, 16);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 1;
			this.button6.Tag = "edit.contrattodetail";
			this.button6.Text = "Modifica";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(16, 16);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 0;
			this.button5.Tag = "insert.contrattodetail";
			this.button5.Text = "Inserisci";
			// 
			// groupBox16
			// 
			this.groupBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox16.Controls.Add(this.button2);
			this.groupBox16.Controls.Add(this.button3);
			this.groupBox16.Controls.Add(this.dataGrid2);
			this.groupBox16.Controls.Add(this.button4);
			this.groupBox16.Location = new System.Drawing.Point(8, 48);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(854, 269);
			this.groupBox16.TabIndex = 4;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Oneri deducibili";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 0;
			this.button2.Tag = "insert.contrattodetail";
			this.button2.Text = "Inserisci";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(112, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 1;
			this.button3.Tag = "edit.contrattodetail";
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
			this.dataGrid2.Location = new System.Drawing.Point(8, 40);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(838, 221);
			this.dataGrid2.TabIndex = 3;
			this.dataGrid2.Tag = "deductibleexpense.contrattodetail.contrattodetail";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(208, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 2;
			this.button4.Tag = "delete";
			this.button4.Text = "Elimina";
			// 
			// tabCUD
			// 
			this.tabCUD.Controls.Add(this.groupBox4);
			this.tabCUD.Location = new System.Drawing.Point(4, 22);
			this.tabCUD.Name = "tabCUD";
			this.tabCUD.Size = new System.Drawing.Size(862, 520);
			this.tabCUD.TabIndex = 6;
			this.tabCUD.Text = "CUD";
			this.tabCUD.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.textBox7);
			this.groupBox4.Controls.Add(this.btnVerificaProblemi);
			this.groupBox4.Controls.Add(this.groupBox6);
			this.groupBox4.Controls.Add(this.groupBox5);
			this.groupBox4.Controls.Add(this.button10);
			this.groupBox4.Controls.Add(this.button9);
			this.groupBox4.Controls.Add(this.inserisci_CUD);
			this.groupBox4.Controls.Add(this.dgrid_CUD);
			this.groupBox4.Location = new System.Drawing.Point(8, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(846, 511);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Dati CUD Presentati";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox7.Location = new System.Drawing.Point(8, 212);
			this.textBox7.Multiline = true;
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(830, 24);
			this.textBox7.TabIndex = 10;
			this.textBox7.Text = "Gli oneri deducibili e detraibili presenti nei CUD sono considerati solo in fase " +
    "di conguaglio ";
			// 
			// btnVerificaProblemi
			// 
			this.btnVerificaProblemi.Location = new System.Drawing.Point(616, 37);
			this.btnVerificaProblemi.Name = "btnVerificaProblemi";
			this.btnVerificaProblemi.Size = new System.Drawing.Size(112, 32);
			this.btnVerificaProblemi.TabIndex = 6;
			this.btnVerificaProblemi.Text = "Verifica problemi";
			this.btnVerificaProblemi.Click += new System.EventHandler(this.btnVerificaProblemi_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.dgrid_DetCud);
			this.groupBox6.Controls.Add(this.btnDeleteDet);
			this.groupBox6.Controls.Add(this.btnEditDet);
			this.groupBox6.Controls.Add(this.btnInsertDet);
			this.groupBox6.Location = new System.Drawing.Point(8, 378);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(830, 125);
			this.groupBox6.TabIndex = 5;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Dettagli Detrazioni CUD Presentato";
			// 
			// dgrid_DetCud
			// 
			this.dgrid_DetCud.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrid_DetCud.CaptionVisible = false;
			this.dgrid_DetCud.DataMember = "";
			this.dgrid_DetCud.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrid_DetCud.Location = new System.Drawing.Point(8, 40);
			this.dgrid_DetCud.Name = "dgrid_DetCud";
			this.dgrid_DetCud.Size = new System.Drawing.Size(814, 77);
			this.dgrid_DetCud.TabIndex = 3;
			this.dgrid_DetCud.Tag = "exhibitedcudabatement.default.default";
			// 
			// btnDeleteDet
			// 
			this.btnDeleteDet.Location = new System.Drawing.Point(184, 16);
			this.btnDeleteDet.Name = "btnDeleteDet";
			this.btnDeleteDet.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteDet.TabIndex = 2;
			this.btnDeleteDet.Tag = "delete";
			this.btnDeleteDet.Text = "Elimina";
			// 
			// btnEditDet
			// 
			this.btnEditDet.Location = new System.Drawing.Point(96, 16);
			this.btnEditDet.Name = "btnEditDet";
			this.btnEditDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditDet.TabIndex = 1;
			this.btnEditDet.Tag = "edit.default";
			this.btnEditDet.Text = "Modifica";
			// 
			// btnInsertDet
			// 
			this.btnInsertDet.Location = new System.Drawing.Point(8, 16);
			this.btnInsertDet.Name = "btnInsertDet";
			this.btnInsertDet.Size = new System.Drawing.Size(75, 23);
			this.btnInsertDet.TabIndex = 0;
			this.btnInsertDet.Tag = "insert.default";
			this.btnInsertDet.Text = "Inserisci";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.dgrid_DedCud);
			this.groupBox5.Controls.Add(this.btnDeleteDed);
			this.groupBox5.Controls.Add(this.btnEditDed);
			this.groupBox5.Controls.Add(this.btnInsertDed);
			this.groupBox5.Location = new System.Drawing.Point(8, 242);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(832, 130);
			this.groupBox5.TabIndex = 4;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Dettagli Deduzioni CUD Presentato";
			// 
			// dgrid_DedCud
			// 
			this.dgrid_DedCud.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrid_DedCud.CaptionVisible = false;
			this.dgrid_DedCud.DataMember = "";
			this.dgrid_DedCud.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrid_DedCud.Location = new System.Drawing.Point(14, 39);
			this.dgrid_DedCud.Name = "dgrid_DedCud";
			this.dgrid_DedCud.Size = new System.Drawing.Size(816, 85);
			this.dgrid_DedCud.TabIndex = 3;
			this.dgrid_DedCud.Tag = "exhibitedcuddeduction.default.default";
			// 
			// btnDeleteDed
			// 
			this.btnDeleteDed.Location = new System.Drawing.Point(184, 16);
			this.btnDeleteDed.Name = "btnDeleteDed";
			this.btnDeleteDed.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteDed.TabIndex = 2;
			this.btnDeleteDed.Tag = "delete";
			this.btnDeleteDed.Text = "Elimina";
			// 
			// btnEditDed
			// 
			this.btnEditDed.Location = new System.Drawing.Point(96, 16);
			this.btnEditDed.Name = "btnEditDed";
			this.btnEditDed.Size = new System.Drawing.Size(75, 23);
			this.btnEditDed.TabIndex = 1;
			this.btnEditDed.Tag = "edit.default";
			this.btnEditDed.Text = "Modifica";
			// 
			// btnInsertDed
			// 
			this.btnInsertDed.Location = new System.Drawing.Point(8, 16);
			this.btnInsertDed.Name = "btnInsertDed";
			this.btnInsertDed.Size = new System.Drawing.Size(75, 23);
			this.btnInsertDed.TabIndex = 0;
			this.btnInsertDed.Tag = "insert.default";
			this.btnInsertDed.Text = "Inserisci";
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(200, 45);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(75, 23);
			this.button10.TabIndex = 2;
			this.button10.Tag = "delete";
			this.button10.Text = "Elimina";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(104, 45);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 1;
			this.button9.Tag = "edit.default";
			this.button9.Text = "Modifica";
			// 
			// inserisci_CUD
			// 
			this.inserisci_CUD.Location = new System.Drawing.Point(8, 45);
			this.inserisci_CUD.Name = "inserisci_CUD";
			this.inserisci_CUD.Size = new System.Drawing.Size(75, 23);
			this.inserisci_CUD.TabIndex = 0;
			this.inserisci_CUD.Tag = "insert.default";
			this.inserisci_CUD.Text = "Inserisci";
			this.inserisci_CUD.Click += new System.EventHandler(this.inserisci_CUD_Click);
			// 
			// dgrid_CUD
			// 
			this.dgrid_CUD.AllowNavigation = false;
			this.dgrid_CUD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrid_CUD.CaptionVisible = false;
			this.dgrid_CUD.DataMember = "";
			this.dgrid_CUD.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrid_CUD.Location = new System.Drawing.Point(8, 74);
			this.dgrid_CUD.Name = "dgrid_CUD";
			this.dgrid_CUD.Size = new System.Drawing.Size(830, 132);
			this.dgrid_CUD.TabIndex = 3;
			this.dgrid_CUD.Tag = "exhibitedcud.default.default";
			// 
			// tabAddizionali
			// 
			this.tabAddizionali.Controls.Add(this.grpAccontoAddCom);
			this.tabAddizionali.Controls.Add(this.groupBox3);
			this.tabAddizionali.Controls.Add(this.grpAddizionaliPassate);
			this.tabAddizionali.Location = new System.Drawing.Point(4, 22);
			this.tabAddizionali.Name = "tabAddizionali";
			this.tabAddizionali.Size = new System.Drawing.Size(862, 520);
			this.tabAddizionali.TabIndex = 3;
			this.tabAddizionali.Text = "Addizionali";
			this.tabAddizionali.UseVisualStyleBackColor = true;
			// 
			// grpAccontoAddCom
			// 
			this.grpAccontoAddCom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpAccontoAddCom.Controls.Add(this.btnCalcAcconto);
			this.grpAccontoAddCom.Controls.Add(this.SubEntity_cmbMeseInizioAcconto);
			this.grpAccontoAddCom.Controls.Add(this.SubEntity_txtNumRateAcconto);
			this.grpAccontoAddCom.Controls.Add(this.SubEntity_txtImportoAcconto);
			this.grpAccontoAddCom.Controls.Add(this.label16);
			this.grpAccontoAddCom.Controls.Add(this.label15);
			this.grpAccontoAddCom.Controls.Add(this.label14);
			this.grpAccontoAddCom.Location = new System.Drawing.Point(429, 256);
			this.grpAccontoAddCom.Name = "grpAccontoAddCom";
			this.grpAccontoAddCom.Size = new System.Drawing.Size(430, 258);
			this.grpAccontoAddCom.TabIndex = 5;
			this.grpAccontoAddCom.TabStop = false;
			this.grpAccontoAddCom.Text = "Acconto dell\'addizionale comunale per l\'esercizio XXX";
			// 
			// btnCalcAcconto
			// 
			this.btnCalcAcconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCalcAcconto.Location = new System.Drawing.Point(160, 107);
			this.btnCalcAcconto.Name = "btnCalcAcconto";
			this.btnCalcAcconto.Size = new System.Drawing.Size(262, 23);
			this.btnCalcAcconto.TabIndex = 6;
			this.btnCalcAcconto.Text = "Calcola Acconto";
			this.btnCalcAcconto.UseVisualStyleBackColor = true;
			this.btnCalcAcconto.Click += new System.EventHandler(this.btnCalcAcconto_Click);
			// 
			// SubEntity_cmbMeseInizioAcconto
			// 
			this.SubEntity_cmbMeseInizioAcconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbMeseInizioAcconto.DataSource = this.DS.monthname;
			this.SubEntity_cmbMeseInizioAcconto.DisplayMember = "title";
			this.SubEntity_cmbMeseInizioAcconto.FormattingEnabled = true;
			this.SubEntity_cmbMeseInizioAcconto.Location = new System.Drawing.Point(191, 75);
			this.SubEntity_cmbMeseInizioAcconto.Name = "SubEntity_cmbMeseInizioAcconto";
			this.SubEntity_cmbMeseInizioAcconto.Size = new System.Drawing.Size(231, 21);
			this.SubEntity_cmbMeseInizioAcconto.TabIndex = 5;
			this.SubEntity_cmbMeseInizioAcconto.Tag = "parasubcontractyear.startmonth_account?parasubcontractview.startmonth_account";
			this.SubEntity_cmbMeseInizioAcconto.ValueMember = "code";
			// 
			// SubEntity_txtNumRateAcconto
			// 
			this.SubEntity_txtNumRateAcconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtNumRateAcconto.Location = new System.Drawing.Point(191, 49);
			this.SubEntity_txtNumRateAcconto.Name = "SubEntity_txtNumRateAcconto";
			this.SubEntity_txtNumRateAcconto.Size = new System.Drawing.Size(231, 20);
			this.SubEntity_txtNumRateAcconto.TabIndex = 4;
			this.SubEntity_txtNumRateAcconto.Tag = "parasubcontractyear.ratequantity_account?parasubcontractview.ratequantity_account" +
    "";
			// 
			// SubEntity_txtImportoAcconto
			// 
			this.SubEntity_txtImportoAcconto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtImportoAcconto.Location = new System.Drawing.Point(191, 23);
			this.SubEntity_txtImportoAcconto.Name = "SubEntity_txtImportoAcconto";
			this.SubEntity_txtImportoAcconto.Size = new System.Drawing.Size(231, 20);
			this.SubEntity_txtImportoAcconto.TabIndex = 3;
			this.SubEntity_txtImportoAcconto.Tag = "parasubcontractyear.citytax_account?parasubcontractview.citytax_account";
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(71, 77);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 13);
			this.label16.TabIndex = 2;
			this.label16.Text = "Mese Inizio:";
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(71, 52);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(73, 13);
			this.label15.TabIndex = 1;
			this.label15.Text = "Numero Rate:";
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(71, 26);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 13);
			this.label14.TabIndex = 0;
			this.label14.Text = "Importo dell\'acconto:";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.button20);
			this.groupBox3.Controls.Add(this.button19);
			this.groupBox3.Controls.Add(this.button18);
			this.groupBox3.Controls.Add(this.dataGrid11);
			this.groupBox3.Location = new System.Drawing.Point(8, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(846, 248);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Comunicazioni dal Centro di Assistenza Fiscale";
			// 
			// button20
			// 
			this.button20.Location = new System.Drawing.Point(208, 24);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(75, 23);
			this.button20.TabIndex = 6;
			this.button20.Tag = "delete";
			this.button20.Text = "Elimina";
			// 
			// button19
			// 
			this.button19.Location = new System.Drawing.Point(112, 24);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(75, 23);
			this.button19.TabIndex = 5;
			this.button19.Tag = "edit.default";
			this.button19.Text = "Modifica";
			// 
			// button18
			// 
			this.button18.Location = new System.Drawing.Point(16, 24);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(75, 23);
			this.button18.TabIndex = 4;
			this.button18.Tag = "insert.default";
			this.button18.Text = "Inserisci";
			this.button18.Click += new System.EventHandler(this.button18_Click);
			// 
			// dataGrid11
			// 
			this.dataGrid11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid11.CaptionVisible = false;
			this.dataGrid11.DataMember = "";
			this.dataGrid11.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid11.Location = new System.Drawing.Point(8, 56);
			this.dataGrid11.Name = "dataGrid11";
			this.dataGrid11.Size = new System.Drawing.Size(830, 186);
			this.dataGrid11.TabIndex = 3;
			this.dataGrid11.Tag = "cafdocument.contratto.contratto";
			// 
			// grpAddizionaliPassate
			// 
			this.grpAddizionaliPassate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpAddizionaliPassate.Controls.Add(this.groupBox20);
			this.grpAddizionaliPassate.Controls.Add(this.groupBox21);
			this.grpAddizionaliPassate.Controls.Add(this.SubEntity_cmbMeseInizio);
			this.grpAddizionaliPassate.Controls.Add(this.SubEntity_txtNumRate);
			this.grpAddizionaliPassate.Controls.Add(this.SubEntity_txtAddReg);
			this.grpAddizionaliPassate.Controls.Add(this.label10);
			this.grpAddizionaliPassate.Controls.Add(this.label12);
			this.grpAddizionaliPassate.Controls.Add(this.label11);
			this.grpAddizionaliPassate.Controls.Add(this.label9);
			this.grpAddizionaliPassate.Controls.Add(this.label13);
			this.grpAddizionaliPassate.Controls.Add(this.SubEntity_txtAddProv);
			this.grpAddizionaliPassate.Controls.Add(this.SubEntity_txtAddCom);
			this.grpAddizionaliPassate.Location = new System.Drawing.Point(8, 256);
			this.grpAddizionaliPassate.Name = "grpAddizionaliPassate";
			this.grpAddizionaliPassate.Size = new System.Drawing.Size(415, 258);
			this.grpAddizionaliPassate.TabIndex = 2;
			this.grpAddizionaliPassate.TabStop = false;
			this.grpAddizionaliPassate.Text = "Addizionali derivanti da contratti della stessa università per l\'esercizio XXXX";
			// 
			// groupBox20
			// 
			this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox20.Controls.Add(this.txtComuneAddRegRata);
			this.groupBox20.Location = new System.Drawing.Point(7, 147);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(400, 43);
			this.groupBox20.TabIndex = 23;
			this.groupBox20.TabStop = false;
			this.groupBox20.Tag = "";
			this.groupBox20.Text = "Comune di riferimento per le addizionali regionali da rateizzare";
			// 
			// txtComuneAddRegRata
			// 
			this.txtComuneAddRegRata.Location = new System.Drawing.Point(9, 19);
			this.txtComuneAddRegRata.Name = "txtComuneAddRegRata";
			this.txtComuneAddRegRata.ReadOnly = true;
			this.txtComuneAddRegRata.Size = new System.Drawing.Size(384, 20);
			this.txtComuneAddRegRata.TabIndex = 8;
			this.txtComuneAddRegRata.Tag = "";
			// 
			// groupBox21
			// 
			this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox21.Controls.Add(this.txtComuneAddComRata);
			this.groupBox21.Location = new System.Drawing.Point(8, 100);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new System.Drawing.Size(400, 43);
			this.groupBox21.TabIndex = 22;
			this.groupBox21.TabStop = false;
			this.groupBox21.Tag = "";
			this.groupBox21.Text = "Comune di riferimento per le addizionali comunali da rateizzare";
			// 
			// txtComuneAddComRata
			// 
			this.txtComuneAddComRata.Location = new System.Drawing.Point(8, 19);
			this.txtComuneAddComRata.Name = "txtComuneAddComRata";
			this.txtComuneAddComRata.ReadOnly = true;
			this.txtComuneAddComRata.Size = new System.Drawing.Size(384, 20);
			this.txtComuneAddComRata.TabIndex = 8;
			this.txtComuneAddComRata.Tag = "";
			// 
			// SubEntity_cmbMeseInizio
			// 
			this.SubEntity_cmbMeseInizio.DataSource = this.DS.monthname;
			this.SubEntity_cmbMeseInizio.DisplayMember = "title";
			this.SubEntity_cmbMeseInizio.Location = new System.Drawing.Point(279, 47);
			this.SubEntity_cmbMeseInizio.Name = "SubEntity_cmbMeseInizio";
			this.SubEntity_cmbMeseInizio.Size = new System.Drawing.Size(104, 21);
			this.SubEntity_cmbMeseInizio.TabIndex = 9;
			this.SubEntity_cmbMeseInizio.Tag = "parasubcontractyear.startmonth?parasubcontractview.startmonth";
			this.SubEntity_cmbMeseInizio.ValueMember = "code";
			// 
			// SubEntity_txtNumRate
			// 
			this.SubEntity_txtNumRate.Location = new System.Drawing.Point(279, 18);
			this.SubEntity_txtNumRate.Name = "SubEntity_txtNumRate";
			this.SubEntity_txtNumRate.Size = new System.Drawing.Size(104, 20);
			this.SubEntity_txtNumRate.TabIndex = 7;
			this.SubEntity_txtNumRate.Tag = "parasubcontractyear.ratequantity?parasubcontractview.ratequantity";
			// 
			// SubEntity_txtAddReg
			// 
			this.SubEntity_txtAddReg.Location = new System.Drawing.Point(82, 19);
			this.SubEntity_txtAddReg.Name = "SubEntity_txtAddReg";
			this.SubEntity_txtAddReg.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtAddReg.TabIndex = 1;
			this.SubEntity_txtAddReg.Tag = "parasubcontractyear.regionaltax?parasubcontractview.regionaltax";
			// 
			// label10
			// 
			this.label10.Enabled = false;
			this.label10.Location = new System.Drawing.Point(6, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(70, 18);
			this.label10.TabIndex = 2;
			this.label10.Text = "Provinciale:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(205, 19);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(104, 16);
			this.label12.TabIndex = 6;
			this.label12.Text = "Numero Rate:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(6, 77);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(70, 18);
			this.label11.TabIndex = 4;
			this.label11.Text = "Comunale:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(6, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(70, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "Regionale:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(205, 48);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 16);
			this.label13.TabIndex = 8;
			this.label13.Text = "Mese Inizio:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SubEntity_txtAddProv
			// 
			this.SubEntity_txtAddProv.Enabled = false;
			this.SubEntity_txtAddProv.Location = new System.Drawing.Point(82, 47);
			this.SubEntity_txtAddProv.Name = "SubEntity_txtAddProv";
			this.SubEntity_txtAddProv.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtAddProv.TabIndex = 3;
			this.SubEntity_txtAddProv.Tag = "parasubcontractyear.countrytax?parasubcontractview.countrytax";
			// 
			// SubEntity_txtAddCom
			// 
			this.SubEntity_txtAddCom.Location = new System.Drawing.Point(82, 75);
			this.SubEntity_txtAddCom.Name = "SubEntity_txtAddCom";
			this.SubEntity_txtAddCom.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtAddCom.TabIndex = 5;
			this.SubEntity_txtAddCom.Tag = "parasubcontractyear.citytax?parasubcontractview.citytax";
			// 
			// tabCedolini
			// 
			this.tabCedolini.Controls.Add(this.label24);
			this.tabCedolini.Controls.Add(this.label23);
			this.tabCedolini.Controls.Add(this.dgCedoliniAltriEsercizi);
			this.tabCedolini.Controls.Add(this.btnGeneraCedolini);
			this.tabCedolini.Controls.Add(this.btnVisualizzaCedolino);
			this.tabCedolini.Controls.Add(this.btnCalcolaCedolino);
			this.tabCedolini.Controls.Add(this.dgCedolini);
			this.tabCedolini.Location = new System.Drawing.Point(4, 22);
			this.tabCedolini.Name = "tabCedolini";
			this.tabCedolini.Size = new System.Drawing.Size(862, 520);
			this.tabCedolini.TabIndex = 8;
			this.tabCedolini.Text = "Cedolini";
			this.tabCedolini.UseVisualStyleBackColor = true;
			this.tabCedolini.Click += new System.EventHandler(this.tabCedolini_Click);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(17, 42);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(841, 20);
			this.label24.TabIndex = 9;
			this.label24.Text = "Esercizio Corrente";
			this.label24.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(16, 254);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(841, 20);
			this.label23.TabIndex = 8;
			this.label23.Text = "Altri Esercizi";
			this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dgCedoliniAltriEsercizi
			// 
			this.dgCedoliniAltriEsercizi.AllowNavigation = false;
			this.dgCedoliniAltriEsercizi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCedoliniAltriEsercizi.CaptionVisible = false;
			this.dgCedoliniAltriEsercizi.DataMember = "";
			this.dgCedoliniAltriEsercizi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCedoliniAltriEsercizi.Location = new System.Drawing.Point(8, 277);
			this.dgCedoliniAltriEsercizi.Name = "dgCedoliniAltriEsercizi";
			this.dgCedoliniAltriEsercizi.Size = new System.Drawing.Size(846, 238);
			this.dgCedoliniAltriEsercizi.TabIndex = 7;
			this.dgCedoliniAltriEsercizi.Tag = "payroll_altriesercizi.default";
			this.dgCedoliniAltriEsercizi.DoubleClick += new System.EventHandler(this.dgCedoliniAltriEsercizi_DoubleClick);
			// 
			// btnGeneraCedolini
			// 
			this.btnGeneraCedolini.Location = new System.Drawing.Point(556, 13);
			this.btnGeneraCedolini.Name = "btnGeneraCedolini";
			this.btnGeneraCedolini.Size = new System.Drawing.Size(128, 23);
			this.btnGeneraCedolini.TabIndex = 6;
			this.btnGeneraCedolini.Text = "Reimposta compensi";
			this.btnGeneraCedolini.Click += new System.EventHandler(this.btnGeneraCedolini_Click);
			// 
			// btnVisualizzaCedolino
			// 
			this.btnVisualizzaCedolino.Location = new System.Drawing.Point(371, 13);
			this.btnVisualizzaCedolino.Name = "btnVisualizzaCedolino";
			this.btnVisualizzaCedolino.Size = new System.Drawing.Size(128, 23);
			this.btnVisualizzaCedolino.TabIndex = 5;
			this.btnVisualizzaCedolino.Tag = "";
			this.btnVisualizzaCedolino.Text = "Visualizza";
			this.btnVisualizzaCedolino.Click += new System.EventHandler(this.btnVisualizzaCedolino_Click);
			// 
			// btnCalcolaCedolino
			// 
			this.btnCalcolaCedolino.Location = new System.Drawing.Point(195, 13);
			this.btnCalcolaCedolino.Name = "btnCalcolaCedolino";
			this.btnCalcolaCedolino.Size = new System.Drawing.Size(128, 23);
			this.btnCalcolaCedolino.TabIndex = 3;
			this.btnCalcolaCedolino.Tag = "";
			this.btnCalcolaCedolino.Text = "Calcola";
			this.btnCalcolaCedolino.Click += new System.EventHandler(this.btnCalcolaCedolino_Click);
			// 
			// dgCedolini
			// 
			this.dgCedolini.AllowNavigation = false;
			this.dgCedolini.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCedolini.CaptionVisible = false;
			this.dgCedolini.DataMember = "";
			this.dgCedolini.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCedolini.Location = new System.Drawing.Point(8, 62);
			this.dgCedolini.Name = "dgCedolini";
			this.dgCedolini.Size = new System.Drawing.Size(846, 154);
			this.dgCedolini.TabIndex = 1;
			this.dgCedolini.Tag = "payroll.default";
			// 
			// tabErogazioni
			// 
			this.tabErogazioni.Controls.Add(this.groupBox1);
			this.tabErogazioni.Location = new System.Drawing.Point(4, 22);
			this.tabErogazioni.Name = "tabErogazioni";
			this.tabErogazioni.Size = new System.Drawing.Size(862, 520);
			this.tabErogazioni.TabIndex = 2;
			this.tabErogazioni.Text = "Erogazioni";
			this.tabErogazioni.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.dataGrid1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(846, 506);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Erogazioni legate al contratto corrente";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 24);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(830, 474);
			this.dataGrid1.TabIndex = 3;
			this.dataGrid1.Tag = "expensepayrollview.contratto";
			// 
			// tabDatiRiepilogativi
			// 
			this.tabDatiRiepilogativi.Controls.Add(this.label68);
			this.tabDatiRiepilogativi.Controls.Add(this.gridRitenute);
			this.tabDatiRiepilogativi.Controls.Add(this.txtCompensoNetto);
			this.tabDatiRiepilogativi.Controls.Add(this.label67);
			this.tabDatiRiepilogativi.Controls.Add(this.txtLordoAlBeneficiarioRiep);
			this.tabDatiRiepilogativi.Controls.Add(this.label66);
			this.tabDatiRiepilogativi.Controls.Add(this.txtCostoTotale);
			this.tabDatiRiepilogativi.Controls.Add(this.label65);
			this.tabDatiRiepilogativi.Controls.Add(this.groupBox14);
			this.tabDatiRiepilogativi.Controls.Add(this.groupBox13);
			this.tabDatiRiepilogativi.Location = new System.Drawing.Point(4, 22);
			this.tabDatiRiepilogativi.Name = "tabDatiRiepilogativi";
			this.tabDatiRiepilogativi.Size = new System.Drawing.Size(862, 520);
			this.tabDatiRiepilogativi.TabIndex = 12;
			this.tabDatiRiepilogativi.Text = "Riepilogo";
			this.tabDatiRiepilogativi.UseVisualStyleBackColor = true;
			// 
			// label68
			// 
			this.label68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label68.Location = new System.Drawing.Point(8, 8);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(752, 24);
			this.label68.TabIndex = 9;
			this.label68.Text = "Dati riepilogativi dei cedolini finora calcolati";
			this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gridRitenute
			// 
			this.gridRitenute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridRitenute.CaptionVisible = false;
			this.gridRitenute.DataMember = "";
			this.gridRitenute.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridRitenute.Location = new System.Drawing.Point(8, 208);
			this.gridRitenute.Name = "gridRitenute";
			this.gridRitenute.Size = new System.Drawing.Size(846, 306);
			this.gridRitenute.TabIndex = 8;
			// 
			// txtCompensoNetto
			// 
			this.txtCompensoNetto.Location = new System.Drawing.Point(136, 176);
			this.txtCompensoNetto.Name = "txtCompensoNetto";
			this.txtCompensoNetto.ReadOnly = true;
			this.txtCompensoNetto.Size = new System.Drawing.Size(100, 20);
			this.txtCompensoNetto.TabIndex = 7;
			this.txtCompensoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label67
			// 
			this.label67.Location = new System.Drawing.Point(48, 176);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(100, 20);
			this.label67.TabIndex = 6;
			this.label67.Text = "Compenso netto";
			this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLordoAlBeneficiarioRiep
			// 
			this.txtLordoAlBeneficiarioRiep.Location = new System.Drawing.Point(392, 176);
			this.txtLordoAlBeneficiarioRiep.Name = "txtLordoAlBeneficiarioRiep";
			this.txtLordoAlBeneficiarioRiep.ReadOnly = true;
			this.txtLordoAlBeneficiarioRiep.Size = new System.Drawing.Size(100, 20);
			this.txtLordoAlBeneficiarioRiep.TabIndex = 5;
			this.txtLordoAlBeneficiarioRiep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label66
			// 
			this.label66.Location = new System.Drawing.Point(288, 176);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(112, 20);
			this.label66.TabIndex = 4;
			this.label66.Text = "Lordo al beneficiario";
			this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCostoTotale
			// 
			this.txtCostoTotale.Location = new System.Drawing.Point(616, 176);
			this.txtCostoTotale.Name = "txtCostoTotale";
			this.txtCostoTotale.ReadOnly = true;
			this.txtCostoTotale.Size = new System.Drawing.Size(100, 20);
			this.txtCostoTotale.TabIndex = 3;
			this.txtCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(552, 176);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(100, 20);
			this.label65.TabIndex = 2;
			this.label65.Text = "Costo totale";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.txtAssicAmm);
			this.groupBox14.Controls.Add(this.label61);
			this.groupBox14.Controls.Add(this.txtAssisAmm);
			this.groupBox14.Controls.Add(this.label62);
			this.groupBox14.Controls.Add(this.txtPrevAmm);
			this.groupBox14.Controls.Add(this.label63);
			this.groupBox14.Controls.Add(this.txtFiscAmm);
			this.groupBox14.Controls.Add(this.label64);
			this.groupBox14.Controls.Add(this.txtTotaleRitAmmin);
			this.groupBox14.Controls.Add(this.label60);
			this.groupBox14.Location = new System.Drawing.Point(8, 32);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(736, 64);
			this.groupBox14.TabIndex = 1;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Ritenute conto Amministrazione";
			// 
			// txtAssicAmm
			// 
			this.txtAssicAmm.Location = new System.Drawing.Point(408, 32);
			this.txtAssicAmm.Name = "txtAssicAmm";
			this.txtAssicAmm.ReadOnly = true;
			this.txtAssicAmm.Size = new System.Drawing.Size(100, 20);
			this.txtAssicAmm.TabIndex = 7;
			this.txtAssicAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(408, 16);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(100, 20);
			this.label61.TabIndex = 6;
			this.label61.Text = "Assicurative";
			this.label61.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtAssisAmm
			// 
			this.txtAssisAmm.Location = new System.Drawing.Point(288, 32);
			this.txtAssisAmm.Name = "txtAssisAmm";
			this.txtAssisAmm.ReadOnly = true;
			this.txtAssisAmm.Size = new System.Drawing.Size(100, 20);
			this.txtAssisAmm.TabIndex = 5;
			this.txtAssisAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(288, 16);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(100, 20);
			this.label62.TabIndex = 4;
			this.label62.Text = "Assistenziali";
			this.label62.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtPrevAmm
			// 
			this.txtPrevAmm.Location = new System.Drawing.Point(168, 32);
			this.txtPrevAmm.Name = "txtPrevAmm";
			this.txtPrevAmm.ReadOnly = true;
			this.txtPrevAmm.Size = new System.Drawing.Size(100, 20);
			this.txtPrevAmm.TabIndex = 3;
			this.txtPrevAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(168, 16);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(100, 20);
			this.label63.TabIndex = 2;
			this.label63.Text = "Previdenziali";
			this.label63.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtFiscAmm
			// 
			this.txtFiscAmm.Location = new System.Drawing.Point(48, 32);
			this.txtFiscAmm.Name = "txtFiscAmm";
			this.txtFiscAmm.ReadOnly = true;
			this.txtFiscAmm.Size = new System.Drawing.Size(100, 20);
			this.txtFiscAmm.TabIndex = 1;
			this.txtFiscAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label64
			// 
			this.label64.Location = new System.Drawing.Point(48, 16);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(100, 20);
			this.label64.TabIndex = 0;
			this.label64.Text = "Fiscali";
			this.label64.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtTotaleRitAmmin
			// 
			this.txtTotaleRitAmmin.Location = new System.Drawing.Point(608, 32);
			this.txtTotaleRitAmmin.Name = "txtTotaleRitAmmin";
			this.txtTotaleRitAmmin.ReadOnly = true;
			this.txtTotaleRitAmmin.Size = new System.Drawing.Size(100, 20);
			this.txtTotaleRitAmmin.TabIndex = 9;
			this.txtTotaleRitAmmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(608, 8);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(100, 20);
			this.label60.TabIndex = 8;
			this.label60.Text = "Totale rit. c/Amm";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox13
			// 
			this.groupBox13.Controls.Add(this.txtAssicDip);
			this.groupBox13.Controls.Add(this.label58);
			this.groupBox13.Controls.Add(this.txtAssisDip);
			this.groupBox13.Controls.Add(this.label57);
			this.groupBox13.Controls.Add(this.txtPrevDip);
			this.groupBox13.Controls.Add(this.label56);
			this.groupBox13.Controls.Add(this.txtFiscDip);
			this.groupBox13.Controls.Add(this.label55);
			this.groupBox13.Controls.Add(this.txtTotaleRitDip);
			this.groupBox13.Controls.Add(this.label59);
			this.groupBox13.Location = new System.Drawing.Point(8, 96);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(736, 64);
			this.groupBox13.TabIndex = 0;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Ritenute conto dipendente";
			// 
			// txtAssicDip
			// 
			this.txtAssicDip.Location = new System.Drawing.Point(408, 32);
			this.txtAssicDip.Name = "txtAssicDip";
			this.txtAssicDip.ReadOnly = true;
			this.txtAssicDip.Size = new System.Drawing.Size(100, 20);
			this.txtAssicDip.TabIndex = 7;
			this.txtAssicDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(408, 16);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(100, 20);
			this.label58.TabIndex = 6;
			this.label58.Text = "Assicurative";
			this.label58.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtAssisDip
			// 
			this.txtAssisDip.Location = new System.Drawing.Point(288, 32);
			this.txtAssisDip.Name = "txtAssisDip";
			this.txtAssisDip.ReadOnly = true;
			this.txtAssisDip.Size = new System.Drawing.Size(100, 20);
			this.txtAssisDip.TabIndex = 5;
			this.txtAssisDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(288, 16);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(100, 20);
			this.label57.TabIndex = 4;
			this.label57.Text = "Assistenziali";
			this.label57.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtPrevDip
			// 
			this.txtPrevDip.Location = new System.Drawing.Point(168, 32);
			this.txtPrevDip.Name = "txtPrevDip";
			this.txtPrevDip.ReadOnly = true;
			this.txtPrevDip.Size = new System.Drawing.Size(100, 20);
			this.txtPrevDip.TabIndex = 3;
			this.txtPrevDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(168, 16);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(100, 20);
			this.label56.TabIndex = 2;
			this.label56.Text = "Previdenziali";
			this.label56.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtFiscDip
			// 
			this.txtFiscDip.Location = new System.Drawing.Point(48, 32);
			this.txtFiscDip.Name = "txtFiscDip";
			this.txtFiscDip.ReadOnly = true;
			this.txtFiscDip.Size = new System.Drawing.Size(100, 20);
			this.txtFiscDip.TabIndex = 1;
			this.txtFiscDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(48, 16);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(100, 20);
			this.label55.TabIndex = 0;
			this.label55.Text = "Fiscali";
			this.label55.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtTotaleRitDip
			// 
			this.txtTotaleRitDip.Location = new System.Drawing.Point(608, 32);
			this.txtTotaleRitDip.Name = "txtTotaleRitDip";
			this.txtTotaleRitDip.ReadOnly = true;
			this.txtTotaleRitDip.Size = new System.Drawing.Size(100, 20);
			this.txtTotaleRitDip.TabIndex = 9;
			this.txtTotaleRitDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label59
			// 
			this.label59.Location = new System.Drawing.Point(608, 8);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(100, 20);
			this.label59.TabIndex = 8;
			this.label59.Text = "Totale rit. c/dip";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TabClassSuppl
			// 
			this.TabClassSuppl.Controls.Add(this.btnClassElimina);
			this.TabClassSuppl.Controls.Add(this.btnClassModifica);
			this.TabClassSuppl.Controls.Add(this.btnClassInserisci);
			this.TabClassSuppl.Controls.Add(this.dgrClassSuppl);
			this.TabClassSuppl.ImageIndex = 0;
			this.TabClassSuppl.Location = new System.Drawing.Point(4, 22);
			this.TabClassSuppl.Name = "TabClassSuppl";
			this.TabClassSuppl.Size = new System.Drawing.Size(862, 520);
			this.TabClassSuppl.TabIndex = 13;
			this.TabClassSuppl.Text = "Classificazione";
			this.TabClassSuppl.UseVisualStyleBackColor = true;
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(208, 16);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(75, 23);
			this.btnClassElimina.TabIndex = 29;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(112, 16);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(75, 23);
			this.btnClassModifica.TabIndex = 28;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(75, 23);
			this.btnClassInserisci.TabIndex = 27;
			this.btnClassInserisci.Tag = "insert.default";
			this.btnClassInserisci.Text = "Inserisci";
			// 
			// dgrClassSuppl
			// 
			this.dgrClassSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassSuppl.CaptionVisible = false;
			this.dgrClassSuppl.DataMember = "";
			this.dgrClassSuppl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassSuppl.Location = new System.Drawing.Point(8, 48);
			this.dgrClassSuppl.Name = "dgrClassSuppl";
			this.dgrClassSuppl.ReadOnly = true;
			this.dgrClassSuppl.Size = new System.Drawing.Size(846, 466);
			this.dgrClassSuppl.TabIndex = 23;
			this.dgrClassSuppl.Tag = "parasubcontractsorting.default.default";
			// 
			// tabEconoPatr
			// 
			this.tabEconoPatr.Controls.Add(this.tabControl2);
			this.tabEconoPatr.Location = new System.Drawing.Point(4, 22);
			this.tabEconoPatr.Name = "tabEconoPatr";
			this.tabEconoPatr.Size = new System.Drawing.Size(862, 520);
			this.tabEconoPatr.TabIndex = 14;
			this.tabEconoPatr.Text = "E/P";
			this.tabEconoPatr.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabFinanziario);
			this.tabControl2.Controls.Add(this.tabAnalitico);
			this.tabControl2.Controls.Add(this.tabEP);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(862, 520);
			this.tabControl2.TabIndex = 0;
			// 
			// tabFinanziario
			// 
			this.tabFinanziario.Controls.Add(this.gboxUPB);
			this.tabFinanziario.Location = new System.Drawing.Point(4, 22);
			this.tabFinanziario.Name = "tabFinanziario";
			this.tabFinanziario.Size = new System.Drawing.Size(854, 494);
			this.tabFinanziario.TabIndex = 0;
			this.tabFinanziario.Text = "Finanziario";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(3, 3);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(413, 104);
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
			this.txtUPB.Size = new System.Drawing.Size(396, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(229, 62);
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
			// tabAnalitico
			// 
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(854, 494);
			this.tabAnalitico.TabIndex = 1;
			this.tabAnalitico.Text = "Analitico";
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(12, 202);
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
			this.txtDenom3.Location = new System.Drawing.Point(150, 8);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(275, 45);
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
			this.gboxclass2.Location = new System.Drawing.Point(12, 98);
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
			this.txtDenom2.Location = new System.Drawing.Point(150, 8);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(275, 52);
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
			this.gboxclass1.Location = new System.Drawing.Point(12, 3);
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
			this.txtDenom1.Location = new System.Drawing.Point(150, 8);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(275, 52);
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
			// tabEP
			// 
			this.tabEP.Controls.Add(this.grpBoxSiopeEP);
			this.tabEP.Controls.Add(this.label19);
			this.tabEP.Controls.Add(this.textBox8);
			this.tabEP.Controls.Add(this.gBoxCausaleDebitoCrg);
			this.tabEP.Controls.Add(this.gBoxCausaleDebito);
			this.tabEP.Controls.Add(this.gBoxCausaleCosto);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(854, 494);
			this.tabEP.TabIndex = 2;
			this.tabEP.Text = "E/P";
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(364, 40);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(320, 92);
			this.grpBoxSiopeEP.TabIndex = 52;
			this.grpBoxSiopeEP.TabStop = false;
			this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
			this.grpBoxSiopeEP.Text = "Class.SIOPE";
			// 
			// btnSiope
			// 
			this.btnSiope.Location = new System.Drawing.Point(8, 35);
			this.btnSiope.Name = "btnSiope";
			this.btnSiope.Size = new System.Drawing.Size(106, 20);
			this.btnSiope.TabIndex = 11;
			this.btnSiope.Text = "Codice";
			this.btnSiope.UseVisualStyleBackColor = true;
			// 
			// txtDescSiope
			// 
			this.txtDescSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescSiope.Location = new System.Drawing.Point(118, 12);
			this.txtDescSiope.Multiline = true;
			this.txtDescSiope.Name = "txtDescSiope";
			this.txtDescSiope.ReadOnly = true;
			this.txtDescSiope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescSiope.Size = new System.Drawing.Size(194, 69);
			this.txtDescSiope.TabIndex = 2;
			this.txtDescSiope.Tag = "sorting_siope.description";
			// 
			// txtCodSiope
			// 
			this.txtCodSiope.Location = new System.Drawing.Point(8, 61);
			this.txtCodSiope.Name = "txtCodSiope";
			this.txtCodSiope.Size = new System.Drawing.Size(108, 20);
			this.txtCodSiope.TabIndex = 9;
			this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(365, 135);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(265, 16);
			this.label19.TabIndex = 16;
			this.label19.Text = "Data correzione causale di debito";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(364, 154);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(134, 20);
			this.textBox8.TabIndex = 2;
			this.textBox8.Tag = "parasubcontract.idaccmotivedebit_datacrg";
			// 
			// gBoxCausaleDebitoCrg
			// 
			this.gBoxCausaleDebitoCrg.Controls.Add(this.textBox9);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.txtCodiceCausaleCrg);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.button8);
			this.gBoxCausaleDebitoCrg.Location = new System.Drawing.Point(364, 180);
			this.gBoxCausaleDebitoCrg.Name = "gBoxCausaleDebitoCrg";
			this.gBoxCausaleDebitoCrg.Size = new System.Drawing.Size(328, 149);
			this.gBoxCausaleDebitoCrg.TabIndex = 3;
			this.gBoxCausaleDebitoCrg.TabStop = false;
			this.gBoxCausaleDebitoCrg.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
			this.gBoxCausaleDebitoCrg.Text = "Causale di debito aggiornata";
			this.gBoxCausaleDebitoCrg.UseCompatibleTextRendering = true;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(120, 16);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(200, 92);
			this.textBox9.TabIndex = 2;
			this.textBox9.TabStop = false;
			this.textBox9.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(8, 114);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?parasubcontractview.codemotivedebit_crg";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(10, 85);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(104, 23);
			this.button8.TabIndex = 0;
			this.button8.Tag = "manage.accmotiveapplied_crg.tree";
			this.button8.Text = "Causale";
			// 
			// gBoxCausaleDebito
			// 
			this.gBoxCausaleDebito.Controls.Add(this.textBox10);
			this.gBoxCausaleDebito.Controls.Add(this.txtCodiceCausaleDeb);
			this.gBoxCausaleDebito.Controls.Add(this.button21);
			this.gBoxCausaleDebito.Location = new System.Drawing.Point(16, 180);
			this.gBoxCausaleDebito.Name = "gBoxCausaleDebito";
			this.gBoxCausaleDebito.Size = new System.Drawing.Size(328, 149);
			this.gBoxCausaleDebito.TabIndex = 1;
			this.gBoxCausaleDebito.TabStop = false;
			this.gBoxCausaleDebito.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gBoxCausaleDebito.Text = "Causale di debito";
			this.gBoxCausaleDebito.UseCompatibleTextRendering = true;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(120, 16);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(200, 92);
			this.textBox10.TabIndex = 2;
			this.textBox10.TabStop = false;
			this.textBox10.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(6, 114);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?parasubcontractview.codemotivedebit";
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(10, 85);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(104, 23);
			this.button21.TabIndex = 0;
			this.button21.Tag = "manage.accmotiveapplied_debit.tree";
			this.button21.Text = "Causale";
			// 
			// gBoxCausaleCosto
			// 
			this.gBoxCausaleCosto.Controls.Add(this.textBox5);
			this.gBoxCausaleCosto.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausaleCosto.Controls.Add(this.button17);
			this.gBoxCausaleCosto.Location = new System.Drawing.Point(16, 31);
			this.gBoxCausaleCosto.Name = "gBoxCausaleCosto";
			this.gBoxCausaleCosto.Size = new System.Drawing.Size(328, 143);
			this.gBoxCausaleCosto.TabIndex = 1;
			this.gBoxCausaleCosto.TabStop = false;
			this.gBoxCausaleCosto.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
			this.gBoxCausaleCosto.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(120, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(200, 95);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied_cost.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(8, 117);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied_cost.codemotive?parasubcontractview.codemotive";
			// 
			// button17
			// 
			this.button17.Location = new System.Drawing.Point(10, 88);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(104, 23);
			this.button17.TabIndex = 0;
			this.button17.Tag = "manage.accmotiveapplied_cost.tree";
			this.button17.Text = "Causale";
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(862, 520);
			this.tabAttributi.TabIndex = 16;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(6, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(564, 64);
			this.gboxclass05.TabIndex = 38;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 38);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(219, 20);
			this.txtCodice05.TabIndex = 6;
			// 
			// btnCodice05
			// 
			this.btnCodice05.Location = new System.Drawing.Point(8, 16);
			this.btnCodice05.Name = "btnCodice05";
			this.btnCodice05.Size = new System.Drawing.Size(88, 23);
			this.btnCodice05.TabIndex = 4;
			this.btnCodice05.Tag = "manage.sorting05.tree";
			this.btnCodice05.Text = "Codice";
			this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom05
			// 
			this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom05.Location = new System.Drawing.Point(234, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(322, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(6, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(564, 64);
			this.gboxclass04.TabIndex = 37;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(9, 38);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(219, 20);
			this.txtCodice04.TabIndex = 6;
			// 
			// btnCodice04
			// 
			this.btnCodice04.Location = new System.Drawing.Point(8, 16);
			this.btnCodice04.Name = "btnCodice04";
			this.btnCodice04.Size = new System.Drawing.Size(88, 23);
			this.btnCodice04.TabIndex = 4;
			this.btnCodice04.Tag = "manage.sorting04.tree";
			this.btnCodice04.Text = "Codice";
			this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom04
			// 
			this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom04.Location = new System.Drawing.Point(234, 12);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(322, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(6, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(564, 64);
			this.gboxclass03.TabIndex = 35;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// txtCodice03
			// 
			this.txtCodice03.Location = new System.Drawing.Point(8, 38);
			this.txtCodice03.Name = "txtCodice03";
			this.txtCodice03.Size = new System.Drawing.Size(219, 20);
			this.txtCodice03.TabIndex = 6;
			// 
			// btnCodice03
			// 
			this.btnCodice03.Location = new System.Drawing.Point(8, 16);
			this.btnCodice03.Name = "btnCodice03";
			this.btnCodice03.Size = new System.Drawing.Size(88, 23);
			this.btnCodice03.TabIndex = 4;
			this.btnCodice03.Tag = "manage.sorting03.tree";
			this.btnCodice03.Text = "Codice";
			this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom03
			// 
			this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom03.Location = new System.Drawing.Point(233, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(323, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(6, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(564, 64);
			this.gboxclass02.TabIndex = 36;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// txtCodice02
			// 
			this.txtCodice02.Location = new System.Drawing.Point(8, 38);
			this.txtCodice02.Name = "txtCodice02";
			this.txtCodice02.Size = new System.Drawing.Size(219, 20);
			this.txtCodice02.TabIndex = 6;
			// 
			// btnCodice02
			// 
			this.btnCodice02.Location = new System.Drawing.Point(8, 16);
			this.btnCodice02.Name = "btnCodice02";
			this.btnCodice02.Size = new System.Drawing.Size(88, 23);
			this.btnCodice02.TabIndex = 4;
			this.btnCodice02.Tag = "manage.sorting02.tree";
			this.btnCodice02.Text = "Codice";
			this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom02
			// 
			this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom02.Location = new System.Drawing.Point(233, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(323, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(564, 64);
			this.gboxclass01.TabIndex = 34;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// txtCodice01
			// 
			this.txtCodice01.Location = new System.Drawing.Point(7, 40);
			this.txtCodice01.Name = "txtCodice01";
			this.txtCodice01.Size = new System.Drawing.Size(220, 20);
			this.txtCodice01.TabIndex = 5;
			// 
			// btnCodice01
			// 
			this.btnCodice01.Location = new System.Drawing.Point(8, 16);
			this.btnCodice01.Name = "btnCodice01";
			this.btnCodice01.Size = new System.Drawing.Size(88, 23);
			this.btnCodice01.TabIndex = 4;
			this.btnCodice01.Tag = "manage.sorting01.tree";
			this.btnCodice01.Text = "Codice";
			this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom01
			// 
			this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom01.Location = new System.Drawing.Point(233, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(323, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabAP
			// 
			this.tabAP.Controls.Add(this.btnCollegaAP);
			this.tabAP.Controls.Add(this.btnGeneraAP);
			this.tabAP.Controls.Add(this.btnVisualizzaAP);
			this.tabAP.Controls.Add(this.labAPnongenerato);
			this.tabAP.Controls.Add(this.labAPgenerato);
			this.tabAP.Location = new System.Drawing.Point(4, 22);
			this.tabAP.Name = "tabAP";
			this.tabAP.Size = new System.Drawing.Size(862, 520);
			this.tabAP.TabIndex = 15;
			this.tabAP.Text = "A/P";
			this.tabAP.UseVisualStyleBackColor = true;
			// 
			// btnCollegaAP
			// 
			this.btnCollegaAP.Location = new System.Drawing.Point(476, 106);
			this.btnCollegaAP.Name = "btnCollegaAP";
			this.btnCollegaAP.Size = new System.Drawing.Size(224, 39);
			this.btnCollegaAP.TabIndex = 23;
			this.btnCollegaAP.Text = "Collega ad Anagrafe delle Prestazioni  già esistente";
			this.btnCollegaAP.Click += new System.EventHandler(this.btnCollegaAP_Click);
			// 
			// btnGeneraAP
			// 
			this.btnGeneraAP.Location = new System.Drawing.Point(476, 64);
			this.btnGeneraAP.Name = "btnGeneraAP";
			this.btnGeneraAP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraAP.TabIndex = 13;
			this.btnGeneraAP.Text = "Genera Anagrafe delle Prestazioni";
			this.btnGeneraAP.Click += new System.EventHandler(this.btnGeneraAP_Click);
			// 
			// btnVisualizzaAP
			// 
			this.btnVisualizzaAP.Location = new System.Drawing.Point(476, 32);
			this.btnVisualizzaAP.Name = "btnVisualizzaAP";
			this.btnVisualizzaAP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaAP.TabIndex = 12;
			this.btnVisualizzaAP.Text = "Visualizza Anagrafe delle Prestazione";
			this.btnVisualizzaAP.Click += new System.EventHandler(this.btnVisualizzaAP_Click);
			// 
			// labAPnongenerato
			// 
			this.labAPnongenerato.Location = new System.Drawing.Point(32, 64);
			this.labAPnongenerato.Name = "labAPnongenerato";
			this.labAPnongenerato.Size = new System.Drawing.Size(432, 24);
			this.labAPnongenerato.TabIndex = 11;
			this.labAPnongenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni  NON sono state ancora generate." +
    "";
			// 
			// labAPgenerato
			// 
			this.labAPgenerato.Location = new System.Drawing.Point(32, 40);
			this.labAPgenerato.Name = "labAPgenerato";
			this.labAPgenerato.Size = new System.Drawing.Size(448, 16);
			this.labAPgenerato.TabIndex = 10;
			this.labAPgenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni sono state generate.";
			// 
			// tabDALIA
			// 
			this.tabDALIA.Controls.Add(this.groupBox22);
			this.tabDALIA.Controls.Add(this.gboxDipartimento);
			this.tabDALIA.Controls.Add(this.grpCausaliAssunzioneDalia);
			this.tabDALIA.Controls.Add(this.txtVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.btnVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.groupBox18);
			this.tabDALIA.Location = new System.Drawing.Point(4, 22);
			this.tabDALIA.Name = "tabDALIA";
			this.tabDALIA.Padding = new System.Windows.Forms.Padding(3);
			this.tabDALIA.Size = new System.Drawing.Size(862, 520);
			this.tabDALIA.TabIndex = 17;
			this.tabDALIA.Text = "DALIA";
			this.tabDALIA.UseVisualStyleBackColor = true;
			// 
			// groupBox22
			// 
			this.groupBox22.Controls.Add(this.cmbDaliaFunzionale);
			this.groupBox22.Location = new System.Drawing.Point(21, 285);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new System.Drawing.Size(379, 54);
			this.groupBox22.TabIndex = 117;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Area funzionale - richiesta per il personale Tecnico / Amministrativo";
			// 
			// cmbDaliaFunzionale
			// 
			this.cmbDaliaFunzionale.FormattingEnabled = true;
			this.cmbDaliaFunzionale.Location = new System.Drawing.Point(6, 19);
			this.cmbDaliaFunzionale.Name = "cmbDaliaFunzionale";
			this.cmbDaliaFunzionale.Size = new System.Drawing.Size(367, 21);
			this.cmbDaliaFunzionale.TabIndex = 0;
			this.cmbDaliaFunzionale.Tag = "parasubcontract.iddalia_funzionale";
			// 
			// gboxDipartimento
			// 
			this.gboxDipartimento.Controls.Add(this.btnDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtCodiceDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtDaliaDipartimento);
			this.gboxDipartimento.Location = new System.Drawing.Point(21, 229);
			this.gboxDipartimento.Name = "gboxDipartimento";
			this.gboxDipartimento.Size = new System.Drawing.Size(814, 50);
			this.gboxDipartimento.TabIndex = 116;
			this.gboxDipartimento.TabStop = false;
			this.gboxDipartimento.Tag = "AutoChoose.txtDaliaDipartimento.default";
			this.gboxDipartimento.Text = "Dipartimento (colonna  DIP-IST)";
			// 
			// btnDipartimento
			// 
			this.btnDipartimento.Location = new System.Drawing.Point(9, 18);
			this.btnDipartimento.Name = "btnDipartimento";
			this.btnDipartimento.Size = new System.Drawing.Size(104, 23);
			this.btnDipartimento.TabIndex = 2;
			this.btnDipartimento.Tag = "choose.dalia_dipartimento.default";
			this.btnDipartimento.Text = "Dipartimento";
			this.btnDipartimento.UseVisualStyleBackColor = true;
			// 
			// txtCodiceDipartimento
			// 
			this.txtCodiceDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceDipartimento.Location = new System.Drawing.Point(701, 19);
			this.txtCodiceDipartimento.Name = "txtCodiceDipartimento";
			this.txtCodiceDipartimento.Size = new System.Drawing.Size(107, 20);
			this.txtCodiceDipartimento.TabIndex = 1;
			this.txtCodiceDipartimento.Tag = "dalia_dipartimento.codedip";
			// 
			// txtDaliaDipartimento
			// 
			this.txtDaliaDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDaliaDipartimento.Location = new System.Drawing.Point(131, 19);
			this.txtDaliaDipartimento.Name = "txtDaliaDipartimento";
			this.txtDaliaDipartimento.Size = new System.Drawing.Size(566, 20);
			this.txtDaliaDipartimento.TabIndex = 0;
			this.txtDaliaDipartimento.Tag = "dalia_dipartimento.title";
			// 
			// grpCausaliAssunzioneDalia
			// 
			this.grpCausaliAssunzioneDalia.Controls.Add(this.txtCausaleAssunzione);
			this.grpCausaliAssunzioneDalia.Controls.Add(this.btnEsclusioneCIG);
			this.grpCausaliAssunzioneDalia.Location = new System.Drawing.Point(21, 164);
			this.grpCausaliAssunzioneDalia.Name = "grpCausaliAssunzioneDalia";
			this.grpCausaliAssunzioneDalia.Size = new System.Drawing.Size(814, 46);
			this.grpCausaliAssunzioneDalia.TabIndex = 113;
			this.grpCausaliAssunzioneDalia.TabStop = false;
			this.grpCausaliAssunzioneDalia.Tag = "AutoChoose.txtCausaleAssunzione.default.(active = \'S\')";
			this.grpCausaliAssunzioneDalia.Text = " Causali immissione qualifica - Causali assunzione";
			// 
			// txtCausaleAssunzione
			// 
			this.txtCausaleAssunzione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausaleAssunzione.Location = new System.Drawing.Point(121, 16);
			this.txtCausaleAssunzione.Name = "txtCausaleAssunzione";
			this.txtCausaleAssunzione.Size = new System.Drawing.Size(685, 20);
			this.txtCausaleAssunzione.TabIndex = 2;
			this.txtCausaleAssunzione.Tag = "dalia_recruitmentmotive.description?x";
			// 
			// btnEsclusioneCIG
			// 
			this.btnEsclusioneCIG.Location = new System.Drawing.Point(9, 14);
			this.btnEsclusioneCIG.Name = "btnEsclusioneCIG";
			this.btnEsclusioneCIG.Size = new System.Drawing.Size(104, 23);
			this.btnEsclusioneCIG.TabIndex = 0;
			this.btnEsclusioneCIG.TabStop = false;
			this.btnEsclusioneCIG.Tag = "choose.dalia_recruitmentmotive.default";
			this.btnEsclusioneCIG.Text = "Causale";
			this.btnEsclusioneCIG.UseVisualStyleBackColor = true;
			// 
			// txtVoceSpesaDalia
			// 
			this.txtVoceSpesaDalia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVoceSpesaDalia.Location = new System.Drawing.Point(206, 129);
			this.txtVoceSpesaDalia.Name = "txtVoceSpesaDalia";
			this.txtVoceSpesaDalia.ReadOnly = true;
			this.txtVoceSpesaDalia.Size = new System.Drawing.Size(609, 20);
			this.txtVoceSpesaDalia.TabIndex = 112;
			// 
			// btnVoceSpesaDalia
			// 
			this.btnVoceSpesaDalia.Location = new System.Drawing.Point(27, 126);
			this.btnVoceSpesaDalia.Name = "btnVoceSpesaDalia";
			this.btnVoceSpesaDalia.Size = new System.Drawing.Size(166, 23);
			this.btnVoceSpesaDalia.TabIndex = 30;
			this.btnVoceSpesaDalia.Text = "Seleziona Voce di spesa Dalia";
			this.btnVoceSpesaDalia.UseVisualStyleBackColor = true;
			this.btnVoceSpesaDalia.Click += new System.EventHandler(this.btnVoceSpesaDalia_Click);
			// 
			// groupBox18
			// 
			this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox18.Controls.Add(this.label91);
			this.groupBox18.Controls.Add(this.btnQualificaDalia);
			this.groupBox18.Controls.Add(this.textBox11);
			this.groupBox18.Controls.Add(this.cmb_dalia_position);
			this.groupBox18.Location = new System.Drawing.Point(21, 23);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(811, 80);
			this.groupBox18.TabIndex = 110;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Banca Dati DALIA";
			// 
			// label91
			// 
			this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(678, 26);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(118, 13);
			this.label91.TabIndex = 110;
			this.label91.Text = "Codice Qualifica DALIA";
			// 
			// btnQualificaDalia
			// 
			this.btnQualificaDalia.Location = new System.Drawing.Point(56, 38);
			this.btnQualificaDalia.Name = "btnQualificaDalia";
			this.btnQualificaDalia.Size = new System.Drawing.Size(116, 23);
			this.btnQualificaDalia.TabIndex = 113;
			this.btnQualificaDalia.Text = "Qualifica Dalia";
			this.btnQualificaDalia.UseVisualStyleBackColor = true;
			this.btnQualificaDalia.Click += new System.EventHandler(this.btnQualificaDalia_Click);
			// 
			// textBox11
			// 
			this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox11.Location = new System.Drawing.Point(678, 42);
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(116, 20);
			this.textBox11.TabIndex = 109;
			this.textBox11.Tag = "dalia_position.codedaliaposition";
			// 
			// cmb_dalia_position
			// 
			this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_dalia_position.DataSource = this.DS.dalia_position;
			this.cmb_dalia_position.DisplayMember = "description";
			this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dalia_position.Location = new System.Drawing.Point(185, 40);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(470, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "parasubcontract.iddaliaposition";
			this.cmb_dalia_position.ValueMember = "iddaliaposition";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// dataGrid3
			// 
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(0, 0);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.Size = new System.Drawing.Size(130, 80);
			this.dataGrid3.TabIndex = 0;
			// 
			// myTip
			// 
			this.myTip.AutomaticDelay = 30;
			this.myTip.AutoPopDelay = 30000;
			this.myTip.InitialDelay = 30;
			this.myTip.ReshowDelay = 6;
			// 
			// Frm_parasubcontract_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(883, 560);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_parasubcontract_default";
			this.Text = "frmcontratto";
			this.tabGenerale.ResumeLayout(false);
			this.tabGenerale.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.groupBox24.ResumeLayout(false);
			this.groupBox24.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.grpDettagliPrevidenzialiAssistenziali.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpDettagliFiscali.ResumeLayout(false);
			this.grpPrestazione.ResumeLayout(false);
			this.grpPercipiente.ResumeLayout(false);
			this.grpPercipiente.PerformLayout();
			this.grpContratto.ResumeLayout(false);
			this.grpContratto.PerformLayout();
			this.grpComune.ResumeLayout(false);
			this.grpComune.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabImponibili.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			this.groupBox17.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.grpNoTaxArea.ResumeLayout(false);
			this.grpAliquoteIrpef.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.tabFamiliare.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid8)).EndInit();
			this.tabAltreCollINAIL.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid10)).EndInit();
			this.tabOneri.ResumeLayout(false);
			this.tabOneri.PerformLayout();
			this.groupBox15.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.groupBox16.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabCUD.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrid_DetCud)).EndInit();
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrid_DedCud)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrid_CUD)).EndInit();
			this.tabAddizionali.ResumeLayout(false);
			this.grpAccontoAddCom.ResumeLayout(false);
			this.grpAccontoAddCom.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid11)).EndInit();
			this.grpAddizionaliPassate.ResumeLayout(false);
			this.grpAddizionaliPassate.PerformLayout();
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			this.groupBox21.ResumeLayout(false);
			this.groupBox21.PerformLayout();
			this.tabCedolini.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCedoliniAltriEsercizi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCedolini)).EndInit();
			this.tabErogazioni.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabDatiRiepilogativi.ResumeLayout(false);
			this.tabDatiRiepilogativi.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRitenute)).EndInit();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.TabClassSuppl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).EndInit();
			this.tabEconoPatr.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabFinanziario.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.tabAnalitico.ResumeLayout(false);
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.tabEP.ResumeLayout(false);
			this.tabEP.PerformLayout();
			this.grpBoxSiopeEP.ResumeLayout(false);
			this.grpBoxSiopeEP.PerformLayout();
			this.gBoxCausaleDebitoCrg.ResumeLayout(false);
			this.gBoxCausaleDebitoCrg.PerformLayout();
			this.gBoxCausaleDebito.ResumeLayout(false);
			this.gBoxCausaleDebito.PerformLayout();
			this.gBoxCausaleCosto.ResumeLayout(false);
			this.gBoxCausaleCosto.PerformLayout();
			this.tabAttributi.ResumeLayout(false);
			this.gboxclass05.ResumeLayout(false);
			this.gboxclass05.PerformLayout();
			this.gboxclass04.ResumeLayout(false);
			this.gboxclass04.PerformLayout();
			this.gboxclass03.ResumeLayout(false);
			this.gboxclass03.PerformLayout();
			this.gboxclass02.ResumeLayout(false);
			this.gboxclass02.PerformLayout();
			this.gboxclass01.ResumeLayout(false);
			this.gboxclass01.PerformLayout();
			this.tabAP.ResumeLayout(false);
			this.tabDALIA.ResumeLayout(false);
			this.tabDALIA.PerformLayout();
			this.groupBox22.ResumeLayout(false);
			this.gboxDipartimento.ResumeLayout(false);
			this.gboxDipartimento.PerformLayout();
			this.grpCausaliAssunzioneDalia.ResumeLayout(false);
			this.grpCausaliAssunzioneDalia.PerformLayout();
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private void txtDataInizio_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            calcolaDurataContratto();
            GeneraSelect(sender);
        }

        private void txtDataFine_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone)
                return;
            if (Meta.IsEmpty)
                return;
            calcolaDurataContratto();
            GeneraSelect(sender);

            //DateTime fineContratto = DateTime.MaxValue;
            //object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            //if (fine is DateTime) {
            //    fineContratto = (DateTime)fine;
            //}
            //if (fineContratto == DateTime.MaxValue)
            //    return;
            //object idComuneAddRegionale = null;
            //int idreg = CfgFn.GetNoNullInt32(DS.parasubcontract.Rows[0]["idreg"]);
            //if (ultimoDellAnno < fineContratto) {
            //    idComuneAddRegionale = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, ultimoDellAnno);
            //}
            //else {
            //    idComuneAddRegionale = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, fineContratto);
            //}
            //txtComuneAddRegionali.Text = ricavaDenominazioneComune(idComuneAddRegionale);
            //aggiornaComuneResidenza(idComuneAddRegionale);
            //object idser = DS.parasubcontract.Rows[0]["idser"];
            //if (idser == DBNull.Value || CfgFn.GetNoNullInt32(idser) == 0)
            //    return;

            //DataTable TGeo = CalcoliCococo.verificaAddizionaliPrestazione(Conn, idser, "R");
            //if ((TGeo != null) && (TGeo.Rows.Count > 0) && (idreg != 0)) {
            //    if ((idComuneAddRegionale == DBNull.Value) || (idComuneAddRegionale == null)) {
            //        MessageBox.Show(this, "In riferimento all'applicazione delle addizionali regionali non esiste per il percipiente "
            //        + "\nun domicilio fiscale o un indirizzo di residenza valido al " + ultimoDellAnno.ToShortDateString()
            //        + "\no alla data di fine contratto. ");
            //    }
            //}
        }

        /// <summary>
        /// Mostra/nasconde il gbox mesicompetenza in base alla data inizio del contratto ed alla datafine.
        ///  Calcola anche il testo dei radiobutton di data inizio e fine
        /// </summary>
        void calcolaDurataContratto() {
            object inizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text,
                txtDataInizio.Tag.ToString());
            object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            if ((inizio is DateTime) && (fine is DateTime)) {
                DateTime dataInizio = (DateTime) inizio;
                DateTime dataFine = (DateTime) fine;
                int nmesi = (dataFine.Year - dataInizio.Year)*12 +
                            dataFine.Month - dataInizio.Month + 1;
                txtDurataMesi.Text = nmesi.ToString();
            }
        }

        public void MetaData_AfterGetFormFata() {
            Meta.myHelpForm.addExtraEntity("parasubcontractyear");
        }

        private void AbilitaCUD(bool enable) {
            inserisci_CUD.Enabled = enable;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            btnSituazione.Enabled = !Meta.InsertMode;
			switch (T.TableName) {
				case "registry": {
						bool scegliDalia = false;
						GeneraSelect(txtPercipiente);
						int idreg = 0;
						object idaccmotivedebit=null;
						if (R != null) {
							idreg = CfgFn.GetNoNullInt32(R["idreg"]);
							idaccmotivedebit = R["idaccmotivedebit"];
						}

						if (!Meta.IsEmpty) {
							DataRow Curr = DS.parasubcontract.Rows[0];
							DataRow rService = Curr.GetParentRow("serviceparasubcontract");
							if ((rService != null) && (rService["certificatekind"].ToString().ToUpper() == "U")) {
								generaCudDaAltriContratti();//genera un freshForm
							} else {
								cancellaCud();
							}

							if (Meta.DrawStateIsDone && R != null) {
								Curr["idaccmotivedebit"] = idaccmotivedebit;
								DS.accmotiveapplied_debit.Clear();
								Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
									(q.eq("idaccmotive", Curr["idaccmotivedebit"]) & q.eq("idepoperation", "cococo_deb")).toSql(QHS), null, false);
								Meta.helpForm.FillControls(gBoxCausaleDebito.Controls);

							}


						}
						if (R == null) {
							txtComuneAddComunali.Text = null;
							txtComuneAddRegionali.Text = null;
							txtComuneAddComRata.Text = null;
							txtComuneAddRegRata.Text = null;
							return;
						}

						//Verifica che la residenza del cred/deb sia coerente con quella del contratto

						if (!Meta.IsEmpty) {
							if (DaliaAbilitato && Meta.DrawStateIsDone) {
								scegliDalia = true;
							}

							object idComuneAddizionale = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
							string denomComuneAddizionale = ricavaDenominazioneComune(idComuneAddizionale);
							txtComuneAddComunali.Text = denomComuneAddizionale;

							object idComuneAddizionaleRata = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnnoPrec);
							string denomComuneAddizionaleRata = ricavaDenominazioneComune(idComuneAddizionaleRata);
							txtComuneAddComRata.Text = denomComuneAddizionaleRata;
							object idser = DS.parasubcontract.Rows[0]["idser"];

							if (idser != DBNull.Value) {
								DataTable TCom = CalcoliCococo.verificaAddizionaliPrestazione(Conn, idser, "C");
								if ((TCom != null) && (TCom.Rows.Count > 0)) {
									if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
										MessageBox.Show(this,
											"In riferimento all'applicazione delle addizionali comunali non esiste per il percipiente "
											+ "\nun domicilio fiscale o un indirizzo di residenza valido al " +
											primoDellAnno.ToShortDateString());
									}
								}
							}


							txtComuneAddRegRata.Text = denomComuneAddizionaleRata;

							txtComuneAddRegionali.Text = denomComuneAddizionale;
							aggiornaComuneResidenza(idComuneAddizionale);

							if (idser != DBNull.Value) {
								DataTable TGeo = CalcoliCococo.verificaAddizionaliPrestazione(Conn, idser, "R");
								if ((TGeo != null) && (TGeo.Rows.Count > 0)) {
									if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
										MessageBox.Show(this,
											"In riferimento all'applicazione delle addizionali regionali non esiste per il percipiente "
											+ "\nun domicilio fiscale o un indirizzo di residenza valido al " +
											primoDellAnno.ToShortDateString()
											+ "\no alla data di fine contratto. ");
									}
								}

							}
						}
						if (scegliDalia) {
							selezionaQualificaDalia(true);
						}
						return;
					}

				case "exhibitedcud": {
						EnableDisableBtnCUDdeduzionidetrazioni();
						break;
					}

				case "payroll": {
						//Abilita/disabilita i bottoni calcola/visualizza cedolino in base al flagcompleto e 
						// alla data erogazione. Si può visualizzare solo un cedolino calcolato,
						// e si può calcolare solo il primo cedolino non calcolato
						if (R != null) {
							object idCedolino = R["idpayroll"];
							string flagCalcolato = R["flagcomputed"].ToString().ToUpper();
							btnVisualizzaCedolino.Enabled = flagCalcolato == "S";

							//Cedolini non calcolati
							DataRow[] rCedoliniNonCalcolati = DS.payroll.Select(
							QHC.CmpEq("flagcomputed", "N"),
							"fiscalyear asc, npayroll asc");

							//Calcolo cedolino abilitato se:
							// ci sono cedolini non calcolati ed il primo è quello selezionato
							btnCalcolaCedolino.Enabled =
								(rCedoliniNonCalcolati.Length != 0)
								&& (idCedolino.Equals(rCedoliniNonCalcolati[0]["idpayroll"]));
						} else {
							btnCalcolaCedolino.Enabled = false;
							btnVisualizzaCedolino.Enabled = false;
						}
						break;
					}
				case "sortingview1": {
						if (R == null) return;
						if (Meta.IsEmpty) return;
						if (!Meta.DrawStateIsDone) return;
						Meta.GetFormData(true);
						selezionaVoceSpesaDalia(R["idsor"]);
						return;
					}

				case "service": {
						abilitaDisabilitaDalia(R);
						abilitaDisabilitaCCdedicato(R);
						if ((!Meta.IsEmpty) && (R != null) && (DS.parasubcontract.Select().Length > 0) &&
							(!verificaPrestazioneStranieri())) {
							int idreg = CfgFn.GetNoNullInt32(DS.parasubcontract.Rows[0]["idreg"]);
							if (idreg != 0) {
								var idComuneAddRegionale = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
								aggiornaComuneResidenza(idComuneAddRegionale);
							}
						}

						if (R != null) {
							abilitaCmbAltreFormeAssicurative(R["idser"]);
							abilitaChiudiContratto(R["idser"]);
							abilitaCmbTipoRapporto(R["idser"]);
							abilitaCmbPat(R["idser"]);
							// Ricalcola l'imponibile dei CUD nel caso sia cambiato
							if (Meta.DrawStateIsDone && !Meta.FirstFillForThisRow && !Meta.IsEmpty) {
								decimal totImponibileCud = calcolaSommaImponibileCud();
								totImponibileCud += calcolaImponibileFiscalePresuntoAnnuo();
								object currPrestazione = R["idser"];
								if ((lastTotImponibileCud != totImponibileCud) &&
									(!lastPrestazione.Equals(currPrestazione))) {
									Meta.GetFormData(true);
									bool aliquotaImpostata = impostaAliquotaFiscaleMarginale();
									if (aliquotaImpostata) {
										lastTotImponibileCud = totImponibileCud;
									}
								}
							}

							lastPrestazione = R["idser"];
						} else {
							lastPrestazione = DBNull.Value;
							abilitaCmbTipoRapporto(null);
							abilitaCmbPat(null);
							abilitaCmbAltreFormeAssicurative(null);
							abilitaCmbAttivitaPrevINPS(null);
						}

						if (Meta.DrawStateIsDone) {
							if (!Meta.IsEmpty) {
								Meta.GetFormData(true);
							}

							gestisciFlagDetrazioni(R);
							ricalcoloEventualeDelCostoTotale();
							gestisciSubEntity_cmbAliquotaIRPEF(true);
						}

						if ((R != null) && (R["certificatekind"].ToString() == "U")) {
							generaCudDaAltriContratti();
							AbilitaCUD(true);
						} else {
							cancellaCud();
							AbilitaCUD(false);
						}

						break;
					}

				case "emenscontractkind": {
						if (Meta.InsertMode || Meta.EditMode) {
							DS.parasubcontractyear.Rows[0]["idemenscontractkind"] = (R == null)
								? DBNull.Value
								: R["idemenscontractkind"];
						}
						if (R == null) {
							if (Meta.InsertMode || Meta.EditMode) {
								btnAttivitaPrevINPS.Enabled = false;
								cmbAttPrevidenzialeINPS.Enabled = false;
								cmbAttPrevidenzialeINPS.SelectedIndex = -1;
							} else {
								btnAttivitaPrevINPS.Enabled = true;
								cmbAttPrevidenzialeINPS.Enabled = true;
							}
							return;
						}

						if (!Meta.FirstFillForThisRow) {
							bool datoSelezionatoNonValido = (R["module"] == DBNull.Value)
														||
														(R["module"].ToString()
															.IndexOf("C", 0, R["module"].ToString().Length) == -1);
							if (datoSelezionatoNonValido && !Meta.IsEmpty) {
								DS.parasubcontractyear.Rows[0]["idemenscontractkind"] = DBNull.Value;
							}
						}

						if (R["flagactivityrequested"].ToString() == "S") {
							// Caso 1: Il rapporto ha il flag attività obbligatorio
							// abilito combo e il bottone dell'attività
							btnAttivitaPrevINPS.Enabled = true;
							cmbAttPrevidenzialeINPS.Enabled = true;
						} else {
							// Caso 2: Il rapporto non ha il flag attività obbligatorio
							// solo se non sono in fase di caricamento del form disabilito il combo di sotto
							// e scelgo come elemento del combo quello vuoto
							if (!Meta.FirstFillForThisRow) {
								btnAttivitaPrevINPS.Enabled = false;
								cmbAttPrevidenzialeINPS.Enabled = false;
								cmbAttPrevidenzialeINPS.SelectedIndex = -1;
							}
						}
						break;
					}

				case "inpsactivity": {
						if (Meta.InsertMode || Meta.EditMode) {
							DS.parasubcontractyear.Rows[0]["activitycode"] = (R == null) ? DBNull.Value : R["activitycode"];
						}
						break;
					}

				case "otherinsurance": {
						if (Meta.InsertMode || Meta.EditMode) {
							DS.parasubcontractyear.Rows[0]["idotherinsurance"] = (R == null)
								? DBNull.Value
								: R["idotherinsurance"];
						}
						break;
					}

				case "pat": {
						if (Meta.DrawStateIsDone) {
							if (!verificaCambioNumODenDellImponibile(R)) {
								MessageBox.Show(this, "Poichè si è cambiata la posizione assicurativa territoriale\n"
													  + "prima di salvare occorre reimpostare i compensi\n" +
													  "e ricalcolare i cedolini non ancora erogati. ");
							}
							if (DS.parasubcontract.Rows.Count != 0) {
								DataRow currPara = DS.parasubcontract.Rows[0];
								currPara["idpat"] = (R == null) ? DBNull.Value : R["idpat"];
							}
							ricalcoloEventualeDelCostoTotale();
						}
						break;
					}
				case "accmotiveapplied_cost": {
						SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
						SiopeObj.selectSiope();
						break;
					}
				case "upb": {
						if (Meta.DrawStateIsDone) {
							Meta.GetFormData(true);
							if (R != null) {
								foreach (DataRow Dett in DS.payroll.Rows) {
									if (Dett["disbursementdate"] != DBNull.Value) continue;
									Dett["idupb"] = R["idupb"];
								}
								Meta.FreshForm(tabCedolini.Controls, true,"upb_payroll");
							}
						}
						break;
						}
					}
		
        }
        private bool verificaCambioNumODenDellImponibile(DataRow pat) {
            if (pat == null) return true;
            DataRow[] rCedNonErog = DS.payroll.Select(QHC.IsNull("disbursementdate"));
            foreach (DataRow r in DS.payrolltax.Select(QHC.FieldIn("idpayroll", rCedNonErog))) {
                DataRow[] rRiten = DS.tax.Select(QHC.CmpEq("taxcode", r["taxcode"]));
                DataRow rTax = r.GetParentRow("taxpayrolltax");
                int taxKind = CfgFn.GetNoNullInt32(rTax["taxkind"]);
                if (taxKind == 4) {
                    int taxableNumerator = CfgFn.GetNoNullInt32(r["taxablenumerator"]);
                    int taxableDenominator = CfgFn.GetNoNullInt32(r["taxabledenominator"]);
                    if ((CfgFn.GetNoNullInt32(pat["taxablenumerator"]) != taxableNumerator)
                        || (CfgFn.GetNoNullInt32(pat["taxabledenominator"]) != taxableDenominator))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Abilita/Disabilita i combo altre forme assicurative in base al codice prestazione
        /// </summary>
        /// <param name="codiceprestazione"></param>
        private void abilitaCmbAltreFormeAssicurative(object codiceprestazione) {
            if (Meta.IsEmpty) {
                cmbAltreFormeAssicurative.Enabled = true;
                btnAltreFormeAssicurative.Enabled = true;
                return;
            }
            if (codiceprestazione == null) {
                cmbAltreFormeAssicurative.SelectedIndex = -1;
                btnAltreFormeAssicurative.Enabled = false;
                cmbAltreFormeAssicurative.Enabled = false;
                return;
            }
            string codeser = DS.service.Select(QHC.CmpEq("idser", codiceprestazione))[0]["servicecode770"].ToString();
            if (codeser=="") codeser = DS.service.Select(QHC.CmpEq("idser", codiceprestazione))[0]["codeser"].ToString();
            switch (codeser) {
                case "05_COORDP": //INPS 15%
                    btnAltreFormeAssicurative.Enabled = false;
                    cmbAltreFormeAssicurative.Enabled = false;
                    HelpForm.SetComboBoxValue(cmbAltreFormeAssicurative, "002");
                    break;
                case "05_TUTORM": //INPS 10%
                case "05_COORDM": //INPS 10%
                case "05_ASSRICM": //INPS 10%
                case "10_COSTCONMUT": //CoCoCo stranieri mutuati in convenz con INPS - Vedi task 4729     
                case "16_COORDM_DS": //task 9186  e poi 9206
                case "16_COORDM_AS": //task 9186  e poi 9206
                case "CUST_COORDMCONTR": //Co.co.co. mutuati docenti a contratto task  10436
                case "15_BRS_POSTM": //Borse post-doc mutuati (con solo rit. Inps) 
                case "15_BRS_DOTTM": //Borse dottorato di ricerca mutuati (solo Inps) 
                    btnAltreFormeAssicurative.Enabled = true;
                    cmbAltreFormeAssicurative.Enabled = true;
                    break;
                default: //INPS 18%
                    btnAltreFormeAssicurative.Enabled = false;
                    cmbAltreFormeAssicurative.Enabled = false;
                    cmbAltreFormeAssicurative.SelectedIndex = 0;
                    break;
            }
        }

        private void abilitaCmbAttivitaPrevINPS(object idser) {
            if (Meta.IsEmpty) {
                btnAttivitaPrevINPS.Enabled = true;
                cmbAttPrevidenzialeINPS.Enabled = true;
                return;
            }
            if (idser == null) {
                btnAttivitaPrevINPS.Enabled = false;
                cmbAttPrevidenzialeINPS.Enabled = false;
                cmbAttPrevidenzialeINPS.SelectedIndex = -1;
                return;
            }
        }


        private void abilitaCmbTipoRapporto(object idser) {
            if (Meta.IsEmpty) {
                btnTipoRapporto.Enabled = true;
                cmbTipoRapporto.Enabled = true;
                return;
            }
            if (idser == null) {
                cmbTipoRapporto.SelectedIndex = -1;
                btnTipoRapporto.Enabled = false;
                cmbTipoRapporto.Enabled = false;
                return;
            }
            DataRow[] Service = DS.service.Select(QHC.CmpEq("idser", idser));
            if (Service.Length > 0) {
                string q = "SELECT * FROM servicetax JOIN tax " +
                           "ON servicetax.taxcode = tax.taxcode " +
                           "WHERE " +
                           QHS.AppAnd(QHS.CmpEq("tax.taxkind", 3), QHS.CmpEq("servicetax.idser", Service[0]["idser"]));
                string errmess;
                DataTable ritenute = Conn.SQLRunner(q, -1, out errmess);
                if (ritenute.Rows.Count == 0) {
                    if (Meta.DrawStateIsDone) {
                        cmbTipoRapporto.SelectedIndex = -1;
                    }
                    btnTipoRapporto.Enabled = false;
                    cmbTipoRapporto.Enabled = false;
                }
                else {
                    btnTipoRapporto.Enabled = true;
                    cmbTipoRapporto.Enabled = true;
                }

            }
        }

        private bool abilitaCmbPat(object idser) {
            if (Meta.IsEmpty) {
                btnPAT.Enabled = true;
                cmbPAT.Enabled = true;
                return true;
            }
            if (idser == null) {
                cmbPAT.SelectedIndex = -1;
                btnPAT.Enabled = false;
                cmbPAT.Enabled = false;
                return false;
            }
            DataRow[] Service = DS.service.Select(QHC.CmpEq("idser", idser));
            if (Service.Length > 0) {
                string q = "SELECT * FROM servicetax JOIN tax " +
                           "ON servicetax.taxcode = tax.taxcode " +
                           "WHERE " +
                           QHS.AppAnd(QHS.CmpEq("tax.taxkind", 4), QHS.CmpEq("servicetax.idser", Service[0]["idser"]));
                string errmess;
                DataTable ritenute = Conn.SQLRunner(q, -1, out errmess);
                if (ritenute.Rows.Count == 0) {
                    if (Meta.DrawStateIsDone) {
                        cmbPAT.SelectedIndex = -1;
                    }
                    btnPAT.Enabled = false;
                    cmbPAT.Enabled = false;
                    return false;
                }
                else {
                    btnPAT.Enabled = true;
                    cmbPAT.Enabled = true;
                    return true;
                }

            }
            return true;
        }

        private void abilitaChiudiContratto(object idser) {
            DataRow[] Service = DS.service.Select(QHC.CmpEq("idser", idser));
            if (Service.Length == 0) {
                btnTroncaContratto.Enabled = false;
                return;
            }
            DataRow rService = Service[0];
            string flagNeedBalance = rService["flagneedbalance"].ToString().ToUpper();
            btnTroncaContratto.Enabled = (flagNeedBalance == "N");
        }

        private void gestisciFlagDetrazioni(DataRow rService) {
            if (rService == null) return;
            if (DS.parasubcontractyear.Rows.Count == 0) return;
            object flagApplyAbatements = rService["flagapplyabatements"];
            bool applicaDetrazione = false;
            if (flagApplyAbatements == DBNull.Value) {
                applicaDetrazione = true;
            }
            else {
                applicaDetrazione = (flagApplyAbatements.ToString().ToUpper() == "S");
            }

            DataRow ParSubYear = DS.parasubcontractyear.Rows[0];

            if (applicaDetrazione) {
                SubEntity_rbtnDedBaseIntero.Checked = true;
            }
            else {
                SubEntity_rbtnNonApplicare.Checked = true;
            }

            ParSubYear["notaxappliance"] = (applicaDetrazione) ? "I" : "N";
        }

        /// <summary>
        /// Imposta il combo (valori possibili e valore attuale) delle aliquote in base alla prestazione selezionata. (Effettua un GetFormData())
        /// </summary>
        private void gestisciSubEntity_cmbAliquotaIRPEF(bool doGetFormData) {
            if (DS.parasubcontract.Rows.Count > 0) {
                if (doGetFormData) {
                    Meta.GetFormData(true);
                }
                DataRow Curr = DS.parasubcontract.Rows[0];
                DataRow CurrImp = DS.parasubcontractyear.Rows[0];
                object codicePrestazione = Curr["idser"];
                bool abilitaCombo = CurrImp["applybrackets"].ToString().ToUpper() == "N";
                SubEntity_cmbAliquotaIRPEF.Enabled = abilitaCombo;
                object irpef = Meta.Conn.DO_READ_VALUE("servicetaxview",
                    QHS.AppAnd(QHS.CmpEq("taxkind", 1), QHS.IsNull("geoappliance"),
                        QHS.CmpEq("idser", codicePrestazione)),
                    "taxcode");
                if (irpef == null) {
                    DS.taxratebracket.Clear();
                    Meta.myHelpForm.FillComboBoxTable(SubEntity_cmbAliquotaIRPEF, true);
                    return;
                }

                object idtaxratestart = Meta.Conn.DO_READ_VALUE("taxratestart",
                    QHS.AppAnd(QHS.CmpEq("taxcode", irpef),
                        QHS.CmpLe("start", Meta.GetSys("datacontabile"))),
                    "max(idtaxratestart)");

                string filter = QHS.AppAnd(QHS.CmpEq("taxcode", irpef), QHS.CmpEq("idtaxratestart", idtaxratestart));
                DS.taxratebracket.Clear();
                GetData.Add_Blank_Row(DS.taxratebracket);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.taxratebracket, null, filter, null, true);
                Meta.myHelpForm.FilteredPreFillCombo(SubEntity_cmbAliquotaIRPEF, filter, false);

                if (Meta.IsEmpty) return;

                setValoreInComboAliquota(DS.parasubcontractyear.Rows[0]["highertax"]);
            }
        }

        private void setValoreInComboAliquota(object valore) {
            if (valore == null)
                return;
            if (SubEntity_cmbAliquotaIRPEF.Items == null)
                return;
            if (SubEntity_cmbAliquotaIRPEF.Items.Count == 0)
                return;
            foreach (DataRowView row in SubEntity_cmbAliquotaIRPEF.Items) {
                if (row == null)
                    continue;
                if (valore.Equals(row["employrate"])) {
                    HelpForm.SetComboBoxValue(SubEntity_cmbAliquotaIRPEF, row["employrate"]);
                    return;
                }
            }

            DataRowView riga = SubEntity_cmbAliquotaIRPEF.Items[0] as DataRowView;
            if (riga == null)
                return;
            HelpForm.SetComboBoxValue(SubEntity_cmbAliquotaIRPEF, riga["employrate"]);
        }


        /// <summary>
        /// Gestione del Tab CUD in base a ultima selezione su cudpresentato: abilitazione/disabilitazione 
        ///		e valori di default per i dettagli deduz/detraz
        /// </summary>
        void EnableDisableBtnCUDdeduzionidetrazioni() {
            if ((Meta.IsEmpty) || (HelpForm.GetLastSelected(DS.exhibitedcud) == null)) {
                btnDeleteDed.Enabled = false;
                btnDeleteDet.Enabled = false;
                btnEditDed.Enabled = false;
                btnEditDet.Enabled = false;
                btnInsertDet.Enabled = false;
                btnInsertDed.Enabled = false;
                return;
            }
            DS.exhibitedcuddeduction.Columns["idexhibitedcud"].DefaultValue =
                HelpForm.GetLastSelected(DS.exhibitedcud)["idexhibitedcud"];
            DS.exhibitedcudabatement.Columns["idexhibitedcud"].DefaultValue =
                HelpForm.GetLastSelected(DS.exhibitedcud)["idexhibitedcud"];
            btnDeleteDed.Enabled = true;
            btnDeleteDet.Enabled = true;
            btnEditDed.Enabled = true;
            btnEditDet.Enabled = true;
            btnInsertDet.Enabled = true;
            btnInsertDed.Enabled = true;
        }

        private void rbAliquotaMarginale_CheckedChanged(object sender, System.EventArgs e) {
            SubEntity_cmbAliquotaIRPEF.Enabled = SubEntity_rbAliquotaMarginale.Checked &&
                                                 (Meta.InsertMode || Meta.EditMode);
            if (!SubEntity_rbAliquotaMarginale.Checked) {
                SubEntity_cmbAliquotaIRPEF.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Calcola i campi imponibilecud e giornicud di imputazionecontratto in base ai cud presentati. Lavora solo sul DataSet
        /// </summary>
        private void calcolaCudPresentati() {
            if (DS.Tables["exhibitedcud"].Rows.Count == 0) {
                if (CfgFn.GetNoNullDecimal(DS.Tables["parasubcontractyear"].Rows[0]) != 0) {
                    DS.Tables["parasubcontractyear"].Rows[0]["taxablecud"] = 0;
                }
                if (CfgFn.GetNoNullDecimal(DS.Tables["parasubcontractyear"].Rows[0]["cuddays"]) != 0) {
                    DS.Tables["parasubcontractyear"].Rows[0]["cuddays"] = 0;
                }
                return;
            }
            string codicecreddeb = QueryCreator.quotedstrvalue(DS.Tables["parasubcontract"].Rows[0]["idreg"], false);
            DataRow[] rCud = DS.Tables["exhibitedcud"].Select(
                QHC.AppAnd(QHC.CmpEq("flagignoreprevcud", "S"), QHC.CmpEq("fiscalyear", esercizio)),
                "idexhibitedcud DESC");

            object idcollaborazione = (rCud.Length == 0) ? (int) 0 : rCud[0]["idexhibitedcud"];

            rCud = DS.Tables["exhibitedcud"].Select(QHC.AppAnd(QHC.CmpEq("fiscalyear", esercizio),
                QHC.CmpGe("idexhibitedcud", idcollaborazione)));

            double imponibile = 0;
            int giorni = 0;
            bool ciSonoModifiche = false;
            foreach (DataRow r1 in rCud) {
                if (r1.RowState != DataRowState.Unchanged) ciSonoModifiche = true;
                imponibile += CfgFn.GetNoNullDouble(r1["taxablepension"]);
                giorni += CfgFn.GetNoNullInt32(r1["ndays"]);
            }
            if (ciSonoModifiche) {
                DS.Tables["parasubcontractyear"].Rows[0]["taxablecud"] = imponibile;
                DS.Tables["parasubcontractyear"].Rows[0]["cuddays"] = giorni;
            }
        }

        private void sommaCudEContratto() {
            DS.Tables["parasubcontractyear"].Rows[0]["taxablepension"] =
                CfgFn.GetNoNullDecimal(DS.Tables["parasubcontractyear"].Rows[0]["taxablecontract"]);
        }

        bool comingFromBtnGeneraCedolini = false;
        private bool insideCalcolaCedolini = false;

		List <DataRow> cedoliniModificati = new  List<DataRow>();
        public void MetaData_BeforePost() {
	        cedoliniModificati.Clear();
            if (DS.parasubcontract.Rows.Count == 0) return;

            if (insideCalcolaCedolini == false) {
	            foreach (var p in DS.payroll.Select()) {
		            if (p.RowState == DataRowState.Modified) {
			            cedoliniModificati.Add(p);
		            }
	            }
            }

            DataRowState contrattoRowState = DS.parasubcontract.Rows[0].RowState;
            if (contrattoRowState == DataRowState.Deleted) {
                object idContratto =
                    QueryCreator.quotedstrvalue(DS.parasubcontract.Rows[0]["idcon", DataRowVersion.Original], true);

                int count = Meta.Conn.RUN_SELECT_COUNT("payroll",
                    QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.IsNotNull("disbursementdate")),
                    true);
                if (count == 0) {//Solo se non ci sono cedolino erogati cancella tutti i cedolini con i loro figli
                    EPM.beforePost();
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payroll, null,
                        QHS.CmpEq("idcon", idContratto), null, true);
                    foreach (DataRow r in DS.payroll.Rows) {
                        cancellaFigliDiCedolino(r);
                        r.Delete();
                    }
                }
                return;
            }

            if (verificaPrestazioneStranieri()) {
                DS.parasubcontractyear.Rows[0]["idresidence"] = DBNull.Value;
            }


            DataRow[] rConguaglio = DS.payroll.Select(QHC.CmpEq("flagbalance", "S"));

            calcolaCudPresentati();
            sommaCudEContratto();

            decimal compensoErogatoAnniPrec = calcolaCompensoErogatoNegliAnniPrecedenti();

            bool sonoCambiatiIDatiInfluenti = ((inputDatiSalvati == null) ||
                                               !inputDatiSalvati.EqualsRicalcolaCedolini(inputPerCalcoloCostoTotale));

            inputDatiSalvati = getInputPerCalcoloCostoTotale(false);

            bool esisteCedolinoDiConguaglio = controllaEsistenzaCedolinoDiConguaglio();

            bool partiConCompensiAttuali = !sonoCambiatiIDatiInfluenti && Meta.EditMode && esisteCedolinoDiConguaglio;

            bool mostraFormGenerazioneCedolini = !partiConCompensiAttuali || comingFromBtnGeneraCedolini;

            if ((mostraFormGenerazioneCedolini) && (Meta.EditMode)) {
                //Prende dal db i cedolini aventi anno fiscale di anni successivi ma non quelli erogati
                string filtro = QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),QHS.IsNull("disbursementdate"),
                    QHS.CmpGt("fiscalyear", esercizio));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payroll, null, filtro, null, true);
                DataRow[] rCedTrasf = DS.payroll.Select(filtro);
                //Cancella i cedolini degli anni successivi
                foreach (DataRow r in rCedTrasf) {
                    r.Delete();
                }
                //Se ci sono cedolini di anni successivi non parte con i compensi attuali 
                if (rCedTrasf.Length > 0) {
                    partiConCompensiAttuali = false;
                }
                azzeraDetrazioneFamiliari();
            }

            if (mostraFormGenerazioneCedolini) {
                string filtroCedoliniErogati = QHS.AppAnd(
                    QHS.CmpEq("flagbalance", "N"),                      
                    QHS.DoPar(QHS.AppOr(QHS.IsNotNull("disbursementdate"), QHS.CmpLt("fiscalyear", esercizio))),
                    QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]));
                DataTable tCedoliniErogati = (Meta.EditMode)
                    ? DataAccess.RUN_SELECT(Meta.Conn, "payroll", null, "fiscalyear, npayroll",
                        filtroCedoliniErogati, null, null, true)
                    : new DataTable();
                DataRow[] rCedoliniErogati = tCedoliniErogati.Select();

                FrmGenerazioneCedolini frmGenCed = new FrmGenerazioneCedolini(
                    Meta, MetaData.GetMetaData(this, "payroll"), DS,
                    partiConCompensiAttuali,
                    (decimal) DS.parasubcontract.Rows[0]["grossamount"],
                    (DateTime) DS.parasubcontract.Rows[0]["start"],
                    (DateTime) DS.parasubcontract.Rows[0]["stop"],
					DS.parasubcontract.Rows[0]["idupb"],
					rCedoliniErogati
                    );

                DialogResult dr = frmGenCed.ShowDialog();

                comingFromBtnGeneraCedolini = false;

                string filtroCedolini = QHC.AppAnd(
                    QHC.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                    QHC.CmpEq("fiscalyear", esercizio), QHC.CmpEq("flagbalance", "S"));
                DataRow[] rCed = DS.payroll.Select(filtroCedolini);
                if (rCed.Length != 0) {
                    DateTime dataInizio_PrimoCedolinoAnnoFiscale = (DateTime) rCed[0]["start"];
                    DateTime dataFine_UltimoCedolinoAnnoFiscale = (DateTime) rCed[0]["stop"];

                    DS.Tables["parasubcontractyear"].Rows[0]["startcompetency"] = dataInizio_PrimoCedolinoAnnoFiscale;
                    DS.Tables["parasubcontractyear"].Rows[0]["stopcompetency"] = dataFine_UltimoCedolinoAnnoFiscale;
                    DS.Tables["parasubcontractyear"].Rows[0]["ndays"] = 1 +
                                                                        (dataFine_UltimoCedolinoAnnoFiscale -
                                                                         dataInizio_PrimoCedolinoAnnoFiscale).Days;
                    DS.Tables["parasubcontractyear"].Rows[0]["taxablecontract"] = rCed[0]["feegross"];
                }
                sommaCudEContratto();
            }
        }

        void AvvisoAnagrafePrestazioni() {
            if (!Meta.EditMode) return;
            //if (!Meta.FirstFillForThisRow) return;
            if (Meta.Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("yservreg", Meta.GetSys("esercizio")), false) ==
                0) return;
            //VisualizzaEtichetteAP();
            if (btnGeneraAP.Visible) {
                MessageBox.Show("Ricordarsi di compilare la scheda Anagrafe prestazioni");
            }
        }



        public void MetaData_AfterPost() {
            EPM.afterPost();

            foreach (var p in cedoliniModificati) {
	            if (p.RowState == DataRowState.Detached) continue;
	            EPM_payroll.setForcedCurrentRow(p);
				EPM_payroll.afterPost();
            }
            cedoliniModificati.Clear();
            if (Meta.PrimaryDataTable.Rows.Count > 0) {
                VisualizzaEtichetteAP();
                AvvisoAnagrafePrestazioni();
            }
        }

        /// <summary>
        /// Metodo che calcola i compensi erogati negli anni precedenti
        /// </summary>
        /// <returns>Totale dei compensi erogati</returns>
        private decimal calcolaCompensoErogatoNegliAnniPrecedenti() {
            if (Meta.EditMode) {
                object compensoErogato = Meta.Conn.DO_READ_VALUE("payroll",
                    QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                        QHS.CmpLt("fiscalyear", esercizio), QHS.CmpEq("flagbalance", "N")),
                    "sum(feegross)");
                if (!(compensoErogato is DBNull)) {
                    return (decimal) compensoErogato;
                }
                else {
                    return 0;
                }
            }
            return 0;
        }

        private void cancellaFigliDiCedolino(DataRow rCedolino) {
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltax")) {
                foreach (DataRow r2 in r.GetChildRows("payrolltaxpayrolltaxbracket")) {
                    r2.Delete();
                }
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrollabatement")) {
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolldeduction")) {
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltaxcorrige")) {
                r.Delete();
            }
        }

        private void azzeraDetrazioneFamiliari() {
            foreach (DataRow rFamiliare in DS.parasubcontractfamily.Select()) {
                rFamiliare["amount"] = DBNull.Value;
                rFamiliare["childasparent"] = DBNull.Value;
            }
        }

        private bool controllaEsistenzaCedolinoDiConguaglio() {
            string filtroConguaglio =
                QHC.AppAnd(QHC.CmpEq("flagbalance", "S"), QHC.CmpEq("fiscalyear", esercizio),
                    QHC.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]));
            DataRow[] rCedolinoConguaglio = DS.payroll.Select(filtroConguaglio);
            return (rCedolinoConguaglio.Length != 0) ? true : false;
        }

        private void btnCalcolaCedolino_Click(object sender, System.EventArgs e) {

            if (!Meta.GetFormData(false)) {
                MessageBox.Show(this, "E' necessario salvare per usare questa funzionalità");
                return;
            }

            if (Meta.IsEmpty)
                return;
            if (Meta.InsertMode)
                return;

            PostData.RemoveFalseUpdates(DS);
            if (inputDatiSalvati != null && !inputDatiSalvati.EqualsRicalcolaCedolini(inputPerCalcoloCostoTotale)) {
                string messaggio = "Sono stati modificati dei dati presenti nel contratto che sono influenti al calcolo del cedolino"
                                   + "\nPer calcolare un cedolino occorre prima salvare il contratto!";
                MessageBox.Show(this, messaggio);
                return;
            }

            bool esisteIlCedolinoDiConguaglio = controllaEsistenzaCedolinoDiConguaglio();
            if (!esisteIlCedolinoDiConguaglio) {
                string messaggio = "Il cedolino non può essere calcolato in quanto non esiste il cedolino di conguaglio per l'anno in corso."
                                   +
                                   "\nPer creare il cedolino di conguaglio si prega di cliccare sul bottone Reimposta Compensi";
                MessageBox.Show(this, messaggio, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow rCedolino = HelpForm.GetLastSelected(DS.payroll);
            if (rCedolino == null) return;
            int idCedolino = (int) rCedolino["idpayroll"];
            string flagCalcolato = rCedolino["flagcomputed"].ToString();
            int rigaGridCedolino = dgCedolini.CurrentRowIndex;
            if (flagCalcolato == "S") {
                DialogResult dr = MessageBox.Show(this,
                    "Si desidera calcolare nuovamente il cedolino cancellando tutti i dati esistenti?",
                    "Richiesta conferma", MessageBoxButtons.YesNoCancel);

                if (dr == DialogResult.Cancel) return;

                if (dr == DialogResult.No) {
                    MetaData.Edit_Grid(dgCedolini, "default");
                    return;
                }
                cancellaFigliDiCedolino(rCedolino);
            }
            string errMess = null;
            int idCedolinoConguaglio;

            EP_Manager epManagerCedolino = EPM_payroll;
           
            Meta_EasyDispatcher d = null;
            Easy_DataAccess newConn = null;
            MetaData metaParasub = null;
            int annostop = esercizio;
            if (rCedolino["stop"] != DBNull.Value ) {
                annostop = ((DateTime)rCedolino["stop"]).Year;
            }
            int annoContratto = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("parasubcontract",QHS.CmpEq("idcon",rCedolino["idcon"]),"ycon"));
            if (annostop < annoContratto) annostop = annoContratto;
            object flag = Conn.DO_READ_VALUE("accountingyear", QHS.CmpEq("ayear", annostop), "flag");
            bool annoStopAperto = flag != null && flag != DBNull.Value && ((CfgFn.GetNoNullInt32(flag) & 32) == 0);

            bool erroriep = false;
            
            if (EPM != null && (annostop < esercizio & (EPM.UsaImpegniDiBudget|| EPM.UsaScritture) && annoStopAperto)) {
                //Genera impegni e scritture nell'anno di competenza del cedolino
                newConn = ottieniConnessioneNuovoEsercizio(Conn, annostop);
                if (newConn == null) {
                    MessageBox.Show("Ci sono problemi nell'accedere all'anno " + annostop + 
                        ", non saranno generati impegni di budget o scritture", "Errore");
                    erroriep = true;
                }
                else {
                    d = new Meta_EasyDispatcher(newConn);
                    metaParasub = d.Get("parasubcontract");
                    metaParasub.DS = Meta.DS;
                    metaParasub.linkedForm = this;
                    epManagerCedolino = new EP_Manager(metaParasub, null, null, null, null, null, null, null, null, "payroll");
                }
            }
            bool ultimoCedolino = controllaSeUltimoCedolinoAnnoFiscale(idCedolino, out idCedolinoConguaglio);
            if (ultimoCedolino) {
                // 1. Calcola Ritenute non Fiscali del Cedolino Rata
                CalcoliCococo coc = new CalcoliCococo(Meta.Dispatcher, Meta.Conn, DS);
                errMess = coc.calcolaCedolino(idCedolino, true, "N");
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolino + ".\n" + errMess);
                    return;
                }
                // 2. Calcola Ritenute Fiscali del Cedolino di Conguaglio
                errMess = coc.calcolaCedolino(idCedolinoConguaglio, true, "F");
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolinoConguaglio + ".\n" + errMess);
                    return;
                }
                // 3. Aggiungi Ritenute non Fiscali al Cedolino di Conguaglio
                errMess = coc.aggiungiRitenuteNonFiscaliCedolinoConguaglio(idCedolinoConguaglio, true);
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolinoConguaglio + ".\n" + errMess);
                    return;
                }
                // 4. Aggiungi Ritenute Fiscali al Cedolino Rata
                errMess = coc.aggiungiRitenuteFiscaliUltimoCedolinoRata(idCedolino, idCedolinoConguaglio, true);
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolino + ".\n" + errMess);
                    return;
                }
                // 5. Aggiorna Ritenute Fiscali al Cedolino di Conguaglio
                errMess = coc.aggiornaDatiCedolinoConguaglio(idCedolinoConguaglio, true);
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolinoConguaglio + ".\n" + errMess);
                }
                // 6. Salva il Cedolino Rata e il Cedolino di Conguaglio
                Meta.SaveFormData();
                if (DS.HasChanges()) {
                    MessageBox.Show(this, "Attenzione! Si sono verificati errori nel calcolo del cedolino");
                    return;
                }

                DataRow currCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino)).FirstOrDefault();
                if (currCedolino == null) {
	                MessageBox.Show(this, "Attenzione! Si sono verificati errori nel calcolo del cedolino");
	                return;
                }

                if ((erroriep==false) && epManagerCedolino.abilitaScritture(currCedolino)) {
                    epManagerCedolino.setForcedCurrentRow(currCedolino);
                    epManagerCedolino.afterPost();
                }

                // 7. Visualizza il Cedolino Rata
                rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
                Meta.EditDataRow(rCedolino, "default", out rCedolino);
                // 8. Visualizza il Cedolino di Conguaglio
                rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolinoConguaglio))[0];
                Meta.EditDataRow(rCedolino, "default", out rCedolino);
            }
            else {
                CalcoliCococo coc = new CalcoliCococo(Meta.Dispatcher, Meta.Conn, DS);
                // 1. Calcola il Cedolino Rata
                errMess = coc.calcolaCedolino(idCedolino, true, "T");
                if (errMess != null) {
                    MessageBox.Show(this, "Errore nel calcolo del cedolino n° " + idCedolino + ".\n" + errMess);
                    return;
                }
                // 2. Salva il Cedolino Rata
                insideCalcolaCedolini = true; //inibisce ulteriori generazioni di impegni o scritture annidati
                Meta.SaveFormData();
                insideCalcolaCedolini = false;
                if (DS.HasChanges()) {
					DS.RejectChanges();
                    MessageBox.Show(this, "Attenzione! Si sono verificati errori nel calcolo del cedolino, le modifiche sono state annullate");
                    return;
                }
                DataRow currCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
                if ((erroriep == false) && epManagerCedolino.abilitaScritture(currCedolino)) {
                    epManagerCedolino.setForcedCurrentRow(currCedolino);
                    epManagerCedolino.afterPost();
                }
                // 3. Visualizza il Cedolino Rata
                rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
                Meta.EditDataRow(rCedolino, "default", out rCedolino);
            }
            if (newConn != null) {
                newConn.Destroy();
                metaParasub.Destroy();
                epManagerCedolino.Dispose();
            }
            dgCedolini.Select(rigaGridCedolino);
            dgCedolini.CurrentRowIndex = rigaGridCedolino;
            riempiDatiRiepilogativi();
        }

        public bool DatiValidi(DataAccess Conn, int esercizio) {
            DataTable EsercizioTable =
                Conn.RUN_SELECT("accountingyear", "*", null, QHS.CmpEq("ayear", esercizio), null, true);

            if (EsercizioTable.Rows.Count == 0) {
                MessageBox.Show("L'esercizio " + esercizio + " non è stato creato.");
                return false;
            }
            return true;
        }

        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall,
                filteranno,
                QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno,
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

        Easy_DataAccess ottieniConnessioneNuovoEsercizio(DataAccess Conn,int newEsercizio) {            
            if (!DatiValidi(Conn, newEsercizio)) return null;

            DateTime newDate = new DateTime(newEsercizio, 12, 31);
            if (!CambioDataConsentita(Conn, newDate)) {
                MessageBox.Show("L'utente non ha diritto ad agire nell'esercizio " + newEsercizio, "Errore");
                return null;
            }
            Easy_DataAccess newConn = (Easy_DataAccess)Conn.Duplicate();
            newConn.SetSys("esercizio", newEsercizio);
            newConn.SetSys("datacontabile", newDate);


            newConn.RecalcUserEnvironment(Conn.GetSys("idflowchart"), Conn.GetSys("ndetail"));
            newConn.ReadAllGroupOperations();

            return newConn;
        }

        private bool controllaSeUltimoCedolinoAnnoFiscale(int idCedolino, out int idCedolinoConguaglio) {
            idCedolinoConguaglio = 0;
            string filterCedolino = QHC.CmpEq("idpayroll", idCedolino);
            DataRow rCedolino = DS.payroll.Select(filterCedolino)[0];
            object progressivoCedolino = rCedolino["npayroll"];
            DataRow[] rCed = DS.payroll.Select(QHC.CmpEq("npayroll", progressivoCedolino));
            foreach (DataRow r in rCed) {
                if (r["flagbalance"].ToString().ToUpper() == "S") {
                    idCedolinoConguaglio = (int) r["idpayroll"];
                }
            }
            return (rCed.Length > 1);
        }




        /// <summary>
        /// Metodo che ritorna la parte comune degli idrelated
        /// </summary>
        /// <param name="EpExp"></param>
        /// <returns></returns>
        private object ottieniPrefissoComune(DataTable EpExp) {
            object idrelated = null;
            int lunghezza = 0;
            int min = int.MaxValue;
            foreach (DataRow rEpExp in EpExp.Rows) {
                lunghezza = rEpExp["idrelated"].ToString().Length;
                if (lunghezza <= min) {
                    idrelated = rEpExp["idrelated"];
                    min = lunghezza;
                }
            }
            return idrelated;
        }


        private void riempiDatiRiepilogativi() {
            string queryRitenute = "select 'Codice Ritenuta'= tax.taxref, "
                                   + "Descrizione=description, "
                                   + " Categoria = CASE tax.taxkind "
                                   + " WHEN 1 THEN 'Fiscale' "
                                   + " WHEN 2 THEN 'Assistenziale' "
                                   + " WHEN 3 THEN 'Previdenziale' "
                                   + " WHEN 4 THEN 'Assicurativa' "
                                   + " WHEN 5 THEN 'Arretrati' "
                                   + " WHEN 6 THEN 'Altro' "
                                   + " END, "
                                   + "'Rit. c/Dip' = sum(employtax), 'Rit. c/Ammin' = sum(admintax) "
                                   + "from payrolltax "
                                   + "join tax on payrolltax.taxcode = tax.taxcode "
                                   + "join payroll on payroll.idpayroll = payrolltax.idpayroll "
                                   + "where " +
                                   QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                                       QHS.CmpEq("payroll.flagbalance", "N")) +
                                   " group by tax.taxref, taxkind, description "
                                   + "order by taxkind";
            DataTable tRit = Meta.Conn.SQLRunner(queryRitenute);
            if (tRit != null) {
                new DataSet().Tables.Add(tRit);
            }
            gridRitenute.DataSource = null;
            if (tRit != null) {
                HelpForm.SetDataGrid(gridRitenute, tRit);
            }


            object o = Meta.Conn.DO_READ_VALUE("payroll",
                QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                    QHS.CmpEq("flagbalance", "N"),
                    QHS.CmpEq("flagcomputed", "S")
                    ), "sum(feegross)");

            decimal lordoAlBeneficiario = CfgFn.GetNoNullDecimal(o);

            string query = "SELECT tax.taxkind, employtax = SUM(payrolltax.employtax), admintax = SUM(payrolltax.admintax) "
                           + " FROM payrolltax "
                           + " JOIN tax ON payrolltax.taxcode = tax.taxcode "
                           + " JOIN payroll ON payroll.idpayroll = payrolltax.idpayroll "
                           + " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("payroll.idcon", DS.parasubcontract.Rows[0]["idcon"]),
                               QHS.CmpEq("payroll.flagbalance", "N")) +
                           " GROUP BY tax.taxkind" +
                           " UNION ALL " +
                           " SELECT tax.taxkind, employtax = SUM(payrolltaxcorrige.employamount), " +
                           " admintax = SUM(payrolltaxcorrige.adminamount) " +
                           " FROM payrolltaxcorrige " +
                           " JOIN tax ON payrolltaxcorrige.taxcode = tax.taxcode " +
                           " JOIN payroll ON payroll.idpayroll = payrolltaxcorrige.idpayroll " +
                           " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("payroll.idcon", DS.parasubcontract.Rows[0]["idcon"]),
                               QHS.CmpEq("payroll.flagbalance", "N")) +
                           " GROUP BY tax.taxkind";

            DataTable t = Meta.Conn.SQLRunner(query);
            DataRow[] rPrev = t.Select(QHC.CmpEq("taxkind", 3));
            decimal ritAmmin = 0, ritDip = 0;
            if (rPrev.Length > 0) {
                ritAmmin += CfgFn.GetNoNullDecimal(rPrev[0]["admintax"]);
                ritDip += CfgFn.GetNoNullDecimal(rPrev[0]["employtax"]);
                txtPrevAmm.Text = HelpForm.StringValue(rPrev[0]["admintax"], "x.x");
                txtPrevDip.Text = HelpForm.StringValue(rPrev[0]["employtax"], "x.x");
            }
            DataRow[] rFisc = t.Select(QHC.CmpEq("taxkind", 1));
            if (rFisc.Length > 0) {
                ritAmmin += CfgFn.GetNoNullDecimal(rFisc[0]["admintax"]);
                ritDip += CfgFn.GetNoNullDecimal(rFisc[0]["employtax"]);
                txtFiscAmm.Text = HelpForm.StringValue(rFisc[0]["admintax"], "x.x");
                txtFiscDip.Text = HelpForm.StringValue(rFisc[0]["employtax"], "x.x");
            }
            DataRow[] rAssic = t.Select(QHC.CmpEq("taxkind", 4));
            if (rAssic.Length > 0) {
                ritAmmin += CfgFn.GetNoNullDecimal(rAssic[0]["admintax"]);
                ritDip += CfgFn.GetNoNullDecimal(rAssic[0]["employtax"]);
                txtAssicAmm.Text = HelpForm.StringValue(rAssic[0]["admintax"], "x.x");
                txtAssicDip.Text = HelpForm.StringValue(rAssic[0]["employtax"], "x.x");
            }
            DataRow[] rAssis = t.Select(QHC.CmpEq("taxkind", 2));
            if (rAssis.Length > 0) {
                ritAmmin += CfgFn.GetNoNullDecimal(rAssis[0]["admintax"]);
                ritDip += CfgFn.GetNoNullDecimal(rAssis[0]["employtax"]);
                txtAssisAmm.Text = HelpForm.StringValue(rAssis[0]["admintax"], "x.x");
                txtAssisDip.Text = HelpForm.StringValue(rAssis[0]["employtax"], "x.x");
            }

            txtLordoAlBeneficiarioRiep.Text = lordoAlBeneficiario.ToString("c");

            txtTotaleRitAmmin.Text = ritAmmin.ToString("c");
            txtTotaleRitDip.Text = ritDip.ToString("c");

            txtCostoTotale.Text = (lordoAlBeneficiario + ritAmmin).ToString("c");
            txtCompensoNetto.Text = (lordoAlBeneficiario - ritDip).ToString("c");
        }


        private void btnGeneraCedolini_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.InsertMode) return;

            DataRow Curr = DS.parasubcontract.Rows[0];
            string filtro = QHS.AppAnd(QHS.CmpEq("idcon", Curr["idcon"]), QHS.CmpGt("fiscalyear", esercizio));
            int numCedoliniTrasferiti = Meta.Conn.RUN_SELECT_COUNT("payroll", filtro, true);
            if (numCedoliniTrasferiti > 0) {
                string messaggio = "Per poter reimpostare i compensi verranno cancellati i cedolini che erano stati trasferiti nell'anno successivo"
                                   + "\nProseguire?";
                DialogResult dr = MessageBox.Show(this, messaggio, "Avviso", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (dr != DialogResult.Yes) {
                    comingFromBtnGeneraCedolini = false;
                    return;
                }
            }

            DataTable cedoliniAltriAnni = Conn.RUN_SELECT("payroll", "*", null,
                QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]), QHS.IsNull("disbursementdate"))
                , null, false);
            foreach (DataRow rced in cedoliniAltriAnni.Rows) {
                //verifica se in altri anni non esiste già una scrittura
                int nEntry = Conn.RUN_SELECT_COUNT("entry", QHS.AppAnd(
                    QHS.CmpEq("idrelated", EP_functions.GetIdForDocument(rced)), QHS.CmpNe("yentry", esercizio)
                ), false);
                if (nEntry > 0) {
                    MessageBox.Show(
                        $"Per il cedolino n.{rced["npayroll"]} anno fiscale {rced["fiscalyear"]} esistono scritture in altri anni, non è "
                        + "possibile reimpostare i compensi. Occorre prima pagare tali cedolini.", "Errore");
                    return;
                }
            }
            comingFromBtnGeneraCedolini = true;
            if (Meta.GetFormData(false)) {
                EPM.beforePost();
                Meta.SaveFormData();//Il ricalcolo avviene nel beforePost
                if (DS.HasChanges()) {
                    MessageBox.Show(this, "Errore nel salvataggio si consiglia di chiamare il settore assistenza");
                    Meta.CanSave = false;
                    return;
                }
            }
            riempiDatiRiepilogativi();
            ricalcoloEventualeDelCostoTotale();
        }

        /// <summary>
        /// Metodo che ottiene l'ID Related dei cedolini rata non erogati
        /// </summary>
        /// <returns></returns>
        private ArrayList ottieniIdRelatedCedoliniNonErogati() {
            string filtroCedNonErogati = QHC.AppAnd(QHC.IsNull("disbursementdate"),
                QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio));

            EP_functions EP = new EP_functions(Meta.Dispatcher);
            ArrayList listaRelated = new ArrayList();

            foreach (DataRow rCedolino in DS.payroll.Select(filtroCedNonErogati)) {
                string idrelated = EP_functions.GetIdForDocument(rCedolino);
                listaRelated.Add(idrelated);
            }
            return listaRelated;
        }

        /// <summary>
        /// Metodo che ottiene l'ID Related dei cedolini rata non erogati
        /// </summary>
        /// <returns></returns>
        private ArrayList ottieniIdRelatedBudgetCedoliniNonErogati() {
            string filtroCedNonErogati = QHC.AppAnd(QHC.IsNull("disbursementdate"),
                QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio));

            BudgetFunction BF = new BudgetFunction(Meta.Dispatcher);
            ArrayList elencoRelCedolini = new ArrayList();

            foreach (DataRow rCedolino in DS.payroll.Select(filtroCedNonErogati)) {
                string idrelated = BudgetFunction.GetIdForDocument(rCedolino);
                elencoRelCedolini.Add(idrelated);
            }
            return elencoRelCedolini;
        }

        //bool fromBtnVisualizza = false;

        private void btnVisualizzaCedolino_Click(object sender, System.EventArgs e) {
            VisualizzaCedolino(dgCedolini, "default");
        }


        private void VisualizzaCedolino (DataGrid dg, string edittype) {
            DataTable tCedolino;
            DataRow rCedolino;
            bool ok = Meta.myHelpForm.GetCurrentRow(dg, out tCedolino, out rCedolino);
            if (!ok) return;
            if (rCedolino == null) return;
            Meta.EditDataRow(rCedolino, edittype, out rCedolino);
            //fromBtnVisualizza = true;
            Meta.DoMainCommand("mainrefresh");
        }

        private decimal calcolaContributiAmminNonInail(object codicePrestazione, decimal lordoAlBeneficiario) {
            string query = "select SUM("
                           + "(CASE "
                           + "WHEN maxamount IS NULL OR maxamount >= "
                           + QHS.quote(lordoAlBeneficiario)
                           + " THEN "
                           + QHS.quote(lordoAlBeneficiario)
                           + " ELSE maxamount "
                           + "END - minamount) * "
                           + "CASE WHEN ISNULL(taxabledenominator,0)=0 THEN ISNULL(taxablenumerator,1) "
                           + "ELSE ISNULL(taxablenumerator/taxabledenominator, 1) "
                           + "END * CASE "
                           + "WHEN ISNULL(admindenominator,0)=0 THEN ISNULL(adminnumerator,1) "
                           + "ELSE ISNULL(adminnumerator/admindenominator, 1) "
                           + "END * adminrate) " //,2))) "
                           + "FROM taxratestart "
                           + "join taxratebracket on taxratebracket.taxcode = taxratestart.taxcode "
                           + "and taxratebracket.idtaxratestart = taxratestart.idtaxratestart "
                           + "join servicetax on servicetax.taxcode = taxratebracket.taxcode "
                           + "where adminrate <> 0 "
                           +
                           "and taxratebracket.idtaxratestart = (select max(ar.idtaxratestart) from taxratebracket ar "
                           +
                           " join taxratestart ts on ts.taxcode = ar.taxcode and ts.idtaxratestart = ar.idtaxratestart "
                           + "where taxratebracket.taxcode = ar.taxcode and ts.start <= "
                           + QHS.quote(Meta.GetSys("datacontabile"))
                           + "and isnull(minamount,0) < "
                           + QHS.quote(lordoAlBeneficiario)
                           + " and idser = "
                           + QHS.quote(codicePrestazione)
                           + ")";

            string errMsg;
            DataTable t = Meta.Conn.SQLRunner(query, 0, out errMsg);
            if (errMsg != null) {
                MessageBox.Show(this, errMsg);
                return -1;
            }
            return CfgFn.GetNoNullDecimal(t.Rows[0][0]);
        }

        private void txtStimaCostoTotale_LostFocus(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            object o = HelpForm.GetObjectFromString(typeof(decimal), txtStimaCostoTotale.Text, "x.x");
            decimal costoTotale = CfgFn.GetNoNullDecimal(o);
            txtStimaCostoTotale.Text = costoTotale.ToString("c");

            InputPerCalcoloCostoTotale input = getInputPerCalcoloCostoTotale(true);
            if (input == null) return;
            inputPerCalcoloCostoTotale = input;

            bool calcoloRiuscito;
            decimal lordoAlBeneficiario = CfgFn.RoundValuta(
                daCostoTotaleAlLordoAlBeneficiario(costoTotale, out calcoloRiuscito));
            inputPerCalcoloCostoTotale.lordoAlBeneficiario = lordoAlBeneficiario;
            if (!calcoloRiuscito) {
                decimal newtotale = CfgFn.RoundValuta(calcolaCostoTotale(inputPerCalcoloCostoTotale));
                txtStimaCostoTotale.Text = newtotale.ToString("c");
                MessageBox.Show(this,
                    "Non è stato possibile trovare un lordo al beneficiario a cui corrisponda in modo esatto il costo digitato." +
                    "Il valore è stato pertanto approssimato.", "Avviso");
            }
            txtLordoAlBeneficiario.Text = lordoAlBeneficiario.ToString("c");
        }

        /// <summary>
        /// Metodo che costruisce il filtro sui dati inerenti la generazione di eventuali CUD
        /// </summary>
        /// <returns></returns>
        private InputPerGestioneCud getInputPerGestioneCud() {
            if (DS.parasubcontract.Rows.Count == 0) return null;
            DataRow Curr = DS.parasubcontract.Rows[0];

            // Recupero i dati nel seguente modo:
            // Il codice del percipiente viene ricavato dal DataSet, in quanto quest'ultimo viene sempre
            // aggiornato durante l'evento AfterRowSelect.
            // La data di inizio e di fine vengono presi dai text box in quanto alla loro modifica non corrisponde
            // l'aggiornamento immediato del DataSet.
            if (CfgFn.GetNoNullInt32(Curr["idreg"]) == 0) return null;
            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text,
                txtDataInizio.Tag.ToString());
            if ((dataInizio == null) || (dataInizio == DBNull.Value)) return null;
            object dataFine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text,
                txtDataFine.Tag.ToString());
            if ((dataFine == null) || (dataFine == DBNull.Value)) return null;
            string certificateKind = "?";
            DataRow[] rService = DS.service.Select(QHC.CmpEq("idser", cmbTipoPrestazione.SelectedValue));
            if (rService.Length > 0) {
                certificateKind = rService[0]["certificatekind"].ToString();
            }

            InputPerGestioneCud input = new InputPerGestioneCud();
            input.codCredDeb = (int) Curr["idreg"];
            input.dataInizioContratto = (DateTime) dataInizio;
            input.dataFineContratto = (DateTime) dataFine;
            input.certificateKind = certificateKind;
            return input;
        }

        private InputPerCalcoloCostoTotale getInputPerCalcoloCostoTotale(bool calcoloInverso) {
            object codPrestazione = cmbTipoPrestazione.SelectedValue;
            string filtro = QHS.AppAnd(QHS.CmpEq("idser", codPrestazione), QHS.CmpEq("taxkind", 4));
            object ritenutaAssicurativa = Meta.Conn.DO_READ_VALUE("servicetaxview", filtro, "taxcode");
            if ((ritenutaAssicurativa != null) && (cmbPAT.SelectedIndex <= 0)) return null;
            InputPerCalcoloCostoTotale input = new InputPerCalcoloCostoTotale();
            input.esercizio = esercizio;
            input.codicePrestazione = codPrestazione;
            input.idPat = CfgFn.GetNoNullInt32(cmbPAT.SelectedValue);

            object o = HelpForm.GetObjectFromString(typeof(decimal), txtLordoAlBeneficiario.Text,
                txtLordoAlBeneficiario.Tag.ToString());
            if (o is decimal) {
                input.lordoAlBeneficiario = (decimal) o;
            }
            else {
                //				MessageBox.Show(this, "Inserire il lordo al beneficiario");
                if (calcoloInverso) {
                    //input.lordoAlBeneficiario = 0;
                }
                else {
                    return null;
                }
            }

            if (input.codicePrestazione == DBNull.Value) {
                //				MessageBox.Show(this, "Inserire il tipo di prestazione");
                return null;
            }

            o = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text, txtDataInizio.Tag.ToString());
            if (o is DateTime) {
                input.dataInizioContratto = (DateTime) o;
            }
            else {
                //				MessageBox.Show(this, "Inserire la data di inizio del contratto");
                return null;
            }

            o = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            if (o is DateTime) {
                input.dataFineContratto = DateTime.Parse(txtDataFine.Text);
            }
            else {
                //				MessageBox.Show(this, "Inserire la data di fine del contratto");
                return null;
            }

            //			if (input.idPat==0) {
            //				//				MessageBox.Show(this, "Inserire la Posizione Assicurativa Territoriale");
            //				return null;
            //			}

            return input;
        }

        private decimal calcolaCostoTotale(InputPerCalcoloCostoTotale input) {
            DateTime[] dateInizioCedolini = null;
            DateTime[] dateFineCedolini = null;

            // Nel caso che la data di inizio del contratto sia superiore a quella di fine
            // il costo totale non potrà essere calcolato
            if (input.dataInizioContratto > input.dataFineContratto) {
                return 0;
            }

            // Nel caso che la l'esrcizio della data di inizio/fine del contratto sia diverso dall
            // esercizio del contratto il costo totale non potrà essere calcolato
            if (input.dataInizioContratto > input.dataFineContratto) {
                return 0;
            }
            if (input.dataInizioContratto.Year > esercizio) {
                MessageBox.Show(this,
                    "L'anno della data di inizio del contratto deve essere minore o uguale all'esercizio corrente");
                return 0;
            }
            CalcoliPerLaGenerazione.calcolaDateInizioEFineDeiCedolini(
                input.dataInizioContratto, input.dataFineContratto, 1,
                out dateInizioCedolini, out dateFineCedolini);


            decimal[] stipendi = CalcoliPerLaGenerazione.calcolaStipendiPerTuttoIlContratto
                (dateInizioCedolini, dateFineCedolini, input.lordoAlBeneficiario);

            DataTable tCedoliniErogati = DataAccess.CreateTableByName(Meta.Conn, "payroll", "*");
            if (Meta.EditMode) {
                string filtro = QHS.AppAnd(QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"]),
                    QHS.CmpEq("fiscalyear", esercizio - 1), QHS.CmpEq("flagbalance", "N"));
                tCedoliniErogati = DataAccess.RUN_SELECT(Meta.Conn, "payroll", null,
                    "fiscalyear, npayroll", filtro, null, null, true);
            }

            int primoCedolinoAnno, ultimoCedolinoAnno;
            CalcoliPerLaGenerazione.getPrimoEUltimoCedolinoAnnoFiscale(
                esercizio, tCedoliniErogati.Select(), dateInizioCedolini, dateFineCedolini,
                out primoCedolinoAnno, out ultimoCedolinoAnno);

            decimal inail = 0;
            bool applicoInail = verificaSeApplicareInail(DS.parasubcontract.Rows[0]["idser"]);
            if (applicoInail) {
                if (primoCedolinoAnno == -1) {
                    inail = 0;
                }
                else {
                    decimal sommaStipendiDiQuestAnno = 0;
                    for (int i = primoCedolinoAnno; i <= ultimoCedolinoAnno; i++) {
                        sommaStipendiDiQuestAnno += stipendi[i];
                    }
                    int nMesi = 1 + (input.dataFineContratto.Year - input.dataInizioContratto.Year)*12 +
                                input.dataFineContratto.Month - input.dataInizioContratto.Month;

                    decimal compensoMedioMensile = input.lordoAlBeneficiario/nMesi;

                    inail = calcolaINAIL(dateInizioCedolini[primoCedolinoAnno], dateFineCedolini[ultimoCedolinoAnno],
                        compensoMedioMensile);
                    if (sommaStipendiDiQuestAnno == 0) {
                        inail = 0;
                    }
                    else {
                        inail *= input.lordoAlBeneficiario/sommaStipendiDiQuestAnno;
                    }
                }
            }

            decimal altreRitenute = calcolaContributiAmminNonInail(input.codicePrestazione, input.lordoAlBeneficiario);
            //			Console.WriteLine(inail+" + "+altreRitenute+" = "+(inail+altreRitenute));
            return input.lordoAlBeneficiario + inail + altreRitenute;
        }

        /// <summary>
        /// Metodo che verifica se applicare o meno l'INAIL. Se la prestazione ha associata una ritenuta di tipo assicurativo
        /// allora verrà calcolata l'INAIL altrimenti no.
        /// </summary>
        /// <param name="idser">Prestazione</param>
        /// <returns>TRUE: Applica INAIL; FALSE: Altrimenti</returns>
        private bool verificaSeApplicareInail(object idser) {
            if (CfgFn.GetNoNullInt32(idser) == 0) return false;
            string query = "SELECT COUNT(*) FROM tax JOIN servicetax ON tax.taxcode = servicetax.taxcode "
                           + " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("tax.taxkind", 4), QHS.CmpEq("idser", idser));
            DataTable t = Meta.Conn.SQLRunner(query);
            if ((t == null) || (t.Rows.Count == 0)) return false;
            DataRow r = t.Rows[0];
            int numRit = CfgFn.GetNoNullInt32(r[0]);
            return (numRit > 0);

        }

        /// <summary>
        /// Metodo che calcola il contributo INAIL (carico amministrazione)
        /// </summary>
        /// <param name="dataInizioCompetenza">Data di inizio competenza del contratto</param>
        /// <param name="dataFineCompetenza">Data di fine competenza del contratto</param>
        /// <param name="compensoMedioMensile">Compenso Lordo Mensile</param>
        /// <returns></returns>
        private decimal calcolaINAIL(DateTime dataInizioCompetenza, DateTime dataFineCompetenza,
            decimal compensoMedioMensile) {
            string filtroMinMasImp = QHS.AppAnd(QHS.CmpEq("ayear", dataFineCompetenza.Year),
                QHS.CmpLe("startmonth", dataFineCompetenza.Month), QHS.CmpEq("taxablecode", "ASSICUR"));

            DataTable tMinMasImp = DataAccess.RUN_SELECT(Meta.Conn, "taxableminmax",
                "minimum = minimum/12, maximal = maximal/12", "ayear desc, startmonth desc",
                filtroMinMasImp, "1", null, true);
            decimal imponibileAssicurativo = CalcoliCococo.calcolaImponibileINAIL(DS.parasubcontract.Rows[0]["idcon"],
                dataInizioCompetenza, dataFineCompetenza,
                tMinMasImp, DS.exhibitedcud, DS.otherinail, compensoMedioMensile);

            object idpat = DS.parasubcontract.Rows[0]["idpat"];
            string filtroPat = QHC.CmpEq("idpat", idpat);
            DataRow[] pat = DS.pat.Select(filtroPat);
            if (pat.Length == 0) {
                //MessageBox.Show(this, "Attenzione: deve essere inserita la PAT (Posizione Assicurativa Territoriale)");
                return 0;
            }
            else {
                return CalcoliCococo.calcolaInailAmmin(imponibileAssicurativo, pat[0]);
            }
        }

        #region CUD

        /*		private void inserisciCud(DataTable tContratto) {
			DataRow Curr = DS.parasubcontract.Rows[0];
			foreach(DataRow rContratto in tContratto.Rows) {
				string idContratto = rContratto["idcon"].ToString();
				if (!controllaCedolinoDiConguaglioErogato(idContratto)) {
					continue;
				}
				MetaData metaCud = MetaData.GetMetaData(this,"exhibitedcud");
				metaCud.SetDefaults(DS.exhibitedcud);
				DataRow rCud = metaCud.Get_New_Row(Curr,DS.exhibitedcud);
				DateTime dataInizioCompetenza = (DateTime)rContratto["startcompetency"];
				DateTime dataFineCompetenza = (DateTime)rContratto["stopcompetency"];
				rCud["start"] = dataInizioCompetenza;
				rCud["stop"] = dataFineCompetenza;
				rCud["flagignoreprevcud"] = "N";

				object cf = Meta.Conn.DO_READ_VALUE("license", null, "cf");
				if (cf != null) {
					rCud["cfotherdeputy"] = cf;
				}

				int numeroGiorni = (dataFineCompetenza - dataInizioCompetenza).Days + 1;
				int numeroMesi = 12 * (dataFineCompetenza.Year - dataInizioCompetenza.Year) -
					(dataInizioCompetenza.Month - dataFineCompetenza.Month) + 1;
				rCud["ndays"] = numeroGiorni;
				rCud["nmonths"] = numeroMesi;
				decimal imponibilePrevidenziale = CfgFn.GetNoNullDecimal(rContratto["taxablepension"]);
				rCud["taxablepension"] = imponibilePrevidenziale;
				rCud["taxablegross"] = calcolaImponibileFiscaleLordo(idContratto);

				// devo calcolare la somma delle INPS, addizionali e IRPEF
				decimal contributiTrattenuti;
				decimal contributiDovuti = sommaContributiDovuti(idContratto,out contributiTrattenuti);
				decimal irpefApplicata = sommaRitenutaFiscaleApplicata(idContratto,null);
				decimal addRegApplicata = sommaRitenutaFiscaleApplicata(idContratto,"R");
				decimal addComApplicata = sommaRitenutaFiscaleApplicata(idContratto,"C");
				
				rCud["citytaxapplied"] = addComApplicata;
				rCud["regionaltaxapplied"] = addRegApplicata;
				rCud["irpefapplied"] = irpefApplicata;
				rCud["inpsretained"] = contributiTrattenuti;
				rCud["inpsowed"] = contributiDovuti;

				aggiungiDeduzioni(rCud, idContratto);
				aggiungiDetrazioni(rCud, idContratto);
				// Il modulo COCOCO non gestisce la sospensione dell'IRPEF e delle addizionali quindi i campi
				// irpefsospese, addizcomsospese, addizregsospese non vengono valorizzati
			}
		}*/

        /// <summary>
        /// Metodo che cancella i CUD precedentemente inseriti
        /// </summary>
        private void cancellaCud() {
            if (!Meta.InsertMode) return;
            inputPerGestioneCud = getInputPerGestioneCud();
            if (DS.exhibitedcud.Rows.Count == 0) return;

            DataRow Curr = DS.parasubcontract.Rows[0];
            string filtro = QHC.CmpEq("idcon", Curr["idcon"]);
            foreach (DataRow rCud in DS.exhibitedcud.Select(filtro)) {
                string filtroCud = QHC.AppAnd(filtro, QHC.CmpMulti(rCud, "idexhibitedcud"));
                foreach (DataRow rDettDetrazioneCud in DS.exhibitedcudabatement.Select(filtroCud)) {
                    rDettDetrazioneCud.Delete();
                }
                foreach (DataRow rDettDeduzioneCud in DS.exhibitedcuddeduction.Select(filtroCud)) {
                    rDettDeduzioneCud.Delete();
                }
                rCud.Delete();
            }
            Meta.myHelpForm.FillControl(dgrid_CUD);
            Meta.myHelpForm.FillControl(dgrid_DedCud);
            Meta.myHelpForm.FillControl(dgrid_DetCud);

        }

        private void generaCudDaAltriContratti() {
            if (!Meta.InsertMode) return;
            if (!(cmbTipoPrestazione.SelectedValue is int)) return;
            DataRow[] rService = DS.service.Select(QHC.CmpEq("idser", cmbTipoPrestazione.SelectedValue));
            if ((rService.Length == 0) || (rService[0]["certificatekind"].ToString().ToUpper() != "U")) return;
            InputPerGestioneCud input = getInputPerGestioneCud();
            if (input == null) {
                return;
            }
            if (input.uguale(inputPerGestioneCud)) return;
            inputPerGestioneCud = input;

            // Nel caso in cui sono presenti CUD allora vengono rimossi
            if (DS.exhibitedcud.Rows.Count != 0) {
                cancellaCud();
            }


            //TODO aggiungere il fatto  che quello che collego deve a sua volta essere cud
            string query = "SELECT * FROM parasubcontractlistview " +
                           " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("idreg", input.codCredDeb),
                               QHS.CmpEq("ayear", esercizio), QHS.CmpEq("linked", 'N'), QHS.CmpEq("balanced", 'S'), QHS.CmpEq("transmittedbalance", 'S'));

            DataTable tContratto = Meta.Conn.SQLRunner(query, true, 0);
            //DataTable tContratto = DataAccess.RUN_SELECT(Meta.Conn,"parasubcontractview","*",null,filtro,null,null,false);
            if ((tContratto == null) || (tContratto.Rows.Count == 0)) return;

            string messaggioAggiungi = "Esistono contratti dello stesso percipiente per l'anno " + esercizio
                                       +
                                       ".\nVerranno aggiunti i CUD corrispondenti a tali contratti in questo contratto?"
                                       +
                                       "\nNota Bene: Verrà automaticamente impostata l'aliquota marginale per la ritenuta fiscale";
            MessageBox.Show(this, messaggioAggiungi, "Avviso");
            // Generazione dei CUD
            Meta.GetFormData(true);
            inserisciCud(tContratto);
            QueryCreator.MarkEvent("generaCudDaAltriContratti.FreshForm");
            Meta.FreshForm();
            // E' stata commentata questa chiamata perchè il FreshForm provoca la chiamata all'AfterFill
            // il quale chiama impostaAliquotaFiscaleMarginale(), quindi c'è una ridondanza di operazione 
            // che provoca la visualizzazione del MessageBox infomativo 2 volte consecutive.
            //impostaAliquotaFiscaleMarginale();
        }

        /// <summary>
        /// Metodo che aggiunge le detrazioni ai CUD
        /// </summary>
        /// <param name="rCud">CUD sul quale aggiungere le detrazioni</param>
        /// <param name="idContratto">ID del contratto dal quale recuperare le detrazioni</param>
        private void aggiungiDetrazioni(DataRow rCud, object idContratto) {
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(idContratto, true);
            if (rCedolini.Length == 0) {
                return;
            }
            //Gli oneri detraibili sono presi dagli oneri detraibili del contratto in questione
            //Se sono presenti già altri oneri dello stesso tipo, è chiesto all'utente se si vogliono sommare o sostituire
            string filterdedexp = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataTable OneriDet = DataAccess.RUN_SELECT(Meta.Conn, "abatableexpense", "*", null, filterdedexp, null, null,
                true);

            foreach (DataRow OnDeb in OneriDet.Rows) {
                MetaData metaDetrazioneCud = MetaData.GetMetaData(this, "exhibitedcudabatement");
                metaDetrazioneCud.SetDefaults(DS.exhibitedcudabatement);
                DataRow rDetCud = metaDetrazioneCud.Get_New_Row(rCud, DS.exhibitedcudabatement);
                rDetCud["amount"] = OnDeb["totalamount"];
                rDetCud["idabatement"] = OnDeb["idabatement"];

                //DataRow OnereFound;
                //string filter = QHC.CmpEq("idabatement", OnDeb["idabatement"]);
                //DataRow[] Existent = DS.abatableexpense.Select(filter);
                //if (Existent.Length > 0) {
                //    DataRow Ded = DS.abatementcode.Select(filter)[0];
                //    string msg = "La detrazione " + Ded["description"].ToString() + " è già presente tra gli oneri di questo contratto " +
                //        "per un importo pari a " + CfgFn.GetNoNullDecimal(Existent[0]["totalamount"]).ToString("c") + ".\r\n" +
                //        "In un contratto esistente ne è stata trovata una di importo pari a " +
                //            CfgFn.GetNoNullDecimal(OnDeb["totalamount"]).ToString("c") + ".\r\n" +
                //            "Se si intende sommare le due deduzioni premere Ok altrimenti sarà ignorata la detrazione trovata";
                //    if (MessageBox.Show(this, msg, "Conferma", MessageBoxButtons.OKCancel) != DialogResult.OK) continue;
                //    OnereFound = Existent[0];
                //    OnereFound["totalamount"] = CfgFn.GetNoNullDecimal(OnereFound["totalamount"]) +
                //                                    CfgFn.GetNoNullDecimal(OnDeb["totalamount"]);
                //}
                //else {
                //    MetaData meta_dedexp = MetaData.GetMetaData(this, "abatableexpense");
                //    meta_dedexp.SetDefaults(DS.abatableexpense);
                //    OnereFound = meta_dedexp.Get_New_Row(DS.parasubcontract.Rows[0], DS.abatableexpense);
                //    OnereFound["totalamount"] = OnDeb["totalamount"];
                //    OnereFound["idabatement"] = OnDeb["idabatement"];
                //}
            }

            //Aggiunge le deduzioni dei CUD collegati!!
            DataTable LinkedCud = getCudLinkedToContract(idContratto);

            if (LinkedCud == null || LinkedCud.Rows.Count == 0) {
                Meta.myGetData.GetTemporaryValues(DS.exhibitedcudabatement);
                return;
            }
            string filterlinkedcud = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.FieldIn("idexhibitedcud", LinkedCud.Select()));
            DataTable LinkedDeduction = Meta.Conn.RUN_SELECT("exhibitedcudabatement", "*", null, filterlinkedcud, null,
                false);
            foreach (DataRow OnDeb in LinkedDeduction.Rows) {

                string filter = QHS.AppAnd(QHC.CmpEq("idabatement", OnDeb["idabatement"]),
                    QHC.CmpEq("idexhibitedcud", rCud["idexhibitedcud"]));
                DataRow[] Existent = DS.exhibitedcudabatement.Select(filter);
                if (Existent.Length > 0) {
                    DataRow OnereFound = Existent[0];
                    OnereFound["amount"] = CfgFn.GetNoNullDecimal(OnereFound["amount"]) +
                                           CfgFn.GetNoNullDecimal(OnDeb["amount"]);
                }
                else {
                    MetaData metaDetrazioneCud = MetaData.GetMetaData(this, "exhibitedcudabatement");
                    metaDetrazioneCud.SetDefaults(DS.exhibitedcudabatement);
                    DataRow rDedCud = metaDetrazioneCud.Get_New_Row(rCud, DS.exhibitedcudabatement);
                    rDedCud["amount"] = OnDeb["amount"];
                    rDedCud["idabatement"] = OnDeb["idabatement"];
                }
            }


            Meta.myGetData.GetTemporaryValues(DS.exhibitedcudabatement);
            //Meta.myGetData.GetTemporaryValues(DS.abatableexpense);
        }

        DataTable getCudLinkedToContract(object idContratto) {
            return
                Meta.Conn.SQLRunner("SELECT * FROM exhibitedcud E WHERE " +
                                    QHS.AppAnd(QHS.CmpEq("E.idcon", idContratto),
                                        QHS.CmpEq("E.fiscalyear", Meta.GetSys("esercizio"))) +
                                    " AND NOT EXISTS(SELECT * FROM exhibitedcud EE where " +
                                    QHS.AppAnd(QHS.CmpEq("EE.idcon", idContratto),
                                        QHS.CmpEq("EE.fiscalyear", Meta.GetSys("esercizio"))) +
                                    " AND (EE.flagignoreprevcud='S') AND (EE.idexhibitedcud>E.idexhibitedcud) )");
        }

        //private void aggiungiDetrazionidaCudCartacei() {
        //    if (Meta.IsEmpty) return;
        //    DataRow Curr = DS.parasubcontract.Rows[0];
        //    object idContratto = Curr["idcon"];
        //    DataRow Cud = HelpForm.GetLastSelected(DS.exhibitedcud);
        //    if (Cud==null) return;
        //    string filtercud = QHC.CmpEq("idexhibitedcud", Curr["idexhibitedcud"]);

        //    //Prende i dettagli detrazioni cud e li trasforma in oneri detraibili;
        //    foreach (DataRow OnDeb in DS.exhibitedcud.Select(filtercud)) {

        //        DataRow OnereFound;
        //        string filter = QHC.CmpEq("idabatement", OnDeb["idabatement"]);
        //        DataRow[] Ab = DS.abatement.Select(filter);
        //        if (Ab.Length == 0) continue;
        //        if (Ab[0]["abatableexpense"].ToString().ToUpper() == "N") continue;

        //        DataRow[] Existent = DS.abatableexpense.Select(filter);
        //        if (Existent.Length > 0) {
        //            DataRow Ded = DS.abatementcode.Select(filter)[0];
        //            string msg = "La detrazione " + Ded["description"].ToString() + " è già presente tra gli oneri di questo contratto " +
        //                "per un importo pari a " + CfgFn.GetNoNullDecimal(Existent[0]["totalamount"]).ToString("c") + ".\r\n" +
        //                "In un contratto esistente ne è stata trovata una di importo pari a " +
        //                    CfgFn.GetNoNullDecimal(OnDeb["totalamount"]).ToString("c") + ".\r\n" +
        //                    "Se si intende sommare le due deduzioni premere Ok altrimenti sarà ignorata la detrazione trovata";
        //            if (MessageBox.Show(this, msg, "Conferma", MessageBoxButtons.OKCancel) != DialogResult.OK) continue;
        //            OnereFound = Existent[0];
        //            OnereFound["totalamount"] = CfgFn.GetNoNullDecimal(OnereFound["totalamount"]) +
        //                                            CfgFn.GetNoNullDecimal(OnDeb["totalamount"]);
        //        }
        //        else {
        //            MetaData meta_dedexp = MetaData.GetMetaData(this, "abatableexpense");
        //            meta_dedexp.SetDefaults(DS.abatableexpense);
        //            OnereFound = meta_dedexp.Get_New_Row(DS.parasubcontract.Rows[0], DS.abatableexpense);
        //            OnereFound["totalamount"] = OnDeb["totalamount"];
        //            OnereFound["idabatement"] = OnDeb["idabatement"];
        //        }
        //    }

        //    Meta.myGetData.GetTemporaryValues(DS.abatableexpense);
        //}


        /// <summary>
        /// Metodo che aggiunge le deduzioni ai CUD prendendole pari pari dagli ONERI DEDUCIBILI del contratto in questione,
        /// ossia prendendo i LORDI
        /// </summary>
        /// <param name="rCud"></param>
        /// <param name="idContratto">ID del contratto dal quale recuperare le deduzioni</param>
        private void aggiungiDeduzioni(DataRow rCud, object idContratto) {
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(idContratto, true);
            if (rCedolini.Length == 0) {
                return;
            }
            ////I dettagli deduzioni CUD sono aggiunti come importi NETTI ossia coerentemente con quanto presente 
            //// nei CUD cartacei
            //foreach (DataRow rCedolino in rCedolini) {
            //    string filtro = QHS.CmpEq("idpayroll", rCedolino["idpayroll"]);
            //    DataTable tDeduzioneCed = DataAccess.RUN_SELECT(Meta.Conn, "payrolldeduction",
            //            "iddeduction, curramount", "iddeduction", filtro, null, null, true);
            //    if ((tDeduzioneCed == null) || (tDeduzioneCed.Rows.Count == 0)) continue;
            //    foreach (DataRow rDeduzioneCed in tDeduzioneCed.Rows) {
            //        MetaData metaDeduzioneCud = MetaData.GetMetaData(this, "exhibitedcuddeduction");
            //        metaDeduzioneCud.SetDefaults(DS.exhibitedcuddeduction);
            //        DataRow rDedCud = metaDeduzioneCud.Get_New_Row(rCud, DS.exhibitedcuddeduction);
            //        rDedCud["amount"] = rDeduzioneCed["curramount"];
            //        rDedCud["iddeduction"] = rDeduzioneCed["iddeduction"];
            //    }
            //}

            //Gli oneri deducibili sono presi pari pari dal contratto in questione
            //Se sono presenti già altri oneri dello stesso tipo, è chiesto all'utente se si vogliono sommare o sostituire            
            string filterdedexp = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataTable OneriDed = DataAccess.RUN_SELECT(Meta.Conn, "deductibleexpense", "*", null, filterdedexp, null,
                null, true);
            foreach (DataRow OnDeb in OneriDed.Rows) {
                MetaData metaDeduzioneCud = MetaData.GetMetaData(this, "exhibitedcuddeduction");
                metaDeduzioneCud.SetDefaults(DS.exhibitedcuddeduction);
                DataRow rDedCud = metaDeduzioneCud.Get_New_Row(rCud, DS.exhibitedcuddeduction);
                rDedCud["amount"] = OnDeb["totalamount"];
                rDedCud["iddeduction"] = OnDeb["iddeduction"];

                //DataRow OnereFound;
                //string filter= QHC.CmpEq("iddeduction",OnDeb["iddeduction"]);
                //DataRow[] Existent = DS.deductibleexpense.Select(filter);
                //if (Existent.Length > 0) {
                //    DataRow Ded = DS.deductioncode.Select(filter)[0];
                //    string msg = "La deduzione " + Ded["description"].ToString() + " è già presente tra gli oneri di questo contratto " +
                //        "per un importo pari a " + CfgFn.GetNoNullDecimal(Existent[0]["totalamount"]).ToString("c") + ".\r\n" +
                //        "In un contratto esistente ne è stata trovata una di importo pari a " +
                //            CfgFn.GetNoNullDecimal(OnDeb["totalamount"]).ToString("c") + ".\r\n" +
                //            "Se si intende sommare le due deduzioni premere Ok altrimenti sarà ignorata la deduzione trovata";
                //    if (MessageBox.Show(this, msg, "Conferma", MessageBoxButtons.OKCancel) != DialogResult.OK) continue;
                //    OnereFound = Existent[0];
                //    OnereFound["totalamount"] = CfgFn.GetNoNullDecimal(OnereFound["totalamount"]) +
                //                                    CfgFn.GetNoNullDecimal(OnDeb["totalamount"]);
                //}
                //else {
                //    MetaData meta_dedexp = MetaData.GetMetaData(this, "deductibleexpense");
                //    meta_dedexp.SetDefaults(DS.exhibitedcuddeduction);
                //    OnereFound = meta_dedexp.Get_New_Row(DS.parasubcontract.Rows[0], DS.deductibleexpense);
                //    OnereFound["totalamount"] = OnDeb["totalamount"];
                //    OnereFound["iddeduction"] = OnDeb["iddeduction"];
                //}
            }

            //Aggiunge le deduzioni dei CUD collegati!!
            DataTable LinkedCud = getCudLinkedToContract(idContratto);
            if (LinkedCud == null || LinkedCud.Rows.Count == 0) {
                Meta.myGetData.GetTemporaryValues(DS.exhibitedcuddeduction);
                return;
            }
            string filterlinkedcud = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.FieldIn("idexhibitedcud", LinkedCud.Select()));
            DataTable LinkedDeduction = Meta.Conn.RUN_SELECT("exhibitedcuddeduction", "*", null, filterlinkedcud, null,
                false);
            foreach (DataRow OnDeb in LinkedDeduction.Rows) {
                string filter = QHS.AppAnd(QHC.CmpEq("iddeduction", OnDeb["iddeduction"]),
                    QHC.CmpEq("idexhibitedcud", rCud["idexhibitedcud"]));
                DataRow[] Existent = DS.exhibitedcuddeduction.Select(filter);
                if (Existent.Length > 0) {
                    DataRow OnereFound = Existent[0];
                    OnereFound["amount"] = CfgFn.GetNoNullDecimal(OnereFound["amount"]) +
                                           CfgFn.GetNoNullDecimal(OnDeb["amount"]);
                }
                else {
                    MetaData metaDeduzioneCud = MetaData.GetMetaData(this, "exhibitedcuddeduction");
                    metaDeduzioneCud.SetDefaults(DS.exhibitedcuddeduction);
                    DataRow rDedCud = metaDeduzioneCud.Get_New_Row(rCud, DS.exhibitedcuddeduction);
                    rDedCud["amount"] = OnDeb["amount"];
                    rDedCud["iddeduction"] = OnDeb["iddeduction"];
                }
            }



            Meta.myGetData.GetTemporaryValues(DS.exhibitedcuddeduction);
            //Meta.myGetData.GetTemporaryValues(DS.deductibleexpense);

        }

        private bool aggiungiFamiliari(object idContratto, bool showMessage) {
            DataRow[] Familiare = ottieniFamiliariContratto(idContratto);

            if (Familiare.Length == 0) {
                return false;
            }

            if (showMessage) {
                MessageBox.Show(this, "Verranno aggiunti i familiari presenti in altri contratti. " +
                                      "Nel caso non si vogliano applicare le detrazioni rimuoverli manualmente",
                    "Informazione",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataRow Curr = DS.parasubcontract.Rows[0];

            foreach (DataRow rFamiliareSrc in Familiare) {
                MetaData metaFamiliare = MetaData.GetMetaData(this, "parasubcontractfamily");
                metaFamiliare.SetDefaults(DS.parasubcontractfamily);
                DataRow rFamiliare = metaFamiliare.Get_New_Row(Curr, DS.parasubcontractfamily);
                foreach (DataColumn C in DS.parasubcontractfamily.Columns) {
                    if ((C.ColumnName == "idcon") ||
                        (C.ColumnName == "ct") || (C.ColumnName == "cu") ||
                        (C.ColumnName == "lt") || (C.ColumnName == "lu") ||
                        (C.ColumnName == "ayear") || (C.ColumnName == "amount") ||
                        (C.ColumnName == "idfamily")) continue;

                    if ((!rFamiliareSrc.Table.Columns.Contains(C.ColumnName)) ||
                        (!rFamiliare.Table.Columns.Contains(C.ColumnName))) continue;

                    rFamiliare[C.ColumnName] = rFamiliareSrc[C.ColumnName];
                }
            }

            return true;
        }

        #endregion

        /// <summary>
        /// Metodo che imposta l'aliquota fiscale marginale
        /// </summary>
        private bool impostaAliquotaFiscaleMarginale() {
            DataRow Curr = DS.parasubcontract.Rows[0];
            DataRow ImpCurr = DS.parasubcontractyear.Rows[0];

            string filterRitenuta =
                QHS.AppAnd(QHS.CmpEq("taxkind", 1), QHS.IsNull("geoappliance"),
                    QHS.CmpEq("idser", Curr["idser"]));
            object ritenutaFiscaleObj = Meta.Conn.DO_READ_VALUE("servicetaxview", filterRitenuta, "taxcode");
            if (ritenutaFiscaleObj == null) return false;

            object nCud = DS.exhibitedcud.Compute("COUNT(idexhibitedcud)", null);
            string messaggio = "";
            if (CfgFn.GetNoNullInt32(nCud) == 0) {
                return false;
                //if (SubEntity_rbScaglioniIRPEF.Checked) {
                //    return false;
                //}
                //messaggio = "Verrà ora impostata l'aliquota della ritenuta fiscale per scaglioni in quanto non ci sono più CUD associati al contratto";
                //MessageBox.Show(this, messaggio, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SubEntity_rbScaglioniIRPEF.Checked = true;
                //setValoreInComboAliquota(DBNull.Value);

                //return true;
            }

            decimal imponibileFiscale = calcolaImponibileFiscalePresuntoAnnuo();
            string filterData =
                QHS.AppAnd(QHS.CmpEq("taxcode", ritenutaFiscaleObj),
                    QHS.CmpLe("start", Meta.GetSys("datacontabile")));
            object idtaxratestart = Meta.Conn.DO_READ_VALUE("taxratestart", filterData, "MAX(idtaxratestart)");

            string filter = QHS.AppAnd(
                QHS.CmpEq("taxcode", ritenutaFiscaleObj), QHS.CmpEq("idtaxratestart", idtaxratestart),
                QHS.DoPar(QHS.NullOrLe("minamount", imponibileFiscale)),
                QHS.DoPar(QHS.NullOrGe("maxamount", imponibileFiscale))
                );

            object aliquotaFiscale = Meta.Conn.DO_READ_VALUE("taxratebracket", filter, "employrate");
            if (ImpCurr["highertax"].Equals(aliquotaFiscale) && ImpCurr["applybrackets"].Equals("N")) return false;
            decimal aliquota = CfgFn.GetNoNullDecimal(aliquotaFiscale);
            messaggio = "Verrà ora impostata l'aliquota della ritenuta fiscale al " + aliquota.ToString("p")
                        + " in base all'imponibile presunto annuo. Questo al fine di evitare "
                        + " problemi di incapienza in fase di conguaglio.\n "
                        + " A conguaglio sarà comunque possibile togliere la spunta per evitare un'applicazione "
                        + " eccessiva di imposte. Avvisare il percipiente di questa situazione.";

            MessageBox.Show(this, messaggio, "Avviso impotante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SubEntity_rbAliquotaMarginale.Checked = true;
            setValoreInComboAliquota(aliquotaFiscale);
            return true;
        }

        private decimal calcolaImponibileFiscalePresuntoAnnuo() {
            DataRow Curr = DS.parasubcontract.Rows[0];
            decimal imponibileFiscalePresuntoAnnuo = 0;

            int esercizio = (int) Meta.GetSys("esercizio");

            DateTime inizioAnno = new DateTime(esercizio, 1, 1);
            DateTime fineAnno = new DateTime(esercizio, 12, 31);

            DateTime dataInizioCompetenza = (Curr["start"] != DBNull.Value) ? (DateTime) Curr["start"] : inizioAnno;
            DateTime dataFineCompetenza = (Curr["stop"] != DBNull.Value) ? (DateTime) Curr["stop"] : fineAnno;

            dataInizioCompetenza = (dataInizioCompetenza < inizioAnno) ? inizioAnno : dataInizioCompetenza;
            dataFineCompetenza = (dataFineCompetenza > fineAnno) ? fineAnno : dataFineCompetenza;
            int giorniCompetenza = 1 + (dataFineCompetenza - dataInizioCompetenza).Days;
            int giorniAnno = DateTime.IsLeapYear(esercizio) ? 366 : 365;
            if (Meta.InsertMode) {
                decimal compensoLordo = CfgFn.GetNoNullDecimal(Curr["grossamount"]);
                imponibileFiscalePresuntoAnnuo = compensoLordo/giorniAnno*giorniCompetenza;
            }
            else {
                string filterContratto = QHC.AppAnd(QHC.CmpEq("idcon", Curr["idcon"]),
                    QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", esercizio));
                foreach (DataRow R in DS.payroll.Select(filterContratto)) {
                    imponibileFiscalePresuntoAnnuo += CfgFn.GetNoNullDecimal(R["feegross"]);
                }
            }
            decimal imponibileCud = calcolaSommaImponibileCud();
            imponibileFiscalePresuntoAnnuo += imponibileCud;
            return imponibileFiscalePresuntoAnnuo;
        }

        /// <summary>
        /// Metodo che ottiene i cedolini erogati del contratto nell'anno fiscale corrente
        /// </summary>
        /// <param name="idContratto">ID del contratto sul quale cercare i cedolini</param>
        /// <param name="isConguaglio">TRUE: Limita la ricerca ai cedolini di conguaglio; FALSE: limita la ricerca ai cedolini rata</param>
        /// <returns></returns>
        private DataRow[] ottieniCedoliniErogatiPerContratto(object idContratto, bool isConguaglio) {
            string conguaglio = QHS.CmpEq("flagbalance", (isConguaglio) ? "S" : "N");
            string filtroCedolino =
                QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("fiscalyear", esercizio), conguaglio,
                    QHS.IsNotNull("disbursementdate"));

            DataTable tCedolini = DataAccess.RUN_SELECT(Meta.Conn, "payroll", "idpayroll", null, filtroCedolino, null,
                null, true);
            DataRow[] rCedolini = tCedolini.Select();
            return rCedolini;
        }

        private string ricavaDescrDeduzione(object idDeduzione) {
            DataRow[] R = DS.deduction.Select(QHC.CmpEq("iddeduction", idDeduzione));
            return R.Length == 0 ? "" : R[0]["description"].ToString();
        }

        private string ricavaDescrDetrazione(object idDetrazione) {
            DataRow[] R = DS.abatement.Select(QHC.CmpEq("idabatement", idDetrazione));
            return R.Length == 0 ? "" : R[0]["description"].ToString();
        }

        private string ricavaDenominazioneComune(object idcity) {
            object nomeCitta = Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcity), "title");
            return nomeCitta == null ? "" : nomeCitta.ToString();
        }

        private void aggiornaComuneResidenza(object idComuneAddRegionale) {
            if (DS.parasubcontractyear.Rows.Count == 0) return;
            if (idComuneAddRegionale == null) idComuneAddRegionale = DBNull.Value;
            if (idComuneAddRegionale.Equals(DS.parasubcontractyear.Rows[0]["idresidence"])) {
                return;
            }
            DS.parasubcontractyear.Rows[0]["idresidence"] = idComuneAddRegionale;

            /*
            if ((idComuneAddRegionale != DBNull.Value) && (idComuneAddRegionale != null)) {
                if (idComuneAddRegionale.Equals(DS.parasubcontractyear.Rows[0]["idresidence"])) {
                    return;
                }
                else {
                    if (Meta.FirstFillForThisRow) {
                        if ((Meta.InsertMode) || (Meta.EditMode)) {
                            if (!verificaPrestazioneStranieri()) {
                                MessageBox.Show(this, "Il comune di residenza del percipiente " +
                                "non risulta essere "
                                + txtComuneAddRegionali.Text
                                + ". Pertanto sarà aggiornato ",
                                "Avviso");
                            }
                        }
                    }
                    DS.parasubcontractyear.Rows[0]["idresidence"] = idComuneAddRegionale;
                }
            }
            else {
                  DS.parasubcontractyear.Rows[0]["idresidence"] = DBNull.Value;
            }
           */

        }

        private void ricalcoloEventualeDelCostoTotale() {
            if (Meta.IsEmpty) return;
            InputPerCalcoloCostoTotale input = getInputPerCalcoloCostoTotale(false);
            if (input == null) return;
            if (input.Equals(inputPerCalcoloCostoTotale)) return;
            inputPerCalcoloCostoTotale = input;

            decimal costoTotale = calcolaCostoTotale(input);

            txtStimaCostoTotale.Text = costoTotale.ToString("c");
        }

        private void txtLordoAlBeneficiario_LostFocus(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ricalcoloEventualeDelCostoTotale();
        }

        /// <summary>
        /// Prende i dati dal form e non dal dataset
        /// </summary>
        /// <returns></returns>
        private bool verificaPrestazioneStranieri() {
            if (cmbTipoPrestazione.SelectedValue == null) return false;
            DataRow[] service = DS.service.Select(QHC.CmpEq("idser", cmbTipoPrestazione.SelectedValue));
            if (service.Length != 0) {
                object flagForeignObj = service[0]["flagforeign"];
                if ((flagForeignObj != DBNull.Value) && (flagForeignObj != null)) {
                    string flagForeignStr = flagForeignObj.ToString().ToUpper();
                    if (flagForeignStr == "S") {
                        return true;
                    }
                }
            }
            return false;
        }

        private decimal daCostoTotaleAlLordoAlBeneficiario(decimal costoTotale, out bool calcoloRiuscito) {
            calcoloRiuscito = false;
            if (inputPerCalcoloCostoTotale == null) return -1;

            InputPerCalcoloCostoTotale inputProva = new InputPerCalcoloCostoTotale(inputPerCalcoloCostoTotale);

            decimal a = 0;
            decimal b = costoTotale;

            inputProva.lordoAlBeneficiario = a;
            decimal costoTotaleA = calcolaCostoTotale(inputProva);

            inputProva.lordoAlBeneficiario = b;
            decimal costoTotaleB = calcolaCostoTotale(inputProva);

            while (a < b && costoTotaleA!=costoTotaleB) {
                inputProva.lordoAlBeneficiario = CfgFn.RoundValuta(
                    ((costoTotale - costoTotaleA)/(costoTotaleB - costoTotaleA))
                    *(b - a) + a);
                decimal costoTotaleProva = CfgFn.RoundValuta(calcolaCostoTotale(inputProva));
                if (costoTotaleProva == costoTotale) {
                    calcoloRiuscito = true;
                    return inputProva.lordoAlBeneficiario;
                }
                if ((costoTotaleProva > costoTotale) && (costoTotaleProva != costoTotaleB)) {
                    costoTotaleB = costoTotaleProva;
                    b = inputProva.lordoAlBeneficiario;
                    continue;
                }
                if ((costoTotaleProva < costoTotale) && (costoTotaleProva != costoTotaleA)) {
                    costoTotaleA = costoTotaleProva;
                    a = inputProva.lordoAlBeneficiario;
                    continue;
                }
                return inputProva.lordoAlBeneficiario;
            }
            inputProva.lordoAlBeneficiario = a;
            calcoloRiuscito = CfgFn.RoundValuta(calcolaCostoTotale(inputProva)) == costoTotale;
            return inputProva.lordoAlBeneficiario;
        }

        private void txtDataFine_LostFocus(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (DS.parasubcontract.Rows.Count == 0) return;
            Meta.myHelpForm.LeaveDateTimeTextBox(txtDataFine, e);
            object o = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            DateTime dataFine = o is DateTime ? (DateTime) o : QueryCreator.EmptyDate();
            DataRow Curr = DS.parasubcontract.Rows[0];
            string filtroCedolino = QHC.AppAnd(QHC.CmpEq("idcon", Curr["idcon"]),
                QHC.IsNotNull("disbursementdate"), QHC.CmpLe("fiscalyear", esercizio));
            DataRow[] cedoliniErogati = DS.payroll.Select(filtroCedolino, "stop desc");

            if (cedoliniErogati.Length != 0) {
                DateTime ultimaDataErogazione = (DateTime) cedoliniErogati[0]["stop"];
                if (ultimaDataErogazione >= dataFine) {
                    string messaggio = "Attenzione! La data di fine del contratto inserita " + txtDataFine.Text +
                                       " è antecedente alla data " +
                                       ultimaDataErogazione.ToString() +
                                       " che rappresenta la data di fine dell'ultimo cedolino erogato" +
                                       "\n Verrà automaticamente impostata la seguente data " +
                                       ultimaDataErogazione.AddDays(1).ToString();
                    MessageBox.Show(this, messaggio, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtDataFine.Text = ultimaDataErogazione.AddDays(1).ToString();
                }
            }
            ricalcoloEventualeDelCostoTotale();
            DataRow rService = DS.parasubcontract.Rows[0].GetParentRow("serviceparasubcontract");
            if ((o is DateTime) && (rService != null) && (rService["certificatekind"].ToString() == "U")) {
                generaCudDaAltriContratti();
            }
            else {
                cancellaCud();
            }
        }

        private void txtDataInizio_LostFocus(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            ricalcoloEventualeDelCostoTotale();
            Meta.myHelpForm.LeaveDateTimeTextBox(txtDataFine, e);
            object o = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            DataRow rService = DS.parasubcontract.Rows[0].GetParentRow("serviceparasubcontract");
            if ((o is DateTime) && (rService != null) && (rService["certificatekind"].ToString() == "U")) {
                generaCudDaAltriContratti();
            }
            else {
                cancellaCud();
            }
        }

        private void btnSituazione_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            object idcontratto;
            DataRow Curr = DS.parasubcontract.Rows[0];
            idcontratto = Curr["idcon"];

            DataSet Out = Meta.Conn.CallSP("show_parasubcontract",
                new Object[2] {Meta.GetSys("esercizio"), idcontratto});
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione Contratto";

            frmSituazioneViewer view = new frmSituazioneViewer(Out);
            view.Show();
        }

        void VisualizzaEtichetteAP() {
            if (DS.parasubcontract.Rows.Count > 0 && (DS.parasubcontract.Rows[0].RowState == DataRowState.Unchanged)) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = true;
                btnCollegaAP.Visible = true;
            }
            else {
                if (Meta.InsertMode || DS.parasubcontract.Rows.Count == 0) // || DS.entrysetup.Rows.Count==0)
                {
                    labAPnongenerato.Visible = false;
                    labAPgenerato.Visible = false;
                    btnVisualizzaAP.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                    return;
                }
            }

            string idrelated = AP_fun.GetIdForDocument(DS.parasubcontract.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("idrelated", idrelated), true) == 0) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = false;
                btnVisualizzaAP.Visible = false;
                btnGeneraAP.Visible = true;
                btnCollegaAP.Visible = true;
            }
            else {
                labAPnongenerato.Visible = false;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = false;
                btnCollegaAP.Visible = false;
            }
        }

        void GeneraScrittureAP() {
            if (DS.parasubcontract.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.parasubcontract.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(Meta.Dispatcher);
            if (!AP.attivo) return;
            AP.GetEntryForDocument(Curr);

            if (AP.MainSrvRegExists()) {
                MessageBox.Show(this, "L'Anagrafe Prestazione è stata già generata.",
                    "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MetaData ToMeta = Meta.Dispatcher.Get("serviceregistry");
            ToMeta.Edit(Meta.linkedForm.ParentForm, "default", false);

            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in ToMeta.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }

            bool isOk = AP.SetSrvRegDefault(ToMeta, Curr, Curr["idreg"], AP_fun.GetIdForDocument(Curr));
            if (!isOk) {
                MessageBox.Show(this, "Errore nella assegnazione dei valori di default",
                    "Anagrafe Prestazioni non generata");
                return;
            }

            ToMeta.DoMainCommand("maininsert");
            foreach (DataColumn CC in ToMeta.PrimaryDataTable.Columns) {
                CC.DefaultValue = saveddefaults[CC.ColumnName];
            }

        }

        private void btnGeneraAP_Click(object sender, System.EventArgs e) {
            GeneraScrittureAP();
        }

        void EditServiceRegistry() {
            if (DS.parasubcontract.Rows.Count == 0) return;
            AP_fun AP = new AP_fun(Meta.Dispatcher);
            AP.EditRelatedServiceRegistry(Meta, DS.parasubcontract.Rows[0]);
        }

        private void btnVisualizzaAP_Click(object sender, System.EventArgs e) {
            EditServiceRegistry();
        }

        private bool problemaAltriContrattiNonConguagliati() {
            //più di un contratto non conguagliato per lo stesso creditore
            string query = "select * from payroll ce1"
                           + " join payroll ce2 on ce1.idpayroll<>ce2.idpayroll"
                           + " join parasubcontract co2 on ce2.idcon=co2.idcon"
                           + " join service S on co2.idser = S.idser "
                           + " where co2.idreg="
                           + DS.parasubcontract.Rows[0]["idreg"]
                           + " and ce1.flagbalance='S' and ce1.idcon="
                           + QHS.quote(DS.parasubcontract.Rows[0]["idcon"])
                           + " and S.certificatekind = 'U' "
                           + " and ce1.disbursementdate is null and ce1.fiscalyear=" + QHS.quote(esercizio)
                           +
                           "	and ce2.flagbalance='S' and ce2.disbursementdate is null and ce2.fiscalyear=ce1.fiscalyear";
            DataTable t = Conn.SQLRunner(query);
            if (t.Rows.Count == 0) return false;
            string messaggio = "Per lo stesso creditore ";
            if (t.Rows.Count == 1) {
                messaggio += "esiste anche il contratto (" + t.Rows[0]["ycon"] + "/" + t.Rows[0]["ncon"] + ")"
                             + " che non è stato ancora conguagliato.";
            }
            else {
                messaggio += "esistono i seguenti contratti\n" + "(" + t.Rows[0]["ycon"] + "," + t.Rows[0]["ncon"] + ")";
                for (int i = 1; i < t.Rows.Count; i++) {
                    DataRow r = t.Rows[i];
                    messaggio += ", (" + r["ycon"] + "," + r["ncon"] + ")";
                }
                messaggio += "\nche non sono ancora stati conguagliati.";
            }
            messaggio += "\nSi consiglia di conguagliare un contratto prima di aprirne un altro.";
            MessageBox.Show(this, messaggio);
            return true;
        }

        private bool problemaAltriPagamentiStessoCreditore() {
            string query = "select distinct expenseview.idser, expenseview.idexp, expenseview.ymov, expenseview.nmov from expenseview"
                           + " join service on expenseview.idser=service.idser and rec770kind='G'"
                           + " join expenseyear on expenseview.idexp=expenseyear.idexp and expenseyear.ayear=" +
                           QHS.quote(esercizio)
                           + " join expensetax on expenseview.idexp=expensetax.idexp "
                           + " and not exists(select * from expensepayroll join expenselink "
                           +
                           " on expenselink.idparent=expensepayroll.idexp where expenselink.idchild=expenseview.idexp)"
                           + " and expenseview.idreg=" + QHS.quote(DS.parasubcontract.Rows[0]["idreg"]);
            DataTable t = DataAccess.SQLRunner(Conn, query);
            if (t.Rows.Count == 0) {
                return false;
            }
            string messaggio = "Per questo creditore esistono altri pagamenti per prestazioni co.co.co.\n"
                               + "non inseriti tramite il modulo Compensi. I Pagamenti sono i seguenti:";
            foreach (DataRow r in t.Rows) {
                string s = r["nmov"].ToString() + " del " + r["ymov"].ToString();
                string descrprest = DS.service.Select(QHC.CmpEq("idser", r["idser"]))[0]["description"].ToString();
                messaggio += "\n" + descrprest + " " + s;
            }
            DataRow[] rCedCong = DS.payroll.Select(QHC.CmpEq("flagbalance", "S"));
            if (rCedCong.Length > 0) {
                if (rCedCong[0]["disbursementdate"] == DBNull.Value) {
                    messaggio += "\n\nSe non già fatto, inserire i cud di tali pagamenti";
                }
                else {
                    messaggio +=
                        "\n\nEssendo già stato erogato il conguaglio non è possibile rimediare in questo contratto";
                }
            }
            MessageBox.Show(this, messaggio);
            return true;
        }

        private bool problemaCudCheNonPuntanoANulla() {
            object codiceFiscale = Conn.DO_READ_VALUE("license", null, "cf");
            DataRow[] rCud = DS.exhibitedcud.Select(
                QHC.AppAnd(QHC.IsNull("idlinkedcon"), QHC.NullOrEq("cfotherdeputy", codiceFiscale)));
            if (rCud.Length == 0) {
                return false;
            }
            MessageBox.Show(this, "In questo contratto esistono cud che non puntano a nessun altro contratto");
            return true;
        }

        private bool problemaPiuUrgenteInAltriContratti() {
            //altri contratti conguagliati dello stesso creditore che hanno cud che non puntano a nulla
            string query = "select exhibitedcud.idcon, exhibitedcud.idexhibitedcud"
                           + " from payroll"
                           + " join parasubcontract on payroll.idcon=parasubcontract.idcon"
                           + " join exhibitedcud on exhibitedcud.idcon=payroll.idcon"
                           + " where idreg=" + QHS.quote(DS.parasubcontract.Rows[0]["idreg"])
                           + " and flagbalance='S' and disbursementdate is not null and payroll.fiscalyear="
                           + QHS.quote(esercizio)
                           + " and exhibitedcud.fiscalyear=" + QHS.quote(esercizio)
                           + " and exhibitedcud.idcon<>" + QHS.quote(DS.parasubcontract.Rows[0]["idcon"])
                           + " and idlinkedcon is null"
                           + " and (cfotherdeputy is null or cfotherdeputy="
                           + " (select cf from license))";
            DataTable t = DataAccess.SQLRunner(Conn, query);
            if (t.Rows.Count == 0) {
                return false;
            }
            string messaggio = "Esistono altri contratti già conguagliati "
                               + "che hanno i cud che non puntano ad alcun contratto.\n"
                               + "I cud sono i seguenti:\n"
                               + "(" + t.Rows[0]["idcon"] + "," + t.Rows[0]["idexhibitedcud"] + ")";
            for (int i = 1; i < t.Rows.Count; i++) {
                messaggio += ", " + "(" + t.Rows[i]["idcon"] + "," + t.Rows[i]["idexhibitedcud"] + ")";
            }
            messaggio += "\n\nOccorre pertanto prima sistemare tali cud e poi tornare a questo contratto!";
            MessageBox.Show(this, messaggio);
            return true;
        }

        //cud che puntano allo stesso contratto 
        private bool problemaDueCudRiferentesiAlloStessoContratto() {
            bool errori = false;
            foreach (DataRow rCud in DS.exhibitedcud.Select("(idlinkedcon is not null)")) {
                string filtro = "((idcon<>" + QHS.quote(rCud["idcon"])
                                + ") or (idexhibitedcud<>" + QHS.quote(rCud["idexhibitedcud"])
                                + ")) and ((idlinkedcon=" + QHS.quote(rCud["idlinkedcon"])
                                + ") AND (idlinkeddbdepartment=" + QHS.quote(rCud["idlinkeddbdepartment"]) + "))";
                DataTable t = DataAccess.RUN_SELECT(Conn, "exhibitedcud", null, null, filtro, null, null, true);
                if (t.Rows.Count > 0) {
                    errori = true;
                    foreach (DataRow r in t.Rows) {
                        MessageBox.Show("Il cud n° " + rCud["idexhibitedcud"] + " punta allo stesso contratto "
                                        + QueryCreator.quotedstrvalue(rCud["idlinkedcon"], true)
                                        + " che è puntato"
                                        + "\n anche dal cud (" + r["idcon"] + "," + r["idexhibitedcud"] + ").");
                    }
                }
            }
            return errori;
        }

        private void inserisciCud(DataTable tContratto) {
            bool askCopyFamily = true;
            foreach (DataRow rContratto in tContratto.Rows) {

                CalcoliCococo.cudContratto cud = CalcoliCococo.getInfoCudFromContratto(
                    Meta.Conn,
                    DS.parasubcontract.Rows[0],
                    rContratto);
                if (cud == null) continue;

                object idContratto = rContratto["idcon"];
                MetaData metaCud = MetaData.GetMetaData(this, "exhibitedcud");
                metaCud.SetDefaults(DS.exhibitedcud);
                DataRow rCud = metaCud.Get_New_Row(DS.parasubcontract.Rows[0], DS.exhibitedcud);
                rCud["start"] = cud.dataInizioCompetenza;
                rCud["stop"] = cud.dataFineCompetenza;
                rCud["flagignoreprevcud"] = "N";
                rCud["cfotherdeputy"] = cud.codicefiscalealtrosostituto;
                rCud["ndays"] = cud.numeroGiorni;
                rCud["nmonths"] = cud.numeroMesi;
                rCud["taxablepension"] = cud.imponibilePrevidenziale;
                rCud["taxablegross"] = cud.imponibilefiscalelordo;
                rCud["citytaxapplied"] = cud.addComApplicata;
                rCud["regionaltaxapplied"] = cud.addRegApplicata;
                rCud["irpefapplied"] = cud.irpefApplicata;
                rCud["irpefgross"] = cud.irpefGross;
                rCud["earnings_based_abatements"] = cud.earnings_based_abatements;
                rCud["totabatements"] = cud.totabatements;
                rCud["fiscalbonusapplied"] = cud.fiscalBonusApplied;
                rCud["inpsretained"] = cud.contributiTrattenuti;
                rCud["inpsowed"] = cud.contributiDovuti;
                rCud["citytax_account"] = cud.accontoAddComunale;
                rCud["idlinkedcon"] = rContratto["idcon"];
                rCud["idlinkeddbdepartment"] = rContratto["iddbdepartment"];
                rCud["idcity"] = cud.idCity;
                rCud["idfiscaltaxregion"] = cud.idFiscalTaxRegion;

                aggiungiDeduzioni(rCud, idContratto);
                aggiungiDetrazioni(rCud, idContratto);

                if (DS.parasubcontractfamily.Rows.Count == 0) {
                    askCopyFamily = askCopyFamily && !aggiungiFamiliari(idContratto, askCopyFamily);
                }
            }
            //            HelpForm.SetDataGrid(dataGrid6, DS.exhibitedcuddeduction);
            //            HelpForm.SetDataGrid(dataGrid7, DS.exhibitedcudabatement);
        }

        //contratti che non puntano ad un contratto precedente
        private bool problemaContrattoPrecedenteNonRiferitoDaCud() {
            if (!(cmbTipoPrestazione.SelectedValue is int)) return false;
            DataRow[] rService = DS.service.Select(QHC.CmpEq("idser", cmbTipoPrestazione.SelectedValue));
            if ((rService.Length == 0) || (rService[0]["certificatekind"].ToString().ToUpper() != "U")) return false;

            string cudRiferiti = QHS.DistinctVal(DS.exhibitedcud.Select(QHC.IsNotNull("idlinkedcon")), "idlinkedcon");
            object idreg = DS.parasubcontract.Rows[0]["idreg"];

            string query = "SELECT * FROM parasubcontractlist " +
                           " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("idreg", idreg),
                               QHS.CmpEq("ayear", esercizio), QHS.CmpEq("linked", 'N'),
                               QHS.CmpEq("balanced", 'S'));

            DataRow[] rCedCong = DS.payroll.Select(QHC.CmpEq("flagbalance", "S"));
            if (rCedCong.Length == 0) {
                MessageBox.Show(this, "Questo contratto non ha il cedolino di conguaglio!");
            }
            bool contrattoChiuso = (rCedCong.Length > 0) && !(rCedCong[0]["disbursementdate"] is DBNull);
            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            if (t.Rows.Count == 0) {
                return false;
            }
            if ((t.Rows.Count >= 1) && (DS.exhibitedcud.Rows.Count == 0) && !contrattoChiuso) {
                DialogResult dr = MessageBox.Show(this, "Per lo stesso percipiente esiste il contratto "
                                                        + t.Rows[0]["idcon"]
                                                        +
                                                        " già conguagliato. Procedere con l'inserimento del relativo cud in questo contratto?",
                    "Inserimento CUD", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK) {
                    Meta.GetFormData(true);
                    inserisciCud(t);
                    Meta.FreshForm();
                }
                return true;
            }
            string messaggio =
                "I seguenti contratti risultano già conguagliati ma non riferiti tramite cud in altri contratti:";
            foreach (DataRow r in t.Rows) {
                messaggio += "\n" + r["idcon"];
            }
            if (!contrattoChiuso) {
                messaggio += "\nÈ possibile rimediare inserendo un cud in questo contratto";
            }
            else {
                if (DS.exhibitedcud.Rows.Count > 0) {
                    messaggio += "\nÈ possibile rimediare facendo puntare uno dei cud a tale contratto";
                }
                else {
                    messaggio += "\nNon è possibile rimediare in questo contratto";
                }
            }
            MessageBox.Show(this, messaggio);
            return true;
        }

        private void btnVerificaProblemi_Click(object sender, System.EventArgs e) {
            bool errori = problemaAltriContrattiNonConguagliati();
            if (problemaAltriPagamentiStessoCreditore()) {
                errori = true;
            }
            if (problemaCudCheNonPuntanoANulla()) {
                errori = true;
            }
            if (problemaPiuUrgenteInAltriContratti()) {
                errori = true;
            }
            else {
                if (problemaDueCudRiferentesiAlloStessoContratto()) {
                    errori = true;
                }
                if (problemaContrattoPrecedenteNonRiferitoDaCud()) {
                    errori = true;
                }
            }
            if (!errori) {
                MessageBox.Show(this, "Non sono stati riscontrati errori nei cud");
            }
        }

        private void btnCalcAcconto_Click(object sender, EventArgs e) {
            if (DS.parasubcontract.Rows.Count == 0) return;
            if (DS.parasubcontractyear.Rows.Count == 0) return;

            DataRow Curr = DS.parasubcontract.Rows[0];
            DataRow CurrImp = DS.parasubcontractyear.Rows[0];

            if (Curr["idreg"] == DBNull.Value) return;
            int idreg = CfgFn.GetNoNullInt32(Curr["idreg"]);
            if (idreg == 0) return;
            decimal annualincome = CfgFn.GetNoNullDecimal(CurrImp["annualincome"]);

            object idcity = CalcoliCococo.calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
            if ((idcity == DBNull.Value) || (idcity == null)) {
                return;
            }
            FrmCalcAcconto frm = new FrmCalcAcconto(Conn, idreg, annualincome, idcity, Curr["idser"]);
            DialogResult dr = frm.ShowDialog();
            if (dr != DialogResult.OK) return;
            decimal newRC = frm.annualincome;
            if (newRC != annualincome) {
                CurrImp["annualincome"] = newRC;
            }
            decimal newCTA = frm.citytax_account;
            if (newCTA != CfgFn.GetNoNullDecimal(CurrImp["citytax_account"])) {
                CurrImp["citytax_account"] = newCTA;
                SubEntity_txtImportoAcconto.Text = newCTA.ToString("c");
            }
        }

        private void btnTroncaContratto_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;

            object dataTroncamento = DS.payroll.Compute("max(stop)", "disbursementdate is not null");
            if (dataTroncamento == DBNull.Value) {
                int count = Meta.Conn.RUN_SELECT_COUNT("payroll",
                    QHS.AppAnd(QHS.IsNotNull("disbursementdate"),
                        QHS.CmpEq("idcon", DS.parasubcontract.Rows[0]["idcon"])), true);
                if (count > 0) {
                    MessageBox.Show(this,
                        "Non ci sono cedolini erogati in quest'anno, pertano questo contratto può essere ignorato");
                }
                MessageBox.Show(this, "Non ci sono cedolini erogati; si può cancellare direttamente il contratto");
                return;
            }
            DataRow[] rCedCong = DS.payroll.Select(QHC.CmpEq("flagbalance", "S"));
            if (rCedCong.Length == 0) {
                MessageBox.Show(this, "Manca il cedolino di conguaglio!");
                return;
            }
            if (rCedCong[0]["disbursementdate"] != DBNull.Value) {
                MessageBox.Show(this, "Il contratto è già chiuso");
                return;
            }
            object dataErogazione = DS.payroll.Compute("max(disbursementdate)", "disbursementdate is not null");
            rCedCong[0]["disbursementdate"] = (DateTime) dataErogazione;
            DS.parasubcontract.Rows[0]["stop"] = (DateTime) dataTroncamento;
            txtDataFine.Text = HelpForm.StringValue(dataTroncamento, txtDataFine.Tag.ToString());
            foreach (DataRow r in DS.payroll.Select(
                QHC.AppAnd(QHC.CmpEq("flagbalance", "N"), QHC.IsNull("disbursementdate")))) {
                cancellaFigliDiCedolino(r);
                r.Delete();
            }
            rCedCong[0]["disbursementdate"] = dataErogazione;
            rCedCong[0]["flagcomputed"] = "S";
            rCedCong[0]["feegross"] = DS.payroll.Compute("sum(feegross)", QHC.CmpEq("flagbalance", "N"));
            rCedCong[0]["netfee"] = DS.payroll.Compute("sum(netfee)", QHC.CmpEq("flagbalance", "N"));
            string filtroCedoliniRata = QHC.CmpNe("idpayroll", rCedCong[0]["idpayroll"]);
            aggiungiRitenuteSulCedolinoDiConguaglio(rCedCong[0], filtroCedoliniRata);

            Meta.SaveFormData();
        }

        private void aggiungiRitenuteSulCedolinoDiConguaglio(DataRow cedConguaglioRow, string filtroCedoliniRata) {
            MetaData metaPayrollTax = MetaData.GetMetaData(this, "payrolltax");

            foreach (DataRow rPayroll in DS.payroll.Select(filtroCedoliniRata)) {
                string fCedolinoRata = QHC.CmpEq("idpayroll", rPayroll["idpayroll"]);

                foreach (DataRow rPayrollTaxRata in DS.payrolltax.Select(fCedolinoRata)) {
                    string fTaxCode = QHC.AppAnd(QHC.CmpEq("taxcode", rPayrollTaxRata["taxcode"]),
                        QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]));

                    DataRow[] PayrollTaxConguaglio = DS.payrolltax.Select(fTaxCode);

                    DataRow rPayrollTaxConguaglio;
                    if (PayrollTaxConguaglio.Length > 0) {
                        rPayrollTaxConguaglio = PayrollTaxConguaglio[0];
                        foreach (string col in new string[] {
                            "admintax", "employtax",
                            "employtaxgross", "deduction",
                            "abatements", "taxablegross",
                            "taxablenet", "annualtaxabletotal"
                        }) {
                            rPayrollTaxConguaglio[col] = CfgFn.GetNoNullDecimal(rPayrollTaxConguaglio[col]) +
                                                         CfgFn.GetNoNullDecimal(rPayrollTaxRata[col]);
                        }
                        rPayrollTaxConguaglio["annualpayedemploytax"] =
                            CfgFn.GetNoNullDecimal(rPayrollTaxConguaglio["annualpayedemploytax"])
                            + CfgFn.GetNoNullDecimal(rPayrollTaxRata["employtax"]);

                        rPayrollTaxConguaglio["annualcreditapplied"] =
                            CfgFn.GetNoNullDecimal(rPayrollTaxConguaglio["annualcreditapplied"])
                            + CfgFn.GetNoNullDecimal(rPayrollTaxRata["employtax"]);
                    }
                    else {
                        metaPayrollTax.SetDefaults(DS.payrolltax);
                        rPayrollTaxConguaglio = metaPayrollTax.Get_New_Row(cedConguaglioRow, DS.payrolltax);

                        foreach (string c in new string[] {
                            "admindenominator", "adminnumerator", "adminrate",
                            "employdenominator", "employnumerator", "employrate", "taxabledenominator",
                            "taxablenumerator", "taxcode", "admintax", "employtax", "employtaxgross", "deduction",
                            "abatements", "taxablegross", "taxablenet", "annualtaxabletotal"
                        }) {
                            rPayrollTaxConguaglio[c] = rPayrollTaxRata[c];
                        }
                    }
                    aggiungiScaglioniCedolinoConguaglio(DS.payrolltaxbracket, rPayrollTaxRata, rPayrollTaxConguaglio);
                }
                aggiungiDeduzioniAlCedolinoDiConguaglio(cedConguaglioRow);
                aggiungiDetrazioniAlCedolinoDiConguaglio(cedConguaglioRow);
            }
        }

        private void aggiungiScaglioniCedolinoConguaglio(DataTable tPayrollTaxBracket, DataRow cedolinoRitenutaRata,
            DataRow parentConguaglio) {
            MetaData metaPayrollTaxBracket = MetaData.GetMetaData(this, "payrolltaxbracket");
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", cedolinoRitenutaRata["idpayroll"]);
            string filtroCedolinoCong = QHC.CmpEq("idpayroll", parentConguaglio["idpayroll"]);
            string filtroScagl = QHC.AppAnd(filtroCedolinoRata,
                QHC.CmpEq("idpayrolltax", cedolinoRitenutaRata["idpayrolltax"]));
            DataRow[] rPayRollTaxBracket = tPayrollTaxBracket.Select(filtroScagl);
            foreach (DataRow rScagl in rPayRollTaxBracket) {
                string filtroCedRitScagl = QHC.AppAnd(filtroCedolinoCong,
                    QHC.CmpEq("idpayrolltax", parentConguaglio["idpayrolltax"]));
                DataRow[] rBracket = DS.payrolltaxbracket.Select(filtroCedRitScagl);
                if (rBracket.Length > 0) {
                    foreach (string col in new string[] {"taxable", "employtax", "admintax"})
                        rBracket[0][col] = CfgFn.GetNoNullDecimal(rBracket[0][col]) +
                                           CfgFn.GetNoNullDecimal(rScagl[col]);
                }
                else {
                    DataRow newCedConguaglioRitScagl = metaPayrollTaxBracket.Get_New_Row(parentConguaglio,
                        DS.payrolltaxbracket);
                    foreach (DataColumn C in DS.payrolltaxbracket.Columns) {
                        if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")
                            || (C.ColumnName == "nbracket")) continue;
                        newCedConguaglioRitScagl[C.ColumnName] = rScagl[C.ColumnName];
                    }
                }
            }
        }

        private void aggiungiDeduzioniAlCedolinoDiConguaglio(DataRow cedConguaglioRow) {
            MetaData metaPayrollDeduction = MetaData.GetMetaData(this, "payrolldeduction");
            foreach (DataRow rPD in DS.payrolldeduction.Select()) {
                DataRow[] rDedCong = DS.payrolldeduction.Select(QHC.AppAnd(
                    QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]),
                    QHC.CmpEq("iddeduction", rPD["iddeduction"])));
                if (rDedCong.Length == 0) {
                    DataRow rpd = metaPayrollDeduction.Get_New_Row(cedConguaglioRow, DS.payrolldeduction);
                    rpd["idpayroll"] = cedConguaglioRow["idpayroll"];
                    foreach (DataColumn c in DS.payrolldeduction.Columns) {
                        if (c.ColumnName != "idpayroll") {
                            rpd[c] = rPD[c.ColumnName];
                        }
                    }
                }
                else {
                    rDedCong[0]["annualamount"] = CfgFn.GetNoNullDecimal(rDedCong[0]["annualamount"])
                                                  + CfgFn.GetNoNullDecimal(rPD["annualamount"]);
                    rDedCong[0]["curramount"] = CfgFn.GetNoNullDecimal(rDedCong[0]["curramount"])
                                                + CfgFn.GetNoNullDecimal(rPD["curramount"]);
                }
            }
        }

        private void aggiungiDetrazioniAlCedolinoDiConguaglio(DataRow cedConguaglioRow) {
            MetaData metaPayrollAbatement = MetaData.GetMetaData(this, "payrollabatement");
            foreach (DataRow rPA in DS.payrollabatement.Select()) {
                DataRow[] rDetrCong = DS.payrollabatement.Select(QHC.AppAnd(
                    QHC.CmpEq("idpayroll", cedConguaglioRow["idpayroll"]),
                    QHC.CmpEq("idabatement", rPA["idabatement"])));
                if (rDetrCong.Length == 0) {
                    DataRow rpa = metaPayrollAbatement.Get_New_Row(cedConguaglioRow, DS.payrollabatement);
                    rpa["idpayroll"] = cedConguaglioRow["idpayroll"];
                    foreach (DataColumn c in DS.payrollabatement.Columns) {
                        if (c.ColumnName != "idpayroll") {
                            rpa[c] = rPA[c.ColumnName];
                        }
                    }
                }
                else {
                    rDetrCong[0]["annualamount"] = CfgFn.GetNoNullDecimal(rDetrCong[0]["annualamount"])
                                                   + CfgFn.GetNoNullDecimal(rPA["annualamount"]);
                    rDetrCong[0]["curramount"] = CfgFn.GetNoNullDecimal(rDetrCong[0]["curramount"])
                                                 + CfgFn.GetNoNullDecimal(rPA["curramount"]);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e) {

        }

        private void btnImportaOneri_Click(object sender, EventArgs e) {
            //aggiungiDetrazionidaCudCartacei();
        }

        private void btnCambiaRuolo_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            ImpostaPosGiuridica(true);
        }

        void resetPosizioneGiuridica() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontract.Rows[0];
            Curr["idregistrylegalstatus"] = DBNull.Value;
        }



        string LastFilterPosGiuridica;

        void ClearInformazioni() {
            LastFilterPosGiuridica = "";
            txtRuoloCSA.Text = "";
            txtCompartoCSA.Text = "";
            txtInquadrcsa.Text = "";
            btnCambiaRuolo.Visible = false;
            resetPosizioneGiuridica();
            if (Meta.IsEmpty) return;
        }

        void ClearPosGiuridica() {
            LastFilterPosGiuridica = "";
            txtRuoloCSA.Text = "";
            txtCompartoCSA.Text = "";
            txtInquadrcsa.Text = "";
            btnCambiaRuolo.Visible = false;
            resetPosizioneGiuridica();
        }

        void AggiornaSoloInformazioni() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontract.Rows[0];

            string filter;
            object datainizio = Curr["start"];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                ClearPosGiuridica();
                return;
            }
            if ((datafine == DBNull.Value) || (((DateTime) datafine) == QueryCreator.EmptyDate())) {
                ClearPosGiuridica();
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                ClearPosGiuridica();
                return;
            }


            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime) datafine, true);

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                QHS.CmpLe("start", datainizio));

            if (LastFilterPosGiuridica == filter) return;

            string filtroInquadramento = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                QHS.CmpEq("idregistrylegalstatus", Curr["idregistrylegalstatus"]));
            DataTable SelClass = Meta.Conn.RUN_SELECT("registrylegalstatus",
                "idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                null, filtroInquadramento, null, false);

            if (SelClass.Rows.Count == 0) {
                ClearInformazioni();
                LastFilterPosGiuridica = filter;
                ImpostaPosGiuridica(true);
                return;
            }
            LastFilterPosGiuridica = filter;

            DataRow RowClass = SelClass.Rows[0];
            txtRuoloCSA.Text = RowClass["csa_role"].ToString();
            txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
            txtInquadrcsa.Text = RowClass["csa_class"].ToString();
        }

        private void GeneraSelect(object sender) {

            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            if (((Control) sender) == txtPercipiente) {
                ImpostaPosGiuridica(false);
            }

            if (((Control) sender) == txtDataInizio) {
                ImpostaPosGiuridica(false);
            }
            if (((Control) sender) == txtDataFine) {
                ImpostaPosGiuridica(false);
            }
        }

        /// <summary>
        /// Calcola il GroupBox PosizioneGiuridica in base alla datainizio della riga corrente
        /// </summary>
        private void ImpostaPosGiuridica(bool changerole) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.parasubcontract.Rows[0];

            string filter;

            object datainizio = Curr["start"];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];

            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                ClearPosGiuridica();
                return;
            }
            if ((datafine == DBNull.Value) || (((DateTime) datafine) == QueryCreator.EmptyDate())) {
                ClearPosGiuridica();
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                ClearPosGiuridica();
                return;
            }

            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime) datafine, true);

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio),
                QHS.NullOrGe("stop", datafine),
                QHS.IsNotNull("csa_compartment"), QHS.IsNotNull("csa_role"));

            if ((LastFilterPosGiuridica == filter) && (!changerole)) return;

            int NposGiuridiche = Meta.Conn.RUN_SELECT_COUNT("registrylegalstatus", filter, false);

            if (NposGiuridiche == 0) {
                ClearPosGiuridica();
                LastFilterPosGiuridica = filter;
                btnCambiaRuolo.Visible = false;
                return;
            }
            LastFilterPosGiuridica = filter;

            DataRow RcurrPosGiuridica = null;
            object CurrPosGiuridica = null;
            DataTable SelClass = null;
            if (NposGiuridiche > 1) {
                //Selezionare una riga
                while (true) {
                    MetaData Mregistrylegalstatus = MetaData.GetMetaData(this, "registrylegalstatus");
                    Mregistrylegalstatus.DS = DS.Copy();
                    Mregistrylegalstatus.FilterLocked = true;
                    RcurrPosGiuridica = Mregistrylegalstatus.SelectOne("anagrafica", filter, "registrylegalstatus", null);
                    if (RcurrPosGiuridica != null) break;
                }
                CurrPosGiuridica = RcurrPosGiuridica["idregistrylegalstatus"];
                SelClass = Meta.Conn.RUN_SELECT("registrylegalstatus",
                    "idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                    null,
                    QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                        QHS.CmpEq("idregistrylegalstatus", RcurrPosGiuridica["idregistrylegalstatus"])), null, false);
                btnCambiaRuolo.Visible = true;
            }
            if (NposGiuridiche == 1) {
                SelClass = Meta.Conn.RUN_SELECT("registrylegalstatus",
                    "idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                    null, filter, null, false);
                btnCambiaRuolo.Visible = false;
            }
            DataRow RowClass = SelClass.Rows[0];

            txtRuoloCSA.Text = RowClass["csa_role"].ToString();
            txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
            txtInquadrcsa.Text = RowClass["csa_class"].ToString();
            Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];
        }

        private void btnCollegaAP_Click(object sender, EventArgs e) {
            if (DS.parasubcontract.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.parasubcontract.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(Meta.Dispatcher);
            if (!AP.attivo) return;
            AP.LinkExistingDocument(Meta, Curr, Curr["idreg"]);
        }

        private void btnVoceSpesaDalia_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DataTable main = Meta.PrimaryDataTable;
            //object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");
            //if (idsorkind == null || idsorkind == DBNull.Value) {
            //    MessageBox.Show("Non è installata la classificazione per DALIA avente codice VOCISPESA", "Errore");
            //    return;
            //}
            DataRow r = main.Rows[0];
            object idser = r["idser"];
            if (idser == DBNull.Value) {
                MessageBox.Show("Occorre selezionare prima la prestazione", "Avviso");
                return;
            }
            DataRow[] classR =
                Conn.RUN_SELECT("servicesorting", "idsor", null, QHS.CmpEq("idser", idser), null, false).Select();
            string filter = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkindDalia),
                QHS.FieldIn("idsor", classR, "idsor"), QHS.CmpEq("ayear", Conn.GetEsercizio()));
            GetData.DenyClear(DS.sortingview1);
            int num = Conn.RUN_SELECT_COUNT("sortingview", filter, false);
            if (num > 0) {
                Meta.DoMainCommand("choose.sortingview1.default." + filter);
                //Il resto lo fa nell'afterrowselect, che chiama selezionaVoceSpesaDalia
            }
            else {
                MessageBox.Show("La prestazione selezionata non è associata ad alcuna classificazione DALIA", "Avviso");
            }
        }

        private void abilitaDisabilitaCCdedicato(DataRow rService) {
            if ((rService == null) && (DS.parasubcontract.Rows.Count == 0)) {
                chkCCdedicato.Enabled = true;
                return;
            }
            if ((rService == null) && (DS.parasubcontract.Rows.Count > 0)) {
                DataRow Curr = DS.parasubcontract.Rows[0];
                DataRow[] Service = DS.service.Select(QHS.CmpEq("idser", Curr["idser"]));
                if (Service.Length > 0) {
                    rService = Service[0];
                }
            }
            if (rService != null) {
                int flag = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 1;
                if (flag != 0) {
                    //CC dedicato necessario
                    chkCCdedicato.Checked = true;
                    chkCCdedicato.Enabled = true;
                }
                else {
                    chkCCdedicato.Checked = false;
                    chkCCdedicato.Enabled = false;
                }
            }
        }

        private bool DaliaAbilitato = false;
        private void abilitaDisabilitaDalia(DataRow service) {
            DaliaAbilitato = false;
            if (Meta.PrimaryDataTable.Rows.Count == 0 || idsorkindDalia == null || idsorkindDalia == DBNull.Value) {
                btnVoceSpesaDalia.Visible = false;
                btnQualificaDalia.Visible = false;
                txtVoceSpesaDalia.Visible = false;
                grpCausaliAssunzioneDalia.Visible = false;
                return;
            }
            if (service == null) {
                DataRow Curr = Meta.PrimaryDataTable.Rows[0];
                DataRow[] Service = DS.service.Select(QHS.CmpEq("idser", Curr["idser"]));
                if (Service.Length > 0) {
                    service = Service[0];
                }
            }
            if (service == null) {
                btnVoceSpesaDalia.Visible = false;
                btnQualificaDalia.Visible = false;
                txtVoceSpesaDalia.Visible = false;
                grpCausaliAssunzioneDalia.Visible = false;
                return;
            }
            DaliaAbilitato = (service["flagdalia"].ToString().ToUpperInvariant() == "S");
            btnVoceSpesaDalia.Visible = DaliaAbilitato;
            btnQualificaDalia.Visible = DaliaAbilitato;
            txtVoceSpesaDalia.Visible = DaliaAbilitato;
            grpCausaliAssunzioneDalia.Visible = DaliaAbilitato;
        }

        /// <summary>
        /// Aggiorna il codice della voce spesa
        /// </summary>
        void AggiornaVoceSpesa() {
            if (Meta.IsEmpty) {
                txtVoceSpesaDalia.Text = "";
                return;
            }
            if (idsorkindDalia == null) {
                txtVoceSpesaDalia.Text = "";
                return;
            }
            DataTable sortingT = DS.Tables[Meta.TableName + "sorting"];
            foreach (DataRow r in sortingT.Select()) {
                object idsor = r["idsor"];
                DataRow[] f =
                    DS.sorting.Select(QHC.AppAnd(QHC.CmpEq("idsor", idsor), QHC.CmpEq("idsorkind", idsorkindDalia)));
                if (f.Length > 0) {
                    txtVoceSpesaDalia.Text = f[0]["description"].ToString();
                    return;
                }
            }
            txtVoceSpesaDalia.Text = "";
        }

        void selezionaVoceSpesaDalia(object idsor) {
            if (Meta.IsEmpty) return;
            DataRow Curr = Meta.PrimaryDataTable.Rows[0];
            string filter = QHC.CmpEq("idsor", idsor);
            DataTable sortingT = DS.Tables[Meta.TableName + "sorting"];
            if (sortingT.Select(filter).Length > 0) {
                //già presente
                return;
            }

            //Cerca altre class.Dalia, ne può esistere solo una per prestaz., cancella tutte le altre
            foreach (DataRow r in sortingT.Select()) {
                object idsor2 = r["idsor"];
                DataRow[] f =
                    DS.sorting.Select(QHC.AppAnd(QHC.CmpEq("idsor", idsor2), QHC.CmpEq("idsorkind", idsorkindDalia)));
                if (f.Length > 0) {
                    r.Delete();
                }
            }


            MetaData MSor = Meta.Dispatcher.Get(sortingT.TableName);
            DataRow newClass = MSor.Get_New_Row(Curr, sortingT);
            newClass["idsor"] = idsor;
            newClass["quota"] = 1.0;
            Meta.FreshForm();

        }
        private void btnQualificaDalia_Click(object sender, EventArgs e) {
            selezionaQualificaDalia(false);
        }



        void selezionaQualificaDalia(bool quiet) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DataTable main = Meta.PrimaryDataTable;
            DataRow Curr = main.Rows[0];
            object idreg = Curr["idreg"];
            if (idreg == DBNull.Value && !quiet) {
                MessageBox.Show("Occorre selezionare prima il percipiente", "Avviso");
                return;
            }

            object datainizio = Curr["start"];
            object datafine = Curr["stop"];
            DateTime empty = QueryCreator.EmptyDate();
            if (datainizio.ToString() == empty.ToString()) datainizio = DBNull.Value;
            if (datafine.ToString() == empty.ToString()) datafine = DBNull.Value;


            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.IsNotNull("iddaliaposition"));
            if (datainizio != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.NullOrLe("start", datainizio));
            }
            if (datafine != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.NullOrGe("stop", datafine));
            }



            DataRow[] dalia =
                Conn.RUN_SELECT("registrylegalstatus", "iddaliaposition", null, filter, null, false).Select();
            if (dalia.Length == 0 && !quiet) {
                MessageBox.Show("Il percipiente selezionato non ha una qualifica Dalia negli inquadramenti", "Errore");
                return;
            }
            if (dalia.Length > 0) {
                string filterDalia = QHS.FieldIn("iddaliaposition", dalia);
                Meta.DoMainCommand("choose.dalia_position.default." + filterDalia);
                //Il resto lo fa in automatico essendo dalia_position parent della tabella principale
            }

        }

        private void dgCedoliniAltriEsercizi_DoubleClick(object sender, EventArgs e) {
            VisualizzaCedolino(dgCedoliniAltriEsercizi, "readonly_dettaglio");
        }

        private void tabCedolini_Click(object sender, EventArgs e) {

        }

        private void inserisci_CUD_Click(object sender, EventArgs e) {

        }

        private void SubEntity_rbScaglioniIRPEF_CheckedChanged(object sender, EventArgs e) {
            //se è stato inserito un CUD nel cui contratto è stata applicata un'aliquota marginale, in questo contratto NON si può applicare 
            // l'aliquota per scaglioni
            if (Meta.IsEmpty) return;
            if (Meta.EditMode) return;
            if (!SubEntity_rbScaglioniIRPEF.Checked) return;
            DataRow Curr = DS.parasubcontract.Rows[0];
            DataRow ImpCurr = DS.parasubcontractyear.Rows[0];

            object nCud = DS.exhibitedcud.Rows.Count;
            string messaggio = "";
            if (CfgFn.GetNoNullInt32(nCud) == 0) {
                return;
            }
            //idlinkedcon
            DataRow row_exhibitedcud = DS.exhibitedcud.Select()._First();
            object idlinkedcon = row_exhibitedcud["idlinkedcon"];
            
            DataTable T = Conn.RUN_SELECT("parasubcontractyear", "*", null, QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("idcon", idlinkedcon)), null, false);//filtrare anche per esercizio

            if (T == null || T.Rows.Count == 0) return;
            if (T.Rows[0]["applybrackets"].ToString().ToUpper() != "S")
                messaggio = "Nel contratto inserito come CUD è stata applicata l'aliquota marginale, pertanto adesso non si potrà applicare l'aliquota per scaglione.\n ";

            MessageBox.Show(this, messaggio, "Avviso importante", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // SubEntity_rbAliquotaMarginale.Checked = false;
        }
    }

    class InputPerCalcoloCostoTotale {
        public object codicePrestazione;
        public decimal lordoAlBeneficiario;
        public int esercizio, idPat;
        public DateTime dataInizioContratto, dataFineContratto;

        public InputPerCalcoloCostoTotale() {
        }

        public InputPerCalcoloCostoTotale(InputPerCalcoloCostoTotale y) {
            codicePrestazione = y.codicePrestazione;
            lordoAlBeneficiario = y.lordoAlBeneficiario;
            esercizio = y.esercizio;
            idPat = y.idPat;
            dataInizioContratto = y.dataInizioContratto;
            dataFineContratto = y.dataFineContratto;
        }

        public bool EqualsRicalcolaCedolini(InputPerCalcoloCostoTotale y) {
            return (y != null)
                   && (codicePrestazione.Equals(y.codicePrestazione))
                   && (lordoAlBeneficiario == y.lordoAlBeneficiario)
                   && (esercizio == y.esercizio)
                   && (dataInizioContratto == y.dataInizioContratto)
                   && (dataFineContratto == y.dataFineContratto);
        }

        public bool Equals(InputPerCalcoloCostoTotale y) {
            return (y != null)
                   && (codicePrestazione == y.codicePrestazione)
                   && (lordoAlBeneficiario == y.lordoAlBeneficiario)
                   && (esercizio == y.esercizio)
                   && (idPat == y.idPat)
                   && (dataInizioContratto == y.dataInizioContratto)
                   && (dataFineContratto == y.dataFineContratto);
        }
    }

    class InputPerGestioneCud {
        public int codCredDeb;
        public string certificateKind;
        public DateTime dataInizioContratto, dataFineContratto;

        public InputPerGestioneCud() {
        }

        public InputPerGestioneCud(InputPerGestioneCud y) {
            codCredDeb = y.codCredDeb;
            dataInizioContratto = y.dataInizioContratto;
            dataFineContratto = y.dataFineContratto;
            certificateKind = y.certificateKind;
        }

        public bool uguale(InputPerGestioneCud y) {
            return (y != null)
                   && (codCredDeb == y.codCredDeb)
                   && (dataInizioContratto == y.dataInizioContratto)
                   && (dataFineContratto == y.dataFineContratto)
                   && (certificateKind == y.certificateKind);
        }
    }
}