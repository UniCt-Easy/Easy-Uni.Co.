
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
namespace meta_admpay_expense
{
	/// <summary>
	/// Summary description for Meta_admpay_expense.
	/// </summary>
	public class Meta_admpay_expense: Meta_easydata {
		public Meta_admpay_expense(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay_expense") {	
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string EditType) {
			if (EditType == "default") {
				DefaultListType = "default";
				Name = "Spese dei Pagamenti Stipendi";
				return GetFormByDllName("admpay_expense_default");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yadmpay");
			RowChange.SetSelector(T, "nadmpay");
			RowChange.MarkAsAutoincrement(T.Columns["nexpense"], null, null, 7);
			return base.Get_New_Row(ParentRow, T);
		}
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))return false;
            if (CfgFn.GetNoNullInt32(R["nappropriation"]) == 0) {
                errfield = "nappropriation";
                errmess = "E' necessario selezionare il meta impegno";
                return false;
            }
            return true;
        }



		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "yadmpay", Conn.GetSys("esercizio"));
		}

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "admpay_expenseview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }
	}
}
