
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

namespace meta_admpay_appropriationview {
	/// <summary>
	/// Summary description for Meta_admpay_appropriationview.
	/// </summary>
	public class Meta_admpay_appropriationview : Meta_easydata {
		public Meta_admpay_appropriationview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay_appropriationview") {	
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yadmpay", "Eserc. Pag. Stip.", nPos++);
				DescribeAColumn(T, "nadmpay", "Num. Pag. Stip.", nPos++);
				DescribeAColumn(T, "nappropriation", "Num. Impegnativa", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "available", "Disponibile", nPos++);
				DescribeAColumn(T, "codefin", "Cod. Bilancio", nPos++);
				DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
				DescribeAColumn(T, "phase", "Fase", nPos++);
				DescribeAColumn(T, "ymov", "Eserc. Mov", nPos++);
				DescribeAColumn(T, "nmov", "Num. Mov.", nPos++);
			}
		}
	}
}
