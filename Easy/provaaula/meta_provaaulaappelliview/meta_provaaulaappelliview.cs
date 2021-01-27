
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
//$CustomUsing$


namespace meta_provaaulaappelliview
{
    public class Meta_provaaulaappelliview : Meta_easydata 
	{
        public Meta_provaaulaappelliview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "provaaulaappelliview") {
				Name = "Aule";
			EditTypes.Add("appelli");
			ListingTypes.Add("appelli");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idappello","idaula","idedificio","idprova","idsede"};

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
				case "appelli": {
						DescribeAColumn(T, "aula_title", "Denominazione", nPos++);
						DescribeAColumn(T, "aula_code", "Codice", nPos++);
						DescribeAColumn(T, "aula_idedificio", "Edificio", nPos++);
						DescribeAColumn(T, "aula_idstruttura", "Struttra didattica di afferenza", nPos++);
						DescribeAColumn(T, "aula_capienza", "Capienza", nPos++);
						DescribeAColumn(T, "aula_capienzadis", "Capienza disabili", nPos++);
						DescribeAColumn(T, "aula_idaulakind", "Tipologia", nPos++);
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
