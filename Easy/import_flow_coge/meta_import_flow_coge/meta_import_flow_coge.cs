
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


using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_import_flow_coge {
    /// <summary>
    /// Summary description for Meta_import_flow.
    /// </summary>
    public class Meta_import_flow_coge : Meta_easydata {
        public Meta_import_flow_coge(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "import_flow") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            }

        //public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
        //    RowChange.SetSelector(T, "idimportflow");
        //    RowChange.MarkAsAutoincrement(T.Columns["idimportflow_prog"], null, null, 7);
        //    return base.Get_New_Row(ParentRow, T);
        //}


        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            }

        }
    }
