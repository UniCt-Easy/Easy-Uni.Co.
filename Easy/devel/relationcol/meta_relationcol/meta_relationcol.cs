
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
using System.Text;
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_relationcol
{
    public class Meta_relationcol : Meta_easydata {
        public Meta_relationcol(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "relationcol") {
            EditTypes.Add("detail");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "detail") {
                Name = "Campo relazione";
                DefaultListType = "detail";
                return GetFormByDllName("relationcol_detail");
            }
            return null;
        }

    

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns) {
                DescribeAColumn(T, C.ColumnName, "", -1);
            }

            if (ListingType == "default") {
                base.DescribeColumns(T, ListingType);
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }


                int nPos = 1;
                DescribeAColumn(T, "parentcol", "parent", nPos++);
                DescribeAColumn(T, "childcol", "child", nPos++);

            }
            return;
        }

    }
}
