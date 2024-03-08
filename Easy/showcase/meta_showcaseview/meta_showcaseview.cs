
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;

namespace meta_showcaseview
{
    public class Meta_showcaseview:Meta_easydata
    {
        public Meta_showcaseview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "showcaseview")
        {
            ListingTypes.Add("default");
            Name = "Vetrine";
        }
        private string[] mykey = new string[] { "idshowcase" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);

            if (listtype == "default")
            {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int ncol;
                ncol = 1;

                DescribeAColumn(T, "title", "Nome", ncol++);
                DescribeAColumn(T, "description", "Descrizione", ncol++);
                DescribeAColumn(T, "store", "Magazzino", ncol++);
                DescribeAColumn(T, "deliveryaddress", "Indirizzo", ncol++);

            }
        }   

    }
}
