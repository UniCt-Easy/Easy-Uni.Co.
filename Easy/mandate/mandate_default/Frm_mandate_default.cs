
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione
using System.Data.OleDb;
using ep_functions;
using manage_var;
using manage_epexpvar;
using System.Collections.Generic;
using meta_mandatedetail;
using q = metadatalibrary.MetaExpression;
using System.Linq;
using System.Globalization;
using AskCurrencyExchange;
using CurrencyManager;

namespace mandate_default { //ordinegenerico//
    /// <summary>
    /// Summary description for frmordinegenerico.
    /// </summary>
    public class Frm_mandate_default : MetaDataForm {
        private System.Windows.Forms.GroupBox gboxContratto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercOrdine;
        private System.Windows.Forms.TextBox txtNumOrdine;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCredDeb;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtTermConsegna;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIndirizzoConsegna;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRiferminento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbTipoScadenza;
        public dsmeta DS;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtTotale;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSituazione;
        private MetaData Meta;
        private System.Windows.Forms.DataGrid detailgrid;
        private DataRow Current;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkCont;
        private System.Windows.Forms.ComboBox cmbTipoOrdine;
        private System.Windows.Forms.Button btnTipoOrdine;
        private System.Windows.Forms.GroupBox gboxValuta;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDataContabile;
        private DataAccess Conn;
        private System.Windows.Forms.TabPage Principale;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Classificazioni;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndModifica;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.DataGrid dgrClassificazioni;
        private System.Windows.Forms.Button btnDividiDettaglio;
        private TabPage tabEP;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private Button btnUnisciDettagli;
        private CQueryHelper QHC;
        private QueryHelper QHS;
        private Label labAltroEsercizio;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private Button btnSostituisciDettaglio;
        private Label label43;
        private TextBox textBox3;
        private GroupBox gBoxCausaleDebitoAggiornata;
        private TextBox textBox4;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox gBoxCausaleDebito;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private TextBox txtApplierAnnotations;
        private Label label5;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private GroupBox gBoxMagazzino;
        private Button btnMagazzino;
        private TabPage tabMagazzino;
        private Label label33;
        private DataGrid gridStock;


        private bool DoSendMail;
        private int CurrentStatus;
        private Button btnAccetta;
        private Button btnintegra;
        private Button btnApprova;
        private Button btnAnnullaApprova;
        private GroupBox gboxAction;
        private ToolTip toolTip1;
        private GroupBox gboxtipofattura;
        private RadioButton rdbextracom;
        private RadioButton rdbintracom;
        private RadioButton rdbitalia;
        private Button btnAnnulla;
        private Label lblcig;
        private TextBox txtcig;
        private TabPage tabAllegati;
        private DataGrid dataGrid1;
        private Button btnDelAtt;
        private Button btnEditAtt;
        private Button btnInsAtt;
        private TabPage tabAttributi;
        private TabPage tabConsip;
        private CheckBox checkBox1;
        private TabPage tabDettagli;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
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
        public TextBox txtValuta;
        private Button button2;
        public TextBox txtStore;
        private Button btnInserisciCopia;
        private Button btnGeneraPreimpegni;
        private Button btnVisualizzaPreimpegni;
        private Button btnLottiAppaltati;
        private Button btnLottiPartecipati;
        private Button btnPartecipantiAlLotto;
        private TabPage tabAnac;
        private Label label13;
        private DataGrid gridLotti;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button btnAggiungiAggiudicatario;
        private Button btnOrdiniNoPartecipanti;
        private Button btnOrdiniNoLotti;
        private Button btnPartecipantiNonAssociati;
        private TabPage tabAltro;
        private GroupBox groupBox1;
        private TextBox textBox5;
        private Label label21;
        private Label label20;
        private TextBox textBox6;
        private TextBox textBox2;
        private Label label19;
        private TabPage tabRegistroUnico;
        private GroupBox grpRegistroUnico;
        private Label label85;
        private TextBox txDataRicezioneRU;
        private TextBox txtProgressivoRU;
        private Label label82;
        private Label label83;
        private TextBox txtProtocolloEntrataRU;
        private TextBox txtAnnotazioniRU;
        private Label label84;
        private Label label42;
        private TextBox txtDataScadenza;
        private Button btnCreaRegistroUnico;
        private CheckBox chkSendPCC;
        private Label label46;
        private DataGrid dgrPCC;
        private Button btnRipartizione;
        private Label label22;
        private TextBox textBox7;
        private BindingSource consipkindBindingSource;
        private BindingSource mandatedetailBindingSource;
        private Button btnConsipkind;
        private TextBox txtConsipMotive1;
        private ComboBox cmbConsip1;
        private ComboBox cmbConsip2;
        private Label labelConsipExt;
        private Label mainLabelConsip;
        private Button btnImportFromExcel;
        private IContainer components;


        private System.Windows.Forms.OpenFileDialog _MyOpenFile;
        private IOpenFileDialog MyOpenFile;
        private System.Windows.Forms.ProgressBar progressBarImport;
        private System.Windows.Forms.ContextMenu CMenu;
        private System.Windows.Forms.MenuItem MenuEnterPwd;
        private GroupBox grpEsitoGara;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private TextBox textBox8;
        private Label label23;
        private GroupBox grpRUP;
        private TextBox txtRUP;
        private TextBox txtRibasso;
        private Label label24;
        private Button btnRimpiazzaPerNuovoProrata;
        private TabControl tabControlAnac;
        private TabPage tabLotti;
        private TabPage tabPartecipanti;
        private Label label7;
        private DataGrid gridAVCP;
        private Button btnDelAVCP;
        private Button btnEditAVCP;
        private Button btnInsAVCP;
        private TabPage tabEsito;
        private GroupBox groupBox7;
        private TextBox textBox9;
        private GroupBox groupBox6;
        private RadioButton radioButton7;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private GroupBox groupBox8;
        private RadioButton radioButton11;
        private RadioButton radioButton10;
        private RadioButton radioButton9;
        private RadioButton radioButton8;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkDurc;
        private CheckBox chkVisura;
        private CheckBox chkCCdedicato;
        private CheckBox chkRecuperoIvaIntraExtra;
        private GroupBox grpDettagliAnnullati;
        private DataGrid dataGridDettAnn;
        private Button btnAnnullaDettaglio;
		private CheckBox chkVerificaAnac;
		private CheckBox chkRegolaritaFiscale;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkCasellarioGiud;
		private Button button10;
		private Button button9;
		private Button button8;
		private Button button1;
		private Button btnImportaGara;
        private Button btnCurrencyExchange;
        string ConnectionString;
		private CheckBox chkPattoIntegrita;
		private Manager currencyManager;

        public Frm_mandate_default() {
            InitializeComponent();

            HelpForm.SetDenyNull(DS.mandate.Columns["active"], true);
            HelpForm.SetDenyNull(DS.mandate.Columns["flagdanger"], true);
            DataAccess.SetTableForReading(DS.upb_detail, "upb");
            DataAccess.SetTableForReading(DS.registrymainview_rup, "registrymainview");



            DS.mandatesorting.ExtendedProperties["ViewTable"] = DS.mandatesortingview;
            DS.sortingview.ExtendedProperties["ViewTable"] = DS.mandatesortingview;
            DS.mandatesortingview.ExtendedProperties["RealTable"] = DS.mandatesorting;

            foreach (DataColumn C in DS.mandatesorting.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.mandatesortingview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "mandatesorting." +
                                                                                               C.ColumnName;
            }

            DS.mandatesortingview.Columns["sortingkind"].ExtendedProperties["ViewSource"] = "sortingview.sortingkind";
            DS.mandatesortingview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sortingview.sortcode";
            DS.mandatesortingview.Columns["sorting"].ExtendedProperties["ViewSource"] = "sortingview.description";



            DS.mandatedetail.ExtendedProperties["ViewTable"] = DS.mandatedetailview;
            DS.registry.ExtendedProperties["ViewTable"] = DS.mandatedetailview;
            DS.ivakind.ExtendedProperties["ViewTable"] = DS.mandatedetailview;
            DS.upb_detail.ExtendedProperties["ViewTable"] = DS.mandatedetailview;
            DS.mandatedetailview.ExtendedProperties["RealTable"] = DS.mandatedetail;

            foreach (DataColumn C in DS.mandatedetail.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.mandatedetailview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "mandatedetail." +
                                                                                              C.ColumnName;
            }

            DS.mandatedetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb_detail.codeupb";
            DS.mandatedetailview.Columns["ivakind"].ExtendedProperties["ViewSource"] = "ivakind.description";
            DS.mandatedetailview.Columns["registry"].ExtendedProperties["ViewSource"] = "registry.title";
            btnImportFromExcel.ContextMenu = CMenu;
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

            int ngiorni = CfgFn.GetNoNullInt32(txtScadenza.Text);
            DateTime dataRegistrazione = DateTime.MinValue;
            if (txtDataContabile.Text != "") {
                object t = HelpForm.GetObjectFromString(typeof(DateTime), txtDataContabile.Text,
                    txtDataContabile.Tag.ToString());
                if (t != DBNull.Value && t != null) dataRegistrazione = (DateTime) t;
            }

            DateTime dataDocumento = DateTime.MinValue;
            if (txtDataDoc.Text != "") {
                object t = HelpForm.GetObjectFromString(typeof(DateTime), txtDataDoc.Text, txtDataDoc.Tag.ToString());
                if (t != DBNull.Value && t != null) dataDocumento = (DateTime) t;
            }

            DateTime dataRicezione = DateTime.MinValue;
            if (txDataRicezioneRU.Text != "") {
                object t = HelpForm.GetObjectFromString(typeof(DateTime), txDataRicezioneRU.Text,
                    txDataRicezioneRU.Tag.ToString());
                if (t != DBNull.Value && t != null) dataRicezione = (DateTime) t;
            }

            DateTime dataScadenza = DateTime.MinValue;
            //  1	Data contabile = data registrazione
            //  2	Data documento
            //  3	Fine mese data documento
            //  4	Fine mese data contabile
            //  5	Pagamento Immediato
            //  6   Data ricezione

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) > 0) {
                dataScadenza = dataRegistrazione.AddDays(ngiorni);
            }

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) == 0) {
                dataScadenza = dataRegistrazione;
            }

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(ngiorni) > 0 && txtDataDoc.Text != "") {
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

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) > 0 &&
                txDataRicezioneRU.Text != "") {
                dataScadenza = dataRicezione.AddDays(ngiorni);
            }

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) == 0 &&
                txDataRicezioneRU.Text != "") {
                dataScadenza = dataRicezione;
            }

            txtDataScadenza.Text = dataScadenza == DateTime.MinValue
                ? null
                : HelpForm.StringValue(dataScadenza, txtDataScadenza.Tag.ToString());
        }

        public void MetaData_AfterGetFormData() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.mandate.Rows[0];
            if (Meta.InsertMode) {

                foreach (DataRow Child in DS.mandatedetail.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];



                }

                foreach (DataRow Child in DS.mandateavcp.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }

                foreach (DataRow Child in DS.mandateavcpdetail.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }

                foreach (DataRow Child in DS.mandatecig.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }

                foreach (DataRow Child in DS.mandateattachment.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }

                foreach (DataRow Child in DS.mandatesorting.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }

                foreach (DataRow Child in DS.uniqueregister.Select()) {
                    Child["yman"] = Curr["yman"];
                    Child["nman"] = Curr["nman"];
                    Child["idmankind"] = Curr["idmankind"];
                }
            }


            DataRow[] contrattoParent = DS.mandatekind.Select(QHC.CmpEq("idmankind", Curr["idmankind"]));
            if (contrattoParent.Length > 0) {
                DataRow TipoContratto = contrattoParent[0];

                if (TipoContratto["multireg"].ToString().ToUpper() == "N") {
                    foreach (DataRow Child in DS.mandatedetail.Select()) {
                        Child["idreg"] = Curr["idreg"];
                    }
                }

                //else {     //commento perchè non ricordo se per convenzione ci va cmq il capogruppo avcp
                //    Curr["idreg"] = DBNull.Value;
                //}
            }

            ImpostaTxtValuta();


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



        bool Consip2Disabilitato = false;

        private EP_Manager EPM;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            currencyManager = new Manager(Meta.Conn, new Uri("https://tassidicambio.bancaditalia.it/terzevalute-wf-web/rest/v1.0/"), 1, 1, ReferenceCurrency.EUR, "Easy");

            // addColumnExcel(mData);
            AccMotiveManager AM = new AccMotiveManager(gBoxCausaleDebito);
            //AccMotiveManager AM01 = new AccMotiveManager(gBoxCausaleDebitoAggiornata);
            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP,

                labEP, labAltroEsercizio, "mandate");

            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            GetData.CacheTable(DS.consipkind, null, "position", true);
            GetData.CacheTable(DS.consipkind_ext, null, "position", true);
            GetData.CacheTable(DS.consipcategory, null, "idconsipcategory", true);

            //GetData.CacheTable(DS.ivakind, null, null, true);
            //GetData.CacheTable(DS.upb, null, null, true);
            //GetData.CacheTable(DS.accmotive, null, null, true);
            //GetData.CacheTable(DS.inventorytree, null, null, true);

            GetData.CacheTable(DS.attachmentkind, null, null, false);
            HelpForm.SetFormatForColumn(DS.mandatedetail.Columns["number"], "N");
            HelpForm.SetFormatForColumn(DS.mandatedetail.Columns["npackage"], "N");
            HelpForm.SetDenyNull(DS.mandate.Columns["flagintracom"], true);
            //HelpForm.SetDenyNull(DS.mandate.Columns["flagtenderresult"], false);
            GetData.SetSorting(DS.mandatedetail, "idgroup asc, rownum asc");
            MetaData.SetDefault(DS.mandate, "idmandatestatus", 5);
            HelpForm.SetDenyNull(DS.mandate.Columns["resendingpcc"], true);
            HelpForm.SetDenyNull(DS.mandate.Columns["requested_doc"], true);
            string filterEpOperationDeb = QHS.CmpEq("idepoperation", "fatacq_deb");

            GetData.SetStaticFilter(DS.expirationkind, QHS.CmpNe("kind", "V"));

            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationDeb = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationDeb, Meta.Conn);

            DS.accmotiveapplied_debit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationDeb;

            QueryCreator.setSkipInsertCopy(DS.mandateavcpdetail, true);
            QueryCreator.setSkipInsertCopy(DS.mandateavcp, true);
            QueryCreator.setSkipInsertCopy(DS.mandatecig, true);

            GetData.SetStaticFilter(DS.accmotiveapplied_debit, filterEpOperationDeb);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationDeb);

            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_debit, "accmotiveapplied");

            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.sortingview, filtereserc);

            string filterCapogruppo = QHS.IsNull("idmain_avcp");
            DS.mandateavcp.ExtendedProperties[MetaData.ExtraParams] = filterCapogruppo;

            DS.mandatestatus.ExtendedProperties["sort_by"] = "idmandatestatus";
            gridStock.DataSource = DS.stockview;
            if (Meta.edit_type != "request") {
                gboxAction.Visible = false;
                MakeSpaceFrom(gboxAction);
                GetData.SetStaticFilter(DS.mandateview, QHS.CmpEq("isrequest", "N"));
                GetData.SetStaticFilter(DS.mandatekind, QHS.CmpEq("isrequest", "N"));
            }
            else {
                //Meta.CanInsert = false;
                Meta.CanInsertCopy = false;
                //Meta.CanCancel = false;
                GetData.SetStaticFilter(DS.mandateview,
                    QHS.AppAnd(QHS.CmpEq("isrequest", "S"), QHS.CmpNe("idmandatestatus", 1)));
                GetData.SetStaticFilter(DS.mandatekind, QHS.CmpEq("isrequest", "S"));
                gboxContratto.Text = "Richiesta d'Ordine";
                btnDividiDettaglio.Visible = false;
                btnUnisciDettagli.Visible = false;
                btnSostituisciDettaglio.Visible = false;
                btnLottiAppaltati.Visible = false;
            }
            VisualizzaBottoneImportaGara(false);

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

            idcurrencyEURO = Meta.Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency");

            Meta.MarkTableAsNotEntityChild(DS.invoicedetail);
            //object O = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "flagepexp");
            //if (O != null && O.ToString().ToUpper() == "S") GeneraImpegniBudget = true;

        }

        private object idcurrencyEURO;

        private object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(this);
        }

        //void SetGBoxClass0(int num, object sortingkind) {
        //    string nums = num.ToString();
        //    if (sortingkind == DBNull.Value) {
        //        GroupBox G = (GroupBox)GetCtrlByName("gboxclass0" + nums);
        //        G.Visible = false;
        //        TextBox C = (TextBox)GetCtrlByName("txtCodice0" + nums);
        //        C.Tag = null;
        //    }
        //    else {
        //        string filter = QHS.CmpEq("idsorkind", sortingkind);
        //        GetData.SetStaticFilter(DS.Tables["sorting0" + nums], filter);
        //        GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass0" + nums);
        //        Button btnCodice = (Button)GetCtrlByName("btnCodice0" + nums);
        //        TextBox txtCodice = (TextBox)GetCtrlByName("txtCodice0" + nums);
        //        //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
        //        string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
        //        gboxclass.Text = title;
        //        btnCodice.Tag = "manage.sorting0" + nums + ".tree." + filter;
        //        DS.Tables["sorting0" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
        //        gboxclass.Tag = "AutoChoose.txtCodice0" + nums + ".tree";
        //        txtCodice.Tag = "sorting0" + nums + ".sortcode?x";
        //    }
        //}


        private void MakeSpaceFrom(GroupBox G) {
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

        string getHeaderForConsipRow(DataRow consip) {
            if (consip == null) return "";
            DataTable T = consip.Table;
            DataRow[] header =
                T.Select(QHC.AppAnd(QHC.CmpEq("flagheader", "S"), QHC.CmpLt("position", consip["position"])),
                    "position desc");
            if (header.Length == 0) return "";
            return header[0]["description"].ToString();
        }
        private bool recuperoIntraUEAttivo = false;
        public void MetaData_AfterActivation() {
            Conn = Meta.Conn;
            //FillConsipKindTab(DS.consipkind);
            //FillConsipKindComboTab(DS.consipkind);
            //FillConsipKindTab_ext(DS.consipkind_ext);
            //FillConsipKindComboTab(DS.consipkind_ext);
            initConsipLabel();
            if (DS.config.Rows.Count > 0) {
                int flag  =CfgFn.GetNoNullInt32(DS.config.First().flag);
                if ((flag & 1) != 0) recuperoIntraUEAttivo = true;
            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.DS = new mandate_default.dsmeta();
			this.btnSituazione = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.cmbTipoScadenza = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtRiferminento = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtIndirizzoConsegna = new System.Windows.Forms.TextBox();
			this.TxtTermConsegna = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtDataDoc = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDocumento = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gboxContratto = new System.Windows.Forms.GroupBox();
			this.btnTipoOrdine = new System.Windows.Forms.Button();
			this.cmbTipoOrdine = new System.Windows.Forms.ComboBox();
			this.txtNumOrdine = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercOrdine = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTotale = new System.Windows.Forms.TextBox();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.txtImponibile = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.detailgrid = new System.Windows.Forms.DataGrid();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label42 = new System.Windows.Forms.Label();
			this.txtDataScadenza = new System.Windows.Forms.TextBox();
			this.chkCont = new System.Windows.Forms.CheckBox();
			this.gboxValuta = new System.Windows.Forms.GroupBox();
			this.btnCurrencyExchange = new System.Windows.Forms.Button();
			this.txtValuta = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txtCambio = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.txtDataContabile = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.Principale = new System.Windows.Forms.TabPage();
			this.btnImportaGara = new System.Windows.Forms.Button();
			this.chkRecuperoIvaIntraExtra = new System.Windows.Forms.CheckBox();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.lblcig = new System.Windows.Forms.Label();
			this.txtcig = new System.Windows.Forms.TextBox();
			this.gboxtipofattura = new System.Windows.Forms.GroupBox();
			this.rdbextracom = new System.Windows.Forms.RadioButton();
			this.rdbintracom = new System.Windows.Forms.RadioButton();
			this.rdbitalia = new System.Windows.Forms.RadioButton();
			this.tabAnac = new System.Windows.Forms.TabPage();
			this.tabControlAnac = new System.Windows.Forms.TabControl();
			this.tabPartecipanti = new System.Windows.Forms.TabPage();
			this.btnAggiungiAggiudicatario = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.gridAVCP = new System.Windows.Forms.DataGrid();
			this.btnLottiAppaltati = new System.Windows.Forms.Button();
			this.btnDelAVCP = new System.Windows.Forms.Button();
			this.btnEditAVCP = new System.Windows.Forms.Button();
			this.btnLottiPartecipati = new System.Windows.Forms.Button();
			this.btnInsAVCP = new System.Windows.Forms.Button();
			this.tabLotti = new System.Windows.Forms.TabPage();
			this.button5 = new System.Windows.Forms.Button();
			this.btnPartecipantiNonAssociati = new System.Windows.Forms.Button();
			this.btnPartecipantiAlLotto = new System.Windows.Forms.Button();
			this.btnOrdiniNoPartecipanti = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.btnOrdiniNoLotti = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.gridLotti = new System.Windows.Forms.DataGrid();
			this.tabEsito = new System.Windows.Forms.TabPage();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.grpRUP = new System.Windows.Forms.GroupBox();
			this.txtRUP = new System.Windows.Forms.TextBox();
			this.grpEsitoGara = new System.Windows.Forms.GroupBox();
			this.txtRibasso = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.tabDettagli = new System.Windows.Forms.TabPage();
			this.btnAnnullaDettaglio = new System.Windows.Forms.Button();
			this.grpDettagliAnnullati = new System.Windows.Forms.GroupBox();
			this.dataGridDettAnn = new System.Windows.Forms.DataGrid();
			this.btnRimpiazzaPerNuovoProrata = new System.Windows.Forms.Button();
			this.btnImportFromExcel = new System.Windows.Forms.Button();
			this.btnRipartizione = new System.Windows.Forms.Button();
			this.btnInserisciCopia = new System.Windows.Forms.Button();
			this.btnSostituisciDettaglio = new System.Windows.Forms.Button();
			this.btnUnisciDettagli = new System.Windows.Forms.Button();
			this.btnDividiDettaglio = new System.Windows.Forms.Button();
			this.Classificazioni = new System.Windows.Forms.TabPage();
			this.dgrClassificazioni = new System.Windows.Forms.DataGrid();
			this.btnIndElimina = new System.Windows.Forms.Button();
			this.btnIndModifica = new System.Windows.Forms.Button();
			this.btnIndInserisci = new System.Windows.Forms.Button();
			this.tabEP = new System.Windows.Forms.TabPage();
			this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
			this.btnGeneraEpExp = new System.Windows.Forms.Button();
			this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
			this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
			this.gBoxCausaleDebito = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
			this.button6 = new System.Windows.Forms.Button();
			this.labAltroEsercizio = new System.Windows.Forms.Label();
			this.btnGeneraEP = new System.Windows.Forms.Button();
			this.btnVisualizzaEP = new System.Windows.Forms.Button();
			this.labEP = new System.Windows.Forms.Label();
			this.tabMagazzino = new System.Windows.Forms.TabPage();
			this.label33 = new System.Windows.Forms.Label();
			this.gridStock = new System.Windows.Forms.DataGrid();
			this.gBoxMagazzino = new System.Windows.Forms.GroupBox();
			this.txtStore = new System.Windows.Forms.TextBox();
			this.btnMagazzino = new System.Windows.Forms.Button();
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
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnDelAtt = new System.Windows.Forms.Button();
			this.btnEditAtt = new System.Windows.Forms.Button();
			this.btnInsAtt = new System.Windows.Forms.Button();
			this.tabConsip = new System.Windows.Forms.TabPage();
			this.labelConsipExt = new System.Windows.Forms.Label();
			this.mainLabelConsip = new System.Windows.Forms.Label();
			this.cmbConsip2 = new System.Windows.Forms.ComboBox();
			this.btnConsipkind = new System.Windows.Forms.Button();
			this.cmbConsip1 = new System.Windows.Forms.ComboBox();
			this.txtConsipMotive1 = new System.Windows.Forms.TextBox();
			this.tabRegistroUnico = new System.Windows.Forms.TabPage();
			this.label46 = new System.Windows.Forms.Label();
			this.dgrPCC = new System.Windows.Forms.DataGrid();
			this.chkSendPCC = new System.Windows.Forms.CheckBox();
			this.grpRegistroUnico = new System.Windows.Forms.GroupBox();
			this.btnCreaRegistroUnico = new System.Windows.Forms.Button();
			this.label85 = new System.Windows.Forms.Label();
			this.txDataRicezioneRU = new System.Windows.Forms.TextBox();
			this.txtProgressivoRU = new System.Windows.Forms.TextBox();
			this.label82 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.txtProtocolloEntrataRU = new System.Windows.Forms.TextBox();
			this.txtAnnotazioniRU = new System.Windows.Forms.TextBox();
			this.label84 = new System.Windows.Forms.Label();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.label22 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkPattoIntegrita = new System.Windows.Forms.CheckBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFiscale = new System.Windows.Forms.CheckBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.label43 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.gBoxCausaleDebitoAggiornata = new System.Windows.Forms.GroupBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
			this.button7 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.txtApplierAnnotations = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gboxStato = new System.Windows.Forms.GroupBox();
			this.cmbStatus = new System.Windows.Forms.ComboBox();
			this.btnAccetta = new System.Windows.Forms.Button();
			this.btnintegra = new System.Windows.Forms.Button();
			this.btnApprova = new System.Windows.Forms.Button();
			this.btnAnnullaApprova = new System.Windows.Forms.Button();
			this.gboxAction = new System.Windows.Forms.GroupBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.consipkindBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.mandatedetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this._MyOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.MyOpenFile = createOpenFileDialog(this._MyOpenFile);
			this.progressBarImport = new System.Windows.Forms.ProgressBar();
			this.CMenu = new System.Windows.Forms.ContextMenu();
			this.MenuEnterPwd = new System.Windows.Forms.MenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.button10 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.gboxContratto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.gboxValuta.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.Principale.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.gboxtipofattura.SuspendLayout();
			this.tabAnac.SuspendLayout();
			this.tabControlAnac.SuspendLayout();
			this.tabPartecipanti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAVCP)).BeginInit();
			this.tabLotti.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLotti)).BeginInit();
			this.tabEsito.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.grpRUP.SuspendLayout();
			this.grpEsitoGara.SuspendLayout();
			this.tabDettagli.SuspendLayout();
			this.grpDettagliAnnullati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridDettAnn)).BeginInit();
			this.Classificazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).BeginInit();
			this.tabEP.SuspendLayout();
			this.gBoxCausaleDebito.SuspendLayout();
			this.tabMagazzino.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStock)).BeginInit();
			this.gBoxMagazzino.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabAllegati.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabConsip.SuspendLayout();
			this.tabRegistroUnico.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).BeginInit();
			this.grpRegistroUnico.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			this.gBoxCausaleDebitoAggiornata.SuspendLayout();
			this.gboxStato.SuspendLayout();
			this.gboxAction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.consipkindBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mandatedetailBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnSituazione
			// 
			this.btnSituazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSituazione.Location = new System.Drawing.Point(316, 166);
			this.btnSituazione.Name = "btnSituazione";
			this.btnSituazione.Size = new System.Drawing.Size(100, 23);
			this.btnSituazione.TabIndex = 10;
			this.btnSituazione.TabStop = false;
			this.btnSituazione.Text = "Situazione";
			this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtCredDeb);
			this.groupBox2.Location = new System.Drawing.Point(8, 84);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(413, 49);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Tag = "AutoChoose.txtCredDeb.default.(active=\'S\')";
			this.groupBox2.Text = "Fornitore";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(6, 20);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(401, 20);
			this.txtCredDeb.TabIndex = 6;
			this.txtCredDeb.Tag = "registrymainview.title?mandateview.registry";
			// 
			// cmbTipoScadenza
			// 
			this.cmbTipoScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoScadenza.DataSource = this.DS.expirationkind;
			this.cmbTipoScadenza.DisplayMember = "description";
			this.cmbTipoScadenza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoScadenza.Location = new System.Drawing.Point(51, 15);
			this.cmbTipoScadenza.Name = "cmbTipoScadenza";
			this.cmbTipoScadenza.Size = new System.Drawing.Size(346, 21);
			this.cmbTipoScadenza.TabIndex = 9;
			this.cmbTipoScadenza.Tag = "mandate.idexpirationkind?mandateview.idexpirationkind";
			this.cmbTipoScadenza.ValueMember = "idexpirationkind";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 16);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(37, 16);
			this.label11.TabIndex = 22;
			this.label11.Text = "Tipo";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtScadenza
			// 
			this.txtScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtScadenza.Location = new System.Drawing.Point(477, 16);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(88, 20);
			this.txtScadenza.TabIndex = 10;
			this.txtScadenza.Tag = "mandate.paymentexpiring?mandateview.paymentexpiring";
			this.txtScadenza.Leave += new System.EventHandler(this.txtScadenza_Leave);
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.Location = new System.Drawing.Point(412, 17);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(64, 16);
			this.label12.TabIndex = 20;
			this.label12.Text = "Scadenza:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(422, 43);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 16);
			this.label10.TabIndex = 0;
			this.label10.Text = "Riferimento:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRiferminento
			// 
			this.txtRiferminento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRiferminento.Location = new System.Drawing.Point(425, 59);
			this.txtRiferminento.Multiline = true;
			this.txtRiferminento.Name = "txtRiferminento";
			this.txtRiferminento.Size = new System.Drawing.Size(605, 37);
			this.txtRiferminento.TabIndex = 3;
			this.txtRiferminento.Tag = "mandate.registryreference?mandateview.registryreference";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 17);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(56, 16);
			this.label9.TabIndex = 17;
			this.label9.Text = "Indirizzo";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIndirizzoConsegna
			// 
			this.txtIndirizzoConsegna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIndirizzoConsegna.Location = new System.Drawing.Point(11, 35);
			this.txtIndirizzoConsegna.Multiline = true;
			this.txtIndirizzoConsegna.Name = "txtIndirizzoConsegna";
			this.txtIndirizzoConsegna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtIndirizzoConsegna.Size = new System.Drawing.Size(556, 45);
			this.txtIndirizzoConsegna.TabIndex = 14;
			this.txtIndirizzoConsegna.Tag = "mandate.deliveryaddress";
			// 
			// TxtTermConsegna
			// 
			this.TxtTermConsegna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtTermConsegna.Location = new System.Drawing.Point(415, 12);
			this.TxtTermConsegna.Name = "TxtTermConsegna";
			this.TxtTermConsegna.Size = new System.Drawing.Size(152, 20);
			this.TxtTermConsegna.TabIndex = 13;
			this.TxtTermConsegna.Tag = "mandate.deliveryexpiration";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Location = new System.Drawing.Point(357, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 16);
			this.label8.TabIndex = 14;
			this.label8.Text = "Termine:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Location = new System.Drawing.Point(7, 155);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.Size = new System.Drawing.Size(413, 71);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.Tag = "mandate.description";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(4, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 16);
			this.label6.TabIndex = 10;
			this.label6.Text = "Descrizione:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDataDoc
			// 
			this.txtDataDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataDoc.Location = new System.Drawing.Point(306, 30);
			this.txtDataDoc.Name = "txtDataDoc";
			this.txtDataDoc.Size = new System.Drawing.Size(101, 20);
			this.txtDataDoc.TabIndex = 5;
			this.txtDataDoc.Tag = "mandate.docdate";
			this.txtDataDoc.Leave += new System.EventHandler(this.txtDataDoc_Leave);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(272, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(32, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Data";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDocumento
			// 
			this.txtDocumento.Location = new System.Drawing.Point(72, 30);
			this.txtDocumento.Name = "txtDocumento";
			this.txtDocumento.Size = new System.Drawing.Size(160, 20);
			this.txtDocumento.TabIndex = 4;
			this.txtDocumento.Tag = "mandate.doc";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Documento";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// gboxContratto
			// 
			this.gboxContratto.Controls.Add(this.btnTipoOrdine);
			this.gboxContratto.Controls.Add(this.cmbTipoOrdine);
			this.gboxContratto.Controls.Add(this.txtNumOrdine);
			this.gboxContratto.Controls.Add(this.label2);
			this.gboxContratto.Controls.Add(this.txtEsercOrdine);
			this.gboxContratto.Controls.Add(this.label1);
			this.gboxContratto.Location = new System.Drawing.Point(8, 40);
			this.gboxContratto.Name = "gboxContratto";
			this.gboxContratto.Size = new System.Drawing.Size(408, 72);
			this.gboxContratto.TabIndex = 2;
			this.gboxContratto.TabStop = false;
			this.gboxContratto.Text = "Contratto Passivo";
			// 
			// btnTipoOrdine
			// 
			this.btnTipoOrdine.Location = new System.Drawing.Point(8, 16);
			this.btnTipoOrdine.Name = "btnTipoOrdine";
			this.btnTipoOrdine.Size = new System.Drawing.Size(64, 24);
			this.btnTipoOrdine.TabIndex = 0;
			this.btnTipoOrdine.TabStop = false;
			this.btnTipoOrdine.Tag = "Choose.mandatekind.default";
			this.btnTipoOrdine.Text = "Tipo";
			// 
			// cmbTipoOrdine
			// 
			this.cmbTipoOrdine.DataSource = this.DS.mandatekind;
			this.cmbTipoOrdine.DisplayMember = "description";
			this.cmbTipoOrdine.Location = new System.Drawing.Point(80, 16);
			this.cmbTipoOrdine.Name = "cmbTipoOrdine";
			this.cmbTipoOrdine.Size = new System.Drawing.Size(320, 21);
			this.cmbTipoOrdine.TabIndex = 0;
			this.cmbTipoOrdine.Tag = "mandate.idmankind";
			this.cmbTipoOrdine.ValueMember = "idmankind";
			// 
			// txtNumOrdine
			// 
			this.txtNumOrdine.Location = new System.Drawing.Point(230, 47);
			this.txtNumOrdine.Name = "txtNumOrdine";
			this.txtNumOrdine.Size = new System.Drawing.Size(56, 20);
			this.txtNumOrdine.TabIndex = 2;
			this.txtNumOrdine.Tag = "mandate.nman";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(172, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Numero:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtEsercOrdine
			// 
			this.txtEsercOrdine.Location = new System.Drawing.Point(80, 46);
			this.txtEsercOrdine.Name = "txtEsercOrdine";
			this.txtEsercOrdine.Size = new System.Drawing.Size(56, 20);
			this.txtEsercOrdine.TabIndex = 1;
			this.txtEsercOrdine.Tag = "mandate.yman.year";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotale
			// 
			this.txtTotale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotale.Location = new System.Drawing.Point(894, 331);
			this.txtTotale.Name = "txtTotale";
			this.txtTotale.ReadOnly = true;
			this.txtTotale.Size = new System.Drawing.Size(104, 20);
			this.txtTotale.TabIndex = 33;
			this.txtTotale.TabStop = false;
			this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtIva
			// 
			this.txtIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIva.Location = new System.Drawing.Point(754, 331);
			this.txtIva.Name = "txtIva";
			this.txtIva.ReadOnly = true;
			this.txtIva.Size = new System.Drawing.Size(88, 20);
			this.txtIva.TabIndex = 32;
			this.txtIva.TabStop = false;
			this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImponibile
			// 
			this.txtImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImponibile.Location = new System.Drawing.Point(592, 331);
			this.txtImponibile.Name = "txtImponibile";
			this.txtImponibile.ReadOnly = true;
			this.txtImponibile.Size = new System.Drawing.Size(112, 20);
			this.txtImponibile.TabIndex = 31;
			this.txtImponibile.TabStop = false;
			this.txtImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label16.Location = new System.Drawing.Point(853, 331);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(40, 17);
			this.label16.TabIndex = 30;
			this.label16.Text = "Totale:";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.Location = new System.Drawing.Point(715, 331);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(38, 17);
			this.label17.TabIndex = 29;
			this.label17.Text = "IVA:";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label18.Location = new System.Drawing.Point(527, 331);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 17);
			this.label18.TabIndex = 28;
			this.label18.Text = "Imponibile:";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(6, 59);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(106, 23);
			this.btnElimina.TabIndex = 18;
			this.btnElimina.TabStop = false;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(6, 31);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(106, 23);
			this.btnModifica.TabIndex = 17;
			this.btnModifica.TabStop = false;
			this.btnModifica.Tag = "edit.single";
			this.btnModifica.Text = "Modifica";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(6, 3);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(106, 23);
			this.btnInserisci.TabIndex = 16;
			this.btnInserisci.TabStop = false;
			this.btnInserisci.Tag = "insert.single";
			this.btnInserisci.Text = "Inserisci";
			// 
			// detailgrid
			// 
			this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.detailgrid.CaptionVisible = false;
			this.detailgrid.DataMember = "";
			this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.detailgrid.Location = new System.Drawing.Point(118, 3);
			this.detailgrid.Name = "detailgrid";
			this.detailgrid.Size = new System.Drawing.Size(880, 182);
			this.detailgrid.TabIndex = 14;
			this.detailgrid.Tag = "mandatedetail.lista.single";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.txtIndirizzoConsegna);
			this.groupBox3.Controls.Add(this.TxtTermConsegna);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Location = new System.Drawing.Point(427, 139);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(575, 88);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Consegna";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.txtDocumento);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.txtDataDoc);
			this.groupBox4.Location = new System.Drawing.Point(8, 8);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(413, 70);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Documento collegato";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.label42);
			this.groupBox5.Controls.Add(this.txtDataScadenza);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.txtScadenza);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.cmbTipoScadenza);
			this.groupBox5.Location = new System.Drawing.Point(427, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(575, 70);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Scadenza";
			// 
			// label42
			// 
			this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label42.Location = new System.Drawing.Point(420, 42);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(56, 16);
			this.label42.TabIndex = 24;
			this.label42.Text = "Data";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataScadenza
			// 
			this.txtDataScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataScadenza.Location = new System.Drawing.Point(477, 42);
			this.txtDataScadenza.Name = "txtDataScadenza";
			this.txtDataScadenza.ReadOnly = true;
			this.txtDataScadenza.Size = new System.Drawing.Size(88, 20);
			this.txtDataScadenza.TabIndex = 23;
			this.txtDataScadenza.Tag = "";
			this.txtDataScadenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// chkCont
			// 
			this.chkCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chkCont.Location = new System.Drawing.Point(9, 174);
			this.chkCont.Name = "chkCont";
			this.chkCont.Size = new System.Drawing.Size(254, 15);
			this.chkCont.TabIndex = 7;
			this.chkCont.Tag = "mandate.active:S:N";
			this.chkCont.Text = "Utilizzabile per la contabilizzazione";
			// 
			// gboxValuta
			// 
			this.gboxValuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxValuta.Controls.Add(this.btnCurrencyExchange);
			this.gboxValuta.Controls.Add(this.txtValuta);
			this.gboxValuta.Controls.Add(this.button2);
			this.gboxValuta.Controls.Add(this.txtCambio);
			this.gboxValuta.Controls.Add(this.label14);
			this.gboxValuta.Location = new System.Drawing.Point(427, 84);
			this.gboxValuta.Name = "gboxValuta";
			this.gboxValuta.Size = new System.Drawing.Size(575, 49);
			this.gboxValuta.TabIndex = 7;
			this.gboxValuta.TabStop = false;
			this.gboxValuta.Tag = "AutoChoose.txtValuta.default";
			// 
			// btnCurrencyExchange
			// 
			this.btnCurrencyExchange.Location = new System.Drawing.Point(427, 19);
			this.btnCurrencyExchange.Name = "btnCurrencyExchange";
			this.btnCurrencyExchange.Size = new System.Drawing.Size(75, 23);
			this.btnCurrencyExchange.TabIndex = 32;
			this.btnCurrencyExchange.Text = "Seleziona";
			this.btnCurrencyExchange.UseVisualStyleBackColor = true;
			this.btnCurrencyExchange.Visible = false;
			this.btnCurrencyExchange.Click += new System.EventHandler(this.btnCurrencyExchange_Click);
			// 
			// txtValuta
			// 
			this.txtValuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtValuta.Location = new System.Drawing.Point(85, 20);
			this.txtValuta.Name = "txtValuta";
			this.txtValuta.Size = new System.Drawing.Size(212, 20);
			this.txtValuta.TabIndex = 1;
			this.txtValuta.Tag = "currency.description?x";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 22);
			this.button2.TabIndex = 31;
			this.button2.TabStop = false;
			this.button2.Tag = "choose.currency.default";
			this.button2.Text = "Valuta";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// txtCambio
			// 
			this.txtCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCambio.Location = new System.Drawing.Point(389, 20);
			this.txtCambio.Name = "txtCambio";
			this.txtCambio.Size = new System.Drawing.Size(96, 20);
			this.txtCambio.TabIndex = 2;
			this.txtCambio.Tag = "mandate.exchangerate.fixed.6...1";
			this.txtCambio.Leave += new System.EventHandler(this.txtCambio_Leave);
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label14.Location = new System.Drawing.Point(302, 22);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(95, 16);
			this.label14.TabIndex = 30;
			this.label14.Text = "Tasso di cambio:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(639, 283);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(84, 19);
			this.label15.TabIndex = 36;
			this.label15.Text = "Data Contabile:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDataContabile
			// 
			this.txtDataContabile.Location = new System.Drawing.Point(721, 282);
			this.txtDataContabile.Name = "txtDataContabile";
			this.txtDataContabile.Size = new System.Drawing.Size(88, 20);
			this.txtDataContabile.TabIndex = 10;
			this.txtDataContabile.Tag = "mandate.adate?mandateview.adate";
			this.txtDataContabile.Leave += new System.EventHandler(this.txtDataContabile_Leave);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.Principale);
			this.tabControl1.Controls.Add(this.tabAnac);
			this.tabControl1.Controls.Add(this.tabDettagli);
			this.tabControl1.Controls.Add(this.Classificazioni);
			this.tabControl1.Controls.Add(this.tabEP);
			this.tabControl1.Controls.Add(this.tabMagazzino);
			this.tabControl1.Controls.Add(this.tabAttributi);
			this.tabControl1.Controls.Add(this.tabAllegati);
			this.tabControl1.Controls.Add(this.tabConsip);
			this.tabControl1.Controls.Add(this.tabRegistroUnico);
			this.tabControl1.Controls.Add(this.tabAltro);
			this.tabControl1.Location = new System.Drawing.Point(4, 198);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1020, 390);
			this.tabControl1.TabIndex = 9;
			// 
			// Principale
			// 
			this.Principale.Controls.Add(this.btnImportaGara);
			this.Principale.Controls.Add(this.chkRecuperoIvaIntraExtra);
			this.Principale.Controls.Add(this.gboxResponsabile);
			this.Principale.Controls.Add(this.lblcig);
			this.Principale.Controls.Add(this.txtcig);
			this.Principale.Controls.Add(this.groupBox4);
			this.Principale.Controls.Add(this.groupBox2);
			this.Principale.Controls.Add(this.gboxtipofattura);
			this.Principale.Controls.Add(this.txtDescrizione);
			this.Principale.Controls.Add(this.label6);
			this.Principale.Controls.Add(this.groupBox3);
			this.Principale.Controls.Add(this.groupBox5);
			this.Principale.Controls.Add(this.gboxValuta);
			this.Principale.Controls.Add(this.txtDataContabile);
			this.Principale.Controls.Add(this.label15);
			this.Principale.Location = new System.Drawing.Point(4, 22);
			this.Principale.Name = "Principale";
			this.Principale.Size = new System.Drawing.Size(1012, 364);
			this.Principale.TabIndex = 0;
			this.Principale.Text = "Principale";
			this.Principale.UseVisualStyleBackColor = true;
			// 
			// btnImportaGara
			// 
			this.btnImportaGara.Location = new System.Drawing.Point(283, 280);
			this.btnImportaGara.Name = "btnImportaGara";
			this.btnImportaGara.Size = new System.Drawing.Size(131, 23);
			this.btnImportaGara.TabIndex = 99;
			this.btnImportaGara.Text = "Importa Gara";
			this.btnImportaGara.UseVisualStyleBackColor = true;
			this.btnImportaGara.Click += new System.EventHandler(this.btnImportaGara_Click);
			// 
			// chkRecuperoIvaIntraExtra
			// 
			this.chkRecuperoIvaIntraExtra.AutoSize = true;
			this.chkRecuperoIvaIntraExtra.Location = new System.Drawing.Point(427, 286);
			this.chkRecuperoIvaIntraExtra.Name = "chkRecuperoIvaIntraExtra";
			this.chkRecuperoIvaIntraExtra.Size = new System.Drawing.Size(177, 17);
			this.chkRecuperoIvaIntraExtra.TabIndex = 98;
			this.chkRecuperoIvaIntraExtra.Tag = "mandate.flagbit:0";
			this.chkRecuperoIvaIntraExtra.Text = "Recupero IVA Intra ed Extra-UE";
			this.chkRecuperoIvaIntraExtra.UseVisualStyleBackColor = true;
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(7, 232);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(413, 44);
			this.gboxResponsabile.TabIndex = 4;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			this.gboxResponsabile.Text = "Responsabile";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(5, 16);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(402, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// lblcig
			// 
			this.lblcig.Location = new System.Drawing.Point(1, 281);
			this.lblcig.Name = "lblcig";
			this.lblcig.Size = new System.Drawing.Size(173, 23);
			this.lblcig.TabIndex = 57;
			this.lblcig.Tag = "";
			this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
			this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtcig
			// 
			this.txtcig.Location = new System.Drawing.Point(175, 282);
			this.txtcig.Name = "txtcig";
			this.txtcig.Size = new System.Drawing.Size(94, 20);
			this.txtcig.TabIndex = 5;
			this.txtcig.Tag = "mandate.cigcode";
			// 
			// gboxtipofattura
			// 
			this.gboxtipofattura.Controls.Add(this.rdbextracom);
			this.gboxtipofattura.Controls.Add(this.rdbintracom);
			this.gboxtipofattura.Controls.Add(this.rdbitalia);
			this.gboxtipofattura.Location = new System.Drawing.Point(427, 233);
			this.gboxtipofattura.Name = "gboxtipofattura";
			this.gboxtipofattura.Size = new System.Drawing.Size(382, 44);
			this.gboxtipofattura.TabIndex = 9;
			this.gboxtipofattura.TabStop = false;
			this.gboxtipofattura.Text = "Tipo Contratto";
			// 
			// rdbextracom
			// 
			this.rdbextracom.AutoSize = true;
			this.rdbextracom.Location = new System.Drawing.Point(130, 18);
			this.rdbextracom.Name = "rdbextracom";
			this.rdbextracom.Size = new System.Drawing.Size(113, 17);
			this.rdbextracom.TabIndex = 25;
			this.rdbextracom.TabStop = true;
			this.rdbextracom.Tag = "mandate.flagintracom:X";
			this.rdbextracom.Text = "Contratto Extra-UE";
			this.rdbextracom.UseVisualStyleBackColor = true;
			this.rdbextracom.CheckedChanged += new System.EventHandler(this.rdbextracom_CheckedChanged);
			// 
			// rdbintracom
			// 
			this.rdbintracom.AutoSize = true;
			this.rdbintracom.Location = new System.Drawing.Point(8, 18);
			this.rdbintracom.Name = "rdbintracom";
			this.rdbintracom.Size = new System.Drawing.Size(115, 17);
			this.rdbintracom.TabIndex = 24;
			this.rdbintracom.TabStop = true;
			this.rdbintracom.Tag = "mandate.flagintracom:S";
			this.rdbintracom.Text = "Contratto Intracom.";
			this.rdbintracom.UseVisualStyleBackColor = true;
			this.rdbintracom.CheckedChanged += new System.EventHandler(this.rdbintracom_CheckedChanged);
			// 
			// rdbitalia
			// 
			this.rdbitalia.AutoSize = true;
			this.rdbitalia.Location = new System.Drawing.Point(252, 18);
			this.rdbitalia.Name = "rdbitalia";
			this.rdbitalia.Size = new System.Drawing.Size(104, 17);
			this.rdbitalia.TabIndex = 23;
			this.rdbitalia.TabStop = true;
			this.rdbitalia.Tag = "mandate.flagintracom:N";
			this.rdbitalia.Text = "Contratto in Italia";
			this.rdbitalia.UseVisualStyleBackColor = true;
			this.rdbitalia.CheckedChanged += new System.EventHandler(this.rdbitalia_CheckedChanged);
			// 
			// tabAnac
			// 
			this.tabAnac.Controls.Add(this.tabControlAnac);
			this.tabAnac.Location = new System.Drawing.Point(4, 22);
			this.tabAnac.Name = "tabAnac";
			this.tabAnac.Size = new System.Drawing.Size(1012, 364);
			this.tabAnac.TabIndex = 10;
			this.tabAnac.Text = "ANAC";
			this.tabAnac.UseVisualStyleBackColor = true;
			// 
			// tabControlAnac
			// 
			this.tabControlAnac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlAnac.Controls.Add(this.tabPartecipanti);
			this.tabControlAnac.Controls.Add(this.tabLotti);
			this.tabControlAnac.Controls.Add(this.tabEsito);
			this.tabControlAnac.Location = new System.Drawing.Point(3, 3);
			this.tabControlAnac.Name = "tabControlAnac";
			this.tabControlAnac.SelectedIndex = 0;
			this.tabControlAnac.Size = new System.Drawing.Size(1001, 357);
			this.tabControlAnac.TabIndex = 52;
			// 
			// tabPartecipanti
			// 
			this.tabPartecipanti.Controls.Add(this.btnAggiungiAggiudicatario);
			this.tabPartecipanti.Controls.Add(this.label7);
			this.tabPartecipanti.Controls.Add(this.gridAVCP);
			this.tabPartecipanti.Controls.Add(this.btnLottiAppaltati);
			this.tabPartecipanti.Controls.Add(this.btnDelAVCP);
			this.tabPartecipanti.Controls.Add(this.btnEditAVCP);
			this.tabPartecipanti.Controls.Add(this.btnLottiPartecipati);
			this.tabPartecipanti.Controls.Add(this.btnInsAVCP);
			this.tabPartecipanti.Location = new System.Drawing.Point(4, 22);
			this.tabPartecipanti.Name = "tabPartecipanti";
			this.tabPartecipanti.Padding = new System.Windows.Forms.Padding(3);
			this.tabPartecipanti.Size = new System.Drawing.Size(993, 331);
			this.tabPartecipanti.TabIndex = 1;
			this.tabPartecipanti.Text = "Partecipanti al bando";
			this.tabPartecipanti.UseVisualStyleBackColor = true;
			// 
			// btnAggiungiAggiudicatario
			// 
			this.btnAggiungiAggiudicatario.Location = new System.Drawing.Point(8, 243);
			this.btnAggiungiAggiudicatario.Name = "btnAggiungiAggiudicatario";
			this.btnAggiungiAggiudicatario.Size = new System.Drawing.Size(96, 37);
			this.btnAggiungiAggiudicatario.TabIndex = 27;
			this.btnAggiungiAggiudicatario.Text = "Aggiungi Aggiudicatario";
			this.btnAggiungiAggiudicatario.UseVisualStyleBackColor = true;
			this.btnAggiungiAggiudicatario.Click += new System.EventHandler(this.btnAggiungiAggiudicatario_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(108, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(215, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "Ditte o raggruppamenti partecipanti alla gara";
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
			this.gridAVCP.Size = new System.Drawing.Size(876, 293);
			this.gridAVCP.TabIndex = 28;
			this.gridAVCP.Tag = "mandateavcp.lista.single";
			// 
			// btnLottiAppaltati
			// 
			this.btnLottiAppaltati.Location = new System.Drawing.Point(8, 214);
			this.btnLottiAppaltati.Name = "btnLottiAppaltati";
			this.btnLottiAppaltati.Size = new System.Drawing.Size(96, 23);
			this.btnLottiAppaltati.TabIndex = 26;
			this.btnLottiAppaltati.Text = "Lotti appaltati";
			this.btnLottiAppaltati.UseVisualStyleBackColor = true;
			this.btnLottiAppaltati.Click += new System.EventHandler(this.btnLottiAppaltati_Click);
			// 
			// btnDelAVCP
			// 
			this.btnDelAVCP.Location = new System.Drawing.Point(8, 92);
			this.btnDelAVCP.Name = "btnDelAVCP";
			this.btnDelAVCP.Size = new System.Drawing.Size(96, 23);
			this.btnDelAVCP.TabIndex = 27;
			this.btnDelAVCP.Tag = "delete";
			this.btnDelAVCP.Text = "Elimina";
			// 
			// btnEditAVCP
			// 
			this.btnEditAVCP.Location = new System.Drawing.Point(8, 62);
			this.btnEditAVCP.Name = "btnEditAVCP";
			this.btnEditAVCP.Size = new System.Drawing.Size(96, 23);
			this.btnEditAVCP.TabIndex = 26;
			this.btnEditAVCP.Tag = "edit.single";
			this.btnEditAVCP.Text = "Modifica...";
			// 
			// btnLottiPartecipati
			// 
			this.btnLottiPartecipati.Location = new System.Drawing.Point(8, 174);
			this.btnLottiPartecipati.Name = "btnLottiPartecipati";
			this.btnLottiPartecipati.Size = new System.Drawing.Size(96, 34);
			this.btnLottiPartecipati.TabIndex = 25;
			this.btnLottiPartecipati.Text = "Lotti a cui partecipa";
			this.btnLottiPartecipati.UseVisualStyleBackColor = true;
			this.btnLottiPartecipati.Click += new System.EventHandler(this.btnLottiPartecipati_Click);
			// 
			// btnInsAVCP
			// 
			this.btnInsAVCP.Location = new System.Drawing.Point(8, 32);
			this.btnInsAVCP.Name = "btnInsAVCP";
			this.btnInsAVCP.Size = new System.Drawing.Size(96, 23);
			this.btnInsAVCP.TabIndex = 25;
			this.btnInsAVCP.Tag = "insert.single";
			this.btnInsAVCP.Text = "Inserisci...";
			// 
			// tabLotti
			// 
			this.tabLotti.Controls.Add(this.button5);
			this.tabLotti.Controls.Add(this.btnPartecipantiNonAssociati);
			this.tabLotti.Controls.Add(this.btnPartecipantiAlLotto);
			this.tabLotti.Controls.Add(this.btnOrdiniNoPartecipanti);
			this.tabLotti.Controls.Add(this.button4);
			this.tabLotti.Controls.Add(this.btnOrdiniNoLotti);
			this.tabLotti.Controls.Add(this.button3);
			this.tabLotti.Controls.Add(this.label13);
			this.tabLotti.Controls.Add(this.gridLotti);
			this.tabLotti.Location = new System.Drawing.Point(4, 22);
			this.tabLotti.Name = "tabLotti";
			this.tabLotti.Padding = new System.Windows.Forms.Padding(3);
			this.tabLotti.Size = new System.Drawing.Size(993, 331);
			this.tabLotti.TabIndex = 0;
			this.tabLotti.Text = "Lotti del bando";
			this.tabLotti.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(6, 37);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(100, 23);
			this.button5.TabIndex = 44;
			this.button5.Tag = "insert.single";
			this.button5.Text = "Inserisci...";
			// 
			// btnPartecipantiNonAssociati
			// 
			this.btnPartecipantiNonAssociati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPartecipantiNonAssociati.Location = new System.Drawing.Point(804, 9);
			this.btnPartecipantiNonAssociati.Name = "btnPartecipantiNonAssociati";
			this.btnPartecipantiNonAssociati.Size = new System.Drawing.Size(183, 23);
			this.btnPartecipantiNonAssociati.TabIndex = 51;
			this.btnPartecipantiNonAssociati.Text = "Partecipanti non associati ai lotti";
			this.btnPartecipantiNonAssociati.UseVisualStyleBackColor = true;
			this.btnPartecipantiNonAssociati.Click += new System.EventHandler(this.btnPartecipantiNonAssociati_Click);
			// 
			// btnPartecipantiAlLotto
			// 
			this.btnPartecipantiAlLotto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnPartecipantiAlLotto.Location = new System.Drawing.Point(6, 237);
			this.btnPartecipantiAlLotto.Name = "btnPartecipantiAlLotto";
			this.btnPartecipantiAlLotto.Size = new System.Drawing.Size(100, 38);
			this.btnPartecipantiAlLotto.TabIndex = 43;
			this.btnPartecipantiAlLotto.Text = "Partecipanti al lotto";
			this.btnPartecipantiAlLotto.UseVisualStyleBackColor = true;
			this.btnPartecipantiAlLotto.Click += new System.EventHandler(this.btnPartecipantiAlLotto_Click);
			// 
			// btnOrdiniNoPartecipanti
			// 
			this.btnOrdiniNoPartecipanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOrdiniNoPartecipanti.Location = new System.Drawing.Point(649, 9);
			this.btnOrdiniNoPartecipanti.Name = "btnOrdiniNoPartecipanti";
			this.btnOrdiniNoPartecipanti.Size = new System.Drawing.Size(149, 23);
			this.btnOrdiniNoPartecipanti.TabIndex = 50;
			this.btnOrdiniNoPartecipanti.Text = "Ordini senza partecipanti";
			this.btnOrdiniNoPartecipanti.UseVisualStyleBackColor = true;
			this.btnOrdiniNoPartecipanti.Click += new System.EventHandler(this.btnOrdiniNoPartecipanti_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 67);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(100, 23);
			this.button4.TabIndex = 45;
			this.button4.Tag = "edit.single";
			this.button4.Text = "Modifica...";
			// 
			// btnOrdiniNoLotti
			// 
			this.btnOrdiniNoLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOrdiniNoLotti.Location = new System.Drawing.Point(535, 9);
			this.btnOrdiniNoLotti.Name = "btnOrdiniNoLotti";
			this.btnOrdiniNoLotti.Size = new System.Drawing.Size(108, 23);
			this.btnOrdiniNoLotti.TabIndex = 49;
			this.btnOrdiniNoLotti.Text = "Ordini senza lotti";
			this.btnOrdiniNoLotti.UseVisualStyleBackColor = true;
			this.btnOrdiniNoLotti.Click += new System.EventHandler(this.btnOrdiniNoLotti_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(6, 97);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(100, 23);
			this.button3.TabIndex = 46;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(111, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(228, 13);
			this.label13.TabIndex = 48;
			this.label13.Text = "Lotti del bando ai fini della pubblicazione AVCP";
			// 
			// gridLotti
			// 
			this.gridLotti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridLotti.DataMember = "";
			this.gridLotti.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridLotti.Location = new System.Drawing.Point(114, 35);
			this.gridLotti.Name = "gridLotti";
			this.gridLotti.ReadOnly = true;
			this.gridLotti.Size = new System.Drawing.Size(873, 291);
			this.gridLotti.TabIndex = 47;
			this.gridLotti.Tag = "mandatecig.lista.detail";
			// 
			// tabEsito
			// 
			this.tabEsito.Controls.Add(this.groupBox7);
			this.tabEsito.Controls.Add(this.groupBox6);
			this.tabEsito.Controls.Add(this.grpRUP);
			this.tabEsito.Controls.Add(this.grpEsitoGara);
			this.tabEsito.Location = new System.Drawing.Point(4, 22);
			this.tabEsito.Name = "tabEsito";
			this.tabEsito.Padding = new System.Windows.Forms.Padding(3);
			this.tabEsito.Size = new System.Drawing.Size(993, 331);
			this.tabEsito.TabIndex = 2;
			this.tabEsito.Text = "Gestione gara";
			this.tabEsito.UseVisualStyleBackColor = true;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.groupBox8);
			this.groupBox7.Controls.Add(this.textBox9);
			this.groupBox7.Location = new System.Drawing.Point(7, 63);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(913, 72);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Data pubblicazione";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.radioButton11);
			this.groupBox8.Controls.Add(this.radioButton10);
			this.groupBox8.Controls.Add(this.radioButton9);
			this.groupBox8.Controls.Add(this.radioButton8);
			this.groupBox8.Location = new System.Drawing.Point(204, 16);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(701, 48);
			this.groupBox8.TabIndex = 1;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Tipo data pubblicazione";
			// 
			// radioButton11
			// 
			this.radioButton11.AutoSize = true;
			this.radioButton11.Location = new System.Drawing.Point(580, 19);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(115, 17);
			this.radioButton11.TabIndex = 6;
			this.radioButton11.TabStop = true;
			this.radioButton11.Tag = "mandate.publishdatekind:M";
			this.radioButton11.Text = "acquisto su MEPA ";
			this.radioButton11.UseVisualStyleBackColor = true;
			// 
			// radioButton10
			// 
			this.radioButton10.AutoSize = true;
			this.radioButton10.Location = new System.Drawing.Point(460, 19);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(86, 17);
			this.radioButton10.TabIndex = 5;
			this.radioButton10.TabStop = true;
			this.radioButton10.Tag = "mandate.publishdatekind:V";
			this.radioButton10.Text = "convenzione";
			this.radioButton10.UseVisualStyleBackColor = true;
			// 
			// radioButton9
			// 
			this.radioButton9.AutoSize = true;
			this.radioButton9.Location = new System.Drawing.Point(200, 19);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(242, 17);
			this.radioButton9.TabIndex = 4;
			this.radioButton9.TabStop = true;
			this.radioButton9.Tag = "mandate.publishdatekind:Q";
			this.radioButton9.Text = "perfezionamento adesione ad accordo quadro";
			this.radioButton9.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(23, 19);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(148, 17);
			this.radioButton8.TabIndex = 3;
			this.radioButton8.TabStop = true;
			this.radioButton8.Tag = "mandate.publishdatekind:C";
			this.radioButton8.Text = "perfezionamento contratto";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(6, 19);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(100, 20);
			this.textBox9.TabIndex = 0;
			this.textBox9.Tag = "mandate.publishdate";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.radioButton7);
			this.groupBox6.Controls.Add(this.radioButton6);
			this.groupBox6.Controls.Add(this.radioButton5);
			this.groupBox6.Controls.Add(this.radioButton4);
			this.groupBox6.Location = new System.Drawing.Point(6, 6);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(361, 51);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Tipo gara";
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(270, 20);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(73, 17);
			this.radioButton7.TabIndex = 3;
			this.radioButton7.TabStop = true;
			this.radioButton7.Tag = "mandate.tenderkind:DE";
			this.radioButton7.Text = "Determina";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(173, 20);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(81, 17);
			this.radioButton6.TabIndex = 2;
			this.radioButton6.TabStop = true;
			this.radioButton6.Tag = "mandate.tenderkind:AF";
			this.radioButton6.Text = "Affidamento";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(92, 20);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(57, 17);
			this.radioButton5.TabIndex = 1;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "mandate.tenderkind:AV";
			this.radioButton5.Text = "Avviso";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(6, 20);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(56, 17);
			this.radioButton4.TabIndex = 0;
			this.radioButton4.TabStop = true;
			this.radioButton4.Tag = "mandate.tenderkind:B";
			this.radioButton4.Text = "Bando";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// grpRUP
			// 
			this.grpRUP.Controls.Add(this.txtRUP);
			this.grpRUP.Location = new System.Drawing.Point(373, 6);
			this.grpRUP.Name = "grpRUP";
			this.grpRUP.Size = new System.Drawing.Size(547, 51);
			this.grpRUP.TabIndex = 4;
			this.grpRUP.TabStop = false;
			this.grpRUP.Tag = "AutoChoose.txtRUP.lista";
			this.grpRUP.Text = "R.U.P. Responsabile Unico del Procedimento per ANAC";
			// 
			// txtRUP
			// 
			this.txtRUP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRUP.Location = new System.Drawing.Point(8, 20);
			this.txtRUP.Name = "txtRUP";
			this.txtRUP.Size = new System.Drawing.Size(531, 20);
			this.txtRUP.TabIndex = 0;
			this.txtRUP.Tag = "registrymainview_rup.title?mandateview.rupanac";
			// 
			// grpEsitoGara
			// 
			this.grpEsitoGara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpEsitoGara.Controls.Add(this.txtRibasso);
			this.grpEsitoGara.Controls.Add(this.label24);
			this.grpEsitoGara.Controls.Add(this.textBox8);
			this.grpEsitoGara.Controls.Add(this.label23);
			this.grpEsitoGara.Controls.Add(this.radioButton1);
			this.grpEsitoGara.Controls.Add(this.radioButton2);
			this.grpEsitoGara.Controls.Add(this.radioButton3);
			this.grpEsitoGara.Location = new System.Drawing.Point(7, 141);
			this.grpEsitoGara.Name = "grpEsitoGara";
			this.grpEsitoGara.Size = new System.Drawing.Size(977, 100);
			this.grpEsitoGara.TabIndex = 3;
			this.grpEsitoGara.TabStop = false;
			this.grpEsitoGara.Text = "Esito della Gara";
			// 
			// txtRibasso
			// 
			this.txtRibasso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRibasso.Location = new System.Drawing.Point(886, 24);
			this.txtRibasso.Name = "txtRibasso";
			this.txtRibasso.Size = new System.Drawing.Size(83, 20);
			this.txtRibasso.TabIndex = 37;
			this.txtRibasso.Tag = "mandate.anacreduced.fixed.4..%.100";
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.Location = new System.Drawing.Point(883, 8);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(56, 16);
			this.label24.TabIndex = 38;
			this.label24.Text = "Ribasso %";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(215, 24);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox8.Size = new System.Drawing.Size(662, 62);
			this.textBox8.TabIndex = 27;
			this.textBox8.Tag = "mandate.motiveassignment";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(214, 10);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(137, 13);
			this.label23.TabIndex = 26;
			this.label23.Text = "Motivazione affidamento:";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 48);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(97, 17);
			this.radioButton1.TabIndex = 25;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "mandate.flagtenderresult:D";
			this.radioButton1.Text = "Andata deserta";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 27);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(81, 17);
			this.radioButton2.TabIndex = 24;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "mandate.flagtenderresult:A";
			this.radioButton2.Text = "Aggiudicata";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 69);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(194, 17);
			this.radioButton3.TabIndex = 23;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "mandate.flagtenderresult:N";
			this.radioButton3.Text = "Senza esito per offerte non congrue";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// tabDettagli
			// 
			this.tabDettagli.Controls.Add(this.btnAnnullaDettaglio);
			this.tabDettagli.Controls.Add(this.grpDettagliAnnullati);
			this.tabDettagli.Controls.Add(this.btnRimpiazzaPerNuovoProrata);
			this.tabDettagli.Controls.Add(this.btnImportFromExcel);
			this.tabDettagli.Controls.Add(this.btnRipartizione);
			this.tabDettagli.Controls.Add(this.btnInserisciCopia);
			this.tabDettagli.Controls.Add(this.btnInserisci);
			this.tabDettagli.Controls.Add(this.btnElimina);
			this.tabDettagli.Controls.Add(this.btnSostituisciDettaglio);
			this.tabDettagli.Controls.Add(this.btnModifica);
			this.tabDettagli.Controls.Add(this.detailgrid);
			this.tabDettagli.Controls.Add(this.btnUnisciDettagli);
			this.tabDettagli.Controls.Add(this.label16);
			this.tabDettagli.Controls.Add(this.btnDividiDettaglio);
			this.tabDettagli.Controls.Add(this.label18);
			this.tabDettagli.Controls.Add(this.label17);
			this.tabDettagli.Controls.Add(this.txtIva);
			this.tabDettagli.Controls.Add(this.txtImponibile);
			this.tabDettagli.Controls.Add(this.txtTotale);
			this.tabDettagli.Location = new System.Drawing.Point(4, 22);
			this.tabDettagli.Name = "tabDettagli";
			this.tabDettagli.Size = new System.Drawing.Size(1012, 364);
			this.tabDettagli.TabIndex = 8;
			this.tabDettagli.Text = "Dettagli";
			this.tabDettagli.UseVisualStyleBackColor = true;
			// 
			// btnAnnullaDettaglio
			// 
			this.btnAnnullaDettaglio.ForeColor = System.Drawing.Color.DarkRed;
			this.btnAnnullaDettaglio.Location = new System.Drawing.Point(6, 229);
			this.btnAnnullaDettaglio.Name = "btnAnnullaDettaglio";
			this.btnAnnullaDettaglio.Size = new System.Drawing.Size(107, 21);
			this.btnAnnullaDettaglio.TabIndex = 49;
			this.btnAnnullaDettaglio.Text = "Annulla";
			this.btnAnnullaDettaglio.UseVisualStyleBackColor = true;
			this.btnAnnullaDettaglio.Click += new System.EventHandler(this.btnAnnullaDettaglio_Click);
			// 
			// grpDettagliAnnullati
			// 
			this.grpDettagliAnnullati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpDettagliAnnullati.Controls.Add(this.dataGridDettAnn);
			this.grpDettagliAnnullati.Location = new System.Drawing.Point(118, 185);
			this.grpDettagliAnnullati.Name = "grpDettagliAnnullati";
			this.grpDettagliAnnullati.Size = new System.Drawing.Size(880, 140);
			this.grpDettagliAnnullati.TabIndex = 48;
			this.grpDettagliAnnullati.TabStop = false;
			this.grpDettagliAnnullati.Text = "Dettagli annullati";
			// 
			// dataGridDettAnn
			// 
			this.dataGridDettAnn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridDettAnn.CaptionVisible = false;
			this.dataGridDettAnn.DataMember = "";
			this.dataGridDettAnn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridDettAnn.Location = new System.Drawing.Point(6, 19);
			this.dataGridDettAnn.Name = "dataGridDettAnn";
			this.dataGridDettAnn.Size = new System.Drawing.Size(869, 117);
			this.dataGridDettAnn.TabIndex = 45;
			this.dataGridDettAnn.Tag = "mandatedetail.annullati.single";
			// 
			// btnRimpiazzaPerNuovoProrata
			// 
			this.btnRimpiazzaPerNuovoProrata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRimpiazzaPerNuovoProrata.Location = new System.Drawing.Point(118, 331);
			this.btnRimpiazzaPerNuovoProrata.Name = "btnRimpiazzaPerNuovoProrata";
			this.btnRimpiazzaPerNuovoProrata.Size = new System.Drawing.Size(111, 22);
			this.btnRimpiazzaPerNuovoProrata.TabIndex = 45;
			this.btnRimpiazzaPerNuovoProrata.Text = "Aggiorna prorata";
			this.btnRimpiazzaPerNuovoProrata.Click += new System.EventHandler(this.btnRimpiazzaPerNuovoProrata_Click);
			// 
			// btnImportFromExcel
			// 
			this.btnImportFromExcel.Location = new System.Drawing.Point(6, 257);
			this.btnImportFromExcel.Name = "btnImportFromExcel";
			this.btnImportFromExcel.Size = new System.Drawing.Size(107, 23);
			this.btnImportFromExcel.TabIndex = 44;
			this.btnImportFromExcel.Text = "Importa da Excel";
			this.btnImportFromExcel.Click += new System.EventHandler(this.btnImportFromExcel_Click);
			// 
			// btnRipartizione
			// 
			this.btnRipartizione.Location = new System.Drawing.Point(6, 200);
			this.btnRipartizione.Name = "btnRipartizione";
			this.btnRipartizione.Size = new System.Drawing.Size(106, 23);
			this.btnRipartizione.TabIndex = 43;
			this.btnRipartizione.Text = "Ripartizione";
			this.btnRipartizione.Click += new System.EventHandler(this.btnRipartizione_Click);
			// 
			// btnInserisciCopia
			// 
			this.btnInserisciCopia.Location = new System.Drawing.Point(6, 87);
			this.btnInserisciCopia.Name = "btnInserisciCopia";
			this.btnInserisciCopia.Size = new System.Drawing.Size(106, 23);
			this.btnInserisciCopia.TabIndex = 42;
			this.btnInserisciCopia.Text = "Inserisci copia";
			this.btnInserisciCopia.UseVisualStyleBackColor = true;
			this.btnInserisciCopia.Click += new System.EventHandler(this.btnInserisciCopia_Click);
			// 
			// btnSostituisciDettaglio
			// 
			this.btnSostituisciDettaglio.Location = new System.Drawing.Point(6, 171);
			this.btnSostituisciDettaglio.Name = "btnSostituisciDettaglio";
			this.btnSostituisciDettaglio.Size = new System.Drawing.Size(106, 23);
			this.btnSostituisciDettaglio.TabIndex = 41;
			this.btnSostituisciDettaglio.Text = "Sostituisci";
			this.btnSostituisciDettaglio.Click += new System.EventHandler(this.btnSostituisciDettaglio_Click);
			// 
			// btnUnisciDettagli
			// 
			this.btnUnisciDettagli.Location = new System.Drawing.Point(6, 143);
			this.btnUnisciDettagli.Name = "btnUnisciDettagli";
			this.btnUnisciDettagli.Size = new System.Drawing.Size(106, 23);
			this.btnUnisciDettagli.TabIndex = 40;
			this.btnUnisciDettagli.Text = "Unisci";
			this.btnUnisciDettagli.Click += new System.EventHandler(this.btnUnisciDettagli_Click);
			// 
			// btnDividiDettaglio
			// 
			this.btnDividiDettaglio.Location = new System.Drawing.Point(6, 115);
			this.btnDividiDettaglio.Name = "btnDividiDettaglio";
			this.btnDividiDettaglio.Size = new System.Drawing.Size(106, 23);
			this.btnDividiDettaglio.TabIndex = 39;
			this.btnDividiDettaglio.Text = "Dividi";
			this.btnDividiDettaglio.Click += new System.EventHandler(this.btnDividiDettaglio_Click);
			// 
			// Classificazioni
			// 
			this.Classificazioni.Controls.Add(this.dgrClassificazioni);
			this.Classificazioni.Controls.Add(this.btnIndElimina);
			this.Classificazioni.Controls.Add(this.btnIndModifica);
			this.Classificazioni.Controls.Add(this.btnIndInserisci);
			this.Classificazioni.Location = new System.Drawing.Point(4, 22);
			this.Classificazioni.Name = "Classificazioni";
			this.Classificazioni.Size = new System.Drawing.Size(1012, 364);
			this.Classificazioni.TabIndex = 1;
			this.Classificazioni.Text = "Classificazioni";
			this.Classificazioni.UseVisualStyleBackColor = true;
			// 
			// dgrClassificazioni
			// 
			this.dgrClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassificazioni.DataMember = "";
			this.dgrClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassificazioni.Location = new System.Drawing.Point(16, 46);
			this.dgrClassificazioni.Name = "dgrClassificazioni";
			this.dgrClassificazioni.ReadOnly = true;
			this.dgrClassificazioni.Size = new System.Drawing.Size(980, 314);
			this.dgrClassificazioni.TabIndex = 15;
			this.dgrClassificazioni.Tag = "mandatesorting.default.default";
			// 
			// btnIndElimina
			// 
			this.btnIndElimina.Location = new System.Drawing.Point(176, 16);
			this.btnIndElimina.Name = "btnIndElimina";
			this.btnIndElimina.Size = new System.Drawing.Size(68, 23);
			this.btnIndElimina.TabIndex = 14;
			this.btnIndElimina.Tag = "delete";
			this.btnIndElimina.Text = "Elimina";
			// 
			// btnIndModifica
			// 
			this.btnIndModifica.Location = new System.Drawing.Point(96, 16);
			this.btnIndModifica.Name = "btnIndModifica";
			this.btnIndModifica.Size = new System.Drawing.Size(69, 23);
			this.btnIndModifica.TabIndex = 13;
			this.btnIndModifica.Tag = "edit.default";
			this.btnIndModifica.Text = "Modifica...";
			// 
			// btnIndInserisci
			// 
			this.btnIndInserisci.Location = new System.Drawing.Point(16, 16);
			this.btnIndInserisci.Name = "btnIndInserisci";
			this.btnIndInserisci.Size = new System.Drawing.Size(68, 23);
			this.btnIndInserisci.TabIndex = 12;
			this.btnIndInserisci.Tag = "insert.default";
			this.btnIndInserisci.Text = "Inserisci...";
			// 
			// tabEP
			// 
			this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
			this.tabEP.Controls.Add(this.btnGeneraEpExp);
			this.tabEP.Controls.Add(this.btnGeneraPreimpegni);
			this.tabEP.Controls.Add(this.btnVisualizzaPreimpegni);
			this.tabEP.Controls.Add(this.gBoxCausaleDebito);
			this.tabEP.Controls.Add(this.labAltroEsercizio);
			this.tabEP.Controls.Add(this.btnGeneraEP);
			this.tabEP.Controls.Add(this.btnVisualizzaEP);
			this.tabEP.Controls.Add(this.labEP);
			this.tabEP.Location = new System.Drawing.Point(4, 22);
			this.tabEP.Name = "tabEP";
			this.tabEP.Size = new System.Drawing.Size(1012, 364);
			this.tabEP.TabIndex = 2;
			this.tabEP.Text = "E/P";
			this.tabEP.UseVisualStyleBackColor = true;
			// 
			// btnVisualizzaEpExp
			// 
			this.btnVisualizzaEpExp.Location = new System.Drawing.Point(720, 145);
			this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
			this.btnVisualizzaEpExp.Size = new System.Drawing.Size(197, 23);
			this.btnVisualizzaEpExp.TabIndex = 40;
			this.btnVisualizzaEpExp.TabStop = false;
			this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
			// 
			// btnGeneraEpExp
			// 
			this.btnGeneraEpExp.Location = new System.Drawing.Point(720, 116);
			this.btnGeneraEpExp.Name = "btnGeneraEpExp";
			this.btnGeneraEpExp.Size = new System.Drawing.Size(197, 23);
			this.btnGeneraEpExp.TabIndex = 39;
			this.btnGeneraEpExp.TabStop = false;
			this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
			// 
			// btnGeneraPreimpegni
			// 
			this.btnGeneraPreimpegni.Location = new System.Drawing.Point(486, 116);
			this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
			this.btnGeneraPreimpegni.Size = new System.Drawing.Size(197, 23);
			this.btnGeneraPreimpegni.TabIndex = 41;
			this.btnGeneraPreimpegni.TabStop = false;
			this.btnGeneraPreimpegni.Text = "Genera Preimpegni di Budget";
			// 
			// btnVisualizzaPreimpegni
			// 
			this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(486, 145);
			this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
			this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(197, 23);
			this.btnVisualizzaPreimpegni.TabIndex = 42;
			this.btnVisualizzaPreimpegni.TabStop = false;
			this.btnVisualizzaPreimpegni.Text = "Visualizza Preimpegni di Budget";
			// 
			// gBoxCausaleDebito
			// 
			this.gBoxCausaleDebito.Controls.Add(this.textBox1);
			this.gBoxCausaleDebito.Controls.Add(this.txtCodiceCausaleDeb);
			this.gBoxCausaleDebito.Controls.Add(this.button6);
			this.gBoxCausaleDebito.Location = new System.Drawing.Point(8, 29);
			this.gBoxCausaleDebito.Name = "gBoxCausaleDebito";
			this.gBoxCausaleDebito.Size = new System.Drawing.Size(329, 142);
			this.gBoxCausaleDebito.TabIndex = 13;
			this.gBoxCausaleDebito.TabStop = false;
			this.gBoxCausaleDebito.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
			this.gBoxCausaleDebito.Text = "Causale di debito";
			this.gBoxCausaleDebito.UseCompatibleTextRendering = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(133, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(190, 94);
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "accmotiveapplied_debit.motive";
			// 
			// txtCodiceCausaleDeb
			// 
			this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(6, 116);
			this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
			this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(317, 20);
			this.txtCodiceCausaleDeb.TabIndex = 1;
			this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_debit.codemotive?mandateview.codemotivedebit";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(6, 87);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(119, 23);
			this.button6.TabIndex = 0;
			this.button6.Tag = "manage.accmotiveapplied_debit.tree";
			this.button6.Text = "Causale";
			// 
			// labAltroEsercizio
			// 
			this.labAltroEsercizio.AutoSize = true;
			this.labAltroEsercizio.Location = new System.Drawing.Point(359, 68);
			this.labAltroEsercizio.Name = "labAltroEsercizio";
			this.labAltroEsercizio.Size = new System.Drawing.Size(324, 13);
			this.labAltroEsercizio.TabIndex = 4;
			this.labAltroEsercizio.Text = "Il contratto non contiene scritture di competenza di questo esercizio";
			// 
			// btnGeneraEP
			// 
			this.btnGeneraEP.Location = new System.Drawing.Point(720, 63);
			this.btnGeneraEP.Name = "btnGeneraEP";
			this.btnGeneraEP.Size = new System.Drawing.Size(197, 23);
			this.btnGeneraEP.TabIndex = 3;
			this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
			this.btnGeneraEP.UseVisualStyleBackColor = true;
			// 
			// btnVisualizzaEP
			// 
			this.btnVisualizzaEP.Location = new System.Drawing.Point(720, 34);
			this.btnVisualizzaEP.Name = "btnVisualizzaEP";
			this.btnVisualizzaEP.Size = new System.Drawing.Size(198, 23);
			this.btnVisualizzaEP.TabIndex = 2;
			this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
			this.btnVisualizzaEP.UseVisualStyleBackColor = true;
			// 
			// labEP
			// 
			this.labEP.AutoSize = true;
			this.labEP.Location = new System.Drawing.Point(360, 50);
			this.labEP.Name = "labEP";
			this.labEP.Size = new System.Drawing.Size(237, 13);
			this.labEP.TabIndex = 0;
			this.labEP.Text = "Le scritture in partita doppia sono state generate.";
			// 
			// tabMagazzino
			// 
			this.tabMagazzino.Controls.Add(this.label33);
			this.tabMagazzino.Controls.Add(this.gridStock);
			this.tabMagazzino.Controls.Add(this.gBoxMagazzino);
			this.tabMagazzino.Location = new System.Drawing.Point(4, 22);
			this.tabMagazzino.Name = "tabMagazzino";
			this.tabMagazzino.Size = new System.Drawing.Size(1012, 364);
			this.tabMagazzino.TabIndex = 4;
			this.tabMagazzino.Text = "Magazzino";
			this.tabMagazzino.UseVisualStyleBackColor = true;
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(12, 53);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(330, 13);
			this.label33.TabIndex = 4;
			this.label33.Text = "Merce pervenuta in magazzino - è aggiornata solo dopo aver salvato";
			// 
			// gridStock
			// 
			this.gridStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridStock.DataMember = "";
			this.gridStock.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridStock.Location = new System.Drawing.Point(15, 69);
			this.gridStock.Name = "gridStock";
			this.gridStock.ReadOnly = true;
			this.gridStock.Size = new System.Drawing.Size(982, 291);
			this.gridStock.TabIndex = 3;
			this.gridStock.Tag = "stockview.default";
			// 
			// gBoxMagazzino
			// 
			this.gBoxMagazzino.Controls.Add(this.txtStore);
			this.gBoxMagazzino.Controls.Add(this.btnMagazzino);
			this.gBoxMagazzino.Location = new System.Drawing.Point(15, 9);
			this.gBoxMagazzino.Name = "gBoxMagazzino";
			this.gBoxMagazzino.Size = new System.Drawing.Size(408, 41);
			this.gBoxMagazzino.TabIndex = 40;
			this.gBoxMagazzino.TabStop = false;
			this.gBoxMagazzino.Tag = "AutoChoose.txtStore.default.(active=\'S\')";
			// 
			// txtStore
			// 
			this.txtStore.Location = new System.Drawing.Point(91, 11);
			this.txtStore.Name = "txtStore";
			this.txtStore.Size = new System.Drawing.Size(311, 20);
			this.txtStore.TabIndex = 41;
			this.txtStore.Tag = "store.description?x";
			// 
			// btnMagazzino
			// 
			this.btnMagazzino.Location = new System.Drawing.Point(5, 9);
			this.btnMagazzino.Name = "btnMagazzino";
			this.btnMagazzino.Size = new System.Drawing.Size(76, 23);
			this.btnMagazzino.TabIndex = 7;
			this.btnMagazzino.TabStop = false;
			this.btnMagazzino.Tag = "choose.store.default";
			this.btnMagazzino.Text = "Magazzino";
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
			this.tabAttributi.Size = new System.Drawing.Size(1012, 364);
			this.tabAttributi.TabIndex = 6;
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
			this.gboxclass05.Location = new System.Drawing.Point(480, 76);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(529, 64);
			this.gboxclass05.TabIndex = 23;
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
			this.btnCodice05.Location = new System.Drawing.Point(8, 14);
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
			this.txtDenom05.Size = new System.Drawing.Size(287, 52);
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
			this.gboxclass04.Location = new System.Drawing.Point(480, 6);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(529, 64);
			this.gboxclass04.TabIndex = 22;
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
			this.btnCodice04.Location = new System.Drawing.Point(8, 14);
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
			this.txtDenom04.Size = new System.Drawing.Size(287, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(6, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(465, 64);
			this.gboxclass03.TabIndex = 20;
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
			this.btnCodice03.Location = new System.Drawing.Point(8, 14);
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
			this.gboxclass02.Location = new System.Drawing.Point(6, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(465, 64);
			this.gboxclass02.TabIndex = 21;
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
			this.btnCodice02.Location = new System.Drawing.Point(8, 14);
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
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(465, 64);
			this.gboxclass01.TabIndex = 19;
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
			// tabAllegati
			// 
			this.tabAllegati.Controls.Add(this.dataGrid1);
			this.tabAllegati.Controls.Add(this.btnDelAtt);
			this.tabAllegati.Controls.Add(this.btnEditAtt);
			this.tabAllegati.Controls.Add(this.btnInsAtt);
			this.tabAllegati.Location = new System.Drawing.Point(4, 22);
			this.tabAllegati.Name = "tabAllegati";
			this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
			this.tabAllegati.Size = new System.Drawing.Size(1012, 364);
			this.tabAllegati.TabIndex = 5;
			this.tabAllegati.Text = "Allegati";
			this.tabAllegati.UseVisualStyleBackColor = true;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(15, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(980, 310);
			this.dataGrid1.TabIndex = 19;
			this.dataGrid1.Tag = "mandateattachment.lista.default";
			// 
			// btnDelAtt
			// 
			this.btnDelAtt.Location = new System.Drawing.Point(175, 18);
			this.btnDelAtt.Name = "btnDelAtt";
			this.btnDelAtt.Size = new System.Drawing.Size(68, 23);
			this.btnDelAtt.TabIndex = 18;
			this.btnDelAtt.Tag = "delete";
			this.btnDelAtt.Text = "Elimina";
			// 
			// btnEditAtt
			// 
			this.btnEditAtt.Location = new System.Drawing.Point(95, 18);
			this.btnEditAtt.Name = "btnEditAtt";
			this.btnEditAtt.Size = new System.Drawing.Size(69, 23);
			this.btnEditAtt.TabIndex = 17;
			this.btnEditAtt.Tag = "edit.default";
			this.btnEditAtt.Text = "Modifica...";
			// 
			// btnInsAtt
			// 
			this.btnInsAtt.Location = new System.Drawing.Point(15, 18);
			this.btnInsAtt.Name = "btnInsAtt";
			this.btnInsAtt.Size = new System.Drawing.Size(68, 23);
			this.btnInsAtt.TabIndex = 16;
			this.btnInsAtt.Tag = "insert.default";
			this.btnInsAtt.Text = "Inserisci...";
			// 
			// tabConsip
			// 
			this.tabConsip.Controls.Add(this.labelConsipExt);
			this.tabConsip.Controls.Add(this.mainLabelConsip);
			this.tabConsip.Controls.Add(this.cmbConsip2);
			this.tabConsip.Controls.Add(this.btnConsipkind);
			this.tabConsip.Controls.Add(this.cmbConsip1);
			this.tabConsip.Controls.Add(this.txtConsipMotive1);
			this.tabConsip.Location = new System.Drawing.Point(4, 22);
			this.tabConsip.Name = "tabConsip";
			this.tabConsip.Size = new System.Drawing.Size(1012, 364);
			this.tabConsip.TabIndex = 7;
			this.tabConsip.Text = "CONSIP";
			this.tabConsip.UseVisualStyleBackColor = true;
			// 
			// labelConsipExt
			// 
			this.labelConsipExt.AutoSize = true;
			this.labelConsipExt.Location = new System.Drawing.Point(8, 163);
			this.labelConsipExt.Name = "labelConsipExt";
			this.labelConsipExt.Size = new System.Drawing.Size(10, 13);
			this.labelConsipExt.TabIndex = 19;
			this.labelConsipExt.Text = "-";
			// 
			// mainLabelConsip
			// 
			this.mainLabelConsip.AutoSize = true;
			this.mainLabelConsip.Location = new System.Drawing.Point(10, 22);
			this.mainLabelConsip.Name = "mainLabelConsip";
			this.mainLabelConsip.Size = new System.Drawing.Size(10, 13);
			this.mainLabelConsip.TabIndex = 18;
			this.mainLabelConsip.Text = "-";
			// 
			// cmbConsip2
			// 
			this.cmbConsip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbConsip2.DataSource = this.DS.consipkind_ext;
			this.cmbConsip2.DisplayMember = "shortdescription";
			this.cmbConsip2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbConsip2.Location = new System.Drawing.Point(7, 183);
			this.cmbConsip2.Name = "cmbConsip2";
			this.cmbConsip2.Size = new System.Drawing.Size(989, 21);
			this.cmbConsip2.TabIndex = 15;
			this.cmbConsip2.Tag = "mandate.idconsipkind_ext?mandateview.idconsipkind_ext";
			this.cmbConsip2.ValueMember = "idconsipkind";
			this.cmbConsip2.SelectedIndexChanged += new System.EventHandler(this.cmbConsip2_SelectedIndexChanged);
			// 
			// btnConsipkind
			// 
			this.btnConsipkind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConsipkind.Location = new System.Drawing.Point(921, 82);
			this.btnConsipkind.Name = "btnConsipkind";
			this.btnConsipkind.Size = new System.Drawing.Size(75, 23);
			this.btnConsipkind.TabIndex = 17;
			this.btnConsipkind.Text = "Modifica";
			this.btnConsipkind.UseVisualStyleBackColor = true;
			this.btnConsipkind.Click += new System.EventHandler(this.btnConsip_Click);
			// 
			// cmbConsip1
			// 
			this.cmbConsip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbConsip1.DataSource = this.DS.consipkind;
			this.cmbConsip1.DisplayMember = "shortdescription";
			this.cmbConsip1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbConsip1.Location = new System.Drawing.Point(7, 43);
			this.cmbConsip1.Name = "cmbConsip1";
			this.cmbConsip1.Size = new System.Drawing.Size(989, 21);
			this.cmbConsip1.TabIndex = 15;
			this.cmbConsip1.Tag = "mandate.idconsipkind?mandateview.idconsipkind";
			this.cmbConsip1.ValueMember = "idconsipkind";
			this.cmbConsip1.SelectedIndexChanged += new System.EventHandler(this.cmbOptionConsip_SelectedIndexChanged);
			// 
			// txtConsipMotive1
			// 
			this.txtConsipMotive1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsipMotive1.Location = new System.Drawing.Point(7, 84);
			this.txtConsipMotive1.Multiline = true;
			this.txtConsipMotive1.Name = "txtConsipMotive1";
			this.txtConsipMotive1.ReadOnly = true;
			this.txtConsipMotive1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtConsipMotive1.Size = new System.Drawing.Size(885, 56);
			this.txtConsipMotive1.TabIndex = 16;
			this.txtConsipMotive1.Tag = "mandate.consipmotive";
			// 
			// tabRegistroUnico
			// 
			this.tabRegistroUnico.Controls.Add(this.label46);
			this.tabRegistroUnico.Controls.Add(this.dgrPCC);
			this.tabRegistroUnico.Controls.Add(this.chkSendPCC);
			this.tabRegistroUnico.Controls.Add(this.grpRegistroUnico);
			this.tabRegistroUnico.Location = new System.Drawing.Point(4, 22);
			this.tabRegistroUnico.Name = "tabRegistroUnico";
			this.tabRegistroUnico.Size = new System.Drawing.Size(1012, 364);
			this.tabRegistroUnico.TabIndex = 12;
			this.tabRegistroUnico.Text = "Registro Unico";
			this.tabRegistroUnico.UseVisualStyleBackColor = true;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(5, 153);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(100, 20);
			this.label46.TabIndex = 53;
			this.label46.Text = "Trasmissione PCC";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgrPCC
			// 
			this.dgrPCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrPCC.DataMember = "";
			this.dgrPCC.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrPCC.Location = new System.Drawing.Point(8, 173);
			this.dgrPCC.Name = "dgrPCC";
			this.dgrPCC.Size = new System.Drawing.Size(995, 180);
			this.dgrPCC.TabIndex = 52;
			this.dgrPCC.Tag = "pccview.mandate";
			// 
			// chkSendPCC
			// 
			this.chkSendPCC.AutoSize = true;
			this.chkSendPCC.Location = new System.Drawing.Point(8, 117);
			this.chkSendPCC.Name = "chkSendPCC";
			this.chkSendPCC.Size = new System.Drawing.Size(202, 17);
			this.chkSendPCC.TabIndex = 51;
			this.chkSendPCC.Tag = "mandate.resendingpcc:S:N";
			this.chkSendPCC.Text = "Ritrasmetti contratto passivo alla PCC";
			this.chkSendPCC.UseVisualStyleBackColor = true;
			// 
			// grpRegistroUnico
			// 
			this.grpRegistroUnico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpRegistroUnico.Controls.Add(this.btnCreaRegistroUnico);
			this.grpRegistroUnico.Controls.Add(this.label85);
			this.grpRegistroUnico.Controls.Add(this.txDataRicezioneRU);
			this.grpRegistroUnico.Controls.Add(this.txtProgressivoRU);
			this.grpRegistroUnico.Controls.Add(this.label82);
			this.grpRegistroUnico.Controls.Add(this.label83);
			this.grpRegistroUnico.Controls.Add(this.txtProtocolloEntrataRU);
			this.grpRegistroUnico.Controls.Add(this.txtAnnotazioniRU);
			this.grpRegistroUnico.Controls.Add(this.label84);
			this.grpRegistroUnico.Location = new System.Drawing.Point(8, 3);
			this.grpRegistroUnico.Name = "grpRegistroUnico";
			this.grpRegistroUnico.Size = new System.Drawing.Size(995, 108);
			this.grpRegistroUnico.TabIndex = 50;
			this.grpRegistroUnico.TabStop = false;
			// 
			// btnCreaRegistroUnico
			// 
			this.btnCreaRegistroUnico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreaRegistroUnico.Location = new System.Drawing.Point(75, 79);
			this.btnCreaRegistroUnico.Name = "btnCreaRegistroUnico";
			this.btnCreaRegistroUnico.Size = new System.Drawing.Size(190, 23);
			this.btnCreaRegistroUnico.TabIndex = 18;
			this.btnCreaRegistroUnico.Text = "Protocolla nel Registro Unico";
			this.btnCreaRegistroUnico.UseVisualStyleBackColor = true;
			this.btnCreaRegistroUnico.Click += new System.EventHandler(this.btnCreaRegistroUnico_Click);
			// 
			// label85
			// 
			this.label85.Location = new System.Drawing.Point(387, 16);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(146, 20);
			this.label85.TabIndex = 16;
			this.label85.Text = "Data ricezione documento ";
			this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txDataRicezioneRU
			// 
			this.txDataRicezioneRU.Location = new System.Drawing.Point(390, 36);
			this.txDataRicezioneRU.Name = "txDataRicezioneRU";
			this.txDataRicezioneRU.Size = new System.Drawing.Size(96, 20);
			this.txDataRicezioneRU.TabIndex = 3;
			this.txDataRicezioneRU.Tag = "mandate.arrivaldate";
			// 
			// txtProgressivoRU
			// 
			this.txtProgressivoRU.Location = new System.Drawing.Point(11, 36);
			this.txtProgressivoRU.Name = "txtProgressivoRU";
			this.txtProgressivoRU.Size = new System.Drawing.Size(117, 20);
			this.txtProgressivoRU.TabIndex = 1;
			this.txtProgressivoRU.Tag = "uniqueregister.iduniqueregister?mandateview.iduniqueregister";
			this.txtProgressivoRU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label82
			// 
			this.label82.Location = new System.Drawing.Point(7, 16);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(175, 20);
			this.label82.TabIndex = 13;
			this.label82.Text = "Codice progressivo di registrazione";
			this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label83
			// 
			this.label83.Location = new System.Drawing.Point(207, 16);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(141, 20);
			this.label83.TabIndex = 8;
			this.label83.Text = "Numero protocollo di entrata";
			this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProtocolloEntrataRU
			// 
			this.txtProtocolloEntrataRU.Location = new System.Drawing.Point(210, 36);
			this.txtProtocolloEntrataRU.Multiline = true;
			this.txtProtocolloEntrataRU.Name = "txtProtocolloEntrataRU";
			this.txtProtocolloEntrataRU.Size = new System.Drawing.Size(114, 20);
			this.txtProtocolloEntrataRU.TabIndex = 2;
			this.txtProtocolloEntrataRU.Tag = "mandate.arrivalprotocolnum";
			// 
			// txtAnnotazioniRU
			// 
			this.txtAnnotazioniRU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnnotazioniRU.Location = new System.Drawing.Point(541, 35);
			this.txtAnnotazioniRU.Multiline = true;
			this.txtAnnotazioniRU.Name = "txtAnnotazioniRU";
			this.txtAnnotazioniRU.Size = new System.Drawing.Size(448, 67);
			this.txtAnnotazioniRU.TabIndex = 4;
			this.txtAnnotazioniRU.Tag = "mandate.annotations";
			// 
			// label84
			// 
			this.label84.Location = new System.Drawing.Point(538, 18);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(81, 16);
			this.label84.TabIndex = 12;
			this.label84.Text = "Annotazioni";
			this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.label22);
			this.tabAltro.Controls.Add(this.textBox7);
			this.tabAltro.Controls.Add(this.groupBox1);
			this.tabAltro.Controls.Add(this.grpCertificatiNecessari);
			this.tabAltro.Location = new System.Drawing.Point(4, 22);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Size = new System.Drawing.Size(1012, 364);
			this.tabAltro.TabIndex = 11;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(11, 243);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(184, 23);
			this.label22.TabIndex = 61;
			this.label22.Tag = "mandate.external_reference";
			this.label22.Text = "Codice proveniente da importazione";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(201, 245);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(276, 20);
			this.textBox7.TabIndex = 2;
			this.textBox7.Tag = "mandate.external_reference";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Location = new System.Drawing.Point(17, 15);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(433, 136);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Annotazioni sull\'accantonamento per Impegno";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(113, 29);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(89, 20);
			this.textBox5.TabIndex = 8;
			this.textBox5.Tag = "mandate.subappropriation";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(42, 95);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(49, 14);
			this.label21.TabIndex = 10;
			this.label21.Text = "Data";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(20, 23);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(87, 31);
			this.label20.TabIndex = 7;
			this.label20.Text = "Anno/Numero";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox6.Location = new System.Drawing.Point(113, 93);
			this.textBox6.Multiline = true;
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(89, 20);
			this.textBox6.TabIndex = 11;
			this.textBox6.Tag = "mandate.adatesubappropriation";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(113, 60);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(315, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.Tag = "mandate.finsubappropriation";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(10, 61);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(97, 17);
			this.label19.TabIndex = 6;
			this.label19.Text = "Voce di Bilancio";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grpCertificatiNecessari.Controls.Add(this.chkPattoIntegrita);
			this.grpCertificatiNecessari.Controls.Add(this.chkVerificaAnac);
			this.grpCertificatiNecessari.Controls.Add(this.chkRegolaritaFiscale);
			this.grpCertificatiNecessari.Controls.Add(this.chkOttempLegge);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioAmm);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioGiud);
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(521, 15);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(482, 136);
			this.grpCertificatiNecessari.TabIndex = 97;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkPattoIntegrita
			// 
			this.chkPattoIntegrita.AutoSize = true;
			this.chkPattoIntegrita.Location = new System.Drawing.Point(335, 95);
			this.chkPattoIntegrita.Name = "chkPattoIntegrita";
			this.chkPattoIntegrita.Size = new System.Drawing.Size(103, 17);
			this.chkPattoIntegrita.TabIndex = 100;
			this.chkPattoIntegrita.Tag = "mandate.requested_doc:8";
			this.chkPattoIntegrita.Text = "Patto di Integrità";
			this.chkPattoIntegrita.UseVisualStyleBackColor = true;
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(161, 60);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 99;
			this.chkVerificaAnac.Tag = "mandate.requested_doc:7";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFiscale
			// 
			this.chkRegolaritaFiscale.AutoSize = true;
			this.chkRegolaritaFiscale.Location = new System.Drawing.Point(21, 62);
			this.chkRegolaritaFiscale.Name = "chkRegolaritaFiscale";
			this.chkRegolaritaFiscale.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFiscale.TabIndex = 98;
			this.chkRegolaritaFiscale.Tag = "mandate.requested_doc:6";
			this.chkRegolaritaFiscale.Text = "Regolarità Fiscale";
			this.chkRegolaritaFiscale.UseVisualStyleBackColor = true;
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(161, 95);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 97;
			this.chkOttempLegge.Tag = "mandate.requested_doc:5";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(271, 61);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 96;
			this.chkCasellarioAmm.Tag = "mandate.requested_doc:4";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(21, 95);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 95;
			this.chkCasellarioGiud.Tag = "mandate.requested_doc:3";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(161, 29);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(57, 17);
			this.chkDurc.TabIndex = 94;
			this.chkDurc.Tag = "mandate.requested_doc:2";
			this.chkDurc.Text = "DURC";
			this.chkDurc.UseVisualStyleBackColor = true;
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(271, 29);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(102, 17);
			this.chkVisura.TabIndex = 93;
			this.chkVisura.Tag = "mandate.requested_doc:1";
			this.chkVisura.Text = "Visura Camerale";
			this.chkVisura.UseVisualStyleBackColor = true;
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(21, 29);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "mandate.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(631, 184);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(169, 16);
			this.label43.TabIndex = 16;
			this.label43.Text = "Data correzione causale di debito";
			this.label43.Visible = false;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(634, 200);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(134, 20);
			this.textBox3.TabIndex = 14;
			this.textBox3.Tag = "mandate.idaccmotivedebit_datacrg?mandateview.idaccmotivedebit_datacrg";
			this.textBox3.Visible = false;
			// 
			// gBoxCausaleDebitoAggiornata
			// 
			this.gBoxCausaleDebitoAggiornata.Controls.Add(this.textBox4);
			this.gBoxCausaleDebitoAggiornata.Controls.Add(this.txtCodiceCausaleCrg);
			this.gBoxCausaleDebitoAggiornata.Controls.Add(this.button7);
			this.gBoxCausaleDebitoAggiornata.Location = new System.Drawing.Point(634, 227);
			this.gBoxCausaleDebitoAggiornata.Name = "gBoxCausaleDebitoAggiornata";
			this.gBoxCausaleDebitoAggiornata.Size = new System.Drawing.Size(305, 80);
			this.gBoxCausaleDebitoAggiornata.TabIndex = 15;
			this.gBoxCausaleDebitoAggiornata.TabStop = false;
			this.gBoxCausaleDebitoAggiornata.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
			this.gBoxCausaleDebitoAggiornata.Text = "Causale di debito aggiornata";
			this.gBoxCausaleDebitoAggiornata.UseCompatibleTextRendering = true;
			this.gBoxCausaleDebitoAggiornata.Visible = false;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(130, 14);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(169, 56);
			this.textBox4.TabIndex = 2;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "accmotiveapplied_crg.motive";
			// 
			// txtCodiceCausaleCrg
			// 
			this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(8, 48);
			this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
			this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(113, 20);
			this.txtCodiceCausaleCrg.TabIndex = 1;
			this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?mandateview.codemotivedebit_crg";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(8, 16);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(113, 23);
			this.button7.TabIndex = 0;
			this.button7.Tag = "manage.accmotiveapplied_crg.tree";
			this.button7.Text = "Causale";
			// 
			// checkBox1
			// 
			this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.Location = new System.Drawing.Point(425, 171);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(216, 21);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Tag = "mandate.flagdanger:S:N";
			this.checkBox1.Text = "Materiale pericoloso/radioattivo";
			// 
			// txtApplierAnnotations
			// 
			this.txtApplierAnnotations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtApplierAnnotations.Location = new System.Drawing.Point(425, 118);
			this.txtApplierAnnotations.Multiline = true;
			this.txtApplierAnnotations.Name = "txtApplierAnnotations";
			this.txtApplierAnnotations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtApplierAnnotations.Size = new System.Drawing.Size(605, 48);
			this.txtApplierAnnotations.TabIndex = 5;
			this.txtApplierAnnotations.Tag = "mandate.applierannotations";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(422, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Note del Richiedente:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gboxStato
			// 
			this.gboxStato.Controls.Add(this.cmbStatus);
			this.gboxStato.Location = new System.Drawing.Point(9, 114);
			this.gboxStato.Name = "gboxStato";
			this.gboxStato.Size = new System.Drawing.Size(407, 49);
			this.gboxStato.TabIndex = 4;
			this.gboxStato.TabStop = false;
			this.gboxStato.Text = "Stato";
			// 
			// cmbStatus
			// 
			this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbStatus.DataSource = this.DS.mandatestatus;
			this.cmbStatus.DisplayMember = "description";
			this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbStatus.Location = new System.Drawing.Point(6, 18);
			this.cmbStatus.Name = "cmbStatus";
			this.cmbStatus.Size = new System.Drawing.Size(395, 21);
			this.cmbStatus.TabIndex = 43;
			this.cmbStatus.Tag = "mandate.idmandatestatus?mandateview.idmandatestatus";
			this.cmbStatus.ValueMember = "idmandatestatus";
			// 
			// btnAccetta
			// 
			this.btnAccetta.Location = new System.Drawing.Point(8, 10);
			this.btnAccetta.Name = "btnAccetta";
			this.btnAccetta.Size = new System.Drawing.Size(97, 24);
			this.btnAccetta.TabIndex = 41;
			this.btnAccetta.TabStop = false;
			this.btnAccetta.Tag = "";
			this.btnAccetta.Text = "Accetta";
			this.toolTip1.SetToolTip(this.btnAccetta, "Esamina la richiesta e ne consente l\'eventuale modifica");
			this.btnAccetta.Click += new System.EventHandler(this.btnAccetta_Click);
			// 
			// btnintegra
			// 
			this.btnintegra.Location = new System.Drawing.Point(113, 10);
			this.btnintegra.Name = "btnintegra";
			this.btnintegra.Size = new System.Drawing.Size(132, 24);
			this.btnintegra.TabIndex = 42;
			this.btnintegra.TabStop = false;
			this.btnintegra.Tag = "";
			this.btnintegra.Text = "Richiedi integrazioni";
			this.toolTip1.SetToolTip(this.btnintegra, "Richiede a chi ha inserito la richiesta di effettuare delle modifiche");
			this.btnintegra.Click += new System.EventHandler(this.btnintegra_Click);
			// 
			// btnApprova
			// 
			this.btnApprova.Location = new System.Drawing.Point(252, 10);
			this.btnApprova.Name = "btnApprova";
			this.btnApprova.Size = new System.Drawing.Size(137, 24);
			this.btnApprova.TabIndex = 43;
			this.btnApprova.TabStop = false;
			this.btnApprova.Tag = "";
			this.btnApprova.Text = "Crea contratto passivo";
			this.toolTip1.SetToolTip(this.btnApprova, "Approva definitivamente la richiesta e la rende un buono dordine ufficiale");
			this.btnApprova.Click += new System.EventHandler(this.btnApprova_Click);
			// 
			// btnAnnullaApprova
			// 
			this.btnAnnullaApprova.Location = new System.Drawing.Point(563, 10);
			this.btnAnnullaApprova.Name = "btnAnnullaApprova";
			this.btnAnnullaApprova.Size = new System.Drawing.Size(97, 24);
			this.btnAnnullaApprova.TabIndex = 44;
			this.btnAnnullaApprova.TabStop = false;
			this.btnAnnullaApprova.Tag = "";
			this.btnAnnullaApprova.Text = "Riconsidera";
			this.toolTip1.SetToolTip(this.btnAnnullaApprova, "Annulla l\'operazione di approvazione o annullamento ");
			this.btnAnnullaApprova.Click += new System.EventHandler(this.btnAnnullaApprova_Click);
			// 
			// gboxAction
			// 
			this.gboxAction.Controls.Add(this.btnAnnulla);
			this.gboxAction.Controls.Add(this.btnAccetta);
			this.gboxAction.Controls.Add(this.btnAnnullaApprova);
			this.gboxAction.Controls.Add(this.btnintegra);
			this.gboxAction.Controls.Add(this.btnApprova);
			this.gboxAction.Location = new System.Drawing.Point(8, 0);
			this.gboxAction.Name = "gboxAction";
			this.gboxAction.Size = new System.Drawing.Size(671, 40);
			this.gboxAction.TabIndex = 1;
			this.gboxAction.TabStop = false;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Location = new System.Drawing.Point(457, 10);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(97, 24);
			this.btnAnnulla.TabIndex = 45;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Tag = "";
			this.btnAnnulla.Text = "Annulla";
			this.toolTip1.SetToolTip(this.btnAnnulla, "Approva definitivamente la richiesta e la rende un buono dordine ufficiale");
			this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
			// 
			// mandatedetailBindingSource
			// 
			this.mandatedetailBindingSource.DataMember = "mandatedetail";
			this.mandatedetailBindingSource.DataSource = this.DS;
			// 
			// progressBarImport
			// 
			this.progressBarImport.Location = new System.Drawing.Point(0, 0);
			this.progressBarImport.Name = "progressBarImport";
			this.progressBarImport.Size = new System.Drawing.Size(100, 23);
			this.progressBarImport.TabIndex = 0;
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
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(609, 29);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(134, 20);
			this.button1.TabIndex = 17;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(606, 63);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(137, 22);
			this.button8.TabIndex = 18;
			this.button8.Text = "button8";
			this.button8.UseVisualStyleBackColor = true;
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(770, 30);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(127, 19);
			this.button9.TabIndex = 19;
			this.button9.Text = "button9";
			this.button9.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(771, 63);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(125, 21);
			this.button10.TabIndex = 20;
			this.button10.Text = "button10";
			this.button10.UseVisualStyleBackColor = true;
			// 
			// Frm_mandate_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1038, 593);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.gboxAction);
			this.Controls.Add(this.gboxStato);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtApplierAnnotations);
			this.Controls.Add(this.chkCont);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.txtRiferminento);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.gboxContratto);
			this.Controls.Add(this.btnSituazione);
			this.Name = "Frm_mandate_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.gboxContratto.ResumeLayout(false);
			this.gboxContratto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.gboxValuta.ResumeLayout(false);
			this.gboxValuta.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.Principale.ResumeLayout(false);
			this.Principale.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxtipofattura.ResumeLayout(false);
			this.gboxtipofattura.PerformLayout();
			this.tabAnac.ResumeLayout(false);
			this.tabControlAnac.ResumeLayout(false);
			this.tabPartecipanti.ResumeLayout(false);
			this.tabPartecipanti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridAVCP)).EndInit();
			this.tabLotti.ResumeLayout(false);
			this.tabLotti.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridLotti)).EndInit();
			this.tabEsito.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.grpRUP.ResumeLayout(false);
			this.grpRUP.PerformLayout();
			this.grpEsitoGara.ResumeLayout(false);
			this.grpEsitoGara.PerformLayout();
			this.tabDettagli.ResumeLayout(false);
			this.tabDettagli.PerformLayout();
			this.grpDettagliAnnullati.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridDettAnn)).EndInit();
			this.Classificazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).EndInit();
			this.tabEP.ResumeLayout(false);
			this.tabEP.PerformLayout();
			this.gBoxCausaleDebito.ResumeLayout(false);
			this.gBoxCausaleDebito.PerformLayout();
			this.tabMagazzino.ResumeLayout(false);
			this.tabMagazzino.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridStock)).EndInit();
			this.gBoxMagazzino.ResumeLayout(false);
			this.gBoxMagazzino.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabConsip.ResumeLayout(false);
			this.tabConsip.PerformLayout();
			this.tabRegistroUnico.ResumeLayout(false);
			this.tabRegistroUnico.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrPCC)).EndInit();
			this.grpRegistroUnico.ResumeLayout(false);
			this.grpRegistroUnico.PerformLayout();
			this.tabAltro.ResumeLayout(false);
			this.tabAltro.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			this.gBoxCausaleDebitoAggiornata.ResumeLayout(false);
			this.gBoxCausaleDebitoAggiornata.PerformLayout();
			this.gboxStato.ResumeLayout(false);
			this.gboxAction.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.consipkindBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mandatedetailBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Metodo che annulla / ripristina tutti i dettagli fratelli di un dettaglio annullato / ripristinato.
        /// Per fratello si intende un dettaglio appartenente allo stesso gruppo, nel caso di split.
        /// </summary>
        private void allineaFratelli() {
            int sysYear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            bool viewMessage = true;
            bool doSetDatagrid = false;
            if (DS.mandatedetail.Select().Length == 0) return;
            foreach (DataRow rDetail in DS.mandatedetail.Select()) {
                if (rDetail.RowState != DataRowState.Modified) continue;

                DateTime originalDate = (rDetail["stop", DataRowVersion.Original] == DBNull.Value)
                    ? QueryCreator.EmptyDate()
                    : (DateTime) rDetail["stop", DataRowVersion.Original];

                DateTime currentDate = (rDetail["stop", DataRowVersion.Current] == DBNull.Value)
                    ? QueryCreator.EmptyDate()
                    : (DateTime) rDetail["stop", DataRowVersion.Current];

                int yearOriginalSTOP = originalDate.Year;
                int yearCurrentSTOP = currentDate.Year;

                if (yearOriginalSTOP == yearCurrentSTOP) continue;
                if ((rDetail["stop", DataRowVersion.Original] == DBNull.Value) &&
                    (rDetail["stop", DataRowVersion.Current] != DBNull.Value)) {
                    string filtroBrother = QHC.MCmp(rDetail,
                        new string[] {"idmankind", "yman", "nman", "idgroup"});

                    foreach (DataRow rBrother in DS.mandatedetail.Select(filtroBrother)) {
                        object brtDate = rBrother["stop"];
                        if ((brtDate == null) || (brtDate == DBNull.Value)) {
                            if (viewMessage) {
                                show(this,
                                    "E' stata impostata la data di annullamento di un dettaglio suddiviso," +
                                    "tutti gli altri dettagli che compongono il dettaglio originale verranno annullati",
                                    "Avviso", MessageBoxButtons.OK);
                                viewMessage = false;
                            }

                            rBrother["stop"] = currentDate;
                            doSetDatagrid = true;
                        }

                    }
                }

                if ((rDetail["stop", DataRowVersion.Original] != DBNull.Value) &&
                    (rDetail["stop", DataRowVersion.Current] == DBNull.Value)) {
                    string filtroBrother = QHC.MCmp(rDetail,
                        new string[] {"idmankind", "yman", "nman", "idgroup"});

                    foreach (DataRow rBrother in DS.mandatedetail.Select(filtroBrother)) {
                        object brtDate = rBrother["stop"];
                        if ((brtDate != null) && (brtDate != DBNull.Value)) {
                            if (viewMessage) {
                                show(this,
                                    "E' stata rimossa la data di annullamento di un dettaglio suddiviso," +
                                    "tutti gli altri dettagli che compongono il dettaglio originale verranno ripristinati",
                                    "Avviso", MessageBoxButtons.OK);
                                viewMessage = false;
                            }

                            rBrother["stop"] = DBNull.Value;
                            doSetDatagrid = true;
                            }

                    }
                }
            }
            if (doSetDatagrid) {
                //L'ho condizionato per farlo agire solo quando serve
                HelpForm.SetDataGrid(detailgrid, DS.mandatedetail);
                HelpForm.SetDataGrid(dataGridDettAnn, DS.mandatedetail);
                }
            }

        bool abilitaLotti(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 1;
            if (flag == 0) return true;

            return false;
        }

        bool abilitaConsip(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["flag"]) & 2;
            if (flag == 0) return true;

            return false;
        }


        bool abilitaMagazzino(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0) return true;
            int flag = CfgFn.GetNoNullInt32(r[0]["assetkind"]) & 8;
            if (flag != 0) return true;

            return false;
        }

        void VisualizzaNascondiLotti(bool visualizza) {
            grpEsitoGara.Visible = visualizza;
            grpRUP.Visible = visualizza;
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabAnac)) {
                    tabControl1.TabPages.Insert(1, tabAnac);

                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabAnac)) {
                    tabControl1.TabPages.Remove(tabAnac);

                }
            }

            lblcig.Visible = visualizza;
            txtcig.Visible = visualizza;
            VisualizzaBottoneImportaGara(visualizza);
        }

        void VisualizzaNascondiConsip(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabConsip)) {
                    int posizione = 8;
                    if (!tabControl1.TabPages.Contains(tabAnac)) posizione--;
                    if (!tabControl1.TabPages.Contains(tabMagazzino)) posizione--;
                    tabControl1.TabPages.Insert(posizione, tabConsip);
                }

                if (!Meta.IsEmpty) {
                    DataRow Curr = DS.mandate.Rows[0];
                    //HelpForm.SetComboBoxValue(CConsipKind, Curr["idconsipkind"]);
                    //HelpForm.SetComboBoxValue(CConsipKind_ext, Curr["idconsipkind_ext"]);
                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabConsip)) {
                    tabControl1.TabPages.Remove(tabConsip);

                }
            }
        }

        void VisualizzaNascondiMagazzino(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabMagazzino)) {
                    int posizione = 6;
                    if (!tabControl1.TabPages.Contains(tabAnac)) posizione--;
                    tabControl1.TabPages.Insert(posizione, tabMagazzino);
                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabMagazzino)) {
                    tabControl1.TabPages.Remove(tabMagazzino);

                }
            }
        }

        void RiposizionaTabAltro() {
            if (tabControl1.TabPages.Contains(tabAltro)) {
                tabControl1.TabPages.Remove(tabAltro);
            }

            if (!tabControl1.TabPages.Contains(tabAltro)) {
                int posizione = 10;
                if (!tabControl1.TabPages.Contains(tabAnac))
                    posizione--;
                if (!tabControl1.TabPages.Contains(tabAttributi))
                    posizione--;
                if (!tabControl1.TabPages.Contains(tabMagazzino))
                    posizione--;
                if (!tabControl1.TabPages.Contains(tabConsip))
                    posizione--;
                if (!tabControl1.TabPages.Contains(tabRegistroUnico))
                    posizione--;
                tabControl1.TabPages.Insert(posizione, tabAltro);
            }
        }

        void VisualizzaNascondiTabRegistroUnico(bool visualizza) {
            if (visualizza) {
                if (!tabControl1.TabPages.Contains(tabRegistroUnico)) {
                    int posizione = 9;
                    if (!tabControl1.TabPages.Contains(tabAnac))
                        posizione--;
                    if (!tabControl1.TabPages.Contains(tabMagazzino))
                        posizione--;
                    if (!tabControl1.TabPages.Contains(tabAttributi))
                        posizione--;
                    if (!tabControl1.TabPages.Contains(tabConsip))
                        posizione--;

                    tabControl1.TabPages.Insert(posizione, tabRegistroUnico);
                }
            }
            else {
                if (tabControl1.TabPages.Contains(tabRegistroUnico)) {
                    tabControl1.TabPages.Remove(tabRegistroUnico);
                }
            }
        }
        bool rateoOFatturaARicevere(DataRow rDetail) {
            object epkind = rDetail["epkind"];
            return (epkind.ToString().ToUpper() == "F" || epkind.ToString().ToUpper() == "R");
        }

        public void MetaData_BeforeFill() {
            if (DS.mandate.Rows.Count == 0) return;
            if (Meta.InsertMode && Meta.FirstFillForThisRow &&
                DS.mandatedetail._Filter(q.isNotNull("rownum_main")).Length > 0) {
                foreach (var r in DS.mandatedetail._Filter(q.isNotNull("rownum_main"))) {
                    if (r.RowState == DataRowState.Added) r.Delete();
                    }
                }
            DataRow Curr = DS.mandate.Rows[0];
            //if (Meta.FirstFillForThisRow) {
            //    VisualizzaNascondiLotti( abilitaLotti(Curr["idmankind"]));
            //    VisualizzaNascondiMagazzino(abilitaMagazzino(Curr["idmankind"]));
            //    VisualizzaNascondiConsip(abilitaConsip(Curr["idmankind"]));
            //}
            CreaPartecipanteInAutomatico(false);
            int idmanstatus = CfgFn.GetNoNullInt32(Curr["idmandatestatus"]);
            if (Meta.edit_type == "request") {
                //Abilita il salvataggio solo nel caso di "Inserito"=4
                //Meta.CanSave = (idmanstatus == 4);
                btnAccetta.Visible = (idmanstatus == 2);
                btnintegra.Visible = (idmanstatus == 4);
                btnApprova.Visible = (idmanstatus == 4);
                btnAnnulla.Visible = (idmanstatus == 4);
                btnAnnullaApprova.Visible = (idmanstatus == 5 || idmanstatus == 6);
                cmbStatus.Enabled = false;
            }
            else {
                if (!Meta.InsertMode) {
                    idmanstatus = CfgFn.GetNoNullInt32(Curr["idmandatestatus", DataRowVersion.Original]);

                }

                cmbStatus.Enabled = (idmanstatus != 5);
            }

            if (DS.mandatedetail.ExtendedProperties["RigaModificata"] != null) {
                DataRow rMandatedetailMod = DS.mandatedetail.ExtendedProperties["RigaModificata"] as DataRow;
                object NumRigaModificata = rMandatedetailMod["rownum"];
                object idgroupbRigaModificata = rMandatedetailMod["idgroup"];
                if (Meta.InsertMode || Meta.EditMode) {
                    PropagaModificheAiFratelli(rMandatedetailMod);
                }

                DS.mandatedetail.ExtendedProperties["RigaModificata"] = null;
            }

            object curridmankind = Curr["idmankind"];

            if (Meta.FirstFillForThisRow) {
                VisualizzaNascondiLotti(abilitaLotti(curridmankind));
                VisualizzaNascondiConsip(abilitaConsip(curridmankind));
                VisualizzaNascondiMagazzino(abilitaMagazzino(curridmankind));
                VisualizzaNascondiTabRegistroUnico(abilitaRegistroUnico(curridmankind));
                RiposizionaTabAltro();
            }
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo;
            //Propaga la modifica della causale e/o dell'upb al dettaglio fattura collegato
            bool mostramessaggio = false;
            if ((DS.mandatedetail.ExtendedProperties["propagaCausaleUpb"] != null) && (DS.Tables["invoicedetail"] != null)) {

                foreach (var md in DS.mandatedetail.Select()) {
                    //se è una riga nuova o la sto cancellando, la ignoro e esamino la prossima
                    if ((md.RowState == DataRowState.Added) || (md.RowState == DataRowState.Deleted)) continue;
                    if (rateoOFatturaARicevere(md)) continue;
                    object idupb = md["idupb"];
                    object idupb_iva = md["idupb_iva"];

                    foreach (DataRow rInvDet in DS.invoicedetail._Filter(q.eq("idmankind", md["idmankind"])
                            & q.eq("yman", md["yman"]) & q.eq("nman", md["nman"]) & q.eq("manrownum", md["rownum"]))) {

                        //info dett. invoice
                        object idaccmotiveInvDet = rInvDet["idaccmotive"];
                        object idupb_inv = rInvDet["idupb"];
                        object idupb_iva_inv = rInvDet["idupb_iva"];

                        //info dett. CP
                        object idaccmotive = md["idaccmotive"];
                        object idsor_siope = md["idsor_siope"];
                        object idlist = md["idlist"];
                        if (idaccmotive == DBNull.Value) continue;

                        if (idaccmotive.ToString() != idaccmotiveInvDet.ToString()
                            || idupb_inv.ToString() != idupb.ToString()
                            || idupb_iva_inv.ToString() != idupb_iva.ToString()
                        )
                            rInvDet["idaccmotive"] = idaccmotive;
                        rInvDet["idsor_siope"] = idsor_siope;
                        rInvDet["idlist"] = idlist;
                        rInvDet["idupb"] = idupb;
                        rInvDet["idupb_iva"] = idupb_iva;

                        Meta.MarkTableAsNotEntityChild(DS.invoicedetail);

                        if (EPM.EP.attivo) {
                            DataRow[] rEntriesOld = EPM.EP.GetAccMotiveDetailsYear(idaccmotiveInvDet, rInvDet["yinv"]);
                            object oldIdAcc = DBNull.Value;
                            if (rEntriesOld.Length > 0) {
                                oldIdAcc = rEntriesOld[0]["idacc"];
                            }

                            DataRow[] rEntriesNew = EPM.EP.GetAccMotiveDetailsYear(idaccmotive, rInvDet["yinv"]);
                            object newIdAcc = DBNull.Value;
                            if (rEntriesNew.Length > 0) {
                                newIdAcc = rEntriesNew[0]["idacc"];
                            }
                            else {
                                MetaFactory.factory.getSingleton<IMessageShower>()
                                    .Show("La causale del dettaglio " + md["detaildescription"] + " non è configurata nell'anno.", "Errore");
                                continue;
                            }
                            if (idupb_inv.ToString() != idupb.ToString() || idupb_iva_inv.ToString() != idupb_iva.ToString()
                                || (newIdAcc != DBNull.Value && oldIdAcc.ToString() != newIdAcc.ToString())) {

                                mostramessaggio = true;
                            }
                        }
                    }
                }
                if (mostramessaggio) {
                    string msg = "E' stato modificato l'UPB o la Casuale EP. Rigenerare le scritture EP della fattura collegata al Contratto Passivo.";
                    var shower = MetaFactory.factory.getSingleton<IMessageShower>();
                    shower.Show(null, msg, "AVVISO IMPORTANTE", MessageBoxButtons.OK);
                }

                DS.mandatedetail.ExtendedProperties["propagaCausaleUpb"] = null;

            }
        }

        /// <summary>
        /// Restituisce 1 se collegato a preimpegno  di budget (ossia richiesta d'ordine)  o 2 se collegato ad impegno di budget
        /// </summary>
        /// <returns></returns>
        int getEpPhase() {
            if (Meta.edit_type == "request") return 1;
            return 2;
        }

        object getMinCig() {
            object mincig = DBNull.Value;
            foreach (DataRow r in DS.mandatedetail.Select(QHC.IsNotNull("cigcode"))) {
                if (mincig == DBNull.Value) {
                    mincig = r["cigcode"];
                    continue;
                }

                if (mincig.ToString().CompareTo(r["cigcode"].ToString()) > 0) {
                    mincig = r["cigcode"];
                }
            }

            return mincig;
        }

        void CheckCig() {
            if (DS.mandatedetail.Select(QHC.IsNotNull("cigcode")).Length == 0) {
                txtcig.ReadOnly = false;
                return;
            }

            if (DS.mandatecig.Select().Length == 0) {
                txtcig.ReadOnly = false;
                return;
            }

            Current = DS.mandate.Rows[0];
            object maincig = Current["cigcode"];
            if (maincig != DBNull.Value && DS.mandatedetail.Select(QHC.CmpEq("cigcode", maincig)).Length > 0) {
                txtcig.ReadOnly = true;
                return;
            }

            Current["cigcode"] = getMinCig();
            txtcig.Text = Current["cigcode"].ToString();
            txtcig.ReadOnly = true;


        }

        /// <summary>
        /// Allinea le anagrafiche dei dett.a quelle dei lotti ove ci siano le condizioni per farlo
        /// </summary>
        void AllineaAnagraficheDettagliOrdine() {
            object curridmankind = (cmbTipoOrdine.SelectedValue != null) ? cmbTipoOrdine.SelectedValue : DBNull.Value;
            DataRow row_mandatekind = null;
            if (curridmankind != null && curridmankind.ToString() != "") {
                row_mandatekind = DS.mandatekind.Select(QHC.CmpEq("idmankind", curridmankind))[0];
            }

            string flagmultireg_selected = (row_mandatekind == null
                ? ""
                : row_mandatekind["multireg"].ToString().ToUpper());
            if (flagmultireg_selected != "S") {
                return;
            }

            foreach (DataRow cig in DS.mandatecig.Select()) {
                if (cig["idavcp"] == DBNull.Value) continue;
                DataRow[] Ravcp = DS.mandateavcp.Select(QHC.CmpEq("idavcp", cig["idavcp"]));
                if (Ravcp == null || Ravcp.Length == 0) continue;
                object idreg = Ravcp[0]["idreg"];
                if (idreg == DBNull.Value) continue;

                string cigcode = cig["cigcode"].ToString();
                DataRow[] det = DS.mandatedetail.Select(QHC.CmpEq("cigcode", cigcode));
                if (det == null || det.Length == 0) continue;
                foreach (DataRow rdet in det) {
                    //Se non fa parte del team di aggiudicazione lo imposta uguale all'aggiudicatario principale 

                    if (checkIsAggiudicatario(rdet["idreg"], cig["idavcp"]) == false)
                        rdet["idreg"] = idreg;
                }
            }

        }

        bool checkIsAggiudicatario(object idreg, object main_idavcp) {
            if (idreg == DBNull.Value) return false;
            DataRow agg = DS.mandateavcp.Select(QHC.CmpEq("idavcp", main_idavcp))[0];
            if (agg["idreg"].ToString() == idreg.ToString()) return true;
            DataRow[] agg_group = DS.mandateavcp.Select(QHC.CmpEq("idmain_avcp", main_idavcp));
            foreach (DataRow agg_2 in agg_group) {
                if (agg_2["idreg"] == DBNull.Value) continue;
                if (agg_2["idreg"].ToString() == idreg.ToString()) return true;
            }

            return false;
        }


        public void MetaData_AfterFill() {

            if (EPM.esistonoScrittureCollegate()) Meta.CanCancel = false;//9ms
            //gboxValuta.Enabled =  (DS.mandatedetail.Select().Length == 0) ;
            Current = DS.mandate.Rows[0];
            lastApplied = CfgFn.GetNoNullDouble(Current["exchangerate"]);
            //object curr = Current["idmankind"];
            //DataRow rManKind = HelpForm.GetLastSelected(DS.mandatekind);
            //object curridmankind = (rManKind != null) ? rManKind["idmankind"] : null;
            object curridmankind = (cmbTipoOrdine.SelectedValue != null) ? cmbTipoOrdine.SelectedValue : DBNull.Value;
            DataRow row_mandatekind = null;
            if (curridmankind != null && curridmankind.ToString() != "") {
                row_mandatekind = DS.mandatekind.Select(QHC.CmpEq("idmankind", curridmankind))[0];

                // Disabilito la causale di debito se tipo è "Richiesta d'ordine"
                gBoxCausaleDebito.Enabled = row_mandatekind["isrequest"].ToString() != "S";
            }

            if (Meta.FirstFillForThisRow) {
                VisualizzaNascondiLotti(abilitaLotti(curridmankind));
                VisualizzaNascondiConsip(abilitaConsip(curridmankind));
                VisualizzaNascondiMagazzino(abilitaMagazzino(curridmankind));
                VisualizzaNascondiTabRegistroUnico(abilitaRegistroUnico(curridmankind));
                RiposizionaTabAltro();
            }

            lastValidConsipExtIndex = cmbConsip2.SelectedIndex;
            lastValidConsipIndex = cmbConsip1.SelectedIndex;

            btnOrdiniNoLotti.Visible = false;
            btnOrdiniNoPartecipanti.Visible = false;
            btnPartecipantiNonAssociati.Visible = false;
            // Solo se sono in editmode abilito questi bottoni

            MetaData.SetDefault(DS.mandatedetail, "cigcode", DBNull.Value);

            int idconsipkind = CfgFn.GetNoNullInt32(Current["idconsipkind"]);
            VisualizzaBottoneConsip(idconsipkind, true);
            AbilitaDisabilitaConsip_Ext(idconsipkind, true);

            AllineaAnagraficheDettagliOrdine();
            fillConsipLabels();

            CheckCig();

            EPM.mostraEtichette();//115ms, anche molto di più

            if (Meta.EditMode) {
                // Metodo che annulla tutti i fratelli di un dettaglio ove lo stesso sia splittato.
                // Lo richiamo solo in EditMode, in InsertMode non ha davvero senso
                allineaFratelli();
            }

            CalcolaImporto();
            ImpostaTxtValuta();//7ms
            txtEsercOrdine.ReadOnly = true;
            if (Meta.InsertMode) {
                btnSituazione.Enabled = false;
                
                // Solo in inserimento,
                // se non sono stati inseriti nè partecipanti nè lotti è possibile importare una gara
                if (DS.mandateavcp.Count() == 0 && DS.mandatecig.Count() == 0)
                    btnImportaGara.Enabled = true;
                else
                    btnImportaGara.Enabled = false;
            }
            else {
                btnSituazione.Enabled = true;
                btnImportaGara.Enabled = false;
            }



            if (!Meta.IsEmpty) {
                if (row_mandatekind != null) {
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");


                    int act = CfgFn.GetNoNullInt32(row_mandatekind["flagactivity"]);
                    if (act == 4) {
                        //Nessun default
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 1) {
                        //istituz.
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 1);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 2) {
                        //comm.
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 2);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 3) {
                        //promiscuo.
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 3);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "S");
                    }
                }
            }

            if ((Meta.InsertMode) || (Meta.EditMode)) {

                if (DS.mandatedetail.Rows.Count == 0) {
                    AzzeraDefaultDettagli(true);
                    
                    object idupb_selected = (row_mandatekind == null ? DBNull.Value : row_mandatekind["idupb"]);
                    MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);
                }
                else {
                    int maxdetail = CfgFn.GetNoNullInt32(DS.mandatedetail.Compute("max(rownum)", null));
                    if (maxdetail > 0) {
                        DataRow row_mandatedetail = DS.mandatedetail.Select(QHC.CmpEq("rownum", maxdetail))[0];
                        if (row_mandatedetail != null && row_mandatedetail.RowState == DataRowState.Added) {
                            object idupb_selected = row_mandatedetail["idupb"];
                            MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);


                            object cupcode = row_mandatedetail["cupcode"];
                            MetaData.SetDefault(DS.mandatedetail, "cupcode", cupcode);

                            object flagactivity = row_mandatedetail["flagactivity"];
                            MetaData.SetDefault(DS.mandatedetail, "flagactivity", flagactivity);

                            object idSor1 = (row_mandatedetail["idsor1"] != DBNull.Value)
                                ? row_mandatedetail["idsor1"]
                                : null;
                            if (idSor1 != null) {
                                MetaData.SetDefault(DS.mandatedetail, "idsor1", idSor1);
                            }

                            object idSor2 = (row_mandatedetail["idsor2"] != DBNull.Value)
                                ? row_mandatedetail["idsor2"]
                                : null;
                            if (idSor2 != null) {
                                MetaData.SetDefault(DS.mandatedetail, "idsor2", idSor2);
                            }

                            object idSor3 = (row_mandatedetail["idsor3"] != DBNull.Value)
                                ? row_mandatedetail["idsor3"]
                                : null;
                            if (idSor3 != null) {
                                MetaData.SetDefault(DS.mandatedetail, "idsor3", idSor3);
                            }

                            object idcostpartition = (row_mandatedetail["idcostpartition"] != DBNull.Value)
                                ? row_mandatedetail["idcostpartition"]
                                : null;
                            if (idcostpartition != null) {
                                MetaData.SetDefault(DS.mandatedetail, "idcostpartition", idcostpartition);
                            }
                        }
                        else {
                            AzzeraDefaultDettagli(true);
                        }
                    }
                    else {
                        AzzeraDefaultDettagli(true);
                    }
                }
                object idivakind_forced = (row_mandatekind == null ? DBNull.Value : row_mandatekind["idivakind_forced"]);

                if (idivakind_forced != DBNull.Value) {
	                MetaData.SetDefault(DS.mandatedetail, "idivakind", idivakind_forced);

	                DataTable tivakind = Conn.RUN_SELECT("ivakind", "*", null,
		                QHC.CmpEq("idivakind", idivakind_forced), null, null, true);//5ms

	                if (tivakind.Rows.Count > 0) {
		                DataRow RIvaKind = tivakind.Rows[0];
		                object taxrate_forced = RIvaKind["rate"];
		                MetaData.SetDefault(DS.mandatedetail, "taxrate", taxrate_forced);
	                }
	                    
                }
            }

            if (Meta.EditMode) {
                EnableDisableRegistry();

            }

            string flagmultireg_selected = (row_mandatekind == null
                ? ""
                : row_mandatekind["multireg"].ToString().ToUpper());
            if (flagmultireg_selected == "S") {
                groupBox2.Visible = false;
            }
            else {
                groupBox2.Visible = true;
            }

            btnLottiPartecipati.Visible = (DS.mandatecig.Select().Length > 1);
            btnLottiAppaltati.Visible = (DS.mandatecig.Select().Length > 1) && flagmultireg_selected == "S";

            if (flagmultireg_selected == "S") {
                MetaData.SetDefault(DS.mandatecig, "idavcp", DBNull.Value);
            }
            else {
                //CreaPartecipanteInAutomatico();
                object idavcp = findIdavcpByIDreg(Current["idreg"]);
                MetaData.SetDefault(DS.mandatecig, "idavcp", idavcp);
            }


            if (Meta.FirstFillForThisRow && Meta.InsertMode && cmbTipoOrdine.SelectedIndex > 0) {
                if (row_mandatekind != null) {
                    SetNumContratto(row_mandatekind);
                }
            }
            if (Meta.FirstFillForThisRow && DS.mandatedetail.Rows.Count > 0) {
                //DataRow RigaSelezionataGridUp = GetGridSelectedRows(detailgrid);
                //if (RigaSelezionataGridUp != null) {
                //    DataRow row_mandatedetail = DS.mandatedetail.Select(QHC.CmpEq("rownum", RigaSelezionataGridUp["rownum"]))[0];
                //    if (row_mandatedetail["rownum_main"] == DBNull.Value) {
                //        DS.mandatedetail.ExtendedProperties["rownum"] = row_mandatedetail["rownum"];
                //        HelpForm.SetDataGrid(dataGridDettAnn, DS.mandatedetail);
                //        }
                //    }
                }
            if (Meta.InsertMode) {
                if (Current["idmankind_origin"] != DBNull.Value) {
                    cmbTipoOrdine.Enabled = false;
                    object idmankind_origin = Current["idmankind_origin"];

                    DataTable RequestMandatekind = Meta.Conn.RUN_SELECT("requestmandatekind", "idmankind", null,
                        QHS.CmpEq("idmankind_original", idmankind_origin), null, true);
                    string filter = QHC.FieldIn("idmankind", RequestMandatekind.Select());
                    btnTipoOrdine.Tag = "Choose.mandatekind.default" + "." + filter;

                }

                if (cmbTipoOrdine.SelectedIndex > 0) {
                    string tiponumerazione = "S";
                    if (row_mandatekind != null) tiponumerazione = row_mandatekind["flag_autodocnumbering"].ToString();
                    if (tiponumerazione == "S") {
                        txtNumOrdine.ReadOnly = true;
                        txtNumOrdine.PasswordChar = ' ';
                    }
                    else {
                        txtNumOrdine.ReadOnly = false;
                        txtNumOrdine.PasswordChar = Convert.ToChar(0);
                    }
                }
                else {
                    txtNumOrdine.ReadOnly = false;
                    txtNumOrdine.PasswordChar = ' ';
                }
            }

            if (Meta.EditMode) {
                EnableDisableMagazzino();//8ms
            }

            if (Meta.InsertMode) {
                if (Meta.FirstFillForThisRow) {
                    DS.uniqueregister.Clear();
                    abilitaDisabilitaCertificatiRichiesti(null);
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
            CalcolaDataScadenza();//2ms

            if ((!Meta.IsEmpty) && (Meta.FirstFillForThisRow)) {
                AbilitaDisabilitaConsip_Ext(CfgFn.GetNoNullInt32(Current["idconsipkind"]), true);
            }

            if (Meta.EditMode) {
                btnImportFromExcel.Enabled = true;
            }
            else
                btnImportFromExcel.Enabled = false;

        }



        bool abilitaRegistroUnico(object idmankind) {
            DataRow[] r = DS.mandatekind.Select(QHC.CmpEq("idmankind", idmankind));
            if (r.Length == 0)
                return true;
            object touniqueregister = r[0]["touniqueregister"];
            if (touniqueregister.ToString() == "S")
                return true;

            return false;
        }

        public void CreaPartecipanteInAutomatico(bool manual) {
            if (DS.mandateavcp.Select().Length > 0) return;
            DataRow curr = DS.mandate.Rows[0];
            object idreg = curr["idreg"];
            if (idreg == DBNull.Value) return;
            btnAggiungiAggiudicatario.Visible = false;

            if (!Meta.InsertMode && !manual) {
                btnAggiungiAggiudicatario.Visible = true;
                return;
            }

            object curridmankind = curr["idmankind"];
            DataRow row_mandatekind = null;
            if (curridmankind.ToString() != "") {
                row_mandatekind = DS.mandatekind.get(Conn,q.eq("idmankind",curridmankind))._First();

                    //.Select(QHC.CmpEq("idmankind", curridmankind))[0];
            }

            string flagmultireg_selected = (row_mandatekind == null
                ? ""
                : row_mandatekind["multireg"].ToString().ToUpper());
            if (flagmultireg_selected == "S") {
                return;
            }

            //Crea il partecipante
            MetaData mAvcp = MetaData.GetMetaData(this, "mandateavcp");
            mAvcp.SetDefaults(DS.mandateavcp);
            DataRow ravcp = mAvcp.Get_New_Row(curr, DS.mandateavcp);
            DataRow R = DS.registrymainview.get(Conn, q.eq("idreg", idreg))._First();
            if (R==null)return;
                //QHC.CmpEq("idreg", idreg)))[0];
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

        List<string> campi_da_non_copiare = new List<string>(
            new string[] {
                "idmankind", "yman", "nman", "rownum", "idgroup",
                "amount", "taxable", "tax", "unabatable",
                "idupb", "cupcode", "cigcode", "idsor1", "idsor2", "idsor3", "idcostpartition",
                "idexp_taxable", "idexp_iva", "idupb_iva", "idepexp", "idepacc","idexp_pre"
            });

        private void PropagaModificheAiFratelli(DataRow rMandatedetailModified) {
            if (rMandatedetailModified["stop"] != DBNull.Value) return;
            object RowNum = rMandatedetailModified["rownum"];
            object idGroup = rMandatedetailModified["idgroup"];
            // Elenco dei campi modificabili prima di questa modifica, e quindi da non propagare.
            // Tutti gli altri, invece, prima erano ReadOnly, invece ora sono editabili
            // e verranno propagati da noi sui fratelli.


            string filtroBrother = QHC.AppAnd(QHC.CmpNe("rownum", RowNum), QHC.CmpEq("idgroup", idGroup));
            foreach (DataRow rBrother in DS.mandatedetail.Select(filtroBrother)) {
                if (rBrother["stop"] != DBNull.Value) continue;
                double currnpackage = CfgFn.GetNoNullDouble(rBrother["npackage"]);
                double newnpackage = CfgFn.GetNoNullDouble(rMandatedetailModified["npackage"]);
                double curridivakind = CfgFn.GetNoNullDouble(rBrother["idivakind"]);
                double newnidivakind = CfgFn.GetNoNullDouble(rMandatedetailModified["idivakind"]);

                foreach (DataColumn C in DS.mandatedetail.Columns) {
                    if (campi_da_non_copiare.Contains(C.ColumnName)) continue;

                    rBrother[C.ColumnName] = rMandatedetailModified[C.ColumnName];
                }

                //Solo se cambia la q.tà, info che prima non era editabile, dobbiamo modificare l'iva, perchè cambia la base imponibile su cui applicare l'aliquota iva
                if ((currnpackage != newnpackage) || (curridivakind != newnidivakind)) {
                    rBrother["tax"] = CalcolaIvaIvaindetraibile(rBrother, newnpackage, "tax");
                    rBrother["unabatable"] = CalcolaIvaIvaindetraibile(rBrother, newnpackage, "unabatable");
                }

            }

            GetData GD = new GetData();
            GD.InitClass(DS, Conn, "mandatedetail");
            GD.GetTemporaryValues(DS.mandatedetail);
        }

        private double CalcolaIvaIvaindetraibile(DataRow rBrotherSplitted, double newnpackage, string fieldname) {
            DataRow Curr = DS.mandate.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(Curr["exchangerate"]));
            double aliquota =
                CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                    QHS.CmpEq("idivakind", rBrotherSplitted["idivakind"]),
                    "rate"));
            double percindeduc =
                CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                    QHS.CmpEq("idivakind", rBrotherSplitted["idivakind"]),
                    "unabatabilitypercentage"));
            double imponibile = CfgFn.GetNoNullDouble(rBrotherSplitted["taxable"]);
            double quantitaConfezioni = newnpackage;
            double sconto = CfgFn.GetNoNullDouble(rBrotherSplitted["discount"]);
            double imponibiletotEUR = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto) * tassocambio));
            //double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio);
            double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR * aliquota);
            double impindeducEUR = CfgFn.RoundValuta(ivaEUR * percindeduc);
            if (fieldname == "tax") {
                return ivaEUR;
            }

            if (fieldname == "unabatable") {
                return impindeducEUR;
            }

            return 0;
        }

        private void AzzeraDefaultDettagli(bool tipoivanonvincolato) {
            if (tipoivanonvincolato) {
                // idivakind_forced è null, non c'è un tipo iva vincolante.
                MetaData.SetDefault(DS.mandatedetail, "idivakind", DBNull.Value);
                MetaData.SetDefault(DS.mandatedetail, "taxrate", DBNull.Value);
            }

            MetaData.SetDefault(DS.mandatedetail, "idupb", DBNull.Value);
            //MetaData.SetDefault(DS.mandatedetail, "flagactivity", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "idsor1", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "idsor2", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "idsor3", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "idcostpartition", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "cupcode", DBNull.Value);

        }

        public static bool hasChanges(DataTable t) {
            if (t == null) return false;
            foreach (DataRow R in t.Rows) {
                if (R.RowState == DataRowState.Unchanged) continue;
                if (R.RowState != DataRowState.Modified) return true;
                if (PostData.CheckForFalseUpdate(R)) {
                    R.AcceptChanges();
                    continue;
                }

                return true;
            }

            return false;
        }

        private void EnableDisableMagazzino() {
            if (DS.mandatedetail.Rows.Count == 0) {
                gBoxMagazzino.Enabled = true;
                return;
            }

            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            if (hasChanges(DS.mandatedetail)) {
                gBoxMagazzino.Enabled = false;
                return;
            }

            gBoxMagazzino.Enabled = true;
        }

        void CancellaSporcizie() {
            //cancella qualsiasi cadavere in mandateavcpdetail o
            // riferimento da mandatecig a righe inesistenti
            if (Meta.edit_type != "request") {

                foreach (DataRow mcig in DS.mandatecig.Select()) {
                    object idavcp = mcig["idavcp"];
                    if (DS.mandateavcp.Select(QHC.CmpEq("idavcp", idavcp)).Length == 0) {
                        mcig.Delete();
                        continue;
                    }
                }
            }

            foreach (DataRow avdet in DS.mandateavcpdetail.Select()) {
                object cigcode = avdet["cigcode"];
                object idavcp = avdet["idavcp"];
                if (DS.mandatecig.Select(QHC.CmpEq("cigcode", cigcode)).Length == 0) {
                    avdet.Delete();
                    continue;
                }

                if (DS.mandateavcp.Select(QHC.CmpEq("idavcp", idavcp)).Length == 0) {
                    avdet.Delete();
                    continue;
                }

            }
        }

        void AssegnaAutomaticamenteLotti() {
            DataRow curr = DS.mandate.Rows[0];
            //Se non ci sono lotti non c'è nulla da fare
            if (DS.mandatecig.Select().Length == 0) return;

            MetaData manvcpdet = MetaData.GetMetaData(this, "mandateavcpdetail");
            if (DS.mandatecig.Select().Length == 1) {
                //Un solo lotto
                string cigcode = DS.mandatecig.Select()[0]["cigcode"].ToString();
                //per ogni partecipante crea la riga in mandateavcpdetail che lo collega al lotto
                foreach (DataRow part in DS.mandateavcp.Select()) {
                    object idavcp = part["idavcp"];
                    string chk = QHC.AppAnd(QHC.CmpEq("cigcode", cigcode),
                        QHC.CmpEq("idavcp", idavcp));
                    if (DS.mandateavcpdetail.Select(chk).Length > 0) continue;
                    manvcpdet.SetDefaults(DS.mandateavcpdetail);
                    MetaData.SetDefault(DS.mandateavcpdetail, "idavcp", idavcp);
                    MetaData.SetDefault(DS.mandateavcpdetail, "cigcode", cigcode);
                    DataRow newdet = manvcpdet.Get_New_Row(curr, DS.mandateavcpdetail);

                }

                foreach (DataRow r in DS.mandatedetail.Select()) {
                    if (r["cigcode"] == DBNull.Value) r["cigcode"] = cigcode;
                }

                if (curr["cigcode"] == DBNull.Value) {
                    curr["cigcode"] = cigcode;
                }
            }

            object mainidreg = curr["idreg"];
            object idavcpmain = findIdavcpByIDreg(mainidreg);

            //Assegna l'anagrafica appaltante come partecipante a tutti i lotti ove già non lo sia
            foreach (DataRow rd in DS.mandatedetail.Select()) {
                object cigcode = rd["cigcode"];
                if (cigcode == DBNull.Value) continue;
                object idreg = rd["idreg"];
                object idavcp = idavcpmain;
                if (idavcp == DBNull.Value) idavcp = findIdavcpByIDreg(idreg);
                if (idavcp == DBNull.Value) continue;

                string chk = QHC.AppAnd(QHC.CmpEq("cigcode", cigcode),
                    QHC.CmpEq("idavcp", idavcp));
                if (DS.mandateavcpdetail.Select(chk).Length > 0) continue;
                manvcpdet.SetDefaults(DS.mandateavcpdetail);
                MetaData.SetDefault(DS.mandateavcpdetail, "idavcp", idavcp);
                MetaData.SetDefault(DS.mandateavcpdetail, "cigcode", cigcode);
                DataRow newdet = manvcpdet.Get_New_Row(curr, DS.mandateavcpdetail);

            }

            //Assegna automaticamente i lotti appaltati in base alle anagrafiche
            //  dell'ordine e dei dettagli
            foreach (DataRow rd in DS.mandatedetail.Select()) {
                object cigcode = rd["cigcode"];
                if (cigcode == DBNull.Value) continue;
                object idreg = rd["idreg"];
                object idavcp = idavcpmain;
                if (idavcp == DBNull.Value) idavcp = findIdavcpByIDreg(idreg);
                if (idavcp != DBNull.Value) Appalta(idavcp, cigcode);
            }

        }

        object findIdavcpByIDreg(object idreg) {
            if (idreg == DBNull.Value) return DBNull.Value;
            DataRow[] f = DS.mandateavcp.Select(QHC.CmpEq("idreg", idreg));
            if (f.Length == 0) return DBNull.Value;
            DataRow r = f[0];
            if (r["idmain_avcp"] != DBNull.Value) return r["idmain_avcp"];
            return r["idavcp"];
        }

        void Appalta(object idavcp, object cigcode) {
            DataRow[] mancig = DS.mandatecig.Select(QHC.CmpEq("cigcode", cigcode));
            if (mancig.Length == 0) return;
            if (mancig[0]["idavcp"] != DBNull.Value && idavcp == DBNull.Value) return;
            mancig[0]["idavcp"] = idavcp;
        }



        public void MetaData_BeforePost() {
            if (DS.mandate.Rows.Count == 0) {
                DS.mandatedetail.Clear();
                DS.mandatecig.Clear();
                DS.mandateavcp.Clear();
                DS.mandateattachment.Clear();
                DS.mandateavcpdetail.Clear();
                DS.mandatesorting.Clear();
                return;
            }


            AssegnaAutomaticamenteLotti();
            CancellaSporcizie();

            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            // Add - Invio Mail al cambio stato
            DataRow CurrRow = DS.mandate.Rows[0];
            DoSendMail = false;
            if (CurrRow.RowState != DataRowState.Deleted) {
                CurrentStatus = CfgFn.GetNoNullInt32(CurrRow["idmandatestatus"]);
                int OriginalStatus;
                if (!Meta.InsertMode)
                    OriginalStatus = CfgFn.GetNoNullInt32(CurrRow["idmandatestatus", DataRowVersion.Original]);
                else
                    OriginalStatus = CurrentStatus;


                if (CurrentStatus != OriginalStatus && (CurrentStatus == 3 || CurrentStatus == 5 || CurrentStatus == 6))
                    DoSendMail = true;
                else
                    DoSendMail = false;
            }
            else {
                ScollegaGaraTraspare();
			}


            if (Meta.InsertMode) {
                object curridmankind = DS.mandate.Rows[0]["idmankind"];
                DataRow row_mandatekind = null;
                if (curridmankind != DBNull.Value) {
                    row_mandatekind = DS.mandatekind.Select(QHC.CmpEq("idmankind", curridmankind))[0];
                }

                string flagmultireg_selected = (row_mandatekind == null
                    ? ""
                    : row_mandatekind["multireg"].ToString().ToUpper());
                //if (flagmultireg_selected == "N") {
                //    foreach (DataRow rDett in DS.mandatedetail.Rows) {
                //        rDett["idreg"] = DBNull.Value;
                //    }
                //}
            }

            EPM.beforePost();

            // Riempio l'ArrayList idrelated in due occasioni
            // 1. Se cancello tutto il buono d'ordine
            if (DS.mandate.Rows[0].RowState == DataRowState.Deleted) {
                return;
            }

            // Variazioni sulle contabilizzazioni dei dettagli annullati nell'anno corrente
            DS.expensevar.Clear();
            DS.expensesorted.Clear();
            DS.epexpvar.Clear();
            DS.epexpsorting.Clear();

            foreach (DataRow rDettaglio in DS.mandatedetail.Rows) {
                if ((rDettaglio.RowState != DataRowState.Modified)
                    && (rDettaglio.RowState != DataRowState.Added))
                    continue;

                //Di qui non passa mai 
                //if (rDettaglio.RowState == DataRowState.Deleted) {
                //    int yearOriginalSTOP = rDettaglio["stop", DataRowVersion.Original] == DBNull.Value
                //                               ? 0
                //                               : ((DateTime)rDettaglio["stop", DataRowVersion.Original]).Year;
                //    if (yearOriginalSTOP == 0) {
                //        //è come se stessimo stiamo annullando un dettaglio contabilizzato.
                //        generaVariazione("-", rDettaglio);
                //    }
                //}

                if (rDettaglio.RowState == DataRowState.Modified) {
                    int yearOriginalStart = rDettaglio["start", DataRowVersion.Original] == DBNull.Value
                        ? 0: ((DateTime) rDettaglio["start", DataRowVersion.Original]).Year;
                    int yearCurrentStart = rDettaglio["start"] == DBNull.Value? 0
                        : ((DateTime) rDettaglio["start"]).Year;
                    int yearOriginalStop = rDettaglio["stop", DataRowVersion.Original] == DBNull.Value
                        ? 0: ((DateTime) rDettaglio["stop", DataRowVersion.Original]).Year;
                    int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["stop"]).Year;
                    bool todo = true;
                    if (todo && yearOriginalStop == 0 && yearCurrentStop > 0 && yearCurrentStop == esercizio) {
                        //stiamo annullando un dettaglio contabilizzato. La sostituzione di norma non segue questo metodo
                        // ossia è una azione manuale dell'utente
                        generaVariazione("-", rDettaglio);
                        todo = false;
                    }

                    if (todo && yearOriginalStop > 0 && yearCurrentStop == 0 && yearOriginalStop == esercizio) {
                        //stiamo togliendo la data stop, con una azione che annulla quella precedente. La sostituzione di norma
                        // non segue questo metodo
                        generaVariazione("+", rDettaglio);
                        todo = false;
                    }

                    if (todo &&
                        ((yearOriginalStart == 0 && yearCurrentStart > 0) ||
                         (yearOriginalStart > 0 && yearCurrentStart > 0 && ImportoVariato(rDettaglio)
                         )
                        )

                        && yearCurrentStart == esercizio) {
                        //Questo è un dettaglio che già era contabilizzato, e che stiamo modificando. Nelle righe aggiunte
                        // vi sarà una riga con i valori uguali a quelli originali di questo dettaglio, e data stop valorizzata
                        generaVariazione("+", rDettaglio);
                        todo = false;
                        //>>l'operazione "manuale" di mettere una data inizio ad un dettaglio contabilizzato va impedita di norma, fisicamente
                    }
                }
                else {
                    //Se il dettaglio è in stato di inserimento, crea una variazione su esso
                    int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["stop"]).Year;

                    if (yearCurrentStop != 0 && yearCurrentStop == esercizio) {
                        generaVariazione("-", rDettaglio);
                    }
                }

                if (rDettaglio.RowState == DataRowState.Added) {
                    int yearCurrentStart = rDettaglio["start"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["start"]).Year;
                    int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["stop"]).Year;

                    if (yearCurrentStop ==0 && yearCurrentStart > 0 && yearCurrentStart == esercizio) {
                        //Questo è un dettaglio creato con il rimpiazzo, è nuovo e acquisisce l'idexp del dettaglio annullato
                        generaVariazione("+", rDettaglio);
                    }
                }

            }

            foreach (DataRow NewVar in DS.expensevar.Select()) {
                if (CfgFn.GetNoNullDecimal(NewVar["amount"]) == 0) NewVar.Delete();
            }


            if (DS.expensevar.Select().Length > 0) {
                if (show("Sono stati variati alcuni dettagli del contratto. " +
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

            if (DS.expensevar.Rows.Count > 0) {
                Form mv = new FrmManage_Var(DS, Meta.Conn, Meta.Dispatcher, "E");
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(mv, null);
                DialogResult dr = mv.ShowDialog();
                if (dr != DialogResult.OK) {
                    DS.expensevar.Clear();
                    DS.expensesorted.Clear();
                }
            }

            //if (DS.epexpvar.Rows.Count > 0) {
            //    Form mv_ep = new FrmManageEpExpVar(DS, Meta.Conn, Meta.Dispatcher);
            //    DialogResult dr = mv_ep.ShowDialog();
            //    if (dr != DialogResult.OK) {
            //        DS.epexpvar.Clear();
            //        DS.epexpsorting.Clear();
            //    }
            //}
        }

        bool changedCol(DataRow r, string col) {
            if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Deleted) return true;
            return r[col, DataRowVersion.Current].ToString() != r[col, DataRowVersion.Original].ToString();
        }

        bool someChangedCol(DataRow r, params string[] col) {
            foreach (string c in col) {
                if (changedCol(r, c)) return true;
            }

            return false;
        }

        bool unchangedCol(DataRow r, params string[] col) {
            return !someChangedCol(r, col);
        }

        //void allineaDettagliFattura() {
        //    foreach (DataRow r in DS.mandatedetail.Select()) {
        //        if (r.RowState == DataRowState.Added) continue;
        //        if (r.RowState == DataRowState.Unchanged) continue;
        //        string[] fields = new string[] { "start", "stop", "idaccmotive", "idaccmotiveannulment",
        //            "idcostpartition", "idupb", "idsor1", "idsor2", "idsor3"};
        //        if (unchangedCol(r, fields)) continue;
        //        DataRow[] ii = DS.invoicedetail.Select(QHC.AppAnd(
        //            QHC.CmpEq("idmankind", r["idmankind"]),
        //            QHC.CmpEq("yman", r["yman"]),
        //            QHC.CmpEq("nman", r["nman"]),
        //            QHC.CmpEq("manrownum", r["nman"])
        //            ));
        //        if (ii.Length == 0) continue;
        //        foreach (DataRow i in ii) {
        //            foreach (string field in fields) {
        //                if (changedCol(r, field)) {
        //                    i[field] = r[field];
        //                }
        //            }
        //        }
        //    }
        //}

        bool ImportoVariato(DataRow R) {
            return someChangedCol(R, "taxable", "tax", "npackage", "discount");
        }

        private void generaVariazione(string segno, DataRow rDettaglio) {
            generaVariazioneFinanziaria(segno, rDettaglio);
            //if (GeneraImpegniBudget) generaVariazioneEP(segno, rDettaglio);
        }


        private void generaVariazioneFinanziaria(string segno, DataRow rDettaglio) {
            DataRowVersion toConsider = DataRowVersion.Current;
            if (rDettaglio.RowState == DataRowState.Deleted) {
                toConsider = DataRowVersion.Original;
            }

            decimal sign = (segno == "+") ? 1 : -1;

            // vedo se esiste una variazione su quell'idexp_taxable, se non c'è la crea
            if (rDettaglio["idexp_taxable", toConsider] != DBNull.Value) {
                string filterVar = QHC.AppAnd(QHC.CmpEq("adate", Meta.GetSys("datacontabile")), QHC.CmpEq("idexp",
                    rDettaglio["idexp_taxable", toConsider]));
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
                    CurrVar["idexp"] = rDettaglio["idexp_taxable", toConsider];
                    string what = (segno == "+") ? "Ripristino" : "Annullamento o sostituzione o cancellazione ";
                    CurrVar["description"] = what + " dett. contratto passivo " +
                                             rDettaglio["idmankind", toConsider].ToString() + "/" +
                                             rDettaglio["yman", toConsider].ToString() + "/" +
                                             rDettaglio["nman", toConsider].ToString();
                }

                DataRow Contratto = DS.mandate.Rows[0];
                decimal tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
                if (tassocambio == 0) tassocambio = 1;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(rDettaglio["taxable", toConsider]);
                decimal R_quantitaConfezioni = CfgFn.GetNoNullDecimal(rDettaglio["npackage", toConsider]);
                decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(rDettaglio["discount", toConsider]), 6);
                decimal taxable_euro =
                    CfgFn.RoundValuta((R_imponibile * R_quantitaConfezioni * (1 - R_sconto)) * tassocambio);

                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) + taxable_euro * sign;

            }

            //vedo se esiste una variazione su quell'idexp_iva, se non c'è la crea
            if (rDettaglio["idexp_iva", toConsider] != DBNull.Value) {
                string filterVar = QHC.AppAnd(QHC.CmpEq("adate", Meta.GetSys("datacontabile")),
                    QHC.CmpEq("idexp", rDettaglio["idexp_iva", toConsider]));
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
                    CurrVar["idexp"] = rDettaglio["idexp_iva", toConsider];
                    string what = (segno == "+") ? "Ripristino" : "Annullamento o sostituzione o cancellazione ";
                    CurrVar["description"] = what + " dett. contratto passivo " +
                                             rDettaglio["idmankind", toConsider].ToString() + "/" +
                                             rDettaglio["yman", toConsider].ToString() + "/" +
                                             rDettaglio["nman", toConsider].ToString();
                }

                DataRow Contratto = DS.mandate.Rows[0];
                decimal tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
                if (tassocambio == 0) tassocambio = 1;
                decimal R_imposta = CfgFn.GetNoNullDecimal(rDettaglio["tax", toConsider]);
                //iva_euro = CfgFn.RoundValuta(R_imposta * tassocambio);
                decimal iva_euro = CfgFn.RoundValuta(R_imposta); //consideriamo l'iva già in euro

                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) + iva_euro * sign;

            }
        }

        public void MetaData_AfterPost() {
            if (DoSendMail) {
                string ManKindDesc = "";
                string MsgBody = "";
                DataRow CurrentRow = DS.mandate.Rows[0];

                if (CurrentRow["idman"] == null) return;
                string CurrentIdMandateKind = CurrentRow["idmankind"].ToString();

                string currstatustext = "";
                switch (CurrentStatus) {
                    case 3:
                        currstatustext = "Da Correggere";
                        break;
                    case 5:
                        currstatustext = "Approvato";
                        break;
                    case 6:
                        currstatustext = "Annullato";
                        break;
                }

                DataRow[] RowsManKind = DS.mandatekind.Select(QHC.CmpEq("idmankind", CurrentIdMandateKind));
                if (RowsManKind.Length == 0) return;


                ManKindDesc = RowsManKind[0]["description"].ToString();

                // Indirizzo e-mail a cui si intende inviare la notifica della richiesta ordine di materiale pericoloso
                string mailto_danger = RowsManKind[0]["dangermail"].ToString();

                // Trovare l'indirizzo e-mail del responsabile mediante idman
                int idman = CfgFn.GetNoNullInt32(CurrentRow["idman"]);
                string filter = QHS.CmpEq("idman", idman);

                DataTable T = Conn.RUN_SELECT("manager", "*", null, filter, null, false);

                if (T == null || T.Rows.Count == 0) return;
                if (T.Rows[0]["wantswarn"].ToString().ToUpper() != "S") return;

                MsgBody = "Il contratto passivo numero " + CurrentRow["nman"] + " relativo all'esercizio " +
                          CurrentRow["yman"] + " di tipo '" + ManKindDesc + "'\r\n";
                MsgBody += "E' passato nello stato '" + currstatustext + "'.\r\n";

                MsgBody += "Descrizione:\r\n";
                MsgBody += CurrentRow["description"].ToString() + "\r\n";

                if (CurrentRow["applierannotations"].ToString() != "") {
                    MsgBody += "Note del richiedente:\r\n";
                    MsgBody += CurrentRow["applierannotations"].ToString() + "\r\n";
                }

                MsgBody += "Dettagli:\r\n";
                foreach (DataRow R in DS.mandatedetail.Select()) {
                    MsgBody += GetDetailDescription(CurrentRow, R);
                    MsgBody += "\r\n";
                }


                string mailto = T.Rows[0]["email"].ToString();
                if (mailto != "") {
                    SendMail SM = new SendMail();
                    SM.UseSMTPLoginAsFromField = true;
                    SM.To = mailto;
                    SM.Subject = "Notifica cambiamento di stato contratto passivo";
                    SM.MessageBody = MsgBody;
                    SM.Conn = Conn;
                    DoSendMail = false;
                    if (!SM.Send()) {
                        if (SM.ErrorMessage.Trim() != "")
                            show(SM.ErrorMessage, "Errore");
                        //ShowClientMessage(SM.ErrorMessage, "Errore");
                    }
                }

                if ((CurrentStatus == 5) && (CurrentRow["flagdanger"].ToString() == "S") && mailto_danger != "") {

                    SendMail SM_danger = new SendMail();
                    SM_danger.UseSMTPLoginAsFromField = true;
                    SM_danger.To = mailto_danger;
                    SM_danger.Subject = "Avviso di ordine con materiale pericoloso o radioattivo";
                    SM_danger.MessageBody = MsgBody;
                    SM_danger.Conn = Conn;
                    DoSendMail = false;
                    if (!SM_danger.Send()) {
                        if (SM_danger.ErrorMessage.Trim() != "")
                            show(SM_danger.ErrorMessage, "Errore");
                    }

                }
            }


            //if (Meta.edit_type == "default") {
            EPM.afterPost();
            //}


            VisualizzaNumeroRegistroUnico();
        }


        private string GetDetailDescription(DataRow Main, DataRow R) {
            double tassocambio = CfgFn.GetNoNullDouble(Main["exchangerate"]);
            double imponibile = CfgFn.GetNoNullDouble(R["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(R["npackage"]);
            //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(R["discount"]);
            double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
            double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio);



            string S = "";
            S += "Descrizione: " + R["detaildescription"].ToString() + "\r\n";
            S += "Quantità: " + quantita.ToString("n") + "\r\n";
            S += "Imponibile unitario: " + imponibile.ToString("n") + "\r\n";
            if (tassocambio != 1) {
                S += "Imponibile totale: " + imponibiletot.ToString("n") + "\r\n";
                S += "Imponibile totale euro: " + imponibiletotEUR.ToString("c") + "\r\n";
            }
            else {
                S += "Imponibile totale: " + imponibiletot.ToString("c") + "\r\n";
            }


            return S;
        }


        private void EnableDisableRegistry() {
            string filter_invoice =
                QHC.AppAnd(QHC.CmpEq("idmankind", Current["idmankind"]),
                    QHC.CmpEq("yman", Current["yman"]), QHC.CmpEq("nman", Current["nman"]));
            int LinkedDet = DS.invoicedetail.Select(filter_invoice).Length;
            if (LinkedDet == 0)
                txtCredDeb.ReadOnly = false;
            else
                txtCredDeb.ReadOnly = true;
        }

        private decimal RoundDecimal6(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta * 10000000);
            if (truncated > 0) {
                if ((truncated % 10) >= 5) truncated += 5;
            }
            else {
                if (((-truncated) % 10) >= 5) truncated -= 5;
            }

            truncated = truncated / 10;
            truncated = Decimal.Truncate(truncated);
            return truncated / 1000000;
            //			SqlDecimal SQLV = new SqlDecimal(valuta);
            //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
        }

        private void CalcolaImporto() {
            decimal imponibile = 0;
            decimal imposta = 0;
            decimal totale = 0;
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }

            tassocambio = RoundDecimal6(tassocambio);
            int prevgroup = -1;
            decimal totimponibile_currgroup = 0;
            decimal lastexpr = 0;
            foreach (DataRow R in DS.mandatedetail.Select(null, "idgroup")) {
                //if (R.RowState== DataRowState.Deleted) continue;
                if (R["stop"] != DBNull.Value) continue;
                int currgroup = CfgFn.GetNoNullInt32(R["idgroup"]);
                if (currgroup != prevgroup) {
                    imponibile += lastexpr;
                    totimponibile_currgroup = 0;
                    prevgroup = currgroup;
                }

                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                //decimal R_imposta  = RoundDecimal6(CfgFn.GetNoNullDecimal(R["taxrate"]));
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                imposta += CfgFn.RoundValuta(R_imposta); //ora consideriamo l'iva già in euro e non in valuta
                totimponibile_currgroup += R_imponibile;
                lastexpr = CfgFn.RoundValuta((totimponibile_currgroup * R_quantitaConfezioni * (1 - R_sconto)) *
                                             tassocambio);
            }

            imponibile += lastexpr;
            totale = imponibile + imposta;
            decimal imponibileEUR = CfgFn.RoundValuta(imponibile);
            decimal impostaEUR = CfgFn.RoundValuta(imposta);
            decimal totaleEUR = CfgFn.RoundValuta(totale);
            //imponibile=MetaData.SumColumn(MyTable, "imponibile");
            txtImponibile.Text = imponibileEUR.ToString("c");
            txtIva.Text = impostaEUR.ToString("c");
            txtTotale.Text = totaleEUR.ToString("c");
        }

        public void MetaData_BeforeClear() {

        }

        public void MetaData_AfterClear() {
            lastApplied = 0;
            Meta.CanCancel = true;
            DS.invoicedetail.Clear();
            lastValidConsipExtIndex = cmbConsip2.SelectedIndex;
            lastValidConsipIndex = cmbConsip1.SelectedIndex;

            gboxValuta.Enabled = true;

            VisualizzaBottoneConsip(0, true);
            AbilitaDisabilitaConsip_Ext(0, true);
            abilitaDisabilitaCertificatiRichiesti(null);

            VisualizzaNascondiLotti(true);
            VisualizzaNascondiConsip(true);
            VisualizzaNascondiMagazzino(true);
            VisualizzaNascondiTabRegistroUnico(true);
            RiposizionaTabAltro();

            VisualizzaBottoneImportaGara(false);

            btnImportaGara.Visible = false;

            btnOrdiniNoLotti.Visible = true;
            btnOrdiniNoPartecipanti.Visible = true;
            btnPartecipantiNonAssociati.Visible = true;

            txtCambio.ReadOnly = false;
            txtEsercOrdine.Text = Meta.GetSys("esercizio").ToString();
            txtEsercOrdine.ReadOnly = false;
            txtCredDeb.ReadOnly = false;
            btnSituazione.Enabled = false;
            // Se la tabella wsgara è vuota significa che il cliente non usa il servizio
            btnImportaGara.Enabled = false;
            txtcig.ReadOnly = false;

            groupBox2.Visible = true;
            EPM.mostraEtichette();
            //VisualizzaEtichetteEP();
            DataColumn C = DS.mandate.Columns["nman"];
            RowChange.ClearAutoIncrement(C);
            RowChange.ClearCustomAutoIncrement(C);
            txtNumOrdine.ReadOnly = false;
            txtNumOrdine.PasswordChar = Convert.ToChar(0);
            gBoxMagazzino.Enabled = true;

            if (Meta.edit_type == "request") {
                //Abilita il salvataggio solo nel caso di "Inserito"=4
                btnAccetta.Visible = false;
                btnintegra.Visible = false;
                btnApprova.Visible = false;
                btnAnnullaApprova.Visible = false;
                cmbStatus.Enabled = true;
            }

            AzzeraDefaultDettagli(false);
            MetaData.SetDefault(DS.mandatedetail, "idivakind", DBNull.Value);
            MetaData.SetDefault(DS.mandatedetail, "taxrate", DBNull.Value);
            txtTotale.Text = "";
            txtImponibile.Text = "";
            txtIva.Text = "";
            VisualizzaNumeroRegistroUnico();
            AbilitaDisabilitaRegistroUnico();
            txtProgressivoRU.ReadOnly = false;
            btnTipoOrdine.Tag = "Choose.mandatekind.default";
            ShowHideExtConsip(true);
            //if (CConsipKind != null) CConsipKind.SelectedIndex = -1;
            //if (CConsipKind_ext != null) CConsipKind_ext.SelectedIndex = -1; 
            initConsipLabel();
            btnImportFromExcel.Enabled = false;
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo;
            chkRecuperoIvaIntraExtra.Enabled = true;
            Meta.UnMarkTableAsNotEntityChild(DS.invoicedetail);
        }

        void initConsipLabel() {
            if (DS.consipkind.Select(QHC.CmpEq("flagheader", "S")).Length == 1) {
                DataRow r = DS.consipkind.Select(QHC.CmpEq("flagheader", "S"))[0];
                mainLabelConsip.Text = r["description"].ToString();
            }
            else {
                mainLabelConsip.Text = "";
            }

            if (Consip2Disabilitato) return;
            if (DS.consipkind_ext.Select(QHC.CmpEq("active", "S")).Length == 0) {
                Consip2Disabilitato = true;
                return;
            }

            if (DS.consipkind_ext.Select(QHC.CmpEq("flagheader", "S")).Length == 1) {
                DataRow r = DS.consipkind_ext.Select(QHC.CmpEq("flagheader", "S"))[0];
                labelConsipExt.Text = r["description"].ToString();
            }
            else {
                labelConsipExt.Text = "";
            }
        }

        void fillConsipLabels() {
            initConsipLabel();
            DataRow r = DS.mandate.Rows[0];
            int idconsipkind = CfgFn.GetNoNullInt32(r["idconsipkind"]);
            if (idconsipkind > 0 && DS.consipkind.Select(QHC.CmpEq("idconsipkind", idconsipkind)).Length > 0) {
                DataRow c = DS.consipkind.Select(QHC.CmpEq("idconsipkind", idconsipkind))[0];
                mainLabelConsip.Text = getHeaderForConsipRow(c);
            }

            int idconsipkind_ext = CfgFn.GetNoNullInt32(r["idconsipkind_ext"]);
            if (idconsipkind_ext > 0 &&
                DS.consipkind_ext.Select(QHC.CmpEq("idconsipkind", idconsipkind_ext)).Length > 0) {
                DataRow c = DS.consipkind_ext.Select(QHC.CmpEq("idconsipkind", idconsipkind_ext))[0];
                labelConsipExt.Text = getHeaderForConsipRow(c);
            }
        }


        private void AbilitaDisabilitaRegistroUnico() {
            if ((Meta.IsEmpty) || (DS.mandate.Rows.Count == 0)) {
                grpRegistroUnico.Enabled = true;
                btnCreaRegistroUnico.Enabled = false;
                return;
            }

            DataRow CurrMandate = DS.mandate.Rows[0];
            object tipodoc = CurrMandate["idmankind"];
            if (tipodoc.ToString() == "") {
                grpRegistroUnico.Enabled = false;
                txtProgressivoRU.Text = "";
                txtProtocolloEntrataRU.Text = "";
                txtAnnotazioniRU.Text = "";
                chkSendPCC.Checked = false;
                btnCreaRegistroUnico.Enabled = false;
                return;
            }


            DataRow[] currMankinds = DS.mandatekind.Select(QHC.CmpEq("idmankind", tipodoc));
            if (currMankinds.Length == 0) {
                grpRegistroUnico.Enabled = false;
                //txtProgressivoRU.Text = "";
                //txtProtocolloEntrataRU.Text = "";
                //txtAnnotazioniRU.Text = "";
                chkSendPCC.Checked = false;
                btnCreaRegistroUnico.Enabled = false;
                return;
            }

            DataRow currMankind = currMankinds[0];
            object linktoinvoice = currMankind["linktoinvoice"];
            object touniqueregister = currMankind["touniqueregister"];

            if (linktoinvoice != null && touniqueregister != null &&
                (linktoinvoice.ToString() == "N") && (touniqueregister.ToString() == "S")) {
                grpRegistroUnico.Enabled = true;
                btnCreaRegistroUnico.Enabled = true;
            }
            else {
                grpRegistroUnico.Enabled = false;
                txtProgressivoRU.Text = "";
                txtProtocolloEntrataRU.Text = "";
                txtAnnotazioniRU.Text = "";
                btnCreaRegistroUnico.Enabled = false;
                chkSendPCC.Checked = false;
            }

            if (DS.uniqueregister.Rows.Count > 0) {
                btnCreaRegistroUnico.Enabled = false;
            }
        }

        private void VisualizzaNumeroRegistroUnico() {
            txtProgressivoRU.Text = "";
            if (DS.mandate.Rows.Count == 0 || DS.uniqueregister.Rows.Count == 0) {
                return;
            }

            //se esiste anche sul db allora lo visualizza
            DataRow rMandate = DS.mandate.Rows[0];
            string filter = QHC.MCmp(rMandate, new string[] {"idmankind", "yman", "nman"});
            if ((Meta.Conn.RUN_SELECT_COUNT("uniqueregister", filter, true) > 0)
                && (DS.uniqueregister.Rows.Count > 0)) {
                DataRow Runiqueregister = DS.uniqueregister.Rows[0];
                txtProgressivoRU.Text = Runiqueregister["iduniqueregister"].ToString();
            }
        }

        //Imposta Txt in base a valore in riga corrente
        private void ImpostaTxtValuta() {
            if (Meta.IsEmpty) return;
            object codicevaluta = DS.mandate.Rows[0]["idcurrency"];
            if (codicevaluta == DBNull.Value) {
                ImpostaTxtValuta(null);
            }
            else {
                if (DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta)).Length == 0) {
                    QueryCreator.ShowError(this,
                        "La modalità di pagamento standard del percipiente è associata ad una valuta non valida.",
                        null);
                }
                else {
                    DataRow CurrValuta = DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta))[0];
                    ImpostaTxtValuta(CurrValuta);
                }
            }
        }

        private void SetChildParameter(DataRow ValutaRow) {
            if (Meta.IsEmpty) return;
            if (ValutaRow == null) {
                DS.mandatedetail.ExtendedProperties[MetaData.ExtraParams] = null;
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

            object curr_idman = Current["idman"];
            Params["codiceresponsabile"] = curr_idman;

            DS.mandatedetail.ExtendedProperties[MetaData.ExtraParams] = Params;
            RicalcolaIvaDettagli(CfgFn.GetNoNullDouble(Params["cambio"]));

        }

        private void ImpostaTxtValuta(DataRow ValutaRow) {
            if (ValutaRow == null) {
                txtCambio.ReadOnly = false;
                //txtCambio.Text="";		
                SetValuta(DBNull.Value);
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
                txtCambio.Text = HelpForm.StringValue(tasso, txtCambio.Tag.ToString()); //tasso.ToString("n");
            }
            else {
                txtCambio.ReadOnly = false;
                //txtCambio.Text="";
            }

            txtCambio.ReadOnly = false;
            SetValuta(ValutaRow["idcurrency"]);
            SetChildParameter(ValutaRow);
        }

        private double lastApplied = 0;

        void RicalcolaIvaDettagli(double tasso) {
            if (tasso == lastApplied) return;
            bool someChange = false;
            foreach (var r in DS.mandatedetail.Filter(q.isNull("stop"))) { //.Select(QHC.IsNull("stop")

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

        //private void EnabledDisableTipoBene()
        //{
        //    DataRow Curr = DS.mandatedetail.Rows[0];
        //    string filter = QHS.CmpEq("idmankind", Curr["idmankind"]);
        //    object AssetKind = Conn.DO_READ_VALUE("mandatekind", filter, "assetkind");
        //    int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);
        //    radioInvent.Enabled = ((IAssetKind & 1) != 0);
        //    radioNonInvent.Enabled = ((IAssetKind & 2) != 0);
        //    radioServizi.Enabled = ((IAssetKind & 4) != 0);
        //    radioMagazzino.Enabled = ((IAssetKind & 8) != 0);
        //    rdbAltro.Enabled = ((IAssetKind & 16) != 0);
        //}
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;
            if (T.TableName == "accmotiveapplied_debit") {
                if (!Meta.DrawStateIsDone)
                    return;
                if (Meta.IsEmpty)
                    return;
                //if (R == null) {
                //    return;
                //}
            }

            if (T.TableName == "registrymainview") {
                if (Meta.InsertMode && Meta.DrawStateIsDone && R != null)  ImpostaIntracom(R["residence"]);
                if (R!=null && !Meta.IsEmpty) {
                    
                    DataRow Curr = DS.mandate.Rows[0];
                    Curr["idaccmotivedebit"] = R["idaccmotivedebit"];
                    DS.accmotiveapplied_debit.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_debit,null,
                        (q.eq("idaccmotive", Curr["idaccmotivedebit"]) & q.eq("idepoperation", "fatacq_deb")).toSql(QHS),null,false);
                    Meta.helpForm.FillControls(gBoxCausaleDebito.Controls);
                }
            }


            if (T.TableName == "currency") {
                ImpostaTxtValuta(R);

                UiHelper.UpdateControls(currencyManager, txtCambio, currentRow, txtDataContabile.Text);
                return;
            }

            if (T.TableName == "mandatekind") {
                if (!Meta.IsEmpty) abilitaDisabilitaCertificatiRichiesti(R);
                if (Meta.InsertMode || Meta.EditMode ) {

                    object idupb_selected = (R == null ? "" : R["idupb"]);
                    MetaData.SetDefault(DS.mandatedetail, "idupb", idupb_selected);

                    object idivakind_forced = (R == null ? "" : R["idivakind_forced"]);
                    MetaData.SetDefault(DS.mandatedetail, "idivakind", idivakind_forced);

                    if (idivakind_forced != DBNull.Value) {

                        DataTable tivakind = Conn.RUN_SELECT("ivakind", "*", null,
                            QHC.CmpEq("idivakind", idivakind_forced), null, null, true);

                        if (tivakind.Rows.Count > 0) {
                            DataRow RIvaKind = tivakind.Rows[0];
                            object taxrate_forced = RIvaKind["rate"];

                            MetaData.SetDefault(DS.mandatedetail, "taxrate", taxrate_forced);

                        }
                    }
                    else {
                        MetaData.SetDefault(DS.mandatedetail, "idivakind", DBNull.Value);
                        MetaData.SetDefault(DS.mandatedetail, "taxrate", DBNull.Value);
                    }
                }
                if (Meta.InsertMode) {
	                object idreg_rupanac_selected = (R == null ? DBNull.Value : R["idreg_rupanac"]);
	                DataRow Curr = DS.mandate.Rows[0];
	                if (idreg_rupanac_selected != DBNull.Value) {
		                Curr["idreg_rupanac"] = idreg_rupanac_selected;
	                }
	                else {
		                Curr["idreg_rupanac"] = DBNull.Value;
	                }

	                SetRUP(idreg_rupanac_selected);

                }

            }
            if (T.TableName == "mandatedetail") {
                //if (!Meta.DrawStateIsDone) return;
                //if (R == null) return;
                ////deve agire solo sui dettagli principali
                //if (R["rownum_main"] == DBNull.Value) {
                //    DS.mandatedetail.ExtendedProperties["rownum"] = R["rownum"];
                //    HelpForm.SetDataGrid(dataGridDettAnn, DS.mandatedetail);
                //    }
                }

            if (T.TableName == "mandatekind" && R != null) {

                VisualizzaNascondiLotti(abilitaLotti(R["idmankind"]));
                VisualizzaNascondiConsip(abilitaConsip(R["idmankind"]));
                VisualizzaNascondiMagazzino(abilitaMagazzino(R["idmankind"]));
                VisualizzaNascondiTabRegistroUnico(abilitaRegistroUnico(R["idmankind"]));
                RiposizionaTabAltro();
            }


            if (T.TableName == "mandatekind" && R != null) {
                if (Meta.InsertMode) {
                    impostaSicurezza(R);

                    //aggiorno il codice tipo contratto. dei dettagli
                    object codicetipodoc = (R == null ? "" : R["idmankind"]);
                    DataRow Curr = DS.mandate.Rows[0];
                    Curr["idmankind"] = codicetipodoc;

                    if (R != null) {
                        SetNumContratto(R);
                        foreach (DataRow Dett in DS.mandatedetail.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }

                        foreach (DataRow Dett in DS.mandatesorting.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }

                        foreach (DataRow Dett in DS.mandateattachment.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }

                        foreach (DataRow Dett in DS.mandateavcp.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }

                        foreach (DataRow Dett in DS.mandateavcpdetail.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }

                        foreach (DataRow Dett in DS.mandatecig.Rows) {
                            Dett["idmankind"] = codicetipodoc;
                        }
                    }

                    AbilitaDisabilitaRegistroUnico();
                }

                if (Meta.InsertMode) {
                    DataRow Curr = DS.mandate.Rows[0];
                    object AssetKind = 0;
                    if (Curr["idmankind"].ToString() != "") {
                        AssetKind = DS.mandatekind.Select(QHC.CmpEq("idmankind", Curr["idmankind"]))[0]["assetkind"];
                    }

                    int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);

                    if (R != null) {
                        bool error = false;
                        foreach (DataRow Dett in DS.mandatedetail.Rows) {
                            if ((Dett["assetkind"] != DBNull.Value) && !(error)) {
                                string assetkind = Dett["assetkind"].ToString();
                                if (
                                    ((assetkind == "A") && ((IAssetKind & 1) == 0)) ||
                                    ((assetkind == "P") && ((IAssetKind & 2) == 0)) ||
                                    ((assetkind == "S") && ((IAssetKind & 4) == 0)) ||
                                    ((assetkind == "M") && ((IAssetKind & 8) == 0)) ||
                                    ((assetkind == "O") && ((IAssetKind & 16) == 0))
                                )
                                    error = true;
                            }

                            if (error)
                                show("Alcuni dettagli hanno il valore del campo  " +
                                                "Tipo Bene non compatibile con " +
                                                "la Natura del Contratto Passivo", "Attenzione");

                        }
                    }
                }

                //if (R["multireg"] == DBNull.Value) return;
                string multiReg = R["multireg"].ToString();
                if (multiReg == "S") {
                    if (DS.mandate.Rows.Count > 0) {
                        DataRow CurrRow = DS.mandate.Rows[0];
                        CurrRow["idreg"] = DBNull.Value;
                        txtCredDeb.Text = "";
                    }

                    groupBox2.Visible = false;
                }
                else {
                    groupBox2.Visible = true;
                }

                if (Meta.IsEmpty) return;
                //if (R["idupb"] == DBNull.Value) return;
                if (R["idupb"] != DBNull.Value) {
                    object idman = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", R["idupb"]), "idman");
                    object getman = GetResponsabile();
                    if (idman != DBNull.Value && idman != null) {
                        if (getman != DBNull.Value) {
                            if (getman.ToString() != idman.ToString())
                                show("Il responsabile dell'ordine è stato reimpostato come da UPB");
                        }

                        SetResponsabile(idman);
                    }

                }

                if (R != null) {
                    MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                    MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");

                    int act = CfgFn.GetNoNullInt32(R["flagactivity"]);
                    if (act == 4) {
                        //Nessun default
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 4);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 1) {
                        //istituz.
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 1);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 2) {
                        //istituz.
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 2);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "N");
                    }

                    if (act == 3) {
                        //promiscua
                        MetaData.SetDefault(DS.mandatedetail, "flagactivity", 3);
                        MetaData.SetDefault(DS.mandatedetail, "flagmixed", "S");
                    }
                }

                //if (R != null) {
                //    if (R["linktoinvoice"].ToString() == "S") {
                //        MetaData.SetDefault(DS.mandatedetail, "epkind", "N");
                //    }
                //    else {
                //        MetaData.SetDefault(DS.mandatedetail, "epkind", "N");
                //    }

                //}
            }



            if (T.TableName == "registrymainview") {
                ImpostaCredDeb(R);
                if (!Meta.IsEmpty) CreaPartecipanteInAutomatico(false);
                return;
            }

            if (T.TableName == "store") {
                if (!Meta.DrawStateIsDone) return;
                if (R == null) {
                    txtIndirizzoConsegna.Text = "";
                    return;
                }
                else {
                    string deliveryaddress = R["deliveryaddress"].ToString();
                    txtIndirizzoConsegna.Text = deliveryaddress;
                }

            }

            if (T.TableName == "expirationkind") {
                if (R != null)
                    CalcolaDataScadenza();
            }





        }

        void impostaSicurezza(DataRow TipoContratto) {
            if (!Meta.InsertMode) return;
            if (TipoContratto == null) return;
            Meta.GetFormData(true);
            DataRow curr = DS.mandate.Rows[0];
            bool someChange = false;
            for (int i = 1; i <= 5; i++) {
                string field = "idsor0" + i;
                int idsor0x = CfgFn.GetNoNullInt32(Meta.GetSys(field));
                if (idsor0x == 0) idsor0x = CfgFn.GetNoNullInt32(TipoContratto[field]);
                int currIdsor = CfgFn.GetNoNullInt32(curr[field]);
                if (currIdsor == idsor0x) continue;
                if (currIdsor != 0) {
                    someChange = true;
                }

                curr[field] = idsor0x;
            }

            if (someChange) {
                //show("Gli attributi di sicurezza sono stati adeguati al nuovo tipo di contratto selezionato", "Avviso");
                Meta.FreshForm(true);
            }
        }

        private object GetResponsabile() {
            return Meta.GetAutoField(txtResponsabile);

        }

        private object GetValuta() {
            return Meta.GetAutoField(txtValuta);
        }


        private void SetValuta(object idcurrency) {
            Meta.SetAutoField(idcurrency, txtValuta);
        }

        private void SetRUP(object idreg_rupanac) {
            Meta.SetAutoField(idreg_rupanac, txtRUP);
        }

        private void SetResponsabile(object idman) {
            Meta.SetAutoField(idman, txtResponsabile);
        }


        private void SetNumContratto(DataRow R) {
            string tiponumerazione = R["flag_autodocnumbering"].ToString();
            DataRow Curr = DS.mandate.Rows[0];
            if (tiponumerazione == "S") {
                RowChange.MarkAsAutoincrement(DS.mandate.Columns["nman"], null, null, 6);
                MetaData.SetDefault(DS.mandate, "nman", -10);
                txtNumOrdine.ReadOnly = true;
                txtNumOrdine.Text = "";
                int N = MetaData.MaxFromColumn(DS.mandate, "nman");
                if (N < 99990000)
                    N = 99990000;
                else
                    N = N + 1;
                Curr["nman"] = N;
                txtNumOrdine.Text = N.ToString();
                txtNumOrdine.PasswordChar = ' ';
                foreach (DataRow Dett in DS.mandatedetail.Rows) {
                    Dett["nman"] = N;
                }

                foreach (DataRow Dett in DS.mandatesorting.Rows) {
                    Dett["nman"] = N;
                }

                foreach (DataRow Dett in DS.mandateattachment.Rows) {
                    Dett["nman"] = N;
                }

                foreach (DataRow Dett in DS.mandateavcp.Rows) {
                    Dett["nman"] = N;
                }

                foreach (DataRow Dett in DS.mandatecig.Rows) {
                    Dett["nman"] = N;
                }

                foreach (DataRow Dett in DS.mandateavcpdetail.Rows) {
                    Dett["nman"] = N;
                }


            }
            else {
                DataColumn C = DS.mandate.Columns["nman"];
                RowChange.ClearAutoIncrement(C);
                RowChange.ClearCustomAutoIncrement(C);
                int nmax = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("mandate",
                               QHS.AppAnd(
                                   QHS.CmpEq("yman", Meta.GetSys("esercizio")),
                                   QHS.CmpEq("idmankind", R["idmankind"])),
                               "MAX(nman)")) + 1;
                MetaData.SetDefault(DS.mandate, "nman", nmax);
                Curr["nman"] = nmax;
                txtNumOrdine.Text = nmax.ToString();
                txtNumOrdine.ReadOnly = false;
                txtNumOrdine.PasswordChar = Convert.ToChar(0);
                foreach (DataRow Dett in DS.mandatedetail.Rows) {
                    Dett["nman"] = nmax;
                }

                foreach (DataRow Dett in DS.mandatesorting.Rows) {
                    Dett["nman"] = nmax;
                }

                foreach (DataRow Dett in DS.mandateattachment.Rows) {
                    Dett["nman"] = nmax;
                }

                foreach (DataRow Dett in DS.mandateavcp.Rows) {
                    Dett["nman"] = nmax;
                }

                foreach (DataRow Dett in DS.mandatecig.Rows) {
                    Dett["nman"] = nmax;
                }

                foreach (DataRow Dett in DS.mandateavcpdetail.Rows) {
                    Dett["nman"] = nmax;
                }

            }
            HelpForm.SetDataGrid(detailgrid, DS.mandatedetail);
            HelpForm.SetDataGrid(dataGridDettAnn, DS.mandatedetail);
            }

        private void ImpostaCredDeb(DataRow R) {
            if (R == null) return;
            if (Meta.IsEmpty) return;

            DataRow DefModPag = CfgFn.ModalitaPagamentoDefault(Meta.Conn, R["idreg"]);

            if (DefModPag != null) {
                txtScadenza.Text = DefModPag["paymentexpiring"].ToString();
                HelpForm.SetComboBoxValue(cmbTipoScadenza, DefModPag["idexpirationkind"]);
                DS.mandate.Rows[0]["idcurrency"] = (DefModPag["idcurrency"] != DBNull.Value)
                    ? DefModPag["idcurrency"]
                    : idcurrencyEURO; // "EUR";
                ImpostaTxtValuta();
            }
            else {
                string fDefault = QHC.CmpEq("idcurrency", idcurrencyEURO); // "EUR");
                DataRow[] Currency = DS.Tables["currency"].Select(fDefault);
                if (Currency.Length == 0) return;
                DataRow rCurrency = Currency[0];
                ImpostaTxtValuta(rCurrency);
            }

        }


        private void btnSituazione_Click(object sender, System.EventArgs e) {
            DataAccess Conn = Meta.Conn;
            int esercordine;
            int numordine;
            string idmankind;
            try {
                esercordine = Convert.ToInt16(DS.Tables["mandate"].Rows[0]["yman"]);
                numordine = Convert.ToInt16(DS.Tables["mandate"].Rows[0]["nman"]);
                idmankind = (DS.Tables["mandate"].Rows[0]["idmankind"]).ToString();
            }
            catch {
                return;
            }

            DataSet Out = Conn.CallSP("show_mandate",
                new Object[5] {
                    idmankind,
                    numordine,
                    esercordine,
                    Meta.GetSys("datacontabile"),
                    Meta.GetSys("esercizio")
                }
            );
            if (Out == null) return;
            Out.Tables[0].TableName = "Situazione Ordine";

            frmSituazioneViewer frm = new frmSituazioneViewer(Out);
            createForm(frm, null);
            frm.Show();

        }

        private void btnElimina_Click(object sender, System.EventArgs e) {
        }

        private void txtCambio_TextChanged(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.DrawStateIsDone) CalcolaImporto();
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
            //return R;
            string kFilter = QHC.CmpKey(DV.Row);
            return DS.Tables[TV.TableName].Select(kFilter)[0];
            }

        private void btnDividiDettaglio_Click(object sender, System.EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);
            if (RigaSelezionata == null) return;
            if (RigaSelezionata["stop"] != DBNull.Value) {
                show("Dettaglio annullato", "Avviso");
                return;
            }

            if ((RigaSelezionata["idexp_taxable"] != DBNull.Value) && (RigaSelezionata["idexp_iva"] != DBNull.Value)) {
                show("Dettaglio contabilizzato", "Avviso");
                return;
            }

            DataRow Ordine = DS.mandate.Rows[0];
            decimal totaleImponibile = CfgFn.GetNoNullDecimal(RigaSelezionata["taxable"]);
            decimal totaleIva = CfgFn.GetNoNullDecimal(RigaSelezionata["tax"]);
            frmAskDividi F = new frmAskDividi(Ordine, RigaSelezionata, Meta, Meta.Dispatcher);
            createForm(F, this);
            if (F.ShowDialog(this) != DialogResult.OK) return;

            DataTable Info = F.Info;
            F.Destroy();
            string filter = QHC.AppOr(QHC.CmpNe("taxable", 0), QHC.CmpNe("tax", 0), QHC.CmpNe("unabatable", 0));
            DataRow[] RigheSplittate = Info.Select(filter);
            if (RigheSplittate.Length > 0) {
                RigaSelezionata["idupb"] = RigheSplittate[0]["idupb"];
                RigaSelezionata["taxable"] = RigheSplittate[0]["taxable"];
                RigaSelezionata["tax"] = RigheSplittate[0]["tax"];
                RigaSelezionata["unabatable"] = RigheSplittate[0]["unabatable"];
                // Ciclo per la creazione di nuovi dettagli
                Meta.GetFormData(false);
                MetaData metaDT = MetaData.GetMetaData(this, "mandatedetail");
                metaDT.SetDefaults(DS.mandatedetail);
                if (RigheSplittate.Length > 1) {
                    for (int i = 1; i <= (RigheSplittate.Length - 1); i++) {
                        DataRow rInfo = RigheSplittate[i];
                        DataRow rDT = metaDT.Get_New_Row(Ordine, DS.mandatedetail);
                        rDT["idgroup"] = RigaSelezionata["idgroup"];
                        rDT["taxable"] = rInfo["taxable"];
                        rDT["tax"] = rInfo["tax"];
                        rDT["idupb"] = rInfo["idupb"];
                        rDT["idupb_iva"] = RigaSelezionata["idupb_iva"];
                        rDT["unabatable"] = rInfo["unabatable"];
                        rDT["idreg"] = RigaSelezionata["idreg"];
                        rDT["number"] = CfgFn.GetNoNullDecimal(RigaSelezionata["number"]);

                        rDT["npackage"] = CfgFn.GetNoNullDecimal(RigaSelezionata["npackage"]);
                        rDT["idlist"] = RigaSelezionata["idlist"];
                        rDT["idunit"] = RigaSelezionata["idunit"];
                        rDT["idpackage"] = RigaSelezionata["idpackage"];
                        rDT["unitsforpackage"] = RigaSelezionata["unitsforpackage"];

                        rDT["detaildescription"] = RigaSelezionata["detaildescription"].ToString();
                        rDT["assetkind"] = RigaSelezionata["assetkind"];
                        rDT["idinv"] = RigaSelezionata["idinv"];
                        rDT["idlocation"] = RigaSelezionata["idlocation"];
                        rDT["idexp_taxable"] = RigaSelezionata["idexp_taxable"];
                        rDT["idexp_iva"] = RigaSelezionata["idexp_iva"];
                        rDT["competencystart"] = RigaSelezionata["competencystart"];
                        rDT["competencystop"] = RigaSelezionata["competencystop"];
                        rDT["epkind"] = RigaSelezionata["epkind"];
                        rDT["start"] = RigaSelezionata["start"];
                        rDT["stop"] = RigaSelezionata["stop"];
                        rDT["idivakind"] = RigaSelezionata["idivakind"];
                        rDT["annotations"] = RigaSelezionata["annotations"];
                        rDT["discount"] = RigaSelezionata["discount"];
                        rDT["taxrate"] = RigaSelezionata["taxrate"];
                        rDT["flagmixed"] = RigaSelezionata["flagmixed"];
                        rDT["flagactivity"] = RigaSelezionata["flagactivity"];
                        rDT["idaccmotive"] = RigaSelezionata["idaccmotive"];
                        rDT["idaccmotiveannulment"] = RigaSelezionata["idaccmotiveannulment"];
                        rDT["idsor1"] = RigaSelezionata["idsor1"];
                        rDT["idsor2"] = RigaSelezionata["idsor2"];
                        rDT["idsor3"] = RigaSelezionata["idsor3"];
                        rDT["idcostpartition"] = RigaSelezionata["idcostpartition"];
                        rDT["ninvoiced"] = RigaSelezionata["ninvoiced"];
                        rDT["cupcode"] = RigaSelezionata["cupcode"];
                        rDT["cigcode"] = RigaSelezionata["cigcode"];
                        rDT["flagto_unload"] = RigaSelezionata["flagto_unload"];
                        rDT["expensekind"] = RigaSelezionata["expensekind"];
                        rDT["idpccdebitstatus"] = RigaSelezionata["idpccdebitstatus"];
                        rDT["idpccdebitmotive"] = RigaSelezionata["idpccdebitmotive"];
                        rDT["toinvoice"] = RigaSelezionata["toinvoice"];
                        rDT["va3type"] = RigaSelezionata["va3type"];
                        rDT["applierannotations"] = RigaSelezionata["applierannotations"];
                        rDT["ivanotes"] = RigaSelezionata["ivanotes"];
                        rDT["contractamount"] = RigaSelezionata["contractamount"];
                        rDT["idavcp"] = RigaSelezionata["idavcp"];
                        rDT["idavcp_choice"] = RigaSelezionata["idavcp_choice"];
                        rDT["avcp_stopcontract"] = RigaSelezionata["avcp_stopcontract"];
                        rDT["avcp_description"] = RigaSelezionata["avcp_description"];
                        //rDT["idepexp"] = RigaSelezionata["idepexp"];
                        //rDT["idepacc"] = RigaSelezionata["idepacc"];
                        rDT["idsor_siope"] = RigaSelezionata["idsor_siope"];

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
            for (int i = 0; i < N; i++) result[i] = DIV[i];
            return result;
        }

        private void btnUnisciDettagli_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);
            if (RigaSelezionata == null) return;
            string filtergroup = QHC.CmpEq("idgroup", RigaSelezionata["idgroup"]);
            DataRow[] Selected = DS.mandatedetail.Select(filtergroup, "rownum");
            decimal detailsGroup = Selected.Length;

            if (detailsGroup > 1) {
                decimal taxable = 0;
                decimal tax = 0;
                decimal unabatable = 0;
                object[] upb = ValoriDiversi(Selected, "idupb");
                object[] idexp_taxable = ValoriDiversi(Selected, "idexp_taxable");
                object[] idexp_iva = ValoriDiversi(Selected, "idexp_iva");
                object idupb = DBNull.Value;
                if (upb.Length == 1) {
                    idupb = upb[0];
                }

                // Ciclo per verificare se è possibile riunire i dettagli splittati
                foreach (DataRow DR in Selected) {

                    decimal ninvoiced = CfgFn.GetNoNullDecimal(DR["ninvoiced"]);
                    if (ninvoiced > 0) {
                        show(
                            "Alcuni dettagli dello stesso gruppo sono collegati a fattura. Non è possibile annullare la suddivisione.",
                            "Avviso");
                        return;
                    }

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
                DataRow[] RowToDel = DS.mandatedetail.Select(filterToDel);
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

        class RowPair {
            public DataRow addedRow;
            public DataRow modifiedRow;

            public RowPair(DataRow oldRow, DataRow newRow) {
                addedRow = oldRow.RowState == DataRowState.Added ? oldRow : newRow;
                modifiedRow = oldRow.RowState == DataRowState.Modified ? oldRow : newRow;
                if (addedRow == null || modifiedRow == null) {
                    throw new Exception("Erroneo uso della classe RowPair");
                }
            }

            public void SwapValues(bool IsAnnoCreazione) {
                DataTable T = modifiedRow.Table;
                foreach (DataColumn c in T.Columns) {
                    string field = c.ColumnName;
                    if (QueryCreator.IsPrimaryKey(T, field)) continue; //non scambia la chiave
                    if (field == "idgroup") continue;
                    if (field == "idepexp") continue;
                    if (field == "idepacc") continue;
                    if (field == "rownum_main") {
                        //Se NON siamo nell'anno di creazione del dettaglio, non deve creare la catena.
                        if (!(IsAnnoCreazione)) {
                            //siccome è possibile fare sostituzioni successive, se si sostituisce un dettaglio che ha rowmain valorizzato,  è quello il rowmain da copiare nel dettaglio annullato e non il rownnum.
                            if (modifiedRow["rownum_main"] != DBNull.Value) {
                                addedRow[field] = modifiedRow["rownum_main"];
                                }
                            else {
                                addedRow[field] = modifiedRow["rownum"];
                                }
                            }
                        continue;
                        }
                    object O = modifiedRow[field];
                    modifiedRow[field] = addedRow[field];
                    addedRow[field] = O;
                }
            }
        }

        private bool Commerciale(object idmankind) {
            DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
                        QHS.CmpEq("idmankind", idmankind), null, null, true);
            if (MandateKind == null || MandateKind.Rows.Count == 0) {
                return false;
                }
            int flagactivity = 0;
            flagactivity = CfgFn.GetNoNullInt32(MandateKind.Rows[0]["flagactivity"]);
            if (flagactivity == 2) {
                //commerciale
                return true;
                }
            return false;
            }

        private bool esistonoDettComm_FattureDaRicevere_Rateo() {
            //Se è  un Contratto Commerciale, blocchiamo la sostituzione per i dettagli aventi il pallino su Fatture da ricevere o Rateo
            foreach (DataRow Rdett in DS.mandatedetail.Select()) {
                bool commerciale = Commerciale(Rdett["idmankind"]);
                if (commerciale && (fatturaARicevereOEmettere(Rdett) || rateo(Rdett)))
                    return true;
                }
            return false;
            }
        private void btnSostituisciDettaglio_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                shower.Show(this, "Prima di sostituire il dettaglio bisogna salvare!");
                return;
            }

            DataRow rContratto = DS.mandate.Rows[0];

            //Se è un Contratto Commerciale, blocchiamo la sostituzione per i dettagli aventi il pallino su Fatture da ricevere o Rateo
            if (esistonoDettComm_FattureDaRicevere_Rateo()) {
                shower.Show(this, "Vi sono alcun dettagli marcati come 'Fatture da ricevere o Rateo', per essi si dovrà procedere con L' ANNULLO.");
                }
            // Passo 1. - Scelta del dettaglio da sostituire
            WizSostituisciDettaglio wiz = new WizSostituisciDettaglio(rContratto, Meta.Conn, Meta.Dispatcher);
            createForm(wiz, null);
            DialogResult dr = wiz.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Operazione annullata!");
                return;
            }

            // Passo 2. - Annullamento di tutti i fratelli del dettaglio annullato
            DataRow rDettaglioAnnullato = wiz.rOldDettaglio;
            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] {"idmankind", "yman", "nman", "idgroup"});

            object dataAnnullamento = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStop.Text, "x.y");
            foreach (DataRow rDetail in DS.mandatedetail.Select(filter)) {
                rDetail["stop"] = dataAnnullamento;
                //rDetail["idaccmotiveannulment"] = (wiz.SelectedCasualeAnn != null) ? wiz.SelectedCasualeAnn["idaccmotive"] : DBNull.Value;
                rDetail["idaccmotiveannulment"] = (wiz.idCausaleAnnullamento != null) ? wiz.idCausaleAnnullamento : DBNull.Value;
                if (rDetail["stop"].ToString() != "") {
                    rDetail["toinvoice"] = "N";
                } //TASK 10671 
            }

            List<RowPair> Coppie = new List<RowPair>();
            // Passo 3. - Creazione nuovo dettaglio già splittato
            int idGroup = creaDettagliSplittati(rContratto, wiz, Coppie); //copia tutti i campi, escluso toinvoice

            // Passo 4. - Raffinamento dello split (usando il form dello split già esistente)
            DataRow[] listaDettagliSplittati = DS.mandatedetail.Select(QHC.CmpEq("idgroup", idGroup), "rownum");
            if ((listaDettagliSplittati.Length > 1) && (listaDettagliSplittati.Length <= 10)) {
                frmAskDividi frm = new frmAskDividi(rContratto, listaDettagliSplittati, Meta, Meta.Dispatcher);
                createForm(frm, null);
                DialogResult dr2 = frm.ShowDialog();
                frm.Destroy();
                if (dr2 != DialogResult.OK) {
                    show(this, "Operazione di split annullata");
                    return;
                }
                else {
                    DataTable Info = frm.Info;
                    for (int i = 0; i < Info.Rows.Count; i++) {
                        listaDettagliSplittati[i]["taxable"] = Info.Rows[i]["taxable"];
                        listaDettagliSplittati[i]["tax"] = Info.Rows[i]["tax"];
                        listaDettagliSplittati[i]["unabatable"] = Info.Rows[i]["unabatable"];
                    }
                }
            }
            //Scambia tutti i valori in modo che la riga con stop not null è quella inserted
            foreach (RowPair rp in Coppie) {
                bool IsAnnoCreazione = false; //IsAnnoCreazionedettaglio(rp.modifiedRow); al momento sotto richiesta di Francesco operiamo sempre nella stessa modalità
                rp.SwapValues(IsAnnoCreazione);
                if (CfgFn.GetNoNullDecimal(rp.addedRow["taxable"]) == 0 &&
                    CfgFn.GetNoNullDecimal(rp.addedRow["tax"]) == 0 &&
                    CfgFn.GetNoNullDecimal(rp.addedRow["unabatable"]) == 0) {
                    rp.addedRow.Delete();
                }
                rp.modifiedRow["toinvoice"] = "S";
                }

            Meta.FreshForm();
        }


        public bool IsAnnoCreazionedettaglio(DataRow R) {

            //(se start = null and Anno contratto = esercizio   OR   start not null and start = esercizio) => Nessun collegamento
            DataRow rMandate = DS.mandate.Rows[0];
            DataRow detailFirstRow = EP_Manager.getFirstRow(R);

            DateTime realStart = (DateTime)(detailFirstRow["start"] == DBNull.Value ? rMandate["adate"] : detailFirstRow["start"]);

            int annoOrigine = realStart.Year;
            if (annoOrigine == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))) {
                return true;
                }


            return false;
            }


        /// <summary>
        /// true per abilitare Tab intracomunitaria
        /// </summary>
        /// <param name="R"></param>
        private void ImpostaIntracom(object idresidence) {
            if (Meta.IsEmpty)
                return;
            // if (cboTipo.SelectedIndex <= 0)
            //     return;

            object Ocoderesidence = Conn.DO_READ_VALUE("residence", QHS.CmpEq("idresidence", idresidence),
                "coderesidence");
            if (Ocoderesidence == null || Ocoderesidence == DBNull.Value)
                return;
            string coderesidence = Ocoderesidence.ToString().ToUpper();
            DataRow Curr = DS.mandate.Rows[0];
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
                    show("Il tipo contratto è stato impostato come 'Extra-UE'", "Avviso");
                if (newval.ToString() == "S")
                    show("Il tipo contratto è stato impostato come 'Intracomunitario'", "Avviso");
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





        private int creaDettagliSplittati(DataRow rContratto, WizSostituisciDettaglio wiz, List<RowPair> coppie) {
            DataRow rDettaglioAnnullato = wiz.rOldDettaglio;
            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] {"idmankind", "yman", "nman", "idgroup"});

            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStart.Text, "x.y");
            string descrDettaglio = wiz.txtNewDescrizione.Text;
            string flagMixed = (wiz.chkNewPromiscuo.Checked) ? "S" : "N";
            object idIvaKind = (wiz.cmbNewTipoIva.SelectedValue == null)
                ? DBNull.Value
                : wiz.cmbNewTipoIva.SelectedValue;
            int flagActivityValue = wiz.flagActivityValue;
            object aliquotaIVA = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewAliquota.Text,
                "x.y.fixed.4..%.100");
            object sconto = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewSconto.Text,
                "x.y.fixed.4..%.100");
            object quantita = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewQuantita.Text,
                "x.y");
            object quantitaconfezioni = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewQuantitaConfezioni.Text,
                "x.y");
            object idunit = (wiz.cmbNewUnitaMisuraCS.SelectedIndex <= 0)
                ? DBNull.Value
                : wiz.cmbNewUnitaMisuraCS.SelectedValue;
            object idpackage = (wiz.cmbNewUnitaMisuraAcquisto.SelectedIndex <= 0)
                ? DBNull.Value
                : wiz.cmbNewUnitaMisuraAcquisto.SelectedValue;
            object unitsforpackage = HelpForm.GetObjectFromString(typeof(int), wiz.txtNewCoeffConversione.Text,
                "x");
            if (unitsforpackage == null)
                unitsforpackage = DBNull.Value;
            object idlist = DBNull.Value;
            if (wiz.rListChosen != null) {
                idlist = wiz.rListChosen["idlist"];
            }

            double ivaNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewIvaEuro.Text, "x.y.c"));
            double importoNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImportoUnitario.Text, "x.y"));
            double imponibileNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImponibileValuta.Text,
                "x.y"));
            double indetraibileNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewIvaIndetraibileEuro
                    .Text, "x.y.c"));


            bool ultimoCiclo = false;
            int lastLoop = DS.mandatedetail.Select(filter).Length;
            int currLoop = 1;

            double progIva = 0;
            double progImponibile = 0;
            double progIndetraibile = 0;

            int idGroup = 1 + CfgFn.GetNoNullInt32(DS.mandatedetail.Compute("MAX(idgroup)", null));
            double SOMMA = 0;
            foreach (DataRow SS in DS.mandatedetail.Select(filter))
                SOMMA += CfgFn.GetNoNullDouble(SS["taxable"]);
            double totImponibileDettagli = SOMMA;
            //CfgFn.GetNoNullDouble(DS.mandatedetail.Compute("SUM(taxable)", filter));

            MetaData MetaDetail = MetaData.GetMetaData(this, "mandatedetail");

            foreach (DataRow rDetail in DS.mandatedetail.Select(filter)) {
                if (currLoop == lastLoop) ultimoCiclo = true;
                MetaDetail.SetDefaults(DS.mandatedetail);
                DataRow rNew = MetaDetail.Get_New_Row(rContratto, DS.mandatedetail);
                rNew["idgroup"] = idGroup;
                string[] listField = new string[] {
                    "annotations", "assetkind", "competencystart", "competencystop", "epkind",
                    "idupb", "ninvoiced", "idaccmotive", "idreg", "idexp_taxable", "idexp_iva",
                    //"toinvoice", mi annulla pure quelli nuovi
                    "idinv", "idlocation", "idsor1", "idsor2", "idsor3", "idcostpartition", "idaccmotiveannulment",
                    "cupcode", "cigcode",
                    "flagto_unload", "idepexp", "idepacc", "idlist", "expensekind", "idupb_iva", "idsor_siope","idepexp_pre"
                };

                foreach (string colName in listField) {
                    rNew[colName] = rDetail[colName];
                }

                rNew["detaildescription"] = descrDettaglio;
                rNew["start"] = dataInizio;
                rNew["flagmixed"] = flagMixed;
                rNew["flagactivity"] = flagActivityValue;
                rNew["idivakind"] = idIvaKind;
                rNew["taxrate"] = aliquotaIVA;
                rNew["discount"] = sconto;
                rNew["npackage"] = quantitaconfezioni;
                rNew["number"] = quantita;
                if (wiz.rListChosen != null) {
                    rNew["idlist"] = wiz.rListChosen["idlist"];
                    rNew["expensekind"] = wiz.expensekind;
                    //rNew["expensekind"] = wiz.rListChosen["expensekind"];
                }

                // Ho modificato i valori rispetto quelli del dettaglio originale
                if ((wiz.new_idinv != DBNull.Value) && (rNew["idinv"] != wiz.new_idinv))
                    rNew["idinv"] = wiz.new_idinv;
                if ((wiz.new_idlist != DBNull.Value) && (rNew["idlist"] != wiz.new_idlist))
                    rNew["idlist"] = wiz.new_idlist;
                if ((wiz.new_va3type != DBNull.Value) && (rNew["va3type"] != wiz.new_va3type))
                    rNew["va3type"] = wiz.new_va3type;
                if ((wiz.new_idaccmotive != DBNull.Value) &&
                    (rNew["idaccmotive"].ToString() != wiz.new_idaccmotive.ToString())) {
                    rNew["idaccmotive"] = wiz.new_idaccmotive;
                    rNew["idsor_siope"] = DBNull.Value;
                }

                if ((wiz.new_assetkind != DBNull.Value) &&
                    (rNew["assetkind"].ToString() != wiz.new_assetkind.ToString()))
                    rNew["assetkind"] = wiz.new_assetkind;
                if ((wiz.expensekind != DBNull.Value) && (rNew["expensekind"].ToString() != wiz.expensekind.ToString()))
                    rNew["expensekind"] = wiz.expensekind;

                rNew["idunit"] = idunit;
                rNew["idpackage"] = idpackage;
                rNew["unitsforpackage"] = unitsforpackage;




                double ivaSplitted = 0;
                double imponibileSplitted = 0;
                double indetraibileSplitted = 0;

                double ivaDettaglio = CfgFn.GetNoNullDouble(rDetail["tax"]);
                double imponibileDettaglio = CfgFn.GetNoNullDouble(rDetail["taxable"]);
                double indetraibileDettaglio = CfgFn.GetNoNullDouble(rDetail["unabatable"]);

                if (ultimoCiclo) {
                    // Tappo
                    ivaSplitted = ivaNew - progIva;
                    imponibileSplitted = importoNew - progImponibile;
                    indetraibileSplitted = indetraibileNew - progIndetraibile;
                }
                else {
                    // Proporzione
                    double prop = imponibileDettaglio / totImponibileDettagli;
                    ivaSplitted = ivaNew * prop;
                    imponibileSplitted = importoNew * prop;
                    indetraibileSplitted = indetraibileNew * prop;

                    progIva += CfgFn.Round(ivaSplitted, 2);
                    progImponibile += CfgFn.Round(imponibileSplitted, 5);
                    progIndetraibile += CfgFn.Round(indetraibileSplitted, 2);
                }

                rNew["tax"] = CfgFn.Round(ivaSplitted, 2);
                rNew["taxable"] = CfgFn.Round(imponibileSplitted, 5);
                rNew["unabatable"] = CfgFn.Round(indetraibileSplitted, 2);
                coppie.Add(new RowPair(rDetail, rNew));
                currLoop++;
            }

            return idGroup;
        }

        private int creaDettagliSplittati_perRimpiazzo(DataRow rContratto, WizRimpiazzaPerProrata wiz,
            List<RowPair> coppie) {
            DataRow rDettaglioAnnullato = wiz.rOldDettaglio;
            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] {"idmankind", "yman", "nman", "idgroup"});

            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStart.Text, "x.y");
            string descrDettaglio = wiz.txtNewDescrizione.Text;
            string flagMixed = (wiz.chkNewPromiscuo.Checked) ? "S" : "N";
            object idIvaKind = (wiz.cmbNewTipoIva.SelectedValue == null)
                ? DBNull.Value
                : wiz.cmbNewTipoIva.SelectedValue;
            int flagActivityValue = wiz.flagActivityValue;
            object aliquotaIVA = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewAliquota.Text,
                "x.y.fixed.4..%.100");
            object sconto = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewSconto.Text,
                "x.y.fixed.4..%.100");
            object quantita = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewQuantita.Text,
                "x.y");
            object quantitaconfezioni = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewQuantitaConfezioni.Text,
                "x.y");
            object idunit = (wiz.cmbNewUnitaMisuraCS.SelectedIndex <= 0)
                ? DBNull.Value
                : wiz.cmbNewUnitaMisuraCS.SelectedValue;
            object idpackage = (wiz.cmbNewUnitaMisuraAcquisto.SelectedIndex <= 0)
                ? DBNull.Value
                : wiz.cmbNewUnitaMisuraAcquisto.SelectedValue;
            object unitsforpackage = HelpForm.GetObjectFromString(typeof(int), wiz.txtNewCoeffConversione.Text,
                "x");
            if (unitsforpackage == null)
                unitsforpackage = DBNull.Value;
            object idlist = DBNull.Value;
            if (wiz.rListChosen != null) {
                idlist = wiz.rListChosen["idlist"];
            }

            double ivaNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewIvaEuro.Text, "x.y.c"));
            double importoNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImportoUnitario.Text, "x.y"));
            double imponibileNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImponibileValuta.Text,
                "x.y"));
            double indetraibileNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewIvaIndetraibileEuro
                    .Text, "x.y.c"));


            bool ultimoCiclo = false;
            int lastLoop = DS.mandatedetail.Select(filter).Length;
            int currLoop = 1;

            double progIva = 0;
            double progImponibile = 0;
            double progIndetraibile = 0;

            int idGroup = 1 + CfgFn.GetNoNullInt32(DS.mandatedetail.Compute("MAX(idgroup)", null));
            double SOMMA = 0;
            foreach (DataRow SS in DS.mandatedetail.Select(filter))
                SOMMA += CfgFn.GetNoNullDouble(SS["taxable"]);
            double totImponibileDettagli = SOMMA;
            //CfgFn.GetNoNullDouble(DS.mandatedetail.Compute("SUM(taxable)", filter));

            MetaData MetaDetail = MetaData.GetMetaData(this, "mandatedetail");

            foreach (DataRow rDetail in DS.mandatedetail.Select(filter)) {
                if (currLoop == lastLoop) ultimoCiclo = true;
                MetaDetail.SetDefaults(DS.mandatedetail);
                DataRow rNew = MetaDetail.Get_New_Row(rContratto, DS.mandatedetail);
                rNew["idgroup"] = idGroup;
                string[] listField = new string[] {
                    "annotations", "assetkind", "competencystart", "competencystop", "epkind",
                    "idupb", "ninvoiced", "toinvoice", "idaccmotive", "idreg", "idexp_taxable", "idexp_iva",
                    "idinv", "idlocation", "idsor1", "idsor2", "idsor3", "idcostpartition", "idaccmotiveannulment",
                    "cupcode", "cigcode", "flagto_unload", "idsor_siope", "idlist"
                };

                foreach (string colName in listField) {
                    rNew[colName] = rDetail[colName];
                }

                rNew["detaildescription"] = descrDettaglio;
                rNew["start"] = dataInizio;
                rNew["flagmixed"] = flagMixed;
                rNew["flagactivity"] = flagActivityValue;
                rNew["idivakind"] = idIvaKind;
                rNew["taxrate"] = aliquotaIVA;
                rNew["discount"] = sconto;
                rNew["npackage"] = quantitaconfezioni;
                rNew["number"] = quantita;
                if (idlist != DBNull.Value) rNew["idlist"] = idlist;
                rNew["idunit"] = idunit;
                rNew["idpackage"] = idpackage;
                rNew["unitsforpackage"] = unitsforpackage;

                double ivaSplitted = 0;
                double imponibileSplitted = 0;
                double indetraibileSplitted = 0;

                double ivaDettaglio = CfgFn.GetNoNullDouble(rDetail["tax"]);
                double imponibileDettaglio = CfgFn.GetNoNullDouble(rDetail["taxable"]);
                double indetraibileDettaglio = CfgFn.GetNoNullDouble(rDetail["unabatable"]);

                if (ultimoCiclo) {
                    // Tappo
                    ivaSplitted = ivaNew - progIva;
                    imponibileSplitted = importoNew - progImponibile;
                    indetraibileSplitted = indetraibileNew - progIndetraibile;
                }
                else {
                    // Proporzione
                    double prop = imponibileDettaglio / totImponibileDettagli;
                    ivaSplitted = ivaNew * prop;
                    imponibileSplitted = importoNew * prop;
                    indetraibileSplitted = indetraibileNew * prop;

                    progIva += CfgFn.Round(ivaSplitted, 2);
                    progImponibile += CfgFn.Round(imponibileSplitted, 5);
                    progIndetraibile += CfgFn.Round(indetraibileSplitted, 2);
                }

                rNew["tax"] = CfgFn.Round(ivaSplitted, 2);
                rNew["taxable"] = CfgFn.Round(imponibileSplitted, 5);
                rNew["unabatable"] = CfgFn.Round(indetraibileSplitted, 2);
                coppie.Add(new RowPair(rDetail, rNew));
                currLoop++;
            }

            return idGroup;
        }

        private void btnAccetta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.mandate.Rows[0];
            curr["resendingpcc"] = "N";
            chkSendPCC.CheckState = CheckState.Unchecked;
            if (!Meta.GetFormData(false)) return;
            curr["idmandatestatus"] = 4;
            Meta.FreshForm();
            Meta.DoMainCommand("mainsave");
        }

        private void btnintegra_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.mandate.Rows[0];
            curr["resendingpcc"] = "N";
            chkSendPCC.CheckState = CheckState.Unchecked;
            if (!Meta.GetFormData(false)) return;
            curr["idmandatestatus"] = 3;
            Meta.FreshForm();
            Meta.DoMainCommand("mainsave");
        }

        private void btnApprova_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.mandate.Rows[0];
            curr["resendingpcc"] = "N";
            chkSendPCC.CheckState = CheckState.Unchecked;
            if (!Meta.GetFormData(false)) return;
            curr["idmandatestatus"] = 5;
            Meta.FreshForm();
            Meta.DoMainCommand("mainsave");


            show("Sarà ora creato e visualizzato l'ordine a partire da questa richiesta\n" +
                            "Sarà quindi necessario scegliere il nuovo tipo contratto ed eventualmente\n" +
                            "il numero qualora la numerazione sia manuale", "Avviso");

            DataRow Curr = DS.mandate.Rows[0];

            //Parte che crea la copia
            MetaData M = Meta.Dispatcher.Get("mandate");
            M.Edit(this.ParentForm, "default", false);
            M.linkedForm.Location = new Point(M.linkedForm.Location.X, M.linkedForm.Location.Y + 20);
            M.DoMainCommand("maininsert");
            DataRow RMain = M.DS.Tables["mandate"].Rows[0];


            foreach (DataColumn C in DS.mandate.Columns) {
                string field = C.ColumnName;
                if (QueryCreator.IsPrimaryKey(DS.mandate, field)) continue;
                RMain[field] = curr[field];
            }

            RMain["resendingpcc"] = "N";

            RMain["idmankind_origin"] = Curr["idmankind"];
            RMain["yman_origin"] = Curr["yman"];
            RMain["nman_origin"] = Curr["nman"];

            RMain["adate"] = Meta.GetSys("datacontabile");
            MetaData mandatedet = M.Dispatcher.Get("mandatedetail");
            foreach (DataRow det in DS.mandatedetail.Select()) {
                DataRow detc = mandatedet.Get_New_Row(RMain, M.DS.Tables["mandatedetail"]);
                foreach (DataColumn C in DS.mandatedetail.Columns) {
                    string field = C.ColumnName;
                    if (QueryCreator.IsPrimaryKey(DS.mandatedetail, field)) continue;
                    detc[field] = det[field];
                }

                detc["rownum_origin"] = det["rownum"];
            }

            MetaData mandateatt = M.Dispatcher.Get("mandateattachment");
            foreach (DataRow det in DS.mandateattachment.Select()) {
                DataRow detc = mandateatt.Get_New_Row(RMain, M.DS.Tables["mandateattachment"]);
                foreach (DataColumn C in DS.mandateattachment.Columns) {
                    string field = C.ColumnName;
                    if (QueryCreator.IsPrimaryKey(DS.mandateattachment, field)) continue;
                    detc[field] = det[field];
                }

            }

            MetaData mandatesor = M.Dispatcher.Get("mandatesorting");
            foreach (DataRow det in DS.mandatesorting.Select()) {
                DataRow detc = mandatesor.Get_New_Row(RMain, M.DS.Tables["mandatesorting"]);
                foreach (DataColumn C in DS.mandatesorting.Columns) {
                    string field = C.ColumnName;
                    if (QueryCreator.IsPrimaryKey(DS.mandatesorting, field)) continue;
                    detc[field] = det[field];
                }
            }

            if (Curr["idreg"] != DBNull.Value) {
                DataTable reg = Conn.RUN_SELECT("registry", "idaccmotivedebit", null, QHS.CmpEq("idreg", Curr["idreg"]), null, false);
                if (reg != null)
                    if (reg.Rows.Count > 0)
                        Curr["idaccmotivedebit"] = reg.Rows[0][0];
            }

            //MetaData mandatecig = M.Dispatcher.Get("mandatecig");
            //foreach (DataRow det in DS.mandatecig.Select()) {
            //    DataRow detc = mandatecig.Get_New_Row(RMain, M.DS.Tables["mandatecig"]);
            //    detc["cigcode"] = det["cigcode"];
            //    foreach (DataColumn C in DS.mandatecig.Columns) {
            //        string field = C.ColumnName;
            //        if (QueryCreator.IsPrimaryKey(DS.mandatecig, field)) continue;
            //        detc[field] = det[field];
            //    }
            //}

            //MetaData mandateavcp = M.Dispatcher.Get("mandateavcp");
            //foreach (DataRow det in DS.mandateavcp.Select()) {
            //    DataRow detc = mandateavcp.Get_New_Row(RMain, M.DS.Tables["mandateavcp"]);
            //    foreach (DataColumn C in DS.mandateavcp.Columns) {
            //        string field = C.ColumnName;
            //        if (QueryCreator.IsPrimaryKey(DS.mandateavcp, field)) continue;
            //        detc[field] = det[field];
            //    }
            //}


            M.FreshForm();
        }

        private void btnAnnullaApprova_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(false)) return;
            DataRow curr = DS.mandate.Rows[0];
            QueryHelper QHS = Conn.GetQueryHelper();

            DataTable t = Conn.RUN_SELECT("mandate", "*", null,
                QHS.AppAnd(QHS.CmpEq("idmankind_origin", curr["idmankind"]),
                    QHS.CmpEq("nman_origin", curr["nman"]),
                    QHS.CmpEq("yman_origin", curr["yman"])
                ), null, false);
            if (t != null && t.Rows.Count > 0) {
                show(
                    "Non è possibile annullare l'approvazione poichè la richiesta è già confluita in un contratto passivo",
                    "Avviso");
                return;
            }

            curr["idmandatestatus"] = 4;
            Meta.FreshForm();
            Meta.DoMainCommand("mainsave");

        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow curr = DS.mandate.Rows[0];
            curr["resendingpcc"] = "N";
            chkSendPCC.CheckState = CheckState.Unchecked;
            if (!Meta.GetFormData(false)) return;
            curr["idmandatestatus"] = 6;
            Meta.FreshForm();
            Meta.DoMainCommand("mainsave");

        }

        //private void rdbOptionConsip_CheckedChanged(object sender, EventArgs e) {}

        private void btnInserisciCopia_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RC = GetGridSelectedRows(detailgrid);
            if (RC == null) return;


            DataRow Ordine = DS.mandate.Rows[0];

            Meta.GetFormData(false);
            MetaData metaDT = MetaData.GetMetaData(this, "mandatedetail");
            metaDT.SetDefaults(DS.mandatedetail);
            DataRow rDT = metaDT.Get_New_Row(Ordine, DS.mandatedetail);

            foreach (string field in new string[] {
                "detaildescription", "npackage", "number", "flagmixed", "idivakind", "taxrate", "tax", "unabatable",
                "ivanotes", "taxable", "discount", "flagactivity", "idupb", "idupb_iva", "cupcode", "cigcode",
                "idinv", "assetkind", "toinvoice", "idsor1", "idsor2", "idsor3", "idcostpartition", "competencystart",
                "competencystop",
                "idaccmotive", "idreg", "va3type", "idlist", "idunit", "idpackage", "unitsforpackage", "flagto_unload",
                "epkind", "expensekind", "idsor_siope"
            }) {
                if (rDT.Table.Columns.Contains(field) && RC.Table.Columns.Contains(field))
                    rDT[field] = RC[field];
            }

            DataRow OR;
            if (Meta.EditDataRow(rDT, "single", out OR)) {
                Meta.FreshForm(true);
            }
        }



        private void btnPartecipantiAlLotto_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridLotti);
            if (RigaSelezionata == null) return;
            FrmPartecipantiLotto F = new FrmPartecipantiLotto(RigaSelezionata, DS.mandateavcp, DS.mandateavcpdetail);
            createForm(F, this);
            F.ShowDialog(this);
        }

        private void btnLottiPartecipati_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridAVCP);
            if (RigaSelezionata == null) return;
            frmLottiPartecipati F = new frmLottiPartecipati(DS.mandatecig, DS.mandateavcpdetail, RigaSelezionata);
            createForm(F, this);
            F.ShowDialog(this);
        }

        private void btnLottiAppaltati_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(gridAVCP);
            if (RigaSelezionata == null) return;
            frmLottiAppaltati F = new frmLottiAppaltati(DS.mandatecig, RigaSelezionata);
            createForm(F, this);
            F.ShowDialog(this);
        }

        private void btnAggiungiAggiudicatario_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            CreaPartecipanteInAutomatico(true);
            Meta.FreshForm();
        }

        private void btnOrdiniNoLotti_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand(
                "maindosearch.lista.((select count(*) from mandatecig MC where MC.idmankind=mandateview.idmankind and MC.yman=mandateview.yman and MC.nman= mandateview.nman)=0)");

        }

        private void btnOrdiniNoPartecipanti_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand(
                "maindosearch.lista.((select count(*) from mandateavcp MC where MC.idmankind=mandateview.idmankind and MC.yman=mandateview.yman and MC.nman= mandateview.nman)=0)");

        }



        private void btnPartecipantiNonAssociati_Click(object sender, EventArgs e) {
            if (!Meta.IsEmpty) return;
            Meta.DoMainCommand("maindosearch.lista.((select count(*) from mandateavcp MC " +
                               " left outer join mandateavcpdetail MD on MD.idmankind=MC.idmankind and MD.yman=MC.yman and MD.nman=MC.nman and MD.idavcp=MC.idavcp " +
                               " where MD.idmankind is null and MC.idmankind=mandateview.idmankind and MC.yman=mandateview.yman and MC.nman= mandateview.nman) >0)"

            );

        }


        private void rdbitalia_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            DS.mandate.ExtendedProperties["flagintracom"] = GetFlagIntracom();
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            if (Meta.DrawStateIsDone) {
                chkRecuperoIvaIntraExtra.Checked = false;
            }
            return;
        }

        private object GetFlagIntracom() {
            if (Meta.IsEmpty) return null;
            if (rdbitalia.Checked) return "N";
            if (rdbintracom.Checked) return "S";
            if (rdbextracom.Checked) return "X";
            return null;
        }

        private void txtScadenza_Leave(object sender, EventArgs e) {
            CalcolaDataScadenza();
        }

        private void txtDataDoc_Leave(object sender, EventArgs e) {
            CalcolaDataScadenza();
        }

        private void btnCreaRU_Click(object sender, EventArgs e) {

        }

        private void chkCreaRigaRU_CheckedChanged(object sender, EventArgs e) {

        }

        private void btnCreaRegistroUnico_Click(object sender, EventArgs e) {
            DataRow CurrMandate = DS.mandate.Rows[0];

            MetaData Uniqueregister = MetaData.GetMetaData(this, "uniqueregister");
            Uniqueregister.SetDefaults(DS.uniqueregister);
            DataRow Runiqueregister = Uniqueregister.Get_New_Row(CurrMandate, DS.uniqueregister);
            btnCreaRegistroUnico.Enabled = false;
        }

        private void btnRipartizione_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RC = GetGridSelectedRows(detailgrid);
            if (RC == null) return;

            object idcostpartition = RC["idcostpartition"];

            if (idcostpartition != DBNull.Value) {
                MetaData ToMeta = Meta.Dispatcher.Get("costpartition");
                string checkfilter = QHS.CmpEq("idcostpartition", idcostpartition);
                ToMeta.ContextFilter = checkfilter;
                Form F = null;
                if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
                bool result = ToMeta.Edit(F, "default", false);

                string listtype = ToMeta.DefaultListType;
                DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
                if (R != null) ToMeta.SelectRow(R, listtype);
            }
            else {
                idcostpartition = EP_functions.importCostPartitionDetail(Meta);
                if (idcostpartition == null) return;
                RC["idcostpartition"] = idcostpartition;

            }

        }

        private void cmbConsip2_SelectedIndexChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            //if (Meta.IsEmpty) return;
            int idconsipkind = CfgFn.GetNoNullInt32(cmbConsip2.SelectedValue);
            if (idconsipkind != 0) {
                DataRow rSelected = DS.consipkind_ext.Select(QHC.CmpEq("idconsipkind", idconsipkind))[0];
                labelConsipExt.Text = getHeaderForConsipRow(rSelected);
                bool isHeader = (rSelected["flagheader"].ToString().ToUpper() == "S");
                if (isHeader) {
                    cmbConsip2.SelectedIndex = calcNewValidIndex(lastValidConsipExtIndex, cmbConsip2.SelectedIndex,
                        DS.consipkind_ext.Rows.Count);
                    return;
                }
            }

            lastValidConsipExtIndex = cmbConsip2.SelectedIndex;
        }


        int lastValidConsipIndex = 0;
        int lastValidConsipExtIndex = 0;

        int calcNewValidIndex(int oldValidIndex, int newIndex, int tableSize) {
            if (oldValidIndex >= tableSize) {
                oldValidIndex = tableSize - 1;
            }

            if (oldValidIndex < newIndex) {
                //direction:forward
                if (newIndex < tableSize - 1) {
                    return newIndex + 1;
                }
                else {
                    return oldValidIndex;
                }
            }
            else {
                //direction: backward
                if (newIndex > 0) {
                    return newIndex - 1;
                }
                else {
                    return oldValidIndex;
                }
            }
        }

        private void cmbOptionConsip_SelectedIndexChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            //if (Meta.IsEmpty) return;

            int idconsipkind = CfgFn.GetNoNullInt32(cmbConsip1.SelectedValue);
            if (idconsipkind != 0) {
                DataRow rSelected = DS.consipkind.Select(QHC.CmpEq("idconsipkind", idconsipkind))[0];
                mainLabelConsip.Text = getHeaderForConsipRow(rSelected);
                bool isHeader = (rSelected["flagheader"].ToString() == "S");
                if (isHeader) {
                    cmbConsip1.SelectedIndex = calcNewValidIndex(lastValidConsipIndex, cmbConsip1.SelectedIndex,
                        DS.consipkind.Rows.Count);
                    return;
                }

                txtConsipMotive1.Text = rSelected["description"].ToString();
            }
            else {
                txtConsipMotive1.Text = "";
            }

            lastValidConsipIndex = cmbConsip1.SelectedIndex;

            VisualizzaBottoneConsip(idconsipkind, true);
            AbilitaDisabilitaConsip_Ext(idconsipkind, true);
        }


        private void VisualizzaBottoneImportaGara(bool visualizza)
        {
            if (visualizza)
            {
                // Il pulsante è visibile se sono state importate delle gare in Easy
                // invece di mettere una variabile in partner_config ad esempio
                if (Conn.RUN_SELECT_COUNT("wsgara", null, true) > 0)
                {
                    btnImportaGara.Visible = true;
                }
                else
                {
                    btnImportaGara.Visible = false;
                }
            }
            else {
                btnImportaGara.Visible = false;
            }
        }

        private void VisualizzaBottoneConsip(int idconsipkind, bool forced)
        {
            if (!forced && !Meta.DrawStateIsDone) return;
            string filter = QHC.CmpEq("idconsipkind", idconsipkind);

            DataRow[] Rows = DS.consipkind.Select(filter);
            if (Rows.Length > 0) {
                DataRow R1 = Rows[0];

                if (R1["active"].ToString() == "N") {
                    txtConsipMotive1.Visible = false;
                    btnConsipkind.Visible = false;
                    return;
                }

                //txtConsipMotive1.Text = R1["description"].ToString();

                string flagdinamic = R1["flagdynamictext"].ToString().ToUpper();
                if (flagdinamic == "S") {
                    btnConsipkind.Visible = true;
                    txtConsipMotive1.Visible = true;
                }
                else {
                    btnConsipkind.Visible = false;
                    txtConsipMotive1.Visible = false;
                }
            }
            else {
                btnConsipkind.Visible = false;
                txtConsipMotive1.Visible = false;
            }
        }

        void ShowHideExtConsip(bool show) {
            if (Consip2Disabilitato) show = false;
            labelConsipExt.Visible = show;
            cmbConsip2.Visible = show;
        }

        //abilitaDisabilitaCCdedicato() negli altri compensi
        private void abilitaDisabilitaCertificatiRichiesti(DataRow rMandatekind) {
            if ((rMandatekind == null) && (DS.mandate.Rows.Count == 0)) {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = true;
                chkDurc.Enabled = true;
                chkVerificaAnac.Enabled = true;
		        chkRegolaritaFiscale.Enabled = true;
		        chkOttempLegge.Enabled = true;
		        chkCasellarioAmm.Enabled = true;
		        chkCasellarioGiud.Enabled = true;
                chkPattoIntegrita.Enabled = true;
                return;
            }

            if ((rMandatekind == null) && (DS.mandate.Rows.Count > 0)) {
                DataRow Curr = DS.mandate.Rows[0];
                DataRow[] Mandatekind = DS.mandatekind.Select(QHS.CmpEq("idmankind", Curr["idmankind"]));
                if (Mandatekind.Length > 0) {
                    rMandatekind = Mandatekind[0];
                }
            }

            if (rMandatekind != null) {
                int flag_ccddicato = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 1;
                if (flag_ccddicato != 0) {
                    //CC dedicato necessario
                    if (Meta.InsertMode) chkCCdedicato.Checked = true;
                    chkCCdedicato.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkCCdedicato.Checked = false;
                    chkCCdedicato.Enabled = false;
                }

                int flag_visura = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 2;
                if (flag_visura != 0) {
                    //flag Visura Camerale necessario
                    if (Meta.InsertMode) chkVisura.Checked = true;
                    chkVisura.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkVisura.Checked = false;
                    chkVisura.Enabled = false;
                }

                int flag_durc = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 4;
                if (flag_durc != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkDurc.Checked = true;
                    chkDurc.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkDurc.Checked = false;
                    chkDurc.Enabled = false;
                }

                int flag_casellagiog = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 8;
                if (flag_casellagiog != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkCasellarioGiud.Checked = true;
                    chkCasellarioGiud.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkCasellarioGiud.Checked = false;
                    chkCasellarioGiud.Enabled = false;
                }

                int flag_casellarioa = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 16;
                if (flag_casellarioa != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkCasellarioAmm.Checked = true;
                    chkCasellarioAmm.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkCasellarioAmm.Checked = false;
                    chkCasellarioAmm.Enabled = false;
                }

                int flag_ottemplegge = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 32;
                if (flag_ottemplegge != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkOttempLegge.Checked = true;
                    chkOttempLegge.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkOttempLegge.Checked = false;
                    chkOttempLegge.Enabled = false;
                }

                int flag_regolaritafisc = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 64;
                if (flag_regolaritafisc != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkRegolaritaFiscale.Checked = true;
                    chkRegolaritaFiscale.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkRegolaritaFiscale.Checked = false;
                    chkRegolaritaFiscale.Enabled = false;
                }

                int flag_anac = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 128;
                if (flag_anac != 0) {
                    //flag DURC necessario
                    if (Meta.InsertMode) chkVerificaAnac.Checked = true;
                    chkVerificaAnac.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else {
                    if (Meta.InsertMode) chkVerificaAnac.Checked = false;
                    chkVerificaAnac.Enabled = false;
                }

                int flag_integrita = CfgFn.GetNoNullInt32(rMandatekind["requested_doc"]) & 256;
                if (flag_integrita != 0)
                {
                    //flag patto integrità necessario
                    if (Meta.InsertMode) chkPattoIntegrita.Checked = true;
                    chkPattoIntegrita.Enabled = true; // >>> c'è la possibilità di modifare il flag
                }
                else
                {
                    if (Meta.InsertMode) chkPattoIntegrita.Checked = false;
                    chkPattoIntegrita.Enabled = false;
                }
            }
        }

        private void AbilitaDisabilitaConsip_Ext(int idconsipkind, bool forced) {
            if (!forced && !Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            string filter = QHC.CmpEq("idconsipkind", idconsipkind);

            if (idconsipkind == 0) {
                ShowHideExtConsip(false);
                return;
            }

            DataRow[] Rows = DS.consipkind.Select(filter);
            if (Rows.Length > 0) {
                DataRow R1 = Rows[0];

                string flagpurchaseperformed = R1["flagpurchaseperformed"].ToString().ToUpper();
                if (flagpurchaseperformed == "") flagpurchaseperformed = "S";
                string flagactive = R1["active"].ToString().ToUpper();

                if (flagpurchaseperformed == "N") {
                    ShowHideExtConsip(true);
                }
                else {
                    cmbConsip2.SelectedIndex = 0;
                    ShowHideExtConsip(false);
                }
            }
            else {
                cmbConsip2.SelectedIndex = 0;
                ShowHideExtConsip(false);
            }
        }


        private void btnConsip_Click(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            if (sender == null) return;
            System.Type C_Type = sender.GetType();
            Meta.GetFormData(true);
            if (typeof(Button).IsAssignableFrom(C_Type)) {
                string testo = txtConsipMotive1.Text;
                DataRow Curr = DS.mandate.Rows[0];
                int idconsipkind = CfgFn.GetNoNullInt32(Curr["idconsipkind"]);
                string filter = QHC.CmpEq("idconsipkind", idconsipkind);

                DataRow[] Rows = DS.consipkind.Select(filter);
                string template_to_compile = "";
                if (Rows.Length > 0) {
                    DataRow R1 = Rows[0];
                    template_to_compile = R1["description"].ToString();
                }

                if ((template_to_compile == "") || (testo == "")) return;

                FrmUpdConsipMotive updconsip = new FrmUpdConsipMotive(template_to_compile, testo, DS.consipcategory);
                createForm(updconsip, null);
                DialogResult dr = updconsip.ShowDialog();
                if (dr == DialogResult.OK) {
                    testo = updconsip.template_compiled;
                    txtConsipMotive1.Text = testo;
                }
            }

        }

        private void btnImportFromExcel_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            //Riempie il datatable MData leggendo dal foglio Excel
            if (!LeggiFile()) {
                return;
            }
        }


        private bool verificaValiditaFileExcel(DataTable mData) {
            ArrayList elencoColonne = new ArrayList();
            // La verifica di validità si basa sulla presenza di alcune colonne all'interno del file Excel.
            foreach (string col in new string[] {
                "codanag", "anagrafica_dettaglio", "codclassanal1", "codclassanal2", "codclassanal3",
                "descrdett", "promiscuo", "impon", "codtipoiva", "aliquota", "iva",
                "ivaindetr", "quantita", "scontoperc",
                "tipobene", "dafatturare", "tipoattivita", "codiceupb", "tipova3",
                "codiceinv", "iniziocompetenza", "finecompetenza", "annotazioni", "noteiva", "cupdett", "cigdett",
                "scaricoimm", "causalecosto", "rifesterno", "naturaspesa", "intcode",
                "codsiope", "datacontab_dett", "tipo_competenzaeconomica", "coderipartizionecosti", "codeubic",
                "code_causaledebitopcc", "code_statodebitopcc",
            }) {
                elencoColonne.Add(col);
            }

            foreach (string col in elencoColonne) {
                if (!mData.Columns.Contains(col)) {
                    show(this, "Nel file " + MyOpenFile.FileName + " non esiste la colonna " + col,
                        "Errore");
                    return false;
                }
            }

            return true;
        }

        string[] tracciato_cpassivo =
            new string[] {
                "codanag;Codice anagrafica(idreg);Intero;8",
                "anagrafica_dettaglio;Anagrafica in dettaglio contratto;Codificato;1;S|N",
                "codclassanal1;Codice Classificazione Analitica 1;Stringa;50",
                "codclassanal2;Codice Classificazione Analitica 2;Stringa;50",
                "codclassanal3;Codice Classificazione Analitica 3;Stringa;50",
                //Informazioni sui dettagli
                "descrdett;Descrizione dettaglio;Stringa;150",
                "promiscuo;Uso promiscuo;Codificato;1;S|N",
                "impon;Imponibile UNITARIO;Numero;22",
                "codtipoiva;Codice Tipo IVA;Stringa;20",
                "aliquota;Aliquota iva;Numero;22",
                "iva;Importo IVA del dettaglio;Numero;22",
                "ivaindetr; Importo IVA indetraibile del dettaglio;Numero;22",
                "quantita;Quantita;Numero;22",
                "scontoperc;Percentuale Sconto;Numero;22",
                "idunit;ID Unità misura di acquisto;Intero;3",
                "idpackage;ID Unità misura di imballo;Intero;3",
                "unitsforpackage;N. unità di acquisto per unità di imballo;Intero;6",

                "tipobene;Tipo bene: Inventariabile(A),Aumento di valore(P),Servizi(S),Magazzino(M),Altro(O) ;Codificato;1;A|P|S|M|O",
                "dafatturare;Proponi per inserimento in fatture;Codificato;1;S|N",
                "tipoattivita;Tipo Attività: Istituzionale(1),Commerciale(2),Promiscua(3),Qualsiasi/Non specificata(4);Codificato;1;1|2|3|4",
                "codiceupb;Codice UPB;Stringa;50",
                "tipova3;Quadro VA3:  Beni ammortizzabili(S),Beni strumentali non ammortizzabili(N),Beni destinati alla rivendita(R), altri acquisti o importazioni(A);Codificato;1;S|N|R|A",
                "codiceinv;Codice inventario;Stringa;20",
                "iniziocompetenza;Inizio competenza economica;Data;8",
                "finecompetenza;Fine competenza economica;Data;8",
                "annotazioni;Appunti su dett.ordine;Stringa;400",
                "noteiva;Note sull'iva;Stringa;400",
                "cupdett;Codice CUP dettaglio;Stringa;15",
                "cigdett;Codice CIG dettaglio;Stringa;10",
                "scaricoimm;Scarico immediato;Codificato;1;S|N",
                "causalecosto;Codice causale costo;Stringa;50",
                "rifesterno;Riferimento esterno (es.da migrazioni);Stringa;50",
                "naturaspesa;Natura di Spesa: CO-> Spesa Corrente, CA--> Conto Capitale (PCC);Codificato;2;CO|CA",
                "intcode;Codice listino;Stringa;50",
                "codsiope;Codice Class. Siope;Stringa;50",
                "datacontab_dett;Data contabile dettaglio;Data;8",
                "tipo_competenzaeconomica;tipo_competenzaeconomica: Fattura da ricevere(F),Non generare ratei o scritture automatiche a fine anno(N),Genera rateo(S);Codificato;1;F|N|S",
                "coderipartizionecosti;codice ripartizione dei costi (tabella costpartition);Stringa;50",
                "codeubic;ubicazione prefissata del bene;Stringa;50",
                "code_causaledebitopcc;codice causale debito pcc (tabella pccdebitmotive);Stringa;20",
                "code_statodebitopcc;codice stato debito(tabella pccdebitstatus);Stringa;9"
            };

        private bool verificaValiditaCampiExcel(DataTable mData) {


            bool ok = true;
            DataSet Out = new DataSet();
            DataTable T = new DataTable();
            T.Columns.Add("errors", typeof(System.String), "");
            for (int i = 0; i < tracciato_cpassivo.Length; i++) {
                string fmt = tracciato_cpassivo[i];
                bool datiValidi = GetField(fmt, T, mData);
                if (!datiValidi) ok = false;
            }

            Out.Tables.Add(T);

            if (!ok) {
                FrmViewError View = new FrmViewError(Out);
                createForm(View, null);
                View.Show();
            }

            return ok;
        }


        bool GetField(string tracciato_field, DataTable T, DataTable mData) {

            bool ok = true;
            string[] ff = tracciato_field.Split(';');
            string fieldname = ff[0];

            int len = Convert.ToInt32(ff[3]);
            string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
            int rownum = 0;
            foreach (DataRow riga in mData.Select()) {
                string val = riga[fieldname].ToString().Trim();
                rownum++;
                if ((val.Length > len) && (ftype == "stringa")) {
                    string err = "Lunghezza non prevista nella decodifica del campo " + fieldname + " di tipo " +
                                 ftype + " e di valore " +
                                 val.Trim().TrimStart('0') + " alla riga " + rownum;
                    DataRow row = T.NewRow();
                    row["errors"] = err;
                    T.Rows.Add(row);
                    ok = false;
                }

                switch (fieldname) {
                    case "anagrafica_dettaglio":
                        if ((val.ToUpper() != "S") && (val.ToUpper() != "N")) {
                            string err = "Valore non previsto nella decodifica del campo " + fieldname +
                                         " di tipo " + ftype + " e di valore " +
                                         val.Trim() + " alla riga " + rownum;
                            DataRow row = T.NewRow();
                            row["errors"] = err;
                            T.Rows.Add(row);
                            ok = false;
                        }

                        break;

                    case "iniziocompetenza":
                    case "finecompetenza":
                        // controllo della data 
                        if (!controllaData(val) && (val != "")) {
                            string err = "Valore non previsto nella decodifica della data " + fieldname + " di tipo " +
                                         ftype + " e di valore " +
                                         val.Trim() + " alla riga " + rownum;
                            DataRow row = T.NewRow();
                            row["errors"] = err;
                            T.Rows.Add(row);
                            ok = false;
                        }

                        break;


                    case "impon":
                    case "quantita":

                        if (CfgFn.GetNoNullDecimal(val) <= 0) {
                            string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype +
                                         " e di valore " +
                                         val.Trim() + " alla riga " + rownum + ": inserire un importo maggiore di zero";
                            DataRow row = T.NewRow();
                            row["errors"] = err;
                            T.Rows.Add(row);
                            ok = false;
                        }

                        break;
                    case "naturaspesa":
                        if ((val.ToUpper() != "CO") && (val.ToUpper() != "CA")) {
                            string err = "Valore non previsto nella decodifica del campo " + fieldname +
                                         " di tipo " + ftype + " e di valore " +
                                         val.Trim() + " alla riga " + rownum;
                            DataRow row = T.NewRow();
                            row["errors"] = err;
                            T.Rows.Add(row);
                            ok = false;
                        }

                        break;
                }
            }

            return ok;
        }


        private bool controllaData(string txtData) {
            try {
                DateTime TT = (DateTime) HelpForm.GetObjectFromString(typeof(DateTime),
                    txtData, "x.y");
                return true;
            }
            catch {
                return false;
            }
        }


        private object TrimString(object value) {
            if (value != null) {
                string strValue = value.ToString();
                if (strValue == "") return DBNull.Value;
                //  else return aggiustaStringa(strValue,toglichiocciola).Trim();  
                else return strValue.Trim();
            }
            else
                return DBNull.Value;
        }

        Hashtable hIvakind = new Hashtable();

        object CheckExistsIvakind(object codice) {
            if (codice == DBNull.Value || codice == null) return DBNull.Value;
            string k = codice.ToString().ToUpper();
            if (hIvakind[k] != null) return hIvakind[k];
            object idivakind = Conn.DO_READ_VALUE("ivakind", QHS.CmpEq("codeivakind", codice), "idivakind");
            if (idivakind == null) return DBNull.Value;
            hIvakind[k] = idivakind;
            return idivakind;
        }


        Hashtable hashCostpartition = new Hashtable();

        object CheckExistsCostpartition(object costpartitioncode) {
            if (costpartitioncode == DBNull.Value || costpartitioncode == null) return DBNull.Value;
            string k = costpartitioncode.ToString().ToUpper();
            if (hashCostpartition[k] != null) return hashCostpartition[k];
            object idcostpartition = Conn.DO_READ_VALUE("costpartition",
                QHS.CmpEq("costpartitioncode", costpartitioncode), "idcostpartition");
            if (idcostpartition == null) return DBNull.Value;
            hashCostpartition[k] = idcostpartition;
            return idcostpartition;
        }

        Hashtable hashLocation = new Hashtable();

        object CheckExistsLocation(object locationcode) {
            if (locationcode == DBNull.Value || locationcode == null) return DBNull.Value;
            string k = locationcode.ToString().ToUpper();
            if (hashLocation[k] != null) return hashLocation[k];
            object idinv = Conn.DO_READ_VALUE("location", QHS.CmpEq("locationcode", locationcode), "idlocation");
            if (idinv == null) return DBNull.Value;
            hashLocation[k] = idinv;
            return idinv;
        }

        Hashtable hInvTree = new Hashtable();

        object CheckExistsInventorytree(object codice) {
            if (codice == DBNull.Value || codice == null) return DBNull.Value;
            string k = codice.ToString().ToUpper();
            if (hInvTree[k] != null) return hInvTree[k];
            object idinv = Conn.DO_READ_VALUE("inventorytree", QHS.CmpEq("codeinv", codice), "idinv");
            if (idinv == null) return DBNull.Value;
            hInvTree[k] = idinv;
            return idinv;
        }

        Hashtable hList = new Hashtable();

        object CheckExistsList(object codice) {
            if (codice == DBNull.Value || codice == null) return DBNull.Value;
            string k = codice.ToString().ToUpper();
            if (hList[k] != null) return hList[k];
            object idlist = Conn.DO_READ_VALUE("list", QHS.CmpEq("intcode", codice), "idlist");
            if (idlist == null) return DBNull.Value;
            hList[k] = idlist;
            return idlist;
        }


        Hashtable hUpb = new Hashtable();

        object CheckExistsUpb(object codice) {
            if (codice == DBNull.Value || codice == null) return DBNull.Value;
            string k = codice.ToString().ToUpper();
            if (hUpb[k] != null) return hUpb[k];
            object idupb = Conn.DO_READ_VALUE("upb", QHS.CmpEq("codeupb", codice), "idupb");
            if (idupb == null) return DBNull.Value;
            hUpb[k] = idupb;
            return idupb;
        }


        Hashtable hAccMotive = new Hashtable();

        object CheckExistsAccMotive(object codice) {
            if (codice == DBNull.Value || codice == null) return DBNull.Value;
            string k = codice.ToString().ToUpper();
            if (hAccMotive[k] != null) return hAccMotive[k];
            object idaccmotive = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("codemotive", codice), "idaccmotive");
            if (idaccmotive == null) return DBNull.Value;
            hAccMotive[k] = idaccmotive;
            return idaccmotive;
        }

        object CheckExistsSorting(object idsortingkind, object codice) {
            if ((idsortingkind == null) || (idsortingkind == DBNull.Value)) return DBNull.Value;
            if ((codice == null) || (codice == DBNull.Value)) return DBNull.Value;
            object idSor = Conn.DO_READ_VALUE("sorting",
                QHS.AppAnd(QHS.CmpEq("idsorkind", idsortingkind),
                    QHS.CmpEq("sortcode", codice)), "idsor", null);
            if (idSor != null && idSor != DBNull.Value) {
                return idSor;
            }

            return DBNull.Value;

        }


        private void fillDetails(DataTable mData) {
            progressBarImport.Value = 0;
            progressBarImport.Maximum = mData.Rows.Count;
            progressBarImport.Visible = true;
            // riempie il Dataset con le righe dei dettagli delle disposizioni di pagamento
            // a partire dalla tabella temporanea mData
            if (DS.mandate.Rows.Count == 0) return;
            DataRow RCurr = DS.mandate.Rows[0];
            MetaData MetaDetail = MetaData.GetMetaData(this, "mandatedetail");
            MetaDetail.SetDefaults(DS.mandatedetail);
            foreach (DataRow rFile in mData.Select()) {
                DataRow rNew = MetaDetail.Get_New_Row(RCurr, DS.mandatedetail);

                string anagrafica_dettaglio = TrimString(rFile["anagrafica_dettaglio"]).ToString().ToUpper();
                rNew["annotations"] = TrimString(rFile["annotazioni"]);

                object asskind = TrimString(rFile["tipobene"]);
                if (asskind != DBNull.Value) rNew["assetkind"] = asskind;
                rNew["competencystart"] = rFile["iniziocompetenza"];
                rNew["competencystop"] = rFile["finecompetenza"];
                rNew["detaildescription"] = TrimString(rFile["descrdett"]);
                rNew["discount"] = CfgFn.GetNoNullDecimal(rFile["scontoperc"]);

                object idaccmotive = DBNull.Value;
                idaccmotive = CheckExistsAccMotive(TrimString(rFile["causalecosto"]));
                rNew["idaccmotive"] = idaccmotive;

                object codeupb = rFile["codiceupb"];
                object idupb = DBNull.Value;
                idupb = CheckExistsUpb(TrimString(codeupb));
                rNew["idupb"] = idupb;

                rNew["number"] = CfgFn.GetNoNullDecimal(rFile["quantita"]);
                rNew["npackage"] = CfgFn.GetNoNullDecimal(rFile["quantita"]);





                rNew["tax"] = CfgFn.GetNoNullDecimal(rFile["iva"]);
                rNew["taxable"] = CfgFn.GetNoNullDecimal(rFile["impon"]);
                rNew["taxrate"] = CfgFn.GetNoNullDecimal(rFile["aliquota"]);
                rNew["toinvoice"] = TrimString(rFile["dafatturare"]);
                rNew["flagmixed"] = TrimString(rFile["promiscuo"]);
                rNew["unabatable"] = CfgFn.GetNoNullDecimal(rFile["ivaindetr"]);

                //if (anagrafica_dettaglio == "S") {
                rNew["idreg"] = TrimString(rFile["codanag"]);
                //}

                object idinv = DBNull.Value;
                idinv = CheckExistsInventorytree(TrimString(rFile["codiceinv"]));
                rNew["idinv"] = idinv;

                object idsorkind = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"),
                    "idsorkind", null);
                rNew["idsor_siope"] = CheckExistsSorting(idsorkind, rFile["codsiope"]);
                rNew["start"] = rFile["datacontab_dett"];
                rNew["epkind"] = TrimString(rFile["tipo_competenzaeconomica"]);

                object idcostpartition = DBNull.Value;
                idcostpartition = CheckExistsCostpartition(TrimString(rFile["coderipartizionecosti"]));
                rNew["idcostpartition"] = idcostpartition;

                object idlocation = DBNull.Value;
                idlocation = CheckExistsLocation(TrimString(rFile["codeubic"]));
                rNew["idlocation"] = idlocation;

                rNew["idpccdebitmotive"] =
                    TrimString(rFile["code_causaledebitopcc"]); // id causale debito pcc (tabella pccdebitmotive)			
                rNew["idpccdebitstatus"] =
                    TrimString(rFile["code_statodebitopcc"]); // id stato debito(tabella pccdebitstatus)       


                object idlist = DBNull.Value;
                idlist = CheckExistsList(TrimString(rFile["intcode"]));
                rNew["idlist"] = idlist;

                if (idlist != DBNull.Value) {
                    var o = Conn.readObject("list", q.eq("idlist", idlist), "idunit,idpackage,unitsforpackage");
                    foreach (string k in o.Keys) {
                        rNew[k] = o[k];
                    }
                }


                string codtipoiva = TrimString(rFile["codtipoiva"]).ToString();
                object aliquota = CfgFn.GetNoNullDecimal(rFile["aliquota"]);
                rNew["idivakind"] = CheckExistsIvakind(codtipoiva);

                rNew["flagactivity"] = TrimString(rFile["tipoattivita"]);
                rNew["va3type"] = TrimString(rFile["tipova3"]);
                rNew["ivanotes"] = TrimString(rFile["noteiva"]);
                rNew["cupcode"] = TrimString(rFile["cupdett"]);
                rNew["cigcode"] = TrimString(rFile["cigdett"]);
                rNew["flagto_unload"] = TrimString(rFile["scaricoimm"]);
                object naturaspesa = TrimString(rFile["naturaspesa"]);
                if (naturaspesa != DBNull.Value)
                    rNew["expensekind"] = naturaspesa.ToString().ToUpper();

                //Dett.ordine
                object[] idsortingkind = new object[] {
                    0, Meta.GetSys("idsortingkind1"),
                    Meta.GetSys("idsortingkind2"),
                    Meta.GetSys("idsortingkind3")
                };

                //Verifica la presenza delle classificazioni analitiche
                for (int nsor = 1; nsor <= 3; nsor++) {

                    rNew["idsor" + nsor.ToString()] =
                        CheckExistsSorting(idsortingkind[nsor], rFile["codclassanal" + nsor.ToString()]);

                }



                rNew["ct"] = DateTime.Now;
                rNew["cu"] = "Import";
                rNew["lt"] = DateTime.Now;
                rNew["lu"] = "Import";
                progressBarImport.Value++;
            }

            progressBarImport.Visible = false;

        }

        public static object getDate(object o) {
            if (o == null) return null;
            if (o == DBNull.Value) return null;
            if (o is DateTime) return o;
            if (o.GetType().ToString() == "DateTime") return o;

            DateTime d;
            bool res = DateTime.TryParse(o.ToString(), out d);
            if (res) return d;
            return o;
        }

        private static object SSTodateTime(object data) {
            if (data == DBNull.Value)
                return data;
            if (data == null) return DBNull.Value;
            data = getDate(data);
            if (!data.GetType().IsAssignableFrom(typeof(DateTime))) {
                (new MetaDataForm()).show("Non posso fare il cast di " + data.ToString() + " in un datetime");

            }

            DateTime d = (DateTime) data;
            DateTime minValue = new DateTime(1753, 1, 1);
            if (d < minValue)
                return minValue;
            DateTime maxValue = new DateTime(999, 12, 31);
            if (d > maxValue)
                return maxValue;

            return data;
        }

        private void ImpostaColonneTracciatoDettagli(DataTable mData) {
            mData.Columns.Clear();
            mData.Columns.Add("codanag", typeof(int));
            mData.Columns.Add("anagrafica_dettaglio", typeof(string));
            mData.Columns.Add("codclassanal1", typeof(string));
            mData.Columns.Add("codclassanal2", typeof(string));
            mData.Columns.Add("codclassanal3", typeof(string));
            mData.Columns.Add("descrdett", typeof(string));
            mData.Columns.Add("promiscuo", typeof(string));
            mData.Columns.Add("impon", typeof(decimal));
            mData.Columns.Add("codtipoiva", typeof(string));
            mData.Columns.Add("aliquota", typeof(decimal));
            mData.Columns.Add("iva", typeof(decimal));
            mData.Columns.Add("ivaindetr", typeof(decimal));
            mData.Columns.Add("quantita", typeof(decimal));
            mData.Columns.Add("scontoperc", typeof(decimal));
            mData.Columns.Add("idunit", typeof(string));
            mData.Columns.Add("idpackage", typeof(string));
            mData.Columns.Add("unitsforpackage", typeof(int));

            mData.Columns.Add("tipobene", typeof(string));
            mData.Columns.Add("dafatturare", typeof(string));
            mData.Columns.Add("tipoattivita", typeof(string));
            mData.Columns.Add("codiceupb", typeof(string));
            mData.Columns.Add("tipova3", typeof(string));
            mData.Columns.Add("codiceinv", typeof(string));
            mData.Columns.Add("iniziocompetenza", typeof(DateTime));
            mData.Columns.Add("finecompetenza", typeof(DateTime));
            mData.Columns.Add("annotazioni", typeof(string));
            mData.Columns.Add("noteiva", typeof(string));
            mData.Columns.Add("cupdett", typeof(string));
            mData.Columns.Add("cigdett", typeof(string));
            mData.Columns.Add("scaricoimm", typeof(string));
            mData.Columns.Add("causalecosto", typeof(string));
            mData.Columns.Add("rifesterno", typeof(string));
            mData.Columns.Add("naturaspesa", typeof(string));
            mData.Columns.Add("intcode", typeof(string));
            mData.Columns.Add("codsiope", typeof(string));
            mData.Columns.Add("datacontab_dett", typeof(DateTime));
            mData.Columns.Add("tipo_competenzaeconomica", typeof(string));
            mData.Columns.Add("coderipartizionecosti", typeof(string));
            mData.Columns.Add("codeubic", typeof(string));
            mData.Columns.Add("code_causaledebitopcc", typeof(string));
            mData.Columns.Add("code_statodebitopcc", typeof(string));


        }

        private bool LeggiFile() {
            DataTable mData = new DataTable();
            ImpostaColonneTracciatoDettagli(mData);
            DialogResult dr = MyOpenFile.ShowDialog(this);
            if (dr != DialogResult.OK) return false;
            try {
                string fileName = MyOpenFile.FileName;
                //ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName +
                //    ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

                if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {

                    ExcelImport x = new ExcelImport();
                    ConnectionString = ExcelImport.ExcelConnString(fileName);
                    x.ImportTable(fileName, mData);
                }

                //ReadCurrentSheet();
            }
            catch (Exception ex) {
                show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
                return false;
            }

            if (!verificaValiditaFileExcel(mData)) {
                show(this, "Il file selezionato non è valido", "Errore");
                return false;
            }

            if (!verificaValiditaCampiExcel(mData)) {
                return false;
            }

            fillDetails(mData);
            Meta.FreshForm();
            return true;
        }

        private void addColumnExcel(DataTable tExcel) {
            tExcel.Columns.Add("nome", typeof(string));
            tExcel.Columns.Add("cognome", typeof(string));
            tExcel.Columns.Add("denominazione", typeof(string));
            tExcel.Columns.Add("personafisica", typeof(string));
            tExcel.Columns.Add("cf", typeof(string));
            tExcel.Columns.Add("p_iva", typeof(string));
            tExcel.Columns.Add("datanasc", typeof(string));
            tExcel.Columns.Add("indirizzo", typeof(string));
            tExcel.Columns.Add("cap", typeof(string));
            tExcel.Columns.Add("localita", typeof(string));
            tExcel.Columns.Add("provincia", typeof(string));
            tExcel.Columns.Add("email", typeof(string));
            tExcel.Columns.Add("iban", typeof(string));
            tExcel.Columns.Add("causaledett", typeof(string));
            tExcel.Columns.Add("causaleCBIdett", typeof(string));
            tExcel.Columns.Add("importo", typeof(decimal));
            tExcel.Columns.Add("codicepagamento", typeof(string));
        }

        public string GetTracciato(string[] tracciato) {
            string res = "";
            int pos = 0;
            foreach (string t in tracciato) {
                string[] ss = t.Split(';');
                string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
                               ss[3].PadLeft(4) +
                               " Tipo: " + ss[2].PadLeft(15);
                if (ss[2].ToLower() == "codificato") {
                    field += " Codifica:" + ss[4];
                }

                field += " Descrizione: " + ss[1];
                field += "\r\n";
                pos += CfgFn.GetNoNullInt32(ss[3]);
                res += field;
            }

            return res;
        }

        public DataTable GetTableTracciato(string[] tracciato) {
            int pos = 0;
            DataTable T = new DataTable("t");
            T.Columns.Add("nome", typeof(string));
            T.Columns.Add("posizione", typeof(int));
            T.Columns.Add("lunghezza", typeof(string));
            T.Columns.Add("tipo", typeof(string));
            T.Columns.Add("codifica", typeof(string));
            T.Columns.Add("Descrizione", typeof(string));

            foreach (string t in tracciato) {
                DataRow r = T.NewRow();
                string[] ss = t.Split(';');
                r["nome"] = ss[0];
                r["posizione"] = pos;
                r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
                r["tipo"] = ss[2];
                if (ss.Length == 5) r["codifica"] = ss[4];
                r["Descrizione"] = ss[1];
                pos += CfgFn.GetNoNullInt32(ss[3]);
                T.Rows.Add(r);
            }

            return T;
        }

        private void MenuEnterPwd_Click(object sender, EventArgs e) {
            if (sender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
            object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
            string tracciato = "";
            DataTable TableTracciato = null;

            tracciato = GetTracciato(tracciato_cpassivo);
            TableTracciato = GetTableTracciato(tracciato_cpassivo);
            FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
            createForm(FT, null);
            FT.ShowDialog();

        }

        private void btnRimpiazzaPerNuovoProrata_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                show(this, "Prima di eseguire l'operazione si deve salvare!");
                return;
            }

            DataRow rContratto = DS.mandate.Rows[0];
			//List<int> idgroup_fattureDaRicevere = new  List<int>();

			//foreach (DataRow det in DS.mandatedetail.Select()) {
			//	if ((det["epkind"] != DBNull.Value) && (det["epkind"].ToString().ToUpper() == "F"))
			//		idgroup_fattureDaRicevere.Add(CfgFn.GetNoNullInt32(det["idgroup"]));
			//}

			// Passo 1. - Scelta del dettaglio da sostituire
			WizRimpiazzaPerProrata wiz = new WizRimpiazzaPerProrata(rContratto, Meta.Conn, Meta.Dispatcher);
            createForm(wiz, null);
            DialogResult dr = wiz.ShowDialog();
            if (dr != DialogResult.OK) {
                show(this, "Operazione annullata!");
                return;
            }

            // Passo 2. - Annullamento di tutti i fratelli del dettaglio annullato
            DataRow rDettaglioAnnullato = wiz.rOldDettaglio;


            object dataAnnullamento = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStop.Text, "x.y");


            List<RowPair> Coppie = new List<RowPair>();
            // Passo 3. - Creazione nuovo dettaglio già splittato
            int idGroup = creaDettagliSplittati_perRimpiazzo(rContratto, wiz, Coppie);

            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] {"idmankind", "yman", "nman", "idgroup"});
            foreach (DataRow rDetail in DS.mandatedetail.Select(filter)) {
                rDetail["stop"] = dataAnnullamento;
                rDetail["toinvoice"] = "N";
                }

            // Passo 4. - Raffinamento dello split (usando il form dello split già esistente)
            DataRow[] listaDettagliSplittati = DS.mandatedetail.Select(QHC.CmpEq("idgroup", idGroup), "rownum");
            if ((listaDettagliSplittati.Length > 1) && (listaDettagliSplittati.Length <= 10)) {
                frmAskDividi frm = new frmAskDividi(rContratto, listaDettagliSplittati, Meta, Meta.Dispatcher);
                createForm(frm, null);
                DialogResult dr2 = frm.ShowDialog();
                frm.Destroy();
                if (dr2 != DialogResult.OK) {
                    show(this, "Operazione di split annullata");
                    return;
                }
                else {
                    DataTable Info = frm.Info;
                    for (int i = 0; i < Info.Rows.Count; i++) {
                        listaDettagliSplittati[i]["taxable"] = Info.Rows[i]["taxable"];
                        listaDettagliSplittati[i]["tax"] = Info.Rows[i]["tax"];
                        listaDettagliSplittati[i]["unabatable"] = Info.Rows[i]["unabatable"];
                    }
                }
            }

            foreach (RowPair rp in Coppie) {
                //rp.SwapValues();
                if (CfgFn.GetNoNullDecimal(rp.addedRow["taxable"]) == 0 &&
                    CfgFn.GetNoNullDecimal(rp.addedRow["tax"]) == 0 &&
                    CfgFn.GetNoNullDecimal(rp.addedRow["unabatable"]) == 0) {
                    rp.addedRow.Delete();
                }
            }

            Meta.FreshForm();
        }

        private void txtCambio_Leave(object sender, EventArgs e) {
            if (Meta.destroyed) return;
            if (Meta.IsEmpty) return;
            double tasso =
                CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double), txtCambio.Text,
                    txtCambio.Tag.ToString()));
            RicalcolaIvaDettagli(tasso);
        }
              
        private void rdbintracom_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            if (Meta.DrawStateIsDone){
                chkRecuperoIvaIntraExtra.Checked = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            }
            return;
        }

        private void rdbextracom_CheckedChanged(object sender, EventArgs e) {
            if (Meta == null)
                return;
            chkRecuperoIvaIntraExtra.Visible = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            if (Meta.DrawStateIsDone){
                chkRecuperoIvaIntraExtra.Checked = recuperoIntraUEAttivo && (Meta.IsEmpty || !rdbitalia.Checked);
            }
            return;

        }

        bool collegabileAFattura(object idmankind) {
            if (idmankind == null || idmankind == DBNull.Value || idmankind.ToString() == "") return false;

            object flaglinktoinvoice = Conn.DO_READ_VALUE("mandatekind", QHS.CmpEq("idmankind", idmankind),
                "linktoinvoice");
            if (flaglinktoinvoice == null || flaglinktoinvoice == DBNull.Value) {
                flaglinktoinvoice = "S";
                }

            return (flaglinktoinvoice.ToString().ToUpper() == "S");
            }
        bool rateo(DataRow rDetail) {
            object epkind = rDetail["epkind"];
            return epkind.ToString().ToUpper() == "R";
            }
        bool fatturaARicevereOEmettere(DataRow rDetail) {
            object epkind = rDetail["epkind"];
            return epkind.ToString().ToUpper() == "F";
            }

        private void btnAnnullaDettaglio_Click(object sender, EventArgs e) {
            if (DS.mandate.Rows.Count == 0) return;
            Meta.GetFormData(true);
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);

            if (RigaSelezionata == null) return;
            if (show(this,
                $"Si vuole annullare il dettaglio relativo alla riga {RigaSelezionata["rownum"]}?", "Conferma", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            if (RigaSelezionata["stop"] != DBNull.Value) {
                show("Dettaglio già annullato", "Avviso");
                return;
                }

            DataRow main = DS.mandate.Rows[0];
            var f = new FrmAnnullaDettaglio(main, RigaSelezionata, Meta, Meta.Dispatcher);
            createForm(f, this);
            if (f.ShowDialog(this) != DialogResult.OK) return;
            //La data di annullo la mette comunque
            DateTime stop = (DateTime)HelpForm.GetObjectFromString(typeof(DateTime), f.txtStop.Text, "x.y.g");
            RigaSelezionata["stop"] = stop;
            var idaccmotiveannulment = f.SelectedCasualeAnn ?? DBNull.Value;



            int yStart = CfgFn.GetNoNullInt32(main["yman"]);
            var rFirst = EP_Manager.getFirstRow(RigaSelezionata);
            if (rFirst["start"] != DBNull.Value) {
                yStart = ((DateTime)rFirst["start"]).Year;
                }



            if (yStart == Conn.GetEsercizio()) {
                RigaSelezionata["idaccmotiveannulment"] = idaccmotiveannulment ?? DBNull.Value;
                Meta.FreshForm();
                return; //Se dettaglio dello stesso esercizio, normale annullo
                }


            /*
			 * "per i dettagli di CA non collegabili e CA con fatture da emettere annullati in esercizi successivi con causale di ricavo deve procedere
			 * ad una sostituzione a zero in modo tale da generare l'acc di budget di tipo variazione.
			 * In tutti gli altri casi deve operare l'annullo come avviene normalmente con la semplice data fine sul dettaglio"
			 */

            bool collegabile = collegabileAFattura(RigaSelezionata["idmankind"]);
            if (collegabile && !fatturaARicevereOEmettere(RigaSelezionata) && !rateo(RigaSelezionata)) {
                RigaSelezionata["idaccmotiveannulment"] = idaccmotiveannulment ?? DBNull.Value;
                Meta.FreshForm();
                return;
                }
            //arriva qui se NON è collegabile OPPURE se è una fattura a ricevere o emettere 
            //Deve fare una sostituzione a zero, crea un nuovo dettaglio con data inizio di quello selezionato e lo fa puntare a quello selezionato, che assume
            // data inizio pari alla data annullo. Inoltre al nuovo dettaglio sono impostati rownum_main, causale di annullo e data fine


            var bf = new BudgetFunction(Meta.Dispatcher);
            //Vede se ha causale di ricavo
            DataRow[] rEntries = bf.GetAccMotiveDetails(idaccmotiveannulment);
            if (rEntries.Length != 1) {
                show(
                    $"La causale di annullo selezionata non è ben configurata.",
                    "Errore");
                RigaSelezionata["stop"] = DBNull.Value;
                return;
                }

            object idContoAnnullo = rEntries[0]["idacc"];


            if (!isBudgetEnabled(idContoAnnullo)) {
                RigaSelezionata["idaccmotiveannulment"] = idaccmotiveannulment ?? DBNull.Value;
                Meta.FreshForm();
                return;
                }

            if (EPM.EP.isRicavo(idContoAnnullo)) {
                RigaSelezionata["idaccmotiveannulment"] = idaccmotiveannulment ?? DBNull.Value;
                Meta.FreshForm();
                return;
                }


            var metaDetail = MetaData.GetMetaData(this, "mandatedetail");
            metaDetail.SetDefaults(DS.mandatedetail);


            string filtroBrother = QHC.MCmp(RigaSelezionata,
                new string[] { "idmankind", "yman", "nman", "idgroup" });

            object idgroupNew = null;
            foreach (DataRow rBrother in DS.mandatedetail.Select(filtroBrother)) {
                var newRow = metaDetail.Get_New_Row(main, DS.mandatedetail);
                //Copia tutti i campi tranne rownumber
                foreach (DataColumn c in DS.mandatedetail.Columns) {
                    if (c.ColumnName != "rownum" && c.ColumnName != "idgroup") newRow[c.ColumnName] = rBrother[c.ColumnName];
                    }

                if (idgroupNew == null) {
                    idgroupNew = newRow["idgroup"];
                    }
                else {
                    newRow["idgroup"] = idgroupNew;
                    }
                newRow["idepexp"] = DBNull.Value;
                newRow["idepexp_pre"] = DBNull.Value;
                newRow["rownum_main"] = rBrother["rownum"];
                newRow["toinvoice"] = "N";
                newRow["stop"] = stop;
                rBrother["start"] = stop;
                rBrother["stop"] = stop;
                newRow["idaccmotiveannulment"] = idaccmotiveannulment;
                rBrother["idaccmotiveannulment"] = rBrother["idaccmotive"];
                rBrother["taxable"] = 0;
                rBrother["tax"] = 0;
                rBrother["unabatable"] = 0;
                rBrother["toinvoice"] = "N";
                }


            Meta.FreshForm();
            }
        bool isBudgetEnabled(object idacc) {
            if (idacc == DBNull.Value) return false;
            if (idacc == null) return false;
            object flag = Conn.DO_READ_VALUE("account", QHS.CmpEq("idacc", idacc), "flagenablebudgetprev");
            return (flag != null && flag.ToString().ToUpper() == "S");
        }

        private void btnImportaGara_Click(object sender, EventArgs e)
        {
            if (Meta.InsertMode && DS.mandate.Rows.Count > 0)
            {
                DataRow drMandate = DS.mandate.Rows[0];

                // Scegleire il tipo Ordine prima di importare la Gara
                if (drMandate["idmankind"].ToString() == "")
                {
                    show("E' necessario scegliere il tipo contratto");
                    return;
                }
            }

            MetaData GaraTraspareView = Meta.Dispatcher.Get("garatraspareview");
            GaraTraspareView.FilterLocked = true;
            DataRow garaTraspare = GaraTraspareView.SelectOne("default", "", "garatraspareview", null);
            if (garaTraspare == null) return;

            riempiContrattoDaGaraTraspare(garaTraspare);

            return;
        }

        private const string CAPOGRUPPO = "04";

        private void riempiContrattoDaGaraTraspare(DataRow garaTraspare)
        {
            // ==========================================================================================
            //                                   MANDATE TABLES
            // ==========================================================================================
            // mandate
            // mandatecig
            // mandateavcp
            // ==========================================================================================
            MetaData MetaMandate = MetaData.GetMetaData(this, "mandate");                
            DataTable Mandate = DS.Tables["mandate"];                
            if (MetaMandate == null || MetaMandate.destroyed) return;

            if (Meta.InsertMode && DS.mandate.Rows.Count > 0)
            {
                DataRow drMandate = DS.mandate.Rows[0];

                // ==========================================================================================
                //                                  Gara Traspare View
                // ==========================================================================================
                // idgaratraspare       Es: 4
                // cig                  Es: '1387456822,1387456833,1387456844'
                // codice fiscale       Es: 01350170385
                //
                // idGaraTraspare serve per filtrare [wsgara] e ottenere [idGara]
                // 
                // idgara e cig servono per filtrare [wslotto] e ottenere List[idlotto]
                //
                // List[idlotto] e codice fiscale servono per ottenere [wsaggiudicatario] e [wspartecipante]

                // Es:
                // idGaraTraspare   cig         Fornitore                           FornitoreCFPIva     FornitoreIdEstero   ImportoAggiudicazione   Rup             RupCF
                // 1567	            Z9B300E977	MARIOHOME SRLS	                    02703860904		    null                16000	                Sara Pirroni	PRRSRA94P64B354P
                // 1544	            Z9B32E6292	EBSCO INFORMATION SERVICES S.R.L.	11164410018	        null                30240,04	            Vanessa Pinna	PNNVSS96H69B354Y 
                // ==========================================================================================


                // ==========================================================================================
                //                                       GARA E CIG
                // ==========================================================================================
                int idGaraTraspare = CfgFn.GetNoNullInt32(garaTraspare["idGaraTraspare"]);      // 1567
                object cigsAggiudicatario = garaTraspare["cig"];                                // Z9B300E977


                // ==========================================================================================
                //                                       FORNITORE
                // ==========================================================================================
                object Fornitore = garaTraspare["Fornitore"];                                   // MARIOHOME SRLS
                object FornitoreCFPIva = garaTraspare["FornitoreCFPIva"];                       // 02703860904


                // ==========================================================================================
                //                                    RICERCA FORNITORE
                // ==========================================================================================
                int idRegFornitore = CfgFn.GetNoNullInt32(IndividuaAnagrafica(FornitoreCFPIva, Fornitore));
                if (idRegFornitore == 0)
                    show($"Non è stata individuata nessuna anagrafica per il fornitore con codice fiscale '{FornitoreCFPIva}' o Ragione Sociale '{Fornitore}'. Selezionarlo manualmente.");
                drMandate["idreg"] = idRegFornitore;


                // ==========================================================================================
                //                                          GARA
                // ==========================================================================================
                int idGara = 0;
                DataTable dtGara = Conn.RUN_SELECT("wsgara", null, null, QHC.CmpEq("idGaraTraspare", idGaraTraspare), null, null, false);
                if (dtGara != null)
                {
                    if (dtGara.Rows != null)
                    {
                        if (dtGara.Rows.Count > 0)
                        {
                            DataRow gara = dtGara.Rows[0];

                            // ==========================================================================================
                            //                                        GARA
                            // ==========================================================================================
                            idGara = CfgFn.GetNoNullInt32(gara["idGara"]);

                            // ==========================================================================================
                            //                              STRUTTURA, ANNO AGGIUDICAZIONE
                            // ==========================================================================================
                            int idStrutturaTraspare = CfgFn.GetNoNullInt32(gara["idStrutturaTraspare"]);
                            int annoAggiudicazioneGara = CfgFn.GetNoNullInt32(gara["annoAggiudicazioneGara"]);

                            // ==========================================================================================
                            //                                         RUP
                            // ==========================================================================================
                            object rup = garaTraspare["rup"];
                            object rupCF = garaTraspare["rupCF"];

                            // ==========================================================================================
                            //                                      RICERCA RUP
                            // ==========================================================================================
                            int idRegRupAnac = CfgFn.GetNoNullInt32(IndividuaAnagrafica(rupCF, rup));
                            if (idRegRupAnac == 0)
                            {
                                show($"Non è stata individuata nessuna anagrafica per il R.U.P. con codice fiscale '{rupCF}' o Ragione Sociale '{rup}'. Selezionarlo manualmente.");
                            }

                            drMandate["idreg_rupanac"] = idRegRupAnac;

                            int tipoDataPub = CfgFn.GetNoNullInt32(gara["tipoPubblicazione"]);
                            drMandate["publishdatekind"] = tipoDataPub == 1 ? "Q" : (tipoDataPub == 2 ? "V" : (tipoDataPub == 2 ? "M" : "C"));

                            drMandate["publishdate"] = DateTime.Parse(gara["dataPubblicazione"].ToString());

                            drMandate["description"] = gara["titoloGara"] + "\r\n" + gara["abstractGara"];

                            int esitoGara = CfgFn.GetNoNullInt32(gara["esitoGara"]);
                            drMandate["flagtenderresult"] = esitoGara == 1 ? "D" : (esitoGara == 2 ? "N" : "A");

                            int tipoGara = CfgFn.GetNoNullInt32(gara["tipoGara"]);
                            drMandate["tenderkind"] = tipoGara == 1 ? "AV" : (tipoGara == 2 ? "AF" : (tipoGara == 2 ? "DE" : "B"));

                            drMandate["motiveassignment"] = gara["motivazioneAffidamento"];

                            drMandate["anacreduced"] = gara["ribasso"];
                        }
                    }
                }
                

                // ==========================================================================================
                // LOTTI
                // ==========================================================================================
                string cigFilter = "'" + cigsAggiudicatario.ToString().Replace(",", "','") + "'";
                string filtroLotti = QHS.AppAnd(QHC.CmpEq("idgara", idGara), QHC.FieldInList("cig", cigFilter));
                DataTable dtLotto = Conn.RUN_SELECT("wslotto", null, null, filtroLotti, null, null, false);
                List<object> idLotti = new List<object>();
                foreach (DataRow drLotto in dtLotto.Rows)
                {
                    int idavcpAggiudicatario = 1;
                    object idLotto = drLotto["idlotto"];
                    idLotti.Add(idLotto);

                    // ==========================================================================================
                    //                              LOTTO -> NEW DATAROW MANDATECIG
                    // ==========================================================================================
                    MetaData mcig = MetaData.GetMetaData(this, "mandatecig");
                    mcig.SetDefaults(DS.mandatecig);
                    DataRow drMandateCig = mcig.Get_New_Row(drMandate, DS.mandatecig);

                    drMandateCig["cigcode"] = drLotto["cig"];
                    drMandateCig["description"] = drLotto["oggetto"];
                    drMandateCig["contractamount"] = CfgFn.GetNoNullDecimal(drLotto["importoAggiudicazione"]);
                    if (drLotto["dataInizio"] == DBNull.Value)
                        drMandateCig["start_contract"] = DBNull.Value;
                    else
                        drMandateCig["start_contract"] = DateTime.Parse(drLotto["dataInizio"].ToString());
                    if (drLotto["dataUltimazione"] == DBNull.Value)
                        drMandateCig["stop_contract"] = DBNull.Value;
                    else
                        drMandateCig["stop_contract"] = DateTime.Parse(drLotto["dataUltimazione"].ToString());
                    drMandateCig["idavcp_choice"] = drLotto["sceltaContraente"];

                    // ==========================================================================================
                    // CIG con importoAggiudicazione maggiore
                    // ==========================================================================================
                    DataTable dtLottoCig = Conn.RUN_SELECT("wslotto", "cig", "importoAggiudicazione desc", filtroLotti, "1", null, false);
                    drMandate["cigcode"] = dtLottoCig.Rows[0]["cig"];


                    string partecipantiFields = "codiceFiscale,identificativoFiscaleEstero,ragioneSociale,ruolo";

                    // ==========================================================================================
                    //                                      PARTECIPANTI SINGOLI
                    // ==========================================================================================
                    string filter = QHS.AppAnd(QHC.CmpEq("idLotto", idLotto), QHS.IsNull("ruolo"));
                    DataTable dtPartecipanti = Conn.SQLRunner("select distinct codiceFiscale,identificativoFiscaleEstero,ragioneSociale,ruolo from wspartecipante where " + filter);

                    int idavcp = 1;

                    List<DataRow> dataRowList = GetDistinctDataRowList(dtPartecipanti.Rows);
                    if (dataRowList != null)
                    {
                        foreach (DataRow partecipante in dataRowList)
                        {
                            CreatePartecipante(drMandate, partecipante, idavcp, "S", DBNull.Value, DBNull.Value);

                            // Questo partecipante è l'aggiudicatario
                            if (partecipante["codiceFiscale"].Equals(FornitoreCFPIva))
                                idavcpAggiudicatario = idavcp;

                            idavcp++;
                        }
                    }

                    // ==========================================================================================
                    //                                  PARTECIPANTE CAPOGRUPPO
                    // ==========================================================================================
                    int? idmain_avcp = null;

                    filter = QHS.AppAnd(QHC.CmpEq("idLotto", idLotto), QHS.CmpEq("ruolo", CAPOGRUPPO));
                    dtPartecipanti = Conn.RUN_SELECT("wspartecipante", partecipantiFields, null, filter, null, null, false);

                    dataRowList = GetDistinctDataRowList(dtPartecipanti.Rows);
                    if (dataRowList != null)
                    {
                        if (dataRowList.Count() == 1)
                        {
                            DataRow partecipante = dtPartecipanti.Rows[0];

                            // ID DEL CAPOGRUPPO
                            CreatePartecipante(drMandate, partecipante, idavcp, "N", CAPOGRUPPO, DBNull.Value);

                            // Questo partecipante è l'aggiudicatario
                            if (partecipante["codiceFiscale"].Equals(FornitoreCFPIva))
                                idavcpAggiudicatario = idavcp;

                            idavcp++;

                            // ID DEL CAPOGRUPPO
                            idmain_avcp = idavcp;
                        }
                    }

                    if (idmain_avcp != null)
                    {
                        // ==========================================================================================
                        //                                  PARTECIPANTI NON CAPOGRUPPO
                        // ==========================================================================================
                        filter = QHS.AppAnd(QHC.CmpEq("idLotto", idLotto), QHS.CmpNe("ruolo", CAPOGRUPPO), QHS.IsNotNull("ruolo"));
                        dtPartecipanti = Conn.RUN_SELECT("wspartecipante", partecipantiFields, null, filter, null, null, false);

                        dataRowList = GetDistinctDataRowList(dtPartecipanti.Rows);
                        if (dataRowList != null)
                        {
                            foreach (DataRow partecipante in dataRowList)
                            {
                                CreatePartecipante(drMandate, partecipante, idavcp, "N", partecipante["ruolo"], idmain_avcp);

                                // Questo partecipante è l'aggiudicatario
                                if (partecipante["codiceFiscale"].Equals(FornitoreCFPIva))
                                    idavcpAggiudicatario = idavcp;

                                idavcp++;
                            }
                        }
                    }

                    drMandateCig["idavcp"] = idavcpAggiudicatario;
                }
                
                this.freshForm(true);


                // Filter 
                object[] objLotti = idLotti.ToArray();
                string filterAggiudicatario = QHS.AppAnd(QHC.FieldIn("idLotto", objLotti), QHC.CmpEq("codiceFiscale", FornitoreCFPIva));

                // ==========================================================================================
                // Filtro Dataset Aggiudicatario (per avvalorare la chiave)
                // ==========================================================================================
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.wsaggiudicatario, null, filterAggiudicatario, null, true);
                int rcnt = DS.wsaggiudicatario.Rows.Count;
                if (rcnt > 0)
                {
                    // Connect Mandate-Aggiudicatario
                    foreach (DataRow drAggiudicatario in DS.wsaggiudicatario.Rows)
                    {
                        drAggiudicatario["yman"] = drMandate["yman"];
                        drAggiudicatario["nman"] = drMandate["nman"];
                        drAggiudicatario["idmankind"] = drMandate["idmankind"];
                    }
                }

                Meta.MarkTableAsNotEntityChild(DS.wsaggiudicatario);
            }
        }

        private List<DataRow> GetDistinctDataRowList(DataRowCollection Rows)
        {
            List<DataRow> dataRowList = new List<DataRow>();

            foreach (DataRow row in Rows)
            {
                bool found = false;
				foreach (DataRow dr in dataRowList)
				{
                    found = true;
					for (int i = 0; i < dr.ItemArray.Length; i++)
					{
                        if (dr[i] != row[i])
                        {
                            found = false;
                            continue;
                        }
                    }

                    if (found == true)
                        continue;
				}
                
                if (!found)
                    dataRowList.Add(row);
            }

            return dataRowList;
        }

        private void CreatePartecipante(DataRow drMandate, DataRow partecipante, int idavcp, string flagcontractor, object role, object idmain_avcp)
        {
            MetaData mavcp = MetaData.GetMetaData(this, "mandateavcp");
            mavcp.SetDefaults(DS.mandateavcp);
            DataRow drMandateAvcp = mavcp.Get_New_Row(drMandate, DS.mandateavcp);

            int idRegPart = CfgFn.GetNoNullInt32(IndividuaAnagrafica(partecipante["codiceFiscale"], partecipante["ragioneSociale"]));
            if (idRegPart == 0)
            {
                show($"Non è stata individuata nessuna anagrafica per il Partecipante con codice fiscale '{partecipante["codiceFiscale"]}' o Ragione Sociale '{partecipante["ragioneSociale"]}'. Selezionarlo manualmente.");
            }

            drMandateAvcp["title"] = partecipante["ragioneSociale"];
            drMandateAvcp["cf"] = partecipante["codiceFiscale"];
            drMandateAvcp["foreigncf"] = partecipante["identificativoFiscaleEstero"];
            drMandateAvcp["flagcontractor"] = flagcontractor;
            drMandateAvcp["flagnonparticipating"] = "N";
            drMandateAvcp["idavcp_role"] = role;
            drMandateAvcp["idmain_avcp"] = idmain_avcp;
            drMandateAvcp["idreg"] = idRegPart;
            drMandateAvcp["idavcp"] = idavcp;

            return;
        }

        private object IndividuaAnagrafica(object identificativo, object RagioneSociale)
        {
            object idreg = DBNull.Value;

            // ==========================================================================================
            //                                  RICERCA per PIva
            // ==========================================================================================
            string filterAnagrafica = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("p_iva", identificativo));
            DataTable tAnag = Conn.RUN_SELECT("registry", "*", null, filterAnagrafica, null, false);
            int countReg = tAnag.Rows.Count;
            //La trova con la p.iva
            if (countReg == 1)
            {
                DataRow rRegistry = tAnag.Rows[0];
                idreg = rRegistry["idreg"];
                return idreg;
            }

            //Ne ha trovate più di una con quella p.iva
            if (countReg > 1)
            {
                show($"E' stata individuata più di una anagrafica per il Partecipante con codice fiscale '{identificativo}' o Ragione Sociale '{RagioneSociale}'. Clicca 'Ok' per selezionare.");
                string VistaScelta = "registrymainview";
                MetaData MRegistry = MetaData.GetMetaData(this, VistaScelta);
                MRegistry.FilterLocked = true;
                MRegistry.DS = DS;
                DataRow MyDR = MRegistry.SelectOne("default", filterAnagrafica, null, null);
                if (MyDR != null)
                {
                    idreg = MyDR["idreg"];
                    return idreg;
                }
            }

            // ==========================================================================================
            //                                  RICERCA per Codice Fiscale
            // ==========================================================================================
            //Non ne ha trovate con quella p.iva, e prova con la denominazione
            string filterAnagrCf = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("cf", identificativo));
            tAnag = Conn.RUN_SELECT("registry", "*", null, filterAnagrCf, null, false);
            countReg = tAnag.Rows.Count;
            //Ne trova un con quella denominazione
            if (countReg == 1)
            {
                DataRow rRegistry = tAnag.Rows[0];
                idreg = rRegistry["idreg"];
                return idreg;
            }

            //Ne ha trovate più di una con quella denominazione
            if (countReg > 1)
            {
                string VistaScelta = "registrymainview";
                MetaData MRegistry = MetaData.GetMetaData(this, VistaScelta);
                MRegistry.FilterLocked = true;
                MRegistry.DS = DS;
                DataRow MyDR = MRegistry.SelectOne("default", filterAnagrCf, null, null);
                if (MyDR != null)
                {
                    idreg = MyDR["idreg"];
                    return idreg;
                }
            }

            // ==========================================================================================
            //                                  RICERCA per Ragione Sociale
            // ==========================================================================================   
            if (!string.IsNullOrEmpty(RagioneSociale.ToString()))
            {
                //Non ne ha trovate con quella p.iva, e prova con la denominazione
                string filterAnagrDenominazione = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.Like("title", RagioneSociale.ToString()));
                tAnag = Conn.RUN_SELECT("registry", "*", null, filterAnagrDenominazione, null, false);
                countReg = tAnag.Rows.Count;
                //Ne trova un con quella denominazione
                if (countReg == 1)
                {
                    DataRow rRegistry = tAnag.Rows[0];
                    idreg = rRegistry["idreg"];
                    return idreg;
                }

                //Ne ha trovate più di una con quella denominazione
                if (countReg > 1)
                {
                    string VistaScelta = "registrymainview";
                    MetaData MRegistry = MetaData.GetMetaData(this, VistaScelta);
                    MRegistry.FilterLocked = true;
                    MRegistry.DS = DS;
                    DataRow MyDR = MRegistry.SelectOne("default", filterAnagrDenominazione, null, null);
                    if (MyDR != null)
                    {
                        idreg = MyDR["idreg"];
                        return idreg;
                    }
                }
            }

            return idreg;
        }

        public void ScollegaGaraTraspare() {
            int rcnt = DS.wsaggiudicatario.Rows.Count;
            if (rcnt > 0) {
                // Disconnect Mandate-Aggiudicatario
                foreach (DataRow drAggiudicatario in DS.wsaggiudicatario.Rows) {
                    drAggiudicatario["yman"] = DBNull.Value;
                    drAggiudicatario["nman"] = DBNull.Value;
                    drAggiudicatario["idmankind"] = DBNull.Value;
                }
            }
        }

        private void btnCurrencyExchange_Click(object sender, EventArgs e) {
            UiHelper.CreateForm(txtCambio, Conn, currentRow);
        }

        private void txtDataContabile_Leave(object sender, EventArgs e) {
            UiHelper.UpdateControls(currencyManager, txtCambio, currentRow, txtDataContabile.Text);
        }
    }
}
