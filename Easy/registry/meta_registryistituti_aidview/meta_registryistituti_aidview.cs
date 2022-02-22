
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace meta_registryistituti_aidview
{
    public class Meta_registryistituti_aidview : Meta_easydata 
	{
        public Meta_registryistituti_aidview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryistituti_aidview") {
				Name = "Agensia Industria e Difesa";
			EditTypes.Add("istituti_aid");
			ListingTypes.Add("istituti_aid");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idreg"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "istituti_aid": {
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_annotation", "Annotazioni", nPos++);
						DescribeAColumn(T, "registry_authorization_free", "Esente ai fini dell'autorizzazione EQUITALIA. (S/N)", nPos++);
						DescribeAColumn(T, "registry_badgecode", "Codice badge", nPos++);
						DescribeAColumn(T, "registry_birthdate", "Data di nascita", nPos++);
						DescribeAColumn(T, "registry_ccp", "Conto corrente postale di Riscossione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_email_fe", "Email_fe", nPos++);
						DescribeAColumn(T, "registry_extmatricula", "Matricola", nPos++);
						DescribeAColumn(T, "registry_flag_pa", "Applica lo split payment  (per le fatture di vendita)", nPos++);
						DescribeAColumn(T, "registry_flagbankitaliaproceeds", "Regolarizzazione Riscossioni presso  T.P.S. - Banca d'Italia", nPos++);
						DescribeAColumn(T, "registry_foreigncf", "Codice fiscale estero", nPos++);
						DescribeAColumn(T, "registry_forename", "Nome", nPos++);
						DescribeAColumn(T, "registry_gender", "Sesso (M/F)", nPos++);
						DescribeAColumn(T, "category_description", "ID Categoria (tabella category)", nPos++);
						DescribeAColumn(T, "centralizedcategory_description", "ID Classificazione centralizzata anagrafica (tabella centralizedcategory)", nPos++);
						DescribeAColumn(T, "geo_city_title", "id città (tabella geo_city)", nPos++);
						DescribeAColumn(T, "registry_idexternal", "Id chiave in altri database, usato in migrazioni o simili", nPos++);
						DescribeAColumn(T, "maritalstatus_description", "ID Stato civile (tabella maritalstatus)", nPos++);
						DescribeAColumn(T, "geo_nation_title", "Id nazione (tabella geo_nation)", nPos++);
						DescribeAColumn(T, "registryclass_description", "ID Tipologie classificazione (tabella registryclass)", nPos++);
						DescribeAColumn(T, "registrykind_description", "ID Classificazione Anagrafica (tabella registrykind)", nPos++);
						DescribeAColumn(T, "title_description", "ID Titolo (tabella title)", nPos++);
						DescribeAColumn(T, "registry_ipa_fe", "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito www.indicepa.gov.it.", nPos++);
						DescribeAColumn(T, "registry_location", "ubicazione", nPos++);
						DescribeAColumn(T, "registry_maritalsurname", "Cognome acquisito", nPos++);
						DescribeAColumn(T, "registry_multi_cf", "Consenti duplicazione CF/P. IVA (S/N)", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_pec_fe", "Pec_fe", nPos++);
						DescribeAColumn(T, "residence_description", "Tipo residenza (chiave di tabella residence)", nPos++);
						DescribeAColumn(T, "registry_rtf", "allegati", nPos++);
						DescribeAColumn(T, "registry_sdi_defrifamm", "Rif.Amministrazione di default per fattura elettronica", nPos++);
						DescribeAColumn(T, "registry_sdi_norifamm", "Consenti al fornitore di non specificare il riferimento amministrativo in fatt.elettronica", nPos++);
						DescribeAColumn(T, "registry_surname", "Cognome", nPos++);
						DescribeAColumn(T, "registry_toredirect", "E' stato usato in qualche migrazione", nPos++);
						DescribeAColumn(T, "registry_txt", "note testuali", nPos++);
						DescribeAColumn(T, "registry_istituti_comune", "Comune", nPos++);
						DescribeAColumn(T, "registry_istituti_nome", "Denominazione breve", nPos++);
						DescribeAColumn(T, "registry_istituti_sortcode", "Sortcode", nPos++);
						DescribeAColumn(T, "registry_istituti_title_en", "Denominazione (ENG)", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "istituti_aid": {
						return "registry_istituti_sortcode";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "istituti_aid": {
						return "idreg = (SELECT top(1) idreg from istitutoprinc)";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
