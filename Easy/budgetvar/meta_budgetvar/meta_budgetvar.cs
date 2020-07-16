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
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_budgetvar {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_budgetvar : Meta_easydata {
        public Meta_budgetvar(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "budgetvar") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("documentocollegato");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Variazione";
                return GetFormByDllName("budgetvar_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "ybudgetvar", GetSys("esercizio"));
            string filter = QHS.CmpEq("ayear",GetSys("esercizio"));
            //vedere se si deve aggiungere eventualmente un nuovo campo in config
            //usiamo lo stesso flag delle variazioni bilancio almeno per il momento 
            object budgetvarofficial_default = Conn.DO_READ_VALUE("config", filter, "finvarofficial_default");
            SetDefault(PrimaryTable, "official", budgetvarofficial_default);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "ybudgetvar");
            RowChange.MarkAsAutoincrement(T.Columns["nbudgetvar"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
           
            return R;
        }

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default"||ListingType == "documentocollegato") return base.SelectOne(ListingType, filter, "budgetvarview", Exclude);
            return base.SelectOne(ListingType, filter, "budgetvar", Exclude);
        }	

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
     
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R.RowState == DataRowState.Modified && R["official"].ToString() == "S" && R["nofficial"] == DBNull.Value){
                errmess = "Attenzione! Inserire un numero ufficiale per la variazione";
                errfield = "nofficial";
                return false;
            }
            return true;
        }

    }
}