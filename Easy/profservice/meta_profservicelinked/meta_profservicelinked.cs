
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
using metaeasylibrary;
using metadatalibrary;


namespace meta_profservicelinked
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_profservicelinked : Meta_easydata
	{
		public Meta_profservicelinked(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "profservicelinked") 
		{		
			Name= "Contratti professionali Contabilizzati";
			ListingTypes.Add("default");
		}

		public override string GetSorting(string ListingType) 
		{
			string sorting;
			if (ListingType=="default") 
			{
				sorting = "ycon desc, ncon desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercizio;
			if (ListingType=="default") {
				filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
				return filteresercizio;
			}
			return base.GetStaticFilter (ListingType);
		}
        private string[] mykey = new string[] { "ayear", "ycon", "ncon" };
        public override string[] primaryKey() {
            return mykey;
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
				DescribeAColumn(T, "ayear", "Esercizio",1);
				DescribeAColumn(T, "ycon", "Eserc. Contratto",2);
				DescribeAColumn(T, "ncon", "Num. Contratto",3);
				DescribeAColumn(T, "registry", "Percipiente",4);
				DescribeAColumn(T, "description", "Descrizione",5);
				DescribeAColumn(T, "start", "Data Inizio",6);
				DescribeAColumn(T, "stop", "Data Fine",7);
				DescribeAColumn(T, "feegross", "Compenso Lordo",8);
				DescribeAColumn(T, "totalcost", "Costo Totale",9);
				DescribeAColumn(T, "adate", "Data Contabile",10);
				DescribeAColumn(T, "ndays", "Durata Giorni",11);
				DescribeAColumn(T, "ivaamount", " Importo IVA",12);
				DescribeAColumn(T, "ivafieldnumber", "Num. Campo IVA",13);
				DescribeAColumn(T, "socialsecurityrate", "Aliq. Cassa di Prev.",14);
				DescribeAColumn(T, "pensioncontributionrate", "Aliq. Contributo Prev.",15);
				DescribeAColumn(T, "ivarate", "Aliq.IVA",16);
				
			}
		}
	}
}
