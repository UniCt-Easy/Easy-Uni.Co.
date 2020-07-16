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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;


namespace manage_var {
    public partial class FrmManage_Var : Form {
        DataTable tVar;
        
        DataSet DS;
        DataAccess Conn;
        MetaDataDispatcher Disp;
        string IoE;
        CQueryHelper QHC;
        QueryHelper QHS;
        ContextMenu ExcelMenu;

        public FrmManage_Var(DataSet DS, DataAccess Conn, MetaDataDispatcher Disp, string IoE) {
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            string tName = (IoE == "I") ? "incomevar" : "expensevar";
            this.tVar = DS.Tables[tName];
            this.DS = DS;
            this.Conn = Conn;
            this.Disp = Disp;
            this.IoE = IoE;
            InitializeComponent();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            FillTables();
            MetaData.SetColor(this);
        }


        private void FillTables() {
            if (IoE == "I") {
                impostaCaptionClass("I");
                popolaMovimento("I");
                popolaVariazione("I");
                impostaCaption("I");
                CalcolaClassificazioniAutomatiche("I");
                HelpForm.SetDataGrid(dgVarEntrata, dsMov.Tables["incomevarview"]);
                dgVarEntrata.ContextMenu = ExcelMenu;
                if (dsMov.Tables["incomeview"].Rows.Count > 0) {
                    aggiornaClassificazioni("I", ottieniRiga(dgVarEntrata), dgClassEntrata);
                }
            }
            else {
                impostaCaptionClass("E");
                popolaMovimento("E");
                popolaVariazione("E");
                impostaCaption("E");
                CalcolaClassificazioniAutomatiche("E");
                HelpForm.SetDataGrid(dgVarSpesa, dsMov.Tables["expensevarview"]);
                dgVarSpesa.ContextMenu = ExcelMenu;
                if (dsMov.Tables["expenseview"].Rows.Count > 0) {
                    aggiornaClassificazioni("E", ottieniRiga(dgVarSpesa), dgClassSpesa);
                }
            }
            showingTab(tabControl1.TabPages["tabVarEntrata"], dsMov.Tables["incomevarview"]);
            showingTab(tabControl1.TabPages["tabVarSpesa"], dsMov.Tables["expensevarview"]);
        }

        private void impostaCaptionClass(string IoE) {
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["!sorting"].Caption = "Cod. Class.";
            dsMov.Tables[tName].Columns["!sortcode"].Caption = "Classificazione";
            dsMov.Tables[tName].Columns["idsubclass"].Caption = "Sub Movim.";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";


        }

        private void showingTab(TabPage tp, DataTable t) {
            if ((t == null) || (t.Rows.Count == 0)) {
                tabControl1.TabPages.Remove(tp);
            }
        }

        private void impostaCaption(string IoE) {
            string tName = (IoE == "I") ? "incomevarview" : "expensevarview";
            if (dsMov.Tables[tName] == null) return;
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["ymov"].Caption = "Eserc. Mov.";
            dsMov.Tables[tName].Columns["nmov"].Caption = "Num. Mov.";
            dsMov.Tables[tName].Columns["description"].Caption = "Descrizione";
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";

            if (IoE == "E") {
                dsMov.Tables[tName].Columns["!codeunderwriting"].Caption = "Cod. Finanziamento";
                dsMov.Tables[tName].Columns["!underwriting"].Caption = "Finanziamento";
            }


        }

        private void aggiornaClassificazioni(string IoE, DataRow rMov, DataGrid dgClass) {
            string tNameSource = (IoE == "I") ? "incomesorted" : "expensesorted";
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";
            string idfield = (IoE == "I") ? "idinc" : "idexp";

            string filter = QHC.CmpEq(idfield, rMov[idfield]);
            DataRow[] Classificazioni = DS.Tables[tNameSource].Select(filter);

            dsMov.Tables[tName].Clear();
            foreach (DataRow rClass in Classificazioni) {
                DataRow rClassDest = dsMov.Tables[tName].NewRow();
                foreach (DataColumn C in DS.Tables[tNameSource].Columns) {
                    if (!dsMov.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rClassDest[C.ColumnName] = rClass[C];
                }

                string f_sorting = QHS.CmpEq("idsor", rClass["idsor"]);
                object descr_sor = Conn.DO_READ_VALUE("sorting", f_sorting, "sortcode");
                rClassDest["!sortcode"] = descr_sor;

                object idsorkind = Conn.DO_READ_VALUE("sorting", f_sorting, "idsorkind");
                string f_sortingkind = QHS.CmpEq("idsorkind", idsorkind);
                object descr_sorkind = Conn.DO_READ_VALUE("sortingkind", f_sortingkind, "description");
                rClassDest["!sorting"] = descr_sorkind;

                dsMov.Tables[tName].Rows.Add(rClassDest);
                rClassDest.AcceptChanges();
            }

            HelpForm.SetDataGrid(dgClass, dsMov.Tables[tName]);
        }

        private DataRow ottieniRiga(DataGrid dg) {
            DataSet DSV = (DataSet)dg.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[dg.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView)dg.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null) return null;
            DataRow R = DV.Row;
            return R;
        }

        private void popolaVariazione(string IoE) {
            string tName = (IoE == "I") ? "incomevar" : "expensevar";
            if (DS.Tables[tName] == null) return;

            string vName = tName + "view";
            string tPhaseName = tName + "phase";
            string tMovNoview = (IoE == "I") ? "income" : "expense";
            string tMov = (IoE == "I") ? "incomeview" : "expenseview";
            string idfield = (IoE == "I") ? "idinc" : "idexp";
            
            foreach (DataRow rVar in DS.Tables[tName].Select()) {
                DataRow rVarLocal = dsMov.Tables[vName].NewRow();

                string[] listaCampi = new string[] {idfield, "nvar", "yvar",
					"amount", "adate", "description"};

                foreach (string campo in listaCampi) {
                    rVarLocal[campo] = rVar[campo];
                }
                object nPhase = null;
                object nMov = null;

                DataRow[] MOV = dsMov.Tables[tMov].Select(QHC.CmpEq(idfield, rVar[idfield]));
                if (MOV.Length > 0) {
                    nPhase = MOV[0]["nphase"];
                    nMov = MOV[0]["nmov"];
                }
                else {
                    string fSQL = QHS.CmpEq(idfield, rVar[idfield]);
                    nPhase = Conn.DO_READ_VALUE(tMovNoview, fSQL, "nphase");
                    if (nPhase == null) {
                        MetaData.mainLogError(null,Conn,"Movimento della tabella "+tMovNoview+" di ID "+rVar[idfield]+" non trovato ",null);
                        MessageBox.Show(
                            "Movimento della tabella " + tMovNoview + " di ID " + rVar[idfield] + " non trovato ",
                            "Errore");
                        nPhase = 0;
                    }
                    nMov = 1;
                }

                string phase = ottieniNomeFase(IoE, nPhase);


                if (IoE == "E") {
                    string f_underwriting = QHS.CmpEq("idunderwriting", rVar["idunderwriting"]);
                    object code_underwriting = Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                    rVarLocal["!codeunderwriting"] = code_underwriting;

                    object title_underwriting = Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                    rVarLocal["!underwriting"] = title_underwriting;
                }



                rVarLocal["ymov"] = Conn.GetSys("esercizio");
                rVarLocal["nmov"] = nMov;
                rVarLocal["nphase"] = nPhase;
                rVarLocal["phase"] = phase;
                rVarLocal["ct"] = DateTime.Now;
                rVarLocal["cu"] = "-";
                rVarLocal["lt"] = DateTime.Now;
                rVarLocal["lu"] = "-";

                dsMov.Tables[vName].Rows.Add(rVarLocal);
                rVarLocal.AcceptChanges();
            }

        }

        private void popolaMovimento(string IoE) {
            string tName = (IoE == "I") ? "income" : "expense";
            string tVar = (IoE == "I") ? "incomevar" : "expensevar";
            string vName = tName + "view";
            string idfield = (IoE == "I") ? "idinc" : "idexp";

            string filter = QHS.AppAnd(QHS.FieldIn(idfield, DS.Tables[tVar].Select()),
                QHS.CmpEq("ayear", Conn.GetSys("esercizio")));

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, dsMov.Tables[vName], null,
                filter, null, true);

            
            foreach (DataRow rMov in dsMov.Tables[vName].Rows) {
                string fVar = QHC.CmpEq(idfield, rMov[idfield]);

                decimal sumVariation = CfgFn.GetNoNullDecimal(DS.Tables[tVar].Compute("SUM(amount)", fVar));
                DateTime VarMaxDate = (DateTime)DS.Tables[tVar].Select(fVar, "adate desc")[0]["adate"];
                decimal oldamount = CfgFn.GetNoNullDecimal(rMov["curramount"]);
                decimal currAmount = oldamount + sumVariation;
                rMov["curramount"] = currAmount;

                setCurrAmountForIdMov(CfgFn.GetNoNullInt32(rMov[idfield]), currAmount);
                setOldAmountForIdMov(CfgFn.GetNoNullInt32(rMov[idfield]), oldamount);
                setVarDateForIdMov(CfgFn.GetNoNullInt32(rMov[idfield]), VarMaxDate);


            }
        }

        Dictionary<int, decimal> oldamount = new Dictionary<int, decimal>();
        decimal GetOldAmountForIdMov(int idmov) {
            if (oldamount.ContainsKey(idmov)) return oldamount[idmov];
            throw new Exception("Errore in FrmManageVar");

        }
        void setOldAmountForIdMov(int idmov, decimal d) {
            oldamount[idmov] = d;
        }

        Dictionary<int, DateTime> varDate = new Dictionary<int, DateTime>();
        DateTime GetVarDateForIdMov(int idmov) {
            if (varDate.ContainsKey(idmov)) return varDate[idmov];
            throw new Exception("Errore in FrmManageVar");

        }
        void setVarDateForIdMov(int idmov, DateTime d) {
            varDate[idmov] = d;
        }


        Dictionary<int, decimal> curramount = new Dictionary<int, decimal>();
        decimal GetCurrAmountForIdMov(int idmov) {
            string tName = (IoE == "I") ? "incometotal" : "expensetotal";
            string field = (IoE == "I") ? "idinc" : "idexp";
            if (curramount.ContainsKey(idmov)) return curramount[idmov];
            decimal d = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE(tName, QHS.AppAnd(QHS.CmpEq(field, idmov), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))),
                "curramount"));
            curramount[idmov] = d;
            return d;
        }
        void setCurrAmountForIdMov(int idmov, decimal d) {
            curramount[idmov] = d;
        }


        void CalcolaClassificazioniAutomatiche(string IoE) {

            DataTable tSor = IoE == "I" ? DS.Tables["incomesorted"] : DS.Tables["expensesorted"];
            string field = (IoE == "I") ? "idinc" : "idexp";
            foreach (DataRow rSor in tSor.Select()) {
                int idmov = CfgFn.GetNoNullInt32(rSor[field]);
                decimal old_class = CfgFn.GetNoNullDecimal(rSor["amount"]);
                decimal old_mov = GetOldAmountForIdMov(idmov);
                if (old_class != old_mov) continue;
                decimal new_mov = GetCurrAmountForIdMov(idmov);
                decimal amount = new_mov - old_mov;

                MetaData M = Disp.Get(tSor.TableName);
                M.SetDefaults(tSor);
                MetaData.SetDefault(tSor, field, idmov);
                MetaData.SetDefault(tSor, "idsor", rSor["idsor"]);
                DataRow R = M.Get_New_Row(null, tSor);
                R["description"] = "classificazione per variazione dettaglio ordine";
                R["start"] = GetVarDateForIdMov(idmov);
                R["amount"] = new_mov - old_mov;
            }

            //Cancellazione vecchie classificazioni di annullamento (Ë una finezza)
            foreach (DataRow rSor in tSor.Select()) {
                if (rSor.RowState != DataRowState.Unchanged) continue;
                int idmov = CfgFn.GetNoNullInt32(rSor[field]);
                decimal old_class = CfgFn.GetNoNullDecimal(rSor["amount"]);
                decimal old_mov = GetOldAmountForIdMov(idmov);
                decimal new_mov = GetCurrAmountForIdMov(idmov);
                if (old_mov != 0) continue; //Se il vecchio movimento Ë zero,
                if (old_class != -new_mov) continue; //e la vecchia classificazione Ë pari a  - (movimento),

                rSor.Delete(); //LA  CANCELLA!

            }
        }

        private string ottieniNomeFase(string IoE, object nphase) {
            string tName = (IoE == "I") ? "incomephase" : "expensephase";
            object descrPhase = Conn.DO_READ_VALUE(tName, QHS.CmpEq("nphase", nphase), "description");
            string phase = (descrPhase == null) ? "" : descrPhase.ToString();
            return phase;
        }

        private void Excel_Click(object menusender, EventArgs e) {
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

        private void btnInsertClassI_Click(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVarEntrata);
            if (ParentVar == null) return;
            DataRow[] ParentMov = dsMov.Tables["incomeview"].Select(QHC.CmpEq("idinc", ParentVar["idinc"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            decimal amount = CfgFn.GetNoNullDecimal(ParentVar["amount"]);
            DataRow rClass = InsertDataRow("I", "all", dsMov.Tables["incomesorted"], Parent,
                0, dgClassEntrata);
            allineaClassificazioniInDS("I", rClass);
            aggiornaClassificazioni("I", Parent, dgClassEntrata);
        }

        private void btnUpdateClassI_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClassEntrata);
            DataRow rMov = ottieniRiga(dgVarEntrata);
            if ((row == null) || (rMov == null)) return;

            string f = QHC.CmpEq("idinc", rMov["idinc"]);
            DataRow []Mov = dsMov.Tables["incomeview"].Select(f);

            DataRow newRow;
            bool res = EditDataRow("I", row, "all", out newRow);
            if (res) {
                allineaClassificazioniInDS("I", newRow);
                aggiornaClassificazioni("I", rMov, dgClassEntrata);
            }
        }

        private void btnDeleteClassI_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClassEntrata);
            if (row == null) return;
            row.Delete();
            allineaClassificazioniInDS("I", row);
            HelpForm.SetDataGrid(dgClassEntrata, dsMov.Tables["incomesorted"]);
        }

        private void btnInsertClassE_Click(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVarSpesa);
            if (ParentVar == null) return;
            DataRow [] ParentMov = dsMov.Tables["expenseview"].Select(QHC.CmpEq("idexp", ParentVar["idexp"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            decimal amount = CfgFn.GetNoNullDecimal(ParentVar["amount"]);
            DataRow rClass = InsertDataRow("E", "all", dsMov.Tables["expensesorted"], Parent,
                amount, dgClassSpesa);
            allineaClassificazioniInDS("E", rClass);
            aggiornaClassificazioni("E", Parent, dgClassSpesa);
        }

        private void btnUpdateClassE_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClassSpesa);
            DataRow rMov = ottieniRiga(dgVarSpesa);
            if ((row == null) || (rMov == null)) return;

            string f = QHC.CmpEq("idexp", rMov["idexp"]);
            DataRow[] Mov = dsMov.Tables["expenseview"].Select(f);

            DataRow newRow;
            bool res = EditDataRow("E", row, "all", out newRow);
            if (res) {
                allineaClassificazioniInDS("E", newRow);
                aggiornaClassificazioni("E", rMov, dgClassSpesa);
            }
        }

        private void btnDeleteClassE_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClassSpesa);
            if (row == null) return;
            row.Delete();
            allineaClassificazioniInDS("E", row);
            HelpForm.SetDataGrid(dgClassSpesa, dsMov.Tables["expensesorted"]);
        }

        private void allineaClassificazioniInDS(string IoE, DataRow rClass) {
            if (rClass == null) return;
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";

            DataRowVersion toConsider = DataRowVersion.Default;
            switch (rClass.RowState) {
                case DataRowState.Added: {
                        toConsider = DataRowVersion.Current;
                        break;
                    }
                case DataRowState.Modified: {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
                case DataRowState.Deleted: {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
            }

            string filter = QueryCreator.WHERE_KEY_CLAUSE(rClass, toConsider, false);

            DataRow[] Classificazioni = DS.Tables[tName].Select(filter);
            if (Classificazioni.Length == 0) {
                DataRow rClassDS = DS.Tables[tName].NewRow();
                foreach (DataColumn C in rClass.Table.Columns) {
                    if (!DS.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                    rClassDS[C.ColumnName] = rClass[C];
                }
                DS.Tables[tName].Rows.Add(rClassDS);
            }
            else {
                if (rClass.RowState == DataRowState.Deleted) {
                    Classificazioni[0].Delete();
                }
                else {
                    foreach (DataColumn C in rClass.Table.Columns) {
                        if (!DS.Tables[tName].Columns.Contains(C.ColumnName)) continue;
                        Classificazioni[0][C.ColumnName] = rClass[C];
                    }
                }
            }
            rClass.AcceptChanges();
        }

        private void allineaDescrizioneInDS(string IoE, DataRow rMov) {
            if (rMov == null) return;
            string tName = (IoE == "I") ? "incomevar" : "expensevar";
            
            DataRowVersion toConsider = DataRowVersion.Default;
            switch (rMov.RowState) {
                case DataRowState.Added: {
                        toConsider = DataRowVersion.Current;
                        break;
                    }
                case DataRowState.Modified: {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
                case DataRowState.Deleted: {
                        toConsider = DataRowVersion.Original;
                        break;
                    }
            }

            string filter = QueryCreator.WHERE_KEY_CLAUSE(rMov, toConsider, false);
            DataRow[] MOV = DS.Tables[tName].Select(filter);
            if (MOV.Length == 0) return;
            MOV[0]["description"] = rMov["description"];
            if (IoE == "E") {
                MOV[0]["idunderwriting"] = rMov["idunderwriting"];

                string f_underwriting = QHS.CmpEq("idunderwriting", MOV[0]["idunderwriting"]);
                object code_underwriting = Conn.DO_READ_VALUE("underwriting", f_underwriting, "codeunderwriting");
                rMov["!codeunderwriting"] = code_underwriting;

                object title_underwriting = Conn.DO_READ_VALUE("underwriting", f_underwriting, "title");
                rMov["!underwriting"] = title_underwriting;

            }
            rMov.AcceptChanges();
        }

        /// <summary>
        /// Edits a datarow using a specified listig type. Also Extra parameter
        ///  of R.Table is considered.
        /// </summary>
        /// <param name="R"></param>
        /// <param name="edit_type"></param>
        /// <returns>true if row has been modified</returns>
        public bool EditDataRow(string IoE, DataRow R, string edit_type, out DataRow newRow) {
            newRow = R;
            string tName = (IoE == "I") ? "incomesorted" : "expensesorted";
            DataTable SourceTable = R.Table;
            MetaData M = Disp.Get(DS.Tables[tName].TableName);
            if (M == null) return false;
            M.SetDefaults(SourceTable);
            M.SetSource(R);

            M.Edit(this, edit_type, true);
            if (M.entityChanged) {
                newRow = M.NewSourceRow;
            }
            return M.entityChanged;
        }

        public DataRow InsertDataRow(string IoE, string edit_type, DataTable SourceTable, DataRow Parent,
            decimal amount, DataGrid dg) {
            MetaData M = Disp.Get(SourceTable.TableName);

            M.SetDefaults(SourceTable);
            MetaData.SetDefault(SourceTable, "amount", amount);
            DataRow R = M.Get_New_Row(Parent, SourceTable);
            if (R == null) {
                MessageBox.Show(this, "La tabella " + SourceTable.TableName +
                    " contiene dati non validi. Contattare il servizio di assistenza.");
                return null;
            }

            M.SetSource(R);

            M.Edit(this, edit_type, true);

            if (!M.entityChanged) {
                R.Delete();
                R = null;
            }
            else {
                R = M.NewSourceRow;
            }

            return R;
        }

        private void dgVarEntrata_CurrentCellChanged(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVarEntrata);
            if (ParentVar == null) return;
            DataRow[] ParentMov = dsMov.Tables["incomeview"].Select(QHC.CmpEq("idinc", ParentVar["idinc"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            aggiornaClassificazioni("I", Parent, dgClassEntrata);
        }

        private void dgVarSpesa_CurrentCellChanged(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVarSpesa);
            if (ParentVar == null) return;
            DataRow[] ParentMov = dsMov.Tables["expenseview"].Select(QHC.CmpEq("idexp", ParentVar["idexp"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            aggiornaClassificazioni("E", Parent, dgClassSpesa);
        }

        private DataRow cambiaDescrizione(DataGrid dg, bool askFinanziamento) {
            DataRow row = ottieniRiga(dg);
            if (row == null) return null;
            if (row.Table.ToString() == "expensevarview")
                if (row["nphase"].ToString() != Conn.GetSys("appropriationphase").ToString())
                    askFinanziamento = false;
            AskDescription fAsk = new AskDescription(row, 0, askFinanziamento, Disp, Conn);
            DialogResult dr = fAsk.ShowDialog();
            if (dr != DialogResult.OK) return null;
            string descrMov = fAsk.txtDescrizione.Text;
            string oldDescription = row["description"].ToString();
            object idunderwriting = DBNull.Value;
            object oldIdunderwriting = DBNull.Value;
            if (askFinanziamento)
            {
                idunderwriting = fAsk.UnderWritingSelected;
                if (idunderwriting == null) idunderwriting = DBNull.Value;
                oldIdunderwriting = row["idunderwriting"];
            }

            if (oldDescription == descrMov && oldIdunderwriting.ToString() == idunderwriting.ToString()) return null;
            row["description"] = descrMov;
            if (askFinanziamento) row["idunderwriting"] = idunderwriting;
            return row;

        }

        private void dgVarEntrata_DoubleClick(object sender, EventArgs e) {
            DataRow row = cambiaDescrizione(dgVarEntrata,false);
            allineaDescrizioneInDS("I", row);
        }

        private void dgVarSpesa_DoubleClick(object sender, EventArgs e) {
            DataRow row = cambiaDescrizione(dgVarSpesa,true);
            allineaDescrizioneInDS("E", row);
        }
    }
}