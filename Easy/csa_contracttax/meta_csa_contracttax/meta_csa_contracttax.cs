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
using funzioni_configurazione;

namespace meta_csa_contracttax {
	/// <summary>
	/// </summary>
	public class Meta_csa_contracttax : Meta_easydata {
		public Meta_csa_contracttax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_contracttax") {
			EditTypes.Add("default");
            EditTypes.Add("elenco");
            ListingTypes.Add("lista");
		}
		protected override Form GetForm(string FormName){
            if (FormName == "default") {
                Name = "Contributi Regola specifica CSA";
                return GetFormByDllName("csa_contracttax_default");
            }
            if (FormName == "elenco") {
                Name = "Contributi Regola specifica CSA";
                return GetFormByDllName("csa_contracttax_elenco");
            }
            return null;
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_contracttaxview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idcsa_contract");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_contracttax"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }
        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ayear", Conn.GetSys("esercizio"));
        }

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);

			if (ListingType=="lista") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
                DescribeAColumn(T,"idcsa_contracttax","#", nPos++);
                DescribeAColumn(T,"ayear","Esercizio", nPos++);
             	DescribeAColumn(T,"vocecsa","Voce CSA",nPos++);
                DescribeAColumn(T,"!codeupb","Codice UPB", "upb1.codeupb", nPos++);
                DescribeAColumn(T,"!codefin","Voce Bilancio Spesa","fin1.codefin", nPos++);
                DescribeAColumn(T,"!sortcode", "Codice SIOPE", "sorting1.sortcode", nPos++);
                DescribeAColumn(T,"!codeacc","Codice Conto","account1.codeacc", nPos++);
                DescribeAColumn(T, "!phase", "Fase", "expenseview3.phase", nPos++);
                DescribeAColumn(T, "!ymov", "Eserc. Movimento", "expenseview3.ymov", nPos++);
                DescribeAColumn(T, "!nmov", "Num. Movimento", "expenseview3.nmov", nPos++);

            }
		}

	}
}