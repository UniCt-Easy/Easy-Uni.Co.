/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_sortabletable {
    public class Meta_sortabletable :Meta_easydata {
        public Meta_sortabletable(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sortabletable") {
            Name = "Tabelle classificabili";
            ListingTypes.Add("solodescrizione");
        }


        //QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
        //                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")))


        private string[] mykey = new string[] { "tablename" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "solodescrizione")  {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "",-1);
                }
                int nPos = 1;
                DescribeAColumn(T, "tablename", "Tabella", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);           
            }

        }




    }
}

