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


namespace no_table_entry_rettifica {
    public partial class FrmEntryPreSavePluriennale : Form {
        DataTable tEntry;
        DataAccess Conn;
        DataTable tAccount;
        DataTable tUpb;
        CQueryHelper QHC;
        QueryHelper QHS;
        ContextMenu ExcelMenu;
        int esercizio;


        public FrmEntryPreSavePluriennale(DataTable tEntry, DataAccess Conn) {
            InitializeComponent();
            this.tEntry = tEntry;
            this.Conn = Conn;
            QHS = this.Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            esercizio = (int)Conn.GetSys("esercizio");

            tAccount = DataAccess.CreateTableByName(Conn, "account", "idacc, codeacc, title");
            tUpb = DataAccess.CreateTableByName(Conn, "upb", "idupb, codeupb");
            string f = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));

            fillTempField();
            assegnaCaption();
            HelpForm.SetDataGrid(dgDettaglio, tEntry);

            ExcelMenu = new ContextMenu();
            ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));


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
            //tEntry.Columns.Add("!costi", typeof(decimal));
            //tEntry.Columns.Add("!ricavi", typeof(decimal));
            //tEntry.Columns.Add("!rateoattivo", typeof(decimal));
            //tEntry.Columns.Add("!scadenza", typeof(int));
            tEntry.Columns.Add("!codiceconto");
            tEntry.Columns.Add("!conto");
            tEntry.Columns.Add("!dare");
            tEntry.Columns.Add("!avere");
            tEntry.Columns.Add("!upb");
            tEntry.Columns.Add("!importo", typeof(decimal));

            decimal saldo = 0;
            foreach (DataRow r in tEntry.Rows) {
                if (r["idacc"] != DBNull.Value) assegnaConto(r);
                if (r["idupb"] != DBNull.Value) assegnaUpb(r);
                assegnaD_A(r);
                saldo += CfgFn.GetNoNullDecimal(r["amount"]);
            }

        }

        private void assegnaD_A(DataRow r) {
            decimal importo = CfgFn.GetNoNullDecimal(r["amount"]);
            if (importo < 0) {
                r["!dare"] = -importo;
                r["!importo"] = -importo;
            }
            else {
                r["!avere"] = importo;
                r["!importo"] = importo;
            }
        }



        private void assegnaConto(DataRow r) {
            string filterC = QHC.CmpEq("idacc", r["idacc"]);
            string filterSQL = QHS.CmpEq("idacc", r["idacc"]);
            fill(r, filterC, filterSQL, tAccount, "!codiceconto", "codeacc");
            fill(r, filterC, filterSQL, tAccount, "!conto", "title");
        }


        private void assegnaUpb(DataRow r) {
            string filterC = QHC.CmpEq("idupb", r["idupb"]);
            string filterSQL = QHS.CmpEq("idupb", r["idupb"]);
            fill(r, filterC, filterSQL, tUpb, "!upb", "codeupb");
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
                MetaData.DescribeAColumn(tEntry, c.ColumnName, "", -1);
            }
            int npos = 1;

            MetaData.DescribeAColumn(tEntry, "!costi", "Costi", npos++);
            MetaData.DescribeAColumn(tEntry, "!riserve", "Riserve", npos++);
            MetaData.DescribeAColumn(tEntry, "!ricavi", "Ricavi", npos++);
            
            MetaData.DescribeAColumn(tEntry, "!rateoattivo", "Rateo att.", npos++);
            MetaData.DescribeAColumn(tEntry, "!scadenza", "Scadenza", npos++);

            MetaData.DescribeAColumn(tEntry, "!importo", "Importo", npos++);

            MetaData.DescribeAColumn(tEntry, "!dare", "Dare", npos++);
            MetaData.DescribeAColumn(tEntry, "!avere", "Avere", npos++);
            MetaData.DescribeAColumn(tEntry, "!codiceconto", "Codice Conto", npos++);
            MetaData.DescribeAColumn(tEntry, "!conto", "Conto", npos++);
            MetaData.DescribeAColumn(tEntry, "!upb", "U.P.B.", npos++);


        }

    }
}
