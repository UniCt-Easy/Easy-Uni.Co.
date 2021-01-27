
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

namespace meta_profservicetax//meta_contrattoprofritenuta//
{
	/// <summary>
	/// Summary description for Meta_contrattoprofritenuta.
	/// </summary>
	public class Meta_profservicetax : Meta_easydata
	{
		public Meta_profservicetax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "profservicetax")
		{
			ListingTypes.Add("default");
		}
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns)
				{
					C.Caption = "";
				}
				DescribeAColumn(T,"!taxref","Codice Ritenuta","tax.taxref");
				DescribeAColumn(T,"!descrizione","Descrizione","tax.description");
				DescribeAColumn(T,"taxablenet","Imponibile Netto");
				DescribeAColumn(T,"employrate","Aliquota c/Dip.");
				DescribeAColumn(T,"employtax","Rit. c/Dip.");
				DescribeAColumn(T,"adminrate","Aliquota c/Ammin.");
				DescribeAColumn(T,"admintax","Rit. c/Ammin.");
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
			}
		}
	}
}
