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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;
using System.Data;

namespace meta_admpay_assessment {
    class Meta_admpay_assessment : Meta_easydata{
        public Meta_admpay_assessment(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "admpay_assessment") {	
			EditTypes.Add("default");
			EditTypes.Add("detail");
			ListingTypes.Add("default");
			ListingTypes.Add("detail");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="default";
				Name = "Accertamento del Pagamento Stipendi";
				return GetFormByDllName("admpay_assessment_default");
			}

			if (FormName=="detail") {
				DefaultListType="detail";
				Name = "Accertamento del Pagamento Stipendi";
				return GetFormByDllName("admpay_assessment_detail");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yadmpay");
			RowChange.SetSelector(T, "nadmpay");
			RowChange.MarkAsAutoincrement(T.Columns["nassessment"], null, null, 7);
			return base.Get_New_Row(ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType == "detail") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "nassessment", "Num. Accertamento", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "!codeupb", "Cod. UPB", "upb.codeupb",nPos++);
				DescribeAColumn(T, "!codefin", "Cod. Bilancio", "fin.codefin", nPos++);
				DescribeAColumn(T, "!ymov", "Eserc. Movimento", "incomeview.ymov", nPos++);
				DescribeAColumn(T, "!nmov", "Num. Movimento", "incomeview.nmov", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
			}
			if (ListingType == "default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}
				int nPos = 1;
				DescribeAColumn(T, "yadmpay", "Eserc. Pag. Stipendi", nPos++);
				DescribeAColumn(T, "nadmpay", "Num. Pag. Stipendi", nPos++);
				DescribeAColumn(T, "nassessment", "Num. Accert.", nPos++);
				DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T, "amount", "Importo", nPos++);
			}
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;
			if ((R["idupb"] == DBNull.Value)
				&& (R["idfin"] == DBNull.Value)
				&& (R["idinc"] == DBNull.Value)) {
				errfield = "idupb";
				errmess = "Bisogna necessariamente associare l'accertamento per il pagamento degli stipendi "
					+ "o ad un movimento di entrata esistente o alla coppia upb-bilancio";
				return false;
			}
			return true;
		}
    }
}
