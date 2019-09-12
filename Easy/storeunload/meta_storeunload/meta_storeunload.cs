/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metaeasylibrary;
using metadatalibrary;

namespace meta_storeunload
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_storeunload : Meta_easydata
    {
        public Meta_storeunload (DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "storeunload")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Scarico Magazzino";
        }

        protected override Form GetForm(string FormName){
            DefaultListType = "default";
            if (FormName == "default") return MetaData.GetFormByDllName("storeunload_default");
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ystoreunload", Conn.GetEsercizio());
            SetDefault(PrimaryTable, "adate", Conn.GetDataContabile());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.ClearMySelector(T, "ystoreunload");
            RowChange.MarkAsAutoincrement(T.Columns["idstoreunload"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["nstoreunload"], null, null, 0);
            RowChange.SetMySelector(T.Columns["nstoreunload"], "ystoreunload", 0);

            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "nstoreunload");
            if (N < 9999000)
                R["nstoreunload"] = 9999001;
            else
                R["nstoreunload"] = N + 1;

            int K = MetaData.MaxFromColumn(T, "idstoreunload");
            if (K < 9999000)
                R["idstoreunload"] = 9999001;
            else
                R["idstoreunload"] = K + 1;
          
            return R;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            return base.SelectOne(ListingType, filter, "storeunloadview", Exclude);
        }


    }
}


