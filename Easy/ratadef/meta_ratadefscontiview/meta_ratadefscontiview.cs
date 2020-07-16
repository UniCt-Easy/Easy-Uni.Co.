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


namespace meta_ratadefscontiview
{
    public class Meta_ratadefscontiview : Meta_easydata 
	{
        public Meta_ratadefscontiview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "ratadefscontiview") {
				Name = "Rate";
			EditTypes.Add("sconti");
			ListingTypes.Add("sconti");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idcostoscontodef","idfasciaiseedef","idratadef"};

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
				case "sconti": {
						DescribeAColumn(T, "idratakind", "Tipologia", nPos++);
						DescribeAColumn(T, "ratadef_decorrenza", "Decorrenza", nPos++);
						if (T.Columns.Contains("ratadef_decorrenza")) T.Columns["ratadef_decorrenza"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "ratadef_scadenza", "Scadenza", nPos++);
						if (T.Columns.Contains("ratadef_scadenza")) T.Columns["ratadef_scadenza"].ExtendedProperties["format"] = "g";
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
