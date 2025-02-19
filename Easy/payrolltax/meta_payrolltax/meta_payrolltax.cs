
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

namespace meta_payrolltax {//meta_cedolinoritenuta//
	/// <summary>
	/// Summary description for Meta_cedolinoritenuta.
	/// </summary>
	public class Meta_payrolltax : Meta_easydata {
		public Meta_payrolltax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "payrolltax") {		
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) {
			switch (FormName) {
				case "default":
                    Name = "Ritenuta Cedolino";
					DefaultListType = "default";
					return MetaData.GetFormByDllName("payrolltax_default");
				case "readonly":
                    Name = "Ritenuta Cedolino";
					DefaultListType = "default";
					return MetaData.GetFormByDllName("payrolltax_default");
				default: return null;
			}
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T,"idpayroll");
			RowChange.MarkAsAutoincrement(T.Columns["idpayrolltax"],null,null,0,false);
			return base.Get_New_Row (ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in	T.Columns) DescribeAColumn(T,C.ColumnName,"");
				int n = 1;
				DescribeAColumn(T, "idpayroll", "Cedolino",n++);
				DescribeAColumn(T, "idpayrolltax", "Ritenuta",n++);
				DescribeAColumn(T, "taxref","Cod. Riten.", "tax.taxref", n++);
				DescribeAColumn(T, "!descrritenuta","Descr. Ritenuta","tax.description",n++);
				DescribeAColumn(T, "taxablenet", "Imponibile Netto",n++);
				DescribeAColumn(T, "employtax","Importo Rit. c/Dip. Netto",n++);
				DescribeAColumn(T, "admintax","Importo Rit. c/Ammin. Netto",n++);
			}
		}
	}
}
