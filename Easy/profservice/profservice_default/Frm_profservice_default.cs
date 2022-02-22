
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using ep_functions;
using ap_functions;

namespace profservice_default { //contrattoprofessionale//

    /// <summary>
    /// Summary description for frmcontrattoprofessionale.
    /// </summary>
    public class Frm_profservice_default : MetaDataForm {
        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabContratto;
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.TextBox txtDurataGiorni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataInizio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabRitenute;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.TabPage tabCalcolo;
        private System.Windows.Forms.Label lblRitenuta;
        private System.Windows.Forms.TextBox txtCompensoLordo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCostoTotale;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtImportoNetto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelImponibileFiscale;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        MetaData Meta;
        private System.Windows.Forms.TextBox txtImportoIVA;
        private System.Windows.Forms.TextBox txtImportoContrCassaPrev;
        private System.Windows.Forms.TextBox txtImportoAddebContrPrev;
        private System.Windows.Forms.TextBox txtImponibileIVA;
        private System.Windows.Forms.TextBox txtPercContrCassaPrev;
        private System.Windows.Forms.TextBox txtPercAddebContrPrev;
        int lastCreditore = 0;
        int lastPrestazioneRitenute = 0;
        int lastPrestazioneCalcolo = 0;
//		string lastRitenuta = "";
        DateTime lastDataContabile = QueryCreator.EmptyDate();
        decimal lastCompensoLordo = 0;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtAliquotaRitFisc;
        private System.Windows.Forms.TextBox txtImportoRitenuta;
        private System.Windows.Forms.TextBox txtImponibileFiscale;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TabPage tabSpese;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        decimal lastTotSpese = 0;
        decimal lastTotSpeseNoIva = 0;
        decimal lastTotSpeseNoF = 0;
        decimal lastTotSpeseNoP = 0;
        decimal lastTotSpeseDed = 0;
        private System.Windows.Forms.TextBox txtTotaleSpese;
        private System.Windows.Forms.TabPage tabClassSuppl;
        private System.Windows.Forms.DataGrid dgrClassSuppl;
        private System.Windows.Forms.Button btnClassElimina;
        private System.Windows.Forms.Button btnClassModifica;
        private System.Windows.Forms.Button btnClassInserisci;
        bool inChiusura;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabFatturazione;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.TextBox txtEsercDocumento;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.GroupBox gboxInvoice;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAnalitico;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.ComboBox cmbTipoIVA;
        private System.Windows.Forms.Label label27;
        DataAccess Conn;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btnscollegainvoice;
        private System.Windows.Forms.ComboBox cmbInvoice;
        private System.Windows.Forms.TabPage tabAP;
        private System.Windows.Forms.Label labAPnongenerato;
        private System.Windows.Forms.Label labAPgenerato;
        private System.Windows.Forms.Button btnGeneraAP;
        private System.Windows.Forms.Button btnVisualizzaAP;
        private Label label45;
        private Label label46;
        private TextBox txtSpeseDed;
        private Label label47;
        private Label label49;
        private TextBox txtSpeseNoF;
        private Label label50;
        private Panel panel6;
        private Label label52;
        private TextBox txtImponibilePrevidenza;
        private Label label53;
        private Label label48;
        private TextBox txtSpeseNoP;
        private Label label51;
        private Label label54;
        private Label label55;
        private TextBox txtSpeseNoIva;
        private Label label56;
        private Label label15;
        private TextBox txtDenImponibile;
        private TextBox txtNumImponibile;
        private GroupBox grpBoxMotivo;
        private TextBox txtMotivoAut;
        private GroupBox grpBoxDocAutorizzattivo;
        private TextBox txtDocumentoAut;
        private Label label58;
        private TextBox txtDataDocumentoAut;
        private Label label59;
        private GroupBox grpBoxAutorizzazioneAP;
        private RadioButton rdbAutorizzazioneNonNecessaria;
        private RadioButton rdbNonApplicabile;
        private RadioButton rdbNecessitaAutorizzazione;
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
        private Label label60;
        private TextBox txtContributi;
        private Label label61;
        private Label label62;
        private TextBox txtAltreRit;
        private Label label63;
        private TextBox txtLordoBeneficiario;
        private Label label64;
        private Button btnCollegaAP;
        private TabPage tabPage2;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private Button btnGeneraPreImpegni;
        private Button btnViewPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private Label label57;
        private TextBox textBox4;
        private GroupBox groupBox11;
        private TextBox textBox6;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox groupBox10;
        private TextBox textBox7;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private GroupBox groupBox1;
        private TextBox textBox5;
        private TextBox txtCodiceCausale;
        private Button button5;
        private GroupBox gBoxCompetenza;
        private RadioButton rdEPKind_N;
        private RadioButton rdEPKind_F;
        private RadioButton rdEPKind_R;
        private TabPage tabDALIA;
        private GroupBox groupBox2;
        private Label label91;
        private TextBox textBox8;
        private ComboBox cmb_dalia_position;
        private TabPage tabANAC;
        private TabControl tabControlAnac;
        private TabPage tabPartecipanti;
        private Button btnAggiungiAggiudicatario;
        private Label label65;
        private DataGrid gridAVCP;
        private Button btnLottiAppaltati;
        private Button btnDelAVCP;
        private Button btnEditAVCP;
        private Button btnLottiPartecipati;
        private Button btnInsAVCP;
        private TabPage tabLotti;
        private Button button4;
        private Button btnPartecipantiNonAssociati;
        private Button btnPartecipantiAlLotto;
        private Button btnOrdiniNoPartecipanti;
        private Button button8;
        private Button btnOrdiniNoLotti;
        private Button button9;
        private Label label66;
        private DataGrid gridLotti;
        private Button btnVoceSpesaDalia;
        private TextBox txtVoceSpesaDalia;
        private Button btnQualificaDalia;
        private Label label67;
        private GroupBox grpBoxSiopeEP;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnSiope;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkVisura;
        private CheckBox chkCCdedicato;
        private GroupBox grpCausaliAssunzioneDalia;
        private TextBox txtCausaleAssunzione;
        private Button btnEsclusioneCIG;
        private GroupBox groupBox3;
        private ComboBox cmbDaliaFunzionale;
        private GroupBox gboxDipartimento;
        private Button btnDipartimento;
        private TextBox txtCodiceDipartimento;
        public TextBox txtDaliaDipartimento;
		private CheckBox chkDurc;
		private CheckBox chkVerificaAnac;
		private CheckBox chkRegolaritaFisc;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkCasellarioGiud;
		private CheckBox SubEntity_chkExcludeFromCertificate;
		private TabPage tabAllegati;
		private DataGrid dgrAllegati;
		private Button btnDelAtt;
		private Button btnEditAtt;
		private Button btnInsAtt;
		private decimal aliquota = 0;

        public Frm_profservice_default() {
            InitializeComponent();
            HelpForm.SetFormatForColumn(DS.profservice.Columns["socialsecurityrate"], "p");
            HelpForm.SetFormatForColumn(DS.profservice.Columns["pensioncontributionrate"], "p");
            HelpForm.SetFormatForColumn(DS.profservice.Columns["ivarate"], "p");
            HelpForm.SetDenyNull(DS.profservice.Columns["flaginvoiced"], true);
            HelpForm.SetDenyNull(DS.profservice.Columns["flagmixed"], true);
            HelpForm.SetDenyNull(DS.Tables["profrefund"].Columns["flagfiscaldeduction"], true);
            HelpForm.SetDenyNull(DS.Tables["profrefund"].Columns["flagivadeduction"], true);
            HelpForm.SetDenyNull(DS.Tables["profrefund"].Columns["flagsecuritydeduction"], true);
			HelpForm.SetDenyNull(DS.profservice.Columns["flagexcludefromcertificate"], true);
            cmbDaliaFunzionale.DataSource = DS.dalia_funzionale;
            cmbDaliaFunzionale.DisplayMember = "title";
            cmbDaliaFunzionale.ValueMember = "iddalia_funzionale";
            inChiusura = false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_profservice_default));
			this.DS = new profservice_default.vistaForm();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabContratto = new System.Windows.Forms.TabPage();
			this.SubEntity_chkExcludeFromCertificate = new System.Windows.Forms.CheckBox();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
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
			this.txtDataFine = new System.Windows.Forms.TextBox();
			this.txtDurataGiorni = new System.Windows.Forms.TextBox();
			this.txtDataInizio = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.tabCalcolo = new System.Windows.Forms.TabPage();
			this.label67 = new System.Windows.Forms.Label();
			this.txtLordoBeneficiario = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.txtAltreRit = new System.Windows.Forms.TextBox();
			this.label63 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.txtContributi = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDenImponibile = new System.Windows.Forms.TextBox();
			this.txtNumImponibile = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txtSpeseNoIva = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.label54 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.txtImponibilePrevidenza = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.txtSpeseNoP = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label49 = new System.Windows.Forms.Label();
			this.txtSpeseNoF = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.txtSpeseDed = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.btnTipo = new System.Windows.Forms.Button();
			this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.txtTotaleSpese = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.labelImponibileFiscale = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.labelInfo2 = new System.Windows.Forms.Label();
			this.txtImportoRitenuta = new System.Windows.Forms.TextBox();
			this.txtImportoIVA = new System.Windows.Forms.TextBox();
			this.txtImportoContrCassaPrev = new System.Windows.Forms.TextBox();
			this.txtImportoAddebContrPrev = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.labelInfo1 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtAliquotaRitFisc = new System.Windows.Forms.TextBox();
			this.txtImponibileFiscale = new System.Windows.Forms.TextBox();
			this.txtImponibileIVA = new System.Windows.Forms.TextBox();
			this.txtPercContrCassaPrev = new System.Windows.Forms.TextBox();
			this.txtPercAddebContrPrev = new System.Windows.Forms.TextBox();
			this.txtImportoNetto = new System.Windows.Forms.TextBox();
			this.txtCostoTotale = new System.Windows.Forms.TextBox();
			this.txtCompensoLordo = new System.Windows.Forms.TextBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label21 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.lblRitenuta = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tabRitenute = new System.Windows.Forms.TabPage();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tabSpese = new System.Windows.Forms.TabPage();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabFatturazione = new System.Windows.Forms.TabPage();
			this.btnscollegainvoice = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
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
			this.gboxInvoice = new System.Windows.Forms.GroupBox();
			this.txtNumDocumento = new System.Windows.Forms.TextBox();
			this.txtEsercDocumento = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.cmbInvoice = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabClassSuppl = new System.Windows.Forms.TabPage();
			this.btnClassElimina = new System.Windows.Forms.Button();
			this.btnClassModifica = new System.Windows.Forms.Button();
			this.btnClassInserisci = new System.Windows.Forms.Button();
			this.dgrClassSuppl = new System.Windows.Forms.DataGrid();
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
			this.grpBoxMotivo = new System.Windows.Forms.GroupBox();
			this.txtMotivoAut = new System.Windows.Forms.TextBox();
			this.grpBoxDocAutorizzattivo = new System.Windows.Forms.GroupBox();
			this.txtDocumentoAut = new System.Windows.Forms.TextBox();
			this.label58 = new System.Windows.Forms.Label();
			this.txtDataDocumentoAut = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.grpBoxAutorizzazioneAP = new System.Windows.Forms.GroupBox();
			this.rdbAutorizzazioneNonNecessaria = new System.Windows.Forms.RadioButton();
			this.rdbNonApplicabile = new System.Windows.Forms.RadioButton();
			this.rdbNecessitaAutorizzazione = new System.Windows.Forms.RadioButton();
			this.btnGeneraAP = new System.Windows.Forms.Button();
			this.btnVisualizzaAP = new System.Windows.Forms.Button();
			this.labAPnongenerato = new System.Windows.Forms.Label();
			this.labAPgenerato = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.gBoxCompetenza = new System.Windows.Forms.GroupBox();
			this.rdEPKind_N = new System.Windows.Forms.RadioButton();
			this.rdEPKind_F = new System.Windows.Forms.RadioButton();
			this.rdEPKind_R = new System.Windows.Forms.RadioButton();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.btnGeneraPreImpegni = new System.Windows.Forms.Button();
			this.btnViewPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label91 = new System.Windows.Forms.Label();
			this.btnQualificaDalia = new System.Windows.Forms.Button();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.cmb_dalia_position = new System.Windows.Forms.ComboBox();
			this.tabANAC = new System.Windows.Forms.TabPage();
			this.tabControlAnac = new System.Windows.Forms.TabControl();
			this.tabPartecipanti = new System.Windows.Forms.TabPage();
			this.btnAggiungiAggiudicatario = new System.Windows.Forms.Button();
			this.label65 = new System.Windows.Forms.Label();
			this.gridAVCP = new System.Windows.Forms.DataGrid();
			this.btnLottiAppaltati = new System.Windows.Forms.Button();
			this.btnDelAVCP = new System.Windows.Forms.Button();
			this.btnEditAVCP = new System.Windows.Forms.Button();
			this.btnLottiPartecipati = new System.Windows.Forms.Button();
			this.btnInsAVCP = new System.Windows.Forms.Button();
			this.tabLotti = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.btnPartecipantiNonAssociati = new System.Windows.Forms.Button();
			this.btnPartecipantiAlLotto = new System.Windows.Forms.Button();
			this.btnOrdiniNoPartecipanti = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.btnOrdiniNoLotti = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.label66 = new System.Windows.Forms.Label();
			this.gridLotti = new System.Windows.Forms.DataGrid();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.label57 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFisc = new System.Windows.Forms.CheckBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dgrAllegati = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabContratto.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.grpPrestazione.SuspendLayout();
			this.grpPercipiente.SuspendLayout();
			this.grpContratto.SuspendLayout();
			this.tabCalcolo.SuspendLayout();
			this.panel4.SuspendLayout();
			this.tabRitenute.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabSpese.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabFatturazione.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.gboxInvoice.SuspendLayout();
			this.tabClassSuppl.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassSuppl)).BeginInit();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAP.SuspendLayout();
			this.grpBoxMotivo.SuspendLayout();
			this.grpBoxDocAutorizzattivo.SuspendLayout();
			this.grpBoxAutorizzazioneAP.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.gBoxCompetenza.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabDALIA.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gboxDipartimento.SuspendLayout();
			this.grpCausaliAssunzioneDalia.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabANAC.SuspendLayout();
			this.tabControlAnac.SuspendLayout();
			this.tabPartecipanti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAVCP)).BeginInit();
			this.tabLotti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLotti)).BeginInit();
			this.groupBox11.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrAllegati)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabContratto);
			this.tabControl1.Controls.Add(this.tabCalcolo);
			this.tabControl1.Controls.Add(this.tabRitenute);
			this.tabControl1.Controls.Add(this.tabSpese);
			this.tabControl1.Controls.Add(this.tabFatturazione);
			this.tabControl1.Controls.Add(this.tabClassSuppl);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAP);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabDALIA);
			this.tabControl1.Controls.Add(this.tabANAC);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ImageList = this.imageList1;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(951, 580);
			this.tabControl1.TabIndex = 1;
			// 
			// tabContratto
			// 
			this.tabContratto.Controls.Add(this.SubEntity_chkExcludeFromCertificate);
			this.tabContratto.Controls.Add(this.grpCertificatiNecessari);
			this.tabContratto.Controls.Add(this.textBox3);
			this.tabContratto.Controls.Add(this.textBox1);
			this.tabContratto.Controls.Add(this.label38);
			this.tabContratto.Controls.Add(this.txtDataContabile);
			this.tabContratto.Controls.Add(this.label22);
			this.tabContratto.Controls.Add(this.textBox2);
			this.tabContratto.Controls.Add(this.label8);
			this.tabContratto.Controls.Add(this.grpPrestazione);
			this.tabContratto.Controls.Add(this.grpPercipiente);
			this.tabContratto.Controls.Add(this.grpContratto);
			this.tabContratto.Controls.Add(this.txtDataFine);
			this.tabContratto.Controls.Add(this.txtDurataGiorni);
			this.tabContratto.Controls.Add(this.txtDataInizio);
			this.tabContratto.Controls.Add(this.label3);
			this.tabContratto.Controls.Add(this.label4);
			this.tabContratto.Controls.Add(this.label5);
			this.tabContratto.Controls.Add(this.label39);
			this.tabContratto.Location = new System.Drawing.Point(4, 23);
			this.tabContratto.Name = "tabContratto";
			this.tabContratto.Size = new System.Drawing.Size(943, 553);
			this.tabContratto.TabIndex = 0;
			this.tabContratto.Text = "Generale";
			this.tabContratto.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkExcludeFromCertificate
			// 
			this.SubEntity_chkExcludeFromCertificate.AutoSize = true;
			this.SubEntity_chkExcludeFromCertificate.Location = new System.Drawing.Point(8, 105);
			this.SubEntity_chkExcludeFromCertificate.Name = "SubEntity_chkExcludeFromCertificate";
			this.SubEntity_chkExcludeFromCertificate.Size = new System.Drawing.Size(225, 17);
			this.SubEntity_chkExcludeFromCertificate.TabIndex = 117;
			this.SubEntity_chkExcludeFromCertificate.Tag = "profservice.flagexcludefromcertificate:S:N";
			this.SubEntity_chkExcludeFromCertificate.Text = "Escludi da Certificazione Unica dei Redditi";
			this.SubEntity_chkExcludeFromCertificate.UseVisualStyleBackColor = true;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(8, 347);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(243, 103);
			this.grpCertificatiNecessari.TabIndex = 116;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(18, 72);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(57, 17);
			this.chkDurc.TabIndex = 93;
			this.chkDurc.Tag = "profservice.requested_doc:2";
			this.chkDurc.Text = "DURC";
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(18, 49);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(101, 17);
			this.chkVisura.TabIndex = 92;
			this.chkVisura.Tag = "profservice.requested_doc:1";
			this.chkVisura.Text = "Visura camerale";
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(18, 26);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "profservice.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(684, 48);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(104, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.Tag = "profservice.docdate";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(684, 16);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 5;
			this.textBox1.Tag = "profservice.doc";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(598, 16);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(80, 23);
			this.label38.TabIndex = 24;
			this.label38.Text = "Documento";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(257, 48);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
			this.txtDataContabile.TabIndex = 4;
			this.txtDataContabile.Tag = "profservice.adate";
			this.txtDataContabile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(171, 48);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 23);
			this.label22.TabIndex = 23;
			this.label22.Text = "Data Contabile";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(8, 265);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(568, 65);
			this.textBox2.TabIndex = 9;
			this.textBox2.Tag = "profservice.description";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 251);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 23);
			this.label8.TabIndex = 21;
			this.label8.Text = "Descrizione";
			// 
			// grpPrestazione
			// 
			this.grpPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrestazione.Controls.Add(this.btnTipoPrestazione);
			this.grpPrestazione.Controls.Add(this.cmbTipoPrestazione);
			this.grpPrestazione.Location = new System.Drawing.Point(8, 189);
			this.grpPrestazione.Name = "grpPrestazione";
			this.grpPrestazione.Size = new System.Drawing.Size(568, 48);
			this.grpPrestazione.TabIndex = 8;
			this.grpPrestazione.TabStop = false;
			this.grpPrestazione.Text = "Prestazione";
			// 
			// btnTipoPrestazione
			// 
			this.btnTipoPrestazione.Location = new System.Drawing.Point(8, 16);
			this.btnTipoPrestazione.Name = "btnTipoPrestazione";
			this.btnTipoPrestazione.Size = new System.Drawing.Size(75, 24);
			this.btnTipoPrestazione.TabIndex = 1;
			this.btnTipoPrestazione.Tag = "choose.service.default";
			this.btnTipoPrestazione.Text = "Tipo";
			// 
			// cmbTipoPrestazione
			// 
			this.cmbTipoPrestazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoPrestazione.DataSource = this.DS.service;
			this.cmbTipoPrestazione.DisplayMember = "description";
			this.cmbTipoPrestazione.ItemHeight = 13;
			this.cmbTipoPrestazione.Location = new System.Drawing.Point(96, 17);
			this.cmbTipoPrestazione.Name = "cmbTipoPrestazione";
			this.cmbTipoPrestazione.Size = new System.Drawing.Size(464, 21);
			this.cmbTipoPrestazione.TabIndex = 2;
			this.cmbTipoPrestazione.Tag = "profservice.idser";
			this.cmbTipoPrestazione.ValueMember = "idser";
			// 
			// grpPercipiente
			// 
			this.grpPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPercipiente.Controls.Add(this.txtPercipiente);
			this.grpPercipiente.Location = new System.Drawing.Point(8, 138);
			this.grpPercipiente.Name = "grpPercipiente";
			this.grpPercipiente.Size = new System.Drawing.Size(568, 45);
			this.grpPercipiente.TabIndex = 7;
			this.grpPercipiente.TabStop = false;
			this.grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active=\'S\') and (((p_iva != \'\') and (p_iva is" +
    " not null)) or ((foreigncf != \'\') and (foreigncf is not null))))";
			this.grpPercipiente.Text = "Percipiente";
			// 
			// txtPercipiente
			// 
			this.txtPercipiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercipiente.Location = new System.Drawing.Point(8, 17);
			this.txtPercipiente.Name = "txtPercipiente";
			this.txtPercipiente.Size = new System.Drawing.Size(552, 20);
			this.txtPercipiente.TabIndex = 0;
			this.txtPercipiente.Tag = "registry.title?profserviceview.registry";
			// 
			// grpContratto
			// 
			this.grpContratto.Controls.Add(this.label2);
			this.grpContratto.Controls.Add(this.txtEsercizio);
			this.grpContratto.Controls.Add(this.txtNumContratto);
			this.grpContratto.Controls.Add(this.label1);
			this.grpContratto.Location = new System.Drawing.Point(8, 8);
			this.grpContratto.Name = "grpContratto";
			this.grpContratto.Size = new System.Drawing.Size(157, 81);
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
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(62, 16);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.Size = new System.Drawing.Size(74, 20);
			this.txtEsercizio.TabIndex = 2;
			this.txtEsercizio.Tag = "profservice.ycon.year";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Location = new System.Drawing.Point(62, 48);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.Size = new System.Drawing.Size(74, 20);
			this.txtNumContratto.TabIndex = 3;
			this.txtNumContratto.Tag = "profservice.ncon";
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
			// txtDataFine
			// 
			this.txtDataFine.Location = new System.Drawing.Point(470, 16);
			this.txtDataFine.Name = "txtDataFine";
			this.txtDataFine.Size = new System.Drawing.Size(104, 20);
			this.txtDataFine.TabIndex = 3;
			this.txtDataFine.Tag = "profservice.stop";
			this.txtDataFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataFine.TextChanged += new System.EventHandler(this.txtDataFine_TextChanged);
			// 
			// txtDurataGiorni
			// 
			this.txtDurataGiorni.Location = new System.Drawing.Point(470, 48);
			this.txtDurataGiorni.Name = "txtDurataGiorni";
			this.txtDurataGiorni.ReadOnly = true;
			this.txtDurataGiorni.Size = new System.Drawing.Size(104, 20);
			this.txtDurataGiorni.TabIndex = 16;
			this.txtDurataGiorni.TabStop = false;
			this.txtDurataGiorni.Tag = "profservice.ndays";
			// 
			// txtDataInizio
			// 
			this.txtDataInizio.Location = new System.Drawing.Point(257, 16);
			this.txtDataInizio.Name = "txtDataInizio";
			this.txtDataInizio.Size = new System.Drawing.Size(104, 20);
			this.txtDataInizio.TabIndex = 2;
			this.txtDataInizio.Tag = "profservice.start";
			this.txtDataInizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDataInizio.TextChanged += new System.EventHandler(this.txtDataInizio_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(171, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Data Inizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(398, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Data Fine";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(376, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 23);
			this.label5.TabIndex = 13;
			this.label5.Text = "Durata (Giorni)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(588, 48);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(90, 23);
			this.label39.TabIndex = 25;
			this.label39.Text = "Data Documento";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabCalcolo
			// 
			this.tabCalcolo.Controls.Add(this.label67);
			this.tabCalcolo.Controls.Add(this.txtLordoBeneficiario);
			this.tabCalcolo.Controls.Add(this.label64);
			this.tabCalcolo.Controls.Add(this.label62);
			this.tabCalcolo.Controls.Add(this.txtAltreRit);
			this.tabCalcolo.Controls.Add(this.label63);
			this.tabCalcolo.Controls.Add(this.label61);
			this.tabCalcolo.Controls.Add(this.txtContributi);
			this.tabCalcolo.Controls.Add(this.label60);
			this.tabCalcolo.Controls.Add(this.label15);
			this.tabCalcolo.Controls.Add(this.txtDenImponibile);
			this.tabCalcolo.Controls.Add(this.txtNumImponibile);
			this.tabCalcolo.Controls.Add(this.label55);
			this.tabCalcolo.Controls.Add(this.txtSpeseNoIva);
			this.tabCalcolo.Controls.Add(this.label56);
			this.tabCalcolo.Controls.Add(this.label54);
			this.tabCalcolo.Controls.Add(this.label52);
			this.tabCalcolo.Controls.Add(this.txtImponibilePrevidenza);
			this.tabCalcolo.Controls.Add(this.label53);
			this.tabCalcolo.Controls.Add(this.label48);
			this.tabCalcolo.Controls.Add(this.txtSpeseNoP);
			this.tabCalcolo.Controls.Add(this.label51);
			this.tabCalcolo.Controls.Add(this.panel6);
			this.tabCalcolo.Controls.Add(this.label49);
			this.tabCalcolo.Controls.Add(this.txtSpeseNoF);
			this.tabCalcolo.Controls.Add(this.label50);
			this.tabCalcolo.Controls.Add(this.label45);
			this.tabCalcolo.Controls.Add(this.label46);
			this.tabCalcolo.Controls.Add(this.txtSpeseDed);
			this.tabCalcolo.Controls.Add(this.label47);
			this.tabCalcolo.Controls.Add(this.label27);
			this.tabCalcolo.Controls.Add(this.btnTipo);
			this.tabCalcolo.Controls.Add(this.cmbTipoIVA);
			this.tabCalcolo.Controls.Add(this.txtIva);
			this.tabCalcolo.Controls.Add(this.label42);
			this.tabCalcolo.Controls.Add(this.label41);
			this.tabCalcolo.Controls.Add(this.txtTotaleSpese);
			this.tabCalcolo.Controls.Add(this.label40);
			this.tabCalcolo.Controls.Add(this.label37);
			this.tabCalcolo.Controls.Add(this.label36);
			this.tabCalcolo.Controls.Add(this.label35);
			this.tabCalcolo.Controls.Add(this.label34);
			this.tabCalcolo.Controls.Add(this.label33);
			this.tabCalcolo.Controls.Add(this.label32);
			this.tabCalcolo.Controls.Add(this.label31);
			this.tabCalcolo.Controls.Add(this.label30);
			this.tabCalcolo.Controls.Add(this.label29);
			this.tabCalcolo.Controls.Add(this.label28);
			this.tabCalcolo.Controls.Add(this.label26);
			this.tabCalcolo.Controls.Add(this.label19);
			this.tabCalcolo.Controls.Add(this.panel5);
			this.tabCalcolo.Controls.Add(this.label18);
			this.tabCalcolo.Controls.Add(this.label17);
			this.tabCalcolo.Controls.Add(this.label16);
			this.tabCalcolo.Controls.Add(this.labelImponibileFiscale);
			this.tabCalcolo.Controls.Add(this.label14);
			this.tabCalcolo.Controls.Add(this.label13);
			this.tabCalcolo.Controls.Add(this.label12);
			this.tabCalcolo.Controls.Add(this.labelInfo2);
			this.tabCalcolo.Controls.Add(this.txtImportoRitenuta);
			this.tabCalcolo.Controls.Add(this.txtImportoIVA);
			this.tabCalcolo.Controls.Add(this.txtImportoContrCassaPrev);
			this.tabCalcolo.Controls.Add(this.txtImportoAddebContrPrev);
			this.tabCalcolo.Controls.Add(this.label10);
			this.tabCalcolo.Controls.Add(this.labelInfo1);
			this.tabCalcolo.Controls.Add(this.label9);
			this.tabCalcolo.Controls.Add(this.txtAliquotaRitFisc);
			this.tabCalcolo.Controls.Add(this.txtImponibileFiscale);
			this.tabCalcolo.Controls.Add(this.txtImponibileIVA);
			this.tabCalcolo.Controls.Add(this.txtPercContrCassaPrev);
			this.tabCalcolo.Controls.Add(this.txtPercAddebContrPrev);
			this.tabCalcolo.Controls.Add(this.txtImportoNetto);
			this.tabCalcolo.Controls.Add(this.txtCostoTotale);
			this.tabCalcolo.Controls.Add(this.txtCompensoLordo);
			this.tabCalcolo.Controls.Add(this.panel4);
			this.tabCalcolo.Controls.Add(this.panel2);
			this.tabCalcolo.Controls.Add(this.label21);
			this.tabCalcolo.Controls.Add(this.label6);
			this.tabCalcolo.Controls.Add(this.label24);
			this.tabCalcolo.Controls.Add(this.label23);
			this.tabCalcolo.Controls.Add(this.label25);
			this.tabCalcolo.Controls.Add(this.label11);
			this.tabCalcolo.Controls.Add(this.lblRitenuta);
			this.tabCalcolo.Controls.Add(this.label20);
			this.tabCalcolo.Controls.Add(this.label7);
			this.tabCalcolo.Location = new System.Drawing.Point(4, 23);
			this.tabCalcolo.Name = "tabCalcolo";
			this.tabCalcolo.Size = new System.Drawing.Size(943, 553);
			this.tabCalcolo.TabIndex = 3;
			this.tabCalcolo.Text = "Calcolo";
			this.tabCalcolo.UseVisualStyleBackColor = true;
			this.tabCalcolo.Visible = false;
			// 
			// label67
			// 
			this.label67.Location = new System.Drawing.Point(92, 479);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(218, 23);
			this.label67.TabIndex = 96;
			this.label67.Text = "INCLUSO IVA ed al netto della ritenuta d\'acconto";
			// 
			// txtLordoBeneficiario
			// 
			this.txtLordoBeneficiario.Location = new System.Drawing.Point(768, 452);
			this.txtLordoBeneficiario.Name = "txtLordoBeneficiario";
			this.txtLordoBeneficiario.ReadOnly = true;
			this.txtLordoBeneficiario.Size = new System.Drawing.Size(100, 20);
			this.txtLordoBeneficiario.TabIndex = 95;
			this.txtLordoBeneficiario.TabStop = false;
			this.txtLordoBeneficiario.Tag = "profservice.totalgross";
			this.txtLordoBeneficiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(645, 455);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(102, 13);
			this.label64.TabIndex = 94;
			this.label64.Text = "Lordo al beneficiario";
			this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label62
			// 
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(885, 308);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(14, 13);
			this.label62.TabIndex = 93;
			this.label62.Text = "V";
			// 
			// txtAltreRit
			// 
			this.txtAltreRit.Location = new System.Drawing.Point(762, 303);
			this.txtAltreRit.Name = "txtAltreRit";
			this.txtAltreRit.ReadOnly = true;
			this.txtAltreRit.Size = new System.Drawing.Size(100, 20);
			this.txtAltreRit.TabIndex = 92;
			this.txtAltreRit.TabStop = false;
			this.txtAltreRit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(639, 306);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(108, 13);
			this.label63.TabIndex = 91;
			this.label63.Text = "Ritenute previdenziali";
			this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(885, 278);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(15, 13);
			this.label61.TabIndex = 90;
			this.label61.Text = "U";
			// 
			// txtContributi
			// 
			this.txtContributi.Location = new System.Drawing.Point(762, 273);
			this.txtContributi.Name = "txtContributi";
			this.txtContributi.ReadOnly = true;
			this.txtContributi.Size = new System.Drawing.Size(100, 20);
			this.txtContributi.TabIndex = 89;
			this.txtContributi.TabStop = false;
			this.txtContributi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(635, 276);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(112, 13);
			this.label60.TabIndex = 88;
			this.label60.Text = "Contributi previdenziali";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label15.Location = new System.Drawing.Point(273, 300);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(13, 20);
			this.label15.TabIndex = 87;
			this.label15.Text = "/";
			// 
			// txtDenImponibile
			// 
			this.txtDenImponibile.Location = new System.Drawing.Point(290, 300);
			this.txtDenImponibile.Name = "txtDenImponibile";
			this.txtDenImponibile.ReadOnly = true;
			this.txtDenImponibile.Size = new System.Drawing.Size(44, 20);
			this.txtDenImponibile.TabIndex = 86;
			this.txtDenImponibile.TabStop = false;
			this.txtDenImponibile.Tag = "";
			this.txtDenImponibile.Leave += new System.EventHandler(this.SubEntity_txtDenImponibile_Leave);
			// 
			// txtNumImponibile
			// 
			this.txtNumImponibile.Location = new System.Drawing.Point(227, 299);
			this.txtNumImponibile.Name = "txtNumImponibile";
			this.txtNumImponibile.ReadOnly = true;
			this.txtNumImponibile.Size = new System.Drawing.Size(44, 20);
			this.txtNumImponibile.TabIndex = 85;
			this.txtNumImponibile.TabStop = false;
			this.txtNumImponibile.Tag = "";
			this.txtNumImponibile.Leave += new System.EventHandler(this.SubEntity_txtNumImponibile_Leave);
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(337, 148);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(24, 16);
			this.label55.TabIndex = 84;
			this.label55.Text = "V";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSpeseNoIva
			// 
			this.txtSpeseNoIva.Location = new System.Drawing.Point(365, 148);
			this.txtSpeseNoIva.Name = "txtSpeseNoIva";
			this.txtSpeseNoIva.ReadOnly = true;
			this.txtSpeseNoIva.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseNoIva.TabIndex = 83;
			this.txtSpeseNoIva.TabStop = false;
			this.txtSpeseNoIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(9, 148);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(208, 23);
			this.label56.TabIndex = 82;
			this.label56.Text = "Spese imponibili ai fini IVA";
			this.label56.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(480, 60);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(100, 23);
			this.label54.TabIndex = 81;
			this.label54.Text = "P = A + B";
			this.label54.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(336, 58);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(24, 16);
			this.label52.TabIndex = 80;
			this.label52.Text = "P";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtImponibilePrevidenza
			// 
			this.txtImponibilePrevidenza.Location = new System.Drawing.Point(365, 58);
			this.txtImponibilePrevidenza.Name = "txtImponibilePrevidenza";
			this.txtImponibilePrevidenza.ReadOnly = true;
			this.txtImponibilePrevidenza.Size = new System.Drawing.Size(100, 20);
			this.txtImponibilePrevidenza.TabIndex = 79;
			this.txtImponibilePrevidenza.TabStop = false;
			this.txtImponibilePrevidenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(8, 58);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(208, 23);
			this.label53.TabIndex = 78;
			this.label53.Text = "Imponibile previdenziale";
			this.label53.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(335, 33);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(24, 16);
			this.label48.TabIndex = 77;
			this.label48.Text = "B";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSpeseNoP
			// 
			this.txtSpeseNoP.Location = new System.Drawing.Point(365, 33);
			this.txtSpeseNoP.Name = "txtSpeseNoP";
			this.txtSpeseNoP.ReadOnly = true;
			this.txtSpeseNoP.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseNoP.TabIndex = 76;
			this.txtSpeseNoP.TabStop = false;
			this.txtSpeseNoP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(7, 33);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(208, 23);
			this.label51.TabIndex = 75;
			this.label51.Text = "Spese imponibili previdenzialmente";
			this.label51.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Location = new System.Drawing.Point(483, 299);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(85, 2);
			this.panel6.TabIndex = 74;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(337, 269);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(24, 16);
			this.label49.TabIndex = 73;
			this.label49.Text = "Z";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSpeseNoF
			// 
			this.txtSpeseNoF.Location = new System.Drawing.Point(365, 269);
			this.txtSpeseNoF.Name = "txtSpeseNoF";
			this.txtSpeseNoF.ReadOnly = true;
			this.txtSpeseNoF.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseNoF.TabIndex = 72;
			this.txtSpeseNoF.TabStop = false;
			this.txtSpeseNoF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(9, 269);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(208, 23);
			this.label50.TabIndex = 71;
			this.label50.Text = "Spese imponibili fiscalmente";
			this.label50.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(520, 361);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(24, 23);
			this.label45.TabIndex = 70;
			this.label45.Text = "T";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(336, 361);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(24, 16);
			this.label46.TabIndex = 69;
			this.label46.Text = "T";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtSpeseDed
			// 
			this.txtSpeseDed.Location = new System.Drawing.Point(365, 362);
			this.txtSpeseDed.Name = "txtSpeseDed";
			this.txtSpeseDed.ReadOnly = true;
			this.txtSpeseDed.Size = new System.Drawing.Size(100, 20);
			this.txtSpeseDed.TabIndex = 68;
			this.txtSpeseDed.TabStop = false;
			this.txtSpeseDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(8, 361);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(208, 23);
			this.label47.TabIndex = 67;
			this.label47.Text = "Spese non imponibili";
			this.label47.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(216, 238);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(24, 16);
			this.label27.TabIndex = 66;
			this.label27.Text = "E%";
			this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnTipo
			// 
			this.btnTipo.Location = new System.Drawing.Point(8, 207);
			this.btnTipo.Name = "btnTipo";
			this.btnTipo.Size = new System.Drawing.Size(64, 23);
			this.btnTipo.TabIndex = 65;
			this.btnTipo.TabStop = false;
			this.btnTipo.Tag = "choose.ivakind.default";
			this.btnTipo.Text = "Tipo IVA";
			// 
			// cmbTipoIVA
			// 
			this.cmbTipoIVA.DataSource = this.DS.ivakind;
			this.cmbTipoIVA.DisplayMember = "description";
			this.cmbTipoIVA.Location = new System.Drawing.Point(80, 207);
			this.cmbTipoIVA.Name = "cmbTipoIVA";
			this.cmbTipoIVA.Size = new System.Drawing.Size(248, 21);
			this.cmbTipoIVA.TabIndex = 4;
			this.cmbTipoIVA.Tag = "profservice.idivakind";
			this.cmbTipoIVA.ValueMember = "idivakind";
			// 
			// txtIva
			// 
			this.txtIva.Location = new System.Drawing.Point(248, 238);
			this.txtIva.Name = "txtIva";
			this.txtIva.ReadOnly = true;
			this.txtIva.Size = new System.Drawing.Size(80, 20);
			this.txtIva.TabIndex = 63;
			this.txtIva.TabStop = false;
			this.txtIva.Tag = "profservice.ivarate.fixed.4..%.100";
			this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(520, 391);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(24, 23);
			this.label42.TabIndex = 61;
			this.label42.Text = "H";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(336, 391);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(24, 16);
			this.label41.TabIndex = 60;
			this.label41.Text = "H";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtTotaleSpese
			// 
			this.txtTotaleSpese.Location = new System.Drawing.Point(365, 393);
			this.txtTotaleSpese.Name = "txtTotaleSpese";
			this.txtTotaleSpese.ReadOnly = true;
			this.txtTotaleSpese.Size = new System.Drawing.Size(100, 20);
			this.txtTotaleSpese.TabIndex = 59;
			this.txtTotaleSpese.TabStop = false;
			this.txtTotaleSpese.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(8, 391);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(208, 23);
			this.label40.TabIndex = 58;
			this.label40.Text = "Totale Spese";
			this.label40.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(336, 456);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(24, 16);
			this.label37.TabIndex = 57;
			this.label37.Text = "J";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(336, 422);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(24, 16);
			this.label36.TabIndex = 56;
			this.label36.Text = "I";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(336, 333);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(24, 16);
			this.label35.TabIndex = 55;
			this.label35.Text = "G";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(336, 300);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(24, 16);
			this.label34.TabIndex = 54;
			this.label34.Text = "F";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label33
			// 
			this.label33.Location = new System.Drawing.Point(336, 238);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(24, 16);
			this.label33.TabIndex = 53;
			this.label33.Text = "E";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label32
			// 
			this.label32.Location = new System.Drawing.Point(337, 178);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(24, 16);
			this.label32.TabIndex = 52;
			this.label32.Text = "D";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label31
			// 
			this.label31.Location = new System.Drawing.Point(336, 116);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(24, 16);
			this.label31.TabIndex = 51;
			this.label31.Text = "C";
			this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(336, 84);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(24, 16);
			this.label30.TabIndex = 50;
			this.label30.Text = "N";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label29
			// 
			this.label29.Location = new System.Drawing.Point(335, 8);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(24, 16);
			this.label29.TabIndex = 49;
			this.label29.Text = "A";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(224, 333);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(24, 16);
			this.label28.TabIndex = 48;
			this.label28.Text = "G%";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(224, 116);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(24, 16);
			this.label26.TabIndex = 46;
			this.label26.Text = "C%";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(224, 84);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(24, 16);
			this.label19.TabIndex = 45;
			this.label19.Text = "N%";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Location = new System.Drawing.Point(488, 449);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(85, 2);
			this.panel5.TabIndex = 44;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(472, 430);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(169, 21);
			this.label18.TabIndex = 43;
			this.label18.Text = "I = A + N + C + E + H + U";
			this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(480, 238);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 42;
			this.label17.Text = "E = E% * D";
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(480, 463);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(96, 18);
			this.label16.TabIndex = 41;
			this.label16.Text = "J = I - G - U - V";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelImponibileFiscale
			// 
			this.labelImponibileFiscale.AutoSize = true;
			this.labelImponibileFiscale.Location = new System.Drawing.Point(480, 303);
			this.labelImponibileFiscale.Name = "labelImponibileFiscale";
			this.labelImponibileFiscale.Size = new System.Drawing.Size(71, 13);
			this.labelImponibileFiscale.TabIndex = 40;
			this.labelImponibileFiscale.Text = "F = A + N + Z";
			this.labelImponibileFiscale.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(480, 338);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 39;
			this.label14.Text = "G = G% * F";
			this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(480, 185);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 38;
			this.label13.Text = "D = A + N + C + V";
			this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(484, 119);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 23);
			this.label12.TabIndex = 37;
			this.label12.Text = "C = C% * (N + P)";
			this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelInfo2
			// 
			this.labelInfo2.Location = new System.Drawing.Point(587, 116);
			this.labelInfo2.Name = "labelInfo2";
			this.labelInfo2.Size = new System.Drawing.Size(312, 23);
			this.labelInfo2.TabIndex = 37;
			this.labelInfo2.Text = "L\'importo costituisce rivalsa e non viene certificato con CU";
			this.labelInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoRitenuta
			// 
			this.txtImportoRitenuta.Location = new System.Drawing.Point(365, 331);
			this.txtImportoRitenuta.Name = "txtImportoRitenuta";
			this.txtImportoRitenuta.ReadOnly = true;
			this.txtImportoRitenuta.Size = new System.Drawing.Size(100, 20);
			this.txtImportoRitenuta.TabIndex = 7;
			this.txtImportoRitenuta.TabStop = false;
			this.txtImportoRitenuta.Tag = "";
			this.txtImportoRitenuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoIVA
			// 
			this.txtImportoIVA.Location = new System.Drawing.Point(365, 238);
			this.txtImportoIVA.Name = "txtImportoIVA";
			this.txtImportoIVA.ReadOnly = true;
			this.txtImportoIVA.Size = new System.Drawing.Size(100, 20);
			this.txtImportoIVA.TabIndex = 5;
			this.txtImportoIVA.TabStop = false;
			this.txtImportoIVA.Tag = "profservice.ivaamount";
			this.txtImportoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoContrCassaPrev
			// 
			this.txtImportoContrCassaPrev.Location = new System.Drawing.Point(365, 116);
			this.txtImportoContrCassaPrev.Name = "txtImportoContrCassaPrev";
			this.txtImportoContrCassaPrev.ReadOnly = true;
			this.txtImportoContrCassaPrev.Size = new System.Drawing.Size(100, 20);
			this.txtImportoContrCassaPrev.TabIndex = 3;
			this.txtImportoContrCassaPrev.TabStop = false;
			this.txtImportoContrCassaPrev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImportoAddebContrPrev
			// 
			this.txtImportoAddebContrPrev.Location = new System.Drawing.Point(365, 84);
			this.txtImportoAddebContrPrev.Name = "txtImportoAddebContrPrev";
			this.txtImportoAddebContrPrev.ReadOnly = true;
			this.txtImportoAddebContrPrev.Size = new System.Drawing.Size(100, 20);
			this.txtImportoAddebContrPrev.TabIndex = 2;
			this.txtImportoAddebContrPrev.TabStop = false;
			this.txtImportoAddebContrPrev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(480, 87);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 32;
			this.label10.Text = "N = N% * P";
			this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelInfo1
			// 
			this.labelInfo1.Location = new System.Drawing.Point(585, 80);
			this.labelInfo1.Name = "labelInfo1";
			this.labelInfo1.Size = new System.Drawing.Size(334, 24);
			this.labelInfo1.TabIndex = 32;
			this.labelInfo1.Text = "L\'importo viene considerato compenso e viene certificato con CU";
			this.labelInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(480, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 31;
			this.label9.Text = "A";
			this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtAliquotaRitFisc
			// 
			this.txtAliquotaRitFisc.Location = new System.Drawing.Point(248, 333);
			this.txtAliquotaRitFisc.Name = "txtAliquotaRitFisc";
			this.txtAliquotaRitFisc.Size = new System.Drawing.Size(80, 20);
			this.txtAliquotaRitFisc.TabIndex = 5;
			this.txtAliquotaRitFisc.Tag = "";
			this.txtAliquotaRitFisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAliquotaRitFisc.Leave += new System.EventHandler(this.txtAliquotaRitFisc_Leave);
			// 
			// txtImponibileFiscale
			// 
			this.txtImponibileFiscale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImponibileFiscale.Location = new System.Drawing.Point(365, 300);
			this.txtImponibileFiscale.Name = "txtImponibileFiscale";
			this.txtImponibileFiscale.ReadOnly = true;
			this.txtImponibileFiscale.Size = new System.Drawing.Size(100, 20);
			this.txtImponibileFiscale.TabIndex = 6;
			this.txtImponibileFiscale.TabStop = false;
			this.txtImponibileFiscale.Tag = "";
			this.txtImponibileFiscale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImponibileIVA
			// 
			this.txtImponibileIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImponibileIVA.Location = new System.Drawing.Point(365, 178);
			this.txtImponibileIVA.Name = "txtImponibileIVA";
			this.txtImponibileIVA.ReadOnly = true;
			this.txtImponibileIVA.Size = new System.Drawing.Size(100, 20);
			this.txtImponibileIVA.TabIndex = 41;
			this.txtImponibileIVA.TabStop = false;
			this.txtImponibileIVA.Tag = "";
			this.txtImponibileIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtPercContrCassaPrev
			// 
			this.txtPercContrCassaPrev.Location = new System.Drawing.Point(248, 116);
			this.txtPercContrCassaPrev.Name = "txtPercContrCassaPrev";
			this.txtPercContrCassaPrev.Size = new System.Drawing.Size(80, 20);
			this.txtPercContrCassaPrev.TabIndex = 3;
			this.txtPercContrCassaPrev.Tag = "profservice.socialsecurityrate.fixed.4..%.100";
			this.txtPercContrCassaPrev.Leave += new System.EventHandler(this.txtPercContrCassaPrev_Leave);
			// 
			// txtPercAddebContrPrev
			// 
			this.txtPercAddebContrPrev.Location = new System.Drawing.Point(248, 84);
			this.txtPercAddebContrPrev.Name = "txtPercAddebContrPrev";
			this.txtPercAddebContrPrev.Size = new System.Drawing.Size(80, 20);
			this.txtPercAddebContrPrev.TabIndex = 2;
			this.txtPercAddebContrPrev.Tag = "profservice.pensioncontributionrate.fixed.4..%.100";
			this.txtPercAddebContrPrev.Leave += new System.EventHandler(this.txtPercAddebContrPrev_Leave);
			// 
			// txtImportoNetto
			// 
			this.txtImportoNetto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtImportoNetto.Location = new System.Drawing.Point(365, 455);
			this.txtImportoNetto.Name = "txtImportoNetto";
			this.txtImportoNetto.ReadOnly = true;
			this.txtImportoNetto.Size = new System.Drawing.Size(100, 20);
			this.txtImportoNetto.TabIndex = 9;
			this.txtImportoNetto.TabStop = false;
			this.txtImportoNetto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCostoTotale
			// 
			this.txtCostoTotale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCostoTotale.Location = new System.Drawing.Point(365, 424);
			this.txtCostoTotale.Name = "txtCostoTotale";
			this.txtCostoTotale.Size = new System.Drawing.Size(100, 20);
			this.txtCostoTotale.TabIndex = 6;
			this.txtCostoTotale.Tag = "profservice.totalcost";
			this.txtCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtCostoTotale.Leave += new System.EventHandler(this.txtCostoTotale_Leave);
			// 
			// txtCompensoLordo
			// 
			this.txtCompensoLordo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCompensoLordo.Location = new System.Drawing.Point(365, 8);
			this.txtCompensoLordo.Name = "txtCompensoLordo";
			this.txtCompensoLordo.Size = new System.Drawing.Size(100, 20);
			this.txtCompensoLordo.TabIndex = 1;
			this.txtCompensoLordo.Tag = "profservice.feegross";
			this.txtCompensoLordo.Leave += new System.EventHandler(this.txtCompensoLordo_Leave);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.panel1);
			this.panel4.Location = new System.Drawing.Point(488, 417);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(85, 2);
			this.panel4.TabIndex = 24;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(-1, -1);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(70, 2);
			this.panel1.TabIndex = 25;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(488, 169);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(85, 2);
			this.panel2.TabIndex = 12;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 422);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(208, 23);
			this.label21.TabIndex = 20;
			this.label21.Text = "Costo Totale";
			this.label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(208, 23);
			this.label6.TabIndex = 19;
			this.label6.Text = "Importo Prestazione";
			this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(8, 84);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(208, 23);
			this.label24.TabIndex = 10;
			this.label24.Text = "Addebito Contr. Prev. (%)";
			this.label24.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 116);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(208, 23);
			this.label23.TabIndex = 18;
			this.label23.Text = "Contr. Cassa di Prev. (%)";
			this.label23.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label25.Location = new System.Drawing.Point(8, 178);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(208, 23);
			this.label25.TabIndex = 12;
			this.label25.Text = "Imponibile IVA";
			this.label25.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(7, 303);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(208, 20);
			this.label11.TabIndex = 16;
			this.label11.Text = "Imponibile Fiscale";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblRitenuta
			// 
			this.lblRitenuta.Location = new System.Drawing.Point(8, 334);
			this.lblRitenuta.Name = "lblRitenuta";
			this.lblRitenuta.Size = new System.Drawing.Size(208, 23);
			this.lblRitenuta.TabIndex = 12;
			this.lblRitenuta.Text = "Ritenuta Fiscale (%)";
			this.lblRitenuta.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label20
			// 
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label20.Location = new System.Drawing.Point(8, 456);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(208, 23);
			this.label20.TabIndex = 22;
			this.label20.Text = "Importo Netto";
			this.label20.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(144, 238);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 8;
			this.label7.Text = "IVA (%)";
			this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tabRitenute
			// 
			this.tabRitenute.Controls.Add(this.dataGrid2);
			this.tabRitenute.Location = new System.Drawing.Point(4, 23);
			this.tabRitenute.Name = "tabRitenute";
			this.tabRitenute.Size = new System.Drawing.Size(943, 553);
			this.tabRitenute.TabIndex = 2;
			this.tabRitenute.Text = "Ritenute";
			this.tabRitenute.UseVisualStyleBackColor = true;
			this.tabRitenute.Visible = false;
			// 
			// dataGrid2
			// 
			this.dataGrid2.AllowNavigation = false;
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.CaptionVisible = false;
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 8);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(928, 538);
			this.dataGrid2.TabIndex = 1;
			this.dataGrid2.Tag = "profservicetax.default";
			// 
			// tabSpese
			// 
			this.tabSpese.Controls.Add(this.button3);
			this.tabSpese.Controls.Add(this.button2);
			this.tabSpese.Controls.Add(this.button1);
			this.tabSpese.Controls.Add(this.dataGrid1);
			this.tabSpese.Location = new System.Drawing.Point(4, 23);
			this.tabSpese.Name = "tabSpese";
			this.tabSpese.Size = new System.Drawing.Size(943, 553);
			this.tabSpese.TabIndex = 4;
			this.tabSpese.Text = "Spese";
			this.tabSpese.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(184, 8);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(96, 8);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Tag = "insert.default";
			this.button1.Text = "Inserisci";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 32);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(928, 505);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "profservicerefund.default.default";
			// 
			// tabFatturazione
			// 
			this.tabFatturazione.Controls.Add(this.btnscollegainvoice);
			this.tabFatturazione.Controls.Add(this.checkBox2);
			this.tabFatturazione.Controls.Add(this.tabControl2);
			this.tabFatturazione.Controls.Add(this.gboxInvoice);
			this.tabFatturazione.Controls.Add(this.checkBox1);
			this.tabFatturazione.Location = new System.Drawing.Point(4, 23);
			this.tabFatturazione.Name = "tabFatturazione";
			this.tabFatturazione.Size = new System.Drawing.Size(943, 553);
			this.tabFatturazione.TabIndex = 6;
			this.tabFatturazione.Text = "Fattura";
			this.tabFatturazione.UseVisualStyleBackColor = true;
			// 
			// btnscollegainvoice
			// 
			this.btnscollegainvoice.Location = new System.Drawing.Point(288, 16);
			this.btnscollegainvoice.Name = "btnscollegainvoice";
			this.btnscollegainvoice.Size = new System.Drawing.Size(120, 24);
			this.btnscollegainvoice.TabIndex = 24;
			this.btnscollegainvoice.Text = "Scollega da Fattura";
			this.btnscollegainvoice.Click += new System.EventHandler(this.btnscollegainvoice_Click);
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(8, 104);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(104, 24);
			this.checkBox2.TabIndex = 23;
			this.checkBox2.Tag = "profservice.flagmixed:S:N";
			this.checkBox2.Text = "Promiscuo";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabAnalitico);
			this.tabControl2.Location = new System.Drawing.Point(8, 168);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(928, 372);
			this.tabControl2.TabIndex = 8;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(920, 346);
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
			this.gboxUPB.Location = new System.Drawing.Point(4, 13);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(592, 136);
			this.gboxUPB.TabIndex = 5;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(7, 110);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(580, 20);
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
			this.txtDescrUPB.Size = new System.Drawing.Size(444, 96);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(7, 84);
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
			this.tabAnalitico.Size = new System.Drawing.Size(920, 346);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			this.tabAnalitico.Visible = false;
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(8, 192);
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
			this.txtDenom3.Location = new System.Drawing.Point(166, 8);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(259, 45);
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
			this.gboxclass2.Location = new System.Drawing.Point(8, 98);
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
			this.gboxclass1.Location = new System.Drawing.Point(8, 3);
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
			this.txtDenom1.Location = new System.Drawing.Point(161, 8);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(264, 52);
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
			// gboxInvoice
			// 
			this.gboxInvoice.Controls.Add(this.txtNumDocumento);
			this.gboxInvoice.Controls.Add(this.txtEsercDocumento);
			this.gboxInvoice.Controls.Add(this.label43);
			this.gboxInvoice.Controls.Add(this.label44);
			this.gboxInvoice.Controls.Add(this.cmbInvoice);
			this.gboxInvoice.Location = new System.Drawing.Point(8, 40);
			this.gboxInvoice.Name = "gboxInvoice";
			this.gboxInvoice.Size = new System.Drawing.Size(552, 56);
			this.gboxInvoice.TabIndex = 1;
			this.gboxInvoice.TabStop = false;
			this.gboxInvoice.Text = "Fattura collegata";
			// 
			// txtNumDocumento
			// 
			this.txtNumDocumento.Location = new System.Drawing.Point(464, 24);
			this.txtNumDocumento.Name = "txtNumDocumento";
			this.txtNumDocumento.Size = new System.Drawing.Size(64, 20);
			this.txtNumDocumento.TabIndex = 2;
			this.txtNumDocumento.Tag = "profservice.ninv";
			// 
			// txtEsercDocumento
			// 
			this.txtEsercDocumento.Location = new System.Drawing.Point(336, 24);
			this.txtEsercDocumento.Name = "txtEsercDocumento";
			this.txtEsercDocumento.Size = new System.Drawing.Size(64, 20);
			this.txtEsercDocumento.TabIndex = 1;
			this.txtEsercDocumento.Tag = "profservice.yinv";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(408, 24);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(48, 16);
			this.label43.TabIndex = 7;
			this.label43.Text = "Numero";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(272, 24);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(56, 16);
			this.label44.TabIndex = 6;
			this.label44.Text = "Esercizio";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbInvoice
			// 
			this.cmbInvoice.DataSource = this.DS.invoicekind;
			this.cmbInvoice.DisplayMember = "description";
			this.cmbInvoice.Location = new System.Drawing.Point(8, 24);
			this.cmbInvoice.Name = "cmbInvoice";
			this.cmbInvoice.Size = new System.Drawing.Size(264, 21);
			this.cmbInvoice.TabIndex = 0;
			this.cmbInvoice.Tag = "profservice.idinvkind";
			this.cmbInvoice.ValueMember = "idinvkind";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(8, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(272, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Tag = "profservice.flaginvoiced:S:N";
			this.checkBox1.Text = "Non considerare per l\'inserimento in fatture";
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
			this.tabClassSuppl.Size = new System.Drawing.Size(943, 553);
			this.tabClassSuppl.TabIndex = 5;
			this.tabClassSuppl.Text = "Classificazione";
			this.tabClassSuppl.UseVisualStyleBackColor = true;
			// 
			// btnClassElimina
			// 
			this.btnClassElimina.Location = new System.Drawing.Point(168, 8);
			this.btnClassElimina.Name = "btnClassElimina";
			this.btnClassElimina.Size = new System.Drawing.Size(68, 22);
			this.btnClassElimina.TabIndex = 22;
			this.btnClassElimina.Tag = "delete";
			this.btnClassElimina.Text = "Elimina";
			// 
			// btnClassModifica
			// 
			this.btnClassModifica.Location = new System.Drawing.Point(88, 8);
			this.btnClassModifica.Name = "btnClassModifica";
			this.btnClassModifica.Size = new System.Drawing.Size(69, 22);
			this.btnClassModifica.TabIndex = 21;
			this.btnClassModifica.Tag = "edit.default";
			this.btnClassModifica.Text = "Modifica...";
			// 
			// btnClassInserisci
			// 
			this.btnClassInserisci.Location = new System.Drawing.Point(8, 8);
			this.btnClassInserisci.Name = "btnClassInserisci";
			this.btnClassInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnClassInserisci.TabIndex = 20;
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
			this.dgrClassSuppl.Location = new System.Drawing.Point(8, 40);
			this.dgrClassSuppl.Name = "dgrClassSuppl";
			this.dgrClassSuppl.ReadOnly = true;
			this.dgrClassSuppl.Size = new System.Drawing.Size(928, 506);
			this.dgrClassSuppl.TabIndex = 19;
			this.dgrClassSuppl.Tag = "profservicesorting.default.default";
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
			this.tabAttributi.Size = new System.Drawing.Size(943, 553);
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
			this.gboxclass05.Location = new System.Drawing.Point(8, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(764, 64);
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
			this.txtDenom05.Size = new System.Drawing.Size(522, 52);
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
			this.gboxclass04.Size = new System.Drawing.Size(764, 64);
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
			this.txtDenom04.Size = new System.Drawing.Size(522, 46);
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
			this.gboxclass03.Size = new System.Drawing.Size(764, 64);
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
			this.txtDenom03.Size = new System.Drawing.Size(523, 52);
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
			this.gboxclass02.Size = new System.Drawing.Size(764, 64);
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
			this.txtDenom02.Size = new System.Drawing.Size(523, 52);
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
			this.gboxclass01.Size = new System.Drawing.Size(764, 64);
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
			this.txtDenom01.Size = new System.Drawing.Size(523, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabAP
			// 
			this.tabAP.Controls.Add(this.btnCollegaAP);
			this.tabAP.Controls.Add(this.grpBoxMotivo);
			this.tabAP.Controls.Add(this.grpBoxDocAutorizzattivo);
			this.tabAP.Controls.Add(this.grpBoxAutorizzazioneAP);
			this.tabAP.Controls.Add(this.btnGeneraAP);
			this.tabAP.Controls.Add(this.btnVisualizzaAP);
			this.tabAP.Controls.Add(this.labAPnongenerato);
			this.tabAP.Controls.Add(this.labAPgenerato);
			this.tabAP.Location = new System.Drawing.Point(4, 23);
			this.tabAP.Name = "tabAP";
			this.tabAP.Size = new System.Drawing.Size(943, 553);
			this.tabAP.TabIndex = 7;
			this.tabAP.Text = "Anagrafe Prestazioni";
			this.tabAP.UseVisualStyleBackColor = true;
			// 
			// btnCollegaAP
			// 
			this.btnCollegaAP.Location = new System.Drawing.Point(366, 96);
			this.btnCollegaAP.Name = "btnCollegaAP";
			this.btnCollegaAP.Size = new System.Drawing.Size(224, 39);
			this.btnCollegaAP.TabIndex = 23;
			this.btnCollegaAP.Text = "Collega ad Anagrafe delle Prestazioni  già esistente";
			this.btnCollegaAP.Click += new System.EventHandler(this.btnCollegaAP_Click);
			// 
			// grpBoxMotivo
			// 
			this.grpBoxMotivo.Controls.Add(this.txtMotivoAut);
			this.grpBoxMotivo.Location = new System.Drawing.Point(290, 178);
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
			this.txtMotivoAut.Tag = "profservice.noauthreason";
			// 
			// grpBoxDocAutorizzattivo
			// 
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label58);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.txtDataDocumentoAut);
			this.grpBoxDocAutorizzattivo.Controls.Add(this.label59);
			this.grpBoxDocAutorizzattivo.Location = new System.Drawing.Point(290, 214);
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
			this.txtDocumentoAut.Tag = "profservice.authdoc";
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(8, 14);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(128, 16);
			this.label58.TabIndex = 0;
			this.label58.Text = "Descrizione";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDocumentoAut
			// 
			this.txtDataDocumentoAut.Location = new System.Drawing.Point(285, 30);
			this.txtDataDocumentoAut.Name = "txtDataDocumentoAut";
			this.txtDataDocumentoAut.Size = new System.Drawing.Size(72, 20);
			this.txtDataDocumentoAut.TabIndex = 2;
			this.txtDataDocumentoAut.Tag = "profservice.authdocdate";
			// 
			// label59
			// 
			this.label59.Location = new System.Drawing.Point(285, 14);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(72, 16);
			this.label59.TabIndex = 0;
			this.label59.Text = "Data";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpBoxAutorizzazioneAP
			// 
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbAutorizzazioneNonNecessaria);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNonApplicabile);
			this.grpBoxAutorizzazioneAP.Controls.Add(this.rdbNecessitaAutorizzazione);
			this.grpBoxAutorizzazioneAP.Location = new System.Drawing.Point(19, 177);
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
			this.rdbAutorizzazioneNonNecessaria.Tag = "profservice.authneeded:N";
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
			this.rdbNonApplicabile.Tag = "profservice.authneeded:X";
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
			this.rdbNecessitaAutorizzazione.Tag = "profservice.authneeded:S";
			this.rdbNecessitaAutorizzazione.Text = "Necessita autorizzazione";
			this.rdbNecessitaAutorizzazione.UseVisualStyleBackColor = true;
			this.rdbNecessitaAutorizzazione.CheckedChanged += new System.EventHandler(this.rdbNecessitaAutorizzazione_CheckedChanged);
			// 
			// btnGeneraAP
			// 
			this.btnGeneraAP.Location = new System.Drawing.Point(368, 56);
			this.btnGeneraAP.Name = "btnGeneraAP";
			this.btnGeneraAP.Size = new System.Drawing.Size(222, 23);
			this.btnGeneraAP.TabIndex = 5;
			this.btnGeneraAP.Text = "Genera Anagrafe delle Prestazioni";
			this.btnGeneraAP.Click += new System.EventHandler(this.btnGeneraAP_Click);
			// 
			// btnVisualizzaAP
			// 
			this.btnVisualizzaAP.Location = new System.Drawing.Point(368, 24);
			this.btnVisualizzaAP.Name = "btnVisualizzaAP";
			this.btnVisualizzaAP.Size = new System.Drawing.Size(222, 23);
			this.btnVisualizzaAP.TabIndex = 4;
			this.btnVisualizzaAP.Text = "Visualizza Anagrafe delle Prestazione";
			this.btnVisualizzaAP.Click += new System.EventHandler(this.btnVisualizzaAP_Click);
			// 
			// labAPnongenerato
			// 
			this.labAPnongenerato.Location = new System.Drawing.Point(16, 56);
			this.labAPnongenerato.Name = "labAPnongenerato";
			this.labAPnongenerato.Size = new System.Drawing.Size(344, 40);
			this.labAPnongenerato.TabIndex = 3;
			this.labAPnongenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni  NON sono state ancora generate." +
    "";
			// 
			// labAPgenerato
			// 
			this.labAPgenerato.Location = new System.Drawing.Point(16, 32);
			this.labAPgenerato.Name = "labAPgenerato";
			this.labAPgenerato.Size = new System.Drawing.Size(352, 16);
			this.labAPgenerato.TabIndex = 2;
			this.labAPgenerato.Text = "Le informazioni per l\'Anagrafe delle Prestazioni sono state generate.";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpBoxSiopeEP);
			this.tabPage2.Controls.Add(this.gBoxCompetenza);
			this.tabPage2.Controls.Add(this.btnGeneraEP);
			this.tabPage2.Controls.Add(this.btnVisualizzaEP);
			this.tabPage2.Controls.Add(this.labEP);
			this.tabPage2.Controls.Add(this.btnGeneraPreImpegni);
			this.tabPage2.Controls.Add(this.btnViewPreimpegni);
			this.tabPage2.Controls.Add(this.btnGeneraEpExp);
			this.tabPage2.Controls.Add(this.btnVisualizzaEpExp);
			this.tabPage2.Controls.Add(this.groupBox10);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(943, 553);
			this.tabPage2.TabIndex = 9;
			this.tabPage2.Text = "EP";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(63, 180);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(328, 100);
			this.grpBoxSiopeEP.TabIndex = 52;
			this.grpBoxSiopeEP.TabStop = false;
			this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
			this.grpBoxSiopeEP.Text = "Class.SIOPE";
			// 
			// btnSiope
			// 
			this.btnSiope.Location = new System.Drawing.Point(4, 36);
			this.btnSiope.Name = "btnSiope";
			this.btnSiope.Size = new System.Drawing.Size(108, 20);
			this.btnSiope.TabIndex = 12;
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
			this.txtDescSiope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescSiope.Size = new System.Drawing.Size(202, 82);
			this.txtDescSiope.TabIndex = 2;
			this.txtDescSiope.Tag = "sorting_siope.description";
			// 
			// txtCodSiope
			// 
			this.txtCodSiope.Location = new System.Drawing.Point(4, 74);
			this.txtCodSiope.Name = "txtCodSiope";
			this.txtCodSiope.Size = new System.Drawing.Size(108, 20);
			this.txtCodSiope.TabIndex = 9;
			this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
			// 
			// gBoxCompetenza
			// 
			this.gBoxCompetenza.Controls.Add(this.rdEPKind_N);
			this.gBoxCompetenza.Controls.Add(this.rdEPKind_F);
			this.gBoxCompetenza.Controls.Add(this.rdEPKind_R);
			this.gBoxCompetenza.Location = new System.Drawing.Point(455, 292);
			this.gBoxCompetenza.Name = "gBoxCompetenza";
			this.gBoxCompetenza.Size = new System.Drawing.Size(303, 72);
			this.gBoxCompetenza.TabIndex = 19;
			this.gBoxCompetenza.TabStop = false;
			this.gBoxCompetenza.Text = "Competenza economica";
			// 
			// rdEPKind_N
			// 
			this.rdEPKind_N.AutoSize = true;
			this.rdEPKind_N.Location = new System.Drawing.Point(6, 19);
			this.rdEPKind_N.Name = "rdEPKind_N";
			this.rdEPKind_N.Size = new System.Drawing.Size(279, 17);
			this.rdEPKind_N.TabIndex = 6;
			this.rdEPKind_N.Tag = "profservice.epkind:N";
			this.rdEPKind_N.Text = "Non generare ratei o scritture automatiche a fine anno";
			this.rdEPKind_N.UseVisualStyleBackColor = true;
			// 
			// rdEPKind_F
			// 
			this.rdEPKind_F.AutoSize = true;
			this.rdEPKind_F.Location = new System.Drawing.Point(167, 40);
			this.rdEPKind_F.Name = "rdEPKind_F";
			this.rdEPKind_F.Size = new System.Drawing.Size(114, 17);
			this.rdEPKind_F.TabIndex = 5;
			this.rdEPKind_F.Tag = "profservice.epkind:F";
			this.rdEPKind_F.Text = "Fattura da ricevere";
			this.rdEPKind_F.UseVisualStyleBackColor = true;
			// 
			// rdEPKind_R
			// 
			this.rdEPKind_R.AutoSize = true;
			this.rdEPKind_R.Location = new System.Drawing.Point(6, 40);
			this.rdEPKind_R.Name = "rdEPKind_R";
			this.rdEPKind_R.Size = new System.Drawing.Size(143, 17);
			this.rdEPKind_R.TabIndex = 4;
			this.rdEPKind_R.Tag = "profservice.epkind:R";
			this.rdEPKind_R.Text = "Genera rateo a fine anno";
			this.rdEPKind_R.UseVisualStyleBackColor = true;
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(697, 126);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 36;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(697, 96);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 35;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labEP.Location = new System.Drawing.Point(452, 96);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(238, 16);
			this.labEP.TabIndex = 34;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			this.labEP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnGeneraPreImpegni
			// 
			this.btnGeneraPreImpegni.Location = new System.Drawing.Point(455, 155);
			this.btnGeneraPreImpegni.Name = "btnGeneraPreImpegni";
			this.btnGeneraPreImpegni.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraPreImpegni.TabIndex = 33;
			this.btnGeneraPreImpegni.Text = "Genera preimpegni di Budget";
			// 
			// btnViewPreimpegni
			// 
			this.btnViewPreimpegni.Location = new System.Drawing.Point(455, 187);
			this.btnViewPreimpegni.Name = "btnViewPreimpegni";
			this.btnViewPreimpegni.Size = new System.Drawing.Size(224, 23);
			this.btnViewPreimpegni.TabIndex = 32;
			this.btnViewPreimpegni.Text = "Visualizza preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(697, 155);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEpExp.TabIndex = 31;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(697, 187);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEpExp.TabIndex = 30;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.textBox7);
			this.groupBox10.Controls.Add(this.txtCodiceCausaleDeb);
			this.groupBox10.Controls.Add(this.button6);
			this.groupBox10.Location = new System.Drawing.Point(63, 292);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(328, 128);
			this.groupBox10.TabIndex = 18;
			this.groupBox10.TabStop = false;
			this.groupBox10.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.groupBox10.Text = "Causale di debito";
			this.groupBox10.UseCompatibleTextRendering = true;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(120, 16);
			this.textBox7.Multiline = true;
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(200, 80);
			this.textBox7.TabIndex = 2;
			this.textBox7.TabStop = false;
			this.textBox7.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(8, 102);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?profserviceview.codemotivedebit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 73);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(106, 23);
			this.button6.TabIndex = 0;
			this.button6.Tag = "manage.accmotiveapplied_debit.tree";
			this.button6.Text = "Causale";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.txtCodiceCausale);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Location = new System.Drawing.Point(63, 33);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 135);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Tag = "AutoManage.txtCodiceCausale.tree.(in_use = \'S\')";
			this.groupBox1.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(120, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(200, 87);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(7, 109);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(313, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?profserviceview.codemotive";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 80);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(108, 23);
			this.button5.TabIndex = 0;
			this.button5.Tag = "manage.accmotiveapplied.tree";
			this.button5.Text = "Causale";
			// 
			// tabDALIA
			// 
			this.tabDALIA.Controls.Add(this.groupBox3);
			this.tabDALIA.Controls.Add(this.gboxDipartimento);
			this.tabDALIA.Controls.Add(this.grpCausaliAssunzioneDalia);
			this.tabDALIA.Controls.Add(this.txtVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.btnVoceSpesaDalia);
			this.tabDALIA.Controls.Add(this.groupBox2);
			this.tabDALIA.Location = new System.Drawing.Point(4, 23);
			this.tabDALIA.Name = "tabDALIA";
			this.tabDALIA.Padding = new System.Windows.Forms.Padding(3);
			this.tabDALIA.Size = new System.Drawing.Size(943, 553);
			this.tabDALIA.TabIndex = 10;
			this.tabDALIA.Text = "DALIA";
			this.tabDALIA.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbDaliaFunzionale);
			this.groupBox3.Location = new System.Drawing.Point(14, 266);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(387, 54);
			this.groupBox3.TabIndex = 117;
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
			this.cmbDaliaFunzionale.Tag = "profservice.iddalia_funzionale";
			// 
			// gboxDipartimento
			// 
			this.gboxDipartimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxDipartimento.Controls.Add(this.btnDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtCodiceDipartimento);
			this.gboxDipartimento.Controls.Add(this.txtDaliaDipartimento);
			this.gboxDipartimento.Location = new System.Drawing.Point(14, 210);
			this.gboxDipartimento.Name = "gboxDipartimento";
			this.gboxDipartimento.Size = new System.Drawing.Size(922, 50);
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
			this.txtCodiceDipartimento.Location = new System.Drawing.Point(809, 19);
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
			this.txtDaliaDipartimento.Size = new System.Drawing.Size(674, 20);
			this.txtDaliaDipartimento.TabIndex = 0;
			this.txtDaliaDipartimento.Tag = "dalia_dipartimento.title";
			// 
			// grpCausaliAssunzioneDalia
			// 
			this.grpCausaliAssunzioneDalia.Controls.Add(this.txtCausaleAssunzione);
			this.grpCausaliAssunzioneDalia.Controls.Add(this.btnEsclusioneCIG);
			this.grpCausaliAssunzioneDalia.Location = new System.Drawing.Point(14, 148);
			this.grpCausaliAssunzioneDalia.Name = "grpCausaliAssunzioneDalia";
			this.grpCausaliAssunzioneDalia.Size = new System.Drawing.Size(922, 46);
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
			this.txtCausaleAssunzione.Size = new System.Drawing.Size(793, 20);
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
			this.txtVoceSpesaDalia.Location = new System.Drawing.Point(217, 110);
			this.txtVoceSpesaDalia.Name = "txtVoceSpesaDalia";
			this.txtVoceSpesaDalia.ReadOnly = true;
			this.txtVoceSpesaDalia.Size = new System.Drawing.Size(713, 20);
			this.txtVoceSpesaDalia.TabIndex = 112;
			// 
			// btnVoceSpesaDalia
			// 
			this.btnVoceSpesaDalia.Location = new System.Drawing.Point(23, 110);
			this.btnVoceSpesaDalia.Name = "btnVoceSpesaDalia";
			this.btnVoceSpesaDalia.Size = new System.Drawing.Size(185, 23);
			this.btnVoceSpesaDalia.TabIndex = 32;
			this.btnVoceSpesaDalia.Text = "Seleziona Voce di spesa Dalia";
			this.btnVoceSpesaDalia.UseVisualStyleBackColor = true;
			this.btnVoceSpesaDalia.Click += new System.EventHandler(this.btnVoceSpesaDalia_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label91);
			this.groupBox2.Controls.Add(this.btnQualificaDalia);
			this.groupBox2.Controls.Add(this.textBox8);
			this.groupBox2.Controls.Add(this.cmb_dalia_position);
			this.groupBox2.Location = new System.Drawing.Point(14, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(922, 80);
			this.groupBox2.TabIndex = 110;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Banca Dati DALIA";
			// 
			// label91
			// 
			this.label91.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(797, 26);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(118, 13);
			this.label91.TabIndex = 110;
			this.label91.Text = "Codice Qualifica DALIA";
			// 
			// btnQualificaDalia
			// 
			this.btnQualificaDalia.Location = new System.Drawing.Point(78, 41);
			this.btnQualificaDalia.Name = "btnQualificaDalia";
			this.btnQualificaDalia.Size = new System.Drawing.Size(116, 23);
			this.btnQualificaDalia.TabIndex = 113;
			this.btnQualificaDalia.Text = "Qualifica Dalia";
			this.btnQualificaDalia.UseVisualStyleBackColor = true;
			this.btnQualificaDalia.Click += new System.EventHandler(this.btnQualificaDalia_Click);
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(797, 42);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(117, 20);
			this.textBox8.TabIndex = 109;
			this.textBox8.Tag = "dalia_position.codedaliaposition";
			// 
			// cmb_dalia_position
			// 
			this.cmb_dalia_position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmb_dalia_position.DataSource = this.DS.dalia_position;
			this.cmb_dalia_position.DisplayMember = "description";
			this.cmb_dalia_position.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_dalia_position.Location = new System.Drawing.Point(203, 41);
			this.cmb_dalia_position.Name = "cmb_dalia_position";
			this.cmb_dalia_position.Size = new System.Drawing.Size(579, 21);
			this.cmb_dalia_position.TabIndex = 6;
			this.cmb_dalia_position.Tag = "profservice.iddaliaposition";
			this.cmb_dalia_position.ValueMember = "iddaliaposition";
			// 
			// tabANAC
			// 
			this.tabANAC.Controls.Add(this.tabControlAnac);
			this.tabANAC.Location = new System.Drawing.Point(4, 23);
			this.tabANAC.Name = "tabANAC";
			this.tabANAC.Size = new System.Drawing.Size(943, 553);
			this.tabANAC.TabIndex = 11;
			this.tabANAC.Text = "ANAC";
			this.tabANAC.UseVisualStyleBackColor = true;
			// 
			// tabControlAnac
			// 
			this.tabControlAnac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlAnac.Controls.Add(this.tabPartecipanti);
			this.tabControlAnac.Controls.Add(this.tabLotti);
			this.tabControlAnac.Location = new System.Drawing.Point(8, 16);
			this.tabControlAnac.Name = "tabControlAnac";
			this.tabControlAnac.SelectedIndex = 0;
			this.tabControlAnac.Size = new System.Drawing.Size(928, 527);
			this.tabControlAnac.TabIndex = 53;
			// 
			// tabPartecipanti
			// 
			this.tabPartecipanti.Controls.Add(this.btnAggiungiAggiudicatario);
			this.tabPartecipanti.Controls.Add(this.label65);
			this.tabPartecipanti.Controls.Add(this.gridAVCP);
			this.tabPartecipanti.Controls.Add(this.btnLottiAppaltati);
			this.tabPartecipanti.Controls.Add(this.btnDelAVCP);
			this.tabPartecipanti.Controls.Add(this.btnEditAVCP);
			this.tabPartecipanti.Controls.Add(this.btnLottiPartecipati);
			this.tabPartecipanti.Controls.Add(this.btnInsAVCP);
			this.tabPartecipanti.Location = new System.Drawing.Point(4, 22);
			this.tabPartecipanti.Name = "tabPartecipanti";
			this.tabPartecipanti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPartecipanti.Size = new System.Drawing.Size(920, 501);
			this.tabPartecipanti.TabIndex = 1;
			this.tabPartecipanti.Text = "Partecipanti al bando";
			this.tabPartecipanti.UseVisualStyleBackColor = true;
			// 
			// btnAggiungiAggiudicatario
			// 
			this.btnAggiungiAggiudicatario.Location = new System.Drawing.Point(9, 213);
			this.btnAggiungiAggiudicatario.Name = "btnAggiungiAggiudicatario";
			this.btnAggiungiAggiudicatario.Size = new System.Drawing.Size(96, 37);
			this.btnAggiungiAggiudicatario.TabIndex = 27;
			this.btnAggiungiAggiudicatario.Text = "Aggiungi Aggiudicatario";
			this.btnAggiungiAggiudicatario.UseVisualStyleBackColor = true;
			this.btnAggiungiAggiudicatario.Click += new System.EventHandler(this.btnAggiungiAggiudicatario_Click);
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(108, 16);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(215, 13);
			this.label65.TabIndex = 29;
			this.label65.Text = "Ditte o raggruppamenti partecipanti alla gara";
			// 
			// gridAVCP
			// 
			this.gridAVCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridAVCP.DataMember = "";
			this.gridAVCP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridAVCP.Location = new System.Drawing.Point(111, 32);
			this.gridAVCP.Name = "gridAVCP";
			this.gridAVCP.ReadOnly = true;
			this.gridAVCP.Size = new System.Drawing.Size(794, 464);
			this.gridAVCP.TabIndex = 28;
			this.gridAVCP.Tag = "profserviceavcp.lista.single";
			// 
			// btnLottiAppaltati
			// 
			this.btnLottiAppaltati.Location = new System.Drawing.Point(8, 184);
			this.btnLottiAppaltati.Name = "btnLottiAppaltati";
			this.btnLottiAppaltati.Size = new System.Drawing.Size(96, 23);
			this.btnLottiAppaltati.TabIndex = 26;
			this.btnLottiAppaltati.Text = "Lotti appaltati";
			this.btnLottiAppaltati.UseVisualStyleBackColor = true;
			this.btnLottiAppaltati.Click += new System.EventHandler(this.btnLottiAppaltati_Click);
			// 
			// btnDelAVCP
			// 
			this.btnDelAVCP.Location = new System.Drawing.Point(10, 92);
			this.btnDelAVCP.Name = "btnDelAVCP";
			this.btnDelAVCP.Size = new System.Drawing.Size(68, 24);
			this.btnDelAVCP.TabIndex = 27;
			this.btnDelAVCP.Tag = "delete";
			this.btnDelAVCP.Text = "Elimina";
			// 
			// btnEditAVCP
			// 
			this.btnEditAVCP.Location = new System.Drawing.Point(9, 62);
			this.btnEditAVCP.Name = "btnEditAVCP";
			this.btnEditAVCP.Size = new System.Drawing.Size(69, 24);
			this.btnEditAVCP.TabIndex = 26;
			this.btnEditAVCP.Tag = "edit.single";
			this.btnEditAVCP.Text = "Modifica...";
			// 
			// btnLottiPartecipati
			// 
			this.btnLottiPartecipati.Location = new System.Drawing.Point(8, 144);
			this.btnLottiPartecipati.Name = "btnLottiPartecipati";
			this.btnLottiPartecipati.Size = new System.Drawing.Size(96, 34);
			this.btnLottiPartecipati.TabIndex = 25;
			this.btnLottiPartecipati.Text = "Lotti a cui partecipa";
			this.btnLottiPartecipati.UseVisualStyleBackColor = true;
			this.btnLottiPartecipati.Click += new System.EventHandler(this.btnLottiPartecipati_Click);
			// 
			// btnInsAVCP
			// 
			this.btnInsAVCP.Location = new System.Drawing.Point(9, 32);
			this.btnInsAVCP.Name = "btnInsAVCP";
			this.btnInsAVCP.Size = new System.Drawing.Size(68, 24);
			this.btnInsAVCP.TabIndex = 25;
			this.btnInsAVCP.Tag = "insert.single";
			this.btnInsAVCP.Text = "Inserisci...";
			// 
			// tabLotti
			// 
			this.tabLotti.Controls.Add(this.button4);
			this.tabLotti.Controls.Add(this.btnPartecipantiNonAssociati);
			this.tabLotti.Controls.Add(this.btnPartecipantiAlLotto);
			this.tabLotti.Controls.Add(this.btnOrdiniNoPartecipanti);
			this.tabLotti.Controls.Add(this.button8);
			this.tabLotti.Controls.Add(this.btnOrdiniNoLotti);
			this.tabLotti.Controls.Add(this.button9);
			this.tabLotti.Controls.Add(this.label66);
			this.tabLotti.Controls.Add(this.gridLotti);
			this.tabLotti.Location = new System.Drawing.Point(4, 22);
			this.tabLotti.Name = "tabLotti";
			this.tabLotti.Padding = new System.Windows.Forms.Padding(3);
			this.tabLotti.Size = new System.Drawing.Size(920, 501);
			this.tabLotti.TabIndex = 0;
			this.tabLotti.Text = "Lotti del bando";
			this.tabLotti.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(16, 37);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(68, 24);
			this.button4.TabIndex = 44;
			this.button4.Tag = "insert.single";
			this.button4.Text = "Inserisci...";
			// 
			// btnPartecipantiNonAssociati
			// 
			this.btnPartecipantiNonAssociati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPartecipantiNonAssociati.Location = new System.Drawing.Point(472, 9);
			this.btnPartecipantiNonAssociati.Name = "btnPartecipantiNonAssociati";
			this.btnPartecipantiNonAssociati.Size = new System.Drawing.Size(184, 23);
			this.btnPartecipantiNonAssociati.TabIndex = 51;
			this.btnPartecipantiNonAssociati.Text = "Partecipanti non associati ai lotti";
			this.btnPartecipantiNonAssociati.UseVisualStyleBackColor = true;
			this.btnPartecipantiNonAssociati.Click += new System.EventHandler(this.btnPartecipantiNonAssociati_Click);
			// 
			// btnPartecipantiAlLotto
			// 
			this.btnPartecipantiAlLotto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPartecipantiAlLotto.Location = new System.Drawing.Point(8, 332);
			this.btnPartecipantiAlLotto.Name = "btnPartecipantiAlLotto";
			this.btnPartecipantiAlLotto.Size = new System.Drawing.Size(77, 47);
			this.btnPartecipantiAlLotto.TabIndex = 43;
			this.btnPartecipantiAlLotto.Text = "Partecipanti al lotto";
			this.btnPartecipantiAlLotto.UseVisualStyleBackColor = true;
			this.btnPartecipantiAlLotto.Click += new System.EventHandler(this.btnPartecipantiAlLotto_Click);
			// 
			// btnOrdiniNoPartecipanti
			// 
			this.btnOrdiniNoPartecipanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOrdiniNoPartecipanti.Location = new System.Drawing.Point(302, 9);
			this.btnOrdiniNoPartecipanti.Name = "btnOrdiniNoPartecipanti";
			this.btnOrdiniNoPartecipanti.Size = new System.Drawing.Size(149, 23);
			this.btnOrdiniNoPartecipanti.TabIndex = 50;
			this.btnOrdiniNoPartecipanti.Text = "Parcelle senza partecipanti";
			this.btnOrdiniNoPartecipanti.UseVisualStyleBackColor = true;
			this.btnOrdiniNoPartecipanti.Click += new System.EventHandler(this.btnOrdiniNoPartecipanti_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(16, 67);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(69, 24);
			this.button8.TabIndex = 45;
			this.button8.Tag = "edit.single";
			this.button8.Text = "Modifica...";
			// 
			// btnOrdiniNoLotti
			// 
			this.btnOrdiniNoLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOrdiniNoLotti.Location = new System.Drawing.Point(172, 9);
			this.btnOrdiniNoLotti.Name = "btnOrdiniNoLotti";
			this.btnOrdiniNoLotti.Size = new System.Drawing.Size(109, 23);
			this.btnOrdiniNoLotti.TabIndex = 49;
			this.btnOrdiniNoLotti.Text = "Parcelle senza lotti";
			this.btnOrdiniNoLotti.UseVisualStyleBackColor = true;
			this.btnOrdiniNoLotti.Click += new System.EventHandler(this.btnOrdiniNoLotti_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(16, 97);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(68, 24);
			this.button9.TabIndex = 46;
			this.button9.Tag = "delete";
			this.button9.Text = "Elimina";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(111, 37);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(228, 13);
			this.label66.TabIndex = 48;
			this.label66.Text = "Lotti del bando ai fini della pubblicazione AVCP";
			// 
			// gridLotti
			// 
			this.gridLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridLotti.DataMember = "";
			this.gridLotti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridLotti.Location = new System.Drawing.Point(114, 54);
			this.gridLotti.Name = "gridLotti";
			this.gridLotti.ReadOnly = true;
			this.gridLotti.Size = new System.Drawing.Size(548, 338);
			this.gridLotti.TabIndex = 47;
			this.gridLotti.Tag = "profservicecig.lista.detail";
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(331, 452);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(265, 16);
			this.label57.TabIndex = 21;
			this.label57.Text = "Data correzione causale di debito";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(330, 471);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(134, 20);
			this.textBox4.TabIndex = 20;
			this.textBox4.Tag = "profservice.idaccmotivedebit_datacrg";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.textBox6);
			this.groupBox11.Controls.Add(this.txtCodiceCausaleCrg);
			this.groupBox11.Controls.Add(this.button7);
			this.groupBox11.Location = new System.Drawing.Point(326, 321);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(328, 128);
			this.groupBox11.TabIndex = 21;
			this.groupBox11.TabStop = false;
			this.groupBox11.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
			this.groupBox11.Text = "Causale di debito aggiornata";
			this.groupBox11.UseCompatibleTextRendering = true;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(120, 16);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(200, 80);
			this.textBox6.TabIndex = 2;
			this.textBox6.TabStop = false;
			this.textBox6.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(6, 102);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?profserviceview.codemotivedebit_crg";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(10, 73);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 23);
			this.button7.TabIndex = 0;
			this.button7.Tag = "manage.accmotiveapplied_crg.tree";
			this.button7.Text = "Causale";
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(18, 94);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 94;
			this.chkCasellarioGiud.Tag = "profservice.requested_doc:3";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(18, 118);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 95;
			this.chkCasellarioAmm.Tag = "profservice.requested_doc:4";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(18, 142);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 96;
			this.chkOttempLegge.Tag = "profservice.requested_doc:5";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFisc
			// 
			this.chkRegolaritaFisc.AutoSize = true;
			this.chkRegolaritaFisc.Location = new System.Drawing.Point(18, 166);
			this.chkRegolaritaFisc.Name = "chkRegolaritaFisc";
			this.chkRegolaritaFisc.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFisc.TabIndex = 97;
			this.chkRegolaritaFisc.Tag = "profservice.requested_doc:6";
			this.chkRegolaritaFisc.Text = "Regolarità Fiscale";
			this.chkRegolaritaFisc.UseVisualStyleBackColor = true;
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(18, 190);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 98;
			this.chkVerificaAnac.Tag = "profservice.requested_doc:7";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dgrAllegati);
			this.tabAllegati.Controls.Add(this.btnDelAtt);
			this.tabAllegati.Controls.Add(this.btnEditAtt);
			this.tabAllegati.Controls.Add(this.btnInsAtt);
			this.tabAllegati.Location = new System.Drawing.Point(4, 23);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Size = new System.Drawing.Size(943, 553);
			this.tabAllegati.TabIndex = 12;
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
			this.dgrAllegati.Location = new System.Drawing.Point(8, 40);
			this.dgrAllegati.Name = "dgrAllegati";
			this.dgrAllegati.ReadOnly = true;
			this.dgrAllegati.Size = new System.Drawing.Size(927, 505);
			this.dgrAllegati.TabIndex = 27;
			this.dgrAllegati.Tag = "profserviceattachment.lista.detail";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(168, 10);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 23);
			this.btnDelAtt.TabIndex = 26;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(88, 10);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(69, 23);
			this.btnEditAtt.TabIndex = 25;
			this.btnEditAtt.Tag = "edit.detail";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(8, 10);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 23);
			this.btnInsAtt.TabIndex = 24;
			this.btnInsAtt.Tag = "insert.detail";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// Frm_profservice_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(951, 580);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_profservice_default";
			this.Text = "frmcontrattoprofessionale";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabContratto.ResumeLayout(false);
			this.tabContratto.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.grpPrestazione.ResumeLayout(false);
			this.grpPercipiente.ResumeLayout(false);
			this.grpPercipiente.PerformLayout();
			this.grpContratto.ResumeLayout(false);
			this.grpContratto.PerformLayout();
			this.tabCalcolo.ResumeLayout(false);
			this.tabCalcolo.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.tabRitenute.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabSpese.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabFatturazione.ResumeLayout(false);
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
			this.gboxInvoice.ResumeLayout(false);
			this.gboxInvoice.PerformLayout();
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
			this.tabAP.ResumeLayout(false);
			this.grpBoxMotivo.ResumeLayout(false);
			this.grpBoxMotivo.PerformLayout();
			this.grpBoxDocAutorizzattivo.ResumeLayout(false);
			this.grpBoxDocAutorizzattivo.PerformLayout();
			this.grpBoxAutorizzazioneAP.ResumeLayout(false);
			this.grpBoxAutorizzazioneAP.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.grpBoxSiopeEP.ResumeLayout(false);
			this.grpBoxSiopeEP.PerformLayout();
			this.gBoxCompetenza.ResumeLayout(false);
			this.gBoxCompetenza.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabDALIA.ResumeLayout(false);
			this.tabDALIA.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.gboxDipartimento.ResumeLayout(false);
			this.gboxDipartimento.PerformLayout();
			this.grpCausaliAssunzioneDalia.ResumeLayout(false);
			this.grpCausaliAssunzioneDalia.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabANAC.ResumeLayout(false);
			this.tabControlAnac.ResumeLayout(false);
			this.tabPartecipanti.ResumeLayout(false);
			this.tabPartecipanti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAVCP)).EndInit();
			this.tabLotti.ResumeLayout(false);
			this.tabLotti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLotti)).EndInit();
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
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

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterPrestazione = QHS.CmpEq("module", "PROFESSIONALE");
            GetData.SetStaticFilter(DS.service, filterPrestazione);
            GetData.SetStaticFilter(DS.sortingview1, filteresercizio);

            GetData.CacheTable(DS.config, filteresercizio, null, false);
            GetData.CacheTable(DS.tax, null, null, false);

            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            HelpForm.SetDenyNull(DS.profservice.Columns["requested_doc"], true);
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

            string filterEpOperationSF = QHS.CmpEq("idepoperation", "prestprof");
            string filterEpOperationEP = QHS.CmpEq("idepoperation", "prestprof");
            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationSF);
            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationEP;

            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "prestprof_deb");
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");


            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");
            DataAccess.SetTableForReading(DS.sortingview1, "sortingview");

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
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreImpegni, btnViewPreimpegni,
                btnGeneraEP, btnVisualizzaEP, labEP, null, "profservice");
            SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);

			bool IsAdmin = (Meta.GetSys("manage_prestazioni") != null) ? Meta.GetSys("manage_prestazioni").ToString() == "S" : false;
            object flag_escludidacu = Conn.GetUsr("flag_escludidacu");
            bool function_enabled = ((flag_escludidacu != null && flag_escludidacu.ToString().ToUpper() == "'S'"));
            SubEntity_chkExcludeFromCertificate.Enabled = IsAdmin||function_enabled;

        }

        siope_helper SiopeObj;




        void EnableDisableGboxInvoice() {
            if (Meta.IsEmpty) {
                gboxInvoice.Enabled = true;
            }
            else {
                gboxInvoice.Enabled = false;
            }
        }

        void EnableDisablebtnscollegainvoice() {
            if (Meta.IsEmpty)
                btnscollegainvoice.Enabled = false;
            else {
                if (cmbInvoice.SelectedIndex <= 0) {
                    btnscollegainvoice.Enabled = false;
                    return;
                }
                else
                    btnscollegainvoice.Enabled = true;
            }
        }

        public void CreaPartecipanteInAutomatico(bool manual) {
            if (DS.profserviceavcp.Select().Length > 0) return;
            DataRow curr = DS.profservice.Rows[0];
            object idreg = curr["idreg"];
            if ((idreg == DBNull.Value) || CfgFn.GetNoNullInt32(idreg) == 0) return;
            btnAggiungiAggiudicatario.Visible = false;

            if (!Meta.InsertMode && !manual) {
                btnAggiungiAggiudicatario.Visible = true;
                return;
            }

            //Crea il partecipante
            MetaData mAvcp = MetaData.GetMetaData(this, "profserviceavcp");
            mAvcp.SetDefaults(DS.profserviceavcp);
            DataRow ravcp = mAvcp.Get_New_Row(curr, DS.profserviceavcp);
            DataRow R = DS.registry.Select(QHC.CmpEq("idreg", idreg))[0];
            ravcp["idreg"] = idreg;

            if (R["cf"] != DBNull.Value) {
                ravcp["cf"] = R["cf"].ToString();
            }
            else {
                if (R["p_iva"] != DBNull.Value) {
                    string p_iva = R["p_iva"].ToString();
                    if (isPartitaEstera(p_iva)) {
                        ravcp["foreigncf"] = p_iva;
                    }
                    else {
                        ravcp["cf"] = p_iva;
                    }
                }
                else {
                    ravcp["foreigncf"] = R["foreigncf"].ToString();
                }
            }
            ravcp["title"] = R["title"];
        }

        bool isPartitaEstera(string p_iva) {
            if (p_iva == null) return false;
            if (p_iva.Length == 2) return false;
            if (Char.IsDigit(p_iva[0])) return false;
            if (Char.IsDigit(p_iva[1])) return false;
            return true;
        }

        public void MetaData_BeforeFill() {
//			if (Meta.InsertMode)
//			{
//				if (Meta.FirstFillForThisRow){
//						creaRigheRitenuta();
//						selezionaAliquotaRitenutaFiscale();
//						}
//			}
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
                if (DS.profservice.Rows.Count > 0) {
                    DataRow R = DS.profservice.Rows[0];
                    object codPrest = R["idser"];
                    // Inserisco la riga in contrattoprofritenuta
                    if (DS.profservicetax.Rows.Count == 0) {
                        aggiornaRigheRitenuta(codPrest);
                        selezionaAliquote();
                        riempiCampoIVA();
                    }
                }
            }
            if (!Meta.IsEmpty) {
                GetAliquotaIva();
            }

            if (DS.profservice.Rows.Count > 0) {
                DataRow Curr = DS.profservice.Rows[0];
                CreaPartecipanteInAutomatico(false);
            }
        }

        public void MetaData_AfterClear() {
            gBoxCompetenza.Enabled = true;
            abilitaDisabilitaDalia(null);
            abilitaDisabilitaCertificatiRichiesti(null);
            cmb_dalia_position.Enabled = true;
            AggiornaVoceSpesa();

            EnableDisablebtnscollegainvoice();
            EnableDisableGboxInvoice();
            azzeraVardiConfronto();
            azzeraTxtNonGestiti();
            txtEsercizio.ReadOnly = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            VisualizzaEtichetteAP();
            MostraNascondiAutorizzazione();
            MostraNascondiMotivazione();
            grpBoxAutorizzazioneAP.Enabled = true;
            aliquota = 0;
            grpPercipiente.Tag =
                "AutoChoose.txtPercipiente.default.((active='S') and (((p_iva != '') and (p_iva is not null)) or ((foreigncf != '') and (foreigncf is not null))))";
            Meta.SetAutoMode(grpPercipiente);
            txtAliquotaRitFisc.ReadOnly = true;
            EPM.mostraEtichette();
            SiopeObj.setCausaleEPCorrente(null);
			txtPercAddebContrPrev.ReadOnly = false;
			txtPercContrCassaPrev.ReadOnly = false;
		}


        public void MetaData_AfterGetFormData() {
            if (Meta.IsEmpty) return;

            if (DS.config.Rows.Count == 0) return;
            int flag_autodocnumbering = CfgFn.GetNoNullInt32(DS.config.Rows[0]["flag_autodocnumbering"]);
            string kind = ((flag_autodocnumbering & 0x40) == 0) ? "A" : "M";

            GetCampiRitFiscale();

            if ((Meta.InsertMode) && (kind.ToUpper() != "A")) {

                object ncon = DS.profservice.Rows[0]["ncon"];
                foreach (DataRow rDett in DS.profservicerefund.Rows) {
                    rDett["ncon"] = ncon;
                }
                foreach (DataRow rDett in DS.profservicetax.Rows) {
                    rDett["ncon"] = ncon;
                }
                foreach (DataRow rDett in DS.profservicesorting.Rows) {
                    rDett["ncon"] = ncon;
                }
            }

        }

        public void MetaData_BeforePost() {
            if (DS.profservice.Rows.Count == 0) return;
            EPM.beforePost();
            AssegnaAutomaticamenteLotti();
            CancellaSporcizie();
        }


        void AssegnaAutomaticamenteLotti() {
            DataRow curr = DS.profservice.Rows[0];
            //Se non ci sono lotti non c'è nulla da fare
            if (DS.profservicecig.Select().Length == 0) return;

            MetaData manvcpdet = MetaData.GetMetaData(this, "profserviceavcpdetail");
            if (DS.profservicecig.Select().Length == 1) {
                //Un solo lotto
                string cigcode = DS.profservicecig.Select()[0]["cigcode"].ToString();
                //per ogni partecipante crea la riga in mandateavcpdetail che lo collega al lotto
                foreach (DataRow part in DS.profserviceavcp.Select()) {
                    object idavcp = part["idavcp"];
                    string chk = QHC.AppAnd(QHC.CmpEq("cigcode", cigcode),
                        QHC.CmpEq("idavcp", idavcp));
                    if (DS.profserviceavcpdetail.Select(chk).Length > 0) continue;
                    manvcpdet.SetDefaults(DS.profserviceavcpdetail);
                    MetaData.SetDefault(DS.profserviceavcpdetail, "idavcp", idavcp);
                    MetaData.SetDefault(DS.profserviceavcpdetail, "cigcode", cigcode);
                    DataRow newdet = manvcpdet.Get_New_Row(curr, DS.profserviceavcpdetail);

                }
                //foreach (DataRow r in DS.mandatedetail.Select()) {
                //    if (r["cigcode"] == DBNull.Value) r["cigcode"] = cigcode;
                //}
                //if (curr["cigcode"] == DBNull.Value) {
                //    curr["cigcode"] = cigcode;
                //}
            }

            object mainidreg = curr["idreg"];
            object idavcpmain = findIdavcpByIDreg(mainidreg);

            //Assegna l'anagrafica appaltante come partecipante a tutti i lotti ove già non lo sia
            foreach (DataRow rd in DS.profservicecig.Select()) {
//mandatedetail
                object cigcode = rd["cigcode"];
                if (cigcode == DBNull.Value) continue;
                object idreg = curr["idreg"];
                object idavcp = idavcpmain;
                if (idavcp == DBNull.Value) idavcp = findIdavcpByIDreg(idreg);
                if (idavcp == DBNull.Value) continue;

                string chk = QHC.AppAnd(QHC.CmpEq("cigcode", cigcode),
                    QHC.CmpEq("idavcp", idavcp));
                if (DS.profserviceavcpdetail.Select(chk).Length > 0) continue;
                manvcpdet.SetDefaults(DS.profserviceavcpdetail);
                MetaData.SetDefault(DS.profserviceavcpdetail, "idavcp", idavcp);
                MetaData.SetDefault(DS.profserviceavcpdetail, "cigcode", cigcode);
                DataRow newdet = manvcpdet.Get_New_Row(curr, DS.profserviceavcpdetail);

            }

            //Assegna automaticamente i lotti appaltati in base alle anagrafiche
            //  dell'ordine e dei dettagli
            foreach (DataRow rd in DS.profservicecig.Select()) {
//mandatedetail
                object cigcode = rd["cigcode"];
                if (cigcode == DBNull.Value) continue;
                object idreg = curr["idreg"];
                object idavcp = idavcpmain;
                if (idavcp == DBNull.Value) idavcp = findIdavcpByIDreg(idreg);
                if (idavcp != DBNull.Value) Appalta(idavcp, cigcode);
            }
        }

        void Appalta(object idavcp, object cigcode) {
            DataRow[] mancig = DS.profservicecig.Select(QHC.CmpEq("cigcode", cigcode));
            if (mancig.Length == 0) return;
            if (mancig[0]["idavcp"] != DBNull.Value && idavcp == DBNull.Value) return;
            mancig[0]["idavcp"] = idavcp;
        }

        void CancellaSporcizie() {
            //cancella qualsiasi cadavere in mandateavcpdetail o
            // riferimento da mandatecig a righe inesistenti
            if (Meta.edit_type != "request") {

                foreach (DataRow mcig in DS.profservicecig.Select()) {
                    object idavcp = mcig["idavcp"];
                    if (DS.profserviceavcp.Select(QHC.CmpEq("idavcp", idavcp)).Length == 0) {
                        mcig.Delete();
                        continue;
                    }
                }
            }
            foreach (DataRow avdet in DS.profserviceavcpdetail.Select()) {
                object cigcode = avdet["cigcode"];
                object idavcp = avdet["idavcp"];
                if (DS.profservicecig.Select(QHC.CmpEq("cigcode", cigcode)).Length == 0) {
                    avdet.Delete();
                    continue;
                }
                if (DS.profserviceavcp.Select(QHC.CmpEq("idavcp", idavcp)).Length == 0) {
                    avdet.Delete();
                    continue;
                }

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
            EPM.afterPost();
            if (Meta.PrimaryDataTable.Rows.Count > 0) {
                VisualizzaEtichetteAP();
                AvvisoAnagrafePrestazioni();
            }
        }

        private void azzeraTxtNonGestiti() {
            txtImportoAddebContrPrev.Text = "";
            txtImportoContrCassaPrev.Text = "";
            txtImponibileIVA.Text = "";
            //Curr["!imponibileiva"] = 0; // sarà usato per l'ANAC
            txtImportoNetto.Text = "";
            txtTotaleSpese.Text = "";
            txtIva.Text = "";
            txtImponibilePrevidenza.Text = "";
            txtSpeseDed.Text = "";
            txtSpeseNoF.Text = "";
            txtSpeseNoIva.Text = "";
            txtSpeseNoP.Text = "";
        }

//		public void creaRigheRitenuta()
//		{
//			if (Meta.IsEmpty) return;
//			DataRow Curr = DS.profservice[0];
//
//			string filtroRitenInPrestazione = "(idser = " + QueryCreator.quotedstrvalue(Curr["idser"],true) + 
//				") AND (taxkind = 'F')";
//
//			object codiceRitenuta = Meta.Conn.DO_READ_VALUE("servicetaxview", filtroRitenInPrestazione, "taxcode");
//			if (codiceRitenuta == null) codiceRitenuta = "";
//			lastRitenuta = codiceRitenuta.ToString();
//			
//			string filtroPerTabellaRitenuta = "(ycon = " + QueryCreator.quotedstrvalue(Curr["ycon"],false) +
//				") AND (ncon = " + QueryCreator.quotedstrvalue(Curr["ncon"],false) + 
//				") AND (taxcode = " + QueryCreator.quotedstrvalue(codiceRitenuta,false) + ")";
//			DataRow [] r = DS.profservicetax.Select(filtroPerTabellaRitenuta);
//			if (r.Length == 0) {
//				DataRow drContratto = DS.Tables["profservice"].Rows[0];
//				MetaData metaRiten = MetaData.GetMetaData(this,"profservicetax");
//				metaRiten.SetDefaults(DS.profservicetax);
//				MetaData.SetDefault(DS.profservicetax,"taxcode",codiceRitenuta);
//				DataRow drRitenuta = metaRiten.Get_New_Row(drContratto,DS.profservicetax);
//			}
//		}

        public void creaRigheRitenuta(object codiceRitenuta) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.profservice.Rows[0];

//			string filtroRitenInPrestazione = "(idser = " + QueryCreator.quotedstrvalue(Curr["idser"],true) + 
//				") AND (taxkind = 'F')";
//
//			object codiceRitenuta = Meta.Conn.DO_READ_VALUE("servicetaxview", filtroRitenInPrestazione, "taxcode");
//			if (codiceRitenuta == null) codiceRitenuta = "";
            if (codiceRitenuta == null) codiceRitenuta = 0;
//			lastRitenuta = codiceRitenuta.ToString();

            string filtroPerTabellaRitenuta = QHC.CmpEq("taxcode", codiceRitenuta);
            DataRow[] r = DS.profservicetax.Select(filtroPerTabellaRitenuta);

            if (r.Length == 0) {
                MetaData metaRiten = MetaData.GetMetaData(this, "profservicetax");
                metaRiten.SetDefaults(DS.profservicetax);
                MetaData.SetDefault(DS.profservicetax, "taxcode", codiceRitenuta);
                DataRow drRitenuta = metaRiten.Get_New_Row(Curr, DS.profservicetax);
            }

        }


        private void cancellaRigheRitenuta() {
            if (DS.profservice.Rows.Count == 0) return;
            foreach (DataRow drRitenuta in DS.profservicetax.Select()) {
                drRitenuta.Delete();
            }
        }

//		private void aggiornaRigheRitenuta(string codPrest)
//		{
//			DataRow Curr = DS.profservicetax.Rows[0];
//			string filtroRitenInPrestazione = "(idser = " + QueryCreator.quotedstrvalue(codPrest,true) + 
//				") AND (taxkind = 'F')";
//
//			object codiceRitenuta = Meta.Conn.DO_READ_VALUE("servicetaxview", filtroRitenInPrestazione, "taxcode");
//			Curr["taxcode"] = codiceRitenuta;
//		}

        private void aggiornaRigheRitenuta(object codPrest) {
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                DS.profservicetax.RejectChanges();
                DataRow[] OldList = DS.profservicetax.Select();
                // Seleziono le ritenute della nuova prestazione
                string filtroRitenInPrestazione = QHS.CmpEq("idser", codPrest);
                DataTable RitProf = Conn.RUN_SELECT("servicetaxview", "*", null, filtroRitenInPrestazione, null, false);
                foreach (DataRow rit in RitProf.Select()) {
                    object codiceRitenuta = rit["taxcode"];
                    creaRigheRitenuta(codiceRitenuta); //La crea solo se non c'è  già
                }

                //Cancella le ritenute in DS.profservicetax che non sono in RitProf
                foreach (DataRow rold in OldList) {
                    if (RitProf.Select(QHC.CmpEq("taxcode", rold["taxcode"])).Length == 0) {
                        rold.Delete();
                    }
                }

            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            DataRow Curr = DS.profservice.Rows[0];
            switch (T.TableName) {
                case "sortingview1": {
                    if (R == null) return;
                    if (Meta.IsEmpty) return;
                    selezionaVoceSpesaDalia(R["idsor"]);
                    return;
                }
                case "service": {
                    abilitaDisabilitaDalia(R);
					abilitaDisabilitaCertificatiRichiesti(R);
					assegnaNomeRitenuta();
                    
					if (R == null) {
						lastPrestazioneRitenute = 0;
						cancellaRigheRitenuta();
						if ((Meta.InsertMode) || (Meta.EditMode)) {
							ricalcolaCostoTotale();
						}
						return;
					}
					object codPrest = R["idser"];
					if (CfgFn.GetNoNullInt32(codPrest) != lastPrestazioneRitenute) {
						// Se cambia la prestazione aggiorno la riga di contrattoprofritenuta
						aggiornaRigheRitenuta(codPrest);
						selezionaAliquote();
						lastPrestazioneRitenute = CfgFn.GetNoNullInt32(codPrest);
						riempiCampoIVA();
						if ((Meta.InsertMode) || (Meta.EditMode)) {
							ricalcolaCostoTotale();
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
                        if (DaliaAbilitato) {
                            scegliDalia = true;
                        }

                    }
                    // Se cambia l'anagrafica imposta il valore di default X
                    Curr["authneeded"] = "X";
                    rdbNonApplicabile.Checked = true;
                    if (!Meta.IsEmpty) CreaPartecipanteInAutomatico(false);
                    if (scegliDalia) {
                        selezionaQualificaDalia(true);
                    }
                    break;
                }

                case "ivakind": {
                    if (T.TableName == "ivakind") {
                        if (R != null) {
                            aliquota = CfgFn.GetNoNullDecimal(R["rate"]);
                        }
                        else {
                            aliquota = 0;
                        }
                        if (Meta.DrawStateIsDone) {
                            //if (inChiusura) return;
                            ricalcolaCostoTotale();
                        }
                    }
                    break;
                }
            case "accmotiveapplied": {
                        SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                        SiopeObj.selectSiope();
                        break;
                }
                //				case "profservicerefund":
                //				{
                //					decimal totSpese = ricalcolaTotaleSpese();
                //					if (lastTotSpese != totSpese)
                //					{
                //						lastTotSpese = totSpese;
                //						txtTotaleSpese.Text = lastTotSpese.ToString("c");
                //						ricalcolaCostoTotale();
                //					}
                //					break;
                //				}
            }
        }

        void GetAliquotaIva() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.profservice.Rows[0];
            string idivakind = Curr["idivakind"].ToString();
            if (idivakind == "") return;
            DataRow[] IvaKindRow = DS.ivakind.Select(QHC.CmpEq("idivakind", idivakind));
            if (IvaKindRow.Length > 0) {
                aliquota = CfgFn.GetNoNullDecimal(IvaKindRow[0]["rate"]);
            }
        }

        private decimal ricalcolaTotaleSpese() {
            if (Meta.IsEmpty) return 0;
            decimal totaleSpese = 0;
            DataRow[] R = DS.profservicerefund.Select();
            if (R.Length == 0) return 0;
            for (int i = 0; i < R.Length; i++) {
                totaleSpese += CfgFn.GetNoNullDecimal(R[i]["amount"]);
            }
            return totaleSpese;
        }

        private decimal ricalcolaTotSpeseNoDed(string kind) {
            return ricalcolaTotSpese(kind, false);
        }

        private decimal ricalcolaTotSpeseDed(string kind) {
            return ricalcolaTotSpese(kind, true);
        }

        /// <summary>
        /// Calcola il totale spese deducibili o meno ai fini Iva(I), Fiscali(F), Previdenziali(P)
        /// </summary>
        /// <param name="kind">Iva/Fiscali/Previdenziali</param>
        /// <param name="deducibile">true per avere le spese non imponibili, false per le imponibili</param>
        /// <returns></returns>
        private decimal ricalcolaTotSpese(string kind, bool deducibile) {
            string val = deducibile ? "S" : "N";
            string field = "";
            switch (kind) {
                case "I": {
                    field = "flagivadeduction";
                    break;
                }
                case "F": {
                    field = "flagfiscaldeduction";
                    break;
                }
                case "P": {
                    field = "flagsecuritydeduction";
                    break;
                }
                default: {
                    show("Errore interno campo inesistente - Contattare il servizio assistenza");
                    Meta.CanInsert = false;
                    Meta.CanInsertCopy = false;
                    Meta.CanSave = false;
                    Meta.FreshToolBar();
                    return 0;
                }
            }
            if (Meta.IsEmpty) return 0;
            decimal totaleSpese = 0;
            DataRow[] R = DS.profservicerefund.Select();
            if (R.Length == 0) return 0;
            for (int i = 0; i < R.Length; i++) {
                string fTipoSpesa = QHC.CmpEq("idlinkedrefund", R[i]["idlinkedrefund"]);
                DataRow[] rSpesa = DS.profrefund.Select(fTipoSpesa);
                if (rSpesa.Length == 0) continue;
                if (rSpesa[0][field].ToString().ToUpper() != val) continue;
                totaleSpese += CfgFn.GetNoNullDecimal(R[i]["amount"]);
            }
            return totaleSpese;
        }


        private decimal ricalcolaTotSpese() {
            if (Meta.IsEmpty) return 0;
            decimal totaleSpese = 0;
            DataRow[] R = DS.profservicerefund.Select();
            if (R.Length == 0) return 0;
            for (int i = 0; i < R.Length; i++) {
                totaleSpese += CfgFn.GetNoNullDecimal(R[i]["amount"]);
            }
            return totaleSpese;
        }

        private void riempiCampoIVA() {
            if (Meta.IsEmpty) return;
            if (cmbTipoPrestazione.SelectedIndex <= 0) return;
            string filtro = QHC.CmpEq("idser", cmbTipoPrestazione.SelectedValue);
            DataRow Curr = DS.service.Select(filtro)[0];
            if (Curr["ivaamount"] == DBNull.Value) return;
            int campoIVA = 1;
            DS.profservice.Rows[0]["ivafieldnumber"] = campoIVA;
        }

		private void assegnaNomeRitenuta() {
            if (Meta.DrawStateIsDone) Meta.GetFormData(true);
            DataRow curr = DS.profservice.Rows[0];
            string nomeLabelDef = "Ritenuta Fiscale";
            if (curr["idser"] == DBNull.Value) {
                lblRitenuta.Text = nomeLabelDef + " %";
                return;
            }
            string filter = QHS.AppAnd(QHS.CmpEq("idser", curr["idser"]), QHS.CmpEq("taxkind", 1));
            object nomeRitenuta = Meta.Conn.DO_READ_VALUE("servicetaxview", filter, "tax");
            lblRitenuta.Text = (nomeRitenuta == null) ? nomeLabelDef + " %" : nomeRitenuta.ToString() + " %";
        }

        private void selezionaAliquotaRitenuta(DataRow drRitenuta) {
            //			if (drRitenuta[0]["employrate"] != DBNull.Value) return;
            object codiceRitenuta = drRitenuta["taxcode"];
            DataRow curr = DS.profservice.Rows[0];

            string filterStruttura = QHS.AppAnd(QHS.CmpEq("taxcode", codiceRitenuta),
                QHS.CmpLe("start", curr["adate"]));
            DataTable dtStruttura = DataAccess.RUN_SELECT(Meta.Conn, "taxratestart",
                null,
                "start desc", filterStruttura, "1", null, true);


            DataRow Tax = DS.tax.Select(QHS.CmpEq("taxcode", codiceRitenuta))[0];
            string taxkind = Tax["taxkind"].ToString(); //"1"=fiscale




            DataRow Found = null;
            if (dtStruttura != null && dtStruttura.Rows.Count > 0) {
                DataRow CurrStart = dtStruttura.Rows[0];

                string filterAliquota = QHS.AppAnd(QHS.CmpEq("taxcode", codiceRitenuta),
                    QHS.CmpEq("idtaxratestart", CurrStart["idtaxratestart"]));
                DataTable dtAliquota = DataAccess.RUN_SELECT(Meta.Conn, "taxratebracket",
                    null, null, filterAliquota, "1", null, true);
                if ((dtAliquota == null) || (dtAliquota.Rows.Count == 0)) return;
                Found = dtAliquota.Rows[0];

            }

            if (Found == null) return;
            drRitenuta["employrate"] = Found["employrate"];
            drRitenuta["adminrate"] = Found["adminrate"];
            drRitenuta["employnumerator"] = Found["employnumerator"];
            drRitenuta["employdenominator"] = Found["employdenominator"];
            drRitenuta["adminnumerator"] = Found["adminnumerator"];
            drRitenuta["admindenominator"] = Found["admindenominator"];
            drRitenuta["taxablenumerator"] = dtStruttura.Rows[0]["taxablenumerator"];
            drRitenuta["taxabledenominator"] = dtStruttura.Rows[0]["taxabledenominator"];
            if (taxkind == "1") {
                setLabelImponibileFiscale(
                    CfgFn.GetNoNullDecimal(dtStruttura.Rows[0]["taxablenumerator"]),
                    CfgFn.GetNoNullDecimal(dtStruttura.Rows[0]["taxabledenominator"]));
            }
        }


        private void selezionaAliquote() {
            if (Meta.IsEmpty) return;
            DataRow[] drRitenuta = DS.profservicetax.Select();
            if (drRitenuta.Length == 0) return;
            if (Meta.DrawStateIsDone) Meta.GetFormData(true);

            foreach (DataRow R in DS.profservicetax.Select()) {
                selezionaAliquotaRitenuta(R);
            }

            Meta.FreshForm();
        }

        private void costruisciFiltri() {
            azzeraVardiConfronto();

            if (Meta.IsEmpty) return;
            if (DS.profservice.Rows.Count == 0) return;
            DataRow Curr = DS.profservice.Rows[0];
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
            lastPrestazioneCalcolo = CfgFn.GetNoNullInt32(codiceprestazione);
            lastDataContabile = (DateTime) datacontabile;
            lastCompensoLordo = CfgFn.GetNoNullDecimal(compensolordo);
            lastTotSpese = ricalcolaTotaleSpese();
            lastTotSpeseNoIva = ricalcolaTotSpeseNoDed("I");
            lastTotSpeseNoF = ricalcolaTotSpeseNoDed("F");
            lastTotSpeseNoP = ricalcolaTotSpeseNoDed("P");
            lastTotSpese = ricalcolaTotSpese();
        }

        private void azzeraVardiConfronto() {
            lastCreditore = 0;
            lastPrestazioneCalcolo = 0;
            lastDataContabile = QueryCreator.EmptyDate();
            lastCompensoLordo = 0;
            lastTotSpese = 0;
            lastTotSpeseNoIva = 0;
            lastTotSpeseNoF = 0;
            lastTotSpeseNoP = 0;
            lastTotSpeseDed = 0;
        }

        /// <summary>
        /// Ricalcola gli importi delle spese e se sono cambiati, ricalcola il costo totale
        /// </summary>
        private void ricalcolaImporti() {
            bool mustRecalc = false;
            DataRow Curr = DS.profservice.Rows[0];

            if (lastCompensoLordo != CfgFn.GetNoNullDecimal(Curr["feegross"])) {
                lastCompensoLordo = CfgFn.GetNoNullDecimal(Curr["feegross"]);
                mustRecalc = true;
            }


            if (lastPrestazioneCalcolo != CfgFn.GetNoNullInt32(Curr["idser"])) {
	            lastPrestazioneCalcolo = CfgFn.GetNoNullInt32(Curr["idser"]);
                mustRecalc = true;
            }

            decimal totSpeseNoIva = ricalcolaTotSpeseNoDed("I");
            if (lastTotSpeseNoIva != totSpeseNoIva) {
                lastTotSpeseNoIva = totSpeseNoIva;
                txtSpeseNoIva.Text = lastTotSpeseNoIva.ToString("c");
                mustRecalc = true;
            }

            decimal totSpeseNoF = ricalcolaTotSpeseNoDed("F");
            if (lastTotSpeseNoF != totSpeseNoF) {
                lastTotSpeseNoF = totSpeseNoF;
                txtSpeseNoF.Text = lastTotSpeseNoF.ToString("c");
                mustRecalc = true;
            }

            decimal totSpeseNoP = ricalcolaTotSpeseNoDed("P");
            if (lastTotSpeseNoP != totSpeseNoP) {
                lastTotSpeseNoP = totSpeseNoP;
                txtSpeseNoP.Text = lastTotSpeseNoP.ToString("c");
                mustRecalc = true;
            }

            decimal totSpese = ricalcolaTotSpese();
            if (lastTotSpese != totSpese) {
                lastTotSpese = totSpese;
                txtSpeseDed.Text = lastTotSpeseDed.ToString("c");
                mustRecalc = true;
            }

            decimal totSpeseDed = TotSpeseDeducibili();
            if (lastTotSpeseDed != totSpeseDed) {
                lastTotSpeseDed = totSpeseDed;
                txtSpeseDed.Text = lastTotSpeseDed.ToString("c");
                mustRecalc = true;
            }

            if (mustRecalc) {
                ricalcolaCostoTotale();
            }
        }

        public void MostraNascondiAutorizzazione() {
            if (DS.profservice.Rows.Count == 0) {
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
            if (DS.profservice.Rows.Count == 0) {
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
            FillCampiRitFiscale();
            abilitaDisabilitaDalia(null);
            cmb_dalia_position.Enabled = false;
            AggiornaVoceSpesa();

            EPM.mostraEtichette();

            if (Meta.FirstFillForThisRow && Meta.InsertMode) {
                riempiCampoIVA();
			}

			if (Meta.InsertMode) {
				txtPercAddebContrPrev.ReadOnly = false;
				txtPercContrCassaPrev.ReadOnly = false;
			}
			else {
				txtPercAddebContrPrev.ReadOnly = true;
				txtPercContrCassaPrev.ReadOnly = true;
			}
			if (Meta.FirstFillForThisRow) {
                lastDataContabile = (DateTime) DS.profservice.Rows[0]["adate"];
            }
            ricalcolaImporti(); //assegna il valore di lastPrestazione ove sia cambiato

            if (Meta.FirstFillForThisRow) {
                //lastDataContabile = (DateTime)DS.profservice.Rows[0]["adate"];
                if (Meta.EditMode) {
                    costruisciFiltri();
                    ricalcolaTxtNonGestiti();
                }

                if (Meta.InsertMode) {
	                azzeraVardiConfronto();
                }
            }
            txtEsercizio.ReadOnly = true;

            EnableDisableGboxInvoice();
            EnableDisablebtnscollegainvoice();
            HelpForm.SetDenyNull(DS.profservice.Columns["idivakind"], true);
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
                grpPercipiente.Tag = "AutoChoose.txtPercipiente.default.((active='S') and (((p_iva != '') and (p_iva is not null)) or ((foreigncf != '') and (foreigncf is not null))))"; //and (human = 'S')			
                Meta.SetAutoMode(grpPercipiente);
            }

            btnLottiPartecipati.Visible = (DS.profservicecig.Select().Length > 1);
            btnLottiAppaltati.Visible = (DS.profservicecig.Select().Length > 1);
            //CreaPartecipanteInAutomatico();
            DataRow Current = DS.profservice.Rows[0];
            object idavcp = findIdavcpByIDreg(Current["idreg"]);
            MetaData.SetDefault(DS.profservicecig, "idavcp", idavcp);
            SiopeObj.setCausaleEPCorrente(Current["idaccmotive"]);
            if ((Meta.InsertMode) && (Meta.FirstFillForThisRow)) {
                abilitaDisabilitaCertificatiRichiesti(null);
            }

            if (Meta.EditMode) {
                //Verifica se ci sono ratei o scritture di fatt. a ricevere 
                int nRatei = Conn.RUN_SELECT_COUNT("entry", QHS.CmpEq("idrelated", EP_functions.GetIdForDocument(Current)), false);
                if (nRatei > 0) {
                    gBoxCompetenza.Enabled = false;
                }
            }

        }

        object findIdavcpByIDreg(object idreg) {
            if (idreg == DBNull.Value) return DBNull.Value;
            DataRow[] f = DS.profserviceavcp.Select(QHC.CmpEq("idreg", idreg));
            if (f.Length == 0) return DBNull.Value;
            DataRow r = f[0];
            if (r["idmain_avcp"] != DBNull.Value) return r["idmain_avcp"];
            return r["idavcp"];
        }

        private void ricalcolaTxtNonGestiti() {
            DataRow Curr = DS.profservice.Rows[0];
            decimal compensoLordo = CfgFn.GetNoNullDecimal(Curr["feegross"]);
            decimal totSpeseNoP = ricalcolaTotSpeseNoDed("P");
            decimal imponibilePrevidenziale = compensoLordo + totSpeseNoP;
            decimal importoAddebContrPrev = imponibilePrevidenziale*
                                            CfgFn.GetNoNullDecimal(Curr["pensioncontributionrate"]);
            decimal importoContrCassaPrev = (imponibilePrevidenziale + importoAddebContrPrev)*
                                            CfgFn.GetNoNullDecimal(Curr["socialsecurityrate"]);
            decimal totSpeseNoIVA = ricalcolaTotSpeseNoDed("I");
            decimal imponibileIVA = compensoLordo + importoAddebContrPrev + importoContrCassaPrev + totSpeseNoIVA;
            //         decimal importoNetto = CfgFn.GetNoNullDecimal(Curr["totalcost"]);
            //DataRow [] drRitenuta = DS.profservicetax.Select();
            //if (drRitenuta.Length > 0) {
            //	importoNetto = importoNetto - CfgFn.GetNoNullDecimal(drRitenuta[0]["employtax"]);
            //}
            txtImportoAddebContrPrev.Text = importoAddebContrPrev.ToString("c");
            txtImportoContrCassaPrev.Text = importoContrCassaPrev.ToString("c");
            txtImponibileIVA.Text = imponibileIVA.ToString("c");
            Curr["!imponibileiva"] = CfgFn.GetNoNullDecimal(imponibileIVA); // Sarà usato per l'ANAC
            //txtImportoNetto.Text = importoNetto.ToString("c");
        }

        private void txtCompensoLordo_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ricalcolaCostoTotale();
        }

        private void txtCostoTotale_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ricalcolaImportoPrestazione();
        }

        private void txtPercAddebContrPrev_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ricalcolaCostoTotale();
        }

        private void txtPercContrCassaPrev_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            ricalcolaCostoTotale();
        }

        void FillCampiRitFiscale() {
            List<DataRow> Rfs = GetTaxRow(1);
            if (Rfs.Count == 0) {
                txtNumImponibile.Text = "";
                txtDenImponibile.Text = "";
                txtImponibileFiscale.Text = "";
                txtAliquotaRitFisc.Text = "";
                txtAliquotaRitFisc.ReadOnly = true;
                txtImportoRitenuta.Text = "";
            }
            else {
                DataRow Rf = Rfs[0];
                txtNumImponibile.Text = Rf["taxablenumerator"].ToString();
                txtDenImponibile.Text = Rf["taxabledenominator"].ToString();
                txtImponibileFiscale.Text = CfgFn.GetNoNullDecimal(Rf["taxablenet"]).ToString("c");
                txtAliquotaRitFisc.Text = HelpForm.StringValue(Rf["employrate"], "x.y.fixed.4..%.100");
                txtAliquotaRitFisc.ReadOnly = true;
                txtImportoRitenuta.Text = CfgFn.GetNoNullDecimal(Rf["employtax"]).ToString("c");
            }
        }

        void GetCampiRitFiscale() {
            List<DataRow> Rfs = GetTaxRow(1);
            if (Rfs.Count == 0) return;
            DataRow Rf = Rfs[0];
            if (Rf == null) return;
            Rf["employrate"] = HelpForm.GetObjectFromString(typeof(decimal),
                txtAliquotaRitFisc.Text, "x.y.fixed.4..%.100");

        }

        private void txtAliquotaRitFisc_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDecTextBox(txtAliquotaRitFisc, "x.x.fixed.4..%.100");
            ricalcolaCostoTotale();
        }

        private decimal getValuta(object o) {
            return CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(o));
        }

        private decimal getAliquota(object o) {
            return CfgFn.Round(CfgFn.GetNoNullDecimal(o), 6);
        }

        /// <summary>
        /// Restituisce tutte le righe di profservicetax di un certo tipo (fiscale/assist./previd.)
        /// </summary>
        /// <param name="taxkind">1 fiscale 2 assistenziale 3 previdenziale</param>
        /// <returns></returns>
        List<DataRow> GetTaxRow(object taxkind) {
            List<DataRow> res = new List<DataRow>();
            foreach (DataRow ritProf in DS.profservicetax.Select()) {
                //Vede se è quella fiscale
                object taxcode = ritProf["taxcode"];
                string filtertax = QHC.CmpEq("taxcode", taxcode);
                if (DS.tax.Select(filtertax).Length == 0) continue;
                DataRow Tax = DS.tax.Select(filtertax)[0];
                if (Tax["taxkind"].ToString() == taxkind.ToString()) res.Add(ritProf);
            }
            return res;
        }

        decimal getFrazione(object num, object den) {
            decimal myNum = CfgFn.GetNoNullDecimal(num);
            decimal myDen = CfgFn.GetNoNullDecimal(den);
            if (myDen == 0) return 1;
            return myNum/myDen;
        }

        /// <summary>
        /// Calcola il costo totale a partire dalle spese, dalle aliquote ritenute/contributi e dal campo feegross
        /// </summary>
        private void ricalcolaCostoTotale() {
            if (Meta.IsEmpty) return;

            if (!Meta.GetFormData(true)) {
                show(this, "Errori nei dati inseriti");
                return;
            }


            List<DataRow> drRitFis = GetTaxRow(1); //fiscale
            List<DataRow> drRitPrev = GetTaxRow(3); //previdenziale

            /*A*/
            decimal importoPrestazione = getValuta(DS.profservice.Rows[0]["feegross"]);
            /*B%*/
            decimal totSpeseNoP = ricalcolaTotSpeseNoDed("P");
            /*P*/
            decimal imponibilePrevidenziale = importoPrestazione + totSpeseNoP;

            /*N%*/
            decimal percB = getAliquota(DS.profservice.Rows[0]["pensioncontributionrate"]);
            /*C%*/
            decimal percC = getAliquota(DS.profservice.Rows[0]["socialsecurityrate"]);
            /*N*/
            decimal valoreB = CfgFn.RoundValuta(imponibilePrevidenziale*percB);
            /*C*/
            decimal valoreC = CfgFn.RoundValuta((valoreB + imponibilePrevidenziale)*percC);
            /*V*/
            decimal totSpeseNoIVA = ricalcolaTotSpeseNoDed("I");
            /*D*/
            decimal imponibileIVA = importoPrestazione + valoreB + valoreC + totSpeseNoIVA;
            /*E*/
            decimal importoIVA = CfgFn.RoundValuta(imponibileIVA*aliquota);
            /*Z*/
            decimal totSpeseNoF = ricalcolaTotSpeseNoDed("F");
            /*F*/
            decimal imponibileFiscale100 = importoPrestazione + valoreB + totSpeseNoF;



            decimal imponibileFiscale = imponibileFiscale100;
            decimal percRitFiscale = 0;

            foreach (DataRow ritFis in drRitFis) {
                decimal quota = getFrazione(ritFis["taxablenumerator"], ritFis["taxabledenominator"])*
                                getFrazione(ritFis["employnumerator"], ritFis["employdenominator"]);
                decimal num = CfgFn.GetNoNullDecimal(ritFis["taxablenumerator"]);
                decimal den = CfgFn.GetNoNullDecimal(ritFis["taxabledenominator"]);
                setLabelImponibileFiscale(num, den);
                if (den != 0) {
                    imponibileFiscale = imponibileFiscale100*quota;
                }
                /*G%*/
                percRitFiscale = getAliquota(ritFis["employrate"]);
            }
            if (drRitFis.Count == 0) {
                setLabelImponibileFiscale(1, 1);
            }

            decimal totImportoRitPrev = 0; //Calcola ritenute previdenziali
            decimal totImportoContrPrev = 0; //Calcola contributi previdenziali
            foreach (DataRow ritPrev in drRitPrev) {
                decimal imponibileDiPartenza = 0;
                DataRow QUOTA = calcolaCampiQuota(ritPrev["taxcode"]);
                decimal frazioneImponibile = (QUOTA != null)
                    ? rapporto(QUOTA["taxablenumerator"], QUOTA["taxabledenominator"])
                    : 0;
                decimal imponibileDaTassare = CfgFn.RoundValuta(imponibilePrevidenziale*frazioneImponibile);

                decimal imponibileTotale = (imponibileDiPartenza + imponibileDaTassare);

                DateTime dataDaConsiderare = (DateTime) Conn.GetSys("datacontabile");


                DataTable scaglioni = CalcolaRitenute.scaglioni(Conn, ritPrev["taxcode"], dataDaConsiderare, 0,
                    imponibileTotale);
                if (scaglioni.Rows.Count == 0) continue;

                DataRow scagl = scaglioni.Rows[0];
                decimal imponibile = CfgFn.GetNoNullDecimal(scagl["maxamount"]) -
                                     CfgFn.GetNoNullDecimal(scagl["minamount"]);

                decimal frazioneDipendente = getFrazione(ritPrev["employnumerator"], ritPrev["employdenominator"]);
                decimal frazioneAmministrazione = getFrazione(ritPrev["adminnumerator"], ritPrev["admindenominator"]);
                decimal imponibileprev_dip = imponibile*frazioneDipendente;
                decimal imponibileprev_amm = imponibile*frazioneAmministrazione;

                decimal percRitDip = getAliquota(ritPrev["employrate"]);
                decimal percRitAmm = getAliquota(ritPrev["adminrate"]);
                decimal importoRitPrev = CfgFn.RoundValuta(imponibileprev_dip*frazioneDipendente*percRitDip);
                decimal importoContrPrev = CfgFn.RoundValuta(imponibileprev_amm*frazioneAmministrazione*percRitAmm);
                decimal deduzioni = ricalcolaTotSpese("P", true);


                ritPrev["taxablegross"] = imponibilePrevidenziale + deduzioni;
                ritPrev["taxablenet"] = imponibileprev_dip;
                ritPrev["employtax"] = importoRitPrev;
                ritPrev["employtaxgross"] = importoRitPrev;
                ritPrev["admintax"] = importoContrPrev;
                ritPrev["deduction"] = deduzioni;
                totImportoContrPrev += importoContrPrev;
                totImportoRitPrev += importoRitPrev;
                txtContributi.Text = totImportoContrPrev.ToString("c");
                txtAltreRit.Text = totImportoRitPrev.ToString("c");
            }

            if (drRitPrev.Count == 0) {
                txtContributi.Text = "";
                txtAltreRit.Text = "";
            }



            /*G*/
            decimal importoRitFiscale = CfgFn.RoundValuta(imponibileFiscale*percRitFiscale);
            /*H*/
            decimal totSpese = ricalcolaTotaleSpese();
            /*I*/
            decimal costoTotale = importoPrestazione + valoreB + valoreC + importoIVA + totSpese + totImportoContrPrev;
            /*J*/
            decimal importoNetto = costoTotale - (importoRitFiscale + totImportoRitPrev + totImportoContrPrev);
            decimal importoBeneficiario = costoTotale - totImportoContrPrev;

            DataRow Curr = DS.profservice.Rows[0];
//			DataRow CurrRit = DS.profservicetax.Rows[0];

            // Campi da modificare della tabella contrattoprof
            Curr["ivaamount"] = importoIVA;
            Curr["totalcost"] = CfgFn.RoundValuta(costoTotale);
            Curr["ivarate"] = aliquota;
            Curr["totalgross"] = importoBeneficiario;




            // Campi da modificare della tabella contrattoprofritenuta
            if (drRitFis.Count == 1) {
                DataRow rFis = drRitFis[0];
                decimal dedFiscali = ricalcolaTotSpese("F", true);
                rFis["taxablegross"] = imponibileFiscale100 + dedFiscali;
                rFis["taxablenet"] = imponibileFiscale;
                rFis["employtax"] = importoRitFiscale;
                rFis["employtaxgross"] = importoRitFiscale;
            }

            txtSpeseDed.Text = TotSpeseDeducibili().ToString("c");
            txtTotaleSpese.Text = totSpese.ToString("c");
            txtImportoAddebContrPrev.Text = valoreB.ToString("c");
            txtImportoContrCassaPrev.Text = valoreC.ToString("c");
            txtImponibileIVA.Text = imponibileIVA.ToString("c");
            Curr["!imponibileiva"] = CfgFn.GetNoNullDecimal(imponibileIVA); // Sarà usato per l'ANAC
            txtImportoNetto.Text = importoNetto.ToString("c");
            txtImponibilePrevidenza.Text = imponibilePrevidenziale.ToString("c");
            txtIva.Text = aliquota.ToString("p");

            Meta.FreshForm();
        }

        private decimal TotSpeseDeducibili() {
            if (Meta.IsEmpty) return 0;
            decimal totaleSpese = 0;
            DataRow[] R = DS.profservicerefund.Select();
            if (R.Length == 0) return 0;
            for (int i = 0; i < R.Length; i++) {
                string fTipoSpesa = QHC.CmpEq("idlinkedrefund", R[i]["idlinkedrefund"]);
                DataRow[] rSpesa = DS.profrefund.Select(fTipoSpesa);
                if (rSpesa.Length == 0) continue;
                if ((rSpesa[0]["flagivadeduction"].ToString().ToUpper() != "S") ||
                    (rSpesa[0]["flagfiscaldeduction"].ToString().ToUpper() != "S") ||
                    (rSpesa[0]["flagsecuritydeduction"].ToString().ToUpper() != "S")) continue;
                totaleSpese += CfgFn.GetNoNullDecimal(R[i]["amount"]);

            }
            return totaleSpese;
        }


        //decimal GetAliquotaPrev() {
        //    DataRow drRitPrev = GetTaxRow(3); //previdenziale
        //    if (drRitPrev == null) return 0;

        //    decimal quotadip = getFrazione(drRitPrev["taxablenumerator"], drRitPrev["taxabledenominator"]) *
        // getFrazione(drRitPrev["employnumerator"], drRitPrev["employdenominator"]);
        //    decimal quotaamm = getFrazione(drRitPrev["taxablenumerator"], drRitPrev["taxabledenominator"]) *
        //             getFrazione(drRitPrev["adminnumerator"], drRitPrev["admindenominator"]);
        //    decimal percRitDip = getAliquota(drRitPrev["employrate"]);
        //    decimal percRitAmm = getAliquota(drRitPrev["adminrate"]);
        //    return percRitDip * quotadip + percRitAmm * quotaamm;
        //}

        void SetImportoPrestazione(decimal amount, decimal importodesiderato) {
            DataRow Curr = DS.profservice.Rows[0];
            Curr["feegross"] = amount;
            txtCompensoLordo.Text = amount.ToString("c");
            ricalcolaCostoTotale();

            decimal costoTotaleCalcolato = getValuta(Curr["totalcost"]);

            if (costoTotaleCalcolato != importodesiderato) {
                show(this, "Per gli arrotondamenti effettuati, il costo totale calcolato ("
                                      + costoTotaleCalcolato.ToString()
                                      + ") differisce leggermente da quello desiderato ("
                                      + importodesiderato.ToString()
                                      + ")");
            }

        }

        /// <summary>
        /// Ricalcola l'importo prestazione a partire dall'importo totale
        /// </summary>
        private void ricalcolaImportoPrestazione() {
            if (Meta.IsEmpty) return;

            if (!Meta.GetFormData(true)) {
                show(this, "Errori nei dati inseriti");
                return;
            }
            DataRow Curr = DS.profservice.Rows[0];
            decimal costoTotaleDesiderato = CfgFn.GetNoNullDecimal(Curr["totalcost"]);


            decimal x0 = 0;
            decimal x1 = CfgFn.RoundValuta(costoTotaleDesiderato);
            if (x0 == x1) {
                SetImportoPrestazione(x0, costoTotaleDesiderato);
                return;
            }

            decimal y0 = CfgFn.RoundValuta(CalcolaCostoTotale(x0));
            decimal y1 = CfgFn.RoundValuta(CalcolaCostoTotale(x1));
            decimal xfound = x0; //Soluzione se trovata o se si verifica una condizione di uscita
            while (true) {
                if (y0 == costoTotaleDesiderato || y0 == y1) break;
                if (y1 == costoTotaleDesiderato) {
                    xfound = x1;
                    break;
                }
                decimal x2 = x0 + (x1 - x0)*(costoTotaleDesiderato - y0)/(y1 - y0);
                if (x2 <= x0) x2 = x0;
                if (x2 >= x1) x2 = x1;

                if (x2 == x0 || x2 == x1) {
                    xfound = x2; //non dovrebbe mai passare di qua in teoria ma tant'è...
                    break;
                }
                decimal y2 = CfgFn.RoundValuta(CalcolaCostoTotale(x2));
                if (y2 > costoTotaleDesiderato) {
                    x1 = x2; //Si mette nel settore inferiore diminuendo l'estremo superiore x1
                    y1 = y2;
                    continue;
                }
                if (y2 < costoTotaleDesiderato) {
                    x0 = x2; //Si mette nel sett. superiore aumentando l'estremo inferiore x0
                    y0 = y2;
                    continue;
                }
                xfound = x2;

                break;
            }
            SetImportoPrestazione(xfound, costoTotaleDesiderato);



        }

        decimal CalcolaCostoTotale(decimal importoPrestazione) {


            /*A*/
            //decimal importoPrestazione = getValuta(DS.profservice.Rows[0]["feegross"]);
            /*B%*/
            decimal totSpeseNoP = ricalcolaTotSpeseNoDed("P");
            /*P*/
            decimal imponibilePrevidenziale = importoPrestazione + totSpeseNoP;

            /*N%*/
            decimal percB = getAliquota(DS.profservice.Rows[0]["pensioncontributionrate"]);
            /*C%*/
            decimal percC = getAliquota(DS.profservice.Rows[0]["socialsecurityrate"]);
            /*N*/
            decimal valoreB = CfgFn.RoundValuta(imponibilePrevidenziale*percB);
            /*C*/
            decimal valoreC = CfgFn.RoundValuta((valoreB + imponibilePrevidenziale)*percC);
            /*V*/
            decimal totSpeseNoIVA = ricalcolaTotSpeseNoDed("I");
            /*D*/
            decimal imponibileIVA = importoPrestazione + valoreB + valoreC + totSpeseNoIVA;
            /*E*/
            decimal importoIVA = CfgFn.RoundValuta(imponibileIVA*aliquota);
            /*Z*/
            decimal totSpeseNoF = ricalcolaTotSpeseNoDed("F");
            /*F*/
            decimal imponibileFiscale100 = importoPrestazione + valoreB + totSpeseNoF;

            List<DataRow> drRitFis = GetTaxRow(1); //fiscale


            decimal imponibileFiscale = imponibileFiscale100;
            decimal percRitFiscale = 0;
            foreach (DataRow ritFis in drRitFis) {
//dovrebbe trovare una sola riga             
                decimal quota = getFrazione(ritFis["taxablenumerator"], ritFis["taxabledenominator"])*
                                getFrazione(ritFis["employnumerator"], ritFis["employdenominator"]);
                decimal num = CfgFn.GetNoNullDecimal(ritFis["taxablenumerator"]);
                decimal den = CfgFn.GetNoNullDecimal(ritFis["taxabledenominator"]);
                //setLabelImponibileFiscale(num, den);
                if (den != 0) {
                    imponibileFiscale = imponibileFiscale100*quota;
                }
                /*G%*/
                percRitFiscale = getAliquota(ritFis["employrate"]);
            }


            List<DataRow> drRitPrev = GetTaxRow(3); //previdenziale
            decimal importoRitPrev = 0; //Calcola ritenute previdenziali
            decimal importoContrPrev = 0; //Calcola contributi previdenziali

            foreach (DataRow ritPrev in drRitPrev) {
                //Imponibile di Partenza: questo imponibile è utile quando si effettua il calcolo delle ritenute
                //previdenziali, in quanto a differenza degli altri tipi di ritenuta, la determinazione dello scaglione
                //di pertinenza dell'aliquota viene calcolato in modo incrementale, in pratica si resta sullo stesso scaglione
                //fin quando nello stesso anno non si raggiunge l'importo massimo dello scaglione di riferimento.
                decimal imponibileDiPartenza = 0;
                object taxCode = ritPrev["taxcode"];

                DataRow QUOTA = calcolaCampiQuota(taxCode);
                decimal frazioneImponibile = (QUOTA != null)
                    ? rapporto(QUOTA["taxablenumerator"], QUOTA["taxabledenominator"])
                    : 0;
                decimal imponibileDaTassare = CfgFn.RoundValuta(imponibilePrevidenziale*frazioneImponibile);

                decimal imponibileTotale = (imponibileDiPartenza + imponibileDaTassare);

                DateTime dataDaConsiderare = (DateTime) Conn.GetSys("datacontabile");

                DataTable scaglioniDellaRitenuta = CalcolaRitenute.scaglioni(Conn, taxCode, dataDaConsiderare,
                    0, imponibileTotale);


                //int numeroScaglione = 1;
                foreach (DataRow scagl in scaglioniDellaRitenuta.Rows) {
                    //DataRow Riten = ritenuteDaPagare.NewRow();
                    //Riten["ycon"] = RCasualContract["ycon"];
                    //Riten["ncon"] = RCasualContract["ncon"];
                    //Riten["taxcode"] = ritenutaPrestazioneRow["taxcode"];
                    //Riten["nbracket"] = numeroScaglione;
                    //Riten["taxable"] = CfgFn.GetNoNullDecimal(scagl["maxamount"]) - CfgFn.GetNoNullDecimal(scagl["minamount"]);
                    decimal taxable = CfgFn.GetNoNullDecimal(scagl["maxamount"]) -
                                      CfgFn.GetNoNullDecimal(scagl["minamount"]);
                    //Riten["adminrate"] = scagl["adminrate"];
                    //Riten["employrate"] = scagl["employrate"];
                    decimal frazioneDipendente = getFrazione(scagl["employnumerator"], scagl["employdenominator"]);
                    decimal frazioneAmministrazione = getFrazione(scagl["adminnumerator"], scagl["admindenominator"]);
                    importoRitPrev +=
                        CfgFn.RoundValuta(taxable*CfgFn.GetNoNullDecimal(scagl["employrate"])*frazioneDipendente);
                    importoContrPrev +=
                        CfgFn.RoundValuta(taxable*CfgFn.GetNoNullDecimal(scagl["adminrate"])*frazioneAmministrazione);

                    //Riten["employtax"] = CfgFn.RoundValuta((decimal)Riten["taxable"] * CfgFn.GetNoNullDecimal(Riten["employrate"]) * frazioneDipendente);
                    //Riten["admintax"] = CfgFn.RoundValuta((decimal)Riten["taxable"] * CfgFn.GetNoNullDecimal(Riten["adminrate"]) * frazioneAmministrazione);
                    //Riten["taxablegross"] = lordoAlBeneficiario;
                    //Riten["taxablenet"] = Riten["taxable"];
                    //Riten["employnumerator"] = scagl["employnumerator"];
                    //Riten["employdenominator"] = scagl["employdenominator"];
                    //Riten["adminnumerator"] = scagl["adminnumerator"];
                    //Riten["admindenominator"] = scagl["admindenominator"];

                    //ritenuteDaPagare.Rows.Add(Riten);
                    //numeroScaglione++;
                }


            }




            /*G*/
            decimal importoRitFiscale = CfgFn.RoundValuta(imponibileFiscale*percRitFiscale);
            /*H*/
            decimal totSpese = ricalcolaTotaleSpese();
            /*I*/
            decimal costoTotale = importoPrestazione + valoreB + valoreC + importoIVA + totSpese + importoContrPrev;
            /*J*/
            decimal importoNetto = costoTotale - (importoRitFiscale + importoRitPrev + importoContrPrev);
            decimal importoBeneficiario = costoTotale - (importoRitPrev + importoContrPrev);

            //DataRow Curr = DS.profservice.Rows[0];
            ////			DataRow CurrRit = DS.profservicetax.Rows[0];

            //// Campi da modificare della tabella contrattoprof
            //Curr["ivaamount"] = importoIVA;
            //Curr["totalcost"] = costoTotale;
            //Curr["ivarate"] = aliquota;
            //Curr["totalgross"] = importoBeneficiario;


            imponibileFiscale100 += ricalcolaTotSpeseDed("F");

            // Campi da modificare della tabella contrattoprofritenuta
            //if (drRitFis != null) {
            //    decimal dedFiscali = ricalcolaTotSpese("F", true);
            //    drRitFis["taxablegross"] = imponibileFiscale100 + dedFiscali;
            //    drRitFis["taxablenet"] = imponibileFiscale;
            //    drRitFis["employtax"] = importoRitFiscale;
            //    drRitFis["employtaxgross"] = importoRitFiscale;
            //}



            //txtImportoAddebContrPrev.Text = valoreB.ToString("c");
            //txtImportoContrCassaPrev.Text = valoreC.ToString("c");
            //txtImponibileIVA.Text = imponibileIVA.ToString("c");
            //txtImportoNetto.Text = importoNetto.ToString("c");
            //txtImponibilePrevidenza.Text = imponibilePrevidenziale.ToString("c");
            //txtIva.Text = aliquota.ToString("p");

            return costoTotale;
        }

        /// <summary>
        /// Metodo che calcola il rapporto tra numeratore e denominatore
        /// </summary>
        /// <param name="quotanum">Numeratore</param>
        /// <param name="quotaden">Denominatore</param>
        /// <returns>Rapporto tra numeratore e denominatore</returns>
        public decimal rapporto(object quotanum, object quotaden) {
            decimal num = CfgFn.GetNoNullDecimal(quotanum);
            decimal den = CfgFn.GetNoNullDecimal(quotaden);
            if (den == 0) {
                return 1;
            }
            return num/den;
        }

        /// <summary>
        /// In base alla data contabile (del dataset), e codiceritenuta seleziona l'aliquota amm/dip
        /// </summary>
        /// <param name="codiceRitenuta"></param>
        /// <returns>Una riga da taxratebracketview, null se non trova aliquote</returns>
        private DataRow calcolaCampiQuota(object codiceRitenuta) {
            object datadaconsiderare = (DateTime) Conn.GetSys("datacontabile");
            object maxIdTaxRateStart = Conn.DO_READ_VALUE("taxratestart",
                QHS.AppAnd(QHS.CmpLe("start", datadaconsiderare),
                    QHS.CmpEq("taxcode", codiceRitenuta)), "max(idtaxratestart)");

            string query = "select top 1 adminrate, employrate, taxablenumerator, taxabledenominator,"
                           + " adminnumerator, admindenominator,"
                           + " employnumerator, employdenominator"
                           + " from taxratebracketview where " +
                           QHS.AppAnd(QHS.CmpEq("idtaxratestart", maxIdTaxRateStart),
                               QHS.CmpEq("taxcode", codiceRitenuta))
                           + " order by nbracket asc";

            DataTable quotanumdenDT = Conn.SQLRunner(query);
            if ((quotanumdenDT == null) || (quotanumdenDT.Rows.Count == 0)) return null;
            return quotanumdenDT.Rows[0];
        }


        private void txtDataInizio_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
        }

        private void txtDataFine_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaDurataGiorni();
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

        private void txtDataContabile_Leave(object sender, System.EventArgs e) {
            if (inChiusura) return;
            if (!(Meta.InsertMode || Meta.EditMode)) return;
        }

        private void btnGeneraEpExp_Click(object sender, System.EventArgs e) {
        }

        private void btnVisualizzaEpExp_Click(object sender, System.EventArgs e) {
        }



        private void btnscollegainvoice_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            show(this, "Si desidera Scollegare la fattura dal Contratto?");
            DataRow Curr = DS.profservice.Rows[0];

            string filterinvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind"]),
                                               QHS.CmpEq("yinv", Curr["yinv"]),
                                               QHS.CmpEq("ninv", Curr["ninv"]));

            Curr["idinvkind"] = DBNull.Value;
            cmbInvoice.SelectedIndex = 0;
            Curr["yinv"] = DBNull.Value;
            txtEsercDocumento.Text = DS.profservice.Rows[0]["yinv"].ToString();
            Curr["ninv"] = DBNull.Value;
            txtNumDocumento.Text = DS.profservice.Rows[0]["ninv"].ToString();

            foreach (DataRow RDet in DS.invoicedetail.Rows) {
                RDet["ycon"] = DBNull.Value; 
                RDet["ncon"] = DBNull.Value;  
                RDet["idepexp"] = DBNull.Value;  
            }


        }

        void VisualizzaEtichetteAP() {
            if (DS.profservice.Rows.Count > 0 && (DS.profservice.Rows[0].RowState == DataRowState.Unchanged)) {
                labAPnongenerato.Visible = true;
                labAPgenerato.Visible = true;
                btnVisualizzaAP.Visible = true;
                btnGeneraAP.Visible = true;
                btnCollegaAP.Visible = true;
            }
            else {
                if (Meta.InsertMode || DS.profservice.Rows.Count == 0) // || DS.entrysetup.Rows.Count==0)
                {
                    labAPnongenerato.Visible = false;
                    labAPgenerato.Visible = false;
                    btnVisualizzaAP.Visible = false;
                    btnGeneraAP.Visible = false;
                    btnCollegaAP.Visible = false;
                    return;
                }
            }

            string idrelated = GetIdForDocument(DS.profservice.Rows[0]);
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

        static string ComposeObjects(object[] o) {
            if (o == null) return null;
            if (o.Length == 0) return null;
            string res = "";
            foreach (object oo in o) {
                if (res != "") res += "§";
                res += oo.ToString();
            }
            return res;
        }

        public static string GetIdForDocument(DataRow R) {
            if (R == null) return null;
            DataRowVersion toConsider = DataRowVersion.Current;
            if (R.RowState == DataRowState.Deleted) toConsider = DataRowVersion.Original;
            string table = R.Table.TableName.ToLower();
            return ComposeObjects(
                new object[] {
                    "profservice",
                    R["ycon", toConsider],
                    R["ncon", toConsider]
                });

        }

        private void btnGeneraAP_Click(object sender, System.EventArgs e) {
            GeneraScrittureAP();
        }

        void GeneraScrittureAP() {
            if (DS.profservice.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.profservice.Rows[0];
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

        public void EditRelatedServiceRegistry(MetaData Meta, string idrelated) {
            if (idrelated == null) return;
            MetaData ToMeta = Meta.Dispatcher.Get("serviceregistry");
            if (ToMeta == null) return;
            string checkfilter = QHS.CmpEq("idrelated", idrelated);
            ToMeta.ContextFilter = checkfilter;
            Form F = null;
            if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
            bool result = ToMeta.Edit(F, "default", false);
            string listtype = ToMeta.DefaultListType;
            DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
            if (R != null) ToMeta.SelectRow(R, listtype);
        }

        void EditServiceRegistry() {
            if (DS.profservice.Rows.Count == 0) return;
            AP_fun AP = new AP_fun(Meta.Dispatcher);
            AP.EditRelatedServiceRegistry(Meta, DS.profservice.Rows[0]);
        }

        private void btnVisualizzaAP_Click(object sender, System.EventArgs e) {
            EditServiceRegistry();
        }

        private void setLabelImponibileFiscale(decimal n, decimal d) {
            int num = CfgFn.GetNoNullInt32(n*100);
            int den = CfgFn.GetNoNullInt32(d*100);
            if ((den == 0) || (num == den)) {
                labelImponibileFiscale.Text = "F = A + N + Z";
                return;
            }
            int x = num;
            int y = den;
            while (x != 0) {
                int h = y%x;
                y = x;
                x = h;
            }
            num /= y;
            den /= y;
            if (num == 1) {
                labelImponibileFiscale.Text = "F = (A + N + Z) / " + den;
                return;
            }
            if (den == 1) {
                labelImponibileFiscale.Text = "F = " + num + " (A + N + Z)";
                return;
            }
            labelImponibileFiscale.Text = "F = " + num + "/" + den + " * (A + N + Z)";
        }

        private void SubEntity_txtNumImponibile_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDecTextBox(txtNumImponibile, "x.x.n");
            ricalcolaCostoTotale();
        }

        private void SubEntity_txtDenImponibile_Leave(object sender, EventArgs e) {
            if (inChiusura) return;
            HelpForm.ExtLeaveDecTextBox(txtDenImponibile, "x.x.n");
            ricalcolaCostoTotale();
        }

        private bool EsisteIndirizzoAP() {
            DataRow curr = DS.profservice.Rows[0];
            String codeaddress = "07_SW_ANP";
            object idaddresskind = Meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            if (curr["start"] == DBNull.Value) return false;
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
            VisualizzaEtichetteAP();
        }

        private void btnCollegaAP_Click(object sender, EventArgs e) {
            if (DS.profservice.Rows.Count == 0) return; //It was an insert-cancel
            DataRow Curr = DS.profservice.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            AP_fun AP = new AP_fun(Meta.Dispatcher);
            if (!AP.attivo) return;
            AP.LinkExistingDocument(Meta, Curr, Curr["idreg"]);
        }

        private void btnLottiPartecipati_Click(object sender, EventArgs e) {
            if (DS.profservice.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridAVCP);
            if (RigaSelezionata == null) return;
            frmLottiPartecipati F = new frmLottiPartecipati(DS.profservicecig, DS.profserviceavcpdetail, RigaSelezionata);
            F.ShowDialog(this);
        }

        private DataRow GetGridSelectedRows(DataGrid G) {
            DataSet DSV = (DataSet) G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null) return null;

            DataRow R = DV.Row;
            return R;
        }

        private void btnLottiAppaltati_Click(object sender, EventArgs e) {
            if (DS.profservice.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridAVCP);
            if (RigaSelezionata == null) return;
            frmLottiAppaltati F = new frmLottiAppaltati(DS.profservicecig, RigaSelezionata);
            F.ShowDialog(this);
        }

        private void btnPartecipantiAlLotto_Click(object sender, EventArgs e) {
            if (DS.profservice.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridLotti);
            if (RigaSelezionata == null) return;
            FrmPartecipantiLotto F = new FrmPartecipantiLotto(RigaSelezionata, DS.profserviceavcp,
                DS.profserviceavcpdetail);
            F.ShowDialog(this);
        }

        private void btnOrdiniNoLotti_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand(
                "maindosearch.lista.((select count(*) from profservicecig MC where MC.ycon = profserviceview.ycon and MC.ncon= profserviceview.ncon)=0)");
        }

        private void btnOrdiniNoPartecipanti_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand(
                "maindosearch.lista.((select count(*) from profserviceavcp MC where MC.ycon = profserviceview.ycon and MC.ncon= profserviceview.ncon)=0)");
        }

        private void btnPartecipantiNonAssociati_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand("maindosearch.lista.((select count(*) from profserviceavcp MC " +
                               " left outer join profserviceavcpdetail MD on MD.ycon = MC.ycon and MD.ncon = MC.ncon and MD.idavcp = MC.idavcp " +
                               " where MC.ycon = profserviceview.ycon and MC.ncon = profserviceview.ncon) >0)"

                );
        }

        //abilitaDisabilitaCCdedicato() negli altri compensi
        private void abilitaDisabilitaCertificatiRichiesti(DataRow rService) {
            if ((rService == null) && (DS.profservice.Rows.Count == 0)) {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = true;
				chkDurc.Enabled = true;
				chkCasellarioGiud.Enabled = true;
				chkCasellarioAmm.Enabled = true;
				chkOttempLegge.Enabled = true;
				chkRegolaritaFisc.Enabled = true;
				chkVerificaAnac.Enabled = true;
                return;
            }
            if ((rService == null) && (DS.profservice.Rows.Count > 0)) {
                DataRow Curr = DS.profservice.Rows[0];
                DataRow[] Service = DS.service.Select(QHS.CmpEq("idser", Curr["idser"]));
                if (Service.Length > 0) {
                    rService = Service[0];
                }
            }
            if (rService != null) {
                int flag_ccddicato = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 1;
                if (flag_ccddicato != 0) {
                    //CC dedicato necessario
                    chkCCdedicato.Checked = true;
                    chkCCdedicato.Enabled = true;
                }
                else {
                    chkCCdedicato.Checked = false;
                    chkCCdedicato.Enabled = false;
                }
                int flag_visura = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 2;
                if (flag_visura != 0) {
                    //flag Visura Camerale necessario
                    chkVisura.Checked = true;
                    chkVisura.Enabled = true;
                }
                else {
                    chkVisura.Checked = false;
                    chkVisura.Enabled = false;
                }
				int flag_durc = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 4;
                if (flag_durc != 0) {
                    //flag DURC necessario
					chkDurc.Checked = true;
                    chkDurc.Enabled = true;
                }
                else {
                    chkDurc.Checked = false;
                    chkDurc.Enabled = false;
                }
				int flag_casellariog = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 8;
                if (flag_casellariog != 0) {                    
					chkCasellarioGiud.Checked = true;
                    chkCasellarioGiud.Enabled = true;
                }
                else {
                    chkCasellarioGiud.Checked = true;
                    chkCasellarioGiud.Enabled = true;
                }
				int flag_casellatrioa = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 16;
                if (flag_casellatrioa != 0) {                    
					chkCasellarioAmm.Checked = true;
                    chkCasellarioAmm.Enabled = true;
                }
                else {
                    chkCasellarioAmm.Checked = true;
                    chkCasellarioAmm.Enabled = true;
                }
				int flag_ottemplegge = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 32;
                if (flag_ottemplegge != 0) {
					chkOttempLegge.Checked = true;
                    chkOttempLegge.Enabled = true;
                }
                else {
                    chkOttempLegge.Checked = false;
                    chkOttempLegge.Enabled = false;
                }
				int flag_regfiscale = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 64;
                if (flag_regfiscale != 0) {
					chkRegolaritaFisc.Checked = true;
                    chkRegolaritaFisc.Enabled = true;
                }
                else {
                    chkRegolaritaFisc.Checked = false;
                    chkRegolaritaFisc.Enabled = false;
                }
				int flag_verificaanac = CfgFn.GetNoNullInt32(rService["requested_doc"]) & 128;
                if (flag_verificaanac != 0) {
					chkVerificaAnac.Checked = true;
                    chkVerificaAnac.Enabled = true;
                }
                else {
                    chkVerificaAnac.Checked = false;
                    chkVerificaAnac.Enabled = false;
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

        private void btnAggiungiAggiudicatario_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            CreaPartecipanteInAutomatico(true);
            Meta.FreshForm();
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

    }
}
