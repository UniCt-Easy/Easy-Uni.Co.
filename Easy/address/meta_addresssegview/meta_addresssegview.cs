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


namespace meta_addresssegview
{
    public class Meta_addresssegview : Meta_easydata 
	{
        public Meta_addresssegview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "addresssegview") {
				Name = "Tipologia di indirizzo";
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idaddress"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

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
				case "seg": {
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {
			switch (ListingType) {
				case "seg": {
						return "description asc ";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "seg": {
						return "active = 'S'";
						break;
					}
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}