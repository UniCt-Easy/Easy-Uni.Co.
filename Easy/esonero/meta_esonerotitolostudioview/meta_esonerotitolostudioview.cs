
/*
Easy
Copyright (C) 2021 UniversitÓ degli Studi di Catania (www.unict.it)
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


namespace meta_esonerotitolostudioview
{
    public class Meta_esonerotitolostudioview : Meta_easydata 
	{
        public Meta_esonerotitolostudioview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "esonerotitolostudioview") {
				Name = "Definizione degli esoneri per titoli di studio conseguiti";
			EditTypes.Add("titolostudio");
			ListingTypes.Add("titolostudio");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idesonero"};

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
				case "titolostudio": {
						DescribeAColumn(T, "aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "esonero_description", "Descrizione", nPos++);
						DescribeAColumn(T, "esonero_applunavolta", "Applicabile una sola volta", nPos++);
						DescribeAColumn(T, "costoscontodef_title", "Sconto", nPos++);
						DescribeAColumn(T, "esoneroanskind_title", "Tipologia Codice ANS", nPos++);
						DescribeAColumn(T, "esoneroanskind_description", "Descrizione Codice ANS", nPos++);
						DescribeAColumn(T, "esonero_retroattivo", "Retroattivo", nPos++);
						DescribeAColumn(T, "esonero_soloconisee", "Applicabile solo con ISEE", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_conseguitoincorso", "Conseguito in corso", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_dataconstutticf", "Data limite per aver conseguito tutti i crediti formativi", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_datalaurea", "Data limite di conseguimento del titolo", nPos++);
						DescribeAColumn(T, "struttura_title", "Struttura didattica", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_nellistituto", "Solo per corsi dell'istituto", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_noabbr", "Senza abbreviazioni di carriera", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_noparttime", "Senza aver effettuato iscrizioni part-time", nPos++);
						DescribeAColumn(T, "esonero_titolostudio_votomin", "Voto minimo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "titolostudio": {
						return "title asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
