
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;//funzioni_configurazione
using System.Data;
using ep_functions;
using System.Collections.Generic;

namespace invoicedetail_single //dettdocumentoivasingle//
{
    /// <summary>
    /// Summary description for frmdettdocumentoivasingle.
    /// </summary>
    public class Frm_invoicedetail_single : System.Windows.Forms.Form {
        public dsmeta DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPercIndeduc;
        private System.Windows.Forms.TextBox txtImpDeducEUR;
        private System.Windows.Forms.TextBox txtImpostaEUR;
        private System.Windows.Forms.TextBox txtImponibileEUR;
        private System.Windows.Forms.TextBox txtAppunti;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private MetaData Meta;
        private decimal tassocambio;
        private decimal aliquota = 0;
        private System.Windows.Forms.ComboBox cmbTipoIVA;
        private System.Windows.Forms.Button btnTipo;
        private System.Windows.Forms.TextBox txtQuantitaConfezioni;
        private System.Windows.Forms.Label lblidpackage;
        private System.Windows.Forms.TextBox txtSconto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblImportoUnitario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.TabPage tabAnalitico;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        public TextBox txtDenom3;
        public TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        public TextBox txtDenom2;
        public TextBox txtCodice2;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        public TextBox txtDenom1;
        public TextBox txtCodice1;
        private System.Windows.Forms.GroupBox grpRiga;
        private System.Windows.Forms.TextBox txtNumriga;
        private System.Windows.Forms.TextBox txtNumordine;
        private System.Windows.Forms.TextBox txtEsercordine;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.TextBox txtImponibileValuta;
        private decimal percindeduc = 0;
        private System.Windows.Forms.Button btnScollegaRiga;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox gboxCompetenza;
        private System.Windows.Forms.GroupBox grpValoreUnitInValuta;
        private System.Windows.Forms.GroupBox grpValoreTotaleInEuro;
        private System.Windows.Forms.TabPage tabEP;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCodiceCausale;
        private System.Windows.Forms.TextBox txtDescrizioneCausale;
        private System.Windows.Forms.GroupBox grpRigaContratto;
        private System.Windows.Forms.Button btnScollegaRigaContratto;
        private System.Windows.Forms.TextBox txtNumRigaContratto;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.TextBox txtEsercContratto;
        IDataAccess Conn;
        DataRow rPadre;
        private System.Windows.Forms.Label lblPercIndeduc;
        private System.Windows.Forms.Label lblIvaIndedEUR;
        private System.Windows.Forms.GroupBox gboxImponibile;
        private System.Windows.Forms.TextBox txtNumImponibile;
        private System.Windows.Forms.TextBox txtEsercizioImponibile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gboxIVA;
        private System.Windows.Forms.TextBox txtNumeroIva;
        private System.Windows.Forms.TextBox txtEsercizioIva;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtstart;
        private System.Windows.Forms.TextBox txtstop;
        private System.Windows.Forms.GroupBox grpCausale;
        private GroupBox grpInvMain;
        private TextBox txtNinv_Main;
        private Label label19;
        private TextBox txtYinv_Main;
        private Label label20;
        private GroupBox grpLiquidazioneIva;
        private Label label22;
        private TextBox textBox1;
        private TabPage tabLiquidazioneIva;
        private GroupBox groupBox1;
        private Label label21;
        private TextBox txtPaymentCompetency;
        private TabPage tabIntrastat;
        private TextBox txtMassaKg;
        private Label label24;
        private GroupBox gboxIntrastatCode;
        private ComboBox cmbmeasure;
        private Label labUnitaMisura;
        private TextBox txtIntrastatDescription;
        private TextBox txtIntrastatCode;
        private Button btnIntrastatCode;
        private TabPage tabPage3;
        private GroupBox gboxVA3;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private GroupBox grpServizi;
        private RadioButton rdbServizi;
        private RadioButton rdbBeni;
        private GroupBox grpBeni;
        private Label label23;
        private ComboBox cmbModErogazione;
        private Label label25;
        private TextBox txtServizi;
        private TextBox txtCodServizi;
        private Button btnservizi;
        private TextBox txtQuantita;
        private Label lblidunit;
        private GroupBox gboxListino;
        private TextBox txtCoeffConversione;
        private Label label26;
        private ComboBox cmbUnitaMisuraAcquisto;
        private Label lblIcmbdpackage;
        private Label label27;
        private ComboBox cmbUnitaMisuraCS;
        private CheckBox chkListDescription;
        private Button btnListino;
        private TextBox txtListino;
        private TextBox txtDescrizioneListino;
        private TabPage tabComunicazioni;
        private GroupBox grpComunicazioni;
        private RadioButton rdbNonSpec;
        private RadioButton radioButton2;
        private RadioButton radioButton7;
        private CheckBox chkexception12;
        private TabPage tabintra12;
        private RadioButton rdbServiziintra12;
        private RadioButton rdbBeniintra12;
        private CheckBox chkmove12;
        private GroupBox gBoxupbIVA;
        private Button buttonupbIVA;
        private TextBox textBox4;
        private Label label7;
        private Label label10;
        private ComboBox cmbInvKindMain;
        private TabPage tabAppunti;
        public TextBox txtUPBiva;
        public TextBox txtUPB;
        private TabPage tabSospesometro;
        private GroupBox groupBox2;
        private Label label11;
        private RadioButton rdbNonEscludere;
        private RadioButton rdbEOperation;
        private RadioButton rdbDoperation;
        private RadioButton rdbCIntracomunitarie;
        private RadioButton rdbBEsportazioni;
        private RadioButton rdbAImportazione;
        private GroupBox groupBox3;
        private RadioButton rdbVarIniziale;
        private RadioButton rdbVarStorno;
        private RadioButton rdbVarAssestamento;
        private RadioButton rdbVarNormale;
        private RadioButton rdbVarRipartizione;
        private RadioButton radioButton8;
        private CheckBox chkResiduoOrdine;
        private TabPage tabFatturaElettronica;
        private ComboBox cmbTipocessioneprestazione;
        private Label label28;
        private TextBox textBox2;
        private TextBox textBox5;
        private TextBox txtRiferimentoNormativo;
        private Label label29;
        private GroupBox grpCupCig;
        private TextBox txtCIG;
        private Label lblcig;
        private Label label87;
        private TextBox txtCUP;
        private TabPage tabPCC;
        private Button btnCasuale;
        private TextBox txtCausale;
        private Label label30;
        private ComboBox cmbStatodelDebito;
        public GroupBox grpRipartizioneCosti;
        public Button button3;
        public TextBox textBox3;
        public TextBox txtCodiceRipartizione;
        private GroupBox grpNaturadiSpesa;
        private RadioButton rdbContoCapitale;
        private RadioButton rdbSpesaCorrente;
        private CheckBox chkRounding;
        private GroupBox grpBoxImpegniBudget;
        private Button btnLinkEpExp;
        private Button btnRemoveEpExp;
        private TextBox txtNumIxBudget;
        private TextBox txtEsercIxBudget;
        private Label label34;
        private Label label33;
        private DataGrid dtgLiquidazioneIVA;
        private Button btnCollegaRigaContratto;
        private Button btnCollegaRiga;
        private TextBox textBox7;
        private TextBox textBox6;
        private GroupBox grpBoxAccertamentiBudget;
        private Label label14;
        private Label label17;
        private Button btnLinkEpAcc;
        private Button btnRemoveEpAcc;
        private TextBox txtNumAxBudget;
        private TextBox txtEsercAxBudget;
        private CheckBox chkBollaDoganale;
        private CheckBox chkSpeseAnticipateSpedizioniere;
        private GroupBox gboxCausaleBilancioEntrata;
        private TextBox TxtDescrCausaleDeb;
        private TextBox txtCodiceCausaleEntrata;
        private Button button6;
        private Label label37;
        private TextBox txtCodiceBollettinoUnivoco;
        private CheckBox checkBox1;
        private GroupBox gboxProfessionale;
        private TextBox txtNCon;
        private Label label38;
        private TextBox txtYCon;
        private Label label39;
        private Button btnScollegaContrProf;
        private Button btnCollegaContrProf;
        private TextBox textBox8;
        private Label label41;
        private TextBox textBox9;
        private Label label40;
        private GroupBox gboxDatiVendita;
        private GroupBox grpBoxSiopeEP;
        private TextBox txtDescSiope;
        private TextBox txtCodSiope;
        private Button btnSiope;
        private GroupBox gboxPreimpegniDiBudget;
        private Label label31;
        private Label label32;
        private Button btnCollegaPreimpegno;
        private Button btnScollegaPreimpegno;
        private TextBox txtPre_nepexp;
        private TextBox txtPre_yepexp;
        private TextBox txtPrezzoUnitarioListino;
        private Label label35;
        object AV;

        public Frm_invoicedetail_single() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.invoicedetail.Columns["exception12"], true);
            HelpForm.SetDenyNull(DS.invoicedetail.Columns["move12"], true);
            HelpForm.SetDenyNull(DS.invoicedetail.Columns["leasing"], true);
            HelpForm.SetDenyNull(DS.invoicedetail.Columns["resetresidualmandate"], true);
            HelpForm.SetDenyNull(DS.invoicedetail.Columns["flagbit"], true);
        }

        QueryHelper QHS;
        CQueryHelper QHC;

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

        bool intrastat;
        bool comunicazioni;
        bool mostraINTRA12;
        object flagva3;
        DataTable tExpSetup;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_invoicedetail_single));
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtPercIndeduc = new System.Windows.Forms.TextBox();
			this.lblPercIndeduc = new System.Windows.Forms.Label();
			this.grpValoreTotaleInEuro = new System.Windows.Forms.GroupBox();
			this.txtImpDeducEUR = new System.Windows.Forms.TextBox();
			this.lblIvaIndedEUR = new System.Windows.Forms.Label();
			this.txtImpostaEUR = new System.Windows.Forms.TextBox();
			this.txtImponibileEUR = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtAppunti = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnTipo = new System.Windows.Forms.Button();
			this.txtQuantitaConfezioni = new System.Windows.Forms.TextBox();
			this.lblidpackage = new System.Windows.Forms.Label();
			this.grpValoreUnitInValuta = new System.Windows.Forms.GroupBox();
			this.txtImponibileValuta = new System.Windows.Forms.TextBox();
			this.txtSconto = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtImponibile = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.lblImportoUnitario = new System.Windows.Forms.Label();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
			this.DS = new invoicedetail_single.dsmeta();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gboxProfessionale = new System.Windows.Forms.GroupBox();
			this.btnScollegaContrProf = new System.Windows.Forms.Button();
			this.btnCollegaContrProf = new System.Windows.Forms.Button();
			this.txtNCon = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.txtYCon = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.gboxCausaleBilancioEntrata = new System.Windows.Forms.GroupBox();
			this.TxtDescrCausaleDeb = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleEntrata = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.label37 = new System.Windows.Forms.Label();
			this.txtCodiceBollettinoUnivoco = new System.Windows.Forms.TextBox();
			this.grpCupCig = new System.Windows.Forms.GroupBox();
			this.txtCIG = new System.Windows.Forms.TextBox();
			this.lblcig = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.txtCUP = new System.Windows.Forms.TextBox();
			this.chkResiduoOrdine = new System.Windows.Forms.CheckBox();
			this.gBoxupbIVA = new System.Windows.Forms.GroupBox();
			this.txtUPBiva = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonupbIVA = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.gboxImponibile = new System.Windows.Forms.GroupBox();
			this.txtNumImponibile = new System.Windows.Forms.TextBox();
			this.txtEsercizioImponibile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.gboxIVA = new System.Windows.Forms.GroupBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtNumeroIva = new System.Windows.Forms.TextBox();
			this.txtEsercizioIva = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.grpRigaContratto = new System.Windows.Forms.GroupBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.btnCollegaRigaContratto = new System.Windows.Forms.Button();
			this.btnScollegaRigaContratto = new System.Windows.Forms.Button();
			this.txtNumRigaContratto = new System.Windows.Forms.TextBox();
			this.txtNumContratto = new System.Windows.Forms.TextBox();
			this.txtEsercContratto = new System.Windows.Forms.TextBox();
			this.grpRiga = new System.Windows.Forms.GroupBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.btnCollegaRiga = new System.Windows.Forms.Button();
			this.btnScollegaRiga = new System.Windows.Forms.Button();
			this.txtNumriga = new System.Windows.Forms.TextBox();
			this.txtNumordine = new System.Windows.Forms.TextBox();
			this.txtEsercordine = new System.Windows.Forms.TextBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.tabAnalitico = new System.Windows.Forms.TabPage();
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
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
			this.gboxPreimpegniDiBudget = new System.Windows.Forms.GroupBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.btnCollegaPreimpegno = new System.Windows.Forms.Button();
			this.btnScollegaPreimpegno = new System.Windows.Forms.Button();
			this.txtPre_nepexp = new System.Windows.Forms.TextBox();
			this.txtPre_yepexp = new System.Windows.Forms.TextBox();
			this.grpBoxSiopeEP = new System.Windows.Forms.GroupBox();
			this.btnSiope = new System.Windows.Forms.Button();
			this.txtDescSiope = new System.Windows.Forms.TextBox();
			this.txtCodSiope = new System.Windows.Forms.TextBox();
			this.grpBoxAccertamentiBudget = new System.Windows.Forms.GroupBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.btnLinkEpAcc = new System.Windows.Forms.Button();
			this.btnRemoveEpAcc = new System.Windows.Forms.Button();
			this.txtNumAxBudget = new System.Windows.Forms.TextBox();
			this.txtEsercAxBudget = new System.Windows.Forms.TextBox();
			this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
			this.label34 = new System.Windows.Forms.Label();
			this.label33 = new System.Windows.Forms.Label();
			this.btnLinkEpExp = new System.Windows.Forms.Button();
			this.btnRemoveEpExp = new System.Windows.Forms.Button();
			this.txtNumIxBudget = new System.Windows.Forms.TextBox();
			this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
			this.grpCausale = new System.Windows.Forms.GroupBox();
			this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.gboxCompetenza = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtstop = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtstart = new System.Windows.Forms.TextBox();
			this.tabLiquidazioneIva = new System.Windows.Forms.TabPage();
			this.dtgLiquidazioneIVA = new System.Windows.Forms.DataGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtPaymentCompetency = new System.Windows.Forms.TextBox();
			this.tabIntrastat = new System.Windows.Forms.TabPage();
			this.grpBeni = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtMassaKg = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.gboxIntrastatCode = new System.Windows.Forms.GroupBox();
			this.cmbmeasure = new System.Windows.Forms.ComboBox();
			this.labUnitaMisura = new System.Windows.Forms.Label();
			this.txtIntrastatDescription = new System.Windows.Forms.TextBox();
			this.txtIntrastatCode = new System.Windows.Forms.TextBox();
			this.btnIntrastatCode = new System.Windows.Forms.Button();
			this.rdbServizi = new System.Windows.Forms.RadioButton();
			this.rdbBeni = new System.Windows.Forms.RadioButton();
			this.grpServizi = new System.Windows.Forms.GroupBox();
			this.txtServizi = new System.Windows.Forms.TextBox();
			this.txtCodServizi = new System.Windows.Forms.TextBox();
			this.btnservizi = new System.Windows.Forms.Button();
			this.cmbModErogazione = new System.Windows.Forms.ComboBox();
			this.label25 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.gboxVA3 = new System.Windows.Forms.GroupBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.tabComunicazioni = new System.Windows.Forms.TabPage();
			this.grpComunicazioni = new System.Windows.Forms.GroupBox();
			this.rdbNonSpec = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.tabintra12 = new System.Windows.Forms.TabPage();
			this.chkmove12 = new System.Windows.Forms.CheckBox();
			this.rdbServiziintra12 = new System.Windows.Forms.RadioButton();
			this.rdbBeniintra12 = new System.Windows.Forms.RadioButton();
			this.chkexception12 = new System.Windows.Forms.CheckBox();
			this.tabAppunti = new System.Windows.Forms.TabPage();
			this.tabSospesometro = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.rdbVarIniziale = new System.Windows.Forms.RadioButton();
			this.rdbVarStorno = new System.Windows.Forms.RadioButton();
			this.rdbVarAssestamento = new System.Windows.Forms.RadioButton();
			this.rdbVarNormale = new System.Windows.Forms.RadioButton();
			this.rdbVarRipartizione = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rdbNonEscludere = new System.Windows.Forms.RadioButton();
			this.rdbEOperation = new System.Windows.Forms.RadioButton();
			this.rdbDoperation = new System.Windows.Forms.RadioButton();
			this.rdbCIntracomunitarie = new System.Windows.Forms.RadioButton();
			this.rdbBEsportazioni = new System.Windows.Forms.RadioButton();
			this.rdbAImportazione = new System.Windows.Forms.RadioButton();
			this.label11 = new System.Windows.Forms.Label();
			this.tabFatturaElettronica = new System.Windows.Forms.TabPage();
			this.gboxDatiVendita = new System.Windows.Forms.GroupBox();
			this.label40 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.chkRounding = new System.Windows.Forms.CheckBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtRiferimentoNormativo = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.cmbTipocessioneprestazione = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.tabPCC = new System.Windows.Forms.TabPage();
			this.grpNaturadiSpesa = new System.Windows.Forms.GroupBox();
			this.rdbContoCapitale = new System.Windows.Forms.RadioButton();
			this.rdbSpesaCorrente = new System.Windows.Forms.RadioButton();
			this.btnCasuale = new System.Windows.Forms.Button();
			this.txtCausale = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.cmbStatodelDebito = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.grpInvMain = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cmbInvKindMain = new System.Windows.Forms.ComboBox();
			this.txtNinv_Main = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtYinv_Main = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.grpLiquidazioneIva = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtQuantita = new System.Windows.Forms.TextBox();
			this.lblidunit = new System.Windows.Forms.Label();
			this.gboxListino = new System.Windows.Forms.GroupBox();
			this.txtPrezzoUnitarioListino = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.txtCoeffConversione = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.cmbUnitaMisuraAcquisto = new System.Windows.Forms.ComboBox();
			this.lblIcmbdpackage = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.cmbUnitaMisuraCS = new System.Windows.Forms.ComboBox();
			this.chkListDescription = new System.Windows.Forms.CheckBox();
			this.btnListino = new System.Windows.Forms.Button();
			this.txtListino = new System.Windows.Forms.TextBox();
			this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
			this.chkBollaDoganale = new System.Windows.Forms.CheckBox();
			this.chkSpeseAnticipateSpedizioniere = new System.Windows.Forms.CheckBox();
			this.grpValoreTotaleInEuro.SuspendLayout();
			this.grpValoreUnitInValuta.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxProfessionale.SuspendLayout();
			this.gboxCausaleBilancioEntrata.SuspendLayout();
			this.grpCupCig.SuspendLayout();
			this.gBoxupbIVA.SuspendLayout();
			this.gboxImponibile.SuspendLayout();
			this.gboxIVA.SuspendLayout();
			this.grpRigaContratto.SuspendLayout();
			this.grpRiga.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.tabAnalitico.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabEP.SuspendLayout();
			this.gboxPreimpegniDiBudget.SuspendLayout();
			this.grpBoxSiopeEP.SuspendLayout();
			this.grpBoxAccertamentiBudget.SuspendLayout();
			this.grpBoxImpegniBudget.SuspendLayout();
			this.grpCausale.SuspendLayout();
			this.gboxCompetenza.SuspendLayout();
			this.tabLiquidazioneIva.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgLiquidazioneIVA)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tabIntrastat.SuspendLayout();
			this.grpBeni.SuspendLayout();
			this.gboxIntrastatCode.SuspendLayout();
			this.grpServizi.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.gboxVA3.SuspendLayout();
			this.tabComunicazioni.SuspendLayout();
			this.grpComunicazioni.SuspendLayout();
			this.tabintra12.SuspendLayout();
			this.tabAppunti.SuspendLayout();
			this.tabSospesometro.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabFatturaElettronica.SuspendLayout();
			this.gboxDatiVendita.SuspendLayout();
			this.tabPCC.SuspendLayout();
			this.grpNaturadiSpesa.SuspendLayout();
			this.grpInvMain.SuspendLayout();
			this.grpLiquidazioneIva.SuspendLayout();
			this.gboxListino.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 154);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Descrizione";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(72, 154);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescrizione.Size = new System.Drawing.Size(369, 54);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "invoicedetail.detaildescription";
			// 
			// txtPercIndeduc
			// 
			this.txtPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercIndeduc.Location = new System.Drawing.Point(541, 24);
			this.txtPercIndeduc.Name = "txtPercIndeduc";
			this.txtPercIndeduc.ReadOnly = true;
			this.txtPercIndeduc.Size = new System.Drawing.Size(88, 20);
			this.txtPercIndeduc.TabIndex = 3;
			this.txtPercIndeduc.TabStop = false;
			this.txtPercIndeduc.Tag = "ivakind.unabatabilitypercentage.fixed.4..%.100";
			this.txtPercIndeduc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPercIndeduc
			// 
			this.lblPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPercIndeduc.Location = new System.Drawing.Point(541, 8);
			this.lblPercIndeduc.Name = "lblPercIndeduc";
			this.lblPercIndeduc.Size = new System.Drawing.Size(88, 16);
			this.lblPercIndeduc.TabIndex = 39;
			this.lblPercIndeduc.Text = "% Indetraibilità";
			this.lblPercIndeduc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpValoreTotaleInEuro
			// 
			this.grpValoreTotaleInEuro.Controls.Add(this.txtImpDeducEUR);
			this.grpValoreTotaleInEuro.Controls.Add(this.lblIvaIndedEUR);
			this.grpValoreTotaleInEuro.Controls.Add(this.txtImpostaEUR);
			this.grpValoreTotaleInEuro.Controls.Add(this.txtImponibileEUR);
			this.grpValoreTotaleInEuro.Controls.Add(this.label4);
			this.grpValoreTotaleInEuro.Controls.Add(this.label6);
			this.grpValoreTotaleInEuro.Location = new System.Drawing.Point(657, 209);
			this.grpValoreTotaleInEuro.Name = "grpValoreTotaleInEuro";
			this.grpValoreTotaleInEuro.Size = new System.Drawing.Size(304, 53);
			this.grpValoreTotaleInEuro.TabIndex = 6;
			this.grpValoreTotaleInEuro.TabStop = false;
			this.grpValoreTotaleInEuro.Text = "Valore totale in EUR";
			// 
			// txtImpDeducEUR
			// 
			this.txtImpDeducEUR.Location = new System.Drawing.Point(200, 29);
			this.txtImpDeducEUR.Name = "txtImpDeducEUR";
			this.txtImpDeducEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImpDeducEUR.TabIndex = 10;
			this.txtImpDeducEUR.TabStop = false;
			this.txtImpDeducEUR.Tag = "invoicedetail.unabatable";
			this.txtImpDeducEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblIvaIndedEUR
			// 
			this.lblIvaIndedEUR.Location = new System.Drawing.Point(200, 13);
			this.lblIvaIndedEUR.Name = "lblIvaIndedEUR";
			this.lblIvaIndedEUR.Size = new System.Drawing.Size(88, 16);
			this.lblIvaIndedEUR.TabIndex = 46;
			this.lblIvaIndedEUR.Text = "Iva indetraibile";
			this.lblIvaIndedEUR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImpostaEUR
			// 
			this.txtImpostaEUR.Location = new System.Drawing.Point(104, 29);
			this.txtImpostaEUR.Name = "txtImpostaEUR";
			this.txtImpostaEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImpostaEUR.TabIndex = 9;
			this.txtImpostaEUR.TabStop = false;
			this.txtImpostaEUR.Tag = "invoicedetail.tax.fixed.2...1";
			this.txtImpostaEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtImpostaEUR.TextChanged += new System.EventHandler(this.txtIvaValuta_TextChanged);
			// 
			// txtImponibileEUR
			// 
			this.txtImponibileEUR.Location = new System.Drawing.Point(8, 29);
			this.txtImponibileEUR.Name = "txtImponibileEUR";
			this.txtImponibileEUR.ReadOnly = true;
			this.txtImponibileEUR.Size = new System.Drawing.Size(88, 20);
			this.txtImponibileEUR.TabIndex = 0;
			this.txtImponibileEUR.TabStop = false;
			this.txtImponibileEUR.Tag = "";
			this.txtImponibileEUR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(104, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 44;
			this.label4.Text = "Iva";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 16);
			this.label6.TabIndex = 43;
			this.label6.Text = "Imponibile";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAppunti
			// 
			this.txtAppunti.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtAppunti.Location = new System.Drawing.Point(0, 0);
			this.txtAppunti.Multiline = true;
			this.txtAppunti.Name = "txtAppunti";
			this.txtAppunti.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtAppunti.Size = new System.Drawing.Size(945, 338);
			this.txtAppunti.TabIndex = 22;
			this.txtAppunti.Tag = "invoicedetail.annotations";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(881, 636);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 9;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(801, 636);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// btnTipo
			// 
			this.btnTipo.Location = new System.Drawing.Point(8, 22);
			this.btnTipo.Name = "btnTipo";
			this.btnTipo.Size = new System.Drawing.Size(64, 23);
			this.btnTipo.TabIndex = 7;
			this.btnTipo.TabStop = false;
			this.btnTipo.Tag = "choose.ivakind.default";
			this.btnTipo.Text = "Tipo IVA";
			// 
			// txtQuantitaConfezioni
			// 
			this.txtQuantitaConfezioni.Location = new System.Drawing.Point(564, 154);
			this.txtQuantitaConfezioni.Name = "txtQuantitaConfezioni";
			this.txtQuantitaConfezioni.Size = new System.Drawing.Size(88, 20);
			this.txtQuantitaConfezioni.TabIndex = 4;
			this.txtQuantitaConfezioni.Tag = "invoicedetail.npackage.N";
			this.txtQuantitaConfezioni.Leave += new System.EventHandler(this.txtQuantitaConfezioni_Leave);
			// 
			// lblidpackage
			// 
			this.lblidpackage.Location = new System.Drawing.Point(480, 155);
			this.lblidpackage.Name = "lblidpackage";
			this.lblidpackage.Size = new System.Drawing.Size(78, 17);
			this.lblidpackage.TabIndex = 18;
			this.lblidpackage.Text = "Quantità:";
			this.lblidpackage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpValoreUnitInValuta
			// 
			this.grpValoreUnitInValuta.Controls.Add(this.txtImponibileValuta);
			this.grpValoreUnitInValuta.Controls.Add(this.txtSconto);
			this.grpValoreUnitInValuta.Controls.Add(this.label12);
			this.grpValoreUnitInValuta.Controls.Add(this.txtImponibile);
			this.grpValoreUnitInValuta.Controls.Add(this.label8);
			this.grpValoreUnitInValuta.Controls.Add(this.lblImportoUnitario);
			this.grpValoreUnitInValuta.Location = new System.Drawing.Point(658, 148);
			this.grpValoreUnitInValuta.Name = "grpValoreUnitInValuta";
			this.grpValoreUnitInValuta.Size = new System.Drawing.Size(304, 60);
			this.grpValoreUnitInValuta.TabIndex = 4;
			this.grpValoreUnitInValuta.TabStop = false;
			this.grpValoreUnitInValuta.Text = "Valore in valuta";
			// 
			// txtImponibileValuta
			// 
			this.txtImponibileValuta.Location = new System.Drawing.Point(200, 35);
			this.txtImponibileValuta.Name = "txtImponibileValuta";
			this.txtImponibileValuta.ReadOnly = true;
			this.txtImponibileValuta.Size = new System.Drawing.Size(88, 20);
			this.txtImponibileValuta.TabIndex = 37;
			this.txtImponibileValuta.TabStop = false;
			this.txtImponibileValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtSconto
			// 
			this.txtSconto.Location = new System.Drawing.Point(120, 35);
			this.txtSconto.Name = "txtSconto";
			this.txtSconto.Size = new System.Drawing.Size(72, 20);
			this.txtSconto.TabIndex = 8;
			this.txtSconto.Tag = "invoicedetail.discount.fixed.4..%.100";
			this.txtSconto.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(199, 18);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(103, 16);
			this.label12.TabIndex = 34;
			this.label12.Text = "Imponibile totale:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImponibile
			// 
			this.txtImponibile.Location = new System.Drawing.Point(8, 35);
			this.txtImponibile.Name = "txtImponibile";
			this.txtImponibile.Size = new System.Drawing.Size(104, 20);
			this.txtImponibile.TabIndex = 7;
			this.txtImponibile.Tag = "invoicedetail.taxable.fixed.5...1";
			this.txtImponibile.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(115, 18);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 36;
			this.label8.Text = "Sconto:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblImportoUnitario
			// 
			this.lblImportoUnitario.Location = new System.Drawing.Point(8, 14);
			this.lblImportoUnitario.Name = "lblImportoUnitario";
			this.lblImportoUnitario.Size = new System.Drawing.Size(104, 20);
			this.lblImportoUnitario.TabIndex = 34;
			this.lblImportoUnitario.Text = "Importo unitario:";
			this.lblImportoUnitario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIva
			// 
			this.txtIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIva.Location = new System.Drawing.Point(453, 24);
			this.txtIva.Name = "txtIva";
			this.txtIva.ReadOnly = true;
			this.txtIva.Size = new System.Drawing.Size(72, 20);
			this.txtIva.TabIndex = 2;
			this.txtIva.TabStop = false;
			this.txtIva.Tag = "ivakind.rate.fixed.4..%.100";
			this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label9.Location = new System.Drawing.Point(453, 8);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 16);
			this.label9.TabIndex = 35;
			this.label9.Text = "Aliquota";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.btnTipo);
			this.groupBox5.Controls.Add(this.cmbTipoIVA);
			this.groupBox5.Controls.Add(this.txtIva);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.lblPercIndeduc);
			this.groupBox5.Controls.Add(this.txtPercIndeduc);
			this.groupBox5.Location = new System.Drawing.Point(7, 209);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(645, 50);
			this.groupBox5.TabIndex = 5;
			this.groupBox5.TabStop = false;
			// 
			// cmbTipoIVA
			// 
			this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoIVA.DataSource = this.DS.ivakind;
			this.cmbTipoIVA.DisplayMember = "description";
			this.cmbTipoIVA.Location = new System.Drawing.Point(80, 22);
			this.cmbTipoIVA.Name = "cmbTipoIVA";
			this.cmbTipoIVA.Size = new System.Drawing.Size(365, 21);
			this.cmbTipoIVA.TabIndex = 6;
			this.cmbTipoIVA.Tag = "invoicedetail.idivakind";
			this.cmbTipoIVA.ValueMember = "idivakind";
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
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabAnalitico);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabLiquidazioneIva);
			this.tabControl1.Controls.Add(this.tabIntrastat);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabComunicazioni);
			this.tabControl1.Controls.Add(this.tabintra12);
			this.tabControl1.Controls.Add(this.tabAppunti);
			this.tabControl1.Controls.Add(this.tabSospesometro);
			this.tabControl1.Controls.Add(this.tabFatturaElettronica);
			this.tabControl1.Controls.Add(this.tabPCC);
			this.tabControl1.Location = new System.Drawing.Point(10, 265);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(953, 364);
			this.tabControl1.TabIndex = 7;
			this.tabControl1.TabStop = false;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxProfessionale);
			this.tabPage1.Controls.Add(this.gboxCausaleBilancioEntrata);
			this.tabPage1.Controls.Add(this.label37);
			this.tabPage1.Controls.Add(this.txtCodiceBollettinoUnivoco);
			this.tabPage1.Controls.Add(this.grpCupCig);
			this.tabPage1.Controls.Add(this.chkResiduoOrdine);
			this.tabPage1.Controls.Add(this.gBoxupbIVA);
			this.tabPage1.Controls.Add(this.gboxImponibile);
			this.tabPage1.Controls.Add(this.gboxIVA);
			this.tabPage1.Controls.Add(this.grpRigaContratto);
			this.tabPage1.Controls.Add(this.grpRiga);
			this.tabPage1.Controls.Add(this.gboxUPB);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(945, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Finanziario";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// gboxProfessionale
			// 
			this.gboxProfessionale.Controls.Add(this.btnScollegaContrProf);
			this.gboxProfessionale.Controls.Add(this.btnCollegaContrProf);
			this.gboxProfessionale.Controls.Add(this.txtNCon);
			this.gboxProfessionale.Controls.Add(this.label38);
			this.gboxProfessionale.Controls.Add(this.txtYCon);
			this.gboxProfessionale.Controls.Add(this.label39);
			this.gboxProfessionale.Location = new System.Drawing.Point(557, 226);
			this.gboxProfessionale.Name = "gboxProfessionale";
			this.gboxProfessionale.Size = new System.Drawing.Size(384, 97);
			this.gboxProfessionale.TabIndex = 77;
			this.gboxProfessionale.TabStop = false;
			this.gboxProfessionale.Text = "Contratto professionale collegato";
			// 
			// btnScollegaContrProf
			// 
			this.btnScollegaContrProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnScollegaContrProf.Location = new System.Drawing.Point(6, 47);
			this.btnScollegaContrProf.Name = "btnScollegaContrProf";
			this.btnScollegaContrProf.Size = new System.Drawing.Size(184, 24);
			this.btnScollegaContrProf.TabIndex = 15;
			this.btnScollegaContrProf.TabStop = false;
			this.btnScollegaContrProf.Tag = "";
			this.btnScollegaContrProf.Text = "Scollega da contratto professionale";
			this.btnScollegaContrProf.Click += new System.EventHandler(this.btnScollegaContrProf_Click);
			// 
			// btnCollegaContrProf
			// 
			this.btnCollegaContrProf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCollegaContrProf.Location = new System.Drawing.Point(6, 15);
			this.btnCollegaContrProf.Name = "btnCollegaContrProf";
			this.btnCollegaContrProf.Size = new System.Drawing.Size(184, 24);
			this.btnCollegaContrProf.TabIndex = 14;
			this.btnCollegaContrProf.TabStop = false;
			this.btnCollegaContrProf.Tag = "";
			this.btnCollegaContrProf.Text = "Collega a contratto professionale";
			this.btnCollegaContrProf.Click += new System.EventHandler(this.btnCollegaContrProf_Click);
			// 
			// txtNCon
			// 
			this.txtNCon.Location = new System.Drawing.Point(315, 19);
			this.txtNCon.Name = "txtNCon";
			this.txtNCon.ReadOnly = true;
			this.txtNCon.Size = new System.Drawing.Size(60, 20);
			this.txtNCon.TabIndex = 3;
			this.txtNCon.Tag = "invoicedetail.ncon";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(281, 20);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(31, 16);
			this.label38.TabIndex = 2;
			this.label38.Text = "Num.";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtYCon
			// 
			this.txtYCon.Location = new System.Drawing.Point(226, 19);
			this.txtYCon.Name = "txtYCon";
			this.txtYCon.ReadOnly = true;
			this.txtYCon.Size = new System.Drawing.Size(51, 20);
			this.txtYCon.TabIndex = 1;
			this.txtYCon.Tag = "invoicedetail.ycon.year";
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(193, 22);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(37, 16);
			this.label39.TabIndex = 0;
			this.label39.Text = "Eserc.";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxCausaleBilancioEntrata
			// 
			this.gboxCausaleBilancioEntrata.Controls.Add(this.TxtDescrCausaleDeb);
			this.gboxCausaleBilancioEntrata.Controls.Add(this.txtCodiceCausaleEntrata);
			this.gboxCausaleBilancioEntrata.Controls.Add(this.button6);
			this.gboxCausaleBilancioEntrata.Location = new System.Drawing.Point(248, 225);
			this.gboxCausaleBilancioEntrata.Name = "gboxCausaleBilancioEntrata";
			this.gboxCausaleBilancioEntrata.Size = new System.Drawing.Size(303, 104);
			this.gboxCausaleBilancioEntrata.TabIndex = 76;
			this.gboxCausaleBilancioEntrata.TabStop = false;
			this.gboxCausaleBilancioEntrata.Tag = "AutoManage.txtCodiceCausaleEntrata.tree.(active = \'S\')";
			this.gboxCausaleBilancioEntrata.Text = "Causale Bilancio di entrata per il flusso studenti";
			this.gboxCausaleBilancioEntrata.UseCompatibleTextRendering = true;
			this.gboxCausaleBilancioEntrata.Visible = false;
			// 
			// TxtDescrCausaleDeb
			// 
			this.TxtDescrCausaleDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtDescrCausaleDeb.Location = new System.Drawing.Point(120, 16);
			this.TxtDescrCausaleDeb.Multiline = true;
			this.TxtDescrCausaleDeb.Name = "TxtDescrCausaleDeb";
			this.TxtDescrCausaleDeb.ReadOnly = true;
			this.TxtDescrCausaleDeb.Size = new System.Drawing.Size(177, 56);
			this.TxtDescrCausaleDeb.TabIndex = 2;
			this.TxtDescrCausaleDeb.TabStop = false;
			this.TxtDescrCausaleDeb.Tag = "finmotive_income.title";
			// 
			// txtCodiceCausaleEntrata
			// 
			this.txtCodiceCausaleEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceCausaleEntrata.Location = new System.Drawing.Point(8, 78);
			this.txtCodiceCausaleEntrata.Name = "txtCodiceCausaleEntrata";
			this.txtCodiceCausaleEntrata.Size = new System.Drawing.Size(289, 20);
			this.txtCodiceCausaleEntrata.TabIndex = 10;
			this.txtCodiceCausaleEntrata.Tag = "finmotive_income.codemotive?x";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(10, 45);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 0;
			this.button6.TabStop = false;
			this.button6.Tag = "manage.finmotive_income.tree";
			this.button6.Text = "Causale";
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(10, 230);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(207, 19);
			this.label37.TabIndex = 75;
			this.label37.Tag = "";
			this.label37.Text = "Codice Bollettino Univoco (IUV)";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCodiceBollettinoUnivoco
			// 
			this.txtCodiceBollettinoUnivoco.Location = new System.Drawing.Point(10, 252);
			this.txtCodiceBollettinoUnivoco.Name = "txtCodiceBollettinoUnivoco";
			this.txtCodiceBollettinoUnivoco.Size = new System.Drawing.Size(234, 20);
			this.txtCodiceBollettinoUnivoco.TabIndex = 74;
			this.txtCodiceBollettinoUnivoco.Tag = "invoicedetail.iduniqueformcode";
			// 
			// grpCupCig
			// 
			this.grpCupCig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCupCig.Controls.Add(this.txtCIG);
			this.grpCupCig.Controls.Add(this.lblcig);
			this.grpCupCig.Controls.Add(this.label87);
			this.grpCupCig.Controls.Add(this.txtCUP);
			this.grpCupCig.Location = new System.Drawing.Point(763, 155);
			this.grpCupCig.Name = "grpCupCig";
			this.grpCupCig.Size = new System.Drawing.Size(173, 66);
			this.grpCupCig.TabIndex = 71;
			this.grpCupCig.TabStop = false;
			// 
			// txtCIG
			// 
			this.txtCIG.Location = new System.Drawing.Point(41, 16);
			this.txtCIG.Name = "txtCIG";
			this.txtCIG.Size = new System.Drawing.Size(127, 20);
			this.txtCIG.TabIndex = 72;
			this.txtCIG.Tag = "invoicedetail.cigcode";
			// 
			// lblcig
			// 
			this.lblcig.AutoSize = true;
			this.lblcig.Location = new System.Drawing.Point(11, 19);
			this.lblcig.Name = "lblcig";
			this.lblcig.Size = new System.Drawing.Size(25, 13);
			this.lblcig.TabIndex = 71;
			this.lblcig.Tag = "";
			this.lblcig.Text = "CIG";
			this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label87
			// 
			this.label87.AutoSize = true;
			this.label87.Location = new System.Drawing.Point(7, 41);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(29, 13);
			this.label87.TabIndex = 70;
			this.label87.Text = "CUP";
			this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCUP
			// 
			this.txtCUP.Location = new System.Drawing.Point(41, 38);
			this.txtCUP.Name = "txtCUP";
			this.txtCUP.Size = new System.Drawing.Size(127, 20);
			this.txtCUP.TabIndex = 69;
			this.txtCUP.Tag = "invoicedetail.cupcode";
			// 
			// chkResiduoOrdine
			// 
			this.chkResiduoOrdine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkResiduoOrdine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkResiduoOrdine.Location = new System.Drawing.Point(787, 132);
			this.chkResiduoOrdine.Name = "chkResiduoOrdine";
			this.chkResiduoOrdine.Size = new System.Drawing.Size(146, 21);
			this.chkResiduoOrdine.TabIndex = 21;
			this.chkResiduoOrdine.TabStop = false;
			this.chkResiduoOrdine.Tag = "invoicedetail.resetresidualmandate:S:N";
			this.chkResiduoOrdine.Text = "Azzera residuo ordine";
			this.chkResiduoOrdine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gBoxupbIVA
			// 
			this.gBoxupbIVA.Controls.Add(this.txtUPBiva);
			this.gBoxupbIVA.Controls.Add(this.label7);
			this.gBoxupbIVA.Controls.Add(this.buttonupbIVA);
			this.gBoxupbIVA.Controls.Add(this.textBox4);
			this.gBoxupbIVA.Location = new System.Drawing.Point(341, 5);
			this.gBoxupbIVA.Name = "gBoxupbIVA";
			this.gBoxupbIVA.Size = new System.Drawing.Size(315, 126);
			this.gBoxupbIVA.TabIndex = 2;
			this.gBoxupbIVA.TabStop = false;
			this.gBoxupbIVA.Tag = "AutoChoose.txtUPBiva.default.(active=\'S\')";
			this.gBoxupbIVA.Text = "UPB per la Contabilizzazione IVA";
			// 
			// txtUPBiva
			// 
			this.txtUPBiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPBiva.Location = new System.Drawing.Point(9, 100);
			this.txtUPBiva.Name = "txtUPBiva";
			this.txtUPBiva.Size = new System.Drawing.Size(300, 20);
			this.txtUPBiva.TabIndex = 7;
			this.txtUPBiva.Tag = "upb_iva.codeupb?x";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 50);
			this.label7.TabIndex = 6;
			this.label7.Text = "Utilizzare solo se diverso dal principale";
			// 
			// buttonupbIVA
			// 
			this.buttonupbIVA.BackColor = System.Drawing.SystemColors.Control;
			this.buttonupbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonupbIVA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonupbIVA.Location = new System.Drawing.Point(10, 77);
			this.buttonupbIVA.Name = "buttonupbIVA";
			this.buttonupbIVA.Size = new System.Drawing.Size(76, 20);
			this.buttonupbIVA.TabIndex = 5;
			this.buttonupbIVA.TabStop = false;
			this.buttonupbIVA.Tag = "manage.upb_iva.tree";
			this.buttonupbIVA.Text = "UPB";
			this.buttonupbIVA.UseVisualStyleBackColor = false;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(112, 16);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(198, 78);
			this.textBox4.TabIndex = 4;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "upb_iva.title";
			// 
			// gboxImponibile
			// 
			this.gboxImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxImponibile.Controls.Add(this.txtNumImponibile);
			this.gboxImponibile.Controls.Add(this.txtEsercizioImponibile);
			this.gboxImponibile.Controls.Add(this.label2);
			this.gboxImponibile.Controls.Add(this.label3);
			this.gboxImponibile.Location = new System.Drawing.Point(657, 70);
			this.gboxImponibile.Name = "gboxImponibile";
			this.gboxImponibile.Size = new System.Drawing.Size(279, 56);
			this.gboxImponibile.TabIndex = 5;
			this.gboxImponibile.TabStop = false;
			this.gboxImponibile.Text = "Contabilizzazione imponibile in finanziario";
			this.gboxImponibile.Visible = false;
			// 
			// txtNumImponibile
			// 
			this.txtNumImponibile.Location = new System.Drawing.Point(64, 32);
			this.txtNumImponibile.Name = "txtNumImponibile";
			this.txtNumImponibile.ReadOnly = true;
			this.txtNumImponibile.Size = new System.Drawing.Size(64, 20);
			this.txtNumImponibile.TabIndex = 3;
			this.txtNumImponibile.TabStop = false;
			this.txtNumImponibile.Tag = "";
			// 
			// txtEsercizioImponibile
			// 
			this.txtEsercizioImponibile.Location = new System.Drawing.Point(8, 32);
			this.txtEsercizioImponibile.Name = "txtEsercizioImponibile";
			this.txtEsercizioImponibile.ReadOnly = true;
			this.txtEsercizioImponibile.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizioImponibile.TabIndex = 2;
			this.txtEsercizioImponibile.TabStop = false;
			this.txtEsercizioImponibile.Tag = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Numero";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Eserc.";
			// 
			// gboxIVA
			// 
			this.gboxIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxIVA.Controls.Add(this.label18);
			this.gboxIVA.Controls.Add(this.txtNumeroIva);
			this.gboxIVA.Controls.Add(this.txtEsercizioIva);
			this.gboxIVA.Controls.Add(this.label5);
			this.gboxIVA.Location = new System.Drawing.Point(657, 5);
			this.gboxIVA.Name = "gboxIVA";
			this.gboxIVA.Size = new System.Drawing.Size(279, 56);
			this.gboxIVA.TabIndex = 6;
			this.gboxIVA.TabStop = false;
			this.gboxIVA.Text = "Contabilizzazione IVA in finanziario";
			this.gboxIVA.Visible = false;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(10, 15);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(40, 16);
			this.label18.TabIndex = 5;
			this.label18.Text = "Eserc.";
			// 
			// txtNumeroIva
			// 
			this.txtNumeroIva.Location = new System.Drawing.Point(66, 31);
			this.txtNumeroIva.Name = "txtNumeroIva";
			this.txtNumeroIva.ReadOnly = true;
			this.txtNumeroIva.Size = new System.Drawing.Size(64, 20);
			this.txtNumeroIva.TabIndex = 3;
			this.txtNumeroIva.TabStop = false;
			this.txtNumeroIva.Tag = "";
			// 
			// txtEsercizioIva
			// 
			this.txtEsercizioIva.Location = new System.Drawing.Point(10, 31);
			this.txtEsercizioIva.Name = "txtEsercizioIva";
			this.txtEsercizioIva.ReadOnly = true;
			this.txtEsercizioIva.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizioIva.TabIndex = 2;
			this.txtEsercizioIva.TabStop = false;
			this.txtEsercizioIva.Tag = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(66, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Numero";
			// 
			// grpRigaContratto
			// 
			this.grpRigaContratto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpRigaContratto.Controls.Add(this.textBox7);
			this.grpRigaContratto.Controls.Add(this.btnCollegaRigaContratto);
			this.grpRigaContratto.Controls.Add(this.btnScollegaRigaContratto);
			this.grpRigaContratto.Controls.Add(this.txtNumRigaContratto);
			this.grpRigaContratto.Controls.Add(this.txtNumContratto);
			this.grpRigaContratto.Controls.Add(this.txtEsercContratto);
			this.grpRigaContratto.Location = new System.Drawing.Point(8, 183);
			this.grpRigaContratto.Name = "grpRigaContratto";
			this.grpRigaContratto.Size = new System.Drawing.Size(728, 36);
			this.grpRigaContratto.TabIndex = 4;
			this.grpRigaContratto.TabStop = false;
			this.grpRigaContratto.Text = "Riga del contratto attivo:Tipo/Eserc./Num./Riga";
			this.grpRigaContratto.Visible = false;
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(3, 12);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(249, 20);
			this.textBox7.TabIndex = 15;
			this.textBox7.TabStop = false;
			this.textBox7.Tag = "estimatekind.description";
			// 
			// btnCollegaRigaContratto
			// 
			this.btnCollegaRigaContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCollegaRigaContratto.Location = new System.Drawing.Point(401, 9);
			this.btnCollegaRigaContratto.Name = "btnCollegaRigaContratto";
			this.btnCollegaRigaContratto.Size = new System.Drawing.Size(160, 24);
			this.btnCollegaRigaContratto.TabIndex = 14;
			this.btnCollegaRigaContratto.TabStop = false;
			this.btnCollegaRigaContratto.Tag = "";
			this.btnCollegaRigaContratto.Text = "Collega a riga contratto attivo";
			this.btnCollegaRigaContratto.Click += new System.EventHandler(this.btnCollegaRigaContratto_Click);
			// 
			// btnScollegaRigaContratto
			// 
			this.btnScollegaRigaContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnScollegaRigaContratto.Location = new System.Drawing.Point(567, 9);
			this.btnScollegaRigaContratto.Name = "btnScollegaRigaContratto";
			this.btnScollegaRigaContratto.Size = new System.Drawing.Size(155, 24);
			this.btnScollegaRigaContratto.TabIndex = 5;
			this.btnScollegaRigaContratto.TabStop = false;
			this.btnScollegaRigaContratto.Tag = "";
			this.btnScollegaRigaContratto.Text = "Scollega da riga contr. attivo";
			this.btnScollegaRigaContratto.Click += new System.EventHandler(this.btnScollegaRigaContratto_Click);
			// 
			// txtNumRigaContratto
			// 
			this.txtNumRigaContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumRigaContratto.Location = new System.Drawing.Point(346, 10);
			this.txtNumRigaContratto.Name = "txtNumRigaContratto";
			this.txtNumRigaContratto.ReadOnly = true;
			this.txtNumRigaContratto.Size = new System.Drawing.Size(32, 20);
			this.txtNumRigaContratto.TabIndex = 4;
			this.txtNumRigaContratto.TabStop = false;
			this.txtNumRigaContratto.Tag = "invoicedetail.estimrownum";
			// 
			// txtNumContratto
			// 
			this.txtNumContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumContratto.Location = new System.Drawing.Point(298, 10);
			this.txtNumContratto.Name = "txtNumContratto";
			this.txtNumContratto.ReadOnly = true;
			this.txtNumContratto.Size = new System.Drawing.Size(40, 20);
			this.txtNumContratto.TabIndex = 3;
			this.txtNumContratto.TabStop = false;
			this.txtNumContratto.Tag = "invoicedetail.nestim";
			// 
			// txtEsercContratto
			// 
			this.txtEsercContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercContratto.Location = new System.Drawing.Point(258, 10);
			this.txtEsercContratto.Name = "txtEsercContratto";
			this.txtEsercContratto.ReadOnly = true;
			this.txtEsercContratto.Size = new System.Drawing.Size(32, 20);
			this.txtEsercContratto.TabIndex = 2;
			this.txtEsercContratto.TabStop = false;
			this.txtEsercContratto.Tag = "invoicedetail.yestim.year";
			// 
			// grpRiga
			// 
			this.grpRiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpRiga.Controls.Add(this.textBox6);
			this.grpRiga.Controls.Add(this.btnCollegaRiga);
			this.grpRiga.Controls.Add(this.btnScollegaRiga);
			this.grpRiga.Controls.Add(this.txtNumriga);
			this.grpRiga.Controls.Add(this.txtNumordine);
			this.grpRiga.Controls.Add(this.txtEsercordine);
			this.grpRiga.Location = new System.Drawing.Point(8, 137);
			this.grpRiga.Name = "grpRiga";
			this.grpRiga.Size = new System.Drawing.Size(728, 40);
			this.grpRiga.TabIndex = 2;
			this.grpRiga.TabStop = false;
			this.grpRiga.Text = "Riga del buono d\'ordine: Tipo/Eserc./Num./Riga";
			this.grpRiga.Visible = false;
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(3, 14);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(249, 20);
			this.textBox6.TabIndex = 1;
			this.textBox6.TabStop = false;
			this.textBox6.Tag = "mandatekind.description";
			// 
			// btnCollegaRiga
			// 
			this.btnCollegaRiga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCollegaRiga.Location = new System.Drawing.Point(401, 12);
			this.btnCollegaRiga.Name = "btnCollegaRiga";
			this.btnCollegaRiga.Size = new System.Drawing.Size(160, 24);
			this.btnCollegaRiga.TabIndex = 13;
			this.btnCollegaRiga.TabStop = false;
			this.btnCollegaRiga.Tag = "";
			this.btnCollegaRiga.Text = "Collega a riga ordine";
			this.btnCollegaRiga.Click += new System.EventHandler(this.btnCollegaRiga_Click);
			// 
			// btnScollegaRiga
			// 
			this.btnScollegaRiga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnScollegaRiga.Location = new System.Drawing.Point(567, 12);
			this.btnScollegaRiga.Name = "btnScollegaRiga";
			this.btnScollegaRiga.Size = new System.Drawing.Size(155, 24);
			this.btnScollegaRiga.TabIndex = 5;
			this.btnScollegaRiga.TabStop = false;
			this.btnScollegaRiga.Tag = "";
			this.btnScollegaRiga.Text = "Scollega da riga ordine";
			this.btnScollegaRiga.Click += new System.EventHandler(this.btnScollegaRiga_Click);
			// 
			// txtNumriga
			// 
			this.txtNumriga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumriga.Location = new System.Drawing.Point(350, 14);
			this.txtNumriga.Name = "txtNumriga";
			this.txtNumriga.ReadOnly = true;
			this.txtNumriga.Size = new System.Drawing.Size(32, 20);
			this.txtNumriga.TabIndex = 4;
			this.txtNumriga.TabStop = false;
			this.txtNumriga.Tag = "invoicedetail.manrownum";
			// 
			// txtNumordine
			// 
			this.txtNumordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumordine.Location = new System.Drawing.Point(302, 14);
			this.txtNumordine.Name = "txtNumordine";
			this.txtNumordine.ReadOnly = true;
			this.txtNumordine.Size = new System.Drawing.Size(40, 20);
			this.txtNumordine.TabIndex = 3;
			this.txtNumordine.TabStop = false;
			this.txtNumordine.Tag = "invoicedetail.nman";
			// 
			// txtEsercordine
			// 
			this.txtEsercordine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEsercordine.Location = new System.Drawing.Point(262, 14);
			this.txtEsercordine.Name = "txtEsercordine";
			this.txtEsercordine.ReadOnly = true;
			this.txtEsercordine.Size = new System.Drawing.Size(32, 20);
			this.txtEsercordine.TabIndex = 2;
			this.txtEsercordine.TabStop = false;
			this.txtEsercordine.Tag = "invoicedetail.yman.year";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.button1);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Location = new System.Drawing.Point(8, 4);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(327, 127);
			this.gboxUPB.TabIndex = 1;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 101);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(313, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(6, 78);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 20);
			this.button1.TabIndex = 5;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.upb.tree";
			this.button1.Text = "UPB";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(119, 19);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(200, 79);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// tabAnalitico
			// 
			this.tabAnalitico.Controls.Add(this.grpRipartizioneCosti);
			this.tabAnalitico.Controls.Add(this.gboxclass3);
			this.tabAnalitico.Controls.Add(this.gboxclass2);
			this.tabAnalitico.Controls.Add(this.gboxclass1);
			this.tabAnalitico.Location = new System.Drawing.Point(4, 22);
			this.tabAnalitico.Name = "tabAnalitico";
			this.tabAnalitico.Size = new System.Drawing.Size(945, 338);
			this.tabAnalitico.TabIndex = 3;
			this.tabAnalitico.Text = "Analitico";
			this.tabAnalitico.UseVisualStyleBackColor = true;
			this.tabAnalitico.Visible = false;
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.button3);
			this.grpRipartizioneCosti.Controls.Add(this.textBox3);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(467, 114);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(463, 96);
			this.grpRipartizioneCosti.TabIndex = 5;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 34);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "choose.costpartition.default.(active=\'S\')";
			this.button3.Text = "Codice";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(128, 19);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(327, 41);
			this.textBox3.TabIndex = 3;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 70);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(449, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// gboxclass3
			// 
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(467, 8);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(463, 100);
			this.gboxclass3.TabIndex = 3;
			this.gboxclass3.TabStop = false;
			this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
			this.gboxclass3.Text = "Classificazione 3";
			// 
			// btnCodice3
			// 
			this.btnCodice3.Location = new System.Drawing.Point(8, 45);
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
			this.txtDenom3.Location = new System.Drawing.Point(128, 19);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(327, 49);
			this.txtDenom3.TabIndex = 3;
			this.txtDenom3.TabStop = false;
			this.txtDenom3.Tag = "sorting3.description";
			// 
			// txtCodice3
			// 
			this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice3.Location = new System.Drawing.Point(6, 74);
			this.txtCodice3.Name = "txtCodice3";
			this.txtCodice3.Size = new System.Drawing.Size(447, 20);
			this.txtCodice3.TabIndex = 4;
			this.txtCodice3.Tag = "sorting3.sortcode?x";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(3, 114);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(430, 96);
			this.gboxclass2.TabIndex = 2;
			this.gboxclass2.TabStop = false;
			this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
			this.gboxclass2.Text = "Classificazione 2";
			// 
			// btnCodice2
			// 
			this.btnCodice2.Location = new System.Drawing.Point(6, 41);
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
			this.txtDenom2.Location = new System.Drawing.Point(125, 19);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(294, 48);
			this.txtDenom2.TabIndex = 3;
			this.txtDenom2.TabStop = false;
			this.txtDenom2.Tag = "sorting2.description";
			// 
			// txtCodice2
			// 
			this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice2.Location = new System.Drawing.Point(6, 70);
			this.txtCodice2.Name = "txtCodice2";
			this.txtCodice2.Size = new System.Drawing.Size(413, 20);
			this.txtCodice2.TabIndex = 3;
			this.txtCodice2.Tag = "sorting2.sortcode?x";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(8, 8);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(430, 100);
			this.gboxclass1.TabIndex = 1;
			this.gboxclass1.TabStop = false;
			this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
			this.gboxclass1.Text = "Classificazione 1";
			// 
			// btnCodice1
			// 
			this.btnCodice1.Location = new System.Drawing.Point(11, 45);
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
			this.txtDenom1.Location = new System.Drawing.Point(124, 19);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(294, 49);
			this.txtDenom1.TabIndex = 3;
			this.txtDenom1.TabStop = false;
			this.txtDenom1.Tag = "sorting1.description";
			// 
			// txtCodice1
			// 
			this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice1.Location = new System.Drawing.Point(10, 74);
			this.txtCodice1.Name = "txtCodice1";
			this.txtCodice1.Size = new System.Drawing.Size(409, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?x";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.gboxPreimpegniDiBudget);
			this.tabEP.Controls.Add(this.grpBoxSiopeEP);
			this.tabEP.Controls.Add(this.grpBoxAccertamentiBudget);
			this.tabEP.Controls.Add(this.grpBoxImpegniBudget);
			this.tabEP.Controls.Add(this.grpCausale);
			this.tabEP.Controls.Add(this.gboxCompetenza);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(945, 338);
			this.tabEP.TabIndex = 4;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// gboxPreimpegniDiBudget
			// 
			this.gboxPreimpegniDiBudget.Controls.Add(this.label31);
			this.gboxPreimpegniDiBudget.Controls.Add(this.label32);
			this.gboxPreimpegniDiBudget.Controls.Add(this.btnCollegaPreimpegno);
			this.gboxPreimpegniDiBudget.Controls.Add(this.btnScollegaPreimpegno);
			this.gboxPreimpegniDiBudget.Controls.Add(this.txtPre_nepexp);
			this.gboxPreimpegniDiBudget.Controls.Add(this.txtPre_yepexp);
			this.gboxPreimpegniDiBudget.Location = new System.Drawing.Point(394, 162);
			this.gboxPreimpegniDiBudget.Name = "gboxPreimpegniDiBudget";
			this.gboxPreimpegniDiBudget.Size = new System.Drawing.Size(491, 55);
			this.gboxPreimpegniDiBudget.TabIndex = 51;
			this.gboxPreimpegniDiBudget.TabStop = false;
			this.gboxPreimpegniDiBudget.Text = "Preimpegno di Budget ";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(132, 24);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(44, 13);
			this.label31.TabIndex = 7;
			this.label31.Text = "Numero";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(6, 24);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(49, 13);
			this.label32.TabIndex = 6;
			this.label32.Text = "Esercizio";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnCollegaPreimpegno
			// 
			this.btnCollegaPreimpegno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCollegaPreimpegno.Location = new System.Drawing.Point(253, 19);
			this.btnCollegaPreimpegno.Name = "btnCollegaPreimpegno";
			this.btnCollegaPreimpegno.Size = new System.Drawing.Size(98, 23);
			this.btnCollegaPreimpegno.TabIndex = 5;
			this.btnCollegaPreimpegno.TabStop = false;
			this.btnCollegaPreimpegno.Text = "Collega";
			this.btnCollegaPreimpegno.Click += new System.EventHandler(this.btnCollegaPreimpegno_Click);
			// 
			// btnScollegaPreimpegno
			// 
			this.btnScollegaPreimpegno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnScollegaPreimpegno.Location = new System.Drawing.Point(368, 19);
			this.btnScollegaPreimpegno.Name = "btnScollegaPreimpegno";
			this.btnScollegaPreimpegno.Size = new System.Drawing.Size(117, 23);
			this.btnScollegaPreimpegno.TabIndex = 4;
			this.btnScollegaPreimpegno.TabStop = false;
			this.btnScollegaPreimpegno.Text = "Scollega";
			this.btnScollegaPreimpegno.Click += new System.EventHandler(this.btnScollegaPreimpegno_Click);
			// 
			// txtPre_nepexp
			// 
			this.txtPre_nepexp.Location = new System.Drawing.Point(183, 21);
			this.txtPre_nepexp.Name = "txtPre_nepexp";
			this.txtPre_nepexp.ReadOnly = true;
			this.txtPre_nepexp.Size = new System.Drawing.Size(64, 20);
			this.txtPre_nepexp.TabIndex = 3;
			this.txtPre_nepexp.TabStop = false;
			this.txtPre_nepexp.Tag = "epexp_pre.nepexp";
			// 
			// txtPre_yepexp
			// 
			this.txtPre_yepexp.Location = new System.Drawing.Point(75, 21);
			this.txtPre_yepexp.Name = "txtPre_yepexp";
			this.txtPre_yepexp.ReadOnly = true;
			this.txtPre_yepexp.Size = new System.Drawing.Size(40, 20);
			this.txtPre_yepexp.TabIndex = 2;
			this.txtPre_yepexp.TabStop = false;
			this.txtPre_yepexp.Tag = "epexp_pre.yepexp";
			// 
			// grpBoxSiopeEP
			// 
			this.grpBoxSiopeEP.Controls.Add(this.btnSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtDescSiope);
			this.grpBoxSiopeEP.Controls.Add(this.txtCodSiope);
			this.grpBoxSiopeEP.Location = new System.Drawing.Point(9, 179);
			this.grpBoxSiopeEP.Name = "grpBoxSiopeEP";
			this.grpBoxSiopeEP.Size = new System.Drawing.Size(379, 92);
			this.grpBoxSiopeEP.TabIndex = 50;
			this.grpBoxSiopeEP.TabStop = false;
			this.grpBoxSiopeEP.Tag = "AutoChoose.txtCodSiope.tree";
			this.grpBoxSiopeEP.Text = "Class.SIOPE";
			// 
			// btnSiope
			// 
			this.btnSiope.Location = new System.Drawing.Point(6, 38);
			this.btnSiope.Name = "btnSiope";
			this.btnSiope.Size = new System.Drawing.Size(108, 20);
			this.btnSiope.TabIndex = 11;
			this.btnSiope.Text = "Codice";
			this.btnSiope.UseVisualStyleBackColor = true;
			// 
			// txtDescSiope
			// 
			this.txtDescSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescSiope.Location = new System.Drawing.Point(120, 16);
			this.txtDescSiope.Multiline = true;
			this.txtDescSiope.Name = "txtDescSiope";
			this.txtDescSiope.ReadOnly = true;
			this.txtDescSiope.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescSiope.Size = new System.Drawing.Size(253, 69);
			this.txtDescSiope.TabIndex = 2;
			this.txtDescSiope.Tag = "sorting_siope.description";
			// 
			// txtCodSiope
			// 
			this.txtCodSiope.Location = new System.Drawing.Point(6, 64);
			this.txtCodSiope.Name = "txtCodSiope";
			this.txtCodSiope.ReadOnly = true;
			this.txtCodSiope.Size = new System.Drawing.Size(108, 20);
			this.txtCodSiope.TabIndex = 9;
			this.txtCodSiope.Tag = "sorting_siope.sortcode?x";
			// 
			// grpBoxAccertamentiBudget
			// 
			this.grpBoxAccertamentiBudget.Controls.Add(this.label14);
			this.grpBoxAccertamentiBudget.Controls.Add(this.label17);
			this.grpBoxAccertamentiBudget.Controls.Add(this.btnLinkEpAcc);
			this.grpBoxAccertamentiBudget.Controls.Add(this.btnRemoveEpAcc);
			this.grpBoxAccertamentiBudget.Controls.Add(this.txtNumAxBudget);
			this.grpBoxAccertamentiBudget.Controls.Add(this.txtEsercAxBudget);
			this.grpBoxAccertamentiBudget.Location = new System.Drawing.Point(394, 57);
			this.grpBoxAccertamentiBudget.Name = "grpBoxAccertamentiBudget";
			this.grpBoxAccertamentiBudget.Size = new System.Drawing.Size(491, 55);
			this.grpBoxAccertamentiBudget.TabIndex = 46;
			this.grpBoxAccertamentiBudget.TabStop = false;
			this.grpBoxAccertamentiBudget.Text = "Accertamento di Budget";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(132, 24);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(44, 13);
			this.label14.TabIndex = 7;
			this.label14.Text = "Numero";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(6, 24);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(49, 13);
			this.label17.TabIndex = 6;
			this.label17.Text = "Esercizio";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnLinkEpAcc
			// 
			this.btnLinkEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLinkEpAcc.Location = new System.Drawing.Point(253, 19);
			this.btnLinkEpAcc.Name = "btnLinkEpAcc";
			this.btnLinkEpAcc.Size = new System.Drawing.Size(98, 23);
			this.btnLinkEpAcc.TabIndex = 5;
			this.btnLinkEpAcc.TabStop = false;
			this.btnLinkEpAcc.Text = "Collega";
			this.btnLinkEpAcc.Visible = false;
			this.btnLinkEpAcc.Click += new System.EventHandler(this.btnLinkEpAcc_Click);
			// 
			// btnRemoveEpAcc
			// 
			this.btnRemoveEpAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveEpAcc.Location = new System.Drawing.Point(368, 19);
			this.btnRemoveEpAcc.Name = "btnRemoveEpAcc";
			this.btnRemoveEpAcc.Size = new System.Drawing.Size(117, 23);
			this.btnRemoveEpAcc.TabIndex = 4;
			this.btnRemoveEpAcc.TabStop = false;
			this.btnRemoveEpAcc.Text = "Scollega";
			this.btnRemoveEpAcc.Visible = false;
			this.btnRemoveEpAcc.Click += new System.EventHandler(this.btnRemoveEpAcc_Click);
			// 
			// txtNumAxBudget
			// 
			this.txtNumAxBudget.Location = new System.Drawing.Point(183, 21);
			this.txtNumAxBudget.Name = "txtNumAxBudget";
			this.txtNumAxBudget.ReadOnly = true;
			this.txtNumAxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtNumAxBudget.TabIndex = 3;
			this.txtNumAxBudget.TabStop = false;
			this.txtNumAxBudget.Tag = "epacc.nepacc";
			// 
			// txtEsercAxBudget
			// 
			this.txtEsercAxBudget.Location = new System.Drawing.Point(75, 21);
			this.txtEsercAxBudget.Name = "txtEsercAxBudget";
			this.txtEsercAxBudget.ReadOnly = true;
			this.txtEsercAxBudget.Size = new System.Drawing.Size(40, 20);
			this.txtEsercAxBudget.TabIndex = 2;
			this.txtEsercAxBudget.TabStop = false;
			this.txtEsercAxBudget.Tag = "epacc.yepacc";
			// 
			// grpBoxImpegniBudget
			// 
			this.grpBoxImpegniBudget.Controls.Add(this.label34);
			this.grpBoxImpegniBudget.Controls.Add(this.label33);
			this.grpBoxImpegniBudget.Controls.Add(this.btnLinkEpExp);
			this.grpBoxImpegniBudget.Controls.Add(this.btnRemoveEpExp);
			this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
			this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
			this.grpBoxImpegniBudget.Location = new System.Drawing.Point(394, 223);
			this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
			this.grpBoxImpegniBudget.Size = new System.Drawing.Size(491, 55);
			this.grpBoxImpegniBudget.TabIndex = 45;
			this.grpBoxImpegniBudget.TabStop = false;
			this.grpBoxImpegniBudget.Text = "Impegno di Budget";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(132, 24);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(44, 13);
			this.label34.TabIndex = 7;
			this.label34.Text = "Numero";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(6, 24);
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
			this.btnLinkEpExp.Location = new System.Drawing.Point(253, 19);
			this.btnLinkEpExp.Name = "btnLinkEpExp";
			this.btnLinkEpExp.Size = new System.Drawing.Size(98, 23);
			this.btnLinkEpExp.TabIndex = 5;
			this.btnLinkEpExp.TabStop = false;
			this.btnLinkEpExp.Text = "Collega";
			this.btnLinkEpExp.Visible = false;
			this.btnLinkEpExp.Click += new System.EventHandler(this.btnLinkEpExp_Click);
			// 
			// btnRemoveEpExp
			// 
			this.btnRemoveEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveEpExp.Location = new System.Drawing.Point(368, 19);
			this.btnRemoveEpExp.Name = "btnRemoveEpExp";
			this.btnRemoveEpExp.Size = new System.Drawing.Size(117, 23);
			this.btnRemoveEpExp.TabIndex = 4;
			this.btnRemoveEpExp.TabStop = false;
			this.btnRemoveEpExp.Text = "Scollega";
			this.btnRemoveEpExp.Visible = false;
			this.btnRemoveEpExp.Click += new System.EventHandler(this.btnRemoveEpExp_Click);
			// 
			// txtNumIxBudget
			// 
			this.txtNumIxBudget.Location = new System.Drawing.Point(183, 21);
			this.txtNumIxBudget.Name = "txtNumIxBudget";
			this.txtNumIxBudget.ReadOnly = true;
			this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
			this.txtNumIxBudget.TabIndex = 3;
			this.txtNumIxBudget.TabStop = false;
			this.txtNumIxBudget.Tag = "epexp.nepexp";
			// 
			// txtEsercIxBudget
			// 
			this.txtEsercIxBudget.Location = new System.Drawing.Point(75, 21);
			this.txtEsercIxBudget.Name = "txtEsercIxBudget";
			this.txtEsercIxBudget.ReadOnly = true;
			this.txtEsercIxBudget.Size = new System.Drawing.Size(40, 20);
			this.txtEsercIxBudget.TabIndex = 2;
			this.txtEsercIxBudget.TabStop = false;
			this.txtEsercIxBudget.Tag = "epexp.yepexp";
			// 
			// grpCausale
			// 
			this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
			this.grpCausale.Controls.Add(this.txtCodiceCausale);
			this.grpCausale.Controls.Add(this.button2);
			this.grpCausale.Location = new System.Drawing.Point(9, 47);
			this.grpCausale.Name = "grpCausale";
			this.grpCausale.Size = new System.Drawing.Size(379, 126);
			this.grpCausale.TabIndex = 0;
			this.grpCausale.TabStop = false;
			this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
			this.grpCausale.Text = "Causale";
			// 
			// txtDescrizioneCausale
			// 
			this.txtDescrizioneCausale.Location = new System.Drawing.Point(120, 16);
			this.txtDescrizioneCausale.Multiline = true;
			this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
			this.txtDescrizioneCausale.ReadOnly = true;
			this.txtDescrizioneCausale.Size = new System.Drawing.Size(248, 78);
			this.txtDescrizioneCausale.TabIndex = 2;
			this.txtDescrizioneCausale.TabStop = false;
			this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(6, 100);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(362, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 71);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(104, 23);
			this.button2.TabIndex = 0;
			this.button2.Tag = "manage.accmotiveapplied.tree";
			this.button2.Text = "Causale";
			// 
			// gboxCompetenza
			// 
			this.gboxCompetenza.Controls.Add(this.label16);
			this.gboxCompetenza.Controls.Add(this.txtstop);
			this.gboxCompetenza.Controls.Add(this.label15);
			this.gboxCompetenza.Controls.Add(this.txtstart);
			this.gboxCompetenza.Location = new System.Drawing.Point(9, 3);
			this.gboxCompetenza.Name = "gboxCompetenza";
			this.gboxCompetenza.Size = new System.Drawing.Size(367, 38);
			this.gboxCompetenza.TabIndex = 11;
			this.gboxCompetenza.TabStop = false;
			this.gboxCompetenza.Text = "Competenza";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(221, 12);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 16);
			this.label16.TabIndex = 22;
			this.label16.Text = "Fine";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtstop
			// 
			this.txtstop.Location = new System.Drawing.Point(261, 10);
			this.txtstop.Name = "txtstop";
			this.txtstop.Size = new System.Drawing.Size(100, 20);
			this.txtstop.TabIndex = 12;
			this.txtstop.Tag = "invoicedetail.competencystop";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(70, 12);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(39, 16);
			this.label15.TabIndex = 20;
			this.label15.Text = "Inizio";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtstart
			// 
			this.txtstart.Location = new System.Drawing.Point(115, 10);
			this.txtstart.Name = "txtstart";
			this.txtstart.Size = new System.Drawing.Size(100, 20);
			this.txtstart.TabIndex = 11;
			this.txtstart.Tag = "invoicedetail.competencystart";
			// 
			// tabLiquidazioneIva
			// 
			this.tabLiquidazioneIva.Controls.Add(this.dtgLiquidazioneIVA);
			this.tabLiquidazioneIva.Controls.Add(this.groupBox1);
			this.tabLiquidazioneIva.Location = new System.Drawing.Point(4, 22);
			this.tabLiquidazioneIva.Name = "tabLiquidazioneIva";
			this.tabLiquidazioneIva.Padding = new System.Windows.Forms.Padding(3);
			this.tabLiquidazioneIva.Size = new System.Drawing.Size(945, 338);
			this.tabLiquidazioneIva.TabIndex = 5;
			this.tabLiquidazioneIva.Text = "Liquidazione IVA";
			this.tabLiquidazioneIva.UseVisualStyleBackColor = true;
			// 
			// dtgLiquidazioneIVA
			// 
			this.dtgLiquidazioneIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtgLiquidazioneIVA.DataMember = "";
			this.dtgLiquidazioneIVA.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgLiquidazioneIVA.Location = new System.Drawing.Point(259, 12);
			this.dtgLiquidazioneIVA.Name = "dtgLiquidazioneIVA";
			this.dtgLiquidazioneIVA.Size = new System.Drawing.Size(668, 308);
			this.dtgLiquidazioneIVA.TabIndex = 11;
			this.dtgLiquidazioneIVA.Tag = "invoicedetaildeferred.default";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.txtPaymentCompetency);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(241, 64);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Competenza ai fini della Liquidazione IVA";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(16, 16);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 16);
			this.label21.TabIndex = 20;
			this.label21.Text = "Data";
			// 
			// txtPaymentCompetency
			// 
			this.txtPaymentCompetency.Location = new System.Drawing.Point(16, 32);
			this.txtPaymentCompetency.Name = "txtPaymentCompetency";
			this.txtPaymentCompetency.Size = new System.Drawing.Size(100, 20);
			this.txtPaymentCompetency.TabIndex = 7;
			this.txtPaymentCompetency.Tag = "invoicedetail.paymentcompetency";
			// 
			// tabIntrastat
			// 
			this.tabIntrastat.Controls.Add(this.grpBeni);
			this.tabIntrastat.Controls.Add(this.rdbServizi);
			this.tabIntrastat.Controls.Add(this.rdbBeni);
			this.tabIntrastat.Controls.Add(this.grpServizi);
			this.tabIntrastat.Location = new System.Drawing.Point(4, 22);
			this.tabIntrastat.Name = "tabIntrastat";
			this.tabIntrastat.Size = new System.Drawing.Size(945, 338);
			this.tabIntrastat.TabIndex = 6;
			this.tabIntrastat.Text = "Intrastat";
			this.tabIntrastat.UseVisualStyleBackColor = true;
			// 
			// grpBeni
			// 
			this.grpBeni.Controls.Add(this.label23);
			this.grpBeni.Controls.Add(this.txtMassaKg);
			this.grpBeni.Controls.Add(this.label24);
			this.grpBeni.Controls.Add(this.gboxIntrastatCode);
			this.grpBeni.Location = new System.Drawing.Point(3, 20);
			this.grpBeni.Name = "grpBeni";
			this.grpBeni.Size = new System.Drawing.Size(579, 161);
			this.grpBeni.TabIndex = 45;
			this.grpBeni.TabStop = false;
			this.grpBeni.Text = "Beni";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(6, 128);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(563, 30);
			this.label23.TabIndex = 42;
			this.label23.Text = resources.GetString("label23.Text");
			this.label23.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtMassaKg
			// 
			this.txtMassaKg.Location = new System.Drawing.Point(460, 100);
			this.txtMassaKg.Name = "txtMassaKg";
			this.txtMassaKg.Size = new System.Drawing.Size(110, 20);
			this.txtMassaKg.TabIndex = 39;
			this.txtMassaKg.Tag = "invoicedetail.weight.n";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(10, 100);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(444, 16);
			this.label24.TabIndex = 40;
			this.label24.Text = "Massa netta in Kilogrammi (solo se è presente una unità di misura supplementare)";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxIntrastatCode
			// 
			this.gboxIntrastatCode.Controls.Add(this.cmbmeasure);
			this.gboxIntrastatCode.Controls.Add(this.labUnitaMisura);
			this.gboxIntrastatCode.Controls.Add(this.txtIntrastatDescription);
			this.gboxIntrastatCode.Controls.Add(this.txtIntrastatCode);
			this.gboxIntrastatCode.Controls.Add(this.btnIntrastatCode);
			this.gboxIntrastatCode.Location = new System.Drawing.Point(6, 19);
			this.gboxIntrastatCode.Name = "gboxIntrastatCode";
			this.gboxIntrastatCode.Size = new System.Drawing.Size(564, 79);
			this.gboxIntrastatCode.TabIndex = 38;
			this.gboxIntrastatCode.TabStop = false;
			this.gboxIntrastatCode.Tag = "AutoChoose.txtIntrastatCode.default";
			this.gboxIntrastatCode.Text = "Nomenclatura combinata";
			// 
			// cmbmeasure
			// 
			this.cmbmeasure.DataSource = this.DS.intrastatmeasure;
			this.cmbmeasure.DisplayMember = "description";
			this.cmbmeasure.Enabled = false;
			this.cmbmeasure.FormattingEnabled = true;
			this.cmbmeasure.Location = new System.Drawing.Point(374, 45);
			this.cmbmeasure.Name = "cmbmeasure";
			this.cmbmeasure.Size = new System.Drawing.Size(180, 21);
			this.cmbmeasure.TabIndex = 45;
			this.cmbmeasure.Tag = "invoicedetail.idintrastatmeasure";
			this.cmbmeasure.ValueMember = "idintrastatmeasure";
			// 
			// labUnitaMisura
			// 
			this.labUnitaMisura.Location = new System.Drawing.Point(374, 26);
			this.labUnitaMisura.Name = "labUnitaMisura";
			this.labUnitaMisura.Size = new System.Drawing.Size(167, 16);
			this.labUnitaMisura.TabIndex = 44;
			this.labUnitaMisura.Text = "Unità di misura supplementare:";
			this.labUnitaMisura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIntrastatDescription
			// 
			this.txtIntrastatDescription.Location = new System.Drawing.Point(112, 16);
			this.txtIntrastatDescription.Multiline = true;
			this.txtIntrastatDescription.Name = "txtIntrastatDescription";
			this.txtIntrastatDescription.ReadOnly = true;
			this.txtIntrastatDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtIntrastatDescription.Size = new System.Drawing.Size(256, 53);
			this.txtIntrastatDescription.TabIndex = 10;
			this.txtIntrastatDescription.Tag = "intrastatcode.description";
			// 
			// txtIntrastatCode
			// 
			this.txtIntrastatCode.Location = new System.Drawing.Point(6, 49);
			this.txtIntrastatCode.Name = "txtIntrastatCode";
			this.txtIntrastatCode.Size = new System.Drawing.Size(102, 20);
			this.txtIntrastatCode.TabIndex = 9;
			this.txtIntrastatCode.Tag = "intrastatcode.code?invoicedetailview.code";
			// 
			// btnIntrastatCode
			// 
			this.btnIntrastatCode.Location = new System.Drawing.Point(7, 19);
			this.btnIntrastatCode.Name = "btnIntrastatCode";
			this.btnIntrastatCode.Size = new System.Drawing.Size(92, 23);
			this.btnIntrastatCode.TabIndex = 0;
			this.btnIntrastatCode.Tag = "Choose.intrastatcode.default";
			this.btnIntrastatCode.Text = "Nomenclatura";
			this.btnIntrastatCode.UseVisualStyleBackColor = true;
			// 
			// rdbServizi
			// 
			this.rdbServizi.AutoSize = true;
			this.rdbServizi.Location = new System.Drawing.Point(508, 6);
			this.rdbServizi.Name = "rdbServizi";
			this.rdbServizi.Size = new System.Drawing.Size(56, 17);
			this.rdbServizi.TabIndex = 44;
			this.rdbServizi.Tag = "invoicedetail.intrastatoperationkind:S";
			this.rdbServizi.Text = "Servizi";
			this.rdbServizi.UseVisualStyleBackColor = true;
			this.rdbServizi.CheckedChanged += new System.EventHandler(this.rdbServizi_CheckedChanged);
			// 
			// rdbBeni
			// 
			this.rdbBeni.AutoSize = true;
			this.rdbBeni.Checked = true;
			this.rdbBeni.Location = new System.Drawing.Point(442, 6);
			this.rdbBeni.Name = "rdbBeni";
			this.rdbBeni.Size = new System.Drawing.Size(46, 17);
			this.rdbBeni.TabIndex = 43;
			this.rdbBeni.TabStop = true;
			this.rdbBeni.Tag = "invoicedetail.intrastatoperationkind:B";
			this.rdbBeni.Text = "Beni";
			this.rdbBeni.UseVisualStyleBackColor = true;
			this.rdbBeni.CheckedChanged += new System.EventHandler(this.rdbBeni_CheckedChanged);
			// 
			// grpServizi
			// 
			this.grpServizi.Controls.Add(this.txtServizi);
			this.grpServizi.Controls.Add(this.txtCodServizi);
			this.grpServizi.Controls.Add(this.btnservizi);
			this.grpServizi.Controls.Add(this.cmbModErogazione);
			this.grpServizi.Controls.Add(this.label25);
			this.grpServizi.Location = new System.Drawing.Point(588, 20);
			this.grpServizi.Name = "grpServizi";
			this.grpServizi.Size = new System.Drawing.Size(353, 138);
			this.grpServizi.TabIndex = 46;
			this.grpServizi.TabStop = false;
			this.grpServizi.Tag = "AutoChoose.txtCodServizi.default";
			this.grpServizi.Text = "Servizi";
			// 
			// txtServizi
			// 
			this.txtServizi.Location = new System.Drawing.Point(107, 17);
			this.txtServizi.Multiline = true;
			this.txtServizi.Name = "txtServizi";
			this.txtServizi.ReadOnly = true;
			this.txtServizi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtServizi.Size = new System.Drawing.Size(240, 55);
			this.txtServizi.TabIndex = 46;
			this.txtServizi.Tag = "intrastatservice.description";
			// 
			// txtCodServizi
			// 
			this.txtCodServizi.Location = new System.Drawing.Point(10, 78);
			this.txtCodServizi.Name = "txtCodServizi";
			this.txtCodServizi.Size = new System.Drawing.Size(332, 20);
			this.txtCodServizi.TabIndex = 45;
			this.txtCodServizi.Tag = "intrastatservice.code?invoicedetailview.servicecode";
			// 
			// btnservizi
			// 
			this.btnservizi.Location = new System.Drawing.Point(9, 49);
			this.btnservizi.Name = "btnservizi";
			this.btnservizi.Size = new System.Drawing.Size(92, 23);
			this.btnservizi.TabIndex = 44;
			this.btnservizi.Tag = "Choose.intrastatservice.default";
			this.btnservizi.Text = "Servizi";
			this.btnservizi.UseVisualStyleBackColor = true;
			// 
			// cmbModErogazione
			// 
			this.cmbModErogazione.DataSource = this.DS.intrastatsupplymethod;
			this.cmbModErogazione.DisplayMember = "description";
			this.cmbModErogazione.FormattingEnabled = true;
			this.cmbModErogazione.Location = new System.Drawing.Point(170, 111);
			this.cmbModErogazione.Name = "cmbModErogazione";
			this.cmbModErogazione.Size = new System.Drawing.Size(173, 21);
			this.cmbModErogazione.TabIndex = 47;
			this.cmbModErogazione.Tag = "invoicedetail.idintrastatsupplymethod";
			this.cmbModErogazione.ValueMember = "idintrastatsupplymethod";
			// 
			// label25
			// 
			this.label25.Location = new System.Drawing.Point(70, 109);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(94, 22);
			this.label25.TabIndex = 53;
			this.label25.Text = "Mod.Erogazione";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.gboxVA3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(945, 338);
			this.tabPage3.TabIndex = 7;
			this.tabPage3.Text = "Quadro VF";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// gboxVA3
			// 
			this.gboxVA3.Controls.Add(this.radioButton6);
			this.gboxVA3.Controls.Add(this.radioButton5);
			this.gboxVA3.Controls.Add(this.radioButton4);
			this.gboxVA3.Controls.Add(this.radioButton3);
			this.gboxVA3.Location = new System.Drawing.Point(6, 5);
			this.gboxVA3.Name = "gboxVA3";
			this.gboxVA3.Size = new System.Drawing.Size(572, 74);
			this.gboxVA3.TabIndex = 3;
			this.gboxVA3.TabStop = false;
			this.gboxVA3.Text = "Ripartizione totale acquisti - Quadro VF";
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(338, 19);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(151, 17);
			this.radioButton6.TabIndex = 32;
			this.radioButton6.TabStop = true;
			this.radioButton6.Tag = "invoicedetail.va3type:A";
			this.radioButton6.Text = " Altri acquisti e importazioni";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(4, 51);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(335, 17);
			this.radioButton5.TabIndex = 31;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "invoicedetail.va3type:R";
			this.radioButton5.Text = "Beni destinati alla rivendita ovvero alla produzione di beni e servizi";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(4, 35);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(187, 17);
			this.radioButton4.TabIndex = 30;
			this.radioButton4.TabStop = true;
			this.radioButton4.Tag = "invoicedetail.va3type:N";
			this.radioButton4.Text = "Beni strumentali non ammortizzabili";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(4, 19);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(113, 17);
			this.radioButton3.TabIndex = 29;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "invoicedetail.va3type:S";
			this.radioButton3.Text = "Beni ammortizzabili";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// tabComunicazioni
			// 
			this.tabComunicazioni.Controls.Add(this.grpComunicazioni);
			this.tabComunicazioni.Location = new System.Drawing.Point(4, 22);
			this.tabComunicazioni.Name = "tabComunicazioni";
			this.tabComunicazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabComunicazioni.Size = new System.Drawing.Size(945, 338);
			this.tabComunicazioni.TabIndex = 8;
			this.tabComunicazioni.Text = "Comunicazioni";
			this.tabComunicazioni.UseVisualStyleBackColor = true;
			// 
			// grpComunicazioni
			// 
			this.grpComunicazioni.Controls.Add(this.rdbNonSpec);
			this.grpComunicazioni.Controls.Add(this.radioButton2);
			this.grpComunicazioni.Controls.Add(this.radioButton7);
			this.grpComunicazioni.Location = new System.Drawing.Point(12, 21);
			this.grpComunicazioni.Name = "grpComunicazioni";
			this.grpComunicazioni.Size = new System.Drawing.Size(400, 95);
			this.grpComunicazioni.TabIndex = 1;
			this.grpComunicazioni.TabStop = false;
			this.grpComunicazioni.Text = "Tipologia per le operazioni con Paesi a fiscalità privilegiata";
			// 
			// rdbNonSpec
			// 
			this.rdbNonSpec.AutoSize = true;
			this.rdbNonSpec.Location = new System.Drawing.Point(15, 19);
			this.rdbNonSpec.Name = "rdbNonSpec";
			this.rdbNonSpec.Size = new System.Drawing.Size(99, 17);
			this.rdbNonSpec.TabIndex = 34;
			this.rdbNonSpec.TabStop = true;
			this.rdbNonSpec.Tag = "invoicedetail.flag:2";
			this.rdbNonSpec.Text = "Non specificato";
			this.rdbNonSpec.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(15, 72);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(56, 17);
			this.radioButton2.TabIndex = 33;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "invoicedetail.flag:1";
			this.radioButton2.Text = "Servizi";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(15, 46);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(46, 17);
			this.radioButton7.TabIndex = 32;
			this.radioButton7.TabStop = true;
			this.radioButton7.Tag = "invoicedetail.flag:0";
			this.radioButton7.Text = "Beni";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// tabintra12
			// 
			this.tabintra12.Controls.Add(this.chkmove12);
			this.tabintra12.Controls.Add(this.rdbServiziintra12);
			this.tabintra12.Controls.Add(this.rdbBeniintra12);
			this.tabintra12.Controls.Add(this.chkexception12);
			this.tabintra12.Location = new System.Drawing.Point(4, 22);
			this.tabintra12.Name = "tabintra12";
			this.tabintra12.Size = new System.Drawing.Size(945, 338);
			this.tabintra12.TabIndex = 9;
			this.tabintra12.Text = "INTRA-12";
			this.tabintra12.UseVisualStyleBackColor = true;
			// 
			// chkmove12
			// 
			this.chkmove12.AutoSize = true;
			this.chkmove12.Location = new System.Drawing.Point(86, 20);
			this.chkmove12.Name = "chkmove12";
			this.chkmove12.Size = new System.Drawing.Size(466, 17);
			this.chkmove12.TabIndex = 47;
			this.chkmove12.Tag = "invoicedetail.move12:S:N";
			this.chkmove12.Text = "Acquisti da soggetti UE non residenti in Italia(Utile per la compilazione del Mod" +
    "ello INTRA-12).";
			this.chkmove12.UseVisualStyleBackColor = true;
			// 
			// rdbServiziintra12
			// 
			this.rdbServiziintra12.AutoSize = true;
			this.rdbServiziintra12.Location = new System.Drawing.Point(8, 62);
			this.rdbServiziintra12.Name = "rdbServiziintra12";
			this.rdbServiziintra12.Size = new System.Drawing.Size(56, 17);
			this.rdbServiziintra12.TabIndex = 46;
			this.rdbServiziintra12.Tag = "invoicedetail.intra12operationkind:S";
			this.rdbServiziintra12.Text = "Servizi";
			this.rdbServiziintra12.UseVisualStyleBackColor = true;
			this.rdbServiziintra12.CheckedChanged += new System.EventHandler(this.rdbServiziintra12_CheckedChanged);
			// 
			// rdbBeniintra12
			// 
			this.rdbBeniintra12.AutoSize = true;
			this.rdbBeniintra12.Checked = true;
			this.rdbBeniintra12.Location = new System.Drawing.Point(11, 19);
			this.rdbBeniintra12.Name = "rdbBeniintra12";
			this.rdbBeniintra12.Size = new System.Drawing.Size(46, 17);
			this.rdbBeniintra12.TabIndex = 45;
			this.rdbBeniintra12.TabStop = true;
			this.rdbBeniintra12.Tag = "invoicedetail.intra12operationkind:B";
			this.rdbBeniintra12.Text = "Beni";
			this.rdbBeniintra12.UseVisualStyleBackColor = true;
			this.rdbBeniintra12.CheckedChanged += new System.EventHandler(this.rdbBeniintra12_CheckedChanged);
			// 
			// chkexception12
			// 
			this.chkexception12.AutoSize = true;
			this.chkexception12.Location = new System.Drawing.Point(86, 56);
			this.chkexception12.Name = "chkexception12";
			this.chkexception12.Size = new System.Drawing.Size(508, 30);
			this.chkexception12.TabIndex = 7;
			this.chkexception12.Tag = "invoicedetail.exception12:S:N";
			this.chkexception12.Text = "IVA sui servizi in applicazione art. 7quarter, 7quinquies, 7sexies e 7septies del" +
    " D.P.R. n. 633 del 1972. \r\n(Utile per la compilazione del Modello INTRA-12.)";
			this.chkexception12.UseVisualStyleBackColor = true;
			// 
			// tabAppunti
			// 
			this.tabAppunti.Controls.Add(this.txtAppunti);
			this.tabAppunti.Location = new System.Drawing.Point(4, 22);
			this.tabAppunti.Name = "tabAppunti";
			this.tabAppunti.Size = new System.Drawing.Size(945, 338);
			this.tabAppunti.TabIndex = 10;
			this.tabAppunti.Text = "Appunti";
			this.tabAppunti.UseVisualStyleBackColor = true;
			// 
			// tabSospesometro
			// 
			this.tabSospesometro.Controls.Add(this.groupBox3);
			this.tabSospesometro.Controls.Add(this.groupBox2);
			this.tabSospesometro.Location = new System.Drawing.Point(4, 22);
			this.tabSospesometro.Name = "tabSospesometro";
			this.tabSospesometro.Size = new System.Drawing.Size(945, 338);
			this.tabSospesometro.TabIndex = 11;
			this.tabSospesometro.Text = "Spesometro";
			this.tabSospesometro.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButton8);
			this.groupBox3.Controls.Add(this.rdbVarIniziale);
			this.groupBox3.Controls.Add(this.rdbVarStorno);
			this.groupBox3.Controls.Add(this.rdbVarAssestamento);
			this.groupBox3.Controls.Add(this.rdbVarNormale);
			this.groupBox3.Controls.Add(this.rdbVarRipartizione);
			this.groupBox3.Location = new System.Drawing.Point(12, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(929, 36);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Noleggio/Leasing";
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(778, 11);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(120, 17);
			this.radioButton8.TabIndex = 11;
			this.radioButton8.Tag = "invoicedetail.leasing:N";
			this.radioButton8.Text = "No noleggio/leasing";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// rdbVarIniziale
			// 
			this.rdbVarIniziale.AutoSize = true;
			this.rdbVarIniziale.Location = new System.Drawing.Point(622, 10);
			this.rdbVarIniziale.Name = "rdbVarIniziale";
			this.rdbVarIniziale.Size = new System.Drawing.Size(73, 17);
			this.rdbVarIniziale.TabIndex = 9;
			this.rdbVarIniziale.Tag = "invoicedetail.leasing:E";
			this.rdbVarIniziale.Text = "Aeromobili";
			this.rdbVarIniziale.UseVisualStyleBackColor = true;
			// 
			// rdbVarStorno
			// 
			this.rdbVarStorno.Location = new System.Drawing.Point(471, 11);
			this.rdbVarStorno.Name = "rdbVarStorno";
			this.rdbVarStorno.Size = new System.Drawing.Size(100, 17);
			this.rdbVarStorno.TabIndex = 8;
			this.rdbVarStorno.Tag = "invoicedetail.leasing:D";
			this.rdbVarStorno.Text = "Unità da diporto ";
			// 
			// rdbVarAssestamento
			// 
			this.rdbVarAssestamento.Location = new System.Drawing.Point(352, 11);
			this.rdbVarAssestamento.Name = "rdbVarAssestamento";
			this.rdbVarAssestamento.Size = new System.Drawing.Size(96, 16);
			this.rdbVarAssestamento.TabIndex = 7;
			this.rdbVarAssestamento.Tag = "invoicedetail.leasing:C";
			this.rdbVarAssestamento.Text = "Altri veicoli ";
			// 
			// rdbVarNormale
			// 
			this.rdbVarNormale.Location = new System.Drawing.Point(125, 10);
			this.rdbVarNormale.Name = "rdbVarNormale";
			this.rdbVarNormale.Size = new System.Drawing.Size(96, 16);
			this.rdbVarNormale.TabIndex = 5;
			this.rdbVarNormale.Tag = "invoicedetail.leasing:A";
			this.rdbVarNormale.Text = "Autovettura ";
			// 
			// rdbVarRipartizione
			// 
			this.rdbVarRipartizione.Location = new System.Drawing.Point(236, 11);
			this.rdbVarRipartizione.Name = "rdbVarRipartizione";
			this.rdbVarRipartizione.Size = new System.Drawing.Size(96, 16);
			this.rdbVarRipartizione.TabIndex = 6;
			this.rdbVarRipartizione.Tag = "invoicedetail.leasing:B";
			this.rdbVarRipartizione.Text = "Caravan";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rdbNonEscludere);
			this.groupBox2.Controls.Add(this.rdbEOperation);
			this.groupBox2.Controls.Add(this.rdbDoperation);
			this.groupBox2.Controls.Add(this.rdbCIntracomunitarie);
			this.groupBox2.Controls.Add(this.rdbBEsportazioni);
			this.groupBox2.Controls.Add(this.rdbAImportazione);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Location = new System.Drawing.Point(3, 45);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(938, 183);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Valutazione del dettaglio ai fini delle dichiarazione";
			// 
			// rdbNonEscludere
			// 
			this.rdbNonEscludere.AutoSize = true;
			this.rdbNonEscludere.Location = new System.Drawing.Point(16, 16);
			this.rdbNonEscludere.Name = "rdbNonEscludere";
			this.rdbNonEscludere.Size = new System.Drawing.Size(103, 17);
			this.rdbNonEscludere.TabIndex = 6;
			this.rdbNonEscludere.TabStop = true;
			this.rdbNonEscludere.Tag = "invoicedetail.usedmodesospesometro:F";
			this.rdbNonEscludere.Text = "f) Non escludere";
			this.rdbNonEscludere.UseVisualStyleBackColor = true;
			// 
			// rdbEOperation
			// 
			this.rdbEOperation.AutoSize = true;
			this.rdbEOperation.Location = new System.Drawing.Point(16, 147);
			this.rdbEOperation.Name = "rdbEOperation";
			this.rdbEOperation.Size = new System.Drawing.Size(826, 30);
			this.rdbEOperation.TabIndex = 5;
			this.rdbEOperation.TabStop = true;
			this.rdbEOperation.Tag = "invoicedetail.usedmodesospesometro:E";
			this.rdbEOperation.Text = resources.GetString("rdbEOperation.Text");
			this.rdbEOperation.UseVisualStyleBackColor = true;
			// 
			// rdbDoperation
			// 
			this.rdbDoperation.AutoSize = true;
			this.rdbDoperation.Location = new System.Drawing.Point(16, 115);
			this.rdbDoperation.Name = "rdbDoperation";
			this.rdbDoperation.Size = new System.Drawing.Size(847, 30);
			this.rdbDoperation.TabIndex = 4;
			this.rdbDoperation.TabStop = true;
			this.rdbDoperation.Tag = "invoicedetail.usedmodesospesometro:D";
			this.rdbDoperation.Text = resources.GetString("rdbDoperation.Text");
			this.rdbDoperation.UseVisualStyleBackColor = true;
			// 
			// rdbCIntracomunitarie
			// 
			this.rdbCIntracomunitarie.AutoSize = true;
			this.rdbCIntracomunitarie.Location = new System.Drawing.Point(16, 95);
			this.rdbCIntracomunitarie.Name = "rdbCIntracomunitarie";
			this.rdbCIntracomunitarie.Size = new System.Drawing.Size(167, 17);
			this.rdbCIntracomunitarie.TabIndex = 3;
			this.rdbCIntracomunitarie.TabStop = true;
			this.rdbCIntracomunitarie.Tag = "invoicedetail.usedmodesospesometro:C";
			this.rdbCIntracomunitarie.Text = "c) Operazioni intracomunitarie;";
			this.rdbCIntracomunitarie.UseVisualStyleBackColor = true;
			// 
			// rdbBEsportazioni
			// 
			this.rdbBEsportazioni.AutoSize = true;
			this.rdbBEsportazioni.Location = new System.Drawing.Point(16, 74);
			this.rdbBEsportazioni.Name = "rdbBEsportazioni";
			this.rdbBEsportazioni.Size = new System.Drawing.Size(622, 17);
			this.rdbBEsportazioni.TabIndex = 2;
			this.rdbBEsportazioni.TabStop = true;
			this.rdbBEsportazioni.Tag = "invoicedetail.usedmodesospesometro:B";
			this.rdbBEsportazioni.Text = "b) Esportazioni di cui all\'articolo 8, comma 1, lettere a) e b) del decreto del P" +
    "residente della Repubblica 26 ottobre 1972, n. 633;";
			this.rdbBEsportazioni.UseVisualStyleBackColor = true;
			// 
			// rdbAImportazione
			// 
			this.rdbAImportazione.AutoSize = true;
			this.rdbAImportazione.Location = new System.Drawing.Point(16, 54);
			this.rdbAImportazione.Name = "rdbAImportazione";
			this.rdbAImportazione.Size = new System.Drawing.Size(97, 17);
			this.rdbAImportazione.TabIndex = 1;
			this.rdbAImportazione.TabStop = true;
			this.rdbAImportazione.Tag = "invoicedetail.usedmodesospesometro:A";
			this.rdbAImportazione.Text = "a) Importazione";
			this.rdbAImportazione.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 38);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(169, 13);
			this.label11.TabIndex = 0;
			this.label11.Text = "Escludi, il dettaglio fattura, perchè:";
			this.label11.Click += new System.EventHandler(this.label11_Click);
			// 
			// tabFatturaElettronica
			// 
			this.tabFatturaElettronica.Controls.Add(this.gboxDatiVendita);
			this.tabFatturaElettronica.Controls.Add(this.checkBox1);
			this.tabFatturaElettronica.Controls.Add(this.chkRounding);
			this.tabFatturaElettronica.Controls.Add(this.textBox5);
			this.tabFatturaElettronica.Controls.Add(this.txtRiferimentoNormativo);
			this.tabFatturaElettronica.Controls.Add(this.label29);
			this.tabFatturaElettronica.Controls.Add(this.textBox2);
			this.tabFatturaElettronica.Controls.Add(this.cmbTipocessioneprestazione);
			this.tabFatturaElettronica.Controls.Add(this.label28);
			this.tabFatturaElettronica.Location = new System.Drawing.Point(4, 22);
			this.tabFatturaElettronica.Name = "tabFatturaElettronica";
			this.tabFatturaElettronica.Size = new System.Drawing.Size(945, 338);
			this.tabFatturaElettronica.TabIndex = 12;
			this.tabFatturaElettronica.Text = "Fattura Elettronica";
			this.tabFatturaElettronica.UseVisualStyleBackColor = true;
			// 
			// gboxDatiVendita
			// 
			this.gboxDatiVendita.Controls.Add(this.label40);
			this.gboxDatiVendita.Controls.Add(this.textBox8);
			this.gboxDatiVendita.Controls.Add(this.textBox9);
			this.gboxDatiVendita.Controls.Add(this.label41);
			this.gboxDatiVendita.Location = new System.Drawing.Point(19, 154);
			this.gboxDatiVendita.Name = "gboxDatiVendita";
			this.gboxDatiVendita.Size = new System.Drawing.Size(696, 69);
			this.gboxDatiVendita.TabIndex = 3;
			this.gboxDatiVendita.TabStop = false;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(16, 16);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(126, 20);
			this.label40.TabIndex = 53;
			this.label40.Text = "Codice tipo ";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(150, 45);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(125, 20);
			this.textBox8.TabIndex = 54;
			this.textBox8.Tag = "invoicedetail.codicevalore";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(150, 16);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(125, 20);
			this.textBox9.TabIndex = 52;
			this.textBox9.Tag = "invoicedetail.codicetipo";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(16, 45);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(126, 20);
			this.label41.TabIndex = 55;
			this.label41.Text = "Codice valore";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(19, 291);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(664, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Tag = "invoicedetail.flagbit:2";
			this.checkBox1.Text = "Dettaglio inserito per rappresentare un minor ricavo a causa di costi di commissi" +
    "oni bancarie o simili. Non fa realmente parte della fattura.";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// chkRounding
			// 
			this.chkRounding.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.chkRounding.AutoSize = true;
			this.chkRounding.Location = new System.Drawing.Point(19, 268);
			this.chkRounding.Name = "chkRounding";
			this.chkRounding.Size = new System.Drawing.Size(399, 17);
			this.chkRounding.TabIndex = 4;
			this.chkRounding.Tag = "invoicedetail.rounding:S:N";
			this.chkRounding.Text = "Dettaglio inserito per rappresentare arrotondamenti presenti in fattura elettroni" +
    "ca";
			this.chkRounding.UseVisualStyleBackColor = true;
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(449, 85);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(266, 33);
			this.textBox5.TabIndex = 13;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "";
			this.textBox5.Text = "Da valorizzare qualora le operazioni non rientrino tra quelle \'imponibili\', ossia" +
    " l\'aliquota IVA sia 0.";
			// 
			// txtRiferimentoNormativo
			// 
			this.txtRiferimentoNormativo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRiferimentoNormativo.Location = new System.Drawing.Point(156, 85);
			this.txtRiferimentoNormativo.Multiline = true;
			this.txtRiferimentoNormativo.Name = "txtRiferimentoNormativo";
			this.txtRiferimentoNormativo.Size = new System.Drawing.Size(284, 54);
			this.txtRiferimentoNormativo.TabIndex = 2;
			this.txtRiferimentoNormativo.Tag = "invoicedetail.fereferencerule";
			// 
			// label29
			// 
			this.label29.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label29.Location = new System.Drawing.Point(32, 85);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(118, 23);
			this.label29.TabIndex = 11;
			this.label29.Text = "Riferimento Normativo";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(449, 29);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(266, 33);
			this.textBox2.TabIndex = 10;
			this.textBox2.TabStop = false;
			this.textBox2.Tag = "";
			this.textBox2.Text = "Il campo deve essere valorizzato qualora la Cessione o Prestazione rientri nelle " +
    "casistiche indicate.";
			// 
			// cmbTipocessioneprestazione
			// 
			this.cmbTipocessioneprestazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipocessioneprestazione.DataSource = this.DS.fetransfer;
			this.cmbTipocessioneprestazione.DisplayMember = "description";
			this.cmbTipocessioneprestazione.Location = new System.Drawing.Point(156, 29);
			this.cmbTipocessioneprestazione.Name = "cmbTipocessioneprestazione";
			this.cmbTipocessioneprestazione.Size = new System.Drawing.Size(284, 21);
			this.cmbTipocessioneprestazione.TabIndex = 1;
			this.cmbTipocessioneprestazione.Tag = "invoicedetail.idfetransfer";
			this.cmbTipocessioneprestazione.ValueMember = "idfetransfer";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(16, 32);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(134, 13);
			this.label28.TabIndex = 0;
			this.label28.Text = "Tipo Cessione/Prestazione";
			// 
			// tabPCC
			// 
			this.tabPCC.Controls.Add(this.grpNaturadiSpesa);
			this.tabPCC.Controls.Add(this.btnCasuale);
			this.tabPCC.Controls.Add(this.txtCausale);
			this.tabPCC.Controls.Add(this.label30);
			this.tabPCC.Controls.Add(this.cmbStatodelDebito);
			this.tabPCC.Location = new System.Drawing.Point(4, 22);
			this.tabPCC.Name = "tabPCC";
			this.tabPCC.Size = new System.Drawing.Size(945, 338);
			this.tabPCC.TabIndex = 13;
			this.tabPCC.Text = "PCC";
			this.tabPCC.UseVisualStyleBackColor = true;
			// 
			// grpNaturadiSpesa
			// 
			this.grpNaturadiSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpNaturadiSpesa.Controls.Add(this.rdbContoCapitale);
			this.grpNaturadiSpesa.Controls.Add(this.rdbSpesaCorrente);
			this.grpNaturadiSpesa.Location = new System.Drawing.Point(599, 19);
			this.grpNaturadiSpesa.Name = "grpNaturadiSpesa";
			this.grpNaturadiSpesa.Size = new System.Drawing.Size(290, 36);
			this.grpNaturadiSpesa.TabIndex = 25;
			this.grpNaturadiSpesa.TabStop = false;
			this.grpNaturadiSpesa.Text = "Natura di spesa";
			// 
			// rdbContoCapitale
			// 
			this.rdbContoCapitale.AutoSize = true;
			this.rdbContoCapitale.Location = new System.Drawing.Point(157, 13);
			this.rdbContoCapitale.Name = "rdbContoCapitale";
			this.rdbContoCapitale.Size = new System.Drawing.Size(93, 17);
			this.rdbContoCapitale.TabIndex = 25;
			this.rdbContoCapitale.TabStop = true;
			this.rdbContoCapitale.Tag = "invoicedetail.expensekind:CA";
			this.rdbContoCapitale.Text = "Conto capitale";
			this.rdbContoCapitale.UseVisualStyleBackColor = true;
			// 
			// rdbSpesaCorrente
			// 
			this.rdbSpesaCorrente.AutoSize = true;
			this.rdbSpesaCorrente.Location = new System.Drawing.Point(8, 14);
			this.rdbSpesaCorrente.Name = "rdbSpesaCorrente";
			this.rdbSpesaCorrente.Size = new System.Drawing.Size(97, 17);
			this.rdbSpesaCorrente.TabIndex = 24;
			this.rdbSpesaCorrente.TabStop = true;
			this.rdbSpesaCorrente.Tag = "invoicedetail.expensekind:CO";
			this.rdbSpesaCorrente.Text = "Spesa corrente";
			this.rdbSpesaCorrente.UseVisualStyleBackColor = true;
			// 
			// btnCasuale
			// 
			this.btnCasuale.BackColor = System.Drawing.SystemColors.Control;
			this.btnCasuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCasuale.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCasuale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCasuale.ImageIndex = 0;
			this.btnCasuale.Location = new System.Drawing.Point(55, 79);
			this.btnCasuale.Name = "btnCasuale";
			this.btnCasuale.Size = new System.Drawing.Size(57, 23);
			this.btnCasuale.TabIndex = 22;
			this.btnCasuale.TabStop = false;
			this.btnCasuale.Tag = "";
			this.btnCasuale.Text = "Causale";
			this.btnCasuale.UseVisualStyleBackColor = false;
			this.btnCasuale.Click += new System.EventHandler(this.btnCasuale_Click);
			// 
			// txtCausale
			// 
			this.txtCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCausale.Location = new System.Drawing.Point(129, 79);
			this.txtCausale.Multiline = true;
			this.txtCausale.Name = "txtCausale";
			this.txtCausale.ReadOnly = true;
			this.txtCausale.Size = new System.Drawing.Size(412, 69);
			this.txtCausale.TabIndex = 24;
			this.txtCausale.TabStop = false;
			this.txtCausale.Tag = "";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(16, 27);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(96, 20);
			this.label30.TabIndex = 21;
			this.label30.Text = "Stato del debito";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cmbStatodelDebito
			// 
			this.cmbStatodelDebito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatodelDebito.DataSource = this.DS.pccdebitstatus;
			this.cmbStatodelDebito.DisplayMember = "description";
			this.cmbStatodelDebito.Location = new System.Drawing.Point(129, 28);
			this.cmbStatodelDebito.Name = "cmbStatodelDebito";
			this.cmbStatodelDebito.Size = new System.Drawing.Size(412, 21);
			this.cmbStatodelDebito.TabIndex = 7;
			this.cmbStatodelDebito.Tag = "invoicedetail.idpccdebitstatus";
			this.cmbStatodelDebito.ValueMember = "idpccdebitstatus";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(0, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 0;
			// 
			// grpInvMain
			// 
			this.grpInvMain.Controls.Add(this.label10);
			this.grpInvMain.Controls.Add(this.cmbInvKindMain);
			this.grpInvMain.Controls.Add(this.txtNinv_Main);
			this.grpInvMain.Controls.Add(this.label19);
			this.grpInvMain.Controls.Add(this.txtYinv_Main);
			this.grpInvMain.Controls.Add(this.label20);
			this.grpInvMain.Location = new System.Drawing.Point(7, 2);
			this.grpInvMain.Name = "grpInvMain";
			this.grpInvMain.Size = new System.Drawing.Size(577, 37);
			this.grpInvMain.TabIndex = 1;
			this.grpInvMain.TabStop = false;
			this.grpInvMain.Text = " Fattura di riferimento";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(23, 17);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(28, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Tipo";
			// 
			// cmbInvKindMain
			// 
			this.cmbInvKindMain.DataSource = this.DS.invoicekind;
			this.cmbInvKindMain.DisplayMember = "description";
			this.cmbInvKindMain.Location = new System.Drawing.Point(70, 13);
			this.cmbInvKindMain.Name = "cmbInvKindMain";
			this.cmbInvKindMain.Size = new System.Drawing.Size(258, 21);
			this.cmbInvKindMain.TabIndex = 9;
			this.cmbInvKindMain.Tag = "invoicedetail.idinvkind_main";
			this.cmbInvKindMain.ValueMember = "idinvkind";
			// 
			// txtNinv_Main
			// 
			this.txtNinv_Main.Location = new System.Drawing.Point(506, 14);
			this.txtNinv_Main.Name = "txtNinv_Main";
			this.txtNinv_Main.Size = new System.Drawing.Size(65, 20);
			this.txtNinv_Main.TabIndex = 2;
			this.txtNinv_Main.Tag = "invoicedetail.ninv_main";
			this.txtNinv_Main.Leave += new System.EventHandler(this.txtNinv_Main_Leave);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(457, 15);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(44, 13);
			this.label19.TabIndex = 8;
			this.label19.Text = "Numero";
			// 
			// txtYinv_Main
			// 
			this.txtYinv_Main.Location = new System.Drawing.Point(389, 13);
			this.txtYinv_Main.Name = "txtYinv_Main";
			this.txtYinv_Main.Size = new System.Drawing.Size(61, 20);
			this.txtYinv_Main.TabIndex = 1;
			this.txtYinv_Main.Tag = "invoicedetail.yinv_main.year";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(334, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(49, 13);
			this.label20.TabIndex = 6;
			this.label20.Text = "Esercizio";
			// 
			// grpLiquidazioneIva
			// 
			this.grpLiquidazioneIva.Controls.Add(this.label22);
			this.grpLiquidazioneIva.Controls.Add(this.textBox1);
			this.grpLiquidazioneIva.Location = new System.Drawing.Point(7, 23);
			this.grpLiquidazioneIva.Name = "grpLiquidazioneIva";
			this.grpLiquidazioneIva.Size = new System.Drawing.Size(241, 64);
			this.grpLiquidazioneIva.TabIndex = 9;
			this.grpLiquidazioneIva.TabStop = false;
			this.grpLiquidazioneIva.Text = "Competenza ai fini della Liquidazione IVA";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(16, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 16);
			this.label22.TabIndex = 20;
			this.label22.Text = "Data";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 7;
			this.textBox1.Tag = "invoicedetail.paymentcompetency";
			// 
			// txtQuantita
			// 
			this.txtQuantita.Location = new System.Drawing.Point(564, 183);
			this.txtQuantita.Name = "txtQuantita";
			this.txtQuantita.ReadOnly = true;
			this.txtQuantita.Size = new System.Drawing.Size(88, 20);
			this.txtQuantita.TabIndex = 19;
			this.txtQuantita.TabStop = false;
			this.txtQuantita.Tag = "invoicedetail.number.N";
			this.txtQuantita.TextChanged += new System.EventHandler(this.txtImponibile_TextChanged);
			// 
			// lblidunit
			// 
			this.lblidunit.Location = new System.Drawing.Point(447, 183);
			this.lblidunit.Name = "lblidunit";
			this.lblidunit.Size = new System.Drawing.Size(111, 17);
			this.lblidunit.TabIndex = 20;
			this.lblidunit.Text = "Totale Quantità:";
			this.lblidunit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxListino
			// 
			this.gboxListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxListino.Controls.Add(this.txtPrezzoUnitarioListino);
			this.gboxListino.Controls.Add(this.label35);
			this.gboxListino.Controls.Add(this.txtCoeffConversione);
			this.gboxListino.Controls.Add(this.label26);
			this.gboxListino.Controls.Add(this.cmbUnitaMisuraAcquisto);
			this.gboxListino.Controls.Add(this.lblIcmbdpackage);
			this.gboxListino.Controls.Add(this.label27);
			this.gboxListino.Controls.Add(this.cmbUnitaMisuraCS);
			this.gboxListino.Controls.Add(this.chkListDescription);
			this.gboxListino.Controls.Add(this.btnListino);
			this.gboxListino.Controls.Add(this.txtListino);
			this.gboxListino.Controls.Add(this.txtDescrizioneListino);
			this.gboxListino.Location = new System.Drawing.Point(7, 39);
			this.gboxListino.Name = "gboxListino";
			this.gboxListino.Size = new System.Drawing.Size(951, 87);
			this.gboxListino.TabIndex = 2;
			this.gboxListino.TabStop = false;
			this.gboxListino.Tag = "";
			// 
			// txtPrezzoUnitarioListino
			// 
			this.txtPrezzoUnitarioListino.Location = new System.Drawing.Point(860, 55);
			this.txtPrezzoUnitarioListino.Name = "txtPrezzoUnitarioListino";
			this.txtPrezzoUnitarioListino.ReadOnly = true;
			this.txtPrezzoUnitarioListino.Size = new System.Drawing.Size(88, 20);
			this.txtPrezzoUnitarioListino.TabIndex = 44;
			this.txtPrezzoUnitarioListino.TabStop = false;
			this.txtPrezzoUnitarioListino.Tag = "";
			this.txtPrezzoUnitarioListino.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(780, 53);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(89, 24);
			this.label35.TabIndex = 45;
			this.label35.Text = "Prezzo unitario";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCoeffConversione
			// 
			this.txtCoeffConversione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCoeffConversione.Location = new System.Drawing.Point(670, 33);
			this.txtCoeffConversione.Name = "txtCoeffConversione";
			this.txtCoeffConversione.ReadOnly = true;
			this.txtCoeffConversione.Size = new System.Drawing.Size(67, 20);
			this.txtCoeffConversione.TabIndex = 8;
			this.txtCoeffConversione.TabStop = false;
			this.txtCoeffConversione.Tag = "invoicedetail.unitsforpackage?x";
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(553, 36);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(107, 13);
			this.label26.TabIndex = 22;
			this.label26.Text = "Coeff. di conversione";
			// 
			// cmbUnitaMisuraAcquisto
			// 
			this.cmbUnitaMisuraAcquisto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbUnitaMisuraAcquisto.DataSource = this.DS.package;
			this.cmbUnitaMisuraAcquisto.DisplayMember = "description";
			this.cmbUnitaMisuraAcquisto.Enabled = false;
			this.cmbUnitaMisuraAcquisto.FormattingEnabled = true;
			this.cmbUnitaMisuraAcquisto.Location = new System.Drawing.Point(669, 7);
			this.cmbUnitaMisuraAcquisto.Name = "cmbUnitaMisuraAcquisto";
			this.cmbUnitaMisuraAcquisto.Size = new System.Drawing.Size(106, 21);
			this.cmbUnitaMisuraAcquisto.TabIndex = 7;
			this.cmbUnitaMisuraAcquisto.TabStop = false;
			this.cmbUnitaMisuraAcquisto.Tag = "invoicedetail.idpackage";
			this.cmbUnitaMisuraAcquisto.ValueMember = "idpackage";
			// 
			// lblIcmbdpackage
			// 
			this.lblIcmbdpackage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIcmbdpackage.AutoSize = true;
			this.lblIcmbdpackage.Location = new System.Drawing.Point(559, 10);
			this.lblIcmbdpackage.Name = "lblIcmbdpackage";
			this.lblIcmbdpackage.Size = new System.Drawing.Size(106, 13);
			this.lblIcmbdpackage.TabIndex = 21;
			this.lblIcmbdpackage.Text = "U.tà di misura imballo";
			// 
			// label27
			// 
			this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(592, 60);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(71, 13);
			this.label27.TabIndex = 23;
			this.label27.Text = "U.tà di misura";
			// 
			// cmbUnitaMisuraCS
			// 
			this.cmbUnitaMisuraCS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbUnitaMisuraCS.DataSource = this.DS.unit;
			this.cmbUnitaMisuraCS.DisplayMember = "description";
			this.cmbUnitaMisuraCS.Enabled = false;
			this.cmbUnitaMisuraCS.FormattingEnabled = true;
			this.cmbUnitaMisuraCS.Location = new System.Drawing.Point(669, 56);
			this.cmbUnitaMisuraCS.Name = "cmbUnitaMisuraCS";
			this.cmbUnitaMisuraCS.Size = new System.Drawing.Size(106, 21);
			this.cmbUnitaMisuraCS.TabIndex = 9;
			this.cmbUnitaMisuraCS.TabStop = false;
			this.cmbUnitaMisuraCS.Tag = "invoicedetail.idunit";
			this.cmbUnitaMisuraCS.ValueMember = "idunit";
			// 
			// chkListDescription
			// 
			this.chkListDescription.Location = new System.Drawing.Point(9, 11);
			this.chkListDescription.Name = "chkListDescription";
			this.chkListDescription.Size = new System.Drawing.Size(235, 21);
			this.chkListDescription.TabIndex = 4;
			this.chkListDescription.TabStop = false;
			this.chkListDescription.Text = "Fitra per Descrizione/Class.Merceologica";
			// 
			// btnListino
			// 
			this.btnListino.BackColor = System.Drawing.SystemColors.Control;
			this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnListino.ImageIndex = 0;
			this.btnListino.Location = new System.Drawing.Point(6, 53);
			this.btnListino.Name = "btnListino";
			this.btnListino.Size = new System.Drawing.Size(57, 23);
			this.btnListino.TabIndex = 1;
			this.btnListino.TabStop = false;
			this.btnListino.Tag = "";
			this.btnListino.Text = "Listino";
			this.btnListino.UseVisualStyleBackColor = false;
			this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
			// 
			// txtListino
			// 
			this.txtListino.Location = new System.Drawing.Point(70, 56);
			this.txtListino.Name = "txtListino";
			this.txtListino.Size = new System.Drawing.Size(161, 20);
			this.txtListino.TabIndex = 3;
			this.txtListino.Tag = "";
			this.txtListino.Enter += new System.EventHandler(this.txtListino_Enter);
			this.txtListino.Leave += new System.EventHandler(this.txtListino_Leave);
			// 
			// txtDescrizioneListino
			// 
			this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizioneListino.Location = new System.Drawing.Point(250, 10);
			this.txtDescrizioneListino.Multiline = true;
			this.txtDescrizioneListino.Name = "txtDescrizioneListino";
			this.txtDescrizioneListino.ReadOnly = true;
			this.txtDescrizioneListino.Size = new System.Drawing.Size(301, 67);
			this.txtDescrizioneListino.TabIndex = 9;
			this.txtDescrizioneListino.TabStop = false;
			this.txtDescrizioneListino.Tag = "";
			// 
			// chkBollaDoganale
			// 
			this.chkBollaDoganale.AutoSize = true;
			this.chkBollaDoganale.Location = new System.Drawing.Point(658, 129);
			this.chkBollaDoganale.Name = "chkBollaDoganale";
			this.chkBollaDoganale.Size = new System.Drawing.Size(103, 17);
			this.chkBollaDoganale.TabIndex = 31;
			this.chkBollaDoganale.Tag = "invoicedetail.flagbit:0";
			this.chkBollaDoganale.Text = "Valore doganale";
			this.chkBollaDoganale.UseVisualStyleBackColor = true;
			// 
			// chkSpeseAnticipateSpedizioniere
			// 
			this.chkSpeseAnticipateSpedizioniere.AutoSize = true;
			this.chkSpeseAnticipateSpedizioniere.Location = new System.Drawing.Point(778, 129);
			this.chkSpeseAnticipateSpedizioniere.Name = "chkSpeseAnticipateSpedizioniere";
			this.chkSpeseAnticipateSpedizioniere.Size = new System.Drawing.Size(184, 17);
			this.chkSpeseAnticipateSpedizioniere.TabIndex = 32;
			this.chkSpeseAnticipateSpedizioniere.Tag = "invoicedetail.flagbit:1";
			this.chkSpeseAnticipateSpedizioniere.Text = "Spese anticipate da spedizioniere";
			this.chkSpeseAnticipateSpedizioniere.UseVisualStyleBackColor = true;
			// 
			// Frm_invoicedetail_single
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(969, 665);
			this.Controls.Add(this.chkSpeseAnticipateSpedizioniere);
			this.Controls.Add(this.chkBollaDoganale);
			this.Controls.Add(this.gboxListino);
			this.Controls.Add(this.txtQuantita);
			this.Controls.Add(this.lblidunit);
			this.Controls.Add(this.grpInvMain);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.grpValoreUnitInValuta);
			this.Controls.Add(this.txtQuantitaConfezioni);
			this.Controls.Add(this.txtDescrizione);
			this.Controls.Add(this.lblidpackage);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.grpValoreTotaleInEuro);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Frm_invoicedetail_single";
			this.Text = "frmdettdocumentoivasingle";
			this.grpValoreTotaleInEuro.ResumeLayout(false);
			this.grpValoreTotaleInEuro.PerformLayout();
			this.grpValoreUnitInValuta.ResumeLayout(false);
			this.grpValoreUnitInValuta.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gboxProfessionale.ResumeLayout(false);
			this.gboxProfessionale.PerformLayout();
			this.gboxCausaleBilancioEntrata.ResumeLayout(false);
			this.gboxCausaleBilancioEntrata.PerformLayout();
			this.grpCupCig.ResumeLayout(false);
			this.grpCupCig.PerformLayout();
			this.gBoxupbIVA.ResumeLayout(false);
			this.gBoxupbIVA.PerformLayout();
			this.gboxImponibile.ResumeLayout(false);
			this.gboxImponibile.PerformLayout();
			this.gboxIVA.ResumeLayout(false);
			this.gboxIVA.PerformLayout();
			this.grpRigaContratto.ResumeLayout(false);
			this.grpRigaContratto.PerformLayout();
			this.grpRiga.ResumeLayout(false);
			this.grpRiga.PerformLayout();
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
			this.tabEP.ResumeLayout(false);
			this.gboxPreimpegniDiBudget.ResumeLayout(false);
			this.gboxPreimpegniDiBudget.PerformLayout();
			this.grpBoxSiopeEP.ResumeLayout(false);
			this.grpBoxSiopeEP.PerformLayout();
			this.grpBoxAccertamentiBudget.ResumeLayout(false);
			this.grpBoxAccertamentiBudget.PerformLayout();
			this.grpBoxImpegniBudget.ResumeLayout(false);
			this.grpBoxImpegniBudget.PerformLayout();
			this.grpCausale.ResumeLayout(false);
			this.grpCausale.PerformLayout();
			this.gboxCompetenza.ResumeLayout(false);
			this.gboxCompetenza.PerformLayout();
			this.tabLiquidazioneIva.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgLiquidazioneIVA)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabIntrastat.ResumeLayout(false);
			this.tabIntrastat.PerformLayout();
			this.grpBeni.ResumeLayout(false);
			this.grpBeni.PerformLayout();
			this.gboxIntrastatCode.ResumeLayout(false);
			this.gboxIntrastatCode.PerformLayout();
			this.grpServizi.ResumeLayout(false);
			this.grpServizi.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.gboxVA3.ResumeLayout(false);
			this.gboxVA3.PerformLayout();
			this.tabComunicazioni.ResumeLayout(false);
			this.grpComunicazioni.ResumeLayout(false);
			this.grpComunicazioni.PerformLayout();
			this.tabintra12.ResumeLayout(false);
			this.tabintra12.PerformLayout();
			this.tabAppunti.ResumeLayout(false);
			this.tabAppunti.PerformLayout();
			this.tabSospesometro.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabFatturaElettronica.ResumeLayout(false);
			this.tabFatturaElettronica.PerformLayout();
			this.gboxDatiVendita.ResumeLayout(false);
			this.gboxDatiVendita.PerformLayout();
			this.tabPCC.ResumeLayout(false);
			this.tabPCC.PerformLayout();
			this.grpNaturadiSpesa.ResumeLayout(false);
			this.grpNaturadiSpesa.PerformLayout();
			this.grpInvMain.ResumeLayout(false);
			this.grpInvMain.PerformLayout();
			this.grpLiquidazioneIva.ResumeLayout(false);
			this.grpLiquidazioneIva.PerformLayout();
			this.gboxListino.ResumeLayout(false);
			this.gboxListino.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private void mostraNascondiCigCup() {
            DataRow Curr = DS.invoicedetail.Rows[0];
            grpCupCig.Visible = true;
            if (Curr["idmankind"] == DBNull.Value) {
               txtCIG.ReadOnly=false;
                txtCUP.ReadOnly = false;
            }
            else {
                txtCIG.ReadOnly = true;
                txtCUP.ReadOnly = true;
            }
        }

        void makeSpaceFrom(GroupBox G) {
            Form F = G.FindForm();
            int disp = G.Height;
            int y0 = G.Location.Y;
            F.SuspendLayout();
            foreach (Control C in F.Controls) {
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
            F.Size = new Size(F.Size.Width, F.Size.Height - disp);
            F.ResumeLayout();

        }

        //void disableEditGroup() {
        //    groupBox5.Enabled = false;
        //    txtQuantitaConfezioni.Enabled = false;
        //    txtQuantita.Enabled = false;
        //    //			txtImponibile.Enabled = false;
        //    txtSconto.Enabled = false;
        //    txtDescrizione.Enabled = false;
        //    txtstart.Enabled = false;
        //    txtstop.Enabled = false;
        //    grpCausale.Enabled = false;
        //    gboxUPB.Enabled = false;
        //    gboxListino.Enabled = false;
        //    gBoxupbIVA.Enabled = false;
        //}

        object getCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }







        private void enableDisableNaturadispesa() {
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
                rdbSpesaCorrente.Enabled = false;
                rdbContoCapitale.Enabled = false;
            }
        }

        //private bool EsisteContabilizzazioneDettOrdine(DataRow Curr) {
        //    string filterManDetContab = QHS.AppAnd(QHS.CmpEq("idmankind", Curr["idmankind"]),
        //                        QHS.CmpEq("yman", Curr["yman"]), QHS.CmpEq("nman", Curr["nman"]), QHS.CmpEq("rownum", Curr["manrownum"]));
        //    filterManDetContab = QHS.AppOr(filterManDetContab, QHS.DoPar(QHS.AppOr(QHS.IsNotNull("idexp_iva"), QHS.IsNotNull("idexp_taxable"))));
        //    if (Meta.Conn.RUN_SELECT_COUNT("mandatedetail", filterManDetContab, true) > 0) {
        //        return true;
        //    }
        //    return false;
        //}

        //private object CalcolaResiduiDettaglioOrdine(DataRow Curr) {
        //    string filterManDet = QHS.AppAnd(QHC.CmpEq("idmankind", Curr["idmankind"]),
        //                        QHS.CmpEq("yman", Curr["yman"]), QHS.CmpEq("nman", Curr["nman"]), QHS.CmpEq("rownum", Curr["manrownum"]));
        //    DataRow rInvoicedetail = Meta.SourceRow;
        //    DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
        //    bool HasDDT = (rInvoice["flag_ddt"].ToString() == "S");
        //    object residuo;
        //    if (HasDDT) {
        //        residuo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("mandatedetailstockedtoinvoice", filterManDet, "residual"));
        //        return residuo;
        //    }
        //    else {
        //        residuo = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("mandatedetailnoddttoinvoice", filterManDet, "residual"));
        //        return residuo;
        //    }

        //}

        private void enableDisableQuantita(DataRow Curr) {
            if (Curr == null) return;
            DataRow rInvoicedetail = Meta.SourceRow;
            if (rInvoicedetail == null) return;
            DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
            if (rInvoice == null) return;
         
            if ((Curr["idlist"] == DBNull.Value) || (rInvoice["flag_ddt"].ToString() == "N" && controller.InsertMode)) {
                txtQuantitaConfezioni.ReadOnly = false;
            }
            else {
                txtQuantitaConfezioni.ReadOnly = true;
            }
        }

        //private decimal roundDecimal6(decimal valuta) {
        //    decimal truncated = decimal.Truncate(valuta*10000000);
        //    if (truncated > 0) {
        //        if ((truncated%10) >= 5) truncated += 5;
        //    }
        //    else {
        //        if (((-truncated)%10) >= 5) truncated -= 5;
        //    }
        //    truncated /= 10;
        //    truncated = decimal.Truncate(truncated);
        //    return truncated/1000000;
        //}

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if ( Meta.destroyed || Meta.formController.isClosing) return;
            if (T.TableName == "intrastatcode" && controller.DrawStateIsDone) {
                if (R != null && !controller.IsEmpty) {
                    DataRow Curr = DS.invoicedetail.Rows[0];
                    comboManager.setComboBoxValue(cmbmeasure, R["idintrastatmeasure"]);
                    Curr["idintrastatmeasure"] = R["idintrastatmeasure"];
                }
            }
            if (T.TableName == "ivakind") {
                if (R != null) {
                    aliquota = CfgFn.GetNoNullDecimal(R["rate"]);
                    percindeduc = CfgFn.GetNoNullDecimal(R["unabatabilitypercentage"]);
                    if ((AV != null) && (AV.ToString().ToUpper() == "V") && (percindeduc != 0)) {
                        percindeduc = 0; // per le fatture di vendita
                    }

                    byte flagIK = CfgFn.GetNoNullByte(R["flag"]);
                    if (comunicazioni) {
                        if ((flagIK & 1) == 0) {
                            grpComunicazioni.Enabled = true; // tipo iva non istituzionale       
                        }
                        else {
                            if (flagva3.ToString() == "S") // tipo iva istituzionale in fatture commerciali
                            {
                                rdbNonSpec.Checked = true;
                                grpComunicazioni.Enabled = false;
                            }
                        }
                    }
                    else {
                        grpComunicazioni.Enabled = false;
                    }
                }
                else {
                    aliquota = 0;
                    percindeduc = 0;
                }
                if ((R != null) && (controller.DrawStateIsDone)) {
                    calcolaImportiValuta(controller.DrawStateIsDone);
                    calcolaImportiEUR(controller.DrawStateIsDone);
                    if (aliquota == 0) { //14773 Riporto riferimento normativo aliquota iva
	                    txtRiferimentoNormativo.Text = R["description"].ToString();
	                    DataRow Curr = DS.invoicedetail.Rows[0];
	                    Curr["fereferencerule"] = R["description"];
                    }
                }
            }
            if ((T.TableName == "accmotive" || T.TableName == "accmotiveapplied") && controller.DrawStateIsDone) {
                controller.GetFormData(true);
                visualizzaControlliContabilizzazioneImpAccBudget();
            }

            if (T.TableName == "pccdebitstatus") {
                if (!controller.DrawStateIsDone)
                    return;
                if (controller.IsEmpty)
                    return;
                if (R == null) {
                    //rdbSpesaCorrente.Checked = false;
                    //rdbContoCapitale.Checked = false;
                    rdbSpesaCorrente.Enabled = false;
                    rdbContoCapitale.Enabled = false;
                    DataRow Curr = DS.invoicedetail.Rows[0];
                    txtCausale.Text = "";
                    Curr["idpccdebitmotive"] = DBNull.Value;
                    return;
                }
                else {
                    //Gestione Casuale
                    DataRow Curr = DS.invoicedetail.Rows[0];
                    if (Curr["idpccdebitstatus"].ToString() != R["idpccdebitstatus"].ToString()) {
                        Curr["idpccdebitstatus"] = R["idpccdebitstatus"];
                        txtCausale.Text = "";
                        Curr["idpccdebitmotive"] = DBNull.Value;
                    }

                    // Gestione Natura di Spesa
                    enableDisableNaturadispesa();
                    //object statodeldebito = DBNull.Value;
                    //if (cmbStatodelDebito.SelectedIndex > 0)
                    //    statodeldebito = cmbStatodelDebito.SelectedValue;

                    //List<string> stati_con_natura = new List<string>(
                    //    new string[] { "LIQ", "LIQdaSOSP", "LIQdaNL", "SOSPdaLIQ", "NLdaLIQ" });
                    //if (stati_con_natura.Contains(statodeldebito.ToString())) {
                    //    rdbSpesaCorrente.Enabled = true;
                    //    rdbContoCapitale.Enabled = true;
                    //}
                    //else {
                    //    //rdbSpesaCorrente.Checked = false;
                    //    //rdbContoCapitale.Checked = false;
                    //    rdbSpesaCorrente.Enabled = false;
                    //    rdbContoCapitale.Enabled = false;
                    //}
                }
            }

            if (T.TableName == "package") {
                if (!controller.DrawStateIsDone) return;
                if (controller.IsEmpty) return;
                if (R == null) {
                    lblidpackage.Text = "Q.tà";
                    //lblImportoUnitario.Text = "Importo unitario";
                    return;
                }
                string UnitaAcquisto = R["description"].ToString();
                lblidpackage.Text = "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")";
            }
            if (T.TableName == "unit") {
                if (!controller.DrawStateIsDone) return;
                if (controller.IsEmpty) return;
                if (R == null) {
                    lblidunit.Text = "Totale";
                    return;
                }
                string UnitaCarico = R["description"].ToString();
                lblidunit.Text = "N." + UnitaCarico;
            }

            if (T.TableName == "accmotiveapplied") {
                if (!controller.DrawStateIsDone)return;
                if (controller.IsEmpty)return;
                object expensekind = R?["expensekind"];
                SiopeObj.setCausaleEPCorrente(R?["idaccmotive"]);
                SiopeObj.selectSiope();
                if (R == null) return;
                impostaNaturadiSpesa(expensekind);
            }
        }

       private void impostaNaturadiSpesa(object expensekind) {
            DataRow Curr = DS.invoicedetail.Rows[0];

            if (expensekind != DBNull.Value) {
                if ((Curr["expensekind"] != DBNull.Value) &&
                    (Curr["expensekind"].ToString() != expensekind.ToString())) {
                    if (MessageBox.Show("Imposto la Natura di Spesa in base alla Causale?",
                        "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                        Curr["expensekind"] = expensekind;
                        if (expensekind.ToString() == "CO")
                            rdbSpesaCorrente.Checked = true;
                        if (expensekind.ToString() == "CA")
                            rdbContoCapitale.Checked = true;
                    }
                }
                else {
                    Curr["expensekind"] = expensekind;
                    if (expensekind.ToString() == "CO")
                        rdbSpesaCorrente.Checked = true;
                    if (expensekind.ToString() == "CA")
                        rdbContoCapitale.Checked = true;
                }

            }
        }

        private void abilitaTipoIVA(bool enable) {
            btnTipo.Enabled = enable;
            cmbTipoIVA.Enabled = enable;
        }


        private void calcolaImportiValuta(bool LeggiDati) {
            if (Meta.formController.isClosing) return;
            if (Meta.destroyed) return;
            if (DS.invoicedetail.Rows.Count == 0) return;

            if (LeggiDati) controller.GetFormData(true);
            DataRow Curr = DS.invoicedetail.Rows[0];

            try {
	            decimal imponibile = CfgFn.GetNoNullDecimal(Curr["taxable"]);
	            decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Curr["npackage"]);
	            decimal imposta = CfgFn.GetNoNullDecimal(Curr["tax"]);
	            decimal sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(Curr["discount"]), 6);
	            decimal imponibiletotEUR = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)) * tassocambio);

                decimal ivaEUR = CfgFn.RoundValuta(imponibiletotEUR*Convert.ToDecimal(aliquota));
                //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
                decimal impindeducEUR = CfgFn.RoundValuta(ivaEUR*percindeduc);
                //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);

                txtImponibileValuta.Text = imponibiletotEUR.ToString("n");
                txtImpostaEUR.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");
                ;
                txtImpDeducEUR.Text = HelpForm.StringValue(impindeducEUR, "x.y.fixed.2...1");
            }
            catch {
                txtImponibileValuta.Text = "";
                txtImpostaEUR.Text = "";
                txtImpDeducEUR.Text = "";
            }
        }

        private void calcolaImponibileValuta() {
            DataRow Curr = DS.invoicedetail.Rows[0];

            try {
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile*quantitaConfezioni*(1 - sconto)));
                txtImponibileValuta.Text = imponibiletot.ToString("n");
            }
            catch {
                txtImponibileValuta.Text = "";
            }
        }

        private void calcolaImportiEUR(bool LeggiDati) {
            if (LeggiDati) controller.GetFormData(true);
            DataRow Curr = DS.invoicedetail.Rows[0];

            try {
                //double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                //double quantitaConfezioni = CfgFn.GetNoNullDouble(Curr["npackage"]);
                //double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                //double imponibiletot = CfgFn.RoundValuta((imponibile*quantitaConfezioni*(1 - sconto)));
                //double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);

                decimal imponibile = CfgFn.GetNoNullDecimal(Curr["taxable"]);
                decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(Curr["npackage"]);
                decimal imposta = CfgFn.GetNoNullDecimal(Curr["tax"]);
                decimal sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(Curr["discount"]), 6);
                decimal imponibiletotEUR = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)) * tassocambio);
                //imposta    +=  CfgFn.RoundValuta((R_imponibile*R_quantita *(1-R_sconto))*R_imposta*tassocambio);
                

                txtImponibileEUR.Text = imponibiletotEUR.ToString("n");

            }
            catch {
                txtImponibileEUR.Text = "";
            }

        }

        private void txtImponibile_TextChanged(object sender, System.EventArgs e) {
            if (Meta.formController.isClosing) return;
            if (Meta.destroyed) return;
            if (DS.invoicedetail.Rows.Count == 0) return;

            if (!controller.DrawStateIsDone) return;
            calcolaImportiValuta(true);
            calcolaImportiEUR(true);
        }

        private void txtIvaValuta_TextChanged(object sender, System.EventArgs e) {
            if (!controller.DrawStateIsDone) return;
            //CalcolaImportiEUR(true);
            ricalcolaIvaIndeducibile(true);
        }

        void ricalcolaIvaIndeducibile(bool LeggiDati) {
            if (Meta == null) return;
            if (!controller.DrawStateIsDone) return;

            if (LeggiDati) controller.GetFormData(true);
            DataRow Curr = DS.invoicedetail.Rows[0];

            try {
                double ivaEUR = CfgFn.GetNoNullDouble(Curr["tax"]);
                double percindet = CfgFn.GetNoNullDouble(
                    HelpForm.GetObjectFromString(typeof(double), txtPercIndeduc.Text, "x.y.fixed.4..%.100"));

                double impindeducEUR = CfgFn.RoundValuta(percindet*ivaEUR);
                txtImpDeducEUR.Text = impindeducEUR.ToString("c");
                Curr["unabatable"] = impindeducEUR;
            }
            catch {
            }

        }

        private void btnScollegaRiga_Click(object sender, System.EventArgs e) {
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["idmankind"] = DBNull.Value;
            Curr["yman"] = DBNull.Value;
            Curr["nman"] = DBNull.Value;
            Curr["manrownum"] = DBNull.Value;
            DS.mandatekind.Clear();
            Meta.FreshForm(false);

        }

        private void btnScollegaRigaContratto_Click(object sender, System.EventArgs e) {
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["idestimkind"] = DBNull.Value;
            Curr["yestim"] = DBNull.Value;
            Curr["nestim"] = DBNull.Value;
            Curr["estimrownum"] = DBNull.Value;
            DS.estimatekind.Clear();
            Meta.FreshForm(false);
        }

        void visualizzaControlliContabilizzazioneImpAccBudget() {
            if (controller.IsEmpty || Meta.destroyed || Meta.formController.isClosing) return;
            if (DS.invoicedetail.Rows.Count == 0) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr["idepexp_pre"] == DBNull.Value) {
                btnScollegaPreimpegno.Visible = false; // Scollega Impegno di Budget
            }
            else {
                btnScollegaPreimpegno.Visible = (Curr["idepexp"] == DBNull.Value && Curr["idmankind"] != DBNull.Value);
            }

            //object idepexpOriginal = (Curr.RowState == DataRowState.Modified)
            //    ? Curr["idepexp", DataRowVersion.Original]
            //    : Curr["idepexp"];
            //if (Curr["idepexp"] == DBNull.Value) {
            //    btnLinkEpExp.Visible = true; // Collega Impegno di Budget
            //    btnRemoveEpExp.Visible = false; // Scollega Impegno di Budget
             
            //}
            //else {
            //    btnLinkEpExp.Visible = false;
            //    btnRemoveEpExp.Visible = (idepexpOriginal==DBNull.Value || 
            //                                    Curr["idmankind"] == DBNull.Value || 
            //                              CfgFn.GetNoNullInt32(Curr["yman"])<minimoAnnoImpegniDiBudget);
            //}

            //object idepaccOriginal = (Curr.RowState == DataRowState.Modified)
            //    ? Curr["idepacc", DataRowVersion.Original]
            //    : Curr["idepacc"];
            //if (Curr["idepacc"] == DBNull.Value) {
            //    btnLinkEpAcc.Visible = true; // Collega accertamento di Budget
            //    btnRemoveEpAcc.Visible = false; // Scollega accertamento di Budget
            //}
            //else {
            //    btnLinkEpAcc.Visible = false;
            //    btnRemoveEpAcc.Visible = (
            //        idepaccOriginal==DBNull.Value ||
            //        Curr["idestimkind"] == DBNull.Value || 
            //        CfgFn.GetNoNullInt32(Curr["yestim"]) < minimoAnnoImpegniDiBudget);
            //}
            bool ImpegnoDiBudgetAbilitato = (AV != null) && AV.ToString().ToUpper() != "V";
            bool AccertamentoDiBudgetAbilitato = (AV != null) && AV.ToString().ToUpper() == "V";

            object idaccmotive = Curr["idaccmotive"];
            if (idaccmotive != DBNull.Value) {
                DataTable t = Conn.RUN_SELECT("accmotivedetail", "*", null,
                    QHS.AppAnd(QHS.CmpEq("ayear", security.GetEsercizio()), QHS.CmpEq("idaccmotive", idaccmotive)), null, false);
                if (t != null && t.Rows.Count == 1) {
                    int flagaccountusage = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("account",
                        QHS.CmpEq("idacc", t.Rows[0]["idacc"]),
                        "flagaccountusage"));
                    if ((flagaccountusage & 4416) != 0) ImpegnoDiBudgetAbilitato = true;
                    if ((flagaccountusage & 128) != 0) AccertamentoDiBudgetAbilitato = true;
                }
            }

            grpBoxImpegniBudget.Enabled = ImpegnoDiBudgetAbilitato;
            gboxPreimpegniDiBudget.Enabled = ImpegnoDiBudgetAbilitato;
            grpBoxAccertamentiBudget.Enabled = AccertamentoDiBudgetAbilitato;

        }

        void visualizzaControlliContabilizzazione() {
            if (controller.InsertMode) {
                gboxImponibile.Visible = false;
                gboxIVA.Visible = false;
                return;
            }
        }


        private void btnRemoveImponibile_Click(object sender, System.EventArgs e) {
            if (MessageBox.Show(this,
                "Rimuovendo la contabilizzazione del DETTAGLIO il movimento finanziario continuerà " +
                "comunque a contabilizzare il doc. iva, tuttavia in forma 'generica'. Per rimuovere la contabilizzazione " +
                "del doc.iva è necessario eseguire la procedura guidata 'Rimuovi contabilizzazione'.\r" +
                "Procedo a rimuovere la contabilizzazione del dettaglio?", "Avviso", MessageBoxButtons.YesNo) !=
                DialogResult.Yes) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["idexp_taxable"] = DBNull.Value;
            Curr["idinc_taxable"] = DBNull.Value;
            DS.expense_taxable.Clear();
            DS.income_taxable.Clear();
            txtEsercizioImponibile.Text = "";
            txtNumImponibile.Text = "";
            if (Curr["idexp_iva", DataRowVersion.Original].ToString() ==
                Curr["idexp_taxable", DataRowVersion.Original].ToString() &&
                Curr["idexp_iva", DataRowVersion.Original].ToString() != "") {
                Curr["idexp_iva"] = DBNull.Value;
                DS.expense_iva.Clear();
                txtEsercizioIva.Text = "";
                txtNumeroIva.Text = "";
            }
            if (Curr["idinc_iva", DataRowVersion.Original].ToString() ==
                Curr["idinc_taxable", DataRowVersion.Original].ToString() &&
                Curr["idinc_iva", DataRowVersion.Original].ToString() != "") {
                Curr["idinc_iva"] = DBNull.Value;
                DS.income_iva.Clear();
                txtEsercizioIva.Text = "";
                txtNumeroIva.Text = "";
            }

        }

        private void abilita_gruppi(string intrastatoperationkind) {
            if (intrastatoperationkind == "") {
                grpBeni.Enabled = false;
                grpServizi.Enabled = false;
                return;
            }

            if (CfgFn.GetNoNullInt32(security.GetEsercizio()) != CfgFn.GetNoNullInt32(rPadre["yinv"])) {
                grpBeni.Enabled = false;
                grpServizi.Enabled = false;
                rdbBeni.Enabled = false;
                rdbServizi.Enabled = false;
                return;
            }

            if (intrastatoperationkind == "B") {
                // Abilita beni e disabilita Servizi
                grpBeni.Enabled = true;

                if (cmbModErogazione.SelectedIndex > 0) {
                    cmbModErogazione.SelectedIndex = -1;
                }
                txtCodServizi.Text = "";
                txtServizi.Text = "";
                if ((!controller.IsEmpty)) {
                    DS.invoicedetail.Rows[0]["idintrastatsupplymethod"] = DBNull.Value;
                    DS.invoicedetail.Rows[0]["idintrastatservice"] = DBNull.Value;
                }
                grpServizi.Enabled = false;

            }
            else {
                //abilita servizi e disabilita Beni
                grpServizi.Enabled = true;
                if (cmbmeasure.SelectedIndex > 0) {
                    cmbmeasure.SelectedIndex = -1;
                }
                txtIntrastatCode.Text = "";
                txtIntrastatDescription.Text = "";
                txtMassaKg.Text = "";
                if ((!controller.IsEmpty)) {
                    DS.invoicedetail.Rows[0]["idintrastatcode"] = DBNull.Value;
                    DS.invoicedetail.Rows[0]["idintrastatmeasure"] = DBNull.Value;
                    DS.invoicedetail.Rows[0]["weight"] = DBNull.Value;
                }
                grpBeni.Enabled = false;
            }
        }

        private void rdbBeni_CheckedChanged(object sender, EventArgs e) {
            if ((Meta != null) && controller.DrawStateIsDone) {
                if (rdbBeni.Checked) abilita_gruppi("B");
            }
        }

        private void rdbServizi_CheckedChanged(object sender, EventArgs e) {
            if ((Meta != null) && controller.DrawStateIsDone) {
                if (rdbServizi.Checked) abilita_gruppi("S");
            }
        }


        void aggiornaListino(DataRow Choosen) {
	        var ctrl = this.getInstance<IFormController>();
	        if (ctrl.isClosing) return;
            if (Choosen==null || Choosen.RowState==DataRowState.Detached)return;

            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr.RowState == DataRowState.Detached) return;

            object idlistclasssel = Choosen["idlistclass"];
            string filterListClass = QHS.AppAnd(QHS.CmpEq("idlistclass", idlistclasssel),
                QHS.CmpEq("ayear", security.GetEsercizio()));
            DataTable ListClass = Conn.RUN_SELECT("listclassyearview", "*", null, filterListClass, null, true);
            if ((ListClass != null) && (ListClass.Rows.Count > 0) &&
                (
                    ListClass.Rows[0]["va3type"] != DBNull.Value ||
                    ListClass.Rows[0]["flag"] != DBNull.Value ||
                    ListClass.Rows[0]["idintrastatsupplymethod"] != DBNull.Value ||
                    ListClass.Rows[0]["intra12operationkind"] != DBNull.Value ||
                    ListClass.Rows[0]["idintrastatservice"] != DBNull.Value ||
                    ListClass.Rows[0]["idintrastatcode"] != DBNull.Value ||
                    ListClass.Rows[0]["idintrastatmeasure"] != DBNull.Value)
                ) {
                if (MessageBox.Show(
                    "Aggiorno i campi del dettaglio in base alla classificazione merceologica selezionata?",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if ((flagva3.ToString() != "N") && (AV.ToString().ToUpper() == "A"))
                        Curr["va3type"] = ListClass.Rows[0]["va3type"];

                    if (comunicazioni)
                        Curr["flag"] = ListClass.Rows[0]["flag"];

                    if (intrastat) {
                        Curr["idintrastatsupplymethod"] = ListClass.Rows[0]["idintrastatsupplymethod"];
                        Curr["idintrastatservice"] = ListClass.Rows[0]["idintrastatservice"];
                        Curr["idintrastatcode"] = ListClass.Rows[0]["idintrastatcode"];
                        Curr["idintrastatmeasure"] = ListClass.Rows[0]["idintrastatmeasure"];

                        if (Curr["idintrastatcode"] != DBNull.Value)
                            Curr["intrastatoperationkind"] = "B";
                        else if (Curr["idintrastatservice"] != DBNull.Value)
                            Curr["intrastatoperationkind"] = "S";
                    }

                    if (mostraINTRA12) Curr["intra12operationkind"] = ListClass.Rows[0]["intra12operationkind"];

                    Meta.FreshForm();
                    if (Choosen.RowState == DataRowState.Detached) {
                        Choosen = DS.listclass.Select(QHC.CmpEq("idlistclass", idlistclasssel))[0];
                    }
                }

            }
            if (grpCausale.Enabled) {
                // Legge la causale EP associata alla classificazione merceologica del listino, e la scrive nella causale EP del dettaglio ordine.
                object idaccmotive = Conn.DO_READ_VALUE("listclass",
                    QHS.CmpEq("idlistclass", idlistclasssel),
                    "idaccmotive");
                if (idaccmotive != null && idaccmotive != DBNull.Value) {
                    DS.accmotiveapplied.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied, null,
                        QHS.AppAnd(filterEpOperation, QHS.CmpEq("idaccmotive", idaccmotive)), null,
                        false);
                    if (DS.accmotiveapplied.Rows.Count > 0) {
                        DataRow AccMotive = DS.accmotiveapplied.Rows[0];
                        txtCodiceCausale.Text = AccMotive["codemotive"].ToString();
                        txtDescrizioneCausale.Text = AccMotive["motive"].ToString();
                        Curr["idaccmotive"] = AccMotive["idaccmotive"].ToString();

                        SiopeObj.setCausaleEPCorrente(Curr?["idaccmotive"]);
                        SiopeObj.selectSiope();
                       

                        impostaNaturadiSpesa(AccMotive["expensekind"]);
                    }
                    //else {
                    //    txtCodiceCausale.Text = "";
                    //    txtDescrizioneCausale.Text = "";
                    //    Curr["idaccmotive"] = DBNull.Value;
                    //}
                }
            }


            if (txtDescrizione.Text != "") {
                if (CfgFn.GetNoNullInt32(Curr["idlist"]) != CfgFn.GetNoNullInt32(idlistclasssel)) {
                    if (MessageBox.Show("Aggiorno il campo descrizione in base al listino selezionato?",
                        "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        txtDescrizione.Text = Choosen["description"].ToString();
                }
            }
            else {
                txtDescrizione.Text = Choosen["description"].ToString();
            }

            Curr["idlist"] = Choosen["idlist"];
            Curr["idunit"] = Choosen["idunit"];
            Curr["idpackage"] = Choosen["idpackage"];
            Curr["unitsforpackage"] = Choosen["unitsforpackage"];

            riempiOggetti(Choosen);
            riempiCoordMagazzino();
            adeguaQuantitaTotale();
        }


        private void btnListino_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            //DataRow Curr = DS.invoicedetail.Rows[0];
            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", security.GetDataContabile())));
            if (AV.ToString() == "A") {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            }
            else {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            }
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            if (chkListDescription.Checked) {
                FrmAskDescr FR = new FrmAskDescr(dispatcher,Conn);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                if (FR.Selected != null) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                }
                if (FR.txtDescrizione.Text != "") {
                    string Description = FR.txtDescrizione.Text;
                    if (!Description.EndsWith("%")) Description += "%";
                    if (!Description.StartsWith("%")) Description = "%" + Description;
                    filter = QHS.AppAnd(filter, QHS.Like("description", Description));
                }
            }
            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            aggiornaListino(Choosen);

            return;
        }

        private void riempiOggetti(DataRow listRow) {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";
            txtPrezzoUnitarioListino.Text = (listRow != null) ? listRow["price"].ToString() : "";
            comboManager.setComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            comboManager.setComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);
        }

        private void riempiCoordMagazzino() {
            if (controller.IsEmpty) return;
            if (controller.EditMode) return;
            DataRow RSetup = tExpSetup.Rows[0];
            DataRow Curr = DS.invoicedetail.Rows[0];
            object idsorkind1 = RSetup["idsortingkind1"];
            object idsorkind2 = RSetup["idsortingkind2"];
            object idsorkind3 = RSetup["idsortingkind3"];

            object idsor1 = Curr["idsor1"];
            object idsor2 = Curr["idsor2"];
            object idsor3 = Curr["idsor3"];
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) return;
            if (idsor1 != DBNull.Value || idsor2 != DBNull.Value || idsor3 != DBNull.Value) return;

            if ((RSetup["idsor1_stock"] != DBNull.Value) && (Curr["idsor1"] == DBNull.Value)) {
                Curr["idsor1"] = RSetup["idsor1_stock"];
                setCoord(1, RSetup["idsor1_stock"]);
            }
            if ((RSetup["idsor2_stock"] != DBNull.Value) && (Curr["idsor2"] == DBNull.Value)) {
                Curr["idsor2"] = RSetup["idsor2_stock"];
                setCoord(2, RSetup["idsor2_stock"]);
            }
            if ((RSetup["idsor3_stock"] != DBNull.Value) && (Curr["idsor3"] == DBNull.Value)) {
                Curr["idsor3"] = RSetup["idsor3_stock"];
                setCoord(3, RSetup["idsor3_stock"]);
            }

        }

        private void setCoord(int num, object idsor) {
            TextBox TextClass = (TextBox) getCtrlByName("txtCodice" + num.ToString());
            TextBox TextDenom = (TextBox) getCtrlByName("txtDenom" + num.ToString());
            Conn.RUN_SELECT_INTO_TABLE(DS.Tables["sorting" + num.ToString()], null, QHS.CmpEq("idsor", idsor), null,
                false);
            if (DS.Tables["sorting" + num.ToString()].Rows.Count > 0) {
                DataRow C = DS.Tables["sorting" + num.ToString()].Rows[0];
                TextClass.Text = C["sortcode"].ToString();
                TextDenom.Text = C["description"].ToString();
            }
        }

        private void txtQuantitaConfezioni_Leave(object sender, EventArgs e) {
            if (Meta.formController.isClosing) return;
            if (Meta.destroyed) return;
            if (DS.invoicedetail.Rows.Count == 0) return;
            if (txtQuantitaConfezioni.Text == "") {
                txtQuantita.Text = "";
                return;
            }

            double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            double number = npackage*unitsforpackage;
            txtQuantita.Text = HelpForm.StringValue(number, "x.y");
        }


        private void setLabel() {
            DataRow Curr = DS.invoicedetail.Rows[0];
            object idpackage = Curr["idpackage"];
            object idunit = Curr["idunit"];

            if (idpackage == null || idpackage == DBNull.Value) {
                lblidpackage.Text = "Q.tà";
                //lblImportoUnitario.Text = "Importo unitario";
            }
            else {
                string UnitaAcquisto =
                    Conn.DO_READ_VALUE("package", QHS.CmpEq("idpackage", idpackage), "description").ToString();
                lblidpackage.Text = "N." + UnitaAcquisto;
                //lblImportoUnitario.Text = "Importo (per " + UnitaAcquisto + ")";
            }

            if (idunit != null && idunit != DBNull.Value) {
                string UnitaCarico = Conn.DO_READ_VALUE("unit", QHS.CmpEq("idunit", idunit), "description").ToString();
                lblidunit.Text = "N." + UnitaCarico;
            }
        }


        private void svuotaOggetti() {
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";
            txtPrezzoUnitarioListino.Text = "";
            if (cmbUnitaMisuraCS.SelectedIndex >= 0) {
                cmbUnitaMisuraCS.SelectedIndex = -1;
            }
            if (cmbUnitaMisuraAcquisto.SelectedIndex >= 0) {
                cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            }

            if (!controller.IsEmpty) {
                DS.invoicedetail.Rows[0]["idunit"] = DBNull.Value;
                DS.invoicedetail.Rows[0]["idpackage"] = DBNull.Value;
                DS.invoicedetail.Rows[0]["unitsforpackage"] = DBNull.Value;
                DS.invoicedetail.Rows[0]["idlist"] = DBNull.Value;
            }
        }

        private void adeguaQuantitaTotale() {
            if (txtCoeffConversione.Text == "") {
                // Se cancello il Coeff. di Conversione, la q.tà totale sarà uguale alla q.tà per l'imballo.
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                txtQuantita.Text = HelpForm.StringValue(npackage, "x.y");
                return;
            }
            else {
                double npackage = CfgFn.GetNoNullDouble(txtQuantitaConfezioni.Text);
                int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
                double number = npackage*unitsforpackage;
                txtQuantita.Text = HelpForm.StringValue(number, "x.y");
            }
        }

        private void txtNinv_Main_Leave(object sender, EventArgs e) {
            object idinvkind_main = DBNull.Value;
            if (cmbInvKindMain.SelectedIndex > 0) idinvkind_main = cmbInvKindMain.SelectedValue;
            string yinv_main = txtYinv_Main.Text;
            string ninv_main = txtNinv_Main.Text;

            if ((idinvkind_main != DBNull.Value) && (yinv_main != "") && (ninv_main != "")) {
                string filter = QHS.AppAnd(QHS.CmpEq("idinvkind", idinvkind_main),
                    QHS.CmpEq("yinv", yinv_main),
                    QHS.CmpEq("ninv", ninv_main));
                if (Conn.RUN_SELECT_COUNT("invoice", filter, true) == 0) {
                    MessageBox.Show("Nessuna fattura trovata.", "Avviso");
                    txtYinv_Main.Text = "";
                    txtNinv_Main.Text = "";
                    if (cmbInvKindMain.SelectedIndex > 0) {
                        cmbInvKindMain.SelectedIndex = -1;
                    }
                            
                    txtDescrizione.Focus();
                    return;
                }
            }
        }

        private void label11_Click(object sender, EventArgs e) {

        }

        private void rdbBeniintra12_CheckedChanged(object sender, EventArgs e) {
            //chkmove12.Checked = rdbBeniintra12.Checked;
        }

        private void rdbServiziintra12_CheckedChanged(object sender, EventArgs e) {
            //chkmove12.Checked = rdbBeniintra12.Checked;
        }

        private void btnCasuale_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            object idpccdebitstatus = DBNull.Value;
            string filter = "";
            if (cmbStatodelDebito.SelectedIndex > 0) idpccdebitstatus = cmbStatodelDebito.SelectedValue;
            if (idpccdebitstatus != DBNull.Value) {
                int maskorder =
                    CfgFn.GetNoNullInt32(
                        DS.pccdebitstatus.Select(QHC.CmpEq("idpccdebitstatus", idpccdebitstatus))[0]["flag"]);
                filter = "( flagstatus & " + QueryCreator.unquotedstrvalue(maskorder, true) + " <>0 )";
            }

            MetaData MCausali = MetaData.GetMetaData(this, "pccdebitmotive");
            MCausali.FilterLocked = true;
            MCausali.DS = DS.Clone();

            DataRow Choosen = MCausali.SelectOne("default", filter, "pccdebitmotive", null);
            if (Choosen == null)
                return;

            Curr["idpccdebitmotive"] = Choosen["idpccdebitmotive"];
            txtCausale.Text = Choosen["description"].ToString();
        }

        string filterEpOperation;
        int minimoAnnoImpegniDiBudget = 0;
        private IFormController controller;
        private ISecurity security;
        private IMetaModel model;
        private IHelpForm helpForm;
        private IMetaDataDispatcher dispatcher;
        private IComboBoxManager comboManager;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = this.getInstance<IDataAccess>();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            var _ = new AccMotiveManager(grpCausale);
            cmbInvKindMain.DataSource = DS.invoicekind;
            cmbInvKindMain.DisplayMember = "description";
            cmbInvKindMain.ValueMember = "idinvkind";

            controller = this.getInstance<IFormController>();
            security = this.getInstance<ISecurity>();
            model = MetaFactory.factory.getSingleton<IMetaModel>();
            helpForm = this.getInstance<IHelpForm>();
            dispatcher = this.getInstance<IMetaDataDispatcher>();
            comboManager = this.getInstance<IComboBoxManager>();

            bool IsAdmin = false;
            if (security.GetSys("manage_prestazioni") != null)
                IsAdmin = (security.GetSys("manage_prestazioni").ToString() == "S");

            btnCollegaContrProf.Enabled = IsAdmin;
            btnScollegaContrProf.Enabled = IsAdmin;
            minimoAnnoImpegniDiBudget = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("config", QHS.CmpEq("flagepexp", "S"), "min(ayear)"));

            tassocambio = 1;
            Hashtable h = (Hashtable) Meta.ExtraParameter;
            if (h == null) {
                grpValoreUnitInValuta.Text += " (non impostata)";
                tassocambio = 1;
            }
            else {
                grpValoreUnitInValuta.Text += " (" + h["nomevaluta"].ToString() + ")";
                tassocambio = Convert.ToDecimal(h["cambio"]);
            }

            rPadre = Meta.SourceRow;
            intrastat = (bool) rPadre.Table.ExtendedProperties["intrastat"];
            if (!intrastat) {
                tabControl1.TabPages.Remove(tabIntrastat);
            }
            comunicazioni = (bool) rPadre.Table.ExtendedProperties["comunicazioni"];
            if (!comunicazioni) {
                //tabControl1.TabPages.Remove(tabComunicazioni);
                grpComunicazioni.Enabled = false;
            }
            else {
                grpComunicazioni.Enabled = true;
            }

            flagva3 = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", security.GetSys("esercizio")), "flagva3");

            if ((flagva3 == DBNull.Value) || (flagva3 == null))
                flagva3 = "N";
            /*
             * N per chi non presenta la dichiarazione VF26
             * S per chi desidera escludere i dettagli con aliquota istituzionale in fatture commerciali/promiscue dalla dichiarazione
             * X per chi prende tutti i dettagli delle fatture commerciali/promiscue
            */

            if (controller.EditMode) {
                string filterIvaKind = QHS.CmpEq("idivakind", rPadre["idivakind"]);
                object flagIKO = Conn.DO_READ_VALUE("ivakind", filterIvaKind, "flag");
                byte flagIKB = CfgFn.GetNoNullByte(flagIKO);
                if (((flagIKB & 1) != 0) && (flagva3.ToString() == "S")) {
                    grpComunicazioni.Enabled = false; // tipo iva istituzionale in fatture commerciali  
                }
            }
            string filterivakind = "";
            if (rPadre.Table.ExtendedProperties["flagactivity"] != null) {
                int flagactivity = CfgFn.GetNoNullInt32(rPadre.Table.ExtendedProperties["flagactivity"]);
                if (flagactivity == 1)
                    filterivakind = QHS.BitSet("flag", 0);
                if (flagactivity == 2)
                    filterivakind = QHS.BitSet("flag", 1);
                if (flagactivity == 3)
                    filterivakind = QHS.BitSet("flag", 2);
            }
            string flagintracom = "";
            if (rPadre.Table.ExtendedProperties["flagintracom"] != null) {
                flagintracom = rPadre.Table.ExtendedProperties["flagintracom"].ToString();

                if (flagintracom == "N")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 6));
                if (flagintracom == "S")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 7));
                if (flagintracom == "X")
                    filterivakind = QHS.AppAnd(filterivakind, QHS.BitSet("flag", 8));
            }
            object idivakind = rPadre["idivakind"];

            if (filterivakind != "" && idivakind != DBNull.Value) {
                filterivakind = QHS.AppOr(QHS.CmpEq("idivakind", idivakind), QHS.DoPar(filterivakind));
            }
            if (filterivakind != "") {
                model.setStaticFilter(DS.ivakind, filterivakind);
            }

            if (rPadre.Table.ExtendedProperties["flag"] == null) {
                AV = "A";
            }
            else {
//del documento considera il registro associato e non il tipo documento
                AV = rPadre.Table.ExtendedProperties["registerclass"].ToString().ToUpper();
            }

            object AVAR;
            if (rPadre.Table.ExtendedProperties["flag"] == null) {
                AVAR = "N";
            }
            else {
                AVAR = (CfgFn.GetNoNullByte(rPadre.Table.ExtendedProperties["flag"]) & 4) != 0
                    ? "S"
                    : "N";
            }

            //object filtroEpContratto = rPadre.Table.ExtendedProperties["filtroepcontratto"];
            filterEpOperation = QHS.IsNull("idepoperation");
            NotaVariazione = false;
            if (AVAR != null) {
                if (AVAR.ToString().ToUpper() == "S") {
                    NotaVariazione = true;
                    grpInvMain.Visible = true;
                }
                else {
                    grpInvMain.Visible = false;
                    NotaVariazione = false;
                    makeSpaceFrom(grpInvMain);
                }
            }
            Vendita = false;
            if (AV != null) {
                if (AV.ToString().ToUpper() == "A") {
                    Vendita = false;
                    grpRiga.Visible = true;
                    gboxImponibile.Visible = true;
                    gboxIVA.Visible = true;
                    txtEsercizioIva.Tag = "expense_iva.ymov";
                    txtNumeroIva.Tag = "expense_iva.nmov";
                    txtEsercizioImponibile.Tag = "expense_taxable.ymov";
                    txtNumImponibile.Tag = "expense_taxable.nmov";

                    if (AVAR.ToString().ToUpper() == "S") {
                        filterEpOperation = QHS.CmpEq("idepoperation", "fatacqvar");
                    }
                    else {
                        filterEpOperation = QHS.CmpEq("idepoperation", "fatacq");
                    }
                    gboxVA3.Enabled = true;
                    gboxDatiVendita.Visible = false;
                }
                else {
                    Vendita = true;
                    grpRigaContratto.Visible = true;
                    gboxCausaleBilancioEntrata.Visible = true;
                    gboxImponibile.Visible = true;
                    gboxIVA.Visible = true;
                    txtEsercizioIva.Tag = "income_iva.ymov";
                    txtNumeroIva.Tag = "income_iva.nmov";
                    txtEsercizioImponibile.Tag = "income_taxable.ymov";
                    txtNumImponibile.Tag = "income_taxable.nmov";

                    if (AVAR.ToString().ToUpper() == "S") {
                        filterEpOperation = QHS.CmpEq("idepoperation", "fatvenvar");
                    }
                    else {
                        filterEpOperation = QHS.CmpEq("idepoperation", "fatven");
                    }
                    lblPercIndeduc.Visible = false;
                    txtPercIndeduc.Visible = false;
                    lblIvaIndedEUR.Visible = false;
                    txtImpDeducEUR.Visible = false;
                    gboxVA3.Enabled = false;
                }
            }
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperation = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperation, Conn as DataAccess);

            //if (rPadre["idaccmotive"] != DBNull.Value) {
            //    string filterthis = QHS.CmpEq("idaccmotive", rPadre["idaccmotive"]);
            //    int N = Conn.RUN_SELECT_COUNT("accmotiveapplied", QHS.AppAnd(filterEpOperation, filterthis), false);
            //}

            model.setExtraParams(DS.accmotiveapplied, filterEpOperation);

            DS.accmotiveapplied.setStaticFilter(filterEpOperation);

            string filterEsercizio = QHC.CmpEq("ayear", security.GetEsercizio());
            string filterEsercInvoice = QHC.CmpEq("ayear", rPadre["yinv"]);
            DS.intrastatcode.setStaticFilter(filterEsercInvoice);
            DS.intrastatservice.setStaticFilter(filterEsercInvoice);

            gboxIntrastatCode.Tag = gboxIntrastatCode.Tag + "." + filterEsercInvoice;
            btnIntrastatCode.Tag = btnIntrastatCode.Tag + "." + filterEsercInvoice;
            grpServizi.Tag = grpServizi.Tag + "." + filterEsercInvoice;
            btnservizi.Tag = btnservizi.Tag + "." + filterEsercInvoice;

            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataAccess.SetTableForReading(DS.expense_taxable, "expense");
            DataAccess.SetTableForReading(DS.expense_iva, "expense");
            DataAccess.SetTableForReading(DS.income_taxable, "income");
            DataAccess.SetTableForReading(DS.income_iva, "income");
            DataAccess.SetTableForReading(DS.upb_iva, "upb");
            DataAccess.SetTableForReading(DS.finmotive_income, "finmotive");
            tExpSetup = Conn.RUN_SELECT("config", "*", null, filterEsercizio, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                object idsorkind1 = R["idsortingkind1"];
                object idsorkind2 = R["idsortingkind2"];
                object idsorkind3 = R["idsortingkind3"];
                CfgFn.SetGBoxClass(this, 1, idsorkind1);
                CfgFn.SetGBoxClass(this, 2, idsorkind2);
                CfgFn.SetGBoxClass(this, 3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAnalitico);
                }
            }
            //DataTable DetailsInvoice = rPadre.Table.DataSet.Tables["invoicedetail"];
            //DataRow[] Selected = DetailsInvoice.Select(QHC.CmpEq("idgroup", rPadre["idgroup"]));
            
            DataTable Invoice = rPadre.Table.DataSet.Tables["invoice"];
            //string flagdeferred = Invoice.Rows[0]["flagdeferred"].ToString();
            object upd_paymentcompetency = Conn.GetUsr("upd_paymentcompetency");
            bool function_enabled = ((upd_paymentcompetency != null && upd_paymentcompetency.ToString().ToUpper() == "'S'"));


            txtPaymentCompetency.ReadOnly = !function_enabled; //(flagdeferred == "N");
            //string flagintracom = Invoice.Rows[0]["flagintracom"].ToString();

            if (Invoice.Columns.Contains("flagbit")) {
                object flagObj = Invoice.Rows[0]["flagbit"];
                int flagInvoice = CfgFn.GetNoNullInt32(flagObj);
                bool isBollettaDoganale = (flagInvoice & 1) != 0; // Bit 0
                bool isFattSpedizioniere = (flagInvoice & 2) != 0; // Bit 1
                if (!isBollettaDoganale) {
                    chkBollaDoganale.Visible = false;
                    chkBollaDoganale.Checked = false;
                }
                if (!isFattSpedizioniere) {
                    chkSpeseAnticipateSpedizioniere.Visible = false;
                    chkSpeseAnticipateSpedizioniere.Checked = false;
                }
            }

            mostraINTRA12 = false;
            if (flagintracom == "N") {
                mostraINTRA12 = false;
            }
            else {
                if (rPadre.Table.ExtendedProperties["flagactivity"] != null) {
                    int flagactivity = CfgFn.GetNoNullInt32(rPadre.Table.ExtendedProperties["flagactivity"]);
                    if (flagactivity == 1) {
                        mostraINTRA12 = true;
                    }
                    else {
                        mostraINTRA12 = false;
                    }
                }
            }

            if (!mostraINTRA12) {
                tabControl1.TabPages.Remove(tabintra12);
            }
            else {
                chkmove12.Visible = (flagintracom == "S");
            }
            //chkmove12.Checked = (flagintracom == "S");

            cmbmeasure.DataSource = DS.intrastatmeasure;
            cmbmeasure.DisplayMember = "description";
            cmbmeasure.ValueMember = "idintrastatmeasure";

            int countList = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("list", null, "count(*)"));
            if (countList == 0) {
                gboxListino.Visible = false;
                makeSpaceFrom(gboxListino);
            }
            else {
                gboxListino.Visible = true;
            }

            GetData.CacheTable(DS.pccdebitmotive);
            GetData.SetSorting(DS.pccdebitmotive, "listingorder asc");
            GetData.SetSorting(DS.pccdebitstatus, "listingorder asc");
            DataAccess.SetTableForReading(DS.sorting_siope, "sorting");
            if (AV.ToString() == "A") {
                SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, true, DS.sorting_siope);
            }
            else {
                SiopeObj = new siope_helper(this, txtCodSiope, txtDescSiope, btnSiope, grpBoxSiopeEP, false, DS.sorting_siope);
            }
        }
        siope_helper SiopeObj;
        private bool NotaVariazione;
        private bool Vendita;

        public void MetaData_AfterPost() {
            Meta.SourceRow.Table.ExtendedProperties["RigaModificata"] = Meta.SourceRow;
        }

        public void MetaData_AfterFill() {
            DataRow Curr = DS.invoicedetail.Rows[0];
            SiopeObj.setCausaleEPCorrente(Curr["idaccmotive"]);
            if (chkResiduoOrdine.Checked)
                chkResiduoOrdine.Enabled = false;
            DataTable Invoice = rPadre.Table.DataSet.Tables["invoice"];
            string flagintracom = Invoice.Rows[0]["flagintracom"].ToString();
            //imposta il default del radiobutton se riesce a farlo, in base alle nostre competenze.
            if (controller.firstFillForThisRow && flagintracom == "S" && Curr["usedmodesospesometro"] == DBNull.Value) {
                rdbCIntracomunitarie.Checked = true;
            }
            gboxUPB.Enabled = true;
            grpCausale.Enabled = true;
            mostraNascondiCigCup();

            visualizzaControlliContabilizzazione();
            visualizzaControlliContabilizzazioneImpAccBudget();
            if ((Curr["idepexp"] != DBNull.Value || Curr["idepacc"] != DBNull.Value ) &&      
                (Curr["idmankind"]!=DBNull.Value)){
                grpCausale.Enabled = false;
            }
            if (Curr["idmankind"] != DBNull.Value) {
                gboxUPB.Enabled = false;
                gBoxupbIVA.Enabled = false;
            }

            if (Curr["idexp_taxable"] != DBNull.Value || Curr["idinc_taxable"] != DBNull.Value
                ) {
                gboxUPB.Enabled = false;
                if (Curr["idupb"] == DBNull.Value) {
                    if (Curr["idexp_taxable"] != DBNull.Value) {
                        if (controller.firstFillForThisRow) {
                            if (MessageBox.Show(this,
                                "Aggiorno l'upb dell'imponibile in base a quello usato in fase di contabilizzazione",
                                "Avviso",
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                Curr["idupb"] = Conn.DO_READ_VALUE("expenseyear",
                                    QHS.CmpEq("idexp", Curr["idexp_taxable"]),
                                    "max(idupb)");
                                Conn.RUN_SELECT_INTO_TABLE(DS.upb, null, QHS.CmpEq("idupb", Curr["idupb"]), null,
                                    false);
                                helpForm.FillControls(gboxUPB.Controls);
                            }
                        }
                    }
                    else {
                        if (controller.firstFillForThisRow) {
                            if (MessageBox.Show(this,
                                "Aggiorno l'upb dell'imponibile  in base a quello usato in fase di contabilizzazione",
                                "Avviso",
                                MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                Curr["idupb"] = Conn.DO_READ_VALUE("incomeyear",
                                    QHS.CmpEq("idinc", Curr["idinc_taxable"]),
                                    "max(idupb)");
                                Conn.RUN_SELECT_INTO_TABLE(DS.upb_iva, null, QHS.CmpEq("idupb", Curr["idupb"]), null,
                                    false);
                                helpForm.FillControls(gboxUPB.Controls);
                            }
                        }
                    }
                }

            }


            if (Curr["idexp_iva"] != DBNull.Value || Curr["idinc_iva"] != DBNull.Value
                ) {
                gBoxupbIVA.Enabled = false;
                if (Curr["idupb_iva"] == DBNull.Value) {
                    if (Curr["idexp_iva"] != DBNull.Value) {
                        if (controller.firstFillForThisRow) {
                            object idupb_iva = Conn.DO_READ_VALUE("expenseyear", QHS.CmpEq("idexp", Curr["idexp_iva"]),
                                "max(idupb)");
                            if (idupb_iva.ToString() != Curr["idupb"].ToString()) {
                                if (MessageBox.Show(this,
                                    "Aggiorno l'upb dell'iva in base a quello usato in fase di contabilizzazione",
                                    "Avviso",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    Curr["idupb_iva"] = idupb_iva;

                                    Conn.RUN_SELECT_INTO_TABLE(DS.upb, null, QHS.CmpEq("idupb", Curr["idupb"]),
                                        null,
                                        false);
                                    helpForm.FillControls(gBoxupbIVA.Controls);
                                }

                            }
                        }
                    }
                    else {
                        if (controller.firstFillForThisRow) {
                            object idupb_iva = Conn.DO_READ_VALUE("incomeyear", QHS.CmpEq("idinc", Curr["idinc_iva"]),
                                "max(idupb)");
                            if (idupb_iva.ToString() != Curr["idupb"].ToString()) {
                                if (MessageBox.Show(this,
                                    "Aggiorno l'upb dell'iva in base a quello usato in fase di contabilizzazione",
                                    "Avviso",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    Curr["idupb_iva"] = idupb_iva;
                                    Conn.RUN_SELECT_INTO_TABLE(DS.upb_iva, null, QHS.CmpEq("idupb", Curr["idupb_iva"]),
                                        null,
                                        false);
                                    helpForm.FillControls(gBoxupbIVA.Controls);
                                }
                            }
                        }
                    }
                }
            }

            if (Curr["idmankind"] == DBNull.Value) {
                btnScollegaRiga.Enabled = false;
            }
            calcolaImponibileValuta();
            calcolaImportiEUR(false);
            if (controller.firstFillForThisRow && Curr["idmankind"] != DBNull.Value) {
                string filtermandate = QHS.AppAnd( QHS.CmpMulti(Curr, "idmankind", "yman", "nman"), QHS.CmpEq("rownum", Curr["manrownum"]));
                DataTable MandateDetail = Conn.RUN_SELECT("mandatedetail", "*",
                    null, filtermandate, null, null, true);
                gboxCompetenza.Visible = false;
                if (MandateDetail != null && MandateDetail.Rows.Count == 1) {
                    DataRow Det = MandateDetail.Rows[0];
                    if (Det["assetkind"].ToString().ToUpper() == "S") {
                        gboxCompetenza.Visible = true;
                        HelpForm.SetDenyNull(DS.invoicedetail.Columns["competencystart"], true);
                        HelpForm.SetDenyNull(DS.invoicedetail.Columns["competencystop"], true);
                    }
                }
            }
            if (Curr["idestimkind"] == DBNull.Value) {
                btnScollegaRigaContratto.Enabled = false;
            }

            if (Curr["intrastatoperationkind"] == DBNull.Value) {
                abilita_gruppi("");
            }
            else {
                if (Curr["intrastatoperationkind"].ToString() == "B") {
                    abilita_gruppi("B");
                }
                else {
                    abilita_gruppi("S");
                }
            }

            setLabel();
            object idlist = Curr["idlist"];
            if (idlist != DBNull.Value) {
                Conn.RUN_SELECT_INTO_TABLE( DS.listview, null, QHS.CmpEq("idlist", idlist), null, true);
                if (DS.listview.Rows.Count != 0) {
                    riempiOggetti(DS.listview.Rows[0]);
                }
            }
            enableDisableQuantita(Curr);
            // Il check è sempre Abilitato, è il metodo a valutare se agire o meno.
            //object ResiduoDettOrdine =  CalcolaResiduiDettaglioOrdine(Curr);
            //if (Meta.EditMode && EsisteContabilizzazioneDettOrdine(Curr) && CfgFn.GetNoNullDecimal(ResiduoDettOrdine) > 0) {
            //    chkResiduoOrdine.Enabled = true;
            //}
            //else {
            //    chkResiduoOrdine.Enabled = false;
            //}
            if ((AV != null) && (AV.ToString().ToUpper() == "V")) {
                cmbTipocessioneprestazione.Enabled = true; // è abilitato solo per le fatture di vendita
                txtRiferimentoNormativo.ReadOnly = false;
            }
            else {
                cmbTipocessioneprestazione.Enabled = false;
                txtRiferimentoNormativo.ReadOnly = true;
            }

            if (Curr["idpccdebitmotive"] != DBNull.Value) {
                txtCausale.Text =
                    DS.pccdebitmotive.Select(QHC.CmpEq("idpccdebitmotive", Curr["idpccdebitmotive"]))[0]["description"].ToString();
            }
            else {
                txtCausale.Text = "";
            }
            enableDisableNaturadispesa();
            string filterLx = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind"]), QHS.CmpEq("yinv", Curr["yinv"]),
                QHS.CmpEq("ninv", Curr["ninv"]), QHS.CmpEq("rownum", Curr["rownum"]));
            if (!controller.InsertMode) {
                Conn.RUN_SELECT_INTO_TABLE(DS.invoicedetaildeferred, null,filterLx,null,false);
                //DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.invoicedetaildeferred, null, filterLx, null, true);
            }
            lastCodice = txtListino.Text;

        }


        public void MetaData_AfterClear() {
            abilitaTipoIVA(true);
            lastCodice = txtListino.Text;
        }

        


        //La funzione fornisce un filtro sui dettagli contratto passivo da selezionare
        public string getFilterForMandateDetail(DataRow Curr) {
            DataRow rInvoicedetail = Meta.SourceRow;
            DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
            object idreg = rInvoice["idreg"];
            string regfilter = QHS.CmpEq("idreg", idreg);
            object idinvkind = Curr["idinvkind"];
            string idinvkindfilter = QHS.CmpEq("idinvkind", idinvkind);
            string flagmixfilter = null;
            DataTable Reg = Conn.RUN_SELECT("invoicekindregisterkind", "*", null, idinvkindfilter, null, null, true);
            if ((Reg != null)&& (Reg.Rows.Count>0)) {
                foreach (DataRow RREg in Reg.Rows) {
                    string filterregkind = QHS.CmpEq("idivaregisterkind", RREg["idivaregisterkind"]);

                    DataTable RegKind = Conn.RUN_SELECT("ivaregisterkind", "*", null, filterregkind, null, null, true);
                    if (RegKind==null || (RegKind.Rows.Count == 0)) continue;
                    int flaga = CfgFn.GetNoNullInt32(RegKind.Rows[0]["flagactivity"]);
                    if (flaga == 1) {
                        //Filtra istituzionali o non importa
                        flagmixfilter = QHS.FieldIn("flagactivity", new object[] {1, 4});
                    }
                    if (flaga == 2) {
                        //Filtra commerciali  o non importa
                        flagmixfilter = QHS.FieldIn("flagactivity", new object[] {2, 4});
                    }
                    if (flaga == 3) {
                        // Filtro su promiscui in base a tipo fattura --> no, ora come gli altri
                        flagmixfilter = QHS.FieldIn("flagactivity", new object[] {3, 4});
                    }
                }
            }

            object idcurrency = rInvoice["idcurrency"];
            string filtercurrency = QHS.NullOrEq("idcurrency", idcurrency);                
            string filter = QHS.AppAnd(regfilter, flagmixfilter,
                            filtercurrency,
                            QHS.CmpNe("toinvoice", 'N'), 
                            QHS.CmpEq("linktoinvoice", 'S'),
                            QHS.CmpEq("idmandatestatus", 5) // stato approvato
                    );
            
            string filtercontab = null;
            string filtermandate = null;
            // Filtro contabilizzazione
            if ((Curr["idexp_taxable"] != DBNull.Value) || (Curr["idexp_iva"] != DBNull.Value)) {                
                if (Curr["idexp_taxable"] != DBNull.Value) {
                    object idExpFaseImpegno_taxable = Conn.DO_READ_VALUE("expenselink",
                        QHS.AppAnd(QHS.CmpEq("idchild", Curr["idexp_taxable"]),
                            QHS.CmpEq("nlevel", security.GetSys("mandatephase"))), "idparent");
                    filtercontab = QHS.AppAnd(filtercontab, QHS.CmpEq("idexp_taxable", idExpFaseImpegno_taxable));
                }

                if (Curr["idexp_iva"] != DBNull.Value) {
                    object idExpFaseImpegno_iva = Conn.DO_READ_VALUE("expenselink",
                        QHS.AppAnd(QHS.CmpEq("idchild", Curr["idexp_iva"]),
                            QHS.CmpEq("nlevel", security.GetSys("mandatephase"))), "idparent");
                    filtercontab = QHS.AppAnd(filtercontab, QHS.CmpEq("idexp_iva", idExpFaseImpegno_iva));
                }

                DataTable MandateDetail = Conn.RUN_SELECT("mandatedetail", "*", null, filtercontab, null, null, true);

                if ((MandateDetail != null) && (MandateDetail.Rows.Count > 0)) {
                    DataRow RExpMandate = MandateDetail.Rows[0];
                    filtermandate = QHS.AppAnd(QHS.CmpEq("idmankind", RExpMandate["idmankind"]),
                        QHS.CmpEq("yman", RExpMandate["yman"]),
                        QHS.CmpEq("nman", RExpMandate["nman"]));
                }
                else return "";
            }
            // Filtro quantità campo residual
            decimal number = CfgFn.GetNoNullDecimal(Curr["number"]);
            string filternumber = QHS.CmpGe("residual", number);

            filter = QHS.AppAnd(filter, filtermandate, filternumber);

            return filter;
        }


        //La funzione fornisce un filtro sui potenziali impegni di budget da selezionare
        public string getFilterForEpexp(DataRow Curr,int nphase) {
            string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", security.GetEsercizio()), QHS.CmpEq("nphase", nphase));

            if (nphase == 1) {
                Filterbase = QHS.AppAnd(Filterbase, QHS.CmpGt("totavailable", 0),
                    QHS.DoPar(QHS.AppOr(QHS.CmpEq("fixedassets", "S"), QHS.CmpEq("cost", "S"))));             
            }

            if (Curr["idmankind"] != DBNull.Value && CfgFn.GetNoNullInt32(Curr["yman"]) >= minimoAnnoImpegniDiBudget) {
                //Se la fattura è collegata a dettaglio C.P., prenderemo l'impegno di budget di quel dettaglio.
                string filterManDet = QHS.AppAnd(QHS.CmpEq("idmankind", Curr["idmankind"]), QHS.CmpEq("yman", Curr["yman"]),
                    QHS.CmpEq("nman", Curr["nman"]));
                DataTable MandateDetail = Conn.RUN_SELECT("mandatedetail", "idepexp", null, filterManDet, null, true);
                if (MandateDetail != null && MandateDetail.Rows.Count > 0) {
                    string listaImpegniBudgetProfservice = QHS.DistinctVal(MandateDetail.Select(), "idepexp");
                    string FilterImpBudget = QHS.FieldInList("idepexp", listaImpegniBudgetProfservice);
                    FilterImpBudget = QHS.AppAnd(Filterbase, FilterImpBudget);
                    return FilterImpBudget;
                }
            }

            //if (Curr["ycon"] != DBNull.Value && CfgFn.GetNoNullInt32(Curr["ycon"]) >= minimoAnnoImpegniDiBudget) {
            string filterInv = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind"]), QHS.CmpEq("yinv", Curr["yinv"]),
                QHS.CmpEq("ninv", Curr["ninv"]));
            DataTable ProfService = Conn.RUN_SELECT("profservice", "*", null, filterInv, null, true);

            // Fattura collegata a parcella professionale: restuisce gli Ix di budget della parcella, interrogando idrelated.
            DataRow rProfService;
            if (ProfService != null && ProfService.Rows.Count > 0) {
                rProfService = ProfService.Rows[0];
            }
            else {
                //prende la riga che sta in memoria
                DataRow rInvoicedetail = Meta.SourceRow;
                DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
                rProfService = rInvoice.GetParentRow("invoiceprofservice");
            }
            if (rProfService != null) {
                if (rProfService["ycon"] != DBNull.Value && CfgFn.GetNoNullInt32(rProfService["ycon"]) >= minimoAnnoImpegniDiBudget) {
                    string idrelated = BudgetFunction.GetIdForDocument(rProfService);
                    idrelated += "%";
                    string filterProfService = QHS.Like("idrelated", idrelated);
                    DataTable Epexp = Conn.RUN_SELECT("epexp", "idepexp", null, filterProfService, null, true);
                    string listaImpegniBudgetProfservice = QHS.DistinctVal(Epexp.Select(), "idepexp");

                    string filterIx = QHS.FieldInList("idepexp", listaImpegniBudgetProfservice);
                    filterIx = QHS.AppAnd(Filterbase, filterIx);
                    return filterIx;
                }
            }
           // }

            //La scelta va fatta solo sugli Impegni di Budget imputati a Conti di Costo e Immobilizzazioni
            Filterbase = QHS.AppAnd(Filterbase,
                QHS.DoPar(QHS.AppOr(QHS.CmpEq("cost", "S"), QHS.CmpEq("fixedassets", "S"),QHS.CmpEq("provision","S"))));

            if (NotaVariazione == false && !Vendita) {
                //La scelta va fatta solo sugli Impegni di Budget imputati a Conti con pari idacc del contesto corrente
                string filterCausale = QHS.AppAnd(QHS.CmpEq("ayear", security.GetEsercizio()),
                    QHS.CmpEq("idaccmotive", Curr["idaccmotive"]));
                // seleziona i conti associati alla casuale del dettaglio fattura
                DataTable Accmotivedetail = Conn.RUN_SELECT("accmotivedetail", "idacc", null, filterCausale, null,
                    true);
                if (Accmotivedetail != null && Accmotivedetail.Rows.Count > 0) {
                    string listaContiCompatibili = QHS.DistinctVal(Accmotivedetail.Select(), "idacc");
                    Filterbase = QHS.AppAnd(Filterbase, QHS.FieldInList("idacc", listaContiCompatibili));
                }
            }

            if (Curr["idupb"] != null && Curr["idupb"] != DBNull.Value) {
                Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("idupb", Curr["idupb"]));
            }

            return Filterbase;
        }


        //La funzione fornisce un filtro sui potenziali accertamenti di budget da selezionare
        public string getFilterForEpacc(DataRow Curr) {
            int nphase = 2; // Accertamento
            string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", security.GetEsercizio()), QHS.CmpEq("nphase", nphase));

            //Se la fattura è collegata a dettaglio C.A., prenderemo l'accertamento di budget di quel dettaglio.
            if (Curr["idestimkind"] != DBNull.Value && CfgFn.GetNoNullInt32(Curr["yestim"]) >= minimoAnnoImpegniDiBudget) {
                string filterEstimDet = QHS.AppAnd(QHS.CmpEq("idestimkind", Curr["idestimkind"]),
                QHS.CmpEq("yestim", Curr["yestim"]),
                QHS.CmpEq("nestim", Curr["nestim"]));
                DataTable estimatedetail = Conn.RUN_SELECT("estimatedetail", "idepacc", null, filterEstimDet, null, true);
                if (estimatedetail != null && estimatedetail.Rows.Count > 0) {
                    string listaAccertamentiBudget = QHS.DistinctVal(estimatedetail.Select(), "idepacc");
                    string FilterAccBudget = QHS.FieldInList("idepacc", listaAccertamentiBudget);
                    FilterAccBudget = QHS.AppAnd(Filterbase, FilterAccBudget);
                    return FilterAccBudget;
                }
            }
            //La scelta va fatta solo sugli Accertamenti di Budget imputati a Conti di Ricavi
            Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("revenue", "S"));

            if (NotaVariazione == false && Vendita) {
                //La scelta va fatta solo sugli Accertamenti di Budget imputati a Conti con pari idacc del contesto corrente
                string filterCausale = QHS.AppAnd(QHS.CmpEq("ayear", security.GetEsercizio()),
                    QHS.CmpEq("idaccmotive", Curr["idaccmotive"]));
                // seleziona i conti associati alla casuale del dettaglio fattura
                DataTable Accmotivedetail = Conn.RUN_SELECT("accmotivedetail", "idacc", null, filterCausale, null,
                    true);
                if (Accmotivedetail != null && Accmotivedetail.Rows.Count > 0) {
                    string listaContiCompatibili = QHS.DistinctVal(Accmotivedetail.Select(), "idacc");
                    Filterbase = QHS.AppAnd(Filterbase, QHS.FieldInList("idacc", listaContiCompatibili));
                }
            }

            if (Curr["idupb"] != null && Curr["idupb"] != DBNull.Value) {
                Filterbase = QHS.AppAnd(Filterbase, QHS.CmpEq("idupb", Curr["idupb"]));
            }
            return Filterbase;
        }

        public string getFilterForEstimateDetail(DataRow Curr) {
            DataRow rInvoicedetail = Meta.SourceRow;
            DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
            object idreg = rInvoice["idreg"];
            string regfilter = QHS.CmpEq("idreg", idreg);


            object idcurrency = rInvoice["idcurrency"];
            string filtercurrency = QHS.CmpEq("idcurrency", idcurrency);
            filtercurrency = QHS.DoPar(QHS.AppOr(filtercurrency, QHS.IsNull("idcurrency")));
            string filter = QHS.AppAnd(regfilter, filtercurrency);
            filter = QHS.AppAnd(filter, QHS.CmpNe("toinvoice", 'N'), QHS.CmpEq("linktoinvoice", 'S'));
            string filtercontab = null;
            string filterestimate = null;
            // Filtro contabilizzazione
            if ((Curr["idinc_taxable"] != DBNull.Value) || (Curr["idinc_iva"] != DBNull.Value)) {
                object idExpFaseAccertamento_taxable = Conn.DO_READ_VALUE("incomelink",
                    QHS.AppAnd(QHS.CmpEq("idchild", Curr["idinc_taxable"]),
                        QHS.CmpEq("nlevel", security.GetSys("estimatephase"))), "idparent");
                filtercontab = QHS.AppAnd(filtercontab, QHS.CmpEq("idinc_taxable", idExpFaseAccertamento_taxable));

                object idExpFaseAccertamento_iva = Conn.DO_READ_VALUE("incomelink",
                    QHS.AppAnd(QHS.CmpEq("idchild", Curr["idinc_iva"]),
                        QHS.CmpEq("nlevel", security.GetSys("estimatephase"))), "idparent");
                filtercontab = QHS.AppAnd(filtercontab, QHS.CmpEq("idinc_iva", idExpFaseAccertamento_iva));


                DataTable EstimateDetail = Conn.RUN_SELECT("estimatedetail", "*", null, filtercontab, null, null, true);

                if ((EstimateDetail != null) && (EstimateDetail.Rows.Count > 0)) {
                    DataRow RExpEstimate = EstimateDetail.Rows[0];
                    filterestimate = QHS.AppAnd(QHS.CmpEq("idestimkind", RExpEstimate["idestimkind"]),
                        QHS.CmpEq("yestim", RExpEstimate["yestim"]),
                        QHS.CmpEq("nestim", RExpEstimate["nestim"]));
                }
                else return "";
            }
            // Filtro quantità campo residual
            decimal number = CfgFn.GetNoNullDecimal(Curr["number"]);
            string filternumber = QHS.CmpGe("residual", number);

            filter = QHS.AppAnd(filter, filterestimate, filternumber);

            return filter;
        }

        private void btnLinkEpExp_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            MetaData.GetFormData(this, true);

            string FilterImpBudget = getFilterForEpexp(Curr,2);

            string VistaScelta = "epexpview";

            MetaData Mepexp = dispatcher.Get(VistaScelta);
            Mepexp.FilterLocked = true;
            Mepexp.DS = DS;
            DataRow MyDR = Mepexp.SelectOne("default", FilterImpBudget, null, null);

            if (MyDR != null) {
                Curr["idepexp"] = MyDR["idepexp"];
                Meta.FreshForm();
            }
        }

        private void btnRemoveEpExp_Click(object sender, EventArgs e) {
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["idepexp"] = DBNull.Value;
            DS.epexp.Clear();
            txtEsercIxBudget.Text = "";
            txtNumIxBudget.Text = "";
            Meta.FreshForm();
        }

        private void btnCollegaRiga_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr["idmankind"] != DBNull.Value) return;
            MetaData.GetFormData(this, true);

            string FilterMandateDetail = getFilterForMandateDetail(Curr);
            if (FilterMandateDetail == "") return;
            
            string VistaScelta ;
            DataRow rInvoicedetail = Meta.SourceRow;
            DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");

            bool HasDDT = (rInvoice["flag_ddt"].ToString() == "S");
            if (HasDDT) {
                VistaScelta = "mandatedetailstockedtoinvoice";
            }
            else {
                VistaScelta = "mandatedetailnoddttoinvoice";
            }

            MetaData MetaMandateDetail = dispatcher.Get(VistaScelta);
            if (MetaMandateDetail==null)return;
            MetaMandateDetail.FilterLocked = true;
            MetaMandateDetail.DS = DS;
            DataRow MyDR = MetaMandateDetail.SelectOne("default", FilterMandateDetail, null, null);

            if (MyDR != null) {
                Curr["idmankind"] = MyDR["idmankind"];
                Curr["yman"] = MyDR["yman"];
                Curr["nman"] = MyDR["nman"];
                Curr["manrownum"] = MyDR["rownum"];
                Curr["idepexp"] = MyDR["idepexp"];
                DS.mandatekind.Clear();
                Meta.FreshForm(true);
            }
        }

        private void btnCollegaRigaContratto_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            MetaData.GetFormData(this, true);

            string FilterEstimateDetail = getFilterForEstimateDetail(Curr);
            if (FilterEstimateDetail == "") return;
            //string FilterEstimateDetail = "";
            string VistaScelta = "estimatedetailtoinvoice";

            MetaData MetaEstimateDetail = dispatcher.Get(VistaScelta);
            MetaEstimateDetail.FilterLocked = true;
            MetaEstimateDetail.DS = DS;
            DataRow MyDR = MetaEstimateDetail.SelectOne("default", FilterEstimateDetail, null, null);

            if (MyDR != null) {
                Curr["idestimkind"] = MyDR["idestimkind"];
                Curr["yestim"] = MyDR["yestim"];
                Curr["nestim"] = MyDR["nestim"];
                Curr["estimrownum"] = MyDR["rownum"];
                Curr["idepacc"] = MyDR["idepacc"];
                DS.estimatekind.Clear();
                Meta.FreshForm(true);
            }
        }

        private void btnLinkEpAcc_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            MetaData.GetFormData(this, true);

            string FilterAccBudget = getFilterForEpacc(Curr);

            string VistaScelta = "epaccview";

            MetaData Mepacc = dispatcher.Get(VistaScelta);
            Mepacc.FilterLocked = true;
            Mepacc.DS = DS;
            DataRow MyDR = Mepacc.SelectOne("default", FilterAccBudget, null, null);

            if (MyDR != null) {
                Curr["idepacc"] = MyDR["idepacc"];
                Meta.FreshForm();
            }

        }

        private void btnRemoveEpAcc_Click(object sender, EventArgs e) {
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["idepacc"] = DBNull.Value;
            DS.epacc.Clear();
            txtEsercAxBudget.Text = "";
            txtNumAxBudget.Text = "";
            Meta.FreshForm();
        }

        private string lastCodice;

        private void txtListino_Enter(object sender, EventArgs e) {
            lastCodice = txtListino.Text;
            //QueryCreator.MarkEvent("imposto last " + lastCodice);
        }


        private void txtListino_Leave(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!controller.DrawStateIsDone) return;
            //QueryCreator.MarkEvent("leave last " + lastCodice+", valore = "+txtListino.Text);
            if (txtListino.Text == lastCodice) return;

            controller.GetFormData(true);
            if (txtListino.Text == "") {
                svuotaOggetti();
                adeguaQuantitaTotale();
                return;
            }
            if (DS.invoicedetail.Rows.Count == 0) return;
            if (!controller.DrawStateIsDone) return;

            string filter =
                QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", security.GetDataContabile())));
            if (AV.ToString() == "A") {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0
            }
            else {
                filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 2)); //bit 2: visibile nei c. attivi
            }
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));
            filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) {
                txtListino.Focus();
                lastCodice = null;
                return;
            }

            aggiornaListino(Choosen);
        }

        private void btnCollegaContrProf_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            //if (Curr["ycon"] != DBNull.Value) return;
            MetaData.GetFormData(this, true);
            DataRow rInvoicedetail = Meta.SourceRow;
            DataRow rInvoice = rInvoicedetail.GetParentRow("invoiceinvoicedetail");
            if (CfgFn.GetNoNullInt32(rInvoice["idreg"]) <= 0) {
                MessageBox.Show("Scegliere prima il fornitore");
                return;
            }
           
            string FilterProfService = QHS.AppAnd(QHS.CmpEq("idreg", rInvoice["idreg"]),
             QHS.CmpEq("flaginvoiced", 'N'), QHS.IsNull("idinvkind"));

            string FilterProfServiceOLD = QHS.CmpKey(rInvoice);

            if ((FilterProfService == "") && (FilterProfServiceOLD == "")) return;
           
            MetaData MetaProfService = dispatcher.Get("profservice");

            MetaProfService.FilterLocked = true;
            MetaProfService.DS = DS;
            DataRow MyDR = MetaProfService.SelectOne("default", QHS.AppOr(FilterProfService, FilterProfServiceOLD), null, null);

            if (MyDR != null) {          
                Curr["ycon"] = MyDR["ycon"];
                Curr["ncon"] = MyDR["ncon"];
                string filterCont = QHS.CmpKey(MyDR);
                DataTable TProfServiceCig = Conn.RUN_SELECT("profservicecig", "*", null, filterCont, null, true);
                if ((TProfServiceCig != null) && (TProfServiceCig.Rows.Count > 0)) {
                    if (MessageBox.Show(this,
                            "Aggiorno il CIG del dettaglio iva in base a quello usato nella parcella?",
                            "Avviso",
                            MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        MetaData MetaProfServiceCig = dispatcher.Get("profservicecig");
                        DataRow MyDRCig = MetaProfServiceCig.SelectOne("default", filterCont, null, null);
                        if (MyDRCig != null) {
                            Curr["cigcode"] = MyDRCig["cigcode"];
                        }
                    }
                }

                controller.FreshForm(true,false);
            }
        }

        private void btnScollegaContrProf_Click(object sender, EventArgs e) {
            DataRow Curr = DS.invoicedetail.Rows[0];
            Curr["ycon"] = DBNull.Value;
            Curr["ncon"] = DBNull.Value;
            Curr["idepexp"] = DBNull.Value; 
            //DS.profservice.Clear();
            Meta.FreshForm(false);
        }

        private void btnCollegaPreimpegno_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            DataRow Curr = DS.invoicedetail.Rows[0];
            MetaData.GetFormData(this, true);

            if (Curr["idmankind"] != DBNull.Value) {
                MessageBox.Show("Non è previsto associare un preimpegno a fatture collegate a contratti", "Avviso");
                return;
            }

            if (Curr["idepexp"] != DBNull.Value) {
                MessageBox.Show("Non è possibile scollegare un preimpegno avendo già generato l'impegno di budget",
                    "Errore");
                return;
            }

            string FilterImpBudget = getFilterForEpexp(Curr,1);

            string VistaScelta = "epexpview";

            MetaData Mepexp = dispatcher.Get(VistaScelta);
            Mepexp.FilterLocked = true;
            Mepexp.DS = DS;
            DataRow MyDR = Mepexp.SelectOne("default", FilterImpBudget, null, null);

            if (MyDR != null) {
                Curr["idepexp_pre"] = MyDR["idepexp"];
                Meta.FreshForm();
            }
        }

        private void btnScollegaPreimpegno_Click(object sender, EventArgs e) {
            if (controller.IsEmpty)return;
            MetaData.GetFormData(this, true);

            DataRow Curr = DS.invoicedetail.Rows[0];
            if (Curr["idepexp"] != DBNull.Value) {
                MessageBox.Show("Non è possibile scollegare un preimpegno avendo già generato l'impegno di budget",
                    "Errore");
                return;
            }

            Curr["idepexp_pre"] = DBNull.Value;
            DS.epexp_pre.Clear();
            txtPre_yepexp.Text = "";
            txtPre_nepexp.Text = "";
            Meta.FreshForm();
        }
    }
}
