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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_admpay_admintax
{
	/// <summary>
	/// Summary description for Meta_admpay_admintax.
	/// </summary>
	public class Meta_admpay_admintax : Meta_easydata
	{
		public Meta_admpay_admintax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay_admintax") {	
			EditTypes.Add("detail");
			ListingTypes.Add("detail");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="detail") {
				DefaultListType="detail";
				Name = "Contributi a carico dell'ente su Movimento del Pagamento Stipendi";
				return GetFormByDllName("admpay_admintax_detail");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "detail") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "!tax", "Ritenuta", "tax.description", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
				DescribeAColumn(T, "nappropriation", "Num. Impegnativa", nPos++);
				DescribeAColumn(T, "!codeupb", "Cod. U.P.B.", "admpay_appropriationview.codeupb", nPos++);
				DescribeAColumn(T, "!codefin", "Cod. Bilancio", "admpay_appropriationview.codefin", nPos++);
				DescribeAColumn(T, "!ymov", "Eserc. Movimento", "admpay_appropriationview.ymov", nPos++);
				DescribeAColumn(T, "!nmov", "Num. Movimento", "admpay_appropriationview.nmov", nPos++);
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yadmpay");
			RowChange.SetSelector(T, "nadmpay");
			RowChange.SetSelector(T, "nexpense");
			RowChange.SetSelector(T, "taxcode");
			RowChange.MarkAsAutoincrement(T.Columns["nbracket"], null, null, 7);
			return base.Get_New_Row(ParentRow, T);
		}
	}
}
