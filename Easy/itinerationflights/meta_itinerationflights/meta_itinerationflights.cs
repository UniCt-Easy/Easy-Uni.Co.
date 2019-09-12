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

ï»¿using System;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_itinerationflights{
    public class Meta_itinerationflights :Meta_easydata {
        public Meta_itinerationflights(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "itinerationflights") {
            EditTypes.Add("default");
            EditTypes.Add("single");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Tratte";
                return MetaData.GetFormByDllName("itinerationflights_single");
            }
            return null;
        }


        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "iditineration");
            RowChange.MarkAsAutoincrement(T.Columns["idflights"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            return true;
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            int nPos = 1;
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                DescribeAColumn(T, "idflights", "Num.Tratta", nPos++);
                DescribeAColumn(T, "fromlocation", "Da", nPos++);
                DescribeAColumn(T, "tolocation", "A", nPos++);
            }
        }

    }
}
