/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_geo_nationdefaultview
{
    public class Meta_geo_nationdefaultview : Meta_easydata 
	{
        public Meta_geo_nationdefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_nationdefaultview") {
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		/// <summary>
		/// Impostare la chiave, serve per le viste, non per le tabelle!!
		/// </summary>
		//private string[] mykey = new string[] { "campo chiave" /*,...campi chiave*/ };
		//public override string[] primaryKey() {
		//    return mykey;
		//}

		private string[] mykey = new string[] {"idnation"};

		public override string[] primaryKey() {
			return mykey;
		}

		//protected override Form GetForm(string FormName) {
		//    //if (FormName == "default") {
		//    //    DefaultListType = "default";
		//    //    Name = "Descrizione Form";
		//    //    return MetaData.GetFormByDllName("geo_nationdefaultview_default");
		//    //}
		//    return null;
		//}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			//T.setMySelector("ntabella", "nphase", 0);  //campo nphase  è selettore per calcolo di ntabella
			//T.setMySelector("ntabella", "ytabella", 0);//campo ytabella  è selettore per calcolo di ntabella
			//T.setAutoincrement("ntabella", null, null, 0);  //ntabella è campo ad autoincremento
			//T.setAutoincrement("idtabella", null, null, 0);  //idtabella è campo ad autoincremento

			//T.setMinimumTempValue("idtabella", 999900000);     //Da impostare  in caso di pericolo di conflitto
			//$Get_New_Row$
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		/// <summary>
		/// FilterRow, si usa per i grid filtrati
		/// </summary>
		/// <param name="R"></param>
		/// <param name="list_type"></param>
		/// <returns></returns>
		//public override bool FilterRow(DataRow R, string list_type) {
			//if (list_type == "form_contenitore") {
			//    if (R["chiave contenitore"] == DBNull.Value) return false;
			//    return true;
			//}

			//return true;
		//}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				//$IsValid$
			}

			return true;
		}

		//public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			//if (ListingType == "lista")
			//    return base.SelectOne(ListingType, filter, "geo_nationdefaultviewview", Exclude);
			//else
			//return base.SelectOne(ListingType, filter, "geo_nationdefaultview", Exclude);
		//}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "geo_continent_title", "Continente", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "geo_nation_lang", "Lang", nPos++);
						DescribeAColumn(T, "geo_nation_newnation", "nazione in cui questa è confluita", nPos++);
						DescribeAColumn(T, "geo_nation_oldnation", "nazione da cui questa  è confluita", nPos++);
						DescribeAColumn(T, "geo_nation_start", "data inizio", nPos++);
						DescribeAColumn(T, "geo_nation_stop", "data fine", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "geo_continent_title desc, title desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
