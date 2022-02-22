
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
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;
using System.Windows.Forms;


namespace meta_grantload
{
    public class Meta_grantload : Meta_easydata
    {

        public Meta_grantload(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "grantload") {
            EditTypes.Add("default");
            Name = "Scarico di contributi o riscontri";
            ListingTypes.Add("default");
        }


        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Scarico di contributi o risconti";
                return MetaData.GetFormByDllName("grantload_default");//PinoRana
            }

            return null;
        }


        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "yload", GetSys("esercizio"));
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "kind", "D");
        }


        public static void SetAutoIncrementProperties(DataTable T, DataAccess Conn) {
            RowChange.MarkAsAutoincrement(T.Columns["idgrantload"], null, null, 0);
            
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            SetAutoIncrementProperties(T, Conn);
            RowChange.setMinimumTempValue(T.Columns["idgrantload"], 999900000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
           
        }
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "grantloadview", Exclude);
            else
                return base.SelectOne(ListingType, filter, searchtable, Exclude);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idgrantload", "Numero carico", nPos++);
                DescribeAColumn(T, "yload", "Anno ", nPos++);
                DescribeAColumn(T, "kind", "Contributi o Risconti", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }

        }




    }
}
