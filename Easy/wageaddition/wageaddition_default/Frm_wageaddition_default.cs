
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
using System.Data;
using funzioni_configurazione;
using ep_functions;
using ap_functions;
using q = metadatalibrary.MetaExpression;

namespace wageaddition_default //contrattodipendente//
{
    /// <summary>
    /// Summary description for frmcontrattodipendente.
    /// </summary>
    public class Frm_wageaddition_default : MetaDataForm {
        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGenerale;
        private System.Windows.Forms.TabPage tabRitenute;
        private System.Windows.Forms.TextBox txtCostoTotaleInput;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtLordoAlBeneficiario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox grpPrestazione;
        private System.Windows.Forms.Button btnTipoPrestazione;
        private System.Windows.Forms.ComboBox cmbTipoPrestazione;
        private System.Windows.Forms.GroupBox grpPercipiente;
        private System.Windows.Forms.TextBox txtPercipiente;
        private System.Windows.Forms.GroupBox grpContratto;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataFine;
        private System.Windows.Forms.TextBox txtDurataGiorni;
        private System.Windows.Forms.DataGrid dgRitenuta;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCostoTotale;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtRitAssicurativaAmm;
        private System.Windows.Forms.TextBox txtRitAssistenzialeAmm;
        private System.Windows.Forms.TextBox txtRitPrevidenzialeAmm;
        private System.Windows.Forms.TextBox txtRitFiscaleAmm;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtImportoNetto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRitAssistenzialeDip;
        private System.Windows.Forms.TextBox txtRitAssicurativaDip;
        private System.Windows.Forms.TextBox txtRitPrevidenzialeDip;
        private System.Windows.Forms.TextBox txtRitFiscaleDip;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        MetaData Meta;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtImponibileFiscale;
        string flagcalcimpfiscale = "";
        string lastParams = "";
        string currParams = "";
        int lastCreditore = 0;
        int lastPrestazione = 0;
        DateTime lastDataContabile;
        DateTime dataVuota = new DateTime(1900, 1, 1);
        private System.Windows.Forms.TabPage tabClassSuppl;
        private System.Windows.Forms.Button btnClassElimina;
        private System.Windows.Forms.Button btnClassModifica;
        private System.Windows.Forms.DataGrid dgrClassSuppl;
        private System.Windows.Forms.Button btnClassInserisci;
        decimal costoTotaleDaLordoAlBeneficiario = -1;
        decimal imponibileFiscaleDaLordoAlBeneficiario = -1;
        bool inChiusura;
        private System.Windows.Forms.ComboBox cmbQualifica;
        private System.Windows.Forms.ComboBox cmbOrario;
        private System.Windows.Forms.ComboBox cmbDurata;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.Button btnGeneraEP;
        private System.Windows.Forms.Button btnVisualizzaEP;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAnalitico;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        private System.Windows.Forms.TextBox txtDenom3;
        public TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        private System.Windows.Forms.TextBox txtDenom2;
        public TextBox txtCodice2;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        private System.Windows.Forms.TextBox txtDenom1;
        public TextBox txtCodice1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gBoxCausale;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnGeneraEpExp;
        private System.Windows.Forms.Button btnVisualizzaEpExp;
        private System.Windows.Forms.TabPage tabAnagPrest;
        private System.Windows.Forms.Button btnGeneraAP;
        private System.Windows.Forms.Button btnVisualizzaAP;
        private System.Windows.Forms.Label labAPnongenerato;
        private System.Windows.Forms.Label labAPgenerato;
        private Label label9;
        private TextBox textBox8;
        private GroupBox gBoxCausaleDebitoCrg;
        private TextBox textBox9;
        private TextBox txtCodiceCausaleCrg;
        private Button button8;
        private GroupBox gBoxCausaleDebito;
        private TextBox textBox10;
        private TextBox txtCodiceCausaleDeb;
        private Button button21;
        private GroupBox groupBox7;
        private Button btnCambiaRuolo;
        private TextBox txtCompartoCSA;
        private TextBox txtInquadrcsa;
        private Label label10;
        private Label label11;
        private Label lblRuoloCSA;
        private TextBox txtRuoloCSA;
        private GroupBox grpBoxMotivo;
        private TextBox txtMotivoAut;
        private GroupBox grpBoxDocAutorizzattivo;
        private TextBox txtDocumentoAut;
        private Label label23;
        private TextBox txtDataDocumentoAut;
        private Label label24;
        private GroupBox grpBoxAutorizzazioneAP;
        private RadioButton rdbAutorizzazioneNonNecessaria;
        private RadioButton rdbNonApplicabile;
        private RadioButton rdbNecessitaAutorizzazione;
        private Button btnRicalcola;
        private GroupBox groupDebPignoratizio;
        private TextBox txtCredDistraint;
        private TabPage tabAttributi;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
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
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
        private Label labEP;
        private TabPage tabDALIA;
        private GroupBox groupBox8;
        private Label label91;
        private TextBox textBox6;
        private ComboBox cmb_dalia_position;
        private Button btnVoceSpesaDalia;
        private TextBox txtVoceSpesaDalia;
        private Button btnQualificaDalia;
        private GroupBox grpBoxSiopeEP;
        private Button btnSiope;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnTrasfdipendenti;
        private GroupBox grpCausaliAssunzioneDalia;
        private TextBox txtCausaleAssunzione;
        private Button btnEsclusioneCIG;
        private GroupBox groupBox9;
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
		private System.ComponentModel.IContainer components;

        enum ImportoDiPartenza {
            compensoLordo,
            compensoOmnicomprensivo,
            imponibileFiscale
        };

        public Frm_wageaddition_default() {
            inChiusura = false;
            InitializeComponent();
            cmbDaliaFunzionale.DataSource = DS.dalia_funzionale;
            cmbDaliaFunzionale.DisplayMember = "title";
            cmbDaliaFunzionale.ValueMember = "iddalia_funzionale";
			HelpForm.SetDenyNull(DS.wageaddition.Columns["flagexcludefromcertificate"], true);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_wageaddition_default));
			this.DS = new wageaddition_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabGenerale = new System.Windows.Forms.TabPage();
			this.SubEntity_chkExcludeFromCertificate = new System.Windows.Forms.CheckBox();
			this.btnTrasfdipendenti = new System.Windows.Forms.Button();
			this.groupDebPignoratizio = new System.Windows.Forms.GroupBox();
			this.txtCredDistraint = new System.Windows.Forms.TextBox();
			this.btnRicalcola = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.btnCambiaRuolo = new System.Windows.Forms.Button();
			this.txtCompartoCSA = new System.Windows.Forms.TextBox();
			this.txtInquadrcsa = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblRuoloCSA = new System.Windows.Forms.Label();
			this.txtRuoloCSA = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtImponibileFiscale = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.cmbOrario = new System.Windows.Forms.ComboBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbDurata = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.cmbQualifica = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.txtDurataGiorni = new System.Windows.Forms.TextBox();
			this.txtCostoTotaleInput = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.txtLordoAlBeneficiario = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.dgRitenuta = new System.Windows.Forms.DataGrid();
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
			this.tabClassSuppl = new System.Windows.Forms.TabPage();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
			this.dgrClassSuppl = new System.Windows.Forms.DataGrid();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.labEP = new System.Windows.Forms.Label();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
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
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.btnCodRipartizione = new System.Windows.Forms.Button();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.gBoxCausaleDebitoCrg = new System.Windows.Forms.GroupBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.gBoxCausaleDebito = new System.Windows.Forms.GroupBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button21 = new System.Windows.Forms.Button();
			this.gBoxCausale = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
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
			this.tabAnagPrest = new System.Windows.Forms.TabPage();
			this.btnCollegaAP = new System.Windows.Forms.Button();
			this.grpBoxMotivo = new System.Windows.Forms.GroupBox();
			this.txtMotivoAut = new System.Windows.Forms.TextBox();
			this.grpBoxDocAutorizzattivo = new System.Windows.Forms.GroupBox();
			this.txtDocumentoAut = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtDataDocumentoAut = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.grpBoxAutorizzazioneAP = new System.Windows.Forms.GroupBox();
			this.rdbAutorizzazioneNonNecessaria = new System.Windows.Forms.RadioButton();
			this.rdbNonApplicabile = new System.Windows.Forms.RadioButton();
			this.rdbNecessitaAutorizzazione = new System.Windows.Forms.RadioButton();
			this.btnGeneraAP = new System.Windows.Forms.Button();
			this.btnVisualizzaAP = new System.Windows.Forms.Button();
			this.labAPnongenerato = new System.Windows.Forms.Label();
			this.labAPgenerato = new System.Windows.Forms.Label();
			this.tabDALIA = new System.Windows.Forms.TabPage();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.cmbDaliaFunzionale = new System.Windows.Forms.ComboBox();
			this.gboxDipartimento = new System.Windows.Forms.GroupBox();
			this.btnDipartimento = new System.Windows.Forms.Button();
			this.txtCodiceDipartimento = new System.Windows.Forms.TextBox();
			this.txtDaliaDipartimento = new System.Windows.Forms.TextBox();
			this.grpCausaliAssunzioneDalia = new System.Windows.Forms.GroupBox();
			this.txtCausaleAssunzione = new System.Windows.Forms.TextBox();
			this.btnEsclusioneCIG = new System.Windows.Forms.Button();
			this.btnVoceSpesaDalia = new System.Windows.Forms.Button();
			this.txtVoceSpesaDalia = new System.Windows.Forms.TextBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label91 = new System.Windows.Forms.Label();
			this.btnQualificaDalia = new System.Windows.Forms.Button();
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
			this.tabGenerale.SuspendLayout();
			this.groupDebPignoratizio.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.grpPrestazione.SuspendLayout();
			this.grpPercipiente.SuspendLayout();
			this.grpContratto.SuspendLayout();
			this.tabRitenute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabClassSuppl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).BeginInit();
			this.tabEP.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.gBoxCausaleDebitoCrg.SuspendLayout();
			this.gBoxCausaleDebito.SuspendLayout();
			this.gBoxCausale.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAnagPrest.SuspendLayout();
			this.grpBoxMotivo.SuspendLayout();
			this.grpBoxDocAutorizzattivo.SuspendLayout();
			this.grpBoxAutorizzazioneAP.SuspendLayout();
			this.tabDALIA.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.gboxDipartimento.SuspendLayout();
			this.grpCausaliAssunzioneDalia.SuspendLayout();
			this.groupBox8.SuspendLayout();
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
			this.tabControl1.Controls.Add(this.tabGenerale);
			this.tabControl1.Controls.Add(this.tabRitenute);
			this.tabControl1.Controls.Add(this.tabClassSuppl);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAnagPrest);
			this.tabControl1.Controls.Add(this.tabDALIA);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(742, 502);
			this.tabControl1.TabIndex = 0;
			// 
			// tabGenerale
			// 
			this.tabGenerale.Controls.Add(this.SubEntity_chkExcludeFromCertificate);
			this.tabGenerale.Controls.Add(this.btnTrasfdipendenti);
			this.tabGenerale.Controls.Add(this.groupDebPignoratizio);
			this.tabGenerale.Controls.Add(this.btnRicalcola);
			this.tabGenerale.Controls.Add(this.groupBox7);
			this.tabGenerale.Controls.Add(this.checkBox1);
			this.tabGenerale.Controls.Add(this.txtImponibileFiscale);
			this.tabGenerale.Controls.Add(this.label7);
			this.tabGenerale.Controls.Add(this.groupBox1);
			this.tabGenerale.Controls.Add(this.textBox2);
			this.tabGenerale.Controls.Add(this.label8);
			this.tabGenerale.Controls.Add(this.txtDataFine);
			this.tabGenerale.Controls.Add(this.txtDurataGiorni);
			this.tabGenerale.Controls.Add(this.txtCostoTotaleInput);
			this.tabGenerale.Controls.Add(this.label40);
			this.tabGenerale.Controls.Add(this.txtLordoAlBeneficiario);
			this.tabGenerale.Controls.Add(this.label6);
			this.tabGenerale.Controls.Add(this.txtDataContabile);
			this.tabGenerale.Controls.Add(this.label22);
			this.tabGenerale.Controls.Add(this.grpPrestazione);
			this.tabGenerale.Controls.Add(this.grpPercipiente);
			this.tabGenerale.Controls.Add(this.grpContratto);
			this.tabGenerale.Controls.Add(this.label4);
			this.tabGenerale.Controls.Add(this.label5);
			this.tabGenerale.Controls.Add(this.txtDataInizio);
			this.tabGenerale.Controls.Add(this.label3);
			this.tabGenerale.Location = new System.Drawing.Point(4, 23);
			this.tabGenerale.Name = "tabGenerale";
			this.tabGenerale.Size = new System.Drawing.Size(734, 475);
			this.tabGenerale.TabIndex = 0;
			this.tabGenerale.Text = "Generale";
			this.tabGenerale.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkExcludeFromCertificate
			// 
			this.SubEntity_chkExcludeFromCertificate.AutoSize = true;
			this.SubEntity_chkExcludeFromCertificate.Location = new System.Drawing.Point(8, 81);
			this.SubEntity_chkExcludeFromCertificate.Name = "SubEntity_chkExcludeFromCertificate";
			this.SubEntity_chkExcludeFromCertificate.Size = new System.Drawing.Size(225, 17);
			this.SubEntity_chkExcludeFromCertificate.TabIndex = 116;
			this.SubEntity_chkExcludeFromCertificate.Tag = "wageaddition.flagexcludefromcertificate:S:N";
			this.SubEntity_chkExcludeFromCertificate.Text = "Escludi da Certificazione Unica dei Redditi";
			this.SubEntity_chkExcludeFromCertificate.UseVisualStyleBackColor = true;
			// 
			// btnTrasfdipendenti
			// 
			this.btnTrasfdipendenti.Location = new System.Drawing.Point(592, 395);
			this.btnTrasfdipendenti.Name = "btnTrasfdipendenti";
			this.btnTrasfdipendenti.Size = new System.Drawing.Size(136, 67);
			this.btnTrasfdipendenti.TabIndex = 115;
			this.btnTrasfdipendenti.TabStop = false;
			this.btnTrasfdipendenti.Text = "Trasferisci nell\'esercizio successivo";
			this.btnTrasfdipendenti.UseVisualStyleBackColor = false;
			this.btnTrasfdipendenti.Click += new System.EventHandler(this.btnTrasfdipendenti_Click);
			// 
			// groupDebPignoratizio
			// 
			this.groupDebPignoratizio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupDebPignoratizio.Controls.Add(this.txtCredDistraint);
			this.groupDebPignoratizio.Location = new System.Drawing.Point(478, 145);
			this.groupDebPignoratizio.Name = "groupDebPignoratizio";
			this.groupDebPignoratizio.Size = new System.Drawing.Size(250, 48);
			this.groupDebPignoratizio.TabIndex = 6;
			this.groupDebPignoratizio.TabStop = false;
			this.groupDebPignoratizio.Tag = "AutoChoose.txtCredDistraint.default.(active=\'S\')";
			this.groupDebPignoratizio.Text = "Debitore pignorato";
			// 
			// txtCredDistraint
			// 
			this.txtCredDistraint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDistraint.Location = new System.Drawing.Point(8, 16);
			this.txtCredDistraint.Name = "txtCredDistraint";
			this.txtCredDistraint.Size = new System.Drawing.Size(232, 20);
			this.txtCredDistraint.TabIndex = 1;
			this.txtCredDistraint.Tag = "registry_distrained.title?wageadditionview.registry_distrained";
			// 
			// btnRicalcola
			// 
			this.btnRicalcola.Location = new System.Drawing.Point(592, 353);
			this.btnRicalcola.Name = "btnRicalcola";
			this.btnRicalcola.Size = new System.Drawing.Size(136, 22);
			this.btnRicalcola.TabIndex = 110;
			this.btnRicalcola.Text = "Ricalcola prestazione";
			this.btnRicalcola.UseVisualStyleBackColor = true;
			this.btnRicalcola.Click += new System.EventHandler(this.btnRicalcola_Click);
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.btnCambiaRuolo);
			this.groupBox7.Controls.Add(this.txtCompartoCSA);
			this.groupBox7.Controls.Add(this.txtInquadrcsa);
			this.groupBox7.Controls.Add(this.label10);
			this.groupBox7.Controls.Add(this.label11);
			this.groupBox7.Controls.Add(this.lblRuoloCSA);
			this.groupBox7.Controls.Add(this.txtRuoloCSA);
			this.groupBox7.Location = new System.Drawing.Point(557, 10);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(169, 125);
			this.groupBox7.TabIndex = 104;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Dati CSA";
			// 
			// btnCambiaRuolo
			// 
			this.btnCambiaRuolo.Location = new System.Drawing.Point(78, 97);
			this.btnCambiaRuolo.Name = "btnCambiaRuolo";
			this.btnCambiaRuolo.Size = new System.Drawing.Size(86, 22);
			this.btnCambiaRuolo.TabIndex = 109;
			this.btnCambiaRuolo.Text = "Cambia Ruolo";
			this.btnCambiaRuolo.UseVisualStyleBackColor = true;
			this.btnCambiaRuolo.Click += new System.EventHandler(this.btnCambiaRuolo_Click);
			// 
			// txtCompartoCSA
			// 
			this.txtCompartoCSA.Location = new System.Drawing.Point(112, 17);
			this.txtCompartoCSA.Name = "txtCompartoCSA";
			this.txtCompartoCSA.ReadOnly = true;
			this.txtCompartoCSA.Size = new System.Drawing.Size(52, 20);
			this.txtCompartoCSA.TabIndex = 108;
			// 
			// txtInquadrcsa
			// 
			this.txtInquadrcsa.Location = new System.Drawing.Point(86, 65);
			this.txtInquadrcsa.Name = "txtInquadrcsa";
			this.txtInquadrcsa.ReadOnly = true;
			this.txtInquadrcsa.Size = new System.Drawing.Size(78, 20);
			this.txtInquadrcsa.TabIndex = 107;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(53, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 13);
			this.label10.TabIndex = 106;
			this.label10.Text = "Comparto";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(4, 68);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(78, 13);
			this.label11.TabIndex = 105;
			this.label11.Text = "Inquadramento";
			// 
			// lblRuoloCSA
			// 
			this.lblRuoloCSA.AutoSize = true;
			this.lblRuoloCSA.Location = new System.Drawing.Point(47, 41);
			this.lblRuoloCSA.Name = "lblRuoloCSA";
			this.lblRuoloCSA.Size = new System.Drawing.Size(35, 13);
			this.lblRuoloCSA.TabIndex = 104;
			this.lblRuoloCSA.Text = "Ruolo";
			// 
			// txtRuoloCSA
			// 
			this.txtRuoloCSA.Location = new System.Drawing.Point(86, 41);
			this.txtRuoloCSA.Name = "txtRuoloCSA";
			this.txtRuoloCSA.ReadOnly = true;
			this.txtRuoloCSA.Size = new System.Drawing.Size(78, 20);
			this.txtRuoloCSA.TabIndex = 103;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(598, 271);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(121, 45);
			this.checkBox1.TabIndex = 52;
			this.checkBox1.Tag = "wageaddition.completed:S:N";
			this.checkBox1.Text = "Considera eseguito quindi  pagabile";
			// 
			// txtImponibileFiscale
			// 
			this.txtImponibileFiscale.Location = new System.Drawing.Point(564, 205);
			this.txtImponibileFiscale.Name = "txtImponibileFiscale";
			this.txtImponibileFiscale.Size = new System.Drawing.Size(100, 20);
			this.txtImponibileFiscale.TabIndex = 9;
			this.txtImponibileFiscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtImponibileFiscale.Leave += new System.EventHandler(this.txtImponibileFiscale_Leave);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(463, 205);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 20);
			this.label7.TabIndex = 51;
			this.label7.Text = "Imponibile Fiscale";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(8, 234);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(556, 144);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dati Generali ed Assistenziali";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.button3);
			this.groupBox6.Controls.Add(this.cmbOrario);
			this.groupBox6.Location = new System.Drawing.Point(8, 96);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(533, 40);
			this.groupBox6.TabIndex = 8;
			this.groupBox6.TabStop = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 11);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "manage.workingtime.default";
			this.button3.Text = "Orario";
			// 
			// cmbOrario
			// 
			this.cmbOrario.DataSource = this.DS.workingtime;
			this.cmbOrario.DisplayMember = "description";
			this.cmbOrario.Location = new System.Drawing.Point(96, 12);
			this.cmbOrario.Name = "cmbOrario";
			this.cmbOrario.Size = new System.Drawing.Size(432, 21);
			this.cmbOrario.TabIndex = 5;
			this.cmbOrario.Tag = "workingtime.idworkingtime?wageadditionview.idworkingtime";
			this.cmbOrario.ValueMember = "idworkingtime";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.button2);
			this.groupBox5.Controls.Add(this.cmbDurata);
			this.groupBox5.Location = new System.Drawing.Point(8, 56);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(533, 40);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 11);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Tag = "manage.contractlength.default";
			this.button2.Text = "Durata";
			// 
			// cmbDurata
			// 
			this.cmbDurata.DataSource = this.DS.contractlength;
			this.cmbDurata.DisplayMember = "description";
			this.cmbDurata.Location = new System.Drawing.Point(96, 12);
			this.cmbDurata.Name = "cmbDurata";
			this.cmbDurata.Size = new System.Drawing.Size(432, 21);
			this.cmbDurata.TabIndex = 3;
			this.cmbDurata.Tag = "contractlength.idcontractlength?wageadditionview.idcontractlength";
			this.cmbDurata.ValueMember = "idcontractlength";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.cmbQualifica);
			this.groupBox2.Location = new System.Drawing.Point(8, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(533, 40);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Tag = "manage.positionworkcontract.default";
			this.button1.Text = "Qualifica";
			// 
			// cmbQualifica
			// 
			this.cmbQualifica.DataSource = this.DS.positionworkcontract;
			this.cmbQualifica.DisplayMember = "description";
			this.cmbQualifica.Location = new System.Drawing.Point(96, 12);
			this.cmbQualifica.Name = "cmbQualifica";
			this.cmbQualifica.Size = new System.Drawing.Size(432, 21);
			this.cmbQualifica.TabIndex = 1;
			this.cmbQualifica.Tag = "positionworkcontract.idposition?wageadditionview.idposition";
			this.cmbQualifica.ValueMember = "idposition";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(8, 395);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(556, 67);
			this.textBox2.TabIndex = 10;
			this.textBox2.Tag = "wageaddition.description";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(3, 378);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(64, 20);
			this.label8.TabIndex = 49;
			this.label8.Text = "Descrizione";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(445, 16);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(104, 20);
			this.txtDataFine.TabIndex = 2;
			this.txtDataFine.Tag = "wageaddition.stop";
			this.txtDataFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// txtDurataGiorni
			// 
			this.txtDurataGiorni.Location = new System.Drawing.Point(445, 40);
			this.txtDurataGiorni.Name = "txtDurataGiorni";
			this.txtDurataGiorni.ReadOnly = true;
			this.txtDurataGiorni.Size = new System.Drawing.Size(104, 20);
			this.txtDurataGiorni.TabIndex = 46;
			this.txtDurataGiorni.TabStop = false;
			this.txtDurataGiorni.Tag = "wageaddition.ndays";
			// 
			// txtCostoTotaleInput
			// 
			this.txtCostoTotaleInput.Location = new System.Drawing.Point(324, 205);
			this.txtCostoTotaleInput.Name = "txtCostoTotaleInput";
			this.txtCostoTotaleInput.Size = new System.Drawing.Size(120, 20);
			this.txtCostoTotaleInput.TabIndex = 8;
			this.txtCostoTotaleInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCostoTotaleInput.Leave += new System.EventHandler(this.txtCostoTotaleInput_Leave);
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(244, 205);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(80, 20);
			this.label40.TabIndex = 44;
			this.label40.Text = "Costo totale";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtLordoAlBeneficiario
			// 
			this.txtLordoAlBeneficiario.Location = new System.Drawing.Point(118, 205);
			this.txtLordoAlBeneficiario.Name = "txtLordoAlBeneficiario";
			this.txtLordoAlBeneficiario.Size = new System.Drawing.Size(120, 20);
			this.txtLordoAlBeneficiario.TabIndex = 7;
			this.txtLordoAlBeneficiario.Tag = "wageaddition.feegross";
			this.txtLordoAlBeneficiario.Leave += new System.EventHandler(this.txtLordoAlBeneficiario_Leave);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 205);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 20);
			this.label6.TabIndex = 43;
			this.label6.Text = "Lordo al beneficiario";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(248, 40);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
			this.txtDataContabile.TabIndex = 3;
			this.txtDataContabile.Tag = "wageaddition.adate";
			this.txtDataContabile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataContabile.Leave += new System.EventHandler(this.txtDataContabile_Leave);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(160, 40);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 23);
			this.label22.TabIndex = 42;
			this.label22.Text = "Data Contabile";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpPrestazione
			// 
			this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
			this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
			this.grpPrestazione.Location = new System.Drawing.Point(7, 145);
			this.grpPrestazione.Name = "grpPrestazione";
			this.grpPrestazione.Size = new System.Drawing.Size(466, 48);
			this.grpPrestazione.TabIndex = 5;
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
			this.cmbTipoPrestazione.Size = new System.Drawing.Size(370, 21);
			this.cmbTipoPrestazione.TabIndex = 7;
			this.cmbTipoPrestazione.Tag = "wageaddition.idser";
			this.cmbTipoPrestazione.ValueMember = "idser";
			// 
			// grpPercipiente
			// 
			this.grpPercipiente.Controls.Add(this.txtPercipiente);
			this.grpPercipiente.Location = new System.Drawing.Point(7, 101);
			this.grpPercipiente.Name = "grpPercipiente";
			this.grpPercipiente.Size = new System.Drawing.Size(542, 40);
			this.grpPercipiente.TabIndex = 4;
			this.grpPercipiente.TabStop = false;
			this.grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active=\'S\') )";
			this.grpPercipiente.Text = "Percipiente";
			// 
			// txtPercipiente
			// 
			this.txtPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercipiente.Location = new System.Drawing.Point(8, 16);
			this.txtPercipiente.Name = "txtPercipiente";
			this.txtPercipiente.Size = new System.Drawing.Size(526, 20);
			this.txtPercipiente.TabIndex = 0;
			this.txtPercipiente.Tag = "registry.title?wageadditionview.registry";
			// 
			// grpContratto
			// 
			this.grpContratto.Controls.Add(this.txtNumContratto);
			this.grpContratto.Controls.Add(this.label2);
			this.grpContratto.Controls.Add(this.txtEsercizio);
			this.grpContratto.Controls.Add(this.label1);
			this.grpContratto.Location = new System.Drawing.Point(8, 8);
			this.grpContratto.Name = "grpContratto";
			this.grpContratto.Size = new System.Drawing.Size(151, 67);
			this.grpContratto.TabIndex = 0;
			this.grpContratto.TabStop = false;
			this.grpContratto.Text = "Contratto";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(64, 41);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(72, 20);
			this.txtNumContratto.TabIndex = 2;
			this.txtNumContratto.Tag = "wageaddition.ncon";
			this.txtNumContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 41);
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
			this.txtEsercizio.TabIndex = 1;
			this.txtEsercizio.Tag = "wageaddition.ycon.year";
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
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(357, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 23);
			this.label4.TabIndex = 40;
			this.label4.Text = "Data Fine";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(357, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 41;
			this.label5.Text = "Durata (Giorni)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(248, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(104, 20);
			this.txtDataInizio.TabIndex = 1;
			this.txtDataInizio.Tag = "wageaddition.start";
			this.txtDataInizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(160, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 38;
			this.label3.Text = "Data Inizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.dgRitenuta);
			this.tabRitenute.Controls.Add(this.label38);
			this.tabRitenute.Controls.Add(this.groupBox4);
			this.tabRitenute.Controls.Add(this.groupBox3);
			this.tabRitenute.Location = new System.Drawing.Point(4, 23);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(734, 475);
			this.tabRitenute.TabIndex = 1;
			this.tabRitenute.Text = "Ritenute";
			this.tabRitenute.UseVisualStyleBackColor = true;
			// 
			// dgRitenuta
			// 
			this.dgRitenuta.AllowNavigation = false;
			this.dgRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgRitenuta.CaptionVisible = false;
			this.dgRitenuta.DataMember = "";
			this.dgRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRitenuta.Location = new System.Drawing.Point(8, 168);
			this.dgRitenuta.Name = "dgRitenuta";
			this.dgRitenuta.Size = new System.Drawing.Size(718, 301);
			this.dgRitenuta.TabIndex = 7;
			this.dgRitenuta.Tag = "wageadditiontax.default.default";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(280, 144);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(100, 16);
			this.label38.TabIndex = 11;
			this.label38.Text = "Ritenute";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.groupBox4.Location = new System.Drawing.Point(8, 80);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(718, 56);
			this.groupBox4.TabIndex = 9;
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
			this.groupBox3.Location = new System.Drawing.Point(8, 7);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(718, 56);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ritenute c/dipendente";
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
			// tabClassSuppl
			// 
			this.tabClassSuppl.Controls.Add(this.btnClassElimina);
			this.tabClassSuppl.Controls.Add(this.btnClassModifica);
			this.tabClassSuppl.Controls.Add(this.btnClassInserisci);
			this.tabClassSuppl.Controls.Add(this.dgrClassSuppl);
			this.tabClassSuppl.ImageIndex = 0;
			this.tabClassSuppl.Location = new System.Drawing.Point(4, 23);
			this.tabClassSuppl.Name = "tabClassSuppl";
			this.tabClassSuppl.Size = new System.Drawing.Size(734, 475);
			this.tabClassSuppl.TabIndex = 2;
			this.tabClassSuppl.Text = "Classificazione";
			this.tabClassSuppl.UseVisualStyleBackColor = true;
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(176, 24);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(68, 22);
			this.btnClassElimina.TabIndex = 26;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(96, 24);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(69, 22);
			this.btnClassModifica.TabIndex = 25;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica...";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(16, 24);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnClassInserisci.TabIndex = 24;
			this.btnClassInserisci.Tag = "insert.default";
			this.btnClassInserisci.Text = "Inserisci...";
			// 
			// dgrClassSuppl
			// 
			this.dgrClassSuppl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassSuppl.DataMember = "";
			this.dgrClassSuppl.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassSuppl.Location = new System.Drawing.Point(8, 56);
			this.dgrClassSuppl.Name = "dgrClassSuppl";
			this.dgrClassSuppl.ReadOnly = true;
			this.dgrClassSuppl.Size = new System.Drawing.Size(718, 416);
			this.dgrClassSuppl.TabIndex = 23;
			this.dgrClassSuppl.Tag = "wageadditionsorting.default.default";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Controls.Add(this.btnGeneraPreImpegni);
			this.tabEP.Controls.Add(this.btnViewPreimpegni);
			this.tabEP.Controls.Add(this.btnGeneraEpExp);
			this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabEP.Controls.Add(this.tabControl2);
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Location = new System.Drawing.Point(4, 23);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(734, 475);
			this.tabEP.TabIndex = 3;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(14, 23);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(352, 16);
			this.labEP.TabIndex = 23;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(106, 88);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(282, 23);
			this.btnGeneraPreImpegni.TabIndex = 22;
			this.btnGeneraPreImpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(106, 120);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(282, 23);
			this.btnViewPreimpegni.TabIndex = 21;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(416, 88);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 20;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(416, 120);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 19;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabAnalitico);
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Location = new System.Drawing.Point(4, 149);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(726, 321);
			this.tabControl2.TabIndex = 18;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(718, 295);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziario";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(3, 3);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(553, 109);
			this.gboxUPB.TabIndex = 5;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 83);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(541, 20);
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
			this.txtDescrUPB.Size = new System.Drawing.Size(404, 69);
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
			this.btnUPBCode.Text = "UPB";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// tabAnalitico
			// 
			this.tabAnalitico.Controls.Add(this.btnRipartizione);
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Controls.Add(this.grpRipartizioneCosti);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(718, 295);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			this.tabAnalitico.Visible = false;
			// 
			// btnRipartizione
			// 
			this.btnRipartizione.Location = new System.Drawing.Point(360, 269);
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
			this.gboxclass3.Location = new System.Drawing.Point(361, 8);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(336, 121);
			this.gboxclass3.TabIndex = 3;
			this.gboxclass3.TabStop = false;
			this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
			this.gboxclass3.Text = "Classificazione 3";
			// 
			// btnCodice3
			// 
			this.btnCodice3.Location = new System.Drawing.Point(6, 65);
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
			this.txtDenom3.Location = new System.Drawing.Point(128, 16);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(200, 72);
			this.txtDenom3.TabIndex = 3;
			this.txtDenom3.TabStop = false;
			this.txtDenom3.Tag = "sorting3.description";
			// 
			// txtCodice3
			// 
			this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice3.Location = new System.Drawing.Point(6, 94);
			this.txtCodice3.Name = "txtCodice3";
			this.txtCodice3.Size = new System.Drawing.Size(322, 20);
			this.txtCodice3.TabIndex = 2;
			this.txtCodice3.Tag = "sorting3.sortcode?x";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(8, 135);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(336, 135);
			this.gboxclass2.TabIndex = 2;
			this.gboxclass2.TabStop = false;
			this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
			this.gboxclass2.Text = "Classificazione 2";
			// 
			// btnCodice2
			// 
			this.btnCodice2.Location = new System.Drawing.Point(6, 80);
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
			this.txtDenom2.Location = new System.Drawing.Point(128, 16);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(200, 87);
			this.txtDenom2.TabIndex = 3;
			this.txtDenom2.TabStop = false;
			this.txtDenom2.Tag = "sorting2.description";
			// 
			// txtCodice2
			// 
			this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice2.Location = new System.Drawing.Point(6, 109);
			this.txtCodice2.Name = "txtCodice2";
			this.txtCodice2.Size = new System.Drawing.Size(324, 20);
			this.txtCodice2.TabIndex = 2;
			this.txtCodice2.Tag = "sorting2.sortcode?x";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(8, 8);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(336, 121);
			this.gboxclass1.TabIndex = 1;
			this.gboxclass1.TabStop = false;
			this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
			this.gboxclass1.Text = "Classificazione 1";
			// 
			// btnCodice1
			// 
			this.btnCodice1.Location = new System.Drawing.Point(11, 65);
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
			this.txtDenom1.Location = new System.Drawing.Point(128, 16);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(200, 72);
			this.txtDenom1.TabIndex = 3;
			this.txtDenom1.TabStop = false;
			this.txtDenom1.Tag = "sorting1.description";
			// 
			// txtCodice1
			// 
			this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice1.Location = new System.Drawing.Point(8, 94);
			this.txtCodice1.Name = "txtCodice1";
			this.txtCodice1.Size = new System.Drawing.Size(322, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.btnCodRipartizione);
			this.grpRipartizioneCosti.Controls.Add(this.textBox7);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(361, 135);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(336, 128);
			this.grpRipartizioneCosti.TabIndex = 54;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// btnCodRipartizione
			// 
			this.btnCodRipartizione.Location = new System.Drawing.Point(9, 73);
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
			this.textBox7.Location = new System.Drawing.Point(137, 8);
			this.textBox7.Multiline = true;
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(191, 88);
			this.textBox7.TabIndex = 3;
			this.textBox7.TabStop = false;
			this.textBox7.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 102);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(320, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpBoxSiopeEP);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textBox8);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebitoCrg);
			this.tabPage2.Controls.Add(this.gBoxCausaleDebito);
			this.tabPage2.Controls.Add(this.gBoxCausale);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(718, 295);
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
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(328, 88);
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
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(345, 105);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(185, 16);
			this.label9.TabIndex = 20;
			this.label9.Text = "Data correzione causale di debito";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(536, 101);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(134, 20);
			this.textBox8.TabIndex = 2;
			this.textBox8.Tag = "wageaddition.idaccmotivedebit_datacrg";
			// 
			// gBoxCausaleDebitoCrg
			// 
			this.gBoxCausaleDebitoCrg.Controls.Add(this.textBox9);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.txtCodiceCausaleCrg);
			this.gBoxCausaleDebitoCrg.Controls.Add(this.button8);
			this.gBoxCausaleDebitoCrg.Location = new System.Drawing.Point(342, 127);
			this.gBoxCausaleDebitoCrg.Name = "gBoxCausaleDebitoCrg";
			this.gBoxCausaleDebitoCrg.Size = new System.Drawing.Size(328, 131);
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
			this.textBox9.Size = new System.Drawing.Size(200, 83);
			this.textBox9.TabIndex = 2;
			this.textBox9.TabStop = false;
			this.textBox9.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(6, 105);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?wageadditionview.codemotivedebit_crg";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(6, 76);
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
			this.gBoxCausaleDebito.Location = new System.Drawing.Point(8, 127);
			this.gBoxCausaleDebito.Name = "gBoxCausaleDebito";
			this.gBoxCausaleDebito.Size = new System.Drawing.Size(328, 131);
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
			this.textBox10.Size = new System.Drawing.Size(200, 83);
			this.textBox10.TabIndex = 2;
			this.textBox10.TabStop = false;
			this.textBox10.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(11, 105);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(309, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?wageadditionview.codemotivedebit";
			// 
			// button21
			// 
			this.button21.Location = new System.Drawing.Point(11, 76);
			this.button21.Name = "button21";
			this.button21.Size = new System.Drawing.Size(104, 23);
			this.button21.TabIndex = 0;
			this.button21.Tag = "manage.accmotiveapplied_debit.tree";
			this.button21.Text = "Causale";
			// 
			// gBoxCausale
			// 
			this.gBoxCausale.Controls.Add(this.textBox5);
			this.gBoxCausale.Controls.Add(this.txtCodiceCausale);
			this.gBoxCausale.Controls.Add(this.button5);
			this.gBoxCausale.Location = new System.Drawing.Point(8, 8);
			this.gBoxCausale.Name = "gBoxCausale";
			this.gBoxCausale.Size = new System.Drawing.Size(328, 113);
			this.gBoxCausale.TabIndex = 0;
			this.gBoxCausale.TabStop = false;
			this.gBoxCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
			this.gBoxCausale.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(120, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(200, 67);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied_cost.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(11, 87);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(309, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied_cost.codemotive?wageadditionview.codemotive";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(11, 60);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 23);
			this.button5.TabIndex = 0;
			this.button5.Tag = "manage.accmotiveapplied_cost.tree";
			this.button5.Text = "Causale";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(416, 48);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 17;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(416, 16);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 16;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
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
			this.tabAttributi.Size = new System.Drawing.Size(734, 475);
			this.tabAttributi.TabIndex = 5;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(9, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(465, 64);
			this.gboxclass05.TabIndex = 28;
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
			this.txtDenom05.Size = new System.Drawing.Size(223, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(9, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(465, 64);
			this.gboxclass04.TabIndex = 27;
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
			this.txtDenom04.Size = new System.Drawing.Size(223, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(9, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(465, 64);
			this.gboxclass03.TabIndex = 25;
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
			this.txtDenom03.Size = new System.Drawing.Size(224, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(9, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(465, 64);
			this.gboxclass02.TabIndex = 26;
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
			this.txtDenom02.Size = new System.Drawing.Size(224, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(9, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(465, 64);
			this.gboxclass01.TabIndex = 24;
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
			this.txtDenom01.Size = new System.Drawing.Size(224, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
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
			this.tabAnagPrest.Size = new System.Drawing.Size(734, 475);
			this.tabAnagPrest.TabIndex = 4;
			this.tabAnagPrest.Text = "Anagrafe Prestazioni";
			this.tabAnagPrest.UseVisualStyleBackColor = true;
			// 
			// btnCollegaAP
			// 
			this.btnCollegaAP.Location = new System.Drawing.Point(440, 96);
			this.btnCollegaAP.Name = "btnCollegaAP";
			this.btnCollegaAP.Size = new System.Drawing.Size(224, 39);
			this.btnCollegaAP.TabIndex = 23;
			this.btnCollegaAP.Text = "Collega ad Anagrafe delle Prestazioni  già esistente";
			this.btnCollegaAP.Click += new System.EventHandler(this.btnCollegaAP_Click);
			// 
			// grpBoxMotivo
			// 
			this.grpBoxMotivo.Controls.Add(this.txtMotivoAut);
			this.grpBoxMotivo.Location = new System.Drawing.Point(290, 222);
			this.grpBoxMotivo.Name = "grpBoxMotivo";
			this.grpBoxMotivo.Size = new System.Drawing.Size(374, 91);
			this.grpBoxMotivo.TabIndex = 21;
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
			this.txtMotivoAut.Tag = "wageaddition.noauthreason";
			// 
			// grpBoxDocAutorizzattivo
			// 
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label23);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDataDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label24);
			this.grpBoxDocAutorizzattivo.Location = new System.Drawing.Point(290, 317);
			this.grpBoxDocAutorizzattivo.Name = "grpBoxDocAutorizzattivo";
			this.grpBoxDocAutorizzattivo.Size = new System.Drawing.Size(374, 54);
			this.grpBoxDocAutorizzattivo.TabIndex = 20;
			this.grpBoxDocAutorizzattivo.TabStop = false;
			this.grpBoxDocAutorizzattivo.Text = "Documento autorizzativo";
			// 
			// txtDocumentoAut
			// 
			this.txtDocumentoAut.Location = new System.Drawing.Point(8, 30);
			this.txtDocumentoAut.Name = "txtDocumentoAut";
			this.txtDocumentoAut.Size = new System.Drawing.Size(255, 20);
			this.txtDocumentoAut.TabIndex = 1;
			this.txtDocumentoAut.Tag = "wageaddition.authdoc";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 14);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(128, 16);
			this.label23.TabIndex = 0;
			this.label23.Text = "Descrizione";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumentoAut
			// 
			this.txtDataDocumentoAut.Location = new System.Drawing.Point(285, 30);
			this.txtDataDocumentoAut.Name = "txtDataDocumentoAut";
			this.txtDataDocumentoAut.Size = new System.Drawing.Size(72, 20);
			this.txtDataDocumentoAut.TabIndex = 2;
			this.txtDataDocumentoAut.Tag = "wageaddition.authdocdate";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(285, 14);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(72, 16);
			this.label24.TabIndex = 0;
			this.label24.Text = "Data";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpBoxAutorizzazioneAP
			// 
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbAutorizzazioneNonNecessaria);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNonApplicabile);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNecessitaAutorizzazione);
			this.grpBoxAutorizzazioneAP.Location = new System.Drawing.Point(19, 221);
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
			this.rdbAutorizzazioneNonNecessaria.Tag = "wageaddition.authneeded:N";
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
			this.rdbNonApplicabile.Tag = "wageaddition.authneeded:X";
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
			this.rdbNecessitaAutorizzazione.Tag = "wageaddition.authneeded:S";
			this.rdbNecessitaAutorizzazione.Text = "Necessita autorizzazione";
			this.rdbNecessitaAutorizzazione.UseVisualStyleBackColor = true;
			this.rdbNecessitaAutorizzazione.CheckedChanged += new System.EventHandler(this.rdbNecessitaAutorizzazione_CheckedChanged);
			// 
			// btnGeneraAP
			// 
			this.btnGeneraAP.Location = new System.Drawing.Point(440, 56);
			this.btnGeneraAP.Name = "btnGeneraAP";
			this.btnGeneraAP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraAP.TabIndex = 9;
			this.btnGeneraAP.Text = "Genera Anagrafe delle Prestazioni";
			this.btnGeneraAP.Click += new System.EventHandler(this.btnGeneraAP_Click);
			// 
			// btnVisualizzaAP
			// 
			this.btnVisualizzaAP.Location = new System.Drawing.Point(440, 24);
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
			this.labAPnongenerato.Size = new System.Drawing.Size(416, 24);
			this.labAPnongenerato.TabIndex = 7;
			this.labAPnongenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni  NON sono state ancora generate." +
    "";
			// 
			// labAPgenerato
			// 
			this.labAPgenerato.Location = new System.Drawing.Point(16, 32);
			this.labAPgenerato.Name = "labAPgenerato";
			this.labAPgenerato.Size = new System.Drawing.Size(432, 16);
			this.labAPgenerato.TabIndex = 6;
			this.labAPgenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni sono state generate.";
			// 
			// tabDALIA
			// 
			this.tabDALIA.Controls.Add(this.groupBox9);
			this.tabDALIA.Controls.Add(this.gboxDipartimento);
			this.tabDALIA.Controls.Add(this.grpCausaliAssunzioneDalia);
			this.tabDALIA.Controls.Add(this.btnVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.txtVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.groupBox8);
			this.tabDALIA.Location = new System.Drawing.Point(4, 23);
			this.tabDALIA.Name = "tabDALIA";
			this.tabDALIA.Padding = new System.Windows.Forms.Padding(3);
			this.tabDALIA.Size = new System.Drawing.Size(734, 475);
			this.tabDALIA.TabIndex = 6;
			this.tabDALIA.Text = "DALIA";
			this.tabDALIA.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Controls.Add(this.cmbDaliaFunzionale);
			this.groupBox9.Location = new System.Drawing.Point(18, 262);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(379, 54);
			this.groupBox9.TabIndex = 117;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Area funzionale - richiesta per il personale Tecnico / Amministrativo";
			// 
			// cmbDaliaFunzionale
			// 
			this.cmbDaliaFunzionale.FormattingEnabled = true;
			this.cmbDaliaFunzionale.Location = new System.Drawing.Point(6, 19);
			this.cmbDaliaFunzionale.Name = "cmbDaliaFunzionale";
			this.cmbDaliaFunzionale.Size = new System.Drawing.Size(367, 21);
			this.cmbDaliaFunzionale.TabIndex = 0;
			this.cmbDaliaFunzionale.Tag = "wageaddition.iddalia_funzionale";
			// 
			// gboxDipartimento
			// 
			this.gboxDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDipartimento.Controls.Add(this.btnDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtCodiceDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtDaliaDipartimento);
			this.gboxDipartimento.Location = new System.Drawing.Point(18, 206);
			this.gboxDipartimento.Name = "gboxDipartimento";
			this.gboxDipartimento.Size = new System.Drawing.Size(694, 50);
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
			this.txtCodiceDipartimento.Location = new System.Drawing.Point(581, 19);
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
			this.txtDaliaDipartimento.Size = new System.Drawing.Size(446, 20);
			this.txtDaliaDipartimento.TabIndex = 0;
			this.txtDaliaDipartimento.Tag = "dalia_dipartimento.title";
			// 
			// grpCausaliAssunzioneDalia
			// 
			this.grpCausaliAssunzioneDalia.Controls.Add(this.txtCausaleAssunzione);
			this.grpCausaliAssunzioneDalia.Controls.Add(this.btnEsclusioneCIG);
			this.grpCausaliAssunzioneDalia.Location = new System.Drawing.Point(18, 154);
			this.grpCausaliAssunzioneDalia.Name = "grpCausaliAssunzioneDalia";
			this.grpCausaliAssunzioneDalia.Size = new System.Drawing.Size(694, 46);
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
			this.txtCausaleAssunzione.Size = new System.Drawing.Size(565, 20);
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
			// btnVoceSpesaDalia
			// 
			this.btnVoceSpesaDalia.Location = new System.Drawing.Point(38, 111);
			this.btnVoceSpesaDalia.Name = "btnVoceSpesaDalia";
			this.btnVoceSpesaDalia.Size = new System.Drawing.Size(160, 23);
			this.btnVoceSpesaDalia.TabIndex = 31;
			this.btnVoceSpesaDalia.Text = "Seleziona Voce di spesa Dalia";
			this.btnVoceSpesaDalia.UseVisualStyleBackColor = true;
			this.btnVoceSpesaDalia.Click += new System.EventHandler(this.btnVoceSpesaDalia_Click);
			// 
			// txtVoceSpesaDalia
			// 
			this.txtVoceSpesaDalia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtVoceSpesaDalia.Location = new System.Drawing.Point(205, 114);
			this.txtVoceSpesaDalia.Name = "txtVoceSpesaDalia";
			this.txtVoceSpesaDalia.ReadOnly = true;
			this.txtVoceSpesaDalia.Size = new System.Drawing.Size(499, 20);
			this.txtVoceSpesaDalia.TabIndex = 112;
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.label91);
			this.groupBox8.Controls.Add(this.btnQualificaDalia);
			this.groupBox8.Controls.Add(this.textBox6);
			this.groupBox8.Controls.Add(this.cmb_dalia_position);
			this.groupBox8.Location = new System.Drawing.Point(18, 17);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(694, 80);
			this.groupBox8.TabIndex = 110;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Banca Dati DALIA";
			// 
			// label91
			// 
			this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(570, 25);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(118, 13);
			this.label91.TabIndex = 110;
			this.label91.Text = "Codice Qualifica DALIA";
			// 
			// btnQualificaDalia
			// 
			this.btnQualificaDalia.Location = new System.Drawing.Point(65, 39);
			this.btnQualificaDalia.Name = "btnQualificaDalia";
			this.btnQualificaDalia.Size = new System.Drawing.Size(116, 23);
			this.btnQualificaDalia.TabIndex = 113;
			this.btnQualificaDalia.Text = "Qualifica Dalia";
			this.btnQualificaDalia.UseVisualStyleBackColor = true;
			this.btnQualificaDalia.Click += new System.EventHandler(this.btnQualificaDalia_Click);
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(570, 41);
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
			this.cmb_dalia_position.Location = new System.Drawing.Point(187, 40);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(365, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "wageaddition.iddaliaposition";
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
			this.tabAllegati.Size = new System.Drawing.Size(734, 475);
			this.tabAllegati.TabIndex = 7;
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
			this.dgrAllegati.Location = new System.Drawing.Point(9, 37);
			this.dgrAllegati.Name = "dgrAllegati";
			this.dgrAllegati.ReadOnly = true;
			this.dgrAllegati.Size = new System.Drawing.Size(719, 435);
			this.dgrAllegati.TabIndex = 31;
			this.dgrAllegati.Tag = "wageadditionattachment.lista.detail";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(169, 7);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 23);
			this.btnDelAtt.TabIndex = 30;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(89, 7);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(69, 23);
			this.btnEditAtt.TabIndex = 29;
			this.btnEditAtt.Tag = "edit.detail";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(9, 7);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 23);
			this.btnInsAtt.TabIndex = 28;
			this.btnInsAtt.Tag = "insert.detail";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// Frm_wageaddition_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(752, 516);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_wageaddition_default";
			this.Text = "frmcontrattodipendente";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabGenerale.ResumeLayout(false);
			this.tabGenerale.PerformLayout();
			this.groupDebPignoratizio.ResumeLayout(false);
			this.groupDebPignoratizio.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.grpPrestazione.ResumeLayout(false);
			this.grpPercipiente.ResumeLayout(false);
			this.grpPercipiente.PerformLayout();
			this.grpContratto.ResumeLayout(false);
			this.grpContratto.PerformLayout();
			this.tabRitenute.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRitenuta)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabClassSuppl.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).EndInit();
			this.tabEP.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.tabAnalitico.ResumeLayout(false);
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
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
			this.tabAnagPrest.ResumeLayout(false);
			this.grpBoxMotivo.ResumeLayout(false);
			this.grpBoxMotivo.PerformLayout();
			this.grpBoxDocAutorizzattivo.ResumeLayout(false);
			this.grpBoxDocAutorizzattivo.PerformLayout();
			this.grpBoxAutorizzazioneAP.ResumeLayout(false);
			this.grpBoxAutorizzazioneAP.PerformLayout();
			this.tabDALIA.ResumeLayout(false);
			this.tabDALIA.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.gboxDipartimento.ResumeLayout(false);
			this.gboxDipartimento.PerformLayout();
			this.grpCausaliAssunzioneDalia.ResumeLayout(false);
			this.grpCausaliAssunzioneDalia.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrAllegati)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;
        private EP_Manager EPM;
        DataAccess Conn;
        object idsorkindDalia;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            idsorkindDalia = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "VOCISPESA"), "idsorkind");
            AccMotiveManager AM = new AccMotiveManager(gBoxCausale);
            AccMotiveManager AM01 = new AccMotiveManager(gBoxCausaleDebito);
            AccMotiveManager AM02 = new AccMotiveManager(gBoxCausaleDebitoCrg);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterPrestazione = QHS.CmpEq("module", "DIPENDENTE");
            GetData.SetStaticFilter(DS.sortingview1, filteresercizio);

            GetData.SetStaticFilter(DS.wageadditionyear, filteresercizio);
            GetData.CacheTable(DS.positionworkcontract, filteresercizio, "description", true);
            GetData.CacheTable(DS.workingtime, filteresercizio, "description", true);
            GetData.CacheTable(DS.contractlength, filteresercizio, "description", true);
            GetData.SetStaticFilter(DS.service, filterPrestazione);
            GetData.CacheTable(DS.tax, null, null, false);
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            HelpForm.SetDenyNull(DS.wageaddition.Columns["completed"], true);

            string filterEpOperationSF = QHS.CmpEq("idepoperation", "dipen");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "dipen");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationSF = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationSF, Meta.Conn);
            filterEpOperationEP = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationEP, Meta.Conn);
            DS.accmotiveapplied_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_cost, filterEpOperationSF);
            DataAccess.SetTableForReading(DS.accmotiveapplied_cost, "accmotiveapplied");

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "dipen_deb");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
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
            DataAccess.SetTableForReading(DS.registry_distrained, "registry");
            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
                filteresercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if ((idsorkind1 == DBNull.Value) && (idsorkind2 == DBNull.Value) && (idsorkind3 == DBNull.Value)) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }
            }

            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Meta.Conn.RUN_SELECT("uniconfig", "*", null,
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
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni,
                btnGeneraEP, btnVisualizzaEP, labEP, null, "wageaddition");

            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);

			bool IsAdmin = (Meta.GetSys("manage_prestazioni") != null) ? Meta.GetSys("manage_prestazioni").ToString() == "S" : false;
            object flag_escludidacu = Conn.GetUsr("flag_escludidacu");
            bool function_enabled = ((flag_escludidacu != null && flag_escludidacu.ToString().ToUpper() == "'S'"));
            SubEntity_chkExcludeFromCertificate.Enabled = IsAdmin||function_enabled;

        }

        siope_helper SiopeObj;

        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }




        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            if (DS.wageaddition.Rows.Count == 0) return;
            DataRow Curr = DS.wageaddition.Rows[0];
            decimal importo = getDecimalFromTextBox(txtLordoAlBeneficiario);
            switch (T.TableName) {
                case "sortingview1": {
                    if (R == null) return;
                    if (Meta.IsEmpty) return;
                    selezionaVoceSpesaDalia(R["idsor"]);
                    return;
                }
                case "service": {
                    abilitaDisabilitaDalia(R);
                    if (R == null) {
                        currParams = Curr["idreg"] + "#_#" + Curr["adate"];
                        lastPrestazione = 0;
                        clearRitenute();
                        txtCredDistraint.Text = "";
                        Curr["idreg_distrained"] = DBNull.Value;
                        groupDebPignoratizio.Visible = false;

                        return;
                    }
                    else {
                        if (lastPrestazione == CfgFn.GetNoNullInt32(R["idser"])) return;
                        currParams = Curr["idreg"] + "#" + R["idser"] + "#" + Curr["adate"];
                        lastPrestazione = CfgFn.GetNoNullInt32(R["idser"]);
                        calcolaRitenute(ImportoDiPartenza.compensoLordo, importo, false);
                        bool distraint = CheckDistraint();
                        if (!distraint) {
                            txtCredDistraint.Text = "";
                            Curr["idreg_distrained"] = DBNull.Value;
                        }
                        groupDebPignoratizio.Visible = distraint;

                    }
                    flagcalcimpfiscale = R["flagonlyfiscalabatement"].ToString().ToUpper();

                    break;
                }
                case "registry": {
                    bool scegliDalia = false;
                    GeneraSelect(txtPercipiente);
                    if (R == null) {
                        currParams = "_#" + Curr["idser"] + "#" + Curr["adate"];
                        lastCreditore = 0;
                        return;
                    }
                    else {
                        if (lastCreditore == CfgFn.GetNoNullInt32(R["idreg"])) return;
                        if (DaliaAbilitato) {
                            scegliDalia = true;
                        }

                        currParams = R["idreg"] + "#" + Curr["idser"] + "#" + Curr["adate"];
                        lastCreditore = CfgFn.GetNoNullInt32(R["idreg"]);
                        calcolaRitenute(ImportoDiPartenza.compensoLordo, importo, false);

                        if (Meta.DrawStateIsDone) {
                            Curr["idaccmotivedebit"] = R["idaccmotivedebit"];
                            DS.accmotiveapplied_debit.Clear();
                            Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, null,
                                (q.eq("idaccmotive", Curr["idaccmotivedebit"]) & q.eq("idepoperation", "dipen_deb")).toSql(QHS),null,false);
                            Meta.helpForm.FillControls(gBoxCausaleDebito.Controls);

                        }
                    }
                    // Se cambia l'anagrafica imposta il valore di default X
                    Curr["authneeded"] = "X";
                    rdbNonApplicabile.Checked = true;

                    if (scegliDalia) {
                        selezionaQualificaDalia(true);
                    }
                    break;
                }
                case "positionworkcontract": {
                    DS.wageadditionyear.Rows[0]["idposition"] = (R == null) ? DBNull.Value : R["idposition"];
                    break;
                }
                case "contractlength": {
                    DS.wageadditionyear.Rows[0]["idcontractlength"] = (R == null) ? DBNull.Value : R["idcontractlength"];
                    break;
                }
                case "workingtime": {
                    DS.wageadditionyear.Rows[0]["idworkingtime"] = (R == null) ? DBNull.Value : R["idworkingtime"];
                    break;
                }
            case "accmotiveapplied_cost": {
                    SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                    SiopeObj.selectSiope();
                        break;
                }
            }
        }

        bool CheckDistraint() {
            if (Meta.IsEmpty) return true;
            DataRow Curr = DS.wageaddition.Rows[0];
            object idser = Curr["idser"];
            DataRow[] ServiceFiltered = DS.service.Select(QHC.CmpEq("idser", Curr["idser"]));
            if (ServiceFiltered.Length != 0) {
                DataRow Service = ServiceFiltered[0];
                object flagdistraint = Service["flagdistraint"];
                if (flagdistraint != DBNull.Value) {
                    return (flagdistraint.ToString().ToString() == "S");
                }
                else return false;
            }
            else return false;
        }



        private void clearRitenute() {
            foreach (DataRow R in DS.wageadditiontax.Select()) {
                R.Delete();
            }
            currParams = lastCreditore + "#_#" + lastDataContabile;
            lastParams = currParams;
            azzeraTxtNonGestiti();
        }

        public void MostraNascondiAutorizzazione() {
            if (DS.wageaddition.Rows.Count == 0) {
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
            if (DS.wageaddition.Rows.Count == 0) {
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
            EPM.mostraEtichette();
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = false;
            AggiornaVoceSpesa();

            if (Meta.FirstFillForThisRow) {
                lastDataContabile = (DateTime) DS.wageaddition.Rows[0]["adate"];
            }

            if ((Meta.FirstFillForThisRow) && (Meta.EditMode)) {
                assegnaVarConfronto();
            }
            txtEsercizio.ReadOnly = true;
            calcolaTxtNonGestiti();

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
                groupDebPignoratizio.Visible = CheckDistraint();

            }
            if ((!Meta.IsEmpty) && (Meta.FirstFillForThisRow)) {
                grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') )";
                Meta.SetAutoMode(grpPercipiente);
            }
            if (Meta.EditMode && Meta.FirstFillForThisRow) AggiornaSoloInformazioni();
            if (Meta.FirstFillForThisRow) VisualizzaBtnCambiaRuolo();
            DataRow curr = DS.wageaddition.Rows[0];
            SiopeObj.setCausaleEPCorrente(curr["idaccmotive"]);
            if (Meta.EditMode) {
                btnTrasfdipendenti.Enabled = true;
                btnTrasfdipendenti.Visible = true;
            }
        }

        /// <summary>
        /// Viene fatta questa assegnazione per far capire alla libreria che stiamo trattando delle subentity
        /// </summary>
        public void MetaData_AfterGetFormData() {
            Meta.myHelpForm.addExtraEntity("wageadditionyear");
            if (Meta.InsertMode) {
                DataRow Curr = DS.wageaddition.Rows[0];
                foreach (DataRow R1 in DS.wageadditionsorting.Select()) {
                    R1["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R2 in DS.wageadditiontax.Select()) {
                    R2["ncon"] = Curr["ncon"];
                }
                foreach (DataRow R3 in DS.wageadditionyear.Select()) {
                    R3["ncon"] = Curr["ncon"];
                }
            }
        }

        public void MetaData_AfterClear() {
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = true;
            AggiornaVoceSpesa();

            txtEsercizio.ReadOnly = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            azzeraVarConfronto();
            azzeraTxtNonGestiti();
            costoTotaleDaLordoAlBeneficiario = -1;
            imponibileFiscaleDaLordoAlBeneficiario = -1;
            EPM.mostraEtichette();
            VisualizzaEtichetteAP();
            MostraNascondiAutorizzazione();
            MostraNascondiMotivazione();
            grpBoxAutorizzazioneAP.Enabled = true;
            grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') )";
            Meta.SetAutoMode(grpPercipiente);
            btnCambiaRuolo.Visible = false;
            groupDebPignoratizio.Visible = true;
            groupDebPignoratizio.Text = "Debitore pignorato";
            ClearPosGiuridica();
            SiopeObj.setCausaleEPCorrente(null);
            btnTrasfdipendenti.Enabled = false;
            btnTrasfdipendenti.Visible = false;
           
        }

        public void MetaData_BeforeFill() {
            if (!Meta.IsEmpty) {
                CreateImputazioneContrattoDipRow();
            }
        }


        private void calcolaTxtNonGestiti() {
            decimal ritDipFisc = 0;
            decimal ritDipAssic = 0;
            decimal ritDipAssist = 0;
            decimal ritDipPrev = 0;
            decimal ritAmmFisc = 0;
            decimal ritAmmAssic = 0;
            decimal ritAmmAssist = 0;
            decimal ritAmmPrev = 0;
            //decimal costoTotale = CfgFn.GetNoNullDecimal(DS.contrattodip.Rows[0]["compensolordo"]);
            decimal costoTotale = getDecimalFromTextBox(txtLordoAlBeneficiario);
            decimal importoNetto = costoTotale;
            decimal imponibileFiscale = 0;
            foreach (DataRow R in DS.wageadditiontax.Select()) {
                switch (R["!tiporitenuta"].ToString().ToUpper()) {
                    case "1": {
                        ritDipFisc += CfgFn.GetNoNullDecimal(R["employtax"]);
                        ritAmmFisc += CfgFn.GetNoNullDecimal(R["admintax"]);
                        imponibileFiscale = CfgFn.GetNoNullDecimal(R["taxable"]);
                        break;
                    }
                    case "3": {
                        ritDipPrev += CfgFn.GetNoNullDecimal(R["employtax"]);
                        ritAmmPrev += CfgFn.GetNoNullDecimal(R["admintax"]);
                        break;
                    }
                    case "4": {
                        ritDipAssic += CfgFn.GetNoNullDecimal(R["employtax"]);
                        ritAmmAssic += CfgFn.GetNoNullDecimal(R["admintax"]);
                        break;
                    }
                    case "2": {
                        ritDipAssist += CfgFn.GetNoNullDecimal(R["employtax"]);
                        ritAmmAssist += CfgFn.GetNoNullDecimal(R["admintax"]);
                        break;
                    }
                }
            }
            costoTotale += (ritAmmFisc + ritAmmPrev + ritAmmAssic + ritAmmAssist);
            importoNetto -= (ritDipFisc + ritDipPrev + ritDipAssic + ritDipAssist);

            txtRitFiscaleDip.Text = ritDipFisc.ToString("c");
            txtRitFiscaleAmm.Text = ritAmmFisc.ToString("c");
            txtRitPrevidenzialeDip.Text = ritDipPrev.ToString("c");
            txtRitPrevidenzialeAmm.Text = ritAmmPrev.ToString("c");
            txtRitAssicurativaDip.Text = ritDipAssic.ToString("c");
            txtRitAssicurativaAmm.Text = ritAmmAssic.ToString("c");
            txtRitAssistenzialeDip.Text = ritDipAssist.ToString("c");
            txtRitAssistenzialeAmm.Text = ritAmmAssist.ToString("c");
            txtCostoTotale.Text = costoTotale.ToString("c");
            txtImportoNetto.Text = importoNetto.ToString("c");
            if (txtCostoTotaleInput.Text == "") txtCostoTotaleInput.Text = costoTotale.ToString("c");
            if (txtImponibileFiscale.Text == "") txtImponibileFiscale.Text = imponibileFiscale.ToString("c");
        }

        private void azzeraTxtNonGestiti() {
            string empty = "";

            txtCostoTotaleInput.Text = empty;
            txtImponibileFiscale.Text = empty;
            txtRitFiscaleDip.Text = empty;
            txtRitPrevidenzialeDip.Text = empty;
            txtRitAssicurativaDip.Text = empty;
            txtRitAssistenzialeDip.Text = empty;
            txtRitFiscaleAmm.Text = empty;
            txtRitPrevidenzialeAmm.Text = empty;
            txtRitAssicurativaAmm.Text = empty;
            txtRitAssistenzialeAmm.Text = empty;
            txtImportoNetto.Text = empty;
            txtCostoTotale.Text = empty;
        }


        private void assegnaVarConfronto() {
            azzeraVarConfronto();

            if (Meta.IsEmpty) return;
            DataRow Curr = DS.wageaddition.Rows[0];

            object codicecreddeb = Curr["idreg"];
            object codiceprestazione = Curr["idser"];
            object datacontabile = Curr["adate"];
            object compensolordo = Curr["feegross"];

            if (CfgFn.GetNoNullInt32(codicecreddeb) == 0) {
                show("Non è stato selezionato il percipiente");
                return;
            }
            if (CfgFn.GetNoNullInt32(codiceprestazione) == 0) {
                show("Non è stata selezionata la prestazione");
                return;
            }
            if ((datacontabile == DBNull.Value) || ((DateTime) datacontabile == QueryCreator.EmptyDate())) {
                show("Non è stata immessa la data contabile della prestazione");
                return;
            }
            if ((compensolordo == DBNull.Value) || ((decimal) compensolordo <= 0)) {
                show("Non è stato inserito il compenso lordo o è stato immesso un compenso negativo");
                return;
            }

            lastCreditore = CfgFn.GetNoNullInt32(codicecreddeb);
            lastPrestazione = CfgFn.GetNoNullInt32(codiceprestazione);
            lastDataContabile = (DateTime) datacontabile;
            lastParams = codicecreddeb + "#" + codiceprestazione + "#" + datacontabile;
        }

        private void azzeraVarConfronto() {
            lastParams = "";
            lastCreditore = 0;
            lastPrestazione = 0;
            lastDataContabile = new DateTime(1900, 1, 1);
        }

        public void CreateImputazioneContrattoDipRow() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.wageaddition.Rows[0];
            if (DS.wageadditionyear.Rows.Count == 0) {
                DataRow drContratto = DS.Tables["wageaddition"].Rows[0];
                MetaData metaIC = MetaData.GetMetaData(this, "wageadditionyear");
                metaIC.SetDefaults(DS.wageadditionyear);
                DataRow DR = metaIC.Get_New_Row(drContratto, DS.wageadditionyear);
            }
        }

        private void txtDataInizio_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
            GeneraSelect(sender);
        }

        private void txtDataFine_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
            GeneraSelect(sender);
        }

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

        private void visualizzaMessaggio() {
            string messaggio = "Il calcolo non può essere effettuato in quanto mancano i seguenti dati:";
            if (lastCreditore == 0) {
                messaggio += "\nIl Percipiente";
            }
            if (lastPrestazione == 0) {
                messaggio += "\nLa Prestazione";
            }
            if (lastDataContabile == dataVuota) {
                messaggio += "\nLa Data Contabile";
            }
            show(this, messaggio, "Avvertimento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void calcolaRitenute(ImportoDiPartenza tipoImporto, decimal importoInserito, bool visualizzaAvvertimento) {
            if ((Meta.IsEmpty) || (!Meta.DrawStateIsDone)) return;
            Meta.GetFormData(true);
            DataRow Curr = DS.wageaddition.Rows[0];

            switch (tipoImporto) {
                case ImportoDiPartenza.compensoOmnicomprensivo: {
                    if (importoInserito == costoTotaleDaLordoAlBeneficiario) {
                        return;
                    }
                    break;
                }
                case ImportoDiPartenza.imponibileFiscale: {
                    if (importoInserito == imponibileFiscaleDaLordoAlBeneficiario) {
                        return;
                    }
                    break;
                }
            }

            bool puoiCalcolare = (lastCreditore != 0) && (lastPrestazione != 0) && (lastDataContabile != dataVuota);
            if (!puoiCalcolare) {
                if (visualizzaAvvertimento) visualizzaMessaggio();
                return;
            }

            // La S.P. viene chiamata solo se cambiano i parametri di ingresso della S.P.
            // ossia creditore / data contabile / prestazione.
            if (currParams != lastParams) {
                // Annullo tutte le modifiche a contrattodipritenuta in quanto sto ricalcolando tutto daccapo
                DS.wageadditiontax.RejectChanges();
                // Viene chiamata la SP
                DataSet Out = Meta.Conn.CallSP("compute_taxrate",
                    new object[] {Curr["idreg"], Curr["idser"], Curr["adate"]});
                if (Out == null) return;
                if (Out.Tables.Count == 0) return; //no answer from sp

                // Controllo il risultato della S.P. con le ritenute già presenti in DS.contrattodipritenuta
                // Se la ritenuta è presente in DS.contrattodipritenuta e non è presente in Out.Tables[0] cancello la riga di DS
                DataRow[] oldListaRitenuta = DS.wageadditiontax.Select();

                foreach (DataRow oldDR in oldListaRitenuta) {
                    string filter = QHS.CmpEq("taxcode", oldDR["taxcode"]);
                    if (Out.Tables[0].Select(filter).Length == 0) {
                        oldDR.Delete();
                    }
                }

                // Se la ritenuta non è presente in DS.contrattodipritenuta ed è presente in Out.Tables[0] aggiungo la riga di DS
                foreach (DataRow R in Out.Tables[0].Rows) {
                    string filter = QHS.CmpEq("taxcode", R["taxcode"]);
                    MetaData MetaRitenuta = MetaData.GetMetaData(this, "wageadditiontax");
                    MetaRitenuta.SetDefaults(DS.wageadditiontax);
                    DataRow[] riten = DS.wageadditiontax.Select(filter);
                    DataRow newRit = (riten.Length > 0)
                        ? riten[0]
                        : MetaRitenuta.Get_New_Row(Curr, DS.wageadditiontax);
                    foreach (DataColumn C in Out.Tables[0].Columns) {
                        if (DS.wageadditiontax.Columns[C.ColumnName] == null) continue;
                        newRit[C.ColumnName] = R[C.ColumnName];
                    }
                    newRit["!tiporitenuta"] = R["taxkind"];
                }
                lastParams = currParams;
            }
            // Dichiarazione delle var. che conterranno la somma delle ritenute
            decimal sumdipendente = 0;
            decimal sumamministrazione = 0;
            decimal previdAmmin = 0;
            decimal previdDipend = 0;
            decimal nonprevidAmmin = 0;

            // Calcolo la somma delle ritenute c/dip e c/amm non fiscali e previdenziali
            foreach (DataRow Rit in DS.wageadditiontax.Select()) {
                double NumDip = CfgFn.GetNoNullDouble(Rit["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(Rit["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(Rit["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(Rit["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(Rit["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(Rit["taxabledenominator"]);
                decimal AliDip = CfgFn.GetNoNullDecimal(Rit["employrate"]);
                decimal AliAmm = CfgFn.GetNoNullDecimal(Rit["adminrate"]);

                string tiporitenuta = Rit["!tiporitenuta"].ToString();

                if ((tiporitenuta == "2") || (tiporitenuta == "3")) {
                    decimal dip = CfgFn.DecMulDiv(AliDip, NumDip, DenDip);
                    dip = CfgFn.DecMulDiv(dip, NumImp, DenImp);
                    sumdipendente += dip;
                    decimal amm = CfgFn.DecMulDiv(AliAmm, NumAmm, DenAmm);
                    amm = CfgFn.DecMulDiv(amm, NumImp, DenImp);
                    sumamministrazione += amm;

                    if (tiporitenuta == "3") {
                        previdAmmin += amm;
                        previdDipend += dip;
                    }
                    else {
                        nonprevidAmmin += amm;
                    }
                }
            }

            decimal imponibileass = 0;
            decimal imponibilefisc = 0;
            decimal contributi = 0;

            decimal lordoAlBeneficiario = 0;
            decimal costoTotale = 0;
            decimal imponibileFiscale = 0;

            switch (tipoImporto) {
                // Caso 1: Inserito Imponibile Fiscale
                case ImportoDiPartenza.imponibileFiscale: {
                    imponibilefisc = importoInserito;
                    // L'imponibile fiscale dipende dalle ritenute previdenziali e assicurative
                    if (flagcalcimpfiscale == "N") {
                        imponibileass = imponibilefisc/(1 - sumdipendente);
                    }
                    // L'imponibile fiscale non dipende dalle ritenute previdenziali e assicurative
                    else {
                        imponibileass = imponibilefisc;
                    }
                    break;
                }
                // Caso 2: Inserito Omnicomprensivo
                case ImportoDiPartenza.compensoOmnicomprensivo: {
                    imponibileass = importoInserito/(1 + sumamministrazione);
                    // L'imponibile fiscale dipende dalle ritenute previdenziali e assicurative
                    if (flagcalcimpfiscale == "N") {
                        imponibilefisc = imponibileass*(1 - sumdipendente);
                    }
                    // L'imponibile fiscale non dipende dalle ritenute previdenziali e assicurative
                    else {
                        imponibilefisc = imponibileass;
                    }
                    break;
                }
                // Caso 3: Inserito Lordo al Beneficiario
                case ImportoDiPartenza.compensoLordo: {
                    imponibileass = importoInserito;
                    // L'imponibile fiscale dipende dalle ritenute previdenziali e assicurative
                    if (flagcalcimpfiscale == "N") {
                        imponibilefisc = imponibileass*(1 - sumdipendente);
                    }
                    // L'imponibile fiscale non dipende dalle ritenute previdenziali e assicurative
                    else {
                        imponibilefisc = imponibileass;
                    }
                    break;
                }
            }

            // Calcola le ritenute non fiscali
            decimal sommaritdipendente = 0;
            foreach (DataRow R in DS.wageadditiontax.Select(QHC.CmpNe("!tiporitenuta", 1))) {
                double NumDip = CfgFn.GetNoNullDouble(R["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(R["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(R["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(R["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(R["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(R["taxabledenominator"]);
                decimal AliDip = CfgFn.GetNoNullDecimal(R["employrate"]);
                decimal AliAmm = CfgFn.GetNoNullDecimal(R["adminrate"]);

                decimal imponibile = 0;
                decimal ritdipendente = 0;
                decimal ritammin = 0;
                string tiporitenuta = R["!tiporitenuta"].ToString().ToUpper();

                imponibile = CfgFn.DecMulDiv(imponibileass, NumImp, DenImp);
                ritdipendente = CfgFn.DecMulDiv(imponibile*AliDip, NumDip, DenDip);
                ritammin = CfgFn.DecMulDiv(imponibile*AliAmm, NumAmm, DenAmm);
                contributi += CfgFn.RoundValuta(ritammin);

                R["taxable"] = CfgFn.RoundValuta(imponibile);
                R["employtax"] = CfgFn.RoundValuta(ritdipendente);
                R["admintax"] = CfgFn.RoundValuta(ritammin);

                sommaritdipendente += CfgFn.RoundValuta(ritdipendente);
            }

            //calcola le ritenute fiscali
            foreach (DataRow R in DS.wageadditiontax.Select(QHC.CmpEq("!tiporitenuta", 1))) {
                double NumDip = CfgFn.GetNoNullDouble(R["employnumerator"]);
                double DenDip = CfgFn.GetNoNullDouble(R["employdenominator"]);
                double NumAmm = CfgFn.GetNoNullDouble(R["adminnumerator"]);
                double DenAmm = CfgFn.GetNoNullDouble(R["admindenominator"]);
                double NumImp = CfgFn.GetNoNullDouble(R["taxablenumerator"]);
                double DenImp = CfgFn.GetNoNullDouble(R["taxabledenominator"]);
                decimal AliDip = CfgFn.GetNoNullDecimal(R["employrate"]);
                decimal AliAmm = CfgFn.GetNoNullDecimal(R["adminrate"]);

                string tiporitenuta = R["!tiporitenuta"].ToString().ToUpper();

                decimal imponibile = CfgFn.DecMulDiv(imponibilefisc, NumImp, DenImp);
                decimal ritdipendente = CfgFn.DecMulDiv(imponibilefisc*AliDip, NumDip, DenDip);
                decimal ritammin = CfgFn.DecMulDiv(imponibilefisc*AliAmm, NumAmm, DenAmm);

                contributi += CfgFn.RoundValuta(ritammin);

                R["taxable"] = CfgFn.RoundValuta(imponibile);
                R["employtax"] = CfgFn.RoundValuta(ritdipendente);
                R["admintax"] = CfgFn.RoundValuta(ritammin);
            }
            Meta.myGetData.GetTemporaryValues(DS.wageadditiontax);

            imponibileFiscale = CfgFn.RoundValuta(imponibilefisc);
            costoTotale = CfgFn.RoundValuta(imponibileass + contributi);
            lordoAlBeneficiario = CfgFn.RoundValuta(imponibileass);

            costoTotaleDaLordoAlBeneficiario = costoTotale;
            imponibileFiscaleDaLordoAlBeneficiario = imponibileFiscale;

            // Copia dei dati nei text box
            txtLordoAlBeneficiario.Text = lordoAlBeneficiario.ToString("c");
            txtCostoTotaleInput.Text = costoTotale.ToString("c");
            txtImponibileFiscale.Text = imponibileFiscale.ToString("c");
            calcolaTxtNonGestiti();
        }


        private decimal getDecimalFromTextBox(TextBox text) {
            string tag = "";
            if ((text.Tag == null) || (text.Tag.ToString() == "")) {
                tag = "x.x";
            }
            else {
                tag = text.Tag.ToString();
            }

            decimal valore = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), text.Text, tag));
            return valore;
        }

        private void txtLordoAlBeneficiario_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            decimal importo = getDecimalFromTextBox(txtLordoAlBeneficiario);
            calcolaRitenute(ImportoDiPartenza.compensoLordo, importo, true);
        }

        private void txtCostoTotaleInput_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            decimal importo = getDecimalFromTextBox(txtCostoTotaleInput);
            calcolaRitenute(ImportoDiPartenza.compensoOmnicomprensivo, importo, true);
        }

        private void txtImponibileFiscale_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            decimal importo = getDecimalFromTextBox(txtImponibileFiscale);
            calcolaRitenute(ImportoDiPartenza.imponibileFiscale, importo, true);
        }

        private void txtDataContabile_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if ((Meta.IsEmpty) || (!Meta.DrawStateIsDone)) return;
            object currDataContabile = HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text,
                txtDataContabile.Tag.ToString());
            DataRow Curr = DS.wageaddition.Rows[0];
            // Caso 1: Inserimento di un valore errato (per esempio 1), viene assegnata al text box la data contabile
            // con cui si è loggati
            if (currDataContabile == null) {
                DateTime dataOdierna = (DateTime) Meta.GetSys("datacontabile");
                lastDataContabile = dataOdierna;
            }
            // Caso 2: Data contabile vuota, assegno il valore della data vuota (1/1/1900)
            if (currDataContabile == DBNull.Value) {
                lastDataContabile = dataVuota;
            }
            // Caso 3: Inserimento corretto della data contabile
            if ((currDataContabile != null) && (currDataContabile != DBNull.Value)) {
                lastDataContabile = (DateTime) currDataContabile;
            }
            currParams = Curr["idreg"] + "#" + Curr["idser"] + "#" + lastDataContabile;
            decimal importo = getDecimalFromTextBox(txtLordoAlBeneficiario);
            if (currParams == lastParams) return;
            calcolaRitenute(ImportoDiPartenza.compensoLordo, importo, false);
        }

        string idrelated = "";
        //string idrelatedBudget = "";
        //bool fromDelete = false;
        string filterDeleteImputazione = "";

        public void MetaData_BeforePost() {
            filterDeleteImputazione = "";
            if (DS.wageaddition.Rows.Count == 0) return;
            EPM.beforePost();

            DataRow Curr = DS.wageaddition.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
               filterDeleteImputazione = QHS.AppAnd(QHS.CmpEq("ycon", Curr["ycon", DataRowVersion.Original]),
                   QHS.CmpEq("ncon", Curr["ncon", DataRowVersion.Original]));
            }
            else {
                filterDeleteImputazione = "";
            }
        }


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
                string script = "delete from wageadditionyear where  "
                                + filterDeleteImputazione;
                Meta.Conn.SQLRunner(script);
            }

            EPM.afterPost();

            if (Meta.PrimaryDataTable.Rows.Count > 0) {
                VisualizzaEtichetteAP();
                AvvisoAnagrafePrestazioni();
            }
            //Cancella riga imputazione di altri esercizi
          

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

        private void btnVisualizzaEP_Click(object sender, System.EventArgs e) {

        }

        private void btnGeneraEP_Click(object sender, System.EventArgs e) {

        }

        private void btnGeneraEpExp_Click(object sender, System.EventArgs e) {

        }

        private void btnVisualizzaEpExp_Click(object sender, System.EventArgs e) {

        }

        void VisualizzaEtichetteAP() {
            if (DS.wageaddition.Rows.Count > 0 && (DS.wageaddition.Rows[0].RowState == DataRowState.Unchanged)) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = true;
                btnCollegaAP.Visible = true;
            }
            else {
                if (Meta.InsertMode || DS.wageaddition.Rows.Count == 0) // || DS.entrysetup.Rows.Count==0)
                {
                    labAPnongenerato.Visible = false;
                    labAPgenerato.Visible = false;
                    btnVisualizzaAP.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                    return;
                }
            }

            string idrelated = AP_fun.GetIdForDocument(DS.wageaddition.Rows[0]);
            if (Meta.Conn.RUN_SELECT_COUNT("serviceregistry", QHS.CmpEq("idrelated", idrelated), true) == 0) {
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
            DataRow curr = DS.wageaddition.Rows[0];
            if (curr["start"] == DBNull.Value) return false;
            String codeaddress = "07_SW_ANP";
            object idaddresskind = Meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DateTime DataInizio = (DateTime) curr["start"];
            if (DataInizio.Year < 1900) DataInizio = new DateTime(1900, 1, 1);
            DataTable Address = DataAccess.RUN_SELECT(Meta.Conn, "registryaddress", "*", null,
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
            if (DS.wageaddition.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.wageaddition.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }
            object idser = Curr["idser"];
            if (!(idser == DBNull.Value || CfgFn.GetNoNullInt32(idser) == 0)) {
                string filter = QHC.CmpEq("idser", idser);
                DataRow[] prestazione = DS.service.Select(filter);
                string codeser = "";
                if (prestazione.Length > 0)
                    codeser = prestazione[0]["codeser"].ToString().ToUpper();
                if (codeser == "08_PREMI") {
                    show("Su Premi di studio e altri premi non è possibile " +
                                    "\ngenerare l'Anagrafe delle Prestazioni");
                    return;
                }
                if (codeser == "08_CONTRIB_C_ESERC") {
                    show("Sui contributi in conto esercizio non è possibile " +
                                    "\ngenerare l'Anagrafe delle Prestazioni");
                    return;
                }
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

            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in ToMeta.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }

            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
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
            if (DS.wageaddition.Rows.Count == 0) return;
            AP_fun AP = new AP_fun(Meta.Dispatcher);
            AP.EditRelatedServiceRegistry(Meta, DS.wageaddition.Rows[0]);
        }

        private void btnVisualizzaAP_Click(object sender, System.EventArgs e) {
            EditServiceRegistry();
        }

        void resetPosizioneGiuridica() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.wageaddition.Rows[0];
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
            DataRow Curr = DS.wageaddition.Rows[0];

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

        public void VisualizzaBtnCambiaRuolo() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.wageaddition.Rows[0];

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

        /// <summary>
        /// Calcola il GroupBox PosizioneGiuridica in base alla datainizio della riga corrente
        /// </summary>
        private void ImpostaPosGiuridica(bool changerole) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.wageaddition.Rows[0];

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
                    null, QHS.AppAnd(QHS.CmpEq("idreg", codicecreddeb),
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

        private void btnCambiaRuolo_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            ImpostaPosGiuridica(true);

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

        private void btnRicalcola_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (DS.wageaddition.Rows.Count == 0) return;
            decimal importo = getDecimalFromTextBox(txtLordoAlBeneficiario);
            lastParams = "";
            calcolaRitenute(ImportoDiPartenza.compensoLordo, importo, false);
        }

        private void rdbNonApplicabile_CheckedChanged(object sender, EventArgs e) {
            VisualizzaEtichetteAP();
        }

        private void btnCollegaAP_Click(object sender, EventArgs e) {
            if (DS.wageaddition.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.wageaddition.Rows[0];
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
            Meta.FreshForm(true);

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

        private void btnTrasfdipendenti_Click(object sender, EventArgs e) {
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
                DataRow MyRow = HelpForm.GetLastSelected(DS.wageaddition);
            }
            catch {
                return;
            }

            DataSet Out = Meta.Conn.CallSP("closeyear_wageaddition_trasfsingle",
                new Object[3] {
                    Meta.GetSys("esercizio").ToString(),
                    Convert.ToInt32(DS.Tables["wageaddition"].Rows[0]["ycon"]),
                    Convert.ToInt32(DS.Tables["wageaddition"].Rows[0]["ncon"])
                }
            );
            if (Out == null) return;
            show(this, "Trasferimento effettuato");
        }

		private void btnRipartizione_Click(object sender, EventArgs e)
		{

			if (Meta.IsEmpty)
				return;

			if (DS.wageaddition.Rows.Count == 0)
				return;

			DataRow curr = DS.wageaddition.Rows[0];
			if (curr == null)
				return;

			object idcostpartition = curr["idcostpartition"];

			if (idcostpartition != DBNull.Value)
			{
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
			else
			{
				idcostpartition = EP_functions.importCostPartitionDetail(Meta);
				if (idcostpartition == null)
					return;
				curr["idcostpartition"] = idcostpartition;
			}
		}
	}
}
