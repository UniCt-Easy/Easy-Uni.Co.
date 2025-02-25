
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


using ServizioRendicontazione.Models;
using ServizioRendicontazione.ApiModels;
using ServizioRendicontazione.Repositories;
using ServizioRendicontazione.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ServizioRendicontazione
{
	public partial class Rendicontazione
	{
		private string settingsFile = "appsettingsRendicontazione.json";

        ApplicationDbContext context;
        Repository _repository;

        public Rendicontazione()
		{
			DoInit();
		}

		public string DoInit(string customSettingsFile = "")
		{
            string resultConn = "Impossibile connettersi al database";

            try
			{
				string _settingsFile = settingsFile;
				if (!string.IsNullOrEmpty(customSettingsFile))
					_settingsFile = customSettingsFile;

                string appsettingJsonFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _settingsFile);
                if (!File.Exists(appsettingJsonFullName))
                    return $"File di configurazione non trovato: {customSettingsFile}";

                var configuration = new ConfigurationBuilder().AddJsonFile(appsettingJsonFullName);
				var config = configuration.Build();
				var appSettings = config.GetSection("AppSettings");

				// Cu
				common.cu = appSettings.GetChildren().FirstOrDefault(w => w.Key == "cu").Value;

				// years to consider
				common.yearToConsider = int.Parse(appSettings.GetChildren().FirstOrDefault(w => w.Key == "yearToConsider").Value);

				// Connection
				common.connstring = appSettings.GetChildren().FirstOrDefault(w => w.Key == "connString").Value;
				common.schemaAmm = appSettings.GetChildren().FirstOrDefault(w => w.Key == "schemaAmm").Value;
				common.schemaDbo = appSettings.GetChildren().FirstOrDefault(w => w.Key == "schemaDbo").Value;

				// API
				common.api_url = appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_url").Value;
				common.limit = int.Parse(appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_limit").Value);
				common.all = appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_all").Value == "Y" ? true : false;

				// Authorization Type
				common.auth_type_basic = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_type").Value == "BASIC" ? true : false;

				// Authorization Type
				common.auth_basic_token = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_basic_token").Value;

				// Authorization Api Proxy
				common.auth_api_url = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_url").Value;
				common.auth_api_remote = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_remote").Value;
				common.auth_api_key = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_key").Value;
				common.auth_api_key_value = appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_key_value").Value;

                DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(common.connstring).Options;
                context = new ApplicationDbContext(options);
                _repository = new Repository(context);

                string Server = common.connstring.Substring(7, common.connstring.IndexOf(";", 10) - 7);
                int cat = common.connstring.IndexOf("Catalog", 0);
                int semicomma = common.connstring.IndexOf(";", common.connstring.IndexOf("Catalog", 0) + 10);
                string Database = common.connstring.Substring(cat + 8, semicomma - cat - 8);

                resultConn = $"Connesso a: {Server} - {Database}";
            }
			catch (Exception Ex)
			{
				common.logInfo(Ex.Message + Ex.InnerException?.Message);
			}

            return resultConn;
        }


        // ===================================================================================================================
        // ¦¦¦¦¦¦   ¦¦¦¦¦¦¦   ¦¦¦¦¦¦   ¦¦  ¦¦¦¦¦¦¦  ¦¦¦¦¦¦¦  ¦¦¦¦¦¦   ¦¦    ¦¦
        // ¦¦   ¦¦  ¦¦       ¦¦        ¦¦  ¦¦         ¦¦     ¦¦   ¦¦   ¦¦  ¦¦
        // ¦¦¦¦¦¦   ¦¦¦¦¦    ¦¦   ¦¦¦  ¦¦  ¦¦¦¦¦¦¦    ¦¦     ¦¦¦¦¦¦      ¦¦
        // ¦¦   ¦¦  ¦¦       ¦¦    ¦¦  ¦¦       ¦¦    ¦¦     ¦¦   ¦¦     ¦¦
        // ¦¦   ¦¦  ¦¦¦¦¦¦¦   ¦¦¦¦¦¦   ¦¦  ¦¦¦¦¦¦¦    ¦¦     ¦¦   ¦¦     ¦¦
        // ===================================================================================================================
        public async Task DelLez(int idLezione)
        {
            _repository.DelLez(idLezione);
        }

        public async Task<List<lezdb>> GetLezioniDb(string filterCF, int idReg)
        {
            if (filterCF != "" && idReg == 0)
                idReg = _repository.RegistryIdByRegFc(filterCF);

            if (idReg == 0)
                return null;

            try
            {
                return _repository.Lezioni(idReg);
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        public async Task<List<lezws>> GetLezioni(string filterCF, int filterIdReg)
        {
            string msg = "";

            try
            {
                bool success = true;

                if (filterIdReg == 0 && filterCF == "")
                    return new List<lezws>() { new lezws() { data = new DateTime(), valws = "Inserire un idreg o un cf" } };

                if (filterCF != "" && filterIdReg == 0)
                    filterIdReg = _repository.RegistryIdByRegFc(filterCF);
                else if (filterCF == "" && filterIdReg != 0)
                    filterCF = _repository.RegistryCfByRegId(filterIdReg);

                if (string.IsNullOrEmpty(filterCF))
                {
                    return new List<lezws>() { new lezws() { data = new DateTime(), valws = "idReg non trovato!" } };
                }

                List<RegistroDocenteConDettagli> ListaRegistroDocenteConDettagli = new List<RegistroDocenteConDettagli>();
                List<RegistroDocente> ListaRegistroDocente = new List<RegistroDocente>();

                // ============================================================================================================================
                // DIARI CURR YEAR
                // ============================================================================================================================
                int thisYear = DateTime.Now.Year;
                int lastYear = thisYear - common.yearToConsider + 1;

                for (int currYear = lastYear; currYear <= thisYear; currYear++)
                {
                    ListaRegistroDocente.AddRange(GetList<RegistroDocente>(out msg, out success, null, $"&aaOffId={currYear}"));

                    if (!success)
                    {
                        if (!msg.Contains("Count: 0"))
                            return new List<lezws>() { new lezws() { data = new DateTime(), valws = $"Errore Get Registro Docente per l'annoAccademico {currYear}: {msg}" } };
                    }
                }

                if (ListaRegistroDocente.Count == 0)
                {
                    return new List<lezws>() { new lezws() { data = new DateTime(), valws = $"Nessun registro docente per l'anno {lastYear}-{thisYear}" } };
                }

                // ==============================================================
                // LISTA DEI CF DEI REGISTRI DOCENTI
                // ==============================================================
                List<long> ListaIdDocentiPresenti = ListaRegistroDocente.Where(w => w.codFis == filterCF).Select(s => s.regId).Distinct().ToList();

                foreach (long regId in ListaIdDocentiPresenti)
                {
                    // ============================================================================================================================
                    // WS REGISTRO DOCENTE, ottengo la rendicontazione del docente
                    // ============================================================================================================================
                    RegistroDocenteConDettagli registroDocenteConDettagli = Get<RegistroDocenteConDettagli>(out msg, out success, new object[1] { regId });

                    if (!success)
                        return new List<lezws>() { new lezws() { data = new DateTime(), valws = msg } };

                    // Se esiste
                    if (registroDocenteConDettagli != null)
                    {
                        // Controllo la presenza di attività didattica
                        if (registroDocenteConDettagli.attivita != null)
                        {
                            // e lo aggiungo
                            if (registroDocenteConDettagli.attivita.Count() > 0)
                            {
                                ListaRegistroDocenteConDettagli.Add(registroDocenteConDettagli);
                            }
                        }
                    }
                }

                List<RegistroDocenteDett> lezioni = ListaRegistroDocenteConDettagli.SelectMany(s => s.attivita).ToList();

                return lezioni.OrderBy(o => DateTime.Parse(o.data)).Select(s => new lezws() { data = DateTime.Parse(s.data.Substring(0, 11) + s.oraInizio), valws = s.oraInizio + " - " + s.oraFine }).ToList();
            }
            catch (Exception Ex)
            {
                return new List<lezws>() { new lezws() { data = new DateTime(), valws = "Errore InsLezioni: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace } };
            }
        }

        public void InsLezioni(string filterCF = "", int filterIdReg = 0)
		{
			common.logInfo("=========================================================================");
			common.logInfo($"Lezioni Start");

			try
			{
				DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(common.connstring).Options;

				using (var context = new ApplicationDbContext(options))
				{
					Repository _repository = new Repository(context);

					string msg = "";
					bool success = false;

                    if (!string.IsNullOrEmpty(filterCF) && filterIdReg == 0)
                        filterIdReg = _repository.RegistryIdByRegFc(filterCF);
                    else if (string.IsNullOrEmpty(filterCF) && filterIdReg != 0)
                        filterCF = _repository.RegistryCfByRegId(filterIdReg);

                    // ============================================================================================================================
                    // LEZIONI FROM YEAR TO YEAR
                    // ============================================================================================================================
                    int thisYear = DateTime.Now.Year;
					int lastYear = thisYear - common.yearToConsider + 1;

					DateTime fromDate = new DateTime(lastYear, 1, 1, 0, 0, 0);
					DateTime toDate = new DateTime(thisYear, 12, 31, 23, 59, 59);

					// ============================================================================================================================
					// VARIABILI
					// ============================================================================================================================
					string ORIENTAMENTO_UNICO = "-";
					string CANALE_UNICO = "Canale Unico";
					string CURRICULUM_UNICO = "Curriculum Unico";
					string AFFIDAMENTO_DI_INCARICO = "Affidamento di incarico";

					int CREDITI_FORMATIVI_60 = 60;
					int iderogazkind = 1;                   // Convenzionale
					int idmacroareadidattica = 1;           // Macroarea 1, non si riesce a recuperarla
					int idistitutokind = 9;                 // Università statale
					int idregUniv = 3256;                   // Utente Easy: Università di Lecce
					int parIdStruttura = 9;                 // Struttura padre
					int idduratakind = 1;                   // Anni
					int idaffidamentokind = 1;              // Affidamento di incarico

					int idstrutturakind_facolta = 12;       // Facoltà
					int idstrutturakind_dipartimento = 1;   // Dipartimento
					int idstrutturakind_altro = 11;         // Altro

					int sede_base = 1;                      // Es: Lecce

					// ============================================================================================================================
					// CACHE
					// ============================================================================================================================
					common.logInfo($"B - Loading Cache");

					List<classescuolakind> ListaTipoClasseScuola =	_repository.AllTipoClasseScuola();		// classescuolakind
					List<corsostudiokind> ListaTipoCorsoStudio =	_repository.AllTipoCorsoStudio();		// corsostudiokind
					List<orakind> ListaTipoLezione =				_repository.AllTipoLezione();			// orakind

					List<areadidattica> ListaAreaDidattica =		_repository.AllAreaDidattica();			// areadidattica
					List<insegn> ListaAttivitaDidattica =			_repository.AllAttivitaDidattica();		// insegn

					List<classescuola> ListaClasseScuola =			_repository.AllClasseScuola();			// classescuola
					List<corsostudionorma> ListaCorsoStudioNorma =	_repository.AllCorsoStudioNorma();		// corsostudionorma
					List<corsostudio> ListaCorsoStudio =			_repository.AllCorsoStudio();			// corsostudio

					List<sede> ListaSede =							_repository.AllSede();					// sede
					List<struttura> ListaStruttura =				_repository.AllStruttura();				// struttura

					List<didprog> ListaDidatticaProgrammata =		_repository.AllDidatticaProgrammata();
					List<didprogcurr> ListaCurriculum =				_repository.AllCurriculum(ListaDidatticaProgrammata.Select(s => s.iddidprog).ToList());
					List<didprogori> ListaOrientamento =			_repository.AllOrientamento(ListaCurriculum.Select(s => s.iddidprogcurr).ToList());
					List<didproganno> ListaAnno =					_repository.AllAnno(ListaOrientamento.Select(s => s.iddidprogori).ToList());
					List<didprogporzanno> ListaPorzioneAnno =		_repository.AllPorzioneAnno(ListaAnno.Select(s => s.iddidproganno).ToList());
					List<attivform> ListaAttivitaFormativa =		_repository.AllAttivitaFormativa(ListaPorzioneAnno.Select(s => s.iddidprogporzanno).ToList());
					List<canale> ListaCanale =						_repository.AllCanale(ListaAttivitaFormativa.Select(s => s.idattivform).ToList());
					List<affidamento> ListaAffidamento =			_repository.AllAffidamento(ListaCanale.Select(s => s.idcanale).ToList());

					List<lezione> ListaLezione =					_repository.AllLezione(filterIdReg);

					List<lezione> ListaLezioniToAdd = new List<lezione>();

					int lezioniInseriteCnt = 0;
					int lezioniEliminateCnt = 0;
					int lezioniAggiornateCnt = 0;

					List<RegistroDocenteConDettagli> ListaRegistroDocenteConDettagli = new List<RegistroDocenteConDettagli>();
					Dictionary<string, CorsoDiStudioConStruttura> listaCorsoDiStudioConStruttura = new Dictionary<string, CorsoDiStudioConStruttura>();
					Dictionary<int, CorsoDiStudioConDettagli> listaCorsoDiStudioConDettagli = new Dictionary<int, CorsoDiStudioConDettagli>();
					List<RegistroDocente> ListaRegistroDocente = new List<RegistroDocente>();

					// ============================================================================================================================
					// DIARI FROM STARTYEAR TO CURR YEAR
					// ============================================================================================================================
					common.logInfo($"C - Call Web Services");

					for (int currYear = lastYear; currYear <= thisYear; currYear++)
					{
						// Lezioni dell'anno
						DateTime annoStart = new DateTime(currYear, 1, 1, 0, 0, 0);
						DateTime annoStop = new DateTime(currYear + 1, 1, 1, 0, 0, 0);

						int thisLezioniCnt = ListaLezione.Where(w => annoStart < w.start && w.start < annoStop).Count();
						common.logInfo($"Lezioni per l'annoAccademico {currYear}: {thisLezioniCnt}");

						ListaRegistroDocente.AddRange(GetList<RegistroDocente>(out msg, out success, null, $"&aaOffId={currYear}"));

						if (!success)
						{
							if (msg.Contains("Count: 0"))
								common.logInfo($"Registro Docente per l'annoAccademico {currYear}: 0");
							else
								common.logInfo($"Errore Get Registro Docente per l'annoAccademico {currYear}: {msg}");
						}
						else
						{
							common.logInfo($"Registro docente per l'annoAccademico {currYear}: {msg.Split("Count: ")[1].Replace("\r\n", "")}");
						}
					}

					if (ListaRegistroDocente.Count == 0)
					{
						common.logInfo($"Nessun registro docente per gli anni {lastYear}-{thisYear}");
						common.logInfo("InsLezioni End");
						return;
					}

					// ==============================================================
					// LISTA DEI CF DEI REGISTRI DOCENTI
					// ==============================================================
					List<string> listaCf = ListaRegistroDocente.Select(s => s.codFis).Distinct().ToList();

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF E CHE
					// EFFETTIVAMENTE PARTECIPANO AI PROGETTI DI RICERCA NELL'ANNO
					// ==============================================================
					List<registryMin> ListaIdRegCfDocenti = _repository.RegistryByCf(listaCf, lastYear, thisYear);

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					List<string> ListaCfRegDocenti = ListaIdRegCfDocenti.Select(s => s.Cf).ToList();

					// ==============================================================
					// FILTRO !!!
					// ==============================================================
					if (!string.IsNullOrEmpty(filterCF))
						ListaCfRegDocenti = ListaCfRegDocenti.Where(w => w == filterCF).ToList();

					// ==============================================================
					// PER OGNI REGISTRO DOCENTE PRESENTE IN REGISTRY
					// ==============================================================
					List<long> ListaIdDocentiPresenti = ListaRegistroDocente.Where(w => ListaCfRegDocenti.Contains(w.codFis)).Select(s => s.regId).Distinct().ToList();

					// Info D
					common.logInfo($"D - ListaIdDocentiPresenti: {ListaIdDocentiPresenti.Count()}");

					foreach (long regId in ListaIdDocentiPresenti)
					{
						// ============================================================================================================================
						// WS REGISTRO DOCENTE, ottengo la rendicontazione del docente
						// ============================================================================================================================
						RegistroDocenteConDettagli registroDocenteConDettagli = Get<RegistroDocenteConDettagli>(out msg, out success, new object[1] { regId });

						// Se esiste
						if (registroDocenteConDettagli != null)
						{
							// Controllo la presenza di attività didattica
							if (registroDocenteConDettagli.attivita != null)
							{
								// e lo aggiungo
								if (registroDocenteConDettagli.attivita.Count() > 0)
								{
									ListaRegistroDocenteConDettagli.Add(registroDocenteConDettagli);
								}
							}
						}

					}

					// ==============================================================
					// Logistiche
					// ==============================================================
					List<LogisticaPerAnno> logistichePerAnno = ListaRegistroDocenteConDettagli
						.GroupBy(dett => dett.aaOffId)
						.Select(group => new LogisticaPerAnno
						{
							aaOffId = group.Key,
							logistica = group.SelectMany(dett => dett.logistica).ToArray()
						})
						.ToList();

					// Info E
					common.logInfo($"E - logistichePerAnno: {logistichePerAnno.Count()}");

                    foreach (LogisticaPerAnno logisticaPerAnno in logistichePerAnno)
					{
						int annoAccademico = logisticaPerAnno.aaOffId;
						string aaaa_aaaa = get_aaaa_aaaa(annoAccademico);
						RegistroDocenteLog[] logistiche = logisticaPerAnno.logistica;

						foreach (RegistroDocenteLog registroDocenteLogistica in logistiche)
						{
							
							// ==============================================================
							// Attività Didattica
							// =============================================================
							int attivitaDidatticaId = (int)registroDocenteLogistica.adId;
							string attivitaDidatticaCodice = registroDocenteLogistica.adCod;
							string attivitaDidatticaDescrizione = registroDocenteLogistica.adDes;

							// ==============================================================
							// Corso di Studio
							// ==============================================================
							int corsoDiStudioId = (int)registroDocenteLogistica.cdsId;
							string corsoDiStudioCodice = registroDocenteLogistica.cdsCod;
							string corsoDiStudioDescrizione = registroDocenteLogistica.cdsDes;

							// ==============================================================
							// Get Corso di Studio from API
							// ==============================================================
							CorsoDiStudioConStruttura corso = null;
							if (!listaCorsoDiStudioConStruttura.ContainsKey(corsoDiStudioCodice))
							{
								CorsoDiStudioConStruttura corsoDiStudioConStruttura = Get<CorsoDiStudioConStruttura>(out msg, out success, null, $"&cdsCod={corsoDiStudioCodice}");

								listaCorsoDiStudioConStruttura.Add(corsoDiStudioCodice, corsoDiStudioConStruttura);
							}
							corso = listaCorsoDiStudioConStruttura[corsoDiStudioCodice];

							long? ateneoId = corso.ateneoId;
							string corsoDiStudioDescrizioneEng = corso.cdsDesEng;
							string tipoCorsoDiStudioCodice = corso.tipoCorsoCod;
							string tipoCorsoDiStudioDescrizione = corso.tipoCorsoDes;
							string classeCorsoDiStudioSigla = corso.claCod;
							string classeCorsoDiStudioDescrizione = corso.claDes;
							string normativaCorsoDiStudioDescrizione = corso.normDes;
							string tipoDiTitoloCorsoDiStudioCodice = corso.tipoTititCod;
							string tipoDiTitoloCorsoDiStudioDescrizione = corso.tipoTititDes;
							string areaDidatticaDescrizione = corso.iscedDes;

							// ==============================================================
							// Tipo Corso di Studio - corsostudiokind
							// ==============================================================
							int idcorsostudiokind = 1;
							if (!string.IsNullOrEmpty(tipoCorsoDiStudioDescrizione))
							{
								if (!ListaTipoCorsoStudio.Any(w => w.title == tipoCorsoDiStudioDescrizione))
								{
									// Add Tipo Corso di Studio
									corsostudiokind newCorsostudioKind = _repository.AddTipoCorsoStudio(title: tipoCorsoDiStudioDescrizione);

									if (newCorsostudioKind != null)
										ListaTipoCorsoStudio.Add(newCorsostudioKind);
								}
								// Get Tipo Corso di Studio
								idcorsostudiokind = ListaTipoCorsoStudio.FirstOrDefault(w => w.title == tipoCorsoDiStudioDescrizione).idcorsostudiokind;
							}

							// ==============================================================
							// Attività Didattica - areadidattica
							// ==============================================================
							int? idareadidattica = null;
							if (!string.IsNullOrEmpty(areaDidatticaDescrizione))
							{
								if (!ListaAreaDidattica.Any(w => w.title == areaDidatticaDescrizione))
								{
									// Add Tipo Corso di Studio
									areadidattica newAreadidattica = _repository.AddAreaDidattica(title: areaDidatticaDescrizione,
																				   idmacroareadidattica: idmacroareadidattica,
																					  idcorsostudiokind: idcorsostudiokind);

									if (newAreadidattica != null)
										ListaAreaDidattica.Add(newAreadidattica);
								}
								// Get Tipo Corso di Studio
								idareadidattica = ListaAreaDidattica.FirstOrDefault(w => w.title == areaDidatticaDescrizione).idareadidattica;
							}

							// ==============================================================
							// Tipo Classe Scuola - classescuolakind
							// ==============================================================
							int? idcorsostudiolivello = null;
							string idclassescuolakind = "";
							if (!string.IsNullOrEmpty(tipoDiTitoloCorsoDiStudioCodice))
							{
								if (!ListaTipoClasseScuola.Any(w => w.idclassescuolakind == tipoDiTitoloCorsoDiStudioCodice))
								{
									// Add Tipo Corso di Studio
									classescuolakind newClassescuolaKind = _repository.AddTipoClasseScuola(cod: tipoDiTitoloCorsoDiStudioCodice,
																										 title: tipoDiTitoloCorsoDiStudioDescrizione,
																							 idcorsostudiokind: idcorsostudiokind);
									if (newClassescuolaKind != null)
										ListaTipoClasseScuola.Add(newClassescuolaKind);
								}
								// Get Tipo Corso di Studio
								classescuolakind tipoClasseScuola = ListaTipoClasseScuola.FirstOrDefault(w => w.idclassescuolakind == tipoDiTitoloCorsoDiStudioCodice);
								idclassescuolakind = tipoClasseScuola.idclassescuolakind;
								idcorsostudiolivello = tipoClasseScuola.idcorsostudiolivello;
							}

							// ==============================================================
							// Norma Corso di Studio - corsostudionorma
							// ==============================================================
							int? idcorsostudionorma = null;
							if (!string.IsNullOrEmpty(normativaCorsoDiStudioDescrizione))
							{
								if (!ListaCorsoStudioNorma.Any(w => w.title == normativaCorsoDiStudioDescrizione))
								{
									// Add Tipo Corso di Studio
									corsostudionorma newCorsostudionorma = _repository.AddCorsoStudioNorma(title: normativaCorsoDiStudioDescrizione,
																								  idistitutokind: idistitutokind);

									if (newCorsostudionorma != null)
										ListaCorsoStudioNorma.Add(newCorsostudionorma);
								}
								// Get Tipo Corso di Studio
								idcorsostudionorma = ListaCorsoStudioNorma.FirstOrDefault(w => w.title == normativaCorsoDiStudioDescrizione).idcorsostudionorma;
							}

							int idclassescuolaarea = 1;
							// ==============================================================
							// Classe Scuola - classescuola
							// ==============================================================
							int? idclassescuola = null;
							if (!string.IsNullOrEmpty(classeCorsoDiStudioSigla))
							{
								if (!ListaClasseScuola.Any(w => w.sigla == classeCorsoDiStudioSigla))
								{
									// Add Tipo Corso di Studio
									classescuola newClassescuola = _repository.AddClasseScuola(sigla: classeCorsoDiStudioSigla,
																							   title: classeCorsoDiStudioDescrizione,
																				  idclassescuolakind: tipoDiTitoloCorsoDiStudioCodice,
																				  idcorsostudionorma: idcorsostudionorma,
																				  idclassescuolaarea: idclassescuolaarea);

									if (newClassescuola != null)
										ListaClasseScuola.Add(newClassescuola);
								}
								idclassescuola = ListaClasseScuola.FirstOrDefault(w => w.sigla == classeCorsoDiStudioSigla).idclassescuola;
							}

							// ==============================================================
							// Get Corso di Studio con Dettagli from API
							// ==============================================================
							CorsoDiStudioConDettagli corsoDetail = null;
							if (!listaCorsoDiStudioConDettagli.ContainsKey(corsoDiStudioId))
							{
								CorsoDiStudioConDettagli corsoDiStudioConDettagli = Get<CorsoDiStudioConDettagli>(out msg, out success, new object[1] { corsoDiStudioId }, "");

								listaCorsoDiStudioConDettagli.Add(corsoDiStudioId, corsoDiStudioConDettagli);
							}
							corsoDetail = listaCorsoDiStudioConDettagli[corsoDiStudioId];

							// ==============================================================
							// Corso > Anno Attivazione/Disattivazione
							// ==============================================================
							int? annoAttivazioneCorso = corsoDetail.aaAttId;
							string sitoWeb = corsoDetail.urlSitoWeb;

							// ==============================================================
							// Corso > Sedi Corso
							// ==============================================================
							if (corsoDetail.sediCorso != null)
							{
								foreach (SediCorso sediCorso in corsoDetail.sediCorso)
								{
									if (!ListaSede.Any(w => w.title == sediCorso.sedeDes))
									{
										// Add Tipo Corso di Studio
										sede newSede = _repository.AddSede(idreg: idregUniv,
																		   title: sediCorso.sedeDes);

										if (newSede != null)
											ListaSede.Add(newSede);
									}
								}
							}
							else
							{
								common.logInfo($"Attenzione! Sede corso non trovata!");
							}

							// ==============================================================
							// IdStruttura
							// ==============================================================
							int strutturaId = 0;

							// ==============================================================
							// Corso > Strutture Corso
							// ==============================================================
							if (corsoDetail.struttureCorso != null)
							{
								foreach (StruttureCorso strutturaCorso in corsoDetail.struttureCorso)
								{
									strutturaId = (int)(strutturaCorso.facId ?? 0);
									string strutturaCodice = strutturaCorso.facCod;
									string strutturaDes = strutturaCorso.facDes;
									string strutturaDesEng = strutturaCorso.facDesEng;
									string strutturaCitta = strutturaCorso.facCitta;
									int idsedeStruttura = ListaSede.Any(w => w.title == strutturaCitta) ? ListaSede.FirstOrDefault(w => w.title == strutturaCitta).idsede : sede_base;


									// ==============================================================
									// Struttura
									// ==============================================================
									if (strutturaId != 0)
									{
										if (!ListaStruttura.Any(w => w.title.ToLowerInvariant() == strutturaDes.ToLowerInvariant()))
										{
											int idstrutturakind = strutturaDes.ToLower().Contains("facolta") ? idstrutturakind_facolta :
																 (strutturaDes.ToLower().Contains("dipartimento") ? idstrutturakind_dipartimento :
																														idstrutturakind_altro);

											// Add Tipo Corso di Studio
											struttura newStruttura = _repository.AddStruttura(idstruttura: strutturaId,
																								   codice: strutturaCodice,
																							denominazione: strutturaDes,
																						 denominazioneEng: strutturaDesEng,
																						  idstrutturakind: idstrutturakind,
																							idcorsostudio: corsoDiStudioId,
																									idreg: idregUniv,
																								   idsede: idsedeStruttura,
																						   paridstruttura: parIdStruttura);

											if (newStruttura != null)
												ListaStruttura.Add(newStruttura);
										}
										else
										{
											strutturaId = _repository.UpdateStruttura(strutturaDes, strutturaCodice, strutturaDesEng);
										}
									}


									// ==============================================================
									// Attività Didattica - areadidattica
									// ==============================================================
									if (!ListaAttivitaDidattica.Any(w => w.idinsegn == attivitaDidatticaId))
									{
										// Add Tipo Corso di Studio
										insegn newInsegn = _repository.AddAttivitaDidattica(idinsegn: attivitaDidatticaId,
																							  codice: attivitaDidatticaCodice,
																					   denominazione: attivitaDidatticaDescrizione,
																				   idcorsostudiokind: idcorsostudiokind,
																						 idstruttura: strutturaId,
																					   idcorsostudio: corsoDiStudioId);

										if (newInsegn != null)
											ListaAttivitaDidattica.Add(newInsegn);
									}
								}
							}

							// ==============================================================
							// 2) Offerta Formativa
							// ==============================================================
							if (corsoDetail.ordinamentiConPercorsi != null)
							{
								foreach (OrdinamentoConPercorsi ordinamentoConPercorsi in corsoDetail.ordinamentiConPercorsi)
								{
									string percorsoDiStudioCdsCod = ordinamentoConPercorsi.cdsOrdCod;
									string percorsoDiStudioCdsDes = ordinamentoConPercorsi.cdsOrdDes;
									int? percorsoDiStudioDurataAnni = ordinamentoConPercorsi.durataAnni;
									int annoistituz = ordinamentoConPercorsi.aaOrdId;

									// ==============================================================
									// 1) Corso di Studio
									// ==============================================================
									if (!ListaCorsoStudio.Any(w => w.codice == corsoDiStudioCodice))
									{
										// ==============================================================
										// Add Corso di Studio
										// ==============================================================
										corsostudio newCorsostudio = _repository.AddCorsoStudio(idcorsostudio: corsoDiStudioId,
																								  annoistituz: annoistituz,
																									   codice: corsoDiStudioCodice,
																										title: corsoDiStudioDescrizione,
																									 title_en: corsoDiStudioDescrizioneEng,
																							idcorsostudiokind: idcorsostudiokind,
																						 idcorsostudiolivello: idcorsostudiolivello,
																						   idcorsostudionorma: idcorsostudionorma,
																								 idduratakind: idduratakind,
																								  idstruttura: strutturaId,
																									   durata: percorsoDiStudioDurataAnni);

										if (newCorsostudio != null)
											ListaCorsoStudio.Add(newCorsostudio);
									}

									// Get Corso di Studio
									corsostudio corsostudio = ListaCorsoStudio.FirstOrDefault(w => w.codice == corsoDiStudioCodice);
									int? idStrutturaCorsoDiStudio = corsostudio.idstruttura;

									int idSedeCorsoDiStudio = sede_base;
									if (ListaStruttura.Any(w => w.idstruttura == corsostudio.idstruttura))
										idSedeCorsoDiStudio = ListaStruttura.FirstOrDefault(w => w.idstruttura == corsostudio.idstruttura)?.idsede ?? sede_base;

									int annosolare = 1; // GetAnnoCorso(annoAccademico);

									// ==============================================================
									// 2) Didattuca Programmata
									// ==============================================================
									int iddidprog = 0;
									if (!ListaDidatticaProgrammata.Any(w => w.codice == corsoDiStudioCodice && w.aa == aaaa_aaaa))
									{
										didprog newDidprog = _repository.AddDidatticaProgrammata(idcorsostudio: corsoDiStudioId,
																											aa: aaaa_aaaa,
																										 title: corsoDiStudioDescrizione,
																									  title_en: corsoDiStudioDescrizioneEng,
																										codice: corsoDiStudioCodice,
																									annosolare: annosolare,
																							   idareadidattica: idareadidattica,
																								  iderogazkind: iderogazkind,
																										idsede: idSedeCorsoDiStudio,
																									   website: sitoWeb);

										if (newDidprog != null)
											ListaDidatticaProgrammata.Add(newDidprog);
									}
									iddidprog = ListaDidatticaProgrammata.FirstOrDefault(w => w.codice == corsoDiStudioCodice && w.aa == aaaa_aaaa).iddidprog;

									if (ordinamentoConPercorsi.percorsiDiStudio != null)
									{
										foreach (PercorsoDiStudio percorsoDiStudio in ordinamentoConPercorsi.percorsiDiStudio)
										{
											string percorsoDiStudioCodice = percorsoDiStudio.pdsCod;
											// string percorsoDiStudioDescrizione = percorsoDiStudio.pdsDes;

											// ==============================================================
											// 3) Curriculum
											// ==============================================================
											int iddidprogcurr = 0;
											if (!ListaCurriculum.Any(w => w.iddidprog == iddidprog && w.idcorsostudio == corsoDiStudioId))
											{
												didprogcurr newDidprogcurr = _repository.AddCurriculum(iddidprog: iddidprog,
																								   idcorsostudio: corsoDiStudioId,
																										  codice: percorsoDiStudioCodice,
																										   title: CURRICULUM_UNICO);
												if (newDidprogcurr != null)
													ListaCurriculum.Add(newDidprogcurr);
											}
											iddidprogcurr = ListaCurriculum.FirstOrDefault(w => w.iddidprog == iddidprog && w.idcorsostudio == corsoDiStudioId)?.iddidprogcurr ?? 0;


											// ==============================================================
											// 4) Orientamento
											// ==============================================================
											int iddidprogori = 0;
											if (!ListaOrientamento.Any(w => w.idcorsostudio == corsoDiStudioId
																			 && w.iddidprog == iddidprog
																		 && w.iddidprogcurr == iddidprogcurr))
											{
												didprogori newDidprogori = _repository.AddOrientamento(idcorsostudio: corsoDiStudioId,
																										   iddidprog: iddidprog,
																									   iddidprogcurr: iddidprogcurr,
																											   title: ORIENTAMENTO_UNICO);

												if (newDidprogori != null)
													ListaOrientamento.Add(newDidprogori);
											}
											iddidprogori = ListaOrientamento.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																								  && w.iddidprog == iddidprog
																							  && w.iddidprogcurr == iddidprogcurr)?.iddidprogori ?? 0;


											// ==============================================================
											// 5) Anno
											// ==============================================================
											int anno = 1;
											string progannoTitle = $"{anno} anno";  // ATTENZIONE !!!!

											int iddidproganno = 0;
											if (!ListaAnno.Any(w => w.idcorsostudio == corsoDiStudioId
																	 && w.iddidprog == iddidprog
																 && w.iddidprogcurr == iddidprogcurr
																  && w.iddidprogori == iddidprogori))
											{
												didproganno newDidproganno = _repository.AddAnno(idcorsostudio: corsoDiStudioId,
																									 iddidprog: iddidprog,
																								 iddidprogcurr: iddidprogcurr,
																								  iddidprogori: iddidprogori,
																										    aa: aaaa_aaaa,
																										  anno: annoAccademico,
																										 title: progannoTitle,
																							  creditiformativi: CREDITI_FORMATIVI_60);

												if (newDidproganno != null)
													ListaAnno.Add(newDidproganno);
											}
											iddidproganno = ListaAnno.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																						   && w.iddidprog == iddidprog
																					   && w.iddidprogcurr == iddidprogcurr
																						&& w.iddidprogori == iddidprogori)?.iddidproganno ?? 0;


											// ==============================================================
											// 6) Porzione Anno
											// ==============================================================
											DateTime inizioPorzAnno = new DateTime(annoAccademico, 11, 1);
											DateTime finePorzAnno = new DateTime(annoAccademico + 1, 10, 30);
											int iddidprogporzannokind = 6;
											string didprogporzannoTitle = stringFromIdporzanno(iddidprogporzannokind);

											int iddidprogporzanno = 0;
											if (!ListaPorzioneAnno.Any(w => w.idcorsostudio == corsoDiStudioId
																			 && w.iddidprog == iddidprog
																		 && w.iddidprogcurr == iddidprogcurr
																		  && w.iddidprogori == iddidprogori
																		 && w.iddidproganno == iddidproganno))
											{
												didprogporzanno newDidprogporzanno = _repository.AddPorzioneAnno(idcorsostudio: corsoDiStudioId,
																													 iddidprog: iddidprog,
																												 iddidprogcurr: iddidprogcurr,
																												  iddidprogori: iddidprogori,
																												 iddidproganno: iddidproganno,
																										 iddidprogporzannokind: iddidprogporzannokind,
																														    aa: aaaa_aaaa,
																														 start: inizioPorzAnno,
																														  stop: finePorzAnno,
																														 title: didprogporzannoTitle);

												if (newDidprogporzanno != null)
													ListaPorzioneAnno.Add(newDidprogporzanno);
											}
											iddidprogporzanno = ListaPorzioneAnno.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																										 && w.iddidprog == iddidprog
																									&& w.iddidprogcurr == iddidprogcurr
																									 && w.iddidprogori == iddidprogori
																									&& w.iddidproganno == iddidproganno)?.iddidproganno ?? 0;


											// ==============================================================
											// 7) Attività Formativa (Unità didattica)
											// ==============================================================
											int idattivform = 0;
											if (!ListaAttivitaFormativa.Any(w => w.idcorsostudio == corsoDiStudioId
																				  && w.iddidprog == iddidprog
																			  && w.iddidprogcurr == iddidprogcurr
																			   && w.iddidprogori == iddidprogori
																			  && w.iddidproganno == iddidproganno
																		  && w.iddidprogporzanno == iddidprogporzanno
																				   && w.idinsegn == attivitaDidatticaId))
											{
												attivform newAttivform = _repository.AddAttivitaFormativa(idcorsostudio: corsoDiStudioId,
																											  iddidprog: iddidprog,
																										  iddidprogcurr: iddidprogcurr,
																										   iddidprogori: iddidprogori,
																										  iddidproganno: iddidproganno,
																									  iddidprogporzanno: iddidprogporzanno,
																												 idsede: idSedeCorsoDiStudio,
																											   idinsegn: attivitaDidatticaId,
																													 aa: aaaa_aaaa,
																												  title: attivitaDidatticaDescrizione);

												if (newAttivform != null)
													ListaAttivitaFormativa.Add(newAttivform);
											}
											idattivform = ListaAttivitaFormativa.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																									  && w.iddidprog == iddidprog
																								  && w.iddidprogcurr == iddidprogcurr
																								   && w.iddidprogori == iddidprogori
																								  && w.iddidproganno == iddidproganno
																							  && w.iddidprogporzanno == iddidprogporzanno
																									   && w.idinsegn == attivitaDidatticaId)?.idattivform ?? 0;


											// ==============================================================
											// 8) Canale
											// ==============================================================
											int idcanale = 0;
											if (!ListaCanale.Any(w => w.idcorsostudio == corsoDiStudioId
																	   && w.iddidprog == iddidprog
																   && w.iddidprogcurr == iddidprogcurr
																	&& w.iddidprogori == iddidprogori
																   && w.iddidproganno == iddidproganno
															   && w.iddidprogporzanno == iddidprogporzanno
																	 && w.idattivform == idattivform))
											{
												canale newCanale = _repository.AddCanale(idcorsostudio: corsoDiStudioId,
																						     iddidprog: iddidprog,
																					     iddidprogcurr: iddidprogcurr,
																					      iddidprogori: iddidprogori,
																					     iddidproganno: iddidproganno,
																				     iddidprogporzanno: iddidprogporzanno,
																						   idattivform: idattivform,
																							    idsede: idSedeCorsoDiStudio,
																								    aa: aaaa_aaaa,
																							     title: CANALE_UNICO);

												if (newCanale != null)
													ListaCanale.Add(newCanale);
											}
										}
									}
								}
							}

							if (!ListaAreaDidattica.Any(w => w.title == areaDidatticaDescrizione))
							{
								// Add Tipo Corso di Studio
								areadidattica newAreadidattica = _repository.AddAreaDidattica(title: areaDidatticaDescrizione,
																			   idmacroareadidattica: idmacroareadidattica,
																				  idcorsostudiokind: idcorsostudiokind);

								if (newAreadidattica != null)
									ListaAreaDidattica.Add(newAreadidattica);
							}
						}
					}

					// Info F
					common.logInfo($"F - ListaRegistroDocenteConDettagli: {ListaRegistroDocenteConDettagli.Count()}");

					// ==============================================================
					// Registro Docente Con Dettagli
					// ==============================================================
					foreach (RegistroDocenteConDettagli registroDocenteConDettagli in ListaRegistroDocenteConDettagli)
					{
						// ==============================================================
						// LOGISTICA
						// ==============================================================
						if (registroDocenteConDettagli.logistica.Count() > 0)
						{
							if (registroDocenteConDettagli.attivita.Count() > 0)
							{
								int iddidprog = 0;
								int iddidprogcurr = 0;
								int iddidprogori = 0;
								int iddidproganno = 0;
								int iddidprogporzanno = 0;
								int idattivform = 0;
								int idaffidamento = 0;
								int idcanale = 0;
								int idreg = 0;
								int idSedeCorsoDiStudio = 0;

								foreach (RegistroDocenteLog logistica in registroDocenteConDettagli.logistica)
								{
									string aaaa_aaaa = get_aaaa_aaaa(registroDocenteConDettagli.aaOffId);
									string corsoDiStudioCodice = logistica.cdsCod;
									int corsoDiStudioId = (int)logistica.cdsId;
									string attivitaDidatticaCodice = logistica.adCod;

									// ==============================================================
									// IdInsegn
									// ==============================================================
									int attivitaDidatticaId = (int)logistica.adId;

									iddidprog = ListaDidatticaProgrammata.FirstOrDefault(w => w.codice == corsoDiStudioCodice && w.aa == aaaa_aaaa).iddidprog;

									idSedeCorsoDiStudio = sede_base;
									int? idstruttura = ListaCorsoStudio.FirstOrDefault(w => w.codice == corsoDiStudioCodice)?.idstruttura;
									if (ListaStruttura.Any(w => w.idstruttura == idstruttura))
										idSedeCorsoDiStudio = ListaStruttura.FirstOrDefault(w => w.idstruttura == idstruttura)?.idsede ?? sede_base;

									// ==============================================================
									// Registry_docente
									// ==============================================================
									idreg = ListaIdRegCfDocenti.FirstOrDefault(w => w.Cf == registroDocenteConDettagli.codFis).Idreg;

									// ==============================================================
									// 3) Curriculum
									// ==============================================================
									iddidprogcurr = ListaCurriculum.FirstOrDefault(w => w.iddidprog == iddidprog && w.idcorsostudio == corsoDiStudioId)?.iddidprogcurr ?? 0;

									// ==============================================================
									// 4) Orientamento
									// ==============================================================
									iddidprogori = ListaOrientamento.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																						  && w.iddidprog == iddidprog
																					  && w.iddidprogcurr == iddidprogcurr)?.iddidprogori ?? 0;

									// ==============================================================
									// 5) Anno
									// ==============================================================
									iddidproganno = ListaAnno.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																				   && w.iddidprog == iddidprog
																			   && w.iddidprogcurr == iddidprogcurr
																				&& w.iddidprogori == iddidprogori)?.iddidproganno ?? 0;

									// ==============================================================
									// 6) Porzione Anno
									// ==============================================================
									iddidprogporzanno = ListaPorzioneAnno.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																							   && w.iddidprog == iddidprog
																						   && w.iddidprogcurr == iddidprogcurr
																							&& w.iddidprogori == iddidprogori
																						   && w.iddidproganno == iddidproganno)?.iddidproganno ?? 0;

									// ==============================================================
									// 7) Attività Formativa (Unità didattica)
									// ==============================================================
									idattivform = ListaAttivitaFormativa.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																							  && w.iddidprog == iddidprog
																						  && w.iddidprogcurr == iddidprogcurr
																						   && w.iddidprogori == iddidprogori
																						  && w.iddidproganno == iddidproganno
																					  && w.iddidprogporzanno == iddidprogporzanno
																							   && w.idinsegn == attivitaDidatticaId)?.idattivform ?? 0;

									// ==============================================================
									// 8) Canale
									// ==============================================================
									idcanale = ListaCanale.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																				&& w.iddidprog == iddidprog
																			&& w.iddidprogcurr == iddidprogcurr
																			 && w.iddidprogori == iddidprogori
																			&& w.iddidproganno == iddidproganno
																		&& w.iddidprogporzanno == iddidprogporzanno
																			  && w.idattivform == idattivform)?.idcanale ?? 0;

									// ==============================================================
									// 9) Affidamento
									// ==============================================================
									if (!ListaAffidamento.Any(w => w.idcorsostudio == corsoDiStudioId
																	&& w.iddidprog == iddidprog
																&& w.iddidprogcurr == iddidprogcurr
																 && w.iddidprogori == iddidprogori
																&& w.iddidproganno == iddidproganno
															&& w.iddidprogporzanno == iddidprogporzanno
																  && w.idattivform == idattivform
																	 && w.idcanale == idcanale
																&& w.idreg_docenti == idreg))
									{
										string corso = ListaDidatticaProgrammata.FirstOrDefault(w => w.iddidprog == iddidprog)?.title;
										string curr = ListaCurriculum.FirstOrDefault(w => w.iddidprog == iddidprog && w.idcorsostudio == corsoDiStudioId)?.title;
										string attivForm = ListaAttivitaFormativa.FirstOrDefault(w => w.idattivform == idattivform)?.title;

										string jsonancestor = "{\"Corso\":\"" + corso + "\",\"Curriculum\":\"" + curr + "\",\"Attività formativa\":\"" + attivForm + "\"}";

										affidamento newAffidamento = _repository.AddAffidamento(idcorsostudio: corsoDiStudioId,
																									iddidprog: iddidprog,
																								iddidprogcurr: iddidprogcurr,
																								 iddidprogori: iddidprogori,
																								iddidproganno: iddidproganno,
																							iddidprogporzanno: iddidprogporzanno,
																								  idattivform: idattivform,
																									 idcanale: idcanale,
																									   idsede: idSedeCorsoDiStudio,
																										   aa: aaaa_aaaa,
																										title: AFFIDAMENTO_DI_INCARICO,
																								 iderogazkind: iderogazkind,
																								idreg_docenti: idreg,
																							idaffidamentokind: idaffidamentokind,
																								 jsonancestor: jsonancestor);

										if (newAffidamento != null)
											ListaAffidamento.Add(newAffidamento);
									}
									idaffidamento = ListaAffidamento.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
																						  && w.iddidprog == iddidprog
																					  && w.iddidprogcurr == iddidprogcurr
																					   && w.iddidprogori == iddidprogori
																					  && w.iddidproganno == iddidproganno
																				  && w.iddidprogporzanno == iddidprogporzanno
																						&& w.idattivform == idattivform
																						   && w.idcanale == idcanale
																					  && w.idreg_docenti == idreg)?.idaffidamento ?? 0;
								}

								// ==============================================================
								// ELENCO ATTIVITA'
								// ==============================================================
								foreach (RegistroDocenteDett att in registroDocenteConDettagli.attivita)
								{
                                    RegistroDocenteLog attivitaLogistica = registroDocenteConDettagli.logistica.FirstOrDefault();

                                    int corsoDiStudioId = (int)attivitaLogistica.cdsId;
                                    int attivitaDidatticaId = (int)attivitaLogistica.adId;

                                    // ==================
                                    // Tipo Lezione
                                    // ==================
                                    // LEZ: Lezione
                                    // LAB: Laboratorio
                                    // ESE: Esercitazione
                                    // SEM: Seminario
                                    if (!ListaTipoLezione.Any(w => w.title == att.tipoAttDes))
									{
										// Add Tipo Corso di Studio
										orakind newOraKind = _repository.AddTipoLezione(att.tipoAttDes);

										if (newOraKind != null)
											ListaTipoLezione.Add(newOraKind);
									}
									// Get Tipo Corso di Studio
									int idorakind = ListaTipoLezione.FirstOrDefault(w => w.title == att.tipoAttDes).idorakind;

									// ==============================================================
									// Lezione Inizio/Fine
									// ==============================================================
									DateTime inizioLezione = DateTime.Parse(att.data.Substring(0, 11) + att.oraInizio);
									DateTime fineLezione = DateTime.Parse(att.data.Substring(0, 11) + att.oraFine);

									string aaaa_aaaa_Lezione = get_aa(inizioLezione);

									// ==============================================================
									// 10) Lezione
									// ==============================================================
									lezione lez = ListaLezione.FirstOrDefault(w => w.idreg_docenti == idreg
																						&& w.start == inizioLezione
																						 && w.stop == fineLezione);

									if (lez == null)
									{
										// Counter
										lezioniInseriteCnt++;

										// Nuova Lezione
										ListaLezioniToAdd.Add(new lezione()
										{
											idcorsostudio = corsoDiStudioId,
											iddidprog = iddidprog,
											iddidprogcurr = iddidprogcurr,
											iddidprogori = iddidprogori,
											iddidproganno = iddidproganno,
											iddidprogporzanno = iddidprogporzanno,
											idattivform = idattivform,
											idsede = idSedeCorsoDiStudio,
											idaffidamento = idaffidamento,
											idcanale = idcanale,
											idreg_docenti = idreg,
											start = inizioLezione,
											stop = fineLezione,
											aa = aaaa_aaaa_Lezione,
											titolo = att.titolo
										});
									}
									else
									{
										if (string.IsNullOrEmpty(lez.titolo))
										{
											lezioniAggiornateCnt++;
											_repository.UpdateTitoloLezione(lez.idlezione, att.titolo);
										}
										ListaLezione.Remove(lez);
									}
								}
							}
						}
					}

					// Info Ins
					common.logInfo($"G - Inserimento Lezioni: {lezioniInseriteCnt}");

					if (ListaLezioniToAdd.Any())
					{
						foreach (lezione lezione in ListaLezioniToAdd)
						{
							_repository.AddLezione(idcorsostudio: lezione.idcorsostudio,
													   iddidprog: lezione.iddidprog,
												   iddidprogcurr: lezione.iddidprogcurr,
													iddidprogori: lezione.iddidprogori,
												   iddidproganno: lezione.iddidproganno,
											   iddidprogporzanno: lezione.iddidprogporzanno,
													 idattivform: lezione.idattivform,
														  idsede: lezione.idsede,
												   idaffidamento: lezione.idaffidamento,
														idcanale: lezione.idcanale,
												   idreg_docenti: lezione.idreg_docenti,
														   start: lezione.start,
															stop: lezione.stop,
															  aa: lezione.aa,
														  titolo: lezione.titolo);
						}
					}
					

					// ==============================================================
					// Elimino le Lezioni eliminate o modificate (del più ins)
					// ==============================================================
					// Info G
					common.logInfo($"H - Eliminazione Lezioni: {ListaLezione.Count()}");

					int iDel = 0;
                    do
					{
                        string idLezList = string.Join(",", ListaLezione.Skip(iDel).Take(100).Select(s => s.idlezione).ToArray());
                        _repository.EliminaLezioni(idLezList);
                        iDel += 100;
                    } while (iDel < ListaLezione.Count());

					// Info H
					common.logInfo($"I - PuliziaDidattica");

					_repository.PuliziaDidattica();

					// ==============================================================
					// Log
					// ==============================================================
					common.logInfo($"Lista di Registri Docente Esse3:    {ListaRegistroDocente.Count}\r\n" +
		$"                    CF Docenti nella lista:             {listaCf.Count}\r\n" +
		$"                    RegId Docenti presenti in Registry: {ListaIdDocentiPresenti.Count}\r\n" +
		$"                    Logistiche:                         {logistichePerAnno.Sum(s => s.logistica.Count())}\r\n" +
		$"                    Registri Docente con Attività:      {ListaRegistroDocenteConDettagli.Count}\r\n" +
		$"                    Lezioni eliminate:                  {lezioniEliminateCnt}\r\n" +
		$"                    Lezioni inserite:                   {lezioniInseriteCnt}\r\n" +
		$"                    Lezioni aggiornate:                 {lezioniAggiornateCnt}");
				}
			}
			catch (Exception Ex)
			{
				common.logInfo("Errore InsLezioni: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace);
			}

			common.logInfo("Lezioni End");
		}


        // ===================================================================================================================
        // ¦¦¦¦¦¦   ¦¦   ¦¦¦¦¦   ¦¦¦¦¦¦   ¦¦    ¦¦
        // ¦¦   ¦¦  ¦¦  ¦¦   ¦¦  ¦¦   ¦¦   ¦¦  ¦¦
        // ¦¦   ¦¦  ¦¦  ¦¦¦¦¦¦¦  ¦¦¦¦¦¦      ¦¦
        // ¦¦   ¦¦  ¦¦  ¦¦   ¦¦  ¦¦   ¦¦     ¦¦
        // ¦¦¦¦¦¦   ¦¦  ¦¦   ¦¦  ¦¦   ¦¦     ¦¦
        // ===================================================================================================================
        public async Task DelDia(int idDiario)
        {
            _repository.DelDia(idDiario);
        }

        public async Task<List<diadb>> GetDiariDb(string filterCF, int filterIdReg)
        {
            if (filterIdReg == 0 && filterCF == "")
                return null;

            if (filterCF != "" && filterIdReg == 0)
                filterIdReg = _repository.RegistryIdByRegFc(filterCF);
            else if (filterCF == "" && filterIdReg != 0)
                filterCF = _repository.RegistryCfByRegId(filterIdReg);

            if (filterIdReg == 0)
                return null;

            try
            {
                return _repository.Diari(filterIdReg);
            }
            catch (Exception Ex)
            {
                return null;
            }
        }

        public async Task<List<diaws>> GetDiari(string filterCF, int filterIdReg)
        {
            string msg = "";

            List<RendicontaltroKindTitle> listaRendicontAltroKind = _repository.GetAllRendicontaAltro();

            try
            {
                bool success = true;

                if (filterIdReg == 0 && filterCF == "")
                    return new List<diaws>() { new diaws() { data = new DateTime(), valws = "Inserire un idreg" } };

                if (filterCF != "" && filterIdReg == 0)
                    filterIdReg = _repository.RegistryIdByRegFc(filterCF);
                else if (filterCF == "" && filterIdReg != 0)
                    filterCF = _repository.RegistryCfByRegId(filterIdReg);

                if (string.IsNullOrEmpty(filterCF))
                {
                    return new List<diaws>() { new diaws() { data = new DateTime(), valws = "idReg non trovato!" } };
                }

                List<DiarioDocente> ListaDiarioDocente = new List<DiarioDocente>();

                // ============================================================================================================================
                // DIARI CURR YEAR
                // ============================================================================================================================
                int thisYear = DateTime.Now.Year;
                int lastYear = thisYear - common.yearToConsider + 1;

                for (int currYear = lastYear; currYear <= thisYear; currYear++)
                {
                    ListaDiarioDocente.AddRange(GetList<DiarioDocente>(out msg, out success, null, $"&aaId={currYear}"));

                    if (!success)
                    {
                        if (!msg.Contains("Count: 0"))
                            return new List<diaws>() { new diaws() { data = new DateTime(), valws = $"Errore Get Diario Docente per l'annoAccademico {currYear}: {msg}" } };
                    }
                }

                // ============================================================================================================================
                // CHECK DIARI
                // ============================================================================================================================
                if (ListaDiarioDocente.Count == 0)
                {
                    return new List<diaws>() { new diaws() { data = new DateTime(), valws = $"Nessun diario docente per l'annoAccademico {lastYear}-{thisYear}" } };
                }

                // ==============================================================
                // PER OGNI DIARIO DOCENTE PRESENTE IN REGISTRY
                // ==============================================================
                List<long> ListaIdDocentiPresenti = ListaDiarioDocente.Where(w => w.codFis == filterCF).Select(s => s.diarioId).Distinct().ToList();

                List<diaws> rendicontAltroList = new List<diaws>();

                foreach (long diarioId in ListaIdDocentiPresenti)
                {
                    // ============================================================================================================================
                    // WS DIARIO DOCENTE, ottengo la rendicontazione del docente
                    // ============================================================================================================================
                    DiarioDocenteConDettagli diarioDocenteConDettagli = Get<DiarioDocenteConDettagli>(out msg, out success, new object[1] { diarioId });

                    if (!success)
                        return new List<diaws>() { new diaws() { data = new DateTime(), valws = msg } };

                    // Se esiste
                    if (diarioDocenteConDettagli != null)
                    {
                        // Controllo la presenza di attività didattica
                        if (diarioDocenteConDettagli.attivita != null)
                        {
                            if (diarioDocenteConDettagli.attivita.Count() > 0)
                            {
                                // ==============================================================
                                // Tutte le rendicontazioni dal WS
                                // ==============================================================

                                rendicontAltroList.AddRange(diarioDocenteConDettagli.attivita.Select(s => new diaws() { 
									data = DateTime.Parse(s.data),
									idrendicontaltrokind = listaRendicontAltroKind.FirstOrDefault(w => w.title == s.tipoAttDes).idkind,
									valws = (((float)(s.ore * 60 + s.minuti)) / 60).ToString("F2") + " ore"
								}).ToList());
                            }
                        }
                    }
                }

                return rendicontAltroList;
            }
            catch (Exception Ex)
            {
                return new List<diaws>() { new diaws() { data = new DateTime(), valws = "Errore InsLezioni: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message + "\r\n" + Ex.StackTrace } };
            }
        }

        public void InsDiari(string filterCF = "", int filterIdReg = 0)
		{
			common.logInfo("=========================================================================");
			common.logInfo($"Diari Start");

			try
			{
				DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(common.connstring).Options;

				using (var context = new ApplicationDbContext(options))
				{
					Repository _repository = new Repository(context);

					string msg = "";
					bool success = false;

                    if (!string.IsNullOrEmpty(filterCF) && filterIdReg == 0)
                        filterIdReg = _repository.RegistryIdByRegFc(filterCF);
                    else if (string.IsNullOrEmpty(filterCF) && filterIdReg != 0)
                        filterCF = _repository.RegistryCfByRegId(filterIdReg);

                    // ============================================================================================================================
                    // DIARI FROM YEAR TO YEAR
                    // ============================================================================================================================
                    int thisYear = DateTime.Now.Year;
					int lastYear = thisYear - common.yearToConsider + 1;

                    List<DiarioDocente> ListaDiarioDocente = new List<DiarioDocente>();

					// ============================================================================================================================
					// DIARI FROM 2015 TO CURR YEAR
					// ============================================================================================================================
					for (int currYear = lastYear; currYear <= thisYear; currYear++)
					{
						ListaDiarioDocente.AddRange(GetList<DiarioDocente>(out msg, out success, null, $"&aaId={currYear}"));
						if (!success)
						{
							if (msg.Contains("Count: 0"))
								common.logInfo($"Diario docente per l'annoAccademico {currYear}: 0");
							else
								common.logInfo($"Errore Get Diario Docente per l'annoAccademico {currYear}: {msg}");
						}
						else
						{
							common.logInfo($"Diario docente per l'annoAccademico {currYear}: {msg.Split("Count: ")[1].Replace("\r\n", "")}");
						}
					}

					// ============================================================================================================================
					// CHECK DIARI
					// ============================================================================================================================
					if (ListaDiarioDocente.Count == 0)
					{
						common.logInfo($"Nessun diario docente per l'annoAccademico {lastYear}-{thisYear}");
						common.logInfo("InsDiari End");
						return;
					}

					// ==============================================================
					// LISTA DEI RENDICONTA ALTRO KIND
					// ==============================================================
					List<RendicontaltroKindTitle> listaRendicontAltroKind = _repository.GetAllRendicontaAltro();

					// ==============================================================
					// LISTA DEI CF DEI DIARI DOCENTI
					// ==============================================================
					List<string> listaCf = ListaDiarioDocente.Select(s => s.codFis).Distinct().ToList();

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					List<registryMin> ListaIdRegCfDocenti = _repository.RegistryByCf(listaCf, lastYear, thisYear);

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					List<string> ListaCfRegDocenti = ListaIdRegCfDocenti.Select(s => s.Cf).ToList();

					// ==============================================================
					// FILTRO !!!
					// ==============================================================
					if (!string.IsNullOrEmpty(filterCF))
						ListaCfRegDocenti = ListaCfRegDocenti.Where(w => w == filterCF).ToList();

					// ==============================================================
					// PER OGNI DIARIO DOCENTE PRESENTE IN REGISTRY
					// ==============================================================
					List<long> ListaIdDocentiPresenti = ListaDiarioDocente.Where(w => ListaCfRegDocenti.Contains(w.codFis)).Select(s => s.diarioId).Distinct().ToList();

					int diari = 0;
					int attivita = 0;
					int attivitaEliminate = 0;
					int attivitaAggiunte = 0;

					List<RendicontAltroMin> rendicontAltroListDb = new List<RendicontAltroMin>();

					List<RendicontAltroMin> rendicontAltroListWs = new List<RendicontAltroMin>();

					foreach (long diarioId in ListaIdDocentiPresenti)
					{
						// ============================================================================================================================
						// WS DIARIO DOCENTE, ottengo la rendicontazione del docente
						// ============================================================================================================================
						DiarioDocenteConDettagli diarioDocenteConDettagli = Get<DiarioDocenteConDettagli>(out msg, out success, new object[1] { diarioId });

						// Se esiste
						if (diarioDocenteConDettagli != null)
						{
							// Controllo la presenza di attività didattica
							if (diarioDocenteConDettagli.attivita != null)
							{
								if (diarioDocenteConDettagli.attivita.Count() > 0)
								{
									// e lo aggiungo
									diari++;
									attivita += diarioDocenteConDettagli.attivita.Count();

									// ==============================================================
									// RendicontaAltroKind
									// ==============================================================
									List<string> ListaTipoAttDes = diarioDocenteConDettagli.attivita.Select(z => z.tipoAttDes).Distinct().ToList();

									foreach (string title in ListaTipoAttDes)
									{
										if (!listaRendicontAltroKind.Any(w => w.title == title))
										{
											_repository.AddRendicontaAltroKind(title);
											listaRendicontAltroKind = _repository.GetAllRendicontaAltro();
										}
									}

									// ==============================================================
									// Registry_docente
									// ==============================================================
									int idregdocenti = ListaIdRegCfDocenti.FirstOrDefault(w => w.Cf == diarioDocenteConDettagli.codFis).Idreg;

									// ==============================================================
									// Tutte le rendicontazioni presenti nel DB
									// ==============================================================
									List<RendicontAltroMin> RendAltroByIdRegDocList = new List<RendicontAltroMin>();
									for (int currYear = lastYear; currYear <= thisYear; currYear++)
										RendAltroByIdRegDocList.AddRange(_repository.GetRendicontaAltro(idregdocenti, currYear));

                                    rendicontAltroListDb.AddRange(RendAltroByIdRegDocList);

									rendicontAltroListDb = rendicontAltroListDb.Distinct().ToList(); ;

									// ==============================================================
									// Tutte le rendicontazioni dal WS
									// ==============================================================
									rendicontAltroListWs.AddRange(diarioDocenteConDettagli.attivita
										.Select(s => new RendicontAltroMin
										{
											data = DateTime.Parse(s.data),
											idkind = listaRendicontAltroKind.FirstOrDefault(w => w.title == s.tipoAttDes).idkind,
											ore = s.ore + Math.Round((decimal)s.minuti / 60, 2),
											idreg_docenti = idregdocenti
										})
										.ToList());
								}
							}
						}
					}

					// ==============================================================
					// Rendicontazioni del DB da cancellare perchè
					// non più presenti o con ore modificate
					// ==============================================================
					List<RendicontAltroMin> dataKindDbToRemove = new List<RendicontAltroMin>();

                    foreach (RendicontAltroMin rendDb in rendicontAltroListDb)
					{
						if (!rendicontAltroListWs.Any(w => w.idreg_docenti == rendDb.idreg_docenti && w.idkind == rendDb.idkind && w.data == rendDb.data && w.ore == rendDb.ore))
						{
							dataKindDbToRemove.Add(rendDb);
						}
					}

					if (dataKindDbToRemove.Any())
					{
						attivitaEliminate += dataKindDbToRemove.Count();
						_repository.RemoveRendicontaAltro(dataKindDbToRemove);
					}

					// ==============================================================
					// Rendicontazioni da WS da aggiungere poichè non presenti nel DB
					// ==============================================================
					List<RendicontAltroMin> dataKindDbToAdd = rendicontAltroListWs.Except(rendicontAltroListDb).ToList();

					if (dataKindDbToAdd.Any())
					{
						attivitaAggiunte += dataKindDbToAdd.Count();
						_repository.AddRendicontaAltro(dataKindDbToAdd);
					}

					common.logInfo($"Lista di Diari Docente Esse3:       {ListaDiarioDocente.Count}\r\n" +
		$"                    Diari:                              {diari}\r\n" +
		$"                    CF Docenti nella lista:             {listaCf.Count}\r\n" +
		$"                    RegId Docenti presenti in Registry: {ListaIdDocentiPresenti.Count}\r\n" +
		$"                    Attività nei Diari:                 {attivita}\r\n" +
		$"                    Attività eliminate dal DB:          {attivitaEliminate}\r\n" +
		$"                    Attività aggiunte al DB:            {attivitaAggiunte}");
				}
			}
			catch (Exception Ex)
			{
				common.logInfo("Errore InsDiari: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message);
			}

			common.logInfo("Diari End");
		}


		// ==============================================================
		// GET LIST
		// ==============================================================
		private List<T> GetList<T>(out string msg, out bool success, object[] param = null, string qryString = "") where T : IApiModel<T>, new()
		{
			// Get List form Api of Type T
			List<T> list = ApiManager.GetApiList<T>(out msg, out success, param, qryString);

			// Return the list
			return list ?? new List<T>();
		}

		// ==============================================================
		// GET
		// ==============================================================
		private T Get<T>(out string msg, out bool success, object[] param = null, string qryString = "") where T : IApiModel<T>, new()
		{
			// Get List form Api of Type T
			T? api = ApiManager.GetApi<T>(out msg, out success, param, qryString);

			// Return the list
			return api;
		}

		// ==============================================================
		// GET
		// ==============================================================
		private string stringFromIdporzanno(int i)
		{
			switch (i)
			{
				case 1:
					return " mese";
				case 2:
					return " bimestre";
				case 3:
					return " trimestre";
				case 4:
					return " quadrimestre";
				case 5:
					return " semestre";
				case 6:
					return " annualità";
			}

			return "";
		}

		// ==============================================================
		// GET AA
		// ==============================================================
		private string get_aa(DateTime dt)
		{
			DateTime nuovoAnnoAccademico = new DateTime(dt.Year, 11, 1);
			int aaaa = dt.Year + (dt > nuovoAnnoAccademico ? 0 : -1);
			return $"{aaaa}/{aaaa + 1}";
		}

		private string get_aaaa_aaaa(int aaaa)
		{
			return $"{aaaa - 1}/{aaaa}";
		}
	}
}
