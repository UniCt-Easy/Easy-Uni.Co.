
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
using System.Collections.Generic;
using System.Text;
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_authpaymentexpense {
    public class Meta_authpaymentexpense : Meta_easydata{
        public Meta_authpaymentexpense(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "authpaymentexpense") {
            EditTypes.Add("single");
            ListingTypes.Add("single");
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "single") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!ymov", "Esercizio", "expenseview.ymov",  nPos++);
                DescribeAColumn(T, "!nmov", "Numero", "expenseview.nmov", nPos++);
                DescribeAColumn(T, "!curramount", "Importo Corrente", "expenseview.curramount", nPos++);
                DescribeAColumn(T, "!netamount", "Importo Corrente", "expenseview.netamount", nPos++);
                DescribeAColumn(T, "!description", "Descrizione", "expenseview.description", nPos++);
            }
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Dettaglio dell'Autorizzazione al Pagamento";
                return GetFormByDllName("authpaymentexpense_single");
            }
            return null;
        }
    }
}
