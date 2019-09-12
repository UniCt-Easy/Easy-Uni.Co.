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


namespace meta_provaaula
{
    public class Meta_provaaula : Meta_easydata 
	{
        public Meta_provaaula(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "provaaula") {
				Name = "Prove";
			EditTypes.Add("aula");
            ListingTypes.Add("aula");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "aula": {
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
				case "aula": {
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
						if (R["idlocation_aula"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Aula' è obbligatorio";
							errfield = "idlocation_aula";
							return false;
						}
						if (R["idprova"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Prova' è obbligatorio";
							errfield = "idprova";
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
				case "aula": {
						DescribeAColumn(T, "!idprova_prova_idprova", "Codice", nPos++);
						DescribeAColumn(T, "!idprova_prova_title", "Denominazione", nPos++);
						DescribeAColumn(T, "!idprova_prova_dataora", "Data e ora", nPos++);
						if (T.Columns.Contains("!idprova_prova_dataora")) T.Columns["!idprova_prova_dataora"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "!idprova_prova_idcommiss", "Commissione", nPos++);
						DescribeAColumn(T, "!idprova_prova_iddidprog", "Didattica programmata", nPos++);
						DescribeAColumn(T, "!idprova_prova_idquestionario", "Questionario", nPos++);
						DescribeAColumn(T, "!idprova_prova_idvalutazionekind", "Tipologia di valutazione", nPos++);
						DescribeAColumn(T, "!idprova_prova_programma", "Programma", nPos++);
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