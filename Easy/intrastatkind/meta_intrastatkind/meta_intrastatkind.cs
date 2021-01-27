
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;
//Pino: using tiposcadenza; diventato inutile
using System.Windows.Forms;

namespace meta_intrastatkind//meta_tiposcadenza//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_intrastatkind : Meta_easydata {
		public Meta_intrastatkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "intrastatkind") {
			EditTypes.Add("lista");
			ListingTypes.Add("lista");
            Name = " Natura della transazione";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="lista") {
				ActAsList();
				return MetaData.GetFormByDllName("intrastatkind_lista");
			}
			return null;
		}
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);

			if (listtype=="lista"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T, "idintrastatkind","Codice");
				DescribeAColumn(T, "description","Descrizione");
			}
		}   
	}
}
