
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_paymenttransmissionview {//meta_trasmdocpagamentoview//
	/// <summary>
	/// Summary description for Class1.
	/// Author: Leo, 12 Dec 2002, End 12 Dec 2002
	/// </summary>
	public class Meta_paymenttransmissionview : Meta_easydata {
		public Meta_paymenttransmissionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "paymenttransmissionview"){
			ListingTypes.Add("lista");   
		}
        private string[] mykey = new string[] { "kpaymenttransmission" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
                int nPos = 1;
                DescribeAColumn(T, "ypaymenttransmission", "Eserc. distinta", nPos++);
				DescribeAColumn(T, "npaymenttransmission", "Num. distinta", nPos++);
				DescribeAColumn(T, "manager", "Responsabile", nPos++);
				DescribeAColumn(T, "idtreasurer", ".#Cassiere", nPos++);
                DescribeAColumn(T, "codetreasurer", "Cod. Cassiere", nPos++);
                DescribeAColumn(T, "treasurer", "Cassiere", nPos++);
                DescribeAColumn(T, "transmissiondate", "Data trasm.", nPos++);
				DescribeAColumn(T, "total", "Totale distinta", nPos++);
			}
		}
	}
}
