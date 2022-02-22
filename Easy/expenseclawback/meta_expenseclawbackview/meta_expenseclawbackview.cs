
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;



namespace meta_expenseclawbackview 
{
	/// <summary>
	/// </summary>
	public class Meta_expenseclawbackview : Meta_easydata 
	{
        public Meta_expenseclawbackview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "expenseclawbackview") 
		{
            ListingTypes.Add("dettagliocollegato");
		
		}
        private string[] mykey = new string[] { "idexp", "idclawback" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
               if (listtype == "dettagliocollegato")
                {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idclawback", ".#", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "desctiporiga", "Sezione", nPos++);
                DescribeAColumn(T, "fiscaltaxcode", "Codice Tributo", nPos++);
                DescribeAColumn(T, "code", "Codice Sede", nPos++);
                DescribeAColumn(T, "identifying_marks", "Estremi", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "transmissiondate", "Trasmissione", nPos++);
                FilterRows(T);
            }
        
		}

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "dettagliocollegato") {
                if (R["idf24ep"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

	}
}
