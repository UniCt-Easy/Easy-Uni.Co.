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

namespace meta_taxfinmotive {
    public class Meta_taxfinmotive : Meta_easydata {
        public Meta_taxfinmotive(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "taxfinmotive") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Associazione delle causali delle voci di bilancio alle prestazione";
                return MetaData.GetFormByDllName("taxfinmotive_single");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "!codeser", "Cod.Prestazione", "service1.codeser", nPos++);
                DescribeAColumn(T, "!service", "Tipo Prestazione", "service1.description", nPos++);
                DescribeAColumn(T, "!codemotive_incomeintra", "Cod.Causale entrata(contributi)", "finmotive_incomeintra.codemotive", nPos++);
                DescribeAColumn(T, "!finmotive_incomeintra", "Causale entrata(contributi)", "finmotive_incomeintra.title", nPos++);

                DescribeAColumn(T, "!codemotive_admintax", "Cod.Causale spesa(contributi)", "finmotive_admintax.codemotive", nPos++);
                DescribeAColumn(T, "!finmotive_admintax", "Causale spesa(contributi)", "finmotive_admintax.title", nPos++);

                DescribeAColumn(T, "!codemotive_expensecontra", "Cod.Causale spesa per Liq.(contributi)", "finmotive_expensecontra.codemotive", nPos++);
                DescribeAColumn(T, "!finmotive_expensecontra", "Causale spesa per Liq.(contributi)", "finmotive_expensecontra.title", nPos++);

                DescribeAColumn(T, "!codemotive_incomeemploy", "Cod.Causale entrata(ritenute)", "finmotive_incomeemploy.codemotive", nPos++);
                DescribeAColumn(T, "!finmotive_incomeemploy", "Causale entrata(ritenute)", "finmotive_incomeemploy.title", nPos++);

                DescribeAColumn(T, "!codemotive_expenseemploy", "Cod.Causale spesa per Liq.(ritenute)", "finmotive_expenseemploy.codemotive", nPos++);
                DescribeAColumn(T, "!finmotive_expenseemploy", "Causale spesa per Liq.(ritenute)", "finmotive_expenseemploy.title", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "taxcode");
            RowChange.SetSelector(T, "idser");
            return base.Get_New_Row(ParentRow, T);
        }

    }
}