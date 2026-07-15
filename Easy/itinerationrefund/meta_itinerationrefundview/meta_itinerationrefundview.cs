/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_itinerationrefundview
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itinerationrefundview : Meta_easydata
	{
		public Meta_itinerationrefundview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "itinerationrefundview") {
			ListingTypes.Add("lista");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
			
			if (ListingType == "lista")
			{
				DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
				DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
				DescribeAColumn(T, "registrytitle", "Percipiente", nPos++);
				DescribeAColumn(T, "maindescription", "Descrizione Missione", nPos++);
				DescribeAColumn(T, "statusdescription", "Stato", nPos++);
				DescribeAColumn(T, "start", "Data inizio missione", nPos++);
				DescribeAColumn(T, "stop", "Data fine missione", nPos++);
				DescribeAColumn(T, "nrefund", "Num.Spesa", nPos++);
				DescribeAColumn(T, "itinerationrefundkind", "Tipo Spesa", nPos++);
				DescribeAColumn(T, "description", "Descrizione spesa", nPos++);
				DescribeAColumn(T, "applicabilita", "Applicabilità", nPos++);
				DescribeAColumn(T, "servicedescription", "Prestazione", nPos++);
				DescribeAColumn(T, "starttime", "Data inizio spesa", nPos++);
				DescribeAColumn(T, "stoptime", "Data fine spesa", nPos++);
				DescribeAColumn(T, "requiredamount", "Richiesto", nPos++);
				DescribeAColumn(T, "amount", "Accordato (EURO)", nPos++);				
				DescribeAColumn(T, "taxableexpense", "Assenza pagamento tracciabile (Spesa imponibile)", nPos++);
				DescribeAColumn(T, "traceability", "Richiesta tracciabilità", nPos++);
				DescribeAColumn(T, "attachmentblocking", "Obbligo allegato (Bloccante)", nPos++);
				DescribeAColumn(T, "attachmentnotblocking", "Obbligo allegato (Non Bloccante)", nPos++);
				DescribeAColumn(T, "amountnotincluded", "Trasmesso all'ufficio stipendi", nPos++);
				DescribeAColumn(T, "applytax", "Applica ritenute in assenza di tracciabilità", nPos++);
				DescribeAColumn(T, "sortcode01", "Codice Attr. 1", nPos++);
				DescribeAColumn(T, "sortcode02", "Codice Attr. 2", nPos++);
				DescribeAColumn(T, "sortcode03", "Codice Attr. 3", nPos++);
				DescribeAColumn(T, "sortcode04", "Codice Attr. 4", nPos++);
				DescribeAColumn(T, "sortcode05", "Codice Attr. 5", nPos++);
			}
		}
	}
}
