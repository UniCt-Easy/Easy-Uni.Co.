
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


using metadatalibrary;
using metaeasylibrary;

using System.Data;

namespace meta_emisti_rec_08 {
    class Meta_emisti_rec_08 : Meta_easydata {

        public Meta_emisti_rec_08(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "emisti_rec_08") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {

            RowChange.SetSelector(T, "idemisti_import");
            RowChange.MarkAsAutoincrement(T.Columns["nrec"], null, null, 0);

            RowChange.setMinimumTempValue(T.Columns["nrec"], 9999000);

            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
    }
}
