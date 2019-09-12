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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_listclassyearview
{
    /// <summary>
    /// Summary description for Meta_listclassyear.
    /// </summary>
    public class Meta_listclassyearview : Meta_easydata {
        public Meta_listclassyearview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "listclassyearview"){
            Name = "Classificazione Merceologica";
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "idlistclass","ayear" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "idlistclass", "#", nPos++);
                DescribeAColumn(T, "codelistclass", "Codice", nPos++);
                DescribeAColumn(T, "title", "Descrizione", nPos++);
                DescribeAColumn(T, "codemotive", "Cod. causale EP", nPos++);
                DescribeAColumn(T, "motive", "Causale costo", nPos++);
                DescribeAColumn(T, "codeintrastatcode", "Cod. nomenclatura combinata", nPos++);
                DescribeAColumn(T, "intrastatcode", "Nomenclatura combinata", nPos++);
                DescribeAColumn(T, "intrastatservice", "Servizio Intrastat", nPos++);
                DescribeAColumn(T, "codeinv", "Cod. Class. Inventariale", nPos++);
                DescribeAColumn(T, "inventorytree", "Class. Inventariale", nPos++);
                DescribeAColumn(T, "fincodemotive", "Cod. causale fin.", nPos++);
                DescribeAColumn(T, "finmotive", "Causale fin", nPos++);
            }

        }

    }
}