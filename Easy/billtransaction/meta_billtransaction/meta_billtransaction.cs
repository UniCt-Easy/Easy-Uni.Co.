/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_billtransaction
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Meta_billtransaction : Meta_easydata {
        public Meta_billtransaction(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "billtransaction") {		
            Name= "Movimento bancario";
            EditTypes.Add("acredito");
            EditTypes.Add("adebito");
            EditTypes.Add("default");
			ListingTypes.Add("detail");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName){

            if (FormName == "adebito")
            {
                Name = "Regolarizzazione Bolletta";
                DefaultListType = "detail";
				return GetFormByDllName("billtransaction_payment");
			}
            if (FormName == "acredito" )
            {
                Name = "Regolarizzazione Bolletta";
                DefaultListType = "detail";
				return GetFormByDllName("billtransaction_proceeds");
			}
            
            if (FormName == "default")
            {
                Name = "Regolarizzazione Bolletta Entrata";
                DefaultListType = "default";
                return GetFormByDllName("billtransaction_default");
            }
			 
			return null;
        }

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ybilltran", GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.SetSelector(T, "ybilltran");
            RowChange.MarkAsAutoincrement(T.Columns["nbilltran"], null,
				null,7);
            SetDefault(T, "ybilltran", GetSys("esercizio"));
            RowChange.setMinimumTempValue(T.Columns["nbilltran"], 9900000);
			DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
		}

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
           
			if (ListingType == "detail") 
			{
				foreach (DataColumn c in T.Columns)
				{
					DescribeAColumn(T, c.ColumnName, "",-1);
				}
                int pos = 1;
                DescribeAColumn(T, "!npro", "N. reversale", "proceeds.npro", pos++);
                DescribeAColumn(T, "!nmovi", "N.mov. entrata", "income.nmov", pos++);
                DescribeAColumn(T, "!npay", "N. mandato", "payment.npay", pos++);
                DescribeAColumn(T, "!nmove", "N.mov. spesa", "expense.nmov", pos++);
                DescribeAColumn(T, "adate", "Data operazione", pos++);
                DescribeAColumn(T, "amount", "Importo", pos++);
            } 
        }   	

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
           
            return base.SelectOne(ListingType, filter, "billtransactionview", Exclude);
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) 
		{
			errmess = null;
			errfield = null;
			if (R["adate"] is DBNull)
			{
				errmess = "Per regolarizzare una bolletta occorre inserire la data operazione.";
				errfield = "adate";
				return false;
			}
            if (R["nbill"] is DBNull)
            {
                errmess = "Bisogna specificare il numero della bolletta che si sta regolarizzando";
                errfield = "nbill";
                return false;
            }
            if (R["kind"] is DBNull)
            {
                errmess = "Bisogna specificare il tipo della bolletta che si sta regolarizzando";
                errfield = "kind";
                return false;
            }
            /*
			decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
			if (amount <=0) {
				errmess="L'importo dell'esito non puÚ essere nullo o negativo";
				errfield="amount";
				return false;
			}
             * */
            /*
			string kind = R["kind"].ToString().ToUpper();
			if (kind == "D") {
				if (R["idexp"].ToString() == "") {
					errmess = "Bisogna specificare il movimento finanziario che si sta esitando";
					errfield = "idexp";
					return false;
				}
			}
			if (kind == "C") {
				if (R["idinc"].ToString() == "") {
					errmess = "Bisogna specificare il movimento finanziario che si sta esitando";
					errfield = "idinc";
					return false;
				}
			}
             * */
			return true;
		}
    }	
}
