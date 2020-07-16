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


namespace meta_ct_asscreddetail {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_ct_asscreddetail : Meta_easydata {
        public Meta_ct_asscreddetail(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "ct_asscreddetail") {
            EditTypes.Add("single");
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "single") {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("ct_asscreddetail_single");
            }
            if (FormName == "default") {
                Name = "Dettaglio Assegnazione Crediti";
                return MetaData.GetFormByDllName("ct_asscreddetail_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!bilanciospesa", "Codice bilancio spesa", "finspesa.codefin", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
                ComputeRowsAs(T, listtype);
            }
        }   

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R["idfin_expense"].ToString() == "") {
                errmess = "Inserire una voce bilancio di spesa.";
                errfield = null;
                return false;
            }
            if (R["quota"] == DBNull.Value) {
                errmess = "Attenzione! Inserire una percentuale.";
                errfield = "percentage";
                return false;
            }
            return true;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
                if (ListingType == "default")
                    return base.SelectOne(ListingType, filter, "ct_asscreddetailview", Exclude);
                else
                    return base.SelectOne(ListingType, filter, "ct_asscreddetail", Exclude);
        }
    }
}
