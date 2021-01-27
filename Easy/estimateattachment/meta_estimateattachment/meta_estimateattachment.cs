
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;                    
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_estimateattachment
{
    public class Meta_estimateattachment : Meta_easydata {
        public Meta_estimateattachment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "estimateattachment") {
            Name = "Allegato al contratto passivo";
            EditTypes.Add("default");
            ListingTypes.Add("lista");
        }
        protected override Form GetForm(string EditType) {
            if (EditType == "default") return GetFormByDllName("estimateattachment_default");
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idestimkind");
            RowChange.SetSelector(T, "yestim");
            RowChange.SetSelector(T, "nestim");
            RowChange.MarkAsAutoincrement(T.Columns["idattachment"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "filename", "Nome file", nPos++);
            }
        }
    }
}
