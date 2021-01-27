
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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_underwriting{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_underwriting : Meta_easydata{
        public Meta_underwriting(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "underwriting"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("impegni");
            Name = "Finanziamento";
        }
        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idunderwriting"], null, null, 7);

            return base.Get_New_Row(ParentRow, T);
        }

        protected override Form GetForm(string FormName){
            if (FormName == "default"){
                DefaultListType = "default";
                return MetaData.GetFormByDllName("underwriting_default");
            }

            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "title", "Denominazione", nPos++);
            }
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            if (ListingType == "impegni")
                return base.SelectOne(ListingType, filter, "upbunderwritingyearview", Exclude);
            return base.SelectOne(ListingType, filter, "underwritingview", Exclude);

        }


    }
}
