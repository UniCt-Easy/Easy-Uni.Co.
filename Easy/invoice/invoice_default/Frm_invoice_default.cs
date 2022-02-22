
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
using funzioni_configurazione;//funzioni_configurazione
using metadatalibrary;
using System.Linq;
using System.Data;
using ep_functions;
using stockmail;
using System.Collections.Generic;
using manage_var;
using q = metadatalibrary.MetaExpression;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Security;
using System.Globalization;
using System.Text;

namespace invoice_default { //documentoiva//

    /// <summary>
    /// Summary description for frmdocumentoiva.
    /// </summary>
    public class Frm_invoice_default : MetaDataForm {
        public dsmeta DS;
        public DataSet D;
        private System.Windows.Forms.TextBox textBox12;
       
        private MetaData Meta;
        private string LastCodiceTipoDoc = "";
        private TabPage tabClassificazioni;
        private Button btnElimina;
        private Button btnModifica;
        private Button btnInserisci;
        private DataGrid dgrClassificazioni;
        private TabPage tabEP;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private TabPage tabLiquidazioni;
        private TextBox txtTotIvaLiquidata;
        private Label label22;
        private DataGrid dataGrid2;
        private TabPage tabRegistri;
        private DataGrid dataGrid1;
        private TabPage tabPageDettagli;
        private Button btnAggiungiDaContratti;
        private GroupBox gboxProfessionale;
        private Button btnCreaDaContratto;
        private TextBox txtTotale;
        private Label label16;
        private TextBox txtIndetraibile;
        private Label label14;
        private TextBox txtIva;
        private Label label17;
        private TextBox txtImponibile;
        private Label label18;
        private Button btnAggiungiDaOrdini;
        private Button buttonDetele;
        private Button buttonEdit;
        private Button buttonInsert;
        private DataGrid gridDettagli;
        private TabPage tabPrincipale;
        private CheckBox chkContabilizzabile;
        private TextBox txtDataContabile;
        private Label label11;
        private GroupBox groupBox6;
        private TextBox textBox10;
        private GroupBox gboxvaluta;
        private TextBox txtCambio;
        private Label label12;
        private GroupBox groupBox4;
        private TextBox txtDataDDT;
        private TextBox txtNumDDT;
        private Label label9;
        private Label label10;
        private GroupBox groupBox1;
        private ComboBox cmbTipoScadenza;
        private Label label8;
        private TextBox txtScadenza;
        private Label label7;
        private GroupBox gboxAnagrafica;
        private TextBox txtCredDeb;
        private GroupBox groupBox2;
        private TextBox txtDataDoc;
        private TextBox txtDocumento;
        private Label label4;
        private Label label5;
        private GroupBox frpDocumento;
        private Button btnTipo;
        private TextBox txtNumDocumento;
        private TextBox txtEsercDocumento;
        private ComboBox cboTipo;
        private Label label3;
        private Label label2;
        private CheckBox chb_IVADifferita;
        private TextBox textBox6;
        private Label label6;
        private TabControl tabControl1;
        private GroupBox grpTesorierePerIncasso;
        private ComboBox cmbCodiceIstituto;
        private TabPage tabIntrastat;
        private GroupBox gboxIntraInfoBeni;
        private Label label19;
        private Label label15;
        private Label label1;
        private GroupBox gboxintra_vendite;
        private Label label20;
        private Label label21;
        private GroupBox gboxintra_acquisti;
        private ComboBox cmb_natura;
        private ComboBox cmb_provorigine;
        private ComboBox cmb_isodestinazione;
        private ComboBox cmb_provdestinazione;
        private ComboBox cmb_isoprovenienza;
        private ComboBox cmb_isoorigine;
        private Label label30;
        private Label label28;
        private Label label29;
        private Label label27;
        private Label label26;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox2;
        private TextBox textBox5;
        private GroupBox gboxNatura;
        private Button button4;
        private TextBox txtDescrUPB;
        private Label labDataCrgCausale;
        private TextBox textBox7;
        private GroupBox gboxCausaleCrg;
        private TextBox txtDescrCausaleCrg;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox gboxCausale;
        private TextBox TxtDescrCausaleDeb;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private GroupBox gboxIntraInfoServizi;
        private ComboBox cmbModpagamento;
        private Label label25;
        private TextBox textBox13;
        private Label label31;
        private ComboBox cmb_isopagamento;
        private Label label32;
        private Button btnContabilizzazioni;
        private CheckBox chkflag_ddt;
        private Button btnBolletta;
        private TabPage tabMagazzino;
        private Label label33;
        private DataGrid gridStock;
        private Button btnModificaStock;
        private DataAccess Conn;
        private TabPage tabAltro;
        private GroupBox grpComunicazioneBlackList;
        private TextBox txtBlCode;
        private ComboBox cmb_BlackList;
        private RadioButton rdbNonEffettuare;
        private RadioButton rdbEffettuare;
        private RadioButton rdbNonSpec;
        private GroupBox gboxtipofattura;
        private RadioButton rdbextracom;
        private RadioButton rdbintracom;
        private RadioButton rdbitalia;
        private Label lblSoggettiUENonresidenti;
        private CheckBox chkAutoFattura;
        private Button btnAutoFattura;
        private TabPage tabPageAutofattura;
        private GroupBox grpInvReal;
        private TextBox txtNinvReal;
        private Label label34;
        private TextBox txtYinvReal;
        private Label label35;
        private DataGrid dgDettagliFattura;
        private TextBox txtTotaleAuto;
        private Label label36;
        private TextBox txtIndetraibileAuto;
        private Label label37;
        private TextBox txtIvaAuto;
        private Label label38;
        private TextBox txtImponibileAuto;
        private Label label39;
        private Label label40;
        private ComboBox cmbTipoFatturaMadre;
        private Button btnVisualizzaFattMadre;
        private TabPage tabAttributi;
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
        private Button btnValuta;
        public TextBox txtValuta;
        private TextBox txtProtocolDate;
        private Label lblProtocolDate;
        private Label label42;
        private TextBox txtDataScadenza;
        private TabPage tabRegistroUnico;
        private GroupBox grpRegistroUnico;
        private TextBox txtProgressivoRU;
        private Label label45;
        private Label label13;
        private TextBox txtProtocolloEntrataRU;
        private TextBox txtAnnotazioniRU;
        private Label label44;
        private Button btnCreaRegistroUnico;
        private CheckBox chkIncludeInPaymentIndicator;
        private CheckBox checkBox1;
        private DataGrid dgrPCC;
        private Label label46;
        private CheckBox chkProtocollanelRU;
        private Button btnAnnullaFattura;
        private TextBox textBox8;
        private Button btnRipartizione;
        private Button btnModStatodelDebito;
        private TabPage tabAllegati;
        private DataGrid dataGrid3;
        private Button btnDelAtt;
        private Button btnEditAtt;
        private Button btnInsAtt;
        private GroupBox grp_Split_Payment;
        private CheckBox chk_auto_split_payment;
        private CheckBox chk_enable_split_payment;
        private CheckBox chk_enable_reverse_charge;
        private Button btnVisualizzaPreimpegni;
        private Button btnGeneraPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private Button btnCopiaUPBeCausaleEP;
        private Button btnUnisciDettagli;
        private Button btnDividiDettaglio;
        private TabPage tabTesseraSSN;
        private GroupBox gboxTesseraSSN;
        private RadioButton radioButton2;
        private RadioButton rdbTicket;
        private Label label53;
        private RadioButton radioButton10;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private RadioButton rdbSpesePrestazioni;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private CheckBox chkFatturaSpedizioniere;
        private CheckBox chkBollaDoganale;
        private Button btnInserisciBollettaDoganale;
        private GroupBox grpInvSpedizioniere;
        private Label label54;
        private ComboBox cmbInvKindSpedizioniere;
        private TextBox txtNinv_Spedizioniere;
        private Label label55;
        private TextBox txtYinv_Spedizioniere;
        private Label label56;
        private Label label57;
        private GroupBox gboxBolleDoganali;
        private Button btnRemoveBollaDoganale;
        private DataGrid dgrBolleDoganali;
        private ContextMenu CMenu;
        private MenuItem MenuEnterPwd;
        private CheckBox chkTicket;
        private CheckBox chkIntraMoenia;
        private Button btnCollegaCarichiCespite;
        private Label label58;
        private DataGrid dgrCarichiCespite;
        private DataGrid dataGrid4;
        private CheckBox chkEscludiInvio;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkDurc;
        private CheckBox chkVisura;
        private CheckBox chkCCdedicato;
        private GroupBox groupBox11;
        private TextBox txtNocigmotive;
        private Button btnEsclusioneCIG;
        private CheckBox chkRecuperoIvaIntraExtra;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkVerificaAnac;
		private CheckBox chkCasellarioGiud;
		private CheckBox chkRegolaritaFisc;
		private TabPage tabFE;
		private TabControl tabControl2;
		private TabPage tabPage2;
		private GroupBox groupBox17;
		private GroupBox gboxBollo;
		private RadioButton rdbNoBollo;
		private RadioButton rdb19_2014;
		private GroupBox groupBox5;
		private ComboBox cmbCondizioniPagFE;
		private GroupBox groupBox7;
		private ComboBox cmbModPagFE;
		private GroupBox groupBox8;
		private TextBox txtEsercTrasmissioneFE;
		private Label label41;
		private Label label43;
		private TextBox txtNumTrasmissioneFE;
		private GroupBox grpLegaleRappresentante;
		private TextBox txtLegaleRappresentante;
		private GroupBox grpDestinatarioVendita;
		private TextBox txtPECFECliente;
		private Label label23;
		private TextBox txtEmailFECliente;
		private Label label24;
		private Label label48;
		private TextBox txtRifamm_ven_cliente;
		private Label label47;
		private TextBox txtIpa_ven_cliente;
		private GroupBox grpMittenteVendita;
		private GroupBox grpRifAmmMittenteVendita;
		private Button button3;
		private TextBox txtRifamm_ven_emittente;
		private GroupBox grpIPAMittenteVendita;
		private Button button5;
		private TextBox txtIpa_ven_emittente;
		private GroupBox grpDestinatarioAcquisto;
		private TextBox txtIpa_acq;
		private Label label51;
		private Label label52;
		private TextBox txtRifamm_acq;
		private TabPage tabPage3;
		private Button btnInviaSdI;
		private Button btnCheck;
		private GroupBox grpSdIAcqEstere;
		private GroupBox groupBox13;
		private ComboBox comboStatoTrasmSdiAcqEstere;
		private GroupBox groupBox14;
		private CheckBox checkBox3;
		private CheckBox checkBox4;
		private CheckBox checkBox6;
		private GroupBox groupBox15;
		private ComboBox comboStatusAcqEstere;
		private GroupBox groupBox16;
		private Label label59;
		private TextBox textBox11;
		private GroupBox grpSDI_vendita;
		private GroupBox grpStatoTrasmissione;
		private ComboBox cmbStatoTrasmissioneSdiVen;
		private GroupBox groupBox10;
		private CheckBox chkAT_attestazione;
		private CheckBox chkRC_ricevutaconsegna;
		private CheckBox chkNE_esitocedente;
		private CheckBox chkNS_notificascarto;
		private CheckBox checkBox2;
		private CheckBox chkMC_mancataconsegna;
		private GroupBox groupBox9;
		private ComboBox cmbStatusVendita;
		private GroupBox groupBox3;
		private Label label50;
		private TextBox textBox9;
		private GroupBox grpSDI_acquisto;
		private GroupBox gboxStatoSdi;
		private ComboBox cmbStatusAcquito;
		private GroupBox grpIdSsi;
		private Label label49;
		private TextBox txtNumFile;
		private GroupBox grpMessaggi;
		private CheckBox chkDT_decorrenzatermini;
		private CheckBox chkSE_scartoesitocommittente;
		private GroupBox groupBox18;
		private GroupBox grpFEAcquistoEstere;
		private ComboBox cmbDenominazione;
		private ComboBox cmbDocumentKind;
		private GroupBox grpDenominazione;
		private GroupBox grpDocumentKind;
		private bool skipAfterFill = false;

        public Frm_invoice_default() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.invoice.Columns["flagdeferred"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["touniqueregister"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flag_enable_split_payment"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flag_auto_split_payment"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flag_reverse_charge"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flagbit"], true);
            DataAccess.SetTableForReading(DS.ipa_ven_emittente, "ipa");
            DataAccess.SetTableForReading(DS.rifamm_ven_emittente, "sdi_rifamm");
            DataAccess.SetTableForReading(DS.treasurer_acq_estere, "treasurer");
            DataAccess.SetTableForReading(DS.sdi_deliverystatus_acquestere, "sdi_deliverystatus");
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            MetaData.messageBroadcaster -= MetaData_messageBroadcaster;
            if (disposing) {
             
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_invoice_default));
			this.DS = new invoice_default.dsmeta();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.tabClassificazioni = new System.Windows.Forms.TabPage();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.dgrClassificazioni = new System.Windows.Forms.DataGrid();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.labDataCrgCausale = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.gboxCausaleCrg = new System.Windows.Forms.GroupBox();
			this.txtDescrCausaleCrg = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.gboxCausale = new System.Windows.Forms.GroupBox();
			this.TxtDescrCausaleDeb = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.tabLiquidazioni = new System.Windows.Forms.TabPage();
			this.txtTotIvaLiquidata = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tabRegistri = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.tabPageDettagli = new System.Windows.Forms.TabPage();
			this.btnCollegaCarichiCespite = new System.Windows.Forms.Button();
			this.btnUnisciDettagli = new System.Windows.Forms.Button();
			this.btnDividiDettaglio = new System.Windows.Forms.Button();
			this.btnCopiaUPBeCausaleEP = new System.Windows.Forms.Button();
			this.btnRipartizione = new System.Windows.Forms.Button();
			this.btnBolletta = new System.Windows.Forms.Button();
			this.btnContabilizzazioni = new System.Windows.Forms.Button();
			this.btnAggiungiDaContratti = new System.Windows.Forms.Button();
			this.gboxProfessionale = new System.Windows.Forms.GroupBox();
			this.dataGrid4 = new System.Windows.Forms.DataGrid();
			this.btnCreaDaContratto = new System.Windows.Forms.Button();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtIndetraibile = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtImponibile = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.btnAggiungiDaOrdini = new System.Windows.Forms.Button();
			this.buttonDetele = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonInsert = new System.Windows.Forms.Button();
			this.gridDettagli = new System.Windows.Forms.DataGrid();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.chkEscludiInvio = new System.Windows.Forms.CheckBox();
			this.grpInvSpedizioniere = new System.Windows.Forms.GroupBox();
			this.label54 = new System.Windows.Forms.Label();
			this.cmbInvKindSpedizioniere = new System.Windows.Forms.ComboBox();
			this.txtNinv_Spedizioniere = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txtYinv_Spedizioniere = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.btnInserisciBollettaDoganale = new System.Windows.Forms.Button();
			this.chkFatturaSpedizioniere = new System.Windows.Forms.CheckBox();
			this.chkBollaDoganale = new System.Windows.Forms.CheckBox();
			this.grp_Split_Payment = new System.Windows.Forms.GroupBox();
			this.chk_enable_reverse_charge = new System.Windows.Forms.CheckBox();
			this.chk_auto_split_payment = new System.Windows.Forms.CheckBox();
			this.chk_enable_split_payment = new System.Windows.Forms.CheckBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.btnAnnullaFattura = new System.Windows.Forms.Button();
			this.chkProtocollanelRU = new System.Windows.Forms.CheckBox();
			this.chkIncludeInPaymentIndicator = new System.Windows.Forms.CheckBox();
			this.txtProtocolDate = new System.Windows.Forms.TextBox();
			this.lblProtocolDate = new System.Windows.Forms.Label();
			this.btnAutoFattura = new System.Windows.Forms.Button();
			this.chkAutoFattura = new System.Windows.Forms.CheckBox();
			this.chkflag_ddt = new System.Windows.Forms.CheckBox();
			this.grpTesorierePerIncasso = new System.Windows.Forms.GroupBox();
			this.cmbCodiceIstituto = new System.Windows.Forms.ComboBox();
			this.chkContabilizzabile = new System.Windows.Forms.CheckBox();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.gboxvaluta = new System.Windows.Forms.GroupBox();
			this.btnValuta = new System.Windows.Forms.Button();
			this.txtValuta = new System.Windows.Forms.TextBox();
			this.txtCambio = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.txtDataDDT = new System.Windows.Forms.TextBox();
			this.txtNumDDT = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label42 = new System.Windows.Forms.Label();
			this.txtDataScadenza = new System.Windows.Forms.TextBox();
			this.cmbTipoScadenza = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.gboxAnagrafica = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.frpDocumento = new System.Windows.Forms.GroupBox();
			this.btnTipo = new System.Windows.Forms.Button();
			this.txtNumDocumento = new System.Windows.Forms.TextBox();
			this.txtEsercDocumento = new System.Windows.Forms.TextBox();
			this.cboTipo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chb_IVADifferita = new System.Windows.Forms.CheckBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFisc = new System.Windows.Forms.CheckBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabIntrastat = new System.Windows.Forms.TabPage();
			this.chkRecuperoIvaIntraExtra = new System.Windows.Forms.CheckBox();
			this.gboxtipofattura = new System.Windows.Forms.GroupBox();
			this.lblSoggettiUENonresidenti = new System.Windows.Forms.Label();
			this.rdbextracom = new System.Windows.Forms.RadioButton();
			this.rdbintracom = new System.Windows.Forms.RadioButton();
			this.rdbitalia = new System.Windows.Forms.RadioButton();
			this.gboxIntraInfoServizi = new System.Windows.Forms.GroupBox();
			this.cmbModpagamento = new System.Windows.Forms.ComboBox();
			this.label25 = new System.Windows.Forms.Label();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.cmb_isopagamento = new System.Windows.Forms.ComboBox();
			this.label32 = new System.Windows.Forms.Label();
			this.gboxIntraInfoBeni = new System.Windows.Forms.GroupBox();
			this.gboxNatura = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.cmb_natura = new System.Windows.Forms.ComboBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.gboxintra_vendite = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.cmb_provorigine = new System.Windows.Forms.ComboBox();
			this.cmb_isodestinazione = new System.Windows.Forms.ComboBox();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.gboxintra_acquisti = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.cmb_provdestinazione = new System.Windows.Forms.ComboBox();
			this.cmb_isoprovenienza = new System.Windows.Forms.ComboBox();
			this.cmb_isoorigine = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.tabMagazzino = new System.Windows.Forms.TabPage();
			this.btnModificaStock = new System.Windows.Forms.Button();
			this.label33 = new System.Windows.Forms.Label();
			this.gridStock = new System.Windows.Forms.DataGrid();
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
			this.tabPageAutofattura = new System.Windows.Forms.TabPage();
			this.txtTotaleAuto = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.txtIndetraibileAuto = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.txtIvaAuto = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.txtImponibileAuto = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.grpInvReal = new System.Windows.Forms.GroupBox();
			this.btnVisualizzaFattMadre = new System.Windows.Forms.Button();
			this.label40 = new System.Windows.Forms.Label();
			this.cmbTipoFatturaMadre = new System.Windows.Forms.ComboBox();
			this.txtNinvReal = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.txtYinvReal = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.dgDettagliFattura = new System.Windows.Forms.DataGrid();
			this.tabFE = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpFEAcquistoEstere = new System.Windows.Forms.GroupBox();
			this.grpDenominazione = new System.Windows.Forms.GroupBox();
			this.cmbDenominazione = new System.Windows.Forms.ComboBox();
			this.grpDocumentKind = new System.Windows.Forms.GroupBox();
			this.cmbDocumentKind = new System.Windows.Forms.ComboBox();
			this.groupBox17 = new System.Windows.Forms.GroupBox();
			this.gboxBollo = new System.Windows.Forms.GroupBox();
			this.rdbNoBollo = new System.Windows.Forms.RadioButton();
			this.rdb19_2014 = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.cmbCondizioniPagFE = new System.Windows.Forms.ComboBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.cmbModPagFE = new System.Windows.Forms.ComboBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.txtEsercTrasmissioneFE = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.txtNumTrasmissioneFE = new System.Windows.Forms.TextBox();
			this.grpLegaleRappresentante = new System.Windows.Forms.GroupBox();
			this.txtLegaleRappresentante = new System.Windows.Forms.TextBox();
			this.grpDestinatarioVendita = new System.Windows.Forms.GroupBox();
			this.txtPECFECliente = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtEmailFECliente = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.txtRifamm_ven_cliente = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.txtIpa_ven_cliente = new System.Windows.Forms.TextBox();
			this.grpMittenteVendita = new System.Windows.Forms.GroupBox();
			this.grpRifAmmMittenteVendita = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.txtRifamm_ven_emittente = new System.Windows.Forms.TextBox();
			this.grpIPAMittenteVendita = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.txtIpa_ven_emittente = new System.Windows.Forms.TextBox();
			this.grpDestinatarioAcquisto = new System.Windows.Forms.GroupBox();
			this.txtIpa_acq = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.txtRifamm_acq = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox18 = new System.Windows.Forms.GroupBox();
			this.btnCheck = new System.Windows.Forms.Button();
			this.btnInviaSdI = new System.Windows.Forms.Button();
			this.grpSdIAcqEstere = new System.Windows.Forms.GroupBox();
			this.groupBox13 = new System.Windows.Forms.GroupBox();
			this.comboStatoTrasmSdiAcqEstere = new System.Windows.Forms.ComboBox();
			this.groupBox14 = new System.Windows.Forms.GroupBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.groupBox15 = new System.Windows.Forms.GroupBox();
			this.comboStatusAcqEstere = new System.Windows.Forms.ComboBox();
			this.groupBox16 = new System.Windows.Forms.GroupBox();
			this.label59 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.grpSDI_vendita = new System.Windows.Forms.GroupBox();
			this.grpStatoTrasmissione = new System.Windows.Forms.GroupBox();
			this.cmbStatoTrasmissioneSdiVen = new System.Windows.Forms.ComboBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.chkAT_attestazione = new System.Windows.Forms.CheckBox();
			this.chkRC_ricevutaconsegna = new System.Windows.Forms.CheckBox();
			this.chkNE_esitocedente = new System.Windows.Forms.CheckBox();
			this.chkNS_notificascarto = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.chkMC_mancataconsegna = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.cmbStatusVendita = new System.Windows.Forms.ComboBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label50 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.grpSDI_acquisto = new System.Windows.Forms.GroupBox();
			this.gboxStatoSdi = new System.Windows.Forms.GroupBox();
			this.cmbStatusAcquito = new System.Windows.Forms.ComboBox();
			this.grpIdSsi = new System.Windows.Forms.GroupBox();
			this.label49 = new System.Windows.Forms.Label();
			this.txtNumFile = new System.Windows.Forms.TextBox();
			this.grpMessaggi = new System.Windows.Forms.GroupBox();
			this.chkDT_decorrenzatermini = new System.Windows.Forms.CheckBox();
			this.chkSE_scartoesitocommittente = new System.Windows.Forms.CheckBox();
			this.tabRegistroUnico = new System.Windows.Forms.TabPage();
			this.label46 = new System.Windows.Forms.Label();
			this.dgrPCC = new System.Windows.Forms.DataGrid();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.grpRegistroUnico = new System.Windows.Forms.GroupBox();
			this.btnModStatodelDebito = new System.Windows.Forms.Button();
			this.btnCreaRegistroUnico = new System.Windows.Forms.Button();
			this.txtProgressivoRU = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.txtProtocolloEntrataRU = new System.Windows.Forms.TextBox();
			this.txtAnnotazioniRU = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.tabAllegati = new System.Windows.Forms.TabPage();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.tabTesseraSSN = new System.Windows.Forms.TabPage();
			this.label53 = new System.Windows.Forms.Label();
			this.gboxTesseraSSN = new System.Windows.Forms.GroupBox();
			this.chkIntraMoenia = new System.Windows.Forms.CheckBox();
			this.chkTicket = new System.Windows.Forms.CheckBox();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.rdbSpesePrestazioni = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.rdbTicket = new System.Windows.Forms.RadioButton();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.txtNocigmotive = new System.Windows.Forms.TextBox();
			this.btnEsclusioneCIG = new System.Windows.Forms.Button();
			this.label58 = new System.Windows.Forms.Label();
			this.dgrCarichiCespite = new System.Windows.Forms.DataGrid();
			this.gboxBolleDoganali = new System.Windows.Forms.GroupBox();
			this.btnRemoveBollaDoganale = new System.Windows.Forms.Button();
			this.dgrBolleDoganali = new System.Windows.Forms.DataGrid();
			this.grpComunicazioneBlackList = new System.Windows.Forms.GroupBox();
			this.label57 = new System.Windows.Forms.Label();
			this.txtBlCode = new System.Windows.Forms.TextBox();
			this.cmb_BlackList = new System.Windows.Forms.ComboBox();
			this.rdbNonEffettuare = new System.Windows.Forms.RadioButton();
			this.rdbEffettuare = new System.Windows.Forms.RadioButton();
			this.rdbNonSpec = new System.Windows.Forms.RadioButton();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabClassificazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).BeginInit();
			this.tabEP.SuspendLayout();
			this.gboxCausaleCrg.SuspendLayout();
			this.gboxCausale.SuspendLayout();
			this.tabLiquidazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.tabRegistri.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPageDettagli.SuspendLayout();
			this.gboxProfessionale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
			this.tabPrincipale.SuspendLayout();
			this.grpInvSpedizioniere.SuspendLayout();
			this.grp_Split_Payment.SuspendLayout();
			this.grpTesorierePerIncasso.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.gboxvaluta.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gboxAnagrafica.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.frpDocumento.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabIntrastat.SuspendLayout();
			this.gboxtipofattura.SuspendLayout();
			this.gboxIntraInfoServizi.SuspendLayout();
			this.gboxIntraInfoBeni.SuspendLayout();
			this.gboxNatura.SuspendLayout();
			this.gboxintra_vendite.SuspendLayout();
			this.gboxintra_acquisti.SuspendLayout();
			this.tabMagazzino.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabPageAutofattura.SuspendLayout();
			this.grpInvReal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDettagliFattura)).BeginInit();
			this.tabFE.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpFEAcquistoEstere.SuspendLayout();
			this.grpDenominazione.SuspendLayout();
			this.grpDocumentKind.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.gboxBollo.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.grpLegaleRappresentante.SuspendLayout();
			this.grpDestinatarioVendita.SuspendLayout();
			this.grpMittenteVendita.SuspendLayout();
			this.grpRifAmmMittenteVendita.SuspendLayout();
			this.grpIPAMittenteVendita.SuspendLayout();
			this.grpDestinatarioAcquisto.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.grpSdIAcqEstere.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.grpSDI_vendita.SuspendLayout();
			this.grpStatoTrasmissione.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpSDI_acquisto.SuspendLayout();
			this.gboxStatoSdi.SuspendLayout();
			this.grpIdSsi.SuspendLayout();
			this.grpMessaggi.SuspendLayout();
			this.tabRegistroUnico.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).BeginInit();
			this.grpRegistroUnico.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabTesseraSSN.SuspendLayout();
			this.gboxTesseraSSN.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.groupBox11.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrCarichiCespite)).BeginInit();
			this.gboxBolleDoganali.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrBolleDoganali)).BeginInit();
			this.grpComunicazioneBlackList.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(0, 0);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(100, 20);
			this.textBox12.TabIndex = 0;
			// 
			// tabClassificazioni
			// 
			this.tabClassificazioni.Controls.Add(this.btnElimina);
			this.tabClassificazioni.Controls.Add(this.btnModifica);
			this.tabClassificazioni.Controls.Add(this.btnInserisci);
			this.tabClassificazioni.Controls.Add(this.dgrClassificazioni);
			this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
			this.tabClassificazioni.Name = "tabClassificazioni";
			this.tabClassificazioni.Size = new System.Drawing.Size(981, 478);
			this.tabClassificazioni.TabIndex = 5;
			this.tabClassificazioni.Text = "Classificazioni";
			this.tabClassificazioni.UseVisualStyleBackColor = true;
			// 
			// btnElimina
			// 
			this.btnElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnElimina.Location = new System.Drawing.Point(875, 16);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(68, 22);
			this.btnElimina.TabIndex = 11;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			// 
			// btnModifica
			// 
			this.btnModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnModifica.Location = new System.Drawing.Point(795, 16);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(69, 22);
			this.btnModifica.TabIndex = 10;
			this.btnModifica.Tag = "edit.default";
			this.btnModifica.Text = "Modifica...";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInserisci.Location = new System.Drawing.Point(715, 16);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnInserisci.TabIndex = 9;
			this.btnInserisci.Tag = "insert.default";
			this.btnInserisci.Text = "Inserisci...";
			// 
			// dgrClassificazioni
			// 
			this.dgrClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassificazioni.DataMember = "";
			this.dgrClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassificazioni.Location = new System.Drawing.Point(16, 48);
			this.dgrClassificazioni.Name = "dgrClassificazioni";
			this.dgrClassificazioni.ReadOnly = true;
			this.dgrClassificazioni.Size = new System.Drawing.Size(927, 409);
			this.dgrClassificazioni.TabIndex = 0;
			this.dgrClassificazioni.Tag = "invoicesorting.default.default";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.btnVisualizzaPreimpegni);
			this.tabEP.Controls.Add(this.btnGeneraPreimpegni);
			this.tabEP.Controls.Add(this.btnGeneraEpExp);
			this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabEP.Controls.Add(this.labDataCrgCausale);
			this.tabEP.Controls.Add(this.textBox7);
			this.tabEP.Controls.Add(this.gboxCausaleCrg);
			this.tabEP.Controls.Add(this.gboxCausale);
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(981, 478);
			this.tabEP.TabIndex = 6;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// btnVisualizzaPreimpegni
			// 
			this.btnVisualizzaPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(739, 40);
			this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
			this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(212, 23);
			this.btnVisualizzaPreimpegni.TabIndex = 46;
			this.btnVisualizzaPreimpegni.TabStop = false;
			this.btnVisualizzaPreimpegni.Text = "Visualizza Preimpegni di Budget";
			// 
			// btnGeneraPreimpegni
			// 
			this.btnGeneraPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGeneraPreimpegni.Location = new System.Drawing.Point(739, 11);
			this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
			this.btnGeneraPreimpegni.Size = new System.Drawing.Size(212, 23);
			this.btnGeneraPreimpegni.TabIndex = 45;
			this.btnGeneraPreimpegni.TabStop = false;
			this.btnGeneraPreimpegni.Text = "Genera Preimpegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGeneraEpExp.Location = new System.Drawing.Point(565, 11);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(168, 23);
			this.btnGeneraEpExp.TabIndex = 43;
			this.btnGeneraEpExp.TabStop = false;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(565, 40);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(168, 23);
			this.btnVisualizzaEpExp.TabIndex = 44;
			this.btnVisualizzaEpExp.TabStop = false;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// labDataCrgCausale
			// 
			this.labDataCrgCausale.Location = new System.Drawing.Point(343, 85);
			this.labDataCrgCausale.Name = "labDataCrgCausale";
			this.labDataCrgCausale.Size = new System.Drawing.Size(265, 16);
			this.labDataCrgCausale.TabIndex = 16;
			this.labDataCrgCausale.Text = "Data correzione causale di debito";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(342, 104);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(134, 20);
			this.textBox7.TabIndex = 4;
			this.textBox7.Tag = "invoice.idaccmotivedebit_datacrg?invoiceview.idaccmotivedebit_datacrg";
			// 
			// gboxCausaleCrg
			// 
			this.gboxCausaleCrg.Controls.Add(this.txtDescrCausaleCrg);
			this.gboxCausaleCrg.Controls.Add(this.txtCodiceCausaleCrg);
			this.gboxCausaleCrg.Controls.Add(this.button7);
			this.gboxCausaleCrg.Location = new System.Drawing.Point(342, 130);
			this.gboxCausaleCrg.Name = "gboxCausaleCrg";
			this.gboxCausaleCrg.Size = new System.Drawing.Size(328, 104);
			this.gboxCausaleCrg.TabIndex = 6;
			this.gboxCausaleCrg.TabStop = false;
			this.gboxCausaleCrg.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
			this.gboxCausaleCrg.Text = "Causale di debito aggiornata";
			this.gboxCausaleCrg.UseCompatibleTextRendering = true;
			// 
			// txtDescrCausaleCrg
			// 
			this.txtDescrCausaleCrg.Location = new System.Drawing.Point(120, 16);
			this.txtDescrCausaleCrg.Multiline = true;
			this.txtDescrCausaleCrg.Name = "txtDescrCausaleCrg";
			this.txtDescrCausaleCrg.ReadOnly = true;
			this.txtDescrCausaleCrg.Size = new System.Drawing.Size(200, 56);
			this.txtDescrCausaleCrg.TabIndex = 2;
			this.txtDescrCausaleCrg.TabStop = false;
			this.txtDescrCausaleCrg.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(6, 78);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(314, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?invoiceview.codemotivedebit_crg";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(6, 45);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(104, 23);
			this.button7.TabIndex = 0;
			this.button7.Tag = "manage.accmotiveapplied_crg.tree";
			this.button7.Text = "Causale";
			// 
			// gboxCausale
			// 
			this.gboxCausale.Controls.Add(this.TxtDescrCausaleDeb);
			this.gboxCausale.Controls.Add(this.txtCodiceCausaleDeb);
			this.gboxCausale.Controls.Add(this.button6);
			this.gboxCausale.Location = new System.Drawing.Point(8, 130);
			this.gboxCausale.Name = "gboxCausale";
			this.gboxCausale.Size = new System.Drawing.Size(328, 104);
			this.gboxCausale.TabIndex = 5;
			this.gboxCausale.TabStop = false;
			this.gboxCausale.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gboxCausale.Text = "Causale di debito";
			this.gboxCausale.UseCompatibleTextRendering = true;
			// 
			// TxtDescrCausaleDeb
			// 
			this.TxtDescrCausaleDeb.Location = new System.Drawing.Point(120, 16);
			this.TxtDescrCausaleDeb.Multiline = true;
			this.TxtDescrCausaleDeb.Name = "TxtDescrCausaleDeb";
			this.TxtDescrCausaleDeb.ReadOnly = true;
			this.TxtDescrCausaleDeb.Size = new System.Drawing.Size(200, 56);
			this.TxtDescrCausaleDeb.TabIndex = 2;
			this.TxtDescrCausaleDeb.TabStop = false;
			this.TxtDescrCausaleDeb.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(8, 78);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(312, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?invoiceview.codemotivedebit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(10, 45);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(104, 23);
			this.button6.TabIndex = 0;
			this.button6.Tag = "manage.accmotiveapplied_debit.tree";
			this.button6.Text = "Causale";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(311, 40);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
			this.btnGeneraEP.TabIndex = 3;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia.";
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(309, 11);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
			this.btnVisualizzaEP.TabIndex = 2;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			// 
			// labEP
			// 
			this.labEP.Location = new System.Drawing.Point(8, 11);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(297, 18);
			this.labEP.TabIndex = 0;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// tabLiquidazioni
			// 
			this.tabLiquidazioni.Controls.Add(this.txtTotIvaLiquidata);
			this.tabLiquidazioni.Controls.Add(this.label22);
			this.tabLiquidazioni.Controls.Add(this.dataGrid2);
			this.tabLiquidazioni.Location = new System.Drawing.Point(4, 22);
			this.tabLiquidazioni.Name = "tabLiquidazioni";
			this.tabLiquidazioni.Size = new System.Drawing.Size(981, 478);
			this.tabLiquidazioni.TabIndex = 4;
			this.tabLiquidazioni.Text = "Liq. IVA";
			this.tabLiquidazioni.UseVisualStyleBackColor = true;
			// 
			// txtTotIvaLiquidata
			// 
			this.txtTotIvaLiquidata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotIvaLiquidata.Location = new System.Drawing.Point(120, 8);
			this.txtTotIvaLiquidata.Name = "txtTotIvaLiquidata";
			this.txtTotIvaLiquidata.ReadOnly = true;
			this.txtTotIvaLiquidata.Size = new System.Drawing.Size(128, 20);
			this.txtTotIvaLiquidata.TabIndex = 3;
			this.txtTotIvaLiquidata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 8);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(112, 23);
			this.label22.TabIndex = 1;
			this.label22.Text = "Totale IVA Liquidata:";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(8, 40);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(947, 430);
			this.dataGrid2.TabIndex = 0;
			this.dataGrid2.Tag = "invoicedeferred.default";
			// 
			// tabRegistri
			// 
			this.tabRegistri.Controls.Add(this.dataGrid1);
			this.tabRegistri.Location = new System.Drawing.Point(4, 22);
			this.tabRegistri.Name = "tabRegistri";
			this.tabRegistri.Size = new System.Drawing.Size(981, 478);
			this.tabRegistri.TabIndex = 3;
			this.tabRegistri.Text = "Registri protocollo";
			this.tabRegistri.UseVisualStyleBackColor = true;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 8);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(947, 459);
			this.dataGrid1.TabIndex = 0;
			this.dataGrid1.Tag = "ivaregister.protocollo";
			// 
			// tabPageDettagli
			// 
			this.tabPageDettagli.Controls.Add(this.btnCollegaCarichiCespite);
			this.tabPageDettagli.Controls.Add(this.btnUnisciDettagli);
			this.tabPageDettagli.Controls.Add(this.btnDividiDettaglio);
			this.tabPageDettagli.Controls.Add(this.btnCopiaUPBeCausaleEP);
			this.tabPageDettagli.Controls.Add(this.btnRipartizione);
			this.tabPageDettagli.Controls.Add(this.btnBolletta);
			this.tabPageDettagli.Controls.Add(this.btnContabilizzazioni);
			this.tabPageDettagli.Controls.Add(this.btnAggiungiDaContratti);
			this.tabPageDettagli.Controls.Add(this.gboxProfessionale);
			this.tabPageDettagli.Controls.Add(this.btnCreaDaContratto);
			this.tabPageDettagli.Controls.Add(this.txtTotale);
			this.tabPageDettagli.Controls.Add(this.label16);
			this.tabPageDettagli.Controls.Add(this.txtIndetraibile);
			this.tabPageDettagli.Controls.Add(this.label14);
			this.tabPageDettagli.Controls.Add(this.txtIva);
			this.tabPageDettagli.Controls.Add(this.label17);
			this.tabPageDettagli.Controls.Add(this.txtImponibile);
			this.tabPageDettagli.Controls.Add(this.label18);
			this.tabPageDettagli.Controls.Add(this.btnAggiungiDaOrdini);
			this.tabPageDettagli.Controls.Add(this.buttonDetele);
			this.tabPageDettagli.Controls.Add(this.buttonEdit);
			this.tabPageDettagli.Controls.Add(this.buttonInsert);
			this.tabPageDettagli.Controls.Add(this.gridDettagli);
			this.tabPageDettagli.Location = new System.Drawing.Point(4, 22);
			this.tabPageDettagli.Name = "tabPageDettagli";
			this.tabPageDettagli.Size = new System.Drawing.Size(981, 478);
			this.tabPageDettagli.TabIndex = 1;
			this.tabPageDettagli.Text = "Dettagli";
			this.tabPageDettagli.UseVisualStyleBackColor = true;
			// 
			// btnCollegaCarichiCespite
			// 
			this.btnCollegaCarichiCespite.Location = new System.Drawing.Point(3, 423);
			this.btnCollegaCarichiCespite.Name = "btnCollegaCarichiCespite";
			this.btnCollegaCarichiCespite.Size = new System.Drawing.Size(97, 37);
			this.btnCollegaCarichiCespite.TabIndex = 54;
			this.btnCollegaCarichiCespite.Text = "Collega a carico cespite";
			this.btnCollegaCarichiCespite.UseVisualStyleBackColor = true;
			this.btnCollegaCarichiCespite.Click += new System.EventHandler(this.btnCollegaCarichiCespite_Click);
			// 
			// btnUnisciDettagli
			// 
			this.btnUnisciDettagli.Location = new System.Drawing.Point(24, 321);
			this.btnUnisciDettagli.Name = "btnUnisciDettagli";
			this.btnUnisciDettagli.Size = new System.Drawing.Size(72, 23);
			this.btnUnisciDettagli.TabIndex = 53;
			this.btnUnisciDettagli.Text = "Unisci";
			this.btnUnisciDettagli.Click += new System.EventHandler(this.btnUnisciDettagli_Click);
			// 
			// btnDividiDettaglio
			// 
			this.btnDividiDettaglio.Location = new System.Drawing.Point(24, 292);
			this.btnDividiDettaglio.Name = "btnDividiDettaglio";
			this.btnDividiDettaglio.Size = new System.Drawing.Size(72, 23);
			this.btnDividiDettaglio.TabIndex = 52;
			this.btnDividiDettaglio.Text = "Dividi";
			this.btnDividiDettaglio.Click += new System.EventHandler(this.btnDividiDettaglio_Click);
			// 
			// btnCopiaUPBeCausaleEP
			// 
			this.btnCopiaUPBeCausaleEP.Location = new System.Drawing.Point(9, 221);
			this.btnCopiaUPBeCausaleEP.Name = "btnCopiaUPBeCausaleEP";
			this.btnCopiaUPBeCausaleEP.Size = new System.Drawing.Size(89, 45);
			this.btnCopiaUPBeCausaleEP.TabIndex = 51;
			this.btnCopiaUPBeCausaleEP.Text = "Copia UPB e Causale EP";
			this.btnCopiaUPBeCausaleEP.Click += new System.EventHandler(this.btnCopiaUPBeCausaleEP_Click);
			// 
			// btnRipartizione
			// 
			this.btnRipartizione.Location = new System.Drawing.Point(6, 347);
			this.btnRipartizione.Name = "btnRipartizione";
			this.btnRipartizione.Size = new System.Drawing.Size(89, 23);
			this.btnRipartizione.TabIndex = 50;
			this.btnRipartizione.Text = "Ripartizione";
			this.btnRipartizione.Click += new System.EventHandler(this.btnRipartizione_Click);
			// 
			// btnBolletta
			// 
			this.btnBolletta.Location = new System.Drawing.Point(319, 12);
			this.btnBolletta.Name = "btnBolletta";
			this.btnBolletta.Size = new System.Drawing.Size(118, 39);
			this.btnBolletta.TabIndex = 49;
			this.btnBolletta.Text = "Aggiungi bolletta";
			this.btnBolletta.Click += new System.EventHandler(this.btnBolletta_Click);
			// 
			// btnContabilizzazioni
			// 
			this.btnContabilizzazioni.Location = new System.Drawing.Point(6, 376);
			this.btnContabilizzazioni.Name = "btnContabilizzazioni";
			this.btnContabilizzazioni.Size = new System.Drawing.Size(92, 41);
			this.btnContabilizzazioni.TabIndex = 48;
			this.btnContabilizzazioni.Text = "Contabilizzazioni";
			this.btnContabilizzazioni.Click += new System.EventHandler(this.btnContabilizzazioni_Click);
			// 
			// btnAggiungiDaContratti
			// 
			this.btnAggiungiDaContratti.Location = new System.Drawing.Point(104, 11);
			this.btnAggiungiDaContratti.Name = "btnAggiungiDaContratti";
			this.btnAggiungiDaContratti.Size = new System.Drawing.Size(86, 41);
			this.btnAggiungiDaContratti.TabIndex = 47;
			this.btnAggiungiDaContratti.Text = "Aggiungi da Contratti Attivi";
			this.btnAggiungiDaContratti.Click += new System.EventHandler(this.btnAggiungiDaContratti_Click);
			// 
			// gboxProfessionale
			// 
			this.gboxProfessionale.Controls.Add(this.dataGrid4);
			this.gboxProfessionale.Location = new System.Drawing.Point(627, 7);
			this.gboxProfessionale.Name = "gboxProfessionale";
			this.gboxProfessionale.Size = new System.Drawing.Size(306, 115);
			this.gboxProfessionale.TabIndex = 46;
			this.gboxProfessionale.TabStop = false;
			this.gboxProfessionale.Text = "Contratti professionali collegati";
			// 
			// dataGrid4
			// 
			this.dataGrid4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid4.CaptionVisible = false;
			this.dataGrid4.DataMember = "";
			this.dataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid4.Location = new System.Drawing.Point(6, 19);
			this.dataGrid4.Name = "dataGrid4";
			this.dataGrid4.Size = new System.Drawing.Size(294, 85);
			this.dataGrid4.TabIndex = 4;
			this.dataGrid4.Tag = "profservice_1.default";
			// 
			// btnCreaDaContratto
			// 
			this.btnCreaDaContratto.Location = new System.Drawing.Point(195, 11);
			this.btnCreaDaContratto.Name = "btnCreaDaContratto";
			this.btnCreaDaContratto.Size = new System.Drawing.Size(118, 39);
			this.btnCreaDaContratto.TabIndex = 45;
			this.btnCreaDaContratto.Text = "Crea da Contratto Professionale";
			this.btnCreaDaContratto.Click += new System.EventHandler(this.btnCreaDaContratto_Click);
			// 
			// txtTotale
			// 
			this.txtTotale.Location = new System.Drawing.Point(537, 102);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.Size = new System.Drawing.Size(80, 20);
			this.txtTotale.TabIndex = 43;
			this.txtTotale.TabStop = false;
			this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(489, 102);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 16);
			this.label16.TabIndex = 44;
			this.label16.Text = "Totale";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndetraibile
			// 
			this.txtIndetraibile.Location = new System.Drawing.Point(401, 102);
			this.txtIndetraibile.Name = "txtIndetraibile";
			this.txtIndetraibile.ReadOnly = true;
			this.txtIndetraibile.Size = new System.Drawing.Size(80, 20);
			this.txtIndetraibile.TabIndex = 41;
			this.txtIndetraibile.TabStop = false;
			this.txtIndetraibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(305, 102);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(88, 16);
			this.label14.TabIndex = 42;
			this.label14.Text = "IVA indetraibile";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIva
			// 
			this.txtIva.Location = new System.Drawing.Point(217, 102);
			this.txtIva.Name = "txtIva";
			this.txtIva.ReadOnly = true;
			this.txtIva.Size = new System.Drawing.Size(80, 20);
			this.txtIva.TabIndex = 37;
			this.txtIva.TabStop = false;
			this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(177, 102);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 16);
			this.label17.TabIndex = 38;
			this.label17.Text = "IVA";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImponibile
			// 
			this.txtImponibile.Location = new System.Drawing.Point(89, 102);
			this.txtImponibile.Name = "txtImponibile";
			this.txtImponibile.ReadOnly = true;
			this.txtImponibile.Size = new System.Drawing.Size(80, 20);
			this.txtImponibile.TabIndex = 35;
			this.txtImponibile.TabStop = false;
			this.txtImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(17, 102);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 36;
			this.label18.Text = "Imponibile";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAggiungiDaOrdini
			// 
			this.btnAggiungiDaOrdini.Location = new System.Drawing.Point(8, 11);
			this.btnAggiungiDaOrdini.Name = "btnAggiungiDaOrdini";
			this.btnAggiungiDaOrdini.Size = new System.Drawing.Size(92, 41);
			this.btnAggiungiDaOrdini.TabIndex = 5;
			this.btnAggiungiDaOrdini.Text = "Aggiungi da Ordini";
			this.btnAggiungiDaOrdini.Click += new System.EventHandler(this.btnAggiungiDaOrdini_Click);
			// 
			// buttonDetele
			// 
			this.buttonDetele.Location = new System.Drawing.Point(23, 192);
			this.buttonDetele.Name = "buttonDetele";
			this.buttonDetele.Size = new System.Drawing.Size(75, 23);
			this.buttonDetele.TabIndex = 2;
			this.buttonDetele.Tag = "delete";
			this.buttonDetele.Text = "Elimina";
			// 
			// buttonEdit
			// 
			this.buttonEdit.Location = new System.Drawing.Point(23, 160);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonEdit.TabIndex = 1;
			this.buttonEdit.Tag = "edit.single";
			this.buttonEdit.Text = "Modifica";
			// 
			// buttonInsert
			// 
			this.buttonInsert.Location = new System.Drawing.Point(23, 128);
			this.buttonInsert.Name = "buttonInsert";
			this.buttonInsert.Size = new System.Drawing.Size(75, 23);
			this.buttonInsert.TabIndex = 0;
			this.buttonInsert.Tag = "insert.single";
			this.buttonInsert.Text = "Inserisci";
			// 
			// gridDettagli
			// 
			this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagli.CaptionVisible = false;
			this.gridDettagli.DataMember = "";
			this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagli.Location = new System.Drawing.Point(104, 128);
			this.gridDettagli.Name = "gridDettagli";
			this.gridDettagli.Size = new System.Drawing.Size(851, 339);
			this.gridDettagli.TabIndex = 3;
			this.gridDettagli.Tag = "invoicedetail.documento.single";
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.chkEscludiInvio);
			this.tabPrincipale.Controls.Add(this.grpInvSpedizioniere);
			this.tabPrincipale.Controls.Add(this.btnInserisciBollettaDoganale);
			this.tabPrincipale.Controls.Add(this.chkFatturaSpedizioniere);
			this.tabPrincipale.Controls.Add(this.chkBollaDoganale);
			this.tabPrincipale.Controls.Add(this.grp_Split_Payment);
			this.tabPrincipale.Controls.Add(this.textBox8);
			this.tabPrincipale.Controls.Add(this.btnAnnullaFattura);
			this.tabPrincipale.Controls.Add(this.chkProtocollanelRU);
			this.tabPrincipale.Controls.Add(this.chkIncludeInPaymentIndicator);
			this.tabPrincipale.Controls.Add(this.txtProtocolDate);
			this.tabPrincipale.Controls.Add(this.lblProtocolDate);
			this.tabPrincipale.Controls.Add(this.btnAutoFattura);
			this.tabPrincipale.Controls.Add(this.chkAutoFattura);
			this.tabPrincipale.Controls.Add(this.chkflag_ddt);
			this.tabPrincipale.Controls.Add(this.grpTesorierePerIncasso);
			this.tabPrincipale.Controls.Add(this.chkContabilizzabile);
			this.tabPrincipale.Controls.Add(this.txtDataContabile);
			this.tabPrincipale.Controls.Add(this.label11);
			this.tabPrincipale.Controls.Add(this.groupBox6);
			this.tabPrincipale.Controls.Add(this.gboxvaluta);
			this.tabPrincipale.Controls.Add(this.groupBox4);
			this.tabPrincipale.Controls.Add(this.groupBox1);
			this.tabPrincipale.Controls.Add(this.gboxAnagrafica);
			this.tabPrincipale.Controls.Add(this.groupBox2);
			this.tabPrincipale.Controls.Add(this.frpDocumento);
			this.tabPrincipale.Controls.Add(this.textBox6);
			this.tabPrincipale.Controls.Add(this.label6);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(981, 478);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// chkEscludiInvio
			// 
			this.chkEscludiInvio.AutoSize = true;
			this.chkEscludiInvio.Location = new System.Drawing.Point(769, 342);
			this.chkEscludiInvio.Name = "chkEscludiInvio";
			this.chkEscludiInvio.Size = new System.Drawing.Size(154, 17);
			this.chkEscludiInvio.TabIndex = 26;
			this.chkEscludiInvio.Tag = "invoice.flagbit:3";
			this.chkEscludiInvio.Text = "Escludi da Invio dati fatture";
			this.chkEscludiInvio.UseVisualStyleBackColor = true;
			// 
			// grpInvSpedizioniere
			// 
			this.grpInvSpedizioniere.Controls.Add(this.label54);
			this.grpInvSpedizioniere.Controls.Add(this.cmbInvKindSpedizioniere);
			this.grpInvSpedizioniere.Controls.Add(this.txtNinv_Spedizioniere);
			this.grpInvSpedizioniere.Controls.Add(this.label55);
			this.grpInvSpedizioniere.Controls.Add(this.txtYinv_Spedizioniere);
			this.grpInvSpedizioniere.Controls.Add(this.label56);
			this.grpInvSpedizioniere.Location = new System.Drawing.Point(17, 329);
			this.grpInvSpedizioniere.Name = "grpInvSpedizioniere";
			this.grpInvSpedizioniere.Size = new System.Drawing.Size(399, 90);
			this.grpInvSpedizioniere.TabIndex = 33;
			this.grpInvSpedizioniere.TabStop = false;
			this.grpInvSpedizioniere.Text = " Fattura Spedizioniere";
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(36, 29);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(28, 13);
			this.label54.TabIndex = 10;
			this.label54.Text = "Tipo";
			// 
			// cmbInvKindSpedizioniere
			// 
			this.cmbInvKindSpedizioniere.DataSource = this.DS.invoicekind_forwarder;
			this.cmbInvKindSpedizioniere.DisplayMember = "description";
			this.cmbInvKindSpedizioniere.Location = new System.Drawing.Point(71, 27);
			this.cmbInvKindSpedizioniere.Name = "cmbInvKindSpedizioniere";
			this.cmbInvKindSpedizioniere.Size = new System.Drawing.Size(321, 21);
			this.cmbInvKindSpedizioniere.TabIndex = 9;
			this.cmbInvKindSpedizioniere.Tag = "invoice.idinvkind_forwarder";
			this.cmbInvKindSpedizioniere.ValueMember = "idinvkind";
			// 
			// txtNinv_Spedizioniere
			// 
			this.txtNinv_Spedizioniere.Location = new System.Drawing.Point(198, 61);
			this.txtNinv_Spedizioniere.Name = "txtNinv_Spedizioniere";
			this.txtNinv_Spedizioniere.Size = new System.Drawing.Size(64, 20);
			this.txtNinv_Spedizioniere.TabIndex = 2;
			this.txtNinv_Spedizioniere.Tag = "invoice.ninv_forwarder";
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(149, 61);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(44, 13);
			this.label55.TabIndex = 8;
			this.label55.Text = "Numero";
			// 
			// txtYinv_Spedizioniere
			// 
			this.txtYinv_Spedizioniere.Location = new System.Drawing.Point(70, 61);
			this.txtYinv_Spedizioniere.Name = "txtYinv_Spedizioniere";
			this.txtYinv_Spedizioniere.Size = new System.Drawing.Size(72, 20);
			this.txtYinv_Spedizioniere.TabIndex = 1;
			this.txtYinv_Spedizioniere.Tag = "invoice.yinv_forwarder.year";
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(11, 61);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(49, 13);
			this.label56.TabIndex = 6;
			this.label56.Text = "Esercizio";
			// 
			// btnInserisciBollettaDoganale
			// 
			this.btnInserisciBollettaDoganale.Location = new System.Drawing.Point(748, 380);
			this.btnInserisciBollettaDoganale.Name = "btnInserisciBollettaDoganale";
			this.btnInserisciBollettaDoganale.Size = new System.Drawing.Size(180, 21);
			this.btnInserisciBollettaDoganale.TabIndex = 32;
			this.btnInserisciBollettaDoganale.Text = "Inserisci bolletta doganale";
			this.btnInserisciBollettaDoganale.UseVisualStyleBackColor = true;
			this.btnInserisciBollettaDoganale.Click += new System.EventHandler(this.btnInserisciBollettaDoganale_Click);
			// 
			// chkFatturaSpedizioniere
			// 
			this.chkFatturaSpedizioniere.AutoSize = true;
			this.chkFatturaSpedizioniere.Location = new System.Drawing.Point(426, 383);
			this.chkFatturaSpedizioniere.Name = "chkFatturaSpedizioniere";
			this.chkFatturaSpedizioniere.Size = new System.Drawing.Size(123, 17);
			this.chkFatturaSpedizioniere.TabIndex = 30;
			this.chkFatturaSpedizioniere.Tag = "invoice.flagbit:1";
			this.chkFatturaSpedizioniere.Text = "Fattura spedizioniere";
			this.chkFatturaSpedizioniere.UseVisualStyleBackColor = true;
			this.chkFatturaSpedizioniere.CheckedChanged += new System.EventHandler(this.chkFatturaSpedizioniere_CheckedChanged);
			// 
			// chkBollaDoganale
			// 
			this.chkBollaDoganale.AutoSize = true;
			this.chkBollaDoganale.Location = new System.Drawing.Point(427, 403);
			this.chkBollaDoganale.Name = "chkBollaDoganale";
			this.chkBollaDoganale.Size = new System.Drawing.Size(96, 17);
			this.chkBollaDoganale.TabIndex = 31;
			this.chkBollaDoganale.Tag = "invoice.flagbit:0";
			this.chkBollaDoganale.Text = "Bolla doganale";
			this.chkBollaDoganale.UseVisualStyleBackColor = true;
			this.chkBollaDoganale.CheckedChanged += new System.EventHandler(this.chkBollaDoganale_CheckedChanged);
			// 
			// grp_Split_Payment
			// 
			this.grp_Split_Payment.Controls.Add(this.chk_enable_reverse_charge);
			this.grp_Split_Payment.Controls.Add(this.chk_auto_split_payment);
			this.grp_Split_Payment.Controls.Add(this.chk_enable_split_payment);
			this.grp_Split_Payment.Location = new System.Drawing.Point(421, 426);
			this.grp_Split_Payment.Name = "grp_Split_Payment";
			this.grp_Split_Payment.Size = new System.Drawing.Size(507, 42);
			this.grp_Split_Payment.TabIndex = 34;
			this.grp_Split_Payment.TabStop = false;
			this.grp_Split_Payment.Text = "Applicazione Split Payment e Reverse Charge";
			// 
			// chk_enable_reverse_charge
			// 
			this.chk_enable_reverse_charge.AutoSize = true;
			this.chk_enable_reverse_charge.Location = new System.Drawing.Point(346, 19);
			this.chk_enable_reverse_charge.Name = "chk_enable_reverse_charge";
			this.chk_enable_reverse_charge.Size = new System.Drawing.Size(141, 17);
			this.chk_enable_reverse_charge.TabIndex = 30;
			this.chk_enable_reverse_charge.Tag = "invoice.flag_reverse_charge:S:N";
			this.chk_enable_reverse_charge.Text = "Applica Reverse Charge";
			this.chk_enable_reverse_charge.UseVisualStyleBackColor = true;
			this.chk_enable_reverse_charge.CheckedChanged += new System.EventHandler(this.chk_enable_reverse_charge_CheckedChanged);
			// 
			// chk_auto_split_payment
			// 
			this.chk_auto_split_payment.AutoSize = true;
			this.chk_auto_split_payment.Location = new System.Drawing.Point(8, 19);
			this.chk_auto_split_payment.Name = "chk_auto_split_payment";
			this.chk_auto_split_payment.Size = new System.Drawing.Size(139, 17);
			this.chk_auto_split_payment.TabIndex = 28;
			this.chk_auto_split_payment.Tag = "invoice.flag_auto_split_payment:N:S";
			this.chk_auto_split_payment.Text = "Abilita modifica manuale";
			this.chk_auto_split_payment.UseVisualStyleBackColor = true;
			this.chk_auto_split_payment.CheckedChanged += new System.EventHandler(this.chk_auto_split_payment_CheckedChanged);
			// 
			// chk_enable_split_payment
			// 
			this.chk_enable_split_payment.AutoSize = true;
			this.chk_enable_split_payment.Enabled = false;
			this.chk_enable_split_payment.Location = new System.Drawing.Point(187, 19);
			this.chk_enable_split_payment.Name = "chk_enable_split_payment";
			this.chk_enable_split_payment.Size = new System.Drawing.Size(128, 17);
			this.chk_enable_split_payment.TabIndex = 27;
			this.chk_enable_split_payment.Tag = "invoice.flag_enable_split_payment:S:N";
			this.chk_enable_split_payment.Text = "Applica Split Payment";
			this.chk_enable_split_payment.UseVisualStyleBackColor = true;
			this.chk_enable_split_payment.CheckedChanged += new System.EventHandler(this.chk_enable_split_payment_CheckedChanged);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(112, 426);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(304, 41);
			this.textBox8.TabIndex = 28;
			this.textBox8.TabStop = false;
			this.textBox8.Tag = "";
			this.textBox8.Text = "Azzera tutti gli importi, la quantità dei dettagli e scollega da eventuali docume" +
    "nti associati.";
			// 
			// btnAnnullaFattura
			// 
			this.btnAnnullaFattura.Location = new System.Drawing.Point(17, 425);
			this.btnAnnullaFattura.Name = "btnAnnullaFattura";
			this.btnAnnullaFattura.Size = new System.Drawing.Size(90, 22);
			this.btnAnnullaFattura.TabIndex = 27;
			this.btnAnnullaFattura.TabStop = false;
			this.btnAnnullaFattura.Tag = "";
			this.btnAnnullaFattura.Text = "Annulla fattura";
			this.btnAnnullaFattura.Click += new System.EventHandler(this.btnAnnullaFattura_Click);
			// 
			// chkProtocollanelRU
			// 
			this.chkProtocollanelRU.AutoSize = true;
			this.chkProtocollanelRU.Location = new System.Drawing.Point(426, 363);
			this.chkProtocollanelRU.Name = "chkProtocollanelRU";
			this.chkProtocollanelRU.Size = new System.Drawing.Size(163, 17);
			this.chkProtocollanelRU.TabIndex = 29;
			this.chkProtocollanelRU.Tag = "invoice.touniqueregister:S:N";
			this.chkProtocollanelRU.Text = "Protocolla nel Registro Unico";
			this.chkProtocollanelRU.UseVisualStyleBackColor = true;
			this.chkProtocollanelRU.CheckedChanged += new System.EventHandler(this.chkProtocollanelRU_CheckedChanged);
			// 
			// chkIncludeInPaymentIndicator
			// 
			this.chkIncludeInPaymentIndicator.AutoSize = true;
			this.chkIncludeInPaymentIndicator.Location = new System.Drawing.Point(426, 342);
			this.chkIncludeInPaymentIndicator.Name = "chkIncludeInPaymentIndicator";
			this.chkIncludeInPaymentIndicator.Size = new System.Drawing.Size(251, 17);
			this.chkIncludeInPaymentIndicator.TabIndex = 25;
			this.chkIncludeInPaymentIndicator.Tag = "invoice.toincludeinpaymentindicator:S:N";
			this.chkIncludeInPaymentIndicator.Text = "Includi in Indicatore Tempestività dei Pagamenti";
			this.chkIncludeInPaymentIndicator.UseVisualStyleBackColor = true;
			// 
			// txtProtocolDate
			// 
			this.txtProtocolDate.Location = new System.Drawing.Point(843, 280);
			this.txtProtocolDate.Name = "txtProtocolDate";
			this.txtProtocolDate.Size = new System.Drawing.Size(80, 20);
			this.txtProtocolDate.TabIndex = 24;
			this.txtProtocolDate.Tag = "invoice.protocoldate";
			this.txtProtocolDate.Leave += new System.EventHandler(this.txtProtocolDate_Leave);
			// 
			// lblProtocolDate
			// 
			this.lblProtocolDate.Location = new System.Drawing.Point(747, 283);
			this.lblProtocolDate.Name = "lblProtocolDate";
			this.lblProtocolDate.Size = new System.Drawing.Size(93, 16);
			this.lblProtocolDate.TabIndex = 23;
			this.lblProtocolDate.Text = "Data protocollo";
			this.lblProtocolDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnAutoFattura
			// 
			this.btnAutoFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAutoFattura.Location = new System.Drawing.Point(882, 32);
			this.btnAutoFattura.Name = "btnAutoFattura";
			this.btnAutoFattura.Size = new System.Drawing.Size(91, 40);
			this.btnAutoFattura.TabIndex = 22;
			this.btnAutoFattura.Text = "Crea Autofattura";
			this.btnAutoFattura.UseVisualStyleBackColor = true;
			this.btnAutoFattura.Visible = false;
			this.btnAutoFattura.Click += new System.EventHandler(this.btnAutoFattura_Click);
			// 
			// chkAutoFattura
			// 
			this.chkAutoFattura.AutoSize = true;
			this.chkAutoFattura.Location = new System.Drawing.Point(426, 321);
			this.chkAutoFattura.Name = "chkAutoFattura";
			this.chkAutoFattura.Size = new System.Drawing.Size(78, 17);
			this.chkAutoFattura.TabIndex = 21;
			this.chkAutoFattura.Tag = "invoice.autoinvoice:S:N";
			this.chkAutoFattura.Text = "Autofattura";
			this.chkAutoFattura.UseVisualStyleBackColor = true;
			this.chkAutoFattura.CheckedChanged += new System.EventHandler(this.chkAutoFattura_CheckedChanged);
			// 
			// chkflag_ddt
			// 
			this.chkflag_ddt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkflag_ddt.ForeColor = System.Drawing.Color.Red;
			this.chkflag_ddt.Location = new System.Drawing.Point(426, 278);
			this.chkflag_ddt.Name = "chkflag_ddt";
			this.chkflag_ddt.Size = new System.Drawing.Size(240, 24);
			this.chkflag_ddt.TabIndex = 9;
			this.chkflag_ddt.Tag = "invoice.flag_ddt:N:S";
			this.chkflag_ddt.Text = "Fattura accompagnatoria";
			this.chkflag_ddt.CheckedChanged += new System.EventHandler(this.chkflag_ddt_CheckedChanged);
			// 
			// grpTesorierePerIncasso
			// 
			this.grpTesorierePerIncasso.Controls.Add(this.cmbCodiceIstituto);
			this.grpTesorierePerIncasso.Location = new System.Drawing.Point(16, 274);
			this.grpTesorierePerIncasso.Name = "grpTesorierePerIncasso";
			this.grpTesorierePerIncasso.Size = new System.Drawing.Size(400, 50);
			this.grpTesorierePerIncasso.TabIndex = 8;
			this.grpTesorierePerIncasso.TabStop = false;
			this.grpTesorierePerIncasso.Text = "Tesoriere per Incasso";
			// 
			// cmbCodiceIstituto
			// 
			this.cmbCodiceIstituto.DataSource = this.DS.treasurer;
			this.cmbCodiceIstituto.DisplayMember = "description";
			this.cmbCodiceIstituto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCodiceIstituto.Location = new System.Drawing.Point(12, 17);
			this.cmbCodiceIstituto.Name = "cmbCodiceIstituto";
			this.cmbCodiceIstituto.Size = new System.Drawing.Size(380, 21);
			this.cmbCodiceIstituto.TabIndex = 0;
			this.cmbCodiceIstituto.Tag = "invoice.idtreasurer";
			this.cmbCodiceIstituto.ValueMember = "idtreasurer";
			// 
			// chkContabilizzabile
			// 
			this.chkContabilizzabile.Location = new System.Drawing.Point(426, 298);
			this.chkContabilizzabile.Name = "chkContabilizzabile";
			this.chkContabilizzabile.Size = new System.Drawing.Size(240, 24);
			this.chkContabilizzabile.TabIndex = 10;
			this.chkContabilizzabile.Tag = "invoice.active:S:N";
			this.chkContabilizzabile.Text = "Utilizzabile per la contabilizzazione";
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(843, 310);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
			this.txtDataContabile.TabIndex = 11;
			this.txtDataContabile.Tag = "invoice.adate";
			this.txtDataContabile.Leave += new System.EventHandler(this.txtDataContabile_Leave);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(747, 312);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 16);
			this.label11.TabIndex = 20;
			this.label11.Text = "Data registrazione";
			this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.textBox10);
			this.groupBox6.Location = new System.Drawing.Point(16, 176);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(400, 96);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Descrizione ";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(12, 16);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(376, 72);
			this.textBox10.TabIndex = 14;
			this.textBox10.Tag = "invoice.description";
			// 
			// gboxvaluta
			// 
			this.gboxvaluta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxvaluta.Controls.Add(this.btnValuta);
			this.gboxvaluta.Controls.Add(this.txtValuta);
			this.gboxvaluta.Controls.Add(this.txtCambio);
			this.gboxvaluta.Controls.Add(this.label12);
			this.gboxvaluta.Location = new System.Drawing.Point(424, 152);
			this.gboxvaluta.Name = "gboxvaluta";
			this.gboxvaluta.Size = new System.Drawing.Size(549, 50);
			this.gboxvaluta.TabIndex = 6;
			this.gboxvaluta.TabStop = false;
			this.gboxvaluta.Tag = "AutoChoose.txtValuta.default";
			// 
			// btnValuta
			// 
			this.btnValuta.Location = new System.Drawing.Point(7, 18);
			this.btnValuta.Name = "btnValuta";
			this.btnValuta.Size = new System.Drawing.Size(59, 23);
			this.btnValuta.TabIndex = 9;
			this.btnValuta.Tag = "choose.currency.default";
			this.btnValuta.Text = "Valuta";
			this.btnValuta.UseVisualStyleBackColor = true;
			// 
			// txtValuta
			// 
			this.txtValuta.Location = new System.Drawing.Point(71, 20);
			this.txtValuta.Name = "txtValuta";
			this.txtValuta.Size = new System.Drawing.Size(259, 20);
			this.txtValuta.TabIndex = 8;
			this.txtValuta.Tag = "currency.description?x";
			// 
			// txtCambio
			// 
			this.txtCambio.Location = new System.Drawing.Point(401, 20);
			this.txtCambio.Name = "txtCambio";
			this.txtCambio.Size = new System.Drawing.Size(98, 20);
			this.txtCambio.TabIndex = 1;
			this.txtCambio.Tag = "invoice.exchangerate.fixed.9...1";
			this.txtCambio.Leave += new System.EventHandler(this.txtCambio_Leave);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(347, 23);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(49, 16);
			this.label12.TabIndex = 7;
			this.label12.Text = "Cambio";
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.txtDataDDT);
			this.groupBox4.Controls.Add(this.txtNumDDT);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Location = new System.Drawing.Point(424, 204);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(549, 73);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Documento di trasporto";
			// 
			// txtDataDDT
			// 
			this.txtDataDDT.Location = new System.Drawing.Point(71, 50);
			this.txtDataDDT.Name = "txtDataDDT";
			this.txtDataDDT.Size = new System.Drawing.Size(66, 20);
			this.txtDataDDT.TabIndex = 1;
			this.txtDataDDT.Tag = "invoice.packinglistdate";
			// 
			// txtNumDDT
			// 
			this.txtNumDDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNumDDT.Location = new System.Drawing.Point(71, 26);
			this.txtNumDDT.Name = "txtNumDDT";
			this.txtNumDDT.Size = new System.Drawing.Size(473, 20);
			this.txtNumDDT.TabIndex = 0;
			this.txtNumDDT.Tag = "invoice.packinglistnum";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(23, 52);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(43, 16);
			this.label9.TabIndex = 7;
			this.label9.Text = "Data";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(17, 29);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 16);
			this.label10.TabIndex = 6;
			this.label10.Text = "Numero";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label42);
			this.groupBox1.Controls.Add(this.txtDataScadenza);
			this.groupBox1.Controls.Add(this.cmbTipoScadenza);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtScadenza);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Location = new System.Drawing.Point(424, 75);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(549, 78);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scadenza";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(339, 51);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(56, 16);
			this.label42.TabIndex = 16;
			this.label42.Text = "Data";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataScadenza
			// 
			this.txtDataScadenza.Location = new System.Drawing.Point(401, 52);
			this.txtDataScadenza.Name = "txtDataScadenza";
			this.txtDataScadenza.Size = new System.Drawing.Size(98, 20);
			this.txtDataScadenza.TabIndex = 15;
			this.txtDataScadenza.Tag = "";
			// 
			// cmbTipoScadenza
			// 
			this.cmbTipoScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoScadenza.DataSource = this.DS.expirationkind;
			this.cmbTipoScadenza.DisplayMember = "description";
			this.cmbTipoScadenza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoScadenza.Location = new System.Drawing.Point(66, 26);
			this.cmbTipoScadenza.Name = "cmbTipoScadenza";
			this.cmbTipoScadenza.Size = new System.Drawing.Size(478, 21);
			this.cmbTipoScadenza.TabIndex = 0;
			this.cmbTipoScadenza.Tag = "invoice.idexpirationkind";
			this.cmbTipoScadenza.ValueMember = "idexpirationkind";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(17, 29);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(34, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Tipo";
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(66, 52);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(71, 20);
			this.txtScadenza.TabIndex = 1;
			this.txtScadenza.Tag = "invoice.paymentexpiring";
			this.txtScadenza.Leave += new System.EventHandler(this.txtScadenza_Leave);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(2, 52);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 16);
			this.label7.TabIndex = 11;
			this.label7.Text = "Scadenza";
			// 
			// gboxAnagrafica
			// 
			this.gboxAnagrafica.Controls.Add(this.txtCredDeb);
			this.gboxAnagrafica.Location = new System.Drawing.Point(16, 136);
			this.gboxAnagrafica.Name = "gboxAnagrafica";
			this.gboxAnagrafica.Size = new System.Drawing.Size(400, 40);
			this.gboxAnagrafica.TabIndex = 2;
			this.gboxAnagrafica.TabStop = false;
			this.gboxAnagrafica.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
			this.gboxAnagrafica.Text = "Cliente / Fornitore";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Location = new System.Drawing.Point(13, 16);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(376, 20);
			this.txtCredDeb.TabIndex = 9;
			this.txtCredDeb.Tag = "registry.title?invoiceview.registry";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtDataDoc);
			this.groupBox2.Controls.Add(this.txtDocumento);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Location = new System.Drawing.Point(16, 88);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(400, 48);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Documento";
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Location = new System.Drawing.Point(309, 22);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(80, 20);
			this.txtDataDoc.TabIndex = 9;
			this.txtDataDoc.Tag = "invoice.docdate";
			this.txtDataDoc.Leave += new System.EventHandler(this.txtDataDoc_Leave);
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(72, 21);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(160, 20);
			this.txtDocumento.TabIndex = 8;
			this.txtDocumento.Tag = "invoice.doc";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(256, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Data";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(24, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 6;
			this.label5.Text = "Doc.";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frpDocumento
			// 
			this.frpDocumento.Controls.Add(this.btnTipo);
			this.frpDocumento.Controls.Add(this.txtNumDocumento);
			this.frpDocumento.Controls.Add(this.txtEsercDocumento);
			this.frpDocumento.Controls.Add(this.cboTipo);
			this.frpDocumento.Controls.Add(this.label3);
			this.frpDocumento.Controls.Add(this.label2);
			this.frpDocumento.Controls.Add(this.chb_IVADifferita);
			this.frpDocumento.Location = new System.Drawing.Point(16, 8);
			this.frpDocumento.Name = "frpDocumento";
			this.frpDocumento.Size = new System.Drawing.Size(400, 80);
			this.frpDocumento.TabIndex = 0;
			this.frpDocumento.TabStop = false;
			this.frpDocumento.Text = "Tipo documento";
			// 
			// btnTipo
			// 
			this.btnTipo.Location = new System.Drawing.Point(8, 24);
			this.btnTipo.Name = "btnTipo";
			this.btnTipo.Size = new System.Drawing.Size(56, 23);
			this.btnTipo.TabIndex = 6;
			this.btnTipo.TabStop = false;
			this.btnTipo.Tag = "choose.invoicekind.default";
			this.btnTipo.Text = "Tipo";
			// 
			// txtNumDocumento
			// 
			this.txtNumDocumento.Location = new System.Drawing.Point(199, 53);
			this.txtNumDocumento.Name = "txtNumDocumento";
			this.txtNumDocumento.Size = new System.Drawing.Size(64, 20);
			this.txtNumDocumento.TabIndex = 5;
			this.txtNumDocumento.Tag = "invoice.ninv";
			// 
			// txtEsercDocumento
			// 
			this.txtEsercDocumento.Location = new System.Drawing.Point(71, 53);
			this.txtEsercDocumento.Name = "txtEsercDocumento";
			this.txtEsercDocumento.Size = new System.Drawing.Size(64, 20);
			this.txtEsercDocumento.TabIndex = 4;
			this.txtEsercDocumento.Tag = "invoice.yinv.year";
			// 
			// cboTipo
			// 
			this.cboTipo.DataSource = this.DS.invoicekind;
			this.cboTipo.DisplayMember = "description";
			this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTipo.Location = new System.Drawing.Point(72, 24);
			this.cboTipo.Name = "cboTipo";
			this.cboTipo.Size = new System.Drawing.Size(320, 21);
			this.cboTipo.TabIndex = 3;
			this.cboTipo.Tag = "invoice.idinvkind";
			this.cboTipo.ValueMember = "idinvkind";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(143, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Numero";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(7, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Esercizio";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chb_IVADifferita
			// 
			this.chb_IVADifferita.Location = new System.Drawing.Point(303, 53);
			this.chb_IVADifferita.Name = "chb_IVADifferita";
			this.chb_IVADifferita.Size = new System.Drawing.Size(89, 24);
			this.chb_IVADifferita.TabIndex = 21;
			this.chb_IVADifferita.Tag = "invoice.flagdeferred:S:N";
			this.chb_IVADifferita.Text = "IVA differita";
			this.chb_IVADifferita.CheckedChanged += new System.EventHandler(this.chb_IVADifferita_CheckedChanged);
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(424, 24);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox6.Size = new System.Drawing.Size(452, 48);
			this.textBox6.TabIndex = 4;
			this.textBox6.Tag = "invoice.registryreference";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(424, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Riferimento";
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCertificatiNecessari.Controls.Add(this.chkOttempLegge);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioAmm);
			this.grpCertificatiNecessari.Controls.Add(this.chkVerificaAnac);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioGiud);
			this.grpCertificatiNecessari.Controls.Add(this.chkRegolaritaFisc);
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(549, 16);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(405, 142);
			this.grpCertificatiNecessari.TabIndex = 98;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(145, 106);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 99;
			this.chkOttempLegge.Tag = "invoice.requested_doc:5";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(248, 68);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 98;
			this.chkCasellarioAmm.Tag = "invoice.requested_doc:4";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(145, 68);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 97;
			this.chkVerificaAnac.Tag = "invoice.requested_doc:7";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(10, 106);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 96;
			this.chkCasellarioGiud.Tag = "invoice.requested_doc:3";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFisc
			// 
			this.chkRegolaritaFisc.AutoSize = true;
			this.chkRegolaritaFisc.Location = new System.Drawing.Point(10, 68);
			this.chkRegolaritaFisc.Name = "chkRegolaritaFisc";
			this.chkRegolaritaFisc.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFisc.TabIndex = 95;
			this.chkRegolaritaFisc.Tag = "invoice.requested_doc:6";
			this.chkRegolaritaFisc.Text = "Regolarità Fiscale";
			this.chkRegolaritaFisc.UseVisualStyleBackColor = true;
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(145, 27);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(57, 17);
			this.chkDurc.TabIndex = 94;
			this.chkDurc.Tag = "invoice.requested_doc:2";
			this.chkDurc.Text = "DURC";
			this.chkDurc.UseVisualStyleBackColor = true;
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(248, 27);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(102, 17);
			this.chkVisura.TabIndex = 93;
			this.chkVisura.Tag = "invoice.requested_doc:1";
			this.chkVisura.Text = "Visura Camerale";
			this.chkVisura.UseVisualStyleBackColor = true;
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(10, 27);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "invoice.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPrincipale);
			this.tabControl1.Controls.Add(this.tabIntrastat);
			this.tabControl1.Controls.Add(this.tabPageDettagli);
			this.tabControl1.Controls.Add(this.tabRegistri);
			this.tabControl1.Controls.Add(this.tabLiquidazioni);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabClassificazioni);
			this.tabControl1.Controls.Add(this.tabMagazzino);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabPageAutofattura);
			this.tabControl1.Controls.Add(this.tabFE);
			this.tabControl1.Controls.Add(this.tabRegistroUnico);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.Controls.Add(this.tabTesseraSSN);
			this.tabControl1.Controls.Add(this.tabAltro);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(989, 504);
			this.tabControl1.TabIndex = 0;
			// 
			// tabIntrastat
			// 
			this.tabIntrastat.Controls.Add(this.chkRecuperoIvaIntraExtra);
			this.tabIntrastat.Controls.Add(this.gboxtipofattura);
			this.tabIntrastat.Controls.Add(this.gboxIntraInfoServizi);
			this.tabIntrastat.Controls.Add(this.gboxIntraInfoBeni);
			this.tabIntrastat.Location = new System.Drawing.Point(4, 22);
			this.tabIntrastat.Name = "tabIntrastat";
			this.tabIntrastat.Size = new System.Drawing.Size(981, 478);
			this.tabIntrastat.TabIndex = 7;
			this.tabIntrastat.Text = "Intrastat";
			this.tabIntrastat.UseVisualStyleBackColor = true;
			// 
			// chkRecuperoIvaIntraExtra
			// 
			this.chkRecuperoIvaIntraExtra.AutoSize = true;
			this.chkRecuperoIvaIntraExtra.Location = new System.Drawing.Point(608, 14);
			this.chkRecuperoIvaIntraExtra.Name = "chkRecuperoIvaIntraExtra";
			this.chkRecuperoIvaIntraExtra.Size = new System.Drawing.Size(177, 17);
			this.chkRecuperoIvaIntraExtra.TabIndex = 27;
			this.chkRecuperoIvaIntraExtra.Tag = "invoice.flagbit:6";
			this.chkRecuperoIvaIntraExtra.Text = "Recupero IVA Intra ed Extra-UE";
			this.chkRecuperoIvaIntraExtra.UseVisualStyleBackColor = true;
			// 
			// gboxtipofattura
			// 
			this.gboxtipofattura.Controls.Add(this.lblSoggettiUENonresidenti);
			this.gboxtipofattura.Controls.Add(this.rdbextracom);
			this.gboxtipofattura.Controls.Add(this.rdbintracom);
			this.gboxtipofattura.Controls.Add(this.rdbitalia);
			this.gboxtipofattura.Location = new System.Drawing.Point(8, 3);
			this.gboxtipofattura.Name = "gboxtipofattura";
			this.gboxtipofattura.Size = new System.Drawing.Size(594, 46);
			this.gboxtipofattura.TabIndex = 25;
			this.gboxtipofattura.TabStop = false;
			this.gboxtipofattura.Text = "Tipo Fattura";
			// 
			// lblSoggettiUENonresidenti
			// 
			this.lblSoggettiUENonresidenti.AutoSize = true;
			this.lblSoggettiUENonresidenti.Location = new System.Drawing.Point(102, 27);
			this.lblSoggettiUENonresidenti.Name = "lblSoggettiUENonresidenti";
			this.lblSoggettiUENonresidenti.Size = new System.Drawing.Size(189, 13);
			this.lblSoggettiUENonresidenti.TabIndex = 26;
			this.lblSoggettiUENonresidenti.Text = "o Acquisti da soggetti UE non residenti";
			// 
			// rdbextracom
			// 
			this.rdbextracom.AutoSize = true;
			this.rdbextracom.Location = new System.Drawing.Point(310, 10);
			this.rdbextracom.Name = "rdbextracom";
			this.rdbextracom.Size = new System.Drawing.Size(103, 17);
			this.rdbextracom.TabIndex = 25;
			this.rdbextracom.TabStop = true;
			this.rdbextracom.Tag = "invoice.flagintracom:X";
			this.rdbextracom.Text = "Fattura Extra-UE";
			this.rdbextracom.UseVisualStyleBackColor = true;
			this.rdbextracom.CheckedChanged += new System.EventHandler(this.rdbextracom_CheckedChanged);
			// 
			// rdbintracom
			// 
			this.rdbintracom.AutoSize = true;
			this.rdbintracom.Location = new System.Drawing.Point(85, 10);
			this.rdbintracom.Name = "rdbintracom";
			this.rdbintracom.Size = new System.Drawing.Size(136, 17);
			this.rdbintracom.TabIndex = 24;
			this.rdbintracom.TabStop = true;
			this.rdbintracom.Tag = "invoice.flagintracom:S";
			this.rdbintracom.Text = "Fattura Intracomunitaria";
			this.rdbintracom.UseVisualStyleBackColor = true;
			this.rdbintracom.CheckedChanged += new System.EventHandler(this.rdbintracom_CheckedChanged);
			// 
			// rdbitalia
			// 
			this.rdbitalia.AutoSize = true;
			this.rdbitalia.Location = new System.Drawing.Point(452, 10);
			this.rdbitalia.Name = "rdbitalia";
			this.rdbitalia.Size = new System.Drawing.Size(94, 17);
			this.rdbitalia.TabIndex = 23;
			this.rdbitalia.TabStop = true;
			this.rdbitalia.Tag = "invoice.flagintracom:N";
			this.rdbitalia.Text = "Fattura in Italia";
			this.rdbitalia.UseVisualStyleBackColor = true;
			this.rdbitalia.CheckedChanged += new System.EventHandler(this.rdbitalia_CheckedChanged);
			// 
			// gboxIntraInfoServizi
			// 
			this.gboxIntraInfoServizi.Controls.Add(this.cmbModpagamento);
			this.gboxIntraInfoServizi.Controls.Add(this.label25);
			this.gboxIntraInfoServizi.Controls.Add(this.textBox13);
			this.gboxIntraInfoServizi.Controls.Add(this.label31);
			this.gboxIntraInfoServizi.Controls.Add(this.cmb_isopagamento);
			this.gboxIntraInfoServizi.Controls.Add(this.label32);
			this.gboxIntraInfoServizi.Location = new System.Drawing.Point(15, 284);
			this.gboxIntraInfoServizi.Name = "gboxIntraInfoServizi";
			this.gboxIntraInfoServizi.Size = new System.Drawing.Size(586, 67);
			this.gboxIntraInfoServizi.TabIndex = 24;
			this.gboxIntraInfoServizi.TabStop = false;
			this.gboxIntraInfoServizi.Text = "Dettagli ai fini dei modelli Intrastat per Servizi resi / ricevuti";
			// 
			// cmbModpagamento
			// 
			this.cmbModpagamento.DataSource = this.DS.intrastatpaymethod;
			this.cmbModpagamento.DisplayMember = "description";
			this.cmbModpagamento.FormattingEnabled = true;
			this.cmbModpagamento.Location = new System.Drawing.Point(134, 38);
			this.cmbModpagamento.Name = "cmbModpagamento";
			this.cmbModpagamento.Size = new System.Drawing.Size(194, 21);
			this.cmbModpagamento.TabIndex = 13;
			this.cmbModpagamento.Tag = "invoice.idintrastatpaymethod";
			this.cmbModpagamento.ValueMember = "idintrastatpaymethod";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(16, 44);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(114, 13);
			this.label25.TabIndex = 12;
			this.label25.Text = "Modalità di pagamento";
			// 
			// textBox13
			// 
			this.textBox13.Location = new System.Drawing.Point(422, 16);
			this.textBox13.Name = "textBox13";
			this.textBox13.ReadOnly = true;
			this.textBox13.Size = new System.Drawing.Size(75, 20);
			this.textBox13.TabIndex = 11;
			this.textBox13.Tag = "intrastatnation_payment.idintrastatnation";
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(345, 21);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(61, 13);
			this.label31.TabIndex = 7;
			this.label31.Text = "Codice ISO";
			// 
			// cmb_isopagamento
			// 
			this.cmb_isopagamento.DisplayMember = "description";
			this.cmb_isopagamento.FormattingEnabled = true;
			this.cmb_isopagamento.Location = new System.Drawing.Point(134, 13);
			this.cmb_isopagamento.Name = "cmb_isopagamento";
			this.cmb_isopagamento.Size = new System.Drawing.Size(194, 21);
			this.cmb_isopagamento.TabIndex = 5;
			this.cmb_isopagamento.Tag = "invoice.iso_payment?invoiceview.idintrastatnation_payment";
			this.cmb_isopagamento.ValueMember = "code";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(24, 20);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(104, 13);
			this.label32.TabIndex = 3;
			this.label32.Text = "Paese di pagamento";
			// 
			// gboxIntraInfoBeni
			// 
			this.gboxIntraInfoBeni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gboxIntraInfoBeni.Controls.Add(this.gboxNatura);
			this.gboxIntraInfoBeni.Controls.Add(this.gboxintra_vendite);
			this.gboxIntraInfoBeni.Controls.Add(this.gboxintra_acquisti);
			this.gboxIntraInfoBeni.Location = new System.Drawing.Point(8, 55);
			this.gboxIntraInfoBeni.Name = "gboxIntraInfoBeni";
			this.gboxIntraInfoBeni.Size = new System.Drawing.Size(642, 415);
			this.gboxIntraInfoBeni.TabIndex = 23;
			this.gboxIntraInfoBeni.TabStop = false;
			this.gboxIntraInfoBeni.Tag = "";
			this.gboxIntraInfoBeni.Text = "Dettagli ai fini dei modelli Intrastat per Acquisti / Cessioni di beni";
			// 
			// gboxNatura
			// 
			this.gboxNatura.Controls.Add(this.button4);
			this.gboxNatura.Controls.Add(this.cmb_natura);
			this.gboxNatura.Controls.Add(this.txtDescrUPB);
			this.gboxNatura.Location = new System.Drawing.Point(6, 164);
			this.gboxNatura.Name = "gboxNatura";
			this.gboxNatura.Size = new System.Drawing.Size(587, 65);
			this.gboxNatura.TabIndex = 7;
			this.gboxNatura.TabStop = false;
			this.gboxNatura.Tag = "";
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.SystemColors.Control;
			this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button4.Location = new System.Drawing.Point(8, 10);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(176, 20);
			this.button4.TabIndex = 5;
			this.button4.TabStop = false;
			this.button4.Tag = "manage.intrastatkind.lista";
			this.button4.Text = "Natura della transazione:";
			this.button4.UseVisualStyleBackColor = false;
			// 
			// cmb_natura
			// 
			this.cmb_natura.FormattingEnabled = true;
			this.cmb_natura.Location = new System.Drawing.Point(9, 35);
			this.cmb_natura.Name = "cmb_natura";
			this.cmb_natura.Size = new System.Drawing.Size(177, 21);
			this.cmb_natura.TabIndex = 6;
			this.cmb_natura.Tag = "invoice.idintrastatkind";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(192, 12);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(387, 42);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "intrastatkind.description";
			// 
			// gboxintra_vendite
			// 
			this.gboxintra_vendite.Controls.Add(this.textBox5);
			this.gboxintra_vendite.Controls.Add(this.textBox3);
			this.gboxintra_vendite.Controls.Add(this.label30);
			this.gboxintra_vendite.Controls.Add(this.label28);
			this.gboxintra_vendite.Controls.Add(this.cmb_provorigine);
			this.gboxintra_vendite.Controls.Add(this.cmb_isodestinazione);
			this.gboxintra_vendite.Controls.Add(this.label20);
			this.gboxintra_vendite.Controls.Add(this.label21);
			this.gboxintra_vendite.Location = new System.Drawing.Point(6, 105);
			this.gboxintra_vendite.Name = "gboxintra_vendite";
			this.gboxintra_vendite.Size = new System.Drawing.Size(588, 59);
			this.gboxintra_vendite.TabIndex = 4;
			this.gboxintra_vendite.TabStop = false;
			this.gboxintra_vendite.Text = "Vendite";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(425, 36);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(75, 20);
			this.textBox5.TabIndex = 12;
			this.textBox5.Tag = "geo_country_origin.province";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(425, 12);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(75, 20);
			this.textBox3.TabIndex = 11;
			this.textBox3.Tag = "intrastatnation_destination.idintrastatnation";
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(380, 38);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(30, 13);
			this.label30.TabIndex = 9;
			this.label30.Text = "Sigla";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(349, 16);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(61, 13);
			this.label28.TabIndex = 7;
			this.label28.Text = "Codice ISO";
			// 
			// cmb_provorigine
			// 
			this.cmb_provorigine.FormattingEnabled = true;
			this.cmb_provorigine.Location = new System.Drawing.Point(137, 35);
			this.cmb_provorigine.Name = "cmb_provorigine";
			this.cmb_provorigine.Size = new System.Drawing.Size(194, 21);
			this.cmb_provorigine.TabIndex = 6;
			this.cmb_provorigine.Tag = "invoice.idcountry_origin";
			// 
			// cmb_isodestinazione
			// 
			this.cmb_isodestinazione.DisplayMember = "description";
			this.cmb_isodestinazione.FormattingEnabled = true;
			this.cmb_isodestinazione.Location = new System.Drawing.Point(137, 8);
			this.cmb_isodestinazione.Name = "cmb_isodestinazione";
			this.cmb_isodestinazione.Size = new System.Drawing.Size(194, 21);
			this.cmb_isodestinazione.TabIndex = 5;
			this.cmb_isodestinazione.Tag = "invoice.iso_destination";
			this.cmb_isodestinazione.ValueMember = "code";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(21, 16);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(110, 13);
			this.label20.TabIndex = 3;
			this.label20.Text = "Paese di destinazione";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(35, 38);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(96, 13);
			this.label21.TabIndex = 4;
			this.label21.Text = "Provincia di origine";
			// 
			// gboxintra_acquisti
			// 
			this.gboxintra_acquisti.Controls.Add(this.textBox4);
			this.gboxintra_acquisti.Controls.Add(this.textBox2);
			this.gboxintra_acquisti.Controls.Add(this.textBox1);
			this.gboxintra_acquisti.Controls.Add(this.label29);
			this.gboxintra_acquisti.Controls.Add(this.label27);
			this.gboxintra_acquisti.Controls.Add(this.label26);
			this.gboxintra_acquisti.Controls.Add(this.cmb_provdestinazione);
			this.gboxintra_acquisti.Controls.Add(this.cmb_isoprovenienza);
			this.gboxintra_acquisti.Controls.Add(this.cmb_isoorigine);
			this.gboxintra_acquisti.Controls.Add(this.label1);
			this.gboxintra_acquisti.Controls.Add(this.label15);
			this.gboxintra_acquisti.Controls.Add(this.label19);
			this.gboxintra_acquisti.Location = new System.Drawing.Point(6, 15);
			this.gboxintra_acquisti.Name = "gboxintra_acquisti";
			this.gboxintra_acquisti.Size = new System.Drawing.Size(588, 86);
			this.gboxintra_acquisti.TabIndex = 3;
			this.gboxintra_acquisti.TabStop = false;
			this.gboxintra_acquisti.Text = "Acquisti";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(425, 62);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(75, 20);
			this.textBox4.TabIndex = 11;
			this.textBox4.Tag = "geo_country_destination.province";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(425, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(75, 20);
			this.textBox2.TabIndex = 10;
			this.textBox2.Tag = "intrastatnation_provenance.idintrastatnation";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(425, 14);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(75, 20);
			this.textBox1.TabIndex = 9;
			this.textBox1.Tag = "intrastatnation_origin.idintrastatnation";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(380, 64);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(30, 13);
			this.label29.TabIndex = 8;
			this.label29.Text = "Sigla";
			this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(349, 41);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(61, 13);
			this.label27.TabIndex = 7;
			this.label27.Text = "Codice ISO";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(349, 16);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(61, 13);
			this.label26.TabIndex = 6;
			this.label26.Text = "Codice ISO";
			// 
			// cmb_provdestinazione
			// 
			this.cmb_provdestinazione.FormattingEnabled = true;
			this.cmb_provdestinazione.Location = new System.Drawing.Point(137, 61);
			this.cmb_provdestinazione.Name = "cmb_provdestinazione";
			this.cmb_provdestinazione.Size = new System.Drawing.Size(194, 21);
			this.cmb_provdestinazione.TabIndex = 5;
			this.cmb_provdestinazione.Tag = "invoice.idcountry_destination";
			// 
			// cmb_isoprovenienza
			// 
			this.cmb_isoprovenienza.DisplayMember = "description";
			this.cmb_isoprovenienza.FormattingEnabled = true;
			this.cmb_isoprovenienza.Location = new System.Drawing.Point(137, 38);
			this.cmb_isoprovenienza.Name = "cmb_isoprovenienza";
			this.cmb_isoprovenienza.Size = new System.Drawing.Size(194, 21);
			this.cmb_isoprovenienza.TabIndex = 4;
			this.cmb_isoprovenienza.Tag = "invoice.iso_provenance";
			this.cmb_isoprovenienza.ValueMember = "code";
			// 
			// cmb_isoorigine
			// 
			this.cmb_isoorigine.FormattingEnabled = true;
			this.cmb_isoorigine.Location = new System.Drawing.Point(137, 13);
			this.cmb_isoorigine.Name = "cmb_isoorigine";
			this.cmb_isoorigine.Size = new System.Drawing.Size(194, 21);
			this.cmb_isoorigine.TabIndex = 3;
			this.cmb_isoorigine.Tag = "invoice.iso_origin";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(49, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Paese di origine";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(22, 38);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(109, 13);
			this.label15.TabIndex = 1;
			this.label15.Text = "Paese di provenienza";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(7, 61);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(124, 13);
			this.label19.TabIndex = 2;
			this.label19.Text = "Provincia di destinazione";
			// 
			// tabMagazzino
			// 
			this.tabMagazzino.Controls.Add(this.btnModificaStock);
			this.tabMagazzino.Controls.Add(this.label33);
			this.tabMagazzino.Controls.Add(this.gridStock);
			this.tabMagazzino.Location = new System.Drawing.Point(4, 22);
			this.tabMagazzino.Name = "tabMagazzino";
			this.tabMagazzino.Padding = new System.Windows.Forms.Padding(3);
			this.tabMagazzino.Size = new System.Drawing.Size(981, 478);
			this.tabMagazzino.TabIndex = 8;
			this.tabMagazzino.Text = "Magazzino";
			this.tabMagazzino.UseVisualStyleBackColor = true;
			// 
			// btnModificaStock
			// 
			this.btnModificaStock.Location = new System.Drawing.Point(746, 8);
			this.btnModificaStock.Name = "btnModificaStock";
			this.btnModificaStock.Size = new System.Drawing.Size(75, 23);
			this.btnModificaStock.TabIndex = 3;
			this.btnModificaStock.Text = "Modifica";
			this.btnModificaStock.UseVisualStyleBackColor = true;
			this.btnModificaStock.Click += new System.EventHandler(this.btnModificaStock_Click);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(15, 19);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(330, 13);
			this.label33.TabIndex = 2;
			this.label33.Text = "Merce pervenuta in magazzino - è aggiornata solo dopo aver salvato";
			// 
			// gridStock
			// 
			this.gridStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridStock.DataMember = "";
			this.gridStock.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridStock.Location = new System.Drawing.Point(18, 37);
			this.gridStock.Name = "gridStock";
			this.gridStock.ReadOnly = true;
			this.gridStock.Size = new System.Drawing.Size(927, 420);
			this.gridStock.TabIndex = 1;
			this.gridStock.Tag = "stockview.invoice";
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
			this.tabAttributi.Size = new System.Drawing.Size(981, 478);
			this.tabAttributi.TabIndex = 11;
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
			this.gboxclass05.Size = new System.Drawing.Size(688, 64);
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
			this.txtDenom05.Size = new System.Drawing.Size(446, 52);
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
			this.gboxclass04.Size = new System.Drawing.Size(688, 64);
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
			this.txtDenom04.Size = new System.Drawing.Size(446, 46);
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
			this.gboxclass03.Size = new System.Drawing.Size(688, 64);
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
			this.txtDenom03.Size = new System.Drawing.Size(447, 52);
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
			this.gboxclass02.Size = new System.Drawing.Size(688, 64);
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
			this.txtDenom02.Size = new System.Drawing.Size(447, 52);
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
			this.gboxclass01.Size = new System.Drawing.Size(688, 64);
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
			this.txtDenom01.Size = new System.Drawing.Size(447, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabPageAutofattura
			// 
			this.tabPageAutofattura.Controls.Add(this.txtTotaleAuto);
			this.tabPageAutofattura.Controls.Add(this.label36);
			this.tabPageAutofattura.Controls.Add(this.txtIndetraibileAuto);
			this.tabPageAutofattura.Controls.Add(this.label37);
			this.tabPageAutofattura.Controls.Add(this.txtIvaAuto);
			this.tabPageAutofattura.Controls.Add(this.label38);
			this.tabPageAutofattura.Controls.Add(this.txtImponibileAuto);
			this.tabPageAutofattura.Controls.Add(this.label39);
			this.tabPageAutofattura.Controls.Add(this.grpInvReal);
			this.tabPageAutofattura.Controls.Add(this.dgDettagliFattura);
			this.tabPageAutofattura.Location = new System.Drawing.Point(4, 22);
			this.tabPageAutofattura.Name = "tabPageAutofattura";
			this.tabPageAutofattura.Size = new System.Drawing.Size(981, 478);
			this.tabPageAutofattura.TabIndex = 10;
			this.tabPageAutofattura.Text = "Autofattura";
			this.tabPageAutofattura.UseVisualStyleBackColor = true;
			this.tabPageAutofattura.Click += new System.EventHandler(this.tabPageAutofattura_Click);
			// 
			// txtTotaleAuto
			// 
			this.txtTotaleAuto.Location = new System.Drawing.Point(568, 82);
			this.txtTotaleAuto.Name = "txtTotaleAuto";
			this.txtTotaleAuto.ReadOnly = true;
			this.txtTotaleAuto.Size = new System.Drawing.Size(80, 20);
			this.txtTotaleAuto.TabIndex = 51;
			this.txtTotaleAuto.TabStop = false;
			this.txtTotaleAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(523, 82);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(40, 16);
			this.label36.TabIndex = 52;
			this.label36.Text = "Totale";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIndetraibileAuto
			// 
			this.txtIndetraibileAuto.Location = new System.Drawing.Point(414, 82);
			this.txtIndetraibileAuto.Name = "txtIndetraibileAuto";
			this.txtIndetraibileAuto.ReadOnly = true;
			this.txtIndetraibileAuto.Size = new System.Drawing.Size(80, 20);
			this.txtIndetraibileAuto.TabIndex = 49;
			this.txtIndetraibileAuto.TabStop = false;
			this.txtIndetraibileAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label37
			// 
			this.label37.Location = new System.Drawing.Point(322, 82);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(88, 16);
			this.label37.TabIndex = 50;
			this.label37.Text = "IVA indetraibile";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIvaAuto
			// 
			this.txtIvaAuto.Location = new System.Drawing.Point(228, 82);
			this.txtIvaAuto.Name = "txtIvaAuto";
			this.txtIvaAuto.ReadOnly = true;
			this.txtIvaAuto.Size = new System.Drawing.Size(80, 20);
			this.txtIvaAuto.TabIndex = 47;
			this.txtIvaAuto.TabStop = false;
			this.txtIvaAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaAuto.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(191, 82);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(32, 16);
			this.label38.TabIndex = 48;
			this.label38.Text = "IVA";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImponibileAuto
			// 
			this.txtImponibileAuto.Location = new System.Drawing.Point(85, 82);
			this.txtImponibileAuto.Name = "txtImponibileAuto";
			this.txtImponibileAuto.ReadOnly = true;
			this.txtImponibileAuto.Size = new System.Drawing.Size(80, 20);
			this.txtImponibileAuto.TabIndex = 45;
			this.txtImponibileAuto.TabStop = false;
			this.txtImponibileAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(15, 82);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(64, 16);
			this.label39.TabIndex = 46;
			this.label39.Text = "Imponibile";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpInvReal
			// 
			this.grpInvReal.Controls.Add(this.btnVisualizzaFattMadre);
			this.grpInvReal.Controls.Add(this.label40);
			this.grpInvReal.Controls.Add(this.cmbTipoFatturaMadre);
			this.grpInvReal.Controls.Add(this.txtNinvReal);
			this.grpInvReal.Controls.Add(this.label34);
			this.grpInvReal.Controls.Add(this.txtYinvReal);
			this.grpInvReal.Controls.Add(this.label35);
			this.grpInvReal.Location = new System.Drawing.Point(289, 3);
			this.grpInvReal.Name = "grpInvReal";
			this.grpInvReal.Size = new System.Drawing.Size(533, 61);
			this.grpInvReal.TabIndex = 6;
			this.grpInvReal.TabStop = false;
			this.grpInvReal.Text = " Fattura di riferimento";
			// 
			// btnVisualizzaFattMadre
			// 
			this.btnVisualizzaFattMadre.Location = new System.Drawing.Point(435, 34);
			this.btnVisualizzaFattMadre.Name = "btnVisualizzaFattMadre";
			this.btnVisualizzaFattMadre.Size = new System.Drawing.Size(88, 24);
			this.btnVisualizzaFattMadre.TabIndex = 12;
			this.btnVisualizzaFattMadre.Text = "Visualizza";
			this.btnVisualizzaFattMadre.UseVisualStyleBackColor = true;
			this.btnVisualizzaFattMadre.Click += new System.EventHandler(this.btnVisualizzaFattMadre_Click);
			// 
			// label40
			// 
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(6, 17);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(28, 13);
			this.label40.TabIndex = 11;
			this.label40.Text = "Tipo";
			// 
			// cmbTipoFatturaMadre
			// 
			this.cmbTipoFatturaMadre.DataSource = this.DS.invoicekind_real;
			this.cmbTipoFatturaMadre.DisplayMember = "description";
			this.cmbTipoFatturaMadre.Enabled = false;
			this.cmbTipoFatturaMadre.FormattingEnabled = true;
			this.cmbTipoFatturaMadre.Location = new System.Drawing.Point(6, 34);
			this.cmbTipoFatturaMadre.Name = "cmbTipoFatturaMadre";
			this.cmbTipoFatturaMadre.Size = new System.Drawing.Size(261, 21);
			this.cmbTipoFatturaMadre.TabIndex = 10;
			this.cmbTipoFatturaMadre.Tag = "invoice.idinvkind_real?x";
			this.cmbTipoFatturaMadre.ValueMember = "idinvkind";
			// 
			// txtNinvReal
			// 
			this.txtNinvReal.Location = new System.Drawing.Point(356, 35);
			this.txtNinvReal.Name = "txtNinvReal";
			this.txtNinvReal.ReadOnly = true;
			this.txtNinvReal.Size = new System.Drawing.Size(65, 20);
			this.txtNinvReal.TabIndex = 9;
			this.txtNinvReal.Tag = "invoice.ninv_real";
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(363, 17);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(44, 13);
			this.label34.TabIndex = 8;
			this.label34.Text = "Numero";
			// 
			// txtYinvReal
			// 
			this.txtYinvReal.Location = new System.Drawing.Point(283, 35);
			this.txtYinvReal.Name = "txtYinvReal";
			this.txtYinvReal.ReadOnly = true;
			this.txtYinvReal.Size = new System.Drawing.Size(61, 20);
			this.txtYinvReal.TabIndex = 7;
			this.txtYinvReal.Tag = "invoice.yinv_real.year";
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(280, 18);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(49, 13);
			this.label35.TabIndex = 6;
			this.label35.Text = "Esercizio";
			// 
			// dgDettagliFattura
			// 
			this.dgDettagliFattura.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgDettagliFattura.CaptionVisible = false;
			this.dgDettagliFattura.DataMember = "";
			this.dgDettagliFattura.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDettagliFattura.Location = new System.Drawing.Point(21, 108);
			this.dgDettagliFattura.Name = "dgDettagliFattura";
			this.dgDettagliFattura.Size = new System.Drawing.Size(925, 350);
			this.dgDettagliFattura.TabIndex = 5;
			this.dgDettagliFattura.Tag = "";
			// 
			// tabFE
			// 
			this.tabFE.Controls.Add(this.tabControl2);
			this.tabFE.Location = new System.Drawing.Point(4, 22);
			this.tabFE.Name = "tabFE";
			this.tabFE.Size = new System.Drawing.Size(981, 478);
			this.tabFE.TabIndex = 16;
			this.tabFE.Text = "Fatt.Elettronica";
			this.tabFE.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Location = new System.Drawing.Point(8, 3);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(963, 472);
			this.tabControl2.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpFEAcquistoEstere);
			this.tabPage2.Controls.Add(this.groupBox17);
			this.tabPage2.Controls.Add(this.grpLegaleRappresentante);
			this.tabPage2.Controls.Add(this.grpDestinatarioVendita);
			this.tabPage2.Controls.Add(this.grpMittenteVendita);
			this.tabPage2.Controls.Add(this.grpDestinatarioAcquisto);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(955, 446);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Fattura Elettronica";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// grpFEAcquistoEstere
			// 
			this.grpFEAcquistoEstere.Controls.Add(this.grpDenominazione);
			this.grpFEAcquistoEstere.Controls.Add(this.grpDocumentKind);
			this.grpFEAcquistoEstere.Location = new System.Drawing.Point(6, 374);
			this.grpFEAcquistoEstere.Name = "grpFEAcquistoEstere";
			this.grpFEAcquistoEstere.Size = new System.Drawing.Size(943, 71);
			this.grpFEAcquistoEstere.TabIndex = 50;
			this.grpFEAcquistoEstere.TabStop = false;
			this.grpFEAcquistoEstere.Text = "FE Acquisto Estere";
			// 
			// grpDenominazione
			// 
			this.grpDenominazione.Controls.Add(this.cmbDenominazione);
			this.grpDenominazione.Location = new System.Drawing.Point(522, 20);
			this.grpDenominazione.Name = "grpDenominazione";
			this.grpDenominazione.Size = new System.Drawing.Size(413, 46);
			this.grpDenominazione.TabIndex = 5;
			this.grpDenominazione.TabStop = false;
			this.grpDenominazione.Text = "Denominazione del Dipartimento o Amministrazione da inserire nella FE";
			// 
			// cmbDenominazione
			// 
			this.cmbDenominazione.DataSource = this.DS.treasurer_acq_estere;
			this.cmbDenominazione.DisplayMember = "description";
			this.cmbDenominazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDenominazione.FormattingEnabled = true;
			this.cmbDenominazione.Location = new System.Drawing.Point(6, 19);
			this.cmbDenominazione.Name = "cmbDenominazione";
			this.cmbDenominazione.Size = new System.Drawing.Size(393, 21);
			this.cmbDenominazione.TabIndex = 3;
			this.cmbDenominazione.Tag = "invoice.idtreasurer_acq_estere";
			this.cmbDenominazione.ValueMember = "idtreasurer";
			// 
			// grpDocumentKind
			// 
			this.grpDocumentKind.Controls.Add(this.cmbDocumentKind);
			this.grpDocumentKind.Location = new System.Drawing.Point(6, 20);
			this.grpDocumentKind.Name = "grpDocumentKind";
			this.grpDocumentKind.Size = new System.Drawing.Size(496, 46);
			this.grpDocumentKind.TabIndex = 4;
			this.grpDocumentKind.TabStop = false;
			this.grpDocumentKind.Text = "Tipo Documento";
			// 
			// cmbDocumentKind
			// 
			this.cmbDocumentKind.DataSource = this.DS.fedocumentkind;
			this.cmbDocumentKind.DisplayMember = "description";
			this.cmbDocumentKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDocumentKind.FormattingEnabled = true;
			this.cmbDocumentKind.Location = new System.Drawing.Point(6, 19);
			this.cmbDocumentKind.Name = "cmbDocumentKind";
			this.cmbDocumentKind.Size = new System.Drawing.Size(478, 21);
			this.cmbDocumentKind.TabIndex = 1;
			this.cmbDocumentKind.Tag = "invoice.idfedocumentkind";
			this.cmbDocumentKind.ValueMember = "idfedocumentkind";
			// 
			// groupBox17
			// 
			this.groupBox17.Controls.Add(this.gboxBollo);
			this.groupBox17.Controls.Add(this.groupBox5);
			this.groupBox17.Controls.Add(this.groupBox7);
			this.groupBox17.Controls.Add(this.groupBox8);
			this.groupBox17.Location = new System.Drawing.Point(6, 245);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new System.Drawing.Size(943, 120);
			this.groupBox17.TabIndex = 49;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Fattura di Vendita";
			// 
			// gboxBollo
			// 
			this.gboxBollo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxBollo.Controls.Add(this.rdbNoBollo);
			this.gboxBollo.Controls.Add(this.rdb19_2014);
			this.gboxBollo.Location = new System.Drawing.Point(6, 74);
			this.gboxBollo.Name = "gboxBollo";
			this.gboxBollo.Size = new System.Drawing.Size(929, 41);
			this.gboxBollo.TabIndex = 44;
			this.gboxBollo.TabStop = false;
			this.gboxBollo.Text = "Bollo";
			// 
			// rdbNoBollo
			// 
			this.rdbNoBollo.AutoSize = true;
			this.rdbNoBollo.Location = new System.Drawing.Point(5, 13);
			this.rdbNoBollo.Name = "rdbNoBollo";
			this.rdbNoBollo.Size = new System.Drawing.Size(157, 17);
			this.rdbNoBollo.TabIndex = 18;
			this.rdbNoBollo.TabStop = true;
			this.rdbNoBollo.Tag = "invoice.idstampkind:no";
			this.rdbNoBollo.Text = "Fattura non soggetta a bollo";
			this.rdbNoBollo.UseVisualStyleBackColor = true;
			// 
			// rdb19_2014
			// 
			this.rdb19_2014.AutoSize = true;
			this.rdb19_2014.Location = new System.Drawing.Point(179, 12);
			this.rdb19_2014.Name = "rdb19_2014";
			this.rdb19_2014.Size = new System.Drawing.Size(567, 17);
			this.rdb19_2014.TabIndex = 17;
			this.rdb19_2014.TabStop = true;
			this.rdb19_2014.Tag = "invoice.idstampkind:dm19_2014";
			this.rdb19_2014.Text = "Fattura soggetta ad imposta di bollo € 2,00 con assolvimento secondo modalità tel" +
    "ematiche del DM 17 giugno 2014";
			this.rdb19_2014.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.cmbCondizioniPagFE);
			this.groupBox5.Location = new System.Drawing.Point(770, 18);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(165, 47);
			this.groupBox5.TabIndex = 41;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Condizioni Pagamento";
			// 
			// cmbCondizioniPagFE
			// 
			this.cmbCondizioniPagFE.DataSource = this.DS.fepaymethodcondition;
			this.cmbCondizioniPagFE.DisplayMember = "description";
			this.cmbCondizioniPagFE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondizioniPagFE.Location = new System.Drawing.Point(3, 17);
			this.cmbCondizioniPagFE.Name = "cmbCondizioniPagFE";
			this.cmbCondizioniPagFE.Size = new System.Drawing.Size(148, 21);
			this.cmbCondizioniPagFE.TabIndex = 0;
			this.cmbCondizioniPagFE.Tag = "invoice.idfepaymethodcondition";
			this.cmbCondizioniPagFE.ValueMember = "idfepaymethodcondition";
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.cmbModPagFE);
			this.groupBox7.Location = new System.Drawing.Point(522, 19);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(242, 47);
			this.groupBox7.TabIndex = 43;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Modalità Pagamento";
			// 
			// cmbModPagFE
			// 
			this.cmbModPagFE.DataSource = this.DS.fepaymethod;
			this.cmbModPagFE.DisplayMember = "description";
			this.cmbModPagFE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbModPagFE.Location = new System.Drawing.Point(6, 19);
			this.cmbModPagFE.Name = "cmbModPagFE";
			this.cmbModPagFE.Size = new System.Drawing.Size(230, 21);
			this.cmbModPagFE.TabIndex = 0;
			this.cmbModPagFE.Tag = "invoice.idfepaymethod";
			this.cmbModPagFE.ValueMember = "idfepaymethod";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.txtEsercTrasmissioneFE);
			this.groupBox8.Controls.Add(this.label41);
			this.groupBox8.Controls.Add(this.label43);
			this.groupBox8.Controls.Add(this.txtNumTrasmissioneFE);
			this.groupBox8.Location = new System.Drawing.Point(11, 19);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(309, 49);
			this.groupBox8.TabIndex = 42;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Trasmissione";
			// 
			// txtEsercTrasmissioneFE
			// 
			this.txtEsercTrasmissioneFE.Location = new System.Drawing.Point(70, 16);
			this.txtEsercTrasmissioneFE.Name = "txtEsercTrasmissioneFE";
			this.txtEsercTrasmissioneFE.Size = new System.Drawing.Size(64, 20);
			this.txtEsercTrasmissioneFE.TabIndex = 14;
			this.txtEsercTrasmissioneFE.Tag = "invoice.yelectronicinvoice.year";
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(149, 15);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(59, 20);
			this.label41.TabIndex = 11;
			this.label41.Text = "Numero";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(6, 18);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(56, 16);
			this.label43.TabIndex = 13;
			this.label43.Text = "Esercizio";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumTrasmissioneFE
			// 
			this.txtNumTrasmissioneFE.Location = new System.Drawing.Point(209, 16);
			this.txtNumTrasmissioneFE.Name = "txtNumTrasmissioneFE";
			this.txtNumTrasmissioneFE.Size = new System.Drawing.Size(87, 20);
			this.txtNumTrasmissioneFE.TabIndex = 12;
			this.txtNumTrasmissioneFE.Tag = "invoice.nelectronicinvoice";
			// 
			// grpLegaleRappresentante
			// 
			this.grpLegaleRappresentante.Controls.Add(this.txtLegaleRappresentante);
			this.grpLegaleRappresentante.Location = new System.Drawing.Point(292, 190);
			this.grpLegaleRappresentante.Name = "grpLegaleRappresentante";
			this.grpLegaleRappresentante.Size = new System.Drawing.Size(657, 49);
			this.grpLegaleRappresentante.TabIndex = 48;
			this.grpLegaleRappresentante.TabStop = false;
			this.grpLegaleRappresentante.Tag = "AutoChoose.txtLegaleRappresentante.lista.(active=\'S\')";
			this.grpLegaleRappresentante.Text = "Legale Rappresentante del Destinatario della Fattura di Vendita o FE acq.Estere";
			// 
			// txtLegaleRappresentante
			// 
			this.txtLegaleRappresentante.Location = new System.Drawing.Point(7, 21);
			this.txtLegaleRappresentante.Name = "txtLegaleRappresentante";
			this.txtLegaleRappresentante.Size = new System.Drawing.Size(642, 20);
			this.txtLegaleRappresentante.TabIndex = 9;
			this.txtLegaleRappresentante.Tag = "registry_sostituto.title?invoiceview.registry_sostituto";
			// 
			// grpDestinatarioVendita
			// 
			this.grpDestinatarioVendita.Controls.Add(this.txtPECFECliente);
			this.grpDestinatarioVendita.Controls.Add(this.label23);
			this.grpDestinatarioVendita.Controls.Add(this.txtEmailFECliente);
			this.grpDestinatarioVendita.Controls.Add(this.label24);
			this.grpDestinatarioVendita.Controls.Add(this.label48);
			this.grpDestinatarioVendita.Controls.Add(this.txtRifamm_ven_cliente);
			this.grpDestinatarioVendita.Controls.Add(this.label47);
			this.grpDestinatarioVendita.Controls.Add(this.txtIpa_ven_cliente);
			this.grpDestinatarioVendita.Location = new System.Drawing.Point(292, 10);
			this.grpDestinatarioVendita.Name = "grpDestinatarioVendita";
			this.grpDestinatarioVendita.Size = new System.Drawing.Size(313, 174);
			this.grpDestinatarioVendita.TabIndex = 47;
			this.grpDestinatarioVendita.TabStop = false;
			this.grpDestinatarioVendita.Text = "Destinatario della Fattura di Vendita";
			// 
			// txtPECFECliente
			// 
			this.txtPECFECliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPECFECliente.Location = new System.Drawing.Point(6, 145);
			this.txtPECFECliente.Name = "txtPECFECliente";
			this.txtPECFECliente.Size = new System.Drawing.Size(300, 20);
			this.txtPECFECliente.TabIndex = 75;
			this.txtPECFECliente.Tag = "invoice.pec_ven_cliente";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(4, 126);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(65, 16);
			this.label23.TabIndex = 76;
			this.label23.Text = "Pec:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEmailFECliente
			// 
			this.txtEmailFECliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailFECliente.Location = new System.Drawing.Point(6, 104);
			this.txtEmailFECliente.Name = "txtEmailFECliente";
			this.txtEmailFECliente.Size = new System.Drawing.Size(301, 20);
			this.txtEmailFECliente.TabIndex = 73;
			this.txtEmailFECliente.Tag = "invoice.email_ven_cliente";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(6, 83);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(65, 16);
			this.label24.TabIndex = 74;
			this.label24.Text = "E-Mail:";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(4, 65);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(150, 18);
			this.label48.TabIndex = 41;
			this.label48.Text = "Riferimento amministrazione";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRifamm_ven_cliente
			// 
			this.txtRifamm_ven_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRifamm_ven_cliente.Location = new System.Drawing.Point(166, 64);
			this.txtRifamm_ven_cliente.Name = "txtRifamm_ven_cliente";
			this.txtRifamm_ven_cliente.Size = new System.Drawing.Size(141, 20);
			this.txtRifamm_ven_cliente.TabIndex = 34;
			this.txtRifamm_ven_cliente.Tag = "invoice.rifamm_ven_cliente";
			// 
			// label47
			// 
			this.label47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label47.Location = new System.Drawing.Point(3, 42);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(201, 17);
			this.label47.TabIndex = 40;
			this.label47.Text = "Codice IPA/Codice destinatario per la FE";
			// 
			// txtIpa_ven_cliente
			// 
			this.txtIpa_ven_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIpa_ven_cliente.Location = new System.Drawing.Point(207, 41);
			this.txtIpa_ven_cliente.Name = "txtIpa_ven_cliente";
			this.txtIpa_ven_cliente.Size = new System.Drawing.Size(99, 20);
			this.txtIpa_ven_cliente.TabIndex = 32;
			this.txtIpa_ven_cliente.Tag = "invoice.ipa_ven_cliente";
			// 
			// grpMittenteVendita
			// 
			this.grpMittenteVendita.Controls.Add(this.grpRifAmmMittenteVendita);
			this.grpMittenteVendita.Controls.Add(this.grpIPAMittenteVendita);
			this.grpMittenteVendita.Location = new System.Drawing.Point(611, 11);
			this.grpMittenteVendita.Name = "grpMittenteVendita";
			this.grpMittenteVendita.Size = new System.Drawing.Size(338, 173);
			this.grpMittenteVendita.TabIndex = 46;
			this.grpMittenteVendita.TabStop = false;
			this.grpMittenteVendita.Text = "Mittente della FE Vendita e FE acq.Estere";
			// 
			// grpRifAmmMittenteVendita
			// 
			this.grpRifAmmMittenteVendita.Controls.Add(this.button3);
			this.grpRifAmmMittenteVendita.Controls.Add(this.txtRifamm_ven_emittente);
			this.grpRifAmmMittenteVendita.Location = new System.Drawing.Point(4, 73);
			this.grpRifAmmMittenteVendita.Name = "grpRifAmmMittenteVendita";
			this.grpRifAmmMittenteVendita.Size = new System.Drawing.Size(326, 45);
			this.grpRifAmmMittenteVendita.TabIndex = 36;
			this.grpRifAmmMittenteVendita.TabStop = false;
			this.grpRifAmmMittenteVendita.Tag = "AutoChoose.txtRifamm_ven_emittente.default";
			this.grpRifAmmMittenteVendita.Text = "Riferimento Amministrazione";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(29, 18);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 38;
			this.button3.Tag = "choose.rifamm_ven_emittente.default";
			this.button3.Text = "Rif.Amm.";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// txtRifamm_ven_emittente
			// 
			this.txtRifamm_ven_emittente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRifamm_ven_emittente.Location = new System.Drawing.Point(126, 19);
			this.txtRifamm_ven_emittente.Name = "txtRifamm_ven_emittente";
			this.txtRifamm_ven_emittente.Size = new System.Drawing.Size(143, 20);
			this.txtRifamm_ven_emittente.TabIndex = 34;
			this.txtRifamm_ven_emittente.Tag = "rifamm_ven_emittente.idsdi_rifamm?x";
			// 
			// grpIPAMittenteVendita
			// 
			this.grpIPAMittenteVendita.Controls.Add(this.button5);
			this.grpIPAMittenteVendita.Controls.Add(this.txtIpa_ven_emittente);
			this.grpIPAMittenteVendita.Location = new System.Drawing.Point(4, 19);
			this.grpIPAMittenteVendita.Name = "grpIPAMittenteVendita";
			this.grpIPAMittenteVendita.Size = new System.Drawing.Size(326, 45);
			this.grpIPAMittenteVendita.TabIndex = 35;
			this.grpIPAMittenteVendita.TabStop = false;
			this.grpIPAMittenteVendita.Tag = "AutoChoose.txtIpa_ven_emittente.default";
			this.grpIPAMittenteVendita.Text = "Codice IPA/Codice destinatario per la FE";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(31, 18);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 37;
			this.button5.Tag = "choose.ipa_ven_emittente.default";
			this.button5.Text = "IPA";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// txtIpa_ven_emittente
			// 
			this.txtIpa_ven_emittente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIpa_ven_emittente.Location = new System.Drawing.Point(126, 20);
			this.txtIpa_ven_emittente.Name = "txtIpa_ven_emittente";
			this.txtIpa_ven_emittente.Size = new System.Drawing.Size(143, 20);
			this.txtIpa_ven_emittente.TabIndex = 32;
			this.txtIpa_ven_emittente.Tag = "ipa_ven_emittente.ipa_fe?x";
			// 
			// grpDestinatarioAcquisto
			// 
			this.grpDestinatarioAcquisto.Controls.Add(this.txtIpa_acq);
			this.grpDestinatarioAcquisto.Controls.Add(this.label51);
			this.grpDestinatarioAcquisto.Controls.Add(this.label52);
			this.grpDestinatarioAcquisto.Controls.Add(this.txtRifamm_acq);
			this.grpDestinatarioAcquisto.Location = new System.Drawing.Point(6, 10);
			this.grpDestinatarioAcquisto.Name = "grpDestinatarioAcquisto";
			this.grpDestinatarioAcquisto.Size = new System.Drawing.Size(279, 95);
			this.grpDestinatarioAcquisto.TabIndex = 45;
			this.grpDestinatarioAcquisto.TabStop = false;
			this.grpDestinatarioAcquisto.Tag = "";
			this.grpDestinatarioAcquisto.Text = "Destinatario della Fattura di Acquisto";
			// 
			// txtIpa_acq
			// 
			this.txtIpa_acq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIpa_acq.Location = new System.Drawing.Point(203, 23);
			this.txtIpa_acq.Name = "txtIpa_acq";
			this.txtIpa_acq.Size = new System.Drawing.Size(70, 20);
			this.txtIpa_acq.TabIndex = 32;
			this.txtIpa_acq.Tag = "invoice.ipa_acq?invoiceview.ipa_acq";
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(5, 20);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(205, 25);
			this.label51.TabIndex = 33;
			this.label51.Text = "Codice IPA/Codice destinatario per la FE";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(1, 68);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(150, 18);
			this.label52.TabIndex = 35;
			this.label52.Text = "Riferimento amministrazione";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRifamm_acq
			// 
			this.txtRifamm_acq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRifamm_acq.Location = new System.Drawing.Point(155, 69);
			this.txtRifamm_acq.Name = "txtRifamm_acq";
			this.txtRifamm_acq.Size = new System.Drawing.Size(122, 20);
			this.txtRifamm_acq.TabIndex = 34;
			this.txtRifamm_acq.Tag = "invoice.rifamm_acq?invoiceview.rifamm_acq";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox18);
			this.tabPage3.Controls.Add(this.grpSdIAcqEstere);
			this.tabPage3.Controls.Add(this.grpSDI_vendita);
			this.tabPage3.Controls.Add(this.grpSDI_acquisto);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(955, 446);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "Trasmissione a SDI";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox18
			// 
			this.groupBox18.Controls.Add(this.btnCheck);
			this.groupBox18.Controls.Add(this.btnInviaSdI);
			this.groupBox18.Location = new System.Drawing.Point(12, 205);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new System.Drawing.Size(372, 60);
			this.groupBox18.TabIndex = 47;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Trasmissione FE acquisto Estere";
			// 
			// btnCheck
			// 
			this.btnCheck.AutoSize = true;
			this.btnCheck.Location = new System.Drawing.Point(15, 28);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(105, 23);
			this.btnCheck.TabIndex = 45;
			this.btnCheck.Text = "Controlla dati";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// btnInviaSdI
			// 
			this.btnInviaSdI.AutoSize = true;
			this.btnInviaSdI.Location = new System.Drawing.Point(175, 29);
			this.btnInviaSdI.Name = "btnInviaSdI";
			this.btnInviaSdI.Size = new System.Drawing.Size(164, 23);
			this.btnInviaSdI.TabIndex = 46;
			this.btnInviaSdI.Text = "Predisponi trasmissione";
			this.btnInviaSdI.UseVisualStyleBackColor = true;
			this.btnInviaSdI.Click += new System.EventHandler(this.btnInviaSdI_Click);
			// 
			// grpSdIAcqEstere
			// 
			this.grpSdIAcqEstere.Controls.Add(this.groupBox13);
			this.grpSdIAcqEstere.Controls.Add(this.groupBox14);
			this.grpSdIAcqEstere.Controls.Add(this.groupBox15);
			this.grpSdIAcqEstere.Controls.Add(this.groupBox16);
			this.grpSdIAcqEstere.Location = new System.Drawing.Point(6, 275);
			this.grpSdIAcqEstere.Name = "grpSdIAcqEstere";
			this.grpSdIAcqEstere.Size = new System.Drawing.Size(381, 149);
			this.grpSdIAcqEstere.TabIndex = 42;
			this.grpSdIAcqEstere.TabStop = false;
			this.grpSdIAcqEstere.Text = "Dati SdI - FE acq.Estere";
			// 
			// groupBox13
			// 
			this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox13.Controls.Add(this.comboStatoTrasmSdiAcqEstere);
			this.groupBox13.Location = new System.Drawing.Point(6, 97);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new System.Drawing.Size(169, 40);
			this.groupBox13.TabIndex = 44;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Stato trasmissione";
			// 
			// comboStatoTrasmSdiAcqEstere
			// 
			this.comboStatoTrasmSdiAcqEstere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboStatoTrasmSdiAcqEstere.DataSource = this.DS.sdi_deliverystatus_acquestere;
			this.comboStatoTrasmSdiAcqEstere.DisplayMember = "description";
			this.comboStatoTrasmSdiAcqEstere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatoTrasmSdiAcqEstere.Location = new System.Drawing.Point(6, 15);
			this.comboStatoTrasmSdiAcqEstere.Name = "comboStatoTrasmSdiAcqEstere";
			this.comboStatoTrasmSdiAcqEstere.Size = new System.Drawing.Size(157, 21);
			this.comboStatoTrasmSdiAcqEstere.TabIndex = 43;
			this.comboStatoTrasmSdiAcqEstere.Tag = "sdi_acquistoestere.idsdi_deliverystatus?invoiceview.idsdi_deliverystatus";
			this.comboStatoTrasmSdiAcqEstere.ValueMember = "idsdi_deliverystatus";
			// 
			// groupBox14
			// 
			this.groupBox14.Controls.Add(this.checkBox3);
			this.groupBox14.Controls.Add(this.checkBox4);
			this.groupBox14.Controls.Add(this.checkBox6);
			this.groupBox14.Location = new System.Drawing.Point(181, 20);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new System.Drawing.Size(194, 91);
			this.groupBox14.TabIndex = 43;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Messaggi ricevuti";
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(7, 68);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(190, 17);
			this.checkBox3.TabIndex = 28;
			this.checkBox3.Tag = "sdi_acquistoestere.flag_unseen:5";
			this.checkBox3.Text = "Ricevuta di impossibilità di recapito";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(6, 46);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(119, 17);
			this.checkBox4.TabIndex = 27;
			this.checkBox4.Tag = "sdi_acquistoestere.flag_unseen:2";
			this.checkBox4.Text = "Ricevuta consegna";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(6, 22);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(105, 17);
			this.checkBox6.TabIndex = 22;
			this.checkBox6.Tag = "sdi_acquistoestere.flag_unseen:0";
			this.checkBox6.Text = "Notifica di scarto";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// groupBox15
			// 
			this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox15.Controls.Add(this.comboStatusAcqEstere);
			this.groupBox15.Location = new System.Drawing.Point(6, 20);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new System.Drawing.Size(169, 40);
			this.groupBox15.TabIndex = 35;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Stato";
			// 
			// comboStatusAcqEstere
			// 
			this.comboStatusAcqEstere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboStatusAcqEstere.DataSource = this.DS.sdi_status_acquestere;
			this.comboStatusAcqEstere.DisplayMember = "description";
			this.comboStatusAcqEstere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboStatusAcqEstere.Location = new System.Drawing.Point(6, 15);
			this.comboStatusAcqEstere.Name = "comboStatusAcqEstere";
			this.comboStatusAcqEstere.Size = new System.Drawing.Size(157, 21);
			this.comboStatusAcqEstere.TabIndex = 43;
			this.comboStatusAcqEstere.Tag = "sdi_acquistoestere.idsdi_status?invoiceview.idsdi_status";
			this.comboStatusAcqEstere.ValueMember = "idsdi_status";
			// 
			// groupBox16
			// 
			this.groupBox16.Controls.Add(this.label59);
			this.groupBox16.Controls.Add(this.textBox11);
			this.groupBox16.Location = new System.Drawing.Point(7, 59);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new System.Drawing.Size(138, 36);
			this.groupBox16.TabIndex = 34;
			this.groupBox16.TabStop = false;
			// 
			// label59
			// 
			this.label59.Location = new System.Drawing.Point(4, 7);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(56, 25);
			this.label59.TabIndex = 9;
			this.label59.Text = "Num.File:";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox11
			// 
			this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox11.Location = new System.Drawing.Point(65, 10);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(71, 20);
			this.textBox11.TabIndex = 8;
			this.textBox11.Tag = "sdi_acquistoestere.idsdi_acquistoestere?invoiceview.idsdi_acquistoestere";
			// 
			// grpSDI_vendita
			// 
			this.grpSDI_vendita.Controls.Add(this.grpStatoTrasmissione);
			this.grpSDI_vendita.Controls.Add(this.groupBox10);
			this.grpSDI_vendita.Controls.Add(this.groupBox9);
			this.grpSDI_vendita.Controls.Add(this.groupBox3);
			this.grpSDI_vendita.Location = new System.Drawing.Point(302, 18);
			this.grpSDI_vendita.Name = "grpSDI_vendita";
			this.grpSDI_vendita.Size = new System.Drawing.Size(514, 168);
			this.grpSDI_vendita.TabIndex = 36;
			this.grpSDI_vendita.TabStop = false;
			this.grpSDI_vendita.Text = "Dati SdI - Vendita";
			// 
			// grpStatoTrasmissione
			// 
			this.grpStatoTrasmissione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpStatoTrasmissione.Controls.Add(this.cmbStatoTrasmissioneSdiVen);
			this.grpStatoTrasmissione.Location = new System.Drawing.Point(12, 103);
			this.grpStatoTrasmissione.Name = "grpStatoTrasmissione";
			this.grpStatoTrasmissione.Size = new System.Drawing.Size(240, 40);
			this.grpStatoTrasmissione.TabIndex = 44;
			this.grpStatoTrasmissione.TabStop = false;
			this.grpStatoTrasmissione.Text = "Stato trasmissione";
			// 
			// cmbStatoTrasmissioneSdiVen
			// 
			this.cmbStatoTrasmissioneSdiVen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatoTrasmissioneSdiVen.DataSource = this.DS.sdi_deliverystatus;
			this.cmbStatoTrasmissioneSdiVen.DisplayMember = "description";
			this.cmbStatoTrasmissioneSdiVen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatoTrasmissioneSdiVen.Location = new System.Drawing.Point(6, 15);
			this.cmbStatoTrasmissioneSdiVen.Name = "cmbStatoTrasmissioneSdiVen";
			this.cmbStatoTrasmissioneSdiVen.Size = new System.Drawing.Size(228, 21);
			this.cmbStatoTrasmissioneSdiVen.TabIndex = 43;
			this.cmbStatoTrasmissioneSdiVen.Tag = "sdi_vendita.idsdi_deliverystatus?invoiceview.idsdi_deliverystatus";
			this.cmbStatoTrasmissioneSdiVen.ValueMember = "idsdi_deliverystatus";
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.chkAT_attestazione);
			this.groupBox10.Controls.Add(this.chkRC_ricevutaconsegna);
			this.groupBox10.Controls.Add(this.chkNE_esitocedente);
			this.groupBox10.Controls.Add(this.chkNS_notificascarto);
			this.groupBox10.Controls.Add(this.checkBox2);
			this.groupBox10.Controls.Add(this.chkMC_mancataconsegna);
			this.groupBox10.Location = new System.Drawing.Point(258, 9);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(247, 143);
			this.groupBox10.TabIndex = 43;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Messaggi ricevuti";
			// 
			// chkAT_attestazione
			// 
			this.chkAT_attestazione.AutoSize = true;
			this.chkAT_attestazione.Location = new System.Drawing.Point(6, 103);
			this.chkAT_attestazione.Name = "chkAT_attestazione";
			this.chkAT_attestazione.Size = new System.Drawing.Size(228, 30);
			this.chkAT_attestazione.TabIndex = 28;
			this.chkAT_attestazione.Tag = "sdi_vendita.flag_unseen:5";
			this.chkAT_attestazione.Text = "Attestazione di avvenuta trasmissione della\r\nfattura al SdI con impossibilità di " +
    "recapito";
			this.chkAT_attestazione.UseVisualStyleBackColor = true;
			// 
			// chkRC_ricevutaconsegna
			// 
			this.chkRC_ricevutaconsegna.AutoSize = true;
			this.chkRC_ricevutaconsegna.Location = new System.Drawing.Point(6, 51);
			this.chkRC_ricevutaconsegna.Name = "chkRC_ricevutaconsegna";
			this.chkRC_ricevutaconsegna.Size = new System.Drawing.Size(119, 17);
			this.chkRC_ricevutaconsegna.TabIndex = 27;
			this.chkRC_ricevutaconsegna.Tag = "sdi_vendita.flag_unseen:2";
			this.chkRC_ricevutaconsegna.Text = "Ricevuta consegna";
			this.chkRC_ricevutaconsegna.UseVisualStyleBackColor = true;
			// 
			// chkNE_esitocedente
			// 
			this.chkNE_esitocedente.AutoSize = true;
			this.chkNE_esitocedente.Location = new System.Drawing.Point(6, 70);
			this.chkNE_esitocedente.Name = "chkNE_esitocedente";
			this.chkNE_esitocedente.Size = new System.Drawing.Size(129, 17);
			this.chkNE_esitocedente.TabIndex = 26;
			this.chkNE_esitocedente.Tag = "sdi_vendita.flag_unseen:3";
			this.chkNE_esitocedente.Text = "Notifica esito cedente";
			this.chkNE_esitocedente.UseVisualStyleBackColor = true;
			// 
			// chkNS_notificascarto
			// 
			this.chkNS_notificascarto.AutoSize = true;
			this.chkNS_notificascarto.Location = new System.Drawing.Point(6, 17);
			this.chkNS_notificascarto.Name = "chkNS_notificascarto";
			this.chkNS_notificascarto.Size = new System.Drawing.Size(105, 17);
			this.chkNS_notificascarto.TabIndex = 22;
			this.chkNS_notificascarto.Tag = "sdi_vendita.flag_unseen:0";
			this.chkNS_notificascarto.Text = "Notifica di scarto";
			this.chkNS_notificascarto.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(6, 87);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(151, 17);
			this.checkBox2.TabIndex = 25;
			this.checkBox2.Tag = "sdi_vendita.flag_unseen:4";
			this.checkBox2.Text = "Notifica decorrenza termini";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// chkMC_mancataconsegna
			// 
			this.chkMC_mancataconsegna.AutoSize = true;
			this.chkMC_mancataconsegna.Location = new System.Drawing.Point(6, 34);
			this.chkMC_mancataconsegna.Name = "chkMC_mancataconsegna";
			this.chkMC_mancataconsegna.Size = new System.Drawing.Size(167, 17);
			this.chkMC_mancataconsegna.TabIndex = 24;
			this.chkMC_mancataconsegna.Tag = "sdi_vendita.flag_unseen:1";
			this.chkMC_mancataconsegna.Text = "Notifica di mancata consegna";
			this.chkMC_mancataconsegna.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.cmbStatusVendita);
			this.groupBox9.Location = new System.Drawing.Point(6, 20);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new System.Drawing.Size(130, 40);
			this.groupBox9.TabIndex = 35;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Stato";
			// 
			// cmbStatusVendita
			// 
			this.cmbStatusVendita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatusVendita.DataSource = this.DS.sdi_statusvendita;
			this.cmbStatusVendita.DisplayMember = "description";
			this.cmbStatusVendita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatusVendita.Location = new System.Drawing.Point(6, 15);
			this.cmbStatusVendita.Name = "cmbStatusVendita";
			this.cmbStatusVendita.Size = new System.Drawing.Size(118, 21);
			this.cmbStatusVendita.TabIndex = 43;
			this.cmbStatusVendita.Tag = "sdi_vendita.idsdi_status?invoiceview.idsdi_status";
			this.cmbStatusVendita.ValueMember = "idsdi_status";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label50);
			this.groupBox3.Controls.Add(this.textBox9);
			this.groupBox3.Location = new System.Drawing.Point(12, 66);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(138, 36);
			this.groupBox3.TabIndex = 34;
			this.groupBox3.TabStop = false;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(6, 7);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(56, 25);
			this.label50.TabIndex = 9;
			this.label50.Text = "Num.File:";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox9
			// 
			this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox9.Location = new System.Drawing.Point(65, 10);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(71, 20);
			this.textBox9.TabIndex = 8;
			this.textBox9.Tag = "sdi_vendita.idsdi_vendita?invoiceview.idsdi_vendita";
			// 
			// grpSDI_acquisto
			// 
			this.grpSDI_acquisto.Controls.Add(this.gboxStatoSdi);
			this.grpSDI_acquisto.Controls.Add(this.grpIdSsi);
			this.grpSDI_acquisto.Controls.Add(this.grpMessaggi);
			this.grpSDI_acquisto.Location = new System.Drawing.Point(21, 18);
			this.grpSDI_acquisto.Name = "grpSDI_acquisto";
			this.grpSDI_acquisto.Size = new System.Drawing.Size(238, 168);
			this.grpSDI_acquisto.TabIndex = 35;
			this.grpSDI_acquisto.TabStop = false;
			this.grpSDI_acquisto.Text = "Dati SdI - Acquisto";
			// 
			// gboxStatoSdi
			// 
			this.gboxStatoSdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxStatoSdi.Controls.Add(this.cmbStatusAcquito);
			this.gboxStatoSdi.Location = new System.Drawing.Point(6, 19);
			this.gboxStatoSdi.Name = "gboxStatoSdi";
			this.gboxStatoSdi.Size = new System.Drawing.Size(226, 40);
			this.gboxStatoSdi.TabIndex = 27;
			this.gboxStatoSdi.TabStop = false;
			this.gboxStatoSdi.Text = "Stato";
			// 
			// cmbStatusAcquito
			// 
			this.cmbStatusAcquito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatusAcquito.DataSource = this.DS.sdi_status;
			this.cmbStatusAcquito.DisplayMember = "description";
			this.cmbStatusAcquito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatusAcquito.Location = new System.Drawing.Point(6, 15);
			this.cmbStatusAcquito.Name = "cmbStatusAcquito";
			this.cmbStatusAcquito.Size = new System.Drawing.Size(214, 21);
			this.cmbStatusAcquito.TabIndex = 43;
			this.cmbStatusAcquito.Tag = "sdi_acquisto.idsdi_status?invoiceview.idsdi_status";
			this.cmbStatusAcquito.ValueMember = "idsdi_status";
			// 
			// grpIdSsi
			// 
			this.grpIdSsi.Controls.Add(this.label49);
			this.grpIdSsi.Controls.Add(this.txtNumFile);
			this.grpIdSsi.Location = new System.Drawing.Point(7, 56);
			this.grpIdSsi.Name = "grpIdSsi";
			this.grpIdSsi.Size = new System.Drawing.Size(147, 36);
			this.grpIdSsi.TabIndex = 33;
			this.grpIdSsi.TabStop = false;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(5, 7);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(56, 25);
			this.label49.TabIndex = 9;
			this.label49.Text = "Num.File:";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtNumFile
			// 
			this.txtNumFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumFile.Location = new System.Drawing.Point(65, 10);
			this.txtNumFile.Name = "txtNumFile";
			this.txtNumFile.Size = new System.Drawing.Size(71, 20);
			this.txtNumFile.TabIndex = 8;
			this.txtNumFile.Tag = "sdi_acquisto.idsdi_acquisto?invoiceview.idsdi_acquisto";
			// 
			// grpMessaggi
			// 
			this.grpMessaggi.Controls.Add(this.chkDT_decorrenzatermini);
			this.grpMessaggi.Controls.Add(this.chkSE_scartoesitocommittente);
			this.grpMessaggi.Location = new System.Drawing.Point(7, 93);
			this.grpMessaggi.Name = "grpMessaggi";
			this.grpMessaggi.Size = new System.Drawing.Size(222, 63);
			this.grpMessaggi.TabIndex = 32;
			this.grpMessaggi.TabStop = false;
			this.grpMessaggi.Text = "Messaggi ricevuti";
			// 
			// chkDT_decorrenzatermini
			// 
			this.chkDT_decorrenzatermini.AutoSize = true;
			this.chkDT_decorrenzatermini.Location = new System.Drawing.Point(6, 39);
			this.chkDT_decorrenzatermini.Name = "chkDT_decorrenzatermini";
			this.chkDT_decorrenzatermini.Size = new System.Drawing.Size(151, 17);
			this.chkDT_decorrenzatermini.TabIndex = 25;
			this.chkDT_decorrenzatermini.Tag = "sdi_acquisto.flag_unseen:3?invoiceview.flag_unseen:3";
			this.chkDT_decorrenzatermini.Text = "Notifica decorrenza termini";
			this.chkDT_decorrenzatermini.UseVisualStyleBackColor = true;
			// 
			// chkSE_scartoesitocommittente
			// 
			this.chkSE_scartoesitocommittente.AutoSize = true;
			this.chkSE_scartoesitocommittente.Location = new System.Drawing.Point(6, 19);
			this.chkSE_scartoesitocommittente.Name = "chkSE_scartoesitocommittente";
			this.chkSE_scartoesitocommittente.Size = new System.Drawing.Size(190, 17);
			this.chkSE_scartoesitocommittente.TabIndex = 24;
			this.chkSE_scartoesitocommittente.Tag = "sdi_acquisto.flag_unseen:2?invoiceview.flag_unseen:2";
			this.chkSE_scartoesitocommittente.Text = "Notifica di scarto esito committente";
			this.chkSE_scartoesitocommittente.UseVisualStyleBackColor = true;
			// 
			// tabRegistroUnico
			// 
			this.tabRegistroUnico.Controls.Add(this.label46);
			this.tabRegistroUnico.Controls.Add(this.dgrPCC);
			this.tabRegistroUnico.Controls.Add(this.checkBox1);
			this.tabRegistroUnico.Controls.Add(this.grpRegistroUnico);
			this.tabRegistroUnico.Location = new System.Drawing.Point(4, 22);
			this.tabRegistroUnico.Name = "tabRegistroUnico";
			this.tabRegistroUnico.Size = new System.Drawing.Size(981, 478);
			this.tabRegistroUnico.TabIndex = 13;
			this.tabRegistroUnico.Text = "Reg.Unico";
			this.tabRegistroUnico.UseVisualStyleBackColor = true;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(8, 220);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(258, 20);
			this.label46.TabIndex = 28;
			this.label46.Text = "Trasmissione PCC";
			// 
			// dgrPCC
			// 
			this.dgrPCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPCC.DataMember = "";
			this.dgrPCC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPCC.Location = new System.Drawing.Point(8, 243);
			this.dgrPCC.Name = "dgrPCC";
			this.dgrPCC.Size = new System.Drawing.Size(947, 211);
			this.dgrPCC.TabIndex = 27;
			this.dgrPCC.Tag = "pccview.invoice";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(11, 185);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(151, 17);
			this.checkBox1.TabIndex = 26;
			this.checkBox1.Tag = "invoice.resendingpcc:S:N";
			this.checkBox1.Text = "Ritrasmetti fattura alla PCC";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// grpRegistroUnico
			// 
			this.grpRegistroUnico.Controls.Add(this.btnModStatodelDebito);
			this.grpRegistroUnico.Controls.Add(this.btnCreaRegistroUnico);
			this.grpRegistroUnico.Controls.Add(this.txtProgressivoRU);
			this.grpRegistroUnico.Controls.Add(this.label45);
			this.grpRegistroUnico.Controls.Add(this.label13);
			this.grpRegistroUnico.Controls.Add(this.txtProtocolloEntrataRU);
			this.grpRegistroUnico.Controls.Add(this.txtAnnotazioniRU);
			this.grpRegistroUnico.Controls.Add(this.label44);
			this.grpRegistroUnico.Location = new System.Drawing.Point(8, 3);
			this.grpRegistroUnico.Name = "grpRegistroUnico";
			this.grpRegistroUnico.Size = new System.Drawing.Size(861, 166);
			this.grpRegistroUnico.TabIndex = 1;
			this.grpRegistroUnico.TabStop = false;
			// 
			// btnModStatodelDebito
			// 
			this.btnModStatodelDebito.Location = new System.Drawing.Point(220, 133);
			this.btnModStatodelDebito.Name = "btnModStatodelDebito";
			this.btnModStatodelDebito.Size = new System.Drawing.Size(144, 23);
			this.btnModStatodelDebito.TabIndex = 21;
			this.btnModStatodelDebito.Text = "Modifica Stato del Debito";
			this.btnModStatodelDebito.UseVisualStyleBackColor = true;
			this.btnModStatodelDebito.Click += new System.EventHandler(this.btnModStatodelDebito_Click);
			// 
			// btnCreaRegistroUnico
			// 
			this.btnCreaRegistroUnico.Location = new System.Drawing.Point(656, 133);
			this.btnCreaRegistroUnico.Name = "btnCreaRegistroUnico";
			this.btnCreaRegistroUnico.Size = new System.Drawing.Size(190, 23);
			this.btnCreaRegistroUnico.TabIndex = 3;
			this.btnCreaRegistroUnico.Text = "Protocolla nel Registro Unico";
			this.btnCreaRegistroUnico.UseVisualStyleBackColor = true;
			this.btnCreaRegistroUnico.Click += new System.EventHandler(this.btnCreaRegistroUnico_Click);
			// 
			// txtProgressivoRU
			// 
			this.txtProgressivoRU.Location = new System.Drawing.Point(220, 30);
			this.txtProgressivoRU.Name = "txtProgressivoRU";
			this.txtProgressivoRU.Size = new System.Drawing.Size(87, 20);
			this.txtProgressivoRU.TabIndex = 14;
			this.txtProgressivoRU.TabStop = false;
			this.txtProgressivoRU.Tag = "uniqueregister.iduniqueregister?invoiceview.iduniqueregister";
			this.txtProgressivoRU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(16, 29);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(187, 20);
			this.label45.TabIndex = 13;
			this.label45.Text = "Codice progressivo di registrazione";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(35, 59);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(173, 20);
			this.label13.TabIndex = 8;
			this.label13.Text = "Numero protocollo di entrata";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProtocolloEntrataRU
			// 
			this.txtProtocolloEntrataRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProtocolloEntrataRU.Location = new System.Drawing.Point(220, 59);
			this.txtProtocolloEntrataRU.Name = "txtProtocolloEntrataRU";
			this.txtProtocolloEntrataRU.Size = new System.Drawing.Size(290, 20);
			this.txtProtocolloEntrataRU.TabIndex = 1;
			this.txtProtocolloEntrataRU.Tag = "invoice.arrivalprotocolnum";
			// 
			// txtAnnotazioniRU
			// 
			this.txtAnnotazioniRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnnotazioniRU.Location = new System.Drawing.Point(516, 47);
			this.txtAnnotazioniRU.Multiline = true;
			this.txtAnnotazioniRU.Name = "txtAnnotazioniRU";
			this.txtAnnotazioniRU.Size = new System.Drawing.Size(339, 70);
			this.txtAnnotazioniRU.TabIndex = 2;
			this.txtAnnotazioniRU.Tag = "invoice.annotations";
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(513, 28);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(81, 16);
			this.label44.TabIndex = 12;
			this.label44.Text = "Annotazioni";
			// 
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dataGrid3);
			this.tabAllegati.Controls.Add(this.btnDelAtt);
			this.tabAllegati.Controls.Add(this.btnEditAtt);
			this.tabAllegati.Controls.Add(this.btnInsAtt);
			this.tabAllegati.Location = new System.Drawing.Point(4, 22);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabAllegati.Size = new System.Drawing.Size(981, 478);
			this.tabAllegati.TabIndex = 14;
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
			this.dataGrid3.Location = new System.Drawing.Point(6, 36);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.ReadOnly = true;
			this.dataGrid3.Size = new System.Drawing.Size(949, 434);
			this.dataGrid3.TabIndex = 23;
			this.dataGrid3.Tag = "invoiceattachment.lista.default";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(166, 6);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 24);
			this.btnDelAtt.TabIndex = 22;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(86, 6);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(69, 24);
			this.btnEditAtt.TabIndex = 21;
			this.btnEditAtt.Tag = "edit.default";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(6, 6);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 24);
			this.btnInsAtt.TabIndex = 20;
			this.btnInsAtt.Tag = "insert.default";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// tabTesseraSSN
			// 
			this.tabTesseraSSN.Controls.Add(this.label53);
			this.tabTesseraSSN.Controls.Add(this.gboxTesseraSSN);
			this.tabTesseraSSN.Location = new System.Drawing.Point(4, 22);
			this.tabTesseraSSN.Name = "tabTesseraSSN";
			this.tabTesseraSSN.Padding = new System.Windows.Forms.Padding(3);
			this.tabTesseraSSN.Size = new System.Drawing.Size(981, 478);
			this.tabTesseraSSN.TabIndex = 15;
			this.tabTesseraSSN.Text = "TesseraSanitaria";
			this.tabTesseraSSN.UseVisualStyleBackColor = true;
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(8, 22);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(364, 13);
			this.label53.TabIndex = 1;
			this.label53.Text = "Dati necessari per Progetto Tessera Sanitaria art. 3 comma 3 D.ls 175/2014";
			// 
			// gboxTesseraSSN
			// 
			this.gboxTesseraSSN.Controls.Add(this.chkIntraMoenia);
			this.gboxTesseraSSN.Controls.Add(this.chkTicket);
			this.gboxTesseraSSN.Controls.Add(this.radioButton10);
			this.gboxTesseraSSN.Controls.Add(this.radioButton9);
			this.gboxTesseraSSN.Controls.Add(this.radioButton8);
			this.gboxTesseraSSN.Controls.Add(this.radioButton7);
			this.gboxTesseraSSN.Controls.Add(this.rdbSpesePrestazioni);
			this.gboxTesseraSSN.Controls.Add(this.radioButton5);
			this.gboxTesseraSSN.Controls.Add(this.radioButton4);
			this.gboxTesseraSSN.Controls.Add(this.radioButton3);
			this.gboxTesseraSSN.Controls.Add(this.radioButton2);
			this.gboxTesseraSSN.Controls.Add(this.rdbTicket);
			this.gboxTesseraSSN.Location = new System.Drawing.Point(8, 38);
			this.gboxTesseraSSN.Name = "gboxTesseraSSN";
			this.gboxTesseraSSN.Size = new System.Drawing.Size(923, 341);
			this.gboxTesseraSSN.TabIndex = 0;
			this.gboxTesseraSSN.TabStop = false;
			this.gboxTesseraSSN.Text = "tipoSpesa";
			// 
			// chkIntraMoenia
			// 
			this.chkIntraMoenia.AutoSize = true;
			this.chkIntraMoenia.Enabled = false;
			this.chkIntraMoenia.Location = new System.Drawing.Point(751, 163);
			this.chkIntraMoenia.Name = "chkIntraMoenia";
			this.chkIntraMoenia.Size = new System.Drawing.Size(119, 17);
			this.chkIntraMoenia.TabIndex = 29;
			this.chkIntraMoenia.Tag = "";
			this.chkIntraMoenia.Text = "Visita in intramoenia";
			this.chkIntraMoenia.UseVisualStyleBackColor = true;
			// 
			// chkTicket
			// 
			this.chkTicket.AutoSize = true;
			this.chkTicket.Enabled = false;
			this.chkTicket.Location = new System.Drawing.Point(557, 19);
			this.chkTicket.Name = "chkTicket";
			this.chkTicket.Size = new System.Drawing.Size(146, 17);
			this.chkTicket.TabIndex = 28;
			this.chkTicket.Tag = "invoice.ssnflagtipospesa:T:N";
			this.chkTicket.Text = "Ticket di pronto soccorso";
			this.chkTicket.UseVisualStyleBackColor = true;
			// 
			// radioButton10
			// 
			this.radioButton10.AutoSize = true;
			this.radioButton10.Location = new System.Drawing.Point(6, 276);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(77, 17);
			this.radioButton10.TabIndex = 9;
			this.radioButton10.TabStop = true;
			this.radioButton10.Tag = "invoice.ssntipospesa:AA";
			this.radioButton10.Text = "Altre spese";
			this.radioButton10.UseVisualStyleBackColor = true;
			this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
			// 
			// radioButton9
			// 
			this.radioButton9.AutoSize = true;
			this.radioButton9.Location = new System.Drawing.Point(6, 253);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(298, 17);
			this.radioButton9.TabIndex = 8;
			this.radioButton9.TabStop = true;
			this.radioButton9.Tag = "invoice.ssntipospesa:IC";
			this.radioButton9.Text = "Intervento di chirurgia estetica ambulatoriale o ospedaliero";
			this.radioButton9.UseVisualStyleBackColor = true;
			this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(6, 230);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(129, 17);
			this.radioButton8.TabIndex = 7;
			this.radioButton8.TabStop = true;
			this.radioButton8.Tag = "invoice.ssntipospesa:PI";
			this.radioButton8.Text = "protesica e integrativa";
			this.radioButton8.UseVisualStyleBackColor = true;
			this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(6, 207);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(84, 17);
			this.radioButton7.TabIndex = 6;
			this.radioButton7.TabStop = true;
			this.radioButton7.Tag = "invoice.ssntipospesa:CT";
			this.radioButton7.Text = "Cure Termali";
			this.radioButton7.UseVisualStyleBackColor = true;
			this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
			// 
			// rdbSpesePrestazioni
			// 
			this.rdbSpesePrestazioni.Location = new System.Drawing.Point(6, 139);
			this.rdbSpesePrestazioni.Name = "rdbSpesePrestazioni";
			this.rdbSpesePrestazioni.Size = new System.Drawing.Size(718, 62);
			this.rdbSpesePrestazioni.TabIndex = 5;
			this.rdbSpesePrestazioni.TabStop = true;
			this.rdbSpesePrestazioni.Tag = "invoice.ssntipospesa:SR";
			this.rdbSpesePrestazioni.Text = resources.GetString("rdbSpesePrestazioni.Text");
			this.rdbSpesePrestazioni.UseVisualStyleBackColor = true;
			this.rdbSpesePrestazioni.CheckedChanged += new System.EventHandler(this.rdbSpesePrestazioni_CheckedChanged);
			// 
			// radioButton5
			// 
			this.radioButton5.AutoEllipsis = true;
			this.radioButton5.Location = new System.Drawing.Point(6, 111);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(893, 32);
			this.radioButton5.TabIndex = 4;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "invoice.ssntipospesa:AS";
			this.radioButton5.Text = resources.GetString("radioButton5.Text");
			this.radioButton5.UseVisualStyleBackColor = true;
			this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(6, 88);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(221, 17);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.TabStop = true;
			this.radioButton4.Tag = "invoice.ssntipospesa:AD";
			this.radioButton4.Text = "Acquisto o affitto di dispositivo medico CE";
			this.radioButton4.UseVisualStyleBackColor = true;
			this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 65);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(156, 17);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "invoice.ssntipospesa:FV";
			this.radioButton3.Text = "Farmaco per uso veterinario";
			this.radioButton3.UseVisualStyleBackColor = true;
			this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 42);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(263, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "invoice.ssntipospesa:FC";
			this.radioButton2.Text = "Farmaco, anche omeopatico. Dispositivi medici CE";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// rdbTicket
			// 
			this.rdbTicket.AutoSize = true;
			this.rdbTicket.Location = new System.Drawing.Point(6, 19);
			this.rdbTicket.Name = "rdbTicket";
			this.rdbTicket.Size = new System.Drawing.Size(536, 17);
			this.rdbTicket.TabIndex = 0;
			this.rdbTicket.TabStop = true;
			this.rdbTicket.Tag = "invoice.ssntipospesa:TK";
			this.rdbTicket.Text = "Ticket (Quota fissa e/o Differenza con il prezzo di riferimento. Franchigia. Pron" +
    "to Soccorso e accesso diretto)";
			this.rdbTicket.UseVisualStyleBackColor = true;
			this.rdbTicket.CheckedChanged += new System.EventHandler(this.rdbTicket_CheckedChanged);
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.groupBox11);
			this.tabAltro.Controls.Add(this.label58);
			this.tabAltro.Controls.Add(this.dgrCarichiCespite);
			this.tabAltro.Controls.Add(this.gboxBolleDoganali);
			this.tabAltro.Controls.Add(this.grpComunicazioneBlackList);
			this.tabAltro.Controls.Add(this.grpCertificatiNecessari);
			this.tabAltro.Location = new System.Drawing.Point(4, 22);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Padding = new System.Windows.Forms.Padding(3);
			this.tabAltro.Size = new System.Drawing.Size(981, 478);
			this.tabAltro.TabIndex = 9;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox11.Controls.Add(this.txtNocigmotive);
			this.groupBox11.Controls.Add(this.btnEsclusioneCIG);
			this.groupBox11.Location = new System.Drawing.Point(5, 410);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(926, 58);
			this.groupBox11.TabIndex = 32;
			this.groupBox11.TabStop = false;
			this.groupBox11.Tag = "AutoChoose.txtNocigmotive.default.(active = \'S\')";
			this.groupBox11.Text = "Motivo esclusione CIG";
			// 
			// txtNocigmotive
			// 
			this.txtNocigmotive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtNocigmotive.Location = new System.Drawing.Point(117, 26);
			this.txtNocigmotive.Name = "txtNocigmotive";
			this.txtNocigmotive.Size = new System.Drawing.Size(803, 20);
			this.txtNocigmotive.TabIndex = 2;
			this.txtNocigmotive.Tag = "nocigmotive.codenocigmotive?x";
			// 
			// btnEsclusioneCIG
			// 
			this.btnEsclusioneCIG.Location = new System.Drawing.Point(5, 24);
			this.btnEsclusioneCIG.Name = "btnEsclusioneCIG";
			this.btnEsclusioneCIG.Size = new System.Drawing.Size(104, 24);
			this.btnEsclusioneCIG.TabIndex = 0;
			this.btnEsclusioneCIG.TabStop = false;
			this.btnEsclusioneCIG.Tag = "choose.nocigmotive.default";
			this.btnEsclusioneCIG.Text = "Motivo";
			this.btnEsclusioneCIG.UseVisualStyleBackColor = true;
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(7, 166);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(164, 16);
			this.label58.TabIndex = 31;
			this.label58.Text = "Elenco carichi cespite associati";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgrCarichiCespite
			// 
			this.dgrCarichiCespite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrCarichiCespite.DataMember = "";
			this.dgrCarichiCespite.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrCarichiCespite.Location = new System.Drawing.Point(8, 185);
			this.dgrCarichiCespite.Name = "dgrCarichiCespite";
			this.dgrCarichiCespite.Size = new System.Drawing.Size(536, 135);
			this.dgrCarichiCespite.TabIndex = 30;
			this.dgrCarichiCespite.Tag = "assetacquire.carichifattura";
			// 
			// gboxBolleDoganali
			// 
			this.gboxBolleDoganali.Controls.Add(this.btnRemoveBollaDoganale);
			this.gboxBolleDoganali.Controls.Add(this.dgrBolleDoganali);
			this.gboxBolleDoganali.Location = new System.Drawing.Point(8, 16);
			this.gboxBolleDoganali.Name = "gboxBolleDoganali";
			this.gboxBolleDoganali.Size = new System.Drawing.Size(509, 142);
			this.gboxBolleDoganali.TabIndex = 23;
			this.gboxBolleDoganali.TabStop = false;
			this.gboxBolleDoganali.Text = "Bolle doganali";
			// 
			// btnRemoveBollaDoganale
			// 
			this.btnRemoveBollaDoganale.Location = new System.Drawing.Point(8, 41);
			this.btnRemoveBollaDoganale.Name = "btnRemoveBollaDoganale";
			this.btnRemoveBollaDoganale.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveBollaDoganale.TabIndex = 4;
			this.btnRemoveBollaDoganale.Text = "Rimuovi";
			this.btnRemoveBollaDoganale.Click += new System.EventHandler(this.btnScollegaBollettaDoganale_Click);
			// 
			// dgrBolleDoganali
			// 
			this.dgrBolleDoganali.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrBolleDoganali.DataMember = "";
			this.dgrBolleDoganali.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrBolleDoganali.Location = new System.Drawing.Point(96, 16);
			this.dgrBolleDoganali.Name = "dgrBolleDoganali";
			this.dgrBolleDoganali.Size = new System.Drawing.Size(407, 117);
			this.dgrBolleDoganali.TabIndex = 2;
			this.dgrBolleDoganali.Tag = "invoice_bolladoganale.bolladoganale";
			// 
			// grpComunicazioneBlackList
			// 
			this.grpComunicazioneBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.grpComunicazioneBlackList.Controls.Add(this.label57);
			this.grpComunicazioneBlackList.Controls.Add(this.txtBlCode);
			this.grpComunicazioneBlackList.Controls.Add(this.cmb_BlackList);
			this.grpComunicazioneBlackList.Controls.Add(this.rdbNonEffettuare);
			this.grpComunicazioneBlackList.Controls.Add(this.rdbEffettuare);
			this.grpComunicazioneBlackList.Controls.Add(this.rdbNonSpec);
			this.grpComunicazioneBlackList.Location = new System.Drawing.Point(8, 326);
			this.grpComunicazioneBlackList.Name = "grpComunicazioneBlackList";
			this.grpComunicazioneBlackList.Size = new System.Drawing.Size(509, 78);
			this.grpComunicazioneBlackList.TabIndex = 22;
			this.grpComunicazioneBlackList.TabStop = false;
			this.grpComunicazioneBlackList.Text = "Blacklist";
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(9, 23);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(305, 13);
			this.label57.TabIndex = 40;
			this.label57.Text = "Comunicazione delle operazioni con Paesi a fiscalità privilegiata";
			// 
			// txtBlCode
			// 
			this.txtBlCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBlCode.Location = new System.Drawing.Point(452, 47);
			this.txtBlCode.Name = "txtBlCode";
			this.txtBlCode.ReadOnly = true;
			this.txtBlCode.Size = new System.Drawing.Size(50, 20);
			this.txtBlCode.TabIndex = 39;
			this.txtBlCode.Tag = "blacklist.blcode?invoiceview.blcode";
			// 
			// cmb_BlackList
			// 
			this.cmb_BlackList.DataSource = this.DS.blacklist;
			this.cmb_BlackList.DisplayMember = "description";
			this.cmb_BlackList.FormattingEnabled = true;
			this.cmb_BlackList.Location = new System.Drawing.Point(297, 47);
			this.cmb_BlackList.Name = "cmb_BlackList";
			this.cmb_BlackList.Size = new System.Drawing.Size(150, 21);
			this.cmb_BlackList.TabIndex = 38;
			this.cmb_BlackList.Tag = "invoice.idblacklist??invoiceview.idblacklist";
			this.cmb_BlackList.ValueMember = "idblacklist";
			// 
			// rdbNonEffettuare
			// 
			this.rdbNonEffettuare.AutoSize = true;
			this.rdbNonEffettuare.Location = new System.Drawing.Point(90, 46);
			this.rdbNonEffettuare.Name = "rdbNonEffettuare";
			this.rdbNonEffettuare.Size = new System.Drawing.Size(93, 17);
			this.rdbNonEffettuare.TabIndex = 37;
			this.rdbNonEffettuare.TabStop = true;
			this.rdbNonEffettuare.Tag = "invoice.flag:1?invoiceview.flag_invoice:1";
			this.rdbNonEffettuare.Text = "Non effettuare";
			this.rdbNonEffettuare.UseVisualStyleBackColor = true;
			// 
			// rdbEffettuare
			// 
			this.rdbEffettuare.AutoSize = true;
			this.rdbEffettuare.Location = new System.Drawing.Point(11, 46);
			this.rdbEffettuare.Name = "rdbEffettuare";
			this.rdbEffettuare.Size = new System.Drawing.Size(71, 17);
			this.rdbEffettuare.TabIndex = 36;
			this.rdbEffettuare.TabStop = true;
			this.rdbEffettuare.Tag = "invoice.flag:0?invoiceview.flag_invoice:0";
			this.rdbEffettuare.Text = "Effettuare";
			this.rdbEffettuare.UseVisualStyleBackColor = true;
			this.rdbEffettuare.CheckedChanged += new System.EventHandler(this.rdbEffettuare_CheckedChanged);
			// 
			// rdbNonSpec
			// 
			this.rdbNonSpec.AutoSize = true;
			this.rdbNonSpec.Location = new System.Drawing.Point(195, 46);
			this.rdbNonSpec.Name = "rdbNonSpec";
			this.rdbNonSpec.Size = new System.Drawing.Size(99, 17);
			this.rdbNonSpec.TabIndex = 35;
			this.rdbNonSpec.TabStop = true;
			this.rdbNonSpec.Tag = "invoice.flag:2?invoiceview.flag_invoice:2";
			this.rdbNonSpec.Text = "Non specificato";
			this.rdbNonSpec.UseVisualStyleBackColor = true;
			// 
			// CMenu
			// 
			this.CMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuEnterPwd});
			// 
			// MenuEnterPwd
			// 
			this.MenuEnterPwd.Index = 0;
			this.MenuEnterPwd.Text = "Visualizza tracciato";
			this.MenuEnterPwd.Click += new System.EventHandler(this.MenuEnterPwd_Click);
			// 
			// Frm_invoice_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(989, 504);
			this.Controls.Add(this.tabControl1);
			this.Name = "Frm_invoice_default";
			this.Text = "frmdocumentoiva";
			this.Load += new System.EventHandler(this.Frm_invoice_default_Load);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabClassificazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).EndInit();
			this.tabEP.ResumeLayout(false);
			this.tabEP.PerformLayout();
			this.gboxCausaleCrg.ResumeLayout(false);
			this.gboxCausaleCrg.PerformLayout();
			this.gboxCausale.ResumeLayout(false);
			this.gboxCausale.PerformLayout();
			this.tabLiquidazioni.ResumeLayout(false);
			this.tabLiquidazioni.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.tabRegistri.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPageDettagli.ResumeLayout(false);
			this.tabPageDettagli.PerformLayout();
			this.gboxProfessionale.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.grpInvSpedizioniere.ResumeLayout(false);
			this.grpInvSpedizioniere.PerformLayout();
			this.grp_Split_Payment.ResumeLayout(false);
			this.grp_Split_Payment.PerformLayout();
			this.grpTesorierePerIncasso.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.gboxvaluta.ResumeLayout(false);
			this.gboxvaluta.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxAnagrafica.ResumeLayout(false);
			this.gboxAnagrafica.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.frpDocumento.ResumeLayout(false);
			this.frpDocumento.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabIntrastat.ResumeLayout(false);
			this.tabIntrastat.PerformLayout();
			this.gboxtipofattura.ResumeLayout(false);
			this.gboxtipofattura.PerformLayout();
			this.gboxIntraInfoServizi.ResumeLayout(false);
			this.gboxIntraInfoServizi.PerformLayout();
			this.gboxIntraInfoBeni.ResumeLayout(false);
			this.gboxNatura.ResumeLayout(false);
			this.gboxNatura.PerformLayout();
			this.gboxintra_vendite.ResumeLayout(false);
			this.gboxintra_vendite.PerformLayout();
			this.gboxintra_acquisti.ResumeLayout(false);
			this.gboxintra_acquisti.PerformLayout();
			this.tabMagazzino.ResumeLayout(false);
			this.tabMagazzino.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
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
			this.tabPageAutofattura.ResumeLayout(false);
			this.tabPageAutofattura.PerformLayout();
			this.grpInvReal.ResumeLayout(false);
			this.grpInvReal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDettagliFattura)).EndInit();
			this.tabFE.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.grpFEAcquistoEstere.ResumeLayout(false);
			this.grpDenominazione.ResumeLayout(false);
			this.grpDocumentKind.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			this.gboxBollo.ResumeLayout(false);
			this.gboxBollo.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.grpLegaleRappresentante.ResumeLayout(false);
			this.grpLegaleRappresentante.PerformLayout();
			this.grpDestinatarioVendita.ResumeLayout(false);
			this.grpDestinatarioVendita.PerformLayout();
			this.grpMittenteVendita.ResumeLayout(false);
			this.grpRifAmmMittenteVendita.ResumeLayout(false);
			this.grpRifAmmMittenteVendita.PerformLayout();
			this.grpIPAMittenteVendita.ResumeLayout(false);
			this.grpIPAMittenteVendita.PerformLayout();
			this.grpDestinatarioAcquisto.ResumeLayout(false);
			this.grpDestinatarioAcquisto.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			this.grpSdIAcqEstere.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.groupBox15.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox16.PerformLayout();
			this.grpSDI_vendita.ResumeLayout(false);
			this.grpStatoTrasmissione.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grpSDI_acquisto.ResumeLayout(false);
			this.gboxStatoSdi.ResumeLayout(false);
			this.grpIdSsi.ResumeLayout(false);
			this.grpIdSsi.PerformLayout();
			this.grpMessaggi.ResumeLayout(false);
			this.grpMessaggi.PerformLayout();
			this.tabRegistroUnico.ResumeLayout(false);
			this.tabRegistroUnico.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).EndInit();
			this.grpRegistroUnico.ResumeLayout(false);
			this.grpRegistroUnico.PerformLayout();
			this.tabAllegati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabTesseraSSN.ResumeLayout(false);
			this.tabTesseraSSN.PerformLayout();
			this.gboxTesseraSSN.ResumeLayout(false);
			this.gboxTesseraSSN.PerformLayout();
			this.tabAltro.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrCarichiCespite)).EndInit();
			this.gboxBolleDoganali.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrBolleDoganali)).EndInit();
			this.grpComunicazioneBlackList.ResumeLayout(false);
			this.grpComunicazioneBlackList.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private QueryHelper QHS;
        private CQueryHelper QHC;
        private string filterayear;
        private XmlTextWriter writer;
        private XmlTextWriter writersdi;
        private EP_Manager EPM;
        private int faseSpesaMax = 0;
        private int faseEntrataMax;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            AccMotiveManager AM = new AccMotiveManager(gboxCausale);
            AccMotiveManager AM01 = new AccMotiveManager(gboxCausaleCrg);
            Conn = Meta.Conn;
            filterayear = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filterayear, null, false);
            GetData.CacheTable(DS.invoicekindyear, filterayear, null, false);
            GetData.CacheTable(DS.invoicekindregisterkind);
            GetData.CacheTable(DS.ivaregisterkind);
            GetData.CacheTable(DS.accountkind);
            GetData.CacheTable(DS.ivakind);
            GetData.CacheTable(DS.fedocumentkind,null,null,true);
            GetData.CacheTable(DS.treasurer_acq_estere, null, null, true);
            DataAccess.SetTableForReading(DS.sorting_siope, "sorting");
            DataAccess.SetTableForReading(DS.invoice_bolladoganale, "invoice");
            QueryCreator.SetTableForPosting(DS.invoice_bolladoganale, "invoice");
            DataAccess.SetTableForReading(DS.invoicekind_bolladoganale, "invoicekind");
			DataAccess.SetTableForReading(DS.registry_sostituto, "registry");
			DataAccess.SetTableForReading(DS.geo_country_origin, "geo_country");
            DataAccess.SetTableForReading(DS.geo_country_destination, "geo_country");
            DataAccess.SetTableForReading(DS.invoicekind_forwarder, "invoicekind");
            DataAccess.SetTableForReading(DS.intrastatnation_provenance, "intrastatnation");

            DataAccess.SetTableForReading(DS.intrastatnation_origin, "intrastatnation");
            DataAccess.SetTableForReading(DS.intrastatnation_destination, "intrastatnation");
            DataAccess.SetTableForReading(DS.intrastatnation_payment, "intrastatnation");
            DataAccess.SetTableForReading(DS.sdi_statusvendita, "sdi_status");
            DataAccess.SetTableForReading(DS.sdi_status_acquestere, "sdi_status");
            DataAccess.SetTableForReading(DS.profservice_1, "profservice");
            GetData.SetStaticFilter(DS.intrastatnation_provenance, QHS.CmpEq("flague", "S"));
            GetData.SetStaticFilter(DS.intrastatnation_payment, QHS.CmpEq("flague", "S"));
            GetData.SetStaticFilter(DS.intrastatnation_destination, QHS.CmpEq("flague", "S"));
            GetData.SetStaticFilter(DS.treasurer_acq_estere, QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.IsNotNull("departmentname_fe")));

            HelpForm.SetDenyNull(DS.invoice.Columns["active"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flagintracom"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["autoinvoice"], true);

            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP,
                labEP, null, "invoice");

            cmb_isodestinazione.DataSource = DS.intrastatnation_destination;
            cmb_isodestinazione.DisplayMember = "description";
            cmb_isodestinazione.ValueMember = "idintrastatnation";
            cmb_isoorigine.DataSource = DS.intrastatnation_origin;
            cmb_isoorigine.DisplayMember = "description";
            cmb_isoorigine.ValueMember = "idintrastatnation";
            cmb_isoprovenienza.DataSource = DS.intrastatnation_provenance;
            cmb_isoprovenienza.DisplayMember = "description";
            cmb_isoprovenienza.ValueMember = "idintrastatnation";
            cmb_isopagamento.DataSource = DS.intrastatnation_payment;
            cmb_isopagamento.DisplayMember = "description";
            cmb_isopagamento.ValueMember = "idintrastatnation";

            cmb_natura.DataSource = DS.intrastatkind;
            cmb_natura.DisplayMember = "idintrastatkind";
            cmb_natura.ValueMember = "idintrastatkind";

            cmb_provorigine.DataSource = DS.geo_country_origin;
            cmb_provorigine.ValueMember = "idcountry";
            cmb_provorigine.DisplayMember = "title";

            cmb_provdestinazione.DataSource = DS.geo_country_destination;
            cmb_provdestinazione.ValueMember = "idcountry";
            cmb_provdestinazione.DisplayMember = "title";

            QueryCreator.SetFilterForInsert(DS.geo_country_destination, "(stop is null)");
            QueryCreator.SetFilterForInsert(DS.geo_country_origin, "(stop is null)");

            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");

            GetData.SetSorting(DS.accmotiveapplied_crg, "in_use");
            GetData.SetSorting(DS.accmotiveapplied_debit, "in_use");

            HelpForm.SetDenyNull(DS.invoice.Columns["flagintracom"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flag_ddt"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["flag"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["toincludeinpaymentindicator"], true);
            HelpForm.SetDenyNull(DS.invoice.Columns["resendingpcc"], true);

            faseSpesaMax = CfgFn.GetNoNullInt32( Conn.GetSys("maxexpensephase"));
            faseEntrataMax = CfgFn.GetNoNullInt32( Conn.GetSys("maxincomephase"));

            gridStock.DataSource = DS.stockview;
            string filterflag = QHS.CmpEq("flag_invoicedefault", 'S');
            object O = Conn.DO_READ_VALUE("storeload_motive", filterflag, "idstoreload_motive");
            if (O != null)
                MetaData.SetDefault(DS.stock, "idstoreload_motive", O);
            DataAccess.SetTableForReading(DS.invoicekind_real, "invoicekind");

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
           
            GetData.SetSorting(DS.pccview, "idpcc");
            chk_auto_split_payment.Enabled = DoManageManualSplitPayment();
            if (Meta.GetUsr("broadcastEnabledInvoice") != null) {
                Meta.SetUsr("broadcastEnabledInvoice", null);
                MetaData.messageBroadcaster += MetaData_messageBroadcaster;
            }

            btnRipartizione.ContextMenu = CMenu;
			
        }

        bool abilitaBroadcast = true;

        void MetaData_messageBroadcaster(object sender, object message) {
            if (!abilitaBroadcast) return;
            abilitaBroadcast = false;
            if (Meta.InsertMode) {
                if (message.ToString() == "apriFormImportaFattureElettroniche") {
                    AggiungidaFE("contrattopassivo");
                }
                if (message.ToString() == "apriFormImportaFattureElettronicheParcella") {
                    AggiungidaFE("parcella");
                }

            }
        }


        private bool recuperoIntraUEAttivo = false;
        public void MetaData_AfterActivation() {
            if (DS.config.Rows.Count > 0) {
                int flag  =CfgFn.GetNoNullInt32(DS.config.First().flag);
                if ((flag & 1) != 0) recuperoIntraUEAttivo = true;
            }

            DS.invoice.ExtendedProperties["docautomatico"] = "N";
            //tabControl1.Controls.Remove(tabPage3);
            tabControl1.SelectedIndex = 0;

            if ((DS.invoicekind.Rows.Count == 0)
                || ((Meta.Conn.RUN_SELECT_COUNT("iva_prorata", filterayear, true) == 0))
                || ((Meta.Conn.RUN_SELECT_COUNT("iva_mixed", filterayear, true) == 0))) {
                show(
                    "Non è stato definito il tipo IVA e il relativo prorata e promiscuo per l'esercizio corrente",
                    "Attenzione",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Meta.CanSave = false;
            }



        }

        public void MetaData_AfterClear() {

            btnAggiungiDaOrdini.Enabled = false;
            btnAggiungiDaContratti.Enabled = false;

            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo;
            chkRecuperoIvaIntraExtra.Enabled = true;

            lastApplied = 0;
            gboxvaluta.Enabled = true;
            GetData.AllowClear(DS.assetacquire);
            DS.assetacquire.Clear();
            gboxBollo.Visible = true;
            grpComunicazioneBlackList.Enabled = true;
            cmb_BlackList.Enabled = true;
            txtBlCode.ReadOnly = false;
            txtEsercDocumento.ReadOnly = false;
            txtCambio.ReadOnly = false;
            chb_IVADifferita.Enabled = true;
            gboxtipofattura.Enabled = true;
            txtEsercDocumento.Text = Conn.GetEsercizio().ToString();
            //AbilitaIntracom(DBNull.Value);
            azzeraTxtdiGrpTotaliInValuta();
            EnableDisableRegistry();
            calcolaIVALiquidata();
            EPM.mostraEtichette();
            VisualizzaNumeroRegistroUnico();
            AbilitaDisabilitaRegistroUnico();
            EnableDisableToIncludeInPaymentIndicator();
            chk_auto_split_payment.Enabled = true;
            //chk_auto_split_payment.Checked = false;

            gboxTesseraSSN.Enabled = true;
            txtProgressivoRU.ReadOnly = false;
            //EnableDisableLiquidazioniIVADifferite();
            MetaData.SetDefault(DS.invoicedetail, "idsor1", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idsor2", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idsor3", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idcostpartition", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idupb", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idaccmotive", DBNull.Value);
            MetaData.SetDefault(DS.invoicedetail, "idpccdebitstatus", DBNull.Value);

            if (DS.config.Rows.Count > 0) {
                DataRow debitStatusSetup = DS.config.Rows[0];
                if (debitStatusSetup["idpccdebitstatus"] != DBNull.Value) {
                    MetaData.SetDefault(DS.invoicedetail, "idpccdebitstatus", debitStatusSetup["idpccdebitstatus"]);
                }
            }

            DisabilitaDocumento(false);
            DoEnableDisableIntrastat();
            DoVisibileLabelSoggettiNonResidenti();
            DoEnableDisableComunicazioni();
            EnableDisableDDT();
            DoManageSplitPayment();
            SetFilters();
            VisualizzaBtnAutoFattura();
            VisualizzaTabPageAutoFattura();
            cmbCondizioniPagFE.Enabled = true;
            cmbModPagFE.Enabled = true;
            txtNumTrasmissioneFE.ReadOnly = false;
            txtEsercTrasmissioneFE.ReadOnly = false;
            txtDataScadenza.ReadOnly = false;
            txtDataScadenza.Text = "";
            this.txtDataDoc.ReadOnly = false;
            GestisciFiltroAnagrafica(null);
            grpSDI_acquisto.Enabled = true;
            grpSDI_vendita.Enabled = true;
            grpSdIAcqEstere.Enabled = true;
            cmbDocumentKind.Enabled = true;
            cmbDenominazione.Enabled = true;
            btnCheck.Enabled = true;
            btnInviaSdI.Enabled = false;
            //gboxStatoSdi.Enabled = true;
            //txtIPA.ReadOnly = false;
            //txtNumFile.ReadOnly = false;
            //txtRiferimentoAmministrazione.ReadOnly = false;
            //grpMessaggi.Enabled = true;
            grpDestinatarioAcquisto.Enabled = true;
            grpDestinatarioVendita.Enabled = true;
            grpMittenteVendita.Enabled = true;
			grpLegaleRappresentante.Enabled = true;
			txtIpa_acq.Text = "";
            txtRifamm_acq.Text = "";
            txtIpa_ven_emittente.Text = "";
            txtRifamm_ven_emittente.Text = "";
            txtIpa_ven_cliente.Text = "";
			txtEmailFECliente.Text = "";
			txtPECFECliente.Text = "";
			txtRifamm_ven_cliente.Text = "";
            chkFatturaSpedizioniere.Enabled = true;
            grpInvSpedizioniere.Enabled = true;
            grpFEAcquistoEstere.Enabled = true;
            EnableDisableToExclude();
        }

        private void calcolaIVALiquidata() {
            if (Meta.IsEmpty) {
                txtTotIvaLiquidata.Text = "";
                return;
            }
            decimal totIVA = 0;
            foreach (DataRow rFatturaDiff in DS.invoicedeferred.Select()) {
                totIVA += CfgFn.GetNoNullDecimal(rFatturaDiff["ivatotalpayed"]);
            }
            txtTotIvaLiquidata.Text = totIVA.ToString("c");
        }

        private void azzeraTxtdiGrpTotaliInValuta() {
            string empty = "";
            txtImponibile.Text = empty;
            txtIva.Text = empty;
            txtTotale.Text = empty;
            txtIndetraibile.Text = empty;
        }

        public void MetaData_BeforeFill() {
            //Meta.MarkTableAsNotEntityChild(DS.stock);
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo;

            string filter = "";
            if (!Meta.IsEmpty) {
                LastCodiceTipoDoc = DS.invoice.Rows[0]["idinvkind"].ToString();
                filter = QHS.CmpEq("idinvkind", LastCodiceTipoDoc);
            }
            if (Meta.InsertMode) {
                DS.invoicedeferred.Clear();
            }

            if (DS.invoicedetail.ExtendedProperties["RigaModificata"] != null) {
                DataRow rInvoicedetailMod = DS.invoicedetail.ExtendedProperties["RigaModificata"] as DataRow;
                DS.invoicedetail.ExtendedProperties["RigaModificata"] = null;
                object NumRigaModificata = rInvoicedetailMod["rownum"];
                object idgroupbRigaModificata = rInvoicedetailMod["idgroup"];
                PropagaModificheAiFratelli(rInvoicedetailMod);
            }

            if (!Meta.IsEmpty) {
                AllineaStock();
                RicalcolaCostiStock();
            }
            GetData.DenyClear(DS.assetacquire);
        }

       private void PropagaModificheAiFratelli(DataRow rInvoicedetailModified) {
            object RowNum = rInvoicedetailModified["rownum"];
            object idGroup = rInvoicedetailModified["idgroup"];
            // Elenco dei campi modificabili prima di questa modifica, e quindi da non propagare.
            // Tutti gli altri, invece, prima erano ReadOnly, invece ora sono editabili
            // e verranno propagati da noi sui fratelli.
            List<string> campi_da_non_copiare = new List<string>(
                new string[] {
                    "idinvkind", "yinv", "ninv", "rownum", "resetresidualmandate",
                    "idestimkind", "yestim", "nestim", "estimrownum",
                    "idmankind", "yman", "nman", "manrownum", "idgroup",
                    "amount", "taxable", "tax", "unabatable", "paymentcompetency",
                    //"intrastatoperationkind","idintrastatcode",
                    //"idintrastatmeasure","idintrastatservice","idintrastatsupplymethod",
                    //"intra12operationkind","move12","exception12",
                    "idupb", "cupcode", "cigcode", "idsor1", "idsor2", "idsor3", "idcostpartition", "idpccdebitstatus",
                    //"va3type","competencystart","competencystop",
                    //"codicetipo","codicevalore",          
                    "idexp_taxable", "idexp_iva", "idinc_taxable", "idinc_iva",
                    "idepexp","idepacc"
                });

            string filtroBrother = QHC.AppAnd(QHC.CmpNe("rownum", RowNum), QHC.CmpEq("idgroup", idGroup));
            double newnpackage = CfgFn.GetNoNullDouble(rInvoicedetailModified["npackage"]);
            double newnidivakind = CfgFn.GetNoNullDouble(rInvoicedetailModified["idivakind"]);
            foreach (DataRow rBrother in DS.invoicedetail.Select(filtroBrother)) {
                double currnpackage = CfgFn.GetNoNullDouble(rBrother["npackage"]);
                double curridivakind = CfgFn.GetNoNullDouble(rBrother["idivakind"]);
                foreach (DataColumn C in DS.invoicedetail.Columns) {
                    if (campi_da_non_copiare.Contains(C.ColumnName))
                        continue;
                    rBrother[C.ColumnName] = rInvoicedetailModified[C.ColumnName];
                }
                //Solo se cambia la q.tà, info che prima non era editabile, dobbiamo modificare l'iva, perchè cambia la base imponibile su cui applicare l'aliquota iva
                if ((currnpackage != newnpackage) || (curridivakind != newnidivakind)) {
                    CalcolaIvaIvaindetraibile(rBrother);
                }


            }
            GetData GD = new GetData();
            GD.InitClass(DS, Conn, "invoicedetail");
            GD.GetTemporaryValues(DS.invoicedetail);
        }

        /// <summary>
        /// Ricalcola iva e ivaindetraibile in base a imponibile, quantità, tasso cambio e sconto
        /// </summary>
        /// <param name="rInvoicedetail"></param>
        private void CalcolaIvaIvaindetraibile(DataRow rInvoicedetail) {
            DataRow Curr = DS.invoice.Rows[0];
            double newnpackage = CfgFn.GetNoNullDouble(rInvoicedetail["npackage"]);
            double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(Curr["exchangerate"]));
            double aliquota =
                CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                    QHS.CmpEq("idivakind", rInvoicedetail["idivakind"]),
                    "rate"));
            double percindeduc =
                CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                    QHS.CmpEq("idivakind", rInvoicedetail["idivakind"]),
                    "unabatabilitypercentage"));
            double imponibile = CfgFn.GetNoNullDouble(rInvoicedetail["taxable"]);
            double quantitaConfezioni = newnpackage;
            double sconto = CfgFn.GetNoNullDouble(rInvoicedetail["discount"]);
            double imponibiletotEUR = CfgFn.RoundValuta((imponibile*quantitaConfezioni*(1 - sconto)*tassocambio));
            //double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
            double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR*aliquota);
            double impindeducEUR = CfgFn.RoundValuta(ivaEUR*percindeduc);

            rInvoicedetail["tax"] = ivaEUR;
            rInvoicedetail["unabatable"] = impindeducEUR;
        }


        private void AbilitaTesorierePerIncasso() {
            if (Meta.IsEmpty) {
                grpTesorierePerIncasso.Visible = true;
                return;
            }
            if (cboTipo.SelectedIndex <= 0) {
                grpTesorierePerIncasso.Visible = false;
                return;
            }
            object codiceDoc = cboTipo.SelectedValue;
            DataRow R = DS.invoicekind.Select(QHC.CmpEq("idinvkind", codiceDoc))[0];
            byte flag = CfgFn.GetNoNullByte(R["flag"]);
            bool movimentoEntrata = (flag & 1) != 0;
            if (movimentoEntrata) {
                grpTesorierePerIncasso.Visible = true;
            }
            else {
                grpTesorierePerIncasso.Visible = false;
            }
        }


        private void EnableDisableToIncludeInPaymentIndicator() {
            if (Meta.IsEmpty) {
                chkIncludeInPaymentIndicator.Visible = true;
                return;
            }
            if (cboTipo.SelectedIndex <= 0) {
                chkIncludeInPaymentIndicator.Visible = false;
                return;
            }
            object a_or_v = tipoRegistroAV();

            if (a_or_v.ToString().ToUpper() == "A") {
                chkIncludeInPaymentIndicator.Visible = true;
            }
            else {
                chkIncludeInPaymentIndicator.Visible = false;
            }
        }

        private void AbilitaDisabilitaWizard() {
            if (Meta.IsEmpty) {
                btnAggiungiDaOrdini.Visible = false;
                btnAggiungiDaContratti.Visible = false;
                btnCreaDaContratto.Visible = false;
                gboxProfessionale.Visible = false;
                return;
            }
            if (cboTipo.SelectedIndex <= 0) {
                btnAggiungiDaOrdini.Visible = false;
                btnAggiungiDaContratti.Visible = false;
                btnCreaDaContratto.Visible = false;
                return;
            }

            DataRow rInvoice = DS.invoice.Rows[0];
            if (rInvoice["idsdi_acquisto"] != DBNull.Value) {
                //Bottoni riattivati in seguito a task 6699
                //btnAggiungiDaOrdini.Visible = false;
                btnAggiungiDaContratti.Visible = false;
                //btnCreaDaContratto.Visible = false;

                return;
            }
            object codiceDoc = cboTipo.SelectedValue;
            DataRow R = DS.invoicekind.Select(QHC.CmpEq("idinvkind", codiceDoc))[0];
            byte flag = CfgFn.GetNoNullByte(R["flag"]);
            bool vendita = tipoRegistroAV().ToUpper() == "V"; // (flag & 1) != 0;
            if (!vendita) {
                btnAggiungiDaOrdini.Visible = chkflag_ddt.Checked ; //&& (faseSpesaMax>1);
                btnCreaDaContratto.Visible = true;
                gboxProfessionale.Visible = true;
                VerificaCollegamentoAContratto(vendita); //Ri-Disabilita eventualmente i bottoni
            }
            else {
                btnAggiungiDaOrdini.Visible = false;
                gboxProfessionale.Visible = false;
                btnCreaDaContratto.Visible = false;
            }
            if (vendita) {
	            btnAggiungiDaContratti.Visible = true; //(faseEntrataMax>1);
                VerificaCollegamentoAContratto(vendita); //Ri-Disabilita eventualmente i bottoni
            }
            else {
                btnAggiungiDaContratti.Visible = false;
            }
        }

        private void VisualizzaContrattoProf() {
            //DataRow[] F = DS.profservice.Select(QHC.IsNotNull("idinvkind"));
           
        }

        private void ScollegaContrattoProf() {
            if (DS.profservice.Rows.Count == 0)
                return;
            DataRow R = DS.profservice.Rows[0];
            if (R["idinvkind"] == DBNull.Value)
                return;
            Meta.unlink(R);
        }

        private void VisualizzaBtnAutoFattura() {
            return;
            /*
            if (DS.invoice.Rows.Count == 0 || DS.config.Rows.Count == 0) {
                btnAutoFattura.Enabled = false;
                btnAutoFattura.Text = "Crea Autofattura";
                return;
            }
            DataRow Curr = DS.invoice.Rows[0];
            // Controlliamo che la fattura corrente NON sia un'autofattura:
            //bool isAutoinvoice = (Curr["autoinvoice"].ToString().ToUpper() == "S");
            if (chkAutoFattura.Checked) {
                btnAutoFattura.Text = "Crea Autofattura";
                btnAutoFattura.Enabled = false;
                return;
            }


            string filterinvkind = QHC.CmpEq("idinvkind", Curr["idinvkind"]);
            if (DS.invoicekind.Select(filterinvkind).Length > 0) {
                DataRow R = DS.invoicekind.Select(filterinvkind)[0];
                object idinvkindAuto = R["idinvkind_auto"];
                if (idinvkindAuto == DBNull.Value) {
                    btnAutoFattura.Text = "Crea Autofattura";
                    btnAutoFattura.Enabled = false;
                    return;
                }
            }
            else {
                show(
                    "Il tipo fattura collegato non è stato trovato, errore nei dati. Contattare il servizio assistenza.",
                    "Errore");
            }

            // Controlliamo che non esiste un'autofattura collegata alla fattura Corrente
            string filterAutoFattura = QHS.AppAnd(QHS.CmpEq("idinvkind_real", Curr["idinvkind"]),
                                                  QHS.CmpEq("yinv_real", Curr["yinv"]),
                                                  QHS.CmpEq("ninv_real", Curr["ninv"]));
            bool esisteAutoFattura = (Meta.Conn.RUN_SELECT_COUNT("invoice", filterAutoFattura, true) > 0);
            bool isIntraCom = (Curr["flagintracom"].ToString().ToUpper() != "N");
                // Flagintracom può valere: S-intracom, N o X-extracom.
            if (esisteAutoFattura) {
                btnAutoFattura.Enabled = true;
                btnAutoFattura.Text = "Visualizza Autofattura";
            }
            else {
                btnAutoFattura.Enabled = isIntraCom;
                btnAutoFattura.Text = "Crea Autofattura";
            }
            */
        }

        private void VisualizzaNumeroRegistroUnico() {
            txtProgressivoRU.Text = "";
            if (DS.invoice.Rows.Count == 0 || DS.uniqueregister.Rows.Count == 0) {
                return;
            }
            //se esiste anche sul db allora lo visualizza
            DataRow rInvoice = DS.invoice.Rows[0];
            string filter = QHC.MCmp(rInvoice, new string[] {"idinvkind", "yinv", "ninv"});
            if ((Meta.Conn.RUN_SELECT_COUNT("uniqueregister", filter, true) > 0)
                && (DS.uniqueregister.Rows.Count > 0)) {
                DataRow Runiqueregister = DS.uniqueregister.Rows[0];
                txtProgressivoRU.Text = Runiqueregister["iduniqueregister"].ToString();
            }
        }



        private void VerificaCollegamentoAContratto(bool vendita) {
            if (Meta.IsEmpty) {
                chkContabilizzabile.Enabled = true;
                btnCreaDaContratto.Visible = false;
                gboxProfessionale.Visible = true;
                return;
            }
   
            if (DS.invoicedetail.Select().Length == 0 && DS.profservice.Select(QHC.IsNotNull("idinvkind")).Length == 0
                && !vendita && !skipAfterFill
                ) {
                btnCreaDaContratto.Visible = true;
            }
            // Anche in presenza di dettagli l'associazione deve poter essere ancora possibile per agganciare più parcelle
            // alla stessa fattura. Commento quindi l'istruzione di seguito

            //else {
            //    btnCreaDaContratto.Visible = false;
            //}
            if (DS.invoicedetail.Select().Length == 0 && DS.profservice.Select(QHC.IsNotNull("idinvkind")).Length > 0
                && !vendita && !skipAfterFill) {
                ScollegaContrattoProf();
            }


        }

        private void EnableDisableDDT(bool enable) {
            txtNumDDT.ReadOnly = !enable;
            txtDataDDT.ReadOnly = !enable;
            if (!enable) {
                txtNumDDT.Text = "";
                txtDataDDT.Text = "";
            }
        }


        private void EnableDisableDDT() {
            if (Meta.IsEmpty) {
                EnableDisableDDT(true);
                chkflag_ddt.Enabled = true;
                btnBolletta.Visible = false;
                return;
            }
            EnableDisableDDT(!chkflag_ddt.Checked);
            btnBolletta.Visible = (!chkflag_ddt.Checked) && (tipoRegistroAV() == "A");

            // Controlliamo che non esiste un'autofattura collegata alla fattura Corrente
            // Se esiste, ossia se la fattura in oggetto è un'autofattura il check andrà disabilitato
            DataRow Curr = DS.invoice.Rows[0];
            bool esisteFatturaMadre = (Curr["idinvkind_real"] != DBNull.Value);

            //Disabilita il chk se ci sono già dettagli con idlist o è un'Autofattura
            if ((DS.invoicedetail.Select(QHC.IsNotNull("idlist")).Length > 0) || (esisteFatturaMadre))
                chkflag_ddt.Enabled = false;
            else
                chkflag_ddt.Enabled = true;

            AbilitaDisabilitaWizard();
        }


        private void SetModalitaPagamentoFE(object idreg) {
            if (tipoRegistroAV().ToUpper() != "V") {
                return;
            }
            if ((idreg == DBNull.Value) || CfgFn.GetNoNullInt32(idreg) == 0)
                return;

            //Se Ente pubblico impostiamo la modalità MP15 giroconto su conti di contabilità speciale
            object flagbankitaliaproceeds = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg),
                "flagbankitaliaproceeds");
            if (flagbankitaliaproceeds.ToString().ToUpper() == "S") {
                object idGiroconto = "MP15";
                HelpForm.SetComboBoxValue(cmbModPagFE, idGiroconto);
            }
        }

        public void EnableDisableToExclude() {
            chkEscludiInvio.Enabled = true;
            if (Meta.GetUsr("liquidazioneiva") != null) {
                chkEscludiInvio.Enabled = false;
                if (Meta.GetUsr("liquidazioneiva").ToString().ToUpper() == "'S'") {
                    chkEscludiInvio.Enabled = true;
                }
            }
        }
        private string documentoAV() {
            if (Meta.IsEmpty) return "q";
            DataRow r = DS.invoice.Rows[0];
            int flagBit = CfgFn.GetNoNullInt32(r["flagbit"]);
            if ((flagBit & 16) != 0) return "V"; //Forza accertamenti di budget
            if ((flagBit & 32) != 0) return "A"; //Forza impegni di budget
            return tipoMovimentoAV(); //altrimenti vale la contabilizzazione in entrata o spesa
        }

        public void MetaData_AfterFill() {
            if (DS.invoice.Rows.Count == 0)return;
            
            if (Meta.FirstFillForThisRow) {
                chkRecuperoIvaIntraExtra.Enabled = true;
                if (DS.invoicedetail.Select(QHC.IsNotNull("idinc_taxable")).Length > 0)chkRecuperoIvaIntraExtra.Enabled = false;
                if (chkRecuperoIvaIntraExtra.Enabled && DS.invoicedetail.Select(QHC.IsNotNull("idinc_iva")).Length > 0) chkRecuperoIvaIntraExtra.Enabled = false;
                if (chkRecuperoIvaIntraExtra.Enabled && DS.invoicedetail.Select(QHC.IsNotNull("idexp_taxable")).Length > 0) chkRecuperoIvaIntraExtra.Enabled = false;
                if (chkRecuperoIvaIntraExtra.Enabled && DS.invoicedetail.Select(QHC.IsNotNull("idexp_taxable")).Length > 0) chkRecuperoIvaIntraExtra.Enabled = false;
                if (chkRecuperoIvaIntraExtra.Enabled && DS.invoicedeferred.Select().Length>0)chkRecuperoIvaIntraExtra.Enabled = false;
            }
            
            DataRow Curr = DS.invoice.Rows[0];
            //gboxvaluta.Enabled = (DS.invoicedetail.Select().Length == 0);
            chk_auto_split_payment.Enabled = DoManageManualSplitPayment();
            EPM.mostraEtichette();
            lastApplied = CfgFn.GetNoNullDouble(Curr["exchangerate"]);
            DoManageSplitPayment();
            if (Meta.FirstFillForThisRow) {
                GetNationInBlackList(DS.invoice.Rows[0]["idreg"],
                    DS.invoice.Rows[0]["adate"]);
                cmb_BlackList.Enabled = false;
                txtBlCode.ReadOnly = true;

            }
            gboxTesseraSSN.Enabled = isSSN();
            SetFilters();
            DoEnableDisableIntrastat();
         
            EnableDisableFEEstera();
            EnableDisableFE();
            DoVisibileLabelSoggettiNonResidenti();
            DoEnableDisableComunicazioni();
            EnableDisableDDT();
            VisualizzaContrattoProf();
            EnableDisableToIncludeInPaymentIndicator();
            grpInvSpedizioniere.Enabled = false;
        

            //DataRow rInvKind = HelpForm.GetLastSelected(DS.invoicekind);
            DataRow[] rkinds = DS.invoicekind.Select(QHC.CmpEq("idinvkind", Curr["idinvkind"]));
            DataRow rInvKind = null;
            if (rkinds.Length > 0)
                rInvKind = rkinds[0];

            GestisciFiltroAnagrafica(rInvKind);

            string tiponumerazione = (rInvKind != null)
                ? rInvKind["flag_autodocnumbering"].ToString()
                : "N";
            if ((Meta.EditMode) && (Meta.FirstFillForThisRow)) {
                if (rInvKind != null) {
                    byte flagIK = CfgFn.GetNoNullByte(rInvKind["flag"]);
                    if ((flagIK & 1) != 0) {
                        DS.invoicedetail.Columns["!percindetraibilita"].Caption = "";
                    }
                    else {
                        DS.invoicedetail.Columns["!percindetraibilita"].Caption = "% Indetr.";
                    }

                }
                HelpForm.SetDataGrid(gridDettagli, DS.invoicedetail);
                gridDettagli.TableStyles.Clear();
                HelpForm.SetGridStyle(gridDettagli, DS.invoicedetail);
                formatgrids format = new formatgrids(gridDettagli);
                format.AutosizeColumnWidth();
            }
            if (Meta.FirstFillForThisRow) {
                if (rInvKind != null) {
                    DS.invoicedetail.ExtendedProperties["flag"] = rInvKind["flag"];
                    DS.invoicedetail.ExtendedProperties["flagactivity"] = TipoAttivita();
                    DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
                    DS.invoicedetail.ExtendedProperties["registerclass"] = tipoRegistroAV();
                }
            }
                
            gboxtipofattura.Enabled = !(Meta.EditMode);
            // Controllo che la fattura sia collegata al contratto, in tal caso bisogna modificare il filtro dell'epoperation
            if (DS.profservice.Rows.Count > 0) {
                string filtroEP = QHS.CmpEq("idepoperation", "fatacq");
                //"((idepoperation='prestprof')OR(idepoperation='spesaprof'))";
                DS.invoicedetail.ExtendedProperties["filtroepcontratto"] = filtroEP;
                if ((Meta.EditMode) && (Meta.FirstFillForThisRow)&& (Curr["active"].ToString() == "N")) {
                    Curr["flagdeferred"] = 'N';
                    chb_IVADifferita.Checked = false;
                    chb_IVADifferita.Enabled = false;
                }
                }
            else {
                DS.invoicedetail.ExtendedProperties["filtroepcontratto"] = null;
                //chb_IVADifferita.Enabled = true;
            }

            txtEsercDocumento.ReadOnly = true;

            CalcolaImporto();
            ImpostaTxtValuta();

            DataRow R = DS.invoice.Rows[0].GetParentRow("invoicekindinvoice");
            byte flagR = 0;
            if (R != null)
                flagR = CfgFn.GetNoNullByte(R["flag"]);

            bool autoincremento = (tiponumerazione == "S");
            bool autofattura = ((flagR & 8) != 0);
            bool vendita = tipoRegistroAV().ToUpper() == "V"; // ((flagR & 1) != 0);
            bool acquisto = !vendita; // ((flagR & 1) == 0);
            if (acquisto && !autofattura)
                autoincremento = false;

            if (!Meta.InsertMode) {
                DisabilitaDocumento(autoincremento);
            }
            if (Meta.FirstFillForThisRow ) { //&& Meta.EditMode
                if ((vendita) || (chkAutoFattura.Checked)) {
                    txtDataDoc.ReadOnly = true;
                }
                else {
                    txtDataDoc.ReadOnly = false;
                }
            }
            EnableDisableRegistry();
            calcolaIVALiquidata();
            AbilitaDisabilitaWizard();
            AbilitaTesorierePerIncasso();
            assegnaValoriDefaultAlDettaglio();
            grpCertificatiNecessari.Enabled = acquisto;

            if (Meta.FirstFillForThisRow && Meta.InsertMode) {
                if (cboTipo.SelectedIndex > 0) {
                    //se la numerazione è automatica il campo documento è disabilitato
                    //solo se il tipo documento ha un flag Vendita
                    DisabilitaDocumento(autoincremento);
                    if (autofattura)
                        chkAutoFattura.Checked = true;
                }
                else {
                    DisabilitaDocumento(false);
                }
            }

            EPM.mostraEtichette();

            if (Meta.FirstFillForThisRow && Meta.EditMode) {
                VisualizzaBtnAutoFattura();
                //VisualizzaTabPageAutoFattura();
            }
            if (Meta.FirstFillForThisRow) {
                VisualizzaTabPageAutoFattura();
            }

            bool accompagnatoria = chkflag_ddt.Checked;
            if (accompagnatoria && DS.stock.Rows.Count != 0) {
                btnModificaStock.Enabled = true;
            }
            else {
                btnModificaStock.Enabled = false;
            }
            txtNumTrasmissioneFE.ReadOnly = true;
            txtEsercTrasmissioneFE.ReadOnly = true;
            txtDataScadenza.ReadOnly = true;

            txtProgressivoRU.ReadOnly = true;
            CalcolaDataScadenza();
            CalcolaDataDocumento();
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
            grpSDI_acquisto.Enabled = false;
            grpSDI_vendita.Enabled = false;
            grpSdIAcqEstere.Enabled = false;
            //gboxStatoSdi.Enabled = false;
            //txtIPA.ReadOnly = true;
            //txtNumFile.ReadOnly = true;
            //txtRiferimentoAmministrazione.ReadOnly = true;
            //grpMessaggi.Enabled = false;
            grpDestinatarioAcquisto.Enabled = false;
            grpDestinatarioVendita.Enabled = vendita;
            grpMittenteVendita.Enabled = vendita || (acquisto && FatturaElettronicaEstera().ToString() == "S" && !FatturaInviataSdI());
			grpLegaleRappresentante.Enabled = vendita;
			if (Meta.EditMode) {
                chkFatturaSpedizioniere.Enabled = false;
                btnInserisciBollettaDoganale.Enabled = false;
            }
            else {
                //Se ho inserito bollette doganali, posso togliere la spunta
                if (BolletteDoganaliInserite()) {
                    chkFatturaSpedizioniere.Enabled = false;
                    btnInserisciBollettaDoganale.Enabled = false;
                }
                else {
                    chkFatturaSpedizioniere.Enabled = true;
                }
            }
            if (DS.assetacquire.ExtendedProperties["NotEntityChild"] == null) {
                DS.assetacquire.ExtendedProperties["NotEntityChild"] = QHC.IsNull("idinvkind");
            }
            EnableDisableToExclude();
            //ImpostaIpaRifEmittente();//Serve per le FE di acquisto estere. Lasciamo la valorizzazione solo nel'After_Row_Select, come avviene per le FE di vendita
        }

        private void assegnaValoriDefaultAlDettaglio() {
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                if (DS.invoicedetail.Select().Length != 0) {
                    int maxdetail = CfgFn.GetNoNullInt32(DS.invoicedetail.Compute("max(rownum)", null));
                    if (maxdetail > 0) {
                        DataRow row_invoicedetail = DS.invoicedetail.Select(QHC.CmpEq("rownum", maxdetail))[0];
                        if (row_invoicedetail != null && row_invoicedetail.RowState == DataRowState.Added) {

                            object idAccMotive = (row_invoicedetail["idaccmotive"] != DBNull.Value)
                                ? row_invoicedetail["idaccmotive"]
                                : null;
                            if (idAccMotive != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idaccmotive", idAccMotive);
                            }

                            object idSor_siope = (row_invoicedetail["idsor_siope"] != DBNull.Value)
                                ? row_invoicedetail["idsor_siope"]
                                : null;
                            if (idSor_siope != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idsor_siope", idSor_siope);
                            }
                            object idSor1 = (row_invoicedetail["idsor1"] != DBNull.Value)
                                ? row_invoicedetail["idsor1"]
                                : null;
                            if (idSor1 != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idsor1", idSor1);
                            }

                            object idSor2 = (row_invoicedetail["idsor2"] != DBNull.Value)
                                ? row_invoicedetail["idsor2"]
                                : null;
                            if (idSor2 != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idsor2", idSor2);
                            }

                            object idSor3 = (row_invoicedetail["idsor3"] != DBNull.Value)
                                ? row_invoicedetail["idsor3"]
                                : null;
                            if (idSor3 != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idsor3", idSor3);
                            }

                            object idUpb = (row_invoicedetail["idupb"] != DBNull.Value)
                                ? row_invoicedetail["idupb"]
                                : null;
                            if (idUpb != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idupb", idUpb);
                            }

                            object idcostpartition = (row_invoicedetail["idcostpartition"] != DBNull.Value)
                                ? row_invoicedetail["idcostpartition"]
                                : null;
                            if (idcostpartition != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idcostpartition", idcostpartition);
                            }

                            //Il default, la prima volta lo legge da config.
                            object idpccdebitstatusDefault = null;
                            if (DS.config.Rows.Count > 0) {
                                DataRow debitStatusSetup = DS.config.Rows[0];
                                if (debitStatusSetup["idpccdebitstatus"] != DBNull.Value)
                                    idpccdebitstatusDefault = debitStatusSetup["idpccdebitstatus"];
                            }

                            object idpccdebitstatus = (row_invoicedetail["idpccdebitstatus"] != DBNull.Value)
                                ? row_invoicedetail["idpccdebitstatus"]
                                : idpccdebitstatusDefault;
                            if (idpccdebitstatus != null) {
                                MetaData.SetDefault(DS.invoicedetail, "idpccdebitstatus", idpccdebitstatus);
                            }

                        }
                    }
                }
            }
        }

        private void EnableDisableRegistry() {
            int LinkedDet = DS.invoicedetail.Select("idmankind is not null").Length;
            if (LinkedDet == 0)
                txtCredDeb.ReadOnly = false;
            else
                txtCredDeb.ReadOnly = true;
        }

        private void AbilitaDisabilitaRegistroUnico() {
            if ((Meta.IsEmpty) || (DS.invoice.Rows.Count == 0)) {
                grpRegistroUnico.Enabled = true;
                btnCreaRegistroUnico.Enabled = false;
                btnModStatodelDebito.Enabled = false;
                return;
            }

            DataRow CurrInvoice = DS.invoice.Rows[0];

            bool acquisto = (tipoRegistroAV() == "A");
            // la condizione OR  (DS.uniqueregister.Rows.Count > 0) l'ho aggiunta perchè se ho una fattura con data ricezione successiva al 1 Luglio, protocollata
            // e cambio la data, anticipandola, non deve disabilitare il grpbox. Non deve fare nulla, ci sarà una regola a impedire di retrodatare la data ricezione se esiste la riga in R.U.
            if ((acquisto) && (DataRegistrazionePost_1luglio2014() && (ProtocollanelRU())) ||
                (DS.uniqueregister.Rows.Count > 0)) {
                grpRegistroUnico.Enabled = true;
                btnModStatodelDebito.Enabled = true;
            }
            else {
                grpRegistroUnico.Enabled = false;
                btnModStatodelDebito.Enabled = false;
                txtProgressivoRU.Text = "";
                txtProtocolloEntrataRU.Text = "";
                txtAnnotazioniRU.Text = "";
                //rdbSpesaCorrente.Checked = false;
                //rdbContoCapitale.Checked = false;
            }

            if (DS.uniqueregister.Rows.Count > 0) {
                btnCreaRegistroUnico.Enabled = false;
            }
            else {
                if ((acquisto) && (DataRegistrazionePost_1luglio2014()) && (ProtocollanelRU())) {
                    btnCreaRegistroUnico.Enabled = Meta.EditMode; //lo abilita solo in EditMode
                }
                else {
                    btnCreaRegistroUnico.Enabled = false;
                }
            }

        }



        public void MetaData_AfterGetFormData() {
            if (Meta.EditMode) {
                DoManageSplitPayment();
            }
            if (Meta.InsertMode) {
                DataRow CurrInvoice = DS.invoice.Rows[0];
                object currdoc = CurrInvoice["idinvkind"];

                foreach (DataRow RChild in DS.profservice.Select()) {
                    RChild["yinv"] = CurrInvoice["yinv"];
                    RChild["ninv"] = CurrInvoice["ninv"];
                    RChild["idinvkind"] = CurrInvoice["idinvkind"];
                }

                foreach (DataRow RChild in DS.stock.Select()) {
                    RChild["yinv"] = CurrInvoice["yinv"];
                    RChild["ninv"] = CurrInvoice["ninv"];
                    RChild["idinvkind"] = CurrInvoice["idinvkind"];
                }
                foreach (DataRow RChild in DS.invoicedetail.Select()) {
                    RChild["yinv"] = CurrInvoice["yinv"];
                    RChild["ninv"] = CurrInvoice["ninv"];
                    RChild["idinvkind"] = CurrInvoice["idinvkind"];
                }
                foreach (DataRow RChild in DS.invoicesorting.Select()) {
                    RChild["yinv"] = CurrInvoice["yinv"];
                    RChild["ninv"] = CurrInvoice["ninv"];
                    RChild["idinvkind"] = CurrInvoice["idinvkind"];
                }
                foreach (DataRow RChild in DS.invoiceattachment.Select()) {
                    RChild["yinv"] = CurrInvoice["yinv"];
                    RChild["ninv"] = CurrInvoice["ninv"];
                    RChild["idinvkind"] = CurrInvoice["idinvkind"];
                }

                foreach (DataRow Child in DS.uniqueregister.Select()) {
                    Child["yinv"] = CurrInvoice["yinv"];
                    Child["ninv"] = CurrInvoice["ninv"];
                    Child["idinvkind"] = CurrInvoice["idinvkind"];
                }
                DoManageSplitPayment();


                //prima svuota tutto perchè deve essere certo di non lasciare cadaveri
                DS.ivaregister.Clear();
                DS.uniqueregister.Clear();

                //Crea le righe di tutti i protocolli che servono

                if (currdoc == DBNull.Value)  return;
                MetaData IvaReg = MetaData.GetMetaData(this, "ivaregister");
                IvaReg.SetDefaults(DS.ivaregister);
                string filterreg = QHS.CmpEq("idinvkind", currdoc);
                bool acquisto = (tipoRegistroAV() == "A");
                //Per le fatture commerciali-reverse charge, intracom, extracom è ammessa la doppia registrazione nell'acquisto altrimenti no
                //Quando non è ammessa la doppia registrazione ? se l'acquisto non è né intracom né extracom né reverse charge commerciale
                if ((acquisto)
                    && ( // Non è Fattura Intra o Extracomunitaria
                        ((CurrInvoice["flagintracom"].ToString().ToUpper() != "S") &&
                         (CurrInvoice["flagintracom"].ToString().ToUpper() != "X"))
                        &&
                        // Non + applicare Split Payment
                        ((CurrInvoice["flag_enable_split_payment"].ToString().ToUpper() != "S") ||
                         !attivitaCommercialeOPromiscua())
                        &&
                        (CurrInvoice["flag_reverse_charge"].ToString().ToUpper() != "S")
                        )
                    ) {
                    string DistVal =
                        QHC.DistinctVal(
                            DS.ivaregisterkind.Select(QHC.FieldIn("registerclass", new string[] {"A", "P"})),
                            "idivaregisterkind");
                    filterreg = QHS.AppAnd(filterreg, QHS.FieldInList("idivaregisterkind", DistVal));
                }

                DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
                foreach (DataRow Reg in RegisterToLink) {
                    MetaData.SetDefault(DS.ivaregister, "idivaregisterkind", Reg["idivaregisterkind"]);
                    DataRow RegDoc = IvaReg.Get_New_Row(CurrInvoice, DS.ivaregister);
                }

                //Crea la riga nel Registro Unico
               

                if ((acquisto) && (DataRegistrazionePost_1luglio2014()) && (ProtocollanelRU())) {
                    MetaData Uniqueregister = MetaData.GetMetaData(this, "uniqueregister");
                    Uniqueregister.SetDefaults(DS.uniqueregister);
                    DataRow Runiqueregister = Uniqueregister.Get_New_Row(CurrInvoice, DS.uniqueregister);
                }
            }

            //Solo per la fatture di acquisto, pone la fattura SDI come Accettata qualora non sia nello stato Decorsi i termini, e non sia già nello stato accettata
            if ((Meta.InsertMode) || (Meta.EditMode)) {              
                DataRow CurrInvoice = DS.invoice.Rows[0];


                if (CurrInvoice["flagintracom"].ToString().ToUpper() != "N"
                    || CurrInvoice["flag_reverse_charge"].ToString().ToUpper() == "S"
                    ) {
                    if (chb_IVADifferita.Checked) {
                        chb_IVADifferita.Checked = false;
                        CurrInvoice["flagdeferred"] = "N";
                    }
                }
            }
        }

        public bool AggiornaSDIAcquistoEnabled = true;

       

        bool ProtocollanelRU() {
            if (chkProtocollanelRU.Checked)
                return true;
            return false;
        }

        bool DataRegistrazionePost_1luglio2014() {
            DateTime dataRicezione = DateTime.MinValue;
            if (txtProtocolDate.Text != "") {
                object tryDate= HelpForm.GetObjectFromString(typeof(DateTime), txtProtocolDate.Text,
                            txtProtocolDate.Tag.ToString());
                if (tryDate != DBNull.Value && tryDate!=null) {
                    dataRicezione = (DateTime) tryDate;
                }                        
            }

            DateTime DataEntratavigore = new DateTime(2014, 7, 1);                
            if (dataRicezione >= DataEntratavigore)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>1 istituzionale 2 commerciale 3 promiscuo</returns>
        private int TipoAttivita() {
            //if (cboTipo.SelectedIndex <= 0) return 1;
            //var found = DS.invoicekindregisterkind.f_Eq("idinvkind", cboTipo.SelectedValue)
            //        .Join(DS.ivaregisterkind, (r1, r2) => r1["idivaregisterkind"].Equals(r2.idivaregisterkindValue)
            //                                                 && r2.registerclass.ToUpper() != "P")
            //                .FirstOrDefault()?.Item2.flagactivity;
            //return found.HasValue?  (int) found:1;




            object idinvkind = cboTipo.SelectedValue;
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
                    continue;
                DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
                if (IvaRegKind["registerclass"].ToString().ToUpper() == "P")
                    continue;
                return CfgFn.GetNoNullInt32(IvaRegKind["flagactivity"]);
            }
            return 1;
        }

        private string tipoMovimentoAV() {
            if (cboTipo.SelectedIndex <= 0)   return "A";
            object idinvkind = cboTipo.SelectedValue;
            DataRow[] invKind = DS.invoicekind.Select(QHS.CmpEq("idinvkind", idinvkind));
            int flag = CfgFn.GetNoNullInt32(invKind[0]["flag"]);
            bool Acquisto = (flag & 1) == 0;

            //string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            //DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            //bool Acquisto = false;
            //foreach (DataRow IReg in RegisterToLink) {
            //    object idivaregisterkind = IReg["idivaregisterkind"];
            //    if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
            //        continue;
            //    DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
            //    if (IvaRegKind["registerclass"].ToString().ToUpper() == "A")
            //        Acquisto = true;
            //}
            if (Acquisto)
                return "A";
            else
                return "V";

        }

        private string FatturaElettronicaEstera() {
            if (cboTipo.SelectedIndex <= 0) return "N";
            object idinvkind = cboTipo.SelectedValue;
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow invoiceKind = DS.invoicekind.First(filterreg);
            return invoiceKind["enable_fe_estera"].ToString();
		}

        private string tipoRegistroAV() {
            if (cboTipo.SelectedIndex <= 0) return "A";
            object idinvkind = cboTipo.SelectedValue;
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            bool Acquisto = false;
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
                    continue;
                DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
                if (IvaRegKind["registerclass"].ToString().ToUpper() == "A")
                    Acquisto = true;
            }
            if (Acquisto)
                return "A";
            else
                return "V";

        }

        private string GetFlagIntracom() {
            if (Meta.IsEmpty) return null;

            //DataRow Curr = DS.invoice.Rows[0];
            //return Curr["flagintracom"].ToString();
            if (rdbitalia.Checked) return "N";
            if (rdbintracom.Checked) return "S";
            if (rdbextracom.Checked) return "X";
            return null;
        }

        private string NotaVariazione() {
            if (cboTipo.SelectedIndex <= 0)
                return "N";
            object idinvkind = cboTipo.SelectedValue;
            string filter = QHS.CmpEq("idinvkind", idinvkind);
            byte flag = CfgFn.GetNoNullByte(Meta.Conn.DO_READ_VALUE("invoicekind", filter, "flag"));
            if ((flag & 4) != 0) {
                //yes
                return "S";
            }
            else //no
            {
                return "N";
            }
        }

        public void SetFilters() {
            string filterEpOperationDeb = QHS.FieldIn("idepoperation", new object[] {"fatven_cred", "fatacq_deb"});
            string filterEpOperationDebC = QHC.FieldIn("idepoperation", new object[] {"fatven_cred", "fatacq_deb"});
            string tipoMovimento = tipoMovimentoAV();
            //string docAV = tipoRegistroAV(); 
            
            string name = "debito/credito";
            filterEpOperationDeb = QHS.IsNull("idepoperation");
            filterEpOperationDebC = QHC.IsNull("idepoperation");
            if (tipoMovimento.ToUpper() == "V") {
                //vendita
                filterEpOperationDeb = QHS.CmpEq("idepoperation", "fatven_cred");
                filterEpOperationDebC = QHC.CmpEq("idepoperation", "fatven_cred");
                //name = "credito";
            }
            if (tipoMovimento.ToUpper() == "A") {
                //acquisto
                filterEpOperationDeb = QHS.CmpEq("idepoperation", "fatacq_deb");
                filterEpOperationDebC = QHC.CmpEq("idepoperation", "fatacq_deb");
                //name = "debito";
            }
            name = tipoMovimento == "A" ? "debito" : "credito";

            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationDeb = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDeb, Conn);
            filterEpOperationDebC = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDebC, Conn);

            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);

            if (DS.accmotiveapplied_crg.Select(filterEpOperationDebC).Length == 0) {
                DS.accmotiveapplied_crg.Clear();
                if (!Meta.IsEmpty) {
                    object currid = DS.invoice.Rows[0]["idaccmotivedebit_crg"];
                    if (currid != DBNull.Value) {
                        Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_crg, "in_use", 
                            QHS.AppAnd(filterEpOperationDeb,QHS.CmpEq("idaccmotive",currid)), null, false);
                    }
                }                

                if (DS.accmotiveapplied_crg.Select(filterEpOperationDebC).Length == 0) {
                    txtCodiceCausaleCrg.Text = "";
                    txtDescrCausaleCrg.Text = "";
                }
            }
            if (DS.accmotiveapplied_debit.Select(filterEpOperationDebC).Length == 0) {
                DS.accmotiveapplied_debit.Clear();
                if (!Meta.IsEmpty) {
                    object currid = DS.invoice.Rows[0]["idaccmotivedebit"];
                    if (currid != DBNull.Value) {
                        Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit, "in_use",
                            QHS.AppAnd(filterEpOperationDeb, QHS.CmpEq("idaccmotive", currid)), null, false);
                    }
                }
                if (DS.accmotiveapplied_debit.Select(filterEpOperationDebC).Length == 0) {
                    txtCodiceCausaleDeb.Text = "";
                    TxtDescrCausaleDeb.Text = "";
                }
            }
            labDataCrgCausale.Text = "Data correzione causale di " + name;
            gboxCausale.Text = "Causale di " + name;
            gboxCausaleCrg.Text = "Causale di " + name + " aggiornata.";
            Meta.SetAutoMode(gboxCausale);
            Meta.SetAutoMode(gboxCausaleCrg);
            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            if (tipoRegistroAV().ToUpper() == "V") {
                txtProtocolDate.Enabled = false;
            }
            else {
                txtProtocolDate.Enabled = true;
            }
        }
        



        //Imposta il filtro anagrafica in base ai bit 4 e 5 di invkind.flag. Se la riga è null rimuove il filtro su PA
        void GestisciFiltroAnagrafica(DataRow invKind) {
            if (Meta.IsEmpty) {
                invKind = null;
            }
            bool soloPA = false;
            bool escludiPA = false;
            if (invKind != null) {
                int flag = CfgFn.GetNoNullInt32(invKind["flag"]);
                soloPA = (flag & 16) != 0;
                escludiPA = (flag & 32) != 0;
            }
            MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCredDeb.Name);
            if (AI == null) {
                Meta.SetAutoMode(gboxAnagrafica);
                AI = Meta.GetAutoInfo(txtCredDeb.Name);
            }

            string filter = "";
			// pubbliche amministrazioni, ipa_fe ha lunghezza 6
			// soggetti privati ipa_fe può essere assente o avere lunghezza 7, se presente
            if (soloPA) {
                filter = QHS.AppAnd(filter, QHS.AppAnd(QHS.IsNotNull("ipa_fe"), "LEN(ipa_fe)=6"));
            }
            if (escludiPA) {
				filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.IsNull("ipa_fe"), "LEN(ipa_fe) = 7")));
		 
            }
            if (Meta.InsertMode) {
                DataRow curr = DS.invoice.Rows[0];
                object idreg = curr["idreg"];
                if (idreg != DBNull.Value && CfgFn.GetNoNullInt32(idreg) != 0 && DS.registry.Rows.Count == 1) {
                    DataRow rreg = DS.registry.Rows[0];
                    if (soloPA && (rreg["ipa_fe"] == DBNull.Value || rreg["ipa_fe"].ToString().Length == 7) /*ipa a 7 cifre (soggetti privati)*/) {
                        DS.registry.Clear();
                        txtCredDeb.Text = "";
                        curr["idreg"] = DBNull.Value;
                    }
                    else {
                        if (escludiPA && /*ipa a 6 cifre (pubbliche ammin.)*/ rreg["ipa_fe"] != DBNull.Value && rreg["ipa_fe"].ToString().Length == 6) {
                            DS.registry.Clear();
                            txtCredDeb.Text = "";
                            curr["idreg"] = DBNull.Value;
                        }
                    }
                }
            }
            AI.startfilter = filter;
        }

        public void ImpostaDenominazione() {
            string myfilter = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.IsNotNull("departmentname_fe"), QHS.IsNotNull("idsor01"));
            DataTable Mytreasuer = Conn.RUN_SELECT("treasurer", "*", null,myfilter, null, null, false);
            Conn.DeleteAllUnselectable(Mytreasuer);
            if (Mytreasuer.Rows.Count == 1) {
                DataRow R = Mytreasuer.Rows[0];
                HelpForm.SetComboBoxValue(cmbDenominazione, R["idtreasurer"]);
            }
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone)
                return;
            if (T.TableName == "invoicekind") {
                EnableDisableFEEstera();
                DoEnableDisableIntrastat();
                EnableDisableFE();
                gboxTesseraSSN.Enabled = isSSN();
                if (!isSSN() && Meta.InsertMode) {
                    clearSSN();
                }
                if (Meta.InsertMode) {
                    string tiponumerazione = "";
                    byte flag = 0;
                    if (R != null) {
                        tiponumerazione = R["flag_autodocnumbering"].ToString();
                        flag = CfgFn.GetNoNullByte(R["flag"]); //se bit 0 =1 allora è vendita
                    }
                    bool autoincremento = (tiponumerazione == "S");
                    bool autofattura = ((flag & 8) != 0);
                    bool vendita = tipoRegistroAV().ToUpper() == "V"; //((flag & 1) != 0);
                    bool acquisto = ((flag & 1) == 0);
                    if (acquisto && !autofattura)
                        autoincremento = false;
                   
                    bool registroUnico = ((flag & 64) != 0);	
					if (R != null) {
                        chkProtocollanelRU.Checked = registroUnico;
					}

                    //se la numerazione è automatica il campo documento è disabilitato
                    //solo se il tipo documento ha un flag Vendita
                    if (R != null && autoincremento) {
                        DisabilitaDocumento(true);
                    }
                    else {
                        DisabilitaDocumento(false);
                    }
                    if (R != null) {
                        chkAutoFattura.Checked = autofattura;
                    }
                    if (tipoRegistroAV().ToUpper() == "V") {
                        DS.invoicedetail.Columns["!percindetraibilita"].Caption = "";
                    }
                    else {
                        DS.invoicedetail.Columns["!percindetraibilita"].Caption = "% Indetr.";
                    }
                    gboxBollo.Visible = vendita;

                    if ((vendita)|| (chkAutoFattura.Checked)) {
                        CalcolaDataDocumento(); txtDataDoc.ReadOnly = true;
                    }
                    else {
                        txtDataDoc.Text = ""; txtDataDoc.ReadOnly = false;
                    }
                    SetFilters();
                    EnableDisableToIncludeInPaymentIndicator();

                    HelpForm.SetDataGrid(gridDettagli, DS.invoicedetail);
                    HelpForm.SetDataGrid(gridDettagli, DS.invoicedetail);
                    gridDettagli.TableStyles.Clear();
                    HelpForm.SetGridStyle(gridDettagli, DS.invoicedetail);
                    formatgrids format = new formatgrids(gridDettagli);
                    format.AutosizeColumnWidth();
                    //aggiorno il codice tipo doc. dei dettagli
                    string codicetipodoc = (R == null ? "" : R["idinvkind"].ToString());
                    DS.invoicedetail.ExtendedProperties["flag"] = (R != null) ? R["flag"] : null;
                    DS.invoicedetail.ExtendedProperties["registerclass"] = tipoRegistroAV();
                    DS.invoicedetail.ExtendedProperties["flagactivity"] = TipoAttivita();
                    DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
                    if (R != null) {
                        DataRow Curr = DS.invoice.Rows[0];
                        Curr["idinvkind"] = codicetipodoc;
                        foreach (DataRow Dett in DS.invoicedetail.Rows) {
                            if (Dett["idinvkind"].ToString() != codicetipodoc)
                                Dett["idinvkind"] = codicetipodoc;
                        }
                        Meta.GetFormData(true);
                        GetNationInBlackList(Curr["idreg"], Curr["adate"]);
                    }
                    AbilitaDisabilitaWizard();
                    AbilitaTesorierePerIncasso();
                    DoVisibileLabelSoggettiNonResidenti();
                    AbilitaDisabilitaRegistroUnico();

                }
                if (Meta.IsEmpty) {
                    SetFilters();
                }
                GestisciFiltroAnagrafica(R);
                //Imposta IPA e Rif.Amma. del MITTENTE, ma solo la prima volta e se di Vendita
                //Lo fa anche se il Tipo documento è flaggato 'enable_fe_estera'
                if (Meta.InsertMode) {
                    if ((R != null) && ((tipoRegistroAV().ToUpper() == "V")|| (R["enable_fe_estera"].ToString() == "S"))) {
                        DataRow Curr = DS.invoice.Rows[0];
                        if (R["ipa_fe"].ToString() != "") {
                            txtIpa_ven_emittente.Text = R["ipa_fe"].ToString();
                            Curr["ipa_ven_emittente"] = R["ipa_fe"];
                        }
                        if (R["riferimento_amministrazione"].ToString() != "") {
                            txtRifamm_ven_emittente.Text = R["riferimento_amministrazione"].ToString();
                            Curr["rifamm_ven_emittente"] = R["riferimento_amministrazione"];
                        }
                        if((R["ipa_fe"].ToString()=="") || (R["riferimento_amministrazione"].ToString() == "")) {
                            ImpostaIpaRifEmittente();
                        }
                        ImpostaDenominazione();
					}
                    else {
                            txtIpa_ven_emittente.Text = "";
                            txtRifamm_ven_emittente.Text = "";
                            txtIpa_ven_cliente.Text = "";
                            txtRifamm_ven_cliente.Text = "";
                            txtEmailFECliente.Text = "";
                            txtPECFECliente.Text = "";
                        }
				}

                if ((tipoRegistroAV().ToUpper() == "V")||((tipoRegistroAV().ToUpper() == "A") && FatturaElettronicaEstera().ToString()=="S" && !FatturaInviataSdI())) {
                    grpDestinatarioVendita.Enabled = true;
                    grpMittenteVendita.Enabled = true;
					grpLegaleRappresentante.Enabled = true;
				}
                else {
                    grpDestinatarioVendita.Enabled = false;
                    grpMittenteVendita.Enabled = false;
					grpLegaleRappresentante.Enabled = false;
				}
            }

            if (T.TableName == "currency") {
                if (Meta.DrawStateIsDone) {
                    ImpostaTxtValuta(R);
                }
                if (Meta.DrawStateIsDone && DS.invoicedetail.Select(QHC.CmpGt("tax", 0)).Length > 0) {
                    show("Rivedere i dettagli fattura con IVA valorizzata.",
                        "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (T.TableName == "registry") {
                ImpostaCredDeb(R);
                Meta.GetFormData(true);
                if (!(Meta.IsEmpty) && Meta.DrawStateIsDone && R != null) {
                    SetModalitaPagamentoFE(DS.invoice.Rows[0]["idreg"]);
                }
                if ((!Meta.IsEmpty) && (R != null)) {
                    GetNationInBlackList(R["idreg"], DS.invoice.Rows[0]["adate"]);
                }
                if (Meta.InsertMode && Meta.DrawStateIsDone && R != null)
                    ImpostaIntracom(R["residence"]);
                //Imposta l'ipa del Fornitore, solo se Insert e trattasi di Vendita. Lo fa solo una volta, poi la persona lo puà modificare
                if (Meta.InsertMode) {
                    if ((R != null) && ((R["ipa_fe"].ToString() != "") || (R["pec_fe"].ToString() != "") || (R["email_fe"].ToString() != "")) && (tipoRegistroAV().ToUpper() == "V")) {
                        txtIpa_ven_cliente.Text = R["ipa_fe"].ToString();

						if (R["email_fe"].ToString() != "") {
							txtEmailFECliente.Text = R["email_fe"].ToString();
						}
						if (R["pec_fe"].ToString() != "") {
							txtPECFECliente.Text = R["pec_fe"].ToString();
						}

					}
                    else {
						txtIpa_ven_cliente.Text = "";
						txtEmailFECliente.Text = "";
						txtPECFECliente.Text = "";
					}
                }
                if (Meta.EditMode) {
                    if ((R != null) && ((R["ipa_fe"].ToString() != "")||(R["pec_fe"].ToString() != ""))  && (tipoRegistroAV().ToUpper() == "V")) {
                        txtIpa_ven_cliente.Text = R["ipa_fe"].ToString();
						if (R["email_fe"].ToString() != "") {
							txtEmailFECliente.Text = R["email_fe"].ToString();
						}
						if (R["pec_fe"].ToString() != "") {
							txtPECFECliente.Text = R["pec_fe"].ToString();
						}
					}
                    else {
                        txtIpa_ven_cliente.Text = "";
						txtEmailFECliente.Text = "";
						txtPECFECliente.Text = "";
					}
                }

                if (!Meta.IsEmpty) {
                    DataRow Curr = DS.invoice.Rows[0];
                    if (R != null) {
                        var sFilter=DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams].ToString();
                        string field = (sFilter.Contains("fatacq_deb"))? "idaccmotivedebit":"idaccmotivecredit";
                        if (!R[field].Equals(Curr["idaccmotivedebit"])) {
                            Curr["idaccmotivedebit"] = R[field];
                            DS.accmotiveapplied_debit.Clear();
                            Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit,null,
                                QHS.AppAnd(QHS.CmpEq("idaccmotive", Curr["idaccmotivedebit"]),sFilter
                                    ),null,false);

                            Meta.helpForm.FillControls(gboxCausale.Controls);
                        }
                    }
                }

            }

            if (T.TableName == "profservice") {
                if (R != null)
                    CollegaContratto(R);
            }
            if (T.TableName == "expirationkind") {
                if (R != null)
                    CalcolaDataScadenza();
            }
            if (T.TableName == "invoice_bolladoganale" && R != null && Meta.DrawStateIsDone) {
                LinkBollettaDoganale(R);
                return;
            }

        }

        private DateTime noNullDate(object o, DateTime defaultDate) {
            if (o == null || o == DBNull.Value)
                return defaultDate;
            try {
                return Convert.ToDateTime(o);
            }
            catch {
                return defaultDate;
            }
        }

        private void CalcolaDataScadenza() {
            if (Meta.IsEmpty)
                return;
            object TipoScadenza;
            if (cmbTipoScadenza.SelectedIndex > 0) {
                TipoScadenza = cmbTipoScadenza.SelectedValue;
            }
            else
                return;
            //if (!Meta.DrawStateIsDone) return;
            DateTime emptyDate = DateTime.Now;

            int ngiorni = CfgFn.GetNoNullInt32(txtScadenza.Text);
            object gotDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text,
                txtDataContabile.Tag.ToString());
            DateTime dataRegistrazione = noNullDate(gotDate, emptyDate);
            DateTime dataDocumento = emptyDate;
            if (txtDataDoc.Text != "") {
                dataDocumento =
                    noNullDate(
                        HelpForm.GetObjectFromString(typeof(DateTime), txtDataDoc.Text, txtDataDoc.Tag.ToString()),
                        emptyDate);
            }

            DateTime dataRicezione = emptyDate;
            if (txtProtocolDate.Text != "") {
                dataRicezione =
                    noNullDate(
                        HelpForm.GetObjectFromString(typeof(DateTime), txtProtocolDate.Text,
                            txtProtocolDate.Tag.ToString()),
                        emptyDate);
            }
            DateTime dataScadenza = DateTime.MinValue;
            //  1	Data contabile = data registrazione
            //  2	Data documento
            //  3	Fine mese data documento
            //  4	Fine mese data contabile
            //  5	Pagamento Immediato
            //  6   Data ricezione
            if (dataRegistrazione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) > 0) {
                    dataScadenza = dataRegistrazione.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) == 0) {
                    dataScadenza = dataRegistrazione;
                }
            }
            if (dataDocumento != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(ngiorni) > 0 &&
                    dataDocumento != DateTime.MinValue) {
                    dataScadenza = dataDocumento.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(ngiorni) == 0 &&
                    txtDataDoc.Text != "") {
                    dataScadenza = dataDocumento;
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 3 && txtDataDoc.Text != "") {
                    int intMese = dataDocumento.Month;
                    int intAnno = dataDocumento.Year;
                    int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                    DateTime FineMeseDataDocumento = new DateTime(intAnno, intMese, intGiorno);
                    FineMeseDataDocumento = FineMeseDataDocumento.AddDays(ngiorni);
                    dataScadenza = FineMeseDataDocumento;
                }
            }
            if (dataRegistrazione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 4) {
                    int intMese = dataRegistrazione.Month;
                    int intAnno = dataRegistrazione.Year;
                    int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                    DateTime FineMeseDataContabile = new DateTime(intAnno, intMese, intGiorno);
                    FineMeseDataContabile = FineMeseDataContabile.AddDays(ngiorni);
                    dataScadenza = FineMeseDataContabile;
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 5) {
                    dataScadenza = dataRegistrazione;
                }
            }

            if (dataRicezione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) > 0 &&
                    txtProtocolDate.Text != "") {
                    dataScadenza = dataRicezione.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) == 0 &&
                    txtProtocolDate.Text != "") {
                    dataScadenza = dataRicezione;
                }
            }
            txtDataScadenza.Text = (dataScadenza == emptyDate)
                ? ""
                : HelpForm.StringValue(dataScadenza, txtDataScadenza.Tag.ToString());
        }

        private void CalcolaDataDocumento() {
            if (Meta.IsEmpty)
                return;
            if (!Meta.DrawStateIsDone) return;
            object idinvkind = cboTipo.SelectedValue;
            if (CfgFn.GetNoNullDecimal(idinvkind) == 0) return;
            DataRow[] invk = DS.invoicekind.Select(QHC.CmpEq("idinvkind", idinvkind));
            int flag = CfgFn.GetNoNullInt32(invk[0]["flag"]);
            //se bit 0 =1 allora è vendita

            bool vendita = tipoRegistroAV().ToUpper() == "V"; //((flag & 1) != 0);
            bool autofattura = chkAutoFattura.Checked;
            if ((!vendita)&&(!autofattura)) return;
            //if (!Meta.DrawStateIsDone) return;
            DateTime emptyDate = DateTime.Now;

            object gotDate = HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text,
                txtDataContabile.Tag.ToString());
            DateTime dataRegistrazione = noNullDate(gotDate, emptyDate);
            DateTime dataDocumento = emptyDate;
            if (txtDataDoc.Text != "") {
                dataDocumento =
                    noNullDate(
                        HelpForm.GetObjectFromString(typeof(DateTime), txtDataDoc.Text, txtDataDoc.Tag.ToString()),
                        emptyDate);
            }

            if (dataDocumento != dataRegistrazione)
                txtDataDoc.Text = (dataRegistrazione == emptyDate)
                     ? ""
                     : HelpForm.StringValue(dataRegistrazione, txtDataDoc.Tag.ToString());
        }

        private object CalcolaDocumento(DataRow R, DataColumn C, DataAccess Conn) {

            object codiceDoc = R["idinvkind"];
            DataRow RInvKind = DS.invoicekind.Select(QHC.CmpEq("idinvkind", codiceDoc))[0];
            object formatString = RInvKind["formatstring"];
            if (formatString == DBNull.Value)
                formatString = "{0:yy}/{1:d6}";
            DateTime AA = new DateTime(CfgFn.GetNoNullInt32(R["yinv"]), 1, 1);
            string doc = String.Format(formatString.ToString(), AA, R["ninv"]);
            //System.Diagnostics.Debug.WriteLine("documento [" + doc + "]");
            return doc;
        }

        /// <summary>
        /// Imposta o Rimuove l'autoincremento dal campo
        /// </summary>
        /// <param name="disable">Se true, il campo è ad autoincremento, altrimenti è ad inserimento manuale</param>
        private void DisabilitaDocumento(bool disable) {
            txtDocumento.ReadOnly = disable;
            DataColumn C = DS.invoice.Columns["doc"];

            if (disable) {
                DS.invoice.ExtendedProperties["docautomatico"] = "S";
                RowChange.MarkAsAutoincrement(C, null, null, 6);
                RowChange.MarkAsCustomAutoincrement(C, new RowChange.CustomCalcAutoID(CalcolaDocumento));
            }
            else {
                DS.invoice.ExtendedProperties["docautomatico"] = "N";
                RowChange.ClearAutoIncrement(C);
                RowChange.ClearCustomAutoIncrement(C);
            }

            if (Meta.InsertMode) {
                if (disable) {
                    txtDocumento.Clear();
                }
                else {
                    txtDocumento.PasswordChar = Convert.ToChar(0);
                }

            }
        }

        private decimal RoundDecimal6(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta*10000000);
            if (truncated > 0) {
                if ((truncated%10) >= 5)
                    truncated += 5;
            }
            else {
                if (((-truncated)%10) >= 5)
                    truncated -= 5;
            }
            truncated = truncated/10;
            truncated = Decimal.Truncate(truncated);
            return truncated/1000000;
        }

        private decimal RoundDecimal10(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta*100000000000);
            if (truncated > 0) {
                if ((truncated%10) >= 9)
                    truncated += 9;
            }
            else {
                if (((-truncated)%10) >= 9)
                    truncated -= 9;
            }
            truncated = truncated/10;
            truncated = Decimal.Truncate(truncated);
            return truncated/10000000000;
        }


        private void CalcolaImporto() {
            decimal imponibile = 0;
            decimal imposta = 0;
            decimal indetraibile = 0;
            decimal totale = 0;
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }
            tassocambio = RoundDecimal10(tassocambio);
            foreach (DataRow R in DS.invoicedetail.Rows) {
                if (R.RowState == DataRowState.Deleted)
                    continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(R["npackage"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                imponibile += CfgFn.RoundValuta((R_imponibile*R_quantita*(1 - R_sconto))*tassocambio);
                imposta += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"]));
                indetraibile += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["unabatable"]));
            }
            totale = imponibile + imposta;
            decimal imponibileEUR = CfgFn.RoundValuta(imponibile);
            decimal impostaEUR = CfgFn.RoundValuta(imposta);
            decimal totaleEUR = CfgFn.RoundValuta(totale);
            decimal indetraibileEUR = CfgFn.RoundValuta(indetraibile);
            txtImponibile.Text = imponibileEUR.ToString("c");
            txtIva.Text = impostaEUR.ToString("c");
            txtTotale.Text = totaleEUR.ToString("c");
            txtIndetraibile.Text = indetraibileEUR.ToString("c");
        }


        private void SetChildParameter(DataRow ValutaRow) {
            if (Meta.IsEmpty)
                return;
            if (ValutaRow == null) {
                DS.invoicedetail.ExtendedProperties[MetaData.ExtraParams] = null;
                return;
            }

            Hashtable Params = new Hashtable();
            Params["nomevaluta"] = ValutaRow["description"];
            Params["codicevaluta"] = ValutaRow["idcurrency"];
            try {
                Params["cambio"] = Double.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
                Params["cambio"] = 0;
            }
            DS.invoicedetail.ExtendedProperties[MetaData.ExtraParams] = Params;
            RicalcolaIvaDettagli(CfgFn.GetNoNullDouble(Params["cambio"]));
        }


        private double lastApplied = 0;
        void RicalcolaIvaDettagli(double tasso) {
            if (tasso == lastApplied) return;
            bool someChange = false;
            foreach (DataRow r in DS.invoicedetail.Select()) {
                double aliquota =
                    CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                        QHS.CmpEq("idivakind", r["idivakind"]), "rate"));
                double percindeduc =
                    CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                        QHS.CmpEq("idivakind", r["idivakind"]), "unabatabilitypercentage"));

                double imponibile = CfgFn.GetNoNullDouble(r["taxable"]);
                double quantitaConfezioni = CfgFn.GetNoNullDouble(r["npackage"]);
                double sconto = CfgFn.GetNoNullDouble(r["discount"]);
                double imponibiletot = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)));
                double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tasso);
                double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR * aliquota);
                double impindeducEUR = CfgFn.RoundValuta(ivaEUR * percindeduc);

                decimal oldTax = CfgFn.GetNoNullDecimal(r["tax"]);
                decimal oldUnabatable = CfgFn.GetNoNullDecimal(r["unabatable"]);

                decimal newTax = CfgFn.GetNoNullDecimal(ivaEUR);
                decimal newUnabatable = CfgFn.GetNoNullDecimal(impindeducEUR);

                if (oldTax != newTax || newUnabatable != oldUnabatable) {
                    r["tax"] = newTax;
                    r["unabatable"] = newUnabatable;
                    someChange = true;
                }
            }

            if (someChange) {
                show(this, "Gli importi dell'iva sono stati cambiati in base al nuovo tasso di cambio.\n" +
                                      "E' necessario controllarne gli importi.", "Avviso");
            }

            lastApplied = tasso;
        }

        //Imposta Txt in base a valore in riga corrente
        private void ImpostaTxtValuta() {
            if (Meta.IsEmpty)
                return;
            object codicevaluta = DS.invoice.Rows[0]["idcurrency"];
            if (codicevaluta == DBNull.Value) {
                ImpostaTxtValuta(null);
            }
            else {
                if (DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta)).Length == 0) {
                    QueryCreator.ShowError(this, "L'anagrafica è associato ad una valuta non valida.", null);
                }
                else {
                    DataRow CurrValuta = DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta))[0];
                    ImpostaTxtValuta(CurrValuta);
                }
            }
        }


        private void ImpostaTxtValuta(DataRow ValutaRow) {
            if (ValutaRow == null) {
                txtCambio.ReadOnly = false;
                //txtCambio.Text="";		
                Meta.SetAutoField(DBNull.Value, txtValuta);
                SetChildParameter(null);
                return;
            }

            if ( //(ValutaRow["flageuro"].ToString().ToUpper()=="S")||
                (ValutaRow["codecurrency"].ToString().ToUpper() == "EUR")
                ) {
                //				txtCambio.ReadOnly=true;
                //				double tasso= CfgFn.GetNoNullDouble(ValutaRow["paritaeuro"]);
                //				if (tasso==0) tasso=1;
                //				tasso=1/tasso;
                double tasso = 1;
                txtCambio.ReadOnly = true;
                txtCambio.Text = HelpForm.StringValue(tasso, txtCambio.Tag.ToString()); //tasso.ToString("n");
            }
            else {
                txtCambio.ReadOnly = false;
                //txtCambio.Text="";
            }
            txtCambio.ReadOnly = false;
            Meta.SetAutoField(ValutaRow["idcurrency"], txtValuta);
            SetChildParameter(ValutaRow);
        }


        private void ImpostaCredDeb(DataRow R) {
            if (R == null)
                return;
            if (Meta.IsEmpty)
                return;
            DataRow DefModPag = CfgFn.ModalitaPagamentoDefault(Meta.Conn, R["idreg"]);
            if (DefModPag != null) {
                txtScadenza.Text = DefModPag["paymentexpiring"].ToString();
                HelpForm.SetComboBoxValue(cmbTipoScadenza, DefModPag["idexpirationkind"]);
                if (DefModPag["idcurrency"] != DBNull.Value) {
                    DS.invoice.Rows[0]["idcurrency"] = DefModPag["idcurrency"];
                    ImpostaTxtValuta();
                }
            }
        }

        /// <summary>
        /// true per abilitare Tab intracomunitaria
        /// </summary>
        /// <param name="R"></param>
        private void ImpostaIntracom(object idresidence) {
            if (Meta.IsEmpty)
                return;
            if (cboTipo.SelectedIndex <= 0)
                return;

            object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
                "coderesidence");
            if (Ocoderesidence == null || Ocoderesidence == DBNull.Value)
                return;
            string coderesidence = Ocoderesidence.ToString().ToUpper();
            DataRow Curr = DS.invoice.Rows[0];
            object oldvalue = Curr["flagintracom"];
            object newval = DBNull.Value;
            if (coderesidence == "I") {
                newval = "N";
            }
            if (coderesidence == "J") {
                newval = "S";
            }
            if (coderesidence == "X") {
                newval = "X";
            }
            if (oldvalue.ToString() != newval.ToString()) {
                if (newval.ToString() == "X")
                    show("Il tipo fattura è stato impostato come 'Extra-UE'", "Avviso");
                if (newval.ToString() == "S")
                    show("Il tipo fattura è stato impostato come 'Intracomunitaria'", "Avviso");
            }
            rdbitalia.Checked = false;
            rdbextracom.Checked = false;
            rdbintracom.Checked = false;

            switch (newval.ToString()) {
                case "N":
                    rdbitalia.Checked = true;
                    break;
                case "X":
                    rdbextracom.Checked = true;
                    break;
                case "S":
                    rdbintracom.Checked = true;
                    break;
            }

        }

        private void btnAggiungiDaOrdini_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            var R = DS.invoice[0];
            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                show("Selezionare prima il fornitore.");
                return;
            }
            object idreg = R["idreg"];
            string regfilter = QHS.CmpEq("idreg", idreg);
            object idinvkind = R["idinvkind"];
            string idinvkindfilter = QHS.CmpEq("idinvkind", idinvkind);
            string idinvkindfilter_C = QHC.CmpEq("idinvkind", idinvkind);
            string flagmixfilter = null;
            DataRow[] TipoFattura = DS.invoicekind.Select(idinvkindfilter_C);
            if (TipoFattura.Length != 0) {
                //Anche il flagmixed del tipo fattura lo stiamo dismettendo,  in favore dell'attività del registro iva associato
                //if ((CfgFn.GetNoNullByte(TipoFattura[0]["flag"]) & 2) != 0) {
                //    flagmixfilter = QHS.CmpEq("flagmixed", CfgFn.DecodeToString(TipoFattura[0]["flag"], 2));
                //    //QHS.BitSet("flag", 1);
                //}
                //else {
                //    flagmixfilter = QHS.CmpEq("flagmixed", CfgFn.DecodeToString(TipoFattura[0]["flag"], 0));
                //    //QHS.BitClear("flag", 1);
                //}
                //Vede quali tipi registro sono associati a questo tipo fattura
                DataRow[] Reg = DS.invoicekindregisterkind.Select(idinvkindfilter_C);
                foreach (DataRow RREg in Reg) {
                    string filterregkind = QHC.CmpEq("idivaregisterkind", RREg["idivaregisterkind"]);
                    DataRow[] RegKind = DS.ivaregisterkind.Select(filterregkind);
                    if (RegKind.Length == 0)
                        continue;
                    int flaga = CfgFn.GetNoNullInt32(RegKind[0]["flagactivity"]);
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
            DataTable T = DS.invoicedetail;
            object idcurrency = R["idcurrency"];
            DataRow[] Selected = null;
            var F = new FrmWizardScegliDettagli(Meta, regfilter, flagmixfilter, idcurrency, T,
                !chkflag_ddt.Checked);
            if (F.ShowDialog(this) != DialogResult.OK)return;
            Selected = F.SelectedRows;
            if (Selected == null)return;
            if (Selected.Length == 0)return;

            //Aggiornamento causali EP
            DataRow rSelected = Selected[0];
            string filterMandate = QHS.AppAnd(QHS.CmpEq("idmankind", rSelected["idmankind"]),
                                              QHS.CmpEq("yman", rSelected["yman"]),
                                              QHS.CmpEq("nman", rSelected["nman"]));
            DataTable Mandate = Conn.RUN_SELECT("mandate", "*", null, filterMandate, null, false);
            if ((Mandate != null) && (Mandate.Rows.Count != 0)) {
                DataRow rMandate = Mandate.Rows[0];
                if ((
                    (rMandate["idaccmotivedebit"] != DBNull.Value) ||
                    (rMandate["idaccmotivedebit_crg"] != DBNull.Value) ||
                    (rMandate["idaccmotivedebit_datacrg"] != DBNull.Value))
                     &&
                    ((R["idaccmotivedebit"] == DBNull.Value) &&
                     (R["idaccmotivedebit_crg"] == DBNull.Value) &&
                     (R["idaccmotivedebit_datacrg"] == DBNull.Value))
                    ) {
                    if (show("Si desidera aggiornare le causali EP prendendole dal contratto passivo? ",
                     "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {

                        object idaccmotivedebit = rMandate["idaccmotivedebit"];
                        R["idaccmotivedebit"] = idaccmotivedebit;
                        object idaccmotivedebit_crg = rMandate["idaccmotivedebit_crg"];
                        R["idaccmotivedebit_crg"] = idaccmotivedebit_crg;
                        R["idaccmotivedebit_datacrg"] = rMandate["idaccmotivedebit_datacrg"];
                    }
                }
            }
            int flag_requested_doc = 0;
            foreach (DataRow Curr in Selected) {
                decimal unitsforpackage = 1;
                if (Curr["unitsforpackage"] != DBNull.Value)
                    unitsforpackage = CfgFn.GetNoNullInt32(Curr["unitsforpackage"]);
                decimal NumberResidual = CfgFn.GetNoNullDecimal(Curr["residual"])*unitsforpackage;
                AddMandateDetailRow(Curr, CfgFn.GetNoNullDecimal(NumberResidual));
                flag_requested_doc = flag_requested_doc | CfgFn.GetNoNullInt32(Curr["requested_doc"]);
             }
            R["requested_doc"] = flag_requested_doc;




            Meta.myGetData.GetTemporaryValues(DS.invoicedetail);
            Meta.FreshForm(true);
        }

        /// <summary>
        /// stabilisce se una fattura è di tipo commerciale /promiscuo oppure no
        /// </summary>
        /// <returns></returns>
        private bool attivitaCommercialeOPromiscua() {
            // stabilisce se una fattura è di tipo commerciale oppure promiscuo
            if (cboTipo.SelectedIndex <= 0)
                return false;
            object idinvkind = cboTipo.SelectedValue;
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            bool CommercialeoPromiscua = false; // istituzionale
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
                    continue;
                DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
                if (CfgFn.GetNoNullInt32(IvaRegKind["flagactivity"]) != 1) // diversa da istituzionale
                    CommercialeoPromiscua = true;
            }
            return (CommercialeoPromiscua);
        }

        private void AdjustIdGroup(DataRow RInvDetail) {
            string fk_me = QHC.CmpKey(RInvDetail);
            if (RInvDetail["idmankind"] == DBNull.Value) return;
            string fman_me = QHC.MCmp(RInvDetail, "idmankind", "yman", "nman");

            //idgroup del dettaglio ordine associato al dett. fattura RInvDetail
            object idgroup_me = Conn.DO_READ_VALUE("mandatedetail",
                QHS.AppAnd(fman_me, QHS.CmpEq("rownum", RInvDetail["manrownum"])), "idgroup");
            if (idgroup_me == null) idgroup_me = DBNull.Value;
            if (idgroup_me==DBNull.Value) return;

            foreach (DataRow RDet in DS.invoicedetail.Select()) {
                string fk = QHC.CmpKey(RDet);
                if (fk_me == fk) continue; //è il medesimo dett. fattura
                string fman = QHC.MCmp(RDet, "idmankind", "yman", "nman");
                if (fman_me != fman) continue; //non è associato allo stesso ordine

                //Se stesso dett. ordine associato NON c'è bisogno di sistemare l'idgroup
                if (RInvDetail["manrownum"].ToString() == RDet["manrownum"].ToString()) continue;

                object idgroup = Conn.DO_READ_VALUE("mandatedetail",
                    QHS.AppAnd(fman, QHS.CmpEq("rownum", RDet["manrownum"])),
                    "idgroup"); //idgroup del dettaglio ordine associato
                if (idgroup == null) idgroup = DBNull.Value;
                if (idgroup == DBNull.Value) continue;

                //Se il det. ordine è diveso ma pari idgroup allora stiamo collegando due dett. fattura ad un dett.ordine splittato
                //  e quindi dovrebbero essere anch'essi gemellati con pari idgroup
                if (idgroup.ToString() != idgroup_me.ToString()) continue;

                RInvDetail["idgroup"] = RDet["idgroup"];
                break;
            }
        }

        private void AdjustIdGroupEstimate(DataRow RInvDetail) {
            string fk_me = QHC.CmpKey(RInvDetail);
            if (RInvDetail["idestimkind"] == DBNull.Value) return;
            string fman_me = QHC.MCmp(RInvDetail, "idestimkind", "yestim", "nestim");
            object idgroup_me = Conn.DO_READ_VALUE("estimatedetail",
                QHS.AppAnd(fman_me, QHS.CmpEq("rownum", RInvDetail["estimrownum"])),
                "idgroup");
            foreach (DataRow RDet in DS.invoicedetail.Select()) {
                string fk = QHC.CmpKey(RDet);
                if (fk_me == fk) continue;
                string fman = QHC.MCmp(RDet, "idestimkind", "yestim", "nestim");
                if (fman_me != fman) continue;

                //Se stesso dett. c.attivo associato NON c'è bisogno di sistemare l'idgroup
                if (RInvDetail["estimrownum"].ToString() == RDet["estimrownum"].ToString()) continue;

                object idgroup = Conn.DO_READ_VALUE("estimatedetail",
                    QHS.AppAnd(fman, QHS.CmpEq("rownum", RDet["estimrownum"])),
                    "idgroup");


                if (idgroup.ToString() != idgroup_me.ToString()) continue;
                RInvDetail["idgroup"] = RDet["idgroup"];
                break;
            }
        }

        /// <summary>
        /// Crea e restituisce una riga di invoicedetail in base al dettaglio ordine
        /// </summary>
        /// <param name="RmanDet"></param>
        /// <param name="number">quantità da collegare del dettaglio ordine</param>
        /// <returns></returns>
        private DataRow AddMandateDetailRow(DataRow RmanDet, decimal number) {
            DataRow R = DS.invoice.Rows[0];
            decimal unitsforpackage = 1;
            if (RmanDet["unitsforpackage"] != DBNull.Value &&
                CfgFn.GetNoNullDecimal(RmanDet["unitsforpackage"]) != 0)
                unitsforpackage = CfgFn.GetNoNullDecimal(RmanDet["unitsforpackage"]);
            decimal npackage = number/unitsforpackage;
            MetaData MI = MetaData.GetMetaData(this, "invoicedetail");
            MI.SetDefaults(DS.invoicedetail);


            object idivakind = DBNull.Value;

            //Calcola un tipo iva adeguato
            if (RmanDet["idivakind"] == DBNull.Value) {
                decimal taxrate = CfgFn.GetNoNullDecimal(RmanDet["taxrate"]);
                DataRow[] Valuta = DS.ivakind.Select(
                    QHC.AppAnd(QHC.CmpEq("rate", taxrate), QHC.CmpEq("active", "S")),
                    "unabatabilitypercentage ASC");
                if ((Valuta == null) || (Valuta.Length == 0)) {
                    show($"Non è stata trovata un\'aliquota per l\'iva al {taxrate:n}%");
                    return null;
                }
                else {
                    DataRow Val = Valuta[0];
                    idivakind = Val["idivakind"];
                }
            }

            DataRow InvDet = MI.Get_New_Row(R, DS.invoicedetail);
            foreach (string colname in
                new string[] {
                    "idmankind", "detaildescription",
                    "yman", "nman", "taxable", "tax", "discount", "idupb","idupb_iva",
                    "idsor1", "idsor2", "idsor3", "idcostpartition", "competencystart", "competencystop",
                    "idaccmotive", "va3type", "cigcode",
                    "idlist", "idunit", "idpackage", "unitsforpackage", "expensekind", "idepexp","idsor_siope", "cupcode"
                }) {
                if (RmanDet.Table.Columns.Contains(colname)) InvDet[colname] = RmanDet[colname];
                
            }
            //Se il metodo viene chiamato dall'importazione FE, copia anche le info della fattura madre, qualora si stia importando una nota di variazione.
            foreach (string colname in
                new string[] {"idinvkind_main", "yinv_main", "ninv_main"}) {
                if (RmanDet.Table.Columns.Contains(colname))
                    InvDet[colname] = RmanDet[colname];
            }
            InvDet["manrownum"] = RmanDet["rownum"];
            InvDet["number"] = number;
            InvDet["npackage"] = npackage;
            // A: bene inventariabile
            // P: Bene non inventariabile  
            // S: Servizi
            // O: Altro
            if (R["flagintracom"].ToString().ToUpper() == "S") {
                if ((RmanDet["assetkind"].ToString() == "A") || (RmanDet["assetkind"].ToString() == "P")) {
                    InvDet["intrastatoperationkind"] = "B";
                }
                if (RmanDet["assetkind"].ToString() == "S") {
                    InvDet["intrastatoperationkind"] = "S";
                }
            }

            double imponibile = CfgFn.GetNoNullDouble(RmanDet["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(number);
            double aliquota = CfgFn.GetNoNullDouble(RmanDet["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(RmanDet["discount"]);
            double imponibileTOT = (imponibile*quantita*(1 - sconto));

            double ivaTOT = CfgFn.GetNoNullDouble(RmanDet["tax"])*
                            (CfgFn.GetNoNullDouble(number)/CfgFn.GetNoNullDouble(RmanDet["number"]));
            double impindeduc = CfgFn.GetNoNullDouble(RmanDet["unabatable"])*
                                (CfgFn.GetNoNullDouble(number)/CfgFn.GetNoNullDouble(RmanDet["number"]));

            InvDet["tax"] = CfgFn.RoundValuta(ivaTOT);
            InvDet["unabatable"] = CfgFn.RoundValuta(impindeduc);
            if (RmanDet["idivakind"] == DBNull.Value) {
                InvDet["idivakind"] = idivakind;
            }
            else {
                InvDet["idivakind"] = RmanDet["idivakind"];
            }
            AdjustIdGroup(InvDet);
            return InvDet;
        }

        private void chb_IVADifferita_CheckedChanged(object sender, System.EventArgs e) {
            //			if (chb_IVADifferita.Checked) calcolaIVALiquidata();
        }




        private bool Contabilizzata() {
            bool contab = false;
            foreach (DataRow r in DS.invoicedetail.Select()) {
                if (r["idexp_iva"] != DBNull.Value)
                    contab = true;
                if (r["idexp_taxable"] != DBNull.Value)
                    contab = true;
                if (r["idinc_iva"] != DBNull.Value)
                    contab = true;
                if (r["idinc_taxable"] != DBNull.Value)
                    contab = true;
            }
            return contab;
        }

        bool isPARegistry() {
            if (DS.registry.Rows.Count == 0)
                return false;
            if (DS.registry.Rows[0]["flag_pa"].ToString().ToUpperInvariant() == "S")
                return true;
            return false;
        }

        private void DoManageSplitPayment() {
            chk_enable_split_payment.Enabled = false;
            if (Meta.IsEmpty) {
                chk_enable_split_payment.Enabled = true;
                return;
            }
            if ((Meta.EditMode)
                    //&& (chk_auto_split_payment.CheckState == CheckState.Checked)
                    ) {
                // fattura salvata con gestione manuale o fattura già salvata
                return;
            }

            if (DS.invoice.Rows.Count == 0)
                return;
            if (DS.invoice.Rows[0].RowState == DataRowState.Deleted)
                return;
            if (GetGeneralFlagSplitPayment() == false)
                return; // leggo la configurazione annuale

            // task 8446 no split payment per bolla doganale
            if (chkBollaDoganale.Checked) {
                DoEnableDisableSplitPayment(false);
                return;
            }

            // 1) Controllo che non sia stata abilitata la gestione manuale del flag, in tal caso return 
            if (chk_auto_split_payment.CheckState == CheckState.Checked && chk_auto_split_payment.Enabled) {
                chk_enable_split_payment.Enabled = true;
                return; //gestione manuale 
            }
            // Questo controllo deve venire prima degli altri poiché se c'è la contabilizzazione nulla va mai variato
            //
            // 2) Controllo che la fattura non sia stata già contabilizzata, in tal caso il flag Crea Recupero varrà N
            if (Contabilizzata()) {
                return;
            }

            //Non tocca le fatture liquidate
            if (DS.invoicedeferred._hasRows() ) {
                return;
            }

            DataRow Curr = DS.invoice.Rows[0];
            //3) Se fattura collegata a contratto professionale la modifica del flag split payment deve essere abilitata
            if (DS.profservice.Select().Length > 0) {
                if (Curr["docdate"] != DBNull.Value) {
                    DateTime d = (DateTime)Curr["docdate"];
                    DateTime startNoSplit = new DateTime(2018,7,15);
                    if (d.CompareTo(startNoSplit)>=0) {
                        DoEnableDisableSplitPayment(false);
                    }
                    else {
                         chk_enable_split_payment.Enabled = true;
                    }
                    return;
                }

                DoEnableDisableSplitPayment(true);               
                return;
            }



            // 4) Tipo fattura non impostato
          
            if (Curr["idinvkind"] == DBNull.Value) {
                DoEnableDisableSplitPayment(false);
                return;
            }

            bool anagraficaPubblicaAmministrazione = isPARegistry();

            // 5) Controllo che la fattura sia di acquisto, non intracom, non Extra - UE. In tal caso Crea Recupero Varrà N
            if (tipoRegistroAV() == "V") {
                if (!anagraficaPubblicaAmministrazione) {
                    //vendita non split
                    DoEnableDisableSplitPayment(false);
                    return;
                }
            }
            else {

                if (tipoRegistroAV() != "A") {
                    DoEnableDisableSplitPayment(false);
                    return;
                }

                // 6) Flagintracom può valere: S-intracom, N-Italia o X-extracom.
                bool isIntraCom = !rdbitalia.Checked;
                if (isIntraCom) {
                    DoEnableDisableSplitPayment(false);
                    return;
                }

            }
            // 7) Controllo che la data di registrazione della fattura sia 2015, altrimenti Crea Recupero varrà N
            if (Curr["docdate"] == DBNull.Value) {
                DoEnableDisableSplitPayment(false);
                return;
            }
            if (Curr["docdate"] != DBNull.Value) {
                DateTime d = (DateTime) Curr["docdate"];
                if (d.Year < 2015) {
                    DoEnableDisableSplitPayment(false);
                    return;
                }
            }



            DoEnableDisableSplitPayment(true);
        }


        /// <summary>
        /// imposta o azzera il flag SplitPayment
        /// </summary>
        /// <param name="enable"></param>
        private void DoEnableDisableSplitPayment(bool enable) {
            DataRow Curr = DS.invoice.Rows[0];
            if (enable) {
                Curr["flag_enable_split_payment"] = "S";
                Curr["flag_reverse_charge"] = "N";
            }
            else {
                Curr["flag_enable_split_payment"] = "N";
                Curr["flag_reverse_charge"] = "N";
            }

            chk_enable_split_payment.Checked = enable;
            chk_enable_reverse_charge.Checked = false;
        }


        private bool DoManageManualSplitPayment() {
            object idflowchart = Conn.GetSys("idflowchart");
            //doManage = false; //solo per test TOGLIERE POI
            if (idflowchart == null || idflowchart == DBNull.Value)
                return true; //Nessuna restrizione

            object manage_split_payment = Conn.GetUsr("manage_split_payment");
            if (manage_split_payment != null && manage_split_payment.ToString().ToUpper() == "'S'") {
                return true;
            }

            return false;
        }





        //private string idrelated = "";


        public void MetaData_BeforePost() {
            if (DS.invoice.Rows.Count == 0) {
                //It was an Insert / Cancel
                DS.ivaregister.Clear();
                DS.uniqueregister.Clear();
                DS.invoicedetail.Clear();
                DS.invoiceattachment.Clear();
                DS.invoicesorting.Clear();
                DS.profservice.Clear();
                DS.stock.Clear();
                DS.stockview.Clear();
                return;
            }

            EPM.beforePost();

            DataRow Curr = DS.invoice.Rows[0];
            if (Curr.RowState != DataRowState.Deleted) {
                foreach (DataRow RDet in DS.invoicedetail.Select()) {
                    if (RDet["ycon"] != DBNull.Value) {
                        string filterProfService = "";
                        filterProfService =
                            QHC.AppAnd(QHC.CmpEq("ycon", RDet["ycon"]), QHC.CmpEq("ncon", RDet["ncon"]));

                        if (DS.profservice.Select(filterProfService).Length == 0) {
                            string filterProfServicedb = "";
                            filterProfServicedb
                                = //QHS.AppAnd(QHS.CmpEq("ycon", RDet["ycon"]), QHS.CmpEq("ncon", RDet["ncon"]));
                                QHS.MCmp(RDet, "ycon", "ncon");

                            /*
                             *   DS.assetacquireview
                        .getFromDb(Meta.Conn,
                                    q.mCmp(FR.Selected, "idinvkind", "yinv", "ninv") & q.isNull("idassetload")
                                      & getInvFilter(OldIdinventory)
                                      & (flagcausale ? q.eq("idmot", curr.idmotValue) : q.constant(true))
                                    );
                             * */
                            var listProfSer = DS.profservice.getFromDb(Conn, filterProfServicedb);

                            if (listProfSer.Length != 0) {
                                //Conn.RUN_SELECT_INTO_TABLE(DS.profservice, null, filterProfServicedb, null, true);
                                //if (DS.profservice.Select(filterProfService).Length != 0) {
                                //else {
                                //    lista._forEach(r => r["idassetload"] = Curr.idassetload);
                                //}
                                listProfSer._First().idinvkind = (int) Curr["idinvkind"];
                                listProfSer._First().yinv = (short) Curr["yinv"];
                                listProfSer._First().ninv = (int) Curr["ninv"];

                                // DS.profservice.Select(filterProfService)[0];
                                //RProf["yinv"] = Curr["yinv"];
                                //RProf["ninv"] = Curr["ninv"];
                                //RProf["idinvkind"] = Curr["idinvkind"];
                            }

                        }
                    }

                }

            }


            if (Curr.RowState == DataRowState.Deleted) {
                DS.stockview.Clear();
                if (Curr["flag_ddt", DataRowVersion.Original].ToString().ToUpper() == "S") {
                    foreach (DataRow RS in DS.stock.Select()) {
                        RS["idinvkind"] = DBNull.Value;
                        RS["yinv"] = DBNull.Value;
                        RS["ninv"] = DBNull.Value;
                        RS["inv_idgroup"] = DBNull.Value;
                        RS["amount"] = DBNull.Value;
                    }
                }
                else {
                    foreach (DataRow RS in DS.stock.Select()) {
                        RS.Delete();
                    }
                }


                foreach (DataRow RR in DS.ivaregister.Select()) {
                    RR.Delete();
                }

                //idrelated = EP_functions.GetIdForDocument(DS.invoice.Rows[0]);
                //fromDelete = true;
            }
            else {
                AllineaStock();
            }

            //Rimuove collegamento con assetacquire
            foreach (DataRow R in DS.assetacquire.Select()) {
                if (R["idinvkind"] == DBNull.Value) {
                    R["invrownum"] = DBNull.Value;
                }

            }

        }

        private object RichiediData(DataRow rInvoicedetail) {
            string t = "Data annullamento dettaglio ordine N." + rInvoicedetail["nman"] + "/" + rInvoicedetail["yman"] +
                       " riga " + rInvoicedetail["manrownum"];
            AskDate frm = new AskDate(t, Meta.Conn);
            DialogResult dr = frm.ShowDialog();
            if ((dr != DialogResult.OK) || (frm.txtData.Text == "")) {
                show(this,
                    "Non è stata impostata la data annullamento per il dettaglio ordine associato al dettaglio fattura selezionato.",
                    "Operazione annullata");
                return null;
            }
            object dataAnnullamento = HelpForm.GetObjectFromString(typeof(DateTime), frm.txtData.Text, "x.y");
            if ((dataAnnullamento == null) || (dataAnnullamento == DBNull.Value)) {
                show(this, "La data immessa non è valida, procedura annullata", "Errore");
                return null;
            }
            return dataAnnullamento;
        }

        /// <summary>
        /// Crea un nuovo dettaglio a partire da rMandateDetail con npackage,iva,taxable,unabatable di DettOrdinedaCreare
        /// </summary>
        /// <param name="DettOrdinedaCreare"></param>
        /// <param name="rMandateDetail"></param>
        /// <param name="dataAnnullamento"></param>
        private DataRow CreaNuovodettaglio(newDettMandate DettOrdinedaCreare, DataRow rMandateDetail,
            object dataAnnullamento) {
            MetaData MetaManDet = Meta.Dispatcher.Get("mandatedetail");
            MetaManDet.SetDefaults(DS.mandatedetail);
            MetaData.SetDefault(DS.mandatedetail, "idmankind", rMandateDetail["idmankind"]);
            MetaData.SetDefault(DS.mandatedetail, "yman", rMandateDetail["yman"]);
            MetaData.SetDefault(DS.mandatedetail, "nman", rMandateDetail["nman"]);
            DataRow NewManDet = MetaManDet.Get_New_Row(null, DS.mandatedetail);

            foreach (string field in new string[] {
                //"rownum", "npackage","tax","unabatable","taxable",
                "detaildescription", "number", "flagmixed", "idivakind", "taxrate",
                "idexp_taxable", "idexp_iva", "annotations",
                "ivanotes", "discount", "flagactivity", "idupb", "cupcode", "cigcode",
                "idinv", "assetkind", "toinvoice", "idsor1", "idsor2", "idsor3", "idcostpartition", "competencystart",
                "competencystop",
                "idaccmotive", "idreg", "va3type", "idlist", "idunit", "idpackage", "unitsforpackage", "flagto_unload",
                "epkind","idsor_siope"
            }) {
                NewManDet[field] = rMandateDetail[field];
            }
            int max_idgroup_db =
                CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("mandatedetail",
                    QHS.MCmp(NewManDet, "idmankind", "yman", "nman"),
                    "max(idgroup)"));
            int idgroup = CfgFn.GetNoNullInt32(NewManDet["idgroup"]);
            if (idgroup <= max_idgroup_db) {
                idgroup = max_idgroup_db + 1;
                NewManDet["idgroup"] = idgroup;
            }
            NewManDet["start"] = dataAnnullamento;
            NewManDet["npackage"] = DettOrdinedaCreare.npackage;
            NewManDet["number"] = DettOrdinedaCreare.number;
            NewManDet["taxable"] = DettOrdinedaCreare.taxable;
            NewManDet["unabatable"] = DettOrdinedaCreare.unabatable;
            NewManDet["tax"] = DettOrdinedaCreare.iva;

            return NewManDet;
        }




        private void AzzeraCreaDettaglioOrdine(newDettMandate NuovoDettOrdine, DataRow rInvoiceDetail,
            object dataAnnullamento) {
            string filterManDet = QHC.AppAnd(QHC.CmpEq("idmankind", rInvoiceDetail["idmankind"]),
                QHC.CmpEq("yman", rInvoiceDetail["yman"]),
                QHC.CmpEq("nman", rInvoiceDetail["nman"]),
                QHC.CmpEq("rownum", rInvoiceDetail["manrownum"]));

            // Per il dett. ordine e per ogni fratello splittato, deve:
            //1) Impostare la Data annullamento
            //2) Creare il nuovo dettaglio
            //3) Creare la var. in spesa
            foreach (DataRow rDettaglio in DS.mandatedetail.Select(filterManDet)) {
                rDettaglio["stop"] = dataAnnullamento;
                DataRow newDRDettOrdine = CreaNuovodettaglio(NuovoDettOrdine, rDettaglio, dataAnnullamento);
                generaVariazione(NuovoDettOrdine, rDettaglio, rInvoiceDetail);

                //Scambia i valori di origine e destinazione
                foreach (DataColumn c in DS.mandatedetail.Columns) {
                    string field = c.ColumnName;
                    if (QueryCreator.IsPrimaryKey(DS.mandatedetail, field))
                        continue; //non scambia la chiave
                    //if (field=="lt"||field=="lu") continue; //non scambia lt lu??

                    if (field == "idgroup")
                        continue;
                    object o = rDettaglio[field];
                    rDettaglio[field] = newDRDettOrdine[field];
                    newDRDettOrdine[field] = o;
                }
            }


            foreach (DataRow NewVar in DS.expensevar.Select()) {
                if (CfgFn.GetNoNullDecimal(NewVar["amount"]) == 0)
                    NewVar.Delete();
            }

            if (DS.expensevar.Select().Length > 0) {
                if (show("E' stata impostata la data di annullamento di alcuni dettagli contabilizzati. " +
                                    "Si desidera creare delle variazioni sui " +
                                    "corrispondenti movimenti di spesa?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                    DS.expensevar.Clear();
                    return;
                }
            }

            string filter = QHS.AppAnd(QHS.FieldIn("idexp", DS.expensevar.Select()),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.expensesorted,
                null, filter, null, true);

            Form mv = new FrmManage_Var(DS, Meta.Conn, Meta.Dispatcher, "E");
            DialogResult dr = mv.ShowDialog();
            if (dr != DialogResult.OK) {
                DS.expensevar.Clear();
                DS.expensesorted.Clear();
                return;
            }

            MetaData MetaExpensevar = Meta.Dispatcher.Get("expensevar");
            PostData EV = MetaExpensevar.Get_PostData();

            EV.InitClass(DS, Meta.Conn);
            bool res = EV.DO_POST();
            if (!res) {
                show("Salvataggio annullato.", "Avviso");
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterInvoice"></param>
        /// <param name="idgroupMan"></param>
        /// <returns></returns>
        private DataRow Fatturato(string filterInvoiceDetail) {
            string queryFatturato =
                "select SUM(taxable_euro) as taxable_euro,SUM(iva_euro) as iva_euro,SUM(unabatable_euro) as unabatable_euro, " +
                " sum(taxable) as taxable "
                + " from invoicedetailview  where "
                + filterInvoiceDetail;

            DataTable tFatturato = Conn.SQLRunner(queryFatturato);
            if ((tFatturato == null) || (tFatturato.Rows.Count == 0))
                return null;
            return tFatturato.Rows[0];
        }

        private DataRow Ordinato(string filterManDet) {
            string queryOrdinato = "select taxable , tax, unabatable, ordered, unitsforpackage,discount, idmankind, yman, nman, rownum, exchangerate, invoiced"
                                   + " from mandatedetailtoinvoice "
                                   + " where " + QHS.AppAnd(QHS.IsNull("stop"), filterManDet);
            DataTable tOrdinato = Conn.SQLRunner(queryOrdinato);
            if ((tOrdinato == null) || (tOrdinato.Rows.Count == 0))
                return null;
            return tOrdinato.Rows[0];
        }

        /// <summary>
        /// Calcola una riga contenente
        /// </summary>
        /// <param name="rInvoiceDetail"></param>
        /// <param name="filterManDet"></param>
        /// <returns></returns>
        private newDettMandate CalcolaNuovoDettaglioOrdine(DataRow rInvoiceDetail, string filterManDet) {
            string filterInvoiceDetail = QHS.AppAnd(QHS.CmpEq("idmankind", rInvoiceDetail["idmankind"]),
                QHS.CmpEq("yman", rInvoiceDetail["yman"]),
                QHS.CmpEq("nman", rInvoiceDetail["nman"]),
                QHS.CmpEq("manrownum", rInvoiceDetail["manrownum"]));

            DataRow rFatturato = Fatturato(filterInvoiceDetail);
            if (rFatturato == null)
                return null;
            DataRow rOrdinato = Ordinato(filterManDet);
            if (rOrdinato == null) {
                show("Il dettaglio ordine n." + rInvoiceDetail["manrownum"].ToString() +
                                " associato alla fattura ha già data di annullamento e non sarà oggetto di ulteriori modifiche.");
                return null;
            }
            // Controlla che ci sia ancora un residuo da Fatturare.
            //CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("mandatedetailview", filterManDet, "exchangerate"));
            decimal taxable_euroFatt = CfgFn.GetNoNullDecimal(rFatturato["taxable_euro"]);
            decimal iva_euroFatt = CfgFn.GetNoNullDecimal(rFatturato["iva_euro"]);
            decimal Tot_Fatturato = taxable_euroFatt + iva_euroFatt;

            decimal tassocambioOrd = CfgFn.GetNoNullDecimal(rOrdinato["exchangerate"]);
            if (tassocambioOrd == 0)
                tassocambioOrd = 1;
            decimal imponibileOrd = CfgFn.GetNoNullDecimal(rOrdinato["taxable"]);
            decimal quantitaOrd = CfgFn.GetNoNullDecimal(rOrdinato["ordered"]);
            decimal scontoOrd = CfgFn.Round(CfgFn.GetNoNullDecimal(rOrdinato["discount"]), 6);
            decimal taxable_euroOrd = CfgFn.RoundValuta((imponibileOrd*quantitaOrd*(1 - scontoOrd))*tassocambioOrd);
            decimal impostaOrd = CfgFn.GetNoNullDecimal(rOrdinato["tax"]);
            decimal iva_euroOrd = CfgFn.RoundValuta(impostaOrd);
            decimal Tot_Ordinato = taxable_euroOrd + iva_euroOrd;

            if (taxable_euroFatt == taxable_euroOrd || iva_euroFatt == iva_euroOrd)
                return null;

            decimal ordered = CfgFn.GetNoNullDecimal(rOrdinato["ordered"]);

            decimal invoiced = CfgFn.GetNoNullDecimal(rOrdinato["invoiced"]);

            decimal taxable = CfgFn.RoundValuta(taxable_euroFatt/(invoiced*(1 - scontoOrd)*tassocambioOrd));
            newDettMandate nmd = new newDettMandate();
            nmd.npackage = invoiced;
            decimal unitsforpackage = CfgFn.GetNoNullDecimal(rOrdinato["unitsforpackage"]) == 0
                ? 1
                : CfgFn.GetNoNullDecimal(rOrdinato["unitsforpackage"]);
            nmd.number = invoiced*unitsforpackage;
            nmd.iva = iva_euroFatt;
            nmd.taxable = taxable;
            nmd.tot_imponibile = taxable_euroFatt;
            nmd.unabatable = CfgFn.GetNoNullDecimal(rFatturato["unabatable_euro"]);
            nmd.exchangerate = tassocambioOrd;
            return nmd;
        }

        private class newDettMandate {
            public decimal npackage = 0;
            public decimal taxable = 0;
            public decimal iva;
            public decimal unabatable = 0;
            public decimal exchangerate = 0;
            public decimal number = 0;
            public decimal tot_imponibile = 0;

        }

        private void generaVariazione(newDettMandate NuovoDettOrdine, DataRow rDettaglio,
            DataRow rInvoiceDetail) {
            string filterManDet = QHC.AppAnd(QHC.CmpEq("idmankind", rDettaglio["idmankind"]),
                QHC.CmpEq("yman", rDettaglio["yman"]),
                QHC.CmpEq("nman", rDettaglio["nman"]),
                QHC.CmpEq("rownum", rDettaglio["rownum"]));



            // vedo se esiste una variazione su quell'idexp_taxable, se non c'è la crea
            if (rDettaglio["idexp_taxable"] != DBNull.Value) {
                string filterVar = QHC.CmpEq("idexp", rDettaglio["idexp_taxable"]);
                DataRow[] ArrVarEsistente = DS.expensevar.Select(filterVar);
                DataRow CurrVar;
                //Vede se esiste già la variazione
                if (ArrVarEsistente.Length > 0) {
                    CurrVar = ArrVarEsistente[0];
                }
                else {
                    MetaData MetaVar = Meta.Dispatcher.Get("expensevar");
                    MetaVar.SetDefaults(DS.expensevar);
                    CurrVar = MetaVar.Get_New_Row(null, DS.expensevar);
                    CurrVar["idexp"] = rDettaglio["idexp_taxable"];
                    CurrVar["description"] = "Annullamento o sostituzione dett. contratto passivo " +
                                             rDettaglio["idmankind"].ToString() + "/" +
                                             rDettaglio["yman"].ToString() + "/" +
                                             rDettaglio["nman"].ToString();
                }
                // Leggo i dati relativi per determinare il taxable_euro Fatturato e Ordinato.
                decimal tassocambio = NuovoDettOrdine.exchangerate;
                //il tasso cambio del vecchio è uguale a quello del nuovo
                if (tassocambio == 0)
                    tassocambio = 1;
                decimal imponibileOrd = CfgFn.GetNoNullDecimal(rDettaglio["taxable"]);
                decimal quantitaOrd = CfgFn.GetNoNullDecimal(rDettaglio["npackage"]);
                decimal scontoOrd = CfgFn.Round(CfgFn.GetNoNullDecimal(rDettaglio["discount"]), 6);
                decimal taxable_euroFatt = NuovoDettOrdine.tot_imponibile;
                decimal taxable_euroOrd = CfgFn.RoundValuta((imponibileOrd*quantitaOrd*(1 - scontoOrd))*tassocambio);
                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) -
                                    (taxable_euroOrd - taxable_euroFatt);
            }

            //vedo se esiste una variazione su quell'idexp_iva, se non c'è la crea
            if (rDettaglio["idexp_iva"] != DBNull.Value) {
                string filterVar = QHC.CmpEq("idexp", rDettaglio["idexp_iva"]);
                DataRow[] ArrVarEsistente = DS.expensevar.Select(filterVar);
                DataRow CurrVar;
                //Vede se esiste già la variazione
                if (ArrVarEsistente.Length > 0) {
                    CurrVar = ArrVarEsistente[0];
                }
                else {
                    MetaData MetaVar = Meta.Dispatcher.Get("expensevar");
                    MetaVar.SetDefaults(DS.expensevar);
                    CurrVar = MetaVar.Get_New_Row(null, DS.expensevar);
                    CurrVar["idexp"] = rDettaglio["idexp_iva"];
                    CurrVar["description"] = "Annullamento o sostituzione dett. contratto passivo " +
                                             rDettaglio["idmankind"].ToString() + "/" +
                                             rDettaglio["yman"].ToString() + "/" +
                                             rDettaglio["nman"].ToString();
                }
                // Leggo i dati relativi per determinare l'iva
                decimal impostaFatt = CfgFn.GetNoNullDecimal(NuovoDettOrdine.iva);
                decimal impostaOrd = CfgFn.GetNoNullDecimal(rDettaglio["tax"]);
                decimal iva_euroFatt = CfgFn.RoundValuta(impostaFatt);
                decimal iva_euroOrd = CfgFn.RoundValuta(impostaOrd);
                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) - (iva_euroOrd - iva_euroFatt);
            }
        }

       public void MetaData_AfterPost() {
            VisualizzaBtnAutoFattura();
            EPM.afterPost();
            //GeneraScritture();
            //if (fromDelete) {
            //    cancellaScritture();
            //    idrelated = "";
            //    fromDelete = false;
            //}

            if (DS.invoicedetail.Rows.Count > 0) {
                StockSendMail SM = new StockSendMail(Conn);
                foreach (DataRow ID in DS.invoicedetail.Select())
                    SM.getItemsFromInvoice(ID);
                SM.SendMailToBookers();
            }

            // Variazioni sulle contabilizzazioni dei dettagli annullati nell'anno corrente
            DS.expensevar.Clear();
            DS.mandatedetail.Clear();

            string filterInvDet = QHC.CmpEq("resetresidualmandate", "S");
            foreach (DataRow rInvoicedetail in DS.invoicedetail.Select(filterInvDet)) {
                string filterManDet = QHS.AppAnd(QHS.CmpEq("idmankind", rInvoicedetail["idmankind"]),
                    QHS.CmpEq("yman", rInvoicedetail["yman"]),
                    QHS.CmpEq("nman", rInvoicedetail["nman"]),
                    QHS.CmpEq("rownum", rInvoicedetail["manrownum"]));

                newDettMandate NuovoDettOrdine = CalcolaNuovoDettaglioOrdine(rInvoicedetail, filterManDet);

                if (NuovoDettOrdine == null)
                    continue;
                object dataAnnullamento = RichiediData(rInvoicedetail);
                if (dataAnnullamento == null)
                    continue; //Se non è stata inserita la data annullamento, quel dettaglio sarà saltato.

                // Annullamento del dettaglio ordine associato al dett. fattura 	           
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.mandatedetail, null, filterManDet, null, true);
                AzzeraCreaDettaglioOrdine(NuovoDettOrdine, rInvoicedetail, dataAnnullamento);
            }

            VisualizzaNumeroRegistroUnico();

            //Eseguito solo in presenza di legame con FE 
            if (!DS.HasChanges()) {
                sendBroadcast_toSDI_acquisto();
            }
        }


        private void sendBroadcast_toSDI_acquisto() {
            if (DS.invoice.Rows.Count == 0) {
                return;
            }
            DataRow rInvoice = DS.invoice.Rows[0];
            if ((rInvoice["idsdi_acquisto"] != DBNull.Value) || (rInvoice["idsdi_acquisto"] != null)) {
                MetaData.sendBroadcast(this, "AggiornareCampiFE");
            }
        }







        private void btnCreaDaContratto_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataRow Curr = DS.invoice.Rows[0];
            if (CfgFn.GetNoNullInt32(Curr["idreg"]) <= 0) {
                show("Scegliere prima il fornitore");
                return;
            }
            string filter = QHS.AppAnd(QHS.CmpEq("idreg", Curr["idreg"]),
                QHS.CmpEq("flaginvoiced", 'N'), QHS.IsNull("idinvkind"));
            skipAfterFill = true;
            MetaData.DoMainCommand(this, "choose.profservice.default." + filter);
            skipAfterFill = false;
        }


        private decimal getValuta(object o) {
            return CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(o));
        }

        private decimal getAliquota(object o) {
            return CfgFn.Round(CfgFn.GetNoNullDecimal(o), 6);
        }

        public string GetFilterIva() {
            int flagactivity = TipoAttivita();
            string filterivakind = "";
            if (flagactivity == 1)
                filterivakind = QHC.BitSet("flag", 0);
            if (flagactivity == 2)
                filterivakind = QHC.BitSet("flag", 1);
            if (flagactivity == 3)
                filterivakind = QHC.BitSet("flag", 2);
            string flagintracom = GetFlagIntracom();
            if (flagintracom == "N")
                filterivakind = QHC.AppAnd(filterivakind, QHC.BitSet("flag", 6));
            if (flagintracom == "S")
                filterivakind = QHC.AppAnd(filterivakind, QHC.BitSet("flag", 7));
            if (flagintracom == "X")
                filterivakind = QHC.AppAnd(filterivakind, QHC.BitSet("flag", 8));
            return filterivakind;
        }


        private void CollegaContratto(DataRow ProfService) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataAccess Conn = Meta.Conn;
            object main_idaccmot = ProfService["idaccmotive"];
            object main_idsor_siope = ProfService["idsor_siope"];
            object main_idupb = ProfService["idupb"];


            if ((EPM.UsaScritture && ProfService["idaccmotive"] == DBNull.Value) ||
                ProfService["idupb"] == DBNull.Value) {
                object idacc = ProfService["idaccmotive"];
                object idupb = ProfService["idupb"];
                string filtroEP = QHS.CmpEq("idepoperation", "fatacq");
                //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
                filtroEP = AddAccMotiveFilter.AddAmmDepFilter(filtroEP, Conn);
                //string filtroEP ="((idepoperation='prestprof')OR(idepoperation='spesaprof'))";
                FrmAskInfo F = new FrmAskInfo(Meta, idacc, idupb, filtroEP, EPM.UsaScritture);
                if (F.ShowDialog(this) != DialogResult.OK) {
                    Meta.unlink(ProfService);
                    return;
                }
                if ((F.selAccmotive.GetValue() != null) && (F.selAccmotive.GetValue() != DBNull.Value)) {
                    if (main_idaccmot != F.selAccmotive.GetValue()) {
                        main_idsor_siope = DBNull.Value;
                    }
                    main_idaccmot = F.selAccmotive.GetValue();
                }
                if ((F.selUPB.GetValue() != null) && (F.selUPB.GetValue() != DBNull.Value))
                    main_idupb = F.selUPB.GetValue();
            }
            DataRow Curr = DS.invoice.Rows[0];
            //Curr["active"] = "N";

            if ((Curr["description"] != DBNull.Value) ||
                (Curr["idaccmotivedebit"] != DBNull.Value) ||
                (Curr["idaccmotivedebit_crg"] != DBNull.Value) ||
                (Curr["idaccmotivedebit_datacrg"] != DBNull.Value)
            ) {
	            if (show(
		                "Si desidera aggiornare descrizione fattura e causali EP prendendole dalla parcella? ",
		                "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {

		            Curr["description"] = ProfService["description"];
		            object idaccmotivedebit = ProfService["idaccmotivedebit"];
		            Curr["idaccmotivedebit"] = idaccmotivedebit;
		            object idaccmotivedebit_crg = ProfService["idaccmotivedebit_crg"];
		            Curr["idaccmotivedebit_crg"] = idaccmotivedebit_crg;
		            Curr["idaccmotivedebit_datacrg"] = ProfService["idaccmotivedebit_datacrg"];
	            }
            }

            string keyfilter = QHS.CmpKey(ProfService);
            DataTable Refund = Conn.RUN_SELECT("profservicerefund", "*", null,
                keyfilter, null, null, true);


            ///////////////////////////////////////////////////////////////
            //Aggiunge la riga relativa alla prestazione (escluse le spese)
            MetaData MetaInvDet = MetaData.GetMetaData(this, "invoicedetail");
            MetaInvDet.SetDefaults(DS.invoicedetail);
            DataRow RinvDet = MetaInvDet.Get_New_Row(Curr, DS.invoicedetail);
            DataRow MainInvDet = RinvDet;
            object idivakind = DBNull.Value;
            DataRow[] Valuta;
            DataRow Val;
            decimal taxrate = CfgFn.GetNoNullDecimal(ProfService["ivarate"]);

            //Calcola un tipo iva adeguato
            if (ProfService["idivakind"] == DBNull.Value) {
                Valuta =
                    DS.ivakind.Select(QHC.AppAnd(QHC.CmpEq("rate", taxrate), QHC.CmpEq("active", 'S'), GetFilterIva()),
                        "unabatabilitypercentage ASC");
                if ((Valuta == null) || (Valuta.Length == 0)) {
                    show("Non è stata trovata un'aliquota per l'iva al " +
                                    taxrate.ToString("n") + "%");
                    Meta.unlink(ProfService);
                    return;
                }
                else {
                    Val = Valuta[0];
                    idivakind = Val["idivakind"];
                }
            }
            else {
                idivakind = ProfService["idivakind"];
                Valuta = DS.ivakind.Select(QHC.CmpEq("idivakind", idivakind));
                if ((Valuta == null) || (Valuta.Length == 0)) {
                    show("Non è stato trovato un tipo IVA corrispondente");
                    Meta.unlink(ProfService);
                    return;
                }
                else {
                    Val = Valuta[0];
                }
            }

            int requested_doc_profservice = CfgFn.GetNoNullInt32(ProfService["requested_doc"]);
            Curr["requested_doc"] = CfgFn.GetNoNullInt32(Curr["requested_doc"]) | requested_doc_profservice;
        
               
            //DataRow Val= Valuta[0];
            RinvDet["detaildescription"] = ProfService["description"];
            RinvDet["discount"] = DBNull.Value;
            RinvDet["tax"] = ProfService["ivaamount"];
            //RinvDet["idivakind"]= Val["idivakind"];
            if (ProfService["idivakind"] == DBNull.Value) {
                RinvDet["idivakind"] = idivakind;
            }
            else {
                RinvDet["idivakind"] = ProfService["idivakind"];
            }
        
            RinvDet["ycon"] = ProfService["ycon"];
            RinvDet["ncon"] = ProfService["ncon"];
           
            RinvDet["number"] = 1;
            RinvDet["npackage"] = 1;
            RinvDet["competencystart"] = ProfService["start"];
            RinvDet["competencystop"] = ProfService["stop"];
            foreach (string colname in
                new string[] {"idsor1", "idsor2", "idsor3"}) {
                RinvDet[colname] = ProfService[colname];
            }
            RinvDet["idupb"] = main_idupb;
            RinvDet["idaccmotive"] = main_idaccmot;
            RinvDet["idsor_siope"] = main_idsor_siope;
            // Valorizza l'impegno di budget prendendo quello del Contratto
            RinvDet["idepexp"] = CalcolaIdEpExp(ProfService, null);

            //Legge la configurazione dei tipi spesa
            DataTable ProfRefundYear = Conn.RUN_SELECT("profrefund", "*", null, null, null, true);

            decimal spese_impprev = 0;
            foreach (DataRow QP in Refund.Select()) {
                //Sceglie la causale del tipo spesa se presente
                string filterQRef = QHC.CmpEq("idlinkedrefund", QP["idlinkedrefund"]);
                DataRow[] QRefKind = ProfRefundYear.Select(filterQRef);
                if (QRefKind.Length > 0) {
                    if (QRefKind[0]["flagsecuritydeduction"].ToString().ToUpper() != "S")
                        spese_impprev += CfgFn.GetNoNullDecimal(QP["amount"]);
                }
            }
            /*A*/
            decimal importoPrestazione = getValuta(ProfService["feegross"]);
            /*b%*/
            decimal percB = getAliquota(ProfService["pensioncontributionrate"]);
            /*c%*/
            decimal percC = getAliquota(ProfService["socialsecurityrate"]);
            //errore: non stava prendendo anche le spese imponibili previdenzialmente
            /*B*/
            decimal valoreB = CfgFn.RoundValuta((importoPrestazione + spese_impprev)*percB);
            /*C*/
            decimal valoreC = CfgFn.RoundValuta((valoreB + importoPrestazione + spese_impprev)*percC);
            /*D*/
            decimal imponibileIVA = importoPrestazione + valoreB + valoreC;
            RinvDet["taxable"] = imponibileIVA;
            string filterCont = QHS.CmpKey(ProfService);
            object CigCode = DBNull.Value;

            DataTable TProfServiceCig = Conn.RUN_SELECT("profservicecig", "*", null, filterCont, null, true);
            if ((TProfServiceCig != null) && (TProfServiceCig.Rows.Count > 0)) {
                    MetaData MetaProfServiceCig = Meta.Dispatcher.Get("profservicecig");
                    DataRow MyDRCig = MetaProfServiceCig.SelectOne("default", filterCont, null, null);
                    if (MyDRCig != null) {
                        CigCode = MyDRCig["cigcode"];
                    }
                
            }



            ///////////////////////////////////////////////////////////////////
            //Aggiunge le righe relative alle spese
            decimal sumtax = 0;
            foreach (DataRow Ref in Refund.Select()) {
                object idacc = main_idaccmot;
                //Sceglie la causale del tipo spesa se presente
                string filterRef = QHC.CmpEq("idlinkedrefund", Ref["idlinkedrefund"]);

                object description = Conn.DO_READ_VALUE("profrefund", QHS.CmpEq("idlinkedrefund", Ref["idlinkedrefund"]),
                    "description");
                object flagivadeduction = Conn.DO_READ_VALUE("profrefund",
                    QHS.CmpEq("idlinkedrefund", Ref["idlinkedrefund"]),
                    "flagivadeduction");
                bool flagiva = (flagivadeduction.ToString().ToUpper() != "S");
                DataRow[] RefKind = ProfRefundYear.Select(filterRef);
                if (RefKind.Length > 0) {
                    if (RefKind[0]["idaccmotive"] != DBNull.Value) {
                        idacc = RefKind[0]["idaccmotive"];
                    }
                }
                RinvDet = MetaInvDet.Get_New_Row(Curr, DS.invoicedetail);
                RinvDet["detaildescription"] = ProfService["description"];
                RinvDet["discount"] = DBNull.Value;
                RinvDet["tax"] = DBNull.Value;
                RinvDet["cigcode"] = CigCode;
                object selected = DBNull.Value;
                string filterivakind = QHS.AppAnd(QHS.CmpEq("active", 'S'), GetFilterIva());
                if (flagiva)
                    filterivakind = QHS.AppAnd(filterivakind, QHS.CmpEq("rate", taxrate));
                else
                    filterivakind = QHS.AppAnd(filterivakind, QHS.CmpEq("rate", 0));
                DataTable IvaKind = Conn.RUN_SELECT("ivakind", "*", null, filterivakind, null, null, true);

                if (IvaKind.Rows.Count == 0) {
                    show("Non è stata trovata un'aliquota per l'iva al " +
                                    taxrate.ToString("n") + "%");
                    Meta.unlink(ProfService);
                    return;
                }
                else {
                    FrmAskInfoIva F = new FrmAskInfoIva(IvaKind, Ref["amount"], description);
                    if (F.ShowDialog() != DialogResult.OK) return;
                    selected = F.cmbIvakind.SelectedValue;
                }

                RinvDet["ycon"] = ProfService["ycon"];
                RinvDet["ncon"] = ProfService["ncon"];
                DataRow[] found = IvaKind.Select(QHC.CmpEq("idivakind", selected));
                if (found.Length == 0) return;
                DataRow RInvKind = found[0];
                double aliquota = CfgFn.GetNoNullDouble(RInvKind["rate"]);
                double percindeduc = CfgFn.GetNoNullDouble(RInvKind["unabatabilitypercentage"]);

                double imponibiletotEur = CfgFn.GetNoNullDouble(Ref["amount"]);
                double ivaEUR = CfgFn.RoundValuta(imponibiletotEur*aliquota);
                //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
                double impindeducEUR = CfgFn.RoundValuta(ivaEUR*percindeduc);


                RinvDet["idivakind"] = selected;
                RinvDet["number"] = 1;
                RinvDet["npackage"] = 1;
                RinvDet["competencystart"] = ProfService["start"];
                RinvDet["competencystop"] = ProfService["stop"];
                foreach (string colname in
                    new string[] {"idsor1", "idsor2", "idsor3"}) {
                    RinvDet[colname] = ProfService[colname];
                }
                RinvDet["idupb"] = main_idupb;
                RinvDet["idaccmotive"] = idacc;
                RinvDet["taxable"] = imponibiletotEur;
                RinvDet["unabatable"] = impindeducEUR;
                RinvDet["tax"] = ivaEUR;
                // Valorizza l'impegno di budget prendendo quello del Contratto
                RinvDet["idepexp"] = CalcolaIdEpExp(ProfService, Ref);
                sumtax += Convert.ToDecimal(ivaEUR);

              

            }

            double ivaTOT = CfgFn.GetNoNullDouble(ProfService["ivaamount"]) - Convert.ToDouble(sumtax);
            double percindeducmain = CfgFn.GetNoNullDouble(Val["unabatabilitypercentage"]);
            double impindeducmain = CfgFn.RoundValuta(ivaTOT*percindeducmain);
            MainInvDet["unabatable"] = impindeducmain;
            MainInvDet["cigcode"] = CigCode;
            MainInvDet["tax"] = Convert.ToDecimal(ivaTOT);

            Meta.myGetData.GetTemporaryValues(DS.invoicedetail);
            Meta.FreshForm(false);
        }

        public object CalcolaIdEpExp(DataRow rProfService, DataRow rProfRefund) {
            int nphase = 2; // Impegno
            string Filterbase = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));

            object idEpExpRefund = DBNull.Value;
            if (rProfRefund != null) {
                string idrelatedSpesa = BudgetFunction.GetIdForDocument(rProfRefund);
                string filterProfRefund = QHS.AppAnd(Filterbase, QHS.CmpEq("idrelated", idrelatedSpesa));
                DataTable EpExpRefund = Meta.Conn.RUN_SELECT("epexpview", "idepexp", null, filterProfRefund, null, true);
                if (EpExpRefund != null && EpExpRefund.Rows.Count > 0) {
                    idEpExpRefund = EpExpRefund.Rows[0]["idepexp"];
                }
                if (idEpExpRefund != DBNull.Value)
                    return idEpExpRefund;
            }

            object idEpExpService = DBNull.Value;
            string idrelatedContratto = BudgetFunction.GetIdForDocument(rProfService);
            string filterProfService = QHS.AppAnd(Filterbase, QHS.CmpEq("idrelated", idrelatedContratto));
            DataTable EpExpProfService = Meta.Conn.RUN_SELECT("epexpview", "idepexp", null, filterProfService, null,
                true);
            if (EpExpProfService != null && EpExpProfService.Rows.Count > 0) {
                idEpExpService = EpExpProfService.Rows[0]["idepexp"];
            }
            return idEpExpService;

        }

        //public object CalcolaIdEpExp(DataRow rProfService) {
        //    object idEpExp = DBNull.Value;
        //    string idrelated = BudgetFunction.GetIdForDocument(rProfService);
        //    //idrelated = idrelated + "%";
        //    string filterProfService = QHS.CmpEq("idrelated", idrelated);//string filterProfService = QHS.Like("idrelated", idrelated);
        //    DataTable Epexp = Meta.Conn.RUN_SELECT("epexp", "idepexp", null, filterProfService, null, true);
        //    string listaImpegniBudgetProfservice = QHS.DistinctVal(Epexp.Select(), "idepexp");

        //    string filterIx = QHS.FieldInList("idepexp", listaImpegniBudgetProfservice);
        //    int nphase = 2; // Impegno
        //    string Filterbase = QHS.AppAnd(QHS.CmpEq("yepexp", Meta.GetSys("esercizio")), QHS.CmpEq("nphase", nphase));
        //    filterIx = QHS.AppAnd(Filterbase, filterIx);
        //    DataTable EpExp = Meta.Conn.RUN_SELECT("epexp", "idepexp", null, filterIx, null, true);
        //    if (EpExp != null && EpExp.Rows.Count > 0) {
        //        idEpExp = EpExp.Rows[0]["idepexp"];
        //        return idEpExp;
        //    }
        //    return idEpExp;
        //}
        private void btnAggiungiDaContratti_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataRow R = DS.invoice.Rows[0];
            if (R["idreg"] == DBNull.Value) {
                show("Selezionare prima il cliente.");
                return;
            }
            object idreg = R["idreg"];
            string regfilter = QHS.CmpEq("idreg", idreg);
            object idinvkind = R["idinvkind"];
            string idinvkindfilter = QHS.CmpEq("idinvkind", idinvkind);
            string idinvkindfilter_C = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] TipoFattura = DS.invoicekind.Select(idinvkindfilter_C);
            DataTable T = DS.invoicedetail;
            object idcurrency = R["idcurrency"];

            FrmWizardScegliDettagliContratto F = new FrmWizardScegliDettagliContratto(Meta, regfilter, idcurrency, T);
            if (F.ShowDialog(this) != DialogResult.OK)
                return;
            DataRow[] Selected = F.SelectedRows;
            if (Selected == null)
                return;
            if (Selected.Length == 0)
                return;
            //Aggiornamento causali EP
            DataRow rSelected = Selected[0];
            string filterEstimate = QHS.AppAnd(QHS.CmpEq("idestimkind", rSelected["idestimkind"]),
                                  QHS.CmpEq("yestim", rSelected["yestim"]),
                                  QHS.CmpEq("nestim", rSelected["nestim"]));

            DataTable Estimate = Conn.RUN_SELECT("estimate", "*", null, filterEstimate, null, false);
            if ((Estimate != null) && (Estimate.Rows.Count != 0)) {
                DataRow rEstimate = Estimate.Rows[0];
                if ((
                    (rEstimate["idaccmotivecredit"] != DBNull.Value) ||
                    (rEstimate["idaccmotivecredit_crg"] != DBNull.Value) ||
                    (rEstimate["idaccmotivecredit_datacrg"] != DBNull.Value))
                     &&
                    ((R["idaccmotivedebit"] == DBNull.Value) &&
                     (R["idaccmotivedebit_crg"] == DBNull.Value) &&
                     (R["idaccmotivedebit_datacrg"] == DBNull.Value))
                    ) {
                    if (show("Si desidera aggiornare le causali EP prendendole dal contratto attivo? ",
                     "Conferma", MessageBoxButtons.OKCancel) == DialogResult.OK) {
                        object idaccmotivecredit = rEstimate["idaccmotivecredit"];
                        R["idaccmotivedebit"] = idaccmotivecredit;
                        object idaccmotivecredit_crg = rEstimate["idaccmotivecredit_crg"];
                        R["idaccmotivedebit_crg"] = idaccmotivecredit_crg;
                        R["idaccmotivedebit_datacrg"] = rEstimate["idaccmotivecredit_datacrg"];
                    }
                }
            }
            MetaData MI = MetaData.GetMetaData(this, "invoicedetail");
            MI.SetDefaults(DS.invoicedetail);
            foreach (DataRow Curr in Selected) {
                object idivakind = DBNull.Value;
                DataRow InvDet = MI.Get_New_Row(R, DS.invoicedetail);
                foreach (string colname in
                    new string[] {
                        "idestimkind", "detaildescription",
                        "yestim", "nestim", "taxable", "tax", "discount", "idupb", "idupb_iva", "cigcode",
                        "idsor1", "idsor2", "idsor3", "idaccmotive", "competencystart", "competencystop", "idepacc",
                        "idlist","idfinmotive","idfinmotive_iva","iduniqueformcode", "idsor_siope", "idtassonomia", "cupcode"
                    }) {
                    InvDet[colname] = Curr[colname];
                }
                InvDet["estimrownum"] = Curr["rownum"];
                InvDet["number"] = Curr["residual"];
                InvDet["npackage"] = Curr["residual"];         
                double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
                double quantita = CfgFn.GetNoNullDouble(Curr["residual"]);
                double aliquota = CfgFn.GetNoNullDouble(Curr["taxrate"]);                
                double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
                double imponibileTOT = (imponibile*quantita*(1 - sconto));
                double ivaTOT = CfgFn.GetNoNullDouble(Curr["tax"])*
                                (CfgFn.GetNoNullDouble(Curr["residual"])/CfgFn.GetNoNullDouble(Curr["ordered"]));
                InvDet["tax"] = CfgFn.RoundValuta(ivaTOT);
                double impindeduc = 0;
                InvDet["unabatable"] = CfgFn.RoundValuta(impindeduc);

                if (Curr["idivakind"] == DBNull.Value) {
                    InvDet["idivakind"] = idivakind;
                }
                else {
                    InvDet["idivakind"] = Curr["idivakind"];
                }

                if (aliquota == 0) {
                    string filteridivakind = QHC.CmpEq("idivakind", Curr["idivakind"]);
                    if (DS.ivakind.Select(filteridivakind).Length > 0) {
                        object descr = DS.ivakind.Select(filteridivakind)[0]["description"].ToString();
	                    InvDet["fereferencerule"] = descr;
					}
                }

                AdjustIdGroupEstimate(InvDet);
            }



            Meta.myGetData.GetTemporaryValues(DS.invoicedetail);
            Meta.FreshForm(true);
        }

        private void EnableIntrastat(bool acquisti, bool vendite) {
            gboxIntraInfoBeni.Enabled = acquisti || vendite;
            gboxIntraInfoServizi.Enabled = acquisti || vendite;
            gboxintra_acquisti.Enabled = acquisti;
            gboxintra_vendite.Enabled = vendite;
        }

        /*
        void DisabilitaComboIntrastat () {

            if (cmb_natura.SelectedIndex>0) {
                cmb_natura.SelectedIndex = -1;
            }
            if (cmb_isodestinazione.SelectedIndex>0) {
                cmb_isodestinazione.SelectedIndex = -1;
            }
            if (cmb_isoorigine.SelectedIndex > 0) {
                cmb_isoorigine.SelectedIndex = -1;
            }
            if (cmb_isoprovenienza.SelectedIndex > 0) {
                cmb_isoprovenienza.SelectedIndex = -1;
            }
            if (cmb_provdestinazione.SelectedIndex > 0) {
                cmb_provdestinazione.SelectedIndex = -1;
            }
            if (cmb_provorigine.SelectedIndex > 0) {
                cmb_provorigine.SelectedIndex = -1;
            }

            if ((!MetaData.Empty(this))) {
                DS.invoice.Rows[0]["idintrastatkind"] = DBNull.Value;
                DS.invoice.Rows[0]["iso_origin"] = DBNull.Value;
                DS.invoice.Rows[0]["iso_provenance"] = DBNull.Value;
                DS.invoice.Rows[0]["iso_destination"] = DBNull.Value;
                DS.invoice.Rows[0]["idcountry_origin"] = DBNull.Value;
                DS.invoice.Rows[0]["idcountry_destination"] = DBNull.Value;
            }
        }*/

        private void EnableDisableFEEstera() {
            if (Meta.IsEmpty) {
                cmbDocumentKind.Enabled = true;
                cmbDenominazione.Enabled = true;
                btnInviaSdI.Enabled = false;
                btnCheck.Enabled = true;
                return;
			}
            if (FatturaElettronicaEstera() == "N") {
                cmbDocumentKind.Enabled = false;
                if (cmbDocumentKind.SelectedIndex > 0) {
                    cmbDocumentKind.SelectedIndex = -1;
				}

                cmbDenominazione.Enabled = false;
                if (cmbDenominazione.SelectedIndex > 0) {
                    cmbDenominazione.SelectedIndex = -1;
				}

                btnInviaSdI.Enabled = false;
                btnCheck.Enabled = false;
                grpFEAcquistoEstere.Enabled = false;
            }
            else {
                cmbDocumentKind.Enabled = true;
                cmbDenominazione.Enabled = true;
                grpMittenteVendita.Enabled = !FatturaInviataSdI(); ;
                grpFEAcquistoEstere.Enabled = !FatturaInviataSdI();

                btnInviaSdI.Enabled = !FatturaInviataSdI();
                btnCheck.Enabled = true;
			}
		}

        private void EnableDisableFE() {
            if (Meta.IsEmpty) {
                cmbCondizioniPagFE.Enabled = true;
                cmbModPagFE.Enabled = true;
                return;
            }
            if (tipoRegistroAV().ToUpper() != "V") {
                // se è una fattura di acquisto disabilita i controlli
                cmbCondizioniPagFE.Enabled = false;
                if (cmbCondizioniPagFE.SelectedIndex > 0) {
                    cmbCondizioniPagFE.SelectedIndex = -1;
                }
                DS.invoice.Rows[0]["idfepaymethodcondition"] = DBNull.Value;

                cmbModPagFE.Enabled = false;
                if (cmbModPagFE.SelectedIndex > 0) {
                    cmbModPagFE.SelectedIndex = -1;
                }
                DS.invoice.Rows[0]["idfepaymethod"] = DBNull.Value;
            }
            else {
                cmbCondizioniPagFE.Enabled = true;
                cmbModPagFE.Enabled = true;
            }

        }


        private bool RegistryHasToDeclareIntrastat() {

            DataRow[] TRegistry = DS.registry.Select();
            if (TRegistry.Length == 0)
                return false;
            DataRow Reg = TRegistry[0];
            object p_iva = Reg["p_iva"];
            object idresidence = Reg["residence"];

            object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
                "coderesidence");
            if (Ocoderesidence == null || Ocoderesidence == DBNull.Value)
                return false;
            string coderesidence = Ocoderesidence.ToString().ToUpper();
            // Qualora l'anagrafica sia configurata come:
            //- ente non commerciale;
            //- soggetto residente in altri paesi dell'UE;
            //- non abbia valorizzato la partita IVA;

            //non deve essere richiesta la compilazione dell'INTRASTAT sia:
            //nella fattura
            //nel dettaglio della fattura
            if ((coderesidence == "J") && (p_iva == DBNull.Value) &&
                (CfgFn.GetNoNullInt32(Reg["idregistryclass"]) == 23)) {
                return false;
            }
            // Lettura dell'indirizzo di Tipo RegistryAddress
            String codeaddress = "15_RAPPR_FISCALE";
            object idaddresskind = Meta.Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
            DataTable Address = DataAccess.RUN_SELECT(Meta.Conn, "registryaddress", "*", null,
                QHS.AppAnd(QHS.IsNull("stop"), QHS.NullOrEq("active", "S"), QHS.CmpEq("idreg", Reg["idreg"]),
                    QHS.CmpEq("idaddresskind", idaddresskind)), false);

            if (Address.Rows.Count > 0) {
                return false;
            }

            return true;

        }

        private void DoEnableDisableIntrastat() {
            if (Meta.IsEmpty) {
                EnableIntrastat(true, true);
                return;
            }
            /*
            if (chkIntrastat.Checked == false) {
                DisabilitaComboIntrastat();
            }*/
            DS.invoicedetail.ExtendedProperties["intrastat"] = false;
            if (!rdbintracom.Checked) {
                EnableIntrastat(false, false);
                return;
            }
            bool declare = RegistryHasToDeclareIntrastat();
            if (!declare) {
                EnableIntrastat(false, false);
                return;
            }
            DS.invoicedetail.ExtendedProperties["intrastat"] = true;

            DataRow R;
            if (cboTipo.SelectedIndex <= 0) {
                EnableIntrastat(false, false);
                return;
            }
            DataTable T;
            bool res = Meta.myHelpForm.GetCurrentRow(cboTipo, out T, out R);
            if (!res || R == null) {
                EnableIntrastat(false, false);
                return;
            }
            byte flag = CfgFn.GetNoNullByte(R["flag"]);
            if ((flag & 1) != 0) {
                EnableIntrastat(false, true);
            }
            else {
                EnableIntrastat(true, false);
            }
        }

        private void DoVisibileLabelSoggettiNonResidenti() {
            if (Meta.IsEmpty) {
                lblSoggettiUENonresidenti.Visible = true;
                return;
            }

            DataRow R;
            if (cboTipo.SelectedIndex <= 0) {
                lblSoggettiUENonresidenti.Visible = false;
                return;
            }
            DataTable T;
            bool res = Meta.myHelpForm.GetCurrentRow(cboTipo, out T, out R);
            if (!res || R == null) {
                lblSoggettiUENonresidenti.Visible = false;
                return;
            }

            int flagactivity = TipoAttivita();
            if (flagactivity == 1) {
                lblSoggettiUENonresidenti.Visible = true;
            }
            else {
                lblSoggettiUENonresidenti.Visible = false;
            }

        }

        private void DoEnableDisableComunicazioni() {
            if (Meta.IsEmpty) {
                EnableComunicazioni(false);
                return;
            }
            if ((rdbEffettuare.Checked == true) && (attivitaCommercialeOPromiscua())) {
                EnableComunicazioni(true);
            }
            else {
                EnableComunicazioni(false);
            }
        }

        private void DoEnableDisableInfoSuSpeseSanitarie(object sender) {
            RadioButton rbCorrente = (RadioButton)sender;

            if (rbCorrente.Checked == false) return;
            if ((rdbTicket.Checked == false) && (rdbSpesePrestazioni.Checked == false))
                {
                    chkTicket.Tag = null;
                    chkIntraMoenia.Tag = null;
                    return;
                }

            string tag_chkTicket = "invoice.ssnflagtipospesa:T:N";
            string tag_chkIntraMoenia = "invoice.ssnflagtipospesa:V:N";
            if (rdbTicket.Checked == true) {
                chkTicket.Enabled = true;
                chkTicket.Tag = tag_chkTicket;
            }
            else {
                chkTicket.Checked = false;
                chkTicket.Enabled = false;
                chkTicket.Tag = null;

            }

            if (rdbSpesePrestazioni.Checked == true) {
                chkIntraMoenia.Enabled = true;
                chkIntraMoenia.Tag = tag_chkIntraMoenia;
            }
            else {
                    chkIntraMoenia.Checked = false;
                    chkIntraMoenia.Enabled = false;
                    chkIntraMoenia.Tag = null;
            }


        }


        private void EnableComunicazioni(bool enable) {
            DS.invoicedetail.ExtendedProperties["comunicazioni"] = enable;
        }

        private void chkIntrastat_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            DoEnableDisableIntrastat();
        }

        private void btnContabilizzazioni_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            DataRow Curr = DS.invoice.Rows[0];
            string filter = QHS.CmpKey(Curr);

            string AoV = tipoMovimentoAV();
            string variationSoN = NotaVariazione();
            string sqlCmd = null;

            if (variationSoN == "N") {
                string tMain = (AoV == "A") ? "expenseinvoiceview" : "incomeinvoiceview";
                string yField = (AoV == "A") ? "ypay" : "ypro";
                string nField = (AoV == "A") ? "npay" : "npro";
                sqlCmd = " SELECT " +
                         " phase as 'Fase.', " +
                         " ymov as 'Eserc. Mov.'," +
                         " nmov as 'Num. Mov.'," +
                         " adate as 'Data Cont.'," +
                         " description as 'Descr.'," +
                         " doc as 'Doc.'," +
                         " docdate as 'Data Doc.'," +
                         " CASE movkind " +
                         " WHEN 1 THEN 'Totale' " +
                         " WHEN 2 THEN 'IVA' " +
                         " WHEN 3 THEN 'Imponibile' " +
                         " END as 'Tipo Contab.', " +
                         " codefin as 'Cod. Bil.'," +
                         " finance as 'Bilancio '," +
                         " codeupb as 'Cod. UPB'," +
                         " upb as 'UPB'," +
                         " registry as 'Anagrafica'," +
                         yField + " as 'Eserc. Mand./Reversale.'," +
                         nField + " as 'Num. Mand./Reversale.'," +
                         " amount as 'Importo'" +
                         " FROM " + tMain +
                         " WHERE " + filter +
                         " ORDER BY ymov, nmov ";
            }
            else {
                string tMain = (AoV == "A") ? "expensevarview" : "incomevarview";

                sqlCmd = " SELECT " +
                         " yvar as 'Eserc. Var.'," +
                         " nvar as 'Num. Var.'," +
                         " phase as 'Fase.', " +
                         " ymov as 'Eserc. Mov.'," +
                         " nmov as 'Num. Mov.'," +
                         " adate as 'Data Cont.'," +
                         " description as 'Descr.'," +
                         " doc as 'Doc.'," +
                         " docdate as 'Data Doc.'," +
                         " CASE movkind " +
                         " WHEN 1 THEN 'Totale' " +
                         " WHEN 2 THEN 'IVA' " +
                         " WHEN 3 THEN 'Imponibile' " +
                         " END as 'Tipo Contab.', " +
                         " codefin as 'Cod. Bil.'," +
                         " finance as 'Bilancio '," +
                         " codeupb as 'Cod. UPB'," +
                         " upb as 'UPB'," +
                         " amount as 'Importo'" +
                         " FROM " + tMain +
                         " WHERE " + filter +
                         " ORDER BY ymov, nmov ";
            }
            DataTable T = Meta.Conn.SQLRunner(sqlCmd);

            if (T != null) {
                Excel_Click(sender, e, T);
            }
        }

        private void Excel_Click(object sender, EventArgs e, DataTable T) {
            if (T.Rows.Count == 0) {
                show("Nessun elemento trovato");
                return;
            }
            exportclass.DataTableToExcel(T, true);
        }

        private void chkflag_ddt_CheckedChanged(object sender, EventArgs e) {
            if (Meta.DrawStateIsDone)
                EnableDisableDDT();
        }


        private void btnBolletta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);


            DataRow RDoc = DS.invoice.Rows[0];
            if (CfgFn.GetNoNullInt32(RDoc["idreg"]) == 0) {
                show("Selezionare prima il fornitore.");
                return;
            }

            string filter = QHS.CmpEq("idreg", RDoc["idreg"]);
            //sceglie tra i dettagli che hanno ancora del disponibile
            FrmWizardScegliDDT_IN F = new FrmWizardScegliDDT_IN(filter, Meta, DS);

            if (F.ShowDialog(this) != DialogResult.OK)
                return;
            DataRow[] Selected = F.SelectedRows; //Selected sono una o più bollette da fatturare
            if (Selected == null)
                return;
            if (Selected.Length == 0)
                return;

            //Aggiunge tutte le righe delle bollette ancora non aggiunte contemporaneamente collegandole anche agli ordini
            //deve anche impostare/aggiornare gli importi di stock in questo caso
            foreach (DataRow RDDT in Selected) {
                //cicla sulle bollette
                DataTable Stock = Conn.RUN_SELECT("stock", "*", null,
                    QHS.AppAnd(QHS.IsNull("idinvkind"),
                        QHS.CmpEq("idddt_in", RDDT["idddt_in"])
                        )
                    , null, true);
                foreach (DataRow RStock in Stock.Rows) {
                    //cicla sulle righe da collegare
                    DataRow RToLink = GetStockRow(RStock);
                    if (RToLink == null)
                        continue;
                    AddStockRow(RToLink);
                }

            }
            Meta.myGetData.GetTemporaryValues(DS.invoicedetail);
            Meta.FreshForm(false);

        }

        /// <summary>
        /// Aggiunge in invoicedetail una riga prendendo le info da RStock
        /// </summary>
        /// <param name="RStock"></param>
        /// <returns></returns>
        private void AddStockRow(DataRow RStock) {
            Meta.MarkTableAsNotEntityChild(DS.stock);
            if (RStock["idmankind"] == DBNull.Value) {
                AddStockNoMandate(RStock);
                return;
            }
            string fman = QHS.AppAnd(QHS.CmpEq("idmankind", RStock["idmankind"]),
                QHS.CmpEq("yman", RStock["yman"]),
                QHS.CmpEq("nman", RStock["nman"]),
                QHS.CmpEq("idgroup", RStock["man_idgroup"]));
            DataTable DetailsToLink = Conn.RUN_SELECT("mandatedetail", "*", null, fman, null, true);
            foreach (DataRow RDet in DetailsToLink.Rows) {
                DataRow Linked = AddMandateDetailRow(RDet, CfgFn.GetNoNullDecimal(RStock["number"]));
                SetStockRow(RStock, Linked, RDet);
            }
        }




        /// <summary>
        /// Aggiunge una riga in stock restituisce null se c'è già.
        /// Non imposta i campi idinvkind, etc. della riga letta
        /// </summary>
        /// <param name="RStock"></param>
        /// <returns></returns>
        private DataRow GetStockRow(DataRow RStock) {
            string fstock = QHC.CmpEq("idstock", RStock["idstock"]);
            if (DS.stock.Select(fstock).Length > 0) {
                if (DS.stock.Select(fstock)[0]["idinvkind"] == DBNull.Value) {
                    return DS.stock.Select(fstock)[0];
                }
                else {
                    return null; //già collegato
                }
            }
            string dbfilter = QHS.CmpEq("idstock", RStock["idstock"]);
            Conn.RUN_SELECT_INTO_TABLE(DS.stock, null, dbfilter, null, true);
            if (DS.stock.Select(fstock).Length == 0)
                return null; //errore, non c'è la riga (!)
            return DS.stock.Select(fstock)[0];
        }

        /// <summary>
        /// Imposta i campi di RStock (link a fattura e ordine) in base al dettaglio fattura RInvDet
        /// </summary>
        /// <param name="RStock"></param>
        /// <param name="InvDet"></param>
        private void LinkStockRow(DataRow RStock, DataRow RInvDet, DataRow RManDetail) {
            foreach (string f in new string[] {"idinvkind", "yinv", "ninv", "idmankind", "yman", "nman"}) {
                RStock[f] = RInvDet[f];
            }
            if (RManDetail == null) {
                if (RInvDet["idmankind"] != DBNull.Value) {
                    string fmandet = QHS.AppAnd(QHS.MCmp(RStock, "idmankind", "yman", "nman"),
                        QHS.CmpEq("rownum", RInvDet["manrownum"]));
                    object O = Conn.DO_READ_VALUE("mandatedetail", fmandet, "idgroup");
                    if (O != null)
                        RStock["man_idgroup"] = O;
                    O = Conn.DO_READ_VALUE("mandatedetail", fmandet, "flagto_unload");
                    if (O != null)
                        RStock["flagto_unload"] = O;
                }
            }
            else {
                RStock["man_idgroup"] = RManDetail["idgroup"];
                RStock["flagto_unload"] = RManDetail["flagto_unload"];
            }
            RStock["inv_idgroup"] = RInvDet["idgroup"];
        }

        /// <summary>
        /// Imposta tutti i campi di RStock in base a InvDet, ovviamente IDSTORE non è incluso
        /// </summary>
        /// <param name="RStock"></param>
        /// <param name="InvDet"></param>
        private void SetStockRow(DataRow RStock, DataRow RInvDet, DataRow RManDet) {
            LinkStockRow(RStock, RInvDet, RManDet);
            if ((RInvDet["idlist"] != DBNull.Value) && (RStock["expiry"] == DBNull.Value)) {
                DataTable List = Conn.RUN_SELECT("list", "*", null,
                    QHS.AppAnd(QHS.CmpEq("idlist", RInvDet["idlist"]),
                        QHS.CmpEq("has_expiry", "S")), null, true);
                if (List.Rows.Count != 0) {
                    DataRow RList = List.Rows[0];
                    object expiry = GetExpiryForInvoiceDetail(RInvDet, RList);
                    if (expiry != null) {
                        RStock["expiry"] = expiry;
                    }
                }
            }
            //Deve assegnare il campo importo di stock
            decimal costo = GetCostoTotale(RInvDet);
            RStock["amount"] = costo;
            RStock["idlist"] = RInvDet["idlist"];
            RStock["number"] = RInvDet["number"];
            DataRow Curr = DS.invoice.Rows[0];
            RStock["adate"] = Curr["adate"];
        }

        /// <summary>
        /// Aggiunge un dett. fattura a partire da Stock in cui non è presente l'informazione dell'ordine
        /// </summary>
        /// <param name="RStock"></param>
        /// <returns></returns>
        private DataRow AddStockNoMandate(DataRow RStock) {
            DataRow R = DS.invoice.Rows[0];

            MetaData MI = MetaData.GetMetaData(this, "invoicedetail");
            MI.SetDefaults(DS.invoicedetail);

            //Calcola un tipo iva adeguato
            //lo lascia vuoto

            DataTable List = Conn.RUN_SELECT("list", "*", null, QHS.MCmp(RStock, "idlist"), null, true);
            if (List.Rows.Count == 0) {
                show("Articolo non trovato nel listino", "Errore");
                return null;
            }
            DataRow RList = List.Rows[0];
            DataRow InvDet = MI.Get_New_Row(R, DS.invoicedetail);
            //Assegna i campi che può
            InvDet["idlist"] = RList["idlist"];
            InvDet["detaildescription"] = RList["description"];
            InvDet["number"] = RStock["number"];
            InvDet["idunit"] = RList["idunit"];

            int unitsforpackage = 1;
            if (RList["unitsforpackage"] != DBNull.Value)
                unitsforpackage = CfgFn.GetNoNullInt32(RList["unitsforpackage"]);
            decimal npackage = CfgFn.GetNoNullDecimal(RStock["number"])/CfgFn.GetNoNullDecimal(unitsforpackage);

            InvDet["npackage"] = npackage;
            InvDet["unitsforpackage"] = RList["unitsforpackage"];

            foreach (string f in new string[] {"idinvkind", "yinv", "ninv"}) {
                RStock[f] = InvDet[f];
            }
            RStock["inv_idgroup"] = InvDet["idgroup"];

            return InvDet;
        }

        /// <summary>
        /// Ricalcola il campo amount di tutte le righe collegate in stock
        /// </summary>
        private void RicalcolaCostiStock() {
            foreach (DataRow RStock in DS.stock.Select()) {
                string finv = QHC.AppAnd(QHC.CmpEq("idinvkind", RStock["idinvkind"]),
                    QHC.CmpEq("yinv", RStock["yinv"]),
                    QHC.CmpEq("ninv", RStock["ninv"]),
                    QHC.CmpEq("idgroup", RStock["inv_idgroup"]));
                DataRow[] InvDet = DS.invoicedetail.Select(finv);
                if (InvDet.Length == 0)
                    continue;
                decimal costo = GetCostoTotale(InvDet[0]);
                RStock["amount"] = costo;
            }
        }

        /// <summary>
        /// Si accerta che in stock ci siano delle righe coerenti con il contenuto di invoicedetail
        /// In particolare, la riga deve esistere e la quantità deve coincidere con quella di inv.detail
        /// </summary>
        private void AllineaStock() {
            if (Meta.IsEmpty)
                return;
            if (DS.invoice.Rows.Count == 0)
                return;
            bool accompagnatoria = chkflag_ddt.Checked;
            DataRow Curr = DS.invoice.Rows[0];
            DataTable Stock = DS.stock;
            DataTable Details = DS.invoicedetail;

            foreach (DataRow RStock in Stock.Select()) {
                //Se la riga non ha un corrispondente in invoicedetail, la cancella. 
                //Poi saranno le regole ad impedirlo, eventualmente
                string fdets = QHC.AppAnd(QHC.MCmp(RStock, "idinvkind", "yinv", "ninv"),
                    QHC.CmpEq("idgroup", RStock["inv_idgroup"]));
                if (Details.Select(fdets).Length == 0) {
                    if (accompagnatoria) {
                        RStock.Delete();
                    }
                    else {
                        foreach (string field in new string[] {"idinvkind", "yinv", "ninv", "inv_idgroup", "amount"})
                            RStock[field] = DBNull.Value;
                        PostData.RemoveFalseUpdates(DS);
                        if (RStock.RowState == DataRowState.Unchanged) {
                            RStock.Delete();
                            RStock.AcceptChanges();
                        }
                    }
                }
            }

            //Crea, in stock, le righe che ci sono in invoicedetail ma non hanno corrispondenza in stock.
            string fdet = QHC.IsNotNull("idlist");
            foreach (DataRow RDet in Details.Select(fdet)) {
                string fst = QHC.AppAnd(QHC.MCmp(RDet, "idinvkind", "yinv", "ninv"),
                    QHC.CmpEq("inv_idgroup", RDet["idgroup"]));
                if (Stock.Select(fst).Length > 0) {

                    string fst2 = QHC.AppAnd(QHC.MCmp(RDet, "idinvkind", "yinv", "ninv"),
                        QHC.CmpEq("inv_idgroup", RDet["idgroup"]),
                        QHC.CmpEq("number", RDet["number"]));
                    //aggiorna la riga
                    if (Stock.Select(fst2).Length > 0) {
                        SetStockRow(Stock.Select(fst2)[0], RDet, null);
                    }
                    else {
                        SetStockRow(Stock.Select(fst)[0], RDet, null);
                    }
                }
                else {
                    object idlistclass = Conn.DO_READ_VALUE("list", QHS.CmpEq("idlist", RDet["idlist"]), "idlistclass");
                    if (idlistclass !=DBNull.Value && idlistclass != null) {
                        object assetKind= Conn.DO_READ_VALUE("listclass", QHS.CmpEq("idlistclass", idlistclass), "assetkind");
                        if (assetKind!=null && assetKind.ToString().ToUpper() == "M") {
                            //crea la riga in stock
                            DataRow RStock = createStockRowFromInvDetail(RDet);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// RDetail è una riga o un gruppo di righe con pari idgroup, ma devono dar luogo ad 
        ///  un'unica riga di stock
        /// </summary>
        /// <param name="Rdetail"></param>
        /// <returns></returns>
        private DataRow createStockRowFromInvDetail(DataRow Rdetail) {
            DataRow RList = null;

            Meta.MarkTableAsNotEntityChild(DS.stock);
            MetaData MetaStock = MetaData.GetMetaData(this, "stock");
            MetaStock.SetDefaults(DS.stock);
            if (Rdetail["idlist"] != DBNull.Value) {
                DataTable List = Conn.RUN_SELECT("list", "*", null,
                    QHS.CmpEq("idlist", Rdetail["idlist"]), null, true);
                if (List.Rows.Count != 0) {
                    RList = List.Rows[0];
                }
            }
            object idstore = GetIDStoreForInvoiceDetail(Rdetail, RList);
            if (idstore == null || idstore == DBNull.Value)
                return null;
            DataRow RStock = MetaStock.Get_New_Row(null, DS.stock);
            RStock["idstore"] = idstore;
            SetStockRow(RStock, Rdetail, null);
            return RStock;
        }


        private object GetIDStoreForInvoiceDetail(DataRow InvDet, DataRow List) {
            // se c'è un dettaglio ordine associato, prende il magazzino dall'ordine
            if (InvDet["idmankind"] != DBNull.Value) {
                string fMan = QHS.MCmp(InvDet, "idmankind", "yman", "nman");
                object idstore = Conn.DO_READ_VALUE("mandate", fMan, "idstore");
                if (idstore != null)
                    return idstore;
            }
            //Apre un form in cui fa scegliere il magazzino idstore e poi lo restituisce, o null se cancel
            FrmAskInfoStore F = new FrmAskInfoStore(Meta.Dispatcher, InvDet, List);
            if (F.ShowDialog(this) != DialogResult.OK)
                return null;
            return F.idstore;
            ;
        }

        private object GetExpiryForInvoiceDetail(DataRow InvDet, DataRow List) {
            //Apre un form in cui fa scegliere la data scadenza e poi lo restituisce, o null se cancel
            FrmAskInfoExpiry F = new FrmAskInfoExpiry(Meta.Dispatcher, InvDet, List);
            if (F.ShowDialog(this) != DialogResult.OK)
                return null;
            return F.expiry;
            ;
        }

        private Hashtable Habatablerate = new Hashtable();

        private decimal getAbatableRate(object idinvkind, object yinv) {
            string key = idinvkind.ToString() + "@" + yinv.ToString();
            if (Habatablerate[key] != null)
                return CfgFn.GetNoNullDecimal(Habatablerate[key]);
            string filtroTipoFattura = QHS.AppAnd(QHS.CmpEq("idinvkind", idinvkind), QHS.CmpEq("ayear", yinv));

            object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtroTipoFattura, "abatablerate");
            decimal abatableRate = 1;
            if ((OabatableRate != null) && (OabatableRate != DBNull.Value)) {
                abatableRate = CfgFn.GetNoNullDecimal(OabatableRate);
            }
            decimal res = abatableRate;
            Habatablerate[key] = res;
            return res;
        }


        private decimal GetCostoTotale(DataRow rDettIva) {
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }
            tassocambio = RoundDecimal10(tassocambio);

            string fdet = QHC.MCmp(rDettIva, "idinvkind", "yinv", "ninv", "idgroup");
            decimal taxable_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(taxable)", fdet));
            decimal unabatable_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(unabatable)", fdet));
            decimal tax_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(tax)", fdet));
            decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(rDettIva["discount"]));

            decimal npackage = CfgFn.GetNoNullDecimal(rDettIva["npackage"]);
            if (rDettIva["npackage"] == DBNull.Value)
                npackage = CfgFn.GetNoNullDecimal(rDettIva["number"]);
            decimal imponibile = CfgFn.RoundValuta((taxable_sum*npackage*(1 - R_sconto))*tassocambio);

            // Se le quantità sono differenti prende i campi dall'ORDINE
            decimal unabatable = unabatable_sum;
            decimal tax = CfgFn.RoundValuta(tax_sum);
            decimal abatablerate = getAbatableRate(rDettIva["idinvkind"], rDettIva["yinv"]);

            decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((tax - unabatable))*(decimal) abatablerate);
            //ivaDetraibile= CfgFn.RoundValuta(ivaDetraibile/quantitaDettOrdine)*quantitaAssegnata;
            return imponibile + tax - ivaDetraibile;

        }

        private DataRow GetGridSelectedRowInv(DataGrid G) {
            DataSet DSV = (DataSet) G.DataSource;
            if (DSV == null)
                return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null)
                return null;

            if (TV.Rows.Count == 0)
                return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null)
                return null;

            DataRow R = DV.Row;
            return R;
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null)
                return null;
            if (G.DataSource == null)
                return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
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
            if ((Res == null) || (Res.Length == 0)) {
                if (numrighetemp == 1) {
                    // vuol dire che nel Grid c'è solo una riga e non è stata selezionata
                    DataRow[] OneRow = new DataRow[numrighetemp];
                    OneRow[0] = GetGridRow(G, 0);
                    return OneRow;
                }
            }
            return Res;
        }

        private DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet) G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.CmpEq("idstock", G[index, 0]);

            DataRow[] selectresult = MyTable.Select(filter);
            return (selectresult.Length > 0) ? selectresult[0] : null;
        }

        private void btnModificaStock_Click(object sender, EventArgs e) {
            DataRow[] StockViewRows = GetGridSelectedRows(gridStock);
            if ((StockViewRows == null) || (StockViewRows.Length == 0)) {
                show("Selezionare la riga da modificare.");
                return;
            }
            DataRow RStockView = StockViewRows[0];
            FrmModifyInfoStore F = new FrmModifyInfoStore(Meta.Dispatcher, RStockView);
            if (F.ShowDialog(this) != DialogResult.OK)
                return;

            DataRow Rstock = DS.stock.Select(QHC.CmpEq("idstock", RStockView["idstock"]))[0];
            Rstock["idstore"] = F.idstore;
            Rstock["expiry"] = F.expiry;
            Rstock["idstocklocation"] = F.idstocklocation;
            //AllineaStock();
        }

        private void rdbEffettuare_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableComunicazioni();
        }


        private void GetNationInBlackList(object idreg, object adate) {
            if (!attivitaCommercialeOPromiscua()) {
                grpComunicazioneBlackList.Enabled = false;
                rdbNonSpec.Checked = true;
                cmb_BlackList.SelectedIndex = -1;
                txtBlCode.Text = "";
                return;
            }
            if (idreg == DBNull.Value)
                return;
            if (adate == DBNull.Value || adate==null)return;
            string[] param = new string[] {"@idreg", "@dateindi", "@res", "@coderes"};
            SqlDbType[] types = new SqlDbType[] {SqlDbType.Int, SqlDbType.DateTime, SqlDbType.Int, SqlDbType.VarChar};
            int[] typelen = new int[] {4, 0, 4, 3};
            ParameterDirection[] dir = new ParameterDirection[] {
                ParameterDirection.Input, ParameterDirection.Input,
                ParameterDirection.Output, ParameterDirection.Output
            };
            object[] values = new object[4] {idreg, adate, null, null};
            bool res = Conn.CallSPParameter("get_address", param, types, typelen, dir, ref values, true, -1);
            if (!res)
                return;
            object idblacklist = values[2];
            object codeblacklist = values[3];
            if (idblacklist != DBNull.Value) {
                HelpForm.SetComboBoxValue(cmb_BlackList, idblacklist);
                grpComunicazioneBlackList.Enabled = true;
            }
            else {
                grpComunicazioneBlackList.Enabled = false;
                rdbNonSpec.Checked = true;
                cmb_BlackList.SelectedIndex = -1;
            }
            if (codeblacklist != DBNull.Value) {
                txtBlCode.Text = codeblacklist.ToString();
            }
            else {
                txtBlCode.Text = "";
            }
        }

        private void txtDataContabile_Leave(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0)
                return;
            GetNationInBlackList(DS.invoice.Rows[0]["idreg"],
                HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text.ToString(), "x.y"));
            CalcolaDataDocumento();
        }

        private void rdbitalia_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            return;
        }

        private void rdbintracom_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            DoEnableDisableIntrastat();
            DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            return;
        }

        private void rdbextracom_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            return;
        }

        private void Frm_invoice_default_Load(object sender, EventArgs e) {
        }

        public bool SetInvoiceDefault(MetaData ToMeta, DataRow MainObject, object idinvkind_auto) {
            foreach (DataColumn C in DS.invoice.Columns) {
                if ((C.ColumnName == "idinvkind_real") || (C.ColumnName == "yinv_real") || (C.ColumnName == "ninv_real")
                    || (C.ColumnName == "idinvkind") || (C.ColumnName == "yinv") || (C.ColumnName == "ninv")
                    || (C.ColumnName == "autoinvoice") || (C.ColumnName == "description")
                    || (C.ColumnName == "doc")
                    || (C.ColumnName == "iso_origin") || (C.ColumnName == "iso_provenance") ||
                    (C.ColumnName == "idcountry_destination")
                    || (C.ColumnName == "idintrastatkind") || (C.ColumnName == "iso_payment") ||
                    (C.ColumnName == "idintrastatpaymethod")
                    )
                    continue;

                ToMeta.PrimaryDataTable.Columns[C.ColumnName].DefaultValue = MainObject[C.ColumnName];
            }

            ToMeta.PrimaryDataTable.Columns["idinvkind"].DefaultValue = idinvkind_auto;
            ToMeta.PrimaryDataTable.Columns["autoinvoice"].DefaultValue = "S";
            ToMeta.PrimaryDataTable.Columns["active"].DefaultValue = "N";
            ToMeta.PrimaryDataTable.Columns["flag_ddt"].DefaultValue = "N";
            ToMeta.PrimaryDataTable.Columns["idinvkind_real"].DefaultValue = MainObject["idinvkind"];
            ToMeta.PrimaryDataTable.Columns["yinv_real"].DefaultValue = MainObject["yinv"];
            ToMeta.PrimaryDataTable.Columns["ninv_real"].DefaultValue = MainObject["ninv"];
            ToMeta.PrimaryDataTable.Columns["description"].DefaultValue = MainObject["description"].ToString();
            return true;
        }

        private void VisualizzaAutoFattura() {
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Curr = DS.invoice.Rows[0];
            MetaData ToMeta = Meta.Dispatcher.Get("invoice");
            if (ToMeta == null)
                return;
            string checkfilter = QHS.AppAnd(QHS.CmpEq("idinvkind_real", Curr["idinvkind"]),
                QHS.CmpEq("yinv_real", Curr["yinv"]), QHS.CmpEq("ninv_real", Curr["ninv"]));
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

        private void GeneraAutoFattura() {
            if (DS.invoice.Rows.Count == 0)
                return; //It was an insert-cancel
            DataRow Curr = DS.invoice.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) {
                //Should delete the related entries 
                return;
            }

            DataRow R = DS.invoicekind.Select(QHS.CmpEq("idinvkind", Curr["idinvkind"]))[0];
            object idinvkind_auto = R["idinvkind_auto"];


            MetaData ToMeta = Meta.Dispatcher.Get("invoice");
            ToMeta.Edit(Meta.linkedForm.ParentForm, "default", false);

            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in ToMeta.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }

            bool isOk = SetInvoiceDefault(ToMeta, Curr, idinvkind_auto);
            if (!isOk) {
                show(this, "Errore nella assegnazione dei valori di default", "AutoFattura non generata");
                return;
            }

            ToMeta.DoMainCommand("maininsert");
            foreach (DataColumn CC in ToMeta.PrimaryDataTable.Columns) {
                CC.DefaultValue = saveddefaults[CC.ColumnName];
            }

        }

        private void btnAutoFattura_Click(object sender, EventArgs e) {
            // Questo metodo si occupa SOLO di gestire la chiamata a Crea o Visualizza Autofattura.
            // Il metodo VisualizzaBntAutofattura avrà provveduto ad abilitare o mneo questo bottone. Quindi avrà già fatto tutti i controlli del caso.

            DataRow Curr = DS.invoice.Rows[0];
            string filterAutoFattura = QHS.AppAnd(QHS.CmpEq("idinvkind_real", Curr["idinvkind"]),
                QHS.CmpEq("yinv_real", Curr["yinv"]),
                QHS.CmpEq("ninv_real", Curr["ninv"]));

            DataRow R = DS.invoicekind.Select(QHS.CmpEq("idinvkind", Curr["idinvkind"]))[0];
            bool esisteAutoFattura = (Meta.Conn.RUN_SELECT_COUNT("invoice", filterAutoFattura, true) > 0);
            if (esisteAutoFattura) {
                VisualizzaAutoFattura();
            }
            else {
                GeneraAutoFattura();
                //VisualizzaTabPageAutoFattura();// CONTROLLARE!!!!! Non funziona.
            }
        }

        private void AddTab(TabPage Tab, bool redraw) {
            if (tabControl1.TabPages.Contains(Tab))
                return;
            tabControl1.TabPages.Add(Tab);
            if (Meta.IsEmpty) {
                Meta.myHelpForm.ClearControls(Tab.Controls);
            }
            else {
                if (redraw)
                    Meta.myHelpForm.FillControls(Tab.Controls);
            }
        }

        private void AddRemoveTab(TabPage Tab, bool Add, bool redraw) {
            if (Add) {
                AddTab(Tab, redraw);
            }
            else {
                if (tabControl1.TabPages.Contains(Tab)) {
                    tabControl1.TabPages.Remove(Tab);
                }
            }
        }

        private void VisualizzaTabPageAutoFattura() {
            if (DS.invoice.Rows.Count == 0 || DS.config.Rows.Count == 0) {
                AddRemoveTab(tabPageAutofattura, false, false);
                ImpostaCheck(true);
                AbilitaCmbTipoFattura(true);
                return;
            }
            DataRow Curr = DS.invoice.Rows[0];
            // Controlliamo se esiste una Fattura Madre
            string filterFatturaMadre = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind_real"]),
                QHS.CmpEq("yinv", Curr["yinv_real"]),
                QHS.CmpEq("ninv", Curr["ninv_real"]));

            bool esisteFatturaMadre = (Curr["idinvkind_real"] != DBNull.Value);


            if (esisteFatturaMadre) {
                AddRemoveTab(tabPageAutofattura, true, true);
                EnableTabDettagli(false);
                // Riempi il Grid dei dettagli fattura Madre.
                RiempiGridAutofattura(filterFatturaMadre);
                CalcolaImportoAutofattura(filterFatturaMadre);
                ImpostaCheck(false);
            }
            else {
                AddRemoveTab(tabPageAutofattura, false, false);
                EnableTabDettagli(true);
                ImpostaCheck(true);
            }
            if (esisteFatturaMadre) {
                AbilitaCmbTipoFattura(false);
            }
        }

        private void AbilitaCmbTipoFattura(bool abilita) {
            cboTipo.Enabled = abilita;
            btnTipo.Enabled = abilita;
        }

        private void ImpostaCheck(bool abilita) {
            chkflag_ddt.Enabled = abilita;
            chkContabilizzabile.Enabled = abilita;
            chkAutoFattura.Enabled = abilita;
        }

        private void EnableTabDettagli(bool abilita) {
            btnAggiungiDaContratti.Enabled = abilita ; //&& (faseEntrataMax>1);
            btnAggiungiDaOrdini.Enabled = abilita;  // && (faseSpesaMax>1);
            btnBolletta.Enabled = abilita;
            btnCreaDaContratto.Enabled = abilita;
            btnContabilizzazioni.Enabled = abilita;
            buttonInsert.Enabled = abilita;
            buttonEdit.Enabled = abilita;
            buttonDetele.Enabled = abilita;
        }

        private void RiempiGridAutofattura(string filterFatturaMadre) {
            string queryDettagliFatturaMadre = "select ivakind as 'Tipo IVA',"
                                               + " detaildescription as 'Descrizione', "
                                               + " rate as 'Aliquota', "
                                               + " unabatabilitypercentage as '% Indetr.', "
                                               + " taxable as 'Importo Unitario', "
                                               + " number as 'Quantità', "
                                               + " tax as 'Imposta', "
                                               + " unabatable as 'Indetraibile', "
                                               + " discount as 'Sconto', "
                                               + " competencystart as 'Inizio comp.', "
                                               + " competencystop as 'Fine comp.' "
                                               + " from invoicedetailview "
                                               + " where " +
                                               filterFatturaMadre;
            DataTable tInvoicedetail = Meta.Conn.SQLRunner(queryDettagliFatturaMadre);

            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Aliquota"], "p");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["% Indetr."], "p");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Importo Unitario"], "n");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Quantità"], "n");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Imposta"], "n");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Indetraibile"], "n");
            HelpForm.SetFormatForColumn(tInvoicedetail.Columns["Sconto"], "p");


            tInvoicedetail.TableName = "tInvoicedetail";
            new DataSet().Tables.Add(tInvoicedetail);
            dgDettagliFattura.DataSource = null;
            HelpForm.SetDataGrid(dgDettagliFattura, tInvoicedetail);
        }

        private void CalcolaImportoAutofattura(string filterFatturaMadre) {
            // Calcoliamo gli importi totali
            decimal imponibile = 0;
            decimal imposta = 0;
            decimal indetraibile = 0;
            decimal totale = 0;
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }
            tassocambio = RoundDecimal10(tassocambio);
            DataTable tInvoicedetail = Conn.RUN_SELECT("invoicedetail", "*", null,
                filterFatturaMadre, null, null, true);

            foreach (DataRow R in tInvoicedetail.Rows) {
                //if (R.RowState == DataRowState.Deleted) continue;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(R["npackage"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                imponibile += CfgFn.RoundValuta((R_imponibile*R_quantita*(1 - R_sconto))*tassocambio);
                imposta += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"]));
                indetraibile += CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["unabatable"]));
            }
            totale = imponibile + imposta;
            decimal imponibileEUR = CfgFn.RoundValuta(imponibile);
            decimal impostaEUR = CfgFn.RoundValuta(imposta);
            decimal totaleEUR = CfgFn.RoundValuta(totale);
            decimal indetraibileEUR = CfgFn.RoundValuta(indetraibile);
            txtImponibileAuto.Text = imponibileEUR.ToString("c");
            txtIvaAuto.Text = impostaEUR.ToString("c");
            txtTotaleAuto.Text = totaleEUR.ToString("c");
            txtIndetraibileAuto.Text = indetraibileEUR.ToString("c");
        }

        private void textBox11_TextChanged(object sender, EventArgs e) {
        }

        private void btnVisualizzaFattMadre_Click(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow Curr = DS.invoice.Rows[0];
            MetaData ToMeta = Meta.Dispatcher.Get("invoice");
            if (ToMeta == null)
                return;
            string checkfilter = QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind_real"]),
                QHS.CmpEq("yinv", Curr["yinv_real"]), QHS.CmpEq("ninv", Curr["ninv_real"]));
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

        private void tabPageAutofattura_Click(object sender, EventArgs e) {
        }

        private void chkAutoFattura_CheckedChanged(object sender, EventArgs e) {
            if (chkAutoFattura.Checked) {
                btnAutoFattura.Enabled = false;
            }
            else {
                VisualizzaBtnAutoFattura();
            }
        }

        private void txtScadenza_Leave(object sender, EventArgs e) {
            CalcolaDataScadenza();
        }

        private void txtDataDoc_Leave(object sender, EventArgs e) {
            CalcolaDataScadenza();
        }

        private void btnCreaRegistroUnico_Click(object sender, EventArgs e) {
            DataRow CurrInvoice = DS.invoice.Rows[0];

            MetaData Uniqueregister = MetaData.GetMetaData(this, "uniqueregister");
            Uniqueregister.SetDefaults(DS.uniqueregister);
            DataRow Runiqueregister = Uniqueregister.Get_New_Row(CurrInvoice, DS.uniqueregister);
            btnCreaRegistroUnico.Enabled = false;
        }

        private void txtProtocolDate_Leave(object sender, EventArgs e) {
            AbilitaDisabilitaRegistroUnico();
        }

        private void chkProtocollanelRU_CheckedChanged(object sender, EventArgs e) {
            AbilitaDisabilitaRegistroUnico();
        }

        public bool FatturaInviataSdI() {
            if (Meta.IsEmpty)
                return false;

            if (Meta.InsertMode)
                return false;
            DataRow rInvoice = DS.invoice.Rows[0];
            if (CfgFn.GetNoNullInt32(rInvoice["idsdi_acquistoestere"])!=0) {
                return true;
            }
            return false;
        }
        private void btnAnnullaFattura_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            if (!Meta.GetFormData(false))
                return;
            if (show(this,
                "Azzero completamente la fattura scollegandola eventualmente dai contratti collegati? (l'operazione non è annullabile)",
                "Avviso",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            bool contab = false;
            foreach (DataRow r in DS.invoicedetail.Select()) {
                if (r["idexp_iva"] != DBNull.Value)
                    contab = true;
                if (r["idexp_taxable"] != DBNull.Value)
                    contab = true;
                if (r["idinc_iva"] != DBNull.Value)
                    contab = true;
                if (r["idinc_taxable"] != DBNull.Value)
                    contab = true;
            }
            if (contab) {
                show(this, "La fattura risulta contabilizzata pertanto non è annullabile", "Avviso");
                return;
            }


            foreach (DataRow r in DS.invoicedetail.Select()) {
                r["npackage"] = 0;
                r["number"] = 0;
                r["taxable"] = 0;
                r["tax"] = 0;
                r["unabatable"] = 0;
                r["idestimkind"] = DBNull.Value;
                r["yestim"] = DBNull.Value;
                r["nestim"] = DBNull.Value;
                r["estimrownum"] = DBNull.Value;
                r["idmankind"] = DBNull.Value;
                r["yman"] = DBNull.Value;
                r["nman"] = DBNull.Value;
                r["manrownum"] = DBNull.Value;
                r["ycon"] = DBNull.Value;
                r["ncon"] = DBNull.Value;
                r["idpccdebitstatus"] = "NOLIQ";
            }
            foreach (DataRow r in DS.profservice.Select()) {
                r["idinvkind"] = DBNull.Value;
                r["yinv"] = DBNull.Value;
                r["ninv"] = DBNull.Value;
            }


            //Rimuove collegamento con assetacquire
            foreach (DataRow R in DS.assetacquire.Select()) {
                R["idinvkind"]= DBNull.Value;
                R["yinv"] = DBNull.Value;
                R["ninv"] = DBNull.Value;
                R["invrownum"] = DBNull.Value;
            }

            DataRow Curr = DS.invoice.Rows[0];
            object idsdi_acquisto = Curr["idsdi_acquisto"];

            if (idsdi_acquisto != DBNull.Value) {
                if (show(this,
                    "Vuoi rimuovere tutti i collegamenti esistenti tra questa fattura e la relativa fattura elettronica?",
                    "Avviso",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                else {
                    Curr["idsdi_acquisto"] = DBNull.Value;
                }
            }

            foreach (DataRow rBolla in DS.invoice_bolladoganale) {
                Meta.unlink(rBolla);
            }
            //MetaData.Unlink_Grid(dgrBolleDoganali);
            Meta.SaveFormData();
            Meta.FreshForm();
        }

        private void btnRipartizione_Click(object sender, EventArgs e) {

            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow RC = GetGridSelectedRowInv(gridDettagli);
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

        private bool GetGeneralFlagSplitPayment() {
            if (DS.config.Rows.Count > 0) {
                DataRow rSetup = DS.config.Rows[0];
                if (rSetup["flagsplitpayment"] == DBNull.Value)
                    return false;
                return (rSetup["flagsplitpayment"].ToString() == "S");
            }
            else
                return false;
        }

        private void btnModStatodelDebito_Click(object sender, EventArgs e) {
            object selected = DBNull.Value;
            object pccdebitmotive = DBNull.Value;
            DataTable Pccdebitstatus = Conn.RUN_SELECT("pccdebitstatus", "*", "listingorder asc", null, null, null, true);
            object idpccdebitstatusDefault = null;
            if (DS.config.Rows.Count > 0) {
                DataRow debitStatusSetup = DS.config.Rows[0];
                idpccdebitstatusDefault = debitStatusSetup["idpccdebitstatus"];
            }

            FrmAskStatoDelDebito F = new FrmAskStatoDelDebito(Meta, Pccdebitstatus, idpccdebitstatusDefault);
            if (F.ShowDialog() != DialogResult.OK)
                return;
            selected = F.cmbStatodeldebito.SelectedValue;
            pccdebitmotive = F.idpccdebitmotive;
            string message = "";
            if (selected != null)
                message = "Cambio lo Stato del Debito a tutti i dettagli ponendoli come: " +
                          selected.ToString() + "?. La Causale resterà invariata";
            if (pccdebitmotive != null)
                message = "Cambio lo Stato del Debito e la Causale a tutti i dettagli ponendoli come: " +
                          selected.ToString() + " e " + pccdebitmotive + "?";

            if (selected != null) {
                if (show(this, message,
                    "Avviso",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                foreach (DataRow r in DS.invoicedetail.Select()) {
                    r["idpccdebitstatus"] = selected;
                    if ((pccdebitmotive != DBNull.Value) && (pccdebitmotive != null))
                        r["idpccdebitmotive"] = pccdebitmotive;
                }
            }
        }

        private void chk_auto_split_payment_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) {
                return;
            }
            chk_enable_split_payment.Enabled = chk_auto_split_payment.Checked && chk_auto_split_payment.Enabled ||
                                               Meta.IsEmpty;
            chk_enable_reverse_charge.Enabled = chk_auto_split_payment.Checked && chk_auto_split_payment.Enabled ||
                                                Meta.IsEmpty;
        }

        private void AggiungidaFE(string modalita) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataRow R = DS.invoice.Rows[0];
            if (CfgFn.GetNoNullInt32(R["idreg"]) == 0) {
                show("Selezionare prima il fornitore.");
                return;
            }
            object idreg = R["idreg"];
            string regfilter = QHS.CmpEq("idreg", idreg);
            object idinvkind = R["idinvkind"];
            string idinvkindfilter_C = QHC.CmpEq("idinvkind", idinvkind);
            string flagmixfilter = null;
            DataRow[] TipoFattura = DS.invoicekind.Select(idinvkindfilter_C);
            if (TipoFattura.Length != 0) {
                DataRow[] Reg = DS.invoicekindregisterkind.Select(idinvkindfilter_C);
                foreach (DataRow RREg in Reg) {
                    string filterregkind = QHC.CmpEq("idivaregisterkind", RREg["idivaregisterkind"]);
                    DataRow[] RegKind = DS.ivaregisterkind.Select(filterregkind);
                    if (RegKind.Length == 0)
                        continue;
                    int flaga = CfgFn.GetNoNullInt32(RegKind[0]["flagactivity"]);
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
            DataTable T = DS.invoicedetail;

            if (TipoFattura.Length != 0) {
                DataRow InvoiceKind = TipoFattura[0];
                DS.invoicedetail.ExtendedProperties["flag"] = (InvoiceKind != null) ? InvoiceKind["flag"] : null;
                DS.invoicedetail.ExtendedProperties["registerclass"] = tipoRegistroAV();
                DS.invoicedetail.ExtendedProperties["flagactivity"] = TipoAttivita();
                DS.invoicedetail.ExtendedProperties["flagintracom"] = GetFlagIntracom();
            }

            DataTable Tassociazioni = null;
            DataRow[] AssociazioniRows = null;
            object flagactivity = TipoAttivita();
            if (modalita == "contrattopassivo") {
                FrmAssociaDettagliDaFE F = new FrmAssociaDettagliDaFE(Meta, R["idsdi_acquisto"], R["idcurrency"],
                    flagactivity, regfilter, flagmixfilter,
                    !chkflag_ddt.Checked, T);
                if (F.ShowDialog(this) != DialogResult.OK) {
                    Meta.DontWarnOnInsertCancel = true;
                    AggiornaSDIAcquistoEnabled = false;
                    DS.sdi_acquisto.RejectChanges();
                    Meta.DoMainCommand("maindelete");
                    AggiornaSDIAcquistoEnabled = true;
                    this.Close();
                    return;
                }
                Tassociazioni = F.Tassociazioni;
                if (Tassociazioni == null)
                    return;
                if (Tassociazioni.Rows.Count == 0)
                    return;
                AssociazioniRows = Tassociazioni.Select();
                int flag_requested_doc = 0;
                foreach (DataRow Curr in AssociazioniRows) {
                    decimal unitsforpackage = 1;
                    if (Curr["unitsforpackage"] != DBNull.Value)
                        unitsforpackage = CfgFn.GetNoNullInt32(Curr["unitsforpackage"]);
                    decimal NumberResidual = CfgFn.GetNoNullDecimal(Curr["residual"])*unitsforpackage;
                    // E' lo stesso metodo chiamato da Aggiungi da Ordine
                    AddMandateDetailRow(Curr, CfgFn.GetNoNullDecimal(NumberResidual));
                    flag_requested_doc = flag_requested_doc | CfgFn.GetNoNullInt32(Curr["requested_doc"]);
                }
                R["requested_doc"] = flag_requested_doc;
                //Crea le righe degli allegati 
                CreaRigheAllegati(F.Tallegati);
            } // fine modalità Contratto Passivo

            DataRow rProfService = null;
            if (modalita == "parcella") {

                FrmCreaDaParcellaFE F = new FrmCreaDaParcellaFE(Meta, R["idsdi_acquisto"], flagactivity, regfilter, T);
                if (F?.ShowDialog(this) != DialogResult.OK) {
                    Meta.DontWarnOnInsertCancel = true;
                    AggiornaSDIAcquistoEnabled = false;
                    DS.sdi_acquisto.RejectChanges();
                    Meta.DoMainCommand("maindelete");
                    AggiornaSDIAcquistoEnabled = true;
                    this.Close();
                    return;
                }
                rProfService = F?.rProfservice;
                if (rProfService != null) {
                    // Stesso metodo chiamato quandi da Crea da Contratto Professionale
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.profservice, null,
                        QHS.AppAnd(QHS.CmpEq("ycon", rProfService["ycon"]), QHS.CmpEq("ncon", rProfService["ncon"])),
                        null, true);

                    DataRow myProfService = DS.profservice.Rows[0];
                    myProfService["idinvkind"] = R["idinvkind"];
                    myProfService["yinv"] = R["yinv"];
                    myProfService["ninv"] = R["ninv"];
                    Meta.MarkTableAsNotEntityChild(DS.profservice);
                    CollegaContratto(myProfService);
                    //Crea le righe degli allegati 
                    CreaRigheAllegati(F.Tallegati);
                    return;
                }
                else {
                    Tassociazioni = F.Tassociazioni;
                    if (Tassociazioni == null)
                        return;
                    if (Tassociazioni.Rows.Count == 0)
                        return;
                    AssociazioniRows = Tassociazioni.Select();
                    foreach (DataRow Curr in AssociazioniRows) {
                        decimal unitsforpackage = 1;
                        if (Curr["unitsforpackage"] != DBNull.Value)
                            unitsforpackage = CfgFn.GetNoNullInt32(Curr["unitsforpackage"]);
                        decimal NumberResidual = CfgFn.GetNoNullDecimal(Curr["residual"])*unitsforpackage;
                        // E' lo stesso metodo chiamato da Aggiungi da Ordine
                        AddMandateDetailRow(Curr, CfgFn.GetNoNullDecimal(NumberResidual));
                    }
                    //Crea le righe degli allegati 
                    CreaRigheAllegati(F.Tallegati);
                }
            } //fine modalità Parcella


            Meta.myGetData.GetTemporaryValues(DS.invoicedetail);
            Meta.FreshForm(false);
        }

        private void CreaRigheAllegati(DataTable TallegatiSDI) {
            DataTable Tallegati = null;
            DataRow[] AllegatiRows = null;
            Tallegati = TallegatiSDI;
            if (Tallegati == null)
                return;
            if (Tallegati.Rows.Count == 0)
                return;
            AllegatiRows = Tallegati.Select();
            foreach (DataRow Curr in AllegatiRows) {
                DataRow CurrIvnoice = DS.invoice.Rows[0];
                MetaData MI = MetaData.GetMetaData(this, "invoiceattachment");
                MI.SetDefaults(DS.invoiceattachment);
                DataRow Rinvoiceattachment = MI.Get_New_Row(CurrIvnoice, DS.invoiceattachment);
                Rinvoiceattachment["filename"] = Curr["filename"];
                Rinvoiceattachment["attachment"] = Curr["attachment"];
            }
        }

        private void chk_enable_split_payment_CheckedChanged(object sender, EventArgs e) {
            if (Meta != null) {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
            }
            if ((chk_auto_split_payment.Checked && chk_auto_split_payment.Enabled) && (chk_enable_split_payment.Checked))
                chk_enable_reverse_charge.Checked = false;
        }

        private void chk_enable_reverse_charge_CheckedChanged(object sender, EventArgs e) {
            if (Meta != null) {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
            }
            if ((chk_auto_split_payment.Checked && chk_auto_split_payment.Enabled) &&
                (chk_enable_reverse_charge.Checked))
                chk_enable_split_payment.Checked = false;
        }

        private void btnCopiaUPBeCausaleEP_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            btnCopiaUPBeCausaleEP.Focus();
            MetaData.GetFormData(this, true);
            if (DS.invoicedetail.Rows.Count <= 1) return;
            string msg =
                "Questa operazione copia le informazioni specifiche (UPB, UPB per la contabilizzazione dell'IVA e Causale EP e natura di spesa) del dettaglio corrente" +
                " evidenziato su tutti gli altri dettagli della fattura in stato di INSERIMENTO senza cambiare i dati già presenti. Confermi?";
            DialogResult res = show(msg, "Conferma",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {
                DataRow selRow = HelpForm.GetLastSelected(DS.invoicedetail);
                if (selRow == null) return;
                foreach (DataRow row in DS.invoicedetail.Rows) {
                    if (row.RowState != DataRowState.Added) continue;
                    // A seguito del task 10572 copio i dati in modo più brutale
                    //if (row["idupb"] == DBNull.Value && selRow["idupb"] != DBNull.Value) {
                    row["idupb"] = selRow["idupb"];
                    //}
                    //if (row["idupb_iva"] == DBNull.Value && selRow["idupb_iva"] != DBNull.Value) {
                    row["idupb_iva"] = selRow["idupb_iva"];
                    //}
                    //if (row["idaccmotive"] == DBNull.Value && selRow["idaccmotive"] != DBNull.Value) {
                    row["idaccmotive"] = selRow["idaccmotive"];
                    row["idsor_siope"] = selRow["idsor_siope"];
                    //}
                    //if (row["expensekind"] == DBNull.Value && selRow["expensekind"] != DBNull.Value) {
                    row["expensekind"] = selRow["expensekind"];
                    //}
                }
            }
        }

        private DataRow GetGridSelectedRow(DataGrid G) {
            DataSet DSV = (DataSet) G.DataSource;
            if (DSV == null)
                return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null)
                return null;

            if (TV.Rows.Count == 0)
                return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView) G.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null)
                return null;

            DataRow R = DV.Row;
            return R;
        }

        private void btnDividiDettaglio_Click(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow RigaSelezionata = GetGridSelectedRow(gridDettagli);
            if (RigaSelezionata == null)
                return;
           
            if (RigaSelezionata["idmankind"] != DBNull.Value) {
                show("Dettaglio collegato a Contratto Passiv.", "Avviso");
                return;
            }
            if (RigaSelezionata["idestimkind"] != DBNull.Value) {
                show("Dettaglio collegato a Contratto Attivo2", "Avviso");
                return;
            }
            if ((RigaSelezionata["idexp_taxable"] != DBNull.Value) && (RigaSelezionata["idexp_iva"] != DBNull.Value)) {
                show("Dettaglio contabilizzato", "Avviso");
                return;
            }
            if ((RigaSelezionata["idinc_taxable"] != DBNull.Value) && (RigaSelezionata["idinc_iva"] != DBNull.Value)) {
                show("Dettaglio contabilizzato", "Avviso");
                return;
            }
            DataRow Fattura = DS.invoice.Rows[0];
            decimal totaleImponibile = CfgFn.GetNoNullDecimal(RigaSelezionata["taxable"]);
            decimal totaleIva = CfgFn.GetNoNullDecimal(RigaSelezionata["tax"]);
            frmAskDividi F = new frmAskDividi(RigaSelezionata, Meta, Meta.Dispatcher);
            if (F.ShowDialog(this) != DialogResult.OK)
                return;

            DataTable Info = F.Info;
            string filter = QHC.AppOr(QHC.CmpNe("taxable", 0), QHC.CmpNe("tax", 0), QHC.CmpNe("unabatable", 0));
            DataRow[] RigheSplittate = Info.Select(filter);
            if (RigheSplittate.Length > 0) {
                RigaSelezionata["idupb"] = RigheSplittate[0]["idupb"];
                RigaSelezionata["taxable"] = RigheSplittate[0]["taxable"];
                RigaSelezionata["tax"] = RigheSplittate[0]["tax"];
                RigaSelezionata["unabatable"] = RigheSplittate[0]["unabatable"];
                // Ciclo per la creazione di nuovi dettagli
                Meta.GetFormData(false);
                MetaData metaDT = MetaData.GetMetaData(this, "invoicedetail");
                metaDT.SetDefaults(DS.invoicedetail);
                if (RigheSplittate.Length > 1) {
                    for (int i = 1; i <= (RigheSplittate.Length - 1); i++) {
                        DataRow rInfo = RigheSplittate[i];
                        DataRow rDT = metaDT.Get_New_Row(Fattura, DS.invoicedetail);
                        rDT["idgroup"] = RigaSelezionata["idgroup"];
                        rDT["taxable"] = rInfo["taxable"];
                        rDT["tax"] = rInfo["tax"];
                        rDT["idupb"] = rInfo["idupb"];
                        rDT["unabatable"] = rInfo["unabatable"];
                        rDT["number"] = CfgFn.GetNoNullDecimal(RigaSelezionata["number"]);
                        rDT["npackage"] = CfgFn.GetNoNullDecimal(RigaSelezionata["npackage"]);
                        rDT["idlist"] = RigaSelezionata["idlist"];
                        rDT["idunit"] = RigaSelezionata["idunit"];
                        rDT["idpackage"] = RigaSelezionata["idpackage"];
                        rDT["unitsforpackage"] = RigaSelezionata["unitsforpackage"];
                        rDT["detaildescription"] = RigaSelezionata["detaildescription"].ToString();
                        rDT["idexp_taxable"] = RigaSelezionata["idexp_taxable"];
                        rDT["idexp_iva"] = RigaSelezionata["idexp_iva"];
                        rDT["idinc_taxable"] = RigaSelezionata["idinc_taxable"];
                        rDT["idinc_iva"] = RigaSelezionata["idinc_iva"];
                        rDT["competencystart"] = RigaSelezionata["competencystart"];
                        rDT["competencystop"] = RigaSelezionata["competencystop"];
                        rDT["idivakind"] = RigaSelezionata["idivakind"];
                        rDT["annotations"] = RigaSelezionata["annotations"];
                        rDT["discount"] = RigaSelezionata["discount"];
                        rDT["idaccmotive"] = RigaSelezionata["idaccmotive"];
                        rDT["idsor_siope"] = RigaSelezionata["idsor_siope"];
                        rDT["idsor1"] = RigaSelezionata["idsor1"];
                        rDT["idsor2"] = RigaSelezionata["idsor2"];
                        rDT["idsor3"] = RigaSelezionata["idsor3"];
                        rDT["idcostpartition"] = RigaSelezionata["idcostpartition"];
                        rDT["cupcode"] = RigaSelezionata["cupcode"];
                        rDT["cigcode"] = RigaSelezionata["cigcode"];
                        rDT["expensekind"] = RigaSelezionata["expensekind"];
                        rDT["idpccdebitstatus"] = RigaSelezionata["idpccdebitstatus"];
                        rDT["idpccdebitmotive"] = RigaSelezionata["idpccdebitmotive"];
                        rDT["idepexp"] = RigaSelezionata["idepexp"];
                        rDT["estimrownum"] = RigaSelezionata["estimrownum"];
                        rDT["estimrownum"] = RigaSelezionata["estimrownum"];
                        rDT["fereferencerule"] = RigaSelezionata["fereferencerule"];
                        rDT["fereferencerule"] = RigaSelezionata["fereferencerule"];
                        rDT["idepacc"] = RigaSelezionata["idepacc"];
                        rDT["idestimkind"] = RigaSelezionata["idestimkind"];
                        rDT["idfetransfer"] = RigaSelezionata["idfetransfer"];
                        rDT["idintrastatcode"] = RigaSelezionata["idintrastatcode"];
                        rDT["idintrastatmeasure"] = RigaSelezionata["idintrastatmeasure"];
                        rDT["idintrastatservice"] = RigaSelezionata["idintrastatservice"];
                        rDT["idintrastatsupplymethod"] = RigaSelezionata["idintrastatsupplymethod"];
                        rDT["idinvkind_main"] = RigaSelezionata["idinvkind_main"];
                        rDT["idmankind"] = RigaSelezionata["idmankind"];
                        rDT["idupb_iva"] = RigaSelezionata["idupb_iva"];
                        rDT["intra12operationkind"] = RigaSelezionata["intra12operationkind"];
                        rDT["intrastatoperationkind"] = RigaSelezionata["intrastatoperationkind"];
                        rDT["leasing"] = RigaSelezionata["leasing"];
                        rDT["manrownum"] = RigaSelezionata["manrownum"];
                        rDT["move12"] = RigaSelezionata["move12"];
                        rDT["nestim"] = RigaSelezionata["nestim"];
                        rDT["ninv_main"] = RigaSelezionata["ninv_main"];
                        rDT["nman"] = RigaSelezionata["nman"];
                        rDT["paymentcompetency"] = RigaSelezionata["paymentcompetency"];
                        rDT["resetresidualmandate"] = RigaSelezionata["resetresidualmandate"];
                        rDT["rounding"] = RigaSelezionata["rounding"];
                        rDT["rownum"] = RigaSelezionata["rownum"];
                        rDT["usedmodesospesometro"] = RigaSelezionata["usedmodesospesometro"];
                        rDT["va3type"] = RigaSelezionata["va3type"];
                        rDT["weight"] = RigaSelezionata["weight"];
                        rDT["yestim"] = RigaSelezionata["yestim"];
                        rDT["yinv_main"] = RigaSelezionata["yinv_main"];
                        rDT["yman"] = RigaSelezionata["yman"];
                    }
                }
                Meta.FreshForm();
            }
        }

        private object[] ValoriDiversi(DataRow[] Rows, string field) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].Equals(currval)) {
                        break;
                    }
                }
                if (j == N) {
                    DIV[N++] = currval;
                }
            }
            object[] result = new object[N];
            for (int i = 0; i < N; i++)
                result[i] = DIV[i];
            return result;
        }

        private void btnUnisciDettagli_Click(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0)
                return;
            DataRow RigaSelezionata = GetGridSelectedRow(gridDettagli);
            if (RigaSelezionata == null)
                return;

            DataRow[] parcella = DS.profservice.Select(QHC.IsNotNull("idinvkind"));
            if (parcella.Length > 0) {
                show("Fattura collegata a Parcella", "Avviso");
                return;
            }
            if (RigaSelezionata["idmankind"] != DBNull.Value) {
                show("Dettaglio collegato a Contratto Passivo.", "Avviso");
                return;
            }
            if (RigaSelezionata["idestimkind"] != DBNull.Value) {
                show("Dettaglio collegato a Contratto Attivo.", "Avviso");
                return;
            }

            string filtergroup = QHC.CmpEq("idgroup", RigaSelezionata["idgroup"]);
            DataRow[] Selected = DS.invoicedetail.Select(filtergroup, "rownum");
            decimal detailsGroup = Selected.Length;

            object codiceDoc = cboTipo.SelectedValue;
            DataRow R = DS.invoicekind.Select(QHC.CmpEq("idinvkind", codiceDoc))[0];
            byte flag = CfgFn.GetNoNullByte(R["flag"]);
            bool movimentoEntrata =  (flag & 1) != 0;

            if (detailsGroup > 1) {
                decimal taxable = 0;
                decimal tax = 0;
                decimal unabatable = 0;
                object[] upb = ValoriDiversi(Selected, "idupb");
                object[] idexp_taxable;
                object[] idexp_iva;
                if (movimentoEntrata) {
                    idexp_taxable = ValoriDiversi(Selected, "idinc_taxable");
                    idexp_iva = ValoriDiversi(Selected, "idinc_iva");
                }
                else {
                    idexp_taxable = ValoriDiversi(Selected, "idexp_taxable");
                    idexp_iva = ValoriDiversi(Selected, "idexp_iva");
                }
                object idupb = DBNull.Value;
                if (upb.Length == 1) {
                    idupb = upb[0];
                }
                // Ciclo per verificare se è possibile riunire i dettagli splittati
                foreach (DataRow DR in Selected) {
                    if ((idexp_taxable.Length > 1) || (idexp_iva.Length > 1)) {
                        show(
                            "Alcuni dettagli dello stesso gruppo sono contabilizzati. Non è possibile annullare la suddivisione.",
                            "Avviso");
                        return;
                    }
                    //Ricalcolo imponibile unitario, iva e iva indetraibile come somma dei dettagli splittati
                    taxable += CfgFn.GetNoNullDecimal(DR["taxable"]);
                    tax += CfgFn.GetNoNullDecimal(DR["tax"]);
                    unabatable += CfgFn.GetNoNullDecimal(DR["unabatable"]);
                }
                // Cancello i dettagli del contratto passivo, ad eccezione del primo del gruppo
                DataRow Original = Selected[0];
                int rownum = CfgFn.GetNoNullInt32(Original["rownum"]);
                string filterToDel = QHC.CmpGt("rownum", Original["rownum"]);
                filterToDel = GetData.MergeFilters(filtergroup, filterToDel);
                DataRow[] RowToDel = DS.invoicedetail.Select(filterToDel);
                foreach (DataRow DR in RowToDel) {
                    DR.Delete();
                }
                Original["idupb"] = idupb;
                Original["taxable"] = taxable;
                Original["tax"] = tax;
                Original["unabatable"] = unabatable;
                Meta.FreshForm();
            }
        }

        bool isSSN() {
            if (cboTipo.SelectedIndex <= 0) return false;
            object idinvkind = cboTipo.SelectedValue;
            string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            DataRow[] RegisterToLink = DS.invoicekindregisterkind.Select(filterreg);
            foreach (DataRow IReg in RegisterToLink) {
                object idivaregisterkind = IReg["idivaregisterkind"];
                if (DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind)).Length == 0)
                    continue;
                DataRow IvaRegKind = DS.ivaregisterkind.Select(QHC.CmpEq("idivaregisterkind", idivaregisterkind))[0];
                if (IvaRegKind["codeivaregisterkind"].ToString().ToUpper() == "16TESSERASANITARIA") return true;
            }
            return false;
        }

        void clearSSN() {
            foreach (Control c in gboxTesseraSSN.Controls) {
                if (c.GetType() == typeof(RadioButton)) {
                    ((RadioButton) c).Checked = false;
                }
            }
        }

        private void chkBollaDoganale_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) {
                return;
            }
            if (!Meta.DrawStateIsDone) {
                return;
            }
            //La fattura viene marcata come "ad iva immediata" e come "non utilizzabile per la contabilizzazione"
            if (chkBollaDoganale.Checked) {
                chb_IVADifferita.Checked = false;
                chkContabilizzabile.Checked = false;
                chkProtocollanelRU.Checked = false;
                chk_auto_split_payment.Checked = false;
                chk_enable_split_payment.Checked = false;
                chkAutoFattura.Checked = false;
                chkIncludeInPaymentIndicator.Checked = false;
                chkFatturaSpedizioniere.Checked = false;
            }
            DoManageSplitPayment();

            //else {
            //    chb_IVADifferita.Checked = false;
            //    chkContabilizzabile.Checked = false;
            //}
        }

        private bool BolletteDoganaliInserite() {
            if (DS.invoicekind_bolladoganale.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void chkFatturaSpedizioniere_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null) {
                return;
            }

            if (chkFatturaSpedizioniere.Checked) {
                btnInserisciBollettaDoganale.Enabled = true;
            }
            else {
                btnInserisciBollettaDoganale.Enabled = false;
            }
        }

        string CalculateFilterForLinking() {
            string MyFilter = "";
            MyFilter = QHS.CmpEq("flag_bolladoganale", 'S');
            //MyFilter = QHS.BitSet("flagbit", 0);
            MyFilter = QHS.AppAnd(QHS.IsNull("idinvkind_forwarder"), MyFilter);

            return MyFilter;
        }

        private void btnInserisciBollettaDoganale_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            string MyFilter = CalculateFilterForLinking();

            string command = "choose.invoice_bolladoganale.default." + MyFilter;
            MetaData.Choose(this, command);
        }

        

        Dictionary<string,string>veroTipo= new Dictionary<string, string>();
        private string veroTipoFatturaAv(object idInvKind) {
            if (veroTipo.ContainsKey(idInvKind.ToString())) return veroTipo[idInvKind.ToString()];
            string filterreg = QHS.CmpEq("idinvkind", idInvKind);
            DataTable invRegKind = Conn.RUN_SELECT("invoicekindregisterkind", "*", null, filterreg, null, false);
            DataRow[] registerToLink = invRegKind.Select();
            bool acquisto = false;
            foreach (DataRow iReg in registerToLink) {
                object regClass = Conn.DO_READ_VALUE("ivaregisterkind",
                    QHS.CmpEq("idivaregisterkind", iReg["idivaregisterkind"]),
                    "registerclass");
                if (regClass.ToString().ToUpper() == "A")
                    acquisto = true;
            }
            veroTipo[idInvKind.ToString()] = (acquisto ? "A" : "V");
            return veroTipo[idInvKind.ToString()];
        }

        Dictionary<string, int> tipoAtt = new Dictionary<string, int>();
        private int tipoAttivita(object idInvKind) {
            if (tipoAtt.ContainsKey(idInvKind.ToString())) return tipoAtt[idInvKind.ToString()];
            string filterreg = QHS.CmpEq("idinvkind", idInvKind);
            DataTable invRegKind = Conn.RUN_SELECT("invoicekindregisterkind", "*", null, filterreg, null, false);
            DataRow[] registerToLink = invRegKind.Select();
            foreach (DataRow iReg in registerToLink) {
                object regClass = Conn.DO_READ_VALUE("ivaregisterkind",
                    QHS.CmpEq("idivaregisterkind", iReg["idivaregisterkind"]), "registerclass");
                if (regClass.ToString().ToUpper() == "P")
                    continue;
                int res = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("ivaregisterkind",
                        QHS.CmpEq("idivaregisterkind", iReg["idivaregisterkind"]), "flagactivity"));
                tipoAtt[idInvKind.ToString()] = res;
                return res;


            }
            tipoAtt[idInvKind.ToString()] = 1;
            return 1;
        }

        void LinkBollettaDoganale(DataRow RigaSelezionata) {
            if (RigaSelezionata == null) return;
            // Ciclo per la creazione due nuovi dettagli
            DataRow RInvoice = DS.invoice.Rows[0];
            MetaData metaDT = MetaData.GetMetaData(this, "invoicedetail");
            metaDT.SetDefaults(DS.invoicedetail);
            string filterNewDettagliFattura = QHS.AppAnd(QHS.CmpEq("idinvkind", RigaSelezionata["idinvkind"]),
                QHS.CmpEq("yinv", RigaSelezionata["yinv"]),
                QHS.CmpEq("ninv", RigaSelezionata["ninv"]));
            DataTable Tinvoicedetail_toAdd = Meta.Conn.RUN_SELECT("invoicedetail", "*", null, filterNewDettagliFattura,
                null, true);

            //Causale spese anticipate : idaccmotive_forwarder
            object CausaleSpeseAnticipate = DBNull.Value;
            //Tipo iva esente : idivakind_forwarder
            object TipoIvaEsente = DBNull.Value;
            if (DS.config.Rows.Count > 0) {
                DataRow rConfig = DS.config.Rows[0];
                if (rConfig["idaccmotive_forwarder"] != DBNull.Value) {
                    CausaleSpeseAnticipate = rConfig["idaccmotive_forwarder"];
                }
                else {
                    show("Non è stata configurata la causale spese anticipate dallo spedizioniere", "Errore");
                }
                if (rConfig["idivakind_forwarder"] != DBNull.Value) {
                    TipoIvaEsente = rConfig["idivakind_forwarder"];
                }
                else {
                    show("Non è stata configurata la causale iva esente bolle doganali", "Errore");
                }
            }
            double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(RInvoice["exchangerate"]));
            double abatablerate = CfgFn.GetNoNullDouble(
                Conn.DO_READ_VALUE("invoicekindyearview",
                    QHS.AppAnd(QHS.CmpEq("idinvkind", RInvoice["idinvkind"]), QHS.CmpEq("ayear", Conn.GetEsercizio())),
                    "abatablerate",
                    null));
            int myTipoAttivita = tipoAttivita(RInvoice["idinvkind"]);
            string myVeroTipoFattura = veroTipoFatturaAv(RInvoice["idinvkind"]);

            //Aggiunge i dettagli marcati come VALORE DOGANALE            
            foreach (DataRow R in Tinvoicedetail_toAdd.Select()) {
                int flag = CfgFn.GetNoNullInt32(R["flagbit"]);
                bool valoreDoganale = ((flag & 1) != 0);

                double rImponibile = CfgFn.GetNoNullDouble(R["taxable"]);
                double iva = CfgFn.GetNoNullDouble(R["tax"]);
                double quantita = CfgFn.GetNoNullDouble(R["npackage"]);
                var scontoPerc = CfgFn.GetNoNullDouble(R["discount"]);
                double imponibileD = CfgFn.RoundValuta(rImponibile*quantita*tassocambio);
                decimal imponibile = Convert.ToDecimal(imponibileD);
                decimal imponibileScontato =
                    Convert.ToDecimal(CfgFn.RoundValuta(rImponibile*quantita*tassocambio*(1 - scontoPerc)));

                decimal sconto = imponibile - imponibileScontato;



                bool istituzionale = (myTipoAttivita == 1);

                double ivaindetraibile = 0; //CfgFn.GetNoNullDouble(Rinvdet["unabatable"]);
                double ivadetraibile; //CfgFn.RoundValuta(ivadetraibilelorda*abatablerate);		

                if (istituzionale) {
                    ivaindetraibile = CfgFn.RoundValuta(iva);
                    ivadetraibile = 0;
                }
                else {
                    ivaindetraibile = CfgFn.GetNoNullDouble(R["unabatable"]);
                    var ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile));
                    //CfgFn.RoundValuta((iva-ivaindetraibile)*tassocambio);
                    ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda*abatablerate);
                }

                decimal ivaIndetraibileNoProrata = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(ivaindetraibile));
                decimal valoreIvaTotale = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["tax"]));

                //iva = iva detraibile, da movimentarsi con il conto normale dell'iva (acq/vendite)
                decimal valoreIvaDetraibile = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(ivadetraibile));
                decimal ivaIndetraibile = valoreIvaTotale - valoreIvaDetraibile;

                decimal ivaIndetraibileDovutaAProrata = ivaIndetraibile - ivaIndetraibileNoProrata;



                //Aggiunge i dettagli marcati come  VALORE DOGANALE
                if (valoreDoganale && ivaIndetraibile > 0) {
                    DataRow rNew = metaDT.Get_New_Row(RInvoice, DS.invoicedetail);
                    foreach (DataColumn c in DS.invoicedetail.Columns) {
                        string field = c.ColumnName;
                        if (QueryCreator.IsPrimaryKey(DS.invoicedetail, field))
                            continue;
                        if (field == "tax") {
                            rNew["taxable"] = ivaIndetraibile;
                            rNew["tax"] = 0;
                            continue;
                        }
                        if (field == "idaccmotive") {
                            rNew[field] = CausaleSpeseAnticipate;
                            continue;
                        }
                        if (field == "idivakind") {
                            rNew[field] = TipoIvaEsente;
                            continue;
                        }
                        if (field == "detaildescription") {
                            string descrizione_completa = "Valore Doganale-" + R["detaildescription"];
                            if (descrizione_completa.Length > 150) {
                                rNew["detaildescription"] = descrizione_completa.Substring(1, 150);
                            }
                            else {
                                rNew["detaildescription"] = descrizione_completa;
                            }
                            continue;
                        }
                        if ((field.Substring(0, 1) == "!") || (field == "taxable") || (field == "idgroup")) {
                            continue;
                        }
                        //Valore Doganale : invoicedetail.flag bit 0
                        if (field == "flagbit") {
                            rNew[field] = (CfgFn.GetNoNullInt32(R["flagbit"]) & (~1)) | 2;
                            continue;
                        }
                        rNew[field] = R[field];
                    }
                }

                if ((valoreDoganale == false) && (imponibileScontato + ivaIndetraibile != 0)) {
                    //Aggiunge i dettagli NON marcati come VALORE DOGANALE-Scrive solo l'imponibile + iva indetraibile
                    DataRow rNew = metaDT.Get_New_Row(RInvoice, DS.invoicedetail);
                    foreach (DataColumn c in DS.invoicedetail.Columns) {
                        string field = c.ColumnName;
                        if (QueryCreator.IsPrimaryKey(DS.invoicedetail, field))
                            continue;
                        if (field == "idaccmotive") {
                            rNew[field] = CausaleSpeseAnticipate;
                            continue;
                        }
                        if (field == "idivakind") {
                            rNew[field] = TipoIvaEsente;
                            continue;
                        }
                        //Calcola imponibile totale + sconto + iva indetraibile e lo scrive nel campo imponibile, con q.tà 1
                        if (field == "taxable") {
                            rNew[field] = imponibileScontato + ivaIndetraibile;
                            //Comprende anche l'iva Indetraibile                                
                            continue;
                        }

                        if (field == "detaildescription") {
                            string descrizione_completa = "Costo-" + R["detaildescription"];
                            if (descrizione_completa.Length > 150) {
                                rNew["detaildescription"] = descrizione_completa.Substring(1, 150);
                            }
                            else {
                                rNew["detaildescription"] = descrizione_completa;
                            }
                            continue;
                        }
                        if ((field == "npackage") || (field == "number")) {
                            rNew[field] = 1;
                            continue;
                        }
                        if ((field == "tax") ||
                            (field == "unabatable")) {
                            rNew[field] = 0;
                            continue;
                        }
                        if ((field.Substring(0, 1) == "!") || (field == "idgroup")) {
                            continue;
                        }

                        //Spese Anticipate da Spedizioniere : invoicedetail.flag bit 1
                        if (field == "flagbit") {
                            rNew[field] = CfgFn.GetNoNullInt32(R["flagbit"]) | 2;
                            continue;
                        }
                        rNew[field] = R[field];
                    }
                }




                //Aggiunge i dettagli NON marcati come VALORE DOGANALE - Scrive solo l'IVA DETRAIBILE nel campo Imponibile
                if (valoreIvaDetraibile > 0) {
                    //string filterNoValoreDoganale_ConIVA = QHC.AppAnd(filterNoValoreDoganale,QHC.CmpGt("tax",0));            
                    DataRow rNew = metaDT.Get_New_Row(RInvoice, DS.invoicedetail);
                    foreach (DataColumn c in DS.invoicedetail.Columns) {
                        string field = c.ColumnName;
                        if (QueryCreator.IsPrimaryKey(DS.invoicedetail, field))
                            continue;
                        if (field == "idaccmotive") {
                            rNew[field] = CausaleSpeseAnticipate;
                            continue;
                        }
                        if (field == "idivakind") {
                            rNew[field] = TipoIvaEsente;
                            continue;
                        }
                        if ((field == "npackage") || (field == "number")) {
                            rNew[field] = 1;
                            continue;
                        }
                        if (field == "tax") {
                            rNew["taxable"] = valoreIvaDetraibile;
                            rNew["tax"] = 0;
                            rNew["unabatable"] = 0;
                            continue;
                        }
                        if (field == "detaildescription") {
                            string descrizione_completa = "Iva Detraibile-" + R["detaildescription"];
                            if (descrizione_completa.Length > 150) {
                                rNew["detaildescription"] = descrizione_completa.Substring(1, 150);
                            }
                            else {
                                rNew["detaildescription"] = descrizione_completa;
                            }
                            continue;
                        }

                        if ((field.Substring(0, 1) == "!") || (field == "taxable") || (field == "idepexp") ||
                            (field == "unabatable") || (field == "idgroup")) {
                            continue;
                        }

                        //Valore Doganale : invoicedetail.flag bit 0
                        if (field == "flagbit") {
                            rNew[field] = (CfgFn.GetNoNullInt32(R["flagbit"]) & (~1)) | 2;
                            continue;
                        }

                        rNew[field] = R[field];
                    }
                }
            }
            Meta.FreshForm();
        }

        private void btnScollegaBollettaDoganale_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(dgrBolleDoganali);
            //HelpForm.SetDataGrid(dgrBolleDoganali, DS.invoice_bolladoganale);
            Meta.FreshForm();
        }

        private void MenuEnterPwd_Click(object sender, EventArgs e) {
            if (sender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
            object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;

            ep_functions.FrmShowTracciato FT = new ep_functions.FrmShowTracciato(tracciatoRipartizione,
                "Importazione ripartizione");
            FT.ShowDialog();
        }

        string[] tracciatoRipartizione = new string[] {
            "quota;Percentuale o valore da ripartire;Numero;22",
            "codice1;Codice prima coordinata analitica;Stringa;50",
            "codice2;Codice seconda coordinata analitica;Stringa;50",
            "codice3;Codice terza coordinata analitica;Stringa;50"
        };

        private void rdbTicket_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void rdbSpesePrestazioni_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e) {
            DoEnableDisableInfoSuSpeseSanitarie(sender);
        }

        public bool CaricoCollegato(string filter_forAssetacquire) {
            DataTable tAssetacquire = Conn.RUN_SELECT("assetacquire", "*", null, filter_forAssetacquire, null, false);
            if (tAssetacquire == null || tAssetacquire.Rows.Count == 0) return false;
            if (tAssetacquire.Rows.Count > 0) return true;
            return false;
        }
        public bool ContoImmobilizzazione(object idaccmotive) {
            if (idaccmotive == DBNull.Value || idaccmotive == null) return false;
            string filteraccmotive = QHS.AppAnd(QHS.CmpEq("idaccmotive", idaccmotive),
                QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
            DataTable tAccmotivedetail = Conn.RUN_SELECT("accmotivedetail", "*", null, filteraccmotive, null, false);
            if (tAccmotivedetail == null || tAccmotivedetail.Rows.Count == 0) return false;
            if (tAccmotivedetail.Rows[0]["idacc"] == null || tAccmotivedetail.Rows[0]["idacc"] == DBNull.Value)
                return false;

            object idAcc = tAccmotivedetail.Rows[0]["idacc"];
            DataTable account_immob = Conn.RUN_SELECT("accountview", "*", null,
                QHS.AppAnd(QHS.CmpEq("idacc", idAcc), QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.BitSet("flagaccountusage", 8)), null, true);

            if (account_immob.Rows.Count > 0) {
                return true;
            }
            return false;
        }
        string CalculateFilterForLinkingAssetacquire(DataRow R) {
            //R = invoicedetail selezionata
            string filter_mandatedetail = QHS.AppAnd(QHS.MCmp(R, "idmankind", "yman", "nman"), QHS.CmpEq("rownum", R["manrownum"]));
            object idgroup_mandate = Conn.DO_READ_VALUE("mandatedetail", filter_mandatedetail, "idgroup");
          
            string MyFilter = QHS.AppAnd(QHS.MCmp(R, "idmankind", "yman", "nman"), QHS.CmpEq("rownum", idgroup_mandate));
            MyFilter = QHS.AppAnd(MyFilter, QHS.IsNull("idinvkind"));

            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpLe("number",R["number"]));// q.tà carico <= q.tà fattura
            MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("idupb", R["idupb"]));// q.tà carico <= q.tà fattura
            return MyFilter;
        }
        
        private bool verificaCondizioni(DataRow R) {
            //R = invoicedetail selezionata
            // Controlla che il dett.ordine abbia la causale di immobilizzazione e che sia collegato a Carico Cespite
            string filter_mandatedetail = QHS.AppAnd(QHS.MCmp(R, "idmankind", "yman", "nman"), QHS.CmpEq("rownum", R["manrownum"]));
            object idaccmotive = Conn.DO_READ_VALUE("mandatedetail", filter_mandatedetail, "idaccmotive");
            object idgroup_mandate = Conn.DO_READ_VALUE("mandatedetail", filter_mandatedetail, "idgroup");
            string filter_forAssetacquire = QHS.AppAnd(QHS.MCmp(R, "idmankind", "yman", "nman"), QHS.CmpEq("rownum", idgroup_mandate));
            if (ContoImmobilizzazione(idaccmotive) && CaricoCollegato(filter_forAssetacquire))
                return true;

            return false;
        }
        private void btnCollegaCarichiCespite_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            btnCollegaCarichiCespite.Focus();
            MetaData.GetFormData(this, true);
            if (DS.invoicedetail.Rows.Count == 0) return;
            
            DataRow selRowInvdet = HelpForm.GetLastSelected(DS.invoicedetail);
            if (selRowInvdet == null) return;
            //if (dettaglioGiàCollegatoACespite(selRowInvdet)) {
            //    show("Dettaglio già collegato", "Avviso");
            //    return;
            //}
            // Controlla che il dett.ordine abbia la causale di immobilizzazione e che sia collegato a Carico Cespite
            if (!verificaCondizioni(selRowInvdet)) {
                show("Non ci sono carichi da collegare", "Avviso");
                return;
            }
            string msg = "Questa operazione collega i carichi cespiti, e aggiorna imponibile e iva del carico leggendoli dalla fattura. Procedere?";
            DialogResult res = show(msg, "Conferma",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) {
                string MyFilter = CalculateFilterForLinkingAssetacquire(selRowInvdet);
                DataTable Carichi = Conn.RUN_SELECT("assetacquire", "*", null, MyFilter, null, false);
                if (Carichi.Rows.Count > 0) {
                    MetaData MRigaAssetacquire = MetaData.GetMetaData(this, "assetacquire");
                    MRigaAssetacquire.FilterLocked = true;
                    MRigaAssetacquire.DS = DS;
                    DataRow selRowCarico = MRigaAssetacquire.SelectOne("default", MyFilter, null, DS.assetacquire);
                    if (selRowCarico == null) return;
                    CollegaCarico(selRowInvdet, selRowCarico);
                }
                else {
                    show("Non ci sono carichi da collegare", "Avviso");
                }
            }
        }

        private void CollegaCarico(DataRow selRowInvdet, DataRow selRowCarico) {
            //selRowInvdet : riga invoicedetail selezionata
            // selRowCarico : riga assetacquire individuata per il collegamento
            string fdet = QHC.MCmp(selRowInvdet, "idinvkind", "yinv", "ninv", "idgroup");
            decimal taxable_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(taxable)", fdet));
            decimal unabatable_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(unabatable)", fdet));
            decimal tax_sum = CfgFn.GetNoNullDecimal(DS.invoicedetail.Compute("SUM(tax)", fdet));
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }

            tassocambio = RoundDecimal10(tassocambio);

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.assetacquire, null,
                QHC.CmpEq("nassetacquire", selRowCarico["nassetacquire"]), null, true);
            if (DS.assetacquire.Select(QHC.CmpEq("nassetacquire", selRowCarico["nassetacquire"])).Length == 0)
                return;
            DataRow R = DS.assetacquire.Select(QHC.CmpEq("nassetacquire", selRowCarico["nassetacquire"]))[0];
            //proporzionare l'iva alla q.tà del carico
            decimal qCarico = CfgFn.GetNoNullDecimal(selRowCarico["number"]);
            decimal qFattura = CfgFn.GetNoNullDecimal(selRowInvdet["number"]);

            R["idinvkind"] = selRowInvdet["idinvkind"];
            R["yinv"] = selRowInvdet["yinv"];
            R["ninv"] = selRowInvdet["ninv"];
            R["invrownum"] = selRowInvdet["idgroup"];

            if (qCarico == qFattura) {
                decimal aliquota = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("ivakind",
                    QHS.CmpEq("idivakind", selRowInvdet["idivakind"]), "rate"));
                R["taxrate"] = aliquota;
                R["discount"] = selRowInvdet["discount"];
                R["taxable"] = CfgFn.Round(taxable_sum * CfgFn.GetNoNullDecimal(tassocambio), 2);

                decimal unabatable = unabatable_sum;
                decimal tax = CfgFn.RoundValuta(tax_sum);
                decimal abatablerate = getAbatableRate(selRowInvdet["idinvkind"], selRowInvdet["yinv"]);
                decimal ivaDetraibile =
                    CfgFn.RoundValuta(CfgFn.RoundValuta((tax - unabatable)) * (decimal) abatablerate);

                R["tax"] = (tax / qFattura) * qCarico;
                R["abatable"] = (ivaDetraibile / qFattura) * qCarico;
            }


            show("Collegamento effettuato. E' necessario salvare affinchè le modifiche divengano operative.", "Avviso");

        }

        private void txtCambio_Leave(object sender, EventArgs e) {
            if (Meta.destroyed) return;
            if (Meta.IsEmpty) return;
            double tasso = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double), txtCambio.Text, txtCambio.Tag.ToString()));
            RicalcolaIvaDettagli(tasso);
        }

		private void btnCheck_Click(object sender, EventArgs e) {
            if (DS.invoice.Rows.Count == 0) {
                return;
            }

            if (!Meta.GetFormData(false)) return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show(this, "Per controllare i dati occorre prima SALVARE");
                return;
            }
            DataRow Curr = DS.invoice.Rows[0];
            DataTable tElectronicinvoicecheck = Meta.Conn.CallSP("exp_electronicinvoicecheck_estere", new object[] { Curr["yinv"], Curr["ninv"], Curr["idinvkind"] }, false).Tables[0];
            if (tElectronicinvoicecheck == null) {
                return;
            }
            if (tElectronicinvoicecheck.Rows.Count == 0) {
                show(this, "Non vi sono errori.");
                return;
            }

            exportclass.DataTableToExcel(tElectronicinvoicecheck, true);
        }
        const string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public static string IntToString(int value) {
            string result = "";
            int Base = baseChars.Length; //=62
            do {
                result = baseChars[value % Base] + result;
                value = value / Base;
            }
            while (value > 0);

            return result;
        }
        private string BuildNomeFileXml() {
            DataRow Curr = DS.invoice.Rows[0];
            string Progressivo = IntToString(CfgFn.GetNoNullInt32(Curr["yinv"]))
                + IntToString(CfgFn.GetNoNullInt32(Curr["ninv"]))
                + IntToString(CfgFn.GetNoNullInt32(Curr["idinvkind"]));
            string CFTrasmittente = Conn.DO_READ_VALUE("license", null, "cf").ToString();
            string NomeFileXml = "IT" + CFTrasmittente + "_" + Progressivo + ".xml";
            return NomeFileXml;
        }
        // VA RICHIAMATO QUANDO SI ABILITA IL TIPO DOCUMENTO TD016...020
        public void ImpostaIpaRifEmittente() {
            if (DS.invoice.Rows.Count == 0) {
                return;
            }
            if (FatturaElettronicaEstera() == "N") return;
            //object idinvkind = cboTipo.SelectedValue;
            //string filterreg = QHS.CmpEq("idinvkind", idinvkind);
            //DataRow invoiceKind = DS.invoicekind.First(filterreg);
            //if (invoiceKind["ipa_fe"].ToString() != "") {
            //    txtIpa_ven_emittente.Text = invoiceKind["ipa_fe"].ToString();
            //    grpIPAMittenteVendita.Enabled = false;
            //}
            //if (invoiceKind["riferimento_amministrazione"].ToString() != "") {
            //    txtRifamm_ven_emittente.Text = invoiceKind["riferimento_amministrazione"].ToString();
            //    grpRifAmmMittenteVendita.Enabled = false;
            //}

			DataRow Curr = DS.invoice.Rows[0];
            // Se agli attributi di sicurezza attuali corrisponde un solo ipa/rif amm, lo mettiamo in automatico come default e li rendiamo NON modificabili
            string myfilter = QHS.IsNotNull("idsor01");
            DataTable MyIpa = Conn.RUN_SELECT("ipa", "*", null, myfilter, null, false);
			Conn.DeleteAllUnselectable(MyIpa);
			if (MyIpa.Rows.Count == 1) {
				DataRow rI = MyIpa.Rows[0];
				txtIpa_ven_emittente.Text = rI["ipa_fe"].ToString();
				grpIPAMittenteVendita.Enabled = false;
				Curr["ipa_ven_emittente"] = rI["ipa_fe"];
			}
			else {
				grpIPAMittenteVendita.Enabled = true;
			}
			DataTable MySdi_rifamm = Conn.RUN_SELECT("sdi_rifamm", "*", null, myfilter, null, false);
			Conn.DeleteAllUnselectable(MySdi_rifamm);
			if (MySdi_rifamm.Rows.Count == 1) {
				DataRow rRA = MySdi_rifamm.Rows[0];
				txtRifamm_ven_emittente.Text = rRA["idsdi_rifamm"].ToString();
				grpRifAmmMittenteVendita.Enabled = false;
				Curr["rifamm_ven_emittente"] = rRA["idsdi_rifamm"];
			}
			else {
				grpRifAmmMittenteVendita.Enabled = true;
			}
		}
        private void btnInviaSdI_Click(object sender, EventArgs e) {
			if (Meta.destroyed) return;

			//Crea le righe in sdi_acquisto_estere 
            
			if (DS.invoice.Rows.Count == 0) {
				return;
			}

			if (!Meta.GetFormData(false))
				return;
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()) {
				show(this, "Per generare il file occorre prima SALVARE");
				return;
			}
			DataTable tElectronicinvoice = new DataTable();
			DataTable tElectronicinvoicedetail = new DataTable();
			DataTable tElectronicinvoiceriepilogo = new DataTable();
			DataTable tElectronicinvoiceAllegati = new DataTable();
			DataRow Curr = DS.invoice.Rows[0];
			Meta.dontClose = true;
			DataSet Out = Meta.Conn.CallSP("exp_electronicinvoice_estere", new object[] { Curr["yinv"], Curr["ninv"], Curr["idinvkind"] });
			if (Out == null) return;
			tElectronicinvoice = Out.Tables[0];
			if (tElectronicinvoice.Rows.Count == 0) {
				Meta.dontClose = false;
				show(this, "Non vi sono fatture da esportare.");
				return;
			}

			DataSet Out1 = Meta.Conn.CallSP("exp_electronicinvoicedetail_estere", new object[] { Curr["yinv"], Curr["ninv"], Curr["idinvkind"] });
			if (Out1 != null) tElectronicinvoicedetail = Out1.Tables[0]; else return;
			DataSet Out2 = Meta.Conn.CallSP("exp_electronicinvoiceriepilogo_estere", new object[] { Curr["yinv"], Curr["ninv"], Curr["idinvkind"] });
			if (Out2 != null) tElectronicinvoiceriepilogo = Out2.Tables[0]; else return;
			DataSet Out3 = Meta.Conn.CallSP("exp_electronicinvoiceallegati_estere", new object[] { Curr["yinv"], Curr["ninv"], Curr["idinvkind"] });
			if (Out3 != null) tElectronicinvoiceAllegati = Out3.Tables[0];

			Meta.dontClose = false;
			Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;
			DataRow R = tElectronicinvoice.Rows[0];

			string NomeFile = BuildNomeFileXml();

			MetaData Sdi_acquistoestere = MetaData.GetMetaData(this, "sdi_acquistoestere");
            Sdi_acquistoestere.SetDefaults(DS.sdi_acquistoestere);

			foreach (DataRow rFattura in tElectronicinvoice.Select()) {
                Sdi_acquistoestere.SetDefaults(DS.sdi_acquistoestere);
				DataRow rSdi_acquistoestere = Sdi_acquistoestere.Get_New_Row(null, DS.sdi_acquistoestere);
                rSdi_acquistoestere["position"] = 1;  //rFattura["position"];
											   //rSdi_acquistoestere["filename"] = NomeFile; //calcolato in automatico ora
				rSdi_acquistoestere["exported"] = "N";
				rSdi_acquistoestere["ipa_fe"] = rFattura["ipa_ven_emittente"];
				rSdi_acquistoestere["idsdi_rifamm"] = rFattura["rifamm_ven_emittente"];

				string filterInvoice = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]), QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
				DataRow rInvoice = DS.invoice.Select(filterInvoice)[0];
				rInvoice["idsdi_acquistoestere"] = rSdi_acquistoestere["idsdi_acquistoestere"];

				StringWriter sw = new StringWriter();
				writersdi = new XmlTextWriter(sw);
				writersdi.Formatting = Formatting.Indented;

				writersdi.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' ");
				//I.ipa_ven_cliente as 'CodiceDestinatario',
				//I.rifamm_ven_cliente as 'RiferimentoAmministrazione',
				bool isPA = rFattura["CodiceDestinatario"].ToString().Length == 6;



				string versione = isPA ? "FPA12" : "FPR12"; //FPA12
				string formatotrasmissione = versione;

				writersdi.WriteStartElement("p:FatturaElettronica");
				writersdi.WriteAttributeString("versione", versione);
				writersdi.WriteAttributeString("xmlns", "ds", null, "http://www.w3.org/2000/09/xmldsig#");
				writersdi.WriteAttributeString("xmlns", "p", null, "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");
				writersdi.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");

				writersdi.WriteStartElement("FatturaElettronicaHeader"); //apre <FatturaElettronicaHeader>
				writersdi.WriteStartElement("DatiTrasmissione"); //Apre <DatiTrasmissione>
				writersdi.WriteStartElement("IdTrasmittente");// apre <IdTrasmittente>
				writersdi.WriteElementString("IdPaese", "IT");
				writersdi.WriteElementString("IdCodice", format(R["IdTrasmittenteCodice"]));
				writersdi.WriteEndElement();// chiude <IdTrasmittente>
				writersdi.WriteElementString("ProgressivoInvio", getLatin1(R["ProgressivoInvio"]));
				writersdi.WriteElementString("FormatoTrasmissione", formatotrasmissione); ///era SDI11
				writersdi.WriteElementString("CodiceDestinatario", getAZ09(R["CodiceDestinatario"]));
				//1.1.5 < ContattiTrasmittente > Dati relativi ai contatti del trasmittente
				//1.1.5.1 < Telefono > xs:normalizedString Contatto telefonico fisso o mobile
				//1.1.5.2 < Email > xs:string   Indirizzo di posta elettronica
				//if (R["email_ven_cliente"]!=DBNull.Value) {
				//    writersdi.WriteStartElement("ContattiTrasmittente"); //Apre <ContattiTrasmittente>
				//    writersdi.WriteElementString("Email", getAZ09(R["email_ven_cliente"]));
				//    writersdi.WriteEndElement();// chiude <ContattiTrasmittente>
				//}

				if (rFattura["CodiceDestinatario"].ToString() == "0000000" && R["pec_ven_cliente"] != DBNull.Value) {
					writersdi.WriteElementString("PECDestinatario", R["pec_ven_cliente"].ToString());
				}

				writersdi.WriteEndElement();// chiude <DatiTrasmissione>
				writersdi.WriteStartElement("CedentePrestatore"); //Apre <CedentePrestatore>
				writersdi.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
				writersdi.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
                writersdi.WriteElementString("IdPaese", getAZ(R["IdFiscaleIvaPaeseFornitore"])); 

                writersdi.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceFornitore"]));
				writersdi.WriteEndElement();// chiude <IdFiscaleIVA>
				//writersdi.WriteElementString("CodiceFiscale", getAZ09(R["IdTrasmittenteCodice"]));
				writersdi.WriteStartElement("Anagrafica");// apre <Anagrafica>
				writersdi.WriteElementString("Denominazione", getLatin1(R["DenominazioneFornitore"]));
                writersdi.WriteElementString("Nome", getAZ(R["NomeFornitore"]));
                writersdi.WriteElementString("Cognome", getAZ(R["CognomeFornitore"]));

                writersdi.WriteEndElement();// chiude <Anagrafica>
				writersdi.WriteElementString("RegimeFiscale", format(R["RegimeFiscale"]));
				writersdi.WriteEndElement();// chiude <DatiAnagrafici>
				writersdi.WriteStartElement("Sede"); //Apre <Sede>
				writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoFornitore"]));
				writersdi.WriteElementString("CAP", getdigit09(R["capFornitore"]));
				writersdi.WriteElementString("Comune", getLatin1(R["comuneFornitore"]));
				writersdi.WriteElementString("Provincia", getAZ(R["provinciaFornitore"]));
				writersdi.WriteElementString("Nazione", getAZ(R["nazioneFornitore"]));
                writersdi.WriteEndElement();// chiude <Sede>
											//		1.4.3 < StabileOrganizzazione > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente non residente e con stabile organizzazione in Italia
											//	1.4.3.1 < Indirizzo > xs:normalizedString Indirizzo della sede del cessionario / committente(nome della via, piazza etc.)
											//	1.4.3.2 < NumeroCivico > xs:normalizedString Numero civico riferito all'indirizzo (non indicare se già presente nell'elemento informativo indirizzo)
											//	1.4.3.3 < CAP > xs:string   Codice Avviamento Postale
											//	1.4.3.4 < Comune > xs:normalizedString Comune relativo alla stabile organizzazione in Italia
											//	1.4.3.5 < Provincia > xs:string   Sigla della provincia di appartenenza del comune indicato nell'elemento informativo 1.4.3.4 <Comune>. Da valorizzare se l'elemento informativo 1.4,3.6 < Nazione > è uguale a IT
											//	1.4.3.6 < Nazione > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
				if ((versione == "FPR12") && (R["indirizzoStabileOrg"] != DBNull.Value)) {
					writersdi.WriteStartElement("StabileOrganizzazione"); //Apre <StabileOrganizzazione>
					writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoStabileOrg"]));
					writersdi.WriteElementString("CAP", getdigit09(R["capStabileOrg"]));
					writersdi.WriteElementString("Comune", getLatin1(R["comuneStabileOrg"]));
					writersdi.WriteElementString("Provincia", getAZ(R["provinciaStabileOrg"]));
					writersdi.WriteElementString("Nazione", getAZ(R["nazioneStabileOrg"]));
					writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
				}
                //PER LE FATTURE DI ACQSUITO ESTERE NON HA SENSO QUESTO CAMPO
				//if ((R["rea_number"] != DBNull.Value)) {
				//	writersdi.WriteStartElement("IscrizioneREA"); //Apre <IscrizioneREA>
				//	writersdi.WriteElementString("Ufficio", getAZ(R["rea_provinceoffice"]));
				//	writersdi.WriteElementString("NumeroREA", getLatin1(R["rea_number"]));
				//	if (format(R["rea_socialcapital"]) != "") {
				//		writersdi.WriteElementString("CapitaleSociale", format(R["rea_socialcapital"]));
				//	}
				//	if (getLatin1(R["rea_partner"]) != "") {
				//		writersdi.WriteElementString("SocioUnico", getLatin1(R["rea_partner"]));
				//	}
				//	writersdi.WriteElementString("StatoLiquidazione", getLatin1(R["rea_closingstatus"]));
				//	writersdi.WriteEndElement();// chiude <IscrizioneREA>
				//}

				//1.4.4 < RappresentanteFiscale > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia
				//	1.4.4.1 < IdFiscaleIVA > Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese(IT, DE, ES …..) ed i restanti(fino ad un massimo di 28) il codice vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
				//		1.4.4.1.1 < IdPaese > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
				//		1.4.4.1.2 < IdCodice > xs:string   Codice identificativo fiscale
				//		1.4.4.2 < Denominazione > (campo assente nella scheda indirizzi dell'anagrafica)				
				//		1.4.4.3 < Nome > (campo assente nella scheda indirizzi dell'anagrafica)			
				//		1.4.4.4 < Cognome > (campo assente nella scheda indirizzi dell'anagrafica)
				if ((versione == "FPR12") && (R["IdPaeseRappresentante"] != DBNull.Value)) {
					writersdi.WriteStartElement("RappresentanteFiscale"); //Apre <StabileOrganizzazione>
					writersdi.WriteElementString("IdPaese", getAZ(R["IdPaeseRappresentante"]));
					writersdi.WriteElementString("IdCodice", getAZ(R["IdCodiceRappresentante"]));
					writersdi.WriteElementString("Denominazione", getAZ(R["DenominazioneRappresentante"]));
					writersdi.WriteElementString("Nome", getAZ(R["NomeRappresentante"]));
					writersdi.WriteElementString("Cognome", getAZ(R["CognomeRappresentante"]));
					writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
				}
				//if (R["RiferimentoAmministrazione"].ToString() != "") {
				//	writersdi.WriteElementString("RiferimentoAmministrazione", getLatin1(R["RiferimentoAmministrazione"]));
				//}
				writersdi.WriteEndElement();// chiude <CedentePrestatore>

				writersdi.WriteStartElement("CessionarioCommittente"); //Apre <CessionarioCommittente>
				writersdi.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
				if (R["IdFiscaleIvaCodiceDip"].ToString() != "") {
					writersdi.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
					writersdi.WriteElementString("IdPaese", getAZ(R["IdFiscaleIvaPaeseDip"]));
					writersdi.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceDip"]));
					writersdi.WriteEndElement();// chiude <IdFiscaleIVA>
				}
				if (R["IdTrasmittenteCodice"].ToString() != "") {
					writersdi.WriteElementString("CodiceFiscale", getAZ09(R["IdTrasmittenteCodice"]));
				}
				writersdi.WriteStartElement("Anagrafica");// apre <Anagrafica>
				if (R["DenominazioneDip"].ToString() != "") {
					writersdi.WriteElementString("Denominazione", getLatin1(R["DenominazioneDip"]));
				}

				writersdi.WriteEndElement();// chiude <Anagrafica>
				writersdi.WriteEndElement();// chiude <DatiAnagrafici>
				writersdi.WriteStartElement("Sede"); //Apre <Sede>
				writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoDip"]));
				writersdi.WriteElementString("CAP", getdigit09(R["capDip"]));
				writersdi.WriteElementString("Comune", getLatin1(R["comuneDip"]));
				writersdi.WriteElementString("Provincia", getAZ(R["provinciaDip"]));
				writersdi.WriteElementString("Nazione", getAZ(R["nazioneDip"]));
				writersdi.WriteEndElement();// chiude <Sede>
				writersdi.WriteEndElement();// chiude <CessionarioCommittente>

				writersdi.WriteEndElement();// Chiude -  <FatturaElettronicaHeader>
											//            foreach (DataRow rFattura in tElectronicinvoice.Select()) {//Spostato sopra
				writersdi.WriteStartElement("FatturaElettronicaBody"); //Apre <FatturaElettronicaBody>
				writersdi.WriteStartElement("DatiGenerali"); //Apre <DatiGenerali>
				writersdi.WriteStartElement("DatiGeneraliDocumento"); //Apre <DatiGeneraliDocumento>
				writersdi.WriteElementString("TipoDocumento", format(rFattura["TipoDocumento"]));
				writersdi.WriteElementString("Divisa", getAZ(rFattura["divisa"]));
				writersdi.WriteElementString("Data", format(rFattura["data"]));
				writersdi.WriteElementString("Numero", getLatin1(rFattura["numero"]));

                //PER LE FATTURE DI ACQSUITO ESTERE NON HA SENSO QUESTO CAMPO
                //if (tElectronicinvoice.Columns.Contains("idstampkind") && rFattura["idstampkind"].ToString().ToUpper() == "DM19_2014") {
                //	writersdi.WriteStartElement("DatiBollo"); //Apre <DatiBollo>
                //											  //writersdi.WriteElementString("NumeroBollo", format("DM-17-GIU-2014"));
                //	writersdi.WriteElementString("BolloVirtuale", format("SI"));
                //	decimal impBollo = 2;
                //	writersdi.WriteElementString("ImportoBollo", format(impBollo));
                //	writersdi.WriteEndElement();// Chiude -  <DatiBollo>
                //}

                if (rFattura["tipoScontoMaggiorazione"].ToString() != "") {
					writersdi.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
					writersdi.WriteElementString("Tipo", format(rFattura["tipoScontoMaggiorazione"]));
					writersdi.WriteElementString("Importo", format(Math.Abs(CfgFn.GetNoNullDecimal(rFattura["sconto"]))));
					writersdi.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
				}
				writersdi.WriteElementString("ImportoTotaleDocumento", format(rFattura["ImportoTotaleDocumento"]));
				writersdi.WriteElementString("Causale", getLatin1(rFattura["causale"]));
				writersdi.WriteEndElement();// Chiude -  <DatiGeneraliDocumento>
				string filterOrdineAcquisto = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]),
					QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]), QHC.IsNotNull("IdDocumento"));

				//"IdDocumento" viene valorizzato solo se c'è il collegamento al C.A. ed è stato indicato il cig o il cup nel dettaglio fattura.


				foreach (DataRow rDetail in tElectronicinvoicedetail.Select(filterOrdineAcquisto)) {
					writersdi.WriteStartElement("DatiOrdineAcquisto");//Apre - <DatiOrdineAcquisto>
					writersdi.WriteElementString("RiferimentoNumeroLinea", format(rDetail["RiferimentoNumeroLinea"]));
					writersdi.WriteElementString("IdDocumento", getLatin1(rDetail["IdDocumento"]));
					if (rDetail["DataDocumentoCollegato"].ToString() != "") {
						writersdi.WriteElementString("Data", format(rDetail["DataDocumentoCollegato"]));
					}
					if (rDetail["NumItem"].ToString() != "") {
						writersdi.WriteElementString("NumItem", getLatin1(rDetail["NumItem"]));
					}
					if (rDetail["CodiceCUP"].ToString() != "") {
						writersdi.WriteElementString("CodiceCUP", getLatin1(rDetail["CodiceCUP"]));
					}
					if (rDetail["CodiceCIG"].ToString() != "") {
						writersdi.WriteElementString("CodiceCIG", getLatin1(rDetail["CodiceCIG"]));
					}
					writersdi.WriteEndElement();// Chiude -  <DatiOrdineAcquisto>
				}
				if (rFattura["tipofattura"].ToString() == "V") {// Se è una Nota di Credito
					writersdi.WriteStartElement("DatiFattureCollegate");
					writersdi.WriteElementString("IdDocumento", getLatin1(rFattura["IdDocumentoFatturaMadre"]));
					writersdi.WriteElementString("Data", format(rFattura["DataFatturaMadre"]));
					writersdi.WriteEndElement();// Chiude -  <DatiFattureCollegate>
				}


				writersdi.WriteEndElement();// Chiude -  <DatiGenerali>

				writersdi.WriteStartElement("DatiBeniServizi"); //Apre <DatiBeniServizi>
				string filterDoc = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]), QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
				foreach (DataRow rDettFattura in tElectronicinvoicedetail.Select(filterDoc)) {
					writersdi.WriteStartElement("DettaglioLinee"); //Apre <DettaglioLinee>
					writersdi.WriteElementString("NumeroLinea", format(rDettFattura["NumeroLinea"]));
					if (rDettFattura["TipoCessionePrestazione"].ToString() != "") {
						writersdi.WriteElementString("TipoCessionePrestazione", format(rDettFattura["TipoCessionePrestazione"]));
					}
					if (rDettFattura["CodiceTipo"] != DBNull.Value) {
						writersdi.WriteStartElement("CodiceArticolo"); //Apre <CodiceArticolo>
						writersdi.WriteElementString("CodiceTipo", format(rDettFattura["CodiceTipo"]));
						writersdi.WriteElementString("CodiceValore", format(rDettFattura["CodiceValore"]));
						writersdi.WriteEndElement();//chiude  CodiceArticolo
					}
					writersdi.WriteElementString("Descrizione", getLatin1(rDettFattura["Descrizione"]).TrimEnd());
					writersdi.WriteElementString("Quantita", format(rDettFattura["quantita"]));
					decimal prezzoUnitario = CfgFn.GetNoNullDecimal(rDettFattura["PrezzoUnitario"]);
					writersdi.WriteElementString("PrezzoUnitario", SecurityElement.Escape(FormatDecimalN(prezzoUnitario, 6)));
					if (rDettFattura["tipoScontoMaggiorazioneDettaglio"].ToString() != "") {
						writersdi.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
						writersdi.WriteElementString("Tipo", format(rDettFattura["tipoScontoMaggiorazioneDettaglio"]));
						writersdi.WriteElementString("Percentuale", FormatDecimalN(Math.Abs(CfgFn.GetNoNullDecimal(rDettFattura["scontoDettaglio"])), 2));
						writersdi.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
					}
					writersdi.WriteElementString("PrezzoTotale", format(rDettFattura["PrezzoTotale"]));
					writersdi.WriteElementString("AliquotaIVA", format(rDettFattura["AliquotaIVA"]));
					if (rDettFattura["Natura"].ToString() != "") {
						writersdi.WriteElementString("Natura", format(rDettFattura["Natura"]));
					}
					writersdi.WriteEndElement();// Chiude -  <DettaglioLinee>
				}// chiusura foreach sui dettagli fattura

				foreach (DataRow rRiepilogo in tElectronicinvoiceriepilogo.Select(filterDoc)) {
					writersdi.WriteStartElement("DatiRiepilogo");//Apre - <DatiRiepilogo>
					writersdi.WriteElementString("AliquotaIVA", format(rRiepilogo["AliquotaIVA"]));
					if (rRiepilogo["Natura"].ToString() != "") {
						writersdi.WriteElementString("Natura", format(rRiepilogo["Natura"]));
					}
					writersdi.WriteElementString("ImponibileImporto", format(rRiepilogo["ImponibileImporto"]));
					writersdi.WriteElementString("Imposta", format(rRiepilogo["Imposta"]));
					writersdi.WriteElementString("EsigibilitaIVA", format(rRiepilogo["EsigibilitaIVA"]));
					if (rRiepilogo["RiferimentoNormativo"].ToString() != "") {
						writersdi.WriteElementString("RiferimentoNormativo", getLatin1(rRiepilogo["RiferimentoNormativo"]));
					}
					writersdi.WriteEndElement();// Chiude -  <DatiRiepilogo>
				}



				writersdi.WriteEndElement();// Chiude -  <DatiBeniServizi>

                //PER LE FATTURE DI ACQSUITO ESTERE NON HA SENSO QUESTO CAMPO
				//if (rFattura["tipofattura"].ToString() == "F") {// Solo se Fattura inseriamo il blocco DatiPagamento
				//	writersdi.WriteStartElement("DatiPagamento");//Apre - <DatiPagamento>
				//	writersdi.WriteElementString("CondizioniPagamento", format(rFattura["CondizioniPagamento"]));

				//	writersdi.WriteStartElement("DettaglioPagamento");
				//	if (rFattura["ModalitaPagamento"].ToString().ToString() != "") {
				//		writersdi.WriteElementString("ModalitaPagamento", format(rFattura["ModalitaPagamento"]));
				//	}
				//	//Data registrazione, usata anche prima    
				//	writersdi.WriteElementString("DataRiferimentoTerminiPagamento", format(rFattura["data"]));
				//	if (rFattura["idexpirationkind"].ToString() != "") {
				//		DateTime DataScadenzaPagamento = CalcolaDataScadenza(rFattura["idexpirationkind"], rFattura["paymentexpiring"], rFattura["data"], rFattura["datadocumento"]);
				//		int GiorniTerminiPagamento = CalcolaGiorniTerminiPagamento(rFattura["data"], DataScadenzaPagamento);
				//		writersdi.WriteElementString("GiorniTerminiPagamento", GiorniTerminiPagamento.ToString());
				//		writersdi.WriteElementString("DataScadenzaPagamento", FormatData(DataScadenzaPagamento));
				//	}
				//	writersdi.WriteElementString("ImportoPagamento", format(rFattura["ImportoPagamento"]));
				//	if (rFattura["IBAN"].ToString() != "") {
				//		writersdi.WriteElementString("IBAN", format(rFattura["IBAN"]));
				//	}
				//	if (rFattura["CodicePagamento"].ToString() != "") {
				//		writersdi.WriteElementString("CodicePagamento", format(rFattura["CodicePagamento"]));
				//	}
				//	writersdi.WriteEndElement();// Chiude -  <DettaglioPagamento>

				//	writersdi.WriteEndElement();// Chiude -  <DatiPagamento>

				//}
				if (tElectronicinvoiceAllegati.Rows.Count > 0) {
					foreach (DataRow rAllegato in tElectronicinvoiceAllegati.Select(filterDoc)) {
						writersdi.WriteStartElement("Allegati");//Apre - <Allegati>                        
						writersdi.WriteElementString("NomeAttachment", getLatin1(rAllegato["filename"]));
						writersdi.WriteElementString("Attachment", format(rAllegato["attachment"]));
						writersdi.WriteEndElement();// Chiude -  <Allegati>
					}
				}
				writersdi.WriteEndElement();// Chiude -  <FatturaElettronicaBody>

				writersdi.WriteEndElement();//chiudep:Fattura
				writersdi.Close();

				string xmlString = sw.ToString();
				rSdi_acquistoestere["xml"] = xmlString;

				Meta.SaveFormData();
				Stream s = GenerateStreamFromString(xmlString);
                ApriFormFE();
                grpMittenteVendita.Enabled = false;
                grpFEAcquistoEstere.Enabled = false;
                //ValidaXML_conXSD(s);
            }// foreach in TElectronicinvoice
		}// Fine 

        void ApriFormFE() {
                if (DS.sdi_acquistoestere.Rows.Count == 0) return;
                MetaData ToMeta = Meta.Dispatcher.Get("sdi_acquistoestere");
                if (ToMeta == null) return;
            object idsdi_acquistoestere = DS.invoice.Rows[0]["idsdi_acquistoestere"];
            if ((idsdi_acquistoestere == null)|| (idsdi_acquistoestere == DBNull.Value))
                return;

                string checkfilter = QHS.CmpEq("idsdi_acquistoestere", idsdi_acquistoestere);
                ToMeta.ContextFilter = checkfilter;
                Form F = null;
                if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
                bool result = ToMeta.Edit(F, "default", false);
                string listtype = ToMeta.DefaultListType;
                DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
                if (R != null) ToMeta.SelectRow(R, listtype);
            
        }
        public Stream GenerateStreamFromString(string s) {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        string FormatDecimalN(Decimal d, int N) {
            return d.ToString("F" + N, CultureInfo.InvariantCulture);
        }
        private string aggiustaStringa(string stringa, bool toglichiocciola) {

            string s = stringa.Replace('’', ' ').Replace('´', ' ').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
            if (toglichiocciola)
                s = s.Replace('@', ' ');
            return s;
        }

        string getAZ09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string getAZ(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }

        string getLatin1(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false);
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] < 32) {
                    continue;
                }
                if (b[i] >= 128) {
                    continue;
                }
                res += Encoding.ASCII.GetString(new byte[] { b[i] });
            }
            return res;
        }
        string FormatData(DateTime Data) {
            return Data.Year.ToString() + "-" + Data.Month.ToString().PadLeft(2, '0') + "-" + Data.Day.ToString().PadLeft(2, '0');
        }
        string FormatDecimal(Decimal d) {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }
        string getdigit09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string format(object o) {

            if (o == null || o == DBNull.Value) return "";
            if (o.GetType() == typeof(DateTime)) return SecurityElement.Escape(FormatData((DateTime)o));
            if (o.GetType() == typeof(Decimal)) return SecurityElement.Escape(FormatDecimal((Decimal)o));
            if (o.GetType().ToString() == "System.Byte[]") return Convert.ToBase64String((byte[])o,
                                Base64FormattingOptions.InsertLineBreaks);
            string res = SecurityElement.Escape(o.ToString());
            if (res != null) {
                res = res.Replace("\"", "&quot;").Replace("'", "&apos;");
            }
            return res;
        }
        //private void btnInviaSdI_Click(object sender, EventArgs e) {

        //}

        //private void btnInviaSdI_Click_1(object sender, EventArgs e) {

        //}

    }

}
