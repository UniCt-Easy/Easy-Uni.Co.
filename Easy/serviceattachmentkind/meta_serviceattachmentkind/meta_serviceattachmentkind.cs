
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

    namespace meta_serviceattachmentkind{
        public class Meta_serviceattachmentkind : Meta_easydata{
            public Meta_serviceattachmentkind(DataAccess Conn, MetaDataDispatcher Dispatcher) :
                base(Conn, Dispatcher, "serviceattachmentkind"){
                EditTypes.Add("default");
                ListingTypes.Add("default");
            }

            protected override Form GetForm(string FormName){
                if (FormName == "default"){
                    Name = "Elenco Tipi Documenti allegati";
                    DefaultListType = "default";
                    return GetFormByDllName("serviceattachmentkind_default");
                }
                return null;
            }

            //public override void DescribeColumns(DataTable T, string ListingType){
            //    base.DescribeColumns(T, ListingType);
            //    if (ListingType == "default"){
            //        foreach (DataColumn C in T.Columns)
            //            DescribeAColumn(T, C.ColumnName, "", -1);
            //        int nPos = 1;
            //    DescribeAColumn(T, "idattachmentkind", ".#", nPos++);
            //    DescribeAColumn(T, "title", "Descrizione", nPos++);
            //    DescribeAColumn(T, "active", "Attivo", nPos++);
            //    DescribeAColumn(T, "flagforced", "Obbligatorio", nPos++);
            //}
            //}
            public override void SetDefaults(DataTable PrimaryTable){
                base.SetDefaults(PrimaryTable);
                MetaData.SetDefault(PrimaryTable, "active", "S");
                MetaData.SetDefault(PrimaryTable, "flagforced", "N");
            }
            public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
                if (ListingType == "default")
                    return base.SelectOne(ListingType, filter, "serviceattachmentkindview", Exclude);
                else
                    return base.SelectOne(ListingType, filter, "serviceattachmentkind", Exclude);
            }

            public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
                    RowChange.MarkAsAutoincrement(T.Columns["idattachmentkind"], null, null, 7);
                    DataRow R = base.Get_New_Row(ParentRow, T);
                    int N = MetaData.MaxFromColumn(T, "idattachmentkind");
                    if (N < 9999000)
                        R["idattachmentkind"] = 9999001;
                    else
                        R["idattachmentkind"] = N + 1;
                    return R;
            }
        }
    }


