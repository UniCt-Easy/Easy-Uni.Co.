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
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace calcolocedolino { //calcolocedolino//
    /// <summary>
    /// Summary description for CalcoliCococo.
    /// </summary>
    public class CalcoliCococo {
        DataSet dsContratto;
        vistaForm DS;
        DataAccess Conn;
        MetaData MetaCedolino;
        MetaData MetaCedolinoRitenuta;
        MetaData MetaCedolinoRitenutaScaglione;
        MetaData MetaDettaglioDeduzioneCedolino;
        MetaData MetaDettaglioDetrazioneCedolino;
        MetaData MetaFamiliare;
        MetaData MetaStorno;
        MetaData MetaEntry;
        QueryHelper QHS;
        CQueryHelper QHC;

        int esercizio;

        // imponibile minimo e massimo ai fini dell'applicazione del bonus finscale
        decimal minAnnualTaxable = 24600; // task 11853

        decimal maxAnnualTaxable = 26600;

        /// <summary>
        /// Costruttore di base
        /// </summary>
        /// <param name="E"></param>
        /// <param name="conn"></param>
        private CalcoliCococo(MetaDataDispatcher E, DataAccess conn) {
            DS = new vistaForm();
            ClearDataSet.RemoveConstraints(DS);
            Conn = conn;
            esercizio = CfgFn.GetNoNullInt32(E.GetSys("esercizio"));
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            MetaCedolino = E.Get("payroll");
            MetaCedolinoRitenuta = E.Get("payrolltax");
            MetaCedolinoRitenutaScaglione = E.Get("payrolltaxbracket");
            MetaDettaglioDeduzioneCedolino = E.Get("payrolldeduction");
            MetaDettaglioDetrazioneCedolino = E.Get("payrollabatement");
            MetaFamiliare = E.Get("parasubcontractfamily");
            MetaStorno = E.Get("payrolltaxcorrige");
            MetaEntry = E.Get("entry");
        }

        /// <summary>
        /// Costruttore per il calcolo multiplo dei cedolini
        /// </summary>
        /// <param name="E"></param>
        /// <param name="conn"></param>
        /// <param name="filtroCedolini">cedolini che si vogliono calcolare</param>
        public CalcoliCococo(MetaDataDispatcher E, DataAccess conn, string filtroCedolini) : this(E, conn) {
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.payroll, null, filtroCedolini, null, true);

            string filtroContratti = QHS.FieldIn("idcon", DS.payroll.Select(), "idcon");
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.parasubcontract, null, filtroContratti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.otherinail, null, filtroContratti, null, true);

            string filtroPat = QHS.FieldIn("idpat", DS.parasubcontract.Select(), "idpat");
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.pat, null, filtroPat, null, true);

            string filtroImpContratti = QHS.AppAnd(filtroContratti, QHS.CmpEq("ayear", esercizio));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.parasubcontractyear, null, filtroImpContratti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.cafdocument, null, filtroImpContratti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.deductibleexpense, null, filtroImpContratti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.abatableexpense, null, filtroImpContratti, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.parasubcontractfamily, null, filtroImpContratti, null, true);

            string filtroCud = QHS.AppAnd(filtroContratti, QHS.CmpEq("fiscalyear", esercizio));
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.exhibitedcud, null, filtroCud, null, true);

            string filtroDettCedol = QHS.FieldIn("idpayroll", DS.payroll.Select(), "idpayroll");
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.payrolltax, null, filtroDettCedol, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.payrolldeduction, null, filtroDettCedol, null, true);

            string filtroDettCud =
                columnValues(DS.exhibitedcud.Select(), new string[] {"idexhibitedcud", "idcon"}, true);
            if (filtroDettCud != "") {
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.exhibitedcuddeduction, null, filtroDettCud, null, true);
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.exhibitedcudabatement, null, filtroDettCud, null, true);
            }

            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.deduction, null, null, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.abatement, null, null, null, true);

            riempiDataSet();
        }

        /// <summary>
        /// Costruttore per il calcolo di un singolo cedolino
        /// </summary>
        /// <param name="E"></param>
        /// <param name="conn"></param>
        /// <param name="ds">Dataset del form contratto</param>
        public CalcoliCococo(MetaDataDispatcher E, DataAccess conn, DataSet ds) : this(E, conn) {
            dsContratto = ds;
            foreach (DataTable t in DS.Tables) {
                if ((t.TableName != "tax") && (t.TableName != "taxablekind")) {
                    foreach (DataRow rSorg in ds.Tables[t.TableName].Rows) {
                        if (rSorg.RowState != DataRowState.Deleted) {
                            DataRow r = t.NewRow();
                            foreach (DataColumn c in t.Columns) {
                                r[c] = rSorg[c.ColumnName];
                            }
                            t.Rows.Add(r);
                        }
                    }
                }
            }
            riempiDataSet();
        }

        /// <summary>
        /// Chiamato dai costruttori per leggere ulteriori tabelle
        /// </summary>
        private void riempiDataSet() {
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.tax, null, null, null, true);
            string filtroEsercizio = QHS.CmpEq("ayear", esercizio);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.deductioncode, null, filtroEsercizio, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.abatementcode, null, filtroEsercizio, null, true);
            DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.taxablekind, "evaluationorder asc", filtroEsercizio, null, true);
        }

        #region Gestione CUD


        public class cudContratto {
            public DateTime dataInizioCompetenza;
            public DateTime dataFineCompetenza;
            public string flagignoracudprecedenti;
            public object codicefiscalealtrosostituto;
            public int numeroGiorni;
            public int numeroMesi;
            public decimal imponibilePrevidenziale;
            public decimal imponibilefiscalelordo;
            public decimal addComApplicata;
            public decimal accontoAddComunale;
            public decimal addRegApplicata;
            public decimal irpefApplicata;
            public decimal contributiTrattenuti;
            public decimal contributiDovuti;
            public int idCity;
            public object idFiscalTaxRegion;
            public decimal irpefGross;
            public decimal earnings_based_abatements;
            public decimal totabatements;
            public decimal fiscalBonusApplied;
        }

        /// <summary>
        /// Metodo che ottiene le informazioni dai CUD associati ad un contratto
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="rContrattoContenitore">DataRow del contratto contenitore (idcon)</param>
        /// <param name="rContrattoContenuto">DataRow del contratto contenuto (linkedidcon)</param>
        /// <param name="dataInizioCompetenza">OUTPUT - Data di inizio competenza del contratto</param>
        /// <param name="dataFineCompetenza">Data di fine competenza del contratto</param>
        /// <param name="flagignoracudprecedenti">Flag che ignora i CUD precedenti</param>
        /// <param name="codicefiscalealtrosostituto">C.F. del datore di lavoro del CUD</param>
        /// <param name="numeroGiorni">Numero dei giorni</param>
        /// <param name="numeroMesi">Numero dei mesi</param>
        /// <param name="imponibilePrevidenziale">Imponibile Previdenziale</param>
        /// <param name="imponibilefiscalelordo">Imponibile Fiscale Lordo</param>
        /// <param name="addComApplicata">Addizionale Comunale Applicata</param>
        /// <param name="accontoAddComunale">Acconto all'Addizionale Comunale Applicata</param>
        /// <param name="addRegApplicata">Addizionale Regionale Applicata</param>
        /// <param name="irpefApplicata">IRPEF Applicata</param>
        /// <param name="contributiTrattenuti">Contributi Trattenuti</param>
        /// <param name="contributiDovuti">Contributi Dovuti</param>
        /// <param name="idCity">ID del Comune</param>
        /// <param name="idFiscalTaxRegion">ID della Regione Fiscale</param>
        public static cudContratto getInfoCudFromContratto(
            DataAccess Conn,
            DataRow rContrattoContenitore,
            DataRow rContrattoContenuto
        ) {
            QueryHelper QHS = Conn.GetQueryHelper();
            CQueryHelper QHC = new CQueryHelper();
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            object idContratto = rContrattoContenuto["idcon"];
            object idDbDepartment = rContrattoContenuto["iddbdepartment"];

            // Tabella di imputazione del contratto oer il contratto corrente
            string query = "SELECT * FROM " + idDbDepartment + ".parasubcontractyear " +
                           " WHERE " +
                           QHS.AppAnd(QHS.CmpEq("idcon", rContrattoContenuto["idcon"]), QHS.CmpEq("ayear", esercizio));

            DataTable tImpContr = Conn.SQLRunner(query, true, 0);
            DataRow rContratto = tImpContr.Rows[0];

            object idser = Conn.DO_READ_VALUE(idDbDepartment + ".parasubcontract",
                QHS.CmpEq("idcon", rContrattoContenuto["idcon"]), "idser");
            object certificatekind = Conn.DO_READ_VALUE("service", QHS.CmpEq("idser", idser), "certificatekind");
            if (certificatekind.ToString().ToUpper() != "U") {
                return null;
            }
            cudContratto Cud = new cudContratto();


            Cud.dataInizioCompetenza = (DateTime) rContratto["startcompetency"];
            Cud.dataFineCompetenza = (DateTime) rContratto["stopcompetency"];

            Cud.flagignoracudprecedenti = "N";

            Cud.codicefiscalealtrosostituto = Conn.DO_READ_VALUE("license", null, "cf");

            decimal imponibilePrevContratto = CfgFn.GetNoNullDecimal(rContratto["taxablepension"]);
            // Si calcola l'imponibile previdenziale totale (ossia quello del contratto corrente più quello degli altri
            // contratti associati per via dei CUD
            Cud.imponibilePrevidenziale =
                calcolaImponibilePrevidenziale(Conn, idContratto, imponibilePrevContratto, idDbDepartment);

            Cud.imponibilefiscalelordo = calcolaImponibileFiscaleLordo(Conn, idContratto, idDbDepartment);

            // devo calcolare la somma delle INPS, addizionali e IRPEF
            Cud.contributiDovuti =
                sommaContributiDovuti(Conn, idContratto, idDbDepartment, out Cud.contributiTrattenuti);
            Cud.irpefApplicata = sommaRitenutaFiscaleApplicata(Conn, idContratto, idDbDepartment, null);
            Cud.totabatements = sommaDetrazioniApplicateinConguaglio(Conn, idContratto, idDbDepartment,
                out Cud.earnings_based_abatements, out Cud.irpefGross);
            Cud.addRegApplicata = sommaRitenutaFiscaleApplicata(Conn, idContratto, idDbDepartment, "R");
            //addComApplicata    = sommaAddizionaleComunaleApplicata(Conn, idContratto);
            Cud.accontoAddComunale = sommaAccontoAddizionaleComunale(Conn, idContratto, idDbDepartment);
            Cud.addComApplicata = sommaRitenutaFiscaleApplicata(Conn, idContratto, idDbDepartment, "C");
            Cud.fiscalBonusApplied = sommaBonusFiscaleApplicato(Conn, idContratto, idDbDepartment);

            DateTime gen01 = new DateTime(esercizio, 1, 1);
            DateTime dec31 = new DateTime(esercizio, 12, 31);
            DateTime fineContratto = dec31;
            if ((rContratto["stopcompetency"] != DBNull.Value) &&
                ((DateTime) rContratto["stopcompetency"] < dec31)) {
                fineContratto = (DateTime) rContratto["stopcompetency"];
            }

            int idReg = CfgFn.GetNoNullInt32(rContrattoContenuto["idreg"]);

            Cud.idCity = CfgFn.GetNoNullInt32(calcolaComuneIndirizzoValido(Conn, idReg, gen01));
            object idCityForRegion = Cud.idCity;

            Cud.idFiscalTaxRegion = calcolaRegioneFiscale(Conn, idCityForRegion);


            DataTable LinkedCud = getCudLinkedToContract(Conn, rContrattoContenuto["idcon"], idDbDepartment);

            // Il modulo COCOCO non gestisce la sospensione dell'IRPEF e delle addizionali quindi i campi
            // irpefsospese, addizcomsospese, addizregsospese non vengono valorizzati
            //string filtroCud = QHS.AppAnd(QHS.CmpEq("idcon", rContrattoContenuto["idcon"]), QHS.CmpEq("fiscalyear", esercizio));

            foreach (DataRow rCud in LinkedCud.Select()) {
                //imponibilePrevidenziale += CfgFn.GetNoNullDecimal(rCud["taxablepension"]);
                //contributiDovuti += CfgFn.GetNoNullDecimal(rCud["inpsowed"]);
                //contributiTrattenuti += CfgFn.GetNoNullDecimal(rCud["inpsretained"]);
                if ((rCud["start"] is DateTime) && ((DateTime) rCud["start"] < Cud.dataInizioCompetenza)) {
                    Cud.dataInizioCompetenza = (DateTime) rCud["start"];
                }
                if ((rCud["stop"] is DateTime) && ((DateTime) rCud["stop"] > Cud.dataFineCompetenza)) {
                    Cud.dataFineCompetenza = (DateTime) rCud["stop"];
                }
            }
            Cud.numeroGiorni = (Cud.dataFineCompetenza - Cud.dataInizioCompetenza).Days + 1;
            Cud.numeroMesi = 12 * (Cud.dataFineCompetenza.Year - Cud.dataInizioCompetenza.Year) +
                             (Cud.dataFineCompetenza.Month - Cud.dataInizioCompetenza.Month) + 1;
            return Cud;
        }



        /// <summary>
        /// Metodo che calcola l'imponibile previdenziale totale partendo da un contratto
        /// </summary>
        /// <param name="Conn">Connessione al DB</param>
        /// <param name="idContratto">ID del contratto di partenza</param>
        /// <param name="imponibilePrevContratto">Imponibile Previdenziale del Contratto</param>
        /// <returns></returns>
        private static decimal calcolaImponibilePrevidenziale(DataAccess Conn,
            object idContratto, decimal imponibilePrevContratto, object idDbDepartment) {
            decimal imponibilePrevidenziale = imponibilePrevContratto;

            string tName = idDbDepartment + ".parasubcontractsummaryview";
            QueryHelper QHS = Conn.GetQueryHelper();
            // Legge la ritenuta Erariale, e la sottrate dall'imponiible previdenziale
            decimal taxErariale = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE(tName,
                QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))),
                "taxerariale"));
            imponibilePrevidenziale =
                CfgFn.GetNoNullDecimal(imponibilePrevidenziale) - CfgFn.GetNoNullDecimal(taxErariale);

            imponibilePrevidenziale +=
                calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "taxablepension", null, false);

            return imponibilePrevidenziale;
        }



        /// <summary>
        /// Metodo che calcola la somma di un certo campo dei cud collegati
        /// </summary>
        /// <param name="Conn">Connessione al DB</param>
        /// <param name="idContratto">ID del contratto di partenza</param>
        /// <param name="imponibilePrevContratto">Imponibile Previdenziale del Contratto</param>
        /// <param name="fieldToConsider">Campo del cud da considerare per la somma</param>
        /// <param name="iterate">Se true, prende il dato dai contratti collegati anziché dal cud se questo non è cartaceo</param>
        /// <returns></returns>
        private static decimal calcolaTotaleRicorsivoCud(DataAccess Conn,
            object idContratto, object idDbDepartment, string fieldToConsiderCud, string fieldToConsiderSummaryView,
            bool iterate) {
            // Si ottiene l'elenco dei CUD associati al contratto
            QueryHelper QHS = Conn.GetQueryHelper();


            // Si ottiene l'imponibile fiscale lordo del contratto corrente
            decimal totale = 0;
            if (fieldToConsiderSummaryView != null) {
                string tName = idDbDepartment + ".parasubcontractsummaryview";
                totale += CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE(tName,
                    QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("ayear", Conn.GetSys("esercizio"))),
                    fieldToConsiderSummaryView));
            }

            if (fieldToConsiderCud == null)
                return totale;

            DataTable LinkedCud = getCudLinkedToContract(Conn, idContratto, idDbDepartment);

            // Se il CUD è cartaceo il dato viene preso dal CUD
            // Altrimenti viene eseguita la ricorsione del metodo corrente in modo da ottenere il dato
            // direttamente dal contratto collegato al CUD
            foreach (DataRow ExC in LinkedCud.Rows) {
                if (ExC["idlinkedcon"] == DBNull.Value || (iterate == false)) {
                    totale += CfgFn.GetNoNullDecimal(ExC[fieldToConsiderCud]);
                }
                else {
                    totale += calcolaTotaleRicorsivoCud(Conn, ExC["idlinkedcon"], ExC["idlinkeddbdepartment"],
                        fieldToConsiderCud, fieldToConsiderSummaryView, true);
                }
            }
            return totale;


        }


        /// <summary>
        /// Metodo che calcola la somma dei contributi previdenziali dovuti all'INPS e trattenuti al dipendente
        /// </summary>
        /// <param name="idContratto">ID del contratto al quale sono legati i cedolini</param>
        /// <param name="contributiTrattenuti">Totale dei contributi c/dip trattenuti</param>
        /// <returns>Totale dei contributi dovuti (sia c/dip sia c/amm)</returns>
        private static decimal sommaContributiDovuti(DataAccess Conn, object idContratto, object idDbDepartment,
            out decimal contributiTrattenuti) {
            // Elenco dei cedolini rata del contratto (sono rata perché l'ultimo parametro è false;
            // si usa true per ottenere il conguaglio)
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(Conn, idContratto, idDbDepartment, false);
            if (rCedolini.Length == 0) {
                contributiTrattenuti = 0;
                return 0;
            }
            // I contributi dovuti sono i contributi previdenziali indipendentemente dal carico
            decimal contributiDovuti = 0;
            // I contributi trattenuti sono i contributi previdenziali trattenuti al dipendente
            contributiTrattenuti = 0;
            QueryHelper QHS = Conn.GetQueryHelper();
            string query = "";
            // Per ogni cedolino rata appartenente al contratto corrente
            // si ottiene l'elenco delle ritenute previdenziali e si procede a sommare 
            // la parte c/dipendente alla variabile dei contributi trattenuti ed entrambe a quella dei contributi dovuti
            foreach (DataRow rCedolino in rCedolini) {
                string filtro = QHS.AppAnd(QHS.CmpEq("idpayroll", rCedolino["idpayroll"]), QHS.CmpEq("taxkind", 3));
                query = "SELECT employtax,admintax FROM " + idDbDepartment + ".payrolltaxview" +
                        " WHERE " + filtro;
                DataTable tCedRit = Conn.SQLRunner(query, true, 0);

                if ((tCedRit == null) || (tCedRit.Rows.Count == 0)) continue;
                foreach (DataRow rCedRit in tCedRit.Rows) {
                    contributiTrattenuti += CfgFn.GetNoNullDecimal(rCedRit["employtax"]);
                    contributiDovuti += CfgFn.GetNoNullDecimal(rCedRit["employtax"]) +
                                        CfgFn.GetNoNullDecimal(rCedRit["admintax"]);
                }
            }

            //Dopo aver calcolato i contributi dovuti e trattenuti del contratto bisogna anche sommare agli stessi
            // i contributi dovuti e trattenuti dei CUD associati a tale contratto
            contributiDovuti += calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "inpsowed", null, false);
            contributiTrattenuti +=
                calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "inpsretained", null, false);
            return contributiDovuti;
        }

        /// <summary>
        /// Metodo che restituisce il totale della ritenuta fiscale applicata
        /// </summary>
        /// <param name="idContratto">ID del contratto da cui ricavare la ritenuta fiscale</param>
        /// <param name="tipoApplicazioneGeografica">Applicazione geografica della ritenuta, assume i seguenti valori
        /// NULL: Nel caso di ritenuta fiscale a livello nazionale (ad es. IRPEF)
        /// R: Ritenuta fiscale a livello regionale (ad es. Addizionale Regionale)
        /// C: Ritenuta fiscale a livello comunale (ad es. Addizionale Comunale)</param>
        /// <returns></returns>
        private static decimal sommaRitenutaFiscaleApplicata(DataAccess Conn, object idContratto, object idDbDepartment,
            object tipoApplicazioneGeografica) {
            // Cedolini di conguaglio del contratto corrente
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(Conn, idContratto, idDbDepartment, true);
            if (rCedolini.Length == 0) {
                return 0;
            }

            decimal ritenutaFiscale = 0;
            QueryHelper QHS = Conn.GetQueryHelper();
            // Si sommano le ritenute fiscali (tenendo conto dell'applicazione geografica come descritto nel summary del metodo)
            // per avere il risultato della ritenuta fiscale applicata.
            // Si lavora con il solo cedolino di conguaglio che ha dentro di se sia il dato relativo ai CUD associati
            // al contratto corrente sia il dato del contratto corrente
            foreach (DataRow rCedolino in rCedolini) {
                string tipoAppGeo = QHS.CmpEq("geoappliance", tipoApplicazioneGeografica);
                string filtro = QHS.AppAnd(tipoAppGeo, QHS.CmpEq("idpayroll", rCedolino["idpayroll"]),
                    QHS.CmpEq("taxkind", 1), QHS.Not(QHS.CmpEq("taxref", "14_BONUS_FISCALE")));
                string query = "SELECT employtax,admintax,annualpayedemploytax FROM " + idDbDepartment +
                               ".payrolltaxview" +
                               " WHERE " + filtro;
                DataTable tCedRit = Conn.SQLRunner(query, true, 0);
                if ((tCedRit == null) || (tCedRit.Rows.Count == 0)) {
                    //Se il cedolino non ha ritenute fiscali deve prendere la somma delle rit. fiscali dei cud relativi
                    string fieldToConsider = "irpefapplied";
                    if ((tipoApplicazioneGeografica != null) && (tipoApplicazioneGeografica.ToString() == "R")) {
                        fieldToConsider = "regionaltaxapplied";
                    }
                    if ((tipoApplicazioneGeografica != null) && (tipoApplicazioneGeografica.ToString() == "C")) {
                        fieldToConsider = "citytaxapplied";
                    }
                    ritenutaFiscale += calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, fieldToConsider,
                        null, false);

                    fieldToConsider = "irpefsuspended";
                    if ((tipoApplicazioneGeografica != null) && (tipoApplicazioneGeografica.ToString() == "R")) {
                        fieldToConsider = "suspendedregionaltax";
                    }
                    if ((tipoApplicazioneGeografica != null) && (tipoApplicazioneGeografica.ToString() == "C")) {
                        fieldToConsider = "suspendedcitytax";
                    }
                    ritenutaFiscale -= calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, fieldToConsider,
                        null, false);

                    continue;
                }
                else {
                    //altrimenti prende i dati dal conguaglio, che includono già tutti i cud precedenti in annualpayedemploytax
                    foreach (DataRow rCedRit in tCedRit.Rows) {
                        ritenutaFiscale += (CfgFn.GetNoNullDecimal(rCedRit["annualpayedemploytax"]) +
                                            CfgFn.GetNoNullDecimal(rCedRit["employtax"]));
                    }
                }
            }
            return ritenutaFiscale;
        }

        private static decimal sommaBonusFiscaleApplicato(DataAccess Conn, object idContratto, object idDbDepartment) {
            decimal bonusFiscale = 0;
            // Cedolino di conguaglio del contratto corrente
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(Conn, idContratto, idDbDepartment, true);
            if (rCedolini.Length == 0) {
                return 0;
            }
            QueryHelper QHS = Conn.GetQueryHelper();


            // Si sommano i bonus fiscali applicati ai singoli cedolini
            // al contratto corrente sia il dato del contratto corrente
            foreach (DataRow rCedolino in rCedolini) {
                string tipoAppGeo = QHS.IsNull("geoappliance"); //ritenuta fiscale non ad applicazione geografica
                string filtro = QHS.AppAnd(tipoAppGeo, QHS.CmpEq("idpayroll", rCedolino["idpayroll"]),
                    QHS.CmpEq("taxkind", 1), QHS.CmpEq("taxref", "14_BONUS_FISCALE"));
                string query1 = "SELECT annualcreditapplied, employtax FROM " + idDbDepartment + ".payrolltaxview" +
                                " WHERE " + filtro;
                DataTable tCedRit = Conn.SQLRunner(query1, true, 0);
                if ((tCedRit == null) || (tCedRit.Rows.Count == 0)) {
                    bonusFiscale += calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "fiscalbonusapplied",
                        null, false);
                }
                else {
                    foreach (DataRow rCedRit in tCedRit.Rows) {
                        bonusFiscale += CfgFn.GetNoNullDecimal(rCedRit["annualcreditapplied"]) +
                                        CfgFn.GetNoNullDecimal(rCedRit["employtax"]);
                    }
                }
            }

            return -bonusFiscale;
        }

        private static decimal sommaDetrazioniApplicateinConguaglio(DataAccess Conn, object idContratto,
            object idDbDepartment, out decimal earnings_based_abatements, out decimal employtaxgross) {
            // Cedolino di conguaglio del contratto corrente
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(Conn, idContratto, idDbDepartment, true);
            earnings_based_abatements = 0;
            employtaxgross = 0;
            if (rCedolini.Length == 0) {
                return 0;
            }
            QueryHelper QHS = Conn.GetQueryHelper();
            decimal detrazioniApplicate = 0;
            object idabatement = Conn.DO_READ_VALUE("abatement", QHS.CmpEq("description", "Detrazioni per reddito"),
                "idabatement");

            // Si sommano le detrazioni fiscali, e in particolare il dettaglio delle detrazioni per reddito 
            // Si lavora con il solo cedolino di conguaglio che ha dentro di se sia il dato relativo ai CUD associati
            // al contratto corrente sia il dato del contratto corrente
            foreach (DataRow rCedolino in rCedolini) {
                string tipoAppGeo = QHS.IsNull("geoappliance"); //ritenuta fiscale non ad applicazione geografica
                string filtro = QHS.AppAnd(tipoAppGeo, QHS.CmpEq("idpayroll", rCedolino["idpayroll"]),
                    QHS.CmpEq("taxkind", 1), QHS.Not(QHS.CmpEq("taxref", "14_BONUS_FISCALE")));
                string query = "SELECT employtaxgross, taxcode FROM " + idDbDepartment + ".payrolltaxview" +
                               " WHERE " + filtro;
                DataTable tCedRit = Conn.SQLRunner(query, true, 0);
                if ((tCedRit == null) || (tCedRit.Rows.Count == 0)) continue;

                foreach (DataRow rCedRit in tCedRit.Rows) {
                    string filterDetrCed = QHS.AppAnd(QHS.CmpEq("idpayroll", rCedolino["idpayroll"]),
                        QHS.CmpEq("taxcode", rCedRit["taxcode"])
                    );
                    string query1 = "SELECT * FROM " + idDbDepartment + ".payrollabatement" +
                                    " WHERE " + filterDetrCed;

                    employtaxgross = CfgFn.GetNoNullDecimal(rCedRit["employtaxgross"]);

                    DataTable rDetrCed = Conn.SQLRunner(query1, true, 0);

                    foreach (DataRow d in rDetrCed.Rows) {
                        detrazioniApplicate += CfgFn.GetNoNullDecimal(d["curramount"]);
                        if (CfgFn.GetNoNullInt32(idabatement) == CfgFn.GetNoNullInt32(d["idabatement"]))
                            earnings_based_abatements += CfgFn.GetNoNullDecimal(d["curramount"]);
                    }
                }

            }

            return detrazioniApplicate;
        }

        /*private static decimal sommaAddizionaleComunaleApplicata (DataAccess Conn, object idContratto) {
            DataRow[] rCedolini = ottieniCedoliniErogatiPerContratto(Conn, idContratto, true);
            if (rCedolini.Length == 0) {
                return 0;
            }
            decimal ritenutaFiscale = 0;
            QueryHelper QHS = Conn.GetQueryHelper();
            foreach (DataRow rCedolino in rCedolini) {
                string tipoAppGeo = QHS.CmpEq("geoappliance", 'C');
                string filtro = QHS.AppAnd(tipoAppGeo, QHS.CmpEq("idpayroll", rCedolino["idpayroll"]),
                                QHS.CmpEq("taxkind", 1), QHS.CmpEq("taxref","05_ADDCOMU"));
                DataTable tCedRit = DataAccess.RUN_SELECT(Conn, "payrolltaxview", "employtax,admintax,annualpayedemploytax", null, filtro, null, null, true);
                if ((tCedRit == null) || (tCedRit.Rows.Count == 0)) continue;
                foreach (DataRow rCedRit in tCedRit.Rows) {
                    ritenutaFiscale += (CfgFn.GetNoNullDecimal(rCedRit["annualpayedemploytax"]) + CfgFn.GetNoNullDecimal(rCedRit["employtax"]));
                }
            }
            return ritenutaFiscale;
        }*/

        /// <summary>
        /// Metodo che calcola la somma dell'acconto all'addizionale comunale applicata
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idContratto"></param>
        /// <returns></returns>
        private static decimal sommaAccontoAddizionaleComunale(DataAccess Conn, object idContratto,
            object idDbDepartment) {
            decimal ritenutaFiscale = 0;
            QueryHelper QHS = Conn.GetQueryHelper();
            string filtroContratto = QHS.CmpEq("idcon", idContratto);
            string filtroEsercizio = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
            string filtro = QHS.AppAnd(filtroContratto, filtroEsercizio);
            string query = "";
            // Si ottiene la tabella dell'imputazione contratto relativa all'anno in corso e si calcola
            // la somma dell'acconto applicato (il ciclo foreach è una generalizzazione andava anche bene
            // prendere solamente la prima riga di tContratto, giacché il filtro è sulla chiave ayear, idcon)

            query = "SELECT citytax_account FROM " + idDbDepartment + ".parasubcontractyear" +
                    " WHERE " + filtro;
            DataTable tContratto = Conn.SQLRunner(query, true, 0);

            if ((tContratto == null) || (tContratto.Rows.Count == 0))
                return ritenutaFiscale;
            foreach (DataRow rContratto in tContratto.Rows) {
                ritenutaFiscale += (CfgFn.GetNoNullDecimal(rContratto["citytax_account"]));
            }
            ritenutaFiscale +=
                calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "citytax_account", null, false);

            return ritenutaFiscale;
        }

        /// <summary>
        /// Metodo che ottiene i cedolini erogati del contratto nell'anno fiscale corrente
        /// </summary>
        /// <param name="idContratto">ID del contratto sul quale cercare i cedolini</param>
        /// <param name="isConguaglio">TRUE: Limita la ricerca ai cedolini di conguaglio; FALSE: limita la ricerca ai cedolini rata</param>
        /// <returns></returns>
        private static DataRow[] ottieniCedoliniErogatiPerContratto(DataAccess Conn, object idContratto,
            object idDbDepartment, bool isConguaglio) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string conguaglio = QHS.CmpEq("flagbalance", (isConguaglio) ? "S" : "N");
            string filtroCedolino = QHS.AppAnd(conguaglio,
                QHS.CmpEq("idcon", idContratto), QHS.CmpEq("fiscalyear", Conn.GetSys("esercizio")),
                QHS.IsNotNull("disbursementdate"));

            string query = "SELECT idpayroll FROM " + idDbDepartment + ".payroll" +
                           " WHERE " + filtroCedolino;
            DataTable tCedolini = Conn.SQLRunner(query, true, 0);
            DataRow[] rCedolini = tCedolini.Select();
            return rCedolini;
        }

        private static DataRow[] CalcolaCedoliniRataNellAnno(DataAccess Conn, object idContratto, int annoFiscale) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string conguaglio = QHS.CmpEq("flagbalance", "N");
            string filtroCedolino = QHS.AppAnd(conguaglio,
                QHS.CmpEq("idcon", idContratto), QHS.CmpEq("fiscalyear", annoFiscale));

            string query = "SELECT idpayroll FROM " + "payroll" +
                           " WHERE " + filtroCedolino;
            DataTable tCedolini = Conn.SQLRunner(query, true, 0);
            DataRow[] rCedolini = tCedolini.Select();
            return rCedolini;
        }

        /// <summary>
        /// L'imponibile fiscale lordo è calcolato come somma dell'imponibile "proprio" più quello dei propri contratti
        ///  inseriti come cud in modo diretto o indiretto, più i contratti cartacei inseriti direttamente o indirettamente
        /// L'importo "proprio" di un contratto è quello presente nel campo fiscaltaxablegross nella vista parasubcontractsummaryview
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idContratto"></param>
        /// <returns></returns>
        private static decimal calcolaImponibileFiscaleLordo(DataAccess Conn, object idContratto,
            object idDbDepartment) {
            return calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "taxablegross", "fiscaltaxablegross",
                true);

        }

        #endregion

        #region imponibili

        //TODO: Fare il conguaglio oltre che delle ritenute fiscali, anche dell'INAIL

        //TODO: L'id. pat non può essere unico, potrebbe cambiare al 1° luglio!
        //TODO: Nel calcolo del costo totale si deve calcolare il compenso medio mensile

        /// <summary>
        /// Calcola l'imponibile mensile di un cedolino
        /// a partire dall'imponibile previdenziale di tutto l'anno in corso,
        /// il numero di mesi lavorati nell'anno,
        /// i cud presentati che hanno data inizio minore o uguale alla data di inizio del cedolino
        /// e data fine maggiore o uguale alla data di fine del cedolino,
        /// e i minimali/massimali per il mese di competenza del cedolino
        /// </summary>
        /// <param name="spcalcoloimponibileriferimento">tipoimponibile.spcalcoloimponibileriferimento</param>
        /// <param name="imponibileDiRiferimento">somma imp. prev. dei cedolini di quest'anno</param>
        /// <param name="rCedolino">riga della tabella cedolino</param>
        /// <param name="compensoMedioMensile">somma dell'imponibile diviso il numero di cedolini di quest'anno</param>
        /// <returns>imponibile lordo calcolato chiamando spcalcoloimponibileriferimento</returns>
        public decimal calcolaImponibileLordo(
            string spcalcoloimponibileriferimento,
            decimal imponibileDiRiferimento,
            DataRow rCedolino,
            decimal compensoMedioMensile
        ) {
            // Sezione di recupero dati per passaggio di parametri
            int annoFiscale = (int) rCedolino["fiscalyear"];
            string natura = rCedolino["flagbalance"].ToString() == "S" ? "C" : "R";
            object idContratto = rCedolino["idcon"];
            DateTime dataInizioCedolino = (DateTime) rCedolino["start"];
            DateTime dataFineCedolino = (DateTime) rCedolino["stop"];
            CQueryHelper QHC = new CQueryHelper();

            int nPayroll = CfgFn.GetNoNullInt32(rCedolino["npayroll"]);
            string fCedolino = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpLt("npayroll", nPayroll));
            bool primoCedolinoAnnoFiscale = (DS.payroll.Select(fCedolino).Length == 0);
            DataRow rContratto = rCedolino.GetParentRow("parasubcontractpayroll");

            // I rami del case sono i valori presenti nella tabella taxablekind. Se un domani dovesse nascere l'esigenza
            // di creare un nuovo imponibile il valore posto nel campo evaluatesp dovrà diventare un nuovo ramo di questo case
            // in modo da richiamare un nuovo metodo
            switch (spcalcoloimponibileriferimento) {
                case "calcola_imponibile_addirpef":
                    return calcola_imponibile_addirpef(
                        imponibileDiRiferimento,
                        natura,
                        annoFiscale,
                        idContratto
                    );
                case "calcola_imponibile_assicurativo":
                    return calcola_imponibile_assicurativo(
                        idContratto, dataInizioCedolino, dataFineCedolino, compensoMedioMensile,
                        primoCedolinoAnnoFiscale
                    );
                case "calcola_imponibile_irpef":
                    return calcola_imponibile_irpef(
                        imponibileDiRiferimento
                    );
                case "calcola_imponibile_previdenziale":
                    return calcola_imponibile_previdenziale(
                        imponibileDiRiferimento, rCedolino
                    );
                case "calcola_imponibile_assistenziale":
                    return calcola_imponibile_assistenziale(
                        imponibileDiRiferimento
                    );
                case "calcola_imponibile_erariale":
                    return calcola_imponibile_erariale(
                        imponibileDiRiferimento
                    );
            }
            MessageBox.Show("Errore interno - non trovata la spcalcoloimponibileriferimento " +
                            spcalcoloimponibileriferimento);
            return -1;
        }

        /// <summary>
        /// Metodo che calcola l'imponibile fiscale per il calcolo dell'acconto all'addizionale comunale
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="esercizio"></param>
        /// <param name="idreg"></param>
        /// <returns></returns>
        static public decimal calcolaImpFiscalePerAccontoAddizCom(DataAccess Conn, int esercizio, int idreg) {
            QueryHelper QHS = Conn.GetQueryHelper();
            // L'imponibile è calcolato sommando gli imponibili lordi presenti nel riepilogo storico delle ritenute
            // con data di fine a NULL, filtrato sullo scaglione massimo della ritenuta in quanto 
            // per ritenute scaglionati l'imponibile lordo è ricopiato identico su tutti gli scaglioni

            string subQuery = "(SELECT MAX(C.nbracket) FROM expensetaxofficial C "
                              + " WHERE (C.idexp = P.idexp) AND (C.taxcode = P.taxcode) "
                              + " AND (C.stop IS NULL))";

            string query = "SELECT SUM(P.taxablegross) FROM expensetaxofficial P "
                           + " JOIN expense "
                           + " ON P.idexp = expense.idexp "
                           + " JOIN tax "
                           + " ON tax.taxcode = P.taxcode "
                           + " WHERE " + QHS.AppAnd(
                               QHS.CmpEq("expense.idreg", idreg), QHS.CmpEq("tax.taxkind", 1),
                               QHS.IsNull("tax.geoappliance"), QHS.CmpEq("expense.ymov", esercizio),
                               QHS.IsNull("P.stop"), QHS.CmpEq("nbracket", QHS.Field(subQuery)));

            return CfgFn.GetNoNullDecimal(Conn.DO_SYS_CMD(query));
        }

        /// <summary>
        /// Metodo che calcola la regione fiscale di una data città
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idCityForRegion"></param>
        /// <returns></returns>
        static public object calcolaRegioneFiscale(DataAccess Conn, object idCityForRegion) {
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            // Nella vista sottostante ad ogni città è associata la regione fiscale di appartenenza
            return Conn.DO_READ_VALUE("geo_cityfiscalview", QHS.CmpEq("idcity", idCityForRegion), "idfiscaltaxregion");
        }

        /// <summary>
        /// Metodo che calcola il comune di "residenza" in base alla data passata
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idreg"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        static public object calcolaComuneIndirizzoValido(DataAccess Conn, int idreg, DateTime date) {
            QueryHelper QHS = Conn.GetQueryHelper();
            // La data di riferimento deve essere 
            // 1) il 1 gennaio dell'esercizio corrente per l' applicazione delle addizionali comunali
            // 2) in caso di applicazione delle addizionali regionali, mentre prima era il 31 dicembre dell'esercizio contabile 
            // o la data di fine contratto se precedente, ora prendiamo anche qui il primo gennaio dell'esercizio corrente

            if (date == QueryCreator.EmptyDate()) return null;
            // Verifico esistenza di un domicilio fiscale alla data di riferimento
            object idDomFiscale = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idDomFiscale),
                "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
            object idComuneAddizionale = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
            idComuneAddizionale = trovaComuneAttuale(Conn, idComuneAddizionale);
            if ((idComuneAddizionale == DBNull.Value) || (idComuneAddizionale == null)) {
                // in assenza di un domicilio fiscale verifico l'esistenza di un indirizzo di residenza ala data di riferimento
                filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), QHS.CmpEq("idaddresskind", idResidenza),
                    "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + QHS.quote(date) + "))");
                idComuneAddizionale = Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
                idComuneAddizionale = trovaComuneAttuale(Conn, idComuneAddizionale);
            }
            if ((idComuneAddizionale != DBNull.Value) && (idComuneAddizionale != null)) {
                return idComuneAddizionale;
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Metodo che ottiene l'ID del comune attuale partendo da un ID di un comune che può essere "antico"
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idcomune"></param>
        /// <returns></returns>
        static public object trovaComuneAttuale(DataAccess Conn, object idcomune) {
            QueryHelper QHS = Conn.GetQueryHelper();
            // Se il comune passato è associato ad un nuovo comune (campo newcity) viene preso il newcity altrimenti
            // resta l'idcomune ricevuto in input
            if (idcomune != null && idcomune != DBNull.Value) {
                object newcomune = idcomune;
                while (newcomune != DBNull.Value) {
                    newcomune = Conn.DO_READ_VALUE("geo_city",
                        QHS.CmpEq("idcity", idcomune), "newcity", "idcity");
                    if (newcomune == DBNull.Value) return idcomune;
                    else {
                        idcomune = newcomune;
                    }
                }
                return newcomune;
            }
            else return idcomune;
        }

        /// <summary>
        /// Metodo che verifica se ad una data prestazione sono associate le addizionali (comunali o regionali)
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idser"></param>
        /// <param name="geoappliance"></param>
        /// <returns></returns>
        static public DataTable verificaAddizionaliPrestazione(DataAccess Conn, object idser, string geoappliance) {
            QueryHelper QHS = Conn.GetQueryHelper();
            string q1 = "SELECT servicetax.taxcode FROM servicetax "
                        + " JOIN tax "
                        + " ON tax.taxcode = servicetax.taxcode "
                        + " WHERE " + QHS.AppAnd(
                            QHS.CmpEq("tax.taxkind", 1), QHS.CmpEq("tax.geoappliance", geoappliance),
                            QHS.CmpEq("servicetax.idser", idser));

            DataTable T = Conn.SQLRunner(q1);
            return T;
        }

        /// <summary>
        /// Metodo che calcola l'acconto all'addizionale comunale
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="esercizio"></param>
        /// <param name="idcity"></param>
        /// <param name="idser"></param>
        /// <param name="taxable"></param>
        /// <param name="errMess"></param>
        /// <returns></returns>
        static public decimal calcolaAccontoAddCom(DataAccess Conn, int esercizio, object idcity, object idser,
            decimal taxable, out string errMess) {
            errMess = null;
            if ((idser == null) || (idser == DBNull.Value)) {
                errMess = "Non è stata selezionata la prestazione";
                return -1;
            }
            QueryHelper QHS = Conn.GetQueryHelper();
            // Si considera sempre come data massima il 15/2 anno corrente
            DateTime dataValidita = new DateTime(esercizio, 2, 15);

            // Si costruisce una query per ottenere il codice della ritenuta che rappresenta l'acconto
            string q1 = "SELECT servicetax.taxcode FROM servicetax "
                        + " JOIN tax "
                        + " ON tax.taxcode = servicetax.taxcode "
                        + " WHERE " + QHS.AppAnd(
                            QHS.CmpEq("tax.taxkind", 1), QHS.CmpEq("tax.geoappliance", "C"),
                            QHS.CmpEq("servicetax.idser", idser),
                            " (EXISTS(SELECT * FROM taxratecitystart T WHERE " +
                            QHS.AppAnd(QHS.CmpEq("T.idcity", idcity),
                                QHS.CmpLe("T.start", dataValidita),
                                QHS.CmpEq("T.taxcode", QHS.Field("servicetax.taxcode"))) + "))"
                        );

            object taxcode = Conn.DO_SYS_CMD(q1);
            if ((taxcode == null) || (taxcode == DBNull.Value)) {
                errMess = "Non esiste alcuna addizionale comunale legata alla prestazione scelta";
                return -1;
            }
            // Fissato il codice della ritenuta si cerca la struttura corrente
            // (per determinarne successivamente lo scaglione e poi ancora l'aliquota da applicare)
            string f1 = QHS.AppAnd(QHS.CmpLe("start", dataValidita),
                QHS.CmpEq("taxcode", taxcode),
                QHS.CmpEq("idcity", idcity));
            object idtaxratecitystart = Conn.DO_READ_VALUE("taxratecitystart", f1, "MAX(idtaxratecitystart)");

            if (idtaxratecitystart == null || idtaxratecitystart == DBNull.Value) {
                //errMess = "Non esiste alcuna data di validità";
                //return - 1;
                return 0; //Non ci sono scaglioni
            }
            decimal esente = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("taxratecitystart",
                QHS.AppAnd(QHS.CmpEq("idtaxratecitystart", idtaxratecitystart), QHS.CmpEq("idcity", idcity)),
                "taxablemin"));
            if (esente >= taxable) return 0;
            // Viene preso lo scaglione dove l'imponibile è compreso tra il limite minimo e massimo dello scaglione
            string f2 = QHS.AppAnd(QHS.CmpEq("taxcode", taxcode),
                QHS.CmpEq("idcity", idcity), QHS.CmpEq("idtaxratecitystart", idtaxratecitystart),
                QHS.CmpLe("ISNULL(minamount,0)", taxable),
                QHS.NullOrGe("maxamount", taxable)
            );

            DataTable tScaglione =
                DataAccess.RUN_SELECT(Conn, "taxratecitybracket", null, "nbracket", f2, null, null, false);

            if ((tScaglione == null) || (tScaglione.Rows.Count == 0)) {
                //errMess = "Il reddito specificato non ricade in alcuno scaglione";
                //return -1;
                return 0;
            }

            object rate = tScaglione.Rows[0]["rate"];
            if (rate == null) {
                errMess = "Non esiste alcuna aliquota per l'addizionale comunale";
                return -1;
            }
            // L'acconto dell'addizionale comunale è fissato per legge al 30% dell'addizionale dovuta
            decimal percAcconto = 0.30M;
            return CfgFn.RoundValuta((taxable * CfgFn.GetNoNullDecimal(rate) * percAcconto));
        }

        /// <summary>
        /// Calcola l'imponibile previdenziale a partire dal compenso lordo del cedolino. Input e Output coincidono
        /// </summary>
        /// <param name="compensoLordo">compenso lordo del cedolino</param>
        /// <returns>imponibile previdenziale del cedolino</returns>
        public decimal calcola_imponibile_previdenziale(
            decimal compensoLordo, DataRow rCedolino
        ) {
            return compensoLordo;
            //decimal sommaRitErariali = 0;
            //foreach(DataRow rtax in DS.payrolltax.Select(QHC.CmpEq("idpayroll",rCedolino["idpayroll"]))){
            //    object taxcode = rtax["taxcode"];
            //    DataRow[] rrTax = DS.tax.Select(QHC.CmpEq("taxcode", taxcode));
            //    if (rrTax.Length == 0) continue;
            //    object taxablecode = rrTax[0]["taxablecode"];
            //    if (taxablecode.ToString().ToUpper() != "ERARIALE") continue;
            //    sommaRitErariali += CfgFn.GetNoNullDecimal(rtax["employtax"]);
            //}

            //return compensoLordo - sommaRitErariali;
        }

        /// <summary>
        /// Input e Output coincidono
        /// </summary>
        /// <param name="compensoLordo"></param>
        /// <returns></returns>
        public decimal calcola_imponibile_erariale(
            decimal compensoLordo
        ) {
            // L'imponibile previdenziale è sempre assunto pari al compenso lordo passato in input
            return compensoLordo;
        }

        public decimal calcola_bonus_erogato_annuo(object idContratto, int annoFiscale, DateTime dataInizioCedolino) {
            decimal bonus_erogato_annuo = 0;
            string payrollList = QueryCreator.ColumnValues(DS.payroll,
                QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("flagbalance", "N"),
                    QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpLt("stop", dataInizioCedolino)),
                "idpayroll", false);

            if (payrollList != "") {
                string filterCedolini = QHC.AppAnd(QHC.FieldInList("idpayroll", payrollList),
                    QHC.FieldIn("taxcode", DS.tax.Select(QHC.CmpEq("taxref", "14_BONUS_FISCALE"))));

                DataRow[] rCedRit = DS.payrolltax.Select(filterCedolini);

                foreach (DataRow r in rCedRit) {
                    bonus_erogato_annuo += CfgFn.GetNoNullDecimal(r["employtax"]);
                }
            }

            return -bonus_erogato_annuo;
        }

        public decimal calcola_bonus_teorico_annuo(
            decimal redditoAnnuoComplessivo
        ) {

            decimal bonus_teorico_annuo = 0;
            if (redditoAnnuoComplessivo > maxAnnualTaxable) {
                bonus_teorico_annuo = 0;
            }
            else {
                if (redditoAnnuoComplessivo <= minAnnualTaxable) bonus_teorico_annuo = 960;
                else bonus_teorico_annuo = 960 * (maxAnnualTaxable - redditoAnnuoComplessivo) / 2000;
            }
            return bonus_teorico_annuo;
        }

        public decimal calcola_bonus_effettivo_annuo(
            decimal bonus_teorico_annuo,
            int annoFiscale,
            int ggLavoroInAnno // Stima dei giorni di lavoro che si effettueranno nell' anno, include sia CUD di precedenti Rapporti di lavoro che una previsione della durata fino a fine anno
        ) {
            // Una volta calcolato il bonus teorico annuo lo si deve rapportare al periodo di lavoro dell’anno quindi:
            // bonus effettivo spettante = [bonus annuo/365 (366)] * n. giorni lavorati  
            int giorniAnnoSolare = DateTime.IsLeapYear(annoFiscale) ? 366 : 365;
            if (ggLavoroInAnno > giorniAnnoSolare) ggLavoroInAnno = giorniAnnoSolare;
            decimal bonus_effettivo_spettante = 0;
            bonus_effettivo_spettante = (bonus_teorico_annuo / giorniAnnoSolare) * ggLavoroInAnno;
            return bonus_effettivo_spettante;
        }

        public decimal calcola_bonus_spettante_cedolino(
            decimal bonus_residuo_annuo,
            string natura,
            int ggcedolino,
            int ggLavoroContratto, //Durata nell'anno del contratto stesso
            int ggLavorati, // Giorni effettivi lavorati alla data del calcolo del cedolino,  non include CUD di precedenti Rapporti di lavoro
            int annoFiscale
        ) {
            if (CfgFn.RoundValuta(bonus_residuo_annuo) == 0) return 0;
            // Il Bonus Residuo spettante va ripartito in proporzione sui giorni da lavorare fino a fine anno per 
            // ottenere l'importo da accreditare sul presente cedolino

            int giorniAnnoSolare = DateTime.IsLeapYear(annoFiscale) ? 366 : 365;
            if (ggLavoroContratto > giorniAnnoSolare) ggLavoroContratto = giorniAnnoSolare;

            int ggDaLavorareAnno = ggLavoroContratto - ggLavorati;

            if (ggDaLavorareAnno == 0) return 0;

            decimal bonus_spettante_cedolino = 0;
            bonus_spettante_cedolino = (bonus_residuo_annuo / ggDaLavorareAnno) * ggcedolino;
            return bonus_spettante_cedolino;

        }

        public decimal calcola_imponibile_bonus_fiscale_2014(
            object idCedolino, string natura, object idContratto, int annoFiscale
        ) {
            // Condizione applicabilita' 1 Reddito annuo complessivo - Ritenute previdenziali c/dipendente – Ritenute assistenziali c/dipendente 
            //- deduzioni rendita catastale abitazione  < 26.0000 euro
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpEq("ayear", annoFiscale));

            // Si ottiene la riga di imputazione per determinare l'imponibile  
            DataRow[] imputazioneAnnuale = DS.parasubcontractyear.Select(filtro);
            decimal imponibileContratto = 0;
            if (imputazioneAnnuale.Length > 0)
                imponibileContratto = CfgFn.GetNoNullDecimal(imputazioneAnnuale[0]["taxablepension"]);
            ;

            // Si somma  l'imponibile dei CUD presentati relativi ai rapporti di lavoro precedenti
            imponibileContratto += sommaImponibileFiscaleCud(annoFiscale, idContratto);

            decimal imponibileBonus = 0;
            imponibileBonus = imponibileContratto;
            imponibileBonus -=
                calcola_deduzioni_per_ritenute_bonus_fiscale(idCedolino, natura, idContratto, annoFiscale);

            return imponibileBonus;
        }

        public decimal calcola_deduzioni_per_ritenute_bonus_fiscale(
            object idCedolino, string natura, object idContratto, int annoFiscale
        ) {

            decimal deduzione_annua_per_ritenute = 0;
            // Dall'imponibile di riferimento devo sottrarre le ritenute assistenziali e previdenziali carico lavoratore del presente contratto,
            // Non è possibile fare un calcolo delle ritenute globale a livello di contratto, perciò effettueremo una perequazione sul cedolino rata
            // natura vale C (cedolino Conguaglio), R (cedolino Rata)
            if (natura == "R") // Cedolino Rata
            {
                // Si considerano per il presente  cedolino rata la somma delle ritenute previdenziali ed assicurative
                // (INPS e INAIL) che saranno delle deduzioni per l'imponibile di riferimento del Bonus
                string filterPayrollList = QHC.CmpEq("idpayroll", idCedolino);

                string filterRitenute = QHC.AppAnd(filterPayrollList,
                    QHC.FieldIn("taxcode", DS.tax.Select(QHC.FieldIn("taxkind", new object[] {3, 4}))));

                DataRow[] rCedRit = DS.payrolltax.Select(filterRitenute);
                decimal sommaRitPrevidenziali = 0;
                foreach (DataRow r in rCedRit) {
                    sommaRitPrevidenziali += CfgFn.GetNoNullDecimal(r["employtax"]);
                }
                // Importo Ritenute Previdenziali / Assicurative calcolate nel presente cedolino
                decimal importoRitenute = CfgFn.GetNoNullDecimal(sommaRitPrevidenziali);
                // numero Giorni lavorati nel cedolino
                DataRow[] rCedolino = DS.payroll.Select(filterPayrollList);
                int giorniCedolino = 0;
                if (rCedolino.Length > 0)
                    giorniCedolino = CfgFn.GetNoNullInt32(rCedolino[0]["workingdays"]);

                // numero giorni lavorati nel contratto, leggo ndays di parasubcontractyear
                string filterContratto = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                    QHC.CmpEq("ayear", annoFiscale));

                // Si ottiene la riga di imputazione per determinare il totale giorni lavorati nell'anno  
                DataRow[] imputazioneAnnuale = DS.parasubcontractyear.Select(filterContratto);
                int giorniContratto = 0;
                if (imputazioneAnnuale.Length > 0)
                    giorniContratto = CfgFn.GetNoNullInt32(imputazioneAnnuale[0]["ndays"]);

                // Si effettua la perequazione sulla base di 
                // deduzione_annua_per_ritenute : giorniContratto =  importoRitenute : giorniCedolino
                deduzione_annua_per_ritenute = CfgFn.RoundValuta((importoRitenute * giorniContratto) / giorniCedolino);
            }
            else {
                //natura == "C" // Cedolino di Conguaglio
                decimal sommaRitPrevidenziali = 0;
                string payrollList = QueryCreator.ColumnValues(DS.payroll,
                    QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto),
                        QHC.CmpEq("flagbalance", "N")), "idpayroll", false);
                if (payrollList != "") {
                    string filterCedolini = QHC.AppAnd(QHC.FieldInList("idpayroll", payrollList),
                        QHC.FieldIn("taxcode", DS.tax.Select(QHC.FieldIn("taxkind", new object[] {3, 4}))));

                    DataRow[] rCedRit = DS.payrolltax.Select(filterCedolini);

                    foreach (DataRow r in rCedRit) {
                        sommaRitPrevidenziali += CfgFn.GetNoNullDecimal(r["employtax"]);
                    }

                    deduzione_annua_per_ritenute = sommaRitPrevidenziali;
                }
            }
            return deduzione_annua_per_ritenute;
        }



        /// <summary>
        /// Calcola l'imponibile assicurativo mensile di un cedolino
        /// a partire dall'imponibile previdenziale di tutto l'anno in corso,
        /// il numero di mesi lavorati nell'anno,
        /// i cud presentati che hanno data inizio minore o uguale alla data di inizio del cedolino
        /// e data fine maggiore o uguale alla data di fine del cedolino,
        /// e i minimali/massimali per il mese di competenza del cedolino
        /// LAVORA SULLE TABELLE: exhibitedcud, taxableminmax
        /// </summary>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="dataInizioCedolino">data di inizio del cedolino</param>
        /// <param name="dataFineCedolino">data di fine del cedolino</param>
        /// <param name="imponibilelordomensile">compenso medio mensile</param>
        /// <returns>imponibile assicurativo mensile per il cedolino</returns>
        public decimal calcola_imponibile_assicurativo(
            object idcontratto,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            decimal imponibilelordomensile,
            bool primoCedolinoAnnoFiscale
        ) {
            decimal imponibile = 0;
            //calcola l'imponibile lordo per tutte le altre collaborazioni in essere nel mese considerato

            // Si definisce un ciclo che va dal primo mese dove può essere applicata l'INAIL sino all'ultimo mese del cedolino
            // Determinare il primo mese di applicazione dell'INAIL è importante in quanto per come è strutturata la logica dei cedolini
            // si rischierebbe di far pagare l'INAIL più volte nello stesso mese.
            // Difatti se ho un cedolino con date 01.01 - 15.01 e uno con date 16.01 - 28.02
            // Sul primo cedolino applico tutta l'INAIL di gennaio e sul secondo la sola INAIL di febbraio
            for (DateTime datariferimentomin =
                    getGiornoPrimoPagamentoInail(idcontratto, dataInizioCedolino, primoCedolinoAnnoFiscale);
                (datariferimentomin <= dataFineCedolino);
                datariferimentomin = new DateTime(datariferimentomin.Year, datariferimentomin.Month, 1).AddMonths(1)) {
                // Si cotruisce un filtro per determinare quale minimale e massimale bisogna considerare in base ad una
                // certa data
                string filtroMinMax = QHS.AppAnd(QHS.CmpEq("ayear", datariferimentomin.Year),
                    QHS.CmpLe("startmonth", datariferimentomin.Month),
                    QHS.CmpEq("taxablecode", "ASSICUR"));

                // Il minimale e massinale è diviso per 12 in quanto nella tabella sono memorizzati quelli annuali
                // mentre a noi serve il mensile
                DataTable tMinMasImp = DataAccess.RUN_SELECT(Conn, "taxableminmax",
                    "minimum=minimum/12, maximal=maximal/12", "ayear desc, startmonth desc",
                    filtroMinMax, "1", null, true);

                int esercizio = datariferimentomin.Year;
                DateTime datariferimentomax = datariferimentomin.AddMonths(1).AddDays(-1);
                string filtro = QHC.AppAnd(QHC.CmpGt("taxable", 0), QHC.NullOrLe("start", datariferimentomax),
                    QHC.NullOrGe("stop", datariferimentomin), QHC.CmpEq("idcon", idcontratto));

                // Si verifica se ci siano altre collaborazioni INAIL associate al contratto, se ci sono
                // si somma l'imponibile medio di ogni collaborazione nella variabile altriImponibili
                DataRow[] altreCollaborazioniInail = DS.otherinail.Select(filtro);
                decimal altriImponibili = 0;
                foreach (DataRow r in altreCollaborazioniInail) {
                    int numeroMesi = r["nmonths"] is DBNull ? 1 : Convert.ToInt32(r["nmonths"]);
                    altriImponibili += CfgFn.GetNoNullDecimal(r["taxable"]) / numeroMesi;
                }

                // Si verifica se ci siano CUD associati al contratto corrente, anche in questo caso si somma
                // ad una variabile l'imponibile medio dei CUD (come imponibile previdenziale diviso numero di mesi del CUD)
                decimal altriImponibiliCud = 0;
                string filtroCud = QHC.AppAnd(QHC.NullOrLe("start", datariferimentomax),
                    QHC.NullOrGe("stop", datariferimentomin), QHC.CmpEq("idcon", idcontratto));
                DataRow[] cudPresentati = DS.exhibitedcud.Select(filtroCud, "idexhibitedcud");
                foreach (DataRow rCud in cudPresentati) {
                    if (rCud["flagignoreprevcud"].ToString().ToUpper() == "S") {
                        if ((rCud["nmonths"] != DBNull.Value) && (CfgFn.GetNoNullInt32(rCud["nmonths"]) != 0)) {
                            altriImponibiliCud = CfgFn.GetNoNullDecimal(rCud["taxablepension"]) /
                                                 (int) isnull(rCud["nmonths"], 1);
                        }
                        else {
                            altriImponibiliCud = 0;
                        }
                    }
                    else {
                        if ((rCud["nmonths"] != DBNull.Value) && (CfgFn.GetNoNullInt32(rCud["nmonths"]) != 0)) {
                            altriImponibiliCud += CfgFn.GetNoNullDecimal(rCud["taxablepension"]) /
                                                  (int) isnull(rCud["nmonths"], 1);
                        }
                    }
                }
                // Si sommano l'imponibile medio del contratto più quello delle altre collaborazioni più quello dei CUD
                decimal importoTotale = altriImponibili + altriImponibiliCud + imponibilelordomensile;

                decimal perc = (importoTotale == 0) ? 0 : imponibilelordomensile / importoTotale;
                decimal minimale = tMinMasImp.Rows.Count > 0
                    ? CfgFn.GetNoNullDecimal(tMinMasImp.Rows[0]["minimum"])
                    : 0;
                decimal massimale = tMinMasImp.Rows.Count > 0
                    ? CfgFn.GetNoNullDecimal(tMinMasImp.Rows[0]["maximal"])
                    : decimal.MaxValue;
                //Se la somma di tutti gli imponibili
                //non è compresa tra minimale e massimale allora va presa la proporzione
                //tra l'imponibile del cedolino e la somma di tutti gli imponibili
                if (importoTotale < minimale) {
                    imponibile += minimale * perc;
                }
                else {
                    if (importoTotale > massimale) {
                        imponibile += massimale * perc;
                    }
                    else {
                        imponibile += imponibilelordomensile;
                    }
                }
            }
            return CfgFn.RoundValuta(imponibile);
        }

        /// <summary>
        /// Metodo che calcola l'imponibile INAIL del contratto per il calcolo del costo totale
        /// </summary>
        /// <param name="idcontratto">ID del contratto</param>
        /// <param name="dataInizioCompetenza">Data di Inizio Competenza del contratto</param>
        /// <param name="dataFineCompetenza">Data di Fine Competenza del contratto</param>
        /// <param name="imponibilelordomensile">Imponibile Lordo Mensile</param>
        /// <returns></returns>
        public static decimal calcolaImponibileINAIL(
            object idcontratto,
            DateTime dataInizioCompetenza,
            DateTime dataFineCompetenza,
            DataTable tMinMasImp,
            DataTable tCud,
            DataTable tAltreCollINAIL,
            decimal imponibileLordoMensile
        ) {
            CQueryHelper QHC = new CQueryHelper();
            decimal imponibile = 0;
            // Il principio di funzionamento è medesimo a quello del metodo calcola_imponibile_assicurativo
            // l'unica differenza è che questo è un metodo statico adoperato nel calcolo del costo totale
            //calcola l'imponibile lordo per tutte le altre collaborazioni in essere nel mese considerato
            for (DateTime datariferimentomin = new DateTime(dataInizioCompetenza.Year, dataInizioCompetenza.Month, 1);
                datariferimentomin <= dataFineCompetenza;
                datariferimentomin = datariferimentomin.AddMonths(1)) {
                int esercizio = datariferimentomin.Year;
                DateTime datariferimentomax = datariferimentomin.AddMonths(1).AddDays(-1);
                string filtro = QHC.AppAnd(QHC.CmpGt("taxable", 0), QHC.NullOrLe("start", datariferimentomax),
                    QHC.NullOrGe("stop", datariferimentomin), QHC.CmpEq("idcon", idcontratto));
                DataRow[] altreCollaborazioniInail = tAltreCollINAIL.Select(filtro);
                decimal altriImponibili = 0;
                foreach (DataRow r in altreCollaborazioniInail) {
                    int numeroMesi = r["nmonths"] is DBNull ? 1 : Convert.ToInt32(r["nmonths"]);
                    if (numeroMesi != 0) {
                        altriImponibili += CfgFn.GetNoNullDecimal(r["taxable"]) / numeroMesi;
                    }
                }

                decimal altriImponibiliCud = 0;
                string filtroCud = QHC.AppAnd(QHC.NullOrLe("start", datariferimentomax),
                    QHC.NullOrGe("stop", datariferimentomin), QHC.CmpEq("idcon", idcontratto));
                DataRow[] cudPresentati = tCud.Select(filtroCud, "idexhibitedcud");
                foreach (DataRow rCud in cudPresentati) {
                    int numeroMesiCud = (rCud["nmonths"] == DBNull.Value) ? 1 : (int) rCud["nmonths"];
                    if (rCud["flagignoreprevcud"].ToString().ToUpper() == "S") {
                        if (numeroMesiCud != 0) {
                            altriImponibiliCud = CfgFn.GetNoNullDecimal(rCud["taxablepension"]) / numeroMesiCud;
                        }
                    }
                    else {
                        if (numeroMesiCud != 0) {
                            altriImponibiliCud += CfgFn.GetNoNullDecimal(rCud["taxablepension"]) / numeroMesiCud;
                        }
                    }
                }

                decimal importoTotale = altriImponibili + altriImponibiliCud + imponibileLordoMensile;

                decimal perc = (importoTotale == 0) ? 0 : imponibileLordoMensile / importoTotale;
                bool flagEsiste = (tMinMasImp.Rows.Count > 0);
                decimal minimale = flagEsiste ? CfgFn.GetNoNullDecimal(tMinMasImp.Rows[0]["minimum"]) : 0;
                decimal massimale =
                    flagEsiste ? CfgFn.GetNoNullDecimal(tMinMasImp.Rows[0]["maximal"]) : decimal.MaxValue;

                if (importoTotale < minimale) {
                    imponibile += CfgFn.RoundValuta(minimale * perc);
                }
                else {
                    if (importoTotale > massimale) {
                        imponibile += CfgFn.RoundValuta(massimale * perc);
                    }
                    else {
                        imponibile += imponibileLordoMensile;
                    }
                }
            }
            return imponibile;
        }

        /// <summary>
        /// Metodo che calcola l'INAIL c/amministrazione
        /// </summary>
        /// <param name="imponibileLordoMensile"></param>
        /// <param name="pat"></param>
        /// <returns></returns>
        public static decimal calcolaInailAmmin(
            decimal imponibileAssicurativo,
            DataRow pat
        ) {
            decimal imponibile = imponibileAssicurativo;
            decimal ritenutaInailAmmin = imponibile * CfgFn.GetNoNullDecimal(pat["adminrate"]);

            decimal frazioneAmmin;

            decimal frazioneImponibile = getRapporto(pat["taxablenumerator"], pat["taxabledenominator"]);

            frazioneAmmin = frazioneImponibile * getRapporto(pat["adminnumerator"], pat["admindenominator"]);

            ritenutaInailAmmin *= frazioneAmmin;

            return CfgFn.RoundValuta(ritenutaInailAmmin);

        }

        /// <summary>
        /// Calcola l'imponibile assistenziale a partire dal compenso lordo del cedolino; 
        /// In realtà input ed output coincidono.
        /// </summary>
        /// <param name="imponibilePrevidenziale">imponibile previdenziale</param>
        /// <returns>imponibile assistenziale (= previdenziale)</returns>
        public decimal calcola_imponibile_assistenziale(
            decimal imponibilePrevidenziale
        ) {
            // L'imponibile assistenziale è sempre uguale al previdenziale (passato in input)
            return imponibilePrevidenziale;
        }

        /// <summary>
        /// Calcola l'imponibile fiscale lordo del cedolino a partire dall'imponibile per le addizionali.
        /// In realtà input ed output coincidono.
        /// </summary>
        /// <param name="imponibilePrevidenziale">imponibile previdenziale</param>
        /// <returns>imponibile fiscale non dedotto</returns>
        public decimal calcola_imponibile_irpef(
            decimal imponibileDiRiferimento
        ) {
            // L'imponibile IRPEF è sempre pari all'imponibile di riferimento passato in input
            return CfgFn.RoundValuta(imponibileDiRiferimento);
        }

        /// <summary>
        /// Calcola l'imponibile per le addizionali irpef per un cedolino a partire dall'imponibile
        /// previdenziale e, se si tratta di un cedolino di conguaglio, tenendo conto dei cud presentati
        /// durante l'anno
        /// </summary>
        /// <param name="imponibilediriferimento">imp. prev. relativo al cedolino</param>
        /// <param name="natura">R=cedolino di rata; C=conguaglio</param>
        /// <param name="annofiscale">anno di competenza del cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <returns>imponibile per le addizionali irpef per il cedolino</returns>
        public decimal calcola_imponibile_addirpef(
            decimal imponibileDiRiferimento,
            string natura,
            int annoFiscale,
            object idContratto
        ) {
            // Siamo in un cedolino rata l'imponibile sarà pari a quello di riferimento
            if (natura == "R") {
                return imponibileDiRiferimento;
            }

            // Nel caso di un cedolino di conguaglio, bisogna sommare all'imponibile de contratto quello dei CUD
            // associati
            string query = QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto));
            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            decimal altriImponibili = 0;
            // Per ogni CUD bisogna applicare tale strategia
            // Se l'utente ha specificato l'imponibile fiscale lordo, prendiamo questo valore,
            // altrimenti verrà considerato l'imponibile previdenziale meno tutti gli oneri deducibili
            foreach (DataRow r in rCud) {
                decimal imponibileCud = 0;
                // Se è definito l'imponibile fiscale lordo, ad esso si sommano le deduzioni per oneri definite nel CUD
                if (r["taxablegross"] != DBNull.Value) {
                    imponibileCud = (decimal) r["taxablegross"];
                    imponibileCud += calcolaDeduzionePerOneriDiCud(r);
                }
                // Atrimenti si considera l'imponibile previdenziale al netto dell'INPS trattenuta
                else {
                    imponibileCud = (decimal) r["taxablepension"];
                    //La logica di exhibitedcuddeduction è cambiata, ossia li troviamo il LORDO e non il netto
                    MessageBox.Show("E' necessario specificare l'imponibile fiscale lordo per tutti i CUD presentati",
                        "Errore");
                    //foreach(DataRow rDed in r.GetChildRows("exhibitedcudexhibitedcuddeduction")) {
                    //    DataRow deduzione = DS.deduction.Select(QHC.CmpEq("iddeduction",rDed["iddeduction"]))[0];
                    //    if ((deduzione["flagdeductibleexpense"].ToString().ToUpper() == "S")
                    //        && (deduzione["taxablecode"].ToString().ToUpper() == "ADDIRPEF")) {
                    //        imponibileCud -= (decimal)rDed["amount"];
                    //    }
                    //}
                    // Vengono tolti anche i contributi trattenuti
                    imponibileCud -= CfgFn.GetNoNullDecimal(r["inpsretained"]);
                }
                if (r["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    altriImponibili = imponibileCud;
                }
                else {
                    altriImponibili += imponibileCud;
                }
            }

            return imponibileDiRiferimento + altriImponibili;
        }

        /// <summary>
        /// Metodo che somma gli imponibili previdenziali dei CUD
        /// </summary>
        /// <param name="annoFiscale"></param>
        /// <param name="idContratto"></param>
        /// <returns></returns>
        private decimal sommaImponibilePrevidenzialeCud(int annoFiscale,
            object idContratto) {
            string query = QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto));
            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            // Per ogni CUD assocaito al contratto si somma il suo imponibile ad una variabile. Se il CUD
            // ha il flag "Ignora Precedenti" a S si riparte da zero come somma.
            decimal altriImponibili = 0;
            foreach (DataRow r in rCud) {
                decimal imponibileCud = CfgFn.GetNoNullDecimal(r["taxablepension"]);

                if (r["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    altriImponibili = imponibileCud;
                }
                else {
                    altriImponibili += imponibileCud;
                }
            }
            return altriImponibili;
        }

        private decimal sommaImponibileFiscaleCud(int annoFiscale,
            object idContratto) {
            string query = QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto));
            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            // Per ogni CUD assocaito al contratto si somma il suo imponibile ad una variabile. Se il CUD
            // ha il flag "Ignora Precedenti" a S si riparte da zero come somma.
            decimal altriImponibili = 0;
            foreach (DataRow r in rCud) {
                decimal imponibileCud = CfgFn.GetNoNullDecimal(r["taxablegross"]);

                if (r["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    altriImponibili = imponibileCud;
                }
                else {
                    altriImponibili += imponibileCud;
                }
            }
            return altriImponibili;
        }

        private int calcolaTotGiorniLavoratiBonus(int annoFiscale, object idContratto, string includiContratto,
            DateTime start, DateTime stop) {
            // dobbiamo tenere conto di contratti e cedolini di anni precedenti non pagati e trasferiti in toto all'esercizio corrente, i quali concorreranno al
            // reddito dell'esercizio fiscale corrente
            DataTable tData = new DataTable();
            tData.Columns.Add("start", typeof(DateTime));
            tData.Columns.Add("stop", typeof(DateTime));

            DataRow r = tData.NewRow();
            r["start"] = start;
            r["stop"] = stop;
            tData.Rows.Add(r);

            calcolaTabellaCud(Conn.GetSys("userdb"), idContratto, annoFiscale, tData, includiContratto, start, stop);





            int ggLavorati = contaGiorniLavorati(tData, annoFiscale);
            return ggLavorati;
        }



        private decimal calcolaCapienzaIrpefInCud(int annoFiscale, object idContratto) {
            string query = QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto));
            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            // Per ogni CUD associato al contratto si considera la differenza tra Imposta Lorda e le sole Detrazioni per Reddito.
            // Se il CUD ha il flag "Ignora Precedenti" a S si riparte da zero come somma.
            decimal impostaLorda = 0;
            decimal detrazioniReddito = 0;
            foreach (DataRow r in rCud) {
                if (r["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    impostaLorda = CfgFn.GetNoNullDecimal(r["irpefgross"]);
                    detrazioniReddito = CfgFn.GetNoNullDecimal(r["earnings_based_abatements"]);
                }
                else {
                    impostaLorda += CfgFn.GetNoNullDecimal(r["irpefgross"]);
                    detrazioniReddito += CfgFn.GetNoNullDecimal(r["earnings_based_abatements"]);
                }
            }
            return impostaLorda - detrazioniReddito;
        }

        private decimal somma_bonus_erogati_cud(int annoFiscale,
            object idContratto) {
            string query = QHC.AppAnd(QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpEq("idcon", idContratto));
            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            // Per ogni CUD associato al contratto si considera la differenza tra Imposta Lorda e le sole Detrazioni per Reddito.
            // Se il CUD ha il flag "Ignora Precedenti" a S si riparte da zero come somma.
            decimal bonusErogati = 0;

            foreach (DataRow r in rCud) {
                if (r["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    bonusErogati = CfgFn.GetNoNullDecimal(r["fiscalbonusapplied"]);
                }
                else {
                    bonusErogati += CfgFn.GetNoNullDecimal(r["fiscalbonusapplied"]);

                }
            }
            return bonusErogati;
        }

        private int contaGiorniLavorati(DataTable tData, int annoFiscale) {
            if ((tData == null) || (tData.Rows.Count == 0)) return 0;
            object o = tData.Compute("MIN(start)", null);
            if (o == null || o == DBNull.Value) return 0;
            DateTime minData = (DateTime) o;
            o = tData.Compute("MAX(stop)", null);
            if (o == null || o == DBNull.Value) return 0;
            DateTime maxData = (DateTime) o;

            int giorniAnnoFiscale = 1 + (maxData - minData).Days;
            // Si definisce un bitarray della dimensione della differenza tra la minima data di inizio e la massima data di fine
            BitArray lav = new BitArray(giorniAnnoFiscale);

            // Per ogni riga di tData si cicla sul periodo e si accende il bit corrispondente
            foreach (DataRow r in tData.Rows) {
                if (r["start"] == DBNull.Value) continue;
                if (r["stop"] == DBNull.Value) continue;
                DateTime dataInizio = (DateTime) r["start"];
                DateTime dataFine = (DateTime) r["stop"];
                for (DateTime d = dataInizio; d <= dataFine; d = d.AddDays(1)) {
                    lav[(d - minData).Days] = true;
                }
            }

            int gglavorati = 0;
            // Per contare i giorni lavorati basterà contare i bit accesi nell'array
            foreach (bool b in lav) {
                if (b) {
                    gglavorati++;
                }
            }
            int giorniAnnoSolare = DateTime.IsLeapYear(annoFiscale) ? 366 : 365;
            // Calcolo del numero di giorni dell'anno (se si superano i giorni dell'anno si pone il numero pari ad esso)
            if (gglavorati > giorniAnnoSolare) {
                gglavorati = giorniAnnoSolare;
            }
            return gglavorati;
        }

        #endregion

        #region deduzioni

        /// <summary>
        /// Metodo che calcola le deduzioni per oneri da CUD
        /// </summary>
        /// <param name="rCud"></param>
        /// <returns></returns>
        private decimal calcolaDeduzionePerOneriDiCud(DataRow rCud) {
            string filter = QHC.MCmp(rCud, new string[] {"idcon", "idexhibitedcud"});
            decimal totDeduzione = 0;
            DataTable tDeduction = DataAccess.CreateTableByName(Conn, "deduction",
                "iddeduction, flagdeductibleexpense, taxablecode");
            DataTable tDeductionCode = DataAccess.CreateTableByName(Conn, "deductioncode",
                "iddeduction, ayear, maximal, exemption, rate");
            // Le deduzioni considerate sono quelle che sono oneri deducibili e che sono associate
            // all'imponibile per addizionali.
            foreach (DataRow rDeduzione in DS.exhibitedcuddeduction.Select(filter)) {
                string fDed = QHC.CmpEq("iddeduction", rDeduzione["iddeduction"]);
                string fDedSQL = QHS.CmpEq("iddeduction", rDeduzione["iddeduction"]);
                if (tDeduction.Select(fDed).Length == 0) {
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, tDeduction, null, fDedSQL, null, true);
                    if (tDeduction.Select(fDed).Length == 0) continue;
                }

                DataRow rDed = tDeduction.Select(fDed)[0];
                if (rDed["taxablecode"].ToString().ToUpper() != "ADDIRPEF") continue;
                if (rDed["flagdeductibleexpense"].ToString().ToUpper() != "S") continue;

                string fDedYear = QHC.AppAnd(fDed, QHC.CmpEq("ayear", Conn.GetSys("esercizio")));
                if (tDeductionCode.Select(fDedYear).Length == 0) {
                    string fDedYearSQL = QHS.AppAnd(fDedSQL, QHS.CmpEq("ayear", Conn.GetSys("esercizio")));
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, tDeductionCode, null, fDedYearSQL, null, true);

                    if (tDeductionCode.Select(fDedYear).Length == 0) continue;
                }
                DataRow rDedYear = tDeductionCode.Select(fDedYear)[0];

                decimal importoOnere = CfgFn.GetNoNullDecimal(rDeduzione["amount"]);

                // L'importo dell'onere deve essere confrontato con il massimale, sottrarre la franchigia ed
                // applicare l'aliquota
                decimal massimale = CfgFn.GetNoNullDecimal(rDedYear["maximal"]);
                decimal franchigia = CfgFn.GetNoNullDecimal(rDedYear["exemption"]);
                decimal aliquota = (rDedYear["rate"] == DBNull.Value) ? 1 : CfgFn.GetNoNullDecimal(rDedYear["rate"]);

                if ((massimale != 0) && (importoOnere > massimale)) {
                    importoOnere = massimale;
                }

                importoOnere -= franchigia;

                totDeduzione = CfgFn.Round(importoOnere * aliquota, 2);
            }
            return totDeduzione;
        }

        /// <summary>
        /// Metodo che calcola le deduzioni per familiare.
        /// QUESTO METODO NON E' PIU' USATO IN QUANTO SI APPLICANO LE DETRAZIONI PER FAMILIARI
        /// E' STATO LASCIATO NEL CASO DOVESSE RITORNARE LA VECCHIA LEGGE
        /// </summary>
        /// <param name="rCedolino"></param>
        /// <param name="deduzioneannua"></param>
        /// <returns></returns>
        private decimal calcolaDeduzioneFamiliari(DataRow rCedolino, out decimal deduzioneannua) {
            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S" ? true : false;
            object idcontratto = rCedolino["idcon"];
            DateTime datainizio = (DateTime) rCedolino["start"];
            DateTime datafine = (DateTime) rCedolino["stop"];
            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idcontratto))[0];
            DateTime datainiziocompetenza = (DateTime) rImputContr["startcompetency"];
            DateTime datafinecompetenza = (DateTime) rImputContr["stopcompetency"];
            decimal redditocomplessivo = (decimal) rImputContr["taxablepension"];
            DataRow[] rOnerDeduc = DS.deductibleexpense.Select(QHC.CmpEq("idcon", idcontratto));
            decimal totonerideducibili = 0;
            foreach (DataRow r in rOnerDeduc) {
                totonerideducibili += (decimal) r["totalamount"];
            }
            return calcola_deduzione_familiariacarico(
                isConguaglio,
                idcontratto,
                datainizio,
                datafine,
                datainiziocompetenza,
                datafinecompetenza,
                redditocomplessivo,
                totonerideducibili,
                out deduzioneannua
            );
        }

        /// <summary>
        /// Calcola la somma delle deduzioni da applicare per l'imponibile dato
        /// </summary>
        /// <param name="rCedolino">riga della tabella cedolino</param>
        /// <param name="codiceimponibile">id. del tipo imponibile</param>
        /// <param name="imponibileriferimento">imponibile sul quale applicare le deduzioni</param>
        /// <param name="ritenuteApplicate">ritenute non fiscali versate sugli imponibili con ordine di valutazione più alto</param>
        /// <returns>somma delle deduzioni per questo imponibile</returns>
        private decimal calcolaDeduzioniPerUnImponibile(
            DataRow rCedolino,
            object codiceimponibile,
            decimal imponibileriferimento,
            decimal ritenuteApplicate
        ) {
            char natura = rCedolino["flagbalance"].ToString() == "S" ? 'C' : 'R';
            object idcontratto = rCedolino["idcon"];
            DataRow rContratto = rCedolino.GetParentRow("parasubcontractpayroll");
            DateTime DataInizio = (DateTime) rCedolino["start"];
            DateTime DataFine = (DateTime) rCedolino["stop"];

            //Calcola la somma delle deduzioni per questo imponibile
            decimal deduzionicorrenti = 0;
            //Le deduzioni sono considerate in base alla data fine del cedolino

            object idcedolino = rCedolino["idpayroll"];
            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S";

            string filterdeduzioni = QHC.AppAnd(QHC.CmpEq("taxablecode", codiceimponibile),
                QHC.NullOrLe("validitystart", DataFine), QHC.NullOrGe("validitystop", DataFine));
            // Si ottiene l'elenco dei tipi di deduzione
            DataRow[] TipoDeduzioni = DS.deduction.Select(filterdeduzioni, "evaluationorder asc");

            // Per ogni tipo di deduzione si valuta se esiste una deduzione per l'anno in corso
            foreach (DataRow Deduzione in TipoDeduzioni) {
                string spdeduzione = Deduzione["evaluatesp"].ToString();
                string tipocalcolo = Deduzione["calculationkind"].ToString();
                object iddeduzione = Deduzione["iddeduction"];
                // Esistenza della deduzione nell'anno in corso
                if (DS.deductioncode.Select(QHC.CmpEq("iddeduction", iddeduzione)).Length == 0) continue;
                // Nel caso esista, si ottengono aliquota, franchigia e massimale da applicare nel calcolo della deduzione
                DataRow rCodiceDeduzione = DS.deductioncode.Select(QHC.CmpEq("iddeduction", iddeduzione))[0];

                decimal aliquota = (decimal) isnull(rCodiceDeduzione["rate"], 1m);
                decimal franchigia = CfgFn.GetNoNullDecimal(rCodiceDeduzione["exemption"]);
                decimal massimale = CfgFn.GetNoNullDecimal(rCodiceDeduzione["maximal"]);

                decimal deduzioneAnnuale;

                decimal deduzione = calcola_deduzione(rCedolino, spdeduzione, iddeduzione, imponibileriferimento,
                    aliquota, franchigia, massimale, tipocalcolo, ritenuteApplicate,
                    out deduzioneAnnuale);

                // Si verifica che il totale delle deduzioni non superi l'imponibile di riferimento
                if (deduzione + deduzionicorrenti > imponibileriferimento) {
                    deduzione = imponibileriferimento - deduzionicorrenti;
                }

                // Se la deduzione è positiva si crea una riga nella tabella delle deduzioni associate al cedolino (PAYROLLDEDUCTION)
                if (deduzione > 0) {
                    MetaData.SetDefault(DS.Tables["payrolldeduction"], "iddeduction", iddeduzione);
                    DataRow NewDeduzione = MetaDettaglioDeduzioneCedolino.Get_New_Row(rCedolino,
                        DS.Tables["payrolldeduction"]);
                    NewDeduzione["taxablecode"] = codiceimponibile;
                    NewDeduzione["annualamount"] = CfgFn.RoundValuta(deduzioneAnnuale);
                    NewDeduzione["curramount"] = CfgFn.RoundValuta(deduzione);
                }
                deduzionicorrenti += deduzione;
                if (deduzionicorrenti >= imponibileriferimento) {
                    return deduzionicorrenti;
                }
            }

            // Sezione riferita al solo conguaglio e se l'imponibile corrente è quello per ADDIZIONALI
            if ((isConguaglio) && (codiceimponibile.ToString() == "ADDIRPEF")) {
                // Si considerano di tutti i cedolini rata la somma delle ritenute previdenziali ed assicurative
                // (INPS e INAIL) che saranno delle deduzioni per l'imponibile ADDIRPEF
                string payrollList = QueryCreator.ColumnValues(DS.payroll,
                    QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("flagbalance", "N")), "idpayroll", false);
                if (payrollList != "") {
                    string filterCedolini = QHC.AppAnd(QHC.FieldIn("idpayroll",
                            DS.payroll.Select(
                                QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("flagbalance", "N")))),
                        QHC.FieldIn("taxcode", DS.tax.Select(QHC.FieldNotIn("taxkind", new object[] {1, 5}))));

                    DataRow[] rCedRit = DS.payrolltax.Select(filterCedolini);
                    decimal sommaRitPrevidenziali = 0;
                    foreach (DataRow r in rCedRit) {
                        sommaRitPrevidenziali += CfgFn.GetNoNullDecimal(r["employtax"]);
                    }
                    deduzionicorrenti += CfgFn.GetNoNullDecimal(sommaRitPrevidenziali);
                }
            }
            return deduzionicorrenti;
        }

        /// <summary>
        /// Calcola l'importo mensile della deduzione specificata da applicare per il cedolino dato
        /// </summary>
        /// <param name="rCedolino">riga della tabella cedolino</param>
        /// <param name="spdeduzione">sp da chiamare il calcolo della deduzione</param>
        /// <param name="iddeduzione">id. del tipo di deduzione</param>
        /// <param name="imponibilelordo">imponibile lordo sul quale applicare la deduzione</param>
        /// <param name="aliquota">tipodeduzione.aliquota</param>
        /// <param name="franchigia">tipodeduzione.franchigia</param>
        /// <param name="massimale">tipodeduzione.massimale</param>
        /// <param name="tipocalcolo">tipodeduzione.tipocalcolo</param>
        /// <param name="ritenuteApplicate">ritenute già versate sugli imponibili già valutati</param>
        /// <param name="deduzioneannua">importo annuale della deduzione</param>
        /// <returns>importo mensile della deduzione</returns>
        public decimal calcola_deduzione(
            DataRow rCedolino,
            string spdeduzione,
            object iddeduzione,
            decimal imponibilelordo,
            decimal aliquota,
            decimal franchigia,
            decimal massimale,
            string tipocalcolo,
            decimal ritenuteApplicate,
            out decimal deduzioneannua
        ) {
            deduzioneannua = 0;
            // Sezione dichiarativa per variabili adoperate successivamente nel corpo del metodo o come passaggio parametri
            object idcedolino = rCedolino["idpayroll"];
            string applicaagevolazionifiscali = (string) rCedolino["enabletaxrelief"];
            string natura = rCedolino["flagbalance"].ToString() == "S" ? "C" : "R";
            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S" ? true : false;
            int annofiscale = (int) rCedolino["fiscalyear"];
            int giornicedolino = (short) rCedolino["workingdays"];
            DateTime datainizio = (DateTime) rCedolino["start"];
            DateTime datafine = (DateTime) rCedolino["stop"];
            object idcontratto = rCedolino["idcon"];

            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idcontratto))[0];
            string tipoapplicazionenotaxbase = rImputContr["notaxappliance"].ToString();
            DateTime datainiziocompetenza = (DateTime) rImputContr["startcompetency"];
            DateTime datafinecompetenza = (DateTime) rImputContr["stopcompetency"];
            decimal redditocomplessivo = (decimal) rImputContr["taxablepension"];

            DataRow rContratto = rCedolino.GetParentRow("parasubcontractpayroll");
            object codiceprestazione = rContratto["idser"];
            int codicecreddeb = (int) rContratto["idreg"];
            DateTime datainiziocontratto = (DateTime) rContratto["start"];
            DateTime datafinecontratto = (DateTime) rContratto["stop"];

            // Fine Sezione dichiarativa

            // Parte commentata attualmente inutile, serviva per le deduzioni ai familiari, non più usate
            // Si ottiene l'elenco degli oneri deducibili di un contratto
            //DataRow[] rOnerDeduc = DS.deductibleexpense.Select(QHC.CmpEq("idcon", idcontratto));
            //decimal totonerideducibili = 0;
            //foreach (DataRow r in rOnerDeduc) {
            //    totonerideducibili += (decimal) r["totalamount"];
            //}

            switch (spdeduzione) {
                // J.T.R. 2007 - Commentato! Non esiste più la no tax area.
                //case "calcola_deduzione_art11_2004": 
                //    // Commentata x velocizzare il processo
                //    //					stampaChiamataDeduzioni(spdeduzione, natura, iddeduzione, idcedolino, idcontratto,
                //    //						codicecreddeb, imponibilelordo, ritenuteApplicate, datainizio, datafine);

                //    return calcola_deduzione_art11_2004(
                //        imponibilelordo,
                //        iddeduzione,
                //        idcontratto,
                //        codiceprestazione,
                //        applicaagevolazionifiscali,
                //        natura,
                //        annofiscale,
                //        giornicedolino,
                //        datainizio,
                //        datafine,
                //        tipoapplicazionenotaxbase,
                //        datainiziocontratto,
                //        datafinecontratto,
                //        tipocalcolo,
                //        datainiziocompetenza,
                //        datafinecompetenza,
                //        out deduzioneannua
                //        );

                case "calcola_deduzione_contributi_versati":
                    return calcola_deduzione_contributi_versati(
                        ritenuteApplicate,
                        natura,
                        giornicedolino,
                        datainizio,
                        datafine,
                        datainiziocompetenza,
                        datafinecompetenza,
                        idcontratto,
                        out deduzioneannua
                    );

                // J.T.R. 2007 - Commentato! Non esistono più le deduzioni per carichi familiari.
                // Sono state sostituite dalle detrazioni.
                //case "calcola_deduzione_familiariacarico":
                //    return calcola_deduzione_familiariacarico(
                //        isConguaglio,
                //        idcontratto,
                //        datainizio, 
                //        datafine,
                //        datainiziocompetenza,
                //        datafinecompetenza,
                //        redditocomplessivo,
                //        totonerideducibili,
                //        out deduzioneannua
                //        );

                case "calcola_deduzione_generica_2004":
                    return calcola_deduzione_generica_2004(
                        iddeduzione,
                        idcedolino,
                        datainizio,
                        datafine,
                        idcontratto,
                        datainiziocompetenza,
                        datafinecompetenza,
                        annofiscale,
                        natura,
                        aliquota,
                        franchigia,
                        massimale,
                        out deduzioneannua
                    );
            }
            MessageBox.Show("Errore interno - non trovata la spdeduzione " + spdeduzione);
            return -1;
        }

        //TODO: nei cedolini rata tenere conto anche delle franchigie e delle aliquote

        /// <summary>
        /// Calcola la deduzione da applicare relativa ad un tipo deduzione / cedolino
        /// </summary>
        /// <param name="iddeduzione">id. del tipo di deduzione</param>
        /// <param name="idcedolino">id. del cedolino</param>
        /// <param name="dataInizioCedolino">Data Inizio del Cedolino</param>
        /// <param name="dataFineCedolino">Data Fine del Cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="dataInizioCompetenza">Data Inizio Competenza del Contratto</param>
        /// <param name="dataFineCompetenza">Data Fine Competenza del Contratto</param>
        /// <param name="annofiscale">anno di competenza del cedolino</param>
        /// <param name="natura">R=rata, C=conguaglio</param>
        /// <param name="aliquota">tipodeduzione.aliquota</param>
        /// <param name="franchigia">tipodeduzione.franchigia</param>
        /// <param name="massimale">tipodeduzione.massimale</param>
        /// <param name="deduzioneannua">importo annuale della deduzione</param>
        /// <returns>importo mensile della deduzione</returns>
        public decimal calcola_deduzione_generica_2004(
            object iddeduzione,
            object idcedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            object idcontratto,
            DateTime dataInizioCompetenza,
            DateTime dataFineCompetenza,
            int annofiscale,
            string natura,
            decimal aliquota,
            decimal franchigia,
            decimal massimale,
            out decimal deduzioneannua
        ) {

            //Se il Cedolino è rata, restituisce la quota parte della deduzione annuale in base ai mesi del cedolino
            DataRow[] rOnerDed = DS.deductibleexpense.Select(QHC.AppAnd(QHC.CmpEq("idcon", idcontratto),
                QHC.CmpEq("iddeduction", iddeduzione)));

            // Se siamo in un cedolino rata e non ci sono oneri deducibili associati al tipo di deduzione di input
            // il metodo ritorna immediatamente zero
            if ((rOnerDed.Length == 0) && (natura == "R")) {
                deduzioneannua = 0;
                return 0;
            }

            // Se siamo in un conguaglio e ci sono oneri verrà preso il valore degli oneri, altrimenti si parte da zero
            if (rOnerDed.Length != 0) {
                deduzioneannua = CfgFn.GetNoNullDecimal(rOnerDed[0]["totalamount"]);
            }
            else {
                deduzioneannua = 0;
            }

            // Sezione che determina la frazione per rapportare la deduzione annuale rispetto alla durata del cedolino

            // Se un cedolino è giornaliero la frazione è espressa in termini di giorni altrimenti in termini mensili
            int gglavorati = 1 + (dataFineCompetenza - dataInizioCompetenza).Days;
            int giornicedolino = 1 + (dataFineCedolino - dataInizioCedolino).Days;
            int numAnno = 1, denAnno = 1;
            bool flagCalcoloARitroso;
            int durataInMesiCedolino =
                CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCedolino, dataFineCedolino, out flagCalcoloARitroso);
            int durataInMesiCompetenza =
                CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCompetenza, dataFineCompetenza,
                    out flagCalcoloARitroso);
            numAnno = giornicedolino;
            denAnno = gglavorati;
            if ((durataInMesiCedolino != 0) && (durataInMesiCompetenza >= durataInMesiCedolino)) {
                int frazione = durataInMesiCompetenza / durataInMesiCedolino;
                if (durataInMesiCedolino * frazione == durataInMesiCompetenza) {
                    numAnno = 1;
                    denAnno = frazione;
                }
            }

            // Se siamo in un cedolino rata l'importo dell'onere viene conforntato con il massimale,
            // gli si sottrae la franchigia e si applica l'aliquota.
            // All'importo annuo si applica la frazione della durata del cedolino rispetto al contratto
            if (natura == "R") {
                if ((massimale != 0) && (deduzioneannua > (decimal) massimale)) {
                    deduzioneannua = (decimal) massimale;
                }
                decimal importo_annuo = (deduzioneannua - franchigia) * aliquota;
                if (importo_annuo < 0) {
                    importo_annuo = 0;
                }
                decimal importo_corrente = importo_annuo * numAnno / denAnno;
                return importo_corrente;
            }


            //Se è un cedolino di conguaglio, restituisce la deduzione annua  sommata anche a quella dei CUD

            string filtroCud =
                QHC.DistinctVal(DS.exhibitedcud.Select(QHC.CmpEq("idcon", idcontratto)), "idexhibitedcud");
            DataRow[] rDeduCud = (filtroCud == "")
                ? new DataRow[0]
                : DS.exhibitedcuddeduction.Select(QHC.AppAnd(QHC.FieldInList("idexhibitedcud", filtroCud),
                        QHC.CmpEq("iddeduction", iddeduzione)),
                    "idexhibitedcud");
            decimal deduzionialtricud = 0;
            // Si sommano tutti gli importi di un fissato onere presente nei CUD associati al contratto
            foreach (DataRow r in rDeduCud) {
                string cud = QHC.MCmp(r, "idexhibitedcud");
                DataRow rCud = DS.exhibitedcud.Select(cud)[0];
                if (rCud["flagignoreprevcud"].ToString() == "S") {
                    deduzionialtricud = (decimal) r["amount"];
                }
                else {
                    deduzionialtricud += (decimal) r["amount"];
                }
            }
            // il precedente risultato si somma alla deduzione presente nel contratto
            decimal totalededuzioneannuale = deduzioneannua + deduzionialtricud;

            // Si confronta il dato col massimale, si sottrae la franchigia e si applica l'aliquota.
            // Giacché siamo in un conguaglio non viene applicata la quota parte come x i cedolini rata (la frazione sarebbe sempre 1/1)
            if ((massimale != 0) && (totalededuzioneannuale > massimale)) {
                totalededuzioneannuale = massimale;
            }

            decimal importo_deduzione = (totalededuzioneannuale - franchigia) * aliquota;

            if (importo_deduzione < 0) {
                importo_deduzione = 0;
            }
            return importo_deduzione;
        }

        /// <summary>
        /// Se è un cedolino di conguaglio allora restituisce i contributi versati;
        /// altrimenti restituisce una proiezione dei contributi versati sul contratto, stile calcolo della deduzione
        /// no tax area. (Rapporta i contributi versati del cedolino con il periodo di competenza del contratto)
        /// </summary>
        /// <param name="ritenuteApplicate">ritenuta INPS/Inail versata per il cedolino</param>
        /// <param name="natura">R=rata, C=conguaglio</param>
        /// <param name="giornicedolino">Giorni del Cedolino</param>
        /// <param name="dataInizioCedolino">Data Inizio Cedolino</param>
        /// <param name="dataFineCedolino">Data Fine Cedolino</param>
        /// <param name="inizioCompetenza">Inizio Competenza Contratto</param>
        /// <param name="fineCompetenza">Fine Competenza Contratto</param>
        /// <param name="idcontratto">ID del Contratto</param>
        /// <param name="deduzioneAnnua">importo annuale della deduzione</param>
        /// <returns>Stima della deduzione applicabile sul contratto</returns>
        public decimal calcola_deduzione_contributi_versati(
            decimal ritenuteApplicate,
            string natura,
            int giornicedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            DateTime inizioCompetenza,
            DateTime fineCompetenza,
            object idcontratto,
            out decimal deduzioneAnnua
        ) {

            // Se siamo in un cedolino di conguaglio si ritorna subito come risultato l'importo dei contributi versati
            //pssato in input
            deduzioneAnnua = ritenuteApplicate;
            if (natura == "C") {
                return CfgFn.Round(ritenuteApplicate, 6);
            }

            // Se siamo in un cedolino rata la deduzione annua viene calcolata come deduzione del cedolino stimata
            // sul periodo di competenza del contratto
            int gglavorati = 1 + (fineCompetenza - inizioCompetenza).Days;
            int numAnno = 1, denAnno = 1;
            bool flagCalcoloARitroso;
            int durataInMesiCedolino =
                CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCedolino, dataFineCedolino, out flagCalcoloARitroso);
            int durataInMesiCompetenza =
                CalcoliPerLaGenerazione.differenzaInMesi(inizioCompetenza, fineCompetenza, out flagCalcoloARitroso);
            numAnno = giornicedolino;
            denAnno = gglavorati;
            if ((durataInMesiCedolino != 0) && (durataInMesiCompetenza >= durataInMesiCedolino)) {
                int frazione = durataInMesiCompetenza / durataInMesiCedolino;
                if (durataInMesiCedolino * frazione == durataInMesiCompetenza) {
                    numAnno = 1;
                    denAnno = frazione;
                }
            }

            deduzioneAnnua = ritenuteApplicate / numAnno * denAnno;
            return CfgFn.Round(ritenuteApplicate, 6);
        }

        //TODO: Eliminare il parametro applicaagevolazionifiscali
        //TODO: Eliminare o gglavorati o totalegiorni (tanto restituiscono la stessa cosa)

        /// <summary>
        /// Calcola la deduzione no-tax area
        /// METODO NON USATO. LA DEDUZIONE NO-TAX AREA NON ESISTE PIU'
        /// IL METODO E' STATO LASCIATO NEL CASO RITORNI TALE LEGGE
        /// </summary>
        /// <param name="imponibilelordo">imponibile previdenziale del cedolino</param>
        /// <param name="iddeduzione">id. del tipo di deduzione</param>
        /// <param name="idcontratto">id. del contratto del cedolino</param>
        /// <param name="codiceprestazione">id. del tipo di prestazione</param>
        /// <param name="applicaagevolazionifiscali">indica se si devono applicare tutte le
        /// agevolazioni fiscali); viene calcolato prima di calcolare il cedolino e posto a N 
        /// se per quell'anno fiscale sono state applicate almeno 12 volte le agevolazioni)</param>
        /// <param name="natura">R=rata, C=conguaglio</param>
        /// <param name="annofiscale">anno di competenza del cedolino</param>
        /// <param name="giornicedolino">numero di giorni di competenza del cedolino</param>
        /// <param name="datainizio">primo giorno di competenza del cedolino</param>
        /// <param name="datafine">ultimo giorno di competenza del cedolino</param>
        /// <param name="tipoapplicazionenotaxbase">imputazionecontratto.tiponotax
        /// I= deduzione base per intero; G=deduzione base giorni fiscali; N=non applicare</param>
        /// <param name="datainiziocompetenza">primo giorno di competenza del cedolino</param>
        /// <param name="datafinecompetenza">ultimo giorno di competenza del cedolino</param>
        /// <param name="datainiziocontratto">primo giorno del contratto</param>
        /// <param name="datafinecontratto">ultimo giorno del contratto</param>
        /// Specifica se il primo mese di un contratto che comincia il 1/1/5 in realtà deve cominciare
        /// esattamente un mese prima del primo giorno del secondo cedolino
        /// </param>
        /// <param name="tipocalcolo">Se 'M' allora la proporzione tra anno e duratacedolino 
        /// varrà numeroMesiDiQuestAnno; altrimento se 'G' varrà gglavorati / giornicedolino</param>
        /// <param name="deduzioneannua">importo annuale della deduzione</param>
        /// <returns>importo mensile della deduzione</returns>
        public decimal calcola_deduzione_art11_2004(
            decimal imponibilelordo,
            int iddeduzione,
            string idcontratto,
            object codiceprestazione,
            string applicaagevolazionifiscali,
            string natura,
            int annofiscale,
            int giornicedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            string tipoapplicazionenotaxbase,
            DateTime datainiziocontratto,
            DateTime datafinecontratto,
            string tipocalcolo,
            DateTime inizioCompetenza,
            DateTime fineCompetenza,
            out decimal deduzioneannua
        ) {

            //Il applicaagevolazionifiscali vale S se si devono applicare tutte le agevolazioni fiscali); 
            //viene calcolato prima di calcolare il cedolino e posto a N se per quell'anno fiscale 
            //sono state applicate almeno 12 volte le agevolazioni)
            if ((natura == "R") && (applicaagevolazionifiscali == "N")) {
                deduzioneannua = 0;
                return 0;
            }
            if (tipoapplicazionenotaxbase == "N") {
                deduzioneannua = 0;
                return 0;
            }

            // calcolo la deduzione potenziale in base al numero di gg già lavorati nell'anno
            // questo numero è calcolato sulla base sia degli altri cud che del periodo di rif. del cedolino corrente, pregressi e successivi!!!!!
            // incomincio (per questioni anche di ottimizzazione)  a calcolare i gg lav. per questo contratto

            int gglavorati = calcolaGiorniLavorati(idcontratto, dataInizioCedolino, dataFineCedolino, natura);

            //			DataRow[] rCedol = DS.payroll.Select("flagbalance='N' and idcon='"+idcontratto+"'", "start");
            // NON CONSIDERIAMO PIU' I GIORNI LAVORATI IN ALTRI CONTRATTI PERCHE' E' UNA INFORMAZIONE CLE L'UTENTE
            // NON RIESCE A CAPIRE IMMEDIATAMENTE. AL MOMENTO CHE IL COLLABORATORE FORNISCE I CUD ALLORA POTRANNO ESSERE CONSIDERATI
            // GLI ALTRI GIORNI LAVORATI

            //			DataRow[] rCud = DS.exhibitedcud.Select("idcon='"+idcontratto+"'");
            //			int numeroaltricud = rCud.Length;
            //calcolo n. di giorni lavorati complessivamente dall'inizio dell'anno sino alla datafine del periodo di riferimento

            DateTime primoGennaio = new DateTime(annofiscale, 1, 1);
            int giorniAnnoSolare = DateTime.IsLeapYear(annofiscale) ? 366 : 365;
            // L'imponibile che passiamo a questo metodo è già comprensivo degli imponibili derivanti da atri CUD
            //			decimal imponibileFiscaleLordoAltriCud = decimal.Zero;
            //
            //			if ((natura=="C") && (numeroaltricud>0)) {
            //				string onDed = QueryCreator.ColumnValues(DS.deduction, "flagdeductibleexpense='S'", "iddeduction", false);
            //				foreach (DataRow r in rCud) {
            //					decimal imponibilePrevidenziale = CfgFn.GetNoNullDecimal(r["taxablepension"]);
            //					decimal inpsTrattenuti = CfgFn.GetNoNullDecimal(r["inpsretained"]);
            //					decimal ifl = imponibilePrevidenziale - inpsTrattenuti;
            //					if (onDed != "") {
            //						string filtroOnDed = QueryCreator.WHERE_KEY_CLAUSE(r, DataRowVersion.Current, false)
            //							+ " and (iddeduction in (" + onDed + "))";
            //						DataRow[] rOnDed = DS.exhibitedcuddeduction.Select(filtroOnDed);
            //						foreach (DataRow rDed in rOnDed) {
            //							ifl -= CfgFn.GetNoNullDecimal(rDed["amount"]);
            //						}
            //					}
            //					decimal imponibileFiscaleLordo = (decimal) isnull(r["taxablegross"], ifl);
            //					imponibileFiscaleLordoAltriCud += imponibileFiscaleLordo;
            //				}
            //			}

            decimal DEDUZIONE_BASE_ANNUA = 3000;
            decimal DEDUZIONE_LAVORO_DIPENDENTE_ANNUA = 4500m;

            decimal deduzioneBase = (tipoapplicazionenotaxbase == "G")
                ? DEDUZIONE_BASE_ANNUA * gglavorati / giorniAnnoSolare
                : DEDUZIONE_BASE_ANNUA;

            decimal deduzionePotenziale = deduzioneBase
                                          + DEDUZIONE_LAVORO_DIPENDENTE_ANNUA * gglavorati / giorniAnnoSolare;

            int numAnno = 1, denAnno = 1;
            if (natura == "R") {
                bool flagCalcoloARitroso;
                int durataInMesiCedolino =
                    CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCedolino, dataFineCedolino,
                        out flagCalcoloARitroso);
                int durataInMesiCompetenza =
                    CalcoliPerLaGenerazione.differenzaInMesi(inizioCompetenza, fineCompetenza, out flagCalcoloARitroso);
                numAnno = giornicedolino;
                denAnno = gglavorati;
                if ((durataInMesiCedolino != 0) && (durataInMesiCompetenza >= durataInMesiCedolino)) {
                    int frazione = durataInMesiCompetenza / durataInMesiCedolino;
                    if (durataInMesiCedolino * frazione == durataInMesiCompetenza) {
                        numAnno = 1;
                        denAnno = frazione;
                    }
                }
            }

            decimal imponibilelordoannuo = imponibilelordo / numAnno * denAnno; // + imponibileFiscaleLordoAltriCud;

            decimal D = calcoloRapportoNoTax(maxAnnualTaxable, deduzionePotenziale, 0, imponibilelordoannuo);

            //Calcolo deduzione applicata
            deduzioneannua = D * deduzionePotenziale;

            decimal importo_deduzione = deduzioneannua * numAnno / denAnno;

            return CfgFn.RoundValuta(importo_deduzione);
        }

        /// <summary>
        /// Calcola la deduzione per i familiari a carico (somma delle deduzioni
        /// per il coniuge, i figli e altri familiari)
        /// METODO NON PIU' USATO. NON ESISTE PIU' LA DEDUZIONE PER FAMILIARI A CARICO
        /// METODO LASCIATO NEL CASO RITORNI LA LEGGE
        /// </summary>
        /// <param name="redditocomplessivo">imputazionecontratto.imponibileprevidenziale</param>
        /// <param name="totonerideducibili">sum(onerededucibile.importototale)</param>
        /// <param name="familiare">familiari inseriti nel contratto</param>
        /// <returns>deduzione</returns>
        public decimal calcola_deduzione_familiariacarico(
            bool isConguaglio,
            object idcontratto,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            DateTime inizioCompetenzaAnno,
            DateTime fineCompetenzaAnno,
            decimal redditocomplessivo,
            decimal totonerideducibili,
            out decimal deduzioneannua
        ) {
            //calcola le deduzioni per figli a carico: 
            decimal deduzioneperfigliannuale =
                calcola_deduzione_art12_2005_figli(idcontratto, inizioCompetenzaAnno, fineCompetenzaAnno);

            //calcola le deduzioni per coniuge 
            decimal deduzioneperconiugeannuale =
                calcola_deduzione_art12_2005_coniuge(idcontratto, inizioCompetenzaAnno, fineCompetenzaAnno);

            //calcola le deduzioni per altri familiari 
            decimal deduzioniperaltrifamiliariannuale =
                calcola_deduzione_art12_2005_altri(idcontratto, inizioCompetenzaAnno, fineCompetenzaAnno);

            deduzioneannua = deduzioneperfigliannuale + deduzioneperconiugeannuale + deduzioniperaltrifamiliariannuale;

            bool flagCalcoloARitroso;
            int giorniCedolino = 1 + (dataFineCedolino - dataInizioCedolino).Days;
            int giorniCompetenza = 1 + (fineCompetenzaAnno - inizioCompetenzaAnno).Days;
            int diffMesi =
                CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCedolino, dataFineCedolino, out flagCalcoloARitroso);
            decimal proporzione = diffMesi == 0
                ? decimal.Divide(giorniCedolino, giorniCompetenza)
                : decimal.Divide(diffMesi, 12);

            decimal deduzioneCedolino = deduzioneannua * proporzione;

            decimal rapporto = calcoloRapportoNoTax(78000, deduzioneannua, totonerideducibili, redditocomplessivo);

            deduzioneCedolino *= rapporto;
            deduzioneannua *= rapporto;

            return deduzioneCedolino;
        }

        /// <summary>
        /// Metodo che calcola il rapporto per la no-tax area
        /// METODO NON USATO.
        /// </summary>
        /// <param name="redditoMax"></param>
        /// <param name="deduzionePotenziale"></param>
        /// <param name="oneriDeducibili"></param>
        /// <param name="redditoComplessivo"></param>
        /// <returns></returns>
        private decimal calcoloRapportoNoTax(decimal redditoMax, decimal deduzionePotenziale, decimal oneriDeducibili,
            decimal redditoComplessivo) {
            decimal d = (redditoMax + deduzionePotenziale + oneriDeducibili - redditoComplessivo)
                        / redditoMax * 10000m;

            int i = (int) d;

            if (i <= 0) {
                return 0;
            }
            if (i < 10000) {
                return i / 10000m; //tronco alla 4a cifra decimale (comma 349 punto 4-ter)
            }
            return 1;
        }


        /// <summary>
        /// Calcola la deduzione art. 12 per i figli
        /// METODO NON USATO.
        /// </summary>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="primoGiornoPrimoCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="ultimoGiornoUltimoCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns></returns>
        public decimal calcola_deduzione_art12_2005_figli(
            object idcontratto,
            DateTime primoGiornoPrimoCedolino,
            DateTime ultimoGiornoUltimoCedolino
        ) {
            // Vengono inseriti gli importi delle deduzioni mensili

            decimal DEDUZIONE_FIGLIO_GENERICO = 2900m;
            decimal DEDUZIONE_PRIMO_FIGLIO_SENZA_CONIUGE = 3200m;
            decimal DEDUZIONE_FIGLIO_MINORE_DI_3_ANNI = 3450m;
            decimal DEDUZIONE_FIGLIO_CON_HANDICAP = 3700m;

            string filtroFigli = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto),
                QHC.CmpEq("idaffinity", "F"), QHC.CmpEq("flagdependent", "S"));
            // Vengono selezionati tutti i figli inseriti nel contratto
            DataRow[] tempFamFigli = DS.parasubcontractfamily.Select(filtroFigli, "birthdate");

            int mesiCompetenza = 1 + 12 * (ultimoGiornoUltimoCedolino.Year - primoGiornoPrimoCedolino.Year)
                                 + ultimoGiornoUltimoCedolino.Month - primoGiornoPrimoCedolino.Month;

            if (mesiCompetenza < 12) {
                mesiCompetenza = 12;
            }

            decimal deduzione = 0;

            // Ciclo che per ogni figlio determina l'ammontare mensile della deduzione
            for (int numeroFiglio = 0; numeroFiglio < tempFamFigli.Length; numeroFiglio++) {
                decimal deduzionePerQuestoFiglio = 0;
                DataRow figlioRow = tempFamFigli[numeroFiglio];
                bool isPrimoFiglio = (numeroFiglio == 0);

                DateTime inizioApplicazioneFiglio =
                    (DateTime) isnull(figlioRow["startapplication"], figlioRow["birthdate"]);
                DateTime fineApplicazioneFiglio = (DateTime) isnull(figlioRow["stopapplication"], DateTime.MaxValue);

                DateTime dataInizioDeduzione = getGiornoPrimoPagamentoFamiliare(primoGiornoPrimoCedolino,
                    ultimoGiornoUltimoCedolino, inizioApplicazioneFiglio, fineApplicazioneFiglio);

                DateTime ultimoGiornoApplicazione = (fineApplicazioneFiglio <= ultimoGiornoUltimoCedolino)
                    ? fineApplicazioneFiglio
                    : ultimoGiornoUltimoCedolino;
                for (DateTime d = primoGiornoPrimoCedolino;
                    d <= ultimoGiornoApplicazione; //ultimoGiornoUltimoCedolino; 
                    d = new DateTime(d.Year, d.Month, 1).AddMonths(1)) {
                    if (dataInizioDeduzione > d) {
                        continue;
                    }
                    decimal deduzioneCorrente = DEDUZIONE_FIGLIO_GENERICO;

                    if (isPrimoFiglio) {
                        string filtroConiuge =
                            QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("idaffinity", "C"));
                        DataRow[] tempFamConiuge = DS.parasubcontractfamily.Select(filtroConiuge);
                        // Se non esiste un coniuge viene considerata, qualora sia più vantaggiosa la deduzione di primo figlio senza coniuge
                        if ((tempFamConiuge.Length == 0) &&
                            (DEDUZIONE_PRIMO_FIGLIO_SENZA_CONIUGE > deduzioneCorrente)) {
                            deduzioneCorrente = DEDUZIONE_PRIMO_FIGLIO_SENZA_CONIUGE;
                        }
                        else {
                            bool senzaConiuge = true;
                            foreach (DataRow rConiuge in tempFamConiuge) {
                                DateTime inizioApplicazioneConiuge =
                                    (DateTime) isnull(rConiuge["startapplication"], DateTime.MinValue);
                                DateTime fineApplicazioneConiuge =
                                    (DateTime) isnull(rConiuge["stopapplication"], DateTime.MaxValue);

                                rConiuge["startapplication"] = getGiornoPrimoPagamentoFamiliare(
                                    primoGiornoPrimoCedolino,
                                    ultimoGiornoUltimoCedolino, inizioApplicazioneConiuge, fineApplicazioneConiuge);

                                senzaConiuge = senzaConiuge && ((DateTime) rConiuge["startapplication"] > d);
                            }
                            if (senzaConiuge && (DEDUZIONE_PRIMO_FIGLIO_SENZA_CONIUGE > deduzioneCorrente)) {
                                deduzioneCorrente = DEDUZIONE_PRIMO_FIGLIO_SENZA_CONIUGE;
                            }
                        }
                    }
                    DateTime dataNascita = (DateTime) figlioRow["birthdate"];
                    int etaInMesi = 12 * (d.Year - dataNascita.Year) + d.Month - dataNascita.Month;
                    if ((etaInMesi < 36) && (DEDUZIONE_FIGLIO_MINORE_DI_3_ANNI > deduzioneCorrente)) {
                        deduzioneCorrente = DEDUZIONE_FIGLIO_MINORE_DI_3_ANNI;
                    }
                    if (figlioRow["starthandicap"] is DateTime) {
                        DateTime datainiziohandicap = (DateTime) figlioRow["starthandicap"];
                        if ((datainiziohandicap <= d) && (DEDUZIONE_FIGLIO_CON_HANDICAP > deduzioneCorrente)) {
                            deduzioneCorrente = DEDUZIONE_FIGLIO_CON_HANDICAP;
                        }
                    }

                    deduzioneCorrente *= (decimal) isnull(figlioRow["appliancepercentage"], 1m);

                    deduzionePerQuestoFiglio += deduzioneCorrente;
                }
                deduzionePerQuestoFiglio /= mesiCompetenza;
                deduzione += deduzionePerQuestoFiglio;
            }
            return deduzione;
        }

        /// <summary>
        /// Calcola la deduzione spettante per una categoria di familiari a carico
        /// METODO NON USATO.
        /// </summary>
        /// <param name="flagConiuge">true per calcolare la deduzione per il coniuge a carico;
        /// false per calcolare la deduzione spettante per tutti i familiari a carico
        /// ad esclusione del coniuge e dei figli
        /// </param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="primoGiornoPrimoCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="ultimoGiornoUltimoCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns>importo della deduzione spettante</returns>
        private decimal calcolaDeduzioneFamiliareNonFiglio(
            bool flagConiuge,
            object idcontratto,
            DateTime primoGiornoPrimoCedolino,
            DateTime ultimoGiornoUltimoCedolino
        ) {
            decimal deduzioneSpettante = 0;
            string filtroTipoFamiliare = "";

            if (flagConiuge) {
                deduzioneSpettante = 3200m;
                filtroTipoFamiliare = QHC.CmpEq("idaffinity", "C");

            }
            else {
                filtroTipoFamiliare = QHC.AppAnd(QHC.CmpNe("idaffinity", "C"), QHC.CmpNe("idaffinity", "F"));
            }

            string filtroFamiliare = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), filtroTipoFamiliare,
                QHC.CmpEq("flagdependent", "S"));

            DataRow[] tempFamiliare = DS.parasubcontractfamily.Select(filtroFamiliare, "birthdate");

            int mesiCompetenza = 1 + 12 * (ultimoGiornoUltimoCedolino.Year - primoGiornoPrimoCedolino.Year)
                                 + ultimoGiornoUltimoCedolino.Month - primoGiornoPrimoCedolino.Month;

            if (mesiCompetenza < 12) {
                mesiCompetenza = 12;
            }

            decimal deduzione = 0;
            foreach (DataRow familiareRow in tempFamiliare) {
                if (!flagConiuge) {
                    string codiceParentela = familiareRow["idaffinity"].ToString().ToUpper();
                    deduzioneSpettante = codiceParentela == "A" ? 2900m : 1820m;
                }
                decimal deduzionePerQuestoFamiliare = 0;
                DateTime inizioApplicazione = (DateTime) isnull(familiareRow["startapplication"], DateTime.MinValue);
                DateTime fineApplicazione = (DateTime) isnull(familiareRow["stopapplication"], DateTime.MaxValue);

                DateTime dataInizioDeduzione = getGiornoPrimoPagamentoFamiliare(primoGiornoPrimoCedolino,
                    ultimoGiornoUltimoCedolino, inizioApplicazione, fineApplicazione);
                DateTime ultimoGiornoApplicazione = (fineApplicazione <= ultimoGiornoUltimoCedolino)
                    ? fineApplicazione
                    : ultimoGiornoUltimoCedolino;
                for (DateTime d = primoGiornoPrimoCedolino;
                    d <= ultimoGiornoApplicazione; //ultimoGiornoUltimoCedolino;
                    d = new DateTime(d.Year, d.Month, 1).AddMonths(1)) {
                    if (dataInizioDeduzione > d) {
                        continue;
                    }
                    decimal deduzioneCorrente = deduzioneSpettante;

                    deduzioneCorrente *= (decimal) isnull(familiareRow["appliancepercentage"], 1m);

                    deduzionePerQuestoFamiliare += deduzioneCorrente;
                }
                deduzionePerQuestoFamiliare /= mesiCompetenza;
                deduzione += deduzionePerQuestoFamiliare;
            }
            return deduzione;
        }

        /// <summary>
        /// Calcola la deduzione art. 12 per il coniuge
        /// METODO NON USATO.
        /// </summary>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="primoGiornoPrimoCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="ultimoGiornoUltimoCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns>importo della deduzione per il coniuge</returns>
        public decimal calcola_deduzione_art12_2005_coniuge(
            object idcontratto,
            DateTime primoGiornoPrimoCedolino,
            DateTime ultimoGiornoUltimoCedolino
        ) {
            return calcolaDeduzioneFamiliareNonFiglio(true,
                idcontratto, primoGiornoPrimoCedolino, ultimoGiornoUltimoCedolino);
        }

        /// <summary>
        /// Calcola la deduzione art.12 per altri familiari a carico
        /// METODO NON USATO.
        /// </summary>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="primoGiornoPrimoCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="ultimoGiornoUltimoCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns>importo della deduzione spettante</returns>
        public decimal calcola_deduzione_art12_2005_altri(
            object idcontratto,
            DateTime primoGiornoPrimoCedolino,
            DateTime ultimoGiornoUltimoCedolino
        ) {
            return calcolaDeduzioneFamiliareNonFiglio(false,
                idcontratto, primoGiornoPrimoCedolino, ultimoGiornoUltimoCedolino);
        }

        #endregion

        #region ritenute

        //TODO: Eliminare principioapplicazione, datacontabile, dataprestazione; le addizionali si applicano sempre al 31/12/annofiscale
        //TODO: Eliminare idcedolino; mi serviva per calcolare l'imponibile pregresso, ma questo ce l'ho già come input

        /// <summary>
        /// Calcola una qualsiasi ritenuta chiamando il metodo di calcolo opportuno.
        /// </summary>
        /// <param name="rCedolino">riga della tabella cedolino</param>
        /// <param name="rRitenuta">riga della tabella tiporitenuta</param>
        /// <param name="imponibilenetto">imponibile sul quale applicare la ritenuta</param>
        /// <returns>importo della ritenuta</returns>
        private DataRow calcola_una_ritenuta(DataRow rCedolino, DataRow rRitenuta,
            decimal imponibilenetto) {
            // Sezione dichiarativa
            object idCedolino = rCedolino["idpayroll"];
            object progrCedolino = rCedolino["npayroll"];

            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S";
            string natura = rCedolino["flagbalance"].ToString() == "S" ? "C" : "R";
            int annoFiscale = Convert.ToInt32(rCedolino["fiscalyear"]);
            object idContratto = rCedolino["idcon"];
            DateTime dataInizioCedolino = (DateTime) rCedolino["start"];
            DateTime dataFineCedolino = (DateTime) rCedolino["stop"];
            decimal compensoLordoCedolino = CfgFn.GetNoNullDecimal(rCedolino["feegross"]);
            string filtroContratto = QHC.CmpEq("idcon", rCedolino["idcon"]);
            DataRow rContratto = DS.parasubcontract.Select(filtroContratto)[0];
            bool flagCalcoloARitroso;
            int diffMesi =
                CalcoliPerLaGenerazione.differenzaInMesi(dataInizioCedolino, dataFineCedolino, out flagCalcoloARitroso);
            decimal numeratoreAnno = diffMesi;
            decimal denominatoreAnno = 12;
            if (diffMesi == 0) {
                numeratoreAnno = 1 + (dataFineCedolino - dataInizioCedolino).Days;
                denominatoreAnno = DateTime.IsLeapYear(dataFineCedolino.Year) ? 366 : 365;
            }

            int idPat = CfgFn.GetNoNullInt32(rContratto["idpat"]);

            string filtroImpContr = QHC.AppAnd(filtroContratto, QHC.CmpEq("ayear", annoFiscale));
            DataRow rImputazioneContratto = DS.parasubcontractyear.Select(filtroImpContr)[0];
            decimal maggioreRitenuta = CfgFn.GetNoNullDecimal(rImputazioneContratto["highertax"]);
            object idComune = rImputazioneContratto["idresidence"];
            int numeroRate = CfgFn.GetNoNullInt32(rImputazioneContratto["ratequantity"]);
            int meseInizioRate = CfgFn.GetNoNullInt32(rImputazioneContratto["startmonth"]);
            decimal addizionaleRegionale = CfgFn.GetNoNullDecimal(rImputazioneContratto["regionaltax"]);
            decimal addizionaleComunale = CfgFn.GetNoNullDecimal(rImputazioneContratto["citytax"]);
            decimal accontoAddizionaleComunale = CfgFn.GetNoNullDecimal(rImputazioneContratto["citytax_account"]);
            int numeroRateAcconto = CfgFn.GetNoNullInt32(rImputazioneContratto["ratequantity_account"]);
            int meseInizioRateAcconto = CfgFn.GetNoNullInt32(rImputazioneContratto["startmonth_account"]);

            object codiceRitenuta = rRitenuta["taxcode"];
            string taxref = rRitenuta["taxref"].ToString();
            int tipoRitenuta = CfgFn.GetNoNullInt32(rRitenuta["taxkind"]);
            string tipoApplicazioneGeo = rRitenuta["geoappliance"].ToString();

            // Commentata x velocizzare il processo
            //			stampaChiamataRitenute(rRitenuta, rCedolino, rContratto, codiceRitenuta, maggioreRitenuta, 
            //				annoFiscale, idCedolino, tipoRitenuta, dataInizioCedolino, idPat, idContratto, imponibilenetto);
            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            DateTime dataSaldoAddCom = new DateTime(CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")), 2, 16);

            // l'indirizzo per il calcolo dell'addizionale comunale deve essere il domicilio fiscale (o in mancanza di esso l'indirizzo di residenza)
            // del percipiente al 1 gennaio dell'anno fiscale del cedolino
            DateTime primoDellAnno = new DateTime(annoFiscale, 01, 01);
            DateTime ultimoGiorno = (DateTime) rCedolino["stop"];

            // verifico esistenza di un domicilio fiscale al 1 gennaio
            int idreg = CfgFn.GetNoNullInt32(rContratto["idreg"]);

            object idComuneAddComunale = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
            object idComuneAddRegionale = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);

            if ((idComuneAddComunale == DBNull.Value) || (idComuneAddComunale == null)) {
                idComuneAddComunale = idComune;
                idComuneAddRegionale = idComune;
            }

            DateTime primoDellAnnoPrecedente = new DateTime(annoFiscale - 1, 01, 01);
            object idComuneAddComunaleRata = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnnoPrecedente);
            if ((idComuneAddComunaleRata == DBNull.Value) || (idComuneAddComunaleRata == null)) {
                idComuneAddComunaleRata = idComune;
            }

            object idFiscalTaxRegion = calcolaRegioneFiscale(Conn, idComuneAddRegionale);
            // Fine sezione dichiarativa

            // Se siamo in conguaglio vengono calcolate le sole ritenute fiscali (sia quelle nazionali, sia quelle locali)
            if (isConguaglio) {
                switch (tipoApplicazioneGeo) {
                    // Applicazione Comunale
                    case "C": {
                        // Acconto
                        if (taxref == "07_ACC_ADDCOM") {
                            return conguaglioAccontoAddCom(idCedolino, codiceRitenuta, idComuneAddComunale);
                        }
                        // Addizionale Comunale
                        return sp_calc_ritenutacomunale(idCedolino, codiceRitenuta, isConguaglio, imponibilenetto,
                            idComuneAddComunale, dataSaldoAddCom, addizionaleComunale);
                    }
                    case "R": {
                        // Addizionale Regionale
                        stornaEntiSeDifferenti(idFiscalTaxRegion, idContratto, codiceRitenuta, idCedolino, "R");
                        return sp_calc_ritenutaregionale(idCedolino, codiceRitenuta, isConguaglio,
                            imponibilenetto, idComuneAddRegionale, dataContabile, addizionaleRegionale,
                            idFiscalTaxRegion);
                    }
                    default: {
                        //if (maggioreRitenuta != 0) {
                        //    return creaRitenutaConAliquotaPrefissata(idCedolino, imponibilenetto, 
                        //                maggioreRitenuta, codiceRitenuta);
                        //}
                        // IRPEF
                        // Bonus Fiscale
                        if (taxref == "14_BONUS_FISCALE") {
                            return calcola_bonus_fiscale_2014(idCedolino, natura, dataInizioCedolino, dataFineCedolino,
                                idContratto, annoFiscale, imponibilenetto, codiceRitenuta);
                        }
                        else {
                            return conguaglioFiscale(idCedolino, progrCedolino, idContratto,
                                annoFiscale, codiceRitenuta, imponibilenetto, maggioreRitenuta);
                        }
                    }
                }
            }

            // Calcolo del comune e della regioen fiscale da associare all'addizionale regionale
            object idComuneAddRegionaleRata = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnnoPrecedente);
            object idFiscalTaxRegionRata = null;
            if ((idComuneAddRegionaleRata != null) && (idComuneAddRegionaleRata != DBNull.Value)) {
                idFiscalTaxRegionRata = calcolaRegioneFiscale(Conn, idComuneAddRegionaleRata);
            }

            // Siamo nel calcolo di un cedolino rata
            switch (tipoRitenuta) {
                case 1: // Fiscale
                    switch (tipoApplicazioneGeo) {
                        //Comunale
                        case "C": {
                            // Acconto all'Addizionale comunale
                            if (taxref == "07_ACC_ADDCOM") {
                                return calcolaRataAccontoAddizionaleComunale(
                                    idCedolino, codiceRitenuta,
                                    dataInizioCedolino, dataFineCedolino, idContratto,
                                    annoFiscale, meseInizioRateAcconto, numeroRateAcconto,
                                    accontoAddizionaleComunale, idComuneAddComunale);
                            }
                            return null;
                        }
                        case "R": return null; // Regionale non ce ne sono in cedolini rata
                        // Ritenuta Nazionale - IRPEF
                        default:
                            // Bonus Fiscale
                            if (taxref == "14_BONUS_FISCALE") {
                                return calcola_bonus_fiscale_2014(idCedolino, natura, dataInizioCedolino,
                                    dataFineCedolino, idContratto, annoFiscale, imponibilenetto, codiceRitenuta);
                            }
                            else {
                                if (maggioreRitenuta != 0) {
                                    decimal imponibileAnnuoNonRapportato =
                                        imponibilenetto / numeratoreAnno * denominatoreAnno;
                                    //DateTime dataContabile = (DateTime)Conn.GetSys("datacontabile");
                                    object taxableNumerator, taxableDenominator;
                                    DataRow[] scaglioni = getTabellaScaglioni(codiceRitenuta, 0,
                                        imponibileAnnuoNonRapportato, dataContabile,
                                        out taxableNumerator, out taxableDenominator);

                                    return creaRitenutaConAliquotaPrefissata(idCedolino, imponibilenetto,
                                        maggioreRitenuta, codiceRitenuta,
                                        taxableNumerator, taxableDenominator);
                                }
                                else
                                    // Caso in cui è stata determinata l'applicaizone di una ritenuta a scaglioni
                                    return calcola_ritenuta_generica(idCedolino, codiceRitenuta, imponibilenetto,
                                        dataFineCedolino, numeratoreAnno, denominatoreAnno);
                            }

                    }
                //Assistenziale - Altro
                case 2:
                case 6:
                    return calcola_ritenuta_generica(idCedolino, codiceRitenuta, imponibilenetto,
                        dataFineCedolino, numeratoreAnno, denominatoreAnno);
                // Nel caso delle ritenute da CAF se non viene prodotta alcuna ritenuta viene ritornato NULL
                // anche perché queste ritenute sono presenti sono nei cedolini rata e non anche in quello di conguaglio

                // Ritenute Arretrate
                case 5: {
                    switch (taxref) {
                        // Addizionale Regionale Rateizzata (Quella inserita dalla scheda Addizionali nel
                        // riquadro inerente le addizionali regionali derivanti da contratti al 31.12 anno 
                        // precedente della stessa università)
                        case "08_ADDREGRATA":
                            if (controllaSePrimoCedolinoDelMese(idCedolino)) {
                                return calcolaRataAddizionaleRegionale(
                                    idCedolino, codiceRitenuta,
                                    dataInizioCedolino, dataFineCedolino, idContratto,
                                    annoFiscale, meseInizioRate, numeroRate,
                                    annoFiscale, addizionaleRegionale, idFiscalTaxRegionRata);
                            }
                            return null;
                        // Addizionale Comunale Rateizzata (Quella inserita dalla scheda Addizionali nel
                        // riquadro inerente le addizionali regionali derivanti da contratti al 31.12 anno 
                        // precedente della stessa univeristà
                        case "08_ADDCOMRATA":
                            if (controllaSePrimoCedolinoDelMese(idCedolino)) {
                                return calcolaRataAddizionaleComunale(
                                    idCedolino, codiceRitenuta,
                                    dataInizioCedolino, dataFineCedolino, idContratto,
                                    annoFiscale, meseInizioRate, numeroRate,
                                    annoFiscale, addizionaleComunale, idComuneAddComunaleRata);
                            }
                            return null;
                        // Gestione delle ritenute da CAF
                        default:
                            if (controllaSePrimoCedolinoDelMese(idCedolino)) {
                                object idCityCAF;
                                object idFiscalTaxRegionCAF;
                                decimal arretratoCaf = calcolaArretratiCaf(
                                    dataInizioCedolino, dataFineCedolino, idContratto, codiceRitenuta, taxref,
                                    annoFiscale, out idCityCAF, out idFiscalTaxRegionCAF);
                                if (arretratoCaf != 0) {
                                    return creaRigaCedolinoRitenuta(idCedolino, arretratoCaf, codiceRitenuta,
                                        idCityCAF, idFiscalTaxRegionCAF);
                                }
                            }
                            return null;
                    }
                }
                // Assicurativa
                case 4:
                    return calcola_ritenuta_inail(compensoLordoCedolino, imponibilenetto, idCedolino, idContratto,
                        dataInizioCedolino, dataFineCedolino, idPat, codiceRitenuta);
//					if (controllaSePrimoCedolinoDelMese(idCedolino)) {
//						return calcola_ritenuta_inail(compensoLordoCedolino, imponibilenetto, idCedolino, idContratto, dataInizioCedolino, dataFineCedolino, idPat, codiceRitenuta);
//					}
//					return null;
                // Previdenziale
                case 3:
                    return calcola_ritenuta_inps(idCedolino, dataInizioCedolino, dataFineCedolino, idContratto,
                        annoFiscale, imponibilenetto, codiceRitenuta);
            }
            return null;
        }

        /// <summary>
        /// Aggiunge una ritenuta ad aliquota fissa (payrolltax + bracket) ad un cedolino
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="imponibilenetto">imponibile sul quale applicare l'aliquota</param>
        /// <param name="maggioreritenuta">aliquota fissa</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <returns>riga della ritenuta</returns>
        private DataRow creaRitenutaConAliquotaPrefissata(object idCedolino,
            decimal imponibilenetto, decimal maggioreritenuta, object codiceRitenuta,
            object taxablenumerator, object taxabledenominator
        ) {
            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRit = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
            // L'aliquota diventa costante quindi si crea una sola riga in PAYROLLTAX e PAYROLLTAXBRACKET
            // La ritenuta è il prodotto tra imponibile e aliquota
            decimal rapporto = getRapporto(taxablenumerator, taxabledenominator);
            rRit["taxcode"] = codiceRitenuta;
            rRit["employrate"] = maggioreritenuta;
            rRit["adminrate"] = 0;
            rRit["employtaxgross"] = CfgFn.RoundValuta(imponibilenetto * maggioreritenuta * rapporto);
            rRit["admintax"] = 0;
            rRit["taxablenumerator"] = taxablenumerator;
            rRit["taxabledenominator"] = taxabledenominator;
            rRit["adminnumerator"] = 1;
            rRit["admindenominator"] = 1;
            rRit["employnumerator"] = 1;
            rRit["employdenominator"] = 1;
            rRit["taxablenet"] = CfgFn.RoundValuta(imponibilenetto * rapporto);

            DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRit, DS.payrolltaxbracket);
            rScagl["taxable"] = imponibilenetto;
            rScagl["employrate"] = maggioreritenuta;
            rScagl["employtax"] = rRit["employtaxgross"];
            rScagl["adminrate"] = 0;
            rScagl["admintax"] = 0;

            return rRit;
        }

        private DataRow creaRitenutaBonusFiscale(object idCedolino,
            decimal creditoApplicato, decimal importoBonus, object codiceRitenuta, string natura
        ) {
            decimal imponibilenetto = 0;
            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRit = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
            // Si crea una sola riga in PAYROLLTAX
            rRit["taxcode"] = codiceRitenuta;
            rRit["employrate"] = 0;
            rRit["adminrate"] = 0;
            rRit["employtaxgross"] = -importoBonus;
            rRit["employtax"] = -importoBonus;
            rRit["admintax"] = 0;
            rRit["taxablenumerator"] = 1;
            rRit["taxabledenominator"] = 1;
            rRit["adminnumerator"] = DBNull.Value;
            rRit["admindenominator"] = DBNull.Value;
            rRit["employnumerator"] = 1;
            rRit["employdenominator"] = 1;
            rRit["taxablegross"] = imponibilenetto;
            rRit["taxablenet"] = imponibilenetto;
            rRit["annualcreditapplied"] = -creditoApplicato;

            DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRit, DS.payrolltaxbracket);
            rScagl["taxable"] = imponibilenetto;
            rScagl["employrate"] = 0;
            rScagl["employtax"] = rRit["employtaxgross"];
            rScagl["adminrate"] = 0;
            rScagl["admintax"] = 0;
            return rRit;
        }

        /// <summary>
        /// Metodo che sceglie in quale giorno deve essere applicata la deduzione seguendo la seguente strategia:
        /// Caso 1: Data di Inizio del Cedolino - Se l'inizio dell'applicazione è compresa tra data inizio e fine del cedolino
        /// Caso 2: Data di Inizio del Cedolino - Se l'applicazione è iniziata prima e termina dopo la data di inizio del cedolino
        /// Caso 3: Data di Inizio del Cedolino - Se l'applicazione inizia nello stesso mese della data di inizio del cedolino ma è successiva in termini di giorni
        /// Caso 4: Primo Giorno del Mese successivo alla Data di Inizio del Cedolino - In tutti gli altri casi
        /// </summary>
        /// <param name="dataInizioCedolino">Data Inizio del Cedolino</param>
        /// <param name="dataFineCedolino">Data Fine del Cedolino</param>
        /// <param name="inizioApplicazione">Inizio dell'applicazione della deduzione</param>
        /// <param name="fineApplicazione">Fine dell'applicazione della deduzione</param>
        /// <returns>Data del primo giorno del Pagamento</returns>
        private DateTime getGiornoPrimoPagamentoFamiliare(DateTime dataInizioCedolino, DateTime dataFineCedolino,
            DateTime inizioApplicazione, DateTime fineApplicazione) {
            // Se l'applicazione ricade nel periodo di competenza del cedolino
            // allora il pagamento cadrà nel cedolino
            if ((inizioApplicazione >= dataInizioCedolino) && (inizioApplicazione <= dataFineCedolino)) {
                if ((inizioApplicazione.Month == dataInizioCedolino.Month) &&
                    (inizioApplicazione.Year == dataInizioCedolino.Year)) {
                    return dataInizioCedolino;
                }
            }

            // Se l'applicazione inizia prima del cedolino considerato e termina dopo di esso
            // allora il pagamento cadrà nel cedolino
            if ((inizioApplicazione < dataInizioCedolino) && (fineApplicazione >= dataInizioCedolino)) {
                return dataInizioCedolino;
            }

            if ((inizioApplicazione > dataInizioCedolino)
                && (inizioApplicazione.Month == dataInizioCedolino.Month)
                && (inizioApplicazione.Year == dataInizioCedolino.Year)) {
                return dataInizioCedolino;
            }
            DateTime primoMeseDopoInizioCedolino =
                new DateTime(dataInizioCedolino.Year, dataInizioCedolino.Month, 1).AddMonths(1);
            if (primoMeseDopoInizioCedolino < dataFineCedolino) {
                primoMeseDopoInizioCedolino = getGiornoPrimoPagamentoFamiliare(primoMeseDopoInizioCedolino,
                    dataFineCedolino, inizioApplicazione, fineApplicazione);
            }
            return primoMeseDopoInizioCedolino;
        }

        /// <summary>
        /// Restituisce:
        /// la data di inizio del cedolino se il giorno di tale data è 1 ed il mese è diverso da quello della prima rata;
        /// l'1 del mese successivo alla data di inizio del cedolino se il giorno di tale data è diverso da 1 ed il mese è diverso da quello della prima rata; 
        /// oppure se non esistono altri cedolini con datainizio minore o uguale all'ultimo del mese della prima rata
        /// l'1 del mese della prima rata se esiste già un altro cedolino con datainizio minore o uguale all'ultimo del mese della prima rata
        /// </summary>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="primoGiornoPrimaRata">giorno in cui versare la prima rata</param>
        /// <returns></returns>
        private DateTime getGiornoPrimoPagamento(object idcontratto,
            DateTime dataInizioCedolino, DateTime primoGiornoPrimaRata) {
            DateTime primoGiornoDelMeseInizioCedolino =
                new DateTime(dataInizioCedolino.Year, dataInizioCedolino.Month, 1);

            if (primoGiornoDelMeseInizioCedolino > primoGiornoPrimaRata) {
                //Il mese della data di inizio del cedolino è maggiore del mese della prima rata da pagare

                //primoPagamento = arrotondamento per eccesso di datainiziocedolino
                DateTime primoPagamento = (dataInizioCedolino.Day == 1)
                    ? dataInizioCedolino
                    : primoGiornoDelMeseInizioCedolino.AddMonths(1);

                //Restituisco il massimo tra primoPagamento e primoGiornoPrimaRata
                if (primoPagamento > primoGiornoPrimaRata) return primoPagamento;
                return primoGiornoPrimaRata;
            }

            DateTime ultimoGiornoPrimaRata = primoGiornoPrimaRata.AddMonths(1).AddDays(-1);
            //Il mese della data di inizio del cedolino è minore o uguale al mese della prima rata da pagare
            //Mi chiedo: Prima rata già pagata?
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto),
                QHC.CmpLe("start", ultimoGiornoPrimaRata),
                QHC.CmpLt("start", dataInizioCedolino),
                QHC.CmpGe("stop", ultimoGiornoPrimaRata),
                QHC.CmpEq("flagbalance", "N"));
            int count = DS.payroll.Select(filtro).Length;
            if (count == 0) {
                //No, la prima rata la dovrò pagare ora
                return primoGiornoPrimaRata;
            }
            //Si, ho già pagato la prima rata, comincio a pagare dal mese successivo a quello di inizio del cedolino
            return primoGiornoDelMeseInizioCedolino.AddMonths(1);
        }

        /// <summary>
        /// Metodo che ritorna il primo giorno su cui considerare il pagamento dell'INAIL
        /// </summary>
        /// <param name="idcontratto">ID del contratto sul quale controllare l'esistenza di altri cedolini</param>
        /// <param name="dataInizioCedolino">Data inizio del cedolino</param>
        /// <param name="primoCedolinoAnnoFiscale">Flag che indica se il cedolino è il primo dell'anno fiscale</param>
        /// <returns>Primo giorno di pagamento dell'INAIL</returns>
        private DateTime getGiornoPrimoPagamentoInail(object idcontratto,
            DateTime dataInizioCedolino, bool primoCedolinoAnnoFiscale) {
            // JTR - Se il cedolino che sto esaminando è il primo dell'anno fiscale devo verificare che
            // nell'anno precedente non abbia già pagato l'INAIL nel mese di inizio del cedolino corrente
            // Se invece non mi trovo sul primo cedolino dell'anno fiscale funziona tutto come prima.
            if (primoCedolinoAnnoFiscale) {
                int esercizioprec = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")) - 1;
                // Filtro per selezionare i cedolini dello stesso contratto dell'anno fiscale precedente
                string fAnnoPrec = QHS.AppAnd(QHS.CmpEq("idcon", idcontratto), QHS.CmpLt("stop", dataInizioCedolino),
                    QHS.CmpEq("fiscalyear", esercizioprec), QHS.CmpEq("flagbalance", "N"),
                    QHS.CmpNe("start", QHS.Field("stop")), QHS.CmpNe("feegross", 0));
                DataTable tempPayroll = DataAccess.CreateTableByName(Conn, "payroll", "*");
                Conn.RUN_SELECT_INTO_TABLE(tempPayroll, "start desc", fAnnoPrec, null, true);
                // Se non ci sono cedolini nell'anno precedente si ritorna la data di inizio del cedolino
                if ((tempPayroll == null) || (tempPayroll.Rows.Count == 0)) {
                    return dataInizioCedolino;
                }
                // Si seleziona l'ultimo cedolino dell'anno precedente
                DataRow lastPayroll = tempPayroll.Rows[0];
                DateTime datafineUltimoCedolinoPrecedenteAnnoPrec = (DateTime) lastPayroll["stop"];
                // Se il mese di fine dell'ultimo cedolino coincide con il mese di inizio del cedolino corrente
                // allora viene presa come primo giorno utile il primo giorno del nuovo mese
                // Esempio:
                // Ultimo cedolino anno precedente con data di fine il 10 ottobre
                // Primo cedolino anno nuovo con data di inizio l'11 ottobre
                // I due cedolini hanno il mese in comune, quindi il primo giorno valido per il 
                // calcolo dell'INAIL è l'1 novembre
                if ((datafineUltimoCedolinoPrecedenteAnnoPrec.Month == dataInizioCedolino.Month) &&
                    (datafineUltimoCedolinoPrecedenteAnnoPrec.Year == dataInizioCedolino.Year)) {
                    return new DateTime(dataInizioCedolino.Year, dataInizioCedolino.Month, 1).AddMonths(1);
                }
            }
            // Se sono su un cedolino differente dal primo dell'anno
            // verifico che i cedolini precedenti al corrente
            // non terminino nello stesso mese in cui il cedolino comincia
            // Se un cedolino tra i precedenti termina nello stesso mese
            // si prende come primo giorno INAIL il primo giorno del mese successivo
            // altrimenti resta il come primo giorno utile la data di inizio del cedolino corrente
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto),
                QHC.CmpLt("stop", dataInizioCedolino), QHC.CmpEq("flagbalance", "N"));
            DataRow[] rCedolini = DS.payroll.Select(filtro, "start");
            DateTime primoGiornoPagamento = dataInizioCedolino;
            foreach (DataRow rCed in rCedolini) {
                DateTime dataFineAltriCedolini = (DateTime) rCed["stop"];
                if ((dataFineAltriCedolini.Month == dataInizioCedolino.Month)
                    && (dataFineAltriCedolini.Year == dataInizioCedolino.Year)) {
                    primoGiornoPagamento =
                        new DateTime(primoGiornoPagamento.Year, primoGiornoPagamento.Month, 1).AddMonths(1);
                }
            }

            return primoGiornoPagamento;
        }

        /// <summary>
        /// Numero delle rate (di una qualsiasi ritenuta rateizzata)
        /// da versare nel periodo di competenza del cedolino
        /// </summary>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="annoPrimaRata">anno della prima rata da versare</param>
        /// <param name="mesePrimaRata">mese della prima rata da versare</param>
        /// <param name="numeroRate">numero delle rate da versare</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <returns>numero delle rate da versare nel periodo di competenza del cedolino</returns>
        private int getNumeroRateDaPagare(DateTime dataInizioCedolino, DateTime dataFineCedolino,
            int annoPrimaRata, int mesePrimaRata, int numeroRate, object idcontratto) {
            if (mesePrimaRata == 0) return 0;
            DateTime primoGiornoPrimaRata = new DateTime(annoPrimaRata, mesePrimaRata, 1);
            DateTime ultimoGiornoPrimaRata = primoGiornoPrimaRata.AddMonths(1).AddDays(-1);
            DateTime primoGiornoUltimaRata = new DateTime(annoPrimaRata, (mesePrimaRata + numeroRate - 1), 1);
            DateTime ultimoGiornoUltimaRata = primoGiornoUltimaRata.AddMonths(1).AddDays(-1);

            if (12 * (dataInizioCedolino.Year - ultimoGiornoUltimaRata.Year) + dataInizioCedolino.Month -
                ultimoGiornoUltimaRata.Month > 0) return 0;

            if (12 * (dataFineCedolino.Year - primoGiornoPrimaRata.Year) + dataFineCedolino.Month -
                primoGiornoPrimaRata.Month < 0) return 0;

            DateTime inizio = getGiornoPrimoPagamento(idcontratto, dataInizioCedolino, primoGiornoPrimaRata);
            DateTime fine = dataFineCedolino > ultimoGiornoUltimaRata ? ultimoGiornoUltimaRata : dataFineCedolino;

            int result = 1 + 12 * (fine.Year - inizio.Year) + fine.Month - inizio.Month;

            return result;
        }

        /// <summary>
        /// Controlla che il cedolino sia il primo del mese
        /// </summary>
        /// <param name="idCedolino">ID del cedolino da controllare</param>
        /// <returns>TRUE: se il cedolino è il primo del mese; FALSE: altrimenti</returns>
        private bool controllaSePrimoCedolinoDelMese(object idCedolino) {
            string filtro = QHC.CmpEq("idpayroll", idCedolino);
            DataRow rCed = DS.payroll.Select(filtro)[0];
            DateTime dataInizioCedolino = (DateTime) rCed["start"];
            DateTime inizioMese = new DateTime(dataInizioCedolino.Year, dataInizioCedolino.Month, 1);
            // Si costruisce un filtro che controlla che non ci siano altri cedolini che cominciano
            // nello stesso mese della data inizio del cedolino corrente
            string f1 = QHC.AppAnd(QHC.CmpNe("idpayroll", idCedolino),
                QHC.CmpGe("start", inizioMese), QHC.CmpLt("start", dataInizioCedolino),
                QHC.CmpEq("idcon", rCed["idcon"]));
            int cedoliniStessoMese = DS.payroll.Select(f1).Length;
            return (cedoliniStessoMese == 0) ? true : false;
        }

        /// <summary>
        /// Calcola l'addizionale regionale tenendo conto anche delle addizionali arretrate
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="annoPrimaRata">anno della prima rata dell'addizionale arretrata</param>
        /// <param name="meseiniziorate">mese della prima rata dell'addizionale arretrata</param>
        /// <param name="numerorate">numero rate dell'addizionale arretrata</param>
        /// <param name="annoPrimaRataCaf">anno della prima rata dell'addizionale da versare per conto CAF</param>
        /// <param name="addizionaleRegionale">addizionale regionale da versare per l'anno in corso</param>
        /// <returns></returns>
        private DataRow calcolaRataAddizionaleRegionale(object idCedolino,
            object codiceRitenuta,
            DateTime dataInizioCedolino, DateTime dataFineCedolino,
            object idcontratto, int annoPrimaRata, int meseiniziorate, int numerorate,
            int annoPrimaRataCaf,
            decimal addizionaleRegionale, object idFiscalTaxRegion) {

            decimal ritenuta_dipendente = 0;
            if (numerorate > 0) {
                int rateDaPagare = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino,
                    annoPrimaRata, meseiniziorate, numerorate, idcontratto);

                ritenuta_dipendente += addizionaleRegionale / numerorate * rateDaPagare;
            }

            return creaRigaCedolinoRitenuta(idCedolino, ritenuta_dipendente, codiceRitenuta, null, idFiscalTaxRegion);
        }

        /// <summary>
        /// Calcola l'addizionale comunale tenendo conto anche delle addizionali comunali arretrate
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="annoPrimaRata">anno della prima rata dell'addizionale arretrata</param>
        /// <param name="meseiniziorate">mese della prima rata dell'addizionale arretrata</param>
        /// <param name="numerorate">numero rate da versare dell'addizionale arretrata</param>
        /// <param name="annoPrimaRataCaf">anno della prima rata dell'addizionale da versare per conto del CAF</param>
        /// <param name="addizionaleComunale">addizionale comunale per l'annno in corso</param>
        /// <returns>addizionale comunale</returns>
        private DataRow calcolaRataAddizionaleComunale(object idCedolino,
            object codiceRitenuta,
            DateTime dataInizioCedolino, DateTime dataFineCedolino,
            object idcontratto, int annoPrimaRata, int meseiniziorate, int numerorate,
            int annoPrimaRataCaf,
            decimal addizionaleComunale, object idCity) {
            decimal ritenuta_dipendente = 0;
            if (numerorate > 0) {
                int rateDaPagare = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino, annoPrimaRata,
                    meseiniziorate, numerorate, idcontratto);
                ritenuta_dipendente += addizionaleComunale / numerorate * rateDaPagare;
            }

            return creaRigaCedolinoRitenuta(idCedolino, ritenuta_dipendente, codiceRitenuta, idCity, null);
        }

        /// <summary>
        /// Metodo che calcola il conguaglio dell'acconto all'addizionale comunale
        /// </summary>
        /// <param name="idCedolino"></param>
        /// <param name="codiceRitenuta"></param>
        /// <param name="idCity"></param>
        /// <returns></returns>
        private DataRow conguaglioAccontoAddCom(object idCedolino, object codiceRitenuta, object idCity) {
            // Viene creata una riga in payrolltax / payrolltaxbracket per restituire i soldi dell'acconto
            // all'addizionale comunale. Ricordiamo che il nostro modo di operare è quello che
            // tratteniamo per ogni cedolino rata una quota dell'acconto all'addizionale (in base al numero di rate 
            // applicate) e in conguaglio restituiamo la somma in quanto la legge dice che l'acconto all'addizionale
            // comunale deve essere portato in compensazione con l'addizionale comunale da versare
            DataRow rPayrollTax = creaRigaCedolinoRitenuta(idCedolino, 0, codiceRitenuta, idCity, null);
            return rPayrollTax;
        }

        /// <summary>
        /// Calcola la rata dell'acconto all'addizionale comunale
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="annoPrimaRata">anno della prima rata dell'addizionale arretrata</param>
        /// <param name="meseiniziorate">mese della prima rata dell'addizionale arretrata</param>
        /// <param name="numerorate">numero rate da versare dell'addizionale arretrata</param>
        /// <param name="addizionaleComunale">addizionale comunale per l'annno in corso</param>
        /// <returns>addizionale comunale</returns>
        private DataRow calcolaRataAccontoAddizionaleComunale(object idCedolino,
            object codiceRitenuta,
            DateTime dataInizioCedolino, DateTime dataFineCedolino,
            object idcontratto, int annoPrimaRata, int meseiniziorate, int numerorate,
            decimal accontoAddizionaleComunale, object idCity) {
            decimal ritenuta_dipendente = 0;
            if (numerorate > 0) {
                int rateDaPagare = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino, annoPrimaRata,
                    meseiniziorate, numerorate, idcontratto);
                ritenuta_dipendente += accontoAddizionaleComunale / numerorate * rateDaPagare;
            }

            return creaRigaCedolinoRitenuta(idCedolino, ritenuta_dipendente, codiceRitenuta, idCity, null);
        }

        /// <summary>
        /// Restituisce la tabella degli scaglioni da applicare per la ritenuta data.
        /// </summary>
        /// <param name="codiceritenuta">id. del tipo di ritenuta</param>
        /// <param name="imponibilePregresso">imponibile di partenza (sul quale si è già versata la ritenuta);
        /// 0 se gli scaglioni vanno applicati tutti ad ogni nuovo calcolo</param>
        /// <param name="compensoDaTassare">imponibile sul quale applicare la ritenuta</param>
        /// <param name="dataprestazione">data di competenza della ritenuta</param>
        /// <returns>tabella degli scaglioni</returns>
        private DataRow[] getTabellaScaglioni(object codiceritenuta, decimal imponibilePregressoNonRapportato,
            decimal compensoDaTassareNonRapportato, DateTime dataprestazione,
            out object taxableNumerator, out object taxableDenominator) {
            // Si considera l'imponibile annuo non rapportato
            decimal imponibileAnnuoNonRapportato =
                imponibilePregressoNonRapportato + compensoDaTassareNonRapportato;

            // Si fissa una data di riferimento
            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            string filtro = QHS.AppAnd(QHS.CmpLe("start", dataContabile),
                QHC.CmpEq("taxcode", codiceritenuta));

            // Si ottiene la tabella delle strutture della ritenuta fornita in input
            DataTable tStrutture =
                DataAccess.RUN_SELECT(Conn, "taxratestart", null, "start desc", filtro, "1", null, true);
            if (tStrutture.Rows.Count == 0) {
                taxableNumerator = DBNull.Value;
                taxableDenominator = DBNull.Value;
                return new DataRow[0];
            }
            // Si ottengono numeratore e denominatore
            taxableNumerator = tStrutture.Rows[0]["taxablenumerator"];
            taxableDenominator = tStrutture.Rows[0]["taxabledenominator"];

            // Si calcola il rapporto tra numeratore e denominatore
            decimal rapporto = getRapporto(taxableNumerator, taxableDenominator);

            // Imponibile Raportato è l'imponibile non rapportato moltiplicato per il rapporto
            decimal imponibileAnnuoRapportato = imponibileAnnuoNonRapportato * rapporto;
            decimal imponibilePregressoRapportato = imponibilePregressoNonRapportato * rapporto;

            object enforcement = tStrutture.Rows[0]["enforcement"];
            object idTaxRateStart = tStrutture.Rows[0]["idtaxratestart"];

            // Si confronta l'imponibile rapportato con i limiti minimo e massimo degli scaglioni
            string query = (imponibileAnnuoRapportato > 0)
                ? QHS.AppAnd(QHS.CmpEq("taxcode", codiceritenuta),
                    QHS.CmpEq("idtaxratestart", idTaxRateStart),
                    QHS.NullOrLt("minamount", imponibileAnnuoRapportato),
                    QHS.NullOrGt("maxamount", imponibilePregressoRapportato))
                : QHS.AppAnd(QHS.CmpEq("taxcode", codiceritenuta),
                    QHS.CmpEq("idtaxratestart", idTaxRateStart),
                    QHS.NullOrLe("minamount", imponibileAnnuoRapportato),
                    QHS.NullOrGt("maxamount", imponibilePregressoRapportato));

            // Si ottiene la tabella degli scaglioni
            DataTable tScaglioni =
                DataAccess.RUN_SELECT(Conn, "taxratebracket", null, "nbracket", query, null, null, true);
            DataRow[] rScaglioni = tScaglioni.Select();

            // Si impostano della tabella degli scaglioni gli importi minimo e massimo dello scaglione che si confronta con l'imponibile
            if (rScaglioni.Length > 0) {
                DataRow ultimoScaglione = rScaglioni[rScaglioni.Length - 1];
                if (enforcement.Equals("F")) {
                    ultimoScaglione["minamount"] = imponibilePregressoRapportato;
                    ultimoScaglione["maxamount"] = imponibileAnnuoRapportato;
                    return new DataRow[] {ultimoScaglione};
                }
                //NUOVA ASSUNZIONE: SE MIN= MAX l'aliquota si applica per intero a tutto 0 - MIN
                decimal importoMinimoPrimoScaglione = CfgFn.GetNoNullDecimal(rScaglioni[0]["minamount"]);
                decimal importoMassimoPrimoScaglione = CfgFn.GetNoNullDecimal(rScaglioni[0]["maxamount"]);
                if ((importoMinimoPrimoScaglione == 0) || (importoMinimoPrimoScaglione < imponibilePregressoRapportato)
                    || (importoMinimoPrimoScaglione == importoMassimoPrimoScaglione)) {
                    rScaglioni[0]["minamount"] = imponibilePregressoRapportato;
                }
                decimal importoMassimo = CfgFn.GetNoNullDecimal(ultimoScaglione["maxamount"]);
                if ((importoMassimo == 0) || (importoMassimo > imponibileAnnuoRapportato)) {
                    ultimoScaglione["maxamount"] = imponibileAnnuoRapportato;
                }
            }
            return rScaglioni;
        }

        /// <summary>
        /// Restituisce la tabella degli scaglioni da applicare per la ritenuta geografica data.
        /// </summary>
        /// <param name="codiceritenuta">id. del tipo di ritenuta</param>
        /// <param name="imponibileAnnuo">imponibile sul quale applicare la ritenuta</param>
        /// <param name="dataprestazione">data di competenza della ritenuta</param>
        /// <param name="tabellaAliquote">tabella sul db contenente le aliquote per la ritenuta</param>
        /// <param name="tabellaScaglioni">tabella sul db contenente gli scaglioni per la ritenuta</param>
        /// <param name="nomeCampoGeo">nome dell'id. dell'ente geografico</param>
        /// <param name="valoreCampoGeo">valore dell'ente geografico</param>
        /// <returns>tabella degli scaglioni</returns>
        private DataRow[] getTabellaScaglioniGeo(
            object codiceritenuta, decimal imponibileAnnuo, DateTime dataPrestazione,
            string prefissoTabella, string nomeCampoGeo, object valoreCampoGeo, out DateTime inizioValidita) {

            // Il principio di funzionamento di questo metodo è il medesimo del metodo getTabellaScaglioni.
            // E' stato definito un metodo a parte giacché le tabelle adoperate sono differenti e sono quelle
            // delle strutture delle ritenute locali (siano esse comunali o regionali)
            string tabellaScaglioni = prefissoTabella + "start";
            string tabellaAliquote = prefissoTabella + "bracket";
            string incrementale = "id" + tabellaScaglioni;

            string filtro = QHS.AppAnd(QHS.CmpLe("start", dataPrestazione),
                QHS.CmpEq("taxcode", codiceritenuta), QHS.CmpEq(nomeCampoGeo, valoreCampoGeo));

            DataTable tStrutture =
                DataAccess.RUN_SELECT(Conn, tabellaScaglioni, null, "start desc", filtro, "1", null, true);
            if (tStrutture.Rows.Count == 0) {
                inizioValidita = new DateTime();
                return new DataRow[0];
            }
            DataRow rStart = tStrutture.Rows[0];

            //Vede se è previsto un importo esente
            if (tStrutture.Columns.Contains("taxablemin")) {
                decimal esente = CfgFn.GetNoNullDecimal(rStart["taxablemin"]);
                if (esente >= imponibileAnnuo) {
                    inizioValidita = new DateTime();
                    return new DataRow[0];
                }
            }

            object idtaxratexxxstart = rStart[incrementale];
            object enforcement = rStart["enforcement"];
            inizioValidita = (DateTime) rStart["start"];

            string query = QHS.AppAnd(QHS.CmpEq("taxcode", codiceritenuta),
                QHS.CmpEq(incrementale, idtaxratexxxstart), QHS.CmpEq(nomeCampoGeo, valoreCampoGeo),
                QHS.NullOrLt("minamount", imponibileAnnuo));
            DataTable tScaglioni =
                DataAccess.RUN_SELECT(Conn, tabellaAliquote, null, "nbracket", query, null, null, true);
            DataRow[] rScaglioni = tScaglioni.Select();

            if (rScaglioni.Length > 0) {
                DataRow ultimoScaglione = rScaglioni[rScaglioni.Length - 1];
                if (enforcement.Equals("F")) {
                    ultimoScaglione["minamount"] = 0;
                    ultimoScaglione["maxamount"] = imponibileAnnuo;
                    return new DataRow[] {ultimoScaglione};
                }
                //NUOVA ASSUNZIONE: SE MIN= MAX l'aliquota si applica per intero a tutto 0 - MIN
                decimal importoMinimoPrimoScaglione = CfgFn.GetNoNullDecimal(rScaglioni[0]["minamount"]);
                decimal importoMassimoPrimoScaglione = CfgFn.GetNoNullDecimal(rScaglioni[0]["maxamount"]);
                if (importoMinimoPrimoScaglione == importoMassimoPrimoScaglione) {
                    rScaglioni[0]["minamount"] = 0;
                }
                decimal importoMassimo = CfgFn.GetNoNullDecimal(ultimoScaglione["maxamount"]);
                if ((importoMassimo == 0) || (importoMassimo > imponibileAnnuo)) {
                    ultimoScaglione["maxamount"] = imponibileAnnuo;
                }
            }
            return rScaglioni;
        }

        /// <summary>
        /// Restituisce il rapporto fra i due numeri in input dando dei default ai DBNull
        /// </summary>
        /// <param name="quotaNum"></param>
        /// <param name="quotaDen"></param>
        /// <returns></returns>
        //private decimal getRapporto(object quotaNum, object quotaDen) {
        //    decimal num = (quotaNum is DBNull) ? 1 : Convert.ToDecimal(quotaNum);
        //    decimal den = CfgFn.GetNoNullDecimal(quotaDen);

        //    return (den == 0) ? 1 : num / den;
        //}

        /// <summary>
        /// Restituisce il rapporto fra i due numeri in input dando dei default ai DBNull
        /// </summary>
        /// <param name="quotaNum"></param>
        /// <param name="quotaDen"></param>
        /// <returns></returns>
        private static decimal getRapporto(object quotaNum, object quotaDen) {
            decimal num = (quotaNum is DBNull) ? 1 : Convert.ToDecimal(quotaNum);
            decimal den = CfgFn.GetNoNullDecimal(quotaDen);

            return (den == 0) ? 1 : num / den;
        }

        /// <summary>
        /// Calcola la quota conto dipendente e la quota conto amministrazione della ritenuta
        /// </summary>
        /// <param name="r">riga della tabella aliquota</param>
        /// <param name="frazioneDipendente">quota conto dipendente</param>
        /// <param name="frazioneAmministrazione">quota conto amministrazione</param>
        //private void calcolaQuotaDipEAmm(DataRow rStart, DataRow rBracket, out decimal frazioneDipendente, out decimal frazioneAmministrazione) {
        //    decimal frazioneImponibile = getRapporto(rStart["taxablenumerator"], rStart["taxabledenominator"]);

        //    frazioneAmministrazione = frazioneImponibile
        //        * getRapporto(rBracket["adminnumerator"], rBracket["admindenominator"]);

        //    frazioneDipendente = frazioneImponibile
        //        * getRapporto(rBracket["employnumerator"], rBracket["employdenominator"]);
        //}

        /// <summary>
        /// Data la tabella degli scaglioni, restituisce la riga della ritenuta
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="scaglioni">tabella degli scaglioni da applicare</param>
        /// <param name="frazioneDiAnno">rapporto tra periodo di competenza e durata dell'anno</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <returns>ritenuta</returns>
        private DataRow calcolaRitenutaScaglionata(
            //decimal imponibileNonRapportato,
            object taxableNumerator,
            object taxableDenominator,
            object idCedolino,
            DataRow[] scaglioni,
            object codiceRitenuta,
            decimal numeratoreAnno,
            decimal denominatoreAnno
        ) {
            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRiten = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
            rRiten["taxcode"] = codiceRitenuta;

            if (scaglioni.Length == 0) {
                return rRiten;
            }

            decimal totImponib = 0;
            decimal totRitDip = 0;
            decimal totRitAmm = 0;
            decimal totRitDipFrazionata = 0;
            decimal totRitAmmFrazionata = 0;
            decimal totRitDipScaglioniArrotondata = 0;
            decimal totRitAmmScaglioniArrotondata = 0;
            bool ultimoScaglione = false;
            int nCiclo = 0;
            // Per ogni scaglione presente nella tabella degli scaglioni
            foreach (DataRow rBracket in scaglioni) {
                ultimoScaglione = (nCiclo == scaglioni.Length - 1);
                // Si considera l'imponibile come rapporto tra numeratore e denominatore dell'anno e la differenza tra
                // massimo e minimo dello scaglione.
                decimal imponibile = numeratoreAnno / denominatoreAnno *
                                     (CfgFn.GetNoNullDecimal(rBracket["maxamount"]) -
                                      CfgFn.GetNoNullDecimal(rBracket["minamount"]));

                // La ritenuta dipendente è calcolata come prodotto tra imponibile ed aliquota
                decimal ritDipendente = imponibile * CfgFn.GetNoNullDecimal(rBracket["employrate"]);
                // idem x la ritenuta c/amministrazione
                decimal ritAmministrazione = imponibile * CfgFn.GetNoNullDecimal(rBracket["adminrate"]);

                // Si calcolano le frazioni c/amministraizone e dipendente (per le ritenute come l'INPS 
                // dove si specifica una ripartizione della ritenuta tra amministrazione, 2/3, e dipendente, 1/3)
                decimal frazioneAmministrazione =
                    getRapporto(rBracket["adminnumerator"], rBracket["admindenominator"]);

                decimal frazioneDipendente =
                    getRapporto(rBracket["employnumerator"], rBracket["employdenominator"]);

                totImponib += imponibile;
                totRitDip += ritDipendente;
                totRitAmm += ritAmministrazione;

                // Si calcola la ritenuta frazioneta (prodotto tra ritenuta dipendente e la frazione)
                totRitDipFrazionata += ritDipendente * frazioneDipendente;
                totRitAmmFrazionata += ritAmministrazione * frazioneAmministrazione;

                // Si crea una riga in payrolltaxcbracket dello scaglione corrente
                DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRiten, DS.payrolltaxbracket);
                rScagl["taxable"] = CfgFn.RoundValuta(imponibile);
                rScagl["employrate"] = rBracket["employrate"];
                rScagl["adminrate"] = rBracket["adminrate"];

                decimal ritDipInScaglione = CfgFn.RoundValuta(frazioneDipendente * ritDipendente);
                decimal ritAmmInScaglione = CfgFn.RoundValuta(frazioneAmministrazione * ritAmministrazione);
                totRitDipScaglioniArrotondata += ritDipInScaglione;
                totRitAmmScaglioniArrotondata += ritAmmInScaglione;

                // Si effettuato gli arrotondamenti sull'ultimo scaglione
                if (ultimoScaglione) {
                    rScagl["employtax"] = (totRitDipScaglioniArrotondata == CfgFn.RoundValuta(totRitDipFrazionata))
                        ? ritDipInScaglione
                        : ritDipInScaglione + (CfgFn.RoundValuta(totRitDipFrazionata) - totRitDipScaglioniArrotondata);
                    rScagl["admintax"] = (totRitAmmScaglioniArrotondata == CfgFn.RoundValuta(totRitAmmFrazionata))
                        ? ritAmmInScaglione
                        : ritAmmInScaglione + (CfgFn.RoundValuta(totRitAmmFrazionata) - totRitAmmScaglioniArrotondata);
                }
                else {
                    rScagl["employtax"] = ritDipInScaglione;
                    rScagl["admintax"] = ritAmmInScaglione;
                }
                nCiclo++;
            }

            decimal totRitAmmArrotondata = CfgFn.RoundValuta(totRitAmmFrazionata);
            decimal totRitDipArrotondata = CfgFn.RoundValuta(totRitDipFrazionata);
            // Si riempie la riga di payrolltax tenendo conto delle quote
            riempiRitenutaConQuote(taxableNumerator, taxableDenominator,
                rRiten, scaglioni[scaglioni.Length - 1], false, totImponib, totRitAmm, totRitDip,
                totRitAmmArrotondata, totRitDipArrotondata);

            return rRiten;
        }

        /// <summary>
        /// Metodo che aggiunge alla ritenuta c/dip versata annua quella presente nei CUD presentati
        /// </summary>
        /// <param name="rCedRitenuta">DataRow di tipo DS.payrolltax</param>
        /// <param name="applicazioneGeografica">Applicazione Geografica della ritenuta</param>
        /// <returns>DataRow in input modificato</returns>
        private DataRow aggiungiRitenutaVersataAnnuaDaCud(DataRow rCedRitenuta, string applicazioneGeografica) {
            string campoRitenutaApplicata;
            string campoRitenutaSospesa;
            // In base all'applicazione geografica si determinano i nomi dei campi da interrogare
            switch (applicazioneGeografica) {
                case "C": {
                    campoRitenutaApplicata = "citytaxapplied";
                    campoRitenutaSospesa = "suspendedcitytax";
                    break;
                }
                case "R": {
                    campoRitenutaApplicata = "regionaltaxapplied";
                    campoRitenutaSospesa = "suspendedregionaltax";
                    break;
                }
                default: {
                    campoRitenutaApplicata = "irpefapplied";
                    campoRitenutaSospesa = "irpefsuspended";
                    break;
                }
            }

            DataRow[] cedolini = DS.payroll.Select(QHC.CmpEq("idpayroll", rCedRitenuta["idpayroll"]));
            if (cedolini.Length == 0) return rCedRitenuta;
            DataRow rCedolino = cedolini[0];
            object idContratto = rCedolino["idcon"];
            string filtroCud = QHC.CmpEq("idcon", idContratto);
            DataRow[] rCud = DS.exhibitedcud.Select(filtroCud, "idexhibitedcud");
            decimal ritenutaVersataInCud = 0;
            // Per ogni CUD si somma il valore presente nel corrispondente campo precedentemente individuato
            if (rCud.Length > 0) {
                foreach (DataRow cudPresentato in rCud) {
                    if (cudPresentato["flagignoreprevcud"].ToString().ToUpper() == "S") {
                        ritenutaVersataInCud = CfgFn.GetNoNullDecimal(cudPresentato[campoRitenutaApplicata]) -
                                               CfgFn.GetNoNullDecimal(cudPresentato[campoRitenutaSospesa]);
                    }
                    else {
                        ritenutaVersataInCud += (CfgFn.GetNoNullDecimal(cudPresentato[campoRitenutaApplicata]) -
                                                 CfgFn.GetNoNullDecimal(cudPresentato[campoRitenutaSospesa]));
                    }
                }
            }
            // Si imposta il campo annualpayedemploytax di payrolltax pari al risultato ottenuto.
            rCedRitenuta["annualpayedemploytax"] =
                CfgFn.GetNoNullDecimal(rCedRitenuta["annualpayedemploytax"]) + ritenutaVersataInCud;
            return rCedRitenuta;
        }

        private static decimal aggiungiBonusDaCud(DataAccess Conn, object idContratto, object idDbDepartment) {

            decimal bonusApplicato =
                calcolaTotaleRicorsivoCud(Conn, idContratto, idDbDepartment, "fiscalbonusapplied", null, false);
            return bonusApplicato;
        }

        /// <summary>
        /// Data la tabella degli scaglioni restituisce la riga della ritenuta
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="scaglioni">tabella degli scaglioni</param>
        /// <param name="isConguaglio">true se si sta calcolando il cedolino di conguaglio</param>
        /// <returns>ritenuta</returns>
        private DataRow calcolaRitenuteScaglionateGeografiche(object idCedolino,
            object codiceRitenuta, DataRow[] scaglioni, bool isConguaglio,
            object idCity, object idFiscalTaxRegion) {

            // Questo metodo adotta i principi già visti nel metodo calcolaRitenutaScaglionata
            if (scaglioni.Length == 0) {
                return null;
            }

            DataRow ultimoScaglione = scaglioni[scaglioni.Length - 1];
            decimal totImponib = 0;
            decimal totRitDip = 0;

            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRiten = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);

            foreach (DataRow r in scaglioni) {
                decimal imponibile = CfgFn.GetNoNullDecimal(r["maxamount"]) - CfgFn.GetNoNullDecimal(r["minamount"]);
                decimal ritDipendente = CfgFn.RoundValuta(imponibile * CfgFn.GetNoNullDecimal(r["rate"]));
                totRitDip += ritDipendente;
                totImponib += imponibile;
                DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRiten, DS.payrolltaxbracket);
                rScagl["taxable"] = imponibile;
                rScagl["employrate"] = r["rate"];
                rScagl["employtax"] = ritDipendente;
                rScagl["adminrate"] = 0;
                rScagl["admintax"] = 0;
            }

            rRiten["taxcode"] = codiceRitenuta;
            rRiten["employrate"] = (totImponib != 0) ? totRitDip / totImponib : 0;
            rRiten["taxcode"] = ultimoScaglione["taxcode"];
            rRiten["taxablenet"] = totImponib;
            rRiten["admintax"] = 0;
            rRiten["employtaxgross"] = totRitDip;
            rRiten["annualpayedemploytax"] = 0;
            if (idCity != null) rRiten["idcity"] = idCity;
            if (idFiscalTaxRegion != null) rRiten["idfiscaltaxregion"] = idFiscalTaxRegion;

            return rRiten;
        }

        /// <summary>
        /// Metodo che somma nel conguaglio le addizionali dell'anno precedente rateizzate
        /// ATTENZIONE: QUESTO METODO NON VIENE PIU' UTILIZZATO IN QUANTO LE ADDIZIONALI RATEIZZATE NON VENGONO
        /// PIU' SOMMATE IN CONGUAGLIO CON LE ADDIZIONALI DEL CONTRATTO
        /// </summary>
        /// <param name="rCedolinoRitenuta">DataRow del Cedolino Ritenuta</param>
        /// <param name="importo">Importo dell'addizionale derivante dall'esercizio precedente da rateizzare</param>
        //private void aggiungiAddizionaleRateizzata(object idCedolino, DataRow rCedolinoRitenuta, 
        //    decimal importo, object codiceRitenuta) {
        //    if (rCedolinoRitenuta != null) {
        //        rCedolinoRitenuta["employtaxgross"] = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["employtaxgross"]) + importo;
        //        rCedolinoRitenuta["employtax"] = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["employtax"]) + importo;
        //        aggiungiScaglioneRitenuta(rCedolinoRitenuta, importo);
        //    }
        //    else {
        //        // J.T.R. 28.05.2008 - Metto NULL come parametro dell'idCity perché ci dobbiamo pensare!!
        //        creaRigaCedolinoRitenuta(idCedolino, importo, codiceRitenuta, null, null);
        //    }
        //}

        /// <summary>
        /// Metodo che aggiunge uno scaglione ad imponibile zero ad una ritenuta o aggiorna i dati della ritenuta c/dipendente
        /// METODO NON USATO.
        /// </summary>
        /// <param name="rCedolinoRitenuta"></param>
        /// <param name="importo"></param>
        private void aggiungiScaglioneRitenuta(DataRow rCedolinoRitenuta, decimal importo) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idpayroll", rCedolinoRitenuta["idpayroll"]),
                QHC.CmpEq("idpayrolltax", rCedolinoRitenuta["idpayrolltax"]),
                QHC.CmpEq("employrate", 0));

            DataRow[] rScaglioni = DS.payrolltaxbracket.Select(filtro);
            if (rScaglioni.Length == 0) {
                DataRow rScaglione = MetaCedolinoRitenutaScaglione.Get_New_Row(rCedolinoRitenuta, DS.payrolltaxbracket);
                rScaglione["taxable"] = 0;
                rScaglione["employrate"] = 0;
                rScaglione["employtax"] = importo;
            }
            else {
                rScaglioni[0]["employtax"] = CfgFn.GetNoNullDecimal(rScaglioni[0]["employtax"]) + importo;
            }
        }

        /// <summary>
        /// Calcola l'addizionale Irpef comunale
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="isConguaglio">true se è un cedolino di conguaglio</param>
        /// <param name="imponibileAnnuo">imponibile netto sul quale applicare la ritenuta</param>
        /// <param name="idcomune">id. del comune</param>
        /// <param name="dataprestazione">data di competenza della ritenuta</param>
        /// <param name="importoAddizionaleRateizzata">Importo dell'addizionale derivante dall'anno precedente da rateizzare</param>
        /// <returns>addizionale comunale</returns>
        public DataRow sp_calc_ritenutacomunale(object idCedolino,
            object codiceRitenuta,
            bool isConguaglio,
            decimal imponibileAnnuo,
            object idcomune,
            DateTime dataprestazione,
            decimal importoAddizionaleRateizzata) {

            DateTime start;
            // Si determinano gli scaglioni di applicazione della ritenuta e successivamente si scrive
            // nel dataset il risultato del calcolo
            DataRow[] scaglioni = getTabellaScaglioniGeo(
                codiceRitenuta, imponibileAnnuo, dataprestazione, "taxratecity", "idcity", idcomune, out start);

            DataRow rCedRitenuta = calcolaRitenuteScaglionateGeografiche(idCedolino, codiceRitenuta,
                scaglioni, isConguaglio, idcomune, null);
            // J.T.R. 28.05.2008 - Non devo più sommare le addizionali da rateizzare, ora hanno un loro codice ritenuta
            //if ((isConguaglio) && (importoAddizionaleRateizzata != 0)) {
            //    aggiungiAddizionaleRateizzata(idCedolino, rCedRitenuta, importoAddizionaleRateizzata, codiceRitenuta);
            //}

            if (rCedRitenuta == null) return null;
            // Si aggiunge la ritenuta presente nel CUD
            return aggiungiRitenutaVersataAnnuaDaCud(rCedRitenuta, "C");
        }

        /// <summary>
        /// Metodo che ottiene l'id della regione dall'ID del comune
        /// </summary>
        /// <param name="idCity"></param>
        /// <returns></returns>
        private object ottieniRegioneDaCitta(object idCity) {
            return Conn.DO_READ_VALUE("geo_cityview", QHS.CmpEq("idcity", idCity), "idregion");

        }

        public static DataTable getCudLinkedToContract(DataAccess Conn, object idContratto, object idDbDepartment) {
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            string table = "exhibitedcud";
            QueryHelper QHS = Conn.GetQueryHelper();
            if (idDbDepartment != null) {
                table = idDbDepartment.ToString() + "." + table;
            }
            return
                Conn.SQLRunner("SELECT * FROM " + table + " E WHERE " +
                               QHS.AppAnd(QHS.CmpEq("E.idcon", idContratto), QHS.CmpEq("E.fiscalyear", esercizio)) +
                               " AND NOT EXISTS(SELECT * FROM " + table + " EE where " +
                               QHS.AppAnd(QHS.CmpEq("EE.idcon", idContratto), QHS.CmpEq("EE.fiscalyear", esercizio)) +
                               " AND (EE.flagignoreprevcud='S') AND (EE.idexhibitedcud>E.idexhibitedcud) )");
        }


        /// <summary>
        /// Metodo che genera gli storni tra enti qualora le ritenute locali siano state versate ad enti
        /// differenti rispetto a quelli individuati in sede di conguaglio
        /// </summary>
        /// <param name="currIdGeo"></param>
        /// <param name="idContratto"></param>
        /// <param name="taxCode"></param>
        /// <param name="idPayroll"></param>
        /// <param name="geo"></param>
        private void stornaEntiSeDifferenti(object currIdGeo, object idContratto, object taxCode,
            object idPayroll, string geo) {
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            // Si ottiene l'elenco dei CUD assocaiti al contratto
            DataTable LinkedCud = getCudLinkedToContract(Conn, idContratto, null);

            string filtroCud = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                QHS.FieldIn("idexhibitedcud", LinkedCud.Select()));

            string fieldApplied = (geo == "R") ? "regionaltaxapplied" : "citytaxapplied";
            string fieldSuspended = (geo == "R") ? "suspendedregionaltax" : "suspendedcitytax";
            string fieldGeo = (geo == "R") ? "idfiscaltaxregion" : "idcity";
            string fieldDest = (geo == "R") ? "idfiscaltaxregion" : "idcity";

            string currIdG = currIdGeo.ToString().ToUpper();

            // Per ogni CUD si valuta l'ente al quale è stato effettuato il versametno e se differente da quello
            // individuato in sede di conguaglio bisognerà effettuare degli storni, creando delle coppie
            // di righe nella tabella PAYROLLTAXCORRIGE
            foreach (DataRow rCud in DS.exhibitedcud.Select(filtroCud)) {
                string idGeoCud = rCud[fieldGeo].ToString().ToUpper();

                if (currIdG != idGeoCud) {
                    if (geo == "R") {
                        string filterGeoCud = QHC.AppAnd(QHC.CmpEq(fieldGeo, idGeoCud),
                            QHC.CmpEq("idpayroll", idPayroll), QHC.CmpEq("taxcode", taxCode));

                        if (DS.payrolltaxcorrige.Select(filterGeoCud).Length > 0) {
                            DataRow rPTC = DS.payrolltaxcorrige.Select(filterGeoCud)[0];
                            rPTC["adminamount"] = CfgFn.GetNoNullDecimal(rPTC["adminamount"]) -
                                                  (CfgFn.GetNoNullDecimal(rCud[fieldApplied]) -
                                                   CfgFn.GetNoNullDecimal(rCud[fieldSuspended]));
                        }
                        else {
                            MetaStorno.SetDefaults(DS.payrolltaxcorrige);
                            MetaData.SetDefault(DS.payrolltaxcorrige, "idpayroll", idPayroll);
                            DataRow rNuova = MetaStorno.Get_New_Row(null, DS.payrolltaxcorrige);
                            rNuova["adminamount"] = -(CfgFn.GetNoNullDecimal(rCud[fieldApplied]) -
                                                      CfgFn.GetNoNullDecimal(rCud[fieldSuspended]));
                            rNuova["taxcode"] = taxCode;
                            rNuova["ayear"] = esercizio;
                            rNuova[fieldDest] = rCud[fieldGeo];
                        }

                        string filterGeoContract = QHC.AppAnd(QHC.CmpEq("idfiscaltaxregion", currIdG),
                            QHC.CmpEq("idpayroll", idPayroll), QHC.CmpEq("taxcode", taxCode));

                        if (DS.payrolltaxcorrige.Select(filterGeoContract).Length > 0) {
                            DataRow rPTC = DS.payrolltaxcorrige.Select(filterGeoContract)[0];
                            rPTC["adminamount"] = CfgFn.GetNoNullDecimal(rPTC["adminamount"]) +
                                                  (CfgFn.GetNoNullDecimal(rCud[fieldApplied]) -
                                                   CfgFn.GetNoNullDecimal(rCud[fieldSuspended]));
                        }
                        else {
                            MetaStorno.SetDefaults(DS.payrolltaxcorrige);
                            MetaData.SetDefault(DS.payrolltaxcorrige, "idpayroll", idPayroll);
                            DataRow rNuova = MetaStorno.Get_New_Row(null, DS.payrolltaxcorrige);
                            rNuova["adminamount"] = CfgFn.GetNoNullDecimal(rCud[fieldApplied]) -
                                                    CfgFn.GetNoNullDecimal(rCud[fieldSuspended]);
                            rNuova["taxcode"] = taxCode;
                            rNuova["ayear"] = esercizio;
                            rNuova[fieldDest] = currIdGeo;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calcola l'addizionale regionale
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="isConguaglio">true se è un cedolino di conguaglio</param>
        /// <param name="imponibileAnnuo">imponibile netto annuo sul quale applicare l'addizionale</param>
        /// <param name="codiceritenuta">id. del tipo di ritenuta</param>
        /// <param name="idcomune">id. del comune</param>
        /// <param name="dataprestazione">data di competenza della ritenuta</param>
        /// <param name="importoAddizionaleRateizzata">Importo dell'addizionale derivante dall'anno precedente da rateizzare</param>
        /// <returns>riga di cedolinoritenuta aggiunta</returns>
        public DataRow sp_calc_ritenutaregionale(
            object idCedolino,
            object codiceRitenuta,
            bool isConguaglio,
            decimal imponibileAnnuo,
            object idcomune,
            DateTime dataprestazione,
            decimal importoAddizionaleRateizzata,
            object idFiscalTaxRegion) {

            // Si determinano gli scaglioni di applicazione della ritenuta e successivamente si scrive
            // nel dataset il risultato del calcolo
            // Prima di operare con la tabella delle ritenute regionali, si valuta se ci sono delle eccezioni
            // su alcuni comuni la quale aliquota regionale è stata impostata in modo differente
            DateTime pubblPC, pubbl;
            DataRow[] rScaglPerComune = getTabellaScaglioniGeo(codiceRitenuta, imponibileAnnuo, dataprestazione,
                "taxrateregioncity", "idcity", idcomune, out pubblPC);

            object idProvincia = Conn.DO_READ_VALUE("geo_city", QHS.CmpEq("idcity", idcomune), "idcountry");
            object idRegione = Conn.DO_READ_VALUE("geo_country", QHS.CmpEq("idcountry", idProvincia), "idregion");

            if (idRegione != DBNull.Value) {
                DataRow[] rScagl = getTabellaScaglioniGeo(codiceRitenuta, imponibileAnnuo, dataprestazione,
                    "taxrateregion", "idregion", idRegione, out pubbl);

                if (pubblPC < pubbl) {
                    DataRow rCedRitenuta = calcolaRitenuteScaglionateGeografiche(idCedolino, codiceRitenuta,
                        rScagl, isConguaglio, null, idFiscalTaxRegion);
                    // J.T.R. 28.05.2008 - Non devo più sommare le addizionali da rateizzare, ora hanno un loro codice ritenuta
                    //if ((isConguaglio) && (importoAddizionaleRateizzata != 0)) {
                    //    aggiungiAddizionaleRateizzata(idCedolino, rCedRitenuta, importoAddizionaleRateizzata, codiceRitenuta);
                    //}
                    if (rCedRitenuta == null) return null;
                    return aggiungiRitenutaVersataAnnuaDaCud(rCedRitenuta, "R");
                }
            }
            DataRow rCedRitenuta2 = calcolaRitenuteScaglionateGeografiche(idCedolino, codiceRitenuta,
                rScaglPerComune, isConguaglio, null, idFiscalTaxRegion);
            // J.T.R. 28.05.2008 - Non devo più sommare le addizionali da rateizzare, ora hanno un loro codice ritenuta
            //if ((isConguaglio) && (importoAddizionaleRateizzata != 0)) {
            //    aggiungiAddizionaleRateizzata(idCedolino, rCedRitenuta2, importoAddizionaleRateizzata, codiceRitenuta);
            //}
            if (rCedRitenuta2 == null) return null;
            return aggiungiRitenutaVersataAnnuaDaCud(rCedRitenuta2, "R");
        }

        /// <summary>
        /// Crea una riga di cedolinoritenuta e relativa riga di cedolinoritenutascaglione per una ritenuta c/dip
        /// ad importo dato
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="ritDipendente">ritenuta c/dip</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="idCity">ID della città dalla quale si otterrà l'ente locale.
        /// I possibili valori sono: NULL per ritenute a carattere Nazionale
        /// NOT NULL: sia per indiciare un ente locale città, sia per indicare un ente locale Regione.
        /// Nel caso si voglia indicare una regione, bisogna sempre indicare la città</param>
        /// <returns></returns>
        private DataRow creaRigaCedolinoRitenuta(object idCedolino, decimal ritDipendente, object codiceRitenuta,
            object idCity, object idFiscalTaxRegion) {
            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRit = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
            rRit["taxcode"] = codiceRitenuta;
            rRit["adminrate"] = 0;
            rRit["employtaxgross"] = ritDipendente;
            rRit["admintax"] = 0;
            rRit["taxablenumerator"] = 1;
            rRit["taxabledenominator"] = 1;
            rRit["adminnumerator"] = 1;
            rRit["admindenominator"] = 1;
            rRit["employnumerator"] = 1;
            rRit["employdenominator"] = 1;
            if (idCity != null) rRit["idcity"] = idCity;
            if (idFiscalTaxRegion != null) rRit["idfiscaltaxregion"] = idFiscalTaxRegion;

            DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRit, DS.payrolltaxbracket);
            rScagl["taxable"] = 0;
            rScagl["employrate"] = 0;
            rScagl["employtax"] = ritDipendente;
            rScagl["adminrate"] = 0;
            rScagl["admintax"] = 0;

            return rRit;
        }

        // Calcola il numero di rate già pagate per una ritenuta.
        private int calcolaNumRateCafPagate(object idContratto, object codiceRitenuta, int annoFiscale,
            DateTime dataInizioCedolino) {
            string filtroCedolino = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpLt("start", dataInizioCedolino));
            string filtroRitenuta = QHC.AppAnd(QHC.CmpEq("taxcode", codiceRitenuta),
                QHC.FieldIn("idpayroll", DS.payroll.Select(filtroCedolino), "idpayroll"));
            DataRow[] rCedRit = DS.payrolltax.Select(filtroRitenuta);

            int n = rCedRit.Length;
            return n;
        }

        /// <summary>
        /// Metodo che calcola il totale delle rate già pagate per una ritenuta
        /// </summary>
        /// <param name="idContratto"></param>
        /// <param name="codiceRitenuta"></param>
        /// <param name="annoFiscale"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <returns></returns>
        private decimal calcolaRateCafGiaPagate(object idContratto, object codiceRitenuta, int annoFiscale,
            DateTime dataInizioCedolino) {
            string filtroCedolino = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpLt("start", dataInizioCedolino));
            string filtroRitenuta = QHC.AppAnd(QHC.CmpEq("taxcode", codiceRitenuta),
                QHC.FieldIn("idpayroll", DS.payroll.Select(filtroCedolino), "idpayroll"));
            DataRow[] rCedRit = DS.payrolltax.Select(filtroRitenuta);

            decimal importo = 0;
            for (int i = 0; i < rCedRit.Length; i++) {
                importo += CfgFn.GetNoNullDecimal(rCedRit[i]["employtax"]);
            }
            return importo;
        }

        /// <summary>
        /// Metodo che restituisce il numero di rate per il quale spalmare le ritenute da CAF
        /// </summary>
        /// <param name="idcontratto">ID del contratto sul quale controllare l'esistenza di ritenute da CAF</param>
        /// <param name="tipoRata">Tipo di rata da considerare - C: Rata ritenute CAF, P: Rata acconto IRPEF, S: Seconda Rata acconto IRPEF</param>
        /// <returns>Numero delle rate</returns>
        private int calcolaNumeroRate(object idContratto, string tipoRata, DateTime dataFineCedolino) {

            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpLe("docdate", dataFineCedolino));
            DataRow[] rComunicazioneDaCaf = DS.cafdocument.Select(filtro, "docdate");
            if (rComunicazioneDaCaf.Length == 0) return 0;
            string campo = "";
            // Si determina il campo da interrogare in merito al tipo di parametro di input passato
            switch (tipoRata) {
                case "P": {
                    campo = "nquotafirstinstalment";
                    break;
                }
                case "S": {
                    campo = "nquotasecondinstalment";
                    break;
                }
                default: {
                    campo = "ratequantity";
                    break;
                }
            }
            int numeroRate = 0;
            foreach (DataRow rCom in rComunicazioneDaCaf) {
                string tipoComunicazione = rCom["cafdocumentkind"].ToString().ToUpper();
                int numRateCorrente = CfgFn.GetNoNullInt32(rCom[campo]);
                // In base al tipo di comunicazione si determina una ulteriore formula
                // se la comunicazione è integrativa si somma se rettificativa si riparte da zero
                switch (tipoComunicazione) {
                    case "I": {
// Integrativa
                        if (numRateCorrente != 0) {
                            numeroRate = numRateCorrente;
                        }
                        break;
                    }
                    default: {
// Ordinaria e Rettificativa
                        numeroRate = numRateCorrente;
                        break;
                    }
                }
            }
            return numeroRate;
        }

        /// <summary>
        /// Metodo che calcola il numero di rate INAIL del contratto in oggetto
        /// </summary>
        /// <param name="idContratto"></param>
        /// <param name="inizioCompetenza"></param>
        /// <param name="fineCompetenza"></param>
        /// <returns></returns>
        private int calcolaNumeroRateINAIL(object idContratto, DateTime inizioCompetenza, DateTime fineCompetenza) {
            // Le rate INAIL sono calcolate tenendo conto dell'inizio e della fine competenza del contratto nell'anno corrente.
            // Giacché l'INAIL viene pagata per ogni mese lavorato, la decisione presa è quella di farla pagare tutta insieme
            // sul primo cedolino che abbraccia un mese.
            // Quando ci si trova a valutare contratti che hanno una data di inizio di competenza precedente
            // all'inizio dell'anno in corso, bisogna verificare che l'INAIL non sia stata già pagata nell'ultimo cedolino
            // dell'anno precedente. In tal caso, il numero di rate deve essere decrementato di una unità, perché il mese "in comune"
            // viene assegnato alla competenza dell'anno precedente e non a quella dell'anno in corso.
            int numeroRateINAIL = 1 + 12 * (fineCompetenza.Year - inizioCompetenza.Year) + fineCompetenza.Month -
                                  inizioCompetenza.Month;
            int esercizioprec = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")) - 1;

            // Per valutare quando sia terminato il contratto nell'anno precedente, si valuta la data di fine
            // del cedolino di conguaglio. Abbiamo scelto il cedolino di conguaglio in quanto le date dello stesso
            // vengono valorizzate mediante questa equazione:
            // Data di inizio Conguaglio = Data Inizio Primo cedolino dell'anno di competenza
            // Data di fine Conguaglio = Data Fine Ultimo cedolino dell'anno di competenza
            string filtroAnnoPrec = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("fiscalyear", esercizioprec),
                QHC.CmpEq("flagbalance", "S"));

            object ultimoGiornoCompetenzaAnnoPrecOBJ = Conn.DO_READ_VALUE("payroll", filtroAnnoPrec, "stop");
            DateTime ultimoGiornoCompetenzaAnnoPrec = DateTime.MinValue;
            if ((ultimoGiornoCompetenzaAnnoPrecOBJ != null) && (ultimoGiornoCompetenzaAnnoPrecOBJ != DBNull.Value)) {
                ultimoGiornoCompetenzaAnnoPrec = new DateTime(((DateTime) ultimoGiornoCompetenzaAnnoPrecOBJ).Year,
                    ((DateTime) ultimoGiornoCompetenzaAnnoPrecOBJ).Month, 1);
            }

            // Se la coppia mese/anno del cedolino di conguaglio dell'anno precedente coincide con la
            // coppia mese/anno della competenza corrente, decrementiamo di una unità il numero di rate INAIL.
            if ((ultimoGiornoCompetenzaAnnoPrec.Year == inizioCompetenza.Year)
                && (ultimoGiornoCompetenzaAnnoPrec.Month == inizioCompetenza.Month)) {
                numeroRateINAIL--;
            }
            return numeroRateINAIL;
        }

        /// <summary>
        /// Metodo che restituisce il mese di inizio dal quale iniziare a pagare le ritenute da CAF
        /// </summary>
        /// <param name="idContratto">ID del contratto sul quale controllare l'esistenza di ritenute da CAF</param>
        /// <param name="tipoRata">Tipo di rata da considerare - C: Rata ritenute CAF, P: Rata acconto IRPEF, S: Seconda Rata acconto IRPEF</param>
        /// <returns>Mese di inizio</returns>
        private int calcolaMeseInizio(object idContratto, string tipoRata, DateTime dataFineCedolino) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpLe("docdate", dataFineCedolino));
            DataRow[] rComunicazioneDaCaf = DS.cafdocument.Select(filtro, "docdate");
            if (rComunicazioneDaCaf.Length == 0) return 0;
            string campo = "";
            switch (tipoRata) {
                case "P": {
                    campo = "monthfirstinstalment";
                    break;
                }
                case "S": {
                    campo = "monthsecondinstalment";
                    break;
                }
                default: {
                    campo = "startmonth";
                    break;
                }
            }
            int meseInizio = 0;
            foreach (DataRow rCom in rComunicazioneDaCaf) {
                string tipoComunicazione = rCom["cafdocumentkind"].ToString().ToUpper();
                int meseInizioCorrente = CfgFn.GetNoNullInt32(rCom[campo]);
                // In base al tipo di comunicazione si determina una ulteriore formula
                // se la comunicazione è integrativa si somma se rettificativa si riparte da zero
                switch (tipoComunicazione) {
                    case "I": {
// Integrativa
                        if (meseInizioCorrente != 0) {
                            meseInizio = meseInizioCorrente;
                        }
                        break;
                    }
                    default: {
// Ordinaria e Rettificativa
                        meseInizio = meseInizioCorrente;
                        break;
                    }
                }
            }
            return meseInizio;
        }

        /// <summary>
        /// Metodo che restituisce l'importo della ritenuta presente nella comunicazione CAF
        /// </summary>
        /// <param name="codiceRitenuta">Codice della ritenuta sul quale restituire l'importo</param>
        /// <param name="idContratto">ID del contratto sul quale controllare l'esistenza di comunicazioni da CAF</param>
        /// <returns>Importo da pagare nel cedolino</returns>
        private decimal calcolaImportoRitenutaDaCaf(string taxref, object idContratto, DateTime dataFineCedolino,
            out object idGeo) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpLe("docdate", dataFineCedolino));
            DataRow[] rComunicazioneDaCaf = DS.cafdocument.Select(filtro, "docdate");
            idGeo = null;
            if (rComunicazioneDaCaf.Length == 0) return 0;
            decimal importo = 0;
            foreach (DataRow rCom in rComunicazioneDaCaf) {
                string tipoComunicazione = rCom["cafdocumentkind"].ToString().ToUpper();
                decimal formula = 0;
                string field = "";
                // In base al codice della ritenuta si definisce una formula
                switch (taxref) {
                    case "07_IRPEF_CAF": {
                        formula = CfgFn.GetNoNullDecimal(rCom["irpeftoretain"])
                                  - CfgFn.GetNoNullDecimal(rCom["irpeftorefund"]);
                        idGeo = null;
                        break;
                    }
                    case "07_IRPEF_R1": {
                        formula = CfgFn.GetNoNullDecimal(rCom["firstrateadvance"]);
                        idGeo = null;
                        break;
                    }
                    case "07_IRPEF_R2": {
                        formula = CfgFn.GetNoNullDecimal(rCom["secondrateadvance"]);
                        idGeo = null;
                        break;
                    }
                    case "07_TASSASEP": {
                        formula = CfgFn.GetNoNullDecimal(rCom["separatedincome"])
                                  + CfgFn.GetNoNullDecimal(rCom["separatedincomehusband"]);
                        idGeo = null;
                        break;
                    }
                    case "08_ACCADDCOMCAF": {
                        formula = CfgFn.GetNoNullDecimal(rCom["citytaxaccount"]) +
                                  CfgFn.GetNoNullDecimal(rCom["citytaxaccounthusband"]);
                        field = "idcity";
                        break;
                    }
                    case "07_ADDCOMCAF": {
                        formula = CfgFn.GetNoNullDecimal(rCom["citytaxtoretain"]) +
                                  CfgFn.GetNoNullDecimal(rCom["citytaxtoretainhusband"]) -
                                  CfgFn.GetNoNullDecimal(rCom["citytaxtorefund"]) -
                                  CfgFn.GetNoNullDecimal(rCom["citytaxtorefundhusband"]);
                        field = "idcity";
                        break;
                    }

                    case "07_ADDREGCAF": {
                        formula = CfgFn.GetNoNullDecimal(rCom["regionaltaxtoretain"]) +
                                  CfgFn.GetNoNullDecimal(rCom["regionaltaxtoretainhusband"]) -
                                  CfgFn.GetNoNullDecimal(rCom["regionaltaxtorefund"]) -
                                  CfgFn.GetNoNullDecimal(rCom["regionaltaxtorefundhusband"]);
                        field = "idfiscaltaxregion";
                        break;
                    }
                }
                // In base al tipo di comunicazione si determina una ulteriore formula
                // se la comunicazione è integrativa si somma se rettificativa si riparte da zero
                switch (tipoComunicazione) {
                    case "I": {
                        importo += formula;
                        if ((taxref == "07_ADDCOMCAF") || (taxref == "07_ADDREGCAF")
                            || (taxref == "08_ACCADDCOMCAF")) {
                            if ((idGeo == null) || (idGeo == DBNull.Value)) {
                                idGeo = rCom[field];
                            }
                        }
                        break;
                    }
                    default: {
                        importo = formula;
                        if ((taxref == "07_ADDCOMCAF") || (taxref == "07_ADDREGCAF")
                            || (taxref == "08_ACCADDCOMCAF")) {
                            idGeo = rCom[field];
                        }
                        break;
                    }
                }
            }
            return importo;
        }

        /// <summary>
        /// Calcola le ritenute fiscali (relativa all'anno precedente) da pagare 
        /// su indicazioni ricevute dal CAF
        /// </summary>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="codiceritenuta">id. del tipo di ritenuta</param>
        /// <param name="annofiscale">anno di esercizio</param>
        /// <param name="meseinizioratecaf">mese della prima rata</param>
        /// <param name="numeroratecaf">numero di rate da versare</param>
        /// <param name="meseinizioprimaratairpef">mese della prima rata irpef CAF</param>
        /// <param name="numerorateprimaratairpef">numero di rate della prima rata irpef CAF da versare</param>
        /// <param name="meseiniziosecondaratairpef">mese della seconda rata CAF</param>
        /// <param name="numeroratesecondaratairpef">numero di rate della seconda rata CAF</param>
        /// <returns></returns>
        private decimal calcolaArretratiCaf(
            DateTime dataInizioCedolino, DateTime dataFineCedolino, object idcontratto,
            object codiceritenuta, string taxref,
            int annofiscale, out object idCity, out object idFiscalTaxRegion) {

            idCity = null;
            idFiscalTaxRegion = null;

            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpLe("docdate", dataFineCedolino));
            DataRow[] rComCaf = DS.cafdocument.Select(filtro);
            if (rComCaf.Length == 0) {
                return 0;
            }

            int numeroRateCaf = calcolaNumeroRate(idcontratto, "C", dataFineCedolino);
            int meseInizioCaf = calcolaMeseInizio(idcontratto, "C", dataFineCedolino);
            int numeroRatePrimaRataIrpef = calcolaNumeroRate(idcontratto, "P", dataFineCedolino);
            int meseInizioPrimaRataIrpef = calcolaMeseInizio(idcontratto, "P", dataFineCedolino);
            int numeroRateSecondaRataIrpef = calcolaNumeroRate(idcontratto, "S", dataFineCedolino);
            int meseInizioSecondaRataIrpef = calcolaMeseInizio(idcontratto, "S", dataFineCedolino);

            int nRateCafInCedolino = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino, annofiscale,
                meseInizioCaf, numeroRateCaf, idcontratto);
            int nRatePrimaRataIrpefInCedolino = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino, annofiscale,
                meseInizioPrimaRataIrpef, numeroRatePrimaRataIrpef, idcontratto);
            int nRateSecondaRataIrpefInCedolino = getNumeroRateDaPagare(dataInizioCedolino, dataFineCedolino,
                annofiscale, meseInizioSecondaRataIrpef, numeroRateSecondaRataIrpef, idcontratto);

            // Calcola le rate già pagate per effettuare un conguaglio ad ogni cedolino
            decimal rateGiaPagate =
                calcolaRateCafGiaPagate(idcontratto, codiceritenuta, annofiscale, dataInizioCedolino);

            //Calcola il numero di rate già pagate
            int nRateCafPagate = calcolaNumRateCafPagate(idcontratto, codiceritenuta, annofiscale, dataInizioCedolino);
            int nRateDaPagare = numeroRateCaf - nRateCafPagate;


            if (nRateCafInCedolino > nRateDaPagare) {
                MessageBox.Show(
                    "Per il cedolino corrente risultano " + nRateCafInCedolino +
                    " rate da pagare, che è inferiore al numero totale rate da pagare (" +
                    nRateDaPagare + ") pertanto si assumerà che per il cedolino corrente ci sono " + nRateDaPagare +
                    " rate da pagare.", "Avviso");
                nRateCafInCedolino = nRateDaPagare;
            }
            object idGeo = null;
            // Calcolo dell'IRPEF da trattenere/rimborsare
            if ((nRateCafInCedolino > 0) && (taxref == "07_IRPEF_CAF")) {
                decimal irpef = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino, out idGeo);
                decimal irpefAncoraDaPagare = (irpef - rateGiaPagate) / nRateDaPagare;
                return nRateCafInCedolino * irpefAncoraDaPagare;
            }

            //Calcolo acconto su redditi a tassazione separata
            if ((nRateCafInCedolino > 0) && (taxref == "07_TASSASEP")) {
                decimal totRedditiTassazioneSeparata = calcolaImportoRitenutaDaCaf(taxref, idcontratto,
                    dataFineCedolino,
                    out idGeo);
                decimal totRedditiTassSepAncoraDaPagare =
                    (totRedditiTassazioneSeparata - rateGiaPagate) / nRateDaPagare;
                return nRateCafInCedolino * totRedditiTassSepAncoraDaPagare;
            }

            if (nRatePrimaRataIrpefInCedolino > numeroRatePrimaRataIrpef) {
                MessageBox.Show(
                    "Per il la prima rata irpef cedolino corrente risultano " + nRatePrimaRataIrpefInCedolino +
                    " rate irpef da pagare, che è inferiore al numero totale rate da pagare (" +
                    nRateDaPagare + ") pertanto si assumerà che per il cedolino corrente ci sono " +
                    numeroRatePrimaRataIrpef +
                    " rate da pagare.", "Avviso");
                nRatePrimaRataIrpefInCedolino = numeroRatePrimaRataIrpef;
            }
            //Calcolo della prima rata IRPEF
            if ((nRatePrimaRataIrpefInCedolino > 0) && (taxref == "07_IRPEF_R1")) {
                decimal primarataaccontoirpef = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino,
                    out idGeo);
                decimal primaRataAccontoIrpefDaPagare =
                    (primarataaccontoirpef - rateGiaPagate) / numeroRatePrimaRataIrpef;
                return nRatePrimaRataIrpefInCedolino * primaRataAccontoIrpefDaPagare;
            }

            if (nRateSecondaRataIrpefInCedolino > numeroRateSecondaRataIrpef) {
                MessageBox.Show(
                    "Per il la seconda rata irpef cedolino corrente risultano " + nRateSecondaRataIrpefInCedolino +
                    " rate irpef da pagare, che è inferiore al numero totale rate da pagare (" +
                    nRateDaPagare + ") pertanto si assumerà che per il cedolino corrente ci sono " +
                    numeroRateSecondaRataIrpef +
                    " rate da pagare.", "Avviso");
                nRateSecondaRataIrpefInCedolino = numeroRateSecondaRataIrpef;
            }
            //Calcolo della seconda rata IRPEF
            if ((nRateSecondaRataIrpefInCedolino > 0) && (taxref == "07_IRPEF_R2")) {
                decimal secondarataaccontoirpef = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino,
                    out idGeo);
                decimal secondaRataAccontoIrpefDaPagare =
                    (secondarataaccontoirpef - rateGiaPagate) / numeroRateSecondaRataIrpef;
                return nRateSecondaRataIrpefInCedolino * secondaRataAccontoIrpefDaPagare;
            }

            if ((nRateCafInCedolino > 0) && (taxref == "08_ACCADDCOMCAF")) {
                decimal accaddcom = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino, out idGeo);
                decimal accaddcomAncoraDaPagare = (accaddcom - rateGiaPagate) / nRateDaPagare;
                idCity = idGeo;
                return nRateCafInCedolino * accaddcomAncoraDaPagare;
            }

            if ((nRateCafInCedolino > 0) && (taxref == "07_ADDCOMCAF")) {
                decimal addcom = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino, out idGeo);
                decimal addcomAncoraDaPagare = (addcom - rateGiaPagate) / nRateDaPagare;
                idCity = idGeo;
                return nRateCafInCedolino * addcomAncoraDaPagare;
            }

            if ((nRateCafInCedolino > 0) && (taxref == "07_ADDREGCAF")) {
                decimal addreg = calcolaImportoRitenutaDaCaf(taxref, idcontratto, dataFineCedolino, out idGeo);
                decimal addregAncoraDaPagare = (addreg - rateGiaPagate) / nRateDaPagare;
                idFiscalTaxRegion = idGeo;
                return nRateCafInCedolino * addregAncoraDaPagare;
            }
            return 0;
        }

        /// <summary>
        /// Restituisce il primo parametro se è diverso da DBNull.Value
        /// Restituisce il secondo parametro se il primo è uguale a DBNull.Value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private object isnull(object a, object b) {
            return a is DBNull ? b : a;
        }

        /// <summary>
        /// Riempie i campi di cedolinoritenuta tendendo conto delle quote c/dip e c/amm della ritenuta
        /// </summary>
        /// <param name="rRit">riga di tiporitenuta</param>
        /// <param name="rAliquota">riga della tabella delle aliquote</param>
        /// <param name="isConguaglio">true se si tratta di un conguaglio</param>
        /// <param name="imponibileNetto">imponibile sul quale si sta applicando la ritenuta</param>
        /// <param name="ritAmministrazione">ritenuta c/amm</param>
        /// <param name="ritDipendente">ritenuta c/dip</param>
        private void riempiRitenutaConQuote(
            //decimal imponibileNonRapportato,
            object taxableNumerator,
            object taxableDenominator,
            DataRow rRit,
            DataRow rBracket,
            bool isConguaglio,
            decimal imponibileNetto,
            decimal ritAmministrazione,
            decimal ritDipendente,
            decimal ritAmministrazioneFrazionata,
            decimal ritDipendenteFrazionata) {

            decimal rapporto = getRapporto(taxableNumerator, taxableDenominator);
            if (imponibileNetto != 0) {
                rRit["adminrate"] = CfgFn.Round(ritAmministrazione / (imponibileNetto), 6);
                rRit["employrate"] = CfgFn.Round(ritDipendente / (imponibileNetto), 6);
            }

            rRit["taxablenet"] = imponibileNetto;
            rRit["admindenominator"] = rBracket["admindenominator"];
            rRit["employdenominator"] = rBracket["employdenominator"];
            rRit["taxabledenominator"] = taxableDenominator;
            rRit["adminnumerator"] = rBracket["adminnumerator"];
            rRit["employnumerator"] = rBracket["employnumerator"];
            rRit["taxablenumerator"] = taxableNumerator;
            rRit["admintax"] = ritAmministrazioneFrazionata;
            rRit["employtaxgross"] = ritDipendenteFrazionata;
        }

        /// <summary>
        /// Calcola la ritenuta inail per il contratto in corso a partire da meseinizio fino a mesefine 
        /// </summary>
        /// <param name="compensoLordoCedolino">Compenso Lordo del Cedolino sul quale calcolare l'INAIL</param>
        /// <param name="imponibilelordomensile">compenso medio mensile per quest'anno</param>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="idContratto">id. del contratto</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <param name="idpat">id. della posizione assicurativa territoriale</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <returns></returns>
        public DataRow calcola_ritenuta_inail(
            decimal compensoLordoCedolino,
            decimal imponibilelordomensile,
            object idCedolino,
            object idContratto,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            int idpat,
            object codiceRitenuta
        ) {
            // Se il cedolino ha importo pari a zero non calcolo l'INAIL
            if (compensoLordoCedolino == 0) return null;
            // Caso in cui ho già pagato l'INAIL del mese in corso nel cedolino precedente
            if (imponibilelordomensile == 0) return null;
            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRit = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
            rRit["taxcode"] = codiceRitenuta;
            // 27.09.2005 Il ciclo sottostante viene cambiato in quanto non ha senso calcolare il rateo dell'INAIL
            // mese per mese. Una volta conosciuto l'imponibile assistenziale viene applicata l'aliquota determinata
            // dalla PAT.
            // Se il cedolino non ricade nel periodo di validità della PAT non avviene il calcolo dello stesso.
            string filtroPat = QHC.CmpEq("idpat", idpat);
            DataRow[] pat = DS.pat.Select(filtroPat);
            if (pat.Length == 0) return null;
            decimal imponibileNonRapportato = imponibilelordomensile;
            decimal frazioneImponibile = getRapporto(pat[0]["taxablenumerator"], pat[0]["taxabledenominator"]);
            decimal imponibileRapportato = imponibileNonRapportato * frazioneImponibile;
            decimal ritDipendente = imponibileRapportato * CfgFn.GetNoNullDecimal(pat[0]["employrate"]);
            decimal ritAmministrazione = imponibileRapportato * CfgFn.GetNoNullDecimal(pat[0]["adminrate"]);
            DataRow rAliquotaScaglione = pat[0];

            decimal frazioneAmministrazione = getRapporto(pat[0]["adminnumerator"], pat[0]["admindenominator"]);
            decimal frazioneDipendente = getRapporto(pat[0]["employnumerator"], pat[0]["employdenominator"]);
            decimal ritamm = frazioneAmministrazione * ritAmministrazione;
            decimal ritdip = frazioneDipendente * ritDipendente;
            decimal ritAmmFrazionata = CfgFn.RoundValuta(ritamm);
            decimal ritDipFrazionata = CfgFn.RoundValuta(ritdip);

            rRit["adminrate"] = rAliquotaScaglione["adminrate"];
            rRit["employrate"] = rAliquotaScaglione["employrate"];

            DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRit, DS.payrolltaxbracket);
            rScagl["adminrate"] = rAliquotaScaglione["adminrate"];
            rScagl["employrate"] = rAliquotaScaglione["employrate"];
            rScagl["taxable"] = imponibileRapportato;
            rScagl["admintax"] = ritAmmFrazionata;
            rScagl["employtax"] = ritDipFrazionata;

            decimal taxableNumerator =
                pat[0]["taxablenumerator"] == DBNull.Value ? 1 : (decimal) pat[0]["taxablenumerator"];
            decimal taxableDenominator = pat[0]["taxabledenominator"] == DBNull.Value
                ? 1
                : (decimal) pat[0]["taxabledenominator"];
            riempiRitenutaConQuote(taxableNumerator, taxableDenominator,
                rRit, pat[0], false, imponibileRapportato,
                ritAmministrazione, ritDipendente, ritAmmFrazionata, ritDipFrazionata);

            rRit["employtaxgross"] = CfgFn.RoundValuta((decimal) rRit["employtaxgross"]);
            return rRit;
        }

        /// <summary>
        /// Calcola la ritenuta INPS.
        /// La ritenuta INPS tiene conto dei compensi lordi degli altri cedolini già pagati,
        /// dell'imponibile previdenziale di eventuali CUD presentati e, se quest'ultimi non sono stati 
        /// presentati, tiene conto della stima dell'imponibile inserita nel contratto
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="dataInizioCedolino">primo giorno di competenza del cedolino</param>
        /// <param name="idContratto">id. del contratto</param>
        /// <param name="annoFiscale">anno di emissione del cedolino</param>
        /// <param name="imponibileCorrente">imponibile previdenziale</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <returns>ritenuta inps</returns>
        public DataRow calcola_ritenuta_inps(
            object idCedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            object idContratto, int annoFiscale,
            decimal imponibileCorrente,
            object codiceRitenuta
        ) {
            string filtro = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpLt("start", dataInizioCedolino),
                QHC.CmpEq("flagbalance", "N"));

            // Si ottiene l'elenco degli altri cedolini rata per determinare l'imponibile pregresso
            DataRow[] altriCedolini = DS.payroll.Select(filtro);
            decimal imponibileOLD = 0;
            foreach (DataRow r in altriCedolini) {
                imponibileOLD += CfgFn.GetNoNullDecimal(r["feegross"]);
            }
            // Si calcola l'imponibile dei CUD
            string filtroCud = QHC.AppAnd(QHC.CmpEq("idcon", idContratto), QHC.CmpEq("fiscalyear", annoFiscale));

            DataRow[] cudPresentati = DS.exhibitedcud.Select(filtroCud, "idexhibitedcud");
            decimal imponibileCud = 0;
            foreach (DataRow rCud in cudPresentati) {
                if (rCud["flagignoreprevcud"].ToString().ToUpper() == "S") {
                    imponibileCud = CfgFn.GetNoNullDecimal(rCud["taxablepension"]);
                }
                else {
                    imponibileCud += CfgFn.GetNoNullDecimal(rCud["taxablepension"]);
                }
            }
            // L'imponibile pregresso sarà quindi la somma tra quello detreminato dai cedolini e quello del CUD
            imponibileOLD += imponibileCud;

            // Si chiama il metodo che determina la ritenuta scaglionata passando come parametro l'imponibile pregresso
            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            object taxableNumerator, taxableDenominator;
            DataRow[] scaglioni = getTabellaScaglioni(codiceRitenuta, imponibileOLD, imponibileCorrente, dataContabile,
                out taxableNumerator, out taxableDenominator);
            return calcolaRitenutaScaglionata( //imponibileCorrente - imponibileOLD, 
                taxableNumerator, taxableDenominator,
                idCedolino, scaglioni, codiceRitenuta, 1, 1);
        }

        public DataRow calcola_bonus_fiscale_2014(
            object idCedolino,
            string natura,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            object idContratto, int annoFiscale,
            decimal imponibileCorrente,
            object codiceRitenuta
        ) {
            // Valutiamo se si è deciso di non applicare il Bonus al Contratto nell'anno fiscale in corso
            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idContratto))[0];
            string applicazioneBonus = rImputContr["flagbonusappliance"].ToString();

            if (applicazioneBonus == "N") return null;

            DataRow rContr = DS.parasubcontract.Select(QHC.CmpEq("idcon", idContratto))[0];
            object idSer = rContr["idser"];
            // Condizione applicabilità  1): Reddito complessivo annuo al netto delle ritenute previdenziali e assistenziali < maxAnnualTaxable
            // Al fine del calcolo del Reddito complessivo annuo non consideriamo le deduzioni inerenti la rendita catastale dell'abitazione principale, 
            // sebbene previsto dal decreto, in quanto in Easy non gestiamo
            // redditi di natura diversa  dai redditi da lavoro  
            decimal RedditoComplessivo;
            RedditoComplessivo = calcola_imponibile_bonus_fiscale_2014(idCedolino, natura, idContratto, annoFiscale);
            // Vado avanti onde gestire eventuali restituzioni di bonus già erogati, nonostante il requisito di applicabilità
            // del reddito non sia rispettato
            // if (RedditoComplessivo > maxAnnualTaxable) return null;   

            // Condizione applicabilità  2): Ritenuta IRPEF al netto delle sole detrazioni per reddito da lavoro dipendente  > 0

            bool applicaIrpef = verifica_capienza_bonus_fiscale(idSer, idCedolino, idContratto, natura, annoFiscale);
            // Vado avanti onde gestire eventuali restituzioni di bonus già erogati, nonostante il requisito di applicabilità
            // del reddito non sia rispettato

            // if (!applicaIrpef) return null;commento

            decimal bonus_teorico_annuo = calcola_bonus_teorico_annuo(RedditoComplessivo);

            // Calcolo cedolino di conguaglio dell'anno fiscale corrente

            DataRow[] rCedolinoConguaglio = DS.payroll.Select(QHC.AppAnd(QHC.CmpEq("idcon", rImputContr["idcon"]),
                QHC.CmpEq("fiscalyear", annoFiscale),
                QHC.CmpEq("flagbalance", "S")));

            if (rCedolinoConguaglio.Length == 0) return null;
            // Per la competenza consideriamo inizio e fine del cedolino di conguaglio dell'anno fiscale corrente
            DateTime datainiziocompetenza = (DateTime) rCedolinoConguaglio[0]["start"];
            DateTime datafinecompetenza = (DateTime) rCedolinoConguaglio[0]["stop"];

            // Stima dei giorni lavorati nell'anno ai fini del calcolo del bonus totale spettante: 
            // durata in giorni del contratto nell'esercizio corrente + 
            // giorni lavorati eventuali CUD da rapporti di lavoro precedenti (non solo in fase conguaglio ma sempre)
            // Per calcolare esattamente i giorni lavorati in qualsiasi cedolino. Per i CUD sovrapposti i giorni in comune 
            // si conteggiano una sola volta
            DateTime emptyDate = QueryCreator.EmptyDate();

            int ggLavoratiAnno = calcolaTotGiorniLavoratiBonus(annoFiscale, rImputContr["idcon"], "S", 
                datainiziocompetenza, datafinecompetenza);

            // Si calcolano i giorni di lavoro del presente contratto
            int totggLavoroContratto = 1 + (datafinecompetenza - datainiziocompetenza).Days;
            int giorniAnnoSolare = DateTime.IsLeapYear(annoFiscale) ? 366 : 365;
            if (totggLavoroContratto > giorniAnnoSolare) totggLavoroContratto = giorniAnnoSolare;

            // Si calcolano i giorni lavorati effettivamente solo per il presente contratto fino alla data odierna, ovvero
            // dalla data inizio contratto fino al giorno precedente l'inizio di questo cedolino, nell'anno Fiscale
            int ggLavoratiContratto = 0;

            DateTime datafineUltimoCedolinoPrecedente = emptyDate;
            datafineUltimoCedolinoPrecedente = dataInizioCedolino.AddDays(-1);

            if (datafineUltimoCedolinoPrecedente > datainiziocompetenza)
                ggLavoratiContratto = 1 + (datafineUltimoCedolinoPrecedente - datainiziocompetenza).Days;

            // Si calcolano i giorni del Cedolino, su di essi andrà ripartito il Bonus Residuo
            int ggCedolino = 0;
            ggCedolino = 1 + (dataFineCedolino - dataInizioCedolino).Days;

            // Bonus effettivo spettante, proporzionato alla stima dei giorni di lavoro nell'anno sui 365, inclusi eventuali CUD inseriti
            decimal bonus_effettivo_spettante =
                calcola_bonus_effettivo_annuo(bonus_teorico_annuo, annoFiscale, ggLavoratiAnno);
            // A questo punto calcoliamo il Bonus da applicare al presente cedolino. Si deve tenere conto dei Bonus già
            // erogati nel corso dell'anno fiscale, il residuo va ripartito tra i cedolini ancora da erogare.
            // Nota: a tale scopo il periodo del presente cedolino in elaborazione deve essere computato tra i giorni ancora da lavorare

            // Calcoliamo il Bonus già erogato nei precedenti cedolini calcolati così come nei CUD precedenti presentati dal lavoratore
            decimal bonus_erogati_in_cedolini =
                calcola_bonus_erogato_annuo(idContratto, annoFiscale, dataInizioCedolino);
            decimal bonus_erogati_in_cud = somma_bonus_erogati_cud(annoFiscale, idContratto); // credito applicato

            // E il Bonus residuo spettante per differenza
            decimal bonus_residuo = bonus_effettivo_spettante - bonus_erogati_in_cedolini - bonus_erogati_in_cud;

            if (((!applicaIrpef) || (RedditoComplessivo > maxAnnualTaxable)) && (bonus_residuo > 0)) return null;
            // Il Bonus Residuo va ripartito in proporzione sui giorni di lavoro che rimangono nel presente contratto fino a fine anno per 
            // ottenere l'importo da accreditare sul presente cedolino, incluso il periodo di lavoro del cedolino stesso
            decimal bonus_cedolino = calcola_bonus_spettante_cedolino(bonus_residuo, natura,
                ggCedolino,
                totggLavoroContratto, ggLavoratiContratto, annoFiscale);
            //if (!(bonus_cedolino==0))
            creaRitenutaBonusFiscale(idCedolino, bonus_erogati_in_cud, bonus_cedolino, codiceRitenuta, natura);

            return null;
        }

        private void ricalcolaPeriodoInAnnoFiscale(DateTime start, DateTime stop, int annoFiscale,
            out DateTime newstart, out DateTime newstop) {
            newstart = start;
            newstop = stop;

            if ((start.Year < annoFiscale) && (stop.Year < annoFiscale)) {
                newstart = QueryCreator.EmptyDate();
                newstop = QueryCreator.EmptyDate();
            }


            if ((start.Year > annoFiscale) && (stop.Year > annoFiscale)) {
                newstart = QueryCreator.EmptyDate();
                newstop = QueryCreator.EmptyDate();
            }

            if ((start.Year < annoFiscale) && (stop.Year > annoFiscale)) {
                newstart = new DateTime(annoFiscale, 1, 1);
                newstop = new DateTime(annoFiscale, 12, 31);
            }


            if ((start.Year < annoFiscale) && (stop.Year == annoFiscale)) {
                newstart = new DateTime(annoFiscale, 1, 1);
            }


            if ((start.Year == annoFiscale) && (stop.Year > annoFiscale)) {
                newstop = new DateTime(annoFiscale, 12, 31);
            }

        }

        /// <summary>
        /// Restituisce un filtro del tipo (A=a and B=b and C=c and...)
        /// dove A,B,C,... sono contenuti in nomiColonne
        /// e a,b,c,... sono le n-ple di valori distinti contenuti nelle colonne A,B,C,... delle righe date
        /// </summary>
        /// <param name="righe">righe</param>
        /// <param name="nomiColonne">nomi delle colonne di cui si vuole costruire il filtro</param>
        /// <param name="sql">true se si vuole costruire una query per il DB; false per il dataset</param>
        /// <returns></returns>
        private string columnValues(DataRow[] righe, string[] nomiColonne, bool sql) {
            string result = "";
            QueryHelper QH = sql ? QHS : QHC;
            foreach (DataRow r in righe) {
                result = QH.AppOr(result, QH.CmpMulti(r, nomiColonne));
            }
            return result;
        }

        /// <summary>
        /// Restituisce la ritenuta IRPEF di conguaglio annuale
        /// </summary>
        /// <param name="idCedolino">ID del Cedolino di Conguaglio</param>
        /// <param name="progrCedolino">Progressivo del Cedolino di Conguaglio</param>
        /// <param name="idContratto">ID del Contratto</param>
        /// <param name="annoFiscale">Anno di cui si vuole fare il conguaglio IRPEF</param>
        /// <param name="codiceRitenuta">Codice della Ritenuta</param>
        /// <param name="imponibileAnnuo">Imponibile IRPEF già dedotto</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns>ritenuta irpef di conguaglio</returns>
        public DataRow conguaglioFiscale(object idCedolino, object progrCedolino, object idContratto, int annoFiscale,
            object codiceRitenuta, decimal imponibileAnnuo, decimal maggioreRitenuta) {

            decimal totRitDipLorda = 0;
            decimal totImponib = 0;

            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");

            object taxableNumerator, taxableDenominator;
            DataRow[] scaglioni = getTabellaScaglioni(codiceRitenuta, 0, imponibileAnnuo, dataContabile,
                out taxableNumerator, out taxableDenominator);

            DataRow rCedolino = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
            DataRow rRit;


            if (maggioreRitenuta > 0) {
                rRit = creaRitenutaConAliquotaPrefissata(idCedolino, imponibileAnnuo, maggioreRitenuta, codiceRitenuta,
                    taxableNumerator, taxableDenominator);

            }
            else {
                rRit = MetaCedolinoRitenuta.Get_New_Row(rCedolino, DS.payrolltax);
                // Per ogni scaglione della ritenuta si crea una nuova riga in payrolltaxbracket
                foreach (DataRow r in scaglioni) {
                    decimal imponibile =
                        CfgFn.GetNoNullDecimal(r["maxamount"]) - CfgFn.GetNoNullDecimal(r["minamount"]);
                    decimal aliquotaDipendente = CfgFn.GetNoNullDecimal(r["employrate"]);
                    decimal ritDipLorda = imponibile * aliquotaDipendente;
                    totImponib += imponibile;
                    totRitDipLorda += ritDipLorda;

                    DataRow rScagl = MetaCedolinoRitenutaScaglione.Get_New_Row(rRit, DS.payrolltaxbracket);
                    rScagl["taxable"] = imponibile;
                    rScagl["employrate"] = aliquotaDipendente;
                    rScagl["employtax"] = CfgFn.RoundValuta(ritDipLorda);
                    rScagl["admintax"] = 0;
                }
                // Si crea anche una riga in payrolltax
                rRit["taxcode"] = codiceRitenuta;
                rRit["taxablenumerator"] = taxableNumerator;
                rRit["taxabledenominator"] = taxableDenominator;
                decimal rapporto = getRapporto(taxableNumerator, taxableDenominator);
                rRit["taxablenet"] = totImponib;
                if (totImponib != 0) {
                    rRit["employrate"] = CfgFn.Round(totRitDipLorda / (totImponib), 6);
                }
                rRit["adminrate"] = 0;
                rRit["employtax"] = CfgFn.RoundValuta(totRitDipLorda);
                rRit["employtaxgross"] = CfgFn.RoundValuta(totRitDipLorda);
                rRit["admintax"] = 0;
                rRit["annualpayedemploytax"] = 0;
            }
            return aggiungiRitenutaVersataAnnuaDaCud(rRit, null);
        }

        /// <summary>
        /// Calcola una ritenuta non INPS, non INAIL e non ADDIZ.
        /// (a scaglioni e senza storico della ritenuta già versata)
        /// </summary>
        /// <param name="idCedolino">id. del cedolino</param>
        /// <param name="codiceRitenuta">id. del tipo di ritenuta</param>
        /// <param name="imponibileNetto">imponibile già dedotto sul quale applicare la ritenuta</param>
        /// <param name="frazioneDiAnno">rapporto tra periodo di competenza e durata dell'anno</param>
        /// <param name="dataFineCedolino">ultimo giorno di competenza del cedolino</param>
        /// <returns></returns>
        public DataRow calcola_ritenuta_generica(object idCedolino, object codiceRitenuta,
            decimal imponibileNettoNonRapportato,
            DateTime dataFineCedolino,
            decimal numeratoreAnno, decimal denominatoreAnno) {
            decimal imponibileAnnuoNonRapportato = imponibileNettoNonRapportato / numeratoreAnno * denominatoreAnno;
            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            object taxableNumerator, taxableDenominator;
            DataRow[] scaglioni = getTabellaScaglioni(codiceRitenuta, 0, imponibileAnnuoNonRapportato, dataContabile,
                out taxableNumerator, out taxableDenominator);
            return calcolaRitenutaScaglionata( //imponibileAnnuoNonRapportato, 
                taxableNumerator, taxableDenominator,
                idCedolino, scaglioni, codiceRitenuta, numeratoreAnno, denominatoreAnno);
        }

        #endregion

        #region detrazioni

        /// <summary>
        /// Calcola la somma delle detrazioni da applicare ad una ritenuta
        /// </summary>
        /// <param name="rCedolino">riga della tabella cedolino</param>
        /// <param name="rCedolinoRitenuta">riga della tabella cedolinoritenuta</param>
        /// <returns></returns>
        public decimal calcolaDetrazioniPerUnaRitenuta(
            DataRow rCedolino,
            DataRow rCedolinoRitenuta,
            decimal imponibileNetto
        ) {
            // Sezione di recupero dati per usi successivi
            object idcontratto = rCedolino["idcon"];
            DateTime dataInizioCedolino = (DateTime) rCedolino["start"];
            DateTime dataFineCedolino = (DateTime) rCedolino["stop"];
            int giorniCedolino = CfgFn.GetNoNullInt32(rCedolino["workingdays"]);
            string natura = rCedolino["flagbalance"].ToString() == "S" ? "C" : "R";
            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S" ? true : false;
            int annoFiscale = CfgFn.GetNoNullInt32(rCedolino["fiscalyear"]);
            object idCedolino = rCedolino["idpayroll"];

            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idcontratto))[0];
            string applicazioneDetrazione = rImputContr["notaxappliance"].ToString();
            DateTime datainiziocompetenza = (DateTime) rImputContr["startcompetency"];
            DateTime datafinecompetenza = (DateTime) rImputContr["stopcompetency"];

            decimal importoritenuta = (natura == "R")
                ? CfgFn.GetNoNullDecimal(rCedolinoRitenuta["employtaxgross"])
                : CfgFn.GetNoNullDecimal(rCedolinoRitenuta["employtaxgross"]) -
                  CfgFn.GetNoNullDecimal(rCedolinoRitenuta["annualpayedemploytax"]);
            object codiceritenuta = rCedolinoRitenuta["taxcode"];

            DataRow[] rCedAnno =
                DS.payroll.Select(QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("flagbalance", "N")));
            int duratainmesi = rCedAnno.Length;
            // Fine sezione recupero dati

            //Le detrazioni sono considerate in base alla data fine del cedolino
            string filterdetrazioni = QHC.AppAnd(QHC.FieldIn("idabatement", DS.abatementcode.Select(), "idabatement"),
                QHC.CmpEq("taxcode", codiceritenuta), QHC.NullOrLe("validitystart", dataFineCedolino),
                QHC.NullOrGe("validitystop", dataFineCedolino));

            DataRow[] Detrazioni = DS.abatement.Select(filterdetrazioni);
            decimal totaledetrazioni = 0;
            // Per ogni tipo detrazione viene chiamato il metodo corrispondente che effettuerà il calcolo
            foreach (DataRow TempDetraz in Detrazioni) {
                string spcalcolo = TempDetraz["evaluatesp"].ToString();
                object iddetrazione = TempDetraz["idabatement"];
                // Si determinano franchigia, massimale e aliquota della detrazione corrente
                DataRow rDetrazione = DS.abatementcode.Select(QHC.CmpEq("idabatement", iddetrazione))[0];
                decimal franchigia = CfgFn.GetNoNullDecimal(rDetrazione["exemption"]);
                decimal aliquota = CfgFn.GetNoNullDecimal(rDetrazione["rate"]);

                decimal detrazionecorr = 0, detrazioneAnnua = 0;

                switch (spcalcolo) {
                    case "calcola_detrazione_generica_2004":
                        detrazionecorr = calcola_detrazione_generica_2004(iddetrazione,
                            natura, duratainmesi, idcontratto, franchigia, aliquota, rDetrazione["maximal"],
                            out detrazioneAnnua);
                        break;
                    case "calcola_detrazione_familiari":
                        detrazionecorr = calcola_detrazione_familiari(isConguaglio, idcontratto, natura, annoFiscale,
                            giorniCedolino, dataInizioCedolino,
                            dataFineCedolino, imponibileNetto, idCedolino,
                            out detrazioneAnnua);
                        break;
                    case "calcola_detrazione_reddito":
                        detrazionecorr = calcola_detrazione_reddito(imponibileNetto, idcontratto, natura, annoFiscale,
                            giorniCedolino, dataInizioCedolino, dataFineCedolino,
                            applicazioneDetrazione, out detrazioneAnnua);
                        break;
                    default:
                        MessageBox.Show("Errore interno - non trovata la spcalcolo " + spcalcolo);
                        break;
                }
                detrazionecorr = CfgFn.Round(detrazionecorr, 2);
                // Si verifica che la detrazione non superi la ritenuta lorda.
                // La legge consente l'applicazione delle detrazioni sino a concorrenza.
                if ((totaledetrazioni + detrazionecorr) > importoritenuta) {
                    detrazionecorr = importoritenuta - totaledetrazioni;
                }
                // Se la detrazione è positiva si scrive una riga in payrollabatement
                if (detrazionecorr > 0) {
                    MetaData.SetDefault(DS.Tables["payrollabatement"], "idabatement", iddetrazione);
                    DataRow Detraz =
                        MetaDettaglioDetrazioneCedolino.Get_New_Row(rCedolino, DS.Tables["payrollabatement"]);
                    Detraz["taxcode"] = codiceritenuta;
                    Detraz["annualamount"] = CfgFn.GetNoNullDecimal(detrazioneAnnua);
                    Detraz["curramount"] = detrazionecorr;
                }
                totaledetrazioni += detrazionecorr;
                if (totaledetrazioni >= importoritenuta)
                    break;

            }
            return totaledetrazioni;
        }


        public bool verifica_capienza_bonus_fiscale(
            object idSer, object idCedolino, object idContratto, string natura, int annoFiscale
        ) {
            decimal importoIrpef = 0;
            // La valutazione del Requisito della capienza ai fini IRPEF la faremo cedolino per cedolino, se siamo in un Cedolino Rata
            // Valuta l'importo della Ritenuta IRPEF al netto delle detrazioni per Reddito  
            // Invece se siamo nel Cedolino di Conguaglio faremo una valutazione globale dei Cedolini erogati nell'anno Fiscale
            string filterRitenutaFiscale = QHC.AppAnd(QHS.CmpEq("idser", idSer), QHS.CmpEq("idser", idSer),
                QHS.CmpEq("taxablecode", "IRPEF"),
                QHS.IsNull("geoappliance"), QHS.CmpEq("taxkind", 1));
            object taxcode = Conn.DO_READ_VALUE("servicetaxview", filterRitenutaFiscale, "taxcode");
            object idabatement = Conn.DO_READ_VALUE("abatement", QHS.CmpEq("description", "Detrazioni per reddito"),
                "idabatement");
            string filterPayrollList = null;
            string filterRitenute = null;

            filterPayrollList = QHC.CmpEq("idpayroll", idCedolino);
            /*}
                else
            {
                DataRow[] RCedolini = CalcolaCedoliniRataNellAnno(Conn, idContratto, annoFiscale);
                string list = "";
                foreach (DataRow RCed in RCedolini)
                {
                    list += QHC.List(RCed["idpayroll"]);
                }

                filterPayrollList = QHC.FieldInList("idpayroll", list); 
            }*/

            filterRitenute = QHC.AppAnd(filterPayrollList, QHS.CmpEq("taxcode", taxcode));

            DataRow[] rCedRit = DS.payrolltax.Select(filterRitenute);
            decimal sommaRitFiscali = 0;
            decimal sommaDetrReddito = 0;
            foreach (DataRow r in rCedRit) {
                sommaRitFiscali += CfgFn.GetNoNullDecimal(r["employtaxgross"]);
                string filterDetrCed = QHC.AppAnd(QHC.CmpEq("idpayroll", r["idpayroll"]),
                    QHC.CmpEq("taxcode", r["taxcode"]),
                    QHC.CmpEq("idabatement", idabatement));
                DataRow[] rDetrCed = DS.payrollabatement.Select(filterDetrCed);
                foreach (DataRow d in rDetrCed) {
                    sommaDetrReddito += CfgFn.GetNoNullDecimal(d["curramount"]);
                }
            }

            // Importo Ritenute Fiscali nel presente cedolino al netto delle sole detrazioni per Reddito    
            importoIrpef = sommaRitFiscali - sommaDetrReddito;

            // Se siamo in fase di conguaglio, facciamo anche una valutazione del requisito della capienza nei CUD
            if (natura == "C") {
                decimal importoIrpefCud = calcolaCapienzaIrpefInCud(annoFiscale, idContratto);
                importoIrpef += importoIrpefCud;
            }
            return (importoIrpef > 0);
        }

        //TODO: eliminare il parametro natura (nel cedolino di conguaglio non si calcolano le detrazioni)
        //TODO: filtrare cudpresentato anche per annofiscale

        /// <summary>
        /// Calcola gli oneri detraibili di un dato tipo di detrazione
        /// </summary>
        /// <param name="iddetrazione">id. della detrazione</param>
        /// <param name="natura"></param>
        /// <param name="duratainmesi">mesi lavorati nell'anno fiscale per questo contratto</param>
        /// <param name="idcontratto">id. del contratto</param>
        /// <param name="franchigia">codicedetrazione.franchigia</param>
        /// <param name="aliquota">codicedetrazione.aliquota</param>
        /// <param name="massimale">codicedetrazione.massimale</param>
        /// <param name="importo_annuo">importo annuale della detrazione applicabile</param>
        /// <returns></returns>
        public decimal calcola_detrazione_generica_2004(
            object iddetrazione,
            string natura,
            int duratainmesi,
            object idcontratto,
            decimal franchigia,
            decimal aliquota,
            object massimale,
            out decimal importo_annuo
        ) {
            importo_annuo = 0;
            decimal importo_annuo_netto = 0;
            string filtroDetrazioni = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto),
                QHC.CmpEq("idabatement", iddetrazione));
            //calcola l'importo complessivo da detrarre nell'anno in corso

            // se siamo in un cedolino rata e non vi sono oneri assocaiati al tipo detrazione nel contratto corrente
            // il metodo termina ritornando zero
            DataRow[] rOnereDetr = DS.abatableexpense.Select(filtroDetrazioni);
            if ((rOnereDetr.Length == 0) && (natura == "R")) {
                return 0;
            }
            // si considera l'importo dell'onere
            decimal onere_contratto = (rOnereDetr.Length > 0)
                ? CfgFn.GetNoNullDecimal(rOnereDetr[0]["totalamount"])
                : 0;

            // se siamo in un cedolino rata l'importo è confrontato con massimale, si sottrae la franchigia e si applica l'aliquota
            if (natura == "R") {
                if ((massimale != DBNull.Value) && (onere_contratto > (decimal) massimale)) {
                    onere_contratto = (decimal) massimale;
                }
                importo_annuo = onere_contratto * aliquota;
                importo_annuo_netto = (onere_contratto - franchigia) * aliquota;
                if (importo_annuo_netto < 0) {
                    importo_annuo_netto = 0;
                }
                decimal importo_corrente = importo_annuo_netto / @duratainmesi;
                return importo_corrente;
            }
            if (onere_contratto == 0) {
                // Non è prevista questa detrazione per il percipiente
                return 0;
            }

            // Adesso devo calcolare le detrazioni altri cud
            string filtroCud = QueryCreator.ColumnValues(DS.exhibitedcud, QHC.CmpEq("idcon", idcontratto),
                "idexhibitedcud", false);
            DataRow[] rDetrCud = (filtroCud == "")
                ? new DataRow[0]
                : DS.exhibitedcudabatement.Select(QHC.AppAnd(QHC.FieldIn("idexhibitedcud",
                        DS.exhibitedcud.Select(QHC.CmpEq("idcon", idcontratto))),
                    QHC.CmpEq("idabatement", iddetrazione)), "idexhibitedcud");

            decimal detrazionialtricud = 0;
            foreach (DataRow r in rDetrCud) {
                string cud = QHC.CmpEq("idexhibitedcud", r["idexhibitedcud"]);
                DataRow rCud = DS.exhibitedcud.Select(cud)[0];
                if (rCud["flagignoreprevcud"].ToString() == "S") {
                    detrazionialtricud = CfgFn.GetNoNullDecimal(r["amount"]);
                }
                else {
                    detrazionialtricud += CfgFn.GetNoNullDecimal(r["amount"]);
                }
            }
            decimal totale_onere = (detrazionialtricud > 0)
                ? onere_contratto + detrazionialtricud / aliquota
                : onere_contratto - franchigia;

            importo_annuo = (detrazionialtricud > 0)
                ? onere_contratto + franchigia + detrazionialtricud / aliquota
                : onere_contratto;


            if (totale_onere < 0) {
                totale_onere = 0;
            }
            else {
                if ((massimale != DBNull.Value) && (totale_onere > (decimal) massimale)) {
                    totale_onere = (decimal) massimale;
                    importo_annuo = (decimal) massimale;

                }
            }

            totale_onere = totale_onere * aliquota;
            return totale_onere;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per reddito
        /// </summary>
        /// <param name="imponibilelordo"></param>
        /// <param name="idcontratto"></param>
        /// <param name="natura"></param>
        /// <param name="annofiscale"></param>
        /// <param name="giornicedolino"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <param name="dataFineCedolino"></param>
        /// <param name="inizioCompetenza"></param>
        /// <param name="fineCompetenza"></param>
        /// <param name="applicazioneDetrazione"></param>
        /// <param name="detrazioneannua"></param>
        /// <returns></returns>
        private decimal calcola_detrazione_reddito(
            decimal imponibilelordo,
            object idcontratto,
            string natura,
            int annofiscale,
            int giornicedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            string applicazioneDetrazione,
            out decimal detrazioneannua
        ) {

            detrazioneannua = 0;

            // Abbiamo deciso che se le detrazioni per reddito non devono essere applicate, questo vale sia per i cedolini rata sia per il conguaglio
            if (applicazioneDetrazione == "N") {
                return 0;
            }

            // Si calcolano i giorni lavorati tramite il metodo calcolaGiorniLavorati che agisce in modo differente se siamo
            // su di un cedolino rata o su di un conguaglio
            int gglavorati = calcolaGiorniLavorati(idcontratto, dataInizioCedolino, dataFineCedolino, natura);

            decimal quotaCedolinoContratto =
                calcolaQuotaMesi(dataInizioCedolino, dataFineCedolino, idcontratto, natura);

            // Si proporzione il reddito complessivo facendone una proporzione sulla durata di competenza del contratto
            // nel caso l'imponibile lordo sia di un cedolino rata (quindi vale per la sua durata)
            decimal redditoComplessivo = imponibilelordo / quotaCedolinoContratto;

            decimal max_fascia1 = 8000;
            decimal max_fascia2 = 28000;
            decimal max_fascia3 = 55000;


            // La detrazione verrà calcolata in base alla fascia di reddito come richiede la Legge
            // Fascia 1:
            if (redditoComplessivo <= max_fascia1) {
                detrazioneannua = detrazione_reddito_fascia1(redditoComplessivo, gglavorati);
            }

            // Fascia 2:
            if (redditoComplessivo > max_fascia1 && redditoComplessivo <= max_fascia2) {
                detrazioneannua = detrazione_reddito_fascia2(redditoComplessivo, gglavorati);
            }

            // Fascia 3: 
            if (redditoComplessivo > max_fascia2 && redditoComplessivo <= max_fascia3) {
                detrazioneannua = detrazione_reddito_fascia3(redditoComplessivo, gglavorati);
            }

            // Fascia 4: Nessuna Detrazione

            detrazioneannua = CfgFn.RoundValuta(detrazioneannua);
            return CfgFn.RoundValuta(detrazioneannua * quotaCedolinoContratto);
        }

        /// <summary>
        /// Metodo che calcola la detrazione per reddito sulla fascia 1, rapportata ai giorni di competenza del contratto
        /// </summary>
        /// <param name="reddito"></param>
        /// <param name="numAnno"></param>
        /// <param name="denAnno"></param>
        /// <param name="giorniCompetenza"></param>
        /// <param name="detrazioneannua"></param>
        /// <returns></returns>
        private decimal detrazione_reddito_fascia1(decimal reddito, int giorniCompetenza) {
            decimal MD = 1880;

            // La minima detrazione non è 690 ma 1380 perché sono lavoratori a tempo determinato
            decimal min_detrazione = 1380;

            DateTime dec_31 = new DateTime(CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")), 12, 31);
            int giorniAnno = dec_31.DayOfYear;
            // Se i giorni di competenza superano l'anno sono posti pari all'anno
            if (giorniCompetenza > giorniAnno) {
                giorniCompetenza = giorniAnno;
            }

            decimal importoDetrazione = 0;

            decimal detrazioneannua = MD;

            importoDetrazione = (MD / giorniAnno) * giorniCompetenza;
            if (importoDetrazione <= min_detrazione) {
                importoDetrazione = min_detrazione;
            }

            return importoDetrazione;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per reddito per la fascia 2, rapportata ai giorni di competenza del contratto
        /// </summary>
        /// <param name="reddito"></param>
        /// <param name="numAnno"></param>
        /// <param name="denAnno"></param>
        /// <param name="giorniCompetenza"></param>
        /// <param name="detrazioneannua"></param>
        /// <returns></returns>
        private decimal detrazione_reddito_fascia2(decimal reddito, int giorniCompetenza) {
            decimal DB = 978;
            decimal K = 902;
            decimal M = 28000;
            decimal min = 20000;

            DateTime dec_31 = new DateTime(CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")), 12, 31);
            int giorniAnno = dec_31.DayOfYear;

            if (giorniCompetenza > giorniAnno) {
                giorniCompetenza = giorniAnno;
            }

            decimal importoDetrazione = (DB + (K * (M - reddito)) / min);
            decimal detrazioneannua = importoDetrazione;

            importoDetrazione = (importoDetrazione / giorniAnno) * giorniCompetenza;
            return importoDetrazione;
        }

        /// <summary>
        /// Metodo che calcola la detrazione annua per reddito per la fascia 3, rapportata ai giorni di competenza del contratto
        /// </summary>
        /// <param name="reddito"></param>
        /// <param name="numAnno"></param>
        /// <param name="denAnno"></param>
        /// <param name="giorniCompetenza"></param>
        /// <param name="detrazioneannua"></param>
        /// <returns></returns>
        private decimal detrazione_reddito_fascia3(decimal reddito, int giorniCompetenza) {
            decimal DB = 978;
            decimal M = 55000;
            decimal min = 27000;

            DateTime dec_31 = new DateTime(CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")), 12, 31);
            int giorniAnno = dec_31.DayOfYear;

            if (giorniCompetenza > giorniAnno) {
                giorniCompetenza = giorniAnno;
            }

            decimal importoDetrazione = (DB * (M - reddito)) / min;

            decimal detrazioneannua = importoDetrazione;

            importoDetrazione = (importoDetrazione / giorniAnno) * giorniCompetenza;

            return importoDetrazione;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per familiari a carico
        /// </summary>
        /// <param name="isConguaglio"></param>
        /// <param name="idcontratto"></param>
        /// <param name="natura"></param>
        /// <param name="annofiscale"></param>
        /// <param name="giornicedolino"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <param name="dataFineCedolino"></param>
        /// <param name="inizioCompetenzaAnno"></param>
        /// <param name="fineCompetenzaAnno"></param>
        /// <param name="redditoComplessivo"></param>
        /// <param name="idCedolino"></param>
        /// <param name="detrazioneannua"></param>
        /// <returns></returns>
        private decimal calcola_detrazione_familiari(
            bool isConguaglio,
            object idcontratto,
            string natura,
            int annofiscale,
            int giornicedolino,
            DateTime dataInizioCedolino,
            DateTime dataFineCedolino,
            decimal redditoComplessivo,
            object idCedolino,
            out decimal detrazioneannua
        ) {
            //Questo è un metodo contenitore che richiama gli altri metodi a seconda del familiare al quale bisogna
            //applicare la detrazione
            int gglavorati = calcolaGiorniLavorati(idcontratto, dataInizioCedolino, dataFineCedolino, natura);

            detrazioneannua = 0;
            decimal dA;
            //calcola le detrazioni per figli a carico: 
            decimal detrazioneperfigli = calcola_detrazione_figli(idcontratto, redditoComplessivo, dataInizioCedolino,
                dataFineCedolino, natura, out dA);
            detrazioneannua += dA;
            //calcola le detrazioni per coniuge:
            decimal detrazioneperconiuge = calcola_detrazione_coniuge(idcontratto, redditoComplessivo,
                dataInizioCedolino, dataFineCedolino, natura, out dA);
            detrazioneannua += dA;
            //calcola le detrazioni per altri familiari:
            decimal detrazioneperaltrifamiliari = calcola_detrazione_altri(idcontratto, redditoComplessivo,
                dataInizioCedolino, dataFineCedolino, natura, out dA);
            detrazioneannua += dA;

            decimal detrazione = detrazioneperfigli + detrazioneperconiuge + detrazioneperaltrifamiliari;

            return detrazione;
        }

        /// <summary>
        /// Metodo che controlla se non ci sono cedolini in un determinato mese
        /// </summary>
        /// <param name="idContratto"></param>
        /// <param name="idCedolino"></param>
        /// <param name="dataCedolino"></param>
        /// <returns></returns>
        private bool
            controllaAssenzaAltriCedoliniNelMese(object idContratto, object idCedolino, DateTime dataCedolino) {
            int annoFiscale = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            string filter = QHC.AppAnd(QHC.CmpEq("idcon", idContratto),
                QHC.CmpEq("fiscalyear", annoFiscale), QHC.CmpNe("idpayroll", idCedolino),
                QHC.CmpEq("flagbalance", "N"));

            DataRow[] Payroll = DS.payroll.Select(filter, "start");
            foreach (DataRow rPayroll in Payroll) {
                DateTime stop = (DateTime) rPayroll["stop"];
                if ((stop.Year == dataCedolino.Year) && (stop.Month == dataCedolino.Month)) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per figli a carico
        /// </summary>
        /// <param name="idcontratto"></param>
        /// <param name="reddito"></param>
        /// <param name="idCedolino"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <param name="dataFineCedolino"></param>
        /// <param name="natura"></param>
        /// <param name="giornicedolino"></param>
        /// <param name="gglavorati"></param>
        /// <param name="detrazioneAnnua"></param>
        /// <returns></returns>
        private decimal calcola_detrazione_figli(object idcontratto, decimal reddito, DateTime dataInizioCedolino,
            DateTime dataFineCedolino, string natura,
            out decimal detrazioneAnnua) {
            detrazioneAnnua = 0;


            decimal quotaCedolinoContratto =
                calcolaQuotaMesi(dataInizioCedolino, dataFineCedolino, idcontratto, natura);

            // Si calcola il reddito complessivo annuo come stima del reddito contenuto nel cedolino (ove sia un cedolino rata)
            decimal redditoComplessivo = reddito / quotaCedolinoContratto; //            reddito / numAnno * denAnno;

            // Filtro per estrarre i figli dai familiari
            string filtroFigli = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("idaffinity", "F"));
            // Vengono selezionati tutti i figli inseriti nel contratto

            DataRow[] tempFamFigli = DS.parasubcontractfamily.Select(filtroFigli, "birthdate");



            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            DateTime inizioAnno = new DateTime(esercizio, 1, 1);
            DateTime fineAnno = new DateTime(esercizio, 12, 31);

            int nFigliACarico = 0;

            // La legge, quando conta i figli a carico, ne tiene conto anche se un figlio è stato per un solo giorno
            // a carico. Si è trovato un esempio su una circolare dell'Agenzia delle Entrate.
            foreach (DataRow son in tempFamFigli) {
                DateTime inizioApplicazione = (DateTime) isnull(son["startapplication"], inizioAnno);
                DateTime fineApplicazione = (DateTime) isnull(son["stopapplication"], fineAnno);

                if (inizioApplicazione < inizioAnno) {
                    inizioApplicazione = inizioAnno;
                }

                if (fineApplicazione > fineAnno) {
                    fineApplicazione = fineAnno;
                }
                if ((inizioApplicazione <= inizioAnno) &&
                     (fineApplicazione >= inizioAnno) ) {
                    nFigliACarico++;
                }
            }

            decimal detrazione = 0;
            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");

            bool esisteConiuge = false;
            string filtroConiuge = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("idaffinity", "C"));
            int n_effettivi_a_carico = 0;
            esisteConiuge = (DS.parasubcontractfamily.Select(filtroConiuge).Length > 0);

            DateTime dataCedolino = dataInizioCedolino;
            // Ciclo che per ogni figlio determina l'ammontare mensile della deduzione
            for (int numeroFiglio = 0; numeroFiglio < tempFamFigli.Length; numeroFiglio++) {
                decimal detrazionePerQuestoFiglio = 0;

                DataRow figlioRow = tempFamFigli[numeroFiglio];
                //if (figlioRow["flagdependent"].ToString().ToUpper() != "S") continue;

                decimal perc = CfgFn.GetNoNullDecimal(isnull(figlioRow["appliancepercentage"], 1));
                if (perc == 0) continue;
                n_effettivi_a_carico += 1;
                DateTime inizioApplicazioneFiglio =
                    (DateTime) isnull(figlioRow["startapplication"], figlioRow["birthdate"]);
                DateTime fineApplicazioneFiglio = (DateTime) isnull(figlioRow["stopapplication"], DateTime.MaxValue);

                if ((dataFineCedolino < inizioApplicazioneFiglio) ||
                    (dataInizioCedolino > fineApplicazioneFiglio)) continue;

                if (inizioApplicazioneFiglio <= inizioAnno) {
                    inizioApplicazioneFiglio = inizioAnno;
                }
                if (fineApplicazioneFiglio >= fineAnno) {
                    fineApplicazioneFiglio = fineAnno;
                }
                //secondo indicazioni di Antonio non conta la data contabile ma solo il periodo di applicazione
                //if ((dataContabile.Month < inizioApplicazioneFiglio.Month) || (dataContabile.Month > fineApplicazioneFiglio.Month)) continue;

                DateTime dataRiferimento = dataFineCedolino >= inizioAnno ? dataFineCedolino : inizioAnno;


                int indice = dataRiferimento.Month - 1;
                //Percentuale che già include la quota di ripartizione tra coniugi
                detrazionePerQuestoFiglio = scegliDetrazionePerFiglio(dataRiferimento, figlioRow, nFigliACarico,
                    inizioApplicazioneFiglio, fineApplicazioneFiglio, perc);
                
                bool isPrimoFiglio = (numeroFiglio == 0);
                bool childAsParent = false;
                // Caso di primo figlio senza coniuge -- Si considera il primo figlio come un coniuge
                if ((isPrimoFiglio) && (!esisteConiuge) && (perc == 1)) {
                    decimal detrazioneAnnuaConiuge = calcola_detrazione_coniuge_su_fascia(redditoComplessivo);
                    detrazionePerQuestoFiglio =
                        detrazione_figli(detrazionePerQuestoFiglio, redditoComplessivo, nFigliACarico);
                    if (detrazioneAnnuaConiuge > detrazionePerQuestoFiglio) {
                        detrazionePerQuestoFiglio = detrazioneAnnuaConiuge;
                        childAsParent = true;
                    }
                    detrazioneAnnua += CfgFn.Round((detrazionePerQuestoFiglio), 2);
                }
                // Caso Normale
                else {
                    detrazionePerQuestoFiglio =
                        detrazione_figli(detrazionePerQuestoFiglio, redditoComplessivo, nFigliACarico);
                    detrazioneAnnua += CfgFn.Round((detrazionePerQuestoFiglio), 2);
                }

                //considera la detrazione rapportandola al periodo del cedolino
                detrazionePerQuestoFiglio = CfgFn.Round(detrazionePerQuestoFiglio * quotaCedolinoContratto, 2);

                detrazione += detrazionePerQuestoFiglio;
                if (natura == "C") {
                    // Informazioni da usare, ove richieste in sede di dichiarazione dei redditi
                    figlioRow["amount"] = detrazionePerQuestoFiglio;
                    figlioRow["childasparent"] = (childAsParent) ? "S" : "N";
                }
            }

            if (n_effettivi_a_carico > 3) {
                decimal detrazione_piu_di_trefigli = 1200m;
                decimal detrazione_da_applicare = 0;
                if (natura == "C") {
                    detrazione_da_applicare = detrazione_piu_di_trefigli;
                }
                else {
                    detrazione_da_applicare = CfgFn.Round(detrazione_piu_di_trefigli * quotaCedolinoContratto, 2);
                }
                detrazione += detrazione_da_applicare;
                detrazioneAnnua += detrazione_piu_di_trefigli;
            }
            return detrazione;
        }


        /// <summary>
        /// Metodo che calcola la detrazione base per i figli secondo canoni imposti dalla Legge
        /// </summary>
        /// <param name="dataRiferimento"></param>
        /// <param name="rSon"></param>
        /// <param name="nFigliAnno"></param>
        /// <param name="inizioApplicazione"></param>
        /// <param name="fineApplicazione"></param>
        /// <param name="percApplicazione"></param>
        /// <returns></returns>
        private decimal scegliDetrazionePerFiglio(DateTime dataRiferimento, DataRow rSon, int nFigliAnno,
            DateTime inizioApplicazione, DateTime fineApplicazione, decimal percApplicazione) {
            if (percApplicazione == 0) return 0;
            decimal D_BASE = 950m; // >> 950 era 800
            decimal PLUS_NO_3ANNI = 270m; //>> 270 era 100
            decimal PLUS_HANDICAP = 400m; //>> 400  era 220
            decimal PLUS_4FIGLI = 200m; //>>ok  
            decimal MD = 0;

            // Si crea un ciclo per ogni mese dell'anno si calcola, in quel mese, quel figlio a che detrazione ha diritto.
            // e alla fine si ottiene un risultato che viene restituito in output

            decimal MDProg = 0;
            int mesiAnno = 12;

            for (int progMese = 1; progMese <= mesiAnno; progMese++) {
                //check inizio applicazione: se segue il mese/anno riferimento, esce
                if (inizioApplicazione.Year > dataRiferimento.Year) continue;
                if (inizioApplicazione.Year == dataRiferimento.Year &&
                    inizioApplicazione.Month > progMese) continue;

                //check fine applicazione: se precede il mese/anno riferimento, esce
                if (fineApplicazione.Year < dataRiferimento.Year) continue;
                if (fineApplicazione.Year == dataRiferimento.Year &&
                    fineApplicazione.Month < progMese) continue;

                //if ((progMese < inizioApplicazione.Month) || (progMese > fineApplicazione.Month)) {
                //    continue;
                //}

                MD = D_BASE;

                // Se ci sono almeno 4 figli viene aggiunta una detrazione di 200 €
                if (nFigliAnno > 3) {
                    MD += PLUS_4FIGLI;
                }

                DateTime inizioAnno = new DateTime(dataRiferimento.Year, 1, 1);

                // Se il figlio è handicappato viene aggiunta una detrazione di 220 €
                if (rSon["starthandicap"] != DBNull.Value) {
                    DateTime handicap = (DateTime) rSon["starthandicap"];
                    if (handicap <= inizioAnno) {
                        handicap = inizioAnno;
                    }
                    if (progMese >= handicap.Month) {
                        MD += PLUS_HANDICAP;
                    }
                }

                // Se il figlio ha meno di 3 anni viene aggiunta una detrazione di 100 €
                if (rSon["birthdate"] != DBNull.Value) {
                    DateTime dataNascita = (DateTime) rSon["birthdate"];
                    int etaInMesi = 12 * (dataRiferimento.Year - dataNascita.Year) + progMese - dataNascita.Month;
                    if (etaInMesi <= 36) {
                        MD += PLUS_NO_3ANNI;
                    }
                }

                MDProg += (MD * percApplicazione);

            }

            MDProg /= 12;

            return CfgFn.RoundValuta(MDProg);
        }

        /// <summary>
        /// Metodo che calcola la detrazione per coniuge a carico
        /// </summary>
        /// <param name="idcontratto"></param>
        /// <param name="reddito"></param>
        /// <param name="idCedolino"></param>
        /// <param name="primoGiornoPrimoCedolino"></param>
        /// <param name="ultimoGiornoUltimoCedolino"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <param name="dataFineCedolino"></param>
        /// <param name="natura"></param>
        /// <param name="giornicedolino"></param>
        /// <param name="gglavorati"></param>
        /// <param name="detrazioneAnnua"></param>
        /// <returns></returns>
        private decimal calcola_detrazione_coniuge(object idcontratto, decimal reddito, DateTime dataInizioCedolino,
            DateTime dataFineCedolino, string natura,
            out decimal detrazioneAnnua) {


            decimal fattoreQuotaMesi = calcolaQuotaMesi(dataInizioCedolino, dataFineCedolino, idcontratto, natura);

            // Si stima il reddito complessivo annuo sulla base del compenso lordo del cedolino rata
            decimal redditoComplessivo = reddito / fattoreQuotaMesi;

            detrazioneAnnua = 0;

            // Filtro per estrarre i coniugi a carico
            string filtroFamiliare = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("idaffinity", "C"),
                QHC.CmpEq("flagdependent", "S"));

            DataRow[] tempFamiliare = DS.parasubcontractfamily.Select(filtroFamiliare, "birthdate");

            decimal detrazione = 0;

            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            DateTime inizioAnno = new DateTime(esercizio, 1, 1);
            DateTime fineAnno = new DateTime(esercizio, 12, 31);



            // Per ogni coniuge si effettua il calcolo della detrazione
            foreach (DataRow familiareRow in tempFamiliare) {
                decimal perc = CfgFn.GetNoNullDecimal(isnull(familiareRow["appliancepercentage"], 1));

                DateTime inizioApplicazione = (DateTime) isnull(familiareRow["startapplication"], DateTime.MinValue);
                DateTime fineApplicazione = (DateTime) isnull(familiareRow["stopapplication"], DateTime.MaxValue);

                if ((dataFineCedolino < inizioApplicazione) || (dataInizioCedolino > fineApplicazione)) continue;

                if (inizioApplicazione <= inizioAnno) {
                    inizioApplicazione = inizioAnno;
                }
                if (fineApplicazione >= fineAnno) {
                    fineApplicazione = fineAnno;
                }

                //if ((dataContabile.Month < inizioApplicazione.Month) || (dataContabile.Month > fineApplicazione.Month)) continue;

                decimal detrazioneAnnuaQuestoFamiliare =
                    CfgFn.Round(calcola_detrazione_coniuge_su_fascia(redditoComplessivo), 2);
                decimal detrazionePerQuestoFamiliare =
                    CfgFn.Round(fattoreQuotaMesi * detrazioneAnnuaQuestoFamiliare, 2);

                detrazioneAnnua += detrazioneAnnuaQuestoFamiliare;
                detrazione += detrazionePerQuestoFamiliare;
                if (natura == "C") {
                    familiareRow["amount"] = detrazioneAnnuaQuestoFamiliare;
                    familiareRow["childasparent"] = "N";
                }
            }

            return detrazione;
        }

        public decimal calcolaQuotaMesi(DateTime dataInizioCedolino, DateTime dataFineCedolino, object idContratto,
            string natura) {
            if (natura == "C")
                return 1;
            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idContratto))[0];
            DateTime datainiziocompetenza = (DateTime) rImputContr["startcompetency"];
            DateTime datafinecompetenza = (DateTime) rImputContr["stopcompetency"];
            int ggCompetenza = 1 + (datafinecompetenza - datainiziocompetenza).Days;
            int ggCedolino = 1 + (dataFineCedolino - dataInizioCedolino).Days;

            return Convert.ToDecimal(ggCedolino) / Convert.ToDecimal(ggCompetenza);
        }


        /// <summary>
        /// Metodo che calcola la detrazione per coniuge in base al periodo di durata del cedolino
        /// </summary>
        /// <param name="redditoComplessivo">Reddito Complessivo Annuo (al netto degli oneri deducibili)</param>
        /// <param name="mesiCompetenza">Mesi Totali di Competenza</param>
        /// <param name="mesiCedolino">Mesi del Cedolino sui quali applicare la detrazione</param>
        /// <returns></returns>
        private decimal calcola_detrazione_coniuge_su_fascia(decimal redditoComplessivo) {
            decimal detrazioneAnnua = 0;
            decimal max_fascia1 = 15000;
            decimal max_fascia2 = 40000;
            decimal max_fascia3 = 80000;


            if (redditoComplessivo <= max_fascia1) {
                detrazioneAnnua = detrazione_coniuge_fascia1(redditoComplessivo);
            }

            if (redditoComplessivo > max_fascia1 && redditoComplessivo <= max_fascia2) {
                detrazioneAnnua = detrazione_coniuge_fascia2(redditoComplessivo);
            }

            if (redditoComplessivo > max_fascia2 && redditoComplessivo <= max_fascia3) {
                detrazioneAnnua = detrazione_coniuge_fascia3(redditoComplessivo);
            }

            return detrazioneAnnua;
        }

        /// <summary>
        /// Metodo che calcola la detrazione annua per coniuge su fascia 1
        /// </summary>
        /// <param name="reddito"></param>
        /// <returns></returns>
        private decimal detrazione_coniuge_fascia1(decimal reddito) {
            decimal MD = 800;
            decimal K = 110;
            decimal min = 15000;
            // Costante moltiplicativa per troncamento alla quarta cifra decimale
            decimal kTron = 10000m;
            decimal importoDetrazione = (reddito / min) * kTron;
            int i = (int) importoDetrazione;

            if (i <= 0) {
                return 0;
            }

            if (i < kTron) {
                return importoDetrazione = MD - K * (i / kTron);
            }

            return importoDetrazione = MD - K;
        }

        /// <summary>
        /// Metodo che calcola la detrazione annua per coniuge su fascia 2
        /// </summary>
        /// <param name="reddito"></param>
        /// <returns></returns>
        private decimal detrazione_coniuge_fascia2(decimal reddito) {
            decimal DB = 690;

            if (reddito > 29000 && reddito <= 29200) {
                return DB + 10;
            }
            if (reddito > 29200 && reddito <= 34700) {
                return DB + 20;
            }
            if (reddito > 34700 && reddito <= 35000) {
                return DB + 30;
            }
            if (reddito > 35000 && reddito <= 35100) {
                return DB + 20;
            }
            if (reddito > 35100 && reddito <= 35200) {
                return DB + 10;
            }

            return DB;
        }

        /// <summary>
        /// Metodo che calcola la detrazione annua per coniuge su fascia 3
        /// </summary>
        /// <param name="reddito"></param>
        /// <returns></returns>
        private decimal detrazione_coniuge_fascia3(decimal reddito) {
            decimal MD = 690;
            decimal M = 80000;
            decimal min = 40000;
            // Costante moltiplicativa per troncamento alla quarta cifra decimale
            decimal kTron = 10000m;
            decimal importoDetrazione = (M - reddito) / min * kTron;
            int i = (int) importoDetrazione;

            if (i <= 0) {
                return 0;
            }

            if (i < kTron) {
                return 690 * (i / kTron);
            }

            return MD;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per gli altri familiari (non figli e non coniuge)
        /// </summary>
        /// <param name="reddito"></param>
        /// <param name="mesiCompetenza"></param>
        /// <param name="mesiCedolino"></param>
        /// <param name="detrazioneAnnua"></param>
        /// <returns></returns>
        private decimal detrazione_altri(decimal reddito) {
            decimal MD = 750;
            decimal kTron = 10000m;
            decimal M = 80000m;
            decimal rapporto = ((M - reddito) / M) * kTron;
            int i = Convert.ToInt32(Math.Truncate(rapporto));
            if (i <= 0) {
                return 0;
            }
            if (i < kTron) {
                return MD * (i / kTron);
            }
            return MD;
        }

        /// <summary>
        /// Metodo che calcola la detrazione per figli
        /// </summary>
        /// <param name="detrazionebase"></param>
        /// <param name="reddito"></param>
        /// <param name="nFigli"></param>
        /// <returns></returns>
        private decimal detrazione_figli(decimal detrazionebase, decimal reddito, int nFigli) {
            decimal M = 95000m;
            decimal inc = 15000m;
            decimal kTron = 10000m;
            decimal importoDetrazione = 0;
            inc *= (nFigli - 1);
            M += inc;
            decimal r = ((M - reddito) / M) * kTron;
            int i = (int) r;
            if (i <= 0) {
                return 0;
            }
            if (i < kTron) {
                return (detrazionebase * i) / kTron;
            }
            importoDetrazione = detrazionebase;
            return importoDetrazione;
        }


        /// <summary>
        /// Metodo che calcola la detrazione per altri familiari
        /// </summary>
        /// <param name="idcontratto"></param>
        /// <param name="reddito"></param>
        /// <param name="idCedolino"></param>
        /// <param name="primoGiornoPrimoCedolino"></param>
        /// <param name="ultimoGiornoUltimoCedolino"></param>
        /// <param name="dataInizioCedolino"></param>
        /// <param name="dataFineCedolino"></param>
        /// <param name="natura"></param>
        /// <param name="giornicedolino"></param>
        /// <param name="gglavorati"></param>
        /// <param name="detrazioneAnnua"></param>
        /// <returns></returns>
        private decimal calcola_detrazione_altri(object idcontratto, decimal reddito, DateTime dataInizioCedolino,
            DateTime dataFineCedolino, string natura,
            out decimal detrazioneAnnua) {

            decimal quotaMesi = calcolaQuotaMesi(dataInizioCedolino, dataFineCedolino, idcontratto, natura);



            //Stima del reddito complessivo annuo partendo da quello del cedolino
            decimal redditoComplessivo = reddito / quotaMesi;

            detrazioneAnnua = 0;

            // Filtro per estrarre i familiari a carico
            string filtroFamiliare = QHC.AppAnd(QHC.CmpEq("idcon", idcontratto), QHC.CmpEq("idaffinity", "A"),
                QHC.CmpEq("flagdependent", "S"));


            DataRow[] tempFamiliare = DS.parasubcontractfamily.Select(filtroFamiliare, "birthdate");



            decimal detrazione = 0;

            DateTime dataContabile = (DateTime) Conn.GetSys("datacontabile");
            int esercizio = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));

            DateTime inizioAnno = new DateTime(esercizio, 1, 1);
            DateTime fineAnno = new DateTime(esercizio, 12, 31);

            foreach (DataRow familiareRow in tempFamiliare) {
                decimal perc = CfgFn.GetNoNullDecimal(isnull(familiareRow["appliancepercentage"], 1));

                DateTime inizioApplicazione = (DateTime) isnull(familiareRow["startapplication"], DateTime.MinValue);
                DateTime fineApplicazione = (DateTime) isnull(familiareRow["stopapplication"], DateTime.MaxValue);

                if ((dataFineCedolino < inizioApplicazione) || (dataInizioCedolino > fineApplicazione)) continue;

                if (inizioApplicazione <= inizioAnno) {
                    inizioApplicazione = inizioAnno;
                }
                if (fineApplicazione >= fineAnno) {
                    fineApplicazione = fineAnno;
                }

                //if ((dataContabile.Month < inizioApplicazione.Month) || (dataContabile.Month > fineApplicazione.Month)) continue;

                DateTime dataCedolino = dataInizioCedolino;


                decimal detrazioneAnnuaPerQuestoFamiliare = detrazione_altri(redditoComplessivo);
                decimal detrazionePerQuestoFamiliare = detrazioneAnnuaPerQuestoFamiliare * quotaMesi;
                detrazioneAnnua += CfgFn.Round((detrazioneAnnuaPerQuestoFamiliare * perc), 2);
                detrazione += CfgFn.Round((detrazionePerQuestoFamiliare * perc), 2);
                if (natura == "C") {
                    familiareRow["amount"] = CfgFn.Round((detrazionePerQuestoFamiliare * perc), 2);
                    familiareRow["childasparent"] = "N";
                }
            }

            return detrazione;
        }




        #endregion

        /// <summary>
        /// Calcola i giorni lavorati tenendo conto dei CUD presentati
        /// </summary>
        /// <returns></returns>
        private int calcolaGiorniLavorati(object idContratto,
            DateTime dataInizioCedolino, DateTime dataFineCedolino, string natura) {

            DataRow rImputContr = DS.parasubcontractyear.Select(QHC.CmpEq("idcon", idContratto))[0];
            DateTime inizioCompetenzaContratto = (DateTime) rImputContr["startcompetency"];
            DateTime fineCompetenzaContratto = (DateTime) rImputContr["stopcompetency"];

            int gglavcontratto = 1 + (fineCompetenzaContratto - inizioCompetenzaContratto).Days;
            int annofiscale = CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"));
            int giorniAnnoSolare = DateTime.IsLeapYear(annofiscale) ? 366 : 365;
            // Se siamo in un cedolino rata i giorni lavorati sono la differenza tra le date di inizio e fine del cedolino
            if (natura == "R") {
                if (gglavcontratto > giorniAnnoSolare) {
                    gglavcontratto = giorniAnnoSolare;
                }
                return gglavcontratto;
            }

            // Quando siamo in conguaglio si definisce un metodo ricorsivo che riempie la tabella tData
            // In questa tabella sono presenti tutte le date di inizio e fine dei contratti e dei CUD cartacei coinvolti 
            // nel conguaglio del contratto corrente
            DataTable tData = new DataTable();
            tData.Columns.Add("start", typeof(DateTime));
            tData.Columns.Add("stop", typeof(DateTime));

            tData = calcolaTabellaData(Conn.GetSys("userdb"), idContratto, tData, "S");

            int gglavorati = contaGiorniLavorati(tData, annofiscale);

            return gglavorati;
        }

        /// <summary>
        /// Metodo ricorsivo che popola la tabella delle date inizio e fine di ogni contratto - CUD cartaceo
        /// </summary>
        /// <param name="idDbDepartment"></param>
        /// <param name="idCon"></param>
        /// <param name="tData"></param>
        /// <returns></returns>


        private DataTable calcolaTabellaData(object idDbDepartment, object idContract, DataTable tData,
            string includiContratto) {
            // Solo se includiContratto = "N", alla prima esecuzione considero solo i CUD inseriti. Invece nelle ricorsioni successive, 
            // prendo sia il range temporale dei contratti collegati come CUD (campo idlinkedcon)
            // che  il range temporale dei CUD in essi inseriti per calcolare correttamente
            // i giorni lavorati 
            if (includiContratto == "S") {
                string tName = idDbDepartment + ".parasubcontractview";
                DataTable tContract = Conn.CreateTableByName(tName,
                    "startcompetency, stopcompetency");

                DataAccess.SetTableForReading(tContract, "parasubcontractview");

                Conn.RUN_SELECT_INTO_TABLE(tContract, null,
                    QHS.AppAnd(QHS.CmpEq("idcon", idContract),
                        QHS.CmpEq("ayear", MetaCedolino.GetSys("esercizio"))),
                    null, true);

                if ((tContract == null) || (tContract.Rows.Count == 0)) {
                    return tData;
                }

                DataRow rContract = tContract.Rows[0];
                DataRow r = tData.NewRow();
                r["start"] = rContract["startcompetency"];
                r["stop"] = rContract["stopcompetency"];
                tData.Rows.Add(r);
            }
            // Si popola la tabella dei CUD collegati al contratto
            DataTable LinkedCud = getCudLinkedToContract(Conn, idContract, null);

            if (LinkedCud == null || LinkedCud.Rows.Count == 0) {
                return tData;
            }

            // Se il CUD è cartaceo si prende il dato da se stesso
            // altrimenti viene chiamata la ricorsione per risalire al contratto

            foreach (DataRow ExC in LinkedCud.Rows) {
                if (ExC["idlinkedcon"] == DBNull.Value) {
                    DataRow rData = tData.NewRow();
                    rData["start"] = ExC["start"];
                    rData["stop"] = ExC["stop"];
                    tData.Rows.Add(rData);
                }
                else {
                    // per i Cud successivi includi sempre il range dei Contratti
                    calcolaTabellaData(idDbDepartment, ExC["idlinkedcon"], tData, "S");
                }
            }

            return tData;
        }

        private void calcolaTabellaCud(object idDbDepartment, object idContract, int annoFiscale, DataTable tData,
            string includiContratto,
            DateTime start, DateTime stop) {
            if (includiContratto == "S") {
// Stima dei giorni lavorati nell'anno nel presente contratto
                DataRow r = tData.NewRow();
                r["start"] = start;
                r["stop"] = stop;
                tData.Rows.Add(r);
            }


            // Ingloba i giorni lavorati nei CUD precedenti
            string query = QHC.AppAnd(QHC.CmpEq("idcon", idContract), QHC.CmpEq("fiscalyear", annoFiscale));

            DataRow[] rCud = DS.exhibitedcud.Select(query, "idexhibitedcud");
            // Per ogni CUD associato al contratto si somma il numero dei giorni lavorati, in caso di contemporaneità
            // deve essere contato solo un giorno

            foreach (DataRow r in rCud) {
                object idexhibitedcud = r["idexhibitedcud"];
                string query_toignore = QHC.AppAnd(query, QHC.CmpGt("idexhibitedcud", idexhibitedcud),
                    QHC.CmpGt("flagignoreprevcud", "S"));
                DataRow[] rCud_toignore = DS.exhibitedcud.Select(query_toignore);
                if (rCud_toignore.Length > 0) continue;

                DateTime datainiziocompetenza = (DateTime) r["start"];
                DateTime datafinecompetenza = (DateTime) r["stop"];

                if (r["idlinkedcon"] == DBNull.Value) {
                    DataRow rData = tData.NewRow();
                    rData["start"] = datainiziocompetenza;
                    rData["stop"] = datafinecompetenza;
                    tData.Rows.Add(rData);
                }
                else {
                    //per i Cud successivi includi sempre il range dei Contratti
                    calcolaTabellaCud(idDbDepartment, r["idlinkedcon"], annoFiscale, tData, "S", datainiziocompetenza,
                        datafinecompetenza);
                }
            }
        }

        /// <summary>
        /// Metodo che valuta se devono essere considerate le ritenute da CAF
        /// </summary>
        /// <param name="applicaAddCom">TRUE: Se deve essere considerata l'addizionale comunale; FALSE: Altrimenti</param>
        /// <param name="applicaAddReg">TRUE: Se deve essere considerata l'addizionale regionale; FALSE: Altrimenti</param>
        /// <param name="applicaArretrati">TRUE: Se devono essere considerati gli arretrati; FALSE: Altrimenti</param>
        private bool consideraRitenuteDaCaf(DataRow[] rowComunicazioneDaCaf) {
            bool applicaArretrati = false;
            foreach (DataRow rowCaf in rowComunicazioneDaCaf) {
                bool arretratiRigaCorrente = (rowCaf["irpeftorefund"] != DBNull.Value)
                                             || (rowCaf["irpeftoretain"] != DBNull.Value)
                                             || (rowCaf["separatedincomehusband"] != DBNull.Value)
                                             || (rowCaf["separatedincome"] != DBNull.Value)
                                             || (rowCaf["firstrateadvance"] != DBNull.Value)
                                             || (rowCaf["secondrateadvance"] != DBNull.Value)
                                             || (rowCaf["citytaxtorefund"] != DBNull.Value)
                                             || (rowCaf["citytaxtorefundhusband"] != DBNull.Value)
                                             || (rowCaf["citytaxtoretain"] != DBNull.Value)
                                             || (rowCaf["citytaxtoretainhusband"] != DBNull.Value)
                                             || (rowCaf["regionaltaxtorefund"] != DBNull.Value)
                                             || (rowCaf["regionaltaxtorefundhusband"] != DBNull.Value)
                                             || (rowCaf["regionaltaxtoretain"] != DBNull.Value)
                                             || (rowCaf["regionaltaxtoretainhusband"] != DBNull.Value)
                                             || (rowCaf["citytaxaccount"] != DBNull.Value)
                                             || (rowCaf["citytaxaccounthusband"] != DBNull.Value);

                string tipoComunicazione = rowCaf["cafdocumentkind"].ToString().ToUpper();
                switch (tipoComunicazione) {
                    case "I": /*comunicazione integrativa*/ {
                        applicaArretrati = applicaArretrati || arretratiRigaCorrente;
                        break;
                    }
                    default: /*comunicazione ordinaria - rettificativa*/ {
                        applicaArretrati = arretratiRigaCorrente;
                        break;
                    }
                }
            }
            return applicaArretrati;
        }

        /// <summary>
        /// Costruisce la query per trovare tutte le ritenute di un tipo di imponibile
        /// </summary>
        /// <param name="codiceimponibile">id. del tipo di imponibile</param>
        /// <param name="codiceprestazione">id. del tipo di prestazione</param>
        /// <param name="isConguaglio">true se si tratta di un conguaglio</param>
        /// <param name="RowAddizionalidaCaf">riga delle addizionali da versare per conto caf</param>
        /// <param name="RowImputazioneContratto">riga di imputazionecontratto</param>
        /// <param name="tipoRitenutaDaCalcolare">N: Calcola solo le ritenute non fiscali; F: Calcola solo le ritenute fiscali; T: Calcola tutte le ritenute (calcolo normale)</param>
        /// <returns></returns>
        private string costruisciQueryRitenute(object codiceimponibile, object codiceprestazione, bool isConguaglio,
            DataRow[] rowComunicazioneDaCaf, DataRow RowImputazioneContratto, string tipoRitenutaDaCalcolare) {
            // Considera tutte le ritenute sui cedolini di rata
            string query2 = QHS.AppAnd(QHS.CmpEq("taxablecode", codiceimponibile),
                QHS.CmpEq("idser", codiceprestazione));

            string tipoApplicazioneGeo = "";
            string taxlocalcode_included = "";
            switch (tipoRitenutaDaCalcolare) {
                // Calcolo delle ritenute non fiscali (ULTIMO CEDOLINO RATA)
                case "N": {
                    query2 = QHS.AppAnd(query2, QHS.CmpNe("taxkind", 1));

                    if (RowImputazioneContratto["regionaltax"] == DBNull.Value) {
                        tipoApplicazioneGeo += "," + QHS.quote("R");
                    }
                    else {
                        object taxR = DS.tax.Select(QHC.CmpEq("taxref", "08_ADDREGRATA"))[0]["taxcode"];
                        taxlocalcode_included = QHS.quote(taxR);
                    }
                    // Attualmente non esiste una addizionale provinciale ma per sviluppi futuri è inserita nel codice
                    // J.T.R. 28.05.2008 - Non ho creato una ritenuta per addizionale provinciale in quanto
                    // non esiste ad oggi, eventualmente si procede alla sua creazione e alla modifica di questo metodo
                    if (RowImputazioneContratto["countrytax"] == DBNull.Value) {
                        tipoApplicazioneGeo += "," + QHS.quote("P");
                    }

                    if (RowImputazioneContratto["citytax"] == DBNull.Value) {
                        tipoApplicazioneGeo += "," + QHS.quote("C");
                    }
                    else {
                        if (taxlocalcode_included != "") {
                            taxlocalcode_included += ",";
                        }
                        object taxC = DS.tax.Select(QHC.CmpEq("taxref", "08_ADDCOMRATA"))[0]["taxcode"];
                        taxlocalcode_included += QHS.quote(taxC);
                    }

                    if (tipoApplicazioneGeo != "") {
                        query2 = QHS.AppAnd(query2,
                            QHS.DoPar(QHS.AppOr(QHS.CmpNe("taxkind", 1), QHS.IsNull("geoappliance"),
                                QHS.FieldInList("taxcode", taxlocalcode_included))
                            ));
                    }

                    if (!consideraRitenuteDaCaf(rowComunicazioneDaCaf)) {
                        string filterArretrato = (tipoApplicazioneGeo == "")
                            ? QHS.CmpNe("taxkind", 5)
                            : QHS.DoPar(QHS.AppOr(QHS.CmpNe("taxkind", 5),
                                QHS.FieldInList("taxcode", taxlocalcode_included)));

                        query2 = QHS.AppAnd(query2, filterArretrato);
                    }
                    break;
                }
                // Calcolo delle sole ritenute fiscali (CEDOLINO DI CONGUAGLIO)
                case "F": {
                    query2 = QHS.AppAnd(query2, QHS.CmpEq("taxkind", 1));
                    break;
                }
                // Calcolo normale (CEDOLINI RATA DIFFERENTI DALL'ULTIMO)
                default: {
                    string taxcode_excluded = "";

                    if (RowImputazioneContratto["regionaltax"] == DBNull.Value) {
                        tipoApplicazioneGeo += "," + QHS.quote("R");
                    }
                    else {
                        object taxR = DS.tax.Select(QHC.CmpEq("taxref", "08_ADDREGRATA"))[0]["taxcode"];
                        taxlocalcode_included = QHS.quote(taxR);
                    }
                    // Attualmente non esiste una addizionale provinciale ma per sviluppi futuri è inserita nel codice
                    // J.T.R. 28.05.2008 - Non ho creato una ritenuta per addizionale provinciale in quanto
                    // non esiste ad oggi, eventualmente si procede alla sua creazione e alla modifica di questo metodo
                    if (RowImputazioneContratto["countrytax"] == DBNull.Value) {
                        tipoApplicazioneGeo += "," + QHS.quote("P");
                    }

                    if ((RowImputazioneContratto["citytax"] == DBNull.Value)
                        && (RowImputazioneContratto["citytax_account"] == DBNull.Value)) {
                        tipoApplicazioneGeo += "," + QHS.quote("C");

                    }
                    else {
                        // Se sono qui vuol dire che almeno uno dei due campi è valorizzato, quindi devo escludere
                        // la ritenuta che non serve
                        object taxC = DS.tax.Select(QHC.CmpEq("taxref", "08_ADDCOMRATA"))[0]["taxcode"];
                        if (RowImputazioneContratto["citytax"] == DBNull.Value) {
                            taxcode_excluded = QHS.quote(taxC);
                        }
                        else {
                            if (taxlocalcode_included != "") {
                                taxlocalcode_included += ",";
                            }
                            taxlocalcode_included += QHS.quote(taxC);
                        }
                        if (RowImputazioneContratto["citytax_account"] == DBNull.Value) {
                            if (taxcode_excluded != "") {
                                taxcode_excluded += ",";
                            }
                            object tax = DS.tax.Select(QHC.CmpEq("taxref", "07_ACC_ADDCOM"))[0]["taxcode"];
                            taxcode_excluded += QHS.quote(tax);
                        }
                        else {
                            if (taxlocalcode_included != "") {
                                taxlocalcode_included += ",";
                            }
                            object tax = DS.tax.Select(QHC.CmpEq("taxref", "07_ACC_ADDCOM"))[0]["taxcode"];
                            taxlocalcode_included += QHS.quote(tax);
                        }
                    }

                    if (tipoApplicazioneGeo != "") {
                        tipoApplicazioneGeo = tipoApplicazioneGeo.Substring(1);
                        query2 = QHS.AppAnd(query2,
                            QHS.DoPar(QHS.AppOr(QHS.CmpNe("taxkind", 1), QHS.IsNull("geoappliance"),
                                QHS.FieldInList("taxcode", taxlocalcode_included))
                            ));
                    }
                    if (taxcode_excluded != "") {
                        query2 = QHS.AppAnd(query2, QHS.FieldNotInList("taxcode", taxcode_excluded));
                    }
                    // Le addizionali da rateizzare le abbiamo aggiunte come ritenute arretrate e quindi
                    // si discriminano dalle altre arretrate (che provengono da CAF)
                    if (!consideraRitenuteDaCaf(rowComunicazioneDaCaf)) {
                        query2 = QHS.AppAnd(query2,
                            QHS.DoPar(QHS.AppOr(QHS.CmpNe("taxkind", 5),
                                QHS.FieldInList("taxcode", taxlocalcode_included))));
                    }
                    break;
                }
            }
            return query2;
        }

        /// <summary>
        /// Cancella tutte le righe figlie della riga di cedolino
        /// </summary>
        /// <param name="rCedolino">Riga padre delle righe da cancellare</param>
        private void cancellaFigliDiCedolino(DataRow rCedolino) {
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltax")) {
                foreach (DataRow r2 in r.GetChildRows("payrolltaxpayrolltaxbracket")) {
                    r2.Delete();
                }
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrollabatement")) {
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolldeduction")) {
                r.Delete();
            }
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltaxcorrige")) {
                r.Delete();
            }
        }

        #region Metodi di Debug

        /// <summary>
        /// Metodo di debug; stampa la chiamata alla sp per il calcolo delle deduzioni
        /// </summary>
        /// <param name="spdeduzione"></param>
        /// <param name="natura"></param>
        /// <param name="iddeduzione"></param>
        /// <param name="idcedolino"></param>
        /// <param name="idcontratto"></param>
        /// <param name="codicecreddeb"></param>
        /// <param name="ritenuteApplicate"></param>
        /// <param name="DataInizio"></param>
        /// <param name="DataFine"></param>
        private void stampaChiamataDeduzioni(
            string spdeduzione,
            string natura,
            int iddeduzione,
            int idcedolino,
            string idcontratto,
            int codicecreddeb,
            decimal imponibileriferimento,
            decimal ritenuteApplicate,
            DateTime DataInizio,
            DateTime DataFine
        ) {
            decimal imponibilepregressonetto = -999999;
            string codiceimponibile = "CODICE IMPONIBILE";

            object[] pars = new object[] {
                natura, iddeduzione, idcontratto, idcedolino, codicecreddeb,
                //annorif,meserif,
                DataInizio, DataFine,
                imponibilepregressonetto,
                //DBNull.Value, //Tipo calcolo, non utilizzato per ora
                codiceimponibile,
                imponibileriferimento,
                ritenuteApplicate,
                0, 0
            };
            string[] paramName = new string[] {
                "@natura", "@iddeduzione", "@idcontratto", "@idcedolino", "@codicecreddeb",
                //"@esercizio","@meseriferimento",
                "@datainizio", "@datafine",
                "@imponibile_pregresso_netto",
                //"@tipocalcolo",
                "@codiceimponibile",
                "@imponibilelordo",
                "@contributiversati",
                //								"@importo_deduzione_pregresso",
                "@importo_deduzione",
                "@deduzioneannua"
            };
            SqlDbType[] paramType = new SqlDbType[] {
                SqlDbType.Char, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int,
                //SqlDbType.Int,SqlDbType.Int,
                SqlDbType.DateTime, SqlDbType.DateTime,
                SqlDbType.Decimal,
                //SqlDbType.Char,
                SqlDbType.VarChar,
                SqlDbType.Decimal,
                SqlDbType.Decimal,
                SqlDbType.Decimal,
                SqlDbType.Decimal
            };
            int[] paramTypeLength = new int[] {
                0, 0, 0, 0, 0,
                //0,0,
                0, 0,
                0,
                //1,
                10,
                0,
                //0,
                0, 0, 0
            };
            ParameterDirection[] paramDirection = new ParameterDirection[] {
                ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input,
                ParameterDirection.Input,
                //INPUT,INPUT,INPUT,INPUT,
                ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input,
                ParameterDirection.Input, ParameterDirection.Input, ParameterDirection.Input,
                ParameterDirection.Output, ParameterDirection.Output
            };
            // Commentata x velocizzare il processo
            //stampaChiamataSP(spdeduzione, paramName, paramDirection, pars);
        }

        /// <summary>
        /// Metodo di debug; confronta la tabella nel dataset (filtrata per idcedolino)
        /// con la corrispondente tabella nel db e stampa le differenze
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="nomeTabella"></param>
        /// <param name="result"></param>
        /// <param name="idCedolino"></param>
        /// <param name="DSCococo"></param>
        /// <returns></returns>
        private static bool confrontaTabelle(DataAccess Conn, string nomeTabella, bool result,
            int idCedolino, vistaForm DSCococo
        ) {
            CQueryHelper QHC = new CQueryHelper();
            string filtroCedolino = QHC.CmpEq("idpayroll", idCedolino);
            StringCollection sc = new StringCollection();
            sc.AddRange(new string[] {"createuser", "createtimestamp", "lastmoduser", "lastmodtimestamp"});
            Console.WriteLine(nomeTabella);
            DataRow[] r1 = DSCococo.Tables[nomeTabella].Select(filtroCedolino);
            DataTable tabella = Conn.RUN_SELECT(nomeTabella, null, null, filtroCedolino, null, true);
            if (r1.Length != tabella.Rows.Count) {
                Console.WriteLine("LUNGHEZZA cococo = " + r1.Length + ";  LUNGHEZZA cedolino = " + tabella.Rows.Count);
                result = false;
            }
            int i = 0;
            foreach (DataRow r in r1) {
                string filtroRit = QueryCreator.WHERE_KEY_CLAUSE(r, DataRowVersion.Current, false);
                DataRow[] rRitContratto = tabella.Select(filtroRit);
                if (rRitContratto.Length == 0) continue;
                DataRow rRitContr = rRitContratto[0];
                Console.WriteLine(i + " //////////// " + filtroRit);
                foreach (DataColumn c in DSCococo.Tables[nomeTabella].Columns) {
                    if (!sc.Contains(c.ColumnName) && !r[c].Equals(rRitContr[c.ColumnName])) {
                        Console.WriteLine(i + " - " + c.ColumnName + ": " + r[c] + " != " + rRitContr[c.ColumnName]);
                        result = false;
                    }
                }
                i++;
            }
            Console.WriteLine();
            return result;
        }

        /// <summary>
        /// Metodo di debug; stampa le differenze tra il cedolino presente in DSCococo con quello sul DB
        /// </summary>
        /// <param name="Conn"></param>
        /// <param name="idCedolino"></param>
        /// <param name="DSCococo"></param>
        /// <returns></returns>
        public static bool confrontaRitenuteDiUnCedolino(DataAccess Conn, int idCedolino, vistaForm DSCococo) {
            bool result = true;
            result = confrontaTabelle(Conn, "payrolltax", result, idCedolino, DSCococo);
            result = confrontaTabelle(Conn, "payrolltaxbracker", result, idCedolino, DSCococo);
            result = confrontaTabelle(Conn, "payrolldeduction", result, idCedolino, DSCococo);
            result = confrontaTabelle(Conn, "payrollabatement", result, idCedolino, DSCococo);
            return result;
        }

        /// <summary>
        /// Metodo di debug; stampa la chiamata ad una sp
        /// </summary>
        /// <param name="sp_name"></param>
        /// <param name="ParamName"></param>
        /// <param name="ParamDirection"></param>
        /// <param name="ParamValues"></param>
        private void stampaChiamataSP(
            string sp_name,
            string[] ParamName,
            //			SqlDbType[] paramType,
            ParameterDirection[] ParamDirection,
            object[] ParamValues
        ) {
            int lunghezza = ParamValues.Length;
            Console.WriteLine("//CALCOLI COCOCO");
            Console.WriteLine("exec " + sp_name);

            for (int i = 0; i < lunghezza; i++) {
                string virgola = (i == lunghezza - 1) ? "" : ",";
                /*				string valore = ((paramType[i]==SqlDbType.VarChar)||(paramType[i]==SqlDbType.Char))
                                    ? QueryCreator.quotedstrvalue(ParamValues[i],true)
                                    : ParamValues[i].ToString();*/
                if (ParamDirection[i] == ParameterDirection.Input)
                    Console.WriteLine("\t" + ParamName[i] + "=" + QHS.quote(ParamValues[i]) + virgola);
                else
                    Console.WriteLine("\t" + ParamName[i] + "=" + ParamName[i] + " output" + virgola);
            }

            bool primo = true;
            for (int i = 0; i < lunghezza; i++) {
                if (ParamDirection[i] == ParameterDirection.Output) {
                    string virgola = primo ? "\nselect " : ", ";
                    primo = false;
                    Console.Write(virgola + ParamName[i].Substring(1) + "=" + ParamName[i]);
                }
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Metodo di debug; stampa la chiamata alla sp per il calcolo delle ritenute
        /// </summary>
        /// <param name="rRitenuta"></param>
        /// <param name="rCedolino"></param>
        /// <param name="rContratto"></param>
        /// <param name="codiceritenuta"></param>
        /// <param name="maggioreritenuta"></param>
        /// <param name="annofiscale"></param>
        /// <param name="idcedolino"></param>
        /// <param name="tiporitenuta"></param>
        /// <param name="dataprestazione"></param>
        /// <param name="idpat"></param>
        /// <param name="idcontratto"></param>
        /// <param name="imponibilenetto"></param>
        private void stampaChiamataRitenute2(
            DataRow rRitenuta,
            DataRow rCedolino,
            DataRow rContratto,
            object codiceritenuta,
            decimal maggioreritenuta,
            int annofiscale,
            int idcedolino,
            string tiporitenuta,
            DateTime dataprestazione,
            int idpat,
            string idcontratto,
            decimal imponibilenetto
        ) {
            string principioapplicazione = rRitenuta["appliancebasis"].ToString();
            DateTime datacontabile = (DateTime) MetaCedolino.GetSys("datacontabile");
            int codicecreddeb = (int) rContratto["idreg"];
            string natura = rCedolino["flagbalance"].ToString() == "S" ? "C" : "R";

            object[,] param = new object[,] {
                {"@codiceritenuta", codiceritenuta, SqlDbType.VarChar, 0, ParameterDirection.Input}, {
//0
                    "@maggioreritenuta", maggioreritenuta, SqlDbType.Decimal, 0, ParameterDirection.Input
                }, {
//1
                    "@principioapplicazione", principioapplicazione, SqlDbType.Char, 0, ParameterDirection.Input
                }, {
//2
                    "@datacontabile", datacontabile, SqlDbType.DateTime, 0, ParameterDirection.Input
                }, {
//3
                    "@annofiscale", annofiscale, SqlDbType.Int, 0, ParameterDirection.Input
                }, {
//4
                    "@idcedolino", idcedolino, SqlDbType.Int, 0, ParameterDirection.Input
                }, {
//5
                    "@codicecreddeb", codicecreddeb, SqlDbType.Int, 0, ParameterDirection.Input
                }, {
//6
                    "@tiporitenuta", tiporitenuta, SqlDbType.Char, 0, ParameterDirection.Input
                }, {
//7
                    "@dataprestazione", dataprestazione, SqlDbType.DateTime, 0, ParameterDirection.Input
                }, {
//8
                    "@idpat", idpat, SqlDbType.Int, 0, ParameterDirection.Input
                }, {
//9
                    "@idcontratto", idcontratto, SqlDbType.VarChar, 0, ParameterDirection.Input
                }, {
//10
                    "@imponibilenetto", imponibilenetto, SqlDbType.Decimal, 0, ParameterDirection.Input
                }, {
//11
                    "@natura", natura, SqlDbType.Char, 0, ParameterDirection.Input
                }, {
//12
                    "@ritenuta_dipendente", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//13
                    "@ritenuta_amministrazione", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//14
                    "@quotanumimponibile", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//15
                    "@quotadenimponibile", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//16
                    "@aliquotaamministrazione", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//17
                    "@quotanumamministrazione", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//18
                    "@quotadenamministrazione", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//19
                    "@aliquotadipendente", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//20
                    "@quotanumdipendente", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//21
                    "@quotadendipendente", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                }, {
//22
                    "@ritdipversataannua", 0, SqlDbType.Decimal, 0, ParameterDirection.Output
                } //23
            };
            int lunghezza = param.GetLength(0);
            string[] ParamName = new string[lunghezza];
            SqlDbType[] ParamType = new SqlDbType[lunghezza];
            int[] ParamTypeLength = new int[lunghezza];
            ParameterDirection[] ParamDirection = new ParameterDirection[lunghezza];
            object[] ParamValues = new object[lunghezza];

            for (int i = 0; i < lunghezza; i++) {
                ParamName[i] = (string) param[i, 0];
                ParamValues[i] = param[i, 1];
                ParamType[i] = (SqlDbType) param[i, 2];
                ParamTypeLength[i] = (int) param[i, 3];
                ParamDirection[i] = (ParameterDirection) param[i, 4];
            }
            // Commentata x velocizzare il processo
            //stampaChiamataSP("calcola_una_ritenuta", ParamName, ParamDirection, ParamValues);
        }

        #endregion

        /// <summary>
        /// Metodo che effettua i controlli preventivi. Se non sono rispettati non avviene il calcolo del cedolino
        /// </summary>
        /// <param name="idCedolino"></param>
        /// <returns></returns>
        private string eseguiControlliPreventivi(object idCedolino) {
            // Recupero dei dati inerenti al cedolino ed al contratto al quale appartiene
            string filtroCedolino = QHC.CmpEq("idpayroll", idCedolino);
            DataRow[] rCedolino = DS.payroll.Select(filtroCedolino);
            if (rCedolino.Length == 0) {
                return null;
            }

            string filtroContratto = QHC.CmpEq("idcon", rCedolino[0]["idcon"]);
            DataRow[] rContratto = DS.parasubcontract.Select(filtroContratto);
            if (rContratto.Length == 0) {
                return null;
            }
            object idser = rContratto[0]["idser"];
            if ((idser == null) || (idser == DBNull.Value)) {
                return "Non è stata selezionata la prestazione";
            }
            if (rContratto[0]["start"] == DBNull.Value) {
                return "Non è stata inserita la data inizio nel contratto.";
            }
            if (rContratto[0]["stop"] == DBNull.Value) {
                return "Non è stata inserita la data fine nel contratto.";
            }
            if (rCedolino[0]["start"] == DBNull.Value) {
                return "Manca la data inizio nel cedolino.";
            }
            if (rCedolino[0]["stop"] == DBNull.Value) {
                return "Manca la data fine nel cedolino.";
            }



            int idreg = CfgFn.GetNoNullInt32(rContratto[0]["idreg"]);
            object idDomFiscale = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");
            int annoFiscale = Convert.ToInt32(rCedolino[0]["fiscalyear"]);
            DateTime primoDellAnno = new DateTime(annoFiscale, 01, 01);
            DataTable T = verificaAddizionaliPrestazione(Conn, idser, "C");
            if ((T != null) && (T.Rows.Count > 0)) {
                // Verifico l'esistenza di un domicilio fiscale / indirizzo residenza valido al 1 gennaio

                object idComuneAddComunale = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
                if ((idComuneAddComunale == DBNull.Value) || (idComuneAddComunale == null)) {
                    return "In riferimento all'applicazione delle addizionali comunali non esiste "
                           + "\nun domicilio fiscale o un indirizzo di residenza valido al " +
                           primoDellAnno.ToShortDateString()
                           + "\nper il percipiente del contratto. ";
                }
            }

            DataTable TGeo = verificaAddizionaliPrestazione(Conn, idser, "R");
            if ((TGeo != null) && (TGeo.Rows.Count > 0)) {
                // Verifico l'esistenza di un domicilio fiscale / indirizzo residenza valido il primo giorno dell'anno
                object idComuneAddRegionale = calcolaComuneIndirizzoValido(Conn, idreg, primoDellAnno);
                if ((idComuneAddRegionale == DBNull.Value) || (idComuneAddRegionale == null)) {
                    return "In riferimento all'applicazione delle addizionali regionali non esiste "
                           + "\nun domicilio fiscale o un indirizzo di residenza valido al " +
                           primoDellAnno.ToShortDateString()
                           + "\nper il percipiente del contratto. ";
                }
            }

            if (rCedolino[0]["flagbalance"].ToString().ToUpper() == "S") return null;

            // Controllo 1. Validità della PAT
            string filtroPat = QHC.CmpEq("idpat", rContratto[0]["idpat"]);
            DataRow[] rPat = DS.pat.Select(filtroPat);

            if (rPat.Length == 0) {
                return null;
            }
            if (rPat[0]["validitystart"] == DBNull.Value) {
                return "Impossibile calcolare il cedolino n. " + idCedolino
                       + "\nInserire la data di inizio della Pos. Assic. Terr.";
            }

            if (rPat[0]["validitystop"] == DBNull.Value) {
                return "Impossibile calcolare il cedolino n. " + idCedolino
                       + "\nInserire la data di fine della Pos. Assic. Terr.";
            }

            DateTime dataInizioPat = (DateTime) rPat[0]["validitystart"];
            DateTime dataFinePat = (DateTime) rPat[0]["validitystop"];
            DateTime dataInizioCedolino = (DateTime) rCedolino[0]["start"];
            DateTime dataFineCedolino = (DateTime) rCedolino[0]["stop"];

            bool patValida = (dataInizioPat <= dataInizioCedolino) && (dataFinePat >= dataInizioCedolino);
            if (!patValida) {
                string errMess = "Impossibile calcolare il cedolino n. " + idCedolino
                                 + "\nIl periodo di validità della Pos. Assic. Terr. non è compreso nel cedolino";
                if (dataInizioPat > dataInizioCedolino) {
                    errMess += "\nLa data di inizio validità della P.A.T. (" + dataInizioPat.ToShortDateString()
                               + ") è successiva alla data di inizio del Cedolino (" +
                               dataInizioCedolino.ToShortDateString() + ")";
                }
                if (dataFinePat < dataInizioCedolino) {
                    errMess += "\nLa data di fine validità della P.A.T. (" + dataFinePat.ToShortDateString()
                               + ") è antecedente alla data di inizio del Cedolino (" +
                               dataInizioCedolino.ToShortDateString() + ")";
                }
                return errMess;
            }
            return null;
        }

        /// <summary>
        /// Metodo che restituisce il tipo della ritenuta
        /// </summary>
        /// <param name="codiceRitenuta"></param>
        /// <returns></returns>
        private int ottieniTipoRitenuta(object codiceRitenuta) {
            if ((codiceRitenuta == null) || (codiceRitenuta.ToString() == "")) return 0;
            string filtroRitenuta = QHS.CmpEq("taxcode", codiceRitenuta);
            object tr = Conn.DO_READ_VALUE("tax", filtroRitenuta, "taxkind");
            if (tr == null) return 0;
            return CfgFn.GetNoNullInt32(tr);
        }

        #region Aggiornamento Cedolino di Conguaglio

        /// <summary>
        /// Metodo che aggiunge le ritenute non fiscali nel cedolino di conguaglio
        /// </summary>
        /// <param name="idCedolino">ID del cedolino di conguaglio</param>
        /// <param name="copiaNelDataSetDiPartenza">TRUE: Ricopia le modifiche effettuate nel DataSet del form chiamante; FALSE: Altrimenti</param>
        /// <returns></returns>
        public string aggiungiRitenuteNonFiscaliCedolinoConguaglio(object idCedolino, bool copiaNelDataSetDiPartenza) {
            string errMess = null;
            string filtroCedolinoCong = QHC.CmpEq("idpayroll", idCedolino);
            DataRow rCedolinoConguaglio = DS.payroll.Select(filtroCedolinoCong)[0];
            string filtroCedoliniRata = QHC.CmpMulti(rCedolinoConguaglio, "idcon", "fiscalyear");
            filtroCedoliniRata = QHC.AppAnd(filtroCedoliniRata, QHC.CmpEq("flagbalance", "N"));
            // Si ottiene l'elenco di tutti i cedolini rata
            DataRow[] rCedoliniRata = DS.payroll.Select(filtroCedoliniRata);
            // Per ogni cedolino rata
            foreach (DataRow cedolinoRata in rCedoliniRata) {
                string filtroCedolinoRata = QHC.CmpEq("idpayroll", cedolinoRata["idpayroll"]);

                // Si ottiene l'elenco delle ritenute del cedolino
                DataRow[] rPayRollTax = DS.payrolltax.Select(filtroCedolinoRata, "idpayroll");
                // Per ogni ritenuta, se fiscale si esce altrimenti si procede
                foreach (DataRow rCedRit in rPayRollTax) {
                    int taxkind = ottieniTipoRitenuta(rCedRit["taxcode"]);
                    if (taxkind == 1) continue;

                    // Si verifica che esista una ritenuta analoga nel cedolino di conguaglio
                    string filtroCedRit = QHC.CmpEq("taxcode", rCedRit["taxcode"]);
                    filtroCedRit = GetData.MergeFilters(filtroCedRit, filtroCedolinoCong);
                    DataRow[] rCedRitConguaglio = DS.payrolltax.Select(filtroCedRit);
                    DataRow newCedRitConguaglio;
                    // Se è presente aggiorna il dato sommando il contributo del cedolino rata corrente
                    if (rCedRitConguaglio.Length > 0) {
                        // Aggiorna riga in payrolltax
                        newCedRitConguaglio = rCedRitConguaglio[0];
                        foreach (string col in new string[] {
                            "admintax", "employtax", "employtaxgross",
                            "deduction", "abatements", "taxablegross", "taxablenet", "annualtaxabletotal"
                        }) {
                            newCedRitConguaglio[col] = CfgFn.GetNoNullDecimal(newCedRitConguaglio[col]) +
                                                       CfgFn.GetNoNullDecimal(rCedRit[col]);
                        }
                        newCedRitConguaglio["taxablenumerator"] = rCedRit["taxablenumerator"];
                        newCedRitConguaglio["taxabledenominator"] = rCedRit["taxabledenominator"];

                        newCedRitConguaglio["annualpayedemploytax"] =
                            CfgFn.GetNoNullDecimal(newCedRitConguaglio["annualpayedemploytax"])
                            + CfgFn.GetNoNullDecimal(rCedRit["employtax"]);

                        newCedRitConguaglio["annualcreditapplied"] =
                            CfgFn.GetNoNullDecimal(newCedRitConguaglio["annualcreditapplied"])
                            + CfgFn.GetNoNullDecimal(rCedRit["employtax"]);
                    }
                    // Altrimenti si crea una nuova riga della ritenuta nel cedolino di conguaglio ponendo i dati
                    // pari a quelli del cedolino rata processato
                    else {
                        newCedRitConguaglio = MetaCedolinoRitenuta.Get_New_Row(rCedolinoConguaglio, DS.payrolltax);
                        foreach (DataColumn C in DS.payrolltax.Columns) {
                            if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")) continue;
                            if (C.ColumnName == "annualpayedemploytax") {
                                newCedRitConguaglio[C.ColumnName] = rCedRit["employtax"];
                                continue;
                            }
                            if (C.ColumnName == "annualcreditapplied") {
                                newCedRitConguaglio[C.ColumnName] = rCedRit["employtax"];
                                continue;
                            }
                            newCedRitConguaglio[C.ColumnName] = rCedRit[C];
                        }
                    }

                    // Si aggiungono gli scaglioni della ritenuta nel cedolino di conguaglio
                    aggiungiScaglioniCedolinoConguaglio(cedolinoRata["idpayroll"], rCedRit, newCedRitConguaglio);
                    RimuoviScaglioniVuoti(DS.payrolltaxbracket, newCedRitConguaglio);
                }

                // Si aggiungono le deduzioni nel cedolino di conguaglio
                aggiungiDeduzioniCedolinoConguaglio(cedolinoRata["idpayroll"], rCedolinoConguaglio);
                // Si aggiungono le detrazioni nel cedolino di conguaglio
                aggiungiDetrazioniCedolinoConguaglio(cedolinoRata["idpayroll"], rCedolinoConguaglio);
            }
            // Si ricalcola il compenso netto del cedolino di conguaglio
            calcolaCompensoNetto(rCedolinoConguaglio);
            // Si ricopiano i dati del dataset locale nel dataset del form chiamante
            if (copiaNelDataSetDiPartenza) {
                copiaVistaCalcoloCedolinoInDS(idCedolino);
            }
            return errMess;
        }

        void RimuoviScaglioniVuoti(DataTable PayrollTaxBracket, DataRow CedRit) {
            string filter = QHC.AppAnd(QHC.MCmp(CedRit, "idpayroll", "idpayrolltax"),
                QHC.CmpEq("employtax", 0), QHC.CmpEq("admintax", 0), QHC.CmpEq("taxable", 0));
            foreach (DataRow R in PayrollTaxBracket.Select(filter)) R.Delete();
        }

        /// <summary>
        /// Metodo che aggiunge gli scaglioni nel cedolino di conguaglio
        /// </summary>
        /// <param name="idCedolinoRata"></param>
        /// <param name="cedolinoRitenutaRata"></param>
        /// <param name="parentConguaglio"></param>
        private void aggiungiScaglioniCedolinoConguaglio(object idCedolinoRata, DataRow cedolinoRitenutaRata,
            DataRow parentConguaglio) {
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", idCedolinoRata);
            string filtroCedolinoCong = QHC.CmpEq("idpayroll", parentConguaglio["idpayroll"]);
            string filtroScagl = QHC.AppAnd(filtroCedolinoRata,
                QHC.MCmp(cedolinoRitenutaRata, "idpayrolltax"));
            // Si ottiene l'elenco degli scaglioni associati ad una fissata ritenuta e cedolino rata
            DataRow[] rPayRollTaxBracket = DS.payrolltaxbracket.Select(filtroScagl);
            // Per ogni scaglione si verifica se è presente nel cedolino di conguaglio
            foreach (DataRow rScagl in rPayRollTaxBracket) {
                string filtroCedRitScagl = QHC.AppAnd(filtroCedolinoCong,
                    QHC.CmpEq("idpayrolltax", parentConguaglio["idpayrolltax"]));
                //QHC.MCmp(rScagl, "employrate", "adminrate"));
                DataRow found = null;
                rScagl["employrate"] = CfgFn.GetNoNullDecimal(rScagl["employrate"]);
                rScagl["adminrate"] = CfgFn.GetNoNullDecimal(rScagl["adminrate"]);
                foreach (DataRow RR in DS.payrolltaxbracket.Select(filtroCedRitScagl)) {
                    if (CfgFn.GetNoNullDecimal(RR["employrate"]) !=
                        CfgFn.GetNoNullDecimal(rScagl["employrate"])) continue;
                    if (CfgFn.GetNoNullDecimal(RR["adminrate"]) != CfgFn.GetNoNullDecimal(rScagl["adminrate"]))
                        continue;
                    found = RR;
                    break;
                }
                //DataRow [] rBracket = DS.payrolltaxbracket.Select(filtroCedRitScagl);
                // Se presente si somma il valore presente nel cedolino di conguaglio con quello del cedolino rata corrente
                if (found != null) {
                    foreach (string col in new string[] {"taxable", "employtax", "admintax"})
                        found[col] = CfgFn.GetNoNullDecimal(found[col]) + CfgFn.GetNoNullDecimal(rScagl[col]);
                }
                // Altrimenti si crea una nuova riga ponendo gli importi pari a quelli del cedolino rata corrente
                else {
                    DataRow newCedConguaglioRitScagl =
                        MetaCedolinoRitenutaScaglione.Get_New_Row(parentConguaglio, DS.payrolltaxbracket);
                    foreach (DataColumn C in DS.payrolltaxbracket.Columns) {
                        if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")
                            || (C.ColumnName == "nbracket")) continue;
                        if (C.ColumnName == "ct" || C.ColumnName == "cu" || C.ColumnName == "lt" ||
                            C.ColumnName == "lu")
                            newCedConguaglioRitScagl[C.ColumnName] = rScagl[C];
                        else
                            newCedConguaglioRitScagl[C.ColumnName] = CfgFn.GetNoNullDecimal(rScagl[C]);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo che aggiunge le deduzioni associate ad imponibili non fiscali e non addizionali nel cedolino di conguaglio
        /// </summary>
        /// <param name="idCedolinoRata"></param>
        /// <param name="parentConguaglio"></param>
        private void aggiungiDeduzioniCedolinoConguaglio(object idCedolinoRata, DataRow parentConguaglio) {
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", idCedolinoRata);
            // Si ottiene l'elenco delle deduzioni del cedolino rata
            DataRow[] rDeduzioneRata = DS.payrolldeduction.Select(filtroCedolinoRata);
            // Per ogni deduzione se è associata all'imponibile fiscale o per addizionale si esce
            // altrimenti si procede
            foreach (DataRow rDedRata in rDeduzioneRata) {
                string filtroDeduzione = QHC.CmpEq("iddeduction", rDedRata["iddeduction"]);
                DataRow deduzione = DS.deduction.Select(filtroDeduzione)[0];
                if ((deduzione["taxablecode"].ToString() == "IRPEF")
                    || (deduzione["taxablecode"].ToString() == "ADDIRPEF")) continue;
                string filtroCedolinoCong = QHC.CmpEq("idpayroll", parentConguaglio["idpayroll"]);
                // Si verifica la presenza della deduzione nel cedolino di conguaglio
                DataRow[] rDeduzioneConguaglio = DS.payrolldeduction.Select(filtroCedolinoCong);
                // Se presente si sommano i dati del conguaglio con quelli del cedolino rata
                if (rDeduzioneConguaglio.Length > 0) {
                    foreach (string col in new string[] {"annualamount", "curramount"}) {
                        rDeduzioneConguaglio[0][col] = CfgFn.GetNoNullDecimal(rDeduzioneConguaglio[0][col])
                                                       + CfgFn.GetNoNullDecimal(rDedRata[col]);
                    }
                }
                // Altrimenti si crea una nuova riga con i dati del cedolino rata
                else {
                    DataRow newDeduzioneConguaglio =
                        MetaDettaglioDeduzioneCedolino.Get_New_Row(parentConguaglio, DS.payrolldeduction);
                    foreach (DataColumn C in DS.payrolldeduction.Columns) {
                        if (C.ColumnName == "idpayroll") continue; //|| (C.ColumnName == "iddeduction")) 
                        newDeduzioneConguaglio[C.ColumnName] = rDedRata[C];
                    }
                }
            }
        }

        /// <summary>
        /// Metodo che aggiunge le detrazioni associate a ritenute non fiscali nel cedolino di conguaglio
        /// </summary>
        /// <param name="idCedolinoRata"></param>
        /// <param name="parentConguaglio"></param>
        private void aggiungiDetrazioniCedolinoConguaglio(object idCedolinoRata, DataRow parentConguaglio) {
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", idCedolinoRata);
            // Si ottiene l'elenco delle detrazioni del cedolino rata
            DataRow[] rDetrazioneRata = DS.payrollabatement.Select(filtroCedolinoRata);
            // Per ogni detrazione se è associata ad una ritenuta fiscale si esce altrimenti si procede
            foreach (DataRow rDetRata in rDetrazioneRata) {
                string filtroDetrazione = QHC.CmpMulti(rDetRata, "idabatement");
                DataRow detrazione = DS.abatement.Select(filtroDetrazione)[0];
                int tipoRitenuta = ottieniTipoRitenuta(detrazione["taxcode"]);
                if (tipoRitenuta == 1) continue;
                // Si verifica la presenza della detrazione nel cedolino di conguaglio
                string filtroCedolinoCong = QHC.CmpMulti(parentConguaglio, "idpayroll");
                DataRow[] rDetrazioneConguaglio = DS.payrollabatement.Select(filtroCedolinoCong);
                // Se esiste la detrazione si sommano i valori presenti nel conguaglo con quelli del cedolino rata
                if (rDetrazioneConguaglio.Length > 0) {
                    foreach (string col in new string[] {"annualamount", "curramount"}) {
                        rDetrazioneConguaglio[0][col] = CfgFn.GetNoNullDecimal(rDetrazioneConguaglio[0][col])
                                                        + CfgFn.GetNoNullDecimal(rDetRata[col]);
                    }
                }
                // Altrimenti si crea una nuova riga copiando i dati del cedolino rata
                else {
                    DataRow newDetrazioneConguaglio =
                        MetaDettaglioDetrazioneCedolino.Get_New_Row(parentConguaglio, DS.payrollabatement);
                    foreach (DataColumn C in DS.payrollabatement.Columns) {
                        if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idabatement")) continue;
                        newDetrazioneConguaglio[C.ColumnName] = rDetRata[C];
                    }
                }
            }
        }

        /// <summary>
        /// Metodo che cancella le ritenute fiscali dal cedolino di conguaglio.
        /// </summary>
        /// <param name="idCedolinoConguaglio"></param>
        private void cancellaRitenuteFiscaliConguaglio(object idCedolinoConguaglio) {
            string filtroConguaglio = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            DataRow rCedolinoConguaglio = DS.payroll.Select(filtroConguaglio)[0];
            // Per ogni ritenuta presente nel conguaglio se non fiscale si esce altrimenti si procede
            // alla cancellazione della ritenuta e degli scaglioni associati
            foreach (DataRow rRitenutaConguaglio in DS.payrolltax.Select(filtroConguaglio)) {
                int tipoRitenuta = ottieniTipoRitenuta(rRitenutaConguaglio["taxcode"]);
                if (tipoRitenuta != 1) continue;
                string filtroScaglioni =
                    QHC.AppAnd(filtroConguaglio, QHC.CmpMulti(rRitenutaConguaglio, "idpayrolltax"));
                foreach (DataRow rScaglioni in DS.payrolltaxbracket.Select(filtroScaglioni)) {
                    rScaglioni.Delete();
                }
                rRitenutaConguaglio.Delete();
            }
        }

        /// <summary>
        /// Metodo che aggiorna i dati del cedolino di conguaglio
        /// </summary>
        /// <param name="idCedolinoConguaglio"></param>
        /// <param name="copiaNelDataSetDiPartenza"></param>
        /// <returns></returns>
        public string aggiornaDatiCedolinoConguaglio(int idCedolinoConguaglio,
            bool copiaNelDataSetDiPartenza) {
            string errMess = null;
            string filtroConguaglio = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            DataRow rCedolinoConguaglio = DS.payroll.Select(filtroConguaglio)[0];
            // Questo metodo viene richiamato in quanto dobbiamo ricopiare nel conguaglio la somma delle ritenute
            // fiscali dei cedolini rata
            cancellaRitenuteFiscaliConguaglio(idCedolinoConguaglio);
            string filtroCedoliniRata = QHC.AppAnd(QHC.CmpEq("idcon", rCedolinoConguaglio["idcon"]),
                QHC.CmpEq("flagbalance", "N"), QHC.CmpEq("fiscalyear", rCedolinoConguaglio["fiscalyear"]));

            // Si ottiene l'elenco dei cedolini rata e per ognuno di essi
            // si estraggono le ritenute fiscali e si verifica se la ritenuta è presente nel conguaglio
            // se è presente si sommano i dati altrimenti si crea una nuova riga ricopiando i dati dal cedolino rata
            foreach (DataRow rCedolinoRata in DS.payroll.Select(filtroCedoliniRata)) {
                string filtroCedolino = QHC.CmpEq("idpayroll", rCedolinoRata["idpayroll"]);
                // Si ottiene l'elenco delle ritenute del cedolino rata corrente
                DataRow[] rRitenuteCedolino = DS.payrolltax.Select(filtroCedolino);
                // Per ogni ritenuta se essa non è fiscale si esce altrimenti si procede
                foreach (DataRow rRitenuta in rRitenuteCedolino) {
                    int tipoRitenuta = ottieniTipoRitenuta(rRitenuta["taxcode"]);
                    if (tipoRitenuta != 1) continue;
                    // Si verifica la presenza della ritenuta nel cedolino di conguaglio
                    string filtroRitenutaConguaglio = QHC.AppAnd(QHC.CmpEq("idpayroll", idCedolinoConguaglio),
                        QHC.CmpEq("taxcode", rRitenuta["taxcode"]));
                    DataRow[] rRitenutaConguaglio = DS.payrolltax.Select(filtroRitenutaConguaglio);
                    DataRow newCedRitConguaglio;
                    // Se presente si sommano i dati del cedolio di conguaglio con quelli del cedolino rata corrente
                    if (rRitenutaConguaglio.Length > 0) {
                        newCedRitConguaglio = rRitenutaConguaglio[0];
                        foreach (string col in new string[] {
                            "admintax", "employtax",
                            "employtaxgross", "deduction",
                            "abatements", "taxablegross", "annualpayedemploytax", "annualcreditapplied",
                            "taxablenet", "annualtaxabletotal"
                        }) {
                            newCedRitConguaglio[col] = CfgFn.GetNoNullDecimal(newCedRitConguaglio[col]) +
                                                       CfgFn.GetNoNullDecimal(rRitenuta[col]);
                        }
                    }
                    // Altrimenti si crea una nuova riga con i dati del cedolino rata
                    else {
                        newCedRitConguaglio = MetaCedolinoRitenuta.Get_New_Row(rCedolinoConguaglio, DS.payrolltax);
                        foreach (DataColumn C in DS.payrolltax.Columns) {
                            if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")) continue;
                            newCedRitConguaglio[C.ColumnName] = rRitenuta[C];
                        }
                    }
                    // Si aggiungono gli scaglioni della ritenuta al cedolino di conguaglio
                    aggiungiScaglioniCedolinoConguaglio(CfgFn.GetNoNullInt32(rCedolinoRata["idpayroll"]),
                        rRitenuta, newCedRitConguaglio);
                    RimuoviScaglioniVuoti(DS.payrolltaxbracket, newCedRitConguaglio);
                }
            }
            // Si ricalcola il compenso netto del cedolino di conguaglio
            calcolaCompensoNetto(rCedolinoConguaglio);
            // Si ricopiano le modifiche del dataset locale nel dataset del form chiamante
            if (copiaNelDataSetDiPartenza) {
                copiaVistaCalcoloCedolinoInDS(idCedolinoConguaglio);
            }
            return errMess;
        }

        #endregion

        #region Aggiornamento Ultimo Cedolino Rata

        /// <summary>
        /// Metodo che inserisce le ritenute fiscali nell'ultimo cedolino rata
        /// L'ultimo cedolino rata rispetta la seguente equazione:
        /// Dato = Dato Conguaglio - SOMMA(Dati altri cedolini rata)
        /// </summary>
        /// <param name="idCedolinoRata">ID dell'ultimo cedolino rata</param>
        /// <param name="idCedolinoConguaglio">ID del cedolino di conguaglio</param>
        /// <param name="copiaNelDataSetDiPartenza">TRUE: Copia le modifiche nel DataSet del form chiamante; FALSE: Altrimenti</param>
        /// <returns></returns>
        public string aggiungiRitenuteFiscaliUltimoCedolinoRata(object idCedolinoRata,
            object idCedolinoConguaglio,
            bool copiaNelDataSetDiPartenza) {
            DataRow cedolinoRata = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolinoRata))[0];
            string filtro = QHC.CmpMulti(cedolinoRata, "fiscalyear", "idcon", "flagbalance");
            filtro = QHC.AppAnd(filtro, QHC.CmpNe("idpayroll", idCedolinoRata));
            // Si ottiene l'elenco dei cedolini rata del contratto (tranne l'ultimo)
            DataRow[] altriCedoliniRata = DS.payroll.Select(filtro);
            string elencoCedolini = QHC.DistinctVal(altriCedoliniRata, "idpayroll");

            string filtroConguaglio = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            // Si ottiene l'elenco delle ritenute presenti nel conguaglio
            DataRow[] ritenuteConguaglio = DS.payrolltax.Select(filtroConguaglio);
            // Per ogni ritenuta presente nel conguaglio
            // se non è fiscale si esce altrimenti si procede
            // In tal caso si estrae il taxcode (chiave della ritenuta) e si verifica se la stessa
            // sia presente nell' ultimo cedolino rata, se presente si seleziona la riga, altrimenti se ne crea una nuova.
            // Sulla riga selezionata (o creata) si ricopiano i dati del cedolino di conguaglio e successivamente si sottraggono
            // quelli degli altri cedolini rata
            foreach (DataRow rRitenutaConguaglio in ritenuteConguaglio) {
                int tipoRitenuta = ottieniTipoRitenuta(rRitenutaConguaglio["taxcode"]);
                if (tipoRitenuta != 1) continue;
                string filtroRitenuta = QHC.CmpEq("taxcode", rRitenutaConguaglio["taxcode"]);
                string filtroUltimoCedolinoRata = QHC.AppAnd(filtroRitenuta, QHC.CmpEq("idpayroll", idCedolinoRata));
                DataRow[] rRitenutaRata = DS.payrolltax.Select(filtroUltimoCedolinoRata);
                DataRow newRitenutaRata;
                if (rRitenutaRata.Length > 0) {
                    newRitenutaRata = rRitenutaRata[0];
                }
                else {
                    newRitenutaRata = MetaCedolinoRitenuta.Get_New_Row(cedolinoRata, DS.payrolltax);
                    newRitenutaRata["taxcode"] = rRitenutaConguaglio["taxcode"];
                }
                // Si ricopiano i dati presenti nel cedolino di conguaglio
                foreach (string colname in new string[] {
                    "admintax", "employtaxgross",
                    "annualpayedemploytax", "annualcreditapplied", "deduction",
                    "abatements", "taxablegross",
                    "taxablenet", "annualtaxabletotal",
                    "taxablenumerator", "taxabledenominator",
                    "idcity", "idfiscaltaxregion"
                }) {
                    newRitenutaRata[colname] = rRitenutaConguaglio[colname];
                }
                newRitenutaRata["employtax"] = CfgFn.GetNoNullDecimal(rRitenutaConguaglio["employtaxgross"])
                                               - CfgFn.GetNoNullDecimal(rRitenutaConguaglio["abatements"])
                                               //06.04.2006 Sottraendo aggiunto per determinare la ritenuta c/dip netta
                                               - CfgFn.GetNoNullDecimal(rRitenutaConguaglio["annualpayedemploytax"]);

                // Si sottraggono i dati presenti dagli altri cedolini rata
                sottraiSommeCedoliniRataDaConguaglio(elencoCedolini, "payrolltax", "taxcode",
                    newRitenutaRata["taxcode"],
                    new string[] {
                        "admintax", "employtax", "employtaxgross",
                        "annualpayedemploytax", "annualcreditapplied", "deduction",
                        "abatements", "taxablegross",
                        "taxablenet", "annualtaxabletotal"
                    }, newRitenutaRata);

                //decimal ritLorda = CfgFn.GetNoNullDecimal(newRitenutaRata["employtaxgross"]);
                //decimal detrazione = CfgFn.GetNoNullDecimal(newRitenutaRata["abatements"]);
                //if (ritLorda <= detrazione) {
                //    newRitenutaRata["abatements"] = newRitenutaRata["employtaxgross"];
                //    newRitenutaRata["employtax"] = 0;
                //}

                // Si aggiungono gli scaglioni inerenti alla ritenuta processata nell'ultimo cedolino rata
                aggiungiScaglioniUltimoCedolinoRata(rRitenutaConguaglio, elencoCedolini, newRitenutaRata);
                // Si calcolano le aliquote medie c/dipendente e c/amministrazione
                calcolaAliquotaAmmDip(newRitenutaRata);
            }
            // Si aggiungono le deduzioni nell'ultimo cedolino rata
            aggiungiDeduzioniUltimoCedolinoRata(elencoCedolini, idCedolinoRata, idCedolinoConguaglio);
            // Si aggiungono le detrazioni nell'ultimo cedolino rata
            aggiungiDetrazioniUltimoCedolinoRata(elencoCedolini, idCedolinoRata, idCedolinoConguaglio);
            // Si aggiungono gli storni nell'ultimo cedolino rata
            aggiungiStorniUltimoCedolinoRata(idCedolinoRata, idCedolinoConguaglio);
            // Si ricalcola il compenso netto dell'ultimo cedolino rata
            calcolaCompensoNetto(cedolinoRata);

            // Ricopiatura dei dati presenti nel dataset di questa classe nel dataset del form chiamante
            if (copiaNelDataSetDiPartenza) {
                copiaVistaCalcoloCedolinoInDS(idCedolinoRata);
            }
            return null;
        }

        /// <summary>
        /// Metodo che imposta l'aliquota media nella tabella PAYROLLTAX
        /// </summary>
        /// <param name="rCedolinoRitenuta">DataRow di payrolltax da modificare</param>
        private void calcolaAliquotaAmmDip(DataRow rCedolinoRitenuta) {
            //decimal imponibileNonRapportato = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["taxablenet"]);
            //decimal imponibileNetto = 0;
            //foreach (DataRow rCedScagl in rCedolinoRitenuta.GetChildRows("payrolltaxpayrolltaxbracket")) {
            //    imponibileNetto += CfgFn.GetNoNullDecimal(rCedScagl["taxable"]);
            //}

            decimal imponibileNetto = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["taxablenet"]);
            decimal ritDip = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["employtaxgross"]);
            decimal ritAmm = CfgFn.GetNoNullDecimal(rCedolinoRitenuta["admintax"]);

            decimal rapporto = getRapporto(CfgFn.GetNoNullDecimal(rCedolinoRitenuta["taxablenumerator"]),
                CfgFn.GetNoNullDecimal(rCedolinoRitenuta["taxabledenominator"]));
            // L'aliquota media c/dipendente è data dal rapporto tra l'imponibile netto e la ritenuta lorda c/dipendente
            if ((ritDip > 0) && (imponibileNetto != 0)) {
                rCedolinoRitenuta["employrate"] = CfgFn.GetNoNullDecimal(ritDip / (imponibileNetto));
            }

            // L'aliquota media c/amministrazione è data dal rapporto tra l'imponibile netto e la ritenuta lorda c/dipendente
            if ((ritAmm > 0) && (imponibileNetto != 0)) {
                rCedolinoRitenuta["adminrate"] = CfgFn.GetNoNullDecimal(ritAmm / (imponibileNetto));
            }
        }

        /// <summary>
        /// Metodo che aggiunge gli scaglioni all'ultimo cedolino rata secondo la formula:
        /// Importo_Ultimo_Cedolino_Rata = Importo_Cedolino_Conguaglio - SOMMA(Importo_Altri_Cedolini_Rata)
        /// </summary>
        /// <param name="rRitenutaConguaglio"></param>
        /// <param name="elencoAltriCedoliniRata"></param>
        /// <param name="parentRata"></param>
        private void aggiungiScaglioniUltimoCedolinoRata(DataRow rRitenutaConguaglio,
            string elencoAltriCedoliniRata, DataRow parentRata) {
            string filtroCedolinoCong = QHC.CmpEq("idpayroll", rRitenutaConguaglio["idpayroll"]);
            string filtroCedolinoRata = QHC.CmpEq("idpayroll", parentRata["idpayroll"]);
            string filtroScaglioneConguaglio = QHC.AppAnd(filtroCedolinoCong,
                QHC.CmpEq("idpayrolltax", rRitenutaConguaglio["idpayrolltax"]));
            // Si ottiene l'elenco degli scaglioni del cedolino di conguaglio
            DataRow[] scaglioniConguaglio = DS.payrolltaxbracket.Select(filtroScaglioneConguaglio);
            // Per ogni scaglione si verifica la presenza di uno analogo nel cedolino rata
            // se è presente vengono sovrascritti i dati altrimenti si crea una nuova riga inserendo i dati
            // del cedolino di conguaglio.
            // Successivamente si sottraggono i dati presenti negli altri cedolini rata
            foreach (DataRow rScaglioneConguaglio in scaglioniConguaglio) {
                string filtroScaglioneCedolinoRata = QHC.AppAnd(filtroCedolinoRata,
                    QHC.CmpEq("idpayrolltax", parentRata["idpayrolltax"]),
                    QHC.CmpEq("employrate", rScaglioneConguaglio["employrate"]));
                DataRow[] scaglioniCedolinoRata = DS.payrolltaxbracket.Select(filtroScaglioneCedolinoRata);
                if (scaglioniCedolinoRata.Length > 0) {
                    foreach (string col in new string[] {"taxable", "employtax", "admintax"})
                        scaglioniCedolinoRata[0][col] = CfgFn.GetNoNullDecimal(rScaglioneConguaglio[col]);
                }
                else {
                    DataRow newCedRataRitScagl =
                        MetaCedolinoRitenutaScaglione.Get_New_Row(parentRata, DS.payrolltaxbracket);
                    foreach (DataColumn C in DS.payrolltaxbracket.Columns) {
                        if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")
                            || (C.ColumnName == "nbracket")) continue;
                        newCedRataRitScagl[C.ColumnName] = rScaglioneConguaglio[C];
                    }
                }
            }
            // Sottrazione dei dati degli altri cedolini rata
            sottraiSommeScaglioniCedoliniRataDaConguaglio(elencoAltriCedoliniRata, parentRata);
        }

        /// <summary>
        /// Metodo che sottrae gli importi contenuti negli scaglioni dei cedolini rata dall'ultimo cedolino rata
        /// </summary>
        /// <param name="elencoCedolini">Elenco dei cedolini rata precednti all'ultimo</param>
        /// <param name="parentCedRitRata">Riga di payrolltax riferita all'ultimo cedolino rata</param>
        private void sottraiSommeScaglioniCedoliniRataDaConguaglio(string elencoCedolini, DataRow parentCedRitRata) {
            if (elencoCedolini == "") return;
            string filtroRitenutaUltimoCedolinoRata = QHC.CmpMulti(parentCedRitRata, "idpayroll", "idpayrolltax");
            string filtroRitenutaAltriCedoliniRata = QHC.AppAnd(
                "(idpayroll in (" + elencoCedolini + "))", QHC.CmpEq("taxcode", parentCedRitRata["taxcode"]));
            // Si ottiene l'elenco delle ritenute degli altri cedolini rata
            DataRow[] ritenutaAltriCedoliniRata = DS.payrolltax.Select(filtroRitenutaAltriCedoliniRata);
            foreach (DataRow rRitenuraAltriCedoliniRata in ritenutaAltriCedoliniRata) {
                string filtroScaglioneAltriCedoliniRata =
                    QHC.CmpMulti(rRitenuraAltriCedoliniRata, "idpayroll", "idpayrolltax");
                // Si ottiene l'elenco degli scaglioni associata ad una fissata ritenuta di un fissato cedolino rata
                DataRow[] scaglioniAltriCedoliniRata = DS.payrolltaxbracket.Select(filtroScaglioneAltriCedoliniRata);

                // Per ogni scaglione ottenuto in precedenza si verifica se esiste uno scaglione
                // nell'ultimo cedolino rata (il controllo viene fatto sull'aliquota c/dipendente)
                foreach (DataRow rScaglioneAltriCedoliniRata in scaglioniAltriCedoliniRata) {
                    string filtroScaglioneUltimoCedolinoRata = QHC.AppAnd(filtroRitenutaUltimoCedolinoRata,
                        QHC.CmpEq("employrate", rScaglioneAltriCedoliniRata["employrate"]));
                    DataRow[] scaglioniUltimoCedolinoRata =
                        DS.payrolltaxbracket.Select(filtroScaglioneUltimoCedolinoRata);
                    // Se lo scaglione è presente si sottraggono gli importi
                    if (scaglioniUltimoCedolinoRata.Length > 0) {
                        foreach (string colname in new string[] {"taxable", "employtax", "admintax"}) {
                            scaglioniUltimoCedolinoRata[0][colname] =
                                CfgFn.GetNoNullDecimal(scaglioniUltimoCedolinoRata[0][colname])
                                - CfgFn.GetNoNullDecimal(rScaglioneAltriCedoliniRata[colname]);
                        }
                    }
                    // Altrimenti si crea una nuova riga con importi negativi.
                    else {
                        DataRow newScaglioneUltimoCedolinoRata =
                            MetaCedolinoRitenutaScaglione.Get_New_Row(parentCedRitRata, DS.payrolltaxbracket);
                        foreach (DataColumn C in DS.payrolltaxbracket.Columns) {
                            if ((C.ColumnName == "idpayroll") || (C.ColumnName == "idpayrolltax")
                                || (C.ColumnName == "nbracket")) continue;
                            if ((C.ColumnName == "employtax") || (C.ColumnName == "admintax")
                                || (C.ColumnName == "taxable")) {
                                newScaglioneUltimoCedolinoRata[C.ColumnName] =
                                    -CfgFn.GetNoNullDecimal(rScaglioneAltriCedoliniRata[C]);
                            }
                            else {
                                newScaglioneUltimoCedolinoRata[C.ColumnName] = rScaglioneAltriCedoliniRata[C];
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metodo che aggiunge le deduzioni associate agli imponibili fiscale e per addizionale all'ultimo cedolino rata
        /// </summary>
        /// <param name="elencoCedolini"></param>
        /// <param name="idCedolinoRata"></param>
        /// <param name="idCedolinoConguaglio"></param>
        private void aggiungiDeduzioniUltimoCedolinoRata(string elencoCedolini, object idCedolinoRata,
            object idCedolinoConguaglio) {
            DataRow cedolinoRata = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolinoRata))[0];
            string filtroConguaglio = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            // Si ottiene l'elenco delle deduzioni del cedolino di conguaglio
            DataRow[] deduzioniConguaglio = DS.payrolldeduction.Select(filtroConguaglio);
            // Per ogni deduzione se essa è associata all'imponibile fiscale o per addizionale si procede
            foreach (DataRow rDeduzioneConguaglio in deduzioniConguaglio) {
                string filtroDeduzione = QHC.CmpEq("iddeduction", rDeduzioneConguaglio["iddeduction"]);
                string filtroDeduzionesql = QHS.CmpEq("iddeduction", rDeduzioneConguaglio["iddeduction"]);
                if (DS.deduction.Select(filtroDeduzione).Length == 0) continue;
                DataRow tipoDeduzione = DS.deduction.Select(filtroDeduzione)[0];
                object imponibileRif = Conn.DO_READ_VALUE("deduction", filtroDeduzionesql, "taxablecode");
                if ((tipoDeduzione["taxablecode"].ToString().ToUpper() != "IRPEF")
                    && (tipoDeduzione["taxablecode"].ToString().ToUpper() != "ADDIRPEF")) continue;

                // Si verifica la presenza della deduzione all'interno dell'ultimo cedolino rata
                string filtroDedUltimoCedolinoRata = QHC.AppAnd(QHC.CmpEq("idpayroll", idCedolinoRata),
                    QHC.CmpEq("iddeduction", rDeduzioneConguaglio["iddeduction"]));
                DataRow[] rDedUltimoCed = DS.payrolldeduction.Select(filtroDedUltimoCedolinoRata);
                DataRow newDedUltimoCed;
                // Se presente si copiano i valori di annualamount e curramount
                if (rDedUltimoCed.Length > 0) {
                    newDedUltimoCed = rDedUltimoCed[0];
                    foreach (string colname in new string[] {"annualamount", "curramount"}) {
                        newDedUltimoCed[colname] = rDeduzioneConguaglio[colname];
                    }
                }
                // Altrimenti si crea una nuova riga con i valori del cedolino di conguaglio
                else {
                    newDedUltimoCed = MetaDettaglioDeduzioneCedolino.Get_New_Row(cedolinoRata, DS.payrolldeduction);
                    foreach (DataColumn C in DS.payrolldeduction.Columns) {
                        if (C.ColumnName == "idpayroll") continue;
                        newDedUltimoCed[C.ColumnName] = rDeduzioneConguaglio[C.ColumnName];
                    }
                }
                // Si sottraggono le deduzioni presenti negli altri cedolini rata
                sottraiSommeCedoliniRataDaConguaglio(elencoCedolini, "payrolldeduction", "iddeduction",
                    rDeduzioneConguaglio["iddeduction"].ToString(), new string[] {"curramount"}, newDedUltimoCed);
            }
        }

        /// <summary>
        /// Metodo che aggiunge le detrazioni associate a ritenute fiscali all'ultimo cedolino rata
        /// </summary>
        /// <param name="elencoCedolini"></param>
        /// <param name="idCedolinoRata"></param>
        /// <param name="idCedolinoConguaglio"></param>
        private void aggiungiDetrazioniUltimoCedolinoRata(string elencoCedolini, object idCedolinoRata,
            object idCedolinoConguaglio) {
            DataRow cedolinoRata = DS.payroll.Select(QHC.CmpEq("idpayroll", idCedolinoRata))[0];
            string filtroConguaglio = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            // Si ottiene l'elenco delle detrazioni del cedolino di conguaglio
            DataRow[] detrazioniConguaglio = DS.payrollabatement.Select(filtroConguaglio);
            // Per ogni detrazione se essa è associata ad una ritenuta fiscale si procede
            foreach (DataRow rDetrazioneConguaglio in detrazioniConguaglio) {
                string filtroDetrazione = QHC.CmpEq("idabatement", rDetrazioneConguaglio["idabatement"]);
                DataRow tipoDetrazione = DS.abatement.Select(filtroDetrazione)[0];
                int ritenutaRif = ottieniTipoRitenuta(tipoDetrazione["taxcode"]);
                if (ritenutaRif != 1) continue;

                // Si verifica la presenza della detrazione all'interno dell'ultimo cedolino rata
                string filtroDetUltimoCedolinoRata = QHC.AppAnd(QHC.CmpEq("idpayroll", idCedolinoRata),
                    QHC.MCmp(rDetrazioneConguaglio, "idabatement"));
                DataRow[] rDetUltimoCed = DS.payrollabatement.Select(filtroDetUltimoCedolinoRata);
                DataRow newDetUltimoCed;
                // Se presente si copiano i valori di annualamount e curramount
                if (rDetUltimoCed.Length > 0) {
                    newDetUltimoCed = rDetUltimoCed[0];
                    foreach (string colname in new string[] {"annualamount", "curramount"}) {
                        newDetUltimoCed[colname] = rDetrazioneConguaglio[colname];
                    }
                }
                // Altrimenti si crea una nuova riga con i valori del cedolino di conguaglio
                else {
                    newDetUltimoCed = MetaDettaglioDetrazioneCedolino.Get_New_Row(cedolinoRata, DS.payrollabatement);
                    foreach (DataColumn C in DS.payrollabatement.Columns) {
                        if (C.ColumnName == "idpayroll") continue;
                        newDetUltimoCed[C.ColumnName] = rDetrazioneConguaglio[C.ColumnName];
                    }
                }
                // Si sottraggono le detrazioni presenti negli altri cedolini rata
                sottraiSommeCedoliniRataDaConguaglio(elencoCedolini, "payrollabatement", "idabatement",
                    rDetrazioneConguaglio["idabatement"].ToString(), new string[] {"curramount"}, newDetUltimoCed);
            }
        }

        /// <summary>
        /// Metodo che aggiunge gli storni presenti sul cedolino di conguaglio nell'ultimo cedolino rata
        /// </summary>
        /// <param name="idCedolinoRata">ID del cedolino rata</param>
        /// <param name="idCedolinoConguaglio">ID del cedolino di conguaglio</param>
        private void aggiungiStorniUltimoCedolinoRata(object idCedolinoRata, object idCedolinoConguaglio) {
            string filtroCong = QHC.CmpEq("idpayroll", idCedolinoConguaglio);
            // Per ogni storno presente nel cedolino di conguaglio
            // si crea uno storno nell'ultimo cedolino rata e vengono ricopiati i valori
            // del cedolino di conguaglio.

            // N.B. Questo metodo è più "semplice" dei suoi simili in quanto gli storni si hanno solamente in sede
            // di conguaglio e non nei pagamenti delle varie rate
            foreach (DataRow rStornoConguaglio in DS.payrolltaxcorrige.Select(filtroCong)) {
                MetaStorno.SetDefaults(DS.payrolltaxcorrige);
                MetaData.SetDefault(DS.payrolltaxcorrige, "idpayroll", idCedolinoRata);
                DataRow rRata = MetaStorno.Get_New_Row(null, DS.payrolltaxcorrige);

                foreach (DataColumn C in DS.payrolltaxcorrige.Columns) {
                    if ((C.ColumnName == "idpayroll") ||
                        (C.ColumnName == "idpayrolltaxcorrige")) continue;
                    rRata[C.ColumnName] = rStornoConguaglio[C.ColumnName];
                }
            }
        }

        /// <summary>
        /// Metodo che sottrae la somma dei campi importo presenti nella tabella figlia specificata dei cedolini rata,
        /// tranne l'ultimo, dall'importo presente nell'ultimo cedolino rata
        /// </summary>
        /// <param name="elencoCedolini">Elenco dei cedolini rata pregressi</param>
        /// <param name="nomeTabella">Nome Tabella su cui calcolare la somma degli importi</param>
        /// <param name="keyfield">Campo chiave della tabella passata differente da IDPAYROLL</param>
        /// <param name="keyvalue">Valore del campo chiave keyfield</param>
        /// <param name="elencoCampi">Elenco dei campi su cui operare l'operazione</param>
        /// <param name="dest">Data Row dove vengono memorizzati i risultati finali</param>
        private void sottraiSommeCedoliniRataDaConguaglio(string elencoCedolini, string nomeTabella,
            string keyfield, object keyvalue, string[] elencoCampi, DataRow dest) {
            if (elencoCedolini == "") return;
            string filtro = QHC.AppAnd(QHC.FieldInList("idpayroll", elencoCedolini),
                QHC.CmpEq(keyfield, keyvalue));

            DataRow[] cedolini = DS.Tables[nomeTabella].Select(filtro);
            if (cedolini.Length == 0) return;
            foreach (string colname in elencoCampi) {
                decimal somma = 0;
                foreach (DataRow CC in cedolini) somma += CfgFn.GetNoNullDecimal(CC[colname]);
                dest[colname] = CfgFn.GetNoNullDecimal(dest[colname]) - somma;
                //Compute SUM fa errori di arrotondamento
                //CfgFn.GetNoNullDecimal(DS.Tables[nomeTabella].Compute("SUM("+colname+")",filtro));
            }
        }

        #endregion

        /// <summary>
        /// Calcola un cedolino (aggiungendo le righe delle tabelle figlie)
        /// </summary>
        /// <param name="idCedolino">id. del cedolino da calcolare</param>
        /// <param name="copiaNelDataSetDiPartenza">TRUE: Se si vogliono copiare i risultati nel Dataset del chiamante; FALSE: Altrimenti</param>
        /// <param name="tipoRitenutaDaCalcolare">N: Calcola solo le ritenute non fiscali; F: Calcola solo le ritenute fiscali; T: Calcola tutte le ritenute (calcolo normale)</param>
        /// <returns>DataSet aggiornato</returns>
        public string calcolaCedolino(object idCedolino, bool copiaNelDataSetDiPartenza,
            string tipoRitenutaDaCalcolare) {
            // Vengono eseguiti controlli preventivi per definire se può essere effettuato o meno il calcolo del cedolino
            string errMess = eseguiControlliPreventivi(idCedolino);
            if (errMess != null) return errMess;

            string filtroCedolino = QHC.CmpEq("idpayroll", idCedolino);
            var rCedolini = DS.payroll.Select(filtroCedolino);
            if (rCedolini.Length == 0) return "Non ho trovato il cedolino di id " + idCedolino;
            DataRow rCedolino = rCedolini[0];
            decimal compensolordo = (decimal) rCedolino["feegross"];
            bool isConguaglio = rCedolino["flagbalance"].ToString() == "S";
            DateTime dataInizioCedolino = (DateTime) rCedolino["start"];
            DateTime dataFineCedolino = (DateTime) rCedolino["stop"];
            DataRow rContratto = rCedolino.GetParentRow("parasubcontractpayroll");
            object codiceprestazione = rContratto["idser"];
            DateTime dataInizioContratto = (DateTime) rContratto["start"];
            DateTime dataFineContratto = (DateTime) rContratto["stop"];

            DateTime inizioAnno = new DateTime(CfgFn.GetNoNullInt32(MetaCedolino.GetSys("esercizio")), 1, 1);
            DateTime fineAnno = new DateTime(CfgFn.GetNoNullInt32(MetaCedolino.GetSys("esercizio")), 12, 31);

            object idContratto = rCedolino["idcon"];
            string filtroContrEdEserc = QHC.CmpEq("idcon", idContratto);
            var ImpContracts = DS.parasubcontractyear.Select(filtroContrEdEserc);
            if (ImpContracts.Length == 0) return $"Non ho trovato il contratto di id {idContratto} nell'anno corrente";
            DataRow rImpContr = ImpContracts[0];
            decimal imponibileprevidenziale = CfgFn.GetNoNullDecimal(rImpContr["taxablepension"]);

            if (rImpContr["startcompetency"] == DBNull.Value) {
                return "Manca la data inizio competenza nel contratto";
            }
            if (rImpContr["stopcompetency"] == DBNull.Value) {
                return "Manca la data fine competenza nel contratto";
            }

            DateTime inizioCompetenza = (DateTime) rImpContr["startcompetency"];
            DateTime fineCompetenza = (DateTime) rImpContr["stopcompetency"];

            int numeroRateINAIL = calcolaNumeroRateINAIL(idContratto, inizioCompetenza, fineCompetenza);
            decimal compensoMedioMensile = 0;
            if (numeroRateINAIL > 0) {
                compensoMedioMensile = CfgFn.RoundValuta(imponibileprevidenziale / numeroRateINAIL);
            }
            else {
                compensoMedioMensile = 0;
            }

            string filtroComCaf = QHC.AppAnd(filtroContrEdEserc, QHC.AppAnd(QHC.CmpLe("docdate", dataFineCedolino), 
                                                                            QHC.CmpEq("ayear", dataInizioCedolino.Year)));
            DataRow[] rComunicazioniDaCaf = DS.cafdocument.Select(filtroComCaf, "docdate");
            foreach (DataRow r in DS.payroll.Select(filtroCedolino)) {
                cancellaFigliDiCedolino(r);
            }

            Hashtable imponibili = new Hashtable();
            decimal ritenuteApplicate = 0; //somma cumulativa di tutte le ritenute calcolate sin'ora nel ciclo
            bool azzeraAddizionali = false;

            // Viene eseguito un ciclo su tutti i tipi imponibile esistenti in un anno
            foreach (DataRow rImponibile in DS.taxablekind.Rows) {
                object codiceimponibile = rImponibile["taxablecode"];
                object codiceimponibilediriferimento = rImponibile["idtaxablekind"];
                string spcalcoloimponibileriferimento = rImponibile["spcalcrefertaxable"].ToString();

                decimal imponibileriferimento = (codiceimponibilediriferimento == DBNull.Value)
                    ? compensolordo
                    : CfgFn.GetNoNullDecimal(imponibili[codiceimponibilediriferimento]);

                decimal imponibile_lordo = calcolaImponibileLordo(spcalcoloimponibileriferimento,
                    imponibileriferimento, rCedolino, compensoMedioMensile);

                // Si calcola l'amnmontare delle deuzioni
                decimal deduzionicorrenti = calcolaDeduzioniPerUnImponibile(
                    rCedolino,
                    codiceimponibile,
                    imponibile_lordo,
                    ritenuteApplicate
                );

                deduzionicorrenti = CfgFn.RoundValuta(deduzionicorrenti);


                // Si calcola l'imponibile netto
                decimal imponibile_netto = (imponibile_lordo > deduzionicorrenti)
                    ? imponibile_lordo - deduzionicorrenti
                    : 0;


                //if (codiceimponibile.ToString().ToUpper() == "ADDIRPEF" && isConguaglio ) {
                //    imponibile_netto = imponibile_netto + sommaImponibiliDaCud;                 
                //}

                imponibili[codiceimponibile] = imponibile_netto;
                // JTR Commentato NON ESISTONO PIU' LE DEDUZIONI PER FAMILIARI
                //if (codiceimponibile=="ADDIRPEF") {
                //    decimal deduzioneAnnua;
                //    decimal deduzFamiliari = calcolaDeduzioneFamiliari(rCedolino, out deduzioneAnnua);
                //    if (imponibile_netto > deduzFamiliari) {
                //        imponibile_netto -= deduzFamiliari;
                //    } else {
                //        imponibile_netto = 0;
                //    }
                //}

                // Si costruisce il filtro da applicare per ottenere le ritenute
                string query2 = costruisciQueryRitenute(codiceimponibile, codiceprestazione, isConguaglio,
                    rComunicazioniDaCaf, rImpContr, tipoRitenutaDaCalcolare);

                DataTable t = Conn.RUN_SELECT("servicetaxview",
                    "taxcode, taxref, taxkind, appliancebasis, geoappliance",
                    null, query2, null, null, true);

                // Si effettua un ciclo su tutte le ritenute coinvolte nel calcolo del cedolino corrente
                foreach (DataRow rRitenuta in t.Rows) {
                    if (codiceimponibile.ToString().ToUpper() == "PREVIDENZA") {
                        imponibile_lordo = CfgFn.Round(imponibile_lordo, 0);
                        imponibile_netto = CfgFn.Round(imponibile_netto, 0);
                    }


                    DataRow rCedRit = calcola_una_ritenuta(rCedolino, rRitenuta, imponibile_netto);
                    if (rCedRit == null) continue;
                    decimal importoritenuta = CfgFn.GetNoNullDecimal(rCedRit["employtaxgross"]);
                    if (rRitenuta["taxref"].ToString().ToUpper() == "07_ACC_ADDCOM") {
                        rCedRit["taxablegross"] = 0;
                        rCedRit["deduction"] = 0;
                        rCedRit["taxablenet"] = 0;
                        rCedRit["annualtaxabletotal"] = 0;
                    }
                    else {
                        rCedRit["taxablegross"] = CfgFn.RoundValuta(imponibile_lordo);
                        rCedRit["deduction"] =
                            CfgFn.RoundValuta(imponibile_lordo) - CfgFn.RoundValuta(imponibile_netto);
                        //rCedRit["taxablenet"] = CfgFn.RoundValuta(imponibile_netto);
                        rCedRit["annualtaxabletotal"] = compensolordo;
                    }
                    if (rCedRit["admintax"] != DBNull.Value) {
                        rCedRit["admintax"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rCedRit["admintax"]));
                    }
                    if (rCedRit["employtaxgross"] != DBNull.Value) {
                        rCedRit["employtaxgross"] = CfgFn.RoundValuta(importoritenuta);
                    }


                    decimal totaledetrazioni = calcolaDetrazioniPerUnaRitenuta(rCedolino, rCedRit, imponibile_netto);

                    // decimal totaleDetrReddito = calcola_detrazione_reddito(); 
                    importoritenuta -= CfgFn.GetNoNullDecimal(rCedRit["annualpayedemploytax"]);
                    if (totaledetrazioni > 0) {
                        importoritenuta -= totaledetrazioni;
                    }
                    else {
                        totaledetrazioni = 0;
                    }

                    rCedRit["abatements"] = totaledetrazioni;
                    rCedRit["employtax"] = CfgFn.RoundValuta(importoritenuta);
                    ritenuteApplicate += importoritenuta;
                    if ((rRitenuta["taxkind"] != DBNull.Value) &&
                        (CfgFn.GetNoNullInt32(rRitenuta["taxkind"]) == 1) &&
                        (rCedolino["flagbalance"].ToString().ToUpper() == "S") &&
                        (rRitenuta["geoappliance"] == DBNull.Value)) {
                        // La legge dice che se non è dovuta l'IRPEF tutte le addizionali non sono dovute
                        azzeraAddizionali =
                            ((CfgFn.GetNoNullDecimal(rCedRit["annualpayedemploytax"]) == 0) &&
                             (CfgFn.GetNoNullDecimal(rCedRit["employtax"]) <= 0)) ||
                            (CfgFn.GetNoNullDecimal(rCedRit["employtaxgross"]) == 0);
                    }
                }
            }

            if (azzeraAddizionali) {
                azzeraAddizionaliLocali(idCedolino, rContratto["idser"]);
            }
            // Calcolo il compenso netto solo nel caso in cui viene calcolato un cedolino rata normale
            // se invece viene calcolato il cedolino di conguaglio o l'ultimo cedolino rata il calcolo
            // del compenso netto viene differito
            if (tipoRitenutaDaCalcolare == "T") {
                calcolaCompensoNetto(rCedolino);
            }
            if (isConguaglio) {
                rCedolino["workingdays"] =
                    calcolaGiorniLavorati(idContratto, dataInizioCedolino, dataFineCedolino, "C");
            }
            rCedolino["flagcomputed"] = "S";
            if (copiaNelDataSetDiPartenza) {
                copiaVistaCalcoloCedolinoInDS(idCedolino);
            }
            return errMess;
        }

        /// <summary>
        /// Metodo che effettua il posting dei dati presenti nel dataset sul db
        /// </summary>
        /// <returns></returns>
        public string salvaSulDB() {
            PostData P = MetaCedolino.Get_PostData();
            string errore = P.InitClass(DS, Conn);
            if (errore != null) {
                return errore;
            }
            if (!P.DO_POST()) {
                return P.GetErrorMsg;
            }
            return null;
        }

        /// <summary>
        /// Metodo che calcola il compenso netto di un cedolino
        /// </summary>
        /// <param name="rCedolino">DataRow del cedolino su cui si desidera calcolare il compenso netto</param>
        private void calcolaCompensoNetto(DataRow rCedolino) {
            decimal compensoNetto = CfgFn.GetNoNullDecimal(rCedolino["feegross"]);
            foreach (DataRow rCedRit in rCedolino.GetChildRows("payrollpayrolltax")) {
                compensoNetto -= CfgFn.GetNoNullDecimal(rCedRit["employtax"]);
            }
            rCedolino["netfee"] = compensoNetto;
        }

        /// <summary>
        /// Metodo che cancella i dati dalle tabelle figlie di cedolino
        /// </summary>
        private void cancellaFigliCedolino(int idCedolino) {
            string filtroCedolino = QHC.CmpEq("idpayroll", idCedolino);
            DataRow rCedolino = DS.payroll.Select(filtroCedolino)[0];

            foreach (DataRow rCedRitenuta in rCedolino.GetChildRows("payrollpayrolltax")) {
                foreach (DataRow rCedRitScaglione in rCedRitenuta.GetChildRows("payrolltaxpayrolltaxbracket")) {
                    rCedRitScaglione.Delete();
                }
                rCedRitenuta.Delete();
            }
            foreach (DataRow rDetrazioneCed in rCedolino.GetChildRows("payrollpayrollabatement")) {
                rDetrazioneCed.Delete();
            }
            foreach (DataRow rDeduzioneCed in rCedolino.GetChildRows("payrollpayrolldeduction")) {
                rDeduzioneCed.Delete();
            }

            foreach (DataRow rStorno in rCedolino.GetChildRows("payrollpayrolltaxcorrige")) {
                rStorno.Delete();
            }
        }

        /// <summary>
        /// Metodo che azzera le addizionali comunali e regionali nel caso di esenzione dalla ritenuta IRPEF
        /// </summary>
        /// <param name="idCedolino">ID del cedolino di conguaglio</param>
        /// <param name="codPrestazione">Codice della Prestazione</param>
        void azzeraAddizionaliLocali(object idCedolino, object codPrestazione) {
            // Le addizionali da azzerare sono solo quella comunale e regionale MA NON l'acconto
            // infatti per come concepiamo noi l'acconto esso viene trattenuto su tutti i cedolini
            // rata e viene restituito al percipiente a conguaglio (a mo di compensazione con la ritenuta 
            // principale che è l'addizionale comunale)
            string filtro = QHS.AppAnd(QHS.CmpEq("taxkind", 1), QHS.CmpEq("idser", codPrestazione),
                QHS.IsNotNull("geoappliance"), QHS.CmpNe("taxref", "07_ACCADDCOM"));
            DataTable ritenuteGeografiche = Conn.RUN_SELECT("servicetaxview",
                "taxcode, taxkind, appliancebasis, geoappliance",
                null, filtro, null, null, true);
            foreach (DataRow ritenuta in ritenuteGeografiche.Rows) {
                string filtroSuCedolinoRitenuta = QHC.AppAnd(QHC.CmpEq("idpayroll", idCedolino),
                    QHC.CmpEq("taxcode", ritenuta["taxcode"]));
                DataRow[] rCedRit = DS.payrolltax.Select(filtroSuCedolinoRitenuta);
                if (rCedRit.Length > 0) {
                    rCedRit[0]["employrate"] = 0;
                    rCedRit[0]["employtaxgross"] = 0;
                    rCedRit[0]["employtax"] = 0;
                    string filtroSuCedolinoRitScagl = QHC.AppAnd(QHC.CmpEq("idpayroll", idCedolino),
                        QHC.MCmp(rCedRit[0], "idpayrolltax"));
                    DataRow[] rCedRitScagl = DS.payrolltaxbracket.Select(filtroSuCedolinoRitScagl);
                    foreach (DataRow rBracket in rCedRitScagl) {
                        rBracket["employrate"] = 0;
                        rBracket["employtax"] = 0;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo che ricopia il dataset modificato nella classe CalcoliCococo nel dataset di contratto
        /// </summary>
        /// <param name="ds"></param>
        private void copiaVistaCalcoloCedolinoInDS(object idCedolino) {
            string filtroCedolino = QHC.CmpEq("idpayroll", idCedolino);
            DataTable[] tabelle = new DataTable[] {
                dsContratto.Tables["payroll"],
                dsContratto.Tables["payrolltax"],
                dsContratto.Tables["payrolltaxbracket"],
                dsContratto.Tables["payrolldeduction"],
                dsContratto.Tables["payrollabatement"],
                dsContratto.Tables["payrolltaxcorrige"]
            };
            foreach (DataTable t in tabelle) {
                // Parte 1: Controllo i dati presenti sul DS di contratto rispetto a quelli in ds di VistaCalcoloCedolino
                foreach (DataRow rowDS in t.Select(filtroCedolino)) {
                    //string campiChiave = QueryCreator.WHERE_KEY_CLAUSE(rowDS, DataRowVersion.Original,false);
                    string campiChiave = QHC.CmpKey(rowDS);
                    DataRow[] rowDsCedolino = DS.Tables[t.TableName].Select(campiChiave);
                    if (rowDsCedolino.Length == 0) {
                        rowDS.Delete();
                    }
                }
            }
            DataRow rCedolinoSorg = DS.Tables["payroll"].Select(filtroCedolino)[0];
            copiaCedolino(rCedolinoSorg, dsContratto.Tables["payroll"]);
            DataRow parentRowDest = dsContratto.Tables["payroll"].Select(filtroCedolino)[0];
            copiaCedolinoRitenuta(DS.Tables["payrolltax"],
                dsContratto.Tables["payrolltax"], parentRowDest);
            copiaRigheFiglie(MetaDettaglioDeduzioneCedolino, DS.Tables["payrolldeduction"],
                dsContratto.Tables["payrolldeduction"], parentRowDest);
            copiaRigheFiglie(MetaDettaglioDetrazioneCedolino, DS.Tables["payrollabatement"],
                dsContratto.Tables["payrollabatement"], parentRowDest);
            copiaRigheFiglie(MetaStorno, DS.Tables["payrolltaxcorrige"],
                dsContratto.Tables["payrolltaxcorrige"], parentRowDest);

            DataRow rContratto = dsContratto.Tables["parasubcontract"].Rows[0];
            copiaRigheFiglie(MetaFamiliare, DS.Tables["parasubcontractfamily"],
                dsContratto.Tables["parasubcontractfamily"], rContratto);
        }


        /// <summary>
        /// Metodo che copia i dati inerenti il cedolino presente nel dataset VistaCalcolaCedolino nel dataset di contratto
        /// </summary>
        /// <param name="tCedolino"></param>
        private void copiaCedolino(DataRow rCedolinoSorg, DataTable tCedolinoDest) {
            // Caso 1: Riga non cancellata nel dataset di VistaCalcoloCedolino
            string campiChiave = QHC.CmpKey(rCedolinoSorg);
            DataRow[] rInDS = tCedolinoDest.Select(campiChiave);
            DataRow newRowDS = rInDS[0];
            foreach (DataColumn C in tCedolinoDest.Columns) {
                newRowDS[C] = rCedolinoSorg[C.ColumnName];
            }
        }

        private void copiaCedolinoRitenuta(DataTable tCedolinoRitenutaSorg, DataTable tCedRitDest,
            DataRow parentRowDest) {
            MetaCedolinoRitenuta.SetDefaults(tCedRitDest);
            string filtroCedolinoRitenuta = QHC.CmpKey(parentRowDest);
            foreach (DataRow rCedRit in tCedolinoRitenutaSorg.Select(filtroCedolinoRitenuta)) {
                // Caso 1: Riga non cancellata nel dataset di VistaCalcoloCedolino
                string campiChiave = QHC.CmpKey(rCedRit);
                DataRow[] rInDS = tCedRitDest.Select(campiChiave);
                DataRow rowDS = (rInDS.Length != 0)
                    ? rInDS[0]
                    : MetaCedolinoRitenuta.Get_New_Row(parentRowDest, tCedRitDest);
                foreach (DataColumn C in tCedolinoRitenutaSorg.Columns) {
                    rowDS[C.ColumnName] = rCedRit[C];
                }
                DataTable tCedolinoRitenutaScaglioneSorg = tCedolinoRitenutaSorg.DataSet.Tables["payrolltaxbracket"];
                DataTable tDest = tCedRitDest.DataSet.Tables["payrolltaxbracket"];
                copiaRigheFiglie(MetaCedolinoRitenutaScaglione, tCedolinoRitenutaScaglioneSorg,
                    tDest, rowDS);
            }
        }

        private void copiaRigheFiglie(MetaData metaTabella, DataTable tSorg, DataTable tDest, DataRow parentRowDest) {
            metaTabella.SetDefaults(tDest);
            string filtro = QHC.CmpKey(parentRowDest);
            foreach (DataRow rowSorg in tSorg.Select(filtro)) {
                // Caso 1: Riga non cancellata nel dataset di VistaCalcoloCedolino
                string campiChiave = QHC.CmpKey(rowSorg);
                DataRow[] rInDS = tDest.Select(campiChiave);
                DataRow rowDS = (rInDS.Length != 0) ? rInDS[0] : metaTabella.Get_New_Row(parentRowDest, tDest);

                foreach (DataColumn C in tSorg.Columns) {
                    rowDS[C.ColumnName] = rowSorg[C];
                }
            }
        }
    }
}