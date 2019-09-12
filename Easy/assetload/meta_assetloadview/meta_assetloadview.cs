/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace meta_assetloadview//meta_buonocaricoinventarioview//
{
	/// <summary>
	/// Summary description for buonocaricoinventarioview.
	/// </summary>
	public class Meta_assetloadview : Meta_easydata
	{
		public Meta_assetloadview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetloadview") 
		{		
			ListingTypes.Add("default");
			Name="buoni di carico inventariali";			
		}
        public override string GetSorting(string ListingType) {
            if (ListingType=="default") return "yassetload DESC, nassetload DESC";

            return base.GetSorting(ListingType);
        }
        private string[] mykey = new string[] { "idassetload" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"");
                int nPos = 1;
				//DescribeAColumn(T,"idassetloadkind","Cod. tipo buono",1);
                DescribeAColumn(T, "assetloadkind", "Tipo buono", nPos++);
                DescribeAColumn(T, "yassetload", "Eserc. buono", nPos++);
                DescribeAColumn(T, "nassetload", "Num. buono", nPos++);
                DescribeAColumn(T, "registry", "Cedente", nPos++);
                DescribeAColumn(T, "assetloadmotive", "Causale carico", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data doc.", nPos++);
                DescribeAColumn(T, "enactment", "Provvedimento", nPos++);
                DescribeAColumn(T, "enactmentdate", "Data provv.", nPos++);
                DescribeAColumn(T, "adate", "Data contabile", nPos++);
                DescribeAColumn(T, "printdate", "Data stampa", nPos++);
                DescribeAColumn(T, "ratificationdate", "Data ratifica", nPos++);
                DescribeAColumn(T, "totalassetacquire", "Totale Carichi", nPos++);
                DescribeAColumn(T, "assetamortizationamount", "Totale Rivalutazioni", nPos++);
                DescribeAColumn(T, "totalassetload", "Totale Buono", nPos++);
            }
        }
	}
}

