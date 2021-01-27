
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

namespace meta_dettliquidazioneivaview_debito{//meta_dettliquidazioneivaview_debito//
	/// <summary>
	/// Summary description for meta_dettliquidazioneivaview_debito
	/// </summary>
	public class Meta_dettliquidazioneivaview_debito : Meta_easydata {
		public Meta_dettliquidazioneivaview_debito(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "dettliquidazioneivaview_debito") {		
			ListingTypes.Add("liquidazione_debito");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="liquidazione_debito") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"codicetiporeg","Codice");
				DescribeAColumn(T,"descrizione","Descrizione");
				DescribeAColumn(T,"iva","IVA");
				FilterRows(T);
			}
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type=="liquidazione_debito") {
				if (R["registerclass"].ToString().ToUpper()=="V") return true;
				return false;
			}
			return true;
		}

	}
}
