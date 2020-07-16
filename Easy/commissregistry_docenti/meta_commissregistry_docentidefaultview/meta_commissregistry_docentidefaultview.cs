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


namespace meta_commissregistry_docentidefaultview
{
    public class Meta_commissregistry_docentidefaultview : Meta_easydata 
	{
        public Meta_commissregistry_docentidefaultview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "commissregistry_docentidefaultview") {
				Name = "Membri";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idappello","idcommiss","idprova","idreg_docenti"};

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
						DescribeAColumn(T, "registry_docenti_docenti_matricola", "Matricola", nPos++);
						DescribeAColumn(T, "registry_docenti_idreg", "Identificativo", nPos++);
						DescribeAColumn(T, "registry_docenti_docenti_idsasd", "SASD", nPos++);
						DescribeAColumn(T, "registry_docenti_docenti_idstruttura", "Struttura di afferenza", nPos++);
						DescribeAColumn(T, "registry_docenti_title", "Denominazione", nPos++);
						DescribeAColumn(T, "registry_docenti_docenti_idreg_istituti", "Istituto, Ente o Azienda", nPos++);
						DescribeAColumn(T, "registry_docenti_cf", "Codice fiscale", nPos++);
						DescribeAColumn(T, "registry_docenti_docenti_idclassconsorsuale", "Classe consorsuale", nPos++);
						DescribeAColumn(T, "registry_docenti_p_iva", "Partita iva", nPos++);
						DescribeAColumn(T, "registry_docenti_active", "attivo", nPos++);
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
