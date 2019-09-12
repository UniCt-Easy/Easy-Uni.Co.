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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_package
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_package : Meta_easydata {
        public Meta_package(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "package"){
			EditTypes.Add("lista");
			ListingTypes.Add("lista");
            Name = " Unità di Misura per l'acquisto";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="lista") {
				ActAsList();
                return MetaData.GetFormByDllName("package_lista");
			}
			return null;
		}

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idpackage"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);

        }
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);

			if (listtype=="lista"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

                DescribeAColumn(T, "idpackage", "Codice");
				DescribeAColumn(T, "description","Descrizione");
                DescribeAColumn(T, "active", "Attivo");
			}
		}   
	}
}
