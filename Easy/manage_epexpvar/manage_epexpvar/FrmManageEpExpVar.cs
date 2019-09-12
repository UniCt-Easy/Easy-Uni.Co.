/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace manage_epexpvar {
    public partial class FrmManageEpExpVar : Form {
        DataTable tVar;

        DataSet DS;
        DataAccess Conn;
        MetaDataDispatcher Disp;
        CQueryHelper QHC;
        QueryHelper QHS;
        ContextMenu ExcelMenu;



        public FrmManageEpExpVar(DataSet DS, DataAccess Conn, MetaDataDispatcher Disp) {
            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            string tName = "epexpvar";
            this.tVar = DS.Tables[tName];
            this.DS = DS;
            this.Conn = Conn;
            this.Disp = Disp;
            InitializeComponent();
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            FillTables();
            MetaData.SetColor(this);
        }

        private void FillTables() {
                impostaCaptionClass();
                popolaMovimento();
                popolaVariazione();
                CalcolaClassificazioniAutomatiche();
                impostaCaption();
                HelpForm.SetDataGrid(dgVar, dsMov.Tables["epexpvarview"]);
                dgVar.ContextMenu = ExcelMenu;
                if (dsMov.Tables["epexpview"].Rows.Count > 0) {
                    aggiornaClassificazioni(ottieniRiga(dgVar), dgClass);
                }
        }

        private void impostaCaptionClass() {
            string tName =  "epexpsorting" ;
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["!sorting"].Caption = "Cod. Class.";
            dsMov.Tables[tName].Columns["!sortcode"].Caption = "Classificazione";            
            dsMov.Tables[tName].Columns["amount"].Caption = "Importo";
        }


        private void impostaCaption() {
            string tName = "epexpvarview";
            if (dsMov.Tables[tName] == null) return;
            foreach (DataColumn C in dsMov.Tables[tName].Columns) {
                dsMov.Tables[tName].Columns[C.ColumnName].Caption = "";
            }

            dsMov.Tables[tName].Columns["phase"].Caption = "Fase"; 
            dsMov.Tables[tName].Columns["yepexp"].Caption = "Eserc. ";
            dsMov.Tables[tName].Columns["nepexp"].Caption = "Num. ";            
            dsMov.Tables[tName].Columns["description"].Caption = "Descrizione";
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            dsMov.Tables[tName].Columns["amount"].Caption = (++esercizio).ToString();
            dsMov.Tables[tName].Columns["amount2"].Caption = (++esercizio).ToString();
            dsMov.Tables[tName].Columns["amount3"].Caption = (++esercizio).ToString();
            dsMov.Tables[tName].Columns["amount4"].Caption = (++esercizio).ToString();
            dsMov.Tables[tName].Columns["amount5"].Caption = (++esercizio).ToString();




        }
        private void popolaMovimento() {
            //string tName = "epexp";
            string tVar = "epexpvar";
            string vName = "epexpview";
            string idfield = "idepexp";

            string filter = QHS.AppAnd(QHS.FieldIn(idfield, DS.Tables[tVar].Select()),
                QHS.CmpEq("ayear", Conn.GetSys("esercizio")));

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, dsMov.Tables[vName], null,
                filter, null, true);

            foreach (DataRow rMov in dsMov.Tables[vName].Rows) {
                string fVar = QHC.CmpEq(idfield, rMov[idfield]);
                foreach (string field in new string[] {"amount","amount2","amount3","amount4","amount5" }) {
                    decimal sumVariation = CfgFn.GetNoNullDecimal(DS.Tables[tVar].Compute("SUM("+field+")", fVar));
                    DateTime VarMaxDate = (DateTime)DS.Tables[tVar].Select(fVar, "adate desc")[0]["adate"];
                    decimal oldamount= CfgFn.GetNoNullDecimal(rMov["curr" + field]);
                    decimal currAmount = oldamount+ sumVariation;
                    rMov["curr" + field] = currAmount;
                    if (field == "amount") {
                        setCurrAmountForIdEpExp(CfgFn.GetNoNullInt32(rMov[idfield]), currAmount);
                        setOldAmountForIdEpExp(CfgFn.GetNoNullInt32(rMov[idfield]), oldamount);
                        setVarDateForIdEpExp(CfgFn.GetNoNullInt32(rMov[idfield]), VarMaxDate);
                    }
                }                
            }
        }
        Dictionary<int, decimal> oldamount = new Dictionary<int, decimal>();
        decimal GetOldAmountForIdEpExp(int idepexp) {
            if (oldamount.ContainsKey(idepexp)) return oldamount[idepexp];
            throw new Exception("Errore in FrmManageEpExpVar");
            
        }
        void setOldAmountForIdEpExp(int idepexp, decimal d) {
            oldamount[idepexp] = d;
        }

        Dictionary<int, DateTime> varDate = new Dictionary<int, DateTime>();
        DateTime GetVarDateForIdEpExp(int idepexp) {
            if (varDate.ContainsKey(idepexp)) return varDate[idepexp];
            throw new Exception("Errore in FrmManageEpExpVar");

        }
        void setVarDateForIdEpExp(int idepexp, DateTime d) {
            varDate[idepexp] = d;
        }


        Dictionary<int, decimal> curramount = new Dictionary<int, decimal>();
        decimal GetCurrAmountForIdEpExp(int idepexp) {
            if (curramount.ContainsKey(idepexp)) return curramount[idepexp];
            decimal d = CfgFn.GetNoNullDecimal( Conn.DO_READ_VALUE("epexptotal", QHS.AppAnd(QHS.CmpEq("idepexp", idepexp), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))),
                "curramount"));
            curramount[idepexp] = d;
            return d;
        }
        void setCurrAmountForIdEpExp(int idepexp, decimal d) {
            curramount[idepexp] = d;
        }

        void CalcolaClassificazioniAutomatiche() {
            DataTable tSor = DS.Tables["epexpsorting"];
            foreach (DataRow rSor in tSor.Select()) {
                int idepexp = CfgFn.GetNoNullInt32(rSor["idepexp"]);
                decimal old_class = CfgFn.GetNoNullDecimal(rSor["amount"]);
                decimal old_mov = GetOldAmountForIdEpExp(idepexp);
                if (old_class != old_mov) continue;
                decimal new_mov = GetCurrAmountForIdEpExp(idepexp);
                decimal amount = new_mov - old_mov;

                MetaData M = Disp.Get("epexpsorting");
                M.SetDefaults(tSor);
                MetaData.SetDefault(tSor, "idepexp", idepexp);
                MetaData.SetDefault(tSor, "idsor", rSor["idsor"]);
                DataRow R = M.Get_New_Row(null, tSor);
                R["description"] = "classificazione per variazione dettaglio ordine";
                R["kind"] = "V";
                R["adate"] = GetVarDateForIdEpExp(idepexp);
                R["amount"] = new_mov - old_mov;
            }

            //Cancellazione vecchie classificazioni di annullamento (è una finezza)
            foreach (DataRow rSor in tSor.Select()) {
                if (rSor.RowState != DataRowState.Unchanged) continue;
                int idepexp = CfgFn.GetNoNullInt32(rSor["idepexp"]);
                decimal old_class = CfgFn.GetNoNullDecimal(rSor["amount"]);
                decimal old_mov = GetOldAmountForIdEpExp(idepexp);
                decimal new_mov = GetCurrAmountForIdEpExp(idepexp);
                if (old_mov != 0 ) continue; //Se il vecchio movimento è zero,
                if (old_class != -new_mov) continue; //e la vecchia classificazione è pari a  - (movimento),

                rSor.Delete(); //LA  CANCELLA!

            }
        }


        private string ottieniNomeFase(object nphase) {
            
            int n = CfgFn.GetNoNullInt32(nphase);
            if (n == 1)
                return "Preimpegno";
            else
                return "Impegno";
            
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


        private void btnInsertClass_Click(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVar);
            if (ParentVar == null) return;
            DataRow[] ParentMov = dsMov.Tables["epexpview"].Select(QHC.CmpEq("idepexp", ParentVar["idepexp"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            decimal amount = CfgFn.GetNoNullDecimal(ParentVar["amount"]);

            dsMov.epexpsorting.ExtendedProperties["importototale"] = GetCurrAmountForIdEpExp(CfgFn.GetNoNullInt32(ParentVar["idepexp"]));
            DataRow rClass = InsertDataRow("default", dsMov.Tables["epexpsorting"], Parent,
                0, dgClass);
            allineaClassificazioniInDS( rClass);
            aggiornaClassificazioni(Parent, dgClass);
        }

        public DataRow InsertDataRow(string edit_type, DataTable SourceTable, DataRow Parent,
           decimal amount, DataGrid dg) {
            MetaData M = Disp.Get(SourceTable.TableName);

            M.SetDefaults(SourceTable);
            MetaData.SetDefault(SourceTable, "amount", amount);
            MetaData.SetDefault(dsMov.Tables["epexpsorting"], "kind", "V");
            DataRow R = M.Get_New_Row(Parent, SourceTable);
            if (R == null) {
                MessageBox.Show(this, "La tabella " + SourceTable.TableName +
                    " contiene dati non validi. Contattare il servizio di assistenza.");
                return null;
            }

            M.SetSource(R);

            M.Edit(this, edit_type, true);

            if (!M.EntityChanged) {
                R.Delete();
                R = null;
            }
            else {
                R = M.NewSourceRow;
            }

            return R;
        }
        private void btnUpdateClass_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClass);
            DataRow rMov = ottieniRiga(dgVar);
            if ((row == null) || (rMov == null)) return;

            string f = QHC.CmpEq("idepexp", rMov["idepexp"]);
            dsMov.epexpsorting.ExtendedProperties["importototale"] = GetCurrAmountForIdEpExp(CfgFn.GetNoNullInt32(rMov["idepexp"]));

            DataRow[] Mov = dsMov.Tables["epexpview"].Select(f);

            DataRow newRow;
            bool res = EditDataRow(row, "default", out newRow);
            if (res) {
                allineaClassificazioniInDS( newRow);
                aggiornaClassificazioni(rMov, dgClass);
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e) {
            DataRow row = ottieniRiga(dgClass);
            if (row == null) return;
            row.Delete();
            allineaClassificazioniInDS( row);
            HelpForm.SetDataGrid(dgClass, dsMov.Tables["epexpsorting"]);
        }


        private void allineaClassificazioniInDS(DataRow rClass) {
            if (rClass == null) return;
            string tName = "epexpsorting";

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


        private void allineaDescrizioneInDS(DataRow rMov) {
            if (rMov == null) return;
            string tName = "epexpvar";

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
            rMov.AcceptChanges();
        }

        /// <summary>
        /// Edits a datarow using a specified listig type. Also Extra parameter
        ///  of R.Table is considered.
        /// </summary>
        /// <param name="R"></param>
        /// <param name="edit_type"></param>
        /// <returns>true if row has been modified</returns>
        public bool EditDataRow(DataRow R, string edit_type, out DataRow newRow) {
            newRow = R;
            string tName = "epexpsorting";
            DataTable SourceTable = R.Table;
            MetaData M = Disp.Get(DS.Tables[tName].TableName);
            if (M == null) return false;
            M.SetDefaults(SourceTable);
            M.SetSource(R);

            M.Edit(this, edit_type, true);
            if (M.EntityChanged) {
                newRow = M.NewSourceRow;
            }
            return M.EntityChanged;
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

            if (!M.EntityChanged) {
                R.Delete();
                R = null;
            }
            else {
                R = M.NewSourceRow;
            }

            return R;
        }

        private void dgVar_CurrentCellChanged(object sender, EventArgs e) {
            DataRow ParentVar = ottieniRiga(dgVar);
            if (ParentVar == null) return;
            DataRow[] ParentMov = dsMov.Tables["epexpview"].Select(QHC.CmpEq("idepexp", ParentVar["idepexp"]));
            if (ParentMov.Length == 0) return;
            DataRow Parent = ParentMov[0];
            aggiornaClassificazioni( Parent, dgClass);
        }

        private DataRow cambiaDescrizione(DataGrid dg, bool askFinanziamento) {
            DataRow row = ottieniRiga(dg);
            if (row == null) return null;           
                
            FrmAskDescription fAsk = new FrmAskDescription(row);
            DialogResult dr = fAsk.ShowDialog();
            if (dr != DialogResult.OK) return null;
            string descrMov = fAsk.txtDescrizione.Text;
            string oldDescription = row["description"].ToString();

            if (oldDescription == descrMov ) return null;
            row["description"] = descrMov;
            
            return row;

        }

        private void dgVar_DoubleClick(object sender, EventArgs e) {
            DataRow row = cambiaDescrizione(dgVar, false);
            allineaDescrizioneInDS(row);
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


        private void popolaVariazione() {
            string tName = "epexpvar";
            if (DS.Tables[tName] == null) return;

            string vName = tName + "view";
            string tMov = "epexpview";
            string idfield = "idepexp";

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
                    nMov = MOV[0]["nepexp"];
                }
                else {
                    string fSQL = QHS.CmpEq(idfield, rVar[idfield]);
                    nPhase = Conn.DO_READ_VALUE(tMov, fSQL, "nphase");
                    nMov = 1;
                }

                string phase = ottieniNomeFase( nPhase);


              



                rVarLocal["yepexp"] = Conn.GetSys("esercizio");
                rVarLocal["nepexp"] = nMov;
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

        private void aggiornaClassificazioni( DataRow rMov, DataGrid dgClass) {
            string tNameSource = "epexpsorting";
            string tName = "epexpsorting";
            string idfield = "idepexp";

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
    }
}
