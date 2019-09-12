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

ï»¿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using metaeasylibrary;
using metadatalibrary;

namespace meta_pccpaymentview {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_pccpaymentview : Meta_easydata {
        public Meta_pccpaymentview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "pccpaymentview") {
            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                int nPos = 1;
                DescribeAColumn(T, "idpccpayment", "Num. Riga", nPos++);
                DescribeAColumn(T, "invoicekind", "Tipo documento", nPos++);
                DescribeAColumn(T, "yinv", "Esercizio", nPos++);
                DescribeAColumn(T, "ninv", "Numero", nPos++);
                DescribeAColumn(T, "mandatekind", "Tipo Contratto Passivo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                DescribeAColumn(T, "ycon", "Esercizio Cotratto Occasionale", nPos++);
                DescribeAColumn(T, "ncon", "Numero Contratto Occasionale", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "IdFiscaleIvaFornitore", "Id Fiscale Iva", nPos++);
                DescribeAColumn(T, "CFfornitore", "Codice Fiscale", nPos++);
                DescribeAColumn(T, "numerodocumento", "Numero documento", nPos++);
                DescribeAColumn(T, "dataemissione", "Data Emissione", nPos++);
                DescribeAColumn(T, "ImportoTotaleDocumento", "Importo Totale Documento", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo Pagato", nPos++);
                DescribeAColumn(T, "expensekind", "Natura di spesa", nPos++);                
                DescribeAColumn(T, "codefin", "Cod.Bilancio", nPos++);
                DescribeAColumn(T, "expensephase", "Fase spesa", nPos++);
                DescribeAColumn(T, "ymov", "Eserc.", nPos++);
                DescribeAColumn(T, "nmov", "Num.", nPos++);   
                DescribeAColumn(T, "npay", "Num.Mandato", nPos++);
                DescribeAColumn(T, "pettycash", "Fondo P.S.", nPos++);
                DescribeAColumn(T, "yoperation", "Eserc.Op.", nPos++);
                DescribeAColumn(T, "noperation", "Num.Op.", nPos++); 
                DescribeAColumn(T, "cigcode", "Codice CIG", nPos++);
                DescribeAColumn(T, "cupcode", "Codice CUP", nPos++);
            }
        }

    }
}