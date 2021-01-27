
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_estimateavailable
{
	/// <summary>
	/// Summary description for estimateavailable
	/// </summary>
	public class Meta_estimateavailable : Meta_easydata {
	
		public Meta_estimateavailable(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimateavailable")  {
			Name= "Contabilizzazione contratto attivo";
			ListingTypes.Add("default");
		}
	
		public override string GetSorting(string ListingType)
		{
			string sorting;
			if (ListingType=="default")
			{
				sorting = "estimkind asc,yestim desc,nestim desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] {  "idestimkind", "yestim", "nestim" };
        public override string[] primaryKey() {
            return mykey;
        }



        public override void DescribeColumns(DataTable T, string ListingType) 
		{			
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "estimkind", "Tipo",1);
				DescribeAColumn(T, "yestim", "Esercizio",2);
				DescribeAColumn(T, "nestim", "Numero",3);
				DescribeAColumn(T, "registry", "Cliente",4);
				DescribeAColumn(T, "description", "Descrizione",5);
				DescribeAColumn(T, "taxabletotal","Tot.Imponibile",6);
				DescribeAColumn(T, "ivatotal","Tot.IVA",7);
				DescribeAColumn(T, "linkedtotal","Tot.Contabilizzato",8);
				DescribeAColumn(T, "residual","Tot.Residuo",9);
			}
		}
	}
}
