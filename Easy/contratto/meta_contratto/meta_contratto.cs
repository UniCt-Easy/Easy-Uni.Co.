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


namespace meta_contratto
{
    public class Meta_contratto : Meta_easydata 
	{
        public Meta_contratto(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "contratto") {
				Name = "Contratti";
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
						SetDefault(PrimaryTable, "start", DateTime.Now);
						SetDefault(PrimaryTable, "tempdef", "N");
						SetDefault(PrimaryTable, "tempindet", "N");
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idcontratto"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idcontratto"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
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
						if (R["estremibando"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Estremi del bando di contratto' può essere al massimo di 50 caratteri";
							errfield = "estremibando";
							return false;
						}
						if (R["idcontratto"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idcontratto";
							return false;
						}
						if (R["idcontrattokind"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia di contratto' è obbligatorio";
							errfield = "idcontrattokind";
							return false;
						}
						if (R["idreg"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Docente' è obbligatorio";
							errfield = "idreg";
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
						if (R["start"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Inizio' è obbligatorio";
							errfield = "start";
							return false;
						}
						if (R["tempdef"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Part Time' è obbligatorio";
							errfield = "tempdef";
							return false;
						}
						if (R["tempindet"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tempo indeterminato' è obbligatorio";
							errfield = "tempindet";
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
						DescribeAColumn(T, "idcontratto", "Codice", nPos++);
						DescribeAColumn(T, "!idcontrattokind_contrattokind_title", "Tipologia di contratto", nPos++);
						DescribeAColumn(T, "!idcontrattokind_contrattokind_description", "Tipologia di contratto", nPos++);
						DescribeAColumn(T, "start", "Inizio", nPos++);
						DescribeAColumn(T, "stop", "Fine", nPos++);
						DescribeAColumn(T, "tempdef", "Part Time", nPos++);
						DescribeAColumn(T, "tempindet", "Tempo indeterminato", nPos++);
						DescribeAColumn(T, "estremibando", "Estremi del bando di contratto", nPos++);
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