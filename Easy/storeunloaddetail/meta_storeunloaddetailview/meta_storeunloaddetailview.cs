
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;


namespace meta_storeunloaddetailview {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_storeunloaddetailview: Meta_easydata {
		public Meta_storeunloaddetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "storeunloaddetailview") {
			Name= "Dettaglio Scarico Magazzino";
            ListingTypes.Add("default");
            ListingTypes.Add("lista");
		}
       
		public override string GetSorting(string ListingType) {
			string sorting;
            if (ListingType == "default") {
				sorting = "idstoreunload asc,idstoreunloaddetail asc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
	
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
            if (listtype == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "idstoreunloaddetail", "Cod.", nPos++);
                DescribeAColumn(T, "number", "Quant.", nPos++);
		        DescribeAColumn(T, "ybooking", "Eserc. Pren.", nPos++);
                DescribeAColumn(T, "nbooking", "Num. Pren.", nPos++);
                DescribeAColumn(T, "manager", "Respons.", nPos++);
                DescribeAColumn(T, "detaildescription", "Descr. Dett.", nPos++);
                DescribeAColumn(T, "invkind", "Tipo Fatt.", nPos++);
                DescribeAColumn(T, "yinv", "Eserc. Fatt.", nPos++);
                DescribeAColumn(T, "ninv", "Num. Fatt.", nPos++);
                DescribeAColumn(T, "rownum", "Num. Dett.", nPos++);
				}
             if (listtype == "lista") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idstoreunloaddetail", "#", nPos++);
                DescribeAColumn(T, "adate", "Data Scarico", nPos++);
                DescribeAColumn(T, "number", "Quantità", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "manager", "Responsabile", nPos++);
                DescribeAColumn(T, "storeunload_motive", "Causale Scarico", nPos++);
                DescribeAColumn(T, "forename", "Nome", nPos++);
                DescribeAColumn(T, "surname", "Cognome", nPos++);
             }
		}   
	
	}
}
