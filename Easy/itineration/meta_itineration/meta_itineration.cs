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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_itineration//meta_missione//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_itineration : Meta_easydata
	{
		public Meta_itineration(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "itineration") {
			EditTypes.Add("default");
			ListingTypes.Add("lista");
			//----------------------------------instm-------------------------------begin
			Name = "Missioni";
			EditTypes.Add("instmuser");
			ListingTypes.Add("instmuser");
			//$EditTypes$
			//----------------------------------instm-------------------------------end
		}
		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				DefaultListType = "lista";
				Name = "Missione";
				return MetaData.GetFormByDllName("itineration_default");
			}
			return null;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.SetMySelector(T.Columns["nitineration"], "yitineration", 0);
			RowChange.MarkAsAutoincrement(T.Columns["nitineration"], null, null, 9);
			RowChange.MarkAsAutoincrement(T.Columns["iditineration"], null, null, 9);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yitineration", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "active", "S");
			SetDefault(PrimaryTable, "authneeded", "X");
			SetDefault(PrimaryDataTable, "clause_accepted", "N");
			SetDefault(PrimaryTable, "flagmove", 0);
			SetDefault(PrimaryTable, "flagoutside", "S");
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			errfield = null;
			errmess = null;
			object O = Conn.DO_READ_VALUE("web_config", null, "askitinerationclause");
			if (O == null) O = DBNull.Value;
			bool clause_needed = (O.ToString().ToUpper() == "S");

			if (CfgFn.GetNoNullInt32(R["idreg"]) <= 0) {
				errfield = "registry.title";
				errmess = "L'incaricato è un informazione obbligatoria.";
				return false;
			}


			if (R["start"].ToString() == QueryCreator.EmptyDate().ToString()) {
				errfield = "start";
				errmess = "Bisogna specificare la data inizio";
				return false;
			}
			if (R["stop"].ToString() == QueryCreator.EmptyDate().ToString()) {
				errfield = "stop";
				errmess = "Bisogna specificare la data fine";
				return false;
			}
			if (R["description"].ToString().Trim() == "") {
				errfield = "description";
				errmess = "Bisogna specificare la descrizione";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["idser"]) <= 0) {
				errfield = "idser";
				errmess = "Bisogna specificare la prestazione";
				return false;
			}

			//if (CfgFn.GetNoNullInt32(R["idregistrylegalstatus"]) <= 0) {
			//    errfield = "idregistrylegalstatus";
			//    errmess = "I dati relativi alla posizione giuridica dell'incaricato sono incompleti o mancanti.";
			//    return false;
			//}
			//itineration§2006§6
			bool IsAdmin = (GetSys("manage_prestazioni") != null)
						? GetSys("manage_prestazioni").ToString() == "S"
						: false;

			string filter_idrelated = "itineration§" + R["yitineration"].ToString() + "§" + R["nitineration"].ToString();
			filter_idrelated = QHS.CmpEq("idrelated", filter_idrelated);

			if (R["completed"].ToString() == "S" && R.Table.Columns.Contains("datecompleted")) {
				if (R["datecompleted"] == DBNull.Value) {
					errmess = "E' necessario specificare la  data di acquisizione documentazione definitiva";
					errfield = "datecompleted";
					return false;
				}
			}


			if (R.Table.Columns.Contains("datecompleted")) {
				if ((R.RowState == DataRowState.Added || (
					R.RowState == DataRowState.Modified && R["datecompleted", DataRowVersion.Original].ToString() != R["datecompleted"].ToString())
					)
					&& R["datecompleted"] != DBNull.Value
					) {
					DateTime dateCompleted = (DateTime) R["datecompleted"];

					if (R["stop"] == DBNull.Value) {
						errmess = "Non è possibile pagare una missione senza data fine";
						errfield = "stop";
						return false;
					}
					DateTime stop = (DateTime) R["stop"];
					if (dateCompleted < stop) {
						errmess = "La data di acquisizione documentazione definitiva non può precedere la data fine missione";
						errfield = "datecompleted";
						return false;
					}

					if (dateCompleted.Year != Conn.GetEsercizio()) {
						errmess = "La data di acquisizione documentazione definitiva deve essere quella dell'esercizio all'atto dell'inserimento";
						errfield = "datecompleted";
						return false;
					}

					int yitineration = CfgFn.GetNoNullInt32(R["yitineration"]);
					if (dateCompleted.Year < yitineration) {
						errmess = "La data di acquisizione documentazione definitiva non può precedere l'anno missione";
						errfield = "datecompleted";
						return false;
					}

				}
			}

			DataTable Tserviceregistry = Conn.RUN_SELECT("serviceregistry","*",null,filter_idrelated,null,null,true);
			if ((Tserviceregistry.Rows.Count > 0) && (R.RowState == DataRowState.Modified)) {
				bool error = false;
				string message = "";
				if (R["idreg", DataRowVersion.Current].ToString() != R["idreg", DataRowVersion.Original].ToString()) {
					message = "Percipiente \n\r ";
					error = true;
				}
				if (R["description", DataRowVersion.Current].ToString() != R["description", DataRowVersion.Original].ToString()) {
					message = message + "Descrizione \n\r ";
					error = true;
				}
				if (R["start", DataRowVersion.Current].ToString() != R["start", DataRowVersion.Original].ToString()) {
					message = message + "Data Inizio \n\r ";
					error = true;
				}
				if (R["stop", DataRowVersion.Current].ToString() != R["stop", DataRowVersion.Original].ToString()) {
					message = message + "Data Fine \n\r ";
					error = true;
				}
				if (CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["totalgross", DataRowVersion.Current])) != CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["totalgross", DataRowVersion.Original]))) {
					message = message + "Importo lordo \n\r ";
					error = true;
				}
				if (error) {
					if (IsAdmin) {
						errmess = "L'Anagrafe delle Prestazioni è stata già generata, e risultano modificati i seguenti dati: \n\r"
							+ message + "Adeguare anche i dati dell'Incarico.";
						MessageBox.Show(errmess, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					} else {
						errmess = "Risultano modificati i seguenti dati: \n\r"
							+ message + "La modifica non è consentita perché l'Anagrafe delle Prestazioni è stata già generata.\r\n" +
							"Contattare il servizio assistenza o un utente con ruolo 'manage_prestazioni' ";
						return false;
					}
				}
			}
			//

			if ((R["start"] != DBNull.Value) && (R["stop"] != DBNull.Value)) {
				DateTime start = (DateTime)R["start"];
				DateTime stop = (DateTime)R["stop"];

				if (start > stop) {
					errmess = "Attenzione! Non può essere immessa una data inizio successiva alla data fine";
					errfield = "start";
					return false;
				}
			} else {
				errmess = "Attenzione! Specificare inizio e termine della missione";
				return false;
			}

			//Se il percipiente ha un indirizzo AP, nel form del compenso si deve scegliere o S o N
			String codeaddress = "07_SW_ANP";
			DateTime DataInizio = (DateTime)R["start"];
			if (DataInizio.Year < 1900) DataInizio = new DateTime(1900, 1, 1);

			object idaddresskind = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", codeaddress), "idaddress");
			DataTable Address = DataAccess.RUN_SELECT(Conn, "registryaddress", "*", null,
								QHS.AppAnd(QHS.CmpEq("idaddresskind", idaddresskind), QHS.CmpEq("idreg", R["idreg"]),
								QHS.CmpLe("start", DataInizio), QHS.NullOrGe("stop", DataInizio)), false);
			if (Address.Rows.Count > 0) {
				if ((R["authneeded"].ToString() != "S") && (R["authneeded"].ToString() != "N")) {
					errfield = "authneeded";
					errmess = "Il percipiente ha un indirizzo Anagrafe delle Prestazioni, pertanto va indicato se necessita o meno dell'autorizzazione.";
					return false;
				}
			}

			if (R["authneeded"].ToString() == "S" && R["authdoc"].ToString() == "") {
				errmess = "Il campo 'Documento' è obbligatorio";
				errfield = "authdoc";
				return false;
			}

			if (R["authneeded"].ToString() == "S" && R["authdocdate"] == DBNull.Value) {
				errmess = "Il campo 'data' è obbligatorio";
				errfield = "authdocdate";
				return false;
			}

			if (R["authneeded"].ToString() == "N" && R["noauthreason"].ToString() == "") {
				errmess = "Il campo 'Motivo' è obbligatorio";
				errfield = "authdoc";
				return false;
			}
			//controlla il check della clausola se è valorizzato KmMezzoProprio OR motivo OR targa, l'OR è stato aggiunto perchè la missione di CT non valorizza KmMezzoProprio.
			if (clause_needed && R["clause_accepted"].ToString().ToUpper() != "S" && (R["owncarkm"] != DBNull.Value || R["vehicle_info"] != DBNull.Value || R["vehicle_motive"] != DBNull.Value)) {
				errmess = "E' necessario accettare la clausola per l'uso del mezzo proprio";
				errfield = "clause_accepted";
				return false;
			}

			if ((CfgFn.GetNoNullInt32(R["owncarkm"]) != 0) && (R["vehicle_info"] == DBNull.Value)) {
				errmess = "Con l'uso del mezzo proprio è obbligatorio compilare le informazioni relative al veicolo";
				errfield = "vehicle_info";
				return false;
			}

			if (R["flagweb"].ToString().ToUpper() == "S" &&
				(CfgFn.GetNoNullInt32(R["iditinerationstatus"]) >= 2) &&
				(CfgFn.GetNoNullInt32(R["iditinerationstatus"]) < 6) &&
				CfgFn.GetNoNullInt32(R["idauthmodel"]) <= 0) {
				errmess = "Non è possibile salvare la Missione senza un modello Autorizzativo";
				errfield = "idauthmodel";
				return false;
			}

			bool DirectAuth = false;
			DirectAuth = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
			   "itineration_directauth").ToString().ToUpper() == "S";

			if ((DirectAuth) && R["flagweb"].ToString().ToUpper() == "S" &&
				(CfgFn.GetNoNullInt32(R["iditinerationstatus"]) == 1) &&
				CfgFn.GetNoNullInt32(R["idauthmodel"]) <= 0) {
				errmess = "Non è possibile salvare la Missione senza un modello Autorizzativo";
				errfield = "idauthmodel";
				return false;
			}
			if (!base.IsValid(R, out errmess, out errfield)) return false;


			return true;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "lista")
				return base.SelectOne(ListingType, filter, "itinerationview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "itineration", Exclude);
		}

		//----------------------------------instm-------------------------------begin

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			foreach (DataColumn C in T.Columns) {
				DescribeAColumn(T, C.ColumnName, "", -1);
			}
			int nPos = 1;

			switch (ListingType) {
				case "instmuser": {
						DescribeAColumn(T, "description", "Motivazione", nPos++);
						DescribeAColumn(T, "location", "Località di destinazione", nPos++);
						DescribeAColumn(T, "start", "data inizio", nPos++);
						DescribeAColumn(T, "stop", "data fine", nPos++);
						break;
					}
					//$DescribeAColumn$
			}
		}

		public override string GetSorting(string ListingType) {

			switch (ListingType) {
				case "instmuser": {
						return "start asc , stop asc ";
					}
					//$GetSorting$
			}
			return base.GetSorting(ListingType);
		}

		public override string GetStaticFilter(string ListingType) {
			switch (ListingType) {
				case "instmuser": {
						return "(idreg='" + security.GetUsr("idreg").ToString() + "')";
						break;
					}
					//$GetStaticFilter$
			}
			return base.GetStaticFilter(ListingType);
		}

		//----------------------------------instm-------------------------------end


	}
}

