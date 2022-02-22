
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
using funzioni_configurazione;

namespace no_table_entry_integrazione {
    public partial class FrmEntryPreSave : MetaDataForm {
        DataTable tEntry;
        DataAccess Conn;
        DataTable tAccount;
        DataTable tAnagrafica;
        DataTable tUpb;
        DataTable tSorting;
        DataTable tAccMotive;
        DataTable tExpenseSetup;
        CQueryHelper QHC;
        QueryHelper QHS;
        ContextMenu ExcelMenu;

        public FrmEntryPreSave(DataTable tEntry, DataAccess Conn, DataTable toPreScan) {
            InitializeComponent();
            this.tEntry = tEntry;
            this.Conn = Conn;
            QHS = this.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            tAccount = DataAccess.CreateTableByName(Conn, "account", "idacc, codeacc, title");
            tAnagrafica = DataAccess.CreateTableByName(Conn, "registry", "idreg, title");
            tUpb = DataAccess.CreateTableByName(Conn, "upb", "idupb, codeupb");
            tSorting = DataAccess.CreateTableByName(Conn, "sorting", "idsorkind, idsor,sortcode");
            tAccMotive = DataAccess.CreateTableByName(Conn, "accmotive", "idaccmotive, codemotive, title");
            tExpenseSetup = DataAccess.CreateTableByName(Conn, "config", "ayear, idsortingkind1, idsortingkind2, idsortingkind3");
            string f = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tExpenseSetup, null, f, null, true);

            preScanAll(toPreScan);

            fillTempField();
            assegnaCaption();
            HelpForm.SetDataGrid(dgDettaglio, tEntry);

            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
            dgDettaglio.ContextMenu = ExcelMenu;

        }
        void preScanAll(DataTable t) {
            preScanSorting(t, "sortcode");
            preScanRegistry(t, "registry");
            preScanUPB(t, "codeupb");
            preScanAccount(t, "account");
            preScanCausale(t, "accmotive");
        }

        Dictionary<string, string> CodeSorting = new Dictionary<string, string>();
        void preScanSorting(DataTable t, string fieldSortCode) {
            if (!t.Columns.Contains(fieldSortCode)) return;
            if (!t.Columns.Contains("idsor")) return;
            foreach (DataRow r in t.Rows) {
                if (r["idsor"] != DBNull.Value) {
                    CodeSorting[r["idsor"].ToString()] = r[fieldSortCode].ToString();
                }
            }
        }

        Dictionary<string, string> TitleRegistry = new Dictionary<string, string>();
        void preScanRegistry(DataTable t, string fieldTitle) {
            if (!t.Columns.Contains(fieldTitle)) return;
            if (!t.Columns.Contains("idreg")) return;
            foreach (DataRow r in t.Rows) {
                if (r["idreg"] != DBNull.Value) {
                    TitleRegistry[r["idreg"].ToString()] = r[fieldTitle].ToString();
                }
            }
        }

        Dictionary<string, string> TitleUpb = new Dictionary<string, string>();
        void preScanUPB(DataTable t, string codiceUpb) {
            if (!t.Columns.Contains(codiceUpb)) return;
            if (!t.Columns.Contains("idupb")) return;
            foreach (DataRow r in t.Rows) {
                if (r["idupb"] != DBNull.Value) {
                    TitleUpb[r["idupb"].ToString()] = r[codiceUpb].ToString();
                }
            }
        }

        Dictionary<string, string> CodeCausale = new Dictionary<string, string>();
        Dictionary<string, string> TitleCausale = new Dictionary<string, string>();
        void preScanCausale(DataTable t, string fieldTitle) {
            if (!t.Columns.Contains(fieldTitle)) return;
            if (!t.Columns.Contains("idaccmotive")) return;

            foreach (DataRow r in t.Rows) {
                if (r["idaccmotive"] != DBNull.Value) {
                    CodeCausale[r["idaccmotive"].ToString()] = r["codemotive"].ToString();
                    TitleCausale[r["idaccmotive"].ToString()] = r[fieldTitle].ToString();
                }
            }
        }

        Dictionary<string, string> TitleAccount = new Dictionary<string, string>();
        Dictionary<string, string> CodeAccount = new Dictionary<string, string>();

        void preScanAccount(DataTable t, string fieldTitle) {
            if (!t.Columns.Contains(fieldTitle)) return;
            if (!t.Columns.Contains("idacc")) return;
            if (!t.Columns.Contains("codeacc")) return;

            foreach (DataRow r in t.Rows) {
                if (r["idacc"] != DBNull.Value) {
                    CodeAccount[r["idacc"].ToString()] = r["codeacc"].ToString();
                    TitleAccount[r["idacc"].ToString()] = r[fieldTitle].ToString();
                }
            }
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


        private void fillTempField() {
            tEntry.Columns.Add("!codiceconto");
            tEntry.Columns.Add("!conto");
            tEntry.Columns.Add("!dare");
            tEntry.Columns.Add("!avere");
            tEntry.Columns.Add("!anagrafica");
            tEntry.Columns.Add("!upb");
            tEntry.Columns.Add("!class1");
            tEntry.Columns.Add("!class2");
            tEntry.Columns.Add("!class3");
            tEntry.Columns.Add("!codicecausale");
            tEntry.Columns.Add("!causale");
            // Questi due campi li aggiungo perché altrimenti quelli veri andrebbero in testa al grid invece li voglio in coda
            tEntry.Columns.Add("!start");
            tEntry.Columns.Add("!stop");

            decimal saldo = 0;
            foreach (DataRow r in tEntry.Rows) {
                if (r["idacc"] != DBNull.Value) assegnaConto(r);
                if (r["idreg"] != DBNull.Value) assegnaAnagrafica(r);
                if (r["idupb"] != DBNull.Value) assegnaUpb(r);
                if (r["idaccmotive"] != DBNull.Value) assegnaCausale(r);
                if (r["idsor1"] != DBNull.Value) assegnaClass(r, 1);
                if (r["idsor2"] != DBNull.Value) assegnaClass(r, 2);
                if (r["idsor3"] != DBNull.Value) assegnaClass(r, 3);
                if (r["competencystart"] != DBNull.Value || r["competencystop"] != DBNull.Value) assegnaDate(r);
                assegnaD_A(r);
                saldo += CfgFn.GetNoNullDecimal(r["amount"]);
            }

            txtSaldo.Text = saldo.ToString("c");
        }

        private void assegnaD_A(DataRow r) {
            decimal importo = CfgFn.GetNoNullDecimal(r["amount"]);
            if (importo < 0) {
                r["!dare"] = -importo;
            }
            else {
                r["!avere"] = importo;
            }
        }

        private void assegnaDate(DataRow r) {
            r["!start"] = r["competencystart"];
            r["!stop"] = r["competencystop"];
        }

        //private void assegnaConto(DataRow r) {
        //    string filterC = QHC.CmpEq("idacc", r["idacc"]);
        //    string filterSQL = QHS.CmpEq("idacc", r["idacc"]);
        //    fill(r, filterC, filterSQL, tAccount, "!codiceconto", "codeacc");
        //    fill(r, filterC, filterSQL, tAccount, "!conto", "title");
        //}
        private void assegnaConto(DataRow r) {
            if (r["idacc"] == DBNull.Value) return;
            if (!CodeAccount.ContainsKey(r["idacc"].ToString())) {
                var o = Conn.readObject("account", QHS.CmpEq("idacc", r["idacc"]), "codeacc,title");
                CodeAccount[r["idacc"].ToString()] = o["codeacc"].ToString();
                TitleAccount[r["idacc"].ToString()] = o["title"].ToString();
            }
            if (CodeAccount.ContainsKey(r["idacc"].ToString())) {
                r["!codiceconto"] = CodeAccount[r["idacc"].ToString()];
                r["!conto"] = TitleAccount[r["idacc"].ToString()];
            }
        }


        //private void assegnaCausale(DataRow r) {
        //    string filterC = QHC.CmpEq("idaccmotive", r["idaccmotive"]);
        //    string filterSQL = QHS.CmpEq("idaccmotive", r["idaccmotive"]);
        //    fill(r, filterC, filterSQL, tAccMotive, "!codicecausale", "codemotive");
        //    fill(r, filterC, filterSQL, tAccMotive, "!causale", "title");
        //}
        private void assegnaCausale(DataRow r) {
            if (r["idaccmotive"] == DBNull.Value) return;
            if (!CodeCausale.ContainsKey(r["idaccmotive"].ToString())) {
                var o = Conn.readObject("accmotive", QHS.CmpEq("idaccmotive", r["idaccmotive"]), "codemotive,title");
                CodeCausale[r["idaccmotive"].ToString()] = o["codemotive"].ToString();
                TitleCausale[r["idaccmotive"].ToString()] = o["title"].ToString();
            }
            if (CodeAccount.ContainsKey(r["idaccmotive"].ToString())) {
                r["!codicecausale"] = CodeCausale[r["idaccmotive"].ToString()];
                r["!causale"] = TitleCausale[r["idaccmotive"].ToString()];
            }
        }


        //private void assegnaAnagrafica(DataRow r) {
        //    string filterC = QHC.CmpEq("idreg", r["idreg"]);
        //    string filterSQL = QHS.CmpEq("idreg", r["idreg"]);
        //    fill(r, filterC, filterSQL, tAnagrafica, "!anagrafica", "title");
        //}
        private void assegnaAnagrafica(DataRow r) {
            if (r["idreg"] == DBNull.Value) return;
            if (!TitleRegistry.ContainsKey(r["idreg"].ToString())) {
                var o = Conn.readObject("registry", QHS.CmpEq("idreg", r["idreg"]), "title");
                TitleRegistry[r["idreg"].ToString()] = o["title"].ToString();
            }
            if (TitleRegistry.ContainsKey(r["idreg"].ToString())) {
                r["!anagrafica"] = TitleRegistry[r["idreg"].ToString()];
            }
        }


        //private void assegnaUpb(DataRow r) {
        //    string filterC = QHC.CmpEq("idupb", r["idupb"]);
        //    string filterSQL = QHS.CmpEq("idupb", r["idupb"]);
        //    fill(r, filterC, filterSQL, tUpb, "!upb", "codeupb");
        //}
        private void assegnaUpb(DataRow r) {
            if (r["idupb"] == DBNull.Value) return;
            if (!TitleUpb.ContainsKey(r["idupb"].ToString())) {
                var o = Conn.readObject("upb", QHS.CmpEq("idupb", r["idupb"]), "codeupb");
                TitleUpb[r["idupb"].ToString()] = o["codeupb"].ToString();
            }
            if (TitleUpb.ContainsKey(r["idupb"].ToString())) {
                r["!upb"] = TitleUpb[r["idupb"].ToString()];
            }
        }


        //private void assegnaClass(DataRow r, int nSor) {
        //    if ((tExpenseSetup == null) || (tExpenseSetup.Rows.Count == 0)) return;
        //    DataRow rExp = tExpenseSetup.Rows[0];
        //    string filterC = QHC.AppAnd(QHC.CmpEq("idsorkind", rExp["idsortingkind" + nSor]),
        //        QHC.CmpEq("idsor", r["idsor" + nSor]));
        //    string filterSQL = QHS.AppAnd(QHS.CmpEq("idsorkind", rExp["idsortingkind" + nSor]),
        //        QHS.CmpEq("idsor", r["idsor" + nSor]));
        //    fill(r, filterC, filterSQL, tSorting, "!class" + nSor, "sortcode");
        //}

        private void assegnaClass(DataRow r, int nSor) {
            if ((tExpenseSetup == null) || (tExpenseSetup.Rows.Count == 0)) return;
            DataRow rExp = tExpenseSetup.Rows[0];
            object idsor = r["idsor" + nSor];

            if (idsor == DBNull.Value) return;
            if (!CodeSorting.ContainsKey(idsor.ToString())) {
                var o = Conn.readObject("sorting", QHS.CmpEq("idsor", idsor), "sortcode");
                CodeSorting[idsor.ToString()] = o["sortcode"].ToString();
            }
            if (CodeSorting.ContainsKey(idsor.ToString())) {
                r["!class" + nSor] = CodeSorting[idsor.ToString()];
            }
        }

        /// <summary>
        /// Metodo che riempie il campo del datarow che abndrà in output
        /// </summary>
        /// <param name="r">DataRow da aggiornare</param>
        /// <param name="filter">Filtro sulla tabella a cui la chiave esterna fa riferimento</param>
        /// <param name="t">Tabella Padre</param>
        /// <param name="tempField">Nome del campo temporaneo (iniziante sempre con !)</param>
        /// <param name="field">Come del campo della tabella padre</param>
        private void fill(DataRow r, string filterC, string filterSQL, DataTable t, string tempField, string field) {
            if (t.Select(filterC).Length > 0) {
                DataRow rOfT = t.Select(filterC)[0];
                r[tempField] = rOfT[field];
                return;
            }
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, t, null, filterSQL, null, true);
            if (t.Select(filterC).Length > 0) {
                DataRow rOfT = t.Select(filterC)[0];
                r[tempField] = rOfT[field];
            }
        }

        private void assegnaCaption() {
            foreach (DataColumn c in tEntry.Columns) {
                c.Caption = "";
            }
            tEntry.Columns["!dare"].Caption = "Dare";
            tEntry.Columns["!avere"].Caption = "Avere";
            tEntry.Columns["!codiceconto"].Caption = "Codice Conto";
            tEntry.Columns["!conto"].Caption = "Conto";
            tEntry.Columns["!anagrafica"].Caption = "Anagrafica";
            tEntry.Columns["!upb"].Caption = "U.P.B.";
            tEntry.Columns["!class1"].Caption = "Coord. Anal. 1";
            tEntry.Columns["!class2"].Caption = "Coord. Anal. 2";
            tEntry.Columns["!class3"].Caption = "Coord. Anal. 3";
            tEntry.Columns["!codicecausale"].Caption = "Codice Causale";
            tEntry.Columns["!causale"].Caption = "Causale";
            tEntry.Columns["!start"].Caption = "Data Inizio";
            tEntry.Columns["!stop"].Caption = "Data Fine";
        }
    }
}
