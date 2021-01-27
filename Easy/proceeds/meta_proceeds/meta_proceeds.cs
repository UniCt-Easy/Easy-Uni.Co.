
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
//Pino: using documentoincasso_gener_auto; diventato inutile
//Pino: using documentoincasso_multiplo; diventato inutile
//using proceeds_default;//documentoincasso
using siopeplus_functions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace meta_proceeds //meta_documentoincasso//
{
	/// <summary>
	/// Summary description for Class1.
	/// Author: Leo, Start 11 Dec 2002, End 12 Dec 2002
	/// Updated by Leo 15 Dec 2002
	/// Revised by Nino 21/2/2003 (mancava IsValid!!!!)
	/// </summary>
	public class Meta_proceeds : Meta_easydata {
		public Meta_proceeds(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "proceeds") {
			// listapermovbancario elenca in ordine di numero mandato filtrando solo l'esercizio corrente
			EditTypes.Add("default");
			EditTypes.Add("generazioneautomatica");
			EditTypes.Add("reversalemultipla");
			ListingTypes.Add("lista");
			ListingTypes.Add("listapermovbancario");
			ListingTypes.Add("documentitrasmessi");
			ListingTypes.Add("elencoautomatico");
			Name = "Documento di incasso";

		}

		protected override Form GetForm(string FormName) {
			object MDVer = Conn.GetSys("MetaDataVersion");
			if (MDVer.ToString().CompareTo("2.1.160.0") < 0) {
				showClientMsg("Per poter eseguire il form richiesto è necessario attendere " +
				              "il completamento del live-update del software, poi CHIUDERE E RIAPRIRE il programma.",
					"Errore", MessageBoxButtons.OK);
				return null;
			}

			;

			if (FormName == "generazioneautomatica") {
				Name = "Generazione automatica delle reversali";
				return MetaData.GetFormByDllName("proceeds_generazioneautomatica"); //PinoRana
			}

			if (FormName == "reversalemultipla") {
				Name = "Reversale di incasso";
				DefaultListType = "lista";
				return MetaData.GetFormByDllName("proceeds_reversalemultipla"); //PinoRana
			}

			if (FormName == "default") {
				Name = "Reversale singola";
				DefaultListType = "lista";
				return MetaData.GetFormByDllName("proceeds_default"); //PinoRana
			}

			return null;
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if (C.ColumnName == "kproceedstransmission") return;
			base.InsertCopyColumn(C, Source, Dest);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "ypro", GetSys("esercizio").ToString());
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			//DataTable TT = Conn.RUN_SELECT("config","flagfruitful",null,
			//    "(ayear="+QueryCreator.quotedstrvalue(GetSys("esercizio"),false)+ ")",null,false);
			//int flag = CfgFn.GetNoNullInt32(PrimaryTable.Columns["flag"].DefaultValue);
			//if ((TT.Rows.Count != 0) && (TT != null)) {
			//    flag = flag & 0xF7;
			//    if (TT.Rows[0]["flagfruitful"].ToString().ToUpper() == "F") {
			//        flag = flag + 0x08;  //def. Fruttifero
			//    }
			//    SetDefault(PrimaryTable,"flag", flag);
			//}
			if (flagautostampa == null) {
				flagautostampa = Conn.DO_READ_VALUE("config",
					QHS.CmpEq("ayear", GetSys("esercizio")),
					"proceeds_flagautoprintdate");
			}

			if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
				SetDefault(PrimaryTable, "printdate", GetSys("datacontabile"));
			}
		}

		object flagautostampa = null;

		private static bool EnableNDoc_Treasurer(DataRow R, DataAccess Conn) {
			QueryHelper QHS;
			QHS = Conn.GetQueryHelper();
			object idtreasurer = R["idtreasurer"];
			if ((idtreasurer == DBNull.Value) || (CfgFn.GetNoNullInt32(idtreasurer) == 0)) return false;
			object flagautondoc_treasurer = Conn.DO_READ_VALUE("treasurer", QHS.CmpEq("idtreasurer", idtreasurer),
				"enable_ndoc_treasurer");
			if ((flagautondoc_treasurer != null) && (flagautondoc_treasurer != DBNull.Value) &&
			    (flagautondoc_treasurer.ToString().ToUpper() == "S")) {
				return true;
			}

			return false;
		}

		static Dictionary<int, object> enable_ndoc_treasurers = new Dictionary<int, object>();

		private static object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
			int npro_treasurer = GetMaxNpro_Treasurer(R, Conn);
			if (npro_treasurer < 0) return DBNull.Value;
			return npro_treasurer;
		}

		private static int GetMaxNpro_Treasurer(DataRow R, DataAccess Conn) {
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

				string sqlmax = "SELECT ISNULL(MAX(npro_treasurer)," + numiniziale.ToString() +
				                ") + 1 FROM proceeds WHERE "
				                + QHS.AppAnd(QHS.CmpEq("idtreasurer", idtreasurer), QHS.CmpEq("ypro", R["ypro"]));

				DataTable t = Conn.SQLRunner(sqlmax, true, 0);
				return CfgFn.GetNoNullInt32(t.Rows[0][0]);
			}

			return -1;
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.ClearMySelector(T, "npro");
			RowChange.setMinimumTempValue(T.Columns["kpro"], 9000000);
			RowChange.setMinimumTempValue(T.Columns["npro"], 9000000);

			RowChange.MarkAsAutoincrement(T.Columns["kpro"], null, null, 0);
			RowChange.MarkAsAutoincrement(T.Columns["npro"], null, null, 0);
			RowChange.SetMySelector(T.Columns["npro"], "ypro", 0);

			if (T.Columns.Contains("npro_treasurer")) {
				RowChange.MarkAsAutoincrement(T.Columns["npro_treasurer"], null, null, 7);
				RowChange.MarkAsCustomAutoincrement(T.Columns["npro_treasurer"],
					new RowChange.CustomCalcAutoID(CalcID));
			}

			DataRow R = base.Get_New_Row(ParentRow, T);
			if (EnableNDoc_Treasurer(R, Conn) && (!T.Columns.Contains("npro_treasurer"))) {
				showClientMsg("Problemi nel calcolo del progressivo reversale per cassiere", "Attenzione",
					MessageBoxButtons.OK);
			}

			if (flagautostampa == null) {
				flagautostampa = Conn.DO_READ_VALUE("config",
					QHS.CmpEq("ayear", GetSys("esercizio")),
					"proceeds_flagautoprintdate");
			}

			if ((flagautostampa != null) && (flagautostampa.ToString().ToUpper() == "S")) {
				R["printdate"] = R["adate"];
			}

			if (T.Columns.Contains("npro_treasurer")) {
				R["npro_treasurer"] = -9999;
			}

			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType == "listapermovbancario" ||
			    ListingType == "lista" ||
			    ListingType == "documentitrasmessi") {
				return base.SelectOne(ListingType, filter, "proceedsview", Exclude);
			}

			return base.SelectOne(ListingType, filter, searchtable, Exclude);
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);
			if (ListingType == "documentitrasmessi") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;

				DescribeAColumn(T, "ypro", "Eserc.", nPos++);
				DescribeAColumn(T, "npro", "Numero", nPos++);
				DescribeAColumn(T, "adate", "Data emiss.", nPos++);
				DescribeAColumn(T, "printdate", "Data stampa", nPos++);
				FilterRows(T);
			}

			if (ListingType == "elencoautomatico") {
				foreach (DataColumn C in T.Columns) {
					DescribeAColumn(T, C.ColumnName, "", -1);
				}

				int nPos = 1;
				DescribeAColumn(T, "ypro", "Eserc.", nPos++);
				DescribeAColumn(T, "npro", "Numero", nPos++);
				DescribeAColumn(T, "adate", "Data emiss.", nPos++);
				DescribeAColumn(T, "printdate", "Data stampa", nPos++);
			}
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type == "documentitrasmessi") {
				if (R["kproceedstransmission"] == DBNull.Value) return false;
				return true;
			}

			return true;
		}

		public bool Verifica_config_SiopePlus() {
			QueryHelper QHS = Conn.GetQueryHelper();
			object config =
				Conn.DO_READ_VALUE("opisiopeplus_config", QHS.CmpEq("code", "opi_siopeplus"), "config", null);
			if (config == null || config == DBNull.Value) return false;
			if (config.ToString().StartsWith("nomeutente|password|"))
				return false; // non è stato configurato il servizio di invio tramite Web Service
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
			sb.AppendLine($"exec  trasmele_income_opisiopeplus_ins {Conn.GetEsercizio()},null,'N',@lista");
			return Conn.SQLRunner(sb.ToString(),false,300);
		}


		public static string SimulaGenerazioneOrdinativo(DataAccess myConn, DataTable Inclastview,
			out Dictionary<int, DataRow> admitted) {
			Dictionary<object, int> ex = new Dictionary<object, int>(); //idinc, byte
			int limiteOPIinByte = 184320;
			QueryHelper QHS = myConn.GetQueryHelper();
			object spexport = "trasmele_income_opisiopeplus_ins";
			object ypro = myConn.GetSys("esercizio");
			//int dimensioneTotale = 0;
			int dimensioneMovCorrente = 0;
			int dimensioneReversaleVuota = 0;
			string Dsingolo = null;
			string DocReversaleVuota = null;
			var SS = new siopeplus_export(myConn);
			var infoVersante = new bankdispositionsetup_siopeplus_incassi.reversaleInformazioni_versante();
			admitted = new Dictionary<int, DataRow>();

			if (Inclastview.Select().Length == 0) return null;

			List<DataRow> Lincassi = new List<DataRow>();
			foreach (DataRow rInc in Inclastview.Rows) {
				if (rInc.RowState != DataRowState.Deleted) Lincassi.Add(rInc);
			}

			DataTable T = callSp(myConn, (from r in Lincassi select (int) r["idinc"]).ToList());
			if (T == null || !T.Columns.Contains("kind")) {
				return "Sono presenti errori nei dati";
			}

			DataRow[] MM = T.Select("(kind='REVERSALE')");
			if (MM.Length == 0) {
				return "Errore interno";
			}

			var reversaleVuota = SS.creaReversale(MM[0]);
			reversaleVuota.dati_a_disposizione_ente_reversale = new bankdispositionsetup_siopeplus_incassi.ctDati_a_disposizione_ente_reversale();
			reversaleVuota.dati_a_disposizione_ente_reversale.struttura = MM[0]["dati_codice_struttura"].ToString();
			reversaleVuota.dati_a_disposizione_ente_reversale.codice_struttura = MM[0]["dati_codice_struttura"].ToString();
			reversaleVuota.dati_a_disposizione_ente_reversale.codice_ipa_struttura = MM[0]["dati_codice_ipa_struttura"].ToString();

			DocReversaleVuota = reversaleVuota.toXml(Encoding.GetEncoding("ISO-8859-1"));
			dimensioneReversaleVuota = DocReversaleVuota.Length + 50;
			//dimensioneTotale = dimensioneReversaleVuota;

			var infoVersanti = SS.get_listaVersanti(T);

			var available = new List<int>();

			var dimReversali = new Dictionary<int, int>();
			foreach (var state in new[] {DataRowState.Unchanged, DataRowState.Modified}) {
				foreach (DataRow rInc in Lincassi) {
					if (rInc.RowState != state) continue;
					if (rInc["kpro"] == DBNull.Value) continue;
					int kPro = CfgFn.GetNoNullInt32(rInc["kpro"]);
					if (!dimReversali.ContainsKey(kPro)) dimReversali[kPro] = dimensioneReversaleVuota;
					var dimensioneTotale = dimReversali[kPro];

					object idinc = rInc["idinc"];
					if (ex.ContainsKey(idinc)) {
						dimensioneMovCorrente = ex[idinc];
					}
					else {
						if (!infoVersanti.ContainsKey((int) idinc)) {
							string error =
								$"L'incasso {rInc["description"]} dal versante {rInc["registry"]} non è stato elencato tra i versanti";
							return error;
						}

						infoVersante = infoVersanti[(int) idinc];
						Dsingolo = infoVersante.toXml(Encoding.GetEncoding("ISO-8859-1"));
						//File.WriteAllText(Path.Combine(Application.StartupPath,idinc.ToString()+"_"+Dsingolo.Length.ToString()),Dsingolo);
						dimensioneMovCorrente = Dsingolo.Length;
						ex[idinc] = Dsingolo.Length;
					}
					//QueryCreator.MarkEvent($"Dimensione calcolata:{dimensioneTotale}");
					if (dimensioneTotale + dimensioneMovCorrente > limiteOPIinByte) {
						return
							"Per rispettare la dimensione massima consentita nella trasmissione OPI Siope ridurre il numero degli incassi."
							+ $"Diversamente il file sarà scartato perchè essendo pari a {dimensioneTotale + dimensioneMovCorrente} supera il limite dei 180 Kb.";
					}

					//File.WriteAllText(Path.Combine(Application.StartupPath, idinc.ToString() + "_" + Dsingolo.Length.ToString()),Dsingolo);
					dimReversali[kPro] = dimensioneTotale+dimensioneMovCorrente;
					admitted[(int) idinc] = rInc;
				}
			}
			

			//File.WriteAllText(Path.Combine(Application.StartupPath,"reve_test_"+Dsingolo.Length.ToString()),Dsingolo);
			return null;

		}


		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (R["adate"] == DBNull.Value) {
				errmess = "Il campo 'Data contabile' è obbligatorio";
				errfield = "adate";
				return false;
			}

			if (CfgFn.GetNoNullInt32(R["flag"]) == 0) {
				errmess = "Bisogna specificare se la reversale è in C/Competenza, in C/Residui oppure Mista";
				errfield = "flag";
				return false;
			}

			DataSet MyDS = R.Table.DataSet;
			DataTable Entrata = MyDS.Tables["incomeview"];
			if (Entrata != null) {

				decimal importo = 0;
				foreach (DataRow SP in Entrata.Rows) {
					if (SP.RowState == DataRowState.Deleted) continue;
					if (SP["kpro"] == DBNull.Value) continue;
					if (SP["curramount"] == DBNull.Value) continue;
					importo += Convert.ToDecimal(SP["curramount"]);
				}

				if (importo <= 0) {
					if (!showClientMsg("L'importo del documento è nullo o negativo. Confermi l'operazione?",
						"Importo nullo o negativo", MessageBoxButtons.OKCancel)) {
						errmess = "Importo del documento nullo o negativo";
						errfield = null;
						return false;
					}
				}
			}

			DataTable IncLastview = MyDS.Tables["incomelastview"];
			if ((IncLastview != null) && Verifica_config_SiopePlus()) {
				Dictionary<int, DataRow> admitted;
				errmess = SimulaGenerazioneOrdinativo(Conn, IncLastview, out admitted);
				if (errmess != null) {
					return false;
				}

			}

			return true;
		}
	}
}
