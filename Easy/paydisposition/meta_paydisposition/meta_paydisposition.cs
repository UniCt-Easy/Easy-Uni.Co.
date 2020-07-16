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
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_paydisposition {
    public class Meta_paydisposition : Meta_easydata {
        public Meta_paydisposition(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
			base(Conn, Dispatcher, "paydisposition") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			DefaultListType = "default";
		}

        protected override Form GetForm(string EditType) {
            if (EditType == "default") {
                DefaultListType = "default";
                Name = "Disposizione di Pagamento";
                return GetFormByDllName("paydisposition_default");
            }

            return null;
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "ayear", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idpaydisposition"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["idpaydisposition"],900000000);
            return base.Get_New_Row(ParentRow, T);
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "paydispositionview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

    }
}
