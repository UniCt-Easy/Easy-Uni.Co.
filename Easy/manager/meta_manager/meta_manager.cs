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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//Pino: using responsabile; diventato inutile
using metadatalibrary;




namespace meta_manager//meta_responsabile//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_manager : Meta_easydata 
	{
		public Meta_manager(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "manager") 
		{
			EditTypes.Add("default");
            EditTypes.Add("history");
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
			Name = "Responsabile";
		}
		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"active","S");
            SetDefault(PrimaryTable, "financeactive", "S");
            SetDefault(PrimaryTable, "wantswarn", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idman"], null,null, 7);
          
            return base.Get_New_Row(ParentRow, T);
        }

        public override string GetSorting(string ListingType) {
            if (ListingType == "lista") return "title asc";
            return base.GetSorting(ListingType);
        }
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default"||FormName=="history") 
			{
				DefaultListType="default";
				return MetaData.GetFormByDllName("manager_default");//PinoRana
			}
		
			return null;
		}

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                //DescribeAColumn(T, "idman", "Cod. Responsabile", nPos++);
                DescribeAColumn(T, "title", "Responsabile", nPos++);
            }
        }
		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "lista") {
                return base.SelectOne(ListingType, filter, searchtable, Exclude);
            }
			return base.SelectOne(ListingType, filter, "managerview", Exclude);
		}		

	
	}
}
