
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


namespace meta_rendicontlezionestuddefaultview
{
    public class Meta_rendicontlezionestuddefaultview : Meta_easydata 
	{
        public Meta_rendicontlezionestuddefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "rendicontlezionestuddefaultview") {
				Name = "Studenti della lezione";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"aa","idaffidamento","idattivform","idaula","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno","idedificio","idlezione","idreg_docenti","idreg_studenti","idsede"};

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
				case "default": {
						DescribeAColumn(T, "registry_studenti_studenti_authinps", "Autorizzazione all'istituto di accedere ai propri dati INPS", nPos++);
						DescribeAColumn(T, "rendicontlezionestud_assente", "Assente", nPos++);
						DescribeAColumn(T, "registry_studenti_studenti_idreg", "Codice Istituto", nPos++);
						DescribeAColumn(T, "registry_studenti_studenti_idstuddirittokind", "Tipologia per il diritto allo studio", nPos++);
						DescribeAColumn(T, "registry_studenti_title", "Denominazione", nPos++);
						DescribeAColumn(T, "rendicontlezionestud_ritardo", "Ritardo", nPos++);
						if (T.Columns.Contains("rendicontlezionestud_ritardo")) T.Columns["rendicontlezionestud_ritardo"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "registry_studenti_studenti_idstudprenotkind", "Tipologia per la prenotazione degli appelli", nPos++);
						DescribeAColumn(T, "registry_studenti_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "rendicontlezionestud_ritardogiustifica", "Giustificazione del ritardo", nPos++);
						DescribeAColumn(T, "registry_studenti_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "rendicontlezionestud_notadisciplinare", "Nota disciplinare", nPos++);
						DescribeAColumn(T, "registry_studenti_active", "attivo", nPos++);
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
