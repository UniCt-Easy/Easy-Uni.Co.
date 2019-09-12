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


namespace meta_affidamento
{
    public class Meta_affidamento : Meta_easydata 
	{
        public Meta_affidamento(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "affidamento") {
				Name = "Affidamento";
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
						SetDefault(PrimaryTable, "gratuito", "N");
						SetDefault(PrimaryTable, "lt", DateTime.Now);
						SetDefault(PrimaryTable, "riferimento", "N");
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idaffidamento"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idaffidamento"], 9990000);
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
						if (R["gratuito"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Gratuito' è obbligatorio";
							errfield = "gratuito";
							return false;
						}
						if (R["idaffidamento"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idaffidamento";
							return false;
						}
						if (R["idaffidamentokind"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia' è obbligatorio";
							errfield = "idaffidamentokind";
							return false;
						}
						if (R["idattivform"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idattivform";
							return false;
						}
						if (R["idcanale"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Canale' è obbligatorio";
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
						if (R["riferimento"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Docente di riferimento per il canale' è obbligatorio";
							errfield = "riferimento";
							return false;
						}
						if (R["urlcorso"].ToString().Trim().Length > 512) {
							errmess = "Attenzione! Il campo 'Indirizzo web del corso' può essere al massimo di 512 caratteri";
							errfield = "urlcorso";
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
						DescribeAColumn(T, "idaffidamento", "Codice", nPos++);
						DescribeAColumn(T, "freqobbl", "Frequenza obbligatoria", nPos++);
						DescribeAColumn(T, "gratuito", "Gratuito", nPos++);
						DescribeAColumn(T, "!idaffidamentokind_affidamentokind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "!idaffidamentokind_affidamentokind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "idcanale", "Canale", nPos++);
						DescribeAColumn(T, "!iderogazkind_erogazkind_title", "Tipo di erogazione", nPos++);
						DescribeAColumn(T, "!iderogazkind_erogazkind_description", "Tipo di erogazione", nPos++);
						DescribeAColumn(T, "!idreg_docenti_registry_docenti_title", "Docente", nPos++);
						DescribeAColumn(T, "orariric", "Orari di ricevimento", nPos++);
						DescribeAColumn(T, "orariric_en", "Oriari di ricevimento (EN)", nPos++);
						DescribeAColumn(T, "!paridaffidamento_affidamento_urlcorso", "Paridaffidamento", nPos++);
						DescribeAColumn(T, "prog", "Programma", nPos++);
						DescribeAColumn(T, "prog_en", "Programma (EN)", nPos++);
						DescribeAColumn(T, "riferimento", "Docente di riferimento per il canale", nPos++);
						DescribeAColumn(T, "start", "Inizio", nPos++);
						DescribeAColumn(T, "stop", "Fine", nPos++);
						DescribeAColumn(T, "testi", "Testi", nPos++);
						DescribeAColumn(T, "testi_en", "Testi (EN)", nPos++);
						DescribeAColumn(T, "urlcorso", "Indirizzo web del corso", nPos++);
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