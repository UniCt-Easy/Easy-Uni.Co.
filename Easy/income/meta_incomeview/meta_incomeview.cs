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

namespace meta_incomeview {//meta_entrataview//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_incomeview : Meta_easydata {
		public Meta_incomeview(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "incomeview") {		
			Name= "Movimento di entrata";
			ListingTypes.Add("documentocollegato");
			ListingTypes.Add("assegnazionecredito");
			ListingTypes.Add("assegnautocreditiincassi");
			ListingTypes.Add("autospesa");
			ListingTypes.Add("autogenerati");
			ListingTypes.Add("reversaleautomatica");
			ListingTypes.Add("elencofaseprec");
			//ListingTypes.Add("movimentiaperti");
			//ListingTypes.Add("movbancariocollegato");
			ListingTypes.Add("autogeneratips"); //by leo
		}
		public override bool FilterRow(DataRow R, string list_type){
			if (list_type=="documentocollegato"){
				if (R["ypro"]==DBNull.Value)return false;
				if (R["npro"]==DBNull.Value)return false;
				return true;
			}

			return true;
		}
		public override bool CanSelect(DataRow R) {
			if (R.Table.Columns["ayear"]!=null){
				if (R["ayear"].ToString()!=GetSys("esercizio").ToString()){
					MessageBox.Show("L'entrata selezionata non è presente in questo esercizio quindi non è selezionabile.");
					return false;
				}
			}
			return base.CanSelect (R);
		}
        private string[] mykey = new string[] { "ayear", "idinc" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType=="elencofaseprec"||ListingType=="default") {
				sorting = "phase asc,ymov desc,nmov desc";
				return sorting;
			}
			return base.GetSorting (ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
            string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
            string basefilter = base.GetStaticFilter(ListingType);
            if (basefilter == null || basefilter == "") return filteresercizio;
            return QHS.AppAnd(basefilter, filteresercizio);
		}

        public void CompletaCaption(DataTable T)
        {

            foreach (DataColumn C in T.Columns)
            {
                if ((C.ColumnName == "nphase") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".n_fase");
                    continue;
                }
                if ((C.ColumnName == "phase") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".fase");
                    continue;
                }
                if ((C.ColumnName == "ymov") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".esercizio mov");
                    continue;
                }
                if ((C.ColumnName == "nmov") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Numero mov");
                    continue;
                }
                if ((C.ColumnName == "parentymov") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio padre");
                    continue;
                }
                if ((C.ColumnName == "parentnmov") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Numero padre");
                    continue;
                }
               
                if ((C.ColumnName == "ayear") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Esercizio contabile");
                    continue;
                }
                if ((C.ColumnName == "codefin") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Cod Bilancio");
                    continue;
                }
                if ((C.ColumnName == "finance") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Bilancio");
                    continue;
                }
                if ((C.ColumnName == "codeupb") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Cod UPB");
                    continue;
                }
                if ((C.ColumnName == "upb") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".UPB");
                    continue;
                }
                if ((C.ColumnName == "idreg") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Cod Anagrafica");
                    continue;
                }
                if ((C.ColumnName == "registry") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Anagrafica");
                    continue;
                }
              
                if ((C.ColumnName == "manager") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Responsabile");
                    continue;
                }
                if ((C.ColumnName == "ypro") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Eserc Reversale");
                    continue;
                }
                if ((C.ColumnName == "npro") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Num Reversale");
                    continue;
                }
               
                if ((C.ColumnName == "doc") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Doc Collegato");
                    continue;
                }
                if ((C.ColumnName == "docdate") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Doc Collegato");
                    continue;
                }
                if ((C.ColumnName == "description") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Descrizione");
                    continue;
                }
                if ((C.ColumnName == "amount") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Originale");
                    continue;
                }
                if ((C.ColumnName == "ayearstartamount") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Iniziale di Esercizio");
                    continue;
                }
                if ((C.ColumnName == "curramount") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Corrente (incluse variazioni)");
                    continue;
                }
                if ((C.ColumnName == "available") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Disponibile (per Fasi successive)");
                    continue;
                }
                if ((C.ColumnName == "unpartitioned") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Importo Non Assegnato");
                    continue;
                }
              
                if ((C.ColumnName == "flagarrear") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Competenza/Residui");
                    continue;
                }
                if ((C.ColumnName == "expiration") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Scadenza");
                    continue;
                }
                if ((C.ColumnName == "adate") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Contabile");
                    continue;
                }
                if ((C.ColumnName == "autokind") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Codice Tipo Automatismo");
                    continue;
                }
                if ((C.ColumnName == "autocode") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Codice Automatismo");
                    continue;
                }
              
                if ((C.ColumnName == "nbill") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Num Bolletta");
                    continue;
                }
                if ((C.ColumnName == "ypro") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Eserc Reversale");
                    continue;
                }
                if ((C.ColumnName == "npro") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Num Reversale");
                    continue;
                }
                if ((C.ColumnName == "idpro") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Num SUB (trasmissione)");
                    continue;
                }
                if ((C.ColumnName == "nproceedstransmission") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Numero Elenco Trasmissione");
                    continue;
                }
                if ((C.ColumnName == "transmissiondate") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Data Trasmissione");
                    continue;
                }
                if ((C.ColumnName == "codeacccredit") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Causale Credito");
                    continue;
                }
                
                if ((C.ColumnName == "cupcode") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Codice CUP");
                    continue;
                }
                if ((C.ColumnName == "underwriting") && ((C.Caption == "") || (C.Caption == C.ColumnName)))
                {
                    DescribeAColumn(T, C.ColumnName, ".Finanziamento");
                    continue;
                }
                if ((C.ColumnName == "ypayment") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".Anno pagamento");
                    continue;
                }
                if ((C.ColumnName == "npayment") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
                    DescribeAColumn(T, C.ColumnName, ".N.Pagamento");
                    continue;
                }
            }		
        }
		public override void DescribeColumns(DataTable T, string ListingType) {			
			base.DescribeColumns(T, ListingType);

			switch (ListingType) {
                case "autogeneratips": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
				DescribeAColumn(T, "idinc", ".identrata");
				DescribeAColumn(T,"!livprecedente","Livello Superiore");
				DescribeAColumn(T, "phase", "Fase");
				DescribeAColumn(T, "registry", "Versante");
				DescribeAColumn(T, "codefin", "Bilancio");
				DescribeAColumn(T, "codeupb", "UPB");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "amount", "Importo");
                CompletaCaption(T);
                    break;
			}

                case "movimentiaperti": {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				DescribeAColumn(T, "ymov", "Eserc. mov.",1);
				DescribeAColumn(T, "nmov", "Num. mov.",2);
				DescribeAColumn(T, "codefin", "Voce di bilancio",3);
				DescribeAColumn(T, "codeupb", "U.P.B.",4);
				DescribeAColumn(T, "registry", "Versante",5);
				DescribeAColumn(T, "manager", "Responsabile",6);
				DescribeAColumn(T, "description", "Descrizione",7);		
				DescribeAColumn(T, "curramount", "Importo Corrente",8);
				DescribeAColumn(T, "available", "Disponibile",9);
				DescribeAColumn(T, "adate", "Data cont.",10);
				DescribeAColumn(T, "doc", "Documento",-1);
				DescribeAColumn(T, "expiration", "Data scad.",-1);
                CompletaCaption(T);
                    break;
			}

                case "documentocollegato": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
				DescribeAColumn(T, "ymov", "Eserc.");
				DescribeAColumn(T, "nmov", "Numero");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "registry", "Versante");
				DescribeAColumn(T, "codefin", "Bilancio");
				DescribeAColumn(T, "codeupb", "U.P.B.");
				DescribeAColumn(T, "manager", "Resp.");
				DescribeAColumn(T, "curramount", "Importo");
                CompletaCaption(T);
				FilterRows(T);
                    break;
			}
			
                case "autospesa": {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                //DescribeAColumn(T, "idinc", ".identrata");
                DescribeAColumn(T, "phase", "Fase", nPos++);
                DescribeAColumn(T, "nmov", "Numero", nPos++);
                DescribeAColumn(T, "registry", "Percipiente", nPos++);
                DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "curramount", "Importo", nPos++);
                DescribeAColumn(T, "ypro", "Eserc. Reversale", nPos++);
                DescribeAColumn(T, "npro", "Num. Reversale", nPos++);
                CompletaCaption(T);
                    break;
            }
                case "autogenerati": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int nPos = 1;
                DescribeAColumn(T, "idinc", ".identrata", nPos++);
				DescribeAColumn(T,"!livprecedente","Livello Superiore",nPos++);
                DescribeAColumn(T, "phase", "Fase",nPos++);
                DescribeAColumn(T, "registry", "Versante", nPos++);
                DescribeAColumn(T, "codefin", "Bilancio", nPos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
                DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
                CompletaCaption(T);
	            break;

			}

                case "assegnazionecredito": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int pos = 1;
				DescribeAColumn(T, "ymov", "Eserc. mov.",pos++);
                DescribeAColumn(T, "nmov", "Num. mov.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "registry", "Versante", pos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", pos++);
                DescribeAColumn(T, "codefin", "Voce bil.", pos++);
                DescribeAColumn(T, "manager", "Resp.", pos++);
                DescribeAColumn(T, "curramount", "Imp. corrente", pos++);
                DescribeAColumn(T, "unpartitioned", "Da assegnare", pos++);
                DescribeAColumn(T, "expiration", "Data scad.", pos++);
                DescribeAColumn(T, "adate", "Data cont.", pos++);
                CompletaCaption(T);
                    break;
			}

                case "assegnautocreditiincassi": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
                int pos = 1;
				DescribeAColumn(T, "phase", "Fase",pos++);
                DescribeAColumn(T, "ymov", "Eserc. mov.", pos++);
                DescribeAColumn(T, "nmov", "Num. mov.", pos++);
                DescribeAColumn(T, "description", "Descrizione", pos++);
                DescribeAColumn(T, "registry", "Versante", pos++);
                DescribeAColumn(T, "codefin", "Bilancio", pos++);
                DescribeAColumn(T, "codeupb", "U.P.B.", pos++);
                DescribeAColumn(T, "curramount", "Imp. corrente", pos++);
                DescribeAColumn(T, "unpartitioned", "Da assegnare", pos++);
                DescribeAColumn(T, "idinc", ".identrata", pos);
                CompletaCaption(T);
                    break;
			}

                case "reversaleautomatica": {
				foreach(DataColumn C in T.Columns){
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "idinc", ".identrata",1);
				DescribeAColumn(T, "ymov", "Eserc.",2);
				DescribeAColumn(T, "nmov", "Numero",3);
				DescribeAColumn(T, "registry", "Versante",4);
				DescribeAColumn(T, "codefin", "Bilancio",5);
				DescribeAColumn(T, "codeupb", "U.P.B.",6);
				DescribeAColumn(T, "manager", "Resp.",7);
				DescribeAColumn(T, "description", "Descrizione",8);
				DescribeAColumn(T, "curramount", "Importo",9);
                CompletaCaption(T);
                    break;
			}
			/*if (ListingType=="movbancario") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "");
				}
				DescribeAColumn(T, "ymov", "Eserc.");
				DescribeAColumn(T, "nmov", "Numero");
				DescribeAColumn(T, "description", "Descrizione");
				DescribeAColumn(T, "registry", "Versante");
				DescribeAColumn(T, "codefin", "Bilancio");
				DescribeAColumn(T, "codeupb", "U.P.B.");
				DescribeAColumn(T, "manager", "Resp. bil.");
				DescribeAColumn(T, "curramount", "Importo");
			}
			if (ListingType=="movbancariocollegato") {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "ymov", "Eserc.",1);
				DescribeAColumn(T, "nmov", "Numero",2);
				DescribeAColumn(T, "description", "Descrizione",3);
				DescribeAColumn(T, "registry", "Versante",4);
				DescribeAColumn(T, "codefin", "Bilancio",5);
				DescribeAColumn(T, "codeupb", "U.P.B.",6);
				DescribeAColumn(T, "manager", "Resp. bil.",7);
				DescribeAColumn(T, "curramount", "Importo",8);
				FilterRows(T);
			}*/

                case "elencofaseprec": {
				foreach(DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "",-1);
				}
				DescribeAColumn(T, "ymov", "Eserc. mov.",1);
				DescribeAColumn(T, "nmov", "Num. mov.",2);
				DescribeAColumn(T, "codefin", "Voce bilancio",3);
				DescribeAColumn(T, "codeupb", "U.P.B.",4);
				DescribeAColumn(T, "description", "Descrizione",5);
				DescribeAColumn(T, "registry", "Versante",6);
				DescribeAColumn(T, "centercode", "CentroSpesa",7);
				DescribeAColumn(T, "curramount", "Imp. corrente",8);
				DescribeAColumn(T, "available", "Disponibile",9);
				DescribeAColumn(T, "adate", "Data cont.",10);
                CompletaCaption(T);
                    break;
			}
        case "default": {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int npos = 1;
                DescribeAColumn(T, "phase", "Fase", npos++);
                DescribeAColumn(T, "ymov", "Eserc.Mov.", npos++);
                DescribeAColumn(T, "nmov", "Num.Mov.", npos++);
                DescribeAColumn(T, "codefin", "Voce Bil.", npos++);
                DescribeAColumn(T, "finance", "Denom. Bil.", npos++);
                DescribeAColumn(T, "codeupb", "Cod. U.P.B.", npos++);
                DescribeAColumn(T, "upb", "U.P.B.", npos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", npos++);
                DescribeAColumn(T, "registry", "Versante", npos++);
                DescribeAColumn(T, "manager", "Responsabile", npos++);
                DescribeAColumn(T, "ypro", "Eserc.Rev.", npos++);
                DescribeAColumn(T, "npro", "Num.Rev.", npos++);
                DescribeAColumn(T, "doc", "Documento", npos++);
                DescribeAColumn(T, "docdate", "Data Doc.", npos++);
                DescribeAColumn(T, "description", "Descrizione", npos++);
                DescribeAColumn(T, "amount", "Importo Originale", npos++);
                DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", npos++);
                DescribeAColumn(T, "curramount", "Imp.Corrente", npos++);
                DescribeAColumn(T, "available", "Disponibile", npos++);
                DescribeAColumn(T, "unpartitioned", "Da Assegnare", npos++);
                DescribeAColumn(T, "fulfilled", ".Mov.Cop.", -1);
                DescribeAColumn(T, "autokind", ".Tipo Auto", -1);
                DescribeAColumn(T, "flagarrear", ".Competenza", -1);
                DescribeAColumn(T, "ypayment", "Eserc.Pagamento.", npos++);
                DescribeAColumn(T, "npayment", "Num.Pagamento.", npos++);
                DescribeAColumn(T, "descrpayment", "Descr.Pagamento.", npos++);
                DescribeAColumn(T, "expiration", ".Data Scadenza", -1);
                DescribeAColumn(T, "adate", "Data Contabile", npos++);
                DescribeAColumn(T, "nproceedstransmission", "Distinta Trasmissione", npos++);
                DescribeAColumn(T, "transmissiondate", "Data Trasmissione", npos++);
                DescribeAColumn(T, "cupcode", "CUP", npos++);
                DescribeAColumn(T, "codeacccredit", "Cod.Causale Credito", npos++);
                DescribeAColumn(T, "accountcredit", "Causale Credito", npos++);
                CompletaCaption(T);
                break;
            }
			}
		}
	}
}