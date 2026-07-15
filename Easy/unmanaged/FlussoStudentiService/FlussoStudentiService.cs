/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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

using ep_functions;
using funzioni_configurazione;
using meta_estimate;
using meta_estimatedetail;
using meta_flussocrediti;
using meta_flussocreditidetail;
using meta_income;
using meta_incomelast;
using meta_incomeyear;
using metadatalibrary;
using metaeasylibrary;
using movimentofunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using q = metadatalibrary.MetaExpression;

namespace FlussoStudentiService
{
    public class FlussoStudenti
    {
        private readonly IMessageLogger _logger;
		private readonly IUiOperations _uiOperations;
		private readonly IManageForm _manageForm;
		private IDataAccess _conn;
		private dsmeta DS;
		private QueryHelper _qhs;
		private CQueryHelper _qhc;
		private ISecurity _security;
		private IMetaDataDispatcher _dispatcher;
		private IFlussoStudentiPostData _fsPostData;
		//private IMetaData _meta;

		private int esercizio;

		private object _idsorkindSiopeE;
		private int _nphaseSiopeE;
		private string newcomputesorting;
		private int faseentratamax;
		private EP_functions epMain;

		private readonly Dictionary<string, object> _dateContrattoAttivo = new Dictionary<string, object>();
		private readonly Dictionary<string, string> _tipoContrattoAttivoCollegabileAFattura = new Dictionary<string, string>();
		private readonly Dictionary<string, string> _tipoContrattoAttivoGestioneDifferita = new Dictionary<string, string>();
		private readonly Dictionary<string, int> _vociBilancioEntrata = new Dictionary<string, int>();
		private readonly Dictionary<string, object> _upbManager = new Dictionary<string, object>();
		private readonly Dictionary<string, int> _accMotiveSiope = new Dictionary<string, int>();
		private readonly Dictionary<int, object> _sospesiAttivi = new Dictionary<int, object>();
		private Dictionary<int, string> __regTitles = new Dictionary<int, string>();
		private Dictionary<string, List<estimateRow>> righeContrattoAttivo = new Dictionary<string, List<estimateRow>>();
		private Dictionary<string, estimateRow> contrattoAttivoByKey = new Dictionary<string, estimateRow>();
		private Dictionary<string, string> __UpbTitles = new Dictionary<string, string>();
		private Dictionary<string, string> __EstimatekindTitles = new Dictionary<string, string>();

		// riempe la struttura dati GroupedInvoice da utilizzare per la successiva
		// eventuale generazione delle fatture raggruppate x idreg e per idinvkind
		private Dictionary<int, DataRow> registryByIdReg = new Dictionary<int, DataRow>();

		public FlussoStudenti(IDataAccess conn, IMessageLogger logger, IUiOperations uiOperations, IManageForm manageForm, ISecurity security, IMetaDataDispatcher dispatcher, IFlussoStudentiPostData fsPostData, int ayear)
        {
            _logger = logger;
			_conn = conn;
			_uiOperations = uiOperations;
			_manageForm = manageForm;
			esercizio = ayear;
			DS = new dsmeta {
				DataSetName = "vistaForm",
				EnforceConstraints = false,
				Locale = new System.Globalization.CultureInfo("en-US")
			};
			_qhs = _conn.GetQueryHelper();
			_qhc = new CQueryHelper();
			_security = security;
			_dispatcher = dispatcher;
			//_meta = _dispatcher.Get("no_table_flussostudenti"); //?????????????????

			_fsPostData = fsPostData;

			var filterEsercizio = _qhs.CmpEq("ayear", esercizio);
			//GetData.CacheTable(DS.license);
			//GetData.CacheTable(DS.config, filterEsercizio, null, false);
			//GetData.CacheTable(DS.estimatekind, null, "description", true);
			//GetData.CacheTable(DS.estimatekind, null, "description", true);

			//GetData.CacheTable(DS.finmotive);
			//GetData.CacheTable(DS.report);
			//GetData.CacheTable(DS.finmotivedetail, filterEsercizio, null, false);
			//GetData.CacheTable(DS.invoicekind, null, "idinvkind", true);
			//GetData.CacheTable(DS.ivakind, null, null, false);
			//GetData.CacheTable(DS.invoicekindregisterkind);

			_conn.RUN_SELECT_INTO_TABLE(DS.license, null, null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.config, null, filterEsercizio, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.estimatekind, "description", null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.finmotive, null, null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.report, null, null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.finmotivedetail, null, filterEsercizio, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.invoicekind, "idinvkind", null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.ivakind, null, null, null, false);
			_conn.RUN_SELECT_INTO_TABLE(DS.invoicekindregisterkind, null, null, null, false);

			faseentratamax = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));
			_idsorkindSiopeE = _conn.readValue("sortingkind", q.eq("codesorkind", "SIOPE_E_18"), "idsorkind");
			_nphaseSiopeE = CfgFn.GetNoNullInt32(_conn.readValue("sortingkind", q.eq("idsorkind", _idsorkindSiopeE), "nphaseincome"));

			epMain = new EP_functions(_dispatcher as Meta_EasyDispatcher);

			newcomputesorting = _conn.DO_READ_VALUE("siopekind", _qhs.AppAnd(_qhs.CmpEq("codesorkind_siopeentrate", _conn.GetSys("codesorkind_siopeentrate")),
					_qhs.CmpEq("ayear", CfgFn.GetNoNullInt32(_conn.GetSys("esercizio")))), "newcomputesorting")?.ToString();
		}

		#region AssociaBollette
		/// <summary>
		///  Per tutte le righe di flussoincassi associa il n. di sospeso attivo (nbill) se il sospeso ha la stessa causale della riga di 
		///  flussoincassi. Una riga di flusso incassi può essere associata ad un solo sospeso attivo, mentre un sospeso attivo
		///  può essere agganciato a più righe di flusso incassi
		/// </summary>
		public void AssociaEventualiBollette()
		{
			DoAssociaEventualiBollette();

			_logger.DisplayMessage();
		}

		private void DoAssociaEventualiBollette()
		{
			try
			{
				int annoCorrente = DateTime.Now.Year;
				int meseCorrente = DateTime.Now.Month;
				int giornoCorrente = DateTime.Now.Day;

				// Definisci gli esercizi su cui lavorare
				List<int> eserciziDaProcessare = new List<int>();

				// Se siamo tra il 1 e il 14 gennaio, lavora su due esercizi
				if (meseCorrente == 1 && giornoCorrente >= 1 && giornoCorrente <= 14)
				{
					if (annoCorrente == esercizio)
					{
						eserciziDaProcessare.Add(esercizio); // Esercizio corrente
						eserciziDaProcessare.Add(esercizio - 1); // Esercizio precedente
					}
					else
					{
						eserciziDaProcessare.Add(esercizio); // Solo esercizio, in quanto è stato indicato un esercizio specifico in configurazione
					}
				}
				else
				{
					eserciziDaProcessare.Add(esercizio); // Solo esercizio corrente
				}

				// Processa ogni esercizio
				foreach (int esercizioDaProcessare in eserciziDaProcessare)
				{
					ProcessaEsercizio(esercizioDaProcessare);
				}

			}
			catch (Exception Ex)
			{
				_logger.Error($"Errore durante l'esecuzione del servizio Elaborazione incassi: Associa Bollette: {Ex.Message}, {Ex.InnerException?.Message}");
			}
		}

		private void ProcessaEsercizio(int esercizioDaProcessare)
		{
			try
			{
				_logger.Info($"Elaborazione per esercizio {esercizioDaProcessare}");

				string sqlBill = BuildSqlQuery(esercizioDaProcessare);
				DataTable billFromCausali = _conn.SQLRunner(sqlBill, false, 0);

				if (billFromCausali.Rows.Count == 0)
				{
					_logger.Info($"La query su FilteredBill per esercizio {esercizioDaProcessare} non ha restituito dati");
					return;
				}

				var rows = DS.flussoincassi.getFromDb(_conn, q.eq("ayear", esercizioDaProcessare));

				ProcessRow(rows, billFromCausali);

				SaveChanges();
			}
			catch (Exception Ex)
			{
				_logger.Error($"Errore durante l'esecuzione del servizio Elaborazione incassi: Associa Bollette {esercizioDaProcessare}: {Ex.Message}, {Ex.InnerException?.Message}");
			}
		}

		private string BuildSqlQuery(int esercizioParam)
		{
			return $"  WITH FilteredBills AS( " +
				$"  SELECT " +
				$"	bill.nbill, " +
				$"	bill.ybill, " +
				$"	bill.adate, " +
				$"	bill.motive, " +
				$"	flussoincassi.causale, " +
				$"	flussoincassi.dataincasso " +
				$" FROM bill" +
				$" JOIN " +
				$"	flussoincassi ON ( " +
				$"		(bill.motive LIKE '%' + flussoincassi.causale + '%' AND flussoincassi.causale LIKE '%/PUR/LGPE-RIVERSAMENTO/URI/%') OR " +
				$"		(bill.motive LIKE '%/PUR/LGPE-RIVERSAMENTO/URI/' + flussoincassi.causale + '%') OR " +
				$"		(bill.motive LIKE '%/PUR/LGPE-RIVERSAMENTO/_/URI/' + flussoincassi.causale + '%') OR " +
				$"		(bill.motive LIKE '%' + flussoincassi.codiceflusso + '%') " +
				$"	) " +
				$" WHERE " +
				$"	flussoincassi.ayear = {esercizioParam}  " +
				$"	AND flussoincassi.nbill IS NULL " +
				$"	AND bill.billkind = 'C' " +
				$"	AND" +
				$"		(" +
				$"		bill.ybill = {esercizioParam} " +
				$"		OR (bill.ybill = {esercizioParam} +1 AND MONTH(bill.adate) = 1 AND DAY(bill.adate) <= 5)" +
				$"		OR  (bill.ybill = {esercizioParam} - 1 AND MONTH(bill.adate) = 12 ) " +
				$"		) " +
				$"		AND( " +
				$" bill.motive LIKE '%/PUR/LGPE-RIVERSAMENTO/URI/%' OR " +
				$" bill.motive LIKE '%/PUR/LGPE-RIVERSAMENTO/_/URI/%' OR " +
				$" bill.motive LIKE '%/PUR/LGPE-RIVERSAMENTO/TXT/0/URI/%'  " +
				$")  " +
				$" ) " +
				$" SELECT " +
				$"	nbill, " +
				$"	ybill, " +
				$"	adate, " +
				$"	causale " +
				$" FROM " +
				$"	FilteredBills " +
				$" WHERE " +
				$" ( " +
				$"	(FilteredBills.ybill = {esercizioParam}) " +
				$"	OR " +
				$"	(FilteredBills.ybill = {esercizioParam} + 1 AND MONTH(FilteredBills.dataincasso) = 12 AND DAY(FilteredBills.dataincasso) >= 25) " +
				$"	OR " +
				$"	(FilteredBills.ybill = {esercizioParam} - 1 AND MONTH(FilteredBills.adate) = 12 AND year(FilteredBills.dataincasso) = {esercizioParam} ) " +
				$" ) ";
		}

		private void ProcessRow(meta_flussoincassi.flussoincassiRow[] rows, DataTable billFromCausali)
		{
			Dictionary<string,int> nBillPerCausale = new Dictionary<string, int>();
			Dictionary<string,object> dataIncassoPerCausale = new Dictionary<string, object>();
			Dictionary<string, int> annoBillPerCausale = new Dictionary<string, int>();

			//_logger.Info("Valorizzazione dei dictionary");
			foreach (DataRow r in billFromCausali.Rows)
			{
				string causale = r["causale"].ToString();
				int nbill = CfgFn.GetNoNullInt32(r["nbill"]);

				if (!nBillPerCausale.ContainsKey(causale))
				{
					nBillPerCausale[causale] = nbill;
				}

				if (!dataIncassoPerCausale.ContainsKey(causale))
				{
					dataIncassoPerCausale[causale] = r["adate"];
				}

				int ybill = CfgFn.GetNoNullInt32(r["ybill"]);

				if (!annoBillPerCausale.ContainsKey(causale))
				{
					annoBillPerCausale[causale] = ybill;
				}
			}

			//_logger.Info("Associazione degli incassi alle bollette mediante causale bolletta");

			string associazioni = "";

			//var noChange = true;
			foreach (var r1 in rows)
			{
				// cerca di assegnare un sospeso attivo sulla base della causale
				var causale = r1.causale;
				if (string.IsNullOrEmpty(causale)) continue;

				if (nBillPerCausale.TryGetValue(causale, out int nBill))
				{
					r1.nbill = nBill;
					associazioni += $"{nBill} - {r1.idflusso}, ";
				}

				if (dataIncassoPerCausale.TryGetValue(causale, out object adate))
				{
					if (adate != DBNull.Value) r1.dataincassoValue = adate;
				}

				if (annoBillPerCausale.TryGetValue(causale, out int yBill))
				{
					r1.ayear = (short)yBill;
				}
			}

			if (string.IsNullOrEmpty(associazioni))
				_logger.Info("Non sono state effettuate associazioni");
			else
				_logger.Info($"Sono state fatte le seguenti associazioni: nbill - idflusso = [{associazioni.Remove(associazioni.Length - 2)}]");
		}

		private void SaveChanges()
		{
			//_logger.Info("Salvataggio...");

			if (!_fsPostData.runPostData(DS)) return;

			DS.flussoincassi.Clear();
						
			_logger.Info("Salvataggio Effettuato");

			return;
		}
		#endregion

		#region CreaIncassiContrattiAttivi
		/// <summary>
		/// Crea gli incassi per i contratti attivi, di cui possono esistere o meno gli accertamenti
		/// </summary>
		public void IncassiContrattiAttivi()
		{
			_uiOperations.SetControlVisibility("btnIncassiContrattiAttivi", false);
			_uiOperations.DoEvents();
			azzeraTutto();

			//DoAssociaEventualiBollette();
			//btnAssociaEventualiBollette_Click(sender, e);

			DataSet dSupdated;

			bool res = creaIncassiContrattiAttivi(!_uiOperations.GetChecked("chkAncheSenzaSospesi"));
			if (res && !DS.HasChanges())
			{
				ricalcolaFlagElaborato();
				azzeraTutto();
				_logger.Info("Nessun incasso da creare", true);
				_uiOperations.SetControlVisibility("btnIncassiContrattiAttivi", true);
				return;
			}

			//Ci sono movimenti da salvare
			if (res)
			{
				//Genera le scritture sui contratti attivi di cui nel dataset in memoria è stata impostata la data inizio di qualche dettaglio
				generaScrittureContrattiAttiviEsterno();

				//PostData.RemoveFalseUpdates(DS);
				//Il salvataggio azzera anche i movimenti finanziari
				if (DS.HasChanges())
				{
					if (doSave(out dSupdated))
					{//da qui esce fuori il messaggio  Dati Salvati
						_logger.Info("Gli incassi per i contratti attivi sono stati salvati.", true);
					}
				}
				else
				{
					_logger.Error("Errore nel salvataggio degli incassi per i contratti attivi");
					_uiOperations.SetControlVisibility("btnIncassiContrattiAttivi", true);
					return;
				}
			}

			azzeraTutto();
			_uiOperations.SetControlVisibility("btnIncassiContrattiAttivi", true);

			_logger.DisplayMessage();
		}

		
		/// <summary>
		/// Crea gli incassi per i contratti attivi, ed eventualmente anche gli accertamenti.
		/// Valorizza la data inizio per i dettagli contratto a generazione differita, imposta flagelaborato di flussoincassi ove necessario
		/// Non salva fisicamente i dati.
		/// </summary>
		/// <param name="soloConSospesi"></param>
		/// <returns></returns>
		private bool creaIncassiContrattiAttivi(bool soloConSospesi)
		{
			//Dictionary<int, decimal> flussoIncassiAmounts = new Dictionary<int, decimal>();

			initPBar("Inizializzazione calcolo incassi", 5);
			var filterNonElaborati = q.eq("ayear", esercizio) & q.eq("elaborato", "N") & q.eq("active", "S") & q.isNotNull("dataincasso");
			if (soloConSospesi) filterNonElaborati &= q.isNotNull("nbill");
			string daNumFlussoIncassi = _uiOperations.GetText("txtDaNumFlussoIncassi");
			string aNumFlussoIncassi = _uiOperations.GetText("txtANumFlussoIncassi");
			if ((daNumFlussoIncassi != "") && (aNumFlussoIncassi != ""))
			{
				int daNFlussoDato;
				int aNFlussoDato;
				if (int.TryParse(daNumFlussoIncassi, out daNFlussoDato) &&
					int.TryParse(aNumFlussoIncassi, out aNFlussoDato))
				{
					filterNonElaborati &= q.between("idflusso", daNFlussoDato, aNFlussoDato);
				}
			}

			if ((daNumFlussoIncassi != "") && (aNumFlussoIncassi == ""))
			{
				int nFlussoDato;
				if (int.TryParse(daNumFlussoIncassi, out nFlussoDato))
				{
					filterNonElaborati &= q.eq("idflusso", nFlussoDato);
				}
			}

			filterNonElaborati.cascadeSetTable("flussoincassi");

			string filterNonElaboratiSql = filterNonElaborati.toSql(_qhs, _conn) +
											   $" AND (flussoincassi.nbill is null or flussoincassi.nbill in (select nbill from bill where billkind='C' AND ybill={esercizio}) )";

			incPBar();

			string colonneDettCrediti = string.Join(",",
				(from c in DS.flussocreditidetail.Columns._names()
				 where QueryCreator.IsReal(DS.flussocreditidetail
						.Columns[c]) //& c!="barcodeimage" & c!="qrcodeimage"
				 select "flussocreditidetail." + c).ToArray());

			// Filtriamo la sicurezza in base al flussocrediti, campo idsor01
			// non riuscendo a filtrarla in modo efficace per UPB
			var condFlussoCrediti = _security.SelectCondition("flussocrediti", true).toMetaExpression();
			var joinFlussoCreditiSql = "";
			var condFlussoCreditiSql = "";
			if (condFlussoCrediti != null)
			{
				condFlussoCrediti.cascadeSetTable("flussocrediti");
				joinFlussoCreditiSql = " join flussocrediti on flussocreditidetail.idflusso = flussocrediti.idflusso ";
				condFlussoCreditiSql = " AND " + condFlussoCrediti.toSql(_qhs);
			}
			// Eseguo due query separate in base al match incasso/credito per IUV o IDUNIQUEFORMCODE ma mi aspetto che
			// siano pressochè equivalenti.  
			string sqlGetFlussiIncassiDaElaborare1  = $" SELECT DISTINCT FL1.idflusso " +
			" from flussocreditidetail " +
			joinFlussoCreditiSql +
			" JOIN flussoincassidetail  FL1 " +
			" ON   ( FL1.iuv = flussocreditidetail.iuv) " +
			" JOIN flussoincassi ON flussoincassi.idflusso= FL1.idflusso " +
			" WHERE flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
			" AND flussocreditidetail.nestim is not null " +
			" AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null " +
			" AND " + filterNonElaboratiSql +
			  condFlussoCreditiSql;

			// Eseguo due query separate in base al match incasso/credito per IUV o IDUNIQUEFORMCODE ma mi aspetto che
			// siano pressochè equivalenti.  
			string sqlGetFlussiIncassiDaElaborare2 = $" SELECT DISTINCT FL1.idflusso " +
			" from flussocreditidetail " +
			joinFlussoCreditiSql +
			" JOIN flussoincassidetail  FL1 " +
			" ON   (FL1.iduniqueformcode = flussocreditidetail.iduniqueformcode) " +
			" JOIN flussoincassi ON flussoincassi.idflusso= FL1.idflusso " +
			" WHERE flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
			" AND flussocreditidetail.nestim is not null " +
			" AND flussocreditidetail.stop is null AND flussocreditidetail.annulment is null " +
			" AND " + filterNonElaboratiSql +
			  condFlussoCreditiSql;
			// DataTable
			var idFlussiDaElaborare1 = _conn.SQLRunner(sqlGetFlussiIncassiDaElaborare1, false, 0); // per iuv 
			var idFlussiDaElaborare2 = _conn.SQLRunner(sqlGetFlussiIncassiDaElaborare2, false, 0); // per IDUNIQUEFORMCODE 

			if (idFlussiDaElaborare1.Rows.Count + idFlussiDaElaborare2.Rows.Count == 0)
			{
				_logger.Info($" Non ci sono Contratti attivi da incassare", true);
				return false;
			}

			string colonneFlussi = string.Join(",",
			(from c in DS.flussoincassi.Columns._names()
			 where QueryCreator.IsReal(DS.flussoincassi.Columns[c]) & c != "txt"
			 select "flussoincassi." + c).ToArray());

			var filterIdFlussi1 = q.fieldIn("idflusso", idFlussiDaElaborare1.Select()._Pick("idflusso").ToArray());

			string sqlGetFlussi1 = $@"  SELECT {colonneFlussi}
										FROM flussoincassi
										WHERE {filterIdFlussi1.toSql(_qhs, _conn)} ";

			// Leggo in memoria  tutti i dett. incassi e i flussi non elaborati filtrati indirettamente in accordo con la sicurezza 
			// dei relativi flussi crediti
			// Match per IUV
			DS.flussoincassi._sqlSafeMergeFromDb(_conn, sqlGetFlussi1, 0);
			DS.flussoincassidetail.readTableJoined(_conn, "flussoincassi", null, filterIdFlussi1, "idflusso");

			var filterIdFlussi2 = q.fieldIn("idflusso", idFlussiDaElaborare2.Select()._Pick("idflusso").ToArray());

			string sqlGetFlussi2 = $@"  SELECT {colonneFlussi}
										FROM flussoincassi
										WHERE {filterIdFlussi2.toSql(_qhs, _conn)} ";

			// Leggo in memoria  tutti i dett. incassi e i flussi non elaborati filtrati indirettamente in accordo con la sicurezza 
			// dei relativi flussi crediti
			// Match per IDUNIQUEFORMCODE
			DS.flussoincassi._sqlSafeMergeFromDb(_conn, sqlGetFlussi2, 0);
			DS.flussoincassidetail.readTableJoined(_conn, "flussoincassi", null, filterIdFlussi2, "idflusso");

			// Lettura dei dettagli flusso crediti 
			q filterCreditidetail = q.isNotNull("idestimkind")&q.isNotNull("nestim")
									&q.isNull("idinvkind")&q.isNull("stop")&q.isNull("annulment");
			filterIdFlussi1.cascadeSetTable("flussoincassidetail", "flussoincassi");
			filterIdFlussi2.cascadeSetTable("flussoincassidetail", "flussoincassi");

			// Estraggo una lista degli IUV/codici bollettino dei dettagli flussoincassi che sono stati letti in memoria
			// l'array se molto grande lo divido in liste più piccole
			var listaiuvDaIncassare = DS.flussoincassidetail.Select()._Pick("iuv").Distinct().ToArray();
			var listaCodiciDaIncassare= DS.flussoincassidetail.Select()._Pick("iduniqueformcode").Distinct().ToArray();

			// Estrai i dettagli crediti  corrispondenti ai dett.incassi, o per iuv o per iduniqueformcode - escludendo i crediti annullati e gli annullamenti

			// La lista degli IUV o dei bollettini da incassare potrebbe essere troppo lunga e generare delle Big Query con la clausola SQL IN(....).
			// la suddivido in tranches di 300 
			int size = 300;
			var listaIuvSplittatiArrays = listaiuvDaIncassare.Split(size);
			var listaCodiciSplittatiArrays = listaCodiciDaIncassare.Split(size);

			// Inizio la lettura in memoria dei dettagli flusso crediti per IUV
			// _sqlSafeMergeFromDb è il metodo che deve essere usato 
			int nPacchetti = listaIuvSplittatiArrays.Count();
			int nContatore = 0;

			foreach (var listaIuvSplittati in listaIuvSplittatiArrays)
			{
				var iuvList = _qhs.FieldIn("iuv", listaIuvSplittati.ToArray());
				nContatore++;

				string sqlGetCrediti = $@"  SELECT {colonneDettCrediti}
										FROM flussocreditidetail
										{joinFlussoCreditiSql}
										WHERE flussocreditidetail.idestimkind is not null 
										AND {iuvList}
										AND flussocreditidetail.nestim is not null 
										AND flussocreditidetail.idinvkind is null 
										AND flussocreditidetail.stop is null 
										AND flussocreditidetail.annulment is null
										{condFlussoCreditiSql} ";

				DS.flussocreditidetail._sqlSafeMergeFromDb(_conn, sqlGetCrediti, 0);
			}

			// Inizio la lettura in memoria dei dettagli flusso crediti per IDUNIQUEFORMCODE
			// _sqlSafeMergeFromDb è il metodo che deve essere usato 
			nContatore = 0;
			nPacchetti = listaCodiciSplittatiArrays.Count();
			foreach (var listaCodiciSplittati in listaCodiciSplittatiArrays)
			{
				var CodiciList = _qhs.FieldIn("iduniqueformcode", listaCodiciSplittati.ToArray());
				nContatore++;

				string sqlGetCrediti = $@"  SELECT {colonneDettCrediti}
										FROM flussocreditidetail
										{joinFlussoCreditiSql}
										WHERE flussocreditidetail.idestimkind is not null 
										AND {CodiciList}
										AND flussocreditidetail.nestim is not null 
										AND flussocreditidetail.idinvkind is null 
										AND flussocreditidetail.stop is null 
										AND flussocreditidetail.annulment is null
										{condFlussoCreditiSql} ";

				DS.flussocreditidetail._sqlSafeMergeFromDb(_conn, sqlGetCrediti, 0);
			}

			string colonneDettContratti = string.Join(",",
			(from c in DS.estimatedetail.Columns._names()
			 where QueryCreator.IsReal(DS.estimatedetail.Columns[c])
			 select "estimatedetail." + c).ToArray());

			string colonneContratti = string.Join(",",
				(from c in DS.estimate.Columns._names()
				 where QueryCreator.IsReal(DS.estimate.Columns[c]) & c != "txt"
				 select "estimate." + c).ToArray());

			// La lista dei bollettini da incassare potrebbe essere troppo lunga e generare delle Big Query con la clausola SQL IN(....).
			// La suddiviamo in blocchi di 300 per eseguire più query di lettura nel dataset relative a
			// Dettagli flusso crediti (flussocreditidetail)
			// Dettagli contratti attivi (estimatedetail)
			// Contratti attivi (estimate)
			// Accertamenti da incassare
			var listaCodiciCreditiDaSplittare = DS.flussocreditidetail.Select()._Pick("iduniqueformcode").Distinct().ToArray();
			var listaCodiciCreditiSplittatiArrays = listaCodiciCreditiDaSplittare.Split(size);
			var info = new infoCreaIncassi();
			nContatore = 0;
			nPacchetti = listaCodiciCreditiSplittatiArrays.Count();

			foreach (var listaCodiciSplittati in listaCodiciCreditiSplittatiArrays)
			{
				nContatore++;
				var iduniqueFormCodeList = _qhs.FieldIn("iduniqueformcode", listaCodiciSplittati.ToArray());
				var iduniqueFormCodeListq = q.fieldIn("iduniqueformcode",  listaCodiciSplittati.ToArray());

				//Estrae i dettagli contratti associati ai crediti in considerazione, prendendo tutti quelli aventi gli stessi iduniqueformcode esclusi i dett. annullati
				string sqlGetDetContratti = $@"SELECT {colonneDettContratti}
												FROM estimatedetail
												WHERE {iduniqueFormCodeList}
												and stop is null";
				DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlGetDetContratti, 0);

				//Estrae i dettagli contratti associati ai crediti in considerazione, prendendo tutti quelli aventi gli stessi iduniqueformcode esclusi i dett. annullati
				string sqlGetContratti = $@"SELECT {colonneContratti}
										FROM estimate
										WHERE
											EXISTS (
												SELECT * FROM estimatedetail
												WHERE estimate.idestimkind=estimatedetail.idestimkind
												AND estimate.yestim = estimatedetail.yestim
												AND estimate.nestim = estimatedetail.nestim
												AND {iduniqueFormCodeList}
												AND estimatedetail.stop is null
											)";
				DS.estimate._sqlSafeMergeFromDb(_conn, sqlGetContratti, 0);


				string sqlAccertamenti = $@"SELECT idinc, available
							FROM incometotal 
							JOIN estimatedetail ON incometotal.idinc= estimatedetail.idinc_taxable OR incometotal.idinc= estimatedetail.idinc_iva
							WHERE incometotal.ayear = {esercizio} 
							AND  {iduniqueFormCodeList}
							AND stop is null";
				var Incassi = _conn.SQLRunner(sqlAccertamenti, false, 0);
				foreach (DataRow r in Incassi.Rows)
				{
					info.availableByIdInc[CfgFn.GetNoNullInt32(r["idinc"])] = CfgFn.GetNoNullDecimal(r["available"]);
				}
				foreach (DataRow r in DS.estimate.Rows) addEstimateDateToDict(r);
			}
			incPBar();

			foreach (var r in DS.flussocreditidetail)
			{
				info.addDettFlussoCrediti(r);
			}

			foreach (var r in DS.flussoincassidetail)
			{
				info.addDettFlussoIncassi(r);
			}

			foreach (var r in DS.estimatedetail)
			{
				info.addDettContratto(r);
			}

			RowChange.SetOptimized(DS.income, true);
			RowChange.ClearMaxCache(DS.income);
			var msg = new List<messaggio>();
			bool res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.imponibile, info, msg);//non modifica la tabella flussoincassi
			if (res) res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.iva, info, msg);
			if (res) res = creaIncassiContrattiAttivi(soloConSospesi, TipoElaborazioneIncassi.totali, info, msg);

			foreach (var rFlusso in DS.flussoincassi.all())
			{
				var infoFlusso = info.flussoIncassiAmounts[rFlusso.idflusso];
				if (infoFlusso.importoFlusso == infoFlusso.sommaIncassi) rFlusso.elaborato = "S";//imposta elaborato=S di flussoincassi
			}

			if (res && msg.Count > 0)
			{
				List<string> txtMsg = new List<string>();
				foreach (var m in msg)
				{
					txtMsg.Add(m.error ? "Errore:" + m.msg : "Avviso:" + m.msg);
				}

				_logger.ShowMessage("Messaggi ottenuti nella creazione degli incassi", txtMsg);
			}

			return res;
		}

		/// <summary>
		///  Genera gli incassi di contratti attivi solo se non sono collegabili a fattura (in base alla configurazione del tipo contratto attivo).
		///  Infatti per quelli collegabili dovremo incassare le fatture. Non salva fisicamente i dati.
		/// </summary>
		/// <param name="conSospesi"></param>
		/// <param name="tipoElaborazione"></param>
		/// <param name="info"></param>
		/// <param name="messages"></param>
		/// <returns></returns>
		private bool creaIncassiContrattiAttivi(bool soloConSospesi, TipoElaborazioneIncassi tipoElaborazione, infoCreaIncassi info, List<messaggio> messages)
		{
			int faseentratamax = CfgFn.GetNoNullInt32(_conn.GetSys("maxincomephase")); // numero delle fasi di entrata

			var incInvoice = _dispatcher.Get("incomeinvoice"); //Contabilizzazione fattura
			incInvoice.SetDefaults(DS.incomeinvoice);

			// Questa funzione viene modificata allo scopo di leggere i dati da db includendo anche il pregresso

			var mov = DS.income;
			var impMov = DS.incomeyear;
			var impLast = DS.incomelast;

			var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
			var fasemassima = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));
			var faseinizio = fasecontratto + 1; //potrebbe essere maggiore di fase massima, attenzione!!
			var fasefine = fasemassima;

			var inc = _dispatcher.Get("income");
			var incY = _dispatcher.Get("incomeyear");
			var incL = _dispatcher.Get("incomelast");
			var incLD  = _dispatcher.Get("incomelastestimatedetail");

			bool monofase = (fasemassima == 1);

			inc.SetDefaults(DS.income);
			incY.SetDefaults(DS.incomeyear);
			incL.SetDefaults(DS.incomelast);

			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);

			var bollettiniElaborati = new Dictionary<string, bool>();
			var iuvElaborati = new Dictionary<string, bool>();
			var allRows = DS.flussoincassi.all();

			initPBar("Creazione contratti attivi - " + tipoElaborazione.ToString(), allRows.Count);

			//fattureDaCreare = new List<string>();
			foreach (var rFlussoIncassi in allRows)
			{ //DS.flussoincassi.Select()
				incPBar();
				_uiOperations.DoEvents();
				decimal sumIncassiContrattiAttivi = 0;
				if (!info.flussoIncassiAmounts.ContainsKey((int)rFlussoIncassi.idflusso))
				{
					info.flussoIncassiAmounts.Add((int)rFlussoIncassi.idflusso,
						new infoIncasso() {
							importoFlusso = CfgFn.GetNoNullDecimal(rFlussoIncassi.importo)
						});
				}

				// Verifica esistenza della bolletta su DB
				var nbill = rFlussoIncassi["nbill"];
				string errore;

				////Questo controllo ora è fatto a monte
				//if (soloConSospesi || nbill != DBNull.Value) {
				//	nbill = getSospesiAttivi(nbill, out errore);
				//	if (nbill == DBNull.Value) {
				//		// Non è stato creato ancora sul db mediante l'importazione del giornale di cassa
				//		continue;
				//	}
				//}

				var idflusso = rFlussoIncassi.idflusso;
				if (!info.dettFlussoIncassiPerIdFlusso.ContainsKey(idflusso)) continue;

				foreach (var rFileDet in info.dettFlussoIncassiPerIdFlusso[idflusso])
				{
					var iuv = rFileDet.iuv;
					if ((!string.IsNullOrEmpty(iuv)) && info.messaggioBollettinoMancante.ContainsKey(iuv))
					{
						continue;
					}
					//if (iuv == null) continue;
					// Prende i dettagli contratto attivo da incassare facendo una ricerca per codice bollettino univoco saltando i dettagli annullati
					List<flussocreditidetailRow> dettCrediti = null;
					if ((!string.IsNullOrEmpty(iuv)) && info.creditiPerIuv.ContainsKey(iuv))
					{
						dettCrediti = info.creditiPerIuv[iuv];
					}

					if ((!string.IsNullOrEmpty(rFileDet.iduniqueformcode)) && info.messaggioBollettinoMancante.ContainsKey(rFileDet.iduniqueformcode))
					{
						continue;
					}

					if ((dettCrediti == null) && (!string.IsNullOrEmpty(rFileDet.iduniqueformcode)) && info.creditiPerUniqueFormCode.ContainsKey(rFileDet.iduniqueformcode))
					{
						dettCrediti = info.creditiPerUniqueFormCode[rFileDet.iduniqueformcode];
					}

					if (dettCrediti == null)
					{
						//	//Questo messaggio ora va bene perchè non scatta se il credito c'è ma è collegato a fattura, e scatta se il credito non c'è proprio
						//	//aggiungere controllo per assicurare unicità messagggio
						messages.Add(new messaggio() {
							error = false,
							msg = $"E' stato trovato il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv} il cui credito manca o non è incassabile."
						});
						if (!string.IsNullOrEmpty(iuv)) info.messaggioBollettinoMancante[iuv] = true;
						if (!string.IsNullOrEmpty(rFileDet.iduniqueformcode)) info.messaggioBollettinoMancante[rFileDet.iduniqueformcode] = true;

						continue;
					}

					// Ciclo sui dettagli crediti a parità di codice bollettino
					foreach (var rCredito in dettCrediti)
					{
						//Salta tutti i crediti non associati a tipi c.attivi
						if (rCredito.idestimkind == null) continue;

						var codiceBollettino = rCredito.iduniqueformcode;
						if (string.IsNullOrEmpty(codiceBollettino)) continue;

						if (bollettiniElaborati.ContainsKey(codiceBollettino))
						{
							continue;
						}

						bollettiniElaborati.Add(codiceBollettino, true);

						// Leggo i dettagli contratto attivo da incassare facendo una ricerca per codice bollettino univoco
						//  salta i dettagli annullati
						List<estimatedetailRow> rows = null;
						if (info.dettContrattoPerUniqueFormCode.ContainsKey(codiceBollettino))
						{
							rows = info.dettContrattoPerUniqueFormCode[codiceBollettino];
						}

						if (rows == null) continue;
						//int faseInizioPerQuestoContratto = faseinizio;
						foreach (var rEstimDet in rows)
						{
							// Se il contratto attivo è di tipo collegabile a fattura lo salto
							string errori;

							var currUpb = rEstimDet.idupb;
							var currUpbIva = rEstimDet.idupb_iva;
							var idinc_Taxable = rEstimDet.idinc_taxable;
							var idinc_Iva = rEstimDet.idinc_iva;

							checkScadenzaUpb(currUpb, rEstimDet, messages);

							if (currUpb != currUpbIva)
								checkScadenzaUpb(currUpbIva, rEstimDet, messages);

							//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
							// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
							if ((rEstimDet.idfinmotive_iva != null) && (currUpb != null) && (currUpbIva == null))
							{
								currUpbIva = currUpb;
							}

							switch (tipoElaborazione)
							{
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null)
										continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									break;
								case TipoElaborazioneIncassi.imponibile:
									if (currUpb == null || currUpbIva == null)
										continue; //upb e upb_iva devono essere entrambi  valorizzati
									break;
								case TipoElaborazioneIncassi.iva:
									if (currUpb == null || currUpbIva == null)
										continue; //upb e upb_iva devono essere entrambi  valorizzati
									break;
							}

							decimal imponibile = CfgFn.GetNoNullDecimal(rEstimDet.taxable);
							decimal sconto = CfgFn.GetNoNullDecimal(rEstimDet.discount);
							decimal quantita = CfgFn.GetNoNullDecimal(rEstimDet.number);
							decimal imponibiletot = CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantita * (1 - sconto))));
							var iva = CfgFn.GetNoNullDecimal(rEstimDet.tax);

							decimal amountBase = 0;
							switch (tipoElaborazione)
							{
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									amountBase = imponibiletot + iva;
									break;
								case TipoElaborazioneIncassi.imponibile:
									// curUpbIva è sicuramente != null
									amountBase = imponibiletot;
									break;
								case TipoElaborazioneIncassi.iva:
									// curUpbIva è sicuramente != null
									amountBase = iva;
									break;
							}

							if (amountBase == 0) continue;

							// per i db monofase i dettagli contratto attivo incassati in una tornata precedente
							// devono essere dati per incassati 
							// per evitare di incassarli due volte
							if (monofase)
							{
								switch (tipoElaborazione)
								{
									case TipoElaborazioneIncassi.totali:
										if (idinc_Taxable != null)
										{
											sumIncassiContrattiAttivi += amountBase;
											continue; //
										}
										break;
									case TipoElaborazioneIncassi.imponibile:
										if (idinc_Taxable != null)
										{
											sumIncassiContrattiAttivi += amountBase;
											continue;
										}
										break;
									case TipoElaborazioneIncassi.iva:
										if (idinc_Iva != null)
										{
											sumIncassiContrattiAttivi += amountBase;
											continue;
										}
										break;
								}
							}

							var collegabileafattura = getCollegabileAFattura(rEstimDet.idestimkind);
							// Non dobbiamo incassare dettagli contratti attivi di tipo collegabile a fattura
							// perchè in tal caso dobbiamo incassare la fattura
							if (collegabileafattura)
							{
								continue;
							}

							var gestionedifferita = getGestioneDifferita(rEstimDet.idestimkind, out errori);
							var filterEstimate = q.mCmp(rEstimDet, "idestimkind", "yestim", "nestim");

							if (gestionedifferita == "S" || faseentratamax == 1)
							{
								//var estimateRows = DS.estimate.get(_conn, filterEstimate);	//INACCETTABILE, deve leggerli prima
								//foreach (var estimateRow in estimateRows) {
								//	addEstimateDateToDict(estimateRow);
								//}

								// Dobbiamo generare dalla prima fase di entrata
								var resFin = creaAccertamentiDaDettagliContrattiAttivi(new estimatedetailRow[] {rEstimDet}, tipoElaborazione, true);
								if (!resFin)
								{
									messages.Add(new messaggio() {
										error = true,
										msg = $"Errore nell'elaborazione della generazione dell'accertamento per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
									});
									_logger.Error($"Errore nell'elaborazione della generazione dell'accertamento per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}");
									closePBar();
									return false;
								}
								// Dato che entra in questo if anche quando gestionedifferita == "N" se monofase, allora verifico se devo aggiornare la data inizio
								// altrimenti mi duplica le scritture sul contratto attivo
								if (gestionedifferita == "S") rEstimDet["start"] = rFlussoIncassi["dataincasso"];
							}

							// Dettaglio contratto                        
							// Accertamento che contabilizza il dettaglio di importo pari a -importo
							var idincToAttach = tipoElaborazione == TipoElaborazioneIncassi.iva
								? rEstimDet["idinc_iva"]
								: rEstimDet["idinc_taxable"];
							if (idincToAttach == DBNull.Value)
							{
								messages.Add(new messaggio() {
									error = true,
									msg = $"Accertamento non trovato per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
								}
								);
								//show(
								//    $"Accertamento non trovato per il bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}",
								//    "Errore");
								continue;
							}

							//if (idincToAttach == DBNull.Value && gestionedifferita=="S") {
							//    faseInizioPerQuestoContratto = 1;
							//}
							int idincInt = CfgFn.GetNoNullInt32(idincToAttach);

							var fltmovI = q.eq("idinc", idincToAttach); //QHS.CmpEq("idinc", idincTaxable);
							incomeRow parentR = null;
							incomeyearRow parentYearR = null;
							if (info.incomeByIdInc.ContainsKey(idincInt))
							{
								parentR = info.incomeByIdInc[idincInt];
								if (!info.incomeYearByIdInc.ContainsKey(idincInt))
								{
									messages.Add(new messaggio() {
										error = true,
										msg = $"Nell'anno corrente non esiste l'imputazione del movimento {parentR["ymov"]}/{parentR["nmov"]} collegato al  bollettino di codice {rFileDet.iduniqueformcode} o iuv {iuv}"
									}
									);
									continue;
								}
								parentYearR = info.incomeYearByIdInc[idincInt];
							}
							else
							{
								if (CfgFn.GetNoNullInt32(idincToAttach) < 900000000)
								{
									object available = DBNull.Value;
									if (info.availableByIdInc.ContainsKey(CfgFn.GetNoNullInt32(idincToAttach)))
									{
										available = info.availableByIdInc[CfgFn.GetNoNullInt32(idincToAttach)];
									}
									else
									{
										available = _conn.readValue("incometotal", fltmovI & q.eq("ayear", esercizio), "available");
										info.availableByIdInc[CfgFn.GetNoNullInt32(idincToAttach)] = CfgFn.GetNoNullDecimal(available);
									}
									if (available != DBNull.Value && available != null)
									{
										if (CfgFn.GetNoNullDecimal(available) < amountBase)
										{
											//messages.Add(new messaggio() {
											//		error = false,
											//		msg =
											//			$"Il bollettino {codiceBollettino} risulta collegato ad un accertamento già incassato. Disponibile: {available} incasso: {amountBase}"
											//	}
											//);

											//show($"Il bollettino {codiceBollettino} risulta collegato ad un accertamento già incassato. Disponibile: {available} incasso: {amountBase}", "Avviso");
											continue;
										}
									}

								}

								// Cerco la riga di accertamento
								var movs = DS.income.get(_conn, fltmovI); //DS.income.mergeFromDb(_conn, fltmovI));
																		  //DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.income, null, fltmovI, null, true);
								var movYears =
									DS.incomeyear.get(_conn, fltmovI & q.eq("ayear", esercizio)); //mergeFromDb(_conn, fltmovI & q.eq("ayear", esercizio)); 
																								  //DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.incomeyear, null,QHS.AppAnd(fltmovI, QHS.CmpEq("ayear", _security.GetEsercizio())), null, true);

								//DS.income.Filter(fltmovI);
								//DS.incomeyear.Filter(fltmovI);
								if (movs.Length == 0) continue;
								if (movYears.Length == 0) continue;
								parentR = movs[0];
								info.incomeByIdInc[idincInt] = parentR;
								parentYearR = movYears[0];
								info.incomeYearByIdInc[idincInt] = parentYearR;
							}

							//per un monofase non entra mai qui dentro, genera le fasi dalla successiva all'accertamento all'ultima
							for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++)
							{
								mov.Columns["nphase"].DefaultValue = faseCorrente;
								//spostato sotto
								//var amount = CfgFn.GetNoNullDecimal(parentYearR.amount);

								// Selezione UPB e Voce di Bilancio in modo completamente automatico
								object idUpbSelected;
								object idmanagerSelected;

								// Determinazione del capitolo di bilancio in base alla causale finanziaria impostata sul dettaglio
								object idfinSelected = DBNull.Value;
								if (fasebilancio < faseinizio)
								{
									idUpbSelected = parentYearR.idupb;
									idfinSelected = parentYearR.idfin;
									idmanagerSelected = (object)parentR.idman ?? DBNull.Value;
								}
								else
								{
									idUpbSelected = (tipoElaborazione == TipoElaborazioneIncassi.iva)
										? rEstimDet.idupb_iva
										: rEstimDet.idupb;
									idmanagerSelected =
										getUpbManager(idUpbSelected,
											out errore); //_conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");

									var idfinCurr = getBilancioFromCausaleFin(rEstimDet.idfinmotive, out errore);
									string erroreiva;
									var idfinCurr_iva = getBilancioFromCausaleFin(rEstimDet.idfinmotive_iva, out erroreiva);
									idfinSelected = idfinCurr;
									if (rEstimDet.idfinmotive_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva && idfinCurr_iva != null)
									{
										idfinSelected = idfinCurr_iva;
									}

									if (errore != "")
									{
										messages.Add(new messaggio() {
											error = true,
											msg = errore
										}
										);
										_logger.Error(errore);
										return false;
									}
								}

								var newEntrataRow = inc.Get_New_Row(parentR, mov) as incomeRow;

								fillMovimento(newEntrataRow, idmanagerSelected, (object)parentR.idreg ?? DBNull.Value,
									parentR.description);

								newEntrataRow.doc =
									$"C.A.{rEstimDet.idestimkind}/{rEstimDet.yestim.ToString().Substring(2, 2)}/{rEstimDet.nestim.ToString().PadLeft(6, '0')}";

								if (gestionedifferita == "S")
								{ // 19530 in tal caso accertamenti e incassi sono contestuali
									newEntrataRow.docdate = rFlussoIncassi.dataincasso;
								}
								else
								{ //negli altri casi lo valorizziamo con la data contabile del contratto attivo
									var aDate = getDateContrattoAttivo(rEstimDet, out errore); //_conn.readValue("estimate", q.mCmp(rDet, "idestimkind", "yestim", "nestim"), "adate");
									newEntrataRow["docdate"] = aDate ?? DBNull.Value;
								}
								newEntrataRow.nphase = Convert.ToByte(faseCorrente);

								var newImpMov = impMov.NewRow() as incomeyearRow;

								fillImputazioneMovimento(newImpMov, amountBase, idfinSelected, idUpbSelected);

								newImpMov.idinc = newEntrataRow.idinc;
								newImpMov.ayear = Convert.ToInt16(esercizio);

								impMov.Rows.Add(newImpMov);

								object idsor_siopeivavendita = null;
								DataTable Tconfig = _conn.RUN_SELECT("config", "*", null, _qhs.CmpEq("ayear", _conn.GetSys("esercizio")), null, true);
								if (Tconfig.Rows.Count > 0)
								{
									idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
								}

								if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S")
								{
									object idsor = null;
									if ((tipoElaborazione == TipoElaborazioneIncassi.iva) && (idsor_siopeivavendita != null))
									{
										//Legge il siope da config
										idsor = idsor_siopeivavendita;
									}
									// Classificazione SIOPE impostata su documento
									if (idsor == DBNull.Value || idsor == null)
									{
										idsor = rEstimDet["idsor_siope"];
									}
									//Altrumenti leggo class SIOPE impostata sulla causale di ricavo
									if (idsor == DBNull.Value || idsor == null)
										idsor = getSiopeForAccMotive(rEstimDet["idaccmotive"], out errori);
									fillIncomeSorted(newEntrataRow, idsor, amountBase);
								}

								parentR = newEntrataRow;
							} // Fasi


							//Aggiunge le informazioni di ultima fase
							var newLastMov = incL.Get_New_Row(parentR, impLast) as incomelastRow;
							// aggiunge le informazioni sul numero bolletta se sono state specificate nel flusso 
							if (nbill != DBNull.Value)
							{
								newLastMov.nbill = (int)nbill;
								var flag = CfgFn.GetNoNullInt32(newLastMov.flag);
								flag |= 1;
								newLastMov.flag = Convert.ToByte(flag);
							}

							newLastMov.idinc = parentR.idinc;
							// sui db monofase non è necessaria la gestione della tabella incomelastestimatedetail
							// perchè non è utile alla generazione delle scritture di chiusura credito
							// in sede di trasmissione
							if ((tipoElaborazione != TipoElaborazioneIncassi.iva) &&
								(faseentratamax != 1)) /*non monofase*/
							{
								//Aggiunge la riga di incasso per i contratti attivi
								foreach (DataColumn c in DS.estimatedetail.PrimaryKey)
									DS.incomelastestimatedetail.Columns[c.ColumnName].DefaultValue =
										rEstimDet[c.ColumnName];
								var incassoDet = incLD.Get_New_Row(parentR, DS.incomelastestimatedetail);
								incassoDet["amount"] = amountBase;
							}

							object idacc = DBNull.Value;

							if (epMain.attivo)
							{
								//Deve farle prima queste letture
								var estimateRows = DS.estimate.get(_conn, filterEstimate);
								if (estimateRows.Length > 0)
								{
									var idaccmotive = estimateRows[0].idaccmotivecredit;
									idacc = epMain.GetCustomerAccountForRegistry(idaccmotive, parentR.idreg);
									if (idacc != DBNull.Value)
									{
										newLastMov.idacccredit = (string)idacc;
									}
								}
							}

							sumIncassiContrattiAttivi += amountBase;
						} //dettagli contratto attivo
					} //Dettaglio crediti

				} //dettaglio incassi

				//test effettuato alla conclusione delle tre chiamate
				//if (rFlussoIncassi.importo == sumAmountContrattiAttivi) {
				//    rFlussoIncassi.elaborato = "S";
				//}
				info.flussoIncassiAmounts[(int)rFlussoIncassi.idflusso].sommaIncassi += sumIncassiContrattiAttivi;
			} //flusso incassi
			closePBar();
			return true;
		}

		private void checkScadenzaUpb(string idupb, estimatedetailRow rEstimDet, List<messaggio> messages)
		{
			if (idupb != null)
			{
				DataTable dtUpb = _conn.RUN_SELECT("upb", "*", null, _qhs.CmpEq("idupb", idupb), null, false);

				if (dtUpb.Rows.Count == 0)
					return;

				DataRow rUpb = dtUpb.Rows[0];

				if (rUpb.IsNull("expiration"))
					return;

				if (!DateTime.TryParse(rUpb["expiration"].ToString(), out DateTime upbScadenza))
					return;
				
				if (upbScadenza < DateTime.Now)
				{
					string msg = $"Attenzione: L'UPB {rUpb["codeupb"]} è scaduta in data {upbScadenza:dd/MM/yyyy}, " +
								 $"è stata utilizzata nel contratto attivo {rEstimDet.idestimkind} {rEstimDet.nestim}/{rEstimDet.yestim} " +
								 $"dettaglio num. {rEstimDet.rownum}.";

					bool messaggioEsistente = messages.Exists(m => string.Equals(m.msg, msg, StringComparison.OrdinalIgnoreCase));

					if (!messaggioEsistente)
					{
						messages.Add(new messaggio() {
							error = false,
							msg = msg
						});
					}
				}
			}
		}
				
		private bool getCollegabileAFattura(object idestimkind)
		{
			if (idestimkind == DBNull.Value || idestimkind == null) return true;
			var sIdEstimKind = idestimkind.ToString();

			if (_tipoContrattoAttivoCollegabileAFattura.ContainsKey(sIdEstimKind))
				return _tipoContrattoAttivoCollegabileAFattura[sIdEstimKind].ToString() == "S";

			var linktoinvoice = _conn.readValue("estimatekind", q.eq("idestimkind", idestimkind), "linktoinvoice");
			if (linktoinvoice == null || linktoinvoice == DBNull.Value)
			{
				_logger.Error($"Il tipo contratto attivo  {sIdEstimKind} non è stato trovato");
				return false;
			}

			_tipoContrattoAttivoCollegabileAFattura[sIdEstimKind] = linktoinvoice.ToString().ToUpper();
			return _tipoContrattoAttivoCollegabileAFattura[sIdEstimKind].ToString() == "S";
		}

		/// <summary>
		/// Stabilisce se idestimkind è un tipo contratto a gestione differita
		/// </summary>
		/// <param name="idestimkind"></param>
		/// <param name="errori"></param>
		/// <returns></returns>
		private string getGestioneDifferita(object idestimkind, out string errori)
		{
			errori = "";
			//if (faseentratamax == 1)
			//	return "S"; //assumiamo che se monofase allora si contabilizza sempre solo in fase di incasso
			if (idestimkind == DBNull.Value || idestimkind == null) return "S";
			string sIdEstimKind = idestimkind.ToString();
			if (_tipoContrattoAttivoGestioneDifferita.ContainsKey(sIdEstimKind))
				return _tipoContrattoAttivoGestioneDifferita[sIdEstimKind];

			var oFlag = _conn.readValue("estimatekind", q.eq("idestimkind", idestimkind), "flag");
			if (oFlag == null || oFlag == DBNull.Value)
			{
				errori = $"Il tipo contratto attivo  {idestimkind} non è stato trovato";
				return "N";
			}

			var flag = CfgFn.GetNoNullInt32(oFlag);
			var differita = CfgFn.DecodeToString(flag, 1);
			_tipoContrattoAttivoGestioneDifferita[sIdEstimKind] = differita;
			return differita;
		}

		private void addEstimateDateToDict(DataRow estim)
		{
			string estimKey = QueryCreator.hashColumns(estim, new[] {"idestimkind", "yestim", "nestim"});
			_dateContrattoAttivo[estimKey] = estim["adate"];
		}

		/// <summary>
		/// Stabilisce se idestimkind è un tipo contratto a gestione differita
		/// </summary>
		/// <param name="idestimkind"></param>
		/// <param name="errori"></param>
		/// <returns></returns>
		private object getDateContrattoAttivo(DataRow estimDetail, out string errori)
		{
			errori = "";
			string estimKey = QueryCreator.hashColumns(estimDetail, new[] {"idestimkind", "yestim", "nestim"});
			if (_dateContrattoAttivo.ContainsKey(estimKey)) return _dateContrattoAttivo[estimKey];

			var oDate = _conn.readValue("estimate", q.mCmp(estimDetail, "idestimkind", "yestim", "nestim"), "adate");
			if (oDate == null || oDate == DBNull.Value)
			{
				errori = $"Il  contratto attivo  {estimKey} non è stato trovato o non ha la data contabile";
				return null;
			}

			_dateContrattoAttivo[estimKey] = oDate;
			return oDate;
		}
		
		private object getUpbManager(object idUpb, out string errori)
		{
			errori = "";
			if (idUpb == DBNull.Value || idUpb == null)
			{
				errori = "UPB non trovato";
				return DBNull.Value;
			}

			if (_upbManager.ContainsKey(idUpb.ToString())) return _upbManager[idUpb.ToString()];

			var idMan = _conn.readValue("upb", q.eq("idupb", idUpb), "idman");
			if (idMan == null)
			{
				errori = $"UPB avente id {idUpb} non trovato";
				return DBNull.Value;
			}

			_upbManager[idUpb.ToString()] = idMan;
			return _upbManager[idUpb.ToString()];
		}

		private void fillMovimento(DataRow eS, object idman, object idreg, string description)
		{
			if (idreg == null) idreg = DBNull.Value;
			if (idman == null) idman = DBNull.Value;

			var dataCont = _security.GetDataContabile();
			eS.BeginEdit();
			eS["ymov"] = esercizio;
			eS["adate"] = dataCont;
			eS["idman"] = idman;
			//E_S["idunderwriting"] = idunderwriting;
			eS["idreg"] = idreg;
			eS["description"] = description;
			//E_S["amount"]=CfgFn.RoundValuta(amount);
			eS.EndEdit();
		}

		private void fillImputazioneMovimento(DataRow impMov, decimal amount, object idfin, object idupb)
		{
			impMov["amount"] = amount;
			impMov["idfin"] = idfin;
			impMov["idupb"] = idupb;
		}

		private int? getSiopeForAccMotive(object idaccmotive, out string errori)
		{
			errori = "";

			if (idaccmotive == DBNull.Value || idaccmotive == null)
			{
				errori = " La causale di Ricavo non è stata specificata";
				return null;
			}

			var sIdAccMotive = idaccmotive.ToString();
			if (_accMotiveSiope.ContainsKey(idaccmotive.ToString())) return _accMotiveSiope[sIdAccMotive];
			if (!SiopeE_obbligatorio()) return null;

			var idsor = _conn.readValue("accmotivesortingview",
				q.eq("idaccmotive", sIdAccMotive) & q.eq("idsorkind", _idsorkindSiopeE), "idsor");
			if (idsor == null || idsor == DBNull.Value)
			{
				string codeMotive = _conn.readValue("accmotive", q.eq("idaccmotive", idaccmotive), "codemotive")
					?.ToString();
				errori = " La causale di Ricavo " + (codeMotive ?? "") +
						 " deve essere associata a un codice SIOPE. E' necessario completare la configurazione.";
				return null;
			}

			_accMotiveSiope[sIdAccMotive] = CfgFn.GetNoNullInt32(idsor);
			return _accMotiveSiope[sIdAccMotive];
		}

		bool SiopeE_obbligatorio()
		{
			int flag = CfgFn.GetNoNullInt32(_conn.DO_READ_VALUE("sortingkind",_qhs.CmpEq("codesorkind", "SIOPE_E_18"), "flag"));
			if ((flag & 1) == 0) return false;// SIOPE non obbligatorio
			return true;// SIOPE obbligatorio
		}

		private void fillIncomeSorted(DataRow newMovRow, object idsor, decimal amount)
		{
			if (idsor == DBNull.Value || idsor == null) return;

			var metaSortedMov = _dispatcher.Get("incomesorted");
			metaSortedMov.SetDefaults(DS.incomesorted);
			DS.Tables["incomesorted"].Columns["idsor"].DefaultValue = idsor;
			var sortedMovRow = metaSortedMov.Get_New_Row(newMovRow, DS.incomesorted);
			sortedMovRow["idsor"] = idsor;
			sortedMovRow["amount"] = amount;
			sortedMovRow["idinc"] = newMovRow["idinc"];
			sortedMovRow["ayear"] = esercizio;
			sortedMovRow["cu"] = "import";
			sortedMovRow["ct"] = DateTime.Now;
			sortedMovRow["lu"] = "import";
			sortedMovRow["lt"] = DateTime.Now;
		}

		void ricalcolaFlagElaborato()
		{
			initPBar("Ricalcolo flag elaborato flusso incassi", DS.flussoincassi.Rows.Count);
			//var someThingDone = false;
			StringBuilder sb = new StringBuilder();
			foreach (var flusso in DS.flussoincassi)
			{
				incPBar();
				sb.AppendLine($"exec compute_flussoincassiflagelaborato {esercizio},{flusso.idflusso}");
				if (sb.Length > 10000)
				{
					_conn.SQLRunner(sb.ToString());
					sb.Clear();
				}
			}

			if (sb.Length > 0)
			{
				_conn.SQLRunner(sb.ToString());
			}
			closePBar();
		}

		/// <summary>
		/// Genera le scritture sui contratti attivi di cui nel dataset in memoria è stata impostata la data inizio di qualche dettaglio
		/// </summary>
		public void generaScrittureContrattiAttiviEsterno()
		{
			var ext = DS.Clone();
			foreach (string table in new[] { "estimate", "estimatedetail" })
			{
				ext.Tables[table].Merge(DS.Tables[table]);//preserva i cambiamenti delle righe modificate
			}

			var contractToGenerate = new Dictionary<string, bool>();
			foreach (var rEstim in DS.estimate)
			{
				contractToGenerate[hashActiveContract(rEstim)] = false;
			}

			foreach (DataRow r in ext.Tables["estimatedetail"].Select())
			{
				if (r.RowState == DataRowState.Added)
				{
					continue;//non dovrebbe passare da qui no??
				}

				if (r.RowState != DataRowState.Modified)
				{
					//Questi li lascio stare perchè servono ai fini delle scritture eventuali
					//ext.Tables["estimatedetail"].Rows.Remove(r);
					if (r.RowState != DataRowState.Unchanged)
					{
						r.RejectChanges();
					}
					continue;
				}

				//Questi li lascio stare perchè servono ai fini delle scritture eventuali
				//if (r["start", DataRowVersion.Original] != DBNull.Value) { //era già stato generato
				//	ext.Tables["estimatedetail"].Rows.Remove(r);
				//	continue;
				//}

				if (r["start", DataRowVersion.Current] == DBNull.Value)
				{
					r.RejectChanges();  //non imposta ancora il movimento collegato ma lascia newStart a null
										//ext.Tables["estimatedetail"].Rows.Remove(r); saltiamo quelle con start null
					continue;
				}

				//prende solo le righe di cui è stato ora impostato lo start

				object newStart = r["start"];
				r.RejectChanges();  //non imposta ancora il movimento collegato ma lascia newStart
				r["start"] = newStart;
				contractToGenerate[hashActiveContract(r)] = true;
			}

			ext.Tables["estimate"].RejectChanges();

			//ext.Tables["flussoincassi"].RejectChanges();//non salva ancora flussoincassi, non serve tanto la tabella non è stata riportata in ext

			var metaEstimate = _dispatcher.Get("estimate");
			metaEstimate.DS = ext;

			var estimateSkipped = new List<string>();
			if (ext.Tables["estimate"].Rows.Count > 0)
			{
				if (!_fsPostData.runPostData(ext)) return;

				foreach (DataRow rEstim in ext.Tables["estimate"].Rows)
				{
					ext.Tables["estimatedetail"]._safeMergeFromDb(_conn, q.keyCmp(rEstim));
					if (!contractToGenerate[hashActiveContract(rEstim)]) continue;
					var epm = new EP_Manager(metaEstimate, null, null, null, null, null, null, null, null, "estimate");
					epm.disableIntegratedPosting();
					epm.silent = true;
					epm.autoIgnore = true;
					epm.setForcedCurrentRow(rEstim);
					epm.afterPost(true); //potrebbe modificare estimatedetail (idepacc..) ma al momento abbiamo verificato che non tocca lt/lu

					if (epm.ultimaGenerazioneRiuscita == false)
					{
						estimateSkipped.Add(descrContrattoAttivo(rEstim));
						//Sarebbe il caso di non salvare questo contratto ma non è semplice
					}

					epm.Dispose();

					//Sistema il valore della riga originale
					//non credo sia necessario -->in realtà lo sarebbe ma usando la nuova classe Easy_PostData_NoBLNoTimeStamp non lo è più

				}
			}

			if (estimateSkipped.Count > 0)
			{
				_logger.ShowMessage("Contratti attivi da rivedere", "Per i seguenti contratti attivi non sono state generati movimenti di budget e/o scritture E/P", estimateSkipped);
			}
		}

		private string hashActiveContract(DataRow r)
		{
			return $"{r["idestimkind"]}§{r["yestim"]}§{r["nestim"]}";
		}

		private string descrContrattoAttivo(DataRow r)
		{
			return $"{r["idestimkind"]}/{r["yestim"]}/{r["nestim"]}";
		}
		
		private void viewAutomatismi(DataSet ds)
		{
			string filterEntrata = null;
			if (ds.Tables["income"] != null)
			{
				var var = ds.Tables["income"];
				var rr = ds.Tables["income"].Select();
				if (rr.Length == 0) return;
				if (rr.Length > 100) return;
				filterEntrata = _qhs.FieldIn("idinc", rr, "idinc");
			}

			_manageForm.showAutomatismi();

			//Form F = ShowAutomatismi.Show(_meta as MetaData, null, filterEntrata, null, null);
			//if (F != null)
			//{
			//	createForm(F, null);
			//	F.ShowDialog();
			//}
		}

		#endregion

		#region CreaAccertamentiIncassiFatture
		public void CreaIncassiFatture()
		{
			string error;
			if (!generaIncassiFatture(!_uiOperations.GetChecked("chkAncheSenzaSospesi"), out error))
			{
				_logger.Error("Errore nel salvataggio incassi per le fatture" + "\r\n" + error);
			}

			azzeraTutto();

			_logger.DisplayMessage();
		}

		private bool generaIncassiFatture(bool soloConSospesi, out string error)
		{
			error = "";
			DataSet dSupdated;

			azzeraMovimentiFinanziariEntrata();

			bool res = creaIncassiFatture(soloConSospesi);
			if (!res)
			{
				error = " (Crea Incassi Fatture)";
				return false;
			}
			PostData.RemoveFalseUpdates(DS);

			if (res && !DS.HasChanges())
			{
				_logger.Info("Nessun incasso da generare", true);
			}

			if (res && DS.HasChanges())
			{
				if (doSave(out dSupdated))
				{//da qui esce fuori il messaggio  Dati Salvati
					_logger.Info("Gli incassi per le fatture sono stati generati", true);
				}
			}

			azzeraTutto();

			return res;
		}

		private void azzeraMovimentiFinanziariEntrata()
		{
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
		}

		private bool creaIncassiFatture(bool soloConSospesi)
		{
			initPBar("Inizializzazione creazione incassi per fatture", 2);
			azzeraTutto();

			var filterNonElaborati = q.eq("ayear", esercizio) & q.eq("elaborato", "N") & q.eq("active", "S") ;
			if (soloConSospesi) filterNonElaborati &= q.isNotNull("nbill");
			string daNumFlussoIncassi = _uiOperations.GetText("txtDaNumFlussoIncassi");
			string aNumFlussoIncassi = _uiOperations.GetText("txtANumFlussoIncassi");
			if ((daNumFlussoIncassi != "") && (aNumFlussoIncassi != ""))
			{
				int daNFlussoDato;
				int aNFlussoDato;
				if (int.TryParse(daNumFlussoIncassi, out daNFlussoDato) &&
					int.TryParse(aNumFlussoIncassi, out aNFlussoDato))
				{
					filterNonElaborati &= q.between("idflusso", daNFlussoDato, aNFlussoDato);
				}
			}

			if ((daNumFlussoIncassi != "") && (aNumFlussoIncassi == ""))
			{
				int nFlussoDato;
				if (int.TryParse(daNumFlussoIncassi, out nFlussoDato))
				{
					filterNonElaborati &= q.eq("idflusso", nFlussoDato);
				}
			}

			filterNonElaborati.cascadeSetTable("flussoincassi");

			// filtriamo la sicurezza anche in base al flussocrediti, campo idsor01
			var condFlussoCrediti = _security.SelectCondition("flussocrediti", true).toMetaExpression();
			var joinFlussoCreditiSql = "";
			var condFlussoCreditiSql = "";
			if (condFlussoCrediti != null)
			{
				condFlussoCrediti.cascadeSetTable("flussocrediti");
				joinFlussoCreditiSql = " join flussocrediti on flussocreditidetail.idflusso = flussocrediti.idflusso ";
				condFlussoCreditiSql = " AND " + condFlussoCrediti.toSql(_qhs);
			}

			string sqlGetFlussiIncassiDaElaborare = $" SELECT FL1.idflusso" +
				" from flussocreditidetail " +
				joinFlussoCreditiSql +
				" JOIN flussoincassidetail  FL1 " +
				" ON   FL1.iuv = flussocreditidetail.iuv " +
				" JOIN flussoincassi ON flussoincassi.idflusso= FL1.idflusso " +
				" WHERE flussocreditidetail.idestimkind is null AND flussocreditidetail.idinvkind is not null " +
				" AND flussocreditidetail.stop is null and flussocreditidetail.annulment is null " +
				" AND flussoincassi.idflusso is not null " +
				" AND " + filterNonElaborati.toSql(_qhs) +
				 condFlussoCreditiSql +
				" UNION " +
				" SELECT FL1.idflusso" +
				" from flussocreditidetail " +
				joinFlussoCreditiSql +
				" JOIN flussoincassidetail  FL1 " +
				" ON   FL1.iduniqueformcode = flussocreditidetail.iduniqueformcode " +
				" JOIN flussoincassi ON flussoincassi.idflusso= FL1.idflusso " +
				" WHERE flussocreditidetail.idestimkind is null AND flussocreditidetail.idinvkind is not null " +
				" AND flussocreditidetail.stop is null and flussocreditidetail.annulment is null " +
				" AND flussoincassi.idflusso is not null " +
				" AND " + filterNonElaborati.toSql(_qhs) +
				 condFlussoCreditiSql
				;

			var idFlussiDaElaborare = _conn.SQLRunner(sqlGetFlussiIncassiDaElaborare, false, 0);

			if (idFlussiDaElaborare.Rows.Count == 0)
			{
				_logger.Info($" Non ci sono Flussi da incassare", true);
				closePBar();
				return true;
			}
			string lista_idListing = _qhc.DistinctVal(idFlussiDaElaborare.Select(), "idflusso");
			string FF = _qhs.FieldInList("idlist", lista_idListing);

			var filterIdFlussi = q.fieldIn("idflusso", idFlussiDaElaborare.Select()._Pick("idflusso").ToArray());
			DS.flussoincassi.mergeFromDb(_conn, filterIdFlussi);
			DS.flussoincassidetail.readTableJoined(_conn, "flussoincassi", null, filterIdFlussi, "idflusso");

			var info = new infoCreaIncassi();
			foreach (var r in DS.flussoincassidetail)
			{
				info.addDettFlussoIncassi(r);
			}

			string colonneDettFature = string.Join(",",
				(from c in DS.invoicedetail.Columns._names()
				 where QueryCreator.IsReal(DS.invoicedetail.Columns[c])
				 select "invoicedetail." + c).ToArray());

			string sqlGetFatture =
				$" SELECT  {colonneDettFature} from invoicedetail where iduniqueformcode in (" +
				$" SELECT flussocreditidetail.iduniqueformcode from flussocreditidetail " +
				//joinUpbSql +
				joinFlussoCreditiSql +
				" WHERE EXISTS(SELECT * from flussoincassidetail  " +
				" JOIN flussoincassi ON flussoincassi.idflusso=flussoincassidetail.idflusso " +
				" WHERE (flussoincassidetail.iuv = flussocreditidetail.iuv OR flussoincassidetail.iduniqueformcode = flussocreditidetail.iduniqueformcode) " +
				" AND " + filterNonElaborati.toSql(_qhs) +
				")" +
				" AND flussocreditidetail.idestimkind is null AND flussocreditidetail.idinvkind is not null " +
				" AND flussocreditidetail.stop is null and flussocreditidetail.annulment is null " +
				//condUpbSql 
				condFlussoCreditiSql +
				$") AND (yinv <= {esercizio}) ";
			//La sicurezza l'abbiamo già filtrata sui crediti, non c'è bisogno di filtrarla anche sul dettaglio contratto
			//DS.invoicedetail._sqlGetFromDb(_conn, sqlGetFatture);

			_conn.SQLRUN_INTO_TABLE(DS.invoicedetail, sqlGetFatture);
			incPBar();
			foreach (var r in DS.invoicedetail)
			{
				info.addDettFattura(r);
				var filterInvoice = q.mCmp(r, "idinvkind", "yinv", "ninv");
				DS.invoice.get(_conn, filterInvoice);
			}
			closePBar();

			if (DS.invoicedetail.Rows.Count == 0)
			{
				_logger.Info("Non sono stati trovati dettagli fattura da incassare di questo anno o anni precedenti.", true);
				return true;
			}

			bool error;
			bool res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.imponibile, info, out error);
			if (error) return false;
			if (res) res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.iva, info, out error);
			if (error) return false;
			if (res) res = creaIncassiFatture(soloConSospesi, TipoElaborazioneIncassi.totali, info, out error);
			if (error) return false;

			foreach (var rFlusso in DS.flussoincassi.all())
			{
				var infoFlusso = info.flussoIncassiAmounts[rFlusso.idflusso];
				if (infoFlusso.importoFlusso == infoFlusso.sommaIncassi) rFlusso.elaborato = "S";
			}

			VisualizzaFatture();
			if (DS.invoice.Rows.Count == 0)
			{
				_logger.Info("Non sono state trovate fatture collegate ai crediti incassati.", true);
			}

			return res;
		}

		/// <summary>
		/// Elabora un flusso incassi 
		/// </summary>
		/// <returns></returns>
		private bool creaIncassiFatture(bool soloConSospesi, TipoElaborazioneIncassi tipoElaborazione, infoCreaIncassi info, out bool error)
		{
			error = false;
			var incInvoice = _dispatcher.Get("incomeinvoice");
			incInvoice.SetDefaults(DS.incomeinvoice);
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));

			var metaIncome = _dispatcher.Get("income");
			var metaIncomeYear = _dispatcher.Get("incomeyear");
			var metaIncomeLast = _dispatcher.Get("incomelast");

			metaIncome.SetDefaults(DS.income);
			metaIncomeYear.SetDefaults(DS.incomeyear);
			metaIncomeLast.SetDefaults(DS.incomelast);

			// Partendo da una riga di flussoincassi / flussoincassidetail
			// ciclo sui dettagli fattura filtrati solo sullo IUV e non contabilizzati
			// Mi leggo ilmovimento finanziario padre (l'accertamento che contabilizza eventuale dettaglio contratto attivo) 
			// 1) leggo il dettaglio contratto attivo associato alla fattura  vedendo prima se sta in memoria , 
			// perchè l'ho esaminato nella fase precedente e mi prendo l'accertamento che sta in memoria construendo le nuove fasi successive
			// 2) Se invece non trovo il dettaglio contratto attivo in memoria perchè privo di IUV, 
			// deve rileggere da db eventuale contabilizzazione e prendere quella come riga padre. 
			// Se invece il dettaglio contratto attivo non è contabilizzato, saltare la riga. 
			// Assumiamo che il dettaglio contratto attivo deve essere già stato contabilizzato,
			// 3) Se il dettaglio Fattura non è collegato ad alun dettaglio contratto attivo, generiamo tutte le fasi
			// finanziarie, dalla prima fino all'ultima

			//DS.incomeinvoice.Clear(); comune a tutte e tre le fasi - svuoto prima

			var bollettiniElaborati = new Dictionary<string, bool>();

			// ciclo flusso incassi
			initPBar("creaIncassiFatture - " + tipoElaborazione.ToString(), DS.flussoincassi.Rows.Count);
			foreach (var rFlussoIncassi in DS.flussoincassi)
			{
				incPBar();
				decimal sumAmount = 0;
				if (!info.flussoIncassiAmounts.ContainsKey((int)rFlussoIncassi.idflusso))
				{
					info.flussoIncassiAmounts.Add((int)rFlussoIncassi.idflusso, new infoIncasso() {
						importoFlusso = CfgFn.GetNoNullDecimal(rFlussoIncassi.importo)
					});
				}

				var mov = DS.income;
				var impMov = DS.incomeyear;
				var impLast = DS.incomelast;
				var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
				var fasemassima = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));

				var fasefine = fasemassima;

				MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);

				var idflusso = rFlussoIncassi.idflusso;
				var nbill = rFlussoIncassi.nbillValue;

				// Verifica esistenza della bolletta su DB

				string errore;
				if (soloConSospesi || nbill != DBNull.Value)
				{
					nbill = getSospesiAttivi(nbill, out errore);
					if (nbill == DBNull.Value)
					{
						// Non è stato creato ancora sul db mediante l'importazione del giornale di cassa
						continue;
					}
				}

				// ciclo flusso incassidetail
				//legge i dettagli flusso incassi se non sono presenti
				if (!info.dettFlussoIncassiPerIdFlusso.ContainsKey(idflusso)) continue;

				foreach (var rFileDet in info.dettFlussoIncassiPerIdFlusso[idflusso])
				{
					//Anche qui deve ciclare tra i crediti per ottenere un codiceBollettino

					// Leggo i dettagli fattura da incassare facendo una ricerca per codice bollettino univoco 
					var codiceBollettino = rFileDet.iduniqueformcode;
					if (string.IsNullOrEmpty(codiceBollettino)) continue;

					//var iuv = rFileDet.iuv;

					//Elabora una volta sola ogni codice bollettino, incassando TUTTI i crediti con pari  iduniqueformcode
					//Non fa niente se il ramo c.attivi ha già considerato questo bollettino, questo ramo lo elaborerà per la quota "fatture"
					// che è disgiunta da quella dei c.attivi
					var key = codiceBollettino;
					if (bollettiniElaborati.ContainsKey(key)) continue;
					//// bollettini non incassabili per mancata generazione scritture
					//if (bollettiniNonIncassabili.Contains(codiceBollettino)) {
					//    continue;
					//}
					bollettiniElaborati.Add(key, true);

					// Dettagli non contabilizzati con iduniqueformcode=  codiceBollettino
					if (!info.dettFatturaPerUniqueFormCode.ContainsKey(codiceBollettino)) continue;
					var rowsInvoicedetPerBollettino = info.dettFatturaPerUniqueFormCode[codiceBollettino];

					//Filtra le righe non contabilizzate della fattura
					q filterDetFattura = null;
					switch (tipoElaborazione)
					{
						case TipoElaborazioneIncassi.totali:
							filterDetFattura = q.isNull("idinc_iva") & q.isNull("idinc_taxable");
							break;
						case TipoElaborazioneIncassi.imponibile:
							filterDetFattura = q.isNull("idinc_taxable");
							break;
						case TipoElaborazioneIncassi.iva:
							filterDetFattura = q.isNull("idinc_iva");
							break;
					}

					var rowsInvoicedet = rowsInvoicedetPerBollettino._Filter(filterDetFattura).ToArray();

					// Si possono verificare i seguenti quattro casi:
					// 1) Dettaglio fattura collegato a dettaglio contratto attivo contabilizzato ma non ancora salvato (accertamento in memoria),
					//    sarà portato a incasso partendo dall'accertamento
					// 2) Dettaglio fattura collegato a dettaglio contratto attivo contabilizzato e con accertamento salvato su DB, 
					//    sarà portato a incasso partendo dall'accertamento
					// 3) Dettaglio fattura collegato a dettaglio contratto attivo non contabilizzato con questa procedura perchè privo di IUV, 
					//    sarà scartato e dovrà essere prima contabilizzato il dett. c.a. secondo una delle altre consuete modalità
					// 4) Dettaglio fattura non collegato a dettaglio, 
					//    saranno generate tutte le fasi finanziarie  

					// ciclo flusso invoicedetai

					foreach (var rInvoiceDet in rowsInvoicedet)
					{
						if (GestisceScritture())
						{
							string idrelated = BudgetFunction.ComposeObjects(
									new[] {
										"inv",
										rInvoiceDet["idinvkind"],
										rInvoiceDet["yinv"],
										rInvoiceDet["ninv"]
									});
							if (_conn.count("entry", q.eq("idrelated", idrelated)) == 0)
							{
								continue;
							}
						}

						decimal imponibile = CfgFn.GetNoNullDecimal(rInvoiceDet.taxable);
						decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(rInvoiceDet.npackage);
						decimal sconto = CfgFn.GetNoNullDecimal(rInvoiceDet.discount);
						decimal imponibiletot =
							CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto))));
						//double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot*tassocambio);
						var iva = CfgFn.GetNoNullDecimal(rInvoiceDet.tax);
						decimal amountBase = 0;

						var filterInvoice = q.mCmp(rInvoiceDet, "idinvkind", "yinv", "ninv");

						var invoice = DS.invoice.get(_conn, filterInvoice);
						if (invoice.Length == 0) continue;
						var invoiceRow = invoice[0];

						bool splitPayment=false;
						if (invoiceRow.flag_enable_split_payment == "S")
						{
							if (tipoElaborazione != TipoElaborazioneIncassi.imponibile) continue;
							splitPayment = true; //in questo caso la contabilizzazione deve essere per forza "imponibile"
							iva = 0;
						}

						var idincTaxable = rInvoiceDet.idinc_taxable;
						var idinciva = rInvoiceDet.idinc_iva;

						if (idincTaxable != null && tipoElaborazione == TipoElaborazioneIncassi.imponibile) continue; // già contabilizzato
						if (idinciva != null && tipoElaborazione == TipoElaborazioneIncassi.iva) continue; // già contabilizzato
						if ((idincTaxable != null || idinciva != null) && tipoElaborazione == TipoElaborazioneIncassi.totali) continue; // già contabilizzato

						var currUpb = rInvoiceDet.idupb;
						var currUpbIva = rInvoiceDet.idupb_iva;

						//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
						// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
						if ((rInvoiceDet.idfinmotive_iva != null) && (currUpb != null) && (currUpbIva == null))
						{
							currUpbIva = currUpb;
						}

						// Cerca la contabilizzazione del dettaglio contratto attivo collegato per agganciarsi ad essa                        
						estimatedetailRow estimDet = null;
						if (rInvoiceDet.idestimkind != null)
						{
							var estimateDetails = DS.estimatedetail.get(_conn,
								q.mCmp(rInvoiceDet, "idestimkind", "yestim", "nestim") &
								q.eq("rownum", rInvoiceDet.estimrownum)
							);
							estimDet = estimateDetails[0];
						}

						if (estimDet == null || faseentratamax == 1)
						{
							//Se non c'è un contratto collegato o siamo nel monofase controlliamo la coerenza degli upb impostati sul dettaglio fattura
							switch (tipoElaborazione)
							{
								case TipoElaborazioneIncassi.totali:
									//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null)
										continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									break;
								case TipoElaborazioneIncassi.imponibile:
									if (currUpb == null || (iva > 0 && currUpbIva == null))
									{
										continue; // imponibile  o iva è ammesso solo se c'è currUPB
									}
									break;
								case TipoElaborazioneIncassi.iva:
									if (currUpb == null || (iva > 0 && currUpbIva == null))
									{
										continue; // imponibile  o iva è ammesso solo se c'è currUPB

									}
									break;
							}
						}
						else
						{
							//conta la cont. del  dett.contratto non gli upb
							switch (tipoElaborazione)
							{
								case TipoElaborazioneIncassi.totali:
									//Elaborazione per modifica split fasi - esegue solo con upb_iva == null
									if (currUpb == null || currUpbIva != null) continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
									if (estimDet.idinc_iva != estimDet.idinc_taxable)
									{
										_logger.Error($"Nel dettaglio fattura [{rInvoiceDet.detaildescription}] codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" bisogna specificare l'upb dell'iva per coerenza con il contratto attivo collegato"); // imponibile  o iva è ammesso solo se c'è currUPB
										continue;
									}
									break;
								case TipoElaborazioneIncassi.imponibile:
									if (currUpb == null || (iva > 0 && currUpbIva == null))
									{
										continue; // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva o causale finanziaria iva
									}
									if (estimDet.idinc_taxable != null && estimDet.idinc_taxable == estimDet.idinc_iva)
									{
										_logger.Error($" Nel dettaglio fattura [{rInvoiceDet.detaildescription}] codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" la causale di contabilizzazione del Contratto Attivo, " +
											$" non è coerente con la valorizzazione della Causale Finanziaria IVA. " +
											$" Si deve cancellare la Causale finanziaria IVA dal dettaglio Fattura."); // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva o causale finanziaria iva
										continue;
									}

									if (estimDet.idinc_taxable == null)
									{
										_logger.Error($"L'imponibile del dettaglio contratto attivo collegato al dettaglio " +
											$"fattura [{rInvoiceDet.detaildescription}] codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" va contabilizzato prima di elaborare l'incasso della fattura collegata"); // imponibile  o iva è ammesso solo se c'è currUPB
										continue;
									}

									break;
								case TipoElaborazioneIncassi.iva:
									if (iva == 0) continue;
									if (currUpb == null || currUpbIva == null)
									{
										continue; // imponibile  o iva è ammesso solo se c'è currUPB e anche upbIva
									}

									if (estimDet.idinc_iva == null)
									{
										_logger.Error($"L'iva del dettaglio contratto attivo collegato al dettaglio " +
											$"fattura{rInvoiceDet.detaildescription} codice bollettino {rInvoiceDet.iduniqueformcode} " +
											$" va contabilizzata prima di elaborare l'incasso della fattura collegata"); // imponibile  o iva è ammesso solo se c'è currUPB
										error = true;
										return false;
									}
									break;
							}
						}

						switch (tipoElaborazione)
						{
							case TipoElaborazioneIncassi.totali:
								amountBase = imponibiletot + iva;
								//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
								break;
							case TipoElaborazioneIncassi.imponibile:
								amountBase = imponibiletot;
								break;
							case TipoElaborazioneIncassi.iva:
								amountBase = iva;
								break;
						}

						if (amountBase == 0) continue;

						// Cerco eventuale accertamento che contabilizza il dettaglio contratto attivo associato

						incomeRow parentR = null;
						incomeyearRow parentYearR = null;

						int faseinizio;
						if (rInvoiceDet.idestimkind == null || faseentratamax == 1)
						{
							//Se il contratto attivo manca o è monofase, genera tutte le fasi
							faseinizio = 1;
						}
						else
						{
							if (estimDet == null) continue; // C'è un errore

							//Nel caso di monofase potrebbe essere idestimkind not null ma il contratto potrebbe non essere contabilizzato                           
							var idincCa = estimDet.idinc_taxable;
							if (tipoElaborazione == TipoElaborazioneIncassi.iva)
							{
								idincCa = estimDet.idinc_iva;
							}

							// Se idinc_taxable è nullo, il dettaglio del contratto attivo deve essere contabilizzato per altra via, 
							// si tratta di un dettaglio senza IUV e la presente procedura non lo elabora
							if (idincCa == null) continue;

							// Prima cerca l'accertamento in memoria perchè potrebbe non essere stato ancora salvato
							var movs = DS.income.Filter(q.eq("idinc", idincCa));
							var movYears = DS.incomeyear.Filter(q.eq("idinc", idincCa));

							// Se non lo trova in memoria legge l'accertamento precedentemente salvato su DB 
							if (movs.Length == 0)
							{
								movs = DS.income.getFromDb(_conn, q.eq("idinc", idincCa));
								movYears = DS.incomeyear.getFromDb(_conn, q.eq("idinc", idincCa) & q.eq("ayear", esercizio));
							}

							if (movs.Length == 0) continue; // Non trova la contabilizzazione, si tratta di un errore
							faseinizio = fasecontratto + 1; // deve generare le fasi finanziarie successive

							parentR = movs[0];
							parentYearR = movYears[0];
						}

						//string filterInvoice = QHS.AppAnd(QHS.CmpEq("idinvkind", rInvoiceDet["idinvkind"]),
						//            QHS.CmpEq("yinv", rInvoiceDet["yinv"]), QHS.CmpEq("ninv", rInvoiceDet["ninv"]));

						object idacc = DBNull.Value;

						var idaccmotive = invoiceRow.idaccmotivedebit_crg ?? invoiceRow.idaccmotivedebit;

						// Anagrafica dalla Fattura
						var idreg = invoiceRow.idreg;
						// Incasso che contabilizza il dettaglio di importo pari a -importo

						MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
						//DataRow IncomeToLink = null; 

						// ciclo fasi
						for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++)
						{
							mov.Columns["nphase"].DefaultValue = faseCorrente;

							//var amount = //imponibiletot + iva;
							//    CfgFn.GetNoNullDecimal(parentYearR == null ? imponibiletot+iva : parentYearR.amount); //moltiplicata per la quantità rInvoiceDet.number al fine di ottenere l'imponibile
							decimal amount = amountBase; //CfgFn.GetNoNullDecimal(parentYearR == null ? amountBase: parentYearR.amount); //moltiplicata per la quantità rInvoiceDet.number al fine di ottenere l'imponibile
							if (amount == 0) break;

							var newEntrataRow = metaIncome.Get_New_Row(parentR, mov) as incomeRow;

							var description = parentR?["description"].ToString() ?? invoiceDescription(rInvoiceDet);

							// Selezione UPB e Voce di Bilancio in modo completamente automatico
							var idUpbSelected = rInvoiceDet.idupb;
							if (rInvoiceDet.idupb_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva)
							{
								idUpbSelected = rInvoiceDet.idupb_iva;
							}

							var idmanagerSelected = getUpbManager(idUpbSelected, out errore); // _conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");
												 //_conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idUpbSelected),"idman");

							// Determinazione del capitolo di bilancio in base alla causale finanziaria impostata sul dettaglio
							/// questo in analogia a quanto fa sul contratto attivo deve essere fatto solo se fase inizio è uguale a fase bilancio 
							var idfinCurr = getBilancioFromCausaleFin(rInvoiceDet.idfinmotiveValue, out errore);
							string erroreiva;
							var idfinCurr_iva = getBilancioFromCausaleFin(rInvoiceDet.idfinmotive_ivaValue, out erroreiva);
							var idfinSelected = idfinCurr;
							if (rInvoiceDet.idfinmotive_iva != null && tipoElaborazione == TipoElaborazioneIncassi.iva && idfinCurr_iva != null)
							{
								idfinSelected = idfinCurr_iva;
							}

							// Ma se sta generando sulla base di accertamenti già creati non va bene, se no ottiene imputazioni
							// incoerenti nella gerarchia dei movimenti di entrata
							if (fasebilancio < faseinizio)
							{
								idUpbSelected = parentYearR.idupb;
								idfinSelected = parentYearR.idfin;
								idmanagerSelected = (object)parentR.idman ?? DBNull.Value;
							}

							if (errore != "")
							{
								_logger.Error(errore + " nel dettaglio " + rInvoiceDet.detaildescription + " codice bollettino " + rInvoiceDet.iduniqueformcode);
								return false;
							}

							fillMovimento(newEntrataRow, idmanagerSelected, idreg, description);

							newEntrataRow.doc = invoiceRow.doc; //invoiceDescription(rInvoiceDet);
							newEntrataRow.docdate = invoiceRow.docdate; //rFlussoIncassi.dataincasso;
							newEntrataRow.nphaseValue = faseCorrente;

							var newImpMov = impMov.NewRow();
							fillImputazioneMovimento(newImpMov, amount, idfinSelected, idUpbSelected);

							newImpMov["idinc"] = newEntrataRow["idinc"];
							newImpMov["ayear"] = esercizio;

							impMov.Rows.Add(newImpMov);

							object idsor_siopeivavendita = null;
							DataTable Tconfig = _conn.RUN_SELECT("config", "*", null, _qhs.CmpEq("ayear", _conn.GetSys("esercizio")), null, true);
							if (Tconfig.Rows.Count > 0)
							{
								idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
							}

							if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S")
							{
								string errori;
								object idsor = null;
								if ((tipoElaborazione == TipoElaborazioneIncassi.iva) && (idsor_siopeivavendita != null))
								{
									//Legge il siope da config
									idsor = idsor_siopeivavendita;
								}
								// Classificazione SIOPE impostata su documento
								if (idsor == DBNull.Value || idsor == null)
								{
									idsor = rInvoiceDet.idsor_siope;
								}
								//Altrumenti leggo class SIOPE impostata sulla causale di ricavo
								if ((idsor == DBNull.Value || idsor == null) && SiopeE_obbligatorio())
								{
									idsor = getSiopeForAccMotive(rInvoiceDet.idaccmotive, out errori);
								}
								fillIncomeSorted(newEntrataRow, idsor, amount);
							}

							if (faseCorrente == fasemassima)
							{
								var newLastMov = metaIncomeLast.Get_New_Row(newEntrataRow, impLast) as incomelastRow;
								// aggiunge le informazioni sul numero bolletta se sono state specificate nel flusso e

								if (nbill != DBNull.Value)
								{
									newLastMov.nbill = (int)nbill;
									var flag = CfgFn.GetNoNullInt32(newLastMov["flag"]);
									flag |= 1;
									newLastMov["flag"] = flag;
								}

								newLastMov["idinc"] = newEntrataRow["idinc"];

								if (epMain.attivo)
								{
									idacc = epMain.GetCustomerAccountForRegistry(idaccmotive, newEntrataRow["idreg"]);
								}

								if (idacc != DBNull.Value)
								{
									newLastMov["idacccredit"] = idacc;
								}

								//Aggiunge la riga in IncomeInvoice e lo contabilizza
								//const int currcausale = 1; // contabilizzazione totale

								int currcausale = 1;
								switch (tipoElaborazione)
								{
									case TipoElaborazioneIncassi.totali:
										currcausale = 1;
										break;
									case TipoElaborazioneIncassi.imponibile:
										currcausale = 3;
										break;
									case TipoElaborazioneIncassi.iva:
										currcausale = 2;
										break;
								}

								var incInvoiceRow = incInvoice.Get_New_Row(newEntrataRow, DS.incomeinvoice);
								incInvoiceRow["movkind"] = currcausale;
								incInvoiceRow["idinvkind"] = rInvoiceDet.idinvkind;
								incInvoiceRow["yinv"] = rInvoiceDet.yinv;
								incInvoiceRow["ninv"] = rInvoiceDet.ninv;

								//Effettua i collegamenti con il dettaglio della fattura
								if (tipoElaborazione == TipoElaborazioneIncassi.imponibile)
								{
									rInvoiceDet.idinc_taxable = newEntrataRow.idinc;
								}

								if (tipoElaborazione == TipoElaborazioneIncassi.iva)
								{
									rInvoiceDet.idinc_iva = newEntrataRow.idinc;
								}

								if (tipoElaborazione == TipoElaborazioneIncassi.totali)
								{
									rInvoiceDet.idinc_iva = newEntrataRow.idinc;
									rInvoiceDet.idinc_taxable = newEntrataRow.idinc;
								}

								sumAmount += amount; // incrementa l'importo incassato
							}

							parentR = newEntrataRow;
						}

						// fine ciclo fasi
					}

					// fine ciclo flusso invoicedetai

					//va fatto al termine delle fasi imponibile,iva e totali
					//if (rFlussoIncassi.importo == sumAmount) {
					//      rFlussoIncassi.elaborato = "S";
					//}
				}

				// fine ciclo flusso incassidetail

				info.flussoIncassiAmounts[(int)rFlussoIncassi.idflusso].sommaIncassi += sumAmount;
			}
			closePBar();
			//fine ciclo flusso incassi

			return true;
		}

		private object getSospesiAttivi(object numeroSospesoAttivo, out string errori)
		{
			errori = "";
			if (numeroSospesoAttivo == DBNull.Value || numeroSospesoAttivo == null) return DBNull.Value;
			var numeroSospesoAttivoI = CfgFn.GetNoNullInt32(numeroSospesoAttivo);
			if (numeroSospesoAttivoI == 0) return DBNull.Value;
			if (_sospesiAttivi.ContainsKey(numeroSospesoAttivoI)) return _sospesiAttivi[numeroSospesoAttivoI];
			var filter = _qhs.AppAnd(_qhs.CmpEq("ybill", esercizio), _qhs.CmpEq("billkind", "C"),
				_qhs.CmpEq("nbill", numeroSospesoAttivoI));
			var t = _conn.SQLRunner($"select nbill  from bill   where {filter}", false);
			if (t == null)
			{
				errori = "Errore nell'accesso al db" + _conn.SecureGetLastError();
				return DBNull.Value;
			}

			if (t.Rows.Count == 0)
			{
				errori = "Il sospeso attivo n°" + numeroSospesoAttivo +
						 " non è ancora presente su DB. E' necessario eseguire prima l'importazione del giornale di Cassa. ";
				_sospesiAttivi[numeroSospesoAttivoI] = DBNull.Value;
				return DBNull.Value;
			}
			else
			{
				_sospesiAttivi[numeroSospesoAttivoI] = t.Rows[0]["nbill"];
				return _sospesiAttivi[numeroSospesoAttivoI];
			}
		}

		private bool GestisceScritture()
		{
			if (epMain.attivo)
				return true;
			else
				return false;
		}

		private string invoiceDescription(DataRow r)
		{
			return "Fattura " +
				   r["idinvkind"] + "/" +
				   r["yinv"].ToString().Substring(2, 2) + "/" +
				   r["ninv"].ToString().PadLeft(6, '0');
		}

		private void VisualizzaFatture()
		{
			__regTitles.Clear();
			for (int i = 0; i < DS.invoice.Rows.Count; i++)
			{
				AddVoceCreditore(DS.invoice.Rows[i]);
			}

			_uiOperations.SetDataGrid("dgrFattureElaborate", DS.invoice);
			//HelpForm.SetDataGrid(dgrFattureElaborate, DS.invoice);
		}
		
		private string GetTitleForIdReg(object idreg)
		{
			if (idreg == DBNull.Value) return "";
			int n = Convert.ToInt32(idreg);
			DataRow reg = getRegistry(n);

			//if (__regTitles.ContainsKey(n)) return __regTitles[n];

			object title = reg?["title"]; //_conn.DO_READ_VALUE("registry", _qhs.CmpEq("idreg", idreg), "title");
			if (title == null)
			{
				title = "[anagrafica di codice " + idreg + "]";
			}

			__regTitles[n] = title.ToString();
			return title.ToString();
		}

		private DataRow getRegistry(int idReg)
		{
			if (registryByIdReg.ContainsKey(idReg)) return registryByIdReg[idReg];
			DataTable t = _conn.readTable("registry", q.eq("idreg", idReg), "idreg,email_fe,pec_fe,flag_pa,title");
			if (t.Rows.Count == 0) return null;
			registryByIdReg[idReg] = t.Rows[0];
			return registryByIdReg[idReg];
		}

		#endregion

		#region CreaContrattoAttivoFlussoCrediti
		/// <summary>
		/// Elabora contratto da flusso studenti
		/// </summary>
		public void ElaboraFlussoCrediti()
		{
			QueryCreator.MarkEvent("Inizio btnElaboraFlussoCrediti_Click");
			_uiOperations.SetControlVisibility("btnelaboraFlussoCrediti", false);
			_uiOperations.DoEvents();
			object startFlusso = DBNull.Value;
			object stopFlusso = DBNull.Value;
			string txtStartFlusso = _uiOperations.GetText("txtStartFlusso");
			if (txtStartFlusso != "")
			{
				object i = HelpForm.GetObjectFromString(typeof(int), txtStartFlusso, "x.y.g");
				if (i == null)
				{
					_logger.Error("Numero non valido in n.flusso iniziale");
					return;
				}

				startFlusso = i;
			}

			string txtStopFlusso = _uiOperations.GetText("txtStopFlusso");

			if (txtStopFlusso != "")
			{
				object i = HelpForm.GetObjectFromString(typeof(int), txtStopFlusso, "x.y.g");
				if (i == null)
				{
					_logger.Error("Numero non valido in n.flusso finale");
					return;
				}

				stopFlusso = i;
			}

			if (startFlusso == DBNull.Value && stopFlusso != DBNull.Value)
			{
				_uiOperations.SetControlVisibility("btnelaboraFlussoCrediti", true);
				_logger.Error("Il campo 'da n. flusso' non può essere vuoto");
				return;
			}
			else if (startFlusso != DBNull.Value && stopFlusso == DBNull.Value)
			{
				_uiOperations.SetControlVisibility("btnelaboraFlussoCrediti", true);
				_logger.Error("Il campo 'a n. flusso' non può essere vuoto");
				return;
			}

			elaboraFlussoCrediti(startFlusso, stopFlusso);
			azzeraTutto();
			if (faseentratamax != 1)
				CercaContrattiDaContabilizzare();
			_uiOperations.SetControlVisibility("btnelaboraFlussoCrediti", true);

			_logger.DisplayMessage();
		}

		private void elaboraFlussoCrediti(object _from, object _to)
		{
			//riempie estimate, estimate
			QueryCreator.MarkEvent("Inizio elaboraFlussoCrediti");
			var res = fillEstimate(_from, _to); //non salva i dati
			if (!res)
			{
				_logger.Error(@"Errore nella creazione dei contratti attivi");
				return;
			}
			if (ResiduiAttiviTrasferiti())
			{
				var resA = fillAnnulment(_from, _to);
				if (!resA)
				{
					_logger.Error(@"Errore nell'elaborazione degli annullamenti");
					return;
				}
			}
			else
			{
				_logger.Info("Per elaborare gli annullamenti è necessario aver trasferito i Residui Attivi.", true);
			}

			if (!DS.HasChanges())
			{
				_logger.Info("Nessun credito da elaborare", true);
				return;
			}

			if (!_fsPostData.runPostData(DS)) return;
			
			if (generaScrittureContrattiAttivi())
			{
				_logger.Info("Elaborazione crediti completata", true);
			}
		}

		/// <summary>
		/// Crea i contratti attivi dalle righe di dettaglio flusso crediti non ancora elaborate e non annullate (stop null)
		/// Le righe considerate sono quelle senza tipo contratto attivo  e senza tipo fattura, oppure con tipo contratto ma senza n. contratto
		/// Svuota e riempie estimate, estimatedetail, flussocrediti*
		/// </summary>
		/// <returns></returns>
		private bool fillEstimate(object _from, object _to)
		{
			QueryCreator.MarkEvent("Inizio fillEstimate");
			DS.estimate.Clear();
			DS.estimatedetail.Clear();
			DS.invoice.Clear();
			DS.invoicedetail.Clear();
			DS.ivaregister.Clear();
			DS.registry.Clear();
			DS.flussocrediti.Clear();
			DS.flussocreditidetail.Clear();
			DS.income.Clear();
			DS.incomeestimate.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
			righeContrattoAttivo.Clear();
			initPBar("Inizializzazione creazione contratti da flusso crediti", 5);

			var metaEstimate = _dispatcher.Get("estimate");
			metaEstimate.SetDefaults(DS.estimate);
			var metaEstimateDetail = _dispatcher.Get("estimatedetail");
			metaEstimateDetail.SetDefaults(DS.estimatedetail);

			var ivaKind = _conn.RUN_SELECT("ivakind", "idivakind,rate", null, null, null, false);
			incPBar();
			var ivaTaxRate = new Dictionary<int, object>();
			foreach (var r in ivaKind.Select())
			{
				ivaTaxRate[CfgFn.GetNoNullInt32(r["idivakind"])] = r["rate"];
			}
			// Conn.readSimpleDictionary<int, object>("ivakind", "idivakind", "taxrate");

			RowChange.MarkAsAutoincrement(DS.estimate.Columns["nestim"], null, null, 0);
			MetaData.SetDefault(DS.estimate, "nestim", -100000);

			var errore = "";
			var tempNestim = 0;
			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
			// elabora tutto il pregresso
			var upbSecurity = _conn.Security.SelectCondition("upb", false);
			var filterUpbSec = MetaExpressionParser.From(upbSecurity);
			filterUpbSec?.cascadeSetTable("upb");

			var condizioneSuDettCrediti = q.doPar(
				q.doPar(q.isNull("idestimkind") & q.isNull("idinvkind") & q.isNull("stop") & q.isNull("annulment"))
				|
				q.doPar(q.isNotNull("idestimkind") & q.isNull("nestim") & q.isNull("stop") & q.isNull("annulment"))
			);
			if (_from != DBNull.Value)
			{
				condizioneSuDettCrediti &= q.ge("idflusso", _from);
			}

			if (_to != DBNull.Value)
			{
				condizioneSuDettCrediti &= q.le("idflusso", _to);
			}

			var allRows = DS.flussocreditidetail.readTableJoined(_conn, "upb", condizioneSuDettCrediti, filterUpbSec, "idupb");
			incPBar();
			//attenzione: sfrutta il comportamento interno della readTableJoined, che ha già modificato gli alias delle condizioni in input

			var overallCondition = (filterUpbSec == null ? condizioneSuDettCrediti : condizioneSuDettCrediti & filterUpbSec).toSql(_qhs);

			//Legge i flussi collegati, ci vuole una doppia join però
			string colonneFlussoCrediti = string.Join(",",
				(from c in DS.flussocrediti.Columns._names()
				 where QueryCreator.IsReal(DS.flussocrediti.Columns[c])
				 select "flussocrediti." + c).ToArray());
			condizioneSuDettCrediti.cascadeSetTable("flussocreditidetail"); //superfluo ma non fa male
			var getFlussiSql = $"SELECT {colonneFlussoCrediti} FROM flussocrediti " +
							   $" WHERE idflusso in (select idflusso from flussocreditidetail " +
							   " JOIN UPB on UPB.idupb=flussocreditidetail.idupb " +
							   $" WHERE {overallCondition} )";
			DS.flussocrediti._sqlGetFromDb(_conn, getFlussiSql);
			QueryCreator.MarkEvent($"fillEstimate - 1 : in DS.flussocrediti {DS.flussocrediti.Rows.Count} righe");

			incPBar();
			var flussoCreditiDict = new Dictionary<int?, flussocreditiRow>();
			foreach (var r in DS.flussocrediti) flussoCreditiDict[r.idflusso] = r;

			string colonneContratti = string.Join(",",
				(from c in DS.estimate.Columns._names()
				 where QueryCreator.IsReal(DS.estimate.Columns[c]) & c!="txt"
				 select "estimate." + c).ToArray());

			// WHERE ((((idestimkind='CA_ESSE3')AND(idaccmotivecredit='000600140008'))AND(adate={d '2019-12-31'}))AND(docdate={d '2019-12-29'}))AND(yestim=2019)
			//docdate  = rCrediti.docdate;
			//idcodiceTipoContratto = rCreditiDetail.idestimkind ?? rCrediti.idestimkind 
			//idaccmotivecredit  = rCreditiDetail.idaccmotivecredit

			//Estrae i contratti associati ai crediti in considerazione
			string sqlGetContratti =
				$" SELECT distinct {colonneContratti}  " +
				$" FROM flussocreditidetail " +
				$" JOIN flussocrediti on flussocrediti.idflusso=flussocreditidetail.idflusso "+
				$" JOIN estimate ON estimate.idestimkind=isnull(flussocreditidetail.idestimkind,flussocrediti.idestimkind) AND "+
				$"    estimate.idaccmotivecredit = flussocreditidetail.idaccmotivecredit AND"+
				$"    estimate.docdate = flussocrediti.docdate AND "+
				$"    estimate.yestim = {esercizio} "+
				" JOIN UPB on UPB.idupb=flussocreditidetail.idupb " +
				$" WHERE {overallCondition} ";

			DS.estimate._sqlSafeMergeFromDb(_conn, sqlGetContratti, 0);
			QueryCreator.MarkEvent(sqlGetContratti);
			QueryCreator.MarkEvent($"fillEstimate - 2 : in DS.estimate {DS.estimate.Rows.Count} righe");

			foreach (var r in DS.estimate) addEstimateRow(r);
			incPBar();

			string colonneDettContratti = string.Join(",",
				(from c in DS.estimatedetail.Columns._names()
				 where QueryCreator.IsReal(DS.estimatedetail.Columns[c])
				 select "estimatedetail." + c).ToArray());

			string sqlGetDetContratti =
				$" SELECT distinct {colonneDettContratti}  " +
				$" FROM estimatedetail " +
				$" JOIN ( {sqlGetContratti} ) AS A "+
				$" on A.idestimkind=estimatedetail.idestimkind and A.yestim=estimatedetail.yestim and A.nestim=estimatedetail.nestim ";
			QueryCreator.MarkEvent(sqlGetDetContratti);
			DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlGetDetContratti, 0);

			QueryCreator.MarkEvent($"fillEstimate - 3 : in DS.estimatedetail {DS.estimatedetail.Rows.Count} righe");

			QueryCreator.MarkEvent("Inizio foreach (var rCreditiDetail");
			initPBar("Creazione contratti da flusso crediti", allRows.Length);
			foreach (var rCreditiDetail in allRows)
			{
				incPBar();
				//Application.DoEvents();
				// Dovrò creare un solo contratto con tanti dettagli 
				// quante sono le anagrafiche pertanto data contabile, tipo contratto e causale ricavo saranno uguali

				var importo = rCreditiDetail.importoversamento;
				var idfinmotive = rCreditiDetail.idfinmotive;
				var idfinmotive_iva = rCreditiDetail.idfinmotive_iva;
				var iduniqueformcode = rCreditiDetail.iduniqueformcode;
				var idaccmotiverevenue = rCreditiDetail.idaccmotiverevenue;
				var idaccmotivecredit = rCreditiDetail.idaccmotivecredit;
				var idupb = rCreditiDetail.idupb;
				var idreg = rCreditiDetail.idreg;
				var competencystart = rCreditiDetail.competencystart;
				var competencystop = rCreditiDetail.competencystop;
				var description = rCreditiDetail.description;
				var nform = rCreditiDetail.nform;
				var idlist = rCreditiDetail.idlist;

				var number = CfgFn.GetNoNullDecimal(rCreditiDetail["number"]);
				if (number == 0) number = 1;
				var taxable = CfgFn.GetNoNullDecimal(importo) / number;

				flussocreditiRow rCrediti = null;
				if (flussoCreditiDict.ContainsKey(rCreditiDetail.idflusso))
				{
					rCrediti = flussoCreditiDict[rCreditiDetail.idflusso];
				}

				var idcodiceTipoContratto = rCreditiDetail.idestimkind ?? rCrediti.idestimkind;
				//attualmente sempre NULL, NO! i crediti provenienti da portale ce l'hanno o possono avercelo

				if (rCrediti["docdate"] == DBNull.Value) continue;

				var docdate = (DateTime) rCrediti["docdate"];
				if (docdate.Year != esercizio) continue;
				idcodiceTipoContratto = checkTipoContrattoAttivo(idcodiceTipoContratto, out errore);
				if (errore != "")
				{
					_logger.Error("Tipo contratto assente nei crediti");
					continue;
				}

				if (idcodiceTipoContratto == null || idcodiceTipoContratto == "")
				{
					_logger.Error("Tipo contratto assente");
					continue;
				}

				//var docdate = rCrediti.docdate;
				var idsor01 = rCrediti.idsor01;
				var idsor02 = rCrediti.idsor02;
				var idsor03 = rCrediti.idsor03;
				var idsor04 = rCrediti.idsor04;
				var idsor05 = rCrediti.idsor05;

				if (idaccmotivecredit == null)
				{
					_logger.Error("Causale di Credito assente");
					return false;
				}

				var rEstimateArr = getEstimateRow(idcodiceTipoContratto, idaccmotivecredit, docdate);
				//DS.estimate.get(_conn, q.eq("idestimkind", idcodiceTipoContratto) &q.eq("idaccmotivecredit", idaccmotivecredit) & 
				//                       q.eq("adate", _security.GetDataContabile()) & q.eq("docdate",  (((object)docdate)?? DBNull.Value)) & q.eq("yestim", esercizio));
				int? idivakindDefault;
				estimateRow rEstimate;
				//prende la riga di contratto esistente o ne crea una nuova
				if (rEstimateArr != null && rEstimateArr.Length > 0)
				{
					rEstimate = rEstimateArr[0];
					idivakindDefault = impostaDefaultIvaKind(idcodiceTipoContratto, out errore);
					//DS.estimatedetail.get(_conn,q.mCmp(rEstimate, "idestimkind", "yestim", "nestim")); //non credo serva
				}
				else
				{
					tempNestim++;
					MetaData.SetDefault(DS.estimate, "idestimkind", idcodiceTipoContratto);
					MetaData.SetDefault(DS.estimate, "yestim", esercizio);

					idivakindDefault = impostaDefaultIvaKind(idcodiceTipoContratto, out errore);
					if (errore != "")
					{
						_logger.Error(errore);
						return false;
					}

					var rNewEstimate = metaEstimate.Get_New_Row(null, DS.estimate) as estimateRow;
					//rNewEstimate.nestim = tempNestim;
					rNewEstimate.adate = _security.GetDataContabile();
					rNewEstimate.docdate = docdate;
					rNewEstimate.description = "Import.Flusso Studenti";

					rNewEstimate.idsor01 = idsor01;
					rNewEstimate.idsor02 = idsor02;
					rNewEstimate.idsor03 = idsor03;
					rNewEstimate.idsor04 = idsor04;
					rNewEstimate.idsor05 = idsor05;
					rNewEstimate.cu = _conn.externalUser;
					rNewEstimate.lu = _conn.externalUser;

					rNewEstimate.idaccmotivecredit = idaccmotivecredit;
					rEstimate = rNewEstimate;
					addEstimateRow(rEstimate);
				}

				var idivakind = idivakindDefault;
				object taxrate = DBNull.Value;
				if (rCreditiDetail["idivakind"] != DBNull.Value)
				{
					idivakind = rCreditiDetail.idivakind;
				}

				if (idivakind != null)
				{
					var iIdIVakind = CfgFn.GetNoNullInt32(idivakind);
					taxrate = ivaTaxRate[iIdIVakind];
				}

				var rNewDetail = metaEstimateDetail.Get_New_Row(rEstimate, DS.estimatedetail) as estimatedetailRow;
				var gestionedifferita = getGestioneDifferita(rNewDetail.idestimkind, out errore);
				if (gestionedifferita == "S")
				{
					//task 14606  non riportare le date di competenza sui Contratti attivi configurati come "Accertamenti differiti...".
					rNewDetail.flag = (rNewDetail.flag ?? 0) | 1; //scritture differite alla data contabile del dettaglio
				}
				else
				{
					rNewDetail.competencystart = competencystart;
					rNewDetail.competencystop = competencystop;
				}

				rNewDetail.idreg = idreg;
				rNewDetail.detaildescription = description;
				rNewDetail.iduniqueformcode = iduniqueformcode;
				rNewDetail.taxable = taxable;
				rNewDetail.tax = rCreditiDetail.tax ?? 0;
				rNewDetail.idivakind = idivakind;
				rNewDetail.taxrateValue = taxrate;
				rNewDetail.cu = _conn.externalUser;
				rNewDetail.lu = _conn.externalUser;

				rNewDetail.number = number;
				rNewDetail.toinvoice = "N"; // sono di tipo non fatturabile 
				rNewDetail.nform = nform; // numero bollettino solo a titolo informativo
				rNewDetail.idlist = idlist;

				if (idaccmotiverevenue == null)
				{
					errore = $"Manca la causale di ricavo nel dettaglio crediti del bollettino n.{nform ?? iduniqueformcode}";
					_logger.Error(errore);
					return false;
				}

				rNewDetail["idaccmotive"] = idaccmotiverevenue;
				string erroreSiope;
				var idSiope = getSiopeForAccMotive(idaccmotiverevenue, out erroreSiope);
				if (erroreSiope != "")
				{
					_logger.Error(erroreSiope);
					return false;
				}
				if (idSiope != null)
				{
					rNewDetail.idsor_siope = idSiope;
				}

				if (idupb == null)
				{
					errore = $"Manca l'UPB nel dettaglio crediti del bollettino n.{nform}";
					_logger.Error(errore);
					return false;
				}

				rNewDetail.idupb = idupb;

				if (idfinmotive == null)
				{
					errore = $"Manca la causale finanziaria nel dettaglio crediti del bollettino n.{nform ?? iduniqueformcode}";
					_logger.Error(errore);
					return false;
				}

				rNewDetail.idfinmotive = idfinmotive;
				if (idfinmotive_iva != null)
				{
					rNewDetail.idfinmotive_iva = idfinmotive_iva;
				}
				//collega il dettaglio credito al dettaglio flusso crediti
				rCreditiDetail.idestimkind = rEstimate.idestimkind;
				rCreditiDetail.yestim = rEstimate.yestim;
				rCreditiDetail.nestim = rEstimate.nestim;
				rCreditiDetail.rownum = rNewDetail.rownum;
				rCreditiDetail.lt = DateTime.Now;
				rCreditiDetail.lu = "fillEstimate_" + _conn.externalUser;

				rNewDetail.idsor1 = rCreditiDetail.idsor1;
				rNewDetail.idsor2 = rCreditiDetail.idsor2;
				rNewDetail.idsor3 = rCreditiDetail.idsor3;

			}
			closePBar();

			return true;
		}

		private void addEstimateRow(estimateRow r)
		{
			string hh = $"{r["idestimkind"]}§{r["idaccmotivecredit"]}§{r["adate"]}§{r["docdate"]}§{r["yestim"]}";
			List<estimateRow> ll;
			if (!righeContrattoAttivo.TryGetValue(hh, out ll))
			{
				ll = new List<estimateRow>();
				righeContrattoAttivo[hh] = ll;
			}

			ll.Add(r);
		}

		private string checkTipoContrattoAttivo(object oCodiceTipoContratto, out string errori)
		{
			errori = "";
			if (oCodiceTipoContratto == DBNull.Value || oCodiceTipoContratto == null)
			{
				errori = "Codice Tipo Contratto non trovato";
				return null;
			}
			string idestimkind = null;

			var rEstimKind = DS.estimatekind.Filter(q.eq("idestimkind", oCodiceTipoContratto));
			if (rEstimKind.Length == 0)
			{
				errori = $"Tipo Contratto Attivo avente codice {oCodiceTipoContratto} non trovato";
			}
			else
			{
				idestimkind = rEstimKind[0].idestimkind;
			}

			return idestimkind;
		}

		private estimateRow[] getEstimateRow(object idcodiceTipoContratto, object idaccmotivecredit, object docdate)
		{
			if (docdate == null) docdate = DBNull.Value;

			string h =
				$"{idcodiceTipoContratto}§{idaccmotivecredit}§{_security.GetDataContabile()}§{docdate}§{esercizio}";
			if (righeContrattoAttivo.Count == 0)
			{
				foreach (var r in DS.estimate)
				{
					addEstimateRow(r);
				}
			}

			List<estimateRow> l;
			if (righeContrattoAttivo.TryGetValue(h, out l))
			{
				return l.ToArray();
			}
			else
			{
				var ll = DS.estimate.get(_conn, q.eq("idestimkind", idcodiceTipoContratto) &
												q.eq("idaccmotivecredit", idaccmotivecredit) &
												q.eq("adate", _security.GetDataContabile()) &
												q.eq("docdate", docdate) &
												q.eq("yestim", esercizio));
				righeContrattoAttivo[h] = ll.ToList();
				return ll;
			}
		}

		private int? impostaDefaultIvaKind(object oCodiceTipoContratto, out string errori)
		{
			errori = "";
			var rEstimKind = DS.estimatekind.Filter(q.eq("idestimkind", oCodiceTipoContratto));
			if (rEstimKind.Length == 0)
			{
				errori = $"Tipo Contratto Attivo avente codice {oCodiceTipoContratto} non trovato";
				return null;
			}

			var rKind = rEstimKind[0];
			var idivakindForced = rKind.idivakind_forced;
			MetaData.SetDefault(DS.estimatedetail, "idivakind", idivakindForced);

			if (idivakindForced != null)
			{
				var taxrate = DS.ivakind.Filter(q.eq("idivakind", idivakindForced))[0].rateValue;
				//_conn.readValue("ivakind", q.eq("idivakind", idivakindForced), "rate");
				MetaData.SetDefault(DS.estimatedetail, "taxrate", taxrate);
				return idivakindForced;
			}

			MetaData.SetDefault(DS.estimatedetail, "idivakind", DBNull.Value);
			MetaData.SetDefault(DS.estimatedetail, "taxrate", DBNull.Value);
			//errori = "Tipo Iva Esente non configurato in Contratto Attivo avente codice " +oCodiceTipoContratto.ToString();
			return null;
		}

		private bool ResiduiAttiviTrasferiti()
		{
			int PrevYear = esercizio - 1;
			string filtroPrev = _qhs.CmpEq("ayear", PrevYear);

			DataTable EsercizioPrev = _conn.RUN_SELECT("accountingyear", "*", null, filtroPrev, null, false);
			if (EsercizioPrev.Rows.Count == 0) return true;// vuol dire che non c'è un esercizio precedente. Siamo in un db nuovo
			DataRow Prev = EsercizioPrev.Rows[0];
			bool ra_trasferiti = ((CfgFn.GetNoNullInt32(Prev["flag"]) & 0x0F) >= 4);
			return ra_trasferiti;
		}

		/// <summary>
		/// Elabora gli annullamenti, ossia le righe dettaglio flusso crediti con stop NOT null e flag & 1 =0
		/// Riempie flussocreditidetail e anche incomevar e incomesorted (per annullare gli accertamenti)
		/// Preventivamente svuota income, incomevar, incomesorted
		/// </summary>
		/// <returns></returns>
		private bool fillAnnulment(object _from, object _to)
		{
			QueryCreator.MarkEvent("Inizio fillAnnulment");
			initPBar("Inizializzazione Elaborazione annullamento crediti", 1);
			// Ciclo per l'annullamento dei dettagli
			bool result = true;
			var iduniqueformcodeToAnnul = new List<string>();

			DS.income.Clear();
			DS.incomevar.Clear();
			DS.incomesorted.Clear();
			var metaIncomeVar = _dispatcher.Get("incomevar");
			contrattoAttivoByKey.Clear();

			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);
			//var filterNonElaborati = _qhs.AppAnd(_qhs.IsNotNull("stop"), _qhs.BitClear("isnull(flag,0)",0));

			q filtroCreditiAnnullati =
				q.eq(q.year("flussocreditidetail.stop"), esercizio) & q.doPar(q.isNull("flussocreditidetail.flag") | q.bitClear("flussocreditidetail.flag", 0));

			if (_from != DBNull.Value)
			{
				filtroCreditiAnnullati &= q.ge("flussocreditidetail.idflusso", _from);
			}

			if (_to != DBNull.Value)
			{
				filtroCreditiAnnullati &= q.le("flussocreditidetail.idflusso", _to);
			}

			DS.flussocreditidetail.safeReadTableJoined(_conn, "upb", filtroCreditiAnnullati,
				_conn.Security.SelectCondition("upb", false)?.toMetaExpression(), "idupb");
			QueryCreator.MarkEvent($"fillAnnulment - 1 : in DS.flussocreditidetail {DS.flussocreditidetail.Rows.Count} righe");

			string secUpb = _conn.Security.SelectCondition("upb", true);
			string joinUPB = ""; //join che sarà fatto tra flussocreditidetail e upb
			string whereUPB = ""; //filtro sulla sicurezza
			if (secUpb != null & secUpb != "")
			{
				var qSec = MetaExpressionParser.From(secUpb);
				if (qSec != null)
				{
					qSec.cascadeSetTable("upb");

					joinUPB = " JOIN UPB ON flussocreditidetail.idupb=UPB.idupb ";
					whereUPB = " AND " + qSec.toSql(_qhs, _conn);
				}
			}

			string joinFlussoCreditidetail = ""; //join che sarà fatto tra flussocreditidetail e Estimatedetail 
			joinFlussoCreditidetail = " JOIN flussocreditidetail ON flussocreditidetail.idestimkind=estimatedetail.idestimkind " +
				" and flussocreditidetail.yestim=estimatedetail.yestim and flussocreditidetail.nestim=estimatedetail.nestim " +
				" and flussocreditidetail.rownum=estimatedetail.rownum " +
				" and flussocreditidetail.iduniqueformcode=estimatedetail.iduniqueformcode ";

			string[] columnNames = QueryCreator.ColumnNameList(DS.estimatedetail).Split(',');
			string owner = "estimatedetail";
			string columns = owner + '.'+columnNames[0];
			for (int i = 1; i < columnNames.Length; i++)
			{
				columns += ',' + owner + '.' + columnNames[i];
			}
			//Legge i dett.c.attivi da annullare 
			string sqlEstimDet = $" SELECT { columns} " +
								 $" FROM estimatedetail " +
								 $" {joinFlussoCreditidetail} " +
								 $" {joinUPB} " +
								 $" WHERE " +
									 filtroCreditiAnnullati.toSql(_qhs)+
								 $"	{whereUPB} " +
								 $"	AND estimatedetail.stop is null ";

			DS.estimatedetail._sqlSafeMergeFromDb(_conn, sqlEstimDet);

			QueryCreator.MarkEvent($"fillAnnulment - 2 : in DS.estimatedetail {DS.estimatedetail.Rows.Count} righe");
			string sq = $@"SELECT  idinc, available
			from incometotal
				join estimatedetail on incometotal.idinc = estimatedetail.idinc_taxable or incometotal.idinc = estimatedetail.idinc_iva " +
							$" { joinFlussoCreditidetail}" +
								 $" {joinUPB} " +
								 $" WHERE " +
									 filtroCreditiAnnullati.toSql(_qhs) +
								 $"	{whereUPB} " +
							" AND incometotal.ayear=  " + $"{esercizio}  " +
							" AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
							" AND estimatedetail.stop is null ";

			var Incassi = _conn.SQLRunner($@"
				SELECT  idinc, available
						from incometotal 
							join estimatedetail on incometotal.idinc= estimatedetail.idinc_taxable or incometotal.idinc= estimatedetail.idinc_iva " +
							$" { joinFlussoCreditidetail}" +
								 $" {joinUPB} " +
								 $" WHERE " +
									 filtroCreditiAnnullati.toSql(_qhs) +
								 $"	{whereUPB} " +
							" AND incometotal.ayear=  " + $"{esercizio}  " +
							" AND flussocreditidetail.idestimkind is not null AND flussocreditidetail.idinvkind is null " +
							" AND estimatedetail.stop is null ");

			QueryCreator.MarkEvent($"fillAnnulment - 3 : in Incassi {Incassi.Rows.Count} righe");
			Dictionary<int, decimal> availablePerIdinc = new Dictionary<int, decimal>();
			foreach (DataRow r in Incassi.Rows)
			{
				availablePerIdinc[CfgFn.GetNoNullInt32(r["idinc"])] = CfgFn.GetNoNullDecimal(r["available"]);
			}

			incPBar();
			//DS.flussocreditidetail.mergeFromDb(_conn, filtroCreditiAnnullati);
			//DataAccess.RUN_SELECT_INTO_TABLE(_conn, DS.flussocreditidetail, "idflusso", filterNonElaborati, null, true);
			iduniqueformcodeToAnnul.Clear();
			var annulli = DS.flussocreditidetail.Filter(filtroCreditiAnnullati);

			QueryCreator.MarkEvent("Inizio foreach (var rCreditoAnnullo");
			// Richiede che le righe in flussocrediti da annullare siano già corredate della chiave del dettaglio contratto attivo
			initPBar(" Elaborazione annulli", annulli.Length);

			foreach (var rCreditoAnnullo in annulli)
			{
				incPBar();
				var iduniqueformcode = rCreditoAnnullo.iduniqueformcode;
				if (iduniqueformcode == null) continue;
				if (iduniqueformcodeToAnnul.Contains(iduniqueformcode)) continue;
				iduniqueformcodeToAnnul.Add(iduniqueformcode);

				// inserimenti
				// Leggo i dettagli contratto attivo da annullare facendo una ricerca per codice bollettino univoco
				// potrebbero essere anche in memoria se creo un contratto e contestualmente annullo certi dettagli
				//   oppure se ci sono più crediti annullati riferiti allo stesso contratto attivo
				var stop = rCreditoAnnullo.stop;

				//vanno prese dal flussocreditidetail collegate al dettaglio contratto attivo che stiamo annullando
				var idaccmotiveundotax = rCreditoAnnullo.idaccmotiveundotax;
				var idaccmotiveundotaxpost = rCreditoAnnullo.idaccmotiveundotaxpost;
				var idestimkind = rCreditoAnnullo.idestimkind;
				var yestim = rCreditoAnnullo.yestim;
				var nestim = rCreditoAnnullo.nestim;
				var rownum = rCreditoAnnullo.rownum;
				var filter = q.eq("iduniqueformcode", iduniqueformcode) & q.isNull("stop")
					 // mettere la condizione su dettaglio contratto attivo 
					 & q.eq("idestimkind", idestimkind) & q.eq("yestim", yestim)
					 & q.eq("nestim", nestim) & q.eq("rownum", rownum)
					;

				//if (rCreditiDetail["idestimkind"] == DBNull.Value) {
				//    //show(this, "La riga di annullo numero " + rCreditiDetail["iddetail"] + " non è associata ad un contratto attivo", "Errore");
				//    continue;
				//}

				// ora mi leggo i dettagli contratto attivo che provengono da salvataggi precedenti 
				//DS.estimatedetail.safeMergeFromDb(_conn, filter); //questo restituisce solo le righe eventualmente aggiunte

				//E' necessario il doppio passaggio perchè alcune righe potrebbero essere già in memoria, ossia presenti nella stessa elaborazione                
				var estimateDetailRows = DS.estimatedetail.Filter(filter);

				//annulla i dettagli aventi quello iduniqueformcode
				foreach (var estimateDetailRow in estimateDetailRows)
				{
					_uiOperations.DoEvents();
					//Non deve compilare i campi della riga di annullo, non è richiesto
					//rCreditoAnnullo["idestimkind"] = estimateDetailRow["idestimkind"];
					//rCreditoAnnullo["yestim"] = estimateDetailRow["yestim"];
					//rCreditoAnnullo["nestim"] = estimateDetailRow["nestim"];
					//rCreditoAnnullo["rownum"] = estimateDetailRow["rownum"];
					bool annoPrecedente = CfgFn.GetNoNullInt32(estimateDetailRow["yestim"]) < esercizio;
					object idcausaleEpAnnullamento = annoPrecedente ? idaccmotiveundotaxpost : idaccmotiveundotax;

					//legge il contratto attivo in memoria ove non già presente
					// MA E' davvero necessario?? non credo (2020)
					getEstimateByKey(estimateDetailRow.idestimkind, estimateDetailRow.yestim, estimateDetailRow.nestim);

					//DS.estimate.get(_conn, q.mCmp(estimateDetailRow, "idestimkind", "yestim", "nestim"));

					// Crea una variazione dell'accertamento che contabilizza il dettaglio di importo pari a -importo
					var idincTaxable = estimateDetailRow["idinc_taxable"];
					var fltmovI = _qhs.CmpEq("idinc", idincTaxable);
					if (idincTaxable == DBNull.Value)
					{
						estimateDetailRow["stop"] = stop;
						estimateDetailRow["idaccmotiveannulment"] = idcausaleEpAnnullamento;
						continue;
					}

					var amount = CfgFn.GetNoNullDecimal(estimateDetailRow["taxable"]) +
								 CfgFn.GetNoNullDecimal(estimateDetailRow["tax"]);

					decimal available = 0;
					availablePerIdinc.TryGetValue(CfgFn.GetNoNullInt32(idincTaxable), out available);
					//CfgFn.GetNoNullDecimal(_conn.readValue("incometotal", q.eq("idinc", idincTaxable) & q.eq("ayear", esercizio), "available"));

					if (available < amount)
					{
						_logger.Error($"Il dettaglio {estimateDetailRow.idestimkind} {estimateDetailRow.yestim} {estimateDetailRow.nestim} riga {estimateDetailRow.rownum}" +
							$" {estimateDetailRow.detaildescription} non può essere annullato perchè già incassato");
						continue;
					}

					estimateDetailRow["stop"] = stop;
					estimateDetailRow["idaccmotiveannulment"] = idcausaleEpAnnullamento;

					//var nvar = 1;
					//if (_conn.RUN_SELECT_COUNT("incomevar", fltmovI, false) > 0) {
					//    var maxNvar = _conn.DO_READ_VALUE("incomevar", fltmovI, "max(nvar)");
					//    nvar = CfgFn.GetNoNullInt32(maxNvar) + 1;
					//}
					// Ciclo per creare le variazioni 

					var fltmovIParent = _qhs.CmpEq("idchild", idincTaxable);
					DataTable IncomeLink = _conn.RUN_SELECT("incomelink", "idparent", null,
						fltmovIParent, null, true);

					string lista = _qhs.DistinctVal(IncomeLink.Select(), "idparent");
					var movimentifin = IncomeLink.Select();

					if (IncomeLink.Rows.Count > 0)
						_conn.RUN_SELECT_INTO_TABLE(DS.income, null, _qhs.FieldInList("idinc", lista), null, false);
					_conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, _qhs.FieldInList("idinc", lista), null, false);

					foreach (object idinc in movimentifin._Pick("idparent").ToArray())
					{
						var fltmovIdinc = _qhs.CmpEq("idinc", idinc);
						MetaData.SetDefault(DS.incomevar, "idinc", idinc);
						var var = metaIncomeVar.Get_New_Row(null, DS.incomevar);
						metaIncomeVar.SetDefaults(DS.incomevar);
						var["yvar"] = esercizio;
						//var["nvar"] = nvar;
						var["adate"] = _security.GetDataContabile();
						var["idinc"] = idinc;
						if (idinc == idincTaxable) var["autokind"] = 11; // annullamento totale
						var["amount"] = -amount;
						var["description"] = $"Annul. bollettino univoco numero {iduniqueformcode}";
						var["ct"] = DateTime.Now;
						var["cu"] = "flussostudentiservice";
						var["lt"] = DateTime.Now;
						var["lu"] = "flussostudentiservice";

						// Vario anche le classificazioni impostate allineandole con l'importo corrente
						_conn.RUN_SELECT_INTO_TABLE(DS.incomesorted, null, fltmovIdinc, null, true);
						var rSorted = DS.incomesorted.Select(_qhc.CmpEq("idinc", idinc));
						foreach (var rSor in rSorted)
						{
							rSor["amount"] = CfgFn.GetNoNullDecimal(rSor["amount"]) - amount;
						}
					}
				}

				rCreditoAnnullo["flag"] = CfgFn.GetNoNullInt32(rCreditoAnnullo["flag"]) | 1;

			}
			closePBar();

			//Salva i dati
			//var myPostData = new Easy_PostData();
			//myPostData.initClass(DS, _conn);
			//var res = myPostData.DO_POST();
			//return res;
			return result;
		}

		private estimateRow getEstimateByKey(object idestimkind, object yestim, object nestim)
		{
			string h = $"{idestimkind}§{yestim}§{nestim}";
			if (contrattoAttivoByKey.Count == 0)
			{
				foreach (var rr in DS.estimate)
				{
					string hh = $"{rr["idestimkind"]}§{rr["yestim"]}§{rr["nestim"]}";
					contrattoAttivoByKey[hh] = rr;
				}
			}

			estimateRow r;
			if (contrattoAttivoByKey.TryGetValue(h, out r))
			{
				return r;
			}
			else
			{
				var rr = DS.estimate.get(_conn, q.eq("idestimkind", idestimkind) &
												q.eq("yestim", yestim) &
												q.eq("nestim", nestim));
				if (rr != null && rr.Length == 1)
				{
					contrattoAttivoByKey[h] = rr[0];
					return rr[0];
				}

				return null;
			}
		}

		/// <summary>
		/// Genera le  scritture e movimenti di budget per tutti i contratti attivi nel dataset DS
		/// Effettua letture in estimatedetail per ogni riga di estimate
		/// </summary>
		/// <returns></returns>
		bool generaScrittureContrattiAttivi()
		{
			var estimateSkipped = new List<string>();
			//estimateSkipped = _manageForm.GeneraScritture(DS);
			foreach (var rEstim in DS.estimate)
			{
				DS.estimatedetail.Clear();
				DS.estimatedetail.safeMergeFromDb(_conn, q.mCmp(rEstim, "idestimkind", "yestim", "nestim"));
				var epm = new EP_Manager(_manageForm.getMetaData(DS), null, null, null, null, null, null, null, null, "estimate");
				epm.disableIntegratedPosting();
				epm.silent = true;
				epm.autoIgnore = true;
				epm.setForcedCurrentRow(rEstim);
				epm.beforePost();
				epm.afterPost(true);
				if (epm.ultimaGenerazioneRiuscita == false)
				{
					estimateSkipped.Add(descrContrattoAttivo(rEstim));
				}
			}

			if (estimateSkipped.Count > 0)
			{
				_logger.ShowMessage("Contratti attivi da rivedere", "Per i seguenti contratti attivi non sono state generati movimenti di budget e/o scritture E/P", estimateSkipped);
				//wndDisplay w = new wndDisplay("Contratti attivi da rivedere",
				//	"Per i seguenti contratti attivi non sono state generati movimenti di budget e/o scritture E/P",
				//	estimateSkipped);

				//createForm(w, this);
				//w.Show(this);
				return true;
			}

			if (DS.estimate.Rows.Count > 0)
			{
				_logger.Info("Le scritture sui contratti attivi sono state generate.", true);
			}

			return true;
		}

		#endregion

		#region CercaContrattiAttiviFlussoCrediti
		/// <summary>
		/// Legge in memoria i dettaglio contratti attivi con IUV ma senza contabilizzazione
		/// </summary>
		public void CercaContrattiDaContabilizzare()
		{
			bool saved = _uiOperations.GetControlVisibility("btnCercaContrattiDaContabilizzare");
			_uiOperations.SetControlVisibility("btnCercaContrattiDaContabilizzare", false);
			_uiOperations.DoEvents();
						
			__UpbTitles.Clear();
			__regTitles.Clear();
			
			_uiOperations.SetButtonEnabled("btnElaboraContabilizzazioni", false);

			FillDSEstimateDetail();

			HelpForm.SetAllowMultiSelection(DS.estimatedetail, true);
			_uiOperations.SetDataGrid("dgrDettContrattiAttivi", DS.estimatedetail);
			//HelpForm.SetDataGrid(dgrDettContrattiAttivi, DS.estimatedetail);

			_uiOperations.DataGridSelectAllRows("dgrDettContrattiAttivi", DS.estimatedetail.Rows);
			//if (DS.estimatedetail.Rows.Count > 0)
			//{
			//	for (int i = 0; i < DS.estimatedetail.Rows.Count; i++)
			//	{
			//		dgrDettContrattiAttivi.Select(i); // seleziona tutto
			//	}
			//}

			if (DS.estimatedetail.Rows.Count == 0)
			{
				_logger.Info("Nessun dettaglio contratto trovato", true);
			}

			_uiOperations.SetButtonEnabled("btnElaboraContabilizzazioni", DS.estimatedetail.Rows.Count > 0 && faseentratamax > 1);

			_uiOperations.SetControlVisibility("btnCercaContrattiDaContabilizzare", saved);

			//_logger.DisplayMessage();
		}

		public DataTable FillDSEstimateDetail()
		{
			DS.estimatedetail.Clear();
			// filtra le righe contratti attivi associate a flusso crediti (iduniqueformcode non nullo) non ancora contabilizzate
			var filterDett = ((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva") & q.gt("tax", 0))) &
							 q.isNotNull("iduniqueformcode") &
							 q.isNull("stop");
			var filterEstimate = q.eq("active", "S");
			var secEstimate = MetaExpressionParser.From(_conn.Security.SelectCondition("estimate", true));
			var enabledIdEstimkind = (from r in DS.estimatekind where ((r.flag ?? 0) & 1) == 0 select r.idestimkind).ToArray();
			filterEstimate &= q.fieldIn("idestimkind", enabledIdEstimkind);
			if (secEstimate != null) filterEstimate &= secEstimate;
			_conn.readTableJoined(DS.estimatedetail, "estimate", filterDett, filterEstimate, (from k in DS.estimate.PrimaryKey select k.ColumnName).ToArray());
			preScanVociCollegateDettagliContrattoAttivo(
				((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva") & q.gt("tax", 0))) &
				q.isNotNull("iduniqueformcode") &
				q.isNull("stop"));
			//DS.estimatedetail.getFromDb(_conn,
			//    ((q.isNull("idinc_taxable")) | (q.isNull("idinc_iva"))) & q.isNotNull("iduniqueformcode")  & q.isNull("stop"));
			var mDettaglio = _dispatcher.Get("estimatedetail");
			if (DS.estimatedetail.Rows.Count > 0)
			{
				for (int i = 0; i < DS.estimatedetail.Rows.Count; i++)
				{
					AddVociCollegate(DS.estimatedetail.Rows[i]); //si può ottimizzare passando il filtro originario usato per estimatedetail per fare un join
					mDettaglio.CalculateFields(DS.estimatedetail.Rows[i], "contabilizza");
				}
				return DS.estimatedetail;//.Cast<DataRow>().ToArray();
			}
			else
				return null;
		}

		private void preScanVociCollegateDettagliContrattoAttivo(q filter)
		{
			DataTable tDettView = _conn.CreateTableByName("estimatedetailview",
				"idestimkind,yestim,nestim,idupb,upb,idupb_iva,upb_iva,idreg,registry,adate");
			_conn.readTableJoined(tDettView, "estimate", filter,
				q.eq("active", "S"),
				(from k in DS.estimate.PrimaryKey select k.ColumnName).ToArray());
			foreach (DataRow r in tDettView.Rows)
			{
				if (r["idreg"] != DBNull.Value)
				{
					__regTitles[CfgFn.GetNoNullInt32(r["idreg"])] = r["registry"].ToString();
				}

				if (r["idupb"] != DBNull.Value)
				{
					__UpbTitles[r["idupb"].ToString()] = r["upb"].ToString();
				}

				if (r["idupb_iva"] != DBNull.Value)
				{
					__UpbTitles[r["idupb_iva"].ToString()] = r["upb_iva"].ToString();
				}

				addEstimateDateToDict(r);
			}
		}

		private void AddVociCollegate(DataRow Row)
		{
			if (Row.Table.TableName == "estimatedetail")
			{
				AddVoceEstimkind(Row); //13720
				AddVoceCreditore(Row);
				AddVoceUPB(Row);
				AddVoceUPBIva(Row);
			}
		}

		private void AddVoceEstimkind(DataRow R)
		{
			if (R["idestimkind"] == DBNull.Value) return;
			R["!estimkind"] = GetTitleForEstimateKind(R["idestimkind"]);
		}

		private string GetTitleForEstimateKind(object estimatekind)
		{
			if (estimatekind == DBNull.Value)
				return "";
			string str_estimatekind = estimatekind.ToString();
			if (__EstimatekindTitles.ContainsKey(str_estimatekind))
				return __EstimatekindTitles[str_estimatekind];
			object title = _conn.DO_READ_VALUE("estimatekind", _qhs.CmpEq("idestimkind", estimatekind), "description");
			if (title == null)
			{
				title = "[estimkind di codice " + estimatekind + "]";
			}

			__EstimatekindTitles[str_estimatekind] = title.ToString();
			return title.ToString();
		}

		private void AddVoceUPB(DataRow R)
		{
			if (R["idupb"] == DBNull.Value) return;
			R["!codeupb"] = GetTitleForIdUPB(R["idupb"]);
		}

		private string GetTitleForIdUPB(object idupb)
		{
			if (idupb == DBNull.Value)
				return "";
			string str_idupb = idupb.ToString();
			if (__UpbTitles.ContainsKey(str_idupb))
				return __UpbTitles[str_idupb];
			object title = _conn.DO_READ_VALUE("upb", _qhs.CmpEq("idupb", idupb), "title");
			if (title == null)
			{
				title = "[upb di codice " + idupb + "]";
			}

			__UpbTitles[str_idupb] = title.ToString();
			return title.ToString();
		}

		void AddVoceUPBIva(DataRow R)
		{
			if (R["idupb_iva"] == DBNull.Value) return;
			R["!codeupb_iva"] = GetTitleForIdUPB(R["idupb_iva"]);
		}

		#endregion

		#region CreaAccertamentiContrattiAttivi
		/// <summary>
		/// Crea accertamenti contratti attivi
		/// Questa funzione non dovrebbe essere attiva nel caso di db monofase, che in quel caso saranno creati in fase di incasso
		/// </summary>
		public void ElaboraContabilizzazioni()
		{
			_uiOperations.SetButtonEnabled("btnElaboraContabilizzazioni", false);
			//necessita di DS.estimatedetail non vuoto
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.flussoincassi.Clear();
			DS.flussoincassidetail.Clear();
			DS.incomelastestimatedetail.Clear();
			DataRow[] SelectedRows = _uiOperations.GetDataGridSelectedRow("dgrDettContrattiAttivi");//GetGridSelectedRows(dgrDettContrattiAttivi);
			var resFin = true;

			foreach (var estimateRow in DS.estimate)
			{
				addEstimateDateToDict(estimateRow);
			}

			for (int i = 0; i < SelectedRows.Length; i++)
			{
				resFin = creaAccertamentiDettagliContratti(new estimatedetailRow[] { (estimatedetailRow)SelectedRows[i] });
				if (!resFin) break;
			}

			DataSet dSupdated;
			if (resFin) resFin = doSave(out dSupdated);

			azzeraTutto();

			if (resFin) CercaContrattiDaContabilizzare();
			//la doSave mostra già messaggi più specifici nel caso in cui fallisca. 
			// Questo messaggio può essere fuorviante perchè potrebbe non esserci nessun movimento e quindi NON essere un errore
			//if (!resFin) {
			//    show(this, @"Errore nell'elaborazione della generazione dei movimenti finanziari");
			//}

			_logger.DisplayMessage();
		}

		private bool creaAccertamentiDettagliContratti(estimatedetailRow[] estimatedetailRow)
		{
			//RowChange.SetOptimized(DS.income,true);
			//RowChange.ClearMaxCache(DS.income);

			bool res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.imponibile, false);
			if (res)
				res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.iva, false);
			if (res)
				res = creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow, TipoElaborazioneIncassi.totali, false);
			return res;
		}

		#endregion

		private bool doSave(out DataSet dSupdated)
		{
			dSupdated = null;

			if (!DS.HasChanges())
			{
				_logger.Info("Nessun movimento da generare", true);
				return false;
			}

			var dsp = DS.Copy();
			var faseincasso = CfgFn.GetNoNullInt32(_security.GetSys("maxincomephase"));

			var ga = new GestioneAutomatismi(_manageForm.getParentForm(), _conn as DataAccess, _dispatcher as MetaDataDispatcher,
				dsp, 1, faseincasso, "income", _manageForm.getShowForm());
			ga.integraCopiaDatiDaDatasetPrincipaleASecondario();
			copyRelation(ga.DSP, dsp.Relations["FK_estimatedetail_estimate"]);
			copyRelation(ga.DSP, dsp.Relations["FK_flussoincassi_flussoincassidetail"]);
			copyRelation(ga.DSP, dsp.Relations["flussocrediti_flussocreditidetail"]);

			copyRelation(ga.DSP, dsp.Relations["estimatedetail_flussocreditidetail"]);
			copyRelation(ga.DSP, dsp.Relations["invoicedetail_flussocreditidetail"]);
			copyRelation(ga.DSP, dsp.Relations["invoice_incomeinvoice"]);

			//copyRelation(ga.DSP, dsp.Relations["income_incomevar"]); già ci dovrebbe essere

			copyRelation(ga.DSP, dsp.Relations["invoice_invoicedetail"]);

			copyRelation(ga.DSP, dsp.Relations["ivaregisterinvoice"]);
			copyRelation(ga.DSP, dsp.Relations["flussocrediti_webpayment"]);

			copyRelation(ga.DSP, dsp.Relations["income_incomeinvoice"]);
			copyRelation(ga.DSP, dsp.Relations["income_invoicedetail"]);
			copyRelation(ga.DSP, dsp.Relations["income_invoicedetail1"]);

			copyRelation(ga.DSP, dsp.Relations["income_incomeestimate"]);
			copyRelation(ga.DSP, dsp.Relations["estimate_incomeestimate"]);
			copyRelation(ga.DSP, dsp.Relations["income_estimatedetail"]);
			copyRelation(ga.DSP, dsp.Relations["income_estimatedetail1"]);
			copyRelation(ga.DSP, dsp.Relations["income_incomelastestimatedetail"]);

			bool res;
			if (DS.income.Rows.Count > 0)
			{
				ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
				res = ga.GeneraAutomatismiAfterPost(_manageForm.getShowForm());
				if (!res)
				{
					_logger.Error("Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
					return false;
				}
			}

			res = _fsPostData.runGaPostData(ga, _dispatcher as MetaDataDispatcher);

			DS.AcceptChanges();
			DS.incomeestimate.Clear();
			DS.incomeinvoice.Clear();
			DS.incomelastestimatedetail.Clear();
			//DS.estimatedetail.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();

			dSupdated = ga.DSP;

			aggiornaChiaviDs(dSupdated); //travasa i dati da DSP a DS

			ricalcolaFlagElaborato();

			if (res)
			{
				_logger.Info("Salvataggio dati effettuato.", true);
				viewAutomatismi(ga.DSP);
			}

			return res;
		}

		private void copyRelation(DataSet dest, DataRelation sourceRel)
		{
			if (dest.Relations.Contains(sourceRel.RelationName)) return;
			if (!dest.Tables.Contains(sourceRel.ParentTable.TableName))
			{
				dest.Merge(sourceRel.ParentTable, false, MissingSchemaAction.Add);
			}

			if (!dest.Tables.Contains(sourceRel.ChildTable.TableName))
			{
				dest.Merge(sourceRel.ChildTable, false, MissingSchemaAction.Add);
			}

			DataTable parentDest = dest.Tables[sourceRel.ParentTable.TableName];
			DataTable childDest = dest.Tables[sourceRel.ChildTable.TableName];

			var destParentColumns = sourceRel.ParentColumns.Select(c => parentDest.Columns[c.ColumnName]).ToArray();
			var childParentColumns = sourceRel.ChildColumns.Select(c => childDest.Columns[c.ColumnName]).ToArray();
			var destRel = new DataRelation(sourceRel.RelationName, destParentColumns, childParentColumns);
			dest.Relations.Add(destRel);
		}

		/// <summary>
		/// In ds i dati aggiornati su flussocrediti flussoincassi invoice estimate ivaregister
		/// </summary>
		/// <param name="dSupdated"></param>
		/// <returns></returns>
		private bool aggiornaChiaviDs(DataSet sourceDataSet)
		{
			QueryCreator.MarkEvent("aggiornaChiaviDs()");
			try
			{
				DS.AcceptChanges();
				foreach (string tableName in new string[] {
					"flussocrediti", "flussocreditidetail", "flussoincassi", "flussoincassidetail",
					"invoice", "invoicedetail", "ivaregister", "estimate", "estimatedetail"
				})
				{
					DS.Tables[tableName].Clear();
					if (sourceDataSet.Tables.Contains(tableName))
					{
						DS.Tables[tableName].Merge(sourceDataSet.Tables[tableName], false);
						QueryCreator.MarkEvent($"Merge(sourceDataSet.Tables[{tableName}])");
						DS.Tables[tableName].AcceptChanges();
					}
				}

			}
			catch (Exception ex)
			{
				_logger.Error($"Errore nell\'aggiornamento delle chiavi del db! Processo Terminato\n{ex.Message}");
				return false;
			}

			return true;
		}

		private void AddVoceCreditore(DataRow R)
		{
			if (R["idreg"] == DBNull.Value) return;
			R["!registry"] = GetTitleForIdReg(R["idreg"]);
		}

		/// <summary>
		/// Crea gli accertamenti relativi ai dettagli contratti attivi. Non opera sui contratti attivi a gestione differita se non in fase incassi
		/// Non cancella nulla dal ds
		/// </summary>
		/// <param name="estimatedetailRows"></param>
		/// <param name="tipoElaborazione"></param>
		/// <param name="faseIncassi"></param>
		/// <returns></returns>
		private bool creaAccertamentiDaDettagliContrattiAttivi(estimatedetailRow[] estimatedetailRows, TipoElaborazioneIncassi tipoElaborazione, bool faseIncassi)
		{
			//QueryCreator.MarkEvent("creaAccertamentiDaDettagliContrattiAttivi");
			// To Do: modificare l'interfaccia uniformando le chiamate
			var fasecontratto = CfgFn.GetNoNullInt32(_security.GetSys("estimatephase"));
			var fasecred = CfgFn.GetNoNullInt32(_security.GetSys("incomeregphase"));
			var fasebilancio = CfgFn.GetNoNullInt32(_security.GetSys("incomefinphase"));

			var faseinizio = 1;
			var fasefine = fasecontratto;

			var metaIncome = _dispatcher.Get("income");
			var metaIncomeYear = _dispatcher.Get("incomeyear");
			var metaIncomeLast = _dispatcher.Get("incomelast");
			var metaIncomeEstimate = _dispatcher.Get("incomeestimate");
			var metaEstimateDetail = _dispatcher.Get("estimatedetail");
			metaIncome.SetDefaults(DS.income);
			metaIncomeYear.SetDefaults(DS.incomeyear);
			metaIncomeLast.SetDefaults(DS.incomelast);
			metaIncomeEstimate.SetDefaults(DS.incomeestimate);
			metaEstimateDetail.SetDefaults(DS.estimatedetail);
			MetaData.SetDefault(DS.income, "parentidinc", DBNull.Value);
			//estimatedetailRow[] selectedRows;
			//if (estimatedetailRow != null) {
			//    selectedRows = new estimatedetailRow[1];
			//    selectedRows[0] = estimatedetailRow;
			//}
			//else {
			//    selectedRows = DS.estimatedetail.allCurrent().ToArray();
			//}

			//if (selectedRows.Length == 0) {
			//    show("Righe di Dettaglio Assenti", "Errore");
			//    return false;
			//}

			var currcausale = 1; // contabilizzazione totale

			var mov = DS.income;
			var impMov = DS.incomeyear;

			MetaData.SetDefault(DS.incomeyear, "ayear", esercizio);

			DataRow incomeToLink = null;
			// Crea Contabilizzazioni dei dettagli contratto attivo elencati
			foreach (var rDet in estimatedetailRows)
			{
				if (rDet["stop"] != DBNull.Value) continue;

				var currUpb = rDet.idupb;
				var currUpbIva = rDet.idupb_iva;
				//Se è valorizzata la Causale finanziaria IVA ma non è valorizzato l'UPB iva,
				// valorizzo l'upb iva al fine di generare un incasso separato per l'IVA [16307]
				if ((rDet.idfinmotive_iva != null) && (currUpb != null) && (currUpbIva == null))
				{
					currUpbIva = currUpb;
				}
				switch (tipoElaborazione)
				{
					case TipoElaborazioneIncassi.totali:
						//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
						if (currUpb == null || currUpbIva != null) continue; //i totali devono avere un upb_iva NON impostato per essere elaborati
						break;
					case TipoElaborazioneIncassi.imponibile:
						if (currUpb == null || currUpbIva == null) continue; // imponibile  o iva è ammesso solo se c'è currUPB
						break;
					case TipoElaborazioneIncassi.iva:
						if (currUpb == null || currUpbIva == null) continue; // imponibile  o iva è ammesso solo se c'è currUPB
						break;
				}

				// possono essere dettagli contratto attivo non collegati a  fattura
				// Prima di tutto vedo se la contabilizzazione è differita
				string errore;
				var gestionedifferita = getGestioneDifferita(rDet.idestimkind, out errore);
				if (gestionedifferita == "S" && !faseIncassi) continue; //salta questo dettaglio
				var aDate = getDateContrattoAttivo(rDet, out errore); //_conn.readValue("estimate", q.mCmp(rDet, "idestimkind", "yestim", "nestim"), "adate");

				DataRow parentR = null;
				//spostato sotto
				//var amount = rDet.taxable;
				if (tipoElaborazione == TipoElaborazioneIncassi.iva)
				{
					if (rDet.idinc_ivaValue != DBNull.Value) continue;
				}
				else
				{
					if (rDet.idinc_taxableValue != DBNull.Value) continue;
				}

				decimal imponibile = CfgFn.GetNoNullDecimal(rDet.taxable);
				decimal sconto = CfgFn.GetNoNullDecimal(rDet.discount);
				decimal quantita = CfgFn.GetNoNullDecimal(rDet.number);
				decimal imponibiletot = CfgFn.GetNoNullDecimal(CfgFn.RoundValuta((imponibile * quantita * (1 - sconto))));
				var iva = CfgFn.GetNoNullDecimal(rDet.tax);

				object idUpbSelected = DBNull.Value;
				decimal amount = 0;
				// Determinazione del capitolo di bilancio in base alla causale finanziaria 
				object idfinSelected = DBNull.Value;
				var Curridfin = getBilancioFromCausaleFin(rDet.idfinmotive, out errore);
				string erroreiva;
				var Curridfin_iva = getBilancioFromCausaleFin(rDet.idfinmotive_iva, out erroreiva);
				switch (tipoElaborazione)
				{
					case TipoElaborazioneIncassi.totali:
						//Elaborazione pre modifica split fasi - esegue solo con upb_iva == null
						currcausale = 1;
						amount = imponibiletot + iva;
						idUpbSelected = currUpb;
						idfinSelected = Curridfin;
						break;
					case TipoElaborazioneIncassi.imponibile:
						// currUpb è sicuramente non null
						currcausale = 3;
						amount = imponibiletot;
						idUpbSelected = currUpb;
						idfinSelected = Curridfin;
						break;
					case TipoElaborazioneIncassi.iva:
						// curUpbIva è sicuramente non null
						currcausale = 2;
						amount = iva;
						idUpbSelected = currUpbIva;
						idfinSelected = (Curridfin_iva == DBNull.Value) ? Curridfin : Curridfin_iva;
						break;
				}

				if (amount == 0) continue; // non dovrebbe essere mai zero 
				for (var faseCorrente = faseinizio; faseCorrente <= fasefine; faseCorrente++)
				{
					mov.Columns["nphase"].DefaultValue = faseCorrente;

					var newEntrataRow = metaIncome.Get_New_Row(parentR, mov);
					if (faseCorrente == fasecontratto) incomeToLink = newEntrataRow;
					parentR = newEntrataRow;
					// Selezione UPB e Voce di Bilancio in modo completamente automatico
					var idmanagerSelected = getUpbManager(idUpbSelected, out errore); //_conn.readValue("upb", q.eq("idupb", idUpbSelected), "idman");
					if (errore != "")
					{
						_logger.Error($"{errore} nel dettaglio {rDet.detaildescription} codice bollettino {rDet.iduniqueformcode}");
						return false;
					}

					if (errore != "")
					{
						_logger.Error($"{errore} nel dettaglio {rDet.detaildescription} codice bollettino {rDet.iduniqueformcode}");
						return false;
					}

					fillMovimento(newEntrataRow, idmanagerSelected, rDet["idreg"], rDet["detaildescription"].ToString());

					newEntrataRow["doc"] = $"C.A.{rDet["idestimkind"]}/{rDet["yestim"].ToString().Substring(2, 2)}/{rDet["nestim"].ToString().PadLeft(6, '0')}";

					newEntrataRow["docdate"] = aDate ?? DBNull.Value;

					newEntrataRow["nphase"] = faseCorrente;
					newEntrataRow["idreg"] = faseCorrente < fasecred ? DBNull.Value : rDet["idreg"];

					var newImpMov = impMov.NewRow();

					fillImputazioneMovimento(newImpMov, CfgFn.GetNoNullDecimal(amount), idfinSelected, idUpbSelected);

					newImpMov["idinc"] = newEntrataRow["idinc"];
					newImpMov["ayear"] = esercizio;

					if (faseCorrente < fasebilancio)
					{
						newImpMov["idfin"] = DBNull.Value;
						newImpMov["idupb"] = DBNull.Value;
					}

					impMov.Rows.Add(newImpMov);
					// nel monofase mi accerto anche di calcolare le class. Siope da documento
					if (faseCorrente == _nphaseSiopeE && newcomputesorting == "S" && faseentratamax == 1 /*monofase*/)
					{
						// Classificazione SIOPE impostata su documento
						string errori;
						var idsor = rDet.idsor_siope ;
						//Altrimenti leggo class SIOPE impostata sulla causale di ricavo
						if (idsor == null)
							idsor = getSiopeForAccMotive(rDet.idaccmotive, out errori);
						fillIncomeSorted(newEntrataRow, idsor, CfgFn.GetNoNullDecimal(amount));
					}
				}

				//Aggiunge la riga in IncomeEstimate
				var incEstimRow = metaIncomeEstimate.Get_New_Row(incomeToLink, DS.incomeestimate);
				incEstimRow["movkind"] = currcausale;
				incEstimRow["idestimkind"] = rDet["idestimkind"];
				incEstimRow["yestim"] = rDet["yestim"];
				incEstimRow["nestim"] = rDet["nestim"];

				//Effettua i collegamenti con il dettaglio
				if (incomeToLink != null)
				{
					if ((tipoElaborazione != TipoElaborazioneIncassi.iva)) rDet["idinc_taxable"] = incomeToLink["idinc"];
					if ((tipoElaborazione == TipoElaborazioneIncassi.iva)) rDet["idinc_iva"] = incomeToLink["idinc"];
				}
			}

			return true;
		}

		private object getBilancioFromCausaleFin(object idfinmotive, out string errori)
		{
			errori = "";
			if (idfinmotive == DBNull.Value || idfinmotive == null)
			{
				errori = " Causale finanziaria non trovata";
				return DBNull.Value;
			}

			var idfinmotiveS = idfinmotive.ToString();
			if (_vociBilancioEntrata.ContainsKey(idfinmotiveS)) return _vociBilancioEntrata[idfinmotiveS];
			var idfin = _conn.readValue("finmotivedetail",
				q.eq("ayear", esercizio) & q.eq("idfinmotive", idfinmotiveS), "idfin");
			if (idfin == null || idfin == DBNull.Value)
			{
				errori = "Voce di bilancio associata alla causale finanziaria non trovata";
				return DBNull.Value;
			}

			_vociBilancioEntrata[idfinmotiveS] = CfgFn.GetNoNullInt32(idfin);
			return _vociBilancioEntrata[idfinmotiveS];
		}

		private struct messaggio
		{
			public string msg;
			public bool error;
		}

		private enum TipoElaborazioneIncassi
		{
			imponibile,
			iva,
			totali
		}

		private void initPBar(string op, int nOperations)
		{
			_uiOperations.SetText("labPBar", "Operazione in corso: " + op);
			_uiOperations.InitProgress(nOperations);
			_uiOperations.SetControlVisibility("pBar", true);
			_uiOperations.DoEvents();
		}

		private void incPBar()
		{
			_uiOperations.UpdateProgress(1);
			_uiOperations.DoEvents();
		}

		private void closePBar()
		{
			_uiOperations.SetText("labPBar", "");
			_uiOperations.InitProgress(0);
			_uiOperations.SetControlVisibility("pBar", false);
			_uiOperations.DoEvents();
		}

		private void azzeraTutto()
		{
			DS.income.Clear();
			DS.incomelast.Clear();
			DS.income.Clear();
			DS.incomeyear.Clear();
			DS.incomesorted.Clear();
			DS.flussoincassi.Clear();
			DS.flussoincassidetail.Clear();

			DS.invoice.Clear();
			DS.invoicedetail.Clear();

			DS.estimate.Clear();
			DS.estimatedetail.Clear();
			DS.incomelastestimatedetail.Clear();
			DS.ivaregister.Clear();

			DS.incomeinvoice.Clear();
			DS.incomeestimate.Clear();

			DS.flussocrediti.Clear();
			DS.flussocreditidetail.Clear();

		}
	}
}
