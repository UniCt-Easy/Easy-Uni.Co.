/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_instmcontrattoafferenteview
{
    public class Meta_instmcontrattoafferenteview : Meta_easydata 
	{
        public Meta_instmcontrattoafferenteview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "instmcontrattoafferenteview") {
				Name = "Contratti";
			EditTypes.Add("afferente");
			ListingTypes.Add("afferente");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idinstmcontratto"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

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
				case "afferente": {
						DescribeAColumn(T, "title", "Titolo della Prestazione", nPos++);
						DescribeAColumn(T, "instmcontratto_datafine", "Data Fine Contratto", nPos++);
						DescribeAColumn(T, "instmcontratto_datainizio", "Data Inizio Contratto", nPos++);
						DescribeAColumn(T, "registry_instmuser_title", "Afferente", nPos++);
						DescribeAColumn(T, "registry_instmuser_resp_title", "Responsabile", nPos++);
						DescribeAColumn(T, "instmcontratto_importolordo", "Importo Lordo", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "afferente": {
						return "title desc";
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