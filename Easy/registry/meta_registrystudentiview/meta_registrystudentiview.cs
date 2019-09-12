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


namespace meta_registrystudentiview
{
    public class Meta_registrystudentiview : Meta_easydata 
	{
        public Meta_registrystudentiview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registrystudentiview") {
				Name = "Studenti";
			EditTypes.Add("studenti");
            ListingTypes.Add("studenti");
            //$EditTypes$
        }

		private string[] mykey = new string[] {"idreg"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

									if (R.Table.Columns.Contains("active") && R["active"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'attivo' è obbligatorio";
							errfield = "active";
							return false;
						}
						if (R.Table.Columns.Contains("annotation") && R["annotation"].ToString().Trim().Length > 400) {
							errmess = "Attenzione! Il campo 'Annotazioni' può essere al massimo di 400 caratteri";
							errfield = "annotation";
							return false;
						}
						if (R.Table.Columns.Contains("badgecode") && R["badgecode"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Codice badge' può essere al massimo di 20 caratteri";
							errfield = "badgecode";
							return false;
						}
						if (R.Table.Columns.Contains("birthdate") && R["birthdate"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Data di nascita' è obbligatorio";
							errfield = "birthdate";
							return false;
						}
						if (R.Table.Columns.Contains("cf") && R["cf"].ToString().Trim().Length > 16) {
							errmess = "Attenzione! Il campo 'Codice fiscale' può essere al massimo di 16 caratteri";
							errfield = "cf";
							return false;
						}
						if (R.Table.Columns.Contains("extmatricula") && R["extmatricula"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Matricola' può essere al massimo di 40 caratteri";
							errfield = "extmatricula";
							return false;
						}
						if (R.Table.Columns.Contains("foreigncf") && R["foreigncf"].ToString().Trim().Length > 40) {
							errmess = "Attenzione! Il campo 'Codice fiscale estero' può essere al massimo di 40 caratteri";
							errfield = "foreigncf";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nome' è obbligatorio";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("forename") && R["forename"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Nome' può essere al massimo di 50 caratteri";
							errfield = "forename";
							return false;
						}
						if (R.Table.Columns.Contains("gender") && R["gender"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Sesso (M/F)' è obbligatorio";
							errfield = "gender";
							return false;
						}
						if (R.Table.Columns.Contains("idcity") && R["idcity"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Comune di nascita' è obbligatorio";
							errfield = "idcity";
							return false;
						}
						if (R.Table.Columns.Contains("idmaritalstatus") && R["idmaritalstatus"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Stato civile' può essere al massimo di 20 caratteri";
							errfield = "idmaritalstatus";
							return false;
						}
						if (R.Table.Columns.Contains("idnation") && R["idnation"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Nazionalità' è obbligatorio";
							errfield = "idnation";
							return false;
						}
						if (R.Table.Columns.Contains("idregistryclass") && R["idregistryclass"].ToString().Trim().Length > 2) {
							errmess = "Attenzione! Il campo 'Tipologia fiscale' può essere al massimo di 2 caratteri";
							errfield = "idregistryclass";
							return false;
						}
						if (R.Table.Columns.Contains("idtitle") && R["idtitle"].ToString().Trim().Length > 20) {
							errmess = "Attenzione! Il campo 'Titolo' può essere al massimo di 20 caratteri";
							errfield = "idtitle";
							return false;
						}
						if (R.Table.Columns.Contains("location") && R["location"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ubicazione' può essere al massimo di 50 caratteri";
							errfield = "location";
							return false;
						}
						if (R.Table.Columns.Contains("maritalsurname") && R["maritalsurname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome acquisito' può essere al massimo di 50 caratteri";
							errfield = "maritalsurname";
							return false;
						}
						if (R.Table.Columns.Contains("p_iva") && R["p_iva"].ToString().Trim().Length > 15) {
							errmess = "Attenzione! Il campo 'Partita iva' può essere al massimo di 15 caratteri";
							errfield = "p_iva";
							return false;
						}
						if (R.Table.Columns.Contains("residence") && R["residence"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Residenza' è obbligatorio";
							errfield = "residence";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Cognome' è obbligatorio";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("surname") && R["surname"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Cognome' può essere al massimo di 50 caratteri";
							errfield = "surname";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Denominazione' è obbligatorio";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("title") && R["title"].ToString().Trim().Length > 100) {
							errmess = "Attenzione! Il campo 'Denominazione' può essere al massimo di 100 caratteri";
							errfield = "title";
							return false;
						}
						if (R.Table.Columns.Contains("authinps") && R["authinps"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Autorizzazione all'istituto di accedere ai propri dati INPS' è obbligatorio";
							errfield = "authinps";
							return false;
						}
						if (R.Table.Columns.Contains("idstudprenotkind") && R["idstudprenotkind"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipologia per la prenotazione degli appelli' è obbligatorio";
							errfield = "idstudprenotkind";
							return false;
						}
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
				case "studenti": {
						DescribeAColumn(T, "idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studenti_idreg", "Codice Istituto", nPos++);
						DescribeAColumn(T, "studdirittokind_title", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "studprenotkind_title", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "studprenotkind_description", "Tipologia per la prenotazione degli appelli", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "studenti": {
						return "studprenotkind_title desc";
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