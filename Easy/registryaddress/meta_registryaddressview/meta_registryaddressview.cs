
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
using metadatalibrary;
using metaeasylibrary;

namespace meta_registryaddressview//meta_cdindirizzoview//
{
	/// <summary>
	/// Summary description for meta_cdindirizzoview
	/// </summary>
	public class Meta_registryaddressview : Meta_easydata {
		public Meta_registryaddressview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "registryaddressview") {
			ListingTypes.Add("default");
			Name="Indirizzo";
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idreg", "Codice Anagrafica", nPos++);
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "addresskind", "Tipo Indirizzo", nPos++);
                DescribeAColumn(T, "officename", "Nome ufficio", nPos++);
                DescribeAColumn(T, "address", "Indirizzo", nPos++);
                DescribeAColumn(T, "city", "Comune", nPos++);
                DescribeAColumn(T, "location", "Località", nPos++);
                DescribeAColumn(T, "nation", "Stato", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
			}
		}
	}
}
