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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Windows.Forms;

namespace meta_expense_epview {
	public class Meta_expense_epview : Meta_easydata {
		public Meta_expense_epview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "expense_epview") {
			//EditTypes.Add("default");
			ListingTypes.Add("ep");
		}

		/// <summary>
		/// Impostare la chiave, serve per le viste, non per le tabelle!!
		/// </summary>
		private string[] mykey = new string[] {"idexp", "ayear" /*,...campi chiave*/};

		public override string[] primaryKey() {
			return mykey;
		}

		public override string GetStaticFilter(string listingType) {
			return QHS.CmpEq("ayear",Conn.GetEsercizio());
		}

		public void CompletaCaption(DataTable T) {

			foreach (DataColumn C in T.Columns) {
				if ((C.ColumnName == "nphase") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".n_fase");
					continue;
				}

				if ((C.ColumnName == "phase") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".fase");
					continue;
				}

				if ((C.ColumnName == "ymov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".esercizio mov");
					continue;
				}

				if ((C.ColumnName == "nmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Numero mov");
					continue;
				}

				if ((C.ColumnName == "parentymov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Esercizio padre");
					continue;
				}

				if ((C.ColumnName == "parentnmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Numero padre");
					continue;
				}

				if ((C.ColumnName == "formerymov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Esercizio Mov Originale (Riporto da Anno Prec)");
					continue;
				}

				if ((C.ColumnName == "formernmov") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Numero Mov Originale (Riporto da Anno Prec)");
					continue;
				}

				if ((C.ColumnName == "ayear") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Esercizio contabile");
					continue;
				}

				if ((C.ColumnName == "codefin") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod Bilancio");
					continue;
				}

				if ((C.ColumnName == "finance") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Bilancio");
					continue;
				}

				if ((C.ColumnName == "codeupb") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod UPB");
					continue;
				}

				if ((C.ColumnName == "upb") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".UPB");
					continue;
				}

				if ((C.ColumnName == "idreg") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod Anagrafica");
					continue;
				}

				if ((C.ColumnName == "registry") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Anagrafica");
					continue;
				}

				if ((C.ColumnName == "cf") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod Fiscale");
					continue;
				}

				if ((C.ColumnName == "p_iva") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Partita iva");
					continue;
				}

				if ((C.ColumnName == "manager") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Responsabile");
					continue;
				}

				if ((C.ColumnName == "ypay") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Eserc Mandato");
					continue;
				}

				if ((C.ColumnName == "npay") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Num Mandato");
					continue;
				}

				if ((C.ColumnName == "paymentadate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Data Contabile Mandato");
					continue;
				}

				if ((C.ColumnName == "doc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Doc Collegato");
					continue;
				}

				if ((C.ColumnName == "docdate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Data Doc Collegato");
					continue;
				}

				if ((C.ColumnName == "description") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Descrizione");
					continue;
				}

				if ((C.ColumnName == "amount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Importo Originale");
					continue;
				}

				if ((C.ColumnName == "ayearstartamount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Importo Iniziale di Esercizio");
					continue;
				}

				if ((C.ColumnName == "curramount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Importo Corrente (incluse variazioni)");
					continue;
				}

				if ((C.ColumnName == "available") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Importo Disponibile (per Fasi successive)");
					continue;
				}

				if ((C.ColumnName == "iban") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".IBAN");
					continue;
				}

				if ((C.ColumnName == "cin") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".CIN");
					continue;
				}

				if ((C.ColumnName == "idbank") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".ABI");
					continue;
				}

				if ((C.ColumnName == "idcab") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".CAB");
					continue;
				}

				if ((C.ColumnName == "cc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Numero C/C");
					continue;
				}

				if ((C.ColumnName == "biccode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Codice BIC/SWIFT");
					continue;
				}

				if ((C.ColumnName == "paymethod_allowdeputy") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Ammetti Delegato");
					continue;
				}

				if ((C.ColumnName == "extracode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Num Conto Banca d'Italia");
					continue;
				}

				if ((C.ColumnName == "deputy") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Delegato");
					continue;
				}

				if ((C.ColumnName == "refexternaldoc") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Riferimento Doc Esterno");
					continue;
				}

				if ((C.ColumnName == "paymentdescr") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Info aggiuntive per il Tesoriere");
					continue;
				}

				if ((C.ColumnName == "service") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Prestazione");
					continue;
				}

				if ((C.ColumnName == "codeser") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod Prestazione");
					continue;
				}

				if ((C.ColumnName == "servicestart") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Inizio Prestazione");
					continue;
				}

				if ((C.ColumnName == "servicestop") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Fine Prestazione");
					continue;
				}

				if ((C.ColumnName == "ivaamount") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Importo IVA");
					continue;
				}

				if ((C.ColumnName == "flagarrear") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Competenza/Residui");
					continue;
				}

				if ((C.ColumnName == "expiration") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Data Scadenza");
					continue;
				}

				if ((C.ColumnName == "adate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Data Contabile");
					continue;
				}

				if ((C.ColumnName == "autocode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Codice Automatismo");
					continue;
				}

				if ((C.ColumnName == "clawback") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Recupero");
					continue;
				}

				if ((C.ColumnName == "clawbackref") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Cod Recupero");
					continue;
				}

				if ((C.ColumnName == "nbill") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Num Bolletta");
					continue;
				}

				if ((C.ColumnName == "idpay") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Num SUB (trasmissione)");
					continue;
				}

				if ((C.ColumnName == "npaymenttransmission") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Numero Elenco Trasmissione");
					continue;
				}

				if ((C.ColumnName == "transmissiondate") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Data Trasmissione");
					continue;
				}

				if ((C.ColumnName == "codeaccdebit") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Causale Debito");
					continue;
				}

				if ((C.ColumnName == "cigcode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".n_fase");
					continue;
				}

				if ((C.ColumnName == "cupcode") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".Codice CUP");
					continue;
				}

				if ((C.ColumnName == "txt") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".appunti");
					continue;
				}
			}
		}

		protected override Form GetForm(string FormName) {
			//if (FormName == "default") {
			//    DefaultListType = "default";
			//    Name = "Descrizione Form";
			//    return MetaData.GetFormByDllName("expenseview_epview_default");
			//}
			return null;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			//PrimaryTable.setDefault("ayear", GetSys("esercizio"));
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			//T.setMySelector("ntabella", "nphase", 0);  //campo nphase  è selettore per calcolo di ntabella
			//T.setMySelector("ntabella", "ytabella", 0);//campo ytabella  è selettore per calcolo di ntabella
			//T.setAutoincrement("ntabella", null, null, 0);  //ntabella è campo ad autoincremento
			//T.setAutoincrement("idtabella", null, null, 0);  //idtabella è campo ad autoincremento

			//T.setMinimumTempValue("idtabella", 999900000);     //Da impostare  in caso di pericolo di conflitto
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		/// <summary>
		/// FilterRow, si usa per i grid filtrati
		/// </summary>
		/// <param name="R"></param>
		/// <param name="list_type"></param>
		/// <returns></returns>
		public override bool FilterRow(DataRow R, string list_type) {
			//if (list_type == "form_contenitore") {
			//    if (R["chiave contenitore"] == DBNull.Value) return false;
			//    return true;
			//}

			return true;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;
			//if (condizione di errore) {
			//    errmess = "Messaggio di errore";
			//    errfield = "Nome campo su cui posizionare il focus";
			//    return false;
			//}


			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			//if (ListingType == "lista")
			//    return base.SelectOne(ListingType, filter, "expenseview_epviewview", Exclude);
			//else
			return base.SelectOne(ListingType, filter, "expenseview_epview", Exclude);
		}


		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			switch (ListingType) {
				case "ep": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "automatismo", "Tipo movimento", nPos++);
					DescribeAColumn(T, "ymov", "Eserc.Mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num.Mov.", nPos++);

					DescribeAColumn(T, "n_mandato", "N.mandato", nPos++);
					DescribeAColumn(T, "n_elenco", "N.elenco", nPos++);
					DescribeAColumn(T, "scrittura_chiusura_debito", "N.scrittura elenco", nPos++);
					DescribeAColumn(T, "amount", "Importo Originale", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}
					DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
					DescribeAColumn(T, "debito_chiuso", "Debito chiuso", nPos++);
					DescribeAColumn(T, "importo_da_esitare", "Importo da esitare", nPos++);
					DescribeAColumn(T, "importo_contributi", "Importo contributi", nPos++);
					DescribeAColumn(T, "pagamenti_contributi", "Pagamento contributi", nPos++);
					DescribeAColumn(T, "chiusura_debito_contributi", "Debito chiuso contributi", nPos++);
					DescribeAColumn(T, "contributi_da_esitare", "Contributi da esitare", nPos++);
					DescribeAColumn(T, "codefin", "Voce Bil.", nPos++);
					DescribeAColumn(T, "finance", "Denom. Bil.", nPos++);
					DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
					DescribeAColumn(T, "upb", "U.P.B.", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);

					
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					CompletaCaption(T);
					break;
				}
			}
		}
	}
}
