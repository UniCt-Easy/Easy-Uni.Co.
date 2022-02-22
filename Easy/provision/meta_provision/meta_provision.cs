
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
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_provision{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_provision : Meta_easydata{
        public Meta_provision(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "provision"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Fondo di Accantonamento";
        }
        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile").ToString());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idprovision"], null, null, 7);

            return base.Get_New_Row(ParentRow, T);
        }

        protected override Form GetForm(string FormName){
            if (FormName == "default"){
                DefaultListType = "default";
                return MetaData.GetFormByDllName("provision_default");
            }

            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["adate"] == DBNull.Value) {
                errmess = "Attenzione! Non è stata inserita la data contabile.";
                errfield = "adate";
                return false;
            }
            if (R["description"] == DBNull.Value) {
                errmess = "Attenzione! Non è stata inserita la descrizione del Fondo.";
                errfield = "description";
                return false;
            }
            if (R["title"] == DBNull.Value) {
                errmess = "Attenzione! Non è stata inserita la denominazione del Fondo.";
                errfield = "title";
                return false;
            }
            return true;
        }

        //public override void DescribeColumns(DataTable T, string ListingType){
        //    base.DescribeColumns(T, ListingType);
        //    if (ListingType == "default"){
        //        foreach (DataColumn C in T.Columns){
        //            DescribeAColumn(T, C.ColumnName, "", -1);
        //        }
        //        int nPos = 1;
        //        DescribeAColumn(T, "description", "Descrizione", nPos++);
        //    }
        //}
        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "provisionview", Exclude);
            return base.SelectOne(ListingType, filter, "provision", Exclude);

        }

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if (C.ColumnName == "idepexp") return;
			base.InsertCopyColumn(C, Source, Dest);
		}
	}
}
