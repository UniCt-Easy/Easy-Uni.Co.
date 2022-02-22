
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;

namespace meta_wageadditionlinked//meta_contrattodipcontabilizzato//
{
	/// <summary>
	/// Summary description for Meta_contrattodipcontabilizzato.
	/// </summary>
	public class Meta_wageadditionlinked : Meta_easydata
	{
		public Meta_wageadditionlinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "wageadditionlinked") 
		{
            Name = "Altri Compensi Contabilizzati";
			ListingTypes.Add("default");
			
		}
        private string[] mykey = new string[] { "ayear","ycon", "ncon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting = "ycon desc, ncon desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = "(ayear='"+GetSys("esercizio").ToString()+"')";
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}

		public override void DescribeColumns(DataTable T, string ListingType)
		{
			base.DescribeColumns (T, ListingType);
			if (ListingType == "default")
			{
				foreach(DataColumn C in T.Columns) 
				{
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "ycon", "Eserc. Contratto", nPos++);
                DescribeAColumn(T, "ncon", "Num. Contratto", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "ndays", "Durata Giorni", nPos++);
                DescribeAColumn(T, "feegross", "Compenso Lordo", nPos++);
                DescribeAColumn(T, "adate", "Data Contabile", nPos++);

			}
		}
	}
}
