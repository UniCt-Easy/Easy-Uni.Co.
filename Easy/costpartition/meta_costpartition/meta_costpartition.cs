
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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

namespace meta_costpartition {
	/// <summary>
	/// Summary description for Meta_costpartition.
	/// </summary>
	public class Meta_costpartition : Meta_easydata {
		public Meta_costpartition(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "costpartition") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Riallocazione di contabilit� analitica Costi/Ricavi";
				return GetFormByDllName("costpartition_default");
			}
			return null;
		}	

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "kind", "C");
            SetDefault(PrimaryTable, "active", "S");
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idcostpartition"], null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

        //public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
        //    if (ListingType == "default") return base.SelectOne(ListingType, filter, "costpartitionview", Exclude);
        //    return base.SelectOne(ListingType, filter, "costpartition", Exclude);
        //}

        public override void CalculateFields(DataRow R, string list_type)
        {
            if ((list_type == "default")&&(R.Table.Columns.Contains("!tipo")))
            {

                if (R["kind"].ToString() == "P")
                {
                    R["!tipo"] = "Percentuali";
                }
                else
                {
                    R["!tipo"] = "Costi";
                }
            }
        }


		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
                DescribeAColumn(T, ".kind", "Tipo", nPos++);
                if (T.Columns.Contains("!tipo"))
                     DescribeAColumn(T, "!tipo", "Tipo", nPos++);
                else
                    DescribeAColumn(T, "kind", "Tipo", nPos++);
                DescribeAColumn(T, ".idcostpartition", "#", nPos++);
                DescribeAColumn(T, "costpartitioncode", "Cod. Ripartizione", nPos++);
                DescribeAColumn(T, "title", "Denominazione", nPos++);
                ComputeRowsAs(T, "default");
			}
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if ((R["costpartitioncode"] == DBNull.Value) || (R["costpartitioncode"].ToString() == ""))
            {
				errmess="Attenzione! Il codice della Ripartizione non pu� essere nullo";
                errfield = "costpartitioncode";
				return false;
			}

            if ((R["title"] == DBNull.Value) || (R["title"].ToString() ==""))
            {
                errmess = "Attenzione! La denominazione non pu� essere nulla";
                errfield = "title";
                return false;
            }
			
            return base.IsValid(R, out errmess, out errfield);    
		}
	}
}
