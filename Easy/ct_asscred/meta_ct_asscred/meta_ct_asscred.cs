
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace meta_ct_asscred
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_ct_asscred : Meta_easydata {
		public Meta_ct_asscred(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ct_asscred") {
			EditTypes.Add("default");
            ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
                DefaultListType = "default";
                Name = "Configurazione Assegnazione Crediti";
				return MetaData.GetFormByDllName("ct_asscred_default");
			}
			return null;
		}		
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
		}

        public override System.Data.DataRow Get_New_Row(System.Data.DataRow ParentRow, System.Data.DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idct_asscred"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["idct_asscred"], 99999000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

		public override bool IsValid(DataRow R,out string errmess, out string errfield){            
			if (!base.IsValid(R, out errmess, out errfield)) return false;
            if ( CfgFn.GetNoNullInt32(R["idfin_income"]) == 0) {
				errmess="Inserire una voce bilancio di entrata.";
				errfield=null;
				return false;
			}
            if (R["idsor"].ToString() == "") {
                errmess = "Inserire il codice classificazione.";
                errfield = null;
                return false;
            }
            return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
            if (ListingType == "default")
				return base.SelectOne(ListingType, filter, "ct_asscredview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "ct_asscred", Exclude);
		}		
	}
}
