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


namespace meta_location_aula
{
    public class Meta_location_aula : Meta_easydata 
	{
        public Meta_location_aula(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "location_aula") {
				Name = "Aula";
			EditTypes.Add("aula");
            ListingTypes.Add("aula");
            EditTypes.Add("aula_seg_child");
            ListingTypes.Add("aula_seg_child");
            //$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			switch (edit_type) {
				case "aula": {
						break;
					}
				case "aula_seg_child": {
						break;
					}
					//$SetDefault$
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			switch (edit_type) {
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
				case "aula": {
						DescribeAColumn(T, "capienza", "Capienza", nPos++);
						DescribeAColumn(T, "capienzadis", "Capienza disabili", nPos++);
						DescribeAColumn(T, "!idaulakind_aulakind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "!idaulakind_aulakind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "!idlocation_struttura_location_struttura_description", "Struttura di afferenza", nPos++);
						break;
					}
				case "aula_seg_child": {
						DescribeAColumn(T, "capienza", "Capienza", nPos++);
						DescribeAColumn(T, "capienzadis", "Capienza disabili", nPos++);
						DescribeAColumn(T, "!idaulakind_aulakind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "!idaulakind_aulakind_description", "Tipologia", nPos++);
						DescribeAColumn(T, "!idlocation_struttura_location_struttura_description", "Struttura di afferenza", nPos++);
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