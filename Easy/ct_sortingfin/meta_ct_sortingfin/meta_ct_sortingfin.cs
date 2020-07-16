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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_ct_sortingfin {
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_ct_sortingfin :Meta_easydata {
        public Meta_ct_sortingfin(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "ct_sortingfin") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Configurazione Utilizzo delle voci di bilancio nei sottosezionali";
                return MetaData.GetFormByDllName("ct_sortingfin_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }
        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "ct_sortingfinview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "ct_sortingfin", Exclude);
        }

    }
}
