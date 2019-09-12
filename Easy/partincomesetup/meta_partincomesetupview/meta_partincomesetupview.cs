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

namespace meta_partincomesetupview//meta_ripassegnazioneview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_partincomesetupview : Meta_easydata {
		public Meta_partincomesetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "partincomesetupview") {		
			Name= "ripartizione automatica entrate";
			ListingTypes.Add("lista");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				DescribeAColumn(T, "yfinincome", "Eserc. bil. entrata");
				DescribeAColumn(T, "finincomecode", "Voce bil. entrata");
				DescribeAColumn(T, "finincometitle", "Denom. bil. entrata");
				DescribeAColumn(T, "yfinexpense", "Eserc. bil. spesa");
				DescribeAColumn(T, "finexpensecode", "Voce bil. spesa");
				DescribeAColumn(T, "finexpensetitle", "Denom. bil. spesa");
				DescribeAColumn(T, "percentage", "Percentuale");
			}

		}
		public override string GetStaticFilter(string ListingType){
			string filteresercizio;
			if (ListingType=="lista"){
				filteresercizio = "(yfinincome='"+GetSys("esercizio").ToString()+"') AND (yfinexpense='"+GetSys("esercizio").ToString()+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
	}
}
