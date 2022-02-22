
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_proceedsview {//meta_documentoincassoview//
	/// <summary>
	/// Summary description for Class1.
	/// Updated by Leo, 11 Dec 2002, End 12 Dec 2002
	/// </summary>
	public class Meta_proceedsview : Meta_easydata {
		public Meta_proceedsview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "proceedsview") {
			EditTypes.Add("esitazionemultipla");
			ListingTypes.Add("esitazionemultipla");
			ListingTypes.Add("listapermovbancario");
			ListingTypes.Add("lista");
			Name = "reversali di incasso";
		}
		public override string GetSorting(string ListingType) {
			if (ListingType=="lista")return "ypro desc, npro desc";
			return base.GetSorting (ListingType);
		}

        private string[] mykey = new string[] { "kpro" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetStaticFilter(string ListingType) {
            if (ListingType == "lista") return QHS.CmpEq("ypro", Conn.GetSys("esercizio")); 
            return base.GetStaticFilter(ListingType);
        }

		public override string GetNoRowFoundMessage(string listingtype) {
			if (listingtype == "listapermovbancario") {
				return "Non esistono reversali da esitare con le condizioni impostate";
			}
			return base.GetNoRowFoundMessage(listingtype);
		}

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            switch (ListingType) {
                case "listapermovbancario":
                    // annullo tutti i column name
                    foreach (DataColumn C in T.Columns)
                        DescribeAColumn(T, C.ColumnName, "", -1);

                    DescribeAColumn(T, "ypro", "Esercizio", 1);
                    DescribeAColumn(T, "npro", "Numero", 2);
                    DescribeAColumn(T, "adate", "Data contabile", 3);
                    DescribeAColumn(T, "printdate", "Data di stampa", 4);
                    DescribeAColumn(T, "transmissiondate", "Data di trasm.", 5);
                    break;
                case "lista": {
                        // annullo tutti i column name
                        foreach (DataColumn C in T.Columns)
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        int pos = 1;
                        DescribeAColumn(T, "ypro", "Esercizio", pos++);
                        DescribeAColumn(T, "npro", "Numero", pos++);
                        DescribeAColumn(T, "npro_treasurer", "Num. doc. Cass.", pos++);
                        DescribeAColumn(T, "stamphandling", "Bollo", pos++);
                        DescribeAColumn(T, "kind", "Tipo", pos++);
                        DescribeAColumn(T, "accountkind", "Conto", pos++);
                        DescribeAColumn(T, "registry", "Versante", pos++);
                        DescribeAColumn(T, "codefin", "Voce bil.", pos++);
                        DescribeAColumn(T, "finance", "Denom. bil.", pos++);
                        DescribeAColumn(T, "manager", "Responsabile", pos++);
                        DescribeAColumn(T, "yproceedstransmission", "Eserc. elenco", pos++);
                        DescribeAColumn(T, "nproceedstransmission", "Num. elenco", pos++);
                        DescribeAColumn(T, "transmissiondate", "Data trasm.", pos++);
                        DescribeAColumn(T, "adate", "Data emiss.", pos++);
                        DescribeAColumn(T, "printdate", "Data stampa", pos++);
                        DescribeAColumn(T, "performed", "Esitato", pos++);
                        DescribeAColumn(T, "total", "Totale", pos++);
                        DescribeAColumn(T, "notperformed", "Rimasto da esitare", pos++);
                        break;
                    }
                case "documentitrasmessi": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "", -1);
                        }
                        int pos = 1;
                        DescribeAColumn(T, "ypro", "Eserc.", pos++);
                        DescribeAColumn(T, "npro", "Numero", pos++);
                        DescribeAColumn(T, "adate", "Data emiss.", pos++);
                        DescribeAColumn(T, "printdate", "Data stampa", pos++);
                        DescribeAColumn(T, "registry", "Versante",pos++);
                        DescribeAColumn(T, "performed", "Esitato", pos++);
                        DescribeAColumn(T, "total", "Totale documento", pos++);
                        DescribeAColumn(T, "npro_treasurer", "Numero Doc. Cassiere", pos++);
                        FilterRows(T);
                        break;
                    }
                case "esitoreversali": {
                        foreach (DataColumn C in T.Columns) {
                            DescribeAColumn(T, C.ColumnName, "");
                        }
                        int pos2 = 1;
                        DescribeAColumn(T, "npro", "N°Reversale", pos2++);
                        DescribeAColumn(T, "total", "Importo", pos2++);
                        DescribeAColumn(T, "performed", "Esitato", pos2++);
                        DescribeAColumn(T, "accountkind", "Conto", pos2++);
                        DescribeAColumn(T, "adate", "Data contabile", pos2++);
                        DescribeAColumn(T, "codefin", "Voce bil.", pos2++);
                        DescribeAColumn(T, "finance", "Denom. bil.", pos2++);
                        DescribeAColumn(T, "manager", "Responsabile", pos2++);
                        DescribeAColumn(T, "nproceedstransmission", "Num. elenco", pos2++);
                        DescribeAColumn(T, "printdate", "Data stampa", pos2++);
                        DescribeAColumn(T, "registry", "Versante", pos2++);
                        DescribeAColumn(T, "transmissiondate", "Data trasm.", pos2++);
                        DescribeAColumn(T, "yproceedstransmission", "Eserc. elenco", pos2++);
                        DescribeAColumn(T, "annulmentdate", "Data annull.", pos2++);
                        break;
                    }
            }
        }
		protected override Form GetForm(string FormName){
			switch (FormName) {
				case "esitazionemultipla":
					Name = "Esitazione multipla dei movimenti di entrata";
					ActAsList();
					StartEmpty = true;
					return GetFormByDllName("proceedsview_esitazionemultipla");
			}
            switch (FormName) {
                case "esitoreversali":
                    Name = "Esitazione multipla delle reversali";
                    ActAsList();
                    StartEmpty = false;
                    return GetFormByDllName("proceedsview_esitoreversali");
            }
            return null;
		}
		public override bool FilterRow(DataRow R, string list_type){
			if (list_type=="documentitrasmessi"){
				if (R["kproceedstransmission"]==DBNull.Value)return false;
				return true;
			}
			return true;
		}
	}
}
