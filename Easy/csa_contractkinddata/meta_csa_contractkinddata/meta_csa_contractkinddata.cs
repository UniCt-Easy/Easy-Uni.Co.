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

namespace meta_csa_contractkinddata {
	/// <summary>
	/// </summary>
	public class Meta_csa_contractkinddata : Meta_easydata {
		public Meta_csa_contractkinddata(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_contractkinddata") {
			Name= "Contributi CSA -Regola generale ";
			EditTypes.Add("default");
            EditTypes.Add("elenco");
            ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") 
				return GetFormByDllName("csa_contractkinddata_default");
            if (FormName == "elenco")
                return GetFormByDllName("csa_contractkinddata_elenco");
            return null;
		}	
		

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_contractkind");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_contractkinddata"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", Conn.GetSys("esercizio"));
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_contractkinddataview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T,"idcsa_contractkinddata", "#", nPos++);
                DescribeAColumn(T,"ayear", "Esercizio", nPos++);
             	DescribeAColumn(T,"vocecsa","Voce CSA",nPos++);
                DescribeAColumn(T,"!codefin","Voce Bilancio Spesa","fin.codefin", nPos++);
                DescribeAColumn(T, "!codeupb", "Codice UPB", "upb1.codeupb", nPos++);
                DescribeAColumn(T, "!sortcode", "Codice SIOPE", "sorting.sortcode", nPos++);
                DescribeAColumn(T,"!codeacc","Codice Conto","account.codeacc", nPos++);
             }
		}

	}
}