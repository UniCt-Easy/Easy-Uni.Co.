
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_csa_contractkindrulesview {
	/// <summary>
	/// </summary>
	public class Meta_csa_contractkindrulesview : Meta_easydata {
		public Meta_csa_contractkindrulesview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "csa_contractkindrulesview")
        {
			ListingTypes.Add("search");
		}
		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="search") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T,"idcsa_rule", "#", nPos++);
                DescribeAColumn(T, "idcsa_contractkind", "#id Reola generale CSA", nPos++);
                DescribeAColumn(T, "contractkindcode", "Cod.REgola generale CSA", nPos++);
                DescribeAColumn(T,"ayear", "Esercizio", nPos++);
             	DescribeAColumn(T,"capitolocsa","Capitolo CSA",nPos++);
                DescribeAColumn(T,"ruolocsa", "Ruolo CSA", nPos++);
             }
		}

	}
}
