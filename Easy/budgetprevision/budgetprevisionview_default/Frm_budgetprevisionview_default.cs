
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
using SituazioneViewer;
using funzioni_configurazione;

namespace budgetprevisionview_default {
	/// <summary>
	/// Summary description for Frm_budgetprevisionview_default.
	/// </summary>
	public class Frm_budgetprevisionview_default : MetaDataForm {
		public budgetprevisionview_default.vistaForm DS;
		public System.Windows.Forms.TabControl MetaDataDetailNO;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.GroupBox grpPrevisione;
		private System.Windows.Forms.TextBox txtPrevisionePrincipalePrecUpb;
        private System.Windows.Forms.TextBox txtPrevisionePrincipaleCorrUpb;
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
       
		private System.Windows.Forms.Splitter splitter1;
        public TabControl MetaDataDetail;
        private System.Windows.Forms.TabPage tabMain;
		private System.Windows.Forms.Label lblEsCorrentePrima;
        private System.Windows.Forms.Label lblEsPrecPrima;
		private System.Windows.Forms.Label lblPrevisione2;
		private System.Windows.Forms.Label lblPrevisione3;
		private System.Windows.Forms.Label lblPrevisione4;
		private System.Windows.Forms.Label lblPrevisione5;
        private System.Windows.Forms.GroupBox gboxPrimaPrevisione;
        public TextBox txtUPB;
        private Button btnUPB;
        private Button btnCalcola;
        bool isSortingOperativo = false;

		public Frm_budgetprevisionview_default() {
			InitializeComponent();
		}
        public object MAIN_idsor;
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
        CQueryHelper QHC;        
        QueryHelper QHS;
        DataAccess Conn;
		public void MetaData_AfterLink() {
			QueryCreator.SetTableForPosting(DS.budgetprevisionview,"budgetprevision");
			Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			object idSorting = Meta.ExtraParameter;
			int esercizio = (int)Meta.GetSys("esercizio");
            string filterEsercizio = QHS.CmpEq("ayear", esercizio);

			string filter = QHS.CmpEq("idsor", idSorting);
            DataTable SortTable = Meta.Conn.RUN_SELECT("sortingview", "idsorkind, codesorkind,sortingkind,idsor,paridsor,sortcode,description,nlevel,leveldescr", null, filter,null, null, true);
            object idsorkind = null;
            if (SortTable.Rows.Count > 0)
            {
                DataRow SortRow = SortTable.Rows[0];
                MetaData.SetDefault(DS.budgetprevisionview, "idsorkind", SortRow["idsorkind"]);
                MetaData.SetDefault(DS.budgetprevisionview, "codesorkind", SortRow["codesorkind"]);
                MetaData.SetDefault(DS.budgetprevisionview, "sortingkind", SortRow["sortingkind"]);
                MetaData.SetDefault(DS.budgetprevisionview, "idsor", SortRow["idsor"]);
                MetaData.SetDefault(DS.budgetprevisionview, "paridsor", SortRow["paridsor"]);
                MetaData.SetDefault(DS.budgetprevisionview, "sortcode", SortRow["sortcode"]);
                MetaData.SetDefault(DS.budgetprevisionview, "sorting", SortRow["description"]);
                MetaData.SetDefault(DS.budgetprevisionview, "nlevel", SortRow["nlevel"]);
                MetaData.SetDefault(DS.budgetprevisionview, "leveldescr", SortRow["leveldescr"]);
                idsorkind = SortRow["idsorkind"];
            }
            string filterLevel = QHS.AppAnd(QHS.BitSet("flag", 1), QHS.CmpEq("idsorkind", idsorkind)); 
			object level = Meta.Conn.DO_READ_VALUE("sortinglevel",filterLevel,"min(nlevel)");

			if ((level != null) && (level != DBNull.Value)) {
                int levelSorting = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", idSorting), "nlevel"));
                isSortingOperativo = (levelSorting >= Convert.ToInt32(level));
			}
            Meta.CanInsert = isSortingOperativo;
            GetData.SetStaticFilter(DS.budgetprevisionview, QHS.AppAnd(filter,filterEsercizio));

			DS.budgetprevisionview.ExtendedProperties["idsor"] = idSorting;
            MAIN_idsor = idSorting;

            GetData.SetStaticFilter(DS.budgetprevision, QHS.AppAnd(filter, filterEsercizio));
            GetData.SetStaticFilter(DS.budgetprevisionview, QHS.AppAnd(filter, filterEsercizio));
	
			cambiaEtichetteEsercizi();
		}

		public void MetaData_AfterActivation() {
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
                    DataRow rConfig = tConfig.Rows[0];
				}
			}
		}

	 
		private void cambiaEtichetteEsercizi() 
		{
			int esercizioCurr = (int)Meta.GetSys("esercizio");
			int esercizioPrec = esercizioCurr - 1;
            string currstr = esercizioCurr.ToString();
            string precstr = esercizioPrec.ToString();
            lblEsCorrentePrima.Text = currstr;
            lblEsCorrPrincCons.Text = currstr;
            lblEsPrecPrima.Text = precstr;           
            lblEsPrecPrincCons.Text = precstr;
			lblPrevisione2.Text = (++esercizioCurr).ToString();
            lblPrev2Cons.Text = esercizioCurr.ToString();
			lblPrevisione3.Text = (++esercizioCurr).ToString();
            lblPrev3Cons.Text = esercizioCurr.ToString();
			lblPrevisione4.Text = (++esercizioCurr).ToString();
            lblPrev4Cons.Text = esercizioCurr.ToString();
			lblPrevisione5.Text = (++esercizioCurr).ToString();
            lblPrev5Cons.Text = esercizioCurr.ToString();
		}

		public void MetaData_AfterClear() {
            btnUPB.Enabled = true;
            FiltraSelezioneUPB(null);			
			azzeraTxtConsolidato();
			btnSituazione.Enabled = true;
			NoUpbSelected=true;
		}

		private void azzeraTxtConsolidato() {
			string empty = "";
			txtPrevisionePrincipaleCorrConsolidato.Text = empty;
	    	txtPrevisionePrincipalePrecConsolidato.Text = empty;
			txtPrevisione2Consolidato.Text = empty;
			txtPrevisione3Consolidato.Text = empty;
			txtPrevisione4Consolidato.Text = empty;
			txtPrevisione5Consolidato.Text = empty;
		}

		public void MetaData_AfterFill() {
			if (Meta.InsertMode) {
				azzeraTxtConsolidato();
				btnSituazione.Enabled = false;
			}
			else {
				azzeraTxtConsolidato();
				btnSituazione.Enabled = true;
			}
		}

		public void MetaData_BeforeFill() {
			if (!Meta.InsertMode) return;
			if (NoUpbSelected){
				FiltraSelezioneUPB(QHS.IsNull("paridupb"));
			}
			else {
				DataRow Curr = HelpForm.GetLastSelected(DS.budgetprevisionview);
				string filter = QHS.CmpEq("paridupb", Curr["paridupb"]);
                FiltraSelezioneUPB(filter);
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
            if (Meta.InsertMode) myfilter = QHS.FieldNotInList("idupb", QHS.DistinctVal(DS.budgetprevisionview.Select(), "idupb"));
            filter = QHS.AppAnd(myfilter, filter);
            AI.startfilter = filter;

            btnUPB.Tag = "choose.upb.default." + filter;
        }

		private void calcolaConsolidato() {
     	    DataRow Curr = HelpForm.GetLastSelected(DS.budgetprevisionview);
            if (Curr == null) {
                azzeraTxtConsolidato();
                return;
            }
            

			decimal previsioneCorr = 0;
		
			decimal previsionePrec = 0;
	
			decimal previsioneAnno2 = 0;
			decimal previsioneAnno3 = 0;
			decimal previsioneAnno4 = 0;
			decimal previsioneAnno5 = 0;
			string filtro = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", Curr["idupb"]), "(paridupb LIKE '" + Curr["idupb"] + "%')"));
            filtro = QHS.AppAnd(filtro,QHS.CmpEq("idsor",MAIN_idsor));
            string expr = "";
            foreach (string field in new string[]{"prevision", "previousprevision", 
                            "prevision2","prevision3","prevision4","prevision5"}) {
                if (expr != "") expr += ",";
                expr += "SUM(" + field + ") as " + field;
            }
            DataTable T = Conn.SQLRunner("SELECT "+expr+" FROM budgetprevisionview WHERE "+filtro, false);

			foreach(DataRow rbudgetprevision in T.Select()) {
				previsioneCorr += (decimal)isNull(rbudgetprevision["prevision"],0m);
				previsionePrec += (decimal)isNull(rbudgetprevision["previousprevision"],0m);
				previsioneAnno2 += (decimal)isNull(rbudgetprevision["prevision2"],0m);
				previsioneAnno3 += (decimal)isNull(rbudgetprevision["prevision3"],0m);
				previsioneAnno4 += (decimal)isNull(rbudgetprevision["prevision4"],0m);
				previsioneAnno5 += (decimal)isNull(rbudgetprevision["prevision5"],0m);
			}
			txtPrevisionePrincipaleCorrConsolidato.Text = previsioneCorr.ToString("c");
			txtPrevisionePrincipalePrecConsolidato.Text = previsionePrec.ToString("c");
			txtPrevisione2Consolidato.Text = previsioneAnno2.ToString("c");
			txtPrevisione3Consolidato.Text = previsioneAnno3.ToString("c");
			txtPrevisione4Consolidato.Text = previsioneAnno4.ToString("c");
			txtPrevisione5Consolidato.Text = previsioneAnno5.ToString("c");
		}

		private object isNull(object a, object b) {
			return ((a == null) || (a == DBNull.Value))	? b : a;
		}

		/// <summary>
		/// Metodo esclude i campi della vista budgetprevisionVIEW non appartenenti alla tabella budgetprevision in fase di salvataggio
		/// e li reinclude dopo aver salvato
		/// </summary>
		/// <param name="salva">TRUE: Campi salvabili; FALSE: Campi non salvabili</param>
		private void impostaCampiDaSalvare(bool salva) {
			if (!salva) {
				string empty = "";
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsorkind"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codesorkind"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortingkind"], empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sorting"],empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortcode"],empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridsor"],empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["upb"],empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codeupb"],empty);
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridupb"],empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["nlevel"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["leveldescr"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor01"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor02"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor03"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor04"], empty);
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor05"], empty);
            }
			else {
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsorkind"], "idsorkind");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codesorkind"], "codesorkind");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortingkind"], "sortingkind");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sorting"],"sorting");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["sortcode"],"sortcode");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridsor"],"paridsor");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["upb"],"upb");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["codeupb"],"codeupb");
				QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["paridupb"],"paridupb");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["nlevel"], "nlevel");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["leveldescr"], "leveldescr");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor01"], "idsor01");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor02"], "idsor02");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor03"], "idsor03");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor04"], "idsor04");
                QueryCreator.SetColumnNameForPosting(DS.budgetprevisionview.Columns["idsor05"], "idsor05");
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
			DataRow Curr = HelpForm.GetLastSelected(DS.budgetprevisionview);
			if (T.TableName == "upb") {
				if (Meta.InsertMode) {
					if (R == null) return;
					Curr["codeupb"] = R["codeupb"];
					Curr["upb"] = R["title"];
					Curr["paridupb"] = R["paridupb"];
				}
			}
			if (T.TableName == "budgetprevisionview") {
				abilitaDisabilitaInserimento();
				FiltraSelezioneUPB(null);
                if (Curr != null) {
                    SetUPB(Curr, Curr["idupb"]);
                }
                else {
                    SetUPB(Curr, DBNull.Value);
                }
				
				azzeraTxtConsolidato();
			}
		}

		/// <summary>
		/// Abilita / Disabilita l'icona di inserimento (se siamo su di un nodo foglia Insert è disabilitato altrimenti è abilitato)
		/// </summary>
		private void abilitaDisabilitaInserimento() {
			DataRow Curr = HelpForm.GetLastSelected(DS.budgetprevisionview);
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
				DataRow [] rowFin = DS.budgetprevisionview.Select(QHS.CmpEq("idupb", drUpb["idupb"]));
				if (rowFin.Length > 0) continue;
				NOK++;
			}

			Meta.CanInsert = (NOK >= 1) && isSortingOperativo;
			Meta.FreshToolBar();
		}

		private void aggiornaTextConsolidato(TextBox txtUpb, TextBox txtCons, ref decimal lastValue) {
			object obj = HelpForm.GetObjectFromString(typeof(decimal), txtUpb.Text, txtUpb.Tag.ToString());
			decimal newValue = (decimal)isNull(obj,0m);
			if (newValue != lastValue) {
				object objConsolidato = HelpForm.GetObjectFromString(typeof(decimal), txtCons.Text,txtCons.Tag.ToString());
				decimal valueConsolidato = (decimal)isNull(objConsolidato,0m);
				valueConsolidato += (newValue - lastValue);
				lastValue = newValue;
				txtCons.Text = valueConsolidato.ToString("c");
			}			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_budgetprevisionview_default));
            this.DS = new budgetprevisionview_default.vistaForm();
            this.MetaDataDetailNO = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.grpPrevisione = new System.Windows.Forms.GroupBox();
            this.gboxPrimaPrevisione = new System.Windows.Forms.GroupBox();
            this.txtPrevisionePrincipalePrecUpb = new System.Windows.Forms.TextBox();
            this.txtPrevisionePrincipaleCorrUpb = new System.Windows.Forms.TextBox();
            this.lblEsCorrentePrima = new System.Windows.Forms.Label();
            this.lblEsPrecPrima = new System.Windows.Forms.Label();
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
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtPrevisione5Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione4Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione3Consolidato = new System.Windows.Forms.TextBox();
            this.txtPrevisione2Consolidato = new System.Windows.Forms.TextBox();
            this.lblPrev5Cons = new System.Windows.Forms.Label();
            this.lblPrev4Cons = new System.Windows.Forms.Label();
            this.lblPrev2Cons = new System.Windows.Forms.Label();
            this.lblPrev3Cons = new System.Windows.Forms.Label();
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
            this.MetaDataDetailNO.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpPrevisione.SuspendLayout();
            this.gboxPrimaPrevisione.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.TabConsolidato.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox11.SuspendLayout();
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
            // MetaDataDetailNO
            // 
            this.MetaDataDetailNO.Controls.Add(this.tabPrincipale);
            this.MetaDataDetailNO.Controls.Add(this.TabConsolidato);
            this.MetaDataDetailNO.Location = new System.Drawing.Point(8, 152);
            this.MetaDataDetailNO.Name = "MetaDataDetailNO";
            this.MetaDataDetailNO.SelectedIndex = 0;
            this.MetaDataDetailNO.Size = new System.Drawing.Size(552, 340);
            this.MetaDataDetailNO.TabIndex = 11;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.grpPrevisione);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(544, 314);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            // 
            // grpPrevisione
            // 
            this.grpPrevisione.Controls.Add(this.gboxPrimaPrevisione);
            this.grpPrevisione.Controls.Add(this.groupBox7);
            this.grpPrevisione.Location = new System.Drawing.Point(8, 8);
            this.grpPrevisione.Name = "grpPrevisione";
            this.grpPrevisione.Size = new System.Drawing.Size(528, 256);
            this.grpPrevisione.TabIndex = 5;
            this.grpPrevisione.TabStop = false;
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
            this.gboxPrimaPrevisione.Text = "Budget";
            // 
            // txtPrevisionePrincipalePrecUpb
            // 
            this.txtPrevisionePrincipalePrecUpb.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisionePrincipalePrecUpb.Name = "txtPrevisionePrincipalePrecUpb";
            this.txtPrevisionePrincipalePrecUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecUpb.TabIndex = 9;
            this.txtPrevisionePrincipalePrecUpb.Tag = "budgetprevisionview.previousprevision";
            // 
            // txtPrevisionePrincipaleCorrUpb
            // 
            this.txtPrevisionePrincipaleCorrUpb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisionePrincipaleCorrUpb.Name = "txtPrevisionePrincipaleCorrUpb";
            this.txtPrevisionePrincipaleCorrUpb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipaleCorrUpb.TabIndex = 8;
            this.txtPrevisionePrincipaleCorrUpb.Tag = "budgetprevisionview.prevision";
            // 
            // lblEsCorrentePrima
            // 
            this.lblEsCorrentePrima.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrentePrima.Name = "lblEsCorrentePrima";
            this.lblEsCorrentePrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrentePrima.TabIndex = 5;
            this.lblEsCorrentePrima.Text = "Corrente";
            this.lblEsCorrentePrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecPrima
            // 
            this.lblEsPrecPrima.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecPrima.Name = "lblEsPrecPrima";
            this.lblEsPrecPrima.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecPrima.TabIndex = 7;
            this.lblEsPrecPrima.Text = "Precedente";
            this.lblEsPrecPrima.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox7.Location = new System.Drawing.Point(8, 70);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(512, 88);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Budget esercizi futuri";
            // 
            // txtPrevisione5Upb
            // 
            this.txtPrevisione5Upb.Location = new System.Drawing.Point(400, 58);
            this.txtPrevisione5Upb.Name = "txtPrevisione5Upb";
            this.txtPrevisione5Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Upb.TabIndex = 18;
            this.txtPrevisione5Upb.Tag = "budgetprevisionview.prevision5";
            // 
            // txtPrevisione4Upb
            // 
            this.txtPrevisione4Upb.Location = new System.Drawing.Point(120, 56);
            this.txtPrevisione4Upb.Name = "txtPrevisione4Upb";
            this.txtPrevisione4Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione4Upb.TabIndex = 17;
            this.txtPrevisione4Upb.Tag = "budgetprevisionview.prevision4";
            // 
            // txtPrevisione3Upb
            // 
            this.txtPrevisione3Upb.Location = new System.Drawing.Point(400, 16);
            this.txtPrevisione3Upb.Name = "txtPrevisione3Upb";
            this.txtPrevisione3Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione3Upb.TabIndex = 16;
            this.txtPrevisione3Upb.Tag = "budgetprevisionview.prevision3";
            // 
            // txtPrevisione2Upb
            // 
            this.txtPrevisione2Upb.Location = new System.Drawing.Point(120, 22);
            this.txtPrevisione2Upb.Name = "txtPrevisione2Upb";
            this.txtPrevisione2Upb.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione2Upb.TabIndex = 15;
            this.txtPrevisione2Upb.Tag = "budgetprevisionview.prevision2";
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
            this.TabConsolidato.Size = new System.Drawing.Size(544, 314);
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
            this.groupBox3.Controls.Add(this.groupBox11);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 266);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
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
            this.groupBox8.Text = "Budget";
            // 
            // txtPrevisionePrincipalePrecConsolidato
            // 
            this.txtPrevisionePrincipalePrecConsolidato.Location = new System.Drawing.Point(400, 22);
            this.txtPrevisionePrincipalePrecConsolidato.Name = "txtPrevisionePrincipalePrecConsolidato";
            this.txtPrevisionePrincipalePrecConsolidato.ReadOnly = true;
            this.txtPrevisionePrincipalePrecConsolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisionePrincipalePrecConsolidato.TabIndex = 9;
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
            this.txtPrevisionePrincipaleCorrConsolidato.Tag = "";
            this.txtPrevisionePrincipaleCorrConsolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEsCorrPrincCons
            // 
            this.lblEsCorrPrincCons.Location = new System.Drawing.Point(8, 24);
            this.lblEsCorrPrincCons.Name = "lblEsCorrPrincCons";
            this.lblEsCorrPrincCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsCorrPrincCons.TabIndex = 5;
            this.lblEsCorrPrincCons.Text = "Es. Corr.";
            this.lblEsCorrPrincCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsPrecPrincCons
            // 
            this.lblEsPrecPrincCons.Location = new System.Drawing.Point(288, 24);
            this.lblEsPrecPrincCons.Name = "lblEsPrecPrincCons";
            this.lblEsPrecPrincCons.Size = new System.Drawing.Size(100, 16);
            this.lblEsPrecPrincCons.TabIndex = 7;
            this.lblEsPrecPrincCons.Text = "Es. Prec.";
            this.lblEsPrecPrincCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.groupBox11.Location = new System.Drawing.Point(6, 70);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(512, 96);
            this.groupBox11.TabIndex = 18;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Budget esercizi futuri";
            // 
            // txtPrevisione5Consolidato
            // 
            this.txtPrevisione5Consolidato.Location = new System.Drawing.Point(400, 58);
            this.txtPrevisione5Consolidato.Name = "txtPrevisione5Consolidato";
            this.txtPrevisione5Consolidato.ReadOnly = true;
            this.txtPrevisione5Consolidato.Size = new System.Drawing.Size(100, 20);
            this.txtPrevisione5Consolidato.TabIndex = 18;
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
            this.txtPrevisione2Consolidato.Tag = "";
            this.txtPrevisione2Consolidato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrev5Cons
            // 
            this.lblPrev5Cons.Location = new System.Drawing.Point(296, 60);
            this.lblPrev5Cons.Name = "lblPrev5Cons";
            this.lblPrev5Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev5Cons.TabIndex = 14;
            this.lblPrev5Cons.Text = "Budget 2009";
            this.lblPrev5Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev4Cons
            // 
            this.lblPrev4Cons.Location = new System.Drawing.Point(16, 59);
            this.lblPrev4Cons.Name = "lblPrev4Cons";
            this.lblPrev4Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev4Cons.TabIndex = 13;
            this.lblPrev4Cons.Text = "Budget 2008";
            this.lblPrev4Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev2Cons
            // 
            this.lblPrev2Cons.Location = new System.Drawing.Point(16, 24);
            this.lblPrev2Cons.Name = "lblPrev2Cons";
            this.lblPrev2Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev2Cons.TabIndex = 11;
            this.lblPrev2Cons.Text = "Budget 2006";
            this.lblPrev2Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPrev3Cons
            // 
            this.lblPrev3Cons.Location = new System.Drawing.Point(295, 21);
            this.lblPrev3Cons.Name = "lblPrev3Cons";
            this.lblPrev3Cons.Size = new System.Drawing.Size(100, 16);
            this.lblPrev3Cons.TabIndex = 12;
            this.lblPrev3Cons.Text = "Budget 2007";
            this.lblPrev3Cons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Location = new System.Drawing.Point(8, 104);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(552, 48);
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
            this.txtUPB.Size = new System.Drawing.Size(441, 20);
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
            this.treeView1.Size = new System.Drawing.Size(216, 526);
            this.treeView1.TabIndex = 8;
            this.treeView1.Tag = "budgetprevisionview.tree";
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
            this.groupBox2.Size = new System.Drawing.Size(552, 96);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informazioni sulla voce di Classificazione";
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(471, 21);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(75, 23);
            this.btnSituazione.TabIndex = 12;
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
            this.txtCodiceBilancio.Tag = "budgetprevisionview.sortcode";
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
            this.txtDenominazioneBilancio.Tag = "budgetprevisionview.sorting";
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
            this.splitter1.Size = new System.Drawing.Size(3, 526);
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
            this.MetaDataDetail.Size = new System.Drawing.Size(573, 526);
            this.MetaDataDetail.TabIndex = 14;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.gboxUPB);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Controls.Add(this.MetaDataDetailNO);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(565, 500);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Principale";
            // 
            // Frm_budgetprevisionview_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 526);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_budgetprevisionview_default";
            this.Text = "Frm_budgetprevisionview_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetailNO.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.grpPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.ResumeLayout(false);
            this.gboxPrimaPrevisione.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.TabConsolidato.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
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
			object idSorting;
            object idUpb;

			DataRow MyRow = HelpForm.GetLastSelected(DS.budgetprevisionview);
			if (MyRow ==null) return;
			idSorting = MyRow["idsor"];
			idUpb = MyRow["idupb"];



            DataSet Out = Meta.Conn.CallSP("show_budget_sorting",
                new Object[3] {Meta.GetSys("datacontabile"),
								  idUpb, idSorting}
                );
			if (Out==null) return;
			Out.Tables[0].TableName= "Situazione Budget";
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

    }
}
