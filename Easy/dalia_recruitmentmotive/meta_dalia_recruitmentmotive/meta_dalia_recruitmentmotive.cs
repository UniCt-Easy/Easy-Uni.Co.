/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_dalia_recruitmentmotive  {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_dalia_recruitmentmotive  :Meta_easydata {
        public Meta_dalia_recruitmentmotive (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "dalia_recruitmentmotive ") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Causali assunzione";
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iddalia_recruitmentmotive "], null, null, 7);

            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "");
                }
                DescribeAColumn(T, "iddaliarecruitmentmotive", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
            }
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            return base.SelectOne(ListingType, filter, searchtable, Exclude);
        }


    }
}
