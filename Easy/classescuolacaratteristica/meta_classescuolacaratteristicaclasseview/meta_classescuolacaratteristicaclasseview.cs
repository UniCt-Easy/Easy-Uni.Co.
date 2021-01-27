
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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


namespace meta_classescuolacaratteristicaclasseview
{
    public class Meta_classescuolacaratteristicaclasseview : Meta_easydata 
	{
        public Meta_classescuolacaratteristicaclasseview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "classescuolacaratteristicaclasseview") {
				Name = "Caratteristiche della scuola / classe di laurea";
			EditTypes.Add("classe");
            ListingTypes.Add("classe");
            //$EditTypes$
        }

		private string[] mykey = new string[] {"idcaratteristica","idclassescuola"};

		public override string[] primaryKey() {
			return mykey;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
				case "classe": {
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
						if (R["idtipoattform"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Tipo di attività formativa' è obbligatorio";
							errfield = "idtipoattform";
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
						if (R["obblig"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Obbligatorio' è obbligatorio";
							errfield = "obblig";
							return false;
						}
						if (R["profess"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Professionalizzante' è obbligatorio";
							errfield = "profess";
							return false;
						}
						if (R["subambito"].ToString().Trim().Length > 50) {
							errmess = "Attenzione! Il campo 'Sotto-ambito' può essere al massimo di 50 caratteri";
							errfield = "subambito";
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
				case "classe": {
						DescribeAColumn(T, "tipoattform_title", "Tipo di attività formativa", nPos++);
						DescribeAColumn(T, "idtipoattform", "Tipo di attività formativa", nPos++);
						DescribeAColumn(T, "tipoattform_2_title", "Tipo della seconda attività formativa", nPos++);
						DescribeAColumn(T, "idtipoattform_2", "Tipo della seconda attività formativa", nPos++);
						DescribeAColumn(T, "ambitoareadisc_title", "Ambito o area disciplinare", nPos++);
						DescribeAColumn(T, "idambitoareadisc", "Ambito o area disciplinare", nPos++);
						DescribeAColumn(T, "caratteristica_subambito", "Sotto-ambito", nPos++);
						DescribeAColumn(T, "sasd_title", "SASD", nPos++);
						DescribeAColumn(T, "idsasd", "SASD", nPos++);
						DescribeAColumn(T, "caratteristica_cfmin", "Crediti min", nPos++);
						DescribeAColumn(T, "caratteristica_cfmax", "Crediti max", nPos++);
						DescribeAColumn(T, "caratteristica_cf", "Crediti", nPos++);
						DescribeAColumn(T, "caratteristica_obblig", "Obbligatorio", nPos++);
						DescribeAColumn(T, "caratteristica_profess", "Professionalizzante", nPos++);
						DescribeAColumn(T, "idcaratteristica", "Identificativo", nPos++);
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
