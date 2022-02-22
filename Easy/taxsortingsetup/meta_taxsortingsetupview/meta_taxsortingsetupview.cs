
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

namespace meta_taxsortingsetupview {
	/// <summary>
	/// Summary description for Meta_taxsortingsetupview.
	/// </summary>
	public class Meta_taxsortingsetupview : Meta_easydata {
		public Meta_taxsortingsetupview (DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxsortingsetupview") {		
			ListingTypes.Add("default");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
                int nPos = 1;
                DescribeAColumn(T, "codeser", "Cod. Prestazione", nPos++);
				DescribeAColumn(T, "service", "Prestazione", nPos++);
				DescribeAColumn(T, "taxref", "Cod. ritenuta", nPos++);
				DescribeAColumn(T, "tax", "Ritenuta", nPos++);
				DescribeAColumn(T, "idsorkind", "Classificazione", nPos++);
				DescribeAColumn(T, "sortcode_employproc", "Codice Class. per Rev. c/Dip.", nPos++);
				DescribeAColumn(T, "sorting_employproc", "Class. per Rev. c/Dip.", nPos++);
				DescribeAColumn(T, "sortcode_adminproc", "Codice Class. per Rev. c/Amm.", nPos++);
				DescribeAColumn(T, "sorting_adminproc", "Class. per Rev. c/Amm.", nPos++);
				DescribeAColumn(T, "sortcode_adminpay", "Codice Class. per Mand. c/Amm.", nPos++);
				DescribeAColumn(T, "sorting_adminpay", "Class. per Mand. c/Amm.", nPos++);
                DescribeAColumn(T, "sortcode_employpay", "Codice Class. per Man. c/Dip.", nPos++);
                DescribeAColumn(T, "sorting_employpay", "Class. per Man.  c/Dip.", nPos++);
                DescribeAColumn(T, "sortcode_taxpay", "Codice Class. per Liquidazione", nPos++);
				DescribeAColumn(T, "sorting_taxpay", "Class. per Liquidazione", nPos++);
			}
		}
	}
}
