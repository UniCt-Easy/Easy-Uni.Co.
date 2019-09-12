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


namespace meta_publicaz
{
    public class Meta_publicaz : Meta_easydata 
	{
        public Meta_publicaz(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "publicaz") {
				Name = "Pubblicazione";
			EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("docenti");
            ListingTypes.Add("docenti");
            EditTypes.Add("instmuser");
			ListingTypes.Add("instmuser");
			//$EditTypes$
        }

		//$PrymaryKey$

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idpublicaz"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idpublicaz"], 9990000);
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
				case "default": {
						DescribeAColumn(T, "idpublicaz", "Codice Istituto", nPos++);
						DescribeAColumn(T, "title", "Titolo", nPos++);
						DescribeAColumn(T, "title2", "Sottotitolo", nPos++);
						DescribeAColumn(T, "annopub", "Anno pubblicazione", nPos++);
						DescribeAColumn(T, "editore", "Editore", nPos++);
						break;
					}
				case "docenti": {
						DescribeAColumn(T, "idpublicaz", "Codice Istituto", nPos++);
						DescribeAColumn(T, "title", "Titolo", nPos++);
						DescribeAColumn(T, "title2", "Sottotitolo", nPos++);
						DescribeAColumn(T, "annopub", "Anno pubblicazione", nPos++);
						DescribeAColumn(T, "editore", "Editore", nPos++);
						break;
					}
				case "instmuser": {
						DescribeAColumn(T, "title", "Titolo", nPos++);
						DescribeAColumn(T, "annopub", "Anno pubblicazione", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "default": {
						return "title desc, title2 desc";
					}
				case "docenti": {
						return "title desc, title2 desc";
					}
				case "instmuser": {
						return "title desc, title2 desc";
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