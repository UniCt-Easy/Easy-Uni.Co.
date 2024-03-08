
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_pccexpiringview {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_pccexpiringview : Meta_easydata {
        public Meta_pccexpiringview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "pccexpiringview") {
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
                DescribeAColumn(T, "idpccexpiring", "Num.Riga", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "IDENTIFICATIVO_2_a", "IDENTIFICATIVO_2_a(IdSdi)", nPos++);
                DescribeAColumn(T, "IDENTIFICATIVO_2_b", "IDENTIFICATIVO_2_b(Num. FE)", nPos++);
                DescribeAColumn(T, "IDENTIFICATIVO_3_a", "IDENTIFICATIVO_3_a(data doc.)", nPos++);
                DescribeAColumn(T, "IDENTIFICATIVO_3_b", "IDENTIFICATIVO_3_b(CF)", nPos++);
                DescribeAColumn(T, "IDENTIFICATIVO_3_c", "IDENTIFICATIVO_3_c(ipa)", nPos++);
                //DescribeAColumn(T, "invrownum", "Num.Dett.Fattura", nPos++);
                //DescribeAColumn(T, "mandatekind", "Tipo Contratto Passivo", nPos++);
                //DescribeAColumn(T, "yman", "Esercizio", nPos++);
                //DescribeAColumn(T, "nman", "Numero", nPos++);
                //DescribeAColumn(T, "manrownum", "Num.Dett.ContrattoPassivo", nPos++);
                //DescribeAColumn(T, "ycon", "Esercizio Contratto Occasionale", nPos++);
                //DescribeAColumn(T, "ncon", "Numero Contratto Occasionale", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "IdFiscaleIvaFornitore", "Id Fiscale Iva", nPos++);
                DescribeAColumn(T, "CFfornitore", "Codice Fiscale", nPos++);
                DescribeAColumn(T, "numerodocumento", "Numero documento", nPos++);
                DescribeAColumn(T, "dataemissione", "Data Emissione", nPos++);
                DescribeAColumn(T, "ImportoTotaleDocumento", "Importo Totale Documento", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "expiringdate", "Data scadenza", nPos++);
            }
        }

    }
}
