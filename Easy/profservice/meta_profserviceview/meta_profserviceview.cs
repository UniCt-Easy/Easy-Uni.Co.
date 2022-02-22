
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_profserviceview {//meta_contrattoprofview//
	/// <summary>
	/// Summary description for Meta_contrattoprofview.
	/// </summary>
	public class Meta_profserviceview : Meta_easydata {
		public Meta_profserviceview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "profserviceview") {
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "ycon", "ncon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T,C.ColumnName,"",-1);
				}
				int nPos = 1;
				DescribeAColumn(T,"ycon","Eserc. Contratto",nPos++);
				DescribeAColumn(T,"ncon","Num. Contratto",nPos++);
				DescribeAColumn(T,"registry","Percipiente",nPos++);
				DescribeAColumn(T,"description","Descrizione",nPos++);
				DescribeAColumn(T,"codeser","Cod. Prestazione",nPos++);
				DescribeAColumn(T,"service","Prestazione",nPos++);
				DescribeAColumn(T,"start","Data Inizio",nPos++);
				DescribeAColumn(T,"stop","Data Fine",nPos++);
				DescribeAColumn(T,"adate","Data Contabile",nPos++);
				DescribeAColumn(T,"ndays","Durata (Giorni)",nPos++);
				DescribeAColumn(T,"feegross","Importo Totale",nPos++);
				DescribeAColumn(T,"totalcost","Costo Totale",nPos++);
				DescribeAColumn(T,"ivarate","Aliquota IVA",nPos++);
				DescribeAColumn(T,"ivaamount","Importo IVA",nPos++);
				DescribeAColumn(T,"doc","Documento",nPos++);
				DescribeAColumn(T,"docdate","Data Documento",nPos++);
				DescribeAColumn(T,"idinvkind",".#Cod. Doc IVA",nPos++);
                DescribeAColumn(T,"codeinvkind", "Cod. Doc IVA", nPos++);
				DescribeAColumn(T,"invkind","Doc IVA",nPos++);
				DescribeAColumn(T,"yinv","Eserc. Doc IVA",nPos++);
				DescribeAColumn(T,"ninv","Num. Doc IVA",nPos++);
				DescribeAColumn(T,"flagexcludefromcertificate","Escludi da CU",nPos++); 
			}
		}
	}
}
