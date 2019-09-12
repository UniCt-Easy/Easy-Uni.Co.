/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;


namespace meta_invoiceavailable{//meta_documentoivaoperativo//
	/// <summary>
	/// Summary description for documentoivaoperativo.
	/// </summary>
	public class Meta_invoiceavailable : Meta_easydata {
		public Meta_invoiceavailable(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "invoiceavailable") {
			ListingTypes.Add("default");
			ListingTypes.Add("variazione");
		}

        private string[] mykey = new string[] { "idinvkind", "yinv", "ninv" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
                int nPos = 1;
				DescribeAColumn(T,"invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "flagbuysell", "Vendite/Acquisto", nPos++);
                DescribeAColumn(T, "flagvariation", "Nota variazione", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "registryreference", "Riferimento Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "paymentexpiring", "Scadenza", nPos++);
                DescribeAColumn(T, "idexpirationkind", "Tiposcadenza", nPos++);
                DescribeAColumn(T, "adate", "Data reg.", nPos++);
                DescribeAColumn(T, "packinglistnum", "Num. doc. trasp.", nPos++);
                DescribeAColumn(T, "packinglistdate", "Data doc. trasp.", nPos++);
                DescribeAColumn(T, "officiallyprinted", "Flag stampa", nPos++);
                DescribeAColumn(T, "taxabletotal", "Tot.Imponibile", nPos++);
                DescribeAColumn(T, "ivatotal", "Tot.IVA", nPos++);
                DescribeAColumn(T, "linkedamount", "Tot.Contabilizzato", nPos++);
                DescribeAColumn(T, "residual", "Tot.Residuo", nPos++);
			}

			if (ListingType=="variazione") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
                int nPos = 1;
                DescribeAColumn(T, "invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "registry", "Cliente/Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxabletotal", "Tot.Imponibile", nPos++);
                DescribeAColumn(T, "ivatotal", "Tot.IVA", nPos++);
                DescribeAColumn(T, "linkedamount", "Tot.Contabilizzato", nPos++);
                DescribeAColumn(T, "residual", "Tot.Residuo", nPos++);
			}
		}

	}
}