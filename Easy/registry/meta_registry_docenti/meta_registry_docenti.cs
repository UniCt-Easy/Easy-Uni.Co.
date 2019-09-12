/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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


namespace meta_registry_docenti
{
    public class Meta_registry_docenti : Meta_easydata 
	{
        public Meta_registry_docenti(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registry_docenti") {
				Name = "Docenti";
			EditTypes.Add("docenti");
            ListingTypes.Add("docenti");
            //$EditTypes$
        }

		//$PrymaryKey$

				public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
		}


		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

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
				case "docenti": {
						DescribeAColumn(T, "matricola", "Matricola", nPos++);
						DescribeAColumn(T, "!idsasd_sasd_title", "SASD", nPos++);
						DescribeAColumn(T, "!idlocation_struttura_location_struttura_description", "Struttura di afferenza", nPos++);
						DescribeAColumn(T, "!idreg_istituti_registry_istituti_title", "Istituto, Ente o Azienda", nPos++);
						DescribeAColumn(T, "!idclassconsorsuale_classconsorsuale_title", "Classe consorsuale", nPos++);
						DescribeAColumn(T, "!idclassconsorsuale_classconsorsuale_description", "Classe consorsuale", nPos++);
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