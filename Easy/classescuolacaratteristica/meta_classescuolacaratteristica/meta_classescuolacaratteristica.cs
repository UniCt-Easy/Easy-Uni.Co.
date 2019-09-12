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


namespace meta_classescuolacaratteristica
{
    public class Meta_classescuolacaratteristica : Meta_easydata 
	{
        public Meta_classescuolacaratteristica(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "classescuolacaratteristica") {
				Name = "Caratteristiche della scuola / classe di laurea";
			EditTypes.Add("classe");
            ListingTypes.Add("classe");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "classe": {
						SetDefault(PrimaryTable, "ct", DateTime.Now);
						SetDefault(PrimaryTable, "lt", DateTime.Now);
						SetDefault(PrimaryTable, "obblig", "N");
						SetDefault(PrimaryTable, "profess", "N");
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idclassescuolacaratteristica"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idclassescuolacaratteristica"], 9990000);
			//$Get_New_Row$

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
						if (R["idclassescuola"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Idclassescuola' è obbligatorio";
							errfield = "idclassescuola";
							return false;
						}
						if (R["idclassescuolacaratteristica"].ToString().Trim() == "") {
							errmess = "Attenzione! Il campo 'Identificativo' è obbligatorio";
							errfield = "idclassescuolacaratteristica";
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
						DescribeAColumn(T, "!idtipoattform_tipoattform_title", "Tipo di attività formativa", nPos++);
						DescribeAColumn(T, "!idtipoattform_tipoattform_description", "Tipo di attività formativa", nPos++);
						DescribeAColumn(T, "!idtipoattform_2_tipoattform_title", "Tipo della seconda attività formativa", nPos++);
						DescribeAColumn(T, "!idtipoattform_2_tipoattform_description", "Tipo della seconda attività formativa", nPos++);
						DescribeAColumn(T, "!idambitoareadisc_ambitoareadisc_title", "Ambito o area disciplinare", nPos++);
						DescribeAColumn(T, "!idsasd_sasd_title", "SASD", nPos++);
						DescribeAColumn(T, "cfmin", "Crediti min", nPos++);
						DescribeAColumn(T, "cf", "Crediti", nPos++);
						DescribeAColumn(T, "cfmax", "Crediti max", nPos++);
						DescribeAColumn(T, "obblig", "Obbligatorio", nPos++);
						DescribeAColumn(T, "profess", "Professionalizzante", nPos++);
						DescribeAColumn(T, "subambito", "Sotto-ambito", nPos++);
						break;
					}
				//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "classe": {
						return "idambitoareadisc desc, idsasd desc, idtipoattform desc";
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