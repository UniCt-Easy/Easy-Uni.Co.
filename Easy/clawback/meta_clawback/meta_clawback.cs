/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using metaeasylibrary;
//Pino: using tiporecupero; diventato inutile

namespace meta_clawback//meta_tiporecupero//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_clawback : Meta_easydata {
		public Meta_clawback(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "clawback") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
		}

		protected override Form GetForm(string FormName) {
			if (FormName=="default")
			{
				Name = "Tipi di recupero";
				ActAsList();
				return MetaData.GetFormByDllName("clawback_default");//PinoRana
			}

			return null;
		}
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idclawback"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
            if (listtype == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idclawback", "ID", nPos++);
                DescribeAColumn(T, "clawbackref", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", 4);
            }
            if (listtype == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "clawbackref", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
		}   
	}
}
