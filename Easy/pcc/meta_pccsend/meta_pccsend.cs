
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_pccsend{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_pccsend : Meta_easydata {
        public Meta_pccsend(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "pccsend") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }


        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idpcc");
            RowChange.MarkAsAutoincrement(T.Columns["idpccsend"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "pccsendview", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
                DescribeAColumn(T, "idpcc", "Num. Trasmissione", nPos++);
                DescribeAColumn(T, "idpccsend", "Num.riga", nPos++);
            }
        }

    }
}
