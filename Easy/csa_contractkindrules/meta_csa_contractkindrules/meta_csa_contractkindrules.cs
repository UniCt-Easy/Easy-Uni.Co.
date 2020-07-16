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
using metadatalibrary;
using funzioni_configurazione;

namespace meta_csa_contractkindrules {
	/// <summary>
	/// </summary>
	public class Meta_csa_contractkindrules : Meta_easydata {
		public Meta_csa_contractkindrules(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_contractkindrules") {
			Name= "Regole di individuazione CSA";
			EditTypes.Add("default");
            EditTypes.Add("search");
			ListingTypes.Add("default");
            ListingTypes.Add("search");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
				return GetFormByDllName("csa_contractkindrules_default");
            if (FormName == "search") {
                DefaultListType = "search";
                return GetFormByDllName("csa_contractkindrules_search");
            }
			return null;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
        {
            if (ListingType == "search")
            {
                return base.SelectOne(ListingType, filter, "csa_contractkindrulesview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_contractkind");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_rule"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", Conn.GetSys("esercizio"));
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T,"idcsa_rule", "#", nPos++);
                DescribeAColumn(T,"ayear", "Esercizio", nPos++);
             	DescribeAColumn(T,"capitolocsa","Capitolo CSA",nPos++);
                DescribeAColumn(T,"ruolocsa", "Ruolo CSA", nPos++);
             }
            
		}

	}
}