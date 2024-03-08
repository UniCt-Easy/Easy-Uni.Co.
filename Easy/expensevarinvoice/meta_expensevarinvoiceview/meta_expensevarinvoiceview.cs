
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_expensevarinvoiceview{//meta_ivavarspesaview//
	/// <summary>
	/// Summary description for meta_ivavarspesaview
	/// </summary>
	public class Meta_expensevarinvoiceview : Meta_easydata {
		public Meta_expensevarinvoiceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "expensevarinvoiceview") {		
			ListingTypes.Add("default");
			Name="variazione movimento di spesa del documento IVA";
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");

				DescribeAColumn(T,"idinvkind","Codice tipo doc.",-1);
				DescribeAColumn(T,"invoicekind","Tipo doc.",2);
				DescribeAColumn(T,"yinv","Esercizio",3);
				DescribeAColumn(T,"ninv","Numero",4);
				DescribeAColumn(T,"movkind","Tipo movimento",6);
				DescribeAColumn(T,"phase","Fase",7);
				DescribeAColumn(T,"ymov","Eserc. mov.",8);
				DescribeAColumn(T,"nmov","Num. mov.",9);
				DescribeAColumn(T,"nvar","Num. variaz.",10);
				DescribeAColumn(T,"yvar","Eserc. variaz.",11);
				DescribeAColumn(T,"registry","Fornitore",12);
				DescribeAColumn(T,"description","Descrizione",13);
				DescribeAColumn(T,"amount","Importo",14);
				DescribeAColumn(T,"doc","Documento",15);
				DescribeAColumn(T,"docdate","Data doc.",16);
				DescribeAColumn(T,"adate","Data contabile",17);
			}
		}
	
	}
}
