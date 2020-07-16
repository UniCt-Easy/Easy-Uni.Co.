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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_billtransactionview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_billtransactionview : Meta_easydata {
        public Meta_billtransactionview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "billtransactionview") {		
            Name= "Regolarizzazioni bollette - elenco";
            ListingTypes.Add("default");
		}
		public override string GetStaticFilter(string ListingType) {
			if (ListingType=="default"){
				string filterEsercizio = "(ybilltran='"+GetSys("esercizio")+"')";
				return filterEsercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
        private string[] mykey = new string[] { "ybilltran", "nbilltran" };
        public override string[] primaryKey() {
            return mykey;
        }


        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			 
			if (ListingType == "default") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
				//DescribeAColumn(T,"yban","Eserc. Transazione", nPos++);
				DescribeAColumn(T,"nbilltran","Progressivo", nPos++);
				DescribeAColumn(T,"adate","Data Operazione", nPos++);
				DescribeAColumn(T,"amount","Importo", nPos++);
				DescribeAColumn(T,"income","Entrate", nPos++);
				DescribeAColumn(T,"expense","Uscite", nPos++);
				DescribeAColumn(T,"ypay","Eserc. Mandato", nPos++);
				DescribeAColumn(T,"npay","Num. Mandato", nPos++);
				DescribeAColumn(T,"ypro","Eserc. Reversale", nPos++);
				DescribeAColumn(T,"npro","Num. Reversale", nPos++);
			} 
        }   	
	    }	
}
