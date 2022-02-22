
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Collections;

namespace ct_expenselast_reset {
    public partial class Frm_ct_expenselast_reset : MetaDataForm {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        ContextMenu ExcelMenu;
        DataAccess Conn;
        public Frm_ct_expenselast_reset() {
            InitializeComponent();
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            gridDettagli.ContextMenu = ExcelMenu;
            
        }

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null)
                return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType())))
                return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType())))
                return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null)
                return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType()))
                return;
            string DDT = G.DataMember;
            if (DDT == null)
                return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null)
                return;
            exportclass.DataTableToExcel(T, true);
        }

        private string nomefase;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            //RiempiGrid();
            btnSelezionaTutto.Enabled = false;
            btnAzzera.Enabled = false;
            nomefase = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", Meta.GetSys("maxexpensephase")), "description").ToString();
        }

        private object calcola_idsor0i(string idsor0i) {
            object defaultValue = DBNull.Value;

            string NtoS = idsor0i.Substring(5, 2);

            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value)
                as_filter = "N";
            object all_value = "S";

            if (as_filter.ToString().ToUpper() == "S") {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(all_sorkind" + NtoS + ",'S')");
                if (all_value == null || all_value == DBNull.Value) {
                    all_value = "S";
                }
            }

            if (all_value.ToString().ToUpper() == "S") {
                defaultValue = DBNull.Value;
                return defaultValue;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            defaultValue = idsor;
            return defaultValue;
        }

        DataTable Tmovimenti = null;
        bool RiempiGrid() {
            object idsor01 = calcola_idsor0i("idsor01");
            object idsor02 = calcola_idsor0i("idsor02");
            object idsor03 = calcola_idsor0i("idsor03");
            object idsor04 = calcola_idsor0i("idsor04");
            object idsor05 = calcola_idsor0i("idsor05");
            object esercizio =  Meta.GetSys("esercizio");
            object escludifatture = "N";
            if (chkEscludiContabilizzazioni.Checked) {
                escludifatture = "S";
            }

            object[] param = new object[] { esercizio, idsor01, idsor02, idsor03, idsor04, idsor05, escludifatture };
            DataSet DSpagamenti = Conn.CallSP("get_expense_toreset", param, true,300);
            if (DSpagamenti == null || DSpagamenti.Tables.Count == 0)
                return false;
            Tmovimenti = DSpagamenti.Tables[0];
            
            Tmovimenti.Columns["idexp"].Caption = "codice";
            Tmovimenti.Columns["ymov"].Caption = "Esercizio";
            Tmovimenti.Columns["nmov"].Caption = "Numero";
            Tmovimenti.Columns["curramount"].Caption = "ImportoCorrente";
            Tmovimenti.Columns["registry"].Caption = "Anagrafica";
            Tmovimenti.Columns["codeupb"].Caption = "CodiceUPB";
            Tmovimenti.Columns["codefin"].Caption = "CodiceBilancio";
            Tmovimenti.Columns["description"].Caption = "Descrizione";           
            Tmovimenti.Columns["kpay"].Caption = "";
            Tmovimenti.Columns["npay"].Caption = "numero mandato";

            Tmovimenti.AcceptChanges();
            gridDettagli.DataSource = null;
            gridDettagli.TableStyles.Clear();
            HelpForm.SetDataGrid(gridDettagli, Tmovimenti);

            lookupRows = new Dictionary<int, DataRow>();
            foreach (DataRow r in Tmovimenti.Rows) {
                lookupRows[CfgFn.GetNoNullInt32(r["idexp"])] = r;
            }
            
            SelezionaTutto();
          
            return true;
        }

        private Dictionary<int, DataRow> lookupRows = new Dictionary<int, DataRow>();

        private void btnSelezionaTutto_Click(object sender, EventArgs e){
            SelezionaTutto();
        }

        void SelezionaTutto(){
			object dataSource = gridDettagli.DataSource;
			if (dataSource==null) return;

			CurrencyManager cm = (CurrencyManager) 
				gridDettagli.BindingContext[dataSource, gridDettagli.DataMember];

			DataView view = cm.List as DataView;

			if (view != null) {
				for (int i=0; i<view.Count; i++) {
					gridDettagli.Select(i);
				}
			}
		}

        private DataRow[] GetGridSelectedRows(DataGrid G){
			if (G.DataMember==null) return null;
			if (G.DataSource==null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS =(DataSet)G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp=MyTable.Rows.Count;
			int numrighe=0;
			int i;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					numrighe++;
				}
			}

			DataRow[] Res=new DataRow[numrighe]; 			
			int count=0;
			for (i=0; i<numrighetemp; i++){
				if(G.IsSelected(i)){
					Res[count++]= GetGridRow(G,i);
				}
			}
			return Res;
		}

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;          
            return lookupRows[CfgFn.GetNoNullInt32(G[index, 0])];
          
        }

       

      

        private void btnAzzera_Click(object sender, EventArgs e) {
            DataRow[] Mov_SelectedRows = GetGridSelectedRows(gridDettagli);
            if ((Mov_SelectedRows == null) || (Mov_SelectedRows.Length == 0)) {
                show("Non è stato selezionato alcun movimento da annullare.");
                return;
            }
            Azzera(Mov_SelectedRows);
        }

        public bool DatiValidi(DataAccess Conn, int esercizio) {
            DataTable EsercizioTable =
                Conn.RUN_SELECT("accountingyear", "*", null, QHS.CmpEq("ayear", esercizio), null, true);

            if (EsercizioTable.Rows.Count == 0) {
                show("L'esercizio " + esercizio + " non è stato creato.");
                return false;
            }
            return true;
        }
        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall,
                filteranno,
                QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno,
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

        DataAccess ottieniConnessioneNuovoEsercizio(DataAccess Conn) {
            int esercizio = Conn.GetEsercizio();
            int newEsercizio = esercizio + 1;
            if (!DatiValidi(Conn, newEsercizio)) return null;

            DateTime newDate = new DateTime(newEsercizio, 1, 1);
            if (!CambioDataConsentita(Conn, newDate)) {
                show("L'utente non ha diritto ad agire nell'esercizio " + newEsercizio, "Errore");
                return null;
            }
            Easy_DataAccess newConn = (Easy_DataAccess) Conn.Duplicate();
            newConn.SetSys("esercizio", newEsercizio);
            newConn.SetSys("datacontabile", newDate);


            newConn.RecalcUserEnvironment(Conn.GetSys("idflowchart"), Conn.GetSys("ndetail"));
            newConn.ReadAllGroupOperations();

            return newConn;
        }


        private void Azzera(DataRow[] MovimentiSelezionati) {

            DataSet dNew = DS.Copy();

            string DistVal = "";
            string DistValkpay = "";
            for (int i = 0; i < MovimentiSelezionati.Length; i++) {
                if (DistVal != "") DistVal += ",";
                DistVal = DistVal + MovimentiSelezionati[i]["idexp"];

                if (DistValkpay != "") DistValkpay += ",";
                DistValkpay = DistValkpay + MovimentiSelezionati[i]["kpay"];
            }
            string filterMov = QHC.FieldInList("idexp", DistVal);
            Conn.RUN_SELECT_INTO_TABLE(DS.expense, null, filterMov, null, false);
            Conn.RUN_SELECT_INTO_TABLE(DS.expenselast, null, filterMov, null, false);
            string filterPayment = QHC.FieldInList("kpay", DistValkpay);
            Conn.RUN_SELECT_INTO_TABLE(DS.payment, null, filterPayment, null, false);
           

            //Calcola newConn
            DataAccess newConn = ottieniConnessioneNuovoEsercizio(Conn);
            if (newConn == null) return;

            bool errori = false;
            for (int i = 0; i < MovimentiSelezionati.Length; i++) {
                DataRow Ri = MovimentiSelezionati[i];
                if (!ElaboraMovimento(Ri,Conn, DS, newConn, dNew)) errori=true;
            }
            if (errori) {
                newConn.Close();
                newConn.Destroy();
                return;
            }
            //Effettua il post
            PostData Post = Meta.Get_PostData();
            Post.InitClass(DS, Conn);
            Post.InitClass(dNew, newConn);
            bool res = Post.DO_POST();

            newConn.Close();
            newConn.Destroy();
            if (res) {
               
                string mess = "Operazione Eseguita con successo.";
                show(mess);
                btnAzzera.Visible = false;
                btnAnnulla.Text = "Chiudi";
            }
            else {
                DS.expense.Clear();
                DS.expensevar.Clear();
                DS.expensesorted.Clear();
                DS.expenseyear.Clear();
                DS.expenselast.Clear();
                DS.payment.Clear();
                return;
            }
        }

        
        private void RiempiExpSorted(DataAccess conn, MetaData metaExpSorted,  DataTable expSortedTable, int segno, DataTable tClassificazioni, object currIdexp, bool parent) {
            string suffix = parent ? "parent" : "";
            foreach (DataRow R4 in tClassificazioni.Rows) {
                object idexp = parent ? R4["idexpparent"] : currIdexp;
                if (idexp == DBNull.Value) continue;
                MetaData.SetDefault(expSortedTable, "idexp", idexp);
                object idsor = R4["idsor" + suffix];
                if (idsor == DBNull.Value) continue;
                MetaData.SetDefault(expSortedTable, "idsor", idsor);
                DataRow rExpSorted = metaExpSorted.Get_New_Row(null, expSortedTable);
                rExpSorted["amount"] = segno * CfgFn.GetNoNullDecimal(R4["amount"]);
                rExpSorted["idexp"] = idexp;
                rExpSorted["ayear"] = conn.GetSys("esercizio");
                rExpSorted["description"] = segno<0? "Azzeramento " +nomefase:"Riemissione "+nomefase;
                rExpSorted["idsor"] = R4["idsor"+ suffix];
            }

        }

        private bool ElaboraMovimento(DataRow R, DataAccess currConn, vistaForm currDS, DataAccess newConn, DataSet newDS){
            object curr_idexp = R["idexp"];
            
            DataRow[] selectresult = DS.expense.Select(QHC.CmpEq("idexp", curr_idexp));
            if (selectresult.Length == 0)return true;
            DataRow Curr = selectresult[0];
            selectresult = DS.expenselast.Select(QHC.CmpEq("idexp", curr_idexp));
            if (selectresult.Length == 0)return true;
            DataRow CurrLast = selectresult[0];
            object curr_kpay = CurrLast["kpay"];
            DataRow[] payment = DS.payment.Select(QHC.CmpEq("kpay", curr_kpay));
            DataRow CurrPayment = payment[0];
            CurrPayment["annulmentdate"] = new DateTime(Convert.ToInt32(Meta.GetSys("esercizio")), 12, 31);
            int esercizioSucc = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1;

            EntityDispatcher dCurr = (EntityDispatcher) Meta.Dispatcher;
            EntityDispatcher dNew = new Meta_EasyDispatcher(newConn);

            MetaData ExpVar = MetaData.GetMetaData(this, "expensevar");
            MetaData ExpSorted = MetaData.GetMetaData(this, "expensesorted");
            DataTable dtExpVar = currDS.expensevar;
            DataTable dtExpSorted = currDS.expensesorted;
            ExpVar.SetDefaults(currDS.expensevar);
            ExpSorted.SetDefaults(currDS.expensesorted);

            MetaData.SetDefault(currDS.expensevar, "idexp", curr_idexp);
            MetaData.SetDefault(currDS.expensesorted, "idexp", curr_idexp);


            MetaData ExpNew = dNew.Get("expense"); 
            MetaData ExpYearNew = dNew.Get("expenseyear"); 
            MetaData ExpLastNew = dNew.Get("expenselast");  
            MetaData ExpSortedNew = dNew.Get("expensesorted");


            DataTable dtExpNew = newDS.Tables["expense"];
            DataTable dtExpYearNew = newDS.Tables["expenseyear"];
            DataTable dtExpLastNew = newDS.Tables["expenselast"];
            DataTable dtExpSortedNew = newDS.Tables["expensesorted"];

            ExpNew.SetDefaults(dtExpNew);
            ExpYearNew.SetDefaults(dtExpYearNew);
            ExpLastNew.SetDefaults(dtExpLastNew);
            ExpSortedNew.SetDefaults(dtExpSortedNew);




            // Nuova riga in expensevar: crea la variazione in diminuzione sul movimento corrente
            DataRow rExpVar = ExpVar.Get_New_Row(Curr, dtExpVar);
            string fltmovS = QHS.CmpEq("idexp", curr_idexp);
            object nvar = null;
            if (currConn.RUN_SELECT_COUNT("expensevar", fltmovS, false) > 0) {
                object max_nvar = currConn.DO_READ_VALUE("expensevar", QHS.CmpEq("idexp", curr_idexp), "max(nvar)");
                nvar = CfgFn.GetNoNullInt32(max_nvar) + 1;
            }
            else {
                nvar = 1;
            }
            RowChange.ClearAutoIncrement(dtExpVar.Columns["nvar"]);
            rExpVar["nvar"] = nvar;
            rExpVar["yvar"] = Meta.GetSys("esercizio");
            rExpVar["description"] = "Azzeramento mandato";
            rExpVar["amount"] = -CfgFn.GetNoNullDecimal(R["curramount"]);
            rExpVar["autokind"] = 11;// non c'è un autokind particolare in questo caso
            rExpVar["adate"] = Meta.GetSys("datacontabile");

            //Ottengo un DataTable con gli importi di classificazione raggruppati per codice, così non considero la class. parziali
            int esercizio = (int)Meta.GetSys("esercizio");
            string queryF4 = " select es1.idsor, s1.sortcode, s1.idsorkind, es1.amount, s2.idsor as idsorparent, EL.idparent as idexpparent"
                             + " from expense "
                             + " join expensesorted es1 on es1.idexp = expense.idexp  "
                             + " join sorting s1 on s1.idsor = es1.idsor "
                             + " join sortingkind sk on sk.idsorkind = s1.idsorkind "
                             + " left outer join sortingkind sk2 on sk2.idsorkind = sk.idparentkind   "
                             + " left outer join sorting s2 on s2.idsorkind=sk2.idsorkind and s2.sortcode=s1.sortcode "
                             + " left outer join expenselink EL on EL.idchild=expense.idexp and EL.nlevel = sk2.nphaseexpense "
                             + " where " + QHS.AppAnd( QHS.CmpEq("expense.idexp", curr_idexp), QHS.CmpEq("es1.ayear",esercizio));
           DataTable tClassificazioni = currConn.SQLRunner(queryF4);

          

            //Cicla per ogni tipo classificazione di Fase 4

                
            RiempiExpSorted(currConn, ExpSorted,  dtExpSorted, -1, tClassificazioni, curr_idexp, false);

            // Nuova riga di EXPENSE NEW
            Hashtable saveddefaults_ExpNew = new Hashtable();
            foreach (DataColumn C in dtExpNew.Columns) {
                saveddefaults_ExpNew[C.ColumnName] = C.DefaultValue;
            }

            int maxPhase = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));
            MetaData.SetDefault(dtExpNew, "nphase", maxPhase);
            DateTime datacontabile = new DateTime(esercizioSucc, 1, 1);// Data contabile nuova liquidazione 01/01/@ayear+1
            MetaData.SetDefault(dtExpNew, "ymov", esercizioSucc);
            MetaData.SetDefault(dtExpNew, "adate", datacontabile);
            MetaData.SetDefault(dtExpNew, "parentidexp", Curr["parentidexp"]);
            DataRow rNewExp = ExpNew.Get_New_Row(null, dtExpNew);
            int idexp = CfgFn.GetNoNullInt32(rNewExp["idexp"]);
            if (idexp < 10000000)
                idexp = 10000000;
            rNewExp["idexp"] = idexp;
            string[] fieldToCopyExpense = new string[] {"doc","docdate","idreg","description","expiration","rtf","txt","idman","cigcode","cupcode","expiration"};
            foreach (string f in fieldToCopyExpense) {
                rNewExp[f] = Curr[f];
            }
            rNewExp["autokind"] = 27;// pagamenti creati con la procedura di Azzeramento Fine Anno, personalizzazione per Catania
            rNewExp["idformerexpense"] = curr_idexp; // Inserisce l'associazione col pagamento che ha azzerato
            foreach (DataColumn CC in dtExpNew.Columns) {
                CC.DefaultValue = saveddefaults_ExpNew[CC.ColumnName];
            }

            // Nuova riga in expenseyear: crea la riga di imputazione del nuovo movimento creato
            Hashtable saveddefaults_ExpYearNew = new Hashtable();
            foreach (DataColumn C in dtExpYearNew.Columns) {
                saveddefaults_ExpYearNew[C.ColumnName] = C.DefaultValue;
            }
            object newidfin = Calcola_newidfin(R["codefin"]);
            if (newidfin == null) {
                show($"Nell'anno {Conn.GetEsercizio()} non è stata trovata una voce di bilancio mappata alla voce di "+
                    $" codice {R["codefin"]} dell'anno precedente","Errore");
                return false;
            }
            object idupb = currConn.DO_READ_VALUE("upb", QHS.CmpEq("codeupb", R["codeupb"]),"idupb");
            MetaData.SetDefault(dtExpYearNew, "ayear", esercizioSucc);
            DataRow rExpyearNew = ExpYearNew.Get_New_Row(rNewExp, dtExpYearNew);
            rExpyearNew["ayear"] = esercizioSucc;
            rExpyearNew["idfin"] = newidfin;
            rExpyearNew["idupb"] = idupb;
            rExpyearNew["amount"] = CfgFn.GetNoNullDecimal(R["curramount"]);

            // Nuova riga in expenselast
            MetaData.SetDefault(dtExpLastNew, "idexp", idexp);
            DataRow rExpLastNew = ExpLastNew.Get_New_Row(rNewExp, dtExpLastNew);

            foreach (DataColumn CC in dtExpLastNew.Columns) {
                if (CC.ColumnName == "idexp" || CC.ColumnName == "kpay") continue;
                rExpLastNew[CC.ColumnName] = CurrLast[CC.ColumnName];
            }

            foreach (DataColumn CC in dtExpYearNew.Columns) {
                CC.DefaultValue = saveddefaults_ExpYearNew[CC.ColumnName];
            }


            // Nuove righe in expensesorted: crea le classificazioni per il movimento creato
            RiempiExpSorted(newConn, ExpSortedNew, dtExpSortedNew, 1, tClassificazioni, idexp, false);
            RiempiExpSorted(newConn, ExpSortedNew, dtExpSortedNew, 1, tClassificazioni, DBNull.Value, true);
            return true;       
            
        }
        private object Calcola_newidfin(object curr_codefin) {
            string filter = QHS.AppAnd(QHS.CmpEq("codefin",curr_codefin), QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.BitSet("flag", 0));
            object curr_idfin = Conn.DO_READ_VALUE("fin", filter, "idfin");
            string filter_lookup = QHS.CmpEq("oldidfin",curr_idfin);
            object new_idfin = Conn.DO_READ_VALUE("finlookup", filter_lookup, "newidfin"); 
            return new_idfin;

        }

        private void btnMostraPagamenti_Click(object sender, EventArgs e) {
            btnMostraPagamenti.Visible = false;
            chkEscludiContabilizzazioni.Enabled = false;
            btnSelezionaTutto.Enabled = true;
            btnAzzera.Enabled = true;
            RiempiGrid();
        }

        private void chkEscludiContabilizzazioni_CheckedChanged(object sender, EventArgs e) {
        }


    }
}
