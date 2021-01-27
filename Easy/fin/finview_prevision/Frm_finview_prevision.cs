
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using SituazioneViewer;
using security_function;

namespace finview_prevision {
	/// <summary>
	/// Summary description for Frm_finview_prevision.
	/// </summary>
	public class Frm_finview_prevision : System.Windows.Forms.Form {
		MetaData Meta;
		decimal lastPrevPrincCorr = 0;
		decimal lastPrevPrincPrec = 0;
		decimal lastPrevSecCorr = 0;
		decimal lastPrevSecPrec = 0;
		decimal lastResCorr = 0;
		decimal lastResPrec = 0;
		public finview_prevision.vistaForm DS;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.GroupBox gboxNoName;
		private System.Windows.Forms.TextBox txtCodiceUpb;
		private System.Windows.Forms.TextBox txtDenominazioneUpb;
		private System.Windows.Forms.GroupBox grpPrevisione;
		private System.Windows.Forms.TextBox txtPrevisionePrincipalePrecUpb;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaPrecUpb;
		private System.Windows.Forms.TextBox txtPrevisioneSecondariaCorrUpb;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TextBox txtResiduiPrecUpb;
		private System.Windows.Forms.TextBox txtResiduiCorrUpb;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.TextBox txtPrevisione5Upb;
		private System.Windows.Forms.TextBox txtPrevisione4Upb;
		private System.Windows.Forms.TextBox txtPrevisione3Upb;
		private System.Windows.Forms.TextBox txtPrevisione2Upb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSituazione;
		private System.Windows.Forms.GroupBox grpPrevSec;
		private System.Windows.Forms.TextBox txtPrevisionePrincipaleCorrUpb;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.GroupBox groupBox2;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RadioButton rdbSpesa;
		private System.Windows.Forms.RadioButton rdbEntrata;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.Label lblprevision5;
		private System.Windows.Forms.Label lblprevision4;
		private System.Windows.Forms.Label lblprevision2;
		private System.Windows.Forms.Label lblprevision3;
		private System.Windows.Forms.Label lblRipCorrente;
		private System.Windows.Forms.Label lblRipPrecedente;
		private System.Windows.Forms.Label lblEsCorrentePrima;
		private System.Windows.Forms.Label lblEsCorrSeconda;
		private System.Windows.Forms.Label lblEsPrecPrima;
		private System.Windows.Forms.Label lblEsPrecSeconda;
		private System.Windows.Forms.GroupBox grpPrevPrinc;
		private System.ComponentModel.IContainer components;
        QueryHelper QHS;
        private TabPage tabPage1;
        private TabControl tabCtrl;
        private TabPage tabPage2;
        private GroupBox grpPrevCassa_E;
        private Label label25;
        private Label label26;
        private TextBox txtPrevAttualeCassaE;
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
        private GroupBox grpPrevCompetenza_E;
        private Label label3;
        private Label label4;
        private TextBox txtPrevAttualeCompetenzaE;
        private Button btnCalcolaTutto;
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
        private TabPage tabPage3;
        private GroupBox grpPrevCompetenza_S;
        private Label label27;
        private Label label28;
        private TextBox txtPrevAttualeCompetenzaS;
        private Button btnPiccoleSpeseImp;
        private Label lblPiccoleSpeseImp;
        private TextBox txtPiccoleSpeseImp;
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
        private Label label29;
        private Label label30;
        private TextBox txtPrevAttualeCassaS;
        private Button btnPiccoleSpesePagamenti;
        private Label lblPiccoleSpesePagamenti;
        private TextBox txtPiccoleSpesePagamenti;
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
        private TabPage tabPage4;
        private GroupBox grpCrediti;
        private Label label31;
        private Label labelTotaleCrediti;
        private TextBox txtTotaleCrediti;
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
        private GroupBox grpCassa;
        private Label label32;
        private Label labelTotaleCassa;
        private TextBox txtTotaleCassa;
        private Button btnPiccoleSpesePagamenti1;
        private Label lblPiccoleSpesePagamenti1;
        private TextBox txtPiccoleSpesePagamenti1;
        private Button btnPagamenti1;
        private Label lblPagamenti1;
        private TextBox txtPagamenti1;
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
        CQueryHelper QHC;
//		public MetaData meta;
        CalcoliFinanziario calcFin;
        private CheckBox chkUpbChilds;
        private TextBox txtLimite;
        private Label label13;
        private Button btnHideUnused;
        DataAccess Conn;
		public Frm_finview_prevision() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		private void cambiaEtichetteEsercizi() 
		{
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;
			lblEsCorrentePrima.Text = esercizioCurr.ToString();
			lblEsCorrSeconda.Text = esercizioCurr.ToString();
			lblRipCorrente.Text = "Presunti del " + esercizioCurr.ToString();
			lblEsPrecPrima.Text = esercizioPrec.ToString();
			lblEsPrecSeconda.Text = esercizioPrec.ToString();
			lblRipPrecedente.Text = "Presunti del " + esercizioPrec.ToString();

			lblprevision2.Text = (++esercizioCurr).ToString();
			lblprevision3.Text = (++esercizioCurr).ToString();
			lblprevision4.Text = (++esercizioCurr).ToString();
			lblprevision5.Text = (++esercizioCurr).ToString();
		}

	    private object mainIdUpb;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            calcFin = new CalcoliFinanziario(Meta, this);
			Meta.CanInsert = false;
			Meta.CanCancel = false;
			object idUpb=DBNull.Value;
            Conn = Meta.Conn;

			int esercizio = (int)Meta.GetSys("esercizio");

			if (Meta.edit_type!="relation")	{
				idUpb = Meta.ExtraParameter.ToString();
			}

			if(Meta.edit_type=="relation"){	//Extract parameter from context filter 
                DataRow middleRow = Meta.GetSys("MiddleRow") as DataRow;
                if (middleRow == null) {
                    middleRow = Meta.GetSys("ComingFromRow") as DataRow;
                    if (middleRow !=null && middleRow.Table.TableName != "upb") middleRow = null;
                }
                string ctxfilter = Meta.ContextFilter;
                if (ctxfilter == null && Meta.GetSys("Parent2Filter") != null) ctxfilter = Meta.GetSys("Parent2Filter").ToString();

                if (middleRow == null) {
                    string fieldname = "idupb";
                    int posizione = ctxfilter.IndexOf(fieldname);
                    int start = posizione + fieldname.Length + 2;//skips fieldname='
                    int stop = Meta.ContextFilter.IndexOf("'", start);
                    if (posizione != -1) {
                        idUpb = ctxfilter.Substring(start, stop - start);
                    }
                }
                else {
                    idUpb = middleRow["idupb"];
                }
			}

			object upbname= Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb",idUpb),"title");//.ToString();
			if (upbname!=null)
			{
				Meta.Name = "Bilancio dell'UPB\""+upbname.ToString()+"\"";
			}
			Meta.DefaultListType="upbprevision";//+idUpb;
            mainIdUpb = idUpb;

            string filterEsercizio = QHS.CmpEq("ayear", esercizio);
            string filter = QHS.AppAnd(QHS.CmpEq("idupb", idUpb), filterEsercizio);
            
			GetData.SetStaticFilter(DS.finview,filter);
			GetData.SetStaticFilter(DS.finyear,filter);
			GetData.CacheTable(DS.fin,filterEsercizio,null,false);
            GetData.CacheTable(DS.upb,QHS.CmpEq("idupb",idUpb),null,false);
			GetData.CacheTable(DS.finlevel,filterEsercizio,"nlevel",false);
            GetData.SetSorting(DS.finview, "printingorder");
			cambiaEtichetteEsercizi();

            txtLimite.ReadOnly = !(Sec_Function.funzioneConsentita(Conn, "edit_limit"));
		}

		public void MetaData_AfterActivation() {
			gestisciGruppoPrevisioneSecondaria();
			riempiVarDiConfronto();
			enableControls(false);
			
			//Imposta i nomi delle previsioni sui groupbox 
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			DataTable tConfig = DataAccess.RUN_SELECT(Meta.Conn, "config", null, null, filteresercizio, null, null, true);
			if (tConfig!= null)
			{
				if (tConfig.Rows.Count != 0)
				{
					DataRow rConfig = tConfig.Rows[0];
                    string nomeprevsecondaria = CfgFn.NomePrevisioneSecondaria(Meta.Conn);
					if (nomeprevsecondaria==null){
						grpPrevSec.Visible=false;
					}
					else{
						grpPrevSec.Text= nomeprevsecondaria;
					}
                    grpPrevPrinc.Text = CfgFn.NomePrevisionePrincipale(Meta.Conn);	

					string RipPrecedente = rConfig["prevpartitiontitle"].ToString();
					if (RipPrecedente!="") lblRipPrecedente.Text = RipPrecedente;
				}
			}
		}

		public void MetaData_AfterFill() {
			PostData.MarkAsRealTable(DS.finview);
			riempiVarDiConfronto();
			bool enable = !(Meta.InsertMode || Meta.EditMode);
			enableControls(enable);
            AbilitaSezioniRiepilogo();
            if (Meta.InsertMode) {
                AbilitaBottoni(false);
            }
            else {
                AbilitaBottoni(true);

            }
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "finview") {
				bool isOperativo = Operativo(R);
				gestisciTxtPrevisione(isOperativo);
				riempiVarDiConfronto();
                if (R != null) {
                    calcFin.Enabled = true;
                    calcFin.SetMask(R["idfin"], R["idupb"], DBNull.Value);
                    btnHideUnused.Enabled = false;
                }
                else {
                    calcFin.Enabled = false;
                    btnHideUnused.Enabled = true;
                }
                pulisciTextRiepilogo();
			}
		}

		public void MetaData_AfterClear() {
			azzeraVarDiConfronto();
			gestisciTxtPrevisione(true);
			enableControls(true);
            calcFin.Enabled = false;
            pulisciTextRiepilogo();
            AbilitaBottoni(false);

            string filterEsercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            string filter = QHS.AppAnd(QHS.CmpEq("idupb", mainIdUpb), filterEsercizio);

            GetData.SetStaticFilter(DS.finview, filter);
            GetData.SetStaticFilter(DS.finyear, filter);
        }

        public void MetaData_BeforeFill() {
            DataRow dr = HelpForm.GetLastSelected(DS.finview);
            if (dr != null) {
                calcFin.Enabled = true;
                calcFin.SetMask(dr["idfin"], dr["idupb"], DBNull.Value);
            }

        }

		private void enableControls(bool enable) {
			txtCodiceBilancio.ReadOnly = !enable;
			txtDenominazioneBilancio.ReadOnly = !enable;
			rdbEntrata.Enabled = enable;
			rdbSpesa.Enabled = enable;
		}

		private void riempiVarDiConfronto() {
			DataRow Curr = HelpForm.GetLastSelected(DS.finview);
			if (Curr == null) return;
			azzeraVarDiConfronto();
			lastPrevPrincCorr = (decimal)isNull(Curr["prevision"],0m);
			lastPrevPrincPrec = (decimal)isNull(Curr["previousprevision"],0m);
			lastPrevSecCorr = (decimal)isNull(Curr["secondaryprev"],0m);
			lastPrevSecPrec = (decimal)isNull(Curr["previoussecondaryprev"],0m);
			lastResCorr = (decimal)isNull(Curr["currentarrears"],0m);
			lastResPrec = (decimal)isNull(Curr["previousarrears"],0m);
		}

		private void azzeraVarDiConfronto() {
			lastPrevPrincCorr = 0;
			lastPrevPrincPrec = 0;
			lastPrevSecCorr = 0;
			lastPrevSecPrec = 0;
			lastResCorr = 0;
			lastResPrec = 0;
		}

		private object isNull(object a, object b) {
			return ((a == null) || (a == DBNull.Value))	? b : a;
		}

		private void gestisciTxtPrevisione(bool enable) {
			txtPrevisionePrincipaleCorrUpb.ReadOnly = !enable;
			txtPrevisionePrincipalePrecUpb.ReadOnly = !enable;
			txtPrevisioneSecondariaCorrUpb.ReadOnly = !enable;
			txtPrevisioneSecondariaPrecUpb.ReadOnly = !enable;
			txtResiduiCorrUpb.ReadOnly = !enable;
			txtResiduiPrecUpb.ReadOnly = !enable;
			txtPrevisione2Upb.ReadOnly = !enable;
			txtPrevisione3Upb.ReadOnly = !enable;
			txtPrevisione4Upb.ReadOnly = !enable;
			txtPrevisione5Upb.ReadOnly = !enable;
		}

		private void gestisciGruppoPrevisioneSecondaria() {
            int finkind = CfgFn.GetNoNullInt32(Meta.Conn.GetSys("fin_kind"));
			grpPrevSec.Visible = (finkind == 3);
		}

		private bool Operativo(DataRow R){
			// Controllo che la voce selezionata sia un nodo foglia
			if (R == null) return false;
		    if (R.RowState == DataRowState.Detached) return false;
			//string filter = "(paridfin = " + QueryCreator.quotedstrvalue(R["idfin"],false) + ")";
			//DataRow [] rFigli = DS.fin.Select(filter);
			//if (rFigli.Length > 0) return false;

			// Se la voce è un nodo foglia controllo se sono su di un livello operativo
            string filteresercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            int thislevel = CfgFn.GetNoNullInt32(R["nlevel"]);
            int levelop = CfgFn.GetNoNullInt32(Meta.GetSys("finusablelevel"));
            if (thislevel < levelop) return false;
            //string livellorow=R["nlevel"].ToString();
            //DataRow[] Res = DS.finlevel.Select(QHC.AppAnd(filteresercizio,QHC.CmpEq("nlevel",livellorow)));
            //if (Res.Length!=1) return false;
            //int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            //if ((flag & 2) == 0) return false;
            return true;
		}

        public void MetaData_BeforePost() {
			if (!DS.HasChanges()) return;
			DataRow rFinView = HelpForm.GetLastSelected(DS.finview);
			if (rFinView.RowState == DataRowState.Unchanged) return;
            string filter = QHC.AppAnd(QHC.CmpEq("idfin", rFinView["idfin"]),
                                    QHC.CmpEq("idupb", rFinView["idupb"]));
			DataRow [] rFinYear = DS.finyear.Select(filter);
			if (rFinYear.Length > 0) {
				// Modifica la tabella finyear
				foreach(string c in new string [] {
													  "prevision","secondaryprev","previousprevision","limit",
													  "previoussecondaryprev","currentarrears","previousarrears",
													  "prevision2","prevision3","prevision4","prevision5"}) {
					if (!rFinYear[0][c].Equals(rFinView[c])) {
						rFinYear[0][c] = rFinView[c];
					}
				}
			}
			else {
				MetaData MetaFinYear = MetaData.GetMetaData(this,"finyear");
				MetaFinYear.SetDefaults(DS.finyear);
				DataRow rNewFinYear = MetaFinYear.Get_New_Row(rFinView,DS.finyear);
				foreach(DataColumn C in DS.finyear.Columns) {
					if (!DS.finview.Columns.Contains(C.ColumnName)) continue;
					rNewFinYear[C] = rFinView[C.ColumnName];
				}
			}
			PostData.MarkAsTemporaryTable(DS.finview,false);
		}

		public void MetaData_AfterPost() {
			DataRow rFinView = HelpForm.GetLastSelected(DS.finview);
			aggiornaLivelliSuperiori(rFinView);
			PostData.MarkAsRealTable(DS.finview);
			DS.finview.AcceptChanges();
		}

		private void aggiornaLivelliSuperiori(DataRow rFinView) {
			object minLivelloOperativoOBJ = DS.finlevel.Compute("min(nlevel)",QHC.BitSet("flag",1));
            int minLivelloOperativo = CfgFn.GetNoNullInt32(minLivelloOperativoOBJ);
			object idFin = rFinView["idfin"];
            int livelloIdFin = CfgFn.GetNoNullInt32(rFinView["nlevel"]);
			if (livelloIdFin > minLivelloOperativo) return;
            object currIdFin = rFinView["paridfin"];
            while (currIdFin != DBNull.Value) {
                string filter = QHC.CmpEq("idfin", currIdFin);
				DataRow rFinViewParent = DS.finview.Select(filter)[0];
				rFinViewParent["prevision"] = (decimal)isNull(rFinViewParent["prevision"],0m) + 
					(decimal)isNull(rFinView["prevision"],0m) - lastPrevPrincCorr;
				rFinViewParent["secondaryprev"] = (decimal)isNull(rFinViewParent["secondaryprev"],0m) + 
					(decimal)isNull(rFinView["secondaryprev"],0m) - lastPrevSecCorr;
				rFinViewParent["previousprevision"] = (decimal)isNull(rFinViewParent["previousprevision"],0m) + 
					(decimal)isNull(rFinView["previousprevision"],0m) - lastPrevPrincPrec;
				rFinViewParent["previoussecondaryprev"] = (decimal)isNull(rFinViewParent["previoussecondaryprev"],0m) + 
					(decimal)isNull(rFinView["previoussecondaryprev"],0m) - lastPrevSecPrec;
				rFinViewParent["currentarrears"] = (decimal)isNull(rFinViewParent["currentarrears"],0m) + 
					(decimal)isNull(rFinView["currentarrears"],0m) - lastResCorr;
				rFinViewParent["previousarrears"] = (decimal)isNull(rFinViewParent["previousarrears"],0m) + 
					(decimal)isNull(rFinView["previousarrears"],0m) - lastResPrec;
                currIdFin = rFinViewParent["paridfin"];
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finview_prevision));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.gboxNoName = new System.Windows.Forms.GroupBox();
            this.btnHideUnused = new System.Windows.Forms.Button();
            this.txtCodiceUpb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazioneUpb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpPrevisione = new System.Windows.Forms.GroupBox();
            this.grpPrevPrinc = new System.Windows.Forms.GroupBox();
            this.txtPrevisionePrincipalePrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisionePrincipaleCorrUpb = new System.Windows.Forms.TextBox();
            this.lblEsCorrentePrima = new System.Windows.Forms.Label();
            this.lblEsPrecPrima = new System.Windows.Forms.Label();
            this.grpPrevSec = new System.Windows.Forms.GroupBox();
            this.txtPrevisioneSecondariaPrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisioneSecondariaCorrUpb = new System.Windows.Forms.TextBox();
            this.lblEsCorrSeconda = new System.Windows.Forms.Label();
            this.lblEsPrecSeconda = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtResiduiPrecUpb = new System.Windows.Forms.TextBox();
            this.txtResiduiCorrUpb = new System.Windows.Forms.TextBox();
            this.lblRipCorrente = new System.Windows.Forms.Label();
            this.lblRipPrecedente = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtPrevisione5Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione4Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione3Upb = new System.Windows.Forms.TextBox();
            this.txtPrevisione2Upb = new System.Windows.Forms.TextBox();
            this.lblprevision5 = new System.Windows.Forms.Label();
            this.lblprevision4 = new System.Windows.Forms.Label();
            this.lblprevision2 = new System.Windows.Forms.Label();
            this.lblprevision3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.btnSituazione = new System.Windows.Forms.Button();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.txtLimite = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkUpbChilds = new System.Windows.Forms.CheckBox();
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grpPrevCassa_E = new System.Windows.Forms.GroupBox();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.btnCalcolaTutto = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.DS = new finview_prevision.vistaForm();
            this.gboxNoName.SuspendLayout();
            this.grpPrevisione.SuspendLayout();
            this.grpPrevPrinc.SuspendLayout();
            this.grpPrevSec.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabCtrl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grpPrevCassa_E.SuspendLayout();
            this.grpPrevCompetenza_E.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpPrevCompetenza_S.SuspendLayout();
            this.grpPrevCassa_S.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpCrediti.SuspendLayout();
            this.grpCassa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
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
            this.treeView1.Size = new System.Drawing.Size(263, 526);
            this.treeView1.TabIndex = 12;
            this.treeView1.Tag = "finview.upbprevision";
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // gboxNoName
            // 
            this.gboxNoName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxNoName.Controls.Add(this.btnHideUnused);
            this.gboxNoName.Controls.Add(this.txtCodiceUpb);
            this.gboxNoName.Controls.Add(this.label1);
            this.gboxNoName.Controls.Add(this.txtDenominazioneUpb);
            this.gboxNoName.Controls.Add(this.label2);
            this.gboxNoName.Location = new System.Drawing.Point(8, 8);
            this.gboxNoName.Name = "gboxNoName";
            this.gboxNoName.Size = new System.Drawing.Size(603, 88);
            this.gboxNoName.TabIndex = 13;
            this.gboxNoName.TabStop = false;
            this.gboxNoName.Text = "Informazioni sull\'U.P.B.";
            // 
            // btnHideUnused
            // 
            this.btnHideUnused.Location = new System.Drawing.Point(371, 19);
            this.btnHideUnused.Name = "btnHideUnused";
            this.btnHideUnused.Size = new System.Drawing.Size(224, 23);
            this.btnHideUnused.TabIndex = 19;
            this.btnHideUnused.Text = "Nascondi voci inutilizzate";
            this.btnHideUnused.Click += new System.EventHandler(this.btnHideUnused_Click);
            // 
            // txtCodiceUpb
            // 
            this.txtCodiceUpb.Location = new System.Drawing.Point(104, 24);
            this.txtCodiceUpb.Name = "txtCodiceUpb";
            this.txtCodiceUpb.ReadOnly = true;
            this.txtCodiceUpb.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceUpb.TabIndex = 2;
            this.txtCodiceUpb.Tag = "finview.codeupb";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazioneUpb
            // 
            this.txtDenominazioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneUpb.Location = new System.Drawing.Point(104, 48);
            this.txtDenominazioneUpb.Multiline = true;
            this.txtDenominazioneUpb.Name = "txtDenominazioneUpb";
            this.txtDenominazioneUpb.ReadOnly = true;
            this.txtDenominazioneUpb.Size = new System.Drawing.Size(491, 32);
            this.txtDenominazioneUpb.TabIndex = 3;
            this.txtDenominazioneUpb.Tag = "finview.upb";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Denominazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPrevisione
            // 
            this.grpPrevisione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPrevisione.Controls.Add(this.grpPrevPrinc);
            this.grpPrevisione.Controls.Add(this.grpPrevSec);
            this.grpPrevisione.Controls.Add(this.groupBox6);
            this.grpPrevisione.Controls.Add(this.groupBox7);
            this.grpPrevisione.Location = new System.Drawing.Point(8, 200);
            this.grpPrevisione.Name = "grpPrevisione";
            this.grpPrevisione.Size = new System.Drawing.Size(603, 256);
            this.grpPrevisione.TabIndex = 5;
            this.grpPrevisione.TabStop = false;
            this.grpPrevisione.Text = "Bilancio di Previsione";
            // 
            // grpPrevPrinc
            // 
            this.grpPrevPrinc.Controls.Add(this.txtPrevisionePrincipalePrecUpb);
            this.grpPrevPrinc.Controls.Add(this.txtPrevisionePrincipaleCorrUpb);
            this.grpPrevPrinc.Controls.Add(this.lblEsCorrentePrima);
            this.grpPrevPrinc.Controls.Add(this.lblEsPrecPrima);
            this.grpPrevPrinc.Location = new System.Drawing.Point(8, 16);
            this.grpPrevPrinc.Name = "grpPrevPrinc";
            this.grpPrevPrinc.Size = new System.Drawing.Size(536, 48);
            this.grpPrevPrinc.TabIndex = 15;
            this.grpPrevPrinc.TabStop = false;
            this.grpPrevPrinc.Text = "Previsione Principale";
            // 
            // txtPrevisionePrincipalePrecUpb
            // 
            this.txtPrevisionePrincipalePrecUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevisionePrincipalePrecUpb.Location = new System.Drawing.Point(424, 22);
            this.txtPrevisionePrincipalePrecUpb.Name = "txtPrevisionePrincipalePrecUpb";
            this.txtPrevisionePrincipalePrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecUpb.TabIndex = 9;
            this.txtPrevisionePrincipalePrecUpb.Tag = "finview.previousprevision";
            // 
            // txtPrevisionePrincipaleCorrUpb
            // 
            this.txtPrevisionePrincipaleCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisionePrincipaleCorrUpb.Name = "txtPrevisionePrincipaleCorrUpb";
            this.txtPrevisionePrincipaleCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipaleCorrUpb.TabIndex = 8;
            this.txtPrevisionePrincipaleCorrUpb.Tag = "finview.prevision";
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
            this.lblEsPrecPrima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEsPrecPrima.Location = new System.Drawing.Point(312, 24);
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
            this.grpPrevSec.Size = new System.Drawing.Size(536, 48);
            this.grpPrevSec.TabIndex = 16;
            this.grpPrevSec.TabStop = false;
            this.grpPrevSec.Text = "Previsione Secondaria";
            // 
            // txtPrevisioneSecondariaPrecUpb
            // 
            this.txtPrevisioneSecondariaPrecUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevisioneSecondariaPrecUpb.Location = new System.Drawing.Point(424, 22);
            this.txtPrevisioneSecondariaPrecUpb.Name = "txtPrevisioneSecondariaPrecUpb";
            this.txtPrevisioneSecondariaPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaPrecUpb.TabIndex = 10;
            this.txtPrevisioneSecondariaPrecUpb.Tag = "finview.previoussecondaryprev";
            // 
            // txtPrevisioneSecondariaCorrUpb
            // 
            this.txtPrevisioneSecondariaCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisioneSecondariaCorrUpb.Name = "txtPrevisioneSecondariaCorrUpb";
            this.txtPrevisioneSecondariaCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisioneSecondariaCorrUpb.TabIndex = 9;
            this.txtPrevisioneSecondariaCorrUpb.Tag = "finview.secondaryprev";
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
            this.lblEsPrecSeconda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEsPrecSeconda.Location = new System.Drawing.Point(312, 24);
            this.lblEsPrecSeconda.Name = "lblEsPrecSeconda";
            this.lblEsPrecSeconda.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecSeconda.TabIndex = 8;
            this.lblEsPrecSeconda.Text = "Prev. Prec.";
            this.lblEsPrecSeconda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtResiduiPrecUpb);
            this.groupBox6.Controls.Add(this.txtResiduiCorrUpb);
            this.groupBox6.Controls.Add(this.lblRipCorrente);
            this.groupBox6.Controls.Add(this.lblRipPrecedente);
            this.groupBox6.Location = new System.Drawing.Point(8, 112);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(536, 48);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Residui dell\'anno precedente";
            // 
            // txtResiduiPrecUpb
            // 
            this.txtResiduiPrecUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResiduiPrecUpb.Location = new System.Drawing.Point(424, 22);
            this.txtResiduiPrecUpb.Name = "txtResiduiPrecUpb";
            this.txtResiduiPrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiPrecUpb.TabIndex = 12;
            this.txtResiduiPrecUpb.Tag = "finview.previousarrears";
            // 
            // txtResiduiCorrUpb
            // 
            this.txtResiduiCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtResiduiCorrUpb.Name = "txtResiduiCorrUpb";
            this.txtResiduiCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiCorrUpb.TabIndex = 11;
            this.txtResiduiCorrUpb.Tag = "finview.currentarrears";
            // 
            // lblRipCorrente
            // 
            this.lblRipCorrente.Location = new System.Drawing.Point(8, 24);
            this.lblRipCorrente.Name = "lblRipCorrente";
            this.lblRipCorrente.Size = new System.Drawing.Size(100, 16);
            this.lblRipCorrente.TabIndex = 9;
            this.lblRipCorrente.Text = "Presunti del ";
            this.lblRipCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRipPrecedente
            // 
            this.lblRipPrecedente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRipPrecedente.Location = new System.Drawing.Point(312, 24);
            this.lblRipPrecedente.Name = "lblRipPrecedente";
            this.lblRipPrecedente.Size = new System.Drawing.Size(100, 16);
            this.lblRipPrecedente.TabIndex = 10;
            this.lblRipPrecedente.Text = "Presunti del";
            this.lblRipPrecedente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtPrevisione5Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione4Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione3Upb);
            this.groupBox7.Controls.Add(this.txtPrevisione2Upb);
            this.groupBox7.Controls.Add(this.lblprevision5);
            this.groupBox7.Controls.Add(this.lblprevision4);
            this.groupBox7.Controls.Add(this.lblprevision2);
            this.groupBox7.Controls.Add(this.lblprevision3);
            this.groupBox7.Location = new System.Drawing.Point(8, 160);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(536, 88);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Previsione Esercizi Futuri";
            // 
            // txtPrevisione5Upb
            // 
            this.txtPrevisione5Upb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevisione5Upb.Location = new System.Drawing.Point(424, 58);
            this.txtPrevisione5Upb.Name = "txtPrevisione5Upb";
            this.txtPrevisione5Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Upb.TabIndex = 18;
            this.txtPrevisione5Upb.Tag = "finview.prevision5";
            // 
            // txtPrevisione4Upb
            // 
            this.txtPrevisione4Upb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrevisione4Upb.Location = new System.Drawing.Point(120, 56);
            this.txtPrevisione4Upb.Name = "txtPrevisione4Upb";
            this.txtPrevisione4Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione4Upb.TabIndex = 17;
            this.txtPrevisione4Upb.Tag = "finview.prevision4";
            // 
            // txtPrevisione3Upb
            // 
            this.txtPrevisione3Upb.Location = new System.Drawing.Point(424, 24);
            this.txtPrevisione3Upb.Name = "txtPrevisione3Upb";
            this.txtPrevisione3Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione3Upb.TabIndex = 16;
            this.txtPrevisione3Upb.Tag = "finview.prevision3";
            // 
            // txtPrevisione2Upb
            // 
            this.txtPrevisione2Upb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisione2Upb.Name = "txtPrevisione2Upb";
            this.txtPrevisione2Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione2Upb.TabIndex = 15;
            this.txtPrevisione2Upb.Tag = "finview.prevision2";
            // 
            // lblprevision5
            // 
            this.lblprevision5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblprevision5.Location = new System.Drawing.Point(319, 58);
            this.lblprevision5.Name = "lblprevision5";
            this.lblprevision5.Size = new System.Drawing.Size(100, 16);
            this.lblprevision5.TabIndex = 14;
            this.lblprevision5.Text = "n+4";
            this.lblprevision5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblprevision4
            // 
            this.lblprevision4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblprevision4.Location = new System.Drawing.Point(16, 56);
            this.lblprevision4.Name = "lblprevision4";
            this.lblprevision4.Size = new System.Drawing.Size(100, 16);
            this.lblprevision4.TabIndex = 13;
            this.lblprevision4.Text = "n+3";
            this.lblprevision4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblprevision2
            // 
            this.lblprevision2.Location = new System.Drawing.Point(16, 24);
            this.lblprevision2.Name = "lblprevision2";
            this.lblprevision2.Size = new System.Drawing.Size(100, 16);
            this.lblprevision2.TabIndex = 11;
            this.lblprevision2.Text = "n+1";
            this.lblprevision2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblprevision3
            // 
            this.lblprevision3.Location = new System.Drawing.Point(330, 25);
            this.lblprevision3.Name = "lblprevision3";
            this.lblprevision3.Size = new System.Drawing.Size(88, 16);
            this.lblprevision3.TabIndex = 12;
            this.lblprevision3.Text = "n+2";
            this.lblprevision3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtDenominazioneBilancio);
            this.groupBox1.Controls.Add(this.txtCodiceBilancio);
            this.groupBox1.Location = new System.Drawing.Point(8, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 88);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni sul Bilancio";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdbSpesa);
            this.groupBox2.Controls.Add(this.rdbEntrata);
            this.groupBox2.Location = new System.Drawing.Point(363, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 40);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parte";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(120, 16);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(104, 16);
            this.rdbSpesa.TabIndex = 1;
            this.rdbSpesa.Tag = "finview.finpart:S";
            this.rdbSpesa.Text = "Spesa";
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Location = new System.Drawing.Point(8, 16);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(104, 16);
            this.rdbEntrata.TabIndex = 0;
            this.rdbEntrata.Tag = "finview.finpart:E";
            this.rdbEntrata.Text = "Entrata";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(88, 23);
            this.label24.TabIndex = 3;
            this.label24.Text = "Denominazione";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 24);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 23);
            this.label23.TabIndex = 2;
            this.label23.Text = "Codice";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(104, 48);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(491, 32);
            this.txtDenominazioneBilancio.TabIndex = 1;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(104, 24);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceBilancio.TabIndex = 0;
            this.txtCodiceBilancio.Tag = "finview.codefin";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(528, 462);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 16;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.Location = new System.Drawing.Point(263, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(627, 526);
            this.MetaDataDetail.TabIndex = 17;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.txtLimite);
            this.tabPrincipale.Controls.Add(this.btnSituazione);
            this.tabPrincipale.Controls.Add(this.grpPrevisione);
            this.tabPrincipale.Controls.Add(this.label13);
            this.tabPrincipale.Controls.Add(this.groupBox1);
            this.tabPrincipale.Controls.Add(this.gboxNoName);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(619, 500);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // txtLimite
            // 
            this.txtLimite.Location = new System.Drawing.Point(250, 464);
            this.txtLimite.Name = "txtLimite";
            this.txtLimite.Size = new System.Drawing.Size(121, 20);
            this.txtLimite.TabIndex = 18;
            this.txtLimite.Tag = "finview.limit";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 467);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(218, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Limite sulla previsione dell\'intero ramo di UPB";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkUpbChilds);
            this.tabPage1.Controls.Add(this.tabCtrl);
            this.tabPage1.Controls.Add(this.btnCalcolaTutto);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(619, 500);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Riepilogo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkUpbChilds
            // 
            this.chkUpbChilds.AutoSize = true;
            this.chkUpbChilds.Location = new System.Drawing.Point(6, 17);
            this.chkUpbChilds.Name = "chkUpbChilds";
            this.chkUpbChilds.Size = new System.Drawing.Size(285, 17);
            this.chkUpbChilds.TabIndex = 69;
            this.chkUpbChilds.Text = "Considera anche gli UPB sottostanti nei dati di riepilogo";
            this.chkUpbChilds.UseVisualStyleBackColor = true;
            this.chkUpbChilds.CheckedChanged += new System.EventHandler(this.chkUpbChilds_CheckedChanged);
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Controls.Add(this.tabPage3);
            this.tabCtrl.Controls.Add(this.tabPage4);
            this.tabCtrl.Location = new System.Drawing.Point(6, 45);
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(594, 442);
            this.tabCtrl.TabIndex = 62;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grpPrevCassa_E);
            this.tabPage2.Controls.Add(this.grpPrevCompetenza_E);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 416);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Entrate";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grpPrevCassa_E
            // 
            this.grpPrevCassa_E.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpPrevCassa_E.Location = new System.Drawing.Point(6, 207);
            this.grpPrevCassa_E.Name = "grpPrevCassa_E";
            this.grpPrevCassa_E.Size = new System.Drawing.Size(571, 193);
            this.grpPrevCassa_E.TabIndex = 63;
            this.grpPrevCassa_E.TabStop = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(373, 69);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 13);
            this.label25.TabIndex = 23;
            this.label25.Text = "= E + F";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(16, 66);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(186, 13);
            this.label26.TabIndex = 21;
            this.label26.Text = "Previsione  attuale di Cassa";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCassaE
            // 
            this.txtPrevAttualeCassaE.Location = new System.Drawing.Point(223, 66);
            this.txtPrevAttualeCassaE.Name = "txtPrevAttualeCassaE";
            this.txtPrevAttualeCassaE.ReadOnly = true;
            this.txtPrevAttualeCassaE.Size = new System.Drawing.Size(137, 20);
            this.txtPrevAttualeCassaE.TabIndex = 22;
            this.txtPrevAttualeCassaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(373, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "H = E + F - G";
            // 
            // btnVarPrevCassa_E
            // 
            this.btnVarPrevCassa_E.Location = new System.Drawing.Point(370, 35);
            this.btnVarPrevCassa_E.Name = "btnVarPrevCassa_E";
            this.btnVarPrevCassa_E.Size = new System.Drawing.Size(75, 23);
            this.btnVarPrevCassa_E.TabIndex = 3;
            this.btnVarPrevCassa_E.Text = "F";
            this.btnVarPrevCassa_E.UseVisualStyleBackColor = true;
            this.btnVarPrevCassa_E.Click += new System.EventHandler(this.btnVarPrevCassa_E_Click);
            // 
            // lblVarPrevCassa_E
            // 
            this.lblVarPrevCassa_E.Location = new System.Drawing.Point(22, 40);
            this.lblVarPrevCassa_E.Name = "lblVarPrevCassa_E";
            this.lblVarPrevCassa_E.Size = new System.Drawing.Size(180, 13);
            this.lblVarPrevCassa_E.TabIndex = 0;
            this.lblVarPrevCassa_E.Text = "Var. Previsione  di Cassa";
            this.lblVarPrevCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevCassa_E
            // 
            this.txtVarPrevCassa_E.Location = new System.Drawing.Point(223, 35);
            this.txtVarPrevCassa_E.Name = "txtVarPrevCassa_E";
            this.txtVarPrevCassa_E.ReadOnly = true;
            this.txtVarPrevCassa_E.Size = new System.Drawing.Size(137, 20);
            this.txtVarPrevCassa_E.TabIndex = 2;
            this.txtVarPrevCassa_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCassa_E
            // 
            this.lblPrevDispCassa_E.Location = new System.Drawing.Point(6, 130);
            this.lblPrevDispCassa_E.Name = "lblPrevDispCassa_E";
            this.lblPrevDispCassa_E.Size = new System.Drawing.Size(196, 13);
            this.lblPrevDispCassa_E.TabIndex = 0;
            this.lblPrevDispCassa_E.Text = "Previsione Disponibile di Cassa";
            this.lblPrevDispCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevDispCassa_E
            // 
            this.txtPrevDispCassa_E.Location = new System.Drawing.Point(223, 125);
            this.txtPrevDispCassa_E.Name = "txtPrevDispCassa_E";
            this.txtPrevDispCassa_E.ReadOnly = true;
            this.txtPrevDispCassa_E.Size = new System.Drawing.Size(137, 20);
            this.txtPrevDispCassa_E.TabIndex = 8;
            this.txtPrevDispCassa_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnIncassi
            // 
            this.btnIncassi.Location = new System.Drawing.Point(370, 100);
            this.btnIncassi.Name = "btnIncassi";
            this.btnIncassi.Size = new System.Drawing.Size(75, 23);
            this.btnIncassi.TabIndex = 5;
            this.btnIncassi.Text = "G";
            this.btnIncassi.UseVisualStyleBackColor = true;
            this.btnIncassi.Click += new System.EventHandler(this.btnIncassi_Click);
            // 
            // lblIncassi
            // 
            this.lblIncassi.Location = new System.Drawing.Point(8, 104);
            this.lblIncassi.Name = "lblIncassi";
            this.lblIncassi.Size = new System.Drawing.Size(194, 13);
            this.lblIncassi.TabIndex = 0;
            this.lblIncassi.Text = "Incassi";
            this.lblIncassi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIncassi
            // 
            this.txtIncassi.Location = new System.Drawing.Point(223, 99);
            this.txtIncassi.Name = "txtIncassi";
            this.txtIncassi.ReadOnly = true;
            this.txtIncassi.Size = new System.Drawing.Size(137, 20);
            this.txtIncassi.TabIndex = 4;
            this.txtIncassi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCassa_E
            // 
            this.btnPrevInizialeCassa_E.Location = new System.Drawing.Point(370, 9);
            this.btnPrevInizialeCassa_E.Name = "btnPrevInizialeCassa_E";
            this.btnPrevInizialeCassa_E.Size = new System.Drawing.Size(75, 23);
            this.btnPrevInizialeCassa_E.TabIndex = 1;
            this.btnPrevInizialeCassa_E.Text = "E";
            this.btnPrevInizialeCassa_E.UseVisualStyleBackColor = true;
            this.btnPrevInizialeCassa_E.Click += new System.EventHandler(this.btnPrevInizialeCassa_E_Click);
            // 
            // lblPrevInizialeCassa_E
            // 
            this.lblPrevInizialeCassa_E.Location = new System.Drawing.Point(22, 14);
            this.lblPrevInizialeCassa_E.Name = "lblPrevInizialeCassa_E";
            this.lblPrevInizialeCassa_E.Size = new System.Drawing.Size(180, 13);
            this.lblPrevInizialeCassa_E.TabIndex = 0;
            this.lblPrevInizialeCassa_E.Text = "Previsione Iniziale di Cassa";
            this.lblPrevInizialeCassa_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCassa_E
            // 
            this.txtPrevInizialeCassa_E.Location = new System.Drawing.Point(223, 9);
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
            this.grpPrevCompetenza_E.Controls.Add(this.label3);
            this.grpPrevCompetenza_E.Controls.Add(this.label4);
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
            this.grpPrevCompetenza_E.Location = new System.Drawing.Point(5, 6);
            this.grpPrevCompetenza_E.Name = "grpPrevCompetenza_E";
            this.grpPrevCompetenza_E.Size = new System.Drawing.Size(572, 182);
            this.grpPrevCompetenza_E.TabIndex = 60;
            this.grpPrevCompetenza_E.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(365, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "= A + B";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Previsione  attuale di Competenza";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCompetenzaE
            // 
            this.txtPrevAttualeCompetenzaE.Location = new System.Drawing.Point(224, 72);
            this.txtPrevAttualeCompetenzaE.Name = "txtPrevAttualeCompetenzaE";
            this.txtPrevAttualeCompetenzaE.ReadOnly = true;
            this.txtPrevAttualeCompetenzaE.Size = new System.Drawing.Size(134, 20);
            this.txtPrevAttualeCompetenzaE.TabIndex = 66;
            this.txtPrevAttualeCompetenzaE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAccertamentiCompetenza
            // 
            this.btnAccertamentiCompetenza.Location = new System.Drawing.Point(368, 111);
            this.btnAccertamentiCompetenza.Name = "btnAccertamentiCompetenza";
            this.btnAccertamentiCompetenza.Size = new System.Drawing.Size(75, 23);
            this.btnAccertamentiCompetenza.TabIndex = 7;
            this.btnAccertamentiCompetenza.Text = "C";
            this.btnAccertamentiCompetenza.UseVisualStyleBackColor = true;
            this.btnAccertamentiCompetenza.Click += new System.EventHandler(this.btnAccertamentiCompetenza_Click);
            // 
            // lblAccertamentiCompetenza
            // 
            this.lblAccertamentiCompetenza.Location = new System.Drawing.Point(6, 109);
            this.lblAccertamentiCompetenza.Name = "lblAccertamentiCompetenza";
            this.lblAccertamentiCompetenza.Size = new System.Drawing.Size(197, 13);
            this.lblAccertamentiCompetenza.TabIndex = 0;
            this.lblAccertamentiCompetenza.Text = "Accertamenti  di Competenza";
            this.lblAccertamentiCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAccertamentiCompetenza
            // 
            this.txtAccertamentiCompetenza.Location = new System.Drawing.Point(224, 109);
            this.txtAccertamentiCompetenza.Name = "txtAccertamentiCompetenza";
            this.txtAccertamentiCompetenza.ReadOnly = true;
            this.txtAccertamentiCompetenza.Size = new System.Drawing.Size(134, 20);
            this.txtAccertamentiCompetenza.TabIndex = 6;
            this.txtAccertamentiCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(373, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "D = A + B - C";
            // 
            // btnVarPrevCompetenza_E
            // 
            this.btnVarPrevCompetenza_E.Location = new System.Drawing.Point(368, 37);
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
            this.lblVarPrevCompetenza_E.Location = new System.Drawing.Point(9, 35);
            this.lblVarPrevCompetenza_E.Name = "lblVarPrevCompetenza_E";
            this.lblVarPrevCompetenza_E.Size = new System.Drawing.Size(194, 13);
            this.lblVarPrevCompetenza_E.TabIndex = 0;
            this.lblVarPrevCompetenza_E.Text = "Var. Previsione  di Competenza";
            this.lblVarPrevCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevCompetenza_E
            // 
            this.txtVarPrevCompetenza_E.Location = new System.Drawing.Point(224, 35);
            this.txtVarPrevCompetenza_E.Name = "txtVarPrevCompetenza_E";
            this.txtVarPrevCompetenza_E.ReadOnly = true;
            this.txtVarPrevCompetenza_E.Size = new System.Drawing.Size(134, 20);
            this.txtVarPrevCompetenza_E.TabIndex = 2;
            this.txtVarPrevCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCompetenza_E
            // 
            this.lblPrevDispCompetenza_E.Location = new System.Drawing.Point(6, 134);
            this.lblPrevDispCompetenza_E.Name = "lblPrevDispCompetenza_E";
            this.lblPrevDispCompetenza_E.Size = new System.Drawing.Size(197, 13);
            this.lblPrevDispCompetenza_E.TabIndex = 0;
            this.lblPrevDispCompetenza_E.Text = "Previsione Disponibile di Competenza";
            this.lblPrevDispCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevDispCompetenza_E
            // 
            this.txtPrevDispCompetenza_E.Location = new System.Drawing.Point(224, 134);
            this.txtPrevDispCompetenza_E.Name = "txtPrevDispCompetenza_E";
            this.txtPrevDispCompetenza_E.ReadOnly = true;
            this.txtPrevDispCompetenza_E.Size = new System.Drawing.Size(134, 20);
            this.txtPrevDispCompetenza_E.TabIndex = 8;
            this.txtPrevDispCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCompetenza_E
            // 
            this.btnPrevInizialeCompetenza_E.Location = new System.Drawing.Point(368, 8);
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
            this.lblPrevInizialeCompetenza_E.Location = new System.Drawing.Point(12, 9);
            this.lblPrevInizialeCompetenza_E.Name = "lblPrevInizialeCompetenza_E";
            this.lblPrevInizialeCompetenza_E.Size = new System.Drawing.Size(191, 13);
            this.lblPrevInizialeCompetenza_E.TabIndex = 0;
            this.lblPrevInizialeCompetenza_E.Text = "Previsione Iniziale di Competenza";
            this.lblPrevInizialeCompetenza_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCompetenza_E
            // 
            this.txtPrevInizialeCompetenza_E.Location = new System.Drawing.Point(224, 9);
            this.txtPrevInizialeCompetenza_E.Name = "txtPrevInizialeCompetenza_E";
            this.txtPrevInizialeCompetenza_E.ReadOnly = true;
            this.txtPrevInizialeCompetenza_E.Size = new System.Drawing.Size(134, 20);
            this.txtPrevInizialeCompetenza_E.TabIndex = 0;
            this.txtPrevInizialeCompetenza_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpPrevCompetenza_S);
            this.tabPage3.Controls.Add(this.grpPrevCassa_S);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(586, 416);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Spese";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.grpPrevCompetenza_S.Location = new System.Drawing.Point(5, 3);
            this.grpPrevCompetenza_S.Name = "grpPrevCompetenza_S";
            this.grpPrevCompetenza_S.Size = new System.Drawing.Size(578, 207);
            this.grpPrevCompetenza_S.TabIndex = 63;
            this.grpPrevCompetenza_S.TabStop = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(366, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 70;
            this.label27.Text = "= A + B";
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(19, 72);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(198, 13);
            this.label28.TabIndex = 68;
            this.label28.Text = "Previsione  attuale di Competenza";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCompetenzaS
            // 
            this.txtPrevAttualeCompetenzaS.Location = new System.Drawing.Point(225, 69);
            this.txtPrevAttualeCompetenzaS.Name = "txtPrevAttualeCompetenzaS";
            this.txtPrevAttualeCompetenzaS.ReadOnly = true;
            this.txtPrevAttualeCompetenzaS.Size = new System.Drawing.Size(137, 20);
            this.txtPrevAttualeCompetenzaS.TabIndex = 69;
            this.txtPrevAttualeCompetenzaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPiccoleSpeseImp
            // 
            this.btnPiccoleSpeseImp.Location = new System.Drawing.Point(368, 129);
            this.btnPiccoleSpeseImp.Name = "btnPiccoleSpeseImp";
            this.btnPiccoleSpeseImp.Size = new System.Drawing.Size(75, 23);
            this.btnPiccoleSpeseImp.TabIndex = 15;
            this.btnPiccoleSpeseImp.Text = "D";
            this.btnPiccoleSpeseImp.UseVisualStyleBackColor = true;
            this.btnPiccoleSpeseImp.Click += new System.EventHandler(this.btnPiccoleSpeseImp_Click);
            // 
            // lblPiccoleSpeseImp
            // 
            this.lblPiccoleSpeseImp.Location = new System.Drawing.Point(13, 134);
            this.lblPiccoleSpeseImp.Name = "lblPiccoleSpeseImp";
            this.lblPiccoleSpeseImp.Size = new System.Drawing.Size(204, 13);
            this.lblPiccoleSpeseImp.TabIndex = 13;
            this.lblPiccoleSpeseImp.Text = "Piccole spese non reintegrate";
            this.lblPiccoleSpeseImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPiccoleSpeseImp
            // 
            this.txtPiccoleSpeseImp.Location = new System.Drawing.Point(226, 129);
            this.txtPiccoleSpeseImp.Name = "txtPiccoleSpeseImp";
            this.txtPiccoleSpeseImp.ReadOnly = true;
            this.txtPiccoleSpeseImp.Size = new System.Drawing.Size(136, 20);
            this.txtPiccoleSpeseImp.TabIndex = 14;
            this.txtPiccoleSpeseImp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "E = A + B - C - D";
            // 
            // btnVarPrevCompetenza_S
            // 
            this.btnVarPrevCompetenza_S.Location = new System.Drawing.Point(368, 36);
            this.btnVarPrevCompetenza_S.Name = "btnVarPrevCompetenza_S";
            this.btnVarPrevCompetenza_S.Size = new System.Drawing.Size(75, 23);
            this.btnVarPrevCompetenza_S.TabIndex = 3;
            this.btnVarPrevCompetenza_S.Text = "B";
            this.btnVarPrevCompetenza_S.UseVisualStyleBackColor = true;
            this.btnVarPrevCompetenza_S.Click += new System.EventHandler(this.btnVarPrevCompetenza_S_Click);
            // 
            // lblVarPrevCompetenza_S
            // 
            this.lblVarPrevCompetenza_S.Location = new System.Drawing.Point(13, 38);
            this.lblVarPrevCompetenza_S.Name = "lblVarPrevCompetenza_S";
            this.lblVarPrevCompetenza_S.Size = new System.Drawing.Size(204, 13);
            this.lblVarPrevCompetenza_S.TabIndex = 0;
            this.lblVarPrevCompetenza_S.Text = "Var. Previsione  di Competenza";
            this.lblVarPrevCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevCompetenza_S
            // 
            this.txtVarPrevCompetenza_S.Location = new System.Drawing.Point(226, 35);
            this.txtVarPrevCompetenza_S.Name = "txtVarPrevCompetenza_S";
            this.txtVarPrevCompetenza_S.ReadOnly = true;
            this.txtVarPrevCompetenza_S.Size = new System.Drawing.Size(136, 20);
            this.txtVarPrevCompetenza_S.TabIndex = 2;
            this.txtVarPrevCompetenza_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCompetenza_S
            // 
            this.lblPrevDispCompetenza_S.Location = new System.Drawing.Point(13, 160);
            this.lblPrevDispCompetenza_S.Name = "lblPrevDispCompetenza_S";
            this.lblPrevDispCompetenza_S.Size = new System.Drawing.Size(204, 13);
            this.lblPrevDispCompetenza_S.TabIndex = 0;
            this.lblPrevDispCompetenza_S.Text = "Previsione Disponibile di Competenza";
            this.lblPrevDispCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevDispCompetenza_S
            // 
            this.txtPrevDispCompetenza_S.Location = new System.Drawing.Point(226, 157);
            this.txtPrevDispCompetenza_S.Name = "txtPrevDispCompetenza_S";
            this.txtPrevDispCompetenza_S.ReadOnly = true;
            this.txtPrevDispCompetenza_S.Size = new System.Drawing.Size(136, 20);
            this.txtPrevDispCompetenza_S.TabIndex = 8;
            this.txtPrevDispCompetenza_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnImpegni
            // 
            this.btnImpegni.Location = new System.Drawing.Point(368, 104);
            this.btnImpegni.Name = "btnImpegni";
            this.btnImpegni.Size = new System.Drawing.Size(75, 23);
            this.btnImpegni.TabIndex = 5;
            this.btnImpegni.Text = "C";
            this.btnImpegni.UseVisualStyleBackColor = true;
            this.btnImpegni.Click += new System.EventHandler(this.btnImpegni_Click);
            // 
            // lblImpegni
            // 
            this.lblImpegni.Location = new System.Drawing.Point(13, 106);
            this.lblImpegni.Name = "lblImpegni";
            this.lblImpegni.Size = new System.Drawing.Size(204, 13);
            this.lblImpegni.TabIndex = 0;
            this.lblImpegni.Text = "Impegni di Competenza";
            this.lblImpegni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImpegniCompetenza
            // 
            this.txtImpegniCompetenza.Location = new System.Drawing.Point(226, 103);
            this.txtImpegniCompetenza.Name = "txtImpegniCompetenza";
            this.txtImpegniCompetenza.ReadOnly = true;
            this.txtImpegniCompetenza.Size = new System.Drawing.Size(136, 20);
            this.txtImpegniCompetenza.TabIndex = 4;
            this.txtImpegniCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCompetenza_S
            // 
            this.btnPrevInizialeCompetenza_S.Location = new System.Drawing.Point(368, 8);
            this.btnPrevInizialeCompetenza_S.Name = "btnPrevInizialeCompetenza_S";
            this.btnPrevInizialeCompetenza_S.Size = new System.Drawing.Size(75, 23);
            this.btnPrevInizialeCompetenza_S.TabIndex = 1;
            this.btnPrevInizialeCompetenza_S.Text = "A";
            this.btnPrevInizialeCompetenza_S.UseVisualStyleBackColor = true;
            this.btnPrevInizialeCompetenza_S.Click += new System.EventHandler(this.btnPrevInizialeCompetenza_S_Click);
            // 
            // lblPrevInizialeCompetenza_S
            // 
            this.lblPrevInizialeCompetenza_S.Location = new System.Drawing.Point(13, 12);
            this.lblPrevInizialeCompetenza_S.Name = "lblPrevInizialeCompetenza_S";
            this.lblPrevInizialeCompetenza_S.Size = new System.Drawing.Size(204, 13);
            this.lblPrevInizialeCompetenza_S.TabIndex = 0;
            this.lblPrevInizialeCompetenza_S.Text = "Previsione Iniziale di Competenza";
            this.lblPrevInizialeCompetenza_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCompetenza_S
            // 
            this.txtPrevInizialeCompetenza_S.Location = new System.Drawing.Point(226, 9);
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
            this.grpPrevCassa_S.Location = new System.Drawing.Point(6, 214);
            this.grpPrevCassa_S.Name = "grpPrevCassa_S";
            this.grpPrevCassa_S.Size = new System.Drawing.Size(578, 196);
            this.grpPrevCassa_S.TabIndex = 62;
            this.grpPrevCassa_S.TabStop = false;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(375, 70);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(42, 13);
            this.label29.TabIndex = 26;
            this.label29.Text = "= F + G";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(31, 69);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(186, 13);
            this.label30.TabIndex = 24;
            this.label30.Text = "Previsione  attuale di Cassa";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevAttualeCassaS
            // 
            this.txtPrevAttualeCassaS.Location = new System.Drawing.Point(225, 67);
            this.txtPrevAttualeCassaS.Name = "txtPrevAttualeCassaS";
            this.txtPrevAttualeCassaS.ReadOnly = true;
            this.txtPrevAttualeCassaS.Size = new System.Drawing.Size(137, 20);
            this.txtPrevAttualeCassaS.TabIndex = 25;
            this.txtPrevAttualeCassaS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPiccoleSpesePagamenti
            // 
            this.btnPiccoleSpesePagamenti.Location = new System.Drawing.Point(371, 130);
            this.btnPiccoleSpesePagamenti.Name = "btnPiccoleSpesePagamenti";
            this.btnPiccoleSpesePagamenti.Size = new System.Drawing.Size(75, 23);
            this.btnPiccoleSpesePagamenti.TabIndex = 18;
            this.btnPiccoleSpesePagamenti.Text = " I ";
            this.btnPiccoleSpesePagamenti.UseVisualStyleBackColor = true;
            this.btnPiccoleSpesePagamenti.Click += new System.EventHandler(this.btnPiccoleSpesePagamenti_Click);
            // 
            // lblPiccoleSpesePagamenti
            // 
            this.lblPiccoleSpesePagamenti.Location = new System.Drawing.Point(18, 133);
            this.lblPiccoleSpesePagamenti.Name = "lblPiccoleSpesePagamenti";
            this.lblPiccoleSpesePagamenti.Size = new System.Drawing.Size(199, 13);
            this.lblPiccoleSpesePagamenti.TabIndex = 16;
            this.lblPiccoleSpesePagamenti.Text = "Piccole spese non reintegrate";
            this.lblPiccoleSpesePagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPiccoleSpesePagamenti
            // 
            this.txtPiccoleSpesePagamenti.Location = new System.Drawing.Point(223, 129);
            this.txtPiccoleSpesePagamenti.Name = "txtPiccoleSpesePagamenti";
            this.txtPiccoleSpesePagamenti.ReadOnly = true;
            this.txtPiccoleSpesePagamenti.Size = new System.Drawing.Size(136, 20);
            this.txtPiccoleSpesePagamenti.TabIndex = 17;
            this.txtPiccoleSpesePagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(372, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = " L = F + G - H - I";
            // 
            // btnVarPrevisioneCassa_S
            // 
            this.btnVarPrevisioneCassa_S.Location = new System.Drawing.Point(370, 35);
            this.btnVarPrevisioneCassa_S.Name = "btnVarPrevisioneCassa_S";
            this.btnVarPrevisioneCassa_S.Size = new System.Drawing.Size(75, 23);
            this.btnVarPrevisioneCassa_S.TabIndex = 3;
            this.btnVarPrevisioneCassa_S.Text = " G ";
            this.btnVarPrevisioneCassa_S.UseVisualStyleBackColor = true;
            this.btnVarPrevisioneCassa_S.Click += new System.EventHandler(this.btnVarPrevisioneCassa_S_Click);
            // 
            // lblVarPrevisioneCassa_S
            // 
            this.lblVarPrevisioneCassa_S.Location = new System.Drawing.Point(18, 40);
            this.lblVarPrevisioneCassa_S.Name = "lblVarPrevisioneCassa_S";
            this.lblVarPrevisioneCassa_S.Size = new System.Drawing.Size(199, 13);
            this.lblVarPrevisioneCassa_S.TabIndex = 0;
            this.lblVarPrevisioneCassa_S.Text = "Var. Previsione  di Cassa";
            this.lblVarPrevisioneCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarPrevisioneCassa_S
            // 
            this.txtVarPrevisioneCassa_S.Location = new System.Drawing.Point(224, 35);
            this.txtVarPrevisioneCassa_S.Name = "txtVarPrevisioneCassa_S";
            this.txtVarPrevisioneCassa_S.ReadOnly = true;
            this.txtVarPrevisioneCassa_S.Size = new System.Drawing.Size(136, 20);
            this.txtVarPrevisioneCassa_S.TabIndex = 2;
            this.txtVarPrevisioneCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrevDispCassa_S
            // 
            this.lblPrevDispCassa_S.Location = new System.Drawing.Point(18, 158);
            this.lblPrevDispCassa_S.Name = "lblPrevDispCassa_S";
            this.lblPrevDispCassa_S.Size = new System.Drawing.Size(199, 13);
            this.lblPrevDispCassa_S.TabIndex = 0;
            this.lblPrevDispCassa_S.Text = "Previsione Disponibile di Cassa";
            this.lblPrevDispCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevDispCassa_S
            // 
            this.txtPrevDispCassa_S.Location = new System.Drawing.Point(223, 155);
            this.txtPrevDispCassa_S.Name = "txtPrevDispCassa_S";
            this.txtPrevDispCassa_S.ReadOnly = true;
            this.txtPrevDispCassa_S.Size = new System.Drawing.Size(136, 20);
            this.txtPrevDispCassa_S.TabIndex = 8;
            this.txtPrevDispCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPagamenti
            // 
            this.btnPagamenti.Location = new System.Drawing.Point(370, 103);
            this.btnPagamenti.Name = "btnPagamenti";
            this.btnPagamenti.Size = new System.Drawing.Size(75, 23);
            this.btnPagamenti.TabIndex = 5;
            this.btnPagamenti.Text = " H ";
            this.btnPagamenti.UseVisualStyleBackColor = true;
            this.btnPagamenti.Click += new System.EventHandler(this.btnPagamenti_Click);
            // 
            // lblPagamenti
            // 
            this.lblPagamenti.Location = new System.Drawing.Point(18, 111);
            this.lblPagamenti.Name = "lblPagamenti";
            this.lblPagamenti.Size = new System.Drawing.Size(199, 13);
            this.lblPagamenti.TabIndex = 0;
            this.lblPagamenti.Text = "Pagamenti";
            this.lblPagamenti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPagamenti
            // 
            this.txtPagamenti.Location = new System.Drawing.Point(223, 103);
            this.txtPagamenti.Name = "txtPagamenti";
            this.txtPagamenti.ReadOnly = true;
            this.txtPagamenti.Size = new System.Drawing.Size(136, 20);
            this.txtPagamenti.TabIndex = 4;
            this.txtPagamenti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPrevInizialeCassa_S
            // 
            this.btnPrevInizialeCassa_S.Location = new System.Drawing.Point(370, 9);
            this.btnPrevInizialeCassa_S.Name = "btnPrevInizialeCassa_S";
            this.btnPrevInizialeCassa_S.Size = new System.Drawing.Size(75, 23);
            this.btnPrevInizialeCassa_S.TabIndex = 1;
            this.btnPrevInizialeCassa_S.Text = " F ";
            this.btnPrevInizialeCassa_S.UseVisualStyleBackColor = true;
            this.btnPrevInizialeCassa_S.Click += new System.EventHandler(this.btnPrevInizialeCassa_S_Click);
            // 
            // lblPrevInizialeCassa_S
            // 
            this.lblPrevInizialeCassa_S.Location = new System.Drawing.Point(18, 14);
            this.lblPrevInizialeCassa_S.Name = "lblPrevInizialeCassa_S";
            this.lblPrevInizialeCassa_S.Size = new System.Drawing.Size(199, 13);
            this.lblPrevInizialeCassa_S.TabIndex = 0;
            this.lblPrevInizialeCassa_S.Text = "Previsione Iniziale di Cassa";
            this.lblPrevInizialeCassa_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevInizialeCassa_S
            // 
            this.txtPrevInizialeCassa_S.Location = new System.Drawing.Point(224, 9);
            this.txtPrevInizialeCassa_S.Name = "txtPrevInizialeCassa_S";
            this.txtPrevInizialeCassa_S.ReadOnly = true;
            this.txtPrevInizialeCassa_S.Size = new System.Drawing.Size(136, 20);
            this.txtPrevInizialeCassa_S.TabIndex = 0;
            this.txtPrevInizialeCassa_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grpCrediti);
            this.tabPage4.Controls.Add(this.grpCassa);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(586, 416);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Assegnazione crediti e cassa";
            this.tabPage4.UseVisualStyleBackColor = true;
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
            this.grpCrediti.Size = new System.Drawing.Size(575, 188);
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
            this.grpCassa.Location = new System.Drawing.Point(8, 194);
            this.grpCassa.Name = "grpCassa";
            this.grpCassa.Size = new System.Drawing.Size(575, 228);
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
            this.btnPagamenti1.Click += new System.EventHandler(this.btnPagamenti1_Click);
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
            // btnCalcolaTutto
            // 
            this.btnCalcolaTutto.Location = new System.Drawing.Point(517, 12);
            this.btnCalcolaTutto.Name = "btnCalcolaTutto";
            this.btnCalcolaTutto.Size = new System.Drawing.Size(83, 25);
            this.btnCalcolaTutto.TabIndex = 64;
            this.btnCalcolaTutto.Text = "Calcola totali";
            this.btnCalcolaTutto.UseVisualStyleBackColor = true;
            this.btnCalcolaTutto.Click += new System.EventHandler(this.btnCalcolaTutto_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(263, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 526);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_finview_prevision
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(890, 526);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_finview_prevision";
            this.Text = "Frm_finview_prevision";
            this.gboxNoName.ResumeLayout(false);
            this.gboxNoName.PerformLayout();
            this.grpPrevisione.ResumeLayout(false);
            this.grpPrevPrinc.ResumeLayout(false);
            this.grpPrevPrinc.PerformLayout();
            this.grpPrevSec.ResumeLayout(false);
            this.grpPrevSec.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabCtrl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grpPrevCassa_E.ResumeLayout(false);
            this.grpPrevCassa_E.PerformLayout();
            this.grpPrevCompetenza_E.ResumeLayout(false);
            this.grpPrevCompetenza_E.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.grpPrevCompetenza_S.ResumeLayout(false);
            this.grpPrevCompetenza_S.PerformLayout();
            this.grpPrevCassa_S.ResumeLayout(false);
            this.grpPrevCassa_S.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.grpCrediti.ResumeLayout(false);
            this.grpCrediti.PerformLayout();
            this.grpCassa.ResumeLayout(false);
            this.grpCassa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnSituazione_Click(object sender, System.EventArgs e) {
			object idBilancio = DBNull.Value;
			object idUpb = DBNull.Value;
            object finpart = DBNull.Value;
			DataRow MyRow = HelpForm.GetLastSelected(DS.finview);

			if (MyRow==null) {
                if (DS.finview.Rows.Count == 0) return;
                DataRow Curr = DS.finview.Rows[0];
				idUpb = Curr["idupb"]; // Finview è già filtrata per l'UPB
                TreeNode CurrNode = treeView1.SelectedNode;
                finpart = CurrNode.Text;
            }
			else {
				idUpb = MyRow["idupb"].ToString();
                idBilancio = MyRow["idfin"];
                int flag = CfgFn.GetNoNullInt32(MyRow["flag"]);
                if ((flag & 1) == 1)
                    finpart = "S";
                else
                    finpart = "E";
            }

			DataSet Out = Meta.Conn.CallSP("show_finyear",
				new Object[4] {Meta.GetSys("datacontabile"),
								  idUpb, idBilancio,finpart
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione bilancio di previsione - U.P.B.";
			frmSituazioneViewer view = new frmSituazioneViewer(Out);
			view.Show();
		}

        private void AbilitaSezioniRiepilogo() {
            grpPrevCompetenza_E.Enabled = true;

            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 1) {
                VisualizzaInTabCassaSolo(grpPrevCassa_E, "incassi"); //competenza
                VisualizzaInTabCassaSolo(grpPrevCassa_S, "pagamenti");
            }
            if (CfgFn.GetNoNullInt32(Meta.GetSys("fin_kind")) == 2) {
                grpPrevCompetenza_E.Visible = false;        //cassa : non visualizza nulla
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
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Manca la configurazione annuale dell'esercizio");
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
        void VisualizzaInTabCassaSolo(Control Gbox, string pattern) {
            foreach (Control C in Gbox.Controls) {
                if (C.Name.ToLower().Contains(pattern))
                    C.Visible = true;
                else
                    C.Visible = false;
            }
        }
        private void AbilitaBottoni(bool abilita) {

            btnAccertamentiCompetenza.Enabled = abilita;
            btnAssegnazioniCassa.Enabled = abilita;
            btnCreditiAssegnati.Enabled = abilita;
            btnDotazioneCassa.Enabled = abilita;
            btnDotazioneCrediti.Enabled = abilita;            
            btnIncassi.Enabled = abilita;
            btnPrevInizialeCassa_S.Enabled = abilita;
            btnPrevInizialeCompetenza_E.Enabled = abilita;
            btnVarPrevCompetenza_E.Enabled = abilita;
            btnVarPrevisioneCassa_S.Enabled = abilita;
            btnPiccoleSpeseImp.Enabled = abilita; ;
            btnPiccoleSpesePagamenti.Enabled = abilita;
            btnPiccoleSpesePagamenti1.Enabled = abilita;
            btnCalcolaTutto.Enabled = abilita;            
            btnPrevInizialeCassa_E.Enabled = abilita;
            btnVarPrevCassa_E.Enabled = abilita;
            btnPagamenti.Enabled = abilita;
            btnPiccoleSpesePagamenti.Enabled = abilita;
            btnVarDotazioneCrediti.Enabled = abilita;
            btnVarDotazioneCassa.Enabled = abilita;

            btnPrevInizialeCompetenza_S.Enabled = abilita;
            btnVarPrevCompetenza_S.Enabled = abilita;
            btnImpegni.Enabled = abilita;
            btnPagamenti1.Enabled = abilita;
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


            txtTotaleCassa.Text = "";
            txtTotaleCrediti.Text = "";
            txtPrevAttualeCompetenzaE.Text = "";
            txtPrevAttualeCompetenzaS.Text = "";
            txtPrevAttualeCassaE.Text = "";
            txtPrevAttualeCassaS.Text = "";

            
        }

        private void btnPrevInizialeCompetenza_E_Click(object sender, EventArgs e) {
            VisualizzaPrevIniziale("P", "E");
        }
        private void VisualizzaPrevIniziale(string kind, string finpart) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            if (kind == "P") {
                calcFin.ElencaPrevisioneInizialeCompetenza(finpart);
            }
            else {
                calcFin.ElencaPrevInizialeCassa(finpart);
            }
        }

        private void btnVarPrevCompetenza_E_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagprevision", "E");
        }

        private void VisualizzaFinvarDetail(string flag, string kind) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
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
                }
                else {
                    calcFin.ElencaVarRipartizioneCrediti();
                }
            }
            if (flag == "flagproceeds") {
                if (kind == "var") {
                    calcFin.ElencaVarNormaleCassa();
                }
                else {
                    calcFin.ElencaVarRipartizioneCassa();
                }
            }

        }

        private void btnAccertamentiCompetenza_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;

            calcFin.ElencaAccertamentiCompetenza();
        }

        private void btnPrevInizialeCassa_E_Click(object sender, EventArgs e) {
            VisualizzaPrevIniziale("S", "E");
        }

        private void btnVarPrevCassa_E_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagsecondaryprev", "E");
        }

        private void btnIncassi_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;

            calcFin.ElencaIncassi();
        }

        private void btnPrevInizialeCompetenza_S_Click(object sender, EventArgs e) {
            VisualizzaPrevIniziale("P", "S");
        }

        private void btnVarPrevCompetenza_S_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagprevision", "S");
        }

        private void btnImpegni_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaImpegniCompetenza();
        }

        private void btnPiccoleSpeseImp_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaPiccoleSpeseImp();
        }

        private void btnPrevInizialeCassa_S_Click(object sender, EventArgs e) {
            VisualizzaPrevIniziale("S", "S");
        }

        private void btnVarPrevisioneCassa_S_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagsecondaryprev", "S");
        }

        private void btnPagamenti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencoPagamenti();
        }

        private void btnPiccoleSpesePagamenti_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaPiccoleSpesePag();
        }

        private void btnDotazioneCrediti_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagcredit", "init");
        }

        private void btnVarDotazioneCrediti_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagcredit", "var");
        }

        private void btnCreditiAssegnati_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaAssegnazioniCrediti();
        }

        private void btnDotazioneCassa_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagproceeds", "init");
        }

        private void btnVarDotazioneCassa_Click(object sender, EventArgs e) {
            VisualizzaFinvarDetail("flagproceeds", "var");
        }

        private void btnAssegnazioniCassa_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaAssegnazioniIncassi();
        }

        private void btnPagamenti1_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencoPagamenti();
        }

        private void btnPiccoleSpesePagamenti1_Click(object sender, EventArgs e) {
            DataRow Curr = HelpForm.GetLastSelected(DS.finview);
            if (Curr == null) return;
            calcFin.ElencaPiccoleSpesePag();
        }

        private void CalcolaTotaliEntrata() {
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

            decimal totIncassi = calcFin.TotIncassi();
            txtIncassi.Text = totIncassi.ToString("C");

            decimal totCompetenza = totPrevIniComp + totvarComp;
            txtPrevAttualeCompetenzaE.Text = totCompetenza.ToString("C");

            decimal totCassa = totPrevIniCassa + totvarCassa;
            txtPrevAttualeCassaE.Text = totCassa.ToString("C");


            txtPrevDispCompetenza_E.Text = (totCompetenza - totAccertamenti).ToString("C");
            txtPrevDispCassa_E.Text = (totCassa - totIncassi).ToString("C");
        }

        private void CalcolaTotaliSpese() {
            decimal prevInizialeComp = calcFin.TotPrevInizialeCompetenza("S");
            txtPrevInizialeCompetenza_S.Text = prevInizialeComp.ToString("C");
            decimal varCompetenza = calcFin.TotVarPrevCompetenza("S");
            txtVarPrevCompetenza_S.Text = varCompetenza.ToString("C");

            decimal totCompetenza = prevInizialeComp + varCompetenza;
            txtPrevAttualeCompetenzaS.Text = totCompetenza.ToString("C");

            decimal totImpegni = calcFin.TotImpegniCompetenza();
            txtImpegniCompetenza.Text = totImpegni.ToString("C");

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

        private void chkUpbChilds_CheckedChanged(object sender, EventArgs e) {
            if (calcFin == null) return;
            calcFin.SetUpbWithChilds(chkUpbChilds.Checked);
            pulisciTextRiepilogo();
        }

        private void btnCalcolaTutto_Click(object sender, EventArgs e) {
          
            if (rdbEntrata.Checked) CalcolaTotaliEntrata();
            if (rdbSpesa.Checked) CalcolaTotaliSpese();
        }

        private void btnHideUnused_Click(object sender, EventArgs e) {
            btnHideUnused.Visible = false;
            object idUpb = mainIdUpb;
            string commonFilter = QHS.AppAnd(QHS.CmpEq("U.idupb", idUpb), QHS.CmpEq("F.ayear", Conn.GetSys("esercizio")));
            string sql =
                "select distinct FL.idparent from upbtotal U " +
                " join fin F on U.idfin = F.idfin" +
                " join finlink FL on FL.idchild = F.idfin " +
                " where " + commonFilter +" and " +
                " (isnull(U.currentarrears, 0) <> 0 " +
                " or isnull(U.creditvariation, 0) <> 0 or isnull(U.totcreditpart, 0) <> 0 " +
                " or isnull(U.proceedsvariation, 0) <> 0   or isnull(U.totproceedspart, 0) <> 0 " +
                " or isnull(U.currentprev, 0) <> 0 or isnull(previsionvariation, 0) <> 0 " +
                " or isnull(U.currentsecondaryprev, 0) <> 0 or isnull(secondaryvariation, 0) <> 0 " +
                ")";
            sql += " UNION ";
            sql += " select distinct FL.idparent from upbexpensetotal U " +
                   " join fin F on U.idfin = F.idfin " +
                   " join finlink FL on FL.idchild = F.idfin " +
                  " where " + commonFilter + " and " +
                   " (isnull(U.totalarrears, 0) <> 0 or isnull(U.totalcompetency, 0) <> 0) ";
            sql += " UNION ";
            sql += " select distinct FL.idparent from upbincometotal U " +
                   " join fin F on U.idfin = F.idfin " +
                   " join finlink FL on FL.idchild = F.idfin " +
                  " where " + commonFilter + " and " +
                   " (isnull(U.totalarrears, 0) <> 0 or isnull(U.totalcompetency, 0) <> 0) ";

            DataTable tAll = Conn.SQLRunner(sql);
            if (tAll == null) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Nessuna voce di bilancio risulta utilizzata", "Avviso");
                return;
            }
            List<int> usedIdFin = new List<int>();
            foreach (DataRow r in tAll.Rows) {
                usedIdFin.Add(CfgFn.GetNoNullInt32(r["idparent"]));
            }
            cascadeDeleteUnusedNodes(usedIdFin, treeView1.Nodes);
            string filterFin = QHS.FieldIn("idfin", tAll.Select(), "idparent");
            GetData.SetStaticFilter(DS.finview, filterFin);
            GetData.SetStaticFilter(DS.fin, filterFin);
            btnHideUnused.Visible = true;
        }

	    void cascadeDeleteUnusedNodes(List<int> used, TreeNodeCollection coll) {
	        List<TreeNode> toDelete = new List<TreeNode>();
            foreach (TreeNode tNode in coll) {
                tree_node tn = (tree_node)tNode.Tag;
                bool toKeep = true;
                if (tn != null && tn.Row != null) {
                    int currId = CfgFn.GetNoNullInt32(tn.Row["idfin"]);
                    toKeep = used.Contains(currId);
                }
                if (toKeep) {
                    cascadeDeleteUnusedNodes(used, tNode.Nodes);
                }
                else {
                    toDelete.Add(tNode);
                    object idfin = ((tree_node)tNode.Tag).Row["idfin"];
                    DataRow[] r3 = DS.finyear.Select(QHC.CmpEq("idfin", idfin));
                    foreach (DataRow rr in r3) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }

                    DataRow[] r1 = DS.fin.Select(QHC.CmpEq("idfin", idfin));
                    foreach (DataRow rr in r1) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }
                    DataRow[] r2 = DS.finview.Select(QHC.CmpEq("idfin", idfin));
                    foreach (DataRow rr in r2) {
                        rr.Delete();
                        rr.AcceptChanges();
                    }

                   

                }
            }
	        foreach (TreeNode n in toDelete) {
	            coll.Remove(n);
	        }

        }
    }
}
