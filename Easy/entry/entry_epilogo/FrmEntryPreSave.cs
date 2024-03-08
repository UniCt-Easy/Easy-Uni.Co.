
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace entry_epilogo {
    public partial class FrmEntryPreSave : Form {
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

        public FrmEntryPreSave(DataTable tEntry, DataAccess Conn) {
            InitializeComponent();
            this.tEntry = tEntry;
            this.Conn = Conn;
            QHS = this.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            tAccount = DataAccess.CreateTableByName(Conn, "account", "idacc, codeacc, title");
            tAnagrafica = DataAccess.CreateTableByName(Conn, "registry", "idreg, title");
            tUpb = DataAccess.CreateTableByName(Conn, "upb", "idupb, codeupb");
            tSorting = DataAccess.CreateTableByName(Conn, "sorting", "idsorkind, idsor");
            tAccMotive = DataAccess.CreateTableByName(Conn, "accmotive", "idaccmotive, codemotive, title");
            tExpenseSetup = DataAccess.CreateTableByName(Conn, "config", "ayear, idsorkind1, idsorkind2, idsorkind3");
            string f = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, tExpenseSetup, null, f, null, true);

            fillTempField();
            assegnaCaption();
            HelpForm.SetDataGrid(dgDettaglio, tEntry);
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

        private void assegnaConto(DataRow r) {
            string filterC = QHC.CmpEq("idacc", r["idacc"]);
            string filterSQL = QHS.CmpEq("idacc", r["idacc"]);
            fill(r, filterC, filterSQL, tAccount, "!codiceconto", "codeacc");
            fill(r, filterC, filterSQL, tAccount, "!conto", "title");
        }

        private void assegnaCausale(DataRow r) {
            string filterC = QHC.CmpEq("idaccmotive", r["idaccmotive"]);
            string filterSQL = QHS.CmpEq("idaccmotive", r["idaccmotive"]);
            fill(r, filterC, filterSQL, tAccMotive, "!codicecausale", "codemotive");
            fill(r, filterC, filterSQL, tAccMotive, "!causale", "title");
        }

        private void assegnaAnagrafica(DataRow r) {
            string filterC = QHC.CmpEq("idreg", r["idreg"]);
            string filterSQL = QHS.CmpEq("idreg", r["idreg"]);
            fill(r, filterC, filterSQL, tAnagrafica, "!anagrafica", "title");
        }

        private void assegnaUpb(DataRow r) {
            string filterC = QHC.CmpEq("idupb", r["idupb"]);
            string filterSQL = QHS.CmpEq("idupb", r["idupb"]);
            fill(r, filterC, filterSQL, tUpb, "!upb", "codeupb");
        }

        private void assegnaClass(DataRow r, int nSor) {
            if ((tExpenseSetup == null) || (tExpenseSetup.Rows.Count == 0)) return;
            DataRow rExp = tExpenseSetup.Rows[0];
            string filterC = QHC.AppAnd(QHC.CmpEq("idsorkind", rExp["idsorkind" + nSor]),
                QHC.CmpEq("idsor", r["idsor" + nSor]));
            string filterSQL = QHS.AppAnd(QHS.CmpEq("idsorkind", rExp["idsorkind" + nSor]),
                QHS.CmpEq("idsor", r["idsor" + nSor]));
            fill(r, filterC, filterSQL, tSorting, "!class" + nSor, "sortcode");
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
