
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
using System.Data;
using SituazioneViewer;
using funzioni_configurazione;
using security_function;

namespace finyearview_default {
	/// <summary>
	/// Summary description for Frm_finyearview_default.
	/// </summary>
	public class Frm_finyearview_default : System.Windows.Forms.Form {
		public finyearview_default.vistaForm DS;
		public System.Windows.Forms.TabControl tabInterno;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.GroupBox grpPrevisione;
		private System.Windows.Forms.TextBox txtPrevisionePrincipalePrecUpb;
		private System.Windows.Forms.TextBox txtPrevisionePrincipaleCorrUpb;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaPrecUpb;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaCorrUpb;
		private System.Windows.Forms.TextBox txtResiduiPrecUpb;
		private System.Windows.Forms.TextBox txtResiduiCorrUpb;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox txtPrevisione5Upb;
		private System.Windows.Forms.TextBox txtPrevisione4Upb;
		private System.Windows.Forms.TextBox txtPrevisione3Upb;
		private System.Windows.Forms.TextBox txtPrevisione2Upb;
		private System.Windows.Forms.TabPage TabConsolidato;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox txtPrevisionePrincipalePrecConsolidato;
		private System.Windows.Forms.TextBox txtPrevisionePrincipaleCorrConsolidato;
		private System.Windows.Forms.Label lblEsCorrPrincCons;
		private System.Windows.Forms.Label lblEsPrecPrincCons;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaPrecConsolidato;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaCorrConsolidato;
		private System.Windows.Forms.Label lblEsCorrSecCons;
		private System.Windows.Forms.Label lblEsPrecSecCons;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.TextBox txtResiduiPrecConsolidato;
		private System.Windows.Forms.TextBox txtResiduiCorrConsolidato;
		private System.Windows.Forms.Label lblRipCorrCons;
		private System.Windows.Forms.Label lblRipPrecCons;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.TextBox txtPrevisione5Consolidato;
		private System.Windows.Forms.TextBox txtPrevisione4Consolidato;
		private System.Windows.Forms.TextBox txtPrevisione3Consolidato;
		private System.Windows.Forms.TextBox txtPrevisione2Consolidato;
		private System.Windows.Forms.Label lblPrev5Cons;
		private System.Windows.Forms.Label lblPrev4Cons;
		private System.Windows.Forms.Label lblPrev2Cons;
		private System.Windows.Forms.Label lblPrev3Cons;
        private System.Windows.Forms.GroupBox gboxUPB;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.Button btnSituazione;
		private System.ComponentModel.IContainer components;
		MetaData Meta;
		//bool inChiusura = false;
		private System.Windows.Forms.GroupBox grpPrevSec;
		private System.Windows.Forms.Splitter splitter1;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.GroupBox grpPrevSecCons;
		private System.Windows.Forms.Label lblRipPrecedente;
		private System.Windows.Forms.Label lblEsCorrentePrima;
		private System.Windows.Forms.Label lblEsPrecPrima;
		private System.Windows.Forms.Label lblEsCorrSeconda;
		private System.Windows.Forms.Label lblEsPrecSeconda;
		private System.Windows.Forms.Label lblRipCorrente;
		private System.Windows.Forms.Label lblPrevisione2;
		private System.Windows.Forms.Label lblPrevisione3;
		private System.Windows.Forms.Label lblPrevisione4;
		private System.Windows.Forms.Label lblPrevisione5;
		private System.Windows.Forms.GroupBox gboxPrimaPrevisione;
		private System.Windows.Forms.GroupBox gboxRipartizione;
        public TextBox txtUPB;
        private Button btnUPB;
        private Button btnCalcola;
        private TabPage tabPage1;
        private TabControl tabControlRiepilogo;
        private TabPage tabCompetenza;
        private GroupBox grpPrevCompetenza;
        private Label label7;
        private Label label6;
        private TextBox txtPrevAttualeCompetenza;
        private Button btnPiccoleSpeseImp;
        private Label lblPiccoleSpeseImp;
        private TextBox txtPiccoleSpeseImp;
        private Button btnAccertamentiCompetenza;
        private Label lblAccertamentiCompetenza;
        private TextBox txtAccertamentiCompetenza;
        private Label label3;
        private Button btnVarPrevCompetenza;
        private Label lblVarPrevCompetenza;
        private TextBox txtVarPrevCompetenza;
        private Label lblPrevDispCompetenza;
        private TextBox txtPrevDispCompetenza;
        private Button btnImpegniCompetenza;
        private Label lblImpegniCompetenza;
        private TextBox txtImpegniCompetenza;
        private Button btnPrevInizialeCompetenza;
        private Label lblPrevInizialeCompetenza;
        private TextBox txtPrevInizialeCompetenza;
        private TabPage tabCassa;
        private GroupBox grpPrevCassa;
        private Label label8;
        private Label label9;
        private TextBox txtPrevAttualeCassa;
        private TextBox txtPrevDispCassa;
        private Button btnPiccoleSpesePagamenti;
        private Label lblPiccoleSpesePagamenti;
        private TextBox txtPiccoleSpesePagamenti;
        private Button btnIncassi;
        private Label lblIncassi;
        private TextBox txtIncassi;
        private Label label4;
        private Button btnVarPrevisioneCassa;
        private Label lblVarPrevisioneCassa;
        private TextBox txtVarPrevisioneCassa;
        private Label lblPrevDispCassa;
        private Button btnPagamenti;
        private Label lblPagamenti;
        private TextBox txtPagamenti;
        private Button btnPrevInizialeCassa;
        private Label lblPrevInizialeCassa;
        private TextBox txtPrevInizialeCassa;
        private TabPage tabCrediti;
        private GroupBox grpCrediti;
        private Label label11;
        private Label labelTotaleCrediti;
        private TextBox txtTotaleCrediti;
        private Button btnVarDotazioneCrediti;
        private TextBox txtVarDotazioneCrediti;
        private Label lblVarDotazioneCrediti;
        private Label label5;
        private Button btnDotazioneCrediti;
        private Label lblDotazioneCrediti;
        private TextBox txtDotazioneCrediti;
        private Label lblCreditiResidui;
        private TextBox txtCreditiResidui;
        private Button btnCreditiAssegnati;
        private Label lblCreditiAssegnati;
        private TextBox txtCreditiAssegnati;
        private TabPage tabAssCassa;
        private GroupBox grpCassa;
        private Label label12;
        private Label labelTotaleCassa;
        private TextBox txtTotaleCassa;
        private Button btnPiccoleSpesePagamenti1;
        private Label lblPiccoleSpesePagamenti1;
        private TextBox txtPiccoleSpesePagamenti1;
        private Button btnPagamenti1;
        private Label lblPagamenti1;
        private TextBox txtPagamenti1;
        private Button btnVarDotazioneCassa;
        private TextBox txtVarDotazioneCassa;
        private Label lblVarDotazioneCassa;
        private Label label10;
        private Button btnDotazioneCassa;
        private Label lblDotazioneCassa;
        private TextBox txtDotazioneCassa;
        private Label lblCassaResidua;
        private TextBox txtCassaResidua;
        private Button btnAssegnazioniCassa;
        private Label lblAssegnazioniCassa;
        private TextBox txtAssegnazioniCassa;
		bool isBilancioOperativo = false;
        private Button btnCalcolaTotali;
        private CheckBox chkUpbChilds;
        private TextBox txtLimite;
        private Label label13;
        CalcoliFinanziario CalcFin;
		public Frm_finyearview_default() {
			InitializeComponent();
		}
        public object MAIN_idfin;
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			//inChiusura = true;
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        CQueryHelper QHC;        
        QueryHelper QHS;
        DataAccess Conn;
		public void MetaData_AfterLink() {
			QueryCreator.SetTableForPosting(DS.finyearview,"finyear");
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			object idBilancio = Meta.ExtraParameter;
			int esercizio = (int)Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            CalcFin = new CalcoliFinanziario(Meta, this);

			string filter = QHS.AppAnd(QHS.CmpEq("idfin", idBilancio),  filterEsercizio);
            DataTable BilTable = Meta.Conn.RUN_SELECT("fin", "idfin,paridfin,codefin,title,nlevel", null, filter,null, null, true);
			if (BilTable.Rows.Count>0){
				DataRow BilRow= BilTable.Rows[0];
				MetaData.SetDefault(DS.finyearview,"idfin",BilRow["idfin"]);
				MetaData.SetDefault(DS.finyearview,"paridfin",BilRow["paridfin"]);
				MetaData.SetDefault(DS.finyearview,"codefin",BilRow["codefin"]);
				MetaData.SetDefault(DS.finyearview,"finance",BilRow["title"]);
                MetaData.SetDefault(DS.finyearview, "nlevel", BilRow["nlevel"]);
            }
            string filterLevel = QHS.AppAnd(filterEsercizio, QHS.BitSet("flag", 1)); 
			object level = Meta.Conn.DO_READ_VALUE("finlevel",filterLevel,"min(nlevel)");

			if ((level != null) && (level != DBNull.Value)) {
                int levelFin = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idBilancio), "nlevel"));
				isBilancioOperativo = (levelFin >= Convert.ToInt32(level));
			}
			Meta.CanInsert = isBilancioOperativo;
            //DataTable tabellaPerTree = DataAccess.RUN_SELECT(Meta.Conn,"finyearview","*","codeupb",filter,null,null,true);
            //HelpForm.SetFilterToTree(DS.finyearview,tabellaPerTree);
            
            GetData.SetStaticFilter(DS.finyearview, filter);

			DS.finyearview.ExtendedProperties["idfin"] = idBilancio;
            MAIN_idfin = idBilancio;

			GetData.SetStaticFilter(DS.finyear,filter);
			GetData.SetStaticFilter(DS.finyearview,filter);
			GetData.CacheTable(DS.fin,filterEsercizio,null,false);			

			cambiaEtichetteEsercizi();
            txtLimite.ReadOnly = !(Sec_Function.funzioneConsentita(Conn, "edit_limit"));

            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                //grpPrevCompetenza.Visible = false;         //cassa
                tabControlRiepilogo.TabPages.Remove(tabCompetenza);
            }
		}

		public void MetaData_AfterActivation() {
			gestisciGruppoPrevisioneSecondaria();
            azzeraTxtConsolidato();
			if (treeView1.Nodes.Count > 0) {
				if (!treeView1.Nodes[0].IsExpanded) {
					treeView1.Nodes[0].Expand();
				}
			}

			string filteresercizio= QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataTable tConfig = DataAccess.RUN_SELECT(Meta.Conn, "config", null, null, filteresercizio, null, null, true);
			if (tConfig!= null){
				if (tConfig.Rows.Count != 0){
					DataRow rConfig= tConfig.Rows[0];

					//Imposta groupbox previsioni competenza 
                    string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
					if (nomeprevsecondaria!=null)
						grpPrevSec.Text= nomeprevsecondaria;
                    gboxPrimaPrevisione.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);				

					ImpostaLabelRipartizione(rConfig);
				}
			}
		}

		private void ImpostaLabelRipartizione(DataRow R) 
		{
			string RipGroupBox=R["boxpartitiontitle"].ToString();
			string RipCorrente=R["currpartitiontitle"].ToString();
			string RipPrecedente=R["prevpartitiontitle"].ToString();
			if (RipGroupBox!="") gboxRipartizione.Text=RipGroupBox;
			if (RipCorrente!="") lblRipCorrente.Text=RipCorrente;
			if (RipPrecedente!="") lblRipPrecedente.Text=RipPrecedente;
		}
		private void cambiaEtichetteEsercizi() 
		{
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;
            string currstr = esercizioCurr.ToString();
            string precstr = esercizioPrec.ToString();
            lblEsCorrentePrima.Text = currstr;
            lblEsCorrSeconda.Text = currstr;
            lblEsCorrPrincCons.Text = currstr;
            lblEsCorrSecCons.Text = currstr;
            lblRipCorrente.Text = "Presunti del " + currstr;
            lblRipCorrCons.Text = "Presunti del " + currstr;
            lblEsPrecPrima.Text = precstr;
            lblEsPrecSeconda.Text = precstr;
            lblEsPrecPrincCons.Text = precstr;
            lblEsPrecSecCons.Text = precstr;
            lblRipPrecedente.Text = "Presunti del " + precstr;
            lblRipPrecCons.Text = "Presunti del " + precstr;

			lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrev2Cons.Text = esercizioCurr.ToString();
			lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrev3Cons.Text = esercizioCurr.ToString();
			lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrev4Cons.Text = esercizioCurr.ToString();
			lblPrevisione5.Text = (++esercizioCurr).ToString();
            lblPrev5Cons.Text = esercizioCurr.ToString();
		}

		private void gestisciGruppoPrevisioneSecondaria() {
            int finkind = CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind"));
			
			if (finkind==3) {
				grpPrevSec.Visible = true;
				grpPrevSecCons.Visible = true;
				return;
			}
		}

		public void MetaData_AfterClear() {
            CalcFin.Enabled = false;
            pulisciTextRiepilogo();
            btnUPB.Enabled = true;
            FiltraSelezioneUPB(null);			
			azzeraTxtConsolidato();
			btnSituazione.Enabled = true;
			NoUpbSelected=true;
            AbilitaBottoni(false);
		}

        private void pulisciTextRiepilogo() {
            txtPrevInizialeCompetenza.Text = "";
            txtVarPrevCompetenza.Text = "";
            txtImpegniCompetenza.Text = "";
            txtPrevDispCompetenza.Text = "";
            txtPrevInizialeCassa.Text = "";
            txtVarPrevisioneCassa.Text = "";
            txtPagamenti.Text = "";
            txtPagamenti1.Text = "";
            txtPrevDispCassa.Text = "";
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

            txtTotaleCassa.Text = "";
            txtTotaleCrediti.Text = "";
            txtPrevAttualeCompetenza.Text = "";
            txtPrevAttualeCassa.Text = "";
        }

		private void azzeraTxtConsolidato() {
			string empty = "";
			txtPrevisionePrincipaleCorrConsolidato.Text = empty;
			txtPrevisioneSecondariaCorrConsolidato.Text = empty;
			txtPrevisionePrincipalePrecConsolidato.Text = empty;
			txtPrevisioneSecondariaPrecConsolidato.Text = empty;
			txtResiduiCorrConsolidato.Text = empty;
			txtResiduiPrecConsolidato.Text = empty;
			txtPrevisione2Consolidato.Text = empty;
			txtPrevisione3Consolidato.Text = empty;
			txtPrevisione4Consolidato.Text = empty;
			txtPrevisione5Consolidato.Text = empty;
		}

		public void MetaData_AfterFill() {
			if (Meta.InsertMode) {
				azzeraTxtConsolidato();
				btnSituazione.Enabled = false;
                AbilitaBottoni(false);                
			}
			else {
				azzeraTxtConsolidato();
				btnSituazione.Enabled = true;
                AbilitaBottoni(true);
			}
            AbilitaSezioniRiepilogo();
		}

		public void MetaData_BeforeFill() {
			if (!Meta.InsertMode) return;
			if (NoUpbSelected){
				FiltraSelezioneUPB(QHS.IsNull("paridupb"));
                pulisciTextRiepilogo();
                CalcFin.Enabled = false;
			}
			else {
				DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
				string filter = QHS.CmpEq("paridupb", Curr["paridupb"]);
                FiltraSelezioneUPB(filter);
                CalcFin.Enabled = true;
                CalcFin.SetMask(Curr["idfin"], Curr["idupb"], DBNull.Value);
			}            

		}

        object GetUpb() {
            return Meta.GetAutoField(txtUPB);
        }
        void SetUPB(DataRow Curr, object idupb) {
            if (Curr != null) Curr["idupb"] = idupb;
          
            Meta.SetAutoField(idupb, txtUPB);
        }

        void FiltraSelezioneUPB(string filter) {
            MetaData.AutoInfo AI = Meta.GetAutoInfo(txtUPB.Name);
            string myfilter = null;
            if (Meta.InsertMode) myfilter = QHS.FieldNotInList("idupb", QHS.DistinctVal(DS.finyearview.Select(), "idupb"));
            filter = QHS.AppAnd(myfilter, filter);
            AI.startfilter = filter;

            btnUPB.Tag = "choose.upb.default." + filter;
        }

        //private void leggiUPB(string filter) {
        //    Meta.myHelpForm.DisableAutoEvents();
        //    object selectedIDUPB = GetUpb();
			

        //    DataTable tabellaDelCombo = (DataTable)cmbUpb.DataSource;
        //    QueryCreator.MyClear(tabellaDelCombo);
        //    GetData.Add_Blank_Row(tabellaDelCombo);
        //    foreach(DataRow drUpb in DS.upb.Select(filter)) {
        //        // Se esiste già una imputazione per l'UPB selezionato non devo inserirlo nel combo in caso di inserimento
        //        if (Meta.InsertMode) {
        //            DataRow [] rowFin = DS.finyearview.Select(QHC.CmpEq("idupb", drUpb["idupb"]));
        //            if (rowFin.Length > 0) continue;
        //        }
        //        DataRow drCombo = tabellaDelCombo.NewRow();
        //        foreach(DataColumn C in DS.upb.Columns) {
        //            drCombo[C.ColumnName] = drUpb[C];
        //        }
        //        tabellaDelCombo.Rows.Add(drCombo);
        //    }

        //    SetUPB(selectedIDUPB);

        //    Meta.myHelpForm.EnableAutoEvents();
        //}

		private void calcolaConsolidato() {
     	    DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) {
                azzeraTxtConsolidato();
                return;
            }
            

			decimal previsioneCorr = 0;
			decimal previsioneSecCorr = 0;
			decimal previsionePrec = 0;
			decimal previsioneSecPrec = 0;
			decimal residuiCorr = 0;
			decimal residuiPrec = 0;
			decimal previsioneAnno2 = 0;
			decimal previsioneAnno3 = 0;
			decimal previsioneAnno4 = 0;
			decimal previsioneAnno5 = 0;
			string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", Curr["idupb"]), "(paridupb LIKE '" + Curr["idupb"] + "%')"));
            filtro = QHS.AppAnd(filtro,QHS.CmpEq("idfin",MAIN_idfin));
            string expr = "";
            foreach (string field in new string[]{"prevision","secondaryprev","previousprevision","previoussecondaryprev",
                            "currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5"}) {
                if (expr != "") expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable T = Conn.SQLRunner("SELECT "+expr+" FROM finyearview WHERE "+filtro, false);

			foreach(DataRow rFinYear in T.Select()) {
				previsioneCorr += (decimal)isNull(rFinYear["prevision"],0m);
				previsioneSecCorr += (decimal)isNull(rFinYear["secondaryprev"],0m);
				previsionePrec += (decimal)isNull(rFinYear["previousprevision"],0m);
				previsioneSecPrec += (decimal)isNull(rFinYear["previoussecondaryprev"],0m);
				residuiCorr += (decimal)isNull(rFinYear["currentarrears"],0m);
				residuiPrec += (decimal)isNull(rFinYear["previousarrears"],0m);
				previsioneAnno2 += (decimal)isNull(rFinYear["prevision2"],0m);
				previsioneAnno3 += (decimal)isNull(rFinYear["prevision3"],0m);
				previsioneAnno4 += (decimal)isNull(rFinYear["prevision4"],0m);
				previsioneAnno5 += (decimal)isNull(rFinYear["prevision5"],0m);
			}
			txtPrevisionePrincipaleCorrConsolidato.Text = previsioneCorr.ToString("c");
			txtPrevisioneSecondariaCorrConsolidato.Text = previsioneSecCorr.ToString("c");
			txtPrevisionePrincipalePrecConsolidato.Text = previsionePrec.ToString("c");
			txtPrevisioneSecondariaPrecConsolidato.Text = previsioneSecPrec.ToString("c");
			txtResiduiCorrConsolidato.Text = residuiCorr.ToString("c");
			txtResiduiPrecConsolidato.Text = residuiPrec.ToString("c");
			txtPrevisione2Consolidato.Text = previsioneAnno2.ToString("c");
			txtPrevisione3Consolidato.Text = previsioneAnno3.ToString("c");
			txtPrevisione4Consolidato.Text = previsioneAnno4.ToString("c");
			txtPrevisione5Consolidato.Text = previsioneAnno5.ToString("c");
		}

		private object isNull(object a, object b) {
			return ((a == null) || (a == DBNull.Value))	? b : a;
		}

		/// <summary>
		/// Metodo esclude i campi della vista FINYEARVIEW non appartenenti alla tabella FINYEAR in fase di salvataggio
		/// e li reinclude dopo aver salvato
		/// </summary>
		/// <param name="salva">TRUE: Campi salvabili; FALSE: Campi non salvabili</param>
		private void impostaCampiDaSalvare(bool salva) {
            string[] listacampi = new string[] {"finance", "codefin","paridfin","upb","codeupb","paridupb",
                        "nlevel","idsor01","idsor02","idsor03","idsor04","idsor05"};
			if (!salva) {
				string empty = "";
                foreach(string field in listacampi){
				    QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field],empty);
                }
            }
			else {
                foreach (string field in listacampi) {
                    QueryCreator.SetColumnNameForPosting(DS.finyearview.Columns[field], field);
                }
            }
		}

		public void MetaData_BeforePost() {
			impostaCampiDaSalvare(false);
		}

		public void MetaData_AfterPost() {
			impostaCampiDaSalvare(true);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
			if (T.TableName == "upb") {
				if (Meta.InsertMode) {
					if (R == null) return;
					Curr["codeupb"] = R["codeupb"];
					Curr["upb"] = R["title"];
					Curr["paridupb"] = R["paridupb"];
				}
			}
			if (T.TableName == "finyearview") {
                pulisciTextRiepilogo();
				abilitaDisabilitaInserimento();
				FiltraSelezioneUPB(null);
                if (Curr != null) {
                    SetUPB(Curr, Curr["idupb"]);
                    CalcFin.Enabled = true;
                    CalcFin.SetMask(Curr["idfin"], Curr["idupb"], DBNull.Value);
                }
                else {
                    SetUPB(null, DBNull.Value);
                    CalcFin.Enabled = false;
                }
				
				azzeraTxtConsolidato();
			}
		}

		/// <summary>
		/// Abilita / Disabilita l'icona di inserimento (se siamo su di un nodo foglia Insert è disabilitato altrimenti è abilitato)
		/// </summary>
		private void abilitaDisabilitaInserimento() {
			DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
			string filter;
			if (Curr==null || NoUpbSelected){
                filter = QHS.IsNull("paridupb");
			}
			else {
                filter = QHS.CmpEq("paridupb", Curr["idupb"]);
			}
            DataTable Childs = Conn.RUN_SELECT("upb", "idupb", null, filter, null, false);
			DataRow [] nFigli = Childs.Select();
			int NOK=0;
			foreach(DataRow drUpb in nFigli) {
				// Se esiste già una imputazione per l'UPB selezionato non devo inserirlo nel combo in caso di inserimento
				DataRow [] rowFin = DS.finyearview.Select(QHS.CmpEq("idupb", drUpb["idupb"]));
				if (rowFin.Length > 0) continue;
				NOK++;
			}

			Meta.CanInsert = (NOK >= 1) && isBilancioOperativo;
			Meta.FreshToolBar();
		}

		

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finyearview_default));
            this.DS = new finyearview_default.vistaForm();
            this.tabInterno = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpPrevisione = new System.Windows.Forms.GroupBox();
            this.gboxPrimaPrevisione = new System.Windows.Forms.GroupBox();
            this.txtPrevisionePrincipalePrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisionePrincipaleCorrUpb = new System.Windows.Forms.TextBox();
            this.lblEsCorrentePrima = new System.Windows.Forms.Label();
            this.lblEsPrecPrima = new System.Windows.Forms.Label();
            this.grpPrevSec = new System.Windows.Forms.GroupBox();
            this.txtPrevisioneSecondariaPrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisioneSecondariaCorrUpb = new System.Windows.Forms.TextBox();
            this.lblEsCorrSeconda = new System.Windows.Forms.Label();
            this.lblEsPrecSeconda = new System.Windows.Forms.Label();
            this.gboxRipartizione = new System.Windows.Forms.GroupBox();
            this.txtResiduiPrecUpb = new System.Windows.Forms.TextBox();
            this.txtResiduiCorrUpb = new System.Windows.Forms.TextBox();
            this.lblRipCorrente = new System.Windows.Forms.Label();
            this.lblRipPrecedente = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtPrevisione5Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione4Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione3Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione2Upb = new System.Windows.Forms.TextBox();
            this.lblPrevisione5 = new System.Windows.Forms.Label();
            this.lblPrevisione4 = new System.Windows.Forms.Label();
            this.lblPrevisione2 = new System.Windows.Forms.Label();
            this.lblPrevisione3 = new System.Windows.Forms.Label();
            this.TabConsolidato = new System.Windows.Forms.TabPage();
            this.btnCalcola = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtPrevisionePrincipalePrecConsolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisionePrincipaleCorrConsolidato = new System.Windows.Forms.TextBox();
            this.lblEsCorrPrincCons = new System.Windows.Forms.Label();
            this.lblEsPrecPrincCons = new System.Windows.Forms.Label();
            this.grpPrevSecCons = new System.Windows.Forms.GroupBox();
            this.txtPrevisioneSecondariaPrecConsolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisioneSecondariaCorrConsolidato = new System.Windows.Forms.TextBox();
            this.lblEsCorrSecCons = new System.Windows.Forms.Label();
            this.lblEsPrecSecCons = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtResiduiPrecConsolidato = new System.Windows.Forms.TextBox();
            this.txtResiduiCorrConsolidato = new System.Windows.Forms.TextBox();
            this.lblRipCorrCons = new System.Windows.Forms.Label();
            this.lblRipPrecCons = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtPrevisione5Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione4Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione3Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione2Consolidato = new System.Windows.Forms.TextBox();
            this.lblPrev5Cons = new System.Windows.Forms.Label();
            this.lblPrev4Cons = new System.Windows.Forms.Label();
            this.lblPrev2Cons = new System.Windows.Forms.Label();
            this.lblPrev3Cons = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUpbChilds = new System.Windows.Forms.CheckBox();
            this.btnCalcolaTotali = new System.Windows.Forms.Button();
            this.tabControlRiepilogo = new System.Windows.Forms.TabControl();
            this.tabCompetenza = new System.Windows.Forms.TabPage();
            this.grpPrevCompetenza = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrevAttualeCompetenza = new System.Windows.Forms.TextBox();
            this.btnPiccoleSpeseImp = new System.Windows.Forms.Button();
            this.lblPiccoleSpeseImp = new System.Windows.Forms.Label();
            this.txtPiccoleSpeseImp = new System.Windows.Forms.TextBox();
            this.btnAccertamentiCompetenza = new System.Windows.Forms.Button();
            this.lblAccertamentiCompetenza = new System.Windows.Forms.Label();
            this.txtAccertamentiCompetenza = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVarPrevCompetenza = new System.Windows.Forms.Button();
            this.lblVarPrevCompetenza = new System.Windows.Forms.Label();
            this.txtVarPrevCompetenza = new System.Windows.Forms.TextBox();
            this.lblPrevDispCompetenza = new System.Windows.Forms.Label();
            this.txtPrevDispCompetenza = new System.Windows.Forms.TextBox();
            this.btnImpegniCompetenza = new System.Windows.Forms.Button();
            this.lblImpegniCompetenza = new System.Windows.Forms.Label();
            this.txtImpegniCompetenza = new System.Windows.Forms.TextBox();
            this.btnPrevInizialeCompetenza = new System.Windows.Forms.Button();
            this.lblPrevInizialeCompetenza = new System.Windows.Forms.Label();
            this.txtPrevInizialeCompetenza = new System.Windows.Forms.TextBox();
            this.tabCassa = new System.Windows.Forms.TabPage();
            this.grpPrevCassa = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrevAttualeCassa = new System.Windows.Forms.TextBox();
            this.txtPrevDispCassa = new System.Windows.Forms.TextBox();
            this.btnPiccoleSpesePagamenti = new System.Windows.Forms.Button();
            this.lblPiccoleSpesePagamenti = new System.Windows.Forms.Label();
            this.txtPiccoleSpesePagamenti = new System.Windows.Forms.TextBox();
            this.btnIncassi = new System.Windows.Forms.Button();
            this.lblIncassi = new System.Windows.Forms.Label();
            this.txtIncassi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVarPrevisioneCassa = new System.Windows.Forms.Button();
            this.lblVarPrevisioneCassa = new System.Windows.Forms.Label();
            this.txtVarPrevisioneCassa = new System.Windows.Forms.TextBox();
            this.lblPrevDispCassa = new System.Windows.Forms.Label();
            this.btnPagamenti = new System.Windows.Forms.Button();
            this.lblPagamenti = new System.Windows.Forms.Label();
            this.txtPagamenti = new System.Windows.Forms.TextBox();
            this.btnPrevInizialeCassa = new System.Windows.Forms.Button();
            this.lblPrevInizialeCassa = new System.Windows.Forms.Label();
            this.txtPrevInizialeCassa = new System.Windows.Forms.TextBox();
            this.tabCrediti = new System.Windows.Forms.TabPage();
            this.grpCrediti = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.labelTotaleCrediti = new System.Windows.Forms.Label();
            this.txtTotaleCrediti = new System.Windows.Forms.TextBox();
            this.btnVarDotazioneCrediti = new System.Windows.Forms.Button();
            this.txtVarDotazioneCrediti = new System.Windows.Forms.TextBox();
            this.lblVarDotazioneCrediti = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDotazioneCrediti = new System.Windows.Forms.Button();
            this.lblDotazioneCrediti = new System.Windows.Forms.Label();
            this.txtDotazioneCrediti = new System.Windows.Forms.TextBox();
            this.lblCreditiResidui = new System.Windows.Forms.Label();
            this.txtCreditiResidui = new System.Windows.Forms.TextBox();
            this.btnCreditiAssegnati = new System.Windows.Forms.Button();
            this.lblCreditiAssegnati = new System.Windows.Forms.Label();
            this.txtCreditiAssegnati = new System.Windows.Forms.TextBox();
            this.tabAssCassa = new System.Windows.Forms.TabPage();
            this.grpCassa = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelTotaleCassa = new System.Windows.Forms.Label();
            this.txtTotaleCassa = new System.Windows.Forms.TextBox();
            this.btnPiccoleSpesePagamenti1 = new System.Windows.Forms.Button();
            this.lblPiccoleSpesePagamenti1 = new System.Windows.Forms.Label();
            this.txtPiccoleSpesePagamenti1 = new System.Windows.Forms.TextBox();
            this.btnPagamenti1 = new System.Windows.Forms.Button();
            this.lblPagamenti1 = new System.Windows.Forms.Label();
            this.txtPagamenti1 = new System.Windows.Forms.TextBox();
            this.btnVarDotazioneCassa = new System.Windows.Forms.Button();
            this.txtVarDotazioneCassa = new System.Windows.Forms.TextBox();
            this.lblVarDotazioneCassa = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDotazioneCassa = new System.Windows.Forms.Button();
            this.lblDotazioneCassa = new System.Windows.Forms.Label();
            this.txtDotazioneCassa = new System.Windows.Forms.TextBox();
            this.lblCassaResidua = new System.Windows.Forms.Label();
            this.txtCassaResidua = new System.Windows.Forms.TextBox();
            this.btnAssegnazioniCassa = new System.Windows.Forms.Button();
            this.lblAssegnazioniCassa = new System.Windows.Forms.Label();
            this.txtAssegnazioniCassa = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabInterno.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpPrevisione.SuspendLayout();
            this.gboxPrimaPrevisione.SuspendLayout();
            this.grpPrevSec.SuspendLayout();
            this.gboxRipartizione.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.TabConsolidato.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.grpPrevSecCons.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlRiepilogo.SuspendLayout();
            this.tabCompetenza.SuspendLayout();
            this.grpPrevCompetenza.SuspendLayout();
            this.tabCassa.SuspendLayout();
            this.grpPrevCassa.SuspendLayout();
            this.tabCrediti.SuspendLayout();
            this.grpCrediti.SuspendLayout();
            this.tabAssCassa.SuspendLayout();
            this.grpCassa.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // tabInterno
            // 
            this.tabInterno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabInterno.Controls.Add(this.tabPrincipale);
            this.tabInterno.Controls.Add(this.TabConsolidato);
            this.tabInterno.Controls.Add(this.tabPage1);
            this.tabInterno.Location = new System.Drawing.Point(8, 152);
            this.tabInterno.Name = "tabInterno";
            this.tabInterno.SelectedIndex = 0;
            this.tabInterno.Size = new System.Drawing.Size(582, 426);
            this.tabInterno.TabIndex = 11;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.txtLimite);
            this.tabPrincipale.Controls.Add(this.label13);
            this.tabPrincipale.Controls.Add(this.grpPrevisione);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(668, 329);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(252, 277);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.ReadOnly = true;
            this.txtLimite.Size = new System.Drawing.Size(121, 20);
            this.txtLimite.TabIndex = 7;
            this.txtLimite.Tag = "finyearview.limit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(218, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Limite sulla previsione dell\'intero ramo di UPB";
            // 
            // grpPrevisione
            // 
            this.grpPrevisione.Controls.Add(this.gboxPrimaPrevisione);
            this.grpPrevisione.Controls.Add(this.grpPrevSec);
            this.grpPrevisione.Controls.Add(this.gboxRipartizione);
            this.grpPrevisione.Controls.Add(this.groupBox7);
            this.grpPrevisione.Location = new System.Drawing.Point(8, 8);
            this.grpPrevisione.Name = "grpPrevisione";
            this.grpPrevisione.Size = new System.Drawing.Size(528, 256);
            this.grpPrevisione.TabIndex = 5;
            this.grpPrevisione.TabStop = false;
            this.grpPrevisione.Text = "Bilancio di Previsione";
            // 
            // gboxPrimaPrevisione
            // 
            this.gboxPrimaPrevisione.Controls.Add(this.txtPrevisionePrincipalePrecUpb);
            this.gboxPrimaPrevisione.Controls.Add(this.txtPrevisionePrincipaleCorrUpb);
            this.gboxPrimaPrevisione.Controls.Add(this.lblEsCorrentePrima);
            this.gboxPrimaPrevisione.Controls.Add(this.lblEsPrecPrima);
            this.gboxPrimaPrevisione.Location = new System.Drawing.Point(8, 16);
            this.gboxPrimaPrevisione.Name = "gboxPrimaPrevisione";
            this.gboxPrimaPrevisione.Size = new System.Drawing.Size(512, 48);
            this.gboxPrimaPrevisione.TabIndex = 15;
            this.gboxPrimaPrevisione.TabStop = false;
            this.gboxPrimaPrevisione.Text = "Previsione Principale";
            // 
            // txtPrevisionePrincipalePrecUpb
            // 
            this.txtPrevisionePrincipalePrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisionePrincipalePrecUpb.Name = "txtPrevisionePrincipalePrecUpb";
            this.txtPrevisionePrincipalePrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecUpb.TabIndex = 9;
            this.txtPrevisionePrincipalePrecUpb.Tag = "finyearview.previousprevision";
            // 
            // txtPrevisionePrincipaleCorrUpb
            // 
            this.txtPrevisionePrincipaleCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisionePrincipaleCorrUpb.Name = "txtPrevisionePrincipaleCorrUpb";
            this.txtPrevisionePrincipaleCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipaleCorrUpb.TabIndex = 8;
            this.txtPrevisionePrincipaleCorrUpb.Tag = "finyearview.prevision";
            // 
            // lblEsCorrentePrima
            // 
            this.lblEsCorrentePrima.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrentePrima.Name = "lblEsCorrentePrima";
            this.lblEsCorrentePrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrentePrima.TabIndex = 5;
            this.lblEsCorrentePrima.Text = "Prev. Corr.";
            this.lblEsCorrentePrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecPrima
            // 
            this.lblEsPrecPrima.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecPrima.Name = "lblEsPrecPrima";
            this.lblEsPrecPrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecPrima.TabIndex = 7;
            this.lblEsPrecPrima.Text = "Prev. Prec.";
            this.lblEsPrecPrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPrevSec
            // 
            this.grpPrevSec.Controls.Add(this.txtPrevisioneSecondariaPrecUpb);
            this.grpPrevSec.Controls.Add(this.txtPrevisioneSecondariaCorrUpb);
            this.grpPrevSec.Controls.Add(this.lblEsCorrSeconda);
            this.grpPrevSec.Controls.Add(this.lblEsPrecSeconda);
            this.grpPrevSec.Location = new System.Drawing.Point(8, 64);
            this.grpPrevSec.Name = "grpPrevSec";
            this.grpPrevSec.Size = new System.Drawing.Size(512, 48);
            this.grpPrevSec.TabIndex = 16;
            this.grpPrevSec.TabStop = false;
            this.grpPrevSec.Text = "Previsione Secondaria";
            // 
            // txtPrevisioneSecondariaPrecUpb
            // 
            this.txtPrevisioneSecondariaPrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisioneSecondariaPrecUpb.Name = "txtPrevisioneSecondariaPrecUpb";
            this.txtPrevisioneSecondariaPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaPrecUpb.TabIndex = 10;
            this.txtPrevisioneSecondariaPrecUpb.Tag = "finyearview.previoussecondaryprev";
            // 
            // txtPrevisioneSecondariaCorrUpb
            // 
            this.txtPrevisioneSecondariaCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisioneSecondariaCorrUpb.Name = "txtPrevisioneSecondariaCorrUpb";
            this.txtPrevisioneSecondariaCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaCorrUpb.TabIndex = 9;
            this.txtPrevisioneSecondariaCorrUpb.Tag = "finyearview.secondaryprev";
            // 
            // lblEsCorrSeconda
            // 
            this.lblEsCorrSeconda.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrSeconda.Name = "lblEsCorrSeconda";
            this.lblEsCorrSeconda.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrSeconda.TabIndex = 6;
            this.lblEsCorrSeconda.Text = "Prev. Corr.";
            this.lblEsCorrSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecSeconda
            // 
            this.lblEsPrecSeconda.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecSeconda.Name = "lblEsPrecSeconda";
            this.lblEsPrecSeconda.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecSeconda.TabIndex = 8;
            this.lblEsPrecSeconda.Text = "Prev. Prec.";
            this.lblEsPrecSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxRipartizione
            // 
            this.gboxRipartizione.Controls.Add(this.txtResiduiPrecUpb);
            this.gboxRipartizione.Controls.Add(this.txtResiduiCorrUpb);
            this.gboxRipartizione.Controls.Add(this.lblRipCorrente);
            this.gboxRipartizione.Controls.Add(this.lblRipPrecedente);
            this.gboxRipartizione.Location = new System.Drawing.Point(8, 112);
            this.gboxRipartizione.Name = "gboxRipartizione";
            this.gboxRipartizione.Size = new System.Drawing.Size(512, 48);
            this.gboxRipartizione.TabIndex = 17;
            this.gboxRipartizione.TabStop = false;
            this.gboxRipartizione.Text = "Residui anno precedente";
            // 
            // txtResiduiPrecUpb
            // 
            this.txtResiduiPrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtResiduiPrecUpb.Name = "txtResiduiPrecUpb";
            this.txtResiduiPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiPrecUpb.TabIndex = 12;
            this.txtResiduiPrecUpb.Tag = "finyearview.previousarrears";
            // 
            // txtResiduiCorrUpb
            // 
            this.txtResiduiCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtResiduiCorrUpb.Name = "txtResiduiCorrUpb";
            this.txtResiduiCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiCorrUpb.TabIndex = 11;
            this.txtResiduiCorrUpb.Tag = "finyearview.currentarrears";
            // 
            // lblRipCorrente
            // 
            this.lblRipCorrente.Location = new System.Drawing.Point(8, 24);
            this.lblRipCorrente.Name = "lblRipCorrente";
            this.lblRipCorrente.Size = new System.Drawing.Size(100, 16);
            this.lblRipCorrente.TabIndex = 9;
            this.lblRipCorrente.Text = "Presunti del 2005";
            this.lblRipCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRipPrecedente
            // 
            this.lblRipPrecedente.Location = new System.Drawing.Point(288, 24);
            this.lblRipPrecedente.Name = "lblRipPrecedente";
            this.lblRipPrecedente.Size = new System.Drawing.Size(100, 16);
            this.lblRipPrecedente.TabIndex = 10;
            this.lblRipPrecedente.Text = "Presunti del 2004";
            this.lblRipPrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtPrevisione5Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione4Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione3Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione2Upb);
            this.groupBox7.Controls.Add(this.lblPrevisione5);
            this.groupBox7.Controls.Add(this.lblPrevisione4);
            this.groupBox7.Controls.Add(this.lblPrevisione2);
            this.groupBox7.Controls.Add(this.lblPrevisione3);
            this.groupBox7.Location = new System.Drawing.Point(8, 160);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(512, 88);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Previsione esercizi futuri";
            // 
            // txtPrevisione5Upb
            // 
            this.txtPrevisione5Upb.Location = new System.Drawing.Point(400, 58);
            this.txtPrevisione5Upb.Name = "txtPrevisione5Upb";
            this.txtPrevisione5Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Upb.TabIndex = 18;
            this.txtPrevisione5Upb.Tag = "finyearview.prevision5";
            // 
            // txtPrevisione4Upb
            // 
            this.txtPrevisione4Upb.Location = new System.Drawing.Point(120, 56);
            this.txtPrevisione4Upb.Name = "txtPrevisione4Upb";
            this.txtPrevisione4Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione4Upb.TabIndex = 17;
            this.txtPrevisione4Upb.Tag = "finyearview.prevision4";
            // 
            // txtPrevisione3Upb
            // 
            this.txtPrevisione3Upb.Location = new System.Drawing.Point(400, 16);
            this.txtPrevisione3Upb.Name = "txtPrevisione3Upb";
            this.txtPrevisione3Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione3Upb.TabIndex = 16;
            this.txtPrevisione3Upb.Tag = "finyearview.prevision3";
            // 
            // txtPrevisione2Upb
            // 
            this.txtPrevisione2Upb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisione2Upb.Name = "txtPrevisione2Upb";
            this.txtPrevisione2Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione2Upb.TabIndex = 15;
            this.txtPrevisione2Upb.Tag = "finyearview.prevision2";
            // 
            // lblPrevisione5
            // 
            this.lblPrevisione5.Location = new System.Drawing.Point(288, 64);
            this.lblPrevisione5.Name = "lblPrevisione5";
            this.lblPrevisione5.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione5.TabIndex = 14;
            this.lblPrevisione5.Text = "n+4";
            this.lblPrevisione5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione4
            // 
            this.lblPrevisione4.Location = new System.Drawing.Point(8, 56);
            this.lblPrevisione4.Name = "lblPrevisione4";
            this.lblPrevisione4.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione4.TabIndex = 13;
            this.lblPrevisione4.Text = "n+3";
            this.lblPrevisione4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione2
            // 
            this.lblPrevisione2.Location = new System.Drawing.Point(8, 24);
            this.lblPrevisione2.Name = "lblPrevisione2";
            this.lblPrevisione2.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione2.TabIndex = 11;
            this.lblPrevisione2.Text = "n+1";
            this.lblPrevisione2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrevisione3
            // 
            this.lblPrevisione3.Location = new System.Drawing.Point(288, 24);
            this.lblPrevisione3.Name = "lblPrevisione3";
            this.lblPrevisione3.Size = new System.Drawing.Size(100, 16);
            this.lblPrevisione3.TabIndex = 12;
            this.lblPrevisione3.Text = "n+2";
            this.lblPrevisione3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabConsolidato
            // 
            this.TabConsolidato.Controls.Add(this.btnCalcola);
            this.TabConsolidato.Controls.Add(this.groupBox3);
            this.TabConsolidato.Location = new System.Drawing.Point(4, 22);
            this.TabConsolidato.Name = "TabConsolidato";
            this.TabConsolidato.Size = new System.Drawing.Size(668, 329);
            this.TabConsolidato.TabIndex = 1;
            this.TabConsolidato.Text = "Consolidato";
            this.TabConsolidato.Visible = false;
            // 
            // btnCalcola
            // 
            this.btnCalcola.Location = new System.Drawing.Point(235, 280);
            this.btnCalcola.Name = "btnCalcola";
            this.btnCalcola.Size = new System.Drawing.Size(75, 23);
            this.btnCalcola.TabIndex = 13;
            this.btnCalcola.Text = "Calcola";
            this.btnCalcola.Click += new System.EventHandler(this.btnCalcola_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.grpPrevSecCons);
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.groupBox11);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 266);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bilancio di Previsione";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtPrevisionePrincipalePrecConsolidato);
            this.groupBox8.Controls.Add(this.txtPrevisionePrincipaleCorrConsolidato);
            this.groupBox8.Controls.Add(this.lblEsCorrPrincCons);
            this.groupBox8.Controls.Add(this.lblEsPrecPrincCons);
            this.groupBox8.Location = new System.Drawing.Point(8, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(512, 48);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Previsione Principale";
            // 
            // txtPrevisionePrincipalePrecConsolidato
            // 
            this.txtPrevisionePrincipalePrecConsolidato.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisionePrincipalePrecConsolidato.Name = "txtPrevisionePrincipalePrecConsolidato";
            this.txtPrevisionePrincipalePrecConsolidato.ReadOnly = true;
            this.txtPrevisionePrincipalePrecConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecConsolidato.TabIndex = 9;
            this.txtPrevisionePrincipalePrecConsolidato.TabStop = false;
            this.txtPrevisionePrincipalePrecConsolidato.Tag = "";
            this.txtPrevisionePrincipalePrecConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisionePrincipaleCorrConsolidato
            // 
            this.txtPrevisionePrincipaleCorrConsolidato.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisionePrincipaleCorrConsolidato.Name = "txtPrevisionePrincipaleCorrConsolidato";
            this.txtPrevisionePrincipaleCorrConsolidato.ReadOnly = true;
            this.txtPrevisionePrincipaleCorrConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipaleCorrConsolidato.TabIndex = 8;
            this.txtPrevisionePrincipaleCorrConsolidato.TabStop = false;
            this.txtPrevisionePrincipaleCorrConsolidato.Tag = "";
            this.txtPrevisionePrincipaleCorrConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsCorrPrincCons
            // 
            this.lblEsCorrPrincCons.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrPrincCons.Name = "lblEsCorrPrincCons";
            this.lblEsCorrPrincCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrPrincCons.TabIndex = 5;
            this.lblEsCorrPrincCons.Text = "Prev. Corr.";
            this.lblEsCorrPrincCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecPrincCons
            // 
            this.lblEsPrecPrincCons.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecPrincCons.Name = "lblEsPrecPrincCons";
            this.lblEsPrecPrincCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecPrincCons.TabIndex = 7;
            this.lblEsPrecPrincCons.Text = "Prev. Prec.";
            this.lblEsPrecPrincCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPrevSecCons
            // 
            this.grpPrevSecCons.Controls.Add(this.txtPrevisioneSecondariaPrecConsolidato);
            this.grpPrevSecCons.Controls.Add(this.txtPrevisioneSecondariaCorrConsolidato);
            this.grpPrevSecCons.Controls.Add(this.lblEsCorrSecCons);
            this.grpPrevSecCons.Controls.Add(this.lblEsPrecSecCons);
            this.grpPrevSecCons.Location = new System.Drawing.Point(8, 64);
            this.grpPrevSecCons.Name = "grpPrevSecCons";
            this.grpPrevSecCons.Size = new System.Drawing.Size(512, 48);
            this.grpPrevSecCons.TabIndex = 16;
            this.grpPrevSecCons.TabStop = false;
            this.grpPrevSecCons.Text = "Previsione Secondaria";
            // 
            // txtPrevisioneSecondariaPrecConsolidato
            // 
            this.txtPrevisioneSecondariaPrecConsolidato.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisioneSecondariaPrecConsolidato.Name = "txtPrevisioneSecondariaPrecConsolidato";
            this.txtPrevisioneSecondariaPrecConsolidato.ReadOnly = true;
            this.txtPrevisioneSecondariaPrecConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaPrecConsolidato.TabIndex = 10;
            this.txtPrevisioneSecondariaPrecConsolidato.TabStop = false;
            this.txtPrevisioneSecondariaPrecConsolidato.Tag = "";
            this.txtPrevisioneSecondariaPrecConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisioneSecondariaCorrConsolidato
            // 
            this.txtPrevisioneSecondariaCorrConsolidato.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisioneSecondariaCorrConsolidato.Name = "txtPrevisioneSecondariaCorrConsolidato";
            this.txtPrevisioneSecondariaCorrConsolidato.ReadOnly = true;
            this.txtPrevisioneSecondariaCorrConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaCorrConsolidato.TabIndex = 9;
            this.txtPrevisioneSecondariaCorrConsolidato.TabStop = false;
            this.txtPrevisioneSecondariaCorrConsolidato.Tag = "";
            this.txtPrevisioneSecondariaCorrConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsCorrSecCons
            // 
            this.lblEsCorrSecCons.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrSecCons.Name = "lblEsCorrSecCons";
            this.lblEsCorrSecCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrSecCons.TabIndex = 6;
            this.lblEsCorrSecCons.Text = "Prev. Corr.";
            this.lblEsCorrSecCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecSecCons
            // 
            this.lblEsPrecSecCons.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecSecCons.Name = "lblEsPrecSecCons";
            this.lblEsPrecSecCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecSecCons.TabIndex = 8;
            this.lblEsPrecSecCons.Text = "Prev. Prec.";
            this.lblEsPrecSecCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtResiduiPrecConsolidato);
            this.groupBox10.Controls.Add(this.txtResiduiCorrConsolidato);
            this.groupBox10.Controls.Add(this.lblRipCorrCons);
            this.groupBox10.Controls.Add(this.lblRipPrecCons);
            this.groupBox10.Location = new System.Drawing.Point(8, 112);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(512, 48);
            this.groupBox10.TabIndex = 17;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Residui anno precedente";
            // 
            // txtResiduiPrecConsolidato
            // 
            this.txtResiduiPrecConsolidato.Location = new System.Drawing.Point(400, 22);
            this.txtResiduiPrecConsolidato.Name = "txtResiduiPrecConsolidato";
            this.txtResiduiPrecConsolidato.ReadOnly = true;
            this.txtResiduiPrecConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiPrecConsolidato.TabIndex = 12;
            this.txtResiduiPrecConsolidato.TabStop = false;
            this.txtResiduiPrecConsolidato.Tag = "";
            this.txtResiduiPrecConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtResiduiCorrConsolidato
            // 
            this.txtResiduiCorrConsolidato.Location = new System.Drawing.Point(120, 22);
            this.txtResiduiCorrConsolidato.Name = "txtResiduiCorrConsolidato";
            this.txtResiduiCorrConsolidato.ReadOnly = true;
            this.txtResiduiCorrConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiCorrConsolidato.TabIndex = 11;
            this.txtResiduiCorrConsolidato.TabStop = false;
            this.txtResiduiCorrConsolidato.Tag = "";
            this.txtResiduiCorrConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRipCorrCons
            // 
            this.lblRipCorrCons.Location = new System.Drawing.Point(8, 24);
            this.lblRipCorrCons.Name = "lblRipCorrCons";
            this.lblRipCorrCons.Size = new System.Drawing.Size(100, 16);
            this.lblRipCorrCons.TabIndex = 9;
            this.lblRipCorrCons.Text = "Presunti del 2005";
            this.lblRipCorrCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRipPrecCons
            // 
            this.lblRipPrecCons.Location = new System.Drawing.Point(288, 24);
            this.lblRipPrecCons.Name = "lblRipPrecCons";
            this.lblRipPrecCons.Size = new System.Drawing.Size(100, 16);
            this.lblRipPrecCons.TabIndex = 10;
            this.lblRipPrecCons.Text = "Effettivi del 2004";
            this.lblRipPrecCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtPrevisione5Consolidato);
            this.groupBox11.Controls.Add(this.txtPrevisione4Consolidato);
            this.groupBox11.Controls.Add(this.txtPrevisione3Consolidato);
            this.groupBox11.Controls.Add(this.txtPrevisione2Consolidato);
            this.groupBox11.Controls.Add(this.lblPrev5Cons);
            this.groupBox11.Controls.Add(this.lblPrev4Cons);
            this.groupBox11.Controls.Add(this.lblPrev2Cons);
            this.groupBox11.Controls.Add(this.lblPrev3Cons);
            this.groupBox11.Location = new System.Drawing.Point(8, 160);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(512, 96);
            this.groupBox11.TabIndex = 18;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Previsione esercizi futuri";
            // 
            // txtPrevisione5Consolidato
            // 
            this.txtPrevisione5Consolidato.Location = new System.Drawing.Point(400, 58);
            this.txtPrevisione5Consolidato.Name = "txtPrevisione5Consolidato";
            this.txtPrevisione5Consolidato.ReadOnly = true;
            this.txtPrevisione5Consolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Consolidato.TabIndex = 18;
            this.txtPrevisione5Consolidato.TabStop = false;
            this.txtPrevisione5Consolidato.Tag = "";
            this.txtPrevisione5Consolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisione4Consolidato
            // 
            this.txtPrevisione4Consolidato.Location = new System.Drawing.Point(120, 57);
            this.txtPrevisione4Consolidato.Name = "txtPrevisione4Consolidato";
            this.txtPrevisione4Consolidato.ReadOnly = true;
            this.txtPrevisione4Consolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione4Consolidato.TabIndex = 17;
            this.txtPrevisione4Consolidato.TabStop = false;
            this.txtPrevisione4Consolidato.Tag = "";
            this.txtPrevisione4Consolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisione3Consolidato
            // 
            this.txtPrevisione3Consolidato.Location = new System.Drawing.Point(399, 18);
            this.txtPrevisione3Consolidato.Name = "txtPrevisione3Consolidato";
            this.txtPrevisione3Consolidato.ReadOnly = true;
            this.txtPrevisione3Consolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione3Consolidato.TabIndex = 16;
            this.txtPrevisione3Consolidato.TabStop = false;
            this.txtPrevisione3Consolidato.Tag = "";
            this.txtPrevisione3Consolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisione2Consolidato
            // 
            this.txtPrevisione2Consolidato.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisione2Consolidato.Name = "txtPrevisione2Consolidato";
            this.txtPrevisione2Consolidato.ReadOnly = true;
            this.txtPrevisione2Consolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione2Consolidato.TabIndex = 15;
            this.txtPrevisione2Consolidato.TabStop = false;
            this.txtPrevisione2Consolidato.Tag = "";
            this.txtPrevisione2Consolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrev5Cons
            // 
            this.lblPrev5Cons.Location = new System.Drawing.Point(296, 60);
            this.lblPrev5Cons.Name = "lblPrev5Cons";
            this.lblPrev5Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev5Cons.TabIndex = 14;
            this.lblPrev5Cons.Text = "Previsione 2009";
            this.lblPrev5Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev4Cons
            // 
            this.lblPrev4Cons.Location = new System.Drawing.Point(16, 59);
            this.lblPrev4Cons.Name = "lblPrev4Cons";
            this.lblPrev4Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev4Cons.TabIndex = 13;
            this.lblPrev4Cons.Text = "Previsione 2008";
            this.lblPrev4Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev2Cons
            // 
            this.lblPrev2Cons.Location = new System.Drawing.Point(16, 24);
            this.lblPrev2Cons.Name = "lblPrev2Cons";
            this.lblPrev2Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev2Cons.TabIndex = 11;
            this.lblPrev2Cons.Text = "Previsione 2006";
            this.lblPrev2Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev3Cons
            // 
            this.lblPrev3Cons.Location = new System.Drawing.Point(295, 21);
            this.lblPrev3Cons.Name = "lblPrev3Cons";
            this.lblPrev3Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev3Cons.TabIndex = 12;
            this.lblPrev3Cons.Text = "Previsione 2007";
            this.lblPrev3Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUpbChilds);
            this.tabPage1.Controls.Add(this.btnCalcolaTotali);
            this.tabPage1.Controls.Add(this.tabControlRiepilogo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 400);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Riepilogo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUpbChilds
            // 
            this.chkUpbChilds.AutoSize = true;
            this.chkUpbChilds.Location = new System.Drawing.Point(8, 14);
            this.chkUpbChilds.Name = "chkUpbChilds";
            this.chkUpbChilds.Size = new System.Drawing.Size(285, 17);
            this.chkUpbChilds.TabIndex = 68;
            this.chkUpbChilds.Text = "Considera anche gli UPB sottostanti nei dati di riepilogo";
            this.chkUpbChilds.UseVisualStyleBackColor = true;
            this.chkUpbChilds.CheckedChanged += new System.EventHandler(this.chkUpbChilds_CheckedChanged);
            // 
            // btnCalcolaTotali
            // 
            this.btnCalcolaTotali.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcolaTotali.Location = new System.Drawing.Point(463, 6);
            this.btnCalcolaTotali.Name = "btnCalcolaTotali";
            this.btnCalcolaTotali.Size = new System.Drawing.Size(105, 25);
            this.btnCalcolaTotali.TabIndex = 59;
            this.btnCalcolaTotali.Text = "Calcola totali";
            this.btnCalcolaTotali.UseVisualStyleBackColor = true;
            this.btnCalcolaTotali.Click += new System.EventHandler(this.btnCalcolaTotali_Click);
            // 
            // tabControlRiepilogo
            // 
            this.tabControlRiepilogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlRiepilogo.Controls.Add(this.tabCompetenza);
            this.tabControlRiepilogo.Controls.Add(this.tabCassa);
            this.tabControlRiepilogo.Controls.Add(this.tabCrediti);
            this.tabControlRiepilogo.Controls.Add(this.tabAssCassa);
            this.tabControlRiepilogo.Location = new System.Drawing.Point(3, 37);
            this.tabControlRiepilogo.Name = "tabControlRiepilogo";
            this.tabControlRiepilogo.SelectedIndex = 0;
            this.tabControlRiepilogo.Size = new System.Drawing.Size(565, 357);
            this.tabControlRiepilogo.TabIndex = 58;
            // 
            // tabCompetenza
            // 
            this.tabCompetenza.Controls.Add(this.grpPrevCompetenza);
            this.tabCompetenza.Location = new System.Drawing.Point(4, 22);
            this.tabCompetenza.Name = "tabCompetenza";
            this.tabCompetenza.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompetenza.Size = new System.Drawing.Size(557, 331);
            this.tabCompetenza.TabIndex = 0;
            this.tabCompetenza.Text = "Previsione di competenza";
            this.tabCompetenza.UseVisualStyleBackColor = true;
            // 
            // grpPrevCompetenza
            // 
            this.grpPrevCompetenza.Controls.Add(this.label7);
            this.grpPrevCompetenza.Controls.Add(this.label6);
            this.grpPrevCompetenza.Controls.Add(this.txtPrevAttualeCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.btnPiccoleSpeseImp);
            this.grpPrevCompetenza.Controls.Add(this.lblPiccoleSpeseImp);
            this.grpPrevCompetenza.Controls.Add(this.txtPiccoleSpeseImp);
            this.grpPrevCompetenza.Controls.Add(this.btnAccertamentiCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.lblAccertamentiCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtAccertamentiCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.label3);
            this.grpPrevCompetenza.Controls.Add(this.btnVarPrevCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.lblVarPrevCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtVarPrevCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.lblPrevDispCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtPrevDispCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.btnImpegniCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.lblImpegniCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtImpegniCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.btnPrevInizialeCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.lblPrevInizialeCompetenza);
            this.grpPrevCompetenza.Controls.Add(this.txtPrevInizialeCompetenza);
            this.grpPrevCompetenza.Location = new System.Drawing.Point(6, 6);
            this.grpPrevCompetenza.Name = "grpPrevCompetenza";
            this.grpPrevCompetenza.Size = new System.Drawing.Size(485, 284);
            this.grpPrevCompetenza.TabIndex = 56;
            this.grpPrevCompetenza.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "= A + B";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Previsione  attuale di Competenza";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCompetenza
            // 
            this.txtPrevAttualeCompetenza.Location = new System.Drawing.Point(220, 77);
            this.txtPrevAttualeCompetenza.Name = "txtPrevAttualeCompetenza";
            this.txtPrevAttualeCompetenza.ReadOnly = true;
            this.txtPrevAttualeCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtPrevAttualeCompetenza.TabIndex = 14;
            this.txtPrevAttualeCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPiccoleSpeseImp
            // 
            this.btnPiccoleSpeseImp.Location = new System.Drawing.Point(347, 165);
            this.btnPiccoleSpeseImp.Name = "btnPiccoleSpeseImp";
            this.btnPiccoleSpeseImp.Size = new System.Drawing.Size(75, 20);
            this.btnPiccoleSpeseImp.TabIndex = 12;
            this.btnPiccoleSpeseImp.Text = "D ";
            this.btnPiccoleSpeseImp.UseVisualStyleBackColor = true;
            this.btnPiccoleSpeseImp.Click += new System.EventHandler(this.btnPiccoleSpeseImp_Click);
            // 
            // lblPiccoleSpeseImp
            // 
            this.lblPiccoleSpeseImp.Location = new System.Drawing.Point(16, 168);
            this.lblPiccoleSpeseImp.Name = "lblPiccoleSpeseImp";
            this.lblPiccoleSpeseImp.Size = new System.Drawing.Size(198, 13);
            this.lblPiccoleSpeseImp.TabIndex = 10;
            this.lblPiccoleSpeseImp.Text = "Piccole spese non reintegrate";
            this.lblPiccoleSpeseImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPiccoleSpeseImp
            // 
            this.txtPiccoleSpeseImp.Location = new System.Drawing.Point(220, 166);
            this.txtPiccoleSpeseImp.Name = "txtPiccoleSpeseImp";
            this.txtPiccoleSpeseImp.ReadOnly = true;
            this.txtPiccoleSpeseImp.Size = new System.Drawing.Size(121, 20);
            this.txtPiccoleSpeseImp.TabIndex = 11;
            this.txtPiccoleSpeseImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAccertamentiCompetenza
            // 
            this.btnAccertamentiCompetenza.Location = new System.Drawing.Point(347, 138);
            this.btnAccertamentiCompetenza.Name = "btnAccertamentiCompetenza";
            this.btnAccertamentiCompetenza.Size = new System.Drawing.Size(75, 20);
            this.btnAccertamentiCompetenza.TabIndex = 7;
            this.btnAccertamentiCompetenza.Text = "C";
            this.btnAccertamentiCompetenza.UseVisualStyleBackColor = true;
            this.btnAccertamentiCompetenza.Click += new System.EventHandler(this.btnAccertamentiCompetenza_Click);
            // 
            // lblAccertamentiCompetenza
            // 
            this.lblAccertamentiCompetenza.Location = new System.Drawing.Point(16, 139);
            this.lblAccertamentiCompetenza.Name = "lblAccertamentiCompetenza";
            this.lblAccertamentiCompetenza.Size = new System.Drawing.Size(198, 13);
            this.lblAccertamentiCompetenza.TabIndex = 0;
            this.lblAccertamentiCompetenza.Text = "Accertamenti  di Competenza";
            this.lblAccertamentiCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccertamentiCompetenza
            // 
            this.txtAccertamentiCompetenza.Location = new System.Drawing.Point(220, 137);
            this.txtAccertamentiCompetenza.Name = "txtAccertamentiCompetenza";
            this.txtAccertamentiCompetenza.ReadOnly = true;
            this.txtAccertamentiCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtAccertamentiCompetenza.TabIndex = 6;
            this.txtAccertamentiCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "E = A + B - C - D";
            // 
            // btnVarPrevCompetenza
            // 
            this.btnVarPrevCompetenza.Location = new System.Drawing.Point(347, 43);
            this.btnVarPrevCompetenza.Name = "btnVarPrevCompetenza";
            this.btnVarPrevCompetenza.Size = new System.Drawing.Size(75, 20);
            this.btnVarPrevCompetenza.TabIndex = 3;
            this.btnVarPrevCompetenza.Text = "B";
            this.btnVarPrevCompetenza.UseVisualStyleBackColor = true;
            this.btnVarPrevCompetenza.Click += new System.EventHandler(this.btnVarPrevCompetenza_Click);
            // 
            // lblVarPrevCompetenza
            // 
            this.lblVarPrevCompetenza.Location = new System.Drawing.Point(16, 45);
            this.lblVarPrevCompetenza.Name = "lblVarPrevCompetenza";
            this.lblVarPrevCompetenza.Size = new System.Drawing.Size(198, 13);
            this.lblVarPrevCompetenza.TabIndex = 0;
            this.lblVarPrevCompetenza.Text = "Variazione Previsione  di Competenza";
            this.lblVarPrevCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevCompetenza
            // 
            this.txtVarPrevCompetenza.Location = new System.Drawing.Point(220, 43);
            this.txtVarPrevCompetenza.Name = "txtVarPrevCompetenza";
            this.txtVarPrevCompetenza.ReadOnly = true;
            this.txtVarPrevCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtVarPrevCompetenza.TabIndex = 2;
            this.txtVarPrevCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCompetenza
            // 
            this.lblPrevDispCompetenza.Location = new System.Drawing.Point(16, 197);
            this.lblPrevDispCompetenza.Name = "lblPrevDispCompetenza";
            this.lblPrevDispCompetenza.Size = new System.Drawing.Size(198, 13);
            this.lblPrevDispCompetenza.TabIndex = 0;
            this.lblPrevDispCompetenza.Text = "Previsione Disponibile di Competenza";
            this.lblPrevDispCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevDispCompetenza
            // 
            this.txtPrevDispCompetenza.Location = new System.Drawing.Point(220, 195);
            this.txtPrevDispCompetenza.Name = "txtPrevDispCompetenza";
            this.txtPrevDispCompetenza.ReadOnly = true;
            this.txtPrevDispCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtPrevDispCompetenza.TabIndex = 8;
            this.txtPrevDispCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImpegniCompetenza
            // 
            this.btnImpegniCompetenza.Location = new System.Drawing.Point(347, 112);
            this.btnImpegniCompetenza.Name = "btnImpegniCompetenza";
            this.btnImpegniCompetenza.Size = new System.Drawing.Size(75, 20);
            this.btnImpegniCompetenza.TabIndex = 5;
            this.btnImpegniCompetenza.Text = "C";
            this.btnImpegniCompetenza.UseVisualStyleBackColor = true;
            this.btnImpegniCompetenza.Click += new System.EventHandler(this.btnImpegniCompetenza_Click);
            // 
            // lblImpegniCompetenza
            // 
            this.lblImpegniCompetenza.Location = new System.Drawing.Point(16, 113);
            this.lblImpegniCompetenza.Name = "lblImpegniCompetenza";
            this.lblImpegniCompetenza.Size = new System.Drawing.Size(198, 13);
            this.lblImpegniCompetenza.TabIndex = 0;
            this.lblImpegniCompetenza.Text = "Impegni di Competenza";
            this.lblImpegniCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpegniCompetenza
            // 
            this.txtImpegniCompetenza.Location = new System.Drawing.Point(220, 111);
            this.txtImpegniCompetenza.Name = "txtImpegniCompetenza";
            this.txtImpegniCompetenza.ReadOnly = true;
            this.txtImpegniCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtImpegniCompetenza.TabIndex = 4;
            this.txtImpegniCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCompetenza
            // 
            this.btnPrevInizialeCompetenza.Location = new System.Drawing.Point(347, 13);
            this.btnPrevInizialeCompetenza.Name = "btnPrevInizialeCompetenza";
            this.btnPrevInizialeCompetenza.Size = new System.Drawing.Size(75, 20);
            this.btnPrevInizialeCompetenza.TabIndex = 1;
            this.btnPrevInizialeCompetenza.Text = "A";
            this.btnPrevInizialeCompetenza.UseVisualStyleBackColor = true;
            this.btnPrevInizialeCompetenza.Click += new System.EventHandler(this.btnPrevInizialeCompetenza_Click);
            // 
            // lblPrevInizialeCompetenza
            // 
            this.lblPrevInizialeCompetenza.Location = new System.Drawing.Point(16, 16);
            this.lblPrevInizialeCompetenza.Name = "lblPrevInizialeCompetenza";
            this.lblPrevInizialeCompetenza.Size = new System.Drawing.Size(198, 13);
            this.lblPrevInizialeCompetenza.TabIndex = 0;
            this.lblPrevInizialeCompetenza.Text = "Previsione Iniziale di Competenza";
            this.lblPrevInizialeCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCompetenza
            // 
            this.txtPrevInizialeCompetenza.Location = new System.Drawing.Point(220, 14);
            this.txtPrevInizialeCompetenza.Name = "txtPrevInizialeCompetenza";
            this.txtPrevInizialeCompetenza.ReadOnly = true;
            this.txtPrevInizialeCompetenza.Size = new System.Drawing.Size(121, 20);
            this.txtPrevInizialeCompetenza.TabIndex = 0;
            this.txtPrevInizialeCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabCassa
            // 
            this.tabCassa.Controls.Add(this.grpPrevCassa);
            this.tabCassa.Location = new System.Drawing.Point(4, 22);
            this.tabCassa.Name = "tabCassa";
            this.tabCassa.Padding = new System.Windows.Forms.Padding(3);
            this.tabCassa.Size = new System.Drawing.Size(557, 331);
            this.tabCassa.TabIndex = 1;
            this.tabCassa.Text = "Previsione di cassa";
            this.tabCassa.UseVisualStyleBackColor = true;
            // 
            // grpPrevCassa
            // 
            this.grpPrevCassa.Controls.Add(this.label8);
            this.grpPrevCassa.Controls.Add(this.label9);
            this.grpPrevCassa.Controls.Add(this.txtPrevAttualeCassa);
            this.grpPrevCassa.Controls.Add(this.txtPrevDispCassa);
            this.grpPrevCassa.Controls.Add(this.btnPiccoleSpesePagamenti);
            this.grpPrevCassa.Controls.Add(this.lblPiccoleSpesePagamenti);
            this.grpPrevCassa.Controls.Add(this.txtPiccoleSpesePagamenti);
            this.grpPrevCassa.Controls.Add(this.btnIncassi);
            this.grpPrevCassa.Controls.Add(this.lblIncassi);
            this.grpPrevCassa.Controls.Add(this.txtIncassi);
            this.grpPrevCassa.Controls.Add(this.label4);
            this.grpPrevCassa.Controls.Add(this.btnVarPrevisioneCassa);
            this.grpPrevCassa.Controls.Add(this.lblVarPrevisioneCassa);
            this.grpPrevCassa.Controls.Add(this.txtVarPrevisioneCassa);
            this.grpPrevCassa.Controls.Add(this.lblPrevDispCassa);
            this.grpPrevCassa.Controls.Add(this.btnPagamenti);
            this.grpPrevCassa.Controls.Add(this.lblPagamenti);
            this.grpPrevCassa.Controls.Add(this.txtPagamenti);
            this.grpPrevCassa.Controls.Add(this.btnPrevInizialeCassa);
            this.grpPrevCassa.Controls.Add(this.lblPrevInizialeCassa);
            this.grpPrevCassa.Controls.Add(this.txtPrevInizialeCassa);
            this.grpPrevCassa.Location = new System.Drawing.Point(6, 6);
            this.grpPrevCassa.Name = "grpPrevCassa";
            this.grpPrevCassa.Size = new System.Drawing.Size(482, 281);
            this.grpPrevCassa.TabIndex = 0;
            this.grpPrevCassa.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "= F + G";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(9, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Previsione  attuale di Cassa";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCassa
            // 
            this.txtPrevAttualeCassa.Location = new System.Drawing.Point(210, 65);
            this.txtPrevAttualeCassa.Name = "txtPrevAttualeCassa";
            this.txtPrevAttualeCassa.ReadOnly = true;
            this.txtPrevAttualeCassa.Size = new System.Drawing.Size(121, 20);
            this.txtPrevAttualeCassa.TabIndex = 19;
            this.txtPrevAttualeCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevDispCassa
            // 
            this.txtPrevDispCassa.Location = new System.Drawing.Point(208, 179);
            this.txtPrevDispCassa.Name = "txtPrevDispCassa";
            this.txtPrevDispCassa.ReadOnly = true;
            this.txtPrevDispCassa.Size = new System.Drawing.Size(122, 20);
            this.txtPrevDispCassa.TabIndex = 17;
            this.txtPrevDispCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPiccoleSpesePagamenti
            // 
            this.btnPiccoleSpesePagamenti.Location = new System.Drawing.Point(343, 154);
            this.btnPiccoleSpesePagamenti.Name = "btnPiccoleSpesePagamenti";
            this.btnPiccoleSpesePagamenti.Size = new System.Drawing.Size(75, 20);
            this.btnPiccoleSpesePagamenti.TabIndex = 15;
            this.btnPiccoleSpesePagamenti.Text = " I ";
            this.btnPiccoleSpesePagamenti.UseVisualStyleBackColor = true;
            this.btnPiccoleSpesePagamenti.Click += new System.EventHandler(this.btnPiccoleSpesePagamenti_Click);
            // 
            // lblPiccoleSpesePagamenti
            // 
            this.lblPiccoleSpesePagamenti.Location = new System.Drawing.Point(13, 156);
            this.lblPiccoleSpesePagamenti.Name = "lblPiccoleSpesePagamenti";
            this.lblPiccoleSpesePagamenti.Size = new System.Drawing.Size(182, 13);
            this.lblPiccoleSpesePagamenti.TabIndex = 13;
            this.lblPiccoleSpesePagamenti.Text = "Piccole spese non reintegrate";
            this.lblPiccoleSpesePagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPiccoleSpesePagamenti
            // 
            this.txtPiccoleSpesePagamenti.Location = new System.Drawing.Point(208, 153);
            this.txtPiccoleSpesePagamenti.Name = "txtPiccoleSpesePagamenti";
            this.txtPiccoleSpesePagamenti.ReadOnly = true;
            this.txtPiccoleSpesePagamenti.Size = new System.Drawing.Size(122, 20);
            this.txtPiccoleSpesePagamenti.TabIndex = 14;
            this.txtPiccoleSpesePagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnIncassi
            // 
            this.btnIncassi.Location = new System.Drawing.Point(343, 127);
            this.btnIncassi.Name = "btnIncassi";
            this.btnIncassi.Size = new System.Drawing.Size(75, 20);
            this.btnIncassi.TabIndex = 7;
            this.btnIncassi.Text = "H";
            this.btnIncassi.UseVisualStyleBackColor = true;
            this.btnIncassi.Click += new System.EventHandler(this.btnIncassi_Click);
            // 
            // lblIncassi
            // 
            this.lblIncassi.Location = new System.Drawing.Point(13, 129);
            this.lblIncassi.Name = "lblIncassi";
            this.lblIncassi.Size = new System.Drawing.Size(182, 13);
            this.lblIncassi.TabIndex = 0;
            this.lblIncassi.Text = "Incassi";
            this.lblIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIncassi
            // 
            this.txtIncassi.Location = new System.Drawing.Point(208, 126);
            this.txtIncassi.Name = "txtIncassi";
            this.txtIncassi.ReadOnly = true;
            this.txtIncassi.Size = new System.Drawing.Size(122, 20);
            this.txtIncassi.TabIndex = 6;
            this.txtIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "L = F + G - H - I";
            // 
            // btnVarPrevisioneCassa
            // 
            this.btnVarPrevisioneCassa.Location = new System.Drawing.Point(343, 35);
            this.btnVarPrevisioneCassa.Name = "btnVarPrevisioneCassa";
            this.btnVarPrevisioneCassa.Size = new System.Drawing.Size(75, 20);
            this.btnVarPrevisioneCassa.TabIndex = 3;
            this.btnVarPrevisioneCassa.Text = "G";
            this.btnVarPrevisioneCassa.UseVisualStyleBackColor = true;
            this.btnVarPrevisioneCassa.Click += new System.EventHandler(this.btnVarPrevisioneCassa_Click);
            // 
            // lblVarPrevisioneCassa
            // 
            this.lblVarPrevisioneCassa.Location = new System.Drawing.Point(13, 37);
            this.lblVarPrevisioneCassa.Name = "lblVarPrevisioneCassa";
            this.lblVarPrevisioneCassa.Size = new System.Drawing.Size(182, 13);
            this.lblVarPrevisioneCassa.TabIndex = 0;
            this.lblVarPrevisioneCassa.Text = "Variazione Previsione  di Cassa";
            this.lblVarPrevisioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevisioneCassa
            // 
            this.txtVarPrevisioneCassa.Location = new System.Drawing.Point(208, 34);
            this.txtVarPrevisioneCassa.Name = "txtVarPrevisioneCassa";
            this.txtVarPrevisioneCassa.ReadOnly = true;
            this.txtVarPrevisioneCassa.Size = new System.Drawing.Size(122, 20);
            this.txtVarPrevisioneCassa.TabIndex = 2;
            this.txtVarPrevisioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCassa
            // 
            this.lblPrevDispCassa.Location = new System.Drawing.Point(13, 182);
            this.lblPrevDispCassa.Name = "lblPrevDispCassa";
            this.lblPrevDispCassa.Size = new System.Drawing.Size(182, 13);
            this.lblPrevDispCassa.TabIndex = 0;
            this.lblPrevDispCassa.Text = "Previsione Disponibile di Cassa";
            this.lblPrevDispCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPagamenti
            // 
            this.btnPagamenti.Location = new System.Drawing.Point(343, 102);
            this.btnPagamenti.Name = "btnPagamenti";
            this.btnPagamenti.Size = new System.Drawing.Size(75, 20);
            this.btnPagamenti.TabIndex = 5;
            this.btnPagamenti.Text = "H";
            this.btnPagamenti.UseVisualStyleBackColor = true;
            this.btnPagamenti.Click += new System.EventHandler(this.btnPagamenti_Click);
            // 
            // lblPagamenti
            // 
            this.lblPagamenti.Location = new System.Drawing.Point(13, 107);
            this.lblPagamenti.Name = "lblPagamenti";
            this.lblPagamenti.Size = new System.Drawing.Size(182, 13);
            this.lblPagamenti.TabIndex = 0;
            this.lblPagamenti.Text = "Pagamenti";
            this.lblPagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPagamenti
            // 
            this.txtPagamenti.Location = new System.Drawing.Point(208, 100);
            this.txtPagamenti.Name = "txtPagamenti";
            this.txtPagamenti.ReadOnly = true;
            this.txtPagamenti.Size = new System.Drawing.Size(122, 20);
            this.txtPagamenti.TabIndex = 4;
            this.txtPagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCassa
            // 
            this.btnPrevInizialeCassa.Location = new System.Drawing.Point(343, 9);
            this.btnPrevInizialeCassa.Name = "btnPrevInizialeCassa";
            this.btnPrevInizialeCassa.Size = new System.Drawing.Size(75, 20);
            this.btnPrevInizialeCassa.TabIndex = 1;
            this.btnPrevInizialeCassa.Text = "F";
            this.btnPrevInizialeCassa.UseVisualStyleBackColor = true;
            this.btnPrevInizialeCassa.Click += new System.EventHandler(this.btnPrevInizialeCassa_Click);
            // 
            // lblPrevInizialeCassa
            // 
            this.lblPrevInizialeCassa.Location = new System.Drawing.Point(13, 11);
            this.lblPrevInizialeCassa.Name = "lblPrevInizialeCassa";
            this.lblPrevInizialeCassa.Size = new System.Drawing.Size(182, 13);
            this.lblPrevInizialeCassa.TabIndex = 0;
            this.lblPrevInizialeCassa.Text = "Previsione Iniziale di Cassa";
            this.lblPrevInizialeCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCassa
            // 
            this.txtPrevInizialeCassa.Location = new System.Drawing.Point(208, 8);
            this.txtPrevInizialeCassa.Name = "txtPrevInizialeCassa";
            this.txtPrevInizialeCassa.ReadOnly = true;
            this.txtPrevInizialeCassa.Size = new System.Drawing.Size(122, 20);
            this.txtPrevInizialeCassa.TabIndex = 0;
            this.txtPrevInizialeCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabCrediti
            // 
            this.tabCrediti.Controls.Add(this.grpCrediti);
            this.tabCrediti.Location = new System.Drawing.Point(4, 22);
            this.tabCrediti.Name = "tabCrediti";
            this.tabCrediti.Size = new System.Drawing.Size(651, 260);
            this.tabCrediti.TabIndex = 2;
            this.tabCrediti.Text = "Assegnazione crediti";
            this.tabCrediti.UseVisualStyleBackColor = true;
            // 
            // grpCrediti
            // 
            this.grpCrediti.Controls.Add(this.label11);
            this.grpCrediti.Controls.Add(this.labelTotaleCrediti);
            this.grpCrediti.Controls.Add(this.txtTotaleCrediti);
            this.grpCrediti.Controls.Add(this.btnVarDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.txtVarDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.lblVarDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.label5);
            this.grpCrediti.Controls.Add(this.btnDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.lblDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.txtDotazioneCrediti);
            this.grpCrediti.Controls.Add(this.lblCreditiResidui);
            this.grpCrediti.Controls.Add(this.txtCreditiResidui);
            this.grpCrediti.Controls.Add(this.btnCreditiAssegnati);
            this.grpCrediti.Controls.Add(this.lblCreditiAssegnati);
            this.grpCrediti.Controls.Add(this.txtCreditiAssegnati);
            this.grpCrediti.Location = new System.Drawing.Point(11, 3);
            this.grpCrediti.Name = "grpCrediti";
            this.grpCrediti.Size = new System.Drawing.Size(480, 203);
            this.grpCrediti.TabIndex = 0;
            this.grpCrediti.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(349, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "= M + N + O";
            // 
            // labelTotaleCrediti
            // 
            this.labelTotaleCrediti.Location = new System.Drawing.Point(19, 105);
            this.labelTotaleCrediti.Name = "labelTotaleCrediti";
            this.labelTotaleCrediti.Size = new System.Drawing.Size(148, 13);
            this.labelTotaleCrediti.TabIndex = 9;
            this.labelTotaleCrediti.Text = "Totale Crediti";
            this.labelTotaleCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotaleCrediti
            // 
            this.txtTotaleCrediti.Location = new System.Drawing.Point(188, 102);
            this.txtTotaleCrediti.Name = "txtTotaleCrediti";
            this.txtTotaleCrediti.ReadOnly = true;
            this.txtTotaleCrediti.Size = new System.Drawing.Size(149, 20);
            this.txtTotaleCrediti.TabIndex = 10;
            this.txtTotaleCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVarDotazioneCrediti
            // 
            this.btnVarDotazioneCrediti.Location = new System.Drawing.Point(349, 42);
            this.btnVarDotazioneCrediti.Name = "btnVarDotazioneCrediti";
            this.btnVarDotazioneCrediti.Size = new System.Drawing.Size(78, 20);
            this.btnVarDotazioneCrediti.TabIndex = 8;
            this.btnVarDotazioneCrediti.Text = "N";
            this.btnVarDotazioneCrediti.UseVisualStyleBackColor = true;
            this.btnVarDotazioneCrediti.Click += new System.EventHandler(this.btnVarDotazioneCrediti_Click);
            // 
            // txtVarDotazioneCrediti
            // 
            this.txtVarDotazioneCrediti.Location = new System.Drawing.Point(188, 42);
            this.txtVarDotazioneCrediti.Name = "txtVarDotazioneCrediti";
            this.txtVarDotazioneCrediti.ReadOnly = true;
            this.txtVarDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
            this.txtVarDotazioneCrediti.TabIndex = 7;
            this.txtVarDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVarDotazioneCrediti
            // 
            this.lblVarDotazioneCrediti.Location = new System.Drawing.Point(19, 45);
            this.lblVarDotazioneCrediti.Name = "lblVarDotazioneCrediti";
            this.lblVarDotazioneCrediti.Size = new System.Drawing.Size(148, 13);
            this.lblVarDotazioneCrediti.TabIndex = 6;
            this.lblVarDotazioneCrediti.Text = "Var. Dotazione Crediti";
            this.lblVarDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "P = M + N + O - C - D";
            // 
            // btnDotazioneCrediti
            // 
            this.btnDotazioneCrediti.Location = new System.Drawing.Point(349, 13);
            this.btnDotazioneCrediti.Name = "btnDotazioneCrediti";
            this.btnDotazioneCrediti.Size = new System.Drawing.Size(78, 20);
            this.btnDotazioneCrediti.TabIndex = 1;
            this.btnDotazioneCrediti.Text = "M";
            this.btnDotazioneCrediti.UseVisualStyleBackColor = true;
            this.btnDotazioneCrediti.Click += new System.EventHandler(this.btnDotazioneCrediti_Click);
            // 
            // lblDotazioneCrediti
            // 
            this.lblDotazioneCrediti.Location = new System.Drawing.Point(19, 16);
            this.lblDotazioneCrediti.Name = "lblDotazioneCrediti";
            this.lblDotazioneCrediti.Size = new System.Drawing.Size(148, 13);
            this.lblDotazioneCrediti.TabIndex = 0;
            this.lblDotazioneCrediti.Text = "Dotazione Iniziale Crediti";
            this.lblDotazioneCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDotazioneCrediti
            // 
            this.txtDotazioneCrediti.Location = new System.Drawing.Point(188, 13);
            this.txtDotazioneCrediti.Name = "txtDotazioneCrediti";
            this.txtDotazioneCrediti.ReadOnly = true;
            this.txtDotazioneCrediti.Size = new System.Drawing.Size(149, 20);
            this.txtDotazioneCrediti.TabIndex = 0;
            this.txtDotazioneCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCreditiResidui
            // 
            this.lblCreditiResidui.Location = new System.Drawing.Point(19, 146);
            this.lblCreditiResidui.Name = "lblCreditiResidui";
            this.lblCreditiResidui.Size = new System.Drawing.Size(148, 13);
            this.lblCreditiResidui.TabIndex = 0;
            this.lblCreditiResidui.Text = "Crediti Residui";
            this.lblCreditiResidui.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreditiResidui
            // 
            this.txtCreditiResidui.Location = new System.Drawing.Point(188, 143);
            this.txtCreditiResidui.Name = "txtCreditiResidui";
            this.txtCreditiResidui.ReadOnly = true;
            this.txtCreditiResidui.Size = new System.Drawing.Size(149, 20);
            this.txtCreditiResidui.TabIndex = 4;
            this.txtCreditiResidui.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCreditiAssegnati
            // 
            this.btnCreditiAssegnati.Location = new System.Drawing.Point(349, 70);
            this.btnCreditiAssegnati.Name = "btnCreditiAssegnati";
            this.btnCreditiAssegnati.Size = new System.Drawing.Size(78, 20);
            this.btnCreditiAssegnati.TabIndex = 3;
            this.btnCreditiAssegnati.Text = "O";
            this.btnCreditiAssegnati.UseVisualStyleBackColor = true;
            this.btnCreditiAssegnati.Click += new System.EventHandler(this.btnCreditiAssegnati_Click);
            // 
            // lblCreditiAssegnati
            // 
            this.lblCreditiAssegnati.Location = new System.Drawing.Point(19, 72);
            this.lblCreditiAssegnati.Name = "lblCreditiAssegnati";
            this.lblCreditiAssegnati.Size = new System.Drawing.Size(148, 13);
            this.lblCreditiAssegnati.TabIndex = 0;
            this.lblCreditiAssegnati.Text = "Totale Assegnazioni di Crediti";
            this.lblCreditiAssegnati.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreditiAssegnati
            // 
            this.txtCreditiAssegnati.Location = new System.Drawing.Point(188, 69);
            this.txtCreditiAssegnati.Name = "txtCreditiAssegnati";
            this.txtCreditiAssegnati.ReadOnly = true;
            this.txtCreditiAssegnati.Size = new System.Drawing.Size(149, 20);
            this.txtCreditiAssegnati.TabIndex = 2;
            this.txtCreditiAssegnati.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabAssCassa
            // 
            this.tabAssCassa.Controls.Add(this.grpCassa);
            this.tabAssCassa.Location = new System.Drawing.Point(4, 22);
            this.tabAssCassa.Name = "tabAssCassa";
            this.tabAssCassa.Size = new System.Drawing.Size(651, 260);
            this.tabAssCassa.TabIndex = 3;
            this.tabAssCassa.Text = "Assegnazioni di cassa";
            this.tabAssCassa.UseVisualStyleBackColor = true;
            // 
            // grpCassa
            // 
            this.grpCassa.Controls.Add(this.label12);
            this.grpCassa.Controls.Add(this.labelTotaleCassa);
            this.grpCassa.Controls.Add(this.txtTotaleCassa);
            this.grpCassa.Controls.Add(this.btnPiccoleSpesePagamenti1);
            this.grpCassa.Controls.Add(this.lblPiccoleSpesePagamenti1);
            this.grpCassa.Controls.Add(this.txtPiccoleSpesePagamenti1);
            this.grpCassa.Controls.Add(this.btnPagamenti1);
            this.grpCassa.Controls.Add(this.lblPagamenti1);
            this.grpCassa.Controls.Add(this.txtPagamenti1);
            this.grpCassa.Controls.Add(this.btnVarDotazioneCassa);
            this.grpCassa.Controls.Add(this.txtVarDotazioneCassa);
            this.grpCassa.Controls.Add(this.lblVarDotazioneCassa);
            this.grpCassa.Controls.Add(this.label10);
            this.grpCassa.Controls.Add(this.btnDotazioneCassa);
            this.grpCassa.Controls.Add(this.lblDotazioneCassa);
            this.grpCassa.Controls.Add(this.txtDotazioneCassa);
            this.grpCassa.Controls.Add(this.lblCassaResidua);
            this.grpCassa.Controls.Add(this.txtCassaResidua);
            this.grpCassa.Controls.Add(this.btnAssegnazioniCassa);
            this.grpCassa.Controls.Add(this.lblAssegnazioniCassa);
            this.grpCassa.Controls.Add(this.txtAssegnazioniCassa);
            this.grpCassa.Location = new System.Drawing.Point(3, 3);
            this.grpCassa.Name = "grpCassa";
            this.grpCassa.Size = new System.Drawing.Size(488, 252);
            this.grpCassa.TabIndex = 3;
            this.grpCassa.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(365, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "= Q + R + S";
            // 
            // labelTotaleCassa
            // 
            this.labelTotaleCassa.Location = new System.Drawing.Point(50, 101);
            this.labelTotaleCassa.Name = "labelTotaleCassa";
            this.labelTotaleCassa.Size = new System.Drawing.Size(148, 13);
            this.labelTotaleCassa.TabIndex = 22;
            this.labelTotaleCassa.Text = "Totale Cassa";
            this.labelTotaleCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotaleCassa
            // 
            this.txtTotaleCassa.Location = new System.Drawing.Point(204, 98);
            this.txtTotaleCassa.Name = "txtTotaleCassa";
            this.txtTotaleCassa.ReadOnly = true;
            this.txtTotaleCassa.Size = new System.Drawing.Size(149, 20);
            this.txtTotaleCassa.TabIndex = 23;
            this.txtTotaleCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPiccoleSpesePagamenti1
            // 
            this.btnPiccoleSpesePagamenti1.Location = new System.Drawing.Point(359, 168);
            this.btnPiccoleSpesePagamenti1.Name = "btnPiccoleSpesePagamenti1";
            this.btnPiccoleSpesePagamenti1.Size = new System.Drawing.Size(75, 20);
            this.btnPiccoleSpesePagamenti1.TabIndex = 18;
            this.btnPiccoleSpesePagamenti1.Text = "U";
            this.btnPiccoleSpesePagamenti1.UseVisualStyleBackColor = true;
            this.btnPiccoleSpesePagamenti1.Click += new System.EventHandler(this.btnPiccoleSpesePagamenti1_Click);
            // 
            // lblPiccoleSpesePagamenti1
            // 
            this.lblPiccoleSpesePagamenti1.Location = new System.Drawing.Point(6, 164);
            this.lblPiccoleSpesePagamenti1.Name = "lblPiccoleSpesePagamenti1";
            this.lblPiccoleSpesePagamenti1.Size = new System.Drawing.Size(192, 13);
            this.lblPiccoleSpesePagamenti1.TabIndex = 16;
            this.lblPiccoleSpesePagamenti1.Text = "Piccole spese non reintegrate";
            this.lblPiccoleSpesePagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPiccoleSpesePagamenti1
            // 
            this.txtPiccoleSpesePagamenti1.Location = new System.Drawing.Point(204, 168);
            this.txtPiccoleSpesePagamenti1.Name = "txtPiccoleSpesePagamenti1";
            this.txtPiccoleSpesePagamenti1.ReadOnly = true;
            this.txtPiccoleSpesePagamenti1.Size = new System.Drawing.Size(149, 20);
            this.txtPiccoleSpesePagamenti1.TabIndex = 17;
            this.txtPiccoleSpesePagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPagamenti1
            // 
            this.btnPagamenti1.Location = new System.Drawing.Point(359, 138);
            this.btnPagamenti1.Name = "btnPagamenti1";
            this.btnPagamenti1.Size = new System.Drawing.Size(75, 20);
            this.btnPagamenti1.TabIndex = 12;
            this.btnPagamenti1.Text = "T";
            this.btnPagamenti1.UseVisualStyleBackColor = true;
            this.btnPagamenti1.Click += new System.EventHandler(this.btnPagamenti1_Click);
            // 
            // lblPagamenti1
            // 
            this.lblPagamenti1.Location = new System.Drawing.Point(6, 138);
            this.lblPagamenti1.Name = "lblPagamenti1";
            this.lblPagamenti1.Size = new System.Drawing.Size(192, 13);
            this.lblPagamenti1.TabIndex = 10;
            this.lblPagamenti1.Text = "Pagamenti";
            this.lblPagamenti1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPagamenti1
            // 
            this.txtPagamenti1.Location = new System.Drawing.Point(204, 138);
            this.txtPagamenti1.Name = "txtPagamenti1";
            this.txtPagamenti1.ReadOnly = true;
            this.txtPagamenti1.Size = new System.Drawing.Size(149, 20);
            this.txtPagamenti1.TabIndex = 11;
            this.txtPagamenti1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVarDotazioneCassa
            // 
            this.btnVarDotazioneCassa.Location = new System.Drawing.Point(359, 38);
            this.btnVarDotazioneCassa.Name = "btnVarDotazioneCassa";
            this.btnVarDotazioneCassa.Size = new System.Drawing.Size(75, 20);
            this.btnVarDotazioneCassa.TabIndex = 9;
            this.btnVarDotazioneCassa.Text = "R";
            this.btnVarDotazioneCassa.UseVisualStyleBackColor = true;
            this.btnVarDotazioneCassa.Click += new System.EventHandler(this.btnVarDotazioneCassa_Click);
            // 
            // txtVarDotazioneCassa
            // 
            this.txtVarDotazioneCassa.Location = new System.Drawing.Point(204, 37);
            this.txtVarDotazioneCassa.Name = "txtVarDotazioneCassa";
            this.txtVarDotazioneCassa.ReadOnly = true;
            this.txtVarDotazioneCassa.Size = new System.Drawing.Size(149, 20);
            this.txtVarDotazioneCassa.TabIndex = 8;
            this.txtVarDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVarDotazioneCassa
            // 
            this.lblVarDotazioneCassa.Location = new System.Drawing.Point(6, 40);
            this.lblVarDotazioneCassa.Name = "lblVarDotazioneCassa";
            this.lblVarDotazioneCassa.Size = new System.Drawing.Size(192, 13);
            this.lblVarDotazioneCassa.TabIndex = 7;
            this.lblVarDotazioneCassa.Text = "Var. Dotazione Cassa";
            this.lblVarDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "V = Q + R + S - T - U";
            // 
            // btnDotazioneCassa
            // 
            this.btnDotazioneCassa.Location = new System.Drawing.Point(359, 13);
            this.btnDotazioneCassa.Name = "btnDotazioneCassa";
            this.btnDotazioneCassa.Size = new System.Drawing.Size(75, 20);
            this.btnDotazioneCassa.TabIndex = 1;
            this.btnDotazioneCassa.Text = "Q";
            this.btnDotazioneCassa.UseVisualStyleBackColor = true;
            this.btnDotazioneCassa.Click += new System.EventHandler(this.btnDotazioneCassa_Click);
            // 
            // lblDotazioneCassa
            // 
            this.lblDotazioneCassa.Location = new System.Drawing.Point(6, 16);
            this.lblDotazioneCassa.Name = "lblDotazioneCassa";
            this.lblDotazioneCassa.Size = new System.Drawing.Size(192, 13);
            this.lblDotazioneCassa.TabIndex = 0;
            this.lblDotazioneCassa.Text = "Dotazione Iniziale Cassa";
            this.lblDotazioneCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDotazioneCassa
            // 
            this.txtDotazioneCassa.Location = new System.Drawing.Point(204, 13);
            this.txtDotazioneCassa.Name = "txtDotazioneCassa";
            this.txtDotazioneCassa.ReadOnly = true;
            this.txtDotazioneCassa.Size = new System.Drawing.Size(149, 20);
            this.txtDotazioneCassa.TabIndex = 0;
            this.txtDotazioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCassaResidua
            // 
            this.lblCassaResidua.Location = new System.Drawing.Point(6, 197);
            this.lblCassaResidua.Name = "lblCassaResidua";
            this.lblCassaResidua.Size = new System.Drawing.Size(192, 13);
            this.lblCassaResidua.TabIndex = 0;
            this.lblCassaResidua.Text = "Assegnazioni di Cassa Residue";
            this.lblCassaResidua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCassaResidua
            // 
            this.txtCassaResidua.Location = new System.Drawing.Point(204, 195);
            this.txtCassaResidua.Name = "txtCassaResidua";
            this.txtCassaResidua.ReadOnly = true;
            this.txtCassaResidua.Size = new System.Drawing.Size(149, 20);
            this.txtCassaResidua.TabIndex = 4;
            this.txtCassaResidua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAssegnazioniCassa
            // 
            this.btnAssegnazioniCassa.Location = new System.Drawing.Point(359, 64);
            this.btnAssegnazioniCassa.Name = "btnAssegnazioniCassa";
            this.btnAssegnazioniCassa.Size = new System.Drawing.Size(75, 20);
            this.btnAssegnazioniCassa.TabIndex = 3;
            this.btnAssegnazioniCassa.Text = "S";
            this.btnAssegnazioniCassa.UseVisualStyleBackColor = true;
            this.btnAssegnazioniCassa.Click += new System.EventHandler(this.btnAssegnazioniCassa_Click);
            // 
            // lblAssegnazioniCassa
            // 
            this.lblAssegnazioniCassa.Location = new System.Drawing.Point(6, 66);
            this.lblAssegnazioniCassa.Name = "lblAssegnazioniCassa";
            this.lblAssegnazioniCassa.Size = new System.Drawing.Size(192, 13);
            this.lblAssegnazioniCassa.TabIndex = 0;
            this.lblAssegnazioniCassa.Text = "Totale Assegnazioni di Cassa";
            this.lblAssegnazioniCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssegnazioniCassa
            // 
            this.txtAssegnazioniCassa.Location = new System.Drawing.Point(204, 63);
            this.txtAssegnazioniCassa.Name = "txtAssegnazioniCassa";
            this.txtAssegnazioniCassa.ReadOnly = true;
            this.txtAssegnazioniCassa.Size = new System.Drawing.Size(149, 20);
            this.txtAssegnazioniCassa.TabIndex = 2;
            this.txtAssegnazioniCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 104);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(676, 48);
            this.gboxUPB.TabIndex = 10;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(12, 17);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(75, 23);
            this.btnUPB.TabIndex = 7;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "choose.upb.default";
            this.btnUPB.Text = "UPB";
            this.btnUPB.UseVisualStyleBackColor = true;
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(105, 19);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(565, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(216, 617);
            this.treeView1.TabIndex = 8;
            this.treeView1.Tag = "finyearview.tree";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSituazione);
            this.groupBox2.Controls.Add(this.txtCodiceBilancio);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDenominazioneBilancio);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(676, 96);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informazioni sulla voce di Bilancio";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(471, 21);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 12;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(128, 24);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.ReadOnly = true;
            this.txtCodiceBilancio.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceBilancio.TabIndex = 2;
            this.txtCodiceBilancio.TabStop = false;
            this.txtCodiceBilancio.Tag = "finyearview.codefin";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 56);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(416, 32);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finyearview.finance";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denominazione";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 617);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabMain);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(219, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(609, 617);
            this.MetaDataDetail.TabIndex = 14;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.gboxUPB);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Controls.Add(this.tabInterno);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(601, 591);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Principale";
            // 
            // Frm_finyearview_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(828, 617);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_finyearview_default";
            this.Text = "Frm_finyearview_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabInterno.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.grpPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.PerformLayout();
            this.grpPrevSec.ResumeLayout(false);
            this.grpPrevSec.PerformLayout();
            this.gboxRipartizione.ResumeLayout(false);
            this.gboxRipartizione.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.TabConsolidato.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.grpPrevSecCons.ResumeLayout(false);
            this.grpPrevSecCons.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControlRiepilogo.ResumeLayout(false);
            this.tabCompetenza.ResumeLayout(false);
            this.grpPrevCompetenza.ResumeLayout(false);
            this.grpPrevCompetenza.PerformLayout();
            this.tabCassa.ResumeLayout(false);
            this.grpPrevCassa.ResumeLayout(false);
            this.grpPrevCassa.PerformLayout();
            this.tabCrediti.ResumeLayout(false);
            this.grpCrediti.ResumeLayout(false);
            this.grpCrediti.PerformLayout();
            this.tabAssCassa.ResumeLayout(false);
            this.grpCassa.ResumeLayout(false);
            this.grpCassa.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
	

		private void btnSituazione_Click(object sender, System.EventArgs e) {
			object idBilancio;
            object idUpb;

			DataRow MyRow = HelpForm.GetLastSelected(DS.finyearview);
			if (MyRow ==null) return;
			idBilancio = MyRow["idfin"];
			idUpb = MyRow["idupb"];

            string finpart = "";
            int flag = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("fin", QHS.CmpEq("idfin", idBilancio), "flag"));
            if ((flag & 1) == 1)
                finpart = "S";
            else
                finpart = "E";

            DataSet Out = Meta.Conn.CallSP("show_finyear",
                new Object[4] {Meta.GetSys("datacontabile"),
								  idUpb, idBilancio, finpart}
                );
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione bilancio di previsione - U.P.B.";
			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

		bool NoUpbSelected=true;
		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			//			if (Meta.IsEmpty)return;
			TreeNode TN = e.Node;
			NoUpbSelected=false;
			if (TN.Tag!=null) return;
			NoUpbSelected=true;
		}

        private void btnCalcola_Click(object sender, EventArgs e) {
            calcolaConsolidato();
        }

        private void btnPrevInizialeCompetenza_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaPrevisioneInizialeCompetenza("");
        }

        private void btnVarPrevCompetenza_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVariazionePrevCompetenza("");
        }

        private void btnImpegniCompetenza_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;

            CalcFin.ElencaImpegniCompetenza();
        }

        private void btnAccertamentiCompetenza_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;

            CalcFin.ElencaAccertamentiCompetenza();
        }

        private void btnPiccoleSpeseImp_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;

            CalcFin.ElencaPiccoleSpeseImp();
        }

        private void btnPrevInizialeCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaPrevInizialeCassa("");
        }

        private void btnVarPrevisioneCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVarPrevisioneCassa("");
        }

        private void btnPagamenti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;

            CalcFin.ElencoPagamenti();
        }

        private void btnIncassi_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaIncassi();
        }

        private void btnPiccoleSpesePagamenti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaPiccoleSpesePag();
        }

        private void btnDotazioneCrediti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVarRipartizioneCrediti();
           
        }

        private void btnVarDotazioneCrediti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVarNormaleCrediti();
        }

        private void btnCreditiAssegnati_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaAssegnazioniCrediti();
        }

        private void btnDotazioneCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVarRipartizioneCassa();
        }

        private void btnVarDotazioneCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaVarNormaleCassa();
        }

        private void btnAssegnazioniCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaAssegnazioniIncassi();
        }

        private void btnPagamenti1_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;

            CalcFin.ElencoPagamenti();
        }

        private void btnPiccoleSpesePagamenti1_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finyearview);
            if (Curr == null) return;
            CalcFin.ElencaPiccoleSpese();
        }

        private void AbilitaBottoni(bool abilita) {

            btnAccertamentiCompetenza.Enabled = abilita;
            btnAssegnazioniCassa.Enabled = abilita;
            btnCreditiAssegnati.Enabled = abilita;
            btnDotazioneCassa.Enabled = abilita;
            btnDotazioneCrediti.Enabled = abilita;
            btnVarDotazioneCrediti.Enabled = abilita;
            btnVarDotazioneCassa.Enabled = abilita;
            btnImpegniCompetenza.Enabled = abilita;
            btnIncassi.Enabled = abilita;
            btnPagamenti.Enabled = abilita;
            btnPagamenti1.Enabled = abilita;
            btnPrevInizialeCassa.Enabled = abilita;
            btnPrevInizialeCompetenza.Enabled = abilita;
            btnVarPrevCompetenza.Enabled = abilita;
            btnVarPrevisioneCassa.Enabled = abilita;
            btnPiccoleSpeseImp.Enabled = abilita; ;
            btnPiccoleSpesePagamenti.Enabled = abilita;
            btnPiccoleSpesePagamenti1.Enabled = abilita;

        }

        private void btnCalcolaTotali_Click(object sender, EventArgs e) {
            CalcolaValoriText();
        }
        private void CalcolaValoriText() {
            DataRow R = HelpForm.GetLastSelected(DS.finyearview);
            if (R == null) return;

            DataRow rFin= DS.fin.Select(QHC.CmpEq("idfin",R["idfin"]))[0];
            int flag = CfgFn.GetNoNullInt32(rFin["flag"]);

            decimal totprevinicomp = CalcFin.TotPrevInizialeCompetenza("");
            txtPrevInizialeCompetenza.Text = totprevinicomp.ToString("C");
            decimal totvarprevcomp = CalcFin.TotVarPrevCompetenza("");
            txtVarPrevCompetenza.Text = totvarprevcomp.ToString("C");
            decimal totPrevComp = totprevinicomp + totvarprevcomp;
            txtPrevAttualeCompetenza.Text = totPrevComp.ToString("C");

            decimal totImpegniCompetenza = CalcFin.TotImpegniCompetenza();
            txtImpegniCompetenza.Text = totImpegniCompetenza.ToString("C");

            decimal totpreviniCassa = CalcFin.TotPrevInizialeCassa("");
            txtPrevInizialeCassa.Text = totpreviniCassa.ToString("C");
            decimal totvatprevCassa = CalcFin.TotVarPrevCassa("");
            txtVarPrevisioneCassa.Text = totvatprevCassa.ToString("C");
            decimal totPrevCassa = totpreviniCassa + totvatprevCassa;
            txtPrevAttualeCassa.Text = totPrevCassa.ToString("C");

            decimal totPagamenti = CalcFin.TotPagamenti();
            txtPagamenti.Text = totPagamenti.ToString("C");
            txtPagamenti1.Text = totPagamenti.ToString("C");

            decimal totPiccoleSpeseImp = CalcFin.TotPiccoleSpeseImp();
            txtPiccoleSpeseImp.Text = totPiccoleSpeseImp.ToString("C");

            decimal totPiccoleSpesePag = CalcFin.TotPiccoleSpesePag();
            txtPiccoleSpesePagamenti.Text = totPiccoleSpesePag.ToString("C");
            txtPiccoleSpesePagamenti1.Text = totPiccoleSpesePag.ToString("C");

            decimal totAccertamentiComp = CalcFin.TotAccertamentiCompetenza();
            txtAccertamentiCompetenza.Text = totAccertamentiComp.ToString("C");

            decimal totIncassi = CalcFin.TotIncassi();
            txtIncassi.Text = totIncassi.ToString("C");


            if ((flag & 1) == 1) // spesa
            {
                txtPrevDispCompetenza.Text = (totPrevComp - totImpegniCompetenza - totPiccoleSpeseImp).ToString("C");
                txtPrevDispCassa.Text = (totPrevCassa - totPagamenti - totPiccoleSpesePag).ToString("C");
            }
            else {
                txtPrevDispCompetenza.Text = (totPrevComp - totAccertamentiComp).ToString("C");
                txtPrevDispCassa.Text = (totPrevCassa - totIncassi).ToString("C");
            }
            decimal totdotCreditiIniziale = CalcFin.TotVarRipartizioneCrediti();
            txtDotazioneCrediti.Text = totdotCreditiIniziale.ToString("C");
            decimal totVarDotCrediti = CalcFin.TotVarNormaleCrediti();
            txtVarDotazioneCrediti.Text = totVarDotCrediti.ToString("C");
            decimal totAssCrediti = CalcFin.TotAssegnazioniCrediti();
            txtCreditiAssegnati.Text = totAssCrediti.ToString("C");
            decimal totaleCrediti = totdotCreditiIniziale + totVarDotCrediti + totAssCrediti;
            txtTotaleCrediti.Text = totaleCrediti.ToString("C");

            txtCreditiResidui.Text = (totaleCrediti - totImpegniCompetenza - totPiccoleSpeseImp).ToString("C");

            decimal totDotinizialeCassa = CalcFin.TotVarRipartizioneCassa();
            txtDotazioneCassa.Text = totDotinizialeCassa.ToString("C");
            decimal totVarDotazioneCassa = CalcFin.TotVarNormaleCassa();
            txtVarDotazioneCassa.Text = totVarDotazioneCassa.ToString("C");
            decimal totAssCassa = CalcFin.TotAssegnazioniIncassi();
            txtAssegnazioniCassa.Text = totAssCassa.ToString("C");
            decimal totaleCassa = totDotinizialeCassa + totVarDotazioneCassa + totAssCassa;
            txtTotaleCassa.Text = totAssCassa.ToString("C");

            txtCassaResidua.Text = (totaleCassa - totPagamenti - totPiccoleSpesePag).ToString("C");

        }
        private void AbilitaSezioniRiepilogo() {
            DataRow R = HelpForm.GetLastSelected(DS.finyearview);
            if (R == null) return;
            DataRow rFin = DS.fin.Select(QHC.CmpEq("idfin", R["idfin"]))[0];
            int flag = CfgFn.GetNoNullInt32(rFin["flag"]);
            if (rFin == null) return;

            grpPrevCompetenza.Enabled = true;
            string what;
            if ((flag & 1) == 1)
                what = "pagamenti";
            else
                what = "incassi";

            string whatnot;
            if ((flag & 1) == 1)
                whatnot = "incassi";
            else
                whatnot = "pagamenti";


            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 1) VisualizzaInTabCassaSolo(what); //competenza
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) grpPrevCompetenza.Visible = false;         //cassa
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 3) VisualizzaInTabCassaTranne(whatnot); //comp e cassa


            object flagcredit = Conn.GetSys("flagcredit");
            if (flagcredit == null) flagcredit = "N";

            object flagproceeds = Conn.GetSys("flagproceeds");
            if (flagproceeds == null) flagproceeds = "N";

            if ((flagcredit.ToString().ToUpper() == "S") && ((flag & 1) == 1)) // spesa
                grpCrediti.Visible = true;
            else
                grpCrediti.Visible = false;

            if ((flagproceeds.ToString().ToUpper() == "S") && ((flag & 1) == 1)) // spesa
            {
                grpCassa.Visible = true;
            }
            else
                grpCassa.Visible = false;

        }

        void VisualizzaInTabCassaSolo(string pattern) {
            foreach (Control C in grpPrevCassa.Controls) {
                if (C.Name.ToLower().Contains(pattern))
                    C.Visible = true;
                else
                    C.Visible = false;
            }
        }
        void VisualizzaInTabCassaTranne(string pattern) {
            foreach (Control C in grpPrevCassa.Controls) {
                if (C.Name.ToLower().Contains(pattern))
                    C.Visible = false;
                else
                    C.Visible = true;
            }
        }

        private void chkUpbChilds_CheckedChanged(object sender, EventArgs e) {
            if (CalcFin == null) return;
            CalcFin.SetUpbWithChilds(chkUpbChilds.Checked);
            pulisciTextRiepilogo();
        }
	}
}
