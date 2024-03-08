
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using itinerationFunctions;
using SituazioneViewer;
using ep_functions;
using ap_functions;
using q = metadatalibrary.MetaExpression;

namespace itineration_default { //missione//

    /// <summary>
    /// Summary description for frmmissione.
    /// </summary>
    public class Frm_itineration_default : MetaDataForm {
        #region Variabili

        IMetaData Meta;
        DataTable RitenuteCalcolate;
        bool AnticipoIsReadOnly;

        #endregion

        #region Dichiarazione controlli

        private System.Windows.Forms.TabControl tabCtrlMissione;
        private System.Windows.Forms.TabPage tabGeneralita;
        private System.Windows.Forms.TabPage tabIndKm;
        private System.Windows.Forms.TabPage tabRitenute;
        private System.Windows.Forms.TabPage tabCalcolo;
        private System.Windows.Forms.TextBox txtEsercmissione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNummissione;
        private System.Windows.Forms.Button btnAggiorna;
        private System.Windows.Forms.GroupBox grpIncaricato;
        private System.Windows.Forms.TextBox txtIncaricato;
        private System.Windows.Forms.Button btnPrestazione;
        private System.Windows.Forms.ComboBox cmbPrestazione;
        public dsmeta DS;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDataAut;
        private System.Windows.Forms.GroupBox grpPosGiuridica;
        private System.Windows.Forms.TextBox txtClassStip;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtMatricola;
        private System.Windows.Forms.TextBox txtGruppoEstero;
        private System.Windows.Forms.TextBox txtDecorrClassStip;
        private System.Windows.Forms.TabPage tabTappeSpese;
        private System.Windows.Forms.GroupBox grpTappe;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtKmMezzoProprio;
        private System.Windows.Forms.TextBox txtEurKmMezzoProprio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtEurTotMezzoProprio;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtEurTotMezzoAmm;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtKmMezzoAmm;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtEurKmMezzoAmm;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox grpIndMezzoAmm;
        private System.Windows.Forms.GroupBox grpIndMezzoProprio;
        private System.Windows.Forms.GroupBox grpIndAPiedi;
        private System.Windows.Forms.TextBox txtEurTotAPiedi;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtKmAPiedi;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtEurKmAPiedi;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DataGrid dgrTappe;
        private System.Windows.Forms.Button btnDelTappa;
        private System.Windows.Forms.Button btnEditTappa;
        private System.Windows.Forms.Button btnInsertTappa;
        private System.Windows.Forms.GroupBox gboxRitDipendente;
        private System.Windows.Forms.TextBox txtAssicurativeDip;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtImportonettoDip;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtAltreDip;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtFiscaliDip;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtPrevidenzialiDip;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtAssistenzialiDip;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox gboxContrEnte;
        private System.Windows.Forms.TextBox txtAssicurativeEnte;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtCostoTotaleEnte;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox txtAltreEnte;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtPrevidenzialiEnte;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtAssistenzialiEnte;
        private System.Windows.Forms.Label label51;
        string btnInsertTappaTag, btnEditTappaTag, dgrTappeTag;
        private System.Windows.Forms.GroupBox grpSpese;
        private System.Windows.Forms.Button btnDelSpesa;
        private System.Windows.Forms.Button btnEditSpesa;
        private System.Windows.Forms.DataGrid dgrSpeseTappe;
        private System.Windows.Forms.Button btnInsertSpesa;
        private System.Windows.Forms.TextBox txtCoeffLord;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TextBox txtSpeseSostenute;
        private System.Windows.Forms.TextBox txtQuotaEsenteMissione;
        private System.Windows.Forms.TextBox txtQuotaImponibileTappa;
        private System.Windows.Forms.TextBox txtImportoAnticipo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Label labelQuotaImponibile;
        private System.Windows.Forms.Label labelQuotaEsente;
        private System.Windows.Forms.Label labelImpAnticipo;
        private System.Windows.Forms.Label labelImpCompl;
        private System.Windows.Forms.Label labelSpeseSost;
        private System.Windows.Forms.TextBox txtComplessivo;
        private System.Windows.Forms.Button btnSituazione;
        private System.Windows.Forms.ToolTip myTip;
        private System.Windows.Forms.TextBox txtHelpCoeffLord;
        private System.Windows.Forms.Label label33;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labQuotaEsente;
        private System.Windows.Forms.TabPage tabClassSuppl;
        private System.Windows.Forms.Button btnClassInserisci;
        private System.Windows.Forms.Button btnClassModifica;
        private System.Windows.Forms.Button btnClassElimina;
        private System.Windows.Forms.DataGrid dgrClassSuppl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtFiscaliEnte;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtImpEsenteItalia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtImpEsenteEstero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gboxDate;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAnalitico;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gBoxCausaleCosto;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnGeneraEP;
        private System.Windows.Forms.Button btnVisualizzaEP;
        private System.Windows.Forms.Label labEP;
        private System.Windows.Forms.Button btnGeneraEpExp;
        private System.Windows.Forms.Button btnVisualizzaEpExp;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTotLordEst;
        private System.Windows.Forms.Label labelIndLordEst;
        private System.Windows.Forms.TextBox txtTotLordIt;
        private System.Windows.Forms.Label labelIndLordIt;
        private System.Windows.Forms.TextBox txtTotIndennKm;
        private System.Windows.Forms.Label labeIndKm;
        private System.Windows.Forms.TextBox txtIndSupplementare;
        private System.Windows.Forms.Label labelIndSuppl;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtPrevAmministrazione;
        private System.Windows.Forms.TextBox txtAssAmministrazione;
        private System.Windows.Forms.Label labelRitPrevAmm;
        private System.Windows.Forms.Label labelRitAssAmm;
        private System.Windows.Forms.TextBox txtLordo;
        private System.Windows.Forms.Label labelImpLord;
        private System.Windows.Forms.TabPage tabAnagPrest;
        private System.Windows.Forms.Button btnGeneraAP;
        private System.Windows.Forms.Button btnVisualizzaAP;
        private System.Windows.Forms.Label labAPnongenerato;
        private System.Windows.Forms.Label labAPgenerato;
        private Label label1;
        private TextBox txtQualifica;
        private Label label3;
        private TextBox textBox6;
        private GroupBox gBoxCausaleDebitoCrg;
        private TextBox textBox9;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox gBoxCausaleDebito;
        private TextBox textBox11;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private GroupBox groupBox6;
        private TextBox txtCompartoCSA;
        private TextBox txtInquadrcsa;
        private Label label14;
        private Label label13;
        private Label lblRuoloCSA;
        private TextBox txtRuoloCSA;
        private Button btnCambiaRuolo;
        private CheckBox chkWeb;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private GroupBox gboxAction;
        private Button btnAccetta;
        private Button btnRiconsidera;
        private Button btnintegra;
        private GroupBox grpSpeseRendiconto;
        private Button btnDeleteSpesaSaldo;
        private Button btnEditSpesaSaldo;
        private DataGrid dataGrid2;
        private Button btnInsertSpesaSaldo;
        private TabPage tabAutorizzazioni;
        private GroupBox grpModelloAut;
        private ComboBox cmbAuthModel;
        private GroupBox groupBox12;
        private DataGrid dgrAutorizzazioni;
        private Button btnAttesaAutorizzazione;
        private TabPage tabPagamenti;
        private GroupBox groupBox8;
        private TextBox textBox13;
        private GroupBox groupBox13;
        private TextBox textBox12;
        private Button btnAnnulla;
        private TextBox txtImportoMax;
        private Label label10;
        private TextBox txtLunghezzaMax;
        private Label label17;
        private TextBox textBox16;
        private TextBox txtSpeseSaldo;
        private Label labelSpeseSaldo;
        private TextBox textBox14;
        private TextBox txtSpeseAnticipo;
        private Label labelSpeseAnticipo;
        private Button btnInserisciAnticipo;
        private GroupBox grpBoxAutorizzazioneAP;
        private RadioButton rdbAutorizzazioneNonNecessaria;
        private RadioButton rdbNonApplicabile;
        private RadioButton rdbNecessitaAutorizzazione;
        private GroupBox grpBoxDocAutorizzattivo;
        private TextBox txtDocumentoAut;
        private Label label19;
        private TextBox txtDataDocumentoAut;
        private Label label22;
        private GroupBox grpBoxMotivo;
        private TextBox txtMotivoAut;
        private TextBox txtClause;
        private CheckBox chkClauseMezzoProprio;
        private Label label38;
        private TextBox txtDatiMezzoProprio;
        private Label label34;
        private TextBox txtCausaleMezzoProprio;
        private TabPage tabAllegati;
        private DataGrid dataGrid3;
        private Button button2;
        private Button button3;
        private Button button1;
        private Label label39;
        private TextBox txtLocation;
        private TabPage tabAttributi;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
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
        private Button btnGeneraPreimpegni;
        private Button btnVisualizzaPreimpegni;
        private System.Windows.Forms.CheckBox chkPagabile;

        #endregion

        private TextBox txtDateCompleted;
        private Label label9;
        private TabPage tabDALIA;
        private GroupBox groupBox9;
        private Label label91;
        private TextBox textBox19;
        private ComboBox cmb_dalia_position;
        private Button btnVoceSpesaDalia;
        private TextBox txtVoceSpesaDalia;
        private Button btnQualificaDalia;
        private GroupBox groupBox10;
        private TextBox txt_additionalannotations;
        private GroupBox grpBoxSiopeEP;
        private Button btnSiope;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Label label40;
        public TextBox txtNRif;
        public GroupBox gboxRif;
        private TabPage tabCTanticipo;
        private GroupBox grpTratte;
        private DataGrid dataGrid4;
        private Button button4;
        private Button button8;
        private Button button9;
        private GroupBox grpAnticipoTramiteCosti;
        private GroupBox groupBox14;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private TextBox textBox22;
        private Label label58;
        private TextBox textBox21;
        private Label label57;
        private TextBox textBox15;
        private Label label53;
        private TextBox textBox17;
        private Label label54;
        private TextBox textBox18;
        private Label label55;
        private TextBox textBox20;
        private Label label56;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private Label label52;
        private TextBox textBox23;
        private Label label59;
        private GroupBox grpCausaliAssunzioneDalia;
        private TextBox txtCausaleAssunzione;
        private Button btnEsclusioneCIG;
        private TextBox txtDataOraInizio;
        private Label label60;
        private Label label61;
        private TextBox txtDataOraTermine;
        private Label label62;
        public TextBox txtYRif;
		private GroupBox gboxDipartimento;
		private Button btnDipartimento;
		private TextBox txtCodiceDipartimento;
		public TextBox txtDaliaDipartimento;
		private GroupBox groupBox3;
		private ComboBox cmbDaliaFunzionale;
		public GroupBox groupBox7;
		public Button btnCodRipartizione;
		public TextBox txtDenRipartizione;
		public TextBox txtCodiceRipartizione;
		private Button btnRipartizione;
		private GroupBox grpAltro;
		private TextBox textBox24;
		private Label label63;
		private Label label64;
		private TextBox textBox26;
		private Label label66;
		private TextBox textBox25;
		private Label label65;
		private TextBox txtPercAnticipoItaliaEstero;
		private EP_Manager EPM;

        public Frm_itineration_default() {
            InitializeComponent();
            txtDataInizio.LostFocus += new System.EventHandler(txtDataInizio_LostFocus);
            txtDataFine.LostFocus += new EventHandler(txtDataFine_LostFocus);
            //			txtDataContabile.LostFocus += new System.EventHandler(txtDataContabile_LostFocus);
            //			cmbPrestazione.LostFocus+= new System.EventHandler(cmbPrestazione_LostFocus);
            //			txtIncaricato.LostFocus+= new System.EventHandler(txtIncaricato_LostFocus);
            btnInsertTappaTag = btnInsertTappa.Tag.ToString();
            btnEditTappaTag = btnInsertTappa.Tag.ToString();
            dgrTappeTag = dgrTappe.Tag.ToString();
            cmbDaliaFunzionale.DataSource = DS.dalia_funzionale;
            cmbDaliaFunzionale.DisplayMember = "title";
            cmbDaliaFunzionale.ValueMember = "iddalia_funzionale";
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itineration_default));
			this.tabCtrlMissione = new System.Windows.Forms.TabControl();
			this.tabGeneralita = new System.Windows.Forms.TabPage();
			this.gboxRif = new System.Windows.Forms.GroupBox();
			this.label62 = new System.Windows.Forms.Label();
			this.txtYRif = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.txtNRif = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtDateCompleted = new System.Windows.Forms.TextBox();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.txtLocation = new System.Windows.Forms.TextBox();
			this.btnInserisciAnticipo = new System.Windows.Forms.Button();
			this.gboxAction = new System.Windows.Forms.GroupBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnAttesaAutorizzazione = new System.Windows.Forms.Button();
			this.btnAccetta = new System.Windows.Forms.Button();
			this.btnRiconsidera = new System.Windows.Forms.Button();
			this.btnintegra = new System.Windows.Forms.Button();
			this.gboxStato = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.DS = new itineration_default.dsmeta();
			this.chkWeb = new System.Windows.Forms.CheckBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnCambiaRuolo = new System.Windows.Forms.Button();
			this.txtCompartoCSA = new System.Windows.Forms.TextBox();
			this.txtInquadrcsa = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblRuoloCSA = new System.Windows.Forms.Label();
			this.txtRuoloCSA = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtImpEsenteEstero = new System.Windows.Forms.TextBox();
			this.txtImpEsenteItalia = new System.Windows.Forms.TextBox();
			this.grpPosGiuridica = new System.Windows.Forms.GroupBox();
			this.txtQualifica = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.txtMatricola = new System.Windows.Forms.TextBox();
			this.txtGruppoEstero = new System.Windows.Forms.TextBox();
			this.txtDecorrClassStip = new System.Windows.Forms.TextBox();
			this.txtClassStip = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.chkPagabile = new System.Windows.Forms.CheckBox();
			this.gboxDate = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataAut = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercmissione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNummissione = new System.Windows.Forms.TextBox();
			this.labQuotaEsente = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.btnSituazione = new System.Windows.Forms.Button();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbPrestazione = new System.Windows.Forms.ComboBox();
			this.btnPrestazione = new System.Windows.Forms.Button();
			this.grpIncaricato = new System.Windows.Forms.GroupBox();
			this.txtIncaricato = new System.Windows.Forms.TextBox();
			this.btnAggiorna = new System.Windows.Forms.Button();
			this.tabTappeSpese = new System.Windows.Forms.TabPage();
			this.grpTappe = new System.Windows.Forms.GroupBox();
			this.grpSpeseRendiconto = new System.Windows.Forms.GroupBox();
			this.btnDeleteSpesaSaldo = new System.Windows.Forms.Button();
			this.btnEditSpesaSaldo = new System.Windows.Forms.Button();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.btnInsertSpesaSaldo = new System.Windows.Forms.Button();
			this.grpSpese = new System.Windows.Forms.GroupBox();
			this.btnDelSpesa = new System.Windows.Forms.Button();
			this.btnEditSpesa = new System.Windows.Forms.Button();
			this.dgrSpeseTappe = new System.Windows.Forms.DataGrid();
			this.btnInsertSpesa = new System.Windows.Forms.Button();
			this.btnDelTappa = new System.Windows.Forms.Button();
			this.btnEditTappa = new System.Windows.Forms.Button();
			this.dgrTappe = new System.Windows.Forms.DataGrid();
			this.btnInsertTappa = new System.Windows.Forms.Button();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.txtHelpCoeffLord = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
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
			this.gboxContrEnte = new System.Windows.Forms.GroupBox();
			this.txtFiscaliEnte = new System.Windows.Forms.TextBox();
			this.txtAssicurativeEnte = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.txtCostoTotaleEnte = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.txtAltreEnte = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.txtPrevidenzialiEnte = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.txtAssistenzialiEnte = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.txtCoeffLord = new System.Windows.Forms.TextBox();
			this.tabIndKm = new System.Windows.Forms.TabPage();
			this.label38 = new System.Windows.Forms.Label();
			this.txtDatiMezzoProprio = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.txtCausaleMezzoProprio = new System.Windows.Forms.TextBox();
			this.txtClause = new System.Windows.Forms.TextBox();
			this.chkClauseMezzoProprio = new System.Windows.Forms.CheckBox();
			this.label35 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.grpIndMezzoAmm = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtEurTotMezzoAmm = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtKmMezzoAmm = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.txtEurKmMezzoAmm = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.grpIndMezzoProprio = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtEurTotMezzoProprio = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.txtKmMezzoProprio = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtEurKmMezzoProprio = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.grpIndAPiedi = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtEurTotAPiedi = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.txtKmAPiedi = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txtEurKmAPiedi = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.tabClassSuppl = new System.Windows.Forms.TabPage();
			this.dgrClassSuppl = new System.Windows.Forms.DataGrid();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
			this.tabCalcolo = new System.Windows.Forms.TabPage();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.txtSpeseSaldo = new System.Windows.Forms.TextBox();
			this.labelSpeseSaldo = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.txtSpeseAnticipo = new System.Windows.Forms.TextBox();
			this.labelSpeseAnticipo = new System.Windows.Forms.Label();
			this.txtLordo = new System.Windows.Forms.TextBox();
			this.labelImpLord = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.txtPrevAmministrazione = new System.Windows.Forms.TextBox();
			this.txtAssAmministrazione = new System.Windows.Forms.TextBox();
			this.labelRitPrevAmm = new System.Windows.Forms.Label();
			this.labelRitAssAmm = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtTotLordEst = new System.Windows.Forms.TextBox();
			this.labelIndLordEst = new System.Windows.Forms.Label();
			this.txtTotLordIt = new System.Windows.Forms.TextBox();
			this.labelIndLordIt = new System.Windows.Forms.Label();
			this.txtTotIndennKm = new System.Windows.Forms.TextBox();
			this.labeIndKm = new System.Windows.Forms.Label();
			this.txtIndSupplementare = new System.Windows.Forms.TextBox();
			this.labelIndSuppl = new System.Windows.Forms.Label();
			this.btnToExcel = new System.Windows.Forms.Button();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtQuotaImponibileTappa = new System.Windows.Forms.TextBox();
			this.labelQuotaImponibile = new System.Windows.Forms.Label();
			this.txtQuotaEsenteMissione = new System.Windows.Forms.TextBox();
			this.labelQuotaEsente = new System.Windows.Forms.Label();
			this.txtImportoAnticipo = new System.Windows.Forms.TextBox();
			this.txtComplessivo = new System.Windows.Forms.TextBox();
			this.labelImpAnticipo = new System.Windows.Forms.Label();
			this.labelImpCompl = new System.Windows.Forms.Label();
			this.txtSpeseSostenute = new System.Windows.Forms.TextBox();
			this.labelSpeseSost = new System.Windows.Forms.Label();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
			this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btnCodRipartizione = new System.Windows.Forms.Button();
			this.txtDenRipartizione = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.btnRipartizione = new System.Windows.Forms.Button();
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.gBoxCausaleDebitoCrg = new System.Windows.Forms.GroupBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.gBoxCausaleDebito = new System.Windows.Forms.GroupBox();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.gBoxCausaleCosto = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.tabAnagPrest = new System.Windows.Forms.TabPage();
			this.btnCollegaAP = new System.Windows.Forms.Button();
			this.grpBoxMotivo = new System.Windows.Forms.GroupBox();
			this.txtMotivoAut = new System.Windows.Forms.TextBox();
			this.grpBoxDocAutorizzattivo = new System.Windows.Forms.GroupBox();
			this.txtDocumentoAut = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtDataDocumentoAut = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.grpBoxAutorizzazioneAP = new System.Windows.Forms.GroupBox();
			this.rdbAutorizzazioneNonNecessaria = new System.Windows.Forms.RadioButton();
			this.rdbNonApplicabile = new System.Windows.Forms.RadioButton();
			this.rdbNecessitaAutorizzazione = new System.Windows.Forms.RadioButton();
			this.btnGeneraAP = new System.Windows.Forms.Button();
			this.btnVisualizzaAP = new System.Windows.Forms.Button();
			this.labAPnongenerato = new System.Windows.Forms.Label();
			this.labAPgenerato = new System.Windows.Forms.Label();
			this.tabAutorizzazioni = new System.Windows.Forms.TabPage();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.dgrAutorizzazioni = new System.Windows.Forms.DataGrid();
			this.grpModelloAut = new System.Windows.Forms.GroupBox();
			this.txtImportoMax = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbAuthModel = new System.Windows.Forms.ComboBox();
			this.txtLunghezzaMax = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.tabPagamenti = new System.Windows.Forms.TabPage();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.txt_additionalannotations = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.textBox13 = new System.Windows.Forms.TextBox();
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
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabDALIA = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
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
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.label91 = new System.Windows.Forms.Label();
			this.btnQualificaDalia = new System.Windows.Forms.Button();
			this.textBox19 = new System.Windows.Forms.TextBox();
			this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
			this.tabCTanticipo = new System.Windows.Forms.TabPage();
			this.grpAltro = new System.Windows.Forms.GroupBox();
			this.label60 = new System.Windows.Forms.Label();
			this.grpTratte = new System.Windows.Forms.GroupBox();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button9 = new System.Windows.Forms.Button();
			this.label52 = new System.Windows.Forms.Label();
			this.grpAnticipoTramiteCosti = new System.Windows.Forms.GroupBox();
			this.textBox26 = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.textBox25 = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.txtPercAnticipoItaliaEstero = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.textBox24 = new System.Windows.Forms.TextBox();
			this.label63 = new System.Windows.Forms.Label();
			this.textBox23 = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.label58 = new System.Windows.Forms.Label();
			this.textBox21 = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.txtDataOraInizio = new System.Windows.Forms.TextBox();
			this.txtDataOraTermine = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.myTip = new System.Windows.Forms.ToolTip(this.components);
			this.tabCtrlMissione.SuspendLayout();
			this.tabGeneralita.SuspendLayout();
			this.gboxRif.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.gboxAction.SuspendLayout();
			this.gboxStato.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox6.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpPosGiuridica.SuspendLayout();
			this.gboxDate.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpIncaricato.SuspendLayout();
			this.tabTappeSpese.SuspendLayout();
			this.grpTappe.SuspendLayout();
			this.grpSpeseRendiconto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.grpSpese.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseTappe)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrTappe)).BeginInit();
			this.tabRitenute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.gboxRitDipendente.SuspendLayout();
			this.gboxContrEnte.SuspendLayout();
			this.tabIndKm.SuspendLayout();
			this.grpIndMezzoAmm.SuspendLayout();
			this.grpIndMezzoProprio.SuspendLayout();
			this.grpIndAPiedi.SuspendLayout();
			this.tabClassSuppl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).BeginInit();
			this.tabCalcolo.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabEP.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.gBoxCausaleDebitoCrg.SuspendLayout();
			this.gBoxCausaleDebito.SuspendLayout();
			this.gBoxCausaleCosto.SuspendLayout();
			this.tabAnagPrest.SuspendLayout();
			this.grpBoxMotivo.SuspendLayout();
			this.grpBoxDocAutorizzattivo.SuspendLayout();
			this.grpBoxAutorizzazioneAP.SuspendLayout();
			this.tabAutorizzazioni.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrAutorizzazioni)).BeginInit();
			this.grpModelloAut.SuspendLayout();
			this.tabPagamenti.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabDALIA.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gboxDipartimento.SuspendLayout();
			this.grpCausaliAssunzioneDalia.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabCTanticipo.SuspendLayout();
			this.grpAltro.SuspendLayout();
			this.grpTratte.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			this.grpAnticipoTramiteCosti.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabCtrlMissione
			// 
			this.tabCtrlMissione.Controls.Add(this.tabGeneralita);
			this.tabCtrlMissione.Controls.Add(this.tabTappeSpese);
			this.tabCtrlMissione.Controls.Add(this.tabRitenute);
			this.tabCtrlMissione.Controls.Add(this.tabIndKm);
			this.tabCtrlMissione.Controls.Add(this.tabClassSuppl);
			this.tabCtrlMissione.Controls.Add(this.tabCalcolo);
			this.tabCtrlMissione.Controls.Add(this.tabEP);
			this.tabCtrlMissione.Controls.Add(this.tabAnagPrest);
			this.tabCtrlMissione.Controls.Add(this.tabAutorizzazioni);
			this.tabCtrlMissione.Controls.Add(this.tabPagamenti);
			this.tabCtrlMissione.Controls.Add(this.tabAttributi);
			this.tabCtrlMissione.Controls.Add(this.tabAllegati);
			this.tabCtrlMissione.Controls.Add(this.tabDALIA);
			this.tabCtrlMissione.Controls.Add(this.tabCTanticipo);
			this.tabCtrlMissione.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabCtrlMissione.ImageList = this.imageList1;
			this.tabCtrlMissione.Location = new System.Drawing.Point(0, 0);
			this.tabCtrlMissione.Name = "tabCtrlMissione";
			this.tabCtrlMissione.SelectedIndex = 0;
			this.tabCtrlMissione.Size = new System.Drawing.Size(971, 527);
			this.tabCtrlMissione.TabIndex = 0;
			this.tabCtrlMissione.Tag = "itinerationlap.default.default";
			// 
			// tabGeneralita
			// 
			this.tabGeneralita.Controls.Add(this.gboxRif);
			this.tabGeneralita.Controls.Add(this.label9);
			this.tabGeneralita.Controls.Add(this.txtDateCompleted);
			this.tabGeneralita.Controls.Add(this.gboxResponsabile);
			this.tabGeneralita.Controls.Add(this.label39);
			this.tabGeneralita.Controls.Add(this.txtLocation);
			this.tabGeneralita.Controls.Add(this.btnInserisciAnticipo);
			this.tabGeneralita.Controls.Add(this.gboxAction);
			this.tabGeneralita.Controls.Add(this.gboxStato);
			this.tabGeneralita.Controls.Add(this.chkWeb);
			this.tabGeneralita.Controls.Add(this.groupBox6);
			this.tabGeneralita.Controls.Add(this.groupBox2);
			this.tabGeneralita.Controls.Add(this.grpPosGiuridica);
			this.tabGeneralita.Controls.Add(this.label37);
			this.tabGeneralita.Controls.Add(this.chkPagabile);
			this.tabGeneralita.Controls.Add(this.gboxDate);
			this.tabGeneralita.Controls.Add(this.groupBox1);
			this.tabGeneralita.Controls.Add(this.labQuotaEsente);
			this.tabGeneralita.Controls.Add(this.checkBox1);
			this.tabGeneralita.Controls.Add(this.btnSituazione);
			this.tabGeneralita.Controls.Add(this.txtDescrizione);
			this.tabGeneralita.Controls.Add(this.label4);
			this.tabGeneralita.Controls.Add(this.cmbPrestazione);
			this.tabGeneralita.Controls.Add(this.btnPrestazione);
			this.tabGeneralita.Controls.Add(this.grpIncaricato);
			this.tabGeneralita.Controls.Add(this.btnAggiorna);
			this.tabGeneralita.Location = new System.Drawing.Point(4, 23);
			this.tabGeneralita.Name = "tabGeneralita";
			this.tabGeneralita.Size = new System.Drawing.Size(963, 500);
			this.tabGeneralita.TabIndex = 0;
			this.tabGeneralita.Tag = "";
			this.tabGeneralita.Text = "Principale";
			this.tabGeneralita.UseVisualStyleBackColor = true;
			// 
			// gboxRif
			// 
			this.gboxRif.Controls.Add(this.label62);
			this.gboxRif.Controls.Add(this.txtYRif);
			this.gboxRif.Controls.Add(this.label40);
			this.gboxRif.Controls.Add(this.txtNRif);
			this.gboxRif.Location = new System.Drawing.Point(279, 56);
			this.gboxRif.Name = "gboxRif";
			this.gboxRif.Size = new System.Drawing.Size(220, 48);
			this.gboxRif.TabIndex = 2;
			this.gboxRif.TabStop = false;
			this.gboxRif.Tag = "AutoChoose.txtNRif.lista.default";
			this.gboxRif.Text = "Missione di riferimento";
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(6, 20);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(58, 18);
			this.label62.TabIndex = 115;
			this.label62.Text = "Esercizio:";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtYRif
			// 
			this.txtYRif.Location = new System.Drawing.Point(65, 19);
			this.txtYRif.Name = "txtYRif";
			this.txtYRif.Size = new System.Drawing.Size(49, 20);
			this.txtYRif.TabIndex = 1;
			this.txtYRif.Tag = "itineration_riferimento.yitineration";
			this.txtYRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(120, 19);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(20, 18);
			this.label40.TabIndex = 113;
			this.label40.Text = "N.";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNRif
			// 
			this.txtNRif.Location = new System.Drawing.Point(142, 19);
			this.txtNRif.Name = "txtNRif";
			this.txtNRif.Size = new System.Drawing.Size(72, 20);
			this.txtNRif.TabIndex = 2;
			this.txtNRif.Tag = "itineration_riferimento.nitineration?itinerationview.nref";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(460, 384);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(217, 13);
			this.label9.TabIndex = 111;
			this.label9.Text = "Data acquisizione documentazione definitiva";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDateCompleted
			// 
			this.txtDateCompleted.Location = new System.Drawing.Point(688, 377);
			this.txtDateCompleted.Name = "txtDateCompleted";
			this.txtDateCompleted.Size = new System.Drawing.Size(100, 20);
			this.txtDateCompleted.TabIndex = 11;
			this.txtDateCompleted.Tag = "itineration.datecompleted";
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gboxResponsabile.Location = new System.Drawing.Point(23, 449);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(413, 40);
			this.gboxResponsabile.TabIndex = 12;
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
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(20, 157);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(344, 16);
			this.label39.TabIndex = 110;
			this.label39.Text = "Località principale (facoltativo):";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLocation
			// 
			this.txtLocation.Location = new System.Drawing.Point(23, 176);
			this.txtLocation.Name = "txtLocation";
			this.txtLocation.Size = new System.Drawing.Size(409, 20);
			this.txtLocation.TabIndex = 6;
			this.txtLocation.Tag = "itineration.location";
			// 
			// btnInserisciAnticipo
			// 
			this.btnInserisciAnticipo.Location = new System.Drawing.Point(632, 460);
			this.btnInserisciAnticipo.Name = "btnInserisciAnticipo";
			this.btnInserisciAnticipo.Size = new System.Drawing.Size(169, 23);
			this.btnInserisciAnticipo.TabIndex = 16;
			this.btnInserisciAnticipo.TabStop = false;
			this.btnInserisciAnticipo.Text = "Inserisci Anticipo Missione";
			this.btnInserisciAnticipo.Click += new System.EventHandler(this.btnInserisciAnticipo_Click);
			// 
			// gboxAction
			// 
			this.gboxAction.Controls.Add(this.btnAnnulla);
			this.gboxAction.Controls.Add(this.btnAttesaAutorizzazione);
			this.gboxAction.Controls.Add(this.btnAccetta);
			this.gboxAction.Controls.Add(this.btnRiconsidera);
			this.gboxAction.Controls.Add(this.btnintegra);
			this.gboxAction.Location = new System.Drawing.Point(24, 3);
			this.gboxAction.Name = "gboxAction";
			this.gboxAction.Size = new System.Drawing.Size(698, 47);
			this.gboxAction.TabIndex = 106;
			this.gboxAction.TabStop = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(500, 14);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(97, 24);
			this.btnAnnulla.TabIndex = 46;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Tag = "";
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// btnAttesaAutorizzazione
			// 
			this.btnAttesaAutorizzazione.Location = new System.Drawing.Point(249, 14);
			this.btnAttesaAutorizzazione.Name = "btnAttesaAutorizzazione";
			this.btnAttesaAutorizzazione.Size = new System.Drawing.Size(244, 24);
			this.btnAttesaAutorizzazione.TabIndex = 45;
			this.btnAttesaAutorizzazione.TabStop = false;
			this.btnAttesaAutorizzazione.Tag = "";
			this.btnAttesaAutorizzazione.Text = "Poni In Attesa di Autorizzazione";
			this.btnAttesaAutorizzazione.Click += new System.EventHandler(this.btnAttesaAutorizzazione_Click);
			// 
			// btnAccetta
			// 
			this.btnAccetta.Location = new System.Drawing.Point(9, 14);
			this.btnAccetta.Name = "btnAccetta";
			this.btnAccetta.Size = new System.Drawing.Size(97, 24);
			this.btnAccetta.TabIndex = 41;
			this.btnAccetta.TabStop = false;
			this.btnAccetta.Tag = "";
			this.btnAccetta.Text = "Accetta";
			this.btnAccetta.Click += new System.EventHandler(this.btnAccetta_Click);
			// 
			// btnRiconsidera
			// 
			this.btnRiconsidera.Location = new System.Drawing.Point(605, 14);
			this.btnRiconsidera.Name = "btnRiconsidera";
			this.btnRiconsidera.Size = new System.Drawing.Size(85, 24);
			this.btnRiconsidera.TabIndex = 44;
			this.btnRiconsidera.TabStop = false;
			this.btnRiconsidera.Tag = "";
			this.btnRiconsidera.Text = "Riconsidera";
			this.btnRiconsidera.Click += new System.EventHandler(this.btnRiconsidera_Click);
			// 
			// btnintegra
			// 
			this.btnintegra.Location = new System.Drawing.Point(111, 14);
			this.btnintegra.Name = "btnintegra";
			this.btnintegra.Size = new System.Drawing.Size(132, 24);
			this.btnintegra.TabIndex = 42;
			this.btnintegra.TabStop = false;
			this.btnintegra.Tag = "";
			this.btnintegra.Text = "Richiedi integrazioni";
			this.btnintegra.Click += new System.EventHandler(this.btnintegra_Click);
			// 
			// gboxStato
			// 
			this.gboxStato.Controls.Add(this.cmbStatus);
			this.gboxStato.Location = new System.Drawing.Point(510, 56);
			this.gboxStato.Name = "gboxStato";
			this.gboxStato.Size = new System.Drawing.Size(263, 49);
			this.gboxStato.TabIndex = 3;
			this.gboxStato.TabStop = false;
			this.gboxStato.Text = "Stato";
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.DataSource = this.DS.itinerationstatus;
			this.cmbStatus.DisplayMember = "description";
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Location = new System.Drawing.Point(17, 18);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(244, 21);
			this.cmbStatus.TabIndex = 43;
			this.cmbStatus.Tag = "itineration.iditinerationstatus?itinerationview.iditinerationstatus";
			this.cmbStatus.ValueMember = "iditinerationstatus";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// chkWeb
			// 
			this.chkWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkWeb.Location = new System.Drawing.Point(737, 18);
			this.chkWeb.Name = "chkWeb";
			this.chkWeb.Size = new System.Drawing.Size(160, 30);
			this.chkWeb.TabIndex = 104;
			this.chkWeb.TabStop = false;
			this.chkWeb.Tag = "itineration.flagweb:S:N";
			this.chkWeb.Text = "Missione inserita mediante interfaccia web";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.btnCambiaRuolo);
			this.groupBox6.Controls.Add(this.txtCompartoCSA);
			this.groupBox6.Controls.Add(this.txtInquadrcsa);
			this.groupBox6.Controls.Add(this.label14);
			this.groupBox6.Controls.Add(this.label13);
			this.groupBox6.Controls.Add(this.lblRuoloCSA);
			this.groupBox6.Controls.Add(this.txtRuoloCSA);
			this.groupBox6.Location = new System.Drawing.Point(439, 275);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(409, 71);
			this.groupBox6.TabIndex = 103;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Dati CSA";
			// 
			// btnCambiaRuolo
			// 
			this.btnCambiaRuolo.Location = new System.Drawing.Point(249, 40);
			this.btnCambiaRuolo.Name = "btnCambiaRuolo";
			this.btnCambiaRuolo.Size = new System.Drawing.Size(86, 22);
			this.btnCambiaRuolo.TabIndex = 109;
			this.btnCambiaRuolo.TabStop = false;
			this.btnCambiaRuolo.Text = "Cambia Ruolo";
			this.btnCambiaRuolo.UseVisualStyleBackColor = true;
			this.btnCambiaRuolo.Click += new System.EventHandler(this.btnCambiaRuolo_Click);
			// 
			// txtCompartoCSA
			// 
			this.txtCompartoCSA.Location = new System.Drawing.Point(113, 17);
			this.txtCompartoCSA.Name = "txtCompartoCSA";
			this.txtCompartoCSA.ReadOnly = true;
			this.txtCompartoCSA.Size = new System.Drawing.Size(52, 20);
			this.txtCompartoCSA.TabIndex = 108;
			this.txtCompartoCSA.TabStop = false;
			// 
			// txtInquadrcsa
			// 
			this.txtInquadrcsa.Location = new System.Drawing.Point(87, 40);
			this.txtInquadrcsa.Name = "txtInquadrcsa";
			this.txtInquadrcsa.ReadOnly = true;
			this.txtInquadrcsa.Size = new System.Drawing.Size(78, 20);
			this.txtInquadrcsa.TabIndex = 107;
			this.txtInquadrcsa.TabStop = false;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(55, 17);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 13);
			this.label14.TabIndex = 106;
			this.label14.Text = "Comparto";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 42);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(78, 13);
			this.label13.TabIndex = 105;
			this.label13.Text = "Inquadramento";
			// 
			// lblRuoloCSA
			// 
			this.lblRuoloCSA.AutoSize = true;
			this.lblRuoloCSA.Location = new System.Drawing.Point(219, 15);
			this.lblRuoloCSA.Name = "lblRuoloCSA";
			this.lblRuoloCSA.Size = new System.Drawing.Size(35, 13);
			this.lblRuoloCSA.TabIndex = 104;
			this.lblRuoloCSA.Text = "Ruolo";
			// 
			// txtRuoloCSA
			// 
			this.txtRuoloCSA.Location = new System.Drawing.Point(260, 15);
			this.txtRuoloCSA.Name = "txtRuoloCSA";
			this.txtRuoloCSA.ReadOnly = true;
			this.txtRuoloCSA.Size = new System.Drawing.Size(78, 20);
			this.txtRuoloCSA.TabIndex = 103;
			this.txtRuoloCSA.TabStop = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.txtImpEsenteEstero);
			this.groupBox2.Controls.Add(this.txtImpEsenteItalia);
			this.groupBox2.Location = new System.Drawing.Point(438, 208);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(410, 66);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Imponibile Esente";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(103, 37);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(136, 24);
			this.label12.TabIndex = 29;
			this.label12.Text = "Per le missioni all\'estero:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(111, 13);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(128, 24);
			this.label11.TabIndex = 31;
			this.label11.Text = "Per le missioni in Italia:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpEsenteEstero
			// 
			this.txtImpEsenteEstero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImpEsenteEstero.Location = new System.Drawing.Point(247, 37);
			this.txtImpEsenteEstero.Name = "txtImpEsenteEstero";
			this.txtImpEsenteEstero.ReadOnly = true;
			this.txtImpEsenteEstero.Size = new System.Drawing.Size(80, 20);
			this.txtImpEsenteEstero.TabIndex = 28;
			this.txtImpEsenteEstero.TabStop = false;
			this.txtImpEsenteEstero.Tag = "";
			this.txtImpEsenteEstero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImpEsenteItalia
			// 
			this.txtImpEsenteItalia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImpEsenteItalia.Location = new System.Drawing.Point(247, 13);
			this.txtImpEsenteItalia.Name = "txtImpEsenteItalia";
			this.txtImpEsenteItalia.ReadOnly = true;
			this.txtImpEsenteItalia.Size = new System.Drawing.Size(80, 20);
			this.txtImpEsenteItalia.TabIndex = 30;
			this.txtImpEsenteItalia.TabStop = false;
			this.txtImpEsenteItalia.Tag = "";
			this.txtImpEsenteItalia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpPosGiuridica
			// 
			this.grpPosGiuridica.Controls.Add(this.txtQualifica);
			this.grpPosGiuridica.Controls.Add(this.label18);
			this.grpPosGiuridica.Controls.Add(this.label20);
			this.grpPosGiuridica.Controls.Add(this.label21);
			this.grpPosGiuridica.Controls.Add(this.label15);
			this.grpPosGiuridica.Controls.Add(this.label16);
			this.grpPosGiuridica.Controls.Add(this.txtMatricola);
			this.grpPosGiuridica.Controls.Add(this.txtGruppoEstero);
			this.grpPosGiuridica.Controls.Add(this.txtDecorrClassStip);
			this.grpPosGiuridica.Controls.Add(this.txtClassStip);
			this.grpPosGiuridica.Location = new System.Drawing.Point(24, 274);
			this.grpPosGiuridica.Name = "grpPosGiuridica";
			this.grpPosGiuridica.Size = new System.Drawing.Size(408, 93);
			this.grpPosGiuridica.TabIndex = 100;
			this.grpPosGiuridica.TabStop = false;
			this.grpPosGiuridica.Text = "Posizione giuridica";
			// 
			// txtQualifica
			// 
			this.txtQualifica.Location = new System.Drawing.Point(112, 16);
			this.txtQualifica.Name = "txtQualifica";
			this.txtQualifica.ReadOnly = true;
			this.txtQualifica.Size = new System.Drawing.Size(286, 20);
			this.txtQualifica.TabIndex = 24;
			this.txtQualifica.TabStop = false;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(35, 67);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(77, 23);
			this.label18.TabIndex = 22;
			this.label18.Text = "Gruppo estero:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(206, 40);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(104, 23);
			this.label20.TabIndex = 20;
			this.label20.Text = "Data Decorrenza:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(245, 64);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 23);
			this.label21.TabIndex = 23;
			this.label21.Text = "Matricola:";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(23, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(89, 23);
			this.label15.TabIndex = 17;
			this.label15.Text = "Qualifica:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(8, 40);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(104, 23);
			this.label16.TabIndex = 16;
			this.label16.Text = "Classe stipendiale:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtMatricola
			// 
			this.txtMatricola.Location = new System.Drawing.Point(309, 64);
			this.txtMatricola.Name = "txtMatricola";
			this.txtMatricola.ReadOnly = true;
			this.txtMatricola.Size = new System.Drawing.Size(88, 20);
			this.txtMatricola.TabIndex = 15;
			this.txtMatricola.TabStop = false;
			this.txtMatricola.Tag = "";
			this.txtMatricola.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtGruppoEstero
			// 
			this.txtGruppoEstero.Location = new System.Drawing.Point(112, 67);
			this.txtGruppoEstero.Name = "txtGruppoEstero";
			this.txtGruppoEstero.ReadOnly = true;
			this.txtGruppoEstero.Size = new System.Drawing.Size(88, 20);
			this.txtGruppoEstero.TabIndex = 13;
			this.txtGruppoEstero.TabStop = false;
			this.txtGruppoEstero.Tag = "";
			this.txtGruppoEstero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtDecorrClassStip
			// 
			this.txtDecorrClassStip.Location = new System.Drawing.Point(310, 40);
			this.txtDecorrClassStip.Name = "txtDecorrClassStip";
			this.txtDecorrClassStip.ReadOnly = true;
			this.txtDecorrClassStip.Size = new System.Drawing.Size(88, 20);
			this.txtDecorrClassStip.TabIndex = 9;
			this.txtDecorrClassStip.TabStop = false;
			this.txtDecorrClassStip.Tag = "";
			this.txtDecorrClassStip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtClassStip
			// 
			this.txtClassStip.Location = new System.Drawing.Point(112, 40);
			this.txtClassStip.Name = "txtClassStip";
			this.txtClassStip.ReadOnly = true;
			this.txtClassStip.Size = new System.Drawing.Size(88, 20);
			this.txtClassStip.TabIndex = 1;
			this.txtClassStip.TabStop = false;
			this.txtClassStip.Tag = "";
			this.txtClassStip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label37.Location = new System.Drawing.Point(442, 406);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(455, 46);
			this.label37.TabIndex = 29;
			this.label37.Text = "Attenzione  se  non  viene  spuntato  \"Considera  eseguito  quindi  pagabile\"  si" +
    "  potranno  contabilizzare  solo  gli  anticipi  inerenti  alla  missione";
			// 
			// chkPagabile
			// 
			this.chkPagabile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkPagabile.Location = new System.Drawing.Point(463, 352);
			this.chkPagabile.Name = "chkPagabile";
			this.chkPagabile.Size = new System.Drawing.Size(248, 24);
			this.chkPagabile.TabIndex = 10;
			this.chkPagabile.Tag = "itineration.completed:S:N";
			this.chkPagabile.Text = "Considera eseguito quindi  pagabile";
			this.chkPagabile.CheckStateChanged += new System.EventHandler(this.chkPagabile_CheckStateChanged);
			// 
			// gboxDate
			// 
			this.gboxDate.Controls.Add(this.label7);
			this.gboxDate.Controls.Add(this.txtDataContabile);
			this.gboxDate.Controls.Add(this.label8);
			this.gboxDate.Controls.Add(this.txtDataAut);
			this.gboxDate.Controls.Add(this.label6);
			this.gboxDate.Controls.Add(this.txtDataFine);
			this.gboxDate.Controls.Add(this.label5);
			this.gboxDate.Controls.Add(this.txtDataInizio);
			this.gboxDate.Location = new System.Drawing.Point(24, 208);
			this.gboxDate.Name = "gboxDate";
			this.gboxDate.Size = new System.Drawing.Size(408, 64);
			this.gboxDate.TabIndex = 8;
			this.gboxDate.TabStop = false;
			this.gboxDate.Text = "Date della Missione";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(216, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 19;
			this.label7.Text = "Data contabile:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(320, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
			this.txtDataContabile.TabIndex = 4;
			this.txtDataContabile.Tag = "itineration.adate";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 40);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 16);
			this.label8.TabIndex = 17;
			this.label8.Text = "Data autorizz.:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataAut
			// 
			this.txtDataAut.Location = new System.Drawing.Point(104, 40);
			this.txtDataAut.Name = "txtDataAut";
			this.txtDataAut.Size = new System.Drawing.Size(80, 20);
			this.txtDataAut.TabIndex = 3;
			this.txtDataAut.Tag = "itineration.authorizationdate";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(216, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 15;
			this.label6.Text = "Data fine:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(320, 16);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(80, 20);
			this.txtDataFine.TabIndex = 2;
			this.txtDataFine.Tag = "itineration.stop";
			this.txtDataFine.Leave += new System.EventHandler(this.txtDataFine_Leave);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Data inizio:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(104, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(80, 20);
			this.txtDataInizio.TabIndex = 1;
			this.txtDataInizio.Tag = "itineration.start";
			this.txtDataInizio.Leave += new System.EventHandler(this.txtDataInizio_Leave);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtEsercmissione);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNummissione);
			this.groupBox1.Location = new System.Drawing.Point(24, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(249, 48);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Missione";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercmissione
			// 
			this.txtEsercmissione.Location = new System.Drawing.Point(65, 19);
			this.txtEsercmissione.Name = "txtEsercmissione";
			this.txtEsercmissione.Size = new System.Drawing.Size(49, 20);
			this.txtEsercmissione.TabIndex = 0;
			this.txtEsercmissione.Tag = "itineration.yitineration.year";
			this.txtEsercmissione.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(117, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNummissione
			// 
			this.txtNummissione.Location = new System.Drawing.Point(171, 19);
			this.txtNummissione.Name = "txtNummissione";
			this.txtNummissione.Size = new System.Drawing.Size(72, 20);
			this.txtNummissione.TabIndex = 1;
			this.txtNummissione.Tag = "itineration.nitineration";
			// 
			// labQuotaEsente
			// 
			this.labQuotaEsente.Location = new System.Drawing.Point(26, 412);
			this.labQuotaEsente.Name = "labQuotaEsente";
			this.labQuotaEsente.Size = new System.Drawing.Size(400, 16);
			this.labQuotaEsente.TabIndex = 27;
			this.labQuotaEsente.Text = "Al rapporto di lavoro selezionato non è applicata la quota esente.";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(779, 71);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 24);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.TabStop = false;
			this.checkBox1.Tag = "itineration.active:S:N";
			this.checkBox1.Text = "Utilizzabile";
			// 
			// btnSituazione
			// 
			this.btnSituazione.Location = new System.Drawing.Point(535, 460);
			this.btnSituazione.Name = "btnSituazione";
			this.btnSituazione.Size = new System.Drawing.Size(80, 23);
			this.btnSituazione.TabIndex = 15;
			this.btnSituazione.TabStop = false;
			this.btnSituazione.Text = "Situazione";
			this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(439, 126);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(409, 70);
			this.txtDescrizione.TabIndex = 7;
			this.txtDescrizione.Tag = "itineration.description";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(442, 103);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 20);
			this.label4.TabIndex = 11;
			this.label4.Text = "Descrizione:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbPrestazione
			// 
			this.cmbPrestazione.DataSource = this.DS.service;
			this.cmbPrestazione.DisplayMember = "description";
			this.cmbPrestazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrestazione.Location = new System.Drawing.Point(135, 378);
			this.cmbPrestazione.Name = "cmbPrestazione";
			this.cmbPrestazione.Size = new System.Drawing.Size(288, 21);
			this.cmbPrestazione.TabIndex = 9;
			this.cmbPrestazione.Tag = "itineration.idser";
			this.cmbPrestazione.ValueMember = "idser";
			// 
			// btnPrestazione
			// 
			this.btnPrestazione.Location = new System.Drawing.Point(23, 378);
			this.btnPrestazione.Name = "btnPrestazione";
			this.btnPrestazione.Size = new System.Drawing.Size(104, 24);
			this.btnPrestazione.TabIndex = 11;
			this.btnPrestazione.TabStop = false;
			this.btnPrestazione.Tag = "choose.service.default";
			this.btnPrestazione.Text = "Prestazione:";
			this.btnPrestazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpIncaricato
			// 
			this.grpIncaricato.Controls.Add(this.txtIncaricato);
			this.grpIncaricato.Location = new System.Drawing.Point(24, 110);
			this.grpIncaricato.Name = "grpIncaricato";
			this.grpIncaricato.Size = new System.Drawing.Size(408, 48);
			this.grpIncaricato.TabIndex = 5;
			this.grpIncaricato.TabStop = false;
			this.grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((human=\'S\') and (active = \'S\') AND (idreg IN(SE" +
	"LECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'S\')  ))";
			this.grpIncaricato.Text = "Percipiente";
			// 
			// txtIncaricato
			// 
			this.txtIncaricato.Location = new System.Drawing.Point(8, 16);
			this.txtIncaricato.Name = "txtIncaricato";
			this.txtIncaricato.Size = new System.Drawing.Size(392, 20);
			this.txtIncaricato.TabIndex = 0;
			this.txtIncaricato.Tag = "registry.title?itinerationview.registry";
			// 
			// btnAggiorna
			// 
			this.btnAggiorna.Location = new System.Drawing.Point(447, 460);
			this.btnAggiorna.Name = "btnAggiorna";
			this.btnAggiorna.Size = new System.Drawing.Size(75, 23);
			this.btnAggiorna.TabIndex = 4;
			this.btnAggiorna.TabStop = false;
			this.btnAggiorna.Text = "Ricalcola";
			this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
			// 
			// tabTappeSpese
			// 
			this.tabTappeSpese.Controls.Add(this.grpTappe);
			this.tabTappeSpese.Location = new System.Drawing.Point(4, 23);
			this.tabTappeSpese.Name = "tabTappeSpese";
			this.tabTappeSpese.Size = new System.Drawing.Size(963, 500);
			this.tabTappeSpese.TabIndex = 2;
			this.tabTappeSpese.Text = "Tappe e spese";
			this.tabTappeSpese.UseVisualStyleBackColor = true;
			// 
			// grpTappe
			// 
			this.grpTappe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpTappe.Controls.Add(this.grpSpeseRendiconto);
			this.grpTappe.Controls.Add(this.grpSpese);
			this.grpTappe.Controls.Add(this.btnDelTappa);
			this.grpTappe.Controls.Add(this.btnEditTappa);
			this.grpTappe.Controls.Add(this.dgrTappe);
			this.grpTappe.Controls.Add(this.btnInsertTappa);
			this.grpTappe.Location = new System.Drawing.Point(8, 3);
			this.grpTappe.Name = "grpTappe";
			this.grpTappe.Size = new System.Drawing.Size(939, 478);
			this.grpTappe.TabIndex = 28;
			this.grpTappe.TabStop = false;
			this.grpTappe.Text = "Tappe";
			// 
			// grpSpeseRendiconto
			// 
			this.grpSpeseRendiconto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpSpeseRendiconto.Controls.Add(this.btnDeleteSpesaSaldo);
			this.grpSpeseRendiconto.Controls.Add(this.btnEditSpesaSaldo);
			this.grpSpeseRendiconto.Controls.Add(this.dataGrid2);
			this.grpSpeseRendiconto.Controls.Add(this.btnInsertSpesaSaldo);
			this.grpSpeseRendiconto.Location = new System.Drawing.Point(480, 191);
			this.grpSpeseRendiconto.Name = "grpSpeseRendiconto";
			this.grpSpeseRendiconto.Size = new System.Drawing.Size(443, 280);
			this.grpSpeseRendiconto.TabIndex = 31;
			this.grpSpeseRendiconto.TabStop = false;
			this.grpSpeseRendiconto.Tag = "";
			this.grpSpeseRendiconto.Text = "Rendiconto Spese";
			// 
			// btnDeleteSpesaSaldo
			// 
			this.btnDeleteSpesaSaldo.Location = new System.Drawing.Point(184, 16);
			this.btnDeleteSpesaSaldo.Name = "btnDeleteSpesaSaldo";
			this.btnDeleteSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteSpesaSaldo.TabIndex = 28;
			this.btnDeleteSpesaSaldo.Tag = "delete";
			this.btnDeleteSpesaSaldo.Text = "Elimina";
			// 
			// btnEditSpesaSaldo
			// 
			this.btnEditSpesaSaldo.Location = new System.Drawing.Point(96, 16);
			this.btnEditSpesaSaldo.Name = "btnEditSpesaSaldo";
			this.btnEditSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnEditSpesaSaldo.TabIndex = 27;
			this.btnEditSpesaSaldo.Tag = "edit.balance";
			this.btnEditSpesaSaldo.Text = "Modifica";
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
			this.dataGrid2.ReadOnly = true;
			this.dataGrid2.Size = new System.Drawing.Size(427, 224);
			this.dataGrid2.TabIndex = 7;
			this.dataGrid2.Tag = "itinerationrefund_balance.balance.balance";
			// 
			// btnInsertSpesaSaldo
			// 
			this.btnInsertSpesaSaldo.Location = new System.Drawing.Point(8, 16);
			this.btnInsertSpesaSaldo.Name = "btnInsertSpesaSaldo";
			this.btnInsertSpesaSaldo.Size = new System.Drawing.Size(75, 23);
			this.btnInsertSpesaSaldo.TabIndex = 26;
			this.btnInsertSpesaSaldo.Tag = "insert.balance";
			this.btnInsertSpesaSaldo.Text = "Inserisci";
			// 
			// grpSpese
			// 
			this.grpSpese.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.grpSpese.Controls.Add(this.btnDelSpesa);
			this.grpSpese.Controls.Add(this.btnEditSpesa);
			this.grpSpese.Controls.Add(this.dgrSpeseTappe);
			this.grpSpese.Controls.Add(this.btnInsertSpesa);
			this.grpSpese.Location = new System.Drawing.Point(8, 190);
			this.grpSpese.Name = "grpSpese";
			this.grpSpese.Size = new System.Drawing.Size(466, 280);
			this.grpSpese.TabIndex = 30;
			this.grpSpese.TabStop = false;
			this.grpSpese.Tag = "";
			this.grpSpese.Text = "Anticipo Richiesto";
			// 
			// btnDelSpesa
			// 
			this.btnDelSpesa.Location = new System.Drawing.Point(184, 16);
			this.btnDelSpesa.Name = "btnDelSpesa";
			this.btnDelSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnDelSpesa.TabIndex = 28;
			this.btnDelSpesa.Tag = "delete";
			this.btnDelSpesa.Text = "Elimina";
			// 
			// btnEditSpesa
			// 
			this.btnEditSpesa.Location = new System.Drawing.Point(96, 16);
			this.btnEditSpesa.Name = "btnEditSpesa";
			this.btnEditSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnEditSpesa.TabIndex = 27;
			this.btnEditSpesa.Tag = "edit.advance";
			this.btnEditSpesa.Text = "Modifica";
			// 
			// dgrSpeseTappe
			// 
			this.dgrSpeseTappe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrSpeseTappe.DataMember = "";
			this.dgrSpeseTappe.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrSpeseTappe.Location = new System.Drawing.Point(8, 48);
			this.dgrSpeseTappe.Name = "dgrSpeseTappe";
			this.dgrSpeseTappe.ReadOnly = true;
			this.dgrSpeseTappe.Size = new System.Drawing.Size(450, 224);
			this.dgrSpeseTappe.TabIndex = 7;
			this.dgrSpeseTappe.Tag = "itinerationrefund_advance.advance.advance";
			// 
			// btnInsertSpesa
			// 
			this.btnInsertSpesa.Location = new System.Drawing.Point(8, 16);
			this.btnInsertSpesa.Name = "btnInsertSpesa";
			this.btnInsertSpesa.Size = new System.Drawing.Size(75, 23);
			this.btnInsertSpesa.TabIndex = 26;
			this.btnInsertSpesa.Tag = "insert.advance";
			this.btnInsertSpesa.Text = "Inserisci";
			// 
			// btnDelTappa
			// 
			this.btnDelTappa.Location = new System.Drawing.Point(184, 16);
			this.btnDelTappa.Name = "btnDelTappa";
			this.btnDelTappa.Size = new System.Drawing.Size(75, 23);
			this.btnDelTappa.TabIndex = 28;
			this.btnDelTappa.Tag = "delete";
			this.btnDelTappa.Text = "Cancella";
			// 
			// btnEditTappa
			// 
			this.btnEditTappa.Location = new System.Drawing.Point(96, 16);
			this.btnEditTappa.Name = "btnEditTappa";
			this.btnEditTappa.Size = new System.Drawing.Size(75, 23);
			this.btnEditTappa.TabIndex = 27;
			this.btnEditTappa.Tag = "edit.default";
			this.btnEditTappa.Text = "Modifica";
			// 
			// dgrTappe
			// 
			this.dgrTappe.AllowNavigation = false;
			this.dgrTappe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrTappe.DataMember = "";
			this.dgrTappe.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrTappe.Location = new System.Drawing.Point(8, 48);
			this.dgrTappe.Name = "dgrTappe";
			this.dgrTappe.Size = new System.Drawing.Size(915, 136);
			this.dgrTappe.TabIndex = 7;
			this.dgrTappe.Tag = "itinerationlap.default.default";
			// 
			// btnInsertTappa
			// 
			this.btnInsertTappa.Location = new System.Drawing.Point(8, 16);
			this.btnInsertTappa.Name = "btnInsertTappa";
			this.btnInsertTappa.Size = new System.Drawing.Size(75, 23);
			this.btnInsertTappa.TabIndex = 26;
			this.btnInsertTappa.Tag = "insert.default";
			this.btnInsertTappa.Text = "Inserisci";
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.txtHelpCoeffLord);
			this.tabRitenute.Controls.Add(this.label33);
			this.tabRitenute.Controls.Add(this.dataGrid1);
			this.tabRitenute.Controls.Add(this.gboxRitDipendente);
			this.tabRitenute.Controls.Add(this.gboxContrEnte);
			this.tabRitenute.Controls.Add(this.label32);
			this.tabRitenute.Controls.Add(this.txtCoeffLord);
			this.tabRitenute.Location = new System.Drawing.Point(4, 23);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(963, 500);
			this.tabRitenute.TabIndex = 5;
			this.tabRitenute.Text = "Ritenute";
			this.tabRitenute.UseVisualStyleBackColor = true;
			// 
			// txtHelpCoeffLord
			// 
			this.txtHelpCoeffLord.Location = new System.Drawing.Point(129, 24);
			this.txtHelpCoeffLord.Multiline = true;
			this.txtHelpCoeffLord.Name = "txtHelpCoeffLord";
			this.txtHelpCoeffLord.ReadOnly = true;
			this.txtHelpCoeffLord.Size = new System.Drawing.Size(350, 20);
			this.txtHelpCoeffLord.TabIndex = 26;
			this.txtHelpCoeffLord.TabStop = false;
			this.txtHelpCoeffLord.Text = "1 / (1 - (1 - TotAliAssDip - TotAliPreDip) * TotAliFisDip)";
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(129, 5);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(136, 16);
			this.label33.TabIndex = 27;
			this.label33.Text = "Formula del coeff. di lord.";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 168);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(939, 318);
			this.dataGrid1.TabIndex = 63;
			this.dataGrid1.Tag = "itinerationtax.default";
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
			this.gboxRitDipendente.Location = new System.Drawing.Point(8, 44);
			this.gboxRitDipendente.Name = "gboxRitDipendente";
			this.gboxRitDipendente.Size = new System.Drawing.Size(624, 56);
			this.gboxRitDipendente.TabIndex = 61;
			this.gboxRitDipendente.TabStop = false;
			this.gboxRitDipendente.Text = "Ritenute c/dipendente";
			// 
			// txtAssicurativeDip
			// 
			this.txtAssicurativeDip.Location = new System.Drawing.Point(272, 28);
			this.txtAssicurativeDip.Name = "txtAssicurativeDip";
			this.txtAssicurativeDip.ReadOnly = true;
			this.txtAssicurativeDip.Size = new System.Drawing.Size(88, 20);
			this.txtAssicurativeDip.TabIndex = 4;
			this.txtAssicurativeDip.TabStop = false;
			this.txtAssicurativeDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(288, 12);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(72, 13);
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
			this.txtImportonettoDip.TabStop = false;
			this.txtImportonettoDip.Tag = "itineration.netfee";
			this.txtImportonettoDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label42
			// 
			this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label42.Location = new System.Drawing.Point(504, 12);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(88, 13);
			this.label42.TabIndex = 16;
			this.label42.Text = "Importo netto:";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAltreDip
			// 
			this.txtAltreDip.Location = new System.Drawing.Point(360, 28);
			this.txtAltreDip.Name = "txtAltreDip";
			this.txtAltreDip.ReadOnly = true;
			this.txtAltreDip.Size = new System.Drawing.Size(88, 20);
			this.txtAltreDip.TabIndex = 5;
			this.txtAltreDip.TabStop = false;
			this.txtAltreDip.Tag = "";
			this.txtAltreDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(376, 12);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(40, 13);
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
			this.txtFiscaliDip.TabStop = false;
			this.txtFiscaliDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(200, 12);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(48, 13);
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
			this.txtPrevidenzialiDip.TabStop = false;
			this.txtPrevidenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(104, 12);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(80, 13);
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
			this.txtAssistenzialiDip.TabStop = false;
			this.txtAssistenzialiDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(16, 12);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(72, 13);
			this.label46.TabIndex = 8;
			this.label46.Text = "Assistenziali:";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxContrEnte
			// 
			this.gboxContrEnte.Controls.Add(this.txtFiscaliEnte);
			this.gboxContrEnte.Controls.Add(this.txtAssicurativeEnte);
			this.gboxContrEnte.Controls.Add(this.label47);
			this.gboxContrEnte.Controls.Add(this.txtCostoTotaleEnte);
			this.gboxContrEnte.Controls.Add(this.label48);
			this.gboxContrEnte.Controls.Add(this.txtAltreEnte);
			this.gboxContrEnte.Controls.Add(this.label49);
			this.gboxContrEnte.Controls.Add(this.txtPrevidenzialiEnte);
			this.gboxContrEnte.Controls.Add(this.label50);
			this.gboxContrEnte.Controls.Add(this.txtAssistenzialiEnte);
			this.gboxContrEnte.Controls.Add(this.label51);
			this.gboxContrEnte.Controls.Add(this.label36);
			this.gboxContrEnte.Location = new System.Drawing.Point(8, 106);
			this.gboxContrEnte.Name = "gboxContrEnte";
			this.gboxContrEnte.Size = new System.Drawing.Size(624, 56);
			this.gboxContrEnte.TabIndex = 62;
			this.gboxContrEnte.TabStop = false;
			this.gboxContrEnte.Text = "Contributi c/amministrazione";
			// 
			// txtFiscaliEnte
			// 
			this.txtFiscaliEnte.Location = new System.Drawing.Point(184, 28);
			this.txtFiscaliEnte.Name = "txtFiscaliEnte";
			this.txtFiscaliEnte.ReadOnly = true;
			this.txtFiscaliEnte.Size = new System.Drawing.Size(88, 20);
			this.txtFiscaliEnte.TabIndex = 17;
			this.txtFiscaliEnte.TabStop = false;
			this.txtFiscaliEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAssicurativeEnte
			// 
			this.txtAssicurativeEnte.Location = new System.Drawing.Point(272, 28);
			this.txtAssicurativeEnte.Name = "txtAssicurativeEnte";
			this.txtAssicurativeEnte.ReadOnly = true;
			this.txtAssicurativeEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAssicurativeEnte.TabIndex = 3;
			this.txtAssicurativeEnte.TabStop = false;
			this.txtAssicurativeEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(288, 12);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(72, 13);
			this.label47.TabIndex = 16;
			this.label47.Text = "Assicurativi:";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCostoTotaleEnte
			// 
			this.txtCostoTotaleEnte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostoTotaleEnte.Location = new System.Drawing.Point(504, 28);
			this.txtCostoTotaleEnte.Name = "txtCostoTotaleEnte";
			this.txtCostoTotaleEnte.ReadOnly = true;
			this.txtCostoTotaleEnte.Size = new System.Drawing.Size(104, 21);
			this.txtCostoTotaleEnte.TabIndex = 5;
			this.txtCostoTotaleEnte.TabStop = false;
			this.txtCostoTotaleEnte.Tag = "itineration.total";
			this.txtCostoTotaleEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label48
			// 
			this.label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label48.Location = new System.Drawing.Point(504, 7);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(88, 18);
			this.label48.TabIndex = 14;
			this.label48.Text = "Costo totale:";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAltreEnte
			// 
			this.txtAltreEnte.Location = new System.Drawing.Point(360, 28);
			this.txtAltreEnte.Name = "txtAltreEnte";
			this.txtAltreEnte.ReadOnly = true;
			this.txtAltreEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAltreEnte.TabIndex = 4;
			this.txtAltreEnte.TabStop = false;
			this.txtAltreEnte.Tag = "";
			this.txtAltreEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(384, 12);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(32, 13);
			this.label49.TabIndex = 12;
			this.label49.Text = "Altri:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevidenzialiEnte
			// 
			this.txtPrevidenzialiEnte.Location = new System.Drawing.Point(96, 28);
			this.txtPrevidenzialiEnte.Name = "txtPrevidenzialiEnte";
			this.txtPrevidenzialiEnte.ReadOnly = true;
			this.txtPrevidenzialiEnte.Size = new System.Drawing.Size(88, 20);
			this.txtPrevidenzialiEnte.TabIndex = 2;
			this.txtPrevidenzialiEnte.TabStop = false;
			this.txtPrevidenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(104, 12);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(72, 13);
			this.label50.TabIndex = 10;
			this.label50.Text = "Previdenziali:";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAssistenzialiEnte
			// 
			this.txtAssistenzialiEnte.Location = new System.Drawing.Point(8, 28);
			this.txtAssistenzialiEnte.Name = "txtAssistenzialiEnte";
			this.txtAssistenzialiEnte.ReadOnly = true;
			this.txtAssistenzialiEnte.Size = new System.Drawing.Size(88, 20);
			this.txtAssistenzialiEnte.TabIndex = 1;
			this.txtAssistenzialiEnte.TabStop = false;
			this.txtAssistenzialiEnte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(16, 12);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(72, 13);
			this.label51.TabIndex = 8;
			this.label51.Text = "Assistenziali:";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(208, 12);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(48, 13);
			this.label36.TabIndex = 18;
			this.label36.Text = "Fiscali:";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(3, 5);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(120, 16);
			this.label32.TabIndex = 25;
			this.label32.Text = "Coeff. di lordizzazione";
			// 
			// txtCoeffLord
			// 
			this.txtCoeffLord.Location = new System.Drawing.Point(5, 24);
			this.txtCoeffLord.Name = "txtCoeffLord";
			this.txtCoeffLord.ReadOnly = true;
			this.txtCoeffLord.Size = new System.Drawing.Size(96, 20);
			this.txtCoeffLord.TabIndex = 24;
			this.txtCoeffLord.TabStop = false;
			this.txtCoeffLord.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabIndKm
			// 
			this.tabIndKm.Controls.Add(this.label38);
			this.tabIndKm.Controls.Add(this.txtDatiMezzoProprio);
			this.tabIndKm.Controls.Add(this.label34);
			this.tabIndKm.Controls.Add(this.txtCausaleMezzoProprio);
			this.tabIndKm.Controls.Add(this.txtClause);
			this.tabIndKm.Controls.Add(this.chkClauseMezzoProprio);
			this.tabIndKm.Controls.Add(this.label35);
			this.tabIndKm.Controls.Add(this.textBox4);
			this.tabIndKm.Controls.Add(this.grpIndMezzoAmm);
			this.tabIndKm.Controls.Add(this.grpIndMezzoProprio);
			this.tabIndKm.Controls.Add(this.grpIndAPiedi);
			this.tabIndKm.Location = new System.Drawing.Point(4, 23);
			this.tabIndKm.Name = "tabIndKm";
			this.tabIndKm.Size = new System.Drawing.Size(963, 500);
			this.tabIndKm.TabIndex = 4;
			this.tabIndKm.Text = "Ind. km";
			this.tabIndKm.UseVisualStyleBackColor = true;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(5, 397);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(138, 13);
			this.label38.TabIndex = 10;
			this.label38.Text = "Dati identificativi del veicolo";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDatiMezzoProprio
			// 
			this.txtDatiMezzoProprio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDatiMezzoProprio.Location = new System.Drawing.Point(8, 413);
			this.txtDatiMezzoProprio.Multiline = true;
			this.txtDatiMezzoProprio.Name = "txtDatiMezzoProprio";
			this.txtDatiMezzoProprio.Size = new System.Drawing.Size(947, 52);
			this.txtDatiMezzoProprio.TabIndex = 8;
			this.txtDatiMezzoProprio.Tag = "itineration.vehicle_info";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(5, 273);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(45, 13);
			this.label34.TabIndex = 9;
			this.label34.Text = "Causale";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCausaleMezzoProprio
			// 
			this.txtCausaleMezzoProprio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausaleMezzoProprio.Location = new System.Drawing.Point(8, 289);
			this.txtCausaleMezzoProprio.Multiline = true;
			this.txtCausaleMezzoProprio.Name = "txtCausaleMezzoProprio";
			this.txtCausaleMezzoProprio.Size = new System.Drawing.Size(947, 88);
			this.txtCausaleMezzoProprio.TabIndex = 7;
			this.txtCausaleMezzoProprio.Tag = "itineration.vehicle_motive";
			// 
			// txtClause
			// 
			this.txtClause.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtClause.Location = new System.Drawing.Point(8, 154);
			this.txtClause.Multiline = true;
			this.txtClause.Name = "txtClause";
			this.txtClause.ReadOnly = true;
			this.txtClause.Size = new System.Drawing.Size(947, 88);
			this.txtClause.TabIndex = 7;
			// 
			// chkClauseMezzoProprio
			// 
			this.chkClauseMezzoProprio.AutoSize = true;
			this.chkClauseMezzoProprio.Location = new System.Drawing.Point(8, 253);
			this.chkClauseMezzoProprio.Name = "chkClauseMezzoProprio";
			this.chkClauseMezzoProprio.Size = new System.Drawing.Size(116, 17);
			this.chkClauseMezzoProprio.TabIndex = 6;
			this.chkClauseMezzoProprio.Tag = "itineration.clause_accepted:S:N";
			this.chkClauseMezzoProprio.Text = "Accetto la clausola";
			this.chkClauseMezzoProprio.UseVisualStyleBackColor = true;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(600, 80);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(112, 23);
			this.label35.TabIndex = 5;
			this.label35.Text = "Formula di EUR tot.";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(600, 104);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(112, 32);
			this.textBox4.TabIndex = 4;
			this.textBox4.Text = "Km. percorsi * EUR/Km.";
			// 
			// grpIndMezzoAmm
			// 
			this.grpIndMezzoAmm.Controls.Add(this.panel2);
			this.grpIndMezzoAmm.Controls.Add(this.txtEurTotMezzoAmm);
			this.grpIndMezzoAmm.Controls.Add(this.label26);
			this.grpIndMezzoAmm.Controls.Add(this.txtKmMezzoAmm);
			this.grpIndMezzoAmm.Controls.Add(this.label27);
			this.grpIndMezzoAmm.Controls.Add(this.txtEurKmMezzoAmm);
			this.grpIndMezzoAmm.Controls.Add(this.label28);
			this.grpIndMezzoAmm.Location = new System.Drawing.Point(200, 8);
			this.grpIndMezzoAmm.Name = "grpIndMezzoAmm";
			this.grpIndMezzoAmm.Size = new System.Drawing.Size(192, 128);
			this.grpIndMezzoAmm.TabIndex = 1;
			this.grpIndMezzoAmm.TabStop = false;
			this.grpIndMezzoAmm.Text = "Mezzo amministrazione";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(8, 80);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(170, 2);
			this.panel2.TabIndex = 7;
			// 
			// txtEurTotMezzoAmm
			// 
			this.txtEurTotMezzoAmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEurTotMezzoAmm.Location = new System.Drawing.Point(96, 96);
			this.txtEurTotMezzoAmm.Name = "txtEurTotMezzoAmm";
			this.txtEurTotMezzoAmm.ReadOnly = true;
			this.txtEurTotMezzoAmm.Size = new System.Drawing.Size(88, 20);
			this.txtEurTotMezzoAmm.TabIndex = 5;
			this.txtEurTotMezzoAmm.TabStop = false;
			this.txtEurTotMezzoAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label26
			// 
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label26.Location = new System.Drawing.Point(16, 96);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(64, 23);
			this.label26.TabIndex = 4;
			this.label26.Text = "EUR tot.";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtKmMezzoAmm
			// 
			this.txtKmMezzoAmm.Location = new System.Drawing.Point(96, 16);
			this.txtKmMezzoAmm.Name = "txtKmMezzoAmm";
			this.txtKmMezzoAmm.Size = new System.Drawing.Size(88, 20);
			this.txtKmMezzoAmm.TabIndex = 1;
			this.txtKmMezzoAmm.Tag = "itineration.admincarkm";
			this.txtKmMezzoAmm.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(8, 16);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(72, 23);
			this.label27.TabIndex = 0;
			this.label27.Text = "Km. percorsi";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEurKmMezzoAmm
			// 
			this.txtEurKmMezzoAmm.Location = new System.Drawing.Point(96, 48);
			this.txtEurKmMezzoAmm.Name = "txtEurKmMezzoAmm";
			this.txtEurKmMezzoAmm.Size = new System.Drawing.Size(88, 20);
			this.txtEurKmMezzoAmm.TabIndex = 2;
			this.txtEurKmMezzoAmm.Tag = "itineration.admincarkmcost.fixed.5...1";
			this.txtEurKmMezzoAmm.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(16, 48);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(64, 23);
			this.label28.TabIndex = 2;
			this.label28.Text = "EUR/Km.";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpIndMezzoProprio
			// 
			this.grpIndMezzoProprio.Controls.Add(this.panel1);
			this.grpIndMezzoProprio.Controls.Add(this.txtEurTotMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label25);
			this.grpIndMezzoProprio.Controls.Add(this.txtKmMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label23);
			this.grpIndMezzoProprio.Controls.Add(this.txtEurKmMezzoProprio);
			this.grpIndMezzoProprio.Controls.Add(this.label24);
			this.grpIndMezzoProprio.Location = new System.Drawing.Point(8, 8);
			this.grpIndMezzoProprio.Name = "grpIndMezzoProprio";
			this.grpIndMezzoProprio.Size = new System.Drawing.Size(184, 128);
			this.grpIndMezzoProprio.TabIndex = 0;
			this.grpIndMezzoProprio.TabStop = false;
			this.grpIndMezzoProprio.Text = "Mezzo proprio";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(8, 80);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(170, 2);
			this.panel1.TabIndex = 6;
			// 
			// txtEurTotMezzoProprio
			// 
			this.txtEurTotMezzoProprio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEurTotMezzoProprio.Location = new System.Drawing.Point(88, 96);
			this.txtEurTotMezzoProprio.Name = "txtEurTotMezzoProprio";
			this.txtEurTotMezzoProprio.ReadOnly = true;
			this.txtEurTotMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtEurTotMezzoProprio.TabIndex = 5;
			this.txtEurTotMezzoProprio.TabStop = false;
			this.txtEurTotMezzoProprio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(8, 96);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(72, 23);
			this.label25.TabIndex = 4;
			this.label25.Text = "EUR tot.";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtKmMezzoProprio
			// 
			this.txtKmMezzoProprio.Location = new System.Drawing.Point(88, 16);
			this.txtKmMezzoProprio.Name = "txtKmMezzoProprio";
			this.txtKmMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtKmMezzoProprio.TabIndex = 1;
			this.txtKmMezzoProprio.Tag = "itineration.owncarkm";
			this.txtKmMezzoProprio.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 16);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(72, 23);
			this.label23.TabIndex = 0;
			this.label23.Text = "Km. percorsi";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEurKmMezzoProprio
			// 
			this.txtEurKmMezzoProprio.Location = new System.Drawing.Point(88, 48);
			this.txtEurKmMezzoProprio.Name = "txtEurKmMezzoProprio";
			this.txtEurKmMezzoProprio.Size = new System.Drawing.Size(88, 20);
			this.txtEurKmMezzoProprio.TabIndex = 2;
			this.txtEurKmMezzoProprio.Tag = "itineration.owncarkmcost.fixed.5...1";
			this.txtEurKmMezzoProprio.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(8, 48);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(72, 23);
			this.label24.TabIndex = 2;
			this.label24.Text = "EUR/Km.";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpIndAPiedi
			// 
			this.grpIndAPiedi.Controls.Add(this.panel3);
			this.grpIndAPiedi.Controls.Add(this.txtEurTotAPiedi);
			this.grpIndAPiedi.Controls.Add(this.label29);
			this.grpIndAPiedi.Controls.Add(this.txtKmAPiedi);
			this.grpIndAPiedi.Controls.Add(this.label30);
			this.grpIndAPiedi.Controls.Add(this.txtEurKmAPiedi);
			this.grpIndAPiedi.Controls.Add(this.label31);
			this.grpIndAPiedi.Location = new System.Drawing.Point(400, 8);
			this.grpIndAPiedi.Name = "grpIndAPiedi";
			this.grpIndAPiedi.Size = new System.Drawing.Size(192, 128);
			this.grpIndAPiedi.TabIndex = 2;
			this.grpIndAPiedi.TabStop = false;
			this.grpIndAPiedi.Text = "A piedi";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(8, 80);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(170, 2);
			this.panel3.TabIndex = 7;
			// 
			// txtEurTotAPiedi
			// 
			this.txtEurTotAPiedi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEurTotAPiedi.Location = new System.Drawing.Point(96, 96);
			this.txtEurTotAPiedi.Name = "txtEurTotAPiedi";
			this.txtEurTotAPiedi.ReadOnly = true;
			this.txtEurTotAPiedi.Size = new System.Drawing.Size(88, 20);
			this.txtEurTotAPiedi.TabIndex = 5;
			this.txtEurTotAPiedi.TabStop = false;
			this.txtEurTotAPiedi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label29
			// 
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label29.Location = new System.Drawing.Point(8, 96);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(72, 23);
			this.label29.TabIndex = 4;
			this.label29.Text = "EUR tot.";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtKmAPiedi
			// 
			this.txtKmAPiedi.Location = new System.Drawing.Point(96, 16);
			this.txtKmAPiedi.Name = "txtKmAPiedi";
			this.txtKmAPiedi.Size = new System.Drawing.Size(88, 20);
			this.txtKmAPiedi.TabIndex = 1;
			this.txtKmAPiedi.Tag = "itineration.footkm";
			this.txtKmAPiedi.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(8, 16);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(72, 23);
			this.label30.TabIndex = 0;
			this.label30.Text = "Km. percorsi";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEurKmAPiedi
			// 
			this.txtEurKmAPiedi.Location = new System.Drawing.Point(96, 48);
			this.txtEurKmAPiedi.Name = "txtEurKmAPiedi";
			this.txtEurKmAPiedi.Size = new System.Drawing.Size(88, 20);
			this.txtEurKmAPiedi.TabIndex = 2;
			this.txtEurKmAPiedi.Tag = "itineration.footkmcost.fixed.5...1";
			this.txtEurKmAPiedi.TextChanged += new System.EventHandler(this.txtKmMezzoProprio_TextChanged);
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(8, 48);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(72, 23);
			this.label31.TabIndex = 2;
			this.label31.Text = "EUR/Km.";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabClassSuppl
			// 
			this.tabClassSuppl.Controls.Add(this.dgrClassSuppl);
			this.tabClassSuppl.Controls.Add(this.btnClassElimina);
			this.tabClassSuppl.Controls.Add(this.btnClassModifica);
			this.tabClassSuppl.Controls.Add(this.btnClassInserisci);
			this.tabClassSuppl.ImageIndex = 0;
			this.tabClassSuppl.Location = new System.Drawing.Point(4, 23);
			this.tabClassSuppl.Name = "tabClassSuppl";
			this.tabClassSuppl.Size = new System.Drawing.Size(963, 500);
			this.tabClassSuppl.TabIndex = 7;
			this.tabClassSuppl.Text = "Classificazione";
			this.tabClassSuppl.UseVisualStyleBackColor = true;
			// 
			// dgrClassSuppl
			// 
			this.dgrClassSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassSuppl.DataMember = "";
			this.dgrClassSuppl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassSuppl.Location = new System.Drawing.Point(16, 48);
			this.dgrClassSuppl.Name = "dgrClassSuppl";
			this.dgrClassSuppl.ReadOnly = true;
			this.dgrClassSuppl.Size = new System.Drawing.Size(939, 438);
			this.dgrClassSuppl.TabIndex = 19;
			this.dgrClassSuppl.Tag = "itinerationsorting.default.default";
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(184, 16);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(68, 22);
			this.btnClassElimina.TabIndex = 18;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(104, 16);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(69, 22);
			this.btnClassModifica.TabIndex = 17;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica...";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(24, 16);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnClassInserisci.TabIndex = 16;
			this.btnClassInserisci.Tag = "insert.default";
			this.btnClassInserisci.Text = "Inserisci...";
			// 
			// tabCalcolo
			// 
			this.tabCalcolo.Controls.Add(this.textBox16);
			this.tabCalcolo.Controls.Add(this.txtSpeseSaldo);
			this.tabCalcolo.Controls.Add(this.labelSpeseSaldo);
			this.tabCalcolo.Controls.Add(this.textBox14);
			this.tabCalcolo.Controls.Add(this.txtSpeseAnticipo);
			this.tabCalcolo.Controls.Add(this.labelSpeseAnticipo);
			this.tabCalcolo.Controls.Add(this.txtLordo);
			this.tabCalcolo.Controls.Add(this.labelImpLord);
			this.tabCalcolo.Controls.Add(this.groupBox5);
			this.tabCalcolo.Controls.Add(this.groupBox4);
			this.tabCalcolo.Controls.Add(this.btnToExcel);
			this.tabCalcolo.Controls.Add(this.textBox10);
			this.tabCalcolo.Controls.Add(this.textBox8);
			this.tabCalcolo.Controls.Add(this.textBox7);
			this.tabCalcolo.Controls.Add(this.textBox3);
			this.tabCalcolo.Controls.Add(this.textBox2);
			this.tabCalcolo.Controls.Add(this.textBox1);
			this.tabCalcolo.Controls.Add(this.txtQuotaImponibileTappa);
			this.tabCalcolo.Controls.Add(this.labelQuotaImponibile);
			this.tabCalcolo.Controls.Add(this.txtQuotaEsenteMissione);
			this.tabCalcolo.Controls.Add(this.labelQuotaEsente);
			this.tabCalcolo.Controls.Add(this.txtImportoAnticipo);
			this.tabCalcolo.Controls.Add(this.txtComplessivo);
			this.tabCalcolo.Controls.Add(this.labelImpAnticipo);
			this.tabCalcolo.Controls.Add(this.labelImpCompl);
			this.tabCalcolo.Controls.Add(this.txtSpeseSostenute);
			this.tabCalcolo.Controls.Add(this.labelSpeseSost);
			this.tabCalcolo.Location = new System.Drawing.Point(4, 23);
			this.tabCalcolo.Name = "tabCalcolo";
			this.tabCalcolo.Size = new System.Drawing.Size(963, 500);
			this.tabCalcolo.TabIndex = 6;
			this.tabCalcolo.Text = "Riepilogo";
			this.tabCalcolo.UseVisualStyleBackColor = true;
			// 
			// textBox16
			// 
			this.textBox16.Location = new System.Drawing.Point(385, 37);
			this.textBox16.Name = "textBox16";
			this.textBox16.ReadOnly = true;
			this.textBox16.Size = new System.Drawing.Size(310, 20);
			this.textBox16.TabIndex = 6;
			this.textBox16.TabStop = false;
			this.textBox16.Text = "Somma degli importi effettivi di ogni spesa rendicontata";
			// 
			// txtSpeseSaldo
			// 
			this.txtSpeseSaldo.Location = new System.Drawing.Point(233, 37);
			this.txtSpeseSaldo.Name = "txtSpeseSaldo";
			this.txtSpeseSaldo.ReadOnly = true;
			this.txtSpeseSaldo.Size = new System.Drawing.Size(136, 20);
			this.txtSpeseSaldo.TabIndex = 5;
			this.txtSpeseSaldo.TabStop = false;
			this.txtSpeseSaldo.Tag = "";
			this.txtSpeseSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelSpeseSaldo
			// 
			this.labelSpeseSaldo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelSpeseSaldo.Location = new System.Drawing.Point(61, 35);
			this.labelSpeseSaldo.Name = "labelSpeseSaldo";
			this.labelSpeseSaldo.Size = new System.Drawing.Size(168, 23);
			this.labelSpeseSaldo.TabIndex = 4;
			this.labelSpeseSaldo.Text = "Totale spese sostenute:";
			this.labelSpeseSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox14
			// 
			this.textBox14.Location = new System.Drawing.Point(385, 11);
			this.textBox14.Name = "textBox14";
			this.textBox14.ReadOnly = true;
			this.textBox14.Size = new System.Drawing.Size(310, 20);
			this.textBox14.TabIndex = 3;
			this.textBox14.TabStop = false;
			this.textBox14.Text = "Somma degli importi effettivi di ogni spesa su anticipo richiesto";
			// 
			// txtSpeseAnticipo
			// 
			this.txtSpeseAnticipo.Location = new System.Drawing.Point(233, 11);
			this.txtSpeseAnticipo.Name = "txtSpeseAnticipo";
			this.txtSpeseAnticipo.ReadOnly = true;
			this.txtSpeseAnticipo.Size = new System.Drawing.Size(136, 20);
			this.txtSpeseAnticipo.TabIndex = 2;
			this.txtSpeseAnticipo.TabStop = false;
			this.txtSpeseAnticipo.Tag = "";
			this.txtSpeseAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelSpeseAnticipo
			// 
			this.labelSpeseAnticipo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelSpeseAnticipo.Location = new System.Drawing.Point(3, 11);
			this.labelSpeseAnticipo.Name = "labelSpeseAnticipo";
			this.labelSpeseAnticipo.Size = new System.Drawing.Size(226, 24);
			this.labelSpeseAnticipo.TabIndex = 1;
			this.labelSpeseAnticipo.Text = "Totale spese preventivate in fase di anticipo:";
			this.labelSpeseAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLordo
			// 
			this.txtLordo.Location = new System.Drawing.Point(231, 255);
			this.txtLordo.Name = "txtLordo";
			this.txtLordo.ReadOnly = true;
			this.txtLordo.Size = new System.Drawing.Size(136, 20);
			this.txtLordo.TabIndex = 13;
			this.txtLordo.TabStop = false;
			this.txtLordo.Tag = "itineration.totalgross";
			this.txtLordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelImpLord
			// 
			this.labelImpLord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImpLord.Location = new System.Drawing.Point(91, 252);
			this.labelImpLord.Name = "labelImpLord";
			this.labelImpLord.Size = new System.Drawing.Size(132, 23);
			this.labelImpLord.TabIndex = 12;
			this.labelImpLord.Text = "Importo lordo";
			this.labelImpLord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.txtPrevAmministrazione);
			this.groupBox5.Controls.Add(this.txtAssAmministrazione);
			this.groupBox5.Controls.Add(this.labelRitPrevAmm);
			this.groupBox5.Controls.Add(this.labelRitAssAmm);
			this.groupBox5.Location = new System.Drawing.Point(8, 277);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(396, 48);
			this.groupBox5.TabIndex = 15;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Contributi";
			// 
			// txtPrevAmministrazione
			// 
			this.txtPrevAmministrazione.Location = new System.Drawing.Point(276, 16);
			this.txtPrevAmministrazione.Name = "txtPrevAmministrazione";
			this.txtPrevAmministrazione.ReadOnly = true;
			this.txtPrevAmministrazione.Size = new System.Drawing.Size(96, 20);
			this.txtPrevAmministrazione.TabIndex = 21;
			this.txtPrevAmministrazione.TabStop = false;
			this.txtPrevAmministrazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAssAmministrazione
			// 
			this.txtAssAmministrazione.Location = new System.Drawing.Point(88, 16);
			this.txtAssAmministrazione.Name = "txtAssAmministrazione";
			this.txtAssAmministrazione.ReadOnly = true;
			this.txtAssAmministrazione.Size = new System.Drawing.Size(96, 20);
			this.txtAssAmministrazione.TabIndex = 20;
			this.txtAssAmministrazione.TabStop = false;
			this.txtAssAmministrazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelRitPrevAmm
			// 
			this.labelRitPrevAmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRitPrevAmm.Location = new System.Drawing.Point(188, 16);
			this.labelRitPrevAmm.Name = "labelRitPrevAmm";
			this.labelRitPrevAmm.Size = new System.Drawing.Size(83, 23);
			this.labelRitPrevAmm.TabIndex = 19;
			this.labelRitPrevAmm.Text = "Previdenziali";
			this.labelRitPrevAmm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelRitAssAmm
			// 
			this.labelRitAssAmm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelRitAssAmm.Location = new System.Drawing.Point(4, 16);
			this.labelRitAssAmm.Name = "labelRitAssAmm";
			this.labelRitAssAmm.Size = new System.Drawing.Size(78, 23);
			this.labelRitAssAmm.TabIndex = 18;
			this.labelRitAssAmm.Text = "Assicurativi";
			this.labelRitAssAmm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.txtTotLordEst);
			this.groupBox4.Controls.Add(this.labelIndLordEst);
			this.groupBox4.Controls.Add(this.txtTotLordIt);
			this.groupBox4.Controls.Add(this.labelIndLordIt);
			this.groupBox4.Controls.Add(this.txtTotIndennKm);
			this.groupBox4.Controls.Add(this.labeIndKm);
			this.groupBox4.Controls.Add(this.txtIndSupplementare);
			this.groupBox4.Controls.Add(this.labelIndSuppl);
			this.groupBox4.Location = new System.Drawing.Point(8, 95);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(369, 152);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Indennità";
			// 
			// txtTotLordEst
			// 
			this.txtTotLordEst.Location = new System.Drawing.Point(223, 112);
			this.txtTotLordEst.Name = "txtTotLordEst";
			this.txtTotLordEst.ReadOnly = true;
			this.txtTotLordEst.Size = new System.Drawing.Size(136, 20);
			this.txtTotLordEst.TabIndex = 19;
			this.txtTotLordEst.TabStop = false;
			this.txtTotLordEst.Tag = "";
			this.txtTotLordEst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelIndLordEst
			// 
			this.labelIndLordEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelIndLordEst.Location = new System.Drawing.Point(83, 112);
			this.labelIndLordEst.Name = "labelIndLordEst";
			this.labelIndLordEst.Size = new System.Drawing.Size(132, 23);
			this.labelIndLordEst.TabIndex = 18;
			this.labelIndLordEst.Text = "Lorda di trasferta Estero";
			this.labelIndLordEst.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotLordIt
			// 
			this.txtTotLordIt.Location = new System.Drawing.Point(223, 80);
			this.txtTotLordIt.Name = "txtTotLordIt";
			this.txtTotLordIt.ReadOnly = true;
			this.txtTotLordIt.Size = new System.Drawing.Size(136, 20);
			this.txtTotLordIt.TabIndex = 17;
			this.txtTotLordIt.TabStop = false;
			this.txtTotLordIt.Tag = "";
			this.txtTotLordIt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelIndLordIt
			// 
			this.labelIndLordIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelIndLordIt.Location = new System.Drawing.Point(94, 80);
			this.labelIndLordIt.Name = "labelIndLordIt";
			this.labelIndLordIt.Size = new System.Drawing.Size(124, 23);
			this.labelIndLordIt.TabIndex = 16;
			this.labelIndLordIt.Text = "Lorda di trasferta Italia";
			this.labelIndLordIt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotIndennKm
			// 
			this.txtTotIndennKm.Location = new System.Drawing.Point(223, 48);
			this.txtTotIndennKm.Name = "txtTotIndennKm";
			this.txtTotIndennKm.ReadOnly = true;
			this.txtTotIndennKm.Size = new System.Drawing.Size(136, 20);
			this.txtTotIndennKm.TabIndex = 15;
			this.txtTotIndennKm.TabStop = false;
			this.txtTotIndennKm.Tag = "";
			this.txtTotIndennKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labeIndKm
			// 
			this.labeIndKm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labeIndKm.Location = new System.Drawing.Point(102, 48);
			this.labeIndKm.Name = "labeIndKm";
			this.labeIndKm.Size = new System.Drawing.Size(111, 23);
			this.labeIndKm.TabIndex = 14;
			this.labeIndKm.Text = "Chilometrica";
			this.labeIndKm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndSupplementare
			// 
			this.txtIndSupplementare.Location = new System.Drawing.Point(223, 16);
			this.txtIndSupplementare.Name = "txtIndSupplementare";
			this.txtIndSupplementare.ReadOnly = true;
			this.txtIndSupplementare.Size = new System.Drawing.Size(136, 20);
			this.txtIndSupplementare.TabIndex = 13;
			this.txtIndSupplementare.TabStop = false;
			this.txtIndSupplementare.Tag = "";
			this.txtIndSupplementare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelIndSuppl
			// 
			this.labelIndSuppl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelIndSuppl.Location = new System.Drawing.Point(90, 16);
			this.labelIndSuppl.Name = "labelIndSuppl";
			this.labelIndSuppl.Size = new System.Drawing.Size(127, 23);
			this.labelIndSuppl.TabIndex = 12;
			this.labelIndSuppl.Text = "Supplementare";
			this.labelIndSuppl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnToExcel
			// 
			this.btnToExcel.Location = new System.Drawing.Point(582, 396);
			this.btnToExcel.Name = "btnToExcel";
			this.btnToExcel.Size = new System.Drawing.Size(112, 24);
			this.btnToExcel.TabIndex = 24;
			this.btnToExcel.TabStop = false;
			this.btnToExcel.Text = "Riepilogo in Excel";
			this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(386, 255);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(360, 20);
			this.textBox10.TabIndex = 14;
			this.textBox10.TabStop = false;
			this.textBox10.Text = "= Spese+Ind. suppl.+Ind.Chilom.+Ind. lorda trasferta Italia ed Estero";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(384, 207);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(310, 20);
			this.textBox8.TabIndex = 28;
			this.textBox8.TabStop = false;
			this.textBox8.Text = "Somma delle Indennità Lorde per ogni tappa estera";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(386, 175);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(310, 20);
			this.textBox7.TabIndex = 27;
			this.textBox7.TabStop = false;
			this.textBox7.Text = "Somma delle Indennità Lorde per ogni tappa italiana";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(386, 143);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(310, 20);
			this.textBox3.TabIndex = 26;
			this.textBox3.TabStop = false;
			this.textBox3.Text = "Somma di tutti gli importi (EUR Tot.) nella scheda Ind.Km.";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(384, 111);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(310, 20);
			this.textBox2.TabIndex = 11;
			this.textBox2.TabStop = false;
			this.textBox2.Text = "Somma delle indennità supplementari di ogni spesa";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(384, 63);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(311, 20);
			this.textBox1.TabIndex = 9;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Totale spese da considerare ai fini del totale missione";
			// 
			// txtQuotaImponibileTappa
			// 
			this.txtQuotaImponibileTappa.Location = new System.Drawing.Point(235, 429);
			this.txtQuotaImponibileTappa.Name = "txtQuotaImponibileTappa";
			this.txtQuotaImponibileTappa.ReadOnly = true;
			this.txtQuotaImponibileTappa.Size = new System.Drawing.Size(136, 20);
			this.txtQuotaImponibileTappa.TabIndex = 23;
			this.txtQuotaImponibileTappa.TabStop = false;
			this.txtQuotaImponibileTappa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelQuotaImponibile
			// 
			this.labelQuotaImponibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelQuotaImponibile.Location = new System.Drawing.Point(37, 428);
			this.labelQuotaImponibile.Name = "labelQuotaImponibile";
			this.labelQuotaImponibile.Size = new System.Drawing.Size(192, 23);
			this.labelQuotaImponibile.TabIndex = 22;
			this.labelQuotaImponibile.Text = "Imponibile";
			this.labelQuotaImponibile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtQuotaEsenteMissione
			// 
			this.txtQuotaEsenteMissione.Location = new System.Drawing.Point(235, 397);
			this.txtQuotaEsenteMissione.Name = "txtQuotaEsenteMissione";
			this.txtQuotaEsenteMissione.ReadOnly = true;
			this.txtQuotaEsenteMissione.Size = new System.Drawing.Size(136, 20);
			this.txtQuotaEsenteMissione.TabIndex = 21;
			this.txtQuotaEsenteMissione.TabStop = false;
			this.txtQuotaEsenteMissione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelQuotaEsente
			// 
			this.labelQuotaEsente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelQuotaEsente.Location = new System.Drawing.Point(37, 397);
			this.labelQuotaEsente.Name = "labelQuotaEsente";
			this.labelQuotaEsente.Size = new System.Drawing.Size(192, 23);
			this.labelQuotaEsente.TabIndex = 20;
			this.labelQuotaEsente.Text = "Quota esente missione";
			this.labelQuotaEsente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImportoAnticipo
			// 
			this.txtImportoAnticipo.Location = new System.Drawing.Point(235, 365);
			this.txtImportoAnticipo.Name = "txtImportoAnticipo";
			this.txtImportoAnticipo.ReadOnly = true;
			this.txtImportoAnticipo.Size = new System.Drawing.Size(136, 20);
			this.txtImportoAnticipo.TabIndex = 19;
			this.txtImportoAnticipo.TabStop = false;
			this.txtImportoAnticipo.Tag = "itineration.totadvance";
			this.txtImportoAnticipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtComplessivo
			// 
			this.txtComplessivo.Location = new System.Drawing.Point(235, 333);
			this.txtComplessivo.Name = "txtComplessivo";
			this.txtComplessivo.ReadOnly = true;
			this.txtComplessivo.Size = new System.Drawing.Size(136, 20);
			this.txtComplessivo.TabIndex = 17;
			this.txtComplessivo.TabStop = false;
			this.txtComplessivo.Tag = "itineration.total";
			this.txtComplessivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelImpAnticipo
			// 
			this.labelImpAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImpAnticipo.Location = new System.Drawing.Point(37, 365);
			this.labelImpAnticipo.Name = "labelImpAnticipo";
			this.labelImpAnticipo.Size = new System.Drawing.Size(192, 23);
			this.labelImpAnticipo.TabIndex = 18;
			this.labelImpAnticipo.Text = "Importo anticipo";
			this.labelImpAnticipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelImpCompl
			// 
			this.labelImpCompl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelImpCompl.Location = new System.Drawing.Point(8, 333);
			this.labelImpCompl.Name = "labelImpCompl";
			this.labelImpCompl.Size = new System.Drawing.Size(221, 20);
			this.labelImpCompl.TabIndex = 16;
			this.labelImpCompl.Text = "Costo totale = Importo lordo + Contributi";
			this.labelImpCompl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSpeseSostenute
			// 
			this.txtSpeseSostenute.Location = new System.Drawing.Point(233, 63);
			this.txtSpeseSostenute.Name = "txtSpeseSostenute";
			this.txtSpeseSostenute.ReadOnly = true;
			this.txtSpeseSostenute.Size = new System.Drawing.Size(136, 20);
			this.txtSpeseSostenute.TabIndex = 8;
			this.txtSpeseSostenute.TabStop = false;
			this.txtSpeseSostenute.Tag = "";
			this.txtSpeseSostenute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelSpeseSost
			// 
			this.labelSpeseSost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelSpeseSost.Location = new System.Drawing.Point(3, 57);
			this.labelSpeseSost.Name = "labelSpeseSost";
			this.labelSpeseSost.Size = new System.Drawing.Size(225, 35);
			this.labelSpeseSost.TabIndex = 7;
			this.labelSpeseSost.Text = "Totale spese da considerare";
			this.labelSpeseSost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.btnGeneraPreimpegni);
			this.tabEP.Controls.Add(this.btnVisualizzaPreimpegni);
			this.tabEP.Controls.Add(this.btnGeneraEpExp);
			this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Controls.Add(this.tabControl2);
			this.tabEP.Location = new System.Drawing.Point(4, 23);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(963, 500);
			this.tabEP.TabIndex = 8;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// btnGeneraPreimpegni
			// 
			this.btnGeneraPreimpegni.Location = new System.Drawing.Point(160, 72);
			this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
			this.btnGeneraPreimpegni.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraPreimpegni.TabIndex = 27;
			this.btnGeneraPreimpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnVisualizzaPreimpegni
			// 
			this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(160, 104);
			this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
			this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaPreimpegni.TabIndex = 26;
			this.btnVisualizzaPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(424, 72);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 25;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(424, 104);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 24;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(424, 40);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 23;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(424, 8);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 22;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(32, 16);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(352, 16);
			this.labEP.TabIndex = 20;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabAnalitico);
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Location = new System.Drawing.Point(8, 136);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(947, 358);
			this.tabControl2.TabIndex = 19;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(939, 332);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziario";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(3, 3);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(413, 104);
			this.gboxUPB.TabIndex = 8;
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
			this.tabAnalitico.Controls.Add(this.groupBox7);
			this.tabAnalitico.Controls.Add(this.btnRipartizione);
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(939, 332);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			this.tabAnalitico.Visible = false;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.btnCodRipartizione);
			this.groupBox7.Controls.Add(this.txtDenRipartizione);
			this.groupBox7.Controls.Add(this.txtCodiceRipartizione);
			this.groupBox7.Location = new System.Drawing.Point(490, 3);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(433, 89);
			this.groupBox7.TabIndex = 54;
			this.groupBox7.TabStop = false;
			this.groupBox7.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.groupBox7.Text = "Ripartizione dei Costi";
			// 
			// btnCodRipartizione
			// 
			this.btnCodRipartizione.Location = new System.Drawing.Point(8, 37);
			this.btnCodRipartizione.Name = "btnCodRipartizione";
			this.btnCodRipartizione.Size = new System.Drawing.Size(88, 23);
			this.btnCodRipartizione.TabIndex = 4;
			this.btnCodRipartizione.Tag = "choose.costpartition.default.(active=\'S\')";
			this.btnCodRipartizione.Text = "Codice";
			this.btnCodRipartizione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenRipartizione
			// 
			this.txtDenRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenRipartizione.Location = new System.Drawing.Point(150, 8);
			this.txtDenRipartizione.Multiline = true;
			this.txtDenRipartizione.Name = "txtDenRipartizione";
			this.txtDenRipartizione.ReadOnly = true;
			this.txtDenRipartizione.Size = new System.Drawing.Size(275, 52);
			this.txtDenRipartizione.TabIndex = 3;
			this.txtDenRipartizione.TabStop = false;
			this.txtDenRipartizione.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 63);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(417, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// btnRipartizione
			// 
			this.btnRipartizione.Location = new System.Drawing.Point(499, 132);
			this.btnRipartizione.Name = "btnRipartizione";
			this.btnRipartizione.Size = new System.Drawing.Size(88, 23);
			this.btnRipartizione.TabIndex = 53;
			this.btnRipartizione.Text = "Ripartizione";
			this.btnRipartizione.Click += new System.EventHandler(this.btnRipartizione_Click);
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(23, 202);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(433, 85);
			this.gboxclass3.TabIndex = 6;
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
			this.gboxclass2.Location = new System.Drawing.Point(23, 98);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(433, 89);
			this.gboxclass2.TabIndex = 5;
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
			this.gboxclass1.Location = new System.Drawing.Point(23, 3);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(433, 89);
			this.gboxclass1.TabIndex = 4;
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
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpBoxSiopeEP);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.textBox6);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebitoCrg);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebito);
			this.tabPage2.Controls.Add(this.gBoxCausaleCosto);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(939, 332);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "E/P";
			this.tabPage2.Visible = false;
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(346, 8);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(328, 92);
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
			this.txtDescSiope.Size = new System.Drawing.Size(202, 69);
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
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(349, 126);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(265, 16);
			this.label3.TabIndex = 16;
			this.label3.Text = "Data correzione causale di debito";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(348, 145);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(134, 20);
			this.textBox6.TabIndex = 2;
			this.textBox6.Tag = "itineration.idaccmotivedebit_datacrg";
			// 
			// gBoxCausaleDebitoCrg
			// 
			this.gBoxCausaleDebitoCrg.Controls.Add(this.textBox9);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.txtCodiceCausaleCrg);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.button7);
			this.gBoxCausaleDebitoCrg.Location = new System.Drawing.Point(346, 169);
			this.gBoxCausaleDebitoCrg.Name = "gBoxCausaleDebitoCrg";
			this.gBoxCausaleDebitoCrg.Size = new System.Drawing.Size(328, 141);
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
			this.textBox9.Size = new System.Drawing.Size(200, 93);
			this.textBox9.TabIndex = 2;
			this.textBox9.TabStop = false;
			this.textBox9.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(6, 115);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?itinerationview.codemotivedebit_crg";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(10, 86);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 23);
			this.button7.TabIndex = 0;
			this.button7.Tag = "manage.accmotiveapplied_crg.tree";
			this.button7.Text = "Causale";
			// 
			// gBoxCausaleDebito
			// 
			this.gBoxCausaleDebito.Controls.Add(this.textBox11);
			this.gBoxCausaleDebito.Controls.Add(this.txtCodiceCausaleDeb);
			this.gBoxCausaleDebito.Controls.Add(this.button6);
			this.gBoxCausaleDebito.Location = new System.Drawing.Point(3, 169);
			this.gBoxCausaleDebito.Name = "gBoxCausaleDebito";
			this.gBoxCausaleDebito.Size = new System.Drawing.Size(328, 141);
			this.gBoxCausaleDebito.TabIndex = 1;
			this.gBoxCausaleDebito.TabStop = false;
			this.gBoxCausaleDebito.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gBoxCausaleDebito.Text = "Causale di debito";
			this.gBoxCausaleDebito.UseCompatibleTextRendering = true;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(120, 16);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(200, 93);
			this.textBox11.TabIndex = 2;
			this.textBox11.TabStop = false;
			this.textBox11.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(8, 115);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?itinerationview.codemotivedebit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(10, 86);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 0;
			this.button6.Tag = "manage.accmotiveapplied_debit.tree";
			this.button6.Text = "Causale";
			// 
			// gBoxCausaleCosto
			// 
			this.gBoxCausaleCosto.Controls.Add(this.textBox5);
			this.gBoxCausaleCosto.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausaleCosto.Controls.Add(this.button5);
			this.gBoxCausaleCosto.Location = new System.Drawing.Point(8, 8);
			this.gBoxCausaleCosto.Name = "gBoxCausaleCosto";
			this.gBoxCausaleCosto.Size = new System.Drawing.Size(328, 155);
			this.gBoxCausaleCosto.TabIndex = 0;
			this.gBoxCausaleCosto.TabStop = false;
			this.gBoxCausaleCosto.Tag = "AutoManage.txtCodiceCausale.tree.( in_use= \'S\')";
			this.gBoxCausaleCosto.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(120, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(200, 96);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied_cost.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(6, 118);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied_cost.codemotive?itinerationview.codemotive";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 89);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 0;
			this.button5.Tag = "manage.accmotiveapplied_cost.tree";
			this.button5.Text = "Causale";
			// 
			// tabAnagPrest
			// 
			this.tabAnagPrest.Controls.Add(this.btnCollegaAP);
			this.tabAnagPrest.Controls.Add(this.grpBoxMotivo);
			this.tabAnagPrest.Controls.Add(this.grpBoxDocAutorizzattivo);
			this.tabAnagPrest.Controls.Add(this.grpBoxAutorizzazioneAP);
			this.tabAnagPrest.Controls.Add(this.btnGeneraAP);
			this.tabAnagPrest.Controls.Add(this.btnVisualizzaAP);
			this.tabAnagPrest.Controls.Add(this.labAPnongenerato);
			this.tabAnagPrest.Controls.Add(this.labAPgenerato);
			this.tabAnagPrest.Location = new System.Drawing.Point(4, 23);
			this.tabAnagPrest.Name = "tabAnagPrest";
			this.tabAnagPrest.Size = new System.Drawing.Size(963, 500);
			this.tabAnagPrest.TabIndex = 9;
			this.tabAnagPrest.Text = "Anagrafe Prestazioni";
			this.tabAnagPrest.UseVisualStyleBackColor = true;
			// 
			// btnCollegaAP
			// 
			this.btnCollegaAP.Location = new System.Drawing.Point(460, 107);
			this.btnCollegaAP.Name = "btnCollegaAP";
			this.btnCollegaAP.Size = new System.Drawing.Size(224, 39);
			this.btnCollegaAP.TabIndex = 23;
			this.btnCollegaAP.Text = "Collega ad Anagrafe delle Prestazioni  già esistente";
			this.btnCollegaAP.Click += new System.EventHandler(this.btnCollegaAP_Click);
			// 
			// grpBoxMotivo
			// 
			this.grpBoxMotivo.Controls.Add(this.txtMotivoAut);
			this.grpBoxMotivo.Location = new System.Drawing.Point(310, 175);
			this.grpBoxMotivo.Name = "grpBoxMotivo";
			this.grpBoxMotivo.Size = new System.Drawing.Size(374, 91);
			this.grpBoxMotivo.TabIndex = 18;
			this.grpBoxMotivo.TabStop = false;
			this.grpBoxMotivo.Text = "Motivo per cui non è necessaria l\'autorizzazione";
			// 
			// txtMotivoAut
			// 
			this.txtMotivoAut.Location = new System.Drawing.Point(8, 16);
			this.txtMotivoAut.Multiline = true;
			this.txtMotivoAut.Name = "txtMotivoAut";
			this.txtMotivoAut.Size = new System.Drawing.Size(360, 65);
			this.txtMotivoAut.TabIndex = 1;
			this.txtMotivoAut.Tag = "itineration.noauthreason";
			// 
			// grpBoxDocAutorizzattivo
			// 
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label19);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDataDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label22);
			this.grpBoxDocAutorizzattivo.Location = new System.Drawing.Point(310, 211);
			this.grpBoxDocAutorizzattivo.Name = "grpBoxDocAutorizzattivo";
			this.grpBoxDocAutorizzattivo.Size = new System.Drawing.Size(374, 54);
			this.grpBoxDocAutorizzattivo.TabIndex = 17;
			this.grpBoxDocAutorizzattivo.TabStop = false;
			this.grpBoxDocAutorizzattivo.Text = "Documento autorizzativo";
			// 
			// txtDocumentoAut
			// 
			this.txtDocumentoAut.Location = new System.Drawing.Point(8, 30);
			this.txtDocumentoAut.Name = "txtDocumentoAut";
			this.txtDocumentoAut.Size = new System.Drawing.Size(255, 20);
			this.txtDocumentoAut.TabIndex = 1;
			this.txtDocumentoAut.Tag = "itineration.authdoc";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 14);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(128, 16);
			this.label19.TabIndex = 0;
			this.label19.Text = "Descrizione";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumentoAut
			// 
			this.txtDataDocumentoAut.Location = new System.Drawing.Point(285, 30);
			this.txtDataDocumentoAut.Name = "txtDataDocumentoAut";
			this.txtDataDocumentoAut.Size = new System.Drawing.Size(72, 20);
			this.txtDataDocumentoAut.TabIndex = 2;
			this.txtDataDocumentoAut.Tag = "itineration.authdocdate";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(285, 14);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(72, 16);
			this.label22.TabIndex = 0;
			this.label22.Text = "Data";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpBoxAutorizzazioneAP
			// 
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbAutorizzazioneNonNecessaria);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNonApplicabile);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNecessitaAutorizzazione);
			this.grpBoxAutorizzazioneAP.Location = new System.Drawing.Point(39, 174);
			this.grpBoxAutorizzazioneAP.Name = "grpBoxAutorizzazioneAP";
			this.grpBoxAutorizzazioneAP.Size = new System.Drawing.Size(265, 91);
			this.grpBoxAutorizzazioneAP.TabIndex = 17;
			this.grpBoxAutorizzazioneAP.TabStop = false;
			this.grpBoxAutorizzazioneAP.Text = "Autorizzazione del soggetto per il compenso";
			// 
			// rdbAutorizzazioneNonNecessaria
			// 
			this.rdbAutorizzazioneNonNecessaria.AutoSize = true;
			this.rdbAutorizzazioneNonNecessaria.Location = new System.Drawing.Point(6, 64);
			this.rdbAutorizzazioneNonNecessaria.Name = "rdbAutorizzazioneNonNecessaria";
			this.rdbAutorizzazioneNonNecessaria.Size = new System.Drawing.Size(163, 17);
			this.rdbAutorizzazioneNonNecessaria.TabIndex = 16;
			this.rdbAutorizzazioneNonNecessaria.TabStop = true;
			this.rdbAutorizzazioneNonNecessaria.Tag = "itineration.authneeded:N";
			this.rdbAutorizzazioneNonNecessaria.Text = "Non necessita autorizzazione";
			this.rdbAutorizzazioneNonNecessaria.UseVisualStyleBackColor = true;
			this.rdbAutorizzazioneNonNecessaria.CheckedChanged += new System.EventHandler(this.rdbAutorizzazioneNonNecessaria_CheckedChanged);
			// 
			// rdbNonApplicabile
			// 
			this.rdbNonApplicabile.AutoSize = true;
			this.rdbNonApplicabile.Location = new System.Drawing.Point(6, 18);
			this.rdbNonApplicabile.Name = "rdbNonApplicabile";
			this.rdbNonApplicabile.Size = new System.Drawing.Size(99, 17);
			this.rdbNonApplicabile.TabIndex = 14;
			this.rdbNonApplicabile.TabStop = true;
			this.rdbNonApplicabile.Tag = "itineration.authneeded:X";
			this.rdbNonApplicabile.Text = "Non Applicabile";
			this.rdbNonApplicabile.UseVisualStyleBackColor = true;
			this.rdbNonApplicabile.CheckedChanged += new System.EventHandler(this.rdbNonApplicabile_CheckedChanged);
			// 
			// rdbNecessitaAutorizzazione
			// 
			this.rdbNecessitaAutorizzazione.AutoSize = true;
			this.rdbNecessitaAutorizzazione.Location = new System.Drawing.Point(6, 41);
			this.rdbNecessitaAutorizzazione.Name = "rdbNecessitaAutorizzazione";
			this.rdbNecessitaAutorizzazione.Size = new System.Drawing.Size(142, 17);
			this.rdbNecessitaAutorizzazione.TabIndex = 15;
			this.rdbNecessitaAutorizzazione.TabStop = true;
			this.rdbNecessitaAutorizzazione.Tag = "itineration.authneeded:S";
			this.rdbNecessitaAutorizzazione.Text = "Necessita autorizzazione";
			this.rdbNecessitaAutorizzazione.UseVisualStyleBackColor = true;
			this.rdbNecessitaAutorizzazione.CheckedChanged += new System.EventHandler(this.rdbNecessitaAutorizzazione_CheckedChanged);
			// 
			// btnGeneraAP
			// 
			this.btnGeneraAP.Location = new System.Drawing.Point(460, 64);
			this.btnGeneraAP.Name = "btnGeneraAP";
			this.btnGeneraAP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraAP.TabIndex = 13;
			this.btnGeneraAP.Text = "Genera Anagrafe delle Prestazioni";
			this.btnGeneraAP.Click += new System.EventHandler(this.btnGeneraAP_Click);
			// 
			// btnVisualizzaAP
			// 
			this.btnVisualizzaAP.Location = new System.Drawing.Point(460, 32);
			this.btnVisualizzaAP.Name = "btnVisualizzaAP";
			this.btnVisualizzaAP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaAP.TabIndex = 12;
			this.btnVisualizzaAP.Text = "Visualizza Anagrafe delle Prestazione";
			this.btnVisualizzaAP.Click += new System.EventHandler(this.btnVisualizzaAP_Click);
			// 
			// labAPnongenerato
			// 
			this.labAPnongenerato.Location = new System.Drawing.Point(36, 64);
			this.labAPnongenerato.Name = "labAPnongenerato";
			this.labAPnongenerato.Size = new System.Drawing.Size(416, 24);
			this.labAPnongenerato.TabIndex = 11;
			this.labAPnongenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni  NON sono state ancora generate." +
    "";
			// 
			// labAPgenerato
			// 
			this.labAPgenerato.Location = new System.Drawing.Point(36, 40);
			this.labAPgenerato.Name = "labAPgenerato";
			this.labAPgenerato.Size = new System.Drawing.Size(432, 16);
			this.labAPgenerato.TabIndex = 10;
			this.labAPgenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni sono state generate.";
			// 
			// tabAutorizzazioni
			// 
			this.tabAutorizzazioni.Controls.Add(this.groupBox13);
			this.tabAutorizzazioni.Controls.Add(this.groupBox12);
			this.tabAutorizzazioni.Controls.Add(this.grpModelloAut);
			this.tabAutorizzazioni.Location = new System.Drawing.Point(4, 23);
			this.tabAutorizzazioni.Name = "tabAutorizzazioni";
			this.tabAutorizzazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabAutorizzazioni.Size = new System.Drawing.Size(963, 500);
			this.tabAutorizzazioni.TabIndex = 10;
			this.tabAutorizzazioni.Text = "Autorizzazioni e avvisi";
			this.tabAutorizzazioni.UseVisualStyleBackColor = true;
			// 
			// groupBox13
			// 
			this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox13.Controls.Add(this.textBox12);
			this.groupBox13.Location = new System.Drawing.Point(16, 270);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(932, 134);
			this.groupBox13.TabIndex = 109;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Avvisi per il Richiedente";
			// 
			// textBox12
			// 
			this.textBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox12.Location = new System.Drawing.Point(12, 19);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(910, 106);
			this.textBox12.TabIndex = 5;
			this.textBox12.Tag = "itineration.webwarn";
			// 
			// groupBox12
			// 
			this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox12.Controls.Add(this.dgrAutorizzazioni);
			this.groupBox12.Location = new System.Drawing.Point(16, 75);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(932, 189);
			this.groupBox12.TabIndex = 108;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Autorizzazioni";
			// 
			// dgrAutorizzazioni
			// 
			this.dgrAutorizzazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrAutorizzazioni.DataMember = "";
			this.dgrAutorizzazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrAutorizzazioni.Location = new System.Drawing.Point(12, 18);
			this.dgrAutorizzazioni.Name = "dgrAutorizzazioni";
			this.dgrAutorizzazioni.ReadOnly = true;
			this.dgrAutorizzazioni.Size = new System.Drawing.Size(910, 162);
			this.dgrAutorizzazioni.TabIndex = 107;
			this.dgrAutorizzazioni.Tag = "itinerationauthagency.default";
			// 
			// grpModelloAut
			// 
			this.grpModelloAut.Controls.Add(this.txtImportoMax);
			this.grpModelloAut.Controls.Add(this.label10);
			this.grpModelloAut.Controls.Add(this.cmbAuthModel);
			this.grpModelloAut.Controls.Add(this.txtLunghezzaMax);
			this.grpModelloAut.Controls.Add(this.label17);
			this.grpModelloAut.Location = new System.Drawing.Point(16, 20);
			this.grpModelloAut.Name = "grpModelloAut";
			this.grpModelloAut.Size = new System.Drawing.Size(689, 49);
			this.grpModelloAut.TabIndex = 106;
			this.grpModelloAut.TabStop = false;
			this.grpModelloAut.Text = "Modello Autorizzativo";
			// 
			// txtImportoMax
			// 
			this.txtImportoMax.Location = new System.Drawing.Point(563, 20);
			this.txtImportoMax.Name = "txtImportoMax";
			this.txtImportoMax.Size = new System.Drawing.Size(112, 20);
			this.txtImportoMax.TabIndex = 113;
			this.txtImportoMax.TabStop = false;
			this.txtImportoMax.Tag = "authmodel.maxlen";
			this.txtImportoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(484, 20);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(69, 16);
			this.label10.TabIndex = 112;
			this.label10.Text = "Durata Max:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbAuthModel
			// 
			this.cmbAuthModel.DataSource = this.DS.authmodel;
			this.cmbAuthModel.DisplayMember = "title";
			this.cmbAuthModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAuthModel.Location = new System.Drawing.Point(6, 18);
			this.cmbAuthModel.Name = "cmbAuthModel";
			this.cmbAuthModel.Size = new System.Drawing.Size(262, 21);
			this.cmbAuthModel.TabIndex = 43;
			this.cmbAuthModel.Tag = "itineration.idauthmodel?itinerationview.idauthmodel";
			this.cmbAuthModel.ValueMember = "idauthmodel";
			// 
			// txtLunghezzaMax
			// 
			this.txtLunghezzaMax.Location = new System.Drawing.Point(354, 19);
			this.txtLunghezzaMax.Name = "txtLunghezzaMax";
			this.txtLunghezzaMax.Size = new System.Drawing.Size(112, 20);
			this.txtLunghezzaMax.TabIndex = 111;
			this.txtLunghezzaMax.TabStop = false;
			this.txtLunghezzaMax.Tag = "authmodel.maxamount.c";
			this.txtLunghezzaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(280, 19);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(73, 16);
			this.label17.TabIndex = 110;
			this.label17.Text = "Importo Max:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabPagamenti
			// 
			this.tabPagamenti.Controls.Add(this.groupBox10);
			this.tabPagamenti.Controls.Add(this.groupBox8);
			this.tabPagamenti.Location = new System.Drawing.Point(4, 23);
			this.tabPagamenti.Name = "tabPagamenti";
			this.tabPagamenti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPagamenti.Size = new System.Drawing.Size(963, 500);
			this.tabPagamenti.TabIndex = 11;
			this.tabPagamenti.Text = "Annotazioni";
			this.tabPagamenti.UseVisualStyleBackColor = true;
			// 
			// groupBox10
			// 
			this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox10.Controls.Add(this.txt_additionalannotations);
			this.groupBox10.Location = new System.Drawing.Point(8, 237);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(925, 200);
			this.groupBox10.TabIndex = 7;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Richieste aggiuntive sulla missione";
			// 
			// txt_additionalannotations
			// 
			this.txt_additionalannotations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_additionalannotations.Location = new System.Drawing.Point(7, 19);
			this.txt_additionalannotations.Multiline = true;
			this.txt_additionalannotations.Name = "txt_additionalannotations";
			this.txt_additionalannotations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txt_additionalannotations.Size = new System.Drawing.Size(912, 175);
			this.txt_additionalannotations.TabIndex = 5;
			this.txt_additionalannotations.Tag = "itineration.additionalannotations";
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.textBox13);
			this.groupBox8.Location = new System.Drawing.Point(8, 17);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(925, 200);
			this.groupBox8.TabIndex = 6;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Appunti per il Pagamento";
			// 
			// textBox13
			// 
			this.textBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox13.Location = new System.Drawing.Point(7, 19);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox13.Size = new System.Drawing.Size(912, 175);
			this.textBox13.TabIndex = 5;
			this.textBox13.Tag = "itineration.applierannotations";
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 23);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(963, 500);
			this.tabAttributi.TabIndex = 13;
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
			this.gboxclass05.Location = new System.Drawing.Point(8, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(661, 64);
			this.gboxclass05.TabIndex = 33;
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
			this.txtDenom05.Size = new System.Drawing.Size(419, 52);
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
			this.gboxclass04.Location = new System.Drawing.Point(8, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(661, 64);
			this.gboxclass04.TabIndex = 32;
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
			this.txtDenom04.Size = new System.Drawing.Size(419, 46);
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
			this.gboxclass03.Location = new System.Drawing.Point(8, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(661, 64);
			this.gboxclass03.TabIndex = 30;
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
			this.txtDenom03.Size = new System.Drawing.Size(420, 52);
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
			this.gboxclass02.Location = new System.Drawing.Point(8, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(661, 64);
			this.gboxclass02.TabIndex = 31;
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
			this.txtDenom02.Size = new System.Drawing.Size(420, 52);
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
			this.gboxclass01.Location = new System.Drawing.Point(8, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(661, 64);
			this.gboxclass01.TabIndex = 29;
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
			this.txtDenom01.Size = new System.Drawing.Size(420, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dataGrid3);
			this.tabAllegati.Controls.Add(this.button2);
			this.tabAllegati.Controls.Add(this.button3);
			this.tabAllegati.Controls.Add(this.button1);
			this.tabAllegati.Location = new System.Drawing.Point(4, 23);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabAllegati.Size = new System.Drawing.Size(963, 500);
			this.tabAllegati.TabIndex = 12;
			this.tabAllegati.Text = "Allegati";
			this.tabAllegati.UseVisualStyleBackColor = true;
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(18, 64);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.ReadOnly = true;
			this.dataGrid3.Size = new System.Drawing.Size(924, 342);
			this.dataGrid3.TabIndex = 23;
			this.dataGrid3.Tag = "itinerationattachment.default.default";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(178, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(68, 24);
			this.button2.TabIndex = 22;
			this.button2.Tag = "delete";
			this.button2.Text = "Elimina";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(98, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(69, 24);
			this.button3.TabIndex = 21;
			this.button3.Tag = "edit.default";
			this.button3.Text = "Modifica...";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(18, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 24);
			this.button1.TabIndex = 20;
			this.button1.Tag = "insert.default";
			this.button1.Text = "Inserisci...";
			// 
			// tabDALIA
			// 
			this.tabDALIA.Controls.Add(this.groupBox3);
			this.tabDALIA.Controls.Add(this.gboxDipartimento);
			this.tabDALIA.Controls.Add(this.grpCausaliAssunzioneDalia);
			this.tabDALIA.Controls.Add(this.txtVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.btnVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.groupBox9);
			this.tabDALIA.Location = new System.Drawing.Point(4, 23);
			this.tabDALIA.Name = "tabDALIA";
			this.tabDALIA.Padding = new System.Windows.Forms.Padding(3);
			this.tabDALIA.Size = new System.Drawing.Size(963, 500);
			this.tabDALIA.TabIndex = 14;
			this.tabDALIA.Text = "DALIA";
			this.tabDALIA.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbDaliaFunzionale);
			this.groupBox3.Location = new System.Drawing.Point(8, 258);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(379, 54);
			this.groupBox3.TabIndex = 115;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Area funzionale - richiesta per il personale Tecnico / Amministrativo";
			// 
			// cmbDaliaFunzionale
			// 
			this.cmbDaliaFunzionale.FormattingEnabled = true;
			this.cmbDaliaFunzionale.Location = new System.Drawing.Point(6, 19);
			this.cmbDaliaFunzionale.Name = "cmbDaliaFunzionale";
			this.cmbDaliaFunzionale.Size = new System.Drawing.Size(367, 21);
			this.cmbDaliaFunzionale.TabIndex = 0;
			this.cmbDaliaFunzionale.Tag = "itineration.iddalia_funzionale";
			// 
			// gboxDipartimento
			// 
			this.gboxDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDipartimento.Controls.Add(this.btnDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtCodiceDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtDaliaDipartimento);
			this.gboxDipartimento.Location = new System.Drawing.Point(8, 202);
			this.gboxDipartimento.Name = "gboxDipartimento";
			this.gboxDipartimento.Size = new System.Drawing.Size(940, 50);
			this.gboxDipartimento.TabIndex = 114;
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
			this.txtCodiceDipartimento.Location = new System.Drawing.Point(827, 19);
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
			this.txtDaliaDipartimento.Size = new System.Drawing.Size(692, 20);
			this.txtDaliaDipartimento.TabIndex = 0;
			this.txtDaliaDipartimento.Tag = "dalia_dipartimento.title";
			// 
			// grpCausaliAssunzioneDalia
			// 
			this.grpCausaliAssunzioneDalia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCausaliAssunzioneDalia.Controls.Add(this.txtCausaleAssunzione);
			this.grpCausaliAssunzioneDalia.Controls.Add(this.btnEsclusioneCIG);
			this.grpCausaliAssunzioneDalia.Location = new System.Drawing.Point(8, 150);
			this.grpCausaliAssunzioneDalia.Name = "grpCausaliAssunzioneDalia";
			this.grpCausaliAssunzioneDalia.Size = new System.Drawing.Size(940, 46);
			this.grpCausaliAssunzioneDalia.TabIndex = 113;
			this.grpCausaliAssunzioneDalia.TabStop = false;
			this.grpCausaliAssunzioneDalia.Tag = "AutoChoose.txtCausaleAssunzione.default.(active = \'S\')";
			this.grpCausaliAssunzioneDalia.Text = "Causali immissione qualifica - Causali assunzione";
			// 
			// txtCausaleAssunzione
			// 
			this.txtCausaleAssunzione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausaleAssunzione.Location = new System.Drawing.Point(121, 16);
			this.txtCausaleAssunzione.Name = "txtCausaleAssunzione";
			this.txtCausaleAssunzione.Size = new System.Drawing.Size(811, 20);
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
			this.txtVoceSpesaDalia.Location = new System.Drawing.Point(213, 103);
			this.txtVoceSpesaDalia.Name = "txtVoceSpesaDalia";
			this.txtVoceSpesaDalia.ReadOnly = true;
			this.txtVoceSpesaDalia.Size = new System.Drawing.Size(734, 20);
			this.txtVoceSpesaDalia.TabIndex = 112;
			// 
			// btnVoceSpesaDalia
			// 
			this.btnVoceSpesaDalia.Location = new System.Drawing.Point(14, 101);
			this.btnVoceSpesaDalia.Name = "btnVoceSpesaDalia";
			this.btnVoceSpesaDalia.Size = new System.Drawing.Size(185, 23);
			this.btnVoceSpesaDalia.TabIndex = 20;
			this.btnVoceSpesaDalia.Text = "Seleziona Voce di spesa Dalia";
			this.btnVoceSpesaDalia.UseVisualStyleBackColor = true;
			this.btnVoceSpesaDalia.Click += new System.EventHandler(this.btnVoceSpesaDalia_Click);
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.label91);
			this.groupBox9.Controls.Add(this.btnQualificaDalia);
			this.groupBox9.Controls.Add(this.textBox19);
			this.groupBox9.Controls.Add(this.cmb_dalia_position);
			this.groupBox9.Location = new System.Drawing.Point(8, 15);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(947, 80);
			this.groupBox9.TabIndex = 110;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Banca Dati DALIA";
			// 
			// label91
			// 
			this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(823, 25);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(118, 13);
			this.label91.TabIndex = 110;
			this.label91.Text = "Codice Qualifica DALIA";
			// 
			// btnQualificaDalia
			// 
			this.btnQualificaDalia.Location = new System.Drawing.Point(75, 38);
			this.btnQualificaDalia.Name = "btnQualificaDalia";
			this.btnQualificaDalia.Size = new System.Drawing.Size(116, 23);
			this.btnQualificaDalia.TabIndex = 113;
			this.btnQualificaDalia.Text = "Qualifica Dalia";
			this.btnQualificaDalia.UseVisualStyleBackColor = true;
			this.btnQualificaDalia.Click += new System.EventHandler(this.btnQualificaDalia_Click);
			// 
			// textBox19
			// 
			this.textBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox19.Location = new System.Drawing.Point(823, 41);
			this.textBox19.Name = "textBox19";
			this.textBox19.ReadOnly = true;
			this.textBox19.Size = new System.Drawing.Size(116, 20);
			this.textBox19.TabIndex = 109;
			this.textBox19.Tag = "dalia_position.codedaliaposition";
			// 
			// cmb_dalia_position
			// 
			this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_dalia_position.DataSource = this.DS.dalia_position;
			this.cmb_dalia_position.DisplayMember = "description";
			this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dalia_position.Location = new System.Drawing.Point(205, 40);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(601, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "itineration.iddaliaposition";
			this.cmb_dalia_position.ValueMember = "iddaliaposition";
			// 
			// tabCTanticipo
			// 
			this.tabCTanticipo.Controls.Add(this.grpAltro);
			this.tabCTanticipo.Location = new System.Drawing.Point(4, 23);
			this.tabCTanticipo.Name = "tabCTanticipo";
			this.tabCTanticipo.Size = new System.Drawing.Size(963, 500);
			this.tabCTanticipo.TabIndex = 15;
			this.tabCTanticipo.Text = "Altro";
			this.tabCTanticipo.UseVisualStyleBackColor = true;
			// 
			// grpAltro
			// 
			this.grpAltro.Controls.Add(this.label60);
			this.grpAltro.Controls.Add(this.grpTratte);
			this.grpAltro.Controls.Add(this.grpAnticipoTramiteCosti);
			this.grpAltro.Controls.Add(this.txtDataOraInizio);
			this.grpAltro.Controls.Add(this.txtDataOraTermine);
			this.grpAltro.Controls.Add(this.label61);
			this.grpAltro.Location = new System.Drawing.Point(8, 3);
			this.grpAltro.Name = "grpAltro";
			this.grpAltro.Size = new System.Drawing.Size(947, 489);
			this.grpAltro.TabIndex = 33;
			this.grpAltro.TabStop = false;
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(44, 38);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(96, 23);
			this.label60.TabIndex = 30;
			this.label60.Text = "Data/ora inizio:";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpTratte
			// 
			this.grpTratte.Controls.Add(this.dataGrid4);
			this.grpTratte.Controls.Add(this.checkBox4);
			this.grpTratte.Controls.Add(this.checkBox3);
			this.grpTratte.Controls.Add(this.button4);
			this.grpTratte.Controls.Add(this.button8);
			this.grpTratte.Controls.Add(this.checkBox2);
			this.grpTratte.Controls.Add(this.button9);
			this.grpTratte.Controls.Add(this.label52);
			this.grpTratte.Location = new System.Drawing.Point(379, 19);
			this.grpTratte.Name = "grpTratte";
			this.grpTratte.Size = new System.Drawing.Size(562, 164);
			this.grpTratte.TabIndex = 0;
			this.grpTratte.TabStop = false;
			this.grpTratte.Text = "Tratte Aereo/Nave";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(91, 47);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.ReadOnly = true;
			this.dataGrid4.Size = new System.Drawing.Size(465, 111);
			this.dataGrid4.TabIndex = 23;
			this.dataGrid4.Tag = "itinerationflights.default.default";
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(475, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(68, 17);
			this.checkBox4.TabIndex = 27;
			this.checkBox4.Tag = "itineration.flagmove:0";
			this.checkBox4.Text = "Nessuno";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(396, 19);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(52, 17);
			this.checkBox3.TabIndex = 26;
			this.checkBox3.Tag = "itineration.flagmove:2";
			this.checkBox3.Text = "Nave";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 107);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(68, 22);
			this.button4.TabIndex = 22;
			this.button4.Tag = "delete";
			this.button4.Text = "Elimina";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(5, 79);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(69, 22);
			this.button8.TabIndex = 21;
			this.button8.Tag = "edit.default";
			this.button8.Text = "Modifica...";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(314, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(54, 17);
			this.checkBox2.TabIndex = 25;
			this.checkBox2.Tag = "itineration.flagmove:1";
			this.checkBox2.Text = "Aereo";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(6, 51);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(68, 22);
			this.button9.TabIndex = 20;
			this.button9.Tag = "insert.default";
			this.button9.Text = "Inserisci...";
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(190, 15);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(101, 23);
			this.label52.TabIndex = 24;
			this.label52.Text = "Autorizzazione uso";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpAnticipoTramiteCosti
			// 
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox26);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label66);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox25);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label65);
			this.grpAnticipoTramiteCosti.Controls.Add(this.txtPercAnticipoItaliaEstero);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label64);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox24);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label63);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox23);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label59);
			this.grpAnticipoTramiteCosti.Controls.Add(this.groupBox14);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox22);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label58);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox21);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label57);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox15);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label53);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox17);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label54);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox18);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label55);
			this.grpAnticipoTramiteCosti.Controls.Add(this.textBox20);
			this.grpAnticipoTramiteCosti.Controls.Add(this.label56);
			this.grpAnticipoTramiteCosti.Location = new System.Drawing.Point(374, 194);
			this.grpAnticipoTramiteCosti.Name = "grpAnticipoTramiteCosti";
			this.grpAnticipoTramiteCosti.Size = new System.Drawing.Size(567, 289);
			this.grpAnticipoTramiteCosti.TabIndex = 28;
			this.grpAnticipoTramiteCosti.TabStop = false;
			this.grpAnticipoTramiteCosti.Text = "Anticipo";
			// 
			// textBox26
			// 
			this.textBox26.Location = new System.Drawing.Point(414, 132);
			this.textBox26.Name = "textBox26";
			this.textBox26.Size = new System.Drawing.Size(100, 20);
			this.textBox26.TabIndex = 67;
			this.textBox26.Tag = "itineration.advancepercentageliving.fixed.4..%.100";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(297, 135);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(107, 13);
			this.label66.TabIndex = 66;
			this.label66.Text = "% Anticipo Soggiorno";
			// 
			// textBox25
			// 
			this.textBox25.Location = new System.Drawing.Point(414, 223);
			this.textBox25.Name = "textBox25";
			this.textBox25.Size = new System.Drawing.Size(100, 20);
			this.textBox25.TabIndex = 65;
			this.textBox25.Tag = "itineration.advancepercentagefood.fixed.4..%.100";
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(317, 226);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(82, 13);
			this.label65.TabIndex = 64;
			this.label65.Text = "% Anticipo Pasti";
			// 
			// txtPercAnticipoItaliaEstero
			// 
			this.txtPercAnticipoItaliaEstero.Location = new System.Drawing.Point(414, 108);
			this.txtPercAnticipoItaliaEstero.Name = "txtPercAnticipoItaliaEstero";
			this.txtPercAnticipoItaliaEstero.Size = new System.Drawing.Size(100, 20);
			this.txtPercAnticipoItaliaEstero.TabIndex = 63;
			this.txtPercAnticipoItaliaEstero.Tag = "itineration.advancepercentagetravel.fixed.4..%.100";
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(317, 112);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(88, 13);
			this.label64.TabIndex = 34;
			this.label64.Text = "% Anticipo Viaggi";
			// 
			// textBox24
			// 
			this.textBox24.Location = new System.Drawing.Point(414, 158);
			this.textBox24.Name = "textBox24";
			this.textBox24.Size = new System.Drawing.Size(100, 20);
			this.textBox24.TabIndex = 33;
			this.textBox24.TabStop = false;
			this.textBox24.Tag = "itineration.supposedcourse.c";
			this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label63
			// 
			this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label63.Location = new System.Drawing.Point(1, 157);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(341, 23);
			this.label63.TabIndex = 32;
			this.label63.Text = "Spese di iscrizione a convegno o corso (non soggette ad anticipo)";
			this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox23
			// 
			this.textBox23.Location = new System.Drawing.Point(96, 256);
			this.textBox23.Name = "textBox23";
			this.textBox23.Size = new System.Drawing.Size(172, 20);
			this.textBox23.TabIndex = 31;
			this.textBox23.TabStop = false;
			this.textBox23.Tag = "registrypaymethod.iban?x";
			this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label59
			// 
			this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label59.Location = new System.Drawing.Point(37, 255);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(57, 23);
			this.label59.TabIndex = 30;
			this.label59.Text = "IBAN";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.radioButton2);
			this.groupBox14.Controls.Add(this.radioButton3);
			this.groupBox14.Location = new System.Drawing.Point(193, 19);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(192, 40);
			this.groupBox14.TabIndex = 29;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Richiesta anticipo";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(58, 19);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(34, 17);
			this.radioButton2.TabIndex = 14;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "itineration.advanceapplied:S";
			this.radioButton2.Text = "Si";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(126, 19);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(39, 17);
			this.radioButton3.TabIndex = 15;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "itineration.advanceapplied:N";
			this.radioButton3.Text = "No";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// textBox22
			// 
			this.textBox22.Location = new System.Drawing.Point(414, 82);
			this.textBox22.Name = "textBox22";
			this.textBox22.Size = new System.Drawing.Size(100, 20);
			this.textBox22.TabIndex = 23;
			this.textBox22.TabStop = false;
			this.textBox22.Tag = "itineration.supposedamount";
			this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label58
			// 
			this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label58.Location = new System.Drawing.Point(316, 83);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(89, 23);
			this.label58.TabIndex = 22;
			this.label58.Text = "Importo presunto";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox21
			// 
			this.textBox21.Location = new System.Drawing.Point(168, 224);
			this.textBox21.Name = "textBox21";
			this.textBox21.Size = new System.Drawing.Size(100, 20);
			this.textBox21.TabIndex = 21;
			this.textBox21.TabStop = false;
			this.textBox21.Tag = "itineration.supposedfood.c";
			this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label57
			// 
			this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label57.Location = new System.Drawing.Point(37, 223);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(123, 23);
			this.label57.TabIndex = 20;
			this.label57.Text = "Costo presunto pasti";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox15
			// 
			this.textBox15.Location = new System.Drawing.Point(168, 200);
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(40, 20);
			this.textBox15.TabIndex = 19;
			this.textBox15.TabStop = false;
			this.textBox15.Tag = "itineration.nfood";
			this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label53
			// 
			this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label53.Location = new System.Drawing.Point(110, 200);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(50, 23);
			this.label53.TabIndex = 18;
			this.label53.Text = "N.Pasti";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(168, 129);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(100, 20);
			this.textBox17.TabIndex = 17;
			this.textBox17.TabStop = false;
			this.textBox17.Tag = "itineration.supposedliving.c";
			this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label54
			// 
			this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label54.Location = new System.Drawing.Point(1, 129);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(161, 23);
			this.label54.TabIndex = 16;
			this.label54.Text = "Costo presunto soggiorno";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(168, 106);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(100, 20);
			this.textBox18.TabIndex = 15;
			this.textBox18.TabStop = false;
			this.textBox18.Tag = "itineration.supposedtravel.c";
			this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label55
			// 
			this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label55.Location = new System.Drawing.Point(5, 106);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(153, 23);
			this.label55.TabIndex = 14;
			this.label55.Text = "Costo presunto viaggio";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(168, 82);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(100, 20);
			this.textBox20.TabIndex = 13;
			this.textBox20.TabStop = false;
			this.textBox20.Tag = "itineration.advancepercentage.fixed.4..%.100";
			this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label56
			// 
			this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label56.Location = new System.Drawing.Point(34, 82);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(127, 23);
			this.label56.TabIndex = 12;
			this.label56.Text = "Percentuale anticipo richiesta";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataOraInizio
			// 
			this.txtDataOraInizio.Location = new System.Drawing.Point(148, 38);
			this.txtDataOraInizio.Name = "txtDataOraInizio";
			this.txtDataOraInizio.Size = new System.Drawing.Size(160, 20);
			this.txtDataOraInizio.TabIndex = 29;
			this.txtDataOraInizio.Tag = "itineration.starttime.g";
			// 
			// txtDataOraTermine
			// 
			this.txtDataOraTermine.Location = new System.Drawing.Point(148, 70);
			this.txtDataOraTermine.Name = "txtDataOraTermine";
			this.txtDataOraTermine.Size = new System.Drawing.Size(160, 20);
			this.txtDataOraTermine.TabIndex = 32;
			this.txtDataOraTermine.Tag = "itineration.stoptime.g";
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(36, 70);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(100, 23);
			this.label61.TabIndex = 31;
			this.label61.Text = "Data/ora termine:";
			this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// myTip
			// 
			this.myTip.AutomaticDelay = 30;
			this.myTip.AutoPopDelay = 30000;
			this.myTip.InitialDelay = 30;
			this.myTip.ReshowDelay = 6;
			// 
			// Frm_itineration_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(971, 527);
			this.Controls.Add(this.tabCtrlMissione);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_itineration_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmmissione";
			this.tabCtrlMissione.ResumeLayout(false);
			this.tabGeneralita.ResumeLayout(false);
			this.tabGeneralita.PerformLayout();
			this.gboxRif.ResumeLayout(false);
			this.gboxRif.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxAction.ResumeLayout(false);
			this.gboxStato.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.grpPosGiuridica.ResumeLayout(false);
			this.grpPosGiuridica.PerformLayout();
			this.gboxDate.ResumeLayout(false);
			this.gboxDate.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpIncaricato.ResumeLayout(false);
			this.grpIncaricato.PerformLayout();
			this.tabTappeSpese.ResumeLayout(false);
			this.grpTappe.ResumeLayout(false);
			this.grpSpeseRendiconto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.grpSpese.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrSpeseTappe)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgrTappe)).EndInit();
			this.tabRitenute.ResumeLayout(false);
			this.tabRitenute.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.gboxRitDipendente.ResumeLayout(false);
			this.gboxRitDipendente.PerformLayout();
			this.gboxContrEnte.ResumeLayout(false);
			this.gboxContrEnte.PerformLayout();
			this.tabIndKm.ResumeLayout(false);
			this.tabIndKm.PerformLayout();
			this.grpIndMezzoAmm.ResumeLayout(false);
			this.grpIndMezzoAmm.PerformLayout();
			this.grpIndMezzoProprio.ResumeLayout(false);
			this.grpIndMezzoProprio.PerformLayout();
			this.grpIndAPiedi.ResumeLayout(false);
			this.grpIndAPiedi.PerformLayout();
			this.tabClassSuppl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).EndInit();
			this.tabCalcolo.ResumeLayout(false);
			this.tabCalcolo.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabEP.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.tabAnalitico.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.grpBoxSiopeEP.ResumeLayout(false);
			this.grpBoxSiopeEP.PerformLayout();
			this.gBoxCausaleDebitoCrg.ResumeLayout(false);
			this.gBoxCausaleDebitoCrg.PerformLayout();
			this.gBoxCausaleDebito.ResumeLayout(false);
			this.gBoxCausaleDebito.PerformLayout();
			this.gBoxCausaleCosto.ResumeLayout(false);
			this.gBoxCausaleCosto.PerformLayout();
			this.tabAnagPrest.ResumeLayout(false);
			this.grpBoxMotivo.ResumeLayout(false);
			this.grpBoxMotivo.PerformLayout();
			this.grpBoxDocAutorizzattivo.ResumeLayout(false);
			this.grpBoxDocAutorizzattivo.PerformLayout();
			this.grpBoxAutorizzazioneAP.ResumeLayout(false);
			this.grpBoxAutorizzazioneAP.PerformLayout();
			this.tabAutorizzazioni.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrAutorizzazioni)).EndInit();
			this.grpModelloAut.ResumeLayout(false);
			this.grpModelloAut.PerformLayout();
			this.tabPagamenti.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
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
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabDALIA.ResumeLayout(false);
			this.tabDALIA.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.gboxDipartimento.ResumeLayout(false);
			this.gboxDipartimento.PerformLayout();
			this.grpCausaliAssunzioneDalia.ResumeLayout(false);
			this.grpCausaliAssunzioneDalia.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.tabCTanticipo.ResumeLayout(false);
			this.grpAltro.ResumeLayout(false);
			this.grpAltro.PerformLayout();
			this.grpTratte.ResumeLayout(false);
			this.grpTratte.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			this.grpAnticipoTramiteCosti.ResumeLayout(false);
			this.grpAnticipoTramiteCosti.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        QueryHelper QHS;
        CQueryHelper QHC;
        IDataAccess Conn;
        private IFormController controller;
        private IMetaDataDispatcher dispatcher;
        private ISecurity security;
        private IHelpForm helpForm;

        DateTime DateSys;
        object idsorkindDalia;

        public void MetaData_AfterLink() {
            grpTappe.Enabled = false;
            Meta = this.getInstance<IMetaData>();
            Conn = this.getInstance<IDataAccess>();
            controller = this.getInstance<IFormController>();
			dispatcher = this.getInstance<IMetaDataDispatcher>();

			security = this.getInstance<ISecurity>();
            helpForm = controller.helpForm;
            GetData.CacheTable(DS.position);
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            idsorkindDalia = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");
            AccMotiveManager AM = new AccMotiveManager(gBoxCausaleCosto);
            AccMotiveManager AM01 = new AccMotiveManager(gBoxCausaleDebito);
            AccMotiveManager AM02 = new AccMotiveManager(gBoxCausaleDebitoCrg);
            //GetData.CacheTable(DS.tipoprestazione, "((visibilemissione is null)OR(visibilemissione='S'))","descrizione",true);
            GetData.CacheTable(DS.tax);
            HelpForm.SetDenyNull(DS.itineration.Columns["active"], true);
            HelpForm.SetDenyNull(DS.itineration.Columns["completed"], true);
            HelpForm.SetDenyNull(DS.itineration.Columns["flagweb"], true);

			string filterService = QHS.CmpEq("itinerationvisible", "S");
			GetData.SetStaticFilter(DS.service, filterService);

            HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["stoptime"], "g");
            HelpForm.SetFormatForColumn(DS.itinerationlap.Columns["starttime"], "g");
            string currsymbol = System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol;

            string filteresercizio = QHS.CmpEq("ayear", security.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.SetStaticFilter(DS.sortingview1, filteresercizio);


            string filterEpOperationSF = QHS.CmpEq("idepoperation", "missioni");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "missioni");

            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationSF = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationSF, Conn as DataAccess);
            filterEpOperationEP = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationEP, Conn as DataAccess);
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperationSF);
            DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "missioni_deb");
            filterEpOperationDeb = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDeb, Conn as DataAccess);
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");

            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");

            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, filteresercizio, null, null, true);
            if (tExpSetup == null || tExpSetup.Rows.Count == 0) {
                show("Configurazione annuale non trovata", "Errore");
                controller.ErroreIrrecuperabile = true;
                return;
            }

            DataRow R = tExpSetup.Rows[0];
            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            CfgFn.SetGBoxClass(this, 1, idsorkind1);
            CfgFn.SetGBoxClass(this, 2, idsorkind2);
            CfgFn.SetGBoxClass(this, 3, idsorkind3);
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                tabControl2.TabPages.Remove(tabAnalitico);
            }

            MetaData.SetDefault(DS.itineration, "iditinerationstatus", 6);
            MetaData.SetDefault(DS.itineration, "flagweb", "N");

            DataTable webconfig = Conn.RUN_SELECT("web_config", "*", null, null, null, false);
            bool askitinerationclause = false;
            string itinerationclause = "";

            if (webconfig.Rows.Count > 0) {
                DataRow rwebconf = webconfig.Rows[0];
                askitinerationclause = (rwebconf["askitinerationclause"].ToString().ToUpper() == "S");
                itinerationclause = (rwebconf["itinerationclause"].ToString());
            }

            if (!askitinerationclause) {
                txtClause.Visible = false;
                chkClauseMezzoProprio.Visible = false;
            }
            else {
                txtClause.Text = itinerationclause;
            }

            DS.itinerationstatus.ExtendedProperties["sort_by"] = "iditinerationstatus";
            string filterWeb = QHS.CmpEq("flagweb", "S");
            int count = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("itineration", filterWeb, "count(*)"));
            if (count == 0) {
                gboxAction.Visible = false;
                chkWeb.Visible = false;
                MakeSpaceFrom(gboxAction);

            }
            DataAccess.SetTableForReading(DS.itinerationrefund_advance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefund_balance, "itinerationrefund");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_advance, "itinerationrefundkind");
            DataAccess.SetTableForReading(DS.itinerationrefundkind_balance, "itinerationrefundkind");
            QueryCreator.SetTableForPosting(DS.itinerationrefund_advance, "itinerationrefund");
            QueryCreator.SetTableForPosting(DS.itinerationrefund_balance, "itinerationrefund");
            GetData.SetStaticFilter(DS.itinerationrefund_advance, QHS.CmpEq("flagadvancebalance", "A"));
            GetData.SetStaticFilter(DS.itinerationrefund_balance, QHS.CmpEq("flagadvancebalance", "S"));
            controller.CanInsertCopy = false;
            object oggi = Conn.DO_SYS_CMD("select getdate()");
            DateSys = (DateTime) oggi;
            HelpForm.SetDenyNull(DS.itineration.Columns["clause_accepted"], true);


            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");
            DataAccess.SetTableForReading(DS.sortingview1, "sortingview");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
                null, null, null, true);
            if (tUniConfig == null || tUniConfig.Rows.Count == 0) {
                show("Configurazione pluriennale non trovata", "Errore");
                controller.ErroreIrrecuperabile = true;
                return;
            }

			DataRow r = tUniConfig.Rows[0];
            object idsorkind01 = r["idsorkind01"];
            object idsorkind02 = r["idsorkind02"];
            object idsorkind03 = r["idsorkind03"];
            object idsorkind04 = r["idsorkind04"];
            object idsorkind05 = r["idsorkind05"];
            CfgFn.SetGBoxClass0(this, 1, idsorkind01);
            CfgFn.SetGBoxClass0(this, 2, idsorkind02);
            CfgFn.SetGBoxClass0(this, 3, idsorkind03);
            CfgFn.SetGBoxClass0(this, 4, idsorkind04);
            CfgFn.SetGBoxClass0(this, 5, idsorkind05);
            if (idsorkind01 == DBNull.Value && idsorkind02 == DBNull.Value &&
                idsorkind03 == DBNull.Value && idsorkind04 == DBNull.Value && idsorkind05 == DBNull.Value) {
                tabCtrlMissione.TabPages.Remove(tabAttributi);
            }

            EPM = new EP_Manager(Meta as MetaData, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP, labEP, null, "itineration");

            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);
        }

        siope_helper SiopeObj;

        void MakeSpaceFrom(GroupBox G) {
            TabPage T = (TabPage) G.Parent;
            int disp = G.Height;
            int y0 = G.Location.Y;
            T.SuspendLayout();
            foreach (Control C in T.Controls) {
                if (C.Location.Y < y0) continue;
                if ((C.Anchor & AnchorStyles.Bottom) == 0)
                    C.Location = new Point(C.Location.X, C.Location.Y - disp);
                else {
                    if ((C.Anchor & AnchorStyles.Top) != 0) {
                        C.Size = new Size(C.Size.Width, C.Size.Height + disp);
                        C.Location = new Point(C.Location.X, C.Location.Y - disp);
                    }
                }
            }
            //T.Size = new Size(F.Size.Width, F.Size.Height - disp);
            T.ResumeLayout();
        }

        public void calcNRifFilter() {
            MetaData.AutoInfo a = controller.GetAutoInfo(txtNRif.Name);
            if (controller.IsEmpty) {
                a.startfilter = null;
                return;
            }

            controller.GetFormData(true);
            var curr = DS.itineration[0];
            var YRif = 0;
            if (!string.IsNullOrEmpty(txtYRif.Text)) int.TryParse(txtYRif.Text, out YRif);
            string filter = YRif == 0 ? null : QHS.CmpEq("yitineration" , YRif);
            //if (curr.idreg.HasValue && curr.idreg!=0) filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", curr.idreg.Value));

            a.startfilter = filter;

        }

        public void MetaData_AfterClear() {
			EnableDisableAll(true);
			calcNRifFilter();
            abilitaDisabilitaControlliMissioneCollegata();

            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = true;
            AggiornaVoceSpesa();
            txtNummissione.ReadOnly = false;
            txtEsercmissione.ReadOnly = false;
            txtYRif.ReadOnly = false;
            txtNRif.ReadOnly = false;
            ImpostaTageFiltriUPB(DBNull.Value);
            txtDateCompleted.ReadOnly = false;
            EPM.mostraEtichette();
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
            btnAggiorna.Enabled = false;
            btnCambiaRuolo.Visible = false;
            txtEsercmissione.Text = security.GetSys("esercizio").ToString();
            txtQuotaEsenteMissione.Text = "";
            txtQuotaImponibileTappa.Text = "";
            lastcalcolaritenuteparams = null;
            ClearRitenute();
            ClearPosGiuridica();
            ClearImpEsente(false);
            ClearCalculated();
            btnSituazione.Enabled = false;
            btnToExcel.Enabled = false;
            azzeraTxtRitenute();
            VisualizzaEtichetteAP();
            mostraNascondiAutorizzazione();
            mostraNascondiMotivazione();
            grpBoxAutorizzazioneAP.Enabled = true;
            //Fill senza filtro della combo
            PostData.MarkAsRealTable((DataTable) cmbPrestazione.DataSource);
            GetData.CacheTable(DS.service, null, null, true);
            helpForm.PreFillControlsTable(cmbPrestazione, null);
            PostData.MarkAsTemporaryTable((DataTable) cmbPrestazione.DataSource, false);
            grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = 'S') AND (human='S') " +
								"AND (idreg IN(SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'S\') )) ) ";
            // il task 6807 prevede sia rimosso questo vincolo
            //  + "AND (idreg IN (SELECT idreg FROM registrytaxablestatus)))";
            controller.SetAutoMode(grpIncaricato);

            chkWeb.Enabled = true;
            gboxAction.Visible = true;

            btnAccetta.Visible = false;
            btnintegra.Visible = false;
            btnAnnulla.Visible = false;
            btnRiconsidera.Visible = false;
            btnAttesaAutorizzazione.Visible = false;
            btnInserisciAnticipo.Visible = false;
            cmbAuthModel.Enabled = true;
            cmbStatus.Enabled = true;
            SiopeObj.setCausaleEPCorrente(null);
            grpTratte.Enabled = false;
            txtDataOraInizio.Enabled = false;
            txtDataOraTermine.Enabled = false;
			grpAltro.Enabled = false;
        }

        private void azzeraTxtRitenute() {
            string empty = "";
            txtAssistenzialiDip.Text = empty;
            txtAssistenzialiEnte.Text = empty;
            txtPrevidenzialiDip.Text = empty;
            txtPrevidenzialiEnte.Text = empty;
            txtFiscaliDip.Text = empty;
            txtFiscaliEnte.Text = empty;
            txtAssicurativeDip.Text = empty;
            txtAssicurativeEnte.Text = empty;
            txtAltreDip.Text = empty;
            txtAltreEnte.Text = empty;
        }

        public bool SpeseAnticipoModificare() {
            if (controller.IsEmpty) return false;
            if (DS.itineration.Rows.Count == 0) return false;

            DataRow Curr = DS.itineration.Rows[0];
            if ((CfgFn.GetNoNullDecimal(Curr["supposedtravel"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedliving"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedfood"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedamount"]) > 0)) {
                foreach (DataRow R in DS.itinerationrefund_advance.Select()) {
                    if (CfgFn.GetNoNullDecimal(R["advancepercentage", DataRowVersion.Current]) != CfgFn.GetNoNullDecimal(R["advancepercentage", DataRowVersion.Original]))
                        return true;
                    if (CfgFn.GetNoNullDecimal(R["requiredamount", DataRowVersion.Current]) != CfgFn.GetNoNullDecimal(R["requiredamount", DataRowVersion.Original]))
                        return true;
                    if (CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Current]) != CfgFn.GetNoNullDecimal(R["amount", DataRowVersion.Original]))
                        return true;
                }
            }
            return false;
        }

        public void MetaData_BeforeFill() {
            PostData.MarkAsTemporaryTable((DataTable) cmbPrestazione.DataSource, false);
            if (DS.itineration.Rows.Count == 0) return;
            DataRow Curr = DS.itineration.Rows[0];
            int iditinerationstatus = CfgFn.GetNoNullInt32(Curr["iditinerationstatus"]);
            if (controller.InsertMode) {
                gboxAction.Visible = false;
            }

            if ((controller.EditMode) && (CheckWeb())) {

                AbilitaAnnotazioni(iditinerationstatus);        // Abilita o disabilita i controlli in tab Annotazioni

                //Abilita il salvataggio solo nel caso di "Inserito"=4

                controller.CanSave = (iditinerationstatus == 4 || iditinerationstatus == 6) && (!SpeseAnticipoModificare());
                btnAccetta.Visible = (iditinerationstatus == 2);
                btnintegra.Visible = (iditinerationstatus == 4);
                btnAttesaAutorizzazione.Visible = (iditinerationstatus == 4);
                if (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0) {
                    btnAttesaAutorizzazione.Width = 97;
                    btnAttesaAutorizzazione.Text = "Approva";
                }
                else {
                    btnAttesaAutorizzazione.Width = 244;
                    btnAttesaAutorizzazione.Text = "Poni In Attesa di Autorizzazione";
                }
                btnAnnulla.Visible = (iditinerationstatus == 4);
                btnRiconsidera.Visible = (iditinerationstatus == 6 || iditinerationstatus == 7);
                if ((iditinerationstatus == 5 || iditinerationstatus == 8) &&
                    (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "D")).Length == 0)) {
                    btnRiconsidera.Visible = true;
                }
                // missione approvata e in fase saldo, devo approvare gli importi delle spese a saldo
                // ponendola di nuovo nello stato "inserita"
                if ((iditinerationstatus == 6) &&
                    (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0) &&
                    (!getFaseAnticipoMissione())) {
                    btnRiconsidera.Visible = true;
                }


                // per le missioni inserite da web disabilitare l'inserimento delle spese
                btnInsertSpesaSaldo.Enabled = false;
                btnInsertSpesa.Enabled = false;

            }
            else {
                controller.CanSave = true;
            }

            if (getFaseAnticipoMissione(Curr["start"]) == false && getSimulatedFaseAnticipoMissione(Curr)) {
                controller.CanSave = false;
            }
			
			//if (Curr["completed"].ToString()== "S") {
			//	controller.CanSave = false;
			//}
            if (!controller.IsEmpty) {
                cmbStatus.Enabled = false;
                cmbAuthModel.Enabled = false;
            }

            if ((controller.EditMode) && (!CheckWeb()) &&
                (!getFaseAnticipoMissione()) &&
                (CfgFn.GetNoNullDecimal(Curr["totadvance", DataRowVersion.Original]) == 0) &&
                (DS.itinerationrefund_advance.Select().Length == 0)) {
                btnInserisciAnticipo.Visible = true;
            }
            else {
                btnInserisciAnticipo.Visible = false;
            }
		}

        bool CheckWeb() {
            if (controller.IsEmpty) return true;
            if (controller.InsertMode) return false;
            DataRow Curr = DS.itineration.Rows[0];
            object flagweb = Curr["flagweb"];

            if (flagweb != DBNull.Value) {
                return (flagweb.ToString().ToUpper() == "S");
            }
            else return false;

        }

        void checkAnticipiReadOnly() {
            if (controller.IsEmpty) return;
            AnticipoIsReadOnly = false;
            if (controller.EditMode) {
                DataRow Curr = DS.itineration.Rows[0];
                string filter = QHS.AppAnd(QHS.CmpMulti(Curr, "iditineration"),
                    QHS.CmpNe("movkind", 4));
                int N = Conn.RUN_SELECT_COUNT("expenseitineration", filter, false);
                filter = QHS.CmpMulti(Curr, "iditineration");
                N += Conn.RUN_SELECT_COUNT("pettycashoperationitineration", filter, false);
                if (N > 0) AnticipoIsReadOnly = true;
            }
            if (!getFaseAnticipoMissione()) AnticipoIsReadOnly = true;
        }


        public void mostraNascondiAutorizzazione() {
            if (DS.itineration.Rows.Count == 0) {
                grpBoxDocAutorizzattivo.Visible = false;
                ;
            }
            if (controller.IsEmpty) return;
            if (rdbNecessitaAutorizzazione.Checked) {
                grpBoxDocAutorizzattivo.Visible = true;
            }
            else {
                grpBoxDocAutorizzattivo.Visible = false;
                ;
            }
        }

        public void mostraNascondiMotivazione() {
            if (DS.itineration.Rows.Count == 0) {
                grpBoxMotivo.Visible = false;
                ;
            }

            if (controller.IsEmpty) return;
            if (rdbAutorizzazioneNonNecessaria.Checked) {
                grpBoxMotivo.Visible = true;
            }
            else {
                grpBoxMotivo.Visible = false;
                ;
            }
        }

        void avvisoAnagrafePrestazioni() {
            if (!controller.EditMode) return;
            //if (!Meta.FirstFillForThisRow) return;
            if (Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("yservreg", security.GetSys("esercizio")), false) == 0) return;
            //VisualizzaEtichetteAP();
            if (btnGeneraAP.Visible) {
                show("Ricordarsi di compilare la scheda Anagrafe prestazioni");
            }
        }

        private string CalcolaFiltroUPB() {
            if (txtResponsabile.Text == "") {
                return "";
            }
            string filter_upb = "";
            object idman = Meta.GetAutoField(txtResponsabile);
            if (idman != null && idman != DBNull.Value) {
                filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", idman));
            }
            return filter_upb;
        }

        private void ImpostaTageFiltriUPB(object idupbToinclude) {
            string upbfilter = CalcolaFiltroUPB();
            string filteradd = upbfilter;
            string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

            if (idupbToinclude != DBNull.Value && upbfilter != "") {
                filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
            }

            GetData.SetStaticFilter(DS.upb, filteradd);

            if (upbfilter != "") {
                btnUPBCode.Tag = "choose.upb.default." + filteractive;
            }
            else {
                btnUPBCode.Tag = "manage.upb.tree";
            }

            if (gboxUPB.Tag != null)
                gboxUPB.Tag = "AutoChoose.txtUPB.default." + filteractive;
            controller.SetAutoMode(gboxUPB);
        }

        void abilitaDisabilitaControlliMissioneCollegata() {
            if ((controller.EditMode || controller.InsertMode) && txtNRif.Text != "") {
                grpIncaricato.Enabled = false;
                gboxDate.Enabled = false;
                //gboxResponsabile.Enabled = false;
                txtLocation.ReadOnly = true;
                cmbPrestazione.Enabled = false;
                btnPrestazione.Enabled = false;
            }
            else {
                grpIncaricato.Enabled = true;
                gboxDate.Enabled = true;
                //gboxResponsabile.Enabled = true;
                txtLocation.ReadOnly = false;
                cmbPrestazione.Enabled = true;
                btnPrestazione.Enabled = true;
            }
        }

        public void MetaData_AfterFill() {
            chkWeb.Enabled = false;
            abilitaDisabilitaDalia(null);
            calcNRifFilter();
            abilitaDisabilitaControlliMissioneCollegata();

            cmb_dalia_position.Enabled = false;
            AggiornaVoceSpesa();
            txtNummissione.ReadOnly = true;
            txtEsercmissione.ReadOnly = true;
            txtYRif.ReadOnly = true;
            if (!controller.InsertMode) {
                txtNRif.ReadOnly = true;
            }

            EPM.mostraEtichette();
            if (EPM.esistonoScrittureCollegate()) {
                txtDateCompleted.ReadOnly = true;
            }
            else {
                txtDateCompleted.ReadOnly = false;
            }
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
            if (controller.EditMode && controller.firstFillForThisRow) AggiornaSoloInformazioni();

            ImpostaTageFiltriUPB(DBNull.Value);

            // Se non esiste l'indirizzo AP, sarà obbligatorio lasciare impostato il valore di default che sarà X, ossia non applicabile.
            if (!EsisteIndirizzoAP()) {
                grpBoxAutorizzazioneAP.Enabled = false;
            }
            else {
                // se esiste l'indirizzo AP va selezionata l'autorizzazione come S o come N:
                grpBoxAutorizzazioneAP.Enabled = true;
            }
            mostraNascondiAutorizzazione();
            mostraNascondiMotivazione();

            checkAnticipiReadOnly();
            EnableDisableRefund();

            btnAggiorna.Enabled = true;
            if (controller.firstFillForThisRow) VisualizzaBtnCambiaRuolo();

            btnDelTappa.Enabled = true;
            if (controller.firstFillForThisRow && controller.EditMode) DetectPosGiuridica();

            CalcolaRitenute(false);
            RicalcolaRimborsiKilometrici();
            CalcolaTotaliMissione();
            RicalcolaTotaliRitenute();
            btnSituazione.Enabled = controller.EditMode;
            btnToExcel.Enabled = true;

            if (controller.firstFillForThisRow && controller.EditMode) {
                VisualizzaEtichetteAP();
            }
            setDateInizioFineSpesa();

            if ((!controller.IsEmpty) && (controller.firstFillForThisRow)) {
                grpIncaricato.Tag = "AutoChoose.txtIncaricato.default.((active = 'S') AND (human='S') AND " +
									" (idreg IN (SELECT idreg FROM registrylegalstatus WHERE idposition IS NOT NULL and (active = \'S\') ))  " +
                                    // task 6807 richiede la rimozione di questo vincolo
                                    //" AND (idreg IN (SELECT idreg FROM registrytaxablestatus))  " +
                                    " )";
                controller.SetAutoMode(grpIncaricato);
            }
            DataRow curr = DS.itineration.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive"]);
            grpTratte.Enabled = AbilitaRichiestaAnticipo();
			model.MarkTableAsNotEntityChild(DS.itineration, DS.itinerationrefundattachment);
			
			if (chkPagabile.CheckState == CheckState.Checked) {
				//disabilita tutto, la missione è solo consultabile ma non si può modificare niente
				EnableDisableAll(false);
			}
			grpAltro.Enabled = false;
		}

		public void EnableDisableAll(bool abilita) {
			//Qui abilita o disabilita tutto
			//foreach (TabPage T in tabCtrlMissione.Controls) {
			//	foreach (Control c in T.Controls) {
			//		c.Enabled = abilita;
			//	}
			//}
			////Qui va a rifinire il lavoro, cioè se Abilita è true, non lo esegue. Vale quello di sopra.
			////Se Abilita è false, vuol dire che sta disabilitando tutto, però deve abilitare i button Edit dei DataGrid
			//if (!abilita) {
			//	grpTappe.Enabled =  true;
			//	btnEditTappa.Enabled = true;
			//	btnInsertTappa.Enabled = false;
			//	btnDelTappa.Enabled = false;

			//	grpSpese.Enabled = true;
			//	btnInsertSpesa.Enabled = false;
			//	btnEditSpesa.Enabled = true;
			//	btnDelSpesa.Enabled = false;

			//	grpSpeseRendiconto.Enabled = true;
			//	btnInsertSpesaSaldo.Enabled = false;
			//	btnEditSpesaSaldo.Enabled = true;
			//	btnDeleteSpesaSaldo.Enabled = false;
			//	btnClassModifica.Enabled = true;
			//	button3.Enabled = true;
			//	tabControl2.Enabled = true;
			//	foreach (TabPage T in tabControl2.Controls) {
			//		foreach (Control c in T.Controls) {
			//			c.Enabled = abilita;//mette a false tutti i controlli del Tab secondario
			//		}
			//	}
			//}
			//else {
			//	btnInsertTappa.Enabled = true;
			//	btnDelTappa.Enabled = true;
			//	btnInsertSpesa.Enabled = true;
			//	btnDelSpesa.Enabled = true;
			//	btnInsertSpesaSaldo.Enabled = true;
			//	btnDeleteSpesaSaldo.Enabled = true;
			//}
			return;
		}

        public void MetaData_BeforePost() {
			if (DS.itineration.Rows.Count == 0) {
				DS.itinerationattachment.Clear();
				return; 
			}
			var R = DS.itineration.Rows[0];
			if (R.RowState == DataRowState.Deleted) {
				foreach (var A in DS.itinerationattachment.Select()) {
					if (A.RowState != DataRowState.Deleted)
						A.Delete();
				}
			}
			string filterAttachment = "";
			//Se ci sono spese di anticipo cancellato, prende la chiave.
			if (DS.itinerationrefund_advance.Rows.Count > 0) {
				foreach (var A in DS.itinerationrefund_advance) {
					if (A.RowState == DataRowState.Detached || A.RowState == DataRowState.Deleted) {
						filterAttachment = QHS.DoPar(QHS.AppOr(filterAttachment, QHS.CmpKey(A)));
					}
				}
			}
			//Se ci sono spese a rendiconto cancellate, prende la chiave.
			if (DS.itinerationrefund_balance.Rows.Count > 0) {
				foreach (var A in DS.itinerationrefund_balance) {
					if (A.RowState == DataRowState.Detached || A.RowState == DataRowState.Deleted) {
						filterAttachment = QHS.DoPar(QHS.AppOr(filterAttachment, QHS.CmpKey(A)));
					}
				}
			}
			//Se il filtro è stato valorizzato vuol dire che alcune spese sono in cancellazione, quindi calcella gli allegati ad esse associati.
			if ((filterAttachment != "") && DS.itinerationrefundattachment.Rows.Count>0 ) {
				foreach (var Ritinerationrefundattachment in DS.itinerationrefundattachment.Select(filterAttachment)) {
					if (Ritinerationrefundattachment.RowState != DataRowState.Deleted)
						Ritinerationrefundattachment.Delete();
				}
			}

			EPM.beforePost();
            //non imposto più in automatico quel flag se ci sono spese a saldo, sotto richiesta di Emilia
            //DataRow Curr = DS.itineration.Rows[0];        
            //if (Curr.RowState != DataRowState.Deleted) {
            //    int iditinerationstatus = CfgFn.GetNoNullInt32(Curr["iditinerationstatus"]);
            //    object completed = Curr["completed"];
            //    if ((iditinerationstatus == 6) && (DS.itinerationrefund_balance.Select().Length > 0) &&
            //        (completed.ToString().ToUpper() != "S")) {
            //        Curr["completed"] = "S";
            //    }
            //}
        }

        public void VisualizzaBtnCambiaRuolo() {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];

            string filter;

            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];
            DateTime SqlServerSafeDate = QHS.SafeMinDate();
            if ((datainizio == DBNull.Value)
                || (((DateTime) datainizio) == QueryCreator.EmptyDate())
                || ((DateTime) datainizio) < SqlServerSafeDate) {
                return;
            }
            if (((DateTime) datainizio).Year < 1900) datainizio = new DateTime(1900, 1, 1);
            if ((datafine == DBNull.Value)
                || (((DateTime) datafine) == QueryCreator.EmptyDate())
                || ((DateTime) datafine) < SqlServerSafeDate) {
                return;
            }

            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                return;
            }

            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime) datafine, true);

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio),
                QHS.NullOrGe("stop", datafine));

            int NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);
            if (NposGiuridiche > 1)
                btnCambiaRuolo.Visible = true;
            else
                btnCambiaRuolo.Visible = false;

        }

        public void MetaData_AfterPost() {

            EPM.afterPost();
            if (DS.itineration.Rows.Count > 0 && EPM.UsaImpegniDiBudget) {
                DataRow curr = DS.itineration.Rows[0];
                if (curr.RowState == DataRowState.Unchanged && EPM.impegniAbilitati(curr)) {
                    int nEpExp = Conn.RUN_SELECT_COUNT("epexp",
                        QHS.CmpEq("idrelated", $"itineration§{curr["iditineration"]}"), false);
                    if (nEpExp == 0) {
                        nEpExp = Conn.RUN_SELECT_COUNT("epexp",
                            QHS.Like("idrelated", $"itineration§{curr["iditineration"]}§%"), false);
                    }
                    if (nEpExp == 0) {
                        curr["completed"] = "N";
                        controller.FreshForm(true, false);
                        Meta.SaveFormData();
                        show(this,
                            "Non avendo generato gli impegni di budget, è stato rimosso il flag 'Considera eseguito quindi pagabile'",
                            "Avviso");
                    }
                }
            }
            if (DS.itineration.Rows.Count > 0) {
                VisualizzaEtichetteAP();
                avvisoAnagrafePrestazioni();
            }

        }

        void ClearCalculated() {
            txtClassStip.Text = "";
            txtQualifica.Text = "";
            txtDecorrClassStip.Text = "";
            txtMatricola.Text = "";
            txtGruppoEstero.Text = "";
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!controller.DrawStateIsDone) return;
            if (T.TableName == "manager") {
                ImpostaTageFiltriUPB(DBNull.Value);
            }
            if (T.TableName == "registry") {
                if (!controller.IsEmpty) {
                    if (R == null) {
                        ClearCalculated();
                        return;
                    }

                    object idaccmotivedebit = R["idaccmotivedebit"];
                    bool scegliDalia = true;
                    GeneraSelect(txtIncaricato);
                    // Se cambia l'anagrafica imposta il valore di default X
                    DataRow Curr = DS.itineration.Rows[0];
                    Curr["authneeded"] = "X";
                    rdbNonApplicabile.Checked = true;
                    if (scegliDalia) {
                        selezionaQualificaDalia(true);
                    }

                    Curr["idaccmotivedebit"] = idaccmotivedebit;
                    DS.accmotiveapplied_debit.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
                        (q.eq("idaccmotive", idaccmotivedebit) & q.eq("idepoperation", "missioni_deb")).toSql(QHS), null, false);
                    Meta.helpForm.FillControls(gBoxCausaleDebito.Controls);

                }
            }
            if (T.TableName == "sortingview1") {
                if (R == null) return;
                if (controller.IsEmpty) return;
                selezionaVoceSpesaDalia(R["idsor"]);
                return;
            }
            if (T.TableName == "service") {
                abilitaDisabilitaDalia(R);
                if (!controller.IsEmpty) {
                    if (R == null) {
                        ClearCalculated();
                        return;
                    }
                    GeneraSelect(cmbPrestazione);
                }
            }
            if (T.TableName == "accmotiveapplied_cost") {
                if (controller.IsEmpty) return;
                SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                SiopeObj.selectSiope();
            }

            if (T.TableName == "itineration_riferimento" && controller.DrawStateIsDone && controller.InsertMode && R != null) {
                controller.GetFormData(true);
                DataRow current = DS.itineration.Rows[0];
                current["idreg"] = R["idreg"];
                current["start"] = R["start"];
                current["stop"] = R["stop"];
                current["adate"] = R["adate"];
                current["authorizationdate"] = R["authorizationdate"];
                current["idman"] = R["idman"];
                current["location"] = R["location"];
                current["description"] = R["description"];
                current["idser"] = R["idser"];
                current["idregistrylegalstatus"] = R["idregistrylegalstatus"];
                controller.FreshForm(true, false);
                setDateInizioFineSpesa();
                checkAnticipiReadOnly();
                EnableDisableRefund();
                AggiornaSoloInformazioni();
                //current[""]
            }
        }

        void clearAutorizzazioni() {
            foreach (DataRow R in DS.itinerationauthagency.Select()) R.Delete();
        }

        void GeneraAutorizzazioni() {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];
            //Aggiorna / Crea le righe nella Tabella Autorizzazioni in base al Modello Autorizzativo selezionato
            MetaData MetaAutorizzazione = MetaData.GetMetaData(this, "itinerationauthagency");
            MetaAutorizzazione.SetDefaults(DS.itinerationauthagency);

            DataTable authModelAuthAgency = Conn.RUN_SELECT("authmodelauthagency", null, null,
                QHS.CmpEq("idauthmodel", cmbAuthModel.SelectedValue), null, true);
            //Elimina dalla tabella Autorizzazioni le righe che non saranno utilizzate
            DS.itinerationauthagency.RejectChanges();
            foreach (DataRow Existing in DS.itinerationauthagency.Select()) {
                if (Existing.RowState == DataRowState.Deleted) continue;
                object codiceold = Existing["idauthagency"];
                if (authModelAuthAgency == null ||
                    authModelAuthAgency.Select(QHC.CmpEq("idauthagency", codiceold)).Length == 0) {
                    Existing.Delete();
                }
            }

            foreach (DataRow Row in authModelAuthAgency.Rows) {
                DataRow[] Found = DS.itinerationauthagency.Select(QHC.CmpEq("idauthagency", Row["idauthagency"]));
                DataRow MissAut;
                if (Found.Length == 0) {
                    MissAut = MetaAutorizzazione.Get_New_Row(Curr, DS.itinerationauthagency);
                    MissAut["idauthagency"] = Row["idauthagency"];
                }
                else {
                    MissAut = Found[0];
                }
                MissAut["flagstatus"] = "D";
            }

        }

        public bool AbilitaRichiestaAnticipo() {
            if (controller.IsEmpty) return false;
            if (DS.itineration.Rows.Count == 0) return false;
            DataRow Curr = DS.itineration.Rows[0];
            if ((CfgFn.GetNoNullDecimal(Curr["supposedtravel"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedliving"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedfood"]) > 0)
                || (CfgFn.GetNoNullDecimal(Curr["supposedamount"]) > 0)) {
                return true;
            }
            return false;
        }
        void EnableDisableRefund() {
            bool AnticipoInseritoTramiteCosti = AbilitaRichiestaAnticipo();
            btnInsertSpesa.Enabled = !AnticipoIsReadOnly && !AnticipoInseritoTramiteCosti; // ((!AnticipoIsReadOnly) && (!CheckWeb()));
            btnDelSpesa.Enabled = !AnticipoIsReadOnly && !AnticipoInseritoTramiteCosti;
            grpAnticipoTramiteCosti.Enabled = !AnticipoIsReadOnly && AnticipoInseritoTramiteCosti;
            //btnEditSpesa.Enabled = !AnticipoIsReadOnly;
            btnInsertSpesaSaldo.Enabled = ((AnticipoIsReadOnly) && (!getFaseAnticipoMissione())); //&& (!CheckWeb())
            btnEditSpesaSaldo.Enabled = AnticipoIsReadOnly;
            btnDeleteSpesaSaldo.Enabled = AnticipoIsReadOnly;
        }

        #region Gestione controlli calcolati in base a creddeb/prestazione/datainizio

        string lastcalcolaritenuteparams = null;
        DataSet LastOutCalcolaRitenute = null;

        void ClearRitenute() {
            RicalcolaRitenuteMissione(null);
        }

        void DescribeGridRitenute(DataTable T) {
            foreach (DataColumn C in T.Columns) C.Caption = "";
            T.Columns["description"].Caption = "Ritenuta";
            T.Columns["description"].ExtendedProperties["ListColPos"] = 1;
            T.Columns["adminrate"].Caption = "Aliquota Amministrazione";
            HelpForm.SetFormatForColumn(T.Columns["adminrate"], "p");
            T.Columns["adminrate"].ExtendedProperties["ListColPos"] = 3;
            T.Columns["employrate"].Caption = "Aliquota Dipendente.";
            HelpForm.SetFormatForColumn(T.Columns["employrate"], "p");
            T.Columns["employrate"].ExtendedProperties["ListColPos"] = 2;
        }

        string CalcolaFlagPerRitenute() {
            DataRow Curr = DS.itineration.Rows[0];
            object datainizio = Curr[MissFun.CampoDataPerRitenute];
            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                return "";
            }
            string ritenuteparams = Curr["idreg"].ToString() + "#" + Curr["idser"].ToString() +
                                    "#" + Curr[MissFun.CampoDataPerRitenute].ToString();
            return ritenuteparams;

        }

        DataSet OttieniTabellaRitenuteARitroso() {
            DataSet DD = new DataSet();
            DataTable T = new DataTable("ritenute");
            T.Columns.Add("taxcode", typeof(int));
            T.Columns.Add("description", typeof(string));
            T.Columns.Add("taxablenumerator", typeof(double));
            T.Columns.Add("taxabledenominator", typeof(double));
            T.Columns.Add("employrate", typeof(double));
            T.Columns.Add("employnumerator", typeof(double));
            T.Columns.Add("employdenominator", typeof(double));
            T.Columns.Add("adminrate", typeof(double));
            T.Columns.Add("adminnumerator", typeof(double));
            T.Columns.Add("admindenominator", typeof(double));
            //T.Columns.Add("flagunabatable", typeof(string));
            DD.Tables.Add(T);

            DD.EnforceConstraints = false;
            foreach (DataRow R in DS.itinerationtax.Rows) {
                DataRow RR = T.NewRow();
                RR["taxcode"] = R["taxcode"];
                try {
                    RR["description"] = DS.tax.Select(QHC.CmpEq("taxcode", R["taxcode"]))[0]["description"];
                }
                catch {
                    RR["description"] = "";
                }

                RR["taxablenumerator"] = R["taxablenumerator"];
                RR["taxabledenominator"] = R["taxabledenominator"];
                RR["employrate"] = R["employrate"];
                RR["employnumerator"] = R["employnumerator"];
                RR["employdenominator"] = R["employdenominator"];
                RR["adminrate"] = R["adminrate"];
                RR["adminnumerator"] = R["adminnumerator"];
                RR["admindenominator"] = R["admindenominator"];
                //RR["flagunabatable"]=R["flagunabatable"];
                T.Rows.Add(RR);
            }
            return DD;
        }

        void resetPosizioneGiuridica() {
            MyCfg.idposition = DBNull.Value;
			MyCfg.livello = DBNull.Value;
			MyCfg.foreignclass = "";
            grpTappe.Enabled = false;
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];
            Curr["idregistrylegalstatus"] = DBNull.Value;
        }

        void setPosizioneGiuridica(object idposition, object livello) {
            MyCfg.idposition = idposition;
			MyCfg.livello = livello;
            if (DS.position.Select(QHC.CmpEq("idposition", idposition)).Length > 0) {
                MyCfg.foreignclass =
                    DS.position.Select(QHC.CmpEq("idposition", idposition))[0]["foreignclass"].ToString().ToUpper();
            }
            else {
                MyCfg.foreignclass = "";
            }
            grpTappe.Enabled = true;
        }

        void setDateInizioFineSpesa() {
            if (controller.IsEmpty) return;

            object datainizio;
            object datafine;
            if (DataValida(txtDataInizio.Text.ToString())) {
                datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text,
                    txtDataInizio.Tag.ToString());
            }
            else return;

            if (DataValida(txtDataFine.Text.ToString())) {
                datafine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            }
            else return;
            MetaData.SetDefault(DS.itinerationrefund_advance, "starttime", datainizio);
            MetaData.SetDefault(DS.itinerationrefund_advance, "stoptime", datafine);
            MetaData.SetDefault(DS.itinerationrefund_advance, "flagadvancebalance", "A");
            MetaData.SetDefault(DS.itinerationrefund_balance, "starttime", datainizio);
            MetaData.SetDefault(DS.itinerationrefund_balance, "stoptime", datafine);
            MetaData.SetDefault(DS.itinerationrefund_balance, "flagadvancebalance", "S");
        }

        private bool getSimulatedFaseAnticipoMissione(DataRow itineration) {
            if (itineration == null || itineration.RowState == DataRowState.Deleted) return true;
            if (itineration["start"] == DBNull.Value) return true;
            DateTime start = (DateTime) itineration["start"];
            DateTime datacontabile = (DateTime) security.GetSys("datacontabile");
            if (datacontabile < (DateTime) start) return true;
            if (DateSys < start) return true;
            return false;
        }

        bool getFaseAnticipoMissione() {
            if (controller.IsEmpty) return false;
            bool phase = false;
            //DateTime datacontabile = (DateTime)Meta.GetSys("datacontabile");
            object datainizio;
            if (DataValida(txtDataInizio.Text.ToString())) {
                datainizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text,
                    txtDataInizio.Tag.ToString());
            }
            else {
                return false;
            }

            //if (datacontabile < (DateTime)datainizio) phase = true;
            if (DateSys < (DateTime) datainizio) phase = true;

            return phase;
        }

        bool getFaseAnticipoMissione(object Date) {
            if (Date == DBNull.Value || Date == null) return false;
            bool phase = false;
            //DateTime datacontabile = (DateTime)Meta.GetSys("datacontabile");
            DateTime datainizio = (DateTime) Date;

            //if (datacontabile < (DateTime)datainizio) phase = true;
            if (DateSys < datainizio) phase = true;

            return phase;
        }

        bool DataValida(string date) {
            try {
                DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
                    date, "x.y");
                return true;
            }
            catch {
                return false;
            }
        }

        void AggiornaSoloInformazioni() {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];

            string filter;
            string sorting;
            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
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

            //string currcodicerapporto = null;

            //sorting = "start DESC";

            //DataTable SelClass = Conn.RUN_SELECT("legalstatuscontract",
            //    "idposition, incomeclass, incomeclassvalidity, maxincomeclass", 
            //    sorting, filter, "1", false);



            string filtroInquadramento = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                QHS.CmpEq("idregistrylegalstatus", Curr["idregistrylegalstatus"]));
            DataTable SelClass = Conn.RUN_SELECT("legalstatuscontract",
                "idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                null, filtroInquadramento, null, false);

            if (SelClass.Rows.Count == 0) {
                if (LastFilterPosGiuridica != filter) {
                    show(
                        "I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");
                }
                ClearInformazioni();
                LastFilterPosGiuridica = filter;
                return;
            }
            LastFilterPosGiuridica = filter;

            DataRow RowClass = SelClass.Rows[0];
            txtRuoloCSA.Text = RowClass["csa_role"].ToString();
            txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
            txtInquadrcsa.Text = RowClass["csa_class"].ToString();

            //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
            object currflagquotaesente = "S";



            //FiltraComboPrestazioneInBaseANiente(false);
            object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");
            int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            txtClassStip.Text = incomeclass.ToString();
            setPosizioneGiuridica(RowClass["idposition"], RowClass["livello"]);
            MyCfg.matricula = matricula;
            MyCfg.incomeclass = incomeclass;
            MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

            object codicequalifica = RowClass["idposition"];
            //string codicerapporto = currcodicerapporto;

            DataRow[] Q = DS.position.Select(QHC.CmpEq("idposition", codicequalifica));
            if (Q.Length > 0) {
                txtQualifica.Text = Q[0]["description"].ToString();
            }


            txtDecorrClassStip.Text = HelpForm.StringValue(MyCfg.incomeclassvalidity, "x.y.d");
            txtMatricola.Text = MyCfg.matricula.ToString();

            //Classe attuale
            int classe, maxclassestip;
            classe = CfgFn.GetNoNullInt32(incomeclass);
            maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
            if (classe <= maxclassestip) {
                txtClassStip.Text = classe.ToString();
                MyCfg.incomeclass = classe;
            }
            else {
                txtClassStip.Text = maxclassestip.ToString();
                MyCfg.incomeclass = maxclassestip;
            }
            bool AzzeraImportoEsente;
            if (currflagquotaesente.ToString().ToUpper() == "S")
                AzzeraImportoEsente = false;
            else
                AzzeraImportoEsente = true;

            labQuotaEsente.Visible = AzzeraImportoEsente;

            datainizio = Curr[MissFun.CampoDataPerGeneralita];


            filter = QHS.CmpLe("start", datainizio);

            sorting = "start DESC";
            DataTable Generalita = Conn.RUN_SELECT("itinerationparameter",
                "start, italianexemption,foreignexemption",
                sorting, filter, "1", false);
            if (Generalita.Rows.Count == 0) {
                show("In Generalità Missioni non è stata trovata alcuna informazione", "Avviso");
                MyCfg.italianexemption = 0;
                MyCfg.foreignexemption = 0;
                MyCfg.foreignhours = 0;

            }
            else {
                DataRow RowGen = Generalita.Rows[0];
                MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);
                txtImpEsenteItalia.Text = HelpForm.StringValue(
                    MyCfg.italianexemption, txtImpEsenteItalia.Tag.ToString());

                MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
                if (AzzeraImportoEsente) MyCfg.foreignexemption = 0;
                txtImpEsenteEstero.Text = HelpForm.StringValue(
                    MyCfg.foreignexemption, txtImpEsenteEstero.Tag.ToString());

                if (DS.config.Rows.Count > 0) {
                    DataRow CurrSetup = DS.config.Rows[0];
                    MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
                }
            }




            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
                QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
                "max(idforeigngrouprule)");
            //imposta il gruppo estero
            string filterGE;
            filterGE = QHS.AppAnd(
                QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                QHS.CmpEq("idposition", MyCfg.idposition),
				QHS.NullOrEq("livello", MyCfg.livello),
				//QHS.CmpEq("livello", MyCfg.livello),
				"(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");

            DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber",
                null, filterGE, "1", false);
            if (DettGruppoEstero.Rows.Count == 0) {
                MyCfg.foreigngroupnumber = DBNull.Value;
                txtGruppoEstero.Text = "";
                show("I dati relativi al gruppo estero sono incompleti o mancanti", "Avviso");
            }
            else {
                MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
                txtGruppoEstero.Text = MyCfg.foreigngroupnumber.ToString();
            }
            SetExtraParameterForDetails();

        }

        private void CalcolaRitenute(bool ForceRecalc) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];

            object datainizio = Curr[MissFun.CampoDataPerRitenute];
            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate()) ||
                (CfgFn.GetNoNullInt32(Curr["idser"]) == 0)
                ) {
                ClearRitenute();
                return;
            }
            string ritenuteparams = CalcolaFlagPerRitenute();
            if ((LastOutCalcolaRitenute == null) ||
                (ritenuteparams != lastcalcolaritenuteparams)) {
                lastcalcolaritenuteparams = ritenuteparams;
                object idreg = Curr["idreg"];
                object supposedIncome = Conn.DO_SYS_CMD(
                    "SELECT TOP 1 supposedincome FROM registrytaxablestatus  WHERE " +
                    QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpLe("start", datainizio)) +
                    " ORDER BY start DESC ", true);
                if (supposedIncome == null || supposedIncome == DBNull.Value) {
                    show(
                        "I dati relativi alla posizione retributiva dell'incaricato sono incomplete o mancanti. Il reddito presunto considerato sarà pari a zero.",
                        "Avviso");
                }

                LastOutCalcolaRitenute = Conn.CallSP("compute_taxrate",
                    new object[] { Curr["idreg"], Curr["idser"], Curr[MissFun.CampoDataPerRitenute] });
            }
            if ((LastOutCalcolaRitenute == null) || (LastOutCalcolaRitenute.Tables.Count == 0)) {
                ClearRitenute();
                return;
            }
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges() || ForceRecalc) {
                RicalcolaRitenuteMissione(LastOutCalcolaRitenute.Tables[0]);
                SetExtraParameterForDetails();
            }
            else {
                decimal coefflord = CfgFn.GetNoNullDecimal(Curr["grossfactor"]);
                txtCoeffLord.Text = HelpForm.StringValue(coefflord, "x.y.fixed.6...1");
            }
        }


        string LastImpEsenteFilter;

        void ClearImpEsente(bool _readonly) {
            LastImpEsenteFilter = "";
            txtImpEsenteItalia.Text = "";
            txtImpEsenteEstero.Text = "";
            labQuotaEsente.Visible = false;
            if (controller.IsEmpty) return;
            if (!_readonly) CalcolaRitenute(true);
        }


        CfgItineration MyCfg = new CfgItineration();

        /// <summary>
        /// Calcola i txtImpesenteItalia/estero in base alla datainizio della riga corrente
        /// </summary>
        private void ImpostaImpEsente(bool AzzeraImportoEsente) {
            if (controller.IsEmpty) return;

            labQuotaEsente.Visible = AzzeraImportoEsente;

            controller.GetFormData(true);
            DataRow Curr = DS.itineration.Rows[0];
            string filter, sorting;
            object datainizio = Curr[MissFun.CampoDataPerGeneralita];
            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                ClearImpEsente(false);
                return;
            }

            filter = QHS.CmpLe("start", datainizio);
            if (filter == LastImpEsenteFilter) return;
            LastImpEsenteFilter = filter;

            sorting = "start DESC";
            DataTable Generalita = Conn.RUN_SELECT("itinerationparameter",
                "start, italianexemption,foreignexemption",
                sorting, filter, "1", false);
            if (Generalita.Rows.Count == 0) {
                show("In Generalità Missioni non è stata trovata alcuna informazione", "Avviso");
                return;
            }
            DataRow RowGen = Generalita.Rows[0];

            ///TODO: Assegnare impkm vari - solo la prima volta in fase di insert
            ///

            //txtEurKmAPiedi.Text = HelpForm.StringValue( 
            //    CfgFn.GetNoNullDecimal(RowGen["footkmcost"]), txtEurKmAPiedi.Tag.ToString());
            //txtEurKmMezzoAmm.Text = HelpForm.StringValue(
            //    CfgFn.GetNoNullDecimal( RowGen["admincarkmcost"]),txtEurKmMezzoAmm.Tag.ToString());
            //txtEurKmMezzoProprio.Text = HelpForm.StringValue(
            //    CfgFn.GetNoNullDecimal(RowGen["owncarkmcost"]),txtEurKmMezzoProprio.Tag.ToString());

            //Curr["owncarkmcost"]= RowGen["owncarkmcost"];
            //Curr["admincarkmcost"]= RowGen["admincarkmcost"];
            //Curr["footkmcost"]= RowGen["footkmcost"];

            MyCfg.italianexemption = CfgFn.GetNoNullDecimal(RowGen["italianexemption"]);
            if (AzzeraImportoEsente) MyCfg.italianexemption = 0;
            txtImpEsenteItalia.Text = HelpForm.StringValue(
                MyCfg.italianexemption, txtImpEsenteItalia.Tag.ToString());

            MyCfg.foreignexemption = CfgFn.GetNoNullDecimal(RowGen["foreignexemption"]);
            if (AzzeraImportoEsente) MyCfg.foreignexemption = 0;
            txtImpEsenteEstero.Text = HelpForm.StringValue(
                MyCfg.foreignexemption, txtImpEsenteEstero.Tag.ToString());

            if (DS.config.Rows.Count > 0) {
                DataRow CurrSetup = DS.config.Rows[0];
                MyCfg.foreignhours = CfgFn.GetNoNullDecimal(CurrSetup["foreignhours"]);
            }
            CalcolaRitenute(true);
            SetExtraParameterForDetails();
        }


        string LastFilterPosGiuridica;

        void ClearInformazioni() {
            LastFilterPosGiuridica = "";
            txtClassStip.Text = "";
            txtQualifica.Text = "";
            txtDecorrClassStip.Text = "";
            txtMatricola.Text = "";
            txtRuoloCSA.Text = "";
            txtCompartoCSA.Text = "";
            txtInquadrcsa.Text = "";
            btnCambiaRuolo.Visible = false;
            MyCfg.incomeclass = DBNull.Value;
            resetPosizioneGiuridica();
            //            MyCfg.idposition = DBNull.Value;
            MyCfg.idwor = DBNull.Value;
            MyCfg.incomeclassvalidity = DBNull.Value;
            MyCfg.matricula = DBNull.Value;
            if (controller.IsEmpty) return;
            SetExtraParameterForDetails();
        }

        void ClearPosGiuridica() {
            LastFilterPosGiuridica = "";
            txtClassStip.Text = "";
            txtQualifica.Text = "";
            txtDecorrClassStip.Text = "";
            txtMatricola.Text = "";
            txtRuoloCSA.Text = "";
            txtCompartoCSA.Text = "";
            txtInquadrcsa.Text = "";
            btnCambiaRuolo.Visible = false;
            //			if (Meta.IsEmpty) return;
            MyCfg.incomeclass = DBNull.Value;
            MyCfg.foreignclass = "";
            resetPosizioneGiuridica();
            //            MyCfg.idposition = DBNull.Value;
            MyCfg.idwor = DBNull.Value;
            MyCfg.incomeclassvalidity = DBNull.Value;
            MyCfg.matricula = DBNull.Value;
            SetExtraParameterForDetails();
            ClearComboPrestazione();
        }

        void FiltraComboPrestazioneInBaseANiente(bool enableold) {
            string filtertipoprestazione;
            object oldcode = null;
            if (cmbPrestazione.SelectedValue != null) oldcode = cmbPrestazione.SelectedValue;
            if ((oldcode == null) || (oldcode.ToString() == "")) enableold = false;

            filtertipoprestazione = QHS.NullOrEq("active", "S");
            filtertipoprestazione = QHS.AppAnd(filtertipoprestazione, QHS.NullOrEq("itinerationvisible", "S"));

            if (enableold)
                filtertipoprestazione = QHS.DoPar(QHS.AppOr(filtertipoprestazione,
                    QHS.CmpEq("idser", oldcode)));

            //Imposta combo prestazione filtrata
            controller.eventManager.DisableAutoEvents();
            cmbPrestazione.BeginUpdate();
            QueryCreator.MyClear(((DataTable) cmbPrestazione.DataSource));
            GetData.Add_Blank_Row(((DataTable) cmbPrestazione.DataSource));
            Conn.RUN_SELECT_INTO_TABLE(((DataTable) cmbPrestazione.DataSource), "description", filtertipoprestazione, null, true);
            HelpForm.SetComboBoxValue(cmbPrestazione, oldcode);
            cmbPrestazione.EndUpdate();
            controller.eventManager.EnableAutoEvents();

            if (enableold) {
                string filter = QHC.AppAnd(QHC.CmpEq("idser", oldcode),
                    QHC.NullOrEq("itinerationvisible", "S"));
                if (((DataTable) cmbPrestazione.DataSource).Select(filter).Length == 0) {
                    show("Attenzione: la prestazione selezionata " +
                                    "non è previsto come tipo di prestazione assimilabile ad una missione");
                }
            }


        }



        void ClearComboPrestazione() {
            ((DataTable) cmbPrestazione.DataSource).Clear();
        }

        void ScegliRuolo() {
            ImpostaPosGiuridica(true);
        }

        void DetectPosGiuridica() {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];
            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
            object datafine = Curr["stop"];
            object codicecreddeb = Curr["idreg"];
            if ((datainizio == DBNull.Value) || (((DateTime) datainizio) == QueryCreator.EmptyDate())) {
                show("Non è stata immessa la data inizio prestazione");
                return;
            }
            if ((datafine == DBNull.Value) || (((DateTime) datafine) == QueryCreator.EmptyDate())) {
                show("Non è stata immessa la data fine prestazione");
                return;
            }
            if ((codicecreddeb == DBNull.Value) || (((int) codicecreddeb) <= 0)) {
                show("Non è stato selezionato l'incaricato");
                return;
            }
            string strdate = QueryCreator.quotedstrvalue((DateTime) datainizio, true);
            string strdatefine = QueryCreator.quotedstrvalue((DateTime) datafine, true);
            FiltraComboPrestazioneInBaseANiente(true);
        }

        /// <summary>
        /// Calcola il GroupBox PosizioneGiuridica in base alla datainizio della riga corrente
        /// </summary>
        private void ImpostaPosGiuridica(bool changerole) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];

            string filter;
            //string sorting;

            object datainizio = Curr[MissFun.CampoDataPerPosGiuridica];
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

            filter = QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb), QHS.CmpLe("start", datainizio), QHS.CmpEq("active","S"),
                QHS.NullOrGe("stop", datafine));

            if ((LastFilterPosGiuridica == filter) && (!changerole)) return;

            //sorting = "start DESC";

            //DataTable SelClass = Conn.RUN_SELECT("legalstatuscontract", 
            //    "idposition, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus", // , idwor
            //    sorting, filter, "1", false);

            int NposGiuridiche = Conn.RUN_SELECT_COUNT("legalstatuscontract", filter, false);

            if (NposGiuridiche == 0) {
                if (LastFilterPosGiuridica != filter) {
                    show(
                        "I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.", "Avviso");
                }
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
                    MetaData Mlegalstatuscontract = MetaData.GetMetaData(this, "legalstatuscontract");
                    Mlegalstatuscontract.DS = DS.Copy();
                    Mlegalstatuscontract.FilterLocked = true;
                    RcurrPosGiuridica = Mlegalstatuscontract.SelectOne("anagrafica", filter, "legalstatuscontract", null);
                    if (RcurrPosGiuridica != null) break;
                    show("E' necessario selezionare un Inquadramento dell'incaricato.");
                }
                CurrPosGiuridica = RcurrPosGiuridica["idregistrylegalstatus"];
                SelClass = Conn.RUN_SELECT("legalstatuscontract",
                    "idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                    null,
                    QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
                        QHS.CmpEq("idregistrylegalstatus", RcurrPosGiuridica["idregistrylegalstatus"])), null, false);
                btnCambiaRuolo.Visible = true;
            }
            if (NposGiuridiche == 1) {
                SelClass = Conn.RUN_SELECT("legalstatuscontract",
					"idposition, livello, incomeclass, incomeclassvalidity, maxincomeclass,idregistrylegalstatus,csa_compartment,csa_role, csa_class",
                    null, filter, null, false);
                btnCambiaRuolo.Visible = false;
            }
            DataRow RowClass = SelClass.Rows[0];

            txtRuoloCSA.Text = RowClass["csa_role"].ToString();
            txtCompartoCSA.Text = RowClass["csa_compartment"].ToString();
            txtInquadrcsa.Text = RowClass["csa_class"].ToString();
            Curr["idregistrylegalstatus"] = RowClass["idregistrylegalstatus"];

			DataTable Dalia = Conn.RUN_SELECT("registrylegalstatus", "*", null, QHS.AppAnd(filter, QHS.CmpEq("idregistrylegalstatus", Curr["idregistrylegalstatus"])), null, true);

			Curr["iddaliaposition"] = Dalia.Rows[0]["iddaliaposition"];
			cmb_dalia_position.SelectedValue = Curr["iddaliaposition"];


            //Aboliamo virtualmente il flagquotaesente mettendolo sempre a S
            object currflagquotaesente = "S";



            FiltraComboPrestazioneInBaseANiente(false);
            object matricula = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", codicecreddeb), "extmatricula");

            int incomeclass = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            txtClassStip.Text = incomeclass.ToString();
			setPosizioneGiuridica(RowClass["idposition"], RowClass["livello"]);
			//            MyCfg.idposition = RowClass["idposition"];
			MyCfg.matricula = matricula;
            MyCfg.incomeclass = incomeclass;
            MyCfg.incomeclassvalidity = RowClass["incomeclassvalidity"];

            object codicequalifica = RowClass["idposition"];

            DataRow[] Q = DS.position.Select(QHC.CmpEq("idposition", codicequalifica));
            if (Q.Length > 0) {
                txtQualifica.Text = Q[0]["description"].ToString();
            }


            txtDecorrClassStip.Text = HelpForm.StringValue(MyCfg.incomeclassvalidity, "x.y.d");
            txtMatricola.Text = MyCfg.matricula.ToString();

            //Classe attuale
            int classe, maxclassestip;
            classe = CfgFn.GetNoNullInt32(RowClass["incomeclass"]);
            maxclassestip = CfgFn.GetNoNullInt32(RowClass["maxincomeclass"]);
            if (classe <= maxclassestip) {
                txtClassStip.Text = classe.ToString();
                MyCfg.incomeclass = classe;
            }
            else {
                txtClassStip.Text = maxclassestip.ToString();
                MyCfg.incomeclass = maxclassestip;
            }

            if (currflagquotaesente.ToString().ToUpper() == "S")
                ImpostaImpEsente(false);
            else
                ImpostaImpEsente(true);

            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule",
                QHS.CmpLe("start", Curr[MissFun.CampoDataPerGruppoEstero]),
                "max(idforeigngrouprule)");
            //imposta il gruppo estero
            string filterGE;
            filterGE = QHS.AppAnd(QHS.CmpEq("idforeigngrouprule", idforeigngrouprule),
                QHS.CmpEq("idposition", MyCfg.idposition),
				//QHS.CmpEq("livello", MyCfg.livello),
				QHS.NullOrEq("livello", MyCfg.livello),
				"(" + QHS.quote(MyCfg.incomeclass) + " between minincomeclass and maxincomeclass)");


            DataTable DettGruppoEstero = Conn.RUN_SELECT("foreigngroupruledetail", "foreigngroupnumber",
                null, filterGE, "1", false);
            if (DettGruppoEstero.Rows.Count == 0) {
                MyCfg.foreigngroupnumber = DBNull.Value;
                txtGruppoEstero.Text = "";
                show("I dati relativi al gruppo estero sono incompleti o mancanti", "Avviso");
                SetExtraParameterForDetails();
                return;
            }
            MyCfg.foreigngroupnumber = CfgFn.GetNoNullInt32(DettGruppoEstero.Rows[0]["foreigngroupnumber"]);
            txtGruppoEstero.Text = MyCfg.foreigngroupnumber.ToString();
            SetExtraParameterForDetails();
        }



        bool inside_lostfocus = false;

        private void txtDataInizio_LostFocus(object sender, System.EventArgs e) {
            if (controller.isClosing) return;
            if (inside_lostfocus) return;
            inside_lostfocus = true;
            if (txtDataInizio.Text != "") {
                //forza l'immissione di una data valida
                DateTime datainizio;
                try {
                    datainizio = Convert.ToDateTime(txtDataInizio.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    txtDataInizio.SelectAll();
                    txtDataInizio.Focus();
                    inside_lostfocus = false;
                    return;
                }

            }
            GeneraSelect(sender);
            inside_lostfocus = false;
        }

        private void txtDataFine_LostFocus(object sender, System.EventArgs e) {
            if (controller.isClosing) return;
            if (inside_lostfocus) return;
            inside_lostfocus = true;

            if (txtDataFine.Text != "") {
                //forza l'immissione di una data valida
                DateTime datafine;
                try {
                    datafine = Convert.ToDateTime(txtDataFine.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    txtDataFine.SelectAll();
                    txtDataFine.Focus();
                    inside_lostfocus = false;
                    return;
                }

            }
            GeneraSelect(sender);
            inside_lostfocus = false;

        }

        private void txtDataContabile_LostFocus(object sender, System.EventArgs e) {
            if (txtDataContabile.Text != "") {
                //forza l'immissione di una data valida
                DateTime datacontabile;
                try {
                    datacontabile = Convert.ToDateTime(txtDataContabile.Text);
                }
                catch {
                    show("La data inserita non era valida");
                    txtDataContabile.SelectAll();
                    txtDataContabile.Focus();
                    return;
                }

            }
            GeneraSelect(sender);
        }


        private void GeneraSelect(object sender) {
            if (controller.destroyed) return;
            if (controller.IsEmpty) return;
            if (controller.isClosing) return;
            controller.GetFormData(true);

            if (((Control) sender) == txtIncaricato) {
                ImpostaPosGiuridica(false);
                CalcolaRitenute(true);
            }
            if (((Control) sender) == cmbPrestazione) {
                CalcolaRitenute(true);
            }

            if ((MissFun.CampoDataPerPosGiuridica == "start") && (((Control) sender) == txtDataInizio)) {
                ImpostaPosGiuridica(false);
                CalcolaRitenute(true);
            }
            if (((Control) sender) == txtDataFine) {
                ImpostaPosGiuridica(false);
                CalcolaRitenute(true);
            }

            //if ((MissFun.CampoDataPerPosGiuridica=="adate")&&(((Control)sender)==txtDataContabile)) {
            //    ImpostaPosGiuridica(false);
            //    CalcolaRitenute(true);
            //}

        }

        #endregion

        /*
		La formula per il calcolo del coefficiente è la seguente:

		1 / (1 - (1 - TotAliAssDip - TotAliPreDip) * TotAliFisDip);

		dove: 

		TotAliAssDip è la somma delle aliquote delle ritenute assistenziali a carico del percipiente (*)

		TotAliPreDip è la somma delle aliquote delle ritenute previdenziali a carico del percipiente (*)

		TotAliFisDip è la somma delle aliquote delle ritenute fiscali a carico del percipiente (*)


		*/

        decimal CoefficienteLordizzazione(DataTable ritenute) {
            if (ritenute == null) return 0;
            decimal TotAliAssDip = 0; //A
            decimal TotAliPreDip = 0; //P 
            decimal TotAliFisDip = 0; //F
            foreach (DataRow Riten in ritenute.Rows) {
                object taxcode = Riten["taxcode"];
                DataRow Tax = DS.tax.Select(QHC.CmpEq("taxcode", taxcode))[0];
                if (Tax["flagunabatable"].ToString().ToLower() == "s") continue;
                string kind = Tax["taxkind"].ToString().ToLower();
                decimal valore = CfgFn.GetNoNullDecimal(Riten["employrate"]);
                decimal num = CfgFn.GetNoNullDecimal(Riten["employnumerator"]);
                decimal denom = CfgFn.GetNoNullDecimal(Riten["employdenominator"]);
                if (num != 0 && denom != 0) {
                    valore = valore * num / denom;
                }

                if (kind == "2") TotAliAssDip += valore;
                if (kind == "3") TotAliPreDip += valore;
                if (kind == "1") TotAliFisDip += valore;
            }
            decimal denominatore = 1 - (1 - TotAliAssDip - TotAliPreDip) * TotAliFisDip;
            if (denominatore == 0) return 0;
            decimal result = 1 / denominatore;
            result = Decimal.Round(result, 6);

            string help1 = "1/  [1 - (1- " + TotAliAssDip.ToString("c") + "- " +
                           TotAliPreDip.ToString("c") + ")*" +
                           TotAliFisDip.ToString("c") + "]";
            SetToolTip(txtCoeffLord, help1);
            string help2 =
                "Nella formula per il calcolo del coefficiente:\r\n" +
                "TotAliAssDip (" + TotAliAssDip.ToString("c") +
                ") è la somma delle aliquote delle ritenute assistenziali a carico del percipiente\r\n" +
                "TotAliPreDip (" + TotAliPreDip.ToString("c") +
                ") è la somma delle aliquote delle ritenute previdenziali a carico del percipiente\r\n" +
                "TotAliFisDip (" + TotAliFisDip.ToString("c") +
                ") è la somma delle aliquote delle ritenute fiscali a carico del percipiente";
            SetToolTip(txtHelpCoeffLord, help2);
            return result;
        }

        void SetToolTip(Control C, string tip) {
            myTip.SetToolTip(C, tip);
        }

        void SetExtraParameterForDetails() {
            MyCfg.totaltaxrate = 0;
            if (!controller.IsEmpty) {
                MyCfg.totaltaxrate = MissFun.IF_TotAliquotaSpese(DS.itinerationtax, DS.tax);
            }
            DS.Tables["itinerationlap"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.Tables["itinerationrefund_advance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.Tables["itinerationrefund_balance"].ExtendedProperties[MetaData.ExtraParams] = MyCfg;
            DS.itineration.ExtendedProperties["MyCfgItineration"] = MyCfg;
        }

        void RicalcolaCoefficienteLordizzazione() {
            if (controller.IsEmpty) {
                txtCoeffLord.Text = "";
                return;
            }
            DataRow Curr = DS.itineration.Rows[0];
            decimal coeff = CoefficienteLordizzazione(RitenuteCalcolate);
            Curr["grossfactor"] = coeff;
            txtCoeffLord.Text = HelpForm.StringValue(coeff, "x.y.fixed.6...1");
            return;
        }

        /// <summary>
        /// Base Imponibile = somma [ (diaria*percriddiaria - quotaesente*percridquota) * coeff. lord.]
        /// </summary>
        /// <param name="T"></param>
        void RicalcolaRitenuteMissione(DataTable T) {
            RitenuteCalcolate = T;
            RicalcolaCoefficienteLordizzazione();

            if (controller.IsEmpty) return;

            DataRow Curr = DS.itineration.Rows[0];
            //DateTime DataInizio= (DateTime) Curr["datainizio"];

            DataRow TipoPrestazione = Curr.GetParentRow("serviceitineration");
            string flagcalcimpfiscale = "";
            if (TipoPrestazione != null) flagcalcimpfiscale = TipoPrestazione["flagonlyfiscalabatement"].ToString();

            //decimal coefflord = CfgFn.GetNoNullDecimal(Curr["grossfactor"]);
            //txtCoeffLord.Text= coefflord.ToString("n");

            DataTable Spese = getFaseAnticipoMissione() ? DS.itinerationrefund_advance : DS.itinerationrefund_balance;
            DataTable TipoSpese = getFaseAnticipoMissione()
                ? DS.itinerationrefundkind_advance
                : DS.itinerationrefundkind_balance;

            decimal imponibile_per_ritenute = MissFun.TotQuoteImponibiliTappe(Curr, DS.itinerationlap, MyCfg)
                                              + MissFun.IF_TotQuoteImponibiliSpese(Spese, TipoSpese, MyCfg);

            //Elimina dalla tabella MissioneRitenuta le righe che non saranno utilizzate
            DS.itinerationtax.RejectChanges();
            ArrayList ToDelete = new ArrayList();
            foreach (DataRow ExistingRiten in DS.itinerationtax.Select()) {
                if (ExistingRiten.RowState == DataRowState.Deleted) continue;
                object codiceoldrit = ExistingRiten["taxcode"];
                if (T == null || T.Select(QHC.CmpEq("taxcode", codiceoldrit)).Length == 0) {
                    ExistingRiten.Delete();
                }
            }

            //Aggiorna / Crea le righe nella Tabella MissioneRitenuta in base alle righe in T
            MetaData MetaMissioneRitenuta = MetaData.GetMetaData(this, "itinerationtax");
            MetaMissioneRitenuta.SetDefaults(DS.itinerationtax);
            if (T != null) {
                foreach (DataRow Rit in T.Rows) {
                    string filter = QHC.CmpEq("taxcode", Rit["taxcode"]);
                    DataRow[] FoundRit = DS.itinerationtax.Select(filter);
                    DataRow MissRit;
                    if (FoundRit.Length == 0) {
                        MissRit = MetaMissioneRitenuta.Get_New_Row(Curr, DS.itinerationtax);
                    }
                    else {
                        MissRit = FoundRit[0];
                    }
                    MissRit["taxcode"] = Rit["taxcode"];
                    MissRit["taxablenumerator"] = Rit["taxablenumerator"];
                    MissRit["taxabledenominator"] = Rit["taxabledenominator"];
                    MissRit["employrate"] = Rit["employrate"];
                    MissRit["employnumerator"] = Rit["employnumerator"];
                    MissRit["employdenominator"] = Rit["employdenominator"];
                    MissRit["adminrate"] = Rit["adminrate"];
                    MissRit["adminnumerator"] = Rit["adminnumerator"];
                    MissRit["admindenominator"] = Rit["admindenominator"];
                    try {
                        MissRit["!ritenuta"] = DS.tax.Select(QHC.CmpEq("taxcode", Rit["taxcode"]))[0]["description"];
                    }
                    catch {
                        MissRit["!ritenuta"] = "";
                    }
                }
            }



            //Calcola le ritenute:

            //Calcola i coefficienti
            double sumdipendente = 0;
            double sumamministrazione = 0;

            foreach (DataRow Rit in DS.itinerationtax.Select()) {
                object taxcode = Rit["taxcode"];
                DataRow Tax = DS.tax.Select(QHS.CmpEq("taxcode", taxcode))[0];
                string taxkind = Tax["taxkind"].ToString().ToUpper();

                double NumDip = CfgFn.GetNoNullDouble(Rit["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(Rit["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(Rit["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(Rit["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(Rit["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(Rit["taxabledenominator"]);
                double AliDip = CfgFn.GetNoNullDouble(Rit["employrate"]);
                double AliAmm = CfgFn.GetNoNullDouble(Rit["adminrate"]);

                if ((taxkind == "2") || (taxkind == "3")) {
                    double dip = CfgFn.DoubleMulDiv(AliDip, NumDip, DenDip);
                    dip = CfgFn.DoubleMulDiv(dip, NumImp, DenImp);
                    sumdipendente += dip;
                    double amm = CfgFn.DoubleMulDiv(AliAmm, NumAmm, DenAmm);
                    amm = CfgFn.DoubleMulDiv(amm, NumImp, DenImp);
                    sumamministrazione += amm;
                }

            }

            double imponibileass = 0;
            double imponibiletot_txt = Convert.ToDouble(imponibile_per_ritenute);

            double imponibilefiscale = 0;
            double contributi = 0;

            imponibileass = imponibiletot_txt;

            if (flagcalcimpfiscale == "N")
                imponibilefiscale = imponibileass * (1 - sumdipendente);
            else
                imponibilefiscale = imponibileass;


            //calcola le ritenute non fiscali
            double sommaritdipendente = 0;
            foreach (DataRow R in DS.itinerationtax.Select()) {
                object taxcode = R["taxcode"];
                DataRow Tax = DS.tax.Select(QHC.CmpEq("taxcode", taxcode))[0];
                string taxkind = Tax["taxkind"].ToString().ToLower();
                if (taxkind == "1") continue;


                //R["datacompetenza"]= DataInizio;
                double NumDip = CfgFn.GetNoNullDouble(R["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(R["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(R["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(R["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(R["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(R["taxabledenominator"]);
                double AliDip = CfgFn.GetNoNullDouble(R["employrate"]);
                double AliAmm = CfgFn.GetNoNullDouble(R["adminrate"]);

                double imponibile = 0;
                double ritdipendente = 0;
                double ritammin = 0;

                imponibile = CfgFn.DoubleMulDiv(imponibileass, NumImp, DenImp);
                ritdipendente = CfgFn.DoubleMulDiv(imponibile * AliDip, NumDip, DenDip);
                ritammin = CfgFn.DoubleMulDiv(imponibile * AliAmm, NumAmm, DenAmm);

                imponibile = CfgFn.RoundValuta(imponibile);
                ritdipendente = CfgFn.RoundValuta(ritdipendente);
                ritammin = CfgFn.RoundValuta(ritammin);
                contributi += ritammin;

                R["taxable"] = Convert.ToDecimal(imponibile);
                R["employtax"] = Convert.ToDecimal(ritdipendente);
                R["admintax"] = Convert.ToDecimal(ritammin);

                sommaritdipendente += ritdipendente;
            }

            if (flagcalcimpfiscale == "N") {
                imponibilefiscale = imponibileass - sommaritdipendente;
            }
            else {
                imponibilefiscale = imponibileass;
            }


            //calcola le ritenute fiscali
            foreach (DataRow R in DS.itinerationtax.Select()) {
                object taxcode = R["taxcode"];
                DataRow Tax = DS.tax.Select(QHC.CmpEq("taxcode", taxcode))[0];
                string taxkind = Tax["taxkind"].ToString().ToLower();
                if (taxkind != "1") continue;

                //R["datacompetenza"]= DataInizio;
                double NumDip = CfgFn.GetNoNullDouble(R["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(R["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(R["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(R["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(R["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(R["taxabledenominator"]);
                double AliDip = CfgFn.GetNoNullDouble(R["employrate"]);
                double AliAmm = CfgFn.GetNoNullDouble(R["adminrate"]);

                double imponibile = 0;
                double ritdipendente = 0;
                double ritammin = 0;

                imponibile = CfgFn.DoubleMulDiv(imponibilefiscale, NumImp, DenImp);
                ritdipendente = CfgFn.DoubleMulDiv(imponibile * AliDip, NumDip, DenDip);

                imponibile = CfgFn.RoundValuta(imponibile);
                ritdipendente = CfgFn.RoundValuta(ritdipendente);
                ritammin = CfgFn.RoundValuta(ritammin);

                contributi += ritammin;
                R["taxable"] = Convert.ToDecimal(imponibile);
                R["employtax"] = Convert.ToDecimal(ritdipendente);
                R["admintax"] = Convert.ToDecimal(ritammin);
            }

            helpForm.FillControls(tabRitenute.Controls);
            RicalcolaTotaliRitenute();

        }

        void RicalcolaTotaliRitenute() {
            if (controller.IsEmpty) return;
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

            DataRow Curr = DS.itineration.Rows[0];
            decimal MyImporto;
            if (DS.HasChanges()) {
                decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
                Curr["totalgross"] = totalgross;
                MyImporto = totalgross;
            }
            else {
                MyImporto = CfgFn.GetNoNullDecimal(Curr["totalgross"]);

            }
            //CfgFn.RoundValuta(CalcolaImportoLordoMissione()); //GetImportoPerClassificazione();

            foreach (DataRow DR in DS.itinerationtax.Rows) {
                if (DR.RowState == DataRowState.Deleted) continue;

                decimal DecDip = CfgFn.GetNoNullDecimal(DR["employtax"]);
                decimal DecAmm = CfgFn.GetNoNullDecimal(DR["admintax"]);
                TotDip += DecDip;
                TotAmm += DecAmm;

                string MyFilter = QHC.CmpEq("taxcode", DR["taxcode"]);
                DataRow[] DRTipo = DS.Tables["tax"].Select(MyFilter);

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
            TotDip = CfgFn.RoundValuta(TotDip);
            TotAmm = CfgFn.RoundValuta(TotAmm);
            AssistenzialiDip = CfgFn.RoundValuta(AssistenzialiDip);
            AssistenzialiEnte = CfgFn.RoundValuta(AssistenzialiEnte);
            PrevidenzialiDip = CfgFn.RoundValuta(PrevidenzialiDip);
            PrevidenzialiEnte = CfgFn.RoundValuta(PrevidenzialiEnte);
            FiscaliDip = CfgFn.RoundValuta(FiscaliDip);
            FiscaliEnte = CfgFn.RoundValuta(FiscaliEnte);
            AltreDip = CfgFn.RoundValuta(AltreDip);
            AltreEnte = CfgFn.RoundValuta(AltreEnte);
            AssicurativeDip = CfgFn.RoundValuta(AssicurativeDip);
            AssicurativeEnte = CfgFn.RoundValuta(AssicurativeEnte);


            txtImportonettoDip.Text = Str(MyImporto - TotDip);
            txtCostoTotaleEnte.Text = Str(MyImporto + TotAmm);
            txtAssistenzialiDip.Text = Str(AssistenzialiDip);
            txtAssistenzialiEnte.Text = Str(AssistenzialiEnte);
            txtAssAmministrazione.Text = Str(AssistenzialiEnte);
            txtFiscaliDip.Text = Str(FiscaliDip);
            txtFiscaliEnte.Text = Str(FiscaliEnte);
            txtPrevidenzialiDip.Text = Str(PrevidenzialiDip);
            txtPrevidenzialiEnte.Text = Str(PrevidenzialiEnte);
            txtPrevAmministrazione.Text = Str(PrevidenzialiEnte);
            txtAltreDip.Text = Str(AltreDip);
            txtAltreEnte.Text = Str(AltreEnte);
            txtAssicurativeDip.Text = Str(AssicurativeDip);
            txtAssicurativeEnte.Text = Str(AssicurativeEnte);

            DataRow CurrMiss = DS.itineration.Rows[0];
            CfgFn.AssignNotEquals(CurrMiss, "netfee", MyImporto - TotDip);
            CfgFn.AssignNotEquals(CurrMiss, "total", MyImporto + TotAmm);
            //DS.dettaglioritenute.imponibileColumn.DefaultValue= GetImporto();
        }


        //restituisce una stringa da un decimal
        private string Str(decimal D) {
            if (D == 0) return "";
            return D.ToString("c");
        }


        /// <summary>
        /// Effettua delle semplici moltiplicazioni che NON CAMBIANO IL DATASET
        /// </summary>
        void RicalcolaRimborsiKilometrici() {
            if (controller.IsEmpty) return;
            controller.GetFormData(true);
            DataRow Curr = DS.itineration.Rows[0];
            double KmProprio = CfgFn.GetNoNullDouble(Curr["owncarkm"]);
            double KmAmm = CfgFn.GetNoNullDouble(Curr["admincarkm"]);
            double KmPiedi = CfgFn.GetNoNullDouble(Curr["footkm"]);
            decimal ImpProprio = CfgFn.GetNoNullDecimal(Curr["owncarkmcost"]);
            decimal ImpAmm = CfgFn.GetNoNullDecimal(Curr["admincarkmcost"]);
            decimal ImpPiedi = CfgFn.GetNoNullDecimal(Curr["footkmcost"]);

            decimal TotAmm = Convert.ToDecimal(KmAmm) * ImpAmm;
            decimal TotProprio = Convert.ToDecimal(KmProprio) * ImpProprio;
            decimal TotPiedi = Convert.ToDecimal(KmPiedi) * ImpPiedi;

            txtEurTotAPiedi.Text = ((decimal) CfgFn.RoundValuta(TotPiedi)).ToString("C");
            txtEurTotMezzoAmm.Text = ((decimal) CfgFn.RoundValuta(TotAmm)).ToString("C");
            txtEurTotMezzoProprio.Text = ((decimal) CfgFn.RoundValuta(TotProprio)).ToString("C");

        }

        private void txtKmMezzoProprio_TextChanged(object sender, System.EventArgs e) {
            if (!controller.DrawStateIsDone) return;
            if (controller.destroyed) return;
            if (controller.isClosing) return;
            RicalcolaRimborsiKilometrici();
            CalcolaTotaliMissione();
            RicalcolaTotaliRitenute();
        }

        /// <summary>
        /// Abilita le text box sulle annotazioni in funzione del valore dello stato della missione
        /// </summary>
        /// <param name="statoMissione">Identifica lo stato della missione</param>
        private void AbilitaAnnotazioni(int statoMissione) {

            // Valori possibili:
            // 1: Bozza
            // 2: Richiesta
            // 3: Da Correggere 
            // 4: Inserita
            // 5: Autorizzazione a Missione
            // 6: Approvata
            // 7: Annullata
            // 8: Autorizzazione a rendiconto

            switch (statoMissione) {
                case 5:
                case 6:
                case 8:
                    txt_additionalannotations.Enabled = false;
                    //chkClauseMezzoProprio.Enabled = false;
                    //txtCausaleMezzoProprio.Enabled = false;
                    //txtDatiMezzoProprio.Enabled = false;
                    break;
                default:
                    txt_additionalannotations.Enabled = true;
                    //chkClauseMezzoProprio.Enabled = true;
                    //txtCausaleMezzoProprio.Enabled = true;
                    //txtDatiMezzoProprio.Enabled = true;

                    break;
            }


        }

        decimal CalcolaSpeseSostenute() {
            decimal SUM = 0;
            if (controller.IsEmpty) return SUM;

            if (getFaseAnticipoMissione()) {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            else {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.SpesaSostenuta(R);
                }
            }
            return SUM;
        }


        decimal CalcolaSpeseAnticipo() {
            decimal SUM = 0;
            if (controller.IsEmpty) return SUM;

            foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }


        decimal CalcolaSpeseSaldo() {
            decimal SUM = 0;
            if (controller.IsEmpty) return SUM;

            foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.SpesaSostenuta(R);
            }

            return SUM;
        }

        /// <summary>
        /// Ind. suppl. EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndennitaSupplementari() {
            decimal SUM = 0;
            if (getFaseAnticipoMissione()) {
                foreach (DataRow R in DS.itinerationrefund_advance.Rows) {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            else {
                foreach (DataRow R in DS.itinerationrefund_balance.Rows) {
                    if (R.RowState == DataRowState.Deleted) continue;
                    SUM += MissFun.IndennitaSupplementare(R);
                }
            }
            return CfgFn.RoundValuta(SUM);
        }

        /// <summary>
        /// Ind.Km. EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndennitaChilometrica() {
            DataRow Curr = DS.itineration.Rows[0];
            return MissFun.IndennitaChilometrica(Curr);
        }



        /// <summary>
        /// Ind.lorda trasf.italia EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndLordaTrafertaItalia() {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "S"))) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }

        /// <summary>
        /// Ind.lorda trasf.estero EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndLordaTrafertaEstero() {
            decimal SUM = 0;
            DataRow Missione = DS.itineration.Rows[0];
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "N"))) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaLordaTappa(Missione, Tappa, MyCfg);
            }
            return SUM;
        }



        /// <summary>
        /// Ind. Trasf.Italia EURO
        /// </summary>
        /// <returns></returns>
        decimal CalcolaIndTrafertaItalia() {
            decimal SUM = 0;
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "S"))) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaTotale(Tappa);
            }
            return SUM;
        }

        decimal CalcolaIndTrafertaEstero() {
            decimal SUM = 0;
            foreach (DataRow Tappa in DS.itinerationlap.Select(QHC.CmpEq("flagitalian", "N"))) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                SUM += MissFun.IndennitaTotale(Tappa);
            }
            return SUM;
        }


        //public static decimal TotQuoteEsentiTappe(DataRow Missione, DataTable Tappe, string IE,CfgItineration Cfg){
        //    decimal SUM = 0;
        //    string filter="(flagitalian='"+IE+"')";
        //    foreach (DataRow Tappa in Tappe.Select(filter)){
        //        SUM += MissFun.QuotaEsenteTappa(Missione, Tappa,Cfg);
        //    }
        //    return SUM;
        //}


        decimal CalcolaImportoLordoMissione() {
            return CalcolaSpeseSostenute() +
                   CalcolaIndennitaSupplementari() +
                   CalcolaIndennitaChilometrica() +
                   CalcolaIndLordaTrafertaItalia() + //lordo 
                   CalcolaIndLordaTrafertaEstero(); //lordo

        }

        decimal CalcolaTotaleMissione() {
            return CalcolaSpeseSostenute() +
                   CalcolaIndennitaSupplementari() +
                   CalcolaIndennitaChilometrica() +
                   CalcolaIndTrafertaItalia() + //deve prendere il netto e non il lordo
                   CalcolaIndTrafertaEstero(); //deve prendere il netto e non il lordo				
        }

        decimal AdminTax() {
            return MetaData.SumColumn(DS.itinerationtax, "admintax");
        }

        decimal EmployTax() {
            return MetaData.SumColumn(DS.itinerationtax, "employtax");
        }

        void CalcolaTotaliMissione() {
            if (controller.IsEmpty) return;
            controller.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            decimal totalrefund = 0;
            decimal totalrefundadv = 0;
            decimal totalrefundbal = 0;
            decimal kmrefund = 0;
            decimal extraallowance = 0;
            decimal italiangrossallowance = 0;
            decimal foreigngrossallowance = 0;


            DataRow Curr = DS.itineration.Rows[0];

            totalrefund = CfgFn.RoundValuta(CalcolaSpeseSostenute());
            totalrefundadv = CfgFn.RoundValuta(CalcolaSpeseAnticipo());
            totalrefundbal = CfgFn.RoundValuta(CalcolaSpeseSaldo());

            extraallowance = CfgFn.RoundValuta(CalcolaIndennitaSupplementari());
            kmrefund = CfgFn.RoundValuta(CalcolaIndennitaChilometrica());
            italiangrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaItalia());
            foreigngrossallowance = CfgFn.RoundValuta(CalcolaIndLordaTrafertaEstero());


            //totindennitalia = SOMMA DELLE INDENNITA TOTALE EURO ITALIA
            //totindennlord manca
            //totesenteitalia
            //totesenteestero
            if (DS.HasChanges()) {
                decimal totalgross = CfgFn.RoundValuta(CalcolaImportoLordoMissione());
                Curr["totalgross"] = totalgross;
                decimal total = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Curr["totalgross"]) +
                                                  CfgFn.GetNoNullDecimal(AdminTax()));
                Curr["total"] = total;

                decimal nuovototanticipo = CfgFn.GetNoNullDecimal(Curr["totadvance"]);
                if (!AnticipoIsReadOnly) {
                    nuovototanticipo = CfgFn.RoundValuta(MissFun.GetTotAnticipoMissione(DS.itinerationlap,
                        DS.itinerationrefund_advance));
                    Curr["totadvance"] = nuovototanticipo;
                }
                //totanticipoconcesso NON USATO
                txtImportoAnticipo.Text = nuovototanticipo.ToString("c");
                txtLordo.Text = totalgross.ToString("c");
                txtComplessivo.Text = total.ToString("c");

            }
            DataTable Spese = getFaseAnticipoMissione() ? DS.itinerationrefund_advance : DS.itinerationrefund_balance;
            DataTable TipoSpese = getFaseAnticipoMissione()
                ? DS.itinerationrefundkind_advance
                : DS.itinerationrefundkind_balance;

            decimal quotaesente = MissFun.TotQuoteEsentiTappe(Curr, DS.itinerationlap, MyCfg) +
                                  MissFun.IF_TotQuoteEsentiSpese(Spese, TipoSpese, MyCfg);
            txtQuotaEsenteMissione.Text = quotaesente.ToString("c");

            decimal totimponibile = MissFun.TotQuoteImponibiliTappe(Curr, DS.itinerationlap, MyCfg) +
                                    MissFun.IF_TotQuoteImponibiliSpese(Spese, TipoSpese, MyCfg);
            txtQuotaImponibileTappa.Text = totimponibile.ToString("c");


            txtSpeseAnticipo.Text = totalrefundadv.ToString("c");
            txtSpeseSaldo.Text = totalrefundbal.ToString("c");

            txtSpeseSostenute.Text = totalrefund.ToString("c");

            if (getFaseAnticipoMissione()) {
                labelSpeseSost.Text = "Totale spese da considerare (preventivate):";
            }
            else {
                labelSpeseSost.Text = "Totale spese da considerare (sostenute):";
            }

            txtIndSupplementare.Text = extraallowance.ToString("c");
            txtTotIndennKm.Text = kmrefund.ToString("c");
            txtTotLordIt.Text = italiangrossallowance.ToString("c");
            txtTotLordEst.Text = foreigngrossallowance.ToString("c");

            //Meta.myHelpForm.FillControls(tabCalcolo.Controls);
        }

        void RicalcolaMissione() {
            checkAnticipiReadOnly();
            lastcalcolaritenuteparams = "!!";
            LastOutCalcolaRitenute = null;
            LastImpEsenteFilter = null;
            LastFilterPosGiuridica = null;
            ImpostaPosGiuridica(false);
            //ImpostaImpEsente(true); già chiamato da ImpostaPosGiuridica

            DataRow CurrMiss = DS.itineration.Rows[0];
            object datarif = CurrMiss[MissFun.CampoDataPerDiaria];
            string filterstart = QHS.CmpLe("start", datarif);
            object groupnumber = MyCfg.foreigngroupnumber;

            //Aggiorna  l'indennità e la perc. di anticipo delle tappe.
            foreach (DataRow Tappa in DS.itinerationlap.Select()) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                if (MissFun.TappaIsItalia(Tappa)) {
                    object idallowancerule = Conn.DO_READ_VALUE("allowancerule", filterstart,
                        "max(idallowancerule)");
                    string filter = MissFun.GetQualificaClasseFilter(MyCfg.idposition, MyCfg.livello, MyCfg.incomeclass);
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idallowancerule", idallowancerule));

                    DataTable TempItalia = Conn.RUN_SELECT("allowanceruledetail",
                        "amount, advancepercentage", null, filter, null, false);
                    decimal indennitaitalia = 0;
                    double percanticipoitalia = 0;
                    if ((TempItalia == null) || (TempItalia.Rows.Count == 0)) {
                        show(
                            "Le informazioni relative alla diaria sono incomplete o mancanti. (Tappe Italiane)",
                            "Avviso");
                        AzzeraIndennitaTappa(Tappa);
                    }
                    else {
                        indennitaitalia = CfgFn.GetNoNullDecimal(TempItalia.Rows[0]["amount"]);
                        percanticipoitalia = CfgFn.GetNoNullDouble(TempItalia.Rows[0]["advancepercentage"]);
                        Tappa["allowance"] = CfgFn.RoundValuta(indennitaitalia);
                        Tappa["advancepercentage"] = percanticipoitalia;
                    }
                }
                else {
                    object idforeignallowancerule = Conn.DO_READ_VALUE("foreignallowancerule",
                        QHS.AppAnd(QHS.CmpEq("idforeigncountry", Tappa["idforeigncountry"]), filterstart),
                        "max(idforeignallowancerule)");
                    string filter = QHS.AppAnd(QHS.CmpEq("idforeignallowancerule", idforeignallowancerule),
                        "(" + QHS.quote(groupnumber) + " BETWEEN minforeigngroupnumber AND maxforeigngroupnumber)");

                    DataTable dettind = Conn.RUN_SELECT("foreignallowanceruledetail",
                        "amount,advancepercentage", null, filter, null, true);
                    if ((dettind == null) || (dettind.Rows.Count == 0)) {
                        show("Le informazioni relative alla diaria estera sono incomplete o mancanti." +
                                        "(Tappa n." + Tappa["lapnumber"].ToString() + ")"
                            , "Avviso");
                        AzzeraIndennitaTappa(Tappa);
                    }
                    else {
                        decimal indennitaestero = CfgFn.GetNoNullDecimal(dettind.Rows[0]["amount"]);
                        double percanticipoestero = CfgFn.GetNoNullDouble(dettind.Rows[0]["advancepercentage"]);
                        Tappa["allowance"] = CfgFn.RoundValuta(indennitaestero);
                        Tappa["advancepercentage"] = percanticipoestero;
                    }
                }

            }

            //Ricalcola Ore/Giorni delle tappe
            foreach (DataRow Tappa in DS.itinerationlap.Select()) {
                if (Tappa.RowState == DataRowState.Deleted) continue;
                MissFun.RicalcolaOreGiorniTappa(CurrMiss, Tappa, MyCfg);
            }

            //Ricalcola Spese 
            MissFun.RicalcolaSpese(Conn as DataAccess, CurrMiss, DS.itinerationrefund_advance,
                MyCfg.idposition, MyCfg.livello, MyCfg.incomeclass);
            MissFun.RicalcolaSpese(Conn as DataAccess, CurrMiss, DS.itinerationrefund_balance,
                MyCfg.idposition,MyCfg.livello, MyCfg.incomeclass);

            CalcolaRitenute(true);
            RicalcolaRimborsiKilometrici();
            CalcolaTotaliMissione();
            RicalcolaTotaliRitenute();

        }

        void AzzeraIndennitaTappa(DataRow Tappa) {
            show("Non è stato possibile aggiornare l'indennità della tappa N." +
                            Tappa["lapnumber"].ToString() +
                            "(" + Tappa["description"].ToString() + "), che è stata quindi lasciata invariata"
                );
            //Tappa["allowance"]=0;
        }


        private void btnAggiorna_Click(object sender, System.EventArgs e) {
            if (controller.IsEmpty) return;
            if (show(this,
                "Saranno aggiornati tutti i parametri utilizzati nel calcolo della missione. Tra questi:\r" +
                "Le indennità corrisposte delle tappe e gli anticipi delle spese.",
                "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
            controller.GetFormData(true);
            RicalcolaMissione();
            controller.FreshForm(true, false);
        }



        private void btnToExcel_Click(object sender, System.EventArgs e) {
            if (controller.IsEmpty) return;
            DataTable TE = new DataTable("Missione");
            TE.Columns.Add("nome", typeof(string));
            TE.Columns.Add("valore", typeof(decimal));

            DataRow RR;
            RR = TE.NewRow();
            RR["nome"] = labelSpeseAnticipo.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtSpeseAnticipo.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelSpeseSaldo.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtSpeseSaldo.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelSpeseSost.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtSpeseSostenute.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelIndSuppl.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtIndSupplementare.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labeIndKm.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtTotIndennKm.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelIndLordIt.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtTotLordIt.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelIndLordEst.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtTotLordEst.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelImpLord.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtLordo.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelRitAssAmm.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtAssAmministrazione.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelRitPrevAmm.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtPrevAmministrazione.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelImpCompl.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtComplessivo.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelImpAnticipo.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtImportoAnticipo.Text, null));
            TE.Rows.Add(RR);


            RR = TE.NewRow();
            RR["nome"] = labelQuotaEsente.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtQuotaEsenteMissione.Text, null));
            TE.Rows.Add(RR);

            RR = TE.NewRow();
            RR["nome"] = labelQuotaImponibile.Text;
            RR["valore"] = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtQuotaImponibileTappa.Text, null));
            TE.Rows.Add(RR);

            exportclass.DataTableToExcel(TE, true);
        }

        private void btnSituazione_Click(object sender, System.EventArgs e) {
            if (controller.IsEmpty) return;
            controller.GetFormData(true);
            DataRow Curr = DS.itineration.Rows[0];
            try {
                DataSet Out = Conn.CallSP("show_itineration",
                    new object[] {
                        Curr["nitineration"],
                        Curr["yitineration"],
                        security.GetSys("datacontabile"),
                        security.GetSys("esercizio")
                    });
                if (Out == null) return;
                Out.Tables[0].TableName = "Situazione missione";
                frmSituazioneViewer FrmSit = new frmSituazioneViewer(Out);
                createForm(FrmSit, null);
                FrmSit.Show();
            }
            catch (Exception E) {
                show("Errore chiamando show_itineration." +
                                "Dettaglio:" + E.Message);
            }


        }

        private void btnRuolo_Click(object sender, System.EventArgs e) {
            ScegliRuolo();
        }








        void VisualizzaEtichetteAP() {
            if (DS.itineration.Rows.Count > 0 && (DS.itineration.Rows[0].RowState == DataRowState.Unchanged)) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = true;
                btnGeneraAP.Enabled = true;
                btnCollegaAP.Visible = true;
            }
            else {
                if (controller.InsertMode || DS.itineration.Rows.Count == 0) // || DS.entrysetup.Rows.Count==0)
                {
                    labAPnongenerato.Visible = false;
                    labAPgenerato.Visible = false;
                    btnVisualizzaAP.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                    return;
                }
            }

            AP_fun AP = new AP_fun(dispatcher as MetaDataDispatcher);
            string idrelated = AP_fun.GetIdForDocument(DS.itineration.Rows[0]);
            if (Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("idrelated", idrelated), true) == 0) {
                labAPgenerato.Visible = false;
                btnVisualizzaAP.Visible = false;

                /*
                 *  considerare il campo authneeded dei vari compensi
                    N oppure X -- > abilitare la generazione
                    S 	       -- > non abilitare la generazione
                 */
                if ((rdbAutorizzazioneNonNecessaria.Checked) || ((rdbNonApplicabile.Checked))) {
                    labAPnongenerato.Visible = true;
                    btnGeneraAP.Visible = true;
                    btnCollegaAP.Visible = true;
                }
                else {
                    labAPnongenerato.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                }

                // Se l'AP non è stata generata visualizza il button Genera, MA se è una missione inserita tramite web....
                if (CheckWeb()) {
                    DataRow Curr = DS.itineration.Rows[0];
                    int iditinerationstatus = CfgFn.GetNoNullInt32(Curr["iditinerationstatus"]);

                    // per le missioni inserite da web disabilitare la generazione di anagrafe prestazioni/impegni du budget ecc
                    // se lo stato non è "Approvata"
                    if (iditinerationstatus != 6) {
                        btnGeneraAP.Visible = false;
                        btnCollegaAP.Visible = false;
                        labAPnongenerato.Visible = false;

                    }
                }

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
            if (DS.itineration.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.itineration.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(dispatcher as MetaDataDispatcher);
            if (!AP.attivo) return;
            AP.GetEntryForDocument(Curr);

            if (AP.MainSrvRegExists()) {
                show(this, "L'Anagrafe Prestazione è stata già generata.",
                    "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MetaData ToMeta = dispatcher.Get("serviceregistry");
            ToMeta.Edit(controller.linkedForm.ParentForm, "default", false);

            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in ToMeta.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }

            bool isOk = AP.SetSrvRegDefault(ToMeta, Curr, Curr["idreg"], AP_fun.GetIdForDocument(Curr));
            if (!isOk) {
                show(this, "Errore nella assegnazione dei valori di default",
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
            if (DS.itineration.Rows.Count == 0) return;
            AP_fun AP = new AP_fun(dispatcher as MetaDataDispatcher);
            AP.EditRelatedServiceRegistry(Meta as MetaData, DS.itineration.Rows[0]);
        }

        private void btnVisualizzaAP_Click(object sender, System.EventArgs e) {
            EditServiceRegistry();
        }

        private void txtDataInizio_Leave(object sender, EventArgs e) {
            setDateInizioFineSpesa();
            checkAnticipiReadOnly();
            EnableDisableRefund();
        }



        private void txtDataFine_Leave(object sender, EventArgs e) {
            setDateInizioFineSpesa();
        }

        private void btnCambiaRuolo_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            ImpostaPosGiuridica(true);
        }

        private void btnAccetta_Click(object sender, EventArgs e) {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 4;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges()) {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        public void MetaData_AfterGetFormData() {
            if (controller.EditMode) {
                DataRow R = DS.itineration.Rows[0];
                if (CfgFn.GetNoNullDecimal(R["supposedtravel", DataRowVersion.Current]) !=
                    CfgFn.GetNoNullDecimal(R["supposedtravel", DataRowVersion.Original])
                    ) {
                    AggiornaSpeseAnticipo("viaggio");
                }
                if (CfgFn.GetNoNullDecimal(R["supposedliving", DataRowVersion.Current]) !=
                    CfgFn.GetNoNullDecimal(R["supposedliving", DataRowVersion.Original])
                    ) {
                    AggiornaSpeseAnticipo("alloggio");
                }
                if (CfgFn.GetNoNullDecimal(R["supposedfood", DataRowVersion.Current]) !=
                    CfgFn.GetNoNullDecimal(R["supposedfood", DataRowVersion.Original])
                    ) {
                    AggiornaSpeseAnticipo("vitto");
                }
                if (CfgFn.GetNoNullDecimal(R["supposedamount", DataRowVersion.Current]) !=
                    CfgFn.GetNoNullDecimal(R["supposedamount", DataRowVersion.Original])
                    ) {
                    AggiornaSpeseAnticipo("altro");
                }
            }
        }
        void AggiornaSpeseAnticipo(string kind) {
            DataRow Curr = DS.itineration.Rows[0];
            object idfundkindgroup = Conn.DO_READ_VALUE("itinerationrefundkindgroup", QHS.CmpEq("description", kind), "iditinerationrefundkindgroup");
            object iditinerationrefundkind = Conn.DO_READ_VALUE("itinerationrefundkind",
                QHS.AppAnd(QHS.CmpEq("iditinerationrefundkindgroup", idfundkindgroup), QHS.CmpEq("active", "S"), QHS.CmpEq("flagadvance", "S")),
                "iditinerationrefundkind", "codeitinerationrefundkind asc");
            DataRow[] found = DS.itinerationrefund_advance.Select(QHC.CmpEq("iditinerationrefundkind", iditinerationrefundkind));
            DataRow SpeseAnticipo;
            decimal importo = 0;
            switch (kind) {
                case "viaggio":
                    importo = CfgFn.GetNoNullDecimal(Curr["supposedtravel"]);
                    break;
                case "alloggio":
                    importo = CfgFn.GetNoNullDecimal(Curr["supposedliving"]);
                    break;
                case "vitto":
                    importo = CfgFn.GetNoNullDecimal(Curr["supposedfood"]) * CfgFn.GetNoNullInt32(Curr["nfood"]);
                    break;
                case "altro":
                    importo = CfgFn.GetNoNullDecimal(Curr["supposedamount"]);
                    break;
            }

            if (found.Length > 0) {
                // Modifica quelle del DS
                found[0]["amount"] = importo;
                found[0]["requiredamount"] = importo;
                found[0]["advancepercentage"] = Curr["advancepercentage"];
            }
            //   CalcolaTotaleCostiAnticipo(Curr, false);
        }
        private void btnintegra_Click(object sender, EventArgs e) {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 3;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges()) {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }


        private void btnRiconsidera_Click(object sender, EventArgs e) {
            if (!controller.GetFormData(false)) return;
            if (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0) {
                bool asked = false;
                foreach (DataRow R in DS.itinerationauthagency.Select()) {
                    if (R["flagstatus"].ToString().ToUpper() != "S") continue;
                    if (!asked) {
                        asked = true;
                        if (
                            show(this, "Lo stato di autorizzazione sarà resettato.", "Avviso",
                                MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;
                    }
                    R["flagstatus"] = "D";
                }
            }

            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 4; // ritorna nello stato "inserita"
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges()) {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                DS.itinerationauthagency.RejectChanges();
                controller.FreshForm(true, false);
            }
            else {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private void btnAttesaAutorizzazione_Click(object sender, EventArgs e) {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = getFaseAnticipoMissione() ? 5 : 8;

            foreach (DataRow Ref in DS.itinerationrefund_advance.Select()) {
                if (CfgFn.GetNoNullDecimal(Ref["requiredamount"]) > 0 &&
                    CfgFn.GetNoNullDecimal(Ref["amount"]) == 0)
                    Ref["amount"] = Ref["requiredamount"];
            }
            foreach (DataRow Ref in DS.itinerationrefund_balance.Select()) {
                if (CfgFn.GetNoNullDecimal(Ref["requiredamount"]) > 0 &&
                    CfgFn.GetNoNullDecimal(Ref["amount"]) == 0)
                    Ref["amount"] = Ref["requiredamount"];
            }

            if (DS.itinerationauthagency.Select().Length == 0 ||
                DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length > 0)
                GeneraAutorizzazioni();

            if ((DS.itinerationauthagency.Select().Length == 0) || //non ci sono agenti autorizzativi
                (DS.itinerationauthagency.Select(QHC.CmpNe("flagstatus", "S")).Length == 0)) {
                // missione già approvata devo inserire il saldo
                curr["iditinerationstatus"] = 6;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
            }
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges()) {
                DS.itinerationauthagency.RejectChanges();
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            if (!controller.GetFormData(false)) return;
            DataRow curr = DS.itineration.Rows[0];
            object idoldstatus = curr["iditinerationstatus"];
            object oldlt = curr["lt"];
            object oldlu = curr["lu"];
            curr["iditinerationstatus"] = 7;
            controller.FreshForm(true, false);
            Meta.DoMainCommand("mainsave");
            if (DS.HasChanges()) {
                curr["iditinerationstatus"] = idoldstatus;
                curr["lu"] = oldlu;
                curr["lt"] = oldlt;
                controller.FreshForm(true, false);
            }
            else {
                MissFun.SendMails(Conn as DataAccess, curr);
            }
        }

        private bool DaliaAbilitato = false;
        private void abilitaDisabilitaDalia(DataRow service) {
            DaliaAbilitato = false;
            if (DS.itineration.Rows.Count == 0 || idsorkindDalia == null || idsorkindDalia == DBNull.Value) {
                btnVoceSpesaDalia.Visible = false;
                btnQualificaDalia.Visible = false;
                txtVoceSpesaDalia.Visible = false;
                grpCausaliAssunzioneDalia.Visible = false;
                return;
            }
            if (service == null) {
                DataRow Curr = DS.itineration.Rows[0];
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

        private bool EsisteIndirizzoAP() {
            DataRow curr = DS.itineration.Rows[0];
            String codeaddress = "07_SW_ANP";
            object idaddresskind = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DateTime DataInizio = new DateTime(1900, 1, 1);
            if (curr["start"] != DBNull.Value) DataInizio = (DateTime) curr["start"];

            if (DataInizio.Year < 1900) DataInizio = new DateTime(1900, 1, 1);
            DataTable Address = Conn.RUN_SELECT("registryaddress", "*", null,
                QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("idreg", curr["idreg"]),
                    QHS.CmpLe("start", DataInizio), QHS.NullOrGe("stop", DataInizio)), null, false);
            if (Address.Rows.Count > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        private void btnInserisciAnticipo_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            controller.GetFormData(true);
            DataRow Curr = DS.itineration.Rows[0];
            if (CfgFn.GetNoNullDecimal(Curr["totadvance", DataRowVersion.Original]) == 0) {
                frmAskAdvance F = new frmAskAdvance(3);
                createForm(F, this);
                if (F.ShowDialog(this) != DialogResult.OK) return;
                object advance = F.importo;
                object totalgross = Curr["totalgross"];
                if (CfgFn.GetNoNullDecimal(advance) == 0) return;
                if ((CfgFn.GetNoNullDecimal(advance) <= CfgFn.GetNoNullDecimal(totalgross))) {
                    Curr["totadvance"] = advance;
                    controller.FreshForm(true, false);
                }
                else {
                    show(this, "L''importo dell'anticipo non può superare quello del lordo");
                }
            }

        }

        private void rdbNonApplicabile_CheckedChanged(object sender, EventArgs e) {
            VisualizzaEtichetteAP();
        }

        private void rdbNecessitaAutorizzazione_CheckedChanged(object sender, EventArgs e) {
            if (rdbNecessitaAutorizzazione.Checked) {
                grpBoxDocAutorizzattivo.Visible = true;
            }
            else {
                grpBoxDocAutorizzattivo.Visible = false;
                txtDataDocumentoAut.Text = "";
                txtDocumentoAut.Text = "";
            }
            VisualizzaEtichetteAP();
        }

        private void chkPagabile_CheckStateChanged(object sender, EventArgs e) {
            if (!controller.DrawStateIsDone) return;
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
        }

        private void btnVoceSpesaDalia_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            if (!controller.GetFormData(true)) return;
            DataTable main = DS.itineration;
            //object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");
            //if (idsorkind == null || idsorkind == DBNull.Value) {
            //    show("Non è installata la classificazione per DALIA avente codice VOCISPESA", "Errore");
            //    return;
            //}
            DataRow r = main.Rows[0];
            object idser = r["idser"];
            if (idser == DBNull.Value) {
                show("Occorre selezionare prima la prestazione", "Avviso");
                return;
            }
            DataRow[] classR =
                Conn.RUN_SELECT("servicesorting", "idsor", null, QHS.CmpEq("idser", idser), null, false).Select();
            string filter = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkindDalia),
                QHS.FieldIn("idsor", classR, "idsor"), QHS.CmpEq("ayear", security.GetEsercizio()));
            GetData.DenyClear(DS.sortingview1);
            int num = Conn.RUN_SELECT_COUNT("sortingview", filter, false);
            if (num > 0) {
                Meta.DoMainCommand("choose.sortingview1.default." + filter);
                //Il resto lo fa nell'afterrowselect, che chiama selezionaVoceSpesaDalia
            }
            else {
                show("La prestazione selezionata non è associata ad alcuna classificazione DALIA", "Avviso");
            }

        }

        private void rdbAutorizzazioneNonNecessaria_CheckedChanged(object sender, EventArgs e) {
            if (rdbAutorizzazioneNonNecessaria.Checked) {
                grpBoxMotivo.Visible = true;
            }
            else {
                grpBoxMotivo.Visible = false;
                txtMotivoAut.Text = "";
            }
            VisualizzaEtichetteAP();
        }

        private void btnCollegaAP_Click(object sender, EventArgs e) {
            if (DS.itineration.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.itineration.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(dispatcher as MetaDataDispatcher);
            if (!AP.attivo) return;
            AP.LinkExistingDocument(Meta as MetaData, Curr, Curr["idreg"]);
        }
        /// <summary>
        /// Aggiorna il codice della voce spesa
        /// </summary>
        void AggiornaVoceSpesa() {
            if (controller.IsEmpty) {
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
            if (controller.IsEmpty) return;
            DataRow Curr = DS.itineration.Rows[0];
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


            MetaData MSor = dispatcher.Get(sortingT.TableName);
            DataRow newClass = MSor.Get_New_Row(Curr, sortingT);
            newClass["idsor"] = idsor;
            newClass["quota"] = 1.0;
            controller.FreshForm(true, false);

        }



        private void btnQualificaDalia_Click(object sender, EventArgs e) {
            selezionaQualificaDalia(false);
        }



        void selezionaQualificaDalia(bool quiet) {
            if (controller.IsEmpty) return;
            if (!controller.GetFormData(true)) return;
            DataTable main = DS.itineration;
            DataRow Curr = main.Rows[0];
            object idreg = Curr["idreg"];
            if (idreg == DBNull.Value && !quiet) {
                show("Occorre selezionare prima il percipiente", "Avviso");
                return;
            }

            object datainizio = Curr["start"];
            object datafine = Curr["stop"];
            DateTime empty = QueryCreator.EmptyDate();
            if (datainizio.ToString() == empty.ToString()) datainizio = DBNull.Value;
            if (datafine.ToString() == empty.ToString()) datafine = DBNull.Value;


            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.IsNotNull("iddaliaposition"), QHS.CmpEq("active", "S"));
            if (datainizio != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.NullOrLe("start", datainizio));
            }
            if (datafine != DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.NullOrGe("stop", datafine));
            }



            DataRow[] dalia =
                Conn.RUN_SELECT("registrylegalstatus", "iddaliaposition", null, filter, null, false).Select();
            if (dalia.Length == 0 && !quiet) {
                show("Il percipiente selezionato non ha una qualifica Dalia negli inquadramenti", "Errore");
                return;
            }
            if (dalia.Length > 0) {
                string filterDalia = QHS.FieldIn("iddaliaposition", dalia);
                Meta.DoMainCommand("choose.dalia_position.default." + filterDalia);
                //Il resto lo fa in automatico essendo dalia_position parent della tabella principale
            }

        }

		private void btnRipartizione_Click(object sender, EventArgs e) {

            if (controller.IsEmpty)
				return;
			
			if (DS.itineration.Rows.Count == 0)
                return;
            DataRow RC = DS.itineration.Rows[0];
            if (RC == null)
                return;

            object idcostpartition = RC["idcostpartition"];

            if (idcostpartition != DBNull.Value) {
                MetaData ToMeta = dispatcher.Get("costpartition");
                string checkfilter = QHS.CmpEq("idcostpartition", idcostpartition);
                ToMeta.ContextFilter = checkfilter;
                Form F = null;
                if (controller.linkedForm != null)
                    F = controller.linkedForm.ParentForm;
                bool result = ToMeta.Edit(F, "default", false);

                string listtype = ToMeta.DefaultListType;
                DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
                if (R != null)
                    ToMeta.SelectRow(R, listtype);
            }
            else {
                idcostpartition = EP_functions.importCostPartitionDetail((MetaData)Meta);
                if (idcostpartition == null)
                    return;
                RC["idcostpartition"] = idcostpartition;
				DS.costpartition.Clear();
				Conn.RUN_SELECT_INTO_TABLE(DS.costpartition, null, QHS.CmpEq("idcostpartition", idcostpartition), null, true);
				if (DS.costpartition.Rows.Count > 0) {
					DataRow rCostpartition = DS.costpartition.Rows[0];
					txtDenRipartizione.Text = rCostpartition["title"].ToString();
					txtCodiceRipartizione.Text = rCostpartition["costpartitioncode"].ToString();
				}
			}
        }
    }
}
