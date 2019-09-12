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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_ccnl
{
    public class Meta_ccnl : Meta_easydata 
	{
        public Meta_ccnl(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "ccnl") {
				Name = "Contratti Collettivi Nazionali del Lavoro";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "default": {
						SetDefault(PrimaryTable, "ct", DateTime.Now);
						SetDefault(PrimaryTable, "lt", DateTime.Now);
						SetDefault(PrimaryTable, "stipula", DateTime.Now);
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idccnl"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idccnl"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R["area"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Area' è obbligatorio";
							errfield = "area";
							return false;
						}
						if (R["area"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Area' può essere al massimo di 50 caratteri";
							errfield = "area";
							return false;
						}
						if (R["contraenti"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Contraenti' è obbligatorio";
							errfield = "contraenti";
							return false;
						}
						if (R["contraenti"].ToString().Trim().Length > 1050) {
							errmess = "Attenzione! Il campo 'Contraenti' può essere al massimo di 1050 caratteri";
							errfield = "contraenti";
							return false;
						}
						if (R["ct"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Ct' è obbligatorio";
							errfield = "ct";
							return false;
						}
						if (R["cu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Cu' è obbligatorio";
							errfield = "cu";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Cu' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["idccnl"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idccnl";
							return false;
						}
						if (R["lt"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Lt' è obbligatorio";
							errfield = "lt";
							return false;
						}
						if (R["lu"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Lu' è obbligatorio";
							errfield = "lu";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lu' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["sortcode"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Ordinamento' è obbligatorio";
							errfield = "sortcode";
							return false;
						}
						if (R["stipula"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Stipula' è obbligatorio";
							errfield = "stipula";
							return false;
						}
						if (R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Title' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 150) {
							errmess = "Attenzione! Il campo 'Title' può essere al massimo di 150 caratteri";
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
						DescribeAColumn(T, "idccnl", "Codice", nPos++);
						DescribeAColumn(T, "title", "Title", nPos++);
						DescribeAColumn(T, "area", "Area", nPos++);
						DescribeAColumn(T, "sortcode", "Ordinamento", nPos++);
						DescribeAColumn(T, "active", "Attivo", nPos++);
						DescribeAColumn(T, "decorrenza", "Decorrenza", nPos++);
						DescribeAColumn(T, "scadec", "Scadenza ec.", nPos++);
						DescribeAColumn(T, "scadenza", "Scadenza", nPos++);
						DescribeAColumn(T, "stipula", "Stipula", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
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