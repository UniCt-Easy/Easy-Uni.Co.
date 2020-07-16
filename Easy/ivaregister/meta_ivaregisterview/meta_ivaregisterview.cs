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

using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_ivaregisterview{//meta_registroivaview//
	/// <summary>
	/// Summary description for Meta_registroiva.
	/// </summary>
	public class Meta_ivaregisterview : Meta_easydata {

		public Meta_ivaregisterview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivaregisterview") {		
			ListingTypes.Add("default");
			ListingTypes.Add("documento");
			Name="Elenco registrazione documento IVA";
		}

		public override string GetSorting(string ListingType) {
			if (ListingType=="default")
				return "yivaregister DESC, idivaregisterkind ASC, nivaregister DESC";
			return base.GetSorting (ListingType);
		}

	
		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"idivaregisterkind",".#");
                DescribeAColumn(T,"codeivaregisterkind", "Codice tipo reg.");
				DescribeAColumn(T,"ivaregisterkind","Tipo reg.");
				DescribeAColumn(T,"yivaregister","Eserc. reg.");
				DescribeAColumn(T,"nivaregister","Numero reg.");
				DescribeAColumn(T,"invoicekind","Tipo documento");
				DescribeAColumn(T,"yinv","Eserc. doc.");
				DescribeAColumn(T,"ninv","Num. doc.");
				DescribeAColumn(T,"idivaoperation","Tipo operazione");
				DescribeAColumn(T,"flagdirect","Flag esig./detraib. immediata");
				DescribeAColumn(T,"flagdeferred","Flag esig./detraib. differita");
				DescribeAColumn(T,"registry","Versante/Percipiente");
				DescribeAColumn(T,"doc","Num. documento");
				DescribeAColumn(T,"docdate","Data documento");
				DescribeAColumn(T,"adate","Data reg.");
				DescribeAColumn(T,"protocolnum","Numero prot.");
			}

			if (ListingType=="documento") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"idinvoiceoperation","Codice operazione");
				DescribeAColumn(T,"idivaoperation","Operazione");
                DescribeAColumn(T, "idivaregisterkind", ".#");
                DescribeAColumn(T, "codeivaregisterkind", "Codice reg.");
				DescribeAColumn(T,"ivaregisterkind","Registrazione");
				DescribeAColumn(T,"flagdirect","Immediata");
				DescribeAColumn(T,"flagdeferred","Differita");
				DescribeAColumn(T,"adate","Data reg.");
				DescribeAColumn(T,"nivaregister","Numero reg.");
			}
		}
	}
}