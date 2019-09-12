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


namespace meta_istattitolistudio
{
    public class Meta_istattitolistudio : Meta_easydata 
	{
        public Meta_istattitolistudio(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "istattitolistudio") {
				Name = "Titoli di studio ISTAT";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "default": {
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idistattitolistudio"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idistattitolistudio"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "default": {
						if (R["codiceistitutogruppo"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice tipo di scuola/istituto, gruppo di corsi accademici' è obbligatorio";
							errfield = "codiceistitutogruppo";
							return false;
						}
						if (R["codiceistitutogruppo"].ToString().Trim().Length > 3) {
							errmess = "Attenzione! Il campo 'Codice tipo di scuola/istituto, gruppo di corsi accademici' può essere al massimo di 3 caratteri";
							errfield = "codiceistitutogruppo";
							return false;
						}
						if (R["codicelivello"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice livello' è obbligatorio";
							errfield = "codicelivello";
							return false;
						}
						if (R["codicespecializcorso"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice specializzazione scolastica/post-scolastica, corso accademico' è obbligatorio";
							errfield = "codicespecializcorso";
							return false;
						}
						if (R["codicespecializcorso"].ToString().Trim().Length > 3) {
							errmess = "Attenzione! Il campo 'Codice specializzazione scolastica/post-scolastica, corso accademico' può essere al massimo di 3 caratteri";
							errfield = "codicespecializcorso";
							return false;
						}
						if (R["idistattitolistudio"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Codice' è obbligatorio";
							errfield = "idistattitolistudio";
							return false;
						}
						if (R["isced97field"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'ISCED 97 - Field of study' è obbligatorio";
							errfield = "isced97field";
							return false;
						}
						if (R["isced97field"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ISCED 97 - Field of study' può essere al massimo di 50 caratteri";
							errfield = "isced97field";
							return false;
						}
						if (R["isced97level"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'ISCED 97 - Level and program destination' è obbligatorio";
							errfield = "isced97level";
							return false;
						}
						if (R["isced97level"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'ISCED 97 - Level and program destination' può essere al massimo di 50 caratteri";
							errfield = "isced97level";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lu' può essere al massimo di 64 caratteri";
							errfield = "lu";
							return false;
						}
						if (R["sinonimi"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Sinonimi' è obbligatorio";
							errfield = "sinonimi";
							return false;
						}
						if (R["sinonimi"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Sinonimi' può essere al massimo di 1024 caratteri";
							errfield = "sinonimi";
							return false;
						}
						if (R["tipo"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipo di scuola/istituto, Corso/classe di corsi accademici' è obbligatorio";
							errfield = "tipo";
							return false;
						}
						if (R["tipo"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Tipo di scuola/istituto, Corso/classe di corsi accademici' può essere al massimo di 1024 caratteri";
							errfield = "tipo";
							return false;
						}
						if (R["titolo"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Titolo di studio' è obbligatorio";
							errfield = "titolo";
							return false;
						}
						if (R["titolo"].ToString().Trim().Length > 1024) {
							errmess = "Attenzione! Il campo 'Titolo di studio' può essere al massimo di 1024 caratteri";
							errfield = "titolo";
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
						DescribeAColumn(T, "idistattitolistudio", "Codice", nPos++);
						DescribeAColumn(T, "titolo", "Titolo di studio", nPos++);
						DescribeAColumn(T, "tipo", "Tipo di scuola/istituto, Corso/classe di corsi accademici", nPos++);
						DescribeAColumn(T, "sinonimi", "Sinonimi", nPos++);
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