
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;


namespace meta_allowancerule {
    public class Meta_allowancerule : Meta_easydata {
        public Meta_allowancerule(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "allowancerule") {
            EditTypes.Add("default");
            ListingTypes.Add("default");

            //
            // TODO: Add constructor logic here
            //
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Regole Indennità di missione in Italia";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("allowancerule_default");
            }
            return null;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idallowancerule"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                DescribeAColumn(T, "idallowancerule", "Id.regola");
                DescribeAColumn(T, "start", "Decorrenza");
                DescribeAColumn(T, "groupnumber", "Gruppo");
            }
            return;
        }
    }
}
