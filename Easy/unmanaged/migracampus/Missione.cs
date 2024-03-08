
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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using System.Collections;

namespace Install {
    class Missione {


        public static void Reset() {
            lookup_idtineration = new Hashtable();
            MigraTipoPrestazione_eseguito = false;
            lookuptaxcode = new Hashtable();
            MigraTipoRitenuta_eseguita = false;
            lookupidForeignCountry = new Hashtable();
            lookupidreduction = new Hashtable();
            migraReduction_eseguito = false;
            lookupiditinerationrefundkind = new Hashtable();
            migraItinerationRefundKind_eseguito = false;
            lookupidser = new Hashtable();
            lookuptaxkind = new Hashtable();
        }
        static object gethash (Hashtable A, string code) {
            if (code == "") return DBNull.Value;
            code = code.ToUpper();
            if (A[code] == null) {
                MessageBox.Show("Code " + code + " was not found in " + A.GetType().Name);
                return DBNull.Value;
            }
            return A[code];
        }
        public static string getExtAccess(DataAccess Conn, string table, bool dbo) {
            //DBNAME.owner"
            if (dbo)
                return Conn.GetSys("database").ToString() + ".dbo." + table;
            else
                return Conn.GetSys("database").ToString() + "." + Conn.GetSys("userdb").ToString() + "." + table;
        }


        public static Hashtable lookup_idtineration = new Hashtable();
        public static bool migraMissione(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("itineration", null, false) > 0) return true;
            Anagrafica.migraValuta(form, sourceConn, destConn);
            Anagrafica.migraCreditoreDebitore(form, sourceConn, destConn);
            MigraTipoPrestazione(form, sourceConn, destConn);
            string query = "SELECT REG.idreg, M.codiceprestazione, grossfactor=M.coefflord, " +
                "ct=M.createtimestamp, cu=M.createuser,authorizationdate= M.dataautorizzazione, " +
                " adate=M.datacontabile,stop=M.datafine, start=M.datainizio, description=M.descrizione," +
                " yitineration=M.esercmissione, admincarkmcost=M.impkmmezzoamm, owncarkmcost=M.impkmmezzoproprio, " +
                " footkmcost=M.impkmpiedi, admincarkm=M.kmmezzoamm, owncarkm=M.kmmezzoproprio, footkm=M.kmpiedi, " +
                " lt=M.lastmodtimestamp,lu=M.lastmoduser,txt=M.notes,nitineration=M.nummissione, rtf=M.olenotes, " +
                " totadvance=M.totanticipo,total=M.totglobale,totalgross=M.totlordo,netfee=M.totnetto " +
                " from missione M " +
                " JOIN creditoredebitore CR ON M.codicecreddeb=CR.codicecreddeb " +
                " JOIN " + getExtAccess(destConn, "registry", true) + " REG " +
                "  ON CR.denominazione = REG.title ";
            DataTable All = sourceConn.SQLRunner(query);

            if (All.Rows.Count == 0) return true;

            int nmaxitineration = 0;
            DataTable Itineration = destConn.CreateTableByName("itineration", "*");
            foreach (DataRow Curr in All.Rows) {
                nmaxitineration++;
                DataRow R = Itineration.NewRow();
                R["idser"] = lookupidser[Curr["codiceprestazione"].ToString().ToUpper()];
                string lookup = Curr["yitineration"].ToString() + "-" + Curr["nitineration"].ToString();
                R["iditineration"] = nmaxitineration;
                lookup_idtineration[lookup] = nmaxitineration;
                R["active"] = "S";
                R["completed"] = "S";
                foreach (string S in new string[]{"idreg","grossfactor","ct","cu","authorizationdate","adate",
                        "stop","start","description","yitineration","admincarkmcost","owncarkmcost","footkmcost",
                        "admincarkm","owncarkm","footkm","lt","lu","txt","nitineration","rtf","totadvance","total",
                    "totalgross","netfee"}) {
                    R[S] = Curr[S];
                }
                Itineration.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(Itineration);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Itineration");
        }



        public static Hashtable lookupidser = new Hashtable();
        public static bool MigraTipoPrestazione_eseguito = false;
        /// <summary>
        /// Aggiunge tutti i tipi di prestazione come non attivi a meno che non abbiano lo stesso codice di uno esistente,
        /// nel qual caso la prest.esistente viene assunta coincidente con quella ufficiale
        /// </summary>
        /// <param name="form"></param>
        /// <param name="sourceConn"></param>
        /// <param name="destConn"></param>
        /// <returns></returns>
        public static bool MigraTipoPrestazione(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (MigraTipoPrestazione_eseguito) return true;
            MigraTipoPrestazione_eseguito = true;
            DataTable All = sourceConn.SQLRunner(
                "SELECT codeser=M.codiceprestazione,ct=M.createtimestamp,cu=M.createuser,"+
                "ivaamount=M.defprestazione1,description='ZZ'+M.descrizione,flagonlyfiscalabatement=M.flagcalcimpfiscale,"+
                "lt=M.lastmodtimestamp,lu=M.lastmoduser"+
                " FROM tipoprestazione M ");
            DataTable Existent = destConn.SQLRunner("SELECT * from service");
            foreach (DataRow RC in Existent.Rows) {
                lookupidser[RC["codeser"].ToString().ToUpper()] = RC["idser"];
            }
            CQueryHelper QHC = new CQueryHelper();

            if (All.Rows.Count == 0) return true;
            DataTable Service = destConn.CreateTableByName("service", "*");
            int maxidservice = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("service",null,"max(idser)"));
            foreach (DataRow Curr in All.Rows) {
                string codeser = Curr["codeser"].ToString().ToUpper();
                if (lookupidser[codeser] != null) continue;
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookupidser[codeser] = found[0]["idser"];
                    continue;
                }

                maxidservice++;
                DataRow R = Service.NewRow();
                R["idser"] = maxidservice;
                R["allowedit"] = "N";
                R["certificatekind"] = "O";
                R["flagalwaysinfiscalmodels"] = "N";
                R["flagapplyabatements"] = "S";
                R["active"] = "N";
                lookupidser[codeser] = maxidservice;
                foreach (string S in new string[]{"ct","cu","ivaamount","description","codeser",
                            "flagonlyfiscalabatement","lt","lu"}) {
                    R[S] = Curr[S];
                }
                Service.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Service);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Service");
        }

        public static Hashtable lookuptaxcode = new Hashtable();
        public static bool MigraTipoRitenuta_eseguita = false;
        public static bool MigraTipoRitenuta(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (MigraTipoRitenuta_eseguita) return true;
            MigraTipoRitenuta_eseguita = true;

            RiempiLookuptaxkind();

            DataTable Existent = destConn.SQLRunner("SELECT * from tax");
            foreach (DataRow RC in Existent.Rows) {
                string codice = RC["taxref"].ToString().ToUpper();
                lookuptaxcode[codice] = RC["taxcode"];
            }
            CQueryHelper QHC= new CQueryHelper();
            string query = "SELECT taxref=M.codiceritenuta,M.tiporitenuta," +
                "ct=M.createtimestamp,cu=M.createuser,description=M.descrizione," +
                "flagunabatable=M.flagindetraibile,lt=M.lastmodtimestamp,lu=M.lastmoduser " +
                "FROM tiporitenuta M";
            DataTable All = sourceConn.SQLRunner(query);
            if (All.Rows.Count == 0) return true;
            DataTable Tax = destConn.CreateTableByName("tax", "*");
            int nmaxtaxcode = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("tax",null,"max(taxcode)"));
            foreach (DataRow Curr in All.Rows) {
                string taxref = Curr["taxref"].ToString().ToUpper();
                if (lookuptaxcode[taxref] != null) continue;
                string find = QHC.CmpEq("description", Curr["description"]);
                DataRow[] found = Existent.Select(find);
                if (found.Length > 0) {
                    lookuptaxcode[taxref] = found[0]["taxcode"];
                    continue;
                }
                nmaxtaxcode++;
                DataRow R = Tax.NewRow();
                R["taxcode"] = nmaxtaxcode;
                R["active"] = "S";
                lookuptaxcode[taxref] = nmaxtaxcode;
                R["taxkind"] = lookuptaxkind[Curr["tiporitenuta"].ToString().ToUpper()];
                foreach (string S in new string[] { "taxref",  "ct", "cu", 
                    "description", "flagunabatable", "lt", "lu" }) {
                    R[S] = Curr[S];
                }

                Tax.Rows.Add(R);

            }
            DataSet ds = new DataSet();
            ds.Tables.Add(Tax);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Tax");
        }


        public static Hashtable lookuptaxkind = new Hashtable();
        public static void RiempiLookuptaxkind() {
            lookuptaxkind["F"] = 1; //fiscale
            lookuptaxkind["A"] = 2; //Assistenziale
            lookuptaxkind["P"] = 3; //Previdenziale
            lookuptaxkind["N"] = 4; //Assicurativo
            lookuptaxkind["R"] = 5; //Arretrati
            lookuptaxkind["O"] = 6; //Altro
            lookuptaxkind[DBNull.Value] = DBNull.Value;
        }


        public static bool migraDatiMissione (Form form, DataAccess sourceConn, DataAccess destConn) {
            RiempiLookuptaxkind();
            if (!MigraTipoPrestazione(form, sourceConn, destConn)) return false;

            //classmissione -> sortingkind e figlie + itinerationsorting
            if (!migraClassMissione(form, sourceConn, destConn)) return false;
            if (!migraLocalita(form, sourceConn, destConn)) return false;
            if (!migraReduction(form, sourceConn, destConn)) return false;

            // misione -> itineration
            if (!migraMissione(form, sourceConn, destConn)) return false;


            // misionetappa -> itinerationlap
            if (!migraItinerationLap(form, sourceConn, destConn)) return false;

            if (!migraItinerationRefundKind(form, sourceConn, destConn))return false;
            // missionespesa -> itinerationrefund
            //if (!migraItinerationRefund(form, sourceConn, destConn)) return false;

            if (!MigraTipoRitenuta(form, sourceConn, destConn)) return false;
            if (!migraItinerationTax(form, sourceConn, destConn)) return false;

            if (!migraAutomPercentuale(form, sourceConn, destConn)) return false;

            return true;
            
        }

        public static bool migraClassMissione(Form form, DataAccess sourceConn, DataAccess destConn) {
            // Passo 1. da CLASSMISSIONE devo popolare SORTINGKIND - SORTINGLEVEL - SORTINGAPPLICABILITY - SORTING
            if (destConn.RUN_SELECT_COUNT("sortingkind", "codesorkind='_CLASSMISSIONE'", false) > 0) return true;
            int nRow = sourceConn.RUN_SELECT_COUNT("classmissione", null, true);
            if (nRow == 0) return true;

            int nmaxidsorkind = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sortingkind", null, "max(idsorkind)")) + 1;
            // Popolamento di SORTINGKIND
            DataTable tSortingKind = DataAccess.CreateTableByName(destConn, "sortingkind", "*");
            DataRow rSortingKind = tSortingKind.NewRow();
            rSortingKind["idsorkind"] = nmaxidsorkind;
            rSortingKind["codesorkind"] = "_CLASSMISSIONE";
            rSortingKind["description"] = "ex class. missione";
            rSortingKind["active"] = "S";
            rSortingKind["flagcheckavailability"] = "N";
            rSortingKind["flagforced"] = "N";
            rSortingKind["flagmultiple"] = "N";
            rSortingKind["ct"] = DateTime.Now;
            rSortingKind["cu"] = "Software And More";
            rSortingKind["lt"] = DateTime.Now;
            rSortingKind["lu"] = "Software And More";
            tSortingKind.Rows.Add(rSortingKind);

            // Popolamento di SORTINGLEVEL
            DataTable tSortingLevel = DataAccess.CreateTableByName(destConn, "sortinglevel", "*");
            DataRow rSortingLevel = tSortingLevel.NewRow();
            rSortingLevel["idsorkind"] = nmaxidsorkind;
            rSortingLevel["nlevel"] = 1;
            int flag = 0;
            flag+=1; //codekind=Alfanum
            flag+=2; //usable 
            flag+=4; //restart
            flag += (256*10); //codelen =10
            rSortingLevel["flag"]=flag;
            rSortingLevel["description"] = "Voce";
            rSortingLevel["ct"] = DateTime.Now;
            rSortingLevel["cu"] = "Software And More";
            rSortingLevel["lt"] = DateTime.Now;
            rSortingLevel["lu"] = "Software And More";
            tSortingLevel.Rows.Add(rSortingLevel);

            // Popolamento di SORTINGAPPLICABILITY
            DataTable tSortingApplicability = DataAccess.CreateTableByName(destConn, "sortingapplicability", "*");
            DataRow rSortingApplicability = tSortingApplicability.NewRow();
            rSortingApplicability["idsorkind"] = nmaxidsorkind;
            rSortingApplicability["tablename"] = "itineration";
            rSortingApplicability["ct"] = DateTime.Now;
            rSortingApplicability["cu"] = "Software And More";
            rSortingApplicability["lt"] = DateTime.Now;
            rSortingApplicability["lu"] = "Software And More";

            tSortingApplicability.Rows.Add(rSortingApplicability);

            // Popolamento di SORTING
            Hashtable htCodiciClass;
            DataTable tSorting = popolaSorting(form, sourceConn, destConn, nmaxidsorkind, out htCodiciClass);
            if (tSorting == null) {
                MessageBox.Show(form, "Errore nel riempimento della tabella SORTING", "Errore");
                return false;
            }
            DataTable tItinerationSorting = popolaItinerationSorting(form, sourceConn, destConn, nmaxidsorkind, htCodiciClass);

            DataSet ds = new DataSet();
            ds.Tables.Add(tSortingKind);
            ds.Tables.Add(tSortingLevel);
            ds.Tables.Add(tSortingApplicability);
            ds.Tables.Add(tSorting);
            ds.Tables.Add(tItinerationSorting);

            return Migrazione.lanciaScript(form, destConn, ds, "classmissione -> struttura di sortingkind e figli + itinerationsorting");
        }

        private static DataTable popolaSorting(Form form, DataAccess sourceConn, DataAccess destConn, 
                int idsorkind, out Hashtable htCodiciClass) {
            htCodiciClass = new Hashtable();
            DataTable tClassMissione = DataAccess.CreateTableByName(sourceConn, "classmissione", "codiceclass, descrizione");
            DataAccess.RUN_SELECT_INTO_TABLE(sourceConn, tClassMissione, "codiceclass", null, null, true);
            if (tClassMissione == null) return null;

            DataTable tSorting = DataAccess.CreateTableByName(destConn, "sorting", "*");
            int maxidsor = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("sorting", null, "max(idsor)"));
            foreach(DataRow rClassMissione in tClassMissione.Rows) {
                maxidsor++;
                DataRow rSorting = tSorting.NewRow();
                rSorting["idsorkind"] = idsorkind;
                rSorting["idsor"] = maxidsor;
                rSorting["description"] = rClassMissione["descrizione"];
                rSorting["nlevel"] = 1;
                rSorting["printingorder"] = "";
                rSorting["sortcode"] = rClassMissione["codiceclass"];
                rSorting["ct"] = DateTime.Now;
                rSorting["cu"] = "Software And More";
                rSorting["lt"] = DateTime.Now;
                rSorting["lu"] = "Software And More";
                tSorting.Rows.Add(rSorting);
                htCodiciClass[rSorting["sortcode"].ToString().ToUpper()] = maxidsor;
            }
            return tSorting;
        }

        private static DataTable popolaItinerationSorting(Form form, DataAccess sourceConn, DataAccess destConn,
                int idsorkind, Hashtable htCodiciClass) {
            DataTable tItinerationSorting = DataAccess.CreateTableByName(destConn, "itinerationsorting", "*");
            DataTable tMissione = DataAccess.CreateTableByName(sourceConn, "missione", "esercmissione, nummissione, codiceclass");
            sourceConn.RUN_SELECT_INTO_TABLE(tMissione, "esercmissione, nummissione", "(codiceclass is not null)", null, true);
            if (tMissione == null) {
                MessageBox.Show(form, "Errore nell'estrazione dei dati della classificazione diretta della missione", "Errore");
                return null;
            }
            foreach (DataRow rMissione in tMissione.Rows) {
                DataRow rItinerationSorting = tItinerationSorting.NewRow();
                rItinerationSorting["idsorkind"] = idsorkind;
                rItinerationSorting["idsor"] = htCodiciClass[rMissione["codiceclass"].ToString().ToUpper()];
                rItinerationSorting["nitineration"] = rMissione["nummissione"];
                rItinerationSorting["yitineration"] = rMissione["esercmissione"];
                rItinerationSorting["quota"] = 1;
                rItinerationSorting["ct"] = DateTime.Now;
                rItinerationSorting["cu"] = "Software And More";
                rItinerationSorting["lt"] = DateTime.Now;
                rItinerationSorting["lu"] = "Software And More";

                tItinerationSorting.Rows.Add(rItinerationSorting);
            }

            return tItinerationSorting;
        }

       

        public static Hashtable lookupidForeignCountry = new Hashtable();
        private static bool migraLocalita(Form form, DataAccess sourceConn, DataAccess destConn) {
            Hashtable internallookupidForeignCountry = new Hashtable();
            internallookupidForeignCountry["1"] = "Z200";
            internallookupidForeignCountry["2"] = "Z100";
            internallookupidForeignCountry["3"] = "Z301";
            internallookupidForeignCountry["4"] = "Z512";
            internallookupidForeignCountry["5"] = "Z302";
            internallookupidForeignCountry["6"] = "Z203";
            internallookupidForeignCountry["7"] = "Z600";
            internallookupidForeignCountry["8"] = "Z700";
            internallookupidForeignCountry["9"] = "Z102";
            internallookupidForeignCountry["10"] = "Z102/V";
            internallookupidForeignCountry["11"] = "Z502";
            internallookupidForeignCountry["12"] = "Z204";
            internallookupidForeignCountry["13"] = "Z249";
            internallookupidForeignCountry["14"] = "Z522";
            internallookupidForeignCountry["15"] = "Z103";
            internallookupidForeignCountry["16"] = "Z103/B";
            internallookupidForeignCountry["17"] = "Z107";
            internallookupidForeignCountry["18"] = "Z205";
            internallookupidForeignCountry["19"] = "Z206/OLD";
            internallookupidForeignCountry["20"] = "Z601";
            internallookupidForeignCountry["21"] = "Z358";
            internallookupidForeignCountry["22"] = "Z602";
            internallookupidForeignCountry["23"] = "Z104";
            internallookupidForeignCountry["24"] = "Z305";
            internallookupidForeignCountry["25"] = "Z208";
            internallookupidForeignCountry["26"] = "Z306";
            internallookupidForeignCountry["27"] = "Z401";
            internallookupidForeignCountry["28"] = "Z307";
            internallookupidForeignCountry["29"] = "Z105";
            internallookupidForeignCountry["30"] = "Z308";
            internallookupidForeignCountry["31"] = "Z309";
            internallookupidForeignCountry["32"] = "Z603";
            internallookupidForeignCountry["33"] = "Z210";
            internallookupidForeignCountry["34"] = "Z217";
            internallookupidForeignCountry["35"] = "Z211";
            internallookupidForeignCountry["36"] = "Z604";
            internallookupidForeignCountry["37"] = "Z310";
            internallookupidForeignCountry["38"] = "Z311";
            internallookupidForeignCountry["39"] = "Z214";
            internallookupidForeignCountry["40"] = "Z213";
            internallookupidForeignCountry["41"] = "Z503";
            internallookupidForeignCountry["42"] = "Z313";
            internallookupidForeignCountry["43"] = "Z504";
            internallookupidForeignCountry["44"] = "Z314";
            internallookupidForeignCountry["45"] = "Z526";
            internallookupidForeignCountry["46"] = "Z505";
            internallookupidForeignCountry["47"] = "Z605";
            internallookupidForeignCountry["48"] = "Z336";
            internallookupidForeignCountry["49"] = "Z506";
            internallookupidForeignCountry["50"] = "Z215";
            internallookupidForeignCountry["51"] = "Z315";
            internallookupidForeignCountry["52"] = "Z704";
            internallookupidForeignCountry["53"] = "Z216";
            internallookupidForeignCountry["54"] = "Z109";
            internallookupidForeignCountry["55"] = "Z109/H";
            internallookupidForeignCountry["56"] = "Z110";
            internallookupidForeignCountry["57"] = "Z110/P";
            internallookupidForeignCountry["58"] = "Z316";
            internallookupidForeignCountry["59"] = "Z317";
            internallookupidForeignCountry["60"] = "Z112/BB";
            internallookupidForeignCountry["62"] = "Z112";
            internallookupidForeignCountry["63"] = "Z318";
            internallookupidForeignCountry["64"] = "Z507";
            internallookupidForeignCountry["65"] = "Z219";
            internallookupidForeignCountry["66"] = "Z219/T";
            internallookupidForeignCountry["67"] = "Z361";
            internallookupidForeignCountry["68"] = "Z220";
            internallookupidForeignCountry["69"] = "Z114";
            internallookupidForeignCountry["70"] = "Z114/L";
            internallookupidForeignCountry["71"] = "Z115";
            internallookupidForeignCountry["72"] = "Z524";
            internallookupidForeignCountry["73"] = "Z509";
            internallookupidForeignCountry["74"] = "Z319";
            internallookupidForeignCountry["75"] = "Z321";
            internallookupidForeignCountry["76"] = "Z320";
            internallookupidForeignCountry["77"] = "Z606";
            internallookupidForeignCountry["78"] = "Z510";
            internallookupidForeignCountry["79"] = "Z511";
            internallookupidForeignCountry["80"] = "Z221";
            internallookupidForeignCountry["81"] = "Z222";
            internallookupidForeignCountry["82"] = "Z223";
            internallookupidForeignCountry["83"] = "Z224";
            internallookupidForeignCountry["84"] = "Z225";
            internallookupidForeignCountry["85"] = "Z116";
            internallookupidForeignCountry["86"] = "Z117";
            internallookupidForeignCountry["87"] = "Z226";
            internallookupidForeignCountry["88"] = "Z118/OLD";
            internallookupidForeignCountry["89"] = "Z322";
            internallookupidForeignCountry["90"] = "Z731";
            internallookupidForeignCountry["91"] = "Z227";
            internallookupidForeignCountry["92"] = "Z228";
            internallookupidForeignCountry["93"] = "Z359";
            internallookupidForeignCountry["94"] = "Z229";
            internallookupidForeignCountry["95"] = "Z325";
            internallookupidForeignCountry["96"] = "Z326";
            internallookupidForeignCountry["97"] = "Z119";
            internallookupidForeignCountry["98"] = "Z120";
            internallookupidForeignCountry["99"] = "Z327";
            internallookupidForeignCountry["100"] = "Z328";
            internallookupidForeignCountry["101"] = "Z247";
            internallookupidForeignCountry["102"] = "Z232";
            internallookupidForeignCountry["103"] = "Z329";
            internallookupidForeignCountry["104"] = "Z121";
            internallookupidForeignCountry["105"] = "Z330";
            internallookupidForeignCountry["106"] = "Z331";
            internallookupidForeignCountry["107"] = "Z332";
            internallookupidForeignCountry["108"] = "Z514";
            internallookupidForeignCountry["109"] = "Z123";
            internallookupidForeignCountry["110"] = "Z233";
            internallookupidForeignCountry["111"] = "Z333";
            internallookupidForeignCountry["112"] = "Z713";
            internallookupidForeignCountry["113"] = "Z234";
            internallookupidForeignCountry["114"] = "Z515";
            internallookupidForeignCountry["115"] = "Z334";
            internallookupidForeignCountry["116"] = "Z335";
            internallookupidForeignCountry["117"] = "Z125";
            internallookupidForeignCountry["118"] = "Z719";
            internallookupidForeignCountry["119"] = "Z126";
            internallookupidForeignCountry["120"] = "Z235";
            internallookupidForeignCountry["121"] = "Z236";
            internallookupidForeignCountry["122"] = "Z516";
            internallookupidForeignCountry["123"] = "Z730";
            internallookupidForeignCountry["124"] = "Z610";
            internallookupidForeignCountry["125"] = "Z611";
            internallookupidForeignCountry["126"] = "Z127";
            internallookupidForeignCountry["127"] = "Z128";
            internallookupidForeignCountry["128"] = "Z237";
            internallookupidForeignCountry["129"] = "Z129";
            internallookupidForeignCountry["130"] = "Z338";
            internallookupidForeignCountry["131"] = "Z527";
            internallookupidForeignCountry["132"] = "Z528";
            internallookupidForeignCountry["133"] = "Z724";
            internallookupidForeignCountry["134"] = "Z726";
            internallookupidForeignCountry["135"] = "Z341";
            internallookupidForeignCountry["136"] = "Z342";
            internallookupidForeignCountry["137"] = "Z343";
            internallookupidForeignCountry["138"] = "Z344";
            internallookupidForeignCountry["139"] = "Z248";
            internallookupidForeignCountry["140"] = "Z240";
            internallookupidForeignCountry["141"] = "Z345";
            internallookupidForeignCountry["142"] = "Z131";
            internallookupidForeignCountry["143"] = "Z131/M";
            internallookupidForeignCountry["144"] = "Z209";
            internallookupidForeignCountry["145"] = "Z404";
            internallookupidForeignCountry["146"] = "Z404/N";
            internallookupidForeignCountry["147"] = "Z404/W";
            internallookupidForeignCountry["148"] = "Z347";
            internallookupidForeignCountry["149"] = "Z348";
            internallookupidForeignCountry["150"] = "Z608";
            internallookupidForeignCountry["151"] = "Z132";
            internallookupidForeignCountry["152"] = "Z133";
            internallookupidForeignCountry["153"] = "Z133/GB";
            internallookupidForeignCountry["154"] = "Z349";
            internallookupidForeignCountry["155"] = "Z357";
            internallookupidForeignCountry["156"] = "Z241";
            internallookupidForeignCountry["157"] = "Z351";
            internallookupidForeignCountry["158"] = "Z728";
            internallookupidForeignCountry["159"] = "Z612";
            internallookupidForeignCountry["160"] = "Z352";
            internallookupidForeignCountry["161"] = "Z243";
            internallookupidForeignCountry["162"] = "Z354";
            internallookupidForeignCountry["163"] = "Z732";
            internallookupidForeignCountry["164"] = "Z353";
            internallookupidForeignCountry["165"] = "Z134";
            internallookupidForeignCountry["166"] = "Z613";
            internallookupidForeignCountry["167"] = "Z733";
            internallookupidForeignCountry["168"] = "Z614";
            internallookupidForeignCountry["169"] = "Z251";
            internallookupidForeignCountry["170"] = "Z246";
            internallookupidForeignCountry["171"] = "Z250";
            internallookupidForeignCountry["172"] = "Z312/OLD";
            internallookupidForeignCountry["173"] = "Z355";
            internallookupidForeignCountry["174"] = "Z337";
            internallookupidForeignCountry["175"] = "Z153";
            internallookupidForeignCountry["176"] = "Z149";
            internallookupidForeignCountry["177"] = "Z148";
            internallookupidForeignCountry["178"] = "Z150";
            internallookupidForeignCountry["179"] = "Z252";
            internallookupidForeignCountry["180"] = "Z253";
            internallookupidForeignCountry["181"] = "Z139";
            internallookupidForeignCountry["182"] = "Z156";
            internallookupidForeignCountry["183"] = "Z368";
            internallookupidForeignCountry["184"] = "Z144";
            internallookupidForeignCountry["185"] = "Z254";
            internallookupidForeignCountry["186"] = "Z255";
            internallookupidForeignCountry["187"] = "Z256";
            internallookupidForeignCountry["188"] = "Z145";
            internallookupidForeignCountry["189"] = "Z146";
            internallookupidForeignCountry["190"] = "Z140";
            internallookupidForeignCountry["191"] = "Z154";
            internallookupidForeignCountry["192"] = "Z154/M";
            internallookupidForeignCountry["193"] = "Z155";
            internallookupidForeignCountry["194"] = "Z257";
            internallookupidForeignCountry["195"] = "Z258";
            internallookupidForeignCountry["196"] = "Z259";
            internallookupidForeignCountry["197"] = "Z138";
            internallookupidForeignCountry["198"] = "Z300";
            internallookupidForeignCountry["199"] = "Z716";
            internallookupidForeignCountry["200"] = "Z312";
            internallookupidForeignCountry["201"] = "Z206";
            internallookupidForeignCountry["202"] = "Z118";

            QueryHelper QHS = destConn.GetQueryHelper();
            DataTable Existent = destConn.SQLRunner("SELECT * from foreigncountry");
            foreach (DataRow RC in Existent.Rows) {
                string codice = RC["codeforeigncountry"].ToString().ToUpper();
                lookupidForeignCountry[codice] = RC["idforeigncountry"];
            }
            DataTable All = sourceConn.SQLRunner("SELECT * from localita");
            DataTable foreigncountry = destConn.CreateTableByName("foreigncountry", "*");
            int nmaxidforeigncountry = CfgFn.GetNoNullInt32(destConn.DO_READ_VALUE("foreigncountry", null, "max(idforeigncountry)"));
            foreach (DataRow Curr in All.Rows) {
                string extcodice = Curr["codicelocalita"].ToString().ToUpper();
                object codice = extcodice;
                if (internallookupidForeignCountry[extcodice] != null)
                    codice = internallookupidForeignCountry[extcodice];

                if (lookupidForeignCountry[codice] != null) {
                    lookupidForeignCountry[extcodice] = lookupidForeignCountry[codice];
                    continue;
                }
                //Codice non presente, lo aggiunge a foreigncountry e al lookup
                
                //Lo cerca prima sulle descrizioni
                DataTable EX = destConn.RUN_SELECT("foreigncountry", "*", null,
                            QHS.CmpEq("description", Curr["descrizione"]), null, false);
                if (EX.Rows.Count > 0) {
                    object idex = EX.Rows[0]["idforeigncountry"];
                    internallookupidForeignCountry[extcodice] = idex;
                    continue;
                }
                nmaxidforeigncountry++;
                //Niente da fare, lo aggiunge
                DataRow R = foreigncountry.NewRow();
                internallookupidForeignCountry[extcodice] = nmaxidforeigncountry;

                R["idforeigncountry"] = nmaxidforeigncountry;
                R["codeforeigncountry"] = extcodice;
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                foreigncountry.Rows.Add(R);                        
            }
            if (foreigncountry.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(foreigncountry);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento foreigncountry");

        }


        public static Hashtable lookupidreduction = new Hashtable();
        static bool migraReduction_eseguito = false;
        private static bool migraReduction(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraReduction_eseguito) return true;
            migraReduction_eseguito = true;

            lookupidreduction["RID25%"] = "25";
            lookupidreduction["RID33%"] = "33";
            lookupidreduction["RID50%"] = "50";
            lookupidreduction["RID66%"] = "66";
            lookupidreduction["RID75%"] = "75";
            lookupidreduction["RID100%"] = "100";

            QueryHelper QHS = destConn.GetQueryHelper();

            DataTable All = sourceConn.SQLRunner("SELECT * from tiporiduzione");
            DataTable Reduction = destConn.CreateTableByName("reduction", "*");
            foreach (DataRow Curr in All.Rows) {
                string codice = Curr["codiceriduzione"].ToString().ToUpper();
                if (lookupidreduction[codice] != null) continue;
                //Codice non presente, lo aggiunge a foreigncountry e al lookup
                
                //Lo cerca prima sulle descrizioni
                DataTable EX = destConn.RUN_SELECT("reduction", "*", null,
                            QHS.CmpEq("description", Curr["descrizione"]), null, false);
                if (EX.Rows.Count > 0) {
                    object idex = EX.Rows[0]["idreduction"];
                    lookupidreduction[codice] = idex;
                    continue;
                }

                //Niente da fare, lo aggiunge
                DataRow R = Reduction.NewRow();
                R["idreduction"] = codice;
                lookupidreduction[codice] = codice;
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Reduction.Rows.Add(R);                        
            }
            if (Reduction.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Reduction);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Reduction");

        }

        public static Hashtable lookupiditinerationrefundkind = new Hashtable();
        public static bool migraItinerationRefundKind_eseguito = false;
        public static bool migraItinerationRefundKind(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (migraItinerationRefundKind_eseguito) return true;
            migraItinerationRefundKind_eseguito = true;

            Hashtable mylookup = new Hashtable();
            mylookup["AEREO"] = "07_FLY";
            mylookup["ALBERGHI"] = "07_HOTEL";
            mylookup["AUTOBUS"] = "07_BUS";
            mylookup["AUTONOLEGG"] = "07_MOBRENT";
            mylookup["CARBURANTI"] = "07_FUEL";
            mylookup["CONGRESSI"] = "07_CONFERENCE";
            mylookup["CUCCETTA"] = "07_BERTH";
            mylookup["NAVE"] = "07_BOAT";
            mylookup["PASTI"] = "07_MEAL";
            mylookup["PEDAGGI"] = "07_FEE";
            mylookup["POSTOLETTO"] = "07_BED";
            mylookup["SUPPLEMENT"] = "07_EXTRA";
            mylookup["TAXI"] = "07_CAB";
            mylookup["TRENO"] = "07_TRAIN";
            mylookup["VAGONLETTO"] = "07_WAGONLIT";

            DataTable Existent = destConn.SQLRunner("SELECT * from itinerationrefundkind");
            foreach (DataRow RC in Existent.Rows) {
                string codice = RC["codeitinerationrefundkind"].ToString().ToUpper() ;
                lookupiditinerationrefundkind[codice] = RC["iditinerationrefundkind"];
            }

            QueryHelper QHS = destConn.GetQueryHelper();

            DataTable All = sourceConn.SQLRunner("SELECT * from classspesemissione");
            DataTable Itinerationrefundkind = destConn.CreateTableByName("itinerationrefundkind", "*");
            int nmaxitinerationrefkind = CfgFn.GetNoNullInt32(
                destConn.DO_READ_VALUE("itinerationrefundkind", null, "max(iditinerationrefundkind)"));
            foreach (DataRow Curr in All.Rows) {
                string extcodice = Curr["codiceclass"].ToString().ToUpper();
                object codice = extcodice;
                //Converte il codice alfa da campus a easy
                if (mylookup[extcodice] != null) codice = mylookup[extcodice];

                if (lookupiditinerationrefundkind[codice] != null) {
                    lookupiditinerationrefundkind[extcodice] = lookupiditinerationrefundkind[codice];
                    continue;
                }
                //Codice non presente, lo aggiunge a foreigncountry e al lookup
                
                //Lo cerca anche sulle descrizioni
                DataTable EX = destConn.RUN_SELECT("itinerationrefundkind", "*", null,
                            QHS.CmpEq("description", Curr["descrizione"]), null, false);
                if (EX.Rows.Count > 0) {
                    object idex = EX.Rows[0]["iditinerationrefundkind"];
                    lookupiditinerationrefundkind[extcodice] = idex;
                    continue;
                }
                
                //Niente da fare, lo aggiunge
                nmaxitinerationrefkind++;
                DataRow R = Itinerationrefundkind.NewRow();
                R["iditinerationrefundkind"] = nmaxitinerationrefkind;
                R["codeitinerationrefundkind"] = codice;
                lookupiditinerationrefundkind[extcodice] = nmaxitinerationrefkind;
                R["description"] = Curr["descrizione"];
                R["lu"] = Curr["lastmoduser"];
                R["cu"] = Curr["createuser"];
                R["lt"] = Curr["lastmodtimestamp"];
                R["ct"] = Curr["createtimestamp"];
                Itinerationrefundkind.Rows.Add(R);                        
            }
            if (Itinerationrefundkind.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(Itinerationrefundkind);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento Itinerationrefundkind");

        }

        public static bool migraAutomPercentuale(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("taxpaymentpartsetup", null, false) > 0) return true;
            MigraTipoRitenuta(form, sourceConn, destConn);
            string query = "SELECT REG.idreg,M.codiceritenuta,ct=M.createtimestamp,cu=M.createuser," +
                "ayear=M.esercizio,lt=M.lastmodtimestamp,lu=M.lastmoduser,percentage=M.percentuale " +
                "from automatismipercentuale M " +
                "join creditoredebitore CR on M.codicecreddeb=CR.codicecreddeb " +
                "join " + getExtAccess(destConn, "registry", true) + " REG " +
                " ON REG.title=CR.denominazione ";
            DataTable All = sourceConn.SQLRunner(query);
            if (All.Rows.Count==0) return true;
            DataTable TaxPS = destConn.CreateTableByName("taxpaymentpartsetup", "*");
            foreach (DataRow Curr in All.Rows) {
                DataRow R = TaxPS.NewRow();
                R["taxcode"] = lookuptaxcode[Curr["codiceritenuta"].ToString().ToUpper()];
                foreach (string S in new string[] { "idreg",  "ct", "cu", "ayear", "lt", "lu", "percentage" }) {
                    R[S] = Curr[S];
                }
                TaxPS.Rows.Add(R);
            }
            if (TaxPS.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(TaxPS);
            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento taxpaymentpartsetup da automatismipercentuale");



        }

        public static bool migraItinerationLap(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("itinerationlap",null,false)>0) return true;
            migraLocalita(form,sourceConn,destConn);
            migraReduction(form,sourceConn,destConn);
            migraMissione(form, sourceConn, destConn);

            DataTable All= sourceConn.SQLRunner(
                "SELECT M.esercmissione, M.nummissione,M.codicelocalita, M.codiceriduzione,ct=M.createtimestamp,cu=M.createuser,"+
                "stoptime=M.dataorafine,starttime=M.dataorainizio,description=M.descrizione,"+
                "days=M.giorni,allowance = round(M.indennitacorrisposta * isnull(M.tassocambio,1),2),"+
                "flagitalian=case when M.italiaestero='E' then 'N' else 'S' end,lt=M.lastmodtimestamp," +
                "lu=M.lastmoduser,lapnumber=M.numtappa,hours=M.ore,advancepercentage=M.percanticipo,"+
                "reductionpercentage=M.percriddiaria "+
                "from missionetappa M order by M.esercmissione, M.nummissione,M.dataorainizio "
            );
            if (All.Rows.Count == 0) return true;
            DataTable ItinerationLap = destConn.CreateTableByName("itinerationlap", "*");
            string prevlookup = "";
            int mytappa = 0;
            foreach (DataRow Curr in All.Rows) {
                DataRow R= ItinerationLap.NewRow();
                string lookup = Curr["esercmissione"].ToString() + "-" + Curr["nummissione"].ToString();
                if (lookup == prevlookup)
                    mytappa++;
                else
                    mytappa = 1;
                prevlookup = lookup;
                R["iditineration"] = lookup_idtineration[lookup];
                R["lapnumber"] = mytappa;
                if (Curr["codicelocalita"] != DBNull.Value)
                    R["idforeigncountry"] = lookupidForeignCountry[Curr["codicelocalita"].ToString().ToUpper()];
                if (Curr["codiceriduzione"] != DBNull.Value)
                    R["idreduction"] = lookupidreduction[Curr["codiceriduzione"].ToString().ToUpper()];
                foreach (string S in new string[] { "ct", "cu", "stoptime", "starttime", 
                        "description",  "days", "allowance", "flagitalian", "lt", "lu", 
                              "hours", "advancepercentage", "reductionpercentage", }) {
                    R[S] = Curr[S];
                }
                ItinerationLap.Rows.Add(R);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(ItinerationLap);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ItinerationLap");
        }

        public static bool migraItinerationTax(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("itinerationtax", null, false) > 0) return true;

            MigraTipoRitenuta(form, sourceConn, destConn);
            string query = "SELECT adminrate=M.aliquotaamministrazione,employrate=M.aliquotadipendente,M.codiceritenuta," +
                  "ct=M.createtimestamp,cu=M.createuser,M.esercmissione,taxable=M.imponibile," +
                  "lt=M.lastmodtimestamp,lu=M.lastmoduser,M.nummissione," +
                  "admindenominator=M.quotadenamministrazione,employdenominator=M.quotadendipendente," +
                  "taxabledenominator=M.quotadenimponibile,adminnumerator=M.quotanumamministrazione," +
                  "employnumerator=M.quotanumdipendente,taxablenumerator=M.quotanumimponibile,admintax=M.ritamministrazione," +
                  "employtax=M.ritdipendente from missioneritenuta M";
            DataTable All = sourceConn.SQLRunner(query);
            if (All.Rows.Count == 0) return true;

            DataTable ItinerationTax = destConn.CreateTableByName("itinerationtax", "*");
            foreach (DataRow Curr in All.Rows) {
                string lookup = Curr["esercmissione"].ToString() + "-" + Curr["nummissione"].ToString();
                DataRow R = ItinerationTax.NewRow();
                R["iditineration"] = lookup_idtineration[lookup];
                R["taxcode"] = lookuptaxcode[Curr["codiceritenuta"].ToString().ToUpper()];
                foreach (string S in new string[] { "adminrate", "employrate", "ct", "cu", 
                    "taxable", "lt", "lu",  "admindenominator", "employdenominator", "taxabledenominator", 
                    "adminnumerator", "employnumerator", "taxablenumerator", "admintax", "employtax", }) {
                    R[S] = Curr[S];
                }
            }
            if (ItinerationTax.Rows.Count == 0) return true;
            DataSet ds = new DataSet();
            ds.Tables.Add(ItinerationTax);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ItinerationTax");

        }

        private static bool migraItinerationRefund(Form form, DataAccess sourceConn, DataAccess destConn) {
            if (destConn.RUN_SELECT_COUNT("itinerationrefund", null, false) > 0) return true;

            migraItinerationRefundKind(form, sourceConn, destConn);
            Anagrafica.migraValuta(form, sourceConn, destConn);
            migraLocalita(form, sourceConn, destConn);


            string query = "SELECT ct = S.createtimestamp, cu = S.createuser, lt = S.lastmodtimestamp, lu = S.lastmoduser, " +
                " S.esercmissione, S.nummissione, " +
                " starttime = T.dataorainizio, stoptime = T.dataorafine, exchangerate = ISNULL(S.tassocambio,1)," +
                " description = S.descrizione, S.codicevaluta,  S.codiceclass, " +
                " amount = S.importoeffettivo, extraallowance = ROUND(S.importonominale * S.percindennsuppl, 2), " +
                " advancepercentage = CASE WHEN isnull(T.italiaestero,'I') = 'I' THEN S.percanticipoitalia ELSE S.percanticipoestero END, " +
                " flag_geo = CASE WHEN isnull(T.italiaestero,'I') = 'I' THEN 'I' ELSE NULL END, "+
                " T.codicelocalita, " +
                " nrefund = (SELECT COUNT(*) FROM missionespesa S2 WHERE S2.esercmissione =	S.esercmissione AND " +
                " S2.nummissione = S.nummissione AND ( (S2.numtappa < S.numtappa) OR " +
	            " ((S2.numtappa = S.numtappa) AND (S2.numspesa <= S.numspesa))))" +
	            " FROM missionespesa S JOIN missionetappa T " +
                " ON T.esercmissione = S.esercmissione AND T.nummissione = S.nummissione AND T.numtappa = S.numtappa";

            DataTable All = DataAccess.SQLRunner(sourceConn, query);

            DataTable tForeignCountry = destConn.SQLRunner("select idforeigncountry, flag_ue from foreigncountry");
            DataTable ItinerationRefund = destConn.CreateTableByName("itinerationrefund", "*");

            if (tForeignCountry == null) {
                MessageBox.Show(form, "Errore nell'estrazione dei dati da foreigncountry", "Errore");
                return false;
            }
            Hashtable htFC = new Hashtable();
            foreach (DataRow Curr in All.Rows) {
                DataRow R = ItinerationRefund.NewRow();
                string lookup = Curr["esercmissione"].ToString() + "-" + Curr["nummissione"].ToString();
                R["iditineration"] = lookup_idtineration[lookup];
                R["flag_geo"] = Curr["flag_geo"];
                if (Curr["codicelocalita"] != DBNull.Value) {
                    object idFC = lookupidForeignCountry[Curr["codicelocalita"].ToString().ToUpper()];
                    if (htFC[idFC] == null) {
                        string filter = "(idforeigncountry = " + QueryCreator.quotedstrvalue(idFC, false) + ")";
                        DataRow[] FC = tForeignCountry.Select(filter);
                        htFC[idFC] = FC[0]["flag_ue"];
                    }
                    R["flag_geo"] = htFC[idFC];
                }
                if (Curr["codicevaluta"] != DBNull.Value) {
                    R["idcurrency"] = Anagrafica.lookupidcurrency[Curr["codicevaluta"].ToString().ToUpper()];
                }
                // forse c'è un errore nella costruzione della tabella lookupiditinerationrefundkind perciò l'ho commentato
                if (Curr["codiceclass"] != DBNull.Value) {
                    R["iditinerationrefundkind"] =gethash(lookupiditinerationrefundkind,Curr["codiceclass"].ToString());
                }
                foreach (string S in new string[] {  "ct", "cu", "starttime","stoptime","amount","extraallowance",
                     "description",  "lt", "lu",  "nrefund", "exchangerate" }) {
                    R[S] = Curr[S];
                }
                ItinerationRefund.Rows.Add(R);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(ItinerationRefund);

            return Migrazione.lanciaScript(form, destConn, ds, "Popolamento ItinerationRefund");

        }
        
    }
}
