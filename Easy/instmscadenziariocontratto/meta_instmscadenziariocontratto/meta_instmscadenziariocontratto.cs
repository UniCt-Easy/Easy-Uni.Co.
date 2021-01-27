
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


namespace meta_instmscadenziariocontratto
{
    public class Meta_instmscadenziariocontratto : Meta_easydata 
	{
        public Meta_instmscadenziariocontratto(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "instmscadenziariocontratto") {
				Name = "Scadenziario Contratti";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("contratti");
			ListingTypes.Add("contratti");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idinstmscadenziariocontratto"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idinstmscadenziariocontratto"], 9990000);
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
						DescribeAColumn(T, "datafattura", "Data Fattura", nPos++);
						DescribeAColumn(T, "datascadenza", "Data Scadenza", nPos++);
						if (T.Columns.Contains("datascadenza")) T.Columns["datascadenza"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "!idinstmcontratto_instmcontratto_title", "Idinstmcontratto", nPos++);
						break;
					}
				case "contratti": {
						DescribeAColumn(T, "datafattura", "Data Fattura", nPos++);
						DescribeAColumn(T, "datascadenza", "Data Scadenza", nPos++);
						if (T.Columns.Contains("datascadenza")) T.Columns["datascadenza"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "!idinstmcontratto_instmcontratto_title", "Idinstmcontratto", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "default": {
						return "(idinstmcontratto in (select idinstmcontratto from instmcontratto where (idreg_instmuser_resp='" + security.GetUsr("idreg").ToString() + "'))";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
