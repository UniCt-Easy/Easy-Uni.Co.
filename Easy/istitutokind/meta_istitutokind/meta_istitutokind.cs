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


namespace meta_istitutokind
{
    public class Meta_istitutokind : Meta_easydata 
	{
        public Meta_istitutokind(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istitutokind") {
				Name = "Tipologia di istituto";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "default": {
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idistitutokind"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idistitutokind"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["idistitutokind"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idistitutokind";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lu' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["tipoistituto"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia' è obbligatorio";
							errfield = "tipoistituto";
							return false;
						}
						if (R["tipoistituto"].ToString().Trim().Length > 256) {
							errmess = "Attenzione! Il campo 'Tipologia' può essere al massimo di 256 caratteri";
							errfield = "tipoistituto";
							return false;
						}
						if (R["tipoistitutoen"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia (EN)' è obbligatorio";
							errfield = "tipoistitutoen";
							return false;
						}
						if (R["tipoistitutoen"].ToString().Trim().Length > 256) {
							errmess = "Attenzione! Il campo 'Tipologia (EN)' può essere al massimo di 256 caratteri";
							errfield = "tipoistitutoen";
							return false;
						}
						if (R["tipoistitutosigla"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Sigla' è obbligatorio";
							errfield = "tipoistitutosigla";
							return false;
						}
						if (R["tipoistitutosigla"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Sigla' può essere al massimo di 50 caratteri";
							errfield = "tipoistitutosigla";
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
						DescribeAColumn(T, "idistitutokind", "Codice", nPos++);
						DescribeAColumn(T, "tipoistituto", "Tipologia", nPos++);
						DescribeAColumn(T, "tipoistitutoen", "Tipologia (EN)", nPos++);
						DescribeAColumn(T, "tipoistitutosigla", "Sigla", nPos++);
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