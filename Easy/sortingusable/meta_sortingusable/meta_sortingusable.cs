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

ï»¿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_sortingusable {
    public class Meta_sortingusable :Meta_easydata {
        public Meta_sortingusable(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sortingusable") {
            Name = "Classificazione";
            ListingTypes.Add("tree");
            ListingTypes.Add("treeusable");
        }

        private string[] mykey = new string[] { "idsor" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if ((ListingType == "tree") || (ListingType== "treeusable")){
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "",-1);
                }
                int nPos = 1;
                DescribeAColumn(T, "sortcode", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "movkind", "Tipo movimento", nPos++);
                DescribeAColumn(T, "printingorder", "Ordine stampa", nPos++);
            }

        }




    }
}

