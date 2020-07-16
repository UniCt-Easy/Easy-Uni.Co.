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


namespace meta_appellodefaultview
{
    public class Meta_appellodefaultview : Meta_easydata 
	{
        public Meta_appellodefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "appellodefaultview") {
				Name = "Appelli";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idappello"};

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
				case "default": {
						DescribeAColumn(T, "description", "Descrizione", nPos++);
						DescribeAColumn(T, "appello_aa", "Anno accademico", nPos++);
						DescribeAColumn(T, "appelloazionekind_title", "Ordinario/Correttivo/Integrativo", nPos++);
						DescribeAColumn(T, "appellokind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "sessione_idsessionekind", "Tipologia Sessione", nPos++);
						DescribeAColumn(T, "sessione_start", "Data di inizio Sessione", nPos++);
						DescribeAColumn(T, "sessione_stop", "Data di fine Sessione", nPos++);
						DescribeAColumn(T, "appello_minvoto", "Voto minimo", nPos++);
						DescribeAColumn(T, "appello_basevoto", "Votazione di base", nPos++);
						DescribeAColumn(T, "appello_prointermedia", "Prova intermedia", nPos++);
						DescribeAColumn(T, "appello_posti", "Numero massimo di posti", nPos++);
						DescribeAColumn(T, "appello_prenotstart", "Data di inizio prenotazioni", nPos++);
						if (T.Columns.Contains("appello_prenotstart")) T.Columns["appello_prenotstart"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "appello_penotend", "Data fine delle prenotazioni", nPos++);
						if (T.Columns.Contains("appello_penotend")) T.Columns["appello_penotend"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "appello_publicato", "Publicato", nPos++);
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
