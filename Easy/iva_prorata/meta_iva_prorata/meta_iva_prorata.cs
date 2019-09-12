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
using metadatalibrary;
using metaeasylibrary;
//Pino: using iva_prorata; diventato inutile
using System.Data;

namespace meta_iva_prorata//meta_iva_prorata//
{
	public class Meta_iva_prorata : Meta_easydata {
		public Meta_iva_prorata(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "iva_prorata") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			Name = "Prorata";
		}

		protected override Form GetForm(string EditType) {
			if (EditType=="default") {
				ActAsList();
				DefaultListType="default";
				return MetaData.GetFormByDllName("iva_prorata_default");//PinoRana
			}
			return null;
		}

		public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"");
				DescribeAColumn(T,"nprorata","Numero");
				DescribeAColumn(T,"prorata","Prorata");
				HelpForm.SetFormatForColumn(T.Columns["prorata"],"p");
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["nprorata"],null,null,6);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable,"ayear",GetSys("esercizio"));
			SetDefault(PrimaryTable,"prorata",1);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid (R, out errmess, out errfield)) return false;

			if (R["prorata"].ToString()=="") {
				errfield="prorata";
				errmess="Specificare la prorata";
				return false;
			}

			return true;
		}

	}
}
