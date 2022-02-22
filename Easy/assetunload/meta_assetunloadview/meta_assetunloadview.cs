
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
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_assetunloadview{//meta_buonoscaricoinventarioview//
	/// <summary>
	/// Summary description for Meta_buonoscaricoinventarioview.
	/// </summary>
	public class Meta_assetunloadview : Meta_easydata {
		public Meta_assetunloadview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetunloadview") {		
			ListingTypes.Add("default");
			Name="buoni di scarico inventariali";			
		}

        public override string GetSorting(string listtype){
            if (listtype == "default")
                return "yassetunload DESC,nassetunload DESC";
            return base.GetSorting(listtype);

        }
        private string[] mykey = new string[] { "idassetunload" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");
                int nPos = 1;
				//DescribeAColumn(T,"idassetunloadkind","Cod. tipo buono",1);
				DescribeAColumn(T,"assetunloadkind","Tipo buono",nPos++);
				DescribeAColumn(T,"yassetunload","Eserc. buono",nPos++);
				DescribeAColumn(T,"nassetunload","Num. buono",nPos++);
				DescribeAColumn(T,"registry","Cessionario",nPos++);
				DescribeAColumn(T,"assetunloadmotive","Causale scarico",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "printdate", "Data stampa", nPos++);
                DescribeAColumn(T, "ratificationdate", "Data ratifica", nPos++);
                DescribeAColumn(T, "assetcurrentvalue", "Totale Scarichi", nPos++);
                DescribeAColumn(T, "assetamortizationamount", "Totale Rivalutazioni", nPos++);
                DescribeAColumn(T, "totalassetunload", "Totale Buono", nPos++);
            }
		}
	}
}

