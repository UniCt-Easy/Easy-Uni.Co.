
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


namespace meta_costoscontodefdettaglioriepilogoview
{
    public class Meta_costoscontodefdettaglioriepilogoview : Meta_easydata 
	{
        public Meta_costoscontodefdettaglioriepilogoview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "costoscontodefdettaglioriepilogoview") {
				Name = "Voci di dettaglio costo";
			EditTypes.Add("riepilogo");
			ListingTypes.Add("riepilogo");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcostoscontodef","idcostoscontodefdettaglio","idfasciaiseedef","idratadef"};

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
				case "riepilogo": {
						DescribeAColumn(T, "costoscontodefdettagliokind_title", "Voce di dettaglio", nPos++);
						DescribeAColumn(T, "fasciaiseedef_idfasciaisee", "Fascia ISEE", nPos++);
						DescribeAColumn(T, "ratadef_idratakind", "Rata", nPos++);
						DescribeAColumn(T, "costoscontodefdettaglio_importo", "Importo", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_importo")) T.Columns["costoscontodefdettaglio_importo"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodefdettaglio_parama", "Parametro A", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_parama")) T.Columns["costoscontodefdettaglio_parama"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodefdettaglio_paramb", "Parametro B", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_paramb")) T.Columns["costoscontodefdettaglio_paramb"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodefdettaglio_paramc", "Parametro C", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_paramc")) T.Columns["costoscontodefdettaglio_paramc"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodefdettaglio_paramd", "Parametro D", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_paramd")) T.Columns["costoscontodefdettaglio_paramd"].ExtendedProperties["format"] = "fixed.2";
						DescribeAColumn(T, "costoscontodefdettaglio_percentuale", "Percentuale", nPos++);
						if (T.Columns.Contains("costoscontodefdettaglio_percentuale")) T.Columns["costoscontodefdettaglio_percentuale"].ExtendedProperties["format"] = "fixed.2";
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "riepilogo": {
						return "fasciaiseedef_idfasciaisee asc , ratadef_idratakind asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
