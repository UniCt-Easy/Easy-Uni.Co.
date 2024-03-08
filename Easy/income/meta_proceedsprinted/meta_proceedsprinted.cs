
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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

namespace meta_proceedsprinted//meta_incassostampatoview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_proceedsprinted : Meta_easydata
	{
		public Meta_proceedsprinted(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedsprinted")
		{
			Name= "Incasso Stampato";
			ListingTypes.Add("default");
		}

		public override string GetNoRowFoundMessage(string listingtype)
		{
			return "Non sono stati trovati incassi la cui reversale associata sia stata stampata ufficialmente";
		}

        string[] mykey = new string[] { "idinc" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string ListingType) 
		{			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default")
			{
				foreach(DataColumn C in T.Columns) 
				{
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "idinc", "",-1);
				DescribeAColumn(T, "ymov", "Esercizio Movimento",1);
				DescribeAColumn(T, "nmov", "Num. Movimento",2);
				DescribeAColumn(T, "curramount", "Importo Corrente",3);
				DescribeAColumn(T, "amount", "Importo",4);
				DescribeAColumn(T, "npro", "Num. Reversale",5);
				DescribeAColumn(T, "competencydate", "Data Stampa Reversale",6);
			}
		}

	}
}
