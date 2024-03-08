
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
//Pino: using ordinegenerico; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_mandate //meta_ordinegenerico//
{
	/// <summary>
	/// Revised by Nino on 30/1/2003.
	/// </summary>
	public class Meta_mandate : Meta_easydata {
		public Meta_mandate(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "mandate") {
			EditTypes.Add("default");
			EditTypes.Add("request");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yman", GetSys("esercizio"));
			SetDefault(PrimaryTable, "docdate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "officiallyprinted", "N");
			SetDefault(PrimaryTable, "idcurrency",
				Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
			SetDefault(PrimaryTable, "active", "S");
			SetDefault(PrimaryTable, "flagintracom", "N");
			SetDefault(PrimaryTable, "resendingpcc", "N");
			if (PrimaryTable.Columns.Contains("flagdanger")) SetDefault(PrimaryTable, "flagdanger", "N");
			if (PrimaryTable.Columns.Contains("flagtenderresult")) SetDefault(PrimaryTable, "flagtenderresult", "A");
			if (PrimaryTable.Columns.Contains("requested_doc")) SetDefault(PrimaryTable, "requested_doc", 0);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetSelector(T, "yman");
			RowChange.SetSelector(T, "idmankind");
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		protected override Form GetForm(string FormName) {

			DefaultListType = "lista";
			if (FormName == "default") {
				Name = "Contratto Passivo";
				return MetaData.GetFormByDllName("mandate_default");
			}

			if (FormName == "request") {
				Name = "Richiesta d'ordine";
				return MetaData.GetFormByDllName("mandate_default");
			}

			return null;
		}

		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype == "default") {
			}
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if ((C.ColumnName == "yman") || (C.ColumnName == "nman") || C.ColumnName == "idmandatestatus" ||
			    C.ColumnName == "cigcode"||
				(C.ColumnName == "idmankind_origin")||
				(C.ColumnName == "yman_origin")||
				(C.ColumnName == "nman_origin")) return;
			base.InsertCopyColumn(C, Source, Dest);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if ((ListingType == "lista") || (ListingType == "default"))
				return base.SelectOne(ListingType, filter, "mandateview", Exclude);
			return base.SelectOne(ListingType, filter, "mandate", Exclude);
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {


			if (R["idmankind"].ToString() == "") {
				errfield = "idmankind";
				errmess = "E' necessario scegliere il tipo contratto";
				return false;
			}


			if (R["description"].ToString() == "") {
				errfield = "description";
				errmess = "E' necessario inserire la descrizione";
				return false;
			}

			int flag = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("mandatekind", QHS.CmpEq("idmankind", R["idmankind"]),
				"flag"));
			bool abilitaLotti = (flag & 1) == 0;
			bool abilitaConsip = (flag & 2) == 0;

			if (R.Table.Columns.Contains("flagtenderresult") && edit_type != "request" && abilitaLotti) {
				if (R["flagtenderresult"].ToString() == "") {
					errmess = "E' necessario specificare l'esito della gara";
					errfield = "flagtenderresult";
					return false;
				}
			}

			if (R.Table.Columns.Contains("flagtenderresult") && edit_type != "request" && abilitaLotti) {
				if (R["flagtenderresult"].ToString() != "A" && R["active"].ToString() == "S") {
					errmess = "Solo una gara aggiudicata può essere resa valida per la contabilizzazione";
					errfield = "flagtenderresult";
					return false;
				}
			}

			if (R.Table.Columns.Contains("flagtenderkind") && edit_type != "request" && abilitaLotti) {
				if (R["flagtenderkind"].ToString() == "") {
					errmess = "E' necessario specificare il tipo di gara";
					errfield = "flagtenderkind";
					return false;
				}
			}

			//      if (R.Table.DataSet.Tables.Contains("mandatedetail")) {
			//    DataTable md = R.Table.DataSet.Tables["mandatedetail"];
			//    if (md.Columns.Contains("idepexp")) {
			//        if (R["active"].ToString() != "S") {
			//            if (md.Select(QHC.IsNotNull("idepexp")).Length > 0) {
			//                errmess =
			//                          "Operazione non consentita in presenza di impegni di budget.\r\n"+
			//                          "Occorre procedere con l'annullamento dei dettagli del contratto con apposizione della data di annullamento.";
			//                errfield = "active";
			//                return false;
			//            }
			//        }
			//    }
			//}
			object multireg = Conn.DO_READ_VALUE("mandatekind", "(idmankind=" +
			                                                    QueryCreator.quotedstrvalue(R["idmankind"], true) + ")",
				"multireg");
			if (multireg == null) multireg = "N";
			string smultireg = multireg.ToString().ToUpper();

			if ((CfgFn.GetNoNullInt32(R["idreg"]) == 0) && (smultireg != "S") && edit_type != "request" &&
			    LinkedForm != null &&
			    (R["flagtenderresult"].ToString() == "A")) {
				errmess = "Il campo 'Fornitore' è obbligatorio";
				errfield = "idreg";
				return false;
			}

			if ((CfgFn.GetNoNullInt32(R["idreg"]) != 0) && edit_type != "request" && LinkedForm != null) {
				DataTable reg = Conn.RUN_SELECT("registry", "*", null, QHS.CmpEq("idreg", R["idreg"]), null, false);
				if (reg.Rows.Count == 0) {
					errmess = $"L'anagrafica di id {R["idreg"]} non esiste sul db. Correggere il riferimento.";
					errfield = "idreg";
					return false;
				}

				DataRow anag = reg.Rows[0];
				object registryclass = Conn.DO_READ_VALUE("registryclass",
					QHS.CmpEq("idregistryclass", anag["idregistryclass"]),
					"flaghuman");
				if (registryclass != null && registryclass.ToString().ToUpper() == "S") {
					object cf = anag["cf"];
					if (cf != DBNull.Value) {
						string errori;
						if (!funzioni_configurazione.CalcolaCodiceFiscale.CodiceFiscaleValido(Conn, anag, out errori)) {
							errmess = "Nel codice fiscale del fornitore sono stati rilevati i seguenti errori:\n\r" +
							          errori;
							errfield = "idreg";
							return false;
						}
					}
				}
				else {
					object cf = anag["cf"];
					if (cf != DBNull.Value && cf.ToString().Length != 11) {
						string errori;
						funzioni_configurazione.CalcolaCodiceFiscale.CheckCF(cf.ToString(), out errori);
						if (errori != "") {
							errmess = "Nel codice fiscale del fornitore sono stati rilevati i seguenti errori:\n\r" +
							          errori;
							errfield = "idreg";
							return false;
						}
					}

					if (cf != DBNull.Value && cf.ToString().Length == 11) {

						foreach (char c in cf.ToString().ToCharArray()) {
							if (!char.IsDigit(c)) {
								errmess = "Il codice fiscale di 11 cifre non è corretto";
								errfield = "idreg";
								return false;
							}
						}

					}
				}

			}

			if ((R.RowState == DataRowState.Added) && (!RowChange.IsAutoIncrement(R.Table.Columns["nman"]))) {
				int NPRESENT = Conn.RUN_SELECT_COUNT("mandate",
					"(idmankind=" + QueryCreator.quotedstrvalue(R["idmankind"], true) + ")AND" +
					"(yman=" + QueryCreator.quotedstrvalue(R["yman"], true) + ")AND" +
					"(nman=" + QueryCreator.quotedstrvalue(R["nman"], true) + ")", true);
				if (NPRESENT > 0) {
					errmess = "Esiste già un contratto passivo con lo stesso numero.";
					errfield = "nman";
					return false;
				}
			}

			if (CfgFn.GetNoNullInt32(R["idcurrency"]) == 0 && edit_type != "request") {
				errmess = "Il campo 'Valuta' è obbligatorio";
				errfield = "idcurrency";
				return false;
			}

			if (R.Table.Columns.Contains("cigcode") && (R["cigcode"].ToString() != "") &&
			    (R["cigcode"].ToString().Length != 10)) {
				errmess = "Il CIG deve avere lunghezza 10.";
				errfield = "cigcode";
				return false;
			}
			//Controllo contenuto CIG

			if (R.Table.Columns.Contains("cigcode") && (R["cigcode"].ToString() != "") &&
			    !CfgFn.IsValidString(R["cigcode"].ToString())) {
				errmess = "Il CIG contiene caratteri non validi. I caratteri ammessi sono solo numeri e lettere";
				errfield = "cigcode";
				return false;
			}

			//Se il DS contiene la tabella mandatedetail controlla che ci siano delle modifiche 
			bool mandetChanged = hasChanges(R.Table.DataSet.Tables["mandatedetail"]);

			bool cigChanged = false;
			if (R.Table.DataSet.Tables["mandatecig"] != null) {
				cigChanged = hasChanges(R.Table.DataSet.Tables["mandatecig"]);
			}

			if ((R.Table.DataSet.Tables.Contains("mandatedetail"))

			    && mandetChanged

			    && (R.Table.DataSet.Tables.Contains("mandatecig")) &&
			    (R.Table.DataSet.Tables["mandatecig"].Rows.Count > 0)

			    && (cigChanged == false)

			) {
				string errore =
					"Alcuni dettagli del Contratto Passivo sono stati modificati. Verificare se sia necessario modificare anche i Lotti del Bando." +
					"\r\n" +
					"1) 'Annulla' per effettuare la correzione prima di salvare" + "\r\n" +
					"2) 'Ok' per salvare ugualmente senza correggere i Lotti";

				if (!ShowClientMsg(errore, "Attenzione!", MessageBoxButtons.OKCancel)) {
					errmess = "E' necessario aggiornare i Lotti del Bando";
					errfield = "description";
					return false;
				}
			}

			int yman = CfgFn.GetNoNullInt32(R["yman"]);

			if (
					!DateTime.TryParse(R["adate"].ToString(), out DateTime adate) || 
					yman == 0 ||
					adate.Year != yman
				) {

				errmess = "L'anno della data contabile non è coerente con l'anno dell'esercizio";
				errfield = "adate";

				return false;
			}

			if (!base.IsValid(R, out errmess, out errfield)) return false;


			return true;
		}

		public static bool hasChanges(DataTable t) {
			if (t == null) return false;
			foreach (DataRow R in t.Rows) {
				if (R.RowState == DataRowState.Unchanged) continue;
				if (R.RowState != DataRowState.Modified) return true;
				if (PostData.CheckForFalseUpdate(R)) {
					R.AcceptChanges();
					continue;
				}

				return true;
			}

			return false;
		}
	}
}
