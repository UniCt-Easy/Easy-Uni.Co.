
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_mandatedetailavailable//meta_dettordinegenericooperativo//
{
	/// <summary>
	/// Summary description for Meta_dettordinegenericooperativo.
	/// </summary>
	public class Meta_mandatedetailavailable : Meta_easydata {
		public Meta_mandatedetailavailable(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatedetailavailable") {
			Name= "riga contratto passivo";
			ListingTypes.Add("dettaglio");
		}
		
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="dettaglio") {
				sorting = "mankind asc,yman desc,nman desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "idmankind", "yman", "nman", "idgroup" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T, "mankind","Tipo",1);
				DescribeAColumn(T, "yman","Esercizio",2);
				DescribeAColumn(T, "nman","Numero",3);
				DescribeAColumn(T, "idgroup","Gruppo",4);
				DescribeAColumn(T, "registry", "Fornitore",5);
				DescribeAColumn(T, "detaildescription", "Descrizione",6);
				DescribeAColumn(T, "ordered", "Q.tà ordinata",7);
				DescribeAColumn(T, "residual", "Residuo",8);
                DescribeAColumn(T, "locationcode", "Codice Ubicazione", 9);
                DescribeAColumn(T, "location", "Descrizione", 10);
                HelpForm.SetFormatForColumn(T.Columns["ordered"], "n");
				HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
			}
		}   
	}
}
