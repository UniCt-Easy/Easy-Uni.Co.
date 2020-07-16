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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;
using System.Data;


namespace meta_motive770serviceview//meta_cdcausale770prestazione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_motive770serviceview : Meta_easydata
	{
		public Meta_motive770serviceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "motive770serviceview") 
		{		
			Name="Abbinamento prestazione con la causale del modello 'Certificazione Unica'";
			EditTypes.Add("default");
			ListingTypes.Add("default");
		}
		 
		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default") 
			{
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                int pos = 1;
                DescribeAColumn(T, "ayear", "Anno Dichiarazione", pos++);
				DescribeAColumn(T, "codeser", "Cod.prestaz.", pos++);
                DescribeAColumn(T, "servicecode770", "Cod.prestaz. 770", pos++);
                DescribeAColumn(T, "service", "Prestaz.", pos++);
                DescribeAColumn(T, "exemptioncode", "Cod.causale esenzione", pos++);
                DescribeAColumn(T, "module", "Modulo", pos++);
                DescribeAColumn(T, "rec770kind", "Record Certificazione Unica / 770", pos++);
                DescribeAColumn(T, "exemptioncode", "Codice Esenzione", pos++);
                DescribeAColumn(T, "exemptiondescr", "Descr. Esenzione", pos++);
             

            }
		}

	}
}
