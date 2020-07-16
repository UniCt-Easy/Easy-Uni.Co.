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
//Pino: using tiporesidenza; diventato inutile
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_residence//meta_tiporesidenza//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_residence : Meta_easydata {
		public Meta_residence(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "residence") {
			EditTypes.Add("lista");
			ListingTypes.Add("lista");
			Name = " Tipo Residenza";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="lista") {
				ActAsList();
				return MetaData.GetFormByDllName("residence_lista");//PinoRana
			}
			return null;
		}			
	
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);

			if (listtype=="lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "coderesidence", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
		}   
	}
}
