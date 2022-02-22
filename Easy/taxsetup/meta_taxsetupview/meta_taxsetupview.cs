
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

namespace meta_taxsetupview//meta_automatismiritenuteview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_taxsetupview : Meta_easydata {
		public Meta_taxsetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "taxsetupview") {		
			Name= "Imputazione ritenute";
			ListingTypes.Add("lista");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "taxref", "Codice ritenuta", nPos++);
                DescribeAColumn(T, "taxkind", "Ritenuta", nPos++);
                DescribeAColumn(T, "paymentagencytitle", "Denom. ente versamento", nPos++);
                DescribeAColumn(T, "codefinincomeemploy", "Voce bil. applicazione ritenute", nPos++);
                DescribeAColumn(T, "finincomeemploy", "Denom. bil. applicazione ritenute", nPos++);
                DescribeAColumn(T, "codefinincomecontra", "Voce bil. applicazione contributi", nPos++);
                DescribeAColumn(T, "finincomecontra", "Denom. bil. applicazione contributi", nPos++);
                DescribeAColumn(T, "codefinadmintax", "Voce bil. contributi", nPos++);
                DescribeAColumn(T, "finadmintax", "Denom. bil. contributi", nPos++);
                DescribeAColumn(T, "codefinexpensecontra", "Voce bil. versamento", nPos++);
                DescribeAColumn(T, "finexpensecontra", "Denom. bil. versamento", nPos++);
                DescribeAColumn(T, "codefinexpenseemploy", "Voce bil. versamento ritenute", nPos++);
                DescribeAColumn(T, "finexpenseemploy", "Denom. bil. versamento ritenute", nPos++);
                DescribeAColumn(T, "idexpirationkind", "Period. (mesi)", nPos++);
                DescribeAColumn(T, "expiringday", "Giorno mese", nPos++);
                DescribeAColumn(T, "flagprevcurr", "Tipo periodo", nPos++);
			}
		}
	}
}
