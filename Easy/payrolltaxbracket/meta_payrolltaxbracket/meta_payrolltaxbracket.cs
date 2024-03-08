
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_payrolltaxbracket//meta_cedolinoritenutascaglione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_payrolltaxbracket : Meta_easydata 
	{
		public Meta_payrolltaxbracket(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "payrolltaxbracket") 
		{		
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{
			RowChange.SetSelector(T,"idpayroll");
			RowChange.SetSelector(T,"idpayrolltax");
			RowChange.MarkAsAutoincrement(T.Columns["nbracket"], null, null, 6);
			return base.Get_New_Row(ParentRow, T);
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			DescribeAColumn(T, "idpayroll", "");
			DescribeAColumn(T, "idpayrolltax", "");
			DescribeAColumn(T, "nbracket", "Scaglione");
			DescribeAColumn(T, "taxable", "Imponibile");
			DescribeAColumn(T, "employrate", "Aliquota dip.");
			DescribeAColumn(T, "employtax", "Ritenuta dip.");
			DescribeAColumn(T, "adminrate", "Aliquota ammin.");
			DescribeAColumn(T, "admintax", "Ritenuta ammin.");
			HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
			HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
		}
	}
}
