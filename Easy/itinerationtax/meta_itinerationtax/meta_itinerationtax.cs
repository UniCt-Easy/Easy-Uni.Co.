
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
using metadatalibrary;
using metaeasylibrary;


namespace meta_itinerationtax//meta_missioneritenuta//
{
	/// <summary>
	/// Summary description for missioneritenuta.
	/// </summary>
	public class Meta_itinerationtax : Meta_easydata 
	{
		public Meta_itinerationtax(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "itinerationtax") 
	{
		
		ListingTypes.Add("default");
			
	}

			
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns(T,ListingType);
			if (ListingType=="default") 
			{
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                //DescribeAColumn(T, "taxcode", "Codice");
                DescribeAColumn(T, "!taxref", "Codice", "tax.taxref", nPos++);
				DescribeAColumn(T, "!ritenuta", "Descrizione","tax.description", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                DescribeAColumn(T, "employrate", "Aliq. dip.", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["employrate"],"p");
                DescribeAColumn(T, "employtax", "Rit. dip.", nPos++);
                DescribeAColumn(T, "adminrate", "Aliq. amm.", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["adminrate"],"p");
                DescribeAColumn(T, "admintax", "Rit. amm.", nPos++);
			}
			
		}   	

	}
}
