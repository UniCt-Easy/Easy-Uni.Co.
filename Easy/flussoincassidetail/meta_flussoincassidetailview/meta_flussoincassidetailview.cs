
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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_flussoincassidetailview {
    class Meta_flussoincassidetailview :Meta_easydata {
        public Meta_flussoincassidetailview(DataAccess Conn,
                MetaDataDispatcher Dispatcher) :
                base(Conn, Dispatcher, "flussoincassidetailview") {
            ListingTypes.Add("default");

        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idflusso desc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int pos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", pos++);
                DescribeAColumn(T, "iddetail", "n.dettaglio", pos++);
                DescribeAColumn(T, "dataincasso", "Data Incasso", pos++);
                DescribeAColumn(T, "dataesitopagamento", "Data Esito Pagamento", pos++);
                DescribeAColumn(T, "codiceflusso", "Codice Flusso", pos++);
                DescribeAColumn(T, "causale", "Causale", pos++);
                DescribeAColumn(T, "trn", "TRN", pos++);
                DescribeAColumn(T, "importotale", "Importo Totale", pos++);
                DescribeAColumn(T, "nbill", "N.Bolletta", pos++);
                DescribeAColumn(T, "iuv", "Codice IUV", pos++);
                DescribeAColumn(T, "iduniqueformcode", "Codice Bollettino", pos++);
                DescribeAColumn(T, "importo", "Importo", pos++);
                DescribeAColumn(T, "cf", "Codice Fiscale", pos++);
                DescribeAColumn(T, "p_iva", "P.Iva", pos++);
                DescribeAColumn(T, "active", "Attivo", pos++);
                DescribeAColumn(T, "elaborato", "Elaborato", pos++);

            }
        }
    }
}

