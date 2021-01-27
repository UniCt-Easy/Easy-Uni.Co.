
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_payment_bank {
	/// <summary>
	/// Summary description for Meta_payment_bank.
	/// </summary>
	public class Meta_payment_bank : Meta_easydata {
		public Meta_payment_bank(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payment_bank") {
			ListingTypes.Add("default");
			ListingTypes.Add("elenco");
			Name = "Movimento Bancario";
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "elenco" || ListingType == "default") {
				return base.SelectOne (ListingType, filter, "payment_bankview", ToMerge);
			}
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}
	}
}
