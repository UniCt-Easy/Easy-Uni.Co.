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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_bankimport {
    public class Meta_bankimport : Meta_easydata {
        public Meta_bankimport(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "bankimport") {
                ListingTypes.Add("default");
                EditTypes.Add("default");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idbankimport"], null,
                null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
            SetDefault(PrimaryTable, "adate", DateTime.Now);
            object idbank = Conn.DO_READ_VALUE("treasurer",
                QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("flagdefault", "S")), "max(idbank)");
            SetDefault(PrimaryTable, "idbank", idbank);
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Importazione esiti e sospesi";
                return GetFormByDllName("bankimport_default");
            }
            return null;
        }
        public override string GetSorting(string ListingType) {
           if (ListingType=="default") return "adate desc";
           return base.GetSorting(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn c in T.Columns) {
                    DescribeAColumn(T, c.ColumnName, "", -1);
                }
                int pos = 0;
                DescribeAColumn(T, "idbankimport", "#",  pos++);
                DescribeAColumn(T, "idbank", "ABI Banca", pos++);
                DescribeAColumn(T, "adate", "Data importazione", pos++);
                DescribeAColumn(T, "ayear", ".Esercizio", pos++);
                DescribeAColumn(T, "lastpayment", "Ultimo pagamento", pos++);
                DescribeAColumn(T, "lastproceeds", "Ultimo incasso", pos++);
                DescribeAColumn(T, "lastbillexpense", "Ultimo sospeso uscita", pos++);
                DescribeAColumn(T, "lastbillincome", "Ultimo sospeso entrata", pos++);
                DescribeAColumn(T, "totalpayment", "Tot.pagamenti", pos++);
                DescribeAColumn(T, "totalproceeds", "Tot.incassi", pos++);
                DescribeAColumn(T, "totalbillexpense_plus", "Sospesi uscita (+)", pos++);
                DescribeAColumn(T, "totalbillexpense_minus", "Sospesi uscita (-)", pos++);
                DescribeAColumn(T, "totalbillincome_plus", "Sospesi entrata (+)", pos++);
                DescribeAColumn(T, "totalbillincome_minus", "Sospesi entrata (-)", pos++);
                DescribeAColumn(T, "identificativo_flusso_bt", "Identificativo flusso BT", pos++);
            }
        }

    }
}
