/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace meta_intrastatservice
{
    /// <summary>
    /// </summary>
    public class Meta_intrastatservice : Meta_easydata
    {

        public Meta_intrastatservice(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "intrastatservice")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName){
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Codice del servizio";
                return MetaData.GetFormByDllName("intrastatservice_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable T){
            base.SetDefaults(T);
            SetDefault(T, "ayear", Conn.GetEsercizio());
        }

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "code", "Codice", nPos++);
                DescribeAColumn(T, "description", "Servizio", nPos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idintrastatservice"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idintrastatservice");
            if (N < 9999000)
                R["idintrastatcode"] = 9999001;
            else
                R["idintrastatcode"] = N + 1;

            return R;
        }

     }

}


