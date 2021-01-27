
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


namespace meta_casualcontractavailable//meta_contrattooccoperativo//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_casualcontractavailable : Meta_easydata
	{
		public Meta_casualcontractavailable(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "casualcontractavailable") 
		{		
			Name= "Contratti Occasionali da Contabilizzare";
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

        private string[] mykey = new string[] { "ycon", "ncon" };
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
				DescribeAColumn(T, "ycon", "Eserc. Contratto",1);
				DescribeAColumn(T, "ncon", "Num. Contratto",2);
				DescribeAColumn(T, "registry", "Percipiente",3);
				DescribeAColumn(T, "description", "Descrizione",4);
				DescribeAColumn(T, "start", "Data Inizio",5);
				DescribeAColumn(T, "stop", "Data Fine",6);
				//DescribeAColumn(T, "datacontabile", "Data Contabile");
				DescribeAColumn(T, "feegross", "Compenso Lordo",7);
				DescribeAColumn(T, "residual","Residuo",8);
			}
		}
		
	}
}
