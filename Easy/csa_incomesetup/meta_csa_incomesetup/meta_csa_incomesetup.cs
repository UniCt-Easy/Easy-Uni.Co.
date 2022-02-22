
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
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using metaeasylibrary;
using metadatalibrary;

namespace meta_csa_incomesetup
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_csa_incomesetup : Meta_easydata {
		public Meta_csa_incomesetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_incomesetup") {
			EditTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default")
			{
				DefaultListType="default";
				Name = "Configurazione Voci CSA";
				return MetaData.GetFormByDllName("csa_incomesetup_default");
			}
			return null;
		}		
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ayear", GetSys("esercizio"));
			}

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "ayear");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_incomesetup"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);

            int N = MetaData.MaxFromColumn(T, "idcsa_incomesetup");
            if (N < 9999000)
                R["idcsa_incomesetup"] = 9999001;
            else
                R["idcsa_incomesetup"] = N + 1;

            return R;
        }
	    string [] allfields= new string[] {
	        "idfin_income","idfin_expense","idsor_siope_income","idsor_siope_expense","idacc_expense","idacc_agency_credit",
	        "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idfin_cost","idsor_siope_cost","idacc_cost","idupb"
	    };
	    string [] ritenuteFields= new string[] 
	        {"idfin_income","idfin_expense","idsor_siope_income","idsor_siope_expense","idacc_expense","idacc_agency_credit"};
	    //finincome && finexpense && sortingincome && sortingexpense && accountente && accountcreditente;

	    string []  recuperiFields= new string[] {
	        "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idfin_cost","idsor_siope_cost",
	        "idacc_cost","idupb"
	    };// finincomeclawback && sortingincomeclawback && account_revenue && finexpensecost  && sortingexpensecost  && account_cost && upb;


	    string [] contributiFields = new string[] {
	        "idfin_incomeclawback","idsor_siope_incomeclawback","idacc_revenue","idacc_expense","idacc_agency_credit"
	    };//finincomeclawback && sortingincomeclawback && account_revenue && accountente && accountcreditente;

	    bool checkConfigurazione(DataRow r, string[] cfg) {
	        List<string> elencoVietati = new List<string>();
	        foreach(string field in allfields) elencoVietati.Add(field);

	        foreach (string field in cfg) {
	            if (r[field] == DBNull.Value) return false;
	            elencoVietati.Remove(field);
	        }
	        
	        foreach (string field in elencoVietati) {
	            if (r[field] != DBNull.Value) return false;
	        }

	        return true;
	    }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
          
            if (!(checkConfigurazione(R,ritenuteFields)|checkConfigurazione(R,contributiFields)| checkConfigurazione(R,recuperiFields))) {
                errmess = "Configurazione incompleta o errata";
                //errfield = "...";
                return false;
            }
            

            return true;
        }


        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_incomesetupview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
	}
}
