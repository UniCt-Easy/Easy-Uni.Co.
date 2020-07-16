/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using System.Collections.Generic;
using System.Collections;
using funzioni_configurazione;

namespace ep_functions {
    public partial class FrmImpegniBudget : Form {     
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaDataDispatcher Disp;
		DataAccess Conn;
        Hashtable RighePadriMovimento;
        public DataTable Automatismi;
        DataSet D;
        ContextMenu ExcelMenu;
        private bool cicloAttivo = false;
        private string tableEp;
        private string tableEpYear;
        private string idTableEp;
        public FrmImpegniBudget(MetaDataDispatcher Disp, DataSet D, bool cicloAttivo) {
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            
            InitializeComponent();

            this.cicloAttivo = cicloAttivo;
            this.Disp=Disp;
			this.Conn= Disp.Conn;
            QHC= new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            this.D = D;
            if (cicloAttivo) {
                this.Text = "Generazione automatica accertamenti di Budget";
            }
            else {
                this.Text = "Generazione automatica impegni di Budget";
            }
           
            MetaData.SetColor(this);
            RighePadriMovimento = new Hashtable();
            Automatismi = new DataTable("auto");
            tableEp = cicloAttivo ? "epacc" : "epexp";
            tableEpYear = tableEp + "year";
            idTableEp = "id" + tableEp;
            myAccount = Conn.RUN_SELECT("account", "idacc,codeacc,title", null, QHS.FieldIn("idacc", D.Tables[tableEpYear].Select()), null, false);
            myUPB = Conn.RUN_SELECT("upb", "idupb,codeupb,title", null, QHS.FieldIn("idupb", D.Tables[tableEpYear].Select()), null, false);
            myRegistry = Conn.RUN_SELECT("registry", "idreg,title", null, QHS.FieldIn("idreg", D.Tables[tableEp].Select()), null, false);
            myManager = Conn.RUN_SELECT("manager", "idman,title", null, QHS.FieldIn("idman", D.Tables[tableEp].Select()), null, false);


            foreach (DataColumn C in D.Tables[tableEp].Columns) {
                Automatismi.Columns.Add(C.ColumnName, C.DataType);
            }
            foreach (DataColumn C in D.Tables[tableEpYear].Columns) {
                if (Automatismi.Columns.Contains(C.ColumnName))
                    continue;
                Automatismi.Columns.Add(C.ColumnName, C.DataType);
            }
            Automatismi.Columns.Add("livsupid", typeof(string));
            Automatismi.Columns.Add("manager", typeof(string));
            //Automatismi.Columns.Add("codeacc", typeof(string));
            //Automatismi.Columns.Add("account", typeof(string));
            //Automatismi.Columns.Add("codeupb", typeof(string));
            //Automatismi.Columns.Add("upb", typeof(string));
            Dictionary<int, DataRow> epyByIdExp = new Dictionary<int, DataRow>();
            foreach (DataRow rr in D.Tables[tableEpYear].Rows) {
                epyByIdExp[(int) rr[idTableEp]] = rr;
            }
            foreach (DataRow r in D.Tables[tableEp].Select()) {
                DataRow ry = epyByIdExp[(int) r[idTableEp]]; //D.Tables[tableEpYear].Select(QHC.CmpEq(idTableEp, r[idTableEp]))[0];

                DataRow newR = Automatismi.NewRow();
                foreach (DataColumn C in D.Tables[tableEp].Columns) {
                    newR[C.ColumnName] = r[C.ColumnName];
                }
                foreach (DataColumn C in D.Tables[tableEpYear].Columns) {
                    if (D.Tables[tableEp].Columns.Contains(C.ColumnName))
                        continue;
                    newR[C.ColumnName] = ry[C.ColumnName];
                }
                isAdded[Automatismi.Rows.Count] = (r.RowState == DataRowState.Added);
                Automatismi.Rows.Add(newR);
            }
            Automatismi.AcceptChanges();
            FillRighePadriMovimento();
            FillTables(Automatismi.Select());            
            GetData.SetSorting(DS.epexpview, "nepexp asc");
            GetData.SetSorting(DS.epaccview, "nepacc asc");
            gridSpesa.ContextMenu = ExcelMenu;
        }

        private Dictionary<int, bool> isAdded = new Dictionary<int, bool>();

        void FillRighePadriMovimento() {
            DataTable P = Conn.CreateTableByName(tableEp+"view", "*");
            foreach (DataRow r in D.Tables[tableEp].Select(QHC.IsNotNull("par"+idTableEp))) {
                object idepmov= r["par" + idTableEp];

                DataRow[] inMem = D.Tables[tableEp].Select(QHC.CmpEq(idTableEp, idepmov));
                if (inMem.Length > 0) {
                    RighePadriMovimento[CfgFn.GetNoNullInt32(idepmov)] = inMem[0];
                    continue;
                }
                string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
                    QHS.CmpEq(idTableEp, idepmov));
                Conn.RUN_SELECT_INTO_TABLE(P,null,filtro,null,false);
                DataRow []rr= P.Select(QHC.CmpEq(idTableEp, idepmov));
                if (rr.Length > 0) {
                    RighePadriMovimento[CfgFn.GetNoNullInt32(idepmov)] = rr[0];
                    continue;
                }
                throw new Exception("Riga non trovata nella tabella " + tableEp + "view con filtro " + filtro);
            }
        }

        private void Excel_Click(object menusender, EventArgs e)
        {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }
        /// <summary>
        /// Copia tutti i valori possibili di R in T
        /// </summary>
        /// <param name="R"></param>
        /// <param name="T"></param>
        /// <param name="i"></param>
        void AddRowToTable(DataRow R, DataTable T, int i) {
            DataRow NewR = T.NewRow();
            if (T.TableName == tableEp+"view") {
                NewR[idTableEp] = i;
            }
            foreach (DataColumn C in R.Table.Columns) {
                if (C.ColumnName == "movkind")
                    continue;
                if (T.Columns[C.ColumnName] == null)
                    continue;
                if (C.ColumnName == idTableEp)
                    continue;
                NewR[C.ColumnName] = R[C.ColumnName];
            }
            T.Rows.Add(NewR);
            NewR.AcceptChanges();
        }

        /// <summary>
        /// Riempie le tabelle incomeview, expenseview e expensevarview in base alle righe di automatismi
        /// </summary>
        /// <param name="Automatismi"></param>
        void FillTables(DataRow[] Automatismi) {
            
            for (int i = 0; i < Automatismi.Length; i++) {
                DataRow R = Automatismi[i];
                AddRowToTable(R, cicloAttivo? DS.epaccview: DS.epexpview, i);
            }

            MetaData MEpexpView = Disp.Get(tableEp+"view");
            MEpexpView.DescribeColumns(DS.Tables[tableEp + "view"], "autogenerati");

            HelpForm.SetDataGrid(gridSpesa, DS.Tables[tableEp + "view"]);


            RicalcolaCampiCalcolati();

        }


        /// <summary>
        /// Cambia info bilancio di MView in base a MChoosen
        /// </summary>
        /// <param name="MView"></param>
        /// <param name="MChoosen"></param>
        void CambiaVoceConto(DataRow MView, DataRow MChoosen) {
            //Per ogni movimento in income/expenseview con livsupid non vuoto copia idfin/codefin
            //  dal movimento padre ove questo sia dotato di tali informazioni.

            //			if (MView["nphase"].ToString().CompareTo(GetFaseInfo("flagfinance",table).ToString())<0)return; 
            //if (MChoosen["idbilancio"]==DBNull.Value)return;
            MView["idacc"] = MChoosen["idacc"];
            MView["codeacc"] = MChoosen["codeacc"];
            MView["account"] = MChoosen["account"];

            MView["idupb"] = MChoosen["idupb"];
            MView["codeupb"] = MChoosen["codeupb"];
            MView["upb"] = MChoosen["upb"];

        }


        // Rusciano G. Aggiunto 04.03.2005
        // Imposta le informazioni sul centro di spesa
        void CambiaVoceUPB(DataRow MView, DataRow MChoosen) {
            //			if (MView["nphase"].ToString().CompareTo(GetFaseInfo("flagfinance",table).ToString())<0)return; 
            MView["idupb"] = MChoosen["idupb"];
            MView["codeupb"] = MChoosen["codeupb"];
            MView["upb"] = MChoosen["upb"];
        }

        void CambiaVoceCreditore(DataRow MView, DataRow MChoosen) {            
            MView["idreg"] = MChoosen["idreg"];
            MView["registry"] = MChoosen["registry"];
        }

        void AllineaAutomatismo(DataRow MView, int row) {
            DataRow A = Automatismi.Rows[row];
            //Per ogni livello con bilancio cambia almeno una riga dal vecchio all'eventuale nuovo idbilancio
            //int codicefase= CfgFn.GetNoNullInt32(A["nphase"]);
            object originalidacc = A["idacc"];
            object originalidupb = A["idupb"];
            A["idacc"] = MView["idacc"];
            //A["codeacc"] = MView["codeacc"];
            //A["account"] = MView["account"];
            A["idupb"] = MView["idupb"];
            //A["codeupb"] = MView["codeupb"];
            //A["upb"] = MView["upb"];

            string filter = QHC.MCmp(A, "amount", "description", "idman");
            //filter += "AND(codicefase='"+i.ToString()+"')";

            //filter += QHC.NullOrEq("idfin", originalidbilancio);
            filter = QHC.AppAnd(filter, QHC.NullOrEq("idacc", originalidacc));
            //filter += QHC.NullOrEq("idupb", originalidupb);
            filter = QHC.AppAnd(filter, QHC.NullOrEq("idupb", originalidupb));
            foreach (string fieldname in
                    new string[] { "idreg" }) {
                if (A[fieldname] != DBNull.Value) {
                    filter = QHC.AppAnd(filter, QHC.NullOrEq(fieldname, A[fieldname]));
                }
            }


            //filter = QHC.AppAnd(filter, QHC.CmpEq("movkind", A["movkind"]));
            DataRow[] Found = Automatismi.Select(filter);
            if (Found.Length > 0) {
                if (Found[0]["idacc"] != DBNull.Value) {
                    Found[0]["idacc"] = MView["idacc"];
                    //Found[0]["codeacc"] = MView["codeacc"];
                    //Found[0]["account"] = MView["account"];
                }
                if (Found[0]["idupb"] != DBNull.Value) {
                    Found[0]["idupb"] = MView["idupb"];
                    //Found[0]["codeupb"] = MView["codeupb"];
                    //Found[0]["upb"] = MView["upb"];
                }
            }

        }

        void AllineaVociConto() {
            //Per ogni automatismo di tipo entrata/spesa cui sia associato un movimento padre ricalcola
            // le info di bilancio per tutti i livelli di quel movimento di spesa/entrata
            foreach (DataRow S in cicloAttivo ?DS.epaccview.Rows: DS.epexpview.Rows) {
                int i = CfgFn.GetNoNullInt32(S[idTableEp]);
                DataRow Automatismo = Automatismi.Rows[i];
                if (Automatismo["livsupid"] != DBNull.Value) {
                    //Allinea gli automatismi parent di questo
                    AllineaAutomatismo(S, i);
                }
            }
            

        }

        DataTable myAccount;
        DataTable myUPB;
        DataTable myRegistry;
        DataTable myManager;

        object  GetUpbField(object idupb, string field) {
            if (idupb==DBNull.Value) return DBNull.Value;
            DataRow []f  = myUPB.Select(QHC.CmpEq("idupb",idupb));
            if (f.Length>0) return f[0][field];
            Conn.RUN_SELECT_INTO_TABLE(myUPB,null,QHS.CmpEq("idupb",idupb),null,false);
            f  = myUPB.Select(QHC.CmpEq("idupb",idupb));
            if (f.Length>0) return f[0][field];
            return DBNull.Value;
        }

        object  GetAccountField(object idacc, string field) {
            if (idacc == DBNull.Value) return DBNull.Value;
            DataRow[] f = myAccount.Select(QHC.CmpEq("idacc", idacc));
            if (f.Length>0) return f[0][field];
            Conn.RUN_SELECT_INTO_TABLE(myAccount, null, QHS.CmpEq("idacc", idacc), null, false);
            f = myAccount.Select(QHC.CmpEq("idacc", idacc));
            if (f.Length>0) return f[0][field];
            return DBNull.Value;
        }

        object GetManagerField(object idman, string field) {
            if (idman == DBNull.Value) return DBNull.Value;
            DataRow[] f = myManager.Select(QHC.CmpEq("idman", idman));
            if (f.Length > 0) return f[0][field];
            Conn.RUN_SELECT_INTO_TABLE(myManager, null, QHS.CmpEq("idman", idman), null, false);
            f = myManager.Select(QHC.CmpEq("idman", idman));
            if (f.Length > 0) return f[0][field];
            return DBNull.Value;
        }
        object GetRegistryField(object idreg, string field) {
            if (idreg == DBNull.Value) return DBNull.Value;
            DataRow[] f = myRegistry.Select(QHC.CmpEq("idreg", idreg));
            if (f.Length > 0) return f[0][field];
            Conn.RUN_SELECT_INTO_TABLE(myRegistry, null, QHS.CmpEq("idreg", idreg), null, false);
            f = myRegistry.Select(QHC.CmpEq("idreg", idreg));
            if (f.Length > 0) return f[0][field];
            return DBNull.Value;
        }

        void RicalcolaCampiCalcolati() {
  
         foreach (DataRow RS in cicloAttivo ? DS.epaccview.Rows : DS.epexpview.Rows) {
                RS["manager"] = GetManagerField(RS["idman"], "title");
                RS["registry"] = GetRegistryField(RS["idreg"], "title");
                RS["codeacc"] = GetAccountField(RS["idacc"], "codeacc");
                RS["account"] = GetAccountField(RS["idacc"], "title");
                RS["codeupb"] = GetUpbField(RS["idupb"], "codeupb");
                RS["upb"] = GetUpbField(RS["idupb"], "title");

                int myphase = CfgFn.GetNoNullInt32(RS["nphase"]);

                string preMov = cicloAttivo ? "Preaccertamento" : "Preimpegno";
                string Mov = cicloAttivo ? "Accertamento" : "Impegno";

                object livsup = RS["par"+idTableEp];
             if (CfgFn.GetNoNullInt32(livsup) >= 99000000) livsup = DBNull.Value;
                //int nfase = CfgFn.GetNoNullInt32(RS["nphase"]);
                //int nfasesup = nfase - 1;
                if (livsup != DBNull.Value) {
                    //int nfase = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("expense", QHS.CmpEq("idexp", livsup), "nphase"));
                    DataRow Sup = (DataRow)RighePadriMovimento[livsup];
                    int nfase = CfgFn.GetNoNullInt32(Sup["nphase"]);

                    string nomefasesup = (nfase == 1) ? preMov : Mov;
                    string nomefasesup2 = (nfase == 1) ? Mov : "";
                    //string nomefasesup = DS.expensephase.Select(QHC.CmpEq("nphase", nfase))[0]["description"].ToString();
                    //string nomefasesup2 = DS.expensephase.Select(QHC.CmpEq("nphase", nfase + 1))[0]["description"].ToString();

                    RS["!livprecedente"] = nomefasesup + " " +
                        Sup["y"+tableEp] + "/" +
                        Sup["n"+tableEp];
                    string nomefasemax = Mov;
                    if (nomefasesup2 != nomefasemax)
                        RS["phase"] = nomefasesup2 + " - " + nomefasemax;
                    else
                        RS["phase"] = nomefasemax;
                    //RS["fase"]= nomefasesup+" - "+ nomefasemax;
                }
                else {
                    RS["!livprecedente"] = "";
                    if (myphase == 1) {
                        RS["phase"] = preMov;
                    }
                    else {
                        RS["phase"] = "Tutte";
                    }
                }
            }
           
            formatgrids FGSpesa = new formatgrids(gridSpesa);
            FGSpesa.AutosizeColumnWidth();
            
        }

       

        int nvaloridiversi(string column, DataRow[] ROWS) {
            string outstring = "";
            int diversi = 0;
            foreach (DataRow R in ROWS) {
                //if (R[column]==DBNull.Value) continue;
                string quoted = QueryCreator.quotedstrvalue(R[column], false);
                if (outstring.IndexOf(quoted) >= 0)
                    continue;
                if (outstring != "")
                    outstring += ",";
                outstring += quoted;
                diversi++;
            }
            return diversi;
        }

        string GetFilterForSelection(DataRow[] Selected, string table, int livello) {
            string filter = QHS.CmpEq("ayear", Disp.GetSys("esercizio"));
            
            int minfaseacc = 1;
            int minfasecred = 2;
            bool vincolaacc = chkConto.Checked;
            bool vincolaupb = chkUpb.Checked;

            if (vincolaacc && (livello >= minfaseacc)) {
                object O = Selected[0]["idacc"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idacc", O));
                }
            }

            if (vincolaupb && (livello >= minfaseacc)) {
                object P = Selected[0]["idupb"];
                if (P != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idupb", P));
                }
            }

            if (livello >= minfasecred) {
                object O = Selected[0]["idreg"];
                if (O != DBNull.Value) {
                    filter = QHS.AppAnd(filter, QHS.CmpEq("idreg", O));
                }
            }
            return filter;
        }

        int GetMaxFaseForSelection(DataRow[] Selected, string table) {
            int minfaseacc = 1;
            int minfasecred = 2;
            bool vincolaacc = chkConto.Checked;
            bool vincolaupb = chkUpb.Checked;
            int fasecurr = 99;
            if (table == "epexp" || tableEp=="epacc") {
                fasecurr = 1;
            }
            foreach (DataRow rr in Selected) {
                if (CfgFn.GetNoNullInt32(rr["nphase"]) == 1) fasecurr = 0;
            }
            if ((nvaloridiversi("idacc", Selected) > 1) && vincolaacc) {
                if (fasecurr >= minfaseacc)
                    fasecurr = minfaseacc - 1;
            }
            if ((nvaloridiversi("idupb", Selected) > 1) && vincolaupb) {
                if (fasecurr >= minfaseacc)
                    fasecurr = minfaseacc - 1;
            }

            if (nvaloridiversi("idreg", Selected) > 1) {
                if (fasecurr >= minfasecred)
                    fasecurr = minfasecred - 1;
            }
            return fasecurr;
        }


        //DataRow GetGridRow(DataGrid G, int index) {
        //    string TableName = G.DataMember.ToString();
        //    DataSet MyDS = (DataSet)G.DataSource;
        //    DataTable MyTable = MyDS.Tables[TableName];
        //    string filter="";


        //    if (MyTable.TableName == tableEp+"view")
        //        filter = QHC.CmpEq(idTableEp, G[index, 0]);

        //    DataRow[] selectresult = MyTable.Select(filter);
        //    return selectresult[0];
        //}

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }
            
            Dictionary<int,DataRow> rowsById= new Dictionary<int, DataRow>();
            foreach (DataRow r in MyTable.Rows) rowsById[(int) r[idTableEp]] = r;

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = rowsById[(int)G[i,0]];
                }
            }
            return Res;
        }


        private void btnCollegaS_Click(object sender, System.EventArgs e) {
            DataRow[] RigheSelezionate = GetGridSelectedRows(gridSpesa);
            if (RigheSelezionate == null)
                return;
            if (RigheSelezionate.Length == 0)
                return;
            string rowfilter;
            int maxfase = GetMaxFaseForSelection(RigheSelezionate, tableEp);
            if (maxfase < 1) {
                MessageBox.Show("Non è possibile collegare tutte le righe selezionate ad uno stesso movimento.\n" +
                    "Le informazioni di U.P.B., conto, percipiente sono " +
                    "troppo diverse tra loro.", "Errore");
                return;
            }
            int selectedfase = maxfase;   //MUST BE = 1

            rowfilter = GetFilterForSelection(RigheSelezionate, tableEp, selectedfase);
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpEq("nphase", selectedfase));
            decimal tot = 0;
            foreach (DataRow R in RigheSelezionate) {
                tot += CfgFn.GetNoNullDecimal(R["amount"]);
            }
            rowfilter = QHS.AppAnd(rowfilter, QHS.CmpGe("available", tot));
            MetaData S = Disp.Get(tableEp);
            S.DS = DS.Clone();
            S.FilterLocked = true;
            DataRow Choosen = S.SelectOne("default", rowfilter, "epexp", null);
            if (Choosen == null)
                return;
            RighePadriMovimento[Choosen[idTableEp]] = Choosen;
            string parent = cicloAttivo ? "preaccertamento" : "preimpegno";
            foreach (DataRow R in RigheSelezionate) {
                if (parentExists(tableEp,R["par"+ idTableEp, DataRowVersion.Original])) {
                    MessageBox.Show("La riga non può essere scollegata dal relativo "+ parent +
                        " poiché già salvata in precedenza sul database.");
                    continue;
                }
                R["par"+idTableEp] = Choosen[idTableEp];
                int I = Convert.ToInt32(R[idTableEp]);
                Automatismi.Rows[I]["livsupid"] = Choosen[idTableEp];
                CambiaVoceConto(R, Choosen);
                CambiaVoceUPB(R, Choosen);
                CambiaVoceCreditore(R, Choosen);
            }
            RicalcolaCampiCalcolati();
        }

        bool parentExists(string table, object parid) {
            if (parid == DBNull.Value) return false;
            var idfield = "id" + table;
            var found = D.Tables[table].Select(QHC.CmpEq(idfield, parid));
            if (found.Length == 0) return true;
            return found[0].RowState != DataRowState.Added;
        }

        void deleteTemporaryParent(string table, object parid) {
            if (parid == DBNull.Value) return;
            var idfield = "id" + table;
            //int minTemp = r.Table.getMinimumTempValue("idepexp");
            var found = D.Tables[table].Select(QHC.CmpEq(idfield, parid));
            if (found.Length == 0) return;
            if (found[0].RowState==DataRowState.Added) {
                found[0].Delete();
                var impMov = D.Tables[table+"year"].Select(QHC.CmpEq(idfield, parid));
                if (impMov.Length>0)impMov[0].Delete();
            }
        }

        private void btnScollegaS_Click(object sender, EventArgs e) {
            var righeSelezionate = GetGridSelectedRows(gridSpesa);
            if (righeSelezionate == null)
                return;
            if (righeSelezionate.Length == 0)
                return;
            var parent = cicloAttivo ? "preaccertamento" : "preimpegno";
            foreach (var r in righeSelezionate) {
                if (parentExists(tableEp,r["par" + idTableEp, DataRowVersion.Original])) {
                    MessageBox.Show(
                        $"La riga n.{r["n" + tableEp]} non può essere scollegata dal relativo {parent} poiché già salvata in precedenza sul database.");
                    continue;
                }
                //r.RejectChanges(); //	CambiaVoceBilancio(R,Automatismi[I]);
                var oldid = r["par" + idTableEp];
                deleteTemporaryParent(tableEp, oldid);
                r["par" + idTableEp] = DBNull.Value;
                var I = Convert.ToInt32(r[idTableEp]);
                Automatismi.Rows[I]["livsupid"] = DBNull.Value;
            }
            RicalcolaCampiCalcolati();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            AllineaVociConto();
        }

        private void gridSpesa_Paint(object sender, PaintEventArgs e) {
            object dataSource = gridSpesa.DataSource;
            if (dataSource == null)
                return;

            var cm = (CurrencyManager) gridSpesa.BindingContext[dataSource, gridSpesa.DataMember];

            var view = cm.List as DataView;

            
            var daScollegare = false;
            var daCollegare = false;
            var vietaCollega = false;
            var vietaScollega = false;
            if (view != null) {
                for (var i = 0; i < view.Count; i++) {
                    if (!gridSpesa.IsSelected(i)) continue;
                    if (CfgFn.GetNoNullInt32(view[i]["nphase"]) == 1) {
                        vietaCollega = true;
                        vietaScollega = true;
                        break;
                    }
                    if (!isAdded[CfgFn.GetNoNullInt32(view[i][idTableEp] )]) { 
                        vietaCollega = true;
                        vietaScollega = true;
                        break;
                    }
                        
                    var livPrecedente = view[i]["par"+ idTableEp];
                    if (livPrecedente != DBNull.Value) {
                        var parid = CfgFn.GetNoNullInt32(view[i]["parid"+tableEp]);
                        var found = D.Tables[tableEp].Select(QHC.CmpEq("id"+tableEp, parid));
                        vietaCollega = true;
                        if (found.Length == 0) continue;
                        if (found[0].RowState==DataRowState.Added){
                            daScollegare = true;                             
                        }
                        break;
                    }
                    vietaScollega = true;
                    daCollegare = true;
                    break;
                }
            }
            btnCollegaS.Enabled = daCollegare && ! vietaCollega;
            btnScollegaS.Enabled = daScollegare && ! vietaScollega;
        }
    }
}
