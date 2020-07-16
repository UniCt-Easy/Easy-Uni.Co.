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


namespace meta_affidamentodefaultview
{
    public class Meta_affidamentodefaultview : Meta_easydata 
	{
        public Meta_affidamentodefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "affidamentodefaultview") {
				Name = "Affidamento";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"aa","idaffidamento","idattivform","idcanale","idcorsostudio","iddidprog","iddidproganno","iddidprogcurr","iddidprogori","iddidprogporzanno"};

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
						DescribeAColumn(T, "registry_docenti_title", "Docente", nPos++);
						DescribeAColumn(T, "affidamentokind_title", "Tipologia", nPos++);
						DescribeAColumn(T, "affidamento_riferimento", "Docente di riferimento per il canale", nPos++);
						DescribeAColumn(T, "erogazkind_title", "Tipo di erogazione", nPos++);
						DescribeAColumn(T, "affidamento_freqobbl", "Frequenza obbligatoria", nPos++);
						DescribeAColumn(T, "affidamento_gratuito", "Gratuito", nPos++);
						DescribeAColumn(T, "affidamento_start", "Inizio", nPos++);
						DescribeAColumn(T, "affidamento_stop", "Fine", nPos++);
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
