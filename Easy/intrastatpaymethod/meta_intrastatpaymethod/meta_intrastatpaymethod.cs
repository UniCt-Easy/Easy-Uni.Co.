/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;

namespace meta_intrastatpaymethod{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_intrastatpaymethod : Meta_easydata
    {
        public Meta_intrastatpaymethod(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "intrastatpaymethod"){
            EditTypes.Add("lista");
            ListingTypes.Add("lista");
            Name = " Natura della transazione";
        }
        protected override Form GetForm(string FormName){
            if (FormName == "lista"){
                ActAsList();
                return MetaData.GetFormByDllName("intrastatpaymethod_lista");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string listtype)
        {
            base.DescribeColumns(T, listtype);

            if (listtype == "lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "idintrastatpaymethod", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
            }
        }
    }
}
