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


namespace meta_rendicontlezionestud
{
    public class Meta_rendicontlezionestud : Meta_easydata 
	{
        public Meta_rendicontlezionestud(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "rendicontlezionestud") {
				Name = "Studenti della lezione";
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
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["assente"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Assente' è obbligatorio";
							errfield = "assente";
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
						if (R["idreg_studenti"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Studente' è obbligatorio";
							errfield = "idreg_studenti";
							return false;
						}
						if (R["idrendicontlezione"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Registro della lezione' è obbligatorio";
							errfield = "idrendicontlezione";
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
						if (R["notadisciplinare"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Nota disciplinare' può essere al massimo di 1024 caratteri";
							errfield = "notadisciplinare";
							return false;
						}
						if (R["ritardogiustifica"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Giustificazione del ritardo' può essere al massimo di 1024 caratteri";
							errfield = "ritardogiustifica";
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
						DescribeAColumn(T, "idreg_studenti", "Studente", nPos++);
						DescribeAColumn(T, "assente", "Assente", nPos++);
						DescribeAColumn(T, "ritardo", "Ritardo", nPos++);
				T.Columns["ritardo"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "ritardogiustifica", "Giustificazione del ritardo", nPos++);
						DescribeAColumn(T, "notadisciplinare", "Nota disciplinare", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "idrendicontlezione     , notadisciplinare     , ritardo     ";
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