/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_showcasedetailview
{
    public class Meta_showcasedetailview:Meta_easydata
    {
        public Meta_showcasedetailview(DataAccess Conn, Meta_EasyDispatcher Dispatcher)
            : base(Conn, Dispatcher, "showcasedetailview")
        {
            ListingTypes.Add("default");
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

                //DescribeAColumn(T, "store", "Magazzino",nPos++);
                DescribeAColumn(T, "intcode", "Codice", nPos++);
                DescribeAColumn(T, "list", "Desc. Articolo", nPos++);
                //DescribeAColumn(T, "number", "Q.t‡ in Carico", nPos++);
                //DescribeAColumn(T, "booked", "Q.t‡ prenotata", nPos++);
                DescribeAColumn(T, "listclass", "Class. Merceologica", nPos++);


            }
        }

    }
}
