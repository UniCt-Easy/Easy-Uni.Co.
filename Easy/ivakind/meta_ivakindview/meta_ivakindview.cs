
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
 

namespace meta_ivakindview//meta_tipoiva//
{
	/// <summary>
	/// Summary description for tipooperazioneiva.
	/// </summary>
	public class Meta_ivakindview : Meta_easydata {
		public Meta_ivakindview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivakindview") {		
			ListingTypes.Add("default");

		}
		
 

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType=="default"){
				foreach (DataColumn C in T.Columns) 
					DescribeAColumn(T, C.ColumnName,"", -1);
                int nPos = 1;
                DescribeAColumn(T, "idivakind", ".#", nPos++);
                DescribeAColumn(T, "codeivakind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "unabatabilitypercentage", "Indetraibilità", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["unabatabilitypercentage"], "p");
                DescribeAColumn(T, "rate", "Aliquota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["rate"], "p");
				DescribeAColumn(T, "ivataxablekind", "Tipo imposizione", nPos++);
				DescribeAColumn(T, "fenature", "Natura Esenzione FE", nPos++);


			}
		}
 
 
    }
}
