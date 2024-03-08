
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
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_mandatedetailnoddttoinvoice
{

	public class Meta_mandatedetailnoddttoinvoice : Meta_easydata {
        public Meta_mandatedetailnoddttoinvoice (DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "mandatedetailnoddttoinvoice") {
			ListingTypes.Add("default");
			Name = "Dettaglio ordine";
		}
        private string[] mykey = new string[] { "idmankind", "yman", "nman", "rownum" };
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="default"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T,C.ColumnName,"",-1);
                int nPos = 1;
                DescribeAColumn(T, "idmankind", ".idmankind", nPos++);
                DescribeAColumn(T, "mandatekind", "Tipo Ordine", nPos++);
                DescribeAColumn(T, "yman", "Eserc.", nPos++);
                DescribeAColumn(T, "nman", "Num.", nPos++);
                DescribeAColumn(T, "rownum", "N. riga.", nPos++);
                DescribeAColumn(T, "idgroup", "Gruppo", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["taxable"], "n");
                DescribeAColumn(T, "tax", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale", nPos++);
                DescribeAColumn(T, "ordered", "Ordinata", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["ordered"], "n");
                DescribeAColumn(T, "residual", "Da fatturare", nPos++);
				HelpForm.SetFormatForColumn(T.Columns["residual"], "n");
                DescribeAColumn(T, "competencystart", "Inizio Comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine Comp.", nPos++);
                DescribeAColumn(T, "cigcode", "Codice CIG", nPos++);
			}
		}   

	
	}
}

