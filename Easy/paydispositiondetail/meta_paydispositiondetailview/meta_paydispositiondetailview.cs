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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
using funzioni_configurazione;

namespace meta_paydispositiondetailview {
    public class Meta_paydispositiondetailview : Meta_easydata {
        public Meta_paydispositiondetailview (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "paydispositiondetailview") {
            ListingTypes.Add("elenco");
 
        }

        public override string GetStaticFilter(string ListingType)
        {
            string filteresercizio;
            if (ListingType == "elenco")
            {
                filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }

        private string[] mykey = new string[] { "ayear", "idpaydisposition", "iddetail" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns (DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            int pos = 1;
            switch (ListingType) {
      
                case "elenco": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        pos = 1;
                        DescribeAColumn(T, "ayear", "Esercizio", pos++);
                        DescribeAColumn(T, "idpaydisposition", "N. Disposizione", pos++);
						DescribeAColumn(T, "npay", "Mandato singolo", pos++);
						DescribeAColumn(T, "iddetail", "Progressivo", pos++);
                        DescribeAColumn(T, "surname", "Cognome", pos++);
                        DescribeAColumn(T, "forename", "Nome", pos++);
                        DescribeAColumn(T, "title", "Denominazione", pos++);
                        DescribeAColumn(T, "cf", "Codice Fiscale", pos++);
                        DescribeAColumn(T, "p_iva", "Partita IVA", pos++);
                        DescribeAColumn(T, "amount", "Importo", pos++);
                        DescribeAColumn(T, "iban", "IBAN", pos++);
                        DescribeAColumn(T, "motive", "Causale", pos++);
                        DescribeAColumn(T, "email", "E-Mail", pos++);
						DescribeAColumn(T, "phase", "Fase Mov. Fin.", pos++);
						DescribeAColumn(T, "ymov", "Eserc. Mov. Fin.", pos++);
						DescribeAColumn(T, "nmov", "Num. Mov. Fin.", pos++);
						DescribeAColumn(T, "npaydett", "Mandato Mov. Fin.", pos++);
						DescribeAColumn(T, "paymentcode", "Cod. Pagamento", pos++);
                        DescribeAColumn(T, "flagtaxrefund", "Rimborso Spese", pos++);
                        DescribeAColumn(T, "academicyear", "Anno Accademico", pos++);
                        DescribeAColumn(T, "calendaryear", "Anno solare", pos++);
                        DescribeAColumn(T, "degreekind", "Tipologia corso", pos++);
                        DescribeAColumn(T, "degreecode", "Codice corso", pos++);
                        break;
                    }
            }
        }

      
    }
}
