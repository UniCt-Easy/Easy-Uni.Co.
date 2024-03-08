
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_epupbkindview {
    public class Meta_epupbkindview : Meta_easydata {
        public Meta_epupbkindview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epupbkindview") {
            ListingTypes.Add("default");

        }

        private string[] mykey = new string[] {"idepupbkind", "ayear"};

        public override string[] primaryKey() {
            return mykey;
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            string basefilter = base.GetStaticFilter(ListingType);
            if (string.IsNullOrEmpty(basefilter))
                return filteresercizio;
            return QHS.AppAnd(basefilter, filteresercizio);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, ".idepupbkind", "#Tipo", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "title", "Tipo", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);

                DescribeAColumn(T, "codeacc_cost", "Codice conto Costo ", nPos++);
                DescribeAColumn(T, "account_cost", "Conto Costo", nPos++);

                DescribeAColumn(T, "codeacc_revenue", "Codice conto Ricavo", nPos++);
                DescribeAColumn(T, "account_revenue", "Conto Ricavo", nPos++);

                DescribeAColumn(T, "codeacc_deferredcost", "Codice  Conto Risconto Passivo", nPos++);
                DescribeAColumn(T, "account_deferredcost", "Conto Risconto Passivo", nPos++);

                DescribeAColumn(T, "codeacc_accruals", "Codice conto Rateo Attivo ", nPos++);
                DescribeAColumn(T, "acoount_accruals", "Conto Rateo Attivo", nPos++);

                DescribeAColumn(T, "codeacc_reserve", "Codice conto Riserva", nPos++);
                DescribeAColumn(T, "account_reserve", "Conto Riserva", nPos++);

                DescribeAColumn(T, "adjustmentkind", ".tipo assestamento", nPos++);
                DescribeAColumn(T, "adjustment", "Assestamento", nPos++);
                DescribeAColumn(T, "flag", ".flag", nPos++);
                DescribeAColumn(T, "considerapreimpegni", "Considera preimpegni", nPos++);
            }
        }
    }
}
