
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_csa_contract
{
	/// <summary>
	/// </summary>
	public class Meta_csa_contract : Meta_easydata {
		public Meta_csa_contract(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_contract") {		
			EditTypes.Add("default");
			EditTypes.Add("annulla");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Regola specifica CSA";
				return MetaData.GetFormByDllName("csa_contract_default");
			}
			if (FormName == "annulla")
			{
				Name = "Disattivazione/Riattivazione Regole specifiche CSA";
				return MetaData.GetFormByDllName("csa_contract_annulment");
			}
			return null;
		}

	    protected override void InsertCopyColumn(DataColumn c, DataRow source, DataRow dest) {
            if(c.ColumnName=="idcsa_contract")return;
	        base.InsertCopyColumn(c,source,dest);
	    }

	    public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
            SetDefault(T, "ayear", GetSys("esercizio"));
            SetDefault(T, "ycontract", GetSys("esercizio"));
            SetDefault(T, "flagkeepalive", "S");
            SetDefault(T, "flagrecreate", "S");
            SetDefault(T, "active", "S");
		}
		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (CfgFn.GetNoNullInt32(R["idcsa_contractkind"]) == 0) {
				errmess = "Non è stato valorizzata la regola generale";
				errfield = "idcsa_contractkind";
				return false;
			}
			return true;
		}

		public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_contractview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.ClearMySelector(T, "ycontract");
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_contract"], null, null, 0);
            RowChange.MarkAsAutoincrement(T.Columns["ncontract"], null, null, 0);
            RowChange.SetMySelector(T.Columns["ncontract"], "ycontract", 0);

            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "ncontract");
            if (N < 9999000)
                R["ncontract"] = 9999001;
            else
                R["ncontract"] = N + 1;

            int K = MetaData.MaxFromColumn(T, "idcsa_contract");
            if (K < 9999000)
                R["idcsa_contract"] = 9999001;
            else
                R["idcsa_contract"] = K + 1;
            return R;
        }
	}

}
