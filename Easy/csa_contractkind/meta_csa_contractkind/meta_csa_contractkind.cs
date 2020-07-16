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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_csa_contractkind
{
	/// <summary>
	/// </summary>
	public class Meta_csa_contractkind : Meta_easydata {
		public Meta_csa_contractkind(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "csa_contractkind") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName)
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name= "Regola generale CSA";
				return MetaData.GetFormByDllName("csa_contractkind_default");
			}
			return null;
		}

		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"flagcr","C");
            SetDefault(T,"flagkeepalive", "S");
            SetDefault(T, "active", "S");
		}		

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "csa_contractkindview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
        public override DataRow Get_New_Row (DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idcsa_contractkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            
            int N = MetaData.MaxFromColumn(T, "idcsa_contractkind");
            if (N < 9999000)
                R["idcsa_contractkind"] = 9999001;
            else
                R["idcsa_contractkind"] = N + 1;

            return R;
        }
	}

}
