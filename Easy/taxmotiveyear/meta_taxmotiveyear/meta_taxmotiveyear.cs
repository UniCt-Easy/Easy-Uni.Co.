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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_taxmotiveyear {
    public class Meta_taxmotiveyear : Meta_easydata {
        public Meta_taxmotiveyear(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "taxmotiveyear") {
            EditTypes.Add("single");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Associazione delle causali alla prestazione per la ritenuta in oggetto";
                return MetaData.GetFormByDllName("taxmotiveyear_single");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "!codeser","Cod.Prestazione" ,"service.codeser", nPos++);
                DescribeAColumn(T, "!service","Tipo Prestazione" ,"service.description", nPos++);
                DescribeAColumn(T, "!codemotive_cost", "Codice causale Costo", "accmotiveapplied_cost.codemotive", nPos++);
                DescribeAColumn(T, "!accmotive_cost", "Causale Costo", "accmotiveapplied_cost.motive", nPos++);
                DescribeAColumn(T, "!codemotive_debit", "Codice causale Debito", "accmotiveapplied.codemotive", nPos++);
                DescribeAColumn(T, "!accmotive_debit", "Causale Debito", "accmotiveapplied.motive", nPos++);
                DescribeAColumn(T, "!codemotive_pay", "Codice causale Liquidazione", "accmotiveapplied_pay.codemotive", nPos++);
                DescribeAColumn(T, "!accmotive_pay", "Causale Liquidazione", "accmotiveapplied_pay.motive", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            return true;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear",
                Conn.GetEsercizio());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idtaxmotiveyear"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

    }
}