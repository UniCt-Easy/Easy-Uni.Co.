
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace meta_electronicinvoiceview {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_electronicinvoiceview : Meta_easydata {
        public Meta_electronicinvoiceview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "electronicinvoiceview") {
            ListingTypes.Add("default");
            Name = "Fattura Elettronica";
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "default") {
                return "nelectronicinvoice DESC";
            }
            return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int pos = 1;
                DescribeAColumn(T, "nelectronicinvoice", "Numero", pos++);
                DescribeAColumn(T, "yelectronicinvoice", "Esercizio", pos++);
                DescribeAColumn(T, "departmentname_fe", "Cedente/Prestatore", pos++);
                DescribeAColumn(T, "registry", "Cliente", pos++);
                DescribeAColumn(T, "ipa_ven_emittente", "IPA Mittente", pos++);
                DescribeAColumn(T, "rifamm_ven_emittente", "Rif.Amm. Mittente", pos++);
                DescribeAColumn(T, "ipa_ven_cliente", "IPA Destinatario", pos++);
                DescribeAColumn(T, "rifamm_ven_cliente", "Rif.Amm. Destinatario", pos++);
            }
        }
    }
}
