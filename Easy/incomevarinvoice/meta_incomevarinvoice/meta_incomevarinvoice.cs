
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_incomevarinvoice{//meta_ivavarentrata//
	/// <summary>
	/// Summary description for meta_ivavarentrata
	/// </summary>
	public class Meta_incomevarinvoice : Meta_easydata {
		public Meta_incomevarinvoice(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomevarinvoice") {		
			ListingTypes.Add("default");
			Name="Variazione movimento di entrata del documento IVA";
		}
		
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "incomevarinvoiceview", ToMerge);

			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (R["idinvkind"].ToString()=="" ||
				R["yinv"].ToString()=="" ||
				R["ninv"].ToString()=="") {
				errfield=null;
				errmess="I campi relativi al documento IVA (tipo documento, "+
					"esercizio e numero documento) sono obbligatori.";
				return false;
			}

			if (!base.IsValid (R, out errmess, out errfield)) return false;

			return true;
		}
	}
}
