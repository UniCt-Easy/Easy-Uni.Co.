
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_itinerationrefundkindview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationrefundkindview : Meta_easydata 
	{
		public Meta_itinerationrefundkindview(DataAccess Conn, MetaDataDispatcher Dispatcher):
		base(Conn, Dispatcher, "itinerationrefundkindview") {
			ListingTypes.Add("default");
		}

		public override void DescribeColumns(DataTable T, string ListingType){
			base.DescribeColumns(T, ListingType);
			if ( ListingType== "default")
			{
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
				DescribeAColumn(T, "codeitinerationrefundkind","Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "itinerationrefundkindgroup", "Tipo", nPos++);
                DescribeAColumn(T, "motive", "Causale", nPos++);
                DescribeAColumn(T, "traceability", "Richiesta tracciabilità", nPos++);
                DescribeAColumn(T, "attachmentblocking", "Obbligo allegato (Bloccante)", nPos++);
                DescribeAColumn(T, "attachmentnotblocking", "Obbligo allegato (Non Bloccante)", nPos++);
                DescribeAColumn(T, "amountnotincluded", "Trasmesso all'ufficio stipendi", nPos++);
                DescribeAColumn(T, "applytax", "Applica ritenute in assenza di tracciabilità", nPos++);
			}
		}

	}
	
}
