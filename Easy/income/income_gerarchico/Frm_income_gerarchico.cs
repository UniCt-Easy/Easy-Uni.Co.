
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione
using SituazioneViewer;//SituazioneViewer
using movimentofunctions;//movimentofunctions
using gestioneclassificazioni;
using ep_functions;
using chooseBill;
using q= metadatalibrary.MetaExpression;
using System.Linq;

namespace income_gerarchico //EntrataGerarchico//
{
	/// <summary>
	/// Summary description for FrmEntrataGerarchico.
	/// </summary>
	public class Frm_income_gerarchico : MetaDataForm {

		#region Dichiarazione variabili e controlli

		private bool dettaglioContrattiIncassati = false;
		GestioneClassificazioni ManageClassificazioni;

		GBoxManage ManageBilAnnuale;
		GBoxManage ManageUPB;
		GBoxManage ManageCreditore;
		int fasespesamax;
		string flagcreddeb;
		string flagbilancio;
		string flagrespons;
		string flagresidui;
		bool MustClose = false;


		DataRow IvaLinked;
		DataRow IvaMovEntrataLinked;

		int CurrCausaleIva;

		//DataTable IvaMovEntrataViewLinked;
		bool IvaLinkedMustBeEvalued;

		DataRow EstimateLinked;
		DataRow EstimateMovEntrataLinked;

		int CurrCausaleEstimate;

		//DataTable EstimateMovEntrataViewLinked;
		bool EstimateLinkedMustBeEvalued;

		int faseiva;
		int faseentrata;
		int fasecontratto;

		private MetaData Meta;
		private DataAccess MyConn;
		private int faseentratamax;
		private byte currphase;
		bool ControlloSuFasiPrecEffettuato;
		bool to_mainrefresh; //true se deve essere effettuato un main refresh (dopo i post)
		decimal lastimportofreshed;

		bool isNumEserEdit = false;

		/// <summary>
		/// True durante il post degli automatismi, usato per non innescare un loop
		/// </summary>
		bool SecondoPostAttivo;
		bool monofase = false;
		bool InChiusura;
		Hashtable FasePrecValues; //default per inserimenti

		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TreeView MovTree;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.GroupBox gboxMovimento;
		private System.Windows.Forms.TextBox txtNumeroMovimento;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtEsercizioMovimento;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblFaseMovimento;
		private System.Windows.Forms.ComboBox cmbFaseEntrata;
		private System.Windows.Forms.GroupBox gboxFasePrecedente;
		private System.Windows.Forms.Button btnFasePrecedente;
		private System.Windows.Forms.TextBox txtNumeroFasePrecedente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEsercizioFasePrecedente;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox SubEntity_chbCoperturaIniziativa;
		private System.Windows.Forms.Button btnSituazioneMovimentoEntrata;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblImportoDisponibile;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtImportoDisponibile;
		private System.Windows.Forms.TextBox txtImportoCorrente;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox gboxResponsabile;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox gboxImporto;
		private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
		private System.Windows.Forms.Label labelImporto;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtDataCont;
		private System.Windows.Forms.TextBox txtScadenza;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chbAzzeramento;
		public dsmeta DS;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txtNumMandato;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.GroupBox GBoxVariazioni;
		private System.Windows.Forms.DataGrid gridVariazioni;
		private System.Windows.Forms.ToolTip Tip;
		private System.ComponentModel.IContainer components;

		#endregion

		bool classEnabled = true;
		private System.Windows.Forms.Button btnDeleteVar;
		private System.Windows.Forms.Button btnEditVar;
		private System.Windows.Forms.Button btnInsertVar;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.TextBox txtImportoAssegnareIncassi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtImportoAssegnareCrediti;
		private System.Windows.Forms.TabPage tabMovFin1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label labelCausale;
		private System.Windows.Forms.ComboBox cmbCausale;
		private System.Windows.Forms.ComboBox cmbTipoContabilizzazione;
		private System.Windows.Forms.GroupBox gboxDocumento;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmbTipoDocumento;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.Label labelTipoDocumento;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabClassSup;
		private System.Windows.Forms.TabPage tabIncasso;
		private System.Windows.Forms.TabPage tabVariazioni;
		private System.Windows.Forms.TabPage tabAssCrediti;
		private System.Windows.Forms.TabPage tabAssIncassi;
		bool ComingFromDelete = false;
		bool MustRefreshImportoEntrata = false;
		decimal DisponibileDaFasePrecedente;
		private System.Windows.Forms.GroupBox gboxCrediti;
		private System.Windows.Forms.GroupBox gboxIncassi;
		private System.Windows.Forms.Button btnGeneraClassAutomatiche;
		private System.Windows.Forms.Label labImportoDaAssegnare;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkListManager;
		private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.GroupBox gboxBolletta;
		private System.Windows.Forms.TextBox SubEntity_txtBolletta;
		private System.Windows.Forms.Button btnBolletta;
		private System.Windows.Forms.TabPage tabDetails;
		private System.Windows.Forms.GroupBox gboxDettEstimate;
		private System.Windows.Forms.Button btnEditEstimDet;
		private System.Windows.Forms.TextBox txtTotEstimateDetail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnRemoveDetEstimate;
		private System.Windows.Forms.DataGrid dgrDettagliContratto;
		private System.Windows.Forms.Button btnAddDetEstimate;
		private System.Windows.Forms.GroupBox gboxDettInvoice;
		private System.Windows.Forms.Button btnEditInvDet;
		private System.Windows.Forms.TextBox txtTotInvoiceDetail;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button btnRemoveDettInvoice;
		private System.Windows.Forms.Button btnAddDettInvoice;
		private System.Windows.Forms.DataGrid dgrDettagliFattura;
		private TabPage tabAltro;
		private GroupBox grpContocredito;
		private TextBox txtDescrContoCustomer;
		private TextBox txtCodiceContoCustomer;
		private Button btnContoCredito;
		private Label lblcup;
		private TextBox txtcup;
		private TextBox txtFinanziamento;
		private Button btnFinanziamento;
		private GroupBox gboxfinanziamento;
		private GroupBox groupBox17;
		private TextBox txtDescrizione;
		private CheckBox SubEntity_chbDestinazioneVincolata;
		private GroupBox grpModRiscossione;
		private CheckBox SubEntity_chkAccreditoTPS;
		private CheckBox SubEntity_chkPrelievodaCCP;
		private CheckBox SubEntity_chkCassa;
		public TextBox txtUPB;
		public TextBox txtResponsabile;
		private GroupBox groupBox2;
		private Label labBollette2;
		private Label labBollette1;
		private Button btnAddBolletta;
		private Button btnDelBolletta;
		private Button btnEditBolletta;
		private DataGrid dgridBollette;
		private Button btnMultipleBillSel;
		private Label label27;
		private TextBox textBox7;
		private CheckBox SubEntity_chkIncassoNetto;
		private Label lbTotale;
		private TextBox txtTotaleSospesi;
		private Button btnScrittureCollegate;
		private GroupBox gboxIncassoDettContratti;
		private Button btnCollegaDettagliContratto;
		private Button button1;
		private TextBox txtTotDettIncassi;
		private Label label11;
		private Button button2;
		private DataGrid gridDettIncassi;
		private Button btnAdd;
		private TabPage tabFatture;
		decimal DisponibilePerProssimafase;

		bool faseIvaInclusa() {
			return (faseiva == currphase);
		}

		bool faseEntrataInclusa() {
			return (faseentrata == currphase);
		}

		bool faseContrattoInclusa() {
			return (fasecontratto == currphase);
		}

		public Frm_income_gerarchico() {
			InitializeComponent();
			ControlloSuFasiPrecEffettuato = false;
			InChiusura = false;

			DS.incomephase.ExtendedProperties["sort_by"] = "nphase";
			//DS.sortingkind.ExtendedProperties["sort_by"]="sortinglevel, description";
			DS.incomesorted.ExtendedProperties["gridmaster"] = "sortingkind";
			DataAccess.SetTableForReading(DS.bilanciocrediti, "fin");
			DataAccess.SetTableForReading(DS.bilancioincassi, "fin");
			DataAccess.SetTableForReading(DS.upbcrediti, "upb");
			DataAccess.SetTableForReading(DS.upbincassi, "upb");
			GetData.SetSorting(DS.upb, "codeupb asc");
			GetData.SetSorting(DS.bill, "nbill desc");
			GetData.SetSorting(DS.billview, "nbill desc");

			//			currphase = 1;
			//			fasespesamax = 2;			
			SecondoPostAttivo = false;
			to_mainrefresh = false;
			ResetTipoClassAvailableEvalued();

			FasePrecValues = new Hashtable();

			tabControl1.SelectedIndex = 0;
			DataAccess.SetTableForReading(DS.estimatedetail_iva, "estimatedetailview");
			DataAccess.SetTableForReading(DS.estimatedetail_taxable, "estimatedetailview");
			DataAccess.SetTableForReading(DS.bill1, "bill");
			QueryCreator.SetTableForPosting(DS.estimatedetail_iva, "estimatedetail");
			QueryCreator.SetTableForPosting(DS.estimatedetail_taxable, "estimatedetail");
			DataAccess.SetTableForReading(DS.invoicedetail_iva, "invoicedetailview");
			DataAccess.SetTableForReading(DS.invoicedetail_taxable, "invoicedetailview");
			QueryCreator.SetTableForPosting(DS.invoicedetail_iva, "invoicedetail");
			QueryCreator.SetTableForPosting(DS.invoicedetail_taxable, "invoicedetail");
			GetData.SetSorting(DS.estimatedetail_iva, "idgroup");
			GetData.SetSorting(DS.estimatedetail_taxable, "idgroup");

			DataAccess.SetTableForReading(DS.estimatedetail_incassi, "estimatedetail");
			

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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_income_gerarchico));
			this.DS = new income_gerarchico.dsmeta();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.MovTree = new System.Windows.Forms.TreeView();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.btnDelClass = new System.Windows.Forms.Button();
			this.btnEditClass = new System.Windows.Forms.Button();
			this.btnInsertClass = new System.Windows.Forms.Button();
			this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
			this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.gboxMovimento = new System.Windows.Forms.GroupBox();
			this.txtNumeroMovimento = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtEsercizioMovimento = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblFaseMovimento = new System.Windows.Forms.Label();
			this.cmbFaseEntrata = new System.Windows.Forms.ComboBox();
			this.gboxFasePrecedente = new System.Windows.Forms.GroupBox();
			this.btnFasePrecedente = new System.Windows.Forms.Button();
			this.txtNumeroFasePrecedente = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEsercizioFasePrecedente = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SubEntity_chbCoperturaIniziativa = new System.Windows.Forms.CheckBox();
			this.btnSituazioneMovimentoEntrata = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblImportoDisponibile = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImportoDisponibile = new System.Windows.Forms.TextBox();
			this.txtImportoCorrente = new System.Windows.Forms.TextBox();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.groupBox19 = new System.Windows.Forms.GroupBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtDataDocumento = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.gboxImporto = new System.Windows.Forms.GroupBox();
			this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
			this.labelImporto = new System.Windows.Forms.Label();
			this.groupBox20 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataCont = new System.Windows.Forms.TextBox();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.chbAzzeramento = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.txtNumMandato = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.GBoxVariazioni = new System.Windows.Forms.GroupBox();
			this.btnDeleteVar = new System.Windows.Forms.Button();
			this.btnEditVar = new System.Windows.Forms.Button();
			this.btnInsertVar = new System.Windows.Forms.Button();
			this.gridVariazioni = new System.Windows.Forms.DataGrid();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.txtImportoAssegnareCrediti = new System.Windows.Forms.TextBox();
			this.labImportoDaAssegnare = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtImportoAssegnareIncassi = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.Tip = new System.Windows.Forms.ToolTip(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabMovFin1 = new System.Windows.Forms.TabPage();
			this.btnScrittureCollegate = new System.Windows.Forms.Button();
			this.gboxfinanziamento = new System.Windows.Forms.GroupBox();
			this.txtFinanziamento = new System.Windows.Forms.TextBox();
			this.btnFinanziamento = new System.Windows.Forms.Button();
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
			this.label8 = new System.Windows.Forms.Label();
			this.labelCausale = new System.Windows.Forms.Label();
			this.cmbCausale = new System.Windows.Forms.ComboBox();
			this.cmbTipoContabilizzazione = new System.Windows.Forms.ComboBox();
			this.gboxDocumento = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
			this.txtNumDoc = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.btnDocumento = new System.Windows.Forms.Button();
			this.labelTipoDocumento = new System.Windows.Forms.Label();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.tabClassSup = new System.Windows.Forms.TabPage();
			this.btnGeneraClassAutomatiche = new System.Windows.Forms.Button();
			this.tabDetails = new System.Windows.Forms.TabPage();
			this.gboxIncassoDettContratti = new System.Windows.Forms.GroupBox();
			this.btnCollegaDettagliContratto = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtTotDettIncassi = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.gridDettIncassi = new System.Windows.Forms.DataGrid();
			this.btnAdd = new System.Windows.Forms.Button();
			this.gboxDettEstimate = new System.Windows.Forms.GroupBox();
			this.btnEditEstimDet = new System.Windows.Forms.Button();
			this.txtTotEstimateDetail = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnRemoveDetEstimate = new System.Windows.Forms.Button();
			this.dgrDettagliContratto = new System.Windows.Forms.DataGrid();
			this.btnAddDetEstimate = new System.Windows.Forms.Button();
			this.tabFatture = new System.Windows.Forms.TabPage();
			this.gboxDettInvoice = new System.Windows.Forms.GroupBox();
			this.btnEditInvDet = new System.Windows.Forms.Button();
			this.txtTotInvoiceDetail = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.btnRemoveDettInvoice = new System.Windows.Forms.Button();
			this.btnAddDettInvoice = new System.Windows.Forms.Button();
			this.dgrDettagliFattura = new System.Windows.Forms.DataGrid();
			this.tabIncasso = new System.Windows.Forms.TabPage();
			this.SubEntity_chkIncassoNetto = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtTotaleSospesi = new System.Windows.Forms.TextBox();
			this.lbTotale = new System.Windows.Forms.Label();
			this.btnMultipleBillSel = new System.Windows.Forms.Button();
			this.labBollette2 = new System.Windows.Forms.Label();
			this.labBollette1 = new System.Windows.Forms.Label();
			this.btnAddBolletta = new System.Windows.Forms.Button();
			this.btnDelBolletta = new System.Windows.Forms.Button();
			this.btnEditBolletta = new System.Windows.Forms.Button();
			this.dgridBollette = new System.Windows.Forms.DataGrid();
			this.SubEntity_chbDestinazioneVincolata = new System.Windows.Forms.CheckBox();
			this.grpModRiscossione = new System.Windows.Forms.GroupBox();
			this.SubEntity_chkAccreditoTPS = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkPrelievodaCCP = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkCassa = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabVariazioni = new System.Windows.Forms.TabPage();
			this.tabAssIncassi = new System.Windows.Forms.TabPage();
			this.gboxIncassi = new System.Windows.Forms.GroupBox();
			this.tabAssCrediti = new System.Windows.Forms.TabPage();
			this.gboxCrediti = new System.Windows.Forms.GroupBox();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.label27 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.lblcup = new System.Windows.Forms.Label();
			this.txtcup = new System.Windows.Forms.TextBox();
			this.grpContocredito = new System.Windows.Forms.GroupBox();
			this.txtDescrContoCustomer = new System.Windows.Forms.TextBox();
			this.txtCodiceContoCustomer = new System.Windows.Forms.TextBox();
			this.btnContoCredito = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox15.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
			this.gboxMovimento.SuspendLayout();
			this.gboxFasePrecedente.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.gboxImporto.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.GBoxVariazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridVariazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabMovFin1.SuspendLayout();
			this.gboxfinanziamento.SuspendLayout();
			this.gboxBolletta.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.gboxBilAnnuale.SuspendLayout();
			this.gboxDocumento.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.tabClassSup.SuspendLayout();
			this.tabDetails.SuspendLayout();
			this.gboxIncassoDettContratti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettIncassi)).BeginInit();
			this.gboxDettEstimate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliContratto)).BeginInit();
			this.tabFatture.SuspendLayout();
			this.gboxDettInvoice.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
			this.tabIncasso.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).BeginInit();
			this.grpModRiscossione.SuspendLayout();
			this.tabVariazioni.SuspendLayout();
			this.tabAssIncassi.SuspendLayout();
			this.gboxIncassi.SuspendLayout();
			this.tabAssCrediti.SuspendLayout();
			this.gboxCrediti.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.grpContocredito.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// icons
			// 
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// MovTree
			// 
			this.MovTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.MovTree.HideSelection = false;
			this.MovTree.ImageIndex = 1;
			this.MovTree.ImageList = this.icons;
			this.MovTree.Location = new System.Drawing.Point(0, 0);
			this.MovTree.Name = "MovTree";
			this.MovTree.SelectedImageIndex = 0;
			this.MovTree.ShowPlusMinus = false;
			this.MovTree.ShowRootLines = false;
			this.MovTree.Size = new System.Drawing.Size(184, 529);
			this.MovTree.TabIndex = 1;
			this.MovTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.MovTree_BeforeSelect);
			this.MovTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MovTree_AfterSelect);
			this.MovTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovTree_MouseMove);
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
			this.groupBox15.Location = new System.Drawing.Point(8, 200);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(790, 285);
			this.groupBox15.TabIndex = 33;
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
			this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(766, 216);
			this.DGridDettagliClassificazioni.TabIndex = 7;
			this.DGridDettagliClassificazioni.Tag = "incomesorted.default";
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
			this.DGridClassificazioni.Size = new System.Drawing.Size(790, 160);
			this.DGridClassificazioni.TabIndex = 31;
			this.DGridClassificazioni.Tag = "sortingkind.default";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(248, 12);
			this.label1.TabIndex = 32;
			this.label1.Text = "Classificazioni";
			// 
			// gboxMovimento
			// 
			this.gboxMovimento.Controls.Add(this.txtNumeroMovimento);
			this.gboxMovimento.Controls.Add(this.label3);
			this.gboxMovimento.Controls.Add(this.txtEsercizioMovimento);
			this.gboxMovimento.Controls.Add(this.label2);
			this.gboxMovimento.Controls.Add(this.lblFaseMovimento);
			this.gboxMovimento.Controls.Add(this.cmbFaseEntrata);
			this.gboxMovimento.Location = new System.Drawing.Point(8, 0);
			this.gboxMovimento.Name = "gboxMovimento";
			this.gboxMovimento.Size = new System.Drawing.Size(381, 40);
			this.gboxMovimento.TabIndex = 1;
			this.gboxMovimento.TabStop = false;
			this.gboxMovimento.Text = "Movimento";
			// 
			// txtNumeroMovimento
			// 
			this.txtNumeroMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumeroMovimento.Location = new System.Drawing.Point(315, 15);
			this.txtNumeroMovimento.Name = "txtNumeroMovimento";
			this.txtNumeroMovimento.Size = new System.Drawing.Size(60, 20);
			this.txtNumeroMovimento.TabIndex = 3;
			this.txtNumeroMovimento.Tag = "income.nmov";
			this.txtNumeroMovimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(278, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "Num.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioMovimento
			// 
			this.txtEsercizioMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercizioMovimento.Location = new System.Drawing.Point(243, 15);
			this.txtEsercizioMovimento.Name = "txtEsercizioMovimento";
			this.txtEsercizioMovimento.Size = new System.Drawing.Size(32, 20);
			this.txtEsercizioMovimento.TabIndex = 2;
			this.txtEsercizioMovimento.Tag = "income.ymov.year";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(207, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Es.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblFaseMovimento
			// 
			this.lblFaseMovimento.Location = new System.Drawing.Point(8, 16);
			this.lblFaseMovimento.Name = "lblFaseMovimento";
			this.lblFaseMovimento.Size = new System.Drawing.Size(32, 20);
			this.lblFaseMovimento.TabIndex = 0;
			this.lblFaseMovimento.Text = "Fase:";
			this.lblFaseMovimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbFaseEntrata
			// 
			this.cmbFaseEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbFaseEntrata.DataSource = this.DS.incomephase;
			this.cmbFaseEntrata.DisplayMember = "description";
			this.cmbFaseEntrata.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFaseEntrata.Location = new System.Drawing.Point(40, 16);
			this.cmbFaseEntrata.Name = "cmbFaseEntrata";
			this.cmbFaseEntrata.Size = new System.Drawing.Size(161, 21);
			this.cmbFaseEntrata.TabIndex = 1;
			this.cmbFaseEntrata.Tag = "income.nphase";
			this.cmbFaseEntrata.ValueMember = "nphase";
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
			this.gboxFasePrecedente.Size = new System.Drawing.Size(381, 40);
			this.gboxFasePrecedente.TabIndex = 2;
			this.gboxFasePrecedente.TabStop = false;
			this.gboxFasePrecedente.Text = "Fase precedente";
			this.gboxFasePrecedente.Visible = false;
			// 
			// btnFasePrecedente
			// 
			this.btnFasePrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFasePrecedente.Location = new System.Drawing.Point(8, 16);
			this.btnFasePrecedente.Name = "btnFasePrecedente";
			this.btnFasePrecedente.Size = new System.Drawing.Size(190, 20);
			this.btnFasePrecedente.TabIndex = 0;
			this.btnFasePrecedente.TabStop = false;
			this.btnFasePrecedente.Text = "Accertamento:";
			this.btnFasePrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnFasePrecedente.Click += new System.EventHandler(this.btnFasePrecedente_Click);
			// 
			// txtNumeroFasePrecedente
			// 
			this.txtNumeroFasePrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumeroFasePrecedente.Location = new System.Drawing.Point(317, 16);
			this.txtNumeroFasePrecedente.Name = "txtNumeroFasePrecedente";
			this.txtNumeroFasePrecedente.Size = new System.Drawing.Size(60, 20);
			this.txtNumeroFasePrecedente.TabIndex = 2;
			this.txtNumeroFasePrecedente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumeroFasePrecedente.Leave += new System.EventHandler(this.txtNumeroFasePrecedente_Leave);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(279, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Num.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizioFasePrecedente
			// 
			this.txtEsercizioFasePrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercizioFasePrecedente.Location = new System.Drawing.Point(245, 16);
			this.txtEsercizioFasePrecedente.Name = "txtEsercizioFasePrecedente";
			this.txtEsercizioFasePrecedente.Size = new System.Drawing.Size(32, 20);
			this.txtEsercizioFasePrecedente.TabIndex = 1;
			this.txtEsercizioFasePrecedente.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.Location = new System.Drawing.Point(204, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Es.";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_chbCoperturaIniziativa
			// 
			this.SubEntity_chbCoperturaIniziativa.Enabled = false;
			this.SubEntity_chbCoperturaIniziativa.Location = new System.Drawing.Point(395, 443);
			this.SubEntity_chbCoperturaIniziativa.Name = "SubEntity_chbCoperturaIniziativa";
			this.SubEntity_chbCoperturaIniziativa.Size = new System.Drawing.Size(288, 18);
			this.SubEntity_chbCoperturaIniziativa.TabIndex = 17;
			this.SubEntity_chbCoperturaIniziativa.Tag = "incomelast.flag:0?incomeview.flag:0";
			this.SubEntity_chbCoperturaIniziativa.Text = "Regolarizza disposizione di incasso già effettuata";
			this.SubEntity_chbCoperturaIniziativa.CheckedChanged += new System.EventHandler(this.chbCoperturaIniziativa_CheckedChanged);
			// 
			// btnSituazioneMovimentoEntrata
			// 
			this.btnSituazioneMovimentoEntrata.Location = new System.Drawing.Point(534, 467);
			this.btnSituazioneMovimentoEntrata.Name = "btnSituazioneMovimentoEntrata";
			this.btnSituazioneMovimentoEntrata.Size = new System.Drawing.Size(91, 23);
			this.btnSituazioneMovimentoEntrata.TabIndex = 14;
			this.btnSituazioneMovimentoEntrata.TabStop = false;
			this.btnSituazioneMovimentoEntrata.Text = "Situazione";
			this.btnSituazioneMovimentoEntrata.Click += new System.EventHandler(this.btnSituazioneMovimentoSpesa_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblImportoDisponibile);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.txtImportoDisponibile);
			this.groupBox1.Controls.Add(this.txtImportoCorrente);
			this.groupBox1.Location = new System.Drawing.Point(392, 332);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(365, 64);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Situazione riassuntiva importo del movimento";
			// 
			// lblImportoDisponibile
			// 
			this.lblImportoDisponibile.Location = new System.Drawing.Point(19, 40);
			this.lblImportoDisponibile.Name = "lblImportoDisponibile";
			this.lblImportoDisponibile.Size = new System.Drawing.Size(181, 20);
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
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtImportoDisponibile
			// 
			this.txtImportoDisponibile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoDisponibile.Location = new System.Drawing.Point(208, 40);
			this.txtImportoDisponibile.Name = "txtImportoDisponibile";
			this.txtImportoDisponibile.Size = new System.Drawing.Size(150, 20);
			this.txtImportoDisponibile.TabIndex = 0;
			this.txtImportoDisponibile.TabStop = false;
			this.txtImportoDisponibile.Tag = "incometotal.available?incomeview.available";
			// 
			// txtImportoCorrente
			// 
			this.txtImportoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoCorrente.Location = new System.Drawing.Point(208, 16);
			this.txtImportoCorrente.Name = "txtImportoCorrente";
			this.txtImportoCorrente.Size = new System.Drawing.Size(150, 20);
			this.txtImportoCorrente.TabIndex = 0;
			this.txtImportoCorrente.TabStop = false;
			this.txtImportoCorrente.Tag = "incometotal.curramount?incomeview.curramount";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			this.imageList1.Images.SetKeyName(1, "");
			// 
			// groupBox19
			// 
			this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox19.Controls.Add(this.txtDocumento);
			this.groupBox19.Controls.Add(this.label10);
			this.groupBox19.Controls.Add(this.txtDataDocumento);
			this.groupBox19.Controls.Add(this.label14);
			this.groupBox19.Location = new System.Drawing.Point(392, 274);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new System.Drawing.Size(406, 56);
			this.groupBox19.TabIndex = 14;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Documento collegato";
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(8, 32);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(225, 20);
			this.txtDocumento.TabIndex = 1;
			this.txtDocumento.Tag = "income.doc";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 14);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(72, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "Descrizione:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumento
			// 
			this.txtDataDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDocumento.Location = new System.Drawing.Point(242, 32);
			this.txtDataDocumento.Name = "txtDataDocumento";
			this.txtDataDocumento.Size = new System.Drawing.Size(157, 20);
			this.txtDataDocumento.TabIndex = 2;
			this.txtDataDocumento.Tag = "income.docdate";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(239, 14);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(64, 18);
			this.label14.TabIndex = 0;
			this.label14.Text = "Data:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(8, 122);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(381, 40);
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
			this.txtResponsabile.Size = new System.Drawing.Size(369, 20);
			this.txtResponsabile.TabIndex = 2;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(392, 103);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(406, 40);
			this.groupCredDeb.TabIndex = 5;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.groupCredDeb.Text = "Versante";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(8, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(391, 20);
			this.txtCredDeb.TabIndex = 1;
			this.txtCredDeb.Tag = "registry.title?incomeview.registry";
			// 
			// gboxImporto
			// 
			this.gboxImporto.Controls.Add(this.SubEntity_txtImportoMovimento);
			this.gboxImporto.Controls.Add(this.labelImporto);
			this.gboxImporto.Location = new System.Drawing.Point(8, 80);
			this.gboxImporto.Name = "gboxImporto";
			this.gboxImporto.Size = new System.Drawing.Size(381, 40);
			this.gboxImporto.TabIndex = 4;
			this.gboxImporto.TabStop = false;
			this.gboxImporto.Text = "Importo";
			// 
			// SubEntity_txtImportoMovimento
			// 
			this.SubEntity_txtImportoMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(262, 12);
			this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
			this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtImportoMovimento.TabIndex = 1;
			this.SubEntity_txtImportoMovimento.Tag = "incomeyear.amount?incomeview.ayearstartamount.c";
			this.SubEntity_txtImportoMovimento.Leave += new System.EventHandler(this.SubEntity_txtImportoMovimento_Leave);
			// 
			// labelImporto
			// 
			this.labelImporto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelImporto.Location = new System.Drawing.Point(115, 12);
			this.labelImporto.Name = "labelImporto";
			this.labelImporto.Size = new System.Drawing.Size(141, 20);
			this.labelImporto.TabIndex = 0;
			this.labelImporto.Text = "Importo originale:";
			this.labelImporto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox20
			// 
			this.groupBox20.Controls.Add(this.label15);
			this.groupBox20.Controls.Add(this.txtDataCont);
			this.groupBox20.Controls.Add(this.txtScadenza);
			this.groupBox20.Controls.Add(this.label13);
			this.groupBox20.Location = new System.Drawing.Point(8, 432);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new System.Drawing.Size(377, 35);
			this.groupBox20.TabIndex = 10;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Data";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(47, 9);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 20);
			this.label15.TabIndex = 0;
			this.label15.Text = "Contabile";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataCont
			// 
			this.txtDataCont.Location = new System.Drawing.Point(103, 9);
			this.txtDataCont.Name = "txtDataCont";
			this.txtDataCont.Size = new System.Drawing.Size(72, 20);
			this.txtDataCont.TabIndex = 1;
			this.txtDataCont.Tag = "income.adate";
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(295, 9);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(72, 20);
			this.txtScadenza.TabIndex = 2;
			this.txtScadenza.Tag = "income.expiration";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(223, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 20);
			this.label13.TabIndex = 0;
			this.label13.Text = "Scadenza:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chbAzzeramento
			// 
			this.chbAzzeramento.Location = new System.Drawing.Point(9, 475);
			this.chbAzzeramento.Name = "chbAzzeramento";
			this.chbAzzeramento.Size = new System.Drawing.Size(256, 16);
			this.chbAzzeramento.TabIndex = 18;
			this.chbAzzeramento.Tag = "";
			this.chbAzzeramento.Text = "Azzera il disponibile di tutti i mov. fin. precedenti";
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.txtNumMandato);
			this.groupBox9.Controls.Add(this.label28);
			this.groupBox9.Location = new System.Drawing.Point(16, 8);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(176, 56);
			this.groupBox9.TabIndex = 18;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Reversale di Incasso associata";
			// 
			// txtNumMandato
			// 
			this.txtNumMandato.Location = new System.Drawing.Point(54, 25);
			this.txtNumMandato.Name = "txtNumMandato";
			this.txtNumMandato.Size = new System.Drawing.Size(64, 20);
			this.txtNumMandato.TabIndex = 2;
			this.txtNumMandato.Tag = "proceeds.npro?incomeview.npro";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(6, 25);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(48, 16);
			this.label28.TabIndex = 13;
			this.label28.Text = "Numero:";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// GBoxVariazioni
			// 
			this.GBoxVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.GBoxVariazioni.Controls.Add(this.btnDeleteVar);
			this.GBoxVariazioni.Controls.Add(this.btnEditVar);
			this.GBoxVariazioni.Controls.Add(this.btnInsertVar);
			this.GBoxVariazioni.Controls.Add(this.gridVariazioni);
			this.GBoxVariazioni.Location = new System.Drawing.Point(8, 8);
			this.GBoxVariazioni.Name = "GBoxVariazioni";
			this.GBoxVariazioni.Size = new System.Drawing.Size(790, 487);
			this.GBoxVariazioni.TabIndex = 3;
			this.GBoxVariazioni.TabStop = false;
			this.GBoxVariazioni.Text = "Variazioni al movimento di entrata corrente";
			// 
			// btnDeleteVar
			// 
			this.btnDeleteVar.Location = new System.Drawing.Point(192, 24);
			this.btnDeleteVar.Name = "btnDeleteVar";
			this.btnDeleteVar.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteVar.TabIndex = 27;
			this.btnDeleteVar.Tag = "delete";
			this.btnDeleteVar.Text = "Elimina";
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
			this.gridVariazioni.Location = new System.Drawing.Point(16, 56);
			this.gridVariazioni.Name = "gridVariazioni";
			this.gridVariazioni.Size = new System.Drawing.Size(766, 413);
			this.gridVariazioni.TabIndex = 30;
			this.gridVariazioni.Tag = "incomevar.default.detail";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(168, 16);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 6;
			this.button6.Tag = "delete";
			this.button6.Text = "Elimina";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(88, 16);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 5;
			this.button5.Tag = "edit.detail";
			this.button5.Text = "Modifica";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 16);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 4;
			this.button4.Tag = "insert.detail";
			this.button4.Text = "Inserisci...";
			// 
			// txtImportoAssegnareCrediti
			// 
			this.txtImportoAssegnareCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoAssegnareCrediti.Location = new System.Drawing.Point(647, 16);
			this.txtImportoAssegnareCrediti.Name = "txtImportoAssegnareCrediti";
			this.txtImportoAssegnareCrediti.ReadOnly = true;
			this.txtImportoAssegnareCrediti.Size = new System.Drawing.Size(136, 20);
			this.txtImportoAssegnareCrediti.TabIndex = 11;
			this.txtImportoAssegnareCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labImportoDaAssegnare
			// 
			this.labImportoDaAssegnare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labImportoDaAssegnare.Location = new System.Drawing.Point(463, 16);
			this.labImportoDaAssegnare.Name = "labImportoDaAssegnare";
			this.labImportoDaAssegnare.Size = new System.Drawing.Size(176, 23);
			this.labImportoDaAssegnare.TabIndex = 10;
			this.labImportoDaAssegnare.Text = "Importo disponibile da assegnare:";
			this.labImportoDaAssegnare.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(777, 437);
			this.dataGrid1.TabIndex = 7;
			this.dataGrid1.Tag = "creditpart.detail.detail";
			// 
			// txtImportoAssegnareIncassi
			// 
			this.txtImportoAssegnareIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoAssegnareIncassi.Location = new System.Drawing.Point(649, 16);
			this.txtImportoAssegnareIncassi.Name = "txtImportoAssegnareIncassi";
			this.txtImportoAssegnareIncassi.ReadOnly = true;
			this.txtImportoAssegnareIncassi.Size = new System.Drawing.Size(136, 20);
			this.txtImportoAssegnareIncassi.TabIndex = 16;
			this.txtImportoAssegnareIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point(465, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(176, 23);
			this.label7.TabIndex = 15;
			this.label7.Text = "Importo disponibile da assegnare:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 48);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(777, 437);
			this.dataGrid2.TabIndex = 14;
			this.dataGrid2.Tag = "proceedspart.detail.detail";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(168, 16);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 13;
			this.button7.Tag = "delete";
			this.button7.Text = "Elimina";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(88, 16);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 23);
			this.button8.TabIndex = 12;
			this.button8.Tag = "edit.detail";
			this.button8.Text = "Modifica";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(8, 16);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(75, 23);
			this.button9.TabIndex = 11;
			this.button9.Tag = "insert.detail";
			this.button9.Text = "Inserisci...";
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(184, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 529);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// Tip
			// 
			this.Tip.ShowAlways = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabMovFin1);
			this.tabControl1.Controls.Add(this.tabClassSup);
			this.tabControl1.Controls.Add(this.tabDetails);
			this.tabControl1.Controls.Add(this.tabFatture);
			this.tabControl1.Controls.Add(this.tabIncasso);
			this.tabControl1.Controls.Add(this.tabVariazioni);
			this.tabControl1.Controls.Add(this.tabAssIncassi);
			this.tabControl1.Controls.Add(this.tabAssCrediti);
			this.tabControl1.Controls.Add(this.tabAltro);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(187, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(814, 531);
			this.tabControl1.TabIndex = 4;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabClassSup_Enter);
			// 
			// tabMovFin1
			// 
			this.tabMovFin1.Controls.Add(this.btnScrittureCollegate);
			this.tabMovFin1.Controls.Add(this.gboxfinanziamento);
			this.tabMovFin1.Controls.Add(this.gboxBolletta);
			this.tabMovFin1.Controls.Add(this.gboxUPB);
			this.tabMovFin1.Controls.Add(this.gboxBilAnnuale);
			this.tabMovFin1.Controls.Add(this.label8);
			this.tabMovFin1.Controls.Add(this.labelCausale);
			this.tabMovFin1.Controls.Add(this.cmbCausale);
			this.tabMovFin1.Controls.Add(this.cmbTipoContabilizzazione);
			this.tabMovFin1.Controls.Add(this.gboxDocumento);
			this.tabMovFin1.Controls.Add(this.gboxFasePrecedente);
			this.tabMovFin1.Controls.Add(this.groupBox1);
			this.tabMovFin1.Controls.Add(this.chbAzzeramento);
			this.tabMovFin1.Controls.Add(this.groupBox19);
			this.tabMovFin1.Controls.Add(this.groupBox20);
			this.tabMovFin1.Controls.Add(this.gboxMovimento);
			this.tabMovFin1.Controls.Add(this.groupBox17);
			this.tabMovFin1.Controls.Add(this.SubEntity_chbCoperturaIniziativa);
			this.tabMovFin1.Controls.Add(this.btnSituazioneMovimentoEntrata);
			this.tabMovFin1.Controls.Add(this.gboxResponsabile);
			this.tabMovFin1.Controls.Add(this.groupCredDeb);
			this.tabMovFin1.Controls.Add(this.gboxImporto);
			this.tabMovFin1.Location = new System.Drawing.Point(4, 23);
			this.tabMovFin1.Name = "tabMovFin1";
			this.tabMovFin1.Size = new System.Drawing.Size(806, 504);
			this.tabMovFin1.TabIndex = 0;
			this.tabMovFin1.Text = "Movimento Finanziario";
			// 
			// btnScrittureCollegate
			// 
			this.btnScrittureCollegate.Location = new System.Drawing.Point(634, 467);
			this.btnScrittureCollegate.Name = "btnScrittureCollegate";
			this.btnScrittureCollegate.Size = new System.Drawing.Size(123, 22);
			this.btnScrittureCollegate.TabIndex = 84;
			this.btnScrittureCollegate.Text = "Scritture collegate";
			this.btnScrittureCollegate.Click += new System.EventHandler(this.btnScrittureCollegate_Click);
			// 
			// gboxfinanziamento
			// 
			this.gboxfinanziamento.Controls.Add(this.txtFinanziamento);
			this.gboxfinanziamento.Controls.Add(this.btnFinanziamento);
			this.gboxfinanziamento.Location = new System.Drawing.Point(4, 373);
			this.gboxfinanziamento.Name = "gboxfinanziamento";
			this.gboxfinanziamento.Size = new System.Drawing.Size(385, 61);
			this.gboxfinanziamento.TabIndex = 9;
			this.gboxfinanziamento.TabStop = false;
			this.gboxfinanziamento.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
			// 
			// txtFinanziamento
			// 
			this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFinanziamento.Location = new System.Drawing.Point(6, 35);
			this.txtFinanziamento.Multiline = true;
			this.txtFinanziamento.Name = "txtFinanziamento";
			this.txtFinanziamento.Size = new System.Drawing.Size(372, 22);
			this.txtFinanziamento.TabIndex = 2;
			this.txtFinanziamento.Tag = "underwriting.title?incomeview.underwriting";
			// 
			// btnFinanziamento
			// 
			this.btnFinanziamento.Location = new System.Drawing.Point(3, 9);
			this.btnFinanziamento.Name = "btnFinanziamento";
			this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
			this.btnFinanziamento.TabIndex = 0;
			this.btnFinanziamento.TabStop = false;
			this.btnFinanziamento.Tag = "choose.underwriting.default";
			this.btnFinanziamento.Text = "Finanziamento";
			this.btnFinanziamento.UseVisualStyleBackColor = true;
			// 
			// gboxBolletta
			// 
			this.gboxBolletta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBolletta.Controls.Add(this.SubEntity_txtBolletta);
			this.gboxBolletta.Controls.Add(this.btnBolletta);
			this.gboxBolletta.Location = new System.Drawing.Point(395, 397);
			this.gboxBolletta.Name = "gboxBolletta";
			this.gboxBolletta.Size = new System.Drawing.Size(402, 40);
			this.gboxBolletta.TabIndex = 16;
			this.gboxBolletta.TabStop = false;
			this.gboxBolletta.Tag = "AutoChoose.SubEntity_txtBolletta.entrata.(active=\'S\')";
			// 
			// SubEntity_txtBolletta
			// 
			this.SubEntity_txtBolletta.Location = new System.Drawing.Point(104, 12);
			this.SubEntity_txtBolletta.Name = "SubEntity_txtBolletta";
			this.SubEntity_txtBolletta.Size = new System.Drawing.Size(100, 20);
			this.SubEntity_txtBolletta.TabIndex = 1;
			this.SubEntity_txtBolletta.Tag = "bill.nbill?incomeview.nbill";
			// 
			// btnBolletta
			// 
			this.btnBolletta.Location = new System.Drawing.Point(8, 12);
			this.btnBolletta.Name = "btnBolletta";
			this.btnBolletta.Size = new System.Drawing.Size(88, 23);
			this.btnBolletta.TabIndex = 0;
			this.btnBolletta.TabStop = false;
			this.btnBolletta.Tag = "choose.bill.entrata";
			this.btnBolletta.Text = "N. bolletta";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(8, 162);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(381, 104);
			this.gboxUPB.TabIndex = 7;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Location = new System.Drawing.Point(5, 78);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(369, 20);
			this.txtUPB.TabIndex = 7;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Location = new System.Drawing.Point(138, 8);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(236, 64);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(6, 52);
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
			this.gboxBilAnnuale.Location = new System.Drawing.Point(4, 269);
			this.gboxBilAnnuale.Name = "gboxBilAnnuale";
			this.gboxBilAnnuale.Size = new System.Drawing.Size(385, 104);
			this.gboxBilAnnuale.TabIndex = 8;
			this.gboxBilAnnuale.TabStop = false;
			this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treeeupb.(idupb=\'0001\')";
			// 
			// chkListTitle
			// 
			this.chkListTitle.Location = new System.Drawing.Point(8, 40);
			this.chkListTitle.Name = "chkListTitle";
			this.chkListTitle.Size = new System.Drawing.Size(148, 16);
			this.chkListTitle.TabIndex = 12;
			this.chkListTitle.TabStop = false;
			this.chkListTitle.Text = "Cerca per denominazione";
			this.chkListTitle.CheckedChanged += new System.EventHandler(this.chkListTitle_CheckedChanged);
			// 
			// chkListManager
			// 
			this.chkListManager.Location = new System.Drawing.Point(8, 24);
			this.chkListManager.Name = "chkListManager";
			this.chkListManager.Size = new System.Drawing.Size(148, 16);
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
			this.chkFilterAvailable.Size = new System.Drawing.Size(122, 16);
			this.chkFilterAvailable.TabIndex = 10;
			this.chkFilterAvailable.TabStop = false;
			this.chkFilterAvailable.Text = "Filtra disponibilità";
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
			this.txtCodiceBilancio.Size = new System.Drawing.Size(370, 20);
			this.txtCodiceBilancio.TabIndex = 2;
			this.txtCodiceBilancio.Tag = "finview.codefin?incomeview.codefin";
			// 
			// txtDenominazioneBilancio
			// 
			this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazioneBilancio.Location = new System.Drawing.Point(162, 9);
			this.txtDenominazioneBilancio.Multiline = true;
			this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
			this.txtDenominazioneBilancio.ReadOnly = true;
			this.txtDenominazioneBilancio.Size = new System.Drawing.Size(216, 65);
			this.txtDenominazioneBilancio.TabIndex = 3;
			this.txtDenominazioneBilancio.TabStop = false;
			this.txtDenominazioneBilancio.Tag = "finview.title";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(395, 153);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 22);
			this.label8.TabIndex = 82;
			this.label8.Text = "Tipo contabilizzazione";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelCausale
			// 
			this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.labelCausale.Location = new System.Drawing.Point(434, 176);
			this.labelCausale.Name = "labelCausale";
			this.labelCausale.Size = new System.Drawing.Size(77, 23);
			this.labelCausale.TabIndex = 78;
			this.labelCausale.Text = "Causale";
			this.labelCausale.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbCausale
			// 
			this.cmbCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCausale.DataSource = this.DS.tipomovimento;
			this.cmbCausale.DisplayMember = "descrizione";
			this.cmbCausale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbCausale.ItemHeight = 13;
			this.cmbCausale.Location = new System.Drawing.Point(517, 178);
			this.cmbCausale.Name = "cmbCausale";
			this.cmbCausale.Size = new System.Drawing.Size(281, 21);
			this.cmbCausale.TabIndex = 12;
			this.cmbCausale.ValueMember = "idtipo";
			this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
			// 
			// cmbTipoContabilizzazione
			// 
			this.cmbTipoContabilizzazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoContabilizzazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoContabilizzazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.cmbTipoContabilizzazione.ItemHeight = 13;
			this.cmbTipoContabilizzazione.Location = new System.Drawing.Point(517, 154);
			this.cmbTipoContabilizzazione.Name = "cmbTipoContabilizzazione";
			this.cmbTipoContabilizzazione.Size = new System.Drawing.Size(281, 21);
			this.cmbTipoContabilizzazione.TabIndex = 11;
			this.cmbTipoContabilizzazione.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContabilizzazione_SelectedIndexChanged);
			// 
			// gboxDocumento
			// 
			this.gboxDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDocumento.Controls.Add(this.label9);
			this.gboxDocumento.Controls.Add(this.cmbTipoDocumento);
			this.gboxDocumento.Controls.Add(this.txtNumDoc);
			this.gboxDocumento.Controls.Add(this.label16);
			this.gboxDocumento.Controls.Add(this.txtEsercDoc);
			this.gboxDocumento.Controls.Add(this.btnDocumento);
			this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
			this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.gboxDocumento.Location = new System.Drawing.Point(392, 202);
			this.gboxDocumento.Name = "gboxDocumento";
			this.gboxDocumento.Size = new System.Drawing.Size(406, 72);
			this.gboxDocumento.TabIndex = 13;
			this.gboxDocumento.TabStop = false;
			this.gboxDocumento.Text = "Documento da contabilizzare";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(104, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 16);
			this.label9.TabIndex = 1;
			this.label9.Text = "Eserc.";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbTipoDocumento
			// 
			this.cmbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbTipoDocumento.Location = new System.Drawing.Point(61, 16);
			this.cmbTipoDocumento.Name = "cmbTipoDocumento";
			this.cmbTipoDocumento.Size = new System.Drawing.Size(338, 21);
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
			this.txtNumDoc.Size = new System.Drawing.Size(159, 20);
			this.txtNumDoc.TabIndex = 4;
			this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label16.Location = new System.Drawing.Point(208, 48);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(32, 16);
			this.label16.TabIndex = 3;
			this.label16.Text = "Num.";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(144, 48);
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
			this.btnDocumento.Size = new System.Drawing.Size(96, 20);
			this.btnDocumento.TabIndex = 0;
			this.btnDocumento.TabStop = false;
			this.btnDocumento.Text = "Documento";
			this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
			// 
			// labelTipoDocumento
			// 
			this.labelTipoDocumento.Location = new System.Drawing.Point(8, 21);
			this.labelTipoDocumento.Name = "labelTipoDocumento";
			this.labelTipoDocumento.Size = new System.Drawing.Size(32, 16);
			this.labelTipoDocumento.TabIndex = 6;
			this.labelTipoDocumento.Text = "Tipo";
			this.labelTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox17
			// 
			this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox17.Controls.Add(this.txtDescrizione);
			this.groupBox17.Location = new System.Drawing.Point(392, 0);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(406, 100);
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
			this.txtDescrizione.Size = new System.Drawing.Size(391, 73);
			this.txtDescrizione.TabIndex = 1;
			this.txtDescrizione.Tag = "income.description";
			// 
			// tabClassSup
			// 
			this.tabClassSup.Controls.Add(this.btnGeneraClassAutomatiche);
			this.tabClassSup.Controls.Add(this.DGridClassificazioni);
			this.tabClassSup.Controls.Add(this.label1);
			this.tabClassSup.Controls.Add(this.groupBox15);
			this.tabClassSup.ImageIndex = 1;
			this.tabClassSup.Location = new System.Drawing.Point(4, 23);
			this.tabClassSup.Name = "tabClassSup";
			this.tabClassSup.Size = new System.Drawing.Size(806, 504);
			this.tabClassSup.TabIndex = 1;
			this.tabClassSup.Text = "Classificazioni";
			// 
			// btnGeneraClassAutomatiche
			// 
			this.btnGeneraClassAutomatiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGeneraClassAutomatiche.Location = new System.Drawing.Point(601, 8);
			this.btnGeneraClassAutomatiche.Name = "btnGeneraClassAutomatiche";
			this.btnGeneraClassAutomatiche.Size = new System.Drawing.Size(192, 23);
			this.btnGeneraClassAutomatiche.TabIndex = 34;
			this.btnGeneraClassAutomatiche.Text = "Genera Classificazioni automatiche";
			this.btnGeneraClassAutomatiche.Click += new System.EventHandler(this.btnGeneraClassAutomatiche_Click);
			// 
			// tabDetails
			// 
			this.tabDetails.Controls.Add(this.gboxIncassoDettContratti);
			this.tabDetails.Controls.Add(this.gboxDettEstimate);
			this.tabDetails.Location = new System.Drawing.Point(4, 23);
			this.tabDetails.Name = "tabDetails";
			this.tabDetails.Size = new System.Drawing.Size(806, 504);
			this.tabDetails.TabIndex = 7;
			this.tabDetails.Text = "Contratti attivi";
			// 
			// gboxIncassoDettContratti
			// 
			this.gboxIncassoDettContratti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxIncassoDettContratti.Controls.Add(this.btnCollegaDettagliContratto);
			this.gboxIncassoDettContratti.Controls.Add(this.button1);
			this.gboxIncassoDettContratti.Controls.Add(this.txtTotDettIncassi);
			this.gboxIncassoDettContratti.Controls.Add(this.label11);
			this.gboxIncassoDettContratti.Controls.Add(this.button2);
			this.gboxIncassoDettContratti.Controls.Add(this.gridDettIncassi);
			this.gboxIncassoDettContratti.Controls.Add(this.btnAdd);
			this.gboxIncassoDettContratti.Location = new System.Drawing.Point(10, 206);
			this.gboxIncassoDettContratti.Name = "gboxIncassoDettContratti";
			this.gboxIncassoDettContratti.Size = new System.Drawing.Size(785, 295);
			this.gboxIncassoDettContratti.TabIndex = 70;
			this.gboxIncassoDettContratti.TabStop = false;
			this.gboxIncassoDettContratti.Text = "Dettagli Contratto Attivo incassati";
			// 
			// btnCollegaDettagliContratto
			// 
			this.btnCollegaDettagliContratto.Location = new System.Drawing.Point(8, 157);
			this.btnCollegaDettagliContratto.Name = "btnCollegaDettagliContratto";
			this.btnCollegaDettagliContratto.Size = new System.Drawing.Size(75, 54);
			this.btnCollegaDettagliContratto.TabIndex = 6;
			this.btnCollegaDettagliContratto.Text = "Riporta dettagli accertati";
			this.btnCollegaDettagliContratto.UseVisualStyleBackColor = true;
			this.btnCollegaDettagliContratto.Click += new System.EventHandler(this.btnCollegaDettagliContratto_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Tag = "edit.detail";
			this.button1.Text = "Modifica..";
			// 
			// txtTotDettIncassi
			// 
			this.txtTotDettIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTotDettIncassi.Location = new System.Drawing.Point(6, 267);
			this.txtTotDettIncassi.Name = "txtTotDettIncassi";
			this.txtTotDettIncassi.ReadOnly = true;
			this.txtTotDettIncassi.Size = new System.Drawing.Size(80, 20);
			this.txtTotDettIncassi.TabIndex = 4;
			this.txtTotDettIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Location = new System.Drawing.Point(6, 248);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 16);
			this.label11.TabIndex = 3;
			this.label11.Text = "Totale";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 48);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Tag = "delete";
			this.button2.Text = "Rimuovi";
			// 
			// gridDettIncassi
			// 
			this.gridDettIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettIncassi.DataMember = "";
			this.gridDettIncassi.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettIncassi.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.gridDettIncassi.Location = new System.Drawing.Point(96, 16);
			this.gridDettIncassi.Name = "gridDettIncassi";
			this.gridDettIncassi.Size = new System.Drawing.Size(681, 273);
			this.gridDettIncassi.TabIndex = 1;
			this.gridDettIncassi.Tag = "incomelastestimatedetail.detail.detail";
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
			// gboxDettEstimate
			// 
			this.gboxDettEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDettEstimate.Controls.Add(this.btnEditEstimDet);
			this.gboxDettEstimate.Controls.Add(this.txtTotEstimateDetail);
			this.gboxDettEstimate.Controls.Add(this.label4);
			this.gboxDettEstimate.Controls.Add(this.btnRemoveDetEstimate);
			this.gboxDettEstimate.Controls.Add(this.dgrDettagliContratto);
			this.gboxDettEstimate.Controls.Add(this.btnAddDetEstimate);
			this.gboxDettEstimate.Location = new System.Drawing.Point(10, 0);
			this.gboxDettEstimate.Name = "gboxDettEstimate";
			this.gboxDettEstimate.Size = new System.Drawing.Size(785, 200);
			this.gboxDettEstimate.TabIndex = 3;
			this.gboxDettEstimate.TabStop = false;
			this.gboxDettEstimate.Text = "Dettagli Contratto Attivo";
			// 
			// btnEditEstimDet
			// 
			this.btnEditEstimDet.Location = new System.Drawing.Point(8, 80);
			this.btnEditEstimDet.Name = "btnEditEstimDet";
			this.btnEditEstimDet.Size = new System.Drawing.Size(75, 23);
			this.btnEditEstimDet.TabIndex = 5;
			this.btnEditEstimDet.Text = "Modifica..";
			this.btnEditEstimDet.Click += new System.EventHandler(this.btnModificaDettContratto_Click);
			// 
			// txtTotEstimateDetail
			// 
			this.txtTotEstimateDetail.Location = new System.Drawing.Point(8, 172);
			this.txtTotEstimateDetail.Name = "txtTotEstimateDetail";
			this.txtTotEstimateDetail.ReadOnly = true;
			this.txtTotEstimateDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotEstimateDetail.TabIndex = 4;
			this.txtTotEstimateDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Totale";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRemoveDetEstimate
			// 
			this.btnRemoveDetEstimate.Location = new System.Drawing.Point(8, 48);
			this.btnRemoveDetEstimate.Name = "btnRemoveDetEstimate";
			this.btnRemoveDetEstimate.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveDetEstimate.TabIndex = 2;
			this.btnRemoveDetEstimate.Text = "Rimuovi";
			this.btnRemoveDetEstimate.Click += new System.EventHandler(this.btnScollegaDettContratto_Click);
			// 
			// dgrDettagliContratto
			// 
			this.dgrDettagliContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrDettagliContratto.DataMember = "";
			this.dgrDettagliContratto.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrDettagliContratto.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.dgrDettagliContratto.Location = new System.Drawing.Point(96, 16);
			this.dgrDettagliContratto.Name = "dgrDettagliContratto";
			this.dgrDettagliContratto.Size = new System.Drawing.Size(681, 176);
			this.dgrDettagliContratto.TabIndex = 1;
			// 
			// btnAddDetEstimate
			// 
			this.btnAddDetEstimate.Location = new System.Drawing.Point(8, 16);
			this.btnAddDetEstimate.Name = "btnAddDetEstimate";
			this.btnAddDetEstimate.Size = new System.Drawing.Size(75, 23);
			this.btnAddDetEstimate.TabIndex = 0;
			this.btnAddDetEstimate.Text = "Aggiungi";
			this.btnAddDetEstimate.Click += new System.EventHandler(this.btnCollegaDettContratto_Click);
			// 
			// tabFatture
			// 
			this.tabFatture.Controls.Add(this.gboxDettInvoice);
			this.tabFatture.Location = new System.Drawing.Point(4, 23);
			this.tabFatture.Name = "tabFatture";
			this.tabFatture.Padding = new System.Windows.Forms.Padding(3);
			this.tabFatture.Size = new System.Drawing.Size(806, 504);
			this.tabFatture.TabIndex = 9;
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
			this.gboxDettInvoice.Location = new System.Drawing.Point(3, 6);
			this.gboxDettInvoice.Name = "gboxDettInvoice";
			this.gboxDettInvoice.Size = new System.Drawing.Size(797, 293);
			this.gboxDettInvoice.TabIndex = 4;
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
			this.txtTotInvoiceDetail.Location = new System.Drawing.Point(8, 257);
			this.txtTotInvoiceDetail.Name = "txtTotInvoiceDetail";
			this.txtTotInvoiceDetail.ReadOnly = true;
			this.txtTotInvoiceDetail.Size = new System.Drawing.Size(80, 20);
			this.txtTotInvoiceDetail.TabIndex = 6;
			this.txtTotInvoiceDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Location = new System.Drawing.Point(8, 241);
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
			this.dgrDettagliFattura.Size = new System.Drawing.Size(693, 269);
			this.dgrDettagliFattura.TabIndex = 2;
			// 
			// tabIncasso
			// 
			this.tabIncasso.Controls.Add(this.SubEntity_chkIncassoNetto);
			this.tabIncasso.Controls.Add(this.groupBox2);
			this.tabIncasso.Controls.Add(this.SubEntity_chbDestinazioneVincolata);
			this.tabIncasso.Controls.Add(this.grpModRiscossione);
			this.tabIncasso.Controls.Add(this.textBox1);
			this.tabIncasso.Controls.Add(this.groupBox9);
			this.tabIncasso.Location = new System.Drawing.Point(4, 23);
			this.tabIncasso.Name = "tabIncasso";
			this.tabIncasso.Size = new System.Drawing.Size(806, 504);
			this.tabIncasso.TabIndex = 2;
			this.tabIncasso.Text = "Reversale";
			// 
			// SubEntity_chkIncassoNetto
			// 
			this.SubEntity_chkIncassoNetto.Enabled = false;
			this.SubEntity_chkIncassoNetto.Location = new System.Drawing.Point(282, 133);
			this.SubEntity_chkIncassoNetto.Name = "SubEntity_chkIncassoNetto";
			this.SubEntity_chkIncassoNetto.Size = new System.Drawing.Size(468, 20);
			this.SubEntity_chkIncassoNetto.TabIndex = 97;
			this.SubEntity_chkIncassoNetto.Tag = "incomelast.flag:5?incomeview.flag:5";
			this.SubEntity_chkIncassoNetto.Text = "Incasso da regolarizzare al netto delle spese accessorie (usare strumento bollett" +
    "e multiple)";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtTotaleSospesi);
			this.groupBox2.Controls.Add(this.lbTotale);
			this.groupBox2.Controls.Add(this.btnMultipleBillSel);
			this.groupBox2.Controls.Add(this.labBollette2);
			this.groupBox2.Controls.Add(this.labBollette1);
			this.groupBox2.Controls.Add(this.btnAddBolletta);
			this.groupBox2.Controls.Add(this.btnDelBolletta);
			this.groupBox2.Controls.Add(this.btnEditBolletta);
			this.groupBox2.Controls.Add(this.dgridBollette);
			this.groupBox2.Location = new System.Drawing.Point(16, 159);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(781, 341);
			this.groupBox2.TabIndex = 96;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Collegamento multiplo con bollette";
			// 
			// txtTotaleSospesi
			// 
			this.txtTotaleSospesi.Location = new System.Drawing.Point(702, 41);
			this.txtTotaleSospesi.Name = "txtTotaleSospesi";
			this.txtTotaleSospesi.Size = new System.Drawing.Size(73, 20);
			this.txtTotaleSospesi.TabIndex = 39;
			// 
			// lbTotale
			// 
			this.lbTotale.AutoSize = true;
			this.lbTotale.Location = new System.Drawing.Point(626, 44);
			this.lbTotale.Name = "lbTotale";
			this.lbTotale.Size = new System.Drawing.Size(77, 13);
			this.lbTotale.TabIndex = 38;
			this.lbTotale.Text = "Totale Sospesi";
			// 
			// btnMultipleBillSel
			// 
			this.btnMultipleBillSel.Location = new System.Drawing.Point(5, 230);
			this.btnMultipleBillSel.Name = "btnMultipleBillSel";
			this.btnMultipleBillSel.Size = new System.Drawing.Size(75, 42);
			this.btnMultipleBillSel.TabIndex = 35;
			this.btnMultipleBillSel.TabStop = false;
			this.btnMultipleBillSel.Tag = "";
			this.btnMultipleBillSel.Text = "Selezione multipla";
			this.btnMultipleBillSel.Click += new System.EventHandler(this.btnMultipleBillSel_Click);
			// 
			// labBollette2
			// 
			this.labBollette2.AutoSize = true;
			this.labBollette2.Location = new System.Drawing.Point(64, 44);
			this.labBollette2.Name = "labBollette2";
			this.labBollette2.Size = new System.Drawing.Size(566, 13);
			this.labBollette2.TabIndex = 34;
			this.labBollette2.Text = "Per utilizzare il collegamento multiplo con le bollette è necessario non selezion" +
    "are una bolletta nella maschera principale";
			// 
			// labBollette1
			// 
			this.labBollette1.AutoSize = true;
			this.labBollette1.Location = new System.Drawing.Point(64, 16);
			this.labBollette1.Name = "labBollette1";
			this.labBollette1.Size = new System.Drawing.Size(625, 13);
			this.labBollette1.TabIndex = 33;
			this.labBollette1.Text = "Per utilizzare il collegamento multiplo con le bollette è necessario selezionare " +
    "\"Regolarizza disposizione di pagamento già effettuata\"";
			// 
			// btnAddBolletta
			// 
			this.btnAddBolletta.Location = new System.Drawing.Point(5, 98);
			this.btnAddBolletta.Name = "btnAddBolletta";
			this.btnAddBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnAddBolletta.TabIndex = 30;
			this.btnAddBolletta.TabStop = false;
			this.btnAddBolletta.Tag = "insert.default";
			this.btnAddBolletta.Text = "Inserisci...";
			// 
			// btnDelBolletta
			// 
			this.btnDelBolletta.Location = new System.Drawing.Point(5, 156);
			this.btnDelBolletta.Name = "btnDelBolletta";
			this.btnDelBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnDelBolletta.TabIndex = 32;
			this.btnDelBolletta.TabStop = false;
			this.btnDelBolletta.Tag = "delete";
			this.btnDelBolletta.Text = "Elimina";
			// 
			// btnEditBolletta
			// 
			this.btnEditBolletta.Location = new System.Drawing.Point(5, 127);
			this.btnEditBolletta.Name = "btnEditBolletta";
			this.btnEditBolletta.Size = new System.Drawing.Size(75, 23);
			this.btnEditBolletta.TabIndex = 31;
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
			this.dgridBollette.Location = new System.Drawing.Point(86, 70);
			this.dgridBollette.Name = "dgridBollette";
			this.dgridBollette.Size = new System.Drawing.Size(689, 265);
			this.dgridBollette.TabIndex = 29;
			this.dgridBollette.Tag = "incomebill.list.default";
			// 
			// SubEntity_chbDestinazioneVincolata
			// 
			this.SubEntity_chbDestinazioneVincolata.Enabled = false;
			this.SubEntity_chbDestinazioneVincolata.Location = new System.Drawing.Point(41, 133);
			this.SubEntity_chbDestinazioneVincolata.Name = "SubEntity_chbDestinazioneVincolata";
			this.SubEntity_chbDestinazioneVincolata.Size = new System.Drawing.Size(213, 15);
			this.SubEntity_chbDestinazioneVincolata.TabIndex = 95;
			this.SubEntity_chbDestinazioneVincolata.Tag = "incomelast.flag:4?incomeview.flag:4";
			this.SubEntity_chbDestinazioneVincolata.Text = "Destinazione vincolata (OIL - non OPI)";
			// 
			// grpModRiscossione
			// 
			this.grpModRiscossione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpModRiscossione.Controls.Add(this.SubEntity_chkAccreditoTPS);
			this.grpModRiscossione.Controls.Add(this.SubEntity_chkPrelievodaCCP);
			this.grpModRiscossione.Controls.Add(this.SubEntity_chkCassa);
			this.grpModRiscossione.Location = new System.Drawing.Point(16, 70);
			this.grpModRiscossione.Name = "grpModRiscossione";
			this.grpModRiscossione.Size = new System.Drawing.Size(790, 48);
			this.grpModRiscossione.TabIndex = 92;
			this.grpModRiscossione.TabStop = false;
			this.grpModRiscossione.Text = "Modalità di riscossione";
			// 
			// SubEntity_chkAccreditoTPS
			// 
			this.SubEntity_chkAccreditoTPS.AutoSize = true;
			this.SubEntity_chkAccreditoTPS.Location = new System.Drawing.Point(266, 19);
			this.SubEntity_chkAccreditoTPS.Name = "SubEntity_chkAccreditoTPS";
			this.SubEntity_chkAccreditoTPS.Size = new System.Drawing.Size(260, 17);
			this.SubEntity_chkAccreditoTPS.TabIndex = 12;
			this.SubEntity_chkAccreditoTPS.Tag = "incomelast.flag:3?incomeview.flag:3";
			this.SubEntity_chkAccreditoTPS.Text = "Accredito presso Tesoreria Provinciale dello Stato";
			this.SubEntity_chkAccreditoTPS.UseVisualStyleBackColor = true;
			this.SubEntity_chkAccreditoTPS.CheckedChanged += new System.EventHandler(this.SubEntity_chkAccreditoTPS_CheckedChanged);
			// 
			// SubEntity_chkPrelievodaCCP
			// 
			this.SubEntity_chkPrelievodaCCP.AutoSize = true;
			this.SubEntity_chkPrelievodaCCP.Location = new System.Drawing.Point(121, 19);
			this.SubEntity_chkPrelievodaCCP.Name = "SubEntity_chkPrelievodaCCP";
			this.SubEntity_chkPrelievodaCCP.Size = new System.Drawing.Size(103, 17);
			this.SubEntity_chkPrelievodaCCP.TabIndex = 11;
			this.SubEntity_chkPrelievodaCCP.Tag = "incomelast.flag:2?incomeview.flag:2";
			this.SubEntity_chkPrelievodaCCP.Text = "Prelievo da CCP";
			this.SubEntity_chkPrelievodaCCP.UseVisualStyleBackColor = true;
			this.SubEntity_chkPrelievodaCCP.ClientSizeChanged += new System.EventHandler(this.SubEntity_chkPrelievodaCCP_CheckedChanged);
			// 
			// SubEntity_chkCassa
			// 
			this.SubEntity_chkCassa.AutoSize = true;
			this.SubEntity_chkCassa.Location = new System.Drawing.Point(25, 19);
			this.SubEntity_chkCassa.Name = "SubEntity_chkCassa";
			this.SubEntity_chkCassa.Size = new System.Drawing.Size(74, 17);
			this.SubEntity_chkCassa.TabIndex = 10;
			this.SubEntity_chkCassa.Tag = "incomelast.flag:1?incomeview.flag:1";
			this.SubEntity_chkCassa.Text = "Per Cassa";
			this.SubEntity_chkCassa.UseVisualStyleBackColor = true;
			this.SubEntity_chkCassa.CheckedChanged += new System.EventHandler(this.SubEntity_chkCassa_CheckedChanged);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(353, 8);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(450, 56);
			this.textBox1.TabIndex = 20;
			this.textBox1.Text = "il numero della reversale di incasso viene riempito solo quando verrà emessa la r" +
    "eversale da associare al movimento di entrata";
			// 
			// tabVariazioni
			// 
			this.tabVariazioni.Controls.Add(this.GBoxVariazioni);
			this.tabVariazioni.Location = new System.Drawing.Point(4, 23);
			this.tabVariazioni.Name = "tabVariazioni";
			this.tabVariazioni.Size = new System.Drawing.Size(806, 504);
			this.tabVariazioni.TabIndex = 4;
			this.tabVariazioni.Text = "Variazioni";
			// 
			// tabAssIncassi
			// 
			this.tabAssIncassi.Controls.Add(this.gboxIncassi);
			this.tabAssIncassi.Location = new System.Drawing.Point(4, 23);
			this.tabAssIncassi.Name = "tabAssIncassi";
			this.tabAssIncassi.Size = new System.Drawing.Size(806, 504);
			this.tabAssIncassi.TabIndex = 6;
			this.tabAssIncassi.Text = "Assegnazione di cassa";
			// 
			// gboxIncassi
			// 
			this.gboxIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxIncassi.Controls.Add(this.dataGrid2);
			this.gboxIncassi.Controls.Add(this.button7);
			this.gboxIncassi.Controls.Add(this.button8);
			this.gboxIncassi.Controls.Add(this.button9);
			this.gboxIncassi.Controls.Add(this.txtImportoAssegnareIncassi);
			this.gboxIncassi.Controls.Add(this.label7);
			this.gboxIncassi.Location = new System.Drawing.Point(8, 8);
			this.gboxIncassi.Name = "gboxIncassi";
			this.gboxIncassi.Size = new System.Drawing.Size(793, 493);
			this.gboxIncassi.TabIndex = 17;
			this.gboxIncassi.TabStop = false;
			// 
			// tabAssCrediti
			// 
			this.tabAssCrediti.Controls.Add(this.gboxCrediti);
			this.tabAssCrediti.Location = new System.Drawing.Point(4, 23);
			this.tabAssCrediti.Name = "tabAssCrediti";
			this.tabAssCrediti.Size = new System.Drawing.Size(806, 504);
			this.tabAssCrediti.TabIndex = 5;
			this.tabAssCrediti.Text = "Assegnazione credito";
			// 
			// gboxCrediti
			// 
			this.gboxCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxCrediti.Controls.Add(this.dataGrid1);
			this.gboxCrediti.Controls.Add(this.button6);
			this.gboxCrediti.Controls.Add(this.button5);
			this.gboxCrediti.Controls.Add(this.button4);
			this.gboxCrediti.Controls.Add(this.txtImportoAssegnareCrediti);
			this.gboxCrediti.Controls.Add(this.labImportoDaAssegnare);
			this.gboxCrediti.Location = new System.Drawing.Point(8, 8);
			this.gboxCrediti.Name = "gboxCrediti";
			this.gboxCrediti.Size = new System.Drawing.Size(793, 493);
			this.gboxCrediti.TabIndex = 12;
			this.gboxCrediti.TabStop = false;
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.label27);
			this.tabAltro.Controls.Add(this.textBox7);
			this.tabAltro.Controls.Add(this.lblcup);
			this.tabAltro.Controls.Add(this.txtcup);
			this.tabAltro.Controls.Add(this.grpContocredito);
			this.tabAltro.Location = new System.Drawing.Point(4, 23);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Padding = new System.Windows.Forms.Padding(3);
			this.tabAltro.Size = new System.Drawing.Size(806, 504);
			this.tabAltro.TabIndex = 8;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(10, 174);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(189, 23);
			this.label27.TabIndex = 69;
			this.label27.Tag = "mandate.external_reference";
			this.label27.Text = "Codice proveniente da importazione";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(205, 177);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(276, 20);
			this.textBox7.TabIndex = 3;
			this.textBox7.Tag = "income.external_reference";
			// 
			// lblcup
			// 
			this.lblcup.Location = new System.Drawing.Point(6, 110);
			this.lblcup.Name = "lblcup";
			this.lblcup.Size = new System.Drawing.Size(173, 23);
			this.lblcup.TabIndex = 47;
			this.lblcup.Tag = "";
			this.lblcup.Text = "Codice Unico di Progetto (CUP)";
			this.lblcup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtcup
			// 
			this.txtcup.Location = new System.Drawing.Point(6, 134);
			this.txtcup.Name = "txtcup";
			this.txtcup.Size = new System.Drawing.Size(108, 20);
			this.txtcup.TabIndex = 2;
			this.txtcup.Tag = "income.cupcode";
			// 
			// grpContocredito
			// 
			this.grpContocredito.Controls.Add(this.txtDescrContoCustomer);
			this.grpContocredito.Controls.Add(this.txtCodiceContoCustomer);
			this.grpContocredito.Controls.Add(this.btnContoCredito);
			this.grpContocredito.Location = new System.Drawing.Point(6, 18);
			this.grpContocredito.Name = "grpContocredito";
			this.grpContocredito.Size = new System.Drawing.Size(475, 72);
			this.grpContocredito.TabIndex = 1;
			this.grpContocredito.TabStop = false;
			this.grpContocredito.Tag = "AutoChoose.txtCodiceContoCustomer.default.((flagaccountusage&48)<>0)";
			this.grpContocredito.Text = "Conto EP  per il credito";
			// 
			// txtDescrContoCustomer
			// 
			this.txtDescrContoCustomer.Location = new System.Drawing.Point(232, 14);
			this.txtDescrContoCustomer.Multiline = true;
			this.txtDescrContoCustomer.Name = "txtDescrContoCustomer";
			this.txtDescrContoCustomer.ReadOnly = true;
			this.txtDescrContoCustomer.Size = new System.Drawing.Size(237, 52);
			this.txtDescrContoCustomer.TabIndex = 2;
			this.txtDescrContoCustomer.TabStop = false;
			this.txtDescrContoCustomer.Tag = "account.title";
			// 
			// txtCodiceContoCustomer
			// 
			this.txtCodiceContoCustomer.Location = new System.Drawing.Point(8, 48);
			this.txtCodiceContoCustomer.Name = "txtCodiceContoCustomer";
			this.txtCodiceContoCustomer.Size = new System.Drawing.Size(208, 20);
			this.txtCodiceContoCustomer.TabIndex = 1;
			this.txtCodiceContoCustomer.Tag = "account.codeacc?incomeview.codeacccredit";
			// 
			// btnContoCredito
			// 
			this.btnContoCredito.Location = new System.Drawing.Point(8, 16);
			this.btnContoCredito.Name = "btnContoCredito";
			this.btnContoCredito.Size = new System.Drawing.Size(120, 23);
			this.btnContoCredito.TabIndex = 0;
			this.btnContoCredito.TabStop = false;
			this.btnContoCredito.Tag = "Choose.account.tree.((flagaccountusage&48)<>0)";
			this.btnContoCredito.Text = "Conto";
			// 
			// Frm_income_gerarchico
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(998, 529);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.MovTree);
			this.Name = "Frm_income_gerarchico";
			this.Text = "FrmEntrataGerarchico";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox15.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
			this.gboxMovimento.ResumeLayout(false);
			this.gboxMovimento.PerformLayout();
			this.gboxFasePrecedente.ResumeLayout(false);
			this.gboxFasePrecedente.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.gboxImporto.ResumeLayout(false);
			this.gboxImporto.PerformLayout();
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.GBoxVariazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridVariazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabMovFin1.ResumeLayout(false);
			this.gboxfinanziamento.ResumeLayout(false);
			this.gboxfinanziamento.PerformLayout();
			this.gboxBolletta.ResumeLayout(false);
			this.gboxBolletta.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.gboxBilAnnuale.ResumeLayout(false);
			this.gboxBilAnnuale.PerformLayout();
			this.gboxDocumento.ResumeLayout(false);
			this.gboxDocumento.PerformLayout();
			this.groupBox17.ResumeLayout(false);
			this.groupBox17.PerformLayout();
			this.tabClassSup.ResumeLayout(false);
			this.tabDetails.ResumeLayout(false);
			this.gboxIncassoDettContratti.ResumeLayout(false);
			this.gboxIncassoDettContratti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettIncassi)).EndInit();
			this.gboxDettEstimate.ResumeLayout(false);
			this.gboxDettEstimate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliContratto)).EndInit();
			this.tabFatture.ResumeLayout(false);
			this.gboxDettInvoice.ResumeLayout(false);
			this.gboxDettInvoice.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
			this.tabIncasso.ResumeLayout(false);
			this.tabIncasso.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).EndInit();
			this.grpModRiscossione.ResumeLayout(false);
			this.grpModRiscossione.PerformLayout();
			this.tabVariazioni.ResumeLayout(false);
			this.tabAssIncassi.ResumeLayout(false);
			this.gboxIncassi.ResumeLayout(false);
			this.gboxIncassi.PerformLayout();
			this.tabAssCrediti.ResumeLayout(false);
			this.gboxCrediti.ResumeLayout(false);
			this.gboxCrediti.PerformLayout();
			this.tabAltro.ResumeLayout(false);
			this.tabAltro.PerformLayout();
			this.grpContocredito.ResumeLayout(false);
			this.grpContocredito.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion


		#region Gestione Abilitazione Crediti/Incassi

		void EnableDisableCrediti(bool enable) {
			gboxCrediti.Enabled = enable;
			gboxIncassi.Enabled = enable;
		}

		void EnableDisableCrediti() {
			if (Meta.IsEmpty) {
				EnableDisableCrediti(false);
				return;
			}

			object getupb = GetUpb();
			if (getupb == DBNull.Value) {
				EnableDisableCrediti(false);
				return;
			}

			string filterupb = QHC.CmpEq("idupb", getupb);

			if (DS.upb.Select(filterupb).Length == 0) {
				EnableDisableCrediti(false);
				return;
			}

			DataRow UPB = DS.upb.Select(filterupb)[0];
			if (UPB["assured"].ToString().ToUpper() == "S") {
				EnableDisableCrediti(false);
			}
			else {
				EnableDisableCrediti(true);
			}
		}


		#endregion

		bool faseMaxInclusa() {
			return (faseentratamax == currphase);
		}

		#region Gestione del'abilitazione e disabilitazione dei controlli.

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


		bool InsideAdRemoveTabs;

		void AddRemoveTabs(bool redraw) {
			InsideAdRemoveTabs = true;
			bool ultimafase = (faseMaxInclusa());
			bool fasecontratto = faseContrattoInclusa();
			bool faseiva = faseIvaInclusa();
			int fasebil = ManageBilAnnuale.faseattivazione;
			bool fasebilinclusa = (currphase == fasebil);
			int myphase = cmbFaseEntrata.SelectedIndex;
			tabControl1.SuspendLayout();
			int currsel = tabControl1.SelectedIndex;
			AddRemoveTab(tabDetails, fasecontratto || faseiva, redraw);
			AddRemoveTab(tabAssCrediti, fasebilinclusa && UsaCrediti(), redraw);
			AddRemoveTab(tabFatture,faseiva,redraw);
			AddRemoveTab(tabAssIncassi, ultimafase && UsaCassa(), redraw);
			AddRemoveTab(tabIncasso, ultimafase, redraw);
			AddRemoveTab(tabVariazioni, Meta.EditMode, redraw);
			if (tabControl1.SelectedIndex != currsel) tabControl1.SelectedIndex = currsel;
			if (myphase != cmbFaseEntrata.SelectedIndex)
				cmbFaseEntrata.SelectedIndex = myphase;
			tabControl1.ResumeLayout();
			InsideAdRemoveTabs = false;
		}


		bool UpbFinUnderwritingLocked() {
			if (Meta.InsertMode) {
				return false;
			}

			if (Meta.IsEmpty) {
				return false;
			}

			object OriginalFin = DS.income.Rows[0]["idunderwriting", DataRowVersion.Original];
			object CurrentFin = DS.income.Rows[0]["idunderwriting", DataRowVersion.Current];
			if ((OriginalFin == DBNull.Value) && (CurrentFin == DBNull.Value)) {
				return false;
			}

			decimal OriginalAmount = CfgFn.GetNoNullDecimal(DS.incomeyear.Rows[0]["amount", DataRowVersion.Original]);
			decimal CurrentAmount = CfgFn.GetNoNullDecimal(DS.incomeyear.Rows[0]["amount", DataRowVersion.Current]);
			if (OriginalAmount != CurrentAmount) {
				return true;
			}

			PostData.RemoveFalseUpdates(DS);

			if (DS.incomevar.GetChanges() != null) {
				if (DS.incomevar.GetChanges().Rows.Count > 0) return true;
			}

			if (DS.creditpart.GetChanges() != null) {
				if (DS.creditpart.GetChanges().Rows.Count > 0) return true;
			}

			//default
			return false;
		}

		bool UnderwritingAmountLocked() {
			if (Meta.InsertMode) {
				return false;
			}

			if (Meta.IsEmpty) {
				return false;
			}

			object OriginalFin = DS.income.Rows[0]["idunderwriting", DataRowVersion.Original];
			object CurrentFin = DS.income.Rows[0]["idunderwriting", DataRowVersion.Current];
			if ((OriginalFin == DBNull.Value) && (CurrentFin == DBNull.Value)) {
				return false;
			}

			decimal OriginalAmount = CfgFn.GetNoNullDecimal(DS.incomeyear.Rows[0]["amount", DataRowVersion.Original]);
			decimal CurrentAmount = CfgFn.GetNoNullDecimal(DS.incomeyear.Rows[0]["amount", DataRowVersion.Current]);
			if (OriginalAmount != CurrentAmount) {
				return true;
			}

			if (DS.incomevar.GetChanges() != null) {
				if (DS.incomevar.GetChanges().Rows.Count > 0) return true;
			}

			if (DS.creditpart.GetChanges() != null) {
				if (DS.creditpart.GetChanges().Rows.Count > 0) return true;
			}

			//default
			return false;
		}


		void ApplicaLogicaSuFase() {
			tipocont currcont = ContabilizzazioneSelezionata();
			if (currphase > faseentratamax) currphase = Convert.ToByte(faseentratamax);

			if (currphase > 1 && cmbFaseEntrata.Items.Count >= currphase) {
				btnFasePrecedente.Text = ((DataRowView) cmbFaseEntrata.Items[currphase - 1])["description"].ToString();
				chbAzzeramento.Enabled = true;
			}
			else {
				chbAzzeramento.Enabled = false;
			}


			cmbFaseEntrata.Enabled = Meta.IsEmpty; //fase disabilitata in edit-mode
			//txtEsercizioMovimento.ReadOnly= Meta.EditMode;//eserc. disabilitato in edit
			if (Meta.InsertMode && currphase > 1) {
				txtEsercizioMovimento.Text =
					DS.income.Columns["ymov"].DefaultValue.ToString();
			}
			
			txtEsercizioMovimento.ReadOnly = ((Meta.EditMode) || (currphase > 1) || (!isNumEserEdit)) && !Meta.IsEmpty;
			
			txtNumeroMovimento.ReadOnly = !Meta.IsEmpty; //num.mov. abilitato in ricerca
			btnSituazioneMovimentoEntrata.Enabled = Meta.EditMode;

			txtImportoCorrente.ReadOnly = !Meta.IsEmpty;
			txtImportoDisponibile.ReadOnly = !Meta.IsEmpty;

			btnInsertClass.Enabled = !Meta.IsEmpty;
			btnDelClass.Enabled = !Meta.IsEmpty;
			btnEditClass.Enabled = !Meta.IsEmpty;

			if (currphase <= 1)
				gboxFasePrecedente.Visible = false;
			else {
				gboxFasePrecedente.Visible = true;
				if (Meta.EditMode) {
					txtEsercizioFasePrecedente.ReadOnly = true;
					txtNumeroFasePrecedente.ReadOnly = true;
					btnFasePrecedente.Enabled = false;
				}
				else {
					bool TreeIsFilled = false;
					if (MovTree.Nodes.Count > 0) {
						if (MovTree.Nodes[0].Nodes.Count > 0) TreeIsFilled = true;
					}

					txtEsercizioFasePrecedente.ReadOnly = TreeIsFilled;
					txtNumeroFasePrecedente.ReadOnly = TreeIsFilled;
					btnFasePrecedente.Enabled = !TreeIsFilled;
				}
			}

			if (faseIvaInclusa()) {
				gboxDettInvoice.Visible = true;
			}
			else {
				gboxDettInvoice.Visible = false;
			}

			if (faseContrattoInclusa()) {
				gboxDettEstimate.Visible = true;
			}
			else {
				gboxDettEstimate.Visible = false;
			}

			ManageBilAnnuale.AbilitaDisabilita(currphase);
			ManageCreditore.AbilitaDisabilita(currphase);
			ManageUPB.AbilitaDisabilita(currphase);

			if (UpbFinUnderwritingLocked()) {
				gboxUPB.Enabled = false;
				gboxBilAnnuale.Enabled = false;
				gboxfinanziamento.Enabled = false;
			}
			//else{
			//    gboxUPB.Enabled = true;
			//    gboxBilAnnuale.Enabled = true;
			//    gboxfinanziamento.Enabled = true;
			//}

			if (UnderwritingAmountLocked()) {
				gboxImporto.Enabled = false;
				gboxCrediti.Enabled = false;
				GBoxVariazioni.Enabled = false;
			}
			else {
				gboxImporto.Enabled = true;
				gboxCrediti.Enabled = true;
				GBoxVariazioni.Enabled = true;
			}



			if (ManageUPB.AttualmenteAttivo) {
				object getupb = GetUpb();
				if (Meta.InsertMode && getupb == DBNull.Value) {
					SetUPB(GetDefaultForUpb());
				}
			}


			GBoxVariazioni.Enabled = Meta.EditMode;

			bool ultimafase = (currphase == faseentratamax);

			btnScrittureCollegate.Visible = ultimafase && Meta.EditMode && txtNumMandato.Text != "";

			if (!ultimafase && currphase > 0 && !Meta.IsEmpty) {
				SubEntity_chbCoperturaIniziativa.Checked = false;
				SubEntity_txtBolletta.Text = "";
			}

			btnAddDetEstimate.Enabled =
				(currcont == tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnRemoveDetEstimate.Enabled =
				(currcont == tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnEditEstimDet.Enabled = (currcont == tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnAddDettInvoice.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
			btnRemoveDettInvoice.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
			btnEditInvDet.Enabled = (currcont == tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();

			gboxIncassoDettContratti.Visible = false;
			dettaglioContrattiIncassati = false;

			if (checkAbilitaDettaglioIncassi()) {
				gboxIncassoDettContratti.Visible = true;
				dettaglioContrattiIncassati = true;
			}

			txtNumMandato.ReadOnly = !Meta.IsEmpty;
//			txtEsercMovBancario.ReadOnly	= !Meta.IsEmpty;
//			txtNumMovBancario.ReadOnly		= !Meta.IsEmpty;

			txtImportoDisponibile.Visible = !ultimafase;
			lblImportoDisponibile.Visible = !ultimafase;
			SubEntity_chbCoperturaIniziativa.Enabled = ultimafase;
			SubEntity_chbDestinazioneVincolata.Enabled = ultimafase;
			if (Meta.IsEmpty) {
				ImpostaModalitaRiscossione(null, false);
			}
			else {
				if (DS.registry.Rows.Count > 0) {
					DataRow R = DS.registry.Rows[0];
					if (Meta.InsertMode) {
						ImpostaModalitaRiscossione(R, true);
					}
					else {
						ImpostaModalitaRiscossione(R, false);
					}
				}
				else {
					ImpostaModalitaRiscossione(null, false);
				}
			}

			int fasebil = ManageBilAnnuale.faseattivazione;
			gboxCrediti.Enabled = (currphase == fasebil);
			gboxIncassi.Enabled = ultimafase;

			if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();
			grpContocredito.Visible = ultimafase;

			int ImpegnoGiuridico = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
			if (currphase == ImpegnoGiuridico) {
				lblcup.Visible = true;
				txtcup.Visible = true;
			}
			else {
				lblcup.Visible = false;
				txtcup.Visible = false;
			}

			btnFinanziamento.Enabled = ((currphase == fasebil) && Meta.InsertMode) || Meta.IsEmpty;
			txtFinanziamento.ReadOnly = !(((currphase == fasebil) && Meta.InsertMode) || Meta.IsEmpty);
		}

		bool checkAbilitaDettaglioIncassi() {
			tipocont currcont = ContabilizzazioneSelezionata();
			if ((!Meta.IsEmpty) & faseIvaInclusa() & faseentratamax > 1 & currcont == tipocont.cont_none) {
				DataRow MiddleRow;
				DataRow estim = GetDocRow("estimate", "incomeestimate", faseentrata, out MiddleRow);
				if (MiddleRow != null) {
					var flag =
						DS.estimatekind._Filter(q.eq("idestimkind", MiddleRow["idestimkind"])).FirstOrDefault()?[
							"linktoinvoice"];
					if (flag?.ToString().ToUpper() == "N") {
						if (MiddleRow != null && MiddleRow["movkind"].ToString() != "2") {
							MetaData.SetDefault(DS.incomelastestimatedetail, "idestimkind", MiddleRow["idestimkind"]);
							MetaData.SetDefault(DS.incomelastestimatedetail, "yestim", MiddleRow["yestim"]);
							MetaData.SetDefault(DS.incomelastestimatedetail, "nestim", MiddleRow["nestim"]);
							return true;
						}
					}
				}

			}

			return false;
		}


		#endregion

		void ImpostaModalitaRiscossione(DataRow R, bool mustUpdateValues) {

			if (currphase < faseentratamax) {
				grpModRiscossione.Visible = false;
				SubEntity_chkCassa.Enabled = false;
				SubEntity_chkPrelievodaCCP.Enabled = false;
				SubEntity_chkAccreditoTPS.Enabled = false;
				return;
			}
			else {
				if (R == null) {
					grpModRiscossione.Visible = true;
					SubEntity_chkCassa.Enabled = true;
					SubEntity_chkPrelievodaCCP.Enabled = true;
					SubEntity_chkAccreditoTPS.Enabled = true;
					return;
				}
			}

			if ((R != null) && (currphase == faseentratamax)) {
				grpModRiscossione.Visible = true;
				SubEntity_chkCassa.Enabled = true;
				SubEntity_chkPrelievodaCCP.Enabled = true;
				SubEntity_chkAccreditoTPS.Enabled = true;

				object ccp = R["ccp"];
				object flagbankitaliaproceeds = R["flagbankitaliaproceeds"];

				if ((mustUpdateValues) && (ccp.ToString() == "") &&
				    ((flagbankitaliaproceeds == DBNull.Value) ||
				     (flagbankitaliaproceeds.ToString() != "S"))) {
					SubEntity_chkCassa.Checked = true;
				}

				if (ccp.ToString() != "") {
					SubEntity_chkPrelievodaCCP.Enabled = true;
					if (mustUpdateValues) SubEntity_chkPrelievodaCCP.Checked = true;
				}
				else {
					SubEntity_chkPrelievodaCCP.Enabled = false;
				}

				if ((flagbankitaliaproceeds != DBNull.Value) &&
				    (flagbankitaliaproceeds.ToString() == "S"))
					if (mustUpdateValues)
						SubEntity_chkAccreditoTPS.Checked = true;
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
				SubEntity_chkIncassoNetto.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
				btnMultipleBillSel.Visible = false;
				GestisciBolletteMultiple();
				return;
			}

			if (DS.incomelast.Rows.Count == 0) {
				SubEntity_txtBolletta.ReadOnly = true;
				btnBolletta.Enabled = false;
				btnMultipleBillSel.Visible = false;
				SubEntity_chkIncassoNetto.Enabled = false;
				GestisciBolletteMultiple();
				return;
			}

			if (Meta.InsertMode) {
				if (AI != null) AI.startfilter = "(active='S')";
				SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
				btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
				SubEntity_chkIncassoNetto.Enabled = false; //SubEntity_chbCoperturaIniziativa.Checked;
				btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
				if (!SubEntity_chbCoperturaIniziativa.Checked) {
					SubEntity_txtBolletta.Text = "";
					SubEntity_chkIncassoNetto.Checked = false;
					DataRow CurrR = DS.incomelast.Rows[0];
					CurrR["nbill"] = DBNull.Value;
				}

				GestisciBolletteMultiple();
				return;
			}

			if (AI != null) AI.startfilter = null;
			DataRow Curr = DS.incomelast.Rows[0];
			if (Curr["kpro"] == DBNull.Value) {
				SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
				SubEntity_chkIncassoNetto.Enabled = false; //SubEntity_chbCoperturaIniziativa.Checked;
				btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
				btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
				if (!SubEntity_chbCoperturaIniziativa.Checked) {
					SubEntity_txtBolletta.Text = "";
					SubEntity_chkIncassoNetto.Checked = false;
					DataRow CurrR = DS.incomelast.Rows[0];
					CurrR["nbill"] = DBNull.Value;
				}
			}
			else {
				// Vedo se esistono variazioni di modifica dati trasmessi, che sbloccano le modifiche
				int count = MyConn.RUN_SELECT_COUNT("incomevar", QHS.AppAnd(QHS.CmpEq("idinc", Curr["idinc"]),
					QHS.CmpEq("autokind", 22),
					QHS.IsNull("kproceedstransmission")), true);
				if (count == 0) {
					SubEntity_txtBolletta.ReadOnly = true;
					btnBolletta.Enabled = false;
					SubEntity_chkIncassoNetto.Enabled = false;
					btnMultipleBillSel.Visible = false;
				}
				else {
					SubEntity_txtBolletta.ReadOnly = !SubEntity_chbCoperturaIniziativa.Checked;
					btnBolletta.Enabled = true;
				}
			}

			GestisciBolletteMultiple();
		}



		void GestisciBolletteMultiple() {
			if (Meta.IsEmpty || DS.incomelast.Rows.Count == 0) {
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


		#region After Clear

		public void MetaData_AfterClear() {
			if (MustClose) return;
			GestisciNumBolletta();

			Meta.CanInsert = true;
			Meta.CanInsertCopy = false;
			labelImporto.Text = "Importo originale";

			try {
				if (Meta.IsRealClear) {
					//currphase=1;
					cmbFaseEntrata.SelectedIndex = 1;
					CambiaFase();
				}
				else {
					//AddRemoveTabs(true);
				}
			}
			catch {
			}

			lastimportofreshed = Decimal.MinValue;
			if (cmbTipoContabilizzazione.SelectedIndex > 0) {
				cmbTipoContabilizzazione.SelectedIndex = 0;
			}

			ResetIva();
			ResetEstimate();

			ResetTipoClassAvailableEvalued();
			ClearComboCausale();


			ControlloSuFasiPrecEffettuato = false;
			//Ripulisco il filtro per la ricerca
			ClearStartFilter();

			//Imposta la fase nel combobox
			//cmbFaseEntrata.SelectedIndex = 1;  
			if (Meta.IsRealClear) ApplicaLogicaSuFase();

			GetData.UnCacheTable(DS.sortingkind);
			GetData.CanClear(DS.sortingkind);
			currphase = Convert.ToByte(cmbFaseEntrata.SelectedIndex >= 0
				? cmbFaseEntrata.SelectedIndex
				: 0); //0-indexed
			//fasespesamax = cmbFaseSpesa.Items.Count - 1;//first phase is a blank phase
			txtEsercizioFasePrecedente.Text = "";
			txtNumeroFasePrecedente.Text = "";
			chbAzzeramento.Checked = false;
			txtTotaleSospesi.Text = "";

			cmbFaseEntrata.Enabled = true;
			txtEsercizioMovimento.ReadOnly = false;
			txtNumeroMovimento.ReadOnly = false;
			SubEntity_txtImportoMovimento.ReadOnly = false;

			ClearGridsData();
			AbilitaDisabilitaAssegnazioni();

			if (!Meta.GointToInsertMode) {
				ClearTree();
				ClearDefaultPerNuovoMovimento();
				try {
					if (Meta.IsRealClear) Meta.FreshToolBar();
				}
				catch {
					Meta.FreshToolBar();
				}
			}
			else {
				DisponibileDaFasePrecedente = DisponibilePerProssimafase;
				if (DS.income.ExtendedProperties["app_default"] == null) ClearTree();
				to_mainrefresh = true;
			}

			string tagBtnBolletta = "choose.bill.entrata";
			btnBolletta.Tag = tagBtnBolletta;
		}

		#endregion

		#region AfterLink

		CQueryHelper QHC;
		QueryHelper QHS;

		void AfterLinkBody() {
			MyConn = MetaData.GetConnection(this);
			QHS = MyConn.GetQueryHelper();
			QHC = new CQueryHelper();
			int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

			string filteresercizio = QHS.CmpEq("ayear", currEsercizio);
			GetData.CacheTable(DS.config, filteresercizio, null, false);
			GetData.SetStaticFilter(DS.incomeyear, filteresercizio);
			GetData.SetStaticFilter(DS.incomesorted, filteresercizio);
			GetData.SetStaticFilter(DS.incometotal, filteresercizio);
			GetData.SetStaticFilter(DS.account, filteresercizio);
			GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.BitClear("flag", 0)));
			GetData.CacheTable(DS.expensephase, null, "nphase", true);
			GetData.CacheTable(DS.incomephase, null, "nphase", true);
			GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2)),
				null, true);
			PostData.MarkAsTemporaryTable(DS.tipomovimento, false);
			GetData.SetStaticFilter(DS.creditpart,
				QHS.CmpEq("ycreditpart", currEsercizio));
			GetData.SetStaticFilter(DS.proceedspart,
				QHS.CmpEq("yproceedspart", currEsercizio));
			GetData.CacheTable(DS.estimatekind, null, null, true);


			string filteresercvariazione = QHS.CmpEq("yvar", currEsercizio);
			GetData.SetStaticFilter(DS.incomevar, filteresercvariazione);

			string filterBill = QHS.AppAnd(QHS.CmpEq("billkind", "C"), QHS.CmpEq("ybill", currEsercizio));
			object idflowchart = Meta.GetSys("idflowchart");
			if (idflowchart != null && idflowchart != DBNull.Value) {
				int flagtreasurer =
					CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "(isnull(flag,0)&1)"));
				if (flagtreasurer != 0)
					filterBill = QHS.AppAnd(filterBill, QHS.IsNotNull("idtreasurer"));
			}

			GetData.SetStaticFilter(DS.bill, filterBill);
			GetData.SetStaticFilter(DS.billview, filterBill);
			GetData.SetStaticFilter(DS.bill1, filterBill);
			string filterInvoice = QHS.BitClear("flag", 2);
			GetData.SetStaticFilter(DS.invoicedetail_iva, filterInvoice);
			GetData.SetStaticFilter(DS.invoicedetail_taxable, filterInvoice);

			string filterstart = QHS.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
			string filterstop = QHS.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
			string filterestimatedetail_date = QHS.AppAnd(filterstart, filterstop);
			GetData.SetStaticFilter(DS.estimatedetail_iva, filterestimatedetail_date);
			GetData.SetStaticFilter(DS.estimatedetail_taxable, filterestimatedetail_date);
			monofase = (MyConn.RUN_SELECT_COUNT("incomephase", null, true) == 1) ? true : false;

			int accountingMinYear = CfgFn.GetNoNullInt32(MyConn.DO_READ_VALUE("accountingyear", null, "MIN(ayear)"));
			if (accountingMinYear == currEsercizio) {
				isNumEserEdit = true;
			}
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			AfterLinkBody();
		}


		#endregion


		#region Before/After Activation

		public void MetaData_AfterActivation() {
			btnInsertClass.BackColor = formcolors.GridButtonBackColor();
			btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
			btnEditClass.BackColor = formcolors.GridButtonBackColor();
			btnEditClass.ForeColor = formcolors.GridButtonForeColor();
			btnDelClass.BackColor = formcolors.GridButtonBackColor();
			btnDelClass.ForeColor = formcolors.GridButtonForeColor();

			MetaData MetaEstimDet = MetaData.GetMetaData(this, "estimatedetailview");
			MetaEstimDet.DescribeColumns(DS.estimatedetail_taxable, "listaimpon");
			MetaEstimDet.DescribeColumns(DS.estimatedetail_iva, "listaimpos");

			MetaData MetaInvDet = MetaData.GetMetaData(this, "invoicedetailview");
			MetaInvDet.DescribeColumns(DS.invoicedetail_taxable, "listaimpon");
			MetaInvDet.DescribeColumns(DS.invoicedetail_iva, "listaimpos");
		}

		public void MetaData_BeforeActivation() {
			if (MustClose) return;
			faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			if ((fasespesamax == 0) || (faseentratamax == 0)) {
				show("Non è presente la configurazione delle entrate o delle spese");
				MustClose = true;
				return;
			}

			DS.Tables["income"].ExtendedProperties["faseentratamax"] = faseentratamax;

			MyConn = MetaData.GetConnection(this);
			string filteresercizio = "(ayear='" + Meta.GetSys("esercizio").ToString() + "')";

			ManageBilAnnuale = new GBoxManage(Meta,
				gboxBilAnnuale,
				new Control[] {txtCodiceBilancio, txtDenominazioneBilancio},
				new Control[] {txtCodiceBilancio, btnBilancio},
				new string[] {"idfin"},
				CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase")),
				"fin", filteresercizio);

			ManageUPB = new GBoxManage(Meta,
				gboxUPB,
				new Control[] {txtUPB, txtDescrUPB},
				new Control[] {txtUPB, btnUPBCode},
				new string[] {"idupb"},
				CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase")),
				"upb", null);

			ManageCreditore = new GBoxManage(Meta,
				groupCredDeb,
				new Control[] {txtCredDeb},
				new Control[] {txtCredDeb},
				new string[] {"idreg"},
				CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase")),
				"registry", null);

//			bool RegEuro = (Convert.ToInt16(Meta.GetSys("esercizio").ToString()) <= 2001);
//			ckbRegolamentoEuro.Visible = RegEuro;

			ManageClassificazioni = new GestioneClassificazioni(Meta,
				DGridClassificazioni, DGridDettagliClassificazioni,
				ManageBilAnnuale, ManageUPB, ManageCreditore,
				btnEditClass, btnInsertClass, btnDelClass);

			if (DS.config.Rows.Count == 0) {
				show(this,
					"Non è stata effettuata la configurazione delle entrate o ci sono problemi con la connessione al db, è necessario chiudere la maschera.",
					"Errore");
				MustClose = true;
				return;
			}

			DataRow PersEntrata = DS.Tables["config"].Rows[0];
			flagcreddeb = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 4);
			flagbilancio = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 2);
			flagrespons = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 16);
			flagresidui = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 8);
			fasecontratto = CfgFn.GetNoNullInt32(PersEntrata["incomephase"]);


			faseiva = 99;
			faseiva = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));

			faseentrata = 99;
			if (PersEntrata["incomephase"] != DBNull.Value)
				faseentrata = CfgFn.GetNoNullInt32(PersEntrata["incomephase"]);

			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeproceedspart"],
				QHC.CmpEq("nphase", faseentratamax));

			int fasebilancio = ManageBilAnnuale.faseattivazione;
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomecreditpart"],
				QHC.CmpEq("nphase", fasebilancio));

			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeincomeinvoice"], QHC.CmpEq("nphase", faseiva));

			QueryCreator.SetRelationActivationFilter(DS.Relations["income_incomelastestimatedetail"],
				QHC.CmpEq("nphase", faseentratamax));


			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeincomeestimate"],
				QHC.CmpEq("nphase", faseentrata));

			//QueryCreator.SetRelationActivationFilter(DS.Relations["incomeestimatedetail_taxable"],QHC.CmpEq("nphase", fasecontratto));
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeestimatedetail_taxable1"],
				QHC.CmpEq("nphase", fasecontratto));
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeestimatedetail_iva"],
				QHC.CmpEq("nphase", fasecontratto));
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeinvoicedetail_iva"],
				QHC.CmpEq("nphase", faseiva));
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeinvoicedetail_taxable"],
				QHC.CmpEq("nphase", faseiva));
			QueryCreator.SetRelationActivationFilter(DS.Relations["incomeinvoicedetail_taxable1"],
				QHC.CmpEq("nphase", faseiva));
		}

		#endregion

		#region Gestione fase precedente

		void AzzeraPadre() {
			DataRow CurrEntrata = DS.income.Rows[0];
			CurrEntrata["parentidinc"] = DBNull.Value;
			txtNumeroFasePrecedente.Text = "";
			txtEsercizioFasePrecedente.Text = "";
			CalcolaStartFilter(null);
		}

		/// <summary>
		/// calcola l'esercizio e il numero di movimento del padre del movimento corrente
		/// </summary>
		private void SetFasePrecedente() {
			if (cmbFaseEntrata.SelectedIndex <= 1) return; //se esiste una fase precedente
			if (MetaData.Empty(this)) return;
			//Calcola e riempie i campi relativi alla fase precedente:
			object Livsupid = DS.Tables["income"].Rows[0]["parentidinc"];
			string filter = QHS.CmpEq("idinc", Livsupid);
			DataTable DT = MyConn.RUN_SELECT("income", "idinc,ymov,nmov,autokind", null, filter, null, true);
			if (DT.Rows.Count == 0) return;
			txtEsercizioFasePrecedente.Text = DT.Rows[0]["ymov"].ToString();
			txtNumeroFasePrecedente.Text = DT.Rows[0]["nmov"].ToString();

		}

		bool DocumentoContabilizzato() {
			tipocont curr = ContabilizzazioneSelezionata();
			if (curr == tipocont.cont_none) return false;
			switch (curr) {
				case tipocont.cont_iva: return (IvaLinked != null);
				case tipocont.cont_estimate: return (EstimateLinked != null);
			}

			return false;
		}

		bool ContrattoOFatturaContabilizzato() {
			tipocont curr = ContabilizzazioneSelezionata();
			if (curr == tipocont.cont_none) return false;
			switch (curr) {
				case tipocont.cont_iva: return (IvaLinked != null);
				case tipocont.cont_estimate: return (EstimateLinked != null);
			}

			return false;
		}

		/// <summary>
		/// Estrae un filtro in base a:
		///  - fase precedente
		///  - disponibilità (solo se Modo Insert)
		///  - textbox EserciziofasePrecedente
		///  - textbox NumeroFasePrecedente
		/// </summary>
		/// <returns></returns>
		string GetFasePrecFilter(bool FiltraNumMovimento) {
			string ffase = "";
			if (cmbFaseEntrata.SelectedIndex > 0) {
				int codicefase = CfgFn.GetNoNullInt32(cmbFaseEntrata.SelectedValue);
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
				DataRow Curr = DS.income.Rows[0];
				int codicecreddeb = CfgFn.GetNoNullInt32(Curr["idreg"]);
				int fasecred = ManageCreditore.faseattivazione;
				if (fasecred < currphase && DocumentoContabilizzato()) {
					if (codicecreddeb > 0)
						MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
				}
			}

			if (!Meta.IsEmpty) {
				DataRow CurrImp = DS.incomeyear.Rows[0];
				object idupb = CurrImp["idupb"];
				int faseupb = ManageUPB.faseattivazione;
				if (faseupb < currphase && ContrattoOFatturaContabilizzato()) {
					if (idupb != DBNull.Value)
						MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idupb", idupb));
				}
			}

			return MyFilter;
		}

		private void btnFasePrecedente_Click(object sender, System.EventArgs e) {
			bool ThereWasIvaLinked = (IvaLinked != null);
			bool ThereWasEstimateLinked = (EstimateLinked != null);
			DataAccess Conn = MetaData.GetConnection(this);
			string MyFilter;

			if (((Control) sender).Name == "txtNumeroFasePrecedente")
				MyFilter = GetFasePrecFilter(true);
			else
				MyFilter = GetFasePrecFilter(false);

			MetaData MFase = MetaData.GetMetaData(this, "incomeview");
			MFase.FilterLocked = true;
			MFase.DS = DS;


			DataRow MyDR = MFase.SelectOne("elencofaseprec", MyFilter, null, null);

			if (MyDR == null) {
				if (Meta.InsertMode) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
					}
				}

				return;
			}

			CalcolaStartFilter(MyDR["idinc"].ToString());

			if (Meta.IsEmpty) {
				//Se mi trovo in imposta ricerca
				txtCredDeb.Text = MyDR["registry"].ToString();
				txtEsercizioFasePrecedente.Text = MyDR["ymov"].ToString();
				txtNumeroFasePrecedente.Text = MyDR["nmov"].ToString();
			}

			if (Meta.InsertMode) {
				DS.incomelastestimatedetail.Clear();
				if (checkAbilitaDettaglioIncassi()) {
					autodetectIncassi();
					CalcTotEstimateIncassi();
				}
			}


			if (ThereWasIvaLinked && (IvaLinked == null)) {
				ScollegaIva();
			}

			if (ThereWasEstimateLinked && (EstimateLinked == null)) {
				ScollegaEstimate();
			}
		}



		private void txtNumeroFasePrecedente_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumeroFasePrecedente.ReadOnly) return;
			HelpForm.ExtLeaveIntTextBox(txtNumeroFasePrecedente, null);
			CalcolaStartFilter(null);

			///TODO: Deve effettuare un controllo sull'esistenza del movimento precedente
			///e poi fare un impostazione del supid, o un clear, o un autochoose
			///
			if (Meta.EditMode) return;

			//solo se ricerca o modifica:
			if (!Meta.InsertMode) return;
			if ((txtNumeroFasePrecedente.Text.Trim() == "") &&
			    (Meta.InsertMode)) {

				DataRow Curr = DS.Tables["income"].Rows[0];
				Curr["parentidinc"] = DBNull.Value;
				DisponibileDaFasePrecedente = 0;
				DataRow CurrImp = DS.Tables["incomeyear"].Rows[0];
				CurrImp["amount"] = 0;
				Curr["autokind"] = DBNull.Value;
				Curr["autocode"] = DBNull.Value;
				Curr["idpayment"] = DBNull.Value;
				Curr["idunderwriting"] = DBNull.Value;
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
				Meta.StartFilter = GetData.MergeFilters(Meta.StartFilter, QHS.CmpEq("parentidinc", livsupid));
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

		private void FormattaDataDelTexBox(TextBox TB) {
			if (!TB.Modified) return;
			HelpForm.FormatLikeYear(TB);
		}


		#endregion


		#region Gestione Totali recuperi/dettspeseincassi/dettentrateincassi

		void ClearGridsData() {
			txtImportoAssegnareCrediti.Text = "";
			txtImportoAssegnareIncassi.Text = "";
			txtTotDettIncassi.Text = "";
		}


		void CalcolaTotaliSuGrids() {
			CalcTotInvoiceDetail();
			CalcTotEstimateDetail();
			CalcTotEstimateIncassi();
		}

		void CalcTotEstimateIncassi() {
			txtTotDettIncassi.Text = "";
			if (Meta.IsEmpty) return;
			decimal totale = GetImportoDettagliContrattoIncassati();
			txtTotDettIncassi.Text = totale.ToString("c");
		}

		void CalcTotEstimateDetail() {
			txtTotEstimateDetail.Text = "";
			if (Meta.IsEmpty) return;
			decimal totale = GetImportoDettagliContratto();
			txtTotEstimateDetail.Text = totale.ToString("c");
		}

		void CalcTotInvoiceDetail() {
			txtTotInvoiceDetail.Text = "";
			if (Meta.IsEmpty) return;
			decimal totale = GetImportoDettagliFattura();
			txtTotInvoiceDetail.Text = totale.ToString("c");
		}


		#endregion

		#region azzera dati su cambio fase

		public void AzzeraDatiSuCambioFase() {

			AzzeraPadre();

			AzzeraDatiSuFasiNonSelezionate();
			DS.creditpart.Clear();
			DS.proceedspart.Clear();
			DS.incomevar.Clear();
			DS.incomesorted.Clear();
			DS.incomelastestimatedetail.Clear();
			ResetIva();

		}

		void AzzeraDatiSuFasiNonSelezionate() {
			if (!faseMaxInclusa()) {
				DS.incomelast.Clear();
				DS.incomebill.Clear();
				DS.incomelastestimatedetail.Clear();
				CalcolaTotaliSuGrids();
			}

			if (!faseIvaInclusa()) {
				DS.incomeinvoice.Clear();
				DS.invoice.Clear();
				DS.invoicedetail_taxable.Clear();
				DS.invoicedetail_iva.Clear();

			}

			if (!faseEntrataInclusa()) {
				DS.incomeestimate.Clear();
				DS.estimate.Clear();
				if (!dettaglioContrattiIncassati) DS.estimatedetail_taxable.Clear();
				DS.estimatedetail_iva.Clear();
			}

		}

		void CambiaFase() {
			if (currphase == cmbFaseEntrata.SelectedIndex) return;
			currphase = Convert.ToByte(cmbFaseEntrata.SelectedIndex); //0-indexed
			CreateImputazioneEntrataRow();

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

		#region Beforefill / AfterFill

		void ImpostaFiltroBilancio() {
			if (DS.incomeyear.Rows.Count == 0) return;
			object idupb = DS.incomeyear.Rows[0]["idupb"];
			MetaData.AutoInfo AI;
			AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
			string filter = "(idupb='" + idupb + "')";
			if (AI != null) AI.startfilter = filter;
			DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
		}

		//Richiamata prima di avviare il ciclo di impostazioni dei controlli del Form. 
		//Questo può accadere molte volte nello stesso form, infatti il form 
		//è ridisegnato ogni volta che è aperto e poi richiuso un form secondario.
		public void MetaData_BeforeFill() {
			if (MustClose) return;

			if (!Meta.IsEmpty)
				currphase = Convert.ToByte(CfgFn.GetNoNullInt32(DS.income.Rows[0]["nphase"]));
			else
				currphase = Convert.ToByte(cmbFaseEntrata.SelectedIndex);

			AddRemoveTabs(false);
			ImpostaFiltroBilancio();

			if (MustRefreshImportoEntrata) {
				MustRefreshImportoEntrata = false;
				object identrata = DS.income.Rows[0]["idinc"];
				DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.incometotal, null, QHS.AppAnd(QHS.CmpEq("idinc", identrata),
					QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), null, true);
				//				MyConn.RUN_SELECT_INTO_TABLE(DS.variazionespesa,null,
				//					"(idspesa="+QueryCreator.quotedstrvalue(idspesa,true)+")",null,true);
			}

			RicalcolaImportoCorrente();

			ManageClassificazioni.CalcolaTotaliClassificazioni();

			//Controlla che vi sia o Crea una nuova riga nel DataTable "imputazionespesa"
			//con valori di default.
			if (!MetaData.Empty(this) && (Meta.FormState == MetaData.form_states.insert)) {
				CreateImputazioneEntrataRow();
			}

			DataRow DREntrata = DS.Tables["income"].Rows[0];
			int fase = Convert.ToInt32(DREntrata["nphase"]);
			if (fase == faseentratamax)
				Meta.CanInsert = false;
			else {
				int autokind = CfgFn.GetNoNullInt32(DREntrata["autokind"]);
				if ((Meta.EditMode) && ((autokind == 30) || (autokind == 31) || (autokind == 20) || (autokind == 21))) {
					Meta.CanInsert = false;
				}
				else {
					Meta.CanInsert = true;
				}
			}

			if (Meta.InsertMode) {
				DS.incometotal.Clear(); //risolve il problema dell'inserisci copia
			}

			//if ((Meta.EditMode) && (DS.incomeyear.Rows[0]["flagarrear"].ToString() == "")) {
			//    string identrata = DS.income.Rows[0]["idinc"].ToString();
			//    DS.incomeyear.Clear();
			//    DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.incomeyear, null,
			//        "(idinc=" + QueryCreator.quotedstrvalue(identrata, true) + ")AND" +
			//        "(ayear='" + Meta.GetSys("esercizio").ToString() + "')",
			//        null, true);
			//}

			//E’ disabilitato nel caso in cui  
			//esiste un ID entrata con esercizio = eserciziosessione-1 in imputazionespesa
			if (Meta.EditMode && !ControlloSuFasiPrecEffettuato) {
				SubEntity_txtImportoMovimento.ReadOnly = EsisteEsercPrecedente();
				if (EsisteEsercPrecedente()) {
					labelImporto.Text = "Importo all' 1/1";
				}
				else {
					labelImporto.Text = "Importo originale";
				}

				Meta.CanCancel = !EsisteEsercPrecedente();
				ControlloSuFasiPrecEffettuato = true;
			}

			if (Meta.InsertMode) {
				labelImporto.Text = "Importo originale";
			}
			
			

			if (Meta.InsertMode) Meta.CanCancel = true;
			
			//ReCalcImporto_Incassi();

			if (Meta.FirstFillForThisRow && Meta.InsertMode) {
				if (checkAbilitaDettaglioIncassi()) {
					autodetectIncassi();
				}
			}

			foreach (DataRow r in DS.incomelastestimatedetail.Select()) {
				DS.estimatedetail_incassi.safeMergeFromDb(MyConn,
					q.mCmp(r, "idestimkind", "yestim", "nestim", "rownum"));
				Meta.getData.CalcTemporaryValues(r);
			}

		}

		void ReCalcImporto_Incassi() {
			if (DS.incomelastestimatedetail.Select().Length > 0) {
				decimal totIncassato = GetImportoDettagliContrattoIncassati();
				SetImporto(totIncassato);
				SubEntity_txtImportoMovimento.Text= totIncassato.ToString("c");
			}
		}

		bool RisultatoRicercaEsercizio = false;

		bool EsisteEsercPrecedente() {
			if (!Meta.EditMode) return false;
			if (ControlloSuFasiPrecEffettuato) return RisultatoRicercaEsercizio;
			//object identrata = DS.Tables["income"].Rows[0]["idinc"];
			//int esercizioprec = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
			//string Myfilter = "(idinc='" + identrata + "') AND "
			//    + "(ayear='" + esercizioprec + "')";
			//int count = MyConn.RUN_SELECT_COUNT("incomeyear", Myfilter, true);
			//RisultatoRicercaEsercizio = (count > 0);
			DataRow Curr = DS.Tables["income"].Rows[0];
			if (Curr["ymov"].ToString() == MyConn.GetEsercizio().ToString()) {
				RisultatoRicercaEsercizio = false;
			}
			else {
				RisultatoRicercaEsercizio = true;
			}

			return RisultatoRicercaEsercizio;
		}

		//Richiamata dopo che il Form è stato riempito completamente con i dati opportuni. 
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

			GestisciNumBolletta();

			DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
			if (CurrSorKind != null) {
				string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
				DS.incomesorted.ExtendedProperties["CustomParentRelation"] = f;
			}

			EnableDisableCrediti();

			if (SubEntity_chbCoperturaIniziativa.ThreeState == true)
				SubEntity_chbCoperturaIniziativa.ThreeState = false;
			if (SubEntity_chkCassa.ThreeState == true) SubEntity_chkCassa.ThreeState = false;
			if (SubEntity_chkPrelievodaCCP.ThreeState == true) SubEntity_chkPrelievodaCCP.ThreeState = false;
			if (SubEntity_chkAccreditoTPS.ThreeState == true) SubEntity_chkAccreditoTPS.ThreeState = false;
			if (SubEntity_chbDestinazioneVincolata.ThreeState == true)
				SubEntity_chbDestinazioneVincolata.ThreeState = false;

			if ((IvaLinkedMustBeEvalued == false) && (IvaLinked != null) &&
			    (IvaLinked.RowState == DataRowState.Detached)) {
				if (DS.invoice.Rows.Count > 0) {
					IvaLinked = DS.invoice.Rows[0];
					IvaMovEntrataLinked = DS.incomeinvoice.Rows[0];
				}
				else
					ResetIva();
			}

			if ((EstimateLinkedMustBeEvalued == false) && (EstimateLinked != null) &&
			    (EstimateLinked.RowState == DataRowState.Detached)) {
				if (DS.estimate.Rows.Count > 0) {
					EstimateLinked = DS.estimate.Rows[0];
					EstimateMovEntrataLinked = DS.incomeestimate.Rows[0];
				}
				else
					ResetEstimate();
			}


			if (to_mainrefresh) {
				to_mainrefresh = false;
			}



			if (Meta.EditMode) {
				if (DS.incometotal.Rows.Count == 0) {
					QueryCreator.ShowError(this,
						"A causa di un errore nell'accesso al database, non è possibile " +
						"completare l'operazione. Si prega di chiudere il programma per continuare.",
						"Errore nell'accesso al db");
					Meta.CanSave = false;
					Meta.SearchEnabled = false;
					Meta.CanInsert = false;
					return;
				}

				DisponibilePerProssimafase = CfgFn.GetNoNullDecimal(
					DS.incometotal.Rows[0]["available"]);
			}

			bool IvaWasToLink = IvaLinkedMustBeEvalued;
			RintracciaIva();
			if (IvaWasToLink) {
				if (IvaLinked != null) {
					VisualizzaMainInfo_Iva(IvaLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}

			bool EstimateWasToLink = EstimateLinkedMustBeEvalued;
			RintracciaEstimate();
			if (EstimateWasToLink) {
				if (EstimateLinked != null) {
					VisualizzaMainInfo_Estimate(EstimateLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}

			AzzeraDatiSuFasiNonSelezionate();
			cmbFaseEntrata.Enabled = false;
			txtEsercizioMovimento.ReadOnly = true;
			txtNumeroMovimento.ReadOnly = true;
			ApplicaLogicaSuFase();


			AbilitaDisabilitaControlliContabilizzazione(!Meta.EditMode);

			if (Meta.EditMode) {
				DeduciContabilizzazione();
			}


			if ((!Meta.IsEmpty) && (lastimportofreshed != GetImporto())) {
				lastimportofreshed = GetImporto();
				UpdateImportoDependencies();
			}


			RefillTree(); //temporanea

			//if (!Meta.EditMode) GestioneFasePerDocumentoCollegato();
			if (!Meta.IsEmpty) GestioneFasePerDocumentoCollegato();

			if (Meta.EditMode) UpdateComboCausale();

			CalcolaTotaliSuGrids();

			//ImpostaBilancioPerMonofase();
            if (!(Meta.IsEmpty) && Meta.InsertMode && monofase) {
                chkFilterAvailable.Checked = false;
            }
            else {
                chkFilterAvailable.Checked = true;
            }
			btnSituazioneMovimentoEntrata.Enabled = !Meta.InsertMode;
			RefillImportoAssegnazioni(GetImportoPerClassificazione());

			CalcolaTotaliSuGrids();
			CalcolaTotaleSospesi();


			SetFasePrecedente();

			//set tipoclassmovimenti like a cached table
			GetData.LockRead(DS.sortingkind);
			GetData.DenyClear(DS.sortingkind);


			if (Meta.FirstFillForThisRow) {
				Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
				//ManageClassificazioni.RefillDettagliClassificazioni(GetImportoPerClassificazione());
			}

			//ManageClassificazioni.RicalcolaTipoClassificazioni(currphase,currphase,false);
			if (Meta.FirstFillForThisRow && Meta.InsertMode) {
				ManageClassificazioni.EnterTabClassificazioni(currphase, currphase);
			}

			ManageClassificazioni.CalcImpClassMovDefaults(GetImportoPerClassificazione());

			if ((DS.incomeinvoice.Columns["idinvkind"].DefaultValue != DBNull.Value) &&
			    (DS.incomeinvoice.Columns["yinv"].DefaultValue != DBNull.Value) &&
			    (DS.incomeinvoice.Columns["ninv"].DefaultValue != DBNull.Value) &&
			    Meta.InsertMode &&
			    DS.incomeinvoice.Rows.Count == 0 &&
			    faseIvaInclusa()
			) {
				SetContabilizzazione(tipocont.cont_iva);
				ImpostaComboInvoiceKind();
				HelpForm.SetComboBoxValue(cmbTipoDocumento,
					DS.incomeinvoice.Columns["idinvkind"].DefaultValue.ToString());
				txtNumDoc.Text = DS.incomeinvoice.Columns["ninv"].DefaultValue.ToString();
				txtEsercDoc.Text = DS.incomeinvoice.Columns["yinv"].DefaultValue.ToString();
				DS.incomeinvoice.Columns["yinv"].DefaultValue = DBNull.Value;
				DS.incomeinvoice.Columns["ninv"].DefaultValue = DBNull.Value;
				btnIva_Click(txtNumDoc, null);

			}

			if ((DS.incomeestimate.Columns["idestimkind"].DefaultValue != DBNull.Value) &&
			    (DS.incomeestimate.Columns["yestim"].DefaultValue != DBNull.Value) &&
			    (DS.incomeestimate.Columns["nestim"].DefaultValue != DBNull.Value) &&
			    Meta.InsertMode &&
			    DS.incomeestimate.Rows.Count == 0 &&
			    faseEntrataInclusa()
			) {
				SetContabilizzazione(tipocont.cont_estimate);
				HelpForm.SetComboBoxValue(cmbTipoDocumento,
					DS.incomeestimate.Columns["idestimkind"].DefaultValue.ToString());
				txtNumDoc.Text = DS.incomeestimate.Columns["nestim"].DefaultValue.ToString();
				txtEsercDoc.Text = DS.incomeestimate.Columns["yestim"].DefaultValue.ToString();
				DS.incomeestimate.Columns["yestim"].DefaultValue = DBNull.Value;
				DS.incomeestimate.Columns["nestim"].DefaultValue = DBNull.Value;
				btnEstimate_Click(txtNumDoc, null);

			}

			CalcolaDefaultPerNuovoMovimento();
			// Gestione filtro su partite pendenti
			string tagBtnBolletta = "choose.bill.entrata";
			if ((Meta.InsertMode) || (Meta.EditMode)) {
				btnBolletta.Tag =
					"choose.bill.entrata.((active= 'S') AND (isnull(total,0)-isnull(reduction,0)>covered) AND (ISNULL(toregularize,0)>0))";
			}

			if (Meta.IsEmpty) {
				btnBolletta.Tag = tagBtnBolletta;
			}
			impostaFlagNonContabilizzazioneAccertamento();
			impostaFlagNonContabilizzazione();
		} //fine after_fill

		public void ImpostaBilancioPerMonofase() {
            if (!(Meta.IsEmpty) && Meta.InsertMode && monofase) {
                DataRow DRImputazione = DS.incomeyear.Rows[0];
                //Se il bilancio è null, ed è un monofase con una sola voce di bilancio(escluse le p.g.)
                //allora imposta per defualt quella voce sull'idfin
                if ((DRImputazione["idfin"] == DBNull.Value) || (DRImputazione["idfin"] == null)) {
                    int countFin = CfgFn.GetNoNullInt32(MyConn.count("finusable", q.bitClear("flag", 1) & q.bitClear("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio"))));
                    if (countFin == 1) {
                        chkFilterAvailable.Checked = false;
                        var idfin = MyConn.readValue("finusable", q.bitClear("flag", 1) & q.bitClear("flag", 0) & q.eq("ayear", Meta.GetSys("esercizio")), "idfin");
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
			var rInc = DS.income.First();
			if (rInc == null) return;
			if ((rInc.autokind ?? 0) != 0) {
				impostaBitUltimaFase(false);
				return;
			}

			if (checkPresenzaContabilizzazione()) {
				impostaBitUltimaFase(false);
				return;
			}

			var rIncYear = DS.incomeyear.First();
			if (rIncYear == null) return;
			if (rIncYear.idfin != null) {
				var flag = CfgFn.GetNoNullInt32(MyConn.readValue("fin", q.eq("idfin", rIncYear.idfin), "flag"));
				if ((flag & 2) != 0) {
					impostaBitUltimaFase(false);
					return;
				}
			}

			impostaBitUltimaFase(true);
		}

		void impostaBitUltimaFase(bool imposta) {
			var rLast = DS.incomelast.First();
			if (rLast == null) return;
			if (imposta) {
				rLast.flag = (byte) ((rLast.flag ?? 0) | 128); //mette il bit
			}
			else {
				rLast.flag = (byte) ((rLast.flag ?? 0) & ~128); //toglie il bit
			}
		}

		bool checkPresenzaContabilizzazione() {

			if (IvaLinked != null) return true; //incondizionatamente

			//if (ProfessionaleLinked != null) return true; questo non ci interesa, è necessario contabilizzare una fattura in questo caso

			//if (EstimateLinked != null) {
			//	//solo se ordine non collegabile a fattura
			//	var rEstimKind = DS.estimatekind.First(q.eq("idestimkind", EstimateLinked["idestimkind"]));
			//	return rEstimKind?.linktoinvoice?.ToUpper() == "N";
			//}
			if (DS.incomelastestimatedetail.Select().Length > 0) return true;

			//Serve per il monofase. 
			if (faseentratamax == 1) return true;

			return false;
		}

		void impostaBitFaseContratto(bool imposta)
		{
			var rMov = DS.income.First();
			if (rMov == null) return;
			if (imposta)
			{
				rMov.flag = (byte)((rMov.flag ?? 0) | 1);//imposta il bit 0 di income
			}
			else
			{
				rMov.flag = (byte)((rMov.flag ?? 0) & ~1);//azzera il bit 0 di income
			}
		}

		bool checkPresenzaContabilizzazioneAccertamento()
		{
			if (EstimateLinked != null) return true;

			//Serve per il monofase. 
			if (faseentratamax == 1) return true;

			return false;
		}
		void impostaFlagNonContabilizzazioneAccertamento()
		{
			// il bit zero del campo flag viene settato solo se 
			// il movimento creato manualmente non è una contabilizzazione
			if (!Meta.InsertMode) return;
			if (!faseEntrataInclusa()) return;
			var rInc = DS.income.First();
			if (rInc == null) return;
			if (rInc.nphase != faseentrata) return;

			// Il flag sulla fase dell'impegno/accertamento non deve essere valorizzato quando trattasi di automatismo
			if ((rInc.autokind ?? 0) != 0)
			{
				impostaBitFaseContratto(false);
				return;
			}

			if (checkPresenzaContabilizzazioneAccertamento())
			{
				impostaBitFaseContratto(false);
				return;
			}

			var rIncYear = DS.incomeyear.First();
			if (rIncYear == null) return;
			if (rIncYear.idfin != null)
			{
				// l flag sulla fase dell'impegno/accertamento non deve essere valorizzato quando:
				// 1 sul capitolo finanziario è presente il flag 'partite di giro'  bit posizione 1
				// 2 sul capitolo finanziario è presente il flag 'permetti movimenti non legati a contabilizzazione'  bit posizione 6
				var flag = CfgFn.GetNoNullInt32(MyConn.readValue("fin", q.eq("idfin", rIncYear.idfin), "flag"));
				if ((flag & 2) != 0) // 'partite di giro' 
				{
					impostaBitFaseContratto(false);
					return;
				}
				if ((flag & 64) != 0)
				{
					impostaBitFaseContratto(false); //'permetti movimenti non legati a contabilizzazione'
					return;
				}
			}

			impostaBitFaseContratto(true);
		}

		#endregion


		#region Before/After Post

		bool ricalcolaProceedsBank = false;
		int kpro = 0;

		public void MetaData_BeforePost() {
			ricalcolaProceedsBank = false;
			kpro = 0;
			if (DS.Tables["income"].Rows.Count == 0) return;
			if (!Meta.IsEmpty) {
				if (DS.Tables["income"].Rows[0].RowState == DataRowState.Deleted) {
					DS.incometotal.Clear();
					MustRefreshImportoEntrata = true;
					if (DS.incomelast.Rows.Count > 0 &&
					    DS.incomelast.Rows[0]["kpro", DataRowVersion.Original] != DBNull.Value) {
						ricalcolaProceedsBank = true;
						kpro = CfgFn.GetNoNullInt32(DS.incomelast.Rows[0]["kpro", DataRowVersion.Original]);
					}
				}
				else {
					if (currphase != CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"))) return;
					DataRow CurrLast = DS.incomelast.Rows[0];
					if (CurrLast["kpro"] == DBNull.Value) return;
					if (CurrLast.RowState != DataRowState.Unchanged) {
						ricalcolaProceedsBank = true;
						return;
					}

					foreach (DataRow rVar in DS.incomevar.Rows) {
						if (rVar.RowState == DataRowState.Unchanged) continue;
						if (rVar.RowState == DataRowState.Modified) {
							decimal oldImporto = CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Original]);
							decimal newImporto = CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Current]);
							if (oldImporto == newImporto) continue;
						}

						ricalcolaProceedsBank = true;
					}
				}
			}

			ItWasAnInsert = Meta.InsertMode;
			ItWasAnInsertCancel = false;
		}

		public void MetaData_AfterPost() {
			if (DS.Tables["income"].Rows.Count == 0) {
				ComingFromDelete = true;
				if (ItWasAnInsert) ItWasAnInsertCancel = true;
				MustRefreshImportoEntrata = false;
				fillProceedsBank();
				return;
			}

//			GeneraAutomatismiAfterPost();
			GeneraAzzeraDisponibilitaFasiPrec();
			fillProceedsBank();
			MustRefreshImportoEntrata = true;
			Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "incomeinvoicedetail_taxable");
			Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "incomeinvoicedetail_iva");
			Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva, "incomeestimatedetail_iva");
			Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable, "incomeestimatedetail_taxable");
			}

		#endregion

		#region Gestione Movimenti Bancari

		private void fillProceedsBank() {
			if (!ricalcolaProceedsBank) return;
			if (!ComingFromDelete) {
				if (DS.incomelast.Rows.Count > 0) {
					DataRow CurrLast = DS.incomelast.Rows[0];
					kpro = CfgFn.GetNoNullInt32(CurrLast["kpro"]);
				}
				else
					kpro = 0;
			}

			if (kpro == 0) return;
			Meta.Conn.CallSP("compute_proceeds_bank", new object[] {kpro});
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
			if (Meta.DrawStateIsDone && T.TableName == "sortingkind") {
				if (R != null) {
					string f = QHC.CmpEq("!idsorkind", R["idsorkind"]);
					DS.incomesorted.ExtendedProperties["CustomParentRelation"] = f;
				}
			}

			if (Meta.DrawStateIsDone && T.TableName == "finview" && R != null) {
				SetUPB(R["idupb"]);
			}
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (MustClose) return;

			if (T.TableName == "incomephase") {
				if (!Meta.DrawStateIsDone) return;
				CambiaFase();
				return;
			}

			if (T.TableName == "registry") {
				ResetTipoClassAvailableEvalued();
				ImpostaModalitaRiscossione(R, true);
				return;
			}

			if (T.TableName == "bill") {
				if (R != null) ManageBollettaChange(R);
			}

			if (((T.TableName == "estimatedetail_taxable") || (T.TableName == "estimatedetail_iva")) &&
			    Meta.DrawStateIsDone) {
				if ((T.TableName == "estimatedetail_taxable") && (CurrCausaleEstimate == 1)) {
					if (R != null) R["idinc_iva"] = R["idinc_taxable"];
					CalcolaImportoInBaseADettagliContratto();
				}
			}


			if (T.TableName == "estimate" && Meta.DrawStateIsDone) {
				DS.estimatedetail_iva.Clear();
				DS.estimatedetail_taxable.Clear();
				CalcTotEstimateDetail();
				if (R == null) {
					btnAddDetEstimate.Enabled = false;
					btnRemoveDetEstimate.Enabled = false;
					btnEditEstimDet.Enabled = false;
				}
				else {
					btnAddDetEstimate.Enabled = true;
					btnRemoveDetEstimate.Enabled = true;
					btnEditEstimDet.Enabled = true;
				}
			}


			if (((T.TableName == "invoicedetail_taxable") || (T.TableName == "invoicedetail_iva")) &&
			    Meta.DrawStateIsDone) {
				if ((T.TableName == "invoicedetail_taxable") && (CurrCausaleEstimate == 1)) {
					if (R != null) R["idinc_iva"] = R["idinc_taxable"];
					CalcolaImportoInBaseADettagliFattura();
				}
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

			if (T.TableName == "upb") {
				EnableDisableCrediti();
				if (Meta.DrawStateIsDone) {
					ImpostaBilancioPerMonofase();
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
				//Se ho modificato il Finanziamento blocco l'importo
				if (UnderwritingAmountLocked()) {
					gboxImporto.Enabled = false;
					gboxCrediti.Enabled = false;
					GBoxVariazioni.Enabled = false;
				}
				else {
					gboxImporto.Enabled = true;
					gboxCrediti.Enabled = true;
					GBoxVariazioni.Enabled = true;
				}
			}

			if (T.TableName == "finview") {
				ResetTipoClassAvailableEvalued();


				object getman = GetResponsabile();
				if ((Meta.InsertMode || Meta.EditMode) && (R != null)) {
					if ((R["idman"] != DBNull.Value) &&
					    ((getman == DBNull.Value) ||
					     ((getman != DBNull.Value) &&
					      (getman.ToString() != R["idman"].ToString())
					     )
					    )
					) {
						if ((getman == DBNull.Value) ||
						    show(
							    "Cambio il responsabile in base alla voce di bilancio selezionata?",
							    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
							SetResponsabile(R["idman"]);
						}
					}
				}

				//Se ho modificato il Finanziamento blocco l'importo
				if (UnderwritingAmountLocked()) {
					gboxImporto.Enabled = false;
					gboxCrediti.Enabled = false;
					GBoxVariazioni.Enabled = false;
				}
				else {
					gboxImporto.Enabled = true;
					gboxCrediti.Enabled = true;
					GBoxVariazioni.Enabled = true;
				}
			}


			if ((T.TableName == "sortingkind") && Meta.DrawStateIsDone) {
				ManageClassificazioni.ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}

		}





		void ManageBollettaChange(DataRow Bolletta) {
			if (Meta.IsEmpty) return;
			if (txtDescrizione.Text != "") {
				if (show(
					    "Aggiorno il campo descrizione in base alla Bolletta selezionata?",
					    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK)
					txtDescrizione.Text = Bolletta["motive"].ToString();
			}

			if (txtDescrizione.Text == "") txtDescrizione.Text = Bolletta["motive"].ToString();
			if (SubEntity_chkIncassoNetto.Checked) return;
			//if (SubEntity_txtImportoMovimento.Text==""){
			bool avvisare = (SubEntity_txtImportoMovimento.Text != "");
			decimal impcorrente = CfgFn.GetNoNullDecimal(
				HelpForm.GetObjectFromString(typeof(decimal), SubEntity_txtImportoMovimento.Text,
					"x.y.c"));
			string filter = QueryCreator.WHERE_KEY_CLAUSE(Bolletta, DataRowVersion.Default, true);
			filter = GetData.MergeFilters(filter,
				"(billkind='C')and(ybill='" + Meta.GetSys("esercizio").ToString() + "')");
			object imp = Meta.Conn.DO_READ_VALUE("billview", filter,
				"isnull(total,0)-isnull(reduction,0)-isnull(covered,0)");

			decimal importo = CfgFn.GetNoNullDecimal(imp);
			decimal variazioni = MetaData.SumColumn(DS.incomevar, "amount");
			importo = importo - variazioni;
			if (importo < 0) importo = 0;
			if (importo < impcorrente || impcorrente == 0) {
				SetImporto(importo);
				SubEntity_txtImportoMovimento.Text = importo.ToString("c");
				if (avvisare) {
					show("L'importo del movimento è stato impostato al valore della bolletta", "Avviso");
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
			DataRow CurrExp = DS.income.Rows[0];
			DataRow Curr = DS.incomeyear.Rows[0];
			if (UPB["idman"] != DBNull.Value) {
				SetResponsabile(UPB["idman"]);
			}

			if (fasebilancio < currphase) {
				//Se è già presente una voce di bilancio tramite  una fase precedente,
				//  allora non modifica il bilancio
				if (Curr["idupb"] != DBNull.Value) return;
			}

			string filterprevU = "(F.ayear=" +
			                     QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")" +
			                     "AND( (F.flag & 1)=0)";
			//(U.idfin like '" + Meta.GetSys("esercizio").ToString().Substring(2) + "E%')";
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
				if (Meta.InsertMode && monofase)
					filterprevU = GetData.MergeFilters(filterprevU, "((F.flag & 2) = 0)");

				DataTable Previsione =
					Meta.Conn.SQLRunner("SELECT * from finview U join finusable F on F.idfin= U.idfin where " +
					                    filterprevU, true);
				if (!monofase) {
					if ((Previsione == null) || (Previsione.Rows.Count != 1)) {
					//Valuta se cancellare il capitolo corrente
					DS.finview.Clear();
					Curr["idfin"] = DBNull.Value;
					txtCodiceBilancio.Text = "";
					txtDenominazioneBilancio.Text = "";
					txtFinanziamento.Text = "";
					CurrExp["idunderwriting"] = DBNull.Value;
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

			//Se c'è un finanziamento che ha del disponibile su questo upb selezioniamo questo finanziamento e questo bilancio 
			string filterFinanziamento = "";
			decimal currval = 0;
			if (SubEntity_txtImportoMovimento.Text.Trim() != "") {
				currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
					typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
			}

			filterFinanziamento = GetData.MergeFilters(filterupb,
				"(incomeprevavailable>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
			string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
			                         Meta.GetSys("esercizio").ToString() + "'))";
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string filteridfin = "(ayear ='" + esercizio.ToString() + "')and((flag & 1)=0)";
			filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteroperativo);
			filterFinanziamento =
				GetData.MergeFilters(filterFinanziamento,
					filteridfin); // filtra voci bilancio di entrata ed esercizio corrente

			DataTable Tupbunderwritingyearview = MyConn.RUN_SELECT("upbunderwritingyearview", "*", null,
				filterFinanziamento, null, null, true);
			if ((chkFilterAvailable.Checked) && (Tupbunderwritingyearview.Rows.Count > 0)) {
				DataRow Rupbunderwritingyearview = Tupbunderwritingyearview.Rows[0];
				txtCodiceBilancio.Text = Rupbunderwritingyearview["codefin"].ToString();
				txtDenominazioneBilancio.Text = Rupbunderwritingyearview["fin"].ToString();
				txtFinanziamento.Text = Rupbunderwritingyearview["underwriting"].ToString();
			}
			else {
				txtFinanziamento.Text = "";
			}

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

		void ResetTipoClassAvailableEvalued() {
			if (ManageClassificazioni != null) ManageClassificazioni.Clear();
		}

		private void tabClassSup_Enter(object sender, System.EventArgs e) {
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

		string GetDefaultForUpb() {
			return ""; // "0001";

			//if (DS.upb.Select(QHC.CmpEq("idupb", "0001")).Length > 0) return "0001";
			//DataRow[] upblist = DS.upb.Select(QHC.CmpNe("idupb", ""), "codeupb asc");
			//if (upblist.Length == 0) return "";
			//return upblist[0]["idupb"].ToString();

		}

		public void CreateImputazioneEntrataRow() {
			if (Meta.IsEmpty) return;
			if (DS.Tables["incomeyear"].Rows.Count == 0) {
				try {
					DataRow DREntrata = DS.Tables["income"].Rows[0];
					MetaData MetaImp = MetaData.GetMetaData(this, "incomeyear");
					MetaImp.SetDefaults(DS.incomeyear);
					DataRow DR = MetaImp.Get_New_Row(DREntrata, DS.incomeyear);
					if (DS.incomeyear.ExtendedProperties["app_default"] != null) {
						Hashtable H = (Hashtable) DS.incomeyear.ExtendedProperties["app_default"];
						foreach (string field in new string[] {"amount", "idfin", "idupb"}) {
							DR[field] = H[field];
						}

						CheckTableRow(DS.finview, "idfin", DR["idfin"].ToString());
						SetUPB(DR["idupb"]);
						DR["ayear"] = Meta.GetSys("esercizio");
					}
					else {
						DR["ayear"] = Meta.GetSys("esercizio");
						if (currphase == ManageUPB.faseattivazione) {
							SetUPB(GetDefaultForUpb());
						}
					}
				}
				catch {
				}
			}

			if (currphase >= faseentratamax && DS.Tables["incomelast"].Rows.Count == 0) {
				try {
					DataRow DREntrata = DS.Tables["income"].Rows[0];
					MetaData MetaLast = MetaData.GetMetaData(this, "incomelast");
					MetaLast.SetDefaults(DS.incomelast);
					DataRow DR = MetaLast.Get_New_Row(DREntrata, DS.incomelast);
					int flag = CfgFn.GetNoNullInt32(DS.Tables["incomelast"].Columns["flag"].DefaultValue);

					//flag &= 0xF0;

					//if (DS.incomelast.ExtendedProperties["app_default"] != null)
					//{
					//    Hashtable H = (Hashtable)DS.incomelast.ExtendedProperties["app_default"];

					//    if (H["ccp"] != DBNull.Value)
					//        flag |= 0x04;
					//    else
					//        if (H["flagbankitaliaproceeds"].ToString() == "S")
					//            flag |= 0x08;
					//        else flag |= 0x02;

					//    DR["flag"] = flag;
					//}
				}
				catch {
				}
			}
		}


		#region Gestione Get/Set Importo

		/// <summary>
		/// Restituisce l'importo "esercizio" da utilizzare come base di calcolo per le
		///  prestazioni, ritenute, automatismi, classificazioni etc.
		/// </summary>
		/// <returns></returns>
		decimal GetImporto() {
			DataRow R = DS.incomeyear.Rows[0];
			if (R["amount"] == DBNull.Value) return 0;
			return Convert.ToDecimal(R["amount"]);
		}

		/// <summary>
		/// Imposta l'importo "esercizio"
		/// </summary>
		/// <param name="Importo"></param>
		void SetImporto(decimal Importo) {
			DataRow R = DS.incomeyear.Rows[0];
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

			if (DS.income.Rows.Count == 0) return;
			DataRow imputazioneRow = DS.incomeyear.Rows[0];
			decimal importoOriginale = 0;
			decimal importoCorrente = 0;
			// Se sono in InsertMode: l'importo originale ed il corrente sono uguali e, non esistono variazioni
			//			if (Meta.InsertMode) {
			//				importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount"]);//Default version
			//				importoCorrente = importoOriginale;
			//			}
			// Se non sono in InsertMode: l'importo originale è dato dall'importo (stato ORIGINAL) presente in expenseyear
			// + la somma delle variazioni di spesa presenti all'inizio (quelle unchanged, modified e deleted)
			// con versione ORIGINAL, mentre l'importo corrente è dato dall'importo (stato CURRENT) presente in expenseyear
			// + la somma delle variazioni di spesa presenti attualmente (quelle unchanged, modified e inserted)
			// con versione DEFAULT
			//			else {
			importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Original]);
			foreach (DataRow rVar in DS.incomevar.Rows) {
				if (rVar.RowState == DataRowState.Added) continue;
				importoOriginale += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Original]);
			}

			importoCorrente = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Current]);
			foreach (DataRow rVar in DS.incomevar.Select()) {
				importoCorrente += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Default]);
			}

			//			}
			decimal importoOriginaleClass = 0;
			decimal importoCorrenteClass = 0;
			foreach (DataRow rClass in DS.incomesorted.Select()) {
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
		/// Metodo che allinea l'importo delle assegnazioni crediti/incassi all'importo del movimento di entrata (comprensivo di variazioni)
		/// </summary>
		private void allineaAssegnazioniAdImportoMovimento() {
			if ((Meta.IsEmpty) || (Meta.InsertMode)) return;

			if (DS.income.Rows.Count == 0) return;
			DataRow imputazioneRow = DS.incomeyear.Rows[0];
			decimal importoOriginale = 0;
			decimal importoCorrente = 0;
			// Se sono in InsertMode: l'importo originale ed il corrente sono uguali e, non esistono variazioni
			//			if (Meta.InsertMode) {
			//				importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount"]);//Default version
			//				importoCorrente = importoOriginale;
			//			}
			// Se non sono in InsertMode: l'importo originale è dato dall'importo (stato ORIGINAL) presente in expenseyear
			// + la somma delle variazioni di spesa presenti all'inizio (quelle unchanged, modified e deleted)
			// con versione ORIGINAL, mentre l'importo corrente è dato dall'importo (stato CURRENT) presente in expenseyear
			// + la somma delle variazioni di spesa presenti attualmente (quelle unchanged, modified e inserted)
			// con versione DEFAULT
			//			else {
			importoOriginale = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Original]);
			foreach (DataRow rVar in DS.incomevar.Rows) {
				if (rVar.RowState == DataRowState.Added) continue;
				importoOriginale += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Original]);
			}

			importoCorrente = CfgFn.GetNoNullDecimal(imputazioneRow["amount", DataRowVersion.Current]);
			foreach (DataRow rVar in DS.incomevar.Select()) {
				importoCorrente += CfgFn.GetNoNullDecimal(rVar["amount", DataRowVersion.Default]);
			}

			//			}
			decimal importoOriginaleClass = 0;
			decimal importoCorrenteClass = 0;
			foreach (DataRow rClass in DS.creditpart.Select()) {
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

			foreach (DataRow rClass in DS.proceedspart.Select()) {
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

		decimal GetImportoPerClassificazione() {
			DataRow R = DS.incomeyear.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
			decimal variazione = MetaData.SumColumn(DS.incomevar, "amount");
			return importo + variazione;
		}

		void UpdateImportoDependencies() {
			allineaClassificazioniAdImportoMovimento();
			allineaAssegnazioniAdImportoMovimento();
			ManageClassificazioni.RefillDettagliClassificazioni(GetImportoPerClassificazione());
			// by Leo
			RefillImportoAssegnazioni(GetImportoPerClassificazione());
			if (UpbFinUnderwritingLocked()) {
				gboxUPB.Enabled = false;
				gboxBilAnnuale.Enabled = false;
				gboxfinanziamento.Enabled = false;
			}
			else {
				gboxUPB.Enabled = true;
				gboxBilAnnuale.Enabled = true;
				gboxfinanziamento.Enabled = true;
			}

		}

		void AbilitaDisabilitaAssegnazioni() {
			bool assegnazionevisibile = true;
			if (Meta.EditMode) {
				object identrata = DS.income.Rows[0]["idinc"];
				if (DS.incometotal.Rows.Count == 0) {
					DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.incometotal, null, QHS.AppAnd(
						QHS.CmpEq("idinc", identrata),
						QHS.CmpEq("ayear", Meta.GetSys("esercizio"))), null, true);
				}

				if (DS.incometotal.Rows.Count == 0) {
					show(
						"Attenzione, c'è un problema nei totalizzatori di entrata, contattare il servizio assistenza (" +
						identrata + ")",
						"Errore");
					Meta.LogError("problema nei totalizzatori di entrata");
					assegnazionevisibile = false;
				}
				else {
					DataRow R = DS.incometotal.Rows[0];
					byte flag = Convert.ToByte(R["flag"]);
					bool flagarrear = ((flag & 1) == 1);
					if (flagarrear)
						assegnazionevisibile = false;

				}
			}

			txtImportoAssegnareCrediti.Visible = assegnazionevisibile;
			labImportoDaAssegnare.Visible = assegnazionevisibile;
		}

		void RefillImportoAssegnazioni(decimal Importo) {
			// valorizzare i textbox degli importi ancora da assegnare
			// e impostare i valori di default degli importi delle assegnazioni
			decimal ImportoDaAssegnareCrediti = Importo -
			                                    MetaData.SumColumn(DS.creditpart, "amount");
			decimal ImportoDaAssegnareIncassi = Importo -
			                                    MetaData.SumColumn(DS.proceedspart, "amount");
			DS.creditpart.Columns["amount"].DefaultValue = ImportoDaAssegnareCrediti;
			DS.proceedspart.Columns["amount"].DefaultValue = ImportoDaAssegnareIncassi;
			txtImportoAssegnareCrediti.Text = ImportoDaAssegnareCrediti.ToString("c");
			txtImportoAssegnareIncassi.Text = ImportoDaAssegnareIncassi.ToString("c");
			AbilitaDisabilitaAssegnazioni();
		}

		private void SubEntity_txtImportoMovimento_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (!Meta.DrawStateIsDone) return;
			if (Meta.IsEmpty) return;
			if (SubEntity_txtImportoMovimento.ReadOnly) return;
			Meta.GetFormData(true);
			UpdateImportoDependencies();
		}

		/// <summary>
		/// Restituisce l'importo "esercizio" da utilizzare come base di calcolo per le
		///  prestazioni, ritenute, automatismi, classificazioni etc.
		/// </summary>
		/// <returns></returns>

		#endregion


		#region Gestione Automatismi

		/*	private void btnAutomatismiAccessori_Click(object sender, System.EventArgs e) {
				if (Meta.IsEmpty) return;
				if (Meta.InsertMode) return;
				string identrata=DS.income.Rows[0]["idinc"].ToString();
				string filter= "(idproceeds="+QueryCreator.quotedstrvalue(identrata,true)+")AND"+
					"(autokind='MOVIM')";
				Form F = ShowAutomatismi.Show(Meta,filter,filter,null,null);
				F.Show();
			}*/

//		public void GeneraAutomatismiAfterPost(){
//			if (SecondoPostAttivo) return;
//			if (DS.income.Rows.Count==0) return; //empty
//			DataRow CurrMov= DS.income.Rows[0];
//
//			//Ricalcola gli automatismi
//			GestioneAutomatismi GestAuto = new GestioneAutomatismi(this, 
//				Meta.Conn, Meta.Dispatcher, DS, currphase, faseentratamax, "income", false);
//
//			DataSet Auto = GestAuto.GeneraAutomatismiAfterPost(true);
//			if (Auto==null) return;
//
//			//Salva gli automatismi
//			PostData Post = Meta.Get_PostData();
//			Post.InitClass(Auto, Meta.Conn);
//			bool res = Post.DO_POST();
//			if (!res) return;
//			fillMovBankAutomatismi(Auto.Tables["payment"], "payment");
//			fillMovBankAutomatismi(Auto.Tables["proceeds"], "proceeds");
//
//			SecondoPostAttivo=true;
//			MetaData.SaveFormData(this);
//			SecondoPostAttivo=false;
//		}

		void GeneraAzzeraDisponibilitaFasiPrec() {
			if (Meta.IsEmpty) return;
			if (SecondoPostAttivo) return;
			if (chbAzzeramento.Checked) {
				GestioneAutomatismi GestAuto = new GestioneAutomatismi(this,
					Meta.Conn, Meta.Dispatcher,
					DS, currphase, faseentratamax, "income", false);
				bool res = GestAuto.GeneraAzzeraDisponibilitaFasiPrec();
				if (res) chbAzzeramento.Checked = false;
			}
		}

		#endregion


		#region AfterGetFormData

		public void MetaData_AfterGetFormData() {
			if (Meta.IsEmpty) return;
			//La seg. evita errori in caso di "delete", nel cui caso le tabelle sono vuote.
			if (DS.Tables["incomeyear"].Rows.Count == 0) return;

			DataRow RImputazione = DS.incomeyear.Rows[0];
			DataRow REntrata = DS.income.Rows[0];

			if (REntrata.RowState == DataRowState.Deleted) return;

			// by Leo
			if (Meta.InsertMode) {
				CfgFn.ReSetAutoIncrementPropertiesForFirstPhaseEntrata(
					Meta.Conn, DS.income, REntrata);
			}

			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			//Un movimento è residuo se deriva dagli esercizi precedenti, ossia 
			//   esercmovimento < Conn.esercizio

			if (Meta.InsertMode) {
				//all'atto dell'inserimento porre imputazione.importo = spesa.importo
				//REntrata["amount"] = RImputazione["amount"]; //può cambiare in seg.
				//REntrata["ycreation"] = esercizio;
				RImputazione["ayear"] = esercizio; //REntrata["eserccreazione"];	//per sempre
				//RImputazione["nphase"]=REntrata["nphase"];
			}

			if (currphase == faseentratamax && Meta.EditMode) {
				DataRow IL = DS.incomelast.Rows[0];
				int flag = CfgFn.GetNoNullInt32(IL["flag"]);
				bool incassoLordo = (flag & 32) != 0;
				int autokind = CfgFn.GetNoNullInt32(REntrata["autokind", DataRowVersion.Original]);
				int newAutokind = autokind;
				if (autokind == 14 || autokind == 28) {
					newAutokind = incassoLordo ? 28 : 14;
				}

				if (autokind != newAutokind) {
					REntrata["autokind"] = newAutokind;
				}
			}
			impostaFlagNonContabilizzazioneAccertamento();
			impostaFlagNonContabilizzazione();

			//if (Meta.EditMode){
			//    //				//se flagcompetenza=C per ogni update imputazione.importo = spesa.importo                
			//    //				if (RImputazione["flagcompetenza"].ToString().ToUpper()=="C"){
			//    //					REntrata["importo"] = RImputazione["importo"];
			//    //				}
			//    if(RImputazione["ayear"].ToString()== REntrata["ycreation"].ToString()){
			//        REntrata["amount"] = RImputazione["amount"];
			//    }

			//}
		}


		#endregion

		private void btnSituazioneMovimentoSpesa_Click(object sender, System.EventArgs e) {
			string identrata;
			DataAccess Conn = MetaData.GetConnection(this);
			try {
				DataRow MyRow = HelpForm.GetLastSelected(DS.income);
				identrata = MyRow["idinc"].ToString();
			}
			catch {
				return;
			}

			DataSet Out = Meta.Conn.CallSP("show_income",
				new Object[3] {
					identrata,
					Meta.GetSys("esercizio").ToString(),
					Meta.GetSys("datacontabile")
				}
			);
			if (Out == null) return;
			Out.Tables[0].TableName = "Situazione movimento di entrata";
			frmSituazioneViewer View = new frmSituazioneViewer(Out);
			View.Show();
		}


		void RicalcolaImportoCorrente() {
			if (!Meta.EditMode) return;
			try {
				decimal importo = GetImportoPerClassificazione();
				decimal old = CfgFn.GetNoNullDecimal(DS.incometotal.Rows[0]["curramount"]);
				if (importo != old) {
					decimal diff = importo - old;
					DS.incometotal.Rows[0]["curramount"] = importo;
					decimal disponibile = CfgFn.GetNoNullDecimal(DS.incometotal.Rows[0]["available"]);
					disponibile += diff;
					DS.incometotal.Rows[0]["available"] = disponibile;
					DS.incometotal.Rows[0].AcceptChanges();
					UpdateImportoDependencies();
				}
			}
			catch {
			}
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

		bool ItWasAnInsert = false;

		bool ItWasAnInsertCancel = false;
		//Viene chiamato ogni volta che viene selezionata una riga differente in una qualsiasi
		//tabella del Dataset in memoria.


		void CheckTableRow(DataTable T, string idfield, string id) {
			if ((idfield == null) || (idfield == "")) {
				if (T.Rows.Count > 0) T.Clear();
				return;
			}

			if (T.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(MyConn, T, null, "(" + idfield + "=" +
				                                                  QueryCreator.quotedstrvalue(id, true) + ")", null,
					true);
				return;
			}

			if (T.Rows[0][idfield].ToString() == id) return;
			T.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(MyConn, T, null, "(" + idfield + "=" +
			                                                  QueryCreator.quotedstrvalue(id, true) + ")", null, true);
		}


		private void btnGeneraClassAutomatiche_Click(object sender, System.EventArgs e) {
			Meta.GetFormData(true);
			ManageClassificazioni.btnGeneraClass_Click(currphase, currphase);
			//if siopekind.newcomputesorting ='S' aggiunge le class. , leggendo il Cod.Class. dal documento contabilizzato 
			string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind",
				QHS.AppAnd(QHS.CmpEq("codesorkind_siopeentrate", Meta.GetSys("codesorkind_siopeentrate")),
					QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
				),
				"newcomputesorting")?.ToString();

			if ((newcomputesorting == "S") && (currphase == faseentratamax)) {
				//Classifica il movimento in base all'idsor_siope specificato nel documento contabilizzato
				ManageClassificazioni.ClassificaTramiteClassDocumento(DS, null);
				ManageClassificazioni.completaClassificazioniSiope(DS.incomesorted, DS);
				Meta.FreshForm();
			}
		}



		#region Gestione Tree

		void ClearDefaultPerNuovoMovimento() {
			if (Meta.GointToInsertMode) return;
			DS.income.Columns["nphase"].DefaultValue = 1;
			DS.income.Columns["parentidinc"].DefaultValue = DBNull.Value;
			DS.income.Columns["description"].DefaultValue = "";
			DS.income.Columns["autokind"].DefaultValue = DBNull.Value;
			DS.income.Columns["autocode"].DefaultValue = DBNull.Value;
			DS.income.Columns["idpayment"].DefaultValue = DBNull.Value;
			DS.income.Columns["description"].DefaultValue = "";
			DS.income.Columns["idunderwriting"].DefaultValue = DBNull.Value;
			foreach (string field in new string[] {"idreg", "doc", "docdate", "idman"}) {
				DS.income.Columns[field].DefaultValue = DBNull.Value;
			}

			DontApplyDefault();
		}



		void CalcolaDefaultPerNuovoMovimento() {
			if (!Meta.EditMode) return;
			DataRow DRImputazione = DS.Tables["incomeyear"].Rows[0];
			DataRow DREntrata = DS.Tables["income"].Rows[0];
			//DataRow UPB = DS.Tables["upb"].Rows[0];

			if (DS.incometotal.Rows.Count == 0) {
				show("Importo entrata  was empty");
				return;
			}

			DataRow DRImportoEntrata = DS.Tables["incometotal"].Rows[0];

			FasePrecValues["idreg"] = DREntrata["idreg"];
			FasePrecValues["description"] = DREntrata["description"];
			FasePrecValues["doc"] = DREntrata["doc"];
			FasePrecValues["docdate"] = DREntrata["docdate"];
			FasePrecValues["idman"] = DREntrata["idman"];
			FasePrecValues["idpayment"] = DREntrata["idpayment"];
			FasePrecValues["autokind"] = DREntrata["autokind"];
			FasePrecValues["autocode"] = DREntrata["autocode"];
			FasePrecValues["amount"] = DRImportoEntrata["available"]; ///TODO: Chiedere a Francesco			
			FasePrecValues["ayear"] = DRImputazione["ayear"]; ///TODO: Chiedere a Francesco		
			FasePrecValues["idunderwriting"] = DREntrata["idunderwriting"];

			int fase = Convert.ToInt32(DREntrata["nphase"]);

			if (fase < faseentratamax) {
				fase++;
				DS.income.Columns["parentidinc"].DefaultValue = DREntrata["idinc"];
				FasePrecValues["parentidinc"] = DREntrata["idinc"];
			}
			else {
				DS.income.Columns["parentidinc"].DefaultValue = DREntrata["parentidinc"];
				FasePrecValues["parentidinc"] = DREntrata["parentidinc"];
			}

			Meta.FreshToolBar();

			FasePrecValues["nphase"] = fase;
			FasePrecValues["idfin"] = DRImputazione["idfin"];
			FasePrecValues["idupb"] = DRImputazione["idupb"];


			object idman = MyConn.readValue("upb", q.eq("idupb", DRImputazione["idupb"]), "idman");

			if (idman != DBNull.Value) {
				FasePrecValues["idman"] = idman;
			}


			DS.income.Columns["nphase"].DefaultValue = fase;

			DS.Tables["income"].ExtendedProperties["app_default"] = FasePrecValues;
			DS.Tables["incomeyear"].ExtendedProperties["app_default"] = FasePrecValues;
		}

		void DontApplyDefault() {
			DS.Tables["income"].ExtendedProperties["app_default"] = null;
			DS.Tables["incomeyear"].ExtendedProperties["app_default"] = null;
			DS.Tables["incomelast"].ExtendedProperties["app_default"] = null;
		}


		bool DontRefill = false;
		object lastid = null;

		string CaptionForNode(DataRow R) {
			string Caption = R["phase"].ToString() + " " +
			                 R["ymov"].ToString() + " " +
			                 R["nmov"].ToString().PadLeft(6, '0');
			return Caption;

		}

		bool AddNode(TreeNodeCollection TC, DataRow R) {
			object livsupid = R["parentidinc"];

			foreach (TreeNode TN in TC) {
				DataRow TR = (DataRow) TN.Tag;
				object currid = TR["idinc"];
				if (livsupid.Equals(currid)) {
					TreeNode NewNode = new TreeNode(CaptionForNode(R));
					NewNode.Tag = R;
					TN.Nodes.Add(NewNode);
					return true;
				}

				if (AddNode(TN.Nodes, R)) return true;
			}

			return false;
		}

		bool SelectNode(TreeNodeCollection TC, object IDEntrata) {
			foreach (TreeNode TN in TC) {
				DataRow TR = (DataRow) TN.Tag;
				object currid = TR["idinc"];
				if (IDEntrata.Equals(currid)) {
					TN.EnsureVisible();
					MovTree.SelectedNode = TN;
					return true;
				}

				if (SelectNode(TN.Nodes, IDEntrata)) return true;
			}

			return false;
		}

		void ClearTree() {
			if (!MovTree.Enabled) return;
			if (DontRefill) return;
			if (!ComingFromDelete) {
				ResetTree();
				return;
			}

			ComingFromDelete = false;

			if (ItWasAnInsertCancel) {
				ItWasAnInsertCancel = false;
				TreeNode Old = MovTree.SelectedNode;
				MovTree.Enabled = false;
				MovTree.SelectedNode = null;
				MovTree.Enabled = true;
				MovTree.SelectedNode = Old;
				return;
			}

			TreeNode CurrNode = MovTree.SelectedNode;
			TreeNode ParentNode = null;
			if (CurrNode != null) ParentNode = CurrNode.Parent;
			if (ParentNode != null) {
				MovTree.Enabled = false;
				CurrNode.Remove();
				MovTree.SelectedNode = null;
				MovTree.Enabled = true;
				if (ParentNode.Nodes.Count > 0) {
					MovTree.SelectedNode = ParentNode.Nodes[0];
				}
				else {
					MovTree.SelectedNode = ParentNode;
				}

				return;
			}

			ResetTree();

		}

		void ResetTree() {
			lastid = null;
			TreeNodeCollection TC = MovTree.Nodes;
			MovTree.Enabled = false;
			TC.Clear();
			TreeNode RootEntrata = new TreeNode("entrata");
			TC.Add(RootEntrata);
			ClearDefaultPerNuovoMovimento();
			MovTree.SelectedNode = RootEntrata;
			MovTree.Enabled = true;

		}

		void RefillTree() {
			if (Meta.IsEmpty) return;
			if (DontRefill) {
				return;
			}

			DataAccess Conn = Meta.Conn;
			DataRow Curr = DS.income.Rows[0];
			object currid = Meta.Conn.DO_READ_VALUE("incomelink",
				"(idchild=" + QueryCreator.quotedstrvalue(Curr["idinc"], true) + ")" +
				"AND(nlevel=1)", "idparent");

			if (Meta.InsertMode) {
				lastid = null;
				return;
			}

			if ((lastid != null) && lastid.Equals(currid)) return;
			lastid = currid;

			DataTable TreeTable =
				Meta.Conn.SQLRunner("select nphase,idinc,parentidinc,phase,nmov,ymov,description from incomeview I " +
				                    " join incomelink IL on IL.idchild=I.idinc " +
				                    " where (IL.idparent = " + QueryCreator.quotedstrvalue(currid, true) + ")" +
				                    " and (I.ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) +
				                    ")" +
				                    " order by nphase ASC, idinc ASC");

			if (TreeTable == null) {
				Meta.ErroreIrrecuperabile = true;
				show(
					"Errore nell'accedere alla informazioni sulla gerarchia, è necessario chiudere la maschera.",
					"Errore");
				MovTree.Enabled = false;
				MovTree.Nodes.Clear();
				return;
			}

			TreeNodeCollection TC = MovTree.Nodes;

			MovTree.Enabled = false;
			TC.Clear();
			TreeNode RootEntrata = new TreeNode("entrata");
			TC.Add(RootEntrata);
			foreach (DataRow R in TreeTable.Rows) {
				if (R["nphase"].ToString() == "1") {
					TreeNode New = new TreeNode(CaptionForNode(R));
					New.Tag = R;
					RootEntrata.Nodes.Add(New);
					continue;
				}

				AddNode(RootEntrata.Nodes, R);
			}

			SelectNode(RootEntrata.Nodes, Curr["idinc"]);
			MovTree.Enabled = true;
		}


		private void MovTree_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e) {
			if (!MovTree.Enabled) return;
			if (Meta.IsEmpty) return;

			TreeNode T = MovTree.SelectedNode;
			if (T == null) return;

			if (e.Node == MovTree.SelectedNode) {
				return;
			}

			MovTree.Enabled = false;
			if (!Meta.WarnUnsaved()) {
				e.Cancel = true;
				//tabControl1.Focus();
			}
			else {
				DS.RejectChanges();
			}

			MovTree.Enabled = true;
		}

		private void MovTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			//if (Meta.IsEmpty) return;
			if (!MovTree.Enabled) return;
			if (DontRefill) return;
			TreeNode T = e.Node;
			if (T == null) return;
			DataRow R = (DataRow) T.Tag;
			if (R == null) {
				ClearDefaultPerNuovoMovimento();
				DontRefill = true;
				MetaData.ClearForm(this);
				DontRefill = false;
				return;
			}

			MovTree.Enabled = false;
			DontRefill = true;
			Meta.SelectRow(R, "default");
			DontRefill = false;
			lastid = Meta.Conn.DO_READ_VALUE("incomelink",
				"(idchild=" + QueryCreator.quotedstrvalue(R["idinc"], true) + ")" +
				"AND(nlevel=1)", "idparent");
			MovTree.Enabled = true;
		}

		private void MovTree_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (!MovTree.Enabled) return;
			TreeNode N = MovTree.GetNodeAt(e.X, e.Y);
			if (N == null) return;
			DataRow R = (DataRow) N.Tag;
			if (R == null) return;
			String S = R["description"].ToString();
			string old = Tip.GetToolTip(MovTree);
			if (old == S) return;
			Tip.SetToolTip(MovTree, S);
			Tip.Active = true;

		}

		#endregion


		#region Gestione ComboBox Causali (generico)

		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui è agganciato il combo causale
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
				case tipocont.cont_iva:
					UpdateComboCausaleIva();
					break;
				case tipocont.cont_estimate:
					UpdateComboCausaleEstimate();
					break;
			}
		}

		/// <summary>
		/// Imposta il valore del combobox ed aggiorna l'importo del movimento
		/// </summary>
		/// <param name="tipomovimento"></param>
		/*void SetValueComboCausale(string tipomovimento){
			cmbCausale.SelectedValue= tipomovimento;
			RecalcImporto();
		}*/

		void RecalcImporto() {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					ReCalcImporto_Iva();
					return;
				case tipocont.cont_estimate:
					ReCalcImporto_Estimate();
					return;
				case tipocont.cont_none:
					return;
			}
		}


		#endregion

		#region Gestione Documenti Contabilizzazione

		private void cmbTipoDocumentoGenerico_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					cmbTipoDocumento_SelectedIndexChanged(sender, e);
					break;
				case tipocont.cont_estimate:
					cmbTipoEstimate_SelectedIndexChanged(sender, e);
					break;
			}
		}

		private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					cmbCausaleIva_SelectedIndexChanged(sender, e);
					break;
				case tipocont.cont_estimate:
					cmbCausaleEstimate_SelectedIndexChanged(sender, e);
					break;
			}
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					btnIva_Click(sender, e);
					break;
				case tipocont.cont_estimate:
					btnEstimate_Click(sender, e);
					break;

			}
		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					txtEsercIva_Leave(sender, e);
					break;
				case tipocont.cont_estimate:
					txtEsercEstimate_Leave(sender, e);
					break;
			}
		}

		private void txtNumDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont = ContabilizzazioneSelezionata();
			switch (currcont) {
				case tipocont.cont_iva:
					txtNumIva_Leave(sender, e);
					break;
				case tipocont.cont_estimate:
					txtNumEstimate_Leave(sender, e);
					break;
			}
		}


		tipocont DeduciTipoContabilizzazione() {
			if (DS.incomeinvoice.Rows.Count > 0) return tipocont.cont_iva;
			if (DS.incomeestimate.Rows.Count > 0) return tipocont.cont_estimate;
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
				case tipocont.cont_iva:
					SetEditComboCausaleIva();
					break;
				case tipocont.cont_estimate:
					SetEditComboCausaleEstimate();
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
		///  ed eventualmente scollega i documenti non più collegabili
		/// </summary>
		void GestioneFasePerDocumentoCollegato() {
			tipocont oldcont = ContabilizzazioneSelezionata();
			//disabilita gli eventi collegati al cmbTipoContabilizzazione
			DisabilitaEventiTipoDocumento = true;
			cmbTipoContabilizzazione.Items.Clear();
			CalcolaContabilizzazioniPossibili();
			if (ContabilizzazioneAttivabile(oldcont)) {
				SetContabilizzazione(oldcont);
				VisualizzaControlliContabilizzazione(oldcont);
				DisabilitaEventiTipoDocumento = false;
				cmbTipoContabilizzazione.Enabled = (!Meta.EditMode);
				return;
			}

			DisabilitaEventiTipoDocumento = false;
			cmbTipoContabilizzazione.Enabled = (!Meta.EditMode);
			SetContabilizzazione(tipocont.cont_none);
			AttivaContabilizzazione(tipocont.cont_none);
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
			//    "incomeyear.idupb?"+
			//    tablevista+	".idupb";
			SubEntity_txtImportoMovimento.Tag =
				"incomeyear.amount?" +
				tablevista + ".ayearstartamount";
			txtImportoCorrente.Tag = "incometotal.curramount?" + tablevista + ".curramount";
			txtImportoDisponibile.Tag = "incometotal.available?" + tablevista + ".available";

		}


		/// <summary>
		/// Visualizza/Nasconde i controlli relativi alla contabilizzazione scelta, 
		///  (inclusi btn, txtCredDeb, etc. ) impostandone anche i tag. 
		/// </summary>
		/// <param name="codecont"></param>
		void VisualizzaControlliContabilizzazione(tipocont codecont) {
			txtEsercDoc.ReadOnly = Meta.EditMode;
			txtNumDoc.ReadOnly = Meta.EditMode;
			btnDocumento.Enabled = !Meta.EditMode;
			cmbTipoDocumento.Enabled = !Meta.EditMode;

			switch (codecont) {
				case tipocont.cont_estimate:
					cmbCausale.Visible = true;
					labelCausale.Visible = true;
					gboxDocumento.Visible = true;

					labelTipoDocumento.Visible = true;
					cmbTipoDocumento.Visible = true;
					btnDocumento.Text = "Contratto Attivo";
					txtEsercDoc.Tag =
						"incomeestimate.yestim?" +
						"incomeestimateview.yestim";
					txtNumDoc.Tag =
						"incomeestimate.nestim?" +
						"incomeestimateview.nestim";
					cmbTipoDocumento.Tag =
						"incomeestimate.idestimkind?" +
						"incomeestimateview.idestimkind";
					AbilitaDisabilitaControlliContratto(true);
					ImpostaComboEstimateKind();
					if (Meta.IsEmpty) {
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.incomeestimate.Rows.Count == 0);
					}

					gboxDettEstimate.Visible = true;

					break;

				case tipocont.cont_iva:
					cmbCausale.Visible = true;
					labelCausale.Visible = true;
					gboxDocumento.Visible = true;

					labelTipoDocumento.Visible = true;
					cmbTipoDocumento.Visible = true;
					btnDocumento.Text = "Documento";
					txtEsercDoc.Tag =
						"incomeinvoice.yinv?" +
						"incomeinvoiceview.yinv";
					txtNumDoc.Tag =
						"incomeinvoice.ninv?" +
						"incomeinvoiceview.ninv";
					cmbTipoDocumento.Tag =
						"incomeinvoice.idinvkind?" +
						"incomeinvoiceview.idinvkind";
					AbilitaDisabilitaControlliFattura(true);
					ImpostaComboInvoiceKind();
					if (Meta.IsEmpty) {
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.incomeinvoice.Rows.Count == 0);
					}

					gboxDettInvoice.Visible = true;
					SubEntity_txtImportoMovimento.ReadOnly = true;
					break;
				case tipocont.cont_none:
					cmbTipoDocumento.Tag = null;
					txtEsercDoc.Tag = null;
					txtNumDoc.Tag = null;
					gboxDettInvoice.Visible = false;
					gboxDettEstimate.Visible = false;
					NascondiControlliContabilizzazione();
					SubEntity_txtImportoMovimento.ReadOnly = EsisteEsercPrecedente();
					break;
			}

			//ClearComboCausale();
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

		void ImpostaComboEstimateKind() {
			if (cmbTipoDocumento.DataSource != null) {
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idestimkind"] != null) return;
			}

			TipoDocChangePilotato = true;
			cmbTipoDocumento.DataSource = DS.estimatekind;
			cmbTipoDocumento.DisplayMember = "description";
			cmbTipoDocumento.ValueMember = "idestimkind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento, null);
			TipoDocChangePilotato = false;
		}


		void NascondiControlliContabilizzazione() {
			cmbCausale.Visible = false;
			labelCausale.Visible = false;
			gboxDocumento.Visible = false;
		}

		public enum tipocont {
			cont_none,
			cont_iva,
			cont_estimate
		};

		//public tipocont currcont;

		string NomeContabilizzazione(tipocont TIPO) {
			switch (TIPO) {
				case tipocont.cont_iva: return "Documento Iva";
				case tipocont.cont_estimate: return "Contratto Attivo";
				case tipocont.cont_none: return "";
			}

			return null;
		}

		tipocont CodiceContabilizzazione(string nomecont) {
			switch (nomecont) {
				case "Documento Iva": return tipocont.cont_iva;
				case "Contratto Attivo": return tipocont.cont_estimate;
				case "": return tipocont.cont_none;
			}

			return tipocont.cont_none;
		}

		/// <summary>
		/// Stabilisce se è possibile con la fase corrente contabilizzare un
		///  certo tipo di documento
		/// </summary>
		/// <returns></returns>
		bool ContabilizzazioneAttivabile(tipocont codecont) {
			switch (codecont) {
				case tipocont.cont_iva:
					if (faseIvaInclusa()) return true;
					return false;
				case tipocont.cont_estimate:
					if ((faseentratamax == 1) &&(Meta.InsertMode)) return false;
					if (faseEntrataInclusa()) return true;
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
			foreach (tipocont codecont in new tipocont[] {tipocont.cont_estimate, tipocont.cont_iva}) {
				if (ContabilizzazioneAttivabile(codecont))
					cmbTipoContabilizzazione.Items.Add(
						NomeContabilizzazione(codecont));
			}
		}

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
			foreach (tipocont disattivacont in new tipocont[] {tipocont.cont_iva, tipocont.cont_estimate}) {
				DisattivaContabilizzazione(disattivacont);
			}

			txtEsercDoc.Text = "";
			txtNumDoc.Text = "";
			switch (codecont) {
				case tipocont.cont_iva:
					CambiaTagControlliComuni("incomeinvoiceview");
					Meta.DefaultListType = "iva";
					break;
				case tipocont.cont_estimate:
					CambiaTagControlliComuni("incomeestimateview");
					Meta.DefaultListType = "estimate";
					break;
				case tipocont.cont_none:
					CambiaTagControlliComuni("incomeview");
					Meta.DefaultListType = "default";
					break;
			}

			VisualizzaControlliContabilizzazione(codecont);
			ClearComboCausale();
		}

		void DisattivaContabilizzazione(tipocont codecont) {
			if (!Meta.InsertMode) return;
			switch (codecont) {
				case tipocont.cont_iva:
					if (faseIvaInclusa()) ScollegaIva();
					return;
				case tipocont.cont_estimate:
					if (faseContrattoInclusa()) ScollegaEstimate();
					return;
			}

		}

		void GetDocIva(out DataRow IvaRow,
			out DataRow CurrIvaMovEntrataRow,
			//out DataTable IvaMovEntrataView, 
			out int CurrCausaleIva) {
			CurrCausaleIva = 0;
			DataRow MiddleRow;
			IvaRow = GetDocRow("invoice", "incomeinvoice", faseiva, out MiddleRow);
			CurrIvaMovEntrataRow = MiddleRow;
			//IvaMovEntrataView=null;
			if (IvaRow == null) return;
			if (MiddleRow != null) CurrCausaleIva = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
			//string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(IvaRow,
			//    DataRowVersion.Default,
			//    true);
			//IvaMovEntrataView = MyConn.RUN_SELECT("incomeinvoiceview","*",null,keyfilter,null,true);
		}


		void GetDocEstimate(out DataRow EstimateRow,
			out DataRow CurrEstimateMovEntrataRow,
			//out DataTable EstimateMovEntrataView, 
			out int CurrCausaleEstimate) {
			CurrCausaleEstimate = 0;
			DataRow MiddleRow;
			EstimateRow = GetDocRow("estimate", "incomeestimate", faseentrata, out MiddleRow);
			CurrEstimateMovEntrataRow = MiddleRow;
			//EstimateMovEntrataView=null;
			if (EstimateRow == null) return;
			if (MiddleRow != null) CurrCausaleEstimate = CfgFn.GetNoNullInt32(MiddleRow["movkind"]);
			//string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(EstimateRow,
			//    DataRowVersion.Default,
			//    true);
			//EstimateMovEntrataView = MyConn.RUN_SELECT("incomeestimateview","*",null,keyfilter,null,true);
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
			string movimentotable = "income";
			if (currphase == faseattivazione) {
				//Se la fase attivazione è inclusa nel range, è possibile che 
				// il documento sia stato selezionato e sia in memoria, oppure che non 
				// sia stato selezionato il documento e quindi non ci sono righe
				if (DS.Tables[tablename].Rows.Count == 0) return null;
				CurrMiddleDocRow = DS.Tables[middletablename].Rows[0];
				return DS.Tables[tablename].Rows[0];
			}
			else {
				//Se la fase attivazione è successiva al range, non può esistere alcun 
				// documento collegato
				if (currphase <= faseattivazione) return null;

				//L'unico caso rimasto è che la faseattivazione è precedente al range

				//Se è stato selezionato un livsupid, è possibile partire da quello come
				// base per selezionare il giusto movimento di fase precedente.
				DataRow Curr = DS.income.Rows[0];
				object livsupid = Curr["parentid" + movimentotable.Substring(0, 3)];
				if (livsupid == DBNull.Value) return null; //non è stato ancora selezionato
				object idattivazione = MyConn.DO_READ_VALUE(movimentotable + "link",
					QHS.AppAnd(QHS.CmpEq("idchild", livsupid),
						QHS.CmpEq("nlevel", faseattivazione)), "idparent");
				if (idattivazione == null) return null;
				if (idattivazione == DBNull.Value) return null;
				DataTable Middle = MyConn.RUN_SELECT(middletablename, "*", null,
					"(id" + movimentotable.Substring(0, 3) + "=" + QueryCreator.quotedstrvalue(idattivazione, true) +
					")",
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
				filtertipodoc = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2));
			}
			else {
				filtertipodoc = "(idinvkind=" +
				                QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue, true) + ")";
			}

			FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

			if (Meta.InsertMode) {
				FilterIva += "AND(residual>'0')AND((active is null)OR(active='S'))";
			}

			//eventualmente appende al filtro sull'ordine un filtro sul creditore.
			//Questo accade se la fase creditore è precedente a quella della missione e la
			// fase creditore è precedente alla prima fase selezionata ed il 
			// movimento relativo alla fase precedente è stato selezionato
//			int fasecreditore = ManageCreditore.faseattivazione;
//			bool fasecredcond = (fasecreditore<currphase) && (fasecreditore<faseiva);
//			if (Meta.IsEmpty) return FilterIva;
//			DataRow Curr = DS.entrata.Rows[0];
//			bool faseprecselected = (Curr["livsupidentrata"]!=DBNull.Value);
//			if (fasecredcond && faseprecselected){
//				FilterIva = GetData.MergeFilters(FilterIva,
//					"(codicecreddeb="+QueryCreator.quotedstrvalue(
//					Curr["codicecreddeb"],true)+")");
//			}
//
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
				DataRow Curr = DS.income.Rows[0];
				bool faseprecselected = (Curr["parentidinc"] != DBNull.Value);
				//int lenidaccertamento=fasecontratto*8;
				//string parid=Curr["parentidinc"].ToString();
				//if (faseprecselected){
				//    DataTable EstimateCont= Conn.RUN_SELECT("incomeestimate","*",null,
				//        "('"+parid+"' LIKE idinc+'%')",null,null,false);
				//    if (EstimateCont.Rows.Count>0){
				//        MyFilterDocumentoIva=GetData.MergeFilters(MyFilterDocumentoIva,
				//            "('"+parid+"' LIKE idinc_ivaestim+'%' or '"+parid+"' LIKE idinc_taxableestim+'%')");
				//    }
				//    else {
				//        MyFilterDocumentoIva=GetData.MergeFilters(MyFilterDocumentoIva,
				//            "(idinc_ivaestim is null and idinc_taxableestim is null)");
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
				bool condfasecred = (fasecred < currphase);
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
				MDocumentoIva = MetaData.GetMetaData(this, "invoiceincomelinked");
				MDocumentoIva.FilterLocked = true;
				MDocumentoIva.DS = DS.Clone();
				MyDRIva = MDocumentoIva.SelectOne("default", MyFilterDocumentoIva, null, null);
				if (MyDRIva == null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
						return;
					}

					return;
				}

				TipoDocChangePilotato = true;
				HelpForm.SetComboBoxValue(cmbTipoDocumento, MyDRIva["idinvkind"].ToString());
				TipoDocChangePilotato = false;
				txtEsercDoc.Text = MyDRIva["yinv"].ToString();
				txtNumDoc.Text = MyDRIva["ninv"].ToString();
				return;
			}

			//MDocumentoIva = MetaData.GetMetaData(this,"invoiceavailable");
			MDocumentoIva = MetaData.GetMetaData(this, "invoiceresidualestimate");
			MDocumentoIva.FilterLocked = true;
			MDocumentoIva.DS = DS.Clone();

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

			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];
			if (Meta.InsertMode) {
				while (true) { //escamotage per impedire che il livello di indentazione arrivi alle stelle
					//Si collega all'impegno ove presente
					object idinc_taxableestim = MyDRIva["idinc_taxableestim"];
					object idinc_ivaestim = MyDRIva["idinc_ivaestim"];
					if (idinc_taxableestim == DBNull.Value && idinc_ivaestim == DBNull.Value) break;
					DataRow Curr = DS.income.Rows[0];
					bool faseprecselected = (Curr["parentidinc"] != DBNull.Value);
					if (faseprecselected) break;
					int precphase = currphase - 1;
					if (precphase <= 0) break;
					//int preclen = precphase*8;
					string filterprec = "(nphase='" + precphase + "')" +
					                    GetFilterIdIncEstim(idinc_ivaestim, idinc_taxableestim)
					                    + "and(available>'0')";

					MetaData MFase = MetaData.GetMetaData(this, "incomeview");
					MFase.FilterLocked = true;
					MFase.DS = DS;

					int NEXP = Meta.Conn.RUN_SELECT_COUNT("incomeview", filterprec, false);
					if (NEXP == 0) {
						show(
							"Non è stato trovato un movimento di entrata a cui agganciare questo incasso," +
							" ai fini di una corretta associazione contratto attivo - fattura.");
						break;
					}

					DataRow MyDR2 = null;

					while (MyDR2 == null) {
						if (NEXP > 1)
							show(
								"E' ora necessario scegliere il mov. di entrata a cui agganciare questo incasso," +
								" ai fini di una corretta associazione contratto attivo - fattura.");
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

		string GetFilterIdIncEstim(object idinc1, object idinc2) {
			string result = "";
			if (idinc1 != DBNull.Value) {
				//result="idinc like '"+idinc1+"%' ";
				result = "(idinc in (select idchild from incomelink where idparent=" +
				         QueryCreator.quotedstrvalue(idinc1, true) + "))";
			}

			if (idinc2 != DBNull.Value) {
				if (result != "") result += " or ";
				//result += "idinc like '" + idinc2 + "%' ";
				result += "(idinc in (select idchild from incomelink where idparent=" +
				          QueryCreator.quotedstrvalue(idinc2, true) + "))";
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
				if (Meta.InsertMode) ScollegaIva();
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
			SetResponsabile(DBNull.Value);
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex = -1;
			AbilitaDisabilitaCreditoreDebitore(true);
		}

		/*void AbilitaDisabilitaControlliIva(bool abilita){
			AbilitaDisabilitaCreditoreDebitore(abilita);
			//txtCredDeb.ReadOnly=!abilita;
		}*/

		void VisualizzaMainInfo_Iva(DataRow Iva2) {

			if (!faseIvaInclusa()) return;
			gboxDettInvoice.Visible = true;
			cmbTipoDocumento.Tag =
				"incomeinvoice.idinvkind?" +
				"incomeinvoiceview.idinvkind";

			txtNumDoc.Text = Iva2["ninv"].ToString();
			txtEsercDoc.Text = Iva2["yinv"].ToString();
			ImpostaComboInvoiceKind();
			TipoDocChangePilotato = true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,
				Iva2["idinvkind"]);
			TipoDocChangePilotato = false;
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaIva(DataRow Iva2, DataRow IvaResiduo) {
			if (Meta.IsEmpty) return;
			if (!faseIvaInclusa()) return;
			//Meta.GetFormData(true);
			//AzzeraPadre();
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

			DataRow CurrRow = DS.income.Rows[0];
			DataRow CurrImpRow = DS.incomeyear.Rows[0];
			MetaData MovIva = MetaData.GetMetaData(this, "incomeinvoice");
			MovIva.SetDefaults(DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue = ValoriDocumentoIva["idinvkind"];
			DS.incomeinvoice.Columns["ninv"].DefaultValue = ValoriDocumentoIva["ninv"];
			DS.incomeinvoice.Columns["yinv"].DefaultValue = ValoriDocumentoIva["yinv"];
			txtNumDoc.Text = ValoriDocumentoIva["ninv"].ToString();
			txtEsercDoc.Text = ValoriDocumentoIva["yinv"].ToString();
			TipoDocChangePilotato = true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento, ValoriDocumentoIva["idinvkind"].ToString());
			TipoDocChangePilotato = false;

			DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
			DS.incomeinvoice.Columns["ninv"].DefaultValue = DBNull.Value;
			DS.incomeinvoice.Columns["yinv"].DefaultValue = DBNull.Value;

			CurrRow["idreg"] = ValoriDocumentoIva["idreg"];
			CurrRow["description"] = ValoriDocumentoIva["description"];
			txtDescrizione.Text = ValoriDocumentoIva["description"].ToString();

			//			CurrRow["documento"] = "Doc."+
			//				ValoriDocumentoIva["esercdocumento"].ToString().Substring(2,2)+"/"+
			//				ValoriDocumentoIva["numdocumento"].ToString().PadLeft(6,'0');
			//			//"Ord."+ValoriOrdine["documento"];
			//			txtDocumento.Text = CurrRow["documento"].ToString();
			//			CurrRow["datadocumento"] = ValoriDocumentoIva["datacontabile"];
			//			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["datacontabile"], txtDataDocumento.Tag.ToString());


			CurrRow["doc"] = "Doc." + ValoriDocumentoIva["doc"];
			txtDocumento.Text = "Doc." + ValoriDocumentoIva["doc"];
			CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
			txtDataDocumento.Text =
				HelpForm.StringValue(ValoriDocumentoIva["docdate"], txtDataDocumento.Tag.ToString());

			//CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

			if (DS.registry.Rows.Count > 0) {
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != ValoriDocumentoIva["idreg"].ToString()) {
					DS.registry.Clear();
					//DS.modpagamentocreddebi.Clear();
				}
			}

			if (DS.registry.Rows.Count == 0) {
				LeggiDatiSuCredDeb(CurrRow["idreg"]);
				//CalcolaValoriDefaultModPagamento(CurrRow["codicecreddeb"].ToString());
			}

			if (DS.registry.Rows.Count > 0) {
				DataRow CredDeb = DS.registry.Rows[0];
				//SetComboCreditoreDebitore(CredDeb);
				txtCredDeb.Text = CredDeb["title"].ToString();
				ImpostaModalitaRiscossione(CredDeb, true);
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
			//AbilitaDisabilitaControlliFattura(false);
			AbilitaDisabilitaCreditoreDebitore(false);

		}

		object LeggiDaCombo(ComboBox C) {
			if ((C.SelectedValue == null) || (C.SelectedIndex <= 0)) {
				return DBNull.Value;
			}
			else {
				return C.SelectedValue;
			}
		}

		void ResetDocumentiFasiNonIncluse() {

			if (!faseContrattoInclusa()) {
				ResetEstimate();
			}

			if (!faseIvaInclusa()) {
				ResetIva();
			}
		}

		void LeggiDatiSuCredDeb(object codicecreddeb) {
			if (codicecreddeb == DBNull.Value) return;
			QueryCreator.MyClear(DS.registry);
			string filter = QHS.CmpEq("idreg", codicecreddeb);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filter, null, true);
		}

		void ScollegaIva() {
			gboxDettInvoice.Visible = false;
			if (DS.incomeinvoice.Rows.Count == 0) return;
			DS.incomeinvoice.Clear();
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			DataRow CurrRow = DS.income.Rows[0];
			DataRow CurrImpRow = DS.incomeyear.Rows[0];
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
			ClearControlliIva(false);
		}

		string CalculateFilterForInvoiceDetailLinking(bool SQL) {
			QueryHelper qh = SQL ? QHS : QHC;
			string MyFilter = "";
			string filter_insideA = "";
			string filter_insideB = "";


			object idreg = DS.income.Rows[0]["idreg"];
			object idupb = GetUpb();

			MyFilter = qh.AppAnd(MyFilter, qh.MCmp(IvaLinked, "idinvkind", "yinv", "ninv"));

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
				DataRow Curr = DS.income.Rows[0];
				filterparent = (Curr["parentidinc"] != DBNull.Value);
				if (filterparent) parid = Curr["parentidinc"].ToString();
			}

			if (CurrCausaleIva == 1) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));

				if (filterparent) {
					filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_taxableestim"));
					filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_ivaestim"));
					filter_insideB = qh.CmpEq("idinc_ivaestim", qh.Field("idinc_taxableestim"));
					DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null,
						QHS.CmpEq("idchild", parid), null, true);
					string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");

					MyFilter = qh.AppAnd(MyFilter,
						qh.DoPar(qh.AppOr(filter_insideA,
							qh.AppAnd(filter_insideB, qh.FieldInList("idinc_taxableestim", lista)))));
				}
			}

			if (CurrCausaleIva == 2) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
				if (filterparent) {
					filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_ivaestim"));
					DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null,
						QHS.CmpEq("idchild", parid), null, true);
					string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");
					MyFilter = qh.AppAnd(MyFilter,
						qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idinc_ivaestim", lista))));
				}
			}

			if (CurrCausaleIva == 3) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));
				if (filterparent) {
					filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_taxableestim"));
					DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null,
						QHS.CmpEq("idchild", parid), null, true);
					string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");
					MyFilter = qh.AppAnd(MyFilter,
						qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idinc_taxableestim", lista))));
				}
			}

			MyFilter = qh.AppAnd(MyFilter, qh.BitClear("flag", 2));

			return MyFilter;
		}


		private void btnCollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count == 0) return;

			if (MetaData.Empty(this)) return;
			if (IvaLinked == null) {
				show("E' necessario selezionare prima la fattura");
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

			string command = "choose." + tablename + ".listaentrata." + MyFilter;
			if (!MetaData.Choose(this, command)) return;
			if (CurrCausaleIva == 1) {
				foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
				}

				;
			}

			CalcolaImportoInBaseADettagliFattura();
		}


		private void btnModificaDettInvoice_Click(object sender, System.EventArgs e) {

			if (Meta.IsEmpty) return;
			if (IvaLinked == null) {
				show("E' necessario selezionare prima la fattura");
				return;
			}

			Meta.GetFormData(true);
			DataTable ToLink = null;
			if (CurrCausaleIva == 1 || CurrCausaleIva == 3) {
				ToLink = DS.invoicedetail_taxable;
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "incomeinvoicedetail_taxable");
			}

			if (CurrCausaleIva == 2) {
				ToLink = DS.invoicedetail_iva;
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "incomeinvoicedetail_iva");
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
				ToLink, MyFilter, MyFilterSQL, "listaentrata");
			if (CurrCausaleIva == 1) {
				foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
				}

				;
			}

			CalcolaImportoInBaseADettagliFattura();
		}

		private void btnScollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (IvaLinked == null) {
				show("E' necessario selezionare prima la fattura");
				return;
			}

			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrDettagliFattura);
			if (CurrCausaleIva == 1) {
				foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
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
				ToConsider = DS.invoicedetail_taxable.Select("idinc_taxable is not null");
			}

			if (CurrCausaleIva == 2) {
				ToConsider = DS.invoicedetail_iva.Select("idinc_iva is not null");
			}

			if (CurrCausaleIva == 1) {
				ToConsider = DS.invoicedetail_taxable.Select("idinc_taxable is not null");
			}

			foreach (DataRow R in ToConsider) {
				if (R.RowState == DataRowState.Deleted) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				//decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
				decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]), 6);
				imponibile += CfgFn.RoundValuta((R_imponibile * R_quantita * (1 - R_sconto)) * tassocambio);
				//imposta    +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*R_imposta*tassocambio);
				imposta += CfgFn.RoundValuta(R_imposta * tassocambio);
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
			object idinc = DS.income.Rows[0]["idinc"];
			if (CurrCausaleIva == 1) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable, null, filter, null, true);
				foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_taxable"] = idinc;
					R["idinc_iva"] = idinc;
				}

				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "incomeinvoicedetail_taxable");
			}

			if (CurrCausaleIva == 3) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable, null, filter, null, true);
				foreach (DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_taxable"] = idinc;
				}

				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "incomeinvoicedetail_taxable");
			}

			if (CurrCausaleIva == 2) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva, null, filter, null, true);
				foreach (DataRow R in DS.invoicedetail_iva.Rows) {
					R["idinc_iva"] = idinc;
				}

				GetData.CalculateTable(DS.invoicedetail_iva);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "incomeinvoicedetail_iva");
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
			object currtipo = DS.Tables["incomeinvoice"].Rows[0]["movkind"];
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
				DataRow Curr = DS.income.Rows[0];
				parid = Curr["parentidinc"];

			}

			bool EnableImpon = true;
			bool EnableImpos = true;
			bool EnableDocum = true;

			DataRow R = Iva;
			totimponibile_dociva = CfgFn.GetNoNullDecimal(R["taxabletotal"]);
			totiva_dociva = CfgFn.GetNoNullDecimal(R["ivatotal"]);
			totimponibile_dociva = CfgFn.GetNoNullDecimal(R["taxabletotal"]);
			totiva_dociva = CfgFn.GetNoNullDecimal(R["ivatotal"]);

			MyFilter_taxable = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idinc_taxableestim"]));
			MyFilter_iva = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idinc_ivaestim"]));

			EnableImpon = (R["idinc_taxableestim"] == DBNull.Value ||
			               (parid != DBNull.Value &&
			                Conn.RUN_SELECT_COUNT("incomelink", MyFilter_taxable, false) > 0) ||
			               R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]));

			EnableImpos = (R["idinc_ivaestim"] == DBNull.Value ||
			               (parid != DBNull.Value && Conn.RUN_SELECT_COUNT("incomelink", MyFilter_iva, false) > 0) ||
			               R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]));

			EnableDocum = R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]);

			assigned_imponibile_dociva = CfgFn.GetNoNullDecimal(R["linkedimpon"]);
			assigned_iva_dociva = CfgFn.GetNoNullDecimal(R["linkedimpos"]);
			assigned_gen_dociva = CfgFn.GetNoNullDecimal(R["linkeddocum"]);
			//bool intracom = false;//Per i C.A. e Fatture intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524

			string filteriva = QHS.AppAnd(QHS.CmpEq("idinvkind", Iva["idinvkind"]),
				QHS.CmpEq("yinv", Iva["yinv"]), QHS.CmpEq("ninv", Iva["ninv"]));
			string filter_idupbivaset = QHS.AppAnd(filteriva, QHS.IsNotNull("idupb_iva"));
			int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

			decimal all_assigned_imponibile_dociva = 0;
			decimal all_assigned_iva_dociva = 0;
			decimal all_assigned_gen_dociva = 0;
			DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filteriva, null, true);
			if ((T != null) && (T.Rows.Count > 0)) {
				foreach (DataRow Dett in T.Rows) {
					all_assigned_imponibile_dociva += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
					all_assigned_iva_dociva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
					all_assigned_gen_dociva += CfgFn.GetNoNullDecimal(Dett["linkeddocum"]);
					//if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
				}
			}

			//if (intracom) {
			//    EnableDocum = false;
			//    EnableImpos = false;
			//}
			if (n_idupbivaset > 0) {
				EnableDocum = false;
			}

			ClearComboCausale();
			DataTable TCombo = DS.tipomovimento;

			if ((Meta.EditMode) ||
			    (EnableDocum &&
			     (all_assigned_imponibile_dociva + all_assigned_iva_dociva) == 0) &&
			    (assigned_gen_dociva < (totimponibile_dociva + totiva_dociva))
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

			DS.incomeinvoice.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
				? cmbCausale.SelectedValue
				: DBNull.Value;
			cmbCausale.Enabled = !(Meta.EditMode);
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
				if (Meta.EditMode) DS.invoicedetail_taxable.Clear();
			}


		}

		void ReCalcImporto_Iva() {
			if (Meta.IsEmpty) return;
			if (EsisteEsercPrecedente()) return;
			DataRow Curr = DS.Tables["income"].Rows[0];
			if ((currphase > 1) && (Curr["parentidinc"] == DBNull.Value)) return;
			if (cmbCausale.SelectedValue == null) return;

			//string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo = GetImportoDettagliFattura();
			/*if (tipomovimento==2){
				importo= totiva_dociva-assigned_iva_dociva;
			}
			if (tipomovimento==3){
				importo= totimponibile_dociva-assigned_imponibile_dociva;
			}
			if (tipomovimento==1){
				importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
			}*/

			if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
				show(
					"Sarà effettuata una contabilizzazione di importo inferiore poiché la " +
					"disponibilità del movimento selezionato è inferiore a " + importo.ToString());
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
			if (DS.incomeinvoice.Rows.Count == 0) return 0;
			if (!Meta.DrawStateIsDone) {
				if (DS.incomeinvoice.Rows[0]["movkind"] != DBNull.Value)
					CurrCausaleIva = CfgFn.GetNoNullInt32(DS.incomeinvoice.Rows[0]["movkind"]);
				else
					CurrCausaleIva = 0;
				return CurrCausaleIva;
			}

			if (cmbCausale.SelectedValue != null)
				DS.incomeinvoice.Rows[0]["movkind"] = cmbCausale.SelectedValue;
			else
				DS.incomeinvoice.Rows[0]["movkind"] = DBNull.Value;
			CurrCausaleIva = CfgFn.GetNoNullInt32(DS.incomeinvoice.Rows[0]["movkind"]);
			return CurrCausaleIva;
			//ReCalcImporto();
		}


		void UpdateComboCausaleIva() {
			if (IvaMovEntrataLinked != null) {
				object currtipo = IvaMovEntrataLinked["movkind"];
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}


		bool TipoDocChangePilotato = false;

		private void cmbTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato = true;
			ClearControlliIva(true);
			txtEsercDoc.Text = "";
			txtNumDoc.Text = "";
			TipoDocChangePilotato = false;
		}

		#endregion



		#region Gestione Selezione Contratto Attivo

		string FilterEstimate;

		private void txtEsercEstimate_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtEsercDoc.ReadOnly) return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);
			//CalcolaStartFilter(null);
		}

		string GetFilterEstimate(bool FiltraNum) {
			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			FilterEstimate = "(yestim<='" + esercizio.ToString() + "')";
			if (txtEsercDoc.Text != "") {
				int esercdocumento = CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercdocumento <= esercizio)
						FilterEstimate = "(yestim='" + esercdocumento.ToString() + "')";
					else
						FilterEstimate = GetData.MergeFilters(FilterIva,
							"(yestim='" + esercdocumento.ToString() + "')");
				}
				catch {
				}
			}

			if (FiltraNum) {
				int numdocumento = CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if (txtNumDoc.Text != "") {
					FilterEstimate = GetData.MergeFilters(FilterEstimate,
						"(nestim='" + numdocumento.ToString() + "')");
				}
			}

			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex <= 0) {
				filtertipodoc = "";
			}
			else {
				filtertipodoc = "(idestimkind=" +
				                QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue, true) + ")";
			}

			FilterEstimate = GetData.MergeFilters(FilterEstimate, filtertipodoc);

			if (Meta.InsertMode) {
				FilterEstimate += "AND(residual>'0')AND((active is null)OR(active='S'))";
			}

			//eventualmente appende al filtro sull'ordine un filtro sul creditore.
			//Questo accade se la fase creditore è precedente a quella della missione e la
			// fase creditore è precedente alla prima fase selezionata ed il 
			// movimento relativo alla fase precedente è stato selezionato
			//			int fasecreditore = ManageCreditore.faseattivazione;
			//			bool fasecredcond = (fasecreditore<currphase) && (fasecreditore<faseiva);
			//			if (Meta.IsEmpty) return FilterIva;
			//			DataRow Curr = DS.entrata.Rows[0];
			//			bool faseprecselected = (Curr["livsupidentrata"]!=DBNull.Value);
			//			if (fasecredcond && faseprecselected){
			//				FilterIva = GetData.MergeFilters(FilterIva,
			//					"(codicecreddeb="+QueryCreator.quotedstrvalue(
			//					Curr["codicecreddeb"],true)+")");
			//			}
			//
			return FilterEstimate;
		}


		private void btnEstimate_Click(object sender, System.EventArgs e) {

			DataAccess Conn = MetaData.GetConnection(this);
			string MyEstimateFilter;
			string MyFilterEstimate;
			string MyFilterEstimateOperativo;
			if (((Control) sender).Name == "txtNumDoc")
				MyEstimateFilter = GetFilterEstimate(true);
			else
				MyEstimateFilter = GetFilterEstimate(false);

			MyFilterEstimate = MyEstimateFilter;
			MyFilterEstimateOperativo = MyEstimateFilter;

			if (Meta.InsertMode) {
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred < currphase);
				DataRow Curr = DS.income.Rows[0];
				bool faseprecselected = (Curr["parentidinc"] != DBNull.Value);
				if ((condfasecred && faseprecselected) ||
				    ((txtCredDeb.ReadOnly == false) && (txtCredDeb.Text.Trim() != ""))
				) {
					MyFilterEstimate = GetData.MergeFilters(MyFilterEstimate,
						"(idreg=" +
						QueryCreator.quotedstrvalue(Curr["idreg"], true) + ")");
					MyFilterEstimateOperativo = GetData.MergeFilters(MyFilterEstimateOperativo,
						"(registry=" +
						QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
				}

				bool condfaseupb = (ManageUPB.faseattivazione < currphase);
				object getupb = GetUpb();
				if ((condfaseupb && faseprecselected) ||
				    (getupb != DBNull.Value && txtUPB.Enabled)) {
					object idupb = getupb;
					MyFilterEstimateOperativo = QHS.AppAnd(MyFilterEstimateOperativo,
						QHS.DoPar(QHS.AppOr(QHS.IsNull("idupb"), QHS.CmpEq("idupb", idupb),
							QHS.CmpEq("idupb_iva", idupb))));
				}

				if (faseentratamax == 1) {
					MyFilterEstimateOperativo =
						QHS.AppAnd(MyFilterEstimateOperativo, QHS.CmpEq("linktoinvoice", "N"));
				}
			}

			if (Meta.IsEmpty) {
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred < currphase);
				bool faseprecselected = (txtCredDeb.Text.Trim() != "");
				if (condfasecred && faseprecselected) {
					MyFilterEstimateOperativo = GetData.MergeFilters(MyFilterEstimateOperativo,
						"(registry=" +
						QueryCreator.quotedstrvalue(txtCredDeb.Text, true) + ")");
				}
			}

			MetaData MEstimate;
			DataRow MyDREstimate;

			if (Meta.IsEmpty) {
				MEstimate = MetaData.GetMetaData(this, "estimatelinked");
				MEstimate.FilterLocked = true;
				MEstimate.DS = new DataSet(); //DS.Clone();
				MyDREstimate = MEstimate.SelectOne("default", MyFilterEstimate, null, null);
				if (MyDREstimate == null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
						return;
					}

					return;
				}

				TipoDocChangePilotato = true;
				HelpForm.SetComboBoxValue(cmbTipoDocumento, MyDREstimate["idestimkind"]);
				TipoDocChangePilotato = false;
				txtEsercDoc.Text = MyDREstimate["yestim"].ToString();
				txtNumDoc.Text = MyDREstimate["nestim"].ToString();
				return;
			}

			MEstimate = MetaData.GetMetaData(this, "estimateresidual");
			MEstimate.FilterLocked = true;
			MEstimate.DS = DS.Clone();

			MyDREstimate = MEstimate.SelectOne("default", MyFilterEstimateOperativo, null, null);

			if (MyDREstimate == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
					if (((TextBox) sender).Text.Trim() != "") ((TextBox) sender).Focus();
				}

				return;
			}

			string selectord = QHS.MCmp(MyDREstimate, "idestimkind", "yestim", "nestim");

			string columnlist = QueryCreator.ColumnNameList(DS.estimate) +
			                    ",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("estimateview", columnlist, null, selectord, null, null, true);

			//if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];


			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if (Meta.InsertMode) {
				ResetEstimate();
				CollegaContratto(MyDR, MyDREstimate);
				CollegaTuttiDettagliContratto();
				RintracciaEstimate();
				ResetTipoClassAvailableEvalued();
			}

			AbilitaDisabilitaControlliContratto(true);
		}




		private void txtNumEstimate_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly) return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;
			//CalcolaStartFilter(null);


			if (txtNumDoc.Text.Trim() == "") {
				if (Meta.InsertMode) ScollegaIva();
				ClearControlliEstimate(true);
				int fasecred = ManageCreditore.faseattivazione;
				if (fasecred < currphase) return;
				txtCredDeb.Text = "";
				return;
			}


			btnEstimate_Click(sender, e);
		}

		void ClearControlliEstimate(bool skipTipoDoc) {
			//txtCredDeb.Text = "";		
			txtDescrizione.Text = "";
			txtDocumento.Text = "";
			txtDataDocumento.Text = "";
			SetResponsabile(DBNull.Value);
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex = -1;
			AbilitaDisabilitaCreditoreDebitore(true);
		}


		void VisualizzaMainInfo_Estimate(DataRow Estimate2) {
			if (!faseContrattoInclusa()) return;
			gboxDettEstimate.Visible = true;
			cmbTipoDocumento.Tag =
				"incomeestimate.idestimkind?" +
				"incomeestimateview.idestimkind";
			ImpostaComboEstimateKind();
			TipoDocChangePilotato = true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,
				Estimate2["idestimkind"]);
			TipoDocChangePilotato = false;
			txtNumDoc.Text = Estimate2["nestim"].ToString();
			txtEsercDoc.Text = Estimate2["yestim"].ToString();
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaContratto(DataRow Estimate2, DataRow EstimateResiduo) {
			if (Meta.IsEmpty) return;
			if (!faseContrattoInclusa()) return;
			tipocont mycont = ContabilizzazioneSelezionata();
			if (mycont != tipocont.cont_estimate && mycont != tipocont.cont_none)
				return; //Non collega contratti se non in questi casi

			//Meta.GetFormData(true);
			//AzzeraPadre();
			Hashtable ValoriEstimate = new Hashtable();
			foreach (DataColumn C in Estimate2.Table.Columns)
				ValoriEstimate[C.ColumnName] = Estimate2[C.ColumnName];

			ScollegaEstimate();

			gboxDettEstimate.Visible = true;

			DataRow NewEstimateR = DS.estimate.NewRow();

			foreach (DataColumn C in DS.estimate.Columns) {
				NewEstimateR[C.ColumnName] = ValoriEstimate[C.ColumnName];
			}

			DS.estimate.Rows.Add(NewEstimateR);
			NewEstimateR.AcceptChanges();

			DataRow CurrRow = DS.income.Rows[0];
			DataRow CurrImpRow = DS.incomeyear.Rows[0];
			MetaData MovEstimate = MetaData.GetMetaData(this, "incomeestimate");
			MovEstimate.SetDefaults(DS.incomeestimate);
			DS.incomeestimate.Columns["idestimkind"].DefaultValue = ValoriEstimate["idestimkind"];
			DS.incomeestimate.Columns["nestim"].DefaultValue = ValoriEstimate["nestim"];
			DS.incomeestimate.Columns["yestim"].DefaultValue = ValoriEstimate["yestim"];
			txtNumDoc.Text = ValoriEstimate["nestim"].ToString();
			txtEsercDoc.Text = ValoriEstimate["yestim"].ToString();
			TipoDocChangePilotato = true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento, ValoriEstimate["idestimkind"]);
			TipoDocChangePilotato = false;

			DataRow RMovEstimate = MovEstimate.Get_New_Row(CurrRow, DS.incomeestimate);
			DS.incomeestimate.Columns["idestimkind"].DefaultValue = DBNull.Value;
			DS.incomeestimate.Columns["nestim"].DefaultValue = DBNull.Value;
			DS.incomeestimate.Columns["yestim"].DefaultValue = DBNull.Value;

			CurrRow["idreg"] = EstimateResiduo["idreg"];
			CurrRow["description"] = ValoriEstimate["description"];
			txtDescrizione.Text = ValoriEstimate["description"].ToString();

			//			CurrRow["documento"] = "Doc."+
			//				ValoriDocumentoIva["esercdocumento"].ToString().Substring(2,2)+"/"+
			//				ValoriDocumentoIva["numdocumento"].ToString().PadLeft(6,'0');
			//			//"Ord."+ValoriOrdine["documento"];
			//			txtDocumento.Text = CurrRow["documento"].ToString();
			//			CurrRow["datadocumento"] = ValoriDocumentoIva["datacontabile"];
			//			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["datacontabile"], txtDataDocumento.Tag.ToString());

			CurrRow["doc"] = "C.A." + ValoriEstimate["idestimkind"].ToString() + "/" +
			                 ValoriEstimate["yestim"].ToString().Substring(2, 2) + "/" +
			                 ValoriEstimate["nestim"].ToString().PadLeft(6, '0');
			//"Doc."+ValoriEstimate["doc"];
			txtDocumento.Text = CurrRow["doc"].ToString();

			txtDocumento.Text = "Doc." + ValoriEstimate["doc"];
			CurrRow["docdate"] = ValoriEstimate["docdate"];
			txtDataDocumento.Text = HelpForm.StringValue(ValoriEstimate["docdate"], txtDataDocumento.Tag.ToString());

			//CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

			if (DS.registry.Rows.Count > 0) {
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != CurrRow["idreg"].ToString()) {
					DS.registry.Clear();
					//DS.modpagamentocreddebi.Clear();
				}
			}

			if (DS.registry.Rows.Count == 0) {
				LeggiDatiSuCredDeb(CurrRow["idreg"]);
				//CalcolaValoriDefaultModPagamento(CurrRow["codicecreddeb"].ToString());
			}

			if (DS.registry.Rows.Count > 0) {
				DataRow CredDeb = DS.registry.Rows[0];
				//SetComboCreditoreDebitore(CredDeb);
				txtCredDeb.Text = CredDeb["title"].ToString();
			}

			if (EstimateResiduo["idupb"] != DBNull.Value && EstimateResiduo["idupb_iva"] == DBNull.Value) {
				SetUPB(EstimateResiduo["idupb"]);
			}
			else {
				CurrImpRow["idupb"] = GetUpb();
			}




			//Meta.myHelpForm.FillControls(tabMovFin.Controls);
			EstimateLinkedMustBeEvalued = true;
			RintracciaEstimate();
			SetComboCausaleEstimate(EstimateResiduo);
			//AbilitaDisabilitaControlliContratto(false);
			AbilitaDisabilitaCreditoreDebitore(false);
		}

		void ScollegaEstimate() {
			gboxDettEstimate.Visible = false;
			if (DS.incomeestimate.Rows.Count == 0) return;
			DS.incomeestimate.Clear();
			DS.estimatedetail_taxable.Clear();
			DS.estimatedetail_iva.Clear();
			DS.estimate.Clear();
			ClearComboCausale();
			DataRow CurrRow = DS.income.Rows[0];
			DataRow CurrImpRow = DS.incomeyear.Rows[0];
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
			ClearControlliEstimate(false);
		}

		#endregion

		#region Eventi Dettagli Contratto

		string CalculateFilterForEstimateDetailLinking(bool SQL) {
			QueryHelper qh = SQL ? QHS : QHC;
			string MyFilter = "";

			string idreg = DS.income.Rows[0]["idreg"].ToString();
			string idupb = DS.incomeyear.Rows[0]["idupb"].ToString();

			MyFilter = qh.AppAnd(MyFilter, qh.MCmp(EstimateLinked, "idestimkind", "yestim", "nestim"));

			DataRow TipoContratto = DS.estimatekind.Select(qh.CmpEq("idestimkind", EstimateLinked["idestimkind"]))[0];
			if (TipoContratto["multireg"].ToString().ToUpper() == "S") {
				if (idreg != "")
					MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", idreg));
			}

			if (idupb != "") {
				//MyFilter+=" AND (idupb is null or idupb = "+QueryCreator.quotedstrvalue(idupb,SQL)+")";           
				if (CurrCausaleEstimate == 1) {
					//totale, prende upb standard
					MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
				}

				if (CurrCausaleEstimate == 2) {
					//IVA
					MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("isnull(idupb_iva,idupb)", idupb));
				}

				if (CurrCausaleEstimate == 3) {
					//imponibile 
					MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
				}
			}

			if (CurrCausaleEstimate == 1) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"), qh.IsNull("idinc_taxable"));
			}

			if (CurrCausaleEstimate == 2) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
			}

			if (CurrCausaleEstimate == 3) {
				MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));
			}

			int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string filterstart = qh.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
			string filterstop = qh.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
			MyFilter = qh.AppAnd(MyFilter, filterstart, filterstop);
			return MyFilter;
		}


		private void btnCollegaDettContratto_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count == 0) return;

			if (MetaData.Empty(this)) return;
			if (EstimateLinked == null) {
				show("E' necessario selezionare prima il contratto attivo");
				return;
			}

			MetaData.GetFormData(this, true);
			CurrCausaleEstimate = GetCausaleContratto();
			string MyFilter = CalculateFilterForEstimateDetailLinking(true);
			string tablename = "";
			if (CurrCausaleEstimate == 1 || CurrCausaleEstimate == 3) {
				tablename = "estimatedetail_taxable";
			}

			if (CurrCausaleEstimate == 2) {
				tablename = "estimatedetail_iva";
			}

			if (tablename == "") {
				show("E' necessario selezionare prima una causale", "Avviso");
				return;
			}

			string command = "choose." + tablename + ".listaentrata." + MyFilter;
			if (!MetaData.Choose(this, command)) return;
			if (CurrCausaleEstimate == 1) {
				foreach (DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
				}
			}

			CalcolaImportoInBaseADettagliContratto();
		}


		private void btnModificaDettContratto_Click(object sender, System.EventArgs e) {

			if (Meta.IsEmpty) return;
			if (EstimateLinked == null) {
				show("E' necessario selezionare prima il contratto attivo");
				return;
			}

			Meta.GetFormData(true);
			DataTable ToLink = null;
			if (CurrCausaleEstimate == 1 || CurrCausaleEstimate == 3) {
				ToLink = DS.estimatedetail_taxable;
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable, "incomeestimatedetail_taxable");
			}

			if (CurrCausaleEstimate == 2) {
				ToLink = DS.estimatedetail_iva;
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva, "incomeestimatedetail_iva");
			}

			if (ToLink == null) {
				show("E' necessario selezionare prima la causale");
				return;
			}

			string MyFilter = CalculateFilterForEstimateDetailLinking(false);
			string MyFilterSQL = CalculateFilterForEstimateDetailLinking(true);
			Meta.MultipleLinkUnlinkRows("Selezione dettagli contratto",
				"Dettagli inclusi nel movimento corrente",
				"Dettagli non inclusi in alcun movimento",
				ToLink, MyFilter, MyFilterSQL, "listaentrata");
			if (CurrCausaleEstimate == 1) {
				foreach (DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
				}

				;
			}

			CalcolaImportoInBaseADettagliContratto();
		}

		private void btnScollegaDettContratto_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (EstimateLinked == null) {
				show("E' necessario selezionare prima il contratto attivo");
				return;
			}

			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrDettagliContratto);
			if (CurrCausaleEstimate == 1) {
				foreach (DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_iva"] = R["idinc_taxable"];
				}
			}

			CalcolaImportoInBaseADettagliContratto();
		}

		decimal GetImportoDettagliContratto() {
			if (DS.estimate.Rows.Count == 0)
				return 0;
			decimal tassocambio;
			DataRow Contratto = DS.estimate.Rows[0];
			tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
			if (tassocambio == 0) tassocambio = 1;
			decimal imponibile = 0;
			decimal imposta = 0;
			DataRow[] ToConsider = new DataRow[0];
			CurrCausaleEstimate = GetCausaleContratto();
			if (CurrCausaleEstimate == 3) {
				ToConsider = DS.estimatedetail_taxable.Select("idinc_taxable is not null");
			}

			if (CurrCausaleEstimate == 2) {
				ToConsider = DS.estimatedetail_iva.Select("idinc_iva is not null");
			}

			if (CurrCausaleEstimate == 1) {
				ToConsider = DS.estimatedetail_taxable.Select("idinc_taxable is not null");
			}

			foreach (DataRow R in ToConsider) {
				if (R.RowState == DataRowState.Deleted) continue;
				//if (R["stop"]!=DBNull.Value) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				//decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
				decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]), 6);
				imponibile += CfgFn.RoundValuta((R_imponibile * R_quantita * (1 - R_sconto)) * tassocambio);
				//imposta    +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*R_imposta*tassocambio);
				imposta += CfgFn.RoundValuta(R_imposta * tassocambio);
			}

			decimal totale = 0;

			if (CurrCausaleEstimate == 3) {
				totale = imponibile;
			}

			if (CurrCausaleEstimate == 2) {
				totale = imposta;
			}

			if (CurrCausaleEstimate == 1) {
				totale = imponibile + imposta;
			}

			return totale;

		}

		decimal GetImportoDettagliContrattoIncassati() {
			if (DS.incomelastestimatedetail.Rows.Count == 0) return 0;
			decimal imponibile = 0;

			foreach (DataRow R in DS.incomelastestimatedetail.Select()) {
				imponibile += CfgFn.GetNoNullDecimal(R["amount"]);
			}

			return imponibile;

		}

		void CalcolaImportoInBaseADettagliContratto() {
			if (Meta.IsEmpty) return;
			if (EsisteEsercPrecedente()) return;
			tipocont currcont = ContabilizzazioneSelezionata();
			if (currcont != tipocont.cont_estimate) return;
			CurrCausaleEstimate = GetCausaleContratto();
			decimal totale = GetImportoDettagliContratto();
			decimal variazioni = MetaData.SumColumn(DS.incomevar, "amount");
			SetImporto(totale - variazioni);
			CalcTotEstimateDetail();
		}

		void SvuotaDettagliContratto() {
			if (Meta.EditMode) return;
			if (EsisteEsercPrecedente()) return;
			DS.estimatedetail_taxable.Clear();
			DS.estimatedetail_iva.Clear();
			CalcTotEstimateDetail();

		}

		void CollegaTuttiDettagliContratto() {
			if (DS.estimate.Rows.Count == 0) return;
			CurrCausaleEstimate = GetCausaleContratto();
			string filter = CalculateFilterForEstimateDetailLinking(true);
			DS.estimatedetail_iva.Clear();
			DS.estimatedetail_taxable.Clear();
			string idinc = DS.income.Rows[0]["idinc"].ToString();
			if (CurrCausaleEstimate == 1) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_taxable, null, filter, null, true);
				foreach (DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_taxable"] = idinc;
					R["idinc_iva"] = idinc;
				}

				GetData.CalculateTable(DS.estimatedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable, "incomeestimatedetail_taxable");
			}

			if (CurrCausaleEstimate == 3) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_taxable, null, filter, null, true);
				foreach (DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_taxable"] = idinc;
				}

				GetData.CalculateTable(DS.estimatedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable, "incomeestimatedetail_taxable");
			}

			if (CurrCausaleEstimate == 2) {
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_iva, null, filter, null, true);
				foreach (DataRow R in DS.estimatedetail_iva.Rows) {
					R["idinc_iva"] = idinc;
				}

				GetData.CalculateTable(DS.estimatedetail_iva);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva, "incomeestimatedetail_iva");
			}

			CalcolaImportoInBaseADettagliContratto();



		}

		#endregion

		#region Gestione ComboBox Causale Contratto


		decimal totimponibile_estimate;
		decimal totiva_estimate;
		decimal assigned_imponibile_estimate;
		decimal assigned_iva_estimate;
		decimal assigned_gen_estimate;



		void SetEditComboCausaleEstimate() {
			if (!Meta.EditMode) return;
			ClearComboCausale();
			EnableTipoMovimento(1, "Contabilizzazione importo totale contratto");
			EnableTipoMovimento(3, "Contabilizzazione imponibile contratto");
			EnableTipoMovimento(2, "Contabilizzazione iva contratto");
			//cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
			object currtipo = DS.Tables["incomeestimate"].Rows[0]["movkind"];
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);
		}

		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleEstimate(DataRow Estimate) {
			if (!faseContrattoInclusa()) return;
			DataAccess Conn = Meta.Conn;
			totimponibile_estimate = CfgFn.GetNoNullDecimal(Estimate["taxabletotal"]);
			totiva_estimate = CfgFn.GetNoNullDecimal(Estimate["ivatotal"]);
			assigned_imponibile_estimate = CfgFn.GetNoNullDecimal(Estimate["linkedimpon"]);
			assigned_iva_estimate = CfgFn.GetNoNullDecimal(Estimate["linkedimpos"]);
			assigned_gen_estimate = CfgFn.GetNoNullDecimal(Estimate["linkedestim"]);

			string filterestim = QHS.AppAnd(QHS.CmpEq("idestimkind", Estimate["idestimkind"]),
				QHS.CmpEq("yestim", Estimate["yestim"]), QHS.CmpEq("nestim", Estimate["nestim"]));

			decimal all_assigned_imponibile = 0;
			decimal all_assigned_iva = 0;
			decimal all_assigned_gen = 0;
			//bool intracom = false;//Per i C.A. e Fatture intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524

			DataTable T = Conn.RUN_SELECT("estimateresidual", "*", null, filterestim, null, true);
			if ((T != null) && (T.Rows.Count > 0)) {
				foreach (DataRow Dett in T.Rows) {
					all_assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
					all_assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
					all_assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkedestim"]);
					//if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
				}
			}

			string filter_idupbivaset = QHS.AppAnd(filterestim, QHS.IsNotNull("idupb_iva"));
			int n_idupbivaset = Conn.RUN_SELECT_COUNT("estimatedetail", filter_idupbivaset, false);


			ClearComboCausale();
			DataTable TCombo = DS.tipomovimento;

			if ((Meta.EditMode) ||
			    ((all_assigned_imponibile + all_assigned_iva) == 0) &&
			    (assigned_gen_estimate < (totimponibile_estimate + totiva_estimate) /*&& !(intracom)*/) &&
			    (n_idupbivaset == 0)
			) {
				EnableTipoMovimento(1, "Contabilizzazione importo totale contratto");
			}

			if ((Meta.EditMode) ||
			    ((all_assigned_gen == 0) && (assigned_imponibile_estimate < totimponibile_estimate))
			) {
				EnableTipoMovimento(3, "Contabilizzazione imponibile contratto");
			}

			if ((Meta.EditMode) ||
			    ((all_assigned_gen == 0) && (assigned_iva_estimate < totiva_estimate) /*&& !(intracom)*/)
			) {
				EnableTipoMovimento(2, "Contabilizzazione iva contratto");
			}

			DS.incomeestimate.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
				? cmbCausale.SelectedValue
				: DBNull.Value;
			cmbCausale.Enabled = !(Meta.EditMode);
			ReCalcImporto_Estimate();

		}

		void AbilitaDisabilitaControlliContratto(bool abilita) {
			bool abilitagrid = abilita && faseContrattoInclusa();
			btnAddDetEstimate.Enabled = abilitagrid;
			btnRemoveDetEstimate.Enabled = abilitagrid;
			btnEditEstimDet.Enabled = abilitagrid;
			gboxDettEstimate.Visible = abilitagrid;
			CurrCausaleEstimate = GetCausaleContratto();
			if (CurrCausaleEstimate == 1 || CurrCausaleEstimate == 3) {
				dgrDettagliContratto.Tag = "estimatedetail_taxable.listaimpon";
				//dgrDettagliContratto.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliContratto, DS.estimatedetail_taxable);
				if (Meta.EditMode) DS.estimatedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
			}

			if (CurrCausaleEstimate == 2) {
				dgrDettagliContratto.Tag = "estimatedetail_iva.listaimpos";
				//dgrDettagliContratto.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliContratto, DS.estimatedetail_iva);
				if (Meta.EditMode)
					DS.estimatedetail_taxable.Clear(); //Importante per evitare problemi in fase di delete
			}
		}

		void ReCalcImporto_Estimate() {
			if (Meta.IsEmpty) return;
			if (EsisteEsercPrecedente()) return;
			DataRow Curr = DS.Tables["income"].Rows[0];
			if ((currphase > 1) && (Curr["parentidinc"] == DBNull.Value)) return;
			if (cmbCausale.SelectedValue == null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo = GetImportoDettagliContratto();
			/*if (tipomovimento==2){
				importo= totiva_estimate-assigned_iva_estimate;
			}
			if (tipomovimento==3){
				importo= totimponibile_estimate-assigned_imponibile_estimate;
			}
			if (tipomovimento==1){
				importo= totimponibile_estimate+totiva_estimate-assigned_gen_estimate;
			}*/

			if ((currphase > 1) && (importo > DisponibileDaFasePrecedente)) {
				show(
					"Sarà effettuata una contabilizzazione di importo inferiore poiché la " +
					"disponibilità del movimento selezionato è inferiore a " + importo.ToString());
				importo = DisponibileDaFasePrecedente;
			}

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;

			SetImporto(importo);
			SubEntity_txtImportoMovimento.Text = importo.ToString("c");

		}

		private void cmbCausaleEstimate_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleContratto();
			SvuotaDettagliContratto();
			CollegaTuttiDettagliContratto();
			ReCalcImporto_Estimate();
		}

		int GetCausaleContratto() {
			CurrCausaleEstimate = 0;
			//if (!Meta.InsertMode) return "";
			if (DS.incomeestimate.Rows.Count == 0) return 0;
			if (!Meta.DrawStateIsDone) {
				if (DS.incomeestimate.Rows[0]["movkind"] != DBNull.Value)
					CurrCausaleEstimate = CfgFn.GetNoNullInt32(DS.incomeestimate.Rows[0]["movkind"]);
				else
					CurrCausaleEstimate = 0;
				return CurrCausaleEstimate;
			}

			if (cmbCausale.SelectedValue != null)
				DS.incomeestimate.Rows[0]["movkind"] = cmbCausale.SelectedValue;
			else
				DS.incomeestimate.Rows[0]["movkind"] = DBNull.Value;
			CurrCausaleEstimate = CfgFn.GetNoNullInt32(DS.incomeestimate.Rows[0]["movkind"]);
			return CurrCausaleEstimate;
			//ReCalcImporto();
		}


		void UpdateComboCausaleEstimate() {
			if (EstimateMovEntrataLinked != null) {
				object currtipo = EstimateMovEntrataLinked["movkind"];
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}

		private void cmbTipoEstimate_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato = true;
			ClearControlliEstimate(true);
			txtEsercDoc.Text = "";
			txtNumDoc.Text = "";
			TipoDocChangePilotato = false;
		}


		#endregion

		void ResetIva() {
			IvaLinkedMustBeEvalued = true;
			IvaLinked = null;
			IvaMovEntrataLinked = null;
			//IvaMovEntrataViewLinked=null;
		}

		void RintracciaIva() {
			if (!IvaLinkedMustBeEvalued) return;
			GetDocIva(out IvaLinked,
				out IvaMovEntrataLinked,
				//out IvaMovEntrataViewLinked, 
				out CurrCausaleIva);
			if ((IvaLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))) {
				AssegnaDatiContratto(IvaLinked);
			}

			IvaLinkedMustBeEvalued = false;
		}


		void ResetEstimate() {
			EstimateLinkedMustBeEvalued = true;
			EstimateLinked = null;
			EstimateMovEntrataLinked = null;
			//EstimateMovEntrataViewLinked=null;
		}

		void RintracciaEstimate() {
			if (!EstimateLinkedMustBeEvalued) return;
			GetDocEstimate(out EstimateLinked,
				out EstimateMovEntrataLinked,
				//out EstimateMovEntrataViewLinked, 
				out CurrCausaleEstimate);
			if ((EstimateLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))) {
				AssegnaDatiContratto(EstimateLinked);
			}

			EstimateLinkedMustBeEvalued = false;
		}

		void AssegnaDatiContratto(DataRow Contratto) {
			if (DS.incomelast.Rows.Count == 0) return;
			DataRow curr = DS.income.Rows[0];
			DataRow currlast = DS.incomelast.Rows[0];

			EP_functions EP = new EP_functions(Meta.Dispatcher);

			object idaccmotive = DBNull.Value;
			object idacc = DBNull.Value;
			if (Contratto.Table.TableName == "estimate") {
				idaccmotive = Contratto["idaccmotivecredit_crg"];
				if (idaccmotive == DBNull.Value) idaccmotive = Contratto["idaccmotivecredit"];
			}
			else {
				idaccmotive = Contratto["idaccmotivedebit_crg"];
				if (idaccmotive == DBNull.Value) idaccmotive = Contratto["idaccmotivedebit"];
			}

			if (EP.attivo) {
				idacc = EP.GetCustomerAccountForRegistry(idaccmotive, curr["idreg"]);
			}

			if (idacc != DBNull.Value) {
				if (DS.account.Select(QHC.CmpEq("idacc", idacc)).Length == 0) {
					DS.account.Clear();
					Meta.Conn.RUN_SELECT_INTO_TABLE(DS.account, null, QHS.CmpEq("idacc", idacc), null, false);
					if (DS.account.Rows.Count > 0) {
						DataRow Acc = DS.account.Rows[0];
						txtCodiceContoCustomer.Text = Acc["codeacc"].ToString();
						txtDescrContoCustomer.Text = Acc["title"].ToString();
					}
				}

				currlast["idacccredit"] = idacc;
			}
		}

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;
			if (!Meta.IsEmpty) Meta.GetFormData(true);

			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string filteridfin = "(ayear ='" + esercizio + "')and((flag & 1)=0)";

			string filterUpb = "";
			//Il filtro sull'UPB c'è sempre
			object getupb = GetUpb();
			if (getupb != DBNull.Value) {
				filterUpb = QHS.CmpEq("idupb", getupb);
			}
			else {
				filterUpb = QHS.CmpEq("idupb", "0001");
			}

			filter = filteridfin + "AND" + filterUpb;

			//Aggiunge eventualmente il filtro sul disponibile
			decimal currval = 0;
			if (chkFilterAvailable.Checked) {
				if (SubEntity_txtImportoMovimento.Text.Trim() != "") {
					currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
						typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
				}

				filter = GetData.MergeFilters(filter,
					"(availableprevision>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
			}

			if (Meta.EditMode) {
				DataRow rIY = DS.incomeyear.Rows[0];
				if (rIY["idupb", DataRowVersion.Original].Equals(rIY["idupb", DataRowVersion.Current])) {

					string query =
						"SELECT idparent as idfin FROM finlink WHERE "
						+ QHS.CmpEq("idchild", rIY["idfin", DataRowVersion.Original]);
					DataTable tApp = Meta.Conn.SQLRunner(query, true, 0);

					if ((tApp != null) && (tApp.Rows.Count > 0)) {
						filter = QHS.DoPar(QHS.AppOr(QHS.DoPar(filter),
							QHS.DoPar(QHS.AppAnd(QHS.CmpEq("idupb", rIY["idupb"]),
								QHS.FieldIn("idfin", tApp.Select())))
						));
					}
				}
			}

			string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
			                         Meta.GetSys("esercizio").ToString() + "'))";

			// Viene aggiunto a filteroperativo, nel caso siamo in EditMode e non è cambiato l'U.P.B., la
			// vecchia voce di bilancio
			if (Meta.EditMode) {
				DataRow rIY = DS.incomeyear.Rows[0];
				if (rIY["idupb", DataRowVersion.Original].Equals(rIY["idupb", DataRowVersion.Current])) {
					filteroperativo = QHS.DoPar(QHS.AppOr(QHS.DoPar(filteroperativo),
						QHS.CmpEq("idfin", rIY["idfin", DataRowVersion.Original])
					));
				}
			}

			if (chkListManager.Checked) {
				object getman = GetResponsabile();
				if (getman != DBNull.Value) {
					filter = QHS.AppAnd(filter, QHS.CmpEq("idman", getman));
				}
				else {
					filter = QHS.AppAnd(filter, QHS.IsNull("idman"));
				}

				filter = GetData.MergeFilters(filter, filteroperativo);
				MetaData.DoMainCommand(this, "choose.finview.default." + filter);
				return;
			}

			if (chkListTitle.Checked) {
				FrmAskDescr FR = new FrmAskDescr(0);
				DialogResult D = FR.ShowDialog(this);
				if (D != DialogResult.OK) return;
				filter = GetData.MergeFilters(filter,
					         "(title like " + QueryCreator.quotedstrvalue(
						         "%" + FR.txtDescrizione.Text + "%", true)) + ")";
				filter = GetData.MergeFilters(filter, filteroperativo);
				MetaData.DoMainCommand(this, "choose.finview.default." + filter);
				return;
			}

			string filterFinanziamento = "";
			filterFinanziamento = GetData.MergeFilters(filterUpb,
				"(incomeprevavailable>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
			filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteroperativo);
			filterFinanziamento =
				GetData.MergeFilters(filterFinanziamento,
					filteridfin); // filtra voci bilancio di entrata ed esercizio corrente

			DataTable Tupbunderwritingyearview = MyConn.RUN_SELECT("upbunderwritingyearview", "*", null,
				filterFinanziamento, null, null, true);

			if (!(Meta.IsEmpty) && (chkFilterAvailable.Checked) && (Tupbunderwritingyearview.Rows.Count > 0)) {
				MetaData MetaUpbunderwritingyearview = MetaData.GetMetaData(this, "upbunderwritingyearview");
				MetaUpbunderwritingyearview.DS = new DataSet();
				MetaUpbunderwritingyearview.linkedForm = this;
				MetaUpbunderwritingyearview.FilterLocked = true;
				DataRow Upbunderwritingyearview = MetaUpbunderwritingyearview.SelectOne("default", filterFinanziamento,
					"upbunderwritingyearview", null);
				if (Upbunderwritingyearview == null) return;
				txtFinanziamento.Text = Upbunderwritingyearview["underwriting"].ToString();
				txtCodiceBilancio.Text = Upbunderwritingyearview["codefin"].ToString();
				txtDenominazioneBilancio.Text = Upbunderwritingyearview["fin"].ToString();
				DataRow curr = DS.income.Rows[0];
				DataRow curryear = DS.incomeyear.Rows[0];
				curr["idunderwriting"] = Upbunderwritingyearview["idunderwriting"];
				curryear["idfin"] = Upbunderwritingyearview["idfin"];
			}
			else {
				DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
				MetaData.DoMainCommand(this, "manage.finview.treeeupb");
			}
		}

		private void chkListManager_CheckedChanged(object sender, System.EventArgs e) {
			if (chkListManager.Checked) chkListTitle.Checked = false;
		}

		private void chkListTitle_CheckedChanged(object sender, System.EventArgs e) {
			if (chkListTitle.Checked) chkListManager.Checked = false;
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
			object getman = GetResponsabile();
			if (Meta.IsEmpty || (Meta.EditMode && getman == DBNull.Value)) {
				Meta.DoMainCommand("manage.upb.tree");
				return;
			}

			string filterMan = "";
			if (getman != DBNull.Value) {
				filterMan = QHS.CmpEq("idman", getman);
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
				filter = QHS.AppAnd(filter, QHS.CmpGe("incomeprevavailable", currval));
			}

			MetaData MetaUpb = MetaData.GetMetaData(this, "upbyearview");
			MetaUpb.DS = new DataSet();
			MetaUpb.linkedForm = this;
			MetaUpb.FilterLocked = true;
			DataRow Upb = MetaUpb.SelectOne("income", filter, "upbyearview", null);
			if (Upb == null) return;
			object idupb = Upb["idupb"];
			SetUPB(idupb);
			if (monofase) AggiornaBilancioResponsabile(Upb);
		}

		private void SubEntity_chkCassa_CheckedChanged(object sender, EventArgs e) {
			bool isChecked = (SubEntity_chkCassa.CheckState == CheckState.Checked);
			if (isChecked) {
				SubEntity_chkPrelievodaCCP.Checked = !isChecked;
				SubEntity_chkAccreditoTPS.Checked = !isChecked;
			}
		}

		private void SubEntity_chkPrelievodaCCP_CheckedChanged(object sender, EventArgs e) {

			bool isChecked = (SubEntity_chkPrelievodaCCP.CheckState == CheckState.Checked);
			if (isChecked) {
				SubEntity_chkAccreditoTPS.Checked = !isChecked;
				SubEntity_chkCassa.Checked = !isChecked;
			}
		}

		private void SubEntity_chkAccreditoTPS_CheckedChanged(object sender, EventArgs e) {
			bool isChecked = (SubEntity_chkAccreditoTPS.CheckState == CheckState.Checked);
			if (isChecked) {
				SubEntity_chkPrelievodaCCP.Checked = !isChecked;
				SubEntity_chkCassa.Checked = !isChecked;
				SubEntity_chkCassa.Checked = !isChecked;
			}

		}

		private void btnMultipleBillSel_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			FrmChooseBill f = new FrmChooseBill(Meta, GetData.MergeFilters(null, DS.billview));
			if (f.ShowDialog(this) != DialogResult.OK) return;

			DataRow[] sel = f.GetGridSelectedRows();
			MetaData mincbill = Meta.Dispatcher.Get("incomebill");
			mincbill.SetDefaults(DS.incomebill);
			DataRow curr = DS.income.Rows[0];

			foreach (DataRow r in sel) {
				decimal amount = CfgFn.GetNoNullDecimal(r["total"]) - CfgFn.GetNoNullDecimal(r["reduction"]) -
				                 CfgFn.GetNoNullDecimal(r["covered"]);
				string filter = QHC.CmpEq("nbill", r["nbill"]);
				if (DS.incomebill.Select(filter).Length > 0) {
					DS.incomebill.Select(filter)[0]["amount"] = amount;
				}
				else {
					DataRow rr = mincbill.Get_New_Row(curr, DS.incomebill);
					rr["nbill"] = r["nbill"];
					rr["amount"] = amount;
				}
			}

			Meta.GetFormData(true);
			Meta.FreshForm();
		}


		private void CalcolaTotaleSospesi() {

			decimal totaleSospesi = 0;

			foreach (DataRow R in DS.incomebill.Select()) {

				totaleSospesi += CfgFn.GetNoNullDecimal(R["amount"]);
			}

			txtTotaleSospesi.Text = totaleSospesi.ToString("c");


		}

		private void btnScrittureCollegate_Click(object sender, EventArgs e) {
			if (DS.income.Rows.Count == 0) return;
			var r = DS.income.Rows[0];
			string idinc = r["idinc"].ToString();
			var mEntryDetail = Meta.Dispatcher.Get("entrydetail");
			mEntryDetail.Edit(ParentForm, "default", false);
			var listtype = "listaestesa";
			//ToMeta.FilterLocked = true;
			mEntryDetail.SelectOne(listtype, QHS.DoPar(QHS.AppOr(
					QHS.CmpEq("idrelateddetail", "income§" + idinc + "§credit"),
					QHS.CmpEq("idrelateddetail", "income§" + idinc)))
				, null, null);
		}

		void autodetectIncassi() {
			var currRow = DS.income.Rows[0];

			decimal currAmount = GetImportoPerClassificazione();

			object idincToConsider = currRow["idinc"];
			if (currRow.RowState == DataRowState.Added) {
				idincToConsider = currRow["parentidinc"];
			}

			//Calcola il residuo dei dettagli contabilizzati dall'accertamento
			var residual = MyConn.DO_SYS_CMD($@"select sum(ed.residual) from estimatedetailtocashin ed 
											join incomelink il on ed.idinc_taxable=il.idparent
											where {(q.eq("il.idchild", idincToConsider) & q.isNull("stop")).toSql(QHS, MyConn)} "); //mCmp non serve ma per sicurezza lo metto
			if (CfgFn.GetNoNullDecimal(residual) == currAmount) {
				doCollegamentoAutomatico();
			}
		}

		void doCollegamentoAutomatico() {
			var currRow = DS.income.Rows[0];


			//Da attivarsi solo in fase incasso ove ci sia un contratto attivo contabilizzato in fase di accertamento, esclusi db monofase
			//Dei dettagli collegati in fase di accertamento deve collegare, a tappo, un insieme di dettagli per un importo pari all'incasso
			// a tal fine è necessario usare una vista apposita
			decimal totLinked =
				MetaData.SumColumn(DS.incomelastestimatedetail,
					"amount"); //include valori non presenti nei residual delle righe della vista
			decimal currAmount = GetImportoPerClassificazione();
			decimal toAssign = currAmount - totLinked;
			if (toAssign <= 0) return;

			DataRow MiddleRow;
			var estim = GetDocRow("estimate", "incomeestimate", faseentrata, out MiddleRow);
			if (estim == null) {
				show("Il movimento non contabilizza un contratto attivo", "Avviso");
				return;
			}

			object idincToConsider = currRow["idinc"];
			if (currRow.RowState == DataRowState.Added) {
				idincToConsider = currRow["parentidinc"];
			}


			//deve filtrare i dettagli appartenenti all'accertamento parent di questo incasso
			q accertate = q.constant(true);
			if (DS.estimatedetail_taxable.Select().Length == 0) {
				//deve prendere in base a incomelink
				var righe = MyConn.SQLRunner($@"select ed.rownum from estimatedetail ed 
											join incomelink il on ed.idinc_taxable=il.idparent
											where {(q.eq("il.idchild", idincToConsider) & q.isNull("stop")).toSql(QHS, MyConn)} "); //mCmp non serve ma per sicurezza lo metto


				//var righe = MyConn.SQLRunner($@"select rownum from estimatedetail  
				//							where {(q.eq("idinc_taxable",idincToConsider) & q.isNull("stop")).toSql(QHS,MyConn)} "); //mCmp non serve ma per sicurezza lo metto
				if (righe != null && righe.Rows.Count > 0) {
					accertate = q.fieldIn("rownum", righe.Select()._Pick("rownum").ToArray());
				}
				else {
					show("Il movimento non contabilizza dettagli di contratto attivo", "Avviso");
					return;
				}
			}
			else {
				var dettagli = DS.estimatedetail_taxable.Select();
				if (dettagli.Length == 0) {
					show("Il movimento non contabilizza dettagli di contratto attivo", "Avviso");
				}

				//deve prendere le righe di estimatedetails
				accertate = q.fieldIn("rownum", dettagli._Pick("rownum").ToArray());
			}


			q filterDetails = q.keyCmp(estim) & q.isNull("stop") & q.gt("residual", 0) & accertate;
			var detailsToLink =
				MyConn.RUN_SELECT("estimatedetailtocashin", "*", null, filterDetails.toSql(QHS), null, false);
			if (detailsToLink == null || detailsToLink.Rows.Count == 0) {
				show("I dettagli del contratto attivo sono tutti incassati.", "Avviso");
				return;
			}

			//Per ogni riga con del residuo, vede se c'è già
			// se c'è ne aumenta l'importo per un valore pari al residuo
			// se non c'è la crea con importo pari al residuo
			var metaDetail = Meta.Dispatcher.Get("incomelastestimatedetail");
			metaDetail.SetDefaults(DS.incomelastestimatedetail);

			foreach (DataRow r in detailsToLink.Rows) {
				if (toAssign == 0) break;
				decimal residual = CfgFn.GetNoNullDecimal(r["residual"]);

				var found = DS.incomelastestimatedetail
					._Filter(q.mCmp(r, DS.estimatedetail_taxable.PrimaryKey), null, null, true).FirstOrDefault();
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

				var rNew = metaDetail.Get_New_Row(DS.income.Rows[0], DS.incomelastestimatedetail);
				foreach (var c in DS.estimatedetail_taxable.PrimaryKey) rNew[c.ColumnName] = r[c.ColumnName];
				rNew["amount"] = residual;
				toAssign -= residual;
			}

			foreach (DataRow r in DS.incomelastestimatedetail.Select()) {
				DS.estimatedetail_taxable.safeMergeFromDb(MyConn,
					q.mCmp(r, "idestimkind", "yestim", "nestim", "rownum"));
				Meta.getData.CalcTemporaryValues(r);
			}
		}

		private void btnCollegaDettagliContratto_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty) return;
			if (DS.incomelast.Rows.Count == 0) return;
			Meta.GetFormData(true);
			doCollegamentoAutomatico();
			Meta.FreshForm();
		}
	}
}
