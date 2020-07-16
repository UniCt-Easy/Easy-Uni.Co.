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
using metaeasylibrary;
using metadatalibrary;

namespace meta_proceedssupposed//meta_incassipresuntiview//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_proceedssupposed : Meta_easydata
	{
		public Meta_proceedssupposed(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedssupposed")
		{
			Name= "Incassi Presunti al 31/12";
			ListingTypes.Add("default");
		}

		public override string GetNoRowFoundMessage(string listingtype)
		{
			return "Non sono stati trovati incassi presunti da visualizzare";
		}

        string[] mykey = new string[] { "idinc" ,"ayear"};
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
				DescribeAColumn(T, "description","Fase",1);
				DescribeAColumn(T, "ymov", "Esercizio Movimento",2);
				DescribeAColumn(T, "nmov", "Num. Movimento",3);
				DescribeAColumn(T, "curramount", "Importo Corrente",4);
				DescribeAColumn(T, "available", "Importo Disponibile",5);
				DescribeAColumn(T, "adate", "Data Contabile Movimento",6);
				DescribeAColumn(T, "expiration","Data Scadenza Mov.",7);
				DescribeAColumn(T, "npro", "Numero Reversale",8);
				DescribeAColumn(T, "proceedsadate", "Data Contabile Reversale",9);
				DescribeAColumn(T, "nproceedstransmission", "Numero Distinta di Trasm.",10);
				DescribeAColumn(T, "transmissiondate","Data Trasmissione Distinta",11);
			}
		}
	}
}
