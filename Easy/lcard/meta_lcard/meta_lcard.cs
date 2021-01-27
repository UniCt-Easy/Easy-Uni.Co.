
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;


namespace meta_lcard {
    class Meta_lcard : Meta_easydata {
        public Meta_lcard(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
           base(Conn, Dispatcher, "lcard") {
            EditTypes.Add("default");
            EditTypes.Add("web");
            ListingTypes.Add("default");
            ListingTypes.Add("ricarica");
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "ystart", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idlcard"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }
        protected override Form GetForm(string FormName){
            if (FormName == "web"){
                Name = "Card";
                DefaultListType = "default";
                return GetFormByDllName("lcard_web");
            }
            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            if (ListingType == "default" )
                return base.SelectOne(ListingType, filter, "lcardview", Exclude);
            return base.SelectOne(ListingType, filter, "lcard", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idstore"]) == 0){
                errmess = "Attenzione! Selezionare il Magazzino";
                errfield = "idstore";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idman"]) == 0){
                errmess = "Attenzione! Selezionare il Responsabile";
                errfield = "idman";
                return false;
            }


            return true;
        }

        
    }
}
