
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_accountvar {
	/// <summary>
	/// Summary description for Meta_accountvar.
	/// </summary>
	public class Meta_accountvar : Meta_easydata {
		public Meta_accountvar(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "accountvar") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Variazione";
				return GetFormByDllName("accountvar_default");
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
		    SetDefault(PrimaryTable, "flag", 0);
		    if (PrimaryTable.Columns["variationkind"].DefaultValue.ToString() == "" ||
		        PrimaryTable.Columns["variationkind"].DefaultValue.ToString() == "0") {
		        SetDefault(PrimaryTable, "variationkind", 1);
		    }
                
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T,"yvar");
			RowChange.MarkAsAutoincrement(T.Columns["nvar"],null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default") return base.SelectOne(ListingType, filter, "accountvarview", Exclude);
            return base.SelectOne(ListingType, filter, "accountvar", Exclude);
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yvar", "Eserc. variazione", nPos++);
				DescribeAColumn(T, "nvar", "Num. variazione", nPos++);
				DescribeAColumn(T, "description", "Desc. variazione", nPos++);
				DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
				DescribeAColumn(T, "nenactment", "Num. provv.", nPos++);
				DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
				DescribeAColumn(T, "adate", "Data cont.", nPos++);
			}
		}
	}
}
