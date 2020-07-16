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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
//$CustomUsing$


namespace meta_protocollosegview
{
    public class Meta_protocollosegview : Meta_easydata 
	{
        public Meta_protocollosegview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "protocollosegview") {
				Name = "Registrazioni di protocollo";
			EditTypes.Add("seg");
			ListingTypes.Add("seg");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"protanno","protnumero"};

		public override string[] primaryKey() {
			return mykey;
		}

		//$SetDefault$

		//$Get_New_Row$

		//$IsValid$

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "seg": {
						DescribeAColumn(T, "protnumero", "Numero di protocollo", nPos++);
						DescribeAColumn(T, "protanno", "Anno di protocollo", nPos++);
						DescribeAColumn(T, "protocollo_protdata", "Data di protocollo", nPos++);
						DescribeAColumn(T, "protocollo_codiceregistro", "Codice Registro (univoco nell'Istituto)", nPos++);
						DescribeAColumn(T, "protocollo_codiceammipa", "Codice IPA dell'Istituto", nPos++);
						DescribeAColumn(T, "aoo_title", "Area organizzativa omogenea", nPos++);
						DescribeAColumn(T, "registryorigine_title", "Mittente", nPos++);
						DescribeAColumn(T, "protocollo_originemail", "E-mail mittente", nPos++);
						DescribeAColumn(T, "protocollo_originecodiceaoo", "Amministrazione pubblica mittente - Codice IPA area organizzativa omogenea", nPos++);
						DescribeAColumn(T, "protocollo_origineidamm", "Amministrazione pubblica mittente - Codice IPA", nPos++);
						DescribeAColumn(T, "protocollo_oggetto", "Oggetto del documento", nPos++);
						DescribeAColumn(T, "protocollo_annullato", "Annullato", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		//$GetStaticFilter$
		
		//$CustomCode$
    }
}
