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

namespace meta_clawbacksetupview//meta_automatismirecuperiview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_clawbacksetupview : Meta_easydata {
		public Meta_clawbacksetupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "clawbacksetupview") {		
			Name= "Imputazioni recuperi";
			ListingTypes.Add("lista");
		}
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "clawbackref", "Cod. recupero", nPos++);
                DescribeAColumn(T, "clawback", "Recupero", nPos++);
                DescribeAColumn(T, "codefin", "Voce bil. entrata", nPos++);
                DescribeAColumn(T, "finance", "Denom. bil. entrata", nPos++);
                DescribeAColumn(T, "finincometitle", "Denom. bil. entrata", nPos++);
                DescribeAColumn(T, "codefin_s", "Voce bil. spesa", nPos++);
                DescribeAColumn(T, "finance_s", "Denom. bil. spesa", nPos++);                
                DescribeAColumn(T, "codemotive", "Cod. Causale", nPos++);
                DescribeAColumn(T, "accmotive", "Causale", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica per debito", nPos++);
			}
		}
	}
}
