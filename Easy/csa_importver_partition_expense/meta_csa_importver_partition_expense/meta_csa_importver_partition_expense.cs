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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_importver_partition_expense {
    /// <summary>
    /// </summary>
    public class Meta_csa_importver_partition_expense :Meta_easydata {
        public Meta_csa_importver_partition_expense(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importver_partition_expense") {
            EditTypes.Add("detail");
            EditTypes.Add("elenco");
            ListingTypes.Add("default");
            ListingTypes.Add("elenco");
            ListingTypes.Add("ritenuta");
            ListingTypes.Add("contributo");
            ListingTypes.Add("recupero");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "detail") {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("csa_importver_partition_expense_detail");
                }
            if (FormName == "elenco") {
                DefaultListType = "elenco";
                Name = "Movimenti Spesa Generati (Ripartizione Versamenti)";
                return MetaData.GetFormByDllName("csa_importver_partition_expense_elenco");
            }
            return null;
            }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "elenco" || ListingType == "recupero" || ListingType == "ritenuta" || ListingType == "contributo") {
                return base.SelectOne(ListingType, filter, "csa_importver_partition_expenseview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
            }

        //public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
        //    RowChange.SetSelector(T, "idcsa_import");
        //    RowChange.SetSelector(T, "idriep");
        //    RowChange.MarkAsAutoincrement(T.Columns["ndetail"], null, null, 6);
        //    DataRow R = base.Get_New_Row(ParentRow, T);
        //    return R;
        //}

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                int nPos = 1;
                DescribeAColumn(T, "ndetail", "#", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!phase", "Fase Mov. Fin.", "expenseview4.phase", nPos++);
                DescribeAColumn(T, "!ymov", "Eserc. Mov. Fin.", "expenseview4.ymov", nPos++);
                DescribeAColumn(T, "!nmov", "Num. Mov. Fin.", "expenseview4.nmov", nPos++);
            }
            }

        }

    }

