
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



namespace meta_taxpayview//meta_liquidazioneritenutaview//
{
	/// <summary>
	/// Summary description for liquidazioneritenutaview.
	/// </summary>
	public class Meta_taxpayview : Meta_easydata 
	{
		public Meta_taxpayview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "taxpayview") 
		{
			ListingTypes.Add("default");
            ListingTypes.Add("liqcollegata");
		
		}

		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
            if (listtype == "default") 
			{
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "taxref", "Cod. ritenuta", nPos++);
                DescribeAColumn(T, "taxkind", "Ritenuta", nPos++);
                DescribeAColumn(T, "ytaxpay", "Eserc. liq.", nPos++);
                DescribeAColumn(T, "ntaxpay", "Num. liq.", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);				
			}

            if (listtype == "liqcollegata") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "taxref", "Cod. ritenuta", nPos++);
                DescribeAColumn(T, "taxkind", "Ritenuta", nPos++);
                DescribeAColumn(T, "ytaxpay", "Eserc. liq.", nPos++);
                DescribeAColumn(T, "ntaxpay", "Num. liq.", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                FilterRows(T);
            }
        
		}

        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "liqcollegata") {
                if (R["idf24ep"] == DBNull.Value) return false;
                return true;
            }

            return true;
        }

	}
}
