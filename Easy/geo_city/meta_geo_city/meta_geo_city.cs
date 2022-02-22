
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


using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
//$CustomUsing$


namespace meta_geo_city
{
	public class Meta_geo_city : Meta_easydata
	{
		public Meta_geo_city(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "geo_city") {
			Name = "Comuni";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			EditTypes.Add("segchild");
			ListingTypes.Add("segchild");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idcity"], null, null, 7);
			RowChange.setMinimumTempValue(T.Columns["idcity"], 9990000);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "idcity", "Codice", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!idcountry_geo_country_title", "id paese (tabella geo_country)", nPos++);
						DescribeAColumn(T, "!newcity_geo_city_title", "id nuovo comune in cui questo è eventualmente confluito, se valorizzato questo comune non ? pi? valido", nPos++);
						DescribeAColumn(T, "!oldcity_geo_city_title", "id comune da cui questo è confluito", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
				case "seg": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!idcountry_geo_country_title", "Provincia", nPos++);
						DescribeAColumn(T, "!newcity_geo_city_title", "Nuovo comune in cui questo è confluito", nPos++);
						DescribeAColumn(T, "!oldcity_geo_city_title", "id comune da cui questo è confluito", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
				case "segchild": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!newcity_geo_city_title", "Nuovo comune in cui questo è confluito", nPos++);
						DescribeAColumn(T, "!oldcity_geo_city_title", "id comune da cui questo è confluito", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "title";
					}
				case "seg": {
						return "title desc";
					}
				case "segchild": {
						return "title desc";
					}
					//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				return MetaData.GetFormByDllName("geo_city_default");//PinoRana
			}
			return null;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "default")
				return base.SelectOne(ListingType, filter, "geo_cityview", ToMerge);

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}
	}
}
