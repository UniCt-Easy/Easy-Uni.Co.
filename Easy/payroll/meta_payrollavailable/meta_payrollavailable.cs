
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_payrollavailable {//meta_cedolinooperativo//
	/// <summary>
	/// Summary description for Meta_cedolinooperativo.
	/// </summary>
	public class Meta_payrollavailable : Meta_easydata {
		public Meta_payrollavailable(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrollavailable") {		
			Name= "Cedolini da Contabilizzare";
			ListingTypes.Add("default");
		}

		
		public override string GetSorting(string ListingType)
		{
			string sorting;
			if (ListingType=="default")
			{
				sorting = "fiscalyear desc,npayroll desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

        private string[] mykey = new string[] { "idpayroll"};
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "idpayroll", "Num. Cedolino",1);
				DescribeAColumn(T, "fiscalyear", "Anno Fiscale",2);
				DescribeAColumn(T, "npayroll", "Progressivo Anno",3);
				DescribeAColumn(T, "ycon", "Eserc. Contratto",4);
				DescribeAColumn(T, "ncon", "Num. Contratto",5);
				DescribeAColumn(T, "registry", "Percipiente",6);
				DescribeAColumn(T, "flagbalance", "Conguaglio",7);
				DescribeAColumn(T, "feegross", "Compenso Lordo",8);
				DescribeAColumn(T, "netfee", "Compenso Netto",9);
				DescribeAColumn(T, "start", "Data Inizio",10);
				DescribeAColumn(T, "stop", "Data Fine",11);
				DescribeAColumn(T, "codeupb", "Cod. Upb", 12);
				DescribeAColumn(T, "workingdays", "Giorni Lavorati",12);
			}
		}
	}
}
