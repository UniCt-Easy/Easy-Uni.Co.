
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Data;
using ep_functions;
using ap_functions;
using calcolooccasionale;
using System.Collections.Generic;
using q  = metadatalibrary.MetaExpression;
namespace casualcontract_default { //contrattooccasionale//

    /// <summary>
    /// Summary description for frmcontrattooccasionale.
    /// </summary>
    public class Frm_casualcontract_default : MetaDataForm {
        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContratto;
        private System.Windows.Forms.TabPage tabSpese;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.GroupBox grpPercipiente;
        private System.Windows.Forms.TextBox txtPercipiente;
        private System.Windows.Forms.GroupBox grpContratto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpDettagliPrevidenzialiAssistenziali;
        private System.Windows.Forms.Button btnAttivitaPrevINPS;
        private System.Windows.Forms.Button btnAltreFormeAssicurative;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TabPage tabRitenute;
        private System.Windows.Forms.TabPage tabImponibili;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SubEntity_txtImpAltriEnti;
        private System.Windows.Forms.TextBox txtImpAltriContratti;
        private System.Windows.Forms.TextBox txtImpContratto;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRitFiscaleDip;
        private System.Windows.Forms.TextBox txtRitPrevidenzialeDip;
        private System.Windows.Forms.TextBox txtRitAssicurativaDip;
        private System.Windows.Forms.TextBox txtRitAssistenzialeDip;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtImportoNetto;
        private System.Windows.Forms.TextBox txtCostoTotale;
        private System.Windows.Forms.TextBox txtDurataGiorni;
        private System.Windows.Forms.TextBox txtRitAssicurativaAmm;
        private System.Windows.Forms.TextBox txtRitAssistenzialeAmm;
        private System.Windows.Forms.TextBox txtRitPrevidenzialeAmm;
        private System.Windows.Forms.TextBox txtRitFiscaleAmm;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.GroupBox gboxPrevidenziale;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtImponibilePrevidenziale;
        private System.Windows.Forms.TextBox txtH2;
        private System.Windows.Forms.TextBox txtImpPrevContratto;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSpesePrevidenziali;
        private System.Windows.Forms.TextBox txtSpeseFiscali;
        private System.Windows.Forms.TextBox txtTotaleImpFisc2;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.TextBox txtCostoTotaleInput;
        private System.Windows.Forms.TextBox txtLordoAlBeneficiario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox SubEntity_cmbAliquotaFiscale;
        private System.Windows.Forms.RadioButton SubEntity_rdoAliquotaMarginale;
        private System.Windows.Forms.RadioButton SubEntity_rdoAliquotaCorrente;
        private System.Windows.Forms.TabPage tabClassSuppl;
        private System.Windows.Forms.Button btnClassInserisci;
        private System.Windows.Forms.Button btnClassModifica;
        private System.Windows.Forms.Button btnClassElimina;
        private System.Windows.Forms.DataGrid dgrClassSuppl;
        private System.Windows.Forms.Button btnTipoRapporto;
        private System.Windows.Forms.ComboBox SubEntity_cmbTipoRapporto;
        private System.Windows.Forms.ComboBox SubEntity_cmbAttPrevidenzialeINPS;
        private System.Windows.Forms.ComboBox SubEntity_cmbAltreFormeAssicurative;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        MetaData Meta;
        string filteresercizio = "";
        bool inChiusura;
        int lastCreditore = 0;
        decimal lastCompensoLordo = 0;
        decimal lastImponibiliAltriContratti = 0;
        decimal lastImponibiliAltriEnti = 0;
        private System.Windows.Forms.CheckBox chkPagabile;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAnalitico;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gBoxCausale;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button5;
        decimal lastAliquotaMarginale = 0;
        private System.Windows.Forms.Button btnGeneraEP;
        private System.Windows.Forms.Button btnVisualizzaEP;
        private System.Windows.Forms.Label labEP;
        private System.Windows.Forms.Button btnGeneraEpExp;
        private System.Windows.Forms.Button btnVisualizzaEpExp;
        private System.Windows.Forms.TabPage tabAnaPrest;
        private System.Windows.Forms.Button btnGeneraAP;
        private System.Windows.Forms.Button btnVisualizzaAP;
        private System.Windows.Forms.Label labAPnongenerato;
        private System.Windows.Forms.Label labAPgenerato;
        private Button btnRicalcola;
        private GroupBox gBoxCausaleDebitoCrg;
        private TextBox textBox4;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox gBoxCausaleDebito;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private Label label43;
        private TextBox textBox3;
        private Label label45;
        private Label label44;
        private TextBox txtLordoPagatoAnniPrec;
        private TextBox txtCostoPagato;
        private Label label46;
        private TextBox txtCostoAnniPrec;
        private Label label47;
        private TextBox txtLordoPagato;
        private Label label37;
        private TextBox txtC1;
        private Label label48;
        private Label label49;
        private TextBox txtC2;
        private Label label50;
        private Label label53;
        private TextBox txtF3;
        private Label label54;
        private Label label51;
        private TextBox txtF2;
        private Label label52;
        private Label label55;
        private Label label57;
        private TextBox txtImpFiscaleContratto;
        private Label label56;
        private TextBox txtH1;
        private Label label59;
        private Label label60;
        private TextBox txtI;
        private Label label61;
        private Label label58;
        private TabPage tabStorico;
        private TextBox txtSpeseFiscaliResidue;
        private Label label39;
        private TextBox txtImpResiduo;
        private Label label38;
        private TextBox txtImpFiscaleNettoResiduo;
        private Label label72;
        private TextBox textQuotaesenteDaApplicare;
        private Label label73;
        private TextBox txtSpesePrevResidue;
        private Label label74;
        private TextBox txtImpPrevidenzialeResiduo;
        private Label label75;
        private TextBox txtQuotaEsenteAnno;
        private Label label63;
        private TextBox txtSpesePrevAnno;
        private Label label64;
        private TextBox txtSpeseFisAnno;
        private Label label66;
        private TextBox txtImportoAnno;
        private Label label67;
        private GroupBox groupBox12;
        private TextBox txtCostoAnno;
        private Label label68;
        private TextBox txtContrAssicurAnno;
        private TextBox txtContrAssistAnno;
        private TextBox txtContrPrevAnno;
        private TextBox txtContrFisAnno;
        private Label label69;
        private Label label70;
        private Label label71;
        private Label label76;
        private GroupBox groupBox13;
        private TextBox txtNettoAnno;
        private Label label77;
        private TextBox txtAssistAnno;
        private TextBox txtAssicurAnno;
        private TextBox txtPrevAnno;
        private TextBox txtFisAnno;
        private Label label78;
        private Label label79;
        private Label label80;
        private Label label81;
        private GroupBox grpBoxMotivo;
        private TextBox txtMotivoAut;
        private GroupBox grpBoxAutorizzazioneAP;
        private RadioButton rdbAutorizzazioneNonNecessaria;
        private RadioButton rdbNonApplicabile;
        private RadioButton rdbNecessitaAutorizzazione;
        private GroupBox grpBoxDocAutorizzattivo;
        private TextBox txtDocumentoAut;
        private Label label62;
        private TextBox txtDataDocumentoAut;
        private Label label65;
        private TabPage tabAttributi;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
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
        private TabPage tabRegistroUnico;
        private GroupBox grpRegistroUnico;
        private TextBox txtCIG;
        private Label lblcig;
        private Label label87;
        private TextBox txtCUP;
        private TextBox txtScadenza;
        private Label label86;
        private Label label85;
        private TextBox txDataRicezioneRU;
        private TextBox txtProgressivoRU;
        private Label label82;
        private Label label83;
        private TextBox txtProtocolloEntrataRU;
        private TextBox txtAnnotazioniRU;
        private Label label84;
        private Button btnCreaRegistroUnico;
        private CheckBox checkBox2;
        private Label label88;
        private DataGrid dgrPCC;
        private ComboBox cmbipa;
        private RichTextBox richTextBox1;
        private GroupBox grpNaturadiSpesa;
        private RadioButton rdbContoCapitale;
        private RadioButton rdbSpesaCorrente;
        private Button btnCasuale;
        private TextBox txtCausale;
        private Label label89;
        private ComboBox cmbStatodelDebito;
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
        private Label lblDateCompleted;
        private TextBox txtDateCompleted;
        private TabPage tabDalia;
        private GroupBox gboxDalia;
        private Label label91;
        private TextBox textBox6;
        private ComboBox cmb_dalia_position;
        private Button btnVoceSpesaDalia;
        private TextBox txtVoceSpesaDalia;
        private Button btnQualificaDalia;
        private Button btnTrasfoccasionali;
        private GroupBox grpBoxSiopeEP;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnSiope;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkCCdedicato;
        private GroupBox grpCausaliAssunzioneDalia;
        private TextBox txtCausaleAssunzione;
        private Button btnEsclusioneCIG;
        private CheckBox chkEP;
		private GroupBox groupBox2;
		private ComboBox cmbDaliaFunzionale;
		private GroupBox gboxDipartimento;
		private Button btnDipartimento;
		private TextBox txtCodiceDipartimento;
		public TextBox txtDaliaDipartimento;
		private CheckBox SubEntity_chkExcludeFromCertificate;
		private TabPage tabAllegati;
		private DataGrid dgrAllegati;
		private Button btnDelAtt;
		private Button btnEditAtt;
		private Button btnInsAtt;
		private Button btnRipartizione;
		public GroupBox grpRipartizioneCosti;
		public Button btnCodRipartizione;
		public TextBox textBox7;
		public TextBox txtCodiceRipartizione;
		DataAccess Conn;

        public Frm_casualcontract_default() {
            InitializeComponent();
            inChiusura = false;
            cmbDaliaFunzionale.DataSource = DS.dalia_funzionale;
            cmbDaliaFunzionale.DisplayMember = "title";
            cmbDaliaFunzionale.ValueMember = "iddalia_funzionale";
			HelpForm.SetDenyNull(DS.casualcontract.Columns["flagexcludefromcertificate"], true);	
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_casualcontract_default));
			this.DS = new casualcontract_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabContratto = new System.Windows.Forms.TabPage();
			this.SubEntity_chkExcludeFromCertificate = new System.Windows.Forms.CheckBox();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.btnTrasfoccasionali = new System.Windows.Forms.Button();
			this.lblDateCompleted = new System.Windows.Forms.Label();
			this.txtDateCompleted = new System.Windows.Forms.TextBox();
			this.btnRicalcola = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtLordoAlBeneficiario = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.txtLordoPagato = new System.Windows.Forms.TextBox();
			this.txtCostoTotaleInput = new System.Windows.Forms.TextBox();
			this.txtCostoPagato = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.txtCostoAnniPrec = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.txtLordoPagatoAnniPrec = new System.Windows.Forms.TextBox();
			this.chkPagabile = new System.Windows.Forms.CheckBox();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.grpDettagliPrevidenzialiAssistenziali = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.btnAltreFormeAssicurative = new System.Windows.Forms.Button();
			this.SubEntity_cmbAltreFormeAssicurative = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btnAttivitaPrevINPS = new System.Windows.Forms.Button();
			this.SubEntity_cmbAttPrevidenzialeINPS = new System.Windows.Forms.ComboBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.btnTipoRapporto = new System.Windows.Forms.Button();
			this.SubEntity_cmbTipoRapporto = new System.Windows.Forms.ComboBox();
			this.grpPrestazione = new System.Windows.Forms.GroupBox();
			this.btnTipoPrestazione = new System.Windows.Forms.Button();
			this.cmbTipoPrestazione = new System.Windows.Forms.ComboBox();
			this.grpPercipiente = new System.Windows.Forms.GroupBox();
			this.txtPercipiente = new System.Windows.Forms.TextBox();
			this.grpContratto = new System.Windows.Forms.GroupBox();
			this.txtNumContratto = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDurataGiorni = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabSpese = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabImponibili = new System.Windows.Forms.TabPage();
			this.label55 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gboxPrevidenziale = new System.Windows.Forms.GroupBox();
			this.label60 = new System.Windows.Forms.Label();
			this.txtI = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.txtH1 = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.txtF3 = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.txtF2 = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label36 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.txtImpPrevContratto = new System.Windows.Forms.TextBox();
			this.txtH2 = new System.Windows.Forms.TextBox();
			this.txtImponibilePrevidenziale = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.txtTotaleImpFisc2 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtSpesePrevidenziali = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label57 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.txtImpFiscaleContratto = new System.Windows.Forms.TextBox();
			this.txtC2 = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.label50 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.txtC1 = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.SubEntity_cmbAliquotaFiscale = new System.Windows.Forms.ComboBox();
			this.SubEntity_rdoAliquotaMarginale = new System.Windows.Forms.RadioButton();
			this.SubEntity_rdoAliquotaCorrente = new System.Windows.Forms.RadioButton();
			this.label10 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.txtImpContratto = new System.Windows.Forms.TextBox();
			this.txtD = new System.Windows.Forms.TextBox();
			this.txtSpeseFiscali = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.SubEntity_txtImpAltriEnti = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.txtImpAltriContratti = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label31 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.txtImpPrevidenzialeResiduo = new System.Windows.Forms.TextBox();
			this.label75 = new System.Windows.Forms.Label();
			this.textQuotaesenteDaApplicare = new System.Windows.Forms.TextBox();
			this.label73 = new System.Windows.Forms.Label();
			this.txtSpesePrevResidue = new System.Windows.Forms.TextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.txtImpFiscaleNettoResiduo = new System.Windows.Forms.TextBox();
			this.label72 = new System.Windows.Forms.Label();
			this.txtSpeseFiscaliResidue = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.txtImpResiduo = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtCostoTotale = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtRitAssicurativaAmm = new System.Windows.Forms.TextBox();
			this.txtRitAssistenzialeAmm = new System.Windows.Forms.TextBox();
			this.txtRitPrevidenzialeAmm = new System.Windows.Forms.TextBox();
			this.txtRitFiscaleAmm = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtImportoNetto = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtRitAssistenzialeDip = new System.Windows.Forms.TextBox();
			this.txtRitAssicurativaDip = new System.Windows.Forms.TextBox();
			this.txtRitPrevidenzialeDip = new System.Windows.Forms.TextBox();
			this.txtRitFiscaleDip = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tabStorico = new System.Windows.Forms.TabPage();
			this.txtQuotaEsenteAnno = new System.Windows.Forms.TextBox();
			this.label63 = new System.Windows.Forms.Label();
			this.txtSpesePrevAnno = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.txtSpeseFisAnno = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.txtImportoAnno = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.txtCostoAnno = new System.Windows.Forms.TextBox();
			this.label68 = new System.Windows.Forms.Label();
			this.txtContrAssicurAnno = new System.Windows.Forms.TextBox();
			this.txtContrAssistAnno = new System.Windows.Forms.TextBox();
			this.txtContrPrevAnno = new System.Windows.Forms.TextBox();
			this.txtContrFisAnno = new System.Windows.Forms.TextBox();
			this.label69 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.txtNettoAnno = new System.Windows.Forms.TextBox();
			this.label77 = new System.Windows.Forms.Label();
			this.txtAssistAnno = new System.Windows.Forms.TextBox();
			this.txtAssicurAnno = new System.Windows.Forms.TextBox();
			this.txtPrevAnno = new System.Windows.Forms.TextBox();
			this.txtFisAnno = new System.Windows.Forms.TextBox();
			this.label78 = new System.Windows.Forms.Label();
			this.label79 = new System.Windows.Forms.Label();
			this.label80 = new System.Windows.Forms.Label();
			this.label81 = new System.Windows.Forms.Label();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.chkEP = new System.Windows.Forms.CheckBox();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.btnUPB = new System.Windows.Forms.Button();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.btnCodRipartizione = new System.Windows.Forms.Button();
			this.textBox7 = new System.Windows.Forms.TextBox();
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
			this.label43 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.gBoxCausaleDebitoCrg = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.gBoxCausaleDebito = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.gBoxCausale = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.tabClassSuppl = new System.Windows.Forms.TabPage();
			this.dgrClassSuppl = new System.Windows.Forms.DataGrid();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
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
			this.tabAnaPrest = new System.Windows.Forms.TabPage();
			this.btnCollegaAP = new System.Windows.Forms.Button();
			this.grpBoxDocAutorizzattivo = new System.Windows.Forms.GroupBox();
			this.txtDocumentoAut = new System.Windows.Forms.TextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.txtDataDocumentoAut = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.grpBoxMotivo = new System.Windows.Forms.GroupBox();
			this.txtMotivoAut = new System.Windows.Forms.TextBox();
			this.grpBoxAutorizzazioneAP = new System.Windows.Forms.GroupBox();
			this.rdbAutorizzazioneNonNecessaria = new System.Windows.Forms.RadioButton();
			this.rdbNonApplicabile = new System.Windows.Forms.RadioButton();
			this.rdbNecessitaAutorizzazione = new System.Windows.Forms.RadioButton();
			this.btnGeneraAP = new System.Windows.Forms.Button();
			this.btnVisualizzaAP = new System.Windows.Forms.Button();
			this.labAPnongenerato = new System.Windows.Forms.Label();
			this.labAPgenerato = new System.Windows.Forms.Label();
			this.tabRegistroUnico = new System.Windows.Forms.TabPage();
			this.cmbipa = new System.Windows.Forms.ComboBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label88 = new System.Windows.Forms.Label();
			this.dgrPCC = new System.Windows.Forms.DataGrid();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.grpRegistroUnico = new System.Windows.Forms.GroupBox();
			this.btnCasuale = new System.Windows.Forms.Button();
			this.grpNaturadiSpesa = new System.Windows.Forms.GroupBox();
			this.rdbContoCapitale = new System.Windows.Forms.RadioButton();
			this.rdbSpesaCorrente = new System.Windows.Forms.RadioButton();
			this.txtCausale = new System.Windows.Forms.TextBox();
			this.label89 = new System.Windows.Forms.Label();
			this.btnCreaRegistroUnico = new System.Windows.Forms.Button();
			this.cmbStatodelDebito = new System.Windows.Forms.ComboBox();
			this.txtCIG = new System.Windows.Forms.TextBox();
			this.lblcig = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.txtCUP = new System.Windows.Forms.TextBox();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label86 = new System.Windows.Forms.Label();
			this.label85 = new System.Windows.Forms.Label();
			this.txDataRicezioneRU = new System.Windows.Forms.TextBox();
			this.txtProgressivoRU = new System.Windows.Forms.TextBox();
			this.label82 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.txtProtocolloEntrataRU = new System.Windows.Forms.TextBox();
			this.txtAnnotazioniRU = new System.Windows.Forms.TextBox();
			this.label84 = new System.Windows.Forms.Label();
			this.tabDalia = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
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
			this.gboxDalia = new System.Windows.Forms.GroupBox();
			this.btnQualificaDalia = new System.Windows.Forms.Button();
			this.label91 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dgrAllegati = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabContratto.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.grpDettagliPrevidenzialiAssistenziali.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.grpPrestazione.SuspendLayout();
			this.grpPercipiente.SuspendLayout();
			this.grpContratto.SuspendLayout();
			this.tabSpese.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabImponibili.SuspendLayout();
			this.gboxPrevidenziale.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabRitenute.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabStorico.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.tabEP.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.gBoxCausaleDebitoCrg.SuspendLayout();
			this.gBoxCausaleDebito.SuspendLayout();
			this.gBoxCausale.SuspendLayout();
			this.tabClassSuppl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).BeginInit();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAnaPrest.SuspendLayout();
			this.grpBoxDocAutorizzattivo.SuspendLayout();
			this.grpBoxMotivo.SuspendLayout();
			this.grpBoxAutorizzazioneAP.SuspendLayout();
			this.tabRegistroUnico.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).BeginInit();
			this.grpRegistroUnico.SuspendLayout();
			this.grpNaturadiSpesa.SuspendLayout();
			this.tabDalia.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.gboxDipartimento.SuspendLayout();
			this.grpCausaliAssunzioneDalia.SuspendLayout();
			this.gboxDalia.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrAllegati)).BeginInit();
			this.SuspendLayout();
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
			this.tabControl1.Controls.Add(this.tabContratto);
			this.tabControl1.Controls.Add(this.tabSpese);
			this.tabControl1.Controls.Add(this.tabImponibili);
			this.tabControl1.Controls.Add(this.tabRitenute);
			this.tabControl1.Controls.Add(this.tabStorico);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabClassSuppl);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAnaPrest);
			this.tabControl1.Controls.Add(this.tabRegistroUnico);
			this.tabControl1.Controls.Add(this.tabDalia);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(887, 529);
			this.tabControl1.TabIndex = 0;
			// 
			// tabContratto
			// 
			this.tabContratto.Controls.Add(this.SubEntity_chkExcludeFromCertificate);
			this.tabContratto.Controls.Add(this.grpCertificatiNecessari);
			this.tabContratto.Controls.Add(this.btnTrasfoccasionali);
			this.tabContratto.Controls.Add(this.lblDateCompleted);
			this.tabContratto.Controls.Add(this.txtDateCompleted);
			this.tabContratto.Controls.Add(this.btnRicalcola);
			this.tabContratto.Controls.Add(this.label6);
			this.tabContratto.Controls.Add(this.txtLordoAlBeneficiario);
			this.tabContratto.Controls.Add(this.label47);
			this.tabContratto.Controls.Add(this.label40);
			this.tabContratto.Controls.Add(this.txtLordoPagato);
			this.tabContratto.Controls.Add(this.txtCostoTotaleInput);
			this.tabContratto.Controls.Add(this.txtCostoPagato);
			this.tabContratto.Controls.Add(this.label46);
			this.tabContratto.Controls.Add(this.txtCostoAnniPrec);
			this.tabContratto.Controls.Add(this.label45);
			this.tabContratto.Controls.Add(this.label44);
			this.tabContratto.Controls.Add(this.txtLordoPagatoAnniPrec);
			this.tabContratto.Controls.Add(this.chkPagabile);
			this.tabContratto.Controls.Add(this.txtDataContabile);
			this.tabContratto.Controls.Add(this.label22);
			this.tabContratto.Controls.Add(this.textBox2);
			this.tabContratto.Controls.Add(this.label8);
			this.tabContratto.Controls.Add(this.grpDettagliPrevidenzialiAssistenziali);
			this.tabContratto.Controls.Add(this.grpPrestazione);
			this.tabContratto.Controls.Add(this.grpPercipiente);
			this.tabContratto.Controls.Add(this.grpContratto);
			this.tabContratto.Controls.Add(this.txtDataFine);
			this.tabContratto.Controls.Add(this.label4);
			this.tabContratto.Controls.Add(this.txtDurataGiorni);
			this.tabContratto.Controls.Add(this.label5);
			this.tabContratto.Controls.Add(this.txtDataInizio);
			this.tabContratto.Controls.Add(this.label3);
			this.tabContratto.Location = new System.Drawing.Point(4, 23);
			this.tabContratto.Name = "tabContratto";
			this.tabContratto.Size = new System.Drawing.Size(879, 502);
			this.tabContratto.TabIndex = 0;
			this.tabContratto.Text = "Generale";
			this.tabContratto.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkExcludeFromCertificate
			// 
			this.SubEntity_chkExcludeFromCertificate.AutoSize = true;
			this.SubEntity_chkExcludeFromCertificate.Location = new System.Drawing.Point(9, 71);
			this.SubEntity_chkExcludeFromCertificate.Name = "SubEntity_chkExcludeFromCertificate";
			this.SubEntity_chkExcludeFromCertificate.Size = new System.Drawing.Size(225, 17);
			this.SubEntity_chkExcludeFromCertificate.TabIndex = 116;
			this.SubEntity_chkExcludeFromCertificate.Tag = "casualcontract.flagexcludefromcertificate:S:N";
			this.SubEntity_chkExcludeFromCertificate.Text = "Escludi da Certificazione Unica dei Redditi";
			this.SubEntity_chkExcludeFromCertificate.UseVisualStyleBackColor = true;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(668, 436);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(124, 56);
			this.grpCertificatiNecessari.TabIndex = 115;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(18, 26);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "casualcontract.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// btnTrasfoccasionali
			// 
			this.btnTrasfoccasionali.Location = new System.Drawing.Point(732, 66);
			this.btnTrasfoccasionali.Name = "btnTrasfoccasionali";
			this.btnTrasfoccasionali.Size = new System.Drawing.Size(131, 64);
			this.btnTrasfoccasionali.TabIndex = 114;
			this.btnTrasfoccasionali.TabStop = false;
			this.btnTrasfoccasionali.Text = "Trasferisci nell\'esercizio successivo";
			this.btnTrasfoccasionali.UseVisualStyleBackColor = false;
			this.btnTrasfoccasionali.Click += new System.EventHandler(this.btnTrasfoccasionali_Click);
			// 
			// lblDateCompleted
			// 
			this.lblDateCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblDateCompleted.AutoSize = true;
			this.lblDateCompleted.Location = new System.Drawing.Point(491, 175);
			this.lblDateCompleted.Name = "lblDateCompleted";
			this.lblDateCompleted.Size = new System.Drawing.Size(217, 13);
			this.lblDateCompleted.TabIndex = 113;
			this.lblDateCompleted.Text = "Data acquisizione documentazione definitiva";
			this.lblDateCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDateCompleted
			// 
			this.txtDateCompleted.Location = new System.Drawing.Point(714, 171);
			this.txtDateCompleted.Name = "txtDateCompleted";
			this.txtDateCompleted.Size = new System.Drawing.Size(149, 20);
			this.txtDateCompleted.TabIndex = 8;
			this.txtDateCompleted.Tag = "casualcontract.datecompleted";
			// 
			// btnRicalcola
			// 
			this.btnRicalcola.Location = new System.Drawing.Point(732, 20);
			this.btnRicalcola.Name = "btnRicalcola";
			this.btnRicalcola.Size = new System.Drawing.Size(131, 40);
			this.btnRicalcola.TabIndex = 17;
			this.btnRicalcola.Text = "Ricalcola prestazione";
			this.btnRicalcola.UseVisualStyleBackColor = true;
			this.btnRicalcola.Click += new System.EventHandler(this.btnRicalcola_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(10, 243);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(274, 20);
			this.label6.TabIndex = 30;
			this.label6.Text = "Lordo al beneficiario contratto (comprensivo spese)";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLordoAlBeneficiario
			// 
			this.txtLordoAlBeneficiario.Location = new System.Drawing.Point(291, 244);
			this.txtLordoAlBeneficiario.Name = "txtLordoAlBeneficiario";
			this.txtLordoAlBeneficiario.Size = new System.Drawing.Size(168, 20);
			this.txtLordoAlBeneficiario.TabIndex = 9;
			this.txtLordoAlBeneficiario.Tag = "casualcontract.feegross";
			this.txtLordoAlBeneficiario.Leave += new System.EventHandler(this.txtLordoAlBeneficiario_Leave);
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(124, 224);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(160, 13);
			this.label47.TabIndex = 40;
			this.label47.Text = "Lordo complessivamente pagato";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(513, 245);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(180, 20);
			this.label40.TabIndex = 31;
			this.label40.Text = "Costo totale del contratto stimato";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLordoPagato
			// 
			this.txtLordoPagato.Location = new System.Drawing.Point(291, 220);
			this.txtLordoPagato.Name = "txtLordoPagato";
			this.txtLordoPagato.ReadOnly = true;
			this.txtLordoPagato.Size = new System.Drawing.Size(168, 20);
			this.txtLordoPagato.TabIndex = 39;
			this.txtLordoPagato.TabStop = false;
			this.txtLordoPagato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCostoTotaleInput
			// 
			this.txtCostoTotaleInput.Location = new System.Drawing.Point(695, 244);
			this.txtCostoTotaleInput.Name = "txtCostoTotaleInput";
			this.txtCostoTotaleInput.Size = new System.Drawing.Size(168, 20);
			this.txtCostoTotaleInput.TabIndex = 10;
			this.txtCostoTotaleInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCostoTotaleInput.Leave += new System.EventHandler(this.txtCostoTotaleInput_Leave);
			// 
			// txtCostoPagato
			// 
			this.txtCostoPagato.Location = new System.Drawing.Point(695, 220);
			this.txtCostoPagato.Name = "txtCostoPagato";
			this.txtCostoPagato.ReadOnly = true;
			this.txtCostoPagato.Size = new System.Drawing.Size(168, 20);
			this.txtCostoPagato.TabIndex = 38;
			this.txtCostoPagato.TabStop = false;
			this.txtCostoPagato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(491, 221);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(202, 20);
			this.label46.TabIndex = 37;
			this.label46.Text = "Costo totale complessivamente pagato";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCostoAnniPrec
			// 
			this.txtCostoAnniPrec.Location = new System.Drawing.Point(695, 196);
			this.txtCostoAnniPrec.Name = "txtCostoAnniPrec";
			this.txtCostoAnniPrec.ReadOnly = true;
			this.txtCostoAnniPrec.Size = new System.Drawing.Size(168, 20);
			this.txtCostoAnniPrec.TabIndex = 36;
			this.txtCostoAnniPrec.TabStop = false;
			this.txtCostoAnniPrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(491, 197);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(202, 20);
			this.label45.TabIndex = 35;
			this.label45.Text = "Costo totale pagato anni precedenti";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(138, 200);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(146, 13);
			this.label44.TabIndex = 34;
			this.label44.Text = "Lordo pagato anni precedenti";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLordoPagatoAnniPrec
			// 
			this.txtLordoPagatoAnniPrec.Location = new System.Drawing.Point(291, 196);
			this.txtLordoPagatoAnniPrec.Name = "txtLordoPagatoAnniPrec";
			this.txtLordoPagatoAnniPrec.ReadOnly = true;
			this.txtLordoPagatoAnniPrec.Size = new System.Drawing.Size(168, 20);
			this.txtLordoPagatoAnniPrec.TabIndex = 33;
			this.txtLordoPagatoAnniPrec.TabStop = false;
			this.txtLordoPagatoAnniPrec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkPagabile
			// 
			this.chkPagabile.Location = new System.Drawing.Point(291, 69);
			this.chkPagabile.Name = "chkPagabile";
			this.chkPagabile.Size = new System.Drawing.Size(197, 21);
			this.chkPagabile.TabIndex = 7;
			this.chkPagabile.Tag = "casualcontract.completed:S:N";
			this.chkPagabile.Text = "Considera eseguito quindi pagabile";
			this.chkPagabile.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			this.chkPagabile.CheckStateChanged += new System.EventHandler(this.chkPagabile_CheckStateChanged);
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(384, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(102, 20);
			this.txtDataContabile.TabIndex = 4;
			this.txtDataContabile.Tag = "casualcontract.adate";
			this.txtDataContabile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(304, 40);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 23);
			this.label22.TabIndex = 23;
			this.label22.Text = "Data Contabile";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 442);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(640, 50);
			this.textBox2.TabIndex = 12;
			this.textBox2.Tag = "casualcontract.description";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 429);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 17);
			this.label8.TabIndex = 21;
			this.label8.Text = "Descrizione";
			// 
			// grpDettagliPrevidenzialiAssistenziali
			// 
			this.grpDettagliPrevidenzialiAssistenziali.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.groupBox8);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.groupBox7);
			this.grpDettagliPrevidenzialiAssistenziali.Controls.Add(this.groupBox6);
			this.grpDettagliPrevidenzialiAssistenziali.Location = new System.Drawing.Point(8, 276);
			this.grpDettagliPrevidenzialiAssistenziali.Name = "grpDettagliPrevidenzialiAssistenziali";
			this.grpDettagliPrevidenzialiAssistenziali.Size = new System.Drawing.Size(863, 150);
			this.grpDettagliPrevidenzialiAssistenziali.TabIndex = 11;
			this.grpDettagliPrevidenzialiAssistenziali.TabStop = false;
			this.grpDettagliPrevidenzialiAssistenziali.Text = "Informazioni indispensabili alla redazione della denuncia E-Mens se la prestazion" +
    "e è soggetta ad INPS";
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.btnAltreFormeAssicurative);
			this.groupBox8.Controls.Add(this.SubEntity_cmbAltreFormeAssicurative);
			this.groupBox8.Location = new System.Drawing.Point(8, 100);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(847, 40);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			// 
			// btnAltreFormeAssicurative
			// 
			this.btnAltreFormeAssicurative.Location = new System.Drawing.Point(8, 11);
			this.btnAltreFormeAssicurative.Name = "btnAltreFormeAssicurative";
			this.btnAltreFormeAssicurative.Size = new System.Drawing.Size(96, 23);
			this.btnAltreFormeAssicurative.TabIndex = 5;
			this.btnAltreFormeAssicurative.Tag = "manage.otherinsurance.default";
			this.btnAltreFormeAssicurative.Text = "Altra Forma Ass.";
			// 
			// SubEntity_cmbAltreFormeAssicurative
			// 
			this.SubEntity_cmbAltreFormeAssicurative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbAltreFormeAssicurative.DataSource = this.DS.otherinsurance;
			this.SubEntity_cmbAltreFormeAssicurative.DisplayMember = "description";
			this.SubEntity_cmbAltreFormeAssicurative.ItemHeight = 13;
			this.SubEntity_cmbAltreFormeAssicurative.Location = new System.Drawing.Point(112, 12);
			this.SubEntity_cmbAltreFormeAssicurative.Name = "SubEntity_cmbAltreFormeAssicurative";
			this.SubEntity_cmbAltreFormeAssicurative.Size = new System.Drawing.Size(727, 21);
			this.SubEntity_cmbAltreFormeAssicurative.TabIndex = 6;
			this.SubEntity_cmbAltreFormeAssicurative.Tag = "casualcontractyear.idotherinsurance?casualcontractview.idotherinsurance";
			this.SubEntity_cmbAltreFormeAssicurative.ValueMember = "idotherinsurance";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.btnAttivitaPrevINPS);
			this.groupBox7.Controls.Add(this.SubEntity_cmbAttPrevidenzialeINPS);
			this.groupBox7.Location = new System.Drawing.Point(8, 58);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(847, 40);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			// 
			// btnAttivitaPrevINPS
			// 
			this.btnAttivitaPrevINPS.Location = new System.Drawing.Point(8, 11);
			this.btnAttivitaPrevINPS.Name = "btnAttivitaPrevINPS";
			this.btnAttivitaPrevINPS.Size = new System.Drawing.Size(96, 23);
			this.btnAttivitaPrevINPS.TabIndex = 3;
			this.btnAttivitaPrevINPS.Tag = "manage.inpsactivity.default";
			this.btnAttivitaPrevINPS.Text = "Att. Prev. INPS";
			// 
			// SubEntity_cmbAttPrevidenzialeINPS
			// 
			this.SubEntity_cmbAttPrevidenzialeINPS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbAttPrevidenzialeINPS.DataSource = this.DS.inpsactivity;
			this.SubEntity_cmbAttPrevidenzialeINPS.DisplayMember = "description";
			this.SubEntity_cmbAttPrevidenzialeINPS.ItemHeight = 13;
			this.SubEntity_cmbAttPrevidenzialeINPS.Location = new System.Drawing.Point(112, 12);
			this.SubEntity_cmbAttPrevidenzialeINPS.Name = "SubEntity_cmbAttPrevidenzialeINPS";
			this.SubEntity_cmbAttPrevidenzialeINPS.Size = new System.Drawing.Size(727, 21);
			this.SubEntity_cmbAttPrevidenzialeINPS.TabIndex = 4;
			this.SubEntity_cmbAttPrevidenzialeINPS.Tag = "casualcontractyear.activitycode?casualcontractview.activitycode";
			this.SubEntity_cmbAttPrevidenzialeINPS.ValueMember = "activitycode";
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.btnTipoRapporto);
			this.groupBox6.Controls.Add(this.SubEntity_cmbTipoRapporto);
			this.groupBox6.Location = new System.Drawing.Point(8, 16);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(847, 40);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			// 
			// btnTipoRapporto
			// 
			this.btnTipoRapporto.Location = new System.Drawing.Point(8, 11);
			this.btnTipoRapporto.Name = "btnTipoRapporto";
			this.btnTipoRapporto.Size = new System.Drawing.Size(96, 23);
			this.btnTipoRapporto.TabIndex = 1;
			this.btnTipoRapporto.Tag = "manage.emenscontractkind.default";
			this.btnTipoRapporto.Text = "Tipo rapporto";
			// 
			// SubEntity_cmbTipoRapporto
			// 
			this.SubEntity_cmbTipoRapporto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_cmbTipoRapporto.DataSource = this.DS.emenscontractkind;
			this.SubEntity_cmbTipoRapporto.DisplayMember = "description";
			this.SubEntity_cmbTipoRapporto.Location = new System.Drawing.Point(112, 12);
			this.SubEntity_cmbTipoRapporto.Name = "SubEntity_cmbTipoRapporto";
			this.SubEntity_cmbTipoRapporto.Size = new System.Drawing.Size(727, 21);
			this.SubEntity_cmbTipoRapporto.TabIndex = 2;
			this.SubEntity_cmbTipoRapporto.Tag = "casualcontractyear.idemenscontractkind?casualcontractview.idemenscontractkind";
			this.SubEntity_cmbTipoRapporto.ValueMember = "idemenscontractkind";
			// 
			// grpPrestazione
			// 
			this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
			this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
			this.grpPrestazione.Location = new System.Drawing.Point(8, 142);
			this.grpPrestazione.Name = "grpPrestazione";
			this.grpPrestazione.Size = new System.Drawing.Size(478, 48);
			this.grpPrestazione.TabIndex = 6;
			this.grpPrestazione.TabStop = false;
			this.grpPrestazione.Text = "Prestazione";
			// 
			// btnTipoPrestazione
			// 
			this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
			this.btnTipoPrestazione.Name = "btnTipoPrestazione";
			this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 24);
			this.btnTipoPrestazione.TabIndex = 6;
			this.btnTipoPrestazione.TabStop = false;
			this.btnTipoPrestazione.Tag = "choose.service.default";
			this.btnTipoPrestazione.Text = "Tipo";
			// 
			// cmbTipoPrestazione
			// 
			this.cmbTipoPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoPrestazione.DataSource = this.DS.service;
			this.cmbTipoPrestazione.DisplayMember = "description";
			this.cmbTipoPrestazione.ItemHeight = 13;
			this.cmbTipoPrestazione.Location = new System.Drawing.Point(88, 16);
			this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
			this.cmbTipoPrestazione.Size = new System.Drawing.Size(382, 21);
			this.cmbTipoPrestazione.TabIndex = 7;
			this.cmbTipoPrestazione.Tag = "casualcontract.idser";
			this.cmbTipoPrestazione.ValueMember = "idser";
			// 
			// grpPercipiente
			// 
			this.grpPercipiente.Controls.Add(this.txtPercipiente);
			this.grpPercipiente.Location = new System.Drawing.Point(8, 96);
			this.grpPercipiente.Name = "grpPercipiente";
			this.grpPercipiente.Size = new System.Drawing.Size(478, 45);
			this.grpPercipiente.TabIndex = 5;
			this.grpPercipiente.TabStop = false;
			this.grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active=\'S\') and (human=\'S\'))";
			this.grpPercipiente.Text = "Percipiente";
			// 
			// txtPercipiente
			// 
			this.txtPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercipiente.Location = new System.Drawing.Point(8, 16);
			this.txtPercipiente.Name = "txtPercipiente";
			this.txtPercipiente.Size = new System.Drawing.Size(462, 20);
			this.txtPercipiente.TabIndex = 0;
			this.txtPercipiente.Tag = "registry.title?casualcontractview.registry";
			// 
			// grpContratto
			// 
			this.grpContratto.Controls.Add(this.txtNumContratto);
			this.grpContratto.Controls.Add(this.label2);
			this.grpContratto.Controls.Add(this.txtEsercizio);
			this.grpContratto.Controls.Add(this.label1);
			this.grpContratto.Location = new System.Drawing.Point(8, 16);
			this.grpContratto.Name = "grpContratto";
			this.grpContratto.Size = new System.Drawing.Size(272, 48);
			this.grpContratto.TabIndex = 1;
			this.grpContratto.TabStop = false;
			this.grpContratto.Text = "Contratto";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(192, 16);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(72, 20);
			this.txtNumContratto.TabIndex = 3;
			this.txtNumContratto.Tag = "casualcontract.ncon";
			this.txtNumContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNumContratto.Leave += new System.EventHandler(this.txtNumContratto_Leave);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(144, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "Numero";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(64, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.Tag = "casualcontract.ycon.year";
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
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(603, 16);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(102, 20);
			this.txtDataFine.TabIndex = 3;
			this.txtDataFine.Tag = "casualcontract.stop";
			this.txtDataFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(515, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Data Fine";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDurataGiorni
			// 
			this.txtDurataGiorni.Location = new System.Drawing.Point(603, 40);
			this.txtDurataGiorni.Name = "txtDurataGiorni";
			this.txtDurataGiorni.ReadOnly = true;
			this.txtDurataGiorni.Size = new System.Drawing.Size(102, 20);
			this.txtDurataGiorni.TabIndex = 16;
			this.txtDurataGiorni.TabStop = false;
			this.txtDurataGiorni.Tag = "casualcontract.ndays";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(515, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Durata (Giorni)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(384, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(102, 20);
			this.txtDataInizio.TabIndex = 2;
			this.txtDataInizio.Tag = "casualcontract.start";
			this.txtDataInizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(304, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Data Inizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabSpese
			// 
			this.tabSpese.Controls.Add(this.dataGrid1);
			this.tabSpese.Controls.Add(this.button3);
			this.tabSpese.Controls.Add(this.button2);
			this.tabSpese.Controls.Add(this.button1);
			this.tabSpese.Location = new System.Drawing.Point(4, 23);
			this.tabSpese.Name = "tabSpese";
			this.tabSpese.Size = new System.Drawing.Size(879, 502);
			this.tabSpese.TabIndex = 1;
			this.tabSpese.Text = "Spese";
			this.tabSpese.UseVisualStyleBackColor = true;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.CaptionVisible = false;
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 40);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(863, 456);
			this.dataGrid1.TabIndex = 3;
			this.dataGrid1.Tag = "casualcontractrefund.default";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(208, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(112, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Tag = "insert.default";
			this.button1.Text = "Inserisci";
			// 
			// tabImponibili
			// 
			this.tabImponibili.Controls.Add(this.label55);
			this.tabImponibili.Controls.Add(this.panel1);
			this.tabImponibili.Controls.Add(this.gboxPrevidenziale);
			this.tabImponibili.Controls.Add(this.groupBox1);
			this.tabImponibili.Location = new System.Drawing.Point(4, 23);
			this.tabImponibili.Name = "tabImponibili";
			this.tabImponibili.Size = new System.Drawing.Size(879, 502);
			this.tabImponibili.TabIndex = 3;
			this.tabImponibili.Text = "Imponibili";
			this.tabImponibili.UseVisualStyleBackColor = true;
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(349, 451);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(423, 13);
			this.label55.TabIndex = 9;
			this.label55.Text = "Nota: tutte le informazioni di questa pagina si riferiscono esclusivamente all\'an" +
    "no in corso";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(340, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(2, 457);
			this.panel1.TabIndex = 8;
			// 
			// gboxPrevidenziale
			// 
			this.gboxPrevidenziale.Controls.Add(this.label60);
			this.gboxPrevidenziale.Controls.Add(this.txtI);
			this.gboxPrevidenziale.Controls.Add(this.label61);
			this.gboxPrevidenziale.Controls.Add(this.label58);
			this.gboxPrevidenziale.Controls.Add(this.txtH1);
			this.gboxPrevidenziale.Controls.Add(this.label59);
			this.gboxPrevidenziale.Controls.Add(this.label53);
			this.gboxPrevidenziale.Controls.Add(this.txtF3);
			this.gboxPrevidenziale.Controls.Add(this.label54);
			this.gboxPrevidenziale.Controls.Add(this.label51);
			this.gboxPrevidenziale.Controls.Add(this.txtF2);
			this.gboxPrevidenziale.Controls.Add(this.label52);
			this.gboxPrevidenziale.Controls.Add(this.panel4);
			this.gboxPrevidenziale.Controls.Add(this.panel3);
			this.gboxPrevidenziale.Controls.Add(this.label36);
			this.gboxPrevidenziale.Controls.Add(this.label35);
			this.gboxPrevidenziale.Controls.Add(this.label34);
			this.gboxPrevidenziale.Controls.Add(this.label33);
			this.gboxPrevidenziale.Controls.Add(this.label32);
			this.gboxPrevidenziale.Controls.Add(this.txtImpPrevContratto);
			this.gboxPrevidenziale.Controls.Add(this.txtH2);
			this.gboxPrevidenziale.Controls.Add(this.txtImponibilePrevidenziale);
			this.gboxPrevidenziale.Controls.Add(this.label27);
			this.gboxPrevidenziale.Controls.Add(this.label26);
			this.gboxPrevidenziale.Controls.Add(this.label25);
			this.gboxPrevidenziale.Controls.Add(this.txtTotaleImpFisc2);
			this.gboxPrevidenziale.Controls.Add(this.label24);
			this.gboxPrevidenziale.Controls.Add(this.txtSpesePrevidenziali);
			this.gboxPrevidenziale.Controls.Add(this.label23);
			this.gboxPrevidenziale.Location = new System.Drawing.Point(352, 8);
			this.gboxPrevidenziale.Name = "gboxPrevidenziale";
			this.gboxPrevidenziale.Size = new System.Drawing.Size(393, 436);
			this.gboxPrevidenziale.TabIndex = 7;
			this.gboxPrevidenziale.TabStop = false;
			this.gboxPrevidenziale.Text = "Imponibile Previdenziale Residuo";
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(263, 264);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(111, 20);
			this.label60.TabIndex = 36;
			this.label60.Text = "I = G-H1";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtI
			// 
			this.txtI.Location = new System.Drawing.Point(166, 264);
			this.txtI.Name = "txtI";
			this.txtI.ReadOnly = true;
			this.txtI.Size = new System.Drawing.Size(88, 20);
			this.txtI.TabIndex = 35;
			this.txtI.TabStop = false;
			this.txtI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(16, 251);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(136, 45);
			this.label61.TabIndex = 34;
			this.label61.Text = "Imponibile previdenziale netto già pagato ";
			this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(298, 220);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(24, 20);
			this.label58.TabIndex = 33;
			this.label58.Text = "H1";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtH1
			// 
			this.txtH1.Location = new System.Drawing.Point(166, 216);
			this.txtH1.Name = "txtH1";
			this.txtH1.ReadOnly = true;
			this.txtH1.Size = new System.Drawing.Size(88, 20);
			this.txtH1.TabIndex = 32;
			this.txtH1.TabStop = false;
			this.txtH1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label59
			// 
			this.label59.Location = new System.Drawing.Point(16, 210);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(136, 30);
			this.label59.TabIndex = 31;
			this.label59.Text = "Quota esente già applicata";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(298, 357);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(24, 20);
			this.label53.TabIndex = 30;
			this.label53.Text = "F3";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtF3
			// 
			this.txtF3.Location = new System.Drawing.Point(167, 357);
			this.txtF3.Name = "txtF3";
			this.txtF3.ReadOnly = true;
			this.txtF3.Size = new System.Drawing.Size(88, 20);
			this.txtF3.TabIndex = 29;
			this.txtF3.TabStop = false;
			this.txtF3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(8, 349);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(151, 47);
			this.label54.TabIndex = 28;
			this.label54.Text = "Spese ancora da dedurre di questo contratto";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(307, 119);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(24, 20);
			this.label51.TabIndex = 27;
			this.label51.Text = "F2";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtF2
			// 
			this.txtF2.Location = new System.Drawing.Point(167, 119);
			this.txtF2.Name = "txtF2";
			this.txtF2.ReadOnly = true;
			this.txtF2.Size = new System.Drawing.Size(88, 20);
			this.txtF2.TabIndex = 26;
			this.txtF2.TabStop = false;
			this.txtF2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(2, 111);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(151, 47);
			this.label52.TabIndex = 25;
			this.label52.Text = "Spese già dedotte  di questo contratto";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Location = new System.Drawing.Point(268, 394);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(70, 2);
			this.panel4.TabIndex = 24;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(292, 152);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(70, 2);
			this.panel3.TabIndex = 23;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(259, 407);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(103, 20);
			this.label36.TabIndex = 22;
			this.label36.Text = " = E- (H2+C3+F3)";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(298, 315);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(24, 20);
			this.label35.TabIndex = 21;
			this.label35.Text = "H2";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(263, 165);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(111, 45);
			this.label34.TabIndex = 20;
			this.label34.Text = "G =A+B2 - (F1+F2+C1+C2)";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(307, 72);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(24, 20);
			this.label33.TabIndex = 19;
			this.label33.Text = "F1";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(307, 32);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(24, 20);
			this.label32.TabIndex = 18;
			this.label32.Text = "B2";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtImpPrevContratto
			// 
			this.txtImpPrevContratto.Location = new System.Drawing.Point(167, 407);
			this.txtImpPrevContratto.Name = "txtImpPrevContratto";
			this.txtImpPrevContratto.ReadOnly = true;
			this.txtImpPrevContratto.Size = new System.Drawing.Size(88, 20);
			this.txtImpPrevContratto.TabIndex = 17;
			this.txtImpPrevContratto.TabStop = false;
			this.txtImpPrevContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtH2
			// 
			this.txtH2.Location = new System.Drawing.Point(167, 315);
			this.txtH2.Name = "txtH2";
			this.txtH2.ReadOnly = true;
			this.txtH2.Size = new System.Drawing.Size(88, 20);
			this.txtH2.TabIndex = 16;
			this.txtH2.TabStop = false;
			this.txtH2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImponibilePrevidenziale
			// 
			this.txtImponibilePrevidenziale.Location = new System.Drawing.Point(167, 178);
			this.txtImponibilePrevidenziale.Name = "txtImponibilePrevidenziale";
			this.txtImponibilePrevidenziale.ReadOnly = true;
			this.txtImponibilePrevidenziale.Size = new System.Drawing.Size(88, 20);
			this.txtImponibilePrevidenziale.TabIndex = 15;
			this.txtImponibilePrevidenziale.TabStop = false;
			this.txtImponibilePrevidenziale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(17, 396);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(142, 31);
			this.label27.TabIndex = 14;
			this.label27.Text = "Imponibile previdenziale netto  residuo";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(17, 309);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(136, 30);
			this.label26.TabIndex = 13;
			this.label26.Text = "Quota esente non ancora applicata";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(17, 165);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(136, 45);
			this.label25.TabIndex = 12;
			this.label25.Text = "Imponibile previdenziale dedotto delle spese già pagato ";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleImpFisc2
			// 
			this.txtTotaleImpFisc2.Location = new System.Drawing.Point(167, 32);
			this.txtTotaleImpFisc2.Name = "txtTotaleImpFisc2";
			this.txtTotaleImpFisc2.ReadOnly = true;
			this.txtTotaleImpFisc2.Size = new System.Drawing.Size(88, 20);
			this.txtTotaleImpFisc2.TabIndex = 11;
			this.txtTotaleImpFisc2.TabStop = false;
			this.txtTotaleImpFisc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(1, 16);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(152, 52);
			this.label24.TabIndex = 10;
			this.label24.Text = "Imponibile previdenziale già pagato";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSpesePrevidenziali
			// 
			this.txtSpesePrevidenziali.Location = new System.Drawing.Point(167, 72);
			this.txtSpesePrevidenziali.Name = "txtSpesePrevidenziali";
			this.txtSpesePrevidenziali.ReadOnly = true;
			this.txtSpesePrevidenziali.Size = new System.Drawing.Size(88, 20);
			this.txtSpesePrevidenziali.TabIndex = 9;
			this.txtSpesePrevidenziali.TabStop = false;
			this.txtSpesePrevidenziali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(1, 64);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(151, 47);
			this.label23.TabIndex = 8;
			this.label23.Text = "Spese già dedotte di altri contratti";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label57);
			this.groupBox1.Controls.Add(this.label49);
			this.groupBox1.Controls.Add(this.txtImpFiscaleContratto);
			this.groupBox1.Controls.Add(this.txtC2);
			this.groupBox1.Controls.Add(this.label56);
			this.groupBox1.Controls.Add(this.label50);
			this.groupBox1.Controls.Add(this.label37);
			this.groupBox1.Controls.Add(this.txtC1);
			this.groupBox1.Controls.Add(this.label48);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label42);
			this.groupBox1.Controls.Add(this.txtImpContratto);
			this.groupBox1.Controls.Add(this.txtD);
			this.groupBox1.Controls.Add(this.txtSpeseFiscali);
			this.groupBox1.Controls.Add(this.label30);
			this.groupBox1.Controls.Add(this.SubEntity_txtImpAltriEnti);
			this.groupBox1.Controls.Add(this.label41);
			this.groupBox1.Controls.Add(this.txtImpAltriContratti);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.label31);
			this.groupBox1.Controls.Add(this.label29);
			this.groupBox1.Controls.Add(this.label28);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 456);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Imponibile Fiscale Residuo";
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(251, 408);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(53, 20);
			this.label57.TabIndex = 17;
			this.label57.Text = "= E-C3";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(272, 161);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(24, 20);
			this.label49.TabIndex = 22;
			this.label49.Text = "C2";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtImpFiscaleContratto
			// 
			this.txtImpFiscaleContratto.Location = new System.Drawing.Point(141, 409);
			this.txtImpFiscaleContratto.Name = "txtImpFiscaleContratto";
			this.txtImpFiscaleContratto.ReadOnly = true;
			this.txtImpFiscaleContratto.Size = new System.Drawing.Size(88, 20);
			this.txtImpFiscaleContratto.TabIndex = 16;
			this.txtImpFiscaleContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtC2
			// 
			this.txtC2.Location = new System.Drawing.Point(152, 161);
			this.txtC2.Name = "txtC2";
			this.txtC2.ReadOnly = true;
			this.txtC2.Size = new System.Drawing.Size(88, 20);
			this.txtC2.TabIndex = 21;
			this.txtC2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(5, 400);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(130, 36);
			this.label56.TabIndex = 15;
			this.label56.Text = "Imponibile fiscale netto residuo";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(11, 152);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(130, 36);
			this.label50.TabIndex = 20;
			this.label50.Text = "Spese già dedotte di questo contratto";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(272, 112);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(24, 20);
			this.label37.TabIndex = 19;
			this.label37.Text = "C1";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtC1
			// 
			this.txtC1.Location = new System.Drawing.Point(152, 112);
			this.txtC1.Name = "txtC1";
			this.txtC1.ReadOnly = true;
			this.txtC1.Size = new System.Drawing.Size(88, 20);
			this.txtC1.TabIndex = 18;
			this.txtC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(6, 103);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(135, 36);
			this.label48.TabIndex = 17;
			this.label48.Text = "Spese già dedotte di altri contratti";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.SubEntity_cmbAliquotaFiscale);
			this.groupBox5.Controls.Add(this.SubEntity_rdoAliquotaMarginale);
			this.groupBox5.Controls.Add(this.SubEntity_rdoAliquotaCorrente);
			this.groupBox5.Location = new System.Drawing.Point(10, 253);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(312, 69);
			this.groupBox5.TabIndex = 16;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Applicazione Aliquota Fiscale";
			// 
			// SubEntity_cmbAliquotaFiscale
			// 
			this.SubEntity_cmbAliquotaFiscale.DataSource = this.DS.taxratebracket;
			this.SubEntity_cmbAliquotaFiscale.DisplayMember = "employrate";
			this.SubEntity_cmbAliquotaFiscale.Location = new System.Drawing.Point(134, 43);
			this.SubEntity_cmbAliquotaFiscale.Name = "SubEntity_cmbAliquotaFiscale";
			this.SubEntity_cmbAliquotaFiscale.Size = new System.Drawing.Size(160, 21);
			this.SubEntity_cmbAliquotaFiscale.TabIndex = 2;
			this.SubEntity_cmbAliquotaFiscale.Tag = "casualcontractyear.higherrate?casualcontractview.higherrate";
			this.SubEntity_cmbAliquotaFiscale.ValueMember = "employrate";
			// 
			// SubEntity_rdoAliquotaMarginale
			// 
			this.SubEntity_rdoAliquotaMarginale.Location = new System.Drawing.Point(6, 43);
			this.SubEntity_rdoAliquotaMarginale.Name = "SubEntity_rdoAliquotaMarginale";
			this.SubEntity_rdoAliquotaMarginale.Size = new System.Drawing.Size(120, 24);
			this.SubEntity_rdoAliquotaMarginale.TabIndex = 1;
			this.SubEntity_rdoAliquotaMarginale.Tag = "casualcontractyear.flaghigherrate:S?casualcontractview.flaghigherrate:S";
			this.SubEntity_rdoAliquotaMarginale.Text = "Aliquota Marginale";
			this.SubEntity_rdoAliquotaMarginale.CheckedChanged += new System.EventHandler(this.rdoAliquotaMarginale_CheckedChanged);
			// 
			// SubEntity_rdoAliquotaCorrente
			// 
			this.SubEntity_rdoAliquotaCorrente.Checked = true;
			this.SubEntity_rdoAliquotaCorrente.Location = new System.Drawing.Point(6, 19);
			this.SubEntity_rdoAliquotaCorrente.Name = "SubEntity_rdoAliquotaCorrente";
			this.SubEntity_rdoAliquotaCorrente.Size = new System.Drawing.Size(120, 24);
			this.SubEntity_rdoAliquotaCorrente.TabIndex = 0;
			this.SubEntity_rdoAliquotaCorrente.TabStop = true;
			this.SubEntity_rdoAliquotaCorrente.Tag = "casualcontractyear.flaghigherrate:N?casualcontractview.flaghigherrate:N";
			this.SubEntity_rdoAliquotaCorrente.Text = "Aliquota Corrente";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(7, 325);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(129, 39);
			this.label10.TabIndex = 4;
			this.label10.Text = "Imponibile residuo per l\'anno di questo Contratto";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(269, 373);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(24, 20);
			this.label42.TabIndex = 15;
			this.label42.Text = "C3";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtImpContratto
			// 
			this.txtImpContratto.Location = new System.Drawing.Point(144, 337);
			this.txtImpContratto.Name = "txtImpContratto";
			this.txtImpContratto.ReadOnly = true;
			this.txtImpContratto.Size = new System.Drawing.Size(88, 20);
			this.txtImpContratto.TabIndex = 5;
			this.txtImpContratto.TabStop = false;
			this.txtImpContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtD
			// 
			this.txtD.Location = new System.Drawing.Point(152, 205);
			this.txtD.Name = "txtD";
			this.txtD.ReadOnly = true;
			this.txtD.Size = new System.Drawing.Size(88, 20);
			this.txtD.TabIndex = 7;
			this.txtD.TabStop = false;
			this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSpeseFiscali
			// 
			this.txtSpeseFiscali.Location = new System.Drawing.Point(144, 373);
			this.txtSpeseFiscali.Name = "txtSpeseFiscali";
			this.txtSpeseFiscali.ReadOnly = true;
			this.txtSpeseFiscali.Size = new System.Drawing.Size(88, 20);
			this.txtSpeseFiscali.TabIndex = 14;
			this.txtSpeseFiscali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(269, 337);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(24, 20);
			this.label30.TabIndex = 10;
			this.label30.Text = "E";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SubEntity_txtImpAltriEnti
			// 
			this.SubEntity_txtImpAltriEnti.Location = new System.Drawing.Point(152, 32);
			this.SubEntity_txtImpAltriEnti.Name = "SubEntity_txtImpAltriEnti";
			this.SubEntity_txtImpAltriEnti.Size = new System.Drawing.Size(88, 20);
			this.SubEntity_txtImpAltriEnti.TabIndex = 1;
			this.SubEntity_txtImpAltriEnti.Tag = "casualcontractyear.taxableotheragency?casualcontractview.taxableotheragency";
			this.SubEntity_txtImpAltriEnti.Leave += new System.EventHandler(this.txtImpAltriEnti_Leave);
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(8, 364);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(130, 36);
			this.label41.TabIndex = 13;
			this.label41.Text = "Spese ancora da dedurre di questo contratto";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpAltriContratti
			// 
			this.txtImpAltriContratti.Location = new System.Drawing.Point(152, 72);
			this.txtImpAltriContratti.Name = "txtImpAltriContratti";
			this.txtImpAltriContratti.ReadOnly = true;
			this.txtImpAltriContratti.Size = new System.Drawing.Size(88, 20);
			this.txtImpAltriContratti.TabIndex = 3;
			this.txtImpAltriContratti.Tag = "";
			this.txtImpAltriContratti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtImpAltriContratti.Leave += new System.EventHandler(this.txtImpAltriContratti_Leave);
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(254, 188);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(72, 2);
			this.panel2.TabIndex = 12;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(246, 197);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(80, 35);
			this.label31.TabIndex = 11;
			this.label31.Text = "D = A + B1  - (C1+C2)";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(272, 72);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(24, 20);
			this.label29.TabIndex = 9;
			this.label29.Text = "B1";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(272, 32);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(24, 20);
			this.label28.TabIndex = 8;
			this.label28.Text = "A";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(11, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 44);
			this.label7.TabIndex = 0;
			this.label7.Text = "Tot. Pagato da  Altri Committenti  al netto delle spese";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label9.Location = new System.Drawing.Point(6, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(140, 36);
			this.label9.TabIndex = 2;
			this.label9.Text = "già pagato nello stesso Dipartimento (Ateneo)";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(5, 188);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(141, 52);
			this.label11.TabIndex = 6;
			this.label11.Text = "Imponibile fiscale netto già pagato ";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.txtImpPrevidenzialeResiduo);
			this.tabRitenute.Controls.Add(this.label75);
			this.tabRitenute.Controls.Add(this.textQuotaesenteDaApplicare);
			this.tabRitenute.Controls.Add(this.label73);
			this.tabRitenute.Controls.Add(this.txtSpesePrevResidue);
			this.tabRitenute.Controls.Add(this.label74);
			this.tabRitenute.Controls.Add(this.txtImpFiscaleNettoResiduo);
			this.tabRitenute.Controls.Add(this.label72);
			this.tabRitenute.Controls.Add(this.txtSpeseFiscaliResidue);
			this.tabRitenute.Controls.Add(this.label39);
			this.tabRitenute.Controls.Add(this.txtImpResiduo);
			this.tabRitenute.Controls.Add(this.label38);
			this.tabRitenute.Controls.Add(this.groupBox4);
			this.tabRitenute.Controls.Add(this.groupBox3);
			this.tabRitenute.Location = new System.Drawing.Point(4, 23);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(879, 502);
			this.tabRitenute.TabIndex = 2;
			this.tabRitenute.Text = "Residuo da pagare";
			this.tabRitenute.UseVisualStyleBackColor = true;
			// 
			// txtImpPrevidenzialeResiduo
			// 
			this.txtImpPrevidenzialeResiduo.Location = new System.Drawing.Point(455, 65);
			this.txtImpPrevidenzialeResiduo.Name = "txtImpPrevidenzialeResiduo";
			this.txtImpPrevidenzialeResiduo.ReadOnly = true;
			this.txtImpPrevidenzialeResiduo.Size = new System.Drawing.Size(100, 20);
			this.txtImpPrevidenzialeResiduo.TabIndex = 15;
			this.txtImpPrevidenzialeResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(452, 49);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(119, 13);
			this.label75.TabIndex = 14;
			this.label75.Text = "Imponibile previdenziale";
			// 
			// textQuotaesenteDaApplicare
			// 
			this.textQuotaesenteDaApplicare.Location = new System.Drawing.Point(317, 65);
			this.textQuotaesenteDaApplicare.Name = "textQuotaesenteDaApplicare";
			this.textQuotaesenteDaApplicare.ReadOnly = true;
			this.textQuotaesenteDaApplicare.Size = new System.Drawing.Size(100, 20);
			this.textQuotaesenteDaApplicare.TabIndex = 13;
			this.textQuotaesenteDaApplicare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Location = new System.Drawing.Point(314, 49);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(132, 13);
			this.label73.TabIndex = 12;
			this.label73.Text = "Quota esente da applicare";
			// 
			// txtSpesePrevResidue
			// 
			this.txtSpesePrevResidue.Location = new System.Drawing.Point(131, 65);
			this.txtSpesePrevResidue.Name = "txtSpesePrevResidue";
			this.txtSpesePrevResidue.ReadOnly = true;
			this.txtSpesePrevResidue.Size = new System.Drawing.Size(100, 20);
			this.txtSpesePrevResidue.TabIndex = 11;
			this.txtSpesePrevResidue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(128, 49);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(172, 13);
			this.label74.TabIndex = 10;
			this.label74.Text = "Spese deducibili previdenzialmente";
			// 
			// txtImpFiscaleNettoResiduo
			// 
			this.txtImpFiscaleNettoResiduo.Location = new System.Drawing.Point(317, 26);
			this.txtImpFiscaleNettoResiduo.Name = "txtImpFiscaleNettoResiduo";
			this.txtImpFiscaleNettoResiduo.ReadOnly = true;
			this.txtImpFiscaleNettoResiduo.Size = new System.Drawing.Size(100, 20);
			this.txtImpFiscaleNettoResiduo.TabIndex = 9;
			this.txtImpFiscaleNettoResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(314, 10);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(90, 13);
			this.label72.TabIndex = 8;
			this.label72.Text = "Imponibile fiscale ";
			// 
			// txtSpeseFiscaliResidue
			// 
			this.txtSpeseFiscaliResidue.Location = new System.Drawing.Point(131, 26);
			this.txtSpeseFiscaliResidue.Name = "txtSpeseFiscaliResidue";
			this.txtSpeseFiscaliResidue.ReadOnly = true;
			this.txtSpeseFiscaliResidue.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseFiscaliResidue.TabIndex = 7;
			this.txtSpeseFiscaliResidue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(128, 10);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(140, 13);
			this.label39.TabIndex = 6;
			this.label39.Text = "Spese deducibili fiscalmente";
			// 
			// txtImpResiduo
			// 
			this.txtImpResiduo.Location = new System.Drawing.Point(16, 26);
			this.txtImpResiduo.Name = "txtImpResiduo";
			this.txtImpResiduo.ReadOnly = true;
			this.txtImpResiduo.Size = new System.Drawing.Size(100, 20);
			this.txtImpResiduo.TabIndex = 5;
			this.txtImpResiduo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label38
			// 
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(13, 10);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(45, 13);
			this.label38.TabIndex = 4;
			this.label38.Text = "Importo ";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.txtCostoTotale);
			this.groupBox4.Controls.Add(this.label21);
			this.groupBox4.Controls.Add(this.txtRitAssicurativaAmm);
			this.groupBox4.Controls.Add(this.txtRitAssistenzialeAmm);
			this.groupBox4.Controls.Add(this.txtRitPrevidenzialeAmm);
			this.groupBox4.Controls.Add(this.txtRitFiscaleAmm);
			this.groupBox4.Controls.Add(this.label16);
			this.groupBox4.Controls.Add(this.label17);
			this.groupBox4.Controls.Add(this.label18);
			this.groupBox4.Controls.Add(this.label19);
			this.groupBox4.Location = new System.Drawing.Point(8, 153);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(863, 56);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Ritenute c/Amministrazione";
			// 
			// txtCostoTotale
			// 
			this.txtCostoTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostoTotale.Location = new System.Drawing.Point(520, 32);
			this.txtCostoTotale.Name = "txtCostoTotale";
			this.txtCostoTotale.ReadOnly = true;
			this.txtCostoTotale.Size = new System.Drawing.Size(100, 20);
			this.txtCostoTotale.TabIndex = 17;
			this.txtCostoTotale.TabStop = false;
			this.txtCostoTotale.Tag = "";
			this.txtCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(528, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(88, 16);
			this.label21.TabIndex = 16;
			this.label21.Text = "Costo Totale:";
			// 
			// txtRitAssicurativaAmm
			// 
			this.txtRitAssicurativaAmm.Location = new System.Drawing.Point(320, 32);
			this.txtRitAssicurativaAmm.Name = "txtRitAssicurativaAmm";
			this.txtRitAssicurativaAmm.ReadOnly = true;
			this.txtRitAssicurativaAmm.Size = new System.Drawing.Size(100, 20);
			this.txtRitAssicurativaAmm.TabIndex = 15;
			this.txtRitAssicurativaAmm.TabStop = false;
			this.txtRitAssicurativaAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitAssistenzialeAmm
			// 
			this.txtRitAssistenzialeAmm.Location = new System.Drawing.Point(216, 32);
			this.txtRitAssistenzialeAmm.Name = "txtRitAssistenzialeAmm";
			this.txtRitAssistenzialeAmm.ReadOnly = true;
			this.txtRitAssistenzialeAmm.Size = new System.Drawing.Size(100, 20);
			this.txtRitAssistenzialeAmm.TabIndex = 14;
			this.txtRitAssistenzialeAmm.TabStop = false;
			this.txtRitAssistenzialeAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitPrevidenzialeAmm
			// 
			this.txtRitPrevidenzialeAmm.Location = new System.Drawing.Point(112, 32);
			this.txtRitPrevidenzialeAmm.Name = "txtRitPrevidenzialeAmm";
			this.txtRitPrevidenzialeAmm.ReadOnly = true;
			this.txtRitPrevidenzialeAmm.Size = new System.Drawing.Size(100, 20);
			this.txtRitPrevidenzialeAmm.TabIndex = 13;
			this.txtRitPrevidenzialeAmm.TabStop = false;
			this.txtRitPrevidenzialeAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitFiscaleAmm
			// 
			this.txtRitFiscaleAmm.Location = new System.Drawing.Point(8, 32);
			this.txtRitFiscaleAmm.Name = "txtRitFiscaleAmm";
			this.txtRitFiscaleAmm.ReadOnly = true;
			this.txtRitFiscaleAmm.Size = new System.Drawing.Size(100, 20);
			this.txtRitFiscaleAmm.TabIndex = 12;
			this.txtRitFiscaleAmm.TabStop = false;
			this.txtRitFiscaleAmm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(224, 16);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(88, 16);
			this.label16.TabIndex = 11;
			this.label16.Text = "Assistenziali:";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(328, 16);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 16);
			this.label17.TabIndex = 10;
			this.label17.Text = "Assicurative:";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(120, 16);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(96, 16);
			this.label18.TabIndex = 9;
			this.label18.Text = "Previdenziali:";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 16);
			this.label19.TabIndex = 8;
			this.label19.Text = "Fiscali:";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.txtImportoNetto);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.txtRitAssistenzialeDip);
			this.groupBox3.Controls.Add(this.txtRitAssicurativaDip);
			this.groupBox3.Controls.Add(this.txtRitPrevidenzialeDip);
			this.groupBox3.Controls.Add(this.txtRitFiscaleDip);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Location = new System.Drawing.Point(8, 91);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(863, 56);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ritenute c/dipendente ";
			// 
			// txtImportoNetto
			// 
			this.txtImportoNetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImportoNetto.Location = new System.Drawing.Point(520, 32);
			this.txtImportoNetto.Name = "txtImportoNetto";
			this.txtImportoNetto.ReadOnly = true;
			this.txtImportoNetto.Size = new System.Drawing.Size(100, 20);
			this.txtImportoNetto.TabIndex = 9;
			this.txtImportoNetto.TabStop = false;
			this.txtImportoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(520, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 16);
			this.label20.TabIndex = 8;
			this.label20.Text = "Importo Netto:";
			// 
			// txtRitAssistenzialeDip
			// 
			this.txtRitAssistenzialeDip.Location = new System.Drawing.Point(216, 32);
			this.txtRitAssistenzialeDip.Name = "txtRitAssistenzialeDip";
			this.txtRitAssistenzialeDip.ReadOnly = true;
			this.txtRitAssistenzialeDip.Size = new System.Drawing.Size(100, 20);
			this.txtRitAssistenzialeDip.TabIndex = 7;
			this.txtRitAssistenzialeDip.TabStop = false;
			this.txtRitAssistenzialeDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitAssicurativaDip
			// 
			this.txtRitAssicurativaDip.Location = new System.Drawing.Point(320, 32);
			this.txtRitAssicurativaDip.Name = "txtRitAssicurativaDip";
			this.txtRitAssicurativaDip.ReadOnly = true;
			this.txtRitAssicurativaDip.Size = new System.Drawing.Size(100, 20);
			this.txtRitAssicurativaDip.TabIndex = 6;
			this.txtRitAssicurativaDip.TabStop = false;
			this.txtRitAssicurativaDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitPrevidenzialeDip
			// 
			this.txtRitPrevidenzialeDip.Location = new System.Drawing.Point(112, 32);
			this.txtRitPrevidenzialeDip.Name = "txtRitPrevidenzialeDip";
			this.txtRitPrevidenzialeDip.ReadOnly = true;
			this.txtRitPrevidenzialeDip.Size = new System.Drawing.Size(100, 20);
			this.txtRitPrevidenzialeDip.TabIndex = 5;
			this.txtRitPrevidenzialeDip.TabStop = false;
			this.txtRitPrevidenzialeDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRitFiscaleDip
			// 
			this.txtRitFiscaleDip.Location = new System.Drawing.Point(8, 32);
			this.txtRitFiscaleDip.Name = "txtRitFiscaleDip";
			this.txtRitFiscaleDip.ReadOnly = true;
			this.txtRitFiscaleDip.Size = new System.Drawing.Size(100, 20);
			this.txtRitFiscaleDip.TabIndex = 4;
			this.txtRitFiscaleDip.TabStop = false;
			this.txtRitFiscaleDip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(216, 16);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(96, 16);
			this.label15.TabIndex = 3;
			this.label15.Text = "Assistenziali:";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(328, 16);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 16);
			this.label14.TabIndex = 2;
			this.label14.Text = "Assicurative:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(120, 16);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(96, 16);
			this.label13.TabIndex = 1;
			this.label13.Text = "Previdenziali:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(8, 16);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 0;
			this.label12.Text = "Fiscali:";
			// 
			// tabStorico
			// 
			this.tabStorico.Controls.Add(this.txtQuotaEsenteAnno);
			this.tabStorico.Controls.Add(this.label63);
			this.tabStorico.Controls.Add(this.txtSpesePrevAnno);
			this.tabStorico.Controls.Add(this.label64);
			this.tabStorico.Controls.Add(this.txtSpeseFisAnno);
			this.tabStorico.Controls.Add(this.label66);
			this.tabStorico.Controls.Add(this.txtImportoAnno);
			this.tabStorico.Controls.Add(this.label67);
			this.tabStorico.Controls.Add(this.groupBox12);
			this.tabStorico.Controls.Add(this.groupBox13);
			this.tabStorico.Location = new System.Drawing.Point(4, 23);
			this.tabStorico.Name = "tabStorico";
			this.tabStorico.Size = new System.Drawing.Size(879, 502);
			this.tabStorico.TabIndex = 7;
			this.tabStorico.Text = "Ritenute applicate nell\'anno";
			this.tabStorico.UseVisualStyleBackColor = true;
			// 
			// txtQuotaEsenteAnno
			// 
			this.txtQuotaEsenteAnno.Location = new System.Drawing.Point(315, 66);
			this.txtQuotaEsenteAnno.Name = "txtQuotaEsenteAnno";
			this.txtQuotaEsenteAnno.ReadOnly = true;
			this.txtQuotaEsenteAnno.Size = new System.Drawing.Size(100, 20);
			this.txtQuotaEsenteAnno.TabIndex = 27;
			this.txtQuotaEsenteAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(312, 50);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(208, 13);
			this.label63.TabIndex = 26;
			this.label63.Text = "Quota esente applicata in questo contratto";
			// 
			// txtSpesePrevAnno
			// 
			this.txtSpesePrevAnno.Location = new System.Drawing.Point(129, 66);
			this.txtSpesePrevAnno.Name = "txtSpesePrevAnno";
			this.txtSpesePrevAnno.ReadOnly = true;
			this.txtSpesePrevAnno.Size = new System.Drawing.Size(100, 20);
			this.txtSpesePrevAnno.TabIndex = 25;
			this.txtSpesePrevAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(126, 50);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(172, 13);
			this.label64.TabIndex = 24;
			this.label64.Text = "Spese deducibili previdenzialmente";
			// 
			// txtSpeseFisAnno
			// 
			this.txtSpeseFisAnno.Location = new System.Drawing.Point(129, 27);
			this.txtSpeseFisAnno.Name = "txtSpeseFisAnno";
			this.txtSpeseFisAnno.ReadOnly = true;
			this.txtSpeseFisAnno.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseFisAnno.TabIndex = 21;
			this.txtSpeseFisAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(126, 11);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(140, 13);
			this.label66.TabIndex = 20;
			this.label66.Text = "Spese deducibili fiscalmente";
			// 
			// txtImportoAnno
			// 
			this.txtImportoAnno.Location = new System.Drawing.Point(14, 27);
			this.txtImportoAnno.Name = "txtImportoAnno";
			this.txtImportoAnno.ReadOnly = true;
			this.txtImportoAnno.Size = new System.Drawing.Size(100, 20);
			this.txtImportoAnno.TabIndex = 19;
			this.txtImportoAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(11, 11);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(45, 13);
			this.label67.TabIndex = 18;
			this.label67.Text = "Importo ";
			// 
			// groupBox12
			// 
			this.groupBox12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox12.Controls.Add(this.txtCostoAnno);
			this.groupBox12.Controls.Add(this.label68);
			this.groupBox12.Controls.Add(this.txtContrAssicurAnno);
			this.groupBox12.Controls.Add(this.txtContrAssistAnno);
			this.groupBox12.Controls.Add(this.txtContrPrevAnno);
			this.groupBox12.Controls.Add(this.txtContrFisAnno);
			this.groupBox12.Controls.Add(this.label69);
			this.groupBox12.Controls.Add(this.label70);
			this.groupBox12.Controls.Add(this.label71);
			this.groupBox12.Controls.Add(this.label76);
			this.groupBox12.Location = new System.Drawing.Point(6, 154);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(863, 56);
			this.groupBox12.TabIndex = 17;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Ritenute c/Amministrazione";
			// 
			// txtCostoAnno
			// 
			this.txtCostoAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostoAnno.Location = new System.Drawing.Point(520, 32);
			this.txtCostoAnno.Name = "txtCostoAnno";
			this.txtCostoAnno.ReadOnly = true;
			this.txtCostoAnno.Size = new System.Drawing.Size(100, 20);
			this.txtCostoAnno.TabIndex = 17;
			this.txtCostoAnno.TabStop = false;
			this.txtCostoAnno.Tag = "";
			this.txtCostoAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label68
			// 
			this.label68.Location = new System.Drawing.Point(528, 16);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(88, 16);
			this.label68.TabIndex = 16;
			this.label68.Text = "Costo Totale:";
			// 
			// txtContrAssicurAnno
			// 
			this.txtContrAssicurAnno.Location = new System.Drawing.Point(320, 32);
			this.txtContrAssicurAnno.Name = "txtContrAssicurAnno";
			this.txtContrAssicurAnno.ReadOnly = true;
			this.txtContrAssicurAnno.Size = new System.Drawing.Size(100, 20);
			this.txtContrAssicurAnno.TabIndex = 15;
			this.txtContrAssicurAnno.TabStop = false;
			this.txtContrAssicurAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContrAssistAnno
			// 
			this.txtContrAssistAnno.Location = new System.Drawing.Point(216, 32);
			this.txtContrAssistAnno.Name = "txtContrAssistAnno";
			this.txtContrAssistAnno.ReadOnly = true;
			this.txtContrAssistAnno.Size = new System.Drawing.Size(100, 20);
			this.txtContrAssistAnno.TabIndex = 14;
			this.txtContrAssistAnno.TabStop = false;
			this.txtContrAssistAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContrPrevAnno
			// 
			this.txtContrPrevAnno.Location = new System.Drawing.Point(112, 32);
			this.txtContrPrevAnno.Name = "txtContrPrevAnno";
			this.txtContrPrevAnno.ReadOnly = true;
			this.txtContrPrevAnno.Size = new System.Drawing.Size(100, 20);
			this.txtContrPrevAnno.TabIndex = 13;
			this.txtContrPrevAnno.TabStop = false;
			this.txtContrPrevAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContrFisAnno
			// 
			this.txtContrFisAnno.Location = new System.Drawing.Point(8, 32);
			this.txtContrFisAnno.Name = "txtContrFisAnno";
			this.txtContrFisAnno.ReadOnly = true;
			this.txtContrFisAnno.Size = new System.Drawing.Size(100, 20);
			this.txtContrFisAnno.TabIndex = 12;
			this.txtContrFisAnno.TabStop = false;
			this.txtContrFisAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label69
			// 
			this.label69.Location = new System.Drawing.Point(224, 16);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(88, 16);
			this.label69.TabIndex = 11;
			this.label69.Text = "Assistenziali:";
			// 
			// label70
			// 
			this.label70.Location = new System.Drawing.Point(328, 16);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(88, 16);
			this.label70.TabIndex = 10;
			this.label70.Text = "Assicurative:";
			// 
			// label71
			// 
			this.label71.Location = new System.Drawing.Point(120, 16);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(96, 16);
			this.label71.TabIndex = 9;
			this.label71.Text = "Previdenziali:";
			// 
			// label76
			// 
			this.label76.Location = new System.Drawing.Point(8, 16);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(100, 16);
			this.label76.TabIndex = 8;
			this.label76.Text = "Fiscali:";
			// 
			// groupBox13
			// 
			this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox13.Controls.Add(this.txtNettoAnno);
			this.groupBox13.Controls.Add(this.label77);
			this.groupBox13.Controls.Add(this.txtAssistAnno);
			this.groupBox13.Controls.Add(this.txtAssicurAnno);
			this.groupBox13.Controls.Add(this.txtPrevAnno);
			this.groupBox13.Controls.Add(this.txtFisAnno);
			this.groupBox13.Controls.Add(this.label78);
			this.groupBox13.Controls.Add(this.label79);
			this.groupBox13.Controls.Add(this.label80);
			this.groupBox13.Controls.Add(this.label81);
			this.groupBox13.Location = new System.Drawing.Point(6, 92);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(863, 56);
			this.groupBox13.TabIndex = 16;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Ritenute c/dipendente ";
			// 
			// txtNettoAnno
			// 
			this.txtNettoAnno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNettoAnno.Location = new System.Drawing.Point(520, 32);
			this.txtNettoAnno.Name = "txtNettoAnno";
			this.txtNettoAnno.ReadOnly = true;
			this.txtNettoAnno.Size = new System.Drawing.Size(100, 20);
			this.txtNettoAnno.TabIndex = 9;
			this.txtNettoAnno.TabStop = false;
			this.txtNettoAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label77
			// 
			this.label77.Location = new System.Drawing.Point(520, 16);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(100, 16);
			this.label77.TabIndex = 8;
			this.label77.Text = "Importo Netto:";
			// 
			// txtAssistAnno
			// 
			this.txtAssistAnno.Location = new System.Drawing.Point(216, 32);
			this.txtAssistAnno.Name = "txtAssistAnno";
			this.txtAssistAnno.ReadOnly = true;
			this.txtAssistAnno.Size = new System.Drawing.Size(100, 20);
			this.txtAssistAnno.TabIndex = 7;
			this.txtAssistAnno.TabStop = false;
			this.txtAssistAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAssicurAnno
			// 
			this.txtAssicurAnno.Location = new System.Drawing.Point(320, 32);
			this.txtAssicurAnno.Name = "txtAssicurAnno";
			this.txtAssicurAnno.ReadOnly = true;
			this.txtAssicurAnno.Size = new System.Drawing.Size(100, 20);
			this.txtAssicurAnno.TabIndex = 6;
			this.txtAssicurAnno.TabStop = false;
			this.txtAssicurAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPrevAnno
			// 
			this.txtPrevAnno.Location = new System.Drawing.Point(112, 32);
			this.txtPrevAnno.Name = "txtPrevAnno";
			this.txtPrevAnno.ReadOnly = true;
			this.txtPrevAnno.Size = new System.Drawing.Size(100, 20);
			this.txtPrevAnno.TabIndex = 5;
			this.txtPrevAnno.TabStop = false;
			this.txtPrevAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFisAnno
			// 
			this.txtFisAnno.Location = new System.Drawing.Point(8, 32);
			this.txtFisAnno.Name = "txtFisAnno";
			this.txtFisAnno.ReadOnly = true;
			this.txtFisAnno.Size = new System.Drawing.Size(100, 20);
			this.txtFisAnno.TabIndex = 4;
			this.txtFisAnno.TabStop = false;
			this.txtFisAnno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label78
			// 
			this.label78.Location = new System.Drawing.Point(216, 16);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(96, 16);
			this.label78.TabIndex = 3;
			this.label78.Text = "Assistenziali:";
			// 
			// label79
			// 
			this.label79.Location = new System.Drawing.Point(328, 16);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(88, 16);
			this.label79.TabIndex = 2;
			this.label79.Text = "Assicurative:";
			// 
			// label80
			// 
			this.label80.Location = new System.Drawing.Point(120, 16);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(96, 16);
			this.label80.TabIndex = 1;
			this.label80.Text = "Previdenziali:";
			// 
			// label81
			// 
			this.label81.Location = new System.Drawing.Point(8, 16);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(100, 16);
			this.label81.TabIndex = 0;
			this.label81.Text = "Fiscali:";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.chkEP);
			this.tabEP.Controls.Add(this.btnGeneraPreImpegni);
			this.tabEP.Controls.Add(this.btnViewPreimpegni);
			this.tabEP.Controls.Add(this.btnGeneraEpExp);
			this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Controls.Add(this.tabControl2);
			this.tabEP.Location = new System.Drawing.Point(4, 23);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(879, 502);
			this.tabEP.TabIndex = 5;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// chkEP
			// 
			this.chkEP.AutoSize = true;
			this.chkEP.Location = new System.Drawing.Point(667, 115);
			this.chkEP.Name = "chkEP";
			this.chkEP.Size = new System.Drawing.Size(156, 17);
			this.chkEP.TabIndex = 18;
			this.chkEP.Text = "Abilita elenco per analisi EP";
			this.chkEP.UseVisualStyleBackColor = true;
			this.chkEP.CheckedChanged += new System.EventHandler(this.chkEP_CheckedChanged);
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(107, 79);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
			this.btnGeneraPreImpegni.TabIndex = 17;
			this.btnGeneraPreImpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(107, 111);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
			this.btnViewPreimpegni.TabIndex = 16;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(416, 79);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 15;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(416, 111);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 14;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(416, 40);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 13;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(416, 8);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 12;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(24, 16);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(352, 16);
			this.labEP.TabIndex = 10;
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
			this.tabControl2.Location = new System.Drawing.Point(8, 144);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(863, 353);
			this.tabControl2.TabIndex = 9;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(855, 327);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziario";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.btnUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Location = new System.Drawing.Point(3, 12);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(316, 124);
			this.gboxUPB.TabIndex = 2;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(4, 100);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(304, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// btnUPB
			// 
			this.btnUPB.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPB.Location = new System.Drawing.Point(6, 71);
			this.btnUPB.Name = "btnUPB";
			this.btnUPB.Size = new System.Drawing.Size(112, 20);
			this.btnUPB.TabIndex = 5;
			this.btnUPB.TabStop = false;
			this.btnUPB.Tag = "manage.upb.tree";
			this.btnUPB.Text = "UPB:";
			this.btnUPB.UseVisualStyleBackColor = false;
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(126, 8);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(182, 83);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// tabAnalitico
			// 
			this.tabAnalitico.Controls.Add(this.grpRipartizioneCosti);
			this.tabAnalitico.Controls.Add(this.btnRipartizione);
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(855, 327);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			this.tabAnalitico.Visible = false;
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.btnCodRipartizione);
			this.grpRipartizioneCosti.Controls.Add(this.textBox7);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(431, 115);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(409, 85);
			this.grpRipartizioneCosti.TabIndex = 52;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// btnCodRipartizione
			// 
			this.btnCodRipartizione.Location = new System.Drawing.Point(8, 30);
			this.btnCodRipartizione.Name = "btnCodRipartizione";
			this.btnCodRipartizione.Size = new System.Drawing.Size(88, 23);
			this.btnCodRipartizione.TabIndex = 4;
			this.btnCodRipartizione.Tag = "choose.costpartition.default.(active=\'S\')";
			this.btnCodRipartizione.Text = "Codice";
			this.btnCodRipartizione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(150, 8);
			this.textBox7.Multiline = true;
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(251, 45);
			this.textBox7.TabIndex = 3;
			this.textBox7.TabStop = false;
			this.textBox7.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 59);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(393, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// btnRipartizione
			// 
			this.btnRipartizione.Location = new System.Drawing.Point(439, 217);
			this.btnRipartizione.Name = "btnRipartizione";
			this.btnRipartizione.Size = new System.Drawing.Size(88, 23);
			this.btnRipartizione.TabIndex = 51;
			this.btnRipartizione.Text = "Ripartizione";
			this.btnRipartizione.Click += new System.EventHandler(this.btnRipartizione_Click);
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(15, 115);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(409, 85);
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
			this.txtDenom3.Size = new System.Drawing.Size(251, 45);
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
			this.txtCodice3.Size = new System.Drawing.Size(393, 20);
			this.txtCodice3.TabIndex = 4;
			this.txtCodice3.Tag = "sorting3.sortcode?x";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(431, 3);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(409, 89);
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
			this.txtDenom2.Size = new System.Drawing.Size(251, 52);
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
			this.txtCodice2.Size = new System.Drawing.Size(393, 20);
			this.txtCodice2.TabIndex = 2;
			this.txtCodice2.Tag = "sorting2.sortcode?x";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(15, 3);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(409, 89);
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
			this.txtDenom1.Location = new System.Drawing.Point(161, 8);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(240, 52);
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
			this.txtCodice1.Size = new System.Drawing.Size(393, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpBoxSiopeEP);
			this.tabPage2.Controls.Add(this.label43);
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebitoCrg);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebito);
			this.tabPage2.Controls.Add(this.gBoxCausale);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(855, 327);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "E/P";
			this.tabPage2.Visible = false;
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(342, 8);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(328, 92);
			this.grpBoxSiopeEP.TabIndex = 51;
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
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(364, 116);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(174, 16);
			this.label43.TabIndex = 12;
			this.label43.Text = "Data correzione causale di debito";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(544, 113);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(126, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "casualcontract.idaccmotivedebit_datacrg";
			// 
			// gBoxCausaleDebitoCrg
			// 
			this.gBoxCausaleDebitoCrg.Controls.Add(this.textBox4);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.txtCodiceCausaleCrg);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.button7);
			this.gBoxCausaleDebitoCrg.Location = new System.Drawing.Point(342, 142);
			this.gBoxCausaleDebitoCrg.Name = "gBoxCausaleDebitoCrg";
			this.gBoxCausaleDebitoCrg.Size = new System.Drawing.Size(328, 127);
			this.gBoxCausaleDebitoCrg.TabIndex = 3;
			this.gBoxCausaleDebitoCrg.TabStop = false;
			this.gBoxCausaleDebitoCrg.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
			this.gBoxCausaleDebitoCrg.Text = "Causale di debito aggiornata";
			this.gBoxCausaleDebitoCrg.UseCompatibleTextRendering = true;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(120, 16);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(200, 79);
			this.textBox4.TabIndex = 2;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(8, 101);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?casualcontractview.codemotivedebit_crg";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(10, 72);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 23);
			this.button7.TabIndex = 0;
			this.button7.Tag = "manage.accmotiveapplied_crg.tree";
			this.button7.Text = "Causale";
			// 
			// gBoxCausaleDebito
			// 
			this.gBoxCausaleDebito.Controls.Add(this.textBox1);
			this.gBoxCausaleDebito.Controls.Add(this.txtCodiceCausaleDeb);
			this.gBoxCausaleDebito.Controls.Add(this.button6);
			this.gBoxCausaleDebito.Location = new System.Drawing.Point(8, 142);
			this.gBoxCausaleDebito.Name = "gBoxCausaleDebito";
			this.gBoxCausaleDebito.Size = new System.Drawing.Size(328, 127);
			this.gBoxCausaleDebito.TabIndex = 1;
			this.gBoxCausaleDebito.TabStop = false;
			this.gBoxCausaleDebito.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gBoxCausaleDebito.Text = "Causale di debito";
			this.gBoxCausaleDebito.UseCompatibleTextRendering = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(200, 79);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(8, 101);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?casualcontractview.codemotivedebit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(10, 72);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 0;
			this.button6.Tag = "manage.accmotiveapplied_debit.tree";
			this.button6.Text = "Causale";
			// 
			// gBoxCausale
			// 
			this.gBoxCausale.Controls.Add(this.textBox5);
			this.gBoxCausale.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausale.Controls.Add(this.button5);
			this.gBoxCausale.Location = new System.Drawing.Point(8, 8);
			this.gBoxCausale.Name = "gBoxCausale";
			this.gBoxCausale.Size = new System.Drawing.Size(328, 128);
			this.gBoxCausale.TabIndex = 0;
			this.gBoxCausale.TabStop = false;
			this.gBoxCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use = \'S\')";
			this.gBoxCausale.Text = "Causale di costo";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(120, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(200, 80);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied_cost.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(7, 102);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(313, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied_cost.codemotive?casualcontractview.codemotive";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(7, 73);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 0;
			this.button5.Tag = "manage.accmotiveapplied_cost.tree";
			this.button5.Text = "Causale";
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
			this.tabClassSuppl.Size = new System.Drawing.Size(879, 502);
			this.tabClassSuppl.TabIndex = 4;
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
			this.dgrClassSuppl.Location = new System.Drawing.Point(16, 56);
			this.dgrClassSuppl.Name = "dgrClassSuppl";
			this.dgrClassSuppl.ReadOnly = true;
			this.dgrClassSuppl.Size = new System.Drawing.Size(855, 432);
			this.dgrClassSuppl.TabIndex = 15;
			this.dgrClassSuppl.Tag = "casualcontractsorting.default.default";
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(176, 24);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(68, 22);
			this.btnClassElimina.TabIndex = 14;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(96, 24);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(69, 22);
			this.btnClassModifica.TabIndex = 13;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica...";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(16, 24);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnClassInserisci.TabIndex = 12;
			this.btnClassInserisci.Tag = "insert.default";
			this.btnClassInserisci.Text = "Inserisci...";
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
			this.tabAttributi.Size = new System.Drawing.Size(879, 502);
			this.tabAttributi.TabIndex = 8;
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
			this.gboxclass05.Size = new System.Drawing.Size(607, 64);
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
			this.txtDenom05.Size = new System.Drawing.Size(365, 52);
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
			this.gboxclass04.Size = new System.Drawing.Size(607, 64);
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
			this.txtDenom04.Size = new System.Drawing.Size(365, 46);
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
			this.gboxclass03.Size = new System.Drawing.Size(607, 64);
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
			this.txtDenom03.Size = new System.Drawing.Size(366, 52);
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
			this.gboxclass02.Size = new System.Drawing.Size(607, 64);
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
			this.txtDenom02.Size = new System.Drawing.Size(366, 52);
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
			this.gboxclass01.Size = new System.Drawing.Size(607, 64);
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
			this.txtDenom01.Size = new System.Drawing.Size(366, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabAnaPrest
			// 
			this.tabAnaPrest.Controls.Add(this.btnCollegaAP);
			this.tabAnaPrest.Controls.Add(this.grpBoxDocAutorizzattivo);
			this.tabAnaPrest.Controls.Add(this.grpBoxMotivo);
			this.tabAnaPrest.Controls.Add(this.grpBoxAutorizzazioneAP);
			this.tabAnaPrest.Controls.Add(this.btnGeneraAP);
			this.tabAnaPrest.Controls.Add(this.btnVisualizzaAP);
			this.tabAnaPrest.Controls.Add(this.labAPnongenerato);
			this.tabAnaPrest.Controls.Add(this.labAPgenerato);
			this.tabAnaPrest.Location = new System.Drawing.Point(4, 23);
			this.tabAnaPrest.Name = "tabAnaPrest";
			this.tabAnaPrest.Size = new System.Drawing.Size(879, 502);
			this.tabAnaPrest.TabIndex = 6;
			this.tabAnaPrest.Text = "Anagrafe Prestazioni";
			this.tabAnaPrest.UseVisualStyleBackColor = true;
			// 
			// btnCollegaAP
			// 
			this.btnCollegaAP.Location = new System.Drawing.Point(432, 94);
			this.btnCollegaAP.Name = "btnCollegaAP";
			this.btnCollegaAP.Size = new System.Drawing.Size(224, 39);
			this.btnCollegaAP.TabIndex = 22;
			this.btnCollegaAP.Text = "Collega ad Anagrafe delle Prestazioni  già esistente";
			this.btnCollegaAP.Click += new System.EventHandler(this.btnCollegaAP_Click);
			// 
			// grpBoxDocAutorizzattivo
			// 
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label62);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDataDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label65);
			this.grpBoxDocAutorizzattivo.Location = new System.Drawing.Point(290, 248);
			this.grpBoxDocAutorizzattivo.Name = "grpBoxDocAutorizzattivo";
			this.grpBoxDocAutorizzattivo.Size = new System.Drawing.Size(374, 54);
			this.grpBoxDocAutorizzattivo.TabIndex = 21;
			this.grpBoxDocAutorizzattivo.TabStop = false;
			this.grpBoxDocAutorizzattivo.Text = "Documento autorizzativo";
			// 
			// txtDocumentoAut
			// 
			this.txtDocumentoAut.Location = new System.Drawing.Point(8, 30);
			this.txtDocumentoAut.Name = "txtDocumentoAut";
			this.txtDocumentoAut.Size = new System.Drawing.Size(255, 20);
			this.txtDocumentoAut.TabIndex = 1;
			this.txtDocumentoAut.Tag = "casualcontract.authdoc";
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(8, 14);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(128, 16);
			this.label62.TabIndex = 0;
			this.label62.Text = "Descrizione";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumentoAut
			// 
			this.txtDataDocumentoAut.Location = new System.Drawing.Point(285, 30);
			this.txtDataDocumentoAut.Name = "txtDataDocumentoAut";
			this.txtDataDocumentoAut.Size = new System.Drawing.Size(72, 20);
			this.txtDataDocumentoAut.TabIndex = 2;
			this.txtDataDocumentoAut.Tag = "casualcontract.authdocdate";
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(285, 14);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(72, 16);
			this.label65.TabIndex = 0;
			this.label65.Text = "Data";
			this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpBoxMotivo
			// 
			this.grpBoxMotivo.Controls.Add(this.txtMotivoAut);
			this.grpBoxMotivo.Location = new System.Drawing.Point(290, 151);
			this.grpBoxMotivo.Name = "grpBoxMotivo";
			this.grpBoxMotivo.Size = new System.Drawing.Size(374, 91);
			this.grpBoxMotivo.TabIndex = 20;
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
			this.txtMotivoAut.Tag = "casualcontract.noauthreason";
			// 
			// grpBoxAutorizzazioneAP
			// 
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbAutorizzazioneNonNecessaria);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNonApplicabile);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNecessitaAutorizzazione);
			this.grpBoxAutorizzazioneAP.Location = new System.Drawing.Point(19, 150);
			this.grpBoxAutorizzazioneAP.Name = "grpBoxAutorizzazioneAP";
			this.grpBoxAutorizzazioneAP.Size = new System.Drawing.Size(265, 91);
			this.grpBoxAutorizzazioneAP.TabIndex = 19;
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
			this.rdbAutorizzazioneNonNecessaria.Tag = "casualcontract.authneeded:N";
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
			this.rdbNonApplicabile.Tag = "casualcontract.authneeded:X";
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
			this.rdbNecessitaAutorizzazione.Tag = "casualcontract.authneeded:S";
			this.rdbNecessitaAutorizzazione.Text = "Necessita autorizzazione";
			this.rdbNecessitaAutorizzazione.UseVisualStyleBackColor = true;
			this.rdbNecessitaAutorizzazione.CheckedChanged += new System.EventHandler(this.rdbNecessitaAutorizzazione_CheckedChanged);
			// 
			// btnGeneraAP
			// 
			this.btnGeneraAP.Location = new System.Drawing.Point(432, 56);
			this.btnGeneraAP.Name = "btnGeneraAP";
			this.btnGeneraAP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraAP.TabIndex = 9;
			this.btnGeneraAP.Text = "Genera Anagrafe delle Prestazioni";
			this.btnGeneraAP.Click += new System.EventHandler(this.btnGeneraAP_Click);
			// 
			// btnVisualizzaAP
			// 
			this.btnVisualizzaAP.Location = new System.Drawing.Point(432, 24);
			this.btnVisualizzaAP.Name = "btnVisualizzaAP";
			this.btnVisualizzaAP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaAP.TabIndex = 8;
			this.btnVisualizzaAP.Text = "Visualizza Anagrafe delle Prestazione";
			this.btnVisualizzaAP.Click += new System.EventHandler(this.btnVisualizzaAP_Click);
			// 
			// labAPnongenerato
			// 
			this.labAPnongenerato.Location = new System.Drawing.Point(16, 56);
			this.labAPnongenerato.Name = "labAPnongenerato";
			this.labAPnongenerato.Size = new System.Drawing.Size(424, 24);
			this.labAPnongenerato.TabIndex = 7;
			this.labAPnongenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni  NON sono state ancora generate." +
    "";
			// 
			// labAPgenerato
			// 
			this.labAPgenerato.Location = new System.Drawing.Point(16, 32);
			this.labAPgenerato.Name = "labAPgenerato";
			this.labAPgenerato.Size = new System.Drawing.Size(352, 16);
			this.labAPgenerato.TabIndex = 6;
			this.labAPgenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni sono state generate.";
			// 
			// tabRegistroUnico
			// 
			this.tabRegistroUnico.Controls.Add(this.cmbipa);
			this.tabRegistroUnico.Controls.Add(this.richTextBox1);
			this.tabRegistroUnico.Controls.Add(this.label88);
			this.tabRegistroUnico.Controls.Add(this.dgrPCC);
			this.tabRegistroUnico.Controls.Add(this.checkBox2);
			this.tabRegistroUnico.Controls.Add(this.grpRegistroUnico);
			this.tabRegistroUnico.Location = new System.Drawing.Point(4, 23);
			this.tabRegistroUnico.Name = "tabRegistroUnico";
			this.tabRegistroUnico.Size = new System.Drawing.Size(879, 502);
			this.tabRegistroUnico.TabIndex = 9;
			this.tabRegistroUnico.Text = "Registro Unico";
			this.tabRegistroUnico.UseVisualStyleBackColor = true;
			// 
			// cmbipa
			// 
			this.cmbipa.DataSource = this.DS.ipa;
			this.cmbipa.DisplayMember = "officename";
			this.cmbipa.Location = new System.Drawing.Point(363, 336);
			this.cmbipa.Name = "cmbipa";
			this.cmbipa.Size = new System.Drawing.Size(419, 21);
			this.cmbipa.TabIndex = 77;
			this.cmbipa.Tag = "casualcontract.ipa_fe";
			this.cmbipa.ValueMember = "ipa_fe";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(363, 308);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(450, 33);
			this.richTextBox1.TabIndex = 76;
			this.richTextBox1.Text = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito" +
    " www.indicepa.gov.it.";
			// 
			// label88
			// 
			this.label88.Location = new System.Drawing.Point(9, 367);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(258, 20);
			this.label88.TabIndex = 55;
			this.label88.Text = "Trasmissione PCC";
			// 
			// dgrPCC
			// 
			this.dgrPCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPCC.DataMember = "";
			this.dgrPCC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPCC.Location = new System.Drawing.Point(12, 390);
			this.dgrPCC.Name = "dgrPCC";
			this.dgrPCC.Size = new System.Drawing.Size(807, 93);
			this.dgrPCC.TabIndex = 54;
			this.dgrPCC.Tag = "pccview.casualcontract";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(12, 338);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(223, 17);
			this.checkBox2.TabIndex = 52;
			this.checkBox2.Tag = "casualcontract.resendingpcc:S:N";
			this.checkBox2.Text = "Ritrasmetti contratto occasionale alla PCC";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// grpRegistroUnico
			// 
			this.grpRegistroUnico.Controls.Add(this.btnCasuale);
			this.grpRegistroUnico.Controls.Add(this.grpNaturadiSpesa);
			this.grpRegistroUnico.Controls.Add(this.txtCausale);
			this.grpRegistroUnico.Controls.Add(this.label89);
			this.grpRegistroUnico.Controls.Add(this.btnCreaRegistroUnico);
			this.grpRegistroUnico.Controls.Add(this.cmbStatodelDebito);
			this.grpRegistroUnico.Controls.Add(this.txtCIG);
			this.grpRegistroUnico.Controls.Add(this.lblcig);
			this.grpRegistroUnico.Controls.Add(this.label87);
			this.grpRegistroUnico.Controls.Add(this.txtCUP);
			this.grpRegistroUnico.Controls.Add(this.txtScadenza);
			this.grpRegistroUnico.Controls.Add(this.label86);
			this.grpRegistroUnico.Controls.Add(this.label85);
			this.grpRegistroUnico.Controls.Add(this.txDataRicezioneRU);
			this.grpRegistroUnico.Controls.Add(this.txtProgressivoRU);
			this.grpRegistroUnico.Controls.Add(this.label82);
			this.grpRegistroUnico.Controls.Add(this.label83);
			this.grpRegistroUnico.Controls.Add(this.txtProtocolloEntrataRU);
			this.grpRegistroUnico.Controls.Add(this.txtAnnotazioniRU);
			this.grpRegistroUnico.Controls.Add(this.label84);
			this.grpRegistroUnico.Location = new System.Drawing.Point(12, 17);
			this.grpRegistroUnico.Name = "grpRegistroUnico";
			this.grpRegistroUnico.Size = new System.Drawing.Size(770, 265);
			this.grpRegistroUnico.TabIndex = 16;
			this.grpRegistroUnico.TabStop = false;
			// 
			// btnCasuale
			// 
			this.btnCasuale.BackColor = System.Drawing.SystemColors.Control;
			this.btnCasuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCasuale.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCasuale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCasuale.ImageIndex = 0;
			this.btnCasuale.Location = new System.Drawing.Point(37, 211);
			this.btnCasuale.Name = "btnCasuale";
			this.btnCasuale.Size = new System.Drawing.Size(57, 23);
			this.btnCasuale.TabIndex = 80;
			this.btnCasuale.TabStop = false;
			this.btnCasuale.Tag = "";
			this.btnCasuale.Text = "Causale";
			this.btnCasuale.UseVisualStyleBackColor = false;
			this.btnCasuale.Click += new System.EventHandler(this.btnCasuale_Click);
			// 
			// grpNaturadiSpesa
			// 
			this.grpNaturadiSpesa.Controls.Add(this.rdbContoCapitale);
			this.grpNaturadiSpesa.Controls.Add(this.rdbSpesaCorrente);
			this.grpNaturadiSpesa.Location = new System.Drawing.Point(494, 121);
			this.grpNaturadiSpesa.Name = "grpNaturadiSpesa";
			this.grpNaturadiSpesa.Size = new System.Drawing.Size(270, 36);
			this.grpNaturadiSpesa.TabIndex = 66;
			this.grpNaturadiSpesa.TabStop = false;
			this.grpNaturadiSpesa.Text = "Natura di spesa";
			// 
			// rdbContoCapitale
			// 
			this.rdbContoCapitale.AutoSize = true;
			this.rdbContoCapitale.Location = new System.Drawing.Point(136, 13);
			this.rdbContoCapitale.Name = "rdbContoCapitale";
			this.rdbContoCapitale.Size = new System.Drawing.Size(93, 17);
			this.rdbContoCapitale.TabIndex = 25;
			this.rdbContoCapitale.TabStop = true;
			this.rdbContoCapitale.Tag = "casualcontract.expensekind:CA";
			this.rdbContoCapitale.Text = "Conto capitale";
			this.rdbContoCapitale.UseVisualStyleBackColor = true;
			// 
			// rdbSpesaCorrente
			// 
			this.rdbSpesaCorrente.AutoSize = true;
			this.rdbSpesaCorrente.Location = new System.Drawing.Point(23, 14);
			this.rdbSpesaCorrente.Name = "rdbSpesaCorrente";
			this.rdbSpesaCorrente.Size = new System.Drawing.Size(97, 17);
			this.rdbSpesaCorrente.TabIndex = 24;
			this.rdbSpesaCorrente.TabStop = true;
			this.rdbSpesaCorrente.Tag = "casualcontract.expensekind:CO";
			this.rdbSpesaCorrente.Text = "Spesa corrente";
			this.rdbSpesaCorrente.UseVisualStyleBackColor = true;
			// 
			// txtCausale
			// 
			this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausale.Location = new System.Drawing.Point(109, 213);
			this.txtCausale.Multiline = true;
			this.txtCausale.Name = "txtCausale";
			this.txtCausale.ReadOnly = true;
			this.txtCausale.Size = new System.Drawing.Size(415, 30);
			this.txtCausale.TabIndex = 81;
			this.txtCausale.TabStop = false;
			this.txtCausale.Tag = "";
			// 
			// label89
			// 
			this.label89.Location = new System.Drawing.Point(7, 179);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(96, 20);
			this.label89.TabIndex = 79;
			this.label89.Text = "Stato del debito";
			this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCreaRegistroUnico
			// 
			this.btnCreaRegistroUnico.Location = new System.Drawing.Point(574, 236);
			this.btnCreaRegistroUnico.Name = "btnCreaRegistroUnico";
			this.btnCreaRegistroUnico.Size = new System.Drawing.Size(190, 23);
			this.btnCreaRegistroUnico.TabIndex = 65;
			this.btnCreaRegistroUnico.Text = "Protocolla nel Registro Unico";
			this.btnCreaRegistroUnico.UseVisualStyleBackColor = true;
			this.btnCreaRegistroUnico.Click += new System.EventHandler(this.btnCreaRegistroUnico_Click);
			// 
			// cmbStatodelDebito
			// 
			this.cmbStatodelDebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatodelDebito.DataSource = this.DS.pccdebitstatus;
			this.cmbStatodelDebito.DisplayMember = "description";
			this.cmbStatodelDebito.Location = new System.Drawing.Point(109, 179);
			this.cmbStatodelDebito.Name = "cmbStatodelDebito";
			this.cmbStatodelDebito.Size = new System.Drawing.Size(415, 21);
			this.cmbStatodelDebito.TabIndex = 78;
			this.cmbStatodelDebito.Tag = "casualcontract.idpccdebitstatus";
			this.cmbStatodelDebito.ValueMember = "idpccdebitstatus";
			// 
			// txtCIG
			// 
			this.txtCIG.Location = new System.Drawing.Point(216, 137);
			this.txtCIG.Name = "txtCIG";
			this.txtCIG.Size = new System.Drawing.Size(155, 20);
			this.txtCIG.TabIndex = 64;
			this.txtCIG.Tag = "casualcontract.cigcode";
			// 
			// lblcig
			// 
			this.lblcig.Location = new System.Drawing.Point(213, 117);
			this.lblcig.Name = "lblcig";
			this.lblcig.Size = new System.Drawing.Size(173, 19);
			this.lblcig.TabIndex = 63;
			this.lblcig.Tag = "";
			this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
			this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(45, 118);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(170, 16);
			this.label87.TabIndex = 62;
			this.label87.Text = "Codice Unico di Progetto (CUP)";
			this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCUP
			// 
			this.txtCUP.Location = new System.Drawing.Point(45, 137);
			this.txtCUP.Name = "txtCUP";
			this.txtCUP.Size = new System.Drawing.Size(155, 20);
			this.txtCUP.TabIndex = 61;
			this.txtCUP.Tag = "casualcontract.cupcode";
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(379, 78);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(102, 20);
			this.txtScadenza.TabIndex = 17;
			this.txtScadenza.Tag = "casualcontract.expiration";
			// 
			// label86
			// 
			this.label86.Location = new System.Drawing.Point(315, 79);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(60, 18);
			this.label86.TabIndex = 18;
			this.label86.Text = "Scadenza";
			this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label85
			// 
			this.label85.Location = new System.Drawing.Point(89, 78);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(98, 20);
			this.label85.TabIndex = 16;
			this.label85.Text = "Data ricezione";
			this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txDataRicezioneRU
			// 
			this.txDataRicezioneRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txDataRicezioneRU.Location = new System.Drawing.Point(199, 78);
			this.txDataRicezioneRU.Name = "txDataRicezioneRU";
			this.txDataRicezioneRU.Size = new System.Drawing.Size(110, 20);
			this.txDataRicezioneRU.TabIndex = 15;
			this.txDataRicezioneRU.Tag = "casualcontract.arrivaldate";
			// 
			// txtProgressivoRU
			// 
			this.txtProgressivoRU.Location = new System.Drawing.Point(199, 23);
			this.txtProgressivoRU.Name = "txtProgressivoRU";
			this.txtProgressivoRU.Size = new System.Drawing.Size(87, 20);
			this.txtProgressivoRU.TabIndex = 14;
			this.txtProgressivoRU.Tag = "uniqueregister.iduniqueregister?casualcontractview.iduniqueregister";
			this.txtProgressivoRU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label82
			// 
			this.label82.Location = new System.Drawing.Point(6, 22);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(187, 20);
			this.label82.TabIndex = 13;
			this.label82.Text = "Codice progressivo di registrazione";
			this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label83
			// 
			this.label83.Location = new System.Drawing.Point(25, 52);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(162, 20);
			this.label83.TabIndex = 8;
			this.label83.Text = "Numero protocollo di entrata";
			this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProtocolloEntrataRU
			// 
			this.txtProtocolloEntrataRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProtocolloEntrataRU.Location = new System.Drawing.Point(199, 52);
			this.txtProtocolloEntrataRU.Multiline = true;
			this.txtProtocolloEntrataRU.Name = "txtProtocolloEntrataRU";
			this.txtProtocolloEntrataRU.Size = new System.Drawing.Size(282, 20);
			this.txtProtocolloEntrataRU.TabIndex = 7;
			this.txtProtocolloEntrataRU.Tag = "casualcontract.arrivalprotocolnum";
			// 
			// txtAnnotazioniRU
			// 
			this.txtAnnotazioniRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnnotazioniRU.Location = new System.Drawing.Point(494, 41);
			this.txtAnnotazioniRU.Multiline = true;
			this.txtAnnotazioniRU.Name = "txtAnnotazioniRU";
			this.txtAnnotazioniRU.Size = new System.Drawing.Size(270, 56);
			this.txtAnnotazioniRU.TabIndex = 11;
			this.txtAnnotazioniRU.Tag = "casualcontract.annotations";
			// 
			// label84
			// 
			this.label84.Location = new System.Drawing.Point(491, 16);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(81, 16);
			this.label84.TabIndex = 12;
			this.label84.Text = "Annotazioni";
			this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabDalia
			// 
			this.tabDalia.Controls.Add(this.groupBox2);
			this.tabDalia.Controls.Add(this.gboxDipartimento);
			this.tabDalia.Controls.Add(this.grpCausaliAssunzioneDalia);
			this.tabDalia.Controls.Add(this.txtVoceSpesaDalia);
			this.tabDalia.Controls.Add(this.btnVoceSpesaDalia);
			this.tabDalia.Controls.Add(this.gboxDalia);
			this.tabDalia.Location = new System.Drawing.Point(4, 23);
			this.tabDalia.Name = "tabDalia";
			this.tabDalia.Padding = new System.Windows.Forms.Padding(3);
			this.tabDalia.Size = new System.Drawing.Size(879, 502);
			this.tabDalia.TabIndex = 10;
			this.tabDalia.Text = "DALIA";
			this.tabDalia.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cmbDaliaFunzionale);
			this.groupBox2.Location = new System.Drawing.Point(19, 273);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(406, 54);
			this.groupBox2.TabIndex = 117;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Area funzionale - richiesta per il personale Tecnico / Amministrativo";
			// 
			// cmbDaliaFunzionale
			// 
			this.cmbDaliaFunzionale.FormattingEnabled = true;
			this.cmbDaliaFunzionale.Location = new System.Drawing.Point(6, 19);
			this.cmbDaliaFunzionale.Name = "cmbDaliaFunzionale";
			this.cmbDaliaFunzionale.Size = new System.Drawing.Size(367, 21);
			this.cmbDaliaFunzionale.TabIndex = 0;
			this.cmbDaliaFunzionale.Tag = "casualcontract.iddalia_funzionale";
			// 
			// gboxDipartimento
			// 
			this.gboxDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDipartimento.Controls.Add(this.btnDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtCodiceDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtDaliaDipartimento);
			this.gboxDipartimento.Location = new System.Drawing.Point(19, 217);
			this.gboxDipartimento.Name = "gboxDipartimento";
			this.gboxDipartimento.Size = new System.Drawing.Size(807, 50);
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
			this.txtCodiceDipartimento.Location = new System.Drawing.Point(694, 19);
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
			this.txtDaliaDipartimento.Size = new System.Drawing.Size(559, 20);
			this.txtDaliaDipartimento.TabIndex = 0;
			this.txtDaliaDipartimento.Tag = "dalia_dipartimento.title";
			// 
			// grpCausaliAssunzioneDalia
			// 
			this.grpCausaliAssunzioneDalia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCausaliAssunzioneDalia.Controls.Add(this.txtCausaleAssunzione);
			this.grpCausaliAssunzioneDalia.Controls.Add(this.btnEsclusioneCIG);
			this.grpCausaliAssunzioneDalia.Location = new System.Drawing.Point(19, 165);
			this.grpCausaliAssunzioneDalia.Name = "grpCausaliAssunzioneDalia";
			this.grpCausaliAssunzioneDalia.Size = new System.Drawing.Size(807, 46);
			this.grpCausaliAssunzioneDalia.TabIndex = 111;
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
			this.txtCausaleAssunzione.Size = new System.Drawing.Size(678, 20);
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
			this.txtVoceSpesaDalia.Location = new System.Drawing.Point(226, 118);
			this.txtVoceSpesaDalia.Name = "txtVoceSpesaDalia";
			this.txtVoceSpesaDalia.ReadOnly = true;
			this.txtVoceSpesaDalia.Size = new System.Drawing.Size(603, 20);
			this.txtVoceSpesaDalia.TabIndex = 110;
			// 
			// btnVoceSpesaDalia
			// 
			this.btnVoceSpesaDalia.Location = new System.Drawing.Point(19, 118);
			this.btnVoceSpesaDalia.Name = "btnVoceSpesaDalia";
			this.btnVoceSpesaDalia.Size = new System.Drawing.Size(185, 23);
			this.btnVoceSpesaDalia.TabIndex = 16;
			this.btnVoceSpesaDalia.Text = "Seleziona Voce di spesa Dalia";
			this.btnVoceSpesaDalia.UseVisualStyleBackColor = true;
			this.btnVoceSpesaDalia.Click += new System.EventHandler(this.btnVoceSpesaDalia_Click);
			// 
			// gboxDalia
			// 
			this.gboxDalia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDalia.Controls.Add(this.btnQualificaDalia);
			this.gboxDalia.Controls.Add(this.label91);
			this.gboxDalia.Controls.Add(this.textBox6);
			this.gboxDalia.Controls.Add(this.cmb_dalia_position);
			this.gboxDalia.Location = new System.Drawing.Point(19, 18);
			this.gboxDalia.Name = "gboxDalia";
			this.gboxDalia.Size = new System.Drawing.Size(810, 80);
			this.gboxDalia.TabIndex = 109;
			this.gboxDalia.TabStop = false;
			this.gboxDalia.Text = "Banca Dati DALIA";
			// 
			// btnQualificaDalia
			// 
			this.btnQualificaDalia.Location = new System.Drawing.Point(69, 40);
			this.btnQualificaDalia.Name = "btnQualificaDalia";
			this.btnQualificaDalia.Size = new System.Drawing.Size(116, 23);
			this.btnQualificaDalia.TabIndex = 111;
			this.btnQualificaDalia.Text = "Qualifica Dalia";
			this.btnQualificaDalia.UseVisualStyleBackColor = true;
			this.btnQualificaDalia.Click += new System.EventHandler(this.btnQualificaDalia_Click);
			// 
			// label91
			// 
			this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(672, 21);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(118, 13);
			this.label91.TabIndex = 110;
			this.label91.Text = "Codice Qualifica DALIA";
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(674, 39);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(116, 20);
			this.textBox6.TabIndex = 109;
			this.textBox6.Tag = "dalia_position.codedaliaposition";
			// 
			// cmb_dalia_position
			// 
			this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_dalia_position.DataSource = this.DS.dalia_position;
			this.cmb_dalia_position.DisplayMember = "description";
			this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dalia_position.Location = new System.Drawing.Point(207, 40);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(448, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "casualcontract.iddaliaposition";
			this.cmb_dalia_position.ValueMember = "iddaliaposition";
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dgrAllegati);
			this.tabAllegati.Controls.Add(this.btnDelAtt);
			this.tabAllegati.Controls.Add(this.btnEditAtt);
			this.tabAllegati.Controls.Add(this.btnInsAtt);
			this.tabAllegati.Location = new System.Drawing.Point(4, 23);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Size = new System.Drawing.Size(879, 502);
			this.tabAllegati.TabIndex = 11;
			this.tabAllegati.Text = "Allegati";
			this.tabAllegati.UseVisualStyleBackColor = true;
			// 
			// dgrAllegati
			// 
			this.dgrAllegati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrAllegati.DataMember = "";
			this.dgrAllegati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrAllegati.Location = new System.Drawing.Point(13, 46);
			this.dgrAllegati.Name = "dgrAllegati";
			this.dgrAllegati.ReadOnly = true;
			this.dgrAllegati.Size = new System.Drawing.Size(850, 440);
			this.dgrAllegati.TabIndex = 23;
			this.dgrAllegati.Tag = "casualcontractattachment.lista.detail";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(173, 16);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 23);
			this.btnDelAtt.TabIndex = 22;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(93, 16);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(69, 23);
			this.btnEditAtt.TabIndex = 21;
			this.btnEditAtt.Tag = "edit.detail";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(13, 16);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 23);
			this.btnInsAtt.TabIndex = 20;
			this.btnInsAtt.Tag = "insert.detail";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// Frm_casualcontract_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(898, 541);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_casualcontract_default";
			this.Text = "frmcontrattooccasionale";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabContratto.ResumeLayout(false);
			this.tabContratto.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.grpDettagliPrevidenzialiAssistenziali.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.grpPrestazione.ResumeLayout(false);
			this.grpPercipiente.ResumeLayout(false);
			this.grpPercipiente.PerformLayout();
			this.grpContratto.ResumeLayout(false);
			this.grpContratto.PerformLayout();
			this.tabSpese.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabImponibili.ResumeLayout(false);
			this.tabImponibili.PerformLayout();
			this.gboxPrevidenziale.ResumeLayout(false);
			this.gboxPrevidenziale.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.tabRitenute.ResumeLayout(false);
			this.tabRitenute.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabStorico.ResumeLayout(false);
			this.tabStorico.PerformLayout();
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.tabEP.ResumeLayout(false);
			this.tabEP.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.tabAnalitico.ResumeLayout(false);
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
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
			this.gBoxCausale.ResumeLayout(false);
			this.gBoxCausale.PerformLayout();
			this.tabClassSuppl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).EndInit();
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
			this.tabAnaPrest.ResumeLayout(false);
			this.grpBoxDocAutorizzattivo.ResumeLayout(false);
			this.grpBoxDocAutorizzattivo.PerformLayout();
			this.grpBoxMotivo.ResumeLayout(false);
			this.grpBoxMotivo.PerformLayout();
			this.grpBoxAutorizzazioneAP.ResumeLayout(false);
			this.grpBoxAutorizzazioneAP.PerformLayout();
			this.tabRegistroUnico.ResumeLayout(false);
			this.tabRegistroUnico.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).EndInit();
			this.grpRegistroUnico.ResumeLayout(false);
			this.grpRegistroUnico.PerformLayout();
			this.grpNaturadiSpesa.ResumeLayout(false);
			this.grpNaturadiSpesa.PerformLayout();
			this.tabDalia.ResumeLayout(false);
			this.tabDalia.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.gboxDipartimento.ResumeLayout(false);
			this.gboxDipartimento.PerformLayout();
			this.grpCausaliAssunzioneDalia.ResumeLayout(false);
			this.grpCausaliAssunzioneDalia.PerformLayout();
			this.gboxDalia.ResumeLayout(false);
			this.gboxDalia.PerformLayout();
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrAllegati)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        private EP_Manager EPM;
        object idsorkindDalia;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            idsorkindDalia = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");

            AccMotiveManager AM = new AccMotiveManager(gBoxCausale);
            AccMotiveManager AM01 = new AccMotiveManager(gBoxCausaleDebito);
            AccMotiveManager AM02 = new AccMotiveManager(gBoxCausaleDebitoCrg);
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.casualcontractyear, filteresercizio);
            GetData.SetStaticFilter(DS.sortingview, filteresercizio);
            GetData.SetStaticFilter(DS.sortingview1, filteresercizio);

            string filterPrestazione = QHS.CmpEq("module", "OCCASIONALE");
            GetData.SetStaticFilter(DS.service, filterPrestazione);
			GetData.CacheTable(DS.motive770service, QHS.AppAnd(filteresercizio,
                QHS.FieldIn("idmot", new object[] {"C", "V", "M"})), null, false);

            GetData.CacheTable(DS.otherinsurance, filteresercizio, "description", true);
            GetData.CacheTable(DS.casualrefund, null, null, false);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.casualcontractexemption, null, null, false);
            GetData.CacheTable(DS.tax, null, null, false);
            DS.casualcontracttaxbracket.ExtendedProperties["gridmaster"] = "casualcontracttax";
            HelpForm.SetFormatForColumn(DS.casualcontractyear.Columns["higherrate"], "p");
            MetaData.SetDefault(DS.casualcontractyear, "flaghigherrate", "N");
            SubEntity_cmbAliquotaFiscale.Enabled = false;
            GetData.SetSorting(DS.taxratebracket, "employrate");
            HelpForm.SetDenyNull(DS.casualcontract.Columns["completed"], true);
            HelpForm.SetDenyNull(DS.casualcontract.Columns["resendingpcc"], true);
            HelpForm.SetDenyNull(DS.casualcontract.Columns["requested_doc"], true);
            string filterEpOperationSF = QHS.CmpEq("idepoperation", "prestocc");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "prestocc");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationSF = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationSF, Meta.Conn);
            filterEpOperationEP = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationEP, Meta.Conn);
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperationSF);
            DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "prestocc_deb");
            filterEpOperationDeb = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDeb, Meta.Conn);
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");

            DataAccess.SetTableForReading(DS.sortingview1, "sortingview");

            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filteresercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }
            }

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

            GetData.SetSorting(DS.pccdebitmotive, "listingorder asc");
            GetData.SetSorting(DS.pccdebitstatus, "listingorder asc");
            Meta.MarkTableAsNotEntityChild(DS.uniqueregister);
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni,
                btnGeneraEP, btnVisualizzaEP, labEP, null, "casualcontract");

            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope); 

			bool IsAdmin = (Meta.GetSys("manage_prestazioni") != null) ? Meta.GetSys("manage_prestazioni").ToString() == "S" : false;
            object flag_escludidacu = Conn.GetUsr("flag_escludidacu");
            bool function_enabled = ((flag_escludidacu != null && flag_escludidacu.ToString().ToUpper() == "'S'"));
            SubEntity_chkExcludeFromCertificate.Enabled = IsAdmin||function_enabled;
        }

        siope_helper SiopeObj;




        public void MetaData_AfterClear() {
            if (mycalc!=null) mycalc.ResetHash();
            to_close = false;
            Meta.CanSave = true;
            gboxPrevidenziale.Visible = true;
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
            lblDateCompleted.Visible = txtDateCompleted.Visible;
            abilitaDisabilitaDalia(null);
            abilitaDisabilitaCCdedicato(null);
            cmb_dalia_position.Enabled = true;
            AggiornaVoceSpesa();
            txtEsercizio.ReadOnly = false;
            AzzeraTxtCalcolati();
            azzeraVardiConfronto();

            // Gestione dei combo box del tipo rapporto EMENS e della attività previdenziale INPS
            SubEntity_cmbTipoRapporto.Enabled = true;
            btnTipoRapporto.Enabled = true;
            if (DS.inpsactivity.Rows.Count > 1) {
                SubEntity_cmbAttPrevidenzialeINPS.Enabled = true;
                btnAttivitaPrevINPS.Enabled = true;
            }
            SubEntity_cmbAltreFormeAssicurative.Enabled = true;
            btnAltreFormeAssicurative.Enabled = true;


            btnTrasfoccasionali.Enabled = false;
            btnTrasfoccasionali.Visible = false;


            btnRicalcola.Enabled = false;

            EPM.mostraEtichette();
            VisualizzaEtichetteAP();
            MostraNascondiAutorizzazione();
            MostraNascondiMotivazione();
            grpBoxAutorizzazioneAP.Enabled = true;
            //Fill con filtro del solo esercizio della combo - EMENSTIPORAPPORTO
            PostData.MarkAsRealTable((DataTable) SubEntity_cmbTipoRapporto.DataSource);
            GetData.CacheTable(DS.emenscontractkind, filteresercizio, null, true);
            Meta.myHelpForm.PreFillControlsTable(SubEntity_cmbTipoRapporto, null);
            PostData.MarkAsTemporaryTable((DataTable) SubEntity_cmbTipoRapporto.DataSource, false);

            //Fill con filtro del solo esercizio della combo - ATTIVITAPREVIDENZIALEINPS
            PostData.MarkAsRealTable((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource);
            GetData.CacheTable(DS.inpsactivity, filteresercizio, null, true);
            Meta.myHelpForm.PreFillControlsTable(SubEntity_cmbAttPrevidenzialeINPS, null);
            PostData.MarkAsTemporaryTable((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource, false);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') and (human='S'))";
            Meta.SetAutoMode(grpPercipiente);
            VisualizzaNumeroRegistroUnico();
            AbilitaDisabilitaRegistroUnico();
            txtProgressivoRU.ReadOnly = false;
            txtCausale.Text = "";
            rdbContoCapitale.Enabled = true;
            rdbContoCapitale.Checked = false;
            rdbSpesaCorrente.Enabled = true;
            rdbSpesaCorrente.Checked = false;
            SiopeObj.setCausaleEPCorrente(null);
            
        }

        private void AbilitaDisabilitaRegistroUnico() {
            if ((Meta.IsEmpty) || (DS.casualcontract.Rows.Count == 0)) {
                btnCreaRegistroUnico.Enabled = false;
                return;
            }

            if (DS.uniqueregister.Rows.Count > 0) {
                btnCreaRegistroUnico.Enabled = false;
            }
            else {
                btnCreaRegistroUnico.Enabled = true;
            }

        }

        private void VisualizzaNumeroRegistroUnico() {
            txtProgressivoRU.Text = "";
            if (DS.casualcontract.Rows.Count == 0 || DS.uniqueregister.Rows.Count == 0) {
                return;
            }

            DataRow CurrCasualcontract = DS.casualcontract.Rows[0];
            string filter = QHS.AppAnd(QHS.CmpEq("ycon", CurrCasualcontract["ycon"]),
                QHS.CmpEq("ncon", CurrCasualcontract["ncon"]));
            if ((Meta.Conn.RUN_SELECT_COUNT("uniqueregister", filter, false) > 0)
                && (DS.uniqueregister.Rows.Count > 0)) {
                DataRow Runiqueregister = DS.uniqueregister.Rows[0];
                txtProgressivoRU.Text = Runiqueregister["iduniqueregister"].ToString();
            }
        }




        //TASK 10623 aggiunto il btnTrasfoccasionali 

        private void btnTrasfoccasionali_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) {
                show(this, "Sei in modalità ricerca, effettua la ricerca prima di trasferire");
                return;
            }

            if (Meta.InsertMode) {
                show(this, "Sei in modalità inserimento non puoi ancora trasferire il contratto");
                return;
            }


            DataAccess Conn = MetaData.GetConnection(this);
            try {
                DataRow MyRow = HelpForm.GetLastSelected(DS.casualcontract);
            }
            catch {
                return;
            }

            DataSet Out = Meta.Conn.CallSP("closeyear_casualcontract_trasfsingle",
                new Object[3] {
                    Meta.GetSys("esercizio").ToString(),
                    Convert.ToInt32(DS.Tables["casualcontract"].Rows[0]["ycon"]),
                    Convert.ToInt32(DS.Tables["casualcontract"].Rows[0]["ncon"])
                }
            );
            if (Out == null) return;
            show(this, "Trasferimento effettuato");

        }







        public void MetaData_AfterGetFormData() {
            if (to_close) return;

            // In questo modo la libreria riconosce come sub entità di casualcontract la tabella casualcontractyear
            Meta.myHelpForm.addExtraEntity("casualcontractyear");
            if (Meta.InsertMode) {
                DataRow Curr = DS.casualcontract.Rows[0];
                foreach (DataRow R1 in DS.casualcontractdeduction.Select()) {
                    R1["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R3 in DS.casualcontractrefund.Select()) {
                    R3["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R4 in DS.casualcontractsorting.Select()) {
                    R4["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R5 in DS.casualcontracttax.Select()) {
                    R5["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R6 in DS.casualcontracttaxbracket.Select()) {
                    R6["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R7 in DS.casualcontractyear.Select()) {
                    R7["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R8 in DS.uniqueregister.Select()) {
                    R8["ncon"] = Curr["ncon"];
                }
            }


        }

        public void MetaData_BeforeFill() {
            if (to_close) return;
            if (Meta.InsertMode) {
                CreateImputazioneContrattoOccRow();
            }
            if (DS.casualcontractyear.Rows.Count == 0) {
                show("Il contratto selezionato non è stato ancora trasferito nell'anno corrente." +
                                " Non è pertanto possibile usare questa maschera.", "Errore");
                Meta.CanSave = false;
                to_close = true;
                return;
            }
        }

        public void CreateImputazioneContrattoOccRow() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.casualcontract.Rows[0];
            string filtro = QHC.AppAnd(QHC.CmpEq("ycon", Curr["ycon"]), QHC.CmpEq("ncon", Curr["ncon"]),
                QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataRow[] r = DS.casualcontractyear.Select(filtro);
            if (r.Length == 0) {
                DataRow drContratto = DS.Tables["casualcontract"].Rows[0];
                MetaData metaIC = MetaData.GetMetaData(this, "casualcontractyear");
                metaIC.SetDefaults(DS.casualcontractyear);
                DataRow DR = metaIC.Get_New_Row(drContratto, DS.casualcontractyear);
            }
        }

        string idrelated = "";
        //string idrelatedBudget = "";
        //bool fromDelete = false;
        string filterDeleteImputazione = "";
        public void MetaData_BeforePost() {
            filterDeleteImputazione = "";
            if (DS.casualcontract.Rows.Count == 0) return;
           
            DataRow Curr = DS.casualcontract.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                filterDeleteImputazione = QHS.AppAnd(QHS.CmpEq("ycon", Curr["ycon", DataRowVersion.Original]),
                    QHS.CmpEq("ncon", Curr["ncon", DataRowVersion.Original]));
            }
            else {
                filterDeleteImputazione = "";
            }
            EPM.beforePost();

        }

        private void cancellaScritture() {
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;
            EP.GetEntryForDocument(idrelated);

            foreach (DataRow rEntry in EP.D.Tables["entry"].Rows) {
                rEntry.Delete();
            }

            foreach (DataRow rEntryDetail in EP.D.Tables["entrydetail"].Rows) {
                rEntryDetail.Delete();
            }

            MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
            PostData Post = MetaEntry.Get_PostData();

            Post.InitClass(EP.D, Meta.Conn);
            if (!Post.DO_POST()) {
                show(this, "Errore durante la cancellazione delle scritture in PD");
            }
        }


        calcOccasionale mycalc = null;
        DataTable Ritenute = null;

        DataTable GetTabellaRitenute() {
            if (mycalc == null) return null;
            return Ritenute;

        }

        void AzzeraTxtCalcolati() {
            txtImpResiduo.Text = "";
            txtSpeseFiscaliResidue.Text = "";
            txtImpFiscaleNettoResiduo.Text = "";
            txtImpAltriContratti.Text = "";
            txtC1.Text = "";
            txtC2.Text = "";
            txtD.Text = "";
            txtImpContratto.Text = "";
            txtSpeseFiscali.Text = "";
            txtImpFiscaleNettoResiduo.Text = "";
            txtTotaleImpFisc2.Text = "";
            txtSpesePrevidenziali.Text = "";
            txtF2.Text = "";
            txtImpPrevidenzialeResiduo.Text = "";
            txtH1.Text = "";
            txtI.Text = "";
            txtH2.Text = "";
            txtF3.Text = "";
            txtImpPrevContratto.Text = "";
            txtRitFiscaleDip.Text = "";
            txtRitFiscaleAmm.Text = "";
            txtRitPrevidenzialeDip.Text = "";
            txtRitPrevidenzialeAmm.Text = "";
            txtRitAssicurativaDip.Text = "";
            txtRitAssicurativaAmm.Text = "";
            txtRitAssistenzialeDip.Text = "";
            txtRitAssistenzialeAmm.Text = "";
            txtCostoTotale.Text = "";
            txtCostoTotaleInput.Text = "";
            txtImportoNetto.Text = "";

            txtLordoPagato.Text = "";
            txtLordoPagatoAnniPrec.Text = "";
            txtCostoAnniPrec.Text = "";
            txtCostoPagato.Text = "";


            txtFisAnno.Text = "";
            txtContrFisAnno.Text = "";
            txtPrevAnno.Text = "";
            txtContrPrevAnno.Text = "";
            txtAssicurAnno.Text = "";
            txtContrAssicurAnno.Text = "";
            txtAssistAnno.Text = "";
            txtContrAssistAnno.Text = "";

            txtImportoAnno.Text = "";
            txtSpeseFisAnno.Text = "";
            txtSpesePrevAnno.Text = "";
            txtQuotaEsenteAnno.Text = "";
            txtNettoAnno.Text = "";
            txtCostoAnno.Text = "";

        }

        /// <summary>
        /// Ricalcola le ritenute e tutti i prospetti. E' richiamata la sp per i dati pregressi solo se forcecalc=true
        /// </summary>
        /// <param name="CompensoLordo"></param>
        /// <returns></returns>
        void RicalcolaPrestazione(bool forcecalc) {
            AzzeraTxtCalcolati();

            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.casualcontract.Rows[0];
            DataRow CurrYear = DS.casualcontractyear.Rows[0];
            if (mycalc == null || forcecalc) {
                mycalc = new calcOccasionale(Conn, Curr, CurrYear, DS.casualcontractrefund,
                    DS.casualrefund);
                bool res = mycalc.GetInfoContratto();
                if (!res) {
                    mycalc = null;
                    return;
                }
            }
            TassePagate = null;
            CostoTotalePagato = 0;
            CostoTotalePagatoAnniPrecedenti = 0;
            if (Meta.EditMode) {
                TassePagate = Conn.SQLRunner(
                    "  SELECT ET.admintax,ET.employtax,ET.taxcode,E.ymov FROM EXPENSETAXOFFICIAL ET " +
                    "JOIN EXPENSE E ON E.idexp=ET.idexp " +
                    "JOIN EXPENSELINK EL ON EL.idchild=ET.idexp " +
                    "JOIN EXPENSECASUALCONTRACT EC ON EC.idexp= EL.idparent " +
                    " WHERE " + QHS.AppAnd(QHS.CmpEq("EC.ycon", Curr["ycon"]),
                        QHS.CmpEq("EC.ncon", Curr["ncon"]),
                        QHS.IsNull("stop")), false);
                CostoTotalePagato = mycalc.CompensoLordoPagato + getContributiPagati();
                CostoTotalePagatoAnniPrecedenti =
                    mycalc.CompensoLordoPagatoAnniPrecedenti + getContributiPagatiAnniPrecedenti();

            }

            aggiornaRitenute();

        }

        DataTable TassePagate = null;

        decimal getContributiPagati() {
            if (TassePagate == null) return 0;
            decimal sum = 0;
            foreach (DataRow R in TassePagate.Select()) {
                sum += CfgFn.GetNoNullDecimal(R["admintax"]);
            }
            return sum;
        }

        decimal getContributiPagatiAnniPrecedenti() {
            if (TassePagate == null) return 0;
            decimal sum = 0;
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            foreach (DataRow R in TassePagate.Select(QHC.CmpLt("ymov", esercizio))) {
                sum += CfgFn.GetNoNullDecimal(R["admintax"]);
            }
            return sum;
        }

        public DataTable CalcolaRitenute(decimal lordodaconsiderare) {
            if (mycalc == null) {
                DataRow Curr = DS.casualcontract.Rows[0];
                DataRow CurrYear = DS.casualcontractyear.Rows[0];
                mycalc = new calcOccasionale(Conn, Curr, CurrYear, DS.casualcontractrefund,
                    DS.casualrefund);

                bool res = mycalc.GetInfoContratto();
                if (!res) {
                    mycalc = null;
                    return null;
                }

            }
            return mycalc.calcolaRitenute(lordodaconsiderare);
        }

        /// <summary>
        /// Aggiorna i valori in basi a cambiamenti delle spese o degli imponibili altri enti
        /// </summary>
        private void aggiornaRitenute() {
            if (mycalc == null) return;
            decimal lordoresiduo = mycalc.GetLordoResiduo();
            Ritenute = mycalc.calcolaRitenute(lordoresiduo);
            aggiornaTotali(Ritenute);
            calcolaCostoTotale(lordoresiduo);
            if (Ritenute != null) {
                foreach (DataRow Rit in Ritenute.Rows) {
                    object taxcode = Rit["taxcode"];
                    DataRow[] taxkind = DS.tax.Select(
                        QHC.AppAnd(QHC.CmpEq("taxcode", taxcode), QHC.CmpEq("taxkind", 3)));
                    if (taxkind.Length == 0) continue;
                    DataRow Curr = DS.casualcontract.Rows[0];
                    Curr["!codiceritenutainps"] = taxkind[0]["taxref"];
                    break;
                }
            }
        }

        void aggiornaTotali(DataTable Ritenute) {
            calcolaTxtDelTabRitenuteResidue(Ritenute);
            RiempiTabImponibili();
            CalcolaPrimoTab();
            calcolaTxtDelTabRitenuteAnnue(TassePagate);


        }

		private void btnRipartizione_Click(object sender, EventArgs e) {

            if (Meta.IsEmpty)
				return;
			
			if (DS.casualcontract.Rows.Count == 0)
                return;
            DataRow RC = DS.casualcontract.Rows[0];
            if (RC == null)
                return;

            object idcostpartition = RC["idcostpartition"];

            if (idcostpartition != DBNull.Value) {
                MetaData ToMeta = Meta.Dispatcher.Get("costpartition");
                string checkfilter = QHS.CmpEq("idcostpartition", idcostpartition);
                ToMeta.ContextFilter = checkfilter;
                Form F = null;
                if (Meta.linkedForm != null)
                    F = Meta.linkedForm.ParentForm;
                bool result = ToMeta.Edit(F, "default", false);

                string listtype = ToMeta.DefaultListType;
                DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
                if (R != null)
                    ToMeta.SelectRow(R, listtype);
            }
            else {
                idcostpartition = EP_functions.importCostPartitionDetail(Meta);
                if (idcostpartition == null)
                    return;
                RC["idcostpartition"] = idcostpartition;
            }
        }

        void RiempiTabImponibili() {
            txtImpAltriContratti.Text = mycalc.B1.ToString("c");
            txtC1.Text = mycalc.C1.ToString("c");
            txtC2.Text = mycalc.C2.ToString("c");
            txtD.Text = mycalc.D.ToString("c");
            txtImpContratto.Text = mycalc.GetLordoResiduo().ToString("c");
            txtSpeseFiscali.Text = mycalc.C3.ToString("c");
            //txtImpFiscaleNettoResiduo.Text = mycalc.GetImponibileFiscaleNetto(mycalc.GetLordoResiduo()).ToString("c");
            txtImpFiscaleContratto.Text = mycalc.GetImponibileFiscaleNetto(mycalc.GetLordoResiduo()).ToString("c");
            txtTotaleImpFisc2.Text = mycalc.B2.ToString("c");
            txtSpesePrevidenziali.Text = mycalc.F1.ToString("c");
            txtF2.Text = mycalc.F2.ToString("c");
            txtImponibilePrevidenziale.Text = mycalc.G.ToString("c");
            txtH1.Text = mycalc.H1.ToString("c");
            txtI.Text = mycalc.I.ToString("c");
            txtH2.Text = mycalc.H2.ToString("c");
            txtF3.Text = mycalc.F3.ToString("c");
            txtImpPrevContratto.Text = mycalc.GetImponibilePrevidenzialeNetto(mycalc.GetLordoResiduo()).ToString("c");
            gboxPrevidenziale.Visible = hasprevidenziale;
        }


        bool hasprevidenziale = false;

        /// <summary>
        /// Partendo dai dati presenti nel Dataset, vengono ricalcolati i text box presenti nel tab delle ritenute.
        /// Tali text box sono inerenti gli importi delle ritenute c/dip e c/amm,
        /// l'importo netto ed il costo totale della prestazione
        /// Nome precedente del metodo: ricalcolaTXTRitenute
        /// </summary>
        private void calcolaTxtDelTabRitenuteResidue(DataTable Ritenute) {
            decimal ritDipFisc = 0;
            decimal ritDipAssic = 0;
            decimal ritDipAssist = 0;
            decimal ritDipPrev = 0;
            decimal ritAmmFisc = 0;
            decimal ritAmmAssic = 0;
            decimal ritAmmAssist = 0;
            decimal ritAmmPrev = 0;
            hasprevidenziale = false;
            decimal importoNetto = mycalc.GetLordoResiduo();
            ;
            decimal costoTotale = mycalc.GetLordoResiduo();
            txtImpResiduo.Text = costoTotale.ToString("c");
            txtSpeseFiscaliResidue.Text = mycalc.C3.ToString("c");
            txtImpFiscaleNettoResiduo.Text = mycalc.GetImponibileFiscaleNetto(mycalc.GetLordoResiduo()).ToString("c");
            txtImpPrevidenzialeResiduo.Text =
                mycalc.GetImponibilePrevidenzialeNetto(mycalc.GetLordoResiduo()).ToString("c");
            decimal SpesePrevResiduo = mycalc.C3 + mycalc.F3;
            txtSpesePrevResidue.Text = SpesePrevResiduo.ToString("c");
            textQuotaesenteDaApplicare.Text = mycalc.H2.ToString("c");
            //txtQuotaEsenteUfficiale.Text = mycalc.quotaesente.ToString("c");

            if (Ritenute != null) {
                foreach (DataRow R in Ritenute.Select()) {
                    string filtertipo = QHC.CmpEq("taxcode", R["taxcode"]);
                    DataRow[] rkind = DS.tax.Select(filtertipo);
                    if (rkind.Length == 0) continue;
                    string kind = rkind[0]["taxkind"].ToString().ToUpper();
                    switch (kind) {
                        case "1": {
                            ritDipFisc += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmFisc += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "3": {
                            hasprevidenziale = true;
                            ritDipPrev += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmPrev += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "4": {
                            ritDipAssic += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmAssic += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "2": {
                            ritDipAssist += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmAssist += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                    }
                }
            }

            if (DS.casualcontract.Rows.Count > 0) {
                DataRow Curr = DS.casualcontract.Rows[0];
                object idser = Curr["idser"];
                DataTable Servicetax = Conn.RUN_SELECT("servicetax", "*", null, QHS.CmpEq("idser", idser), null, true);
                foreach (DataRow Tax in Servicetax.Select()) {
                    string filtertipo = QHC.CmpEq("taxcode", Tax["taxcode"]);
                    DataRow[] rkind = DS.tax.Select(filtertipo);
                    if (rkind.Length == 0) continue;
                    string kind = rkind[0]["taxkind"].ToString().ToUpper();
                    if (kind == "3") hasprevidenziale = true;
                }
            }

            txtRitFiscaleDip.Text = ritDipFisc.ToString("c");
            txtRitFiscaleAmm.Text = ritAmmFisc.ToString("c");
            txtRitPrevidenzialeDip.Text = ritDipPrev.ToString("c");
            txtRitPrevidenzialeAmm.Text = ritAmmPrev.ToString("c");
            txtRitAssicurativaDip.Text = ritDipAssic.ToString("c");
            txtRitAssicurativaAmm.Text = ritAmmAssic.ToString("c");
            txtRitAssistenzialeDip.Text = ritDipAssist.ToString("c");
            txtRitAssistenzialeAmm.Text = ritAmmAssist.ToString("c");

            decimal costototalegenerale = costoTotale + CostoTotalePagato;
            txtCostoTotale.Text = costoTotale.ToString("c");
            txtCostoTotaleInput.Text = costototalegenerale.ToString("c");
            txtImportoNetto.Text = importoNetto.ToString("c");
        }

        void CalcolaPrimoTab() {
            if (mycalc == null) return;
            txtLordoPagato.Text = mycalc.CompensoLordoPagato.ToString("c");
            txtLordoPagatoAnniPrec.Text = mycalc.CompensoLordoPagatoAnniPrecedenti.ToString("c");
            txtCostoAnniPrec.Text = CostoTotalePagatoAnniPrecedenti.ToString("c");
            txtCostoPagato.Text = CostoTotalePagato.ToString("c");
        }

        private void calcolaTxtDelTabRitenuteAnnue(DataTable Ritenute) {
            decimal pagatoAnno = mycalc.CompensoLordoPagato - mycalc.CompensoLordoPagatoAnniPrecedenti;

            txtImportoAnno.Text = pagatoAnno.ToString("c");
            txtSpeseFisAnno.Text = mycalc.C2.ToString("c");
            txtSpesePrevAnno.Text = mycalc.F2.ToString("c");
            txtQuotaEsenteAnno.Text = mycalc.QuotaEsenteApplicataQuestoContrattoNellAnno.ToString("c");

            decimal ritDipFisc = 0;
            decimal ritDipAssic = 0;
            decimal ritDipAssist = 0;
            decimal ritDipPrev = 0;
            decimal ritAmmFisc = 0;
            decimal ritAmmAssic = 0;
            decimal ritAmmAssist = 0;
            decimal ritAmmPrev = 0;
            decimal importoNetto = pagatoAnno;
            ;
            decimal costoTotale = pagatoAnno;
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            if (Ritenute != null) {
                foreach (DataRow R in Ritenute.Select(QHC.CmpEq("ymov", esercizio))) {
                    string filtertipo = QHC.CmpEq("taxcode", R["taxcode"]);
                    DataRow[] rkind = DS.tax.Select(filtertipo);
                    if (rkind.Length == 0) continue;
                    string kind = rkind[0]["taxkind"].ToString().ToUpper();
                    switch (kind) {
                        case "1": {
                            ritDipFisc += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmFisc += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "3": {
                            ritDipPrev += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmPrev += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "4": {
                            ritDipAssic += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmAssic += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                        case "2": {
                            ritDipAssist += CfgFn.GetNoNullDecimal(R["employtax"]);
                            ritAmmAssist += CfgFn.GetNoNullDecimal(R["admintax"]);
                            costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
                            importoNetto -= CfgFn.GetNoNullDecimal(R["employtax"]);
                            break;
                        }
                    }
                }

            }
            txtFisAnno.Text = ritDipFisc.ToString("c");
            txtContrFisAnno.Text = ritAmmFisc.ToString("c");
            txtPrevAnno.Text = ritDipPrev.ToString("c");
            txtContrPrevAnno.Text = ritAmmPrev.ToString("c");
            txtAssicurAnno.Text = ritDipAssic.ToString("c");
            txtContrAssicurAnno.Text = ritAmmAssic.ToString("c");
            txtAssistAnno.Text = ritDipAssist.ToString("c");
            txtContrAssistAnno.Text = ritAmmAssist.ToString("c");

            txtNettoAnno.Text = importoNetto.ToString("c");
            txtCostoAnno.Text = costoTotale.ToString("c");

        }

        void AbilitaBtnComboOveNecessario(DataRow RService) {
            if (Meta.IsEmpty) return;
            //if (!Meta.DrawStateIsDone) return;
            DataRow R = DS.casualcontract.Rows[0];
            DataRow RImp = DS.casualcontractyear.Rows[0];
            if (R["!codiceritenutainps"] == DBNull.Value) return;
            object idemenscontractkind;
            if (Meta.DrawStateIsDone)
                idemenscontractkind = SubEntity_cmbTipoRapporto.SelectedValue;
            else
                idemenscontractkind = RImp["idemenscontractkind"];
            if (idemenscontractkind == null) idemenscontractkind = DBNull.Value;
            if (idemenscontractkind == DBNull.Value) return;

            string filtro = QHS.AppAnd(QHS.CmpEq("idemenscontractkind",
                idemenscontractkind),
                QHS.CmpEq("ayear", R["ycon"]));
            object flagAttivitaObbligatoria = Conn.DO_READ_VALUE("emenscontractkind", filtro,
                "flagactivityrequested");
            bool att_presente = false;
            if (Meta.DrawStateIsDone)
                att_presente = (RImp["activitycode"] != DBNull.Value);
            else
                att_presente = (SubEntity_cmbAttPrevidenzialeINPS.SelectedIndex > 0);
            if (flagAttivitaObbligatoria != null &&
                flagAttivitaObbligatoria.Equals("S") &&
                (att_presente == false)) {
                SubEntity_cmbAttPrevidenzialeINPS.Enabled = true;
                btnAttivitaPrevINPS.Enabled = true;
            }

            bool altrass_presente = false;
            if (Meta.DrawStateIsDone)
                altrass_presente = (RImp["idotherinsurance"] != DBNull.Value);
            else
                altrass_presente = (SubEntity_cmbAltreFormeAssicurative.SelectedIndex > 0);

            string codiceritenutainps = R["!codiceritenutainps"].ToString();
            if ((codiceritenutainps == "07_INPS_M") &&
                (altrass_presente == false)) {
                SubEntity_cmbAltreFormeAssicurative.Enabled = true;
                btnAltreFormeAssicurative.Enabled = true;
            }



        }

        bool to_close = false;

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (to_close) return;
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (DS.casualcontractyear.Rows.Count == 0) {
                show(
                    "Errore nel caricamento dei dati, è necessario chiudere la maschera o caricare altri dati.",
                    "Errore");
                to_close = true;
            }
            DataRow Curr = DS.casualcontract.Rows[0];
            switch (T.TableName) {                
                case "sortingview1": {
                    if (R == null) return;
                    if (Meta.IsEmpty) return;
                    selezionaVoceSpesaDalia(R["idsor"]);
                    return;
                }
                case "service": {
                    // Chiamo i 2 metodi solo se cambia la prestazione
                    if (R == null) {
                        AzzeraTxtCalcolati();
                        btnAltreFormeAssicurative.Enabled = true;
                        SubEntity_cmbAltreFormeAssicurative.Enabled = true;
                        SubEntity_cmbAltreFormeAssicurative.SelectedIndex = 0;
                        btnVoceSpesaDalia.Visible = false;
                        return;
                    }
                    abilitaDisabilitaDalia(R);
                    abilitaDisabilitaCCdedicato(R);
                    if (R["codeser"].Equals("07_OCC_P") || R["codeser"].Equals("OCCNIRAPEN")) {
                        btnAltreFormeAssicurative.Enabled = false;
                        SubEntity_cmbAltreFormeAssicurative.Enabled = false;
                        SubEntity_cmbAltreFormeAssicurative.SelectedValue = "002";
                    }
                    else {
                        if (R["servicecode770"].Equals("07_OCC_M") || R["servicecode770"].Equals("OCCMUTUATI")) {
                        if (SubEntity_cmbAltreFormeAssicurative.Enabled == false)
                                SubEntity_cmbAltreFormeAssicurative.SelectedIndex = -1;
                            btnAltreFormeAssicurative.Enabled = true;
                            SubEntity_cmbAltreFormeAssicurative.Enabled = true;

                        }
                        else {
                            btnAltreFormeAssicurative.Enabled = false;
                            SubEntity_cmbAltreFormeAssicurative.Enabled = false;
                            SubEntity_cmbAltreFormeAssicurative.SelectedIndex = -1;
                        }
                    }
                    object codPrest = R["idser"];
                    if (Meta.DrawStateIsDone) {
                        if (!Meta.FirstFillForThisRow) {
                            RicalcolaPrestazione(true);
                        }
                    }
                    AbilitaBtnComboOveNecessario(R);
                    break;
                }

                case "pccdebitstatus": {
                    if (!Meta.DrawStateIsDone)
                        return;
                    if (Meta.IsEmpty)
                        return;
                    if (R == null) {
                        //rdbSpesaCorrente.Checked = false;
                        //rdbContoCapitale.Checked = false;
                        rdbSpesaCorrente.Enabled = false;
                        rdbContoCapitale.Enabled = false;
                        return;
                    }
                    else {
                        //Gestione Casuale
                        if (Curr["idpccdebitstatus"].ToString() != R["idpccdebitstatus"].ToString()) {
                            txtCausale.Text = "";
                            Curr["idpccdebitmotive"] = DBNull.Value;
                        }
                        // Gestione Natura di Spesa
                        object statodeldebito = DBNull.Value;
                        if (cmbStatodelDebito.SelectedIndex > 0)
                            statodeldebito = cmbStatodelDebito.SelectedValue;

                        List<string> stati_con_natura = new List<string>(
                            new string[] {"LIQ", "LIQdaSOSP", "LIQdaNL", "SOSPdaLIQ", "NLdaLIQ"});
                        if (stati_con_natura.Contains(statodeldebito.ToString())) {
                            rdbSpesaCorrente.Enabled = true;
                            rdbContoCapitale.Enabled = true;
                        }
                        else {
                            //rdbSpesaCorrente.Checked = false;
                            //rdbContoCapitale.Checked = false;
                            rdbSpesaCorrente.Enabled = false;
                            rdbContoCapitale.Enabled = false;
                            //Curr["expensekind"] = DBNull.Value;
                        }
                    }
                    break;
                }


                case "registry": {
                    if (R == null) return;
                    bool scegliDalia = false;
                    int codcred = CfgFn.GetNoNullInt32(R["idreg"]);
                    if (codcred == 0) return;
                    if (lastCreditore != codcred) {
                        lastCreditore = codcred;
                        RicalcolaPrestazione(true);
                        if (DaliaAbilitato) {
                            scegliDalia = true;
                        }

                        Curr["idaccmotivedebit"] = R["idaccmotivedebit"];
                        DS.accmotiveapplied_debit.Clear();
                        Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
                                (q.eq("idaccmotive", Curr["idaccmotivedebit"]) & q.eq("idepoperation", "prestocc_deb")).toSql(QHS),null,false);
                        Meta.helpForm.FillControls(gBoxCausaleDebito.Controls);

                    }
                    // Se cambia l'anagrafica imposta il valore di default X
                    Curr["authneeded"] = "X";
                    rdbNonApplicabile.Checked = true;
                    if (scegliDalia) {
                        selezionaQualificaDalia(true);
                    }
                    break;
                }

                case "emenscontractkind": {
                    DS.casualcontractyear.Rows[0]["idemenscontractkind"] = (R == null)
                        ? DBNull.Value
                        : R["idemenscontractkind"];
                    if (R == null) return;

                    if (!Meta.FirstFillForThisRow) {
                        bool datoSelezionatoNonValido = (R["module"] == DBNull.Value)
                                                        ||
                                                        (R["module"].ToString()
                                                            .IndexOf("O", 0, R["module"].ToString().Length) == -1);
                        if (datoSelezionatoNonValido) {
                            DS.casualcontractyear.Rows[0]["idemenscontractkind"] = DBNull.Value;
                        }
                    }

                    // Caso 1: Il rapporto ha il flag attività obbligatorio
                    // abilito combo e il bottone dell'attività
                    if (R["flagactivityrequested"].ToString().ToUpper() == "S") {
                        btnAttivitaPrevINPS.Enabled = true;
                        SubEntity_cmbAttPrevidenzialeINPS.Enabled = true;
                    }
                    else {
                        // Caso 2: Il rapporto non ha il flag attività obbligatorio
                        // solo se non sono in fase di caricamento del form disabilito il combo di sotto
                        // e scelgo come elemento del combo quello vuoto
                        if (!Meta.FirstFillForThisRow) {
                            btnAttivitaPrevINPS.Enabled = false;
                            SubEntity_cmbAttPrevidenzialeINPS.Enabled = false;
                            SubEntity_cmbAttPrevidenzialeINPS.SelectedIndex = -1;
                        }
                    }
                    break;
                }

                case "inpsactivity": {
                    DS.casualcontractyear.Rows[0]["activitycode"] = (R == null) ? DBNull.Value : R["activitycode"];
                    break;
                }

                case "otherinsurance": {
                    DS.casualcontractyear.Rows[0]["idotherinsurance"] = (R == null)
                        ? DBNull.Value
                        : R["idotherinsurance"];
                    break;
                }

                case "taxratebracket": {
                    if (Meta.FirstFillForThisRow) return;
                    if (!Meta.DrawStateIsDone) return;
                    string applicaAliquotaMarginale =
                        DS.casualcontractyear.Rows[0]["flaghigherrate"].ToString().ToUpper();
                    if (applicaAliquotaMarginale == "N") {
                        lastAliquotaMarginale = 0;
                        return;
                    }

                    decimal currAliquotaMarginale = (R == null) ? 0 : CfgFn.GetNoNullDecimal(R["employrate"]);
                    if (currAliquotaMarginale != lastAliquotaMarginale) {
                        lastAliquotaMarginale = currAliquotaMarginale;
                        RicalcolaPrestazione(false);
                    }
                    break;
                }
            case "accmotiveapplied_cost": {
                        SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                        SiopeObj.selectSiope();
                        break;
                }
            }
        }


        public void MostraNascondiAutorizzazione() {
            if (DS.casualcontract.Rows.Count == 0) {
                grpBoxDocAutorizzattivo.Visible = false;
                ;
            }
            if (Meta.IsEmpty) return;
            if (rdbNecessitaAutorizzazione.Checked) {
                grpBoxDocAutorizzattivo.Visible = true;
            }
            else {
                grpBoxDocAutorizzattivo.Visible = false;
                ;
            }
        }

        public void MostraNascondiMotivazione() {
            if (DS.casualcontract.Rows.Count == 0) {
                grpBoxMotivo.Visible = false;
                ;
            }
            if (Meta.IsEmpty) return;
            if (rdbAutorizzazioneNonNecessaria.Checked) {
                grpBoxMotivo.Visible = true;
            }
            else {
                grpBoxMotivo.Visible = false;
                ;
            }
        }

        public void MetaData_AfterFill() {
            if (to_close) {
                //Close();
                return;
            }
            EPM.mostraEtichette();
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = false;
            AggiornaVoceSpesa();
            if (EPM.esistonoScrittureCollegate()) {
                txtDateCompleted.ReadOnly = true;
            }
            else {
                txtDateCompleted.ReadOnly = false;
            }
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
            lblDateCompleted.Visible = txtDateCompleted.Visible;

            txtEsercizio.ReadOnly = true;
            if (Meta.IsEmpty) return;
            if (Meta.FirstFillForThisRow) {
                RicalcolaPrestazione(true);
                impostaComboTipoRapporto();
                impostaComboAttPrevINPS();
                gestisciCmbAliquotaFiscale();
                if (Meta.InsertMode || Meta.EditMode) {
                    abilitaDisabilitaCmbAltraFormaAss();
                }
            }
            else {
                RicalcolaPrestazione(false);
            }
            // if (Meta.InsertMode) {
            // Se ci sono solo 2 righe vuol dire che è stata caricata solo una riga da emenstiporapporto
            // mentre l'altra rappresenta la riga vuota aggiunta dal CacheTable.
            if ((SubEntity_cmbTipoRapporto.Items != null) && (SubEntity_cmbTipoRapporto.Items.Count == 2)) {
                SubEntity_cmbTipoRapporto.SelectedIndex = 1;
                SubEntity_cmbTipoRapporto.Enabled = false;
                btnTipoRapporto.Enabled = false;
            }
            // }


            if (Meta.EditMode) {
                btnTrasfoccasionali.Enabled = true;
                btnTrasfoccasionali.Visible = true;
            }



            // aggiornaTotali viene sempre chiamato

            // aggiornaRitenute viene chiamato solo se siamo in fill successivi al primo
            if (!Meta.FirstFillForThisRow) {
                aggiornaRitenute();
            }
            else {
                btnRicalcola.Enabled = true;
            }

            // Se non esiste l'indirizzo AP, sarà obbligatorio lasciare impostato il valore di default che sarà X, ossia non applicabile.
            if (!EsisteIndirizzoAP()) {
                grpBoxAutorizzazioneAP.Enabled = false;
            }
            else {
                // se esiste l'indirizzo AP va selezionata l'autorizzazione come S o come N:
                grpBoxAutorizzazioneAP.Enabled = true;
            }
            MostraNascondiAutorizzazione();
            MostraNascondiMotivazione();

            if (Meta.FirstFillForThisRow && Meta.EditMode) {
                VisualizzaEtichetteAP();
            }
            if ((!Meta.IsEmpty) && (Meta.FirstFillForThisRow)) {
                grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') and (human='S'))";
                Meta.SetAutoMode(grpPercipiente);
            }

            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
                RicalcolaPrestazione(true);
                Meta.GetFormData(true);
                abilitaDisabilitaCCdedicato(null);
            }

            if (Meta.InsertMode) {
                if (Meta.FirstFillForThisRow) {
                    DS.uniqueregister.Clear();
                }
                VisualizzaNumeroRegistroUnico();
            }

            if (Meta.EditMode) {
                VisualizzaNumeroRegistroUnico();
            }

            if (Meta.FirstFillForThisRow) {
                AbilitaDisabilitaRegistroUnico();
            }

            txtProgressivoRU.ReadOnly = true;
            if (Meta.FirstFillForThisRow && Meta.EditMode) {
                DataRow Curr = DS.casualcontract.Rows[0];
                if (Curr["idpccdebitmotive"] != DBNull.Value) {
                    txtCausale.Text =
                        DS.pccdebitmotive.Select(QHC.CmpEq("idpccdebitmotive", Curr["idpccdebitmotive"]))[0][
                            "description"].ToString();
                }
            }
            DataRow curr = DS.casualcontract.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive"]);
        }

       

        string concat(object[] par) {
            string res = "";
            foreach (object O in par) res = res + O.ToString() + "|";
            return res;
        }


        private bool DaliaAbilitato = false;
        private void abilitaDisabilitaDalia(DataRow service) {
            DaliaAbilitato = false;
            if (Meta.PrimaryDataTable.Rows.Count == 0 ||  idsorkindDalia == null || idsorkindDalia == DBNull.Value) {
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

        private void abilitaDisabilitaCCdedicato(DataRow rService) {
            if ((rService == null) && (DS.casualcontract.Rows.Count == 0)) {
                chkCCdedicato.Enabled = true;
                return;
            }
            if ((rService == null) && (DS.casualcontract.Rows.Count > 0)) {
                DataRow Curr = DS.casualcontract.Rows[0];
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

        /// <summary>
        ///  Metodo che abilita/disabilita il combo CmbAltraFormaAss
        /// </summary>
        private void abilitaDisabilitaCmbAltraFormaAss() {
            if (DS.casualcontract.Rows.Count == 0) return;
            DataRow Curr = DS.casualcontract.Rows[0];
            DataRow[] Service = DS.service.Select(QHS.CmpEq("idser", Curr["idser"]));
            if (Service.Length == 0) return;
            object codeSer = Service[0]["codeser"];
            if (codeSer == DBNull.Value) return;
            if ((codeSer.ToString().ToUpper() == "07_OCC_N") ||
                (codeSer.ToString().ToUpper() == "OCCNONMUT")) {
                btnAltreFormeAssicurative.Enabled = false;
                SubEntity_cmbAltreFormeAssicurative.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo che gestisce il combo dell'aliquota fiscale
        /// </summary>
        private void gestisciCmbAliquotaFiscale() {
            if (DS.casualcontract.Rows.Count == 0) return;

            DataRow Curr = DS.casualcontract.Rows[0];
            DataRow CurrYear = DS.casualcontractyear.Rows[0];
            DS.taxratebracket.Clear();
            /*
            string query1 = "SELECT TOP 1 taxratestart.taxcode, taxratestart.idtaxratestart," +
                "taxratestart.start "
				+ " FROM tax JOIN taxratestart"
                + " ON (tax.taxcode = taxratestart.taxcode)"
				+ " WHERE " + QHS.AppAnd(QHS.CmpEq("tax.taxkind",1), QHS.CmpEq("tax.active", 'S'),
                QHS.IsNull("tax.geoappliance"), QHS.CmpLe("taxratestart.start", Curr["adate"]))
                + " ORDER BY taxratestart.start DESC";

			DataTable dtRitenuta = Meta.Conn.SQLRunner(query1);
            string filtro = QHS.IsNull("taxcode");
            if (dtRitenuta.Rows.Count > 0) {
                DataRow R= dtRitenuta.Rows[0];
                filtro = QHS.AppAnd(QHS.CmpEq("taxcode", R["taxcode"]),
                    QHS.CmpEq("idtaxratestart", R["idtaxratestart"]));
            }
            */
            object datadaconsiderare = (DateTime) Conn.GetSys("datacontabile");

            string query2 =
                "select distinct employrate FROM taxratebracket TB  " +
                "join taxratestart  on TB.taxcode=taxratestart.taxcode and TB.idtaxratestart=taxratestart.idtaxratestart " +
                "join tax  on tax.taxcode=taxratestart.taxcode " +
                " WHERE " +
                QHS.AppAnd(QHS.CmpEq("tax.taxkind", 1), QHS.CmpEq("tax.active", 'S'),
                    QHS.IsNull("tax.geoappliance"), QHS.CmpLe("taxratestart.start", datadaconsiderare),
                    QHS.CmpGt("employrate", 0)) +
                " AND taxratestart.idtaxratestart= (SELECT MAX(TT.idtaxratestart) from taxratestart TT where  " +
                " TT.start=taxratestart.start)" +
                " AND taxratestart.start = (SELECT MAX(TT2.start) from taxratestart TT2  where " +
                QHS.AppAnd("(TT2.taxcode=TB.taxcode)",
                    QHS.CmpLe("taxratestart.start", datadaconsiderare))
                + ")";

            ;


            if (CurrYear["higherrate"] != DBNull.Value) {
                query2 += " UNION SELECT " + QueryCreator.unquotedstrvalue(CurrYear["higherrate"], true)
                          + " AS employrate";
            }
            query2 += " ORDER BY employrate";
            DataTable aliquoteFinali = Meta.Conn.SQLRunner(query2);

            object taxcode = Meta.Conn.DO_READ_VALUE("tax", QHS.CmpEq("taxref", "07_ACC_FISC"), "taxcode");

            GetData.Add_Blank_Row(DS.taxratebracket);
            int numeroAliquote = 1;
            foreach (DataRow R in aliquoteFinali.Rows) {
                DataRow arRow = DS.taxratebracket.NewRow();
                arRow["idtaxratestart"] = 1;
                arRow["taxcode"] = taxcode;
                arRow["employrate"] = R["employrate"];
                arRow["nbracket"] = numeroAliquote;
                arRow["lu"] = "-";
                arRow["lt"] = Meta.GetSys("datacontabile");
                DS.taxratebracket.Rows.Add(arRow);
                numeroAliquote++;
            }
            DS.taxratebracket.AcceptChanges();

            Meta.myHelpForm.FilteredPreFillCombo(SubEntity_cmbAliquotaFiscale, null, false);

            if (CurrYear["higherrate"] == DBNull.Value) return;

            decimal aliquota = (decimal) CurrYear["higherrate"];
            try {
                SubEntity_cmbAliquotaFiscale.SelectedValue = aliquota;
            }
            catch {
            }
        }

        /// <summary>
        /// Metodo che azzera le variabili di confronto
        /// </summary>
        private void azzeraVardiConfronto() {
            lastCreditore = 0;
            lastCompensoLordo = 0;
            lastImponibiliAltriContratti = 0;
            lastImponibiliAltriEnti = 0;
            lastAliquotaMarginale = 0;
        }

        /// <summary>
        /// Metodo che calcola la durata in giorni della prestazione occasionale
        /// </summary>
        private void calcolaDurataGiorni() {
            object inizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizio.Text,
                txtDataInizio.Tag.ToString());
            object fine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFine.Text, txtDataFine.Tag.ToString());
            if ((inizio is DateTime) && (fine is DateTime)) {
                DateTime dataInizio = (DateTime) inizio;
                DateTime dataFine = (DateTime) fine;
                int ngiorni = (dataFine - dataInizio).Days + 1;
                txtDurataGiorni.Text = ngiorni.ToString();
            }
        }

        decimal CostoTotalePagatoAnniPrecedenti = 0;
        decimal CostoTotalePagato = 0;

        private decimal calcolaCostoTotale(decimal lordoAlBeneficiario) {
            decimal lordodaconsiderare = lordoAlBeneficiario - mycalc.CompensoLordoPagato;
            if (lordodaconsiderare < 0) lordodaconsiderare = 0;
            DataTable riten = CalcolaRitenute(lordodaconsiderare);
            decimal costoTotale = lordodaconsiderare + mycalc.CompensoLordoPagato + getContributiPagati();
            if ((riten == null) || (riten.Rows.Count == 0)) {
                return costoTotale;
            }
            foreach (DataRow R in riten.Rows) {
                costoTotale += CfgFn.GetNoNullDecimal(R["admintax"]);
            }

            return costoTotale;
        }

        private decimal daCostoTotaleAlLordoAlBeneficiario(decimal costoTotale, out bool calcoloRiuscito) {
            calcoloRiuscito = false;
            decimal a = mycalc.CompensoLordoPagato;
            decimal b = costoTotale;

            decimal costoTotaleA = calcolaCostoTotale(a);
            decimal costoTotaleB = calcolaCostoTotale(b);
            decimal imponibileProva = -1;
            while ((a < b) && (costoTotaleA != costoTotaleB)) {
                imponibileProva = CfgFn.RoundValuta(
                    ((costoTotale - costoTotaleA)/(costoTotaleB - costoTotaleA))*(b - a) + a);
                decimal costoTotaleProva = CfgFn.RoundValuta(calcolaCostoTotale(imponibileProva));
                if (costoTotaleProva == costoTotale) {
                    calcoloRiuscito = true;
                    return imponibileProva;
                }
                if ((costoTotaleProva > costoTotale) && (costoTotaleProva != costoTotaleB)) {
                    costoTotaleB = costoTotaleProva;
                    b = imponibileProva;
                    continue;
                }
                if ((costoTotaleProva < costoTotale) && (costoTotaleProva != costoTotaleA)) {
                    costoTotaleA = costoTotaleProva;
                    a = imponibileProva;
                    continue;
                }
                return imponibileProva;
            }
            decimal costoTotaleTrovato = CfgFn.RoundValuta(calcolaCostoTotale(imponibileProva));
            if (costoTotaleTrovato == costoTotale) {
                calcoloRiuscito = true;
            }
            else {
                imponibileProva = mycalc.CompensoLordoPagato;
            }
            return imponibileProva;
        }

        #region Eventi degli oggetti

        // Oggetti presenti nel tab PRINCIPALE
        private void txtNumContratto_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (!Meta.InsertMode) return;
            DataRow Curr = DS.casualcontract.Rows[0];
            object numContratto = HelpForm.GetObjectFromString(typeof(int), txtNumContratto.Text,
                txtNumContratto.Tag.ToString());
            if (numContratto == null) return;
            if (CfgFn.GetNoNullInt32(Curr["ncon"]) != (int) numContratto) {
                Meta.GetFormData(true);
                DS.casualcontractyear.Rows[0]["ncon"] = numContratto;
            }
        }

        private void txtDataInizio_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
        }


        private void txtDataFine_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
        }



        private void txtLordoAlBeneficiario_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            if (mycalc == null) return;
            object currentfeegross = DS.casualcontract.Rows[0]["feegross"];
            decimal compensoLordo = decimalDaTextBox(txtLordoAlBeneficiario);

            decimal lordopagato = mycalc.CompensoLordoPagato;
            if (compensoLordo < lordopagato) {
                string messaggio = "Attenzione! Il compenso loro non può essere inferiore al compenso lordo pagato " +
                                   "\nCosto Lordo Inserito : € " + compensoLordo +
                                   "\nCompenso Lordo Pagato: €" + lordopagato;
                show(this, messaggio);
                txtLordoAlBeneficiario.Text = currentfeegross.ToString();
                return;
            }
            if (lastCompensoLordo != compensoLordo) {
                lastCompensoLordo = compensoLordo;
                Meta.GetFormData(true);
                RicalcolaPrestazione(false);
                aggiornaRitenute();
            }
        }

        private void txtCostoTotaleInput_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;


            decimal costoTotale = CfgFn.RoundValuta(decimalDaTextBox(txtCostoTotaleInput));
            bool calcoloRiuscito;
            decimal imponibileContratto = daCostoTotaleAlLordoAlBeneficiario(costoTotale, out calcoloRiuscito);
            decimal costoTotaleTrovato = CfgFn.RoundValuta(calcolaCostoTotale(imponibileContratto));

            if (!calcoloRiuscito) {
                txtCostoTotaleInput.Text = costoTotaleTrovato.ToString("c");
                string messaggio = "Attenzione!, in base al costo totale inserito non è stato possibile calcolare " +
                                   "precisamente il compenso lordo al beneficiario, quindi verrà inserito il valore più vicino" +
                                   "\n Costo Totale Inserito:" + costoTotale +
                                   "\n Compenso Lordo al Beneficiario calcolato: " + imponibileContratto;
                show(this, messaggio);
            }

            txtLordoAlBeneficiario.Text = imponibileContratto.ToString("c");
            lastCompensoLordo = CfgFn.GetNoNullDecimal(imponibileContratto);
            Meta.GetFormData(true);
            RicalcolaPrestazione(false);
            aggiornaRitenute();
        }

        // Oggetti presenti nel tab IMPONIBILI
        private void txtImpAltriEnti_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            decimal imponibiliAltriEnti = decimalDaTextBox(SubEntity_txtImpAltriEnti);
            if (lastImponibiliAltriEnti != imponibiliAltriEnti) {
                lastImponibiliAltriEnti = imponibiliAltriEnti;
                Meta.GetFormData(true);
                RicalcolaPrestazione(false);
                aggiornaRitenute();
            }
        }

        private void txtImpAltriContratti_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) return;
            decimal imponibiliAltriContratti = decimalDaTextBox(txtImpAltriContratti);
            if (lastImponibiliAltriContratti != imponibiliAltriContratti) {
                lastImponibiliAltriContratti = imponibiliAltriContratti;
                Meta.GetFormData(true);
                RicalcolaPrestazione(false);
                aggiornaRitenute();
            }
        }

        private void rdoAliquotaMarginale_CheckedChanged(object sender, System.EventArgs e) {
            SubEntity_cmbAliquotaFiscale.Enabled = SubEntity_rdoAliquotaMarginale.Checked;
            if (!Meta.DrawStateIsDone) return;
            if (!SubEntity_rdoAliquotaMarginale.Checked) {
                SubEntity_cmbAliquotaFiscale.SelectedIndex = 0;
                lastAliquotaMarginale = 0;
            }

            Meta.GetFormData(true);
            if (!Meta.IsEmpty) {
                RicalcolaPrestazione(false);
                aggiornaRitenute();
            }

        }

        #endregion

        #region Metodi per la conversione dei dati

        /// <summary>
        /// Metodo che, ricevuto un text box, converte il valore presente in esso in decimal
        /// </summary>
        /// <param name="textbox">Text Box nel quale è presente il valore da convertire</param>
        /// <returns>Valore presente nel text box convertito in decimal</returns>
        private decimal decimalDaTextBox(TextBox textbox) {
            return CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), textbox.Text, "x.y"));
        }

        /// <summary>
        /// Metodo che calcola il rapporto tra numeratore e denominatore
        /// </summary>
        /// <param name="quotanum">Numeratore</param>
        /// <param name="quotaden">Denominatore</param>
        /// <returns>Rapporto tra numeratore e denominatore</returns>
        private decimal rapporto(object quotanum, object quotaden) {
            decimal num = CfgFn.GetNoNullDecimal(quotanum);
            decimal den = CfgFn.GetNoNullDecimal(quotaden);
            if (den == 0) {
                return 1;
            }
            return num/den;
        }

        /// <summary>
        /// Metodo che calcola l'aliquota della ritenuta c/amministrazione, tenendo conto della formula
        /// Aliquota Amm = Frazione Imponibile * Frazione Amministrazione * Aliquota Amm
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        private decimal getAliquotaAmministrazione(DataRow r) {
            decimal frazioneImponibile = rapporto(r["taxablenumerator"], r["taxabledenominator"]);
            decimal frazioneAmministrazione = rapporto(r["adminnumerator"], r["admindenominator"]);
            decimal aliquotaAmmnistrazione = CfgFn.GetNoNullDecimal(r["adminrate"]);
            return frazioneImponibile*frazioneAmministrazione*aliquotaAmmnistrazione;
        }

        #endregion

        #region Gestione Combo Tipo Rapporto

        void ClearComboTipoRapporto() {
            ((DataTable) SubEntity_cmbTipoRapporto.DataSource).Clear();
        }

        private void impostaComboTipoRapporto() {
            bool enableold = true;
            string filterTipoRapporto;
            string oldcode = null;
            if (SubEntity_cmbTipoRapporto.SelectedValue != null)
                oldcode = SubEntity_cmbTipoRapporto.SelectedValue.ToString();
            if ((oldcode == null) || (oldcode.ToString() == "")) enableold = false;

            //prende i tipi rapporto compatibili con il modulo OCCASIONALI in base alla tabella
            DataTable emensTipoRapporto = Meta.Conn.RUN_SELECT("emenscontractkind", "*", null,
                QHS.AppAnd(QHS.Like("module", "%O%"),
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                    QHS.DoPar(QHS.AppOr(QHS.IsNull("active"), QHS.CmpEq("active", "S")))
                    ),
                null, null, true);

            if (emensTipoRapporto.Rows.Count == 0) {
                // Caso 1: non ci sono rapporti compatibili con il modulo OCCASIONALI
                // Si controlla se è stato scelto un rapporto in precedenza.
                // Se si appare il messaggio che il rapporto non è più compatibile con il modulo
                // Altrimenti viene svuotato il combo box
                if (enableold) {
                    filterTipoRapporto = QHS.CmpEq("idemenscontractkind", oldcode);
                    show(this,
                        "Attenzione: il tipo rapporto selezionato non è coerente con il modulo OCCASIONALI");
                }
                else {
                    ClearComboTipoRapporto();
                    return;
                }
            }
            else {
                // Caso 2: ci sono rapporti compatibili con il modulo OCCASIONALI
                // Si costruisce il filtro su tipoRapporto tenendo conto della prestazione precedentemente scelta
                filterTipoRapporto = QHS.AppAnd(QHS.Like("module", "%O%"),
                    QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                    QHS.DoPar(QHS.AppOr(QHS.IsNull("active"), QHS.CmpEq("active", "S")))
                    );
                bool rapportoSceltoIsOld =
                    (emensTipoRapporto.Select(QHC.CmpEq("idemenscontractkind", oldcode)).Length == 0);
                if (enableold && rapportoSceltoIsOld) {
                    show(this,
                        "Attenzione: il tipo rapporto EMENS selezionato non è coerente con il modulo OCCASIONALI");
                }
                if (enableold)
                    filterTipoRapporto = QHS.AppOr(filterTipoRapporto,
                        QHS.DoPar(QHS.AppAnd(QHS.CmpEq("idemenscontractkind", oldcode),
                            QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                            QHS.DoPar(QHS.AppOr(QHS.IsNull("active"), QHS.CmpEq("active", "S")))))
                        );
            }

            //Imposta combo prestazione filtrata
            Meta.myHelpForm.DisableAutoEvents();
            SubEntity_cmbTipoRapporto.BeginUpdate();
            QueryCreator.MyClear(((DataTable) SubEntity_cmbTipoRapporto.DataSource));
            GetData.Add_Blank_Row(((DataTable) SubEntity_cmbTipoRapporto.DataSource));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, ((DataTable) SubEntity_cmbTipoRapporto.DataSource),
                "description",
                filterTipoRapporto, null, true);
            HelpForm.SetComboBoxValue(SubEntity_cmbTipoRapporto, oldcode);
            SubEntity_cmbTipoRapporto.EndUpdate();
            Meta.myHelpForm.EnableAutoEvents();
        }

        #endregion

        #region Gestione Combo Attività Previdenziale INPS

        void ClearComboAttPrevINPS() {
            ((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource).Clear();
        }

        private void impostaComboAttPrevINPS() {
            bool enableold = true;
            string filterAttPrevINPS = "";
            string oldcode = null;
            if (SubEntity_cmbAttPrevidenzialeINPS.SelectedValue != null)
                oldcode = SubEntity_cmbAttPrevidenzialeINPS.SelectedValue.ToString();
            if ((oldcode == null) || (oldcode.ToString() == "")) enableold = false;

            //Filtro i rapporti che hanno il codice attività obbligatorio
            string filtro = QHC.AppAnd(QHC.CmpEq("flagactivityrequested", "S"), QHC.Like("module", "%O%"));
            DataRow[] emensRow = DS.emenscontractkind.Select(filtro);

            if (emensRow.Length == 0) {
                // Caso 1: I rapporti selezionati non hanno l'obbligatorietà del codice attività
                // Si controlla se è stata scelta un'attività in precedenza.
                // Se si appare il messaggio che l'attività non è più compatibile con i rapporti
                // Altrimenti viene svuotato il combo box
                if (enableold) {
                    filterAttPrevINPS = QHS.AppAnd(QHS.CmpEq("idemenscontractkind", oldcode),
                        QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
                    show(this,
                        "Attenzione: l'attività previdenziale INPS scelta non è coerente con il rapporto scelto");
                }
                else {
                    ClearComboAttPrevINPS();
                    if (((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource).Rows.Count == 0) {
                        SubEntity_cmbAttPrevidenzialeINPS.Enabled = false;
                        btnAttivitaPrevINPS.Enabled = false;
                    }
                    return;
                }
            }
            else {
                // Caso 2: I rapporti selezionati hanno l'obbligatorietà del codice attività
                // Si costruisce il filtro su tipoRapporto tenendo conto della prestazione precedentemente scelta
                filterAttPrevINPS = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            }

            //Imposta combo prestazione filtrata
            Meta.myHelpForm.DisableAutoEvents();
            SubEntity_cmbAttPrevidenzialeINPS.BeginUpdate();
            QueryCreator.MyClear(((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource));
            GetData.Add_Blank_Row(((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, ((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource),
                "description",
                filterAttPrevINPS, null, true);
            HelpForm.SetComboBoxValue(SubEntity_cmbAttPrevidenzialeINPS, oldcode);
            SubEntity_cmbAttPrevidenzialeINPS.EndUpdate();
            Meta.myHelpForm.EnableAutoEvents();
            // Se DS.attivitaprevidenzialeinps ha una sola riga essa è quella vuota (GetData.Add_Blank_Row)
            // e quindi può essere disabilitato
            if (((DataTable) SubEntity_cmbAttPrevidenzialeINPS.DataSource).Rows.Count == 1) {
                SubEntity_cmbAttPrevidenzialeINPS.Enabled = false;
                btnAttivitaPrevINPS.Enabled = false;
            }
        }

        #endregion






        void AvvisoAnagrafePrestazioni() {
            if (!Meta.EditMode) return;
            //if (!Meta.FirstFillForThisRow) return;
            if (Meta.Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("yservreg", Meta.GetSys("esercizio")), false) ==
                0) return;
            //VisualizzaEtichetteAP();
            if (btnGeneraAP.Visible) {
                show("Ricordarsi di compilare la scheda Anagrafe prestazioni");
            }
        }


        public void MetaData_AfterPost() {
            if (filterDeleteImputazione != "") {
                string script = "delete from casualcontractyear where  "
                                + filterDeleteImputazione;
                Meta.Conn.SQLRunner(script);
                filterDeleteImputazione = "";
            }

            EPM.afterPost();
            if (DS.casualcontract.Rows.Count > 0 && EPM.UsaImpegniDiBudget) {
                DataRow curr = DS.casualcontract.Rows[0];
                if (curr.RowState == DataRowState.Unchanged && EPM.impegniAbilitati(curr)) {
                    int nEpExp = Conn.RUN_SELECT_COUNT("epexp",
                        QHS.CmpEq("idrelated", $"cascon§{curr["ycon"]}§{curr["ncon"]}"), false);

                    if ((nEpExp == 0)&&(mycalc.CompensoLordoPagato == 0)) 
                    {
                        curr["completed"] = "N";
                        Meta.FreshForm();
                        Meta.SaveFormData();
                        show(this, 
                            "Non avendo generato gli impegni di budget, è stato rimosso il flag 'Considera eseguito quindi pagabile'",
                            "Avviso");
                    }
                }
            }
        
        /**
         %<casualcontract.completed>%='N' 

or
(
exists (select * from epexp where idrelated=
'cascon§'+convert(varchar(30),%<casualcontract.ycon>%)+'§'+convert(varchar(30),%<casualcontract.ncon>%)
)
)

or 
[select flagepexp from config where ayear=%<sys_esercizio>%]{C}='N'


         */
        if (Meta.PrimaryDataTable.Rows.Count > 0) {
                VisualizzaEtichetteAP();
                AvvisoAnagrafePrestazioni();
            }
            VisualizzaNumeroRegistroUnico();
            //Cancella riga imputazione di altri esercizi
          
        }





        void VisualizzaEtichetteAP() {
            if (DS.casualcontract.Rows.Count > 0 && (DS.casualcontract.Rows[0].RowState == DataRowState.Unchanged)) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = true;
                btnCollegaAP.Visible = true;
            }
            else {
                if (Meta.InsertMode || DS.casualcontract.Rows.Count == 0) // || DS.entrysetup.Rows.Count==0)
                {
                    labAPnongenerato.Visible = false;
                    labAPgenerato.Visible = false;
                    btnVisualizzaAP.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                    return;
                }
            }

            string idrelated = AP_fun.GetIdForDocument(DS.casualcontract.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("serviceregistry",
                QHS.CmpEq("idrelated", idrelated), true) == 0) {

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

            }
            else {
                labAPnongenerato.Visible = false;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = false;
                btnCollegaAP.Visible = false;
            }

        }

        private bool EsisteIndirizzoAP() {
            DataRow curr = DS.casualcontract.Rows[0];
            String codeaddress = "07_SW_ANP";

            if (curr["start"] == DBNull.Value) return false;

            DateTime DataInizio = (DateTime) curr["start"];
            if (DataInizio.Year < 1900) DataInizio = new DateTime(1900, 1, 1);
            object idaddresskind = Meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DataTable Address = DataAccess.RUN_SELECT(Conn, "registryaddress", "*", null,
                QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("idreg", curr["idreg"]),
                    QHS.CmpLe("start", DataInizio), QHS.NullOrGe("stop", DataInizio)), false);

            if (Address.Rows.Count > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        private void btnGeneraAP_Click(object sender, System.EventArgs e) {
            GeneraScrittureAP();
        }

        void GeneraScrittureAP() {
            if (DS.casualcontract.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.casualcontract.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(Meta.Dispatcher);
            if (!AP.attivo) return;
            AP.GetEntryForDocument(Curr);

            if (AP.MainSrvRegExists()) {
                show(this, "L'Anagrafe Prestazione è stata già generata.",
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
                show(this, "Errore nella assegnazione dei valori di default",
                    "Anagrafe Prestazioni non generata");
                return;
            }

            ToMeta.DoMainCommand("maininsert");
            foreach (DataColumn CC in ToMeta.PrimaryDataTable.Columns) {
                CC.DefaultValue = saveddefaults[CC.ColumnName];
            }
        }

        void EditServiceRegistry() {
            if (DS.casualcontract.Rows.Count == 0) return;
            AP_fun AP = new AP_fun(Meta.Dispatcher);
            AP.EditRelatedServiceRegistry(Meta, DS.casualcontract.Rows[0]);
        }

        private void btnVisualizzaAP_Click(object sender, System.EventArgs e) {
            EditServiceRegistry();
        }

        private void btnRicalcola_Click(object sender, EventArgs e) {
            if (inChiusura) return;
            if (Meta.IsEmpty) {
                show(this, "Sei in modalità ricerca, effettua la ricerca prima di ricalcolare");
                return;
            }
            //if (ContrattoGiaPagato()) return;
            RicalcolaPrestazione(true);
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

        private void rdbNonApplicabile_CheckedChanged(object sender, EventArgs e) {
            if (rdbNonApplicabile.Checked) {
                VisualizzaEtichetteAP();
            }
        }

        private void btnCollegaAP_Click(object sender, EventArgs e) {
            if (DS.casualcontract.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.casualcontract.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(Meta.Dispatcher);
            if (!AP.attivo) return;
            AP.LinkExistingDocument(Meta, Curr, Curr["idreg"]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

        private void btnCreaRegistroUnico_Click(object sender, EventArgs e) {
            DataRow CurrCasualcontract = DS.casualcontract.Rows[0];

            MetaData Uniqueregister = MetaData.GetMetaData(this, "uniqueregister");
            Uniqueregister.SetDefaults(DS.uniqueregister);
            DataRow Runiqueregister = Uniqueregister.Get_New_Row(CurrCasualcontract, DS.uniqueregister);
            btnCreaRegistroUnico.Enabled = false;
        }

        private void btnCasuale_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.casualcontract.Rows[0];
            object idpccdebitstatus = DBNull.Value;

            if (cmbStatodelDebito.SelectedIndex <= 0) {
                show("Selezionare prima lo stato del debito", "Avviso");
                return;
            }

            idpccdebitstatus = cmbStatodelDebito.SelectedValue;
            int maskorder =
                CfgFn.GetNoNullInt32(
                    DS.pccdebitstatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);

            string filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            MetaData MCausali = MetaData.GetMetaData(this, "pccdebitmotive");
            MCausali.FilterLocked = true;
            MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;

            Curr["idpccdebitmotive"] = Choosen["idpccdebitmotive"];
            txtCausale.Text = Choosen["description"].ToString();
        }

        private void chkPagabile_CheckStateChanged(object sender, EventArgs e) {

            if (!Meta.DrawStateIsDone) return;
            txtDateCompleted.Visible = (chkPagabile.CheckState == CheckState.Checked);
            lblDateCompleted.Visible = txtDateCompleted.Visible;

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
                    DS.sortingview.Select(QHC.AppAnd(QHC.CmpEq("idsor", idsor), QHC.CmpEq("idsorkind", idsorkindDalia)));
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
                    DS.sortingview.Select(QHC.AppAnd(QHC.CmpEq("idsor", idsor2), QHC.CmpEq("idsorkind", idsorkindDalia)));
                if (f.Length > 0) {
                    r.Delete();
                }
            }


            MetaData MSor = Meta.Dispatcher.Get(sortingT.TableName);
            DataRow newClass = MSor.Get_New_Row(Curr, sortingT);
            newClass["idsor"] = idsor;
            newClass["quota"] = 1.0;
            Meta.FreshForm(true);

        }

        private void btnVoceSpesaDalia_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            DataTable main = Meta.PrimaryDataTable;
            
            //if (idsorkindDalia == null || idsorkindDalia == DBNull.Value) {
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
                QHS.FieldIn("idsor", classR, "idsor"), QHS.CmpEq("ayear", Conn.GetEsercizio()));
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
                show("Occorre selezionare prima il percipiente", "Avviso");
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
                show("Il percipiente selezionato non ha una qualifica Dalia negli inquadramenti", "Errore");                
                return;
            }
            if (dalia.Length > 0) {
                string filterDalia = QHS.FieldIn("iddaliaposition", dalia);
                Meta.DoMainCommand("choose.dalia_position.default." + filterDalia);
                //Il resto lo fa in automatico essendo dalia_position parent della tabella principale
            }

        }

        private void chkEP_CheckedChanged(object sender, EventArgs e) {
			Meta.DefaultListType = chkEP.Checked? "epdebit":"default";
        }
    }
}
