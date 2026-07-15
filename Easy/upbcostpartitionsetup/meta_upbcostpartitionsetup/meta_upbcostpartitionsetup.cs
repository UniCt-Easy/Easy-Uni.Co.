/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

namespace meta_upbcostpartitionsetup {
	/// <summary>
	/// Summary description for meta_upbcostpartitionsetup.
	/// </summary>
	public class Meta_upbcostpartitionsetup : Meta_easydata {
		public Meta_upbcostpartitionsetup(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "upbcostpartitionsetup") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Mappatura UPB - Driver di contabilità analitica";
				return GetFormByDllName("upbcostpartitionsetup_default");
			}
			return null;
		}	

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idupbcostpartitionsetup"], null,
				null,7);
			return base.Get_New_Row(ParentRow, T);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {            
			if ((R["idupb"] == DBNull.Value) || (R["idupb"].ToString() == ""))
			{
				errmess = "Attenzione! l'upb non può essere nullo";
				errfield = "idupb";
				return false;
			}

			if ((R["idcostpartition"] == DBNull.Value) || (R["idcostpartition"].ToString() == "") || (R["idcostpartition"].ToString() == "0"))
			{
				errmess = "Attenzione! Il driver di contabilità analitica non può essere nullo";
				errfield = "idcostpartition";
				return false;
			}

			return base.IsValid(R, out errmess, out errfield);    
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge)
		{
			if (ListingType == "default")
			{
				return base.SelectOne(ListingType, filter, "upbcostpartitionsetupview", ToMerge);
			}

			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}
	}
}