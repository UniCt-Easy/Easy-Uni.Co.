
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


using ServizioRendicontazione.Models;
using ServizioRendicontazione.ApiModels;
using ServizioRendicontazione.Repositories;
using ServizioRendicontazione.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ServizioRendicontazione
{
    public class Rendicontazione
    {
		private string _logFileName = "__Log.txt";

		private string settingsFile = "appsettingsRendicontazione.json";

        public Rendicontazione()
        {
			DoInit();
		}

		private void DoInit()
		{
            try
            {
                string appsettingJsonFullName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, settingsFile);
				var configuration = new ConfigurationBuilder().AddJsonFile(appsettingJsonFullName);
                var config = configuration.Build();
                var appSettings = config.GetSection("AppSettings");

                // Cu
                common.cu =                       appSettings.GetChildren().FirstOrDefault(w => w.Key == "cu").Value;

			    // Connection
			    common.connstring =               appSettings.GetChildren().FirstOrDefault(w => w.Key == "connString").Value;
                common.schemaAmm =                appSettings.GetChildren().FirstOrDefault(w => w.Key == "schemaAmm").Value;
                common.schemaDbo =                appSettings.GetChildren().FirstOrDefault(w => w.Key == "schemaDbo").Value;
                common.annoAccademico = int.Parse(appSettings.GetChildren().FirstOrDefault(w => w.Key == "annoAccademico").Value);

                // API
                common.api_url =                  appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_url").Value;
			    common.limit =          int.Parse(appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_limit").Value);
			    common.all =                      appSettings.GetChildren().FirstOrDefault(w => w.Key == "api_all").Value == "Y" ? true : false;

			    // Authorization Type
                common.auth_type_basic =          appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_type").Value == "BASIC" ? true : false;

			    // Authorization Type
                common.auth_basic_token =         appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_basic_token").Value;

			    // Authorization Api Proxy
			    common.auth_api_url =             appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_url").Value;
			    common.auth_api_remote =          appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_remote").Value;
			    common.auth_api_key =             appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_key").Value;
			    common.auth_api_key_value =       appSettings.GetChildren().FirstOrDefault(w => w.Key == "auth_api_key_value").Value;
			}
			catch (Exception Ex)
			{
				logInfo(Ex.Message + Ex.InnerException?.Message);
			}
		}

        public void InsLezioni()
        {
			logInfo("=========================================================================");
			logInfo("InsLezioni Start");

            try
            {
			    int annoAccademico = common.annoAccademico;

                DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(common.connstring).Options;

                using (var context = new ApplicationDbContext(options))
                {
                    Repository _repository = new Repository(context);

                    string aaaa_aaaa = $"{annoAccademico}/{annoAccademico + 1}";    // es: 2022/2023

                    string ORIENTAMENTO_UNICO =         "-";
                    string CANALE_UNICO =               "Canale Unico";
                    string CURRICULUM_UNICO =           "Curriculum Unico";
                    string AFFIDAMENTO_DI_INCARICO =    "Affidamento di incarico";

                    int CREDITI_FORMATIVI_60 =          60;
                    int iderogazkind =                  1;      // Convenzionale
                    int idmacroareadidattica =          1;      // Macroarea 1, non si riesce a recuperarla
                    int idistitutokind =                9;      // Università statale
                    int idregUniv =                     3256;   // Utente Easy: Università di Lecce
                    int parIdStruttura =                9;      // Struttura padre
                    int idduratakind =                  1;      // Anni
                    int idaffidamentokind =             1;      // Affidamento di incarico

                    int idstrutturakind_facolta =       12;     // Facoltà
                    int idstrutturakind_dipartimento =  1;      // Dipartimento
                    int idstrutturakind_altro =         11;     // Altro

                    int sede_base =                     1;      // Es: Lecce

                    List<classescuolakind>   ListaTipoClasseScuola =    _repository.AllTipoClasseScuola();      // classescuolakind
                    List<corsostudiokind>    ListaTipoCorsoStudio =     _repository.AllTipoCorsoStudio();       // corsostudiokind
                    List<orakind>            ListaTipoLezione =         _repository.AllTipoLezione();           // orakind

                    List<areadidattica>      ListaAreaDidattica =       _repository.AllAreaDidattica();         // areadidattica
                    List<insegn>             ListaAttivitaDidattica =   _repository.AllAttivitaDidattica();     // insegn

                    List<classescuola>       ListaClasseScuola =        _repository.AllClasseScuola();          // classescuola
                    List<corsostudionorma>   ListaCorsoStudioNorma =    _repository.AllCorsoStudioNorma();      // corsostudionorma
                    List<corsostudio>        ListaCorsoStudio =         _repository.AllCorsoStudio();           // corsostudio

                    List<sede>               ListaSede =                _repository.AllSede();                  // sede
                    List<struttura>          ListaStruttura =           _repository.AllStruttura();             // struttura


                    List<didprog>           ListaDidatticaProgrammata = _repository.AllDidatticaProgrammata(aaaa_aaaa);
                    List<didprogcurr>       ListaCurriculum =           _repository.AllCurriculum(ListaDidatticaProgrammata.Select(s => s.iddidprog).ToList());
                    List<didprogori>        ListaOrientamento =         _repository.AllOrientamento(ListaCurriculum.Select(s => s.iddidprogcurr).ToList());
                    List<didproganno>       ListaAnno =                 _repository.AllAnno(ListaOrientamento.Select(s => s.iddidprogori).ToList());
                    List<didprogporzanno>   ListaPorzioneAnno =         _repository.AllPorzioneAnno(ListaAnno.Select(s => s.iddidproganno).ToList());
                    List<attivform>         ListaAttivitaFormativa =    _repository.AllAttivitaFormativa(ListaPorzioneAnno.Select(s => s.iddidprogporzanno).ToList());
                    List<canale>            ListaCanale =               _repository.AllCanale(ListaAttivitaFormativa.Select(s => s.idattivform).ToList());
                    List<affidamento>       ListaAffidamento =          _repository.AllAffidamento(ListaCanale.Select(s => s.idcanale).ToList());
                    List<lezione>           ListaLezione =              _repository.AllLezione(ListaAffidamento.Select(s => s.idaffidamento).ToList());

					List<RegistroDocenteConDettagli> ListaRegistroDocenteConDettagli = new List<RegistroDocenteConDettagli>();
                    Dictionary<string, CorsoDiStudioConStruttura> listaCorsoDiStudioConStruttura = new Dictionary<string, CorsoDiStudioConStruttura>();
                    Dictionary<int, CorsoDiStudioConDettagli> listaCorsoDiStudioConDettagli = new Dictionary<int, CorsoDiStudioConDettagli>();

					string msg = "";
					bool success = false;
                    
                    // ============================================================================================================================
                    // WS: REGISTRI (idReg, cf): 1347
                    // ============================================================================================================================
                    List<RegistroDocente> ListaRegistroDocente = GetList<RegistroDocente>(out msg, out success, null, $"&aaOffId={annoAccademico}");

					if (!success)
					{
						logInfo($"Error in GetList<RegistroDocente> annoAccademico {annoAccademico}\r\n{msg}");
						logInfo("InsLezioni End");
                        return;
					}

                    if (ListaRegistroDocente.Count == 0)
                    {
						logInfo($"Attenzione! ListaRegistroDocente.Count == 0");
						logInfo("InsLezioni End");
						return;
                    }

					// ==============================================================
					// LISTA DEI CF DEI REGISTRI DOCENTI
					// ==============================================================
					List<string> listaCf = ListaRegistroDocente.Select(s => s.codFis).Distinct().ToList();

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					List<registryMin> ListaIdRegCfDocenti = _repository.RegistryByCf(listaCf);

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					List<string> ListaCfRegDocenti = ListaIdRegCfDocenti.Select(s => s.Cf).ToList();

					// ==============================================================
					// FILTRO !!!
					// ==============================================================
					//ListaCfRegDocenti = ListaCfRegDocenti.Where(w => w == "MLEGPP64D10H826D").ToList();

					// ==============================================================
					// QRY: LISTA DEI DOCENTI PRESENTI IN REGISTRY CON QUEI CF
					// ==============================================================
					// List<string> LogCfDocentiNonPresentiNelDb = listaCf.Where(w => !ListaCfRegDocenti.Contains(w)).ToList();

					// ==============================================================
					// PER OGNI REGISTRO DOCENTE PRESENTE IN REGISTRY
					// ==============================================================
					List<long> ListaIdDocentiPresenti = ListaRegistroDocente.Where(w => ListaCfRegDocenti.Contains(w.codFis)).Select(s => s.regId).Distinct().ToList();

					foreach (long regId in ListaIdDocentiPresenti)
                    {
                        // ============================================================================================================================
                        // WS REGISTRO DOCENTE, ottengo la rendicontazione del docente
                        // ============================================================================================================================
                        RegistroDocenteConDettagli registroDocenteConDettagli = Get<RegistroDocenteConDettagli>(out msg, out success, new object[1] { regId });

						if (!success)
						{
							logInfo($"Error in Get<RegistroDocenteConDettagli> regId {regId}\r\n{msg}");
							logInfo("InsLezioni End");
							return;
						}

						// Se esiste
						if (registroDocenteConDettagli != null)
                        {
                            // Controllo la presenza di attività didattica
                            if (registroDocenteConDettagli.attivita != null)
                            {
                                if (registroDocenteConDettagli.attivita.Count() > 0)
                                {
                                    // e lo aggiungo
                                    ListaRegistroDocenteConDettagli.Add(registroDocenteConDettagli);
                                }
                            }
                        }
                    }

                    // ==============================================================
                    // Logistiche
                    // ==============================================================
                    List<RegistroDocenteLog> logistiche = ListaRegistroDocenteConDettagli.SelectMany(s => s.logistica.ToList()).Distinct(new RegistroDocenteLogComparer()).ToList();

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

							if (!success)
							{
								logInfo($"Error in Get<CorsoDiStudioConStruttura> corsoDiStudioCodice {corsoDiStudioCodice}\r\n{msg}");
								logInfo("InsLezioni End");
								return;
							}

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
                                ListaTipoCorsoStudio.Add(_repository.AddTipoCorsoStudio(title: tipoCorsoDiStudioDescrizione));
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
                                ListaAreaDidattica.Add(_repository.AddAreaDidattica(title: areaDidatticaDescrizione,
                                                                     idmacroareadidattica: idmacroareadidattica,
                                                                        idcorsostudiokind: idcorsostudiokind));
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
                                ListaTipoClasseScuola.Add(_repository.AddTipoClasseScuola(cod: tipoDiTitoloCorsoDiStudioCodice,
                                                                                        title: tipoDiTitoloCorsoDiStudioDescrizione,
                                                                            idcorsostudiokind: idcorsostudiokind));
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
                                ListaCorsoStudioNorma.Add(_repository.AddCorsoStudioNorma(title: normativaCorsoDiStudioDescrizione,
                                                                                 idistitutokind: idistitutokind));
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
                                ListaClasseScuola.Add(_repository.AddClasseScuola(sigla: classeCorsoDiStudioSigla,
                                                                                  title: classeCorsoDiStudioDescrizione,
                                                                     idclassescuolakind: tipoDiTitoloCorsoDiStudioCodice,
                                                                     idcorsostudionorma: idcorsostudionorma,
                                                                     idclassescuolaarea: idclassescuolaarea));
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

							if (!success)
							{
								logInfo($"Error in Get<CorsoDiStudioConDettagli> corsoDiStudioId {corsoDiStudioId}\r\n{msg}");
								logInfo("InsLezioni End");
								return;
							}

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
                                    ListaSede.Add(_repository.AddSede(idreg: idregUniv,
                                                                      title: sediCorso.sedeDes));
                                }
                            }
                        }
                        else
                        {
							logInfo($"Attenzione! Sede corso non trovata!");
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
                                        ListaStruttura.Add(_repository.AddStruttura(idstruttura: strutturaId,
                                                                                         codice: strutturaCodice,
                                                                                  denominazione: strutturaDes,
                                                                               denominazioneEng: strutturaDesEng,
                                                                                idstrutturakind: idstrutturakind,
                                                                                  idcorsostudio: corsoDiStudioId,
                                                                                          idreg: idregUniv,
                                                                                         idsede: idsedeStruttura,
                                                                                 paridstruttura: parIdStruttura));
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
                                    ListaAttivitaDidattica.Add(_repository.AddAttivitaDidattica(idinsegn: attivitaDidatticaId,
                                                                                                  codice: attivitaDidatticaCodice,
                                                                                           denominazione: attivitaDidatticaDescrizione,
                                                                                       idcorsostudiokind: idcorsostudiokind,
                                                                                             idstruttura: strutturaId,
                                                                                           idcorsostudio: corsoDiStudioId));
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
                                    ListaCorsoStudio.Add(_repository.AddCorsoStudio(idcorsostudio: corsoDiStudioId,
                                                                                      annoistituz: annoistituz,
                                                                                           codice: corsoDiStudioCodice,
                                                                                            title: corsoDiStudioDescrizione,
                                                                                         title_en: corsoDiStudioDescrizioneEng,
                                                                                idcorsostudiokind: idcorsostudiokind,
                                                                             idcorsostudiolivello: idcorsostudiolivello,
                                                                               idcorsostudionorma: idcorsostudionorma,
                                                                                     idduratakind: idduratakind,
                                                                                      idstruttura: strutturaId,
                                                                                           durata: percorsoDiStudioDurataAnni
                                    ));
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
                                    ListaDidatticaProgrammata.Add(
                                        _repository.AddDidatticaProgrammata(idcorsostudio: corsoDiStudioId,
                                                                                       aa: aaaa_aaaa,
                                                                                    title: corsoDiStudioDescrizione,
                                                                                 title_en: corsoDiStudioDescrizioneEng,
                                                                                   codice: corsoDiStudioCodice,
                                                                               annosolare: annosolare,
                                                                          idareadidattica: idareadidattica,
                                                                             iderogazkind: iderogazkind,
                                                                                   idsede: idSedeCorsoDiStudio,
                                                                                  website: sitoWeb)
                                    );
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
                                            ListaCurriculum.Add(
                                                _repository.AddCurriculum(iddidprog: iddidprog,
                                                                      idcorsostudio: corsoDiStudioId,
                                                                             codice: percorsoDiStudioCodice,
                                                                              title: CURRICULUM_UNICO)
                                            );
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
                                            ListaOrientamento.Add(
                                                _repository.AddOrientamento(idcorsostudio: corsoDiStudioId,
                                                                                iddidprog: iddidprog,
                                                                            iddidprogcurr: iddidprogcurr,
                                                                                    title: ORIENTAMENTO_UNICO)
                                            );
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
                                            ListaAnno.Add(
                                                _repository.AddAnno(idcorsostudio: corsoDiStudioId,
                                                                                    iddidprog: iddidprog,
                                                                                iddidprogcurr: iddidprogcurr,
                                                                                 iddidprogori: iddidprogori,
                                                                                           aa: aaaa_aaaa,
                                                                                         anno: annoAccademico,
                                                                                        title: progannoTitle,
                                                                             creditiformativi: CREDITI_FORMATIVI_60)
                                                );
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
                                            ListaPorzioneAnno.Add(
                                                _repository.AddPorzioneAnno(idcorsostudio: corsoDiStudioId,
                                                                                iddidprog: iddidprog,
                                                                            iddidprogcurr: iddidprogcurr,
                                                                             iddidprogori: iddidprogori,
                                                                            iddidproganno: iddidproganno,
                                                                    iddidprogporzannokind: iddidprogporzannokind,
                                                                                       aa: aaaa_aaaa,
                                                                                    start: inizioPorzAnno,
                                                                                     stop: finePorzAnno,
                                                                                    title: didprogporzannoTitle)
                                            );
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
                                            ListaAttivitaFormativa.Add(
                                                _repository.AddAttivitaFormativa(idcorsostudio: corsoDiStudioId,
                                                                                     iddidprog: iddidprog,
                                                                                 iddidprogcurr: iddidprogcurr,
                                                                                  iddidprogori: iddidprogori,
                                                                                 iddidproganno: iddidproganno,
                                                                             iddidprogporzanno: iddidprogporzanno,
                                                                                        idsede: idSedeCorsoDiStudio,
                                                                                      idinsegn: attivitaDidatticaId,
                                                                                            aa: aaaa_aaaa,
                                                                                         title: attivitaDidatticaDescrizione)
                                            );
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
                                            ListaCanale.Add(
                                                _repository.AddCanale(idcorsostudio: corsoDiStudioId,
                                                                          iddidprog: iddidprog,
                                                                      iddidprogcurr: iddidprogcurr,
                                                                       iddidprogori: iddidprogori,
                                                                      iddidproganno: iddidproganno,
                                                                  iddidprogporzanno: iddidprogporzanno,
                                                                        idattivform: idattivform,
                                                                             idsede: idSedeCorsoDiStudio,
                                                                                 aa: aaaa_aaaa,
                                                                              title: CANALE_UNICO)
                                            );
                                        }
                                    }
                                }
                            }
                        }

                        if (!ListaAreaDidattica.Any(w => w.title == areaDidatticaDescrizione))
                        {
                            // Add Tipo Corso di Studio
                            ListaAreaDidattica.Add(_repository.AddAreaDidattica(title: areaDidatticaDescrizione,
                                                                 idmacroareadidattica: idmacroareadidattica,
                                                                    idcorsostudiokind: idcorsostudiokind));
                        }
                    }


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
                                int corsoDiStudioId = 0;
                                int attivitaDidatticaId = 0;
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
                                    string corsoDiStudioCodice = logistica.cdsCod;
                                    corsoDiStudioId = (int)logistica.cdsId;
                                    string attivitaDidatticaCodice = logistica.adCod;

                                    // ==============================================================
                                    // IdInsegn
                                    // ==============================================================
                                    attivitaDidatticaId = (int)logistica.adId;

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

                                        ListaAffidamento.Add(
                                            _repository.AddAffidamento(idcorsostudio: corsoDiStudioId,
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
                                                                        jsonancestor: jsonancestor)
                                            );
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
                                        ListaTipoLezione.Add(_repository.AddTipoLezione(att.tipoAttDes));
                                    }
                                    // Get Tipo Corso di Studio
                                    int idorakind = ListaTipoLezione.FirstOrDefault(w => w.title == att.tipoAttDes).idorakind;

                                    // ==============================================================
                                    // Lezione Inizio/Fine
                                    // ==============================================================
                                    DateTime inizioLezione = DateTime.Parse(att.data.Substring(0, 11) + att.oraInizio);
                                    DateTime fineLezione = inizioLezione.AddHours(att.oreAccademiche);

                                    // ==============================================================
                                    // 10) Lezione
                                    // ==============================================================
                                    lezione lezione = ListaLezione.FirstOrDefault(w => w.idcorsostudio == corsoDiStudioId
                                                                                        && w.iddidprog == iddidprog
                                                                                    && w.iddidprogcurr == iddidprogcurr
                                                                                     && w.iddidprogori == iddidprogori
                                                                                    && w.iddidproganno == iddidproganno
                                                                                && w.iddidprogporzanno == iddidprogporzanno
                                                                                      && w.idattivform == idattivform
                                                                                         && w.idcanale == idcanale
                                                                                    && w.idaffidamento == idaffidamento
                                                                                    && w.idreg_docenti == idreg
                                                                                            && w.start == inizioLezione
                                                                                             && w.stop == fineLezione
                                                                                               && w.aa == aaaa_aaaa);
                                    if (lezione == null)
                                    {
                                        _repository.AddLezione(idcorsostudio: corsoDiStudioId,
                                                                   iddidprog: iddidprog,
                                                               iddidprogcurr: iddidprogcurr,
                                                                iddidprogori: iddidprogori,
                                                               iddidproganno: iddidproganno,
                                                           iddidprogporzanno: iddidprogporzanno,
                                                                 idattivform: idattivform,
                                                                      idsede: idSedeCorsoDiStudio,
                                                               idaffidamento: idaffidamento,
                                                                    idcanale: idcanale,
                                                               idreg_docenti: idreg,
                                                                       start: inizioLezione,
                                                                        stop: fineLezione,
                                                                          aa: aaaa_aaaa);
                                    }
                                    else
                                    {
                                        ListaLezione.Remove(lezione);
                                    }
                                }
                            }
                        }
                    }

					logInfo($"Cnt: {ListaRegistroDocente.Count} - " +
							$"{listaCf.Count} - " +
							$"{ListaIdRegCfDocenti.Count} - " +
							$"{ListaCfRegDocenti.Count} - " +
							$"{ListaIdDocentiPresenti.Count} - " +
							$"{logistiche.Count}  - " +
							$"{ListaRegistroDocenteConDettagli.Count} - " +
							$"{ListaLezione.Count}");

					// ==============================================================
					// Elimino le Lezioni eliminate o modificate (del più ins)
					// ==============================================================
					foreach (lezione lezione in ListaLezione)
                        _repository.DeleteLezione(lezione.idlezione);
				}
			}
			catch (Exception Ex)
			{
				logInfo("Errore InsLezioni: \r\n" + Ex.Message + "\r\n" + Ex.InnerException?.Message);
			}

			logInfo("InsLezioni End");
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

		// =======================================================================================================================================
		// PRINT LOG
		// =======================================================================================================================================
		private void logInfo(string s)
		{
			try { System.IO.File.AppendAllText($"{AppDomain.CurrentDomain.BaseDirectory}{_logFileName}", DateTime.Now.ToString("yy-MM-dd hh:mm:ss") + " - " + s + "\r\n"); } catch { }
		}
	}
}
