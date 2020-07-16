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


namespace meta_registry_instmuser
{
    public class Meta_registry_instmuser : Meta_easydata 
	{
        public Meta_registry_instmuser(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registry_instmuser") {
				Name = "Pagina di registrazione";
			EditTypes.Add("instmuser");
			ListingTypes.Add("instmuser");
			EditTypes.Add("instmuser_anagrafica");
			ListingTypes.Add("instmuser_anagrafica");
			//$EditTypes$
        }

		//$PrymaryKey$

		//$SetDefault$

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			
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
				case "instmuser": {
						DescribeAColumn(T, "!idinstmseztematichekind_instmseztematichekind_title", "Sezione tematica prescelta", nPos++);
						DescribeAColumn(T, "!idinstmseztematichekind_2_instmseztematichekind_title", "Seconda sezione tematica prescelta", nPos++);
						DescribeAColumn(T, "!idinstmusercategorykind_instmusercategorykind_title", "Categoria di afferenza", nPos++);
						DescribeAColumn(T, "maritalcf", "Maritalcf", nPos++);
						DescribeAColumn(T, "interest", "Interessi di Ricerca", nPos++);
						DescribeAColumn(T, "newsletter", "Autorizzo l’invio della Newsletter istituzionale", nPos++);
						DescribeAColumn(T, "otherbelonging", "Eventuale afferenza ad altri Consorzi (specificare quale/i, uno per riga):", nPos++);
						DescribeAColumn(T, "privacy", "Presa visione dell’informativa e consenso al trattamento dei dati", nPos++);
						DescribeAColumn(T, "regulationaccept", "Do il consenso", nPos++);
						break;
					}
				case "instmuser_anagrafica": {
						DescribeAColumn(T, "maritalcf", "Maritalcf", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		//$GetSortings$

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}
		
		//$CustomCode$
    }
}
