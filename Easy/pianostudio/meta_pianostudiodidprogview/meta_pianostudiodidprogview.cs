
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
//$CustomUsing$


namespace meta_pianostudiodidprogview
{
    public class Meta_pianostudiodidprogview : Meta_easydata 
	{
        public Meta_pianostudiodidprogview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "pianostudiodidprogview") {
				Name = "Piani di studio";
			EditTypes.Add("didprog");
			ListingTypes.Add("didprog");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcorsostudio","iddidprog","idiscrizione","idpianostudio","idreg"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "didprog": {
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "pianostudiostatus_title", "Status", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "didprog": {
						return "aa desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
