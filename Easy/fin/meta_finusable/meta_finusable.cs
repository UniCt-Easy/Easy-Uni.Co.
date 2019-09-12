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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using funzioni_configurazione;
namespace meta_finusable
{
    public class Meta_finusable : Meta_easydata
    {
        public Meta_finusable(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "finusable")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        string[] mykey = new string[] { "idfin" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType)
        {
            string sorting;
            if (ListingType == "default")
            {
                sorting = "finpart asc,title asc,codefin asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }


        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);

            if (listtype == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "codefin", "Codice", nPos);
                nPos++;
                DescribeAColumn(T, "title", "Descrizione", nPos);
                nPos++;
                DescribeAColumn(T, "finpart", "Entrata/Spesa", nPos);
            }
        }

    }
}
