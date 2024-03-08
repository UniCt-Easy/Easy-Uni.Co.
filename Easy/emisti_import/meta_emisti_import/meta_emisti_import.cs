
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta_emisti_import {
    class Meta_emisti_import : Meta_easydata {

        public Meta_emisti_import(DataAccess Conn, MetaDataDispatcher Dispatcher) : base(Conn, Dispatcher, "emisti_import") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "yimport", GetSys("esercizio"));
            SetDefault(T, "adate", GetSys("datacontabile"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {

            RowChange.ClearMySelector(T, "yimport");

            RowChange.MarkAsAutoincrement(T.Columns["idemisti_import"], null, null, 0);

            RowChange.SetMySelector(T.Columns["nimport"], "yimport", 0);
            RowChange.MarkAsAutoincrement(T.Columns["nimport"], null, null, 0);

            DataRow R = base.Get_New_Row(ParentRow, T);

            int K = MaxFromColumn(T, "idemisti_import");
            if (K < 9999000)
                R["idemisti_import"] = 9999001;
            else
                R["idemisti_import"] = K + 1;

            return R;
        }
    }
}
