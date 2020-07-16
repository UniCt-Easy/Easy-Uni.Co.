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
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_mandatedetail_tostock
{
	public class Meta_mandatedetail_tostock : Meta_easydata {
		public Meta_mandatedetail_tostock(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatedetail_tostock") {
			ListingTypes.Add("default");
            ListingTypes.Add("list");
			Name = "Dettaglio ordine";
		}
	
		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
                int nPos = 1;
                DescribeAColumn(T, "idmankind", ".idmankind", nPos++);
                DescribeAColumn(T, "mandatekind", "Tipo Ordine", nPos++);
                DescribeAColumn(T, "yman", "Eserc", nPos++);
                DescribeAColumn(T, "nman", "Num", nPos++);
                DescribeAColumn(T, "idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "ordered", "Ordinata", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["ordered"], "n");
                DescribeAColumn(T, "stocked", "Immagazzinato", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["stocked"], "n");
                DescribeAColumn(T, "ntostock", "Inevasa", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["ntostock"], "n");
			}
            if (listtype == "list") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "adate", "Data Ordine", nPos++);
                DescribeAColumn(T, "store", "Magazzino", nPos++);
                DescribeAColumn(T, "registry", "Fornitore", nPos++);
                DescribeAColumn(T, "ordered", "Quantit‡ ordinata", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["ordered"], "n");
                DescribeAColumn(T, "ntostock", "Quantit‡ inevasa", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["ntostock"], "n");
                DescribeAColumn(T, "npackage", "N. Confezioni", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["npackage"], "n");  
            }
		}   
	}
}


