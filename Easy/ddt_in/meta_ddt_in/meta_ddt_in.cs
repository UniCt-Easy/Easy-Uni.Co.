
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_ddt_in
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_ddt_in : Meta_easydata
    {
        public Meta_ddt_in(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "ddt_in")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Bolla di Ingresso";
        }

        protected override Form GetForm(string FormName){
            DefaultListType = "default";
            if (FormName == "default") return MetaData.GetFormByDllName("ddt_in_default");
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "yddt_in", Conn.GetEsercizio());
            SetDefault(PrimaryTable, "adate", Conn.GetDataContabile().ToString());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idddt_in"], null, null, 0);
            //RowChange.MarkAsAutoincrement(T.Columns["nddt_in"], null, null, 0);
            //RowChange.SetMySelector(T.Columns["nddt_in"], "yddt_in", 0);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            return base.SelectOne(ListingType, filter, "ddt_inview", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32(R["idstore"]) == 0){
                errmess = "Il campo 'Magazzino' è obbligatorio";
                errfield = "idstore";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idddt_in_motive"]) == 0) {
                errmess = "Il campo 'Causale' è obbligatorio";
                errfield = "idddt_in_motive";
                return false;
            }
            return true;
        }


    }
}


