
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_expenseview { //meta_spesaview//
	/// <summary>
	/// MetaData for spesa
	/// </summary>
	public class Meta_expenseview : Meta_easydata {
		public Meta_expenseview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "expenseview") {
			Name = "Movimento di spesa";
			ListingTypes.Add("default");
			ListingTypes.Add("movimentiaperti");
			ListingTypes.Add("documentocollegato");
			ListingTypes.Add("variazionemovimento");
			ListingTypes.Add("autospesa");
			ListingTypes.Add("autogenerati");
			ListingTypes.Add("mandatoautomatico");
			ListingTypes.Add("elencofaseprec");
			ListingTypes.Add("movbancariocollegato");
			ListingTypes.Add("movbancario");
			ListingTypes.Add("autogeneratips"); //by leo
			ListingTypes.Add("movimentospesa"); //Rosalba
		}

		private string[] mykey = new string[] {"ayear", "idexp"};

		public override string[] primaryKey() {
			return mykey;
		}

		public override bool CanSelect(DataRow R) {
			if (R.Table.Columns["ayear"] != null) {
				if (R["ayear"].ToString() != GetSys("esercizio").ToString()) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(
						"La spesa selezionata non è presente in questo esercizio quindi non è selezionabile.");
					return false;
				}
			}

			return base.CanSelect(R);
		}


		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type == "documentocollegato") {
				if (R["kpay"] == DBNull.Value) return false;
				return true;
			}

			return true;
		}

		public override string GetStaticFilter(string ListingType) {
			string filteresercizio = QHS.CmpEq("ayear", GetSys("esercizio"));
			string basefilter = base.GetStaticFilter(ListingType);
			if (basefilter == null || basefilter == "") return filteresercizio;
			return QHS.AppAnd(basefilter, filteresercizio);
		}


		public override string GetSorting(string ListingType) {
			string sorting;
			if (ListingType == "elencofaseprec" || ListingType == "default") {
				sorting = "phase asc,ymov desc,nmov desc";
				return sorting;
			}

			return base.GetSorting(ListingType);
		}

		public void CompletaCaption(DataTable T) {

			foreach (DataColumn C in T.Columns) {
				if ((C.ColumnName == "idinc_lined") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".idinc p.giro");
					continue;
				}
				if ((C.ColumnName == "ninc_linked") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".n.mov.entrata p.giro");
					continue;
				}
				if ((C.ColumnName == "yinc_linked") && ((C.Caption == "") || (C.Caption == C.ColumnName))) {
					DescribeAColumn(T, C.ColumnName, ".es.mov.entrata p.giro");
					continue;
				}

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




		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			//added by Leo
			switch (ListingType) {
				case "autogeneratips": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "idexp", ".idexp", nPos++);
					DescribeAColumn(T, "!livprecedente", "Livello Superiore", nPos++);
					DescribeAColumn(T, "phase", "Fase", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "amount", "Importo", nPos++);
					CompletaCaption(T);
					break;
				}

				case "movimentiaperti": {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "", -1);
					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "doc", "Documento", nPos++);
					DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "manager", "Responsabile", nPos++);
					DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
					DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					DescribeAColumn(T, "available", "Disponibile", nPos++);
					CompletaCaption(T);
					break;
				}

				case "documentocollegato": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc.", nPos++);
					DescribeAColumn(T, "nmov", "Numero", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
					DescribeAColumn(T, "curramount", "Importo", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					CompletaCaption(T);
					FilterRows(T);
					break;
				}

				case "autospesa": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "phase", "Fase", nPos++);
					DescribeAColumn(T, "nmov", "Numero", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					// DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
					DescribeAColumn(T, "curramount", "Importo", nPos++);
					DescribeAColumn(T, "ypay", "Eserc. Mandato", nPos++);
					DescribeAColumn(T, "npay", "Num. Mandato", nPos++);
					CompletaCaption(T);
					break;
				}

				case "autogenerati": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "idexp", ".idexp", nPos++);
					DescribeAColumn(T, "!livprecedente", "Livello Superiore", nPos++);
					DescribeAColumn(T, "phase", "Fase", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "amount", "Importo Iniziale", nPos++);
					DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
					CompletaCaption(T);
					break;
				}

				case "variazionemovimento": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Voce bil.", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
					DescribeAColumn(T, "curramount", "Imp. corrente", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					DescribeAColumn(T, "available", "Disponibile", nPos++);
					DescribeAColumn(T, "expiration", "Data scad.", nPos++);
					DescribeAColumn(T, "adate", "Data cont.", nPos++);
					CompletaCaption(T);
					break;
				}


				case "elencofaseprec": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
					DescribeAColumn(T, "codefin", "Voce bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "curramount", "Imp. corrente", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					DescribeAColumn(T, "available", "Disponibile", nPos++);
					DescribeAColumn(T, "adate", "Data cont.", nPos++);
					CompletaCaption(T);
					break;
				}

				case "movbancariocollegato": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc.", nPos++);
					DescribeAColumn(T, "nmov", "Numero", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
					DescribeAColumn(T, "curramount", "Importo", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					CompletaCaption(T);
					FilterRows(T);
					break;
				}

				case "movbancario": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc.", nPos++);
					DescribeAColumn(T, "nmov", "Numero", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
					DescribeAColumn(T, "curramount", "Importo", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					CompletaCaption(T);
					break;
				}

				case "mandatoautomatico": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "idexp", ".idexp", nPos++);
					DescribeAColumn(T, "ymov", "Eserc.", nPos++);
					DescribeAColumn(T, "nmov", "Numero", nPos++);
					DescribeAColumn(T, "codefin", "Bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "manager", "Resp. bil.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "curramount", "Importo", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					CompletaCaption(T);
					break;
				}


				case "movimentospesa": {
					foreach (DataColumn C in T.Columns)
						DescribeAColumn(T, C.ColumnName, "", -1);

					int nPos = 1;
					DescribeAColumn(T, "ymov", "Eserc. mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num. mov.", nPos++);
					DescribeAColumn(T, "codefin", "Voce di bilancio", nPos++);
					DescribeAColumn(T, "codeupb", "U.P.B.", nPos++);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "manager", "Responsabile", nPos++);
					DescribeAColumn(T, "doc", "Documento", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					DescribeAColumn(T, "available", "Disponibile", nPos++);
					DescribeAColumn(T, "expiration", "Data scad.", nPos++);
					DescribeAColumn(T, "adate", "Data cont.", nPos++);
					CompletaCaption(T);
					break;
				}

				case "default": {
					foreach (DataColumn C in T.Columns) {
						DescribeAColumn(T, C.ColumnName, "", -1);
					}

					int nPos = 1;
					DescribeAColumn(T, "phase", "Fase", nPos++);
					DescribeAColumn(T, "ymov", "Eserc.Mov.", nPos++);
					DescribeAColumn(T, "nmov", "Num.Mov.", nPos++);
					DescribeAColumn(T, "codefin", "Voce Bil.", nPos++);
					DescribeAColumn(T, "finance", "Denom. Bil.", nPos++);
					DescribeAColumn(T, "codeupb", "Cod. U.P.B.", nPos++);
					DescribeAColumn(T, "upb", "U.P.B.", nPos++);
					DescribeAColumn(T, "idexp", ".idexp", -1);
					DescribeAColumn(T, "registry", "Percipiente", nPos++);
					DescribeAColumn(T, "manager", "Responsabile", nPos++);
					DescribeAColumn(T, "doc", "Documento", nPos++);
					DescribeAColumn(T, "docdate", "Data Doc.", nPos++);
					DescribeAColumn(T, "description", "Descrizione", nPos++);
					DescribeAColumn(T, "amount", "Importo Originale", nPos++);
					DescribeAColumn(T, "ayearstartamount", "Imp.Esercizio", nPos++);
					DescribeAColumn(T, "curramount", "Imp.Corrente", nPos++);
					if (T.Columns.Contains("netamount")) {
						DescribeAColumn(T, "netamount", "Importo Netto", nPos++);
					}

					DescribeAColumn(T, "available", "Disponibile", nPos++);
					DescribeAColumn(T, "adate", "Data Contabile", nPos++);
					DescribeAColumn(T, "ypay", "Eserc.Mand.", nPos++);
					DescribeAColumn(T, "npay", "Num.Mand.", nPos++);
					DescribeAColumn(T, "idpay", "Num. SUB (trasmissione)",nPos++);
					DescribeAColumn(T, "paymentadate", "Data Cont. Mand.", nPos++);
					DescribeAColumn(T, "npaymenttransmission", "Distinta Trasmissione", nPos++);
					DescribeAColumn(T, "transmissiondate", "Data Trasmissione", nPos++);
					DescribeAColumn(T, "cigcode", "CIG", nPos++);
					DescribeAColumn(T, "cupcode", "CUP", nPos++);
					DescribeAColumn(T, "codeaccdebit", "Cod.Causale Debito", nPos++);
					DescribeAColumn(T, "accountdebit", "Causale Debito", nPos++);
					DescribeAColumn(T, "nbill", "Bolletta", nPos++);
					DescribeAColumn(T, "idregistrypaymethod", ".#", -1);
					DescribeAColumn(T, "idpaymethod", ".Codice Mod.Pag.", -1);
					DescribeAColumn(T, "cin", ".Cin", -1);
					DescribeAColumn(T, "idbank", ".Cod.ABI", -1);
					DescribeAColumn(T, "idcab", ".CAB", -1);
					DescribeAColumn(T, "cc", ".Conto", nPos++);
					DescribeAColumn(T, "paymentdescr", ".Note per il tesoriere.", -1);
					DescribeAColumn(T, "codeser", ".Cod. Prestazione", -1);
					DescribeAColumn(T, "service", ".Prestazione", -1);
					DescribeAColumn(T, "servicestart", ".Data Inizio Prest.", -1);
					DescribeAColumn(T, "servicestop", ".Data Fine Prest.", -1);
					DescribeAColumn(T, "ivaamount", ".Iva", -1);
					DescribeAColumn(T, "autokind", ".Tipo Auto", -1);
					DescribeAColumn(T, "flagarrear", ".Competenza", -1);
					DescribeAColumn(T, "expiration", ".Data Scadenza", -1);
					DescribeAColumn(T, "ninc_linked", "n.mov.entrata p.giro", -1);

					CompletaCaption(T);
					break;
				}
			}
		}
	}
}
