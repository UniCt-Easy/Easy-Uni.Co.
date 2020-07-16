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
using metaeasylibrary;
using metadatalibrary;

namespace meta_wageadditiontax//meta_contrattodipritenuta//
{
	/// <summary>
	/// Summary description for Meta_contrattodipritenuta.
	/// </summary>
	public class Meta_wageadditiontax : Meta_easydata
	{
		public Meta_wageadditiontax(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "wageadditiontax") 
		{
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}

		protected override Form GetForm(string FormName) 
		{
			if (FormName=="default") 
			{
				DefaultListType="default";
				Name = "Ritenute";
				return GetFormByDllName("wageadditiontax_default");
			}
			return null;
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns)
				{
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
                int col=1;
				//DescribeAColumn(T,"taxcode","Codice Ritenuta",col++);
                DescribeAColumn(T, "!taxref", "Codice Ritenuta", "tax.taxref", col++);
                DescribeAColumn(T, "!descrizione", "Descrizione", "tax.description", col++);
                DescribeAColumn(T, "taxable", "Imponibile", col++);
                DescribeAColumn(T, "employrate", "Aliquota c/Dip.", col++);
                DescribeAColumn(T, "employtax", "Rit. c/Dip.", col++);
                DescribeAColumn(T, "adminrate", "Aliquota c/Ammin.", col++);
                DescribeAColumn(T, "admintax", "Rit. c/Ammin.", col++);
                DescribeAColumn(T, "!tiporitenuta", ".Tipo Ritenuta", "tax.taxkind", col++);
                DescribeAColumn(T, "!tiporitenuta", ".Tipo Ritenuta", "tax.taxkind", col++);
                HelpForm.SetFormatForColumn(T.Columns["employrate"], "p");
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
			}
		}
	}
}
