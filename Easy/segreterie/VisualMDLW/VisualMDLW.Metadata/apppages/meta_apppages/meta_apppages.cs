/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
//$CustomUsing$


namespace meta_apppages
{
    public class Meta_apppages : Meta_easydata 
	{
        public Meta_apppages(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "apppages") {
				Name = "Interfacce (pincipale)";
			EditTypes.Add("default");
			ListingTypes.Add("default");
			EditTypes.Add("child");
			ListingTypes.Add("child");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
			RowChange.MarkAsAutoincrement(T.Columns["idapppages"], null, null, 0);
			RowChange.setMinimumTempValue(T.Columns["idapppages"], 9990000);
			//$Get_New_Row$

			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			//$IsValid$

			return true;
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;
					
			switch (ListingType) {
				case "default": {
						DescribeAColumn(T, "!idapplicazione_applicazione_title", "Applicazione", nPos++);
						DescribeAColumn(T, "tablename", "Tabella", nPos++);
						DescribeAColumn(T, "idapppages", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Titolo", nPos++);
						DescribeAColumn(T, "!idmenuweb_menuweb_label", "Voce di Menù madre", nPos++);
						DescribeAColumn(T, "principale", "Principale", nPos++);
						DescribeAColumn(T, "editlistingtype", "Edit Listing Type", nPos++);
						DescribeAColumn(T, "icon", "Icona", nPos++);
						DescribeAColumn(T, "autosearch", "Ricerca automatica all'apertura", nPos++);
						DescribeAColumn(T, "othersapp", "Metadato condiviso con altre app", nPos++);
						DescribeAColumn(T, "anonimous", "Pagina ad accesso anonimo", nPos++);
						break;
					}
				case "child": {
						DescribeAColumn(T, "anonimous", "Pagina ad accesso anonimo", nPos++);
						DescribeAColumn(T, "autosearch", "Ricerca automatica all'apertura", nPos++);
						DescribeAColumn(T, "idapppages", "Identificativo", nPos++);
						DescribeAColumn(T, "title", "Titolo", nPos++);
						DescribeAColumn(T, "tablename", "Tabella", nPos++);
						DescribeAColumn(T, "principale", "Principale", nPos++);
						DescribeAColumn(T, "!idmenuweb_menuweb_label", "Voce di Menù madre", nPos++);
						DescribeAColumn(T, "othersapp", "Metadato condiviso con altre app", nPos++);
						DescribeAColumn(T, "editlistingtype", "Edit Listing Type", nPos++);
						DescribeAColumn(T, "icon", "Icona", nPos++);
						DescribeAColumn(T, "staticfilter", "Filtro statico sul metadato applicato alle query", nPos++);
						DescribeAColumn(T, "vocabolario", "Vocabolario", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "child": {
						return "tablename desc, title desc";
					}
				//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		       public string GeneratePages(JValue prm1, JValue prm2)
        {
            return "ok GeneratePages " + prm1.ToString() + " " + prm2.ToString();
        }
public string GenerateDetail(JValue prm1) {
			var errmsg = "";
			base.dbConn.CallSP("GenerateAppPageDetail", new string[1] {prm1.ToString()}, -1, out errmsg);
			if (string.IsNullOrEmpty(errmsg))
				return "OK. Sono stati generati i dettagli per la pagina con id " + prm1.ToString();
			else
				return "KO. " + errmsg;
		}
//$CustomCode$
    }
}
