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


namespace meta_corsostudio
{
    public class Meta_corsostudio : Meta_easydata 
	{
        public Meta_corsostudio(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "corsostudio") {
				Name = "Corsi di studio";
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
			
			RowChange.MarkAsAutoincrement(T.Columns["idcorsostudio"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idcorsostudio"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["codice"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice' può essere al massimo di 50 caratteri";
							errfield = "codice";
							return false;
						}
						if (R["codicemiur"].ToString().Trim().Length > 10) {
							errmess = "Attenzione! Il campo 'Codice MIUR' può essere al massimo di 10 caratteri";
							errfield = "codicemiur";
							return false;
						}
						if (R["codicemiurlungo"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Codice MIUR lungo' può essere al massimo di 50 caratteri";
							errfield = "codicemiurlungo";
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
						if (R["idcorsostudio"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idcorsostudio";
							return false;
						}
						if (R["idcorsostudiokind"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia' è obbligatorio";
							errfield = "idcorsostudiokind";
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
						DescribeAColumn(T, "title_en", "Denominazione (EN)", nPos++);
						DescribeAColumn(T, "codice", "Codice", nPos++);
						DescribeAColumn(T, "codicemiur", "Codice MIUR", nPos++);
						DescribeAColumn(T, "codicemiurlungo", "Codice MIUR lungo", nPos++);
						DescribeAColumn(T, "!idcorsostudiokind_corsostudiokind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "!idcorsostudiokind_corsostudiokind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "!idlocation_struttura_location_struttura_description", "Struttura di riferimento", nPos++);
						DescribeAColumn(T, "crediti", "Crediti", nPos++);
						DescribeAColumn(T, "durata", "Durata", nPos++);
						DescribeAColumn(T, "!idduratakind_duratakind_title", "Tipologia della durata", nPos++);
						DescribeAColumn(T, "!idcorsostudionorma_corsostudionorma_title", "Normativa di riferimento", nPos++);
						DescribeAColumn(T, "!idcorsostudiolivello_corsostudiolivello_title", "Livello", nPos++);
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