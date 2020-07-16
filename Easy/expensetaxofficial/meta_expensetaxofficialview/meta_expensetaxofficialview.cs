/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;


namespace meta_expensetaxofficialview
{
    /// <summary>
    /// </summary>
    public class Meta_expensetaxofficialview : Meta_easydata {
        public Meta_expensetaxofficialview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
        base(Conn, Dispatcher, "expensetaxofficialview") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "";
        }

        protected override Form GetForm (string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Riepilogo Storico Ritenute Applicate";
                return MetaData.GetFormByDllName("expensetaxofficialview_default");
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
            return DataAccess.CanSelect(Conn, R);
        }

        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            switch (ListingType) {
                case "default":
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "phase", "Fase spesa", nPos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
                DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
                DescribeAColumn(T, "idreg", "Cod. Percipiente", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "expensedescription", "Descrizione pag.", nPos++);
                DescribeAColumn(T, "taxref", "Cod. ritenuta", nPos++);
                DescribeAColumn(T, "description", "Desc. ritenuta", nPos++);
                DescribeAColumn(T, "taxkind", "Tipo ritenuta", nPos++);
                DescribeAColumn(T, "employrate", "Aliq. dip.", nPos++);
                DescribeAColumn(T, "employtax", "Rit. dip.", nPos++);
                DescribeAColumn(T, "adminrate", "Aliq. amm.", nPos++);
                DescribeAColumn(T, "admintax", "Rit. amm.", nPos++);
                DescribeAColumn(T, "start", "Inizio valid.", nPos++);
                DescribeAColumn(T, "stop", "Fine valid.", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "fiscaltaxregion", "Comune", nPos++);
                break;

            }
        }
    }
}
