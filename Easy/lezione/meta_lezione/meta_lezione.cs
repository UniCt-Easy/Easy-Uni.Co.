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


namespace meta_lezione
{
    public class Meta_lezione : Meta_easydata 
	{
        public Meta_lezione(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "lezione") {
				Name = "Lezioni";
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
						SetDefault(PrimaryTable, "stop", DateTime.Now);
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idlezione"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idlezione"], 9990000);
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
						if (R["idaffidamento"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Affidamento' è obbligatorio";
							errfield = "idaffidamento";
							return false;
						}
						if (R["idattivform"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idattivform";
							return false;
						}
						if (R["idcanale"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idcanale";
							return false;
						}
						if (R["iddidprog"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidprog";
							return false;
						}
						if (R["iddidproganno"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidproganno";
							return false;
						}
						if (R["iddidprogcurr"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidprogcurr";
							return false;
						}
						if (R["iddidprogori"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidprogori";
							return false;
						}
						if (R["iddidprogporzanno"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidprogporzanno";
							return false;
						}
						if (R["idlezione"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idlezione";
							return false;
						}
						if (R["idlocation_aula"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Aula' è obbligatorio";
							errfield = "idlocation_aula";
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
							errmess = "Attenzione! Il campo 'Data e ora inizio' è obbligatorio";
							errfield = "start";
							return false;
						}
						if (R["stop"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Data e ora fine' è obbligatorio";
							errfield = "stop";
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
						DescribeAColumn(T, "idaffidamento", "Affidamento", nPos++);
						DescribeAColumn(T, "!idlocation_aula_location_aula_description", "Aula", nPos++);
						DescribeAColumn(T, "!idlocation_aula_location_aula_locationcode", "Aula", nPos++);
						DescribeAColumn(T, "start", "Data e ora inizio", nPos++);
				T.Columns["start"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "stop", "Data e ora fine", nPos++);
				T.Columns["stop"].ExtendedProperties["format"] = "g";
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