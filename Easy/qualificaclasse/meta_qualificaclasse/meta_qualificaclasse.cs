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
using metadatalibrary;
using metaeasylibrary;

namespace meta_qualificaclasse//meta_qualificaclasse//
{
	/// <summary>
	/// Summary description for qualificaclasse.
	/// </summary>
	public class Meta_qualificaclasse : Meta_easydata
	{
		public Meta_qualificaclasse(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "qualificaclasse") {		
			ListingTypes.Add("default");
			
			//
			// TODO: Add constructor logic here
			//
		}

		
		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default"){
				DescribeAColumn(T,"codicequalifica","");
				DescribeAColumn(T,"descrizione","Qualifica");
				DescribeAColumn(T,"classe","");
				DescribeAColumn(T,"descrizioneclasse","Classe");
			}
			return;
		}
	}
}

