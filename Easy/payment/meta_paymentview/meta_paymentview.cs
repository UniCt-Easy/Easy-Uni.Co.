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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_paymentview{//meta_documentopagamentoview//
    /// <summary>
    /// Summary description for Class1.
    /// Updated by Leo 12 Dec 2002
    /// </summary>
    public class Meta_paymentview : Meta_easydata {
        public Meta_paymentview(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "paymentview") {
			EditTypes.Add("esitazionemultipla");
			ListingTypes.Add("lista");
            ListingTypes.Add("listapermovbancario");
			ListingTypes.Add("esitazionemultipla");
			Name = "mandati di pagamento";
    
        }
		public override string GetSorting(string ListingType) {
			if (ListingType=="lista")return "ypay desc, npay desc";
			return base.GetSorting (ListingType);
		}
        private string[] mykey = new string[] { "kpay" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "lista") return QHS.CmpEq("ypay", Conn.GetSys("esercizio"));
            return base.GetStaticFilter(ListingType);
        }

		public override string GetNoRowFoundMessage(string listingtype) {
			if (listingtype == "listapermovbancario") {
				return "Non esistono mandati da esitare con le condizioni impostate";
			}
			return base.GetNoRowFoundMessage(listingtype);
		}

        public override void DescribeColumns(DataTable T, string ListingType){
            base.DescribeColumns(T, ListingType);
			switch (ListingType) {
				case "listapermovbancario": {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "",-1);
					int pos=1;
					DescribeAColumn(T,"ypay","Eserc.Doc",pos++);
					DescribeAColumn(T,"npay","Num. Doc.",pos++);
					DescribeAColumn(T,"adate","Data contabile",pos++);
					DescribeAColumn(T,"printdate","Data di stampa",pos++);
					DescribeAColumn(T,"transmissiondate","Data di trasm.",pos++);
					break;
				}
				case "lista": {
					// annullo tutti i column name
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName,"",-1);
					int pos=1;
					DescribeAColumn(T, "ypay", "Eserc. doc.",pos++);
					DescribeAColumn(T, "npay", "Num. doc.",pos++);
                    DescribeAColumn(T, "npay_treasurer", "Num. doc. Cass.", pos++);
					DescribeAColumn(T, "stamphandling", "Bollo",pos++);
					DescribeAColumn(T, "kind", "Tipo",pos++);
					DescribeAColumn(T, "registry", "Percipiente",pos++);
					DescribeAColumn(T, "codefin", "Voce bil.",pos++);
					DescribeAColumn(T, "finance", "Denom. bil.",pos++);
					DescribeAColumn(T, "manager", "Responsabile",pos++);
					DescribeAColumn(T, "ypaymenttransmission", "Eserc. elenco",pos++);
					DescribeAColumn(T, "npaymenttransmission", "Num. elenco",pos++);
					DescribeAColumn(T, "transmissiondate", "Data trasm.",pos++);
					DescribeAColumn(T, "adate","Data emiss.",pos++);
					DescribeAColumn(T, "printdate","Data stampa",pos++);
					DescribeAColumn(T, "performed", "Esitato",pos++);
					DescribeAColumn(T, "total", "Totale",pos++);
                    DescribeAColumn(T, "net", "Netto", pos++);
					DescribeAColumn(T, "notperformed", "Rimasto da esitare",pos++);
					break;
				}
				case "documentitrasmessi": {
					foreach(DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "",-1);
					}
					int pos=1;
					DescribeAColumn(T, "ypay", "Eserc.",pos++);
					DescribeAColumn(T, "npay", "Numero",pos++);
					DescribeAColumn(T, "adate", "Data emiss.",pos++);
					DescribeAColumn(T, "printdate", "Data stampa",pos++);
					DescribeAColumn(T, "performed", "Esitato",pos++);
					DescribeAColumn(T, "total", "Totale documento",pos++);
                    DescribeAColumn(T, "npay_treasurer", "Numero Doc. Cassiere", pos++);
					FilterRows(T);
					break;
				}
            case "esitomandati": {
                    foreach (DataColumn C in T.Columns) {
                         DescribeAColumn(T, C.ColumnName, "");
                    }
                    int pos2 = 1;
                    DescribeAColumn(T, "npay", "N°Mandato", pos2++);
                    DescribeAColumn(T, "total", "Importo", pos2++);
                    DescribeAColumn(T, "performed", "Esitato", pos2++);
                    DescribeAColumn(T, "adate", "Data emiss.", pos2++);
                    DescribeAColumn(T, "codefin", "Voce bil.", pos2++);
                    DescribeAColumn(T, "finance", "Denom. bil.", pos2++);
                    DescribeAColumn(T, "manager", "Responsabile", pos2++);
                    DescribeAColumn(T, "npaymenttransmission", "Num. elenco", pos2++);
                    DescribeAColumn(T, "printdate", "Data stampa", pos2++);
                    DescribeAColumn(T, "registry", "Percipiente", pos2++);
                    DescribeAColumn(T, "transmissiondate", "Data trasm.", pos2++);
                    DescribeAColumn(T, "ypaymenttransmission", "Eserc. elenco", pos2++);
                    DescribeAColumn(T, "annulmentdate", "Data annull.", pos2++);
                    break;
                }
            }
		}

		protected override Form GetForm(string FormName){
			switch (FormName) {
				case "esitazionemultipla":
					Name = "Esitazione multipla dei movimenti di spesa";
					ActAsList();
					StartEmpty = true;
					return GetFormByDllName("paymentview_esitazionemultipla");
                case "esitomandati":
                    Name = "Esitazione multipla dei mandati";
                    ActAsList();
                    StartEmpty = true;
                    return GetFormByDllName("paymentview_esitomandati");
            }
			return null;
		}
			
		public override bool FilterRow(DataRow R, string list_type){
			if (list_type=="documentitrasmessi"){
				if (R["kpaymenttransmission"]==DBNull.Value)return false;
				return true;
			}
			return true;
		}
	}
}
