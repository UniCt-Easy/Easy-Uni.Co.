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

using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_geo_nation
{
    public class Meta_geo_nation : Meta_easydata 
	{
        public Meta_geo_nation(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "geo_nation") {
				Name = "Nazioni";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("lingue");
            ListingTypes.Add("lingue");
            EditTypes.Add("seg");
            ListingTypes.Add("seg");
            EditTypes.Add("segchild");
            ListingTypes.Add("segchild");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "default": {
						break;
					}
				case "lingue": {
						break;
					}
				case "seg": {
						break;
					}
				case "segchild": {
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idnation"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idnation"], 9990000);
			//$Get_New_Row$
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["lang"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lang' può essere al massimo di 64 caratteri";
							errfield = "lang";
							return false;
						}
						if (R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 65) {
							errmess = "Attenzione! Il campo 'Nazione' può essere al massimo di 65 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "lingue": {
						if (R["lang"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lingua' può essere al massimo di 64 caratteri";
							errfield = "lang";
							return false;
						}
						if (R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 65) {
							errmess = "Attenzione! Il campo 'Nazione' può essere al massimo di 65 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "seg": {
						if (R["lang"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lingua' può essere al massimo di 64 caratteri";
							errfield = "lang";
							return false;
						}
						if (R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 65) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 65 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				case "segchild": {
						if (R["lang"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lingua' può essere al massimo di 64 caratteri";
							errfield = "lang";
							return false;
						}
						if (R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'nome ultimo utente modifica' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 65) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 65 caratteri";
							errfield = "title";
							return false;
						}
						break;
					}
				//$IsValid$
			}

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "start", "Inizio validità", nPos++);
						DescribeAColumn(T, "stop", "Fine validità", nPos++);
						DescribeAColumn(T, "title", "Nazione", nPos++);
						break;
					}
				case "lingue": {
						DescribeAColumn(T, "lang", "Lingua", nPos++);
						break;
					}
				case "seg": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!idcontinent_geo_continent_title", "Continente", nPos++);
						DescribeAColumn(T, "lang", "Lingua", nPos++);
						DescribeAColumn(T, "!newnation_geo_nation_title", "nazione in cui questa è confluita", nPos++);
						DescribeAColumn(T, "!oldnation_geo_nation_title", "nazione da cui questa  è confluita", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
				case "segchild": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "lang", "Lingua", nPos++);
						DescribeAColumn(T, "!newnation_geo_nation_title", "nazione in cui questa è confluita", nPos++);
						DescribeAColumn(T, "!oldnation_geo_nation_title", "nazione da cui questa  è confluita", nPos++);
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
						return "title desc";
					}
				case "segchild": {
						return "title desc";
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