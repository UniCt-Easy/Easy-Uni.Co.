
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_parasubcontractattachment{
    public class Meta_parasubcontractattachment : Meta_easydata{
        public Meta_parasubcontractattachment(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "parasubcontractattachment"){
            Name = "Allegato al Compenso";
            EditTypes.Add("detail");
            ListingTypes.Add("lista");
        }
        protected override Form GetForm(string EditType){
            if (EditType == "detail") return GetFormByDllName("parasubcontractattachment_detail");
            return null;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.SetSelector(T, "idcon");
            RowChange.MarkAsAutoincrement(T.Columns["idattachment"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);
            if (listtype == "lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "filename", "Nome file", nPos++);
                DescribeAColumn(T, "!serviceattachmentkind", "Tipo Allegato", "serviceattachmentkind.title", nPos++);
            }
        }
    }
}
