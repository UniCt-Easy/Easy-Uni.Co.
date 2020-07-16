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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//using valuta;
//Pino: using valutalista; diventato inutile
using metadatalibrary;

namespace meta_currency
{

	public class Meta_currency : Meta_easydata 
	{
		public Meta_currency(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "currency") 
		{
			EditTypes.Add("lista");
			ListingTypes.Add("default");
            ListingTypes.Add("checkimport");
            ListingTypes.Add("lista");
			Name = "Valuta";
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="lista") 
			{
				ActAsList();
				return MetaData.GetFormByDllName("currency_lista");
			}

			return null;
		}			
	
		
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
            if (listtype == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codecurrency", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
            if (listtype == "checkimport"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codecurrency", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
            if (listtype == "lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codecurrency", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
		}

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcurrency"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idcurrency");
            if (N < 9999000)
                R["idcurrency"] = 9999001;
            else
                R["idcurrency"] = N + 1;

            return R;
        }
    }
}
