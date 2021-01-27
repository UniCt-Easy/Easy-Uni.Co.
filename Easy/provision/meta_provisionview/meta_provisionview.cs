
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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_provisionview{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_provisionview : Meta_easydata{
        public Meta_provisionview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "provisionview"){
            ListingTypes.Add("default");
            Name = "Fondo di Accantonamento";
        }

        private string[] mykey = new string[] { "idprovision" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione Fondo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);
                DescribeAColumn(T, "upb", "U.P.B.", nPos++);
                DescribeAColumn(T, "doc", "Doc. Collegato", nPos++);
                DescribeAColumn(T, "docdate", "Data Doc. Collegato", nPos++);
                DescribeAColumn(T, "yepexp", "Eserc. Impegno di Budget", nPos++);
                DescribeAColumn(T, "nepexp", "Num. Impegno di Budget", nPos++);
                DescribeAColumn(T, "available", "Disponibile", nPos++);
                DescribeAColumn(T, "payed", "Pagato", nPos++);
                DescribeAColumn(T, "topay", "Da Pagare", nPos++);
            }
        }



    }
}
