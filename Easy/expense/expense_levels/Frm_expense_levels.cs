
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using System.Data.SqlClient;
using System.Linq;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione
using movimentofunctions;//movimentofunctions
using gestioneclassificazioni;
using ep_functions;
using calcolooccasionale;
using chooseBill;
using q = metadatalibrary.MetaExpression;

namespace expense_levels { //spesemovimenti//
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Frm_expense_levels : MetaDataForm {

        #region dichiarazione variabili e controlli

        bool classEnabled = true;
        bool MustClose = false;
        GestioneClassificazioni ManageClassificazioni;
        private MetaData Meta;
        byte fasedefault;
        decimal DisponibileDaFasePrecedente;
        private bool dettaglioContrattiPagati = false;
        private DataAccess MyConn;
        private int fasespesamax;
        int faseentratamax;

        DataRow MissionLinked;
        DataRow MissioneMovSpesaLinked;
        int CurrCausaleMissione;
        DataTable MissioneMovSpesaViewLinked;
        bool MissionLinkedMustBeEvalued;

        DataRow CedolinoLinked;
        DataRow CedolinoMovSpesaLinked;

        int CurrCausaleCedolino;

        //DataTable CedolinoMovSpesaViewLinked;
        bool CedolinoLinkedMustBeEvalued;

        DataRow OccasionaleLinked;
        DataRow OccasionaleMovSpesaLinked;

        int CurrCausaleOccasionale;

        //DataTable OccasionaleMovSpesaViewLinked;
        bool OccasionaleLinkedMustBeEvalued;


        DataRow ProfessionaleLinked;
        DataRow ProfessionaleMovSpesaLinked;

        int CurrCausaleProfessionale;

        //DataTable ProfessionaleMovSpesaViewLinked;
        bool ProfessionaleLinkedMustBeEvalued;


        DataRow DipendenteLinked;
        DataRow DipendenteMovSpesaLinked;

        int CurrCausaleDipendente;

        //DataTable DipendenteMovSpesaViewLinked;
        bool DipendenteLinkedMustBeEvalued;

        DataRow OrdineLinked;
        DataRow OrdineGenericoMovSpesaLinked;

        int CurrCausaleOrdine;

        //DataTable OrdineGenericoMovSpesaViewLinked;
        bool OrdineLinkedMustBeEvalued;

        DataRow IvaLinked;
        DataRow IvaMovSpesaLinked;

        int CurrCausaleIva;

        //DataTable IvaMovSpesaViewLinked;
        bool IvaLinkedMustBeEvalued;

        string flagcreddeb;
        string flagbilancio;
        string flagrespons;
        string flagresidui;
        int fasemissione;
        int fasecedolino;
        int faseordine;
        int faseiva;
        int faseoccasionale;
        int faseprofessionale;
        int fasedipendente;
        bool monofase = false;

        //		private int minfasecreditore;
        //		private int minfasebilannuale;
        //		private int minfasefondo;
        private byte currphase;

        //		private int minfasebilpluriennale;
        bool ControlloSuFasiPrecEffettuato;
        bool to_mainrefresh; //true se deve essere effettuato un main refresh (dopo i post)

        bool isNumEserEdit = false;

        /// <summary>
        /// True durante il post degli automatismi, usato per non innescare un loop
        /// </summary>
        bool SecondoPostAttivo;

        bool InChiusura;
        decimal lastimportofreshed;

        GBoxManage ManageBilAnnuale;
        GBoxManage ManageUPB;
        GBoxManage ManageCreditore;


        public dsmeta DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEsercizioMovimento;
        private System.Windows.Forms.TextBox txtNumeroMovimento;
        private System.Windows.Forms.TextBox txtNumeroFasePrecedente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEsercizioFasePrecedente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnFasePrecedente;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.CheckBox SubEntity_chbCoperturaIniziativa;
        private System.Windows.Forms.CheckBox chbAzzeramento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelImporto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.TextBox txtDataDocumento;
        private System.Windows.Forms.TextBox txtDataCont;
        private System.Windows.Forms.TextBox txtImportoCorrente;
        private System.Windows.Forms.TextBox txtImportoDisponibile;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.ComboBox cmbFaseSpesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupCredDeb;
        private System.Windows.Forms.GroupBox gboxFasePrecedente;
        private System.Windows.Forms.GroupBox gboxMovimento;
        private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
        private System.Windows.Forms.DataGrid DGridClassificazioni;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnInsertClass;
        private System.Windows.Forms.Button btnDelClass;

        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtAssicurativeDip;
        private System.Windows.Forms.TextBox txtImportonettoDip;
        private System.Windows.Forms.TextBox txtAltreDip;
        private System.Windows.Forms.TextBox txtFiscaliDip;
        private System.Windows.Forms.TextBox txtPrevidenzialiDip;
        private System.Windows.Forms.TextBox txtAssistenzialiDip;
        private System.Windows.Forms.TextBox txtAssicurativeEnte;
        private System.Windows.Forms.TextBox txtCostoTotaleEnte;
        private System.Windows.Forms.TextBox txtAltreEnte;
        private System.Windows.Forms.TextBox txtPrevidenzialiEnte;
        private System.Windows.Forms.TextBox txtAssistenzialiEnte;
        private System.Windows.Forms.ComboBox SubEntity_cmbTipoprestazione;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.TextBox SubEntity_txtNumMandato;
        private System.Windows.Forms.TextBox SubEntity_txtDataFinePrest;
        private System.Windows.Forms.TextBox SubEntity_txtDataInizioPrest;
        private System.Windows.Forms.GroupBox gboxResponsabile;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.GroupBox gboxRitDipendente;
        private System.Windows.Forms.GroupBox gboxContrEnte;
        private System.Windows.Forms.Button btnSituazioneMovimentoSpesa;
        private System.Windows.Forms.Button btnEliminaRitenute;
        private System.Windows.Forms.Button btnModificaRitenute;
        private System.Windows.Forms.Button btnInserisciRitenute;
        private System.Windows.Forms.Label lblImportoDisponibile;
        private System.Windows.Forms.Button btnAutomatismiPrestazione;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
        private System.Windows.Forms.GroupBox gBoxImportiPrestazione;
        public System.Windows.Forms.TextBox SubEntity_prest1;
        private System.Windows.Forms.DataGrid griddetriten;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTipoContabilizzazione;
        private System.Windows.Forms.ComboBox cmbCausale;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Button btnDocumento;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.TextBox txtEsercDoc;
        private System.Windows.Forms.GroupBox gboxDocumento;
        private System.Windows.Forms.Label labelTipoDocumento;
        private System.Windows.Forms.Label labelCausale;
        private System.Windows.Forms.Button btnGerarchia;
        private System.Windows.Forms.TabPage tabMovFin;
        private System.Windows.Forms.TabPage tabClassSup;
        private System.Windows.Forms.TabPage tabPrest;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtRecuperiTotale;
        private System.Windows.Forms.Button btnAutomatismiRecuperi;
        private System.Windows.Forms.DataGrid dGridRecuperi;
        private System.Windows.Forms.Button btnEliminaRecuperi;
        private System.Windows.Forms.Button btnModificaRecuperi;
        private System.Windows.Forms.Button btnInserisciRecuperi;
        private System.Windows.Forms.GroupBox GBoxVariazioni;
        private System.Windows.Forms.Button btnDelVar;
        private System.Windows.Forms.Button btnEditVar;
        private System.Windows.Forms.Button btnInsertVar;
        private System.Windows.Forms.DataGrid gridVariazioni;
        private System.Windows.Forms.TabPage tabRecup;
        private System.Windows.Forms.TabPage tabVariaz;
        private System.Windows.Forms.TabPage tabPagam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox SubEntity_chkAutomPrestazione;
        private System.Windows.Forms.CheckBox SubEntity_chkAutomRecuperi;
        private System.Windows.Forms.Button btnGeneraClassAutomatiche;
        private System.Windows.Forms.Label labEsercizio;
        private System.Windows.Forms.Label labNum;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiscaliEnte;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Label labePrestGenerica;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbRecupero;
        private System.Windows.Forms.GroupBox gboxBolletta;
        private System.Windows.Forms.TextBox SubEntity_txtBolletta;
        private System.Windows.Forms.Button btnBolletta;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.Button btnAddDetMandate;
        private System.Windows.Forms.Button btnRemoveDetMandate;
        private System.Windows.Forms.GroupBox gboxDettmandate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTotMandateDetail;
        private System.Windows.Forms.Button btnEditMandDet;
        private System.Windows.Forms.DataGrid dgrDettagliOrdine;
        private NotifyIcon notifyIcon1;
        bool MustRefreshImportoSpesa = false;


        QueryHelper QHS;
        private TabPage tabPageAltro;
        private GroupBox groupBox5;
        private TextBox txtFormerNmov;
        private Label label19;
        private TextBox txtFormerYmov;
        private Label label18;
        private TabControl tabControl2;
        private TabPage tabTax;
        private TabPage tabCorrige;
        private TabPage tabOfficial;
        private Button btnInserisciCorrezione;
        private Button btnModificaCorrezione;
        private Button btnEliminaCorrezione;
        private DataGrid dgCorrige;
        private Button btnInserisciUfficiale;
        private Button btnModificaUfficiale;
        private Button btnEliminaUfficiale;
        private DataGrid dgOfficial;
        private GroupBox grpContodebito;
        private TextBox txtDescrContoSupplier;
        private TextBox txtCodiceContoSupplier;
        private Button btnContoDebito;
        private Label label20;
        private TextBox txtApplierAnnotations;
        private Label lblcup;
        private TextBox txtcup;
        private Label lblcig;
        private TextBox txtcig;
        private TabPage tabFinanziamenti;
        private GroupBox gboxFinCassa;
        private Button button2;
        private Button btnCercaFinanziamentoCassa;
        private DataGrid dataGrid1;
        private TextBox txtTotFinanziatoCassa;
        private Button button5;
        private Label label21;
        private Button button6;
        private GroupBox gboxFinCompetenza;
        private Button btnAddFinanziamento;
        private Button btnCercaFinanziamentoCrediti;
        private DataGrid dgridFinanziamenti;
        private TextBox txtTotFinanziatoCrediti;
        private Button btnEditFinanziamento;
        private Label label22;
        private Button btnDeleteFinanziamento;
        private TabControl tabModPagamento;
        private TabPage tabInfoModPagamento;
        private CheckBox SubEntity_chkEsenteSpese;
        private GroupBox groupBox12;
        private Label label24;
        private TextBox SubEntity_txtExtraCode;
        private Label label23;
        private TextBox SubEntity_txtBiccode;
        private Label lblCommento;
        private TextBox txtModPagamento;
        private Button btnSelModalita;
        private Label label11;
        private TextBox SubEntity_txtIBAN;
        private Button btnModEstinzione;
        private TextBox SubEntity_txtRifDocumentoEsterno;
        private Label label9;
        private TextBox SubEntity_txtDelegato;
        private Label label7;
        private ComboBox SubEntity_cmbModPagamento;
        private Label label38;
        private TextBox SubEntity_txtDescrModPagamento;
        private Label label40;
        private Label label32;
        private Label label35;
        private Label label36;
        private Label label37;
        private TextBox SubEntity_txtContoCorrente;
        private TextBox SubEntity_txtSportello;
        private TextBox SubEntity_txtBanca;
        private TextBox SubEntity_txtCin;
        private TabPage tabOpzioniModPagamento;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox8;
        private CheckBox chkObbligoCoordBanc;
        private CheckBox chkDivietoCoordBanc;
        private CheckBox chkContoCorrPostale;
        private CheckBox chkDelegato;
        private CheckBox chkStampaAvviso;
        public TextBox txtResponsabile;
        public TextBox txtUPB;
        private GroupBox gboxBilAnnuale;
        private CheckBox chkListTitle;
        private CheckBox chkListManager;
        private CheckBox chkFilterAvailable;
        private Button btnBilancio;
        private TextBox txtCodiceBilancio;
        private TextBox txtDenominazioneBilancio;
        private GroupBox groupBox10;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private Button btnAltreBollette;
        private TabPage tabPage1;
        private DataGrid dgridBollette;
        private Button btnAddBolletta;
        private Button btnDelBolletta;
        private Button btnEditBolletta;
        private Label labBollette2;
        private Label labBollette1;
        private Button btnMultipleBillSel;
        private ComboBox SubEntity_cmbChargeHandling;
        private Label label26;
        private Button btnAggiornaRecupero;
        private Label label27;
        private TextBox textBox7;
        private GroupBox grpCertificatiNecessari;
        private CheckBox SubEntity_chkDurc;
        private CheckBox SubEntity_chkVisura;
        private CheckBox SubEntity_chkCCdedicato;
        private Button btnAggiornaCertificati;
		private Label lblAvvisoPagoPa;
		private TextBox SubEntity_txtAvvisoPagoPa;
        private TextBox txtTotaleSospesi;
        private Label label29;
        private Button btnScrittureCollegate;
        private CheckBox chkElenchiEp;
        private GroupBox gboxEntrata;
        private TextBox txtNumEntrata;
        private Label label31;
        private TextBox txtEsercEntrata;
        private Label label39;
        private Button btnEntrata;
        private TabPage tabFatture;
        private GroupBox gboxDettInvoice;
        private Button btnEditInvDet;
        private TextBox txtTotInvoiceDetail;
        private Label label17;
        private Button btnRemoveDettInvoice;
        private Button btnAddDettInvoice;
        private DataGrid dgrDettagliFattura;
        private GroupBox gboxIncassoDettContratti;
        private Button btnCollegaDettagliContratto;
        private Button button3;
        private TextBox txtTotDettPagamenti;
        private Label label30;
        private Button button4;
        private DataGrid gridDettPagamenti;
        private Button btnAdd;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioGiud;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkVerificaAnac;
		private CheckBox chkRegolaritaFisc;
		private CheckBox chkPattoIntegrita;
		CQueryHelper QHC;
        

        #endregion dichiarazione variabili e controlli

        public Frm_expense_levels() {
            InitializeComponent();
            ResetMissione();
            ResetOrdine();
            ResetProfessionale();
            ResetOccasionale();
            ResetCedolino();
            ResetIva();
            ControlloSuFasiPrecEffettuato = false;
            InChiusura = false;

            InitPosGiuridicaSystem();

            GetData.SetSorting(DS.expensephase, "nphase");
            //GetData.SetSorting(DS.sortingkind,"sortinglevel, description");
            GetData.SetSorting(DS.expensemandate, "yman desc,nman desc");
            GetData.SetSorting(DS.upb, "codeupb asc");
            GetData.SetSorting(DS.bill, "nbill desc");
            GetData.SetSorting(DS.billview, "nbill desc");
            DataAccess.SetTableForReading(DS.deputy, "registry");
            DataAccess.SetTableForReading(DS.underwriting_var, "underwriting");
            DataAccess.SetTableForReading(DS.bill1, "bill");
            DS.expensesorted.ExtendedProperties["gridmaster"] = "sortingkind";
            GetData.SetSorting(DS.registrypaymethod, " flagstandard  DESC, regmodcode  ASC");
            GetData.MarkToAddBlankRow(DS.registrypaymethod);
            GetData.MarkToAddBlankRow(DS.chargehandling);
            DataAccess.SetTableForReading(DS.clawback_expense, "clawback");
            DataAccess.SetTableForReading(DS.formerexpense, "expense");
            DataAccess.SetTableForReading(DS.mandatedetail_iva, "mandatedetailview");
            DataAccess.SetTableForReading(DS.mandatedetail_taxable, "mandatedetailview");
            QueryCreator.SetTableForPosting(DS.mandatedetail_iva, "mandatedetail");
            QueryCreator.SetTableForPosting(DS.mandatedetail_taxable, "mandatedetail");
            DataAccess.SetTableForReading(DS.invoicedetail_iva, "invoicedetailview");
            DataAccess.SetTableForReading(DS.invoicedetail_taxable, "invoicedetailview");
            QueryCreator.SetTableForPosting(DS.invoicedetail_iva, "invoicedetail");
            QueryCreator.SetTableForPosting(DS.invoicedetail_taxable, "invoicedetail");
            DataAccess.SetTableForReading(DS.invoicedetail_iva_nc, "invoicedetail");
            DataAccess.SetTableForReading(DS.invoicedetail_taxable_nc, "invoicedetail");
            QueryCreator.SetTableForPosting(DS.invoicedetail_iva_nc, "invoicedetail");
            QueryCreator.SetTableForPosting(DS.invoicedetail_taxable_nc, "invoicedetail");
            DataAccess.SetTableForReading(DS.mandatedetail_pagamenti, "mandatedetail");
            GetData.SetSorting(DS.mandatedetail_iva, "idgroup");
            GetData.SetSorting(DS.mandatedetail_taxable, "idgroup");

            //			currphase = 1;
            //			fasespesamax = 2;			
            SecondoPostAttivo = false;
            to_mainrefresh = false;

            ResetTipoClassAvailableEvalued();

            tabControl1.SelectedIndex = 0;
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

                MetaData.messageBroadcaster -= MetaData_messageBroadcaster;
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_expense_levels));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblImportoDisponibile = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
			this.txtImportoCorrente = new System.Windows.Forms.TextBox();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataCont = new System.Windows.Forms.TextBox();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
			this.labelImporto = new System.Windows.Forms.Label();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.chbAzzeramento = new System.Windows.Forms.CheckBox();
			this.SubEntity_chbCoperturaIniziativa = new System.Windows.Forms.CheckBox();
			this.gboxFasePrecedente = new System.Windows.Forms.GroupBox();
			this.btnFasePrecedente = new System.Windows.Forms.Button();
			this.txtNumeroFasePrecedente = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEsercizioFasePrecedente = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.gboxMovimento = new System.Windows.Forms.GroupBox();
			this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbFaseSpesa = new System.Windows.Forms.ComboBox();
			this.DS = new expense_levels.dsmeta();
			this.btnSituazioneMovimentoSpesa = new System.Windows.Forms.Button();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtNumMandato = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.SubEntity_chkAutomPrestazione = new System.Windows.Forms.CheckBox();
			this.btnAutomatismiPrestazione = new System.Windows.Forms.Button();
			this.btnEliminaRitenute = new System.Windows.Forms.Button();
			this.btnModificaRitenute = new System.Windows.Forms.Button();
			this.btnInserisciRitenute = new System.Windows.Forms.Button();
			this.SubEntity_txtDataFinePrest = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.SubEntity_txtDataInizioPrest = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.gboxRitDipendente = new System.Windows.Forms.GroupBox();
			this.txtAssicurativeDip = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.txtImportonettoDip = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.txtAltreDip = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.txtFiscaliDip = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.txtPrevidenzialiDip = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.txtAssistenzialiDip = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.griddetriten = new System.Windows.Forms.DataGrid();
			this.gboxContrEnte = new System.Windows.Forms.GroupBox();
			this.label50 = new System.Windows.Forms.Label();
			this.txtFiscaliEnte = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAssicurativeEnte = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.txtCostoTotaleEnte = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.txtAltreEnte = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.txtPrevidenzialiEnte = new System.Windows.Forms.TextBox();
			this.txtAssistenzialiEnte = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.btnDelClass = new System.Windows.Forms.Button();
			this.btnEditClass = new System.Windows.Forms.Button();
			this.btnInsertClass = new System.Windows.Forms.Button();
			this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
			this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGerarchia = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbTipoContabilizzazione = new System.Windows.Forms.ComboBox();
			this.gboxDocumento = new System.Windows.Forms.GroupBox();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.labEsercizio = new System.Windows.Forms.Label();
			this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.labNum = new System.Windows.Forms.Label();
			this.labelTipoDocumento = new System.Windows.Forms.Label();
			this.labelCausale = new System.Windows.Forms.Label();
			this.gBoxImportiPrestazione = new System.Windows.Forms.GroupBox();
			this.SubEntity_prest1 = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabMovFin = new System.Windows.Forms.TabPage();
			this.chkElenchiEp = new System.Windows.Forms.CheckBox();
			this.btnScrittureCollegate = new System.Windows.Forms.Button();
			this.btnAltreBollette = new System.Windows.Forms.Button();
			this.gboxBolletta = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtBolletta = new System.Windows.Forms.TextBox();
			this.btnBolletta = new System.Windows.Forms.Button();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
			this.chkListTitle = new System.Windows.Forms.CheckBox();
			this.chkListManager = new System.Windows.Forms.CheckBox();
			this.chkFilterAvailable = new System.Windows.Forms.CheckBox();
			this.btnBilancio = new System.Windows.Forms.Button();
			this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
			this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.tabClassSup = new System.Windows.Forms.TabPage();
			this.btnGeneraClassAutomatiche = new System.Windows.Forms.Button();
			this.tabPageAltro = new System.Windows.Forms.TabPage();
			this.gboxEntrata = new System.Windows.Forms.GroupBox();
			this.txtNumEntrata = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.txtEsercEntrata = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.btnEntrata = new System.Windows.Forms.Button();
			this.label27 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.lblcig = new System.Windows.Forms.Label();
			this.txtcig = new System.Windows.Forms.TextBox();
			this.lblcup = new System.Windows.Forms.Label();
			this.txtcup = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtApplierAnnotations = new System.Windows.Forms.TextBox();
			this.grpContodebito = new System.Windows.Forms.GroupBox();
			this.txtDescrContoSupplier = new System.Windows.Forms.TextBox();
			this.txtCodiceContoSupplier = new System.Windows.Forms.TextBox();
			this.btnContoDebito = new System.Windows.Forms.Button();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtFormerNmov = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtFormerYmov = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFisc = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkDurc = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkVisura = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.btnAggiornaCertificati = new System.Windows.Forms.Button();
			this.tabPrest = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabTax = new System.Windows.Forms.TabPage();
			this.tabCorrige = new System.Windows.Forms.TabPage();
			this.btnInserisciCorrezione = new System.Windows.Forms.Button();
			this.btnModificaCorrezione = new System.Windows.Forms.Button();
			this.btnEliminaCorrezione = new System.Windows.Forms.Button();
			this.dgCorrige = new System.Windows.Forms.DataGrid();
			this.tabOfficial = new System.Windows.Forms.TabPage();
			this.btnInserisciUfficiale = new System.Windows.Forms.Button();
			this.btnModificaUfficiale = new System.Windows.Forms.Button();
			this.btnEliminaUfficiale = new System.Windows.Forms.Button();
			this.dgOfficial = new System.Windows.Forms.DataGrid();
			this.labePrestGenerica = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.SubEntity_cmbTipoprestazione = new System.Windows.Forms.ComboBox();
			this.tabDetails = new System.Windows.Forms.TabPage();
			this.gboxIncassoDettContratti = new System.Windows.Forms.GroupBox();
			this.btnCollegaDettagliContratto = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.txtTotDettPagamenti = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.gridDettPagamenti = new System.Windows.Forms.DataGrid();
			this.btnAdd = new System.Windows.Forms.Button();
			this.gboxDettmandate = new System.Windows.Forms.GroupBox();
			this.btnEditMandDet = new System.Windows.Forms.Button();
			this.txtTotMandateDetail = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.btnRemoveDetMandate = new System.Windows.Forms.Button();
			this.dgrDettagliOrdine = new System.Windows.Forms.DataGrid();
			this.btnAddDetMandate = new System.Windows.Forms.Button();
			this.tabPagam = new System.Windows.Forms.TabPage();
			this.tabModPagamento = new System.Windows.Forms.TabControl();
			this.tabInfoModPagamento = new System.Windows.Forms.TabPage();
			this.lblAvvisoPagoPa = new System.Windows.Forms.Label();
			this.SubEntity_txtAvvisoPagoPa = new System.Windows.Forms.TextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.label26 = new System.Windows.Forms.Label();
			this.SubEntity_cmbChargeHandling = new System.Windows.Forms.ComboBox();
			this.SubEntity_chkEsenteSpese = new System.Windows.Forms.CheckBox();
			this.label24 = new System.Windows.Forms.Label();
			this.SubEntity_txtExtraCode = new System.Windows.Forms.TextBox();
			this.lblCommento = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.SubEntity_txtBiccode = new System.Windows.Forms.TextBox();
			this.txtModPagamento = new System.Windows.Forms.TextBox();
			this.btnSelModalita = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.SubEntity_txtIBAN = new System.Windows.Forms.TextBox();
			this.btnModEstinzione = new System.Windows.Forms.Button();
			this.SubEntity_txtRifDocumentoEsterno = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.SubEntity_txtDelegato = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SubEntity_cmbModPagamento = new System.Windows.Forms.ComboBox();
			this.label38 = new System.Windows.Forms.Label();
			this.SubEntity_txtDescrModPagamento = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.SubEntity_txtContoCorrente = new System.Windows.Forms.TextBox();
			this.SubEntity_txtSportello = new System.Windows.Forms.TextBox();
			this.SubEntity_txtBanca = new System.Windows.Forms.TextBox();
			this.SubEntity_txtCin = new System.Windows.Forms.TextBox();
			this.tabOpzioniModPagamento = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.chkObbligoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkDivietoCoordBanc = new System.Windows.Forms.CheckBox();
			this.chkContoCorrPostale = new System.Windows.Forms.CheckBox();
			this.chkDelegato = new System.Windows.Forms.CheckBox();
			this.chkStampaAvviso = new System.Windows.Forms.CheckBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label29 = new System.Windows.Forms.Label();
			this.txtTotaleSospesi = new System.Windows.Forms.TextBox();
			this.btnMultipleBillSel = new System.Windows.Forms.Button();
			this.labBollette2 = new System.Windows.Forms.Label();
			this.labBollette1 = new System.Windows.Forms.Label();
			this.btnAddBolletta = new System.Windows.Forms.Button();
			this.btnDelBolletta = new System.Windows.Forms.Button();
			this.btnEditBolletta = new System.Windows.Forms.Button();
			this.dgridBollette = new System.Windows.Forms.DataGrid();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabRecup = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btnAggiornaRecupero = new System.Windows.Forms.Button();
			this.dGridRecuperi = new System.Windows.Forms.DataGrid();
			this.label25 = new System.Windows.Forms.Label();
			this.txtRecuperiTotale = new System.Windows.Forms.TextBox();
			this.btnEliminaRecuperi = new System.Windows.Forms.Button();
			this.btnModificaRecuperi = new System.Windows.Forms.Button();
			this.btnInserisciRecuperi = new System.Windows.Forms.Button();
			this.SubEntity_chkAutomRecuperi = new System.Windows.Forms.CheckBox();
			this.btnAutomatismiRecuperi = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbRecupero = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tabFinanziamenti = new System.Windows.Forms.TabPage();
			this.gboxFinCassa = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnCercaFinanziamentoCassa = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtTotFinanziatoCassa = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.gboxFinCompetenza = new System.Windows.Forms.GroupBox();
			this.btnAddFinanziamento = new System.Windows.Forms.Button();
			this.btnCercaFinanziamentoCrediti = new System.Windows.Forms.Button();
			this.dgridFinanziamenti = new System.Windows.Forms.DataGrid();
			this.txtTotFinanziatoCrediti = new System.Windows.Forms.TextBox();
			this.btnEditFinanziamento = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.btnDeleteFinanziamento = new System.Windows.Forms.Button();
			this.tabVariaz = new System.Windows.Forms.TabPage();
			this.GBoxVariazioni = new System.Windows.Forms.GroupBox();
			this.btnDelVar = new System.Windows.Forms.Button();
			this.btnEditVar = new System.Windows.Forms.Button();
			this.btnInsertVar = new System.Windows.Forms.Button();
			this.gridVariazioni = new System.Windows.Forms.DataGrid();
			this.tabFatture = new System.Windows.Forms.TabPage();
			this.gboxDettInvoice = new System.Windows.Forms.GroupBox();
			this.btnEditInvDet = new System.Windows.Forms.Button();
			this.txtTotInvoiceDetail = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnRemoveDettInvoice = new System.Windows.Forms.Button();
			this.btnAddDettInvoice = new System.Windows.Forms.Button();
			this.dgrDettagliFattura = new System.Windows.Forms.DataGrid();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.chkPattoIntegrita = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.gboxFasePrecedente.SuspendLayout();
			this.gboxMovimento.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox9.SuspendLayout();
			this.gboxRitDipendente.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.griddetriten)).BeginInit();
			this.gboxContrEnte.SuspendLayout();
			this.groupBox15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
			this.gboxDocumento.SuspendLayout();
			this.gBoxImportiPrestazione.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabMovFin.SuspendLayout();
			this.gboxBolletta.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.gboxBilAnnuale.SuspendLayout();
			this.tabClassSup.SuspendLayout();
			this.tabPageAltro.SuspendLayout();
			this.gboxEntrata.SuspendLayout();
			this.grpContodebito.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.tabPrest.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabTax.SuspendLayout();
			this.tabCorrige.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgCorrige)).BeginInit();
			this.tabOfficial.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgOfficial)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabDetails.SuspendLayout();
			this.gboxIncassoDettContratti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettPagamenti)).BeginInit();
			this.gboxDettmandate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliOrdine)).BeginInit();
			this.tabPagam.SuspendLayout();
			this.tabModPagamento.SuspendLayout();
			this.tabInfoModPagamento.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.tabOpzioniModPagamento.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).BeginInit();
			this.tabRecup.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridRecuperi)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.tabFinanziamenti.SuspendLayout();
			this.gboxFinCassa.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.gboxFinCompetenza.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridFinanziamenti)).BeginInit();
			this.tabVariaz.SuspendLayout();
			this.GBoxVariazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridVariazioni)).BeginInit();
			this.tabFatture.SuspendLayout();
			this.gboxDettInvoice.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.lblImportoDisponibile);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtImportoDisponibile);
			this.groupBox1.Controls.Add(this.txtImportoCorrente);
			this.groupBox1.Location = new System.Drawing.Point(427, 318);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(447, 64);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
			// 
			// lblImportoDisponibile
			// 
			this.lblImportoDisponibile.Location = new System.Drawing.Point(8, 40);
			this.lblImportoDisponibile.Name = "lblImportoDisponibile";
			this.lblImportoDisponibile.Size = new System.Drawing.Size(192, 20);
			this.lblImportoDisponibile.TabIndex = 0;
			this.lblImportoDisponibile.Text = "Disponibile:";
			this.lblImportoDisponibile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 12);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(200, 24);
			this.label12.TabIndex = 0;
			this.label12.Text = "Attuale (comprensivo delle variazioni):";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoDisponibile
			// 
			this.txtImportoDisponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoDisponibile.Location = new System.Drawing.Point(208, 40);
			this.txtImportoDisponibile.Name = "txtImportoDisponibile";
			this.txtImportoDisponibile.Size = new System.Drawing.Size(235, 20);
			this.txtImportoDisponibile.TabIndex = 0;
			this.txtImportoDisponibile.TabStop = false;
			this.txtImportoDisponibile.Tag = "expensetotal.available?expenseview.available";
			// 
			// txtImportoCorrente
			// 
			this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoCorrente.Location = new System.Drawing.Point(208, 16);
			this.txtImportoCorrente.Name = "txtImportoCorrente";
			this.txtImportoCorrente.Size = new System.Drawing.Size(235, 20);
			this.txtImportoCorrente.TabIndex = 0;
			this.txtImportoCorrente.TabStop = false;
			this.txtImportoCorrente.Tag = "expensetotal.curramount?expenseview.curramount";
			// 
			// groupBox20
			// 
			this.groupBox20.Controls.Add(this.label15);
			this.groupBox20.Controls.Add(this.txtDataCont);
			this.groupBox20.Controls.Add(this.txtScadenza);
			this.groupBox20.Controls.Add(this.label13);
			this.groupBox20.Location = new System.Drawing.Point(10, 382);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(413, 40);
			this.groupBox20.TabIndex = 9;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Data";
			this.groupBox20.Enter += new System.EventHandler(this.groupBox20_Enter);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(2, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 20);
			this.label15.TabIndex = 0;
			this.label15.Text = "Contabile";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataCont
			// 
			this.txtDataCont.Location = new System.Drawing.Point(58, 16);
			this.txtDataCont.Name = "txtDataCont";
			this.txtDataCont.Size = new System.Drawing.Size(72, 20);
			this.txtDataCont.TabIndex = 1;
			this.txtDataCont.Tag = "expense.adate";
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(232, 16);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(72, 20);
			this.txtScadenza.TabIndex = 2;
			this.txtScadenza.Tag = "expense.expiration";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(160, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 20);
			this.label13.TabIndex = 0;
			this.label13.Text = "Scadenza:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox19
			// 
			this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox19.Controls.Add(this.txtDocumento);
			this.groupBox19.Controls.Add(this.label10);
			this.groupBox19.Controls.Add(this.txtDataDocumento);
			this.groupBox19.Controls.Add(this.label14);
			this.groupBox19.Location = new System.Drawing.Point(427, 262);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(447, 56);
			this.groupBox19.TabIndex = 13;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Documento collegato";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(8, 32);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(200, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "expense.doc";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 14);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(88, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "Descrizione";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDocumento.Location = new System.Drawing.Point(232, 32);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(211, 20);
			this.txtDataDocumento.TabIndex = 2;
			this.txtDataDocumento.Tag = "expense.docdate";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(232, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 18);
			this.label14.TabIndex = 0;
			this.label14.Text = "Data";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
			this.groupBox18.Controls.Add(this.labelImporto);
			this.groupBox18.Location = new System.Drawing.Point(8, 80);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(413, 40);
			this.groupBox18.TabIndex = 4;
			this.groupBox18.TabStop = false;
			// 
			// SubEntity_txtImportoMovimento
			// 
			this.SubEntity_txtImportoMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(294, 13);
			this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
			this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtImportoMovimento.TabIndex = 1;
			this.SubEntity_txtImportoMovimento.Tag = "expenseyear.amount?expenseview.ayearstartamount.c";
			this.SubEntity_txtImportoMovimento.Leave += new System.EventHandler(this.SubEntity_txtImportoMovimento_Leave);
			// 
			// labelImporto
			// 
			this.labelImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelImporto.Location = new System.Drawing.Point(180, 14);
			this.labelImporto.Name = "labelImporto";
			this.labelImporto.Size = new System.Drawing.Size(108, 20);
			this.labelImporto.TabIndex = 0;
			this.labelImporto.Text = "Importo originale:";
			this.labelImporto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox17
			// 
			this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox17.Controls.Add(this.txtDescrizione);
			this.groupBox17.Location = new System.Drawing.Point(427, 3);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(447, 85);
			this.groupBox17.TabIndex = 3;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(431, 63);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "expense.description";
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(8, 121);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(413, 40);
			this.gboxResponsabile.TabIndex = 6;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(402, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(427, 94);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(447, 40);
			this.groupCredDeb.TabIndex = 5;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.groupCredDeb.Text = "Percipiente";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(432, 20);
			this.txtCredDeb.TabIndex = 1;
			this.txtCredDeb.Tag = "registry.title?x";
			// 
			// chbAzzeramento
			// 
			this.chbAzzeramento.Location = new System.Drawing.Point(12, 428);
			this.chbAzzeramento.Name = "chbAzzeramento";
			this.chbAzzeramento.Size = new System.Drawing.Size(296, 16);
			this.chbAzzeramento.TabIndex = 15;
			this.chbAzzeramento.Tag = "";
			this.chbAzzeramento.Text = "Azzera il disponibile di tutti i mov. fin. precedenti";
			// 
			// SubEntity_chbCoperturaIniziativa
			// 
			this.SubEntity_chbCoperturaIniziativa.Enabled = false;
			this.SubEntity_chbCoperturaIniziativa.Location = new System.Drawing.Point(429, 424);
			this.SubEntity_chbCoperturaIniziativa.Name = "SubEntity_chbCoperturaIniziativa";
			this.SubEntity_chbCoperturaIniziativa.Size = new System.Drawing.Size(304, 24);
			this.SubEntity_chbCoperturaIniziativa.TabIndex = 16;
			this.SubEntity_chbCoperturaIniziativa.Tag = "expenselast.flag:0?expenseview.flag:0";
			this.SubEntity_chbCoperturaIniziativa.Text = "Regolarizza disposizione di pagamento gi� effettuata";
			this.SubEntity_chbCoperturaIniziativa.CheckedChanged += new System.EventHandler(this.chbCoperturaIniziativa_CheckedChanged);
			// 
			// gboxFasePrecedente
			// 
			this.gboxFasePrecedente.Controls.Add(this.btnFasePrecedente);
			this.gboxFasePrecedente.Controls.Add(this.txtNumeroFasePrecedente);
			this.gboxFasePrecedente.Controls.Add(this.label5);
			this.gboxFasePrecedente.Controls.Add(this.txtEsercizioFasePrecedente);
			this.gboxFasePrecedente.Controls.Add(this.label6);
			this.gboxFasePrecedente.Location = new System.Drawing.Point(8, 40);
			this.gboxFasePrecedente.Name = "gboxFasePrecedente";
			this.gboxFasePrecedente.Size = new System.Drawing.Size(413, 40);
			this.gboxFasePrecedente.TabIndex = 2;
			this.gboxFasePrecedente.TabStop = false;
			this.gboxFasePrecedente.Text = "Fase precedente";
			this.gboxFasePrecedente.Visible = false;
			// 
			// btnFasePrecedente
			// 
			this.btnFasePrecedente.Location = new System.Drawing.Point(5, 16);
			this.btnFasePrecedente.Name = "btnFasePrecedente";
			this.btnFasePrecedente.Size = new System.Drawing.Size(230, 20);
			this.btnFasePrecedente.TabIndex = 0;
			this.btnFasePrecedente.TabStop = false;
			this.btnFasePrecedente.Text = "Impegno:";
			this.btnFasePrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFasePrecedente.Click += new System.EventHandler(this.btnFasePrecedente_Click);
			// 
			// txtNumeroFasePrecedente
			// 
			this.txtNumeroFasePrecedente.Location = new System.Drawing.Point(335, 16);
			this.txtNumeroFasePrecedente.Name = "txtNumeroFasePrecedente";
			this.txtNumeroFasePrecedente.Size = new System.Drawing.Size(60, 20);
			this.txtNumeroFasePrecedente.TabIndex = 2;
			this.txtNumeroFasePrecedente.Text = "12345678";
			this.txtNumeroFasePrecedente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumeroFasePrecedente.Leave += new System.EventHandler(this.txtNumeroFasePrecedente_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(301, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Num:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioFasePrecedente
			// 
			this.txtEsercizioFasePrecedente.Location = new System.Drawing.Point(264, 16);
			this.txtEsercizioFasePrecedente.Name = "txtEsercizioFasePrecedente";
			this.txtEsercizioFasePrecedente.Size = new System.Drawing.Size(34, 20);
			this.txtEsercizioFasePrecedente.TabIndex = 1;
			this.txtEsercizioFasePrecedente.Text = "1234";
			this.txtEsercizioFasePrecedente.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(231, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Es.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxMovimento
			// 
			this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
			this.gboxMovimento.Controls.Add(this.label3);
			this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
			this.gboxMovimento.Controls.Add(this.label2);
			this.gboxMovimento.Controls.Add(this.cmbFaseSpesa);
			this.gboxMovimento.Location = new System.Drawing.Point(8, 0);
			this.gboxMovimento.Name = "gboxMovimento";
			this.gboxMovimento.Size = new System.Drawing.Size(413, 40);
			this.gboxMovimento.TabIndex = 1;
			this.gboxMovimento.TabStop = false;
			this.gboxMovimento.Text = "Movimento";
			// 
			// txtNumeroMovimento
			// 
			this.txtNumeroMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumeroMovimento.Location = new System.Drawing.Point(349, 16);
			this.txtNumeroMovimento.Name = "txtNumeroMovimento";
			this.txtNumeroMovimento.Size = new System.Drawing.Size(60, 20);
			this.txtNumeroMovimento.TabIndex = 3;
			this.txtNumeroMovimento.Tag = "expense.nmov";
			this.txtNumeroMovimento.Text = "12345678";
			this.txtNumeroMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(317, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Num.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioMovimento
			// 
			this.txtEsercizioMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercizioMovimento.Location = new System.Drawing.Point(280, 16);
			this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
			this.txtEsercizioMovimento.Size = new System.Drawing.Size(34, 20);
			this.txtEsercizioMovimento.TabIndex = 2;
			this.txtEsercizioMovimento.Tag = "expense.ymov.year";
			this.txtEsercizioMovimento.Text = "1234";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(253, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(26, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Es.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbFaseSpesa
			// 
			this.cmbFaseSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFaseSpesa.DataSource = this.DS.expensephase;
			this.cmbFaseSpesa.DisplayMember = "description";
			this.cmbFaseSpesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFaseSpesa.Location = new System.Drawing.Point(4, 16);
			this.cmbFaseSpesa.Name = "cmbFaseSpesa";
			this.cmbFaseSpesa.Size = new System.Drawing.Size(243, 21);
			this.cmbFaseSpesa.TabIndex = 1;
			this.cmbFaseSpesa.Tag = "expense.nphase";
			this.cmbFaseSpesa.ValueMember = "nphase";
			// 
			// DS
			// 
			this.DS.DataSetName = "dsmeta";
			// 
			// btnSituazioneMovimentoSpesa
			// 
			this.btnSituazioneMovimentoSpesa.Location = new System.Drawing.Point(313, 450);
			this.btnSituazioneMovimentoSpesa.Name = "btnSituazioneMovimentoSpesa";
			this.btnSituazioneMovimentoSpesa.Size = new System.Drawing.Size(96, 22);
			this.btnSituazioneMovimentoSpesa.TabIndex = 17;
			this.btnSituazioneMovimentoSpesa.TabStop = false;
			this.btnSituazioneMovimentoSpesa.Text = "Situazione";
			this.btnSituazioneMovimentoSpesa.Click += new System.EventHandler(this.btnSituazioneMovimentoSpesa_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.SubEntity_txtNumMandato);
			this.groupBox9.Controls.Add(this.label28);
			this.groupBox9.Location = new System.Drawing.Point(8, 8);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(160, 56);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Mandato di pagamento";
			// 
			// SubEntity_txtNumMandato
			// 
			this.SubEntity_txtNumMandato.Location = new System.Drawing.Point(75, 20);
			this.SubEntity_txtNumMandato.Name = "SubEntity_txtNumMandato";
			this.SubEntity_txtNumMandato.Size = new System.Drawing.Size(64, 20);
			this.SubEntity_txtNumMandato.TabIndex = 2;
			this.SubEntity_txtNumMandato.Tag = "payment.npay?expenseview.npay";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(21, 24);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 13;
			this.label28.Text = "Numero:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_chkAutomPrestazione
			// 
			this.SubEntity_chkAutomPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SubEntity_chkAutomPrestazione.Location = new System.Drawing.Point(16, 469);
			this.SubEntity_chkAutomPrestazione.Name = "SubEntity_chkAutomPrestazione";
			this.SubEntity_chkAutomPrestazione.Size = new System.Drawing.Size(256, 16);
			this.SubEntity_chkAutomPrestazione.TabIndex = 12;
			this.SubEntity_chkAutomPrestazione.Tag = "expenselast.flag:1?expenseview.flag:1";
			this.SubEntity_chkAutomPrestazione.Text = "Gli automatismi SONO GIA\' STATI  generati ";
			// 
			// btnAutomatismiPrestazione
			// 
			this.btnAutomatismiPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutomatismiPrestazione.Location = new System.Drawing.Point(734, 467);
			this.btnAutomatismiPrestazione.Name = "btnAutomatismiPrestazione";
			this.btnAutomatismiPrestazione.Size = new System.Drawing.Size(130, 23);
			this.btnAutomatismiPrestazione.TabIndex = 13;
			this.btnAutomatismiPrestazione.TabStop = false;
			this.btnAutomatismiPrestazione.Text = "Visualizza automatismi";
			this.btnAutomatismiPrestazione.Click += new System.EventHandler(this.btnAutomatismiPrestazione_Click);
			// 
			// btnEliminaRitenute
			// 
			this.btnEliminaRitenute.Location = new System.Drawing.Point(182, 6);
			this.btnEliminaRitenute.Name = "btnEliminaRitenute";
			this.btnEliminaRitenute.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaRitenute.TabIndex = 9;
			this.btnEliminaRitenute.TabStop = false;
			this.btnEliminaRitenute.Tag = "delete";
			this.btnEliminaRitenute.Text = "Elimina";
			// 
			// btnModificaRitenute
			// 
			this.btnModificaRitenute.Location = new System.Drawing.Point(94, 6);
			this.btnModificaRitenute.Name = "btnModificaRitenute";
			this.btnModificaRitenute.Size = new System.Drawing.Size(75, 23);
			this.btnModificaRitenute.TabIndex = 8;
			this.btnModificaRitenute.TabStop = false;
			this.btnModificaRitenute.Tag = "edit.default";
			this.btnModificaRitenute.Text = "Modifica...";
			// 
			// btnInserisciRitenute
			// 
			this.btnInserisciRitenute.Location = new System.Drawing.Point(6, 6);
			this.btnInserisciRitenute.Name = "btnInserisciRitenute";
			this.btnInserisciRitenute.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciRitenute.TabIndex = 7;
			this.btnInserisciRitenute.TabStop = false;
			this.btnInserisciRitenute.Tag = "insert.default";
			this.btnInserisciRitenute.Text = "Inserisci...";
			// 
			// SubEntity_txtDataFinePrest
			// 
			this.SubEntity_txtDataFinePrest.Location = new System.Drawing.Point(216, 24);
			this.SubEntity_txtDataFinePrest.Name = "SubEntity_txtDataFinePrest";
			this.SubEntity_txtDataFinePrest.Size = new System.Drawing.Size(88, 20);
			this.SubEntity_txtDataFinePrest.TabIndex = 2;
			this.SubEntity_txtDataFinePrest.Tag = "expenselast.servicestop?expenseview.servicestop";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(168, 24);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(40, 24);
			this.label33.TabIndex = 39;
			this.label33.Text = "Fine:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtDataInizioPrest
			// 
			this.SubEntity_txtDataInizioPrest.Location = new System.Drawing.Point(72, 24);
			this.SubEntity_txtDataInizioPrest.Name = "SubEntity_txtDataInizioPrest";
			this.SubEntity_txtDataInizioPrest.Size = new System.Drawing.Size(72, 20);
			this.SubEntity_txtDataInizioPrest.TabIndex = 1;
			this.SubEntity_txtDataInizioPrest.Tag = "expenselast.servicestart?expenseview.servicestart";
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(8, 24);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(56, 24);
			this.label34.TabIndex = 37;
			this.label34.Text = "Inizio:";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxRitDipendente
			// 
			this.gboxRitDipendente.Controls.Add(this.txtAssicurativeDip);
			this.gboxRitDipendente.Controls.Add(this.label41);
			this.gboxRitDipendente.Controls.Add(this.txtImportonettoDip);
			this.gboxRitDipendente.Controls.Add(this.label42);
			this.gboxRitDipendente.Controls.Add(this.txtAltreDip);
			this.gboxRitDipendente.Controls.Add(this.label43);
			this.gboxRitDipendente.Controls.Add(this.txtFiscaliDip);
			this.gboxRitDipendente.Controls.Add(this.label44);
			this.gboxRitDipendente.Controls.Add(this.txtPrevidenzialiDip);
			this.gboxRitDipendente.Controls.Add(this.label45);
			this.gboxRitDipendente.Controls.Add(this.txtAssistenzialiDip);
			this.gboxRitDipendente.Controls.Add(this.label46);
			this.gboxRitDipendente.Location = new System.Drawing.Point(16, 98);
			this.gboxRitDipendente.Name = "gboxRitDipendente";
			this.gboxRitDipendente.Size = new System.Drawing.Size(624, 56);
			this.gboxRitDipendente.TabIndex = 5;
			this.gboxRitDipendente.TabStop = false;
			this.gboxRitDipendente.Text = "Ritenute a carico del dipendente";
			// 
			// txtAssicurativeDip
			// 
			this.txtAssicurativeDip.Location = new System.Drawing.Point(272, 28);
			this.txtAssicurativeDip.Name = "txtAssicurativeDip";
			this.txtAssicurativeDip.ReadOnly = true;
			this.txtAssicurativeDip.Size = new System.Drawing.Size(88, 20);
			this.txtAssicurativeDip.TabIndex = 4;
			this.txtAssicurativeDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(288, 12);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(72, 12);
			this.label41.TabIndex = 18;
			this.label41.Text = "Assicurative:";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportonettoDip
			// 
			this.txtImportonettoDip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImportonettoDip.Location = new System.Drawing.Point(504, 28);
			this.txtImportonettoDip.Name = "txtImportonettoDip";
			this.txtImportonettoDip.ReadOnly = true;
			this.txtImportonettoDip.Size = new System.Drawing.Size(104, 21);
			this.txtImportonettoDip.TabIndex = 6;
			this.txtImportonettoDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(504, 12);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(88, 12);
			this.label42.TabIndex = 16;
			this.label42.Text = "Importo netto:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAltreDip
			// 
			this.txtAltreDip.Location = new System.Drawing.Point(360, 28);
			this.txtAltreDip.Name = "txtAltreDip";
			this.txtAltreDip.ReadOnly = true;
			this.txtAltreDip.Size = new System.Drawing.Size(88, 20);
			this.txtAltreDip.TabIndex = 5;
			this.txtAltreDip.Tag = "";
			this.txtAltreDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(376, 12);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(40, 12);
			this.label43.TabIndex = 14;
			this.label43.Text = "Altre:";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFiscaliDip
			// 
			this.txtFiscaliDip.Location = new System.Drawing.Point(184, 28);
			this.txtFiscaliDip.Name = "txtFiscaliDip";
			this.txtFiscaliDip.ReadOnly = true;
			this.txtFiscaliDip.Size = new System.Drawing.Size(88, 20);
			this.txtFiscaliDip.TabIndex = 3;
			this.txtFiscaliDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(200, 12);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(48, 12);
			this.label44.TabIndex = 12;
			this.label44.Text = "Fiscali:";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevidenzialiDip
			// 
			this.txtPrevidenzialiDip.Location = new System.Drawing.Point(96, 28);
			this.txtPrevidenzialiDip.Name = "txtPrevidenzialiDip";
			this.txtPrevidenzialiDip.ReadOnly = true;
			this.txtPrevidenzialiDip.Size = new System.Drawing.Size(88, 20);
			this.txtPrevidenzialiDip.TabIndex = 2;
			this.txtPrevidenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(104, 12);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(80, 12);
			this.label45.TabIndex = 10;
			this.label45.Text = "Previdenziali:";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAssistenzialiDip
			// 
			this.txtAssistenzialiDip.Location = new System.Drawing.Point(8, 28);
			this.txtAssistenzialiDip.Name = "txtAssistenzialiDip";
			this.txtAssistenzialiDip.ReadOnly = true;
			this.txtAssistenzialiDip.Size = new System.Drawing.Size(88, 20);
			this.txtAssistenzialiDip.TabIndex = 1;
			this.txtAssistenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(24, 12);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(72, 12);
			this.label46.TabIndex = 8;
			this.label46.Text = "Assistenziali:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// griddetriten
			// 
			this.griddetriten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.griddetriten.DataMember = "";
			this.griddetriten.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.griddetriten.Location = new System.Drawing.Point(6, 35);
			this.griddetriten.Name = "griddetriten";
			this.griddetriten.Size = new System.Drawing.Size(838, 178);
			this.griddetriten.TabIndex = 11;
			this.griddetriten.Tag = "expensetax.lista.default";
			// 
			// gboxContrEnte
			// 
			this.gboxContrEnte.Controls.Add(this.label50);
			this.gboxContrEnte.Controls.Add(this.txtFiscaliEnte);
			this.gboxContrEnte.Controls.Add(this.label4);
			this.gboxContrEnte.Controls.Add(this.txtAssicurativeEnte);
			this.gboxContrEnte.Controls.Add(this.label47);
			this.gboxContrEnte.Controls.Add(this.txtCostoTotaleEnte);
			this.gboxContrEnte.Controls.Add(this.label48);
			this.gboxContrEnte.Controls.Add(this.txtAltreEnte);
			this.gboxContrEnte.Controls.Add(this.label49);
			this.gboxContrEnte.Controls.Add(this.txtPrevidenzialiEnte);
			this.gboxContrEnte.Controls.Add(this.txtAssistenzialiEnte);
			this.gboxContrEnte.Controls.Add(this.label51);
			this.gboxContrEnte.Location = new System.Drawing.Point(16, 154);
			this.gboxContrEnte.Name = "gboxContrEnte";
			this.gboxContrEnte.Size = new System.Drawing.Size(624, 56);
			this.gboxContrEnte.TabIndex = 6;
			this.gboxContrEnte.TabStop = false;
			this.gboxContrEnte.Text = "Contributi a carico dell\'ente";
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(104, 16);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(72, 16);
			this.label50.TabIndex = 10;
			this.label50.Text = "Previdenziali:";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFiscaliEnte
			// 
			this.txtFiscaliEnte.Location = new System.Drawing.Point(184, 32);
			this.txtFiscaliEnte.Name = "txtFiscaliEnte";
			this.txtFiscaliEnte.ReadOnly = true;
			this.txtFiscaliEnte.Size = new System.Drawing.Size(88, 20);
			this.txtFiscaliEnte.TabIndex = 17;
			this.txtFiscaliEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(200, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 18;
			this.label4.Text = "Fiscali:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAssicurativeEnte
			// 
			this.txtAssicurativeEnte.Location = new System.Drawing.Point(272, 32);
			this.txtAssicurativeEnte.Name = "txtAssicurativeEnte";
			this.txtAssicurativeEnte.ReadOnly = true;
			this.txtAssicurativeEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAssicurativeEnte.TabIndex = 3;
			this.txtAssicurativeEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(288, 16);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(72, 16);
			this.label47.TabIndex = 16;
			this.label47.Text = "Assicurativi:";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCostoTotaleEnte
			// 
			this.txtCostoTotaleEnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostoTotaleEnte.Location = new System.Drawing.Point(504, 32);
			this.txtCostoTotaleEnte.Name = "txtCostoTotaleEnte";
			this.txtCostoTotaleEnte.ReadOnly = true;
			this.txtCostoTotaleEnte.Size = new System.Drawing.Size(104, 21);
			this.txtCostoTotaleEnte.TabIndex = 5;
			this.txtCostoTotaleEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(504, 16);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(88, 16);
			this.label48.TabIndex = 14;
			this.label48.Text = "Costo totale:";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAltreEnte
			// 
			this.txtAltreEnte.Location = new System.Drawing.Point(360, 32);
			this.txtAltreEnte.Name = "txtAltreEnte";
			this.txtAltreEnte.ReadOnly = true;
			this.txtAltreEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAltreEnte.TabIndex = 4;
			this.txtAltreEnte.Tag = "";
			this.txtAltreEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(384, 16);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(32, 16);
			this.label49.TabIndex = 12;
			this.label49.Text = "Altri:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevidenzialiEnte
			// 
			this.txtPrevidenzialiEnte.Location = new System.Drawing.Point(96, 32);
			this.txtPrevidenzialiEnte.Name = "txtPrevidenzialiEnte";
			this.txtPrevidenzialiEnte.ReadOnly = true;
			this.txtPrevidenzialiEnte.Size = new System.Drawing.Size(88, 20);
			this.txtPrevidenzialiEnte.TabIndex = 2;
			this.txtPrevidenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAssistenzialiEnte
			// 
			this.txtAssistenzialiEnte.Location = new System.Drawing.Point(8, 32);
			this.txtAssistenzialiEnte.Name = "txtAssistenzialiEnte";
			this.txtAssistenzialiEnte.ReadOnly = true;
			this.txtAssistenzialiEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAssistenzialiEnte.TabIndex = 1;
			this.txtAssistenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(16, 16);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(72, 16);
			this.label51.TabIndex = 8;
			this.label51.Text = "Assistenziali:";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox15
			// 
			this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox15.Controls.Add(this.btnDelClass);
			this.groupBox15.Controls.Add(this.btnEditClass);
			this.groupBox15.Controls.Add(this.btnInsertClass);
			this.groupBox15.Controls.Add(this.DGridDettagliClassificazioni);
			this.groupBox15.Location = new System.Drawing.Point(8, 221);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(847, 264);
			this.groupBox15.TabIndex = 27;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Dettagli classificazioni";
			// 
			// btnDelClass
			// 
			this.btnDelClass.Location = new System.Drawing.Point(192, 24);
			this.btnDelClass.Name = "btnDelClass";
			this.btnDelClass.Size = new System.Drawing.Size(75, 23);
			this.btnDelClass.TabIndex = 3;
			this.btnDelClass.Tag = "";
			this.btnDelClass.Text = "Cancella";
			this.btnDelClass.Click += new System.EventHandler(this.btnDelClass_Click);
			// 
			// btnEditClass
			// 
			this.btnEditClass.Location = new System.Drawing.Point(104, 24);
			this.btnEditClass.Name = "btnEditClass";
			this.btnEditClass.Size = new System.Drawing.Size(75, 23);
			this.btnEditClass.TabIndex = 2;
			this.btnEditClass.Tag = "";
			this.btnEditClass.Text = "Correggi";
			this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
			// 
			// btnInsertClass
			// 
			this.btnInsertClass.Location = new System.Drawing.Point(16, 24);
			this.btnInsertClass.Name = "btnInsertClass";
			this.btnInsertClass.Size = new System.Drawing.Size(75, 23);
			this.btnInsertClass.TabIndex = 1;
			this.btnInsertClass.Tag = "";
			this.btnInsertClass.Text = "Aggiungi";
			this.btnInsertClass.Click += new System.EventHandler(this.btnInsertClass_Click);
			// 
			// DGridDettagliClassificazioni
			// 
			this.DGridDettagliClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DGridDettagliClassificazioni.DataMember = "";
			this.DGridDettagliClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(16, 56);
			this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
			this.DGridDettagliClassificazioni.ReadOnly = true;
			this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(824, 200);
			this.DGridDettagliClassificazioni.TabIndex = 7;
			this.DGridDettagliClassificazioni.Tag = "expensesorted.default";
			this.DGridDettagliClassificazioni.DoubleClick += new System.EventHandler(this.DGridDettagliClassificazioni_DoubleClick);
			// 
			// DGridClassificazioni
			// 
			this.DGridClassificazioni.AllowNavigation = false;
			this.DGridClassificazioni.AllowSorting = false;
			this.DGridClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DGridClassificazioni.DataMember = "";
			this.DGridClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DGridClassificazioni.Location = new System.Drawing.Point(8, 40);
			this.DGridClassificazioni.Name = "DGridClassificazioni";
			this.DGridClassificazioni.ParentRowsVisible = false;
			this.DGridClassificazioni.ReadOnly = true;
			this.DGridClassificazioni.Size = new System.Drawing.Size(847, 175);
			this.DGridClassificazioni.TabIndex = 5;
			this.DGridClassificazioni.Tag = "sortingkind.default";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Classificazioni";
			// 
			// btnGerarchia
			// 
			this.btnGerarchia.Location = new System.Drawing.Point(427, 450);
			this.btnGerarchia.Name = "btnGerarchia";
			this.btnGerarchia.Size = new System.Drawing.Size(88, 22);
			this.btnGerarchia.TabIndex = 18;
			this.btnGerarchia.Text = "Gerarchia";
			this.btnGerarchia.Click += new System.EventHandler(this.btnGerarchia_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(427, 142);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 23);
			this.label8.TabIndex = 70;
			this.label8.Text = "Tipo contabilizzazione";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipoContabilizzazione
			// 
			this.cmbTipoContabilizzazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoContabilizzazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoContabilizzazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbTipoContabilizzazione.ItemHeight = 13;
			this.cmbTipoContabilizzazione.Location = new System.Drawing.Point(547, 142);
			this.cmbTipoContabilizzazione.Name = "cmbTipoContabilizzazione";
			this.cmbTipoContabilizzazione.Size = new System.Drawing.Size(327, 21);
			this.cmbTipoContabilizzazione.TabIndex = 10;
			this.cmbTipoContabilizzazione.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContabilizzazione_SelectedIndexChanged);
			// 
			// gboxDocumento
			// 
			this.gboxDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDocumento.Controls.Add(this.txtEsercDoc);
			this.gboxDocumento.Controls.Add(this.btnDocumento);
			this.gboxDocumento.Controls.Add(this.labEsercizio);
			this.gboxDocumento.Controls.Add(this.cmbTipoDocumento);
			this.gboxDocumento.Controls.Add(this.txtNumDoc);
			this.gboxDocumento.Controls.Add(this.labNum);
			this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
			this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.gboxDocumento.Location = new System.Drawing.Point(427, 190);
			this.gboxDocumento.Name = "gboxDocumento";
			this.gboxDocumento.Size = new System.Drawing.Size(447, 72);
			this.gboxDocumento.TabIndex = 12;
			this.gboxDocumento.TabStop = false;
			this.gboxDocumento.Text = "Documento da contabilizzare";
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(152, 48);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(56, 20);
			this.txtEsercDoc.TabIndex = 2;
			this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
			// 
			// btnDocumento
			// 
			this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDocumento.Location = new System.Drawing.Point(8, 48);
			this.btnDocumento.Name = "btnDocumento";
			this.btnDocumento.Size = new System.Drawing.Size(98, 20);
			this.btnDocumento.TabIndex = 0;
			this.btnDocumento.TabStop = false;
			this.btnDocumento.Text = "Documento";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// labEsercizio
			// 
			this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labEsercizio.Location = new System.Drawing.Point(112, 48);
			this.labEsercizio.Name = "labEsercizio";
			this.labEsercizio.Size = new System.Drawing.Size(40, 16);
			this.labEsercizio.TabIndex = 1;
			this.labEsercizio.Text = "Eserc.";
			this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipoDocumento
			// 
			this.cmbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbTipoDocumento.Location = new System.Drawing.Point(40, 16);
			this.cmbTipoDocumento.Name = "cmbTipoDocumento";
			this.cmbTipoDocumento.Size = new System.Drawing.Size(402, 21);
			this.cmbTipoDocumento.TabIndex = 1;
			this.cmbTipoDocumento.Tag = "";
			this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumentoGenerico_SelectedIndexChanged);
			// 
			// txtNumDoc
			// 
			this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumDoc.Location = new System.Drawing.Point(240, 48);
			this.txtNumDoc.Name = "txtNumDoc";
			this.txtNumDoc.Size = new System.Drawing.Size(203, 20);
			this.txtNumDoc.TabIndex = 3;
			this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
			// 
			// labNum
			// 
			this.labNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labNum.Location = new System.Drawing.Point(200, 48);
			this.labNum.Name = "labNum";
			this.labNum.Size = new System.Drawing.Size(40, 16);
			this.labNum.TabIndex = 3;
			this.labNum.Text = "Num.";
			this.labNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTipoDocumento
			// 
			this.labelTipoDocumento.Location = new System.Drawing.Point(8, 16);
			this.labelTipoDocumento.Name = "labelTipoDocumento";
			this.labelTipoDocumento.Size = new System.Drawing.Size(32, 16);
			this.labelTipoDocumento.TabIndex = 6;
			this.labelTipoDocumento.Text = "Tipo";
			this.labelTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCausale
			// 
			this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.labelCausale.Location = new System.Drawing.Point(427, 166);
			this.labelCausale.Name = "labelCausale";
			this.labelCausale.Size = new System.Drawing.Size(48, 23);
			this.labelCausale.TabIndex = 66;
			this.labelCausale.Text = "Causale";
			this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gBoxImportiPrestazione
			// 
			this.gBoxImportiPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gBoxImportiPrestazione.Controls.Add(this.SubEntity_prest1);
			this.gBoxImportiPrestazione.Location = new System.Drawing.Point(575, 54);
			this.gBoxImportiPrestazione.Name = "gBoxImportiPrestazione";
			this.gBoxImportiPrestazione.Size = new System.Drawing.Size(137, 40);
			this.gBoxImportiPrestazione.TabIndex = 10;
			this.gBoxImportiPrestazione.TabStop = false;
			this.gBoxImportiPrestazione.Text = "Iva";
			// 
			// SubEntity_prest1
			// 
			this.SubEntity_prest1.Location = new System.Drawing.Point(8, 16);
			this.SubEntity_prest1.Name = "SubEntity_prest1";
			this.SubEntity_prest1.Size = new System.Drawing.Size(120, 20);
			this.SubEntity_prest1.TabIndex = 1;
			this.SubEntity_prest1.Tag = "expenselast.ivaamount?expenseview.ivaamount";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabMovFin);
			this.tabControl1.Controls.Add(this.tabClassSup);
			this.tabControl1.Controls.Add(this.tabPageAltro);
			this.tabControl1.Controls.Add(this.tabPrest);
			this.tabControl1.Controls.Add(this.tabDetails);
			this.tabControl1.Controls.Add(this.tabPagam);
			this.tabControl1.Controls.Add(this.tabRecup);
			this.tabControl1.Controls.Add(this.tabFinanziamenti);
			this.tabControl1.Controls.Add(this.tabVariaz);
			this.tabControl1.Controls.Add(this.tabFatture);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(882, 520);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabClassSup_Enter);
			// 
			// tabMovFin
			// 
			this.tabMovFin.Controls.Add(this.chkElenchiEp);
			this.tabMovFin.Controls.Add(this.btnScrittureCollegate);
			this.tabMovFin.Controls.Add(this.btnAltreBollette);
			this.tabMovFin.Controls.Add(this.gboxBolletta);
			this.tabMovFin.Controls.Add(this.gboxUPB);
			this.tabMovFin.Controls.Add(this.groupBox20);
			this.tabMovFin.Controls.Add(this.groupBox19);
			this.tabMovFin.Controls.Add(this.btnGerarchia);
			this.tabMovFin.Controls.Add(this.label8);
			this.tabMovFin.Controls.Add(this.cmbTipoContabilizzazione);
			this.tabMovFin.Controls.Add(this.gboxDocumento);
			this.tabMovFin.Controls.Add(this.groupBox18);
			this.tabMovFin.Controls.Add(this.gboxMovimento);
			this.tabMovFin.Controls.Add(this.groupBox17);
			this.tabMovFin.Controls.Add(this.gboxResponsabile);
			this.tabMovFin.Controls.Add(this.gboxBilAnnuale);
			this.tabMovFin.Controls.Add(this.btnSituazioneMovimentoSpesa);
			this.tabMovFin.Controls.Add(this.groupCredDeb);
			this.tabMovFin.Controls.Add(this.cmbCausale);
			this.tabMovFin.Controls.Add(this.labelCausale);
			this.tabMovFin.Controls.Add(this.chbAzzeramento);
			this.tabMovFin.Controls.Add(this.SubEntity_chbCoperturaIniziativa);
			this.tabMovFin.Controls.Add(this.gboxFasePrecedente);
			this.tabMovFin.Controls.Add(this.groupBox1);
			this.tabMovFin.Location = new System.Drawing.Point(4, 23);
			this.tabMovFin.Name = "tabMovFin";
			this.tabMovFin.Size = new System.Drawing.Size(874, 493);
			this.tabMovFin.TabIndex = 0;
			this.tabMovFin.Text = "Movimento Finanziario";
			this.tabMovFin.UseVisualStyleBackColor = true;
			// 
			// chkElenchiEp
			// 
			this.chkElenchiEp.AutoSize = true;
			this.chkElenchiEp.Location = new System.Drawing.Point(678, 454);
			this.chkElenchiEp.Name = "chkElenchiEp";
			this.chkElenchiEp.Size = new System.Drawing.Size(108, 17);
			this.chkElenchiEp.TabIndex = 73;
			this.chkElenchiEp.Text = "Abilita elenchi EP";
			this.chkElenchiEp.UseVisualStyleBackColor = true;
			this.chkElenchiEp.CheckedChanged += new System.EventHandler(this.chkElenchiEp_CheckedChanged);
			// 
			// btnScrittureCollegate
			// 
			this.btnScrittureCollegate.Location = new System.Drawing.Point(531, 450);
			this.btnScrittureCollegate.Name = "btnScrittureCollegate";
			this.btnScrittureCollegate.Size = new System.Drawing.Size(123, 22);
			this.btnScrittureCollegate.TabIndex = 72;
			this.btnScrittureCollegate.Text = "Scritture collegate";
			this.btnScrittureCollegate.Click += new System.EventHandler(this.btnScrittureCollegate_Click);
			// 
			// btnAltreBollette
			// 
			this.btnAltreBollette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAltreBollette.Location = new System.Drawing.Point(647, 398);
			this.btnAltreBollette.Name = "btnAltreBollette";
			this.btnAltreBollette.Size = new System.Drawing.Size(168, 22);
			this.btnAltreBollette.TabIndex = 71;
			this.btnAltreBollette.TabStop = false;
			this.btnAltreBollette.Tag = "";
			this.btnAltreBollette.Text = "Copri altre bollette";
			this.btnAltreBollette.Click += new System.EventHandler(this.btnAltreBollette_Click);
			// 
			// gboxBolletta
			// 
			this.gboxBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBolletta.Controls.Add(this.SubEntity_txtBolletta);
			this.gboxBolletta.Controls.Add(this.btnBolletta);
			this.gboxBolletta.Location = new System.Drawing.Point(427, 382);
			this.gboxBolletta.Name = "gboxBolletta";
			this.gboxBolletta.Size = new System.Drawing.Size(213, 40);
			this.gboxBolletta.TabIndex = 14;
			this.gboxBolletta.TabStop = false;
			this.gboxBolletta.Tag = "AutoChoose.SubEntity_txtBolletta.spesa.(active=\'S\')";
			// 
			// SubEntity_txtBolletta
			// 
			this.SubEntity_txtBolletta.Location = new System.Drawing.Point(104, 12);
			this.SubEntity_txtBolletta.Name = "SubEntity_txtBolletta";
			this.SubEntity_txtBolletta.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtBolletta.TabIndex = 1;
			this.SubEntity_txtBolletta.Tag = "bill.nbill?x";
			// 
			// btnBolletta
			// 
			this.btnBolletta.Location = new System.Drawing.Point(8, 12);
			this.btnBolletta.Name = "btnBolletta";
			this.btnBolletta.Size = new System.Drawing.Size(88, 23);
			this.btnBolletta.TabIndex = 0;
			this.btnBolletta.TabStop = false;
			this.btnBolletta.Tag = "";
			this.btnBolletta.Text = "N. bolletta";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(10, 162);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(413, 104);
			this.gboxUPB.TabIndex = 7;
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
			this.btnUPBCode.Tag = "";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			this.btnUPBCode.Click += new System.EventHandler(this.btnUPBCode_Click);
			// 
			// gboxBilAnnuale
			// 
			this.gboxBilAnnuale.Controls.Add(this.chkListTitle);
			this.gboxBilAnnuale.Controls.Add(this.chkListManager);
			this.gboxBilAnnuale.Controls.Add(this.chkFilterAvailable);
			this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
			this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
			this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
			this.gboxBilAnnuale.Location = new System.Drawing.Point(10, 268);
			this.gboxBilAnnuale.Name = "gboxBilAnnuale";
			this.gboxBilAnnuale.Size = new System.Drawing.Size(413, 110);
			this.gboxBilAnnuale.TabIndex = 8;
			this.gboxBilAnnuale.TabStop = false;
			this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
			// 
			// chkListTitle
			// 
			this.chkListTitle.Location = new System.Drawing.Point(8, 40);
			this.chkListTitle.Name = "chkListTitle";
			this.chkListTitle.Size = new System.Drawing.Size(161, 16);
			this.chkListTitle.TabIndex = 12;
			this.chkListTitle.TabStop = false;
			this.chkListTitle.Text = "Cerca per denominazione";
			this.chkListTitle.CheckedChanged += new System.EventHandler(this.chkListTitle_CheckedChanged);
			// 
			// chkListManager
			// 
			this.chkListManager.Location = new System.Drawing.Point(8, 24);
			this.chkListManager.Name = "chkListManager";
			this.chkListManager.Size = new System.Drawing.Size(149, 16);
			this.chkListManager.TabIndex = 11;
			this.chkListManager.TabStop = false;
			this.chkListManager.Text = "Elenca per responsabile";
			this.chkListManager.CheckedChanged += new System.EventHandler(this.chkListManager_CheckedChanged);
			// 
			// chkFilterAvailable
			// 
			this.chkFilterAvailable.Checked = true;
			this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFilterAvailable.Location = new System.Drawing.Point(8, 8);
			this.chkFilterAvailable.Name = "chkFilterAvailable";
			this.chkFilterAvailable.Size = new System.Drawing.Size(161, 16);
			this.chkFilterAvailable.TabIndex = 10;
			this.chkFilterAvailable.TabStop = false;
			this.chkFilterAvailable.Text = "Filtra per disponibilit�";
			// 
			// btnBilancio
			// 
			this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
			this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBilancio.ImageIndex = 0;
			this.btnBilancio.ImageList = this.imageList1;
			this.btnBilancio.Location = new System.Drawing.Point(8, 56);
			this.btnBilancio.Name = "btnBilancio";
			this.btnBilancio.Size = new System.Drawing.Size(112, 20);
			this.btnBilancio.TabIndex = 1;
			this.btnBilancio.TabStop = false;
			this.btnBilancio.Tag = "";
			this.btnBilancio.Text = "Bilancio";
			this.btnBilancio.UseVisualStyleBackColor = false;
			this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
			// 
			// txtCodiceBilancio
			// 
			this.txtCodiceBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 80);
			this.txtCodiceBilancio.Name = "txtCodiceBilancio";
			this.txtCodiceBilancio.Size = new System.Drawing.Size(399, 20);
			this.txtCodiceBilancio.TabIndex = 2;
			this.txtCodiceBilancio.Tag = "finview.codefin?x";
			// 
			// txtDenominazioneBilancio
			// 
			this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneBilancio.Location = new System.Drawing.Point(175, 8);
			this.txtDenominazioneBilancio.Multiline = true;
			this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
			this.txtDenominazioneBilancio.ReadOnly = true;
			this.txtDenominazioneBilancio.Size = new System.Drawing.Size(232, 66);
			this.txtDenominazioneBilancio.TabIndex = 3;
			this.txtDenominazioneBilancio.TabStop = false;
			this.txtDenominazioneBilancio.Tag = "finview.title";
			// 
			// cmbCausale
			// 
			this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCausale.DataSource = this.DS.tipomovimento;
			this.cmbCausale.DisplayMember = "descrizione";
			this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbCausale.ItemHeight = 13;
			this.cmbCausale.Location = new System.Drawing.Point(483, 166);
			this.cmbCausale.Name = "cmbCausale";
			this.cmbCausale.Size = new System.Drawing.Size(391, 21);
			this.cmbCausale.TabIndex = 11;
			this.cmbCausale.ValueMember = "idtipo";
			this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
			// 
			// tabClassSup
			// 
			this.tabClassSup.Controls.Add(this.btnGeneraClassAutomatiche);
			this.tabClassSup.Controls.Add(this.DGridClassificazioni);
			this.tabClassSup.Controls.Add(this.groupBox15);
			this.tabClassSup.Controls.Add(this.label1);
			this.tabClassSup.ImageIndex = 1;
			this.tabClassSup.Location = new System.Drawing.Point(4, 23);
			this.tabClassSup.Name = "tabClassSup";
			this.tabClassSup.Size = new System.Drawing.Size(874, 493);
			this.tabClassSup.TabIndex = 1;
			this.tabClassSup.Text = "Classificazioni";
			this.tabClassSup.UseVisualStyleBackColor = true;
			// 
			// btnGeneraClassAutomatiche
			// 
			this.btnGeneraClassAutomatiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGeneraClassAutomatiche.Location = new System.Drawing.Point(664, 8);
			this.btnGeneraClassAutomatiche.Name = "btnGeneraClassAutomatiche";
			this.btnGeneraClassAutomatiche.Size = new System.Drawing.Size(191, 23);
			this.btnGeneraClassAutomatiche.TabIndex = 28;
			this.btnGeneraClassAutomatiche.Text = "Genera Classificazioni automatiche";
			this.btnGeneraClassAutomatiche.Click += new System.EventHandler(this.btnGeneraClassAutomatiche_Click);
			// 
			// tabPageAltro
			// 
			this.tabPageAltro.Controls.Add(this.gboxEntrata);
			this.tabPageAltro.Controls.Add(this.label27);
			this.tabPageAltro.Controls.Add(this.textBox7);
			this.tabPageAltro.Controls.Add(this.lblcig);
			this.tabPageAltro.Controls.Add(this.txtcig);
			this.tabPageAltro.Controls.Add(this.lblcup);
			this.tabPageAltro.Controls.Add(this.txtcup);
			this.tabPageAltro.Controls.Add(this.label20);
			this.tabPageAltro.Controls.Add(this.txtApplierAnnotations);
			this.tabPageAltro.Controls.Add(this.grpContodebito);
			this.tabPageAltro.Controls.Add(this.groupBox5);
			this.tabPageAltro.Controls.Add(this.grpCertificatiNecessari);
			this.tabPageAltro.Controls.Add(this.btnAggiornaCertificati);
			this.tabPageAltro.Location = new System.Drawing.Point(4, 23);
			this.tabPageAltro.Name = "tabPageAltro";
			this.tabPageAltro.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageAltro.Size = new System.Drawing.Size(874, 493);
			this.tabPageAltro.TabIndex = 8;
			this.tabPageAltro.Text = "Altro";
			this.tabPageAltro.UseVisualStyleBackColor = true;
			// 
			// gboxEntrata
			// 
			this.gboxEntrata.Controls.Add(this.txtNumEntrata);
			this.gboxEntrata.Controls.Add(this.label31);
			this.gboxEntrata.Controls.Add(this.txtEsercEntrata);
			this.gboxEntrata.Controls.Add(this.label39);
			this.gboxEntrata.Controls.Add(this.btnEntrata);
			this.gboxEntrata.Location = new System.Drawing.Point(8, 82);
			this.gboxEntrata.Name = "gboxEntrata";
			this.gboxEntrata.Size = new System.Drawing.Size(337, 95);
			this.gboxEntrata.TabIndex = 66;
			this.gboxEntrata.TabStop = false;
			this.gboxEntrata.Text = "Movimento di Entrata collegato";
			// 
			// txtNumEntrata
			// 
			this.txtNumEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumEntrata.Location = new System.Drawing.Point(234, 28);
			this.txtNumEntrata.Name = "txtNumEntrata";
			this.txtNumEntrata.Size = new System.Drawing.Size(83, 20);
			this.txtNumEntrata.TabIndex = 4;
			this.txtNumEntrata.Tag = "income_linked.nmov?expenseview.ninc_linked";
			this.txtNumEntrata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumEntrata.Leave += new System.EventHandler(this.txtNumEntrata_Leave);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(173, 28);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(59, 15);
			this.label31.TabIndex = 4;
			this.label31.Text = "Numero";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtEsercEntrata
			// 
			this.txtEsercEntrata.Location = new System.Drawing.Point(74, 28);
			this.txtEsercEntrata.Name = "txtEsercEntrata";
			this.txtEsercEntrata.Size = new System.Drawing.Size(58, 20);
			this.txtEsercEntrata.TabIndex = 3;
			this.txtEsercEntrata.Tag = "income_linked.ymov?expenseview.yinc_linked";
			this.txtEsercEntrata.Leave += new System.EventHandler(this.txtEsercEntrata_Leave);
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(17, 28);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(55, 15);
			this.label39.TabIndex = 2;
			this.label39.Text = "Esercizio";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnEntrata
			// 
			this.btnEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEntrata.Location = new System.Drawing.Point(190, 63);
			this.btnEntrata.Name = "btnEntrata";
			this.btnEntrata.Size = new System.Drawing.Size(128, 23);
			this.btnEntrata.TabIndex = 1;
			this.btnEntrata.TabStop = false;
			this.btnEntrata.Text = "Scegli Movimento";
			this.btnEntrata.Click += new System.EventHandler(this.btnEntrata_Click);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(454, 432);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(278, 20);
			this.label27.TabIndex = 65;
			this.label27.Tag = "mandate.external_reference";
			this.label27.Text = "Codice proveniente da importazione";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(457, 454);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(275, 20);
			this.textBox7.TabIndex = 64;
			this.textBox7.Tag = "expense.external_reference";
			// 
			// lblcig
			// 
			this.lblcig.Location = new System.Drawing.Point(222, 436);
			this.lblcig.Name = "lblcig";
			this.lblcig.Size = new System.Drawing.Size(192, 19);
			this.lblcig.TabIndex = 47;
			this.lblcig.Tag = "";
			this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
			this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtcig
			// 
			this.txtcig.Location = new System.Drawing.Point(225, 456);
			this.txtcig.Name = "txtcig";
			this.txtcig.Size = new System.Drawing.Size(120, 20);
			this.txtcig.TabIndex = 46;
			this.txtcig.Tag = "expense.cigcode";
			// 
			// lblcup
			// 
			this.lblcup.Location = new System.Drawing.Point(6, 434);
			this.lblcup.Name = "lblcup";
			this.lblcup.Size = new System.Drawing.Size(172, 19);
			this.lblcup.TabIndex = 45;
			this.lblcup.Tag = "";
			this.lblcup.Text = "Codice Unico di Progetto (CUP)";
			this.lblcup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtcup
			// 
			this.txtcup.Location = new System.Drawing.Point(8, 456);
			this.txtcup.Name = "txtcup";
			this.txtcup.Size = new System.Drawing.Size(108, 20);
			this.txtcup.TabIndex = 44;
			this.txtcup.Tag = "expense.cupcode";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(7, 286);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(311, 16);
			this.label20.TabIndex = 43;
			this.label20.Text = "Note del Richiedente:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtApplierAnnotations
			// 
			this.txtApplierAnnotations.Location = new System.Drawing.Point(8, 304);
			this.txtApplierAnnotations.Multiline = true;
			this.txtApplierAnnotations.Name = "txtApplierAnnotations";
			this.txtApplierAnnotations.ReadOnly = true;
			this.txtApplierAnnotations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtApplierAnnotations.Size = new System.Drawing.Size(434, 115);
			this.txtApplierAnnotations.TabIndex = 42;
			this.txtApplierAnnotations.Tag = "mandate.applierannotations";
			// 
			// grpContodebito
			// 
			this.grpContodebito.Controls.Add(this.txtDescrContoSupplier);
			this.grpContodebito.Controls.Add(this.txtCodiceContoSupplier);
			this.grpContodebito.Controls.Add(this.btnContoDebito);
			this.grpContodebito.Location = new System.Drawing.Point(8, 190);
			this.grpContodebito.Name = "grpContodebito";
			this.grpContodebito.Size = new System.Drawing.Size(434, 93);
			this.grpContodebito.TabIndex = 4;
			this.grpContodebito.TabStop = false;
			this.grpContodebito.Tag = "AutoChoose.txtCodiceContoSupplier.default.((flagaccountusage&48)<>0)";
			this.grpContodebito.Text = "Conto EP  per il debito";
			// 
			// txtDescrContoSupplier
			// 
			this.txtDescrContoSupplier.Location = new System.Drawing.Point(176, 19);
			this.txtDescrContoSupplier.Multiline = true;
			this.txtDescrContoSupplier.Name = "txtDescrContoSupplier";
			this.txtDescrContoSupplier.ReadOnly = true;
			this.txtDescrContoSupplier.Size = new System.Drawing.Size(242, 63);
			this.txtDescrContoSupplier.TabIndex = 2;
			this.txtDescrContoSupplier.TabStop = false;
			this.txtDescrContoSupplier.Tag = "account.title";
			// 
			// txtCodiceContoSupplier
			// 
			this.txtCodiceContoSupplier.Location = new System.Drawing.Point(8, 62);
			this.txtCodiceContoSupplier.Name = "txtCodiceContoSupplier";
			this.txtCodiceContoSupplier.Size = new System.Drawing.Size(162, 20);
			this.txtCodiceContoSupplier.TabIndex = 1;
			this.txtCodiceContoSupplier.Tag = "account.codeacc?expenseview.codeaccdebit";
			// 
			// btnContoDebito
			// 
			this.btnContoDebito.Location = new System.Drawing.Point(8, 33);
			this.btnContoDebito.Name = "btnContoDebito";
			this.btnContoDebito.Size = new System.Drawing.Size(120, 23);
			this.btnContoDebito.TabIndex = 0;
			this.btnContoDebito.TabStop = false;
			this.btnContoDebito.Tag = "Choose.account.tree.((flagaccountusage&48)<>0)";
			this.btnContoDebito.Text = "Conto";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtFormerNmov);
			this.groupBox5.Controls.Add(this.label19);
			this.groupBox5.Controls.Add(this.txtFormerYmov);
			this.groupBox5.Controls.Add(this.label18);
			this.groupBox5.Location = new System.Drawing.Point(8, 6);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(337, 69);
			this.groupBox5.TabIndex = 2;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Economia di spesa associata";
			// 
			// txtFormerNmov
			// 
			this.txtFormerNmov.Location = new System.Drawing.Point(234, 26);
			this.txtFormerNmov.Name = "txtFormerNmov";
			this.txtFormerNmov.Size = new System.Drawing.Size(83, 20);
			this.txtFormerNmov.TabIndex = 3;
			this.txtFormerNmov.Tag = "formerexpense.nmov?expenseview.formernmov";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(177, 28);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(44, 13);
			this.label19.TabIndex = 2;
			this.label19.Text = "Numero";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFormerYmov
			// 
			this.txtFormerYmov.Location = new System.Drawing.Point(71, 26);
			this.txtFormerYmov.Name = "txtFormerYmov";
			this.txtFormerYmov.Size = new System.Drawing.Size(58, 20);
			this.txtFormerYmov.TabIndex = 1;
			this.txtFormerYmov.Tag = "formerexpense.ymov.year?expenseview.formerymov.year";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(12, 28);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(52, 13);
			this.label18.TabIndex = 0;
			this.label18.Text = "Esercizio ";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkPattoIntegrita);
			this.grpCertificatiNecessari.Controls.Add(this.chkOttempLegge);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioGiud);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioAmm);
			this.grpCertificatiNecessari.Controls.Add(this.chkVerificaAnac);
			this.grpCertificatiNecessari.Controls.Add(this.chkRegolaritaFisc);
			this.grpCertificatiNecessari.Controls.Add(this.SubEntity_chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.SubEntity_chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.SubEntity_chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(457, 6);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(405, 296);
			this.grpCertificatiNecessari.TabIndex = 99;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(14, 184);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 99;
			this.chkOttempLegge.Tag = "expenselast.paymethod_flag:20?expenseview.paymethod_flag:20";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(14, 121);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 98;
			this.chkCasellarioGiud.Tag = "expenselast.paymethod_flag:18?expenseview.paymethod_flag:18";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(14, 153);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 97;
			this.chkCasellarioAmm.Tag = "expenselast.paymethod_flag:19?expenseview.paymethod_flag:19";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(14, 245);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 96;
			this.chkVerificaAnac.Tag = "expenselast.paymethod_flag:22?expenseview.paymethod_flag:22";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFisc
			// 
			this.chkRegolaritaFisc.AutoSize = true;
			this.chkRegolaritaFisc.Location = new System.Drawing.Point(14, 215);
			this.chkRegolaritaFisc.Name = "chkRegolaritaFisc";
			this.chkRegolaritaFisc.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFisc.TabIndex = 95;
			this.chkRegolaritaFisc.Tag = "expenselast.paymethod_flag:21?expenseview.paymethod_flag:21";
			this.chkRegolaritaFisc.Text = "Regolarit� Fiscale";
			this.chkRegolaritaFisc.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkDurc
			// 
			this.SubEntity_chkDurc.AutoSize = true;
			this.SubEntity_chkDurc.Location = new System.Drawing.Point(14, 90);
			this.SubEntity_chkDurc.Name = "SubEntity_chkDurc";
			this.SubEntity_chkDurc.Size = new System.Drawing.Size(57, 17);
			this.SubEntity_chkDurc.TabIndex = 94;
			this.SubEntity_chkDurc.Tag = "expenselast.paymethod_flag:17?expenseview.paymethod_flag:17";
			this.SubEntity_chkDurc.Text = "DURC";
			this.SubEntity_chkDurc.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkVisura
			// 
			this.SubEntity_chkVisura.AutoSize = true;
			this.SubEntity_chkVisura.Location = new System.Drawing.Point(14, 59);
			this.SubEntity_chkVisura.Name = "SubEntity_chkVisura";
			this.SubEntity_chkVisura.Size = new System.Drawing.Size(102, 17);
			this.SubEntity_chkVisura.TabIndex = 93;
			this.SubEntity_chkVisura.Tag = "expenselast.paymethod_flag:16?expenseview.paymethod_flag:16";
			this.SubEntity_chkVisura.Text = "Visura Camerale";
			this.SubEntity_chkVisura.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkCCdedicato
			// 
			this.SubEntity_chkCCdedicato.AutoSize = true;
			this.SubEntity_chkCCdedicato.Location = new System.Drawing.Point(14, 28);
			this.SubEntity_chkCCdedicato.Name = "SubEntity_chkCCdedicato";
			this.SubEntity_chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.SubEntity_chkCCdedicato.TabIndex = 91;
			this.SubEntity_chkCCdedicato.Tag = "expenselast.paymethod_flag:15?expenseview.paymethod_flag:15";
			this.SubEntity_chkCCdedicato.Text = "CC dedicato";
			// 
			// btnAggiornaCertificati
			// 
			this.btnAggiornaCertificati.Location = new System.Drawing.Point(706, 330);
			this.btnAggiornaCertificati.Name = "btnAggiornaCertificati";
			this.btnAggiornaCertificati.Size = new System.Drawing.Size(156, 24);
			this.btnAggiornaCertificati.TabIndex = 100;
			this.btnAggiornaCertificati.Text = "Aggiorna controlli certificati";
			this.btnAggiornaCertificati.UseVisualStyleBackColor = true;
			this.btnAggiornaCertificati.Click += new System.EventHandler(this.btnAggiornaCertificati_Click);
			// 
			// tabPrest
			// 
			this.tabPrest.Controls.Add(this.tabControl2);
			this.tabPrest.Controls.Add(this.labePrestGenerica);
			this.tabPrest.Controls.Add(this.groupBox3);
			this.tabPrest.Controls.Add(this.gboxContrEnte);
			this.tabPrest.Controls.Add(this.gboxRitDipendente);
			this.tabPrest.Controls.Add(this.SubEntity_chkAutomPrestazione);
			this.tabPrest.Controls.Add(this.btnAutomatismiPrestazione);
			this.tabPrest.Controls.Add(this.gBoxImportiPrestazione);
			this.tabPrest.Controls.Add(this.SubEntity_cmbTipoprestazione);
			this.tabPrest.Location = new System.Drawing.Point(4, 23);
			this.tabPrest.Name = "tabPrest";
			this.tabPrest.Size = new System.Drawing.Size(874, 493);
			this.tabPrest.TabIndex = 2;
			this.tabPrest.Text = "Prestazione";
			this.tabPrest.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabTax);
			this.tabControl2.Controls.Add(this.tabCorrige);
			this.tabControl2.Controls.Add(this.tabOfficial);
			this.tabControl2.Location = new System.Drawing.Point(8, 215);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(857, 246);
			this.tabControl2.TabIndex = 15;
			// 
			// tabTax
			// 
			this.tabTax.Controls.Add(this.btnInserisciRitenute);
			this.tabTax.Controls.Add(this.btnModificaRitenute);
			this.tabTax.Controls.Add(this.btnEliminaRitenute);
			this.tabTax.Controls.Add(this.griddetriten);
			this.tabTax.Location = new System.Drawing.Point(4, 22);
			this.tabTax.Name = "tabTax";
			this.tabTax.Padding = new System.Windows.Forms.Padding(3);
			this.tabTax.Size = new System.Drawing.Size(849, 220);
			this.tabTax.TabIndex = 0;
			this.tabTax.Text = "Ritenute";
			this.tabTax.UseVisualStyleBackColor = true;
			// 
			// tabCorrige
			// 
			this.tabCorrige.Controls.Add(this.btnInserisciCorrezione);
			this.tabCorrige.Controls.Add(this.btnModificaCorrezione);
			this.tabCorrige.Controls.Add(this.btnEliminaCorrezione);
			this.tabCorrige.Controls.Add(this.dgCorrige);
			this.tabCorrige.Location = new System.Drawing.Point(4, 22);
			this.tabCorrige.Name = "tabCorrige";
			this.tabCorrige.Padding = new System.Windows.Forms.Padding(3);
			this.tabCorrige.Size = new System.Drawing.Size(849, 220);
			this.tabCorrige.TabIndex = 1;
			this.tabCorrige.Text = "Correzioni";
			this.tabCorrige.UseVisualStyleBackColor = true;
			// 
			// btnInserisciCorrezione
			// 
			this.btnInserisciCorrezione.Location = new System.Drawing.Point(6, 6);
			this.btnInserisciCorrezione.Name = "btnInserisciCorrezione";
			this.btnInserisciCorrezione.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciCorrezione.TabIndex = 12;
			this.btnInserisciCorrezione.TabStop = false;
			this.btnInserisciCorrezione.Tag = "insert.default";
			this.btnInserisciCorrezione.Text = "Inserisci...";
			// 
			// btnModificaCorrezione
			// 
			this.btnModificaCorrezione.Location = new System.Drawing.Point(94, 6);
			this.btnModificaCorrezione.Name = "btnModificaCorrezione";
			this.btnModificaCorrezione.Size = new System.Drawing.Size(75, 23);
			this.btnModificaCorrezione.TabIndex = 13;
			this.btnModificaCorrezione.TabStop = false;
			this.btnModificaCorrezione.Tag = "edit.default";
			this.btnModificaCorrezione.Text = "Modifica...";
			// 
			// btnEliminaCorrezione
			// 
			this.btnEliminaCorrezione.Location = new System.Drawing.Point(182, 6);
			this.btnEliminaCorrezione.Name = "btnEliminaCorrezione";
			this.btnEliminaCorrezione.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaCorrezione.TabIndex = 14;
			this.btnEliminaCorrezione.TabStop = false;
			this.btnEliminaCorrezione.Tag = "delete";
			this.btnEliminaCorrezione.Text = "Elimina";
			// 
			// dgCorrige
			// 
			this.dgCorrige.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgCorrige.DataMember = "";
			this.dgCorrige.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCorrige.Location = new System.Drawing.Point(6, 35);
			this.dgCorrige.Name = "dgCorrige";
			this.dgCorrige.Size = new System.Drawing.Size(838, 179);
			this.dgCorrige.TabIndex = 15;
			this.dgCorrige.Tag = "expensetaxcorrige.lista.default";
			// 
			// tabOfficial
			// 
			this.tabOfficial.Controls.Add(this.btnInserisciUfficiale);
			this.tabOfficial.Controls.Add(this.btnModificaUfficiale);
			this.tabOfficial.Controls.Add(this.btnEliminaUfficiale);
			this.tabOfficial.Controls.Add(this.dgOfficial);
			this.tabOfficial.Location = new System.Drawing.Point(4, 22);
			this.tabOfficial.Name = "tabOfficial";
			this.tabOfficial.Size = new System.Drawing.Size(849, 220);
			this.tabOfficial.TabIndex = 2;
			this.tabOfficial.Text = "Riepilogo Storico";
			this.tabOfficial.UseVisualStyleBackColor = true;
			// 
			// btnInserisciUfficiale
			// 
			this.btnInserisciUfficiale.Location = new System.Drawing.Point(6, 6);
			this.btnInserisciUfficiale.Name = "btnInserisciUfficiale";
			this.btnInserisciUfficiale.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciUfficiale.TabIndex = 12;
			this.btnInserisciUfficiale.TabStop = false;
			this.btnInserisciUfficiale.Tag = "insert.default";
			this.btnInserisciUfficiale.Text = "Inserisci...";
			// 
			// btnModificaUfficiale
			// 
			this.btnModificaUfficiale.Location = new System.Drawing.Point(94, 6);
			this.btnModificaUfficiale.Name = "btnModificaUfficiale";
			this.btnModificaUfficiale.Size = new System.Drawing.Size(75, 23);
			this.btnModificaUfficiale.TabIndex = 13;
			this.btnModificaUfficiale.TabStop = false;
			this.btnModificaUfficiale.Tag = "edit.default";
			this.btnModificaUfficiale.Text = "Modifica...";
			// 
			// btnEliminaUfficiale
			// 
			this.btnEliminaUfficiale.Location = new System.Drawing.Point(182, 6);
			this.btnEliminaUfficiale.Name = "btnEliminaUfficiale";
			this.btnEliminaUfficiale.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaUfficiale.TabIndex = 14;
			this.btnEliminaUfficiale.TabStop = false;
			this.btnEliminaUfficiale.Tag = "delete";
			this.btnEliminaUfficiale.Text = "Elimina";
			// 
			// dgOfficial
			// 
			this.dgOfficial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgOfficial.DataMember = "";
			this.dgOfficial.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgOfficial.Location = new System.Drawing.Point(6, 35);
			this.dgOfficial.Name = "dgOfficial";
			this.dgOfficial.Size = new System.Drawing.Size(838, 179);
			this.dgOfficial.TabIndex = 15;
			this.dgOfficial.Tag = "expensetaxofficial.lista.default";
			// 
			// labePrestGenerica
			// 
			this.labePrestGenerica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labePrestGenerica.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.labePrestGenerica.Location = new System.Drawing.Point(562, 8);
			this.labePrestGenerica.Name = "labePrestGenerica";
			this.labePrestGenerica.Size = new System.Drawing.Size(300, 48);
			this.labePrestGenerica.TabIndex = 14;
			this.labePrestGenerica.Text = "E\' importante sapere che attraverso la prestazione generica le ritenute inserite " +
    "non verranno gestite nelle stampe delle certificazioni fiscali, Trasmissioni EME" +
    "NS, Modello 770 ecc.";
			this.labePrestGenerica.Visible = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label33);
			this.groupBox3.Controls.Add(this.SubEntity_txtDataInizioPrest);
			this.groupBox3.Controls.Add(this.label34);
			this.groupBox3.Controls.Add(this.SubEntity_txtDataFinePrest);
			this.groupBox3.Location = new System.Drawing.Point(16, 34);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(317, 60);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Date della prestazione";
			// 
			// SubEntity_cmbTipoprestazione
			// 
			this.SubEntity_cmbTipoprestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbTipoprestazione.DataSource = this.DS.service;
			this.SubEntity_cmbTipoprestazione.DisplayMember = "description";
			this.SubEntity_cmbTipoprestazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SubEntity_cmbTipoprestazione.Location = new System.Drawing.Point(16, 8);
			this.SubEntity_cmbTipoprestazione.Name = "SubEntity_cmbTipoprestazione";
			this.SubEntity_cmbTipoprestazione.Size = new System.Drawing.Size(536, 21);
			this.SubEntity_cmbTipoprestazione.TabIndex = 0;
			this.SubEntity_cmbTipoprestazione.Tag = "expenselast.idser?expenseview.idser";
			this.SubEntity_cmbTipoprestazione.ValueMember = "idser";
			// 
			// tabDetails
			// 
			this.tabDetails.Controls.Add(this.gboxIncassoDettContratti);
			this.tabDetails.Controls.Add(this.gboxDettmandate);
			this.tabDetails.Location = new System.Drawing.Point(4, 23);
			this.tabDetails.Name = "tabDetails";
			this.tabDetails.Size = new System.Drawing.Size(874, 493);
			this.tabDetails.TabIndex = 7;
			this.tabDetails.Text = "Contratti Passivi";
			this.tabDetails.UseVisualStyleBackColor = true;
			// 
			// gboxIncassoDettContratti
			// 
			this.gboxIncassoDettContratti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxIncassoDettContratti.Controls.Add(this.btnCollegaDettagliContratto);
			this.gboxIncassoDettContratti.Controls.Add(this.button3);
			this.gboxIncassoDettContratti.Controls.Add(this.txtTotDettPagamenti);
			this.gboxIncassoDettContratti.Controls.Add(this.label30);
			this.gboxIncassoDettContratti.Controls.Add(this.button4);
			this.gboxIncassoDettContratti.Controls.Add(this.gridDettPagamenti);
			this.gboxIncassoDettContratti.Controls.Add(this.btnAdd);
			this.gboxIncassoDettContratti.Location = new System.Drawing.Point(3, 214);
			this.gboxIncassoDettContratti.Name = "gboxIncassoDettContratti";
			this.gboxIncassoDettContratti.Size = new System.Drawing.Size(861, 271);
			this.gboxIncassoDettContratti.TabIndex = 72;
			this.gboxIncassoDettContratti.TabStop = false;
			this.gboxIncassoDettContratti.Text = "Dettagli Contratto Passivo pagati";
			// 
			// btnCollegaDettagliContratto
			// 
			this.btnCollegaDettagliContratto.Location = new System.Drawing.Point(8, 157);
			this.btnCollegaDettagliContratto.Name = "btnCollegaDettagliContratto";
			this.btnCollegaDettagliContratto.Size = new System.Drawing.Size(75, 54);
			this.btnCollegaDettagliContratto.TabIndex = 6;
			this.btnCollegaDettagliContratto.Text = "Riporta dettagli impegnati";
			this.btnCollegaDettagliContratto.UseVisualStyleBackColor = true;
			this.btnCollegaDettagliContratto.Click += new System.EventHandler(this.btnCollegaDettagliContratto_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 80);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Tag = "edit.detail";
			this.button3.Text = "Modifica..";
			// 
			// txtTotDettPagamenti
			// 
			this.txtTotDettPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotDettPagamenti.Location = new System.Drawing.Point(8, 243);
			this.txtTotDettPagamenti.Name = "txtTotDettPagamenti";
			this.txtTotDettPagamenti.ReadOnly = true;
			this.txtTotDettPagamenti.Size = new System.Drawing.Size(80, 20);
			this.txtTotDettPagamenti.TabIndex = 4;
			this.txtTotDettPagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label30
			// 
			this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label30.Location = new System.Drawing.Point(6, 224);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(48, 16);
			this.label30.TabIndex = 3;
			this.label30.Text = "Totale";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 48);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 2;
			this.button4.Tag = "delete";
			this.button4.Text = "Rimuovi";
			// 
			// gridDettPagamenti
			// 
			this.gridDettPagamenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettPagamenti.DataMember = "";
			this.gridDettPagamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettPagamenti.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.gridDettPagamenti.Location = new System.Drawing.Point(103, 16);
			this.gridDettPagamenti.Name = "gridDettPagamenti";
			this.gridDettPagamenti.Size = new System.Drawing.Size(750, 249);
			this.gridDettPagamenti.TabIndex = 1;
			this.gridDettPagamenti.Tag = "expenselastmandatedetail.detail.detail";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(8, 16);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Tag = "insert.detail";
			this.btnAdd.Text = "Aggiungi";
			// 
			// gboxDettmandate
			// 
			this.gboxDettmandate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDettmandate.Controls.Add(this.btnEditMandDet);
			this.gboxDettmandate.Controls.Add(this.txtTotMandateDetail);
			this.gboxDettmandate.Controls.Add(this.label16);
			this.gboxDettmandate.Controls.Add(this.btnRemoveDetMandate);
			this.gboxDettmandate.Controls.Add(this.dgrDettagliOrdine);
			this.gboxDettmandate.Controls.Add(this.btnAddDetMandate);
			this.gboxDettmandate.Location = new System.Drawing.Point(8, 0);
			this.gboxDettmandate.Name = "gboxDettmandate";
			this.gboxDettmandate.Size = new System.Drawing.Size(856, 208);
			this.gboxDettmandate.TabIndex = 0;
			this.gboxDettmandate.TabStop = false;
			this.gboxDettmandate.Text = "Dettagli Contratto Passivo";
			// 
			// btnEditMandDet
			// 
			this.btnEditMandDet.Location = new System.Drawing.Point(8, 80);
			this.btnEditMandDet.Name = "btnEditMandDet";
			this.btnEditMandDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditMandDet.TabIndex = 5;
			this.btnEditMandDet.Text = "Modifica..";
			this.btnEditMandDet.Click += new System.EventHandler(this.btnModificaDettOrdine_Click);
			// 
			// txtTotMandateDetail
			// 
			this.txtTotMandateDetail.Location = new System.Drawing.Point(8, 168);
			this.txtTotMandateDetail.Name = "txtTotMandateDetail";
			this.txtTotMandateDetail.ReadOnly = true;
			this.txtTotMandateDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotMandateDetail.TabIndex = 4;
			this.txtTotMandateDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 152);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(48, 16);
			this.label16.TabIndex = 3;
			this.label16.Text = "Totale";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRemoveDetMandate
			// 
			this.btnRemoveDetMandate.Location = new System.Drawing.Point(8, 48);
			this.btnRemoveDetMandate.Name = "btnRemoveDetMandate";
			this.btnRemoveDetMandate.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDetMandate.TabIndex = 2;
			this.btnRemoveDetMandate.Text = "Rimuovi";
			this.btnRemoveDetMandate.Click += new System.EventHandler(this.btnScollegaDettOrdine_Click);
			// 
			// dgrDettagliOrdine
			// 
			this.dgrDettagliOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettagliOrdine.DataMember = "";
			this.dgrDettagliOrdine.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettagliOrdine.Location = new System.Drawing.Point(96, 16);
			this.dgrDettagliOrdine.Name = "dgrDettagliOrdine";
			this.dgrDettagliOrdine.Size = new System.Drawing.Size(752, 184);
			this.dgrDettagliOrdine.TabIndex = 1;
			// 
			// btnAddDetMandate
			// 
			this.btnAddDetMandate.Location = new System.Drawing.Point(8, 16);
			this.btnAddDetMandate.Name = "btnAddDetMandate";
			this.btnAddDetMandate.Size = new System.Drawing.Size(75, 23);
			this.btnAddDetMandate.TabIndex = 0;
			this.btnAddDetMandate.Text = "Aggiungi";
			this.btnAddDetMandate.Click += new System.EventHandler(this.btnCollegaDettOrdine_Click);
			// 
			// tabPagam
			// 
			this.tabPagam.Controls.Add(this.groupBox9);
			this.tabPagam.Controls.Add(this.tabModPagamento);
			this.tabPagam.Controls.Add(this.textBox1);
			this.tabPagam.Controls.Add(this.panel1);
			this.tabPagam.Location = new System.Drawing.Point(4, 23);
			this.tabPagam.Name = "tabPagam";
			this.tabPagam.Size = new System.Drawing.Size(874, 493);
			this.tabPagam.TabIndex = 3;
			this.tabPagam.Text = "Mandato";
			this.tabPagam.UseVisualStyleBackColor = true;
			// 
			// tabModPagamento
			// 
			this.tabModPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabModPagamento.Controls.Add(this.tabInfoModPagamento);
			this.tabModPagamento.Controls.Add(this.tabOpzioniModPagamento);
			this.tabModPagamento.Controls.Add(this.tabPage1);
			this.tabModPagamento.Location = new System.Drawing.Point(8, 80);
			this.tabModPagamento.Name = "tabModPagamento";
			this.tabModPagamento.SelectedIndex = 0;
			this.tabModPagamento.Size = new System.Drawing.Size(862, 406);
			this.tabModPagamento.TabIndex = 35;
			// 
			// tabInfoModPagamento
			// 
			this.tabInfoModPagamento.Controls.Add(this.lblAvvisoPagoPa);
			this.tabInfoModPagamento.Controls.Add(this.SubEntity_txtAvvisoPagoPa);
			this.tabInfoModPagamento.Controls.Add(this.groupBox12);
			this.tabInfoModPagamento.Location = new System.Drawing.Point(4, 22);
			this.tabInfoModPagamento.Name = "tabInfoModPagamento";
			this.tabInfoModPagamento.Padding = new System.Windows.Forms.Padding(3);
			this.tabInfoModPagamento.Size = new System.Drawing.Size(854, 380);
			this.tabInfoModPagamento.TabIndex = 0;
			this.tabInfoModPagamento.Text = "Generale";
			this.tabInfoModPagamento.UseVisualStyleBackColor = true;
			// 
			// lblAvvisoPagoPa
			// 
			this.lblAvvisoPagoPa.Location = new System.Drawing.Point(154, 333);
			this.lblAvvisoPagoPa.Name = "lblAvvisoPagoPa";
			this.lblAvvisoPagoPa.Size = new System.Drawing.Size(168, 17);
			this.lblAvvisoPagoPa.TabIndex = 79;
			this.lblAvvisoPagoPa.Tag = "";
			this.lblAvvisoPagoPa.Text = "Numero avviso PagoPa";
			this.lblAvvisoPagoPa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtAvvisoPagoPa
			// 
			this.SubEntity_txtAvvisoPagoPa.Location = new System.Drawing.Point(155, 351);
			this.SubEntity_txtAvvisoPagoPa.Name = "SubEntity_txtAvvisoPagoPa";
			this.SubEntity_txtAvvisoPagoPa.Size = new System.Drawing.Size(148, 20);
			this.SubEntity_txtAvvisoPagoPa.TabIndex = 101;
			this.SubEntity_txtAvvisoPagoPa.Tag = "expenselast.pagopanoticenum?expenseview.pagopanoticenum";
			// 
			// groupBox12
			// 
			this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox12.Controls.Add(this.label26);
			this.groupBox12.Controls.Add(this.SubEntity_cmbChargeHandling);
			this.groupBox12.Controls.Add(this.SubEntity_chkEsenteSpese);
			this.groupBox12.Controls.Add(this.label24);
			this.groupBox12.Controls.Add(this.SubEntity_txtExtraCode);
			this.groupBox12.Controls.Add(this.lblCommento);
			this.groupBox12.Controls.Add(this.label23);
			this.groupBox12.Controls.Add(this.SubEntity_txtBiccode);
			this.groupBox12.Controls.Add(this.txtModPagamento);
			this.groupBox12.Controls.Add(this.btnSelModalita);
			this.groupBox12.Controls.Add(this.label11);
			this.groupBox12.Controls.Add(this.SubEntity_txtIBAN);
			this.groupBox12.Controls.Add(this.btnModEstinzione);
			this.groupBox12.Controls.Add(this.SubEntity_txtRifDocumentoEsterno);
			this.groupBox12.Controls.Add(this.label9);
			this.groupBox12.Controls.Add(this.SubEntity_txtDelegato);
			this.groupBox12.Controls.Add(this.label7);
			this.groupBox12.Controls.Add(this.SubEntity_cmbModPagamento);
			this.groupBox12.Controls.Add(this.label38);
			this.groupBox12.Controls.Add(this.SubEntity_txtDescrModPagamento);
			this.groupBox12.Controls.Add(this.label40);
			this.groupBox12.Controls.Add(this.label32);
			this.groupBox12.Controls.Add(this.label35);
			this.groupBox12.Controls.Add(this.label36);
			this.groupBox12.Controls.Add(this.label37);
			this.groupBox12.Controls.Add(this.SubEntity_txtContoCorrente);
			this.groupBox12.Controls.Add(this.SubEntity_txtSportello);
			this.groupBox12.Controls.Add(this.SubEntity_txtBanca);
			this.groupBox12.Controls.Add(this.SubEntity_txtCin);
			this.groupBox12.Location = new System.Drawing.Point(6, 4);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(844, 323);
			this.groupBox12.TabIndex = 24;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Modalit� di pagamento del movimento finanziario corrente";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(620, 244);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(165, 15);
			this.label26.TabIndex = 77;
			this.label26.Text = "Tipologia Trattamento Spese:";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_cmbChargeHandling
			// 
			this.SubEntity_cmbChargeHandling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbChargeHandling.DataSource = this.DS.chargehandling;
			this.SubEntity_cmbChargeHandling.DisplayMember = "description";
			this.SubEntity_cmbChargeHandling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SubEntity_cmbChargeHandling.Location = new System.Drawing.Point(623, 259);
			this.SubEntity_cmbChargeHandling.Name = "SubEntity_cmbChargeHandling";
			this.SubEntity_cmbChargeHandling.Size = new System.Drawing.Size(162, 21);
			this.SubEntity_cmbChargeHandling.TabIndex = 76;
			this.SubEntity_cmbChargeHandling.Tag = "expenselast.idchargehandling?expenseview.idchargehandling";
			this.SubEntity_cmbChargeHandling.ValueMember = "idchargehandling";
			// 
			// SubEntity_chkEsenteSpese
			// 
			this.SubEntity_chkEsenteSpese.Enabled = false;
			this.SubEntity_chkEsenteSpese.Location = new System.Drawing.Point(623, 298);
			this.SubEntity_chkEsenteSpese.Name = "SubEntity_chkEsenteSpese";
			this.SubEntity_chkEsenteSpese.Size = new System.Drawing.Size(151, 20);
			this.SubEntity_chkEsenteSpese.TabIndex = 102;
			this.SubEntity_chkEsenteSpese.TabStop = false;
			this.SubEntity_chkEsenteSpese.Tag = "expenselast.flag:3?expenseview.flag:3";
			this.SubEntity_chkEsenteSpese.Text = "Esente da spese bancarie";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(620, 77);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(121, 17);
			this.label24.TabIndex = 70;
			this.label24.Text = "Conto Banca d\'Italia:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtExtraCode
			// 
			this.SubEntity_txtExtraCode.Location = new System.Drawing.Point(623, 94);
			this.SubEntity_txtExtraCode.Name = "SubEntity_txtExtraCode";
			this.SubEntity_txtExtraCode.Size = new System.Drawing.Size(162, 20);
			this.SubEntity_txtExtraCode.TabIndex = 0;
			this.SubEntity_txtExtraCode.Tag = "expenselast.extracode?expenseview.extracode";
			// 
			// lblCommento
			// 
			this.lblCommento.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lblCommento.Location = new System.Drawing.Point(495, 182);
			this.lblCommento.Name = "lblCommento";
			this.lblCommento.Size = new System.Drawing.Size(229, 49);
			this.lblCommento.TabIndex = 67;
			this.lblCommento.Text = "Da compilare con il riferimento ad un allegato cartaceo o secondo indicazioni def" +
    "inite da precisi accordi con il Tesoriere";
			this.lblCommento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(484, 119);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(66, 13);
			this.label23.TabIndex = 69;
			this.label23.Tag = "";
			this.label23.Text = "BIC/SWIFT:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtBiccode
			// 
			this.SubEntity_txtBiccode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtBiccode.Location = new System.Drawing.Point(487, 136);
			this.SubEntity_txtBiccode.Name = "SubEntity_txtBiccode";
			this.SubEntity_txtBiccode.Size = new System.Drawing.Size(101, 20);
			this.SubEntity_txtBiccode.TabIndex = 68;
			this.SubEntity_txtBiccode.Tag = "expenselast.biccode?expenseview.biccode";
			// 
			// txtModPagamento
			// 
			this.txtModPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtModPagamento.Location = new System.Drawing.Point(149, 23);
			this.txtModPagamento.Name = "txtModPagamento";
			this.txtModPagamento.ReadOnly = true;
			this.txtModPagamento.Size = new System.Drawing.Size(262, 20);
			this.txtModPagamento.TabIndex = 64;
			this.txtModPagamento.TabStop = false;
			this.txtModPagamento.Tag = "";
			// 
			// btnSelModalita
			// 
			this.btnSelModalita.Location = new System.Drawing.Point(8, 21);
			this.btnSelModalita.Name = "btnSelModalita";
			this.btnSelModalita.Size = new System.Drawing.Size(136, 22);
			this.btnSelModalita.TabIndex = 63;
			this.btnSelModalita.TabStop = false;
			this.btnSelModalita.Text = "Seleziona Modalit�";
			this.btnSelModalita.UseVisualStyleBackColor = true;
			this.btnSelModalita.Click += new System.EventHandler(this.btnSelModalita_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(147, 77);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 13);
			this.label11.TabIndex = 58;
			this.label11.Tag = "";
			this.label11.Text = "IBAN:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtIBAN
			// 
			this.SubEntity_txtIBAN.Location = new System.Drawing.Point(149, 94);
			this.SubEntity_txtIBAN.Name = "SubEntity_txtIBAN";
			this.SubEntity_txtIBAN.Size = new System.Drawing.Size(179, 20);
			this.SubEntity_txtIBAN.TabIndex = 1;
			this.SubEntity_txtIBAN.Tag = "expenselast.iban?expenseview.iban";
			// 
			// btnModEstinzione
			// 
			this.btnModEstinzione.Location = new System.Drawing.Point(70, 182);
			this.btnModEstinzione.Name = "btnModEstinzione";
			this.btnModEstinzione.Size = new System.Drawing.Size(74, 23);
			this.btnModEstinzione.TabIndex = 56;
			this.btnModEstinzione.Text = "Modifica";
			this.btnModEstinzione.UseVisualStyleBackColor = true;
			this.btnModEstinzione.Click += new System.EventHandler(this.btnModEstinzione_Click);
			// 
			// SubEntity_txtRifDocumentoEsterno
			// 
			this.SubEntity_txtRifDocumentoEsterno.Location = new System.Drawing.Point(149, 261);
			this.SubEntity_txtRifDocumentoEsterno.Name = "SubEntity_txtRifDocumentoEsterno";
			this.SubEntity_txtRifDocumentoEsterno.ReadOnly = true;
			this.SubEntity_txtRifDocumentoEsterno.Size = new System.Drawing.Size(340, 20);
			this.SubEntity_txtRifDocumentoEsterno.TabIndex = 55;
			this.SubEntity_txtRifDocumentoEsterno.TabStop = false;
			this.SubEntity_txtRifDocumentoEsterno.Tag = "expenselast.refexternaldoc?expenseview.refexternaldoc";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(148, 244);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(189, 15);
			this.label9.TabIndex = 54;
			this.label9.Text = "Riferimento Documento Esterno:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtDelegato
			// 
			this.SubEntity_txtDelegato.Location = new System.Drawing.Point(149, 298);
			this.SubEntity_txtDelegato.Name = "SubEntity_txtDelegato";
			this.SubEntity_txtDelegato.ReadOnly = true;
			this.SubEntity_txtDelegato.Size = new System.Drawing.Size(340, 20);
			this.SubEntity_txtDelegato.TabIndex = 49;
			this.SubEntity_txtDelegato.TabStop = false;
			this.SubEntity_txtDelegato.Tag = "deputy.title?expenseview.deputy";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(148, 284);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 12);
			this.label7.TabIndex = 48;
			this.label7.Text = "Delegato:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_cmbModPagamento
			// 
			this.SubEntity_cmbModPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbModPagamento.DataSource = this.DS.paymethod;
			this.SubEntity_cmbModPagamento.DisplayMember = "description";
			this.SubEntity_cmbModPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SubEntity_cmbModPagamento.Enabled = false;
			this.SubEntity_cmbModPagamento.Location = new System.Drawing.Point(149, 48);
			this.SubEntity_cmbModPagamento.Name = "SubEntity_cmbModPagamento";
			this.SubEntity_cmbModPagamento.Size = new System.Drawing.Size(262, 21);
			this.SubEntity_cmbModPagamento.TabIndex = 2;
			this.SubEntity_cmbModPagamento.Tag = "expenselast.idpaymethod?expenseview.idpaymethod";
			this.SubEntity_cmbModPagamento.ValueMember = "idpaymethod";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(148, 163);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(258, 17);
			this.label38.TabIndex = 47;
			this.label38.Tag = "";
			this.label38.Text = "Note per il Tesoriere-Rif.doc.esterno:";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtDescrModPagamento
			// 
			this.SubEntity_txtDescrModPagamento.Location = new System.Drawing.Point(149, 182);
			this.SubEntity_txtDescrModPagamento.Multiline = true;
			this.SubEntity_txtDescrModPagamento.Name = "SubEntity_txtDescrModPagamento";
			this.SubEntity_txtDescrModPagamento.ReadOnly = true;
			this.SubEntity_txtDescrModPagamento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SubEntity_txtDescrModPagamento.Size = new System.Drawing.Size(340, 57);
			this.SubEntity_txtDescrModPagamento.TabIndex = 7;
			this.SubEntity_txtDescrModPagamento.TabStop = false;
			this.SubEntity_txtDescrModPagamento.Tag = "expenselast.paymentdescr?expenseview.paymentdescr";
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(48, 48);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(96, 20);
			this.label40.TabIndex = 44;
			this.label40.Tag = "";
			this.label40.Text = "Tipo Modalit�:";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(147, 116);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(35, 20);
			this.label32.TabIndex = 42;
			this.label32.Tag = "";
			this.label32.Text = "C/C:";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(484, 74);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(43, 20);
			this.label35.TabIndex = 39;
			this.label35.Tag = "";
			this.label35.Text = "CAB:";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(369, 74);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(29, 20);
			this.label36.TabIndex = 38;
			this.label36.Tag = "";
			this.label36.Text = "ABI:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(369, 116);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(40, 20);
			this.label37.TabIndex = 37;
			this.label37.Tag = "";
			this.label37.Text = "CIN:";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubEntity_txtContoCorrente
			// 
			this.SubEntity_txtContoCorrente.Location = new System.Drawing.Point(149, 136);
			this.SubEntity_txtContoCorrente.Name = "SubEntity_txtContoCorrente";
			this.SubEntity_txtContoCorrente.Size = new System.Drawing.Size(179, 20);
			this.SubEntity_txtContoCorrente.TabIndex = 4;
			this.SubEntity_txtContoCorrente.Tag = "expenselast.cc?expenseview.cc";
			// 
			// SubEntity_txtSportello
			// 
			this.SubEntity_txtSportello.Location = new System.Drawing.Point(487, 94);
			this.SubEntity_txtSportello.Name = "SubEntity_txtSportello";
			this.SubEntity_txtSportello.Size = new System.Drawing.Size(103, 20);
			this.SubEntity_txtSportello.TabIndex = 3;
			this.SubEntity_txtSportello.Tag = "expenselast.idcab?expenseview.idcab";
			// 
			// SubEntity_txtBanca
			// 
			this.SubEntity_txtBanca.Location = new System.Drawing.Point(372, 94);
			this.SubEntity_txtBanca.Name = "SubEntity_txtBanca";
			this.SubEntity_txtBanca.Size = new System.Drawing.Size(88, 20);
			this.SubEntity_txtBanca.TabIndex = 2;
			this.SubEntity_txtBanca.Tag = "expenselast.idbank?expenseview.idbank";
			// 
			// SubEntity_txtCin
			// 
			this.SubEntity_txtCin.Location = new System.Drawing.Point(372, 136);
			this.SubEntity_txtCin.Name = "SubEntity_txtCin";
			this.SubEntity_txtCin.Size = new System.Drawing.Size(34, 20);
			this.SubEntity_txtCin.TabIndex = 5;
			this.SubEntity_txtCin.Tag = "expenselast.cin?expenseview.cin";
			// 
			// tabOpzioniModPagamento
			// 
			this.tabOpzioniModPagamento.Controls.Add(this.groupBox6);
			this.tabOpzioniModPagamento.Location = new System.Drawing.Point(4, 22);
			this.tabOpzioniModPagamento.Name = "tabOpzioniModPagamento";
			this.tabOpzioniModPagamento.Padding = new System.Windows.Forms.Padding(3);
			this.tabOpzioniModPagamento.Size = new System.Drawing.Size(854, 380);
			this.tabOpzioniModPagamento.TabIndex = 1;
			this.tabOpzioniModPagamento.Text = "Opzioni";
			this.tabOpzioniModPagamento.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.groupBox10);
			this.groupBox6.Controls.Add(this.groupBox7);
			this.groupBox6.Controls.Add(this.groupBox8);
			this.groupBox6.Controls.Add(this.chkContoCorrPostale);
			this.groupBox6.Controls.Add(this.chkDelegato);
			this.groupBox6.Controls.Add(this.chkStampaAvviso);
			this.groupBox6.Location = new System.Drawing.Point(3, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(308, 341);
			this.groupBox6.TabIndex = 6;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Opzioni";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.checkBox8);
			this.groupBox10.Controls.Add(this.checkBox9);
			this.groupBox10.Location = new System.Drawing.Point(6, 72);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(195, 52);
			this.groupBox10.TabIndex = 20;
			this.groupBox10.TabStop = false;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(7, 28);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(97, 17);
			this.checkBox8.TabIndex = 18;
			this.checkBox8.Tag = "expenselast.paymethod_flag:14";
			this.checkBox8.Text = "Bonifico Estero";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(7, 11);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(95, 17);
			this.checkBox9.TabIndex = 17;
			this.checkBox9.Tag = "expenselast.paymethod_flag:13";
			this.checkBox9.Text = "Bonifico SEPA";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.checkBox7);
			this.groupBox7.Controls.Add(this.checkBox6);
			this.groupBox7.Controls.Add(this.checkBox5);
			this.groupBox7.Controls.Add(this.checkBox4);
			this.groupBox7.Controls.Add(this.checkBox3);
			this.groupBox7.Controls.Add(this.checkBox2);
			this.groupBox7.Controls.Add(this.checkBox1);
			this.groupBox7.Location = new System.Drawing.Point(6, 184);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(269, 151);
			this.groupBox7.TabIndex = 10;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Istituto cassiere";
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(6, 114);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(247, 17);
			this.checkBox7.TabIndex = 14;
			this.checkBox7.Tag = "expenselast.paymethod_flag:12";
			this.checkBox7.Text = "Fruttifera (Tipo Cont. Ente Ricevente Girofondi)";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(6, 95);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(144, 17);
			this.checkBox6.TabIndex = 13;
			this.checkBox6.Tag = "expenselast.paymethod_flag:11";
			this.checkBox6.Text = "Girofondi vincolati TAB B";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(6, 74);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(139, 17);
			this.checkBox5.TabIndex = 12;
			this.checkBox5.Tag = "expenselast.paymethod_flag:10";
			this.checkBox5.Text = "Girofondi ordinari TAB B";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(6, 55);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(144, 17);
			this.checkBox4.TabIndex = 11;
			this.checkBox4.Tag = "expenselast.paymethod_flag:9";
			this.checkBox4.Text = "Girofondi vincolati TAB A";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(6, 37);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(139, 17);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Tag = "expenselast.paymethod_flag:8";
			this.checkBox3.Text = "Girofondi ordinari TAB A";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(6, 135);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(67, 17);
			this.checkBox2.TabIndex = 9;
			this.checkBox2.Tag = "expenselast.paymethod_flag:7";
			this.checkBox2.Text = "Sportello";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(68, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Tag = "expenselast.paymethod_flag:6";
			this.checkBox1.Text = "Girofondi";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.chkObbligoCoordBanc);
			this.groupBox8.Controls.Add(this.chkDivietoCoordBanc);
			this.groupBox8.Location = new System.Drawing.Point(7, 130);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(195, 52);
			this.groupBox8.TabIndex = 9;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Coordinate bancarie";
			// 
			// chkObbligoCoordBanc
			// 
			this.chkObbligoCoordBanc.AutoSize = true;
			this.chkObbligoCoordBanc.Location = new System.Drawing.Point(6, 14);
			this.chkObbligoCoordBanc.Name = "chkObbligoCoordBanc";
			this.chkObbligoCoordBanc.Size = new System.Drawing.Size(82, 17);
			this.chkObbligoCoordBanc.TabIndex = 4;
			this.chkObbligoCoordBanc.Tag = "expenselast.paymethod_flag:2";
			this.chkObbligoCoordBanc.Text = "Obbligatorie";
			this.chkObbligoCoordBanc.UseVisualStyleBackColor = true;
			// 
			// chkDivietoCoordBanc
			// 
			this.chkDivietoCoordBanc.AutoSize = true;
			this.chkDivietoCoordBanc.Location = new System.Drawing.Point(6, 31);
			this.chkDivietoCoordBanc.Name = "chkDivietoCoordBanc";
			this.chkDivietoCoordBanc.Size = new System.Drawing.Size(115, 17);
			this.chkDivietoCoordBanc.TabIndex = 5;
			this.chkDivietoCoordBanc.Tag = "expenselast.paymethod_flag:3";
			this.chkDivietoCoordBanc.Text = "Da non specificare";
			this.chkDivietoCoordBanc.UseVisualStyleBackColor = true;
			// 
			// chkContoCorrPostale
			// 
			this.chkContoCorrPostale.AutoSize = true;
			this.chkContoCorrPostale.Location = new System.Drawing.Point(13, 52);
			this.chkContoCorrPostale.Name = "chkContoCorrPostale";
			this.chkContoCorrPostale.Size = new System.Drawing.Size(133, 17);
			this.chkContoCorrPostale.TabIndex = 8;
			this.chkContoCorrPostale.Tag = "expenselast.paymethod_flag:1";
			this.chkContoCorrPostale.Text = "Conto corrente postale";
			this.chkContoCorrPostale.UseVisualStyleBackColor = true;
			// 
			// chkDelegato
			// 
			this.chkDelegato.AutoSize = true;
			this.chkDelegato.Location = new System.Drawing.Point(13, 18);
			this.chkDelegato.Name = "chkDelegato";
			this.chkDelegato.Size = new System.Drawing.Size(109, 17);
			this.chkDelegato.TabIndex = 3;
			this.chkDelegato.Tag = "expenselast.paymethod_allowdeputy:S:N";
			this.chkDelegato.Text = "Ammetti Delegato";
			// 
			// chkStampaAvviso
			// 
			this.chkStampaAvviso.AutoSize = true;
			this.chkStampaAvviso.Location = new System.Drawing.Point(13, 34);
			this.chkStampaAvviso.Name = "chkStampaAvviso";
			this.chkStampaAvviso.Size = new System.Drawing.Size(163, 17);
			this.chkStampaAvviso.TabIndex = 2;
			this.chkStampaAvviso.Tag = "expenselast.paymethod_flag:0";
			this.chkStampaAvviso.Text = "Stampa avviso di pagamento";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label29);
			this.tabPage1.Controls.Add(this.txtTotaleSospesi);
			this.tabPage1.Controls.Add(this.btnMultipleBillSel);
			this.tabPage1.Controls.Add(this.labBollette2);
			this.tabPage1.Controls.Add(this.labBollette1);
			this.tabPage1.Controls.Add(this.btnAddBolletta);
			this.tabPage1.Controls.Add(this.btnDelBolletta);
			this.tabPage1.Controls.Add(this.btnEditBolletta);
			this.tabPage1.Controls.Add(this.dgridBollette);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(854, 380);
			this.tabPage1.TabIndex = 2;
			this.tabPage1.Text = "Collegamento multiplo a bollette";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(689, 43);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(75, 13);
			this.label29.TabIndex = 105;
			this.label29.Text = "Totale sospesi";
			// 
			// txtTotaleSospesi
			// 
			this.txtTotaleSospesi.Location = new System.Drawing.Point(770, 40);
			this.txtTotaleSospesi.Name = "txtTotaleSospesi";
			this.txtTotaleSospesi.Size = new System.Drawing.Size(85, 20);
			this.txtTotaleSospesi.TabIndex = 104;
			this.txtTotaleSospesi.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// btnMultipleBillSel
			// 
			this.btnMultipleBillSel.Location = new System.Drawing.Point(6, 202);
			this.btnMultipleBillSel.Name = "btnMultipleBillSel";
			this.btnMultipleBillSel.Size = new System.Drawing.Size(75, 42);
			this.btnMultipleBillSel.TabIndex = 29;
			this.btnMultipleBillSel.TabStop = false;
			this.btnMultipleBillSel.Tag = "";
			this.btnMultipleBillSel.Text = "Selezione multipla";
			this.btnMultipleBillSel.Click += new System.EventHandler(this.btnMultipleBillSel_Click);
			// 
			// labBollette2
			// 
			this.labBollette2.AutoSize = true;
			this.labBollette2.Location = new System.Drawing.Point(84, 40);
			this.labBollette2.Name = "labBollette2";
			this.labBollette2.Size = new System.Drawing.Size(566, 13);
			this.labBollette2.TabIndex = 28;
			this.labBollette2.Text = "Per utilizzare il collegamento multiplo con le bollette � necessario non selezion" +
    "are una bolletta nella maschera principale";
			// 
			// labBollette1
			// 
			this.labBollette1.AutoSize = true;
			this.labBollette1.Location = new System.Drawing.Point(84, 15);
			this.labBollette1.Name = "labBollette1";
			this.labBollette1.Size = new System.Drawing.Size(625, 13);
			this.labBollette1.TabIndex = 27;
			this.labBollette1.Text = "Per utilizzare il collegamento multiplo con le bollette � necessario selezionare " +
    "\"Regolarizza disposizione di pagamento gi� effettuata\"";
			// 
			// btnAddBolletta
			// 
			this.btnAddBolletta.Location = new System.Drawing.Point(6, 94);
			this.btnAddBolletta.Name = "btnAddBolletta";
			this.btnAddBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnAddBolletta.TabIndex = 24;
			this.btnAddBolletta.TabStop = false;
			this.btnAddBolletta.Tag = "insert.default";
			this.btnAddBolletta.Text = "Inserisci...";
			// 
			// btnDelBolletta
			// 
			this.btnDelBolletta.Location = new System.Drawing.Point(6, 152);
			this.btnDelBolletta.Name = "btnDelBolletta";
			this.btnDelBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnDelBolletta.TabIndex = 26;
			this.btnDelBolletta.TabStop = false;
			this.btnDelBolletta.Tag = "delete";
			this.btnDelBolletta.Text = "Elimina";
			// 
			// btnEditBolletta
			// 
			this.btnEditBolletta.Location = new System.Drawing.Point(6, 123);
			this.btnEditBolletta.Name = "btnEditBolletta";
			this.btnEditBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnEditBolletta.TabIndex = 25;
			this.btnEditBolletta.TabStop = false;
			this.btnEditBolletta.Tag = "edit.default";
			this.btnEditBolletta.Text = "Modifica...";
			// 
			// dgridBollette
			// 
			this.dgridBollette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridBollette.DataMember = "";
			this.dgridBollette.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridBollette.Location = new System.Drawing.Point(87, 66);
			this.dgridBollette.Name = "dgridBollette";
			this.dgridBollette.Size = new System.Drawing.Size(762, 295);
			this.dgridBollette.TabIndex = 16;
			this.dgridBollette.Tag = "expensebill.list.default";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(174, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(696, 56);
			this.textBox1.TabIndex = 31;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Il numero del mandato di pagamento viene riempito solo quando verr� emesso il man" +
    "dato da associare al movimento di spesa";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(8, 70);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1074, 2);
			this.panel1.TabIndex = 30;
			// 
			// tabRecup
			// 
			this.tabRecup.Controls.Add(this.groupBox4);
			this.tabRecup.Controls.Add(this.groupBox2);
			this.tabRecup.Location = new System.Drawing.Point(4, 23);
			this.tabRecup.Name = "tabRecup";
			this.tabRecup.Size = new System.Drawing.Size(874, 493);
			this.tabRecup.TabIndex = 4;
			this.tabRecup.Text = "Recuperi";
			this.tabRecup.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.btnAggiornaRecupero);
			this.groupBox4.Controls.Add(this.dGridRecuperi);
			this.groupBox4.Controls.Add(this.label25);
			this.groupBox4.Controls.Add(this.txtRecuperiTotale);
			this.groupBox4.Controls.Add(this.btnEliminaRecuperi);
			this.groupBox4.Controls.Add(this.btnModificaRecuperi);
			this.groupBox4.Controls.Add(this.btnInserisciRecuperi);
			this.groupBox4.Controls.Add(this.SubEntity_chkAutomRecuperi);
			this.groupBox4.Controls.Add(this.btnAutomatismiRecuperi);
			this.groupBox4.Location = new System.Drawing.Point(8, 72);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(864, 413);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Elenco dei recuperi che si intende generare unitamente al movimento di spesa";
			// 
			// btnAggiornaRecupero
			// 
			this.btnAggiornaRecupero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAggiornaRecupero.Location = new System.Drawing.Point(499, 381);
			this.btnAggiornaRecupero.Name = "btnAggiornaRecupero";
			this.btnAggiornaRecupero.Size = new System.Drawing.Size(196, 24);
			this.btnAggiornaRecupero.TabIndex = 36;
			this.btnAggiornaRecupero.TabStop = false;
			this.btnAggiornaRecupero.Tag = " ";
			this.btnAggiornaRecupero.Text = "Aggiorna Recupero Split Payment";
			this.btnAggiornaRecupero.Click += new System.EventHandler(this.btnAggiornaRecupero_Click);
			// 
			// dGridRecuperi
			// 
			this.dGridRecuperi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dGridRecuperi.DataMember = "";
			this.dGridRecuperi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridRecuperi.Location = new System.Drawing.Point(104, 24);
			this.dGridRecuperi.Name = "dGridRecuperi";
			this.dGridRecuperi.Size = new System.Drawing.Size(751, 349);
			this.dGridRecuperi.TabIndex = 25;
			this.dGridRecuperi.Tag = "expenseclawback.lista.default";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(8, 128);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(96, 32);
			this.label25.TabIndex = 23;
			this.label25.Text = "Totale dei recuperi elencati:";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtRecuperiTotale
			// 
			this.txtRecuperiTotale.Location = new System.Drawing.Point(6, 163);
			this.txtRecuperiTotale.Name = "txtRecuperiTotale";
			this.txtRecuperiTotale.ReadOnly = true;
			this.txtRecuperiTotale.Size = new System.Drawing.Size(88, 20);
			this.txtRecuperiTotale.TabIndex = 24;
			this.txtRecuperiTotale.TabStop = false;
			this.txtRecuperiTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnEliminaRecuperi
			// 
			this.btnEliminaRecuperi.Location = new System.Drawing.Point(8, 96);
			this.btnEliminaRecuperi.Name = "btnEliminaRecuperi";
			this.btnEliminaRecuperi.Size = new System.Drawing.Size(75, 23);
			this.btnEliminaRecuperi.TabIndex = 22;
			this.btnEliminaRecuperi.TabStop = false;
			this.btnEliminaRecuperi.Tag = "delete";
			this.btnEliminaRecuperi.Text = "Elimina";
			// 
			// btnModificaRecuperi
			// 
			this.btnModificaRecuperi.Location = new System.Drawing.Point(8, 64);
			this.btnModificaRecuperi.Name = "btnModificaRecuperi";
			this.btnModificaRecuperi.Size = new System.Drawing.Size(75, 23);
			this.btnModificaRecuperi.TabIndex = 21;
			this.btnModificaRecuperi.TabStop = false;
			this.btnModificaRecuperi.Tag = "edit.default";
			this.btnModificaRecuperi.Text = "Modifica...";
			// 
			// btnInserisciRecuperi
			// 
			this.btnInserisciRecuperi.Location = new System.Drawing.Point(8, 32);
			this.btnInserisciRecuperi.Name = "btnInserisciRecuperi";
			this.btnInserisciRecuperi.Size = new System.Drawing.Size(75, 23);
			this.btnInserisciRecuperi.TabIndex = 20;
			this.btnInserisciRecuperi.TabStop = false;
			this.btnInserisciRecuperi.Tag = "insert.default";
			this.btnInserisciRecuperi.Text = "Inserisci...";
			// 
			// SubEntity_chkAutomRecuperi
			// 
			this.SubEntity_chkAutomRecuperi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SubEntity_chkAutomRecuperi.Location = new System.Drawing.Point(104, 381);
			this.SubEntity_chkAutomRecuperi.Name = "SubEntity_chkAutomRecuperi";
			this.SubEntity_chkAutomRecuperi.Size = new System.Drawing.Size(328, 24);
			this.SubEntity_chkAutomRecuperi.TabIndex = 1;
			this.SubEntity_chkAutomRecuperi.Tag = "expenselast.flag:2?expenseview.flag:2";
			this.SubEntity_chkAutomRecuperi.Text = "Non generare automatismi";
			// 
			// btnAutomatismiRecuperi
			// 
			this.btnAutomatismiRecuperi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutomatismiRecuperi.Location = new System.Drawing.Point(712, 381);
			this.btnAutomatismiRecuperi.Name = "btnAutomatismiRecuperi";
			this.btnAutomatismiRecuperi.Size = new System.Drawing.Size(143, 23);
			this.btnAutomatismiRecuperi.TabIndex = 34;
			this.btnAutomatismiRecuperi.TabStop = false;
			this.btnAutomatismiRecuperi.Text = "Visualizza automatismi";
			this.btnAutomatismiRecuperi.Click += new System.EventHandler(this.btnAutomatismiRecuperi_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.cmbRecupero);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(864, 64);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Codice del Recupero con il quale si � trattenuta o si recuperer� in futuro la som" +
    "ma che si sta versando";
			// 
			// cmbRecupero
			// 
			this.cmbRecupero.DataSource = this.DS.clawback_expense;
			this.cmbRecupero.DisplayMember = "description";
			this.cmbRecupero.Location = new System.Drawing.Point(104, 24);
			this.cmbRecupero.Name = "cmbRecupero";
			this.cmbRecupero.Size = new System.Drawing.Size(418, 21);
			this.cmbRecupero.TabIndex = 1;
			this.cmbRecupero.Tag = "expense.idclawback";
			this.cmbRecupero.ValueMember = "idclawback";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.clawback_expense.default";
			this.button1.Text = "Recupero";
			// 
			// tabFinanziamenti
			// 
			this.tabFinanziamenti.Controls.Add(this.gboxFinCassa);
			this.tabFinanziamenti.Controls.Add(this.gboxFinCompetenza);
			this.tabFinanziamenti.Location = new System.Drawing.Point(4, 23);
			this.tabFinanziamenti.Name = "tabFinanziamenti";
			this.tabFinanziamenti.Padding = new System.Windows.Forms.Padding(3);
			this.tabFinanziamenti.Size = new System.Drawing.Size(874, 493);
			this.tabFinanziamenti.TabIndex = 9;
			this.tabFinanziamenti.Text = "Finanziamento";
			this.tabFinanziamenti.UseVisualStyleBackColor = true;
			// 
			// gboxFinCassa
			// 
			this.gboxFinCassa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxFinCassa.Controls.Add(this.button2);
			this.gboxFinCassa.Controls.Add(this.btnCercaFinanziamentoCassa);
			this.gboxFinCassa.Controls.Add(this.dataGrid1);
			this.gboxFinCassa.Controls.Add(this.txtTotFinanziatoCassa);
			this.gboxFinCassa.Controls.Add(this.button5);
			this.gboxFinCassa.Controls.Add(this.label21);
			this.gboxFinCassa.Controls.Add(this.button6);
			this.gboxFinCassa.Location = new System.Drawing.Point(8, 238);
			this.gboxFinCassa.Name = "gboxFinCassa";
			this.gboxFinCassa.Size = new System.Drawing.Size(860, 236);
			this.gboxFinCassa.TabIndex = 48;
			this.gboxFinCassa.TabStop = false;
			this.gboxFinCassa.Text = "Finanziamenti usati per la cassa e/o per le assegnazioni di cassa";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 39;
			this.button2.TabStop = false;
			this.button2.Tag = "insert.detail";
			this.button2.Text = "Inserisci...";
			// 
			// btnCercaFinanziamentoCassa
			// 
			this.btnCercaFinanziamentoCassa.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCercaFinanziamentoCassa.Location = new System.Drawing.Point(128, 199);
			this.btnCercaFinanziamentoCassa.Name = "btnCercaFinanziamentoCassa";
			this.btnCercaFinanziamentoCassa.Size = new System.Drawing.Size(161, 23);
			this.btnCercaFinanziamentoCassa.TabIndex = 44;
			this.btnCercaFinanziamentoCassa.TabStop = false;
			this.btnCercaFinanziamentoCassa.Tag = "";
			this.btnCercaFinanziamentoCassa.Text = "Aggiungi automaticamente";
			this.btnCercaFinanziamentoCassa.Click += new System.EventHandler(this.btnCercaFinanziamentoCassa_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.AllowNavigation = false;
			this.dataGrid1.AllowSorting = false;
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(86, 19);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ParentRowsVisible = false;
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(768, 176);
			this.dataGrid1.TabIndex = 29;
			this.dataGrid1.Tag = "underwritingpayment.spesa.detail";
			// 
			// txtTotFinanziatoCassa
			// 
			this.txtTotFinanziatoCassa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotFinanziatoCassa.Location = new System.Drawing.Point(720, 200);
			this.txtTotFinanziatoCassa.Name = "txtTotFinanziatoCassa";
			this.txtTotFinanziatoCassa.ReadOnly = true;
			this.txtTotFinanziatoCassa.Size = new System.Drawing.Size(134, 20);
			this.txtTotFinanziatoCassa.TabIndex = 43;
			this.txtTotFinanziatoCassa.TabStop = false;
			this.txtTotFinanziatoCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 51);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 40;
			this.button5.TabStop = false;
			this.button5.Tag = "edit.detail";
			this.button5.Text = "Modifica...";
			// 
			// label21
			// 
			this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(615, 204);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(85, 13);
			this.label21.TabIndex = 42;
			this.label21.Text = "Totale finanziato";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(6, 83);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 41;
			this.button6.TabStop = false;
			this.button6.Tag = "delete";
			this.button6.Text = "Elimina";
			// 
			// gboxFinCompetenza
			// 
			this.gboxFinCompetenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxFinCompetenza.Controls.Add(this.btnAddFinanziamento);
			this.gboxFinCompetenza.Controls.Add(this.btnCercaFinanziamentoCrediti);
			this.gboxFinCompetenza.Controls.Add(this.dgridFinanziamenti);
			this.gboxFinCompetenza.Controls.Add(this.txtTotFinanziatoCrediti);
			this.gboxFinCompetenza.Controls.Add(this.btnEditFinanziamento);
			this.gboxFinCompetenza.Controls.Add(this.label22);
			this.gboxFinCompetenza.Controls.Add(this.btnDeleteFinanziamento);
			this.gboxFinCompetenza.Location = new System.Drawing.Point(8, 6);
			this.gboxFinCompetenza.Name = "gboxFinCompetenza";
			this.gboxFinCompetenza.Size = new System.Drawing.Size(860, 226);
			this.gboxFinCompetenza.TabIndex = 47;
			this.gboxFinCompetenza.TabStop = false;
			this.gboxFinCompetenza.Text = "Finanziamenti usati per la competenza e/o per i crediti";
			// 
			// btnAddFinanziamento
			// 
			this.btnAddFinanziamento.Location = new System.Drawing.Point(6, 19);
			this.btnAddFinanziamento.Name = "btnAddFinanziamento";
			this.btnAddFinanziamento.Size = new System.Drawing.Size(75, 23);
			this.btnAddFinanziamento.TabIndex = 39;
			this.btnAddFinanziamento.TabStop = false;
			this.btnAddFinanziamento.Tag = "insert.detail";
			this.btnAddFinanziamento.Text = "Inserisci...";
			// 
			// btnCercaFinanziamentoCrediti
			// 
			this.btnCercaFinanziamentoCrediti.Location = new System.Drawing.Point(86, 183);
			this.btnCercaFinanziamentoCrediti.Name = "btnCercaFinanziamentoCrediti";
			this.btnCercaFinanziamentoCrediti.Size = new System.Drawing.Size(161, 23);
			this.btnCercaFinanziamentoCrediti.TabIndex = 44;
			this.btnCercaFinanziamentoCrediti.TabStop = false;
			this.btnCercaFinanziamentoCrediti.Tag = "";
			this.btnCercaFinanziamentoCrediti.Text = "Aggiungi automaticamente";
			this.btnCercaFinanziamentoCrediti.Click += new System.EventHandler(this.btnCercaFinanziamentoCrediti_Click);
			// 
			// dgridFinanziamenti
			// 
			this.dgridFinanziamenti.AllowNavigation = false;
			this.dgridFinanziamenti.AllowSorting = false;
			this.dgridFinanziamenti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgridFinanziamenti.DataMember = "";
			this.dgridFinanziamenti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgridFinanziamenti.Location = new System.Drawing.Point(86, 19);
			this.dgridFinanziamenti.Name = "dgridFinanziamenti";
			this.dgridFinanziamenti.ParentRowsVisible = false;
			this.dgridFinanziamenti.ReadOnly = true;
			this.dgridFinanziamenti.Size = new System.Drawing.Size(768, 158);
			this.dgridFinanziamenti.TabIndex = 29;
			this.dgridFinanziamenti.Tag = "underwritingappropriation.spesa.detail";
			// 
			// txtTotFinanziatoCrediti
			// 
			this.txtTotFinanziatoCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotFinanziatoCrediti.Location = new System.Drawing.Point(720, 190);
			this.txtTotFinanziatoCrediti.Name = "txtTotFinanziatoCrediti";
			this.txtTotFinanziatoCrediti.ReadOnly = true;
			this.txtTotFinanziatoCrediti.Size = new System.Drawing.Size(134, 20);
			this.txtTotFinanziatoCrediti.TabIndex = 43;
			this.txtTotFinanziatoCrediti.TabStop = false;
			this.txtTotFinanziatoCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnEditFinanziamento
			// 
			this.btnEditFinanziamento.Location = new System.Drawing.Point(6, 51);
			this.btnEditFinanziamento.Name = "btnEditFinanziamento";
			this.btnEditFinanziamento.Size = new System.Drawing.Size(75, 23);
			this.btnEditFinanziamento.TabIndex = 40;
			this.btnEditFinanziamento.TabStop = false;
			this.btnEditFinanziamento.Tag = "edit.detail";
			this.btnEditFinanziamento.Text = "Modifica...";
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(615, 193);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(85, 13);
			this.label22.TabIndex = 42;
			this.label22.Text = "Totale finanziato";
			// 
			// btnDeleteFinanziamento
			// 
			this.btnDeleteFinanziamento.Location = new System.Drawing.Point(6, 83);
			this.btnDeleteFinanziamento.Name = "btnDeleteFinanziamento";
			this.btnDeleteFinanziamento.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteFinanziamento.TabIndex = 41;
			this.btnDeleteFinanziamento.TabStop = false;
			this.btnDeleteFinanziamento.Tag = "delete";
			this.btnDeleteFinanziamento.Text = "Elimina";
			// 
			// tabVariaz
			// 
			this.tabVariaz.Controls.Add(this.GBoxVariazioni);
			this.tabVariaz.Location = new System.Drawing.Point(4, 23);
			this.tabVariaz.Name = "tabVariaz";
			this.tabVariaz.Size = new System.Drawing.Size(874, 493);
			this.tabVariaz.TabIndex = 6;
			this.tabVariaz.Text = "Variazioni";
			this.tabVariaz.UseVisualStyleBackColor = true;
			// 
			// GBoxVariazioni
			// 
			this.GBoxVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GBoxVariazioni.Controls.Add(this.btnDelVar);
			this.GBoxVariazioni.Controls.Add(this.btnEditVar);
			this.GBoxVariazioni.Controls.Add(this.btnInsertVar);
			this.GBoxVariazioni.Controls.Add(this.gridVariazioni);
			this.GBoxVariazioni.Location = new System.Drawing.Point(8, 8);
			this.GBoxVariazioni.Name = "GBoxVariazioni";
			this.GBoxVariazioni.Size = new System.Drawing.Size(856, 477);
			this.GBoxVariazioni.TabIndex = 1;
			this.GBoxVariazioni.TabStop = false;
			this.GBoxVariazioni.Text = "Variazioni al movimento di spesa corrente";
			// 
			// btnDelVar
			// 
			this.btnDelVar.Location = new System.Drawing.Point(192, 24);
			this.btnDelVar.Name = "btnDelVar";
			this.btnDelVar.Size = new System.Drawing.Size(75, 23);
			this.btnDelVar.TabIndex = 27;
			this.btnDelVar.Tag = "delete";
			this.btnDelVar.Text = "Elimina";
			// 
			// btnEditVar
			// 
			this.btnEditVar.Location = new System.Drawing.Point(104, 24);
			this.btnEditVar.Name = "btnEditVar";
			this.btnEditVar.Size = new System.Drawing.Size(75, 23);
			this.btnEditVar.TabIndex = 26;
			this.btnEditVar.Tag = "edit.detail";
			this.btnEditVar.Text = "Modifica...";
			// 
			// btnInsertVar
			// 
			this.btnInsertVar.Location = new System.Drawing.Point(16, 24);
			this.btnInsertVar.Name = "btnInsertVar";
			this.btnInsertVar.Size = new System.Drawing.Size(75, 23);
			this.btnInsertVar.TabIndex = 25;
			this.btnInsertVar.Tag = "insert.detail";
			this.btnInsertVar.Text = "Inserisci...";
			// 
			// gridVariazioni
			// 
			this.gridVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridVariazioni.DataMember = "";
			this.gridVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridVariazioni.Location = new System.Drawing.Point(16, 58);
			this.gridVariazioni.Name = "gridVariazioni";
			this.gridVariazioni.Size = new System.Drawing.Size(832, 403);
			this.gridVariazioni.TabIndex = 30;
			this.gridVariazioni.Tag = "expensevar.default.detail";
			// 
			// tabFatture
			// 
			this.tabFatture.Controls.Add(this.gboxDettInvoice);
			this.tabFatture.Location = new System.Drawing.Point(4, 23);
			this.tabFatture.Name = "tabFatture";
			this.tabFatture.Size = new System.Drawing.Size(874, 493);
			this.tabFatture.TabIndex = 10;
			this.tabFatture.Text = "Fatture";
			this.tabFatture.UseVisualStyleBackColor = true;
			// 
			// gboxDettInvoice
			// 
			this.gboxDettInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDettInvoice.Controls.Add(this.btnEditInvDet);
			this.gboxDettInvoice.Controls.Add(this.txtTotInvoiceDetail);
			this.gboxDettInvoice.Controls.Add(this.label17);
			this.gboxDettInvoice.Controls.Add(this.btnRemoveDettInvoice);
			this.gboxDettInvoice.Controls.Add(this.btnAddDettInvoice);
			this.gboxDettInvoice.Controls.Add(this.dgrDettagliFattura);
			this.gboxDettInvoice.Location = new System.Drawing.Point(3, 15);
			this.gboxDettInvoice.Name = "gboxDettInvoice";
			this.gboxDettInvoice.Size = new System.Drawing.Size(856, 277);
			this.gboxDettInvoice.TabIndex = 2;
			this.gboxDettInvoice.TabStop = false;
			this.gboxDettInvoice.Text = "Dettagli Fattura";
			// 
			// btnEditInvDet
			// 
			this.btnEditInvDet.Location = new System.Drawing.Point(8, 88);
			this.btnEditInvDet.Name = "btnEditInvDet";
			this.btnEditInvDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditInvDet.TabIndex = 7;
			this.btnEditInvDet.Text = "Modifica..";
			this.btnEditInvDet.Click += new System.EventHandler(this.btnModificaDettInvoice_Click);
			// 
			// txtTotInvoiceDetail
			// 
			this.txtTotInvoiceDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotInvoiceDetail.Location = new System.Drawing.Point(7, 246);
			this.txtTotInvoiceDetail.Name = "txtTotInvoiceDetail";
			this.txtTotInvoiceDetail.ReadOnly = true;
			this.txtTotInvoiceDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotInvoiceDetail.TabIndex = 6;
			this.txtTotInvoiceDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Location = new System.Drawing.Point(7, 230);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 16);
			this.label17.TabIndex = 5;
			this.label17.Text = "Totale";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRemoveDettInvoice
			// 
			this.btnRemoveDettInvoice.Location = new System.Drawing.Point(8, 56);
			this.btnRemoveDettInvoice.Name = "btnRemoveDettInvoice";
			this.btnRemoveDettInvoice.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDettInvoice.TabIndex = 4;
			this.btnRemoveDettInvoice.Text = "Rimuovi";
			this.btnRemoveDettInvoice.Click += new System.EventHandler(this.btnScollegaDettInvoice_Click);
			// 
			// btnAddDettInvoice
			// 
			this.btnAddDettInvoice.Location = new System.Drawing.Point(8, 24);
			this.btnAddDettInvoice.Name = "btnAddDettInvoice";
			this.btnAddDettInvoice.Size = new System.Drawing.Size(75, 23);
			this.btnAddDettInvoice.TabIndex = 3;
			this.btnAddDettInvoice.Text = "Aggiungi";
			this.btnAddDettInvoice.Click += new System.EventHandler(this.btnCollegaDettInvoice_Click);
			// 
			// dgrDettagliFattura
			// 
			this.dgrDettagliFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettagliFattura.DataMember = "";
			this.dgrDettagliFattura.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettagliFattura.Location = new System.Drawing.Point(96, 16);
			this.dgrDettagliFattura.Name = "dgrDettagliFattura";
			this.dgrDettagliFattura.Size = new System.Drawing.Size(752, 253);
			this.dgrDettagliFattura.TabIndex = 2;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// chkPattoIntegrita
			// 
			this.chkPattoIntegrita.AutoSize = true;
			this.chkPattoIntegrita.Location = new System.Drawing.Point(14, 272);
			this.chkPattoIntegrita.Name = "chkPattoIntegrita";
			this.chkPattoIntegrita.Size = new System.Drawing.Size(103, 17);
			this.chkPattoIntegrita.TabIndex = 100;
			this.chkPattoIntegrita.Tag = "expenselast.paymethod_flag:23?expenseview.paymethod_flag:23";
			this.chkPattoIntegrita.Text = "Patto di Integrit�";
			this.chkPattoIntegrita.UseVisualStyleBackColor = true;
			// 
			// Frm_expense_levels
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(882, 520);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Frm_expense_levels";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Movimento di spesa";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			this.groupBox17.ResumeLayout(false);
			this.groupBox17.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.gboxFasePrecedente.ResumeLayout(false);
			this.gboxFasePrecedente.PerformLayout();
			this.gboxMovimento.ResumeLayout(false);
			this.gboxMovimento.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.gboxRitDipendente.ResumeLayout(false);
			this.gboxRitDipendente.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.griddetriten)).EndInit();
			this.gboxContrEnte.ResumeLayout(false);
			this.gboxContrEnte.PerformLayout();
			this.groupBox15.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
			this.gboxDocumento.ResumeLayout(false);
			this.gboxDocumento.PerformLayout();
			this.gBoxImportiPrestazione.ResumeLayout(false);
			this.gBoxImportiPrestazione.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabMovFin.ResumeLayout(false);
			this.tabMovFin.PerformLayout();
			this.gboxBolletta.ResumeLayout(false);
			this.gboxBolletta.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.gboxBilAnnuale.ResumeLayout(false);
			this.gboxBilAnnuale.PerformLayout();
			this.tabClassSup.ResumeLayout(false);
			this.tabPageAltro.ResumeLayout(false);
			this.tabPageAltro.PerformLayout();
			this.gboxEntrata.ResumeLayout(false);
			this.gboxEntrata.PerformLayout();
			this.grpContodebito.ResumeLayout(false);
			this.grpContodebito.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.tabPrest.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabTax.ResumeLayout(false);
			this.tabCorrige.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgCorrige)).EndInit();
			this.tabOfficial.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgOfficial)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabDetails.ResumeLayout(false);
			this.gboxIncassoDettContratti.ResumeLayout(false);
			this.gboxIncassoDettContratti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettPagamenti)).EndInit();
			this.gboxDettmandate.ResumeLayout(false);
			this.gboxDettmandate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliOrdine)).EndInit();
			this.tabPagam.ResumeLayout(false);
			this.tabPagam.PerformLayout();
			this.tabModPagamento.ResumeLayout(false);
			this.tabInfoModPagamento.ResumeLayout(false);
			this.tabInfoModPagamento.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.tabOpzioniModPagamento.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).EndInit();
			this.tabRecup.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridRecuperi)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.tabFinanziamenti.ResumeLayout(false);
			this.gboxFinCassa.ResumeLayout(false);
			this.gboxFinCassa.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.gboxFinCompetenza.ResumeLayout(false);
			this.gboxFinCompetenza.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridFinanziamenti)).EndInit();
			this.tabVariaz.ResumeLayout(false);
			this.GBoxVariazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridVariazioni)).EndInit();
			this.tabFatture.ResumeLayout(false);
			this.gboxDettInvoice.ResumeLayout(false);
			this.gboxDettInvoice.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        #region funzioni Help su inclusione Fasi

        bool faseBilancioInclusa() {
            return (ManageUPB.faseattivazione == currphase);
        }

        bool faseMissioneInclusa() {
            return (fasemissione == currphase);
        }

        bool faseOrdineInclusa() {
            return (faseordine == currphase);
        }

        bool faseIvaInclusa() {
            return (faseiva == currphase);
        }

        bool faseCedolinoInclusa() {
            return (fasecedolino == currphase);
        }

        bool faseMaxInclusa() {
            return (fasespesamax == currphase);
        }

        bool faseOccasionaleInclusa() {
            return (faseoccasionale == currphase);
        }

        bool faseProfessionaleInclusa() {
            return (faseprofessionale == currphase);
        }

        bool faseDipendenteInclusa() {
            return (fasedipendente == currphase);
        }

        #endregion

        private int flagUniconfig;
        void AfterLinkBody() {
            MyConn = MetaData.GetConnection(this);
            QHC = new CQueryHelper();
            QHS = MyConn.GetQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            flagUniconfig = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "flag"));

            GetData.SetStaticFilter(DS.mandatekind, QHS.NullOrEq("isrequest", "N"));

            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.SetStaticFilter(DS.expenseyear, filteresercizio);
            GetData.SetStaticFilter(DS.expensesorted, filteresercizio);
            GetData.SetStaticFilter(DS.expensetotal, filteresercizio);

            GetData.SetStaticFilter(DS.account, filteresercizio);
            DataAccess.SetTableForReading(DS.monthname1, "monthname");
            DataAccess.SetTableForReading(DS.monthname2, "monthname");
            DataAccess.SetTableForReading(DS.income_linked, "income");
            GetData.CacheTable(DS.monthname1);
            GetData.CacheTable(DS.monthname2);

            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.BitSet("flag", 0)));
            GetData.CacheTable(DS.expensephase, null, "nphase", true);
            GetData.CacheTable(DS.incomephase, null, "nphase", false);
            GetData.CacheTable(DS.tax);
            GetData.CacheTable(DS.clawback);
            GetData.CacheTable(DS.chargehandling);

            GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2)), "description",
                true);
            GetData.CacheTable(DS.mandatekind, null, null, true);

            GetData.SetStaticFilter(DS.invoicedetail_iva, QHS.BitClear("flag", 2));
            GetData.SetStaticFilter(DS.invoicedetail_taxable, QHS.BitClear("flag", 2));



            DataTable kindVar = MyConn.readFromTable("invoicekind", q.bitSet("flag", 2), "idinvkind");

            GetData.SetStaticFilter(DS.invoicedetail_iva_nc, QHS.FieldIn("idinvkind",kindVar.Select()));
            GetData.SetStaticFilter(DS.invoicedetail_taxable_nc, QHS.FieldIn("idinvkind",kindVar.Select()));

            PostData.MarkAsTemporaryTable(DS.tipomovimento, false);

            fasedefault = 200;
            if ((Meta.ExtraParameter != null) && (Meta.ExtraParameter != DBNull.Value)
                                              && ((string) Meta.ExtraParameter != "")) {
                fasedefault = Convert.ToByte(CfgFn.GetNoNullInt32(Meta.ExtraParameter));
            }

            int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteresercvariazione = QHS.CmpEq("yvar", currEsercizio);
            GetData.SetStaticFilter(DS.expensevar, filteresercvariazione);

            string billfilter = QHS.AppAnd(QHS.CmpEq("billkind", 'D'), QHS.CmpEq("ybill", currEsercizio));
            object idflowchart = Meta.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
             	int flagtreasurer = flagUniconfig & 1; //CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "(isnull(flag,0)&1)"));
                if (flagtreasurer != 0)
                    billfilter = QHS.AppAnd(billfilter, QHS.IsNotNull("idtreasurer"));
            }

            GetData.SetStaticFilter(DS.bill, billfilter);
            GetData.SetStaticFilter(DS.billview, billfilter);
            GetData.SetStaticFilter(DS.bill1, billfilter);
            string filterstart = QHS.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
            string filterstop = QHS.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
            string filtermandatedetail_date = QHS.AppAnd(filterstart, filterstop);
            GetData.SetStaticFilter(DS.mandatedetail_iva, filtermandatedetail_date);
            GetData.SetStaticFilter(DS.mandatedetail_taxable, filtermandatedetail_date);

            GetData.LockRead(DS.registrypaymethod);
            GetData.DenyClear(DS.registrypaymethod);
            GetData.SetStaticFilter(DS.clawback_expense, QHS.CmpNe("flagf24ep", 'S'));

            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva);
            monofase = MyConn.RUN_SELECT_COUNT("expensephase", null, true)==1? true : false;
            
            int accountingMinYear = CfgFn.GetNoNullInt32(MyConn.DO_READ_VALUE("accountingyear", null, "MIN(ayear)"));
			if (accountingMinYear == currEsercizio) {
				isNumEserEdit = true;
			}
        }

        /// <summary>
        /// public void MetaData_AfterLink() Richiamato una volta sola
        /// Richiamata subito dopo che al form � stato collegato il MetaDato e rimossi i constraint
        /// dal DataSet. E� possibile far riferimento al MetaDato M tramite la funzione statica
        /// MetaData.GetMetaData(this). ove �this� � il Form. In questa fase � possibile:
        ///	stabilire la tabella da monitorare del Form, con M.SetTableToMonitor(�nome tabella da monitorare�);
        ///	stabilire quali tabelle sono da mettere in �cache�, ossia leggere una sola volta all�avvio
        ///	 del form, con M.SetTableToCache(�nome tabella�);
        ///	impostare un filtro statico non parametrico su una tabella con il metodo statico
        ///	 GetData.SetStaticFilter(�nome tabella�, �filtro�),
        ///	  ad esempio GetData.SetStaticFilter(�bilancio�,�(partebilancio=�E�)�)
        /// </summary>
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            AfterLinkBody();
            MetaData.messageBroadcaster += MetaData_messageBroadcaster;

        }

        void MetaData_messageBroadcaster(object sender, object e) {
            if (e.ToString() == "ForzaRecuperoSplitPayment") {
                GeneraOAzzeraRecuperoSplitPayment();
            }
        }


        /// <summary>
        /// Metodo che imposta a Read Only o in Read and Write il Form del dettaglio ritenute
        /// </summary>
        private void impostaFormRitenuteReadOnly() {
            if ((MissionLinked != null) || (CedolinoLinked != null) || (DipendenteLinked != null) ||
                (OccasionaleLinked != null) || (ProfessionaleLinked != null)) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            if ((Meta.IsEmpty) || (Meta.EditMode)) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedValue == null) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedIndex == 0) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            object cod = SubEntity_cmbTipoprestazione.SelectedValue;
            DataRow[] PREST = DS.service.Select("idser=" + QueryCreator.quotedstrvalue(cod, false));
            if (PREST.Length == 0) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            DataRow P = PREST[0];
            decimal II =
                CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text,
                    "x.y.c"));
            if (II == 0) {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (P["allowedit"].ToString().ToUpper() == "N") {
                DS.expensetax.ExtendedProperties["readonly"] = "S";
                return;
            }

            DS.expensetax.ExtendedProperties["readonly"] = "N";
        }

        /// <summary>
        /// Metodo che imposta a Read Only o in Read and Write il Form del dettaglio correzioni - storni
        /// </summary>
        private void impostaFormStorniReadOnly() {
            if ((Meta.IsEmpty) || (Meta.InsertMode)) {
                DS.expensetaxcorrige.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedValue == null) {
                DS.expensetaxcorrige.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedIndex == 0) {
                DS.expensetaxcorrige.ExtendedProperties["readonly"] = "S";
                return;
            }

            object cod = SubEntity_cmbTipoprestazione.SelectedValue;
            DataRow[] PREST = DS.service.Select(QHC.CmpEq("idser", cod));
            if (PREST.Length == 0) {
                DS.expensetaxcorrige.ExtendedProperties["readonly"] = "S";
                return;
            }

            DataRow P = PREST[0];
            decimal II =
                CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text,
                    "x.y.c"));
            if (II == 0) {
                DS.expensetaxcorrige.ExtendedProperties["readonly"] = "S";
                return;
            }

            DS.expensetaxcorrige.ExtendedProperties["readonly"] = "N";
        }

        /// <summary>
        /// Metodo che imposta a Read Only o in Read and Write il Form del dettaglio riepilogo storico
        /// </summary>
        private void impostaFormUfficialeReadOnly() {
            if ((Meta.IsEmpty) || (Meta.InsertMode)) {
                DS.expensetaxofficial.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedValue == null) {
                DS.expensetaxofficial.ExtendedProperties["readonly"] = "S";
                return;
            }

            if (SubEntity_cmbTipoprestazione.SelectedIndex == 0) {
                DS.expensetaxofficial.ExtendedProperties["readonly"] = "S";
                return;
            }

            object cod = SubEntity_cmbTipoprestazione.SelectedValue;
            DataRow[] PREST = DS.service.Select(QHC.CmpEq("idser", cod));
            if (PREST.Length == 0) {
                DS.expensetaxofficial.ExtendedProperties["readonly"] = "S";
                return;
            }

            DataRow P = PREST[0];
            decimal II =
                CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text,
                    "x.y.c"));
            if (II == 0) {
                DS.expensetaxofficial.ExtendedProperties["readonly"] = "S";
                return;
            }

            DS.expensetaxofficial.ExtendedProperties["readonly"] = "N";
        }

        /// <summary>
        /// Dice se � ammessa la modifica delle ritenute considerando il fatto che il movimento contabilizza
        /// una prestazione.
        /// </summary>
        /// <returns></returns>
        //bool ModificaRitenuteAbilitata() {
        //    if ((MissionLinked != null) || (CedolinoLinked != null) || (DipendenteLinked != null) ||
        //        (OccasionaleLinked != null) || (ProfessionaleLinked != null)) {
        //        return false;
        //    }
        //    if (Meta.IsEmpty) {
        //        return false;
        //    }
        //    //DataRow S= DS.spesa.Rows[0];
        //    //if (S["codiceprestazione"]==DBNull.Value) return true;
        //    //string cod= S["codiceprestazione"].ToString();
        //    if (SubEntity_cmbTipoprestazione.SelectedValue == null) {
        //        return false;
        //    }
        //    if (SubEntity_cmbTipoprestazione.SelectedIndex == 0) {
        //        return false;
        //    }
        //    object cod = SubEntity_cmbTipoprestazione.SelectedValue;
        //    DataRow[] PREST = DS.service.Select("idser=" + QueryCreator.quotedstrvalue(cod, false));
        //    if (PREST.Length == 0) {
        //        return true;
        //    }
        //    DataRow P = PREST[0];
        //    decimal II = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
        //    if (II == 0) {
        //        return true;
        //    }
        //    if (P["allowedit"].ToString().ToUpper() == "N") {
        //        return false;
        //    }
        //    return true;
        //}

        ///  Si occupa anche di azzerare i campi di spesa se la fase non li ammette

        #region Gestione del'abilitazione e disabilitazione dei controlli.

        /// <summary>
        /// gboxFasePrecedente
        /// txtEsercizioFasePrecedente
        /// txtNumeroFasePrecedente
        /// btnFasePrecedente
        /// </summary>
        void AddTab(TabPage Tab, bool redraw) {
            if (tabControl1.TabPages.Contains(Tab)) return;
            tabControl1.TabPages.Add(Tab);
            if (Meta.IsEmpty) {
                Meta.myHelpForm.ClearControls(Tab.Controls);
            }
            else {
                if (redraw) Meta.myHelpForm.FillControls(Tab.Controls);
            }
        }

        void AddRemoveTab(TabPage Tab, bool Add, bool redraw) {
            if (Add) {
                AddTab(Tab, redraw);
            }
            else {
                if (tabControl1.TabPages.Contains(Tab)) {
                    tabControl1.TabPages.Remove(Tab);
                }
            }
        }

        bool InsideAdRemoveTabs;

        void AddRemoveTabs(bool redraw) {
            InsideAdRemoveTabs = true;
            bool ultimafase = (faseMaxInclusa());
            bool faseordine = faseOrdineInclusa();
            bool faseiva = faseIvaInclusa();
            bool fasebilancio = faseBilancioInclusa();

            tabControl1.SuspendLayout();
            int currsel = tabControl1.SelectedIndex;
            int myphase = cmbFaseSpesa.SelectedIndex;
            AddRemoveTab(tabDetails, faseordine || faseiva, redraw);
            AddRemoveTab(tabFatture, faseiva, redraw);
            AddRemoveTab(tabPrest, ultimafase, redraw);
            AddRemoveTab(tabRecup, ultimafase, redraw);
            AddRemoveTab(tabPagam, ultimafase, redraw);
            AddRemoveTab(tabVariaz, Meta.EditMode | Meta.InsertMode, redraw);//AddRemoveTab(tabVariaz, Meta.EditMode, redraw);
            AddRemoveTab(tabFinanziamenti, fasebilancio || ultimafase, redraw);

            if (tabControl1.SelectedIndex != currsel) tabControl1.SelectedIndex = currsel;

            if (myphase != cmbFaseSpesa.SelectedIndex)
                cmbFaseSpesa.SelectedIndex = myphase;
            tabControl1.ResumeLayout();
            InsideAdRemoveTabs = false;
        }

        bool checkAbilitaDettaglioPagamenti() {
            tipocont currcont = ContabilizzazioneSelezionata();
            if ((!Meta.IsEmpty) & faseIvaInclusa() & fasespesamax > 1 & currcont == tipocont.cont_none) {
                DataRow MiddleRow;
                DataRow mand = GetDocRow("mandate", "expensemandate", faseordine, out MiddleRow);
                if (MiddleRow != null) {
                    var flag =
                        DS.mandatekind._Filter(q.eq("idmankind", MiddleRow["idmankind"])).FirstOrDefault()?[
                            "linktoinvoice"];
                    if (flag?.ToString().ToUpper() == "N") {
                        if (MiddleRow != null && MiddleRow["movkind"].ToString() != "2") {
                            MetaData.SetDefault(DS.expenselastmandatedetail, "idmankind", MiddleRow["idmankind"]);
                            MetaData.SetDefault(DS.expenselastmandatedetail, "yman", MiddleRow["yman"]);
                            MetaData.SetDefault(DS.expenselastmandatedetail, "nman", MiddleRow["nman"]);
                            return true;
                            }
                        }
                    }

                }
            // Per il monofase
            if ((!Meta.IsEmpty) & monofase & currcont == tipocont.cont_ordine) {
                DataRow MiddleRow;
                DataRow mand = GetDocRow("mandate", "expensemandate", faseordine, out MiddleRow);
                if (MiddleRow != null) {
                    var flag =
                        DS.mandatekind._Filter(q.eq("idmankind", MiddleRow["idmankind"])).FirstOrDefault()?[
                            "linktoinvoice"];
                    if (flag?.ToString().ToUpper() == "N") {
                        if (MiddleRow != null && MiddleRow["movkind"].ToString() != "2") {
                            MetaData.SetDefault(DS.expenselastmandatedetail, "idmankind", MiddleRow["idmankind"]);
                            MetaData.SetDefault(DS.expenselastmandatedetail, "yman", MiddleRow["yman"]);
                            MetaData.SetDefault(DS.expenselastmandatedetail, "nman", MiddleRow["nman"]);
                            return true;
                        }
                    }
                }

            }
            return false;
            }

        /// <summary>
        /// Imposta il testo di BtnFasePrecedente e abilita/disabilita i controlli in
        ///  base alla fase
        /// </summary>
        void ApplicaLogicaSuFase() {
            tipocont currcont = ContabilizzazioneSelezionata();
            //			if (Meta.IsEmpty)
            //				currphase = cmbFaseSpesa.SelectedIndex;	//0-indexed
            //			else {
            //				currphase = CfgFn.GetNoNullInt32(DS.spesa.Rows[0]["codicefase"]);
            //			}
            if (currphase > fasespesamax) currphase = Convert.ToByte(fasespesamax);

            if (currphase == 1 && currcont==tipocont.cont_none) {
	            gboxEntrata.Visible = true;
	            gboxEntrata.Enabled = Meta.InsertMode|Meta.IsEmpty;
            }
            else {
	            gboxEntrata.Visible = false;
            }

            if (currphase > 1 && cmbFaseSpesa.Items.Count >= currphase) {
                btnFasePrecedente.Text = ((DataRowView) cmbFaseSpesa.Items[currphase - 1])["description"].ToString();
                chbAzzeramento.Enabled = true;
            }
            else {
                chbAzzeramento.Enabled = false;
            }
           
            cmbFaseSpesa.Enabled = (!Meta.EditMode) && (fasedefault == 200);

            txtFormerYmov.ReadOnly = !Meta.IsEmpty;
            txtFormerNmov.ReadOnly = !Meta.IsEmpty;
            txtImportoCorrente.ReadOnly = !Meta.IsEmpty;
            txtImportoDisponibile.ReadOnly = !Meta.IsEmpty;

            //txtEsercizioMovimento.ReadOnly= Meta.EditMode;//eserc. disabilitato in edit
            if (Meta.InsertMode && currphase > 1) {
                txtEsercizioMovimento.Text =
                    DS.expense.Columns["ymov"].DefaultValue.ToString();
            }

            txtEsercizioMovimento.ReadOnly = ((Meta.EditMode) || (currphase > 1) || (!isNumEserEdit)) && !Meta.IsEmpty;

            txtNumeroMovimento.ReadOnly = !Meta.IsEmpty; //num.mov. abilitato solo in ricerca
            btnSituazioneMovimentoSpesa.Enabled = Meta.EditMode;
            btnGerarchia.Enabled = Meta.EditMode;

            btnInsertClass.Enabled = !Meta.IsEmpty;
            btnDelClass.Enabled = !Meta.IsEmpty;
            btnEditClass.Enabled = !Meta.IsEmpty;

            if (currphase <= 1) //la prima fase � la 1
                gboxFasePrecedente.Visible = false;
            else {
                gboxFasePrecedente.Visible = true;
                txtEsercizioFasePrecedente.ReadOnly = Meta.EditMode;
                txtNumeroFasePrecedente.ReadOnly = Meta.EditMode;
                btnFasePrecedente.Enabled = !Meta.EditMode;
            }

            if (faseIvaInclusa()) {
                gboxDettInvoice.Visible = true;
            }
            else {
                gboxDettInvoice.Visible = false;
            }

            if (faseOrdineInclusa()) {
                gboxDettmandate.Visible = true;
            }
            else {
                gboxDettmandate.Visible = false;
            }

            ManageBilAnnuale.AbilitaDisabilita(currphase);
            ManageUPB.AbilitaDisabilita(currphase);
            ManageCreditore.AbilitaDisabilita(currphase);
            if (ManageUPB.AttualmenteAttivo) {
                if (Meta.InsertMode && GetUpb() == DBNull.Value) {
                    DataRow DR = DS.expenseyear.Rows[0];
                    SetUPB(GetDefaultForUpb());
                    //DR["idupb"] = GetDefaultForUpb();
                    //DataRow UPB=DS.upb.Select(QHC.CmpEq("idupb",GetDefaultForUpb()))[0];
                    //HelpForm.SetComboBoxValue(SubEntity_comboUPB, GetDefaultForUpb());
                    //txtDescrUPB.Text=UPB["title"].ToString();
                }
            }


            GBoxVariazioni.Enabled = (Meta.EditMode|| Meta.InsertMode);

            bool ultimafase = (currphase == fasespesamax);

            chkElenchiEp.Visible = ultimafase;
            if (defaultListType == "ep" && !ultimafase) {
	            defaultListType = "default";
            }


            btnScrittureCollegate.Visible = ultimafase && Meta.EditMode && SubEntity_txtNumMandato.Text!="";

            if (!ultimafase && currphase > 0 && !Meta.IsEmpty) {
                SubEntity_chbCoperturaIniziativa.Checked = false;
                SubEntity_txtBolletta.Text = "";
                SubEntity_chkEsenteSpese.Checked = false;
            }
            gboxIncassoDettContratti.Visible = false;
            dettaglioContrattiPagati = false;

            if (checkAbilitaDettaglioPagamenti()) {
                gboxIncassoDettContratti.Visible = true;
                dettaglioContrattiPagati = true;
                if (monofase) {
                    //gboxIncassoDettContratti.Visible = false;
                    //dettaglioContrattiPagati = false;
                    doCollegamentoAutomatico();
                }
            }

            SubEntity_txtNumMandato.ReadOnly = !Meta.IsEmpty;

            //btnPrestazione.Enabled			=  ultimafase && (MissionLinked==null)&&(CedolinoLinked==null)&&(OccasionaleLinked==null)&&(ProfessionaleLinked==null)&&(DipendenteLinked==null);
            SubEntity_cmbTipoprestazione.Enabled = ultimafase && (MissionLinked == null) && (CedolinoLinked == null) &&
                                                   (OccasionaleLinked == null) && (ProfessionaleLinked == null) &&
                                                   (DipendenteLinked == null);
            SubEntity_txtDataInizioPrest.ReadOnly = !(ultimafase && (MissionLinked == null) &&
                                                      (CedolinoLinked == null) && (OccasionaleLinked == null) &&
                                                      (ProfessionaleLinked == null) && (DipendenteLinked == null));
            SubEntity_txtDataFinePrest.ReadOnly = !(ultimafase && (MissionLinked == null) && (CedolinoLinked == null) &&
                                                    (OccasionaleLinked == null) && (ProfessionaleLinked == null) &&
                                                    (DipendenteLinked == null));
            //btnCalcoloGuidato.Enabled		= ultimafase &&  ModificaRitenuteAbilitata() && (MissionLinked==null)&&(CedolinoLinked==null)&&(OccasionaleLinked==null)&&(ProfessionaleLinked==null)&&(DipendenteLinked==null) && (!Meta.IsEmpty);

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            btnInserisciRitenute.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaRitenuteAbilitata();
            // J.T.R L'and con ModificaRitenuteAbilitata � stato rimosso
            btnModificaRitenute.Enabled = ultimafase && (!Meta.IsEmpty); //&& ModificaRitenuteAbilitata();
            btnEliminaRitenute.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaRitenuteAbilitata();

            btnInserisciCorrezione.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaStorniAbilitata();
            btnModificaCorrezione.Enabled = ultimafase && (!Meta.IsEmpty);
            btnEliminaCorrezione.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaStorniAbilitata();

            btnInserisciUfficiale.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaStorniAbilitata();
            btnModificaUfficiale.Enabled = ultimafase && (!Meta.IsEmpty);
            btnEliminaUfficiale.Enabled = ultimafase && (!Meta.IsEmpty); // && ModificaStorniAbilitata();

            btnAddDetMandate.Enabled = (currcont == tipocont.cont_ordine) && (!Meta.IsEmpty) && faseOrdineInclusa();
            btnRemoveDetMandate.Enabled = (currcont == tipocont.cont_ordine) && (!Meta.IsEmpty) && faseOrdineInclusa();
            btnEditMandDet.Enabled = (currcont == tipocont.cont_ordine) && (!Meta.IsEmpty) && faseOrdineInclusa();

            btnAddDettInvoice.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
            btnRemoveDettInvoice.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
            btnEditInvDet.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";

            btnInserisciRecuperi.Enabled = ultimafase && (!Meta.IsEmpty);
            btnModificaRecuperi.Enabled = ultimafase && (!Meta.IsEmpty);
            btnEliminaRecuperi.Enabled = ultimafase && (!Meta.IsEmpty);
            txtImportoDisponibile.Visible = !ultimafase;
            lblImportoDisponibile.Visible = !ultimafase;
            btnAutomatismiPrestazione.Enabled = ultimafase && (Meta.EditMode);
            btnAutomatismiRecuperi.Enabled = ultimafase && (Meta.EditMode);
            SubEntity_chkAutomPrestazione.Enabled = ultimafase && (!Meta.IsEmpty);
            SubEntity_chkAutomRecuperi.Enabled = ultimafase && (!Meta.IsEmpty);
            SubEntity_chbCoperturaIniziativa.Enabled = ultimafase;
            SubEntity_chkEsenteSpese.Enabled = ultimafase;

            btnSelModalita.Enabled = ultimafase && (!Meta.IsEmpty);
            btnModEstinzione.Enabled = ultimafase && (!Meta.IsEmpty);
            SubEntity_cmbModPagamento.Enabled = false; //ultimafase && (!Meta.IsEmpty);
            SubEntity_cmbChargeHandling.Enabled = false;
            if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();

            SubEntity_txtCin.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtContoCorrente.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtIBAN.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtBanca.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtSportello.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtBiccode.ReadOnly = !(Meta.IsEmpty & ultimafase);
            SubEntity_txtExtraCode.ReadOnly = !(Meta.IsEmpty & ultimafase);
            grpContodebito.Visible = ultimafase;
            grpCertificatiNecessari.Visible = ultimafase;
            SubEntity_txtAvvisoPagoPa.Visible = ultimafase;
            lblAvvisoPagoPa.Visible = ultimafase;

            int ImpegnoGiuridico = CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase"));
            if (currphase == ImpegnoGiuridico) {
                lblcig.Visible = true;
                lblcup.Visible = true;
                txtcig.Visible = true;
                txtcup.Visible = true;
            }
            else {
                lblcig.Visible = false;
                lblcup.Visible = false;
                txtcig.Visible = false;
                txtcup.Visible = false;
            }

            gboxFinCompetenza.Visible =
                (!Meta.IsEmpty) && faseBilancioInclusa() && (UsaCrediti() || UsaPrevCompetenza());
            gboxFinCassa.Visible = (!Meta.IsEmpty) && ultimafase && (UsaCassa() || UsaPrevCassa());

            if (Meta.EditMode) {
                if (CfgFn.GetNoNullInt32(DS.expenseyear.Rows[0]["idfin", DataRowVersion.Original]) !=
                    CfgFn.GetNoNullInt32(DS.expenseyear.Rows[0]["idfin", DataRowVersion.Current])
                    ||
                    DS.expenseyear.Rows[0]["idupb", DataRowVersion.Original].ToString() !=
                    DS.expenseyear.Rows[0]["idupb", DataRowVersion.Current].ToString()
                ) {
                    gboxFinCompetenza.Enabled = false;
                }
                else {
                    gboxFinCompetenza.Enabled = true;
                }
            }
        }


        #endregion


        void GestisciNumBolletta() {
            MetaData.AutoInfo AI = Meta.GetAutoInfo(SubEntity_txtBolletta.Name);
            if (AI == null) {
                Meta.SetAutoMode(gboxBolletta);
                AI = Meta.GetAutoInfo(SubEntity_txtBolletta.Name);
            }

            if (Meta.IsEmpty) {
                if (AI != null) AI.startfilter = null; //Elimina il filtro su flagattivo
                btnBolletta.Enabled = true;
                SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
                btnAltreBollette.Visible = false;
                btnMultipleBillSel.Visible = false;
                GestisciBolletteMultiple();
                return;
            }

            if (DS.expenselast.Rows.Count == 0) {
                SubEntity_txtBolletta.ReadOnly = true;
                btnBolletta.Enabled = false;
                btnAltreBollette.Visible = false;
                btnMultipleBillSel.Visible = false;
                GestisciBolletteMultiple();
                return;
            }

            if (Meta.InsertMode) {
                btnAltreBollette.Visible = false;
                btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
                if (AI != null) AI.startfilter = "(active='S')";
                SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
                btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
                if (!SubEntity_chbCoperturaIniziativa.Checked) {
                    SubEntity_txtBolletta.Text = "";
                    DataRow CurrR = DS.expenselast.Rows[0];
                    CurrR["nbill"] = DBNull.Value;
                }

                GestisciBolletteMultiple();
                return;
            }

            if (AI != null) AI.startfilter = null;
            DataRow Curr = DS.expenselast.Rows[0];
            if (Curr["kpay"] == DBNull.Value) {
                SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
                btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
                btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
                if (!SubEntity_chbCoperturaIniziativa.Checked) {
                    SubEntity_txtBolletta.Text = "";
                    DataRow CurrR = DS.expenselast.Rows[0];
                    CurrR["nbill"] = DBNull.Value;
                }
            }
            else {
                // Mandato di pagamento e variazione modifica dati trasmessi
                // Vedo se esistono variazioni di modifica dati trasmessi, che sbloccano le modifiche
                int count = MyConn.RUN_SELECT_COUNT("expensevar", QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]),
                    QHS.CmpEq("autokind", 22),
                    QHS.IsNull("kpaymenttransmission")), true);
                if (count == 0) {
                    SubEntity_txtBolletta.ReadOnly = true;
                    btnBolletta.Enabled = false;
                    btnMultipleBillSel.Visible = false;
                }
                else {
                    SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
                    btnBolletta.Enabled = true;
                }
            }

            //if (Curr["nbill"] != DBNull.Value)
            //    btnAltreBollette.Visible = false;  //era true
            //else
            //    btnAltreBollette.Visible = false;

            GestisciBolletteMultiple();
        }

        void GestisciBolletteMultiple() {
            if (Meta.IsEmpty || DS.expenselast.Rows.Count == 0) {
                btnAddBolletta.Enabled = false;
                btnEditBolletta.Enabled = false;
                btnDelBolletta.Enabled = false;
                labBollette1.Visible = false;
                labBollette2.Visible = false;
                return;
            }

            btnAddBolletta.Enabled = true;
            btnEditBolletta.Enabled = true;
            btnDelBolletta.Enabled = true;
            labBollette1.Visible = true;
            labBollette2.Visible = true;
        }


        #region AfterClear

        public void MetaData_AfterClear() {
            if (MustClose) return;
            Meta.UnMarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            Meta.UnMarkTableAsNotEntityChild(DS.invoicedetail_taxable);
            Meta.UnMarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            Meta.UnMarkTableAsNotEntityChild(DS.invoicedetail_iva);
            grpCertificatiNecessari.Enabled = true;
            GestisciNumBolletta();
            DS.registrypaymethod.Clear();
            txtModPagamento.Text = "";

            CalcTotFinanziamenti();

            if (fasedefault > fasespesamax && fasedefault != 200) fasedefault = Convert.ToByte(fasespesamax);
            labelImporto.Text = "Importo originale";
            if (fasedefault != 200) {
                if ((cmbFaseSpesa.SelectedValue == null) ||
                    ((cmbFaseSpesa.SelectedValue != null) &&
                     (!cmbFaseSpesa.SelectedValue.Equals(fasedefault)))) {
                    HelpForm.SetComboBoxValue(cmbFaseSpesa, fasedefault);
                    CambiaFase();
                    //cmbFaseSpesa.SelectedValue= fasedefault;
                }

                DS.expense.Columns["nphase"].DefaultValue = fasedefault;
                cmbFaseSpesa.Enabled = false;
            }
            else {
                try {
                    cmbFaseSpesa.Enabled = true;
                    if (Meta.IsRealClear) {
                        //currphase=1;
                        cmbFaseSpesa.SelectedIndex = 1;
                        CambiaFase();
                    }
                    else {
                        //AddRemoveTabs(false);
                    }
                }
                catch {
                }

                ;
            }

            lastimportofreshed = Decimal.MinValue;

            if (cmbTipoContabilizzazione.SelectedIndex > 0) {
                cmbTipoContabilizzazione.SelectedIndex = 0;
            }

            ResetMissione();
            ResetOrdine();
            ResetIva();
            ResetCedolino();
            ResetOccasionale();
            ResetProfessionale();
            ResetDipendente();

            ResetTipoClassAvailableEvalued();

            ClearComboCausale();
            ControlloSuFasiPrecEffettuato = false;
            if (Meta.IsRealClear) ApplicaLogicaSuFase();

            //Ripulisco il filtro per la ricerca
            ClearStartFilter();


            GetData.UnCacheTable(DS.sortingkind);
            GetData.CanClear(DS.sortingkind);
            currphase = Convert.ToByte(cmbFaseSpesa.SelectedIndex >= 0 ? cmbFaseSpesa.SelectedIndex : 0); //0-indexed
            //fasespesamax = cmbFaseSpesa.Items.Count - 1;//first phase is a blank phase
            txtEsercizioFasePrecedente.Text = "";
            txtNumeroFasePrecedente.Text = "";
            chbAzzeramento.Checked = false;

            txtEsercizioMovimento.ReadOnly = false;
            txtNumeroMovimento.ReadOnly = false;
            SubEntity_txtImportoMovimento.ReadOnly = false;

            ClearPrestazioni();

            ClearGridsData();
            UnfilterPrestazione();

            string tagBtnBolletta = "choose.bill.spesa";
            btnBolletta.Tag = tagBtnBolletta;
            btnAggiornaCertificati.Enabled = false;
            txtTotaleSospesi.Text = "";
        }

        #endregion



        #region Gestione Pos. Giuridica



        void ClearComboPrestazione() {
            if (currphase != fasespesamax) return;
            ((DataTable) SubEntity_cmbTipoprestazione.DataSource).Clear();
        }

        void UnfilterPrestazione() {
            //Fill senza filtro della combo
            if (currphase != fasespesamax) return;
            string X = QueryCreator.GetFilterForInsert(DS.service);
            string Y = QueryCreator.GetFilterForSearch(DS.service);
            QueryCreator.SetInsertFilter(DS.service, null);
            PostData.MarkAsRealTable((DataTable) SubEntity_cmbTipoprestazione.DataSource);
            Meta.myHelpForm.PreFillControlsTable(SubEntity_cmbTipoprestazione, null);
            PostData.MarkAsTemporaryTable((DataTable) SubEntity_cmbTipoprestazione.DataSource, false);
            QueryCreator.SetInsertFilter(DS.service, X);
            QueryCreator.SetSearchFilter(DS.service, Y);
        }

        string LastFilterPosGiuridica;
        string LastFilterCDPosRuolo;

        void ClearPosGiuridica() {
            LastFilterPosGiuridica = "";
            LastFilterCDPosRuolo = "";
            ClearComboPrestazione();
        }

        object DataPerPosGiuridica() {
            if (Meta.IsEmpty) return DBNull.Value;
            if (DS.expenselast.Rows.Count == 0) return DBNull.Value;
            DataRow CurrLast = DS.expenselast.Rows[0];
            object datainizio = CurrLast["servicestart"];
            DataRow Curr = DS.expense.Rows[0];
            if (datainizio == DBNull.Value) datainizio = Curr["adate"];
            return datainizio;
        }


        void DetectPosGiuridica() {
            if (Meta.IsEmpty) return;
            if (currphase != fasespesamax) return;
            //DataRow Curr = DS.expense.Rows[0];
            //DataRow CurrLast = DS.expenselast.Rows[0];
            //object datainizio = DataPerPosGiuridica();
            //object codicecreddeb = Curr["idreg"];

            //if ((datainizio ==DBNull.Value)||(((DateTime)datainizio) ==QueryCreator.EmptyDate())) {
            //    ClearPosGiuridica();
            //    return;
            //}			
            //if ((codicecreddeb==DBNull.Value)||(((int)codicecreddeb)<=0)){
            //    ClearPosGiuridica();
            //    return;
            //}
            //string strdate=QueryCreator.quotedstrvalue((DateTime)datainizio,true);

            //string filter = "(idreg = "+QueryCreator.quotedstrvalue(codicecreddeb,true)+") AND "+
            //    "(start <= "+	QueryCreator.quotedstrvalue(datainizio,true)+")";

            //string filtercdposruolo;

            //object datafine = CurrLast["servicestop"];
            //if (datafine!=DBNull.Value){
            //    string strdatafineprest =QueryCreator.quotedstrvalue((DateTime)datafine,true);
            //    filtercdposruolo=
            //        "(idreg = "+QueryCreator.quotedstrvalue(codicecreddeb,true)+") AND "+
            //        "(start<="+strdate+")"+
            //        "and ((stop is null) or (stop>="+strdatafineprest+"))"+
            //        "and (active<>'N')";
            //}
            //else 
            //    filtercdposruolo=
            //        "(idreg = "+QueryCreator.quotedstrvalue(codicecreddeb,true)+") AND "+
            //        "(start<="+strdate+")"+
            //        "and ((stop is null) or (stop>="+strdate+"))"+
            //        "and (active<>'N')";

            if (Meta.InsertMode) {
                FiltraComboPrestazione(false);
            }

            if (Meta.EditMode) {
                FiltraComboPrestazione(true);
            }

            return;
        }

        private void ImpostaPosGiuridica(bool MustAsk) {
            if (Meta.IsEmpty) return;
            if (currphase != fasespesamax) return;
            DataRow Curr = DS.expense.Rows[0];
            DataRow CurrLast = DS.expenselast.Rows[0];
            object datainizio = DataPerPosGiuridica();
            object codicecreddeb = Curr["idreg"];
            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                ClearPosGiuridica();
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                ClearPosGiuridica();
                return;
            }

            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);

            string filter = "(idreg = " + QueryCreator.quotedstrvalue(codicecreddeb, true) + ") AND " +
                            "(start <= " + QueryCreator.quotedstrvalue(datainizio, true) + ")";

            string filtercdposruolo;
            object datafine = CurrLast["servicestop"];
            if (datafine != DBNull.Value) {
                string strdatafineprest = QueryCreator.quotedstrvalue((DateTime) datafine, true);
                filtercdposruolo =
                    "(idreg = " + QueryCreator.quotedstrvalue(codicecreddeb, true) + ") AND " +
                    "(start<=" + strdate + ")" +
                    "and ((stop is null) or (stop>=" + strdatafineprest + "))" +
                    "and (active<>'N')";
            }
            else
                filtercdposruolo =
                    "(idreg = " + QueryCreator.quotedstrvalue(codicecreddeb, true) + ") AND " +
                    "(start<=" + strdate + ")" +
                    "and ((stop is null) or (stop>=" + strdate + "))" +
                    "and (active<>'N')";

            if ((LastFilterCDPosRuolo == filtercdposruolo) && (!MustAsk)) return;
            LastFilterCDPosRuolo = filtercdposruolo;
            if (Meta.InsertMode)
                FiltraComboPrestazione(false);
            else if (Meta.EditMode)
                FiltraComboPrestazione(true);

            LastFilterPosGiuridica = filter;
            //FiltraComboPrestazioneInBaseARapporto(SelClass.Rows[0]["idwor"].ToString(),false);

        }


        void FiltraComboPrestazione(bool enableold) {
            // Criteri di filtro:
            // 1) Prestazioni su cui � abilitata l'immissione manuale delle ritenute, in modalit� di INSERIMENTO e MODIFICA
            // 2) pi� la prestazione eventualmente gi� selezionata, solo se in modalit� di MODIFICA
            string filtertipoprestazione;
            object oldcode = DBNull.Value;
            string allowedit = "S";
            if (SubEntity_cmbTipoprestazione.SelectedValue != null)
                oldcode = SubEntity_cmbTipoprestazione.SelectedValue;
            if ((oldcode == null) || (oldcode.ToString() == "")) enableold = false;
            filtertipoprestazione = QHS.CmpEq("allowedit", allowedit);

            if (enableold)
                filtertipoprestazione = QHS.DoPar(QHS.AppOr(filtertipoprestazione, QHS.CmpEq("idser", oldcode)));
            //"("+filtertipoprestazione+"OR(idser="+
            //QueryCreator.quotedstrvalue(oldcode,true)+"))";


            //Imposta combo prestazione filtrata
            Meta.myHelpForm.DisableAutoEvents();
            SubEntity_cmbTipoprestazione.BeginUpdate();
            QueryCreator.MyClear(((DataTable) SubEntity_cmbTipoprestazione.DataSource));
            GetData.Add_Blank_Row(((DataTable) SubEntity_cmbTipoprestazione.DataSource));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, ((DataTable) SubEntity_cmbTipoprestazione.DataSource),
                "description",
                filtertipoprestazione, null, true);
            HelpForm.SetComboBoxValue(SubEntity_cmbTipoprestazione, oldcode);
            SubEntity_cmbTipoprestazione.EndUpdate();
            Meta.myHelpForm.EnableAutoEvents();
        }

        private void GeneraSelect(object sender) {

            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            if (SubEntity_cmbTipoprestazione.Enabled == false) return;
            //			DataRow CurrMiss = DS.missione.Rows[0];
            //			int codicecreddeb = (int) CurrMiss["codicecreddeb"];
            //			string codiceprestazione = CurrMiss["codiceprestazione"].ToString();
            //			DateTime dataprestaz = (DateTime) CurrMiss["datainizio"];
            //			DateTime datacont  =  (DateTime) CurrMiss["datacontabile"];

            if (((Control) sender) == txtCredDeb) {
                ImpostaPosGiuridica(false);
            }

            if (((Control) sender) == SubEntity_txtDataInizioPrest) {
                ImpostaPosGiuridica(false);
            }

            if (((Control) sender) == SubEntity_txtDataFinePrest) {
                ImpostaPosGiuridica(false);
            }

            if (((Control) sender) == txtDataCont) {
                ImpostaPosGiuridica(false);
            }

        }

        private void txtIncaricato_LostFocus(object sender, System.EventArgs e) {
            GeneraSelect(sender);
        }

        private void txtDataInizio_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (SubEntity_txtDataInizioPrest.Text != "") {
                //forza l'immissione di una data valida
                DateTime datainizio;
                try {
                    datainizio = Convert.ToDateTime(SubEntity_txtDataInizioPrest.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    SubEntity_txtDataInizioPrest.SelectAll();
                    SubEntity_txtDataInizioPrest.Focus();
                    return;
                }

            }

            GeneraSelect(sender);
        }

        private void txtDataFinePrest_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (SubEntity_txtDataFinePrest.Text != "") {
                //forza l'immissione di una data valida
                DateTime datainizio;
                try {
                    datainizio = Convert.ToDateTime(SubEntity_txtDataFinePrest.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    SubEntity_txtDataFinePrest.SelectAll();
                    SubEntity_txtDataFinePrest.Focus();
                    return;
                }

            }

            GeneraSelect(sender);
        }

        private void txtDataContabile_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtDataCont.Text != "") {
                //forza l'immissione di una data valida
                DateTime datacontabile;
                try {
                    datacontabile = Convert.ToDateTime(txtDataCont.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    txtDataCont.SelectAll();
                    txtDataCont.Focus();
                    return;
                }

            }

            GeneraSelect(sender);
        }

        void InitPosGiuridicaSystem() {
            SubEntity_txtDataInizioPrest.LostFocus += new System.EventHandler(txtDataInizio_LostFocus);
            txtDataCont.LostFocus += new System.EventHandler(txtDataContabile_LostFocus);
            SubEntity_txtDataFinePrest.LostFocus += new System.EventHandler(txtDataFinePrest_LostFocus);

        }

        #endregion

        #region Gestione totale finanziamenti

        void CalcTotFinanziamenti() {
            if (Meta.IsEmpty) {
                txtTotFinanziatoCrediti.Text = "";
                txtTotFinanziatoCassa.Text = "";
                return;
            }

            decimal tot = MetaData.SumColumn(DS.underwritingappropriation, "amount");
            txtTotFinanziatoCrediti.Text = tot.ToString("c");
            tot = MetaData.SumColumn(DS.underwritingpayment, "amount");
            txtTotFinanziatoCassa.Text = tot.ToString("c");
        }

        #endregion

        #region BeforeActivation/AfterActivation

        public void MetaData_AfterActivation() {
            btnInsertClass.BackColor = formcolors.GridButtonBackColor();
            btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
            btnEditClass.BackColor = formcolors.GridButtonBackColor();
            btnEditClass.ForeColor = formcolors.GridButtonForeColor();
            btnDelClass.BackColor = formcolors.GridButtonBackColor();
            btnDelClass.ForeColor = formcolors.GridButtonForeColor();

            MetaData MetaMandDet = MetaData.GetMetaData(this, "mandatedetailview");
            MetaMandDet.DescribeColumns(DS.mandatedetail_taxable, "listaimpon");
            MetaMandDet.DescribeColumns(DS.mandatedetail_iva, "listaimpos");

            MetaData MetaInvDet = MetaData.GetMetaData(this, "invoicedetailview");
            MetaInvDet.DescribeColumns(DS.invoicedetail_taxable, "listaimpon");
            MetaInvDet.DescribeColumns(DS.invoicedetail_iva, "listaimpos");


            bool FlagEsenteBanca = LeggiFlagEsenteBancaPredefinita();
            SubEntity_chkEsenteSpese.Visible = FlagEsenteBanca;
        }


        public void MetaData_BeforeActivation() {
            if (MustClose) return;
            fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));

            if ((fasespesamax == 0) || (faseentratamax == 0) || DS.config.Rows.Count == 0) {
                show("Non � presente la configurazione delle entrate o delle spese");
                MustClose = true;
                fasedefault = 200;
                return;
            }

            if (fasedefault > fasespesamax && fasedefault != 200) fasedefault = Convert.ToByte(fasespesamax);
            DS.Tables["expense"].ExtendedProperties["fasespesamax"] = fasespesamax;


            MyConn = MetaData.GetConnection(this);
            string filteresercizio = "(ayear='" + Meta.GetSys("esercizio").ToString() + "')";

            ManageBilAnnuale = new GBoxManage(Meta,
                gboxBilAnnuale,
                new Control[] {txtCodiceBilancio, txtDenominazioneBilancio},
                new Control[] {txtCodiceBilancio, btnBilancio},
                new string[] {"idfin"},
                CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase")),
                "fin", filteresercizio);


            ManageUPB = new GBoxManage(Meta,
                gboxUPB,
                new Control[] {txtUPB, txtDescrUPB},
                new Control[] {txtUPB, btnUPBCode},
                new string[] {"idupb"},
                CfgFn.GetNoNullInt32(Meta.GetSys("expensefinphase")),
                "upb", null);

            ManageCreditore = new GBoxManage(Meta,
                groupCredDeb,
                new Control[] {txtCredDeb},
                //,cmbTipoEstinzione,cmbModPagamento,
                //		txtBanca, txtSportello, txtContoCorrente, txtCin,
                //		txtDescrModPagamento},
                new Control[] {txtCredDeb},
                new string[] {"idreg"},
                //"tipomodalita","codicemodalita",
                //"cin","codicebanca","codicesportello","numeroconto",
                //"descpagamento"}, 
                CfgFn.GetNoNullInt32(Meta.GetSys("expenseregphase")),
                "registry", null);

            //			bool RegEuro = (Convert.ToInt16(Meta.GetSys("esercizio").ToString()) <= 2001);
            //			ckbRegolamentoEuro.Visible = RegEuro;

            ManageClassificazioni = new GestioneClassificazioni(Meta,
                DGridClassificazioni, DGridDettagliClassificazioni,
                ManageBilAnnuale, ManageUPB, ManageCreditore,
                btnEditClass, btnInsertClass, btnDelClass);

            if (fasedefault != 200) {
                DataRow CurrFase = DS.expensephase.Select(QHC.CmpEq("nphase", fasedefault))[0];
                Meta.Name = CurrFase["description"].ToString();
            }

            ;


            DataRow PersSpesa = DS.Tables["config"].Rows[0];
            flagcreddeb = CfgFn.DecodeToString(PersSpesa["payment_flag"], 4);
            flagbilancio = CfgFn.DecodeToString(PersSpesa["payment_flag"], 2);
            flagrespons = CfgFn.DecodeToString(PersSpesa["payment_flag"], 16);
            flagresidui = CfgFn.DecodeToString(PersSpesa["payment_flag"], 8);
            fasemissione = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);
            fasecedolino = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);
            faseordine = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);
            faseoccasionale = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);
            faseprofessionale = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);
            fasedipendente = CfgFn.GetNoNullInt32(PersSpesa["expensephase"]);

            faseiva = 99;
            faseiva = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));


            int lenmax = fasespesamax * 8;
            QueryCreator.SetRelationActivationFilter(DS.Relations["expenseexpenseclawback"],
                QHC.CmpEq("nphase", fasespesamax));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpensetax"],
                QHC.CmpEq("nphase", fasespesamax));

            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpensemandate"],
                QHC.CmpEq("nphase", faseordine));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expensemandatedetail_taxable"],
                QHC.CmpEq("nphase", faseordine));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expensemandatedetail_taxable1"],
                QHC.CmpEq("nphase", faseordine));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expensemandatedetail_iva"],
                QHC.CmpEq("nphase", faseordine));



            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpenseitineration"],
                QHC.CmpEq("nphase", fasemissione));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpensepayroll"],
                QHC.CmpEq("nphase", fasecedolino));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpenseinvoice"],
                QHC.CmpEq("nphase", faseiva));


            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseinvoicedetail_iva"],
                QHC.CmpEq("nphase", faseiva));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseinvoicedetail_taxable"],
                QHC.CmpEq("nphase", faseiva));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseinvoicedetail_taxable1"],
                QHC.CmpEq("nphase", faseiva));

            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpensecasualcontract"],
                QHC.CmpEq("nphase", faseoccasionale));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpenseprofservice"],
                QHC.CmpEq("nphase", faseprofessionale));
            QueryCreator.SetRelationActivationFilter(
                DS.Relations["expenseexpensewageaddition"],
                QHC.CmpEq("nphase", fasedipendente));
        }

        #endregion


        #region Gestione Totali recuperi

        void CalcolaTotaliSuGrids() {
            decimal sum = MetaData.SumColumn(DS.expenseclawback, "amount");
            txtRecuperiTotale.Text = sum.ToString("c");
            //CfgFn.AssignNotEquals(DS.expense.Rows[0],"clawbackamount",sum);
            CalcTotInvoiceDetail();
            CalcTotMandateDetail();
            CalcTotMandatePagamenti();
            }

        /// <summary>
        /// Cancella i totali dei grid recuperi
        /// </summary>
        void ClearGridsData() {
            txtRecuperiTotale.Text = "";
            txtTotDettPagamenti.Text = "";
            }


        void CalcTotMandateDetail() {
            txtTotMandateDetail.Text = "";
            if (Meta.IsEmpty) return;
            decimal totale = GetImportoDettagliOrdine();
            txtTotMandateDetail.Text = totale.ToString("c");
        }

        void CalcTotInvoiceDetail() {
            txtTotInvoiceDetail.Text = "";
            if (Meta.IsEmpty) return;
            decimal totale = GetImportoDettagliFattura();
            txtTotInvoiceDetail.Text = totale.ToString("c");
        }


        #endregion

        #region BeforeFill/AfterFill

        void ImpostaFiltroBilancio() {
            if (DS.expenseyear.Rows.Count == 0) return;
            object idupb = DS.expenseyear.Rows[0]["idupb"];
            MetaData.AutoInfo AI;
            AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
            string filter = "(idupb='" + idupb + "')";
            if (AI != null) AI.startfilter = filter;
            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
        }

        decimal GetImportoDettagliContrattoPagati() {
            if (DS.expenselastmandatedetail.Rows.Count == 0) return 0;
            decimal imponibile = 0;

            foreach (DataRow R in DS.expenselastmandatedetail.Select()) {
                imponibile += CfgFn.GetNoNullDecimal(R["amount"]);
                }

            return imponibile;

            }

        void ReCalcImporto_Pagamenti() {
            if (DS.expenselastmandatedetail.Select().Length > 0) {
                decimal totPagato = GetImportoDettagliContrattoPagati();
                SetImporto(totPagato);
                SubEntity_txtImportoMovimento.Text = totPagato.ToString("c");
                }
            }

        public void MetaData_BeforeFill() {
            if (MustClose) return;
            if (!Meta.IsEmpty) {
                currphase = Convert.ToByte(CfgFn.GetNoNullInt32(DS.expense.Rows[0]["nphase"]));
            }
            else {
                currphase = Convert.ToByte(cmbFaseSpesa.SelectedIndex);
            }

            AddRemoveTabs(false);

            ImpostaFiltroBilancio();

            if (MustRefreshImportoSpesa) {
                MustRefreshImportoSpesa = false;
                object idspesa = DS.expense.Rows[0]["idexp"];
                DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.expensetotal, null,
                    "(idexp=" + QueryCreator.quotedstrvalue(idspesa, true) + ")AND" +
                    "(ayear='" + Meta.GetSys("esercizio").ToString() + "')",
                    null, true);
                //				MyConn.RUN_SELECT_INTO_TABLE(DS.variazionespesa,null,
                //					"(idspesa="+QueryCreator.quotedstrvalue(idspesa,true)+")",null,true);
            }

            RicalcolaImportoCorrente();
            foreach (DataRow r in DS.expenselastmandatedetail.Select()) {
                DS.mandatedetail_pagamenti.safeMergeFromDb(MyConn, q.mCmp(r, "idmankind", "yman", "nman", "rownum"));
                Meta.getData.CalcTemporaryValues(r);
                }
            //ReCalcImporto_Pagamenti();
            if (ContabilizzazioneSelezionata() != tipocont.cont_none || currphase != 1) {
                DS.expense.Rows[0]["idinc_linked"] = DBNull.Value;
                DS.income_linked.Clear();
                }

            ManageClassificazioni.CalcolaTotaliClassificazioni();

            //Controlla che vi sia o Crea una nuova riga nel DataTable "imputazionespesa"
            //con valori di default.
            if (!MetaData.Empty(this) && (Meta.FormState == MetaData.form_states.insert)) {
                CreateImputazioneSpesaRow();

            }

            if (Meta.InsertMode) {
                DS.expensetotal.Clear(); //risolve il problema dell'inserisci copia
            }

            //E� disabilitato nel caso in cui  
            //esiste un ID spesa con esercizio = eserciziosessione-1 in imputazionespesa
            if (Meta.EditMode && !ControlloSuFasiPrecEffettuato) {
                SubEntity_txtImportoMovimento.ReadOnly = EsisteEsercPrecedente();
                if (EsisteEsercPrecedente()) {
                    labelImporto.Text = "Importo all' 1/1";
                }
                else {
                    labelImporto.Text = "Importo Originale";
                }

                Meta.CanCancel = !EsisteEsercPrecedente();
                ControlloSuFasiPrecEffettuato = true;
            }

            if (Meta.InsertMode) {
                labelImporto.Text = "Importo Originale";
            }

            if (Meta.InsertMode) Meta.CanCancel = true;

            if (ContabilizzazioneSelezionata() != tipocont.cont_none || currphase != 1) {
	            DS.expense.Rows[0]["idinc_linked"] = DBNull.Value;
                DS.income_linked.Clear();
            }

            //if (DS.expensevar.ExtendedProperties["filter_nc"] != null) {
            //    string filter_nc = DS.expensevar.ExtendedProperties["filter_nc"].ToString();
            //    int CausaleContabilizzazione = CfgFn.GetNoNullInt32(DS.expensevar.ExtendedProperties["CausaleContabilizzazione"]);

            //    CollegaTuttiDettagliFattura_NC(filter_nc, CausaleContabilizzazione);
            //    DS.expensevar.ExtendedProperties["filter_nc"] = null;
            //    DS.expensevar.ExtendedProperties["CausaleContabilizzazione"] = null;
            //}
        }

        //void CollegaTuttiDettagliFattura_NC(string filter, int CurrCausaleIva) {
        //    return;
        //    DS.invoicedetail_iva_nc.Clear();//da rivedere
        //    DS.invoicedetail_taxable_nc.Clear();//da rivedere
        //    object idexp = DS.expensevar.Rows[0]["idexp"];
        //    if (idexp == DBNull.Value) return;
        //    if (CurrCausaleIva == 0) return;

        //    if (CurrCausaleIva == 1) {
        //        Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable_nc, null, filter, null, true);
        //        foreach (DataRow R in DS.invoicedetail_taxable_nc.Rows) {
        //            R["idexp_taxable"] = idexp;
        //            R["idexp_iva"] = idexp;
        //        }
        //        GetData.CalculateTable(DS.invoicedetail_taxable_nc);
        //        Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
        //    }
        //    if (CurrCausaleIva == 3) {
        //        Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable_nc, null, filter, null, true);
        //        foreach (DataRow R in DS.invoicedetail_taxable_nc.Rows) {
        //            R["idexp_taxable"] = idexp;
        //        }
        //        GetData.CalculateTable(DS.invoicedetail_taxable_nc);
        //        Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
        //    }
        //    if (CurrCausaleIva == 2) {
        //        Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva_nc, null, filter, null, true);
        //        foreach (DataRow R in DS.invoicedetail_iva_nc.Rows) {
        //            R["idexp_iva"] = idexp;
        //        }
        //        GetData.CalculateTable(DS.invoicedetail_iva_nc);
        //        Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
        //    }

        //}

        bool RisultatoRicercaEsercizio = false;

        bool EsisteEsercPrecedente() {
            if (!Meta.EditMode) return false;
            if (ControlloSuFasiPrecEffettuato) return RisultatoRicercaEsercizio;
            //object idspesa = DS.Tables["expense"].Rows[0]["idexp"];
            //int esercizioprec = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
            //string Myfilter = "(idexp='" + idspesa + "') AND "
            //    + "(ayear='" + esercizioprec + "')";
            //int count = MyConn.RUN_SELECT_COUNT("expenseyear", Myfilter, true);
            //RisultatoRicercaEsercizio = (count > 0);
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if (Curr["ymov"].ToString() == MyConn.GetEsercizio().ToString()) {
                RisultatoRicercaEsercizio = false;
            }
            else {
                RisultatoRicercaEsercizio = true;
            }

            return RisultatoRicercaEsercizio;
        }

        public void MetaData_AfterFill() {
            if (MustClose) {
                Meta.CanSave = false;
                Meta.SearchEnabled = false;
                Meta.CanInsert = false;
                //Meta.MainRefreshEnabled=false;
                Meta.FreshToolBar();
                tabControl1.Enabled = false;

                return;
            }
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva);

            //Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable_nc);
            //Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva_nc);
            grpCertificatiNecessari.Enabled = false;
            CalcTotFinanziamenti();
            GestisciNumBolletta();



            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                DS.expensesorted.ExtendedProperties["CustomParentRelation"] = f;
            }

            //int handle = metaprofiler.StartTimer("SPESA fase 1");
            PostData.MarkAsTemporaryTable((DataTable) SubEntity_cmbTipoprestazione.DataSource, false);
            if (Meta.FirstFillForThisRow) {
                DetectPosGiuridica();
            }

            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 2");
            if (SubEntity_chbCoperturaIniziativa.ThreeState == true)
                SubEntity_chbCoperturaIniziativa.ThreeState = false;
            if (SubEntity_chkEsenteSpese.ThreeState == true) SubEntity_chkEsenteSpese.ThreeState = false;

            if ((CedolinoLinkedMustBeEvalued == false) && (CedolinoLinked != null) &&
                (CedolinoLinked.RowState == DataRowState.Detached)) {
                if (DS.payroll.Rows.Count > 0) {
                    CedolinoLinked = DS.payroll.Rows[0];
                    CedolinoMovSpesaLinked = DS.expensepayroll.Rows[0];
                }
                else
                    ResetCedolino();
            }

            if ((MissionLinkedMustBeEvalued == false) && (MissionLinked != null) &&
                (MissionLinked.RowState == DataRowState.Detached)) {
                if (DS.itineration.Rows.Count > 0) {
                    MissionLinked = DS.itineration.Rows[0];
                    MissioneMovSpesaLinked = DS.expenseitineration.Rows[0];
                }
                else
                    ResetMissione();
            }

            if ((OrdineLinkedMustBeEvalued == false) && (OrdineLinked != null) &&
                (OrdineLinked.RowState == DataRowState.Detached)) {
                if (DS.mandate.Rows.Count > 0) {
                    OrdineLinked = DS.mandate.Rows[0];
                    OrdineGenericoMovSpesaLinked = DS.expensemandate.Rows[0];
                }
                else
                    ResetOrdine();
            }

            if ((OccasionaleLinkedMustBeEvalued == false) && (OccasionaleLinked != null) &&
                (OccasionaleLinked.RowState == DataRowState.Detached)) {
                if (DS.casualcontract.Rows.Count > 0) {
                    OccasionaleLinked = DS.casualcontract.Rows[0];
                    OccasionaleMovSpesaLinked = DS.expensecasualcontract.Rows[0];
                }
                else
                    ResetOccasionale();
            }

            if ((ProfessionaleLinkedMustBeEvalued == false) && (ProfessionaleLinked != null) &&
                (ProfessionaleLinked.RowState == DataRowState.Detached)) {
                if (DS.profservice.Rows.Count > 0) {
                    ProfessionaleLinked = DS.profservice.Rows[0];
                    ProfessionaleMovSpesaLinked = DS.expenseprofservice.Rows[0];
                }
                else
                    ResetProfessionale();
            }

            if ((DipendenteLinkedMustBeEvalued == false) && (DipendenteLinked != null) &&
                (DipendenteLinked.RowState == DataRowState.Detached)) {
                if (DS.wageaddition.Rows.Count > 0) {
                    DipendenteLinked = DS.wageaddition.Rows[0];
                    DipendenteMovSpesaLinked = DS.expensewageaddition.Rows[0];
                }
                else
                    ResetDipendente();
            }

            if (DS.invoicedetail_taxable_nc.Rows.Count > 0 || DS.invoicedetail_iva_nc.Rows.Count > 0) {
                GeneraOAzzeraRecuperoSplitPayment();
            }

            if ((IvaLinkedMustBeEvalued == false) && (IvaLinked != null) &&
                (IvaLinked.RowState == DataRowState.Detached)) {
                if (DS.invoice.Rows.Count > 0) {
                    IvaLinked = DS.invoice.Rows[0];
                    IvaMovSpesaLinked = DS.expenseinvoice.Rows[0];
                }
                else
                    ResetIva();
            }
            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 3");

            if (to_mainrefresh) {
                to_mainrefresh = false;
            }

            //Se presente un creditore debitore, riempie il combobox delle mod. pagamento
            if (DS.registry.Rows.Count > 0) {
                SetComboCreditoreDebitore();
            }

            bool CedolinoWasToLink = CedolinoLinkedMustBeEvalued;
            RintracciaCedolino();
            if (CedolinoWasToLink) {
                if (CedolinoLinked != null) {
                    CollegaCedolino(CedolinoLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }

            bool MissionWasToLink = MissionLinkedMustBeEvalued;
            RintracciaMissione();
            if (MissionWasToLink) {
                if (MissionLinked != null) {
                    CollegaMissione(MissionLinked);
                    lastimportofreshed = decimal.MinValue;
                    //Implicitely done through UpdateImportoDependencies:
                    //if (faseMaxInclusa()) RicalcolaPrestazioneMissione();
                }
            }

            bool OrdineWasToLink = OrdineLinkedMustBeEvalued;
            RintracciaOrdine();
            if (OrdineWasToLink) {
                if (OrdineLinked != null) {
                    VisualizzaMainInfo_Ordine(OrdineLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }

            bool IvaWasToLink = IvaLinkedMustBeEvalued;
            RintracciaIva();
            if (IvaWasToLink) {
                if (IvaLinked != null) {
                    VisualizzaMainInfo_Iva(IvaLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }

            bool OccasionaleWasToLink = OccasionaleLinkedMustBeEvalued;
            RintracciaOccasionale();
            if (OccasionaleWasToLink) {
                if (OccasionaleLinked != null) {
                    CollegaOccasionale(OccasionaleLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }

            bool ProfessionaleWasToLink = ProfessionaleLinkedMustBeEvalued;
            RintracciaProfessionale();
            if (ProfessionaleWasToLink) {
                if (ProfessionaleLinked != null) {
                    CollegaProfessionale(ProfessionaleLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }


            bool DipendenteWasToLink = DipendenteLinkedMustBeEvalued;
            RintracciaDipendente();
            if (DipendenteWasToLink) {
                if (DipendenteLinked != null) {
                    CollegaDipendente(DipendenteLinked);
                    lastimportofreshed = decimal.MinValue;
                }
            }

            popolaUfficiale();

            AzzeraDatiSuFasiNonSelezionate();
            cmbFaseSpesa.Enabled = false;
            txtEsercizioMovimento.ReadOnly = true;
            txtNumeroMovimento.ReadOnly = true;
            ApplicaLogicaSuFase();

            AbilitaDisabilitaControlliContabilizzazione(!Meta.EditMode &&
                                                        ((ContabilizzazioneSelezionata() != tipocont.cont_iva) ||
                                                         (ProfessionaleLinked == null)));

            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 5");

            if (Meta.EditMode) {
                DeduciContabilizzazione();
            }

            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 6");

            if (fasedefault != 200) {
                cmbFaseSpesa.Enabled = false;
            }


            if ((!Meta.IsEmpty) && (lastimportofreshed != GetImporto())) {
                lastimportofreshed = GetImporto();
                UpdateImportoDependencies();
            }
            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 6a");

            //if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();
            if (!Meta.IsEmpty) GestioneFasePerDocumentoCollegato();
            if (Meta.EditMode) UpdateComboCausale();

            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 6b");


            CalcolaTotaliSuGrids();
            CalcolaTotaleSospesi();
            if (DS.Tables["expenselast"].Rows.Count > 0) {
                DataRow CurrLast = DS.Tables["expenselast"].Rows[0];
                if (CurrLast["idser"] == DBNull.Value) {
                    ShowHidePrestazioniAggiuntive(false);
                }
                else {
                    if (!faseMaxInclusa()) {
                        ShowHidePrestazioniAggiuntive(false);
                    }
                    else {
                        DataRow R = CurrLast.GetParentRow("service_expenselast");
                        if (R != null)
                            VisualizzaPrestazioniAggiuntive(R);
                        else
                            ShowHidePrestazioniAggiuntive(false);
                    }
                }
            }
            else {
                ShowHidePrestazioniAggiuntive(false);
            }

            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 6c");
            ////task n. 16413 
            //ImpostaBilancioperMonofase();
            if (!(Meta.IsEmpty) && Meta.InsertMode && monofase) {
                chkFilterAvailable.Checked = false;
            }
            else {
                chkFilterAvailable.Checked = true;
            }
            btnSituazioneMovimentoSpesa.Enabled = !Meta.InsertMode;

            SetFasePrecedente();
            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 6d");

            //Riempie i textbox del tab prestazione
            //Le aliquote sono lette da dettaglioritenuteview
            RefreshTabPrestazione();

            //set tipoclassmovimenti like a cached table
            GetData.LockRead(DS.sortingkind);
            GetData.DenyClear(DS.sortingkind);
            if (Meta.FirstFillForThisRow) {
                Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
                //ManageClassificazioni.RefillDettagliClassificazioni(GetImportoPerClassificazione());
            }

            if (Meta.FirstFillForThisRow /*&& Meta.InsertMode*/) {
                ManageClassificazioni.EnterTabClassificazioni(currphase, currphase);
            }

            //ManageClassificazioni.RicalcolaTipoClassificazioni(currphase,currphase,false);
            ManageClassificazioni.CalcImpClassMovDefaults(GetImportoPerClassificazione());
            //metaprofiler.StopTimer(handle);
            //handle = metaprofiler.StartTimer("SPESA fase 7");


            // CEDOLINO PARASUBORDINATO
            if ((DS.expensepayroll.Columns["idpayroll"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expensepayroll.Rows.Count == 0 &&
                faseCedolinoInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_cedolino);
                txtNumDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll",
                    "(idpayroll=" + QueryCreator.quotedstrvalue(DS.expensepayroll.Columns["idpayroll"].DefaultValue
                        , true) + ")", "npayroll")).ToString();
                txtEsercDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("payroll",
                    "(idpayroll=" + QueryCreator.quotedstrvalue(DS.expensepayroll.Columns["idpayroll"].DefaultValue
                        , true) + ")", "fiscalyear")).ToString();


                DS.expensepayroll.Columns["idpayroll"].DefaultValue = DBNull.Value;
                btnCedolino_Click(txtNumDoc, null);

            }

            // CONTRATTO OCCASIONALE
            if ((DS.expensecasualcontract.Columns["ycon"].DefaultValue != DBNull.Value) &&
                (DS.expensecasualcontract.Columns["ncon"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expensecasualcontract.Rows.Count == 0 &&
                faseOccasionaleInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_occasionale);
                txtNumDoc.Text = DS.expensecasualcontract.Columns["ncon"].DefaultValue.ToString();
                txtEsercDoc.Text = DS.expensecasualcontract.Columns["ycon"].DefaultValue.ToString();
                DS.expensecasualcontract.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expensecasualcontract.Columns["ncon"].DefaultValue = DBNull.Value;
                btnOccasionale_Click(txtNumDoc, null);
            }

            // CONTRATTO PROFESSIONALE
            if ((DS.expenseprofservice.Columns["ycon"].DefaultValue != DBNull.Value) &&
                (DS.expenseprofservice.Columns["ncon"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expenseprofservice.Rows.Count == 0 &&
                faseProfessionaleInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_professionale);
                txtNumDoc.Text = DS.expenseprofservice.Columns["ncon"].DefaultValue.ToString();
                txtEsercDoc.Text = DS.expenseprofservice.Columns["ycon"].DefaultValue.ToString();
                DS.expenseprofservice.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expenseprofservice.Columns["ncon"].DefaultValue = DBNull.Value;
                btnProfessionale_Click(txtNumDoc, null);
            }

            // CONTRATTO DIPENDENTE
            if ((DS.expensewageaddition.Columns["ycon"].DefaultValue != DBNull.Value) &&
                (DS.expensewageaddition.Columns["ncon"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expensewageaddition.Rows.Count == 0 &&
                faseDipendenteInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_dipendente);
                txtNumDoc.Text = DS.expensewageaddition.Columns["ncon"].DefaultValue.ToString();
                txtEsercDoc.Text = DS.expensewageaddition.Columns["ycon"].DefaultValue.ToString();
                DS.expensewageaddition.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expensewageaddition.Columns["ncon"].DefaultValue = DBNull.Value;
                btnDipendente_Click(txtNumDoc, null);
            }

            // ORDINE GENERICO
            if ((DS.expensemandate.Columns["idmankind"].DefaultValue != DBNull.Value) &&
                (DS.expensemandate.Columns["yman"].DefaultValue != DBNull.Value) &&
                (DS.expensemandate.Columns["nman"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expensemandate.Rows.Count == 0 &&
                faseOrdineInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_ordine);
                ImpostaComboMandateKind();
                HelpForm.SetComboBoxValue(cmbTipoDocumento,
                    DS.expensemandate.Columns["idmankind"].DefaultValue);
                txtNumDoc.Text = DS.expensemandate.Columns["nman"].DefaultValue.ToString();
                txtEsercDoc.Text = DS.expensemandate.Columns["yman"].DefaultValue.ToString();
                DS.expensemandate.Columns["idmankind"].DefaultValue = DBNull.Value;
                DS.expensemandate.Columns["yman"].DefaultValue = DBNull.Value;
                DS.expensemandate.Columns["nman"].DefaultValue = DBNull.Value;
                btnOrdine_Click(txtNumDoc, null);
            }

            // IVA
            if ((DS.expenseinvoice.Columns["idinvkind"].DefaultValue != DBNull.Value) &&
                (DS.expenseinvoice.Columns["yinv"].DefaultValue != DBNull.Value) &&
                (DS.expenseinvoice.Columns["ninv"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expenseinvoice.Rows.Count == 0 &&
                faseIvaInclusa()
            ) {
                SetContabilizzazione(tipocont.cont_iva);
                ImpostaComboInvoiceKind();
                HelpForm.SetComboBoxValue(cmbTipoDocumento, DS.expenseinvoice.Columns["idinvkind"].DefaultValue);
                txtNumDoc.Text = DS.expenseinvoice.Columns["ninv"].DefaultValue.ToString();
                txtEsercDoc.Text = DS.expenseinvoice.Columns["yinv"].DefaultValue.ToString();
                DS.expenseinvoice.Columns["yinv"].DefaultValue = DBNull.Value;
                DS.expenseinvoice.Columns["ninv"].DefaultValue = DBNull.Value;
                btnIva_Click(txtNumDoc, null);
            }

            // MISSIONE
            if ((DS.expenseitineration.Columns["iditineration"].DefaultValue != DBNull.Value) &&
                Meta.InsertMode &&
                DS.expenseitineration.Rows.Count == 0 &&
                faseMissioneInclusa()) {
                SetContabilizzazione(tipocont.cont_missione);
                txtNumDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                    "(iditineration=" + QueryCreator.quotedstrvalue(
                        DS.expenseitineration.Columns["iditineration"].DefaultValue
                        , true) + ")", "nitineration")).ToString();
                txtEsercDoc.Text = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("itineration",
                    "(iditineration=" + QueryCreator.quotedstrvalue(
                        DS.expenseitineration.Columns["iditineration"].DefaultValue
                        , true) + ")", "yitineration")).ToString();
                DS.expenseitineration.Columns["iditineration"].DefaultValue = DBNull.Value;
                btnMissione_Click(txtNumDoc, null);

            }

            //metaprofiler.StopTimer(handle);
            if (Meta.FirstFillForThisRow) {
                if ((MissionLinked == null) && (CedolinoLinked == null) && (DipendenteLinked == null) &&
                    (OccasionaleLinked == null) && (ProfessionaleLinked == null)
                    && (SubEntity_cmbTipoprestazione.SelectedIndex > 0) &&
                    (SubEntity_cmbTipoprestazione.SelectedValue != null)) {
                    string allowedit = "N";
                    object codprestazione = SubEntity_cmbTipoprestazione.SelectedValue;
                    string filter = QHC.CmpEq("idser", codprestazione);
                    DataRow[] prestazioni = DS.service.Select(filter);
                    if (prestazioni.Length != 0) {
                        allowedit = prestazioni[0]["allowedit"].ToString().ToUpper();
                    }

                    if (allowedit == "S") {

                        labePrestGenerica.Visible = true;
                    }
                    else {
                        labePrestGenerica.Visible = false;
                    }
                }
                else {
                    labePrestGenerica.Visible = false;
                }
            }

            // Gestione filtro su partite pendenti
            string tagBtnBolletta = "choose.bill.spesa";
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                btnBolletta.Tag =
                    "choose.bill.spesa.((active='S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0) ) ";
            }

            if (Meta.IsEmpty) {
                btnBolletta.Tag = tagBtnBolletta;
            }
            impostaFlagNonContabilizzazioneImpegno();
            impostaFlagNonContabilizzazione();
        } //fine after_fill

        //task n. 16413

        public void ImpostaBilancioperMonofase() {
            if (!(Meta.IsEmpty) && Meta.InsertMode && monofase) {
                DataRow DRImputazione = DS.expenseyear.Rows[0];
                //Se il bilancio � null, ed � un monofase con una sola voce di bilancio(escluse le p.g.)
                //allora imposta per defualt quella voce sull'idfin
                if ((DRImputazione["idfin"] == DBNull.Value) || (DRImputazione["idfin"] == null)) {
                    int countFin = CfgFn.GetNoNullInt32(MyConn.count("finusable", q.bitClear("flag", 1) & q.bitSet("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio"))));
                    if (countFin == 1) {
                        chkFilterAvailable.Checked = false;
                        var idfin = MyConn.readValue("finusable", q.bitClear("flag", 1) & q.bitSet("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio")), "idfin");
                        string filter_idfin = QHS.CmpEq("idfin", idfin);
                        DRImputazione["idfin"] = idfin;
                        DS.finview.Clear();
                        DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.finview, null, filter_idfin, null, true);
                        if (DS.finview.Rows.Count > 0) {
                            DataRow Bil = DS.finview.Rows[0];
                            txtCodiceBilancio.Text = Bil["codefin"].ToString();
                            txtDenominazioneBilancio.Text = Bil["title"].ToString();
                            MetaData_AfterRowSelect(DS.finview, Bil);
                        }
                        else {
                            txtCodiceBilancio.Text = "";
                            txtDenominazioneBilancio.Text = "";
                            MetaData_AfterRowSelect(DS.finview, null);
                        }
                    }
                }
            }

        }
        void impostaFlagNonContabilizzazione() {
            if (!Meta.InsertMode) return;
            if (!faseMaxInclusa()) return;
            var rExp = DS.expense.First();
            if (rExp == null) return;
            if ((rExp.autokind ?? 0) != 0) {
                impostaBitUltimaFase(false);
                return; 
            }

            if (checkPresenzaContabilizzazione()) {
                impostaBitUltimaFase(false);
                return;
            }

            var rExpYear = DS.expenseyear.First();
            if (rExpYear == null) return;
            if (rExpYear.idfin != null) {
                var flag = CfgFn.GetNoNullInt32(MyConn.readValue("fin", q.eq("idfin", rExpYear.idfin), "flag"));
                if ((flag & 2) != 0) {
                    impostaBitUltimaFase(false);
                    return;
                }
            }

            impostaBitUltimaFase(true);
        }


        void impostaFlagNonContabilizzazioneImpegno()
        {
            // il bit zero del campo flag viene settato solo se 
            // il movimento creato manualmente non � una contabilizzazione
            if (!Meta.InsertMode) return;
            if (!faseOrdineInclusa()) return;
            var rExp = DS.expense.First();
            if (rExp == null) return;
            if (rExp.nphase != faseordine) return;
            // Il flag sulla fase dell'impegno/accertamento non deve essere valorizzato quando trattasi di automatismo
            if ((rExp.autokind ?? 0) != 0)
            {
                impostaBitFaseOrdine(false);
                return;
            }

            if (checkPresenzaContabilizzazioneImpegno())
            {
                impostaBitFaseOrdine(false);
                return;
            }

            var rExpYear = DS.expenseyear.First();
            if (rExpYear == null) return;
            if (rExpYear.idfin != null)
            {
                // l flag sulla fase dell'impegno/accertamento non deve essere valorizzato quando:
                // 1 sul capitolo finanziario � presente il flag 'partite di giro'  bit posizione 1
                // 2 sul capitolo finanziario � presente il flag 'permetti movimenti non legati a contabilizzazione'  bit posizione 6
                var flag = CfgFn.GetNoNullInt32(MyConn.readValue("fin", q.eq("idfin", rExpYear.idfin), "flag"));
                if ((flag & 2) != 0) // 'partite di giro' 
                {
                    impostaBitFaseOrdine(false);
                    return;
                }
                if ((flag & 64) != 0)
                {
                    impostaBitFaseOrdine(false); //'permetti movimenti non legati a contabilizzazione'
                    return;
                }
            }

            impostaBitFaseOrdine(true);
        }


        void impostaBitUltimaFase(bool imposta) {
            var rLast = DS.expenselast.First();
            if (rLast == null) return;
            if (imposta) {                
                rLast.flag =(byte) ((rLast.flag??0) |  128 );//mette il bit 7 di expenselast
            }
            else {
                rLast.flag =(byte) ((rLast.flag??0) &  ~128 );//toglie il bit 7 di expenselast
            }
        }

          void impostaBitFaseOrdine(bool imposta) {
            var rMov = DS.expense.First();
            if (rMov == null) return;
            if (imposta) {
                rMov.flag =(byte) ((rMov.flag??0) |  1 );//imposta il bit 0 di expense
            }
            else {
                rMov.flag =(byte) ((rMov.flag??0) &  ~1 );//azzera il bit 0 di expense
            }
        }

        bool checkPresenzaContabilizzazione() {
            
            if (DipendenteLinked != null) return true; //incondizionatamente

            //if (ProfessionaleLinked != null) return true; questo non ci interesa, � necessario contabilizzare una fattura in questo caso

            if (OccasionaleLinked != null) return true; //incondizionatamente

            if (IvaLinked != null) return true;          //incondizionatamente
            if (MissionLinked != null) return true;      //incondizionatamente
            if (CedolinoLinked != null) return true;     //incondizionatamente

            //if (OrdineLinked != null) {
            //    //solo se ordine non collegabile a fattura
            //    var rMandateKind = DS.mandatekind.First(q.eq("idmankind", OrdineLinked["idmankind"]));
            //    return rMandateKind?.linktoinvoice?.ToUpper()=="N";
            //}
            if (DS.expenselastmandatedetail.Select().Length > 0) return true;

            //Serve per il monofase. 
            if (fasespesamax == 1) return true;

            return false;
        }

        bool checkPresenzaContabilizzazioneImpegno()
        {
            if (OrdineLinked != null) return true;
            if (DipendenteLinked != null) return true;  
            if (ProfessionaleLinked != null) return true; 
            if (OccasionaleLinked != null) return true;  
            if (MissionLinked != null) return true;      
            if (CedolinoLinked != null) return true;
            //Serve per il monofase. 
            if (fasespesamax == 1) return true;
            return false;
        }


        string GetDefaultForUpb() {
            return ""; // "0001";
            //if (DS.upb.Select(QHC.CmpEq("idupb", "0001")).Length > 0) return "0001";
            //DataRow[] upblist = DS.upb.Select(QHC.CmpNe("idupb", ""), "codeupb asc");
            //if (upblist.Length == 0) return "";
            //return upblist[0]["idupb"].ToString();

        }

        public void CreateImputazioneSpesaRow() {
            if (Meta.IsEmpty) return;
            if (DS.Tables["expenseyear"].Rows.Count == 0) {
                try {
                    DataRow DRSpesa = DS.Tables["expense"].Rows[0];
                    MetaData MetaImp = MetaData.GetMetaData(this, "expenseyear");
                    MetaImp.SetDefaults(DS.expenseyear);
                    DataRow DR = MetaImp.Get_New_Row(DRSpesa, DS.expenseyear);
                    if (currphase == ManageUPB.faseattivazione) {
                        SetUPB(GetDefaultForUpb());
                    }

                    DR["ayear"] = Meta.GetSys("esercizio");
                }
                catch {
                }
            }

            if (currphase >= fasespesamax && DS.Tables["expenselast"].Rows.Count == 0) {
                try {
                    DataRow DRSpesa = DS.Tables["expense"].Rows[0];
                    MetaData MetaLast = MetaData.GetMetaData(this, "expenselast");
                    MetaLast.SetDefaults(DS.expenselast);
                    DataRow DR = MetaLast.Get_New_Row(DRSpesa, DS.expenselast);
                }
                catch {
                }
            }

        }


        void RicalcolaImportoCorrente() {
            if (!Meta.EditMode) return;
            try {
                decimal importo = GetImportoPerClassificazione();
                decimal old = CfgFn.GetNoNullDecimal(DS.expensetotal.Rows[0]["curramount"]);
                if (importo != old) {
                    decimal diff = importo - old;
                    DS.expensetotal.Rows[0]["curramount"] = importo;
                    decimal disponibile = CfgFn.GetNoNullDecimal(DS.expensetotal.Rows[0]["available"]);
                    disponibile += diff;
                    DS.expensetotal.Rows[0]["available"] = disponibile;
                    DS.expensetotal.Rows[0].AcceptChanges();
                    UpdateImportoDependencies();
                }
            }
            catch {
            }
        }


        #endregion

        private void FormattaDataDelTexBox(TextBox TB) {
            if (!TB.Modified) return;
            HelpForm.FormatLikeYear(TB);
        }




        /// <summary>
        /// Restituisce un decimal da una stringa
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        private decimal Dec(string S) {
            if (S.Length == 0) return 0;
            try {
                return Convert.ToDecimal(S);
            }
            catch {
                return 0;
            }
        }

        //restituisce una stringa da un decimal
        private string Str(decimal D) {
            if (D == 0) return "";
            return D.ToString("c");
        }




        #region Gestione fase precedente

        void AzzeraPadre() {
            DataRow CurrSpesa = DS.expense.Rows[0];
            CurrSpesa["parentidexp"] = DBNull.Value;
            txtNumeroFasePrecedente.Text = "";
            txtEsercizioFasePrecedente.Text = "";
            CalcolaStartFilter(null);
        }


        /// <summary>
        /// calcola l'esercizio e il numero di movimento del padre del movimento corrente
        /// </summary>
        private void SetFasePrecedente() {
            if (cmbFaseSpesa.SelectedIndex <= 1) return; //se esiste una fase precedente
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object Livsupid = DS.Tables["expense"].Rows[0]["parentidexp"];
            string filter = "(idexp = " + QueryCreator.quotedstrvalue(Livsupid, true) + ")";
            DataTable DT = MyConn.RUN_SELECT("expense", "idexp,ymov,nmov,autokind", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEsercizioFasePrecedente.Text = DT.Rows[0]["ymov"].ToString();
            txtNumeroFasePrecedente.Text = DT.Rows[0]["nmov"].ToString();
        }

        bool DocumentoContabilizzato() {
            tipocont curr = ContabilizzazioneSelezionata();
            if (curr == tipocont.cont_none) return false;
            switch (curr) {
                case tipocont.cont_cedolino: return (CedolinoLinked != null);
                case tipocont.cont_dipendente: return (DipendenteLinked != null);
                case tipocont.cont_iva: return (IvaLinked != null);
                case tipocont.cont_missione: return (MissionLinked != null);
                case tipocont.cont_occasionale: return (OccasionaleLinked != null);
                case tipocont.cont_ordine: return (OrdineLinked != null);
                case tipocont.cont_professionale: return (ProfessionaleLinked != null);
            }

            return false;
        }

        bool OrdineOFatturaContabilizzato() {
            tipocont curr = ContabilizzazioneSelezionata();
            if (curr == tipocont.cont_none) return false;
            switch (curr) {
                case tipocont.cont_iva: return (IvaLinked != null);
                case tipocont.cont_ordine: return (OrdineLinked != null);
            }

            return false;
        }

        /// <summary>
        /// Estrae un filtro in base a:
        ///  - fase precedente
        ///  - disponibilit� (solo se Modo Insert)
        ///  - textbox EserciziofasePrecedente
        ///  - textbox NumeroFasePrecedente
        /// </summary>
        /// <returns></returns>
        string GetFasePrecFilter(bool FiltraNumMovimento) {
            string ffase = "";
            if (cmbFaseSpesa.SelectedIndex > 0) {
                int codicefase = CfgFn.GetNoNullInt32(cmbFaseSpesa.SelectedValue);
                ffase = QHS.CmpEq("nphase", codicefase - 1);
            }

            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            if (Meta.InsertMode) {
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpGt("available", 0));
            }

            if (txtEsercizioFasePrecedente.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioFasePrecedente.Text.Trim()));
            //if (!FiltraNumMovimento) return MyFilter; //
            if (FiltraNumMovimento && (txtNumeroFasePrecedente.Text.Trim() != ""))
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroFasePrecedente.Text.Trim()));

            if (!Meta.IsEmpty) {
                DataRow Curr = DS.expense.Rows[0];
                int codicecreddeb = CfgFn.GetNoNullInt32(Curr["idreg"]);
                int fasecred = ManageCreditore.faseattivazione;
                if (fasecred < currphase && DocumentoContabilizzato()) {
                    if (codicecreddeb > 0)
                        MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
                }
            }

            if (!Meta.IsEmpty) {
                DataRow CurrImp = DS.expenseyear.Rows[0];
                object idupb = CurrImp["idupb"];
                int faseupb = ManageUPB.faseattivazione;
                if (faseupb < currphase && OrdineOFatturaContabilizzato()) {
                    if (idupb != DBNull.Value)
                        MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idupb", idupb));
                }
            }

            return MyFilter;
        }


        void CalcTotMandatePagamenti() {
            txtTotDettPagamenti.Text = "";
            if (Meta.IsEmpty) return;
            decimal totale = GetImportoDettagliContrattoPagati();
            txtTotDettPagamenti.Text = totale.ToString("c");
            }

        private void btnFasePrecedente_Click(object sender, System.EventArgs e) {
            bool ThereWasMissionLinked = (MissionLinked != null);
            bool ThereWasOrdineLinked = (OrdineLinked != null);
            bool ThereWasIvaLinked = (IvaLinked != null);
            bool ThereWasCedolinoLinked = (CedolinoLinked != null);
            bool ThereWasProfessionaleLinked = (ProfessionaleLinked != null);
            bool ThereWasOccasionaleLinked = (OccasionaleLinked != null);
            bool ThereWasDipendenteLinked = (DipendenteLinked != null);

            DataAccess Conn = MetaData.GetConnection(this);
            string MyFilter;

            if (((Control) sender).Name == "txtNumeroFasePrecedente")
                MyFilter = GetFasePrecFilter(true);
            else
                MyFilter = GetFasePrecFilter(false);

            MetaData MFase = MetaData.GetMetaData(this, "expenseview");
            MFase.FilterLocked = true;
            MFase.DS = DS;

            if (Meta.InsertMode)
            {
                string valuelist = QHS.quote(30) + "," + QHS.quote(31)+ "," +QHS.quote(20) + "," + QHS.quote(21) ;
                MyFilter = QHS.AppAnd(MyFilter,
                                          QHS.DoPar(QHS.AppOr(QHS.IsNull("autokind"), QHS.FieldNotInList("autokind", valuelist))));
            }
            DataRow MyDR = MFase.SelectOne("elencofaseprec", MyFilter, null, null);

            if (MyDR == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                    }
                }

                return;
            }

            CalcolaStartFilter(MyDR["idexp"].ToString());

            if (Meta.IsEmpty) {
                //Se mi trovo in imposta ricerca
                txtCredDeb.Text = MyDR["registry"].ToString();
                txtEsercizioFasePrecedente.Text = MyDR["ymov"].ToString();
                txtNumeroFasePrecedente.Text = MyDR["nmov"].ToString();
            }

            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                DisponibileDaFasePrecedente = CfgFn.GetNoNullDecimal(MyDR["available"]);
                //Legge i dati dal Form
                MetaData.GetFormData(this, true);
                DS.expense.Rows[0]["parentidexp"] = MyDR["idexp"];
                DataRow DRImputazione = DS.Tables["expenseyear"].Rows[0];
                DataRow DRSpesa = DS.Tables["expense"].Rows[0];

                if (currphase > ManageCreditore.faseattivazione)
                    DRSpesa["idreg"] = MyDR["idreg"];

                bool MissionLocked = ((MissionLinkedMustBeEvalued == false) && (MissionLinked != null));
                bool OrdineLocked = ((OrdineLinkedMustBeEvalued == false) && (OrdineLinked != null));
                bool IvaLocked = ((IvaLinkedMustBeEvalued == false) && (IvaLinked != null));
                bool CedolinoLocked = ((CedolinoLinkedMustBeEvalued == false) && (CedolinoLinked != null));
                bool OccasionaleLocked = ((OccasionaleLinkedMustBeEvalued == false) && (OccasionaleLinked != null));
                bool ProfessionaleLocked =
                    ((ProfessionaleLinkedMustBeEvalued == false) && (ProfessionaleLinked != null));
                bool DipendenteLocked = ((DipendenteLinkedMustBeEvalued == false) && (DipendenteLinked != null));

                if ((MissionLocked == false) && (OrdineLocked == false) &&
                    (IvaLocked == false) && (CedolinoLocked == false) &&
                    (ProfessionaleLocked == false) && (OccasionaleLocked == false) && (DipendenteLocked == false)) {
                    DRSpesa["doc"] = MyDR["doc"];
                    DRSpesa["docdate"] = MyDR["docdate"];
                    DRSpesa["description"] = MyDR["description"];
                }

                // 5 = Riemissione in conto competenza
                if (CfgFn.GetNoNullInt32(MyDR["autokind"]) != 5) {
                    DRSpesa["idpayment"] = MyDR["idpayment"];
                    DRSpesa["autokind"] = MyDR["autokind"];
                    DRSpesa["autocode"] = MyDR["autocode"];
                }
                else {
                    DRSpesa["idpayment"] = DBNull.Value;
                    DRSpesa["autokind"] = DBNull.Value;
                    DRSpesa["autocode"] = DBNull.Value;
                }


                if (((OrdineLocked == false) && (IvaLocked == false)) || DRSpesa["idman"] == DBNull.Value) {
                    DRSpesa["idman"] = MyDR["idman"];
                }
                object idman =  MyConn.readValue("upb",q.eq("idupb",MyDR["idupb"] ),"idman");

				if(idman != DBNull.Value) {
					DRSpesa["idman"] = idman;
				}
                DRImputazione["idexp"] = DRSpesa["idexp"];
                DRImputazione["ayear"] = Meta.GetSys("esercizio").ToString();

                if (currphase > ManageBilAnnuale.faseattivazione) {
                    DRImputazione["idfin"] = MyDR["idfin"];
                    DRImputazione["idupb"] = MyDR["idupb"];
                    SetUPB(MyDR["idupb"]);
                }

                DRImputazione["amount"] = MyDR["available"];
                RecalcImporto();

                //DRImputazione["flagarrear"] = MyDR["flagarrear"];
                bool MustSetPosGiuridica = false;

                //Valori del padre del movimento
                txtEsercizioFasePrecedente.Text = MyDR["ymov"].ToString();
                txtNumeroFasePrecedente.Text = MyDR["nmov"].ToString();
                if (currphase > ManageCreditore.faseattivazione) {
                    CalcolaValoriDefaultModPagamento(DRSpesa["idreg"]);
                    LeggiDatiSuCredDeb(DRSpesa["idreg"]);
                    if (DS.registry.Rows.Count > 0) {
                        DataRow CredDeb = DS.registry.Rows[0];
                        SetComboCreditoreDebitore();
                        MustSetPosGiuridica = true;
                    }
                }

                ResetTipoClassAvailableEvalued();
                lastimportofreshed = GetImporto() + 1;

                ResetDocumentiFasiNonIncluse();

                Meta.FreshForm(true); //richiama in automatico il Ricalcolo Missione,
                if (SubEntity_cmbTipoprestazione.Enabled == false) MustSetPosGiuridica = false;
                if (MustSetPosGiuridica) ImpostaPosGiuridica(true);
                //poich� l'importo � variato
                //RicalcolaPrestazioneMissione(false);
                //GeneraOAzzeraRigaRecupero();  (automatico nel freshform)
            }

            if (Meta.InsertMode) {
                DS.expenselastmandatedetail.Clear();
                if (checkAbilitaDettaglioPagamenti()) {
                    autodetectPagamenti();
                    CalcTotMandatePagamenti();
                    }
                }
            if (ThereWasMissionLinked && (MissionLinked == null)) {
                ScollegaMissione();
                ClearControlliMissione();
            }

            if (ThereWasOrdineLinked && (OrdineLinked == null)) {
                ScollegaOrdine();
                ClearControlliOrdine(false);
            }

            if (ThereWasIvaLinked && (IvaLinked == null)) {
                ScollegaIva();
                ClearControlliIva(false);
            }

            if (ThereWasCedolinoLinked && (CedolinoLinked == null)) {
                ScollegaCedolino();
                ClearControlliCedolino();
            }

            if (ThereWasOccasionaleLinked && (OccasionaleLinked == null)) {
                ScollegaOccasionale();
                ClearControlliOccasionale();
            }

            if (ThereWasProfessionaleLinked && (ProfessionaleLinked == null)) {
                ScollegaProfessionale();
                ClearControlliProfessionale();
            }

            if (ThereWasDipendenteLinked && (DipendenteLinked == null)) {
                ScollegaDipendente();
                ClearControlliDipendente();
            }


        }

        void ResetDocumentiFasiNonIncluse() {
            if (!faseMissioneInclusa()) {
                ResetMissione();
            }

            if (!faseOrdineInclusa()) {
                ResetOrdine();
            }

            if (!faseIvaInclusa()) {
                ResetIva();
            }

            if (!faseCedolinoInclusa()) {
                ResetCedolino();
            }

            if (!faseProfessionaleInclusa()) {
                ResetProfessionale();
            }

            if (!faseOccasionaleInclusa()) {
                ResetOccasionale();
            }

            if (!faseDipendenteInclusa()) {
                ResetDipendente();
            }

        }

        void LeggiDatiSuCredDeb(object codicecreddeb) {
            if (codicecreddeb == DBNull.Value) return;
            QueryCreator.MyClear(DS.registry);
            string filter = QHS.CmpEq("idreg", codicecreddeb);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filter, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registrypaymethod, null, filter, null, true);
        }

        private void txtNumeroFasePrecedente_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (txtNumeroFasePrecedente.ReadOnly) return;
            HelpForm.ExtLeaveIntTextBox(txtNumeroFasePrecedente,null);
            CalcolaStartFilter(null);

            if (!Meta.InsertMode) return;
            if (txtNumeroFasePrecedente.Text.Trim() == "") {
                DataRow Curr = DS.Tables["expense"].Rows[0];
                Curr["parentidexp"] = DBNull.Value;
                DisponibileDaFasePrecedente = 0;
                DataRow CurrImp = DS.Tables["expenseyear"].Rows[0];
                CurrImp["amount"] = 0;
                Curr["autokind"] = DBNull.Value;
                Curr["autocode"] = DBNull.Value;
                Curr["idpayment"] = DBNull.Value;
                ResetDocumentiFasiNonIncluse();
                VisualizzaControlliContabilizzazione(ContabilizzazioneSelezionata());
                return;
            }

            btnFasePrecedente_Click(sender, e);
        }

        void ClearStartFilter() {
            Meta.StartFilter = null;
        }

        void CalcolaStartFilter(string livsupid) {
            ClearStartFilter();
            if (livsupid != null)
                Meta.StartFilter = GetData.MergeFilters(Meta.StartFilter,
                    "(parentidexp='" + livsupid + "')");
            else {
                string flt = "";
                if (txtEsercizioFasePrecedente.Text.Length == 4) {
                    flt = QHS.CmpEq("parentymov", txtEsercizioFasePrecedente.Text);
                }

                if (txtNumeroFasePrecedente.Text != "") {
                    flt = QHS.AppAnd(flt, QHS.CmpEq("parentnmov", txtNumeroFasePrecedente.Text));
                }

                Meta.StartFilter = flt;
            }
        }

        private void txtEsercizioFasePrecedente_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercizioFasePrecedente.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercizioFasePrecedente);
            CalcolaStartFilter(null);
        }


        #endregion


        #region Cambio Fase

        void AzzeraDatiSuFasiNonSelezionate() {
            if (!faseMaxInclusa()) {
                DS.expenselast.Clear();

                //Elimina ritenute 
                DS.expensetax.Clear();
                DS.expensetaxofficial.Clear();
                DS.expensetaxcorrige.Clear();
                RefreshTabPrestazione();

                //Elimina expensebill
                DS.expensebill.Clear();

                //Elimina recuperi
                DS.expenseclawback.Clear();
                CalcolaTotaliSuGrids();

                txtModPagamento.Text = "";
                SetModPagamentoDetails(null);
            }

            if (!faseMaxInclusa()) {
                DS.underwritingpayment.Clear();
            }

            if (!faseBilancioInclusa()) {
                DS.underwritingappropriation.Clear();
            }

            if (!faseMissioneInclusa()) {
                DS.expenseitineration.Clear();
                DS.itineration.Clear();
            }

            if (!faseOrdineInclusa()) {
                DS.expensemandate.Clear();
                DS.mandate.Clear();
                if (!dettaglioContrattiPagati) DS.mandatedetail_taxable.Clear();
                DS.mandatedetail_iva.Clear();
            }

            if (!faseIvaInclusa()) {
                DS.expenseinvoice.Clear();
                DS.invoice.Clear();
                DS.invoicedetail_taxable.Clear();
                DS.invoicedetail_iva.Clear();
            }

            if (!faseCedolinoInclusa()) {
                DS.expensepayroll.Clear();
                DS.payroll.Clear();
            }

            if (!faseOccasionaleInclusa()) {
                DS.expensecasualcontract.Clear();
                DS.casualcontract.Clear();
            }

            if (!faseProfessionaleInclusa()) {
                DS.expenseprofservice.Clear();
                DS.profservice.Clear();
            }

            if (!faseDipendenteInclusa()) {
                DS.expensewageaddition.Clear();
                DS.wageaddition.Clear();
            }


        }


        public void AzzeraDatiSuCambioFase() {

            AzzeraPadre();

            DS.expensevar.Clear();
            DS.expensesorted.Clear();

            ResetMissione();
            ResetOrdine();
            ResetIva();
            ResetCedolino();
            ResetOccasionale();
            ResetProfessionale();
            ResetDipendente();

            AzzeraDatiSuFasiNonSelezionate();

        }


        void CambiaFase() {
            if (currphase == cmbFaseSpesa.SelectedIndex) return;
            int fase = cmbFaseSpesa.SelectedIndex < 0 ? 0 : cmbFaseSpesa.SelectedIndex;
            currphase = Convert.ToByte(fase); //0-indexed
            CreateImputazioneSpesaRow();

            //ApplicaLogicaSufase() also clear when idbilancio,idblilpruriennale, 
            //  codicecreddeb, codicefondo, codiceripartiz., and pagamento data 
            //  when needed
            AddRemoveTabs(true);
            ApplicaLogicaSuFase();
            if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();

            if (Meta.InsertMode) {
                AzzeraPadre();
                AzzeraDatiSuCambioFase();
                ResetTipoClassAvailableEvalued();
            }

        }

        #endregion

        #region Gestione Modalit� Pagamento

        /// <summary>
        /// Riempie il combobox delle modalit� di pagamento e lo imposta al valore opportuno
        /// </summary>
        /// <param name="CredDebitoreRow"></param>
        void SetComboCreditoreDebitore() {
            if (!faseMaxInclusa()) return;
            if (Meta.IsEmpty) return;

            if (DS.expenselast.Rows.Count == 0) {
                show(this, "Problemi con il caricamento dei dati, si consiglia di contattare l'assistenza.",
                    "Errore");
                Meta.LogError("ExpenseLevels>SetComboCreditoreDebitore expenselast vuoto");
                Meta.CanSave = false;
                DS.registrypaymethod.Clear();
                txtModPagamento.Text = "";
                return;
            }

            DataRow CurrLast = DS.expenselast.Rows[0];
            DataRow Curr = DS.expense.Rows[0];

            if (CurrLast["idregistrypaymethod"] == DBNull.Value) {
                DS.registrypaymethod.Clear();
                txtModPagamento.Text = "";
                return;
            }

            string filter = QHC.CmpEq("idregistrypaymethod", CurrLast["idregistrypaymethod"]);
            if (DS.registrypaymethod.Select(filter).Length > 0) {
                DataRow R = DS.registrypaymethod.Select(filter)[0];
                txtModPagamento.Text = R["regmodcode"].ToString();
                return;
            }

            DS.registrypaymethod.Clear();
            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.registrypaymethod, null,
                QHS.AppAnd(QHS.CmpEq("idreg", Curr["idreg"]),
                    QHS.CmpEq("idregistrypaymethod", CurrLast["idregistrypaymethod"])), null, true);
            if (DS.registrypaymethod.Rows.Count == 0) {
                txtModPagamento.Text = "Modalit� non trovata";
                return;
            }

            txtModPagamento.Text = DS.registrypaymethod.Rows[0]["regmodcode"].ToString();

            //Meta.myHelpForm.FillRelatedToRowControl(SubEntity_cmbTipoEstinzione, 
            //    DS.registry, 
            //    CredDebitoreRow);
            //if (CredDebitoreRow==null) return;
            //if (Meta.IsEmpty) return;
            //object val = DS.expenselast.Rows[0]["idregistrypaymethod"];
            //HelpForm.SetComboBoxValue(SubEntity_cmbTipoEstinzione, val);

        }

        /// <summary>
        /// Imposta solo CurrSpesa, senza toccare i textbox o i controlli
        /// </summary>
        /// <param name="CredDebi"></param>
        void CalcolaValoriDefaultModPagamento(object codicecred) {
            if (Meta.IsEmpty) return;
            if (!faseMaxInclusa()) return;
            DataRow CurrLast = DS.expenselast.Rows[0];
            int flag_exemption = 0;
            if ((codicecred == null) || (codicecred == DBNull.Value)) {
                foreach (string field in
                    new string[] {
                        "idregistrypaymethod", "idpaymethod", "iban", "idbank",
                        "idcab", "cin", "cc", "iddeputy",
                        "paymentdescr", "refexternaldoc", "biccode", "extracode", "idchargehandling"
                    }) {
                    if (CurrLast.Table.Columns.Contains(field)) {
                        if (field == "idchargehandling")
                            continue;
                        CurrLast[field] = DBNull.Value;
                    }
                }

                foreach (string field in
                    new string[] {"paymethod_allowdeputy", "paymethod_flag"}) {
                    if (CurrLast.Table.Columns.Contains(field))
                        CurrLast[field] = DBNull.Value;
                }

                if (LeggiFlagEsenteBancaPredefinita()) {
                    flag_exemption = (CfgFn.GetNoNullInt32(CurrLast["flag"]) & 0xF7);
                    CurrLast["flag"] = flag_exemption;
                }

                return;
            }

            DataRow DefPagam = CfgFn.ModalitaPagamentoDefault(MyConn, codicecred);
            if (DefPagam == null) return;
            foreach (string field in
                new string[] {
                    "idregistrypaymethod", "idpaymethod", "iban", "idbank",
                    "idcab", "cin", "cc", "iddeputy",
                    "paymentdescr", "refexternaldoc", "biccode", "extracode", "idchargehandling"
                }) {
                if ((CurrLast.Table.Columns.Contains(field)) &&
                    (DefPagam.Table.Columns.Contains(field))) {
                    if ((field == "idchargehandling") && (DefPagam[field] == DBNull.Value))
                        continue;
                    CurrLast[field] = DefPagam[field];
                }
            }

            object idpaymethod = DefPagam["idpaymethod"];
            string filter = QHC.CmpEq("idpaymethod", idpaymethod);
            DataRow[] Paymethod = DS.paymethod.Select(filter);

            if (LeggiFlagEsenteBancaPredefinita()) {
                flag_exemption = (CfgFn.GetNoNullInt32(CurrLast["flag"]) & 0xF7) |
                                 ((CfgFn.GetNoNullInt32(DefPagam["flag"]) & 1) << 3);
                CurrLast["flag"] = flag_exemption;
            }

            if (Paymethod.Length > 0) {
                object paymethod_allowdeputy = Paymethod[0]["allowdeputy"];
                if (CurrLast.Table.Columns.Contains("paymethod_allowdeputy")) {
                    CurrLast["paymethod_allowdeputy"] = paymethod_allowdeputy;
                }

                int paymethod_flag = CfgFn.GetNoNullInt32(Paymethod[0]["flag"]);
                if (CurrLast.Table.Columns.Contains("paymethod_flag")) {
                    int oldValue = CfgFn.GetNoNullInt32(CurrLast["paymethod_flag"]);
                    CurrLast["paymethod_flag"] = (paymethod_flag & 0x7FFF) | (oldValue & ~0x7FFF);
                    SpuntaCertificaticiNecessari(CurrLast);
                }
            }

            if (faseMaxInclusa()) {
				
	            object val = DefPagam["idpaymethod"];
	            HelpForm.SetComboBoxValue(SubEntity_cmbModPagamento, val);
	            txtModPagamento.Text = DefPagam["regmodcode"].ToString();
	            SubEntity_txtIBAN.Text = DefPagam["iban"].ToString();
	            SubEntity_txtBanca.Text = DefPagam["idbank"].ToString();
	            SubEntity_txtSportello.Text = DefPagam["idcab"].ToString();
	            SubEntity_txtCin.Text = DefPagam["cin"].ToString();
	            SubEntity_txtContoCorrente.Text = DefPagam["cc"].ToString();
	            SubEntity_txtDescrModPagamento.Text = DefPagam["paymentdescr"].ToString();
	            SubEntity_txtRifDocumentoEsterno.Text = DefPagam["refexternaldoc"].ToString();
	            SubEntity_txtBiccode.Text = DefPagam["biccode"].ToString();
	            SubEntity_txtExtraCode.Text = DefPagam["extracode"].ToString();
	            if (DefPagam["idchargehandling"] != DBNull.Value) {
		            HelpForm.SetComboBoxValue(SubEntity_cmbChargeHandling, DefPagam["idchargehandling"]);
	            }

	            Meta.myHelpForm.FillControls(tabOpzioniModPagamento.Controls);
	            string delegato = "";
	            if (DefPagam["iddeputy"] != DBNull.Value) {
		            string filtroDelegato = QHC.CmpEq("idreg", DefPagam["iddeputy"]);
		            DS.deputy.Clear();

		            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.deputy, null, filtroDelegato, null, true);
		            DataRow rDelegato = DS.deputy.Select(filtroDelegato)[0];
		            delegato = rDelegato["title"].ToString();
	            }

	            SubEntity_txtDelegato.Text = delegato;
	            SubEntity_txtDelegato.ReadOnly = true;
            }

        }

        private void btnModEstinzione_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.expenselast.Rows.Count == 0) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.expenselast.Rows[0];
            int paymethod_flagBit = CfgFn.GetNoNullInt32(Curr["paymethod_flag"]); 
            bool res = Meta.EditDataRow(Curr, "modpaga", out Curr);
            if (res) {
                paymethod_flagBit = (paymethod_flagBit & ~0x7FFF);//0x7FFF = 0000 0000 0111 1111 1111 1111
                int oldValue = CfgFn.GetNoNullInt32(Curr["paymethod_flag"]);
                Curr["paymethod_flag"] = (paymethod_flagBit) | (oldValue & ~0xFF8000);  //0xFF8000 = 1111 1111 1000 0000 0000 0000
                Curr["idregistrypaymethod"] = DBNull.Value;
                //Curr["regmodcode"] = DBNull.Value;
            }

            Meta.FreshForm(true);
        }


        /// <summary>
        /// Imposta a video i dettagli della mod. di pagamento in base alla modalit�
        ///  predefinita selezionata
        /// </summary>
        /// <param name="ModPagamento"></param>
        void SetModPagamentoDetails(DataRow ModPagamento) {
            DS.deputy.Clear();
            if (DS.expenselast.Rows.Count == 0) return;


            if (ModPagamento == null) {
                SubEntity_cmbModPagamento.SelectedIndex = -1;
                SubEntity_cmbChargeHandling.SelectedIndex = -1;
                DS.registrypaymethod.Clear();
                txtModPagamento.Text = "";
                SubEntity_txtIBAN.Text = "";
                SubEntity_txtBanca.Text = "";
                SubEntity_txtSportello.Text = "";
                SubEntity_txtCin.Text = "";
                SubEntity_txtContoCorrente.Text = "";
                SubEntity_txtDescrModPagamento.Text = "";
                SubEntity_txtRifDocumentoEsterno.Text = "";
                SubEntity_txtBiccode.Text = "";
                SubEntity_txtExtraCode.Text = "";
                //DS.expenselast.Rows[0]["paymethod_flag"] = 0;
                int paymethod_flagBit = 0; // CfgFn.GetNoNullInt32(ModPagamento["flag"]);
                int oldValue = CfgFn.GetNoNullInt32(DS.expenselast.Rows[0]["paymethod_flag"]);
                DS.expenselast.Rows[0]["paymethod_flag"] = (paymethod_flagBit & 0x7FFF) | (oldValue & ~0x7FFF);//0x7FFF = 0000 0000 0111 1111 1111 1111
                SpuntaCertificaticiNecessari(DS.expenselast.Rows[0]);
                if (LeggiFlagEsenteBancaPredefinita()) {
                    SubEntity_chkEsenteSpese.Checked = false;
                }

                DS.expenselast.Rows[0]["paymethod_allowdeputy"] = "N";
                return;
            }
			string delegato = "";
			object codDelegato = DBNull.Value;

			if (ModPagamento["iddeputy"] != DBNull.Value) {
				string filtroDelegato =
					"(idreg = '"
					+ ModPagamento["iddeputy"] + "')";

				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.deputy,
					null, filtroDelegato, null, true);
				DataRow rDelegato = DS.deputy.Select(filtroDelegato)[0];
				delegato = rDelegato["title"].ToString();
				codDelegato = ModPagamento["iddeputy"];
			}
			DS.expenselast.Rows[0]["idregistrypaymethod"] = ModPagamento["idregistrypaymethod"];
            object val = ModPagamento["idpaymethod"];
            string filterpaymethod = QHC.CmpEq("idpaymethod", val);
            DataRow[] Paymethod = DS.paymethod.Select(filterpaymethod);

            if (Paymethod.Length > 0) {
                object paymethod_allowdeputy = Paymethod[0]["allowdeputy"];
                DS.expenselast.Rows[0]["paymethod_allowdeputy"] = paymethod_allowdeputy;
                int paymethod_flagBit = CfgFn.GetNoNullInt32(Paymethod[0]["flag"]);
                int oldValue = CfgFn.GetNoNullInt32(DS.expenselast.Rows[0]["paymethod_flag"]);
                DS.expenselast.Rows[0]["paymethod_flag"] = (paymethod_flagBit & 0x7FFF) | (oldValue & ~0x7FFF);
            }
            else {
                int paymethod_flagBit = 0; // CfgFn.GetNoNullInt32(ModPagamento["flag"]);
                int oldValue = CfgFn.GetNoNullInt32(DS.expenselast.Rows[0]["paymethod_flag"]);
                DS.expenselast.Rows[0]["paymethod_flag"] = (paymethod_flagBit & 0x7FFF) | (oldValue & ~0x7FFF);
                DS.expenselast.Rows[0]["paymethod_allowdeputy"] = "N";
            }

            SpuntaCertificaticiNecessari(DS.expenselast.Rows[0]);
            HelpForm.SetComboBoxValue(SubEntity_cmbModPagamento, val);
            txtModPagamento.Text = ModPagamento["regmodcode"].ToString();
            SubEntity_txtIBAN.Text = ModPagamento["iban"].ToString();
            SubEntity_txtBanca.Text = ModPagamento["idbank"].ToString();
            SubEntity_txtSportello.Text = ModPagamento["idcab"].ToString();
            SubEntity_txtCin.Text = ModPagamento["cin"].ToString();
            SubEntity_txtContoCorrente.Text = ModPagamento["cc"].ToString();
            SubEntity_txtDescrModPagamento.Text = ModPagamento["paymentdescr"].ToString();
            SubEntity_txtRifDocumentoEsterno.Text = ModPagamento["refexternaldoc"].ToString();
            SubEntity_txtBiccode.Text = ModPagamento["biccode"].ToString();
            SubEntity_txtExtraCode.Text = ModPagamento["extracode"].ToString();
            if (ModPagamento["idchargehandling"] != DBNull.Value) {
                HelpForm.SetComboBoxValue(SubEntity_cmbChargeHandling, ModPagamento["idchargehandling"]);
            }

            if (LeggiFlagEsenteBancaPredefinita()) {
                int flag_exemption = (CfgFn.GetNoNullInt32(DS.expenselast.Rows[0]["flag"]) & 0xF7) |
                                     ((CfgFn.GetNoNullInt32(ModPagamento["flag"]) & 1) << 3);
                SubEntity_chkEsenteSpese.Checked = !((flag_exemption & 8) == 0);
            }

            SubEntity_txtDelegato.Text = delegato;
            SubEntity_txtDelegato.ReadOnly = true;
            DS.expenselast.Rows[0]["iddeputy"] = codDelegato;
            string filterold = QHC.AppOr(QHC.CmpNe("idreg", ModPagamento["idreg"]),
                QHC.CmpNe("idregistrypaymethod", ModPagamento["idregistrypaymethod"]));
            foreach (DataRow RToDel in DS.registrypaymethod.Select(filterold)) {
                RToDel.Delete();
            }

            DS.registrypaymethod.AcceptChanges();
            Meta.myHelpForm.FillControls(tabOpzioniModPagamento.Controls);
            string filter = QHC.AppAnd(QHC.CmpEq("idreg", ModPagamento["idreg"]),
                QHC.CmpEq("idregistrypaymethod", ModPagamento["idregistrypaymethod"]));

            if (DS.registrypaymethod.Select(filter).Length == 0) {
                DS.registrypaymethod.Clear();
                string filterSQL = QHS.AppAnd(QHS.CmpEq("idreg", ModPagamento["idreg"]),
                    QHS.CmpEq("idregistrypaymethod", ModPagamento["idregistrypaymethod"]));
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.registrypaymethod, null, filterSQL, null, true);
            }

        }

        void ManageModPagamentoCredDebiRowChange(DataRow R) {
            SetModPagamentoDetails(R);
        }

        #endregion

        #region BeforePost/AfterPost

        bool ricalcolaPaymentBank = false;
        int kpay = 0;
        bool mostraMessScrittureEP = false;

        public void MetaData_BeforePost() {
            ricalcolaPaymentBank = false;
            kpay = 0;
            if (DS.Tables["expense"].Rows.Count == 0) return;
            if (!Meta.IsEmpty) {
                if (DS.Tables["expense"].Rows[0].RowState == DataRowState.Deleted) {
                    DS.expensetotal.Clear();
                    MustRefreshImportoSpesa = true;
                    if (DS.expenselast.Rows.Count > 0 &&
                        DS.expenselast.Rows[0]["kpay", DataRowVersion.Original] != DBNull.Value) {
                        ricalcolaPaymentBank = true;
                        kpay = CfgFn.GetNoNullInt32(DS.expenselast.Rows[0]["kpay", DataRowVersion.Original]);
                    }
                }
                else {
                    if (currphase != CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"))) return;
                    if (DS.expenselast.Rows.Count==0)return;
                    
                        DataRow CurrLast = DS.expenselast.Rows[0];
                        if (CurrLast["iddeputy"] != DBNull.Value) {
                            string filtroDelegato =
                                "(idreg = '"
                                + CurrLast["iddeputy"] + "')";

                            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.deputy,
                                null, filtroDelegato, null, true);
                            DataRow rDelegato = DS.deputy.Select(filtroDelegato)[0];
                            string delegato = rDelegato["title"].ToString();
                            string message =
                                "Sulla modalit� di pagamento dell'anagrafica � stato inserito il Delegato. ";
                            message += "Sar� generato il pagamento a favore di " + delegato;
                            if (CurrLast["iban"] != DBNull.Value)
                                message += " con IBAN " + CurrLast["iban"].ToString();
                            show(message, "Conferma", MessageBoxButtons.OK);
                        }

                    foreach (DataRow rVar in DS.expensevar.Rows) {
                        if (rVar.RowState == DataRowState.Unchanged) continue;
                        if (rVar.RowState == DataRowState.Added) {
                             object Idinvkind = rVar["idinvkind", DataRowVersion.Default];
                            if (Idinvkind != DBNull.Value) {
                                mostraMessScrittureEP = true;
                            }
                        }
                        if (rVar.RowState == DataRowState.Modified){
                            object oldIdinvkind_main = rVar["idinvkind", DataRowVersion.Original];
                            object newIdinvkind_main = rVar["idinvkind", DataRowVersion.Current];
                            if (oldIdinvkind_main != newIdinvkind_main) {
                                mostraMessScrittureEP = true;
                            }
                        }
                    }
                    if (mostraMessScrittureEP) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("E'necessario rigenerare le scritture EP della Nota di Credito.", "Conferma", MessageBoxButtons.OK);
                        mostraMessScrittureEP = false;
                    }

                    if (CurrLast["kpay"] == DBNull.Value) return;
                    if (CurrLast.RowState != DataRowState.Unchanged) {
                        ricalcolaPaymentBank = true;
                        return;
                    }

                    foreach (DataRow rVar in DS.expensevar.Rows) {
                        if (rVar.RowState == DataRowState.Unchanged) continue;
                        if (rVar.RowState == DataRowState.Modified) {
                            decimal oldImporto = CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Original]);
                            decimal newImporto = CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Current]);
                            if (oldImporto == newImporto) continue;
                        }

                        ricalcolaPaymentBank = true;
                    }

                }
            }

        }




        bool comingFromDelete = false;

        public void MetaData_AfterPost() {
            comingFromDelete = false;
            if (DS.Tables["expense"].Rows.Count == 0) {
                MustRefreshImportoSpesa = false;
                comingFromDelete = true;
                fillPaymentBank();
                return;
            }

            //GeneraAutomatismiAfterPost();
            GeneraAzzeraDisponibilitaFasiPrec();
            fillPaymentBank();
            MustRefreshImportoSpesa = true;
        }

        #endregion

        #region Gestione Movimenti Bancari

        private void fillPaymentBank() {
            if (!ricalcolaPaymentBank) return;
            if (!comingFromDelete) {
                if (DS.expenselast.Rows.Count > 0) {
                    DataRow CurrLast = DS.expenselast.Rows[0];
                    kpay = CfgFn.GetNoNullInt32(CurrLast["kpay"]);
                }
                else
                    kpay = 0;
            }

            Meta.Conn.CallSP("compute_payment_bank", new object[] {kpay});
        }

        private void fillMovBankAutomatismi(DataTable table, string tablename) {
            if (table.Rows.Count == 0) return;
            string kfield = (tablename == "payment") ? "kpay" : "kpro";
            foreach (DataRow rDoc in table.Rows) {
                int k = CfgFn.GetNoNullInt32(rDoc[kfield]);
                Meta.Conn.CallSP("compute_" + tablename + "_bank", new object[] {k});
            }
        }

        #endregion

        #region AfterRowSelect

        public void MetaData_BeforeRowSelect(DataTable T, DataRow R) {
            if (MustClose) return;
            if (!Meta.DrawStateIsDone) return;
            if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
                if (R != null) {
                    string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
                    DS.expensesorted.ExtendedProperties["CustomParentRelation"] = f;
                }
            }

            if (Meta.IsEmpty) return;
            if (Meta.DrawStateIsDone && T.TableName == "finview" && R != null) {
                SetUPB(R["idupb"]);
            }

            if (!faseMaxInclusa()) return;
            if (T.TableName == "registrypaymethod") {
                DataRow CurrLast = DS.expenselast.Rows[0];
                CurrLast["idregistrypaymethod"] = R["idregistrypaymethod"];
            }


        }


        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (MustClose) return;

            if (T.TableName == "expensephase") {
                if (!Meta.DrawStateIsDone) return;
                CambiaFase();
                return;
            }

            if (((T.TableName == "mandatedetail_taxable") || (T.TableName == "mandatedetail_iva")) &&
                Meta.DrawStateIsDone) {
                if ((T.TableName == "mandatedetail_taxable") && (CurrCausaleOrdine == 1)) {
                    if (R != null) R["idexp_iva"] = R["idexp_taxable"];
                }

                CalcolaImportoInBaseADettagliOrdine();
            }


            if (T.TableName == "mandate" && Meta.DrawStateIsDone) {
                DS.mandatedetail_iva.Clear();
                DS.mandatedetail_taxable.Clear();
                CalcTotMandateDetail();
                if (R == null) {
                    btnAddDetMandate.Enabled = false;
                    btnRemoveDetMandate.Enabled = false;
                    btnEditMandDet.Enabled = false;
                }
                else {
                    btnAddDetMandate.Enabled = true;
                    btnRemoveDetMandate.Enabled = true;
                    btnEditMandDet.Enabled = true;
                }
            }


            if (((T.TableName == "invoicedetail_taxable") || (T.TableName == "invoicedetail_iva")) &&
                Meta.DrawStateIsDone) {
                if ((T.TableName == "invoicedetail_taxable") && (CurrCausaleIva == 1)) {
                    if (R != null) R["idexp_iva"] = R["idexp_taxable"];
                }

                CalcolaImportoInBaseADettagliFattura();
            }

            if (T.TableName == "invoice" && Meta.DrawStateIsDone) {
                DS.invoicedetail_iva.Clear();
                DS.invoicedetail_taxable.Clear();
                CalcTotInvoiceDetail();
                if (R == null) {
                    btnAddDettInvoice.Enabled = false;
                    btnRemoveDettInvoice.Enabled = false;
                    btnEditInvDet.Enabled = false;
                }
                else {
                    btnAddDettInvoice.Enabled = true;
                    btnRemoveDettInvoice.Enabled = true;
                    btnEditInvDet.Enabled = true;
                }
            }


            if (T.TableName == "service") {
                if (Meta.DrawStateIsDone) {
                    if (!Meta.IsEmpty) {
                        foreach (DataRow RRR in DS.expensetax.Select()) {
                            RRR.Delete();
                        }

                        ;
                        popolaUfficiale();
                        RefreshTabPrestazione();
                    }
                }

                if (currphase != fasespesamax) {
                    ShowHidePrestazioniAggiuntive(false);
                    //btnCalcoloGuidato.Enabled=false;
                    //btnPrestazione.Enabled=false;
                    btnInserisciRitenute.Enabled = false;
                    btnModificaRitenute.Enabled = false;
                    btnEliminaRitenute.Enabled = false;

                    btnInserisciCorrezione.Enabled = false;
                    btnModificaCorrezione.Enabled = false;
                    btnEliminaCorrezione.Enabled = false;

                    btnInserisciUfficiale.Enabled = false;
                    btnModificaUfficiale.Enabled = false;
                    btnEliminaUfficiale.Enabled = false;

                    return;
                }
                else {
                    object idSer = (R == null) ? DBNull.Value : R["idser"];
                    DS.expensetax.ExtendedProperties[MetaData.ExtraParams] = idSer;
                    DS.expensetaxcorrige.ExtendedProperties[MetaData.ExtraParams] = idSer;
                    if (Meta.DrawStateIsDone) {
                        VerificaPrestazioneGenerica();
                    }
                }

                if (faseMaxInclusa()) {
                    impostaFormRitenuteReadOnly();
                    impostaFormStorniReadOnly();
                    impostaFormUfficialeReadOnly();
                }

                if (R != null) {
                    bool enableRit = faseMaxInclusa(); // && ModificaRitenuteAbilitata();
                    bool enableCor = faseMaxInclusa(); // && ModificaStorniAbilitata();
                    bool enableUff = faseMaxInclusa(); // && ModificaUfficialeAbilitata();
                    //btnCalcoloGuidato.Enabled=enable;
                    //btnPrestazione.Enabled=enable;
                    btnInserisciRitenute.Enabled = enableRit;
                    btnModificaRitenute.Enabled = enableRit;
                    btnEliminaRitenute.Enabled = enableRit;

                    btnInserisciCorrezione.Enabled = enableCor;
                    btnModificaCorrezione.Enabled = enableCor;
                    btnEliminaCorrezione.Enabled = enableCor;

                    btnInserisciUfficiale.Enabled = enableUff;
                    btnModificaUfficiale.Enabled = enableUff;
                    btnEliminaUfficiale.Enabled = enableUff;

                    VisualizzaPrestazioniAggiuntive(R);
                }
                else {
                    bool enableRit = faseMaxInclusa(); // && ModificaRitenuteAbilitata();
                    bool enableCor = faseMaxInclusa(); // && ModificaStorniAbilitata();
                    bool enableUff = faseMaxInclusa(); // && ModificaUfficialeAbilitata();
                    //btnCalcoloGuidato.Enabled=enable;
                    //btnPrestazione.Enabled=enable;
                    btnInserisciRitenute.Enabled = enableRit;
                    btnModificaRitenute.Enabled = enableRit;
                    btnEliminaRitenute.Enabled = enableRit;

                    btnInserisciCorrezione.Enabled = enableCor;
                    btnModificaCorrezione.Enabled = enableCor;
                    btnEliminaCorrezione.Enabled = enableCor;

                    btnInserisciUfficiale.Enabled = enableUff;
                    btnModificaUfficiale.Enabled = enableUff;
                    btnEliminaUfficiale.Enabled = enableUff;

                    ShowHidePrestazioniAggiuntive(false);
                }

                return;
            }

            if (T.TableName == "registry") {
                if (!Meta.DrawStateIsDone) return;
                ResetTipoClassAvailableEvalued();
                if (!faseMaxInclusa()) return;
                SetModPagamentoDetails(null);
                if (R == null)
                    CalcolaValoriDefaultModPagamento(null);
                else
                    CalcolaValoriDefaultModPagamento(R["idreg"]);
                SetComboCreditoreDebitore();
                GeneraSelect(txtCredDeb);
                return;
            }

            if (T.TableName == "bill") {
                if (R != null) ManageBollettaChange(R);
            }

            if (T.TableName == "upb") {
                if (Meta.DrawStateIsDone) {
                    ImpostaBilancioperMonofase();// task 16413
                    ResetTipoClassAvailableEvalued();
                    AggiornaBilancioResponsabile(R);
                }

                string idupb = GetDefaultForUpb();
                if (R != null) {
                    idupb = R["idupb"].ToString();
                    SetUPB(idupb);
                }

                MetaData.AutoInfo AI;
                AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
                string filter = "(idupb='" + idupb + "')";
                if (AI != null) AI.startfilter = filter;
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                
            }

            if (T.TableName == "finview") {
                ResetTipoClassAvailableEvalued();
                //if (R!=null){
                //    HelpForm.SetComboBoxValue(SubEntity_comboUPB,R["idupb"].ToString());
                //}
                if ((Meta.InsertMode || Meta.EditMode) && (R != null)) {
                    object oldIdMan = GetResponsabile();
                    if ((R["idman"] != DBNull.Value) &&
                        ((oldIdMan == DBNull.Value) ||
                         ((oldIdMan != DBNull.Value) &&
                          (oldIdMan.ToString() != R["idman"].ToString())
                         )
                        )
                    ) {
                        if ((oldIdMan == DBNull.Value) ||
                            show("Cambio il responsabile in base alla voce di bilancio selezionata?",
                                "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                            SetResponsabile(R["idman"]);
                        }
                    }
                }

                if (R != null && Meta.DrawStateIsDone && EsistonoFinanziamenti()) {
                    DetectFinanziamento(R["idfin"], R["idupb"]);
                }
            }

            if (T.TableName == "registrypaymethod") {
                if (!Meta.DrawStateIsDone) return;
                ManageModPagamentoCredDebiRowChange(R);
                return;
            }

            if ((T.TableName == "sortingkind") && Meta.DrawStateIsDone) {
                ManageClassificazioni.ManageTipoClassMovimentiRowChanged(
                    GetImportoPerClassificazione(), R);
                return;
            }
        }

        void SetResponsabile(object idman) {
            Meta.SetAutoField(idman, txtResponsabile);
        }

        void SetUPB(object idupb) {
            Meta.SetAutoField(idupb, txtUPB);
        }

        object GetResponsabile() {
            return Meta.GetAutoField(txtResponsabile);
        }

        object GetUpb() {
            return Meta.GetAutoField(txtUPB);
        }


        void ManageBollettaChange(DataRow Bolletta) {
            if (Meta.IsEmpty) return;
            if (txtDescrizione.Text != "") {
                if (show("Aggiorno il campo descrizione in base alla Bolletta selezionata?",
                        "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    txtDescrizione.Text = Bolletta["motive"].ToString();
            }

            if (txtDescrizione.Text == "") txtDescrizione.Text = Bolletta["motive"].ToString();
            //if (SubEntity_txtImportoMovimento.Text==""){
            bool avvisare = (SubEntity_txtImportoMovimento.Text != "");
            decimal impcorrente = CfgFn.GetNoNullDecimal(
                HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text,
                    "x.y.c"));

            string filter = QueryCreator.WHERE_KEY_CLAUSE(Bolletta, DataRowVersion.Default, true);
            filter = GetData.MergeFilters(filter,
                "(billkind='D')and(ybill='" + Meta.GetSys("esercizio").ToString() + "')");
            object imp = Meta.Conn.DO_READ_VALUE("billview", filter,
                "isnull(total,0)-isnull(reduction,0)-isnull(covered,0)");

            decimal importo = CfgFn.GetNoNullDecimal(imp);
            decimal variazioni = MetaData.SumColumn(DS.expensevar, "amount");
            importo = importo - variazioni;
            if (importo < 0) importo = 0;
            if (importo < impcorrente || impcorrente == 0) {
                SetImporto(importo);
                SubEntity_txtImportoMovimento.Text = importo.ToString("c");
                if (avvisare) {
                    show("L'importo del movimento � stato impostato al valore della bolletta", "Avviso");
                }
            }

            //}
        }

        string lastfilterPrev = null;
        DataRow LastPrevRow = null;

        void AggiornaBilancioResponsabile(DataRow UPB) {
            if (UPB == null) return;
            if (Meta.IsEmpty) return;
            int fasebilancio = ManageBilAnnuale.faseattivazione;
            if (fasebilancio > currphase) return;

            DataRow CurrExp = DS.expense.Rows[0];
            DataRow Curr = DS.expenseyear.Rows[0];
            if (UPB["idman"] != DBNull.Value) {
                CurrExp["idman"] = UPB["idman"];
                SetResponsabile(CurrExp["idman"]);
            }

            if (fasebilancio < currphase) {
                //Se � gi� presente una voce di bilancio tramite  una fase precedente,
                //  allora non modifica il bilancio
                if (Curr["idupb"] != DBNull.Value) return;
            }


            string filterprevU = "(F.ayear=" +
                                 QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")" +
                                 "AND( (F.flag & 1)=1)";
            //(U.idfin like '" + Meta.GetSys("esercizio").ToString().Substring(2) + "S%')";
            string filterupbU = "(U.idupb = " + QueryCreator.quotedstrvalue(UPB["idupb"], true) + ")";
            string filterupb = "(idupb = " + QueryCreator.quotedstrvalue(UPB["idupb"], true) + ")";
            filterprevU = GetData.MergeFilters(filterprevU, filterupbU);

            if (Meta.InsertMode) {
                object OX = HelpForm.GetObjectFromString(typeof(decimal),
                    SubEntity_txtImportoMovimento.Text, "x.y.c");
                if (OX != DBNull.Value) {
                    decimal X = CfgFn.GetNoNullDecimal(OX);
                    filterprevU = GetData.MergeFilters(filterprevU,
                        //"(  (isnull(currentprev,0)+isnull(previsionvariation,0))>=" +
                        "(  (isnull(availableprevision,0))>=" +
                        QueryCreator.quotedstrvalue(X, true) + ")");
                }
            }
            if (filterprevU != lastfilterPrev) {
                if ((Meta.InsertMode) && (monofase)) {
                    //lo fa perch� dopo si salva il filtro...
                    filterprevU = GetData.MergeFilters(filterprevU, "((F.flag & 2) =0)");
                }
                DataTable Previsione =
                    Meta.Conn.SQLRunner("SELECT * from finview U join finusable F on F.idfin= U.idfin where " +
                                        filterprevU, true);
                //Escludo dal comportamento il monofase per il task 16413, perch� abbiamo precedentemente
                // valorizzato per default il bilancio
                if (!monofase) {
                    if (((Previsione == null) || (Previsione.Rows.Count != 1))) {
                        //Valuta se cancellare il capitolo corrente
                        DS.finview.Clear();
                        Curr["idfin"] = DBNull.Value;
                        txtCodiceBilancio.Text = "";
                        txtDenominazioneBilancio.Text = "";
                        lastfilterPrev = filterprevU;
                        LastPrevRow = null;
                        MetaData_AfterRowSelect(DS.finview, null);
                        return;
                    }
                    LastPrevRow = Previsione.Rows[0];
				}
                lastfilterPrev = filterprevU;
            }

            if (LastPrevRow == null) return;
            if (Curr["idfin"].ToString() == LastPrevRow["idfin"].ToString()) return;
            Curr["idfin"] = LastPrevRow["idfin"];
            DS.finview.Clear();
            DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.finview, null,
                "(idfin=" + QueryCreator.quotedstrvalue(Curr["idfin"], true) + ")" +
                "AND" + filterupb,
                null, true);
            if (DS.finview.Rows.Count > 0) {
                DataRow Bil = DS.finview.Rows[0];
                txtCodiceBilancio.Text = Bil["codefin"].ToString();
                txtDenominazioneBilancio.Text = Bil["title"].ToString();
                MetaData_AfterRowSelect(DS.finview, Bil);
            }
            else {
                txtCodiceBilancio.Text = "";
                txtDenominazioneBilancio.Text = "";
                MetaData_AfterRowSelect(DS.finview, null);
            }

        }

        #endregion


        #region Gestione delle classificazioni movimento

        /// <summary>
        /// Azzera i tipoclass / classmovimenti available calcolati
        /// NON Esegue Get / Fill form
        /// </summary>
        void ResetTipoClassAvailableEvalued() {
            if (ManageClassificazioni != null) ManageClassificazioni.Clear();
        }


        private void tabClassSup_Enter(object sender, System.EventArgs e) {
            if (InsideAdRemoveTabs) return;
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (InsideAdRemoveTabs) return;
            if (tabControl1.SelectedTab == tabClassSup) {
                ManageClassificazioni.EnterTabClassificazioni(currphase, currphase);
            }
        }

        private void btnInsertClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (classEnabled) {
                classEnabled = false;
                ManageClassificazioni.btnInsertClass_Click(currphase, currphase, GetImportoPerClassificazione());
                classEnabled = true;
            }
        }

        private void btnDelClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (classEnabled) {
                classEnabled = false;
                ManageClassificazioni.btnDelClass_Click(GetImportoPerClassificazione());
                classEnabled = true;
            }
        }

        private void btnEditClass_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (classEnabled) {
                classEnabled = false;
                ManageClassificazioni.btnEditClass_Click(currphase, currphase, GetImportoPerClassificazione());
                classEnabled = true;
            }
        }

        private void DGridDettagliClassificazioni_DoubleClick(object sender, System.EventArgs e) {
            btnEditClass_Click(null, null);
        }



        #endregion

        private void btnSituazioneMovimentoSpesa_Click(object sender, System.EventArgs e) {
            string idspesa;
            DataAccess Conn = MetaData.GetConnection(this);
            try {
                DataRow MyRow = HelpForm.GetLastSelected(DS.expense);
                idspesa = MyRow["idexp"].ToString();
            }
            catch {
                return;
            }

            DataSet Out = Meta.Conn.CallSP("show_expense",
                new Object[3] {
                    idspesa,
                    Meta.GetSys("esercizio").ToString(),
                    Meta.GetSys("datacontabile")
                }
            );
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione movimento di spesa";
            frmSituazioneViewer View = new frmSituazioneViewer(Out);
            createForm(View, null);
            View.Show();
        }


        #region Gestione Get/Set Importo

        /// <summary>
        /// Restituisce l'importo "esercizio" da utilizzare come base di calcolo per le
        ///  prestazioni, ritenute, automatismi, classificazioni etc.
        /// </summary>
        /// <returns></returns>
        decimal GetImporto() {
            DataRow R = DS.expenseyear.Rows[0];
            if (R["amount"] == DBNull.Value) return 0;
            return Convert.ToDecimal(R["amount"]);
        }

        /// <summary>
        /// Imposta l'importo "esercizio"
        /// </summary>
        /// <param name="Importo"></param>
        void SetImporto(decimal Importo) {
            DataRow R = DS.expenseyear.Rows[0];
            R["amount"] = Importo;
            SubEntity_txtImportoMovimento.Text = HelpForm.StringValue(
                Importo, "x.y.c");
            MetaData_AfterGetFormData();
            ResetTipoClassAvailableEvalued();
            UpdateImportoDependencies();
        }

        /// <summary>
        /// Metodo che allinea l'importo delle classificazioni all'importo del movimento di spesa (comrpensivo di variazioni)
        /// </summary>
        private void allineaClassificazioniAdImportoMovimento() {
            if ((Meta.IsEmpty) || (Meta.InsertMode)) return;

            if (DS.expense.Rows.Count == 0) return;
            DataRow imputazioneRow = DS.expenseyear.Rows[0];
            decimal importoOriginale = 0;
            decimal importoCorrente = 0;
            // Se sono in InsertMode: l'importo originale ed il corrente sono uguali e, non esistono variazioni
            //			if (Meta.InsertMode) {
            //				importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount"]);//Default version
            //				importoCorrente = importoOriginale;
            //			}
            // Se non sono in InsertMode: l'importo originale � dato dall'importo (stato ORIGINAL) presente in expenseyear
            // + la somma delle variazioni di spesa presenti all'inizio (quelle unchanged, modified e deleted)
            // con versione ORIGINAL, mentre l'importo corrente � dato dall'importo (stato CURRENT) presente in expenseyear
            // + la somma delle variazioni di spesa presenti attualmente (quelle unchanged, modified e inserted)
            // con versione DEFAULT
            //			else {
            importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Original]);
            foreach (DataRow rVar in DS.expensevar.Rows) {
                if (rVar.RowState == DataRowState.Added) continue;
                importoOriginale += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Original]);
            }

            importoCorrente = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Current]);
            foreach (DataRow rVar in DS.expensevar.Select()) {
                importoCorrente += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Default]);
            }

            //			}
            decimal importoOriginaleClass = 0;
            decimal importoCorrenteClass = 0;
            foreach (DataRow rClass in DS.expensesorted.Select()) {
                if (rClass.RowState == DataRowState.Added) {
                    importoOriginaleClass = CfgFn.GetNoNullDecimal(rClass["amount", DataRowVersion.Default]);
                    importoCorrenteClass = importoOriginaleClass;
                }
                else {
                    importoOriginaleClass = CfgFn.GetNoNullDecimal(rClass["amount", DataRowVersion.Original]);
                    importoCorrenteClass = CfgFn.GetNoNullDecimal(rClass["amount", DataRowVersion.Default]);
                }

                if (importoOriginale == importoOriginaleClass) {
                    importoCorrenteClass = importoCorrente;
                    rClass["amount"] = importoCorrente;
                }
            }
        }

        /// <summary>
        /// Restituisce l'importo "esercizio" uguale a imputazionespesa.importo+variazioni
        /// </summary>
        /// <returns></returns>
        decimal GetImportoPerClassificazione() {
            if (DS.expenseyear.Rows.Count == 0) {
                show("Il movimento non ha imputazione nell'anno corrente. Si prega di chiudere la maschera.", "Errore");
                Meta.ErroreIrrecuperabile = true;
                return 0;
            }
            DataRow R = DS.expenseyear.Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
            decimal variazione = MetaData.SumColumn(DS.expensevar, "amount");
            return importo + variazione;
        }

        void UpdateImportoDependencies() {
            allineaClassificazioniAdImportoMovimento();
            ManageClassificazioni.RefillDettagliClassificazioni(
                GetImportoPerClassificazione());
            RicalcolaPrestazioneMissione();
            RicalcolaPrestazioneCedolino();
            RicalcolaPrestazioneOccasionale();
            RicalcolaPrestazioneProfessionale();
            RicalcolaPrestazioneDipendente();

        }

        private void SubEntity_txtImportoMovimento_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (SubEntity_txtImportoMovimento.ReadOnly) return;
            Meta.GetFormData(true);
            UpdateImportoDependencies();
        }

        #endregion


        #region Gestione Ritenute (TAB PRESTAZIONI)

        void RicalcolaPrestazioneMissione() {
            // 17.11.2005 - Rusciano G. - Le ritenute delle missioni avranno sempre un solo scaglione in quanto si applica l'aliquota marginale,
            // in base alla posizione giuridica del percipiente.
            if (Meta.IsEmpty) return;

            RintracciaMissione();

            // Se sono presenti in expensetax ritenute liquidate non si possono pi� modificare!
            if (DS.expensetax.Select("(ytaxpay is not null)").Length > 0) {
                return;
            }

            if ((MissionLinked == null) || (!Meta.InsertMode)) {
                RefreshTabPrestazione();
                return;
            }

            if (!faseMaxInclusa()) {
                //Non calcola ritenute se non � la fase finale
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }


            if ((MissionLinked == null) || (MissioneMovSpesaLinked == null) ||
                (MissioneMovSpesaLinked["movkind"].ToString() != "4")) { //Se non � saldo
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                //Prende almeno il conto di debito
                if (DS.expenselast.Rows.Count > 0 && MissionLinked != null) {
                    object idacc = DBNull.Value;
                    EP_functions EP = new EP_functions(Meta.Dispatcher);

                    DataRow curr = DS.expense.Rows[0];
                    DataRow currlast = DS.expenselast.Rows[0];
                    object idaccmotive = MissionLinked["idaccmotivedebit_crg"];
                    if (idaccmotive == DBNull.Value) idaccmotive = MissionLinked["idaccmotivedebit"];

                    if (EP.attivo) {
                        idacc = EP.GetSupplierAccountForRegistry(idaccmotive, curr["idreg"]);
                        currlast["idaccdebit"] = idacc;
                    }

                    if (idacc != DBNull.Value) {
                        if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                            DS.account.Clear();
                            Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                            if (DS.account.Rows.Count > 0) {
                                DataRow Acc = DS.account.Rows[0];
                                txtCodiceContoSupplier.Text = Acc["codeacc"].ToString();
                                txtDescrContoSupplier.Text = Acc["title"].ToString();
                            }
                        }
                    }
                }

                return;
            }

            AssegnaCampiPrestazione(MissionLinked);
            CalcolaContabilizzatiMissione(MissionLinked);

            if (Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
            }

            DataRow Curr = DS.expense.Rows[0];
            string filterprestazione = QHS.CmpKey(MissionLinked);
            DataTable RitenScagl = MyConn.RUN_SELECT("itinerationtax", "*", null, filterprestazione, null, null, true);

            //Importo lordo missione = Tot Lordo della MISSIONE
            decimal importolordomissione = CfgFn.GetNoNullDecimal(MissionLinked["totalgross"]);
            decimal TOTALE = importolordomissione;
            decimal CONTABILIZZATO = CalcContab(MissionLinked); //Non include quanto contabilizzato su anticipi

            decimal IMPORTO = GetImportoPerClassificazione() - VariazioniPerRitenute();
            decimal RESIDUO = importolordomissione - contabilizzato_ANPAG;
            ArrayList codiciRitenuta = new ArrayList();
            foreach (DataRow R in RitenScagl.Rows) {
                if (!codiciRitenuta.Contains(R["taxcode"])) {
                    codiciRitenuta.Add(R["taxcode"]);
                }
            }

            if (IMPORTO == RESIDUO) { //{
                //Calcola gli importi delle ritenute come differenze rispetto alle
                // ritenute in missioneritenute e quelle in dettaglioritenute
                foreach (object codiceRitenuta in codiciRitenuta) {
                    string filtertaxcode = QHC.CmpEq("taxcode", codiceRitenuta);

                    decimal assignedimponibilelordo = 0;
                    decimal assigneddeduzioni = 0;
                    decimal assigneddetrazioni = 0;
                    CalcolaTotaliAssegnati(MissionLinked, codiceRitenuta,
                        out assignedimponibilelordo, out assigneddeduzioni, out assigneddetrazioni);

                    decimal detrazioni = 0;
                    detrazioni -= assigneddetrazioni;
                    foreach (DataRow MisRit in RitenScagl.Select(filtertaxcode)) {
                        bool ultimoScaglione = true;
                        decimal imponibilenetto = CfgFn.GetNoNullDecimal(MisRit["taxable"]);
                        decimal ritdipendente = CfgFn.GetNoNullDecimal(MisRit["employtax"]);
                        decimal ritamministrazione = CfgFn.GetNoNullDecimal(MisRit["admintax"]);

                        decimal assignedimponibilenetto = 0;
                        decimal assignedritdipendente = 0;
                        decimal assignedritamministrazione = 0;
                        CalcolaTotaliAssegnatiScaglione(MissionLinked, MisRit,
                            out assignedimponibilenetto, out assignedritdipendente, out assignedritamministrazione);

                        decimal detrazioniScaglione;
                        if (ultimoScaglione) {
                            detrazioniScaglione = detrazioni;
                        }
                        else {
                            detrazioniScaglione = (detrazioni <= ritdipendente) ? detrazioni : ritdipendente;
                        }

                        detrazioni -= detrazioniScaglione;
                        ritdipendente -= detrazioniScaglione;


                        decimal resid_imponibilenetto = imponibilenetto - assignedimponibilenetto;
                        decimal resid_ritdip = ritdipendente - assignedritdipendente;
                        decimal resid_ritamm = ritamministrazione - assignedritamministrazione;

                        MisRit["taxable"] = resid_imponibilenetto;
                        MisRit["employtax"] = resid_ritdip;
                        MisRit["admintax"] = resid_ritamm;
                    }
                }
            }
            else {
                //Calcola gli importi assumendo come imponibile (IMPORTO/RESIDUO)*IMPORTOLORDOMISSIONE.
                //Poich� quelle in missioneritenute hanno come imponibile IMPORTOLORDOMISSIONE,
                // la proporzione applicata � (IMPORTO/RESIDUO)
                decimal proporzione = (TOTALE - contabilizzato_ANPAG == 0)
                    ? 0
                    : (IMPORTO / (TOTALE - contabilizzato_ANPAG));
                foreach (DataRow MissRit in RitenScagl.Select()) {
                    decimal imponibilenetto = CfgFn.GetNoNullDecimal(MissRit["taxable"]);
                    decimal ritdipendente = CfgFn.GetNoNullDecimal(MissRit["employtax"]);
                    decimal ritamministrazione = CfgFn.GetNoNullDecimal(MissRit["admintax"]);

                    MissRit["taxable"] = CfgFn.RoundValuta(imponibilenetto * proporzione);
                    MissRit["employtax"] = CfgFn.RoundValuta(ritdipendente * proporzione);
                    MissRit["admintax"] = CfgFn.RoundValuta(ritamministrazione * proporzione);
                }
            }

            //Cancella le vecchie ritenute
            // J.T.R. 30.06.2008 Siamo solo in InsertMode non serve pi�, facciamo solo il Clear
            //DS.expensetax.RejectChanges();//now all rows in dettaglioritenute are back again!
            //ClearRitenute(DS.expensetax);
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();


            //Aggiunge le nuove ritenute
            MetaData MetaRiten = MetaData.GetMetaData(this, "expensetax");
            MetaRiten.SetDefaults(DS.expensetax);
            foreach (DataRow R in RitenScagl.Rows) {
                //17.11.2005 - if (CfgFn.GetNoNullDecimal(R["taxable"])==0) continue;
                if (CfgFn.GetNoNullDecimal(R["taxable"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["employtax"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["admintax"]) == 0
                ) continue;
                //string filter = GetFilterRit(R);
                //DataRow newR;
                //DataRow []found = DS.expensetax.Select(filter);
                //if (found.Length>0)
                //    newR= found[0];	 //takes existent!!
                //else {
                MetaData.SetDefault(DS.expensetax, "taxcode", R["taxcode"]);
                DataRow newR = MetaRiten.Get_New_Row(Curr, DS.expensetax);
                //}
                foreach (string colname in new string[] {
                    "taxablenumerator", "taxabledenominator",
                    "employrate", "employnumerator", "employdenominator",
                    "adminrate", "adminnumerator", "admindenominator",
                    "employtax", "admintax"
                }) {
                    newR[colname] = R[colname];
                }

                newR["taxablegross"] = R["taxable"];
                newR["exemptionquota"] = 0;
                newR["taxablenet"] = R["taxable"];
                newR["abatements"] = DBNull.Value;
                newR["competencydate"] = MissionLinked["start"];
                newR["!descrizione"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", R["taxcode"]));
                newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", R["taxcode"]));
            }

            DeleteRitenute(DS.expensetax);

            popolaUfficiale();

            RefreshTabPrestazione();
            //Meta.FreshForm(true);
        }


        void AssegnaCampiPrestazione(DataRow Prestazione) {
            if (DS.expenselast.Rows.Count == 0) return;
            DataRow curr = DS.expense.Rows[0];
            DataRow currlast = DS.expenselast.Rows[0];
            currlast["servicestart"] = Prestazione["start"];
            SubEntity_txtDataInizioPrest.Text = HelpForm.StringValue(Prestazione["start"],
                SubEntity_txtDataInizioPrest.Tag.ToString());
            currlast["servicestop"] = Prestazione["stop"];
            SubEntity_txtDataFinePrest.Text = HelpForm.StringValue(Prestazione["stop"],
                SubEntity_txtDataFinePrest.Tag.ToString());

            EP_functions EP = new EP_functions(Meta.Dispatcher);

            object codiceprest = DBNull.Value;
            object idaccmotive = DBNull.Value;
            object idacc = DBNull.Value;
            if (Prestazione.Table.Columns.Contains("idser")) codiceprest = Prestazione["idser"];
            if (Prestazione.Table.TableName == "payroll") {
                codiceprest = Meta.Conn.DO_READ_VALUE("parasubcontract", "(idcon=" +
                                                                         QueryCreator.quotedstrvalue(
                                                                             Prestazione["idcon"], true) + ")",
                    "idser");

                if (EP.attivo) {
                    idaccmotive = Meta.Conn.DO_READ_VALUE("parasubcontract", "(idcon=" +
                                                                             QueryCreator.quotedstrvalue(
                                                                                 Prestazione["idcon"], true) + ")",
                        "isnull(idaccmotivedebit_crg,idaccmotivedebit)");
                }
            }
            else {
                idaccmotive = Prestazione["idaccmotivedebit_crg"];
                if (idaccmotive == DBNull.Value) idaccmotive = Prestazione["idaccmotivedebit"];
            }

            if (EP.attivo) {
                idacc = EP.GetSupplierAccountForRegistry(idaccmotive, curr["idreg"]);
            }

            currlast["idser"] = codiceprest;
            currlast["idaccdebit"] = idacc;
            if (idacc != DBNull.Value) {
                if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                    DS.account.Clear();
                    Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                    if (DS.account.Rows.Count > 0) {
                        DataRow Acc = DS.account.Rows[0];
                        txtCodiceContoSupplier.Text = Acc["codeacc"].ToString();
                        txtDescrContoSupplier.Text = Acc["title"].ToString();
                    }
                }
            }

            UnfilterPrestazione();
            HelpForm.SetComboBoxValue(SubEntity_cmbTipoprestazione, codiceprest);

        }

        void RicalcolaPrestazioneCedolino() {
            if (Meta.IsEmpty) return;

            RintracciaCedolino();

            // Se sono presenti in expensetax ritenute liquidate non si possono pi� modificare!
            if (DS.expensetax.Select("(ytaxpay is not null)").Length > 0) {
                return;
            }

            if ((CedolinoLinked == null) || (!Meta.InsertMode)) {
                RefreshTabPrestazione();
                return;
            }

            if (!faseMaxInclusa()) {
                //Non calcola ritenute se non � la fase finale
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            if ((CedolinoLinked == null) || (CedolinoMovSpesaLinked == null)) {
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            AssegnaCampiPrestazione(CedolinoLinked);
            CalcolaContabilizzatiCedolino(CedolinoLinked);

            if (Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
            }

            DataRow Curr = DS.expense.Rows[0];
            string filterprestazione = QueryCreator.WHERE_KEY_CLAUSE(CedolinoLinked, DataRowVersion.Default, true);
            DataTable RitenScagl =
                MyConn.RUN_SELECT("payrolltaxbracketview", "*", null, filterprestazione, null, null, true);

            //Importo lordo missione = Tot Lordo del Cedolino
            decimal importolordomissione = CfgFn.GetNoNullDecimal(CedolinoLinked["feegross"]); //imponibilelordo

            decimal TOTALE = importolordomissione;
            decimal CONTABILIZZATO = CalcContab(CedolinoLinked);

            decimal IMPORTO = GetImportoPerClassificazione() - VariazioniPerRitenute();
            decimal RESIDUO = TOTALE - CONTABILIZZATO;

            ArrayList codiciRitenuta = new ArrayList();
            foreach (DataRow R in RitenScagl.Rows) {
                if (!codiciRitenuta.Contains(R["taxcode"])) {
                    codiciRitenuta.Add(R["taxcode"]);
                }
            }

            if (IMPORTO == RESIDUO) { //{
                //Calcola gli importi delle ritenute come differenze rispetto alle
                // ritenute in missioneritenute e quelle in dettaglioritenute
                foreach (object codiceRitenuta in codiciRitenuta) {
                    string filtertaxcode = QHC.CmpEq("taxcode", codiceRitenuta);
                    decimal assignedimponibilelordo = 0;
                    decimal assigneddeduzioni = 0;
                    decimal assigneddetrazioni = 0;
                    CalcolaTotaliAssegnati(CedolinoLinked, codiceRitenuta,
                        out assignedimponibilelordo, out assigneddeduzioni, out assigneddetrazioni);

                    string filtroCedolino = QHS.AppAnd(filtertaxcode, filterprestazione);
                    decimal detrazioni = CfgFn.GetNoNullDecimal(
                        MyConn.DO_READ_VALUE("payrolltaxview", filtroCedolino,
                            "ISNULL(SUM(abatements),0.0) + ISNULL(SUM(annualpayedemploytax),0.0)"));
                    detrazioni -= assigneddetrazioni;
                    int nCiclo = 1;
                    int nScaglioni = RitenScagl.Select(filtertaxcode, "nbracket").Length;

                    foreach (DataRow CedRitScagl in RitenScagl.Select(filtertaxcode, "nbracket")) {
                        bool ultimoScaglione = (nCiclo == nScaglioni);
                        decimal imponibilenetto = CfgFn.GetNoNullDecimal(CedRitScagl["taxablenet"]);
                        decimal ritdipendente = CfgFn.GetNoNullDecimal(CedRitScagl["employtax"]);
                        decimal ritamministrazione = CfgFn.GetNoNullDecimal(CedRitScagl["admintax"]);

                        decimal assignedimponibilenetto = 0;
                        decimal assignedritdipendente = 0;
                        decimal assignedritamministrazione = 0;
                        CalcolaTotaliAssegnatiScaglione(CedolinoLinked, CedRitScagl,
                            out assignedimponibilenetto, out assignedritdipendente, out assignedritamministrazione);

                        decimal detrazioniScaglione;
                        if (ultimoScaglione) {
                            detrazioniScaglione = detrazioni;
                        }
                        else {
                            detrazioniScaglione = (detrazioni <= ritdipendente) ? detrazioni : ritdipendente;
                        }

                        detrazioni -= detrazioniScaglione;
                        ritdipendente -= detrazioniScaglione;

                        decimal resid_imponibilenetto = imponibilenetto - assignedimponibilenetto;
                        decimal resid_ritdip = ritdipendente - assignedritdipendente;
                        decimal resid_ritamm = ritamministrazione - assignedritamministrazione;
                        decimal resid_detrazioni = detrazioniScaglione;

                        CedRitScagl["taxablenet"] = resid_imponibilenetto;
                        CedRitScagl["employtax"] = resid_ritdip;
                        CedRitScagl["admintax"] = resid_ritamm;
                        CedRitScagl["abatements"] = resid_detrazioni;

                        nCiclo++;
                    }
                }
            }
            else {
                decimal proporzione = (TOTALE == 0) ? 0 : (IMPORTO / TOTALE);
                foreach (object codiceRitenuta in codiciRitenuta) {
                    string filtertaxcode = QHC.CmpEq("taxcode", codiceRitenuta);
                    string filtroCedolino = QHS.AppAnd(QHS.CmpEq("taxcode", codiceRitenuta), filterprestazione);
                    decimal detrazioni = CfgFn.GetNoNullDecimal(
                        MyConn.DO_READ_VALUE("payrolltaxview", filtroCedolino,
                            "ISNULL(SUM(abatements),0.0) + ISNULL(SUM(annualpayedemploytax),0.0)"));
                    int nCiclo = 1;
                    int nScaglioni = RitenScagl.Select(filtertaxcode, "nbracket").Length;
                    foreach (DataRow CedRitScagl in RitenScagl.Select(filtertaxcode, "nbracket")) {
                        bool ultimoScaglione = (nCiclo == nScaglioni);
                        decimal imponibilenetto = 0;
                        decimal ritdipendente = 0;
                        decimal ritamministrazione = 0;

                        imponibilenetto =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(CedRitScagl["taxablenet"]) * proporzione);
                        ritdipendente =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(CedRitScagl["employtax"]) * proporzione);
                        ritamministrazione =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(CedRitScagl["admintax"]) * proporzione);

                        decimal detrazioniScaglione = 0;
                        if (ultimoScaglione) {
                            detrazioniScaglione = detrazioni;
                        }
                        else {
                            detrazioniScaglione = (detrazioni <= ritdipendente) ? detrazioni : ritdipendente;
                        }

                        detrazioni -= detrazioniScaglione;
                        ritdipendente -= detrazioniScaglione;

                        CedRitScagl["taxablenet"] = imponibilenetto;
                        CedRitScagl["employtax"] = ritdipendente;
                        CedRitScagl["admintax"] = ritamministrazione;
                        CedRitScagl["abatements"] = detrazioniScaglione;
                        nCiclo++;
                    }
                }
            }

            //Cancella le vecchie ritenute
            // J.T.R. 30.06.2008 Siamo solo in InsertMode non serve pi�, facciamo solo il Clear
            //DS.expensetax.RejectChanges();//now all rows in dettaglioritenute are back again!
            //DataRow[] OldList = DS.expensetax.Select();
            //ClearRitenute(DS.expensetax);
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();

            //Aggiunge le nuove ritenute
            MetaData MetaRiten = MetaData.GetMetaData(this, "expensetax");
            MetaRiten.SetDefaults(DS.expensetax);
            foreach (DataRow R in RitenScagl.Rows /*Riten.Rows*/) {
                if ((CfgFn.GetNoNullDecimal(R["taxablegross"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(R["employtax"]) == 0) &&
                    (CfgFn.GetNoNullDecimal(R["admintax"]) == 0)) continue;

                // string filter = GetFilterRit(R);
                //DataRow newR;
                //DataRow []found = DS.expensetax.Select(filter);
                //if (found.Length>0)
                //	newR= found[0];	 //takes existent!!
                //else {
                MetaData.SetDefault(DS.expensetax, "taxcode", R["taxcode"]);
                DataRow newR = MetaRiten.Get_New_Row(Curr, DS.expensetax);
                //}

                // In questo foreach calcolo tutti i campi che devono essere copiati
                // dalla tabella degli scaglioni del contratto occasionale
                foreach (string colname in new string[] {
                    "taxablegross",
                    "taxablenet", "employtax", "admintax",
                    "taxablenumerator", "taxabledenominator", "abatements",
                    "employrate", "employnumerator", "employdenominator",
                    "adminrate", "adminnumerator", "admindenominator",
                    "idcity", "idfiscaltaxregion"
                }) {
                    newR[colname] = R[colname];
                }

                // Assegnazione dei campi il cui valore � uguale a tutti gli scaglioni della ritenuta
                newR["ayear"] = R["fiscalyear"];
                newR["exemptionquota"] = R["deduction"];
                newR["competencydate"] = CedolinoLinked["start"];
                newR["!descrizione"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", R["taxcode"]));
                newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", R["taxcode"]));
            }

            DeleteRitenute(DS.expensetax);

            DataTable tStorno =
                MyConn.RUN_SELECT("payrolltaxcorrigeview", "*", null, filterprestazione, null, null, true);
            bool ricopiaStorni = false;

            if (tStorno.Rows.Count > 0) {
                ricopiaStorni = !esistonoPagamentiDiStorni(CedolinoLinked);
            }

            if (ricopiaStorni) {
                // J.T.R. 30.06.2008 - Stiamo operando solo in insertmode, quindi si procede con un Clear della tabella
                // e poi insert a terremoto
                DS.expensetaxcorrige.Clear();
                //DS.expensetaxcorrige.RejectChanges();
                //DataRow[] OldListCorrige = DS.expensetaxcorrige.Select();
                //ClearStorni(DS.expensetaxcorrige);

                //Aggiunge le nuove ritenute
                MetaData MetaStorno = MetaData.GetMetaData(this, "expensetaxcorrige");
                MetaStorno.SetDefaults(DS.expensetaxcorrige);

                foreach (DataRow rStorno in tStorno.Rows) {
                    MetaData.SetDefault(DS.expensetaxcorrige, "taxcode", rStorno["taxcode"]);
                    DataRow newR = MetaStorno.Get_New_Row(Curr, DS.expensetaxcorrige);

                    foreach (string colname in new string[] {
                        "employamount", "adminamount",
                        "idcity", "idfiscaltaxregion", "ayear"
                    }) {
                        newR[colname] = rStorno[colname];
                    }

                    newR["adate"] = Meta.GetSys("datacontabile");
                    newR["!description"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", rStorno["taxcode"]));
                    newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", rStorno["taxcode"]));

                    popolaGeoCity(rStorno["idcity"]);
                    newR["!city"] = (rStorno["idcity"] != DBNull.Value)
                        ? DS.geo_city.Compute("MIN(title)", QHC.CmpEq("idcity", rStorno["idcity"]))
                        : DBNull.Value;

                    popolaFiscalTaxRegion(rStorno["idfiscaltaxregion"]);
                    newR["!fiscaltaxregion"] = (rStorno["idfiscaltaxregion"] != DBNull.Value)
                        ? DS.fiscaltaxregion.Compute("MIN(title)",
                            QHC.CmpEq("idfiscaltaxregion", rStorno["idfiscaltaxregion"]))
                        : DBNull.Value;
                }

                DeleteStorni(DS.expensetaxcorrige);
            }
            else {
                DS.expensetaxcorrige.Clear();
                //DS.expensetaxcorrige.RejectChanges();
                //ClearStorni(DS.expensetaxcorrige);
                //DeleteStorni(DS.expensetaxcorrige);
            }

            popolaUfficiale();

            RefreshTabPrestazione();
            // Controlla che l'importo netto sia >=0
            object ImportoNetto = HelpForm.GetObjectFromString(typeof(decimal), txtImportonettoDip.Text, "x.y");

            if (CfgFn.GetNoNullDecimal(ImportoNetto) < 0) {
                show(this, "L'importo netto � NEGATIVO!\r" + "ANNULLARE l'operazione e rivedere il Compenso.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Meta.FreshForm(true);
        }

        /// <summary>
        /// Calcola l'importo dei mov. di spesa di ultima fase associati ad una prestazione, escluse le var. per ritenute
        ///  non considera gli anticipi su part.di giro x missioni e i pag. di sola iva x le fatture
        /// </summary>
        /// <param name="Prestazione"></param>
        /// <returns></returns>
        decimal CalcContab(DataRow Prestazione) {

            DataRow Curr = DS.expense.Rows[0];
            string excludecurrent = "";
            if (Meta.EditMode) excludecurrent = QHS.CmpNe("ET.idexp", Curr["idexp"]);

            string filterkey = "";
            foreach (DataColumn K in Prestazione.Table.PrimaryKey) {
                filterkey = QHS.AppAnd(filterkey, QHS.CmpEq("Q." + K.ColumnName, Prestazione[K]));
            }

            string middletable = "expense" + Prestazione.Table.TableName;
            string filter = QHS.AppAnd(excludecurrent, filterkey);
            if (Prestazione.Table.TableName == "profservice") {
                filter = QHS.AppAnd(filter, QHS.CmpNe("Q.movkind", 2));
            }

            if (Prestazione.Table.TableName == "itineration") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("Q.movkind", 4));
            }

            //Calcola somma importi originali
            string query1 = "select sum(amount) from expenseyear ET JOIN " +
                            "   expenselast EL on EL.idexp = ET.idexp JOIN " +
                            "   expenselink ELK on EL.idexp= ELK.idchild JOIN " +
                            middletable + " Q on ELK.idparent = Q.idexp WHERE ";
            object origval = MyConn.DO_SYS_CMD(query1 + filter);

            //Calcola somma importi originali
            string query2 = "select sum(amount) from expensevar ET JOIN " +
                            "   expenselast EL on EL.idexp = ET.idexp JOIN " +
                            "   expenselink ELK on EL.idexp= ELK.idchild JOIN " +
                            middletable + " Q on ELK.idparent = Q.idexp WHERE " +
                            " (ISNULL(ET.autokind,0)<> 4) AND ";
            object variaz = MyConn.DO_SYS_CMD(query2 + filter);
            return CfgFn.GetNoNullDecimal(origval) + CfgFn.GetNoNullDecimal(variaz);

        }

        void CalcolaTotaliAssegnati(DataRow Prestazione,
            object taxcode,
            out decimal assignedimponibilelordo,
            out decimal assigneddeduzioni,
            out decimal assigneddetrazioni) {
            assignedimponibilelordo = 0;
            assigneddeduzioni = 0;
            assigneddetrazioni = 0;
            DataRow Curr = DS.expense.Rows[0];
            string excludecurrent = "";
            if (Meta.EditMode) excludecurrent = QHS.CmpNe("ETAX.idexp", Curr["idexp"]);

            string filterkey = "";
            foreach (DataColumn K in Prestazione.Table.PrimaryKey) {
                filterkey = QHS.AppAnd(filterkey, QHS.CmpEq("Q." + K.ColumnName, Prestazione[K]));
            }

            string filter = QHS.AppAnd(excludecurrent, filterkey);
            filter = QHS.AppAnd(filter, QHS.CmpEq("ETAX.taxcode", taxcode));

            string filterBracket = " nbracket = (select min(nbracket) from expensetax et2 " +
                                   " where et2.taxcode = ETAX.taxcode and et2.idexp = ETAX.idexp)";

            string query = "SELECT SUM(ETAX.taxablegross) AS taxablegross, SUM(ETAX.exemptionquota) AS exemptionquota"
                           + " FROM expensetax ETAX "
                           + " join expenselink ELK on ELK.idchild = ETAX.idexp JOIN "
                           + " expense" + Prestazione.Table.TableName + " Q on ELK.idparent = Q.idexp "
                           + " WHERE " + QHS.AppAnd(filter, filterBracket);

            DataTable sommePagate = MyConn.SQLRunner(query);

            if ((sommePagate != null) && (sommePagate.Rows.Count > 0)) {
                assignedimponibilelordo = CfgFn.GetNoNullDecimal(sommePagate.Rows[0]["taxablegross"]);
                assigneddeduzioni = CfgFn.GetNoNullDecimal(sommePagate.Rows[0]["exemptionquota"]);
            }

            query = "SELECT SUM(ETAX.abatements) FROM expensetax ETAX "
                    + " join expenselink ELK on ELK.idchild = ETAX.idexp "
                    + " join expense" + Prestazione.Table.TableName + " Q on ELK.idparent = Q.idexp "
                    + " WHERE " + filter;
            assigneddetrazioni = CfgFn.GetNoNullDecimal(MyConn.DO_SYS_CMD(query));
        }

        void CalcolaTotaliAssegnatiScaglione(DataRow Prestazione, DataRow ScaglioneRit,
            out decimal imponibilenetto,
            out decimal ritdipendente,
            out decimal ritamministrazione) {
            imponibilenetto = 0;
            ritdipendente = 0;
            ritamministrazione = 0;
            DataRow Curr = DS.expense.Rows[0];
            string excludecurrent = "";
            if (Meta.EditMode) excludecurrent = QHS.CmpNe("ETAX.idexp", Curr["idexp"]);

            string filterkey = "";
            foreach (DataColumn K in Prestazione.Table.PrimaryKey) {
                filterkey = QHS.AppAnd(filterkey, QHS.CmpEq("Q." + K.ColumnName, Prestazione[K]));
            }

            string filter = QHS.AppAnd(excludecurrent, filterkey);
            filter = QHS.AppAnd(filter, QHS.CmpEq("ETAX.taxcode", ScaglioneRit["taxcode"]));

            string filterscaglione = filter;
            if (ScaglioneRit.Table.Columns.Contains("nbracket")) {
                filterscaglione = QHS.AppAnd(filter,
                    QHS.AppAnd(
                        QHS.CmpEq("ISNULL(ETAX.employrate,0)", CfgFn.GetNoNullDecimal(ScaglioneRit["employrate"])),
                        QHS.CmpEq("ISNULL(ETAX.adminrate,0)", CfgFn.GetNoNullDecimal(ScaglioneRit["adminrate"]))));
            }

            string query = "SELECT SUM(ETAX.taxablenet) AS taxablenet, SUM(ETAX.employtax) AS employtax, "
                           + " SUM(ETAX.admintax) AS admintax FROM expensetax ETAX "
                           + " join expenselink ELK on ELK.idchild = ETAX.idexp "
                           + " join expense" + Prestazione.Table.TableName + " Q on ELK.idparent = Q.idexp "
                           + " WHERE " + filterscaglione;
            DataTable sommePagate = MyConn.SQLRunner(query);
            if ((sommePagate != null) && (sommePagate.Rows.Count > 0)) {
                imponibilenetto = CfgFn.GetNoNullDecimal(sommePagate.Rows[0]["taxablenet"]);
                ritdipendente = CfgFn.GetNoNullDecimal(sommePagate.Rows[0]["employtax"]);
                ritamministrazione = CfgFn.GetNoNullDecimal(sommePagate.Rows[0]["admintax"]);
            }


        }


        void RicalcolaPrestazioneOccasionale() {
            if (Meta.IsEmpty) return;

            RintracciaOccasionale();

            // Se sono presenti in expensetax ritenute liquidate non si possono pi� modificare!
            if (DS.expensetax.Select("(ytaxpay is not null)").Length > 0) {
                return;
            }

            if ((OccasionaleLinked == null) || (!Meta.InsertMode)) {
                RefreshTabPrestazione();
                return;
            }

            if (!faseMaxInclusa()) {
                //Non calcola ritenute se non � la fase finale
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            if ((OccasionaleLinked == null) || (OccasionaleMovSpesaLinked == null)
                /*	||	(CedolinoMovSpesaLinked["tipomovimento"].ToString().ToUpper()!=4) */) {
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            AssegnaCampiPrestazione(OccasionaleLinked);
            CalcolaContabilizzatiOccasionale(OccasionaleLinked);

            if (Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
            }

            DataRow Curr = DS.expense.Rows[0];
            string filterprestazione = QHS.CmpKey(OccasionaleLinked);

            //Importo lordo missione = Tot Lordo del Cedolino
            decimal importolordooccasionale = CfgFn.GetNoNullDecimal(OccasionaleLinked["feegross"]); //imponibilelordo
            //RESIDUO = Importo Lordo 
            decimal TOTALE = importolordooccasionale;
            decimal CONTABILIZZATO = CalcContab(OccasionaleLinked);

            decimal contabilizzato_PS = CfgFn.GetNoNullDecimal(
                MyConn.DO_READ_VALUE("pettycashopcasualcontractview", filterprestazione, "SUM(amount)"));


            CONTABILIZZATO = CONTABILIZZATO + contabilizzato_PS;

            decimal IMPORTO = GetImportoPerClassificazione() - VariazioniPerRitenute() + contabilizzato_PS;
            decimal RESIDUO = TOTALE - CONTABILIZZATO;
            ArrayList codiciRitenuta = new ArrayList();

            calcOccasionale mycalc = new calcOccasionale(MyConn, OccasionaleLinked);
            mycalc.GetInfoContratto();
            DataTable Riten = mycalc.calcolaRitenute(IMPORTO);
            if (Riten != null) {
                foreach (DataRow R in Riten.Rows) {
                    if (!codiciRitenuta.Contains(R["taxcode"])) {
                        codiciRitenuta.Add(R["taxcode"]);
                    }
                }
            }

            //Cancella le vecchie ritenute
            // J.T.R. 30.06.2008 Siamo solo in InsertMode non serve pi�, facciamo solo il Clear
            //DS.expensetax.RejectChanges();//now all rows in dettaglioritenute are back again!
            //ClearRitenute(DS.expensetax);
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();

            //Aggiunge le nuove ritenute
            MetaData MetaRiten = MetaData.GetMetaData(this, "expensetax");
            MetaRiten.SetDefaults(DS.expensetax);
            if (Riten != null) {
                foreach (DataRow R in Riten.Rows /*Riten.Rows*/) {
                    MetaData.SetDefault(DS.expensetax, "taxcode", R["taxcode"]);
                    DataRow newR = MetaRiten.Get_New_Row(Curr, DS.expensetax);

                    foreach (string colname in new string[] {
                        "taxablegross", "taxablenet", "employtax", "admintax",
                        "taxablenumerator", "taxabledenominator",
                        "employrate", "employnumerator", "employdenominator",
                        "adminrate", "adminnumerator", "admindenominator"
                    }) {
                        newR[colname] = R[colname];
                    }

                    newR["exemptionquota"] = DBNull.Value;
                    newR["abatements"] = DBNull.Value;
                    newR["competencydate"] = OccasionaleLinked["start"];
                    newR["!descrizione"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", R["taxcode"]));
                    newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", R["taxcode"]));
                }
            }

            DeleteRitenute(DS.expensetax);

            popolaUfficiale();

            RefreshTabPrestazione();
            //Meta.FreshForm(true);
        }

        //string GetFilterRit(DataRow Rit) {
        //    string filter = QHC.CmpEq("taxcode", Rit["taxcode"]);
        //    filter = QHC.AppAnd(filter, QHC.CmpEq("taxablegross", 0));
        //    filter = QHC.AppAnd(filter, QHC.CmpEq("employtax", 0));
        //    filter = QHC.AppAnd(filter, QHC.CmpEq("admintax", 0));
        //    return filter;            
        //}

        void ClearRitenute(DataTable OldRit) {
            foreach (DataRow Rit in OldRit.Select()) {
                Rit["taxablegross"] = 0;
                Rit["employtax"] = 0;
                Rit["admintax"] = 0;
                Rit["taxablenet"] = 0;
                Rit["abatements"] = DBNull.Value;
            }
        }

        void DeleteRitenute(DataTable NewRit) {
            foreach (DataRow Rit in NewRit.Select()) {
                if (CfgFn.GetNoNullDecimal(Rit["taxablegross"]) != 0) continue;
                if (CfgFn.GetNoNullDecimal(Rit["employtax"]) != 0) continue;
                if (CfgFn.GetNoNullDecimal(Rit["admintax"]) != 0) continue;
                Rit.Delete();
            }

        }

        //string GetFilterStorno(DataRow rStorno) {
        //    string filter = QHC.CmpEq("taxcode", rStorno["taxcode"]);
        //    filter = QHC.AppAnd(filter, QHC.CmpEq("employamount", 0));
        //    filter = QHC.AppAnd(filter, QHC.CmpEq("adminamount", 0));
        //    return filter;
        //}

        void ClearStorni(DataTable OldStorno) {
            foreach (DataRow Storno in OldStorno.Select()) {
                Storno["employamount"] = 0;
                Storno["adminamount"] = 0;
                Storno["idcity"] = DBNull.Value;
                Storno["idfiscaltaxregion"] = DBNull.Value;
            }
        }

        void DeleteStorni(DataTable NewStorno) {
            foreach (DataRow Rit in NewStorno.Select()) {
                if (CfgFn.GetNoNullDecimal(Rit["employamount"]) != 0) continue;
                if (CfgFn.GetNoNullDecimal(Rit["adminamount"]) != 0) continue;
                Rit.Delete();
            }

        }

        void ClearUfficiale(DataTable OldUff) {
            foreach (DataRow rUff in OldUff.Select()) {
                rUff["taxablegross"] = 0;
                rUff["employtax"] = 0;
                rUff["admintax"] = 0;
                rUff["taxablenet"] = 0;
                rUff["abatements"] = DBNull.Value;
            }
        }

        void DeleteUfficiale(DataTable NewUff) {
            foreach (DataRow rUff in NewUff.Select()) {
                if (CfgFn.GetNoNullDecimal(rUff["taxablegross"]) != 0) continue;
                if (CfgFn.GetNoNullDecimal(rUff["employtax"]) != 0) continue;
                if (CfgFn.GetNoNullDecimal(rUff["admintax"]) != 0) continue;
                rUff.Delete();
            }
        }

        private void popolaUfficiale() {
            // Le situazioni che possono verificarsi sono:
            // 1. Zero righe per un determinato taxcode ==> Viene aggiunta la riga
            // 2. Una riga per un determinato taxcode ==> Si confrontano i campi delle ritenute c/dip e c/amm,
            // se almeno uno � diverso, alla riga precedente viene impostata la data di fine (stop) e ne viene creata 
            // una con data inizio (start) pari alla data contabile
            // 3. Pi� righe per lo stesso taxcode ==> Visualizzato messaggio che bisogna modificare a mano le
            // informazioni di quella ritenuta.
            if (!faseMaxInclusa()) return;
            if (!Meta.InsertMode) return;
            if (DS.expense.Rows.Count == 0) return;

            bool dosomething = false;
            foreach (DataRow r in DS.expensetax.Rows) {
                if (r.RowState == DataRowState.Unchanged) continue;
                dosomething = true;
            }

            foreach (DataRow r in DS.expensetaxcorrige.Rows) {
                if (r.RowState == DataRowState.Unchanged) continue;
                dosomething = true;
            }

            if (!dosomething) {
                if (DS.expensetaxcorrige.Rows.Count == 0 && DS.expensetax.Rows.Count == 0) {
                    DS.expensetaxofficial.Clear();
                }

                return;
            }

            DataRow CurrExp = DS.expense.Rows[0];
            MetaData MetaOfficial = MetaData.GetMetaData(this, "expensetaxofficial");

            DS.expensetaxofficial.RejectChanges();

            DataRow[] OldList = DS.expensetaxofficial.Select();
            ClearUfficiale(DS.expensetaxofficial);

            MetaOfficial.SetDefaults(DS.expensetaxofficial);
            foreach (DataRow rET in DS.expensetax.Select()) {
                if (rET.RowState != DataRowState.Added) continue;

                MetaData.SetDefault(DS.expensetaxofficial, "taxcode", rET["taxcode"]);
                DataRow rOfficial = MetaOfficial.Get_New_Row(CurrExp, DS.expensetaxofficial);
                foreach (DataColumn c in DS.expensetax.Columns) {
                    if ((c.ColumnName == "idexp") ||
                        (c.ColumnName == "ct") ||
                        (c.ColumnName == "cu") ||
                        (c.ColumnName == "lt") ||
                        (c.ColumnName == "lu")) continue;
                    if (!DS.expensetaxofficial.Columns.Contains(c.ColumnName)) continue;
                    rOfficial[c.ColumnName] = rET[c.ColumnName];
                }

                rOfficial["!description"] = rET["!descrizione"];
            }

            // da expensetaxcorrige devono entrare solo in expensetaxofficial solo le vere correzioni di ritenute
            // c/dip e/o c/amm e quindi non devono entrare gli storni tra enti (vedi caso di addizionale regionale
            // stornata in fase di conguaglio nei Co.Co.Co.), per evitare ci� possiamo filtrare
            // sulla base che l'idcity e l'idfiscaltaxregion siano null e sull'importo c/dip.
            string fNazionale = QHC.DoPar(QHC.AppAnd(QHC.IsNull("idcity"), QHC.IsNull("idfiscaltaxregion")));
            string fLocaleDip = QHC.DoPar(QHC.AppAnd(
                QHC.DoPar(QHC.AppOr(QHC.IsNotNull("idcity"), QHC.IsNotNull("idfiscaltaxregion"))),
                QHC.CmpNe("ISNULL(employamount,0)", 0)));
            string filterCorrige = QHC.AppOr(fNazionale, fLocaleDip);

            foreach (DataRow rETC in DS.expensetaxcorrige.Select(filterCorrige)) {
                string filterTax = QHS.CmpEq("taxcode", rETC["taxcode"]);
                string filterOfficial = QHS.AppAnd(QHS.CmpEq("taxcode", rETC["taxcode"]), QHS.IsNull("stop"));
                int nRow = DS.expensetaxofficial.Select(filterOfficial).Length;

                switch (nRow) {
                    case 0: {
                        MetaData.SetDefault(DS.expensetaxofficial, "taxcode", rETC["taxcode"]);
                        DataRow rOfficial = MetaOfficial.Get_New_Row(CurrExp, DS.expensetaxofficial);
                        rOfficial["ayear"] = rETC["ayear"];
                        rOfficial["employtax"] = rETC["employamount"];
                        rOfficial["admintax"] = rETC["adminamount"];
                        rOfficial["idcity"] = rETC["idcity"];
                        rOfficial["idfiscaltaxregion"] = rETC["idfiscaltaxregion"];
                        rOfficial["start"] = Meta.GetSys("datacontabile");
                        rOfficial["!description"] = rETC["!description"];
                        rOfficial["!taxref"] = rETC["!taxref"];
                        break;
                    }
                    case 1: {

                        DataRow oldOfficial = DS.expensetaxofficial.Select(filterOfficial)[0];
                        DataRow[] ExpenseTax = DS.expensetax.Select(QHS.CmpEq("taxcode", rETC["taxcode"]));

                        decimal importoDip = 0;
                        decimal importoAmm = 0;
                        if (ExpenseTax.Length == 1) {
                            DataRow rExpTax = ExpenseTax[0];
                            importoDip = CfgFn.GetNoNullDecimal(rExpTax["employtax"]);
                            importoAmm = CfgFn.GetNoNullDecimal(rExpTax["admintax"]);
                        }

                        importoDip += CfgFn.GetNoNullDecimal(rETC["employamount"]);
                        importoAmm += CfgFn.GetNoNullDecimal(rETC["adminamount"]);

                        if ((CfgFn.GetNoNullDecimal(oldOfficial["employtax"]) !=
                             importoDip) ||
                            (CfgFn.GetNoNullDecimal(oldOfficial["admintax"]) !=
                             importoAmm)) {
                            oldOfficial["stop"] = Meta.GetSys("datacontabile");

                            MetaData.SetDefault(DS.expensetaxofficial, "taxcode", rETC["taxcode"]);
                            DataRow rOfficial = MetaOfficial.Get_New_Row(CurrExp, DS.expensetaxofficial);
                            rOfficial["ayear"] = rETC["ayear"];
                            rOfficial["employtax"] = importoDip;
                            rOfficial["admintax"] = importoAmm;
                            rOfficial["idcity"] = rETC["idcity"];
                            rOfficial["idfiscaltaxregion"] = rETC["idfiscaltaxregion"];
                            rOfficial["start"] = Meta.GetSys("datacontabile");

                            foreach (string colName in new string[] {
                                "taxablegross", "taxablenet",
                                "nbracket", "taxabledenominator", "taxablenumerator",
                                "exemptionquota", "adminrate", "admindenominator", "adminnumerator",
                                "employrate", "employdenominator", "employnumerator", "abatements",
                                "!description", "!taxref"
                            }) {
                                rOfficial[colName] = oldOfficial[colName];
                            }
                        }

                        break;
                    }
                    default: {
                        object descr = DS.tax.Compute("MIN(description)", filterTax);
                        show(this, "La ritenuta " + descr.ToString() +
                                              " ha pi� di un dettaglio attivo nel Riepilogo Storico bisogna procedere ad una modficia manuale");
                        break;
                    }
                }
            }

            DeleteUfficiale(DS.expensetaxofficial);

        }

        void RicalcolaPrestazioneProfessionale() {
            if (Meta.IsEmpty) return;

            RintracciaProfessionale();

            // Se sono presenti in expensetax ritenute liquidate non si possono pi� modificare!
            if (DS.expensetax.Select("(ytaxpay is not null)").Length > 0) {
                return;
            }

            if ((ProfessionaleLinked == null) || (!Meta.InsertMode)) {
                RefreshTabPrestazione();
                return;
            }

            if (!faseMaxInclusa()) {
                //Non calcola ritenute se non � la fase finale
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            //			if ((CurrCausaleMissione!=4)||(MissionLinked==null)){
            //				DS.dettaglioritenute.Clear();
            //				ClearPrestazioni();
            //				return;
            //			}

            if (((ProfessionaleLinked == null) || (ProfessionaleMovSpesaLinked == null) ||
                (ProfessionaleMovSpesaLinked["movkind"].ToString() == "2"))
                && !monofase ){
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }
            if (((ProfessionaleLinked == null) || (IvaMovSpesaLinked==null) || 
                (IvaMovSpesaLinked["movkind"].ToString() == "2")) && monofase) {
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            int tipomovimento = 0;
            if (monofase) {
                tipomovimento = CfgFn.GetNoNullInt32(IvaMovSpesaLinked["movkind"]);
            }
            else {
                tipomovimento = CfgFn.GetNoNullInt32(ProfessionaleMovSpesaLinked["movkind"]);
            }
            //tipomovimento pu� essere IMPON o DOCUM. 
            // Se IMPON-->proporzione su totaleimponibile
            // Se DOCUM-->proporzione su costototale

            AssegnaCampiPrestazione(ProfessionaleLinked);
            CalcolaContabilizzatiProfessionale(ProfessionaleLinked);

            if (Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
            }

            decimal IMPORTO = GetImportoPerClassificazione() - VariazioniPerRitenute();

            DataRow Curr = DS.expense.Rows[0];
            //string filterprestazione = QHS.CmpKey(ProfessionaleLinked);
            string filterprestazione = QHS.AppAnd(QHS.CmpEq("ycon", ProfessionaleLinked["ycon"]), QHS.CmpEq("ncon", ProfessionaleLinked["ncon"]));
            DataTable RitenScagl = MyConn.RUN_SELECT("profservicetax", "*", null, filterprestazione, null, null, true);

            decimal costototale = CfgFn.GetNoNullDecimal(ProfessionaleLinked["totalgross"]);
            decimal importoiva = CfgFn.GetNoNullDecimal(ProfessionaleLinked["ivaamount"]);
            //Imponibile iva = costototale - importoiva 
            decimal totaleimponibile = costototale - importoiva;

            decimal TOTALE;
            decimal CONTABILIZZATO = CalcContab(ProfessionaleLinked); //Non considera gli IMPOS
            CONTABILIZZATO += CfgFn.GetNoNullDecimal(MyConn.DO_READ_VALUE("pettycashopprofserviceview",
                filterprestazione, "SUM(amount)"));


            if (tipomovimento == 1) {
                TOTALE = costototale;
                if (ProfessionaleLinked["ivafieldnumber"] != DBNull.Value) {
                    decimal imp_iva = (IMPORTO / costototale) *
                                      CfgFn.GetNoNullDecimal(ProfessionaleLinked["ivaamount"]);
                    DS.expenselast.Rows[0]["ivaamount"] = CfgFn.RoundValuta(imp_iva);
                    SetText("SubEntity_prest1", imp_iva.ToString("c"));
                }
            }
            else {
                TOTALE = costototale - importoiva; //considera solo l'imponibile
            }

            decimal RESIDUO = TOTALE - CONTABILIZZATO;
            ArrayList codiciRitenuta = new ArrayList();
            foreach (DataRow R in RitenScagl.Rows) {
                if (!codiciRitenuta.Contains(R["taxcode"])) {
                    codiciRitenuta.Add(R["taxcode"]);
                }
            }

            if (IMPORTO == RESIDUO) { //{
                //Calcola gli importi delle ritenute come differenze rispetto alle
                // ritenute in missioneritenute e quelle in dettaglioritenute
                foreach (object codiceRitenuta in codiciRitenuta) {
                    string filtertaxcode = QHC.CmpEq("taxcode", codiceRitenuta);


                    decimal assignedimponibilelordo = 0;
                    decimal assigneddeduzioni = 0;
                    decimal assigneddetrazioni = 0;
                    CalcolaTotaliAssegnati(ProfessionaleLinked, codiceRitenuta,
                        out assignedimponibilelordo, out assigneddeduzioni, out assigneddetrazioni);

                    string filtroPrestProf = QHS.AppAnd(filtertaxcode, filterprestazione);

                    decimal detrazioni = 0;
                    detrazioni -= assigneddetrazioni;


                    foreach (DataRow ProfRit in RitenScagl.Select(filtertaxcode)) {
                        bool ultimoScaglione = true;
                        decimal imponibilenetto = CfgFn.GetNoNullDecimal(ProfRit["taxablenet"]);
                        decimal ritdipendente = CfgFn.GetNoNullDecimal(ProfRit["employtax"]);
                        decimal ritamministrazione = CfgFn.GetNoNullDecimal(ProfRit["admintax"]);
                        decimal imponibilelordo = CfgFn.GetNoNullDecimal(ProfRit["taxablegross"]);
                        decimal deduzioni = CfgFn.GetNoNullDecimal(ProfRit["deduction"]);

                        decimal assignedimponibilenetto = 0;
                        decimal assignedritdipendente = 0;
                        decimal assignedritamministrazione = 0;
                        CalcolaTotaliAssegnatiScaglione(ProfessionaleLinked, ProfRit,
                            out assignedimponibilenetto, out assignedritdipendente, out assignedritamministrazione);

                        decimal detrazioniScaglione;
                        if (ultimoScaglione) {
                            detrazioniScaglione = detrazioni;
                        }
                        else {
                            detrazioniScaglione = (detrazioni <= ritdipendente) ? detrazioni : ritdipendente;
                        }

                        detrazioni -= detrazioniScaglione;
                        ritdipendente -= detrazioniScaglione;

                        decimal resid_imponibilenetto = imponibilenetto - assignedimponibilenetto;
                        decimal resid_ritdip = ritdipendente - assignedritdipendente;
                        decimal resid_ritamm = ritamministrazione - assignedritamministrazione;

                        ProfRit["taxablenet"] = resid_imponibilenetto;
                        ProfRit["employtax"] = resid_ritdip;
                        ProfRit["admintax"] = resid_ritamm;
                        ProfRit["taxablegross"] = imponibilelordo - assignedimponibilelordo;
                        ProfRit["deduction"] = deduzioni - assigneddeduzioni;

                    }

                }
            }
            else {
                //Calcola gli importi assumendo come imponibile (IMPORTO/RESIDUO)*IMPORTOLORDOMISSIONE.
                //Poich� quelle in missioneritenute hanno come imponibile IMPORTOLORDOMISSIONE,
                // la proporzione applicata � (IMPORTO/RESIDUO)
                decimal proporzione = (TOTALE == 0) ? 0 : (IMPORTO / TOTALE);
                foreach (DataRow ProfRit in RitenScagl.Select()) {
                    //decimal imponibile = CfgFn.GetNoNullDecimal(ProfRit["taxablegross"]);
                    decimal imponibilenetto = CfgFn.GetNoNullDecimal(ProfRit["taxablenet"]);
                    decimal ritdipendente = CfgFn.GetNoNullDecimal(ProfRit["employtax"]);
                    decimal ritamministrazione = CfgFn.GetNoNullDecimal(ProfRit["admintax"]);
                    decimal imponibilelordo = CfgFn.GetNoNullDecimal(ProfRit["taxablegross"]);
                    decimal deduzioni = CfgFn.GetNoNullDecimal(ProfRit["deduction"]);

                    ProfRit["taxablenet"] = CfgFn.RoundValuta(imponibilenetto * proporzione);
                    ProfRit["employtax"] = CfgFn.RoundValuta(ritdipendente * proporzione);
                    ProfRit["admintax"] = CfgFn.RoundValuta(ritamministrazione * proporzione);
                    ProfRit["taxablegross"] = CfgFn.RoundValuta(imponibilelordo * proporzione);
                    ProfRit["deduction"] = CfgFn.RoundValuta(deduzioni * proporzione);
                }
            }

            //Cancella le vecchie ritenute
            // J.T.R. 30.06.2008 Siamo solo in InsertMode non serve pi�, facciamo solo il Clear
            //DS.expensetax.RejectChanges();//now all rows in dettaglioritenute are back again!
            //ClearRitenute(DS.expensetax);
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();

            //Aggiunge le nuove ritenute
            MetaData MetaRiten = MetaData.GetMetaData(this, "expensetax");
            MetaRiten.SetDefaults(DS.expensetax);
            foreach (DataRow R in RitenScagl.Rows) {
                if (CfgFn.GetNoNullDecimal(R["taxablegross"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["employtax"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["admintax"]) == 0
                ) continue;
                //string filter = GetFilterRit(R);
                //DataRow newR;
                //DataRow []found = DS.expensetax.Select(filter);
                //if (found.Length>0)
                //    newR= found[0];	 //takes existent!!
                //else {
                MetaData.SetDefault(DS.expensetax, "taxcode", R["taxcode"]);
                DataRow newR = MetaRiten.Get_New_Row(Curr, DS.expensetax);
                //}
                foreach (string colname in new string[] {
                    "taxablegross", "taxablenet",
                    "adminrate", "adminnumerator", "admindenominator",
                    "employrate", "employnumerator", "employdenominator",
                    "taxablenumerator", "taxabledenominator",
                    "employtax", "admintax"
                }) {
                    newR[colname] = R[colname];
                }

                newR["abatements"] = DBNull.Value;
                newR["exemptionquota"] = R["deduction"];
                newR["competencydate"] = ProfessionaleLinked["start"];
                newR["!descrizione"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", R["taxcode"]));
                newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", R["taxcode"]));
            }

            DeleteRitenute(DS.expensetax);

            popolaUfficiale();

            RefreshTabPrestazione();
            //Meta.FreshForm(true);
        }


        void RicalcolaPrestazioneDipendente() {
            if (Meta.IsEmpty) return;

            RintracciaDipendente();

            // Se sono presenti in expensetax ritenute liquidate non si possono pi� modificare!
            if (DS.expensetax.Select("(ytaxpay is not null)").Length > 0) {
                return;
            }

            if ((DipendenteLinked == null) || (!Meta.InsertMode)) {
                RefreshTabPrestazione();
                return;
            }

            if (!faseMaxInclusa()) {
                //Non calcola ritenute se non � la fase finale
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            if ((DipendenteLinked == null) || (DipendenteMovSpesaLinked == null)
                /*	||	(CedolinoMovSpesaLinked["tipomovimento"].ToString().ToUpper()!=4) */) {
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                return;
            }

            AssegnaCampiPrestazione(DipendenteLinked);
            CalcolaContabilizzatiDipendente(DipendenteLinked);

            if (Meta.DrawStateIsDone) {
                Meta.GetFormData(true);
            }

            DataRow Curr = DS.expense.Rows[0];
            string filterprestazione = QueryCreator.WHERE_KEY_CLAUSE(DipendenteLinked, DataRowVersion.Default, true);
            DataTable RitenScagl = MyConn.RUN_SELECT("wageadditiontax", "*", null, filterprestazione, null, null, true);

            //Importo lordo missione = Tot Lordo del Cedolino
            decimal importolordodipendente = CfgFn.GetNoNullDecimal(DipendenteLinked["feegross"]); //imponibilelordo
            decimal TOTALE = importolordodipendente;
            decimal CONTABILIZZATO = CalcContab(DipendenteLinked);

            decimal IMPORTO = GetImportoPerClassificazione() - VariazioniPerRitenute();
            decimal RESIDUO = TOTALE - CONTABILIZZATO;
            ArrayList codiciRitenuta = new ArrayList();
            foreach (DataRow R in RitenScagl.Rows) {
                if (!codiciRitenuta.Contains(R["taxcode"])) {
                    codiciRitenuta.Add(R["taxcode"]);
                }
            }

            if (IMPORTO == RESIDUO) { //{
                //Calcola gli importi delle ritenute come differenze rispetto alle
                // ritenute in missioneritenute e quelle in dettaglioritenute
                foreach (object codiceRitenuta in codiciRitenuta) {
                    string filtertaxcode = QHC.CmpEq("taxcode", codiceRitenuta);
                    decimal assignedimponibilelordo = 0;
                    decimal assigneddeduzioni = 0;
                    decimal assigneddetrazioni = 0;
                    CalcolaTotaliAssegnati(DipendenteLinked, codiceRitenuta,
                        out assignedimponibilelordo, out assigneddeduzioni, out assigneddetrazioni);

                    string filtroCedolino = QHS.AppAnd(filtertaxcode, filterprestazione);
                    decimal detrazioni = 0;
                    detrazioni -= assigneddetrazioni;

                    foreach (DataRow DipRit in RitenScagl.Select(filtertaxcode)) {
                        bool ultimoScaglione = true;
                        decimal imponibilenetto = CfgFn.GetNoNullDecimal(DipRit["taxable"]);
                        decimal ritdipendente = CfgFn.GetNoNullDecimal(DipRit["employtax"]);
                        decimal ritamministrazione = CfgFn.GetNoNullDecimal(DipRit["admintax"]);

                        decimal assignedimponibilenetto = 0;
                        decimal assignedritdipendente = 0;
                        decimal assignedritamministrazione = 0;
                        CalcolaTotaliAssegnatiScaglione(DipendenteLinked, DipRit,
                            out assignedimponibilenetto, out assignedritdipendente, out assignedritamministrazione);

                        decimal detrazioniScaglione;
                        if (ultimoScaglione) {
                            detrazioniScaglione = detrazioni;
                        }
                        else {
                            detrazioniScaglione = (detrazioni <= ritdipendente) ? detrazioni : ritdipendente;
                        }

                        detrazioni -= detrazioniScaglione;
                        ritdipendente -= detrazioniScaglione;

                        decimal resid_imponibilenetto = imponibilenetto - assignedimponibilenetto;
                        decimal resid_ritdip = ritdipendente - assignedritdipendente;
                        decimal resid_ritamm = ritamministrazione - assignedritamministrazione;

                        DipRit["taxable"] = resid_imponibilenetto;
                        DipRit["employtax"] = resid_ritdip;
                        DipRit["admintax"] = resid_ritamm;
                    }

                }
            }
            else {
                //Calcola gli importi assumendo come imponibile (IMPORTO/RESIDUO)*IMPORTOLORDOMISSIONE.
                //Poich� quelle in missioneritenute hanno come imponibile IMPORTOLORDOMISSIONE,
                // la proporzione applicata � (IMPORTO/RESIDUO)
                decimal proporzione = (TOTALE == 0) ? 0 : (IMPORTO / TOTALE);
                foreach (DataRow DipRit in RitenScagl.Select()) {
                    //18.11.2005 - decimal imponibile = CfgFn.GetNoNullDecimal(DipRit["taxable"]);
                    decimal imponibilenetto = CfgFn.GetNoNullDecimal(DipRit["taxable"]);
                    decimal ritdipendente = CfgFn.GetNoNullDecimal(DipRit["employtax"]);
                    decimal ritamministrazione = CfgFn.GetNoNullDecimal(DipRit["admintax"]);

                    DipRit["taxable"] = CfgFn.RoundValuta(imponibilenetto * proporzione);
                    DipRit["employtax"] = CfgFn.RoundValuta(ritdipendente * proporzione);
                    DipRit["admintax"] = CfgFn.RoundValuta(ritamministrazione * proporzione);
                }
            }

            //Cancella le vecchie ritenute
            // J.T.R. 30.06.2008 Siamo solo in InsertMode non serve pi�, facciamo solo il Clear
            //DS.expensetax.RejectChanges();//now all rows in dettaglioritenute are back again!
            //ClearRitenute(DS.expensetax);
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();


            //Aggiunge le nuove ritenute
            MetaData MetaRiten = MetaData.GetMetaData(this, "expensetax");
            MetaRiten.SetDefaults(DS.expensetax);
            foreach (DataRow R in RitenScagl.Rows) {
                if (CfgFn.GetNoNullDecimal(R["taxable"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["employtax"]) == 0 &&
                    CfgFn.GetNoNullDecimal(R["admintax"]) == 0
                ) continue;
                //string filter = GetFilterRit(R);
                //DataRow newR;
                //DataRow []found = DS.expensetax.Select(filter);
                //if (found.Length>0)
                //    newR= found[0];	 //takes existent!!
                //else {
                MetaData.SetDefault(DS.expensetax, "taxcode", R["taxcode"]);
                DataRow newR = MetaRiten.Get_New_Row(Curr, DS.expensetax);
                //}
                foreach (string colname in new string[] {
                    "taxablenumerator", "taxabledenominator",
                    "employrate", "employnumerator", "employdenominator",
                    "adminrate", "adminnumerator", "admindenominator",
                    "employtax", "admintax",
                }) {
                    newR[colname] = R[colname];
                }

                //newR["ayear"] = DipendenteLinked["ycon"]; task 11058: non va pi� impostato
                newR["taxablegross"] = R["taxable"];
                newR["exemptionquota"] = 0;
                newR["taxablenet"] = R["taxable"];
                newR["abatements"] = DBNull.Value;
                newR["competencydate"] = DipendenteLinked["start"];
                newR["!descrizione"] = DS.tax.Compute("MIN(description)", QHC.CmpEq("taxcode", R["taxcode"]));
                newR["!taxref"] = DS.tax.Compute("MIN(taxref)", QHC.CmpEq("taxcode", R["taxcode"]));
            }

            DeleteRitenute(DS.expensetax);

            popolaUfficiale();

            RefreshTabPrestazione();
            //Meta.FreshForm(true);
        }



        decimal VariazioniPerRitenute() {
            decimal SUM = 0;
            foreach (DataRow Var in DS.expensevar.Select("(autokind=4)")) {
                SUM += CfgFn.GetNoNullDecimal(Var["amount"]);
            }

            return SUM;
        }

        /// <summary>
        /// Ricalcola i valori dei textbox del tab prestazione!!!!!
        /// </summary>
        private void RefreshTabPrestazione() {
            decimal TotDip = 0;
            decimal TotAmm = 0;
            decimal AssicurativeDip = 0;
            decimal AssicurativeEnte = 0;
            decimal AssistenzialiDip = 0;
            decimal AssistenzialiEnte = 0;
            decimal FiscaliDip = 0;
            decimal FiscaliEnte = 0;
            decimal PrevidenzialiDip = 0;
            decimal PrevidenzialiEnte = 0;
            decimal AltreDip = 0;
            decimal AltreEnte = 0;
            decimal MyImporto = GetImportoPerClassificazione() - VariazioniPerRitenute();

            foreach (DataRow DR in DS.expensetaxofficial.Select(QHC.IsNull("stop"))) {
                if (DR.RowState == DataRowState.Deleted) continue;

                decimal DecDip = CfgFn.GetNoNullDecimal(DR["employtax"]);
                decimal DecAmm = CfgFn.GetNoNullDecimal(DR["admintax"]);
                TotDip += DecDip;
                TotAmm += DecAmm;

                string MyFilter = "taxcode = " +
                                  QueryCreator.quotedstrvalue(DR["taxcode"], false);
                DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);
                if (DRTipo.Length == 0) {
                    string errmess = "La ritenuta con codice " + DR["taxcode"].ToString() +
                                     " non � stata trovata nella tabella TAX. " +
                                     " E' consigliabile rivolgersi al servizio assistenza. " +
                                     "Questo pu� portare ad ERRORI GRAVI nei calcoli. ";
                    Meta.CanSave = false;
                    QueryCreator.ShowError(this, errmess, errmess);
                    AltreDip += DecDip;
                    AltreEnte += DecAmm;
                    continue;
                }

                //In base al tipo di ritenuta:
                switch (DRTipo[0]["taxkind"].ToString()) {
                    case "2":
                        AssistenzialiDip += DecDip;
                        AssistenzialiEnte += DecAmm;
                        break;
                    case "1":
                        FiscaliDip += DecDip;
                        FiscaliEnte += DecAmm;
                        break;
                    case "3":
                        PrevidenzialiDip += DecDip;
                        PrevidenzialiEnte += DecAmm;
                        break;
                    case "6":
                        AltreDip += DecDip;
                        AltreEnte += DecAmm;
                        break;
                    case "4":
                        AssicurativeDip += DecDip;
                        AssicurativeEnte += DecAmm;
                        break;
                }
            } //fine foreach

            if ((DS.expensetaxofficial.Rows.Count == 0)
                //  ||				(TotDip < 0) || (TotAmm < 0)
            ) {
                txtImportonettoDip.Text = "";
                txtCostoTotaleEnte.Text = "";
                txtAssistenzialiDip.Text = "";
                txtAssistenzialiEnte.Text = "";
                txtFiscaliDip.Text = "";
                txtFiscaliEnte.Text = "";
                txtPrevidenzialiDip.Text = "";
                txtPrevidenzialiEnte.Text = "";
                txtAltreDip.Text = "";
                txtAltreEnte.Text = "";
                txtAssicurativeDip.Text = "";
                txtAssicurativeEnte.Text = "";
                return;
            }

            txtImportonettoDip.Text = Str(MyImporto - TotDip);
            txtCostoTotaleEnte.Text = Str(MyImporto + TotAmm);
            txtAssistenzialiDip.Text = Str(AssistenzialiDip);
            txtAssistenzialiEnte.Text = Str(AssistenzialiEnte);
            txtFiscaliDip.Text = Str(FiscaliDip);
            txtFiscaliEnte.Text = Str(FiscaliEnte);
            txtPrevidenzialiDip.Text = Str(PrevidenzialiDip);
            txtPrevidenzialiEnte.Text = Str(PrevidenzialiEnte);
            txtAltreDip.Text = Str(AltreDip);
            txtAltreEnte.Text = Str(AltreEnte);
            txtAssicurativeDip.Text = Str(AssicurativeDip);
            txtAssicurativeEnte.Text = Str(AssicurativeEnte);

            //CfgFn.AssignNotEquals(DS.expense.Rows[0],"employtaxamount",TotDip);
            //CfgFn.AssignNotEquals(DS.expense.Rows[0],"admintaxamount",TotAmm);
            // 17.11.2005 DS.expensetax.Columns["taxable"].DefaultValue= GetImporto();
            //DS.expensetax.Columns["taxablegross"].DefaultValue = GetImporto();
        }



        void ShowHideControl(string name, bool visible) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
            if (Ctrl == null) return;
            Control C = (Control) Ctrl.GetValue(this);
            C.Visible = visible;
        }

        void SetLabel(string name, string text) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
            if (Ctrl == null) return;
            if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return;
            Label L = (Label) Ctrl.GetValue(this);
            L.Text = text;
        }

        void SetText(string name, string text) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(name);
            if (Ctrl == null) return;
            if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return;
            TextBox T = (TextBox) Ctrl.GetValue(this);
            T.Text = text;
        }

        void VisualizzaPrestazioniAggiuntive(DataRow TipoPrestazione) {
            bool GboxVisibile = false;
            for (int i = 1; i <= 1; i++) {
                //string txtname = "prest"+i.ToString();
                //string labname = "labprest"+i.ToString();
                string etichetta = TipoPrestazione["ivaamount"].ToString().Trim();
                bool visible = (etichetta != "");
                //ShowHideControl(txtname, visible);
                //ShowHideControl(labname, visible);
                //SetLabel(labname, etichetta);
                GboxVisibile |= visible;
            }

            gBoxImportiPrestazione.Visible = GboxVisibile;
        }

        private void popolaGeoCity(object idCity) {
            if ((idCity == null) || (idCity == DBNull.Value)) return;
            string filter = QHC.CmpEq("idcity", idCity);
            if (DS.geo_city.Select(filter).Length > 0) return;
            string filterSQL = QHS.CmpEq("idcity", idCity);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.geo_city, null, filterSQL, null, true);
        }

        private void popolaFiscalTaxRegion(object idFiscalTaxRegion) {
            if ((idFiscalTaxRegion == null) || (idFiscalTaxRegion == DBNull.Value)) return;
            string filter = QHC.CmpEq("idfiscaltaxregion", idFiscalTaxRegion);
            if (DS.fiscaltaxregion.Select(filter).Length > 0) return;
            string filterSQL = QHS.CmpEq("idfiscaltaxregion", idFiscalTaxRegion);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.fiscaltaxregion, null, filterSQL, null, true);
        }

        void ShowHidePrestazioniAggiuntive(bool visible) {
//			for (int i=1; i<=1; i++){
//				string txtname = "prest"+i.ToString();
//				string labname = "labprest"+i.ToString();
//				string etichetta = "prestazione "+i.ToString();
//				ShowHideControl(txtname, visible);
//				ShowHideControl(labname, visible);
//				if (visible) SetLabel(labname, etichetta);
//			}
            gBoxImportiPrestazione.Visible = visible;
        }

        /// <summary>
        /// Azzera i textBox relativi agli importi delle prestazioni
        /// </summary>
        void ClearPrestazioni() {
            //if (!Meta.IsEmpty){
            //    if (faseMaxInclusa()){
            //        CfgFn.AssignNotEquals(DS.expense.Rows[0],"employtaxamount",0);
            //        CfgFn.AssignNotEquals(DS.expense.Rows[0],"admintaxamount",0);
            //    }
            //    else {
            //        if (DS.expense.Rows[0]["employtaxamount"]!=DBNull.Value) 
            //            DS.expense.Rows[0]["employtaxamount"]=DBNull.Value;
            //        if (DS.expense.Rows[0]["admintaxamount"]!=DBNull.Value) 
            //            DS.expense.Rows[0]["admintaxamount"]=DBNull.Value;
            //    }
            //}
            txtImportonettoDip.Text = "";
            txtCostoTotaleEnte.Text = "";
            txtAssistenzialiDip.Text = "";
            txtAssistenzialiEnte.Text = "";
            txtFiscaliDip.Text = "";
            txtFiscaliEnte.Text = "";
            txtPrevidenzialiDip.Text = "";
            txtPrevidenzialiEnte.Text = "";
            txtAltreDip.Text = "";
            txtAltreEnte.Text = "";
            txtAssicurativeDip.Text = "";
            txtAssicurativeEnte.Text = "";
            ShowHidePrestazioniAggiuntive(false);
        }

        #endregion


        #region Gestione Automatismi

        private void btnAutomatismiPrestazione_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.InsertMode) return;
            string idspesa = DS.expense.Rows[0]["idexp"].ToString();
            string filter = QHS.AppAnd(QHS.CmpEq("idpayment", idspesa), QHS.DoPar(QHS.AppOr(QHS.CmpEq("autokind", 4),
                QHS.CmpEq("autokind", 20), QHS.CmpEq("autokind", 21))));
            Form F = ShowAutomatismi.Show(Meta, filter, filter, filter, null);
            createForm(F, null);
            F.Show();

        }

        private void btnAutomatismiRecuperi_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.InsertMode) return;
            string idspesa = DS.expense.Rows[0]["idexp"].ToString();
            string filter = "(idpayment=" + QueryCreator.quotedstrvalue(idspesa, true) + ")AND" +
                            "(autokind=6)";
            Form F = ShowAutomatismi.Show(Meta, filter, filter, filter, null);
            createForm(F, null);
            F.Show();

        }



        void GeneraAzzeraDisponibilitaFasiPrec() {
            if (Meta.IsEmpty) return;
            if (SecondoPostAttivo) return;

            if (chbAzzeramento.Checked) {
                GestioneAutomatismi GestAuto = new GestioneAutomatismi(this,
                    Meta.Conn, Meta.Dispatcher,
                    DS, currphase, fasespesamax, "expense", false);
                bool res = GestAuto.GeneraAzzeraDisponibilitaFasiPrec();
                if (res) chbAzzeramento.Checked = false;
            }

        }

        #endregion

        public void MetaData_AfterGetFormData() {

            if (Meta.IsEmpty) return;

            //La seg. evita errori in caso di "delete", nel cui caso le tabelle sono vuote.
            if (DS.Tables["expenseyear"].Rows.Count == 0) return;

            DataRow RSpesa = DS.expense.Rows[0];
            DataRow RImputazione = DS.expenseyear.Rows[0];
            if (RSpesa.RowState == DataRowState.Deleted) return;
            
            HelpForm.SetDenyNull(DS.expense.Columns["idinc_linked"], false);
            DS.expense.Columns["idinc_linked"].Caption = "Movimento di entrata collegato";

            if (ContabilizzazioneSelezionata() == tipocont.cont_none && currphase == 1 && Meta.InsertMode && ((flagUniconfig&16) !=0)) {
	            //se la voce di bilancio � p. di giro allora rende obbligatorio il movimento di entrata collegato
	            object idfin = RImputazione["idfin"];
	            var r = DS.finview.get(MyConn, q.eq("idfin", idfin)).FirstOrDefault();
	            if (r != null) {
		            int flag = CfgFn.GetNoNullInt32(r["flag"]);
                    if ((flag &2)!=0 ) HelpForm.SetDenyNull(DS.expense.Columns["idinc_linked"], true);
	            }
            }



            if (Meta.InsertMode) CfgFn.ReSetAutoIncrementPropertiesForFirstPhaseSpesa(Meta.Conn, DS.expense, RSpesa);

            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            //Un movimento � residuo se deriva dagli esercizi precedenti, ossia 
            //   esercmovimento < Conn.esercizio

            if (Meta.InsertMode) {
                //all'atto dell'inserimento porre imputazione.importo = spesa.importo
                //RSpesa["amount"] = RImputazione["amount"]; 
                //RSpesa["ycreation"] = esercizio;
                RImputazione["ayear"] = esercizio; // RSpesa["eserccreazione"];	
                                                   //RImputazione["nphase"]=RSpesa["nphase"];
                //foreach (DataRow Child in DS.invoicedetail_taxable_nc.Select()) {
                //    Child["idexp_taxable"] = RSpesa["idexp"];
                //    Child["idexp_iva"] = RSpesa["idexp"];
                //}
            }
            impostaFlagNonContabilizzazioneImpegno();
            impostaFlagNonContabilizzazione();

//            if (Meta.EditMode){
////				//se flagcompetenza=C per ogni update imputazione.importo = spesa.importo                
////				if (RImputazione["flagcompetenza"].ToString().ToUpper()=="C"){
////					RSpesa["importo"] = RImputazione["importo"];
////				}
//                if (RImputazione["ayear"].ToString()==RSpesa["ycreation"].ToString()){
//                    RSpesa["amount"] = RImputazione["amount"];
//                }
//            }
        }


        #region Gestione ComboBox Causali (generico)

        /// <summary>
        /// Svuota la tabella DS.tipomovimento, a cui � agganciato il combo causale
        /// </summary>
        void ClearComboCausale() {
            DataTable TCombo = DS.tipomovimento;
            TCombo.Clear();
            cmbCausale.Enabled = false;
        }

        void EnableTipoMovimento(int IDtipo, string descrtipo) {
            DataRow R = DS.tipomovimento.NewRow();
            R["idtipo"] = IDtipo;
            R["descrizione"] = descrtipo;
            DS.tipomovimento.Rows.Add(R);
            DS.tipomovimento.AcceptChanges();
        }

        /// <summary>
        /// Restituisce la contabilizzazione selezionata nel combobox cmbTipoContabilizz.
        /// </summary>
        /// <returns></returns>
        tipocont ContabilizzazioneSelezionata() {
            if (cmbTipoContabilizzazione.Items.Count == 0) return tipocont.cont_none;
            if (cmbTipoContabilizzazione.SelectedItem == null) return tipocont.cont_none;
            string currTipo = cmbTipoContabilizzazione.SelectedItem.ToString();
            tipocont codecont = CodiceContabilizzazione(currTipo);
            return codecont;
        }

        private void cmbTipoContabilizzazione_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (DisabilitaEventiTipoDocumento) return;
            tipocont codecont = ContabilizzazioneSelezionata();
            AttivaContabilizzazione(codecont);
        }

        void UpdateComboCausale() {
            if (!Meta.EditMode) return;
            tipocont curr = ContabilizzazioneSelezionata();
            switch (curr) {
                case tipocont.cont_missione:
                    UpdateComboCausaleMissione();
                    break;
                case tipocont.cont_ordine:
                    UpdateComboCausaleOrdine();
                    break;
                case tipocont.cont_iva:
                    UpdateComboCausaleIva();
                    break;
                case tipocont.cont_cedolino:
                    UpdateComboCausaleCedolino();
                    break;
                case tipocont.cont_occasionale:
                    UpdateComboCausaleOccasionale();
                    break;
                case tipocont.cont_professionale:
                    UpdateComboCausaleProfessionale();
                    break;
                case tipocont.cont_dipendente:
                    UpdateComboCausaleDipendente();
                    break;
            }
        }

        /// <summary>
        /// Imposta il valore del combobox ed aggiorna l'importo del movimento
        /// </summary>
        /// <param name="tipomovimento"></param>

        /// <summary>
        /// Ricalcola l'importo selezionato considerando che il mov. padre (quindi la disponibilit�) � cambiata
        /// </summary>
        void RecalcImporto() {
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_missione:
                    ReCalcImporto_Missione();
                    return;
                case tipocont.cont_ordine:
                    ReCalcImporto_Ordine();
                    return;
                case tipocont.cont_iva:
                    ReCalcImporto_Iva();
                    return;
                case tipocont.cont_cedolino:
                    ReCalcImporto_Cedolino();
                    return;
                case tipocont.cont_occasionale:
                    ReCalcImporto_Occasionale();
                    return;
                case tipocont.cont_professionale:
                    ReCalcImporto_Professionale();
                    return;
                case tipocont.cont_dipendente:
                    ReCalcImporto_Dipendente();
                    return;
                case tipocont.cont_none:
                    return;

            }
        }


        #endregion

        #region Gestione Documenti Contabilizzazione

        private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_missione:
                    cmbCausaleMissione_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_ordine:
                    cmbCausaleOrdine_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_iva:
                    cmbCausaleIva_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_cedolino:
                    cmbCausaleCedolino_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_occasionale:
                    cmbCausaleOccasionale_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_professionale:
                    cmbCausaleProfessionale_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_dipendente:
                    cmbCausaleDipendente_SelectedIndexChanged(sender, e);
                    break;

            }
        }

        private void btnDocumento_Click(object sender, System.EventArgs e) {
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_missione:
                    btnMissione_Click(sender, e);
                    break;
                case tipocont.cont_ordine:
                    btnOrdine_Click(sender, e);
                    break;
                case tipocont.cont_iva:
                    btnIva_Click(sender, e);
                    break;
                case tipocont.cont_cedolino:
                    btnCedolino_Click(sender, e);
                    break;
                case tipocont.cont_occasionale:
                    btnOccasionale_Click(sender, e);
                    break;
                case tipocont.cont_professionale:
                    btnProfessionale_Click(sender, e);
                    break;
                case tipocont.cont_dipendente:
                    btnDipendente_Click(sender, e);
                    break;
            }
        }

        private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_missione:
                    txtEsercMissione_Leave(sender, e);
                    break;
                case tipocont.cont_ordine:
                    txtEsercOrdine_Leave(sender, e);
                    break;
                case tipocont.cont_iva:
                    txtEsercIva_Leave(sender, e);
                    break;
                case tipocont.cont_cedolino:
                    txtEsercCedolino_Leave(sender, e);
                    break;
                case tipocont.cont_occasionale:
                    txtEsercOccasionale_Leave(sender, e);
                    break;
                case tipocont.cont_professionale:
                    txtEsercProfessionale_Leave(sender, e);
                    break;
                case tipocont.cont_dipendente:
                    txtEsercDipendente_Leave(sender, e);
                    break;
            }
        }

        bool LeavingtxtNumDoc = false;

        private void txtNumDoc_Leave(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (LeavingtxtNumDoc) return;
            LeavingtxtNumDoc = true;
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_missione:
                    txtNumMissione_Leave(sender, e);
                    break;
                case tipocont.cont_ordine:
                    txtNumOrdine_Leave(sender, e);
                    break;
                case tipocont.cont_iva:
                    txtNumIva_Leave(sender, e);
                    break;
                case tipocont.cont_cedolino:
                    txtNumCedolino_Leave(sender, e);
                    break;
                case tipocont.cont_occasionale:
                    txtNumOccasionale_Leave(sender, e);
                    break;
                case tipocont.cont_professionale:
                    txtNumProfessionale_Leave(sender, e);
                    break;
                case tipocont.cont_dipendente:
                    txtNumDipendente_Leave(sender, e);
                    break;
            }

            LeavingtxtNumDoc = false;
        }

        private void cmbTipoDocumentoGenerico_SelectedIndexChanged(object sender, System.EventArgs e) {
            tipocont currcont = ContabilizzazioneSelezionata();
            switch (currcont) {
                case tipocont.cont_ordine:
                    cmbTipoOrdine_SelectedIndexChanged(sender, e);
                    break;
                case tipocont.cont_iva:
                    cmbTipoDocumento_SelectedIndexChanged(sender, e);
                    break;
            }
        }


        tipocont DeduciTipoContabilizzazione() {
            if (DS.expenseitineration.Rows.Count > 0) return tipocont.cont_missione;
            if (DS.expensemandate.Rows.Count > 0) return tipocont.cont_ordine;
            if (DS.expenseinvoice.Rows.Count > 0) return tipocont.cont_iva;
            if (DS.expensepayroll.Rows.Count > 0) return tipocont.cont_cedolino;
            if (DS.expensecasualcontract.Rows.Count > 0) return tipocont.cont_occasionale;
            if (DS.expenseprofservice.Rows.Count > 0) return tipocont.cont_professionale;
            if (DS.expensewageaddition.Rows.Count > 0) return tipocont.cont_dipendente;
            return tipocont.cont_none;
        }


        void DeduciContabilizzazione() {
            tipocont currcont = DeduciTipoContabilizzazione();
            VisualizzaControlliContabilizzazione(currcont);

            /// HERE!
            DisabilitaEventiTipoDocumento = true;
            CalcolaContabilizzazioniPossibili();
            SetContabilizzazione(currcont);
            DisabilitaEventiTipoDocumento = false;

            switch (currcont) {
                case tipocont.cont_missione:
                    SetEditComboCausaleMissione();
                    break;

                case tipocont.cont_ordine:
                    SetEditComboCausaleOrdine();
                    break;

                case tipocont.cont_iva:
                    SetEditComboCausaleIva();
                    break;

                case tipocont.cont_cedolino:
                    SetEditComboCausaleCedolino();
                    break;

                case tipocont.cont_occasionale:
                    SetEditComboCausaleOccasionale();
                    break;

                case tipocont.cont_professionale:
                    SetEditComboCausaleProfessionale();
                    break;

                case tipocont.cont_dipendente:
                    SetEditComboCausaleDipendente();
                    break;
            }



        }

        /// <summary>
        /// Imposta il combo del tipo contabilizzazione con un valore assegnato
        /// </summary>
        /// <param name="tipo"></param>
        void SetContabilizzazione(tipocont tipo) {
            for (int i = 0; i < cmbTipoContabilizzazione.Items.Count; i++) {
                if (cmbTipoContabilizzazione.Items[i].ToString() ==
                    NomeContabilizzazione(tipo)) {
                    if (cmbTipoContabilizzazione.SelectedIndex != i) {
                        if ((i != 0) || (cmbTipoContabilizzazione.SelectedIndex != -1)) {
                            cmbTipoContabilizzazione.SelectedIndex = i;
                        }
                    }

                }
            }            
        }

        bool DisabilitaEventiTipoDocumento = false;

        /// <summary>
        /// Ricalcola il combo delle contabilizzazioni in base alle fasi selezionate,
        ///  ed eventualmente scollega i documenti non pi� collegabili
        /// </summary>
        void GestioneFasePerDocumentoCollegato() {
            DisabilitaEventiTipoDocumento = true;
            tipocont oldcont = ContabilizzazioneSelezionata();
            cmbTipoContabilizzazione.Items.Clear();
            CalcolaContabilizzazioniPossibili();
            if (ContabilizzazioneAttivabile(oldcont)) {
                SetContabilizzazione(oldcont);
                VisualizzaControlliContabilizzazione(oldcont);
                DisabilitaEventiTipoDocumento = false;

                if (oldcont != tipocont.cont_iva) {
                    cmbTipoContabilizzazione.Enabled = (!Meta.EditMode);
                }
                else {
                    cmbTipoContabilizzazione.Enabled = (!Meta.EditMode && (ProfessionaleLinked == null));
                }

                return;
            }

            cmbTipoContabilizzazione.Enabled = (!Meta.EditMode);
            if (oldcont != tipocont.cont_iva) {
                cmbTipoContabilizzazione.Enabled = (!Meta.EditMode);
            }
            else {
                cmbTipoContabilizzazione.Enabled = (!Meta.EditMode && (ProfessionaleLinked == null));
            }

            SetContabilizzazione(tipocont.cont_none);

            AttivaContabilizzazione(tipocont.cont_none);
            DisabilitaEventiTipoDocumento = false;
        }

        void AbilitaDisabilitaControlliContabilizzazione(bool abilita) {
            cmbCausale.Enabled = abilita && (!Meta.EditMode);
            cmbTipoDocumento.Enabled = abilita && (!Meta.EditMode);
            btnDocumento.Enabled = abilita && (!Meta.EditMode);
            txtEsercDoc.ReadOnly = (!abilita) || Meta.EditMode;
            txtNumDoc.ReadOnly = (!abilita) || Meta.EditMode;
            cmbTipoContabilizzazione.Enabled = abilita && (!Meta.EditMode);
        }

        void CambiaTagControlliComuni(string tablevista) {
            txtCodiceBilancio.Tag =
                "finview.codefin?" +
                tablevista + ".codefin";
            //txtCredDeb.Tag=
            //    "registry.title?"+
            //    tablevista+	".registry";
            //SubEntity_comboUPB.Tag=
            //    "expenseyear.idupb?"+
            //    tablevista+	".idupb";
            SubEntity_txtImportoMovimento.Tag =
                "expenseyear.amount?" +
                tablevista + ".ayearstartamount";
            txtImportoCorrente.Tag = "expensetotal.curramount?" + tablevista + ".curramount";
            txtImportoDisponibile.Tag = "expensetotal.available?" + tablevista + ".available";
            txtFormerYmov.Tag = "formerexpense.ymov.year?" + tablevista + ".formerymov";
            txtFormerNmov.Tag = "formerexpense.nmov?" + tablevista + ".formernmov";
        }


        /// <summary>
        /// Visualizza/Nasconde i controlli relativi alla contabilizzazione scelta, 
        ///  (inclusi btn, txtCredDeb, etc. ) impostandone anche i tag. 
        /// </summary>
        /// <param name="codecont"></param>
        void VisualizzaControlliContabilizzazione(tipocont codecont) {
//			cmbCausale.Visible=true;
//			labelCausale.Visible=true;
//			gboxDocumento.Visible=true;
            txtEsercDoc.ReadOnly = Meta.EditMode;
            txtNumDoc.ReadOnly = Meta.EditMode;
            btnDocumento.Enabled = !Meta.EditMode;
            cmbTipoDocumento.Enabled = !Meta.EditMode;

            switch (codecont) {
                case tipocont.cont_missione:
                    cmbCausale.Visible = true;
                    labelCausale.Visible = true;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = false;
                    cmbTipoDocumento.Visible = false;
                    btnDocumento.Text = "Missione";
                    txtEsercDoc.Tag =
                        "itineration.yitineration?" +
                        "expenseitinerationview.yitineration";
                    txtNumDoc.Tag = "itineration.nitineration?" +
                                    "expenseitinerationview.nitineration";
                    txtApplierAnnotations.Tag = "itineration.applierannotations";
                    cmbTipoDocumento.Tag = null;
                    AbilitaDisabilitaControlliMissione(false);
                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expenseitineration.Rows.Count == 0);
                    }

                    //					txtDataInizioPrest.ReadOnly=true;
                    //					txtDataFinePrest.ReadOnly=true;
                    //					btnPrestazione.Enabled=false;
                    //					cmbTipoprestazione.Enabled=false;
                    //					btnCalcoloGuidato.Enabled=false;
                    break;
                case tipocont.cont_cedolino:
                    cmbCausale.Visible = false;
                    labelCausale.Visible = false;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = false;
                    cmbTipoDocumento.Visible = false;
                    btnDocumento.Text = "Cedolino";
                    txtEsercDoc.Tag =
                        "payroll.fiscalyear?" +
                        "expensepayrollview.fiscalyear";
                    txtNumDoc.Tag = "payroll.npayroll?" +
                                    "expensepayrollview.npayroll";
                    cmbTipoDocumento.Tag = null;
                    AbilitaDisabilitaControlliCedolino(false);
                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expensepayroll.Rows.Count == 0);
                    }

                    //					txtDataInizioPrest.ReadOnly=true;
                    //					txtDataFinePrest.ReadOnly=true;
                    //					btnPrestazione.Enabled=false;
                    //					cmbTipoprestazione.Enabled=false;
                    //					btnCalcoloGuidato.Enabled=false;
                    break;
                case tipocont.cont_occasionale:
                    cmbCausale.Visible = false;
                    labelCausale.Visible = false;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = false;
                    cmbTipoDocumento.Visible = false;
                    btnDocumento.Text = "Contr.Occasionale";
                    txtEsercDoc.Tag =
                        "expensecasualcontract.ycon?" +
                        "expensecasualcontractview.ycon";
                    txtNumDoc.Tag = "expensecasualcontract.ncon?" +
                                    "expensecasualcontractview.ncon";
                    cmbTipoDocumento.Tag = null;
                    AbilitaDisabilitaControlliOccasionale(false);
                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expensecasualcontract.Rows.Count == 0);
                    }

                    break;
                case tipocont.cont_professionale:
                    cmbCausale.Visible = true;
                    labelCausale.Visible = true;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = false;
                    cmbTipoDocumento.Visible = false;
                    btnDocumento.Text = "Contr.Professionale";
                    txtEsercDoc.Tag =
                        "expenseprofservice.ycon?" +
                        "expenseprofserviceview.ycon";
                    txtNumDoc.Tag = "expenseprofservice.ncon?" +
                                    "expenseprofserviceview.ncon";
                    cmbTipoDocumento.Tag = null;
                    AbilitaDisabilitaControlliProfessionale(false);
                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expenseprofservice.Rows.Count == 0);
                    }

                    break;
                case tipocont.cont_dipendente:
                    cmbCausale.Visible = false;
                    labelCausale.Visible = false;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = false;
                    cmbTipoDocumento.Visible = false;
                    btnDocumento.Text = "Altri Compensi";
                    txtEsercDoc.Tag =
                        "expensewageaddition.ycon?" +
                        "expensewageadditionview.ycon";
                    txtNumDoc.Tag = "expensewageaddition.ncon?" +
                                    "expensewageadditionview.ncon";
                    cmbTipoDocumento.Tag = null;
                    AbilitaDisabilitaControlliDipendente(false);
                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expensewageaddition.Rows.Count == 0);
                    }

                    break;

                case tipocont.cont_iva:
                    if (Meta.InsertMode) {
                        txtEsercDoc.ReadOnly = ProfessionaleLinked != null;
                        txtNumDoc.ReadOnly = ProfessionaleLinked != null;
                        btnDocumento.Enabled = ProfessionaleLinked == null;
                        cmbTipoDocumento.Enabled = ProfessionaleLinked == null;
                    }

                    cmbCausale.Visible = true;
                    labelCausale.Visible = true;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = true;
                    cmbTipoDocumento.Visible = true;
                    btnDocumento.Text = "Documento";
                    txtEsercDoc.Tag =
                        "expenseinvoice.yinv?" +
                        "expenseinvoiceview.yinv";
                    txtNumDoc.Tag =
                        "expenseinvoice.ninv?" +
                        "expenseinvoiceview.ninv";
                    cmbTipoDocumento.Tag =
                        "expenseinvoice.idinvkind?" +
                        "expenseinvoiceview.idinvkind";
                    ImpostaComboInvoiceKind();
                    AbilitaDisabilitaControlliFattura(true);

                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expenseinvoice.Rows.Count == 0);
                    }

                    gboxDettInvoice.Visible = true;
                    SubEntity_txtImportoMovimento.ReadOnly = true;
                    break;
                case tipocont.cont_ordine:
                    cmbCausale.Visible = true;
                    labelCausale.Visible = true;
                    gboxDocumento.Visible = true;
                    labEsercizio.Text = "Eserc.";
                    labNum.Text = "Num.";

                    labelTipoDocumento.Visible = true;
                    cmbTipoDocumento.Visible = true;
                    btnDocumento.Text = "Contratto Passivo";
                    txtEsercDoc.Tag =
                        "expensemandate.yman?" +
                        "expensemandateview.yman";
                    txtNumDoc.Tag = "expensemandate.nman?" +
                                    "expensemandateview.nman";
                    txtApplierAnnotations.Tag = "mandate.applierannotations";
                    cmbTipoDocumento.Tag =
                        "expensemandate.idmankind?" +
                        "expensemandateview.idmankind";
                    ImpostaComboMandateKind();
                    AbilitaDisabilitaControlliOrdine(true);

                    if (Meta.IsEmpty) {
                        AbilitaDisabilitaCreditoreDebitore(true);
                    }
                    else {
                        AbilitaDisabilitaCreditoreDebitore(DS.expensemandate.Rows.Count == 0);
                    }

                    gboxDettmandate.Visible = true;
                    break;

                case tipocont.cont_none:
                    cmbTipoDocumento.Tag = null;
                    txtEsercDoc.Tag = null;
                    txtNumDoc.Tag = null;
                    NascondiControlliContabilizzazione();
                    gboxDettInvoice.Visible = false;
                    gboxDettmandate.Visible = false;
                    SubEntity_txtImportoMovimento.ReadOnly = EsisteEsercPrecedente();
                    break;
            }

            //ClearComboCausale();
        }

        void ImpostaComboMandateKind() {
            if (cmbTipoDocumento.DataSource != null) {
                DataTable T = cmbTipoDocumento.DataSource as DataTable;
                if (T.Columns["idmankind"] != null) return;
            }

            TipoDocChangePilotato = true;
            cmbTipoDocumento.DataSource = DS.mandatekind;
            cmbTipoDocumento.DisplayMember = "description";
            cmbTipoDocumento.ValueMember = "idmankind";
            Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento, null);
            TipoDocChangePilotato = false;
        }

        void ImpostaComboInvoiceKind() {
            if (cmbTipoDocumento.DataSource != null) {
                DataTable T = cmbTipoDocumento.DataSource as DataTable;
                if (T.Columns["idinvkind"] != null) return;
            }

            TipoDocChangePilotato = true;
            cmbTipoDocumento.DataSource = DS.invoicekind;
            cmbTipoDocumento.DisplayMember = "description";
            cmbTipoDocumento.ValueMember = "idinvkind";
            Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento, null);
            TipoDocChangePilotato = false;
        }


        void NascondiControlliContabilizzazione() {
            if (gboxDocumento.Visible) gboxDocumento.Visible = false;
            if (cmbCausale.Visible) cmbCausale.Visible = false;
            if (labelCausale.Visible) labelCausale.Visible = false;
        }

        public enum tipocont {
            cont_none,
            cont_ordine,
            cont_missione,
            cont_iva,
            cont_cedolino,
            cont_occasionale,
            cont_professionale,
            cont_dipendente
        };
        //public tipocont currcont;

        string NomeContabilizzazione(tipocont TIPO) {
            switch (TIPO) {
                case tipocont.cont_ordine: return "Contratto Passivo";
                case tipocont.cont_missione: return "Missione";
                case tipocont.cont_iva: return "Documento Iva";
                case tipocont.cont_cedolino: return "Cedolino Parasubordinati";
                case tipocont.cont_occasionale: return "Prestazione Occasionale";
                case tipocont.cont_professionale: return "Prestazione Professionale";
                case tipocont.cont_dipendente: return "Altri Compensi";
                case tipocont.cont_none: return "";
            }

            return null;
        }

        tipocont CodiceContabilizzazione(string nomecont) {
            switch (nomecont) {
                case "Contratto Passivo": return tipocont.cont_ordine;
                case "Missione": return tipocont.cont_missione;
                case "Documento Iva": return tipocont.cont_iva;
                case "Cedolino Parasubordinati": return tipocont.cont_cedolino;
                case "Prestazione Occasionale": return tipocont.cont_occasionale;
                case "Prestazione Professionale": return tipocont.cont_professionale;
                case "Altri Compensi": return tipocont.cont_dipendente;
                case "": return tipocont.cont_none;
            }

            return tipocont.cont_none;
        }

        /// <summary>
        /// Stabilisce se � possibile con la fase corrente contabilizzare un
        ///  certo tipo di documento
        /// </summary>
        /// <returns></returns>
        bool ContabilizzazioneAttivabile(tipocont codecont) {
            switch (codecont) {
                case tipocont.cont_missione:
                    if (currphase == fasemissione) return true;
                    return false;
                case tipocont.cont_cedolino:
                    if (currphase == fasecedolino) return true;
                    return false;
                case tipocont.cont_ordine:
                    if ((fasespesamax == 1) && (Meta.InsertMode)) return false;
                    if (currphase == faseordine) return true;
                    return false;
                case tipocont.cont_iva:
                    if (currphase == faseiva) return true;
                    return false;
                case tipocont.cont_occasionale:
                    if (currphase == faseoccasionale) return true;
                    return false;
                case tipocont.cont_professionale:
                    if (currphase == faseprofessionale) return true;
                    return false;
                case tipocont.cont_dipendente:
                    if (currphase == fasedipendente) return true;
                    return false;

                default:
                    return false;
            }
        }


        /// <summary>
        /// Riempie il Combo del tipo di Contabilizzazione con
        ///  le scelte possibili in base alla fase corrente
        /// </summary>
        void CalcolaContabilizzazioniPossibili() {
            cmbTipoContabilizzazione.Items.Clear();
            cmbTipoContabilizzazione.Items.Add("");
            foreach (tipocont codecont in new tipocont[] {
                tipocont.cont_ordine,
                tipocont.cont_missione,
                tipocont.cont_iva,
                tipocont.cont_cedolino,
                tipocont.cont_occasionale,
                tipocont.cont_professionale,
                tipocont.cont_dipendente
            }) {
                if (ContabilizzazioneAttivabile(codecont))
                    cmbTipoContabilizzazione.Items.Add(
                        NomeContabilizzazione(codecont));
            }
        }

        /// <summary>
        /// Abilita / disabilita il cred/deb, sempre le la fase di attivazione � inclusa
        /// </summary>
        /// <param name="abilita"></param>
        void AbilitaDisabilitaCreditoreDebitore(bool abilita) {
            if (!abilita) {
                txtCredDeb.ReadOnly = true;
                return;
            }

            int fasecreditore = ManageCreditore.faseattivazione;
            bool CreditoreAbilitato = (currphase == fasecreditore);
            txtCredDeb.ReadOnly = !CreditoreAbilitato;
        }

        /// <summary>
        /// Funzione chiamata quando cambia il combo delle contabilizzazioni
        /// Disattiva tutte le contabilizzazioni e poi attiva quella indicata.
        /// Scollega qualsiasi documento collegato
        /// </summary>
        /// <param name="codecont"></param>
        void AttivaContabilizzazione(tipocont codecont) {
            foreach (tipocont disattivacont in new tipocont[] {
                tipocont.cont_missione,
                tipocont.cont_ordine,
                tipocont.cont_iva,
                tipocont.cont_cedolino,
                tipocont.cont_occasionale,
                tipocont.cont_professionale,
                tipocont.cont_dipendente
            }) {
                DisattivaContabilizzazione(disattivacont);
            }

            txtEsercDoc.Text = "";
            txtNumDoc.Text = "";
            switch (codecont) {
                case tipocont.cont_missione:
                    CambiaTagControlliComuni("expenseitinerationview");
                    Meta.DefaultListType = "missione";
                    break;
                case tipocont.cont_ordine:
                    CambiaTagControlliComuni("expensemandateview");
                    Meta.DefaultListType = "ordinegenerico";
                    break;
                case tipocont.cont_iva:
                    CambiaTagControlliComuni("expenseinvoiceview");
                    Meta.DefaultListType = "iva";
                    break;
                case tipocont.cont_cedolino:
                    CambiaTagControlliComuni("expensepayrollview");
                    Meta.DefaultListType = "cedolino";
                    break;
                case tipocont.cont_occasionale:
                    CambiaTagControlliComuni("expensecasualcontractview");
                    Meta.DefaultListType = "occasionale";
                    break;
                case tipocont.cont_professionale:
                    CambiaTagControlliComuni("expenseprofserviceview");
                    Meta.DefaultListType = "professionale";
                    break;
                case tipocont.cont_dipendente:
                    CambiaTagControlliComuni("expensewageadditionview");
                    Meta.DefaultListType = "dipendente";
                    break;
                case tipocont.cont_none:
                    CambiaTagControlliComuni("expenseview");
                    Meta.DefaultListType = defaultListType;
                    break;
            }

            VisualizzaControlliContabilizzazione(codecont);
            ClearComboCausale();
        }

        void DisattivaContabilizzazione(tipocont codecont) {
            if (!Meta.InsertMode) return;
            switch (codecont) {
                case tipocont.cont_missione:
                    if (faseMissioneInclusa()) ScollegaMissione();
                    return;
                case tipocont.cont_cedolino:
                    if (faseCedolinoInclusa()) ScollegaCedolino();
                    return;
                case tipocont.cont_ordine:
                    if (faseOrdineInclusa()) ScollegaOrdine();
                    return;
                case tipocont.cont_iva:
                    if (faseIvaInclusa()) ScollegaIva();
                    return;
                case tipocont.cont_occasionale:
                    if (faseOccasionaleInclusa()) ScollegaOccasionale();
                    return;
                case tipocont.cont_professionale:
                    if (faseProfessionaleInclusa()) ScollegaProfessionale();
                    return;
                case tipocont.cont_dipendente:
                    if (faseDipendenteInclusa()) ScollegaDipendente();
                    return;
            }

        }

        void GetDocMissione(out DataRow MissioneRow,
            out DataRow CurrMissioneMovSpesaRow,
            //out DataTable MissioneMovSpesaView, 
            out int CurrCausaleMissione) {
            CurrCausaleMissione = 0;
            DataRow MiddleRow;
            MissioneRow = GetDocRow("itineration", "expenseitineration", fasemissione, out MiddleRow);
            CurrMissioneMovSpesaRow = MiddleRow;
            //MissioneMovSpesaView=null;
            if (MissioneRow == null) return;
            if (MiddleRow != null) CurrCausaleMissione = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(MissioneRow,
            //    DataRowVersion.Default,true);
            //string filter= GetData.MergeFilters(keyfilter,
            //    "(nphase="+QueryCreator.quotedstrvalue(fasemissione,true)+")"+
            //    "AND(ayear="+QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true)+")"
            //    );
            //MissioneMovSpesaView = MyConn.RUN_SELECT("itinerationexpensedownview","*",null,filter,null,true);
        }

        void GetDocCedolino(out DataRow CedolinoRow,
            out DataRow CurrCedolinoMovSpesaRow,
            //out DataTable CedolinoMovSpesaView, 
            out int CurrCausaleCedolino) {
            CurrCausaleCedolino = 0;
            DataRow MiddleRow;
            CedolinoRow = GetDocRow("payroll", "expensepayroll", fasecedolino, out MiddleRow);
            CurrCedolinoMovSpesaRow = MiddleRow;
            //CedolinoMovSpesaView=null;
            if (CedolinoRow == null) return;
            if (CedolinoRow != null) CurrCausaleCedolino = 4;
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(CedolinoRow,
            //    DataRowVersion.Default,true);
            //string filter= GetData.MergeFilters(keyfilter,
            //    "(nphase="+QueryCreator.quotedstrvalue(fasecedolino,true)+")"+
            //    "AND(ayear="+QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true)+")"
            //    );
            //CedolinoMovSpesaView = MyConn.RUN_SELECT("payrollexpensedownview","*",null,filter,null,true);
        }

        void GetDocOrdine(out DataRow OrdineRow,
            out DataRow CurrOrdineGenericoMovSpesaRow,
            //out DataTable OrdineGenericoMovSpesaView, 
            out int CurrCausaleOrdine) {
            CurrCausaleOrdine = 0;
            DataRow MiddleRow;
            OrdineRow = GetDocRow("mandate", "expensemandate", faseordine, out MiddleRow);
            CurrOrdineGenericoMovSpesaRow = MiddleRow;
            //OrdineGenericoMovSpesaView=null;
            if (OrdineRow == null) return;
            if (MiddleRow != null) CurrCausaleOrdine = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(OrdineRow,
            //    DataRowVersion.Default,
            //    true);
            //OrdineGenericoMovSpesaView = MyConn.RUN_SELECT("expensemandateview","*",null,keyfilter,null,true);
        }

        void GetDocOccasionale(out DataRow OccasionaleRow,
            out DataRow CurrOccasionaleMovSpesaRow,
            //out DataTable OccasionaleMovSpesaView, 
            out int CurrCausaleOccasionale) {
            CurrCausaleOccasionale = 0;
            DataRow MiddleRow;
            OccasionaleRow = GetDocRow("casualcontract", "expensecasualcontract", faseoccasionale, out MiddleRow);
            CurrOccasionaleMovSpesaRow = MiddleRow;
            //OccasionaleMovSpesaView=null;
            if (OccasionaleRow == null) return;
            if (OccasionaleRow != null) CurrCausaleOccasionale = 4;
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(OccasionaleRow,
            //    DataRowVersion.Default,true);
            //string filter= GetData.MergeFilters(keyfilter,
            //    "(nphase="+QueryCreator.quotedstrvalue(faseoccasionale,true)+")"+
            //    "AND(ayear="+QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true)+")"
            //    );
            //OccasionaleMovSpesaView = MyConn.RUN_SELECT("casualcontractexpensedownview","*",null,filter,null,true);
        }

        void GetDocProfessionale(out DataRow ProfessionaleRow,
            out DataRow CurrProfessionaleMovSpesaRow,
            //out DataTable ProfessionaleMovSpesaView, 
            out int CurrCausaleProfessionale) {
            CurrCausaleProfessionale = 0;
            DataRow MiddleRow;
            ProfessionaleRow = GetDocRow("profservice", "expenseprofservice", faseprofessionale, out MiddleRow);
            CurrProfessionaleMovSpesaRow = MiddleRow;
            //ProfessionaleMovSpesaView=null;
             if (ProfessionaleRow == null) return;
            if (MiddleRow != null) CurrCausaleProfessionale = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(ProfessionaleRow,
            //    DataRowVersion.Default,true);
            //string filter= GetData.MergeFilters(keyfilter,
            //    "(nphase="+QueryCreator.quotedstrvalue(faseprofessionale,true)+")"+
            //    "AND(ayear="+QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true)+")"
            //    );
            //ProfessionaleMovSpesaView = MyConn.RUN_SELECT("profserviceexpensedownview","*",null,filter,null,true);
        }

        void GetDocDipendente(out DataRow DipendenteRow,
            out DataRow CurrDipendenteMovSpesaRow,
            //out DataTable DipendenteMovSpesaView, 
            out int CurrCausaleDipendente) {
            CurrCausaleDipendente = 0;
            DataRow MiddleRow;
            DipendenteRow = GetDocRow("wageaddition", "expensewageaddition", fasedipendente, out MiddleRow);
            CurrDipendenteMovSpesaRow = MiddleRow;
            //DipendenteMovSpesaView=null;
            if (DipendenteRow == null) return;
            if (MiddleRow != null) CurrCausaleDipendente = 4;
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(DipendenteRow,
            //    DataRowVersion.Default,true);
            //string filter= GetData.MergeFilters(keyfilter,
            //    "(nphase="+QueryCreator.quotedstrvalue(fasedipendente,true)+")"+
            //    "AND(ayear="+QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"),true)+")"
            //    );
            //DipendenteMovSpesaView = MyConn.RUN_SELECT("wageadditionexpensedownview","*",null,filter,null,true);
        }

        void GetDocIva(out DataRow IvaRow,
            out DataRow CurrIvaMovSpesaRow,
            //out DataTable IvaMovSpesaView, 
            out int CurrCausaleIva) {
            CurrCausaleIva = 0;
            DataRow MiddleRow;
            IvaRow = GetDocRow("invoice", "expenseinvoice", faseiva, out MiddleRow);
            CurrIvaMovSpesaRow = MiddleRow;
            //IvaMovSpesaView=null;
            if (IvaRow == null) return;
            if (MiddleRow != null) CurrCausaleIva = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(IvaRow,
            //    DataRowVersion.Default,
            //    true);
            //IvaMovSpesaView = MyConn.RUN_SELECT("expenseinvoiceview","*",null,keyfilter,null,true);
        }



        /// <summary>
        /// Restituisce il documento contabilizzato con il movimento corrente
        /// </summary>
        /// <param name="tablename">nome tabella documento</param>
        /// <param name="middletablename">nome tabella intermedia del DataSet</param>
        /// <param name="faseattivazione">fase di contabilizzazione del documento</param>
        /// <param name="CurrMiddleDocRow">Riga intermedia associata a questo movimento</param>
        /// <returns>Documento contabilizzato dal movimento corrente</returns>
        DataRow GetDocRow(string tablename, string middletablename,
            int faseattivazione,
            out DataRow CurrMiddleDocRow
        ) {
            CurrMiddleDocRow = null;
            if (Meta.IsEmpty) return null;
            string movimentotable = "expense";
            if (currphase == faseattivazione) {
                //Se la fase attivazione � inclusa nel range, � possibile che 
                // il documento sia stato selezionato e sia in memoria, oppure che non 
                // sia stato selezionato il documento e quindi non ci sono righe
                if (DS.Tables[tablename].Rows.Count == 0) return null;
                CurrMiddleDocRow = DS.Tables[middletablename].Rows[0];
                return DS.Tables[tablename].Rows[0];
            }
            else {
                //Se la fase attivazione � successiva al range, non pu� esistere alcun 
                // documento collegato
                if (currphase <= faseattivazione) return null;

                //L'unico caso rimasto � che la faseattivazione � precedente al range

                //Se � stato selezionato un livsupid, � possibile partire da quello come
                // base per selezionare il giusto movimento di fase precedente.
                DataRow Curr = DS.expense.Rows[0];
                object livsupid = Curr["parentid" + movimentotable.Substring(0, 3)];
                if (livsupid == DBNull.Value) return null;
                object idattivazione = MyConn.DO_READ_VALUE(movimentotable + "link",
                    QHS.AppAnd(QHS.CmpEq("idchild", livsupid),
                        QHS.CmpEq("nlevel", faseattivazione)), "idparent");
                if (idattivazione == null) return null;
                if (idattivazione == DBNull.Value) return null;
                DataTable Middle = MyConn.RUN_SELECT(middletablename, "*", null,
                    QHS.CmpEq("id" + movimentotable.Substring(0, 3), idattivazione),
                    null, true);
                if (Middle.Rows.Count == 0) return null;
                CurrMiddleDocRow = Middle.Rows[0];
                DataTable Doc = DS.Tables[tablename];
                string dockeyfilter = QueryCreator.WHERE_REL_CLAUSE(CurrMiddleDocRow,
                    Doc.PrimaryKey, Doc.PrimaryKey, DataRowVersion.Default, true);
                DataTable Documento = MyConn.RUN_SELECT(tablename, "*", null, dockeyfilter, null, true);
                if (Documento.Rows.Count == 0) return null; //non dovrebbe accadere
                return Documento.Rows[0];

            }
        }

        #endregion


        #region Gestione Selezione Documento Iva 

        string FilterIva;

        //		void AbilitaDisabilitaBtnOrdine(){
        //			bool SelezioneOrdineAttiva = ((Meta.IsEmpty)||(Meta.InsertMode));
        //			btnOrdine.Enabled=  SelezioneOrdineAttiva;
        //			txtNumOrdine.ReadOnly= !SelezioneOrdineAttiva;
        //			txtEsercOrdine.ReadOnly= !SelezioneOrdineAttiva;
        //			cmbCausale.Enabled= Meta.InsertMode && (txtNumOrdine.Text.Trim()!="");
        //			txtCredDeb.ReadOnly = !Meta.IsEmpty;
        //		}

        private void txtEsercIva_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
            //CalcolaStartFilter(null);
        }

        string GetFilterIva(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            FilterIva = "(yinv<='" + esercizio.ToString() + "')";
            if (txtEsercDoc.Text != "") {
                int esercdocumento = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (esercdocumento <= esercizio)
                        FilterIva = "(yinv='" + esercdocumento.ToString() + "')";
                    else
                        FilterIva = GetData.MergeFilters(FilterIva,
                            "(yinv='" + esercdocumento.ToString() + "')");
                }
                catch {
                }
            }

            if (FiltraNum) {
                int numdocumento = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterIva = GetData.MergeFilters(FilterIva,
                        "(ninv='" + numdocumento.ToString() + "')");
                }
            }

            string filtertipodoc;
            if (cmbTipoDocumento.SelectedIndex <= 0) {
                filtertipodoc = QHS.AppAnd(QHS.BitClear("flag", 0), QHS.BitClear("flag", 2));
            }
            else {
                filtertipodoc = "(idinvkind=" +
                                QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue, true) + ")";
            }

            FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

            if (Meta.InsertMode) {
                FilterIva += "AND(residual>'0')AND((active is null)OR(active='S'))";
                if (ProfessionaleLinked != null) {
                    FilterIva = QHS.AppAnd(FilterIva, QHS.CmpKey(ProfessionaleLinked));
                }
                else {
                    if (!monofase) {
                        FilterIva = QHS.AppAnd(FilterIva, QHS.IsNull("ycon"));
                    }
                }
            }

            return FilterIva;
        }


        private void btnIva_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);
            string MyIvaFilter;
            string MyFilterDocumentoIva;
            string MyFilterIvaOperativo;
            if (((Control) sender).Name == "txtNumDoc")
                MyIvaFilter = GetFilterIva(true);
            else
                MyIvaFilter = GetFilterIva(false);

            MyFilterDocumentoIva = MyIvaFilter;
            MyFilterIvaOperativo = MyIvaFilter;

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                //int lenidimpegno=faseordine*8;
                object parid = Curr["parentidexp"];
                //if (faseprecselected){
                //    DataTable MandateCont= Conn.RUN_SELECT("expensemandate","*",null,
                //        "('"+parid+"' LIKE idexp+'%')",null,null,false);
                //    if (MandateCont.Rows.Count>0){
                //        MyFilterDocumentoIva=GetData.MergeFilters(MyFilterDocumentoIva,
                //            "('"+parid+"' LIKE idexp_ivamand+'%' or '"+parid+"' LIKE idexp_taxablemand+'%')");
                //    }
                //    else {
                //        MyFilterDocumentoIva=GetData.MergeFilters(MyFilterDocumentoIva,
                //            "(idexp_ivamand is null and idexp_taxablemand is null)");
                //    }

                //}
                if ((condfasecred && faseprecselected) ||
                    ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != ""))
                ) {
                    MyFilterDocumentoIva = GetData.MergeFilters(MyFilterDocumentoIva,
                        "(idreg=" +
                        QueryCreator.quotedstrvalue(Curr["idreg"], true) + ")");
                    MyFilterIvaOperativo = GetData.MergeFilters(MyFilterIvaOperativo,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

//				if ((txtCredDeb.ReadOnly==false) && (txtCredDeb.Text.Trim()!="")){
//					DataRow Cred=DS.registry.Rows[0];
//					MyFilterDocumentoIva = GetData.MergeFilters(MyFilterDocumentoIva,
//						"(idreg="+
//						QueryCreator.quotedstrvalue(Cred["idreg"],true)+")");
//					MyFilterIvaOperativo= GetData.MergeFilters(MyFilterIvaOperativo,
//						"(registry="+
//						QueryCreator.quotedstrvalue(Cred["title"],true)+")");
//				}
                bool condfaseupb = (ManageUPB.faseattivazione < currphase);
                object getupb = GetUpb();
                if ((condfaseupb && faseprecselected) ||
                    (getupb != DBNull.Value && txtUPB.Enabled)) {
                    object idupb = getupb;
                    MyFilterIvaOperativo = QHS.AppAnd(MyFilterIvaOperativo,
                        QHS.DoPar(QHS.AppOr(QHS.IsNull("idupb"), QHS.CmpEq("idupb", idupb),
                            QHS.CmpEq("idupb_iva", idupb))));

                }

            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyFilterIvaOperativo = GetData.MergeFilters(MyFilterIvaOperativo,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MDocumentoIva;
            DataRow MyDRIva;

            if (Meta.IsEmpty) {
                MDocumentoIva = MetaData.GetMetaData(this, "invoiceexpenselinked");
                MDocumentoIva.FilterLocked = true;
                MDocumentoIva.DS = new DataSet(); // DS.Clone();
                MyDRIva = MDocumentoIva.SelectOne("default", MyFilterDocumentoIva, null, null);
                if (MyDRIva == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                TipoDocChangePilotato = true;
                HelpForm.SetComboBoxValue(cmbTipoDocumento, MyDRIva["idinvkind"]);
                TipoDocChangePilotato = false;
                txtEsercDoc.Text = MyDRIva["yinv"].ToString();
                txtNumDoc.Text = MyDRIva["ninv"].ToString();
                return;
            }

            MDocumentoIva = MetaData.GetMetaData(this, "invoiceresidualmandate");
            MDocumentoIva.FilterLocked = true;
            MDocumentoIva.DS = new DataSet(); //DS.Clone();

            MyDRIva = MDocumentoIva.SelectOne("default", MyFilterIvaOperativo, null, null);

            if (MyDRIva == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectord =
                "(idinvkind=" + QueryCreator.quotedstrvalue(MyDRIva["idinvkind"], true) + ")AND" +
                "(yinv='" + MyDRIva["yinv"].ToString() + "')AND" +
                "(ninv='" + MyDRIva["ninv"].ToString() + "')";


            string columnlist = QueryCreator.ColumnNameList(DS.invoice) +
                                ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("invoiceview", columnlist, null, selectord, null, null, false);

            if (Temp == null) return;
            if (Temp.Rows.Count == 0) return;

            DataRow MyDR = Temp.Rows[0];

            if (Meta.InsertMode) {
                while (true) { //escamotage per impedire che il livello di indentazione arrivi alle stelle
                    //Si collega all'impegno ove presente
                    object idexp_taxablemand = MyDRIva["idexp_taxablemand"];
                    object idexp_ivamand = MyDRIva["idexp_ivamand"];
                    if (idexp_taxablemand == DBNull.Value && idexp_ivamand == DBNull.Value) break;
                    DataRow Curr = DS.expense.Rows[0];
                    bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                    if (faseprecselected) break;
                    int precphase = currphase - 1;
                    if (precphase <= 0) break;
                    //int preclen = precphase*8;
                    string filterprec = "(nphase='" + precphase + "')" +
                                        GetFilterIdExpmand(idexp_ivamand, idexp_taxablemand)
                                        + "and(available>0)";

                    MetaData MFase = MetaData.GetMetaData(this, "expenseview");
                    MFase.FilterLocked = true;
                    MFase.DS = DS;

                    int NEXP = Meta.Conn.RUN_SELECT_COUNT("expenseview", filterprec, false);
                    if (NEXP == 0) {
                        show("Non � stato trovato un movimento di spesa a cui agganciare questo pagamento," +
                                        " ai fini di una corretta associazione impegno ordine-pagamento fattura.");
                        break;
                    }

                    DataRow MyDR2 = null;

                    while (MyDR2 == null) {
                        if (NEXP > 1)
                            show(
                                "E' ora necessario scegliere il mov. di spesa a cui agganciare questo pagamento," +
                                " ai fini di una corretta associazione impegno ordine-pagamento fattura.");
                        MyDR2 = MFase.SelectOne("elencofaseprec", filterprec, null, null);
                    }

                    txtNumeroFasePrecedente.Text = MyDR2["nmov"].ToString();
                    txtEsercizioFasePrecedente.Text = MyDR2["ymov"].ToString();
                    btnFasePrecedente_Click(txtNumeroFasePrecedente, null);
                    break;
                }

            }

            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetIva();
                CollegaIva(MyDR, MyDRIva);
                CollegaTuttiDettagliFattura();

                RintracciaIva();
                ResetTipoClassAvailableEvalued();
            }

            AbilitaDisabilitaControlliFattura(true);


        }

        string GetFilterIdExpmand(object idexp1, object idexp2) {
            string result = "";
            if (idexp1 != DBNull.Value) {
                //result="idexp like '"+idexp1+"%' ";
                result = "(idexp in (select idchild from expenselink where idparent=" +
                         QueryCreator.quotedstrvalue(idexp1, true) + "))";
            }

            if (idexp2 != DBNull.Value) {
                if (result != "") result += " or ";
                //result += "idexp like '" + idexp2 + "%' ";
                result += "(idexp in (select idchild from expenselink where idparent=" +
                          QueryCreator.quotedstrvalue(idexp2, true) + "))";
            }

            if (result != "") result = "AND(" + result + ")";
            return result;
        }


        private void txtNumIva_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;
            //CalcolaStartFilter(null);


            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) ScollegaIva(true);
                ClearControlliIva(true);
                int fasecred = ManageCreditore.faseattivazione;
                if (fasecred < currphase) return;
                txtCredDeb.Text = "";
                return;
            }


            btnIva_Click(sender, e);
        }

        void ClearControlliIva(bool skipTipoDoc) {
            //txtCredDeb.Text = "";		
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            //cmbResponsabile.SelectedIndex=0;
            if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex = -1;
            AbilitaDisabilitaCreditoreDebitore(true);
        }


        /*
        void AbilitaDisabilitaControlliIva(bool abilita){
            AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }
        */

        void VisualizzaMainInfo_Iva(DataRow Iva2) {

            if (!faseIvaInclusa()) return;
            gboxDettInvoice.Visible = true;
            cmbTipoDocumento.Tag =
                "expenseinvoice.idinvkind?" +
                "expenseinvoiceview.idinvkind";

            txtNumDoc.Text = Iva2["ninv"].ToString();
            txtEsercDoc.Text = Iva2["yinv"].ToString();
            ImpostaComboInvoiceKind();
            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, Iva2["idinvkind"]);
            TipoDocChangePilotato = false;
        }

        /// <summary>
        /// Collega la riga al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        void CollegaIva(DataRow Iva2, DataRow IvaResiduo) {
            if (Meta.IsEmpty) return;
            if (!faseIvaInclusa()) return;

            Hashtable ValoriDocumentoIva = new Hashtable();
            foreach (DataColumn C in Iva2.Table.Columns)
                ValoriDocumentoIva[C.ColumnName] = Iva2[C.ColumnName];

            ScollegaIva();

            gboxDettInvoice.Visible = true;

            DataRow NewIvaR = DS.invoice.NewRow();

            foreach (DataColumn C in DS.invoice.Columns) {
                NewIvaR[C.ColumnName] = ValoriDocumentoIva[C.ColumnName];
            }

            DS.invoice.Rows.Add(NewIvaR);
            NewIvaR.AcceptChanges();

            DataRow CurrRow = DS.expense.Rows[0];
            DataRow CurrImpRow = DS.expenseyear.Rows[0];
            MetaData MovIva = MetaData.GetMetaData(this, "expenseinvoice");
            MovIva.SetDefaults(DS.expenseinvoice);
            DS.expenseinvoice.Columns["idinvkind"].DefaultValue = ValoriDocumentoIva["idinvkind"];
            DS.expenseinvoice.Columns["ninv"].DefaultValue = ValoriDocumentoIva["ninv"];
            DS.expenseinvoice.Columns["yinv"].DefaultValue = ValoriDocumentoIva["yinv"];
            txtNumDoc.Text = ValoriDocumentoIva["ninv"].ToString();
            txtEsercDoc.Text = ValoriDocumentoIva["yinv"].ToString();
            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, ValoriDocumentoIva["idinvkind"]);
            TipoDocChangePilotato = false;

            DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.expenseinvoice);
            DS.expenseinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
            DS.expenseinvoice.Columns["ninv"].DefaultValue = DBNull.Value;
            DS.expenseinvoice.Columns["yinv"].DefaultValue = DBNull.Value;


            CurrRow["idreg"] = ValoriDocumentoIva["idreg"];
            CurrRow["description"] = ValoriDocumentoIva["description"];
            txtDescrizione.Text = ValoriDocumentoIva["description"].ToString();


            CurrRow["doc"] = ValoriDocumentoIva["doc"];
            txtDocumento.Text = ValoriDocumentoIva["doc"].ToString();
            CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
            txtDataDocumento.Text =
                HelpForm.StringValue(ValoriDocumentoIva["docdate"], txtDataDocumento.Tag.ToString());
            //CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
            //HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != ValoriDocumentoIva["idreg"].ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (IvaResiduo["idupb"] != DBNull.Value && IvaResiduo["idupb_iva"] == DBNull.Value) {
                SetUPB(IvaResiduo["idupb"]);
            }
            else {
                CurrImpRow["idupb"] = GetUpb();
            }


            //Meta.myHelpForm.FillControls(tabMovFin.Controls);
            IvaLinkedMustBeEvalued = true;
            RintracciaIva();
            SetComboCausaleIva(IvaResiduo);
            //AbilitaDisabilitaControlliIva(false);
            AbilitaDisabilitaCreditoreDebitore(false);
            if ((monofase) && (ProfessionaleLinked!=null)) {
                AbilitaDisabilitaControlliProfessionale(false);
            }
        }

        object LeggiDaCombo(ComboBox C) {
            if ((C.SelectedValue == null) || (C.SelectedIndex <= 0)) {
                return DBNull.Value;
            }
            else {
                return C.SelectedValue;
            }
        }

        void ScollegaIva() {
            ValorizzaFlagCertificati(null, false);
            ScollegaIva(false);
        }

        void ScollegaIva(bool skiptipodoc) {
            gboxDettInvoice.Visible = false;
            ResetIva();
            if (DS.expenseinvoice.Rows.Count == 0) return;
            DS.invoicedetail_iva.Clear();
            DS.invoicedetail_taxable.Clear();
            DS.expenseinvoice.Clear();
            DS.invoice.Clear();
            if ((monofase) && ProfessionaleLinked!=null){
                ClearControlliProfessionale();
                DS.expensetax.Clear();
                DS.expensetaxcorrige.Clear();
                DS.expensetaxofficial.Clear();
                ClearPrestazioni();
                //AbilitaDisabilitaControlliProfessionale(true);
                AbilitaDisabilitaCreditoreDebitore(true);
            }
            ClearComboCausale();
            DataRow CurrRow = DS.expense.Rows[0];
            DataRow CurrImpRow = DS.expenseyear.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
                DS.registry.Clear();
            }

            if (fasecreditore < currphase && txtNumeroFasePrecedente.Text == "") {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
                DS.registry.Clear();
            }

            int faseupb = ManageUPB.faseattivazione;
            if (faseupb < currphase && txtNumeroFasePrecedente.Text == "") {
                SetUPB(DBNull.Value);
            }

            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            //CurrRow["codiceresponsabile"]=DBNull.Value;
            CurrRow["description"] = "";
            ClearControlliIva(skiptipodoc);
        }

        string CalculateFilterForInvoiceDetailLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
            string filter_insideA = "";
            string filter_insideB = "";
            object idreg = DS.expense.Rows[0]["idreg"];
            //object idupb = DS.expenseyear.Rows[0]["idupb"];
            object idupb = GetUpb();


            MyFilter = qh.AppAnd(MyFilter, qh.MCmp(IvaLinked, "idinvkind", "yinv", "ninv"));
            if (monofase & (ProfessionaleLinked != null)) {
                string filterprestazione = QHS.AppAnd(QHS.CmpEq("ycon", ProfessionaleLinked["ycon"]), 
                    QHS.CmpEq("ncon", ProfessionaleLinked["ncon"]));
                MyFilter = QHS.AppAnd(MyFilter, filterprestazione);
            }
            //if (ProfessionaleLinked != null) {
            //    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpKey(ProfessionaleLinked));
            //}

            if (idupb != DBNull.Value) {
                if (CurrCausaleIva == 1) {
                    //totale, prende upb standard
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }

                if (CurrCausaleIva == 2) {
                    //IVA
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("isnull(idupb_iva,idupb)", idupb));
                }

                if (CurrCausaleIva == 3) {
                    //imponibile 
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }
            }

            bool filterparent = false;
            object parid = DBNull.Value;
            if (Meta.InsertMode) {
                DataRow Curr = DS.expense.Rows[0];
                filterparent = (Curr["parentidexp"] != DBNull.Value);
                if (filterparent) parid = Curr["parentidexp"];
            }

            if (CurrCausaleIva == 1) {
                //MyFilter+="AND (idexp_iva is null and idexp_taxable is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_iva"));
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_taxable"));

                if (filterparent) {
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idexp_taxablemand"));
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idexp_ivamand"));
                    filter_insideB = qh.CmpEq("idexp_ivamand", qh.Field("idexp_taxablemand"));
                    //MyFilter +=
                    //"AND ((idexp_taxablemand is null AND idexp_ivamand is null) " +
                    //" OR (idexp_ivamand = idexp_taxablemand ";

                    //" AND idexp_taxablemand in (SELECT idparent from expenselink where idchild=" +
                    //        QueryCreator.quotedstrvalue(parid, true) + ")" +
                    DataTable ExpenseLink = Meta.Conn.RUN_SELECT("expenselink", "idparent", null,
                        QHS.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(ExpenseLink.Select(), "idparent");

                    MyFilter = qh.AppAnd(MyFilter,
                        qh.DoPar(qh.AppOr(filter_insideA,
                            qh.AppAnd(filter_insideB, qh.FieldInList("idexp_taxablemand", lista)))));
                    //MyFilter += "))";
                }
            }

            if (CurrCausaleIva == 2) {
                //MyFilter+="AND (idexp_iva is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_iva"));
                if (filterparent) {
                    //MyFilter += "AND (idexp_ivamand is null OR ";
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idexp_ivamand"));

                    //" AND idexp_ivamand in (SELECT idparent from expenselink where idchild=" +
                    //QueryCreator.quotedstrvalue(parid, true) + ")" +
                    DataTable ExpenseLink = Meta.Conn.RUN_SELECT("expenselink", "idparent", null,
                        qh.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(ExpenseLink.Select(), "idparent");
                    //MyFilter = qh.AppAnd(MyFilter, qh.FieldInList("idexp_ivamand", lista));

                    MyFilter = qh.AppAnd(MyFilter,
                        qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idexp_ivamand", lista))));

                    //MyFilter += "))";
                }


                //if (filterparent) MyFilter += "AND (idexp_ivamand is null OR '" + parid + "' like idexp_ivamand +'%')";

            }

            if (CurrCausaleIva == 3) {
                //MyFilter+="AND (idexp_taxable is null)";
                //if (filterparent) MyFilter += "AND (idexp_taxablemand is null OR " +
                //       " idexp_taxablemand in (SELECT idparent from expenselink where idchild=" +
                //         QueryCreator.quotedstrvalue(parid, true) + ")" +
                // ")";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_taxable"));
                if (filterparent) {
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idexp_taxablemand"));
                    DataTable ExpenseLink = Meta.Conn.RUN_SELECT("expenselink", "idparent", null,
                        qh.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(ExpenseLink.Select(), "idparent");
                    MyFilter = qh.AppAnd(MyFilter,
                        qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idexp_taxablemand", lista))));
                }

                //if (filterparent) MyFilter += "AND (idexp_taxablemand is null OR '" + parid + "' like idexp_taxablemand +'%')";
            }

            //MyFilter+="AND (flagvariation ='N')";
            MyFilter = qh.AppAnd(MyFilter, qh.BitClear("flag", 2));
            if (ProfessionaleLinked != null) {
                MyFilter = QHS.AppAnd(MyFilter, qh.CmpKey(ProfessionaleLinked));
            }
            else {
                MyFilter = QHS.AppAnd(MyFilter, qh.IsNull("ycon"));
            }

            return MyFilter;
        }


        private void btnCollegaDettInvoice_Click(object sender, System.EventArgs e) {
            if (DS.config.Rows.Count == 0) return;

            if (MetaData.Empty(this)) return;
            if (IvaLinked == null) {
                show("E' necessario selezionare prima la fattura.");
                return;
            }

            MetaData.GetFormData(this, true);
            CurrCausaleIva = GetCausaleIva();
            string MyFilter = CalculateFilterForInvoiceDetailLinking(true);
            string tablename = "";
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
                tablename = "invoicedetail_taxable";
            }

            if (CurrCausaleIva == 2) {
                tablename = "invoicedetail_iva";
            }

            if (tablename == "") {
                show("E' necessario selezionare prima una causale", "Avviso");
                return;
            }

            string command = "choose." + tablename + ".listaspesa." + MyFilter;
            if (!MetaData.Choose(this, command)) return;
            if (CurrCausaleIva == 1) {
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliFattura();
        }


        private void btnModificaDettInvoice_Click(object sender, System.EventArgs e) {

            if (Meta.IsEmpty) return;
            if (IvaLinked == null) {
                show("E' necessario selezionare prima la fattura.");
                return;
            }

            Meta.GetFormData(true);
            DataTable ToLink = null;
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
                ToLink = DS.invoicedetail_taxable;
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "expenseinvoicedetail_taxable");
            }

            if (CurrCausaleIva == 2) {
                ToLink = DS.invoicedetail_iva;
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "expenseinvoicedetail_iva");
            }

            if (ToLink == null) {
                show("E' necessario selezionare prima la causale");
                return;
            }

            string MyFilter = CalculateFilterForInvoiceDetailLinking(false);
            string MyFilterSQL = CalculateFilterForInvoiceDetailLinking(true);
            Meta.MultipleLinkUnlinkRows("Selezione dettagli fattura",
                "Dettagli inclusi nel movimento corrente",
                "Dettagli non inclusi in alcun movimento",
                ToLink, MyFilter, MyFilterSQL, "listaspesa");
            if (CurrCausaleIva == 1) {
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliFattura();
        }

        private void btnScollegaDettInvoice_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (IvaLinked == null) {
                show("E' necessario selezionare prima la fattura.");
                return;
            }

            Meta.GetFormData(true);
            MetaData.Unlink_Grid(dgrDettagliFattura);
            if (CurrCausaleIva == 1) {
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliFattura();
        }

        decimal GetImportoDettagliFattura() {
            if (DS.invoice.Rows.Count == 0)
                return 0;
            decimal tassocambio;
            DataRow Fattura = DS.invoice.Rows[0];
            tassocambio = CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            decimal imponibile = 0;
            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            CurrCausaleIva = GetCausaleIva();
            if (CurrCausaleIva == 3) {
                ToConsider = DS.invoicedetail_taxable.Select("idexp_taxable is not null");
            }

            if (CurrCausaleIva == 2) {
                ToConsider = DS.invoicedetail_iva.Select("idexp_iva is not null");
            }

            if (CurrCausaleIva == 1) {
                ToConsider = DS.invoicedetail_taxable.Select("idexp_taxable is not null");
            }

            foreach (DataRow R in ToConsider) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                //decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]), 6);
                imponibile += CfgFn.RoundValuta((R_imponibile * R_quantitaConfezioni * (1 - R_sconto)) * tassocambio);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

            decimal totale = 0;

            if (CurrCausaleIva == 3) {
                totale = imponibile;
            }

            if (CurrCausaleIva == 2) {
                totale = imposta;
            }

            if (CurrCausaleIva == 1) {
                totale = imponibile + imposta;
            }

            return totale;

        }

        void CalcolaImportoInBaseADettagliFattura() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            tipocont currcont = ContabilizzazioneSelezionata();
            if (currcont != tipocont.cont_iva) return;
            CurrCausaleIva = GetCausaleIva();
            decimal totale = GetImportoDettagliFattura();
            SetImporto(totale);
            CalcTotInvoiceDetail();
            GeneraOAzzeraRecuperoSplitPayment();
            GeneraOAzzeraRecuperoIvaEstera();
        }

        decimal CalcolaIvaInBaseADettagliFattura() {
            if (Meta.IsEmpty) return 0;
            if (EsisteEsercPrecedente()) return 0;
            tipocont currcont = ContabilizzazioneSelezionata();
            if (currcont != tipocont.cont_iva) return 0;
            decimal iva = GetIVADettagliFattura();
            return iva;
        }

        decimal CalcolaIvaNoteDiCredito() {
            if (Meta.IsEmpty) return 0;
            tipocont currcont = ContabilizzazioneSelezionata();
            if (currcont != tipocont.cont_iva) return 0;
            decimal iva = GetIVANoteDiCredito();
            return iva;
        }

        decimal GetIVADettagliFattura() {
            if (DS.invoice.Rows.Count == 0)
                return 0;
            decimal tassocambio;
            DataRow Fattura = DS.invoice.Rows[0];
            tassocambio = CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;

            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            CurrCausaleIva = GetCausaleIva();

            if (CurrCausaleIva == 3) return 0;

            if (CurrCausaleIva == 2) {
                ToConsider = DS.invoicedetail_iva.Select("idexp_iva is not null");
            }

            if (CurrCausaleIva == 1) {
                ToConsider = DS.invoicedetail_taxable.Select("idexp_taxable is not null");
            }

            foreach (DataRow R in ToConsider) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

            return imposta;

        }

        bool VerificaNoteDiCreditoNonContabilizzate() {

            if (DS.invoice.Rows.Count == 0) return false;
            CurrCausaleIva = GetCausaleIva();

            string filter = null;
            DataRow Curr = DS.expense.Rows[0];
            object idreg = Curr["idreg"];
            if (CurrCausaleIva == 3) return false;

            filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.IsNull("idexp_iva"), QHS.IsNull("idexp_taxable"),
                QHS.BitSet("flag", 2));

            DataTable invoicedetailview =
                Meta.Conn.RUN_SELECT("invoicedetailview", "*", null, filter, null, null, false);
            return false;

        }

        decimal GetIVANoteDiCredito() {
            //if (Meta.InsertMode) return 0;
            if (DS.invoice.Rows.Count == 0)
                return 0;
            decimal tassocambio;
            DataRow Fattura = DS.invoice.Rows[0];
            tassocambio = CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;

            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            CurrCausaleIva = GetCausaleIva();

            DataRow Curr = DS.expense.Rows[0];
            string filter = null;

            if (CurrCausaleIva == 3) return 0;

            if (CurrCausaleIva == 2) {
                ToConsider = DS.invoicedetail_iva_nc.Select("idexp_iva is not null");

            }

            if (CurrCausaleIva == 1) {
                ToConsider = DS.invoicedetail_taxable_nc.Select("idexp_taxable is not null");
            }
            foreach (DataRow R in ToConsider) {
                if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

           

            return imposta;

        }

        void SvuotaDettagliFattura() {
            if (Meta.EditMode) return;
            if (EsisteEsercPrecedente()) return;
            DS.invoicedetail_taxable.Clear();
            DS.invoicedetail_iva.Clear();
            CalcTotInvoiceDetail();

        }

        void CollegaTuttiDettagliFattura() {
            if (DS.invoice.Rows.Count == 0) return;
            CurrCausaleIva = GetCausaleIva();
            string filter = CalculateFilterForInvoiceDetailLinking(true);
            DS.invoicedetail_iva.Clear();
            DS.invoicedetail_taxable.Clear();
            object idexp = DS.expense.Rows[0]["idexp"];
            if (CurrCausaleIva == 1) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
                    R["idexp_taxable"] = idexp;
                    R["idexp_iva"] = idexp;
                }

                GetData.CalculateTable(DS.invoicedetail_taxable);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "expenseinvoicedetail_taxable");
            }

            if (CurrCausaleIva == 3) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
                    R["idexp_taxable"] = idexp;
                }

                GetData.CalculateTable(DS.invoicedetail_taxable);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "expenseinvoicedetail_taxable");
            }

            if (CurrCausaleIva == 2) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva, null, filter, null, true);
                foreach (DataRow R in DS.invoicedetail_iva.Rows) {
                    R["idexp_iva"] = idexp;
                }

                GetData.CalculateTable(DS.invoicedetail_iva);
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "expenseinvoicedetail_iva");
            }

            CalcolaImportoInBaseADettagliFattura();

            if ((DS.invoicedetail_iva.Rows.Count == 0) && (DS.invoicedetail_taxable.Rows.Count == 0)) {
                show("Non sono stati trovati dettagli coerenti con UPB e Causale selezionati.");
                return;
            }
        }


        #endregion

        #region Gestione ComboBox Causale Iva


        decimal totimponibile_dociva;
        decimal totiva_dociva;
        decimal assigned_imponibile_dociva;
        decimal assigned_iva_dociva;
        decimal assigned_gen_dociva;



        void SetEditComboCausaleIva() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
            EnableTipoMovimento(3, "Contabilizzazione imponibile documento");
            EnableTipoMovimento(2, "Contabilizzazione iva documento");
            //cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
            object currtipo = DS.Tables["expenseinvoice"].Rows[0]["movkind"];
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);

        }





        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleIva(DataRow Iva) {
            if (!faseIvaInclusa()) return;
            string MyFilter_taxable = "";
            string MyFilter_iva = "";

            DataAccess Conn = Meta.Conn;
            object parid = DBNull.Value;
            if (Meta.InsertMode) {
                DataRow Curr = DS.expense.Rows[0];
                parid = Curr["parentidexp"];
            }

            bool EnableImpon = true;
            bool EnableImpos = true;
            bool EnableDocum = true;

            DataRow R = Iva;
            totimponibile_dociva = CfgFn.GetNoNullDecimal(R["taxabletotal"]);
            totiva_dociva = CfgFn.GetNoNullDecimal(R["ivatotal"]);
            MyFilter_taxable = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idexp_taxablemand"]));
            MyFilter_iva = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idexp_ivamand"]));

            //EnableImpon = (R["idexp_taxablemand"] == DBNull.Value ||
            //    (parid != DBNull.Value && (R["idexp_ivamand"].ToString() == R["idexp_taxablemand"].ToString()) &&
            //       Conn.RUN_SELECT_COUNT("expenselink",
            //            "(idchild=" + QueryCreator.quotedstrvalue(parid, true) + ")AND" +
            //            "(idparent=" + QueryCreator.quotedstrvalue(R["idexp_taxablemand"], true) + ")", false) > 0));

            EnableImpon = (R["idexp_taxablemand"] == DBNull.Value ||
                           (parid != DBNull.Value &&
                            Conn.RUN_SELECT_COUNT("expenselink", MyFilter_taxable, false) > 0) ||
                           R["idexp_ivamand"].Equals(R["idexp_taxablemand"]));


            //EnableImpos = (R["idexp_ivamand"] == DBNull.Value ||
            //    (parid != DBNull.Value && (R["idexp_ivamand"].ToString() == R["idexp_taxablemand"].ToString()) &&
            //       Conn.RUN_SELECT_COUNT("expenselink",
            //            "(idchild=" + QueryCreator.quotedstrvalue(parid, true) + ")AND" +
            //            "(idparent=" + QueryCreator.quotedstrvalue(R["idexp_ivamand"], true) + ")", false) > 0));

            EnableImpos = (R["idexp_ivamand"] == DBNull.Value ||
                           (parid != DBNull.Value && Conn.RUN_SELECT_COUNT("expenselink", MyFilter_iva, false) > 0) ||
                           R["idexp_ivamand"].Equals(R["idexp_taxablemand"]));

            //EnableDocum = (R["idexp_taxablemand"].ToString() == R["idexp_ivamand"].ToString());
            EnableDocum = R["idexp_ivamand"].Equals(R["idexp_taxablemand"]);




            assigned_imponibile_dociva = CfgFn.GetNoNullDecimal(R["linkedimpon"]);
            assigned_iva_dociva = CfgFn.GetNoNullDecimal(R["linkedimpos"]);
            assigned_gen_dociva = CfgFn.GetNoNullDecimal(R["linkeddocum"]);


            string filteriva = QHS.AppAnd(QHS.CmpEq("idinvkind", Iva["idinvkind"]),
                QHS.CmpEq("yinv", Iva["yinv"]), QHS.CmpEq("ninv", Iva["ninv"]));

            string filter_idupbivaset = QHS.AppAnd(filteriva, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);


            decimal all_assigned_imponibile_dociva = 0;
            decimal all_assigned_iva_dociva = 0;
            decimal all_assigned_gen_dociva = 0;
            bool intracom = false;
            bool recuperoIvaEstera = false;
            DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filteriva, null, true);
            if ((T != null) && (T.Rows.Count > 0)) {
                //DataRow R=T.Rows[0];
                //totimponibile=CfgFn.GetNoNullDecimal(R["taxabletotal"]);
                //totiva=CfgFn.GetNoNullDecimal(R["ivatotal"]);
                foreach (DataRow Dett in T.Rows) {
                    all_assigned_imponibile_dociva += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    all_assigned_iva_dociva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    all_assigned_gen_dociva += CfgFn.GetNoNullDecimal(Dett["linkeddocum"]);
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                    int flag = CfgFn.GetNoNullInt32(Dett["flagbit"]);
                    if ((flag & 64) != 0) {
                        recuperoIvaEstera = true;
                    }
                }
            }


            if ((intracom) && (!recuperoIvaEstera)) {
                EnableDocum = false;
                EnableImpos = false;
            }

            if (n_idupbivaset > 0) {
                EnableDocum = false;
            }

            ClearComboCausale();
            object currIdInvKind = R["idinvkind"];
            DataRow Fattura = DS.invoice.Rows[0];


            int nVen = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " +
                QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "V")
                  )));

            int nAcq = CfgFn.GetNoNullInt32(Conn.DO_SYS_CMD(
             "select count(*) from invoicekindregisterkind IIRK " +
             " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
             " where " +
             QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A")
               )));


            //Nota di credito liquidata Split Payment, pu� essere contabilizzato solo imponibile
            if ((Fattura["flag_enable_split_payment"].ToString() == "S") && (nVen > 0) && (nAcq == 0)) {
                EnableDocum = false;
                EnableImpos = false;
            }
            DataTable TCombo = DS.tipomovimento;
            if ((Meta.EditMode) ||
                ((EnableDocum && (all_assigned_imponibile_dociva + all_assigned_iva_dociva) == 0) &&
                 (assigned_gen_dociva < (totimponibile_dociva + totiva_dociva)))
            ) {
                EnableTipoMovimento(1, "Contabilizzazione importo totale documento");
            }

            if ((Meta.EditMode) ||
                (EnableImpon && (all_assigned_gen_dociva == 0) && (assigned_imponibile_dociva < totimponibile_dociva))
            ) {
                EnableTipoMovimento(3, "Contabilizzazione imponibile documento");
            }

            if ((Meta.EditMode) ||
                (EnableImpos && (all_assigned_gen_dociva == 0) && (assigned_iva_dociva < totiva_dociva))
            ) {
                EnableTipoMovimento(2, "Contabilizzazione iva documento");
            }

            DS.expenseinvoice.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                ? cmbCausale.SelectedValue
                : DBNull.Value;
            cmbCausale.Enabled = (!(Meta.EditMode)) & (ProfessionaleLinked == null);
            ReCalcImporto_Iva();

        }


        void AbilitaDisabilitaControlliFattura(bool abilita) {
            bool abilitagrid = abilita && faseIvaInclusa();
            btnAddDettInvoice.Enabled = abilitagrid;
            btnRemoveDettInvoice.Enabled = abilitagrid;
            btnEditInvDet.Enabled = abilitagrid;
            gboxDettInvoice.Visible = abilitagrid;
            CurrCausaleIva = GetCausaleIva();
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
                dgrDettagliFattura.Tag = "invoicedetail_taxable.listaimpon";
                dgrDettagliFattura.TableStyles.Clear();
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_taxable);
                if (Meta.EditMode) DS.invoicedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
            }

            if (CurrCausaleIva == 2) {
                dgrDettagliFattura.TableStyles.Clear();
                dgrDettagliFattura.Tag = "invoicedetail_iva.listaimpos";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_iva);
                if (Meta.EditMode) DS.invoicedetail_taxable.Clear(); //Importante per evitare problemi in fase di delete
            }


        }



        void ReCalcImporto_Iva() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            //string tipomovimento = cmbCausale.SelectedValue.ToString();

            decimal importo = GetImportoDettagliFattura();
//			if (tipomovimento==2){
//				importo= totiva_dociva-assigned_iva_dociva;
//			}
//			if (tipomovimento==3){
//				importo= totimponibile_dociva-assigned_imponibile_dociva;
//			}
//			if (tipomovimento==1){
//				importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
//			}

            if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
                show("Sar� effettuata una contabilizzazione di importo inferiore poich� la " +
                                "disponibilit� del movimento selezionato � inferiore a " + importo.ToString());
                importo = DisponibileDaFasePrecedente;
            }

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");

        }

        private void cmbCausaleIva_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.InsertMode) return;

            GetCausaleIva();
            SvuotaDettagliFattura();
            CollegaTuttiDettagliFattura();
            ReCalcImporto_Iva();
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
                dgrDettagliFattura.Tag = "invoicedetail_taxable.listaimpon";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_taxable);
            }

            if (CurrCausaleIva == 2) {
                dgrDettagliFattura.Tag = "invoicedetail_iva.listaimpos";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_iva);
            }

        }


        int GetCausaleIva() {
            CurrCausaleIva = 0;
            //if (!Meta.InsertMode) return "";
            if (DS.expenseinvoice.Rows.Count == 0) return 0;
            if (!Meta.DrawStateIsDone) {
                if (DS.expenseinvoice.Rows[0]["movkind"] != DBNull.Value)
                    CurrCausaleIva = CfgFn.GetNoNullInt32(DS.expenseinvoice.Rows[0]["movkind"]);
                else
                    CurrCausaleIva = 0;
                return CurrCausaleIva;
            }

            if (cmbCausale.SelectedValue != null)
                DS.expenseinvoice.Rows[0]["movkind"] = cmbCausale.SelectedValue;
            else
                DS.expenseinvoice.Rows[0]["movkind"] = DBNull.Value;
            CurrCausaleIva = CfgFn.GetNoNullInt32(DS.expenseinvoice.Rows[0]["movkind"]);
            return CurrCausaleIva;
            //ReCalcImporto();
        }


        void UpdateComboCausaleIva() {
            if (IvaMovSpesaLinked != null) {
                object currtipo = IvaMovSpesaLinked["movkind"];
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }


        bool TipoDocChangePilotato = false;

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (TipoDocChangePilotato) return;
            TipoDocChangePilotato = true;
            if (Meta.InsertMode) ScollegaIva(true);
            ClearControlliIva(true);
            txtEsercDoc.Text = "";
            txtNumDoc.Text = "";
            TipoDocChangePilotato = false;
        }

        #endregion



        #region Gestione Selezione Ordine 

        string FilterOrdine;

        //		void AbilitaDisabilitaBtnOrdine(){
        //			bool SelezioneOrdineAttiva = ((Meta.IsEmpty)||(Meta.InsertMode));
        //			btnOrdine.Enabled=  SelezioneOrdineAttiva;
        //			txtNumOrdine.ReadOnly= !SelezioneOrdineAttiva;
        //			txtEsercOrdine.ReadOnly= !SelezioneOrdineAttiva;
        //			cmbCausale.Enabled= Meta.InsertMode && (txtNumOrdine.Text.Trim()!="");
        //			txtCredDeb.ReadOnly = !Meta.IsEmpty;
        //		}

        private void txtEsercOrdine_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
            //CalcolaStartFilter(null);
        }

        string GetFilterOrdine(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            FilterOrdine = QHS.CmpLe("yman", esercizio);
            if (txtEsercDoc.Text != "") {
                int esercordine = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (esercordine <= esercizio)
                        FilterOrdine = QHS.CmpEq("yman", esercordine);
                    else
                        FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.CmpEq("yman", esercordine));
                }
                catch {
                }
            }

            string filtertipoord = null;
            if (cmbTipoDocumento.SelectedIndex <= 0) {
                filtertipoord = null;
            }
            else {
                filtertipoord = QHS.CmpEq("idmankind", cmbTipoDocumento.SelectedValue);
            }

            FilterOrdine = QHS.AppAnd(FilterOrdine, filtertipoord);
            if (FiltraNum) {
                int numordine = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.CmpEq("nman", numordine));
                }
            }

            if (Meta.InsertMode) {
                FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.CmpGt("residual", 0),
                    QHS.DoPar(QHS.AppOr(QHS.IsNull("active"), QHS.CmpEq("active", 'S'))));
            }

            FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.CmpEq("idmandatestatus", 5)); // stato approvato
            FilterOrdine = QHS.AppAnd(FilterOrdine, QHS.NullOrEq("isrequest", "N")); // vero ordine
            return FilterOrdine;
        }


        private void btnOrdine_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);
            string MyOrdineFilter;
            string MyFilterOrdineGenerico;
            string MyFilterOrdineGenericoOperativo;
            if (((Control) sender).Name == "txtNumDoc")
                MyOrdineFilter = GetFilterOrdine(true);
            else
                MyOrdineFilter = GetFilterOrdine(false);

            MyFilterOrdineGenerico = MyOrdineFilter;
            MyFilterOrdineGenericoOperativo = MyOrdineFilter;

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if ((condfasecred && faseprecselected) ||
                    ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != ""))
                ) {
                    MyFilterOrdineGenerico = GetData.MergeFilters(MyFilterOrdineGenerico,
                        "(idreg is null or idreg=" +
                        QueryCreator.quotedstrvalue(Curr["idreg"], true) + ")");
                    MyFilterOrdineGenericoOperativo = GetData.MergeFilters(MyFilterOrdineGenericoOperativo,
                        "(registry is null or registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

                bool condfaseupb = (ManageUPB.faseattivazione < currphase);
                object getupb = GetUpb();
                if ((condfaseupb && faseprecselected) ||
                    (getupb != DBNull.Value && txtUPB.Enabled)) {
                    object idupb = getupb;
                    MyFilterOrdineGenericoOperativo = QHS.AppAnd(MyFilterOrdineGenericoOperativo,
                        QHS.DoPar(QHS.AppOr(QHS.IsNull("idupb"), QHS.CmpEq("idupb", idupb),
                            QHS.CmpEq("idupb_iva", idupb))));
                }
                if (fasespesamax == 1) {
	                MyFilterOrdineGenericoOperativo =
		                QHS.AppAnd(MyFilterOrdineGenericoOperativo, QHS.CmpEq("linktoinvoice", "N"));
                }
            }

            

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyFilterOrdineGenericoOperativo = GetData.MergeFilters(MyFilterOrdineGenericoOperativo,
                        "(registry is null or registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MOrdine;
            DataRow MyDROrdine;

            if (Meta.IsEmpty) {
                MOrdine = MetaData.GetMetaData(this, "mandatelinked");
                MOrdine.FilterLocked = true;
                MOrdine.DS = new DataSet(); //DS.Clone();
                MyDROrdine = MOrdine.SelectOne("default", MyFilterOrdineGenerico, null, null);
                if (MyDROrdine == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                TipoDocChangePilotato = true;
                HelpForm.SetComboBoxValue(cmbTipoDocumento, MyDROrdine["idmankind"]);
                TipoDocChangePilotato = false;
                txtEsercDoc.Text = MyDROrdine["yman"].ToString();
                txtNumDoc.Text = MyDROrdine["nman"].ToString();
                return;
            }

            MOrdine = MetaData.GetMetaData(this, "mandateresidual");
            MOrdine.FilterLocked = true;
            MOrdine.DS = new DataSet(); //DS.Clone();

            MyDROrdine = MOrdine.SelectOne("default", MyFilterOrdineGenericoOperativo, null, null);

            if (MyDROrdine == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectord = QHS.MCmp(MyDROrdine, "idmankind", "yman", "nman");

            string columnlist = QueryCreator.ColumnNameList(DS.mandate) +
                                ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("mandateview", columnlist, null, selectord, null, null, true);

            //if (Temp.Rows.Count==0) return;

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetOrdine();
                CollegaOrdine(MyDR, MyDROrdine);
                CollegaTuttiDettagliOrdine();
                RintracciaOrdine();
                ResetTipoClassAvailableEvalued();
            }

            AbilitaDisabilitaControlliOrdine(true);

        }

        private void txtNumOrdine_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;
            //CalcolaStartFilter(null);


            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) ScollegaOrdine(true);
                ClearControlliOrdine(true);
                int fasecred = ManageCreditore.faseattivazione;
                if (fasecred < currphase) return;
                txtCredDeb.Text = "";
                return;
            }


            btnOrdine_Click(sender, e);
        }

        void ClearControlliOrdine(bool skipTipoDoc) {
            //txtCredDeb.Text = "";		
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SetResponsabile(DBNull.Value);
            //cmbResponsabile.SelectedIndex=-1;
            txtApplierAnnotations.Text = "";
            if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex = -1;
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        /*
         * void AbilitaDisabilitaControlliOrdine(bool abilita){
            AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }
        */


        void VisualizzaMainInfo_Ordine(DataRow Ordine2) {
            if (!faseOrdineInclusa()) return;
            gboxDettmandate.Visible = true;
            cmbTipoDocumento.Tag =
                "expensemandate.idmankind?" +
                "expensemandateview.idmankind";
            ImpostaComboMandateKind();
            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, Ordine2["idmankind"]);
            TipoDocChangePilotato = false;
            txtNumDoc.Text = Ordine2["nman"].ToString();
            txtEsercDoc.Text = Ordine2["yman"].ToString();
        }

        /// <summary>
        /// Collega la riga Ordine2 al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        void CollegaOrdine(DataRow Ordine2, DataRow OrdineResiduo) {
            if (Meta.IsEmpty) return;
            if (!faseOrdineInclusa()) return;
            tipocont mycont = ContabilizzazioneSelezionata();
            if (mycont != tipocont.cont_ordine && mycont != tipocont.cont_none)
                return; //Non collega ordini se non in questi casi

            //AzzeraPadre();
            Hashtable ValoriOrdine = new Hashtable();
            foreach (DataColumn C in Ordine2.Table.Columns)
                ValoriOrdine[C.ColumnName] = Ordine2[C.ColumnName];

            ScollegaOrdine();

            gboxDettmandate.Visible = true;

            DataRow NewOrdR = DS.mandate.NewRow();
            foreach (DataColumn C in DS.mandate.Columns) {
                NewOrdR[C.ColumnName] = ValoriOrdine[C.ColumnName];
            }

            DS.mandate.Rows.Add(NewOrdR);
            NewOrdR.AcceptChanges();

            DataRow CurrRow = DS.expense.Rows[0];
            DataRow CurrImpRow = DS.expenseyear.Rows[0];
            MetaData MovOrd = MetaData.GetMetaData(this, "expensemandate");
            MovOrd.SetDefaults(DS.expensemandate);
            DS.expensemandate.Columns["idmankind"].DefaultValue = ValoriOrdine["idmankind"];
            DS.expensemandate.Columns["nman"].DefaultValue = ValoriOrdine["nman"];
            DS.expensemandate.Columns["yman"].DefaultValue = ValoriOrdine["yman"];
            TipoDocChangePilotato = true;
            HelpForm.SetComboBoxValue(cmbTipoDocumento, ValoriOrdine["idmankind"]);
            TipoDocChangePilotato = false;
            txtNumDoc.Text = ValoriOrdine["nman"].ToString();
            txtEsercDoc.Text = ValoriOrdine["yman"].ToString();

            DataRow RMovOrd = MovOrd.Get_New_Row(CurrRow, DS.expensemandate);
            DS.expensemandate.Columns["idmankind"].DefaultValue = DBNull.Value;
            DS.expensemandate.Columns["nman"].DefaultValue = DBNull.Value;
            DS.expensemandate.Columns["yman"].DefaultValue = DBNull.Value;

            CurrRow["idreg"] = OrdineResiduo["idreg"];

            CurrRow["description"] = ValoriOrdine["description"];
            txtDescrizione.Text = ValoriOrdine["description"].ToString();

            CurrRow["doc"] = "Ord." +
                             ValoriOrdine["idmankind"].ToString() + "/" +
                             ValoriOrdine["yman"].ToString().Substring(2, 2) + "/" +
                             ValoriOrdine["nman"].ToString().PadLeft(6, '0');
            //"Ord."+ValoriOrdine["documento"];
            txtDocumento.Text = CurrRow["doc"].ToString();
            CurrRow["docdate"] = ValoriOrdine["adate"];
            txtDataDocumento.Text = HelpForm.StringValue(ValoriOrdine["adate"], txtDataDocumento.Tag.ToString());
            if (ValoriOrdine["idman"] != DBNull.Value) {
                CurrRow["idman"] = ValoriOrdine["idman"];
                SetResponsabile(ValoriOrdine["idman"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != CurrRow["idreg"].ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (OrdineResiduo["idupb"] != DBNull.Value && OrdineResiduo["idupb_iva"] == DBNull.Value) {
                SetUPB(OrdineResiduo["idupb"]);
            }
            else {
                CurrImpRow["idupb"] = GetUpb();
            }

            //Meta.myHelpForm.FillControls(tabMovFin.Controls);
            OrdineLinkedMustBeEvalued = true;
            RintracciaOrdine();
            SetComboCausaleOrdine(OrdineResiduo);
            //AbilitaDisabilitaControlliOrdine(false);
            AbilitaDisabilitaCreditoreDebitore(false);
        }

        void ScollegaOrdine() {
            ValorizzaFlagCertificati(null, false);
            ScollegaOrdine(false);
        }

        void ScollegaOrdine(bool skiptipodoc) {
            gboxDettmandate.Visible = false;
            ResetOrdine();
            if (DS.expensemandate.Rows.Count == 0) return;
            DS.expensemandate.Clear();
            DS.mandatedetail_taxable.Clear();
            DS.mandatedetail_iva.Clear();
            DS.mandate.Clear();
            ClearComboCausale();
            DataRow CurrRow = DS.expense.Rows[0];
            DataRow CurrImpRow = DS.expenseyear.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
                DS.registry.Clear();
            }

            if (fasecreditore < currphase && txtNumeroFasePrecedente.Text == "") {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
                DS.registry.Clear();
            }

            int faseupb = ManageUPB.faseattivazione;
            if (faseupb < currphase && txtNumeroFasePrecedente.Text == "") {
                SetUPB(DBNull.Value);
            }

            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            CurrRow["idman"] = DBNull.Value;
            CurrRow["description"] = "";
            ClearControlliOrdine(skiptipodoc);
        }

        #endregion

        #region Eventi Dettagli Ordine

        string CalculateFilterForMandateDetailLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";

            string idreg = DS.expense.Rows[0]["idreg"].ToString();
            string idupb = DS.expenseyear.Rows[0]["idupb"].ToString();

            //MyFilter = "(idmankind="+
            //        QueryCreator.quotedstrvalue(OrdineLinked["idmankind"],SQL)+")AND"+
            //            "(yman="+
            //        QueryCreator.quotedstrvalue(OrdineLinked["yman"],SQL)+")AND"+
            //            "(nman="+
            //        QueryCreator.quotedstrvalue(OrdineLinked["nman"],SQL)+")";
            MyFilter = qh.AppAnd(MyFilter, qh.MCmp(OrdineLinked, "idmankind", "yman", "nman"));

            //DataRow TipoOrdine=DS.mandatekind.Select("(idmankind="+
            //        QueryCreator.quotedstrvalue(OrdineLinked["idmankind"],SQL)+")")[0];
            var TipoOrdine = DS.mandatekind.Select(qh.CmpEq("idmankind", OrdineLinked["idmankind"]));
            bool multireg = false;
            if (TipoOrdine.Length > 0) {
                multireg = TipoOrdine[0]["multireg"].ToString().ToUpper() == "S";
            }

            if (multireg) {
                if (idreg != "")
                    MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", idreg));
            }

            if (idupb != "") {
                if (CurrCausaleOrdine == 1) {
                    //totale, prende upb standard
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }

                if (CurrCausaleOrdine == 2) {
                    //IVA
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("isnull(idupb_iva,idupb)", idupb));
                }

                if (CurrCausaleOrdine == 3) {
                    //imponibile 
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }
            }

            if (CurrCausaleOrdine == 1) {
                //MyFilter+="AND (idexp_iva is null and idexp_taxable is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_iva"), qh.IsNull("idexp_taxable"));
            }

            if (CurrCausaleOrdine == 2) {
                //MyFilter+="AND (idexp_iva is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_iva"));
            }

            if (CurrCausaleOrdine == 3) {
                //MyFilter+="AND (idexp_taxable is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idexp_taxable"));
            }

            //MyFilter+="AND(stop is null)";
            //MyFilter = qh.AppAnd(MyFilter, qh.IsNull("stop"));
            int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterstart = qh.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
            string filterstop = qh.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
            MyFilter = qh.AppAnd(MyFilter, filterstart, filterstop);
            return MyFilter;
        }


        private void btnCollegaDettOrdine_Click(object sender, System.EventArgs e) {
            if (DS.config.Rows.Count == 0) return;

            if (MetaData.Empty(this)) return;
            if (OrdineLinked == null) {
                show("E' necessario selezionare prima il contr.passivo");
                return;
            }

            MetaData.GetFormData(this, true);
            CurrCausaleOrdine = GetCausaleOrdine();
            string MyFilter = CalculateFilterForMandateDetailLinking(true);
            string tablename = "";
            if (CurrCausaleOrdine == 1 || CurrCausaleOrdine == 3) {
                tablename = "mandatedetail_taxable";
            }

            if (CurrCausaleOrdine == 2) {
                tablename = "mandatedetail_iva";
            }

            if (tablename == "") {
                show("E' necessario selezionare prima una causale", "Avviso");
                return;
            }

            string command = "choose." + tablename + ".listaspesa." + MyFilter;
            if (!MetaData.Choose(this, command)) return;
            if (CurrCausaleOrdine == 1) {
                foreach (DataRow R in DS.mandatedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliOrdine();
        }


        private void btnModificaDettOrdine_Click(object sender, System.EventArgs e) {

            if (Meta.IsEmpty) return;
            if (OrdineLinked == null) {
                show("E' necessario selezionare prima il contr.passivo");
                return;
            }

            Meta.GetFormData(true);
            DataTable ToLink = null;
            if (CurrCausaleOrdine == 1 || CurrCausaleOrdine == 3) {
                ToLink = DS.mandatedetail_taxable;
                Meta.MarkTableAsNotEntityChild(DS.mandatedetail_taxable, "expensemandatedetail_taxable");
            }

            if (CurrCausaleOrdine == 2) {
                ToLink = DS.mandatedetail_iva;
                Meta.MarkTableAsNotEntityChild(DS.mandatedetail_iva, "expensemandatedetail_iva");
            }

            if (ToLink == null) {
                show("E' necessario selezionare prima la causale");
                return;
            }

            string MyFilter = CalculateFilterForMandateDetailLinking(false);
            string MyFilterSQL = CalculateFilterForMandateDetailLinking(true);
            Meta.MultipleLinkUnlinkRows("Selezione dettagli contratto",
                "Dettagli inclusi nel movimento corrente",
                "Dettagli non inclusi in alcun movimento",
                ToLink, MyFilter, MyFilterSQL, "listaspesa");
            if (CurrCausaleOrdine == 1) {
                foreach (DataRow R in DS.mandatedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliOrdine();
        }

        private void btnScollegaDettOrdine_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (OrdineLinked == null) {
                show("E' necessario selezionare prima il contr.passivo");
                return;
            }

            Meta.GetFormData(true);
            MetaData.Unlink_Grid(dgrDettagliOrdine);
            if (CurrCausaleOrdine == 1) {
                foreach (DataRow R in DS.mandatedetail_taxable.Rows) {
                    R["idexp_iva"] = R["idexp_taxable"];
                }

                ;
            }

            CalcolaImportoInBaseADettagliOrdine();
        }

        decimal GetImportoDettagliOrdine() {
            if (DS.mandate.Rows.Count == 0)
                return 0;
            decimal tassocambio;
            DataRow Contratto = DS.mandate.Rows[0];
            tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
            if (tassocambio == 0) tassocambio = 1;
            decimal imponibile = 0;
            decimal imposta = 0;
            DataRow[] ToConsider = new DataRow[0];
            CurrCausaleOrdine = GetCausaleOrdine();
            if (CurrCausaleOrdine == 3) {
                ToConsider = DS.mandatedetail_taxable.Select("idexp_taxable is not null");
            }

            if (CurrCausaleOrdine == 2) {
                ToConsider = DS.mandatedetail_iva.Select("idexp_iva is not null");
            }

            if (CurrCausaleOrdine == 1) {
                ToConsider = DS.mandatedetail_taxable.Select("idexp_taxable is not null");
            }

            foreach (DataRow R in ToConsider) {
                if (R.RowState == DataRowState.Deleted) continue;
                if (R["stop"] != DBNull.Value) continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                //decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]), 6);
                imponibile += CfgFn.RoundValuta((R_imponibile * R_quantitaConfezioni * (1 - R_sconto)) * tassocambio);
                imposta += CfgFn.RoundValuta(R_imposta);
            }

            decimal totale = 0;

            if (CurrCausaleOrdine == 3) {
                totale = imponibile;
            }

            if (CurrCausaleOrdine == 2) {
                totale = imposta;
            }

            if (CurrCausaleOrdine == 1) {
                totale = imponibile + imposta;
            }

            return totale;

        }

        void CalcolaImportoInBaseADettagliOrdine() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            tipocont currcont = ContabilizzazioneSelezionata();
            if (currcont != tipocont.cont_ordine) return;
            CurrCausaleOrdine = GetCausaleOrdine();
            decimal totale = GetImportoDettagliOrdine();
            decimal variazioni = MetaData.SumColumn(DS.expensevar, "amount");
            SetImporto(totale - variazioni);
            CalcTotMandateDetail();
        }

        void SvuotaDettagliOrdine() {
            if (Meta.EditMode) return;
            if (EsisteEsercPrecedente()) return;
            DS.mandatedetail_taxable.Clear();
            DS.mandatedetail_iva.Clear();
            CalcTotMandateDetail();

        }

        void CollegaTuttiDettagliOrdine() {
            if (DS.mandate.Rows.Count == 0) return;
            CurrCausaleOrdine = GetCausaleOrdine();
            string filter = CalculateFilterForMandateDetailLinking(true);
            DS.mandatedetail_iva.Clear();
            DS.mandatedetail_taxable.Clear();
            string idexp = DS.expense.Rows[0]["idexp"].ToString();
            if (CurrCausaleOrdine == 1) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.mandatedetail_taxable, null, filter, null, true);
                foreach (DataRow R in DS.mandatedetail_taxable.Rows) {
                    R["idexp_taxable"] = idexp;
                    R["idexp_iva"] = idexp;
                }

                GetData.CalculateTable(DS.mandatedetail_taxable);
                Meta.MarkTableAsNotEntityChild(DS.mandatedetail_taxable, "expensemandatedetail_taxable");
            }

            if (CurrCausaleOrdine == 3) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.mandatedetail_taxable, null, filter, null, true);
                foreach (DataRow R in DS.mandatedetail_taxable.Rows) {
                    R["idexp_taxable"] = idexp;
                }

                GetData.CalculateTable(DS.mandatedetail_taxable);
                Meta.MarkTableAsNotEntityChild(DS.mandatedetail_taxable, "expensemandatedetail_taxable");
            }

            if (CurrCausaleOrdine == 2) {
                Meta.Conn.RUN_SELECT_INTO_TABLE(DS.mandatedetail_iva, null, filter, null, true);
                foreach (DataRow R in DS.mandatedetail_iva.Rows) {
                    R["idexp_iva"] = idexp;
                }

                GetData.CalculateTable(DS.mandatedetail_iva);
                Meta.MarkTableAsNotEntityChild(DS.mandatedetail_iva, "expensemandatedetail_iva");
            }

            CalcolaImportoInBaseADettagliOrdine();
        }

        #endregion



        #region Gestione ComboBox Causale Ordine


        decimal totimponibile;
        decimal totiva;
        decimal assigned_imponibile;
        decimal assigned_iva;
        decimal assigned_gen;



        void SetEditComboCausaleOrdine() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(1, "Contabilizzazione Totale Contratto Passivo");
            EnableTipoMovimento(3, "Contabilizzazione Imponibile Contratto Passivo");
            EnableTipoMovimento(2, "Contabilizzazione Iva Contratto Passivo");
            object currtipo = DS.Tables["expensemandate"].Rows[0]["movkind"];
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);

        }


        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleOrdine(DataRow Ordine) {
            if (!faseOrdineInclusa()) return;
            DataAccess Conn = Meta.Conn;

            totimponibile = CfgFn.GetNoNullDecimal(Ordine["taxabletotal"]);
            totiva = CfgFn.GetNoNullDecimal(Ordine["ivatotal"]);
            assigned_imponibile = CfgFn.GetNoNullDecimal(Ordine["linkedimpon"]);
            assigned_iva = CfgFn.GetNoNullDecimal(Ordine["linkedimpos"]);
            assigned_gen = CfgFn.GetNoNullDecimal(Ordine["linkedordin"]);


            string filterordine = QHS.AppAnd(QHS.CmpEq("idmankind", Ordine["idmankind"]),
                QHS.CmpEq("yman", Ordine["yman"]), QHS.CmpEq("nman", Ordine["nman"]));

            decimal all_assigned_imponibile = 0;
            decimal all_assigned_iva = 0;
            decimal all_assigned_gen = 0;
            bool intracom = false;
            DataTable T = Conn.RUN_SELECT("mandateresidual", "*", null, filterordine, null, true);
            bool recuperoIvaEstera = false;
            if ((T != null) && (T.Rows.Count > 0)) {
                //DataRow R=T.Rows[0];
                //totimponibile=CfgFn.GetNoNullDecimal(R["taxabletotal"]);
                //totiva=CfgFn.GetNoNullDecimal(R["ivatotal"]);
                foreach (DataRow Dett in T.Rows) {
                    all_assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    all_assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    all_assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkedordin"]);
                    if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                    int flag = CfgFn.GetNoNullInt32(Dett["flagbit"]);
                    if ((flag & 1) != 0) {
                        recuperoIvaEstera = true;
                    }
                }
            }

            string filter_idupbivaset = QHS.AppAnd(filterordine, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("mandatedetail", filter_idupbivaset, false);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            if ((Meta.EditMode) ||
                ((all_assigned_imponibile + all_assigned_iva) == 0) &&
                (assigned_gen < (totimponibile + totiva) && (!(intracom)|| recuperoIvaEstera) && (n_idupbivaset == 0))
            ) {
                EnableTipoMovimento(1, "Contabilizzazione Totale Contratto Passivo");
            }

            if ((Meta.EditMode) ||
                ((all_assigned_gen == 0) && (assigned_imponibile < totimponibile))
            ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Contratto Passivo");
            }

            if ((Meta.EditMode) ||
                ((all_assigned_gen == 0) && (assigned_iva < totiva) && (!(intracom)|| recuperoIvaEstera) )
            ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Contratto Passivo");
            }

            DS.expensemandate.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                ? cmbCausale.SelectedValue
                : DBNull.Value;
            cmbCausale.Enabled = Meta.InsertMode;
            ReCalcImporto_Ordine();

        }

        void AbilitaDisabilitaControlliOrdine(bool abilita) {
            bool abilitagrid = abilita && faseOrdineInclusa();
            btnAddDetMandate.Enabled = abilitagrid;
            btnRemoveDetMandate.Enabled = abilitagrid;
            btnEditMandDet.Enabled = abilitagrid;
            gboxDettmandate.Visible = abilitagrid;
            CurrCausaleOrdine = GetCausaleOrdine();
            if (CurrCausaleOrdine == 1 || CurrCausaleOrdine == 3) {
                dgrDettagliOrdine.Tag = "mandatedetail_taxable.listaimpon";
                //dgrDettagliOrdine.TableStyles.Clear();
                HelpForm.SetDataGrid(dgrDettagliOrdine, DS.mandatedetail_taxable);
                if (Meta.EditMode) DS.mandatedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
            }

            if (CurrCausaleOrdine == 2) {
                dgrDettagliOrdine.Tag = "mandatedetail_iva.listaimpos";
                //dgrDettagliOrdine.TableStyles.Clear();
                HelpForm.SetDataGrid(dgrDettagliOrdine, DS.mandatedetail_iva);
                if (Meta.EditMode) DS.mandatedetail_taxable.Clear(); //Importante per evitare problemi in fase di delete
            }


        }


        /// <summary>
        /// Il disponibile � calcolato in base ai dettagli selezionati e non al residuo da contabilizzare
        /// </summary>
        void ReCalcImporto_Ordine() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            string tipomovimento = cmbCausale.SelectedValue.ToString();

            decimal importo = GetImportoDettagliOrdine();
//			if (tipomovimento==2){
//				importo= totiva-assigned_iva;
//			}
//			if (tipomovimento==3){
//				importo= totimponibile-assigned_imponibile;
//			}
//			if (tipomovimento==1){
//				importo= totimponibile+totiva-assigned_gen;
//			}
            if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
                show("Sar� effettuata una contabilizzazione di importo inferiore poich� la " +
                                "disponibilit� del movimento selezionato � inferiore a " + importo.ToString());
                importo = DisponibileDaFasePrecedente;
            }

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");

        }

        private void cmbCausaleOrdine_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.InsertMode) return;
            GetCausaleOrdine();
            SvuotaDettagliOrdine();
            CollegaTuttiDettagliOrdine();
            ReCalcImporto_Ordine();
        }

        int GetCausaleOrdine() {
            CurrCausaleOrdine = 0;
            //if (!Meta.InsertMode) return "";
            if (DS.expensemandate.Rows.Count == 0) return 0;
            if (!Meta.DrawStateIsDone) {
                if (DS.expensemandate.Rows[0]["movkind"] != DBNull.Value)
                    CurrCausaleOrdine = CfgFn.GetNoNullInt32(DS.expensemandate.Rows[0]["movkind"]);
                else
                    CurrCausaleOrdine = 0;
                return CurrCausaleOrdine;
            }

            if (cmbCausale.SelectedValue != null)
                DS.expensemandate.Rows[0]["movkind"] = cmbCausale.SelectedValue;
            else
                DS.expensemandate.Rows[0]["movkind"] = DBNull.Value;
            CurrCausaleOrdine = CfgFn.GetNoNullInt32(DS.expensemandate.Rows[0]["movkind"]);
            return CurrCausaleOrdine;
            //ReCalcImporto();
        }


        void UpdateComboCausaleOrdine() {
            if (OrdineGenericoMovSpesaLinked != null) {
                object currtipo = OrdineGenericoMovSpesaLinked["movkind"];
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }

        private void cmbTipoOrdine_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (TipoDocChangePilotato) return;
            TipoDocChangePilotato = true;
            if (Meta.InsertMode) ScollegaOrdine(true);
            ClearControlliOrdine(true);
            txtEsercDoc.Text = "";
            txtNumDoc.Text = "";
            TipoDocChangePilotato = false;
        }

        #endregion



        #region Gestione Selezione Missione 

        private void txtEsercMissione_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
        }

        string GetFilterMissione(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filterupb = null;
            object getupb = GetUpb();
            if (getupb != DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);
            }

            string FilterMissione = "(yitineration<='" + esercizio.ToString() + "')";
            FilterMissione = GetData.MergeFilters(FilterMissione, filterupb);
            if (txtEsercDoc.Text != "") {
                int esercmissione = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (esercmissione <= esercizio)
                        FilterMissione = "(yitineration='" + esercmissione.ToString() + "')";
                    else
                        FilterMissione = GetData.MergeFilters(FilterMissione,
                            "(yitineration='" + esercmissione.ToString() + "')");
                }
                catch {
                }
            }

            if (FiltraNum) {
                int nummissione = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterMissione = GetData.MergeFilters(FilterMissione,
                        "(nitineration='" + nummissione.ToString() + "')");
                }
            }

            if (Meta.InsertMode) {
                FilterMissione +=
                    " AND ( ((residual>0) AND (completed='S') and (datecompleted is not null)) OR (linkedanpag + linkedangir < totadvance) )";
                FilterMissione += " AND ((active IS NULL)OR(active='S')) ";
            }

            FilterMissione = QHS.AppAnd(FilterMissione, QHS.CmpEq("iditinerationstatus", 6)); // stato approvato

            return FilterMissione;
        }


        private void btnMissione_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);

            string MyMissioneFilter;
            if (((Control) sender).Name == "txtNumDoc")
                MyMissioneFilter = GetFilterMissione(true);
            else
                MyMissioneFilter = GetFilterMissione(false);

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if (condfasecred && faseprecselected) {
                    MyMissioneFilter = GetData.MergeFilters(MyMissioneFilter,
                        "(idreg=" +
                        QueryCreator.quotedstrvalue(Curr["idreg"], true) + ")");
                }

                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
                    DataRow Cred = DS.registry.Rows[0];
                    MyMissioneFilter = GetData.MergeFilters(MyMissioneFilter,
                        "(idreg=" +
                        QueryCreator.quotedstrvalue(Cred["idreg"], true) + ")");
                }
            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyMissioneFilter = GetData.MergeFilters(MyMissioneFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MMissione;
            DataRow MyDRMissione;

            if (Meta.IsEmpty) {
                MMissione = MetaData.GetMetaData(this, "itinerationlinked");
                MMissione.FilterLocked = true;
                MMissione.DS = new DataSet(); //DS.Clone();
                MyDRMissione = MMissione.SelectOne("default", MyMissioneFilter, null, null);
                if (MyDRMissione == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                txtEsercDoc.Text = MyDRMissione["yitineration"].ToString();
                txtNumDoc.Text = MyDRMissione["nitineration"].ToString();
                return;
            }

            MMissione = MetaData.GetMetaData(this, "itinerationresidual");
            MMissione.FilterLocked = true;
            MMissione.DS = new DataSet(); //DS.Clone();

            MyDRMissione = MMissione.SelectOne("default", MyMissioneFilter,
                //GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
                null, null);

            if (MyDRMissione == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectmis = "(yitineration='" + MyDRMissione["yitineration"].ToString() + "')AND" +
                               "(nitineration='" + MyDRMissione["nitineration"].ToString() + "')";


            string columnlist = QueryCreator.ColumnNameList(DS.itineration)
                                + ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("itinerationview", columnlist, null, selectmis, null, null, true);

            if (Temp.Rows.Count == 0) {
                show(this,
                    $"Missione n. {MyDRMissione["nitineration"]} del {MyDRMissione["yitineration"]} non presente nella vista",
                    "Errore");
                return;
            }

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetMissione();
                CollegaMissione(MyDR);
                //RintracciaMissione();
                ResetTipoClassAvailableEvalued();
                //RicalcolaPrestazioneMissione();
            }

        }

        private void txtNumMissione_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;

            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) {
                    ScollegaMissione();
                    ClearControlliMissione();
                }

                return;
            }

            btnMissione_Click(sender, e);
        }

        void AbilitaDisabilitaControlliMissione(bool abilita) {
            bool abilitalast = abilita && faseMaxInclusa();
            SubEntity_txtDataInizioPrest.ReadOnly = !abilitalast;
            SubEntity_txtDataFinePrest.ReadOnly = !abilitalast;
            SubEntity_cmbTipoprestazione.Enabled = abilitalast;
            //btnCalcoloGuidato.Enabled=abilitalast;
            //btnPrestazione.Enabled=abilitalast;

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            //btnInserisciRitenute.Enabled	= abilitalast||ModificaRitenuteAbilitata();
            // J.T.R. Consentiamo sempre di accedere al form figlio che si porr� in sola lettura nel caso
            // la prestazione adoperata non consenta modifiche alle ritenute.
            //btnModificaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();
            //btnEliminaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();

            //btnInserisciCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();
            //btnEliminaCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();

            //btnInserisciUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();
            //btnEliminaUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";
        }

        void ClearControlliMissione() {
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SubEntity_txtDataInizioPrest.Text = "";
            SubEntity_txtDataFinePrest.Text = "";
            SubEntity_cmbTipoprestazione.SelectedIndex = -1;
            cmbRecupero.SelectedIndex = -1;
            txtApplierAnnotations.Text = "";
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        /// <summary>
        /// Collega la riga missione al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        bool CollegaMissione(DataRow Missione2) {
            if (Meta.EditMode) {
                if (faseMissioneInclusa()) {
                    txtNumDoc.Text = Missione2["nitineration"].ToString();
                    txtEsercDoc.Text = Missione2["yitineration"].ToString();
                }

                return false;
            }

            if (Meta.IsEmpty) return false;

            Hashtable ValoriMissione = new Hashtable();
            foreach (DataColumn C in DS.itineration.Columns)
                ValoriMissione[C.ColumnName] = Missione2[C.ColumnName];

            //AzzeraPadre();
            ScollegaMissione();
            DataRow CurrRow = DS.expense.Rows[0];

            //Se la fase missione � presente, legge la riga missione e la collega al
            // movimento di spesa corrente
            if (faseMissioneInclusa()) {
                DataRow NewMissR = DS.itineration.NewRow();
                foreach (DataColumn C in DS.itineration.Columns) {
                    NewMissR[C.ColumnName] = ValoriMissione[C.ColumnName];
                }

                DS.itineration.Rows.Add(NewMissR);
                NewMissR.AcceptChanges();
                Missione2 = NewMissR;

                MetaData MovMis = MetaData.GetMetaData(this, "expenseitineration");
                MovMis.SetDefaults(DS.expenseitineration);
                DS.expenseitineration.Columns["iditineration"].DefaultValue = ValoriMissione["iditineration"];
                DataRow RMovMis = MovMis.Get_New_Row(CurrRow, DS.expenseitineration);
                DS.expenseitineration.Columns["iditineration"].DefaultValue = DBNull.Value;
                txtNumDoc.Text = ValoriMissione["nitineration"].ToString();
                txtEsercDoc.Text = ValoriMissione["yitineration"].ToString();
            }

            //Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
            // anche a video.
            CurrRow["idreg"] = ValoriMissione["idreg"];
            CurrRow["description"] = ValoriMissione["description"];
            txtDescrizione.Text = ValoriMissione["description"].ToString();

            CurrRow["doc"] = "Mis." +
                             ValoriMissione["yitineration"].ToString().Substring(2, 2) + "/" +
                             ValoriMissione["nitineration"].ToString().PadLeft(6, '0');
            //"Ord."+ValoriOrdine["documento"];
            txtDocumento.Text = CurrRow["doc"].ToString();

            CurrRow["docdate"] = ValoriMissione["adate"];
            txtDataDocumento.Text = HelpForm.StringValue(CurrRow["docdate"], txtDataDocumento.Tag.ToString());
            if (ValoriMissione["idman"] != DBNull.Value) {
                CurrRow["idman"] = ValoriMissione["idman"];
                SetResponsabile(ValoriMissione["idman"]);
            }


            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != ValoriMissione["idreg"].ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (ValoriMissione["idupb"] != DBNull.Value) {
                SetUPB(ValoriMissione["idupb"]);
            }

            MissionLinkedMustBeEvalued = true;
            RintracciaMissione();
            if (MissionLinked != null) {
                AbilitaDisabilitaControlliMissione(false);
                AbilitaDisabilitaCreditoreDebitore(false);
                CalcolaContabilizzatiMissione(MissionLinked);
                SetComboCausaleMissione(MissionLinked);
                ImpostaBilancioMissione();
                GeneraOAzzeraRigaRecupero();
            }

            return true;
        }


        void ScollegaMissione() {
            ResetMissione();
            if (DS.expenseitineration.Rows.Count == 0) {
                AbilitaDisabilitaControlliMissione(true);
                AbilitaDisabilitaCreditoreDebitore(true);
                //ClearControlliMissione();
                //DS.expensetax.Clear();
                return;
            }

            DS.expenseitineration.Clear();
            DS.itineration.Clear();
            DataRow CurrRow = DS.expense.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
            }

            CurrRow["description"] = "";
            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            CurrRow["idman"] = DBNull.Value;
            CurrRow["idclawback"] = DBNull.Value;
            ClearControlliMissione();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
            ClearComboCausale();
            ClearPrestazioni();
            AbilitaDisabilitaControlliMissione(true);
            AbilitaDisabilitaCreditoreDebitore(true);
        }



        #endregion

        #region Gestione ComboBox Causale Missione

        decimal totlordo;
        decimal totanticipo;
        decimal contabilizzato_ANPAG;
        decimal contabilizzato_ANGIR;
        decimal contabilizzato_SALDO;
        decimal contabilizzato_VARIAZIONI;

        void SetEditComboCausaleMissione() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(5, "Anticipo della missione su partita di giro");
            EnableTipoMovimento(6, "Anticipo della missione sul capitolo di spesa");
            EnableTipoMovimento(4, "Pagamento o saldo della missione");
            object currtipo = DS.Tables["expenseitineration"].Rows[0]["movkind"];
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }

        void UpdateComboCausaleMissione() {
            if (MissioneMovSpesaLinked != null) {
                object currtipo = MissioneMovSpesaLinked["movkind"];
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }



        string lastMissEvalued = null;

        void CalcolaContabilizzatiMissione(DataRow Missione) {
            string filtermiss = "(yitineration='" + Missione["yitineration"].ToString() + "')AND" +
                                "(nitineration='" + Missione["nitineration"].ToString() + "')";
            decimal totlordo = CfgFn.GetNoNullDecimal(Missione["totalgross"]);

            if (filtermiss == lastMissEvalued) return;
            lastMissEvalued = filtermiss;

            DataTable Residuo = MyConn.RUN_SELECT("itinerationresidual", "*", null, filtermiss, null, true);
            if (Residuo.Rows.Count == 0) return;
            DataRow CurrResid = Residuo.Rows[0];
            contabilizzato_ANGIR = CfgFn.GetNoNullDecimal(CurrResid["linkedangir"]);
            contabilizzato_ANPAG = CfgFn.GetNoNullDecimal(CurrResid["linkedanpag"]);
            contabilizzato_SALDO = CfgFn.GetNoNullDecimal(CurrResid["linkedsaldo"]);
            decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residual"]);
            contabilizzato_VARIAZIONI = -(totlordo - residuo - contabilizzato_ANPAG - contabilizzato_SALDO);

        }

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleMissione(DataRow Missione) {
            if (!faseMissioneInclusa()) {
                cmbCausale.Enabled = false;
                return;
            }

            totlordo = CfgFn.GetNoNullDecimal(Missione["totalgross"]);
            totanticipo = CfgFn.GetNoNullDecimal(Missione["totadvance"]);

            CalcolaContabilizzatiMissione(Missione);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            object completed = Missione["completed"];

            if (((Meta.EditMode) ||
                 ((contabilizzato_SALDO + contabilizzato_ANPAG - contabilizzato_VARIAZIONI) < totlordo) &&
                 ((completed != null) && (Missione["datecompleted"] != DBNull.Value) && (completed.ToString().ToUpper() == "S")))
            ) {
                EnableTipoMovimento(4, "Pagamento o saldo della missione");
            }

            if ((Meta.EditMode) ||
                ((contabilizzato_SALDO == 0) && (contabilizzato_ANPAG == 0) &&
                 (contabilizzato_ANGIR < totanticipo))
            ) {
                EnableTipoMovimento(5, "Anticipo della missione su partita di giro");
            }

            if ((Meta.EditMode) ||
                ((contabilizzato_SALDO == 0) && (contabilizzato_ANGIR == 0) &&
                 (contabilizzato_ANPAG < totanticipo))
            ) {
                EnableTipoMovimento(6, "Anticipo della missione sul capitolo di spesa");
            }

            DS.expenseitineration.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                ? cmbCausale.SelectedValue
                : DBNull.Value;
            cmbCausale.Enabled = Meta.InsertMode;
            ReCalcImporto_Missione();

        }


        /// <summary>
        /// Deve essere preceduto da GetFormData() e seguito da FreshForm()
        /// </summary>
        void ImpostaBilancioMissione() {
            if (!Meta.InsertMode) return;
            if (MissionLinked == null) return;
            if (MissioneMovSpesaLinked == null) return;
            if (MissioneMovSpesaLinked.RowState == DataRowState.Detached) {
                return;
            }

            int tipomovimento = CfgFn.GetNoNullInt32(MissioneMovSpesaLinked["movkind"]);
            DataRow Curr = DS.expenseyear.Rows[0];
            DataRow CurrExp = DS.expense.Rows[0];

            if (tipomovimento != 5) {
                cmbRecupero.SelectedIndex = -1;
                CurrExp["idclawback"] = DBNull.Value;
                return;
            }

            if (DS.config.Rows.Count > 0) {
                object idclawback = DS.config.Rows[0]["idclawback"];
                if (idclawback != DBNull.Value) {
                    HelpForm.SetComboBoxValue(cmbRecupero, idclawback);
                    if (cmbRecupero.SelectedIndex > 0)
                        CurrExp["idclawback"] = cmbRecupero.SelectedValue;
                    else
                        CurrExp["idclawback"] = DBNull.Value;
                }
            }



            int fasebilancio = ManageBilAnnuale.faseattivazione;
            if (fasebilancio > currphase) return;
            if (fasebilancio < currphase) {
                //Se � gi� presente una voce di bilancio tramite  una fase precedente,
                //  allora non modifica il bilancio
                if (Curr["idfin"] != DBNull.Value) return;
            }

            if (DS.config.Rows.Count == 0) return;
            DataRow PersMiss = DS.config.Rows[0];
            Curr["idfin"] = PersMiss["idfinexpense"];
            DS.finview.Clear();
            DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.finview, null,
                QHS.AppAnd(QHS.CmpEq("idfin", Curr["idfin"]), QHS.CmpEq("idupb", "0001")),
                null, true);
            if (DS.finview.Rows.Count > 0) {
                DataRow Bil = DS.finview.Rows[0];
                txtCodiceBilancio.Text = Bil["codefin"].ToString();
                txtDenominazioneBilancio.Text = Bil["title"].ToString();
            }
            else {
                txtCodiceBilancio.Text = "";
                txtDenominazioneBilancio.Text = "";
            }


        }


        void ReCalcImporto_Missione() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            int tipomovimento = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            decimal importo = 0;
            if (tipomovimento == 4) {
                importo = totlordo - (contabilizzato_SALDO + contabilizzato_ANPAG) + contabilizzato_VARIAZIONI;
            }

            if (tipomovimento == 5) {
                importo = totanticipo - contabilizzato_ANGIR;
            }

            if (tipomovimento == 6) {
                importo = totanticipo - contabilizzato_ANPAG;
            }

            if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
                show("Sar� effettuata una contabilizzazione parziale della missione poich� la " +
                                "disponibilit� del movimento selezionato � inferiore a " + importo.ToString());
                importo = DisponibileDaFasePrecedente;
            }

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");
        }

        private void cmbCausaleMissione_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta.InsertMode) {
                //Meta.GetFormData(true);
                GetCausaleMissione();
                ReCalcImporto_Missione(); //Richiama indirettamente RicalcolaPrestazioneMissione();
                GeneraOAzzeraRigaRecupero();
                ImpostaBilancioMissione();
            }
        }


        /// <summary>
        /// Legge la causale dal combobox e la mette in tipomovimento ove 
        ///  possibile.
        /// </summary>
        int GetCausaleMissione() {
            CurrCausaleMissione = 0;
            if (!Meta.InsertMode) return 0;
            DataRow r = DS.expenseitineration.First();
            if (r == null) return 0;
            if (ContabilizzazioneSelezionata() != tipocont.cont_missione) return 0;
            r["movkind"] = cmbCausale.SelectedValue;
            CurrCausaleMissione = CfgFn.GetNoNullInt32(r["movkind"]);
            return CurrCausaleMissione;
            //ReCalcImporto();
        }

        #endregion



        #region Gestione Selezione Cedolino 



        //		void AbilitaDisabilitaBtnMissione(){
        //			int fasemissione = ManageMissione.faseattivazione;
        //			bool SelezioneMissioneAttiva=false;
        //			if ((faseinizio<= fasemissione) && (fasemissione<= fasespesafine)) 
        //				SelezioneMissioneAttiva=true;
        //			btnDocumento.Enabled=  SelezioneMissioneAttiva;
        //			txtNumDoc.ReadOnly= !SelezioneMissioneAttiva;
        //			txtEsercDoc.ReadOnly= !SelezioneMissioneAttiva;
        //			cmbCausale.Enabled= Meta.InsertMode && (txtNumDoc.Text.Trim()!="");
        //			//txtCredDeb.ReadOnly = !Meta.IsEmpty;
        //			AbilitaDisabilitaCreditoreDebitore();
        //		}

        private void txtEsercCedolino_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
        }

        string GetFilterCedolino(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filterupb = null;
            object getupb = GetUpb();
            if (getupb != DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);
            }

            string FilterCedolino = QHS.CmpLe("fiscalyear", esercizio);
            if (Meta.InsertMode) {
                FilterCedolino = QHS.CmpGe("fiscalyear", esercizio);
            }

            if (txtEsercDoc.Text != "") {
                int annoriferimento = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                FilterCedolino = QHS.CmpEq("fiscalyear", annoriferimento);
            }

            if (FiltraNum) {
                if (txtNumDoc.Text != "") {
                    int numcedolino = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                    FilterCedolino = QHS.AppAnd(FilterCedolino, QHS.CmpEq("npayroll", numcedolino));
                }
            }

            FilterCedolino = QHS.AppAnd(FilterCedolino, filterupb);

            if (Meta.InsertMode) {
                FilterCedolino = QHS.AppAnd(FilterCedolino, QHS.IsNull("disbursementdate"));
            }


            return FilterCedolino;
        }


        private void btnCedolino_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);

            string MyCedolinoFilter;
            if (((Control) sender).Name == "txtNumDoc")
                MyCedolinoFilter = GetFilterCedolino(true);
            else
                MyCedolinoFilter = GetFilterCedolino(false);


            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if (condfasecred && faseprecselected) {
                    MyCedolinoFilter = GetData.MergeFilters(MyCedolinoFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
                    MyCedolinoFilter = GetData.MergeFilters(MyCedolinoFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyCedolinoFilter = GetData.MergeFilters(MyCedolinoFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MCedolino;
            DataRow MyDRCedolino;

            if (Meta.IsEmpty) {
                MCedolino = MetaData.GetMetaData(this, "payrolllinked");
                MCedolino.FilterLocked = true;
                MCedolino.DS = new DataSet(); //DS.Clone();
                MyDRCedolino = MCedolino.SelectOne("default", MyCedolinoFilter, null, null);
                if (MyDRCedolino == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                txtEsercDoc.Text = MyDRCedolino["fiscalyear"].ToString();
                txtNumDoc.Text = MyDRCedolino["npayroll"].ToString();
                return;
            }

            MCedolino = MetaData.GetMetaData(this, "payrollavailable");
            MCedolino.FilterLocked = true;
            MCedolino.DS = new DataSet(); //DS.Clone();

            MyDRCedolino = MCedolino.SelectOne("default", MyCedolinoFilter,
                //GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
                null, null);

            if (MyDRCedolino == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectced = "(idpayroll='" + MyDRCedolino["idpayroll"].ToString() + "')";


            string columnlist = QueryCreator.ColumnNameList(DS.payroll)
                                + ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("payrollview", columnlist, null, selectced, null, null, true);

            //if (Temp.Rows.Count==0) return;

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetCedolino();
                CollegaCedolino(MyDR);
                RintracciaCedolino();
                ResetTipoClassAvailableEvalued();
                RicalcolaPrestazioneCedolino();
            }

        }

        private void txtNumCedolino_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;

            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) {
                    ScollegaCedolino();
                    ClearControlliCedolino();
                }

                return;
            }

            btnCedolino_Click(sender, e);
        }

        void AbilitaDisabilitaControlliCedolino(bool abilita) {
            bool abilitalast = abilita && faseMaxInclusa();
            SubEntity_txtDataInizioPrest.ReadOnly = !abilitalast;
            SubEntity_txtDataFinePrest.ReadOnly = !abilitalast;
            SubEntity_cmbTipoprestazione.Enabled = abilitalast;
            //btnCalcoloGuidato.Enabled=abilitalast;
            //btnPrestazione.Enabled=abilitalast;

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            //btnInserisciRitenute.Enabled	= abilitalast||ModificaRitenuteAbilitata();
            // J.T.R. Consentiamo sempre di accedere al form figlio che si porr� in sola lettura nel caso
            // la prestazione adoperata non consenta modifiche alle ritenute.
            //btnModificaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();
            //btnEliminaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();

            //btnInserisciCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();
            //btnEliminaCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();

            //btnInserisciUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();
            //btnEliminaUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";
            //AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }

        void ClearControlliCedolino() {
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SubEntity_txtDataInizioPrest.Text = "";
            SubEntity_txtDataFinePrest.Text = "";
            SubEntity_cmbTipoprestazione.SelectedIndex = -1;
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        /// <summary>
        /// Collega la riga missione al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        bool CollegaCedolino(DataRow Cedolino2) {
            if (Meta.EditMode) {
                if (faseCedolinoInclusa()) {
                    txtEsercDoc.Text = Cedolino2["fiscalyear"].ToString();
                    txtNumDoc.Text = Cedolino2["npayroll"].ToString();
                }

                return false;
            }

            if (Meta.IsEmpty) return false;

            Hashtable ValoriCedolino = new Hashtable();
            foreach (DataColumn C in DS.payroll.Columns)
                ValoriCedolino[C.ColumnName] = Cedolino2[C.ColumnName];

            //AzzeraPadre();
            ScollegaCedolino();
            DataRow CurrRow = DS.expense.Rows[0];

            //Se la fase missione � presente, legge la riga missione e la collega al
            // movimento di spesa corrente
            if (faseCedolinoInclusa()) {
                DataRow NewCedR = DS.payroll.NewRow();
                foreach (DataColumn C in DS.payroll.Columns) {
                    NewCedR[C.ColumnName] = ValoriCedolino[C.ColumnName];
                }

                DS.payroll.Rows.Add(NewCedR);
                NewCedR.AcceptChanges();
                Cedolino2 = NewCedR;

                MetaData MovCed = MetaData.GetMetaData(this, "expensepayroll");
                MovCed.SetDefaults(DS.expensepayroll);
                DS.expensepayroll.Columns["idpayroll"].DefaultValue = ValoriCedolino["idpayroll"];
                DataRow RMovCed = MovCed.Get_New_Row(CurrRow, DS.expensepayroll);
                DS.expensepayroll.Columns["idpayroll"].DefaultValue = DBNull.Value;
                txtNumDoc.Text = ValoriCedolino["npayroll"].ToString();
                txtEsercDoc.Text = ValoriCedolino["fiscalyear"].ToString();
            }

            object codicecreddeb = Meta.Conn.DO_READ_VALUE("parasubcontract",
                "(idcon=" + QueryCreator.quotedstrvalue(ValoriCedolino["idcon"], true) + ")", "idreg");
            object esercontratto = Meta.Conn.DO_READ_VALUE("parasubcontract",
                "(idcon=" + QueryCreator.quotedstrvalue(ValoriCedolino["idcon"], true) + ")", "ycon");
            object numcontratto = Meta.Conn.DO_READ_VALUE("parasubcontract",
                "(idcon=" + QueryCreator.quotedstrvalue(ValoriCedolino["idcon"], true) + ")", "ncon");
            object idupb = ValoriCedolino["idupb"];

            if (idupb != DBNull.Value) {
                SetUPB(idupb);
            }


            //Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
            // anche a video.
            CurrRow["idreg"] = codicecreddeb; //		ValoriCedolino["codicecreddeb"];
            DateTime startCedolino = (DateTime) ValoriCedolino["start"];
            DateTime stopCedolino = (DateTime) ValoriCedolino["stop"];

            CurrRow["description"] = "Pagamento Cedolino n." +
                                     ValoriCedolino["fiscalyear"].ToString() + "/" +
                                     ValoriCedolino["npayroll"].ToString().PadLeft(2, '0') +
                                     " del contratto " + esercontratto.ToString() + "/" + numcontratto.ToString() +
                                     " per il periodo dal " + startCedolino.ToShortDateString() + " al " +
                                     stopCedolino.ToShortDateString();

            txtDescrizione.Text = CurrRow["description"].ToString();
            CurrRow["doc"] = "Cedolino " +
                             ValoriCedolino["fiscalyear"].ToString() + "/" +
                             ValoriCedolino["npayroll"].ToString().PadLeft(2, '0') +
                             " contr. " + esercontratto.ToString() + "/" + numcontratto.ToString().PadLeft(4, '0');

            //"Ord."+ValoriOrdine["documento"];
            txtDocumento.Text = CurrRow["doc"].ToString();

            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != codicecreddeb.ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            CedolinoLinkedMustBeEvalued = true;
            RintracciaCedolino();
            if (CedolinoLinked != null) {
                AbilitaDisabilitaControlliCedolino(false);
                //CalcolaContabilizzatiCedolino(Cedolino2); lo fa gi� RintracciaCedolino
                SetComboCausaleCedolino(CedolinoLinked);
                DataTable tParasubcontract = Meta.Conn.RUN_SELECT("parasubcontract", "requested_doc", null,
                    QHS.CmpEq("idcon", CedolinoLinked["idcon"]), null, null, true);
                DataRow rParasubcontract = tParasubcontract.Rows[0];
                ValorizzaFlagCertificati(rParasubcontract, false);
            }


            return true;
        }


        void ScollegaCedolino() {
            ValorizzaFlagCertificati(null, false);
            ResetCedolino();
            if (DS.expensepayroll.Rows.Count == 0) {
                AbilitaDisabilitaControlliCedolino(true);
                AbilitaDisabilitaCreditoreDebitore(true);
                //ClearControlliCedolino();
                //DS.expensetax.Clear();
                return;
            }

            DS.expensepayroll.Clear();
            DS.payroll.Clear();
            DataRow CurrRow = DS.expense.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
            }

            CurrRow["description"] = "";
            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            ClearControlliCedolino();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
            ClearComboCausale();
            ClearPrestazioni();
            AbilitaDisabilitaControlliCedolino(true);
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        //		bool RitenuteDevonoEssereCalcolate(){
        //			int faseritenute = fasespesamax;
        //			if (fasespesafine < faseritenute) return false;
        //			if ((fasemissione>=faseinizio) &&
        //				(ContabilizzazioneSelezionata()!=tipocont.cont_missione)) return false;
        //			if (fasemissione<faseinizio) return true;
        //			if ((faseinizio <= fasemissione) && 
        //				(fasemissione <= fasespesafine) &&
        //				(DS.missione.Rows.Count>0))return true;
        //			return false;
        //		}


        #endregion

        #region Gestione ComboBox Causale Cedolino

        decimal cedolinolordo;
        decimal contabilizzatocedolino;

        void SetEditComboCausaleCedolino() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(4, "Pagamento");
            object currtipo = 4; //DS.Tables["cedolinomovspesa"].Rows[0]["tipomovimento"].ToString();
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }

        void UpdateComboCausaleCedolino() {
            if (CedolinoMovSpesaLinked != null) {
                object currtipo = 4;
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }



        string lastCedEvalued = null;

        void CalcolaContabilizzatiCedolino(DataRow Cedolino) {
            string filterced = "(idpayroll='" + Cedolino["idpayroll"].ToString() + "')";
            decimal totlordo = CfgFn.GetNoNullDecimal(Cedolino["feegross"]);

            if (filterced == lastCedEvalued) return;
            lastCedEvalued = filterced;

            DataTable Residuo = MyConn.RUN_SELECT("payrollresidual", "*", null, filterced, null, true);
            if (Residuo.Rows.Count == 0) return;
            DataRow CurrResid = Residuo.Rows[0];
            contabilizzatocedolino = CfgFn.GetNoNullDecimal(CurrResid["linkedamount"]);
            decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residual"]);
            //contabilizzato_VARIAZIONI= -(totlordo - contabilizzatocedolino-residuo);
        }

        /// <summary>
        /// Metodo che verifica che non ci siano storni
        /// </summary>
        /// <param name="Cedolino"></param>
        /// <returns></returns>
        bool esistonoPagamentiDiStorni(DataRow Cedolino) {
            if (Cedolino == null) return true;
            string excludeIdExp = "";
            // Nel caso ci si trovi in EditMode viene scartato il movimento di spesa corrente
            if (Meta.EditMode) {
                DataRow Curr = DS.expense.Rows[0];
                QHS.CmpNe("idexp", Curr["idexp"]);
            }

            string filter = QHS.AppAnd(QHS.CmpEq("expensepayroll.idpayroll", Cedolino["idpayroll"]),
                excludeIdExp);
            string query = "SELECT COUNT(*) as number" +
                           " FROM expensepayroll " +
                           " JOIN expenselink " +
                           " ON expenselink.idparent = expensepayroll.idexp " +
                           " JOIN expenselast " +
                           " ON expenselast.idexp = expenselink.idchild " +
                           " JOIN expensetaxcorrige " +
                           " ON expensetaxcorrige.idexp = expenselast.idexp " +
                           " WHERE " + filter;

            DataTable t = MyConn.SQLRunner(query, true);

            if ((t == null) || (t.Rows.Count == 0)) return true;
            DataRow r = t.Rows[0];

            return (CfgFn.GetNoNullInt32(r["number"]) == 0);
        }

        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleCedolino(DataRow Cedolino) {
            if (!faseCedolinoInclusa()) {
                cmbCausale.Enabled = false;
                return;
            }

            cedolinolordo = CfgFn.GetNoNullDecimal(Cedolino["feegross"]);
            //totanticipo =  CfgFn.GetNoNullDecimal(Missione["totanticipo"]);

            //CalcolaContabilizzatiMissione(Missione);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            if ((Meta.EditMode) ||
                (contabilizzatocedolino < cedolinolordo)
            ) {
                EnableTipoMovimento(4, "Pagamento");
            }

            //DS.missionemovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
            cmbCausale.Enabled = false; //Meta.InsertMode;
            ReCalcImporto_Cedolino();

        }


        void ReCalcImporto_Cedolino() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            string tipomovimento = cmbCausale.SelectedValue.ToString();

            decimal importo = cedolinolordo - contabilizzatocedolino;

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");
        }

        private void cmbCausaleCedolino_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta.InsertMode) {
                //Meta.GetFormData(true);
                GetCausaleCedolino();
                ReCalcImporto_Cedolino(); //Richiama indirettamente RicalcolaPrestazioneMissione();
            }
        }


        /// <summary>
        /// Legge la causale dal combobox e la mette in tipomovimento ove 
        ///  possibile.
        /// </summary>
        int GetCausaleCedolino() {
            CurrCausaleCedolino = 0;
            if (!Meta.InsertMode) return 0;
            if (DS.expensepayroll.Rows.Count == 0) return 0;
            if (ContabilizzazioneSelezionata() != tipocont.cont_cedolino) return 0;
            CurrCausaleCedolino = 4;
            //DS.cedolinomovspesa.Rows[0]["tipomovimento"].ToString();
            return CurrCausaleCedolino;
            //ReCalcImporto();
        }

        #endregion


        #region Gestione Selezione Contratto Occasionale

        private void txtEsercOccasionale_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
        }

        string GetFilterOccasionale(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filterupb = null;
            object getupb = GetUpb();
            if (getupb != DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);
            }

            string FilterOccasionale = "(ycon<='" + esercizio.ToString() + "')";
            FilterOccasionale = GetData.MergeFilters(FilterOccasionale, filterupb);

            if (txtEsercDoc.Text != "") {
                int eserccontratto = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (eserccontratto <= esercizio)
                        FilterOccasionale = "(ycon='" + eserccontratto.ToString() + "')";
                    else
                        FilterOccasionale = GetData.MergeFilters(FilterOccasionale,
                            "(ycon='" + eserccontratto.ToString() + "')");
                }
                catch {
                }
            }

            if (FiltraNum) {
                int numcontratto = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterOccasionale = GetData.MergeFilters(FilterOccasionale,
                        "(ncon='" + numcontratto.ToString() + "')");
                }
            }

            if (Meta.InsertMode) {
                FilterOccasionale = QHS.AppAnd(FilterOccasionale, QHS.CmpEq("completed", "S"));
            }

            return FilterOccasionale;
        }


        private void btnOccasionale_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);

            string MyOccasionaleFilter;
            if (((Control) sender).Name == "txtNumDoc")
                MyOccasionaleFilter = GetFilterOccasionale(true);
            else
                MyOccasionaleFilter = GetFilterOccasionale(false);

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if (condfasecred && faseprecselected) {
                    MyOccasionaleFilter = GetData.MergeFilters(MyOccasionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
                    MyOccasionaleFilter = GetData.MergeFilters(MyOccasionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyOccasionaleFilter = GetData.MergeFilters(MyOccasionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MOccasionale;
            DataRow MyDROccasionale;

            if (Meta.IsEmpty) {
                MOccasionale = MetaData.GetMetaData(this, "casualcontractlinked");
                MOccasionale.FilterLocked = true;
                MOccasionale.DS = new DataSet(); //DS.Clone();
                MyDROccasionale = MOccasionale.SelectOne("default", MyOccasionaleFilter, null, null);
                if (MyDROccasionale == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                txtEsercDoc.Text = MyDROccasionale["ycon"].ToString();
                txtNumDoc.Text = MyDROccasionale["ncon"].ToString();
                return;
            }

            MOccasionale = MetaData.GetMetaData(this, "casualcontractavailable");
            MOccasionale.FilterLocked = true;
            MOccasionale.DS = new DataSet(); //DS.Clone();

            MyDROccasionale = MOccasionale.SelectOne("default", MyOccasionaleFilter,
                //GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
                null, null);

            if (MyDROccasionale == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectocc = "(ycon='" + MyDROccasionale["ycon"].ToString() + "')AND" +
                               "(ncon='" + MyDROccasionale["ncon"].ToString() + "')";

            string columnlist = QueryCreator.ColumnNameList(DS.casualcontract)
                                + ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("casualcontractview", columnlist, null, selectocc, null, null, true);

            if (Temp.Rows.Count == 0) return;

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetOccasionale();
                CollegaOccasionale(MyDR);
                //RintracciaOccasionale();
                ResetTipoClassAvailableEvalued();
                //RicalcolaPrestazioneOccasionale();
            }

        }

        private void txtNumOccasionale_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;

            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) {
                    ScollegaOccasionale();
                    ClearControlliOccasionale();
                }

                return;
            }

            btnOccasionale_Click(sender, e);
        }

        void AbilitaDisabilitaControlliOccasionale(bool abilita) {
            bool abilitalast = abilita && faseMaxInclusa();
            SubEntity_txtDataInizioPrest.ReadOnly = !abilitalast;
            SubEntity_txtDataFinePrest.ReadOnly = !abilitalast;
            SubEntity_cmbTipoprestazione.Enabled = abilitalast;
            //btnCalcoloGuidato.Enabled=abilitalast;
            //btnPrestazione.Enabled=abilitalast;

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            //btnInserisciRitenute.Enabled	= abilitalast||ModificaRitenuteAbilitata();
            // J.T.R. Consentiamo sempre di accedere al form figlio che si porr� in sola lettura nel caso
            // la prestazione adoperata non consenta modifiche alle ritenute.
            //btnModificaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();
            //btnEliminaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();

            //btnInserisciCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();
            //btnEliminaCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();

            //btnInserisciUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();
            //btnEliminaUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";
            //AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }

        void ClearControlliOccasionale() {
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SubEntity_txtDataInizioPrest.Text = "";
            SubEntity_txtDataFinePrest.Text = "";
            SubEntity_cmbTipoprestazione.SelectedIndex = -1;
            AbilitaDisabilitaControlliOccasionale(true);
        }

        /// <summary>
        /// Collega la riga missione al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        bool CollegaOccasionale(DataRow ContrattoOcc2) {
            if (Meta.EditMode) {
                if (faseOccasionaleInclusa()) {
                    txtEsercDoc.Text = ContrattoOcc2["ycon"].ToString();
                    txtNumDoc.Text = ContrattoOcc2["ncon"].ToString();
                }

                return false;
            }

            if (Meta.IsEmpty) return false;

            Hashtable ValoriOccasionale = new Hashtable();
            foreach (DataColumn C in DS.casualcontract.Columns)
                ValoriOccasionale[C.ColumnName] = ContrattoOcc2[C.ColumnName];

            //AzzeraPadre();
            ScollegaOccasionale();
            DataRow CurrRow = DS.expense.Rows[0];

            //Se la fase missione � presente, legge la riga missione e la collega al
            // movimento di spesa corrente
            if (faseOccasionaleInclusa()) {
                DataRow NewOccR = DS.casualcontract.NewRow();
                foreach (DataColumn C in DS.casualcontract.Columns) {
                    NewOccR[C.ColumnName] = ValoriOccasionale[C.ColumnName];
                }

                DS.casualcontract.Rows.Add(NewOccR);
                NewOccR.AcceptChanges();
                ContrattoOcc2 = NewOccR;

                MetaData MovOcc = MetaData.GetMetaData(this, "expensecasualcontract");
                MovOcc.SetDefaults(DS.expensecasualcontract);
                DS.expensecasualcontract.Columns["ycon"].DefaultValue = ValoriOccasionale["ycon"];
                DS.expensecasualcontract.Columns["ncon"].DefaultValue = ValoriOccasionale["ncon"];
                DataRow RMovOcc = MovOcc.Get_New_Row(CurrRow, DS.expensecasualcontract);
                DS.expensecasualcontract.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expensecasualcontract.Columns["ncon"].DefaultValue = DBNull.Value;
                txtEsercDoc.Text = ValoriOccasionale["ycon"].ToString();
                txtNumDoc.Text = ValoriOccasionale["ncon"].ToString();
            }

            //Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
            // anche a video.
            object codicecreddeb = ValoriOccasionale["idreg"];
            object esercontratto = ValoriOccasionale["ycon"];
            object numcontratto = ValoriOccasionale["ncon"];


            CurrRow["idreg"] = codicecreddeb;
            CurrRow["description"] = ValoriOccasionale["description"].ToString();
            //ValoriCedolino["descrizione"];

            txtDescrizione.Text = CurrRow["description"].ToString();
            CurrRow["doc"] = "Contratto Occasionale " +
                             ValoriOccasionale["ycon"].ToString().Substring(2, 2) + "/" +
                             ValoriOccasionale["ncon"].ToString().PadLeft(6, '0');
            txtDocumento.Text = CurrRow["doc"].ToString();
            CurrRow["docdate"] = ValoriOccasionale["adate"];
            txtDataDocumento.Text = HelpForm.StringValue(ValoriOccasionale["adate"], txtDataDocumento.Tag.ToString());


            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != codicecreddeb.ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (ValoriOccasionale["idupb"] != DBNull.Value) {
                SetUPB(ValoriOccasionale["idupb"]);
            }

            OccasionaleLinkedMustBeEvalued = true;
            RintracciaOccasionale();
            if (OccasionaleLinked != null) {
                AbilitaDisabilitaControlliOccasionale(false);
                AbilitaDisabilitaCreditoreDebitore(false);
                CalcolaContabilizzatiOccasionale(OccasionaleLinked);
                SetComboCausaleOccasionale(OccasionaleLinked);
                ValorizzaFlagCertificati(OccasionaleLinked, false);
            }

            return true;
        }

        /// <summary>
        /// ValorizzaFlagCertificati
        /// </summary>
        /// <param name="rCompenso"></param> riga del documento contaiblizzato
        /// <param name="forced"></param>true se � stato richiesto esplicitamente l'aggiornamento col button
        void ValorizzaFlagCertificati(DataRow rCompenso, bool forced) {
            if (!faseMaxInclusa()) return;
            rDocumentocontabilizzato = rCompenso;
            DataRow rExpenselast = DS.expenselast.Rows[0];
            if (rCompenso == null) {
                int oldValue = CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]);
                rExpenselast["paymethod_flag"] = (oldValue & ~0xFF8000);
                btnAggiornaCertificati.Enabled = false;
                return;
            }

            if (rCompenso.RowState == DataRowState.Detached) return;

            if (Meta.EditMode) {
                //Abilita o meno il button
                int flagCertificatiCompenso = CfgFn.GetNoNullInt32(rCompenso["requested_doc"]) & 511; // & 8, non sono pi� i bit 0,1 e 2 ma bit 0,1,2,3,4,5,6,7 e 8.
                flagCertificatiCompenso =
                    flagCertificatiCompenso << 15; // lo sposo di 15 a sinistra, per poterlo confrontare dopo
                int flagCertificatiSpesa = (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 32768) +
                                           (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 65536) +
                                          (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 131072) +
                                          (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 262144) +
                                          (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 524288) +
                                         (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 1048576) +
                                         (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 2097152) +
                                         (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 4194304) +
                                        (CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]) & 8388608); 
                if ((flagCertificatiCompenso != flagCertificatiSpesa) && (rExpenselast["kpay"] == DBNull.Value)) {
                    btnAggiornaCertificati.Enabled = true;
                }
                else {
                    btnAggiornaCertificati.Enabled = false;
                }
            }

            if ((Meta.EditMode) && !forced) {
                return;
            }

            //Aggiunge i bit 0,1,2 di casualcontract.requested_doc e li scrive nelle posizioni 15,16,17
            //Ora[15883] deve considerare anche i bit 3,4,5,6 e 7. Quindi requested_doc verr� spostato dal bit 15 fino al bit 22
            //Ora[18454] deve considerare anche il bit 8. Quindi requested_doc verr� spostato dal bit 15 fino al bit 23
            //requested_doc:
            //                  b8 b7  b6  b5  b4  b3  b2  b1  b0
            //paymethod_flag :
            //                  b23  b22 b21	b20	b19	b18	b17	b16	b15	
            if (Meta.InsertMode || (Meta.EditMode && forced)) {
                if (rExpenselast.Table.Columns.Contains("paymethod_flag")) {
                    int flag = CfgFn.GetNoNullInt32(rCompenso["requested_doc"]) & 511; // & 8
                    // lo spostiamo di 15 posizioni a sinistra
                    flag = flag << 15;
                    int oldValue = CfgFn.GetNoNullInt32(rExpenselast["paymethod_flag"]);
                    rExpenselast["paymethod_flag"] = flag | (oldValue & ~0xFF8000);
                }

                SpuntaCertificaticiNecessari(rExpenselast);
            }
        }

        DataRow rDocumentocontabilizzato = null;

        void SpuntaCertificaticiNecessari(DataRow expenselast) {
            SubEntity_chkCCdedicato.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 32768) == 0);
            SubEntity_chkVisura.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 65536) == 0);
            SubEntity_chkDurc.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 131072) == 0);
            chkCasellarioGiud.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 262144) == 0);
            chkCasellarioAmm.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 524288) == 0);
            chkOttempLegge.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 1048576) == 0);
            chkRegolaritaFisc.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 2097152) == 0);
            chkVerificaAnac.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 4194304) == 0);
            chkPattoIntegrita.Checked = !((CfgFn.GetNoNullInt32(expenselast["paymethod_flag"]) & 8388608) == 0);
        }

        void ScollegaOccasionale() {
            ValorizzaFlagCertificati(null, false);
            ResetOccasionale();
            if (DS.expensecasualcontract.Rows.Count == 0) {
                AbilitaDisabilitaControlliOccasionale(true);
                AbilitaDisabilitaCreditoreDebitore(true);
                //DS.expensetax.Clear();
                //ClearComboCausale();
                return;
            }

            DS.expensecasualcontract.Clear();
            DS.casualcontract.Clear();
            DataRow CurrRow = DS.expense.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
            }

            CurrRow["description"] = "";
            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            ClearControlliOccasionale();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
            ClearComboCausale();
            ClearPrestazioni();
            AbilitaDisabilitaControlliOccasionale(true);
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        //		bool RitenuteDevonoEssereCalcolate(){
        //			int faseritenute = fasespesamax;
        //			if (fasespesafine < faseritenute) return false;
        //			if ((fasemissione>=faseinizio) &&
        //				(ContabilizzazioneSelezionata()!=tipocont.cont_missione)) return false;
        //			if (fasemissione<faseinizio) return true;
        //			if ((faseinizio <= fasemissione) && 
        //				(fasemissione <= fasespesafine) &&
        //				(DS.missione.Rows.Count>0))return true;
        //			return false;
        //		}


        #endregion

        #region Gestione ComboBox Causale Occasionale

        decimal occasionalelordo;
        decimal contabilizzatooccasionale;

        void SetEditComboCausaleOccasionale() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(4, "Pagamento");
            object currtipo = 4; //DS.Tables["cedolinomovspesa"].Rows[0]["tipomovimento"].ToString();
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }

        void UpdateComboCausaleOccasionale() {
            if (OccasionaleMovSpesaLinked != null) {
                object currtipo = 4;
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }



        string lastOccEvalued = null;

        void CalcolaContabilizzatiOccasionale(DataRow ContrattoOcc) {
            string filterocc = "(ycon='" + ContrattoOcc["ycon"].ToString() + "')AND" +
                               "(ncon='" + ContrattoOcc["ncon"].ToString() + "')";
            decimal totlordo = CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);

            if (filterocc == lastOccEvalued) return;
            lastOccEvalued = filterocc;

            DataTable Residuo = MyConn.RUN_SELECT("casualcontractresidual", "*", null, filterocc, null, true);
            if (Residuo.Rows.Count == 0) return;
            DataRow CurrResid = Residuo.Rows[0];
            contabilizzatooccasionale = CfgFn.GetNoNullDecimal(CurrResid["linkedtotal"]);
            //decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residuo"]);
            //contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzatooccasionale);
        }



        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleOccasionale(DataRow ContrattoOcc) {
            if (!faseOccasionaleInclusa()) {
                cmbCausale.Enabled = false;
                return;
            }

            occasionalelordo = CfgFn.GetNoNullDecimal(ContrattoOcc["feegross"]);
            //totanticipo =  CfgFn.GetNoNullDecimal(Missione["totanticipo"]);

            //CalcolaContabilizzatiMissione(Missione);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            if ((Meta.EditMode) ||
                (contabilizzatooccasionale < occasionalelordo)
            ) {
                EnableTipoMovimento(4, "Pagamento");
            }

            //DS.missionemovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
            cmbCausale.Enabled = false; //Meta.InsertMode;
            ReCalcImporto_Occasionale();

        }


        void ReCalcImporto_Occasionale() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            string tipomovimento = cmbCausale.SelectedValue.ToString();

            decimal importo = occasionalelordo - contabilizzatooccasionale;

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");
        }

        private void cmbCausaleOccasionale_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta.InsertMode) {
                //Meta.GetFormData(true);
                GetCausaleOccasionale();
                ReCalcImporto_Occasionale(); //Richiama indirettamente RicalcolaPrestazioneMissione();
            }
        }


        /// <summary>
        /// Legge la causale dal combobox e la mette in tipomovimento ove 
        ///  possibile.
        /// </summary>
        int GetCausaleOccasionale() {
            CurrCausaleOccasionale = 0;
            if (!Meta.InsertMode) return 0;
            if (DS.expensecasualcontract.Rows.Count == 0) return 0;
            if (ContabilizzazioneSelezionata() != tipocont.cont_occasionale) return 0;
            CurrCausaleOccasionale = 4;
            //DS.cedolinomovspesa.Rows[0]["tipomovimento"].ToString();
            return CurrCausaleOccasionale;
            //ReCalcImporto();
        }

        #endregion



        #region Gestione Selezione Contratto Professionale

        private void txtEsercProfessionale_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
        }

        string GetFilterProfessionale(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filterupb = null;
            object getupb = GetUpb();
            if (getupb != DBNull.Value && Meta.InsertMode)
                filterupb = QHS.NullOrEq("idupb", getupb);
            string FilterProfessionale = "(ycon<='" + esercizio.ToString() + "')";
            FilterProfessionale = GetData.MergeFilters(FilterProfessionale, filterupb);
            if (txtEsercDoc.Text != "") {
                int eserccontratto = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (eserccontratto <= esercizio)
                        FilterProfessionale = "(ycon='" + eserccontratto.ToString() + "')";
                    else
                        FilterProfessionale = GetData.MergeFilters(FilterProfessionale,
                            "(ycon='" + eserccontratto.ToString() + "')");
                }
                catch {
                }
            }

            if (FiltraNum) {
                int numcontratto = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterProfessionale = GetData.MergeFilters(FilterProfessionale,
                        "(ncon='" + numcontratto.ToString() + "')");
                }
            }

            if (Meta.InsertMode) {
                FilterProfessionale += "AND(residual>'0')";
            }

            return FilterProfessionale;
        }


        private void btnProfessionale_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);

            string MyProfessionaleFilter;
            if (((Control) sender).Name == "txtNumDoc")
                MyProfessionaleFilter = GetFilterProfessionale(true);
            else
                MyProfessionaleFilter = GetFilterProfessionale(false);

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if (condfasecred && faseprecselected) {
                    MyProfessionaleFilter = GetData.MergeFilters(MyProfessionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
                    MyProfessionaleFilter = GetData.MergeFilters(MyProfessionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyProfessionaleFilter = GetData.MergeFilters(MyProfessionaleFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MProfessionale;
            DataRow MyDRProfessionale;

            if (Meta.IsEmpty) {
                MProfessionale = MetaData.GetMetaData(this, "profservicelinked");
                MProfessionale.FilterLocked = true;
                MProfessionale.DS = new DataSet(); //DS.Clone();
                MyDRProfessionale = MProfessionale.SelectOne("default", MyProfessionaleFilter, null, null);
                if (MyDRProfessionale == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                txtEsercDoc.Text = MyDRProfessionale["ycon"].ToString();
                txtNumDoc.Text = MyDRProfessionale["ncon"].ToString();
                return;
            }

            MProfessionale = MetaData.GetMetaData(this, "profserviceavailable");
            MProfessionale.FilterLocked = true;
            MProfessionale.DS = new DataSet(); //DS.Clone();

            MyDRProfessionale = MProfessionale.SelectOne("default", MyProfessionaleFilter,
                //GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
                null, null);

            if (MyDRProfessionale == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectocc = "(ycon='" + MyDRProfessionale["ycon"].ToString() + "')AND" +
                               "(ncon='" + MyDRProfessionale["ncon"].ToString() + "')";

            string columnlist = QueryCreator.ColumnNameList(DS.profservice)
                                + ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("profserviceview", columnlist, null, selectocc, null, null, true);

            if (Temp.Rows.Count == 0) return;

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetProfessionale();
                CollegaProfessionale(MyDR);
                //RintracciaProfessionale();
                ResetTipoClassAvailableEvalued();
                //RicalcolaPrestazioneProfessionale();
            }

        }

        private void txtNumProfessionale_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;

            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) {
                    ScollegaProfessionale();
                    ClearControlliProfessionale();
                }

                return;
            }

            btnProfessionale_Click(sender, e);
        }

        void AbilitaDisabilitaControlliProfessionale(bool abilita) {
            bool abilitalast = abilita && faseMaxInclusa();
            SubEntity_txtDataInizioPrest.ReadOnly = !abilitalast;
            SubEntity_txtDataFinePrest.ReadOnly = !abilitalast;
            SubEntity_cmbTipoprestazione.Enabled = abilitalast;
            //btnCalcoloGuidato.Enabled=abilitalast;
            //btnPrestazione.Enabled=abilitalast;

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            //btnInserisciRitenute.Enabled = abilitalast || ModificaRitenuteAbilitata();
            // J.T.R. Consentiamo sempre di accedere al form figlio che si porr� in sola lettura nel caso
            // la prestazione adoperata non consenta modifiche alle ritenute.
            //btnModificaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();
            //btnEliminaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();

            //btnInserisciCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();
            //btnEliminaCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();

            //btnInserisciUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();
            //btnEliminaUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";
            //AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }

        void ClearControlliProfessionale() {
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SubEntity_txtDataInizioPrest.Text = "";
            SubEntity_txtDataFinePrest.Text = "";
            SubEntity_cmbTipoprestazione.SelectedIndex = -1;
            AbilitaDisabilitaControlliProfessionale(true);
        }

        /// <summary>
        /// Collega la riga missione al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        bool CollegaProfessionale(DataRow ContrattoProf2) {
            if (Meta.EditMode) {
                if (faseProfessionaleInclusa()) {
                    txtEsercDoc.Text = ContrattoProf2["ycon"].ToString();
                    txtNumDoc.Text = ContrattoProf2["ncon"].ToString();
                }

                return false;
            }

            if (Meta.IsEmpty) return false;

            Hashtable ValoriProfessionale = new Hashtable();
            foreach (DataColumn C in DS.profservice.Columns)
                ValoriProfessionale[C.ColumnName] = ContrattoProf2[C.ColumnName];

            //AzzeraPadre();
            ScollegaProfessionale();
            DataRow CurrRow = DS.expense.Rows[0];

            //Se la fase missione � presente, legge la riga missione e la collega al
            // movimento di spesa corrente
            if (faseProfessionaleInclusa()) {
                DataRow NewProfR = DS.profservice.NewRow();
                foreach (DataColumn C in DS.profservice.Columns) {
                    NewProfR[C.ColumnName] = ValoriProfessionale[C.ColumnName];
                }

                DS.profservice.Rows.Add(NewProfR);
                NewProfR.AcceptChanges();
                ContrattoProf2 = NewProfR;

                MetaData MovProf = MetaData.GetMetaData(this, "expenseprofservice");
                MovProf.SetDefaults(DS.expenseprofservice);
                DS.expenseprofservice.Columns["ycon"].DefaultValue = ValoriProfessionale["ycon"];
                DS.expenseprofservice.Columns["ncon"].DefaultValue = ValoriProfessionale["ncon"];
                DataRow RMovProf = MovProf.Get_New_Row(CurrRow, DS.expenseprofservice);
                DS.expenseprofservice.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expenseprofservice.Columns["ncon"].DefaultValue = DBNull.Value;
                txtEsercDoc.Text = ValoriProfessionale["ycon"].ToString();
                txtNumDoc.Text = ValoriProfessionale["ncon"].ToString();
            }

            //Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
            // anche a video.
            object codicecreddeb = ValoriProfessionale["idreg"];
            object esercontratto = ValoriProfessionale["ycon"];
            object numcontratto = ValoriProfessionale["ncon"];




            CurrRow["idreg"] = codicecreddeb;
            CurrRow["description"] = ValoriProfessionale["description"].ToString();
            //ValoriCedolino["descrizione"];

            txtDescrizione.Text = CurrRow["description"].ToString();
            CurrRow["doc"] = ValoriProfessionale["doc"];
            txtDocumento.Text = CurrRow["doc"].ToString();
            CurrRow["docdate"] = ValoriProfessionale["docdate"];
            txtDataDocumento.Text = HelpForm.StringValue(ValoriProfessionale["docdate"],
                txtDataDocumento.Tag.ToString());

            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != codicecreddeb.ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (ValoriProfessionale["idupb"] != DBNull.Value) {
                SetUPB(ValoriProfessionale["idupb"]);
            }


            ProfessionaleLinkedMustBeEvalued = true;
            RintracciaProfessionale();
            if (ProfessionaleLinked != null) {
                AbilitaDisabilitaControlliProfessionale(false);
                AbilitaDisabilitaCreditoreDebitore(false);
                CalcolaContabilizzatiProfessionale(ProfessionaleLinked);
                SetComboCausaleProfessionale(ProfessionaleLinked);
                ValorizzaFlagCertificati(ProfessionaleLinked, false);
                if (Meta.InsertMode && ContabilizzazioneSelezionata() != tipocont.cont_iva) {

                    ResetIva();
                    if (CollegaIvaDaProfessionale(ProfessionaleLinked)) {
                        CollegaTuttiDettagliFattura();
                        RintracciaIva();
                        if ((IvaMovSpesaLinked != null) && (ProfessionaleMovSpesaLinked != null))
                            IvaMovSpesaLinked["movkind"] = ProfessionaleMovSpesaLinked["movkind"];
                        UpdateComboCausaleIva();
                        ResetTipoClassAvailableEvalued();
                    }
                }
            }

            return true;
        }


        void ScollegaProfessionale() {
            ValorizzaFlagCertificati(null, false);
            ResetProfessionale();
            if (DS.expenseprofservice.Rows.Count == 0) {
                AbilitaDisabilitaControlliProfessionale(true);
                AbilitaDisabilitaCreditoreDebitore(true);
                //ClearControlliProfessionale();
                //DS.expensetax.Clear();
                return;
            }

            DS.expenseprofservice.Clear();
            DS.profservice.Clear();
            DataRow CurrRow = DS.expense.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
            }

            CurrRow["description"] = "";
            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            ClearControlliProfessionale();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
            ClearComboCausale();
            ClearPrestazioni();
            AbilitaDisabilitaControlliProfessionale(true);
            AbilitaDisabilitaCreditoreDebitore(true);
        }

        //		bool RitenuteDevonoEssereCalcolate(){
        //			int faseritenute = fasespesamax;
        //			if (fasespesafine < faseritenute) return false;
        //			if ((fasemissione>=faseinizio) &&
        //				(ContabilizzazioneSelezionata()!=tipocont.cont_missione)) return false;
        //			if (fasemissione<faseinizio) return true;
        //			if ((faseinizio <= fasemissione) && 
        //				(fasemissione <= fasespesafine) &&
        //				(DS.missione.Rows.Count>0))return true;
        //			return false;
        //		}


        #endregion

        #region Gestione ComboBox Causale Professionale


        decimal totprofimponibile;
        decimal totprofiva;
        decimal assigned_profimponibile;
        decimal assigned_profiva;
        decimal assigned_profgen;



        void SetEditComboCausaleProfessionale() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(1, "Contabilizzazione Totale Fattura");
            EnableTipoMovimento(3, "Contabilizzazione Imponibile Fattura");
            EnableTipoMovimento(2, "Contabilizzazione Iva Fattura");
            //cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
            object currtipo = DS.Tables["expenseprofservice"].Rows[0]["movkind"];
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);

        }


        string lastProfEvalued = null;

        void CalcolaContabilizzatiProfessionale(DataRow ContrattoProf) {
            string filterprof = "(ycon='" + ContrattoProf["ycon"].ToString() + "')AND" +
                                "(ncon='" + ContrattoProf["ncon"].ToString() + "')";
            if (filterprof == lastProfEvalued) return;
            lastProfEvalued = filterprof;
            decimal lordobeneficiario = CfgFn.GetNoNullDecimal(ContrattoProf["totalgross"]);
            totprofiva = CfgFn.GetNoNullDecimal(ContrattoProf["ivaamount"]);
            totprofimponibile = lordobeneficiario - totprofiva;

            DataTable Residuo = MyConn.RUN_SELECT("profserviceresidual", "*", null, filterprof, null, true);
            if (Residuo.Rows.Count == 0) {
                assigned_profimponibile = totprofimponibile;
                assigned_profiva = totprofiva;
                assigned_profgen = lordobeneficiario;
                return;
            }

            DataRow CurrResid = Residuo.Rows[0];
            assigned_profimponibile = CfgFn.GetNoNullDecimal(CurrResid["linkedimpon"]);
            assigned_profiva = CfgFn.GetNoNullDecimal(CurrResid["linkedimpos"]);
            assigned_profgen = CfgFn.GetNoNullDecimal(CurrResid["linkeddocum"]);
            //decimal residuo = CfgFn.GetNoNullDecimal(CurrResid["residuo"]);
            //contabilizzato_VARIAZIONI= 0; //-(totlordo-residuo-contabilizzato_ANPAG-contabilizzato_SALDO);

        }



        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleProfessionale(DataRow ContrattoProf) {
            if (!faseProfessionaleInclusa()) return;
            DataAccess Conn = Meta.Conn;

            CalcolaContabilizzatiProfessionale(ContrattoProf);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            if ((Meta.EditMode) ||
                ((assigned_profimponibile + assigned_profiva) == 0) &&
                (assigned_profgen < (totprofimponibile + totprofiva))
            ) {
                EnableTipoMovimento(1, "Contabilizzazione Totale Fattura");
            }

            if ((Meta.EditMode) ||
                ((assigned_profgen == 0) && (assigned_profimponibile < totprofimponibile))
            ) {
                EnableTipoMovimento(3, "Contabilizzazione Imponibile Fattura");
            }

            if ((Meta.EditMode) ||
                ((assigned_profgen == 0) && (assigned_profiva < totprofiva))
            ) {
                EnableTipoMovimento(2, "Contabilizzazione Iva Fattura");
            }

            DS.expenseprofservice.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                ? cmbCausale.SelectedValue
                : DBNull.Value;
            cmbCausale.Enabled = Meta.InsertMode;
            ReCalcImporto_Professionale();

        }


        void ReCalcImporto_Professionale() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            int tipomovimento = CfgFn.GetNoNullInt32(cmbCausale.SelectedValue);

            decimal importo = 0;
            if (tipomovimento == 2) {
                importo = totprofiva - assigned_profiva;
            }

            if (tipomovimento == 3) {
                importo = totprofimponibile - assigned_profimponibile;
            }

            if (tipomovimento == 1) {
                importo = totprofimponibile + totprofiva - assigned_profgen;
            }

            if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
                show("Sar� effettuata una contabilizzazione parziale della fattura poich� la " +
                                "disponibilit� del movimento selezionato � inferiore a " + importo.ToString());
                importo = DisponibileDaFasePrecedente;
            }

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;				
            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");

        }

        private void cmbCausaleProfessionale_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.InsertMode) return;
            GetCausaleProfessionale();
            ReCalcImporto_Professionale();
        }

        int GetCausaleProfessionale() {
            CurrCausaleProfessionale = 0;
            if (!Meta.InsertMode) return 0;
            if (DS.expenseprofservice.Rows.Count == 0) return 0;
            if (cmbCausale.SelectedValue != null)
                DS.expenseprofservice.Rows[0]["movkind"] = cmbCausale.SelectedValue;
            else
                DS.expenseprofservice.Rows[0]["movkind"] = DBNull.Value;
            CurrCausaleProfessionale = CfgFn.GetNoNullInt32(DS.expenseprofservice.Rows[0]["movkind"]);
            return CurrCausaleProfessionale;
            //ReCalcImporto();
        }


        void UpdateComboCausaleProfessionale() {
            if (ProfessionaleMovSpesaLinked != null) {
                object currtipo = ProfessionaleMovSpesaLinked["movkind"];
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }

        #endregion


        #region Gestione Selezione Compenso Dipendente

        private void txtEsercDipendente_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtEsercDoc.ReadOnly) return;
            if (!Meta.DrawStateIsDone) return;
            FormattaDataDelTexBox(txtEsercDoc);
        }

        string GetFilterDipendente(bool FiltraNum) {
            int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
            string filterupb = null;
            object getupb = GetUpb();
            if (getupb != DBNull.Value && Meta.InsertMode) {
                filterupb = QHS.NullOrEq("idupb", getupb);
            }

            string FilterDipendente = "(ycon<='" + esercizio.ToString() + "')";
            FilterDipendente = GetData.MergeFilters(FilterDipendente, filterupb);
            if (txtEsercDoc.Text != "") {
                int eserccontratto = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
                try {
                    if (eserccontratto <= esercizio)
                        FilterDipendente = "(ycon='" + eserccontratto.ToString() + "')";
                    else
                        FilterDipendente = GetData.MergeFilters(FilterDipendente,
                            "(ycon='" + eserccontratto.ToString() + "')");
                }
                catch {
                }
            }

            if (FiltraNum) {
                int numcontratto = CfgFn.GetNoNullInt32(txtNumDoc.Text);
                if (txtNumDoc.Text != "") {
                    FilterDipendente = GetData.MergeFilters(FilterDipendente,
                        "(ncon='" + numcontratto.ToString() + "')");
                }
            }

            return FilterDipendente;
        }


        private void btnDipendente_Click(object sender, System.EventArgs e) {

            DataAccess Conn = MetaData.GetConnection(this);

            string MyDipendenteFilter;
            if (((Control) sender).Name == "txtNumDoc")
                MyDipendenteFilter = GetFilterDipendente(true);
            else
                MyDipendenteFilter = GetFilterDipendente(false);

            if (Meta.InsertMode) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred < currphase);
                DataRow Curr = DS.expense.Rows[0];
                bool faseprecselected = (Curr["parentidexp"] != DBNull.Value);
                if (condfasecred && faseprecselected) {
                    MyDipendenteFilter = GetData.MergeFilters(MyDipendenteFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }

                if ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != "")) {
                    MyDipendenteFilter = GetData.MergeFilters(MyDipendenteFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            if (Meta.IsEmpty) {
                int fasecred = ManageCreditore.faseattivazione;
                bool condfasecred = (fasecred <= currphase);
                bool faseprecselected = (txtCredDeb.Text.Trim() != "");
                if (condfasecred && faseprecselected) {
                    MyDipendenteFilter = GetData.MergeFilters(MyDipendenteFilter,
                        "(registry=" +
                        QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
                }
            }

            MetaData MDipendente;
            DataRow MyDRDipendente;

            if (Meta.IsEmpty) {
                MDipendente = MetaData.GetMetaData(this, "wageadditionlinked");
                MDipendente.FilterLocked = true;
                MDipendente.DS = new DataSet(); //DS.Clone();
                MyDRDipendente = MDipendente.SelectOne("default", MyDipendenteFilter, null, null);
                if (MyDRDipendente == null) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                        return;
                    }

                    return;
                }

                txtEsercDoc.Text = MyDRDipendente["ycon"].ToString();
                txtNumDoc.Text = MyDRDipendente["ncon"].ToString();
                return;
            }

            MDipendente = MetaData.GetMetaData(this, "wageadditionavailable");
            MDipendente.FilterLocked = true;
            MDipendente.DS = new DataSet(); //DS.Clone();

            MyDRDipendente = MDipendente.SelectOne("default", MyDipendenteFilter,
                //GetData.MergeFilters( MyMissioneFilter,"(residuo>'0')"),
                null, null);

            if (MyDRDipendente == null) {
                if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                    if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
                }

                return;
            }

            string selectdip = "(ycon='" + MyDRDipendente["ycon"].ToString() + "')AND" +
                               "(ncon='" + MyDRDipendente["ncon"].ToString() + "')";

            string columnlist = QueryCreator.ColumnNameList(DS.wageaddition)
                                + ",registry";
            DataTable Temp = Meta.Conn.RUN_SELECT("wageadditionview", columnlist, null, selectdip, null, null, true);

            //if (Temp.Rows.Count==0) return;

            DataRow MyDR = Temp.Rows[0];


            //Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
            //al fine di consentire il calcolo automatico del nuovo idspesa.
            //Poi eredito tutti i campi dell'eventuale movimento padre.
            if (Meta.InsertMode) {
                ResetDipendente();
                CollegaDipendente(MyDR);
                //RintracciaOccasionale();
                ResetTipoClassAvailableEvalued();
                //RicalcolaPrestazioneOccasionale();
            }

        }

        private void txtNumDipendente_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumDoc.ReadOnly) return;
            if (Meta.EditMode) return;
            //if (!Meta.InsertMode) return;

            if (txtNumDoc.Text.Trim() == "") {
                if (Meta.InsertMode) {
                    ScollegaDipendente();
                    ClearControlliDipendente();
                }

                return;
            }

            btnDipendente_Click(sender, e);
        }

        void AbilitaDisabilitaControlliDipendente(bool abilita) {
            bool abilitalast = abilita && faseMaxInclusa();
            SubEntity_txtDataInizioPrest.ReadOnly = !abilitalast;
            SubEntity_txtDataFinePrest.ReadOnly = !abilitalast;
            SubEntity_cmbTipoprestazione.Enabled = abilitalast;
            //btnCalcoloGuidato.Enabled=abilitalast;
            //btnPrestazione.Enabled=abilitalast;

            impostaFormRitenuteReadOnly();
            impostaFormStorniReadOnly();
            impostaFormUfficialeReadOnly();

            //btnInserisciRitenute.Enabled	= abilitalast||ModificaRitenuteAbilitata();
            // J.T.R. Consentiamo sempre di accedere al form figlio che si porr� in sola lettura nel caso
            // la prestazione adoperata non consenta modifiche alle ritenute.
            //btnModificaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();
            //btnEliminaRitenute.Enabled		= abilitalast||ModificaRitenuteAbilitata();

            //btnInserisciCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();
            //btnEliminaCorrezione.Enabled = abilitalast || ModificaStorniAbilitata();

            //btnInserisciUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();
            //btnEliminaUfficiale.Enabled = abilitalast || ModificaUfficialeAbilitata();

            if (btnModificaRitenute.Enabled)
                griddetriten.Tag = "expensetax.lista.default";
            else
                griddetriten.Tag = "expensetax.lista";

            if (btnModificaCorrezione.Enabled)
                dgCorrige.Tag = "expensetaxcorrige.lista.default";
            else
                dgCorrige.Tag = "expensetaxcorrige.lista";

            if (btnModificaUfficiale.Enabled)
                dgOfficial.Tag = "expensetaxofficial.lista.default";
            else
                dgOfficial.Tag = "expensetaxofficial.lista";
            //AbilitaDisabilitaCreditoreDebitore(abilita);
            //txtCredDeb.ReadOnly=!abilita;
        }

        void ClearControlliDipendente() {
            txtDescrizione.Text = "";
            txtDocumento.Text = "";
            txtDataDocumento.Text = "";
            SubEntity_txtDataInizioPrest.Text = "";
            SubEntity_txtDataFinePrest.Text = "";
            SubEntity_cmbTipoprestazione.SelectedIndex = -1;
            AbilitaDisabilitaControlliDipendente(true);
        }

        /// <summary>
        /// Collega la riga missione al movimento e aggiorna il form.
        /// </summary>
        /// <param name="Ordine"></param>
        bool CollegaDipendente(DataRow ContrattoDip2) {
            if (Meta.EditMode) {
                if (faseDipendenteInclusa()) {
                    txtEsercDoc.Text = ContrattoDip2["ycon"].ToString();
                    txtNumDoc.Text = ContrattoDip2["ncon"].ToString();
                }

                return false;
            }

            if (Meta.IsEmpty) return false;

            Hashtable ValoriDipendente = new Hashtable();
            foreach (DataColumn C in DS.wageaddition.Columns)
                ValoriDipendente[C.ColumnName] = ContrattoDip2[C.ColumnName];

            //AzzeraPadre();
            ScollegaDipendente();
            DataRow CurrRow = DS.expense.Rows[0];

            //Se la fase missione � presente, legge la riga missione e la collega al
            // movimento di spesa corrente
            if (faseDipendenteInclusa()) {
                DataRow NewDipR = DS.wageaddition.NewRow();
                foreach (DataColumn C in DS.wageaddition.Columns) {
                    NewDipR[C.ColumnName] = ValoriDipendente[C.ColumnName];
                }

                DS.wageaddition.Rows.Add(NewDipR);
                NewDipR.AcceptChanges();
                ContrattoDip2 = NewDipR;

                MetaData MovOcc = MetaData.GetMetaData(this, "expensewageaddition");
                MovOcc.SetDefaults(DS.expensewageaddition);
                DS.expensewageaddition.Columns["ycon"].DefaultValue = ValoriDipendente["ycon"];
                DS.expensewageaddition.Columns["ncon"].DefaultValue = ValoriDipendente["ncon"];
                DataRow RMovDip = MovOcc.Get_New_Row(CurrRow, DS.expensewageaddition);
                DS.expensewageaddition.Columns["ycon"].DefaultValue = DBNull.Value;
                DS.expensewageaddition.Columns["ncon"].DefaultValue = DBNull.Value;
                txtEsercDoc.Text = ValoriDipendente["ycon"].ToString();
                txtNumDoc.Text = ValoriDipendente["ncon"].ToString();
            }

            //Imposta i campi che devono essere ereditati dalla missione e li aggiorna 
            // anche a video.
            object codicecreddeb = ValoriDipendente["idreg"];
            object esercontratto = ValoriDipendente["ycon"];
            object numcontratto = ValoriDipendente["ncon"];

            CurrRow["idreg"] = codicecreddeb;
            CurrRow["description"] = ValoriDipendente["description"].ToString();
            //ValoriCedolino["descrizione"];

            txtDescrizione.Text = CurrRow["description"].ToString();
            CurrRow["doc"] = "Altri Compensi " +
                             ValoriDipendente["ycon"].ToString().Substring(2, 2) + "/" +
                             ValoriDipendente["ncon"].ToString().PadLeft(6, '0');
            txtDocumento.Text = CurrRow["doc"].ToString();
            CurrRow["docdate"] = ValoriDipendente["adate"];
            txtDataDocumento.Text = HelpForm.StringValue(ValoriDipendente["adate"], txtDataDocumento.Tag.ToString());


            if (DS.registry.Rows.Count > 0) {
                DataRow Cred = DS.registry.Rows[0];
                if (Cred["idreg"].ToString() != codicecreddeb.ToString()) {
                    DS.registry.Clear();
                    DS.registrypaymethod.Clear();
                }
            }

            if (DS.registry.Rows.Count == 0) {
                LeggiDatiSuCredDeb(CurrRow["idreg"]);
                CalcolaValoriDefaultModPagamento(CurrRow["idreg"]);
            }

            if (DS.registry.Rows.Count > 0) {
                DataRow CredDeb = DS.registry.Rows[0];
                SetComboCreditoreDebitore();
                txtCredDeb.Text = CredDeb["title"].ToString();
            }

            if (ValoriDipendente["idupb"] != DBNull.Value) {
                SetUPB(ValoriDipendente["idupb"]);
            }

            DipendenteLinkedMustBeEvalued = true;
            RintracciaDipendente();
            if (DipendenteLinked != null) {
                AbilitaDisabilitaControlliDipendente(false);
                AbilitaDisabilitaCreditoreDebitore(false);
                CalcolaContabilizzatiDipendente(DipendenteLinked);
                SetComboCausaleDipendente(DipendenteLinked);
            }

            return true;
        }


        void ScollegaDipendente() {
            ResetDipendente();
            if (DS.expensewageaddition.Rows.Count == 0) {
                AbilitaDisabilitaControlliDipendente(true);
                AbilitaDisabilitaCreditoreDebitore(true);
                //ClearControlliDipendente();
                //DS.expensetax.Clear();
                return;
            }

            DS.expensewageaddition.Clear();
            DS.wageaddition.Clear();
            DataRow CurrRow = DS.expense.Rows[0];
            int fasecreditore = ManageCreditore.faseattivazione;
            if (fasecreditore >= currphase) {
                CurrRow["idreg"] = DBNull.Value;
                txtCredDeb.Text = "";
            }

            CurrRow["description"] = "";
            CurrRow["doc"] = DBNull.Value;
            CurrRow["docdate"] = DBNull.Value;
            ClearControlliDipendente();
            DS.expensetax.Clear();
            DS.expensetaxcorrige.Clear();
            DS.expensetaxofficial.Clear();
            ClearComboCausale();
            ClearPrestazioni();
            AbilitaDisabilitaControlliDipendente(true);
            AbilitaDisabilitaCreditoreDebitore(true);
        }



        #endregion

        #region Gestione ComboBox Causale Dipendente

        decimal dipendentelordo;
        decimal contabilizzatodipendente;

        void SetEditComboCausaleDipendente() {
            if (!Meta.EditMode) return;
            ClearComboCausale();
            EnableTipoMovimento(4, "Pagamento");
            object currtipo = 4; //DS.Tables["cedolinomovspesa"].Rows[0]["tipomovimento"].ToString();
            HelpForm.SetComboBoxValue(cmbCausale, currtipo);
        }

        void UpdateComboCausaleDipendente() {
            if (DipendenteMovSpesaLinked != null) {
                object currtipo = 4;
                HelpForm.SetComboBoxValue(cmbCausale, currtipo);
            }
        }



        string lastDipEvalued = null;

        void CalcolaContabilizzatiDipendente(DataRow ContrattoDip) {
            string filterdip = "(ycon='" + ContrattoDip["ycon"].ToString() + "')AND" +
                               "(ncon='" + ContrattoDip["ncon"].ToString() + "')";
            decimal totlordo = CfgFn.GetNoNullDecimal(ContrattoDip["feegross"]);

            if (filterdip == lastDipEvalued) return;
            lastOccEvalued = filterdip;

            DataTable Residuo = MyConn.RUN_SELECT("wageadditionresidual", "*", null, filterdip, null, true);
            if (Residuo.Rows.Count == 0) return;
            DataRow CurrResid = Residuo.Rows[0];
            contabilizzatodipendente = CfgFn.GetNoNullDecimal(CurrResid["linkedtotal"]);
            //decimal residuo = CfgFn.GetNoNullDecimal( CurrResid["residuo"]);
            //contabilizzato_VARIAZIONI= -(totlordo-residuo-contabilizzatooccasionale);
        }



        /// <summary>
        /// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
        /// </summary>
        /// <param name="Ordine"></param>
        void SetComboCausaleDipendente(DataRow ContrattoDip) {
            if (!faseDipendenteInclusa()) {
                cmbCausale.Enabled = false;
                return;
            }

            dipendentelordo = CfgFn.GetNoNullDecimal(ContrattoDip["feegross"]);
            //totanticipo =  CfgFn.GetNoNullDecimal(Missione["totanticipo"]);

            //CalcolaContabilizzatiMissione(Missione);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

            if ((Meta.EditMode) ||
                (contabilizzatodipendente < dipendentelordo)
            ) {
                EnableTipoMovimento(4, "Pagamento");
            }

            //DS.missionemovspesa.Rows[0]["tipomovimento"]=	 cmbCausale.SelectedValue;
            cmbCausale.Enabled = false; //Meta.InsertMode;
            ReCalcImporto_Dipendente();

        }


        void ReCalcImporto_Dipendente() {
            if (Meta.IsEmpty) return;
            if (EsisteEsercPrecedente()) return;
            DataRow Curr = DS.Tables["expense"].Rows[0];
            if ((currphase > 1) && (Curr["parentidexp"] == DBNull.Value)) return;
            if (cmbCausale.SelectedValue == null) return;

            string tipomovimento = cmbCausale.SelectedValue.ToString();

            decimal importo = dipendentelordo - contabilizzatodipendente;

            //if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;	

            if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
                show("Sar� effettuata una contabilizzazione parziale del compenso poich� la " +
                                "disponibilit� del movimento selezionato � inferiore a " + importo.ToString());
                importo = DisponibileDaFasePrecedente;
            }

            SetImporto(importo);
            SubEntity_txtImportoMovimento.Text = importo.ToString("c");
        }

        private void cmbCausaleDipendente_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (Meta.InsertMode) {
                //Meta.GetFormData(true);
                GetCausaleDipendente();
                ReCalcImporto_Dipendente(); //Richiama indirettamente RicalcolaPrestazioneMissione();
            }
        }


        /// <summary>
        /// Legge la causale dal combobox e la mette in tipomovimento ove 
        ///  possibile.
        /// </summary>
        int GetCausaleDipendente() {
            CurrCausaleDipendente = 0;
            if (!Meta.InsertMode) return 0;
            if (DS.expensewageaddition.Rows.Count == 0) return 0;
            if (ContabilizzazioneSelezionata() != tipocont.cont_dipendente) return 0;
            CurrCausaleDipendente = 4;
            //DS.cedolinomovspesa.Rows[0]["tipomovimento"].ToString();
            return CurrCausaleDipendente;
            //ReCalcImporto();
        }

        #endregion

        private void btnGerarchia_Click(object sender, System.EventArgs e) {
            MetaData newSpesa = MetaData.GetMetaData(this, "expense");
            newSpesa.Edit(this.ParentForm, "gerarchico", false);
            object idspesa = DS.expense.Rows[0]["idexp"];


            DataRow R = newSpesa.SelectOne(newSpesa.DefaultListType,
                "(ayear='" + Meta.GetSys("esercizio").ToString() + "')AND" +
                "(idexp=" + QueryCreator.quotedstrvalue(idspesa, true) + ")", "expense", null);

            if (R != null) newSpesa.SelectRow(R, newSpesa.DefaultListType);
            
        }


        #region Reset / Rintraccia documenti

        void ResetCedolino() {
            CedolinoLinkedMustBeEvalued = true;
            CedolinoLinked = null;
            CedolinoMovSpesaLinked = null;
            //CedolinoMovSpesaViewLinked=null;
            lastCedEvalued = null;
        }

        void RintracciaCedolino() {
            if (!CedolinoLinkedMustBeEvalued) return;
            GetDocCedolino(out CedolinoLinked,
                out CedolinoMovSpesaLinked,
                //out CedolinoMovSpesaViewLinked, 
                out CurrCausaleCedolino);
            if ((CedolinoLinked != null) && (faseMaxInclusa())) {
                CalcolaContabilizzatiCedolino(CedolinoLinked);
                DataTable tParasubcontract = Meta.Conn.RUN_SELECT("parasubcontract", "requested_doc", null,
                    QHS.CmpEq("idcon", CedolinoLinked["idcon"]), null, null, true);
                DataRow rParasubcontract = tParasubcontract.Rows[0];
                ValorizzaFlagCertificati(rParasubcontract, false);
            }

            CedolinoLinkedMustBeEvalued = false;
        }

        void ResetMissione() {
            MissionLinkedMustBeEvalued = true;
            MissionLinked = null;
            MissioneMovSpesaLinked = null;
            MissioneMovSpesaViewLinked = null;
            lastMissEvalued = null;
        }

        void RintracciaMissione() {
            if (!MissionLinkedMustBeEvalued) return;
            GetDocMissione(out MissionLinked,
                out MissioneMovSpesaLinked,
                //out MissioneMovSpesaViewLinked, 
                out CurrCausaleMissione);
            if ((MissionLinked != null) && (faseMaxInclusa())) {
                CalcolaContabilizzatiMissione(MissionLinked);
            }

            if (MissionLinked != null) {
                AssegnaAltriDatiMissione(MissionLinked);
            }

            MissionLinkedMustBeEvalued = false;
        }

        void ResetOccasionale() {
            OccasionaleLinkedMustBeEvalued = true;
            OccasionaleLinked = null;
            OccasionaleMovSpesaLinked = null;
            //OccasionaleMovSpesaViewLinked=null;
            lastOccEvalued = null;
        }

        void RintracciaOccasionale() {
            if (!OccasionaleLinkedMustBeEvalued) return;
            GetDocOccasionale(out OccasionaleLinked,
                out OccasionaleMovSpesaLinked,
                //out OccasionaleMovSpesaViewLinked, 
                out CurrCausaleOccasionale);
            if ((OccasionaleLinked != null) && (faseMaxInclusa())) {
                CalcolaContabilizzatiOccasionale(OccasionaleLinked);
                ValorizzaFlagCertificati(OccasionaleLinked, false);
            }

            OccasionaleLinkedMustBeEvalued = false;
        }

        bool CollegaIvaDaProfessionale(DataRow ProfessionaleLinked) {

            string filter = QHS.CmpMulti(ProfessionaleLinked, "idinvkind", "yinv", "ninv");
            DataTable Invoice = Meta.Conn.RUN_SELECT("invoice", "*", null, filter, null, false);
            DataTable InvoiceResidualMandate = Meta.Conn.RUN_SELECT("invoiceresidualmandate", "*", null,
                QHS.AppAnd(QHS.CmpMulti(ProfessionaleLinked, "idinvkind", "yinv", "ninv", "idupb"),
                    QHS.CmpGt("residual", 0)), null, false);
            DataRow IVA = Invoice.First(filter);
            if (IVA == null) return false;
            DataRow IVAResidual = InvoiceResidualMandate.First(
                QHS.AppAnd(QHS.CmpMulti(ProfessionaleLinked, "idinvkind", "yinv", "ninv"), QHS.CmpGt("residual", 0)));
            if (IVAResidual == null) return false;

            SetContabilizzazione(tipocont.cont_iva);
            CollegaIva(IVA, IVAResidual);

            return true;

        }

        void ResetProfessionale() {
            ProfessionaleLinkedMustBeEvalued = true;
            ProfessionaleLinked = null;
            ProfessionaleMovSpesaLinked = null;
            //ProfessionaleMovSpesaViewLinked=null;
            lastProfEvalued = null;
        }

        void RintracciaProfessionale() {
            if (!ProfessionaleLinkedMustBeEvalued) return;
            if (monofase) {
                RintracciaProfessionaleMonoFase();
                return;
            }
            GetDocProfessionale(out ProfessionaleLinked,
                out ProfessionaleMovSpesaLinked,
                //out ProfessionaleMovSpesaViewLinked, 
                out CurrCausaleProfessionale);
            if ((ProfessionaleLinked != null) && (faseMaxInclusa())) {
                CalcolaContabilizzatiProfessionale(ProfessionaleLinked);
                ValorizzaFlagCertificati(ProfessionaleLinked, false);

            }

            ProfessionaleLinkedMustBeEvalued = false;
        }

        void RintracciaProfessionaleMonoFase() {
            if (Meta.InsertMode) {
                if (IvaLinked == null) //if (DS.expenseinvoice.Rows.Count == 0)
                    return;

                string filterFattura = QHC.MCmp(DS.expenseinvoice.Rows[0], "idinvkind", "yinv", "ninv");
                filterFattura = QHC.AppAnd(filterFattura, QHC.CmpGt("residual", 0));
                MetaData MParcellaavailable = MetaData.GetMetaData(this, "profserviceavailablemono");
                MParcellaavailable.FilterLocked = true;
                MParcellaavailable.DS = DS;
                if (Meta.Conn.RUN_SELECT_COUNT("profserviceavailablemono", filterFattura, false) == 0) return;
                DataRow MyDR = MParcellaavailable.SelectOne("default", filterFattura, null, null);
                if (MyDR == null) {
                    return;
                }
                string filterParcella = QHS.AppAnd(QHS.CmpEq("ycon", MyDR["ycon"]), QHS.CmpEq("ncon", MyDR["ncon"]));
                DataTable Rprofservice = Meta.Conn.RUN_SELECT("profservice", "*", null, filterParcella, null, false);
                ProfessionaleLinked = Rprofservice.Rows[0]; ;

                if ((ProfessionaleLinked != null) && (faseMaxInclusa())) {
                    CalcolaContabilizzatiProfessionale(ProfessionaleLinked);
                    ValorizzaFlagCertificati(ProfessionaleLinked, false);
                }
                ProfessionaleLinkedMustBeEvalued = false;
            }
        }

        void ResetDipendente() {
            DipendenteLinkedMustBeEvalued = true;
            DipendenteLinked = null;
            DipendenteMovSpesaLinked = null;
            //DipendenteMovSpesaViewLinked=null;
            lastDipEvalued = null;
        }

        void RintracciaDipendente() {
            if (!DipendenteLinkedMustBeEvalued) return;
            GetDocDipendente(out DipendenteLinked,
                out DipendenteMovSpesaLinked,
                //out DipendenteMovSpesaViewLinked, 
                out CurrCausaleDipendente);
            if ((DipendenteLinked != null) && (faseMaxInclusa())) {
                CalcolaContabilizzatiDipendente(DipendenteLinked);
            }

            DipendenteLinkedMustBeEvalued = false;
        }

        void ResetOrdine() {
            OrdineLinkedMustBeEvalued = true;
            OrdineLinked = null;
            OrdineGenericoMovSpesaLinked = null;
            //OrdineGenericoMovSpesaViewLinked=null;
        }

        void RintracciaOrdine() {
            if (!OrdineLinkedMustBeEvalued) return;
            GetDocOrdine(out OrdineLinked,
                out OrdineGenericoMovSpesaLinked,
                //out OrdineGenericoMovSpesaViewLinked, 
                out CurrCausaleOrdine);
            if ((OrdineLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))) {
                //CalcolaContabilizzatiMissione(MissionLinked);
                AssegnaDatiContratto(OrdineLinked);
            }

            if (OrdineLinked != null) {
                AssegnaAltriDatiContratto(OrdineLinked);
                ValorizzaFlagCertificati(OrdineLinked, false);
            }

            OrdineLinkedMustBeEvalued = false;
        }


        void AssegnaDatiContratto(DataRow Contratto) {
            if (DS.expenselast.Rows.Count == 0) return;
            DataRow curr = DS.expense.Rows[0];
            DataRow currlast = DS.expenselast.Rows[0];

            EP_functions EP = new EP_functions(Meta.Dispatcher);

            object idaccmotive = DBNull.Value;
            object idacc = DBNull.Value;

            idaccmotive = Contratto["idaccmotivedebit_crg"];
            if (idaccmotive == DBNull.Value) idaccmotive = Contratto["idaccmotivedebit"];

            if (EP.attivo) {
                idacc = EP.GetSupplierAccountForRegistry(idaccmotive, curr["idreg"]);
            }

            if (idacc != DBNull.Value) {
                if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
                    DS.account.Clear();
                    Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
                    if (DS.account.Rows.Count > 0) {
                        DataRow Acc = DS.account.Rows[0];
                        txtCodiceContoSupplier.Text = Acc["codeacc"].ToString();
                        txtDescrContoSupplier.Text = Acc["title"].ToString();
                    }
                }

                currlast["idaccdebit"] = idacc;
            }
        }

        void AssegnaAltriDatiContratto(DataRow Contratto) {
            txtApplierAnnotations.Text = Contratto["applierannotations"].ToString();
        }

        void AssegnaAltriDatiMissione(DataRow Missione) {
            txtApplierAnnotations.Text = Missione["applierannotations"].ToString();
        }

        void ResetIva() {
            IvaLinkedMustBeEvalued = true;
            IvaLinked = null;
            IvaMovSpesaLinked = null;
            //IvaMovSpesaViewLinked=null;
        }

        void RintracciaIva() {
            if (!IvaLinkedMustBeEvalued) return;
            GetDocIva(out IvaLinked,
                out IvaMovSpesaLinked,
                //out IvaMovSpesaViewLinked, 
                out CurrCausaleIva);
            if ((IvaLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))) {
                AssegnaDatiContratto(IvaLinked);
            }

            if (IvaLinked != null) {
                ValorizzaFlagCertificati(IvaLinked, false);
            }

            IvaLinkedMustBeEvalued = false;
        }

        #endregion


        #region Gestione Recuperi



        void AzzeraRigaRecupero(object codice) {
            DataRow[] found =
                DS.expenseclawback.Select("(idclawback=" + QueryCreator.quotedstrvalue(codice, false) + ")");
            if (found.Length == 0) return;
            found[0].Delete();
        }

        void GeneraRigaRecupero(object codice, decimal importo) {
            DataRow[] found = DS.expenseclawback.Select("(idclawback=" +
                                                        QueryCreator.quotedstrvalue(codice, false) + ")");
            DataRow Recupero;
            if (found.Length > 0) {
                Recupero = found[0];
                if ((Recupero.RowState != DataRowState.Added) && (importo > 0)) {
                    show("Non � stato possibile generare un recupero sugli anticipi poich� " +
                                    " ne � gi� presente uno collegato a questo movimento di spesa");
                }

                if (Recupero.RowState != DataRowState.Added) return;
            }
            else {
                DataRow Parent = DS.expense.Rows[0];
                MetaData MetaRec = MetaData.GetMetaData(this, "expenseclawback");
                MetaRec.SetDefaults(DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = codice;
                Recupero = MetaRec.Get_New_Row(Parent, DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = DBNull.Value;
            }

            Recupero["amount"] = importo;
            Recupero["!clawbackref"] =
                DS.clawback.Compute("MIN(clawbackref)", QHC.CmpEq("idclawback", Recupero["idclawback"]));
            HelpForm.SetDataGrid(dGridRecuperi, DS.expenseclawback);
        }


        /// <summary>
        /// Ogni volta che � effettuata una contabilizzazione a saldo di una missione
        ///  su cui � stato contabilizzato almeno un anticipo di tipo ANIGIR (su partita
        ///   di giro) � creato un recupero di importo pari alla somma degli anticipi 
        ///   meno i recuperi gi� effettuati e contabilizzati in entrata
        ///   L'importo da recuperare � calcolato come somma degli importi correnti
        ///    dei movimenti ANGIR LIQUIDATI relativi a quella missione. 
        /// </summary>
        /// 
        void GeneraOAzzeraRigaRecupero() {
            if (Meta.IsEmpty) return;
            //Vede se � inclusa la fase dei recuperi
            int faserecupero = fasespesamax;
            bool faserecuperoinclusa = (faserecupero == currphase);
            //la tabella recuperi � svuotata dalla logica standard delle fasi
            if (!faserecuperoinclusa) return;

            if (DS.config.Rows.Count == 0) return;
            DataRow PersMissione = DS.config.Rows[0];
            object codicerecupero = PersMissione["idclawback"];
            if (codicerecupero == DBNull.Value) return;


            RintracciaMissione();

            DataRow Missione = MissionLinked;
            DataRow MissioneMovSpesa = MissioneMovSpesaLinked;
            DataTable MissioneMovSpesaView = MissioneMovSpesaViewLinked;

            if ((MissionLinked == null) || (MissioneMovSpesa == null) ||
                (MissioneMovSpesa["movkind"].ToString() != "4")) {
                AzzeraRigaRecupero(codicerecupero);
                return;
            }

            DataRow CurrMiddle = MissioneMovSpesaLinked;

            string filtermissione = QueryCreator.WHERE_KEY_CLAUSE(Missione,
                DataRowVersion.Default, true);
            string filter = QHS.AppAnd(filtermissione,
                QHS.AppAnd(QHS.CmpEq("I.autokind", 6), QHS.CmpEq("I.nphase", faseentratamax)));

            decimal ImportiSpesaContabilizzatiANGIR = CfgFn.GetNoNullDecimal(
                MyConn.DO_READ_VALUE("itinerationresidual", filtermissione, "linkedangir"));

            if (ImportiSpesaContabilizzatiANGIR == 0) {
                AzzeraRigaRecupero(codicerecupero);
                return;
            }

            decimal ImportiRecuperati = CfgFn.GetNoNullDecimal(MyConn.DO_SYS_CMD(
                "SELECT SUM(curramount) from incometotal IT join " +
                " income I on IT.idinc=I.idinc and I.ymov= IT.ayear " +
                " JOIN expenselink EL on EL.idchild = I.idpayment " +
                " JOIN expenseitineration  on expenseitineration.idexp= EL.idparent " +
                " WHERE " + filter));


            decimal ImportoDaRecuperare = ImportiSpesaContabilizzatiANGIR - ImportiRecuperati;
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(codicerecupero);
                return;
            }

            GeneraRigaRecupero(codicerecupero, ImportoDaRecuperare);
        }

        void GeneraOAzzeraRecuperoIvaEstera() {
            if (Meta.IsEmpty) return;
            // Controllo se ha gi� generato Automatismi Recuperi
            if (SubEntity_chkAutomRecuperi.Checked) return;

            if (DS.invoice.Rows.Count == 0) return;
            DataRow Fattura = DS.invoice.Rows[0];
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            if (!intracom) return;

            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if ((flag & 64) == 0) //Recupero IVA Intra ed Extra-UE = N
                return;

            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(MyConn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " + QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.FieldIn("flagactivity", new object[] { 2, 3, 4 }))));//Comm. Promoscuo o qualsiasi
            bool isAcquistoCommerciale = nAcq > 0;

            int nIst = CfgFn.GetNoNullInt32(MyConn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " + QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("registerclass", "A"),
                    QHS.CmpEq("flagactivity", 1))));//Ist
            bool isAcquistoIstituzionale = nIst > 0;

            //Vede se � inclusa la fase dei recuperi
            int faserecupero = fasespesamax;
            bool faserecuperoinclusa = (faserecupero == currphase);
            //la tabella recuperi � svuotata dalla logica standard delle fasi
            if (!faserecuperoinclusa) return;

            if (DS.clawback.Rows.Count == 0) return;
            string codeClawBack = isAcquistoCommerciale ? "IVAESTERA_COMM" : "IVAESTERA_IST";

            string codeToDelete = isAcquistoCommerciale ? "IVAESTERA_IST" : "IVAESTERA_COMM";
            DataRow[] RSplitPaymentToDel = DS.clawback.Select(QHC.CmpEq("clawbackref", codeToDelete));
            if (RSplitPaymentToDel.Length > 0) {
                object codicerecuperoToDelete = RSplitPaymentToDel[0]["idclawback"];
                AzzeraRigaRecupero(codicerecuperoToDelete);
            }

            DataRow[] RIvaEstera = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RIvaEstera.Length == 0) return;

            object codicerecupero = RIvaEstera[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;

            decimal ImportoDaRecuperare = CalcolaIvaInBaseADettagliFattura();

            decimal ImportoVariazioni = CalcolaIvaNoteDiCredito();
            ImportoDaRecuperare -= ImportoVariazioni;

            if (ImportoDaRecuperare < 0) {
                show(
                    "Attenzione, l'importo del Recupero IVA Estera � negativo");
                return;
            }

            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(codicerecupero);
                return;
            }

            GeneraRigaRecuperoSplitPayment_o_IvaEstera(codicerecupero, ImportoDaRecuperare);
        }
        void GeneraRigaRecuperoSplitPayment_o_IvaEstera(object codice, decimal importo) {
            DataRow[] found = DS.expenseclawback.Select(QHS.CmpEq("idclawback", codice));
            DataRow Recupero;
            if (found.Length > 0) {

                Recupero = found[0];
                //if (Recupero.RowState != DataRowState.Added) return;
                if (CfgFn.GetNoNullDecimal(Recupero["amount"]) == importo) return;
            } else {
                DataRow Parent = DS.expense.Rows[0];
                MetaData MetaRec = MetaData.GetMetaData(this, "expenseclawback");
                MetaRec.SetDefaults(DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = codice;
                Recupero = MetaRec.Get_New_Row(Parent, DS.expenseclawback);
                DS.expenseclawback.Columns["idclawback"].DefaultValue = DBNull.Value;
            }

            Recupero["amount"] = importo;
            Recupero["!clawbackref"] =
                DS.clawback.Compute("MIN(clawbackref)", QHC.CmpEq("idclawback", Recupero["idclawback"]));
            HelpForm.SetDataGrid(dGridRecuperi, DS.expenseclawback);
        }


        void GeneraOAzzeraRecuperoSplitPayment() {
            if (Meta.IsEmpty) return;
            // Controllo se ha gi� generato Automatismi Recuperi
            if (SubEntity_chkAutomRecuperi.Checked) return;

            if (DS.invoice.Rows.Count == 0) return;
            DataRow Fattura = DS.invoice.Rows[0];
            if (Fattura["flag_enable_split_payment"].ToString() == "N") return;
            bool intracom = false;
            if (Fattura["flagintracom"].ToString().ToUpper() != "N") intracom = true;
            int flag = CfgFn.GetNoNullInt32(Fattura["flagbit"]);
            if (intracom && (flag & 64) != 0) //Verr� generato il Recupero IVA Intra ed Extra-UE 
                return;
            object currIdInvKind = Fattura["idinvkind"];
            int nAcq = CfgFn.GetNoNullInt32(MyConn.DO_SYS_CMD(
                "select count(*) from invoicekindregisterkind IIRK " +
                " join ivaregisterkind IRK on IRK.idivaregisterkind = IIRK.idivaregisterkind " +
                " where " + QHS.AppAnd(QHS.CmpEq("IIRK.idinvkind", currIdInvKind), QHS.CmpEq("IRK.registerclass", "A"),
                    QHS.CmpNe("IRK.flagactivity", 1))));
            bool isAcquistoCommerciale = nAcq > 0;

            //Vede se � inclusa la fase dei recuperi
            int faserecupero = fasespesamax;
            bool faserecuperoinclusa = (faserecupero == currphase);
            //la tabella recuperi � svuotata dalla logica standard delle fasi
            if (!faserecuperoinclusa) return;

            if (DS.clawback.Rows.Count == 0) return;
            string codeClawBack = isAcquistoCommerciale ? "16_SPLIT_PAYMENT_C" : "15_SPLIT_PAYMENT";

            string codeToDelete = isAcquistoCommerciale ? "15_SPLIT_PAYMENT" : "16_SPLIT_PAYMENT_C";
            DataRow[] RSplitPaymentToDel = DS.clawback.Select(QHC.CmpEq("clawbackref", codeToDelete));
            if (RSplitPaymentToDel.Length > 0) {
                object codicerecuperoToDelete = RSplitPaymentToDel[0]["idclawback"];
                AzzeraRigaRecupero(codicerecuperoToDelete);
            }

            DataRow[] RSplitPayment = DS.clawback.Select(QHC.CmpEq("clawbackref", codeClawBack));
            if (RSplitPayment.Length == 0) return;

            object codicerecupero = RSplitPayment[0]["idclawback"];
            if (codicerecupero == DBNull.Value) return;

            decimal ImportoDaRecuperare = CalcolaIvaInBaseADettagliFattura();

            decimal ImportoVariazioni = CalcolaIvaNoteDiCredito();
            ImportoDaRecuperare -= ImportoVariazioni;

            if (ImportoDaRecuperare < 0) {
                show(
                    "Attenzione, l'importo del Recupero legato all'applicazione dello Split Payment � negativo");
                return;
            }

            // Calcolo importo IVA da contabilizzare
            if (ImportoDaRecuperare == 0) {
                AzzeraRigaRecupero(codicerecupero);
                return;
            }

            GeneraRigaRecuperoSplitPayment_o_IvaEstera(codicerecupero, ImportoDaRecuperare);

        }

        #endregion

        private void btnGeneraClassAutomatiche_Click(object sender, System.EventArgs e) {
	        Meta.GetFormData(true);
            ManageClassificazioni.btnGeneraClass_Click(currphase, currphase);
            //if siopekind.newcomputesorting ='S' aggiunge le class. , leggendo il Cod.Class. dal documento contabilizzato 
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind",
						QHS.AppAnd( QHS.CmpEq("codesorkind_siopespese", Meta.GetSys("codesorkind_siopespese")),
									QHS.CmpEq("ayear",CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
							), 
						"newcomputesorting")?.ToString();
            if ((newcomputesorting == "S") && (currphase == fasespesamax)) {
                //Classifica il movimento in base all'idsor_siope specificato nel documento contabilizzato
                ManageClassificazioni.ClassificaTramiteClassDocumento(DS, null);
			}
            ManageClassificazioni.completaClassificazioniSiope(DS.expensesorted, DS);
            Meta.FreshForm();
        }

        private void btnBilancio_Click(object sender, System.EventArgs e) {
            string filter = "";
            if (!Meta.IsEmpty) Meta.GetFormData(true);

            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "(ayear ='" + esercizio.ToString() + "')and((flag & 1)=1)";

            //Il filtro sull'UPB c'� sempre
            if (!chkListManager.Checked) {
                object getupb = GetUpb();
                if (getupb != DBNull.Value) {
                    filter = QHS.CmpEq("idupb", getupb);
                }
                else {
                    filter = QHS.CmpEq("idupb", "0001"); // "(idupb='0001')";
                }
            }

            filter = GetData.MergeFilters(filteridfin, filter);

            //Aggiunge eventualmente il filtro sul disponibile
            if (chkFilterAvailable.Checked) {
                decimal currval = 0;
                if (Meta.IsEmpty || Meta.InsertMode) {
                    if (SubEntity_txtImportoMovimento.Text.Trim() != "") {
                        currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                            typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
                    }
                }
                else {
                    if (txtImportoCorrente.Text.Trim() != "") {
                        currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                            typeof(decimal), txtImportoCorrente.Text, "x.y.c"));
                    }
                }

                filter = GetData.MergeFilters(filter,
                    "(availableprevision>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
            }

            if (Meta.EditMode) {
                DataRow rEY = DS.expenseyear.Rows[0];
                if (rEY["idupb", DataRowVersion.Original].Equals(rEY["idupb", DataRowVersion.Current])) {

                    string query =
                        "SELECT idparent as idfin FROM finlink WHERE "
                        + QHS.CmpEq("idchild", rEY["idfin", DataRowVersion.Original]);
                    DataTable tApp = Meta.Conn.SQLRunner(query, true, 0);

                    if ((tApp != null) && (tApp.Rows.Count > 0)) {
                        filter = QHS.DoPar(QHS.AppOr(QHS.DoPar(filter),
                            QHS.DoPar(QHS.AppAnd(QHS.CmpEq("idupb", rEY["idupb"]),
                                QHS.FieldIn("idfin", tApp.Select())))
                        ));
                    }
                }
            }

            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                                     Meta.GetSys("esercizio").ToString() + "'))";

            // Viene aggiunto a filteroperativo, nel caso siamo in EditMode e non � cambiato l'U.P.B., la
            // vecchia voce di bilancio
            if (Meta.EditMode) {
                DataRow rEY = DS.expenseyear.Rows[0];
                if (rEY["idupb", DataRowVersion.Original].Equals(rEY["idupb"])) {
                    filteroperativo = QHS.DoPar(QHS.AppOr(QHS.DoPar(filteroperativo),
                        QHS.CmpEq("idfin", rEY["idfin"])
                    ));
                }
            }

            if (chkListManager.Checked) {

                if (GetResponsabile() != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idman", GetResponsabile()));
                }
                else {
                    filter = QHS.AppAnd(filter, QHS.IsNull("idman"));
                }

                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.manager." + filter);
                return;
            }

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                createForm(FR, this);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                             "(title like " + QueryCreator.quotedstrvalue(
                                 "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.finview.treesupb");
        }

        private void chkListManager_CheckedChanged(object sender, System.EventArgs e) {
            if (chkListManager.Checked) chkListTitle.Checked = false;
        }

        private void chkListTitle_CheckedChanged(object sender, System.EventArgs e) {
            if (chkListTitle.Checked) chkListManager.Checked = false;
        }



        void VerificaPrestazioneGenerica() {
            if ((SubEntity_cmbTipoprestazione.SelectedIndex <= 0) ||
                (SubEntity_cmbTipoprestazione.SelectedValue == null)) {
                labePrestGenerica.Visible = false;
                return;
            }

            string allowedit = "N";
            object codprestazione = SubEntity_cmbTipoprestazione.SelectedValue;
            string filter = "(idser=" + QueryCreator.quotedstrvalue(codprestazione, false) + ")";
            DataRow[] prestazioni = DS.service.Select(filter);
            if (prestazioni.Length != 0) {
                allowedit = prestazioni[0]["allowedit"].ToString().ToUpper();
            }

            //if (prestazione == "GENERICA") {
            if (allowedit == "S") {
                if ((!Meta.FirstFillForThisRow) && (Meta.EditMode || Meta.InsertMode)) {
                    show(
                        "Selezionando la prestazione GENERICA le ritenute inserite non saranno visualizzate nelle stampe:\r" +
                        "1) Modelli di certificazione fiscale\r" +
                        "2) Trasmissioni EMENS, Modello 770 ecc.\r" +
                        "Tale scelta � consentita solo se � necessario inserire manualmente le ritenute calcolate " +
                        "utilizzando un altro software.\r", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                labePrestGenerica.Visible = true;
            }
            else {
                labePrestGenerica.Visible = false;
            }

        }

        private void chbCoperturaIniziativa_CheckedChanged(object sender, System.EventArgs e) {
            if (SubEntity_chbCoperturaIniziativa.Checked) {
                gboxBolletta.Enabled = true;
                GestisciNumBolletta();
            }
            else {
                gboxBolletta.Enabled = false;
                GestisciNumBolletta();
            }
        }

        private void btnUPBCode_Click(object sender, EventArgs e) {
            object getresp = GetResponsabile();
            if (Meta.IsEmpty || (Meta.EditMode && getresp == DBNull.Value)) {
                Meta.DoMainCommand("manage.upb.tree");
                return;
            }

            string filterMan = "";
            if (getresp != DBNull.Value) {
                filterMan = QHS.CmpEq("idman", getresp);
            }

            string filter = QHS.AppAnd(filterMan, QHS.CmpEq("active", 'S'),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            decimal currval = 0;
            if (Meta.IsEmpty || Meta.InsertMode) {
                if (SubEntity_txtImportoMovimento.Text.Trim() != "") {
                    currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                        typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
                }
            }
            else {
                if (txtImportoCorrente.Text.Trim() != "") {
                    currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                        typeof(decimal), txtImportoCorrente.Text, "x.y.c"));
                }
            }

            if ((Meta.InsertMode) && (currval > 0) && !monofase) {
                filter = QHS.AppAnd(filter, QHS.CmpGe("expenseprevavailable", currval));
            }

            MetaData MetaUpb = MetaData.GetMetaData(this, "upbyearview");
            MetaUpb.DS = new DataSet();
            MetaUpb.linkedForm = this;
            MetaUpb.FilterLocked = true;
            DataRow Upb = MetaUpb.SelectOne("expense", filter, "upbyearview", null);
            if (Upb == null) return;
            object idupb = Upb["idupb"];
            SetUPB(idupb);
            if (monofase) AggiornaBilancioResponsabile(Upb);
        }

        private void btnSelModalita_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!faseMaxInclusa()) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.expense.Rows[0];
            DataRow CurrLast = DS.expenselast.Rows[0];
            if (Curr["idreg"] == DBNull.Value) {
                show(this, "Selezionare prima l'anagrafica", "Avviso");
                return;
            }

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", Curr["idreg"]), QHS.CmpEq("active", "S"));
            Meta.DoMainCommand("choose.registrypaymethod.default." + filter);
        }


        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
                QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }



        bool UsaCrediti() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagcredit"].ToString().ToUpper() == "S") return true;
            return false;
        }

        bool UsaCassa() {
            if (DS.config.Rows.Count == 0) return false;
            if (DS.config.Rows[0]["flagproceeds"].ToString().ToUpper() == "S") return true;
            return false;
        }

        bool UsaPrevCompetenza() {
            if (DS.config.Rows.Count == 0) return false;
            int finkind = CfgFn.GetNoNullInt32(DS.config.Rows[0]["fin_kind"]);
            if (finkind == 1 || finkind == 3) return true;
            return false;
        }

        bool UsaPrevCassa() {
            if (DS.config.Rows.Count == 0) return false;
            int finkind = CfgFn.GetNoNullInt32(DS.config.Rows[0]["fin_kind"]);
            if (finkind == 2 || finkind == 3) return true;
            return false;
        }

        void CercaFinanziamentoCrediti() {
            if (Meta.IsEmpty) return;
            if (!faseBilancioInclusa()) return;
            string fieldtouse = "expenseprevavailable"; // = disp. a impegnare
            if (UsaCrediti()) {
                fieldtouse = "creditavailable"; //crediti disponibili
            }

            Meta.GetFormData(true);
            DataRow CurrMov = DS.expense.Rows[0];
            int esercizio = MyConn.GetEsercizio();
            if (CfgFn.GetNoNullInt32(CurrMov["ymov"]) != esercizio) {
                show(this,
                    "E' possibile assegnare i finanziamenti solo nell'anno di creazione del movimento", "Avviso");
                return;
            }

            DataRow Curr = DS.expenseyear.Rows[0];
            object idfin = Curr["idfin"];
            object idupb = Curr["idupb"];
            if (idfin == DBNull.Value || idupb == DBNull.Value) {
                show(this, "E' necessario selezionare prima UPB e voce di bilancio", "Avviso");
                return;
            }

            DataTable F = MyConn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
                QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null,
                false);
            if (F == null || F.Rows.Count == 0) {
                show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
                    "Informazione");
                return;
            }

            if (DS.underwritingappropriation.Select().Length > 0) {
                if (show(this, "I finanziamenti precedentemente assegnati saranno cancellati.",
                        "Conferma",
                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    return;
                }

                foreach (DataRow todel in DS.underwritingappropriation.Select()) todel.Delete();
            }

            MetaData MetaUA = Meta.Dispatcher.Get("underwritingappropriation");

            decimal to_cover = GetImportoPerClassificazione(); //prende l'importo corrente


            foreach (DataRow Rf in F.Rows) {
                object idfin_found = Rf["idfin"];
                object idupb_found = Rf["idupb"];
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);
                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

                //vede se in memoria c'era gi� una riga con pari idfin e idupb
                if (DS.underwritingappropriation.Select(filterunderwriting, null, DataViewRowState.Deleted).Length >
                    0) {
                    DataRow torestore =
                        DS.underwritingappropriation.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.underwritingappropriation);
                    DataRow toadd = MetaUA.Get_New_Row(CurrMov, DS.underwritingappropriation);
                    toadd["idunderwriting"] = idunderwriting_found;
                    //DS.underwriting.Clear();
                    MyConn.RUN_SELECT_INTO_TABLE(DS.underwriting, null,
                        QHS.CmpEq("idunderwriting", idunderwriting_found),
                        null, false);
                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }

                if (to_cover == 0) break;
            }

            Meta.FreshForm(false);

        }

        private void btnCercaFinanziamentoCrediti_Click(object sender, EventArgs e) {
            CercaFinanziamentoCrediti();
        }

        void DetectFinanziamento(object idupb, object idfin) {
            if (Meta.EditMode) return;
            if (Meta.IsEmpty) return;
            if (faseBilancioInclusa()) {
                if (DS.underwritingappropriation.Select().Length == 0) {
                    CercaFinanziamentoCrediti();
                }
            }

            if (faseMaxInclusa()) {
                if (DS.underwritingpayment.Select().Length == 0) {
                    CercaFinanziamentoCassa();
                }
            }
        }



        //void FaiSingolaCorrezione(DataTable CreditiAssegnati, decimal importo, object idunderwriting) {
        //    DataRow[] found = CreditiAssegnati.Select(QHC.CmpEq("idunderwriting", idunderwriting));
        //    DataRow R;
        //    if (found.Length == 0) {
        //        //non dovrebbe accadere 
        //        R = CreditiAssegnati.NewRow();
        //        R["ayear"] = Meta.GetSys("esercizio");
        //        R["idunderwriting"] = idunderwriting;
        //        R["topay"] = importo;
        //        CreditiAssegnati.Rows.Add(R);

        //    }
        //    else {
        //        R = found[0];
        //        R["topay"] = CfgFn.GetNoNullDecimal(R["topay"]) + importo;
        //    }
        //    R.AcceptChanges();
        //    if (CfgFn.GetNoNullDecimal(R["topay"]) == 0) {
        //        R.Delete();
        //        R.AcceptChanges();
        //    }

        //}

        //void CorreggiImportiToPay(DataTable CreditiAssegnati) {
        //    foreach (DataRow R in DS.underwritingpayment.Rows) {
        //        if (R.RowState == DataRowState.Unchanged) continue;
        //        if (R.RowState == DataRowState.Added) {
        //            FaiSingolaCorrezione(CreditiAssegnati, -CfgFn.GetNoNullDecimal(R["amount"]), R["idunderwriting"]);
        //            continue;
        //        }
        //        if (R.RowState == DataRowState.Deleted) {
        //            FaiSingolaCorrezione(CreditiAssegnati, CfgFn.GetNoNullDecimal(R["amount",DataRowVersion.Original]),
        //                                                            R["idunderwriting", DataRowVersion.Original]);
        //            continue;
        //        }
        //        if (R.RowState == DataRowState.Modified) {
        //            FaiSingolaCorrezione(CreditiAssegnati, CfgFn.GetNoNullDecimal(R["amount"]), R["idunderwriting"]);
        //            FaiSingolaCorrezione(CreditiAssegnati, -CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Original]),
        //                                            R["idunderwriting"]);
        //            continue;
        //        }


        //    }
        //}
        object GetIDImpegno() {
            if (Meta.IsEmpty) return DBNull.Value;
            if (faseBilancioInclusa() && !monofase)
                throw new Exception("Non dovrebbe essere chiamata la funzione GetIDImpegno in questo caso");
            object parid = DS.Tables["expense"].Rows[0]["parentidexp"];
            object idlivbil = MyConn.DO_READ_VALUE("expenselink",
                QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("nlevel", ManageUPB.faseattivazione)),
                "idparent");
            return idlivbil;

        }


        void CercaFinanziamento_SolaCassa() {
            if (Meta.IsEmpty) return;
            string fieldtouse = "paymentprevavailable"; // = disp. a pagare

            Meta.GetFormData(true);
            DataRow CurrMov = DS.expense.Rows[0];
            int esercizio = MyConn.GetEsercizio();
            if (CfgFn.GetNoNullInt32(CurrMov["ymov"]) != esercizio) {
                show(this,
                    "E' possibile assegnare i finanziamenti solo nell'anno di creazione del movimento", "Avviso");
                return;
            }

            DataRow Curr = DS.expenseyear.Rows[0];
            object idfin = Curr["idfin"];
            object idupb = Curr["idupb"];
            if (idfin == DBNull.Value || idupb == DBNull.Value) {
                show(this, "E' necessario selezionare prima UPB e voce di bilancio", "Avviso");
                return;
            }

            DataTable F = MyConn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
                QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null,
                false);
            if (F == null || F.Rows.Count == 0) {
                show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
                    "Informazione");
                return;
            }

            if (DS.underwritingpayment.Select().Length > 0) {
                if (show(this, "I finanziamenti precedentemente assegnati saranno cancellati.",
                        "Conferma",
                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    return;
                }

                foreach (DataRow todel in DS.underwritingpayment.Select()) todel.Delete();
            }

            MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

            decimal to_cover = GetImportoPerClassificazione(); //prende l'importo corrente


            foreach (DataRow Rf in F.Rows) {
                object idfin_found = Rf["idfin"];
                object idupb_found = Rf["idupb"];
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);
                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

                //vede se in memoria c'era gi� una riga con pari idfin e idupb
                if (DS.underwritingpayment.Select(filterunderwriting, null, DataViewRowState.Deleted).Length > 0) {
                    DataRow torestore =
                        DS.underwritingpayment.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.underwritingpayment);
                    DataRow toadd = MetaUA.Get_New_Row(CurrMov, DS.underwritingpayment);
                    toadd["idunderwriting"] = idunderwriting_found;
                    //DS.underwriting.Clear();
                    MyConn.RUN_SELECT_INTO_TABLE(DS.underwriting, null,
                        QHS.CmpEq("idunderwriting", idunderwriting_found),
                        null, false);
                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }

                if (to_cover == 0) break;
            }

            Meta.FreshForm(false);

        }

        bool EsistonoFinanziamenti() {
            string filter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            ;
            if (!Meta.IsEmpty) {
                DataRow Curr = DS.expenseyear.Rows[0];
                object idupb = Curr["idupb"];
                if (idupb != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", idupb));
                }
            }

            int countUnderwriting = MyConn.RUN_SELECT_COUNT("upbunderwritingyearview", filter, false);
            return (countUnderwriting > 0);
        }

        void CercaFinanziamentoCassa() {
            if (Meta.IsEmpty) return;
            if (!faseMaxInclusa()) return;
            if (!(UsaCrediti() || UsaPrevCompetenza())) {
                CercaFinanziamento_SolaCassa();
                return;
            }

            string fieldtouse = "paymentsavailable"; // = disp. a pagare
            if (UsaCassa()) {
                fieldtouse = "proceedsavailable"; //incassi disponibili
            }


            Meta.GetFormData(true);
            DataRow CurrMov = DS.expense.Rows[0];
            int esercizio = MyConn.GetEsercizio();
            if (CfgFn.GetNoNullInt32(CurrMov["ymov"]) != esercizio) {
                show(this,
                    "E' possibile assegnare i finanziamenti solo nell'anno di creazione del movimento", "Avviso");
                return;
            }

            DataRow Curr = DS.expenseyear.Rows[0];
            //if (idfin == DBNull.Value || idupb == DBNull.Value) {
            //    show(this, "E' necessario selezionare prima UPB e voce di bilancio", "Avviso");
            //    return;
            //}
            DataTable F = MyConn.RUN_SELECT("expensecreditproceedsview", "*", fieldtouse + " asc",
                QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno()),
                    QHS.CmpGt(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);
            MyConn.RUN_SELECT_INTO_TABLE(F, fieldtouse + " desc",
                QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno()),
                    QHS.CmpLe(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);

            if (F == null || F.Rows.Count == 0) {
                show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
                    "Informazione");
                return;
            }

            if (DS.underwritingpayment.Select().Length > 0) {
                if (show(this, "I finanziamenti precedentemente assegnati saranno cancellati.",
                        "Conferma",
                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    return;
                }

                foreach (DataRow todel in DS.underwritingpayment.Select()) todel.Delete();
            }

            MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

            decimal to_cover = GetImportoPerClassificazione(); //prende l'importo corrente



            foreach (DataRow Rf in F.Rows) {
                object idunderwriting_found = Rf["idunderwriting"];
                string filterunderwriting = QHC.CmpEq("idunderwriting", idunderwriting_found);
                //DataRow RCreditiFound = null;

                DataRow newrow = null;

                decimal available = CfgFn.GetNoNullDecimal(Rf["topay"]);
                if (available == 0) continue;

                //vede se in memoria c'era gi� una riga con pari idfin e idupb
                if (DS.underwritingpayment.Select(filterunderwriting, null, DataViewRowState.Deleted).Length > 0) {
                    DataRow torestore =
                        DS.underwritingpayment.Select(filterunderwriting, null,
                            DataViewRowState.Deleted)[0];
                    torestore.RejectChanges();
                    decimal oldval = CfgFn.GetNoNullDecimal(torestore["amount"]);
                    available += oldval;
                    torestore["amount"] = 0;
                    newrow = torestore;
                }
                else {
                    MetaUA.SetDefaults(DS.underwritingpayment);
                    DataRow toadd = MetaUA.Get_New_Row(CurrMov, DS.underwritingpayment);
                    toadd["idunderwriting"] = idunderwriting_found;
                    //DS.underwriting.Clear();
                    MyConn.RUN_SELECT_INTO_TABLE(DS.underwriting, null,
                        QHS.CmpEq("idunderwriting", idunderwriting_found),
                        null, false);
                    DataRow Rfound = DS.underwriting.Select(QHC.CmpEq("idunderwriting", idunderwriting_found))[0];
                    toadd["!codeunderwriting"] = Rfound["codeunderwriting"];
                    toadd["!underwriting"] = Rfound["title"];
                    newrow = toadd;
                }

                if (to_cover <= available) {
                    newrow["amount"] = to_cover;
                    to_cover = 0;
                }
                else {
                    newrow["amount"] = available;
                    to_cover -= available;
                }

                if (to_cover == 0) break;
            }

            Meta.FreshForm(false);

        }

        private void btnCercaFinanziamentoCassa_Click(object sender, EventArgs e) {
            CercaFinanziamentoCassa();
        }

        private void btnAltreBollette_Click(object sender, EventArgs e) {
            if (!Meta.EditMode) return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show("Ci sono modifiche non salvate, salvare prima e poi riprovare.", "Avviso");
                return;
            }

            string filter =
                GetData.MergeFilters(
                    "((active='S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0) )",
                    DS.billview);
            DataTable T = Meta.Conn.RUN_SELECT("billview", "*", GetData.GetSorting(DS.billview, null), filter, null,
                false);
            DataSet D = new DataSet("a");
            MetaData Mbillview = Meta.Dispatcher.Get("billview");
            Mbillview.DescribeColumns(T, "spesa");
            string elaborate = "";
            D.Tables.Add(T);
            FrmAskNBill f = new FrmAskNBill(T);
            createForm(f, this);
            if (f.ShowDialog(this) != DialogResult.OK) return;
            string bills = f.txtBollette.Text.Trim();
            if (bills == "") return;
            string[] allbill = bills.Split(',');
            foreach (string s_nbill in allbill) {
                int nbill = CfgFn.GetNoNullInt32(s_nbill.Trim());
                if (nbill == 0) {
                    show(s_nbill + " non � un numero valido, bolletta saltata", "Errore");
                    continue;
                }

                int nexists =
                    Meta.Conn.RUN_SELECT_COUNT("billview", QHS.AppAnd(filter, QHS.CmpEq("nbill", nbill)), false);
                if (nexists == 0) {
                    show(
                        s_nbill + "La bolletta n. " + s_nbill + " non esiste o non ha disponibilit�, bolletta saltata",
                        "Errore");
                    continue;
                }

                decimal total = CfgFn.GetNoNullDecimal(T.Select(QHC.CmpEq("nbill", nbill))[0]["total"]);
                decimal covered = CfgFn.GetNoNullDecimal(T.Select(QHC.CmpEq("nbill", nbill))[0]["covered"]);
                decimal reduction = CfgFn.GetNoNullDecimal(T.Select(QHC.CmpEq("nbill", nbill))[0]["reduction"]);
                decimal amount = total - reduction - covered;

                Meta.EditNewCopy();
                SubEntity_txtImportoMovimento.Text = amount.ToString("c");
                SubEntity_txtImportoMovimento_Leave(null, null);
                SubEntity_txtBolletta.Text = nbill.ToString();
                DS.expenselast.Rows[0]["nbill"] = nbill;
                DS.expenseyear.Rows[0]["amount"] = amount;
                Meta.SaveFormData();
                if (DS.HasChanges()) {
                    if (elaborate == "") {
                        show("Operazione interrotta, non ho potuto associare alcuna bolletta.", "Avviso");
                    }
                    else {
                        show("Operazione interrotta, ho associato le bollette:" + elaborate, "Avviso");
                    }

                    return;
                }

                if (elaborate != "") elaborate += ", ";
                elaborate += nbill.ToString();
            }
        }

        private void btnMultipleBillSel_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            FrmChooseBill f = new FrmChooseBill(Meta, GetData.MergeFilters(null, DS.billview));
            createForm(f, this);
            if (f.ShowDialog(this) != DialogResult.OK) return;

            DataRow[] sel = f.GetGridSelectedRows();
            MetaData mexpbill = Meta.Dispatcher.Get("expensebill");
            mexpbill.SetDefaults(DS.expensebill);
            DataRow curr = DS.expense.Rows[0];

            foreach (DataRow r in sel) {
                decimal amount = CfgFn.GetNoNullDecimal(r["total"]) - CfgFn.GetNoNullDecimal(r["reduction"]) -
                                 CfgFn.GetNoNullDecimal(r["covered"]);
                string filter = QHC.CmpEq("nbill", r["nbill"]);
                if (DS.expensebill.Select(filter).Length > 0) {
                    DS.expensebill.Select(filter)[0]["amount"] = amount;
                }
                else {
                    DataRow rr = mexpbill.Get_New_Row(curr, DS.expensebill);
                    rr["nbill"] = r["nbill"];
                    rr["amount"] = amount;
                }
            }

            Meta.GetFormData(true);
            Meta.FreshForm();
        }

        private void btnAggiornaRecupero_Click(object sender, EventArgs e) {
            GeneraOAzzeraRecuperoSplitPayment();
            GeneraOAzzeraRecuperoIvaEstera();
        }

        private void groupBox20_Enter(object sender, EventArgs e) {

        }

        private void btnAggiornaCertificati_Click(object sender, EventArgs e) {
            //rDocumentocontabilizzato � stato valorizzato precedentemente
            ValorizzaFlagCertificati(rDocumentocontabilizzato, true);
        }

        private void CalcolaTotaleSospesi() {

            decimal totaleSospesi = 0;

            foreach (DataRow R in DS.expensebill.Select()) {

                totaleSospesi += CfgFn.GetNoNullDecimal(R["amount"]);
            }

            txtTotaleSospesi.Text = totaleSospesi.ToString("c");


        }
        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void btnScrittureCollegate_Click(object sender, EventArgs e) {
	        if (DS.expense.Rows.Count == 0) return;
	        var r = DS.expense.Rows[0];
	        string idexp = r["idexp"].ToString();
	        var mEntryDetail = Meta.Dispatcher.Get("entrydetail");
	        mEntryDetail.Edit(ParentForm, "default", false);
	        var listtype = "listaestesa";
	        //ToMeta.FilterLocked = true;
	        mEntryDetail.SelectOne(listtype, QHS.DoPar(QHS.AppOr(
											QHS.CmpEq("idrelateddetail","expense�"+idexp+"�debit"),
											QHS.CmpEq("idrelateddetail","expense�"+idexp)))
											, null, null);
        }

        private string defaultListType = "default";
        private void chkElenchiEp_CheckedChanged(object sender, EventArgs e) {
	        if (!Meta.DrawStateIsDone) return;
	        defaultListType = (chkElenchiEp.Checked ? "ep" : "default");
	        Meta.defaultListType = defaultListType;
        }

        private void btnEntrata_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			int esercizio = MyConn.GetEsercizio();
			DataRow Curr = DS.expense.Rows[0];

			decimal importo = GetImporto();
			string filter = QHS.CmpEq("nphase", 1);

			int ymov = CfgFn.GetNoNullInt32(txtEsercEntrata.Text.Trim());
			int nmov = CfgFn.GetNoNullInt32(txtNumEntrata.Text.Trim());
			if (importo > 0) filter = QHS.AppAnd(filter, QHS.CmpEq("curramount", importo));
			if (ymov != 0) {
				filter = QHS.AppAnd(filter, QHS.CmpEq("ymov", ymov));
			}

			if ((nmov != 0)) {
				filter = QHS.AppAnd(filter, QHS.CmpEq("nmov", nmov));
			}

			object idupb = GetUpb();
			if (idupb != DBNull.Value && idupb != null) {
				filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", idupb));
			}

			
			filter = QHS.AppAnd(filter, QHS.CmpMask("finflag", 2,2));
			filter = QHS.AppAnd(filter, " (idinc not in (select idinc_linked from expense where idinc_linked is not null))");



			MetaData E = Meta.Dispatcher.Get("income");
			E.FilterLocked = true;
			E.DS = new DataSet();
			E.DS.Tables.Add(MyConn.CreateTableByName("income", "*"));
			DataRow Choosen = E.SelectOne("default", filter, "income", null);
			if (Choosen == null) {
				if (sender!=btnEntrata) {
					((Control) sender).Focus();
				}
				return;
			}
			Curr["idinc_linked"] = Choosen["idinc"];
			Meta.Conn.RUN_SELECT_INTO_TABLE(DS.income_linked, null, QHS.AppAnd(QHS.CmpEq("idinc", Choosen["idinc"])),null, true);

			//DataRow Rexp = DS.expenseview.Rows[0];
			//Meta.SetAutoField(Rexp["idupb"], txtUPB);
			//if (Rexp["idman"] != DBNull.Value) Meta.SetAutoField(Rexp["idman"], txtResponsabile);
			//Meta.SetAutoField(Rexp["idfin"], txtCodiceBilancio);
			//Curr["idfin"] = Choosen["idfin"];
			//Curr["idupb"] = Choosen["idupb"];
			//Curr["idman"] = Choosen["idman"];
			txtEsercEntrata.Text = Choosen["ymov"].ToString();
			txtNumEntrata.Text = Choosen["nmov"].ToString();

		}

		private void txtNumEntrata_Leave(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.expense.Rows[0];
			if (txtNumEntrata.Text.Trim() == "") {
				DS.income_linked.Clear();
				Curr["idinc_linked"] = DBNull.Value;
				return;
			}

			btnEntrata_Click(sender, e);
		}

        void autodetectPagamenti() {
            var currRow = DS.expense.Rows[0];

            decimal currAmount = GetImportoPerClassificazione();

            object idexpToConsider = currRow["idexp"];
            if (currRow.RowState == DataRowState.Added) {
                idexpToConsider = currRow["parentidexp"];
                }

            //Calcola il residuo dei dettagli contabilizzati dall'impegno
            var residual = MyConn.DO_SYS_CMD($@"select sum(ed.residual) from mandatedetailtocashout ed 
											join expenselink il on ed.idexp_taxable=il.idparent
											where {(q.eq("il.idchild", idexpToConsider) & q.isNull("stop")).toSql(QHS, MyConn)} "); //mCmp non serve ma per sicurezza lo metto
            if (CfgFn.GetNoNullDecimal(residual) == currAmount) {
                doCollegamentoAutomatico();
                }
            }

        private void txtEsercEntrata_Leave(object sender, EventArgs e) {
			HelpForm.FormatLikeYear(txtEsercEntrata);
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.expense.Rows[0];
			if (Curr["idinc_linked"] != DBNull.Value) {
				if (txtEsercEntrata.Text.Trim() == "") {
					txtNumEntrata.Text = "";
					DS.income_linked.Clear();
					Curr["idinc_linked"] = DBNull.Value;
				}
				else {
					int oldYmov = CfgFn.GetNoNullInt32(DS.income_linked.Rows[0]["ymov"]);
					int newYmov = CfgFn.GetNoNullInt32(txtEsercEntrata.Text.Trim());
					if (oldYmov != newYmov) {
						txtNumEntrata.Text = "";
						DS.income_linked.Clear();
						Curr["idinc_linked"] = DBNull.Value;
					}
				}

			}
		}
        void doCollegamentoAutomatico() {
            var currRow = DS.expense.Rows[0];


            //Da attivarsi solo in fase incasso ove ci sia un contratto attivo contabilizzato in fase di accertamento, esclusi db monofase
            //Dei dettagli collegati in fase di accertamento deve collegare, a tappo, un insieme di dettagli per un importo pari all'incasso
            // a tal fine � necessario usare una vista apposita
            decimal totLinked =
                MetaData.SumColumn(DS.expenselastmandatedetail,
                    "amount"); //include valori non presenti nei residual delle righe della vista
            decimal currAmount = GetImportoPerClassificazione();
            decimal toAssign = currAmount - totLinked;
            if (toAssign <= 0) return;

            DataRow MiddleRow;
            var estim = GetDocRow("mandate", "expensemandate", faseordine, out MiddleRow); // DA VERIFICARE faseiva
            if (estim == null) {
                MetaFactory.factory.getSingleton<IMessageShower>()
                    .Show("Il movimento non contabilizza un contratto passivo", "Avviso");
                return;
                }

            object idexpToConsider = currRow["idexp"];
            if (currRow.RowState == DataRowState.Added) {
                idexpToConsider = currRow["parentidexp"];
                }


            //deve filtrare i dettagli appartenenti all'accertamento parent di questo incasso
            q impegnate = q.constant(true);
            if (DS.mandatedetail_taxable.Select().Length == 0) {
                //deve prendere in base a incomelink
                var righe = MyConn.SQLRunner($@"select ed.rownum from mandatedetail ed 
											join expenselink il on ed.idexp_taxable=il.idparent
											where {(q.eq("il.idchild", idexpToConsider) & q.isNull("stop")).toSql(QHS, MyConn)} "); //mCmp non serve ma per sicurezza lo metto


                //var righe = MyConn.SQLRunner($@"select rownum from estimatedetail  
                //							where {(q.eq("idinc_taxable",idincToConsider) & q.isNull("stop")).toSql(QHS,MyConn)} "); //mCmp non serve ma per sicurezza lo metto
                if (righe != null && righe.Rows.Count > 0) {
                    impegnate = q.fieldIn("rownum", righe.Select()._Pick("rownum").ToArray());
                    }
                else {
                    MetaFactory.factory.getSingleton<IMessageShower>()
                        .Show("Il movimento non contabilizza dettagli di contratto passivo", "Avviso");
                    return;
                    }
                }
            else {
                var dettagli = DS.mandatedetail_taxable.Select();
                if (dettagli.Length == 0) {
                    MetaFactory.factory.getSingleton<IMessageShower>()
                        .Show("Il movimento non contabilizza dettagli di contratto pssivo", "Avviso");
                    }

                //deve prendere le righe di mandatedetails
                impegnate = q.fieldIn("rownum", dettagli._Pick("rownum").ToArray());
                }


            q filterDetails = q.keyCmp(estim) & q.isNull("stop") & q.gt("residual", 0) & impegnate;
            var detailsToLink =
                MyConn.RUN_SELECT("mandatedetailtocashout", "*", null, filterDetails.toSql(QHS), null, false);
            if (detailsToLink == null || detailsToLink.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>()
                    .Show("I dettagli del contratto passivo sono tutti pagati.", "Avviso");
                return;
                }

            //Per ogni riga con del residuo, vede se c'� gi�
            // se c'� ne aumenta l'importo per un valore pari al residuo
            // se non c'� la crea con importo pari al residuo
            var metaDetail = Meta.Dispatcher.Get("expenselastmandatedetail");
            metaDetail.SetDefaults(DS.expenselastmandatedetail);

            foreach (DataRow r in detailsToLink.Rows) {
                if (toAssign == 0) break;
                decimal residual = CfgFn.GetNoNullDecimal(r["residual"]);

                var found = DS.expenselastmandatedetail
                    ._Filter(q.mCmp(r, DS.mandatedetail_taxable.PrimaryKey), null, null, true).FirstOrDefault();
                decimal delta = 0;
                if (found != null) {
                    if (found.RowState == DataRowState.Added) {
                        decimal oldamount = CfgFn.GetNoNullDecimal(found["amount"]);
                        residual -= oldamount;
                        if (residual > toAssign) residual = toAssign;
                        found["amount"] = residual + oldamount;
                        delta = residual;
                        }

                    if (found.RowState == DataRowState.Modified) {
                        decimal oldamount = CfgFn.GetNoNullDecimal(found["amount", DataRowVersion.Original]);
                        decimal newamount = CfgFn.GetNoNullDecimal(found["amount", DataRowVersion.Current]);
                        residual = residual + oldamount - newamount;
                        if (residual > toAssign) residual = toAssign;
                        found["amount"] = residual + newamount;
                        delta = residual;
                        }

                    if (found.RowState == DataRowState.Unchanged) {
                        decimal amount = CfgFn.GetNoNullDecimal(found["amount"]);
                        if (residual > toAssign) residual = toAssign;
                        found["amount"] = residual + amount;
                        delta = residual;
                        }

                    if (found.RowState == DataRowState.Deleted) {
                        found.RejectChanges();
                        decimal oldamount = CfgFn.GetNoNullDecimal(found["amount"]);
                        residual = residual + oldamount;
                        if (residual > toAssign) residual = toAssign;
                        found["amount"] = residual;
                        delta = residual;
                        }

                    if (CfgFn.GetNoNullDecimal(found["amount"]) == 0) found.Delete();
                    toAssign -= delta;
                    continue;
                    }

                var rNew = metaDetail.Get_New_Row(DS.expense.Rows[0], DS.expenselastmandatedetail);
                foreach (var c in DS.mandatedetail_taxable.PrimaryKey) rNew[c.ColumnName] = r[c.ColumnName];
                rNew["amount"] = residual;
                toAssign -= residual;
                }

            foreach (DataRow r in DS.expenselastmandatedetail.Select()) {
                DS.mandatedetail_taxable.safeMergeFromDb(MyConn,
                    q.mCmp(r, "idmankind", "yman", "nman", "rownum"));
                Meta.getData.CalcTemporaryValues(r);
                }
            }
        private void btnCollegaDettagliContratto_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.expenselast.Rows.Count == 0) return;
            Meta.GetFormData(true);
            doCollegamentoAutomatico();
            Meta.FreshForm();
            }

	}
}
