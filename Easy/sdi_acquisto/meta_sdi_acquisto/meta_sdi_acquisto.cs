
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_sdi_acquisto {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_sdi_acquisto : Meta_easydata {
        public Meta_sdi_acquisto(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "sdi_acquisto") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("iparifamm");
            ListingTypes.Add("ipa");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Fattura Elettronica-Acquisto";
                return GetFormByDllName("sdi_acquisto_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "idsdi_status", 1);
            SetDefault(PrimaryTable, "ec_sent", "N");
            SetDefault(PrimaryTable, "notcreacontabilita", "N"); 
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idsdi_acquisto"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "iparifamm")
                return base.SelectOne(ListingType, filter, "sdi_acquistoiparifammview", Exclude);

            if (ListingType == "ipa")
                return base.SelectOne(ListingType, filter, "sdi_acquistoipaview", Exclude);
            
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "sdi_acquistoview", Exclude);
            return base.SelectOne(ListingType, filter, "sdi_acquisto", Exclude);
        }

        
    }
}
