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
using metaeasylibrary;
using metadatalibrary;
using System.Data;


namespace meta_ddt_inview
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_ddt_inview : Meta_easydata
    {
        public Meta_ddt_inview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "meta_ddt_inview")
        {
            Name = "Bolla di Ingresso";
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);
            if (listtype == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idddt_in", ".Cod", nPos++);
                DescribeAColumn(T, "yddt_in", "Esercizio", nPos++);
                DescribeAColumn(T, "nddt_in", "Numero", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "terms", "Termine Consegna", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "ddt_in_motive", "Causale", nPos++);
            }

        }

    }
}
