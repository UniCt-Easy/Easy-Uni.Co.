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


namespace meta_nullaostaimm_seganagstupreview
{
    public class Meta_nullaostaimm_seganagstupreview : Meta_easydata 
	{
        public Meta_nullaostaimm_seganagstupreview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "nullaostaimm_seganagstupreview") {
				Name = "Nullaosta";
			EditTypes.Add("imm_seganagstupre");
			ListingTypes.Add("imm_seganagstupre");
			//$EditTypes$
        }

		private string[] mykey = new string[] {"idistanza","idnullaosta","idreg"};

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
				case "imm_seganagstupre": {
						DescribeAColumn(T, "data", "Data", nPos++);
						if (T.Columns.Contains("data")) T.Columns["data"].ExtendedProperties["format"] = "g";
						DescribeAColumn(T, "nullaosta_protnumero", "Numero di protocollo", nPos++);
						DescribeAColumn(T, "nullaosta_protanno", "Anno di protocollo", nPos++);
						DescribeAColumn(T, "nullaosta_imm_annoimm", "anno di corso di immatricolazione", nPos++);
						DescribeAColumn(T, "didprogcurr_title", "Curriculum", nPos++);
						DescribeAColumn(T, "didprogori_title", "Corso e orientamento", nPos++);
						DescribeAColumn(T, "nullaosta_imm_parttime", "Parttime", nPos++);
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