
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_intrastatcode
{
	/// <summary>
	/// </summary>
    public class Meta_intrastatcode : Meta_easydata {

        public Meta_intrastatcode (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "intrastatcode") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm (string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Nomenclatura combinata";
                return MetaData.GetFormByDllName("intrastatcode_default");
            }
            return null;
        }

        public override void SetDefaults (DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "ayear", Conn.GetEsercizio());
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idintrastatcode"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idintrastatcode");
            if (N < 9999000)
                R["idintrastatcode"] = 9999001;
            else
                R["idintrastatcode"] = N + 1;

            return R;
        }

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType=="default")
				return base.SelectOne (ListingType, filter, "intrastatcodeview", ToMerge);
			return base.SelectOne (ListingType, filter, searchtable, ToMerge);
		}
    }

}
