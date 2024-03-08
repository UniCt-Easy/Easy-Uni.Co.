
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_invoiceexpavailable {
    class Meta_invoiceexpavailable : Meta_easydata {
        public Meta_invoiceexpavailable(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "invoiceexpavailable")  {
			Name= "Contabilizzazione Fattura d'Acquisto";
			ListingTypes.Add("default");
		}
	
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting = "invkind asc,yinv desc,ninv desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

        private string[] mykey = new string[] { "idinvkind", "yinv", "ninv" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {			
			base.DescribeColumns(T, ListingType);
			//			GetData.SetSorting(T,"yman desc,nman desc");
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
				DescribeAColumn(T, "invkind", "Tipo", nPos++);
                DescribeAColumn(T, "yinv", "Eserc.", nPos++);
                DescribeAColumn(T, "ninv", "Num.", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
				DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "taxabletotal", "Tot.Impon.", nPos++);
                DescribeAColumn(T, "detailtaxabletotal", "Tot.Impon.Cont.Dettagli", nPos++);
                DescribeAColumn(T, "ivatotal", "Tot.IVA", nPos++);
                DescribeAColumn(T, "detailivatotal", "Tot.Iva Cont.Dettagli", nPos++);
                DescribeAColumn(T, "linkedtotal", "Tot.Contabilizzato", nPos++);
                DescribeAColumn(T, "residual", "Tot.Residuo", nPos++);
			}
		}
    }
}
