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


namespace meta_prova
{
    public class Meta_prova : Meta_easydata 
	{
        public Meta_prova(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "prova") {
				Name = "Prove d’esame";
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
			
			RowChange.MarkAsAutoincrement(T.Columns["idprova"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idprova"], 9990000);
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
						if (R["idprova"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
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
						if (R["title"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 50 caratteri";
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
				case "aula": {
						DescribeAColumn(T, "idprova", "Codice", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "dataora", "Data e ora", nPos++);
				T.Columns["dataora"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "!idcommiss_commiss_idcommiss", "Commissione", nPos++);
						DescribeAColumn(T, "!iddidprog_didprog_title", "Didattica programmata", nPos++);
						DescribeAColumn(T, "!idquestionario_questionario_title", "Questionario", nPos++);
						DescribeAColumn(T, "!idquestionario_questionario_description", "Questionario", nPos++);
						DescribeAColumn(T, "!idvalutazionekind_valutazionekind_title", "Tipologia di valutazione", nPos++);
						DescribeAColumn(T, "programma", "Programma", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "aula": {
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