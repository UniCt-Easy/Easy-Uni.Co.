/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using SituazioneViewer;
using funzioni_configurazione;
using metadatalibrary;
using System.Globalization;

namespace upb_default {
	/// <summary>
	/// Summary description for Frm_upb_default.
	/// </summary>
	public class Frm_upb_default :System.Windows.Forms.Form {
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC;
		QueryHelper QHS;

		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TabPage tabClassificazione;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.DataGrid dGridClassSup;
		private System.Windows.Forms.TextBox txtScadenza;
		private System.Windows.Forms.Label lblScadenza;
		private System.Windows.Forms.TextBox txtOrdineStampa;
		private System.Windows.Forms.Label lblOrdineStampa;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.Button btnEnteFin;
		private System.Windows.Forms.Button btnResponsabile;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TabControl MetaDataDetail;
		public upb_default.vistaForm DS;
		private System.Windows.Forms.TextBox txtFinRichiesto;
		private System.Windows.Forms.TextBox txtFinConcesso;
		private System.Windows.Forms.Button btnBilPrevisione;
		private System.Windows.Forms.CheckBox chbUpbAttivo;
		private System.Windows.Forms.CheckBox chbFinCerto;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnSituazioneAnnuale;
		private System.Windows.Forms.Button btnSituazionePluriennale;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private Label label5;
		private TextBox textBox2;
		private TabPage tabAttributi;
		private TabPage tabClassAutoSpese;
		private GroupBox groupBox4;
		private GroupBox groupBox3;
		private DataGrid dGridFilterClassExp;
		private Button btnEliminaFilterS;
		private Button btnModificaFilterS;
		private Button btnInserisciFilterS;
		private DataGrid dGridClassAutoExp;
		private Button btnEliminaClassS;
		private Button btnModificaClassS;
		private Button btnInserisciClassS;
		private TabPage tabPrevisione;
		private DataGrid dgPrevisione;
		private Button btnInsPrevisione;
		private Button btnEditPrevisione;
		private Button btnDelPrevisione;
		private GroupBox groupBox5;
		private DataGrid dgVariazioni;
		private TabPage tabRiepilogo;
		private GroupBox grpRiepilogo;
		private GroupBox grpPrevCompetenza_E;
		private Button btnAccertamentiCompetenza;
		private Label lblAccertamentiCompetenza;
		private TextBox txtAccertamentiCompetenza;
		private Label label9;
		private Button btnVarPrevCompetenza_E;
		private Label lblVarPrevCompetenza_E;
		private TextBox txtVarPrevCompetenza_E;
		private Label lblPrevDispCompetenza_E;
		private TextBox txtPrevDispCompetenza_E;
		private Button btnPrevInizialeCompetenza_E;
		private Label lblPrevInizialeCompetenza_E;
		private TextBox txtPrevInizialeCompetenza_E;
		private TabControl tabCtrl;
		private TabPage tabPage1;
		private TabPage tabPage2;
		private GroupBox grpPrevCompetenza_S;
		private Label label11;
		private Button btnVarPrevCompetenza_S;
		private Label lblVarPrevCompetenza_S;
		private TextBox txtVarPrevCompetenza_S;
		private Label lblPrevDispCompetenza_S;
		private TextBox txtPrevDispCompetenza_S;
		private Button btnImpegni;
		private Label lblImpegni;
		private TextBox txtImpegniCompetenza;
		private Button btnPrevInizialeCompetenza_S;
		private Label lblPrevInizialeCompetenza_S;
		private TextBox txtPrevInizialeCompetenza_S;
		private GroupBox grpPrevCassa_S;
		private Label label8;
		private Button btnVarPrevisioneCassa_S;
		private Label lblVarPrevisioneCassa_S;
		private TextBox txtVarPrevisioneCassa_S;
		private Label lblPrevDispCassa_S;
		private TextBox txtPrevDispCassa_S;
		private Button btnPagamenti;
		private Label lblPagamenti;
		private TextBox txtPagamenti;
		private Button btnPrevInizialeCassa_S;
		private Label lblPrevInizialeCassa_S;
		private TextBox txtPrevInizialeCassa_S;
		private GroupBox grpCassa;
		private Button btnVarDotazioneCassa;
		private Label lblVarDotazioneCassa;
		private TextBox txtVarDotazioneCassa;
		private Label label6;
		private Button btnDotazioneCassa;
		private Label lblDotazioneCassa;
		private TextBox txtDotazioneCassa;
		private Label lblCassaResidua;
		private TextBox txtCassaResidua;
		private Button btnAssegnazioniCassa;
		private Label lblAssegnazioniCassa;
		private TextBox txtAssegnazioniCassa;
		private GroupBox grpCrediti;
		private Button btnVarDotazioneCrediti;
		private Label lblVarDotazioneCrediti;
		private TextBox txtVarDotazioneCrediti;
		private Label label7;
		private Button btnDotazioneCrediti;
		private Label lblDotazioneCrediti;
		private TextBox txtDotazioneCrediti;
		private Label lblCreditiResidui;
		private TextBox txtCreditiResidui;
		private Button btnCreditiAssegnati;
		private Label lblCreditiAssegnati;
		private TextBox txtCreditiAssegnati;
		private GroupBox grpPrevCassa_E;
		private Label label10;
		private Button btnVarPrevCassa_E;
		private Label lblVarPrevCassa_E;
		private TextBox txtVarPrevCassa_E;
		private Label lblPrevDispCassa_E;
		private TextBox txtPrevDispCassa_E;
		private Button btnIncassi;
		private Label lblIncassi;
		private TextBox txtIncassi;
		private Button btnPrevInizialeCassa_E;
		private Label lblPrevInizialeCassa_E;
		private TextBox txtPrevInizialeCassa_E;
		private Button btnPagamenti1;
		private Label lblPagamenti1;
		private TextBox txtPagamenti1;
		private Button btnPiccoleSpeseImp;
		private Label lblPiccoleSpeseImp;
		private TextBox txtPiccoleSpeseImp;
		private Button btnPiccoleSpesePagamenti;
		private Label lblPiccoleSpesePagamenti;
		private TextBox txtPiccoleSpesePagamenti;
		private Button btnPiccoleSpesePagamenti1;
		private Label lblPiccoleSpesePagamenti1;
		private TextBox txtPiccoleSpesePagamenti1;
		private TabPage tabClassAutoEntrate;
		private GroupBox groupBox6;
		private DataGrid dGridFilterClassInc;
		private Button btnEliminaFilterE;
		private Button btnModificaFilterE;
		private Button btnInserisciFilterE;
		private GroupBox groupBox7;
		private DataGrid dGridClassAutoInc;
		private Button btnEliminaClassE;
		private Button btnModificaClassE;
		private Button btnInserisciClassE;
		private GroupBox grpAttivita;
		private RadioButton radCommerciale;
		private RadioButton radioButton1;
		private RadioButton radioButton2;
		private GroupBox Funzione;
		private CheckBox chkRicerca;
		private CheckBox chkDidattica;
		private TextBox txtCodiceConsolidamento;
		private Label label12;
		private ComboBox cmbIstitutoCassiere;
		private Button btnIstitutoCassiere;
		private TabPage tabPage3;
		private Button btnCalcolaTutto;
		private GroupBox gboxUnderwriting;
		public TextBox txtUnderwriting;
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
		private Label label14;
		private Label label13;
		private TextBox textBox5;
		private TextBox textBox4;
		private TextBox textBox6;
		private Label label15;
		private Label label16;
		private CheckBox checkBox1;
		private TabPage tabBudget;
		private GroupBox groupBox2;
		private DataGrid dgBudgetVar;
		private DataGrid dgBudget;
		private Button button1;
		private Button button2;
		private Button button3;
		private TabPage tabBudgetRiep;
		private Button btnSituazioneBudget;
		private Button btnSitBudgetAnnuale;
		private Button btnBudgetUPB;
		private Label label23;
		private Label label24;
		private TextBox txtPrevAttualeCompetenzaE;
		private Label label25;
		private Label label26;
		private TextBox txtPrevAttualeCassaE;
		private Label label27;
		private Label label28;
		private TextBox txtPrevAttualeCompetenzaS;
		private Label label29;
		private Label label30;
		private TextBox txtPrevAttualeCassaS;
		private Label label31;
		private Label labelTotaleCrediti;
		private TextBox txtTotaleCrediti;
		private Label label32;
		private Label labelTotaleCassa;
		private TextBox txtTotaleCassa;
		private System.ComponentModel.IContainer components;
		private CheckBox chkUpbChilds;
		private TabPage tabAltro;
		private Label label33;
		private ComboBox cmbEPUPBKind;
		private BindingSource upbBindingSource;
		private GroupBox groupBox8;
		private DataGrid dataGrid1;
		private Button button4;
		private Button button5;
		private Button button6;
		private TabPage tabPage4;
		private DataGrid dataGrid3;
		private Button button7;
		private Button button8;
		private Button button9;
		private GroupBox grpDatiPrevisioneBudget;
		private Label label36;
		private TextBox SubEntity_txtCostiPresunti;
		private TextBox SubEntity_txtRicaviPresunti;
		private Label label37;
		private Button btnInsDettagli;
		private GroupBox grpBlocca;
		private CheckBox SubEntity_chkBloccaCoFi;
		private CheckBox SubEntity_chkBloccaCoGe;
		private GroupBox groupBox9;
		private CheckBox chkBloccaCoFiMovimenti;
		private CheckBox chkBloccaCoGeMovimenti;
		private TabPage tabPage5;
		private TextBox txtFondoAccantonamentoDare;
		private TextBox txtRiservaDare;
		private TextBox txtRiscontiPassiviDare;
		private TextBox txtRiscontiAttiviDare;
		private Label label49;
		private Label label48;
		private Label label47;
		private Label label46;
		private Label label38;
		private TextBox txtRateiAttiviDare;
		private TextBox txtContiDebitoDare;
		private Label label39;
		private Label label40;
		private TextBox txtContiCreditoDare;
		private Label label42;
		private TextBox txtImmobilizzazioniDare;
		private Label label43;
		private TextBox txtRateiPassiviDare;
		private Label label44;
		private TextBox txtRicaviDare;
		private Label label45;
		private TextBox txtCostiDare;
		private Label label50;
		private Label label41;
		private Button FondoAccantonamentoDareAvere;
		private Button RiservaDareAvere;
		private Button RiscontiPassiviDareAvere;
		private Button RiscontiAttiviDareAvere;
		private Button RateiPassiviDareAvere;
		private TextBox txtFondoAccantonamentoAvere;
		private TextBox txtRiservaAvere;
		private TextBox txtRiscontiPassiviAvere;
		private TextBox txtRiscontiAttiviAvere;
		private Button RateiAttiviDareAvere;
		private TextBox txtRateiAttiviAvere;
		private TextBox txtContiDebitoAvere;
		private Button ContiDebitoDareAvere;
		private Button ContiCreditoDareAvere;
		private TextBox txtContiCreditoAvere;
		private Button ImmobilizzazioniDareAvere;
		private TextBox txtImmobilizzazioniAvere;
		private TextBox txtRateiPassiviAvere;
		private Button RicaviDareAvere;
		private TextBox txtRicaviAvere;
		private Button CostiDareAvere;
		private TextBox txtCostiAvere;
		private Label label51;
		private TextBox txtFondoAccantonamentoDifferenza;
		private TextBox txtRiservaDifferenza;
		private TextBox txtRiscontiPassiviDifferenza;
		private TextBox txtRiscontiAttiviDifferenza;
		private TextBox txtRateiAttiviDifferenza;
		private TextBox txtContiDebitoDifferenza;
		private TextBox txtContiCreditoDifferenza;
		private TextBox txtImmobilizzazioniDifferenza;
		private TextBox txtRateiPassiviDifferenza;
		private TextBox txtRicaviDifferenza;
		private TextBox txtCostiDifferenza;
		private TextBox txtDisponibilit‡liquideDifferenza;
		private Button Disponibilit‡liquideDareAvere;
		private TextBox txtDisponibilit‡liquideAvere;
		private TextBox txtDisponibilit‡liquideDare;
		private Label label52;
		private TextBox txtAltrevociAttivoDifferenza;
		private Button AltrevociAttivoDareAvere;
		private TextBox txtAltrevociAttivoAvere;
		private TextBox txtAltrevociAttivoDare;
		private Label label53;
		private TextBox txtAltrevociPassivoDifferenza;
		private Button AltrevociPassivoDareAvere;
		private TextBox txtAltrevociPassivoAvere;
		private TextBox txtAltrevociPassivoDare;
		private Label label55;
		private TextBox txtFondiAmmortamentoDifferenza;
		private Button FondiAmmortamentoDareAvere;
		private TextBox txtFondiAmmortamentoAvere;
		private TextBox txtFondiAmmortamentoDare;
		private Label label54;
		private GroupBox groupBox11;
		private Button btnVarAccertamentiBudget;
		private Label label56;
		private TextBox txtVarAccertamentiBudget;
		private TextBox txtVarPreaccertamenti;
		private Label label57;
		private Button btnVarPreaccertamentiBudget;
		private Button btnAccertamentiBudget;
		private Label label58;
		private TextBox txtAccertamentiBudget;
		private Label label59;
		private Button btnVarBudgetAcc;
		private Label label60;
		private TextBox txtVarBudgetAcc;
		private Label label61;
		private TextBox txtBudgetdisponibilePreaccertmenti;
		private Button btnPreaccertamentiBudget;
		private Label label62;
		private TextBox txtPreaccertamentiBudget;
		private Button btnBudgetInizialeAcc;
		private Label label63;
		private TextBox txtBudgetInizialeAcc;
		private GroupBox groupBox10;
		private Button btnVarImpegniBudget;
		private Label label34;
		private TextBox txtVarImpegniBudget;
		private TextBox txtVarPreimpegni;
		private Label label35;
		private Button btnVarPreimpegni;
		private Button btnImpegniBudget;
		private Label label17;
		private TextBox txtImpegniBudget;
		private Label label18;
		private Button btnVarBudgetImp;
		private Label label19;
		private TextBox txtVarBudgetImp;
		private Label label20;
		private TextBox txtBudgetdisponibilePreimpegni;
		private Button btnPreimpegniBudget;
		private Label label21;
		private TextBox txtPreimpegniBudget;
		private Button btnBudgetInizialeImp;
		private Label label22;
		private TextBox txtBudgetInizialeImp;
		CalcoliFinanziario calcFin;
		private CheckBox checkBox2;
		private Button btnAccertamentiAll;
		private Label lblAccertamentiAll;
		private TextBox txtAccertamentiAll;
		private TextBox txtPrevDispCassaPerAccertamenti;
		private Label label64;
		private Label lblPrevDispCassaAccertamenti;
		private Button btnImpegniAll;
		private Label lblImpegniAll;
		private TextBox txtImpegniAll;
		private TextBox txtPrevDispCassaPerImpegni;
		private Label label65;
		private Label lblPrevDispCassaImpegni;
		private TabPage tabFabbisogno;
		private Label label69;
		private GroupBox grpCodUE;
		private RadioButton rdbUE04;
		private RadioButton rdbUE03;
		private RadioButton rdbUE02;
		private RadioButton rdbUE01;
		private ComboBox cmbCofog;
		private Label label66;

		delegate string myUPBComparator(string field, object value);
		myUPBComparator upbComp;

		public Frm_upb_default() {
			InitializeComponent();

			DS.upbsorting.ExtendedProperties["ViewTable"] = DS.upbsortingview;
			DS.sortingview.ExtendedProperties["ViewTable"] = DS.upbsortingview;
			DS.upbsortingview.ExtendedProperties["RealTable"] = DS.upbsorting;

			DS.upbsortingview.Columns["idupb"].ExtendedProperties["ViewSource"] = "upbsorting.idupb";
			DS.upbsortingview.Columns["quota"].ExtendedProperties["ViewSource"] = "upbsorting.quota";
			DS.upbsortingview.Columns["idsor"].ExtendedProperties["ViewSource"] = "upbsorting.idsor";
			DS.upbsortingview.Columns["ct"].ExtendedProperties["ViewSource"] = "upbsorting.ct";
			DS.upbsortingview.Columns["cu"].ExtendedProperties["ViewSource"] = "upbsorting.cu";
			DS.upbsortingview.Columns["lt"].ExtendedProperties["ViewSource"] = "upbsorting.lt";
			DS.upbsortingview.Columns["lu"].ExtendedProperties["ViewSource"] = "upbsorting.lu";

			DS.upbsortingview.Columns["sortingkind"].ExtendedProperties["ViewSource"] = "sortingview.sortingkind";
			DS.upbsortingview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sortingview.sortcode";
			DS.upbsortingview.Columns["sorting"].ExtendedProperties["ViewSource"] = "sortingview.description";

			upbComp = UpbCompareEqual;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_upb_default));
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.MetaDataDetail = new System.Windows.Forms.TabControl();
			this.tabPrincipale = new System.Windows.Forms.TabPage();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.btnSituazioneAnnuale = new System.Windows.Forms.Button();
			this.btnSituazionePluriennale = new System.Windows.Forms.Button();
			this.gboxResponsabile = new System.Windows.Forms.GroupBox();
			this.txtResponsabile = new System.Windows.Forms.TextBox();
			this.btnResponsabile = new System.Windows.Forms.Button();
			this.gboxUnderwriting = new System.Windows.Forms.GroupBox();
			this.txtUnderwriting = new System.Windows.Forms.TextBox();
			this.btnEnteFin = new System.Windows.Forms.Button();
			this.cmbIstitutoCassiere = new System.Windows.Forms.ComboBox();
			this.DS = new upb_default.vistaForm();
			this.btnIstitutoCassiere = new System.Windows.Forms.Button();
			this.txtCodiceConsolidamento = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.Funzione = new System.Windows.Forms.GroupBox();
			this.chkRicerca = new System.Windows.Forms.CheckBox();
			this.chkDidattica = new System.Windows.Forms.CheckBox();
			this.grpAttivita = new System.Windows.Forms.GroupBox();
			this.radCommerciale = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnBilPrevisione = new System.Windows.Forms.Button();
			this.chbUpbAttivo = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFinRichiesto = new System.Windows.Forms.TextBox();
			this.txtFinConcesso = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chbFinCerto = new System.Windows.Forms.CheckBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtScadenza = new System.Windows.Forms.TextBox();
			this.lblScadenza = new System.Windows.Forms.Label();
			this.txtOrdineStampa = new System.Windows.Forms.TextBox();
			this.lblOrdineStampa = new System.Windows.Forms.Label();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.lblDenominazione = new System.Windows.Forms.Label();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.lblCodice = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tabPrevisione = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.dgVariazioni = new System.Windows.Forms.DataGrid();
			this.dgPrevisione = new System.Windows.Forms.DataGrid();
			this.btnInsPrevisione = new System.Windows.Forms.Button();
			this.btnEditPrevisione = new System.Windows.Forms.Button();
			this.btnDelPrevisione = new System.Windows.Forms.Button();
			this.tabBudget = new System.Windows.Forms.TabPage();
			this.btnSituazioneBudget = new System.Windows.Forms.Button();
			this.btnSitBudgetAnnuale = new System.Windows.Forms.Button();
			this.btnBudgetUPB = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgBudgetVar = new System.Windows.Forms.DataGrid();
			this.dgBudget = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabClassificazione = new System.Windows.Forms.TabPage();
			this.dGridClassSup = new System.Windows.Forms.DataGrid();
			this.btnElimina = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
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
			this.tabClassAutoSpese = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dGridFilterClassExp = new System.Windows.Forms.DataGrid();
			this.btnEliminaFilterS = new System.Windows.Forms.Button();
			this.btnModificaFilterS = new System.Windows.Forms.Button();
			this.btnInserisciFilterS = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dGridClassAutoExp = new System.Windows.Forms.DataGrid();
			this.btnEliminaClassS = new System.Windows.Forms.Button();
			this.btnModificaClassS = new System.Windows.Forms.Button();
			this.btnInserisciClassS = new System.Windows.Forms.Button();
			this.tabClassAutoEntrate = new System.Windows.Forms.TabPage();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.dGridFilterClassInc = new System.Windows.Forms.DataGrid();
			this.btnEliminaFilterE = new System.Windows.Forms.Button();
			this.btnModificaFilterE = new System.Windows.Forms.Button();
			this.btnInserisciFilterE = new System.Windows.Forms.Button();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.dGridClassAutoInc = new System.Windows.Forms.DataGrid();
			this.btnEliminaClassE = new System.Windows.Forms.Button();
			this.btnModificaClassE = new System.Windows.Forms.Button();
			this.btnInserisciClassE = new System.Windows.Forms.Button();
			this.tabRiepilogo = new System.Windows.Forms.TabPage();
			this.grpRiepilogo = new System.Windows.Forms.GroupBox();
			this.chkUpbChilds = new System.Windows.Forms.CheckBox();
			this.tabCtrl = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.grpPrevCassa_E = new System.Windows.Forms.GroupBox();
			this.txtPrevDispCassaPerAccertamenti = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.lblPrevDispCassaAccertamenti = new System.Windows.Forms.Label();
			this.btnAccertamentiAll = new System.Windows.Forms.Button();
			this.lblAccertamentiAll = new System.Windows.Forms.Label();
			this.txtAccertamentiAll = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCassaE = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnVarPrevCassa_E = new System.Windows.Forms.Button();
			this.lblVarPrevCassa_E = new System.Windows.Forms.Label();
			this.txtVarPrevCassa_E = new System.Windows.Forms.TextBox();
			this.lblPrevDispCassa_E = new System.Windows.Forms.Label();
			this.txtPrevDispCassa_E = new System.Windows.Forms.TextBox();
			this.btnIncassi = new System.Windows.Forms.Button();
			this.lblIncassi = new System.Windows.Forms.Label();
			this.txtIncassi = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCassa_E = new System.Windows.Forms.Button();
			this.lblPrevInizialeCassa_E = new System.Windows.Forms.Label();
			this.txtPrevInizialeCassa_E = new System.Windows.Forms.TextBox();
			this.grpPrevCompetenza_E = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCompetenzaE = new System.Windows.Forms.TextBox();
			this.btnAccertamentiCompetenza = new System.Windows.Forms.Button();
			this.lblAccertamentiCompetenza = new System.Windows.Forms.Label();
			this.txtAccertamentiCompetenza = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnVarPrevCompetenza_E = new System.Windows.Forms.Button();
			this.lblVarPrevCompetenza_E = new System.Windows.Forms.Label();
			this.txtVarPrevCompetenza_E = new System.Windows.Forms.TextBox();
			this.lblPrevDispCompetenza_E = new System.Windows.Forms.Label();
			this.txtPrevDispCompetenza_E = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCompetenza_E = new System.Windows.Forms.Button();
			this.lblPrevInizialeCompetenza_E = new System.Windows.Forms.Label();
			this.txtPrevInizialeCompetenza_E = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.grpPrevCompetenza_S = new System.Windows.Forms.GroupBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCompetenzaS = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpeseImp = new System.Windows.Forms.Button();
			this.lblPiccoleSpeseImp = new System.Windows.Forms.Label();
			this.txtPiccoleSpeseImp = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btnVarPrevCompetenza_S = new System.Windows.Forms.Button();
			this.lblVarPrevCompetenza_S = new System.Windows.Forms.Label();
			this.txtVarPrevCompetenza_S = new System.Windows.Forms.TextBox();
			this.lblPrevDispCompetenza_S = new System.Windows.Forms.Label();
			this.txtPrevDispCompetenza_S = new System.Windows.Forms.TextBox();
			this.btnImpegni = new System.Windows.Forms.Button();
			this.lblImpegni = new System.Windows.Forms.Label();
			this.txtImpegniCompetenza = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCompetenza_S = new System.Windows.Forms.Button();
			this.lblPrevInizialeCompetenza_S = new System.Windows.Forms.Label();
			this.txtPrevInizialeCompetenza_S = new System.Windows.Forms.TextBox();
			this.grpPrevCassa_S = new System.Windows.Forms.GroupBox();
			this.txtPrevDispCassaPerImpegni = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.lblPrevDispCassaImpegni = new System.Windows.Forms.Label();
			this.btnImpegniAll = new System.Windows.Forms.Button();
			this.lblImpegniAll = new System.Windows.Forms.Label();
			this.txtImpegniAll = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.txtPrevAttualeCassaS = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpesePagamenti = new System.Windows.Forms.Button();
			this.lblPiccoleSpesePagamenti = new System.Windows.Forms.Label();
			this.txtPiccoleSpesePagamenti = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnVarPrevisioneCassa_S = new System.Windows.Forms.Button();
			this.lblVarPrevisioneCassa_S = new System.Windows.Forms.Label();
			this.txtVarPrevisioneCassa_S = new System.Windows.Forms.TextBox();
			this.lblPrevDispCassa_S = new System.Windows.Forms.Label();
			this.txtPrevDispCassa_S = new System.Windows.Forms.TextBox();
			this.btnPagamenti = new System.Windows.Forms.Button();
			this.lblPagamenti = new System.Windows.Forms.Label();
			this.txtPagamenti = new System.Windows.Forms.TextBox();
			this.btnPrevInizialeCassa_S = new System.Windows.Forms.Button();
			this.lblPrevInizialeCassa_S = new System.Windows.Forms.Label();
			this.txtPrevInizialeCassa_S = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.grpCrediti = new System.Windows.Forms.GroupBox();
			this.label31 = new System.Windows.Forms.Label();
			this.labelTotaleCrediti = new System.Windows.Forms.Label();
			this.txtTotaleCrediti = new System.Windows.Forms.TextBox();
			this.btnVarDotazioneCrediti = new System.Windows.Forms.Button();
			this.lblVarDotazioneCrediti = new System.Windows.Forms.Label();
			this.txtVarDotazioneCrediti = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnDotazioneCrediti = new System.Windows.Forms.Button();
			this.lblDotazioneCrediti = new System.Windows.Forms.Label();
			this.txtDotazioneCrediti = new System.Windows.Forms.TextBox();
			this.lblCreditiResidui = new System.Windows.Forms.Label();
			this.txtCreditiResidui = new System.Windows.Forms.TextBox();
			this.btnCreditiAssegnati = new System.Windows.Forms.Button();
			this.lblCreditiAssegnati = new System.Windows.Forms.Label();
			this.txtCreditiAssegnati = new System.Windows.Forms.TextBox();
			this.grpCassa = new System.Windows.Forms.GroupBox();
			this.label32 = new System.Windows.Forms.Label();
			this.labelTotaleCassa = new System.Windows.Forms.Label();
			this.txtTotaleCassa = new System.Windows.Forms.TextBox();
			this.btnPiccoleSpesePagamenti1 = new System.Windows.Forms.Button();
			this.lblPiccoleSpesePagamenti1 = new System.Windows.Forms.Label();
			this.txtPiccoleSpesePagamenti1 = new System.Windows.Forms.TextBox();
			this.btnPagamenti1 = new System.Windows.Forms.Button();
			this.lblPagamenti1 = new System.Windows.Forms.Label();
			this.txtPagamenti1 = new System.Windows.Forms.TextBox();
			this.btnVarDotazioneCassa = new System.Windows.Forms.Button();
			this.lblVarDotazioneCassa = new System.Windows.Forms.Label();
			this.txtVarDotazioneCassa = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnDotazioneCassa = new System.Windows.Forms.Button();
			this.lblDotazioneCassa = new System.Windows.Forms.Label();
			this.txtDotazioneCassa = new System.Windows.Forms.TextBox();
			this.lblCassaResidua = new System.Windows.Forms.Label();
			this.txtCassaResidua = new System.Windows.Forms.TextBox();
			this.btnAssegnazioniCassa = new System.Windows.Forms.Button();
			this.lblAssegnazioniCassa = new System.Windows.Forms.Label();
			this.txtAssegnazioniCassa = new System.Windows.Forms.TextBox();
			this.tabBudgetRiep = new System.Windows.Forms.TabPage();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.btnVarAccertamentiBudget = new System.Windows.Forms.Button();
			this.label56 = new System.Windows.Forms.Label();
			this.txtVarAccertamentiBudget = new System.Windows.Forms.TextBox();
			this.txtVarPreaccertamenti = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.btnVarPreaccertamentiBudget = new System.Windows.Forms.Button();
			this.btnAccertamentiBudget = new System.Windows.Forms.Button();
			this.label58 = new System.Windows.Forms.Label();
			this.txtAccertamentiBudget = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.btnVarBudgetAcc = new System.Windows.Forms.Button();
			this.label60 = new System.Windows.Forms.Label();
			this.txtVarBudgetAcc = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.txtBudgetdisponibilePreaccertmenti = new System.Windows.Forms.TextBox();
			this.btnPreaccertamentiBudget = new System.Windows.Forms.Button();
			this.label62 = new System.Windows.Forms.Label();
			this.txtPreaccertamentiBudget = new System.Windows.Forms.TextBox();
			this.btnBudgetInizialeAcc = new System.Windows.Forms.Button();
			this.label63 = new System.Windows.Forms.Label();
			this.txtBudgetInizialeAcc = new System.Windows.Forms.TextBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.btnVarImpegniBudget = new System.Windows.Forms.Button();
			this.label34 = new System.Windows.Forms.Label();
			this.txtVarImpegniBudget = new System.Windows.Forms.TextBox();
			this.txtVarPreimpegni = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.btnVarPreimpegni = new System.Windows.Forms.Button();
			this.btnImpegniBudget = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.txtImpegniBudget = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.btnVarBudgetImp = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.txtVarBudgetImp = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtBudgetdisponibilePreimpegni = new System.Windows.Forms.TextBox();
			this.btnPreimpegniBudget = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.txtPreimpegniBudget = new System.Windows.Forms.TextBox();
			this.btnBudgetInizialeImp = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.txtBudgetInizialeImp = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtAltrevociPassivoDifferenza = new System.Windows.Forms.TextBox();
			this.AltrevociPassivoDareAvere = new System.Windows.Forms.Button();
			this.txtAltrevociPassivoAvere = new System.Windows.Forms.TextBox();
			this.txtAltrevociPassivoDare = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.txtFondiAmmortamentoDifferenza = new System.Windows.Forms.TextBox();
			this.FondiAmmortamentoDareAvere = new System.Windows.Forms.Button();
			this.txtFondiAmmortamentoAvere = new System.Windows.Forms.TextBox();
			this.txtFondiAmmortamentoDare = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.txtAltrevociAttivoDifferenza = new System.Windows.Forms.TextBox();
			this.AltrevociAttivoDareAvere = new System.Windows.Forms.Button();
			this.txtAltrevociAttivoAvere = new System.Windows.Forms.TextBox();
			this.txtAltrevociAttivoDare = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.txtDisponibilit‡liquideDifferenza = new System.Windows.Forms.TextBox();
			this.Disponibilit‡liquideDareAvere = new System.Windows.Forms.Button();
			this.txtDisponibilit‡liquideAvere = new System.Windows.Forms.TextBox();
			this.txtDisponibilit‡liquideDare = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.txtFondoAccantonamentoDifferenza = new System.Windows.Forms.TextBox();
			this.txtRiservaDifferenza = new System.Windows.Forms.TextBox();
			this.txtRiscontiPassiviDifferenza = new System.Windows.Forms.TextBox();
			this.txtRiscontiAttiviDifferenza = new System.Windows.Forms.TextBox();
			this.txtRateiAttiviDifferenza = new System.Windows.Forms.TextBox();
			this.txtContiDebitoDifferenza = new System.Windows.Forms.TextBox();
			this.txtContiCreditoDifferenza = new System.Windows.Forms.TextBox();
			this.txtImmobilizzazioniDifferenza = new System.Windows.Forms.TextBox();
			this.txtRateiPassiviDifferenza = new System.Windows.Forms.TextBox();
			this.txtRicaviDifferenza = new System.Windows.Forms.TextBox();
			this.txtCostiDifferenza = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.FondoAccantonamentoDareAvere = new System.Windows.Forms.Button();
			this.RiservaDareAvere = new System.Windows.Forms.Button();
			this.RiscontiPassiviDareAvere = new System.Windows.Forms.Button();
			this.RiscontiAttiviDareAvere = new System.Windows.Forms.Button();
			this.RateiPassiviDareAvere = new System.Windows.Forms.Button();
			this.txtFondoAccantonamentoAvere = new System.Windows.Forms.TextBox();
			this.txtRiservaAvere = new System.Windows.Forms.TextBox();
			this.txtRiscontiPassiviAvere = new System.Windows.Forms.TextBox();
			this.txtRiscontiAttiviAvere = new System.Windows.Forms.TextBox();
			this.RateiAttiviDareAvere = new System.Windows.Forms.Button();
			this.txtRateiAttiviAvere = new System.Windows.Forms.TextBox();
			this.txtContiDebitoAvere = new System.Windows.Forms.TextBox();
			this.ContiDebitoDareAvere = new System.Windows.Forms.Button();
			this.ContiCreditoDareAvere = new System.Windows.Forms.Button();
			this.txtContiCreditoAvere = new System.Windows.Forms.TextBox();
			this.ImmobilizzazioniDareAvere = new System.Windows.Forms.Button();
			this.txtImmobilizzazioniAvere = new System.Windows.Forms.TextBox();
			this.txtRateiPassiviAvere = new System.Windows.Forms.TextBox();
			this.RicaviDareAvere = new System.Windows.Forms.Button();
			this.txtRicaviAvere = new System.Windows.Forms.TextBox();
			this.CostiDareAvere = new System.Windows.Forms.Button();
			this.txtCostiAvere = new System.Windows.Forms.TextBox();
			this.txtFondoAccantonamentoDare = new System.Windows.Forms.TextBox();
			this.txtRiservaDare = new System.Windows.Forms.TextBox();
			this.txtRiscontiPassiviDare = new System.Windows.Forms.TextBox();
			this.txtRiscontiAttiviDare = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.label48 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.txtRateiAttiviDare = new System.Windows.Forms.TextBox();
			this.txtContiDebitoDare = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.txtContiCreditoDare = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.txtImmobilizzazioniDare = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.txtRateiPassiviDare = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.txtRicaviDare = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.txtCostiDare = new System.Windows.Forms.TextBox();
			this.btnCalcolaTutto = new System.Windows.Forms.Button();
			this.tabAltro = new System.Windows.Forms.TabPage();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox9 = new System.Windows.Forms.GroupBox();
			this.chkBloccaCoFiMovimenti = new System.Windows.Forms.CheckBox();
			this.chkBloccaCoGeMovimenti = new System.Windows.Forms.CheckBox();
			this.grpBlocca = new System.Windows.Forms.GroupBox();
			this.SubEntity_chkBloccaCoFi = new System.Windows.Forms.CheckBox();
			this.SubEntity_chkBloccaCoGe = new System.Windows.Forms.CheckBox();
			this.grpDatiPrevisioneBudget = new System.Windows.Forms.GroupBox();
			this.label36 = new System.Windows.Forms.Label();
			this.SubEntity_txtCostiPresunti = new System.Windows.Forms.TextBox();
			this.SubEntity_txtRicaviPresunti = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.btnInsDettagli = new System.Windows.Forms.Button();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.cmbEPUPBKind = new System.Windows.Forms.ComboBox();
			this.label33 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.dataGrid3 = new System.Windows.Forms.DataGrid();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.tabFabbisogno = new System.Windows.Forms.TabPage();
			this.label66 = new System.Windows.Forms.Label();
			this.cmbCofog = new System.Windows.Forms.ComboBox();
			this.label69 = new System.Windows.Forms.Label();
			this.grpCodUE = new System.Windows.Forms.GroupBox();
			this.rdbUE04 = new System.Windows.Forms.RadioButton();
			this.rdbUE03 = new System.Windows.Forms.RadioButton();
			this.rdbUE02 = new System.Windows.Forms.RadioButton();
			this.rdbUE01 = new System.Windows.Forms.RadioButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.upbBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.MetaDataDetail.SuspendLayout();
			this.tabPrincipale.SuspendLayout();
			this.gboxResponsabile.SuspendLayout();
			this.gboxUnderwriting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.Funzione.SuspendLayout();
			this.grpAttivita.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPrevisione.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).BeginInit();
			this.tabBudget.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgBudgetVar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgBudget)).BeginInit();
			this.tabClassificazione.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabClassAutoSpese.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassExp)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoExp)).BeginInit();
			this.tabClassAutoEntrate.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassInc)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoInc)).BeginInit();
			this.tabRiepilogo.SuspendLayout();
			this.grpRiepilogo.SuspendLayout();
			this.tabCtrl.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.grpPrevCassa_E.SuspendLayout();
			this.grpPrevCompetenza_E.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.grpPrevCompetenza_S.SuspendLayout();
			this.grpPrevCassa_S.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.grpCrediti.SuspendLayout();
			this.grpCassa.SuspendLayout();
			this.tabBudgetRiep.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabAltro.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.grpBlocca.SuspendLayout();
			this.grpDatiPrevisioneBudget.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
			this.tabFabbisogno.SuspendLayout();
			this.grpCodUE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.upbBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.HideSelection = false;
			this.treeView1.HotTracking = true;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.icons;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.ShowPlusMinus = false;
			this.treeView1.Size = new System.Drawing.Size(326, 553);
			this.treeView1.TabIndex = 0;
			this.treeView1.Tag = "upb.tree";
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// icons
			// 
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			this.icons.Images.SetKeyName(0, "");
			this.icons.Images.SetKeyName(1, "");
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.tabPrincipale);
			this.MetaDataDetail.Controls.Add(this.tabPrevisione);
			this.MetaDataDetail.Controls.Add(this.tabBudget);
			this.MetaDataDetail.Controls.Add(this.tabClassificazione);
			this.MetaDataDetail.Controls.Add(this.tabAttributi);
			this.MetaDataDetail.Controls.Add(this.tabClassAutoSpese);
			this.MetaDataDetail.Controls.Add(this.tabClassAutoEntrate);
			this.MetaDataDetail.Controls.Add(this.tabRiepilogo);
			this.MetaDataDetail.Controls.Add(this.tabAltro);
			this.MetaDataDetail.Controls.Add(this.tabPage4);
			this.MetaDataDetail.Controls.Add(this.tabFabbisogno);
			this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MetaDataDetail.HotTrack = true;
			this.MetaDataDetail.ImageList = this.imageList1;
			this.MetaDataDetail.Location = new System.Drawing.Point(326, 0);
			this.MetaDataDetail.Multiline = true;
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.SelectedIndex = 0;
			this.MetaDataDetail.Size = new System.Drawing.Size(678, 553);
			this.MetaDataDetail.TabIndex = 1;
			// 
			// tabPrincipale
			// 
			this.tabPrincipale.Controls.Add(this.checkBox1);
			this.tabPrincipale.Controls.Add(this.label15);
			this.tabPrincipale.Controls.Add(this.textBox6);
			this.tabPrincipale.Controls.Add(this.label14);
			this.tabPrincipale.Controls.Add(this.label13);
			this.tabPrincipale.Controls.Add(this.textBox5);
			this.tabPrincipale.Controls.Add(this.textBox4);
			this.tabPrincipale.Controls.Add(this.btnSituazioneAnnuale);
			this.tabPrincipale.Controls.Add(this.btnSituazionePluriennale);
			this.tabPrincipale.Controls.Add(this.gboxResponsabile);
			this.tabPrincipale.Controls.Add(this.gboxUnderwriting);
			this.tabPrincipale.Controls.Add(this.cmbIstitutoCassiere);
			this.tabPrincipale.Controls.Add(this.btnIstitutoCassiere);
			this.tabPrincipale.Controls.Add(this.txtCodiceConsolidamento);
			this.tabPrincipale.Controls.Add(this.label12);
			this.tabPrincipale.Controls.Add(this.Funzione);
			this.tabPrincipale.Controls.Add(this.grpAttivita);
			this.tabPrincipale.Controls.Add(this.textBox2);
			this.tabPrincipale.Controls.Add(this.textBox1);
			this.tabPrincipale.Controls.Add(this.label4);
			this.tabPrincipale.Controls.Add(this.btnBilPrevisione);
			this.tabPrincipale.Controls.Add(this.chbUpbAttivo);
			this.tabPrincipale.Controls.Add(this.groupBox1);
			this.tabPrincipale.Controls.Add(this.chbFinCerto);
			this.tabPrincipale.Controls.Add(this.textBox3);
			this.tabPrincipale.Controls.Add(this.label3);
			this.tabPrincipale.Controls.Add(this.txtScadenza);
			this.tabPrincipale.Controls.Add(this.lblScadenza);
			this.tabPrincipale.Controls.Add(this.txtOrdineStampa);
			this.tabPrincipale.Controls.Add(this.lblOrdineStampa);
			this.tabPrincipale.Controls.Add(this.txtDenominazione);
			this.tabPrincipale.Controls.Add(this.lblDenominazione);
			this.tabPrincipale.Controls.Add(this.txtCodice);
			this.tabPrincipale.Controls.Add(this.lblCodice);
			this.tabPrincipale.Controls.Add(this.label5);
			this.tabPrincipale.Controls.Add(this.label16);
			this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
			this.tabPrincipale.Name = "tabPrincipale";
			this.tabPrincipale.Size = new System.Drawing.Size(670, 526);
			this.tabPrincipale.TabIndex = 0;
			this.tabPrincipale.Text = "Principale";
			this.tabPrincipale.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(12, 484);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(249, 17);
			this.checkBox1.TabIndex = 20;
			this.checkBox1.Tag = "upb.flagkind:2";
			this.checkBox1.Text = "Usa contabilit‡ speciale negli impegni di budget";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(452, 313);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(0, 13);
			this.label15.TabIndex = 53;
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(429, 329);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(124, 20);
			this.textBox6.TabIndex = 12;
			this.textBox6.Tag = "upb.cigcode";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(426, 427);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(50, 13);
			this.label14.TabIndex = 51;
			this.label14.Text = "Data fine";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(426, 381);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(56, 13);
			this.label13.TabIndex = 50;
			this.label13.Text = "Data inizio";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(429, 446);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(104, 20);
			this.textBox5.TabIndex = 17;
			this.textBox5.Tag = "upb.stop";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(429, 399);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(104, 20);
			this.textBox4.TabIndex = 16;
			this.textBox4.Tag = "upb.start";
			// 
			// btnSituazioneAnnuale
			// 
			this.btnSituazioneAnnuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSituazioneAnnuale.Location = new System.Drawing.Point(458, 9);
			this.btnSituazioneAnnuale.Name = "btnSituazioneAnnuale";
			this.btnSituazioneAnnuale.Size = new System.Drawing.Size(128, 23);
			this.btnSituazioneAnnuale.TabIndex = 34;
			this.btnSituazioneAnnuale.TabStop = false;
			this.btnSituazioneAnnuale.Text = "Situazione Annuale";
			this.btnSituazioneAnnuale.Click += new System.EventHandler(this.btnSituazioneAnnuale_Click);
			// 
			// btnSituazionePluriennale
			// 
			this.btnSituazionePluriennale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSituazionePluriennale.Location = new System.Drawing.Point(434, 37);
			this.btnSituazionePluriennale.Name = "btnSituazionePluriennale";
			this.btnSituazionePluriennale.Size = new System.Drawing.Size(152, 23);
			this.btnSituazionePluriennale.TabIndex = 35;
			this.btnSituazionePluriennale.TabStop = false;
			this.btnSituazionePluriennale.Text = "Situazione Pluriennale";
			this.btnSituazionePluriennale.Click += new System.EventHandler(this.btnSituazionePluriennale_Click);
			// 
			// gboxResponsabile
			// 
			this.gboxResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gboxResponsabile.Controls.Add(this.txtResponsabile);
			this.gboxResponsabile.Controls.Add(this.btnResponsabile);
			this.gboxResponsabile.Location = new System.Drawing.Point(8, 137);
			this.gboxResponsabile.Name = "gboxResponsabile";
			this.gboxResponsabile.Size = new System.Drawing.Size(654, 40);
			this.gboxResponsabile.TabIndex = 5;
			this.gboxResponsabile.TabStop = false;
			this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
			// 
			// txtResponsabile
			// 
			this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtResponsabile.Location = new System.Drawing.Point(114, 14);
			this.txtResponsabile.Name = "txtResponsabile";
			this.txtResponsabile.Size = new System.Drawing.Size(534, 20);
			this.txtResponsabile.TabIndex = 0;
			this.txtResponsabile.Tag = "manager.title?x";
			// 
			// btnResponsabile
			// 
			this.btnResponsabile.Location = new System.Drawing.Point(7, 12);
			this.btnResponsabile.Name = "btnResponsabile";
			this.btnResponsabile.Size = new System.Drawing.Size(104, 23);
			this.btnResponsabile.TabIndex = 25;
			this.btnResponsabile.TabStop = false;
			this.btnResponsabile.Tag = "choose.manager.default";
			this.btnResponsabile.Text = "Responsabile";
			// 
			// gboxUnderwriting
			// 
			this.gboxUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUnderwriting.Controls.Add(this.txtUnderwriting);
			this.gboxUnderwriting.Controls.Add(this.btnEnteFin);
			this.gboxUnderwriting.Location = new System.Drawing.Point(8, 183);
			this.gboxUnderwriting.Name = "gboxUnderwriting";
			this.gboxUnderwriting.Size = new System.Drawing.Size(654, 44);
			this.gboxUnderwriting.TabIndex = 6;
			this.gboxUnderwriting.TabStop = false;
			this.gboxUnderwriting.Tag = "AutoChoose.txtUnderwriting.default";
			// 
			// txtUnderwriting
			// 
			this.txtUnderwriting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUnderwriting.Location = new System.Drawing.Point(114, 18);
			this.txtUnderwriting.Name = "txtUnderwriting";
			this.txtUnderwriting.Size = new System.Drawing.Size(534, 20);
			this.txtUnderwriting.TabIndex = 0;
			this.txtUnderwriting.Tag = "underwriter.description?x";
			// 
			// btnEnteFin
			// 
			this.btnEnteFin.Location = new System.Drawing.Point(7, 15);
			this.btnEnteFin.Name = "btnEnteFin";
			this.btnEnteFin.Size = new System.Drawing.Size(104, 23);
			this.btnEnteFin.TabIndex = 23;
			this.btnEnteFin.TabStop = false;
			this.btnEnteFin.Tag = "manage.underwriter.lista";
			this.btnEnteFin.Text = "Ente Finanziatore";
			// 
			// cmbIstitutoCassiere
			// 
			this.cmbIstitutoCassiere.DataSource = this.DS.treasurer;
			this.cmbIstitutoCassiere.DisplayMember = "description";
			this.cmbIstitutoCassiere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIstitutoCassiere.Location = new System.Drawing.Point(122, 233);
			this.cmbIstitutoCassiere.Name = "cmbIstitutoCassiere";
			this.cmbIstitutoCassiere.Size = new System.Drawing.Size(457, 21);
			this.cmbIstitutoCassiere.TabIndex = 7;
			this.cmbIstitutoCassiere.Tag = "upb.idtreasurer";
			this.cmbIstitutoCassiere.ValueMember = "idtreasurer";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnIstitutoCassiere
			// 
			this.btnIstitutoCassiere.Location = new System.Drawing.Point(15, 233);
			this.btnIstitutoCassiere.Name = "btnIstitutoCassiere";
			this.btnIstitutoCassiere.Size = new System.Drawing.Size(104, 23);
			this.btnIstitutoCassiere.TabIndex = 47;
			this.btnIstitutoCassiere.TabStop = false;
			this.btnIstitutoCassiere.Tag = "choose.treasurer.lista";
			this.btnIstitutoCassiere.Text = "Cassiere";
			// 
			// txtCodiceConsolidamento
			// 
			this.txtCodiceConsolidamento.Location = new System.Drawing.Point(12, 448);
			this.txtCodiceConsolidamento.Name = "txtCodiceConsolidamento";
			this.txtCodiceConsolidamento.Size = new System.Drawing.Size(165, 20);
			this.txtCodiceConsolidamento.TabIndex = 18;
			this.txtCodiceConsolidamento.Tag = "upb.newcodeupb";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(12, 431);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 17);
			this.label12.TabIndex = 45;
			this.label12.Text = "Codice di Consolidamento:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Funzione
			// 
			this.Funzione.Controls.Add(this.chkRicerca);
			this.Funzione.Controls.Add(this.chkDidattica);
			this.Funzione.Location = new System.Drawing.Point(244, 440);
			this.Funzione.Name = "Funzione";
			this.Funzione.Size = new System.Drawing.Size(176, 37);
			this.Funzione.TabIndex = 19;
			this.Funzione.TabStop = false;
			this.Funzione.Text = "Funzione";
			// 
			// chkRicerca
			// 
			this.chkRicerca.AutoSize = true;
			this.chkRicerca.Location = new System.Drawing.Point(96, 14);
			this.chkRicerca.Name = "chkRicerca";
			this.chkRicerca.Size = new System.Drawing.Size(63, 17);
			this.chkRicerca.TabIndex = 1;
			this.chkRicerca.Tag = "upb.flagkind:1";
			this.chkRicerca.Text = "Ricerca";
			this.chkRicerca.UseVisualStyleBackColor = true;
			// 
			// chkDidattica
			// 
			this.chkDidattica.AutoSize = true;
			this.chkDidattica.Location = new System.Drawing.Point(6, 14);
			this.chkDidattica.Name = "chkDidattica";
			this.chkDidattica.Size = new System.Drawing.Size(68, 17);
			this.chkDidattica.TabIndex = 0;
			this.chkDidattica.Tag = "upb.flagkind:0";
			this.chkDidattica.Text = "Didattica";
			this.chkDidattica.UseVisualStyleBackColor = true;
			// 
			// grpAttivita
			// 
			this.grpAttivita.Controls.Add(this.radCommerciale);
			this.grpAttivita.Controls.Add(this.radioButton1);
			this.grpAttivita.Controls.Add(this.radioButton2);
			this.grpAttivita.Location = new System.Drawing.Point(244, 369);
			this.grpAttivita.Name = "grpAttivita";
			this.grpAttivita.Size = new System.Drawing.Size(176, 69);
			this.grpAttivita.TabIndex = 15;
			this.grpAttivita.TabStop = false;
			this.grpAttivita.Text = "Attivit‡";
			// 
			// radCommerciale
			// 
			this.radCommerciale.Location = new System.Drawing.Point(7, 49);
			this.radCommerciale.Name = "radCommerciale";
			this.radCommerciale.Size = new System.Drawing.Size(96, 16);
			this.radCommerciale.TabIndex = 3;
			this.radCommerciale.Tag = "upb.flagactivity:2";
			this.radCommerciale.Text = "Commerciale";
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(8, 13);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(160, 16);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.Tag = "upb.flagactivity:4";
			this.radioButton1.Text = "Qualsiasi/Non specificata";
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(8, 31);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(96, 16);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Tag = "upb.flagactivity:1";
			this.radioButton2.Text = "Istituzionale";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(429, 281);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(136, 20);
			this.textBox2.TabIndex = 11;
			this.textBox2.Tag = "upb.cupcode";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(161, 344);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 10;
			this.textBox1.Tag = "upb.previousassessment";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(27, 340);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 23);
			this.label4.TabIndex = 39;
			this.label4.Tag = "";
			this.label4.Text = "Tot Accertato Pregresso";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnBilPrevisione
			// 
			this.btnBilPrevisione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBilPrevisione.Location = new System.Drawing.Point(281, 8);
			this.btnBilPrevisione.Name = "btnBilPrevisione";
			this.btnBilPrevisione.Size = new System.Drawing.Size(147, 23);
			this.btnBilPrevisione.TabIndex = 36;
			this.btnBilPrevisione.TabStop = false;
			this.btnBilPrevisione.Text = "Bilancio dell\'UPB";
			this.btnBilPrevisione.Click += new System.EventHandler(this.btnBilPrevisione_Click);
			// 
			// chbUpbAttivo
			// 
			this.chbUpbAttivo.Location = new System.Drawing.Point(14, 413);
			this.chbUpbAttivo.Name = "chbUpbAttivo";
			this.chbUpbAttivo.Size = new System.Drawing.Size(120, 15);
			this.chbUpbAttivo.TabIndex = 14;
			this.chbUpbAttivo.Tag = "upb.active:S:N";
			this.chbUpbAttivo.Text = "U.P.B. Attivo";
			this.chbUpbAttivo.Click += new System.EventHandler(this.chbUpbAttivo_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtFinRichiesto);
			this.groupBox1.Controls.Add(this.txtFinConcesso);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(14, 263);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(406, 44);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Finanziamento";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 26;
			this.label1.Text = "Richiesto";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFinRichiesto
			// 
			this.txtFinRichiesto.Location = new System.Drawing.Point(69, 19);
			this.txtFinRichiesto.Name = "txtFinRichiesto";
			this.txtFinRichiesto.Size = new System.Drawing.Size(112, 20);
			this.txtFinRichiesto.TabIndex = 1;
			this.txtFinRichiesto.Tag = "upb.requested";
			// 
			// txtFinConcesso
			// 
			this.txtFinConcesso.Location = new System.Drawing.Point(255, 19);
			this.txtFinConcesso.Name = "txtFinConcesso";
			this.txtFinConcesso.Size = new System.Drawing.Size(112, 20);
			this.txtFinConcesso.TabIndex = 2;
			this.txtFinConcesso.Tag = "upb.granted";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(183, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 27;
			this.label2.Text = "Concesso";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chbFinCerto
			// 
			this.chbFinCerto.Location = new System.Drawing.Point(14, 370);
			this.chbFinCerto.Name = "chbFinCerto";
			this.chbFinCerto.Size = new System.Drawing.Size(224, 37);
			this.chbFinCerto.TabIndex = 13;
			this.chbFinCerto.Tag = "upb.assured:S:N";
			this.chbFinCerto.Text = "Finanziamento certo (Non gestire assegnazione crediti/incassi)";
			this.chbFinCerto.UseCompatibleTextRendering = true;
			this.chbFinCerto.Click += new System.EventHandler(this.chbFinCerto_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(161, 320);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 9;
			this.textBox3.Tag = "upb.previousappropriation";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 319);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 21);
			this.label3.TabIndex = 28;
			this.label3.Tag = "";
			this.label3.Text = "Tot Impegnato Pregresso";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtScadenza
			// 
			this.txtScadenza.Location = new System.Drawing.Point(332, 40);
			this.txtScadenza.Name = "txtScadenza";
			this.txtScadenza.Size = new System.Drawing.Size(96, 20);
			this.txtScadenza.TabIndex = 3;
			this.txtScadenza.Tag = "upb.expiration";
			// 
			// lblScadenza
			// 
			this.lblScadenza.Location = new System.Drawing.Point(266, 42);
			this.lblScadenza.Name = "lblScadenza";
			this.lblScadenza.Size = new System.Drawing.Size(64, 15);
			this.lblScadenza.TabIndex = 22;
			this.lblScadenza.Text = "Scadenza:";
			this.lblScadenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtOrdineStampa
			// 
			this.txtOrdineStampa.Location = new System.Drawing.Point(96, 40);
			this.txtOrdineStampa.Name = "txtOrdineStampa";
			this.txtOrdineStampa.Size = new System.Drawing.Size(160, 20);
			this.txtOrdineStampa.TabIndex = 2;
			this.txtOrdineStampa.Tag = "upb.printingorder";
			// 
			// lblOrdineStampa
			// 
			this.lblOrdineStampa.Location = new System.Drawing.Point(8, 40);
			this.lblOrdineStampa.Name = "lblOrdineStampa";
			this.lblOrdineStampa.Size = new System.Drawing.Size(88, 24);
			this.lblOrdineStampa.TabIndex = 20;
			this.lblOrdineStampa.Text = "Ordine stampa:";
			this.lblOrdineStampa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenominazione.Location = new System.Drawing.Point(8, 91);
			this.txtDenominazione.Multiline = true;
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(654, 40);
			this.txtDenominazione.TabIndex = 4;
			this.txtDenominazione.Tag = "upb.title?upbyearview.upb";
			// 
			// lblDenominazione
			// 
			this.lblDenominazione.Location = new System.Drawing.Point(3, 64);
			this.lblDenominazione.Name = "lblDenominazione";
			this.lblDenominazione.Size = new System.Drawing.Size(88, 24);
			this.lblDenominazione.TabIndex = 18;
			this.lblDenominazione.Text = "Denominazione:";
			this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(96, 8);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(160, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "upb.codeupb";
			// 
			// lblCodice
			// 
			this.lblCodice.Location = new System.Drawing.Point(32, 8);
			this.lblCodice.Name = "lblCodice";
			this.lblCodice.Size = new System.Drawing.Size(56, 24);
			this.lblCodice.TabIndex = 15;
			this.lblCodice.Text = "Codice:";
			this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(426, 257);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(160, 23);
			this.label5.TabIndex = 41;
			this.label5.Tag = "";
			this.label5.Text = "Codice Unico di Progetto (CUP)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(426, 305);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(183, 21);
			this.label16.TabIndex = 54;
			this.label16.Tag = "";
			this.label16.Text = "Codice Identificativo di Gara (CIG)";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPrevisione
			// 
			this.tabPrevisione.Controls.Add(this.groupBox5);
			this.tabPrevisione.Controls.Add(this.dgPrevisione);
			this.tabPrevisione.Controls.Add(this.btnInsPrevisione);
			this.tabPrevisione.Controls.Add(this.btnEditPrevisione);
			this.tabPrevisione.Controls.Add(this.btnDelPrevisione);
			this.tabPrevisione.Location = new System.Drawing.Point(4, 42);
			this.tabPrevisione.Name = "tabPrevisione";
			this.tabPrevisione.Size = new System.Drawing.Size(619, 507);
			this.tabPrevisione.TabIndex = 4;
			this.tabPrevisione.Text = "Previsione";
			this.tabPrevisione.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.dgVariazioni);
			this.groupBox5.Location = new System.Drawing.Point(10, 269);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(606, 227);
			this.groupBox5.TabIndex = 24;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Variazioni Bilancio";
			// 
			// dgVariazioni
			// 
			this.dgVariazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgVariazioni.DataMember = "";
			this.dgVariazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgVariazioni.Location = new System.Drawing.Point(6, 28);
			this.dgVariazioni.Name = "dgVariazioni";
			this.dgVariazioni.Size = new System.Drawing.Size(593, 193);
			this.dgVariazioni.TabIndex = 24;
			this.dgVariazioni.Tag = "finvardetailview.upb";
			// 
			// dgPrevisione
			// 
			this.dgPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgPrevisione.DataMember = "";
			this.dgPrevisione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPrevisione.Location = new System.Drawing.Point(97, 8);
			this.dgPrevisione.Name = "dgPrevisione";
			this.dgPrevisione.Size = new System.Drawing.Size(514, 255);
			this.dgPrevisione.TabIndex = 22;
			this.dgPrevisione.Tag = "finyearview.previsionfin.previsionfin";
			// 
			// btnInsPrevisione
			// 
			this.btnInsPrevisione.Location = new System.Drawing.Point(5, 8);
			this.btnInsPrevisione.Name = "btnInsPrevisione";
			this.btnInsPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnInsPrevisione.TabIndex = 19;
			this.btnInsPrevisione.Tag = "insert.previsionfin";
			this.btnInsPrevisione.Text = "Inserisci";
			// 
			// btnEditPrevisione
			// 
			this.btnEditPrevisione.Location = new System.Drawing.Point(5, 40);
			this.btnEditPrevisione.Name = "btnEditPrevisione";
			this.btnEditPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnEditPrevisione.TabIndex = 20;
			this.btnEditPrevisione.Tag = "edit.previsionfin";
			this.btnEditPrevisione.Text = "Modifica";
			// 
			// btnDelPrevisione
			// 
			this.btnDelPrevisione.Location = new System.Drawing.Point(5, 72);
			this.btnDelPrevisione.Name = "btnDelPrevisione";
			this.btnDelPrevisione.Size = new System.Drawing.Size(86, 26);
			this.btnDelPrevisione.TabIndex = 21;
			this.btnDelPrevisione.Tag = "delete";
			this.btnDelPrevisione.Text = "Elimina";
			// 
			// tabBudget
			// 
			this.tabBudget.Controls.Add(this.btnSituazioneBudget);
			this.tabBudget.Controls.Add(this.btnSitBudgetAnnuale);
			this.tabBudget.Controls.Add(this.btnBudgetUPB);
			this.tabBudget.Controls.Add(this.groupBox2);
			this.tabBudget.Controls.Add(this.dgBudget);
			this.tabBudget.Controls.Add(this.button1);
			this.tabBudget.Controls.Add(this.button2);
			this.tabBudget.Controls.Add(this.button3);
			this.tabBudget.Location = new System.Drawing.Point(4, 42);
			this.tabBudget.Name = "tabBudget";
			this.tabBudget.Size = new System.Drawing.Size(619, 507);
			this.tabBudget.TabIndex = 7;
			this.tabBudget.Text = "Budget";
			this.tabBudget.UseVisualStyleBackColor = true;
			// 
			// btnSituazioneBudget
			// 
			this.btnSituazioneBudget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSituazioneBudget.Location = new System.Drawing.Point(379, 9);
			this.btnSituazioneBudget.Name = "btnSituazioneBudget";
			this.btnSituazioneBudget.Size = new System.Drawing.Size(172, 23);
			this.btnSituazioneBudget.TabIndex = 39;
			this.btnSituazioneBudget.TabStop = false;
			this.btnSituazioneBudget.Text = "Situazione Pluriennale";
			this.btnSituazioneBudget.Click += new System.EventHandler(this.btnSituazioneBudget_Click);
			// 
			// btnSitBudgetAnnuale
			// 
			this.btnSitBudgetAnnuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSitBudgetAnnuale.Location = new System.Drawing.Point(221, 9);
			this.btnSitBudgetAnnuale.Name = "btnSitBudgetAnnuale";
			this.btnSitBudgetAnnuale.Size = new System.Drawing.Size(128, 23);
			this.btnSitBudgetAnnuale.TabIndex = 38;
			this.btnSitBudgetAnnuale.TabStop = false;
			this.btnSitBudgetAnnuale.Text = "Situazione Annuale";
			this.btnSitBudgetAnnuale.Click += new System.EventHandler(this.btnSitBudgetAnnuale_Click);
			// 
			// btnBudgetUPB
			// 
			this.btnBudgetUPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBudgetUPB.Location = new System.Drawing.Point(37, 9);
			this.btnBudgetUPB.Name = "btnBudgetUPB";
			this.btnBudgetUPB.Size = new System.Drawing.Size(147, 23);
			this.btnBudgetUPB.TabIndex = 37;
			this.btnBudgetUPB.TabStop = false;
			this.btnBudgetUPB.Text = "Budget dell\'UPB";
			this.btnBudgetUPB.Click += new System.EventHandler(this.btnBudgetUPB_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgBudgetVar);
			this.groupBox2.Location = new System.Drawing.Point(9, 269);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(605, 227);
			this.groupBox2.TabIndex = 29;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Variazioni Budget";
			// 
			// dgBudgetVar
			// 
			this.dgBudgetVar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgBudgetVar.DataMember = "";
			this.dgBudgetVar.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgBudgetVar.Location = new System.Drawing.Point(6, 28);
			this.dgBudgetVar.Name = "dgBudgetVar";
			this.dgBudgetVar.Size = new System.Drawing.Size(593, 193);
			this.dgBudgetVar.TabIndex = 24;
			this.dgBudgetVar.Tag = "accountvardetailview.upb";
			// 
			// dgBudget
			// 
			this.dgBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgBudget.DataMember = "";
			this.dgBudget.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgBudget.Location = new System.Drawing.Point(96, 38);
			this.dgBudget.Name = "dgBudget";
			this.dgBudget.Size = new System.Drawing.Size(513, 225);
			this.dgBudget.TabIndex = 28;
			this.dgBudget.Tag = "accountyearview.previsionaccount.previsionaccount";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(5, 38);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(86, 26);
			this.button1.TabIndex = 25;
			this.button1.Tag = "insert.previsionaccount";
			this.button1.Text = "Inserisci";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(5, 70);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(86, 26);
			this.button2.TabIndex = 26;
			this.button2.Tag = "edit.previsionaccount";
			this.button2.Text = "Modifica";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(5, 102);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(86, 26);
			this.button3.TabIndex = 27;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			// 
			// tabClassificazione
			// 
			this.tabClassificazione.Controls.Add(this.dGridClassSup);
			this.tabClassificazione.Controls.Add(this.btnElimina);
			this.tabClassificazione.Controls.Add(this.btnModifica);
			this.tabClassificazione.Controls.Add(this.btnInserisci);
			this.tabClassificazione.ImageIndex = 0;
			this.tabClassificazione.Location = new System.Drawing.Point(4, 42);
			this.tabClassificazione.Name = "tabClassificazione";
			this.tabClassificazione.Size = new System.Drawing.Size(619, 507);
			this.tabClassificazione.TabIndex = 1;
			this.tabClassificazione.Text = "Class.";
			this.tabClassificazione.UseVisualStyleBackColor = true;
			// 
			// dGridClassSup
			// 
			this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassSup.DataMember = "";
			this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassSup.Location = new System.Drawing.Point(88, 9);
			this.dGridClassSup.Name = "dGridClassSup";
			this.dGridClassSup.Size = new System.Drawing.Size(523, 485);
			this.dGridClassSup.TabIndex = 17;
			this.dGridClassSup.Tag = "upbsorting.default.default";
			// 
			// btnElimina
			// 
			this.btnElimina.Location = new System.Drawing.Point(8, 72);
			this.btnElimina.Name = "btnElimina";
			this.btnElimina.Size = new System.Drawing.Size(72, 24);
			this.btnElimina.TabIndex = 16;
			this.btnElimina.Tag = "delete";
			this.btnElimina.Text = "Elimina";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(8, 40);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(72, 24);
			this.btnModifica.TabIndex = 15;
			this.btnModifica.Tag = "edit.single";
			this.btnModifica.Text = "Modifica";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(8, 8);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(72, 24);
			this.btnInserisci.TabIndex = 14;
			this.btnInserisci.Tag = "insert.single";
			this.btnInserisci.Text = "Inserisci";
			// 
			// tabAttributi
			// 
			this.tabAttributi.BackColor = System.Drawing.Color.Transparent;
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 42);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(619, 507);
			this.tabAttributi.TabIndex = 2;
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
			this.gboxclass05.Location = new System.Drawing.Point(5, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(611, 64);
			this.gboxclass05.TabIndex = 18;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 38);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(254, 20);
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
			this.txtDenom05.Location = new System.Drawing.Point(267, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(336, 52);
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
			this.gboxclass04.Location = new System.Drawing.Point(5, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(611, 64);
			this.gboxclass04.TabIndex = 17;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(9, 38);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(254, 20);
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
			this.txtDenom04.Location = new System.Drawing.Point(267, 8);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(336, 52);
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
			this.gboxclass03.Size = new System.Drawing.Size(611, 64);
			this.gboxclass03.TabIndex = 15;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// txtCodice03
			// 
			this.txtCodice03.Location = new System.Drawing.Point(8, 38);
			this.txtCodice03.Name = "txtCodice03";
			this.txtCodice03.Size = new System.Drawing.Size(254, 20);
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
			this.txtDenom03.Location = new System.Drawing.Point(267, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(336, 52);
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
			this.gboxclass02.Size = new System.Drawing.Size(610, 64);
			this.gboxclass02.TabIndex = 16;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// txtCodice02
			// 
			this.txtCodice02.Location = new System.Drawing.Point(8, 38);
			this.txtCodice02.Name = "txtCodice02";
			this.txtCodice02.Size = new System.Drawing.Size(254, 20);
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
			this.txtDenom02.Location = new System.Drawing.Point(267, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(335, 52);
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
			this.gboxclass01.Size = new System.Drawing.Size(610, 64);
			this.gboxclass01.TabIndex = 14;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// txtCodice01
			// 
			this.txtCodice01.Location = new System.Drawing.Point(7, 40);
			this.txtCodice01.Name = "txtCodice01";
			this.txtCodice01.Size = new System.Drawing.Size(254, 20);
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
			this.txtDenom01.Location = new System.Drawing.Point(267, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(335, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabClassAutoSpese
			// 
			this.tabClassAutoSpese.BackColor = System.Drawing.Color.Transparent;
			this.tabClassAutoSpese.Controls.Add(this.groupBox4);
			this.tabClassAutoSpese.Controls.Add(this.groupBox3);
			this.tabClassAutoSpese.Location = new System.Drawing.Point(4, 42);
			this.tabClassAutoSpese.Name = "tabClassAutoSpese";
			this.tabClassAutoSpese.Padding = new System.Windows.Forms.Padding(3);
			this.tabClassAutoSpese.Size = new System.Drawing.Size(619, 507);
			this.tabClassAutoSpese.TabIndex = 3;
			this.tabClassAutoSpese.Text = "Class. Autom. S.";
			this.tabClassAutoSpese.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.dGridFilterClassExp);
			this.groupBox4.Controls.Add(this.btnEliminaFilterS);
			this.groupBox4.Controls.Add(this.btnModificaFilterS);
			this.groupBox4.Controls.Add(this.btnInserisciFilterS);
			this.groupBox4.Location = new System.Drawing.Point(8, 240);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(605, 261);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Filtri Classificazione Automatica delle Spese";
			// 
			// dGridFilterClassExp
			// 
			this.dGridFilterClassExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dGridFilterClassExp.DataMember = "";
			this.dGridFilterClassExp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFilterClassExp.Location = new System.Drawing.Point(84, 19);
			this.dGridFilterClassExp.Name = "dGridFilterClassExp";
			this.dGridFilterClassExp.Size = new System.Drawing.Size(518, 236);
			this.dGridFilterClassExp.TabIndex = 24;
			this.dGridFilterClassExp.Tag = "sortingexpensefilter.upb.single";
			// 
			// btnEliminaFilterS
			// 
			this.btnEliminaFilterS.Location = new System.Drawing.Point(6, 83);
			this.btnEliminaFilterS.Name = "btnEliminaFilterS";
			this.btnEliminaFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaFilterS.TabIndex = 23;
			this.btnEliminaFilterS.Tag = "delete";
			this.btnEliminaFilterS.Text = "Elimina";
			// 
			// btnModificaFilterS
			// 
			this.btnModificaFilterS.Location = new System.Drawing.Point(6, 51);
			this.btnModificaFilterS.Name = "btnModificaFilterS";
			this.btnModificaFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnModificaFilterS.TabIndex = 22;
			this.btnModificaFilterS.Tag = "edit.single";
			this.btnModificaFilterS.Text = "Modifica";
			// 
			// btnInserisciFilterS
			// 
			this.btnInserisciFilterS.Location = new System.Drawing.Point(6, 19);
			this.btnInserisciFilterS.Name = "btnInserisciFilterS";
			this.btnInserisciFilterS.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciFilterS.TabIndex = 21;
			this.btnInserisciFilterS.Tag = "insert.single";
			this.btnInserisciFilterS.Text = "Inserisci";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.dGridClassAutoExp);
			this.groupBox3.Controls.Add(this.btnEliminaClassS);
			this.groupBox3.Controls.Add(this.btnModificaClassS);
			this.groupBox3.Controls.Add(this.btnInserisciClassS);
			this.groupBox3.Location = new System.Drawing.Point(6, 9);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(605, 221);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Configurazione Classificazione Automatica delle Spese";
			// 
			// dGridClassAutoExp
			// 
			this.dGridClassAutoExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassAutoExp.DataMember = "";
			this.dGridClassAutoExp.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassAutoExp.Location = new System.Drawing.Point(81, 19);
			this.dGridClassAutoExp.Name = "dGridClassAutoExp";
			this.dGridClassAutoExp.Size = new System.Drawing.Size(517, 196);
			this.dGridClassAutoExp.TabIndex = 21;
			this.dGridClassAutoExp.Tag = "autoexpensesorting.upb.single";
			// 
			// btnEliminaClassS
			// 
			this.btnEliminaClassS.Location = new System.Drawing.Point(4, 81);
			this.btnEliminaClassS.Name = "btnEliminaClassS";
			this.btnEliminaClassS.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaClassS.TabIndex = 20;
			this.btnEliminaClassS.Tag = "delete";
			this.btnEliminaClassS.Text = "Elimina";
			// 
			// btnModificaClassS
			// 
			this.btnModificaClassS.Location = new System.Drawing.Point(4, 49);
			this.btnModificaClassS.Name = "btnModificaClassS";
			this.btnModificaClassS.Size = new System.Drawing.Size(72, 24);
			this.btnModificaClassS.TabIndex = 19;
			this.btnModificaClassS.Tag = "edit.single";
			this.btnModificaClassS.Text = "Modifica";
			// 
			// btnInserisciClassS
			// 
			this.btnInserisciClassS.Location = new System.Drawing.Point(4, 17);
			this.btnInserisciClassS.Name = "btnInserisciClassS";
			this.btnInserisciClassS.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciClassS.TabIndex = 18;
			this.btnInserisciClassS.Tag = "insert.single";
			this.btnInserisciClassS.Text = "Inserisci";
			// 
			// tabClassAutoEntrate
			// 
			this.tabClassAutoEntrate.Controls.Add(this.groupBox6);
			this.tabClassAutoEntrate.Controls.Add(this.groupBox7);
			this.tabClassAutoEntrate.Location = new System.Drawing.Point(4, 42);
			this.tabClassAutoEntrate.Name = "tabClassAutoEntrate";
			this.tabClassAutoEntrate.Size = new System.Drawing.Size(619, 507);
			this.tabClassAutoEntrate.TabIndex = 6;
			this.tabClassAutoEntrate.Text = "Class. Autom. E.";
			this.tabClassAutoEntrate.UseVisualStyleBackColor = true;
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.dGridFilterClassInc);
			this.groupBox6.Controls.Add(this.btnEliminaFilterE);
			this.groupBox6.Controls.Add(this.btnModificaFilterE);
			this.groupBox6.Controls.Add(this.btnInserisciFilterE);
			this.groupBox6.Location = new System.Drawing.Point(8, 240);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(605, 261);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Filtri Classificazione Automatica delle Entrate";
			// 
			// dGridFilterClassInc
			// 
			this.dGridFilterClassInc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dGridFilterClassInc.DataMember = "";
			this.dGridFilterClassInc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFilterClassInc.Location = new System.Drawing.Point(84, 19);
			this.dGridFilterClassInc.Name = "dGridFilterClassInc";
			this.dGridFilterClassInc.Size = new System.Drawing.Size(518, 236);
			this.dGridFilterClassInc.TabIndex = 24;
			this.dGridFilterClassInc.Tag = "sortingincomefilter.upb.single";
			// 
			// btnEliminaFilterE
			// 
			this.btnEliminaFilterE.Location = new System.Drawing.Point(6, 83);
			this.btnEliminaFilterE.Name = "btnEliminaFilterE";
			this.btnEliminaFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaFilterE.TabIndex = 23;
			this.btnEliminaFilterE.Tag = "delete";
			this.btnEliminaFilterE.Text = "Elimina";
			// 
			// btnModificaFilterE
			// 
			this.btnModificaFilterE.Location = new System.Drawing.Point(6, 51);
			this.btnModificaFilterE.Name = "btnModificaFilterE";
			this.btnModificaFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnModificaFilterE.TabIndex = 22;
			this.btnModificaFilterE.Tag = "edit.single";
			this.btnModificaFilterE.Text = "Modifica";
			// 
			// btnInserisciFilterE
			// 
			this.btnInserisciFilterE.Location = new System.Drawing.Point(6, 19);
			this.btnInserisciFilterE.Name = "btnInserisciFilterE";
			this.btnInserisciFilterE.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciFilterE.TabIndex = 21;
			this.btnInserisciFilterE.Tag = "insert.single";
			this.btnInserisciFilterE.Text = "Inserisci";
			// 
			// groupBox7
			// 
			this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox7.Controls.Add(this.dGridClassAutoInc);
			this.groupBox7.Controls.Add(this.btnEliminaClassE);
			this.groupBox7.Controls.Add(this.btnModificaClassE);
			this.groupBox7.Controls.Add(this.btnInserisciClassE);
			this.groupBox7.Location = new System.Drawing.Point(6, 9);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new System.Drawing.Size(605, 221);
			this.groupBox7.TabIndex = 2;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Configurazione Classificazione Automatica delle Entrate";
			// 
			// dGridClassAutoInc
			// 
			this.dGridClassAutoInc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dGridClassAutoInc.DataMember = "";
			this.dGridClassAutoInc.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridClassAutoInc.Location = new System.Drawing.Point(81, 19);
			this.dGridClassAutoInc.Name = "dGridClassAutoInc";
			this.dGridClassAutoInc.Size = new System.Drawing.Size(517, 196);
			this.dGridClassAutoInc.TabIndex = 21;
			this.dGridClassAutoInc.Tag = "autoincomesorting.upb.single";
			this.dGridClassAutoInc.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dGridClassAutoInc_Navigate);
			// 
			// btnEliminaClassE
			// 
			this.btnEliminaClassE.Location = new System.Drawing.Point(4, 81);
			this.btnEliminaClassE.Name = "btnEliminaClassE";
			this.btnEliminaClassE.Size = new System.Drawing.Size(72, 24);
			this.btnEliminaClassE.TabIndex = 20;
			this.btnEliminaClassE.Tag = "delete";
			this.btnEliminaClassE.Text = "Elimina";
			// 
			// btnModificaClassE
			// 
			this.btnModificaClassE.Location = new System.Drawing.Point(4, 49);
			this.btnModificaClassE.Name = "btnModificaClassE";
			this.btnModificaClassE.Size = new System.Drawing.Size(72, 24);
			this.btnModificaClassE.TabIndex = 19;
			this.btnModificaClassE.Tag = "edit.single";
			this.btnModificaClassE.Text = "Modifica";
			// 
			// btnInserisciClassE
			// 
			this.btnInserisciClassE.Location = new System.Drawing.Point(4, 17);
			this.btnInserisciClassE.Name = "btnInserisciClassE";
			this.btnInserisciClassE.Size = new System.Drawing.Size(72, 24);
			this.btnInserisciClassE.TabIndex = 18;
			this.btnInserisciClassE.Tag = "insert.single";
			this.btnInserisciClassE.Text = "Inserisci";
			// 
			// tabRiepilogo
			// 
			this.tabRiepilogo.Controls.Add(this.grpRiepilogo);
			this.tabRiepilogo.Location = new System.Drawing.Point(4, 42);
			this.tabRiepilogo.Name = "tabRiepilogo";
			this.tabRiepilogo.Padding = new System.Windows.Forms.Padding(3);
			this.tabRiepilogo.Size = new System.Drawing.Size(619, 507);
			this.tabRiepilogo.TabIndex = 5;
			this.tabRiepilogo.Text = "Riepilogo";
			this.tabRiepilogo.UseVisualStyleBackColor = true;
			// 
			// grpRiepilogo
			// 
			this.grpRiepilogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpRiepilogo.Controls.Add(this.chkUpbChilds);
			this.grpRiepilogo.Controls.Add(this.tabCtrl);
			this.grpRiepilogo.Controls.Add(this.btnCalcolaTutto);
			this.grpRiepilogo.Location = new System.Drawing.Point(8, 6);
			this.grpRiepilogo.Name = "grpRiepilogo";
			this.grpRiepilogo.Size = new System.Drawing.Size(605, 492);
			this.grpRiepilogo.TabIndex = 1;
			this.grpRiepilogo.TabStop = false;
			// 
			// chkUpbChilds
			// 
			this.chkUpbChilds.AutoSize = true;
			this.chkUpbChilds.Location = new System.Drawing.Point(10, 19);
			this.chkUpbChilds.Name = "chkUpbChilds";
			this.chkUpbChilds.Size = new System.Drawing.Size(285, 17);
			this.chkUpbChilds.TabIndex = 67;
			this.chkUpbChilds.Text = "Considera anche gli UPB sottostanti nei dati di riepilogo";
			this.chkUpbChilds.UseVisualStyleBackColor = true;
			this.chkUpbChilds.CheckedChanged += new System.EventHandler(this.chkUpbChilds_CheckedChanged);
			// 
			// tabCtrl
			// 
			this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabCtrl.Controls.Add(this.tabPage1);
			this.tabCtrl.Controls.Add(this.tabPage2);
			this.tabCtrl.Controls.Add(this.tabPage3);
			this.tabCtrl.Controls.Add(this.tabBudgetRiep);
			this.tabCtrl.Controls.Add(this.tabPage5);
			this.tabCtrl.Location = new System.Drawing.Point(10, 50);
			this.tabCtrl.Name = "tabCtrl";
			this.tabCtrl.SelectedIndex = 0;
			this.tabCtrl.Size = new System.Drawing.Size(593, 436);
			this.tabCtrl.TabIndex = 61;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.grpPrevCassa_E);
			this.tabPage1.Controls.Add(this.grpPrevCompetenza_E);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(585, 410);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Entrate";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// grpPrevCassa_E
			// 
			this.grpPrevCassa_E.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrevCassa_E.Controls.Add(this.txtPrevDispCassaPerAccertamenti);
			this.grpPrevCassa_E.Controls.Add(this.label64);
			this.grpPrevCassa_E.Controls.Add(this.lblPrevDispCassaAccertamenti);
			this.grpPrevCassa_E.Controls.Add(this.btnAccertamentiAll);
			this.grpPrevCassa_E.Controls.Add(this.lblAccertamentiAll);
			this.grpPrevCassa_E.Controls.Add(this.txtAccertamentiAll);
			this.grpPrevCassa_E.Controls.Add(this.label25);
			this.grpPrevCassa_E.Controls.Add(this.label26);
			this.grpPrevCassa_E.Controls.Add(this.txtPrevAttualeCassaE);
			this.grpPrevCassa_E.Controls.Add(this.label10);
			this.grpPrevCassa_E.Controls.Add(this.btnVarPrevCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.lblVarPrevCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.txtVarPrevCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.lblPrevDispCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.txtPrevDispCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.btnIncassi);
			this.grpPrevCassa_E.Controls.Add(this.lblIncassi);
			this.grpPrevCassa_E.Controls.Add(this.txtIncassi);
			this.grpPrevCassa_E.Controls.Add(this.btnPrevInizialeCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.lblPrevInizialeCassa_E);
			this.grpPrevCassa_E.Controls.Add(this.txtPrevInizialeCassa_E);
			this.grpPrevCassa_E.Location = new System.Drawing.Point(8, 204);
			this.grpPrevCassa_E.Name = "grpPrevCassa_E";
			this.grpPrevCassa_E.Size = new System.Drawing.Size(570, 208);
			this.grpPrevCassa_E.TabIndex = 63;
			this.grpPrevCassa_E.TabStop = false;
			// 
			// txtPrevDispCassaPerAccertamenti
			// 
			this.txtPrevDispCassaPerAccertamenti.Location = new System.Drawing.Point(307, 123);
			this.txtPrevDispCassaPerAccertamenti.Name = "txtPrevDispCassaPerAccertamenti";
			this.txtPrevDispCassaPerAccertamenti.ReadOnly = true;
			this.txtPrevDispCassaPerAccertamenti.Size = new System.Drawing.Size(138, 20);
			this.txtPrevDispCassaPerAccertamenti.TabIndex = 64;
			this.txtPrevDispCassaPerAccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(464, 127);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(66, 13);
			this.label64.TabIndex = 63;
			this.label64.Text = "H = E +F - G";
			// 
			// lblPrevDispCassaAccertamenti
			// 
			this.lblPrevDispCassaAccertamenti.Location = new System.Drawing.Point(47, 123);
			this.lblPrevDispCassaAccertamenti.Name = "lblPrevDispCassaAccertamenti";
			this.lblPrevDispCassaAccertamenti.Size = new System.Drawing.Size(250, 24);
			this.lblPrevDispCassaAccertamenti.TabIndex = 62;
			this.lblPrevDispCassaAccertamenti.Text = "Previsione Disponibile di Cassa per Accertamenti";
			this.lblPrevDispCassaAccertamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnAccertamentiAll
			// 
			this.btnAccertamentiAll.Location = new System.Drawing.Point(455, 97);
			this.btnAccertamentiAll.Name = "btnAccertamentiAll";
			this.btnAccertamentiAll.Size = new System.Drawing.Size(75, 20);
			this.btnAccertamentiAll.TabIndex = 61;
			this.btnAccertamentiAll.Text = "G";
			this.btnAccertamentiAll.UseVisualStyleBackColor = true;
			this.btnAccertamentiAll.Click += new System.EventHandler(this.btnAccertamentiAll_Click);
			// 
			// lblAccertamentiAll
			// 
			this.lblAccertamentiAll.Location = new System.Drawing.Point(99, 98);
			this.lblAccertamentiAll.Name = "lblAccertamentiAll";
			this.lblAccertamentiAll.Size = new System.Drawing.Size(196, 18);
			this.lblAccertamentiAll.TabIndex = 59;
			this.lblAccertamentiAll.Text = "Accertamenti";
			this.lblAccertamentiAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAccertamentiAll
			// 
			this.txtAccertamentiAll.Location = new System.Drawing.Point(307, 96);
			this.txtAccertamentiAll.Name = "txtAccertamentiAll";
			this.txtAccertamentiAll.ReadOnly = true;
			this.txtAccertamentiAll.Size = new System.Drawing.Size(138, 20);
			this.txtAccertamentiAll.TabIndex = 60;
			this.txtAccertamentiAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(458, 69);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(41, 13);
			this.label25.TabIndex = 23;
			this.label25.Text = "= E + F";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(115, 66);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(186, 13);
			this.label26.TabIndex = 21;
			this.label26.Text = "Previsione  attuale di Cassa";
			this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCassaE
			// 
			this.txtPrevAttualeCassaE.Location = new System.Drawing.Point(308, 66);
			this.txtPrevAttualeCassaE.Name = "txtPrevAttualeCassaE";
			this.txtPrevAttualeCassaE.ReadOnly = true;
			this.txtPrevAttualeCassaE.Size = new System.Drawing.Size(137, 20);
			this.txtPrevAttualeCassaE.TabIndex = 22;
			this.txtPrevAttualeCassaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(457, 180);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(62, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "L = E + F - I";
			// 
			// btnVarPrevCassa_E
			// 
			this.btnVarPrevCassa_E.Location = new System.Drawing.Point(455, 35);
			this.btnVarPrevCassa_E.Name = "btnVarPrevCassa_E";
			this.btnVarPrevCassa_E.Size = new System.Drawing.Size(75, 23);
			this.btnVarPrevCassa_E.TabIndex = 3;
			this.btnVarPrevCassa_E.Text = "F";
			this.btnVarPrevCassa_E.UseVisualStyleBackColor = true;
			this.btnVarPrevCassa_E.Click += new System.EventHandler(this.btnVarPrevCassa_E_Click);
			// 
			// lblVarPrevCassa_E
			// 
			this.lblVarPrevCassa_E.Location = new System.Drawing.Point(121, 40);
			this.lblVarPrevCassa_E.Name = "lblVarPrevCassa_E";
			this.lblVarPrevCassa_E.Size = new System.Drawing.Size(180, 13);
			this.lblVarPrevCassa_E.TabIndex = 0;
			this.lblVarPrevCassa_E.Text = "Var. Previsione  di Cassa";
			this.lblVarPrevCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevCassa_E
			// 
			this.txtVarPrevCassa_E.Location = new System.Drawing.Point(308, 35);
			this.txtVarPrevCassa_E.Name = "txtVarPrevCassa_E";
			this.txtVarPrevCassa_E.ReadOnly = true;
			this.txtVarPrevCassa_E.Size = new System.Drawing.Size(137, 20);
			this.txtVarPrevCassa_E.TabIndex = 2;
			this.txtVarPrevCassa_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCassa_E
			// 
			this.lblPrevDispCassa_E.Location = new System.Drawing.Point(6, 179);
			this.lblPrevDispCassa_E.Name = "lblPrevDispCassa_E";
			this.lblPrevDispCassa_E.Size = new System.Drawing.Size(294, 15);
			this.lblPrevDispCassa_E.TabIndex = 0;
			this.lblPrevDispCassa_E.Text = "Previsione Disponibile di Cassa";
			this.lblPrevDispCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevDispCassa_E
			// 
			this.txtPrevDispCassa_E.Location = new System.Drawing.Point(307, 174);
			this.txtPrevDispCassa_E.Name = "txtPrevDispCassa_E";
			this.txtPrevDispCassa_E.ReadOnly = true;
			this.txtPrevDispCassa_E.Size = new System.Drawing.Size(137, 20);
			this.txtPrevDispCassa_E.TabIndex = 8;
			this.txtPrevDispCassa_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnIncassi
			// 
			this.btnIncassi.Location = new System.Drawing.Point(454, 149);
			this.btnIncassi.Name = "btnIncassi";
			this.btnIncassi.Size = new System.Drawing.Size(75, 23);
			this.btnIncassi.TabIndex = 5;
			this.btnIncassi.Text = "I";
			this.btnIncassi.UseVisualStyleBackColor = true;
			this.btnIncassi.Click += new System.EventHandler(this.btnIncassi_Click);
			// 
			// lblIncassi
			// 
			this.lblIncassi.Location = new System.Drawing.Point(106, 153);
			this.lblIncassi.Name = "lblIncassi";
			this.lblIncassi.Size = new System.Drawing.Size(194, 13);
			this.lblIncassi.TabIndex = 0;
			this.lblIncassi.Text = "Incassi";
			this.lblIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIncassi
			// 
			this.txtIncassi.Location = new System.Drawing.Point(307, 148);
			this.txtIncassi.Name = "txtIncassi";
			this.txtIncassi.ReadOnly = true;
			this.txtIncassi.Size = new System.Drawing.Size(137, 20);
			this.txtIncassi.TabIndex = 4;
			this.txtIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCassa_E
			// 
			this.btnPrevInizialeCassa_E.Location = new System.Drawing.Point(455, 9);
			this.btnPrevInizialeCassa_E.Name = "btnPrevInizialeCassa_E";
			this.btnPrevInizialeCassa_E.Size = new System.Drawing.Size(75, 23);
			this.btnPrevInizialeCassa_E.TabIndex = 1;
			this.btnPrevInizialeCassa_E.Text = "E";
			this.btnPrevInizialeCassa_E.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCassa_E.Click += new System.EventHandler(this.btnPrevInizialeCassa_E_Click);
			// 
			// lblPrevInizialeCassa_E
			// 
			this.lblPrevInizialeCassa_E.Location = new System.Drawing.Point(121, 14);
			this.lblPrevInizialeCassa_E.Name = "lblPrevInizialeCassa_E";
			this.lblPrevInizialeCassa_E.Size = new System.Drawing.Size(180, 13);
			this.lblPrevInizialeCassa_E.TabIndex = 0;
			this.lblPrevInizialeCassa_E.Text = "Previsione Iniziale di Cassa";
			this.lblPrevInizialeCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCassa_E
			// 
			this.txtPrevInizialeCassa_E.Location = new System.Drawing.Point(308, 9);
			this.txtPrevInizialeCassa_E.Name = "txtPrevInizialeCassa_E";
			this.txtPrevInizialeCassa_E.ReadOnly = true;
			this.txtPrevInizialeCassa_E.Size = new System.Drawing.Size(137, 20);
			this.txtPrevInizialeCassa_E.TabIndex = 0;
			this.txtPrevInizialeCassa_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpPrevCompetenza_E
			// 
			this.grpPrevCompetenza_E.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrevCompetenza_E.Controls.Add(this.label23);
			this.grpPrevCompetenza_E.Controls.Add(this.label24);
			this.grpPrevCompetenza_E.Controls.Add(this.txtPrevAttualeCompetenzaE);
			this.grpPrevCompetenza_E.Controls.Add(this.btnAccertamentiCompetenza);
			this.grpPrevCompetenza_E.Controls.Add(this.lblAccertamentiCompetenza);
			this.grpPrevCompetenza_E.Controls.Add(this.txtAccertamentiCompetenza);
			this.grpPrevCompetenza_E.Controls.Add(this.label9);
			this.grpPrevCompetenza_E.Controls.Add(this.btnVarPrevCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.lblVarPrevCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.txtVarPrevCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.lblPrevDispCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.txtPrevDispCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.btnPrevInizialeCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.lblPrevInizialeCompetenza_E);
			this.grpPrevCompetenza_E.Controls.Add(this.txtPrevInizialeCompetenza_E);
			this.grpPrevCompetenza_E.Location = new System.Drawing.Point(6, 6);
			this.grpPrevCompetenza_E.Name = "grpPrevCompetenza_E";
			this.grpPrevCompetenza_E.Size = new System.Drawing.Size(571, 182);
			this.grpPrevCompetenza_E.TabIndex = 60;
			this.grpPrevCompetenza_E.TabStop = false;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(449, 83);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(42, 13);
			this.label23.TabIndex = 67;
			this.label23.Text = "= A + B";
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(89, 83);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(198, 13);
			this.label24.TabIndex = 65;
			this.label24.Text = "Previsione  attuale di Competenza";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCompetenzaE
			// 
			this.txtPrevAttualeCompetenzaE.Location = new System.Drawing.Point(308, 80);
			this.txtPrevAttualeCompetenzaE.Name = "txtPrevAttualeCompetenzaE";
			this.txtPrevAttualeCompetenzaE.ReadOnly = true;
			this.txtPrevAttualeCompetenzaE.Size = new System.Drawing.Size(134, 20);
			this.txtPrevAttualeCompetenzaE.TabIndex = 66;
			this.txtPrevAttualeCompetenzaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAccertamentiCompetenza
			// 
			this.btnAccertamentiCompetenza.Location = new System.Drawing.Point(452, 119);
			this.btnAccertamentiCompetenza.Name = "btnAccertamentiCompetenza";
			this.btnAccertamentiCompetenza.Size = new System.Drawing.Size(75, 23);
			this.btnAccertamentiCompetenza.TabIndex = 7;
			this.btnAccertamentiCompetenza.Text = "C";
			this.btnAccertamentiCompetenza.UseVisualStyleBackColor = true;
			this.btnAccertamentiCompetenza.Click += new System.EventHandler(this.btnAccertamentiCompetenza_Click);
			// 
			// lblAccertamentiCompetenza
			// 
			this.lblAccertamentiCompetenza.Location = new System.Drawing.Point(90, 117);
			this.lblAccertamentiCompetenza.Name = "lblAccertamentiCompetenza";
			this.lblAccertamentiCompetenza.Size = new System.Drawing.Size(197, 13);
			this.lblAccertamentiCompetenza.TabIndex = 0;
			this.lblAccertamentiCompetenza.Text = "Accertamenti  di Competenza";
			this.lblAccertamentiCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAccertamentiCompetenza
			// 
			this.txtAccertamentiCompetenza.Location = new System.Drawing.Point(308, 117);
			this.txtAccertamentiCompetenza.Name = "txtAccertamentiCompetenza";
			this.txtAccertamentiCompetenza.ReadOnly = true;
			this.txtAccertamentiCompetenza.Size = new System.Drawing.Size(134, 20);
			this.txtAccertamentiCompetenza.TabIndex = 6;
			this.txtAccertamentiCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(457, 150);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(69, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "D = A + B - C";
			// 
			// btnVarPrevCompetenza_E
			// 
			this.btnVarPrevCompetenza_E.Location = new System.Drawing.Point(452, 45);
			this.btnVarPrevCompetenza_E.Name = "btnVarPrevCompetenza_E";
			this.btnVarPrevCompetenza_E.Size = new System.Drawing.Size(75, 23);
			this.btnVarPrevCompetenza_E.TabIndex = 3;
			this.btnVarPrevCompetenza_E.Text = "B";
			this.btnVarPrevCompetenza_E.UseVisualStyleBackColor = true;
			this.btnVarPrevCompetenza_E.Click += new System.EventHandler(this.btnVarPrevCompetenza_E_Click);
			// 
			// lblVarPrevCompetenza_E
			// 
			this.lblVarPrevCompetenza_E.AutoEllipsis = true;
			this.lblVarPrevCompetenza_E.Location = new System.Drawing.Point(93, 43);
			this.lblVarPrevCompetenza_E.Name = "lblVarPrevCompetenza_E";
			this.lblVarPrevCompetenza_E.Size = new System.Drawing.Size(194, 13);
			this.lblVarPrevCompetenza_E.TabIndex = 0;
			this.lblVarPrevCompetenza_E.Text = "Var. Previsione  di Competenza";
			this.lblVarPrevCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevCompetenza_E
			// 
			this.txtVarPrevCompetenza_E.Location = new System.Drawing.Point(308, 43);
			this.txtVarPrevCompetenza_E.Name = "txtVarPrevCompetenza_E";
			this.txtVarPrevCompetenza_E.ReadOnly = true;
			this.txtVarPrevCompetenza_E.Size = new System.Drawing.Size(134, 20);
			this.txtVarPrevCompetenza_E.TabIndex = 2;
			this.txtVarPrevCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCompetenza_E
			// 
			this.lblPrevDispCompetenza_E.Location = new System.Drawing.Point(90, 142);
			this.lblPrevDispCompetenza_E.Name = "lblPrevDispCompetenza_E";
			this.lblPrevDispCompetenza_E.Size = new System.Drawing.Size(197, 13);
			this.lblPrevDispCompetenza_E.TabIndex = 0;
			this.lblPrevDispCompetenza_E.Text = "Previsione Disponibile di Competenza";
			this.lblPrevDispCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevDispCompetenza_E
			// 
			this.txtPrevDispCompetenza_E.Location = new System.Drawing.Point(308, 142);
			this.txtPrevDispCompetenza_E.Name = "txtPrevDispCompetenza_E";
			this.txtPrevDispCompetenza_E.ReadOnly = true;
			this.txtPrevDispCompetenza_E.Size = new System.Drawing.Size(134, 20);
			this.txtPrevDispCompetenza_E.TabIndex = 8;
			this.txtPrevDispCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCompetenza_E
			// 
			this.btnPrevInizialeCompetenza_E.Location = new System.Drawing.Point(452, 16);
			this.btnPrevInizialeCompetenza_E.Name = "btnPrevInizialeCompetenza_E";
			this.btnPrevInizialeCompetenza_E.Size = new System.Drawing.Size(75, 23);
			this.btnPrevInizialeCompetenza_E.TabIndex = 1;
			this.btnPrevInizialeCompetenza_E.Text = "A";
			this.btnPrevInizialeCompetenza_E.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCompetenza_E.Click += new System.EventHandler(this.btnPrevInizialeCompetenza_E_Click);
			// 
			// lblPrevInizialeCompetenza_E
			// 
			this.lblPrevInizialeCompetenza_E.AutoEllipsis = true;
			this.lblPrevInizialeCompetenza_E.Location = new System.Drawing.Point(96, 17);
			this.lblPrevInizialeCompetenza_E.Name = "lblPrevInizialeCompetenza_E";
			this.lblPrevInizialeCompetenza_E.Size = new System.Drawing.Size(191, 13);
			this.lblPrevInizialeCompetenza_E.TabIndex = 0;
			this.lblPrevInizialeCompetenza_E.Text = "Previsione Iniziale di Competenza";
			this.lblPrevInizialeCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCompetenza_E
			// 
			this.txtPrevInizialeCompetenza_E.Location = new System.Drawing.Point(308, 17);
			this.txtPrevInizialeCompetenza_E.Name = "txtPrevInizialeCompetenza_E";
			this.txtPrevInizialeCompetenza_E.ReadOnly = true;
			this.txtPrevInizialeCompetenza_E.Size = new System.Drawing.Size(134, 20);
			this.txtPrevInizialeCompetenza_E.TabIndex = 0;
			this.txtPrevInizialeCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.grpPrevCompetenza_S);
			this.tabPage2.Controls.Add(this.grpPrevCassa_S);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(585, 410);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Spese";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// grpPrevCompetenza_S
			// 
			this.grpPrevCompetenza_S.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrevCompetenza_S.Controls.Add(this.label27);
			this.grpPrevCompetenza_S.Controls.Add(this.label28);
			this.grpPrevCompetenza_S.Controls.Add(this.txtPrevAttualeCompetenzaS);
			this.grpPrevCompetenza_S.Controls.Add(this.btnPiccoleSpeseImp);
			this.grpPrevCompetenza_S.Controls.Add(this.lblPiccoleSpeseImp);
			this.grpPrevCompetenza_S.Controls.Add(this.txtPiccoleSpeseImp);
			this.grpPrevCompetenza_S.Controls.Add(this.label11);
			this.grpPrevCompetenza_S.Controls.Add(this.btnVarPrevCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.lblVarPrevCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.txtVarPrevCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.lblPrevDispCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.txtPrevDispCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.btnImpegni);
			this.grpPrevCompetenza_S.Controls.Add(this.lblImpegni);
			this.grpPrevCompetenza_S.Controls.Add(this.txtImpegniCompetenza);
			this.grpPrevCompetenza_S.Controls.Add(this.btnPrevInizialeCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.lblPrevInizialeCompetenza_S);
			this.grpPrevCompetenza_S.Controls.Add(this.txtPrevInizialeCompetenza_S);
			this.grpPrevCompetenza_S.Location = new System.Drawing.Point(6, 6);
			this.grpPrevCompetenza_S.Name = "grpPrevCompetenza_S";
			this.grpPrevCompetenza_S.Size = new System.Drawing.Size(577, 185);
			this.grpPrevCompetenza_S.TabIndex = 63;
			this.grpPrevCompetenza_S.TabStop = false;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(438, 72);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(42, 13);
			this.label27.TabIndex = 70;
			this.label27.Text = "= A + B";
			// 
			// label28
			// 
			this.label28.Location = new System.Drawing.Point(91, 72);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(198, 13);
			this.label28.TabIndex = 68;
			this.label28.Text = "Previsione  attuale di Competenza";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCompetenzaS
			// 
			this.txtPrevAttualeCompetenzaS.Location = new System.Drawing.Point(297, 69);
			this.txtPrevAttualeCompetenzaS.Name = "txtPrevAttualeCompetenzaS";
			this.txtPrevAttualeCompetenzaS.ReadOnly = true;
			this.txtPrevAttualeCompetenzaS.Size = new System.Drawing.Size(137, 20);
			this.txtPrevAttualeCompetenzaS.TabIndex = 69;
			this.txtPrevAttualeCompetenzaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpeseImp
			// 
			this.btnPiccoleSpeseImp.Location = new System.Drawing.Point(440, 129);
			this.btnPiccoleSpeseImp.Name = "btnPiccoleSpeseImp";
			this.btnPiccoleSpeseImp.Size = new System.Drawing.Size(75, 23);
			this.btnPiccoleSpeseImp.TabIndex = 15;
			this.btnPiccoleSpeseImp.Text = "D";
			this.btnPiccoleSpeseImp.UseVisualStyleBackColor = true;
			this.btnPiccoleSpeseImp.Click += new System.EventHandler(this.btnPiccoleSpeseImp_Click);
			// 
			// lblPiccoleSpeseImp
			// 
			this.lblPiccoleSpeseImp.Location = new System.Drawing.Point(85, 134);
			this.lblPiccoleSpeseImp.Name = "lblPiccoleSpeseImp";
			this.lblPiccoleSpeseImp.Size = new System.Drawing.Size(204, 13);
			this.lblPiccoleSpeseImp.TabIndex = 13;
			this.lblPiccoleSpeseImp.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpeseImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpeseImp
			// 
			this.txtPiccoleSpeseImp.Location = new System.Drawing.Point(298, 129);
			this.txtPiccoleSpeseImp.Name = "txtPiccoleSpeseImp";
			this.txtPiccoleSpeseImp.ReadOnly = true;
			this.txtPiccoleSpeseImp.Size = new System.Drawing.Size(136, 20);
			this.txtPiccoleSpeseImp.TabIndex = 14;
			this.txtPiccoleSpeseImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(441, 162);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(85, 13);
			this.label11.TabIndex = 9;
			this.label11.Text = "E = A + B - C - D";
			// 
			// btnVarPrevCompetenza_S
			// 
			this.btnVarPrevCompetenza_S.Location = new System.Drawing.Point(440, 36);
			this.btnVarPrevCompetenza_S.Name = "btnVarPrevCompetenza_S";
			this.btnVarPrevCompetenza_S.Size = new System.Drawing.Size(75, 23);
			this.btnVarPrevCompetenza_S.TabIndex = 3;
			this.btnVarPrevCompetenza_S.Text = "B";
			this.btnVarPrevCompetenza_S.UseVisualStyleBackColor = true;
			this.btnVarPrevCompetenza_S.Click += new System.EventHandler(this.btnVarPrevCompetenza_S_Click);
			// 
			// lblVarPrevCompetenza_S
			// 
			this.lblVarPrevCompetenza_S.Location = new System.Drawing.Point(85, 38);
			this.lblVarPrevCompetenza_S.Name = "lblVarPrevCompetenza_S";
			this.lblVarPrevCompetenza_S.Size = new System.Drawing.Size(204, 13);
			this.lblVarPrevCompetenza_S.TabIndex = 0;
			this.lblVarPrevCompetenza_S.Text = "Var. Previsione  di Competenza";
			this.lblVarPrevCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevCompetenza_S
			// 
			this.txtVarPrevCompetenza_S.Location = new System.Drawing.Point(298, 35);
			this.txtVarPrevCompetenza_S.Name = "txtVarPrevCompetenza_S";
			this.txtVarPrevCompetenza_S.ReadOnly = true;
			this.txtVarPrevCompetenza_S.Size = new System.Drawing.Size(136, 20);
			this.txtVarPrevCompetenza_S.TabIndex = 2;
			this.txtVarPrevCompetenza_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCompetenza_S
			// 
			this.lblPrevDispCompetenza_S.Location = new System.Drawing.Point(85, 160);
			this.lblPrevDispCompetenza_S.Name = "lblPrevDispCompetenza_S";
			this.lblPrevDispCompetenza_S.Size = new System.Drawing.Size(204, 13);
			this.lblPrevDispCompetenza_S.TabIndex = 0;
			this.lblPrevDispCompetenza_S.Text = "Previsione Disponibile di Competenza";
			this.lblPrevDispCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevDispCompetenza_S
			// 
			this.txtPrevDispCompetenza_S.Location = new System.Drawing.Point(298, 157);
			this.txtPrevDispCompetenza_S.Name = "txtPrevDispCompetenza_S";
			this.txtPrevDispCompetenza_S.ReadOnly = true;
			this.txtPrevDispCompetenza_S.Size = new System.Drawing.Size(136, 20);
			this.txtPrevDispCompetenza_S.TabIndex = 8;
			this.txtPrevDispCompetenza_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnImpegni
			// 
			this.btnImpegni.Location = new System.Drawing.Point(440, 104);
			this.btnImpegni.Name = "btnImpegni";
			this.btnImpegni.Size = new System.Drawing.Size(75, 23);
			this.btnImpegni.TabIndex = 5;
			this.btnImpegni.Text = "C";
			this.btnImpegni.UseVisualStyleBackColor = true;
			this.btnImpegni.Click += new System.EventHandler(this.btnImpegni_Click);
			// 
			// lblImpegni
			// 
			this.lblImpegni.Location = new System.Drawing.Point(85, 106);
			this.lblImpegni.Name = "lblImpegni";
			this.lblImpegni.Size = new System.Drawing.Size(204, 13);
			this.lblImpegni.TabIndex = 0;
			this.lblImpegni.Text = "Impegni di Competenza";
			this.lblImpegni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpegniCompetenza
			// 
			this.txtImpegniCompetenza.Location = new System.Drawing.Point(298, 103);
			this.txtImpegniCompetenza.Name = "txtImpegniCompetenza";
			this.txtImpegniCompetenza.ReadOnly = true;
			this.txtImpegniCompetenza.Size = new System.Drawing.Size(136, 20);
			this.txtImpegniCompetenza.TabIndex = 4;
			this.txtImpegniCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCompetenza_S
			// 
			this.btnPrevInizialeCompetenza_S.Location = new System.Drawing.Point(440, 8);
			this.btnPrevInizialeCompetenza_S.Name = "btnPrevInizialeCompetenza_S";
			this.btnPrevInizialeCompetenza_S.Size = new System.Drawing.Size(75, 23);
			this.btnPrevInizialeCompetenza_S.TabIndex = 1;
			this.btnPrevInizialeCompetenza_S.Text = "A";
			this.btnPrevInizialeCompetenza_S.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCompetenza_S.Click += new System.EventHandler(this.btnPrevInizialeCompetenza_S_Click);
			// 
			// lblPrevInizialeCompetenza_S
			// 
			this.lblPrevInizialeCompetenza_S.Location = new System.Drawing.Point(85, 12);
			this.lblPrevInizialeCompetenza_S.Name = "lblPrevInizialeCompetenza_S";
			this.lblPrevInizialeCompetenza_S.Size = new System.Drawing.Size(204, 13);
			this.lblPrevInizialeCompetenza_S.TabIndex = 0;
			this.lblPrevInizialeCompetenza_S.Text = "Previsione Iniziale di Competenza";
			this.lblPrevInizialeCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCompetenza_S
			// 
			this.txtPrevInizialeCompetenza_S.Location = new System.Drawing.Point(298, 9);
			this.txtPrevInizialeCompetenza_S.Name = "txtPrevInizialeCompetenza_S";
			this.txtPrevInizialeCompetenza_S.ReadOnly = true;
			this.txtPrevInizialeCompetenza_S.Size = new System.Drawing.Size(136, 20);
			this.txtPrevInizialeCompetenza_S.TabIndex = 0;
			this.txtPrevInizialeCompetenza_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpPrevCassa_S
			// 
			this.grpPrevCassa_S.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPrevCassa_S.Controls.Add(this.txtPrevDispCassaPerImpegni);
			this.grpPrevCassa_S.Controls.Add(this.label65);
			this.grpPrevCassa_S.Controls.Add(this.lblPrevDispCassaImpegni);
			this.grpPrevCassa_S.Controls.Add(this.btnImpegniAll);
			this.grpPrevCassa_S.Controls.Add(this.lblImpegniAll);
			this.grpPrevCassa_S.Controls.Add(this.txtImpegniAll);
			this.grpPrevCassa_S.Controls.Add(this.label29);
			this.grpPrevCassa_S.Controls.Add(this.label30);
			this.grpPrevCassa_S.Controls.Add(this.txtPrevAttualeCassaS);
			this.grpPrevCassa_S.Controls.Add(this.btnPiccoleSpesePagamenti);
			this.grpPrevCassa_S.Controls.Add(this.lblPiccoleSpesePagamenti);
			this.grpPrevCassa_S.Controls.Add(this.txtPiccoleSpesePagamenti);
			this.grpPrevCassa_S.Controls.Add(this.label8);
			this.grpPrevCassa_S.Controls.Add(this.btnVarPrevisioneCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.lblVarPrevisioneCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.txtVarPrevisioneCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.lblPrevDispCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.txtPrevDispCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.btnPagamenti);
			this.grpPrevCassa_S.Controls.Add(this.lblPagamenti);
			this.grpPrevCassa_S.Controls.Add(this.txtPagamenti);
			this.grpPrevCassa_S.Controls.Add(this.btnPrevInizialeCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.lblPrevInizialeCassa_S);
			this.grpPrevCassa_S.Controls.Add(this.txtPrevInizialeCassa_S);
			this.grpPrevCassa_S.Location = new System.Drawing.Point(5, 189);
			this.grpPrevCassa_S.Name = "grpPrevCassa_S";
			this.grpPrevCassa_S.Size = new System.Drawing.Size(577, 219);
			this.grpPrevCassa_S.TabIndex = 62;
			this.grpPrevCassa_S.TabStop = false;
			// 
			// txtPrevDispCassaPerImpegni
			// 
			this.txtPrevDispCassaPerImpegni.Location = new System.Drawing.Point(300, 171);
			this.txtPrevDispCassaPerImpegni.Name = "txtPrevDispCassaPerImpegni";
			this.txtPrevDispCassaPerImpegni.ReadOnly = true;
			this.txtPrevDispCassaPerImpegni.Size = new System.Drawing.Size(134, 20);
			this.txtPrevDispCassaPerImpegni.TabIndex = 64;
			this.txtPrevDispCassaPerImpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(446, 175);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(86, 13);
			this.label65.TabIndex = 63;
			this.label65.Text = "M = F + G - H - L";
			// 
			// lblPrevDispCassaImpegni
			// 
			this.lblPrevDispCassaImpegni.Location = new System.Drawing.Point(6, 164);
			this.lblPrevDispCassaImpegni.Name = "lblPrevDispCassaImpegni";
			this.lblPrevDispCassaImpegni.Size = new System.Drawing.Size(286, 32);
			this.lblPrevDispCassaImpegni.TabIndex = 62;
			this.lblPrevDispCassaImpegni.Text = "Previsione Disponibile di Cassa per Impegni";
			this.lblPrevDispCassaImpegni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnImpegniAll
			// 
			this.btnImpegniAll.Location = new System.Drawing.Point(446, 98);
			this.btnImpegniAll.Name = "btnImpegniAll";
			this.btnImpegniAll.Size = new System.Drawing.Size(75, 20);
			this.btnImpegniAll.TabIndex = 59;
			this.btnImpegniAll.Text = "H";
			this.btnImpegniAll.UseVisualStyleBackColor = true;
			this.btnImpegniAll.Click += new System.EventHandler(this.btnImpegniAll_Click);
			// 
			// lblImpegniAll
			// 
			this.lblImpegniAll.Location = new System.Drawing.Point(76, 98);
			this.lblImpegniAll.Name = "lblImpegniAll";
			this.lblImpegniAll.Size = new System.Drawing.Size(216, 18);
			this.lblImpegniAll.TabIndex = 57;
			this.lblImpegniAll.Text = "Impegni";
			this.lblImpegniAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpegniAll
			// 
			this.txtImpegniAll.Location = new System.Drawing.Point(300, 96);
			this.txtImpegniAll.Name = "txtImpegniAll";
			this.txtImpegniAll.ReadOnly = true;
			this.txtImpegniAll.Size = new System.Drawing.Size(134, 20);
			this.txtImpegniAll.TabIndex = 58;
			this.txtImpegniAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(450, 73);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(42, 13);
			this.label29.TabIndex = 26;
			this.label29.Text = "= F + G";
			// 
			// label30
			// 
			this.label30.Location = new System.Drawing.Point(106, 72);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(186, 13);
			this.label30.TabIndex = 24;
			this.label30.Text = "Previsione  attuale di Cassa";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevAttualeCassaS
			// 
			this.txtPrevAttualeCassaS.Location = new System.Drawing.Point(300, 70);
			this.txtPrevAttualeCassaS.Name = "txtPrevAttualeCassaS";
			this.txtPrevAttualeCassaS.ReadOnly = true;
			this.txtPrevAttualeCassaS.Size = new System.Drawing.Size(134, 20);
			this.txtPrevAttualeCassaS.TabIndex = 25;
			this.txtPrevAttualeCassaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpesePagamenti
			// 
			this.btnPiccoleSpesePagamenti.Location = new System.Drawing.Point(446, 146);
			this.btnPiccoleSpesePagamenti.Name = "btnPiccoleSpesePagamenti";
			this.btnPiccoleSpesePagamenti.Size = new System.Drawing.Size(75, 23);
			this.btnPiccoleSpesePagamenti.TabIndex = 18;
			this.btnPiccoleSpesePagamenti.Text = " L";
			this.btnPiccoleSpesePagamenti.UseVisualStyleBackColor = true;
			this.btnPiccoleSpesePagamenti.Click += new System.EventHandler(this.btnPiccoleSpesePagamenti_Click);
			// 
			// lblPiccoleSpesePagamenti
			// 
			this.lblPiccoleSpesePagamenti.Location = new System.Drawing.Point(93, 149);
			this.lblPiccoleSpesePagamenti.Name = "lblPiccoleSpesePagamenti";
			this.lblPiccoleSpesePagamenti.Size = new System.Drawing.Size(199, 13);
			this.lblPiccoleSpesePagamenti.TabIndex = 16;
			this.lblPiccoleSpesePagamenti.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpesePagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpesePagamenti
			// 
			this.txtPiccoleSpesePagamenti.Location = new System.Drawing.Point(300, 145);
			this.txtPiccoleSpesePagamenti.Name = "txtPiccoleSpesePagamenti";
			this.txtPiccoleSpesePagamenti.ReadOnly = true;
			this.txtPiccoleSpesePagamenti.Size = new System.Drawing.Size(134, 20);
			this.txtPiccoleSpesePagamenti.TabIndex = 17;
			this.txtPiccoleSpesePagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(447, 202);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(80, 13);
			this.label8.TabIndex = 9;
			this.label8.Text = "N = F + G - I - L";
			// 
			// btnVarPrevisioneCassa_S
			// 
			this.btnVarPrevisioneCassa_S.Location = new System.Drawing.Point(445, 38);
			this.btnVarPrevisioneCassa_S.Name = "btnVarPrevisioneCassa_S";
			this.btnVarPrevisioneCassa_S.Size = new System.Drawing.Size(75, 23);
			this.btnVarPrevisioneCassa_S.TabIndex = 3;
			this.btnVarPrevisioneCassa_S.Text = " G ";
			this.btnVarPrevisioneCassa_S.UseVisualStyleBackColor = true;
			this.btnVarPrevisioneCassa_S.Click += new System.EventHandler(this.btnVarPrevisioneCassa_S_Click);
			// 
			// lblVarPrevisioneCassa_S
			// 
			this.lblVarPrevisioneCassa_S.Location = new System.Drawing.Point(93, 43);
			this.lblVarPrevisioneCassa_S.Name = "lblVarPrevisioneCassa_S";
			this.lblVarPrevisioneCassa_S.Size = new System.Drawing.Size(199, 13);
			this.lblVarPrevisioneCassa_S.TabIndex = 0;
			this.lblVarPrevisioneCassa_S.Text = "Var. Previsione  di Cassa";
			this.lblVarPrevisioneCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarPrevisioneCassa_S
			// 
			this.txtVarPrevisioneCassa_S.Location = new System.Drawing.Point(299, 38);
			this.txtVarPrevisioneCassa_S.Name = "txtVarPrevisioneCassa_S";
			this.txtVarPrevisioneCassa_S.ReadOnly = true;
			this.txtVarPrevisioneCassa_S.Size = new System.Drawing.Size(136, 20);
			this.txtVarPrevisioneCassa_S.TabIndex = 2;
			this.txtVarPrevisioneCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblPrevDispCassa_S
			// 
			this.lblPrevDispCassa_S.Location = new System.Drawing.Point(6, 200);
			this.lblPrevDispCassa_S.Name = "lblPrevDispCassa_S";
			this.lblPrevDispCassa_S.Size = new System.Drawing.Size(286, 15);
			this.lblPrevDispCassa_S.TabIndex = 0;
			this.lblPrevDispCassa_S.Text = "Previsione Disponibile di Cassa";
			this.lblPrevDispCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevDispCassa_S
			// 
			this.txtPrevDispCassa_S.Location = new System.Drawing.Point(300, 197);
			this.txtPrevDispCassa_S.Name = "txtPrevDispCassa_S";
			this.txtPrevDispCassa_S.ReadOnly = true;
			this.txtPrevDispCassa_S.Size = new System.Drawing.Size(134, 20);
			this.txtPrevDispCassa_S.TabIndex = 8;
			this.txtPrevDispCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPagamenti
			// 
			this.btnPagamenti.Location = new System.Drawing.Point(445, 119);
			this.btnPagamenti.Name = "btnPagamenti";
			this.btnPagamenti.Size = new System.Drawing.Size(75, 23);
			this.btnPagamenti.TabIndex = 5;
			this.btnPagamenti.Text = " I";
			this.btnPagamenti.UseVisualStyleBackColor = true;
			this.btnPagamenti.Click += new System.EventHandler(this.btnPagamenti_Click);
			// 
			// lblPagamenti
			// 
			this.lblPagamenti.Location = new System.Drawing.Point(93, 127);
			this.lblPagamenti.Name = "lblPagamenti";
			this.lblPagamenti.Size = new System.Drawing.Size(199, 13);
			this.lblPagamenti.TabIndex = 0;
			this.lblPagamenti.Text = "Pagamenti";
			this.lblPagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPagamenti
			// 
			this.txtPagamenti.Location = new System.Drawing.Point(300, 119);
			this.txtPagamenti.Name = "txtPagamenti";
			this.txtPagamenti.ReadOnly = true;
			this.txtPagamenti.Size = new System.Drawing.Size(134, 20);
			this.txtPagamenti.TabIndex = 4;
			this.txtPagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPrevInizialeCassa_S
			// 
			this.btnPrevInizialeCassa_S.Location = new System.Drawing.Point(445, 12);
			this.btnPrevInizialeCassa_S.Name = "btnPrevInizialeCassa_S";
			this.btnPrevInizialeCassa_S.Size = new System.Drawing.Size(75, 23);
			this.btnPrevInizialeCassa_S.TabIndex = 1;
			this.btnPrevInizialeCassa_S.Text = " F ";
			this.btnPrevInizialeCassa_S.UseVisualStyleBackColor = true;
			this.btnPrevInizialeCassa_S.Click += new System.EventHandler(this.btnPrevInizialeCassa_S_Click);
			// 
			// lblPrevInizialeCassa_S
			// 
			this.lblPrevInizialeCassa_S.Location = new System.Drawing.Point(93, 17);
			this.lblPrevInizialeCassa_S.Name = "lblPrevInizialeCassa_S";
			this.lblPrevInizialeCassa_S.Size = new System.Drawing.Size(199, 13);
			this.lblPrevInizialeCassa_S.TabIndex = 0;
			this.lblPrevInizialeCassa_S.Text = "Previsione Iniziale di Cassa";
			this.lblPrevInizialeCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPrevInizialeCassa_S
			// 
			this.txtPrevInizialeCassa_S.Location = new System.Drawing.Point(299, 12);
			this.txtPrevInizialeCassa_S.Name = "txtPrevInizialeCassa_S";
			this.txtPrevInizialeCassa_S.ReadOnly = true;
			this.txtPrevInizialeCassa_S.Size = new System.Drawing.Size(136, 20);
			this.txtPrevInizialeCassa_S.TabIndex = 0;
			this.txtPrevInizialeCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.grpCrediti);
			this.tabPage3.Controls.Add(this.grpCassa);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(585, 410);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Assegnazione crediti e cassa";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// grpCrediti
			// 
			this.grpCrediti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpCrediti.Controls.Add(this.label31);
			this.grpCrediti.Controls.Add(this.labelTotaleCrediti);
			this.grpCrediti.Controls.Add(this.txtTotaleCrediti);
			this.grpCrediti.Controls.Add(this.btnVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.txtVarDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.label7);
			this.grpCrediti.Controls.Add(this.btnDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.txtDotazioneCrediti);
			this.grpCrediti.Controls.Add(this.lblCreditiResidui);
			this.grpCrediti.Controls.Add(this.txtCreditiResidui);
			this.grpCrediti.Controls.Add(this.btnCreditiAssegnati);
			this.grpCrediti.Controls.Add(this.lblCreditiAssegnati);
			this.grpCrediti.Controls.Add(this.txtCreditiAssegnati);
			this.grpCrediti.Location = new System.Drawing.Point(8, 3);
			this.grpCrediti.Name = "grpCrediti";
			this.grpCrediti.Size = new System.Drawing.Size(574, 175);
			this.grpCrediti.TabIndex = 60;
			this.grpCrediti.TabStop = false;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(372, 118);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(65, 13);
			this.label31.TabIndex = 69;
			this.label31.Text = "= M + N + O";
			// 
			// labelTotaleCrediti
			// 
			this.labelTotaleCrediti.Location = new System.Drawing.Point(57, 114);
			this.labelTotaleCrediti.Name = "labelTotaleCrediti";
			this.labelTotaleCrediti.Size = new System.Drawing.Size(148, 13);
			this.labelTotaleCrediti.TabIndex = 67;
			this.labelTotaleCrediti.Text = "Totale Crediti";
			this.labelTotaleCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleCrediti
			// 
			this.txtTotaleCrediti.Location = new System.Drawing.Point(211, 111);
			this.txtTotaleCrediti.Name = "txtTotaleCrediti";
			this.txtTotaleCrediti.ReadOnly = true;
			this.txtTotaleCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtTotaleCrediti.TabIndex = 68;
			this.txtTotaleCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnVarDotazioneCrediti
			// 
			this.btnVarDotazioneCrediti.Location = new System.Drawing.Point(367, 45);
			this.btnVarDotazioneCrediti.Name = "btnVarDotazioneCrediti";
			this.btnVarDotazioneCrediti.Size = new System.Drawing.Size(75, 23);
			this.btnVarDotazioneCrediti.TabIndex = 8;
			this.btnVarDotazioneCrediti.Text = " N ";
			this.btnVarDotazioneCrediti.UseVisualStyleBackColor = true;
			this.btnVarDotazioneCrediti.Click += new System.EventHandler(this.btnVarDotazioneCrediti_Click);
			// 
			// lblVarDotazioneCrediti
			// 
			this.lblVarDotazioneCrediti.Location = new System.Drawing.Point(10, 47);
			this.lblVarDotazioneCrediti.Name = "lblVarDotazioneCrediti";
			this.lblVarDotazioneCrediti.Size = new System.Drawing.Size(195, 13);
			this.lblVarDotazioneCrediti.TabIndex = 7;
			this.lblVarDotazioneCrediti.Text = "Var. Dotazione Crediti";
			this.lblVarDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarDotazioneCrediti
			// 
			this.txtVarDotazioneCrediti.Location = new System.Drawing.Point(210, 44);
			this.txtVarDotazioneCrediti.Name = "txtVarDotazioneCrediti";
			this.txtVarDotazioneCrediti.ReadOnly = true;
			this.txtVarDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtVarDotazioneCrediti.TabIndex = 6;
			this.txtVarDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(372, 150);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(111, 13);
			this.label7.TabIndex = 5;
			this.label7.Text = "P = M + N + O  - C - D";
			// 
			// btnDotazioneCrediti
			// 
			this.btnDotazioneCrediti.Location = new System.Drawing.Point(368, 15);
			this.btnDotazioneCrediti.Name = "btnDotazioneCrediti";
			this.btnDotazioneCrediti.Size = new System.Drawing.Size(75, 23);
			this.btnDotazioneCrediti.TabIndex = 1;
			this.btnDotazioneCrediti.Text = " M ";
			this.btnDotazioneCrediti.UseVisualStyleBackColor = true;
			this.btnDotazioneCrediti.Click += new System.EventHandler(this.btnDotazioneCrediti_Click);
			// 
			// lblDotazioneCrediti
			// 
			this.lblDotazioneCrediti.Location = new System.Drawing.Point(26, 17);
			this.lblDotazioneCrediti.Name = "lblDotazioneCrediti";
			this.lblDotazioneCrediti.Size = new System.Drawing.Size(179, 13);
			this.lblDotazioneCrediti.TabIndex = 0;
			this.lblDotazioneCrediti.Text = "Dotazione Iniziale Crediti";
			this.lblDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDotazioneCrediti
			// 
			this.txtDotazioneCrediti.Location = new System.Drawing.Point(211, 14);
			this.txtDotazioneCrediti.Name = "txtDotazioneCrediti";
			this.txtDotazioneCrediti.ReadOnly = true;
			this.txtDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
			this.txtDotazioneCrediti.TabIndex = 0;
			this.txtDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCreditiResidui
			// 
			this.lblCreditiResidui.Location = new System.Drawing.Point(13, 150);
			this.lblCreditiResidui.Name = "lblCreditiResidui";
			this.lblCreditiResidui.Size = new System.Drawing.Size(192, 13);
			this.lblCreditiResidui.TabIndex = 0;
			this.lblCreditiResidui.Text = "Crediti Residui";
			this.lblCreditiResidui.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCreditiResidui
			// 
			this.txtCreditiResidui.Location = new System.Drawing.Point(211, 147);
			this.txtCreditiResidui.Name = "txtCreditiResidui";
			this.txtCreditiResidui.ReadOnly = true;
			this.txtCreditiResidui.Size = new System.Drawing.Size(149, 20);
			this.txtCreditiResidui.TabIndex = 4;
			this.txtCreditiResidui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCreditiAssegnati
			// 
			this.btnCreditiAssegnati.Location = new System.Drawing.Point(368, 71);
			this.btnCreditiAssegnati.Name = "btnCreditiAssegnati";
			this.btnCreditiAssegnati.Size = new System.Drawing.Size(75, 23);
			this.btnCreditiAssegnati.TabIndex = 3;
			this.btnCreditiAssegnati.Text = " O ";
			this.btnCreditiAssegnati.UseVisualStyleBackColor = true;
			this.btnCreditiAssegnati.Click += new System.EventHandler(this.btnCreditiAssegnati_Click);
			// 
			// lblCreditiAssegnati
			// 
			this.lblCreditiAssegnati.Location = new System.Drawing.Point(13, 76);
			this.lblCreditiAssegnati.Name = "lblCreditiAssegnati";
			this.lblCreditiAssegnati.Size = new System.Drawing.Size(192, 13);
			this.lblCreditiAssegnati.TabIndex = 0;
			this.lblCreditiAssegnati.Text = "Totale Assegnazioni di Crediti";
			this.lblCreditiAssegnati.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCreditiAssegnati
			// 
			this.txtCreditiAssegnati.Location = new System.Drawing.Point(211, 73);
			this.txtCreditiAssegnati.Name = "txtCreditiAssegnati";
			this.txtCreditiAssegnati.ReadOnly = true;
			this.txtCreditiAssegnati.Size = new System.Drawing.Size(149, 20);
			this.txtCreditiAssegnati.TabIndex = 2;
			this.txtCreditiAssegnati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// grpCassa
			// 
			this.grpCassa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpCassa.Controls.Add(this.label32);
			this.grpCassa.Controls.Add(this.labelTotaleCassa);
			this.grpCassa.Controls.Add(this.txtTotaleCassa);
			this.grpCassa.Controls.Add(this.btnPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.lblPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.txtPiccoleSpesePagamenti1);
			this.grpCassa.Controls.Add(this.btnPagamenti1);
			this.grpCassa.Controls.Add(this.lblPagamenti1);
			this.grpCassa.Controls.Add(this.txtPagamenti1);
			this.grpCassa.Controls.Add(this.btnVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.txtVarDotazioneCassa);
			this.grpCassa.Controls.Add(this.label6);
			this.grpCassa.Controls.Add(this.btnDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblDotazioneCassa);
			this.grpCassa.Controls.Add(this.txtDotazioneCassa);
			this.grpCassa.Controls.Add(this.lblCassaResidua);
			this.grpCassa.Controls.Add(this.txtCassaResidua);
			this.grpCassa.Controls.Add(this.btnAssegnazioniCassa);
			this.grpCassa.Controls.Add(this.lblAssegnazioniCassa);
			this.grpCassa.Controls.Add(this.txtAssegnazioniCassa);
			this.grpCassa.Location = new System.Drawing.Point(3, 180);
			this.grpCassa.Name = "grpCassa";
			this.grpCassa.Size = new System.Drawing.Size(574, 221);
			this.grpCassa.TabIndex = 61;
			this.grpCassa.TabStop = false;
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(369, 107);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(63, 13);
			this.label32.TabIndex = 27;
			this.label32.Text = "= Q + R + S";
			// 
			// labelTotaleCassa
			// 
			this.labelTotaleCassa.Location = new System.Drawing.Point(54, 106);
			this.labelTotaleCassa.Name = "labelTotaleCassa";
			this.labelTotaleCassa.Size = new System.Drawing.Size(148, 13);
			this.labelTotaleCassa.TabIndex = 25;
			this.labelTotaleCassa.Text = "Totale Cassa";
			this.labelTotaleCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotaleCassa
			// 
			this.txtTotaleCassa.Location = new System.Drawing.Point(208, 103);
			this.txtTotaleCassa.Name = "txtTotaleCassa";
			this.txtTotaleCassa.ReadOnly = true;
			this.txtTotaleCassa.Size = new System.Drawing.Size(149, 20);
			this.txtTotaleCassa.TabIndex = 26;
			this.txtTotaleCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPiccoleSpesePagamenti1
			// 
			this.btnPiccoleSpesePagamenti1.Location = new System.Drawing.Point(367, 162);
			this.btnPiccoleSpesePagamenti1.Name = "btnPiccoleSpesePagamenti1";
			this.btnPiccoleSpesePagamenti1.Size = new System.Drawing.Size(75, 23);
			this.btnPiccoleSpesePagamenti1.TabIndex = 21;
			this.btnPiccoleSpesePagamenti1.Text = "U";
			this.btnPiccoleSpesePagamenti1.UseVisualStyleBackColor = true;
			this.btnPiccoleSpesePagamenti1.Click += new System.EventHandler(this.btnPiccoleSpesePagamenti1_Click);
			// 
			// lblPiccoleSpesePagamenti1
			// 
			this.lblPiccoleSpesePagamenti1.Location = new System.Drawing.Point(13, 164);
			this.lblPiccoleSpesePagamenti1.Name = "lblPiccoleSpesePagamenti1";
			this.lblPiccoleSpesePagamenti1.Size = new System.Drawing.Size(189, 13);
			this.lblPiccoleSpesePagamenti1.TabIndex = 19;
			this.lblPiccoleSpesePagamenti1.Text = "Piccole spese non reintegrate";
			this.lblPiccoleSpesePagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPiccoleSpesePagamenti1
			// 
			this.txtPiccoleSpesePagamenti1.Location = new System.Drawing.Point(210, 162);
			this.txtPiccoleSpesePagamenti1.Name = "txtPiccoleSpesePagamenti1";
			this.txtPiccoleSpesePagamenti1.ReadOnly = true;
			this.txtPiccoleSpesePagamenti1.Size = new System.Drawing.Size(149, 20);
			this.txtPiccoleSpesePagamenti1.TabIndex = 20;
			this.txtPiccoleSpesePagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPagamenti1
			// 
			this.btnPagamenti1.Location = new System.Drawing.Point(367, 136);
			this.btnPagamenti1.Name = "btnPagamenti1";
			this.btnPagamenti1.Size = new System.Drawing.Size(75, 23);
			this.btnPagamenti1.TabIndex = 11;
			this.btnPagamenti1.Text = " T ";
			this.btnPagamenti1.UseVisualStyleBackColor = true;
			this.btnPagamenti1.Click += new System.EventHandler(this.btnPagamenti_Click);
			// 
			// lblPagamenti1
			// 
			this.lblPagamenti1.Location = new System.Drawing.Point(4, 141);
			this.lblPagamenti1.Name = "lblPagamenti1";
			this.lblPagamenti1.Size = new System.Drawing.Size(198, 13);
			this.lblPagamenti1.TabIndex = 9;
			this.lblPagamenti1.Text = "Pagamenti";
			this.lblPagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPagamenti1
			// 
			this.txtPagamenti1.Location = new System.Drawing.Point(210, 136);
			this.txtPagamenti1.Name = "txtPagamenti1";
			this.txtPagamenti1.ReadOnly = true;
			this.txtPagamenti1.Size = new System.Drawing.Size(149, 20);
			this.txtPagamenti1.TabIndex = 10;
			this.txtPagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnVarDotazioneCassa
			// 
			this.btnVarDotazioneCassa.Location = new System.Drawing.Point(367, 41);
			this.btnVarDotazioneCassa.Name = "btnVarDotazioneCassa";
			this.btnVarDotazioneCassa.Size = new System.Drawing.Size(75, 23);
			this.btnVarDotazioneCassa.TabIndex = 8;
			this.btnVarDotazioneCassa.Text = " R ";
			this.btnVarDotazioneCassa.UseVisualStyleBackColor = true;
			this.btnVarDotazioneCassa.Click += new System.EventHandler(this.btnVarDotazioneCassa_Click);
			// 
			// lblVarDotazioneCassa
			// 
			this.lblVarDotazioneCassa.Location = new System.Drawing.Point(10, 44);
			this.lblVarDotazioneCassa.Name = "lblVarDotazioneCassa";
			this.lblVarDotazioneCassa.Size = new System.Drawing.Size(192, 13);
			this.lblVarDotazioneCassa.TabIndex = 7;
			this.lblVarDotazioneCassa.Text = "Var. Dotazione Cassa";
			this.lblVarDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarDotazioneCassa
			// 
			this.txtVarDotazioneCassa.Location = new System.Drawing.Point(210, 41);
			this.txtVarDotazioneCassa.Name = "txtVarDotazioneCassa";
			this.txtVarDotazioneCassa.ReadOnly = true;
			this.txtVarDotazioneCassa.Size = new System.Drawing.Size(149, 20);
			this.txtVarDotazioneCassa.TabIndex = 6;
			this.txtVarDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(369, 192);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(110, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = " V = M + R + S - T - U";
			// 
			// btnDotazioneCassa
			// 
			this.btnDotazioneCassa.Location = new System.Drawing.Point(367, 14);
			this.btnDotazioneCassa.Name = "btnDotazioneCassa";
			this.btnDotazioneCassa.Size = new System.Drawing.Size(75, 23);
			this.btnDotazioneCassa.TabIndex = 1;
			this.btnDotazioneCassa.Text = " Q ";
			this.btnDotazioneCassa.UseVisualStyleBackColor = true;
			this.btnDotazioneCassa.Click += new System.EventHandler(this.btnDotazioneCassa_Click);
			// 
			// lblDotazioneCassa
			// 
			this.lblDotazioneCassa.Location = new System.Drawing.Point(10, 13);
			this.lblDotazioneCassa.Name = "lblDotazioneCassa";
			this.lblDotazioneCassa.Size = new System.Drawing.Size(192, 13);
			this.lblDotazioneCassa.TabIndex = 0;
			this.lblDotazioneCassa.Text = "Dotazione Iniziale Cassa";
			this.lblDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDotazioneCassa
			// 
			this.txtDotazioneCassa.Location = new System.Drawing.Point(210, 13);
			this.txtDotazioneCassa.Name = "txtDotazioneCassa";
			this.txtDotazioneCassa.ReadOnly = true;
			this.txtDotazioneCassa.Size = new System.Drawing.Size(149, 20);
			this.txtDotazioneCassa.TabIndex = 0;
			this.txtDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblCassaResidua
			// 
			this.lblCassaResidua.Location = new System.Drawing.Point(13, 189);
			this.lblCassaResidua.Name = "lblCassaResidua";
			this.lblCassaResidua.Size = new System.Drawing.Size(189, 13);
			this.lblCassaResidua.TabIndex = 0;
			this.lblCassaResidua.Text = "Assegnazioni di Cassa residue";
			this.lblCassaResidua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCassaResidua
			// 
			this.txtCassaResidua.Location = new System.Drawing.Point(210, 189);
			this.txtCassaResidua.Name = "txtCassaResidua";
			this.txtCassaResidua.ReadOnly = true;
			this.txtCassaResidua.Size = new System.Drawing.Size(149, 20);
			this.txtCassaResidua.TabIndex = 4;
			this.txtCassaResidua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnAssegnazioniCassa
			// 
			this.btnAssegnazioniCassa.Location = new System.Drawing.Point(367, 69);
			this.btnAssegnazioniCassa.Name = "btnAssegnazioniCassa";
			this.btnAssegnazioniCassa.Size = new System.Drawing.Size(75, 23);
			this.btnAssegnazioniCassa.TabIndex = 3;
			this.btnAssegnazioniCassa.Text = " S ";
			this.btnAssegnazioniCassa.UseVisualStyleBackColor = true;
			this.btnAssegnazioniCassa.Click += new System.EventHandler(this.btnAssegnazioniCassa_Click);
			// 
			// lblAssegnazioniCassa
			// 
			this.lblAssegnazioniCassa.Location = new System.Drawing.Point(10, 75);
			this.lblAssegnazioniCassa.Name = "lblAssegnazioniCassa";
			this.lblAssegnazioniCassa.Size = new System.Drawing.Size(192, 13);
			this.lblAssegnazioniCassa.TabIndex = 0;
			this.lblAssegnazioniCassa.Text = "Totale Assegnazioni di cassa";
			this.lblAssegnazioniCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAssegnazioniCassa
			// 
			this.txtAssegnazioniCassa.Location = new System.Drawing.Point(210, 70);
			this.txtAssegnazioniCassa.Name = "txtAssegnazioniCassa";
			this.txtAssegnazioniCassa.ReadOnly = true;
			this.txtAssegnazioniCassa.Size = new System.Drawing.Size(149, 20);
			this.txtAssegnazioniCassa.TabIndex = 2;
			this.txtAssegnazioniCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabBudgetRiep
			// 
			this.tabBudgetRiep.Controls.Add(this.groupBox11);
			this.tabBudgetRiep.Controls.Add(this.groupBox10);
			this.tabBudgetRiep.Location = new System.Drawing.Point(4, 22);
			this.tabBudgetRiep.Name = "tabBudgetRiep";
			this.tabBudgetRiep.Padding = new System.Windows.Forms.Padding(3);
			this.tabBudgetRiep.Size = new System.Drawing.Size(585, 410);
			this.tabBudgetRiep.TabIndex = 3;
			this.tabBudgetRiep.Text = "Budget";
			this.tabBudgetRiep.UseVisualStyleBackColor = true;
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.Add(this.btnVarAccertamentiBudget);
			this.groupBox11.Controls.Add(this.label56);
			this.groupBox11.Controls.Add(this.txtVarAccertamentiBudget);
			this.groupBox11.Controls.Add(this.txtVarPreaccertamenti);
			this.groupBox11.Controls.Add(this.label57);
			this.groupBox11.Controls.Add(this.btnVarPreaccertamentiBudget);
			this.groupBox11.Controls.Add(this.btnAccertamentiBudget);
			this.groupBox11.Controls.Add(this.label58);
			this.groupBox11.Controls.Add(this.txtAccertamentiBudget);
			this.groupBox11.Controls.Add(this.label59);
			this.groupBox11.Controls.Add(this.btnVarBudgetAcc);
			this.groupBox11.Controls.Add(this.label60);
			this.groupBox11.Controls.Add(this.txtVarBudgetAcc);
			this.groupBox11.Controls.Add(this.label61);
			this.groupBox11.Controls.Add(this.txtBudgetdisponibilePreaccertmenti);
			this.groupBox11.Controls.Add(this.btnPreaccertamentiBudget);
			this.groupBox11.Controls.Add(this.label62);
			this.groupBox11.Controls.Add(this.txtPreaccertamentiBudget);
			this.groupBox11.Controls.Add(this.btnBudgetInizialeAcc);
			this.groupBox11.Controls.Add(this.label63);
			this.groupBox11.Controls.Add(this.txtBudgetInizialeAcc);
			this.groupBox11.Location = new System.Drawing.Point(9, 6);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(568, 198);
			this.groupBox11.TabIndex = 68;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Risorse di Budget";
			// 
			// btnVarAccertamentiBudget
			// 
			this.btnVarAccertamentiBudget.Location = new System.Drawing.Point(349, 131);
			this.btnVarAccertamentiBudget.Name = "btnVarAccertamentiBudget";
			this.btnVarAccertamentiBudget.Size = new System.Drawing.Size(75, 20);
			this.btnVarAccertamentiBudget.TabIndex = 108;
			this.btnVarAccertamentiBudget.Text = "F";
			this.btnVarAccertamentiBudget.UseVisualStyleBackColor = true;
			this.btnVarAccertamentiBudget.Click += new System.EventHandler(this.btnVarAccertamentiBudget_Click);
			// 
			// label56
			// 
			this.label56.Location = new System.Drawing.Point(20, 131);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(196, 18);
			this.label56.TabIndex = 106;
			this.label56.Text = "Variazioni a Accertamenti di Budget";
			this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarAccertamentiBudget
			// 
			this.txtVarAccertamentiBudget.Location = new System.Drawing.Point(222, 131);
			this.txtVarAccertamentiBudget.Name = "txtVarAccertamentiBudget";
			this.txtVarAccertamentiBudget.ReadOnly = true;
			this.txtVarAccertamentiBudget.Size = new System.Drawing.Size(121, 20);
			this.txtVarAccertamentiBudget.TabIndex = 107;
			this.txtVarAccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtVarPreaccertamenti
			// 
			this.txtVarPreaccertamenti.Location = new System.Drawing.Point(222, 87);
			this.txtVarPreaccertamenti.Name = "txtVarPreaccertamenti";
			this.txtVarPreaccertamenti.ReadOnly = true;
			this.txtVarPreaccertamenti.Size = new System.Drawing.Size(121, 20);
			this.txtVarPreaccertamenti.TabIndex = 104;
			this.txtVarPreaccertamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label57
			// 
			this.label57.Location = new System.Drawing.Point(17, 87);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(199, 18);
			this.label57.TabIndex = 103;
			this.label57.Text = "Variazioni a preaccertamenti di Budget";
			this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnVarPreaccertamentiBudget
			// 
			this.btnVarPreaccertamentiBudget.Location = new System.Drawing.Point(349, 86);
			this.btnVarPreaccertamentiBudget.Name = "btnVarPreaccertamentiBudget";
			this.btnVarPreaccertamentiBudget.Size = new System.Drawing.Size(75, 20);
			this.btnVarPreaccertamentiBudget.TabIndex = 105;
			this.btnVarPreaccertamentiBudget.Text = "D";
			this.btnVarPreaccertamentiBudget.UseVisualStyleBackColor = true;
			this.btnVarPreaccertamentiBudget.Click += new System.EventHandler(this.btnVarPreaccertamentiBudget_Click);
			// 
			// btnAccertamentiBudget
			// 
			this.btnAccertamentiBudget.Location = new System.Drawing.Point(349, 110);
			this.btnAccertamentiBudget.Name = "btnAccertamentiBudget";
			this.btnAccertamentiBudget.Size = new System.Drawing.Size(75, 20);
			this.btnAccertamentiBudget.TabIndex = 100;
			this.btnAccertamentiBudget.Text = "E";
			this.btnAccertamentiBudget.UseVisualStyleBackColor = true;
			this.btnAccertamentiBudget.Click += new System.EventHandler(this.btnAccertamentiBudget_Click);
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(18, 111);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(198, 13);
			this.label58.TabIndex = 88;
			this.label58.Text = "Accertamenti di Budget";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAccertamentiBudget
			// 
			this.txtAccertamentiBudget.Location = new System.Drawing.Point(222, 109);
			this.txtAccertamentiBudget.Name = "txtAccertamentiBudget";
			this.txtAccertamentiBudget.ReadOnly = true;
			this.txtAccertamentiBudget.Size = new System.Drawing.Size(121, 20);
			this.txtAccertamentiBudget.TabIndex = 99;
			this.txtAccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(346, 157);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(86, 13);
			this.label59.TabIndex = 102;
			this.label59.Text = "G = A + B - C - D";
			// 
			// btnVarBudgetAcc
			// 
			this.btnVarBudgetAcc.Location = new System.Drawing.Point(349, 41);
			this.btnVarBudgetAcc.Name = "btnVarBudgetAcc";
			this.btnVarBudgetAcc.Size = new System.Drawing.Size(75, 20);
			this.btnVarBudgetAcc.TabIndex = 96;
			this.btnVarBudgetAcc.Text = "B";
			this.btnVarBudgetAcc.UseVisualStyleBackColor = true;
			this.btnVarBudgetAcc.Click += new System.EventHandler(this.btnVarBudgetAcc_Click);
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(18, 43);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(198, 13);
			this.label60.TabIndex = 89;
			this.label60.Text = "Variazione Budget";
			this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarBudgetAcc
			// 
			this.txtVarBudgetAcc.Location = new System.Drawing.Point(222, 41);
			this.txtVarBudgetAcc.Name = "txtVarBudgetAcc";
			this.txtVarBudgetAcc.ReadOnly = true;
			this.txtVarBudgetAcc.Size = new System.Drawing.Size(121, 20);
			this.txtVarBudgetAcc.TabIndex = 95;
			this.txtVarBudgetAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label61
			// 
			this.label61.Location = new System.Drawing.Point(18, 155);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(198, 13);
			this.label61.TabIndex = 90;
			this.label61.Text = "Budget disponibile";
			this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBudgetdisponibilePreaccertmenti
			// 
			this.txtBudgetdisponibilePreaccertmenti.Location = new System.Drawing.Point(222, 153);
			this.txtBudgetdisponibilePreaccertmenti.Name = "txtBudgetdisponibilePreaccertmenti";
			this.txtBudgetdisponibilePreaccertmenti.ReadOnly = true;
			this.txtBudgetdisponibilePreaccertmenti.Size = new System.Drawing.Size(121, 20);
			this.txtBudgetdisponibilePreaccertmenti.TabIndex = 101;
			this.txtBudgetdisponibilePreaccertmenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPreaccertamentiBudget
			// 
			this.btnPreaccertamentiBudget.Location = new System.Drawing.Point(349, 65);
			this.btnPreaccertamentiBudget.Name = "btnPreaccertamentiBudget";
			this.btnPreaccertamentiBudget.Size = new System.Drawing.Size(75, 20);
			this.btnPreaccertamentiBudget.TabIndex = 98;
			this.btnPreaccertamentiBudget.Text = "C";
			this.btnPreaccertamentiBudget.UseVisualStyleBackColor = true;
			this.btnPreaccertamentiBudget.Click += new System.EventHandler(this.btnPreaccertamentiBudget_Click);
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(18, 66);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(198, 13);
			this.label62.TabIndex = 91;
			this.label62.Text = "Preaccertamenti di Budget";
			this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPreaccertamentiBudget
			// 
			this.txtPreaccertamentiBudget.Location = new System.Drawing.Point(222, 64);
			this.txtPreaccertamentiBudget.Name = "txtPreaccertamentiBudget";
			this.txtPreaccertamentiBudget.ReadOnly = true;
			this.txtPreaccertamentiBudget.Size = new System.Drawing.Size(121, 20);
			this.txtPreaccertamentiBudget.TabIndex = 97;
			this.txtPreaccertamentiBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnBudgetInizialeAcc
			// 
			this.btnBudgetInizialeAcc.Location = new System.Drawing.Point(349, 18);
			this.btnBudgetInizialeAcc.Name = "btnBudgetInizialeAcc";
			this.btnBudgetInizialeAcc.Size = new System.Drawing.Size(75, 20);
			this.btnBudgetInizialeAcc.TabIndex = 94;
			this.btnBudgetInizialeAcc.Text = "A";
			this.btnBudgetInizialeAcc.UseVisualStyleBackColor = true;
			this.btnBudgetInizialeAcc.Click += new System.EventHandler(this.btnBudgetInizialeAcc_Click);
			// 
			// label63
			// 
			this.label63.Location = new System.Drawing.Point(18, 21);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(198, 13);
			this.label63.TabIndex = 92;
			this.label63.Text = "Budget iniziale";
			this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBudgetInizialeAcc
			// 
			this.txtBudgetInizialeAcc.Location = new System.Drawing.Point(222, 19);
			this.txtBudgetInizialeAcc.Name = "txtBudgetInizialeAcc";
			this.txtBudgetInizialeAcc.ReadOnly = true;
			this.txtBudgetInizialeAcc.Size = new System.Drawing.Size(121, 20);
			this.txtBudgetInizialeAcc.TabIndex = 93;
			this.txtBudgetInizialeAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.Add(this.btnVarImpegniBudget);
			this.groupBox10.Controls.Add(this.label34);
			this.groupBox10.Controls.Add(this.txtVarImpegniBudget);
			this.groupBox10.Controls.Add(this.txtVarPreimpegni);
			this.groupBox10.Controls.Add(this.label35);
			this.groupBox10.Controls.Add(this.btnVarPreimpegni);
			this.groupBox10.Controls.Add(this.btnImpegniBudget);
			this.groupBox10.Controls.Add(this.label17);
			this.groupBox10.Controls.Add(this.txtImpegniBudget);
			this.groupBox10.Controls.Add(this.label18);
			this.groupBox10.Controls.Add(this.btnVarBudgetImp);
			this.groupBox10.Controls.Add(this.label19);
			this.groupBox10.Controls.Add(this.txtVarBudgetImp);
			this.groupBox10.Controls.Add(this.label20);
			this.groupBox10.Controls.Add(this.txtBudgetdisponibilePreimpegni);
			this.groupBox10.Controls.Add(this.btnPreimpegniBudget);
			this.groupBox10.Controls.Add(this.label21);
			this.groupBox10.Controls.Add(this.txtPreimpegniBudget);
			this.groupBox10.Controls.Add(this.btnBudgetInizialeImp);
			this.groupBox10.Controls.Add(this.label22);
			this.groupBox10.Controls.Add(this.txtBudgetInizialeImp);
			this.groupBox10.Location = new System.Drawing.Point(9, 211);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(568, 176);
			this.groupBox10.TabIndex = 67;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Impegni di Budget";
			// 
			// btnVarImpegniBudget
			// 
			this.btnVarImpegniBudget.Location = new System.Drawing.Point(348, 126);
			this.btnVarImpegniBudget.Name = "btnVarImpegniBudget";
			this.btnVarImpegniBudget.Size = new System.Drawing.Size(75, 20);
			this.btnVarImpegniBudget.TabIndex = 87;
			this.btnVarImpegniBudget.Text = "O";
			this.btnVarImpegniBudget.UseVisualStyleBackColor = true;
			this.btnVarImpegniBudget.Click += new System.EventHandler(this.btnVarImpegniBudget_Click);
			// 
			// label34
			// 
			this.label34.Location = new System.Drawing.Point(19, 126);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(196, 18);
			this.label34.TabIndex = 85;
			this.label34.Text = "Variazioni a Impegni di Budget";
			this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarImpegniBudget
			// 
			this.txtVarImpegniBudget.Location = new System.Drawing.Point(221, 126);
			this.txtVarImpegniBudget.Name = "txtVarImpegniBudget";
			this.txtVarImpegniBudget.ReadOnly = true;
			this.txtVarImpegniBudget.Size = new System.Drawing.Size(121, 20);
			this.txtVarImpegniBudget.TabIndex = 86;
			this.txtVarImpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtVarPreimpegni
			// 
			this.txtVarPreimpegni.Location = new System.Drawing.Point(221, 82);
			this.txtVarPreimpegni.Name = "txtVarPreimpegni";
			this.txtVarPreimpegni.ReadOnly = true;
			this.txtVarPreimpegni.Size = new System.Drawing.Size(121, 20);
			this.txtVarPreimpegni.TabIndex = 83;
			this.txtVarPreimpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(16, 82);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(199, 18);
			this.label35.TabIndex = 82;
			this.label35.Text = "Variazioni a Preimpegni di Budget";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnVarPreimpegni
			// 
			this.btnVarPreimpegni.Location = new System.Drawing.Point(348, 81);
			this.btnVarPreimpegni.Name = "btnVarPreimpegni";
			this.btnVarPreimpegni.Size = new System.Drawing.Size(75, 20);
			this.btnVarPreimpegni.TabIndex = 84;
			this.btnVarPreimpegni.Text = "M";
			this.btnVarPreimpegni.UseVisualStyleBackColor = true;
			this.btnVarPreimpegni.Click += new System.EventHandler(this.btnVarPreimpegni_Click);
			// 
			// btnImpegniBudget
			// 
			this.btnImpegniBudget.Location = new System.Drawing.Point(348, 105);
			this.btnImpegniBudget.Name = "btnImpegniBudget";
			this.btnImpegniBudget.Size = new System.Drawing.Size(75, 20);
			this.btnImpegniBudget.TabIndex = 79;
			this.btnImpegniBudget.Text = "N";
			this.btnImpegniBudget.UseVisualStyleBackColor = true;
			this.btnImpegniBudget.Click += new System.EventHandler(this.btnImpegniBudget_Click);
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(17, 106);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(198, 13);
			this.label17.TabIndex = 67;
			this.label17.Text = "Impegni di Budget";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImpegniBudget
			// 
			this.txtImpegniBudget.Location = new System.Drawing.Point(221, 104);
			this.txtImpegniBudget.Name = "txtImpegniBudget";
			this.txtImpegniBudget.ReadOnly = true;
			this.txtImpegniBudget.Size = new System.Drawing.Size(121, 20);
			this.txtImpegniBudget.TabIndex = 78;
			this.txtImpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(345, 152);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(82, 13);
			this.label18.TabIndex = 81;
			this.label18.Text = "P = H + I - L - M";
			// 
			// btnVarBudgetImp
			// 
			this.btnVarBudgetImp.Location = new System.Drawing.Point(348, 36);
			this.btnVarBudgetImp.Name = "btnVarBudgetImp";
			this.btnVarBudgetImp.Size = new System.Drawing.Size(75, 20);
			this.btnVarBudgetImp.TabIndex = 75;
			this.btnVarBudgetImp.Text = "I";
			this.btnVarBudgetImp.UseVisualStyleBackColor = true;
			this.btnVarBudgetImp.Click += new System.EventHandler(this.btnVarBudget_Click);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(17, 38);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(198, 13);
			this.label19.TabIndex = 68;
			this.label19.Text = "Variazione Budget";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVarBudgetImp
			// 
			this.txtVarBudgetImp.Location = new System.Drawing.Point(221, 36);
			this.txtVarBudgetImp.Name = "txtVarBudgetImp";
			this.txtVarBudgetImp.ReadOnly = true;
			this.txtVarBudgetImp.Size = new System.Drawing.Size(121, 20);
			this.txtVarBudgetImp.TabIndex = 74;
			this.txtVarBudgetImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(17, 150);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(198, 13);
			this.label20.TabIndex = 69;
			this.label20.Text = "Budget disponibile";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBudgetdisponibilePreimpegni
			// 
			this.txtBudgetdisponibilePreimpegni.Location = new System.Drawing.Point(221, 148);
			this.txtBudgetdisponibilePreimpegni.Name = "txtBudgetdisponibilePreimpegni";
			this.txtBudgetdisponibilePreimpegni.ReadOnly = true;
			this.txtBudgetdisponibilePreimpegni.Size = new System.Drawing.Size(121, 20);
			this.txtBudgetdisponibilePreimpegni.TabIndex = 80;
			this.txtBudgetdisponibilePreimpegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnPreimpegniBudget
			// 
			this.btnPreimpegniBudget.Location = new System.Drawing.Point(348, 60);
			this.btnPreimpegniBudget.Name = "btnPreimpegniBudget";
			this.btnPreimpegniBudget.Size = new System.Drawing.Size(75, 20);
			this.btnPreimpegniBudget.TabIndex = 77;
			this.btnPreimpegniBudget.Text = "L";
			this.btnPreimpegniBudget.UseVisualStyleBackColor = true;
			this.btnPreimpegniBudget.Click += new System.EventHandler(this.btnPreimpegniBudget_Click);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(17, 61);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(198, 13);
			this.label21.TabIndex = 70;
			this.label21.Text = "Preimpegni di Budget";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPreimpegniBudget
			// 
			this.txtPreimpegniBudget.Location = new System.Drawing.Point(221, 59);
			this.txtPreimpegniBudget.Name = "txtPreimpegniBudget";
			this.txtPreimpegniBudget.ReadOnly = true;
			this.txtPreimpegniBudget.Size = new System.Drawing.Size(121, 20);
			this.txtPreimpegniBudget.TabIndex = 76;
			this.txtPreimpegniBudget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnBudgetInizialeImp
			// 
			this.btnBudgetInizialeImp.Location = new System.Drawing.Point(348, 13);
			this.btnBudgetInizialeImp.Name = "btnBudgetInizialeImp";
			this.btnBudgetInizialeImp.Size = new System.Drawing.Size(75, 20);
			this.btnBudgetInizialeImp.TabIndex = 73;
			this.btnBudgetInizialeImp.Text = "H";
			this.btnBudgetInizialeImp.UseVisualStyleBackColor = true;
			this.btnBudgetInizialeImp.Click += new System.EventHandler(this.btnBudgetIniziale_Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(17, 16);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(198, 13);
			this.label22.TabIndex = 71;
			this.label22.Text = "Budget iniziale";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBudgetInizialeImp
			// 
			this.txtBudgetInizialeImp.Location = new System.Drawing.Point(221, 14);
			this.txtBudgetInizialeImp.Name = "txtBudgetInizialeImp";
			this.txtBudgetInizialeImp.ReadOnly = true;
			this.txtBudgetInizialeImp.Size = new System.Drawing.Size(121, 20);
			this.txtBudgetInizialeImp.TabIndex = 72;
			this.txtBudgetInizialeImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtAltrevociPassivoDifferenza);
			this.tabPage5.Controls.Add(this.AltrevociPassivoDareAvere);
			this.tabPage5.Controls.Add(this.txtAltrevociPassivoAvere);
			this.tabPage5.Controls.Add(this.txtAltrevociPassivoDare);
			this.tabPage5.Controls.Add(this.label55);
			this.tabPage5.Controls.Add(this.txtFondiAmmortamentoDifferenza);
			this.tabPage5.Controls.Add(this.FondiAmmortamentoDareAvere);
			this.tabPage5.Controls.Add(this.txtFondiAmmortamentoAvere);
			this.tabPage5.Controls.Add(this.txtFondiAmmortamentoDare);
			this.tabPage5.Controls.Add(this.label54);
			this.tabPage5.Controls.Add(this.txtAltrevociAttivoDifferenza);
			this.tabPage5.Controls.Add(this.AltrevociAttivoDareAvere);
			this.tabPage5.Controls.Add(this.txtAltrevociAttivoAvere);
			this.tabPage5.Controls.Add(this.txtAltrevociAttivoDare);
			this.tabPage5.Controls.Add(this.label53);
			this.tabPage5.Controls.Add(this.txtDisponibilit‡liquideDifferenza);
			this.tabPage5.Controls.Add(this.Disponibilit‡liquideDareAvere);
			this.tabPage5.Controls.Add(this.txtDisponibilit‡liquideAvere);
			this.tabPage5.Controls.Add(this.txtDisponibilit‡liquideDare);
			this.tabPage5.Controls.Add(this.label52);
			this.tabPage5.Controls.Add(this.label51);
			this.tabPage5.Controls.Add(this.txtFondoAccantonamentoDifferenza);
			this.tabPage5.Controls.Add(this.txtRiservaDifferenza);
			this.tabPage5.Controls.Add(this.txtRiscontiPassiviDifferenza);
			this.tabPage5.Controls.Add(this.txtRiscontiAttiviDifferenza);
			this.tabPage5.Controls.Add(this.txtRateiAttiviDifferenza);
			this.tabPage5.Controls.Add(this.txtContiDebitoDifferenza);
			this.tabPage5.Controls.Add(this.txtContiCreditoDifferenza);
			this.tabPage5.Controls.Add(this.txtImmobilizzazioniDifferenza);
			this.tabPage5.Controls.Add(this.txtRateiPassiviDifferenza);
			this.tabPage5.Controls.Add(this.txtRicaviDifferenza);
			this.tabPage5.Controls.Add(this.txtCostiDifferenza);
			this.tabPage5.Controls.Add(this.label50);
			this.tabPage5.Controls.Add(this.label41);
			this.tabPage5.Controls.Add(this.FondoAccantonamentoDareAvere);
			this.tabPage5.Controls.Add(this.RiservaDareAvere);
			this.tabPage5.Controls.Add(this.RiscontiPassiviDareAvere);
			this.tabPage5.Controls.Add(this.RiscontiAttiviDareAvere);
			this.tabPage5.Controls.Add(this.RateiPassiviDareAvere);
			this.tabPage5.Controls.Add(this.txtFondoAccantonamentoAvere);
			this.tabPage5.Controls.Add(this.txtRiservaAvere);
			this.tabPage5.Controls.Add(this.txtRiscontiPassiviAvere);
			this.tabPage5.Controls.Add(this.txtRiscontiAttiviAvere);
			this.tabPage5.Controls.Add(this.RateiAttiviDareAvere);
			this.tabPage5.Controls.Add(this.txtRateiAttiviAvere);
			this.tabPage5.Controls.Add(this.txtContiDebitoAvere);
			this.tabPage5.Controls.Add(this.ContiDebitoDareAvere);
			this.tabPage5.Controls.Add(this.ContiCreditoDareAvere);
			this.tabPage5.Controls.Add(this.txtContiCreditoAvere);
			this.tabPage5.Controls.Add(this.ImmobilizzazioniDareAvere);
			this.tabPage5.Controls.Add(this.txtImmobilizzazioniAvere);
			this.tabPage5.Controls.Add(this.txtRateiPassiviAvere);
			this.tabPage5.Controls.Add(this.RicaviDareAvere);
			this.tabPage5.Controls.Add(this.txtRicaviAvere);
			this.tabPage5.Controls.Add(this.CostiDareAvere);
			this.tabPage5.Controls.Add(this.txtCostiAvere);
			this.tabPage5.Controls.Add(this.txtFondoAccantonamentoDare);
			this.tabPage5.Controls.Add(this.txtRiservaDare);
			this.tabPage5.Controls.Add(this.txtRiscontiPassiviDare);
			this.tabPage5.Controls.Add(this.txtRiscontiAttiviDare);
			this.tabPage5.Controls.Add(this.label49);
			this.tabPage5.Controls.Add(this.label48);
			this.tabPage5.Controls.Add(this.label47);
			this.tabPage5.Controls.Add(this.label46);
			this.tabPage5.Controls.Add(this.label38);
			this.tabPage5.Controls.Add(this.txtRateiAttiviDare);
			this.tabPage5.Controls.Add(this.txtContiDebitoDare);
			this.tabPage5.Controls.Add(this.label39);
			this.tabPage5.Controls.Add(this.label40);
			this.tabPage5.Controls.Add(this.txtContiCreditoDare);
			this.tabPage5.Controls.Add(this.label42);
			this.tabPage5.Controls.Add(this.txtImmobilizzazioniDare);
			this.tabPage5.Controls.Add(this.label43);
			this.tabPage5.Controls.Add(this.txtRateiPassiviDare);
			this.tabPage5.Controls.Add(this.label44);
			this.tabPage5.Controls.Add(this.txtRicaviDare);
			this.tabPage5.Controls.Add(this.label45);
			this.tabPage5.Controls.Add(this.txtCostiDare);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(585, 410);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "EP";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtAltrevociPassivoDifferenza
			// 
			this.txtAltrevociPassivoDifferenza.Location = new System.Drawing.Point(403, 384);
			this.txtAltrevociPassivoDifferenza.Name = "txtAltrevociPassivoDifferenza";
			this.txtAltrevociPassivoDifferenza.ReadOnly = true;
			this.txtAltrevociPassivoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociPassivoDifferenza.TabIndex = 156;
			this.txtAltrevociPassivoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// AltrevociPassivoDareAvere
			// 
			this.AltrevociPassivoDareAvere.Location = new System.Drawing.Point(521, 384);
			this.AltrevociPassivoDareAvere.Name = "AltrevociPassivoDareAvere";
			this.AltrevociPassivoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.AltrevociPassivoDareAvere.TabIndex = 155;
			this.AltrevociPassivoDareAvere.Text = "Dettagli";
			this.AltrevociPassivoDareAvere.UseVisualStyleBackColor = true;
			this.AltrevociPassivoDareAvere.Click += new System.EventHandler(this.AltrevociPassivoDareAvere_Click);
			// 
			// txtAltrevociPassivoAvere
			// 
			this.txtAltrevociPassivoAvere.Location = new System.Drawing.Point(280, 384);
			this.txtAltrevociPassivoAvere.Name = "txtAltrevociPassivoAvere";
			this.txtAltrevociPassivoAvere.ReadOnly = true;
			this.txtAltrevociPassivoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociPassivoAvere.TabIndex = 154;
			this.txtAltrevociPassivoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAltrevociPassivoDare
			// 
			this.txtAltrevociPassivoDare.Location = new System.Drawing.Point(153, 384);
			this.txtAltrevociPassivoDare.Name = "txtAltrevociPassivoDare";
			this.txtAltrevociPassivoDare.ReadOnly = true;
			this.txtAltrevociPassivoDare.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociPassivoDare.TabIndex = 153;
			this.txtAltrevociPassivoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label55
			// 
			this.label55.Location = new System.Drawing.Point(11, 384);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(133, 13);
			this.label55.TabIndex = 152;
			this.label55.Text = "Altre voci del Passivo ";
			this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFondiAmmortamentoDifferenza
			// 
			this.txtFondiAmmortamentoDifferenza.Location = new System.Drawing.Point(403, 358);
			this.txtFondiAmmortamentoDifferenza.Name = "txtFondiAmmortamentoDifferenza";
			this.txtFondiAmmortamentoDifferenza.ReadOnly = true;
			this.txtFondiAmmortamentoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtFondiAmmortamentoDifferenza.TabIndex = 151;
			this.txtFondiAmmortamentoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// FondiAmmortamentoDareAvere
			// 
			this.FondiAmmortamentoDareAvere.Location = new System.Drawing.Point(521, 358);
			this.FondiAmmortamentoDareAvere.Name = "FondiAmmortamentoDareAvere";
			this.FondiAmmortamentoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.FondiAmmortamentoDareAvere.TabIndex = 150;
			this.FondiAmmortamentoDareAvere.Text = "Dettagli";
			this.FondiAmmortamentoDareAvere.UseVisualStyleBackColor = true;
			this.FondiAmmortamentoDareAvere.Click += new System.EventHandler(this.FondiAmmortamentoDareAvere_Click);
			// 
			// txtFondiAmmortamentoAvere
			// 
			this.txtFondiAmmortamentoAvere.Location = new System.Drawing.Point(280, 358);
			this.txtFondiAmmortamentoAvere.Name = "txtFondiAmmortamentoAvere";
			this.txtFondiAmmortamentoAvere.ReadOnly = true;
			this.txtFondiAmmortamentoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtFondiAmmortamentoAvere.TabIndex = 149;
			this.txtFondiAmmortamentoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFondiAmmortamentoDare
			// 
			this.txtFondiAmmortamentoDare.Location = new System.Drawing.Point(153, 358);
			this.txtFondiAmmortamentoDare.Name = "txtFondiAmmortamentoDare";
			this.txtFondiAmmortamentoDare.ReadOnly = true;
			this.txtFondiAmmortamentoDare.Size = new System.Drawing.Size(98, 20);
			this.txtFondiAmmortamentoDare.TabIndex = 148;
			this.txtFondiAmmortamentoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label54
			// 
			this.label54.Location = new System.Drawing.Point(11, 358);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(133, 13);
			this.label54.TabIndex = 147;
			this.label54.Text = "Fondi Ammortamento ";
			this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtAltrevociAttivoDifferenza
			// 
			this.txtAltrevociAttivoDifferenza.Location = new System.Drawing.Point(403, 332);
			this.txtAltrevociAttivoDifferenza.Name = "txtAltrevociAttivoDifferenza";
			this.txtAltrevociAttivoDifferenza.ReadOnly = true;
			this.txtAltrevociAttivoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociAttivoDifferenza.TabIndex = 146;
			this.txtAltrevociAttivoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// AltrevociAttivoDareAvere
			// 
			this.AltrevociAttivoDareAvere.Location = new System.Drawing.Point(521, 332);
			this.AltrevociAttivoDareAvere.Name = "AltrevociAttivoDareAvere";
			this.AltrevociAttivoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.AltrevociAttivoDareAvere.TabIndex = 145;
			this.AltrevociAttivoDareAvere.Text = "Dettagli";
			this.AltrevociAttivoDareAvere.UseVisualStyleBackColor = true;
			this.AltrevociAttivoDareAvere.Click += new System.EventHandler(this.AltrevociAttivoDareAvere_Click);
			// 
			// txtAltrevociAttivoAvere
			// 
			this.txtAltrevociAttivoAvere.Location = new System.Drawing.Point(280, 332);
			this.txtAltrevociAttivoAvere.Name = "txtAltrevociAttivoAvere";
			this.txtAltrevociAttivoAvere.ReadOnly = true;
			this.txtAltrevociAttivoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociAttivoAvere.TabIndex = 144;
			this.txtAltrevociAttivoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAltrevociAttivoDare
			// 
			this.txtAltrevociAttivoDare.Location = new System.Drawing.Point(153, 332);
			this.txtAltrevociAttivoDare.Name = "txtAltrevociAttivoDare";
			this.txtAltrevociAttivoDare.ReadOnly = true;
			this.txtAltrevociAttivoDare.Size = new System.Drawing.Size(98, 20);
			this.txtAltrevociAttivoDare.TabIndex = 143;
			this.txtAltrevociAttivoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label53
			// 
			this.label53.Location = new System.Drawing.Point(11, 332);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(133, 13);
			this.label53.TabIndex = 142;
			this.label53.Text = "Altre voci dell\'Attivo";
			this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtDisponibilit‡liquideDifferenza
			// 
			this.txtDisponibilit‡liquideDifferenza.Location = new System.Drawing.Point(403, 306);
			this.txtDisponibilit‡liquideDifferenza.Name = "txtDisponibilit‡liquideDifferenza";
			this.txtDisponibilit‡liquideDifferenza.ReadOnly = true;
			this.txtDisponibilit‡liquideDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtDisponibilit‡liquideDifferenza.TabIndex = 141;
			this.txtDisponibilit‡liquideDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// Disponibilit‡liquideDareAvere
			// 
			this.Disponibilit‡liquideDareAvere.Location = new System.Drawing.Point(521, 306);
			this.Disponibilit‡liquideDareAvere.Name = "Disponibilit‡liquideDareAvere";
			this.Disponibilit‡liquideDareAvere.Size = new System.Drawing.Size(52, 20);
			this.Disponibilit‡liquideDareAvere.TabIndex = 140;
			this.Disponibilit‡liquideDareAvere.Text = "Dettagli";
			this.Disponibilit‡liquideDareAvere.UseVisualStyleBackColor = true;
			this.Disponibilit‡liquideDareAvere.Click += new System.EventHandler(this.Disponibilit‡liquideDareAvere_Click);
			// 
			// txtDisponibilit‡liquideAvere
			// 
			this.txtDisponibilit‡liquideAvere.Location = new System.Drawing.Point(280, 306);
			this.txtDisponibilit‡liquideAvere.Name = "txtDisponibilit‡liquideAvere";
			this.txtDisponibilit‡liquideAvere.ReadOnly = true;
			this.txtDisponibilit‡liquideAvere.Size = new System.Drawing.Size(98, 20);
			this.txtDisponibilit‡liquideAvere.TabIndex = 139;
			this.txtDisponibilit‡liquideAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtDisponibilit‡liquideDare
			// 
			this.txtDisponibilit‡liquideDare.Location = new System.Drawing.Point(153, 306);
			this.txtDisponibilit‡liquideDare.Name = "txtDisponibilit‡liquideDare";
			this.txtDisponibilit‡liquideDare.ReadOnly = true;
			this.txtDisponibilit‡liquideDare.Size = new System.Drawing.Size(98, 20);
			this.txtDisponibilit‡liquideDare.TabIndex = 138;
			this.txtDisponibilit‡liquideDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label52
			// 
			this.label52.Location = new System.Drawing.Point(11, 306);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(133, 13);
			this.label52.TabIndex = 137;
			this.label52.Text = "Disponibilit‡ liquide";
			this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label51
			// 
			this.label51.Location = new System.Drawing.Point(410, 3);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(79, 15);
			this.label51.TabIndex = 136;
			this.label51.Text = "DIFFERENZA";
			this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFondoAccantonamentoDifferenza
			// 
			this.txtFondoAccantonamentoDifferenza.Location = new System.Drawing.Point(403, 280);
			this.txtFondoAccantonamentoDifferenza.Name = "txtFondoAccantonamentoDifferenza";
			this.txtFondoAccantonamentoDifferenza.ReadOnly = true;
			this.txtFondoAccantonamentoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtFondoAccantonamentoDifferenza.TabIndex = 135;
			this.txtFondoAccantonamentoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiservaDifferenza
			// 
			this.txtRiservaDifferenza.Location = new System.Drawing.Point(403, 254);
			this.txtRiservaDifferenza.Name = "txtRiservaDifferenza";
			this.txtRiservaDifferenza.ReadOnly = true;
			this.txtRiservaDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRiservaDifferenza.TabIndex = 134;
			this.txtRiservaDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiPassiviDifferenza
			// 
			this.txtRiscontiPassiviDifferenza.Location = new System.Drawing.Point(403, 228);
			this.txtRiscontiPassiviDifferenza.Name = "txtRiscontiPassiviDifferenza";
			this.txtRiscontiPassiviDifferenza.ReadOnly = true;
			this.txtRiscontiPassiviDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiPassiviDifferenza.TabIndex = 133;
			this.txtRiscontiPassiviDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiAttiviDifferenza
			// 
			this.txtRiscontiAttiviDifferenza.Location = new System.Drawing.Point(403, 202);
			this.txtRiscontiAttiviDifferenza.Name = "txtRiscontiAttiviDifferenza";
			this.txtRiscontiAttiviDifferenza.ReadOnly = true;
			this.txtRiscontiAttiviDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiAttiviDifferenza.TabIndex = 132;
			this.txtRiscontiAttiviDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRateiAttiviDifferenza
			// 
			this.txtRateiAttiviDifferenza.Location = new System.Drawing.Point(403, 150);
			this.txtRateiAttiviDifferenza.Name = "txtRateiAttiviDifferenza";
			this.txtRateiAttiviDifferenza.ReadOnly = true;
			this.txtRateiAttiviDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRateiAttiviDifferenza.TabIndex = 131;
			this.txtRateiAttiviDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContiDebitoDifferenza
			// 
			this.txtContiDebitoDifferenza.Location = new System.Drawing.Point(403, 98);
			this.txtContiDebitoDifferenza.Name = "txtContiDebitoDifferenza";
			this.txtContiDebitoDifferenza.ReadOnly = true;
			this.txtContiDebitoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtContiDebitoDifferenza.TabIndex = 130;
			this.txtContiDebitoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContiCreditoDifferenza
			// 
			this.txtContiCreditoDifferenza.Location = new System.Drawing.Point(403, 124);
			this.txtContiCreditoDifferenza.Name = "txtContiCreditoDifferenza";
			this.txtContiCreditoDifferenza.ReadOnly = true;
			this.txtContiCreditoDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtContiCreditoDifferenza.TabIndex = 128;
			this.txtContiCreditoDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtImmobilizzazioniDifferenza
			// 
			this.txtImmobilizzazioniDifferenza.Location = new System.Drawing.Point(403, 46);
			this.txtImmobilizzazioniDifferenza.Name = "txtImmobilizzazioniDifferenza";
			this.txtImmobilizzazioniDifferenza.ReadOnly = true;
			this.txtImmobilizzazioniDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtImmobilizzazioniDifferenza.TabIndex = 126;
			this.txtImmobilizzazioniDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRateiPassiviDifferenza
			// 
			this.txtRateiPassiviDifferenza.Location = new System.Drawing.Point(403, 176);
			this.txtRateiPassiviDifferenza.Name = "txtRateiPassiviDifferenza";
			this.txtRateiPassiviDifferenza.ReadOnly = true;
			this.txtRateiPassiviDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRateiPassiviDifferenza.TabIndex = 129;
			this.txtRateiPassiviDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRicaviDifferenza
			// 
			this.txtRicaviDifferenza.Location = new System.Drawing.Point(403, 72);
			this.txtRicaviDifferenza.Name = "txtRicaviDifferenza";
			this.txtRicaviDifferenza.ReadOnly = true;
			this.txtRicaviDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtRicaviDifferenza.TabIndex = 127;
			this.txtRicaviDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtCostiDifferenza
			// 
			this.txtCostiDifferenza.Location = new System.Drawing.Point(403, 20);
			this.txtCostiDifferenza.Name = "txtCostiDifferenza";
			this.txtCostiDifferenza.ReadOnly = true;
			this.txtCostiDifferenza.Size = new System.Drawing.Size(98, 20);
			this.txtCostiDifferenza.TabIndex = 125;
			this.txtCostiDifferenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(305, 3);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(44, 15);
			this.label50.TabIndex = 124;
			this.label50.Text = "AVERE";
			this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label41
			// 
			this.label41.Location = new System.Drawing.Point(172, 3);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(42, 15);
			this.label41.TabIndex = 123;
			this.label41.Text = "DARE";
			this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// FondoAccantonamentoDareAvere
			// 
			this.FondoAccantonamentoDareAvere.Location = new System.Drawing.Point(521, 280);
			this.FondoAccantonamentoDareAvere.Name = "FondoAccantonamentoDareAvere";
			this.FondoAccantonamentoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.FondoAccantonamentoDareAvere.TabIndex = 122;
			this.FondoAccantonamentoDareAvere.Text = "Dettagli";
			this.FondoAccantonamentoDareAvere.UseVisualStyleBackColor = true;
			this.FondoAccantonamentoDareAvere.Click += new System.EventHandler(this.FondoAccantonamentoDareAvere_Click);
			// 
			// RiservaDareAvere
			// 
			this.RiservaDareAvere.Location = new System.Drawing.Point(521, 254);
			this.RiservaDareAvere.Name = "RiservaDareAvere";
			this.RiservaDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RiservaDareAvere.TabIndex = 121;
			this.RiservaDareAvere.Text = "Dettagli";
			this.RiservaDareAvere.UseVisualStyleBackColor = true;
			this.RiservaDareAvere.Click += new System.EventHandler(this.RiservaDareAvere_Click);
			// 
			// RiscontiPassiviDareAvere
			// 
			this.RiscontiPassiviDareAvere.Location = new System.Drawing.Point(521, 228);
			this.RiscontiPassiviDareAvere.Name = "RiscontiPassiviDareAvere";
			this.RiscontiPassiviDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RiscontiPassiviDareAvere.TabIndex = 120;
			this.RiscontiPassiviDareAvere.Text = "Dettagli";
			this.RiscontiPassiviDareAvere.UseVisualStyleBackColor = true;
			this.RiscontiPassiviDareAvere.Click += new System.EventHandler(this.RiscontiPassiviDareAvere_Click);
			// 
			// RiscontiAttiviDareAvere
			// 
			this.RiscontiAttiviDareAvere.Location = new System.Drawing.Point(521, 202);
			this.RiscontiAttiviDareAvere.Name = "RiscontiAttiviDareAvere";
			this.RiscontiAttiviDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RiscontiAttiviDareAvere.TabIndex = 119;
			this.RiscontiAttiviDareAvere.Text = "Dettagli";
			this.RiscontiAttiviDareAvere.UseVisualStyleBackColor = true;
			this.RiscontiAttiviDareAvere.Click += new System.EventHandler(this.RiscontiAttiviDareAvere_Click);
			// 
			// RateiPassiviDareAvere
			// 
			this.RateiPassiviDareAvere.Location = new System.Drawing.Point(521, 176);
			this.RateiPassiviDareAvere.Name = "RateiPassiviDareAvere";
			this.RateiPassiviDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RateiPassiviDareAvere.TabIndex = 118;
			this.RateiPassiviDareAvere.Text = "Dettagli";
			this.RateiPassiviDareAvere.UseVisualStyleBackColor = true;
			this.RateiPassiviDareAvere.Click += new System.EventHandler(this.RateiPassiviDareAvere_Click);
			// 
			// txtFondoAccantonamentoAvere
			// 
			this.txtFondoAccantonamentoAvere.Location = new System.Drawing.Point(280, 280);
			this.txtFondoAccantonamentoAvere.Name = "txtFondoAccantonamentoAvere";
			this.txtFondoAccantonamentoAvere.ReadOnly = true;
			this.txtFondoAccantonamentoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtFondoAccantonamentoAvere.TabIndex = 117;
			this.txtFondoAccantonamentoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiservaAvere
			// 
			this.txtRiservaAvere.Location = new System.Drawing.Point(280, 254);
			this.txtRiservaAvere.Name = "txtRiservaAvere";
			this.txtRiservaAvere.ReadOnly = true;
			this.txtRiservaAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRiservaAvere.TabIndex = 116;
			this.txtRiservaAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiPassiviAvere
			// 
			this.txtRiscontiPassiviAvere.Location = new System.Drawing.Point(280, 228);
			this.txtRiscontiPassiviAvere.Name = "txtRiscontiPassiviAvere";
			this.txtRiscontiPassiviAvere.ReadOnly = true;
			this.txtRiscontiPassiviAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiPassiviAvere.TabIndex = 115;
			this.txtRiscontiPassiviAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiAttiviAvere
			// 
			this.txtRiscontiAttiviAvere.Location = new System.Drawing.Point(280, 202);
			this.txtRiscontiAttiviAvere.Name = "txtRiscontiAttiviAvere";
			this.txtRiscontiAttiviAvere.ReadOnly = true;
			this.txtRiscontiAttiviAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiAttiviAvere.TabIndex = 114;
			this.txtRiscontiAttiviAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// RateiAttiviDareAvere
			// 
			this.RateiAttiviDareAvere.Location = new System.Drawing.Point(521, 150);
			this.RateiAttiviDareAvere.Name = "RateiAttiviDareAvere";
			this.RateiAttiviDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RateiAttiviDareAvere.TabIndex = 113;
			this.RateiAttiviDareAvere.Text = "Dettagli";
			this.RateiAttiviDareAvere.UseVisualStyleBackColor = true;
			this.RateiAttiviDareAvere.Click += new System.EventHandler(this.RateiAttiviDareAvere_Click);
			// 
			// txtRateiAttiviAvere
			// 
			this.txtRateiAttiviAvere.Location = new System.Drawing.Point(280, 150);
			this.txtRateiAttiviAvere.Name = "txtRateiAttiviAvere";
			this.txtRateiAttiviAvere.ReadOnly = true;
			this.txtRateiAttiviAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRateiAttiviAvere.TabIndex = 112;
			this.txtRateiAttiviAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContiDebitoAvere
			// 
			this.txtContiDebitoAvere.Location = new System.Drawing.Point(280, 98);
			this.txtContiDebitoAvere.Name = "txtContiDebitoAvere";
			this.txtContiDebitoAvere.ReadOnly = true;
			this.txtContiDebitoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtContiDebitoAvere.TabIndex = 110;
			this.txtContiDebitoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ContiDebitoDareAvere
			// 
			this.ContiDebitoDareAvere.Location = new System.Drawing.Point(521, 98);
			this.ContiDebitoDareAvere.Name = "ContiDebitoDareAvere";
			this.ContiDebitoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.ContiDebitoDareAvere.TabIndex = 111;
			this.ContiDebitoDareAvere.Text = "Dettagli";
			this.ContiDebitoDareAvere.UseVisualStyleBackColor = true;
			this.ContiDebitoDareAvere.Click += new System.EventHandler(this.ContiDebitoDareAvere_Click);
			// 
			// ContiCreditoDareAvere
			// 
			this.ContiCreditoDareAvere.Location = new System.Drawing.Point(521, 124);
			this.ContiCreditoDareAvere.Name = "ContiCreditoDareAvere";
			this.ContiCreditoDareAvere.Size = new System.Drawing.Size(52, 20);
			this.ContiCreditoDareAvere.TabIndex = 108;
			this.ContiCreditoDareAvere.Text = "Dettagli";
			this.ContiCreditoDareAvere.UseVisualStyleBackColor = true;
			this.ContiCreditoDareAvere.Click += new System.EventHandler(this.ContiCreditoDareAvere_Click);
			// 
			// txtContiCreditoAvere
			// 
			this.txtContiCreditoAvere.Location = new System.Drawing.Point(280, 124);
			this.txtContiCreditoAvere.Name = "txtContiCreditoAvere";
			this.txtContiCreditoAvere.ReadOnly = true;
			this.txtContiCreditoAvere.Size = new System.Drawing.Size(98, 20);
			this.txtContiCreditoAvere.TabIndex = 107;
			this.txtContiCreditoAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ImmobilizzazioniDareAvere
			// 
			this.ImmobilizzazioniDareAvere.Location = new System.Drawing.Point(521, 46);
			this.ImmobilizzazioniDareAvere.Name = "ImmobilizzazioniDareAvere";
			this.ImmobilizzazioniDareAvere.Size = new System.Drawing.Size(52, 20);
			this.ImmobilizzazioniDareAvere.TabIndex = 104;
			this.ImmobilizzazioniDareAvere.Text = "Dettagli";
			this.ImmobilizzazioniDareAvere.UseVisualStyleBackColor = true;
			this.ImmobilizzazioniDareAvere.Click += new System.EventHandler(this.ImmobilizzazioniDareAvere_Click);
			// 
			// txtImmobilizzazioniAvere
			// 
			this.txtImmobilizzazioniAvere.Location = new System.Drawing.Point(280, 46);
			this.txtImmobilizzazioniAvere.Name = "txtImmobilizzazioniAvere";
			this.txtImmobilizzazioniAvere.ReadOnly = true;
			this.txtImmobilizzazioniAvere.Size = new System.Drawing.Size(98, 20);
			this.txtImmobilizzazioniAvere.TabIndex = 103;
			this.txtImmobilizzazioniAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRateiPassiviAvere
			// 
			this.txtRateiPassiviAvere.Location = new System.Drawing.Point(280, 176);
			this.txtRateiPassiviAvere.Name = "txtRateiPassiviAvere";
			this.txtRateiPassiviAvere.ReadOnly = true;
			this.txtRateiPassiviAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRateiPassiviAvere.TabIndex = 109;
			this.txtRateiPassiviAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// RicaviDareAvere
			// 
			this.RicaviDareAvere.Location = new System.Drawing.Point(521, 72);
			this.RicaviDareAvere.Name = "RicaviDareAvere";
			this.RicaviDareAvere.Size = new System.Drawing.Size(52, 20);
			this.RicaviDareAvere.TabIndex = 106;
			this.RicaviDareAvere.Text = "Dettagli";
			this.RicaviDareAvere.UseVisualStyleBackColor = true;
			this.RicaviDareAvere.Click += new System.EventHandler(this.RicaviDareAvere_Click);
			// 
			// txtRicaviAvere
			// 
			this.txtRicaviAvere.Location = new System.Drawing.Point(280, 72);
			this.txtRicaviAvere.Name = "txtRicaviAvere";
			this.txtRicaviAvere.ReadOnly = true;
			this.txtRicaviAvere.Size = new System.Drawing.Size(98, 20);
			this.txtRicaviAvere.TabIndex = 105;
			this.txtRicaviAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// CostiDareAvere
			// 
			this.CostiDareAvere.Location = new System.Drawing.Point(521, 20);
			this.CostiDareAvere.Name = "CostiDareAvere";
			this.CostiDareAvere.Size = new System.Drawing.Size(52, 20);
			this.CostiDareAvere.TabIndex = 102;
			this.CostiDareAvere.Text = "Dettagli";
			this.CostiDareAvere.UseVisualStyleBackColor = true;
			this.CostiDareAvere.Click += new System.EventHandler(this.CostiDareAvere_Click);
			// 
			// txtCostiAvere
			// 
			this.txtCostiAvere.Location = new System.Drawing.Point(280, 20);
			this.txtCostiAvere.Name = "txtCostiAvere";
			this.txtCostiAvere.ReadOnly = true;
			this.txtCostiAvere.Size = new System.Drawing.Size(98, 20);
			this.txtCostiAvere.TabIndex = 101;
			this.txtCostiAvere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtFondoAccantonamentoDare
			// 
			this.txtFondoAccantonamentoDare.Location = new System.Drawing.Point(153, 280);
			this.txtFondoAccantonamentoDare.Name = "txtFondoAccantonamentoDare";
			this.txtFondoAccantonamentoDare.ReadOnly = true;
			this.txtFondoAccantonamentoDare.Size = new System.Drawing.Size(98, 20);
			this.txtFondoAccantonamentoDare.TabIndex = 95;
			this.txtFondoAccantonamentoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiservaDare
			// 
			this.txtRiservaDare.Location = new System.Drawing.Point(153, 254);
			this.txtRiservaDare.Name = "txtRiservaDare";
			this.txtRiservaDare.ReadOnly = true;
			this.txtRiservaDare.Size = new System.Drawing.Size(98, 20);
			this.txtRiservaDare.TabIndex = 94;
			this.txtRiservaDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiPassiviDare
			// 
			this.txtRiscontiPassiviDare.Location = new System.Drawing.Point(153, 228);
			this.txtRiscontiPassiviDare.Name = "txtRiscontiPassiviDare";
			this.txtRiscontiPassiviDare.ReadOnly = true;
			this.txtRiscontiPassiviDare.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiPassiviDare.TabIndex = 93;
			this.txtRiscontiPassiviDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtRiscontiAttiviDare
			// 
			this.txtRiscontiAttiviDare.Location = new System.Drawing.Point(153, 202);
			this.txtRiscontiAttiviDare.Name = "txtRiscontiAttiviDare";
			this.txtRiscontiAttiviDare.ReadOnly = true;
			this.txtRiscontiAttiviDare.Size = new System.Drawing.Size(98, 20);
			this.txtRiscontiAttiviDare.TabIndex = 92;
			this.txtRiscontiAttiviDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(11, 280);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(133, 13);
			this.label49.TabIndex = 91;
			this.label49.Text = "Fondo di Accantonamento";
			this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(13, 254);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(133, 13);
			this.label48.TabIndex = 90;
			this.label48.Text = "Riserva";
			this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(10, 228);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(133, 13);
			this.label47.TabIndex = 89;
			this.label47.Text = "Risconti Passivi";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label46
			// 
			this.label46.Location = new System.Drawing.Point(10, 202);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(133, 13);
			this.label46.TabIndex = 88;
			this.label46.Text = "Risconti Attivi";
			this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(13, 150);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(133, 13);
			this.label38.TabIndex = 85;
			this.label38.Text = "Ratei Attivi";
			this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRateiAttiviDare
			// 
			this.txtRateiAttiviDare.Location = new System.Drawing.Point(153, 150);
			this.txtRateiAttiviDare.Name = "txtRateiAttiviDare";
			this.txtRateiAttiviDare.ReadOnly = true;
			this.txtRateiAttiviDare.Size = new System.Drawing.Size(98, 20);
			this.txtRateiAttiviDare.TabIndex = 86;
			this.txtRateiAttiviDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtContiDebitoDare
			// 
			this.txtContiDebitoDare.Location = new System.Drawing.Point(153, 98);
			this.txtContiDebitoDare.Name = "txtContiDebitoDare";
			this.txtContiDebitoDare.ReadOnly = true;
			this.txtContiDebitoDare.Size = new System.Drawing.Size(98, 20);
			this.txtContiDebitoDare.TabIndex = 83;
			this.txtContiDebitoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(10, 98);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(136, 13);
			this.label39.TabIndex = 82;
			this.label39.Text = "Conti di Debito";
			this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(11, 124);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(135, 13);
			this.label40.TabIndex = 67;
			this.label40.Text = "Conti di Credito";
			this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtContiCreditoDare
			// 
			this.txtContiCreditoDare.Location = new System.Drawing.Point(153, 124);
			this.txtContiCreditoDare.Name = "txtContiCreditoDare";
			this.txtContiCreditoDare.ReadOnly = true;
			this.txtContiCreditoDare.Size = new System.Drawing.Size(98, 20);
			this.txtContiCreditoDare.TabIndex = 78;
			this.txtContiCreditoDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(11, 46);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(135, 13);
			this.label42.TabIndex = 68;
			this.label42.Text = "Immobilizzazioni";
			this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtImmobilizzazioniDare
			// 
			this.txtImmobilizzazioniDare.Location = new System.Drawing.Point(153, 46);
			this.txtImmobilizzazioniDare.Name = "txtImmobilizzazioniDare";
			this.txtImmobilizzazioniDare.ReadOnly = true;
			this.txtImmobilizzazioniDare.Size = new System.Drawing.Size(98, 20);
			this.txtImmobilizzazioniDare.TabIndex = 74;
			this.txtImmobilizzazioniDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label43
			// 
			this.label43.Location = new System.Drawing.Point(11, 176);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(135, 13);
			this.label43.TabIndex = 69;
			this.label43.Text = "Ratei Passivi";
			this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRateiPassiviDare
			// 
			this.txtRateiPassiviDare.Location = new System.Drawing.Point(153, 176);
			this.txtRateiPassiviDare.Name = "txtRateiPassiviDare";
			this.txtRateiPassiviDare.ReadOnly = true;
			this.txtRateiPassiviDare.Size = new System.Drawing.Size(98, 20);
			this.txtRateiPassiviDare.TabIndex = 80;
			this.txtRateiPassiviDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label44
			// 
			this.label44.Location = new System.Drawing.Point(11, 72);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(135, 13);
			this.label44.TabIndex = 70;
			this.label44.Text = "Ricavi";
			this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRicaviDare
			// 
			this.txtRicaviDare.Location = new System.Drawing.Point(153, 72);
			this.txtRicaviDare.Name = "txtRicaviDare";
			this.txtRicaviDare.ReadOnly = true;
			this.txtRicaviDare.Size = new System.Drawing.Size(98, 20);
			this.txtRicaviDare.TabIndex = 76;
			this.txtRicaviDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label45
			// 
			this.label45.Location = new System.Drawing.Point(8, 20);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(135, 13);
			this.label45.TabIndex = 71;
			this.label45.Text = "Costi";
			this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCostiDare
			// 
			this.txtCostiDare.Location = new System.Drawing.Point(153, 20);
			this.txtCostiDare.Name = "txtCostiDare";
			this.txtCostiDare.ReadOnly = true;
			this.txtCostiDare.Size = new System.Drawing.Size(98, 20);
			this.txtCostiDare.TabIndex = 72;
			this.txtCostiDare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCalcolaTutto
			// 
			this.btnCalcolaTutto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCalcolaTutto.Location = new System.Drawing.Point(516, 19);
			this.btnCalcolaTutto.Name = "btnCalcolaTutto";
			this.btnCalcolaTutto.Size = new System.Drawing.Size(83, 25);
			this.btnCalcolaTutto.TabIndex = 66;
			this.btnCalcolaTutto.Text = "Calcola totali";
			this.btnCalcolaTutto.UseVisualStyleBackColor = true;
			this.btnCalcolaTutto.Click += new System.EventHandler(this.btnCalcolaTutto_Click);
			// 
			// tabAltro
			// 
			this.tabAltro.Controls.Add(this.checkBox2);
			this.tabAltro.Controls.Add(this.groupBox9);
			this.tabAltro.Controls.Add(this.grpBlocca);
			this.tabAltro.Controls.Add(this.grpDatiPrevisioneBudget);
			this.tabAltro.Controls.Add(this.btnInsDettagli);
			this.tabAltro.Controls.Add(this.groupBox8);
			this.tabAltro.Controls.Add(this.cmbEPUPBKind);
			this.tabAltro.Controls.Add(this.label33);
			this.tabAltro.Location = new System.Drawing.Point(4, 23);
			this.tabAltro.Name = "tabAltro";
			this.tabAltro.Padding = new System.Windows.Forms.Padding(3);
			this.tabAltro.Size = new System.Drawing.Size(670, 526);
			this.tabAltro.TabIndex = 8;
			this.tabAltro.Text = "Altro";
			this.tabAltro.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(5, 305);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(300, 17);
			this.checkBox2.TabIndex = 63;
			this.checkBox2.Tag = "upb.flag:2";
			this.checkBox2.Text = "Movimento di budget non atteso in P.D. (per diagnostiche)";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// groupBox9
			// 
			this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox9.Controls.Add(this.chkBloccaCoFiMovimenti);
			this.groupBox9.Controls.Add(this.chkBloccaCoGeMovimenti);
			this.groupBox9.Location = new System.Drawing.Point(5, 446);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox9.Size = new System.Drawing.Size(661, 53);
			this.groupBox9.TabIndex = 5;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Blocco movimenti di prima fase e variazioni di previsione";
			// 
			// chkBloccaCoFiMovimenti
			// 
			this.chkBloccaCoFiMovimenti.AutoSize = true;
			this.chkBloccaCoFiMovimenti.Location = new System.Drawing.Point(244, 23);
			this.chkBloccaCoFiMovimenti.Name = "chkBloccaCoFiMovimenti";
			this.chkBloccaCoFiMovimenti.Size = new System.Drawing.Size(125, 17);
			this.chkBloccaCoFiMovimenti.TabIndex = 1;
			this.chkBloccaCoFiMovimenti.Tag = "upb.flag:0";
			this.chkBloccaCoFiMovimenti.Text = "Contabilit‡ finanziaria";
			this.chkBloccaCoFiMovimenti.UseVisualStyleBackColor = true;
			// 
			// chkBloccaCoGeMovimenti
			// 
			this.chkBloccaCoGeMovimenti.AutoSize = true;
			this.chkBloccaCoGeMovimenti.Location = new System.Drawing.Point(11, 23);
			this.chkBloccaCoGeMovimenti.Name = "chkBloccaCoGeMovimenti";
			this.chkBloccaCoGeMovimenti.Size = new System.Drawing.Size(164, 17);
			this.chkBloccaCoGeMovimenti.TabIndex = 0;
			this.chkBloccaCoGeMovimenti.Tag = "upb.flag:1";
			this.chkBloccaCoGeMovimenti.Text = "Contabilit‡ generale e budget";
			this.chkBloccaCoGeMovimenti.UseVisualStyleBackColor = true;
			// 
			// grpBlocca
			// 
			this.grpBlocca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpBlocca.Controls.Add(this.SubEntity_chkBloccaCoFi);
			this.grpBlocca.Controls.Add(this.SubEntity_chkBloccaCoGe);
			this.grpBlocca.Location = new System.Drawing.Point(5, 387);
			this.grpBlocca.Name = "grpBlocca";
			this.grpBlocca.Padding = new System.Windows.Forms.Padding(10);
			this.grpBlocca.Size = new System.Drawing.Size(661, 53);
			this.grpBlocca.TabIndex = 4;
			this.grpBlocca.TabStop = false;
			this.grpBlocca.Text = "Blocco per assestamento di bilancio";
			// 
			// SubEntity_chkBloccaCoFi
			// 
			this.SubEntity_chkBloccaCoFi.AutoSize = true;
			this.SubEntity_chkBloccaCoFi.Location = new System.Drawing.Point(244, 23);
			this.SubEntity_chkBloccaCoFi.Name = "SubEntity_chkBloccaCoFi";
			this.SubEntity_chkBloccaCoFi.Size = new System.Drawing.Size(125, 17);
			this.SubEntity_chkBloccaCoFi.TabIndex = 1;
			this.SubEntity_chkBloccaCoFi.Tag = "upbyear.locked:1";
			this.SubEntity_chkBloccaCoFi.Text = "Contabilit‡ finanziaria";
			this.SubEntity_chkBloccaCoFi.UseVisualStyleBackColor = true;
			// 
			// SubEntity_chkBloccaCoGe
			// 
			this.SubEntity_chkBloccaCoGe.AutoSize = true;
			this.SubEntity_chkBloccaCoGe.Location = new System.Drawing.Point(11, 24);
			this.SubEntity_chkBloccaCoGe.Name = "SubEntity_chkBloccaCoGe";
			this.SubEntity_chkBloccaCoGe.Size = new System.Drawing.Size(164, 17);
			this.SubEntity_chkBloccaCoGe.TabIndex = 0;
			this.SubEntity_chkBloccaCoGe.Tag = "upbyear.locked:0";
			this.SubEntity_chkBloccaCoGe.Text = "Contabilit‡ generale e budget";
			this.SubEntity_chkBloccaCoGe.UseVisualStyleBackColor = true;
			// 
			// grpDatiPrevisioneBudget
			// 
			this.grpDatiPrevisioneBudget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.grpDatiPrevisioneBudget.Controls.Add(this.label36);
			this.grpDatiPrevisioneBudget.Controls.Add(this.SubEntity_txtCostiPresunti);
			this.grpDatiPrevisioneBudget.Controls.Add(this.SubEntity_txtRicaviPresunti);
			this.grpDatiPrevisioneBudget.Controls.Add(this.label37);
			this.grpDatiPrevisioneBudget.Location = new System.Drawing.Point(5, 328);
			this.grpDatiPrevisioneBudget.Name = "grpDatiPrevisioneBudget";
			this.grpDatiPrevisioneBudget.Padding = new System.Windows.Forms.Padding(10);
			this.grpDatiPrevisioneBudget.Size = new System.Drawing.Size(661, 53);
			this.grpDatiPrevisioneBudget.TabIndex = 3;
			this.grpDatiPrevisioneBudget.TabStop = false;
			this.grpDatiPrevisioneBudget.Text = "Dati utili Percentuale completamento";
			// 
			// label36
			// 
			this.label36.Location = new System.Drawing.Point(11, 22);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(166, 23);
			this.label36.TabIndex = 59;
			this.label36.Text = "Costi Totali Presunti";
			this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SubEntity_txtCostiPresunti
			// 
			this.SubEntity_txtCostiPresunti.Location = new System.Drawing.Point(182, 23);
			this.SubEntity_txtCostiPresunti.Name = "SubEntity_txtCostiPresunti";
			this.SubEntity_txtCostiPresunti.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtCostiPresunti.TabIndex = 57;
			this.SubEntity_txtCostiPresunti.Tag = "upbyear.costprevision";
			// 
			// SubEntity_txtRicaviPresunti
			// 
			this.SubEntity_txtRicaviPresunti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SubEntity_txtRicaviPresunti.Location = new System.Drawing.Point(538, 23);
			this.SubEntity_txtRicaviPresunti.Name = "SubEntity_txtRicaviPresunti";
			this.SubEntity_txtRicaviPresunti.Size = new System.Drawing.Size(112, 20);
			this.SubEntity_txtRicaviPresunti.TabIndex = 58;
			this.SubEntity_txtRicaviPresunti.Tag = "upbyear.revenueprevision";
			// 
			// label37
			// 
			this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label37.Location = new System.Drawing.Point(367, 22);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(166, 23);
			this.label37.TabIndex = 60;
			this.label37.Text = "Ricavi Totali Presunti";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnInsDettagli
			// 
			this.btnInsDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnInsDettagli.Location = new System.Drawing.Point(453, 300);
			this.btnInsDettagli.Name = "btnInsDettagli";
			this.btnInsDettagli.Size = new System.Drawing.Size(207, 22);
			this.btnInsDettagli.TabIndex = 62;
			this.btnInsDettagli.Text = "Inserisci informazioni annuali";
			this.btnInsDettagli.UseVisualStyleBackColor = true;
			this.btnInsDettagli.Click += new System.EventHandler(this.btnInsDettagli_Click);
			// 
			// groupBox8
			// 
			this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox8.Controls.Add(this.dataGrid1);
			this.groupBox8.Controls.Add(this.button4);
			this.groupBox8.Controls.Add(this.button5);
			this.groupBox8.Controls.Add(this.button6);
			this.groupBox8.Location = new System.Drawing.Point(11, 74);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(656, 221);
			this.groupBox8.TabIndex = 2;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Destinazione Utile Progetto  a Scadenza";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(81, 19);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(568, 196);
			this.dataGrid1.TabIndex = 21;
			this.dataGrid1.Tag = "upbprofitpartition.default.single";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(4, 81);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 24);
			this.button4.TabIndex = 20;
			this.button4.Tag = "delete";
			this.button4.Text = "Elimina";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(4, 49);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 24);
			this.button5.TabIndex = 19;
			this.button5.Tag = "edit.single";
			this.button5.Text = "Modifica";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(4, 17);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(72, 24);
			this.button6.TabIndex = 18;
			this.button6.Tag = "insert.single";
			this.button6.Text = "Inserisci";
			// 
			// cmbEPUPBKind
			// 
			this.cmbEPUPBKind.DataSource = this.DS.epupbkind;
			this.cmbEPUPBKind.DisplayMember = "title";
			this.cmbEPUPBKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEPUPBKind.Location = new System.Drawing.Point(10, 35);
			this.cmbEPUPBKind.Name = "cmbEPUPBKind";
			this.cmbEPUPBKind.Size = new System.Drawing.Size(364, 21);
			this.cmbEPUPBKind.TabIndex = 1;
			this.cmbEPUPBKind.Tag = "upb.idepupbkind";
			this.cmbEPUPBKind.ValueMember = "idepupbkind";
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(7, 19);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(212, 13);
			this.label33.TabIndex = 0;
			this.label33.Text = "Tipo UPB ai fini dell\'economico patrimoniale";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.dataGrid3);
			this.tabPage4.Controls.Add(this.button7);
			this.tabPage4.Controls.Add(this.button8);
			this.tabPage4.Controls.Add(this.button9);
			this.tabPage4.Location = new System.Drawing.Point(4, 42);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(619, 507);
			this.tabPage4.TabIndex = 9;
			this.tabPage4.Text = "Allegati";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// dataGrid3
			// 
			this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid3.DataMember = "";
			this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid3.Location = new System.Drawing.Point(28, 59);
			this.dataGrid3.Name = "dataGrid3";
			this.dataGrid3.ReadOnly = true;
			this.dataGrid3.Size = new System.Drawing.Size(583, 351);
			this.dataGrid3.TabIndex = 26;
			this.dataGrid3.Tag = "upbattachment.default.default";
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(188, 29);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(68, 24);
			this.button7.TabIndex = 25;
			this.button7.Tag = "delete";
			this.button7.Text = "Elimina";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(108, 29);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(69, 24);
			this.button8.TabIndex = 24;
			this.button8.Tag = "edit.default";
			this.button8.Text = "Modifica...";
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(28, 29);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(68, 24);
			this.button9.TabIndex = 23;
			this.button9.Tag = "insert.default";
			this.button9.Text = "Inserisci...";
			// 
			// tabFabbisogno
			// 
			this.tabFabbisogno.Controls.Add(this.label66);
			this.tabFabbisogno.Controls.Add(this.cmbCofog);
			this.tabFabbisogno.Controls.Add(this.label69);
			this.tabFabbisogno.Controls.Add(this.grpCodUE);
			this.tabFabbisogno.Location = new System.Drawing.Point(4, 23);
			this.tabFabbisogno.Name = "tabFabbisogno";
			this.tabFabbisogno.Padding = new System.Windows.Forms.Padding(3);
			this.tabFabbisogno.Size = new System.Drawing.Size(670, 526);
			this.tabFabbisogno.TabIndex = 10;
			this.tabFabbisogno.Text = "Fabbisogno";
			this.tabFabbisogno.UseVisualStyleBackColor = true;
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(24, 44);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(80, 13);
			this.label66.TabIndex = 46;
			this.label66.Text = "Codice COFOG";
			// 
			// cmbCofog
			// 
			this.cmbCofog.DataSource = this.DS.codicecofogmp;
			this.cmbCofog.DisplayMember = "descrizione";
			this.cmbCofog.FormattingEnabled = true;
			this.cmbCofog.Location = new System.Drawing.Point(27, 62);
			this.cmbCofog.Name = "cmbCofog";
			this.cmbCofog.Size = new System.Drawing.Size(462, 21);
			this.cmbCofog.TabIndex = 45;
			this.cmbCofog.Tag = "upb.cofogmpcode";
			this.cmbCofog.ValueMember = "codice";
			this.cmbCofog.SelectedIndexChanged += new System.EventHandler(this.cmbCofog_SelectedIndexChanged);
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.Location = new System.Drawing.Point(24, 22);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(432, 13);
			this.label69.TabIndex = 44;
			this.label69.Text = "Dati necessari ai fini della compilazione della sezione ARCONET del tracciato OPI" +
	" SIOPE+";
			// 
			// grpCodUE
			// 
			this.grpCodUE.Controls.Add(this.rdbUE04);
			this.grpCodUE.Controls.Add(this.rdbUE03);
			this.grpCodUE.Controls.Add(this.rdbUE02);
			this.grpCodUE.Controls.Add(this.rdbUE01);
			this.grpCodUE.Location = new System.Drawing.Point(27, 99);
			this.grpCodUE.Name = "grpCodUE";
			this.grpCodUE.Size = new System.Drawing.Size(547, 120);
			this.grpCodUE.TabIndex = 39;
			this.grpCodUE.TabStop = false;
			this.grpCodUE.Text = "Codice Unione Europea";
			// 
			// rdbUE04
			// 
			this.rdbUE04.AutoSize = true;
			this.rdbUE04.Location = new System.Drawing.Point(28, 94);
			this.rdbUE04.Name = "rdbUE04";
			this.rdbUE04.Size = new System.Drawing.Size(173, 17);
			this.rdbUE04.TabIndex = 3;
			this.rdbUE04.TabStop = true;
			this.rdbUE04.Tag = "upb.uesiopecode:04";
			this.rdbUE04.Text = "ì04î Progetto Ricerca ExtraUE ";
			this.rdbUE04.UseVisualStyleBackColor = true;
			// 
			// rdbUE03
			// 
			this.rdbUE03.AutoSize = true;
			this.rdbUE03.Location = new System.Drawing.Point(28, 71);
			this.rdbUE03.Name = "rdbUE03";
			this.rdbUE03.Size = new System.Drawing.Size(146, 17);
			this.rdbUE03.TabIndex = 2;
			this.rdbUE03.TabStop = true;
			this.rdbUE03.Tag = "upb.uesiopecode:03";
			this.rdbUE03.Text = "ì03î Progetto Ricerca UE";
			this.rdbUE03.UseVisualStyleBackColor = true;
			// 
			// rdbUE02
			// 
			this.rdbUE02.AutoSize = true;
			this.rdbUE02.Location = new System.Drawing.Point(28, 48);
			this.rdbUE02.Name = "rdbUE02";
			this.rdbUE02.Size = new System.Drawing.Size(159, 17);
			this.rdbUE02.TabIndex = 1;
			this.rdbUE02.TabStop = true;
			this.rdbUE02.Tag = "upb.uesiopecode:02";
			this.rdbUE02.Text = "ì02î Progetto Ricerca privati";
			this.rdbUE02.UseVisualStyleBackColor = true;
			// 
			// rdbUE01
			// 
			this.rdbUE01.AutoSize = true;
			this.rdbUE01.Location = new System.Drawing.Point(28, 25);
			this.rdbUE01.Name = "rdbUE01";
			this.rdbUE01.Size = new System.Drawing.Size(154, 17);
			this.rdbUE01.TabIndex = 0;
			this.rdbUE01.TabStop = true;
			this.rdbUE01.Tag = "upb.uesiopecode:01";
			this.rdbUE01.Text = "ì01î Progetto Ricerca stato";
			this.rdbUE01.UseVisualStyleBackColor = true;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "");
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(326, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 553);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// upbBindingSource
			// 
			this.upbBindingSource.DataMember = "upb";
			this.upbBindingSource.DataSource = this.DS;
			// 
			// Frm_upb_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1004, 553);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.treeView1);
			this.Name = "Frm_upb_default";
			this.Text = "Frm_upb_default";
			this.MetaDataDetail.ResumeLayout(false);
			this.tabPrincipale.ResumeLayout(false);
			this.tabPrincipale.PerformLayout();
			this.gboxResponsabile.ResumeLayout(false);
			this.gboxResponsabile.PerformLayout();
			this.gboxUnderwriting.ResumeLayout(false);
			this.gboxUnderwriting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.Funzione.ResumeLayout(false);
			this.Funzione.PerformLayout();
			this.grpAttivita.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPrevisione.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgVariazioni)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPrevisione)).EndInit();
			this.tabBudget.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgBudgetVar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgBudget)).EndInit();
			this.tabClassificazione.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
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
			this.tabClassAutoSpese.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassExp)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoExp)).EndInit();
			this.tabClassAutoEntrate.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridFilterClassInc)).EndInit();
			this.groupBox7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridClassAutoInc)).EndInit();
			this.tabRiepilogo.ResumeLayout(false);
			this.grpRiepilogo.ResumeLayout(false);
			this.grpRiepilogo.PerformLayout();
			this.tabCtrl.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.grpPrevCassa_E.ResumeLayout(false);
			this.grpPrevCassa_E.PerformLayout();
			this.grpPrevCompetenza_E.ResumeLayout(false);
			this.grpPrevCompetenza_E.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.grpPrevCompetenza_S.ResumeLayout(false);
			this.grpPrevCompetenza_S.PerformLayout();
			this.grpPrevCassa_S.ResumeLayout(false);
			this.grpPrevCassa_S.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.grpCrediti.ResumeLayout(false);
			this.grpCrediti.PerformLayout();
			this.grpCassa.ResumeLayout(false);
			this.grpCassa.PerformLayout();
			this.tabBudgetRiep.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox11.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabAltro.ResumeLayout(false);
			this.tabAltro.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.groupBox9.PerformLayout();
			this.grpBlocca.ResumeLayout(false);
			this.grpBlocca.PerformLayout();
			this.grpDatiPrevisioneBudget.ResumeLayout(false);
			this.grpDatiPrevisioneBudget.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
			this.tabFabbisogno.ResumeLayout(false);
			this.tabFabbisogno.PerformLayout();
			this.grpCodUE.ResumeLayout(false);
			this.grpCodUE.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.upbBindingSource)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		bool AbilitaModificaSicurezzaUPB = false;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			calcFin = new CalcoliFinanziario(Meta, this);

			GetData.SetSorting(DS.upb, "printingorder");
			HelpForm.SetDenyNull(DS.upb.Columns["assured"], true);
			HelpForm.SetDenyNull(DS.upb.Columns["flagkind"], true);
			HelpForm.SetDenyNull(DS.upbyear.Columns["locked"], true);
			if (Meta.edit_type == "default") {
				GetData.SetStaticFilter(DS.upb, Meta.GetFilterForSearch(DS.upb));
				Meta.StartFilter = Meta.GetFilterForSearch(DS.upb);
			}
			string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.upbyear, filtereserc);
			GetData.SetStaticFilter(DS.upbyearview, filtereserc);
			string Filteraccountyearview = "(isnull(coalesce(prevision,prevision2,prevision3,prevision4,prevision5),0)<>0)";
			GetData.SetStaticFilter(DS.accountyearview, QHS.AppAnd(filtereserc, Filteraccountyearview));
			QueryCreator.SetTableForPosting(DS.accountyearview, "accountyear");
			GetData.SetStaticFilter(DS.accountvardetailview, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			GetData.SetSorting(DS.accountvardetailview, "nvar,rownum");

			string FilterFinyearview = "(isnull(prevision,0) <>0 or isnull(secondaryprev,0)<>0)";
			FilterFinyearview = QHS.AppAnd(FilterFinyearview, filtereserc);
			GetData.SetStaticFilter(DS.finyearview, FilterFinyearview);
			QueryCreator.SetTableForPosting(DS.finyearview, "finyear");
			GetData.SetStaticFilter(DS.finvardetailview, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			GetData.SetSorting(DS.finvardetailview, "nvar,rownum");



			GetData.SetStaticFilter(DS.sortingview, filtereserc);
			GetData.SetStaticFilter(DS.treasurer, QHS.CmpEq("active", 'S'));
			DataAccess.SetTableForReading(DS.sorting01, "sorting");
			DataAccess.SetTableForReading(DS.sorting02, "sorting");
			DataAccess.SetTableForReading(DS.sorting03, "sorting");
			DataAccess.SetTableForReading(DS.sorting04, "sorting");
			DataAccess.SetTableForReading(DS.sorting05, "sorting");
			DataAccess.SetTableForReading(DS.sorting, "sorting");
			DataAccess.SetTableForReading(DS.sortingkind, "sortingkind");

			DataAccess.SetTableForReading(DS.upb_dest, "upb");
			//string filterupb = QHS.CmpEq("idupb", ParentRow["idupb"]);
			string filter = QHS.AppAnd(QHS.IsNull("idfin"), QHS.IsNull("idman"), QHS.IsNull("idsorreg"), QHS.IsNull("idsorkindreg"));
			filter = QHS.AppAnd(filter, filtereserc);
			GetData.SetStaticFilter(DS.sortingincomefilter, filter);
			GetData.SetStaticFilter(DS.sortingexpensefilter, filter);
			GetData.SetStaticFilter(DS.autoexpensesorting, filter);
			GetData.SetStaticFilter(DS.autoincomesorting, filter);


			object UPBSec = Conn.GetUsr("UPBsecurity");
			if (UPBSec == null || UPBSec.ToString().ToUpper() == "'S'") {
				AbilitaModificaSicurezzaUPB = true;
			}
			SubEntity_chkBloccaCoFi.Enabled = AbilitaModificaSicurezzaUPB;
			SubEntity_chkBloccaCoGe.Enabled = AbilitaModificaSicurezzaUPB;
			chkBloccaCoFiMovimenti.Enabled = AbilitaModificaSicurezzaUPB;
			chkBloccaCoGeMovimenti.Enabled = AbilitaModificaSicurezzaUPB;


			PostData.SetPostingOrder(DS.finyearview, "idupb");
			PostData.SetPostingOrder(DS.accountyearview, "idupb");


			CalcolaEtichette();

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
					MetaDataDetail.TabPages.Remove(tabAttributi);
				}
			}
			PostData.MarkAsTemporaryTable(DS.codicecofogmp, false);
			//GetData.MarkToAddBlankRow(DS.codicecofogmp);
			EnableCodiceCofog(DBNull.Value, "");
            EnableCodiceCofog("04.8", "Ricerca scientifica e tecnologica applicata per gli affari economici (COFOG 04.8)");
            EnableCodiceCofog("01.4", "Ricerca scientifica e tecnologica di base (COFOG 01.4)");
            EnableCodiceCofog("07.5", "Ricerca scientifica e tecnologica applicata per la sanit‡ (COFOG 07.5)");

        }

		public void MetaData_AfterGetFormData() {
			// In questo modo la libreria riconosce come sub entit‡ di upb la tabella upbyear
			Meta.myHelpForm.addExtraEntity("upbyear");
		}
		void CalcolaEtichette() {
			object pagamento = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Conn.GetSys("maxexpensephase")), "description");
			object incasso = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Conn.GetSys("maxincomephase")), "description");
			object impegno = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Conn.GetSys("appropriationphase")), "description");
			object accertamento = Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Conn.GetSys("assessmentphase")), "description");

			if (pagamento != null) {
				lblPagamenti.Text = "Tot. fase " + pagamento.ToString().ToLower();
				lblPagamenti1.Text = "Tot. fase " + pagamento.ToString().ToLower();
				lblPrevDispCassa_S.Text = "Previsione Disponibile di cassa su " + pagamento.ToString().ToLower();
			} else {
				MessageBox.Show("Non Ë stata definita la fase di pagamento (ultima fase di spesa)", "Avviso");
			}
			if (incasso != null) {
				lblIncassi.Text = "Tot. fase " + incasso.ToString().ToLower();
				lblPrevDispCassa_E.Text = "Previsione Disponibile di cassa su " + incasso.ToString().ToLower();
			} else {
				MessageBox.Show("Non Ë stata definita la fase di incasso (ultima fase di entrata)", "Avviso");
			}

			if (impegno != null) {
				lblImpegni.Text = "Tot. fase " + impegno.ToString().ToLower() + " competenza";
				lblImpegniAll.Text = "Tot. fase " + impegno.ToString().ToLower();
				lblPrevDispCassaImpegni.Text = "Previsione Disponibile di cassa su " + impegno.ToString().ToLower();
			} else {
				MessageBox.Show("Non Ë stata definita la fase di impegno (prima fase di spesa)", "Avviso");
			}


			if (accertamento != null) {
				lblAccertamentiCompetenza.Text = "Tot. fase " + accertamento.ToString().ToLower() + " competenza";
				lblAccertamentiAll.Text = "Tot. fase " + accertamento.ToString().ToLower();
				lblPrevDispCassaAccertamenti.Text = "Previsione Disponibile di cassa su " + accertamento.ToString().ToLower();
			} else {
				MessageBox.Show("Non Ë stata definita la fase di accertamento (prima fase di entrata)", "Avviso");
			}

		}


		private Decimal CK(Object O) {
			if (O == DBNull.Value) return 0;
			return CfgFn.GetNoNullDecimal(O);
		}












		private void AbilitaBottoni(bool abilita) {

			btnAccertamentiCompetenza.Enabled = abilita;
			btnAssegnazioniCassa.Enabled = abilita;
			btnCreditiAssegnati.Enabled = abilita;
			btnDelPrevisione.Enabled = abilita;
			btnDotazioneCassa.Enabled = abilita;
			btnDotazioneCrediti.Enabled = abilita;
			btnIncassi.Enabled = abilita;
			btnPagamenti.Enabled = abilita;
			btnPrevInizialeCassa_S.Enabled = abilita;
			btnPrevInizialeCompetenza_E.Enabled = abilita;
			btnVarPrevCompetenza_E.Enabled = abilita;
			btnVarPrevisioneCassa_S.Enabled = abilita;
			btnPiccoleSpeseImp.Enabled = abilita; ;
			btnPiccoleSpesePagamenti.Enabled = abilita;
			btnPiccoleSpesePagamenti1.Enabled = abilita;
			btnCalcolaTutto.Enabled = abilita;



			btnPrevInizialeCompetenza_S.Enabled = abilita;
			btnVarPrevCompetenza_S.Enabled = abilita;
			btnImpegni.Enabled = abilita;
			btnPagamenti1.Enabled = abilita;
			btnCalcolaTutto.Enabled = abilita;

			btnPrevInizialeCassa_E.Enabled = abilita;
			btnVarPrevCassa_E.Enabled = abilita;
			btnIncassi.Enabled = abilita;

			btnPrevInizialeCompetenza_S.Enabled = abilita;
			btnVarPrevCompetenza_S.Enabled = abilita;
			btnImpegni.Enabled = abilita;

			btnVarDotazioneCassa.Enabled = abilita;
			btnVarDotazioneCrediti.Enabled = abilita;

		}

		void VisualizzaInTabCassaSolo(Control Gbox, string pattern) {
			foreach (Control C in Gbox.Controls) {
				if (C.Name.ToLower().Contains(pattern))
					C.Visible = true;
				else
					C.Visible = false;
			}
		}


		private void AbilitaSezioniRiepilogo() {
			grpPrevCompetenza_E.Enabled = true;
			if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 1) {
				VisualizzaInTabCassaSolo(grpPrevCassa_E, "incassi"); //competenza
				VisualizzaInTabCassaSolo(grpPrevCassa_S, "pagamenti");
			}
			if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
				grpPrevCompetenza_E.Visible = false;
				grpPrevCompetenza_S.Visible = false;
			}
			if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 3) {
				//comp e cassa: visualizza tutto
			}
			object flagcredit = Conn.GetSys("flagcredit");
			if (flagcredit == null) flagcredit = "N";

			object flagproceeds = Conn.GetSys("flagproceeds");
			if (flagproceeds == null) flagproceeds = "N";


			if (flagcredit == null || flagproceeds == null) {
				flagcredit = "N";
				flagproceeds = "N";
				MessageBox.Show("Manca la configurazione annuale dell'esercizio");
			}
			if (flagcredit.ToString().ToUpper() == "S")
				grpCrediti.Visible = true;
			else
				grpCrediti.Visible = false;

			if (flagproceeds.ToString().ToUpper() == "S")
				grpCassa.Visible = true;
			else
				grpCassa.Visible = false;

		}


		private decimal TotPiccoleSpeseImp() {
			// Vanno considerate le p.spese non reintegrate e NON associate ad un impegno
			decimal valore;
			string FilterPO = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			FilterPO = QHS.CmpEq("PO.yoperation", esercizioCurr);
			FilterPO = QHS.AppAnd(FilterPO, QHS.CmpLe("PO.adate", Meta.GetSys("datacontabile")));
			FilterPO = QHS.AppAnd(FilterPO, QHS.CmpEq("PO.idupb", Curr["idupb"]));
			string FilterRestoreop = "";
			FilterRestoreop = QHS.CmpLe("restoreop.adate", Meta.GetSys("datacontabile"));

			string sql = " SELECT SUM(PO.amount) as amount" +
			 " FROM pettycashoperation PO " +
			 " WHERE" + FilterPO +
			 " AND NOT EXISTS " +
				 " (SELECT * FROM pettycashoperation restoreop " +
				 " WHERE restoreop.yrestore = PO.yrestore " +
				 " AND restoreop.nrestore = PO.nrestore " +
				 " AND restoreop.idpettycash = PO.idpettycash " +
				 " AND " + FilterRestoreop + " )" +
			" AND NOT EXISTS " +
				" (SELECT * FROM pettycashexpense mov " +
				" WHERE mov.yoperation = PO.yoperation " +
					" AND mov.noperation = PO.noperation " +
					" AND mov.idpettycash = PO.idpettycash) ";

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);
			return valore;
		}

		private decimal TotPiccoleSpesePag() {
			// Vanno considerate le p.spese non reintegrate, senza considerare l'associazione ad un impegno
			decimal valore;
			string FilterPO = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			FilterPO = QHS.CmpEq("PO.yoperation", esercizioCurr);
			FilterPO = QHS.AppAnd(FilterPO, QHS.CmpLe("PO.adate", Meta.GetSys("datacontabile")));
			FilterPO = QHS.AppAnd(FilterPO, QHS.CmpEq("PO.idupb", Curr["idupb"]));
			string FilterRestoreop = "";
			FilterRestoreop = QHS.CmpLe("restoreop.adate", Meta.GetSys("datacontabile"));

			string sql = " SELECT SUM(PO.amount) as amount" +
			 " FROM pettycashoperation PO " +
			 " WHERE" + FilterPO +
			 " AND NOT EXISTS " +
				 " (SELECT * FROM pettycashoperation restoreop " +
				 " WHERE restoreop.yrestore = PO.yrestore " +
				 " AND restoreop.nrestore = PO.nrestore " +
				 " AND restoreop.idpettycash = PO.idpettycash " +
				 " AND " + FilterRestoreop + " )";

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);
			return valore;
		}


		private void pulisciTextRiepilogo() {
			txtPrevInizialeCompetenza_E.Text = "";
			txtPrevInizialeCompetenza_S.Text = "";
			txtVarPrevCompetenza_E.Text = "";
			txtVarPrevCompetenza_S.Text = "";
			txtImpegniCompetenza.Text = "";
			txtPrevDispCompetenza_E.Text = "";
			txtPrevDispCompetenza_S.Text = "";
			txtPrevInizialeCassa_E.Text = "";
			txtPrevInizialeCassa_S.Text = "";
			txtVarPrevCassa_E.Text = "";
			txtVarPrevisioneCassa_S.Text = "";
			txtPagamenti.Text = "";
			txtPagamenti1.Text = "";
			txtPrevDispCassa_E.Text = "";
			txtPrevDispCassa_S.Text = "";
			txtDotazioneCrediti.Text = "";
			txtCreditiAssegnati.Text = "";
			txtCreditiResidui.Text = "";
			txtDotazioneCassa.Text = "";
			txtVarDotazioneCrediti.Text = "";
			txtVarDotazioneCassa.Text = "";
			txtAssegnazioniCassa.Text = "";
			txtCassaResidua.Text = "";
			txtAccertamentiCompetenza.Text = "";
			txtIncassi.Text = "";
			txtPiccoleSpeseImp.Text = "";
			txtPiccoleSpesePagamenti.Text = "";
			txtPiccoleSpesePagamenti1.Text = "";

			txtBudgetInizialeAcc.Text = "";
			txtVarBudgetAcc.Text = "";
			txtAccertamentiBudget.Text = "";
			txtPreaccertamentiBudget.Text = "";
			txtBudgetdisponibilePreaccertmenti.Text = "";
			txtVarAccertamentiBudget.Text = "";
			txtVarPreaccertamenti.Text = "";

			txtBudgetInizialeImp.Text = "";
			txtVarBudgetImp.Text = "";
			txtImpegniBudget.Text = "";
			txtPreimpegniBudget.Text = "";
			txtBudgetdisponibilePreimpegni.Text = "";
			txtVarImpegniBudget.Text = "";
			txtVarPreimpegni.Text = "";

			txtTotaleCassa.Text = "";
			txtTotaleCrediti.Text = "";
			txtPrevAttualeCompetenzaE.Text = "";
			txtPrevAttualeCompetenzaS.Text = "";
			txtPrevAttualeCassaE.Text = "";
			txtPrevAttualeCassaS.Text = "";

			//MODIFICHE TASK 10134 -Alex 
			//Avendo aggiunti nuovi textbox nel tab Riepilogo -> E/P Ë necessario che questi vengano puliti...
			txtFondoAccantonamentoAvere.Text = "";
			txtRiservaAvere.Text = "";
			txtRiscontiPassiviAvere.Text = "";
			txtRiscontiAttiviAvere.Text = "";
			txtRateiPassiviAvere.Text = "";
			txtRateiAttiviAvere.Text = "";
			txtContiCreditoAvere.Text = "";
			txtContiDebitoAvere.Text = "";
			txtRicaviAvere.Text = "";
			txtImmobilizzazioniAvere.Text = "";
			txtCostiAvere.Text = "";

			txtFondoAccantonamentoDare.Text = "";
			txtRiservaDare.Text = "";
			txtRiscontiPassiviDare.Text = "";
			txtRiscontiAttiviDare.Text = "";
			txtRateiPassiviDare.Text = "";
			txtRateiAttiviDare.Text = "";
			txtContiCreditoDare.Text = "";
			txtContiDebitoDare.Text = "";
			txtRicaviDare.Text = "";
			txtImmobilizzazioniDare.Text = "";
			txtCostiDare.Text = "";

			txtFondoAccantonamentoDifferenza.Text = "";
			txtRiservaDifferenza.Text = "";
			txtRiscontiPassiviDifferenza.Text = "";
			txtRiscontiAttiviDifferenza.Text = "";
			txtRateiAttiviDifferenza.Text = "";
			txtContiDebitoDifferenza.Text = "";
			txtContiCreditoDifferenza.Text = "";
			txtImmobilizzazioniDifferenza.Text = "";
			txtRateiPassiviDifferenza.Text = "";
			txtRicaviDifferenza.Text = "";
			txtCostiDifferenza.Text = "";


			//MODIFICHE TASK 10657
			txtDisponibilit‡liquideDifferenza.Text = "";
			txtDisponibilit‡liquideDare.Text = "";
			txtDisponibilit‡liquideAvere.Text = "";
			txtAltrevociAttivoDifferenza.Text = "";
			txtAltrevociAttivoDare.Text = "";
			txtAltrevociAttivoAvere.Text = "";
			txtFondiAmmortamentoDifferenza.Text = "";
			txtFondiAmmortamentoDare.Text = "";
			txtFondiAmmortamentoAvere.Text = "";
			txtAltrevociPassivoDifferenza.Text = "";
			txtAltrevociPassivoDare.Text = "";
			txtAltrevociPassivoAvere.Text = "";





		}

		private void SelezionaMovimento(DataRow MyDR, string entrata_spesa) {

			if (entrata_spesa == "E") {
				MetaData newEntrata = Meta.Dispatcher.Get("income");
				newEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
					QHS.CmpEq("idinc", MyDR["idinc"]), "income", null);
				if (R2 != null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
			}
			if (entrata_spesa == "S") {
				MetaData newSpesa = Meta.Dispatcher.Get("expense");
				newSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
					QHS.CmpEq("idexp", MyDR["idexp"]), "expense", null);
				if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
			}
		}

		private void SelezionaPrevisione(DataRow MyDR) {
			MetaData newFinyearView = Meta.Dispatcher.Get("finyearview");
			newFinyearView.ExtraParameter = MyDR["idfin"];
			newFinyearView.Edit(this.ParentForm, "default", false);
			DataRow R2 = newFinyearView.SelectOne(newFinyearView.DefaultListType,
				 QHS.AppAnd(QHS.CmpEq("idfin", MyDR["idfin"]),
							   QHS.CmpEq("idupb", MyDR["idupb"])), "finyearview", null);
			if (R2 != null) newFinyearView.SelectRow(R2, newFinyearView.DefaultListType);
		}
		private void SelezionaBudget(DataRow MyDR) {
			MetaData newAccyearView = Meta.Dispatcher.Get("accountyearview");
			newAccyearView.ExtraParameter = MyDR["idacc"];
			newAccyearView.Edit(this.ParentForm, "default", false);
			DataRow R2 = newAccyearView.SelectOne(newAccyearView.DefaultListType,
				 QHS.AppAnd(QHS.CmpEq("idacc", MyDR["idacc"]),
							   QHS.CmpEq("idupb", MyDR["idupb"])), "accountyearview", null);
			if (R2 != null)
				newAccyearView.SelectRow(R2, newAccyearView.DefaultListType);
		}


		private void SelezionaAssegnazione(DataRow MyDR, string credit_proceeds) {

			if (credit_proceeds == "C") {
				MetaData newCreditPart = Meta.Dispatcher.Get("creditpart");
				newCreditPart.Edit(this.ParentForm, "default", false);
				DataRow R2 = newCreditPart.SelectOne("lista",
					QHS.AppAnd(QHS.CmpEq("ycreditpart", MyDR["ycreditpart"]),
							   QHS.CmpEq("ncreditpart", MyDR["ncreditpart"])), "creditpart", null);
				if (R2 != null) newCreditPart.SelectRow(R2, "lista");
			}
			if (credit_proceeds == "P") {
				MetaData newProceedsPart = Meta.Dispatcher.Get("proceedspart");
				newProceedsPart.Edit(this.ParentForm, "default", false);
				DataRow R2 = newProceedsPart.SelectOne("lista",
							 QHS.AppAnd(QHS.CmpEq("yproceedspart", MyDR["yproceedspart"]),
							   QHS.CmpEq("nproceedspart", MyDR["nproceedspart"])), "proceedspart", null);
				if (R2 != null) newProceedsPart.SelectRow(R2, "lista");
			}
		}

		private void SelezionaVariazione(DataRow MyDR) {
			MetaData newFinVarDetail = Meta.Dispatcher.Get("finvardetail");

			newFinVarDetail.Edit(this.ParentForm, "default", false);
			DataRow R2 = newFinVarDetail.SelectOne("lista",
				QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
				QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
				"finvardetail", null);
			if (R2 != null) newFinVarDetail.SelectRow(R2, "lista");
		}

		/// <summary>
		/// Metodo esclude i campi della vista FINYEARVIEW non appartenenti alla tabella FINYEAR in fase di salvataggio
		/// e li reinclude dopo aver salvato
		/// </summary>
		/// <param name="salva">TRUE: Campi salvabili; FALSE: Campi non salvabili</param>
		private void impostaCampiDaSalvare(bool salva) {
			string []field_finyearview = new string[]{"finance","codefin","paridfin","upb","codeupb","paridupb","flag",
										"finpart","nlevel","leveldescr"};
			string []field_accountyearview = new string[]{"account","codeacc","paridacc","upb","codeupb","paridupb","nlevel","leveldescr"};

			if (!salva) {
				string empty = "";
				foreach (string field in field_finyearview) {
					QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field], empty);
				}
				foreach (string field in field_accountyearview) {
					QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], empty);
				}
			} else {
				foreach (string field in field_finyearview) {
					QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field], field);
				}
				foreach (string field in field_accountyearview) {
					QueryCreator.SetColumnNameForPosting(DS.accountyearview.Columns[field], field);
				}


			}
		}

		public void MetaData_BeforePost() {
			impostaCampiDaSalvare(false);
		}

		public void MetaData_AfterPost() {
			impostaCampiDaSalvare(true);

			DataRow rUpb = HelpForm.GetLastSelected(DS.upb);
			if (rUpb == null) return;
			object idupb = rUpb["idupb"];
			string filter = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),QHS.CmpEq("idupb", idupb));

			string FilterFinyearview = "(isnull(prevision,0) <>0 or isnull(secondaryprev,0)<>0)";
			string filterfinyear = QHS.AppAnd(FilterFinyearview, filter);
			Conn.RUN_SELECT_INTO_TABLE(DS.finyearview, null, filterfinyear, null, true);

			string Filteraccountyearview = "(isnull(coalesce(prevision,prevision2,prevision3,prevision4,prevision5),0)<>0)";
			string filteraccountyear = QHS.AppAnd(Filteraccountyearview, filter);
			Conn.RUN_SELECT_INTO_TABLE(DS.accountyearview, null, filteraccountyear, null, true);

			Meta.FreshForm();
		}




		object GetCtrlByName(string Name) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl == null) return null;
			//if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			//Label L =  (Label) Ctrl.GetValue(this);                        
			//return L;
			return Ctrl.GetValue(this);
		}


		public void MetaData_AfterActivation() {
			if (treeView1.Nodes.Count > 0) {
				if (!treeView1.Nodes[0].IsExpanded) {
					treeView1.Nodes[0].Expand();

					if (treeView1.Nodes[0].Nodes.Count > 0) {
						treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];
					}
				}
			}
			CalcolaDefaultPerIstitutoCassiere();
		}

		void CalcolaDefaultPerIstitutoCassiere() {
			DataRow[] cassiere = DS.treasurer.Select("flagdefault='S'");
			if (cassiere.Length == 1) {
				MetaData.SetDefault(DS.upb, "idtreasurer", cassiere[0]["idtreasurer"]);
				return;
			}
			if (DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0)).Length == 1) {
				object codiceistituto = DS.treasurer.Select(QHC.CmpNe("idtreasurer", 0))[0]["idtreasurer"];
				MetaData.SetDefault(DS.upb, "idtreasurer", codiceistituto);
			}

		}



		public void MetaData_BeforeFill() {
			if (HelpForm.GetLastSelected(DS.upb) == null)
				Meta.CanInsert = false;
			else
				Meta.CanInsert = true;

			DataRow drUpb = HelpForm.GetLastSelected(DS.upb);
			if (drUpb != null) {
				calcFin.Enabled = true;
				calcFin.SetMask(DBNull.Value, drUpb["idupb"], DBNull.Value);
			}
			if (Meta.InsertMode) {
				CreateUpbYearRow();
				btnInsDettagli.Visible = false;
			}
			if (DS.upbyear.Rows.Count > 0) {
				btnInsDettagli.Visible = false;
			} else {
				btnInsDettagli.Visible = true;
			}

		}
		public void MetaData_AfterFill() {
			btnSituazioneAnnuale.Enabled = !Meta.InsertMode;
			btnSituazionePluriennale.Enabled = !Meta.InsertMode;
			btnBilPrevisione.Enabled = !Meta.InsertMode;
			impostaCampiReadonly(false);

			if (Meta.InsertMode) {
				AbilitaBottoni(false);
			} else {
				AbilitaBottoni(true);

			}
			AbilitaSezioniRiepilogo();
			AbilitaDatiPrevisionediBudget();
		}

		private void impostaCampiReadonly(bool abilita) {
			DS.finyearview.Columns["finpart"].ReadOnly = abilita;
		}

		private void AbilitaDatiPrevisionediBudget() {
			if (Meta.IsEmpty) {
				grpDatiPrevisioneBudget.Visible = true;
				grpBlocca.Visible = false;
				SubEntity_txtCostiPresunti.Text = "";
				SubEntity_txtRicaviPresunti.Text = "";
				return;
			}
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			string filtro = QHC.AppAnd(QHC.CmpEq("idupb", Curr["idupb"]),
				QHC.CmpEq("ayear", Meta.GetSys("esercizio")));

			DataRow[] r = DS.upbyear.Select(filtro);
			if (r.Length == 0) {
				grpDatiPrevisioneBudget.Visible = false;
				grpBlocca.Visible = false;
				SubEntity_txtCostiPresunti.Text = "";
				SubEntity_txtRicaviPresunti.Text = "";
				return;
			} else {
				grpDatiPrevisioneBudget.Visible = true;
				grpBlocca.Visible = true;
				if (Meta.DrawStateIsDone) {
					if (!Meta.IsEmpty) {
						// DS.upbyear.Rows[0]["idintrastatservice"] = DBNull.Value;
						// txtCostiPresunti.Text = "";
						// txtRicaviPresunti.Text = "";
					}
				}
			}

		}

		public void MetaData_AfterClear() {
			btnSituazioneAnnuale.Enabled = false;
			btnSituazionePluriennale.Enabled = false;
			btnBilPrevisione.Enabled = false;
			//AbilitaBtnPrevisione(false);
			calcFin.Enabled = false;

			if (HelpForm.GetLastSelected(DS.upb) == null)
				Meta.CanInsert = false;
			else
				Meta.CanInsert = true;

			pulisciTextRiepilogo();
			AbilitaBottoni(false);
			btnInsDettagli.Visible = false;
			AbilitaDatiPrevisionediBudget();
			HelpForm.SetComboBoxValue(cmbCofog, DBNull.Value);
		}

		//void AbilitaBtnPrevisione(bool enable){
		//    btnInsPrevisione.Enabled = enable;
		//    btnEditPrevisione.Enabled = enable;
		//    btnDelPrevisione.Enabled = enable;
		//}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName != "upb") return;
			if (R != null) {
				calcFin.Enabled = true;
				calcFin.SetMask(DBNull.Value, R["idupb"], DBNull.Value);
			} else {
				calcFin.Enabled = false;
			}
			pulisciTextRiepilogo();
			bool ModoInsert = Meta.InsertMode;
			btnSituazioneAnnuale.Enabled = !ModoInsert;
			btnSituazionePluriennale.Enabled = !ModoInsert;
			btnBilPrevisione.Enabled = !ModoInsert;
			if (R != null && R.RowState != DataRowState.Detached) {
				MetaData.SetDefault(T, "idman", R["idman"]);
				MetaData.SetDefault(DS.autoexpensesorting, "idupb", R["idupb"]);
				MetaData.SetDefault(DS.autoincomesorting, "idupb", R["idupb"]);
				MetaData.SetDefault(DS.sortingexpensefilter, "idupb", R["idupb"]);
				MetaData.SetDefault(DS.sortingincomefilter, "idupb", R["idupb"]);
				MetaData.SetDefault(DS.accountyearview, "idupb", R["idupb"]);
			}



		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			TreeNode TN = e.Node;
			if (TN.Tag != null) return;
		}

		private void btnSituazioneAnnuale_Click(object sender, System.EventArgs e) {
			DataRow rUpb = HelpForm.GetLastSelected(DS.upb);
			if (rUpb == null) return;
			string idUpb = rUpb["idupb"].ToString();

			DataSet Out = Meta.Conn.CallSP("show_upbannual",
				new Object[2] {Meta.GetSys("datacontabile"),
								  idUpb
							  }
				);
			if (Out == null) return;
			Out.Tables[0].TableName = "Situazione Annuale U.P.B.";

			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

		private void btnSituazionePluriennale_Click(object sender, System.EventArgs e) {
			DataRow rUpb = HelpForm.GetLastSelected(DS.upb);
			if (rUpb == null) return;
			string idUpb = rUpb["idupb"].ToString();

			DataSet Out = Meta.Conn.CallSP("show_upbmultiannual",
				new Object[2] {Meta.GetSys("datacontabile"),
								  idUpb
							  }
				);
			if (Out == null) return;
			Out.Tables[0].TableName = "Situazione Pluriennale U.P.B.";

			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

		private void btnBilPrevisione_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null) return;

			string idUpb = upbRow["idupb"].ToString();
			DS.finview.ExtendedProperties[MetaData.ExtraParams] = idUpb;
			Meta.Dispatcher.Edit(this.ParentForm, "finview", "upbprevision", false, idUpb);
		}

		private void chbFinCerto_Click(object sender, System.EventArgs e) {
			if (!Meta.IsEmpty) {
				if (((CheckBox)sender).CheckState == CheckState.Indeterminate)
					((CheckBox)sender).CheckState = CheckState.Unchecked;
			}
		}

		private void chbUpbAttivo_Click(object sender, System.EventArgs e) {
			if (!Meta.IsEmpty) {
				if (((CheckBox)sender).CheckState == CheckState.Indeterminate)
					((CheckBox)sender).CheckState = CheckState.Unchecked;
			}
		}

		private void btnPrevInizialeCompetenza_E_Click(object sender, EventArgs e) {
			VisualizzaPrevIniziale("P", "E");
		}

		/// <summary>
		/// VIsualizza la previsione principale (kind=P) o secondaria 
		/// </summary>
		/// <param name="kind"></param>
		/// <param name="finpart"></param>
		private void VisualizzaPrevIniziale(string kind, string finpart) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			if (kind == "P") {
				calcFin.ElencaPrevisioneInizialeCompetenza(finpart);
			} else {
				calcFin.ElencaPrevInizialeCassa(finpart);
			}

		}

		private void VisualizzaBudgetIniziale(string kind) {
			string Filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null)
				return;
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("accountusablelevel"));

			Filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("nlevel", levelop));
			if (kind == "I") {
				//Costi : flagaccountusage : bit 6(&64 Costi), bit 8(&256 Immobilizzazioni), bit 12(&4096 Accantonamento)
				Filter = QHS.AppAnd(Filter, QHS.DoPar(QHS.AppOr(QHS.BitSet("flagaccountusage", 6), QHS.BitSet("flagaccountusage", 8), QHS.BitSet("flagaccountusage", 12))));
			} else {
				//Ricavi : flagaccountusage : bit 7 ( &128 Ricavo)
				Filter = QHS.AppAnd(Filter, QHS.BitSet("flagaccountusage", 7));
			}
			//Previsione iniziale (principale)
			Filter = QHS.AppAnd(Filter, QHS.CmpNe("prevision", 0));

			VistaScelta = "accountyearview";
			MetaData MAccyearView = MetaData.GetMetaData(this, VistaScelta);
			MAccyearView.FilterLocked = true;
			MAccyearView.DS = DS;

			DataRow MyDR = MAccyearView.SelectOne("default", Filter, null, null);

			if (MyDR != null) {
				SelezionaBudget(MyDR);
			}
		}

		private void btnVarPrevCompetenza_E_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagprevision", "E");
		}



		private void btnPrevInizialeCassa_Click(object sender, EventArgs e) {
			VisualizzaPrevIniziale("S", "E");
		}

		private void btnAccertamentiCompetenza_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;

			calcFin.ElencaAccertamentiCompetenza();
		}

		private void btnVarPrevisioneCassa_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagsecondaryprev", null);
		}

		private void btnPagamenti_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencoPagamenti();
		}

		private void btnIncassi_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;

			calcFin.ElencaIncassi();
		}



		private void VisualizzaFinvarDetail(string flag, string kind) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;

			// il parametro flag indica se previsione o dotazione crediti/cassa
			// flagprevision, flagsecondaryprev, flagcredit, flagproceeds
			if (flag == "flagprevision") {
				calcFin.ElencaVariazionePrevCompetenza(kind);
				return;
			}
			if (flag == "flagsecondaryprev") {
				calcFin.ElencaVarPrevisioneCassa(kind);
				return;
			}

			if (flag == "flagcredit") {
				if (kind == "var") {
					calcFin.ElencaVarNormaleCrediti();
				} else {
					calcFin.ElencaVarRipartizioneCrediti();
				}
			}
			if (flag == "flagproceeds") {
				if (kind == "var") {
					calcFin.ElencaVarNormaleCassa();
				} else {
					calcFin.ElencaVarRipartizioneCassa();
				}
			}

		}

		private void btnVarDotazioneCrediti_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagcredit", "var");
		}

		private void btnVarDotazioneCassa_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagproceeds", "var");
		}

		private void btnPrevInizialeCassa_E_Click(object sender, EventArgs e) {
			VisualizzaPrevIniziale("S", "E");
		}

		private void btnVarPrevCassa_E_Click(object sender, EventArgs e) {
			if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
				VisualizzaFinvarDetail("flagprevision", "E");
			} else {
				VisualizzaFinvarDetail("flagsecondaryprev", "E");
			}
		}

		private void btnPrevInizialeCompetenza_S_Click(object sender, EventArgs e) {
			VisualizzaPrevIniziale("P", "S");
		}

		private void btnVarPrevCompetenza_S_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagprevision", "S");
		}

		private void btnPrevInizialeCassa_S_Click(object sender, EventArgs e) {
			VisualizzaPrevIniziale("S", "S");
		}

		private void btnVarPrevisioneCassa_S_Click(object sender, EventArgs e) {
			if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
				VisualizzaFinvarDetail("flagprevision", "S");
			} else {
				VisualizzaFinvarDetail("flagsecondaryprev", "S");
			}
		}

		private void btnDotazioneCrediti_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagcredit", "init");
		}




		private void btnCreditiAssegnati_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaAssegnazioniCrediti();
		}

		private void btnDotazioneCassa_Click(object sender, EventArgs e) {
			VisualizzaFinvarDetail("flagproceeds", "init");
		}

		private void btnAssegnazioniCassa_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaAssegnazioniIncassi();

		}

		private void btnImpegni_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaImpegniCompetenza();
		}


		private void btnPiccoleSpeseImp_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaPiccoleSpeseImp();

		}

		private void btnPiccoleSpesePagamenti_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaPiccoleSpesePag();

		}

		private void btnPiccoleSpesePagamenti1_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaPiccoleSpesePag();
		}

		private void dGridClassAutoInc_Navigate(object sender, NavigateEventArgs ne) {

		}



		private void CalcolaTotaliEntrate() {
			decimal totPrevIniComp = calcFin.TotPrevInizialeCompetenza("E");
			txtPrevInizialeCompetenza_E.Text = totPrevIniComp.ToString("C");
			decimal totvarComp = calcFin.TotVarPrevCompetenza("E");
			txtVarPrevCompetenza_E.Text = totvarComp.ToString("C");

			decimal totPrevIniCassa = calcFin.TotPrevInizialeCassa("E");
			txtPrevInizialeCassa_E.Text = totPrevIniCassa.ToString("C");
			decimal totvarCassa = calcFin.TotVarPrevCassa("E");
			txtVarPrevCassa_E.Text = totvarCassa.ToString("C");

			decimal totAccertamenti = calcFin.TotAccertamentiCompetenza();
			txtAccertamentiCompetenza.Text = totAccertamenti.ToString("C");
			decimal totAccertamentiAll = calcFin.TotAccertamentiAll();
			txtAccertamentiAll.Text = totAccertamentiAll.ToString("C");

			decimal totIncassi = calcFin.TotIncassi();
			txtIncassi.Text = totIncassi.ToString("C");

			decimal totCompetenza = totPrevIniComp + totvarComp;
			txtPrevAttualeCompetenzaE.Text = totCompetenza.ToString("C");

			decimal totCassa = totPrevIniCassa + totvarCassa;
			txtPrevAttualeCassaE.Text = totCassa.ToString("C");


			txtPrevDispCompetenza_E.Text = (totCompetenza - totAccertamenti).ToString("C");

			txtPrevDispCassaPerAccertamenti.Text = (totCassa - totAccertamentiAll).ToString("C");
			txtPrevDispCassa_E.Text = (totCassa - totIncassi).ToString("C");


		}

		private bool checkPercentuale(object sender, EventArgs e) {
			bool OK = false;
			TextBox T = (TextBox)sender;
			try {
				decimal percent = Decimal.Parse(T.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0) || (percent > 100)) {
					OK = false;
				}
				OK = true;
			} catch {
				MessageBox.Show("E' necessario digitare un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}




		/// <summary>
		/// Svuota la tabella DS.tipomovimento, a cui Ë agganciato il combo causale
		/// </summary>
		void ClearComboCodiciCofog() {
			DataTable TCombo = DS.codicecofogmp;
			TCombo.Clear();
		}

		void EnableCodiceCofog(object codice, string descr) {
			DataRow R = DS.codicecofogmp.NewRow();
			R["codice"] = codice;
			R["descrizione"] = descr;
			DS.codicecofogmp.Rows.Add(R);
			DS.codicecofogmp.AcceptChanges();
		}


		//private void   AzzeraCofogMp_Check(object sender, EventArgs e) {
		//	DataRow Curr = HelpForm.GetLastSelected(DS.upb);
		//	if (Meta.IsEmpty) return;
		//	if (Curr == null) return;
		//	if (rdbAzzeraCofogMp.Checked) {
		//		Curr["uesiopecode"] = DBNull.Value;
		//		rdbUE01.Checked = false;
		//		rdbUE02.Checked = false;
		//		rdbUE03.Checked = false;
		//		rdbUE04.Checked = false;

		//		rdbUE01.Checked = false;
		//		rdbUE02.Checked = false;
		//		rdbUE03.Checked = false;
		//		rdbUE04.Checked = false;
		//		grpCodUE.Enabled = false;
		//	} else {
		//		grpCodUE.Enabled = true;
		//	}
		//}


		private void CalcolaTotaliSpese() {
			decimal prevInizialeComp = calcFin.TotPrevInizialeCompetenza("S");
			txtPrevInizialeCompetenza_S.Text = prevInizialeComp.ToString("C");
			decimal varCompetenza = calcFin.TotVarPrevCompetenza("S");
			txtVarPrevCompetenza_S.Text = varCompetenza.ToString("C");

			decimal totCompetenza = prevInizialeComp + varCompetenza;
			txtPrevAttualeCompetenzaS.Text = totCompetenza.ToString("C");

			decimal totImpegni = calcFin.TotImpegniCompetenza();
			txtImpegniCompetenza.Text = totImpegni.ToString("C");
			decimal totImpegniAll = calcFin.TotImpegniAll();
			txtImpegniAll.Text = totImpegniAll.ToString("C");

			decimal totPiccoleSpeseImp = calcFin.TotPiccoleSpeseImp();
			txtPiccoleSpeseImp.Text = totPiccoleSpeseImp.ToString("C");

			txtPrevDispCompetenza_S.Text = (totCompetenza - totImpegni - totPiccoleSpeseImp).ToString("C");

			decimal prevInizialeCassa = calcFin.TotPrevInizialeCassa("S");
			txtPrevInizialeCassa_S.Text = prevInizialeCassa.ToString("C");

			decimal varPrevCassa = calcFin.TotVarPrevCassa("S");
			txtVarPrevisioneCassa_S.Text = varPrevCassa.ToString("C");

			decimal totCassa = prevInizialeCassa + varPrevCassa;
			txtPrevAttualeCassaS.Text = totCassa.ToString("C");

			decimal pagamenti = calcFin.TotPagamenti();
			txtPagamenti.Text = pagamenti.ToString("C");
			txtPagamenti1.Text = pagamenti.ToString("C");

			decimal pspesepagamenti = calcFin.TotPiccoleSpesePag();
			txtPiccoleSpesePagamenti.Text = pspesepagamenti.ToString("C");
			txtPiccoleSpesePagamenti1.Text = pspesepagamenti.ToString("C");
			txtPrevDispCassaPerImpegni.Text = (totCassa - totImpegniAll - pspesepagamenti).ToString("C");
			txtPrevDispCassa_S.Text = (totCassa - pagamenti - pspesepagamenti).ToString("C");

			decimal creditiiniziale = calcFin.TotVarRipartizioneCrediti();
			txtDotazioneCrediti.Text = creditiiniziale.ToString("C");
			decimal varcrediti = calcFin.TotVarNormaleCrediti();
			txtVarDotazioneCrediti.Text = varcrediti.ToString("C");

			decimal totasscrediti = calcFin.TotAssegnazioniCrediti();
			txtCreditiAssegnati.Text = totasscrediti.ToString("C");

			decimal totcrediti = creditiiniziale + varcrediti + totasscrediti;
			txtTotaleCrediti.Text = totcrediti.ToString("C");

			txtCreditiResidui.Text = (totcrediti - totImpegni - totPiccoleSpeseImp).ToString("C");

			decimal DotcassaIniziale = calcFin.TotVarRipartizioneCassa();
			txtDotazioneCassa.Text = DotcassaIniziale.ToString("C");

			decimal totvarDotCassa = calcFin.TotVarNormaleCassa();
			txtVarDotazioneCassa.Text = totvarDotCassa.ToString("C");

			decimal totAssCassa = calcFin.TotAssegnazioniIncassi();
			txtAssegnazioniCassa.Text = totAssCassa.ToString("C");

			decimal totDotCassa = DotcassaIniziale + totvarDotCassa + totAssCassa;
			txtTotaleCassa.Text = totDotCassa.ToString("C");

			txtCassaResidua.Text = (totDotCassa - pagamenti - pspesepagamenti).ToString("C");


		}

		private void CalcolaTotaliBudget() {
			decimal budgetIni = BudgetIniziale("I");
			txtBudgetInizialeImp.Text = budgetIni.ToString("c");
			decimal varBudget = VarBudget("I");
			txtVarBudgetImp.Text = varBudget.ToString("c");
			decimal preImp = PreimpegniBudget();
			txtPreimpegniBudget.Text = preImp.ToString("c");
			decimal varPreImp = VariazioniPreimpegniBudget();
			txtVarPreimpegni.Text = varPreImp.ToString("c");
			txtImpegniBudget.Text = ImpegniBudget().ToString("c");
			txtVarImpegniBudget.Text = VariazioniImpegniBudget().ToString("c");
			txtBudgetdisponibilePreimpegni.Text = (budgetIni + varBudget - preImp - varPreImp).ToString("c");

			decimal budgetIniAcc = BudgetIniziale("A");
			txtBudgetInizialeAcc.Text = budgetIniAcc.ToString("c");
			decimal varBudgetAcc = VarBudget("A");
			txtVarBudgetAcc.Text = varBudgetAcc.ToString("c");
			decimal preAcc = PreaccertamentiBudget();
			txtPreaccertamentiBudget.Text = preAcc.ToString("c");
			decimal varPreAcc = VariazioniPreaccertamentiBudget();
			txtVarPreaccertamenti.Text = varPreAcc.ToString("c");
			txtAccertamentiBudget.Text = AccertamentiBudget().ToString("c");
			txtVarAccertamentiBudget.Text = VariazioniAccertamentiBudget().ToString("c");
			txtBudgetdisponibilePreaccertmenti.Text = (budgetIniAcc + varBudgetAcc - preAcc - varPreAcc).ToString("c");
		}

		private decimal BudgetIniziale(string kind) {
			decimal valore;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("accountusablelevel"));

			string filter = "";
			filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			filter = QHS.AppAnd(filter, upbComp("idupb", Curr["idupb"]));
			filter = QHS.AppAnd(filter, QHS.CmpEq("nlevel", levelop));
			if (kind == "I") {
				//Costi : flagaccountusage : bit 6(&64 Costi), bit 8(&256 Immobilizzazioni), bit 12(&4096 Accantonamento)
				filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.BitSet("flagaccountusage", 6), QHS.BitSet("flagaccountusage", 8), QHS.BitSet("flagaccountusage", 12))));
			} else {
				//Ricavi : flagaccountusage : bit 7 ( &128 Ricavo)
				filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", 7));
			}
			string strExpr = "SUM(ISNULL(prevision,0))";
			valore = CK(Conn.DO_READ_VALUE("accountyearview", filter, strExpr));
			return valore;
		}

		private decimal VarBudget(string kind) {
			decimal valore;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			int esercizioCurr = (int)Meta.GetSys("esercizio");

			string filter = "";
			filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
			filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));
			if (kind == "I") {
				//Costi : flagaccountusage : bit 6(&64 Costi), bit 8(&256 Immobilizzazioni), bit 12(&4096 Accantonamento)
				filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.BitSet("flagaccountusage", 6), QHS.BitSet("flagaccountusage", 8), QHS.BitSet("flagaccountusage", 12))));
			} else {
				//Ricavi : flagaccountusage : bit 7 ( &128 Ricavo)
				filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", 7));
			}
			filter = QHS.AppAnd(filter, QHS.CmpNe("variationkind", "5"));
			filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			filter = QHS.AppAnd(filter, upbComp("idupb", Curr["idupb"]));
			string strExpr = "SUM(ISNULL(amount,0))";
			valore = CK(Conn.DO_READ_VALUE("accountvardetailview", filter, strExpr));

			return valore;
		}
		private decimal ImpegniBudget() {

			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			Filter = QHS.CmpEq("E.nphase", "2");
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));


			// quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
			string sql = " SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EY.amount  ELSE EY.amount END ) as amount from epexpyear EY " +
						 " JOIN epexp E on EY.idepexp=E.idepexp " +
						 " WHERE " + Filter;

			// quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);


			return valore;

		}

		private decimal VariazioniImpegniBudget() {

			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;

			// Aggiungiamo le var. dei suddetti pagamenti.
			Filter = QHS.CmpEq("E.nphase", "2");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));

			string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EV.amount  ELSE EV.amount END ) as amount from epexpyear EY " +
						" JOIN epexp E on EY.idepexp=E.idepexp " +
						" JOIN epexpvar EV on EV.idepexp=EY.idepexp and EY.ayear= EV.yvar" +
						" WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);

			return valore;

		}


		private decimal PreimpegniBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			Filter = QHS.CmpEq("E.nphase", "1");
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));

			// quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
			string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EY.amount  ELSE EY.amount END ) as amount from epexpyear EY " +
						 "JOIN epexp E on EY.idepexp=E.idepexp " +
						 " WHERE " + Filter;

			// quindi sommiamo gli amount dei pagamenti associati alla voce di bilancio corrente
			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);

			return valore;
		}

		decimal VariazioniPreimpegniBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;

			// Aggiungiamo le var. dei suddetti pagamenti.
			Filter = QHS.CmpEq("E.nphase", "1");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.idupb", Curr["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));

			string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EV.amount  ELSE EV.amount END ) as amount from epexpyear EY " +
						"JOIN epexp E on EY.idepexp=E.idepexp " +
						"JOIN epexpvar EV on EV.idepexp=EY.idepexp and EY.ayear= EV.yvar" +
						" WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);

			return valore;
		}
		private decimal PreaccertamentiBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			Filter = QHS.CmpEq("E.nphase", "1");
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));

			// quindi sommiamo gli amount degli accertamenti associati alla voce di bilancio corrente
			string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EY.amount  ELSE EY.amount END ) as amount from epaccyear EY " +
						 "JOIN epacc E on EY.idepacc = E.idepacc " +
						 " WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);

			return valore;
		}

		decimal VariazioniPreaccertamentiBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;

			Filter = QHS.CmpEq("E.nphase", "1");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));

			string sql = "SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EV.amount  ELSE EV.amount END ) as amount from epaccyear EY " +
						"JOIN epacc E on EY.idepacc = E.idepacc " +
						"JOIN epaccvar EV on EV.idepacc = EY.idepacc and EY.ayear= EV.yvar" +
						" WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);

			return valore;
		}
		private decimal AccertamentiBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;
			Filter = QHS.CmpEq("E.nphase", "2");
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("E.adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));
			// quindi sommiamo gli amount degli impegni associati alla voce di bilancio corrente
			string sql = " SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EY.amount  ELSE EY.amount END ) as amount from epaccyear EY " +
						 " JOIN epacc E on EY.idepacc = E.idepacc " +
						 " WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);
			return valore;
		}

		private decimal VariazioniAccertamentiBudget() {
			decimal valore;
			string Filter = "";
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return 0;

			// Aggiungiamo le var. dei suddetti pagamenti.
			Filter = QHS.CmpEq("E.nphase", "2");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("EY.idupb", Curr["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("EV.yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("EV.adate", Meta.GetSys("datacontabile")));

			string sql = " SELECT SUM(CASE WHEN E.flagvariation = 'S' THEN - EV.amount  ELSE EV.amount END)  as amount from epaccyear EY " +
						 " JOIN epacc E on EY.idepacc = E.idepacc " +
						 " JOIN epaccvar EV on EV.idepacc = EY.idepacc and EY.ayear= EV.yvar " +
						 " WHERE " + Filter;

			DataTable t = Conn.SQLRunner(sql, false);
			if (t == null || t.Rows.Count == 0) return 0;
			valore = CK(t.Rows[0]["amount"]);
			return valore;
		}

		private void btnBudgetIniziale_Click(object sender, EventArgs e) {
			VisualizzaBudgetIniziale("I");
		}

		private void btnVarBudget_Click(object sender, EventArgs e) {
			VisualizzaVarBudget("I");
		}
		private void VisualizzaVarBudget(string kind) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			int esercizioCurr = (int)Meta.GetSys("esercizio");

			string filter = "";
			string VistaScelta;
			filter = QHS.CmpEq("yvar", Meta.GetSys("esercizio"));
			filter = QHS.AppAnd(filter, QHS.CmpEq("idaccountvarstatus", "5"));

			filter = QHS.AppAnd(filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			filter = QHS.AppAnd(filter, upbComp("idupb", Curr["idupb"]));
			if (kind == "I") {
				//Costi : flagaccountusage : bit 6(&64 Costi), bit 8(&256 Immobilizzazioni), bit 12(&4096 Accantonamento)
				filter = QHS.AppAnd(filter, QHS.DoPar(QHS.AppOr(QHS.BitSet("flagaccountusage", 6), QHS.BitSet("flagaccountusage", 8), QHS.BitSet("flagaccountusage", 12))));
			} else {
				//Ricavi : flagaccountusage : bit 7 ( &128 Ricavo)
				filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", 7));
			}


			string listaVarkind = QHS.List("1", "3", "4", "5");
			filter = QHS.AppAnd(filter, QHS.FieldInList("variationkind", listaVarkind));

			VistaScelta = "accountvardetailview";
			MetaData MAccountVarDetail = MetaData.GetMetaData(this, VistaScelta);
			MAccountVarDetail.FilterLocked = true;
			MAccountVarDetail.DS = DS;
			DataRow MyDR = MAccountVarDetail.SelectOne("listaestesa", filter, null, null);

			if (MyDR != null) {
				SelezionaVariazioneBudget(MyDR);
			}
		}

		private void SelezionaVariazioneBudget(DataRow MyDR) {
			MetaData newAccVarDetail = Meta.Dispatcher.Get("accountvardetail");

			newAccVarDetail.Edit(this.ParentForm, "default", false);
			DataRow R2 = newAccVarDetail.SelectOne("lista",
				QHS.AppAnd(QHS.CmpEq("yvar", MyDR["yvar"]),
				QHS.CmpEq("nvar", MyDR["nvar"]), QHS.CmpEq("rownum", MyDR["rownum"])),
				"accountvardetail", null);
			if (R2 != null) newAccVarDetail.SelectRow(R2, "lista");
		}

		private void btnPreimpegniBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			Filter = QHS.CmpEq("nphase", "1");
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));
			VistaScelta = "epexpview";

			MetaData MPreImpegni = MetaData.GetMetaData(this, VistaScelta);
			MPreImpegni.FilterLocked = true;
			MPreImpegni.DS = DS;
			DataRow MyDR = MPreImpegni.SelectOne("budgetupb", Filter, null, null);

			if (MyDR != null) {
				//Seleziona movimento
				MetaData newSpesa = Meta.Dispatcher.Get("epexp");
				newSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
					QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
				if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
			}
		}

		private void btnImpegniBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			Filter = QHS.CmpEq("nphase", "2");
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));

			VistaScelta = "epexpview";

			MetaData MImpegni = MetaData.GetMetaData(this, VistaScelta);
			MImpegni.FilterLocked = true;
			MImpegni.DS = DS;
			DataRow MyDR = MImpegni.SelectOne("budgetupb", Filter, null, null);

			if (MyDR != null) {
				//Seleziona movimento
				MetaData newSpesa = Meta.Dispatcher.Get("epexp");
				newSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newSpesa.SelectOne(newSpesa.DefaultListType,
					QHS.CmpEq("idepexp", MyDR["idepexp"]), "epexp", null);
				if (R2 != null) newSpesa.SelectRow(R2, newSpesa.DefaultListType);
			}
		}

		private void btnBudgetUPB_Click(object sender, EventArgs e) {
			if (Meta.IsEmpty)
				return;
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null)
				return;

			object idUpb = upbRow["idupb"];
			DS.accountprevisionview.ExtendedProperties[MetaData.ExtraParams] = idUpb;
			Meta.Dispatcher.Edit(this.ParentForm, "accountprevisionview", "prevision", false, idUpb);

		}

		private void btnSitBudgetAnnuale_Click(object sender, EventArgs e) {
			DataRow rUpb = HelpForm.GetLastSelected(DS.upb);
			if (rUpb == null) return;
			string idUpb = rUpb["idupb"].ToString();

			DataSet Out = Meta.Conn.CallSP("show_upbaccountannual",
				new Object[2] {Meta.GetSys("datacontabile"),
								  idUpb
							  }
				);
			if (Out == null) return;
			Out.Tables[0].TableName = "Situazione Annuale Budget U.P.B.";

			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

		private void btnSituazioneBudget_Click(object sender, EventArgs e) {
			DataRow rUpb = HelpForm.GetLastSelected(DS.upb);
			if (rUpb == null) return;
			string idUpb = rUpb["idupb"].ToString();

			DataSet Out = Meta.Conn.CallSP("show_upbaccountmultiannual",
				new Object[2] {Meta.GetSys("datacontabile"),
								  idUpb
							  }
				);
			if (Out == null) return;
			Out.Tables[0].TableName = "Situazione Pluriennale Budget U.P.B.";

			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();

		}

		private void chkUpbChilds_CheckedChanged(object sender, EventArgs e) {

			if (calcFin == null) return;
			if (chkUpbChilds.Checked) upbComp = UpbCompareLike;
			else upbComp = UpbCompareEqual;

			calcFin.SetUpbWithChilds(chkUpbChilds.Checked);

			pulisciTextRiepilogo();
		}

		string UpbCompareEqual(string field, object value) {
			return QHS.CmpEq(field, value);
		}
		string UpbCompareLike(string field, object value) {
			return QHS.Like(field, value.ToString() + "%");
		}

		private void btnCalcolaTutto_Click(object sender, EventArgs e) {
			CalcolaTotaliEntrate();
			CalcolaTotaliSpese();
			CalcolaTotaliBudget();
			CalcolaTotaliScrittureEP();
		}

		private void btnVarPreimpegni_Click(object sender, EventArgs e) {
			string Filter = "";
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null)
				return;
			Filter = QHS.CmpEq("nphase", "1");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("idupb", upbRow["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

			string VistaScelta = "epexpvarview";
			MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
			MVarImpegni.FilterLocked = true;
			MVarImpegni.DS = DS;
			DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
			if (MyDR != null) {
				MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
				newVarSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
					QHS.AppAnd(QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epexpvar", null);
				if (R2 != null)
					newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
			}
		}

		private void btnVarImpegni_Click(object sender, EventArgs e) {

		}

		public void CreateUpbYearRow() {
			if (Meta.IsEmpty) return;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			string filtro = QHC.AppAnd(QHC.CmpEq("idupb", Curr["idupb"]),
				QHC.CmpEq("ayear", Meta.GetSys("esercizio")));
			DataRow[] r = DS.upbyear.Select(filtro);
			if (r.Length == 0) {
				MetaData metaUY = MetaData.GetMetaData(this, "upbyear");
				metaUY.SetDefaults(DS.upbyear);
				DataRow DR = metaUY.Get_New_Row(Curr, DS.upbyear);
			}
		}
		private void btnInsDettagli_Click(object sender, EventArgs e) {
			Meta.GetFormData(true);
			CreateUpbYearRow();
			Meta.FreshForm(false);
		}





		private void SelezionaDettaglioScrittura(DataRow MyDR) {

			MetaData Newentrydetail = Meta.Dispatcher.Get("entrydetail");
			Newentrydetail.Edit(this.ParentForm, "default", false);
			DataRow R2 = Newentrydetail.SelectOne(Newentrydetail.DefaultListType,
				 QHS.AppAnd(QHS.CmpEq("yentry", MyDR[("yentry")]),
							QHS.CmpEq("nentry", MyDR["nentry"]),
							QHS.CmpEq("ndetail", MyDR["ndetail"])), "entrydetail", null);
			if (R2 != null)
				Newentrydetail.SelectRow(R2, Newentrydetail.DefaultListType);
		}


		private decimal DettagliScritture(int bitTipoConto, String dare_o_avere) {
			decimal valore;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			//int esercizioCurr = (int)Meta.GetSys("esercizio"); //TASK 10134 -Alex 

			string filter = "";
			filter = QHS.CmpEq("yentry", Meta.GetSys("esercizio"));
			filter = QHS.AppAnd(filter, upbComp("idupb", Curr["idupb"]));
			filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", bitTipoConto));

			string strExpr = "";

			if (dare_o_avere == "A") {
				strExpr = "SUM(have)";
				filter = QHS.AppAnd(filter, QHS.CmpGt("have", 0));
			} else {
				strExpr = "SUM(give)";
				filter = QHS.AppAnd(filter, QHS.CmpGt("give", 0));
			}

			valore = CK(Conn.DO_READ_VALUE("entrydetailview", filter, strExpr));

			return valore;

		}



		//TASK 10134 -Alex
		//Modificati tutti i metodi commentati come richiesto da task (Vedi mia attivit‡ per maggiori info) 




		//private void CalcolaTotaliScrittureEP(){

		//    decimal costiDare = DettagliScritture(6, "D");
		//    txtCostiDare.Text = costiDare.ToString("C");

		//    decimal immobilizzazioniDare = DettagliScritture(8, "D");
		//    txtImmobilizzazioniDare.Text = immobilizzazioniDare.ToString("C");

		//    decimal ricaviDare = DettagliScritture(7, "D");
		//    txtRicaviDare.Text = ricaviDare.ToString("C");

		//    decimal contiDebitoDare = DettagliScritture(4, "D");
		//    txtContiDebitoDare.Text = contiDebitoDare.ToString("C");

		//    decimal contiCreditoDare = DettagliScritture(5,"D");
		//    txtContiCreditoDare.Text = contiCreditoDare.ToString("C");

		//    decimal rateiAttiviDare = DettagliScritture(0,"D");
		//    txtRateiAttiviDare.Text = rateiAttiviDare.ToString("C");

		//    decimal rateiPassiviDare = DettagliScritture(1,"D");
		//    txtRateiPassiviDare.Text = rateiPassiviDare.ToString("C");

		//    decimal riscontriAttiviDare = DettagliScritture(2,"D");
		//    txtRiscontiAttiviDare.Text = riscontriAttiviDare.ToString("C");

		//    decimal riscontriPassiviDare = DettagliScritture(3,"D");
		//    txtRiscontiPassiviDare.Text = riscontriPassiviDare.ToString("C");

		//    decimal riservaDare = DettagliScritture(11,"D");
		//    txtRiservaDare.Text = riservaDare.ToString("C");

		//    decimal fondoAccantonamentoDare = DettagliScritture(12, "D");
		//    txtFondoAccantonamentoDare.Text = fondoAccantonamentoDare.ToString("C");

		//    decimal costiAvere = DettagliScritture(6, "A");
		//    txtCostiAvere.Text = costiAvere.ToString("C");

		//    decimal immobilizzazioniAvere = DettagliScritture(8, "A");
		//    txtImmobilizzazioniAvere.Text = immobilizzazioniAvere.ToString("C");

		//    decimal ricaviAvere = DettagliScritture(7, "A");
		//    txtRicaviAvere.Text = ricaviAvere.ToString("C");

		//    decimal contiDebitoAvere = DettagliScritture(4, "A");
		//    txtContiDebitoAvere.Text = contiDebitoAvere.ToString("C");

		//    decimal contiCreditoAvere = DettagliScritture(5,"A");
		//    txtContiCreditoAvere.Text = contiCreditoAvere.ToString("C");

		//    decimal rateiArriviAvere = DettagliScritture(0, "A");
		//    txtRateiAttiviAvere.Text = rateiArriviAvere.ToString("C");

		//    decimal rateiPassiviAvere = DettagliScritture(1, "A");
		//    txtRateiPassiviAvere.Text = rateiPassiviAvere.ToString("C");

		//    decimal riscontriAttiviAvere = DettagliScritture(2, "A");
		//    txtRiscontiAttiviAvere.Text = riscontriAttiviAvere.ToString("C");

		//    decimal riscontriPassiviAvere = DettagliScritture(3, "A");
		//    txtRiscontiPassiviAvere.Text = riscontriPassiviAvere.ToString("C");

		//    decimal riserveAvere = DettagliScritture(11, "A");
		//    txtRiservaAvere.Text = riserveAvere.ToString("C");

		//    decimal fondoAccantonamentoAvere = DettagliScritture(12, "A");
		//    txtFondoAccantonamentoAvere.Text = fondoAccantonamentoAvere.ToString("C");

		//}


		private void CalcolaTotaliScrittureEP() {


			decimal costiDare = DettagliScritture(6, "D");
			decimal ammortamentoDare = DettagliScritture(17, "D");
			txtCostiDare.Text = (costiDare + ammortamentoDare).ToString("C");
			decimal costiAvere = DettagliScritture(6, "A");
			decimal ammortamentoAvere = DettagliScritture(17, "A");
			txtCostiAvere.Text = (costiAvere + ammortamentoAvere).ToString("C");
			txtCostiDifferenza.Text = (costiDare + ammortamentoDare - costiAvere - ammortamentoAvere).ToString("C");


			decimal immobilizzazioniDare = DettagliScritture(8, "D");
			txtImmobilizzazioniDare.Text = immobilizzazioniDare.ToString("C");
			decimal immobilizzazioniAvere = DettagliScritture(8, "A");
			txtImmobilizzazioniAvere.Text = immobilizzazioniAvere.ToString("C");
			txtImmobilizzazioniDifferenza.Text = (immobilizzazioniDare - immobilizzazioniAvere).ToString("C");


			decimal ricaviDare = DettagliScritture(7, "D");
			txtRicaviDare.Text = ricaviDare.ToString("C");
			decimal ricaviAvere = DettagliScritture(7, "A");
			txtRicaviAvere.Text = ricaviAvere.ToString("C");
			txtRicaviDifferenza.Text = (ricaviDare - ricaviAvere).ToString("C");


			decimal contiDebitoDare = DettagliScritture(4, "D");
			txtContiDebitoDare.Text = contiDebitoDare.ToString("C");
			decimal contiDebitoAvere = DettagliScritture(4, "A");
			txtContiDebitoAvere.Text = contiDebitoAvere.ToString("C");
			txtContiDebitoDifferenza.Text = (contiDebitoDare - contiDebitoAvere).ToString("C");


			decimal contiCreditoDare = DettagliScritture(5, "D");
			txtContiCreditoDare.Text = contiCreditoDare.ToString("C");
			decimal contiCreditoAvere = DettagliScritture(5, "A");
			txtContiCreditoAvere.Text = contiCreditoAvere.ToString("C");
			txtContiCreditoDifferenza.Text = (contiCreditoDare - contiCreditoAvere).ToString("C");


			decimal rateiAttiviDare = DettagliScritture(0, "D");
			txtRateiAttiviDare.Text = rateiAttiviDare.ToString("C");
			decimal rateiAttiviAvere = DettagliScritture(0, "A");
			txtRateiAttiviAvere.Text = rateiAttiviAvere.ToString("C");
			txtRateiAttiviDifferenza.Text = (rateiAttiviDare - rateiAttiviAvere).ToString("C");


			decimal rateiPassiviDare = DettagliScritture(1, "D");
			txtRateiPassiviDare.Text = rateiPassiviDare.ToString("C");
			decimal rateiPassiviAvere = DettagliScritture(1, "A");
			txtRateiPassiviAvere.Text = rateiPassiviAvere.ToString("C");
			txtRateiPassiviDifferenza.Text = (rateiPassiviDare - rateiPassiviAvere).ToString("C");


			decimal riscontriAttiviDare = DettagliScritture(2, "D");
			txtRiscontiAttiviDare.Text = riscontriAttiviDare.ToString("C");
			decimal riscontriAttiviAvere = DettagliScritture(2, "A");
			txtRiscontiAttiviAvere.Text = riscontriAttiviAvere.ToString("C");
			txtRiscontiAttiviDifferenza.Text = (riscontriAttiviDare - riscontriAttiviAvere).ToString("C");


			decimal riscontriPassiviDare = DettagliScritture(3, "D");
			txtRiscontiPassiviDare.Text = riscontriPassiviDare.ToString("C");
			decimal riscontriPassiviAvere = DettagliScritture(3, "A");
			txtRiscontiPassiviAvere.Text = riscontriPassiviAvere.ToString("C");
			txtRiscontiPassiviDifferenza.Text = (riscontriPassiviDare - riscontriPassiviAvere).ToString("C");


			decimal riservaDare = DettagliScritture(11, "D");
			txtRiservaDare.Text = riservaDare.ToString("C");
			decimal riserveAvere = DettagliScritture(11, "A");
			txtRiservaAvere.Text = riserveAvere.ToString("C");
			txtRiservaDifferenza.Text = (riservaDare - riserveAvere).ToString("C");


			decimal fondoAccantonamentoDare = DettagliScritture(12, "D");
			txtFondoAccantonamentoDare.Text = fondoAccantonamentoDare.ToString("C");
			decimal fondoAccantonamentoAvere = DettagliScritture(12, "A");
			txtFondoAccantonamentoAvere.Text = fondoAccantonamentoAvere.ToString("C");
			txtFondoAccantonamentoDifferenza.Text = (fondoAccantonamentoDare - fondoAccantonamentoAvere).ToString("C");




			//MODIFICHE TASK 10657

			decimal Disponibilit‡liquideDare = DettagliScritture(13, "D");
			txtDisponibilit‡liquideDare.Text = Disponibilit‡liquideDare.ToString("C");
			decimal Disponibilit‡liquideAvere = DettagliScritture(13, "A");
			txtDisponibilit‡liquideAvere.Text = Disponibilit‡liquideAvere.ToString("C");
			txtDisponibilit‡liquideDifferenza.Text = (Disponibilit‡liquideDare - Disponibilit‡liquideAvere).ToString("C");


			decimal AltrevociAttivoDare = DettagliScritture(14, "D");
			txtAltrevociAttivoDare.Text = AltrevociAttivoDare.ToString("C");
			decimal AltrevociAttivoAvere = DettagliScritture(14, "A");
			txtAltrevociAttivoAvere.Text = AltrevociAttivoAvere.ToString("C");
			txtAltrevociAttivoDifferenza.Text = (AltrevociAttivoDare - AltrevociAttivoAvere).ToString("C");


			decimal FondiAmmortamentoDare = DettagliScritture(14, "D");
			txtFondiAmmortamentoDare.Text = FondiAmmortamentoDare.ToString("C");
			decimal FondiAmmortamentoAvere = DettagliScritture(14, "A");
			txtFondiAmmortamentoAvere.Text = FondiAmmortamentoAvere.ToString("C");
			txtFondiAmmortamentoDifferenza.Text = (FondiAmmortamentoDare - FondiAmmortamentoAvere).ToString("C");


			decimal AltrevociPassivoDare = DettagliScritture(14, "D");
			txtAltrevociPassivoDare.Text = AltrevociPassivoDare.ToString("C");
			decimal AltrevociPassivoAvere = DettagliScritture(14, "A");
			txtAltrevociPassivoAvere.Text = AltrevociPassivoAvere.ToString("C");
			txtAltrevociPassivoDifferenza.Text = (AltrevociPassivoDare - AltrevociPassivoAvere).ToString("C");



		}


		//private void VisualizzaDettagliScritture(int bitTipoConto, String dare_o_avere){

		//    string filter = "";
		//    string VistaScelta;
		//    DataRow Curr = HelpForm.GetLastSelected(DS.upb);
		//    if (Curr == null) return;

		//    filter = QHS.CmpEq("yentry", Meta.GetSys("esercizio"));
		//    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", Curr["idupb"]));
		//    filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", bitTipoConto));


		//    if (dare_o_avere == "A"){
		//        filter = QHS.AppAnd(filter, QHS.CmpGt("have", 0));
		//    }
		//    else{
		//        filter = QHS.AppAnd(filter, QHS.CmpGt("give", 0));
		//    }

		//    VistaScelta = "entrydetailview";

		//    MetaData Mentrydetailview = MetaData.GetMetaData(this, VistaScelta);
		//    Mentrydetailview.FilterLocked = true;
		//    Mentrydetailview.DS = DS;

		//    DataRow MyDR = Mentrydetailview.SelectOne("listaestesa", filter, null, null);

		//    if (MyDR != null){
		//        SelezionaDettaglioScrittura(MyDR);
		//    }
		//}


		//private void CostiDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(6,"D");
		//}

		//private void ImmobilizzazioniDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(8, "D");
		//}

		//private void RicaviDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(7, "D");
		//}

		//private void ContiDebitoDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(4, "D");
		//}

		//private void ContiCreditoDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(5, "D");
		//}

		//private void RateiAttiviDare_Click(object sender, EventArgs e) { 
		//    VisualizzaDettagliScritture(0, "D");
		//}

		//private void RateiPassiviDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(1, "D");
		//}

		//private void RiscontiAttiviDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(2, "D");
		//}

		//private void RiscontiPassiviDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(3, "D");
		//}

		//private void RiservaDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(11, "D");
		//}

		//private void FondoAccantonamentoDare_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(12, "D");
		//}

		//private void CostiAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(6, "A");
		//}

		//private void ImmobilizzazioniAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(8, "A");
		//}

		//private void RicaviAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(7, "A");
		//}

		//private void ContiDebitoAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(4, "A");
		//}

		//private void ContiCreditoAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(5, "A");
		//}

		//private void RateiAttiviAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(0, "A");
		//}

		//private void RateiPassiviAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(1, "A");
		//}

		//private void RiscontiAttiviAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(2, "A");
		//}

		//private void RiscontiPassiviAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(3, "A");
		//}

		//private void RiservaAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(11, "A");
		//}

		//private void FondoAccantonamentoAvere_Click(object sender, EventArgs e){
		//    VisualizzaDettagliScritture(12, "A");
		//}




		private void VisualizzaDettagliScrittureEP(int flagaccountusage) {

			string filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			filter = QHS.AppAnd(filter, upbComp("idupb", Curr["idupb"]));
			filter = QHS.AppAnd(filter, QHS.BitSet("flagaccountusage", flagaccountusage));

			VistaScelta = "entrydetailview";

			MetaData Mentrydetailview = MetaData.GetMetaData(this, VistaScelta);
			Mentrydetailview.FilterLocked = true;
			Mentrydetailview.DS = DS;

			DataRow MyDR = Mentrydetailview.SelectOne("listaestesa", filter, null, null);

			if (MyDR != null) {
				SelezionaDettaglioScrittura(MyDR);
			}
		}





		private void CostiDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(6);
		}


		private void ImmobilizzazioniDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(8);
		}

		private void RicaviDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(7);
		}

		private void ContiDebitoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(4);
		}

		private void ContiCreditoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(5);
		}

		private void RateiAttiviDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(0);
		}

		private void RateiPassiviDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(1);
		}

		private void RiscontiAttiviDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(2);
		}

		private void RiscontiPassiviDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(3);
		}

		private void RiservaDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(11);
		}

		private void FondoAccantonamentoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(12);
		}


		//FINE MODIFICHE TASK 10134 -Alex


		//TASK 10657    
		private void Disponibilit‡liquideDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(13);
		}

		private void AltrevociAttivoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(14);
		}

		private void FondiAmmortamentoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(15);
		}

		private void AltrevociPassivoDareAvere_Click(object sender, EventArgs e) {
			VisualizzaDettagliScrittureEP(16);
		}

		private void btnBudgetInizialeAcc_Click(object sender, EventArgs e) {
			VisualizzaBudgetIniziale("A");
		}

		private void btnVarBudgetAcc_Click(object sender, EventArgs e) {
			VisualizzaVarBudget("A");
		}

		private void btnPreaccertamentiBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			Filter = QHS.CmpEq("nphase", "1");
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));
			VistaScelta = "epaccview";

			MetaData MPreAccertamenti = MetaData.GetMetaData(this, VistaScelta);
			MPreAccertamenti.FilterLocked = true;
			MPreAccertamenti.DS = DS;
			DataRow MyDR = MPreAccertamenti.SelectOne("budgetupb", Filter, null, null);

			if (MyDR != null) {
				//Seleziona movimento
				MetaData newEntrata = Meta.Dispatcher.Get("epacc");
				newEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
					QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
				if (R2 != null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
			}
		}

		private void btnVarImpegniBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null)
				return;
			Filter = QHS.CmpEq("nphase", "2");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("idupb", upbRow["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

			string VistaScelta = "epexpvarview";
			MetaData MVarImpegni = MetaData.GetMetaData(this, VistaScelta);
			MVarImpegni.FilterLocked = true;
			MVarImpegni.DS = DS;
			DataRow MyDR = MVarImpegni.SelectOne("budgetupb", Filter, null, null);
			if (MyDR != null) {
				MetaData newVarSpesa = Meta.Dispatcher.Get("epexpvar");
				newVarSpesa.Edit(this.ParentForm, "default", false);
				DataRow R2 = newVarSpesa.SelectOne(newVarSpesa.DefaultListType,
					QHS.AppAnd(QHS.CmpEq("idepexp", MyDR["idepexp"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epexpvar", null);
				if (R2 != null)
					newVarSpesa.SelectRow(R2, newVarSpesa.DefaultListType);
			}
		}

		private void btnVarPreaccertamentiBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null)
				return;
			Filter = QHS.CmpEq("nphase", "1");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("idupb", upbRow["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

			string VistaScelta = "epaccvarview";
			MetaData MVarAccertamenti = MetaData.GetMetaData(this, VistaScelta);
			MVarAccertamenti.FilterLocked = true;
			MVarAccertamenti.DS = DS;
			DataRow MyDR = MVarAccertamenti.SelectOne("budgetupb", Filter, null, null);
			if (MyDR != null) {
				MetaData newVarEntrata = Meta.Dispatcher.Get("epaccvar");
				newVarEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newVarEntrata.SelectOne(newVarEntrata.DefaultListType,
					QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epaccvar", null);
				if (R2 != null)
					newVarEntrata.SelectRow(R2, newVarEntrata.DefaultListType);
			}
		}

		private void btnAccertamentiBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			string VistaScelta;
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			Filter = QHS.CmpEq("nphase", "2");
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));
			Filter = QHS.AppAnd(Filter, upbComp("idupb", Curr["idupb"]));
			VistaScelta = "epaccview";

			MetaData MAccertamenti = MetaData.GetMetaData(this, VistaScelta);
			MAccertamenti.FilterLocked = true;
			MAccertamenti.DS = DS;
			DataRow MyDR = MAccertamenti.SelectOne("budgetupb", Filter, null, null);

			if (MyDR != null) {
				//Seleziona movimento
				MetaData newEntrata = Meta.Dispatcher.Get("epacc");
				newEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newEntrata.SelectOne(newEntrata.DefaultListType,
					QHS.CmpEq("idepacc", MyDR["idepacc"]), "epacc", null);
				if (R2 != null) newEntrata.SelectRow(R2, newEntrata.DefaultListType);
			}
		}

		private void btnVarAccertamentiBudget_Click(object sender, EventArgs e) {
			string Filter = "";
			DataRow upbRow = HelpForm.GetLastSelected(DS.upb);
			if (upbRow == null)
				return;
			Filter = QHS.CmpEq("nphase", "2");
			//Filter = QHS.AppAnd(Filter, QHS.CmpEq("EY.ayear", Meta.GetSys("esercizio"))); 8469
			Filter = QHS.AppAnd(Filter, upbComp("idupb", upbRow["idupb"]));
			Filter = QHS.AppAnd(Filter, QHS.CmpEq("yvar", Meta.GetSys("esercizio")));
			Filter = QHS.AppAnd(Filter, QHS.CmpLe("adate", Meta.GetSys("datacontabile")));

			string VistaScelta = "epaccvarview";
			MetaData MVarAccertamenti = MetaData.GetMetaData(this, VistaScelta);
			MVarAccertamenti.FilterLocked = true;
			MVarAccertamenti.DS = DS;
			DataRow MyDR = MVarAccertamenti.SelectOne("budgetupb", Filter, null, null);
			if (MyDR != null) {
				MetaData newVarEntrata = Meta.Dispatcher.Get("epaccvar");
				newVarEntrata.Edit(this.ParentForm, "default", false);
				DataRow R2 = newVarEntrata.SelectOne(newVarEntrata.DefaultListType,
					QHS.AppAnd(QHS.CmpEq("idepacc", MyDR["idepacc"]), QHS.CmpEq("yvar", MyDR["yvar"])), "epaccvar", null);
				if (R2 != null)
					newVarEntrata.SelectRow(R2, newVarEntrata.DefaultListType);
			}
		}

		private void btnImpegniAll_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaImpegniAll();
		}

		private void btnAccertamentiAll_Click(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			calcFin.ElencaAccertamentiAll();
		}
		void enableDisableUE() {
			if (cmbCofog.SelectedIndex > 0) {
				grpCodUE.Enabled = true;
			} else {
				grpCodUE.Enabled = false;
			}
		}

		private void cmbCofog_SelectedIndexChanged(object sender, EventArgs e) {
			DataRow Curr = HelpForm.GetLastSelected(DS.upb);
			if (Curr == null) return;
			object code = cmbCofog.SelectedValue;
			if (code != DBNull.Value) {
				Curr["cofogmpcode"] = cmbCofog.SelectedValue;
				grpCodUE.Enabled = true;
			} else {
				Curr["cofogmpcode"] = DBNull.Value;
				Curr["uesiopecode"] = DBNull.Value;
				rdbUE01.Checked = false;
				rdbUE02.Checked = false;
				rdbUE03.Checked = false;
				rdbUE04.Checked = false;
				grpCodUE.Enabled = false;

			}
		}
	}
}
