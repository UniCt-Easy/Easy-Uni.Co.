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

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_underwritingpayment {
    public class Meta_underwritingpayment : Meta_easydata {
        public Meta_underwritingpayment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "underwritingpayment") {
            EditTypes.Add("detail");
            EditTypes.Add("default");
            ListingTypes.Add("spesa");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "detail") {
                Name = "Finanziamento al movimento di spesa";
                return GetFormByDllName("underwritingpayment_detail");
            }
            if (FormName == "default")
            {
                string pagamento = Conn.DO_READ_VALUE("expensephase", QHS.CmpEq("nphase", GetSys("maxexpensephase")), "description").ToString();
                Name = "Finanziamento fase " + pagamento;
                DefaultListType = "default";
                return GetFormByDllName("underwritingpayment_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "spesa") {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "!codeunderwriting", "Codice Fin.", "underwriting.codeunderwriting");
                DescribeAColumn(T, "!underwriting", "Finanziamento", "underwriting.title");
                DescribeAColumn(T, "amount", "Importo");
            }
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "underwritingpaymentview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
    }
}
