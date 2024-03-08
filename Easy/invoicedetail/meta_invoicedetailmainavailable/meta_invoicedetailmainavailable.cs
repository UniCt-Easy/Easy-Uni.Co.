
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
using metaeasylibrary;
using metadatalibrary;


namespace meta_invoicedetailmainavailable {



	public class Meta_invoicedetailmainavailable : Meta_easydata {
		public Meta_invoicedetailmainavailable(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "invoicedetailmainavailable") {
			ListingTypes.Add("default");
			Name = "Dettaglio Fattura Riferimento";
		}


		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
				int nPos = 1;
				DescribeAColumn(T, "idinvkind", ".idinvkind", nPos++);
				DescribeAColumn(T, "invoicekind", "Tipo Documento", nPos++);
				DescribeAColumn(T, "yinv", "Eserc.", nPos++);
				DescribeAColumn(T, "ninv", "Num.", nPos++);
				DescribeAColumn(T, "rownum", "N.riga", nPos++);
				DescribeAColumn(T, "invidgroup", ".", nPos++);
				DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
				DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
				DescribeAColumn(T, "taxable", "Imponibile", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
				DescribeAColumn(T, "invoiced", "Fatturata", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["invoiced"], "n");

				DescribeAColumn(T, "linked", "Collegata", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["linked"], "n");

				DescribeAColumn(T, "residual", "Da collegare", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["residual"], "n");

			}
		}


	}
}


