
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace meta_registrypaymethodview{//meta_modpagamentocreddebianagview//
	/// <summary>
	/// Summary description for Meta_modpagamentocreddebianagview.
	/// </summary>
	public class Meta_registrypaymethodview : Meta_easydata {
		public Meta_registrypaymethodview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registrypaymethodview") {
			ListingTypes.Add("modpaganagrafica");
			Name = "";
		}
        private string[] mykey = new string[] { "idreg","idregistrypaymethod" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="modpaganagrafica") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
				DescribeAColumn(T,"regmodcode","Nome modalità", nPos++);
                DescribeAColumn(T, "registry", "Denom. Anagrafica", nPos++);
                DescribeAColumn(T, "paymethod", "Modalità pagamento", nPos++);
                DescribeAColumn(T, "iban", "IBAN", nPos++);
                DescribeAColumn(T, "cin", "Cin", nPos++);
                DescribeAColumn(T, "idbank", "Cod. ABI", nPos++);
                DescribeAColumn(T, "banktitle", "Banca", nPos++);
                DescribeAColumn(T, "idcab", "CAB", nPos++);
                DescribeAColumn(T, "cabtitle", "Sportello", nPos++);
                DescribeAColumn(T, "cc", "Conto", nPos++);
                DescribeAColumn(T, "currency", "Valuta", nPos++);
                DescribeAColumn(T, "paymentdescr", "Desc. pag.", nPos++);
                DescribeAColumn(T, "paymentexpiring", "Scad. pag.", nPos++);
                DescribeAColumn(T, "idexpirationkind", "Tipo scad.", nPos++);
                DescribeAColumn(T, "flagstandard", "Flag standard", nPos++);
                DescribeAColumn(T, "active", "Flag attivo", nPos++);
                DescribeAColumn(T, "extracode", "Codice contabilità speciale", nPos++);
			}
		}   
	}
}

