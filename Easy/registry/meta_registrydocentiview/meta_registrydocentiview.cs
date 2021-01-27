
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


namespace meta_registrydocentiview
{
    public class Meta_registrydocentiview : Meta_easydata 
	{
        public Meta_registrydocentiview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registrydocentiview") {
				Name = "Docenti";
			EditTypes.Add("docenti");
			ListingTypes.Add("docenti");
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
				case "docenti": {
						DescribeAColumn(T, "idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_active", "attivo", nPos++);
						DescribeAColumn(T, "registry_docenti_matricola", "Matricola", nPos++);
						DescribeAColumn(T, "sasd_codice", "Codice SASD", nPos++);
						DescribeAColumn(T, "sasd_title", "Settore Artistico Scientifico Disciplinare SASD", nPos++);
						DescribeAColumn(T, "struttura_title", "Denominazione Struttura di afferenza", nPos++);
						DescribeAColumn(T, "struttura_idstrutturakind", "Tipologia Struttura di afferenza", nPos++);
						DescribeAColumn(T, "registryistituti_title", "Istituto, Ente o Azienda", nPos++);
						DescribeAColumn(T, "classconsorsuale_title", "Classe consorsuale", nPos++);
						DescribeAColumn(T, "contrattokind_title", "Tipo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "docenti": {
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
