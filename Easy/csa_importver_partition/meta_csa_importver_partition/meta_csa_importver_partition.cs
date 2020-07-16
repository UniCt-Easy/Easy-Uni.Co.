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

﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_csa_importver_partition {
    /// <summary>
    /// </summary>
    public class Meta_csa_importver_partition :Meta_easydata {
        public Meta_csa_importver_partition(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "csa_importver_partition") {
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
                return MetaData.GetFormByDllName("csa_importver_partition_detail");
                }
            if (FormName == "elenco") {
                DefaultListType = "elenco";
                Name =  "Ripartizione unica righe di versamento";
                return MetaData.GetFormByDllName("csa_importver_partition_elenco");
            }
            return null;
            }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "elenco" ||ListingType == "recupero" || ListingType == "ritenuta" || ListingType == "contributo") {
                return base.SelectOne(ListingType, filter, "csa_importver_partitionview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
            }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_import");
            RowChange.SetSelector(T, "idver");
            RowChange.MarkAsAutoincrement(T.Columns["ndetail"], null, null, 6);
            RowChange.setMinimumTempValue(T.Columns["ndetail"], 9900000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
           
            }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            return true;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                    }
                int nPos = 1;
                DescribeAColumn(T, "ndetail", "#", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!phasemovfin", "Fase Mov. Fin.", "expenseview3.phase", nPos++);
                DescribeAColumn(T, "!ymov", "Eserc. Mov. Fin.", "expenseview3.ymov", nPos++);
                DescribeAColumn(T, "!nmov", "Num. Mov. Fin.", "expenseview3.nmov", nPos++);
                DescribeAColumn(T, "!phaseimpbudg", "Fase Imp. Budg.", "epexpview3.phase", nPos++);
                DescribeAColumn(T, "!yepexp", "Eserc. Imp.Budget", "epexpview3.yepexp", nPos++);
                DescribeAColumn(T, "!nepexp", "Num. Imp. Budget", "epexpview3.nepexp", nPos++);
                DescribeAColumn(T, "!codefin", "Cod. Bilancio", "fin2.codefin", nPos++);
                DescribeAColumn(T, "!codeupb", "Cod. UPB", "upb2.codeupb", nPos++);
                DescribeAColumn(T, "!codeacc", "Cod. Conto EP", "account2.codeacc", nPos++);
                DescribeAColumn(T, "!sortcode", "Cod. Class. Siope Spese", "sorting1.sortcode", nPos++);
            }

        }

        }

    }

