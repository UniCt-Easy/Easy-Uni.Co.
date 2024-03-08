
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

namespace meta_webpayment_prenotazioniview
{
    /// <summary>
    /// Summary description for meta_webpayment_prenotazioniview
    /// </summary>
    public class Meta_webpayment_prenotazioniview : Meta_easydata
    {
        public Meta_webpayment_prenotazioniview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "webpayment_prenotazioniview")
        {
            Name = "Prenotazione Pagamenti";
            ListingTypes.Add("default");
            EditTypes.Add("default");
        }

        private string[] mykey = new string[] { "idwebpayment" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
            string sorting;
            if (ListingType == "default") {
                sorting = "idwebpayment asc";
                return sorting;
            }
            return base.GetSorting(ListingType);
        }
        
     

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);

            foreach (DataColumn C in T.Columns)
            {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }
            int nPos = 1;

            if (ListingType == "default")
            {
                DescribeAColumn(T, "idwebpayment", "Cod.Pagamento", nPos++);
                DescribeAColumn(T, "ywebpayment", "Esercizio", nPos++);
                DescribeAColumn(T, "nwebpayment", "Numero", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "webpaymentstatus", "Stato Corrente", nPos++);
                DescribeAColumn(T, "forename", "Nome", nPos++);
                DescribeAColumn(T, "surname", "Cognome", nPos++);
                DescribeAColumn(T, "registry", "Denominazione", nPos++);
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "email", "e-mail", nPos++);
                DescribeAColumn(T, "iuv", "IUV", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "p_iva", "p.iva", nPos++);
                DescribeAColumn(T, "idflussocrediti", "N° flusso cred.", nPos++);

            }
        }
    }
}
