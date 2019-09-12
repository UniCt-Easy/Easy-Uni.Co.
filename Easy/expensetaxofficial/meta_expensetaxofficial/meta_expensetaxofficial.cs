/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Text;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_expensetaxofficial {
    public class Meta_expensetaxofficial : Meta_easydata {
        public Meta_expensetaxofficial(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "expensetaxofficial") {
            Name = "Dettaglio Riepilogo Ritenute";
            EditTypes.Add("default");
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
            ListingTypes.Add("liquidazione");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                return GetFormByDllName("expensetaxofficial_default");
            }
            return null;
        }
        public override bool CanSelect(DataRow R) {
            if (R.Table.Columns.Contains("ymov")) {
                if (R["ymov"] != DBNull.Value) {
                    if (Convert.ToInt32(R["ymov"]) != Convert.ToInt32(GetSys("esercizio"))) {
                        MessageBox.Show("La riga scelta non appartiene all'esercizio corrente e non può essere selezionata.");
                        return false;
                    }
                }
            }
            return DataAccess.CanSelect(Conn,R);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.ClearMySelector(T, "idexp");
            RowChange.ClearMySelector(T, "taxcode");

            RowChange.SetMySelector(T.Columns["idexpensetaxofficial"], "idexp", 0);
            RowChange.MarkAsAutoincrement(T.Columns["idexpensetaxofficial"], null, null, 7);

            RowChange.SetMySelector(T.Columns["nbracket"], "idexp", 0);
            RowChange.SetMySelector(T.Columns["nbracket"], "taxcode", 0);
            RowChange.MarkAsAutoincrement(T.Columns["nbracket"], null, null, 7);

            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, ".idexpensetaxofficial", "Dettaglio #", nPos++);
                DescribeAColumn(T, ".taxcode", "#", nPos++);
                DescribeAColumn(T, "!taxref", "Codice", "tax.taxref", nPos++);
                DescribeAColumn(T, "!description", "Descrizione", "tax.description", nPos++);
                DescribeAColumn(T, "employtax", "Rit. dip.", nPos++);
                DescribeAColumn(T, "admintax", "Rit. amm.", nPos++);
                DescribeAColumn(T, "ayear", "Anno di competenza", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                
                HelpForm.SetFormatForColumn(T.Columns["employrate"], "p");
                HelpForm.SetFormatForColumn(T.Columns["adminrate"], "p");
                HelpForm.SetFormatForColumn(T.Columns["employnumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["employdenominator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["adminnumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["admindenominator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxablenumerator"], "n");
                HelpForm.SetFormatForColumn(T.Columns["taxabledenominator"], "n");
            }
        }
    }
}

