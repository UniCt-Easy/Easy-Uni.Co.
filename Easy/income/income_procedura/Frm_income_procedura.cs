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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using movimentofunctions;//movimentofunctions
using funzioni_configurazione;//funzioni_configurazione
using System.Data;
using gestioneclassificazioni;
using SituazioneViewer;
using ep_functions;
using chooseBill;
using q= metadatalibrary.MetaExpression;
using System.Linq;


namespace income_procedura//entrataprocedura//
{
	/// <summary>
	/// Summary description for FrmEntrataProcedura.
	/// </summary>
	public class Frm_income_procedura : System.Windows.Forms.Form
	{

		#region Dichiarazione Variabili e Controlli
        bool classEnabled = true;
		/// <summary>
		/// DataSet for posting operations 
		/// </summary>
		DataSet DSP;

		private MetaData Meta;
		private DataAccess MyConn;
		private int faseentratamax;
		int fasespesamax;
		bool MustClose=false;

		bool to_mainrefresh; //true se deve essere effettuato un main refresh (dopo i post)
		decimal lastimportofreshed;
		decimal DisponibileDaFasePrecedente;

		GestioneClassificazioni ManageClassificazioni;

		GBoxManage ManageBilAnnuale;
		GBoxManage ManageUPB;
		GBoxManage ManageCreditore;

		string flagcreddeb;
		string flagbilancio;
		string flagrespons;
		string flagresidui;
		string maxfasebil;

		/// <summary>
		/// True durante il post degli automatismi, usato per non innescare un loop
		/// </summary>
		bool InChiusura;

		int faseinizio;  //prima fase selezionata nel checkedlistbox

		/// <summary>
		/// fasefine è l'ultima fase a cui si deve arrivare nel salvataggio
		/// </summary>
		int fasefine;    //ultima fase selezionata (può essere anche = fasespesamax)

		int faseentratafine {
			get {
				if (fasefine<=faseentratamax) return fasefine;
				return faseentratamax;
			}
		}
		int fasecontratto;
		int faseiva;
		int faseentrata;

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

		//True quando il form si sta chiudendo. Questo per non bloccare il focus negli 
		// automanage (problema di dotnet)
		bool CanGoInsert;
		private System.Windows.Forms.GroupBox groupBox17;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox groupBox19;
		private System.Windows.Forms.TextBox txtDocumento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtDataDocumento;
		private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gboxResponsabile;
		private System.Windows.Forms.GroupBox groupBox18;
		private System.Windows.Forms.TextBox SubEntity_txtImportoMovimento;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox20;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtDataCont;
		private System.Windows.Forms.TextBox txtScadenza;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chbAzzeramento;
		private System.Windows.Forms.GroupBox grpReversaleIncasso;
		private System.Windows.Forms.RadioButton rdbFruttifero;
		private System.Windows.Forms.RadioButton rdbInfruttifero;
		private System.Windows.Forms.CheckedListBox chkListaFasi;
		private System.Windows.Forms.GroupBox groupBox15;
		private System.Windows.Forms.Button btnDelClass;
		private System.Windows.Forms.Button btnEditClass;
		private System.Windows.Forms.Button btnInsertClass;
		private System.Windows.Forms.DataGrid DGridDettagliClassificazioni;
		private System.Windows.Forms.DataGrid DGridClassificazioni;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.TextBox txtNumMandato;
        private System.Windows.Forms.Label label28;
		public dsmeta DS;
		private System.Windows.Forms.GroupBox grpTipoConto;
		private System.Windows.Forms.CheckBox SubEntity_chbCoperturaIniziativa;
		private System.Windows.Forms.ComboBox cmbIstitutoCassiere;
		private System.Windows.Forms.Button btnIstitutoCassiere;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.TextBox txtImportoAssegnareCrediti;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtImportoAssegnareIncassi;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnGerarchia;
		private System.Windows.Forms.Button btnSituazioneMovimentoSpesa;
		private System.Windows.Forms.Label labelCausale;
		private System.Windows.Forms.ComboBox cmbCausale;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cmbTipoContabilizzazione;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMovFin;
		private System.Windows.Forms.TabPage tabClassSup;
		private System.Windows.Forms.TabPage tabIncasso;
		private System.Windows.Forms.TabPage tabAssCrediti;
		private System.Windows.Forms.TabPage tabAssIncassi;
		private System.Windows.Forms.GroupBox gboxIncassi;
		private System.Windows.Forms.Button btnGeneraClassAutomatiche;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTipoDocumento;
		private System.Windows.Forms.TextBox txtNumDoc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtEsercDoc;
		private System.Windows.Forms.Button btnDocumento;
		private System.Windows.Forms.Label labelTipoDocumento;
		private System.Windows.Forms.GroupBox gboxDocumento;
		private System.Windows.Forms.TextBox txtCredDeb;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.CheckBox chkListTitle;
		private System.Windows.Forms.CheckBox chkListManager;
		private System.Windows.Forms.CheckBox chkFilterAvailable;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.Button btnFasePrecedente;
		private System.Windows.Forms.TextBox txtNumeroFasePrecedente;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtEsercizioFasePrecedente;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox gboxFasePrecedente;
		private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TextBox txtDescrUPB;
		private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.DataGrid GridCrediti;
        private System.Windows.Forms.GroupBox gboxCrediti;
		private System.Windows.Forms.GroupBox gboxBolletta;
		private System.Windows.Forms.TextBox SubEntity_txtBolletta;
		private System.Windows.Forms.Button btnBolletta;
		private System.Windows.Forms.TabPage tabDetails;
		private System.Windows.Forms.GroupBox gboxDettEstimate;
		private System.Windows.Forms.Button btnEditEstimDet;
		private System.Windows.Forms.TextBox txtTotEstimateDetail;
		private System.Windows.Forms.Label label2;
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
        private TabPage tabPage1;
        private GroupBox grpContocredito;
        private TextBox txtDescrContoCustomer;
        private TextBox txtCodiceContoCustomer;
        private Button btnContoCredito;
        private Label lblcup;
        private TextBox txtcup;
        private Button btnBollo;
        private ComboBox cmbBollo;
        private GroupBox groupBox3;
        private TextBox txtFinanziamento;
        private Button btnFinanziamento;
        private Button btnCopiaAssegnazioneCrediti;
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
        private CheckBox SubEntity_chkIncassoNetto;
        private Label lbTotale;
        private TextBox txtTotaleSospesi;
        private System.ComponentModel.IContainer components;
		#endregion
		public Frm_income_procedura() {
			InitializeComponent();
			CanGoInsert=false;
			InChiusura=false;
			faseinizio=0;
			fasefine=0;
			DS.incomephase.ExtendedProperties["sort_by"]="nphase";
            //DS.sortingkind.ExtendedProperties["sort_by"]="sortinglevel, description";
			DS.incomesorted.ExtendedProperties["gridmaster"]="sortingkind";
			DataAccess.SetTableForReading(DS.bilanciocrediti,"fin");
            DataAccess.SetTableForReading(DS.upbcrediti, "upb");
            DataAccess.SetTableForReading(DS.upbincassi, "upb");
			DataAccess.SetTableForReading(DS.bilancioincassi,"fin");
			GetData.SetSorting(DS.upb,"codeupb asc");
			GetData.SetSorting(DS.bill,"nbill desc");
			GetData.SetSorting(DS.billview,"nbill desc");

			DS.Tables["income"].ExtendedProperties["faseinizio"]=0;
			DS.Tables["income"].ExtendedProperties["fasefine"]=0;
			
			ResetTipoClassAvailableEvalued();

			//			currphase = 1;
			//			fasespesamax = 2;			
			to_mainrefresh=false;

//			tabControl1.Appearance = 
//				Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiBox;
//			tabControl1.HotTrack=true;
//			tabControl1.PositionTop=true;
			tabControl1.SelectedIndex=0;
			DataAccess.SetTableForReading(DS.estimatedetail_iva, "estimatedetailview");
			DataAccess.SetTableForReading(DS.estimatedetail_taxable, "estimatedetailview");
			QueryCreator.SetTableForPosting(DS.estimatedetail_iva, "estimatedetail");
			QueryCreator.SetTableForPosting(DS.estimatedetail_taxable, "estimatedetail");
			DataAccess.SetTableForReading(DS.invoicedetail_iva, "invoicedetailview");
			DataAccess.SetTableForReading(DS.invoicedetail_taxable, "invoicedetailview");
			QueryCreator.SetTableForPosting(DS.invoicedetail_iva, "invoicedetail");
			QueryCreator.SetTableForPosting(DS.invoicedetail_taxable, "invoicedetail");
			GetData.SetSorting(DS.estimatedetail_iva,"idgroup");
			GetData.SetSorting(DS.estimatedetail_taxable,"idgroup"); 

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			InChiusura=true;
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_income_procedura));
            this.SubEntity_chbCoperturaIniziativa = new System.Windows.Forms.CheckBox();
            this.grpReversaleIncasso = new System.Windows.Forms.GroupBox();
            this.btnBollo = new System.Windows.Forms.Button();
            this.cmbBollo = new System.Windows.Forms.ComboBox();
            this.DS = new income_procedura.dsmeta();
            this.cmbIstitutoCassiere = new System.Windows.Forms.ComboBox();
            this.btnIstitutoCassiere = new System.Windows.Forms.Button();
            this.grpTipoConto = new System.Windows.Forms.GroupBox();
            this.rdbFruttifero = new System.Windows.Forms.RadioButton();
            this.rdbInfruttifero = new System.Windows.Forms.RadioButton();
            this.chkListaFasi = new System.Windows.Forms.CheckedListBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataCont = new System.Windows.Forms.TextBox();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chbAzzeramento = new System.Windows.Forms.CheckBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.SubEntity_txtImportoMovimento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnDelClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnInsertClass = new System.Windows.Forms.Button();
            this.DGridDettagliClassificazioni = new System.Windows.Forms.DataGrid();
            this.DGridClassificazioni = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtNumMandato = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtImportoAssegnareCrediti = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GridCrediti = new System.Windows.Forms.DataGrid();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtImportoAssegnareIncassi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMovFin = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.gboxDocumento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.btnDocumento = new System.Windows.Forms.Button();
            this.labelTipoDocumento = new System.Windows.Forms.Label();
            this.labelCausale = new System.Windows.Forms.Label();
            this.cmbCausale = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoContabilizzazione = new System.Windows.Forms.ComboBox();
            this.btnGerarchia = new System.Windows.Forms.Button();
            this.btnSituazioneMovimentoSpesa = new System.Windows.Forms.Button();
            this.gboxFasePrecedente = new System.Windows.Forms.GroupBox();
            this.btnFasePrecedente = new System.Windows.Forms.Button();
            this.txtNumeroFasePrecedente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEsercizioFasePrecedente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.tabClassSup = new System.Windows.Forms.TabPage();
            this.btnGeneraClassAutomatiche = new System.Windows.Forms.Button();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.gboxDettInvoice = new System.Windows.Forms.GroupBox();
            this.btnEditInvDet = new System.Windows.Forms.Button();
            this.txtTotInvoiceDetail = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnRemoveDettInvoice = new System.Windows.Forms.Button();
            this.btnAddDettInvoice = new System.Windows.Forms.Button();
            this.dgrDettagliFattura = new System.Windows.Forms.DataGrid();
            this.gboxDettEstimate = new System.Windows.Forms.GroupBox();
            this.btnEditEstimDet = new System.Windows.Forms.Button();
            this.txtTotEstimateDetail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveDetEstimate = new System.Windows.Forms.Button();
            this.dgrDettagliContratto = new System.Windows.Forms.DataGrid();
            this.btnAddDetEstimate = new System.Windows.Forms.Button();
            this.tabIncasso = new System.Windows.Forms.TabPage();
            this.SubEntity_chkIncassoNetto = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotale = new System.Windows.Forms.Label();
            this.txtTotaleSospesi = new System.Windows.Forms.TextBox();
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
            this.tabAssCrediti = new System.Windows.Forms.TabPage();
            this.gboxCrediti = new System.Windows.Forms.GroupBox();
            this.tabAssIncassi = new System.Windows.Forms.TabPage();
            this.gboxIncassi = new System.Windows.Forms.GroupBox();
            this.btnCopiaAssegnazioneCrediti = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblcup = new System.Windows.Forms.Label();
            this.txtcup = new System.Windows.Forms.TextBox();
            this.grpContocredito = new System.Windows.Forms.GroupBox();
            this.txtDescrContoCustomer = new System.Windows.Forms.TextBox();
            this.txtCodiceContoCustomer = new System.Windows.Forms.TextBox();
            this.btnContoCredito = new System.Windows.Forms.Button();
            this.grpReversaleIncasso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipoConto.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCrediti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabMovFin.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxBolletta.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxDocumento.SuspendLayout();
            this.gboxFasePrecedente.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.tabClassSup.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.gboxDettInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).BeginInit();
            this.gboxDettEstimate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliContratto)).BeginInit();
            this.tabIncasso.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).BeginInit();
            this.grpModRiscossione.SuspendLayout();
            this.tabAssCrediti.SuspendLayout();
            this.gboxCrediti.SuspendLayout();
            this.tabAssIncassi.SuspendLayout();
            this.gboxIncassi.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpContocredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // SubEntity_chbCoperturaIniziativa
            // 
            this.SubEntity_chbCoperturaIniziativa.Enabled = false;
            this.SubEntity_chbCoperturaIniziativa.Location = new System.Drawing.Point(445, 427);
            this.SubEntity_chbCoperturaIniziativa.Name = "SubEntity_chbCoperturaIniziativa";
            this.SubEntity_chbCoperturaIniziativa.Size = new System.Drawing.Size(264, 16);
            this.SubEntity_chbCoperturaIniziativa.TabIndex = 17;
            this.SubEntity_chbCoperturaIniziativa.Tag = "incomelast.flag:0?incomeview.flag:0";
            this.SubEntity_chbCoperturaIniziativa.Text = "Regolarizza disposizione di incasso già effettuata";
            this.SubEntity_chbCoperturaIniziativa.CheckedChanged += new System.EventHandler(this.chbCoperturaIniziativa_CheckedChanged);
            // 
            // grpReversaleIncasso
            // 
            this.grpReversaleIncasso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReversaleIncasso.Controls.Add(this.btnBollo);
            this.grpReversaleIncasso.Controls.Add(this.cmbBollo);
            this.grpReversaleIncasso.Controls.Add(this.cmbIstitutoCassiere);
            this.grpReversaleIncasso.Controls.Add(this.btnIstitutoCassiere);
            this.grpReversaleIncasso.Controls.Add(this.grpTipoConto);
            this.grpReversaleIncasso.Location = new System.Drawing.Point(437, 77);
            this.grpReversaleIncasso.Name = "grpReversaleIncasso";
            this.grpReversaleIncasso.Size = new System.Drawing.Size(378, 90);
            this.grpReversaleIncasso.TabIndex = 4;
            this.grpReversaleIncasso.TabStop = false;
            this.grpReversaleIncasso.Text = "Reversale di incasso";
            // 
            // btnBollo
            // 
            this.btnBollo.Location = new System.Drawing.Point(8, 66);
            this.btnBollo.Name = "btnBollo";
            this.btnBollo.Size = new System.Drawing.Size(104, 23);
            this.btnBollo.TabIndex = 49;
            this.btnBollo.TabStop = false;
            this.btnBollo.Tag = "manage.stamphandling.lista";
            this.btnBollo.Text = "Bollo";
            // 
            // cmbBollo
            // 
            this.cmbBollo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBollo.DataSource = this.DS.stamphandling;
            this.cmbBollo.DisplayMember = "description";
            this.cmbBollo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBollo.Location = new System.Drawing.Point(123, 67);
            this.cmbBollo.Name = "cmbBollo";
            this.cmbBollo.Size = new System.Drawing.Size(247, 21);
            this.cmbBollo.TabIndex = 50;
            this.cmbBollo.Tag = "";
            this.cmbBollo.ValueMember = "idstamphandling";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // cmbIstitutoCassiere
            // 
            this.cmbIstitutoCassiere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbIstitutoCassiere.DataSource = this.DS.treasurer;
            this.cmbIstitutoCassiere.DisplayMember = "description";
            this.cmbIstitutoCassiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIstitutoCassiere.Location = new System.Drawing.Point(120, 13);
            this.cmbIstitutoCassiere.Name = "cmbIstitutoCassiere";
            this.cmbIstitutoCassiere.Size = new System.Drawing.Size(250, 21);
            this.cmbIstitutoCassiere.TabIndex = 1;
            this.cmbIstitutoCassiere.Tag = "";
            this.cmbIstitutoCassiere.ValueMember = "idtreasurer";
            this.cmbIstitutoCassiere.SelectedIndexChanged += new System.EventHandler(this.cmbIstitutoCassiere_SelectedIndexChanged);
            // 
            // btnIstitutoCassiere
            // 
            this.btnIstitutoCassiere.Location = new System.Drawing.Point(8, 13);
            this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
            this.btnIstitutoCassiere.Size = new System.Drawing.Size(104, 23);
            this.btnIstitutoCassiere.TabIndex = 48;
            this.btnIstitutoCassiere.TabStop = false;
            this.btnIstitutoCassiere.Tag = "choose.treasurer.lista.(active=\'S\')";
            this.btnIstitutoCassiere.Text = "Cassiere:";
            // 
            // grpTipoConto
            // 
            this.grpTipoConto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoConto.Controls.Add(this.rdbFruttifero);
            this.grpTipoConto.Controls.Add(this.rdbInfruttifero);
            this.grpTipoConto.Location = new System.Drawing.Point(8, 35);
            this.grpTipoConto.Name = "grpTipoConto";
            this.grpTipoConto.Size = new System.Drawing.Size(362, 30);
            this.grpTipoConto.TabIndex = 47;
            this.grpTipoConto.TabStop = false;
            this.grpTipoConto.Text = "Conto";
            // 
            // rdbFruttifero
            // 
            this.rdbFruttifero.Location = new System.Drawing.Point(45, 7);
            this.rdbFruttifero.Name = "rdbFruttifero";
            this.rdbFruttifero.Size = new System.Drawing.Size(88, 16);
            this.rdbFruttifero.TabIndex = 2;
            this.rdbFruttifero.Tag = "";
            this.rdbFruttifero.Text = "Fruttifero";
            // 
            // rdbInfruttifero
            // 
            this.rdbInfruttifero.Location = new System.Drawing.Point(139, 8);
            this.rdbInfruttifero.Name = "rdbInfruttifero";
            this.rdbInfruttifero.Size = new System.Drawing.Size(88, 16);
            this.rdbInfruttifero.TabIndex = 3;
            this.rdbInfruttifero.Tag = "";
            this.rdbInfruttifero.Text = "Infruttifero";
            // 
            // chkListaFasi
            // 
            this.chkListaFasi.CheckOnClick = true;
            this.chkListaFasi.Location = new System.Drawing.Point(8, 40);
            this.chkListaFasi.Name = "chkListaFasi";
            this.chkListaFasi.Size = new System.Drawing.Size(423, 79);
            this.chkListaFasi.TabIndex = 2;
            this.chkListaFasi.ThreeDCheckBoxes = true;
            this.chkListaFasi.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListaFasi_ItemCheck);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label15);
            this.groupBox20.Controls.Add(this.txtDataCont);
            this.groupBox20.Controls.Add(this.txtScadenza);
            this.groupBox20.Controls.Add(this.label13);
            this.groupBox20.Location = new System.Drawing.Point(8, 458);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(423, 40);
            this.groupBox20.TabIndex = 11;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Data";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(64, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Contabile";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(120, 14);
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.Size = new System.Drawing.Size(72, 20);
            this.txtDataCont.TabIndex = 1;
            this.txtDataCont.Tag = "income.adate";
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(336, 15);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.Size = new System.Drawing.Size(72, 20);
            this.txtScadenza.TabIndex = 2;
            this.txtScadenza.Tag = "income.expiration";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(264, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "Scadenza:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbAzzeramento
            // 
            this.chbAzzeramento.Location = new System.Drawing.Point(445, 449);
            this.chbAzzeramento.Name = "chbAzzeramento";
            this.chbAzzeramento.Size = new System.Drawing.Size(256, 16);
            this.chbAzzeramento.TabIndex = 18;
            this.chbAzzeramento.Tag = "";
            this.chbAzzeramento.Text = "Azzera il disponibile di tutti i mov. fin. precedenti";
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.SubEntity_txtImportoMovimento);
            this.groupBox18.Controls.Add(this.label11);
            this.groupBox18.Location = new System.Drawing.Point(8, 120);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(423, 36);
            this.groupBox18.TabIndex = 5;
            this.groupBox18.TabStop = false;
            // 
            // SubEntity_txtImportoMovimento
            // 
            this.SubEntity_txtImportoMovimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubEntity_txtImportoMovimento.Location = new System.Drawing.Point(302, 11);
            this.SubEntity_txtImportoMovimento.Name = "SubEntity_txtImportoMovimento";
            this.SubEntity_txtImportoMovimento.Size = new System.Drawing.Size(112, 20);
            this.SubEntity_txtImportoMovimento.TabIndex = 1;
            this.SubEntity_txtImportoMovimento.Tag = "incomeyear.amount?incomeview.ayearstartamount";
            this.SubEntity_txtImportoMovimento.Leave += new System.EventHandler(this.SubEntity_txtImportoMovimento_Leave);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(119, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Importo originale:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox19.Location = new System.Drawing.Point(445, 327);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(370, 54);
            this.groupBox19.TabIndex = 15;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Documento collegato";
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(8, 31);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(200, 20);
            this.txtDocumento.TabIndex = 1;
            this.txtDocumento.Tag = "income.doc";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Descrizione:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataDocumento.Location = new System.Drawing.Point(232, 32);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(130, 20);
            this.txtDataDocumento.TabIndex = 2;
            this.txtDataDocumento.Tag = "income.docdate";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(240, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Data:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(8, 158);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(423, 40);
            this.gboxResponsabile.TabIndex = 6;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(6, 15);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(408, 20);
            this.txtResponsabile.TabIndex = 3;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.txtDescrizione);
            this.groupBox17.Location = new System.Drawing.Point(437, 3);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(378, 74);
            this.groupBox17.TabIndex = 3;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Descrizione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(8, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(362, 52);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "income.description";
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
            this.groupBox15.Size = new System.Drawing.Size(807, 284);
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
            this.DGridDettagliClassificazioni.Location = new System.Drawing.Point(8, 56);
            this.DGridDettagliClassificazioni.Name = "DGridDettagliClassificazioni";
            this.DGridDettagliClassificazioni.ReadOnly = true;
            this.DGridDettagliClassificazioni.Size = new System.Drawing.Size(791, 210);
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
            this.DGridClassificazioni.Size = new System.Drawing.Size(807, 152);
            this.DGridClassificazioni.TabIndex = 31;
            this.DGridClassificazioni.Tag = "sortingkind.default";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Classificazioni";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.txtNumMandato);
            this.groupBox9.Controls.Add(this.label28);
            this.groupBox9.Location = new System.Drawing.Point(8, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(135, 56);
            this.groupBox9.TabIndex = 20;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Reversale di Incasso";
            // 
            // txtNumMandato
            // 
            this.txtNumMandato.Location = new System.Drawing.Point(54, 27);
            this.txtNumMandato.Name = "txtNumMandato";
            this.txtNumMandato.Size = new System.Drawing.Size(64, 20);
            this.txtNumMandato.TabIndex = 2;
            this.txtNumMandato.Tag = "";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(6, 27);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 16);
            this.label28.TabIndex = 13;
            this.label28.Text = "Numero:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImportoAssegnareCrediti
            // 
            this.txtImportoAssegnareCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoAssegnareCrediti.Location = new System.Drawing.Point(663, 16);
            this.txtImportoAssegnareCrediti.Name = "txtImportoAssegnareCrediti";
            this.txtImportoAssegnareCrediti.ReadOnly = true;
            this.txtImportoAssegnareCrediti.Size = new System.Drawing.Size(136, 20);
            this.txtImportoAssegnareCrediti.TabIndex = 13;
            this.txtImportoAssegnareCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(463, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Importo disponibile da assegnare:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GridCrediti
            // 
            this.GridCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridCrediti.DataMember = "";
            this.GridCrediti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.GridCrediti.Location = new System.Drawing.Point(8, 45);
            this.GridCrediti.Name = "GridCrediti";
            this.GridCrediti.Size = new System.Drawing.Size(791, 435);
            this.GridCrediti.TabIndex = 11;
            this.GridCrediti.Tag = "creditpart.detail.detail";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(168, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Tag = "delete";
            this.button6.Text = "Elimina";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(88, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 9;
            this.button5.Tag = "edit.detail";
            this.button5.Text = "Modifica";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Tag = "insert.detail";
            this.button4.Text = "Inserisci...";
            // 
            // txtImportoAssegnareIncassi
            // 
            this.txtImportoAssegnareIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportoAssegnareIncassi.Location = new System.Drawing.Point(663, 16);
            this.txtImportoAssegnareIncassi.Name = "txtImportoAssegnareIncassi";
            this.txtImportoAssegnareIncassi.ReadOnly = true;
            this.txtImportoAssegnareIncassi.Size = new System.Drawing.Size(136, 20);
            this.txtImportoAssegnareIncassi.TabIndex = 16;
            this.txtImportoAssegnareIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(463, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 23);
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
            this.dataGrid2.Size = new System.Drawing.Size(791, 408);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMovFin);
            this.tabControl1.Controls.Add(this.tabClassSup);
            this.tabControl1.Controls.Add(this.tabDetails);
            this.tabControl1.Controls.Add(this.tabIncasso);
            this.tabControl1.Controls.Add(this.tabAssCrediti);
            this.tabControl1.Controls.Add(this.tabAssIncassi);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(830, 530);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabClassSup_Enter);
            // 
            // tabMovFin
            // 
            this.tabMovFin.Controls.Add(this.groupBox3);
            this.tabMovFin.Controls.Add(this.gboxBolletta);
            this.tabMovFin.Controls.Add(this.gboxUPB);
            this.tabMovFin.Controls.Add(this.gboxBilAnnuale);
            this.tabMovFin.Controls.Add(this.gboxDocumento);
            this.tabMovFin.Controls.Add(this.labelCausale);
            this.tabMovFin.Controls.Add(this.cmbCausale);
            this.tabMovFin.Controls.Add(this.label9);
            this.tabMovFin.Controls.Add(this.cmbTipoContabilizzazione);
            this.tabMovFin.Controls.Add(this.btnGerarchia);
            this.tabMovFin.Controls.Add(this.btnSituazioneMovimentoSpesa);
            this.tabMovFin.Controls.Add(this.gboxFasePrecedente);
            this.tabMovFin.Controls.Add(this.groupBox17);
            this.tabMovFin.Controls.Add(this.chkListaFasi);
            this.tabMovFin.Controls.Add(this.SubEntity_chbCoperturaIniziativa);
            this.tabMovFin.Controls.Add(this.groupBox20);
            this.tabMovFin.Controls.Add(this.grpReversaleIncasso);
            this.tabMovFin.Controls.Add(this.groupCredDeb);
            this.tabMovFin.Controls.Add(this.gboxResponsabile);
            this.tabMovFin.Controls.Add(this.groupBox19);
            this.tabMovFin.Controls.Add(this.chbAzzeramento);
            this.tabMovFin.Controls.Add(this.groupBox18);
            this.tabMovFin.Location = new System.Drawing.Point(4, 23);
            this.tabMovFin.Name = "tabMovFin";
            this.tabMovFin.Size = new System.Drawing.Size(823, 503);
            this.tabMovFin.TabIndex = 0;
            this.tabMovFin.Text = "Movimento Finanziario";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFinanziamento);
            this.groupBox3.Controls.Add(this.btnFinanziamento);
            this.groupBox3.Location = new System.Drawing.Point(8, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 61);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
            // 
            // txtFinanziamento
            // 
            this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinanziamento.Location = new System.Drawing.Point(7, 33);
            this.txtFinanziamento.Multiline = true;
            this.txtFinanziamento.Name = "txtFinanziamento";
            this.txtFinanziamento.Size = new System.Drawing.Size(410, 22);
            this.txtFinanziamento.TabIndex = 4;
            this.txtFinanziamento.Tag = "underwriting.title";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(7, 7);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 3;
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
            this.gboxBolletta.Location = new System.Drawing.Point(445, 381);
            this.gboxBolletta.Name = "gboxBolletta";
            this.gboxBolletta.Size = new System.Drawing.Size(370, 40);
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
            this.btnBolletta.Tag = "choose.bill.entrata.((active=\'S\') and (isnull(total,0)-isnull(reduction,0)>covere" +
    "d) AND (ISNULL(toregularize,0)>0))";
            this.btnBolletta.Text = "N. bolletta";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 199);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(423, 96);
            this.gboxUPB.TabIndex = 8;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(7, 66);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(410, 20);
            this.txtUPB.TabIndex = 8;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(159, 11);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(258, 49);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 40);
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
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 293);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(423, 104);
            this.gboxBilAnnuale.TabIndex = 9;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treeeupb.(idupb=\'0001\')";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(6, 40);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(147, 16);
            this.chkListTitle.TabIndex = 12;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            this.chkListTitle.CheckedChanged += new System.EventHandler(this.chkListTitle_CheckedChanged);
            // 
            // chkListManager
            // 
            this.chkListManager.Location = new System.Drawing.Point(6, 24);
            this.chkListManager.Name = "chkListManager";
            this.chkListManager.Size = new System.Drawing.Size(145, 16);
            this.chkListManager.TabIndex = 11;
            this.chkListManager.TabStop = false;
            this.chkListManager.Text = "Elenca per responsabile";
            this.chkListManager.CheckedChanged += new System.EventHandler(this.chkListManager_CheckedChanged);
            // 
            // chkFilterAvailable
            // 
            this.chkFilterAvailable.Checked = true;
            this.chkFilterAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterAvailable.Location = new System.Drawing.Point(6, 8);
            this.chkFilterAvailable.Name = "chkFilterAvailable";
            this.chkFilterAvailable.Size = new System.Drawing.Size(128, 16);
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
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 80);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(409, 20);
            this.txtCodiceBilancio.TabIndex = 2;
            this.txtCodiceBilancio.Tag = "finview.codefin?incomeview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(159, 6);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(258, 70);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // gboxDocumento
            // 
            this.gboxDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxDocumento.Controls.Add(this.label1);
            this.gboxDocumento.Controls.Add(this.cmbTipoDocumento);
            this.gboxDocumento.Controls.Add(this.txtNumDoc);
            this.gboxDocumento.Controls.Add(this.label8);
            this.gboxDocumento.Controls.Add(this.txtEsercDoc);
            this.gboxDocumento.Controls.Add(this.btnDocumento);
            this.gboxDocumento.Controls.Add(this.labelTipoDocumento);
            this.gboxDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.gboxDocumento.Location = new System.Drawing.Point(445, 262);
            this.gboxDocumento.Name = "gboxDocumento";
            this.gboxDocumento.Size = new System.Drawing.Size(370, 64);
            this.gboxDocumento.TabIndex = 14;
            this.gboxDocumento.TabStop = false;
            this.gboxDocumento.Text = "Documento da contabilizzare";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Eserc.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDocumento.ItemHeight = 13;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(53, 16);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(309, 21);
            this.cmbTipoDocumento.TabIndex = 1;
            this.cmbTipoDocumento.Tag = "";
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumentoGenerico_SelectedIndexChanged);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(240, 40);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(122, 20);
            this.txtNumDoc.TabIndex = 4;
            this.txtNumDoc.Leave += new System.EventHandler(this.txtNumDoc_Leave);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(208, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Num.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(157, 40);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.Size = new System.Drawing.Size(47, 20);
            this.txtEsercDoc.TabIndex = 2;
            this.txtEsercDoc.Leave += new System.EventHandler(this.txtEsercDoc_Leave);
            // 
            // btnDocumento
            // 
            this.btnDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumento.Location = new System.Drawing.Point(8, 40);
            this.btnDocumento.Name = "btnDocumento";
            this.btnDocumento.Size = new System.Drawing.Size(108, 20);
            this.btnDocumento.TabIndex = 0;
            this.btnDocumento.TabStop = false;
            this.btnDocumento.Text = "Documento";
            this.btnDocumento.Click += new System.EventHandler(this.btnDocumento_Click);
            // 
            // labelTipoDocumento
            // 
            this.labelTipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelTipoDocumento.Location = new System.Drawing.Point(15, 16);
            this.labelTipoDocumento.Name = "labelTipoDocumento";
            this.labelTipoDocumento.Size = new System.Drawing.Size(32, 16);
            this.labelTipoDocumento.TabIndex = 6;
            this.labelTipoDocumento.Text = "Tipo";
            this.labelTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCausale
            // 
            this.labelCausale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.labelCausale.Location = new System.Drawing.Point(442, 234);
            this.labelCausale.Name = "labelCausale";
            this.labelCausale.Size = new System.Drawing.Size(47, 23);
            this.labelCausale.TabIndex = 77;
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
            this.cmbCausale.Location = new System.Drawing.Point(495, 240);
            this.cmbCausale.Name = "cmbCausale";
            this.cmbCausale.Size = new System.Drawing.Size(320, 21);
            this.cmbCausale.TabIndex = 13;
            this.cmbCausale.ValueMember = "idtipo";
            this.cmbCausale.SelectedIndexChanged += new System.EventHandler(this.cmbCausale_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(442, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 23);
            this.label9.TabIndex = 81;
            this.label9.Text = "Tipo contabilizzazione";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTipoContabilizzazione
            // 
            this.cmbTipoContabilizzazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoContabilizzazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoContabilizzazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.cmbTipoContabilizzazione.ItemHeight = 13;
            this.cmbTipoContabilizzazione.Location = new System.Drawing.Point(563, 216);
            this.cmbTipoContabilizzazione.Name = "cmbTipoContabilizzazione";
            this.cmbTipoContabilizzazione.Size = new System.Drawing.Size(252, 21);
            this.cmbTipoContabilizzazione.TabIndex = 12;
            this.cmbTipoContabilizzazione.SelectedIndexChanged += new System.EventHandler(this.cmbTipoContabilizzazione_SelectedIndexChanged);
            // 
            // btnGerarchia
            // 
            this.btnGerarchia.Location = new System.Drawing.Point(660, 475);
            this.btnGerarchia.Name = "btnGerarchia";
            this.btnGerarchia.Size = new System.Drawing.Size(64, 20);
            this.btnGerarchia.TabIndex = 16;
            this.btnGerarchia.TabStop = false;
            this.btnGerarchia.Text = "Gerarchia";
            this.btnGerarchia.Click += new System.EventHandler(this.btnGerarchia_Click);
            // 
            // btnSituazioneMovimentoSpesa
            // 
            this.btnSituazioneMovimentoSpesa.Location = new System.Drawing.Point(564, 475);
            this.btnSituazioneMovimentoSpesa.Name = "btnSituazioneMovimentoSpesa";
            this.btnSituazioneMovimentoSpesa.Size = new System.Drawing.Size(64, 20);
            this.btnSituazioneMovimentoSpesa.TabIndex = 15;
            this.btnSituazioneMovimentoSpesa.TabStop = false;
            this.btnSituazioneMovimentoSpesa.Text = "Situazione";
            this.btnSituazioneMovimentoSpesa.Click += new System.EventHandler(this.btnSituazioneMovimentoSpesa_Click);
            // 
            // gboxFasePrecedente
            // 
            this.gboxFasePrecedente.Controls.Add(this.btnFasePrecedente);
            this.gboxFasePrecedente.Controls.Add(this.txtNumeroFasePrecedente);
            this.gboxFasePrecedente.Controls.Add(this.label5);
            this.gboxFasePrecedente.Controls.Add(this.txtEsercizioFasePrecedente);
            this.gboxFasePrecedente.Controls.Add(this.label6);
            this.gboxFasePrecedente.Location = new System.Drawing.Point(8, 0);
            this.gboxFasePrecedente.Name = "gboxFasePrecedente";
            this.gboxFasePrecedente.Size = new System.Drawing.Size(423, 40);
            this.gboxFasePrecedente.TabIndex = 1;
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
            this.btnFasePrecedente.Size = new System.Drawing.Size(201, 20);
            this.btnFasePrecedente.TabIndex = 0;
            this.btnFasePrecedente.TabStop = false;
            this.btnFasePrecedente.Text = "Accertamento:";
            this.btnFasePrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFasePrecedente.Click += new System.EventHandler(this.btnFasePrecedente_Click);
            // 
            // txtNumeroFasePrecedente
            // 
            this.txtNumeroFasePrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroFasePrecedente.Location = new System.Drawing.Point(343, 16);
            this.txtNumeroFasePrecedente.Name = "txtNumeroFasePrecedente";
            this.txtNumeroFasePrecedente.Size = new System.Drawing.Size(71, 20);
            this.txtNumeroFasePrecedente.TabIndex = 2;
            this.txtNumeroFasePrecedente.Leave += new System.EventHandler(this.txtNumeroFasePrecedente_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(289, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Num.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizioFasePrecedente
            // 
            this.txtEsercizioFasePrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEsercizioFasePrecedente.Location = new System.Drawing.Point(249, 16);
            this.txtEsercizioFasePrecedente.Name = "txtEsercizioFasePrecedente";
            this.txtEsercizioFasePrecedente.Size = new System.Drawing.Size(40, 20);
            this.txtEsercizioFasePrecedente.TabIndex = 1;
            this.txtEsercizioFasePrecedente.Leave += new System.EventHandler(this.txtEsercizioFasePrecedente_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(215, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Es.:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCredDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(437, 173);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(378, 40);
            this.groupCredDeb.TabIndex = 7;
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
            this.txtCredDeb.Size = new System.Drawing.Size(362, 20);
            this.txtCredDeb.TabIndex = 1;
            this.txtCredDeb.Tag = "registry.title?incomeview.registry";
            // 
            // tabClassSup
            // 
            this.tabClassSup.Controls.Add(this.btnGeneraClassAutomatiche);
            this.tabClassSup.Controls.Add(this.DGridClassificazioni);
            this.tabClassSup.Controls.Add(this.groupBox15);
            this.tabClassSup.Controls.Add(this.label3);
            this.tabClassSup.ImageIndex = 1;
            this.tabClassSup.Location = new System.Drawing.Point(4, 23);
            this.tabClassSup.Name = "tabClassSup";
            this.tabClassSup.Size = new System.Drawing.Size(823, 503);
            this.tabClassSup.TabIndex = 1;
            this.tabClassSup.Text = "Classificazioni";
            this.tabClassSup.Enter += new System.EventHandler(this.tabClassSup_Enter);
            // 
            // btnGeneraClassAutomatiche
            // 
            this.btnGeneraClassAutomatiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraClassAutomatiche.Location = new System.Drawing.Point(623, 8);
            this.btnGeneraClassAutomatiche.Name = "btnGeneraClassAutomatiche";
            this.btnGeneraClassAutomatiche.Size = new System.Drawing.Size(192, 23);
            this.btnGeneraClassAutomatiche.TabIndex = 34;
            this.btnGeneraClassAutomatiche.Text = "Genera Classificazioni automatiche";
            this.btnGeneraClassAutomatiche.Click += new System.EventHandler(this.btnGeneraClassAutomatiche_Click);
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.gboxDettInvoice);
            this.tabDetails.Controls.Add(this.gboxDettEstimate);
            this.tabDetails.Location = new System.Drawing.Point(4, 23);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Size = new System.Drawing.Size(823, 503);
            this.tabDetails.TabIndex = 6;
            this.tabDetails.Text = "Dettagli";
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
            this.gboxDettInvoice.Location = new System.Drawing.Point(8, 216);
            this.gboxDettInvoice.Name = "gboxDettInvoice";
            this.gboxDettInvoice.Size = new System.Drawing.Size(807, 277);
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
            this.txtTotInvoiceDetail.Location = new System.Drawing.Point(3, 249);
            this.txtTotInvoiceDetail.Name = "txtTotInvoiceDetail";
            this.txtTotInvoiceDetail.ReadOnly = true;
            this.txtTotInvoiceDetail.Size = new System.Drawing.Size(80, 20);
            this.txtTotInvoiceDetail.TabIndex = 6;
            this.txtTotInvoiceDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Location = new System.Drawing.Point(3, 233);
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
            this.dgrDettagliFattura.Size = new System.Drawing.Size(703, 253);
            this.dgrDettagliFattura.TabIndex = 2;
            // 
            // gboxDettEstimate
            // 
            this.gboxDettEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxDettEstimate.Controls.Add(this.btnEditEstimDet);
            this.gboxDettEstimate.Controls.Add(this.txtTotEstimateDetail);
            this.gboxDettEstimate.Controls.Add(this.label2);
            this.gboxDettEstimate.Controls.Add(this.btnRemoveDetEstimate);
            this.gboxDettEstimate.Controls.Add(this.dgrDettagliContratto);
            this.gboxDettEstimate.Controls.Add(this.btnAddDetEstimate);
            this.gboxDettEstimate.Location = new System.Drawing.Point(8, 8);
            this.gboxDettEstimate.Name = "gboxDettEstimate";
            this.gboxDettEstimate.Size = new System.Drawing.Size(807, 208);
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
            this.txtTotEstimateDetail.Location = new System.Drawing.Point(8, 168);
            this.txtTotEstimateDetail.Name = "txtTotEstimateDetail";
            this.txtTotEstimateDetail.ReadOnly = true;
            this.txtTotEstimateDetail.Size = new System.Drawing.Size(80, 20);
            this.txtTotEstimateDetail.TabIndex = 4;
            this.txtTotEstimateDetail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Totale";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dgrDettagliContratto.Size = new System.Drawing.Size(703, 184);
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
            this.tabIncasso.Size = new System.Drawing.Size(822, 503);
            this.tabIncasso.TabIndex = 2;
            this.tabIncasso.Text = "Reversale";
            // 
            // SubEntity_chkIncassoNetto
            // 
            this.SubEntity_chkIncassoNetto.Enabled = false;
            this.SubEntity_chkIncassoNetto.Location = new System.Drawing.Point(249, 139);
            this.SubEntity_chkIncassoNetto.Name = "SubEntity_chkIncassoNetto";
            this.SubEntity_chkIncassoNetto.Size = new System.Drawing.Size(560, 20);
            this.SubEntity_chkIncassoNetto.TabIndex = 98;
            this.SubEntity_chkIncassoNetto.Tag = "incomelast.flag:5?incomeview.flag:5";
            this.SubEntity_chkIncassoNetto.Text = "Incasso da regolarizzare al netto delle spese accessorie (usare strumento bollett" +
    "e multiple)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTotale);
            this.groupBox2.Controls.Add(this.txtTotaleSospesi);
            this.groupBox2.Controls.Add(this.btnMultipleBillSel);
            this.groupBox2.Controls.Add(this.labBollette2);
            this.groupBox2.Controls.Add(this.labBollette1);
            this.groupBox2.Controls.Add(this.btnAddBolletta);
            this.groupBox2.Controls.Add(this.btnDelBolletta);
            this.groupBox2.Controls.Add(this.btnEditBolletta);
            this.groupBox2.Controls.Add(this.dgridBollette);
            this.groupBox2.Location = new System.Drawing.Point(8, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 341);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Collegamento multiplo con bollette";
            // 
            // lbTotale
            // 
            this.lbTotale.AutoSize = true;
            this.lbTotale.Location = new System.Drawing.Point(627, 44);
            this.lbTotale.Name = "lbTotale";
            this.lbTotale.Size = new System.Drawing.Size(77, 13);
            this.lbTotale.TabIndex = 37;
            this.lbTotale.Text = "Totale Sospesi";
            // 
            // txtTotaleSospesi
            // 
            this.txtTotaleSospesi.Location = new System.Drawing.Point(710, 41);
            this.txtTotaleSospesi.Name = "txtTotaleSospesi";
            this.txtTotaleSospesi.Size = new System.Drawing.Size(91, 20);
            this.txtTotaleSospesi.TabIndex = 36;
            // 
            // btnMultipleBillSel
            // 
            this.btnMultipleBillSel.Location = new System.Drawing.Point(5, 221);
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
            this.labBollette2.Location = new System.Drawing.Point(63, 44);
            this.labBollette2.Name = "labBollette2";
            this.labBollette2.Size = new System.Drawing.Size(566, 13);
            this.labBollette2.TabIndex = 34;
            this.labBollette2.Text = "Per utilizzare il collegamento multiplo con le bollette è necessario non selezion" +
    "are una bolletta nella maschera principale";
            // 
            // labBollette1
            // 
            this.labBollette1.AutoSize = true;
            this.labBollette1.Location = new System.Drawing.Point(63, 16);
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
            this.dgridBollette.Size = new System.Drawing.Size(715, 265);
            this.dgridBollette.TabIndex = 29;
            this.dgridBollette.Tag = "incomebill.list.default";
            // 
            // SubEntity_chbDestinazioneVincolata
            // 
            this.SubEntity_chbDestinazioneVincolata.Enabled = false;
            this.SubEntity_chbDestinazioneVincolata.Location = new System.Drawing.Point(33, 139);
            this.SubEntity_chbDestinazioneVincolata.Name = "SubEntity_chbDestinazioneVincolata";
            this.SubEntity_chbDestinazioneVincolata.Size = new System.Drawing.Size(138, 16);
            this.SubEntity_chbDestinazioneVincolata.TabIndex = 95;
            this.SubEntity_chbDestinazioneVincolata.Tag = "incomelast.flag:4?incomeview.flag:4";
            this.SubEntity_chbDestinazioneVincolata.Text = "Destinazione vincolata";
            // 
            // grpModRiscossione
            // 
            this.grpModRiscossione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpModRiscossione.Controls.Add(this.SubEntity_chkAccreditoTPS);
            this.grpModRiscossione.Controls.Add(this.SubEntity_chkPrelievodaCCP);
            this.grpModRiscossione.Controls.Add(this.SubEntity_chkCassa);
            this.grpModRiscossione.Location = new System.Drawing.Point(8, 70);
            this.grpModRiscossione.Name = "grpModRiscossione";
            this.grpModRiscossione.Size = new System.Drawing.Size(806, 48);
            this.grpModRiscossione.TabIndex = 94;
            this.grpModRiscossione.TabStop = false;
            this.grpModRiscossione.Text = "Modalità di riscossione";
            // 
            // SubEntity_chkAccreditoTPS
            // 
            this.SubEntity_chkAccreditoTPS.AutoSize = true;
            this.SubEntity_chkAccreditoTPS.Location = new System.Drawing.Point(241, 19);
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
            this.SubEntity_chkPrelievodaCCP.Location = new System.Drawing.Point(115, 19);
            this.SubEntity_chkPrelievodaCCP.Name = "SubEntity_chkPrelievodaCCP";
            this.SubEntity_chkPrelievodaCCP.Size = new System.Drawing.Size(103, 17);
            this.SubEntity_chkPrelievodaCCP.TabIndex = 11;
            this.SubEntity_chkPrelievodaCCP.Tag = "incomelast.flag:2?incomeview.flag:2";
            this.SubEntity_chkPrelievodaCCP.Text = "Prelievo da CCP";
            this.SubEntity_chkPrelievodaCCP.UseVisualStyleBackColor = true;
            this.SubEntity_chkPrelievodaCCP.CheckedChanged += new System.EventHandler(this.SubEntity_chkPrelievodaCCP_CheckedChanged);
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
            this.textBox1.Location = new System.Drawing.Point(167, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(647, 56);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "il numero della reversale di incasso viene riempito solo quando verrà emessa la r" +
    "eversale da associare al movimento di entrata";
            // 
            // tabAssCrediti
            // 
            this.tabAssCrediti.Controls.Add(this.gboxCrediti);
            this.tabAssCrediti.Location = new System.Drawing.Point(4, 23);
            this.tabAssCrediti.Name = "tabAssCrediti";
            this.tabAssCrediti.Size = new System.Drawing.Size(823, 503);
            this.tabAssCrediti.TabIndex = 4;
            this.tabAssCrediti.Text = "Assegnazione credito";
            // 
            // gboxCrediti
            // 
            this.gboxCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCrediti.Controls.Add(this.GridCrediti);
            this.gboxCrediti.Controls.Add(this.button4);
            this.gboxCrediti.Controls.Add(this.button5);
            this.gboxCrediti.Controls.Add(this.button6);
            this.gboxCrediti.Controls.Add(this.txtImportoAssegnareCrediti);
            this.gboxCrediti.Controls.Add(this.label4);
            this.gboxCrediti.Location = new System.Drawing.Point(8, 0);
            this.gboxCrediti.Name = "gboxCrediti";
            this.gboxCrediti.Size = new System.Drawing.Size(807, 497);
            this.gboxCrediti.TabIndex = 14;
            this.gboxCrediti.TabStop = false;
            // 
            // tabAssIncassi
            // 
            this.tabAssIncassi.Controls.Add(this.gboxIncassi);
            this.tabAssIncassi.Location = new System.Drawing.Point(4, 23);
            this.tabAssIncassi.Name = "tabAssIncassi";
            this.tabAssIncassi.Size = new System.Drawing.Size(823, 503);
            this.tabAssIncassi.TabIndex = 5;
            this.tabAssIncassi.Text = "Assegnazione di cassa";
            // 
            // gboxIncassi
            // 
            this.gboxIncassi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxIncassi.Controls.Add(this.btnCopiaAssegnazioneCrediti);
            this.gboxIncassi.Controls.Add(this.dataGrid2);
            this.gboxIncassi.Controls.Add(this.button8);
            this.gboxIncassi.Controls.Add(this.button9);
            this.gboxIncassi.Controls.Add(this.button7);
            this.gboxIncassi.Controls.Add(this.txtImportoAssegnareIncassi);
            this.gboxIncassi.Controls.Add(this.label7);
            this.gboxIncassi.Location = new System.Drawing.Point(8, 0);
            this.gboxIncassi.Name = "gboxIncassi";
            this.gboxIncassi.Size = new System.Drawing.Size(807, 500);
            this.gboxIncassi.TabIndex = 17;
            this.gboxIncassi.TabStop = false;
            // 
            // btnCopiaAssegnazioneCrediti
            // 
            this.btnCopiaAssegnazioneCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopiaAssegnazioneCrediti.Location = new System.Drawing.Point(180, 462);
            this.btnCopiaAssegnazioneCrediti.Name = "btnCopiaAssegnazioneCrediti";
            this.btnCopiaAssegnazioneCrediti.Size = new System.Drawing.Size(253, 23);
            this.btnCopiaAssegnazioneCrediti.TabIndex = 17;
            this.btnCopiaAssegnazioneCrediti.Text = "Copia da assegnazioni crediti";
            this.btnCopiaAssegnazioneCrediti.UseVisualStyleBackColor = true;
            this.btnCopiaAssegnazioneCrediti.Click += new System.EventHandler(this.btnCopiaAssegnazioneCrediti_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblcup);
            this.tabPage1.Controls.Add(this.txtcup);
            this.tabPage1.Controls.Add(this.grpContocredito);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 503);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Altro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblcup
            // 
            this.lblcup.Location = new System.Drawing.Point(13, 116);
            this.lblcup.Name = "lblcup";
            this.lblcup.Size = new System.Drawing.Size(173, 23);
            this.lblcup.TabIndex = 47;
            this.lblcup.Tag = "";
            this.lblcup.Text = "Codice Unico di Progetto (CUP)";
            this.lblcup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcup
            // 
            this.txtcup.Location = new System.Drawing.Point(13, 140);
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
            this.grpContocredito.Location = new System.Drawing.Point(8, 31);
            this.grpContocredito.Name = "grpContocredito";
            this.grpContocredito.Size = new System.Drawing.Size(430, 72);
            this.grpContocredito.TabIndex = 1;
            this.grpContocredito.TabStop = false;
            this.grpContocredito.Tag = "AutoChoose.txtCodiceContoCustomer.default.((flagaccountusage&48)<>0)";
            this.grpContocredito.Text = "Conto EP  per il credito";
            // 
            // txtDescrContoCustomer
            // 
            this.txtDescrContoCustomer.Location = new System.Drawing.Point(199, 14);
            this.txtDescrContoCustomer.Multiline = true;
            this.txtDescrContoCustomer.Name = "txtDescrContoCustomer";
            this.txtDescrContoCustomer.ReadOnly = true;
            this.txtDescrContoCustomer.Size = new System.Drawing.Size(225, 52);
            this.txtDescrContoCustomer.TabIndex = 2;
            this.txtDescrContoCustomer.TabStop = false;
            this.txtDescrContoCustomer.Tag = "account.title";
            // 
            // txtCodiceContoCustomer
            // 
            this.txtCodiceContoCustomer.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceContoCustomer.Name = "txtCodiceContoCustomer";
            this.txtCodiceContoCustomer.Size = new System.Drawing.Size(185, 20);
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
            // Frm_income_procedura
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_income_procedura";
            this.Text = "FrmEntrataProcedura";
            this.grpReversaleIncasso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipoConto.ResumeLayout(false);
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridDettagliClassificazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridClassificazioni)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridCrediti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabMovFin.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxBolletta.ResumeLayout(false);
            this.gboxBolletta.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxDocumento.ResumeLayout(false);
            this.gboxDocumento.PerformLayout();
            this.gboxFasePrecedente.ResumeLayout(false);
            this.gboxFasePrecedente.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.tabClassSup.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.gboxDettInvoice.ResumeLayout(false);
            this.gboxDettInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFattura)).EndInit();
            this.gboxDettEstimate.ResumeLayout(false);
            this.gboxDettEstimate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliContratto)).EndInit();
            this.tabIncasso.ResumeLayout(false);
            this.tabIncasso.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridBollette)).EndInit();
            this.grpModRiscossione.ResumeLayout(false);
            this.grpModRiscossione.PerformLayout();
            this.tabAssCrediti.ResumeLayout(false);
            this.gboxCrediti.ResumeLayout(false);
            this.gboxCrediti.PerformLayout();
            this.tabAssIncassi.ResumeLayout(false);
            this.gboxIncassi.ResumeLayout(false);
            this.gboxIncassi.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpContocredito.ResumeLayout(false);
            this.grpContocredito.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		bool faseIvaInclusa(){
			return (faseiva>=faseinizio) && (faseiva<=faseentratafine);
		}
		bool faseEntrataInclusa(){
			return (faseentrata>=faseinizio) && (faseentrata<=faseentratafine);
		}
		bool faseContrattoInclusa(){
			return (fasecontratto>=faseinizio) && (fasecontratto<=faseentratafine);
		}

		#region Gestione Abilitazione Crediti/Incassi
		void EnableDisableCrediti(bool enable){
			gboxCrediti.Enabled=enable;
			gboxIncassi.Enabled=enable;
		}

		void EnableDisableCrediti(){
            if (Meta.IsEmpty) {
                EnableDisableCrediti(false);
                return;
            }

            object getupb = GetUpb();
			if (getupb==DBNull.Value){
				EnableDisableCrediti(false);
				return;
			}
            string filterupb = QHC.CmpEq("idupb", getupb);
            if (DS.upb.Select(filterupb).Length == 0) {
                EnableDisableCrediti(false);
                return;
            }
                
			DataRow UPB = DS.upb.Select(filterupb)[0];
			if (UPB["assured"].ToString().ToUpper()=="S"){
				EnableDisableCrediti(false);
			}
			else {
				EnableDisableCrediti(true);
			}
		}

		#endregion



		
		#region Gestione del'abilitazione e disabilitazione dei controlli.

		void AddTab(TabPage Tab,bool redraw) {
			if (tabControl1.TabPages.Contains(Tab)) return;
			tabControl1.TabPages.Add(Tab);
			if (Meta.IsEmpty) {
				Meta.myHelpForm.ClearControls(Tab.Controls);
			}
			else {
				if (redraw) Meta.myHelpForm.FillControls(Tab.Controls);
			}
		}

		void AddRemoveTab(TabPage Tab, bool Add,bool redraw){
			if (Add){
				AddTab(Tab,redraw);
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
		void AddRemoveTabs(bool redraw){
			InsideAdRemoveTabs=true;
			bool ultimafase = (faseMaxInclusa());
			bool fasecontratto= faseContrattoInclusa();
			bool faseiva  = faseIvaInclusa();
			int fasebil = ManageBilAnnuale.faseattivazione;
			bool fasebilinclusa = (faseinizio<=fasebil) && (fasebil<=fasefine);
			tabControl1.SuspendLayout();
			int currsel = tabControl1.SelectedIndex;
			AddRemoveTab(tabDetails,fasecontratto||faseiva,redraw);
			AddRemoveTab(tabAssCrediti, fasebilinclusa,redraw);
			AddRemoveTab(tabAssIncassi, ultimafase,redraw);
			AddRemoveTab(tabIncasso, ultimafase,redraw);
			if (tabControl1.SelectedIndex!=currsel) tabControl1.SelectedIndex= currsel;
			tabControl1.ResumeLayout();
			InsideAdRemoveTabs=false;
		}

		/// <summary>
		/// Abilita/Disabilita/Svuota controlli e dati in base alle fasi operative
		/// </summary>
		void ApplicaLogicaSuFase(){
			if (Meta.IsEmpty) return;
			
			if (faseinizio > 1) {
				btnFasePrecedente.Text= chkListaFasi.Items[faseinizio-2].ToString();
				chbAzzeramento.Enabled=true;
				if (txtEsercizioFasePrecedente.Text=="")
					txtEsercizioFasePrecedente.Text= Meta.GetSys("esercizio").ToString();
			}	   
			else {
				chbAzzeramento.Enabled=false;
				txtEsercizioFasePrecedente.Text="";
			}

			if ((faseinizio==1) && (fasefine==1)){
				//txtEsercizioMovimento.ReadOnly= false; 
				//il contenuto dell'esercizio rimane invariato
			}
			else {
				//txtEsercizioMovimento.ReadOnly=true;
//				txtEsercizioMovimento.Text=
//					DS.income.Columns["ymov"].DefaultValue.ToString();
				txtEsercizioFasePrecedente.ReadOnly=true;
			}					

			btnInsertClass.Enabled= !Meta.IsEmpty;
			btnDelClass.Enabled= !Meta.IsEmpty;
			btnEditClass.Enabled= !Meta.IsEmpty;
			btnSituazioneMovimentoSpesa.Enabled = Meta.EditMode;;
			btnGerarchia.Enabled= Meta.EditMode;
			
			gboxFasePrecedente.Visible = (faseinizio>1);
//			gboxMovimento.Visible= (faseinizio==1);

			//txtEsercizioMovimento.ReadOnly= false;
			txtEsercizioFasePrecedente.ReadOnly= false;
			txtNumeroFasePrecedente.ReadOnly=false;
			btnFasePrecedente.Enabled=true;
			if (faseIvaInclusa()){ 
				gboxDettInvoice.Visible=true;
			}
			else {
				gboxDettInvoice.Visible=false;
			}
			if (faseContrattoInclusa()){
				gboxDettEstimate.Visible=true;
			}
			else {
				gboxDettEstimate.Visible=false;
			} 
			ManageBilAnnuale.AbilitaDisabilita(faseinizio,fasefine);
			ManageUPB.AbilitaDisabilita(faseinizio,fasefine);
			ManageCreditore.AbilitaDisabilita(faseinizio,fasefine);

			if (ManageUPB.AttualmenteAttivo){
                object getupb = GetUpb();
				if (Meta.InsertMode && getupb==DBNull.Value){
                    SetUPB(GetDefaultForUpb());
				}
			}
          

			bool ultimafase = faseMaxInclusa();
			if (!ultimafase) {
				SubEntity_chbCoperturaIniziativa.Checked=false;
				SubEntity_txtBolletta.Text="";
			}
			
			btnAddDetEstimate.Enabled= (currcont==tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnRemoveDetEstimate.Enabled= (currcont==tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnEditEstimDet.Enabled=(currcont==tipocont.cont_estimate) && (!Meta.IsEmpty) && faseContrattoInclusa();
			btnAddDettInvoice.Enabled= (currcont==tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
			btnRemoveDettInvoice.Enabled= (currcont==tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();
			btnEditInvDet.Enabled= (currcont==tipocont.cont_iva) && (!Meta.IsEmpty) && faseIvaInclusa();

			txtNumMandato.ReadOnly			= true;
//			txtEsercMovBancario.ReadOnly	= true;
//			txtNumMovBancario.ReadOnly		= true;
			grpReversaleIncasso.Visible = (fasefine>faseentratamax);

			SubEntity_chbCoperturaIniziativa.Enabled  = ultimafase;
            SubEntity_chbDestinazioneVincolata.Enabled = ultimafase;
			gboxIncassi.Enabled				= ultimafase;

            if (Meta.IsEmpty)
            {
                ImpostaModalitaRiscossione(null, false);
            }
            else
            {
                if (DS.registry.Rows.Count > 0)
                {
                    DataRow R = DS.registry.Rows[0];
                    if (Meta.InsertMode)
                    {
                        ImpostaModalitaRiscossione(R, true);
                    }
                    else
                    {
                        ImpostaModalitaRiscossione(R, false);
                    }
                }
                else
                {
                    ImpostaModalitaRiscossione(null, false);
                }
            }


			int fasebil = ManageBilAnnuale.faseattivazione;
			bool fasebilpresente = (faseinizio<=fasebil) && (fasebil<=faseentratafine);
			gboxCrediti.Enabled=fasebilpresente;
	
			GestioneFasePerDocumentoCollegato();
            grpContocredito.Visible = ultimafase;

            int ImpegnoGiuridico = CfgFn.GetNoNullInt32(Meta.GetSys("incomeregphase"));
            if ((faseinizio <= ImpegnoGiuridico) && (ImpegnoGiuridico <= fasefine)){
                lblcup.Visible = true;
                txtcup.Visible = true;
            }
            else{
                lblcup.Visible = false;
                txtcup.Visible = false;
            }

            btnFinanziamento.Enabled = fasebilpresente;
            txtFinanziamento.ReadOnly = !fasebilpresente;

            AddRemoveTab(tabAssCrediti,  UsaCrediti(), true);
            AddRemoveTab(tabAssIncassi, UsaCassa(), true);
            if (UsaCassa()){
                if (ManageUPB.AttualmenteAttivo && faseMaxInclusa() && UsaCrediti()) {
                    btnCopiaAssegnazioneCrediti.Visible = true;
                }
                else {
                    btnCopiaAssegnazioneCrediti.Visible = false;
                }
            }
		}

        void ImpostaModalitaRiscossione(DataRow R, bool mustUpdateValues)
        {

            if ((R == null) &&  !(faseMaxInclusa()))
            {
                grpModRiscossione.Visible = false;
                SubEntity_chkCassa.Enabled = false;
                SubEntity_chkPrelievodaCCP.Enabled = false;
                SubEntity_chkAccreditoTPS.Enabled = false;
                return;
            }
            else
            {
                if ((R == null) && faseMaxInclusa())
                {
                    grpModRiscossione.Visible = true;
                    SubEntity_chkCassa.Enabled = true;
                    SubEntity_chkPrelievodaCCP.Enabled = true;
                    SubEntity_chkAccreditoTPS.Enabled = true;
                    return;
                }
            }
            if ((R != null) && faseMaxInclusa())
            {
                grpModRiscossione.Visible = true;
                SubEntity_chkCassa.Enabled = true;
                SubEntity_chkPrelievodaCCP.Enabled = true;
                SubEntity_chkAccreditoTPS.Enabled = true;

                object ccp = R["ccp"];
                object flagbankitaliaproceeds = R["flagbankitaliaproceeds"];

                if ((mustUpdateValues) && (ccp.ToString() == "") &&
                   ((flagbankitaliaproceeds == DBNull.Value) ||
                    (flagbankitaliaproceeds.ToString() != "S")))
                {
                    SubEntity_chkCassa.Checked = true;
                }

                if (ccp.ToString() != "")
                {
                    SubEntity_chkPrelievodaCCP.Enabled = true;
                    if (mustUpdateValues) SubEntity_chkPrelievodaCCP.Checked = true;
                }
                else
                {
                    SubEntity_chkPrelievodaCCP.Enabled = false;
                }

                if ((flagbankitaliaproceeds != DBNull.Value) &&
                    (flagbankitaliaproceeds.ToString() == "S"))
                    if (mustUpdateValues) SubEntity_chkAccreditoTPS.Checked = true;
            }
        }

	
		bool faseMaxInclusa(){
			return (faseentratamax>=faseinizio)&& (faseentratamax<=faseentratafine);
		}




		void AbilitaDisabilitaRiferimentiBancari(){
			bool abilita=false;
			//if (Meta.IsEmpty) abilita=true;

			txtNumMandato.ReadOnly			= !abilita;
//			txtEsercMovBancario.ReadOnly	= !abilita;
//			txtNumMovBancario.ReadOnly		= !abilita;
		}


		
		/// <summary>
		/// groupCredDeb
		/// txtCredDeb

		#endregion

        void SetResponsabile(object idman) {
            Meta.SetAutoField(idman, txtResponsabile);
        }

        void SetUPB(object idupb) {
            Meta.SetAutoField(idupb, txtUPB );
            
        }

        object GetResponsabile() {
            return Meta.GetAutoField(txtResponsabile);
        }

        object GetUpb() {
            return Meta.GetAutoField(txtUPB);

        }



		void GestisciNumBolletta(){
			MetaData.AutoInfo AI =  Meta.GetAutoInfo(SubEntity_txtBolletta.Name);
			if (AI==null){
				Meta.SetAutoMode(gboxBolletta);
				AI =  Meta.GetAutoInfo(SubEntity_txtBolletta.Name);
			}

			if (Meta.IsEmpty){
				if (AI!=null) AI.startfilter=null; //Elimina il filtro su flagattivo
				btnBolletta.Enabled=true;
				SubEntity_txtBolletta.ReadOnly=!SubEntity_chbCoperturaIniziativa.Checked;
                SubEntity_chkIncassoNetto.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
                btnMultipleBillSel.Visible = false;
                GestisciBolletteMultiple();
				return;
			}
            if (fasefine < faseentratamax) {
                SubEntity_txtBolletta.ReadOnly = true;
                btnBolletta.Enabled = false;
                btnMultipleBillSel.Visible = false;
                SubEntity_chkIncassoNetto.Enabled = false;
                GestisciBolletteMultiple();
                return;
            }
			if (Meta.InsertMode){
				if (AI!=null) AI.startfilter="(active='S')";
				SubEntity_txtBolletta.ReadOnly=!SubEntity_chbCoperturaIniziativa.Checked;
                btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
			    SubEntity_chkIncassoNetto.Enabled = false; //SubEntity_chbCoperturaIniziativa.Checked;
                btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
				if (!SubEntity_chbCoperturaIniziativa.Checked){
					SubEntity_txtBolletta.Text="";
				    SubEntity_chkIncassoNetto.Checked = false;
                    DataRow CurrR=DS.incomelast.Rows[0];
					CurrR["nbill"]=DBNull.Value;
				}
                GestisciBolletteMultiple();
				return;
			}
			if (AI!=null) AI.startfilter=null;
			DataRow Curr=DS.incomelast.Rows[0];
			if (Curr["kpro"]==DBNull.Value){
				SubEntity_txtBolletta.ReadOnly=!SubEntity_chbCoperturaIniziativa.Checked;
			    SubEntity_chkIncassoNetto.Enabled = false; //SubEntity_chbCoperturaIniziativa.Checked;
                btnBolletta.Enabled = SubEntity_chbCoperturaIniziativa.Checked;
                btnMultipleBillSel.Visible = SubEntity_chbCoperturaIniziativa.Checked;
				if (!SubEntity_chbCoperturaIniziativa.Checked){
					SubEntity_txtBolletta.Text="";
                    SubEntity_chkIncassoNetto.Checked = false;
                    DataRow CurrR=DS.incomelast.Rows[0];
					CurrR["nbill"]=DBNull.Value;
				}
			}
			else {
				SubEntity_txtBolletta.ReadOnly=true;
				btnBolletta.Enabled=false;
                SubEntity_chkIncassoNetto.Enabled = false;
                btnMultipleBillSel.Visible = false;
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
			FillCheckedListBox();
			lastimportofreshed=Decimal.MinValue;
			ResetIva();
			ResetEstimate();

			faseinizio=0;
			fasefine=0;
			PostData.MarkAsRealTable(DS.proceeds);
			DS.proceeds.Clear();

			if (ManageClassificazioni!=null) ManageClassificazioni.Clear();


			//Imposta la fase nel combobox
			ApplicaLogicaSuFase();

			GetData.UnCacheTable(DS.sortingkind);
			GetData.CanClear(DS.sortingkind);
			
			txtEsercizioFasePrecedente.Text = "";
			txtNumeroFasePrecedente.Text = "";
			chbAzzeramento.Checked=false;
            txtTotaleSospesi.Text = "";

            //txtEsercizioMovimento.ReadOnly=false;
            SubEntity_txtImportoMovimento.ReadOnly = false;

			ClearGridsData();

			if (Meta.GointToInsertMode) {
				Meta.CanSave=true;
			}


			if (!CanGoInsert)return;

			if (Meta.GointToInsertMode) {
				return;
			}

			CanGoInsert=false;
			MetaData.MainAdd(this);
			return;

		}

		#endregion

		#region AfterLink

        CQueryHelper QHC;
        QueryHelper QHS;

		void AfterLinkBody(){
			Meta.SearchEnabled=false;
			Meta.CanInsertCopy=false;
			MyConn = MetaData.GetConnection(this);
            QHS = MyConn.GetQueryHelper();
            QHC = new CQueryHelper();
            int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteresercizio = QHS.CmpEq("ayear", currEsercizio);
			GetData.CacheTable(DS.config, filteresercizio, null, false);
			GetData.SetStaticFilter(DS.incomeyear, filteresercizio);
			GetData.SetStaticFilter(DS.incomesorted, filteresercizio);
            GetData.SetStaticFilter(DS.account, filteresercizio);
            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.BitClear("flag", 0)));
			GetData.CacheTable(DS.expensephase,null,"nphase",false);
			GetData.CacheTable(DS.incomephase,null,"nphase",false);
			GetData.CacheTable(DS.treasurer,null,null,true);	//per poterla usare nel before activation
            GetData.SetStaticFilter(DS.treasurer, QHS.CmpEq("active", 'S'));
            GetData.CacheTable(DS.stamphandling, null, null, true);	//per poterla usare nel before activation
            GetData.CacheTable(DS.invoicekind, QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2)),
                null,true);
			GetData.CacheTable(DS.estimatekind,null,null,true);

			PostData.MarkAsTemporaryTable(DS.tipomovimento,false);
            string filterBill = QHS.AppAnd(QHS.CmpEq("billkind", "C"), QHS.CmpEq("ybill", currEsercizio));
            object idflowchart = Meta.GetSys("idflowchart");
            if (idflowchart != null && idflowchart != DBNull.Value) {
                int flagtreasurer = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("uniconfig", null, "(isnull(flag,0)&1)"));
                if (flagtreasurer != 0)
                    filterBill = QHS.AppAnd(filterBill, QHS.IsNotNull("idtreasurer"));
            }
            GetData.SetStaticFilter(DS.bill, filterBill);
            GetData.SetStaticFilter(DS.billview, filterBill);

            string filterInvoice = QHS.BitClear("flag", 2);
            GetData.SetStaticFilter(DS.invoicedetail_iva, filterInvoice);
            GetData.SetStaticFilter(DS.invoicedetail_taxable, filterInvoice);

            string filterstart = QHS.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
            string filterstop = QHS.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
            string filterestimatedetail_date = QHS.AppAnd(filterstart, filterstop);
            GetData.SetStaticFilter(DS.estimatedetail_iva, filterestimatedetail_date);
            GetData.SetStaticFilter(DS.estimatedetail_taxable, filterestimatedetail_date);
            GetData.SetStaticFilter(DS.stamphandling, QHS.CmpEq("active", 'S'));
		}

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			AfterLinkBody();
		}

		#endregion



		#region Gestione CheckedListBox delle fasi

		/// Se faseinizio==0-> nessuna fase è attualmente selezionata
		/// 

		/// <summary>
		/// Mette nel CheckedListBox gli ID calcolati (prendendoli da DSP)
		/// </summary>
		void FillPostedID(){
            string idreversale= "";
			//riempie gli ID movimento
            foreach (DataRow Rfase in DS.incomephase.Rows) {
                string searchmov = "(nphase='" + Rfase["nphase"].ToString() + "')";
                DataRow[] foundmovs = DSP.Tables["income"].Select(searchmov);
                if (foundmovs.Length == 0) continue;
                string nomefase = Rfase["description"].ToString();
                string idmov = foundmovs[0]["ymov"] + "-" + foundmovs[0]["nmov"];
                int idx = Convert.ToInt32(Rfase["nphase"]);
                chkListaFasi.Items[idx - 1] = nomefase + "(" + idmov + ")";
                if (idx == faseentratamax) {
                    object idinc = foundmovs[0]["idinc"];
                    DataRow[] IncomeLast = DSP.Tables["incomelast"].Select(QHC.CmpEq("idinc", idinc));
                    if (IncomeLast.Length > 0) {
                        DataRow rLast = IncomeLast[0];
                        if (rLast["kpro"] != DBNull.Value) {
                            DataRow P = DSP.Tables["proceeds"].Select(QHC.CmpEq("kpro", rLast["kpro"]))[0];
                            idreversale = P["ypro"].ToString() + "-" + P["npro"].ToString();
                            if (DS.incomelast.Rows.Count > 0) {
                                DS.incomelast.Rows[0]["idinc"] = rLast["idinc"];
                                DS.incomelast.Rows[0]["kpro"] = rLast["kpro"];
                            }
                            if (DS.proceeds.Rows.Count > 0) {
                                DS.proceeds.Rows[0]["kpro"] = P["kpro"];
                                DS.proceeds.Rows[0]["ypro"] = P["ypro"];
                                DS.proceeds.Rows[0]["npro"] = P["npro"];
                            }
                            DS.AcceptChanges();
                        }
                    }
                }
            }
			if (DSP.Tables["proceeds"].Rows.Count!=0 && (idreversale!= "") ){
				chkListaFasi.Items[faseentratamax]= "Reversale di Incasso ("+idreversale+")";
			}
			chkListaFasi.Enabled=false;
            chkListaFasi.ClearSelected();

		}


		/// <summary>
		/// Riempie il CheckedListBox. Assume la tabella fasispesa già letta.
		/// </summary>
		void FillCheckedListBox(){		
			chkListaFasi.Enabled=false;
			chkListaFasi.Items.Clear();
			chkListaFasi.Enabled=true;
			faseinizio=0;
			fasefine=0;
			foreach (DataRow Rfase in DS.incomephase.Rows){
				string nomefase = Rfase["description"].ToString();
				chkListaFasi.Items.Add(nomefase,false);
			}
			chkListaFasi.Items.Add("Reversale di Incasso", false);
		}


		private void chkListaFasi_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e) {
			if (Meta.IsEmpty) return;
			if (!chkListaFasi.Enabled)return;
			bool CredDebWasThere = (faseinizio<= ManageCreditore.faseattivazione)
				&& faseMaxInclusa();
			chkListaFasi.Enabled=false;
			chkListaFasi.SetItemCheckState(e.Index, e.NewValue);
			if (RicalcolaFasiInizioFine()){
				//se passa di qui è cambiata la fase iniziale-> azzera padre e molte
				// altre cose
				//AzzeraPadre();
				AzzeraDatiSuCambioFase();
			}
			AzzeraDatiFasiNonSelezionate();
			AddRemoveTabs(true);

			//ApplicaLogicaSufase() also clear idfin,
			//  idreg, idupb
			//  when needed
			ApplicaLogicaSuFase(); 
			
	
			ResetTipoClassAvailableEvalued();
			e.NewValue= chkListaFasi.GetItemCheckState(e.Index);
			chkListaFasi.Enabled=true;			
		}


		/// <summary>
		/// Ricalcola le fasi di inizio e fine e riempie quelle di mezzo
		/// Le fasi possibili vanno da 1 a fasespesamax+1
		/// FaseInizio==0 significa che nessuna fase è selezionata
		/// </summary>
		/// <returns>true se è cambiata la fase di inizio</returns>
		bool RicalcolaFasiInizioFine(){
			chkListaFasi.Enabled=false;

			int oldfaseinizio= faseinizio;
			faseinizio=0;    //default = nessuna fase selezionata 		
			fasefine=0;    //default = nessuna fase selezionata 				
			

			for ( int i=0; i< chkListaFasi.Items.Count; i++){
				if (chkListaFasi.GetItemCheckState(i)!=CheckState.Checked) continue;
				if (faseinizio==0)  faseinizio= i+1;
				if (fasefine < i+1) fasefine=i+1;
			}
			if (faseinizio>faseentratamax) faseinizio--;

			if (faseinizio>0){
				for (int j=faseinizio; j<=fasefine; j++)
					chkListaFasi.SetItemCheckState(j-1, CheckState.Checked);
			}
			chkListaFasi.Enabled=true;
			
			if (!Meta.IsEmpty){
				DataRow CurrEntrata= DS.income.Rows[0];			
				CurrEntrata["nphase"]= faseinizio;
			}

			DS.Tables["income"].ExtendedProperties["faseinizio"]=faseinizio;
			DS.Tables["income"].ExtendedProperties["fasefine"]=fasefine;
			DS.Tables["income"].ExtendedProperties["faseentratafine"]=faseentratafine;

			if (faseinizio!=oldfaseinizio) return true;
			return false;
		}



		

	


		#endregion


		#region Before/After Activation

		public void MetaData_BeforeActivation() {
			if (MustClose) return;
            faseentratamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
            fasespesamax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			if ((fasespesamax==0)||(faseentratamax==0)) {
				MessageBox.Show("Non è presente la configurazione delle entrate o delle spese");
				MustClose=true;
				return;
			}
			DS.Tables["income"].ExtendedProperties["faseentratamax"]= faseentratamax;

			MyConn = MetaData.GetConnection(this);
			string filteresercizio= "(ayear='"+Meta.GetSys("esercizio").ToString()+"')";
			
			ManageBilAnnuale = new GBoxManage(Meta,
				gboxBilAnnuale, 
				new Control[] {txtCodiceBilancio,txtDenominazioneBilancio},
				new Control[] {txtCodiceBilancio, btnBilancio},
				new string[] {"idfin"},
                CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase")),
                "fin", filteresercizio);
			DS.Tables["income"].ExtendedProperties["minfasebilannuale"]= 
				ManageBilAnnuale.faseattivazione;

			ManageUPB = new GBoxManage(Meta,
				gboxUPB, 
				new Control[] {txtUPB,txtDescrUPB},
                new Control[] { txtUPB, btnUPBCode },
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
			DS.Tables["income"].ExtendedProperties["minfasecreditore"]= 
				ManageCreditore.faseattivazione;


			ManageClassificazioni= new GestioneClassificazioni(Meta, 
				DGridClassificazioni, DGridDettagliClassificazioni,
				ManageBilAnnuale, ManageUPB, ManageCreditore, 
				btnEditClass, btnInsertClass, btnDelClass);

			DataRow PersEntrata= DS.Tables["config"].Rows[0];
            flagcreddeb = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 4);
            flagbilancio = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 2);
            flagrespons = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 16);
            flagresidui = CfgFn.DecodeToString(PersEntrata["proceeds_flag"], 8);
			fasecontratto = CfgFn.GetNoNullInt32( PersEntrata["incomephase"]);

			maxfasebil = Meta.Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), 
					"max(nlevel)").ToString();

            int flag_pro = CfgFn.GetNoNullInt32(DS.Tables["proceeds"].Columns["flag"].DefaultValue);
            flag_pro &= 0xF0;

            if (flagresidui == "S") {
                flag_pro |= 0x01;
            }
            else {
                flag_pro |= 0x04;
            }
            flag_pro |= 0x08;
            DS.proceeds.Columns["flag"].DefaultValue = flag_pro;

			DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
			if (cassiere.Length==1) MetaData.SetDefault(DS.proceeds, 
										"idtreasurer", 
										cassiere[0]["idtreasurer"]);


            DataRow[] bollo = DS.stamphandling.Select("flagdefault='S'");
            if (bollo.Length == 1) MetaData.SetDefault(DS.proceeds,
                                       "idstamphandling",
                                       bollo[0]["idstamphandling"]);

			faseiva=99;
			faseiva = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));

			faseentrata=99;
			if (PersEntrata["incomephase"]!=DBNull.Value) 
				faseentrata=CfgFn.GetNoNullInt32(PersEntrata["incomephase"]);

			DS.Tables["incomeinvoice"].ExtendedProperties["faseattivazione"]=faseiva;
			DS.Tables["incomeestimate"].ExtendedProperties["faseattivazione"]=faseentrata;

		}
        void CalcolaDefaultPerIstitutoCassiere() {
            DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
            if (cassiere.Length == 1) {
                MetaData.SetDefault(DS.proceeds, "idtreasurer", cassiere[0]["idtreasurer"]);
                return;
            }
            if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
                object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
                MetaData.SetDefault(DS.proceeds, "idtreasurer", codiceistituto);
            }

        }
		public void MetaData_AfterActivation() {
			btnInsertClass.BackColor = formcolors.GridButtonBackColor();
			btnInsertClass.ForeColor = formcolors.GridButtonForeColor();
			btnEditClass.BackColor = formcolors.GridButtonBackColor();
			btnEditClass.ForeColor = formcolors.GridButtonForeColor();
			btnDelClass.BackColor = formcolors.GridButtonBackColor();
			btnDelClass.ForeColor = formcolors.GridButtonForeColor();
			MetaData MetaEstimDet = MetaData.GetMetaData(this,"estimatedetailview");
			MetaEstimDet.DescribeColumns(DS.estimatedetail_taxable,"listaimpon");
			MetaEstimDet.DescribeColumns(DS.estimatedetail_iva,"listaimpos");
			MetaData MetaInvDet = MetaData.GetMetaData(this,"invoicedetailview");
			MetaInvDet.DescribeColumns(DS.invoicedetail_taxable,"listaimpon");
			MetaInvDet.DescribeColumns(DS.invoicedetail_iva,"listaimpos");
            CalcolaDefaultPerIstitutoCassiere();
			MetaData.MainAdd(this);

		}

		#endregion

		#region Gestione fase precedente

		void AzzeraPadre(){
			DataRow CurrEntrata = DS.income.Rows[0];
			CurrEntrata["parentidinc"]=DBNull.Value;
			txtNumeroFasePrecedente.Text="";
			txtEsercizioFasePrecedente.Text="";
            CurrEntrata["autokind"] = DBNull.Value;
            CurrEntrata["autocode"] = DBNull.Value;
            CurrEntrata["idpayment"] = DBNull.Value;
            CurrEntrata["idunderwriting"] = DBNull.Value;
		}

		/// <summary>
		/// calcola l'esercizio e il numero di movimento del padre del movimento corrente
		/// </summary>
		private void SetFasePrecedente() {
			if (faseinizio==1) return;  //se non esiste una fase precedente esce
			if(MetaData.Empty(this))return;
			//Calcola e riempie i campi relativi alla fase precedente:
			object Livsupid = DS.Tables["income"].Rows[0]["parentidinc"];
			string filter = QHS.CmpEq("idinc", Livsupid);
			DataTable DT = MyConn.RUN_SELECT("income","idinc,ymov,nmov,autokind",null,filter,null,true);
			if(DT.Rows.Count == 0)return;
			txtEsercizioFasePrecedente.Text = DT.Rows[0]["ymov"].ToString();
			txtNumeroFasePrecedente.Text = DT.Rows[0]["nmov"].ToString(); 
		}
		
		bool DocumentoContabilizzato(){
			tipocont curr = ContabilizzazioneSelezionata();
			if (curr==tipocont.cont_none) return false;
			switch( curr){
				case tipocont.cont_iva:  return (IvaLinked!=null);
				case tipocont.cont_estimate:  return (EstimateLinked!=null);
			}
			return false;
		}

		bool ContrattoOFatturaContabilizzato(){
			tipocont curr = ContabilizzazioneSelezionata();
			if (curr==tipocont.cont_none) return false;
			switch( curr){
				case tipocont.cont_iva:  return (IvaLinked!=null);
				case tipocont.cont_estimate:  return (EstimateLinked!=null);
			}
			return false;
		}

		/// <summary>
		/// Estrae un filtro in base a:
		///  - Fase precedente la prima selezionata
		///  - disponibilità (solo se Modo Insert)
		///  - textbox EserciziofasePrecedente
		///  - textbox NumeroFasePrecedente
		/// </summary>
		/// <returns></returns>
		string GetFasePrecFilter(bool FiltraNumMovimento){
            int codfaseprec = faseinizio - 1;
            string ffase = ffase = QHS.CmpEq("nphase", codfaseprec);
            string MyFilter = QHS.AppAnd(ffase, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            if (Meta.InsertMode) {
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpGt("available", 0));
            }

            if (txtEsercizioFasePrecedente.Text.Trim() != "")
                MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioFasePrecedente.Text.Trim()));
            if (FiltraNumMovimento) {
                if (txtNumeroFasePrecedente.Text.Trim() != "")
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroFasePrecedente.Text.Trim()));
            }
			if (Meta.IsEmpty) return MyFilter;//non passa mai di qui poiché siamo in procedura
			DataRow Curr= DS.income.Rows[0];
			int codicecreddeb=  CfgFn.GetNoNullInt32(Curr["idreg"]);
			int fasecred = ManageCreditore.faseattivazione;
			if (fasecred< faseinizio && DocumentoContabilizzato()){
				if (codicecreddeb>0)
                    MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idreg", codicecreddeb));
			}	
			if (!Meta.IsEmpty){
				DataRow CurrImp= DS.incomeyear.Rows[0];
				object idupb=  CurrImp["idupb"];
				int faseupb = ManageUPB.faseattivazione;
				if (faseupb< faseinizio){
					if (faseupb< faseinizio && ContrattoOFatturaContabilizzato()){
						if (idupb!=DBNull.Value)
                            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idupb", idupb));
					}
				}
			}
			return MyFilter;
		}

		private void btnFasePrecedente_Click(object sender, System.EventArgs e) {
			DataAccess Conn = MetaData.GetConnection(this);
			bool ThereWasIvaLinked = (IvaLinked!=null);
			bool ThereWasEstimateLinked = (EstimateLinked!=null);
			string MyFilter; 
			
			if (((Control)sender).Name == "txtNumeroFasePrecedente")
				MyFilter = GetFasePrecFilter(true);
			else
				MyFilter = GetFasePrecFilter(false);

			MetaData MFase = MetaData.GetMetaData(this,"incomeview");
			MFase.FilterLocked=true;
			MFase.DS=DS;
			if (Meta.InsertMode)
			{
				string valuelist = QHS.quote(30) + "," + QHS.quote(31)+ "," +QHS.quote(20) + "," + QHS.quote(21) ;
				MyFilter = QHS.AppAnd(MyFilter, 
                           QHS.DoPar(QHS.AppOr(QHS.IsNull("autokind"),QHS.FieldNotInList("autokind", valuelist))));
			}
			DataRow MyDR = MFase.SelectOne("elencofaseprec",MyFilter,null,null);
			
			if(MyDR == null) {
				if (Meta.InsertMode){
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
					}
				}
				return;
			}
		
			if(Meta.IsEmpty) {  
				///TODO: Non dovrebbe passare mai di qui.... si può eliminare
				//Se mi trovo in imposta ricerca 
				txtCredDeb.Text = MyDR["registry"].ToString();		
				txtEsercizioFasePrecedente.Text=MyDR["ymov"].ToString();
				txtNumeroFasePrecedente.Text=MyDR["nmov"].ToString();
			}
			
			//Inserisco nella riga attuale il valore identrata nel campo livsupidentrata
			//al fine di consentire il calcolo automatico del nuovo identrata.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				DisponibileDaFasePrecedente= CfgFn.GetNoNullDecimal( MyDR["available"]);
				//Legge i dati dal Form
				MetaData.GetFormData(this,true);
				DS.income.Rows[0]["parentidinc"]=MyDR["idinc"];
				DataRow DRImputazione = DS.Tables["incomeyear"].Rows[0];
				DataRow DREntrata = DS.Tables["income"].Rows[0];

				if (faseinizio>ManageCreditore.faseattivazione)
					DREntrata["idreg"] = MyDR["idreg"];

				bool IvaLocked = ((IvaLinkedMustBeEvalued==false) && (IvaLinked!=null));
				bool EstimateLocked = ((EstimateLinkedMustBeEvalued==false) && (EstimateLinked!=null));
			
				if (IvaLocked==false||EstimateLocked==false){
					DREntrata["doc"] = MyDR["doc"];
					DREntrata["docdate"] = MyDR["docdate"];
					DREntrata["description"] = MyDR["description"];
				}


                DREntrata["idpayment"] = MyDR["idpayment"];
                DREntrata["autokind"] = MyDR["autokind"];
                DREntrata["autocode"] = MyDR["autocode"];
                DREntrata["idunderwriting"] = MyDR["idunderwriting"];

				if (IvaLocked==false||EstimateLocked==false||DREntrata["idman"]==DBNull.Value){
					DREntrata["idman"] = MyDR["idman"];
				}

				DRImputazione["idinc"] = DREntrata["idinc"];
				DRImputazione["ayear"] = Meta.GetSys("esercizio").ToString();

				if (faseinizio>ManageBilAnnuale.faseattivazione){
					DRImputazione["idfin"] = MyDR["idfin"];
					DRImputazione["idupb"] = MyDR["idupb"];
				}

				DRImputazione["amount"] = MyDR["available"];
				RecalcImporto();			
				
				//Valori del padre del movimento
				txtEsercizioFasePrecedente.Text=MyDR["ymov"].ToString();
				txtNumeroFasePrecedente.Text=MyDR["nmov"].ToString();			
				ResetTipoClassAvailableEvalued();
				lastimportofreshed= GetImporto()+1;
				ResetDocumentiFasiNonIncluse();
				Meta.FreshForm(true);
			}
			if (ThereWasIvaLinked&&(IvaLinked==null)){
				ScollegaIva();
			}
			if (ThereWasEstimateLinked&&(EstimateLinked==null)){
				ScollegaEstimate();
			}
		}


		
		private void txtNumeroFasePrecedente_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumeroFasePrecedente.ReadOnly)return;


			if (!Meta.InsertMode) return;

			if ((txtNumeroFasePrecedente.Text.Trim()=="")&& Meta.InsertMode) {				
				DataRow Curr = DS.Tables["income"].Rows[0];
				Curr["parentidinc"]=DBNull.Value;
				DisponibileDaFasePrecedente=0;
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
			btnFasePrecedente_Click(sender,e);
		}

		private void txtEsercizioFasePrecedente_Leave(object sender, System.EventArgs e) {			
			if (InChiusura)return;
			if (txtEsercizioFasePrecedente.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercizioFasePrecedente);		
		}


		void AzzeraDatiFasiNonSelezionate(){
			bool ultimafase = (faseinizio<=faseentratamax) &&(faseentratamax<=faseentratafine);	
			if ((faseentratamax<faseinizio)||(faseentratamax>faseentratafine)){
				//Elimina movim.spesa access. 

				CalcolaTotaliSuGrids();
			}
		
			int fasebil= ManageBilAnnuale.faseattivazione;
			bool fasebilinclusa = (faseinizio<=fasebil) && (fasebil<=faseentratafine);
			if (!fasebilinclusa) {
				DS.creditpart.Clear();
			}

		    if (!ultimafase) {
                DS.incomebill.Clear();
                DS.proceedspart.Clear();
		    }

		    //Cancella le classificazioni fuori range
			foreach (DataRow RImp in DS.incomesorted.Select()){
                DataRow Class = RImp.GetParentRow("sortingincomesorted");
                if (Class == null) {
                    RImp.Delete();
                    try {
                        RImp.AcceptChanges();
                    }
                    catch { };
                    continue;
                }

                string searchparent = QHC.CmpEq("idsorkind", Class["idsorkind"]);
                DataTable SorKind = Class.Table.DataSet.Tables["sortingkind"];
                DataRow[] TipoClassRs = SorKind.Select(searchparent);
                DataRow TipoClass = null;
                if (TipoClassRs.Length > 0) TipoClass = TipoClassRs[0];
                if (TipoClass == null) {
					RImp.Delete();
					try {
						RImp.AcceptChanges();
					}
					catch{};
					continue;
				}
				int currtipo = CfgFn.GetNoNullInt32(TipoClass["nphaseincome"]);
				if ((currtipo<faseinizio)||(currtipo>faseentratafine)) RImp.Delete();
			}

			if (!faseIvaInclusa()){
				DS.incomeinvoice.Clear();
				DS.invoice.Clear();
				DS.invoicedetail_taxable.Clear();
				DS.invoicedetail_iva.Clear();
			}
			if (!faseContrattoInclusa()){
				DS.incomeestimate.Clear();
				DS.estimate.Clear();
				DS.estimatedetail_taxable.Clear();
				DS.estimatedetail_iva.Clear();
			}
		}

		public void AzzeraDatiSuCambioFase(){
			
			AzzeraPadre();
			if ((IvaLinked!=null)&&
				(!faseIvaInclusa())) {
				//Cancella le prestazioni se derivano da una missione non più abilitata
				ScollegaIva();
				ClearControlliIva(false);
				//AbilitaDisabilitaControlliIva(true);
				AbilitaDisabilitaCreditoreDebitore(true);
				ResetIva();
			}
			if ((EstimateLinked!=null)&&
				(!faseContrattoInclusa())) {
				//Cancella le prestazioni se derivano da una missione non più abilitata
				ScollegaEstimate();
				ClearControlliEstimate(false);
				//AbilitaDisabilitaControlliOrdine(true);
				AbilitaDisabilitaCreditoreDebitore(true);
				ResetEstimate();
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
			AddRemoveTabs(false);
            ImpostaFiltroBilancio();

			if (!Meta.CanSave) return;
			if (Meta.EditMode== Meta.MainRefreshEnabled){
				Meta.MainRefreshEnabled= !(Meta.EditMode);
				Meta.FreshToolBar();
			}

			ManageClassificazioni.CalcolaTotaliClassificazioni();
			
			//Controlla che vi sia o Crea una nuova riga nel DataTable "imputazionespesa"
			//con valori di default.
			if(!MetaData.Empty(this) && (Meta.FormState ==  MetaData.form_states.insert)){
				CreateImputazioneEntrataRow();
				CreateDocumentoIncassoRow();
			}
			
		}

		//Richiamata dopo che il Form è stato riempito completamente con i dati opportuni. 
		public void MetaData_AfterFill() {
			
			EnableDisableCrediti();

			if (SubEntity_chbCoperturaIniziativa.ThreeState==true) SubEntity_chbCoperturaIniziativa.ThreeState=false;
            if (SubEntity_chbDestinazioneVincolata.ThreeState == true) SubEntity_chbDestinazioneVincolata.ThreeState = false;
          
            if (MustClose) {
				Meta.CanSave=false;
				Meta.SearchEnabled=false;
				Meta.CanInsert=false;
				//Meta.MainRefreshEnabled=false;
				Meta.FreshToolBar();
				tabControl1.Enabled=false;
				return;
			}
            
            DataRow CurrSorKind = HelpForm.GetLastSelected(DS.sortingkind);
            if (CurrSorKind != null) {
                string f = QHC.CmpEq("!idsorkind", CurrSorKind["idsorkind"]);
                DS.incomesorted.ExtendedProperties["CustomParentRelation"] = f;
            }

			if ((IvaLinkedMustBeEvalued==false)&&(IvaLinked!=null) &&
				(IvaLinked.RowState==DataRowState.Detached)){
				if (DS.invoice.Rows.Count>0){
					IvaLinked= DS.invoice.Rows[0];
					IvaMovEntrataLinked = DS.incomeinvoice.Rows[0];
				}
				else 
					ResetIva();
			}

			if ((EstimateLinkedMustBeEvalued==false)&&(EstimateLinked!=null) &&
				(EstimateLinked.RowState==DataRowState.Detached)){
				if (DS.estimate.Rows.Count>0){
					EstimateLinked= DS.estimate.Rows[0];
					EstimateMovEntrataLinked = DS.incomeestimate.Rows[0];
				}
				else 
					ResetEstimate();
			}


			if (to_mainrefresh){
				to_mainrefresh=false;
			}

			bool IvaWasToLink = IvaLinkedMustBeEvalued;
			RintracciaIva();
			if (IvaWasToLink){
				if (IvaLinked !=null) {
					VisualizzaMainInfo_Iva(IvaLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}


			bool EstimateWasToLink = EstimateLinkedMustBeEvalued;
			RintracciaEstimate();
			if (EstimateWasToLink){
				if (EstimateLinked !=null) {
					VisualizzaMainInfo_Estimate(EstimateLinked);
					lastimportofreshed = decimal.MinValue;
				}
			}

			AzzeraDatiFasiNonSelezionate();
			ApplicaLogicaSuFase();
			CanGoInsert=true;
			AbilitaDisabilitaControlliContabilizzazione(!Meta.EditMode);
			
			AbilitaDisabilitaBottoniAutomatismi(Meta.EditMode);


			if (DS.proceeds.Rows.Count>0){
				DataRow DocInc = DS.proceeds.Rows[0];
				HelpForm.SetComboBoxValue(cmbIstitutoCassiere, DocInc["idtreasurer"]);
                HelpForm.SetComboBoxValue(cmbBollo, DocInc["idstamphandling"]);

                bool isFruttifero = ((CfgFn.GetNoNullInt32(DocInc["flag"]) & 8) != 0);

				if (isFruttifero){
					rdbFruttifero.Checked=true;
				}
				else {
					rdbInfruttifero.Checked=true;
				}
			}

			if (Meta.CanSave){
				txtNumMandato.Text= "";
			}
			else {
				if (DSP.Tables["proceeds"].Rows.Count!=0){
					DataRow DocPag2=DSP.Tables["proceeds"].Rows[0];
					txtNumMandato.Text= DocPag2["npro"].ToString();
				}
			}
	
			if (lastimportofreshed!=GetImporto()){
				lastimportofreshed= GetImporto();
				UpdateImportoDependencies();
			}
			if (!Meta.IsEmpty) GestioneFasePerDocumentoCollegato();
			CalcolaTotaliSuGrids();
            CalcolaTotaleSospesi();

            SetFasePrecedente();

			//set tipoclassmovimenti like a cached table
			GetData.LockRead(DS.sortingkind);
			GetData.DenyClear(DS.sortingkind);

			RefillImportoAssegnazioni(GetImportoPerClassificazione());
			// qui chiamare l'update dei totali degli importi ancora da assegnare
			
			ManageClassificazioni.CalcImpClassMovDefaults(GetImportoPerClassificazione());


		    impostaFlagNonContabilizzazione();
		}//fine after_fill

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
	            var flag = CfgFn.GetNoNullInt32(MyConn.readValue("fin",q.eq("idfin",rIncYear.idfin),"flag"));
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
	            rLast.flag =(byte) ((rLast.flag??0) |  128 );//mette il bit
	        }
	        else {
	            rLast.flag =(byte) ((rLast.flag??0) &  ~128 );//toglie il bit
	        }
	    }

	    bool checkPresenzaContabilizzazione() {
            
	        if (IvaLinked != null) return true; //incondizionatamente

	        //if (ProfessionaleLinked != null) return true; questo non ci interesa, è necessario contabilizzare una fattura in questo caso

	        if (EstimateLinked != null) {
	            //solo se ordine non collegabile a fattura
	            var rEstimKind = DS.estimatekind.First(q.eq("idestimkind", EstimateLinked["idestimkind"]));
	            return rEstimKind?.linktoinvoice?.ToUpper()=="N";
	        }

	        return false;
	    }


		#endregion


		#region Before/After Post

		bool ricalcolaProceedsBank = false;

		public void MetaData_BeforePost(){
			if (DS.income.Select().Length==0){
				DS.proceeds.Clear();
			}
		}

		public void MetaData_AfterPost(){
			Meta.MainRefreshEnabled= false;
			if (DS.income.Rows.Count==0) return;

			DSP = (DataSet) DS.ExtendedProperties["DSPData"];
			if (!DSP.HasChanges()){
				DS.AcceptChanges();
				Meta.CanSave=false;
                Meta.FreshToolBar();
			}
//			GeneraAutomatismiAfterPost();
			ricalcolaProceedsBank = DSP.Tables["proceeds"].Rows.Count >=0;	
			GeneraAzzeraDisponibilitaFasiPrec();
			fillProceedsBank();
			PostData.MarkAsTemporaryTable(DS.proceeds,false);
			//to_mainrefresh=true;
			Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable,"incomeinvoicedetail_taxable");
			Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva,"incomeinvoicedetail_iva");
            Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva,"incomeestimatedetail_iva");
			Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable,"incomeestimatedetail_taxable");

			FillPostedID();

			copiaTabella(DSP.Tables["creditpart"], DS.creditpart);
			copiaTabella(DSP.Tables["proceedspart"], DS.proceedspart);
		}
		#endregion

		#region Gestione Movimenti Bancari
		private void fillProceedsBank() {
			if (!ricalcolaProceedsBank) return;
			if (DSP.Tables["proceeds"].Rows.Count==0) return;
			
			DataRow CurrEntrata = DSP.Tables["proceeds"].Rows[0];
            int kpro = 0;
            if (DS.incomelast.Rows.Count > 0) {
                DataRow CurrLast = DS.incomelast.Rows[0];
                kpro = CfgFn.GetNoNullInt32(CurrLast["kpro"]);
            }
            else
                kpro = 0;
            if (kpro == 0 || kpro >= 9999000) return;
            Meta.Conn.CallSP("compute_proceeds_bank", new object[] { kpro });
		}

		private void fillMovBankAutomatismi(DataTable table, string tablename) {
			if (table.Rows.Count == 0) return;
			string kfield = (tablename == "payment") ? "kpay" : "kpro";
			foreach(DataRow rDoc in table.Rows) {
				int k = CfgFn.GetNoNullInt32(rDoc[kfield]);
                if (k == 0 || k >= 9999000) continue;
                Meta.Conn.CallSP("compute_" + tablename + "_bank", new object[] { k });
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
			if (Meta.IsEmpty) return;
			
			if (DS.proceeds.Rows.Count>0){
				DataRow DocInc = DS.proceeds.Rows[0];

				if (T.TableName == "treasurer"){
					if (R==null)
						DocInc["idtreasurer"]= DBNull.Value;
					else
						DocInc["idtreasurer"]= R["idtreasurer"];
					HelpForm.SetComboBoxValue(cmbIstitutoCassiere, 
						DocInc["idtreasurer"]);

                    if (R["flagfruitful"].ToString().ToUpper() == "F") {
                        rdbInfruttifero.Checked = false;
                        rdbFruttifero.Checked = true;
                    }
                    else {
                        rdbFruttifero.Checked = false;
                        rdbInfruttifero.Checked = true;
                    }

				}
                if (T.TableName == "stamphandling"){
                    if (R == null)
                        DocInc["idstamphandling"] = DBNull.Value;
                    else
                        DocInc["idstamphandling"] = R["idstamphandling"];
                    HelpForm.SetComboBoxValue(cmbBollo, DocInc["idstamphandling"]);
                }
			}

			if (T.TableName == "registry"){
				if (!Meta.DrawStateIsDone) return;
				ResetTipoClassAvailableEvalued();
                ImpostaModalitaRiscossione(R, true);
				return;
			}

			if (T.TableName=="bill"){
				if (R!=null) ManageBollettaChange(R);
			}

			if (((T.TableName=="estimatedetail_taxable")||(T.TableName=="estimatedetail_iva"))&&Meta.DrawStateIsDone){
				if ((T.TableName=="estimatedetail_taxable")&&(CurrCausaleEstimate==1)){
					if (R!=null) R["idinc_iva"]=R["idinc_taxable"];
					CalcolaImportoInBaseADettagliContratto();
				}
			}


			if (T.TableName=="estimate" && Meta.DrawStateIsDone){
				DS.estimatedetail_iva.Clear();
				DS.estimatedetail_taxable.Clear();
				CalcTotEstimateDetail();
				if (R==null){
					btnAddDetEstimate.Enabled=false;
					btnRemoveDetEstimate.Enabled=false;
					btnEditEstimDet.Enabled=false;
				}
				else {
					btnAddDetEstimate.Enabled=true;
					btnRemoveDetEstimate.Enabled=true;
					btnEditEstimDet.Enabled=true;
				}
			}


			if (((T.TableName=="invoicedetail_taxable")||(T.TableName=="invoicedetail_iva"))&&Meta.DrawStateIsDone){
				if ((T.TableName=="invoicedetail_taxable")&&(CurrCausaleEstimate==1)){
					if (R!=null) R["idinc_iva"]=R["idinc_taxable"];
					CalcolaImportoInBaseADettagliFattura();
				}
			}

			if (T.TableName=="invoice" && Meta.DrawStateIsDone){
				DS.invoicedetail_iva.Clear();
				DS.invoicedetail_taxable.Clear();
				CalcTotInvoiceDetail();
				if (R==null){
					btnAddDettInvoice.Enabled=false;
					btnRemoveDettInvoice.Enabled=false;
					btnEditInvDet.Enabled=false;
				}
				else {
					btnAddDettInvoice.Enabled=true;
					btnRemoveDettInvoice.Enabled=true;
					btnEditInvDet.Enabled=true;
				}
			}
			if (T.TableName == "upb"){
				EnableDisableCrediti();
				if (Meta.DrawStateIsDone){
					ResetTipoClassAvailableEvalued();
					AggiornaBilancioResponsabile(R);
				}
                string idupb = GetDefaultForUpb();
				if (R!=null)idupb= R["idupb"].ToString();
				MetaData.AutoInfo AI;
				AI = Meta.GetAutoInfo(txtCodiceBilancio.Name);
				string filter="(idupb='"+idupb+"')";
				if (AI!=null) AI.startfilter=filter;
				DS.finview.ExtendedProperties[MetaData.ExtraParams]= filter;				
			}


			if (T.TableName == "finview"){
				ResetTipoClassAvailableEvalued();
                object getman = GetResponsabile();
				if ((Meta.InsertMode || Meta.EditMode)&&(R!=null)){
                    if ((R["idman"] != DBNull.Value) &&
                        ((getman==DBNull.Value) ||
                        ((getman!=DBNull.Value) &&
                        (getman.ToString() != R["idman"].ToString())
                        )
                        )
                        ) {
						if ((getman==DBNull.Value)||
							MessageBox.Show("Cambio il responsabile in base alla voce di bilancio selezionata?",
							"Conferma",MessageBoxButtons.OKCancel )==DialogResult.OK) {
                            SetResponsabile(R["idman"]);
						}
					}					
				}
			}

			if ((T.TableName == "sortingkind")&& Meta.DrawStateIsDone) {
				ManageClassificazioni.ManageTipoClassMovimentiRowChanged(
					GetImportoPerClassificazione(), R);
				return;
			}		

		}

        void ManageBollettaChange(DataRow Bolletta) {
            if (Meta.IsEmpty) return;
            if (Bolletta==null) return;
            if (txtDescrizione.Text != "") {
                if (MessageBox.Show("Aggiorno il campo descrizione in base alla Bolletta selezionata?",
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
            if (importo < 0) importo = 0;
            if (importo < impcorrente || impcorrente == 0) {
                SetImporto(importo);
                SubEntity_txtImportoMovimento.Text = importo.ToString("c");
                if (avvisare) {
                    MessageBox.Show("L'importo del movimento è stato impostato al valore della bolletta", "Avviso");
                }
            }
            //}
        }
		string lastfilterPrev=null;
		DataRow LastPrevRow=null;
		void AggiornaBilancioResponsabile(DataRow UPB){
			if (UPB==null) return;
			if (Meta.IsEmpty) return;

			int fasebilancio = ManageBilAnnuale.faseattivazione;
			if (fasebilancio>faseinizio) return;

			DataRow CurrExp= DS.income.Rows[0];
			DataRow Curr = DS.incomeyear.Rows[0];
            if(UPB["idman"] != DBNull.Value) {
                SetResponsabile(UPB["idman"]);
            }

            if (fasebilancio < faseinizio){
				//Se è già presente una voce di bilancio tramite  una fase precedente,
				//  allora non modifica il bilancio
				if (Curr["idupb"]!=DBNull.Value)return;
			}


            string filterprevU = "(F.ayear=" +
                        QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")" +
                        "AND( (F.flag & 1)=0)";
            //(U.idfin like '" + Meta.GetSys("esercizio").ToString().Substring(2) + "E%')";
            string filterupbU = "(U.idupb = " + QueryCreator.quotedstrvalue(UPB["idupb"], true) + ")";
            string filterupb = "(idupb = " + QueryCreator.quotedstrvalue(UPB["idupb"], true) + ")";
            filterprevU = GetData.MergeFilters(filterprevU, filterupbU);

            if(Meta.InsertMode) {
                object OX = HelpForm.GetObjectFromString(typeof(decimal),
                    SubEntity_txtImportoMovimento.Text, "x.y.c");
                if(OX != DBNull.Value) {
                    decimal X = CfgFn.GetNoNullDecimal(OX);
                    filterprevU = GetData.MergeFilters(filterprevU,
                        //"(  (isnull(currentprev,0)+isnull(previsionvariation,0))>=" +
                        "(  (isnull(availableprevision,0))>=" +
                        QueryCreator.quotedstrvalue(X, true) + ")");
                }
            }

            if(filterprevU != lastfilterPrev) {
                DataTable Previsione =
                    Meta.Conn.SQLRunner("SELECT * from finview U join finusable F on F.idfin= U.idfin where " +
                     filterprevU, true);
                if((Previsione == null) || (Previsione.Rows.Count != 1)) {
					//Valuta se cancellare il capitolo corrente
					DS.finview.Clear();
					Curr["idfin"]=DBNull.Value;
					txtCodiceBilancio.Text="";
					txtDenominazioneBilancio.Text="";
                    // Puliamo anche il finanziamento 
                    txtFinanziamento.Text = "";
                    lastfilterPrev = filterprevU;
					LastPrevRow=null;
					MetaData_AfterRowSelect(DS.finview, null);
					return;
				}
                lastfilterPrev = filterprevU;
				LastPrevRow= Previsione.Rows[0];
			}
			if (LastPrevRow==null) return;
            //Se c'è un finanziamento che ha del disponibile su questo upb selezioniamo questo finanziamento e questo bilancio 
            string filterFinanziamento = "";
            decimal currval = 0;
            if (SubEntity_txtImportoMovimento.Text.Trim() != ""){
                currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                    typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
            }
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "(ayear ='" + esercizio.ToString() + "')and((flag & 1)=0)";
            filterFinanziamento = GetData.MergeFilters(filterupb,
                    "(incomeprevavailable>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                    Meta.GetSys("esercizio").ToString() + "'))";
            filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteroperativo);
            filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteridfin); // filtra voci bilancio di entrata ed esercizio corrente
          
            DataTable Tupbunderwritingyearview = MyConn.RUN_SELECT("upbunderwritingyearview", "*", null, filterFinanziamento, null, null, true);
            if ((chkFilterAvailable.Checked) && (Tupbunderwritingyearview.Rows.Count > 0)){
                DataRow Rupbunderwritingyearview = Tupbunderwritingyearview.Rows[0];
                txtCodiceBilancio.Text = Rupbunderwritingyearview["codefin"].ToString();
                txtDenominazioneBilancio.Text = Rupbunderwritingyearview["fin"].ToString();
                txtFinanziamento.Text = Rupbunderwritingyearview["underwriting"].ToString();
            }
            else{
                txtFinanziamento.Text = "";
            }

			if (Curr["idfin"].ToString()==LastPrevRow["idfin"].ToString()) return;
			Curr["idfin"]= LastPrevRow["idfin"];


			DS.finview.Clear();
            DataAccess.RUN_SELECT_INTO_TABLE(MyConn, DS.finview, null,
                    "(idfin=" + QueryCreator.quotedstrvalue(Curr["idfin"], true) + ")" +
                        "AND" + filterupb,
                            null, true);

			if (DS.finview.Rows.Count>0){
				DataRow Bil = DS.finview.Rows[0];
				txtCodiceBilancio.Text= Bil["codefin"].ToString();
				txtDenominazioneBilancio.Text=Bil["title"].ToString();
				MetaData_AfterRowSelect(DS.finview, Bil);
			}
			else {
				txtCodiceBilancio.Text="";
				txtDenominazioneBilancio.Text="";
				MetaData_AfterRowSelect(DS.finview, null);
			}
		}



		#endregion

	
		#region Gestione delle classificazioni movimento

		void ResetTipoClassAvailableEvalued(){
			if (ManageClassificazioni!=null) ManageClassificazioni.Clear();
		}

		private void tabClassSup_Enter(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (!Meta.DrawStateIsDone) return;
			if (InsideAdRemoveTabs) return;
			if (tabControl1.SelectedTab==tabClassSup){
				ManageClassificazioni.EnterTabClassificazioni(faseinizio, faseentratafine);
			}
		}
		
		private void btnInsertClass_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
            if (classEnabled) {
                classEnabled = false;
                ManageClassificazioni.btnInsertClass_Click(faseinizio, faseentratafine, GetImportoPerClassificazione());
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
                ManageClassificazioni.btnEditClass_Click(faseinizio, faseentratafine, GetImportoPerClassificazione());
                classEnabled = true;
            }
		}

		private void DGridDettagliClassificazioni_DoubleClick(object sender, System.EventArgs e) {
			btnEditClass_Click(null,null); 
		}


		#endregion


		private void FormattaDataDelTexBox(TextBox TB) {
			if(!TB.Modified)return;
			HelpForm.FormatLikeYear(TB);
		}




		///  Si occupa anche di azzerare i campi di spesa se la fase non li ammette


	

	

		void AbilitaDisabilitaBottoniAutomatismi(bool abilita){
		}


		//Viene chiamato ogni volta che viene selezionata una riga differente in una qualsiasi
		//tabella del Dataset in memoria.

		#region Gestione Totali dettspesepagamenti/dettentratepagamenti
		
		void CalcolaTotaliSuGrids(){
			CalcTotInvoiceDetail();
			CalcTotEstimateDetail();

		}
		
		void CalcTotEstimateDetail(){
			txtTotEstimateDetail.Text="";
			if (Meta.IsEmpty) return;
			decimal totale= GetImportoDettagliContratto();
			txtTotEstimateDetail.Text=totale.ToString("c");			
		}

		void CalcTotInvoiceDetail(){
			txtTotInvoiceDetail.Text="";
			if (Meta.IsEmpty) return;
			decimal totale= GetImportoDettagliFattura();
			txtTotInvoiceDetail.Text=totale.ToString("c");						
		}

		void ClearGridsData(){
			txtImportoAssegnareCrediti.Text="";
			txtImportoAssegnareIncassi.Text="";
		}

		#endregion

        string GetDefaultForUpb () {
            return ""; // "0001";
            //if (DS.upb.Select(QHC.CmpEq("idupb", "0001")).Length > 0) return "0001";
            //DataRow[] upblist = DS.upb.Select(QHC.CmpNe("idupb", ""), "codeupb asc");
            //if (upblist.Length == 0) return "";
            //return upblist[0]["idupb"].ToString();

        }
		public void CreateImputazioneEntrataRow(){
			if (Meta.IsEmpty) return;
			if(DS.Tables["incomeyear"].Rows.Count == 0) {
				try {
					DataRow DREntrata = DS.Tables["income"].Rows[0];
					MetaData MetaImp = MetaData.GetMetaData(this,"incomeyear");
					MetaImp.SetDefaults(DS.incomeyear);
					DataRow DR =  MetaImp.Get_New_Row(DREntrata, DS.incomeyear);
                    if (faseinizio == ManageUPB.faseattivazione) {
                        SetUPB(GetDefaultForUpb());
                    }
					DR["ayear"] = Meta.GetSys("esercizio");
				}
				catch {
				}
			}
            if (DS.Tables["incomelast"].Rows.Count == 0) {
                try {
                    DataRow DREntrata = DS.Tables["income"].Rows[0];
                    MetaData MetaLast = MetaData.GetMetaData(this, "incomelast");
                    MetaLast.SetDefaults(DS.incomelast);
                    DataRow DR = MetaLast.Get_New_Row(DREntrata, DS.incomelast);
                }
                catch {
                }
            }
		}

		public void CreateDocumentoIncassoRow(){
			if (Meta.IsEmpty) return;
			if(DS.Tables["proceeds"].Rows.Count == 0) {
				try {
                    DataRow DRLast = DS.Tables["incomelast"].Rows[0];
					DataRow DREntrata = DS.Tables["income"].Rows[0];
					MetaData MetaImp = MetaData.GetMetaData(this,"proceeds");
					MetaImp.SetDefaults(DS.proceeds);
					DataRow DR =  MetaImp.Get_New_Row(null, DS.proceeds);
                    object idtreasurer = DR["idtreasurer"];
                    string flt = QHC.CmpEq("idtreasurer", idtreasurer);
                    if (DS.treasurer.Select(flt).Length > 0) {
                        object o = DS.treasurer.Select(flt)[0]["flagfruitful"];
                        int flag = CfgFn.GetNoNullInt32(DR["flag"]);
                        if (o.ToString() == "F") {
                            flag = flag | 8;
                        }
                        else {
                            flag = flag & 0xF7;
                        }
                        DR["flag"] = flag;

                    }
					DRLast["kpro"] = DR["kpro"];
					//
					GetData.DenyClear(DS.proceeds);
					GetData.LockRead(DS.proceeds);
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
		decimal GetImporto(){
			DataRow R = DS.incomeyear.Rows[0];
			if (R["amount"]==DBNull.Value) return 0;
			return Convert.ToDecimal(R["amount"]);
		}
		/// <summary>
		/// Imposta l'importo "esercizio"
		/// </summary>
		/// <param name="Importo"></param>
		void SetImporto(decimal Importo){
			DataRow R = DS.incomeyear.Rows[0];
			R["amount"]= Importo;
			SubEntity_txtImportoMovimento.Text= HelpForm.StringValue(
				Importo, "x.y.c");
			MetaData_AfterGetFormData();
			ResetTipoClassAvailableEvalued();
			UpdateImportoDependencies();
		}

		/// <summary>
		/// Restituisce l'importo "esercizio" uguale a imputazionespesa.importo+variazioni
		/// </summary>
		/// <returns></returns>
		decimal GetImportoPerClassificazione(){
			DataRow R = DS.incomeyear.Rows[0];
			decimal importo = CfgFn.GetNoNullDecimal(R["amount"]);
			return  importo; //+variazione;
		}

		void UpdateImportoDependencies(){
			ManageClassificazioni.RefillDettagliClassificazioni(GetImportoPerClassificazione());
			// by Leo
			RefillImportoAssegnazioni(GetImportoPerClassificazione());
		}

		void RefillImportoAssegnazioni(decimal Importo){
			// valorizzare i textbox degli importi ancora da assegnare
			// e impostare i valori di default degli importi delle assegnazioni
			decimal ImportoDaAssegnareCrediti = Importo - 
				MetaData.SumColumn(DS.creditpart, "amount");
			decimal ImportoDaAssegnareIncassi = Importo - 
				MetaData.SumColumn(DS.proceedspart, "amount");
			DS.creditpart.Columns["amount"].DefaultValue=ImportoDaAssegnareCrediti;
			DS.proceedspart.Columns["amount"].DefaultValue=ImportoDaAssegnareIncassi;
            if (gboxCrediti.Enabled)
			    txtImportoAssegnareCrediti.Text = ImportoDaAssegnareCrediti.ToString("c");
            else
            txtImportoAssegnareCrediti.Text = "";
            if (gboxIncassi.Enabled)
                txtImportoAssegnareIncassi.Text = ImportoDaAssegnareIncassi.ToString("c");
            else
                txtImportoAssegnareIncassi.Text = "";
		}

		private void SubEntity_txtImportoMovimento_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (Meta.IsEmpty) return;
			if (SubEntity_txtImportoMovimento.ReadOnly) return;
			Meta.GetFormData(true);
			UpdateImportoDependencies();
		}

		#endregion

		#region Gestione Automatismi

		public DataRow GetLastPhaseRow() {
			if (DSP==null) return null;
			string filterlast  = "(nphase='"+faseentratamax.ToString()+"')";
			DataRow []Found = DSP.Tables["income"].Select(filterlast);
			if (Found.Length==0) return null;
			return Found[0];
		}


		/*private void btnAutomatismiAccessori_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (Meta.InsertMode) return;
			string identrata=DS.income.Rows[0]["idinc"].ToString();
			string filter= "(idproceeds="+QueryCreator.quotedstrvalue(identrata,true)+")AND"+
				"(autokind='MOVIM')";
			Form F = ShowAutomatismi.Show(Meta,filter,filter,null,null);
			F.Show();
		}*/


		
		/// <summary>
		/// Legge i dati da DSP (DataSet per il Post)
		/// </summary>
//		public void GeneraAutomatismiAfterPost(){
//			//if (SecondoPostAttivo) return;
//			if (faseentratamax!=faseentratafine) return;
//
//			GestioneAutomatismi GestAuto = new GestioneAutomatismi(this, 
//				Meta, DSP, faseentratafine, faseentratamax, chbAzzeramento);
//
//			DataRow CurrMov= GetLastPhaseRow();
//			if (CurrMov==null) return;
//
//			DataSet Auto = GestAuto.GeneraAutomatismiAfterPost();
//			if (Auto==null) return;
//		
//			//Salva i dati
//			PostData Post = new Easy_PostData();
//			Post.InitClass(Auto, Meta.Conn);
//			bool res = Post.DO_POST();
//			if (!res) return;
//
//
//			fillMovBankAutomatismi(Auto.Tables["payment"], "payment");
//			fillMovBankAutomatismi(Auto.Tables["proceeds"], "proceeds");
//
//			//Scrive le modifiche sulla riga dell'ultima fase
//			PostData PostLastRow = new Easy_PostData();
//			PostLastRow.InitClass(DSP, Meta.Conn);
//			PostLastRow.DO_POST();
//		}

		void GeneraAzzeraDisponibilitaFasiPrec(){
			if (Meta.IsEmpty) return;
			if (chbAzzeramento.Checked){
				GestioneAutomatismi GestAuto = new GestioneAutomatismi(this,
					Meta.Conn, Meta.Dispatcher,
					DSP, faseentratafine, faseentratamax, "income", false);
				bool res = GestAuto.GeneraAzzeraDisponibilitaFasiPrec();
				if (res) chbAzzeramento.Checked=false;
			}
		}
		
		#endregion

		#region AfterGetFormData
		public void MetaData_AfterGetFormData(){
			if (!Meta.CanSave) return;
			if (Meta.IsEmpty) return;
			//La seg. evita errori in caso di "delete", nel cui caso le tabelle sono vuote.
			if (DS.Tables["incomeyear"].Rows.Count==0) return;

			DataRow REntrata = DS.income.Rows[0];
			DataRow RImputazione = DS.incomeyear.Rows[0];
			DataRow DocInc = DS.proceeds.Rows[0];

			if (REntrata.RowState== DataRowState.Deleted) return;
			
			CfgFn.ReSetAutoIncrementPropertiesForFirstPhaseEntrataProcedura(Meta.Conn,
				DS.income, REntrata, faseinizio, fasefine);

			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));		    
			//Un movimento è residuo se deriva dagli esercizi precedenti, ossia 
			//   esercmovimento < Conn.esercizio

			if(Meta.InsertMode) {
				//all'atto dell'inserimento porre imputazione.importo = spesa.importo
				RImputazione["ayear"]= esercizio; 
                //if (faseinizio<=ManageBilAnnuale.faseattivazione){
                //    //Calcola flagcompetenza (se faseinizio>1 il flag è preso dal mov.padre)
                //    if (REntrata["ymov"].ToString()==REntrata["ycreation"].ToString()){
                //        RImputazione["flagarrear"]="C";				
                //    }
                //    else {
                //        RImputazione["flagarrear"]="R";				
                //    }
                //}
			}

            //if (Meta.EditMode){
            //    //se flagcompetenza=C per ogni update imputazione.importo = spesa.importo                
            //    if (RImputazione["flagarrear"].ToString().ToUpper()=="C"){
            //        REntrata["amount"] = RImputazione["amount"];
            //    }
            //}
			DataRow PersEntrata= DS.Tables["config"].Rows[0];
            int flag = CfgFn.GetNoNullInt32(PersEntrata["proceeds_flag"]);
            bool flagrespons = ((flag & 16) == 16);
            bool flagbilancio = ((flag & 2) == 2);
            bool flagcreddeb = ((flag & 4) == 4);
            bool flagresidui = ((flag & 8) == 8);

            int idbilancioreversale = CfgFn.GetNoNullInt32(RImputazione["idfin"]);

			if (flagbilancio &&
				(PersEntrata["proceeds_finlevel"].ToString()!="") &&
				(PersEntrata["proceeds_finlevel"].ToString()!= maxfasebil)
				){
                int liv = CfgFn.GetNoNullInt32(PersEntrata["proceeds_finlevel"]);
                if (liv != 0) {
                    object O = Meta.Conn.DO_READ_VALUE(
                        "finlink",
                        QHS.AppAnd(QHS.CmpEq("idchild", idbilancioreversale),
                                    QHS.CmpEq("nlevel", liv)),
                        "idparent");
                    if (O != DBNull.Value) idbilancioreversale = CfgFn.GetNoNullInt32(O);
                }   
			}

			if (fasefine>faseentratamax){
				DocInc["adate"]= REntrata["adate"];
                object flagautostampa = PersEntrata["proceeds_flagautoprintdate"];
                if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
                    DocInc["printdate"] = DocInc["adate"];
                }

				if (cmbIstitutoCassiere.SelectedIndex<=0)
					DocInc["idtreasurer"]=DBNull.Value;
				else
					DocInc["idtreasurer"]=cmbIstitutoCassiere.SelectedValue;

                if (cmbBollo.SelectedIndex <= 0)
                    DocInc["idstamphandling"] = DBNull.Value;
                else
                    DocInc["idstamphandling"] = cmbBollo.SelectedValue;

                if (flagcreddeb) DocInc["idreg"] = REntrata["idreg"];
                if (flagbilancio) DocInc["idfin"] = idbilancioreversale;
                if (flagrespons) DocInc["idman"] = REntrata["idman"];

                int flag_pro = CfgFn.GetNoNullInt32(DocInc["flag"]);
                flag_pro &= 0xF0;

                if (flagresidui) {
                    string flagComp = CalcolaFlagCompetenza();

                    flag_pro &= 0xF8;

                    if (flagComp == "C") {
                        flag_pro |= 0x01;
                    }
                    else {
                        flag_pro |= 0x02;
                    }
                }
                else {
                    flag_pro |= 0x04;
                }

                if (rdbFruttifero.Checked) {
                    flag_pro |= 0x08;
                }
                
                DocInc["flag"] = flag_pro;
			}
		    impostaFlagNonContabilizzazione();
		}

        string CalcolaFlagCompetenza() {
            int fasebilancio = ManageBilAnnuale.faseattivazione;
            if (faseinizio <= fasebilancio) {
                return "C";
            }
            else {
                DataRow CurrExp = DS.income.Rows[0];
                object parid = CurrExp["parentidinc"];
                if (parid == DBNull.Value) {
                    return "C";
                }
                else { // Devo ricavare il movimento da DB
                    object ycurr = Meta.GetSys("esercizio");

                    object value = Meta.Conn.DO_READ_VALUE("incometotal",
                        QHS.AppAnd(QHS.CmpEq("idinc", parid), QHS.CmpEq("ayear", ycurr)), "flag");
                    byte flag = Convert.ToByte(value);
                    bool flagarrear = (flag & 1) == 1;
                    return (flagarrear) ? "R" : "C";
                }
            }
        }

		#endregion



		/// <summary>
		/// Restituisce un decimal da una stringa
		/// </summary>
		/// <param name="S"></param>
		/// <returns></returns>
		private decimal Dec(string S) {
			if(S.Length == 0) return 0;
			try {
				return Convert.ToDecimal(S);
			}
			catch {
				return 0;
			}
		}
		//restituisce una stringa da un decimal
		private string Str(decimal D) {
			if(D == 0) return "";
			return D.ToString("c");
		}


	
		private void btnGerarchia_Click(object sender, System.EventArgs e) {
			MetaData newEntrata = MetaData.GetMetaData(this,"income");
			if (DSP==null) return;
			if (!Meta.EditMode) return;
			DataTable entrata= DSP.Tables["income"];
			DataRow []myR  = entrata.Select("nphase='"+faseentratafine.ToString()+"'");
			if (myR.Length==0) return;
			newEntrata.Edit(this.ParentForm, "gerarchico",false);
			
			object identrata= myR[0]["idinc"];
			//DS.spesa.Rows[0]["idspesa"].ToString();

			DataRow R = newEntrata.SelectOne(newEntrata.DefaultListType, 
                QHS.CmpEq("idinc", identrata),"income",null);
			if (R!=null) newEntrata.SelectRow(R,newEntrata.DefaultListType);

		}

		private void btnGeneraClassAutomatiche_Click(object sender, System.EventArgs e) {
			ManageClassificazioni.btnGeneraClass_Click(faseinizio,faseentratafine);
            //if siopekind.newcomputesorting ='S' aggiunge le class. , leggendo il Cod.Class. dal documento contabilizzato 
            string newcomputesorting = Meta.Conn.DO_READ_VALUE("siopekind",
	            QHS.AppAnd( QHS.CmpEq("codesorkind_siopeentrate", Meta.GetSys("codesorkind_siopeentrate")),
		            QHS.CmpEq("ayear",CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
	            ), 
	            "newcomputesorting")?.ToString();
            if ((newcomputesorting == "S") && (faseentratafine == faseentratamax)) {
                //Classifica il movimento in base all'idsor_siope specificato nel documento contabilizzato
                ManageClassificazioni.ClassificaTramiteClassDocumento(DS, null);
				ManageClassificazioni.completaClassificazioniSiope(DS.incomesorted, DS);
				Meta.FreshForm();
			}
        }


		void GetLastRowIDS(){
			DataRow LastMov = GetLastPhaseRow();
			DataRow [] LastImps = LastMov.GetChildRows("entrataimputazioneentrata");


		}

		public void copiaTabella(DataTable sorg, DataTable dest) 
		{
			dest.Clear();
			if (DS.income.Rows.Count==0) return;
			DataRow RE= DS.income.Rows[0];
			foreach (DataRow rp in sorg.Rows) 
			{
				DataRow r = dest.NewRow();
				r["idinc"]= RE["idinc"];
				foreach (DataColumn c in sorg.Columns) 
				{
					if (c.ColumnName == "idinc") continue;
					r[c.ColumnName] = rp[c.ColumnName];
				}
				dest.Rows.Add(r);
			}
			dest.AcceptChanges();
		}

	

		private void tabControl1_SelectionChanged(object sender, System.EventArgs e) {
		
		}

	
		#region Gestione ComboBox Causali (generico)

		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui è agganciato il combo causale
		/// </summary>
		void ClearComboCausale(){
			DataTable TCombo= DS.tipomovimento;
			TCombo.Clear();
			cmbCausale.Enabled=false;
		}

		void EnableTipoMovimento(int IDtipo, string descrtipo){
			DataRow R = DS.tipomovimento.NewRow();
			R["idtipo"]= IDtipo;
			R["descrizione"]= descrtipo;
			DS.tipomovimento.Rows.Add(R);
			DS.tipomovimento.AcceptChanges();
		}

		/// <summary>
		/// Restituisce la contabilizzazione selezionata nel combobox cmbTipoContabilizz.
		/// </summary>
		/// <returns></returns>
		tipocont ContabilizzazioneSelezionata(){
			if (cmbTipoContabilizzazione.Items.Count==0) return tipocont.cont_none;
			if (cmbTipoContabilizzazione.SelectedItem == null) return tipocont.cont_none;
			string currTipo = cmbTipoContabilizzazione.SelectedItem.ToString();
			tipocont codecont= CodiceContabilizzazione(currTipo);
			return codecont;
		}
		private void cmbTipoContabilizzazione_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (DisabilitaEventiTipoDocumento)return;
			tipocont codecont = ContabilizzazioneSelezionata();
			AttivaContabilizzazione(codecont);
		}
		

		/// <summary>
		/// Imposta il valore del combobox ed aggiorna l'importo del movimento
		/// </summary>
		/// <param name="tipomovimento"></param>
		/*void SetValueComboCausale(string tipomovimento){
			cmbCausale.SelectedValue= tipomovimento;
			RecalcImporto();
		}*/

		void RecalcImporto(){
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
					//				case tipocont.cont_missione:
					//					ReCalcImporto_Missione();
					//					return;
					//				case tipocont.cont_ordine:
					//					ReCalcImporto_Ordine();
					//					return;
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

		private void cmbCausale_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					cmbCausaleIva_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_estimate:
					cmbCausaleEstimate_SelectedIndexChanged(sender,e);
					break;				
			}
		}

		private void btnDocumento_Click(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					btnIva_Click(sender,e);
					break;
				case tipocont.cont_estimate:
					btnEstimate_Click(sender,e);
					break;
			}
		}

		private void txtEsercDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					txtEsercIva_Leave(sender,e);
					break;
				case tipocont.cont_estimate:
					txtEsercEstimate_Leave(sender,e);
					break;
			}
		}

		private void txtNumDoc_Leave(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					txtNumIva_Leave(sender,e);
					break;
				case tipocont.cont_estimate:
					txtNumEstimate_Leave(sender,e);
					break;
			}
		}




		/// <summary>
		/// Imposta il combo del tipo contabilizzazione con un valore assegnato
		/// </summary>
		/// <param name="tipo"></param>
		void SetContabilizzazione(tipocont tipo){
			for (int i=0; i< cmbTipoContabilizzazione.Items.Count; i++){
				if (cmbTipoContabilizzazione.Items[i].ToString()== 
					NomeContabilizzazione(tipo)){
					if (cmbTipoContabilizzazione.SelectedIndex!=i){
						if ((i!=0)||(cmbTipoContabilizzazione.SelectedIndex!=-1)){
							cmbTipoContabilizzazione.SelectedIndex=i;
						}
					}
				}
			}
		}
		bool DisabilitaEventiTipoDocumento=false;

		
		private void cmbTipoDocumentoGenerico_SelectedIndexChanged(object sender, System.EventArgs e) {
			tipocont currcont= ContabilizzazioneSelezionata();
			switch (currcont){
				case tipocont.cont_iva:
					cmbTipoDocumento_SelectedIndexChanged(sender,e);
					break;
				case tipocont.cont_estimate:
					cmbTipoEstimate_SelectedIndexChanged(sender,e);
					break;
			}
		}

		/// <summary>
		/// Ricalcola il combo delle contabilizzazioni in base alle fasi selezionate,
		///  ed eventualmente scollega i documenti non più collegabili
		/// </summary>
		void GestioneFasePerDocumentoCollegato(){
			tipocont oldcont = ContabilizzazioneSelezionata();
			//disabilita gli eventi collegati al cmbTipoContabilizzazione
			DisabilitaEventiTipoDocumento=true;
			cmbTipoContabilizzazione.Items.Clear();
			CalcolaContabilizzazioniPossibili();
			if (ContabilizzazioneAttivabile(oldcont)){
				SetContabilizzazione(oldcont);				
				VisualizzaControlliContabilizzazione(oldcont);
				DisabilitaEventiTipoDocumento=false;
				cmbTipoContabilizzazione.Enabled=(!Meta.EditMode);
				return;
			}
			DisabilitaEventiTipoDocumento=false;
			cmbTipoContabilizzazione.Enabled=(!Meta.EditMode);
			SetContabilizzazione(tipocont.cont_none);
			AttivaContabilizzazione(tipocont.cont_none);
		}

		void AbilitaDisabilitaControlliContabilizzazione(bool abilita){
			cmbCausale.Enabled= abilita && (!Meta.EditMode);
			cmbTipoDocumento.Enabled= abilita && (!Meta.EditMode);
			btnDocumento.Enabled=abilita && (!Meta.EditMode);
			txtEsercDoc.ReadOnly=(!abilita) || Meta.EditMode;
			txtNumDoc.ReadOnly=(!abilita)||Meta.EditMode;
			cmbTipoContabilizzazione.Enabled=abilita && (!Meta.EditMode);
		}

		void CambiaTagControlliComuni(string tablevista){
			txtCodiceBilancio.Tag=
				"finview.codefin?"+
				tablevista+	".codefin";
            //txtCredDeb.Tag=
            //    "registry.title?"+
            //    tablevista+	".registry";
            //SubEntity_comboUPB.Tag=
            //    "incomeyear.idupb?"+
            //    tablevista+	".idupb";
			SubEntity_txtImportoMovimento.Tag=
				"incomeyear.amount?"+
				tablevista+".ayearstartamount";
		}


		/// <summary>
		/// Visualizza/Nasconde i controlli relativi alla contabilizzazione scelta, 
		///  (inclusi btn, txtCredDeb, etc. ) impostandone anche i tag. 
		/// </summary>
		/// <param name="codecont"></param>
		void VisualizzaControlliContabilizzazione(tipocont codecont){
			txtEsercDoc.ReadOnly= Meta.EditMode;
			txtNumDoc.ReadOnly=Meta.EditMode;
			btnDocumento.Enabled= !Meta.EditMode;
			cmbTipoDocumento.Enabled = !Meta.EditMode;


			switch(codecont){
				case tipocont.cont_estimate:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;

					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					btnDocumento.Text="Contratto Attivo";
					txtEsercDoc.Tag=
						"incomeestimate.yestim?"+
						"incomeestimateview.yestim";
					txtNumDoc.Tag=
						"incomeestimate.nestim?"+
						"incomeestimateview.nestim";
					cmbTipoDocumento.Tag=
						"incomeestimate.idestimkind?"+
						"incomeestimateview.idestimkind";
					AbilitaDisabilitaControlliContratto(true);
					ImpostaComboEstimateKind();
					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.incomeestimate.Rows.Count==0);
					}
					gboxDettEstimate.Visible=true;
					break;
				case tipocont.cont_iva:
					cmbCausale.Visible=true;
					labelCausale.Visible=true;
					gboxDocumento.Visible=true;
					
					labelTipoDocumento.Visible=true;
					cmbTipoDocumento.Visible=true;
					btnDocumento.Text="Documento";
					txtEsercDoc.Tag=
						"incomeinvoice.yinv?"+
						"incomeinvoiceview.yinv";
					txtNumDoc.Tag=
						"incomeinvoice.ninv?"+
						"incomeinvoiceview.ninv";
					cmbTipoDocumento.Tag=
						"incomeinvoice.idinvkind?"+
						"incomeinvoiceview.idinvkind";
					AbilitaDisabilitaControlliFattura(true);
					ImpostaComboInvoiceKind();
					if (Meta.IsEmpty)	{
						AbilitaDisabilitaCreditoreDebitore(true);
					}
					else {
						AbilitaDisabilitaCreditoreDebitore(DS.incomeinvoice.Rows.Count==0);
					}
					gboxDettInvoice.Visible=true;
					SubEntity_txtImportoMovimento.ReadOnly=true;
					break;
				case tipocont.cont_none:
					cmbTipoDocumento.Tag= null;
					txtEsercDoc.Tag=null;
					txtNumDoc.Tag=null;
					NascondiControlliContabilizzazione();
					gboxDettInvoice.Visible=false;
					gboxDettEstimate.Visible=false;
					SubEntity_txtImportoMovimento.ReadOnly=false;
					break;
			}
			//ClearComboCausale();
		}
		

		void ImpostaComboInvoiceKind(){
			if (cmbTipoDocumento.DataSource!=null){
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idinvkind"]!=null) return;
			}
			TipoDocChangePilotato=true;
			cmbTipoDocumento.DataSource= DS.invoicekind;
			cmbTipoDocumento.DisplayMember="description";
			cmbTipoDocumento.ValueMember="idinvkind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento,null);
			TipoDocChangePilotato=false;
		}

		void ImpostaComboEstimateKind(){
			if (cmbTipoDocumento.DataSource!=null){
				DataTable T = cmbTipoDocumento.DataSource as DataTable;
				if (T.Columns["idestimkind"]!=null) return;
			}
			TipoDocChangePilotato=true;
			cmbTipoDocumento.DataSource= DS.estimatekind;
			cmbTipoDocumento.DisplayMember="description";
			cmbTipoDocumento.ValueMember="idestimkind";
			Meta.myHelpForm.PreFillControlsTable(cmbTipoDocumento,null);
			TipoDocChangePilotato=false;
		}



		void NascondiControlliContabilizzazione(){
			cmbCausale.Visible=false;
			labelCausale.Visible=false;
			gboxDocumento.Visible=false;
		}

		public enum tipocont {cont_none,cont_iva,cont_estimate};
		public tipocont currcont;

		string NomeContabilizzazione(tipocont TIPO){
			switch (TIPO){
				case tipocont.cont_iva: return "Documento Iva";
				case tipocont.cont_estimate: return "Contratto Attivo";
				case tipocont.cont_none: return "";
			}
			return null;
		}
		tipocont CodiceContabilizzazione(string nomecont){
			switch(nomecont){
				case "Documento Iva": return tipocont.cont_iva;
				case "Contratto Attivo": return tipocont.cont_estimate;
				case "":return tipocont.cont_none;
			}
			return tipocont.cont_none;
		}

		/// <summary>
		/// Stabilisce se è possibile con la fase corrente contabilizzare un
		///  certo tipo di documento
		/// </summary>
		/// <returns></returns>
		bool ContabilizzazioneAttivabile(tipocont codecont){
			switch(codecont){
				case tipocont.cont_iva:
					if ((faseinizio<=faseiva)&&(faseiva<=faseentratafine))return true;
					return false;
				case tipocont.cont_estimate:
					if (faseEntrataInclusa())return true;
					return false;

				default:
					return false;
			}
		}


		/// <summary>
		/// Riempie il Combo del tipo di Contabilizzazione con
		///  le scelte possibili in base alla fase corrente
		/// </summary>
		void CalcolaContabilizzazioniPossibili(){
			cmbTipoContabilizzazione.Items.Clear();
			cmbTipoContabilizzazione.Items.Add("");
			foreach (tipocont codecont in new tipocont[] { tipocont.cont_estimate,tipocont.cont_iva}){
				if (ContabilizzazioneAttivabile(codecont))
					cmbTipoContabilizzazione.Items.Add(
						NomeContabilizzazione(codecont));
			}																								   
		}
		
		void AbilitaDisabilitaCreditoreDebitore(bool abilita){
			if (!abilita){
				txtCredDeb.ReadOnly = true;
				return;
			}
			int fasecreditore= ManageCreditore.faseattivazione;
			bool CreditoreAbilitato = (faseinizio<= fasecreditore)&& (fasecreditore<=faseentratafine);
			txtCredDeb.ReadOnly= !CreditoreAbilitato;
		}

		/// <summary>
		/// Funzione chiamata quando cambia il combo delle contabilizzazioni
		/// Disattiva tutte le contabilizzazioni e poi attiva quella indicata.
		/// Scollega qualsiasi documento collegato
		/// </summary>
		/// <param name="codecont"></param>
		void AttivaContabilizzazione(tipocont codecont){
			foreach(tipocont disattivacont in new tipocont[]{tipocont.cont_iva,
															 tipocont.cont_estimate}){
				DisattivaContabilizzazione(disattivacont);
			}
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			switch(codecont){
				case tipocont.cont_iva:
					CambiaTagControlliComuni("incomeinvoiceview");
					Meta.DefaultListType="iva";
					break;
				case tipocont.cont_estimate:
					CambiaTagControlliComuni("incomeestimateview");
					Meta.DefaultListType="estimate";
					break;
				case tipocont.cont_none:
					CambiaTagControlliComuni("incomeview");
					Meta.DefaultListType="default";
					break;
			}
			VisualizzaControlliContabilizzazione(codecont);
			ClearComboCausale();
		}

		void DisattivaContabilizzazione(tipocont codecont){
			if (!Meta.InsertMode) return;
			switch(codecont){
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
			out int CurrCausaleIva){
			CurrCausaleIva=0;
			DataRow MiddleRow;
			IvaRow= GetDocRow("invoice","incomeinvoice",faseiva,out MiddleRow);
			CurrIvaMovEntrataRow= MiddleRow;
            //IvaMovEntrataView=null;
			if (IvaRow==null)return;
			if (MiddleRow!=null) CurrCausaleIva= CfgFn.GetNoNullInt32( MiddleRow["movkind"]);
            //string keyfilter= QueryCreator.WHERE_KEY_CLAUSE(IvaRow,
            //    DataRowVersion.Default,
            //    true);
            //IvaMovEntrataView = MyConn.RUN_SELECT("incomeinvoiceview","*",null,keyfilter,null,true);
		}

		void GetDocEstimate(out DataRow EstimateRow, 
			out DataRow CurrEstimateMovEntrataRow,
            //out DataTable EstimateMovEntrataView, 
			out int CurrCausaleEstimate){
			CurrCausaleEstimate=0;
			DataRow MiddleRow;
			EstimateRow= GetDocRow("estimate","incomeestimate",faseentrata,out MiddleRow);
			CurrEstimateMovEntrataRow= MiddleRow;
            //EstimateMovEntrataView=null;
			if (EstimateRow==null)return;
			if (MiddleRow!=null) CurrCausaleEstimate= CfgFn.GetNoNullInt32( MiddleRow["movkind"]);
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
			){
			CurrMiddleDocRow=null;
			if (Meta.IsEmpty) return null;
			string movimentotable = "income";
			if ((faseinizio<=faseattivazione)&&(faseattivazione<=faseentratafine)){
				//Se la fase attivazione è inclusa nel range, è possibile che 
				// il documento sia stato selezionato e sia in memoria, oppure che non 
				// sia stato selezionato il documento e quindi non ci sono righe
				if (DS.Tables[tablename].Rows.Count==0) return null;
				CurrMiddleDocRow= DS.Tables[middletablename].Rows[0];
				return DS.Tables[tablename].Rows[0];
			}
			else {
				//Se la fase attivazione è successiva al range, non può esistere alcun 
				// documento collegato
				if (faseentratafine<=faseattivazione) return null;

				//L'unico caso rimasto è che la faseattivazione è precedente al range

				//Se è stato selezionato un livsupid, è possibile partire da quello come
				// base per selezionare il giusto movimento di fase precedente.
				DataRow Curr = DS.income.Rows[0];
				object livsupid= Curr["parentid"+movimentotable.Substring(0,3)];
				if (livsupid==DBNull.Value)return null; //non è stato ancora selezionato
                object idattivazione = MyConn.DO_READ_VALUE(movimentotable + "link",
                    QHS.AppAnd(QHS.CmpEq("idchild", livsupid),
                                QHS.CmpEq("nlevel", faseattivazione)), "idparent");
                if (idattivazione == null) return null;
                if (idattivazione == DBNull.Value) return null;
				DataTable Middle= MyConn.RUN_SELECT(middletablename,"*",null,
                    QHS.CmpEq("id"+movimentotable.Substring(0,3), idattivazione),
					null,true);
				if (Middle.Rows.Count==0) return null;
				CurrMiddleDocRow = Middle.Rows[0];
				DataTable Doc= DS.Tables[tablename];
				string dockeyfilter = QueryCreator.WHERE_REL_CLAUSE(CurrMiddleDocRow,
					Doc.PrimaryKey, Doc.PrimaryKey, DataRowVersion.Default, true);
				DataTable Documento= MyConn.RUN_SELECT(tablename,"*",null,dockeyfilter, null,true);
				if (Documento.Rows.Count==0) return null; //non dovrebbe accadere
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
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
			//CalcolaStartFilter(null);
		}

		string GetFilterIva(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			FilterIva="(yinv<='"+esercizio.ToString()+"')";
			if(txtEsercDoc.Text != ""){
				int esercdocumento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercdocumento <= esercizio) 
						FilterIva="(yinv='"+esercdocumento.ToString()+"')";
					else 
						FilterIva = GetData.MergeFilters(FilterIva,
							"(yinv='"+esercdocumento.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numdocumento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterIva = GetData.MergeFilters(FilterIva,
						"(ninv='"+numdocumento.ToString()+"')");
				} 
			}
			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex<=0){
                filtertipodoc = QHS.AppAnd(QHS.BitSet("flag", 0), QHS.BitClear("flag", 2));
			}
			else {
				filtertipodoc = "(idinvkind="+
					QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue,true)+")";
			}
			FilterIva = GetData.MergeFilters(FilterIva, filtertipodoc);

			if (Meta.InsertMode){
				FilterIva+="AND(residual>'0')AND((active is null)OR(active='S'))";
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
			if (((Control)sender).Name == "txtNumDoc")
				MyIvaFilter = GetFilterIva(true);
			else
				MyIvaFilter = GetFilterIva(false);

			MyFilterDocumentoIva= MyIvaFilter;
			MyFilterIvaOperativo= MyIvaFilter;

			if (Meta.InsertMode){
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred<faseinizio);
				DataRow Curr = DS.income.Rows[0];
				bool faseprecselected = (Curr["parentidinc"]!=DBNull.Value);
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
					((txtCredDeb.ReadOnly==false) && (txtCredDeb.Text.Trim()!=""))
					){
					MyFilterDocumentoIva = GetData.MergeFilters(MyFilterDocumentoIva,
						"(idreg="+
						QueryCreator.quotedstrvalue(Curr["idreg"],true)+")");
					MyFilterIvaOperativo= GetData.MergeFilters(MyFilterIvaOperativo,
						"(registry="+
						QueryCreator.quotedstrvalue(txtCredDeb.Text,true)+")");
				}
				bool condfaseupb= (ManageUPB.faseattivazione< faseinizio);
                object getupb = GetUpb();
				if ( (condfaseupb && faseprecselected)||
					(getupb!=DBNull.Value&& txtUPB.Enabled) ){
                    object idupb = getupb;
                    MyFilterIvaOperativo = QHS.AppAnd(MyFilterIvaOperativo,
                            QHS.DoPar(QHS.AppOr(QHS.IsNull("idupb"), QHS.CmpEq("idupb", idupb), QHS.CmpEq("idupb_iva", idupb))));
                    }
			}
			if (Meta.IsEmpty){
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred<faseinizio);
				bool faseprecselected = (txtCredDeb.Text.Trim()!="");
				if (condfasecred && faseprecselected){
					MyFilterIvaOperativo= GetData.MergeFilters(MyFilterIvaOperativo,
						"(registry="+
						QueryCreator.quotedstrvalue(txtCredDeb.Text,true)+")");
				}
			}

			MetaData MDocumentoIva;
			DataRow MyDRIva;

			if (Meta.IsEmpty) {
				MDocumentoIva = MetaData.GetMetaData(this,"invoiceincomelinked");
				MDocumentoIva.FilterLocked=true;			
				MDocumentoIva.DS = DS.Clone();
				MyDRIva = MDocumentoIva.SelectOne("default",MyFilterDocumentoIva,null,null);
				if (MyDRIva==null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				TipoDocChangePilotato=true;				
				HelpForm.SetComboBoxValue(cmbTipoDocumento,MyDRIva["idinvkind"]);
				TipoDocChangePilotato=false;
				txtEsercDoc.Text= MyDRIva["yinv"].ToString();
				txtNumDoc.Text= MyDRIva["ninv"].ToString();
				return;
			}

			MDocumentoIva = MetaData.GetMetaData(this,"invoiceresidualestimate");
			MDocumentoIva.FilterLocked=true;
			MDocumentoIva.DS = DS.Clone();
			
			MyDRIva = MDocumentoIva.SelectOne("default",MyFilterIvaOperativo,null,null);
			
			if(MyDRIva == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectord= 
				"(idinvkind="+QueryCreator.quotedstrvalue(MyDRIva["idinvkind"],true)+")AND"+
				"(yinv='"+MyDRIva["yinv"].ToString()+"')AND"+
				"(ninv='"+MyDRIva["ninv"].ToString()+"')";

			string columnlist = QueryCreator.ColumnNameList(DS.invoice)+
				",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("invoiceview",columnlist,null,selectord,null,null,false);
			
			if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];
			if (Meta.InsertMode) {
				while (true){ //escamotage per impedire che il livello di indentazione arrivi alle stelle
					//Si collega all'impegno ove presente
                    object idinc_taxableestim = MyDRIva["idinc_taxableestim"];
					object idinc_ivaestim=MyDRIva["idinc_ivaestim"];
					if (idinc_taxableestim==DBNull.Value && idinc_ivaestim==DBNull.Value)break;
					DataRow Curr = DS.income.Rows[0];
					bool faseprecselected = (Curr["parentidinc"]!=DBNull.Value);
					if (faseprecselected) break;
					int precphase = faseinizio-1;
					if (precphase <=0) break;
                    //int preclen = precphase*8;
					string filterprec= "(nphase='"+precphase+"')"+
						GetFilterIdIncEstim(idinc_ivaestim,idinc_taxableestim)
						+"and(available>'0')";

					MetaData MFase = MetaData.GetMetaData(this,"incomeview");
					MFase.FilterLocked=true;
					MFase.DS=DS;

					int NEXP=Meta.Conn.RUN_SELECT_COUNT("incomeview",filterprec,false);
					if (NEXP==0){
						MessageBox.Show("Non è stato trovato un movimento di entrata a cui agganciare questo incasso,"+
							" ai fini di una corretta associazione contratto attivo - fattura.");
						break;
					}
		
					DataRow MyDR2 = null;
			
					while (MyDR2==null) {
						if (NEXP>1) MessageBox.Show("E' ora necessario scegliere il mov. di entrata a cui agganciare questo incasso,"+
										" ai fini di una corretta associazione contratto attivo - fattura.");
						MyDR2 =	MFase.SelectOne("elencofaseprec",filterprec,null,null);					
					}
					txtNumeroFasePrecedente.Text= MyDR2["nmov"].ToString();
					txtEsercizioFasePrecedente.Text=MyDR2["ymov"].ToString();
					btnFasePrecedente_Click(txtNumeroFasePrecedente,null);
					break;
				}

			}
		
			//Inserisco nella riga attuale il valore idinc nel campo parentidinc
			//al fine di consentire il calcolo automatico del nuovo idinc.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				ResetIva();
				CollegaIva(MyDR,MyDRIva);
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
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;
			//CalcolaStartFilter(null);


			if (txtNumDoc.Text.Trim()==""){
				if (Meta.InsertMode) ScollegaIva();				
				ClearControlliIva(true);
				int fasecred = ManageCreditore.faseattivazione;
				if (fasecred<faseinizio) return;
				txtCredDeb.Text="";
				return;
			}


			btnIva_Click(sender,e);
		}

		void ClearControlliIva(bool skipTipoDoc){
			//txtCredDeb.Text = "";		
			txtDescrizione.Text= "";
			txtDocumento.Text= "";
			txtDataDocumento.Text = "";
            SetResponsabile(DBNull.Value);
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex=-1;
			AbilitaDisabilitaCreditoreDebitore(true);
		}

		void AbilitaDisabilitaControlliIva(bool abilita){
			AbilitaDisabilitaCreditoreDebitore(abilita);
			//txtCredDeb.ReadOnly=!abilita;
		}

		
		void VisualizzaMainInfo_Iva(DataRow Iva2){

			if (!faseIvaInclusa())return;
			gboxDettInvoice.Visible=true;
			cmbTipoDocumento.Tag=
				"incomeinvoice.idinvkind?"+
				"incomeinvoiceview.idinvkind";

			txtNumDoc.Text= Iva2["ninv"].ToString();
			txtEsercDoc.Text = Iva2["yinv"].ToString();
			ImpostaComboInvoiceKind();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,
				Iva2["idinvkind"]);
			TipoDocChangePilotato=false;
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
		void CollegaIva(DataRow Iva2, DataRow IvaResiduo){
			if (Meta.IsEmpty) return;
			if (!faseIvaInclusa()) return;

			Hashtable ValoriDocumentoIva = new Hashtable();
			foreach (DataColumn C in Iva2.Table.Columns) 
				ValoriDocumentoIva[C.ColumnName]= Iva2[C.ColumnName];

			ScollegaIva();

			gboxDettInvoice.Visible=true;


			DataRow NewIvaR = DS.invoice.NewRow();

			foreach (DataColumn C in DS.invoice.Columns){
				NewIvaR[C.ColumnName]= ValoriDocumentoIva[C.ColumnName];
			}

			DS.invoice.Rows.Add(NewIvaR);
			NewIvaR.AcceptChanges();

			DataRow CurrRow= DS.income.Rows[0];
			DataRow CurrImpRow= DS.incomeyear.Rows[0];
			MetaData MovIva = MetaData.GetMetaData(this,"incomeinvoice");
			MovIva.SetDefaults(DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue=ValoriDocumentoIva["idinvkind"];
			DS.incomeinvoice.Columns["ninv"].DefaultValue= ValoriDocumentoIva["ninv"];
			DS.incomeinvoice.Columns["yinv"].DefaultValue= ValoriDocumentoIva["yinv"];
			txtNumDoc.Text=ValoriDocumentoIva["ninv"].ToString();
			txtEsercDoc.Text=ValoriDocumentoIva["yinv"].ToString();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriDocumentoIva["idinvkind"]);
			TipoDocChangePilotato=false;

			DataRow RMovIva = MovIva.Get_New_Row(CurrRow, DS.incomeinvoice);
			DS.incomeinvoice.Columns["idinvkind"].DefaultValue = DBNull.Value;
			DS.incomeinvoice.Columns["ninv"].DefaultValue= DBNull.Value;
			DS.incomeinvoice.Columns["yinv"].DefaultValue= DBNull.Value;

			CurrRow["idreg"] = ValoriDocumentoIva["idreg"];
			CurrRow["description"] = ValoriDocumentoIva["description"];
			txtDescrizione.Text= ValoriDocumentoIva["description"].ToString();

//			CurrRow["documento"] = "Doc."+
//				ValoriDocumentoIva["esercdocumento"].ToString().Substring(2,2)+"/"+
//				ValoriDocumentoIva["numdocumento"].ToString().PadLeft(6,'0');
//			//"Ord."+ValoriOrdine["documento"];
//			txtDocumento.Text = CurrRow["documento"].ToString();
//			CurrRow["datadocumento"] = ValoriDocumentoIva["datacontabile"];
//			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["datacontabile"], txtDataDocumento.Tag.ToString());

			CurrRow["doc"] = "Doc."+ValoriDocumentoIva["doc"];
			txtDocumento.Text = "Doc."+ValoriDocumentoIva["doc"];
			CurrRow["docdate"] = ValoriDocumentoIva["docdate"];
			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["docdate"], txtDataDocumento.Tag.ToString());

			//CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

			if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != ValoriDocumentoIva["idreg"].ToString()){
					DS.registry.Clear();
					//DS.modpagamentocreddebi.Clear();
				}
			}

			if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"]);
				//CalcolaValoriDefaultModPagamento(CurrRow["codicecreddeb"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
				//SetComboCreditoreDebitore(CredDeb);
				txtCredDeb.Text= CredDeb["title"].ToString();
			}

            if (IvaResiduo["idupb"] != DBNull.Value && IvaResiduo["idupb_iva"] == DBNull.Value){
                SetUPB(IvaResiduo["idupb"]);
            }
            else{
                CurrImpRow["idupb"] = GetUpb();
            }    
            //Meta.myHelpForm.FillControls(tabMovFin.Controls);
			IvaLinkedMustBeEvalued=true;
			RintracciaIva();
			SetComboCausaleIva(IvaResiduo);
			AbilitaDisabilitaControlliIva(false);

		}

        object LeggiDaCombo(ComboBox C){
            if ((C.SelectedValue == null) || (C.SelectedIndex <= 0)){
                return DBNull.Value;
            }
            else{
                return C.SelectedValue;
            }
        }

		void ResetDocumentiFasiNonIncluse(){
			
			if (!faseContrattoInclusa()){
				ResetEstimate();
			}
			if (!faseIvaInclusa()){
				ResetIva();
			}
		}


        void LeggiDatiSuCredDeb(object codicecreddeb) {
            if (codicecreddeb == DBNull.Value) return;
            QueryCreator.MyClear(DS.registry);
            string filter = QHS.CmpEq("idreg", codicecreddeb);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.registry, null, filter, null, true);
        }
	
		void ScollegaIva(){
			gboxDettInvoice.Visible=false;
			if (DS.incomeinvoice.Rows.Count==0) return;
			DS.incomeinvoice.Clear();
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			DS.invoice.Clear();
			ClearComboCausale();
			DataRow CurrRow= DS.income.Rows[0];
			DataRow CurrImpRow= DS.incomeyear.Rows[0];
			int fasecreditore= ManageCreditore.faseattivazione;
			if (fasecreditore>=faseinizio){
				CurrRow["idreg"] = DBNull.Value;
				txtCredDeb.Text = "";		
				DS.registry.Clear();
			}
			if (fasecreditore<faseinizio && txtNumeroFasePrecedente.Text==""){
				CurrRow["idreg"]=DBNull.Value;
				txtCredDeb.Text="";
				DS.registry.Clear();
			}

			int faseupb = ManageUPB.faseattivazione;
			if (faseupb<faseinizio && txtNumeroFasePrecedente.Text==""){
                SetUPB(DBNull.Value);
			}
			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
			//CurrRow["codiceresponsabile"]=DBNull.Value;
			CurrRow["description"]="";
			ClearControlliIva(false);
		}
		
		string CalculateFilterForInvoiceDetailLinking(bool SQL){
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
            string filter_insideA = "";
            string filter_insideB = "";

            object idreg = DS.income.Rows[0]["idreg"].ToString();
            object idupb = GetUpb();

            //MyFilter = "(idinvkind="+
            //    QueryCreator.quotedstrvalue(IvaLinked["idinvkind"],SQL)+")AND"+
            //    "(yinv="+
            //    QueryCreator.quotedstrvalue(IvaLinked["yinv"],SQL)+")AND"+
            //    "(ninv="+
            //    QueryCreator.quotedstrvalue(IvaLinked["ninv"],SQL)+")"; 
            MyFilter = qh.AppAnd(MyFilter, qh.MCmp(IvaLinked, "idinvkind", "yinv", "ninv"));

            if (idupb != DBNull.Value){
                if (CurrCausaleIva == 1){
                    //totale, prende upb standard
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }
                if (CurrCausaleIva == 2){
                    //IVA
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("isnull(idupb_iva,idupb)", idupb));
                }
                if (CurrCausaleIva == 3){
                    //imponibile 
                    MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("idupb", idupb));
                }
            }

            bool filterparent = false;
            object parid = DBNull.Value;
            if (Meta.InsertMode) {
                DataRow Curr = DS.income.Rows[0];
                filterparent = (Curr["parentidinc"] != DBNull.Value);
                if (filterparent) parid = Curr["parentidinc"];
            }

            //if (CurrCausaleIva == 1) {
            //    MyFilter += "AND (idinc_iva is null and idinc_taxable is null)";
            //    if (filterparent) MyFilter +=
            //         "AND ((idinc_taxableestim is null AND idinc_ivaestim is null) " +
            //                          " OR (idinc_ivaestim = idinc_taxableestim AND " +
            //                          " idinc_taxableestim in (SELECT idparent from incomelink where idchild=" +
            //                          QueryCreator.quotedstrvalue(parid, true) + ")" +
            //         "))";
            //}

            if (CurrCausaleIva == 1)
            {
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));

                if (filterparent)
                {
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_taxableestim"));
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_ivaestim"));
                    filter_insideB = qh.CmpEq("idinc_ivaestim", qh.Field("idinc_taxableestim"));
                    DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null, QHS.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");

                    MyFilter = qh.AppAnd(MyFilter, qh.DoPar(qh.AppOr(filter_insideA, qh.AppAnd(filter_insideB, qh.FieldInList("idinc_taxableestim", lista)))));
                }
            }



            //if (CurrCausaleIva == 2) {
            //    MyFilter += "AND (idinc_iva is null)";
            //    if (filterparent) MyFilter += "AND (idinc_ivaestim is null OR " +
            //         " idinc_ivaestim in (SELECT idparent from incomelink where idchild=" +
            //         QueryCreator.quotedstrvalue(parid, true) + ")" + ")";

            //    //if (filterparent) MyFilter += "AND (idinc_ivaestim is null OR '" + parid + "' like idinc_ivaestim +'%')";

            //}

            if (CurrCausaleIva == 2)
            {
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
                if (filterparent)
                {
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_ivaestim"));
                    DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null, QHS.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");
                    MyFilter = qh.AppAnd(MyFilter, qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idinc_ivaestim", lista))));
                }
            }


            //if (CurrCausaleIva == 3) {
            //    MyFilter += "AND (idinc_taxable is null)";
            //    if (filterparent) MyFilter += "AND (idinc_taxableestim is null OR " +
            //        " idinc_taxableestim in (SELECT idparent from incomelink where idchild=" +
            //        QueryCreator.quotedstrvalue(parid, true) + ")" + ")";
            //    //if (filterparent)MyFilter+="AND (idinc_taxableestim is null OR '"+parid+"' like idinc_taxableestim +'%')";
            //}

            if (CurrCausaleIva == 3)
            {
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));
                if (filterparent)
                {
                    filter_insideA = qh.AppAnd(filter_insideA, qh.IsNull("idinc_taxableestim"));
                    DataTable IncomeLink = Meta.Conn.RUN_SELECT("incomelink", "idparent", null, QHS.CmpEq("idchild", parid), null, true);
                    string lista = qh.DistinctVal(IncomeLink.Select(), "idparent");
                    MyFilter = qh.AppAnd(MyFilter, qh.DoPar(qh.AppOr(filter_insideA, qh.FieldInList("idinc_taxableestim", lista))));
                }
            }
            MyFilter = qh.AppAnd(MyFilter, qh.BitClear("flag", 2));
            //MyFilter += "AND (flagvariation ='N')";

            return MyFilter;
        }


		private void btnCollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (MetaData.Empty(this)) return;
			if (IvaLinked==null){
				MessageBox.Show("E' necessario selezionare prima la fattura");
				return;
			}
			MetaData.GetFormData(this,true);
			CurrCausaleIva= GetCausaleIva();
			string MyFilter = CalculateFilterForInvoiceDetailLinking(true);
			string tablename="";
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				tablename="invoicedetail_taxable";
			}
			if (CurrCausaleIva==2){
				tablename="invoicedetail_iva";
			}
            if (tablename == "") {
                MessageBox.Show("E' necessario selezionare prima una causale", "Avviso");
                return;
            }
            string command = "choose."+tablename+".listaentrata." + MyFilter;
			if (!MetaData.Choose(this,command))return;
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}
			CalcolaImportoInBaseADettagliFattura();
		}


		private void btnModificaDettInvoice_Click(object sender, System.EventArgs e) {
			
			if (Meta.IsEmpty) return;
			if (IvaLinked==null){
				MessageBox.Show("E' necessario selezionare prima la fattura");
				return;
			}
			Meta.GetFormData(true);
			DataTable ToLink=null;
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				ToLink=DS.invoicedetail_taxable;
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable, "incomeinvoicedetail_taxable");
			}
			if (CurrCausaleIva==2){
				ToLink=DS.invoicedetail_iva;
                Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva, "incomeinvoicedetail_iva");
			}
            if (ToLink == null) {
                MessageBox.Show("E' necessario selezionare prima la causale");
                return;
            }
            string MyFilter = CalculateFilterForInvoiceDetailLinking(false);
			string MyFilterSQL = CalculateFilterForInvoiceDetailLinking(true);
			Meta.MultipleLinkUnlinkRows("Selezione dettagli fattura",
				"Dettagli inclusi nel movimento corrente", 
				"Dettagli non inclusi in alcun movimento",
				ToLink, MyFilter, MyFilterSQL, "listaentrata"); 
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}

			CalcolaImportoInBaseADettagliFattura();		 
		}
		
		private void btnScollegaDettInvoice_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (IvaLinked==null){
				MessageBox.Show("E' necessario selezionare prima la fattura");
				return;
			}
			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrDettagliFattura);
			if (CurrCausaleIva==1){
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){					
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}
			CalcolaImportoInBaseADettagliFattura();
		}

		decimal GetImportoDettagliFattura(){
			if (DS.invoice.Rows.Count==0) 
				return 0;
			decimal tassocambio;
			DataRow Fattura= DS.invoice.Rows[0];
			tassocambio= CfgFn.GetNoNullDecimal(Fattura["exchangerate"]);
			if(tassocambio==0) tassocambio=1;
			decimal imponibile=0;
			decimal imposta=0;
			DataRow[] ToConsider=new DataRow[0];
			CurrCausaleIva= GetCausaleIva();
			if (CurrCausaleIva==3){
				ToConsider= DS.invoicedetail_taxable.Select("idinc_taxable is not null");
			}
			if (CurrCausaleIva==2){
				ToConsider= DS.invoicedetail_iva.Select("idinc_iva is not null");
			}
			if (CurrCausaleIva==1){
				ToConsider= DS.invoicedetail_taxable.Select("idinc_taxable is not null");
			}

			foreach (DataRow R in ToConsider){
				if (R.RowState== DataRowState.Deleted) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				//decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
				decimal R_imposta  = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto   = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]),6);
				imponibile +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*tassocambio) ;
				//imposta    +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*R_imposta*tassocambio);
				imposta    +=  CfgFn.RoundValuta(R_imposta*tassocambio);
			}

			decimal totale=0;

			if (CurrCausaleIva==3){
				totale= imponibile;
			}
			if (CurrCausaleIva==2){
				totale= imposta;
			}
			if (CurrCausaleIva==1){
				totale= imponibile+imposta;
			}

			return totale;

		}

		void CalcolaImportoInBaseADettagliFattura(){
			if (Meta.IsEmpty) return;		
			tipocont currcont= ContabilizzazioneSelezionata();
			if (currcont!= tipocont.cont_iva) return;
			CurrCausaleIva= GetCausaleIva();
			decimal totale= GetImportoDettagliFattura();
			SetImporto(totale);
			CalcTotInvoiceDetail();
		}

		void SvuotaDettagliFattura(){
			if (Meta.EditMode)return;
			DS.invoicedetail_taxable.Clear();
			DS.invoicedetail_iva.Clear();
			CalcTotInvoiceDetail();

		}

		void CollegaTuttiDettagliFattura(){
            if (DS.invoice.Rows.Count == 0) return;
			CurrCausaleIva= GetCausaleIva();
			string filter = CalculateFilterForInvoiceDetailLinking(true);
			DS.invoicedetail_iva.Clear();
			DS.invoicedetail_taxable.Clear();
			object idinc=DS.income.Rows[0]["idinc"];
			if (CurrCausaleIva==1){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
				foreach(DataRow R in DS.invoicedetail_taxable.Rows){
					R["idinc_taxable"]=idinc;
					R["idinc_iva"]=idinc;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable,"incomeinvoicedetail_taxable");
			}
			if (CurrCausaleIva==3){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_taxable,null,filter,null,true);
                foreach(DataRow R in DS.invoicedetail_taxable.Rows) {
					R["idinc_taxable"]=idinc;
				}
				GetData.CalculateTable(DS.invoicedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_taxable,"incomeinvoicedetail_taxable");
			}
			if (CurrCausaleIva==2){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetail_iva,null,filter,null,true);
                foreach(DataRow R in DS.invoicedetail_iva.Rows) {
					R["idinc_iva"]=idinc;
				}
				GetData.CalculateTable(DS.invoicedetail_iva);
				Meta.MarkTableAsNotEntityChild(DS.invoicedetail_iva,"incomeinvoicedetail_iva");
			}

            CalcolaImportoInBaseADettagliFattura();
            if ((DS.invoicedetail_iva.Rows.Count == 0) && (DS.invoicedetail_taxable.Rows.Count == 0)){
                MessageBox.Show("Non sono stati trovati dettagli coerenti con UPB e Causale selezionati.");
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



		void SetEditComboCausaleIva(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
			EnableTipoMovimento(2,"Contabilizzazione iva documento");
			//cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
			object currtipo = DS.Tables["incomeinvoice"].Rows[0]["movkind"];
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);

		}
		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleIva(DataRow Iva){
			if (!faseIvaInclusa()) return;
            string MyFilter_taxable = "";
            string MyFilter_iva = "";
			DataAccess Conn= Meta.Conn;
			object parid=DBNull.Value;
			if (Meta.InsertMode){
				DataRow Curr=DS.income.Rows[0];
				parid=Curr["parentidinc"].ToString();
			}
			bool EnableImpon=true;
			bool EnableImpos=true;
			bool EnableDocum=true;
			DataRow R=Iva;
			totimponibile_dociva=CfgFn.GetNoNullDecimal( R["taxabletotal"]);
			totiva_dociva=CfgFn.GetNoNullDecimal( R["ivatotal"]);
            MyFilter_taxable = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idinc_taxableestim"]));
            MyFilter_iva = QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("idparent", R["idinc_ivaestim"]));

            EnableImpon = (R["idinc_taxableestim"] == DBNull.Value ||
                (parid != DBNull.Value && Conn.RUN_SELECT_COUNT("incomelink", MyFilter_taxable, false) > 0) ||
                    R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]));

            EnableImpos = (R["idinc_ivaestim"] == DBNull.Value ||
                (parid != DBNull.Value && Conn.RUN_SELECT_COUNT("incomelink", MyFilter_iva, false) > 0) ||
                        R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]));

            EnableDocum = R["idinc_ivaestim"].Equals(R["idinc_taxableestim"]);

			assigned_imponibile_dociva= CfgFn.GetNoNullDecimal( R["linkedimpon"]);
			assigned_iva_dociva= CfgFn.GetNoNullDecimal( R["linkedimpos"]);
			assigned_gen_dociva=CfgFn.GetNoNullDecimal( R["linkeddocum"]);
            //bool intracom = false; //Per i C.A. e Fatture intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524

            string filteriva = QHS.AppAnd(QHS.CmpEq("idinvkind", Iva["idinvkind"]),
                QHS.CmpEq("yinv", Iva["yinv"]), QHS.CmpEq("ninv", Iva["ninv"]));
            string filter_idupbivaset = QHS.AppAnd(filteriva, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("invoicedetail", filter_idupbivaset, false);

            decimal all_assigned_imponibile_dociva = 0;
            decimal all_assigned_iva_dociva = 0;
            decimal all_assigned_gen_dociva = 0;
            DataTable T = Conn.RUN_SELECT("invoiceresidual", "*", null, filteriva, null, true);
            if ((T != null) && (T.Rows.Count > 0))
            {
                foreach (DataRow Dett in T.Rows)
                {
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
            if (n_idupbivaset > 0){
                EnableDocum = false;
            }
			ClearComboCausale();
			DataTable TCombo= DS.tipomovimento;

			if ((Meta.EditMode) || 
				(EnableDocum &&
                (all_assigned_imponibile_dociva + all_assigned_iva_dociva) == 0) && 
				(assigned_gen_dociva< (totimponibile_dociva+totiva_dociva))
				){
				EnableTipoMovimento(1,"Contabilizzazione importo totale documento");
			}

			if ((Meta.EditMode) ||
                (EnableImpon && (all_assigned_gen_dociva == 0) && (assigned_imponibile_dociva < totimponibile_dociva))
				){
				EnableTipoMovimento(3,"Contabilizzazione imponibile documento");
			}

			if ((Meta.EditMode) ||
                (EnableImpos && (all_assigned_gen_dociva == 0) && (assigned_iva_dociva < totiva_dociva))
				){
				EnableTipoMovimento(2,"Contabilizzazione iva documento");
			}

            DS.incomeinvoice.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                    ? cmbCausale.SelectedValue : DBNull.Value;
			cmbCausale.Enabled=!(Meta.EditMode);
			ReCalcImporto_Iva();
			
		}

		void AbilitaDisabilitaControlliFattura(bool abilita){
			bool abilitagrid= abilita && faseIvaInclusa();
			btnAddDettInvoice.Enabled= abilitagrid;
			btnRemoveDettInvoice.Enabled=abilitagrid;
			btnEditInvDet.Enabled= abilitagrid;
			gboxDettInvoice.Visible= abilitagrid;
			CurrCausaleIva= GetCausaleIva();
			if (CurrCausaleIva==1||CurrCausaleIva==3){
				dgrDettagliFattura.Tag="invoicedetail_taxable.listaimpon";
				dgrDettagliFattura.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliFattura,DS.invoicedetail_taxable);
				if (Meta.EditMode) DS.invoicedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
			}
			if (CurrCausaleIva==2){
				dgrDettagliFattura.TableStyles.Clear();
				dgrDettagliFattura.Tag="invoicedetail_iva.listaimpos";
				HelpForm.SetDataGrid(dgrDettagliFattura,DS.invoicedetail_iva);
			}


		}

		void ReCalcImporto_Iva(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.Tables["income"].Rows[0];
			if ((faseinizio>1)&&(Curr["parentidinc"]==DBNull.Value)) return;
			if (cmbCausale.SelectedValue==null) return;

            //string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=GetImportoDettagliFattura();
			/*if (tipomovimento==2){
				importo= totiva_dociva-assigned_iva_dociva;
			}
			if (tipomovimento==3){
				importo= totimponibile_dociva-assigned_imponibile_dociva;
			}
			if (tipomovimento==1){
				importo= totimponibile_dociva+totiva_dociva-assigned_gen_dociva;
			}*/

			if ((faseinizio>1)&& (importo> DisponibileDaFasePrecedente)) {
				MessageBox.Show("Sarà effettuata una contabilizzazione di importo inferiore poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
				importo=DisponibileDaFasePrecedente;				
			}

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;
	
			SetImporto(importo);
			SubEntity_txtImportoMovimento.Text= importo.ToString("c");

		}

		private void cmbCausaleIva_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleIva();
			SvuotaDettagliFattura();
			CollegaTuttiDettagliFattura();
			ReCalcImporto_Iva();
            if (CurrCausaleIva == 1 || CurrCausaleIva == 3){
                dgrDettagliFattura.Tag = "invoicedetail_taxable.listaimpon";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_taxable);
            }
            if (CurrCausaleIva == 2){
                dgrDettagliFattura.Tag = "invoicedetail_iva.listaimpos";
                HelpForm.SetDataGrid(dgrDettagliFattura, DS.invoicedetail_iva);
            }
		}

		int GetCausaleIva(){
			CurrCausaleIva=0;
			//if (!Meta.InsertMode) return "";
			if (DS.incomeinvoice.Rows.Count==0) return 0;
			if (!Meta.DrawStateIsDone){
				if (DS.incomeinvoice.Rows[0]["movkind"]!=DBNull.Value)
					CurrCausaleIva=CfgFn.GetNoNullInt32( DS.incomeinvoice.Rows[0]["movkind"]);
				else
					CurrCausaleIva=0;
				return CurrCausaleIva;
			}
			if (cmbCausale.SelectedValue!=null)
				DS.incomeinvoice.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.incomeinvoice.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleIva= CfgFn.GetNoNullInt32( DS.incomeinvoice.Rows[0]["movkind"]);
			return CurrCausaleIva;
			//ReCalcImporto();
		}


		void UpdateComboCausaleIva(){
			if (IvaMovEntrataLinked!=null){
				object currtipo = IvaMovEntrataLinked["movkind"];
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}


		bool TipoDocChangePilotato=false;
		private void cmbTipoDocumento_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			ClearControlliIva(true);
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			TipoDocChangePilotato=false;
		}

		#endregion

		
		#region Gestione Selezione Contratto Attivo

		string FilterEstimate;

		private void txtEsercEstimate_Leave(object sender, System.EventArgs e) {
			if (InChiusura)return;
			if (txtEsercDoc.ReadOnly)return;
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercDoc);		
			//CalcolaStartFilter(null);
		}

		string GetFilterEstimate(bool FiltraNum){
			int esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
			FilterEstimate="(yestim<='"+esercizio.ToString()+"')";
			if(txtEsercDoc.Text != ""){
				int esercdocumento= CfgFn.GetNoNullInt32(txtEsercDoc.Text);
				try {
					if (esercdocumento <= esercizio) 
						FilterEstimate="(yestim='"+esercdocumento.ToString()+"')";
					else 
						FilterEstimate = GetData.MergeFilters(FilterIva,
							"(yestim='"+esercdocumento.ToString()+"')");
				}
				catch {
				}
			} 
			if (FiltraNum){
				int numdocumento= CfgFn.GetNoNullInt32(txtNumDoc.Text);
				if(txtNumDoc.Text != ""){
					FilterEstimate = GetData.MergeFilters(FilterEstimate,
						"(nestim='"+numdocumento.ToString()+"')");
				} 
			}
			string filtertipodoc;
			if (cmbTipoDocumento.SelectedIndex<=0){
				filtertipodoc= "";
			}
			else {
				filtertipodoc = "(idestimkind="+
					QueryCreator.quotedstrvalue(cmbTipoDocumento.SelectedValue,true)+")";
			}
			FilterEstimate = GetData.MergeFilters(FilterEstimate, filtertipodoc);

			if (Meta.InsertMode){
				FilterEstimate+="AND(residual>'0')AND((active is null)OR(active='S'))";
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
			if (((Control)sender).Name == "txtNumDoc")
				MyEstimateFilter = GetFilterEstimate(true);
			else
				MyEstimateFilter = GetFilterEstimate(false);

			MyFilterEstimate= MyEstimateFilter;
			MyFilterEstimateOperativo= MyEstimateFilter;

			if (Meta.InsertMode){
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred<faseinizio);
				DataRow Curr = DS.income.Rows[0];
				bool faseprecselected = (Curr["parentidinc"]!=DBNull.Value);
				if ((condfasecred && faseprecselected) ||
					((txtCredDeb.ReadOnly==false) && (txtCredDeb.Text.Trim()!=""))
					){
					MyFilterEstimate = GetData.MergeFilters(MyFilterEstimate,
						"(idreg="+
						QueryCreator.quotedstrvalue(Curr["idreg"],true)+")");
					MyFilterEstimateOperativo= GetData.MergeFilters(MyFilterEstimateOperativo,
						"(registry="+
						QueryCreator.quotedstrvalue(txtCredDeb.Text,true)+")");
				}
				bool condfaseupb= (ManageUPB.faseattivazione< faseinizio);
                object getupb = GetUpb();
				if ( (condfaseupb && faseprecselected)||
					(getupb!=DBNull.Value && txtUPB.Enabled) ){
					object idupb= getupb;
                    MyFilterEstimateOperativo = QHS.AppAnd(MyFilterEstimateOperativo, QHS.DoPar(QHS.AppOr(QHS.IsNull("idupb"), QHS.CmpEq("idupb", idupb), QHS.CmpEq("idupb_iva", idupb))));
				}
				if (faseentratamax == 1) {
					MyFilterEstimateOperativo =
						QHS.AppAnd(MyFilterEstimateOperativo, QHS.CmpEq("linktoinvoice", "N"));
				}
			}
			if (Meta.IsEmpty){
				int fasecred = ManageCreditore.faseattivazione;
				bool condfasecred = (fasecred<faseinizio);
				bool faseprecselected = (txtCredDeb.Text.Trim()!="");
				if (condfasecred && faseprecselected){
					MyFilterEstimateOperativo= GetData.MergeFilters(MyFilterEstimateOperativo,
						"(registry="+
						QueryCreator.quotedstrvalue(txtCredDeb.Text,true)+")");
				}
			}

			MetaData MEstimate;
			DataRow MyDREstimate;

			if (Meta.IsEmpty) {
				MEstimate = MetaData.GetMetaData(this,"estimatelinked");
				MEstimate.FilterLocked=true;			
				MEstimate.DS = new DataSet();//DS.Clone();
				MyDREstimate = MEstimate.SelectOne("default",MyFilterEstimate,null,null);
				if (MyDREstimate==null) {
					if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
						if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
						return;
					}
					return;
				}
				TipoDocChangePilotato=true;				
				HelpForm.SetComboBoxValue(cmbTipoDocumento,MyDREstimate["idestimkind"]);
				TipoDocChangePilotato=false;
				txtEsercDoc.Text= MyDREstimate["yestim"].ToString();
				txtNumDoc.Text= MyDREstimate["nestim"].ToString();
				return;
			}

			MEstimate = MetaData.GetMetaData(this,"estimateresidual");
			MEstimate.FilterLocked=true;
			MEstimate.DS = DS.Clone();
			
			MyDREstimate = MEstimate.SelectOne("default",MyFilterEstimateOperativo,null,null);
			
			if(MyDREstimate == null) {
				if (typeof(TextBox).IsAssignableFrom(sender.GetType())){
					if (((TextBox)sender).Text.Trim()!="")	((TextBox)sender).Focus();
				}
				return;
			}
			string selectord = QHS.MCmp(MyDREstimate, "idestimkind", "yestim", "nestim");


			string columnlist = QueryCreator.ColumnNameList(DS.estimate)+
				",registry";
			DataTable Temp = Meta.Conn.RUN_SELECT("estimateview",columnlist,null,selectord,null,null,true);
			
			if (Temp.Rows.Count==0) return;

			DataRow MyDR = Temp.Rows[0];

		
			//Inserisco nella riga attuale il valore idspesa nel campo livsupidspesa
			//al fine di consentire il calcolo automatico del nuovo idspesa.
			//Poi eredito tutti i campi dell'eventuale movimento padre.
			if(Meta.InsertMode) {
				CollegaContratto(MyDR,MyDREstimate);
				CollegaTuttiDettagliContratto();
				RintracciaEstimate();
				ResetTipoClassAvailableEvalued();
			}
			AbilitaDisabilitaControlliContratto(true);
		}




		private void txtNumEstimate_Leave(object sender, System.EventArgs e) {
			if (InChiusura) return;
			if (txtNumDoc.ReadOnly)return;
			if (Meta.EditMode) return;
			//if (!Meta.InsertMode) return;
			//CalcolaStartFilter(null);


			if (txtNumDoc.Text.Trim()==""){
				if (Meta.InsertMode) ScollegaIva();				
				ClearControlliEstimate(true);
				int fasecred = ManageCreditore.faseattivazione;
				if (fasecred<faseinizio) return;
				txtCredDeb.Text="";
				return;
			}


			btnEstimate_Click(sender,e);
		}

		void ClearControlliEstimate(bool skipTipoDoc){
			//txtCredDeb.Text = "";		
			txtDescrizione.Text= "";
			txtDocumento.Text= "";
			txtDataDocumento.Text = "";
            SetResponsabile(DBNull.Value);
			if (!skipTipoDoc) cmbTipoDocumento.SelectedIndex=-1;
			AbilitaDisabilitaCreditoreDebitore(true);
		}

		/*void AbilitaDisabilitaControlliEstimate(bool abilita){
			AbilitaDisabilitaCreditoreDebitore(abilita);
			//txtCredDeb.ReadOnly=!abilita;
		}*/

		void VisualizzaMainInfo_Estimate(DataRow Estimate2){
			if (!faseContrattoInclusa())return;
			gboxDettEstimate.Visible=true;
			cmbTipoDocumento.Tag=
				"incomeestimate.idestimkind?"+
				"incomeestimateview.idestimkind";
			ImpostaComboEstimateKind();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,
				Estimate2["idestimkind"]);
			TipoDocChangePilotato=false;
			txtNumDoc.Text= Estimate2["nestim"].ToString();
			txtEsercDoc.Text = Estimate2["yestim"].ToString();
		}

		/// <summary>
		/// Collega la riga al movimento e aggiorna il form.
		/// </summary>
		/// <param name="Ordine"></param>
			void CollegaContratto(DataRow Estimate2, DataRow EstimateResiduo){

			if (Meta.IsEmpty) return;

			if (!faseContrattoInclusa()) return;
			tipocont mycont=ContabilizzazioneSelezionata();
			if (mycont!=tipocont.cont_estimate &&	mycont != tipocont.cont_none) return; //Non collega ordini se non in questi casi
			
			Hashtable ValoriEstimate = new Hashtable();
			foreach (DataColumn C in Estimate2.Table.Columns) 
				ValoriEstimate[C.ColumnName]= Estimate2[C.ColumnName];
			
			ScollegaEstimate();

			gboxDettEstimate.Visible=true;

			DataRow NewEstimateR = DS.estimate.NewRow();

			foreach (DataColumn C in DS.estimate.Columns){
				NewEstimateR[C.ColumnName]= ValoriEstimate[C.ColumnName];
			}

			DS.estimate.Rows.Add(NewEstimateR);
			NewEstimateR.AcceptChanges();

			DataRow CurrRow= DS.income.Rows[0];
			DataRow CurrImpRow= DS.incomeyear.Rows[0];
			MetaData MovEstimate = MetaData.GetMetaData(this,"incomeestimate");
			MovEstimate.SetDefaults(DS.incomeestimate);
			DS.incomeestimate.Columns["idestimkind"].DefaultValue=ValoriEstimate["idestimkind"];
			DS.incomeestimate.Columns["nestim"].DefaultValue= ValoriEstimate["nestim"];
			DS.incomeestimate.Columns["yestim"].DefaultValue= ValoriEstimate["yestim"];
			txtNumDoc.Text=ValoriEstimate["nestim"].ToString();
			txtEsercDoc.Text=ValoriEstimate["yestim"].ToString();
			TipoDocChangePilotato=true;
			HelpForm.SetComboBoxValue(cmbTipoDocumento,ValoriEstimate["idestimkind"]);
			TipoDocChangePilotato=false;

			DataRow RMovEstimate = MovEstimate.Get_New_Row(CurrRow, DS.incomeestimate);
			DS.incomeestimate.Columns["idestimkind"].DefaultValue = DBNull.Value;
			DS.incomeestimate.Columns["nestim"].DefaultValue= DBNull.Value;
			DS.incomeestimate.Columns["yestim"].DefaultValue= DBNull.Value;

			CurrRow["idreg"] = EstimateResiduo["idreg"];
			
			CurrRow["description"] = ValoriEstimate["description"];
			txtDescrizione.Text= ValoriEstimate["description"].ToString();

			//			CurrRow["documento"] = "Doc."+
			//				ValoriDocumentoIva["esercdocumento"].ToString().Substring(2,2)+"/"+
			//				ValoriDocumentoIva["numdocumento"].ToString().PadLeft(6,'0');
			//			//"Ord."+ValoriOrdine["documento"];
			//			txtDocumento.Text = CurrRow["documento"].ToString();
			//			CurrRow["datadocumento"] = ValoriDocumentoIva["datacontabile"];
			//			txtDataDocumento.Text=   HelpForm.StringValue( ValoriDocumentoIva["datacontabile"], txtDataDocumento.Tag.ToString());

			CurrRow["doc"] = "C.A." +          ValoriEstimate["idestimkind"].ToString() + "/" +
                                               ValoriEstimate["yestim"].ToString().Substring(2, 2) + "/" +
                                               ValoriEstimate["nestim"].ToString().PadLeft(6, '0');
            //"Doc."+ValoriEstimate["doc"];
            txtDocumento.Text = CurrRow["doc"].ToString();
			CurrRow["docdate"] = ValoriEstimate["docdate"];
			txtDataDocumento.Text=   HelpForm.StringValue( ValoriEstimate["docdate"], txtDataDocumento.Tag.ToString());

			//CurrRow["codiceresponsabile"] = ValoriDocumentoIva["codiceresponsabile"];
			//HelpForm.SetComboBoxValue(cmbResponsabile, 	ValoriDocumentoIva["codiceresponsabile"].ToString());

			if (DS.registry.Rows.Count>0){
				DataRow Cred = DS.registry.Rows[0];
				if (Cred["idreg"].ToString() != CurrRow["idreg"].ToString()){
					DS.registry.Clear();
					//DS.modpagamentocreddebi.Clear();
				}
			}

			if (DS.registry.Rows.Count==0){
				LeggiDatiSuCredDeb(CurrRow["idreg"]);
				//CalcolaValoriDefaultModPagamento(CurrRow["codicecreddeb"].ToString());
			}
			if (DS.registry.Rows.Count>0){
				DataRow CredDeb= DS.registry.Rows[0];
				//SetComboCreditoreDebitore(CredDeb);
				txtCredDeb.Text= CredDeb["title"].ToString();
			}
            if (EstimateResiduo["idupb"] != DBNull.Value && EstimateResiduo["idupb_iva"] == DBNull.Value) {
                SetUPB(EstimateResiduo["idupb"]);
            }
            else {
             CurrImpRow["idupb"] = GetUpb();
            } 

			//Meta.myHelpForm.FillControls(tabMovFin.Controls);
			EstimateLinkedMustBeEvalued=true;
			RintracciaEstimate();
			SetComboCausaleEstimate(EstimateResiduo);
			AbilitaDisabilitaCreditoreDebitore(false);

		}

		void ScollegaEstimate(){
			gboxDettEstimate.Visible=false;
			if (DS.incomeestimate.Rows.Count==0) return;
			DS.incomeestimate.Clear();
			DS.estimatedetail_taxable.Clear();
			DS.estimatedetail_iva.Clear();
			DS.estimate.Clear();
			ClearComboCausale();
			DataRow CurrRow= DS.income.Rows[0];
			DataRow CurrImpRow= DS.incomeyear.Rows[0];
			int fasecreditore= ManageCreditore.faseattivazione;
			if (fasecreditore>=faseinizio){
				CurrRow["idreg"] = DBNull.Value;
				txtCredDeb.Text = "";		
				DS.registry.Clear();
			}
			if (fasecreditore<faseinizio && txtNumeroFasePrecedente.Text==""){
				CurrRow["idreg"]=DBNull.Value;
				txtCredDeb.Text="";
				DS.registry.Clear();
			}

			int faseupb = ManageUPB.faseattivazione;
			if (faseupb<faseinizio && txtNumeroFasePrecedente.Text==""){
                SetUPB(DBNull.Value);
			}
			CurrRow["doc"] = DBNull.Value;
			CurrRow["docdate"] = DBNull.Value;
			//CurrRow["codiceresponsabile"]=DBNull.Value;
			CurrRow["description"]="";
			ClearControlliEstimate(false);
		}

		#endregion
		
		#region Eventi Dettagli Contratto

		string CalculateFilterForEstimateDetailLinking(bool SQL){
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";
			
			string idreg = DS.income.Rows[0]["idreg"].ToString();
			string idupb = DS.incomeyear.Rows[0]["idupb"].ToString();

            //MyFilter = "(idestimkind="+
            //    QueryCreator.quotedstrvalue(EstimateLinked["idestimkind"],SQL)+")AND"+
            //    "(yestim="+
            //    QueryCreator.quotedstrvalue(EstimateLinked["yestim"],SQL)+")AND"+
            //    "(nestim="+
            //    QueryCreator.quotedstrvalue(EstimateLinked["nestim"],SQL)+")"; 
            MyFilter = qh.AppAnd(MyFilter, qh.MCmp(EstimateLinked, "idestimkind", "yestim", "nestim"));

            //DataRow TipoContratto=DS.estimatekind.Select("(idestimkind="+
            //    QueryCreator.quotedstrvalue(EstimateLinked["idestimkind"],SQL)+")")[0];
            DataRow TipoContratto = DS.estimatekind.Select(qh.CmpEq("idestimkind", EstimateLinked["idestimkind"]))[0];

			if (TipoContratto["multireg"].ToString().ToUpper()=="S"){
				if (idreg!="")
                    //MyFilter+="AND(idreg='" + idreg + "')";
                    MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", idreg));
			}

			if (idupb!=""){
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

			if (CurrCausaleEstimate==1){
                //MyFilter+="AND (idinc_iva is null and idinc_taxable is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"), qh.IsNull("idinc_taxable"));
			}
			if (CurrCausaleEstimate==2){
                //MyFilter+="AND (idinc_iva is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_iva"));
			}
			if (CurrCausaleEstimate==3){
                //MyFilter+="AND (idinc_taxable is null)";
                MyFilter = qh.AppAnd(MyFilter, qh.IsNull("idinc_taxable"));
			}
            //MyFilter+="AND(stop is null)";
            //MyFilter = qh.AppAnd(MyFilter, qh.IsNull("stop"));
            int currEsercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterstart = qh.NullOrLe("start", new DateTime(currEsercizio, 12, 31));
            string filterstop = qh.NullOrGt("stop", new DateTime(currEsercizio, 12, 31));
            MyFilter = qh.AppAnd(MyFilter, filterstart, filterstop);

			return MyFilter;
		}


		private void btnCollegaDettContratto_Click(object sender, System.EventArgs e) {
			if (DS.config.Rows.Count==0) return;

			if (MetaData.Empty(this)) return;
			if (EstimateLinked==null){
				MessageBox.Show("E' necessario selezionare prima il contratto attivo");
				return;
			}
			MetaData.GetFormData(this,true);
			CurrCausaleEstimate= GetCausaleEstimate();
			string MyFilter = CalculateFilterForEstimateDetailLinking(true);
			string tablename="";
			if (CurrCausaleEstimate==1||CurrCausaleEstimate==3){
				tablename="estimatedetail_taxable";
			}
			if (CurrCausaleEstimate==2){
				tablename="estimatedetail_iva";
			}
            if (tablename == "") {
                MessageBox.Show("E' necessario selezionare prima una causale", "Avviso");
                return;
            }
            string command = "choose."+tablename+".listaentrata." + MyFilter;
			if (!MetaData.Choose(this,command))return;
			if (CurrCausaleEstimate==1){
				foreach(DataRow R in DS.estimatedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				}
			}
			CalcolaImportoInBaseADettagliContratto();
		}


		private void btnModificaDettContratto_Click(object sender, System.EventArgs e) {
			
			if (Meta.IsEmpty) return;
			if (EstimateLinked==null){
				MessageBox.Show("E' necessario selezionare prima il contratto attivo");
				return;
			}
			Meta.GetFormData(true);
			DataTable ToLink=null;
			if (CurrCausaleEstimate==1||CurrCausaleEstimate==3){
				ToLink=DS.estimatedetail_taxable;
                Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable, "incomeestimatedetail_taxable");
			}
			if (CurrCausaleEstimate==2){
				ToLink=DS.estimatedetail_iva;
                Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva, "incomeestimatedetail_iva");
			}
            if (ToLink == null) {
                MessageBox.Show("E' necessario selezionare prima la causale");
                return;
            }
            string MyFilter = CalculateFilterForEstimateDetailLinking(false);
			string MyFilterSQL = CalculateFilterForEstimateDetailLinking(true);
			Meta.MultipleLinkUnlinkRows("Selezione dettagli contratto",
				"Dettagli inclusi nel movimento corrente", 
				"Dettagli non inclusi in alcun movimento",
				ToLink, MyFilter, MyFilterSQL, "listaentrata"); 
			if (CurrCausaleEstimate==1){
				foreach(DataRow R in DS.estimatedetail_taxable.Rows){
					R["idinc_iva"]=R["idinc_taxable"];
				};
			}

			CalcolaImportoInBaseADettagliContratto();		 
		}
		
		private void btnScollegaDettContratto_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			if (EstimateLinked==null){
				MessageBox.Show("E' necessario selezionare prima il contratto attivo");
				return;
			}
			Meta.GetFormData(true);
			MetaData.Unlink_Grid(dgrDettagliContratto);
			if (CurrCausaleEstimate==1){
				foreach(DataRow R in DS.estimatedetail_taxable.Rows){					
					R["idinc_iva"]=R["idinc_taxable"];
				}
			}
			CalcolaImportoInBaseADettagliContratto();
		}

		decimal GetImportoDettagliContratto(){
			if (DS.estimate.Rows.Count==0) 
				return 0;
			decimal tassocambio;
			DataRow Contratto= DS.estimate.Rows[0];
			tassocambio= CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
			if(tassocambio==0) tassocambio=1;
			decimal imponibile=0;
			decimal imposta=0;
			DataRow[] ToConsider=new DataRow[0];
			CurrCausaleEstimate= GetCausaleEstimate();
			if (CurrCausaleEstimate==3){
				ToConsider= DS.estimatedetail_taxable.Select("idinc_taxable is not null");
			}
			if (CurrCausaleEstimate==2){
				ToConsider= DS.estimatedetail_iva.Select("idinc_iva is not null");
			}
			if (CurrCausaleEstimate==1){
				ToConsider= DS.estimatedetail_taxable.Select("idinc_taxable is not null");
			}

			foreach (DataRow R in ToConsider){
				if (R.RowState== DataRowState.Deleted) continue;
				if (R["stop"]!=DBNull.Value) continue;
				decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
				decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
				//decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
				decimal R_imposta  = CfgFn.GetNoNullDecimal(R["tax"]);
				decimal R_sconto   = CfgFn.Round(CfgFn.GetNoNullDecimal(R["discount"]),6);
				imponibile +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*tassocambio) ;
				//imposta    +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*R_imposta*tassocambio);
				imposta    +=  CfgFn.RoundValuta(R_imposta*tassocambio);
			}

			decimal totale=0;

			if (CurrCausaleEstimate==3){
				totale= imponibile;
			}
			if (CurrCausaleEstimate==2){
				totale= imposta;
			}
			if (CurrCausaleEstimate==1){
				totale= imponibile+imposta;
			}

			return totale;

		}

		void CalcolaImportoInBaseADettagliContratto(){
			if (Meta.IsEmpty) return;		
			tipocont currcont= ContabilizzazioneSelezionata();
			if (currcont!= tipocont.cont_estimate) return;
			CurrCausaleEstimate= GetCausaleEstimate();
			decimal totale= GetImportoDettagliContratto();
			SetImporto(totale);
			CalcTotEstimateDetail();
		}

		void SvuotaDettagliContratto(){
			if (Meta.EditMode)return;
			DS.estimatedetail_taxable.Clear();
			DS.estimatedetail_iva.Clear();
			CalcTotEstimateDetail();

		}
		void CollegaTuttiDettagliContratto(){
            if (DS.estimate.Rows.Count == 0) return;
			CurrCausaleEstimate= GetCausaleEstimate();
			string filter = CalculateFilterForEstimateDetailLinking(true);
			DS.estimatedetail_iva.Clear();
			DS.estimatedetail_taxable.Clear();
			string idinc=DS.income.Rows[0]["idinc"].ToString();
			if (CurrCausaleEstimate==1){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_taxable,null,filter,null,true);
                foreach(DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_taxable"]=idinc;
					R["idinc_iva"]=idinc;
				}
				GetData.CalculateTable(DS.estimatedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable,"incomeestimatedetail_taxable");
			}
			if (CurrCausaleEstimate==3){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_taxable,null,filter,null,true);
                foreach(DataRow R in DS.estimatedetail_taxable.Rows) {
					R["idinc_taxable"]=idinc;
				}
				GetData.CalculateTable(DS.estimatedetail_taxable);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_taxable,"incomeestimatedetail_taxable");
			}
			if (CurrCausaleEstimate==2){
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.estimatedetail_iva,null,filter,null,true);
                foreach(DataRow R in DS.estimatedetail_iva.Rows) {
					R["idinc_iva"]=idinc;
				}
				GetData.CalculateTable(DS.estimatedetail_iva);
				Meta.MarkTableAsNotEntityChild(DS.estimatedetail_iva,"incomeestimatedetail_iva");
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

		void SetEditComboCausaleEstimate(){
			if (!Meta.EditMode)return;
			ClearComboCausale();
			EnableTipoMovimento(1,"Contabilizzazione importo totale contratto");
			EnableTipoMovimento(3,"Contabilizzazione imponibile contratto");
			EnableTipoMovimento(2,"Contabilizzazione iva contratto");
			//cmbCausale.SelectedValue= DS.Tables["ordinegenericomovspesa"].Rows[0]["tipomovimento"].ToString();
			object currtipo = DS.Tables["incomeestimate"].Rows[0]["movkind"];
			HelpForm.SetComboBoxValue(cmbCausale, currtipo);
		}

		/// <summary>
		/// Riempie il combobox causale con i valori ammessi, senza impostarvi alcun valore
		/// </summary>
		/// <param name="Ordine"></param>
		void SetComboCausaleEstimate(DataRow Estimate){
			if (!faseContrattoInclusa()) return;
			DataAccess Conn= Meta.Conn;
			totimponibile_estimate=CfgFn.GetNoNullDecimal(Estimate["taxabletotal"]);
			totiva_estimate=CfgFn.GetNoNullDecimal(Estimate["ivatotal"]);
			assigned_imponibile_estimate= CfgFn.GetNoNullDecimal(Estimate["linkedimpon"]);
			assigned_iva_estimate= CfgFn.GetNoNullDecimal(Estimate["linkedimpos"]);
			assigned_gen_estimate=CfgFn.GetNoNullDecimal(Estimate["linkedestim"]);
			
            string filterestim = QHS.AppAnd(QHS.CmpEq("idestimkind", Estimate["idestimkind"]),
            QHS.CmpEq("yestim", Estimate["yestim"]), QHS.CmpEq("nestim", Estimate["nestim"]));

            decimal all_assigned_imponibile = 0;
            decimal all_assigned_iva = 0;
            decimal all_assigned_gen = 0;
            //bool intracom = false;// Per i C.A. intracom., l'università incassa anche l'iva, per cui deve essere possibile contabilizzarla.Vedi 8524
            DataTable T = Conn.RUN_SELECT("estimateresidual", "*", null, filterestim, null, true);
            if ((T != null) && (T.Rows.Count > 0))
            {
                foreach (DataRow Dett in T.Rows)
                {
                    all_assigned_imponibile += CfgFn.GetNoNullDecimal(Dett["linkedimpon"]);
                    all_assigned_iva += CfgFn.GetNoNullDecimal(Dett["linkedimpos"]);
                    all_assigned_gen += CfgFn.GetNoNullDecimal(Dett["linkedestim"]);
                   // if (Dett["flagintracom"].ToString().ToUpper() != "N") intracom = true;
                }
            }

            string filter_idupbivaset = QHS.AppAnd(filterestim, QHS.IsNotNull("idupb_iva"));
            int n_idupbivaset = Conn.RUN_SELECT_COUNT("estimatedetail", filter_idupbivaset, false);

            ClearComboCausale();
            DataTable TCombo = DS.tipomovimento;

			if ((Meta.EditMode) ||
                ((all_assigned_imponibile + all_assigned_iva) == 0) &&
                (assigned_gen_estimate < (totimponibile_estimate + totiva_estimate)/* && !(intracom)*/) && (n_idupbivaset == 0)
				){
				EnableTipoMovimento(1,"Contabilizzazione importo totale contratto");
			}

			if ((Meta.EditMode) ||
                ((all_assigned_gen == 0) && (assigned_imponibile_estimate < totimponibile_estimate))
				){
				EnableTipoMovimento(3,"Contabilizzazione imponibile contratto");
			}

			if ( (Meta.EditMode) ||
                ((all_assigned_gen == 0) && (assigned_iva_estimate < totiva_estimate) /*&& !(intracom)*/)
				){
				EnableTipoMovimento(2,"Contabilizzazione iva contratto");
			}

            DS.incomeestimate.Rows[0]["movkind"] = (cmbCausale.SelectedValue != null)
                    ? cmbCausale.SelectedValue : DBNull.Value;
			cmbCausale.Enabled=!(Meta.EditMode);
			ReCalcImporto_Estimate();
			
		}

		void AbilitaDisabilitaControlliContratto(bool abilita){
			bool abilitagrid= abilita && faseContrattoInclusa();
			btnAddDetEstimate.Enabled= abilitagrid;
			btnRemoveDetEstimate.Enabled=abilitagrid;
			btnEditEstimDet.Enabled= abilitagrid;
			gboxDettEstimate.Visible= abilitagrid;
			CurrCausaleEstimate=GetCausaleEstimate();
			if (CurrCausaleEstimate==1||CurrCausaleEstimate==3){
				dgrDettagliContratto.Tag="estimatedetail_taxable.listaimpon";
				//dgrDettagliContratto.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliContratto,DS.estimatedetail_taxable);
				if (Meta.EditMode) DS.estimatedetail_iva.Clear(); //Importante per evitare problemi in fase di delete
			}
			if (CurrCausaleEstimate==2){
				dgrDettagliContratto.Tag="estimatedetail_iva.listaimpos";
				//dgrDettagliContratto.TableStyles.Clear();
				HelpForm.SetDataGrid(dgrDettagliContratto,DS.estimatedetail_iva);
			}
		}

		void ReCalcImporto_Estimate(){
			if (Meta.IsEmpty) return;
			DataRow Curr = DS.Tables["income"].Rows[0];
			if ((faseinizio>1)&&(Curr["parentidinc"]==DBNull.Value)) return;
			if (cmbCausale.SelectedValue==null) return;

			string tipomovimento = cmbCausale.SelectedValue.ToString();

			decimal importo=GetImportoDettagliContratto();
			/*if (tipomovimento==2){
				importo= totiva_estimate-assigned_iva_estimate;
			}
			if (tipomovimento==3){
				importo= totimponibile_estimate-assigned_imponibile_estimate;
			}
			if (tipomovimento==1){
				importo= totimponibile_estimate+totiva_estimate-assigned_gen_estimate;
			}*/

			if ((faseinizio>1)&& (importo> DisponibileDaFasePrecedente)) {
				MessageBox.Show("Sarà effettuata una contabilizzazione di importo inferiore poiché la "+
					"disponibilità del movimento selezionato è inferiore a "+importo.ToString());
				importo=DisponibileDaFasePrecedente;				
			}

			//if ((currphase>1)&& (importo> DisponibileDaFasePrecedente)) importo=DisponibileDaFasePrecedente;
	
			SetImporto(importo);
			SubEntity_txtImportoMovimento.Text= importo.ToString("c");

		}

		private void cmbCausaleEstimate_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.InsertMode) return;
			GetCausaleEstimate();
			SvuotaDettagliContratto();
			CollegaTuttiDettagliContratto();
			ReCalcImporto_Estimate();
		}

		int GetCausaleEstimate(){
			CurrCausaleEstimate= 0;
			//if (!Meta.InsertMode) return "";
			if (DS.incomeestimate.Rows.Count==0) return 0;
			if (!Meta.DrawStateIsDone){
				if (DS.incomeestimate.Rows[0]["movkind"]!=DBNull.Value)
					CurrCausaleEstimate=CfgFn.GetNoNullInt32( DS.incomeestimate.Rows[0]["movkind"]);
				else
					CurrCausaleEstimate= 0;
				return CurrCausaleEstimate;
			}
			if (cmbCausale.SelectedValue!=null)
				DS.incomeestimate.Rows[0]["movkind"]= cmbCausale.SelectedValue;
			else
				DS.incomeestimate.Rows[0]["movkind"]= DBNull.Value;
			CurrCausaleEstimate= CfgFn.GetNoNullInt32( DS.incomeestimate.Rows[0]["movkind"]);
			return CurrCausaleEstimate;
			//ReCalcImporto();
		}


		void UpdateComboCausaleEstimate(){
			if (EstimateMovEntrataLinked!=null){
				object currtipo = EstimateMovEntrataLinked["movkind"];
				HelpForm.SetComboBoxValue(cmbCausale, currtipo);
			}
		}

		private void cmbTipoEstimate_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			if (TipoDocChangePilotato) return;
			TipoDocChangePilotato=true;
			ClearControlliEstimate(true);
			txtEsercDoc.Text="";
			txtNumDoc.Text="";
			TipoDocChangePilotato=false;
		}


		#endregion

		void ResetIva(){
			IvaLinkedMustBeEvalued=true;
			IvaLinked=null;
			IvaMovEntrataLinked=null;
            //IvaMovEntrataViewLinked=null;
		}

		void RintracciaIva(){
			if (!IvaLinkedMustBeEvalued)return;
			GetDocIva(out IvaLinked, 
				out IvaMovEntrataLinked, 
                //out IvaMovEntrataViewLinked, 
				out CurrCausaleIva);
            if ((IvaLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))){
                AssegnaDatiContratto(IvaLinked);
			}
			IvaLinkedMustBeEvalued=false;
		}

		void ResetEstimate(){
			EstimateLinkedMustBeEvalued=true;
			EstimateLinked=null;
			EstimateMovEntrataLinked=null;
            //EstimateMovEntrataViewLinked=null;
		}

		void RintracciaEstimate(){
			if (!EstimateLinkedMustBeEvalued)return;
			GetDocEstimate(out EstimateLinked, 
				out EstimateMovEntrataLinked, 
                //out EstimateMovEntrataViewLinked, 
				out CurrCausaleEstimate);
            if ((EstimateLinked != null) && (faseMaxInclusa() && (Meta.InsertMode))) {
                AssegnaDatiContratto(EstimateLinked);
			}
			EstimateLinkedMustBeEvalued=false;
		}

        void AssegnaDatiContratto(DataRow Contratto){
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
                    if (DS.account.Rows.Count > 0)
                    {
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

			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "(ayear ='" + esercizio.ToString() + "')and((flag & 1)=0)";
						
			//Il filtro sull'UPB c'è sempre
            string filterUpb = "";
            object getupb = GetUpb();
			if (getupb!=DBNull.Value){
                filterUpb = QHS.CmpEq("idupb", getupb);
			}
			else {
                filterUpb = QHS.CmpEq("idupb", "0001");
			}
            filter = filteridfin + "AND" + filterUpb;
			
			//Aggiunge eventualmente il filtro sul disponibile
            decimal currval = 0;
            if (chkFilterAvailable.Checked){
				if (SubEntity_txtImportoMovimento.Text.Trim()!=""){
					currval= CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
						typeof(decimal),SubEntity_txtImportoMovimento.Text,"x.y.c"));
				}
				
				filter=GetData.MergeFilters(filter,
					"(availableprevision>="+QueryCreator.quotedstrvalue(currval,true)+")");
			}

			string filteroperativo= "(idfin in (SELECT idfin from finusable where ayear='"+
				Meta.GetSys("esercizio").ToString()+"'))";
			if (chkListManager.Checked){
                object getman = GetResponsabile();
				if (getman!=DBNull.Value){
					filter= QHS.AppAnd(filter,QHS.CmpEq("idman",getman));
				}
				else {
					filter= QHS.AppAnd(filter,QHS.IsNull("idman"));
				}
				filter= GetData.MergeFilters(filter,filteroperativo);
				MetaData.DoMainCommand(this,"choose.finview.default."+filter);
				return;
			}
			if (chkListTitle.Checked){
				FrmAskDescr FR= new FrmAskDescr(0);
				DialogResult D = FR.ShowDialog(this);
				if (D!= DialogResult.OK) return;
				filter = GetData.MergeFilters(filter,
					"(title like "+QueryCreator.quotedstrvalue(
					"%"+FR.txtDescrizione.Text+"%",true))+")";
				filter= GetData.MergeFilters(filter,filteroperativo);
				MetaData.DoMainCommand(this,"choose.finview.default."+filter);
				return;
			}
            string filterFinanziamento = "";
            filterFinanziamento = GetData.MergeFilters(filterUpb,
                    "(incomeprevavailable>=" + QueryCreator.quotedstrvalue(currval, true) + ")");
            filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteroperativo);
            filterFinanziamento = GetData.MergeFilters(filterFinanziamento, filteridfin); // filtra voci bilancio di entrata ed esercizio corrente
            DataTable Tupbunderwritingyearview = MyConn.RUN_SELECT("upbunderwritingyearview", "*", null, filterFinanziamento, null, null, true);

            if (!(Meta.IsEmpty) && (chkFilterAvailable.Checked) && (Tupbunderwritingyearview.Rows.Count > 0)){
                MetaData MetaUpbunderwritingyearview = MetaData.GetMetaData(this, "upbunderwritingyearview");
                MetaUpbunderwritingyearview.DS = new DataSet();
                MetaUpbunderwritingyearview.linkedForm = this;
                MetaUpbunderwritingyearview.FilterLocked = true;
                DataRow Upbunderwritingyearview = MetaUpbunderwritingyearview.SelectOne("default", filterFinanziamento, "upbunderwritingyearview", null);
                if (Upbunderwritingyearview == null) return;
                txtFinanziamento.Text = Upbunderwritingyearview["underwriting"].ToString();
                txtCodiceBilancio.Text = Upbunderwritingyearview["codefin"].ToString();
                txtDenominazioneBilancio.Text = Upbunderwritingyearview["fin"].ToString();
                DataRow curr = DS.income.Rows[0];
                DataRow curryear = DS.incomeyear.Rows[0];
                curr["idunderwriting"] = Upbunderwritingyearview["idunderwriting"];
                curryear["idfin"] = Upbunderwritingyearview["idfin"];
            }
            else{
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                MetaData.DoMainCommand(this, "manage.finview.treeeupb");
            }
		}

		private void chkListManager_CheckedChanged(object sender, System.EventArgs e) {
			if (chkListManager.Checked) chkListTitle.Checked=false;
		}

		private void chkListTitle_CheckedChanged(object sender, System.EventArgs e) {
			if (chkListTitle.Checked) chkListManager.Checked=false;
		}

		private void btnSituazioneMovimentoSpesa_Click(object sender, System.EventArgs e) {
			string identrata;
			DataAccess Conn=MetaData.GetConnection(this);
			try {
				DataRow MyRow=HelpForm.GetLastSelected(DS.income);
				identrata=MyRow["idinc"].ToString();
			}
			catch {
				return;
			}
			DataSet Out = Meta.Conn.CallSP("show_income",
				new Object[3] {identrata,
								  Meta.GetSys("esercizio").ToString(),
								  Meta.GetSys("datacontabile")
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione movimento di entrata";
			frmSituazioneViewer View = new frmSituazioneViewer(Out);
			View.Show();
		}

		private void chbCoperturaIniziativa_CheckedChanged(object sender, System.EventArgs e) {
			if (SubEntity_chbCoperturaIniziativa.Checked){
				gboxBolletta.Enabled=true;
				GestisciNumBolletta();
			}
			else {
				gboxBolletta.Enabled=false;
				GestisciNumBolletta();
			}
		}

        private void btnUPBCode_Click(object sender, EventArgs e) {
            object getman = GetResponsabile();
            if(getman==DBNull.Value || !Meta.InsertMode) {
                Meta.DoMainCommand("manage.upb.tree");
                return;
            }
           
            string filter = QHS.AppAnd(QHS.CmpEq("idman", getman), QHS.CmpEq("active", 'S'),
                               QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            decimal currval = 0;
            if(Meta.IsEmpty || Meta.InsertMode) {
                if(SubEntity_txtImportoMovimento.Text.Trim() != "") {
                    currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                                    typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
                }
            }
            else {
                if(SubEntity_txtImportoMovimento.Text.Trim() != "") {
                    currval = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                        typeof(decimal), SubEntity_txtImportoMovimento.Text, "x.y.c"));
                }
            }
            if (currval > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpGe("incomeprevavailable", currval));
            }
            MetaData MetaUpb = MetaData.GetMetaData(this, "upbyearview");
            MetaUpb.DS = new DataSet();
            MetaUpb.linkedForm = this;
            MetaUpb.FilterLocked = true;
            DataRow Upb = MetaUpb.SelectOne("income", filter, "upbyearview", null);
            if(Upb == null) return;
            object idupb = Upb["idupb"];
            SetUPB(idupb);
        }

        private void cmbIstitutoCassiere_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbIstitutoCassiere.SelectedIndex <= 0) return;
            object val = cmbIstitutoCassiere.SelectedValue;
            if (val == DBNull.Value) return;
            string flt = QHC.CmpEq("idtreasurer", val);
            if (DS.treasurer.Select(flt).Length == 0) return;
            object fruitful = DS.treasurer.Select(flt)[0]["flagfruitful"];
            if (fruitful == DBNull.Value) return;
            if (fruitful.ToString().ToUpper() == "F") {
                rdbInfruttifero.Checked = false;
                rdbFruttifero.Checked = true;
            }
            else {
                rdbFruttifero.Checked = false;
                rdbInfruttifero.Checked = true;
            }
        }

        private void btnCopiaAssegnazioneCrediti_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);
            DS.proceedspart.Clear();
            MetaData MProcPart = Meta.Dispatcher.Get("proceedspart");
            MProcPart.SetDefaults(DS.proceedspart);
            DataRow Curr= DS.income.Rows[0];
            foreach (DataRow R in DS.creditpart.Rows) {
                DataRow RP = MProcPart.Get_New_Row(Curr, DS.proceedspart);
                foreach (string field in new string[] {"idfin","!codbil","!denombil","description","idupb","!codeupb","!upb",
                    "amount","adate" }) {
                    RP[field] = R[field];
                }
            }
            Meta.FreshForm(true);
        }

        private void SubEntity_chkCassa_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = (SubEntity_chkCassa.CheckState == CheckState.Checked);
            if (isChecked)
            {
                SubEntity_chkPrelievodaCCP.Checked = !isChecked;
                SubEntity_chkAccreditoTPS.Checked = !isChecked;
            }
        }

        private void SubEntity_chkPrelievodaCCP_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = (SubEntity_chkPrelievodaCCP.CheckState == CheckState.Checked);
            if (isChecked)
            {
                SubEntity_chkAccreditoTPS.Checked = !isChecked;
                SubEntity_chkCassa.Checked = !isChecked;
            }
        }

        private void SubEntity_chkAccreditoTPS_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = (SubEntity_chkAccreditoTPS.CheckState == CheckState.Checked);
            if (isChecked)
            {
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
                decimal amount = CfgFn.GetNoNullDecimal(r["total"]) - CfgFn.GetNoNullDecimal(r["reduction"]) - CfgFn.GetNoNullDecimal(r["covered"]);
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
    }
}
