
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

namespace meta_payrolllinked//meta_cedolinocontabilizzato//
{
	/// <summary>
	/// Summary description for Meta_cedolinocontabilizzato.
	/// </summary>
	public class Meta_payrolllinked : Meta_easydata
	{
		public Meta_payrolllinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrolllinked") 
		{		
			Name= "Cedolini Contabilizzati";
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "ayear", "idpayroll" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting = "fiscalyear desc,npayroll desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
		public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns) 
				{
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "idpayroll", "Num. Cedolino", nPos++);
                DescribeAColumn(T, "fiscalyear", "Anno Fiscale", nPos++);
                DescribeAColumn(T, "npayroll", "Progressivo Anno", nPos++);
                DescribeAColumn(T, "ycon", "Eserc. Contratto", nPos++);
                DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codeser", "Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "workingdays", "Giorni Lavorati", nPos++);
                DescribeAColumn(T, "disbursementdate", "Data Erogazione", nPos++);
                DescribeAColumn(T, "feegross", "Compenso Lordo", nPos++);
                DescribeAColumn(T, "netfee", "Compenso Netto", nPos++);
                DescribeAColumn(T, "flagbalance", "Conguaglio", nPos++);
			}
		}
	}
}
