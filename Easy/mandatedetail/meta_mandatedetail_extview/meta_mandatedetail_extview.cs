
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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_mandatedetail_extview {
    public class Meta_mandatedetail_extview : Meta_easydata {
    public Meta_mandatedetail_extview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "mandatedetail_extview") {
			Name= "Riga Contratto Passivo";
			ListingTypes.Add("dettaglio");
		}
		
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="dettaglio") {
				sorting = "mankind asc,yman desc,nman desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "idmankind", "yman", "nman", "rownum" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "mankind", "Tipo", nPos++);
                DescribeAColumn(T, "yman", "Esercizio", nPos++);
                DescribeAColumn(T, "nman", "Numero", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "description", "Descr. Contr. Pass.", nPos++);
                DescribeAColumn(T, "codeinv", "Class. inventariale", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "taxable", "Importo Unitario", nPos++);
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "ivakind", "Tipo IVA", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "start", "Data inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "codemotive", "Causale EP", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "epkind", ".Tipo EP", nPos++);
                DescribeAColumn(T, "notlinkedtoasset", "Q.tà da inventariare", nPos++);
                DescribeAColumn(T, "linkedtoasset", "Q.tà inventariata", nPos++);
                DescribeAColumn(T, "notlinkedtoinvoice", "Q.tà da fatturare", nPos++);
                DescribeAColumn(T, "linkedtoinvoice", "Q.tà fatturata", nPos++);
                DescribeAColumn(T, "cigcode", "CIG", nPos++);
                DescribeAColumn(T, "yepexp", "Anno impegno di B.", nPos++);
                DescribeAColumn(T, "nepexp", "N. impegno di B.", nPos++);
                DescribeAColumn(T, "yexpimpo", "Anno impegno impon.", nPos++);
                DescribeAColumn(T, "nexpimpo", "N. impegno impon.", nPos++);
                DescribeAColumn(T, "yexpiva", "Anno impegno iva", nPos++);
                DescribeAColumn(T, "nexpiva", "N. impegno iva", nPos++);
                DescribeAColumn(T, "locationcode", "Codice Ubicazione", nPos++);
                DescribeAColumn(T, "location", "Descrizione", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "cashed","Pagato", nPos++);
                DescribeAColumn(T, "tocashed", "Da pagare", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                HelpForm.SetFormatForColumn(T.Columns["notlinkedtoasset"], "n");
                HelpForm.SetFormatForColumn(T.Columns["linkedtoasset"], "n");
                HelpForm.SetFormatForColumn(T.Columns["notlinkedtoinvoice"], "n");
                HelpForm.SetFormatForColumn(T.Columns["linkedtoinvoice"], "n");
			}
		}
	}
}
