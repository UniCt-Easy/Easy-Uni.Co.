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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_profserviceresidual {

	public class Meta_profserviceresidual : Meta_easydata {
		public Meta_profserviceresidual(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "profserviceresidual") {
			Name = "Prestazioni professionali da contabilizzare";
			ListingTypes.Add("default");
		}
        private string[] mykey = new string[] { "ycon","ncon" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType=="default") {
				foreach(DataColumn C in T.Columns) DescribeAColumn(T,C.ColumnName,"",-1);
				int pos=1;
				DescribeAColumn(T,"ycon","Eserc. Contratto",pos++);
				DescribeAColumn(T,"ncon","Num. Contratto",pos++);
				DescribeAColumn(T,"registry","Percipiente",pos++);
				DescribeAColumn(T,"description","Descrizione",pos++);
				DescribeAColumn(T,"start","Data Inizio",pos++);
				DescribeAColumn(T,"stop","Data Fine",pos++);
				DescribeAColumn(T,"adate","Data Contabile",pos++);
				DescribeAColumn(T,"feegross","Importo Totale",pos++);
				DescribeAColumn(T,"residual","Importo Residuo",pos++);
			}
		}
	}
}
