
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace meta_istanzarin_segview
{
    public class Meta_istanzarin_segview : Meta_easydata 
	{
        public Meta_istanzarin_segview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istanzarin_segview") {
				Name = "Istanza di rinuncia agli studi";
			EditTypes.Add("rin_seg");
			ListingTypes.Add("rin_seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idistanza","idistanzakind","idreg_studenti"};

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
				case "rin_seg": {
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "istanza_data", "Data", nPos++);
						if (T.Columns.Contains("istanza_data")) T.Columns["istanza_data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "registry_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registrystudenti_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registryparent_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registrystudenti_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registryparent_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registrystudenti_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registryparent_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registrystudenti_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registryparent_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studentistudenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studentiparent_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "registry_studenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studentistudenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studentiparent_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studentistudenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studentiparent_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
