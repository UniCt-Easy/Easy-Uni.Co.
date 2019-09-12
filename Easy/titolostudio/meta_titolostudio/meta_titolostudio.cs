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


namespace meta_titolostudio
{
    public class Meta_titolostudio : Meta_easydata 
	{
        public Meta_titolostudio(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "titolostudio") {
				Name = "Titoli di studio";
			EditTypes.Add("docenti");
            ListingTypes.Add("docenti");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "docenti": {
						SetDefault(PrimaryTable, "conseguito", "N");
						SetDefault(PrimaryTable, "data", DateTime.Now);
						SetDefault(PrimaryTable, "votolode", "N");
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idtitolostudio"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idtitolostudio"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "docenti": {
						if (R["aa"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Anno accademco' è obbligatorio";
							errfield = "aa";
							return false;
						}
						if (R["aa"].ToString().Trim().Length > 9) {
							errmess = "Attenzione! Il campo 'Anno accademco' può essere al massimo di 9 caratteri";
							errfield = "aa";
							return false;
						}
						if (R["conseguito"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Conseguito' è obbligatorio";
							errfield = "conseguito";
							return false;
						}
						if (R["cu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Cu' può essere al massimo di 64 caratteri";
							errfield = "cu";
							return false;
						}
						if (R["data"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Data del conseguimento' è obbligatorio";
							errfield = "data";
							return false;
						}
						if (R["giudizio"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Giudizio' può essere al massimo di 50 caratteri";
							errfield = "giudizio";
							return false;
						}
						if (R["idistattitolistudio"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Titolo ISTAT' è obbligatorio";
							errfield = "idistattitolistudio";
							return false;
						}
						if (R["idreg_istituti"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Istituto' è obbligatorio";
							errfield = "idreg_istituti";
							return false;
						}
						if (R["idtitolostudio"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idtitolostudio";
							return false;
						}
						if (R["lu"].ToString().Trim().Length > 64) {
							errmess = "Attenzione! Il campo 'Lu' può essere al massimo di 64 caratteri";
							errfield = "lu";
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
				case "docenti": {
						DescribeAColumn(T, "!idistattitolistudio_istattitolistudio_titolo", "Titolo ISTAT", nPos++);
						DescribeAColumn(T, "voto", "Voto", nPos++);
						DescribeAColumn(T, "votosu", "Su", nPos++);
						DescribeAColumn(T, "votolode", "Lode", nPos++);
						DescribeAColumn(T, "!aa_annoaccademico_aa", "Anno accademco", nPos++);
						DescribeAColumn(T, "!idreg_istituti_registry_istituti_title", "Istituto", nPos++);
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