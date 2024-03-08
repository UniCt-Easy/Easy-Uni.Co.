
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_profserviceavailablemono
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_profserviceavailablemono :Meta_easydata {
        public Meta_profserviceavailablemono(DataAccess Conn, MetaDataDispatcher Dispatcher) :
        base(Conn, Dispatcher, "profserviceavailablemono") {
            Name = "Contratti Professionali da Contabilizzare";
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "ycon", "ncon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "ycon desc, ncon desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                DescribeAColumn(T, "ycon", "Eserc. Contratto", 1);
                DescribeAColumn(T, "ncon", "Num. Contratto", 2);
                DescribeAColumn(T, "registry", "Percipiente", 3);
                DescribeAColumn(T, "description", "Descrizione", 4);
                DescribeAColumn(T, "start", "Data Inizio", 5);
                DescribeAColumn(T, "stop", "Data Fine", 6);
                DescribeAColumn(T, "adate", "Data Contabile", 7);
                DescribeAColumn(T, "feegross", "Compenso Lordo", 8);
                DescribeAColumn(T, "totalcost", "Costo Totale", 9);
                DescribeAColumn(T, "taxabletotal", "Totale Imponibile", 10);
                DescribeAColumn(T, "ivatotal", "Totale IVA", 11);
                DescribeAColumn(T, "linkedtotal", "Totale Movimenti", 12);
                DescribeAColumn(T, "residual", "Residuo", 13);
            }
        }

    }
}
