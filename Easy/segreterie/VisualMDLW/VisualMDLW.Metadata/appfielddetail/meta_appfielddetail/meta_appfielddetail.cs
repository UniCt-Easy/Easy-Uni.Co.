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

ï»¿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_appfielddetail
{
    public class Meta_appfielddetail : Meta_easydata 
	{
        public Meta_appfielddetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "appfielddetail") {
				Name = "Campi della scheda";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idappfielddetail"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idappfielddetail"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//$IsValid$

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
						DescribeAColumn(T, "visible", "Inserito nella pagina di dettaglio", nPos++);
						DescribeAColumn(T, "!idapptab_apptab_title", "Tab", nPos++);
						DescribeAColumn(T, "position", "Posizione", nPos++);
						DescribeAColumn(T, "hidden", "Nascosto", nPos++);
						DescribeAColumn(T, "columnname", "Nome colonna", nPos++);
						DescribeAColumn(T, "defaultvalue", "Default Value", nPos++);
						DescribeAColumn(T, "title", "Nome alternativo", nPos++);
						DescribeAColumn(T, "isnullable", "Nullable", nPos++);
						DescribeAColumn(T, "radiovalues", "Valori (radio button)", nPos++);
						DescribeAColumn(T, "listtype", "Listtype (autochoose e select)", nPos++);
						DescribeAColumn(T, "uniqueonrow", "Disponi da solo sulla riga", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "hidden asc , idapptab desc, position desc, visible asc ";
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