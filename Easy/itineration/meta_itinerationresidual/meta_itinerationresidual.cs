
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_itinerationresidual//meta_residuomissione//
{
	public class Meta_itinerationresidual : Meta_easydata {
	
		public Meta_itinerationresidual(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "itinerationresidual") {		
			Name = "Missioni da contabilizzare";
			ListingTypes.Add("default");

		}
        private string[] mykey = new string[] { "iditineration" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType)
		{
			string sorting;
			if (ListingType=="default")
			{
				sorting = "yitineration desc,nitineration desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
                DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
                DescribeAColumn(T, "registry", "Denom. Percipiente", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "totalgross", "Tot. lordo missione", nPos++);
                DescribeAColumn(T, "totadvance", "Tot. anticipo", nPos++);
                DescribeAColumn(T, "residual", "Residuo", nPos++);
                DescribeAColumn(T, "linkedsaldo", "Saldo contabilizzato", nPos++);
                DescribeAColumn(T, "linkedangir", "Ant. su part. giro contabilizzato", nPos++);
                DescribeAColumn(T, "linkedanpag", "Ant. su cap. bil. contabilizzato", nPos++);
 
			}
		}
	}
}
