
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


using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_purchase {

    public class Meta_purchase : Meta_easydata {

        public Meta_purchase(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "purchase") {
            ListingTypes.Add("default");
            EditTypes.Add("default");
        }

        protected override Form GetForm(string EditType) {
            if (EditType == "default") {
                DefaultListType = "default";
                Name = "Vendita sul portale";
                return GetFormByDllName("purchase_default");
            }

            return null;
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);

            SetDefault(T, "adate", Conn.GetDataContabile());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idpurchase"], null, null, 0);

            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R.IsNull("idreg")) {
                errmess = "Specificare un intestatario";
                errfield = "idreg";
                return false;
            }

            if (R.IsNull("adate")) {
                errmess = "Specificare una data di emissione";
                errfield = "adate";
                return false;
            }

            return base.IsValid(R, out errmess, out errfield);
        }

    }

}
