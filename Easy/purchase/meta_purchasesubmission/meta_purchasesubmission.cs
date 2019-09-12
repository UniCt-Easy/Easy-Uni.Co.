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

ï»¿using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_purchasesubmission {

    public class Meta_purchasesubmission : Meta_easydata {

        public Meta_purchasesubmission(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "purchasesubmission") {
            ListingTypes.Add("list");
            EditTypes.Add("single");
        }

        protected override Form GetForm(string EditType) {
            if (EditType == "single") {
                DefaultListType = "list";
                Name = "Versamento";
                return GetFormByDllName("purchasesubmission_single");
            }

            return null;
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);

            SetDefault(T, "ayear", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idpurchase");

            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "iuv", "IUV", nPos++);
                DescribeAColumn(T, "expirationdate", "Scadenza", nPos++);
            }
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (R.IsNull("ayear")) {
                errmess = "Selezionare un anno d'esercizio";
                errfield = "ayear";
                return false;
            }

            if (R.IsNull("expirationdate")) {
                errmess = "Selezionare una data di scadenza";
                errfield = "expirationdate";
                return false;
            }

            if (R.IsNull("idreg")) {
                errmess = "Selezionare l'anagrafica del versante";
                errfield = "idreg";
                return false;
            }

            return base.IsValid(R, out errmess, out errfield);
        }

    }

}
