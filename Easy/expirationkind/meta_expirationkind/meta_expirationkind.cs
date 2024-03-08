
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
using metaeasylibrary;
using metadatalibrary;
//Pino: using tiposcadenza; diventato inutile
using System.Windows.Forms;

namespace meta_expirationkind//meta_tiposcadenza//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_expirationkind : Meta_easydata {
		public Meta_expirationkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expirationkind") {
			EditTypes.Add("lista");
			ListingTypes.Add("lista");
			Name = " Tipo Scadenza";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="lista") {
				ActAsList();
				return MetaData.GetFormByDllName("expirationkind_lista");//PinoRana
			}
			return null;
		}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idexpirationkind"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
            
        }
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);

			if (listtype=="lista"){
				foreach(DataColumn C in T.Columns) 
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T, "idexpirationkind","Codice");
				DescribeAColumn(T, "description","Descrizione");
                DescribeAColumn(T, "shorttitle", "Sigla");
        		DescribeAColumn(T, "active","Attivo");
			}
		}   
	}
}
