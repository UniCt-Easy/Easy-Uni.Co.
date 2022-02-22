
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


using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_nso_vendita {
    public class Meta_nso_vendita : Meta_easydata {
        public Meta_nso_vendita(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "nso_vendita") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("iparifamm");
            ListingTypes.Add("ipa");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "NSO Ordine di Vendita";
                return MetaData.GetFormByDllName("nso_vendita_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "idnso_status", 1);
            SetDefault(PrimaryTable, "ec_sent", "N");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idnso_vendita"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "iparifamm")
                return base.SelectOne(ListingType, filter, "nso_venditaiparifammview", Exclude);

            if (ListingType == "ipa")
                return base.SelectOne(ListingType, filter, "nso_venditaipaview", Exclude);

            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "nso_venditaview", Exclude);
            return base.SelectOne(ListingType, filter, "nso_vendita", Exclude);
        }
    }
}
