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


namespace meta_didprog
{
    public class Meta_didprog : Meta_easydata 
	{
        public Meta_didprog(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "didprog") {
				Name = "Didattiche programmate";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "default": {
						SetDefault(PrimaryTable, "freqobbl", "S");
						SetDefault(PrimaryTable, "iddidprognumchiusokind", "1");
						SetDefault(PrimaryTable, "iddidprogsuddannokind", "5");
						SetDefault(PrimaryTable, "iderogazkind", "1");
						SetDefault(PrimaryTable, "idnation_lang", "1");
						SetDefault(PrimaryTable, "idnation_langvis", "1");
						SetDefault(PrimaryTable, "idtitolokind", "1");
						SetDefault(PrimaryTable, "immatoltreauth", "S");
						SetDefault(PrimaryTable, "preimmatoltreauth", "S");
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["iddidprog"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["iddidprog"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["aa"].ToString().Trim().Length > 9) {
							errmess = "Attenzione! Il campo 'Anno accademico' può essere al massimo di 9 caratteri";
							errfield = "aa";
							return false;
						}
						if (R["codice"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "codice";
							return false;
						}
						if (R["codicemiur"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice MIUR' può essere al massimo di 50 caratteri";
							errfield = "codicemiur";
							return false;
						}
						if (R["idcorsostudio"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Corso di studi' è obbligatorio";
							errfield = "idcorsostudio";
							return false;
						}
						if (R["iddidprog"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "iddidprog";
							return false;
						}
						if (R["regolamentotaxurl"].ToString().Trim().Length > 512) {
							errmess = "Attenzione! Il campo 'Indirizzo WEB del regolamento delle tasse' può essere al massimo di 512 caratteri";
							errfield = "regolamentotaxurl";
							return false;
						}
						if (R["title"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 1024 caratteri";
							errfield = "title";
							return false;
						}
						if (R["title_en"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Denominazione (EN)' può essere al massimo di 1024 caratteri";
							errfield = "title_en";
							return false;
						}
						if (R["website"].ToString().Trim().Length > 512) {
							errmess = "Attenzione! Il campo 'Sito WEB del corso' può essere al massimo di 512 caratteri";
							errfield = "website";
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
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "!aa_annoaccademico_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "annosolare", "Anno solare", nPos++);
						DescribeAColumn(T, "!idcorsostudio_corsostudio_title", "Corso di studi", nPos++);
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