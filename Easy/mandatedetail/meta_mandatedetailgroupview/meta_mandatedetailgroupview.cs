/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_mandatedetailgroupview{
	public class Meta_mandatedetailgroupview: Meta_easydata 
	{
		public Meta_mandatedetailgroupview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatedetailgroupview") 
		{
			Name= "Riga Contratto Passivo";
			ListingTypes.Add("dettaglio");
		}

		public override string GetSorting(string ListingType) 
		{
			string sorting;
			if (ListingType=="dettaglio") 
			{
				sorting = "mankind asc,yman desc,nman desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "idmankind", "yman", "nman", "idgroup" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype)
		{
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") 
			{
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T, "mankind","Tipo",1);
				DescribeAColumn(T, "yman","Esercizio",2);
				DescribeAColumn(T, "nman","Numero",3);
//				DescribeAColumn(T, "rownum","Num. riga",4);
				DescribeAColumn(T, "idgroup","Num. riga",4);
				DescribeAColumn(T, "idinv","Class. inventariale",5);
				DescribeAColumn(T, "detaildescription", "Descrizione",6);
				DescribeAColumn(T, "registry", "Percipiente",7);
				DescribeAColumn(T, "number", "Q.t‡ ordinata",8);
				DescribeAColumn(T,"start","Inizio val.",9);
				DescribeAColumn(T,"stop","Fine val.",10);
				HelpForm.SetFormatForColumn(T.Columns["number"], "n");
				
			}
		}   
	
	}
}
