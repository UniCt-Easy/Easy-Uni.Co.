/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace meta_creditpartview//meta_assegnazionecreditiview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_creditpartview : Meta_easydata {
		public Meta_creditpartview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "creditpartview") {		
			Name= "assegnazioni credito al bilancio";
			ListingTypes.Add("lista");
		}
        public override string GetSorting (string ListingType) {
            string sorting;
            if (ListingType == "lista") {
                sorting = "ycreditpart desc, ncreditpart desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        private string[] mykey = new string[] { "idinc", "ncreditpart" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
			    int pos = 1;
				DescribeAColumn(T, "phase", "Fase",pos++);
				DescribeAColumn(T, "ymov", "Eserc. mov.", pos++);
				DescribeAColumn(T, "nmov", "Num. mov.", pos++);
				DescribeAColumn(T, "ycreditpart", "Eserc. assegn.", pos++);
				DescribeAColumn(T, "ncreditpart", "Num. assegn.", pos++);
				DescribeAColumn(T, "codefin", "Bil. Spesa", pos++);
				DescribeAColumn(T, "finance", "Denom. bil", pos++);
                DescribeAColumn(T, "codeupb", "Cod. UPB", pos++);
                DescribeAColumn(T, "upb", "UPB", pos++);
                DescribeAColumn(T, "codeupb_income", "Cod. UPB movimento", pos++);
                DescribeAColumn(T, "upb_income", "UPB movimento", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
				DescribeAColumn(T, "amount", "Importo", pos++);
				DescribeAColumn(T, "financeincome","Bil. Entrata", pos++);
				DescribeAColumn(T, "adate", "Data cont.", pos++);
			}
		}
	}
}
