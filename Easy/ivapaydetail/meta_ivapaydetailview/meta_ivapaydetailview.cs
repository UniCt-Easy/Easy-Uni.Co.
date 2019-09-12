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

namespace meta_ivapaydetailview{//meta_dettliquidazioneivaview//
	/// <summary>
	/// Summary description for meta_dettliquidazioneivaview
	/// </summary>
	public class Meta_ivapaydetailview : Meta_easydata {
		public Meta_ivapaydetailview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "ivapaydetailview") {		
			ListingTypes.Add("liquidazione_debito");
			ListingTypes.Add("liquidazione_credito");
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns (T, ListingType);

			if (ListingType=="liquidazione_debito") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
                int nPos = 1;
                DescribeAColumn(T, "idivaregisterkind", ".#", nPos++);
                DescribeAColumn(T, "department", "Dipartimento", nPos++);
                DescribeAColumn(T, "codeivaregisterkind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "ivatotal", "IVA", nPos++);
				FilterRows(T);
			}
			if (ListingType=="liquidazione_credito") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
				int nPos = 1;
				DescribeAColumn(T,"idivaregisterkind",".#",nPos++);
                DescribeAColumn(T,"department","Dipartimento", nPos++);
                DescribeAColumn(T, "codeivaregisterkind", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
				DescribeAColumn(T,"ivatotal","IVA Totale",nPos++);
				DescribeAColumn(T,"unabatabletotal","Indetraibile",nPos++);
				DescribeAColumn(T,"prorata","Prorata",nPos++);
				DescribeAColumn(T,"mixed","Promiscuo",nPos++);
				DescribeAColumn(T,"!ivacredit","IVA a credito",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["prorata"],"p");
				HelpForm.SetFormatForColumn(T.Columns["mixed"],"p");
				FilterRows(T);
			}
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type=="liquidazione_debito") {
                if ((R["registerclass"].ToString().ToUpper() == "V") 
                    || ((R["registerclass"].ToString().ToUpper() == "A") && (R["flagactivity"].ToString()=="1"))) return true;
				return false;
			}
			if (list_type=="liquidazione_credito") {
				if ((R["registerclass"].ToString().ToUpper()=="A") && (R["flagactivity"].ToString()!="1")) return true;
				return false;
			}
			return true;
		}

	}
}
