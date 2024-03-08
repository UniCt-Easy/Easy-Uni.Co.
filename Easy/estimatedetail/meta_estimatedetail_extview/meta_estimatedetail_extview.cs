
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_estimatedetail_extview {
    public class Meta_estimatedetail_extview : Meta_easydata {
		public Meta_estimatedetail_extview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimatedetail_extview") {
			Name= "Riga contratto attivo";
			ListingTypes.Add("dettaglio");
		}
		
		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="dettaglio") {
				sorting = "estimkind asc,yestim desc,nestim desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

        private string[] mykey = new string[] {"idestimkind", "yestim", "nestim", "rownum"};
        public override string[] primaryKey() {
            return mykey;
        }

        public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="dettaglio") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
                DescribeAColumn(T, "estimkind", "Tipo", nPos++);
                DescribeAColumn(T, "yestim", "Esercizio", nPos++);
                DescribeAColumn(T, "nestim", "Numero", nPos++);
                DescribeAColumn(T, "rownum", "Num. riga", nPos++);
                DescribeAColumn(T, "description", "Descr. Contratto Att.", nPos++);
                DescribeAColumn(T, "idinv", "Class. inventariale", nPos++);
                DescribeAColumn(T, "detaildescription", "Descrizione", nPos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
                DescribeAColumn(T, "registry", "Cliente", nPos++);
                DescribeAColumn(T, "number", "Q.tà ordinata", nPos++);
                DescribeAColumn(T, "taxable", "Importo Unitario", nPos++);
                DescribeAColumn(T, "taxable_euro", "Imponibile totale", nPos++);
                DescribeAColumn(T, "ivakind", "Tipo IVA", nPos++);
                DescribeAColumn(T, "iva_euro", "Iva", nPos++);
                DescribeAColumn(T, "rowtotal", "Totale riga", nPos++);
                DescribeAColumn(T, "start", "Data inizio validità", nPos++);
                DescribeAColumn(T, "stop", "Fine val.", nPos++);
                DescribeAColumn(T, "codemotive", "Causale EP", nPos++);
                DescribeAColumn(T, "codefinmotive", "Causale Finanziaria", nPos++);
                DescribeAColumn(T, "codefinmotive_iva", "Causale Finanziaria IVA", nPos++);
                DescribeAColumn(T, "competencystart", "Inizio comp.", nPos++);
                DescribeAColumn(T, "competencystop", "Fine comp.", nPos++);
                DescribeAColumn(T, "notlinkedtoinvoice", "Q.tà da fatturare", nPos++);
                DescribeAColumn(T, "linkedtoinvoice", "Q.tà fatturata", nPos++);
                DescribeAColumn(T, "cashed", "Incassato", nPos++);
                DescribeAColumn(T, "tocash", "Da incassare", nPos++);
                DescribeAColumn(T, "nepacc", "N. accertamento di B.", nPos++);
                DescribeAColumn(T, "yepacc", "Anno accertamento di B.", nPos++);
                DescribeAColumn(T, "yincimpo", "Anno accertamento imponibile", nPos++); //TASK 10761
                DescribeAColumn(T, "nincimpo", "N.accertamento imponibile", nPos++);
                DescribeAColumn(T, "yinciva", "Anno accertamento iva", nPos++);
                DescribeAColumn(T, "ninciva", "N.accertamento iva", nPos++);
                DescribeAColumn(T, "list", "Listino", nPos++);
                DescribeAColumn(T, "codicetassonomia", "Codice tassonomia", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
			}
		}   
	}
}

