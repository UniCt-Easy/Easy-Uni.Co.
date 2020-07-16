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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_webpayment_prenotazioniview
{
    /// <summary>
    /// Summary description for meta_documentoivaview
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
                DescribeAColumn(T, "webpaymentstatus", "Stato Corrente", nPos++);
                DescribeAColumn(T, "nome", "Nome", nPos++);
                DescribeAColumn(T, "cognome", "Cognome", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                DescribeAColumn(T, "email", "e-mail", nPos++);
                DescribeAColumn(T, "p_iva", "p.iva", nPos++);
                DescribeAColumn(T, "cf", "CF", nPos++);
                DescribeAColumn(T, "adate", "Data", nPos++);
                DescribeAColumn(T, "annotations", "Annotazioni", nPos++);
                DescribeAColumn(T, "idinvkind", "idinvkind", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio Competenza", nPos++);
                DescribeAColumn(T, "competencystop", "Fine Competenza", nPos++);
                DescribeAColumn(T, "idreg", "Cod.Anagrafica", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "intcode", "Codice listino", nPos++);
                DescribeAColumn(T, "codelistclass", "Codice class.merc.", nPos++);
                DescribeAColumn(T, "listclass", "Class. Merc.", nPos++);
                DescribeAColumn(T, "number", "quantità", nPos++);
                DescribeAColumn(T, "price", "prezzo", nPos++);
            }
        }
    }
}
