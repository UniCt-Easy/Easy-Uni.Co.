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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_epaccvar {
    /// <summary>
    /// Summary description for meta_epaccvar.
    /// </summary>
    /// 

    public class Meta_epaccvar : Meta_easydata {
        public Meta_epaccvar(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "epaccvar") {
            EditTypes.Add("default");
            EditTypes.Add("detail");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
            Name = "Variazione movimento Accertamento di Budget";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "lista";
                Name = "Variazione Accertamento di Budget";
                return GetFormByDllName("epaccvar_default");
            }
            if (FormName == "detail") {
                return MetaData.GetFormByDllName("epaccvar_detail");
            }
            return null;
        }


        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idepacc");
            RowChange.MarkAsAutoincrement(T.Columns["nvar"], null,
                null, 7);
            RowChange.setMinimumTempValue(T.Columns["nvar"], 99990000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "yvar", GetSys("esercizio"));

            SetDefault(T, "adate", GetSys("datacontabile"));
            SetDefault(T, "amount", 0);
            SetDefault(T, "amount2", 0);
            SetDefault(T, "amount3", 0);
            SetDefault(T, "amount4", 0);
            SetDefault(T, "amount5", 0);
        }
        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "",-1);
                int npos = 1;
                DescribeAColumn(T, "yvar", "Eserc. variaz.",npos++);
                DescribeAColumn(T, "nvar", "Num. variaz.",npos++);
                DescribeAColumn(T, "description", "Descrizione",npos++);
                DescribeAColumn(T, "amount", "Importo",npos++);
                int esercizio = Convert.ToInt32(GetSys("esercizio"));
                DescribeAColumn(T, "amount2", (++esercizio).ToString(), npos++);
                DescribeAColumn(T, "amount3", (++esercizio).ToString(), npos++);
                DescribeAColumn(T, "amount4", (++esercizio).ToString(), npos++);
                DescribeAColumn(T, "amount5", (++esercizio).ToString(), npos++);
                DescribeAColumn(T, "adate", "Data cont.",npos++);
            }

        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "default")
            {
                return base.SelectOne(ListingType, filter, "epaccvar", Exclude);
            }
            return base.SelectOne(ListingType, filter, "epaccvarview", Exclude);

        }	

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if (R["amount"] == DBNull.Value) {
                errmess = "E' necessario specificare l'importo della variazione";
                errfield = "amount";
                return false;
            }
            if (R["description"] == DBNull.Value) {
                errmess = "E' necessario inserire una descrizione";
                errfield = "description";
                return false;
            }
            return true;
        }
    }
}
