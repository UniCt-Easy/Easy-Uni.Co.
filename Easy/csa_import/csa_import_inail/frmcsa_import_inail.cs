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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using q= metadatalibrary.MetaExpression;
using movimentofunctions;
using ep_functions;
using System.Collections;
using csa_import_default;

namespace csa_import_inail {
	public partial class frmcsa_import_inail : Form {
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC = new CQueryHelper();
		QueryHelper QHS;
		EntityDispatcher Dispatcher;
		int esercizio;
		private DataTable OutTable;
		private DataTable SP_Result;
		public csa_import_inail.dsFinancial dsFinancial;
		private System.Data.DataTable mData = new System.Data.DataTable();
		private System.Data.DataTable csa_bill_global = new System.Data.DataTable();

		public frmcsa_import_inail() {
			InitializeComponent();
		}
	 
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Dispatcher = Meta.Dispatcher as EntityDispatcher;
			Conn = Meta.Conn;
			esercizio = Conn.GetEsercizio();
			QHS = Conn.GetQueryHelper();
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			DataAccess.SetTableForReading(DS.bill_versamenti, "bill");
			DataAccess.SetTableForReading(DS.bill_ripartizione, "bill");

			string billfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.CmpEq("billkind", 'D'),
				QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
			GetData.SetStaticFilter(DS.bill_versamenti, billfilter);
			GetData.SetStaticFilter(DS.bill_netti, billfilter);
			GetData.SetStaticFilter(DS.bill_ripartizione, billfilter);
			GetElencoVociCSA();
		}





		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}


		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>


		void ResetWizard() {
			dsFinancial.Clear();
			DS.Clear();
			dgrImportazioni.DataSource = null;
			dgrEntiVersamento.DataSource = null;
			dgrSospesi.DataSource = null;
			mData.Clear();
		}



		private void FormatDataGrid(DataGrid dgr, DataTable tResult) {
			HelpForm.SetGridStyle(dgr, tResult);
			metadatalibrary.formatgrids fg = new formatgrids(dgr);
			fg.AutosizeColumnWidth();
		}

		string getHash(DataRow r, string[] listaCampi) {
			if ((listaCampi != null) && (listaCampi.Length > 0))
				return string.Join("§", (from field in listaCampi select r[field].ToString()).ToArray());

			string[] fields = null;
			if ((r.Table.TableName.ToString() == "csa_importver_partition_expenseview") ||
			    (r.Table.TableName.ToString() == "csa_importver_partition_incomeview")) {
				fields = new[] {"idcsa_import", "idver"};
			}

			return string.Join("§", (from field in fields select r[field].ToString()).ToArray());
		}


		private void ImpostaCaption(DataTable T) {
			foreach (DataColumn C in T.Columns)
				MetaData.DescribeAColumn(T, C.ColumnName, "", -1);

			int nPos = 0;
			if (T.TableName == "Enti") {
				MetaData.DescribeAColumn(T, "idreg_agency", ".idreg_agency", nPos++);
				MetaData.DescribeAColumn(T, "registry_agency", "Anagrafica Ente", nPos++);
				MetaData.DescribeAColumn(T, "annualpayment", "Versamenti annuali", nPos++);
				MetaData.DescribeAColumn(T, "nobill", "Non richiede sospeso in versamenti", nPos++);
			}
			if (T.TableName == "Importazioni") {
				MetaData.DescribeAColumn(T, "idcsa_import", ".#Codice", nPos++);
				MetaData.DescribeAColumn(T, "yimport", "Esercizio", nPos++);
				MetaData.DescribeAColumn(T, "nimport", "Numero", nPos++);
				MetaData.DescribeAColumn(T, "description", "Descrizione", nPos++);
				MetaData.DescribeAColumn(T, "adate", "Data Contabile", nPos++);
			}

 
			if (T.TableName == "tResult") {
				MetaData.DescribeAColumn(T, "Movimento", "Movimento padre con disp. insufficiente", nPos++);
				MetaData.DescribeAColumn(T, "bilancio", "Bilancio", nPos++);
				MetaData.DescribeAColumn(T, "upb", "UPB", nPos++);
				MetaData.DescribeAColumn(T, "registry", "Anagrafica", nPos++);
				MetaData.DescribeAColumn(T, "curramount", "Importo Corrente", nPos++);
				MetaData.DescribeAColumn(T, "amount", "Versamenti posticipati", nPos++);
				MetaData.DescribeAColumn(T, "available", "Importo Disponibile attuale", nPos++);
				MetaData.DescribeAColumn(T, "new_available", "Nuovo Disponibile dopo Versamenti posticipati", nPos++);
			}
		}

		Dictionary<string, List<DataRow>> SpeseElaborate = new Dictionary<string, List<DataRow>>();
		Dictionary<string, List<DataRow>> EntrateElaborate = new Dictionary<string, List<DataRow>>();

		private bool GetElencoVociCSA() {
			DataSet DataSource = new DataSet();

			dgrImportazioni.DataSource = null;
			dgrEntiVersamento.DataSource = null;
			string filter = QHS.AppAnd(QHS.CmpEq("yimport", getIntSys("esercizio")),
				QHS.CmpEq("ayear", getIntSys("esercizio")));

			DataTable VersamentiGeneratiSpese = Meta.Conn.RUN_SELECT("csa_importver_partition_expenseview",
				" distinct idcsa_import, yimport,  idver, movkind, idcsa_agency, idreg_agency ", null,
				QHS.AppAnd(filter, QHS.CmpEq("movkind", 4)), null, false);
			DataTable VersamentiGeneratiEntrate = Meta.Conn.RUN_SELECT("csa_importver_partition_incomeview",
				" distinct idcsa_import, yimport,  idver, movkind, idcsa_agency, idreg_agency ", null,
				QHS.AppAnd(filter, QHS.FieldInList("movkind", QHS.List(9, 10))), null, false);

			if (VersamentiGeneratiSpese.Rows.Count > 0) {
				foreach (DataRow rVer in VersamentiGeneratiSpese.Rows) {
					string key = getHash(rVer, null);
					if ((SpeseElaborate != null) && (SpeseElaborate.ContainsKey(key))) continue;
					SpeseElaborate[key] = new List<DataRow>();
					SpeseElaborate[key].Add(rVer);
				}
			}

			if (VersamentiGeneratiEntrate.Rows.Count > 0) {
				foreach (DataRow rVer in VersamentiGeneratiEntrate.Rows) {
					string key = getHash(rVer, null);
					if ((EntrateElaborate != null) && (EntrateElaborate.ContainsKey(key))) continue;
					EntrateElaborate[key] = new List<DataRow>();
					EntrateElaborate[key].Add(rVer);
				}
			}

			//Enti  
			//DataTable Enti = Meta.Conn.RUN_SELECT("csa_agencyview", "*", null,QHS.NullOrEq("annualpayment","S"), null, false);
			string filterImp = QHS.CmpEq("VE.yimport", getIntSys("esercizio"));


			string sqlCmdEnti = " SELECT DISTINCT  " +
			                    " csa_agency.idreg as 'idreg_agency', VE.registry_agency, " +
								" CASE	WHEN (ISNULL(csa_agency.flag,0) & 1 <> 0) THEN 'S' ELSE 'N' END as annualpayment, " +
								" CASE  WHEN (ISNULL(csa_agency.flag,0) & 2 <> 0) THEN 'S' ELSE 'N' END AS nobill " +
								" FROM csa_agency " +
			                    " JOIN csa_importverview VE ON csa_agency.idcsa_agency = VE.idcsa_agency " +
			                    " WHERE " + /*(ISNULL(csa_agency.flag, 0) & 1 <> 0) AND " +*/
			                    " EXISTS(SELECT * FROM csa_importver_partition  P where P.idcsa_import = VE.idcsa_import  AND P.idver = VE.idver) " +
			                    " AND NOT EXISTS(SELECT * FROM csa_importver_partition_expense V where V.idcsa_import = VE.idcsa_import " +
			                    " AND V.idver = VE.idver AND V.movkind = 4  and VE.importo > 0 ) " +
			                    " AND NOT EXISTS(SELECT * FROM csa_importver_partition_income V where V.idcsa_import = VE.idcsa_import " +
			                    " AND V.idver = VE.idver AND V.movkind in (9, 10) and VE.importo < 0 ) " +
			                    " AND VE.kind IN ('Contributo','Ritenuta') " +
			                    " AND " + filterImp +
			                    " ORDER BY VE.registry_agency ";

			DataTable Enti = Conn.SQLRunner(sqlCmdEnti);

			if (Enti != null) {
				Enti.TableName = "Enti";
				ImpostaCaption(Enti);
				DataSource.Tables.Add(Enti);
				FormatDataGrid(dgrEntiVersamento, Enti);
				HelpForm.SetDataGrid(dgrEntiVersamento, Enti);
				HelpForm.SetAllowMultiSelection(Enti, true);
			}

			string sqlCmdImportazioni = " SELECT DISTINCT  " +
			                            " VE.idcsa_import, I.yimport,I.nimport, I.description, I.adate " +
			                            " FROM csa_importverview VE JOIN csa_import I ON  I.idcsa_import = VE.idcsa_import" +
			                            " WHERE " + /*(ISNULL(csa_agency.flag, 0) & 1 <> 0) AND " +*/
			                            " EXISTS(SELECT * FROM csa_importver_partition  P where P.idcsa_import = VE.idcsa_import  AND P.idver = VE.idver) " +
			                            " AND NOT EXISTS(SELECT * FROM csa_importver_partition_expense V where V.idcsa_import = VE.idcsa_import " +
			                            " AND V.idver = VE.idver   AND V.movkind = 4  and VE.importo > 0 ) " +
			                            " AND NOT EXISTS(SELECT * FROM csa_importver_partition_income V where V.idcsa_import = VE.idcsa_import " +
			                            " AND V.idver = VE.idver   AND V.movkind in (9, 10) and VE.importo < 0 ) " +
			                            " AND VE.kind IN ('Contributo','Ritenuta') " +
			                            " AND " + filterImp +
			                            " ORDER BY I.nimport ";

			DataTable Importazioni = Conn.SQLRunner(sqlCmdImportazioni);

			if (Importazioni != null) {
				Importazioni.TableName = "Importazioni";
				ImpostaCaption(Importazioni);
				DataSource.Tables.Add(Importazioni);
				FormatDataGrid(dgrImportazioni, Importazioni);
				HelpForm.SetDataGrid(dgrImportazioni, Importazioni);
				HelpForm.SetAllowMultiSelection(Importazioni, true);
			}

			if (Importazioni.Rows.Count > 0) {
				for (int i = 0; i < Importazioni.Rows.Count; i++) {
					dgrImportazioni.Select(i); // seleziona tutto
				}
			}

			if (Enti.Rows.Count > 0) {
				for (int i = 0; i < Enti.Rows.Count; i++) {
					dgrEntiVersamento.Select(i); // seleziona tutto
				}
			}

			Meta.FreshForm();
			return true;
		}

		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s == 0) return 99;
			return s;
		}


		static DataTable callSp(DataAccess Conn, List<int> idcsaimport_List, List<int> idreg_List) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista_idcsa_import AS int_list;");
			int currblockLen = 0;
			foreach (int id in idcsaimport_List) {
				if (currblockLen == 0) {
					sb.Append($"insert into @lista_idcsa_import values ({id})");
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
			
			sb.AppendLine("");
			sb.AppendLine("DECLARE @lista_idreg AS int_list;");
			int currblockLen1 = 0;


			foreach (int id in idreg_List) {
				if (currblockLen1 == 0) {
					sb.Append($"insert into @lista_idreg values ({id})");
				}
				else {
					sb.Append($",({id})");
				}

				currblockLen1++;
				if (currblockLen1 == 20) {
					sb.AppendLine(";");
					currblockLen1 = 0;
				}
			}

			if (currblockLen1 > 0) {
				sb.AppendLine(";");
			}
			/*
			 * CREATE  PROCEDURE [compute_csa_versamenti_partition]
				(
					@ayear int,
					@idcsa_import int,
					@lista_idcsa_import dbo.int_list  READONLY, -- @idcsa_import int,
					@lista_idreg_agency dbo.int_list  READONLY   --@idcsa_agency int
				)
			 * */
			sb.AppendLine(
				$"exec  compute_csa_versamenti_partition {Conn.GetEsercizio()},null,@lista_idcsa_import, @lista_idreg");
			QueryCreator.MarkEvent(sb.ToString());
			return Conn.SQLRunner(sb.ToString());
		}

		/// <summary>
		/// Legge "Non associare a sospeso in Elaborazione Versamenti"
		/// </summary>
		/// <returns></returns>
		private bool LeggiFlagEsenteBancaPredefinita() {
			DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null,
				QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
			if (tTreasurer.Rows.Count == 0) return false;
			return true;
		}

		Dictionary<int, string> __regTitles = new Dictionary<int, string>();

		string GetTitleForIdReg(object idreg) {
			if (idreg == DBNull.Value)
				return "";
			int n = Convert.ToInt32(idreg);
			if (__regTitles.ContainsKey(n))
				return __regTitles[n];
			object title = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "title");
			if (title == null) {
				title = "[anagrafica di codice " + idreg + "]";
			}

			__regTitles[n] = title.ToString();
			return title.ToString();
		}

		string getIdList(DataRow[] rr, string field, int threeshold) {
			Dictionary<int, bool> sl = new Dictionary<int, bool>();
			foreach (DataRow r in rr) {
				if (r.RowState == DataRowState.Deleted) continue;
				int n = CfgFn.GetNoNullInt32(r[field]);
				if (n == 0 || n >= threeshold) continue;
				if (sl.ContainsKey(n)) continue;
				sl.Add(n, true);
			}

			string res = "";
			foreach (int k in sl.Keys) {
				if (res.Length > 0) res += ",";
				res += k.ToString();
			}

			return res;
		}

		private bool doSave() {
			int faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, dsFinancial,
				faseMax, faseMax, "expense", true);
			ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
			ga.GeneraClassificazioniIndirette(ga.DSP, true);


			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) {
				MessageBox.Show(this,
					"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				return false;
			}
			else {
				if (azzeraClassificazioniAutomatiche(ga.DSP, "I") && azzeraClassificazioniAutomatiche(ga.DSP, "E")) {
					res = ga.doPost(Meta.Dispatcher);
					if (res) {
						MessageBox.Show(this, "Salvataggio dei movimenti finanziari avvenuto con successo");
						return true;
					}
					else {
						MessageBox.Show(this,
							"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
						return false;
					}
				}
				else return false;
			}

		}

		private bool azzeraClassificazioniAutomatiche(DataSet DSP, string IoE) {
			bool azzera = chkAzzeraUltimaFase.Checked;
			if (!azzera) return true;
			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			Dictionary<int, List<DataRow>> classDict = (IoE == "I") ? ClassEntrateLast : ClassSpeseLast;
			if (classDict == null) return false;
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			foreach (DataRow SortedMovRow in DSP.Tables[tMainSorted].Select()) {
				int key = CfgFn.GetNoNullInt32(SortedMovRow[idMovField]);
				if (!classDict.ContainsKey(key)) continue;
				decimal amount = CfgFn.GetNoNullDecimal(SortedMovRow["amount"]);
				if ((amount) > 0) {
					SortedMovRow["amount"] = 0;
					SortedMovRow["originalamount"] = amount;
				}
			}

			//dsFinancial.Tables[tMainSorted].AcceptChanges();
			return true;
		}

		/// <summary>
		/// Riempie i campi della riga E_S, in base alla riga di automatismo Auto
		/// </summary>
		/// <param name="E_S">riga da riempire</param>
		/// <param name="Auto">riga di automatismo</param>
		private void FillMovimento(DataRow E_S, DataRow Auto) {
			//, string idmovimento)
			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"] = esercizio;
			E_S["adate"] = DataCont;

			string[] fields_to_copy = new string[] {"idman", "idreg", "description"};
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (E_S.Table.Columns.Contains(field)) E_S[field] = Auto[field];
			}

			E_S.EndEdit();
		}

		private void FillImportMov(bool azzera, DataRow ImportMovRow, DataRow Auto, object idcsa_import) {
			ImportMovRow["idcsa_import"] = idcsa_import;
			ImportMovRow["movkind"] = Auto["movkind"];
			ImportMovRow["cu"] = "import";
			ImportMovRow["ct"] = DateTime.Now;
			ImportMovRow["lu"] = "import";
			ImportMovRow["lt"] = DateTime.Now;
			if (ImportMovRow.Table.Columns.Contains("idriep")) {
				ImportMovRow["idriep"] = Auto["idriep"];
			}

			if (ImportMovRow.Table.Columns.Contains("ndetail")) {
				ImportMovRow["ndetail"] = Auto["ndetail"];
			}

			if (ImportMovRow.Table.Columns.Contains("idver")) {
				ImportMovRow["idver"] = Auto["idver"];
			}

			if (ImportMovRow.Table.Columns.Contains("amount")) {
				if (azzera)
					ImportMovRow["amount"] = 0;
				else
					ImportMovRow["amount"] = Auto["amount"];
			}

			if (ImportMovRow.Table.Columns.Contains("originalamount")) {
				if (azzera)
					ImportMovRow["originalamount"] = Auto["amount"];
				else
					ImportMovRow["originalamount"] = 0;
			}
		}

		Dictionary<string, DataRow> __myModPagam = new Dictionary<string, DataRow>();

		private DataRow GetModalitaPagamento(object idreg_agency, object idcsa_agency, object idcsa_agencypaymethod) {
			if ((idreg_agency == null) || (idreg_agency == DBNull.Value)) return null;
			string key = idreg_agency.ToString() + "-" + idcsa_agency.ToString() + "-" + idcsa_agencypaymethod;
			if (__myModPagam.ContainsKey(key))
				return __myModPagam[key];

			string filtro = QHS.AppAnd(QHS.CmpEq("idcsa_agency", idcsa_agency),
				QHS.CmpEq("idcsa_agencypaymethod", idcsa_agencypaymethod));
			DataTable AgencyPagam = Conn.RUN_SELECT("csa_agencypaymethod", "*", null, filtro, null, true);
			if (AgencyPagam.Rows.Count == 0) {
				// cerco la modalità di pagamento di defualt 
				__myModPagam[key] = CfgFn.ModalitaPagamentoDefault(Conn, idreg_agency);
				return __myModPagam[key];
			}

			DataRow DefRow = AgencyPagam.Rows[0];
			object idregistrypaymethod = DefRow["idregistrypaymethod"];

			string filtermodpag = QHS.AppAnd(QHS.CmpEq("idreg", idreg_agency),
				QHS.CmpEq("idregistrypaymethod", idregistrypaymethod));
			DataTable ModPagam = Conn.RUN_SELECT("registrypaymethod", "*", null, filtermodpag, null, true);


			if (ModPagam.Rows.Count == 0) {
				// cerco la modalità di pagamento di defualt 
				__myModPagam[key] = CfgFn.ModalitaPagamentoDefault(Conn, idreg_agency);
				return __myModPagam[key];
			}

			else {
				__myModPagam[key] = ModPagam.Rows[0];
				return ModPagam.Rows[0];
			}
		}

		Dictionary<int, int> __kind_of_sorting = new Dictionary<int, int>();
		Dictionary<int, int> __e_phase_sorkind = new Dictionary<int, int>();
		Dictionary<int, int> __i_phase_sorkind = new Dictionary<int, int>();

		int DetectFaseSortingParent(string IoE) {
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			string phasefieldname = (IoE == "I") ? "nphaseincome" : "nphaseexpense";
			//Prende la prima riga che trova classificata come parent della siope
			DataRow[] RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.IsNotNull("parentidsor"), QHC.CmpEq("kind", kind)));
			if (RUnGrouped == null || RUnGrouped.Length == 0) {
				return -1;
			}

			object idsor = RUnGrouped[0]["parentidsor"];
			int nidsor = Convert.ToInt32(idsor);
			int idsorkind = 0;
			if (__kind_of_sorting.ContainsKey(nidsor)) {
				idsorkind = __kind_of_sorting[nidsor];
			}
			else {
				idsorkind = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", idsor), "idsorkind"));
				__kind_of_sorting[nidsor] = idsorkind;
			}

			Dictionary<int, int> myphasedict = (IoE == "I") ? __i_phase_sorkind : __e_phase_sorkind;
			if (myphasedict.ContainsKey(idsorkind)) {
				return myphasedict[idsorkind];
			}

			object nphase = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind), phasefieldname);
			//MessageBox.Show("IoE="+IoE+" idsor="+idsor.ToString()+" idsorkind="+idsorkind.ToString()+ 
			//                " Fase ="+nphase+ " + kind +  = " + kind+" phasefieldname="+phasefieldname);

			if (nphase == null || nphase == DBNull.Value) {
				myphasedict[idsorkind] = -1;
			}
			else {
				myphasedict[idsorkind] = CfgFn.GetNoNullInt32(nphase);
			}

			return myphasedict[idsorkind];
		}

		private void FillMovSortedFaseParent(int index, string IoE, DataRow NewMovRow) {
			FillMovSorted(false, false, index, IoE, NewMovRow, "parentidsor");
		}

		private void FillMovSortedFaseMAX(bool azzera, int index, string IoE, DataRow NewMovRow) {
			FillMovSorted(azzera, true, index, IoE, NewMovRow, "idsor");
		}

		private void FillMovSorted(bool azzera, bool lastphase, int index, string IoE, DataRow NewMovRow,
			string field_for_idsor) {
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			Dictionary<int, List<DataRow>> classDict = (IoE == "I") ? ClassEntrateLast : ClassSpeseLast;
			DataRow[] RUnGrouped;
			//nriga è sempre l'indice della riga stessa
			RUnGrouped = new DataRow[] {SP_Result.Rows[index]}; //penso che potesse andare bene anche con la vecchia
			if (RUnGrouped.Length == 0) return;
			MetaData MetaSortedMov = Meta.Dispatcher.Get(tMainSorted);
			MetaSortedMov.SetDefaults(dsFinancial.Tables[tMainSorted]);
			int esercizio = getIntSys("esercizio");
			int key = CfgFn.GetNoNullInt32(NewMovRow[idMovField]);

			foreach (DataRow R in RUnGrouped) {
				if (lastphase) {
					if ((classDict != null) && (!classDict.ContainsKey(key))) classDict[key] = new List<DataRow>();
				}

				if (R[field_for_idsor] == DBNull.Value) continue;

				dsFinancial.Tables[tMainSorted].Columns["idsor"].DefaultValue = R[field_for_idsor];
				DataRow SortedMovRow = MetaSortedMov.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainSorted]);
				SortedMovRow["idsor"] = R[field_for_idsor];
				if (!azzera) {
					SortedMovRow["amount"] = R["amount"];
					SortedMovRow["originalamount"] = 0;
				}
				else {
					SortedMovRow["amount"] = 0;
					SortedMovRow["originalamount"] = R["amount"];
				}

				SortedMovRow[idMovField] = NewMovRow[idMovField];
				SortedMovRow["ayear"] = esercizio;
				SortedMovRow["cu"] = "import";
				SortedMovRow["ct"] = DateTime.Now;
				SortedMovRow["lu"] = "import";
				SortedMovRow["lt"] = DateTime.Now;
				if (lastphase) {
					classDict[key].Add(SortedMovRow);
				}
			}
		}

		/// <summary>
		/// Aggiunge i finanziamenti alla riga NewMovRow, corrispondente alla riga  raggruppata di spesa (di fase 1) di indice index
		///     questa parte NON viene utilizzata quando al movimento è associato un impegno, visto che in quel caso la fase 1 
		///     non è da generare. Aggiunge un finanziamento (eventualmente accorpandoli) per ogni riga non raggruppata  associata al
		///     movimento in fase di generazione
		/// </summary>
		/// <param name="index">indice della riga di spesa raggruppata</param>
		/// <param name="NewMovRow">riga di spesa in fase di creazione</param>
		private void FillUnderwritingAppropriation(int index, DataRow NewMovRow) {
			string tUnderwritingAppropriation = "underwritingappropriation";
			string kind = "Spesa";

			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame
			DataRow[] RUnGrouped; //= OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind)));
			if (!nuovaGestione()) {
				RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind)));
			}
			else {
				//nriga è sempre l'indice della riga stessa
				RUnGrouped = new DataRow[] {SP_Result.Rows[index]}; //penso che potesse andare bene anche con la vecchia
			}

			if (RUnGrouped.Length == 0) return;

			MetaData MetaUnderwritingAppropriation = Meta.Dispatcher.Get(tUnderwritingAppropriation);
			MetaUnderwritingAppropriation.SetDefaults(dsFinancial.Tables[tUnderwritingAppropriation]);

			foreach (DataRow R in RUnGrouped) {
				if (R["idunderwriting"] == DBNull.Value) continue;
				// Verifica l'esistenza di un'altra riga avente lo stesso idunderwriting e idexp
				string filter = QHC.AppAnd(QHC.CmpEq("idunderwriting", R["idunderwriting"]),
					QHC.CmpEq("idexp", NewMovRow["idexp"]));
				DataRow[] UnderwritingAppropriation = dsFinancial.Tables[tUnderwritingAppropriation].Select(filter);
				if (UnderwritingAppropriation.Length > 0)
					UnderwritingAppropriation[0]["amount"] =
						CfgFn.GetNoNullDecimal(UnderwritingAppropriation[0]["amount"]) +
						CfgFn.GetNoNullDecimal(R["amount"]);
				else {
					DataRow UnderwritingAppropritionRow = MetaUnderwritingAppropriation.Get_New_Row(NewMovRow,
						dsFinancial.Tables[tUnderwritingAppropriation]);
					UnderwritingAppropritionRow["idunderwriting"] = R["idunderwriting"];
					UnderwritingAppropritionRow["amount"] = R["amount"];
					UnderwritingAppropritionRow["idexp"] = NewMovRow["idexp"];
					UnderwritingAppropritionRow["cu"] = "import";
					UnderwritingAppropritionRow["ct"] = DateTime.Now;
					UnderwritingAppropritionRow["lu"] = "import";
					UnderwritingAppropritionRow["lt"] = DateTime.Now;
				}
			}


		}

		private void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
			string[] fields_to_copy = new string[] {
				"idfin", "idupb", "codefin"
			};
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (ImpMov.Table.Columns[field] == null) continue;
				ImpMov[field] = Auto[field];
			}

			ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
		}

		/// <summary>
		/// Aggiunge i finanziamenti alla riga NewMovRow, corrispondente alla riga  raggruppata di spesa (di fase max) di indice index
		/// Aggiunge un finanziamento (eventualmente accorpandoli) per ogni riga non raggruppata associata al movimento in fase di creazione
		/// Se nessuna riga associata a quella corrente ha dei finanzimenti, viene utilizzato il metodo CercaFinanziamento_SolaCassa
		/// </summary>
		/// <param name="index">indice della riga di spesa raggruppata</param>
		/// <param name="NewMovRow">riga di spesa in fase di creazione</param>
		private void FillUnderwritingPayment(int index, DataRow NewMovRow) {
			string tUnderwritingPayment = "underwritingpayment";
			string kind = "Spesa";
			DataRow SP_R = SP_Result.Rows[index];
			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame
			DataRow[] RUnGrouped = OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", kind),
				QHC.IsNotNull("idunderwriting")));

			if (RUnGrouped.Length == 0) {
				CercaFinanziamento_SolaCassa(SP_R["idfin"], SP_R["idupb"], CfgFn.GetNoNullDecimal(SP_R["amount"]),
					NewMovRow);
				return;
			}

			MetaData MetaUnderwritingPayment = Meta.Dispatcher.Get(tUnderwritingPayment);
			MetaUnderwritingPayment.SetDefaults(dsFinancial.Tables[tUnderwritingPayment]);

			foreach (DataRow R in RUnGrouped) {
				if (R["idunderwriting"] == DBNull.Value) continue;
				// Verifica l'esistenza di un'altra riga avente lo stesso idunderwriting e idexp
				string filter = QHC.AppAnd(QHC.CmpEq("idunderwriting", R["idunderwriting"]),
					QHC.CmpEq("idexp", NewMovRow["idexp"]));
				DataRow[] UnderwritingPayment = dsFinancial.Tables[tUnderwritingPayment].Select(filter);
				if (UnderwritingPayment.Length > 0)
					UnderwritingPayment[0]["amount"] = CfgFn.GetNoNullDecimal(UnderwritingPayment[0]["amount"]) +
					                                   CfgFn.GetNoNullDecimal(R["amount"]);
				else {
					DataRow UnderwritingPaymentRow = MetaUnderwritingPayment.Get_New_Row(NewMovRow,
						dsFinancial.Tables[tUnderwritingPayment]);
					UnderwritingPaymentRow["idunderwriting"] = R["idunderwriting"];
					UnderwritingPaymentRow["amount"] = R["amount"];
					UnderwritingPaymentRow["idexp"] = NewMovRow["idexp"];
					UnderwritingPaymentRow["cu"] = "import";
					UnderwritingPaymentRow["ct"] = DateTime.Now;
					UnderwritingPaymentRow["lu"] = "import";
					UnderwritingPaymentRow["lt"] = DateTime.Now;
				}
			}
		}




		/// <summary>
		/// Aggiunge le righe collegate di bilancio, upb e creditore ai fini del salvataggio
		/// </summary>
		/// <param name="SP_Row"></param>
		private void AddVociCollegate(DataRow SP_Row) {
			AddVoceBilancio(SP_Row["idfin"], SP_Row["codefin"].ToString());
			AddVoceUpb(SP_Row["idupb"], SP_Row["codeupb"].ToString());
			AddVoceCreditore(SP_Row["idreg"], SP_Row["registry"].ToString());
		}

		Hashtable hashFin = new Hashtable();
		Hashtable hashUpb = new Hashtable();
		Hashtable hashReg = new Hashtable();

		private void AddVoceBilancio(object ID, string codbil) {
			if (ID == DBNull.Value) return;
			if (hashFin.ContainsKey(ID.ToString())) return;
			//if (dsFinancial.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
			DataRow NewBil = dsFinancial.fin.NewRow();
			NewBil["idfin"] = ID;
			NewBil["codefin"] = codbil;
			dsFinancial.fin.Rows.Add(NewBil);
			NewBil.AcceptChanges();
			hashFin[ID.ToString()] = NewBil;
		}

		private void AddVoceUpb(object ID, string codupb) {
			if (ID == DBNull.Value) return;
			if (hashUpb.ContainsKey(ID.ToString())) return;
			//if (dsFinancial.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;

			DataRow NewUpb = dsFinancial.upb.NewRow();
			NewUpb["idupb"] = ID;
			NewUpb["codeupb"] = codupb;
			dsFinancial.upb.Rows.Add(NewUpb);
			NewUpb.AcceptChanges();
			hashUpb[ID.ToString()] = NewUpb;
		}

		private void AddVoceCreditore(object codice, string denominazione) {
			if (codice == DBNull.Value) return;
			if (hashReg.ContainsKey(codice.ToString())) return;
			//if (dsFinancial.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;

			DataRow NewCred = dsFinancial.registry.NewRow();
			NewCred["idreg"] = codice;
			NewCred["title"] = denominazione;
			dsFinancial.registry.Rows.Add(NewCred);
			NewCred.AcceptChanges();
			hashReg[codice.ToString()] = NewCred;
		}

		void clearHashTabelleCollegate() {
			hashFin.Clear();
			dsFinancial.fin.Clear();

			hashReg.Clear();
			dsFinancial.registry.Clear();

			hashUpb.Clear();
			dsFinancial.upb.Clear();
		}

		bool nuovaGestione() {
			return true;
		}

		object __myidchargehandliing_CSA = null;

		private object Get_idchargehandling_CSA() {
			// flag di gestione del tipo trattamento spese CSA, obbligatorio per circolare ABI 36
			//if (Meta.IsEmpty) return DBNull.Value;
			if (__myidchargehandliing_CSA != null)
				return __myidchargehandliing_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myidchargehandliing_CSA = rConfig["csa_idchargehandling"];
			return rConfig["csa_idchargehandling"];
		}

		object __myFlagEsenteSpese_CSA = null;

		private object Get_FlagEsenteSpese_CSA() {
			// flag di gestione dell'esenzione da spese, per chi non usa Circ. ABI 26, come Unicredit
			//if (Meta.IsEmpty) return DBNull.Value;
			if (__myFlagEsenteSpese_CSA != null)
				return __myFlagEsenteSpese_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myFlagEsenteSpese_CSA = rConfig["csa_flag"];
			return rConfig["csa_flag"];
		}

		object _myreg_CSA = null;

		/// <summary>
		/// Ottiene l'anagrafica per le importazioni csa  da config
		/// </summary>
		/// <returns></returns>


		object _myFlagLinkToExp = null;

		/// <summary>
		/// Verifica se bisogna collegare le reversali delle ritenute ai movimenti di spesa dei lordi
		/// </summary>
		/// <returns></returns>
		private object Get_FlagLinkToExp() {
			if (_myFlagLinkToExp != null)
				return _myFlagLinkToExp;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			if (rConfig["csa_flaglinktoexp"] == DBNull.Value)
				_myFlagLinkToExp = "N";
			else
				_myFlagLinkToExp = rConfig["csa_flaglinktoexp"];
			return _myFlagLinkToExp;
		}

		/// <summary>
		/// Ricerca i finanziamenti disponibili per la coppia bilancio/upb considerata nei casi in cui non ci siano finanziamenti 
		///  in fase di impegno.
		/// La ricerca riguarda quindi solo la previsione e non i finanziamenti. Le previsioni sono prese in ordine crescente 
		///  di disponibilità.
		/// </summary>
		/// <param name="idfin">IDfin per la riga da considerare</param>
		/// <param name="idupb">IDupb per la riga da considerare</param>
		/// <param name="Curr">Riga di spesa in fase di generazione</param>
		void CercaFinanziamento_SolaCassa(object idfin, object idupb, decimal amount, DataRow Curr) {
			// Curr nuovo movimento di spesa in fase di creazione
			string fieldtouse = "paymentprevavailable"; // = disp. a pagare

			//object idfin = Curr["idfin"];
			//object idupb = Curr["idupb"];

			//Legge l'elenco di tutti i finanziamenti aventi previsione disponibile per il pagamento
			//  per la voce upb/bilancio del movimento di spesa, in ordine crescente di disponibilità
			DataTable F = Conn.RUN_SELECT("upbunderwritingyearview", "*", fieldtouse + " asc",
				QHS.AppAnd(QHS.CmpEq("idfin", idfin), QHS.CmpEq("idupb", idupb), QHS.CmpGt(fieldtouse, 0)), null,
				false);

			if (F == null || F.Rows.Count == 0) {
				//MessageBox.Show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
				//    "Informazione");
				return;
			}

			MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

			decimal to_cover = amount; //prende l'importo corrente dell movimento di spesa

			foreach (DataRow Rf in F.Rows) {
				object idunderwriting_found = Rf["idunderwriting"];
				string filterunderwriting = QHC.AppAnd(
					QHC.CmpEq("idexp", Curr["idexp"]),
					QHC.CmpEq("idunderwriting", idunderwriting_found)
				);
				DataRow newrow = null;
				decimal available = CfgFn.GetNoNullDecimal(Rf[fieldtouse]);

				if (dsFinancial.Tables["underwritingpayment"].Select(filterunderwriting).Length == 0) {
					//in available la disponibilità a pagare                    
					MetaUA.SetDefaults(dsFinancial.Tables["underwritingpayment"]);
					DataRow toadd = MetaUA.Get_New_Row(Curr, dsFinancial.Tables["underwritingpayment"]);
					toadd["idunderwriting"] = idunderwriting_found;

					newrow = toadd;
				}
				else {
					newrow = dsFinancial.Tables["underwritingpayment"].Select(filterunderwriting)[0];
				}

				if (to_cover <= available) {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + to_cover;
					to_cover = 0;
				}
				else {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + available;
					to_cover -= available;
				}

				if (to_cover == 0) break;
			}

		}

		/// <summary>
		/// Calcola i finanziamenti sull'impegno associati ad un movimento di spesa il cui padre ha chiave parentidexp
		///  le colonne sono idunderwriting e topay (parte del credito assegnata e non pagata)
		/// </summary>
		/// <param name="parentidexp"></param>
		/// <returns>Finanziamenti associati in fase impegno ad un movimento generico di fase successiva</returns>

		string __myflagcredit = null;

		/// <summary>
		/// Verifica se l'utente gestisce le assegnazioni dei crediti
		/// </summary>
		/// <returns></returns>
		bool UsaCrediti() {
			if (__myflagcredit != null) {
				return __myflagcredit == "S";
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myflagcredit = rConfig["flagcredit"].ToString().ToUpper();
			if (__myflagcredit == "S")
				return true;
			return false;
		}


		string __myflagproceeds = null;

		/// <summary>
		/// Verifica se l'utente gestisce le assegnazioni di cassa
		/// </summary>
		/// <returns></returns>
		bool UsaCassa() {
			if (__myflagproceeds != null) {
				return __myflagproceeds == "S";
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myflagproceeds = rConfig["flagproceeds"].ToString().ToUpper();
			if (__myflagproceeds == "S")
				return true;
			return false;
		}

		int __myfin_kind = -1;

		/// <summary>
		/// Verifica se l'utente gestisce la previsione di competenza
		/// </summary>
		/// <returns></returns>
		bool UsaPrevCompetenza() {
			if (__myfin_kind != -1) {
				return (__myfin_kind == 1 || __myfin_kind == 3);
			}

			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return false;
			if (t.Rows.Count == 0) return false;
			DataRow rConfig = t.Rows[0];
			__myfin_kind = CfgFn.GetNoNullInt32(rConfig["fin_kind"]);
			if (__myfin_kind == 1 || __myfin_kind == 3) return true;
			return false;
		}

		/// <summary>
		/// Verifica se l'utente gestisce la previsione di cassa
		/// </summary>
		/// <returns></returns>

		Dictionary<int, int> __getImpegnoofIdExp = new Dictionary<int, int>();

		/// <summary>
		/// Ottiene  la chiave dell'impegno a partire dalla chiave di un movimento di spesa di un livello generico
		/// </summary>
		/// <param name="parentidexp">chiave di un movimento di spesa salvato</param>
		/// <returns>chiave dell'antenato del movimento dato, avente fase pari a quella del bilancio (la prima in genere)</returns>
		object GetIDImpegno(object parentidexp) {
			int parid = CfgFn.GetNoNullInt32(parentidexp);
			if (__getImpegnoofIdExp.ContainsKey(parid)) return __getImpegnoofIdExp[parid];
			int faseBilancio = getIntSys("expensefinphase");
			object idlivbil = Conn.DO_READ_VALUE("expenselink",
				QHS.AppAnd(QHS.CmpEq("idchild", parid), QHS.CmpEq("nlevel", faseBilancio)),
				"idparent");
			__getImpegnoofIdExp[parid] = CfgFn.GetNoNullInt32(idlivbil);
			return idlivbil;
		}
		/*
		 * topay = finanziamenti impegnato e non pagati
		 *          Ossia quanto è stato finanziato in fase di impegno ma non ancora portato in pagamento
		 * paymentprevavailable = prev. di cassa disponibile
		 *          Ossia quanto hai previsto di PAGARE e non hai ancora PAGATO
		 * proceedsavailable  = CASSA disponibile
		 *          Ossia quanto hai assegnato in cassa e non ancora utilizzato nei PAGAMENTI
		 */

		/// <summary>
		/// Inserisce i finanziamenti sul pagamento cercando di fare il meglio che può. In particolare:
		///  - 1 se l'utente non usa crediti o competenza associa i finanziamenti sulla semplice disponibilità che trova a finanziare
		///  - 2 se ci sono righe non raggruppate associate con dei finanziamenti espliciti, usa quelli 
		///  - 3 se l'impegno non è associato a dei finanziamenti o questi non hanno disponibilità, vale il caso 1
		///  - Altrimenti usa i finanziamenti dell'impegno con disponibilità, considerando in particolarei finanziamenti associati in fase 
		///     di impegno e non associati a pagamenti, prendendoli in ordine di:
		///      * previsione disponibile a pagare  se uno non usa le assegazioni di cassa
		///      * assegnazioni disponibili di cassa se uno usa le assegnazioni di cassa 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="R">Riga di automatismo raggruppata</param>
		/// <param name="Curr">Riga di spesa in fase di generazione</param>
		void CercaFinanziamentoCassa(int index, DataRow Curr) {

			DataRow R = SP_Result.Rows[index];
			//Se non usa i crediti e nemmeno la competenza, la disponibilità a pagare non può essere ricercata considerando l'impegno
			//  sarà dunque effettuata sulla semplice base della coppia upb/bilancio in uscita (considerando tutti i finanziamenti presenti)
			// Questa parte quindi prescinde dal fatto che uno abbia o meno selezionato un impegno
			if (!(UsaCrediti() || UsaPrevCompetenza())) {
				FillUnderwritingPayment(index, Curr);
				return;
			}

			//Ottiene tutte le righe NON raggruppate che puntano alla riga in esame e che hanno associato un finanziamento
			DataRow[] RUnGroupedWithUnderwriting =
				OutTable.Select(QHC.AppAnd(QHC.CmpEq("nriga", index), QHC.CmpEq("kind", "Spesa"),
					QHC.IsNotNull("idunderwriting")));

			//Se ci sono delle righe sono associate a finanziamenti, allora non deve prendere i dati dagli impegni ma dalle righe 
			// non raggruppate direttamente
			if (RUnGroupedWithUnderwriting.Length > 0) {
				FillUnderwritingPayment(index, Curr);
				return;
			}

			object parentidexp = R["parentidexp"];

			//Se usa i crediti o la competenza ->  si presume ci siano uno più finanziamenti associati all'impegno .
			//La disponibilità sarà considerata nell'ambito del pagato relativo a tali finanziamenti e non esclusivamente 
			// sulla coppia bilancio/upb in uscita

			string fieldtouse = "paymentsavailable";
			// = disp. a pagare =  previsione di cassa in uscita - pagamenti effettuati
			if (UsaCassa()) {
				fieldtouse = "proceedsavailable"; //incassi disponibili (cassa assegnata e non utilizzata nei pagamenti)
			}

			//Prende prima le righe aventi disponibilità nei sensi di fieldtouse e POI quelle che non ce l'hanno
			DataTable F = Conn.RUN_SELECT("expensecreditproceedsview", "*", fieldtouse + " asc",
				QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno(parentidexp)), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
					QHS.CmpGt(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);
			Conn.RUN_SELECT_INTO_TABLE(F, fieldtouse + " desc",
				QHS.AppAnd(QHS.CmpEq("idexp", GetIDImpegno(parentidexp)), QHS.CmpEq("ayear", Conn.GetSys("esercizio")),
					QHS.CmpLe(fieldtouse, 0), QHS.CmpGt("topay", 0)), null, false);

			if (F == null || F.Rows.Count == 0) {

				//MessageBox.Show(this, "Non ci sono finanziamenti per questa coppia progetto-voce di bilancio",
				//    "Informazione");

				// Se non ci sono finanziamenti associati a questo movimento, fai finta che di non dover collegare alcun movimento
				//  andando a considerare direttamente le previsioni
				CercaFinanziamento_SolaCassa(R["idfin"], R["idupb"], CfgFn.GetNoNullDecimal(R["amount"]), Curr);
				return;
			}


			//Ottiene una tabella con le colonne idunderwriting e topay (disponibile a pagare sul finanziamento dell'impegno)

			MetaData MetaUA = Meta.Dispatcher.Get("underwritingpayment");

			decimal to_cover = CfgFn.GetNoNullDecimal(R["amount"]); //prende l'importo della riga corrente


			foreach (DataRow Rf in F.Rows) {
				decimal available = CfgFn.GetNoNullDecimal(Rf["topay"]);
				if (available == 0) continue;

				object idunderwriting_found = Rf["idunderwriting"];

				DataRow newrow = null;


				string filterpay = QHS.AppAnd(QHS.CmpEq("idexp", Curr["idexp"]),
					QHS.CmpEq("idunderwriting", idunderwriting_found));

				if (dsFinancial.Tables["underwritingpayment"].Select(filterpay).Length == 0) {
					MetaUA.SetDefaults(dsFinancial.Tables["underwritingpayment"]);
					DataRow toadd = MetaUA.Get_New_Row(Curr, dsFinancial.Tables["underwritingpayment"]);
					toadd["idunderwriting"] = idunderwriting_found;
					newrow = toadd;
				}
				else {
					newrow = dsFinancial.Tables["underwritingpayment"].Select(filterpay)[0];
				}

				if (to_cover <= available) {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + to_cover;
					to_cover = 0;
				}
				else {
					newrow["amount"] = CfgFn.GetNoNullDecimal(newrow["amount"]) + available;
					to_cover -= available;
				}

				if (to_cover == 0) break;
			}

		}


		Dictionary<int, Dictionary<int, decimal>> getElencoSospesi(DataTable t) {
			var l = new Dictionary<int, Dictionary<int, decimal>>();
			foreach (DataRow r in t.Rows) {
				//campi nbill, idreg, amount
				int nBill = (int) r["nbill"];
				int idreg = (int) r["idreg"];
				decimal amount = (decimal) r["amount"];
				if (!l.ContainsKey(idreg)) {
					l[idreg] = new Dictionary<int, decimal>();
				}

				var listaSospesi = l[idreg];
				if (!listaSospesi.ContainsKey(nBill)) {
					//MessageBox.Show("listaSospesi " + idreg.ToString() + nBill.ToString());
					listaSospesi[nBill] = 0;
				}

				listaSospesi[nBill] += amount;
			}

			//MessageBox.Show("sospesi " + l.Count.ToString());
			return l;
		}

		Dictionary<int, decimal> getSospesiPerAnagrafica(int idReg, Dictionary<int, Dictionary<int, decimal>> sospesi,
			decimal amountToCover) {
			var l = new Dictionary<int, decimal>();

			if (!sospesi.ContainsKey(idReg)) return l;
			var listaSospesi = sospesi[idReg];
			foreach (var nbill in listaSospesi.Keys.ToArray()) {
				//MessageBox.Show("sospeso " + nbill.ToString() + idReg.ToString());
				decimal residuo = listaSospesi[nbill];
				if (residuo == 0) continue; //superflua ma toglierla appare controintuitivo
				decimal amount = (residuo > amountToCover) ? amountToCover : residuo; //minimo tra i due
				residuo -= amount;
				amountToCover -= amount;
				listaSospesi[nbill] = residuo;
				l[nbill] = amount;
				if (amountToCover == 0) break;
			}

			return l;
		}


		Dictionary<object, bool> _agency_not_use_nbill = new Dictionary<object, bool>();

		bool agency_not_use_nbill(object idcsa_agency) {
			if (_agency_not_use_nbill.ContainsKey(idcsa_agency)) {
				return _agency_not_use_nbill[idcsa_agency];
			}
			else {
				int flag = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("csa_agency",
					QHS.CmpEq("idcsa_agency", idcsa_agency), "(ISNULL(csa_agency.flag, 0)&2)"));
				_agency_not_use_nbill[idcsa_agency] = flag != 0;
				return _agency_not_use_nbill[idcsa_agency];
			}
		}

		DataRow GetGridRow(DataGrid G, int index) {

			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet) G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			string filter = "";
			string nomecampo = "idcsa_import";
			if (G.Name == "dgrEntiVersamento") nomecampo = "idreg_agency";
			filter = QHC.CmpEq(nomecampo, G[index, 0]);
			DataRow[] selectresult = MyTable.Select(filter);
			return (selectresult.Length > 0) ? selectresult[0] : null;
		}



		private DataRow[] GetGridSelectedRows(DataGrid G) {
			if (G.DataMember == null) return null;
			if (G.DataSource == null) return null;
			string TableName = G.DataMember.ToString();
			DataSet MyDS = (DataSet) G.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];
			int numrighetemp = MyTable.Rows.Count;
			int numrighe = 0;
			int i;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					numrighe++;
				}
			}

			DataRow[] Res = new DataRow[numrighe];
			int count = 0;
			for (i = 0; i < numrighetemp; i++) {
				if (G.IsSelected(i)) {
					DataRow R = GetGridRow(G, i);
					if (R == null) continue;
					Res[count++] = R;
				}
			}

			return Res;
		}

		/// <summary>
		/// Genera i movimenti di entrata e di spesa a partire dalle tabelle raggruppate
		/// </summary>
		/// <param name="IoE"></param>
		/// <returns></returns>
		Dictionary<int, List<DataRow>> ClassSpeseLast = new Dictionary<int, List<DataRow>>();

		Dictionary<int, List<DataRow>> ClassEntrateLast = new Dictionary<int, List<DataRow>>();

		private bool generaMovPrincipali(string IoE, bool nonPagareNettiPositivi,
			Dictionary<int, Dictionary<int, decimal>> sospesi, bool lordi) {
			bool azzeraUltimaFase = chkAzzeraUltimaFase.Checked;
			string tMain = (IoE == "I") ? "income" : "expense";
			string tMainYear = (IoE == "I") ? "incomeyear" : "expenseyear";
			string tMainLast = (IoE == "I") ? "incomelast" : "expenselast";
			string tMainBill = (IoE == "I") ? "incomebill" : "expensebill";
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			string tImportMain = (IoE == "I") ? "csa_import_income" : "csa_import_expense";
			string tImportMainVerPlus =
				(IoE == "I") ? "csa_importver_partition_income" : "csa_importver_partition_expense";
			string tImportMainRiepPlus =
				(IoE == "I") ? "csa_importriep_partition_income" : "csa_importriep_partition_expense";
			string tMainVar = (IoE == "I") ? "incomevar" : "expensevar";
			MetaData MetaM = Meta.Dispatcher.Get(tMain);
			MetaM.SetDefaults(dsFinancial.Tables[tMain]);

			MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
			MetaL.SetDefaults(dsFinancial.Tables[tMainLast]);


			MetaData MetaMBill = Meta.Dispatcher.Get(tMainBill);
			MetaMBill.SetDefaults(dsFinancial.Tables[tMainBill]);

			MetaData MetaSorted = Meta.Dispatcher.Get(tMainSorted);
			MetaSorted.SetDefaults(dsFinancial.Tables[tMainSorted]);

			MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
			MetaImputazioneMov.SetDefaults(dsFinancial.Tables[tMainYear]);
			int esercizio = getIntSys("esercizio");
			MetaData MetaVarUltimaFase = Meta.Dispatcher.Get(tMainVar);
			MetaVarUltimaFase.SetDefaults(dsFinancial.Tables[tMainVar]);
			DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
			// Generazione variazioni di azzeramento sulle ultime fasi entrata e spesa CSA
			MetaData.SetDefault(dsFinancial.Tables[tMainVar], "adate", DataCont);
			MetaData.SetDefault(dsFinancial.Tables[tMainVar], "yvar", esercizio);
			// 32,'AZZERACSA','Azzeramento Versamenti CSA'
			MetaData.SetDefault(dsFinancial.Tables[tMainVar], "autokind", 32);

			string maxPhaseName = (IoE == "I") ? "maxincomephase" : "maxexpensephase";
			int fasemax = getIntSys(maxPhaseName);
			int ultimafasedagenerare = fasemax;

			string regPhaseName = (IoE == "I") ? "incomeregphase" : "expenseregphase";
			int faseCreditoreDebitore = getIntSys(regPhaseName);

			string finPhaseName = (IoE == "I") ? "incomefinphase" : "expensefinphase";
			int faseBilancio = getIntSys(finPhaseName);

			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			string idParMovField = (IoE == "I") ? "parentidinc" : "parentidexp";

			string idAcc = (IoE == "I") ? "idacccredit" : "idaccdebit";

			string descrLoV = (lordi) ? "Lordi " : "Versamenti ";

			DataTable Mov = dsFinancial.Tables[tMain];
			DataTable ImpMov = dsFinancial.Tables[tMainYear];
			DataTable ImportMov = dsFinancial.Tables[tImportMain];
			DataTable ImportMovRiepPlus = dsFinancial.Tables[tImportMainRiepPlus];
			DataTable ImportMovVerPlus = dsFinancial.Tables[tImportMainVerPlus];

			if (IoE == "E") {
				RowChange.SetOptimized(Mov, true);
				RowChange.ClearMaxCache(Mov);
				RowChange.SetOptimized(ImpMov, true);
				RowChange.ClearMaxCache(ImpMov);
				RowChange.SetOptimized(ImportMov, true);
				RowChange.ClearMaxCache(ImportMov);
				RowChange.SetOptimized(ImportMovRiepPlus, true);
				RowChange.ClearMaxCache(ImportMovRiepPlus);
				RowChange.SetOptimized(ImportMovVerPlus, true);
				RowChange.ClearMaxCache(ImportMovVerPlus);
			}

			RowChange.SetOptimized(dsFinancial.Tables[tMainSorted], true);
			RowChange.ClearMaxCache(dsFinancial.Tables[tMainSorted]);

			DataTable AllPaymethod = Conn.RUN_SELECT("paymethod", "*", null, null, null, true);

			//fase classificazione MIUR   (<= 0 se non presente)
			int faseSortingPARENT = DetectFaseSortingParent(IoE);

			// Automatismi di entrata o spesa
			string filterAuto = (IoE == "I") ? QHC.CmpEq("kind", "Entrata") : QHC.CmpEq("kind", "Spesa");
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			
			List<DataRow> Auto = new List<DataRow>();
			bool flagEsenteBancaPredefinita = LeggiFlagEsenteBancaPredefinita(); //true se flag impostato
			object csa_flaglinktoexp = Get_FlagLinkToExp();
			Dictionary<int, bool> ExpenseToPreserve = new Dictionary<int, bool>();
			for (int ii = 0; ii < SP_Result.Rows.Count; ii++) {
				DataRow R = SP_Result.Rows[ii];
				//object idcsa_import = R["idcsa_import"];
				if (R["kind"].ToString() != kind) continue;
				Auto.Add(R);
				int NRIGA = CfgFn.GetNoNullInt32(R["nriga"]);
				AddVociCollegate(R);
				DataRow ParentR = null;
				object parentidmov = DBNull.Value; //All'inizio il movimento parent corrente è null
				int movkind = CfgFn.GetNoNullInt32(R["movkind"]);
				// Genera tutte le fasi oppure si ferma alla fase residui a seconda dell'opzione scelta nel tab precedente
				int faseIniziale = 1;
				if (R["parent_phase"] != DBNull.Value) {
					faseIniziale = CfgFn.GetNoNullInt32(R["parent_phase"]) + 1;
					parentidmov = R["parent" + idMovField];
				}

				for (int faseCorrente = faseIniziale; faseCorrente <= fasemax; faseCorrente++) {
					//if (faseCorrente > ultimafasedagenerare) continue;
					if (kind == "E" && faseCorrente == fasemax && nonPagareNettiPositivi) {
						decimal netto = CfgFn.GetNoNullDecimal(R["netto"]);
						if (netto != 0) continue;
					}


					Mov.Columns["nphase"].DefaultValue = faseCorrente;
					DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
					if (nonPagareNettiPositivi && kind == "E" && faseCorrente == fasemax - 1) {
						ExpenseToPreserve.Add(CfgFn.GetNoNullInt32(NewMovRow["idexp"]), true);
					}

					//Imposta il movimento parent tramite il livsupid. Il movimento parent è quello generato nella fase precedente
					NewMovRow[idParMovField] = parentidmov;
					parentidmov = NewMovRow[idMovField];
					ParentR = NewMovRow;
					FillMovimento(NewMovRow, R);
					string description = NewMovRow["description"].ToString();
					if (!description.Contains("Versament"))
						description = "Fase " + descrLoV + description;
					if (description.Length > 150) description = description.Substring(0, 150);
					NewMovRow["description"] = description;
					R["idmovimento"] = NewMovRow[idMovField];
					NewMovRow["nphase"] = faseCorrente;

					if (faseCorrente < faseCreditoreDebitore) {
						NewMovRow["idreg"] = DBNull.Value;
					}

					if (movkind == 4 || movkind == 9 || movkind == 10) {
						NewMovRow["autokind"] = 31;
					}

					if (movkind == 1) {
						// serve in fase di trasmissione, a generare dettagli scritture con                    
						NewMovRow["autocode"] = R["idcsa_agency"]; // anagrafiche distinte
					}

					//Se c'è la configurazione apposita e se  il movimento è di entrata, lo collega alla spesa corrispondente 
					// al campo "indice" della tabella raggruppata

					if ((IoE == "I") && (csa_flaglinktoexp.ToString() == "S")) {
						if (R["indice"] != DBNull.Value)
							if (IdExpPerIndice[CfgFn.GetNoNullInt32(R["indice"])] != null) {
								NewMovRow["idpayment"] = IdExpPerIndice[CfgFn.GetNoNullInt32(R["indice"])];
							}
							else {
								MessageBox.Show("Errore di programma, indice interno non trovato");
							}
					}


					if (faseCorrente == faseSortingPARENT) {
						FillMovSortedFaseParent(NRIGA, IoE, NewMovRow);
					}

					//QueryCreator.MarkEvent($"reached NRIGA {NRIGA}-{R["indice"]}-fase {faseCorrente}");
					if (faseCorrente == fasemax) {
						if (R["indice"] != DBNull.Value) {
							int indice = CfgFn.GetNoNullInt32(R["indice"]);
							if (IoE == "E") {
								voceCsaPerIdExp[NewMovRow[idMovField]] = SP_Result.Rows[indice]["vocecsa"];
								enteCsaPerIdExp[NewMovRow[idMovField]] = SP_Result.Rows[indice]["idcsa_agency"];
							}
							else {
								voceCsaPerIdInc[NewMovRow[idMovField]] = SP_Result.Rows[indice]["vocecsa"];
							}

							if (IoE == "E" && R["indice"] != DBNull.Value) {
								IdExpPerIndice[indice] = NewMovRow[idMovField];
							}
						}

						DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainLast]);
						if (IoE == "E") {
							object codicecreddeb = R["idreg"];
							DataRow ModPagam = null;
							// non associo alcun sospeso se devo azzerare l'ultima fase
							if (agency_not_use_nbill(R["idcsa_agency"]) || azzeraUltimaFase) {
								ModPagam = GetModalitaPagamento(codicecreddeb, R["idcsa_agency"],
									R["idcsa_agencypaymethod"]);
							}


							NewLastRow["flag"] = 0;
							int datiModPagam = 0;
							object idchargehandling = DBNull.Value;
							if (ModPagam != null) { // vecchia gestione o pagamenti non a regolarizzazione
								datiModPagam = CfgFn.GetNoNullInt32(ModPagam["flag"]);
								idchargehandling = ModPagam["idchargehandling"];
							}
							else {
								// nuova gestione
								datiModPagam = CfgFn.GetNoNullInt32(Get_FlagEsenteSpese_CSA());
								idchargehandling = Get_idchargehandling_CSA();
							}

							NewLastRow["idchargehandling"] = idchargehandling;
							bool regolarizzazioneEffettuata = false;

							if (!azzeraUltimaFase) {
								// Verifico l'esistenza di sospesi multipli
								decimal amount = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
								//MessageBox.Show(elencoSospesi.ToArray().ToString());
								var bill = getSospesiPerAnagrafica(CfgFn.GetNoNullInt32(codicecreddeb), sospesi,
									amount);
								if ((bill.Keys.Count == 1) && (CfgFn.GetNoNullDecimal(R["netto"]) != 0)) {
									var Bill = bill.First();
									NewLastRow["nbill"] = Bill.Key;
									NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
									regolarizzazioneEffettuata = true;
								}

								if ((bill.Keys.Count > 1) && (CfgFn.GetNoNullDecimal(R["netto"]) != 0)) {
									foreach (int nBill in bill.Keys) {
										var newBill = MetaMBill.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainBill]);
										newBill["nbill"] = nBill;
										newBill["ybill"] = esercizio;
										newBill["amount"] = bill[nBill];
										NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
										regolarizzazioneEffettuata = true;
										//MessageBox.Show("ripartizione sospeso su movimento " + NewLastRow["nbill"].ToString() + " " + "anagr." + codicecreddeb.ToString());
									}
								}

								if ((bill.Keys.Count == 0) && (R["nbill"] != DBNull.Value)) {
									NewLastRow["nbill"] = R["nbill"];
									NewLastRow["flag"] = CfgFn.GetNoNullInt32(NewLastRow["flag"]) | 1;
									regolarizzazioneEffettuata = true;
								}

								NewLastRow["paymethod_flag"] = 0;
								//MessageBox.Show("sospeso su movimento " + NewLastRow["nbill"].ToString() + " " + "anagr." + codicecreddeb.ToString());
							}

							if (ModPagam != null && regolarizzazioneEffettuata == false) {
								#region riempimento mod. pagamento

								//aggiungere le informazioni della modalità di pagamento
								NewLastRow["idregistrypaymethod"] = ModPagam["idregistrypaymethod"];
								NewLastRow["idpaymethod"] = ModPagam["idpaymethod"];
								NewLastRow["iban"] = ModPagam["iban"];
								NewLastRow["cin"] = ModPagam["cin"];
								NewLastRow["idbank"] = ModPagam["idbank"];
								NewLastRow["idcab"] = ModPagam["idcab"];
								NewLastRow["cc"] = ModPagam["cc"];
								NewLastRow["iddeputy"] = ModPagam["iddeputy"];
								NewLastRow["refexternaldoc"] = ModPagam["refexternaldoc"];
								NewLastRow["paymentdescr"] = ModPagam["paymentdescr"];
								NewLastRow["biccode"] = ModPagam["biccode"];
								NewLastRow["extracode"] = ModPagam["extracode"];

								object idpaymethod = ModPagam["idpaymethod"];
								string filterpaymethod = QHC.CmpEq("idpaymethod", idpaymethod);

								//DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);
								DataRow[] pmethods = AllPaymethod.Select(filterpaymethod);
								if (pmethods.Length > 0) {
									object paymethod_allowdeputy = pmethods[0]["allowdeputy"];
									object paymethod_flag = pmethods[0]["flag"];
									NewLastRow["paymethod_allowdeputy"] = paymethod_allowdeputy;
									NewLastRow["paymethod_flag"] = paymethod_flag;
								}

								#endregion
							}

							if (flagEsenteBancaPredefinita) { //in questo caso ignora i casi suddetti
								int flag = CfgFn.GetNoNullInt32(NewLastRow["flag"]);
								int flag_exemption = (CfgFn.GetNoNullInt32(NewLastRow["flag"]) & 0xF7) |
								                     ((datiModPagam & 1) << 3);
								NewLastRow["flag"] = flag_exemption;
							}

						}

						NewLastRow[idAcc] = R["idacc"];
						FillMovSortedFaseMAX(false, /*azzeraUltimaFase*/ NRIGA, IoE,
							NewMovRow); // inserisce le classificazioni 

						if (azzeraUltimaFase) {
							decimal valore_da_azzerare = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));

							DataRow DRVarUltimaFase;
							if (valore_da_azzerare > 0) {
								DRVarUltimaFase =
									MetaVarUltimaFase.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainVar]);
								DRVarUltimaFase["nvar"] = 1;
								DRVarUltimaFase["amount"] = -valore_da_azzerare;
								DRVarUltimaFase[idMovField] = NewMovRow[idMovField];
								DRVarUltimaFase["description"] = "Variazione di Azzeramento del Versamento CSA";
							}
						}

					}

					DataRow NewImpMov = ImpMov.NewRow();

					FillImputazioneMovimento(NewImpMov, R);
					NewImpMov[idMovField] = NewMovRow[idMovField];
					NewImpMov["ayear"] = esercizio;

					if (faseCorrente < faseBilancio) {
						NewImpMov["idfin"] = DBNull.Value;
						NewImpMov["idupb"] = DBNull.Value;
					}

					ImpMov.Rows.Add(NewImpMov);


					

					
					HashSet<int> idcsa_collegati= new HashSet<int>();

					foreach (var rQuota in movimentiRaggruppati.getLinkedToMov(R)) {
						int idcsaImport = CfgFn.GetNoNullInt32(rQuota.mov["idcsa_import"]);

						if (!idcsa_collegati.Contains(idcsaImport)) {
							idcsa_collegati.Add(idcsaImport);
							DataRow NewImportMovRow = ImportMov.NewRow();
							FillImportMov(azzeraUltimaFase, NewImportMovRow, R, idcsaImport);
							NewImportMovRow[idMovField] = R["idmovimento"];
							ImportMov.Rows.Add(NewImportMovRow);
						}

						DataRow NewImportMovPlusRow = ImportMovVerPlus.NewRow();
						rQuota.mov["amount"] = rQuota.quota;
						FillImportMov((azzeraUltimaFase&&(faseCorrente==fasemax)), NewImportMovPlusRow, rQuota.mov, idcsaImport);
						NewImportMovPlusRow[idMovField] =R["idmovimento"]; //R["idmovimento"];//R è la stessa della riga di spesa collegata alla riga della sp in oggetto
						ImportMovVerPlus.Rows.Add(NewImportMovPlusRow);
					}

				}
			}



			return true;
		}

		private QuoteCsa movimentiRaggruppati = null;

		/// <summary>
		/// Chiama la SP che calcoli i movimenti per i Lordi o per i Versamenti
		/// Calcola la tabella OutTable (righe non raggruppate) e la tabella SP_Result (righe raggruppate)
		/// </summary>
		/// <param name="kind">L/V</param>
		/// <returns>false on errors</returns>
		private bool CallStoredProcedure(List<DataRow> LsImportazioni, List<DataRow> LsEnti) {

			OutTable = callSp(Conn, 
				(from r in LsImportazioni select (int) r["idcsa_import"]).ToList(),
				(from r in LsEnti select (int) r["idreg_agency"]).ToList());
			if (OutTable == null || OutTable.Rows.Count == 0) {
				return false;
			}

			return true;
		}



		/// <summary>
		/// Aggiunge alla tabella T una riga copia di R e restituisce la riga creata
		/// </summary>
		/// <param name="R">Riga da copiare</param>
		/// <param name="T">Tabella in cui creare la riga</param>
		/// <returns>copia della riga</returns>


		private void AddRowToTable(DataRow R, DataTable T, int i) {
			DataRow NewR = T.NewRow();
			if (T.TableName == "incomeview") {
				NewR["idinc"] = i;
			}

			if (T.TableName == "expenseview") {
				NewR["idexp"] = i;
			}

			foreach (DataColumn C in R.Table.Columns) {
				if (C.ColumnName == "idmovimento") continue;
				if (C.ColumnName == "indice") continue;
				if (C.ColumnName == "movkind") continue;
				if (C.ColumnName == "kind") continue;
				if (C.ColumnName == "idacc") continue;
				if (C.ColumnName == "codeacc") continue;
				if (C.ColumnName == "idcsa_agency") continue;
				if (C.ColumnName == "idcsa_agencypaymethod") continue;
				if (C.ColumnName == "indice") continue;
				if (C.ColumnName == "nriga") continue;
				if (C.ColumnName == "idsor") continue;
				if (C.ColumnName == "vocecsa") continue;
				if (C.ColumnName == "idunderwriting") continue;
				if ((T.TableName == "incomeview") && (C.ColumnName == "parentidexp")) continue;
				if ((T.TableName == "expenseview") && (C.ColumnName == "parentidinc")) continue;
				if (!T.Columns.Contains(C.ColumnName)) continue;
				NewR[C.ColumnName] = R[C.ColumnName];
			}

			T.Rows.Add(NewR);
		}

		object _myFlagBalanceCSA = null;

		/// <summary>
		/// Verifica se bisogna collegare le reversali delle ritenute ai movimenti di spesa dei lordi
		/// </summary>
		/// <returns></returns>


		Hashtable hSospesi = null;

		object getSospeso() {
			int nbill = 0;
			if (txtNumBollettaVersamenti.Text.Trim() != "")
				nbill = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),
					txtNumBollettaVersamenti.Text, HelpForm.GetStandardTag(txtNumBollettaVersamenti.Tag)));
			if (nbill != 0) return nbill;
			else return DBNull.Value;
		}



		/// <summary>
		/// Riempie le tabelle per i grid a partire dalla tabella in input
		/// </summary>
		/// <param name="Automatismi"></param>
		private void FillTables(DataTable Automatismi) {
			dsFinancial.expenseview.Clear();
			for (int i = 0; i < Automatismi.Rows.Count; i++) {
				DataRow R = Automatismi.Rows[i];
				AddRowToTable(R, dsFinancial.expenseview, i);
			}

			dsFinancial.incomeview.Clear();
			for (int i = 0; i < Automatismi.Rows.Count; i++) {
				DataRow R = Automatismi.Rows[i];
				AddRowToTable(R, dsFinancial.incomeview, i);
			}

			dsFinancial.expenseview.AcceptChanges();
			dsFinancial.incomeview.AcceptChanges();
		}


		private bool CalcolaMovConDisponibileInsufficiente(DataTable Automatismi) {
			DataSet ds = new DataSet();
			DataTable tResult = new DataTable("tResult");

			tResult.Columns.Add("movimento", typeof(string));
			tResult.Columns.Add("bilancio", typeof(string));
			tResult.Columns.Add("upb", typeof(string));
			tResult.Columns.Add("registry", typeof(string));
			tResult.Columns.Add("curramount", typeof(decimal));
			tResult.Columns.Add("available", typeof(decimal));
			tResult.Columns.Add("amount", typeof(decimal));
			tResult.Columns.Add("new_available", typeof(decimal));
			ds.Tables.Add(tResult);

			ImpostaCaption(tResult);
			//string list = QHC.DistinctVal(Automatismi.Select(QHC.AppAnd(QHC.CmpEq("kind", "spesa"),
			//QHC.IsNotNull("parentidexp"))), "parentidexp");
			//foreach (object parentidexp in QHC.FieldInList("parentidexp",list)) {

			List < int > list= new List<int>();
			foreach (DataRow R in Automatismi.Select(QHC.AppAnd(QHC.CmpEq("kind", "spesa"), QHC.IsNotNull("parentidexp")))) {
				int parentidexp = CfgFn.GetNoNullInt32(R["parentidexp"]);
				list.Add(parentidexp);
			}
			foreach (int parentidexp   in list ) {
				 
				string filter = QHC.CmpEq("parentidexp", parentidexp);
				decimal amount = CfgFn.GetNoNullDecimal(Automatismi.Compute("sum(amount)",filter)); // importo corrente movimenti generati
				DataTable expenseview = Conn.RUN_SELECT("expenseview", "*", null,  QHS.AppAnd(QHS.CmpEq("idexp", parentidexp),
										  QHS.CmpEq("ayear", Meta.GetSys("esercizio") )), null, false);
				decimal curramount = 0;
				decimal available = 0;
				string phase  = "";
				string nmov   = "";
				string ymov   = "";

				string codefin  = "";
				string finance   = "";
				string codeupb   = "";
				string upb   = "";
				string registry   = "";
				if (expenseview.Rows.Count > 0) {
					DataRow EY = expenseview.Rows[0];
					curramount = CfgFn.GetNoNullDecimal(EY["curramount"]);
					available = CfgFn.GetNoNullDecimal(EY["available"]);
					phase = EY["phase"].ToString();
					nmov = EY["nmov"].ToString();
					ymov = EY["ymov"].ToString();
					codefin = EY["codefin"].ToString();
					finance = EY["finance"].ToString();
					codeupb = EY["codeupb"].ToString();
					upb = EY["upb"].ToString();
					registry = EY["registry"].ToString();

					decimal new_available = available - amount;

					if (new_available < 0) {
						DataRow NewR = tResult.NewRow();
						NewR["movimento"] = phase + " n " + nmov + '/' + ymov;
						NewR["bilancio"] = codefin + '-' + finance;
						NewR["upb"] = codeupb + '-' + upb;
						NewR["registry"] = registry;
						NewR["curramount"] = curramount;
						NewR["available"] = available;
						NewR["amount"] = amount;
						NewR["new_available"] = new_available;

						tResult.Rows.Add(NewR);
					}
				}
			}
			if ((tResult != null) && (tResult.Rows.Count > 0)) {
				exportclass.DataTableToExcel(tResult, true);
				return false;
			}
			return true;
		}
	 

 

/// <summary>
/// Collega le entrate alle spesa sulla semplice base di avere pari creditore, a patto che vi sia un unico 
///  movimento di spesa avente quel creditore in uscita. In quel caso idpayment di income viene posto uguale 
///  all'idexp del movimento di spesa
/// </summary>
private void collegaEntrateaSpese() {
			int faseentratamax = getIntSys("maxincomephase");
			int fasespesamax = getIntSys("maxexpensephase");
			// Ciclo sugli automatismi di entrata per determinare l'eventuale movimento di spesa da associare
			DataTable Income = dsFinancial.Tables["income"];
			DataTable Expense = dsFinancial.Tables["expense"];
			foreach (DataRow R in Income.Select(QHC.CmpEq("nphase", faseentratamax))) {
				object vocecsa_incasso = voceCsaPerIdInc[CfgFn.GetNoNullInt32(R["idinc"])];
				if (R["idpayment"] != DBNull.Value) continue;

				object idreg_csa = R["idreg"];
				DataRow[] RExp =
					Expense.Select(QHC.AppAnd(QHC.CmpEq("nphase", fasespesamax), QHC.CmpEq("idreg", idreg_csa)));
				foreach (DataRow r in RExp) {
					object vocecsa_pagamento = voceCsaPerIdExp[CfgFn.GetNoNullInt32(r["idexp"])];
					object idcsa_agency = enteCsaPerIdExp[CfgFn.GetNoNullInt32(r["idexp"])];
					//if (!CollegaAutomatismiEnteCSA(idcsa_agency)) continue;
					if (vocecsa_pagamento == null && vocecsa_incasso == null) {
						R["idpayment"] = r["idexp"];
						break;
					}

					if (vocecsa_pagamento == null || vocecsa_incasso == null) {
						continue;
					}

					if (vocecsa_pagamento.ToString() == vocecsa_incasso.ToString()) {
						R["idpayment"] = r["idexp"];
						break;
					}

					continue;
				}


			}

			return;
		}

		private void scollegaEntratedaSpese() {
			// Questo metodo scollega le entrate collegate alle spese se il loro importo è superiore
			// in quanto potrebbe derminare dei mandati a netto negativo
			int faseentratamax = getIntSys("maxincomephase");
			int fasespesamax = getIntSys("maxexpensephase");
			// Ciclo sugli automatismi di spesa eventualmente associati a movimenti di entrata
			DataTable Expense = dsFinancial.Tables["expense"];
			DataTable Income = dsFinancial.Tables["income"];

			DataTable ExpenseYear = dsFinancial.Tables["expenseyear"];
			DataTable IncomeYear = dsFinancial.Tables["incomeyear"];
			bool unlinked = false;

			foreach (DataRow R in Expense.Select(QHC.CmpEq("nphase", fasespesamax))) {
				object idpayment = R["idexp"];
				string filter = QHC.AppAnd(QHC.CmpEq("nphase", faseentratamax), QHC.CmpEq("idpayment", idpayment));

				DataRow[] linkedIncome = Income.Select(filter);

				if (linkedIncome.Length == 0) continue;

				string filterExpenseYear = QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")),
					QHC.CmpEq("idexp", idpayment));

				DataRow[] linkedExpenseYear = ExpenseYear.Select(filterExpenseYear);
				decimal amountExp = 0;

				if (linkedExpenseYear.Length > 0) {
					DataRow rExp = linkedExpenseYear[0];
					amountExp = CfgFn.GetNoNullDecimal(rExp["amount"]);
				}

				string filterIncomeYear = QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")),
					QHC.FieldIn("idinc", linkedIncome, "idinc"));

				DataRow[] linkedIncomeYear = IncomeYear.Select(filterIncomeYear);
				decimal totLinked = 0;

				foreach (DataRow RLinked in linkedIncomeYear) {
					totLinked += CfgFn.GetNoNullDecimal(RLinked["amount"]);
				}

				if (totLinked > amountExp) {
					foreach (DataRow R1 in Income.Select(QHC.CmpEq("idpayment", idpayment))) {
						R1["idpayment"] = DBNull.Value;
						unlinked = true;
					}
				}
			}

			if (unlinked) {
				MessageBox.Show(
					"Sono stati scollegati alcuni movimenti di entrata dai relativi movimenti di spesa per evitare mandati con importo netto negativo");
			}

			return;
		}

		/// <summary>
		/// Contiene gli idexp (temporanei) dei DataRow di spesa raggruppati, ha come chiave l'indice delle stesse nel relativo datatable
		/// </summary>
		private Hashtable IdExpPerIndice = new Hashtable();

		private Hashtable vocecsaPerIndice = new Hashtable();

		/// <summary>
		/// Conta le righe di riepilogo e versamento e restituisce true se ve n'è almeno una
		/// </summary>
		/// <returns></returns>

		Hashtable voceCsaPerIdInc = new Hashtable();

		Hashtable voceCsaPerIdExp = new Hashtable();
		Hashtable enteCsaPerIdExp = new Hashtable();

		/// <summary>
		/// Genera i movimenti finanziari per i lordi (kind=L) o per i versamenti (kind= V)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <param name="kind">L lordi V versamenti</param>
		private void btnGeneraMovFin_Click(object sender, System.EventArgs e, string kind) {
			//Meta.GetFormData(true);
			string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			if (MessageBox.Show(
				    " Attenzione: é necessario verificare preventivamente le singole importazioni dell'anno " + "\r\n" +
				    " per rilevare e correggere possibili errori nell'individuazione di Anagrafiche, Contratti, Enti. " +
				    "\r\n" +
				    " Premere OK per continuare lo stesso, in caso si sia già provveduto, oppure " + "\r\n" +
				    " premere ANNULLA per interrompere l'elaborazione.", "Avviso", MessageBoxButtons.OKCancel) ==
			    DialogResult.Cancel) return;

			dsFinancial.Clear();
			dsFinancial.AcceptChanges();
			RowChange.SetOptimized(dsFinancial.expensesorted, true);
			RowChange.ClearMaxCache(dsFinancial.expensesorted);
			RowChange.SetOptimized(dsFinancial.incomesorted, true);
			RowChange.ClearMaxCache(dsFinancial.incomesorted);
			RowChange.SetOptimized(dsFinancial.underwritingappropriation, true);
			RowChange.ClearMaxCache(dsFinancial.underwritingappropriation);
			RowChange.SetOptimized(dsFinancial.underwritingpayment, true);
			RowChange.ClearMaxCache(dsFinancial.underwritingpayment);
			DataRow[] ImportazioniSelected = GetGridSelectedRows(dgrImportazioni);
			DataRow[] EntiVersamentoSelected = GetGridSelectedRows(dgrEntiVersamento);


			List<DataRow> LsEnti = new List<DataRow>();
			List<DataRow> LsImportazioni = new List<DataRow>();

			if (EntiVersamentoSelected != null) {
				foreach (DataRow rEnte in EntiVersamentoSelected) {
					if (LsEnti.Contains(rEnte)) continue;
					LsEnti.Add(rEnte);
				}
			}

			if (ImportazioniSelected != null) {
				foreach (DataRow rImportazione in ImportazioniSelected) {
					LsImportazioni.Add(rImportazione);
				}
			}

			if ((LsEnti.Count == 0) && (LsImportazioni.Count == 0)) {
				MessageBox.Show("E' necessario selezionare almeno un Ente e almeno un'Importazione");
				return;
			}

			if (CallStoredProcedure(LsImportazioni, LsEnti)) {

				clearHashTabelleCollegate();

				// Filtra OUTTABLE in base alle righe versamenti già elaborate,  
				QueryCreator.MarkEvent("Prima della delete:"+OutTable.Rows.Count+" righe");
				foreach (DataRow rVer in OutTable.Rows) {
					string keyRow = getHash(rVer, new[] {"idcsa_import", "idver"});
					if (SpeseElaborate.ContainsKey(keyRow) || EntrateElaborate.ContainsKey(keyRow))
						rVer.Delete();
				}

				OutTable.AcceptChanges();

				QueryCreator.MarkEvent("Dopo la delete:"+OutTable.Rows.Count+" righe");

				if ((OutTable == null) || OutTable.Rows.Count == 0) return;
				IdExpPerIndice = new Hashtable();
				voceCsaPerIdInc = new Hashtable();
				voceCsaPerIdExp = new Hashtable();

				movimentiRaggruppati = null;
				object nBill = getSospeso();
				var listaSospesi = new Dictionary<int, Dictionary<int, decimal>>();
				if (kind == "V") {
					DataTable csaBill = csa_bill_global;
					listaSospesi = getElencoSospesi(csaBill);
				}

				SP_Result = csa_import_default.nuovaGestionOutTable.calcola(OutTable, Conn, out movimentiRaggruppati);

				QueryCreator.MarkEvent("Dopo calcola SP_Result ha "+SP_Result.Rows.Count+" righe");
				if (movimentiRaggruppati != null) {
					int totale = 0;
					foreach (DataRow r in SP_Result.Rows) {
						var linkedCsa = movimentiRaggruppati.getLinkedToMov(r);
						totale += linkedCsa.Count;
					}
					QueryCreator.MarkEvent("movimentiRaggruppati "+totale+" righe");
				}

				
				if ((SP_Result == null) || SP_Result.Rows.Count == 0) {
					MessageBox.Show("Per gli Enti e le Importazioni selezionate non ci sono righe da elaborare");
				}
				//formtest frm = new formtest(SP_Result, SP_Result);

				//DialogResult dr = frm.ShowDialog();
				if (!CalcolaMovConDisponibileInsufficiente(SP_Result))  {
					MessageBox.Show("Per gli Enti e le Importazioni selezionate saranno generati movimenti con disponibile insufficiente");
					//return;
				}

				if (nuovaGestione()) {
					if (!SP_Result.Columns.Contains("nbill")) SP_Result.Columns.Add("nbill", typeof(Int32));
					foreach (DataRow r in SP_Result.Rows) {
						if ((CfgFn.GetNoNullDecimal(r["netto"]) != 0) && (r["kind"].ToString() == "Spesa")) {
							// Per alcuni enti versamento non si deve specificare il sospeso sui movimenti di tipo 4, Versamento Contributi e Ritenute
							if (agency_not_use_nbill(r["idcsa_agency"])) {
								r["nbill"] = DBNull.Value;
							}
							else {
								r["nbill"] =
									(CfgFn.GetNoNullInt32(nBill) != 0) ? nBill : DBNull.Value;
							}
						}
						else
							r["nbill"] = DBNull.Value; // Entrate o eventuali movimenti a netto 0
					}
				}

				Dictionary<object, string> csaDescr = new Dictionary<object, string>();

				//foreach (DataRow rImp in LsImportazioni) {
				//	string descr = $"Fase Versamenti Importazione n.{rImp["nimport"]}/{rImp["yimport"]} {rImp["description"]}";
				//	csaDescr[rImp["idcsa_import"]] = descr;
				//}

				if (movimentiRaggruppati != null) {
					foreach (DataRow r in SP_Result.Rows) {
						object idcsa_import = r["idcsa_import"];
						var linkedCsa = movimentiRaggruppati.getLinkedToMov(r);
						foreach (var rL in linkedCsa) {
							if (rL.mov["idcsa_import"].ToString() != idcsa_import.ToString()) {
								r["description"] = "Versamenti posticipati";
							}
						}
					}
				}

				FillTables(SP_Result);
				if (dsFinancial.config.Rows.Count == 0) {
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.config,
						null, fEsercizio, null, true);
				}

				if (dsFinancial.sortingkind.Rows.Count == 0) {
					DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.sortingkind,
						null, null, null, true);
				}

				//FillImportazione(curr["idcsa_import"]);
				bool LiquidazioneDicembre = false;


				// Verificare l'esistenza di movimenti finanziari precedentemente generati
				if (!generaMovPrincipali("E", LiquidazioneDicembre, listaSospesi, false)) {
					MessageBox.Show(this, "Errore nella generazione dei movimenti finanziari di spesa");

					clearHashTabelleCollegate();
					dsFinancial.Clear();
					dsFinancial.AcceptChanges();
					return;
				}

				if (!generaMovPrincipali("I", LiquidazioneDicembre, null, false)) {
					MessageBox.Show(this, "Errore nella generazione dei movimenti finanziari di entrata");
					clearHashTabelleCollegate();
					dsFinancial.Clear();
					dsFinancial.AcceptChanges();
					return;
				}

				if (!nuovaGestione()) {

					if (kind == "V") {
						collegaEntrateaSpese();
					}

					scollegaEntratedaSpese();
				}

				if (doSave()) {
					lblTask.Text = "Dati salvati con successo";
				}
				else lblTask.Text = "I Dati non sono stati salvati";

				//progressBarImport.Visible = false;
				dsFinancial.Clear();
				dsFinancial.AcceptChanges();
				GetElencoVociCSA();

			}
			else {
				MessageBox.Show(this, "Per gli Enti e le Importazioni selezionate non ci sono righe da elaborare ");
			}

		}




		private bool executing = false;

		private void btnVersamenti_Click(object sender, EventArgs e) {
			if (executing) return;
			// btnVersamenti.Visible = false;
			executing = true;
			//sia entrate che spese
			string message = "";
			lblTask.Text = "";
			DataRow[] ImportazioniSelected = GetGridSelectedRows(dgrImportazioni);
			DataRow[] EntiVersamentoSelected = GetGridSelectedRows(dgrEntiVersamento);
			if ((ImportazioniSelected.Length == 0) && (EntiVersamentoSelected.Length == 0)) {
				MessageBox.Show("E' necessario selezionare almeno un Ente e almeno un'Importazione");
				executing = false;
				return;
			}

			if (chkAzzeraUltimaFase.Checked)
				message = "Si è scelto di generare i movimenti finanziari esclusa l'ultima fase?";
			else message = "Si è scelto di generare tutte le fasi di spesa (fino all'ultima fase)?";
			if (MessageBox.Show(this, message,
				    "Conferma", MessageBoxButtons.YesNo) == DialogResult.No) {
				executing = false;
				return;
			}

			btnGeneraMovFin_Click(sender, e, "V");

			//btnVersamenti.Visible = true;
			executing = false; // Consente di rieseguire la procedura
		}



		private void btnBollettaVersamenti_Click(object sender, EventArgs e) {
			string filteresercizio = QHS.CmpEq("ybill", Meta.GetSys("esercizio"));
			int annosuccessivo = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
			string filteresercizionew = QHS.CmpEq("ybill", annosuccessivo);

			string filter = (QHS.DoPar(QHS.AppOr(filteresercizio, filteresercizionew)));

			filter = QHS.AppAnd(filter, QHS.CmpEq("billkind", "D"));

			string VistaScelta = "billview";

			MetaData meta_bill = Meta.Dispatcher.Get(VistaScelta);
			meta_bill.FilterLocked = true;
			meta_bill.DS = DS;
			DataRow myDr = meta_bill.SelectOne("default", filter, null, null);
			if (myDr != null) {
				DS.bill_versamenti.Clear();
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bill_versamenti, null,
					QHS.AppAnd(QHS.CmpEq("ybill", myDr["ybill"]),
						QHS.CmpEq("nbill", myDr["nbill"]),
						QHS.CmpEq("billkind", "D")),
					null, true);
				txtEsercBollettaVersamenti.Text = myDr["ybill"].ToString();
				txtNumBollettaVersamenti.Text = myDr["nbill"].ToString();
				HelpForm.FormatLikeYear(txtEsercBollettaVersamenti);
			}
		}

		#region importazione bollette

		private void ImpostaColonneTracciatoDettagli(DataTable mData) {
			mData.Columns.Clear();
			mData.Columns.Add("denominazione_anagrafica", typeof(string));
			mData.Columns.Add("n_sospeso", typeof(int));
			mData.Columns.Add("importo", typeof(decimal));
		}

		public string GetTracciato(string[] tracciato) {
			string res = "";
			int pos = 0;
			foreach (string t in tracciato) {
				string[] ss = t.Split(';');
				string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
				               ss[3].PadLeft(4) +
				               " Tipo: " + ss[2].PadLeft(15);
				if (ss[2].ToLower() == "codificato") {
					field += " Codifica:" + ss[4];
				}

				field += " Descrizione: " + ss[1];
				field += "\r\n";
				pos += CfgFn.GetNoNullInt32(ss[3]);
				res += field;
			}

			return res;
		}

		public DataTable GetTableTracciato(string[] tracciato) {
			int pos = 0;
			DataTable T = new DataTable("t");
			T.Columns.Add("nome", typeof(string));
			T.Columns.Add("posizione", typeof(int));
			T.Columns.Add("lunghezza", typeof(string));
			T.Columns.Add("tipo", typeof(string));
			T.Columns.Add("codifica", typeof(string));
			T.Columns.Add("Descrizione", typeof(string));

			foreach (string t in tracciato) {
				DataRow r = T.NewRow();
				string[] ss = t.Split(';');
				r["nome"] = ss[0];
				r["posizione"] = pos;
				r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
				r["tipo"] = ss[2];
				if (ss.Length == 5) r["codifica"] = ss[4];
				r["Descrizione"] = ss[1];
				pos += CfgFn.GetNoNullInt32(ss[3]);
				T.Rows.Add(r);
			}

			return T;
		}

		private void MenuEnterPwd_Click(object sender, EventArgs e) {
			if (sender == null) return;
			if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
			object mysender = ((MenuItem) sender).Parent.GetContextMenu().SourceControl;
			string tracciato = "";
			DataTable TableTracciato = null;

			tracciato = GetTracciato(tracciato_sospeso);
			TableTracciato = GetTableTracciato(tracciato_sospeso);
			FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
			FT.ShowDialog();
		}

		string[] tracciato_sospeso =
			new string[] {
				"DENOMINAZIONE_ANAGRAFICA;Anagrafica;Stringa;150",
				"N_SOSPESO;Numero sospeso(nbill);Intero;8",
				"IMPORTO;Importo;Numero;22"
			};

		Dictionary<object, int> __myNBill = new Dictionary<object, int>();

		private bool CheckSospeso(object n_sospeso) {
			if ((n_sospeso == null) || (n_sospeso == DBNull.Value)) return false;
			string key = n_sospeso.ToString();
			if (__myNBill.ContainsKey(key))
				return true;

			string filtro = QHS.AppAnd(QHS.CmpEq("nbill", n_sospeso), QHS.CmpEq("ybill", Meta.GetSys("esercizio")),
				QHS.CmpEq("billkind", "D"));
			DataTable Bill = Conn.RUN_SELECT("bill", "*", null, filtro, null, true);
			if (Bill.Rows.Count == 0) return false;
			DataRow DefRow = Bill.Rows[0];
			__myNBill[key] = CfgFn.GetNoNullInt32(DefRow["nbill"]);
			return true;
		}


		Dictionary<string, int> __myidReg = new Dictionary<string, int>();

		private object GetAnagrafica(object denominazione_anagrafica) {
			if ((denominazione_anagrafica == null) || (denominazione_anagrafica == DBNull.Value)) return null;
			string key = denominazione_anagrafica.ToString();
			if (__myidReg.ContainsKey(key))
				return __myidReg[key];
			string filtro = QHS.AppAnd(QHS.CmpEq("title", denominazione_anagrafica), QHS.NullOrEq("active", "S"));

			DataTable Registry = Conn.RUN_SELECT("registry", "*", null, filtro, null, true);
			if (Registry.Rows.Count == 0) return null;
			DataRow DefRow = Registry.Rows[0];
			__myidReg[key] = CfgFn.GetNoNullInt32(DefRow["idreg"]);
			return __myidReg[key];
		}

		private void fillSospesi() {
			if (!VerificaFileSospesi(mData)) return;
			csa_bill_global.Clear();
			DataTable csa_bill = mData.Clone();
			csa_bill.Columns.Add("idreg", typeof(int));
			csa_bill.Columns.Remove("importo");
			csa_bill.Columns.Remove("N_SOSPESO");
			csa_bill.Columns.Add("amount", typeof(Decimal));
			csa_bill.Columns.Add("nbill", typeof(int));
			csa_bill.Columns.Add("motive", typeof(string));
			csa_bill.Columns.Add("datasospeso", typeof(DateTime));

			csa_bill.Columns["DENOMINAZIONE_ANAGRAFICA"].Caption = "Anagrafica";
			csa_bill.Columns["nbill"].Caption = "N. Sospeso";
			csa_bill.Columns["amount"].Caption = "Importo";
			csa_bill.Columns["motive"].Caption = "Causale";
			csa_bill.Columns["datasospeso"].Caption = "Data Sospeso";
			csa_bill.Columns["idreg"].Caption = ".#idreg";

			foreach (DataRow rFile in mData.Rows) {

				if (CfgFn.GetNoNullDecimal(rFile["importo"]) != 0) {
					var rSospeso = csa_bill.NewRow();
					rSospeso["DENOMINAZIONE_ANAGRAFICA"] = rFile["DENOMINAZIONE_ANAGRAFICA"];
					rSospeso["idreg"] = GetAnagrafica(rFile["DENOMINAZIONE_ANAGRAFICA"]);
					rSospeso["nbill"] = rFile["N_SOSPESO"];
					rSospeso["amount"] = CfgFn.GetNoNullDecimal(rFile["IMPORTO"]);
					rSospeso["motive"] = GetMotiveForNbill(rFile["N_SOSPESO"]);
					rSospeso["datasospeso"] = GetDateForNbill(rFile["N_SOSPESO"]);
					csa_bill.Rows.Add(rSospeso);
				}
			}

			DataSet dsSospesi = new DataSet();
			dsSospesi.Tables.Add(csa_bill);
			csa_bill.TableName = "csa_bill";
			dgrSospesi.DataBindings.Clear();
			dgrSospesi.DataSource = null;
			dgrSospesi.TableStyles.Clear();
			HelpForm.SetDataGrid(dgrSospesi, csa_bill);
			formatgrids fg = new formatgrids(dgrSospesi);
			fg.AutosizeColumnWidth();
			csa_bill_global = csa_bill;
		}

		private bool VerificaFileSospesi(DataTable mData) {
			bool ok = true;
			DataSet Out = new DataSet();
			DataTable T = new DataTable();
			T.Columns.Add("errors", typeof(System.String), "");
			for (int i = 0; i < tracciato_sospeso.Length; i++) {
				string fmt = tracciato_sospeso[i];
				bool datiValidi = GetField(fmt, T, mData);
				if (!datiValidi) ok = false;
			}

			Out.Tables.Add(T);

			if (!ok) {
				FrmViewError View = new FrmViewError(Out);
				View.Show();
			}

			return ok;
		}


		bool GetField(string tracciato_field, DataTable T, DataTable mData) {


			bool ok = true;
			string[] ff = tracciato_field.Split(';');
			string fieldname = ff[0].ToLower();

			int len = Convert.ToInt32(ff[3]);
			string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
			int rownum = 0;
			foreach (DataRow riga in mData.Select()) {
				string val = riga[fieldname].ToString().Trim();
				rownum++;
				switch (fieldname) {

					case "importo":

						if (CfgFn.GetNoNullDecimal(val) <= 0) {
							string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype +
							             " e di valore " +
							             val.Trim() + " alla riga " + rownum + ": inserire un importo maggiore di zero";
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}

						break;
					case "denominazione_anagrafica":
						if ((GetAnagrafica(val) == DBNull.Value) || (GetAnagrafica(val) == null)) {
							string err = "Anagrafica non trovata nella decodifica del campo " + fieldname +
							             " di tipo " + ftype + " e di valore " +
							             val.Trim() + " alla riga " + rownum;
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}

						break;
					case "n_sospeso":
						if (CheckSospeso(val) == false) {
							string err = "Sospeso di uscita non valido nella decodifica del campo " + fieldname +
							             " di tipo " + ftype + " e di valore " +
							             val.Trim() + " alla riga " + rownum;
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}

						break;
				}
			}

			return ok;
		}


		Dictionary<int, string> __billMotive = new Dictionary<int, string>();

		string GetMotiveForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billMotive.ContainsKey(n))
				return __billMotive[n];
			object motive = Conn.DO_READ_VALUE("bill",
				QHS.AppAnd(QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"),
					QHS.CmpEq("ybill", Meta.GetSys("esercizio"))), "motive");
			if (motive == null) {
				motive = "[sospeso numero " + nbill + "]";
			}

			__billMotive[n] = motive.ToString();
			return motive.ToString();
		}


		Dictionary<int, string> __billDate = new Dictionary<int, string>();

		object GetDateForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billDate.ContainsKey(n))
				return __billDate[n];
			object date = Conn.DO_READ_VALUE("bill",
				QHS.AppAnd(QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"),
					QHS.CmpEq("ybill", Meta.GetSys("esercizio"))), "adate");
			if (date == null) {
				date = "[data sospeso numero " + nbill + "]";
			}

			__billDate[n] = date.ToString();
			return date;
		}

		private bool interrogaFileExcel(string task) {
			mData.Clear();
			try {
				string fileName = openInputFileDlg.FileName;
				//ConnectionString = ExcelImport.ExcelConnString(fileName);
				ImpostaColonne(task);
				ReadCurrentSheet(fileName);
			}
			catch (Exception ex) {
				MessageBox.Show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
				return false;
			}

			return true;
		}

		/// <summary>
		/// legge i dati dal foglio di Excel a mData
		/// </summary>
		private void ReadCurrentSheet(string fileName) {
			try {
				lblTask.Text = "Apertura del file...Attendere";

				if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
					// con header
					ExcelImport x = new ExcelImport();
					//ConnectionString = ExcelImport.ExcelConnString(fileName);
					x.ImportTable(fileName, mData, true, 2);
				}

				lblTask.Text = "";
			}
			catch (Exception ex) {
				MessageBox.Show(this, ex.Message);
			}
		}



		private void ImpostaColonne(string kind) {

			mData.Columns.Clear();
			switch (kind) {
				case "S": {
					mData.Columns.Add("DENOMINAZIONE_ANAGRAFICA", typeof(string));
					mData.Columns.Add("N_SOSPESO", typeof(int));
					mData.Columns.Add("IMPORTO", typeof(decimal));
					break;
				}
			}
		}

		#endregion

		private void btnInputSospesi_Click(object sender, EventArgs e) {
			DialogResult dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK) {
				MessageBox.Show("Non è stato scelto alcun file");
				return;
			}

			string fileName = openInputFileDlg.FileName;

			if (!interrogaFileExcel("S")) {
				return;
			}

			fillSospesi();

		}

		private void btnDelSospesi_Click(object sender, EventArgs e) {
			dgrSospesi.DataBindings.Clear();
			dgrSospesi.DataSource = null;
			dgrSospesi.TableStyles.Clear();
		}

		private void dgrVersamentiAnnuali_MouseUp(object sender, MouseEventArgs e) {
			//Impedisce la multiselezione col mouse
			HelpForm.HelpForm_MouseUp(sender, e);
		}

		private void dgrVersamentiAnnuali_KeyUp(object sender, KeyEventArgs e) {
			//Impedisce la multiselezione da tastiera
			HelpForm.HelpForm_KeyUp(sender, e);
		}

		private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected) {
			foreach (DataRow R in RrowSelected)
				if (R == curr_rowgrid)
					return true;
			return false;

		}

		DataRow[] Ver_SelectedRowsbk;

		private void dgrVersamentiAnnuali_Paint(object sender, PaintEventArgs e) {
			/*
			if (dgrVersamentiAnnuali.DataMember == null || dgrVersamentiAnnuali.DataMember == "")
				return;
			//if (InsidePaintCP)
			//	return;
			//InsidePaintCP = true;
			int i;

			string TableName = dgrVersamentiAnnuali.DataMember.ToString();
			DataSet MyDS = (DataSet)dgrVersamentiAnnuali.DataSource;
			DataTable MyTable = MyDS.Tables[TableName];

			int numrighetemp = MyTable.Rows.Count;
			DataRow gridrow = null;

			// Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
			if (Ver_SelectedRowsbk == null)
				Ver_SelectedRowsbk = new DataRow[numrighetemp];

			for (i = 0; i < numrighetemp; i++) {
				if (dgrVersamentiAnnuali.IsSelected(i)) {
					gridrow = GetGridRow(dgrVersamentiAnnuali, i);
					//if (alreadyselected(gridrow, Ver_SelectedRowsbk))
					//	continue;
					SelectGridRowsIdemGroup(gridrow, dgrVersamentiAnnuali, true);
				}
				if (!(dgrVersamentiAnnuali.IsSelected(i))) {
					gridrow = GetGridRow(dgrVersamentiAnnuali, i);
					//if (!(alreadyselected(gridrow, Ver_SelectedRowsbk)))
					//	continue;
					//deve de-selezionare ciò che era selezionato
					SelectGridRowsIdemGroup(gridrow, dgrVersamentiAnnuali, false);
				}
			}

			Ver_SelectedRowsbk = GetGridSelectedRows(dgrVersamentiAnnuali);
			//InsidePaintCP = false;
			*/
		}
	}
}