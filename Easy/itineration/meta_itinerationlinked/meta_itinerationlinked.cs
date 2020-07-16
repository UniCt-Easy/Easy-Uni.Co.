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

using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;


namespace meta_itinerationlinked
{
	/// <summary>
    /// Summary description for meta_itinerationlinked.
	/// </summary>
	public class Meta_itinerationlinked : Meta_easydata 
	{
		public Meta_itinerationlinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "itinerationlinked") 
		{
			Name = "Missioni contabilizzate";
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] {"ayear" ,"iditineration" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="default") {
				sorting = "yitineration desc,nitineration desc";
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
		public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="default") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "yitineration", "Eserc. miss.", nPos++);
                DescribeAColumn(T, "nitineration", "Num. miss.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "idreg", ".Cod. Percipiente", nPos++);
                DescribeAColumn(T, "registry", "Denom. Pericipiente", nPos++);
                DescribeAColumn(T, "codeser", ".Cod. Prestazione", nPos++);
                DescribeAColumn(T, "service", "Prestazione", nPos++);
                DescribeAColumn(T, "authorizationdate", "Data autorizz.", nPos++);
                DescribeAColumn(T, "start", "Data inizio", nPos++);
                DescribeAColumn(T, "stop", "Data fine", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "netfee", "Tot. netto missione", nPos++);
                DescribeAColumn(T, "totalgross", "Tot. lordo missione", nPos++);
                DescribeAColumn(T, "total", "Tot. globale missione", nPos++);
                DescribeAColumn(T, "totadvance", "Anticipo", nPos++);
                DescribeAColumn(T, "admincarkmcost", ".Imp. Km. mezzo amministrazione", nPos++);
                DescribeAColumn(T, "owncarkmcost", ".Imp. Km. mezzo proprio", nPos++);
                DescribeAColumn(T, "footkmcost", ".Imp. Km. mezzo piedi", nPos++);
                DescribeAColumn(T, "admincarkm", ".Km. mezzo amministrazione", nPos++);
                DescribeAColumn(T, "owncarkm", ".Km. mezzo proprio", nPos++);
                DescribeAColumn(T, "footkm", ".Km. mezzo piedi", nPos++);
				DescribeAColumn(T, "grossfactor", ".Coeff. di lordizzazione");
			}
			
		}   
	}
}
