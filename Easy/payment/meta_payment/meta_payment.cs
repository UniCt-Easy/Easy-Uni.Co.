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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
//using payment_default;//documentopagamento
//Pino: using documentopagamentomultiplo; diventato inutile
//Pino: using documentopagamento_gener_auto; diventato inutile
using metadatalibrary;
using funzioni_configurazione;
using siopeplus_functions;
using System.Collections.Generic;
using System.Text;
using pagamenti = bankdispositionsetup_siopeplus_pagamenti;
using System.Linq;

namespace meta_payment { //meta_documentopagamento//
	/// <summary>
	/// Summary description for Meta_documentopagamento.
	/// Updated by Leo 12 Dec 2002 
	/// Revised By Nino on 27/2/2003
	/// </summary>
	public class Meta_payment : Meta_easydata {
		public Meta_payment(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "payment") {
			EditTypes.Add("default");
			EditTypes.Add("docmultiplo");
			EditTypes.Add("generazioneautomatica");
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente            
			ListingTypes.Add("lista");
			ListingTypes.Add("listapermovbancario");
			ListingTypes.Add("documentitrasmessi");
			ListingTypes.Add("elencoautomatico");
			Name = "Documento di pagamento";
		}

		object flagautostampa = null;

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ypay", GetSys("esercizio").ToString());
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			if (flagautostampa == null) {
				flagautostampa = Conn.DO_READ_VALUE("config",
					QHS.CmpEq("ayear", GetSys("esercizio")),
					"payment_flagautoprintdate");
			}

			if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
				SetDefault(PrimaryTable, "printdate", GetSys("datacontabile"));
			}
		}


		private static object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
			int npay_treasurer = GetMaxNpay_Treasurer(R, Conn);
			if (npay_treasurer < 0) return DBNull.Value;
			return npay_treasurer;
		}

		static Dictionary<int, object> enable_ndoc_treasurers = new Dictionary<int, object>();

		private static int GetMaxNpay_Treasurer(DataRow R, DataAccess Conn) {
			QueryHelper QHS;
			QHS = Conn.GetQueryHelper();
			var qhc = new CQueryHelper();
			object idtreasurer = R["idtreasurer"];
			if ((idtreasurer == DBNull.Value) || (CfgFn.GetNoNullInt32(idtreasurer) == 0)) return -1;
			object flagautondoc_treasurer = null;
			if (enable_ndoc_treasurers.ContainsKey((int) idtreasurer)) {
				flagautondoc_treasurer = enable_ndoc_treasurers[(int) idtreasurer];
			}
			else {
				if (R.Table.DataSet.Tables.Contains("treasurer") &&
				    R.Table.DataSet.Tables["treasurer"].Columns.Contains("enable_ndoc_treasurer")
				) {
					DataTable ttr = R.Table.DataSet.Tables["treasurer"];
					var foundTr = ttr.Select(qhc.CmpEq("idtreasurer", idtreasurer));
					if (foundTr.Length > 0) {
						flagautondoc_treasurer = foundTr[0]["enable_ndoc_treasurer"];
						enable_ndoc_treasurers[(int) idtreasurer] = flagautondoc_treasurer;
					}
				}
			}

			if (flagautondoc_treasurer == null) {
				flagautondoc_treasurer = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("idtreasurer", idtreasurer),
					"enable_ndoc_treasurer");
				enable_ndoc_treasurers[(int) idtreasurer] = flagautondoc_treasurer;
			}

			if ((flagautondoc_treasurer != null) && (flagautondoc_treasurer != DBNull.Value) &&
			    (flagautondoc_treasurer.ToString().ToUpper() == "S")) {
				int numiniziale = 0;

				string sqlmax = "SELECT ISNULL(MAX(npay_treasurer)," + numiniziale.ToString() +
				                ") + 1 FROM payment WHERE "
				                + QHS.AppAnd(QHS.CmpEq("idtreasurer", idtreasurer), QHS.CmpEq("ypay", R["ypay"]));

				DataTable t = Conn.SQLRunner(sqlmax, true, 0);
				return CfgFn.GetNoNullInt32(t.Rows[0][0]);
			}

			return -1;
		}

		private static bool EnableNDoc_Treasurer(DataRow R, DataAccess Conn) {
			QueryHelper QHS;
			QHS = Conn.GetQueryHelper();
			object idtreasurer = R["idtreasurer"];
			if ((idtreasurer == DBNull.Value) || (CfgFn.GetNoNullInt32(idtreasurer) == 0))
				return false;
			object flagautondoc_treasurer = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("idtreasurer", idtreasurer),
				"enable_ndoc_treasurer");
			if ((flagautondoc_treasurer != null) && (flagautondoc_treasurer != DBNull.Value) &&
			    (flagautondoc_treasurer.ToString().ToUpper() == "S")) {
				return true;
			}

			return false;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.ClearMySelector(T, "npay");
			RowChange.setMinimumTempValue(T.Columns["kpay"], 9999000);
			RowChange.setMinimumTempValue(T.Columns["npay"], 9999000);
			RowChange.MarkAsAutoincrement(T.Columns["kpay"], null, null, 0);
			RowChange.MarkAsAutoincrement(T.Columns["npay"], null, null, 0);

			RowChange.SetMySelector(T.Columns["npay"], "ypay", 0);

			if (T.Columns.Contains("npay_treasurer")) {
				RowChange.MarkAsAutoincrement(T.Columns["npay_treasurer"], null, null, 7);
				RowChange.MarkAsCustomAutoincrement(T.Columns["npay_treasurer"],
					new RowChange.CustomCalcAutoID(CalcID));
			}

			DataRow R = base.Get_New_Row(ParentRow, T);
			if (EnableNDoc_Treasurer(R, Conn) && (!T.Columns.Contains("npay_treasurer"))) {
				showClientMsg("Problemi nel calcolo del progressivo mandato per cassiere", "Attenzione",
					MessageBoxButtons.OK);
			}

			if (flagautostampa == null) {
				flagautostampa = Conn.DO_READ_VALUE("config",
					QHS.CmpEq("ayear", GetSys("esercizio")),
					"payment_flagautoprintdate");
			}

			if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
				R["printdate"] = R["adate"];
			}

			if (T.Columns.Contains("npay_treasurer")) {
				R["npay_treasurer"] = -9999;
			}

			return R;
		}

		protected override Form GetForm(string FormName) {

			Name = "Mandato di pagamento";
			if (FormName == "default") {
				Name = "Mandato singolo";
				DefaultListType = "lista";
				return MetaData.GetFormByDllName("payment_default"); //PinoRana
			}

			if (FormName == "docmultiplo") {
				Name = "Mandato di pagamento";
				DefaultListType = "lista";
				return MetaData.GetFormByDllName("payment_docmultiplo"); //PinoRana
			}

			if (FormName == "generazioneautomatica") {
				DefaultListType = "lista";
				Name = "Generazione automatica dei mandati";
				return MetaData.GetFormByDllName("payment_generazioneautomatica"); //PinoRana
			}

			return null;
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if (C.ColumnName == "kpaymenttransmission") return;
			base.InsertCopyColumn(C, Source, Dest);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "listapermovbancario" ||
			    ListingType == "lista" ||
			    ListingType == "documentitrasmessi") {
				return base.SelectOne(ListingType, filter, "paymentview", Exclude);
			}

			return base.SelectOne(ListingType, filter, "payment", Exclude);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "documentitrasmessi") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;
				DescribeAColumn(T, "ypay", "Eserc.", nPos++);
				DescribeAColumn(T, "npay", "Numero", nPos++);
				DescribeAColumn(T, "adate", "Data emiss.", nPos++);
				DescribeAColumn(T, "printdate", "Data stampa", nPos++);
				FilterRows(T);
			}

			if (ListingType == "elencoautomatico") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;
				DescribeAColumn(T, "ypay", "Eserc.", nPos++);
				DescribeAColumn(T, "npay", "Numero", nPos++);
				DescribeAColumn(T, "adate", "Data emiss.", nPos++);
				DescribeAColumn(T, "printdate", "Data stampa", nPos++);
			}
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type == "documentitrasmessi") {
				if (R["kpaymenttransmission"] == DBNull.Value) return false;
				return true;
			}

			return true;
		}

		static DataTable callSp(DataAccess Conn, List<int> idincList) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista AS int_list;");
			int currblockLen = 0;
			foreach (int id in idincList) {
				if (currblockLen == 0) {
					sb.Append($"insert into @lista values ({id})");
				}
				else {
					sb.Append($",({id})");
				}

				currblockLen++;
				if (currblockLen == 20) {
					sb.AppendLine(";");
					currblockLen = 0;
				}
			}

			if (currblockLen > 0) sb.AppendLine(";");
            sb.AppendLine($"exec  trasmele_expense_opisiopeplus_ins {Conn.GetEsercizio()},null,'N',@lista");
			return Conn.SQLRunner(sb.ToString(),false,300);
		}

		public static string SimulaGenerazioneOrdinativo(DataAccess myConn, DataTable Explastview,
			out Dictionary<int, DataRow> admitted) {
			Dictionary<object, int> ex = new Dictionary<object, int>(); //idexp, byte
			admitted = new Dictionary<int, DataRow>();
			int limiteOPIinByte = 184320;
			QueryHelper QHS = myConn.GetQueryHelper();
			//if (Meta.IsEmpty) return;
			object spexport = "trasmele_expense_opisiopeplus_ins";
			object ypay = myConn.GetSys("esercizio");
			//int dimensioneTotale = 0;
			int dimensioneMovCorrente = 0;
			int dimensioneMandatoVuoto = 0;
			string Dsingolo = null;
			string DocMandatoVuoto = null;
			if (Explastview.Select().Length == 0) return null;

			siopeplus_export SS = new siopeplus_export(myConn);
			List<DataRow> Lpagamenti = new List<DataRow>();
			foreach (DataRow rExp in Explastview.Rows) {
				if (rExp.RowState != DataRowState.Deleted) Lpagamenti.Add(rExp);
			}

			DataTable T = callSp(myConn, (from r in Lpagamenti select (int) r["idexp"]).ToList());
			if (T == null || !T.Columns.Contains("kind")) {
				return "Sono presenti errori nei dati";
			}

			DataRow[] MM = T.Select("(kind='MANDATO')");
			if (MM.Length == 0) {
				return "Errore interno";
			}

			var mandatoVuoto = SS.creaMandato(MM[0]);
			mandatoVuoto.dati_a_disposizione_ente_mandato = new pagamenti.ctDati_a_disposizione_ente_mandato();
			mandatoVuoto.dati_a_disposizione_ente_mandato.struttura = MM[0]["dati_codice_struttura"].ToString();
			mandatoVuoto.dati_a_disposizione_ente_mandato.codice_struttura = MM[0]["dati_codice_struttura"].ToString();
			mandatoVuoto.dati_a_disposizione_ente_mandato.codice_ipa_struttura =MM[0]["dati_codice_ipa_struttura"].ToString();

			DocMandatoVuoto = mandatoVuoto.toXml(Encoding.GetEncoding("ISO-8859-1"));
			dimensioneMandatoVuoto = DocMandatoVuoto.Length + 50;
			//dimensioneTotale = dimensioneMandatoVuoto;

			var infoBeneficiari = SS.get_listaBeneficiari(T);
			//Sdoppio il ciclo per dare priorit‡ alle righe gi‡ salvate
			var dimMandati = new Dictionary<int, int>();
			foreach (var state in new[] {DataRowState.Unchanged, DataRowState.Modified}) {
				foreach (DataRow rExp in Lpagamenti) {
					if (rExp.RowState != state) continue;
					object idexp = rExp["idexp"];
					if (rExp["kpay"] == DBNull.Value) continue;
					int kPay = CfgFn.GetNoNullInt32(rExp["kpay"]);
					if (!dimMandati.ContainsKey(kPay)) dimMandati[kPay] = dimensioneMandatoVuoto;
					var dimensioneTotale = dimMandati[kPay];

					if (ex.ContainsKey(idexp)) {
						dimensioneMovCorrente = ex[idexp];
					}
					else {
						if (!infoBeneficiari.ContainsKey((int) idexp)) {
							string error =
								$"L'incasso {rExp["description"]} dal beneficiario {rExp["registry"]} non Ë stato elencato tra i versanti";
							return error;
						}

						var infoBeneficiario = infoBeneficiari[(int) idexp];
						Dsingolo = infoBeneficiario.toXml(Encoding.GetEncoding("ISO-8859-1"));
						ex[idexp] = Dsingolo.Length;
						dimensioneMovCorrente = Dsingolo.Length;
					}

					if (dimensioneTotale + dimensioneMovCorrente <= limiteOPIinByte) {
						dimMandati[kPay] = dimensioneTotale + dimensioneMovCorrente;
					}
					else {
						return
							"Per rispettare la dimensione massima consentita nella trasmissione OPI Siope, ridurre il numero dei pagamenti."
							+ $"Diversamente il file sar‡ scartato perchË essendo pari a {dimensioneTotale + dimensioneMovCorrente} supera il limite dei 180 Kb.";
					}

					admitted[(int) idexp] = rExp;
				}

			}

			return null;
		}


		public bool Verifica_config_SiopePlus() {
			QueryHelper QHS = Conn.GetQueryHelper();
			object config =
				Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "config", null);
			if (config == null || config == DBNull.Value) return false;
			if (config.ToString().StartsWith("nomeutente|password|"))
				return false; // non Ë stato configurato il servizio di invio tramite Web Service
			return true;
		}

		decimal GetCurrentImporto(DataSet MyDS) {
			DataTable Spesa = MyDS.Tables["expenseview"];
			decimal importo = 0;
			foreach (DataRow SP in Spesa.Rows) {
				if (SP.RowState == DataRowState.Deleted) continue;
				if (SP["kpay"] == DBNull.Value) continue;
				if (SP["curramount"] == DBNull.Value) continue;
				importo += Convert.ToDecimal(SP["curramount"]);
			}

			return importo;

		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (R["adate"] == DBNull.Value) {
				errmess = "Il campo 'Data contabile' Ë obbligatorio";
				errfield = "adate";
				return false;
			}

			if (R["idtreasurer"] == DBNull.Value) {
				errmess = "il cassiere Ë obbligatorio";
				errfield = "idtreasurer";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["flag"]) == 0) {
				errmess = "Bisogna specificare se il mandato Ë in C/Competenza, in C/Residui oppure Misto";
				errfield = "flag";
				return false;
			}

			DataSet MyDS = R.Table.DataSet;
			DataTable Spesa = MyDS.Tables["expenseview"];
			if (Spesa != null) {
				decimal importo = GetCurrentImporto(MyDS);
				if (importo <= 0) {

					if (!showClientMsg("L'importo del documento Ë nullo o negativo. Confermi l'operazione?",
						"Importo nullo o negativo", MessageBoxButtons.OKCancel)) {
						errmess = "Importo del documento nullo o negativo";
						errfield = null;
						return false;
					}
				}
			}

			DataTable ExpLastview = MyDS.Tables["expenselastview"];
			if ((ExpLastview != null) && Verifica_config_SiopePlus()) {
				//Chiama il metodo che controlla la lunghezza dell'ordinativo
				// non Ë bloccate ai fini del salvataggio
				Dictionary<int, DataRow> admitted;
				errmess = SimulaGenerazioneOrdinativo(Conn, ExpLastview, out admitted);
				if (errmess != null) return false;
			}

			return true;
		}
	}
}